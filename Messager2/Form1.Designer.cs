namespace Messager2
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Tree = new System.Windows.Forms.TreeView();
			this.filter = new System.Windows.Forms.TextBox();
			this.LblInfo = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.ToggleAutoRefresh = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.btnCatchUnderMouse = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.SendMessageMessage = new System.Windows.Forms.ComboBox();
			this.SendMessageWParam = new System.Windows.Forms.ComboBox();
			this.SendMessageLParam = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.SendMessageOK = new System.Windows.Forms.Button();
			this.SendMessageResult = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.SetWindowLongIndex = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.SetWindowLongLong_SingleSelect = new System.Windows.Forms.ComboBox();
			this.WindowLongGet = new System.Windows.Forms.Button();
			this.SetWindowLongResult = new System.Windows.Forms.Label();
			this.WindowLongSet = new System.Windows.Forms.Button();
			this.SetWindowLongLong_MultiSelect = new System.Windows.Forms.ListBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// Tree
			// 
			this.Tree.Location = new System.Drawing.Point(12, 38);
			this.Tree.Name = "Tree";
			this.Tree.Size = new System.Drawing.Size(390, 400);
			this.Tree.TabIndex = 0;
			this.Tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Tree_SelChange);
			this.Tree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TP_MouseClick);
			// 
			// filter
			// 
			this.filter.Location = new System.Drawing.Point(50, 12);
			this.filter.Name = "filter";
			this.filter.Size = new System.Drawing.Size(285, 20);
			this.filter.TabIndex = 1;
			this.filter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_KP);
			// 
			// LblInfo
			// 
			this.LblInfo.Location = new System.Drawing.Point(408, 12);
			this.LblInfo.Name = "LblInfo";
			this.LblInfo.Size = new System.Drawing.Size(236, 126);
			this.LblInfo.TabIndex = 2;
			this.LblInfo.Text = "...info...";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(341, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(61, 20);
			this.button1.TabIndex = 3;
			this.button1.Text = "Refresh";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Filter:";
			// 
			// ToggleAutoRefresh
			// 
			this.ToggleAutoRefresh.Location = new System.Drawing.Point(411, 415);
			this.ToggleAutoRefresh.Name = "ToggleAutoRefresh";
			this.ToggleAutoRefresh.Size = new System.Drawing.Size(125, 23);
			this.ToggleAutoRefresh.TabIndex = 5;
			this.ToggleAutoRefresh.Text = "Enable auto-refresh";
			this.ToggleAutoRefresh.UseVisualStyleBackColor = true;
			this.ToggleAutoRefresh.Click += new System.EventHandler(this.ToggleAutoRefresh_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(542, 415);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(102, 23);
			this.button2.TabIndex = 6;
			this.button2.Text = "Take snapshot";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// btnCatchUnderMouse
			// 
			this.btnCatchUnderMouse.Location = new System.Drawing.Point(650, 415);
			this.btnCatchUnderMouse.Name = "btnCatchUnderMouse";
			this.btnCatchUnderMouse.Size = new System.Drawing.Size(138, 23);
			this.btnCatchUnderMouse.TabIndex = 7;
			this.btnCatchUnderMouse.Text = "Catch under mouse";
			this.btnCatchUnderMouse.UseVisualStyleBackColor = true;
			this.btnCatchUnderMouse.Click += new System.EventHandler(this.btnCatchUnderMouse_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 21);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(50, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Message";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(15, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(45, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "wParam";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(11, 105);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(39, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "lParam";
			// 
			// SendMessageMessage
			// 
			this.SendMessageMessage.FormattingEnabled = true;
			this.SendMessageMessage.Location = new System.Drawing.Point(14, 37);
			this.SendMessageMessage.Name = "SendMessageMessage";
			this.SendMessageMessage.Size = new System.Drawing.Size(219, 21);
			this.SendMessageMessage.TabIndex = 9;
			this.SendMessageMessage.SelectedValueChanged += new System.EventHandler(this.SendMessageMessage_OnSelChange);
			// 
			// SendMessageWParam
			// 
			this.SendMessageWParam.FormattingEnabled = true;
			this.SendMessageWParam.Location = new System.Drawing.Point(14, 80);
			this.SendMessageWParam.Name = "SendMessageWParam";
			this.SendMessageWParam.Size = new System.Drawing.Size(219, 21);
			this.SendMessageWParam.TabIndex = 9;
			// 
			// SendMessageLParam
			// 
			this.SendMessageLParam.FormattingEnabled = true;
			this.SendMessageLParam.Location = new System.Drawing.Point(14, 121);
			this.SendMessageLParam.Name = "SendMessageLParam";
			this.SendMessageLParam.Size = new System.Drawing.Size(219, 21);
			this.SendMessageLParam.TabIndex = 9;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.SendMessageOK);
			this.groupBox1.Controls.Add(this.SendMessageWParam);
			this.groupBox1.Controls.Add(this.SendMessageLParam);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.SendMessageResult);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.SendMessageMessage);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Location = new System.Drawing.Point(411, 153);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(241, 256);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "SendMessage";
			// 
			// SendMessageOK
			// 
			this.SendMessageOK.Location = new System.Drawing.Point(14, 148);
			this.SendMessageOK.Name = "SendMessageOK";
			this.SendMessageOK.Size = new System.Drawing.Size(219, 23);
			this.SendMessageOK.TabIndex = 10;
			this.SendMessageOK.Text = "Send";
			this.SendMessageOK.UseVisualStyleBackColor = true;
			this.SendMessageOK.Click += new System.EventHandler(this.SendMessageOK_Click);
			// 
			// SendMessageResult
			// 
			this.SendMessageResult.Location = new System.Drawing.Point(11, 174);
			this.SendMessageResult.Name = "SendMessageResult";
			this.SendMessageResult.Size = new System.Drawing.Size(222, 71);
			this.SendMessageResult.TabIndex = 8;
			this.SendMessageResult.Text = "...";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.SetWindowLongLong_MultiSelect);
			this.groupBox2.Controls.Add(this.WindowLongSet);
			this.groupBox2.Controls.Add(this.WindowLongGet);
			this.groupBox2.Controls.Add(this.SetWindowLongLong_SingleSelect);
			this.groupBox2.Controls.Add(this.SetWindowLongIndex);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.SetWindowLongResult);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Location = new System.Drawing.Point(658, 15);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(265, 394);
			this.groupBox2.TabIndex = 11;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Get/SetWindowLong";
			// 
			// SetWindowLongIndex
			// 
			this.SetWindowLongIndex.FormattingEnabled = true;
			this.SetWindowLongIndex.Location = new System.Drawing.Point(14, 38);
			this.SetWindowLongIndex.Name = "SetWindowLongIndex";
			this.SetWindowLongIndex.Size = new System.Drawing.Size(236, 21);
			this.SetWindowLongIndex.TabIndex = 0;
			this.SetWindowLongIndex.SelectedValueChanged += new System.EventHandler(this.SetWindowLong_OnSelChange);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(39, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "nIndex";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(13, 68);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(67, 13);
			this.label6.TabIndex = 8;
			this.label6.Text = "dwNewLong";
			// 
			// SetWindowLongLong_SingleSelect
			// 
			this.SetWindowLongLong_SingleSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
			this.SetWindowLongLong_SingleSelect.FormattingEnabled = true;
			this.SetWindowLongLong_SingleSelect.Location = new System.Drawing.Point(14, 84);
			this.SetWindowLongLong_SingleSelect.Name = "SetWindowLongLong_SingleSelect";
			this.SetWindowLongLong_SingleSelect.Size = new System.Drawing.Size(236, 215);
			this.SetWindowLongLong_SingleSelect.TabIndex = 9;
			// 
			// WindowLongGet
			// 
			this.WindowLongGet.Location = new System.Drawing.Point(14, 302);
			this.WindowLongGet.Name = "WindowLongGet";
			this.WindowLongGet.Size = new System.Drawing.Size(75, 23);
			this.WindowLongGet.TabIndex = 10;
			this.WindowLongGet.Text = "Get";
			this.WindowLongGet.UseVisualStyleBackColor = true;
			this.WindowLongGet.Click += new System.EventHandler(this.WindowLongGet_Click);
			// 
			// SetWindowLongResult
			// 
			this.SetWindowLongResult.Location = new System.Drawing.Point(16, 335);
			this.SetWindowLongResult.Name = "SetWindowLongResult";
			this.SetWindowLongResult.Size = new System.Drawing.Size(234, 48);
			this.SetWindowLongResult.TabIndex = 8;
			this.SetWindowLongResult.Text = "...";
			// 
			// WindowLongSet
			// 
			this.WindowLongSet.Location = new System.Drawing.Point(95, 302);
			this.WindowLongSet.Name = "WindowLongSet";
			this.WindowLongSet.Size = new System.Drawing.Size(75, 23);
			this.WindowLongSet.TabIndex = 10;
			this.WindowLongSet.Text = "Set";
			this.WindowLongSet.UseVisualStyleBackColor = true;
			this.WindowLongSet.Click += new System.EventHandler(this.SetWindowLongSet_Click);
			// 
			// SetWindowLongLong_MultiSelect
			// 
			this.SetWindowLongLong_MultiSelect.FormattingEnabled = true;
			this.SetWindowLongLong_MultiSelect.IntegralHeight = false;
			this.SetWindowLongLong_MultiSelect.Location = new System.Drawing.Point(14, 84);
			this.SetWindowLongLong_MultiSelect.Name = "SetWindowLongLong_MultiSelect";
			this.SetWindowLongLong_MultiSelect.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.SetWindowLongLong_MultiSelect.Size = new System.Drawing.Size(236, 212);
			this.SetWindowLongLong_MultiSelect.TabIndex = 11;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(935, 450);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnCatchUnderMouse);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.ToggleAutoRefresh);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.LblInfo);
			this.Controls.Add(this.filter);
			this.Controls.Add(this.Tree);
			this.Name = "Form1";
			this.Text = "Messager";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.TreeView Tree;
		private System.Windows.Forms.TextBox filter;
		internal System.Windows.Forms.Label LblInfo;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button ToggleAutoRefresh;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button btnCatchUnderMouse;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox SendMessageMessage;
		private System.Windows.Forms.ComboBox SendMessageWParam;
		private System.Windows.Forms.ComboBox SendMessageLParam;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button SendMessageOK;
		private System.Windows.Forms.Label SendMessageResult;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button WindowLongGet;
		private System.Windows.Forms.ComboBox SetWindowLongLong_SingleSelect;
		private System.Windows.Forms.ComboBox SetWindowLongIndex;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label SetWindowLongResult;
		private System.Windows.Forms.Button WindowLongSet;
		private System.Windows.Forms.ListBox SetWindowLongLong_MultiSelect;
	}
}

