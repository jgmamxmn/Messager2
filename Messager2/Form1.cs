using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Messager2
{
	public partial class Form1 : Form
	{
		FormMgr FM;
		public Form1()
		{
			InitializeComponent();
			FM = new FormMgr(this);

			WindowMessages = Sender.AllWMMessages();
			SendMessageMessage.Items.AddRange(WindowMessages.ToArray());
			SendMessageResult.Text = "";

			Longs = Sender.AllGWLs();
			SetWindowLongIndex.Items.AddRange(Longs.ToArray());
			SetWindowLongLong_SingleSelect.Visible = true;
			SetWindowLongLong_MultiSelect.Visible = false;
		}

		private void TB_KP(object sender, KeyPressEventArgs e)
		{
			bool bUnfilter=string.IsNullOrEmpty(filter.Text);
			FilterAll(M => bUnfilter || M.Text.IndexOf(filter.Text, StringComparison.CurrentCultureIgnoreCase) >= 0);
		}

		private void FilterAll(Predicate<TreeNode> test)
		{ 
			List<TreeNode> Visible = new List<TreeNode>();
			List<TreeNode> Invisible = new List<TreeNode>();

			foreach (TreeNode N in Tree.Nodes)
			{
				if (DoFilter(test, N))
					Visible.Add(N);
				else
					Invisible.Add(N);
			}

			Visible.Sort((A, B) => string.Compare(A.Text, B.Text));
			Invisible.Sort((A, B) => string.Compare(A.Text, B.Text));

			Tree.Nodes.Clear();
			Tree.Nodes.AddRange(Visible.ToArray());
			Tree.Nodes.AddRange(Invisible.ToArray());
		}
		private bool DoFilter(Predicate<TreeNode> test, TreeNode top)
		{
			bool bVisible = false, bInhVisible=false;
			if (test(top))
				bVisible = true;
			else if(top.Nodes.Count>0)
			{
				foreach (TreeNode subN in top.Nodes)
					bInhVisible |= DoFilter(test, subN);
			}

			if (bVisible)
				top.ForeColor = Color.Black;
			else if (bInhVisible)
			{
				top.Expand();
				top.ForeColor = Color.Gray;
			}
			else
				top.ForeColor = Color.LightGray;

			return (bVisible || bInhVisible);
		}

		private void Tree_SelChange(object sender, TreeViewEventArgs e)
		{
			if (!(e.Node is object) || !e.Node.IsSelected)
				return;

			((Win)e.Node).Populate();

			Form1.AutoRefreshParentWin = ((Win)e.Node).HWnd;
		}

		private void TP_MouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			/*foreach (TreeNode N in Tree.Nodes)
				((Win)N).SelCheck();*/
		}

		private void button1_Click(object sender, EventArgs e)
		{
			FM.Rebuild();
		}

		enum eAutoRefreshModality { AutoRefresh, Snapshot };
		private bool AutoRefresh = false;
		static eAutoRefreshModality AutoRefreshModality;
		static int SnapshotTimer;
		static Timer RefreshTimer = null;
		static Form1 AutoRefreshRef;
		static IntPtr AutoRefreshParentWin = IntPtr.Zero;
		private void ToggleAutoRefresh_Click(object sender, EventArgs e)
		{
			AutoRefresh = !AutoRefresh;

			if(AutoRefresh)
			{
				AutoRefreshModality = eAutoRefreshModality.AutoRefresh;
				Form1.AutoRefreshRef = this;
				ToggleAutoRefresh.Text = "Disable auto-refresh";
				RefreshTimer = new Timer();
				RefreshTimer.Tick += AutoRefreshLoop;
				RefreshTimer.Interval = 500;
				RefreshTimer.Start();
			}
			else
			{
				ToggleAutoRefresh.Text = "Enable auto-refresh";
				RefreshTimer.Stop();
				RefreshTimer = null;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Form1.AutoRefreshModality = eAutoRefreshModality.Snapshot;
			Form1.SnapshotTimer = 5;
			Form1.AutoRefreshRef = this;
			button2.Text = SnapshotTimer.ToString();
			RefreshTimer = new Timer();
			RefreshTimer.Tick += AutoRefreshLoop;
			RefreshTimer.Interval = 1000;
			RefreshTimer.Start();
		}
		private static void AutoRefreshLoop(Object myObject, EventArgs myEventArgs)
		{
			switch (Form1.AutoRefreshModality)
			{
				case eAutoRefreshModality.Snapshot:
					--SnapshotTimer;
					if (SnapshotTimer <= 0)
					{
						AutoRefreshRef.button2.Text = "Take snapshot";
						Form1.RefreshTimer.Stop();
						Form1.AutoRefreshRef.FM.Rebuild(); //.RebuildSubSet(Form1.AutoRefreshParentWin);
					}
					else
					{
						AutoRefreshRef.button2.Text = SnapshotTimer.ToString();
					}
					break;
				case eAutoRefreshModality.AutoRefresh:
					Form1.AutoRefreshRef.FM.RebuildSubSet(Form1.AutoRefreshParentWin);
					break;
			}
		}

		bool CatchUnderMouseSearching = false;
		private void btnCatchUnderMouse_Click(object sender, EventArgs e)
		{
			if(!CatchUnderMouseSearching)
			{
				CatchUnderMouseSearching = true;
				btnCatchUnderMouse.Text = "Press space to catch";
				btnCatchUnderMouse.Focus();
			}
			else
			{
				CatchUnderMouseSearching = false;
				btnCatchUnderMouse.Text = "Catch under mouse";
				API.POINT Pnt;
				API.GetCursorPos(out Pnt);
				FilterAll(M =>
				{
					Win W = M as Win;
					API.WINDOWPLACEMENT WP;
					API.GetWindowPlacement(W.HWnd, out WP);
					switch(WP.ShowCmd)
					{
						case API.ShowWindowCommands.Hide: case API.ShowWindowCommands.Minimize: case API.ShowWindowCommands.ShowMinimized: case API.ShowWindowCommands.ShowMinNoActive:
							return false;
						case API.ShowWindowCommands.Maximize: 
							return true;
					}
					API.RECT R;
					API.GetWindowRect(W.HWnd, out R);
					return R.Left <= Pnt.X && R.Right >= Pnt.X && R.Top <= Pnt.Y && R.Bottom >= Pnt.Y;
				});
			}
		}



		private List<WM> WindowMessages;
		private void SendMessageMessage_OnSelChange(object sender, EventArgs e)
		{
			var Msg = WindowMessages.FirstOrDefault(M => M.MessageName == SendMessageMessage.Text);
			if(Msg!=null)
			{
				SendMessageWParam.Items.Clear();
				foreach(var wKVP in Msg.wParams)
				{
					SendMessageWParam.Items.Add(wKVP.Key);
				}
			}
		}

		private void SendMessageOK_Click(object sender, EventArgs e)
		{
			int M, W;
			IntPtr L;
			var Msg = WindowMessages.FirstOrDefault(N => N.MessageName == SendMessageMessage.Text);
			if (Msg != null)
				M = Msg.ID;
			else if (int.TryParse(SendMessageMessage.Text, out int Parsed))
				M = Parsed;
			else
			{
				MessageBox.Show("Message ID or integer must be specified");
				return;
			}

			if (Msg is object && Msg.wParams.ContainsKey(SendMessageWParam.Text))
				W = Msg.wParams[SendMessageWParam.Text];
			else if (int.TryParse(SendMessageWParam.Text, out int Parsed))
				W = Parsed;
			else
			{
				MessageBox.Show("wParam ID or integer must be specified");
				return;
			}

			if (Msg is object && Msg.lParams.ContainsKey(SendMessageLParam.Text))
				L = Msg.lParams[SendMessageLParam.Text];
			else if (int.TryParse(SendMessageLParam.Text, out int Parsed))
				L = (IntPtr)Parsed;
			else
			{
				MessageBox.Show("lParam ID or integer must be specified");
				return;
			}

			IntPtr res = Sender.SendMessage(FM.Selection.HWnd, M, W, L);
			SendMessageResult.Text = new StringBuilder().Append("Sent message ")
				.AppendFormat("{0,10:X}", M).Append("; ")
				.AppendFormat("{0,10:X}", W).Append("; ")
				.AppendFormat("{0,10:X}", L).Append(" -- result: ")
				.AppendFormat("{0,10:X}", res)
				.ToString();
		}

		List<GWL> Longs;

		private void SetWindowLong_OnSelChange(object sender, EventArgs e)
		{
			var Msg = Longs.FirstOrDefault(M => M.GWLName == SetWindowLongIndex.Text);
			dynamic ToShow, ToHide; // <- LAZY!
			if (Msg != null)
			{
				if(Msg.IsFlag)
				{
					ToShow = SetWindowLongLong_MultiSelect;
					ToHide = SetWindowLongLong_SingleSelect;
				}
				else
				{
					ToShow = SetWindowLongLong_SingleSelect;
					ToHide = SetWindowLongLong_MultiSelect;					
				}

				ToShow.Items.Clear();
				foreach (var wKVP in Msg.LongValues)
				{
					ToShow.Items.Add(wKVP.Key);
				}
			}
			else
			{
				ToShow = SetWindowLongLong_SingleSelect;
				ToHide = SetWindowLongLong_MultiSelect;
			}
			ToShow.Visible = true;
			ToHide.Visible = false;
		}

		private void SetWindowLongSet_Click(object sender, EventArgs e)
		{
			int Index;
			UInt32 NewLong;

			var aGWL = Longs.FirstOrDefault(N => N.GWLName == SetWindowLongIndex.Text);
			if (aGWL != null)
				Index = aGWL.ID;
			else if (int.TryParse(SetWindowLongIndex.Text, out int Parsed))
				Index = Parsed;
			else
			{
				MessageBox.Show("Long type (index) must be specified");
				return;
			}


			if ((aGWL is object) && SetWindowLongLong_SingleSelect.Visible && aGWL.LongValues.ContainsKey(SetWindowLongLong_SingleSelect.Text))
				NewLong = aGWL.LongValues[SetWindowLongLong_SingleSelect.Text];
			else if((aGWL is object) && SetWindowLongLong_MultiSelect.Visible && SetWindowLongLong_MultiSelect.SelectedIndices.Count>0)
			{
				NewLong = 0;
				foreach(var Idx in SetWindowLongLong_MultiSelect.SelectedIndices)
				{
					var Txt = (string)SetWindowLongLong_MultiSelect.Items[(int)Idx];
					if(aGWL.LongValues.TryGetValue(Txt, out UInt32 Lng))
					{
						NewLong |= Lng;
					}
				}
			}
			else if(SetWindowLongLong_SingleSelect.Visible && UInt32.TryParse(SetWindowLongLong_SingleSelect.Text, out UInt32 Parsed))
				NewLong = Parsed;
			else
			{
				MessageBox.Show("Long value must be specified");
				return;
			}

			long res = Sender.SetWindowLong32(FM.Selection.HWnd, Index, NewLong);
			SetWindowLongResult.Text = new StringBuilder().Append("Set window long ")
				.AppendFormat("{0,10:X}", Index).Append("; ")
				.AppendFormat("{0,10:X}", NewLong).Append(" -- result: ")
				.AppendFormat("{0,10:X}", res)
				.ToString();
		}

		private void WindowLongGet_Click(object sender, EventArgs e)
		{
			var aGWL = Longs.FirstOrDefault(N => N.GWLName == SetWindowLongIndex.Text);
			if(aGWL==null)
			{
				MessageBox.Show("Select a long index first.");
				return;
			}

			IntPtr CurrentLongVal = Sender.GetWindowLongPtr(FM.Selection.HWnd, aGWL.ID);

			if(aGWL.IsFlag)
			{
				SetWindowLongLong_MultiSelect.Visible = true;
				SetWindowLongLong_SingleSelect.Visible = false;
				SetWindowLongLong_MultiSelect.SelectedIndices.Clear();
				for(int i=0; i<SetWindowLongLong_MultiSelect.Items.Count; ++i)
				{
					var Item = SetWindowLongLong_MultiSelect.Items[i];

					var S = Item.ToString();
					if(aGWL.LongValues.ContainsKey(S))
					{
						var LongVal = aGWL.LongValues[S];
						if (((long)LongVal & (long)CurrentLongVal) != 0)
							SetWindowLongLong_MultiSelect.SelectedIndices.Add(i);
					}
				}
			}
			else
			{
				SetWindowLongLong_SingleSelect.Visible = true;
				SetWindowLongLong_SingleSelect.Text = ((long)CurrentLongVal).ToString();
				SetWindowLongLong_MultiSelect.Visible = false;
			}

		}
	}
}
