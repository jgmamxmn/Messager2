using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Messager2
{
	internal class Sender
	{
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, StringBuilder lParam);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, ref IntPtr lParam);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);

		// This helper static method is required because the 32-bit version of user32.dll does not contain this API
		// (on any versions of Windows), so linking the method will fail at run-time. The bridge dispatches the request
		// to the correct function (GetWindowLong in 32-bit mode and GetWindowLongPtr in 64-bit mode)
		public static IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
		{
			if (IntPtr.Size == 8)
				return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
			else
				return new IntPtr(SetWindowLong32(hWnd, nIndex, (UInt32)(dwNewLong.ToInt32())));
		}

		[DllImport("user32.dll", EntryPoint = "SetWindowLong")]
		internal static extern int SetWindowLong32(IntPtr hWnd, int nIndex, UInt32 dwNewLong);

		[DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
		internal static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);


		[DllImport("user32.dll", EntryPoint = "GetWindowLong")]
		private static extern IntPtr GetWindowLongPtr32(IntPtr hWnd, int nIndex);

		[DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
		private static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, int nIndex);

		// This static method is required because Win32 does not support
		// GetWindowLongPtr directly
		public static IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex)
		{
			if (IntPtr.Size == 8)
				return GetWindowLongPtr64(hWnd, nIndex);
			else
				return GetWindowLongPtr32(hWnd, nIndex);
		}




		public static List<WM> AllWMMessages()
		{
			return new List<WM>
			{
				new WM("NULL", 0),
				new WM("HSHELL_WINDOWCREATED", 1),
				new WM("HSHELL_WINDOWDESTROYED", 2),
				new WM("HSHELL_ACTIVATESHELLWINDOW", 3),
				new WM("HSHELL_WINDOWACTIVATED", 4),
				new WM("SIZE", 5),
				new WM("ACTIVATE", 6),
				new WM("SETFOCUS", 7),
				new WM("KILLFOCUS", 8),
				new WM("ENABLE", 10),
				new WM("SETREDRAW", 11),
				new WM("SETTEXT", 12),
				new WM("GETTEXT", 13),
				new WM("GETTEXTLENGTH", 14),
				new WM("PAINT", 15),
				new WM("CLOSE", 16),
				new WM("QUERYENDSESSION", 17),
				new WM("QUIT", 18),
				new WM("QUERYOPEN", 19),
				new WM("ERASEBKGND", 20),
				new WM("SYSCOLORCHANGE", 21),
				new WM("ENDSESSION", 22),
				new WM("SHOWWINDOW", 24),
				new WM("WININICHANGE", 26),
				new WM("DEVMODECHANGE", 27),
				new WM("ACTIVATEAPP", 28),
				new WM("FONTCHANGE", 29),
				new WM("TIMECHANGE", 30),
				new WM("CANCELMODE", 31),
				new WM("SETCURSOR", 32),
				new WM("MOUSEACTIVATE", 33),
				new WM("CHILDACTIVATE", 34),
				new WM("QUEUESYNC", 35),
				new WM("GETMINMAXINFO", 36),
				new WM("PAINTICON", 38),
				new WM("ICONERASEBKGND", 39),
				new WM("NEXTDLGCTL", 40),
				new WM("SPOOLERSTATUS", 42),
				new WM("DRAWITEM", 43),
				new WM("MEASUREITEM", 44),
				new WM("DELETEITEM", 45),
				new WM("VKEYTOITEM", 46),
				new WM("CHARTOITEM", 47),
				new WM("SETFONT", 48),
				new WM("GETFONT", 49),
				new WM("SETHOTKEY", 50),
				new WM("GETHOTKEY", 51),
				new WM("QUERYDRAGICON", 55),
				new WM("COMPAREITEM", 57),
				new WM("GETOBJECT", 61),
				new WM("COMPACTING", 65),
				new WM("COMMNOTIFY", 68),
				new WM("WINDOWPOSCHANGING", 70),
				new WM("WINDOWPOSCHANGED", 71),
				new WM("POWER", 72),
				new WM("COPYDATA", 74),
				new WM("CANCELJOURNAL", 75),
				new WM("NOTIFY", 78),
				new WM("INPUTLANGCHANGEREQUEST", 80),
				new WM("INPUTLANGCHANGE", 81),
				new WM("TCARD", 82),
				new WM("HELP", 83),
				new WM("USERCHANGED", 84),
				new WM("NOTIFYFORMAT", 85),
				new WM("CONTEXTMENU", 123),
				new WM("STYLECHANGING", 124),
				new WM("STYLECHANGED", 125),
				new WM("DISPLAYCHANGE", 126),
				new WM("GETICON", 127),
				new WM("SETICON", 128),
				new WM("NCCREATE", 129),
				new WM("NCDESTROY", 130),
				new WM("NCCALCSIZE", 131),
				new WM("NCHITTEST", 132),
				new WM("NCPAINT", 133),
				new WM("NCACTIVATE", 134),
				new WM("GETDLGCODE", 135),
				new WM("SYNCPAINT", 136),
				new WM("NCMOUSEMOVE", 160),
				new WM("NCLBUTTONDOWN", 161),
				new WM("NCLBUTTONUP", 162),
				new WM("NCLBUTTONDBLCLK", 163),
				new WM("NCRBUTTONDOWN", 164),
				new WM("NCRBUTTONUP", 165),
				new WM("NCRBUTTONDBLCLK", 166),
				new WM("NCMBUTTONDOWN", 167),
				new WM("NCMBUTTONUP", 168),
				new WM("NCMBUTTONDBLCLK", 169),
				new WM("NCXBUTTONDOWN", 171),
				new WM("NCXBUTTONUP", 172),
				new WM("NCXBUTTONDBLCLK", 173),
				new WM("INPUT_DEVICE_CHANGE", 254),
				new WM("INPUT", 255),
				new WM("KEYDOWN", 256),
				new WM("KEYUP", 257),
				new WM("CHAR", 258),
				new WM("DEADCHAR", 259),
				new WM("SYSKEYDOWN", 260),
				new WM("SYSKEYUP", 261),
				new WM("SYSCHAR", 262),
				new WM("SYSDEADCHAR", 263),
				new WM("KEYLAST", 264),
				new WM("UNICHAR", 265),
				new WM("IME_STARTCOMPOSITION", 269),
				new WM("IME_ENDCOMPOSITION", 270),
				new WM("IME_COMPOSITION", 271),
				new WM("INITDIALOG", 272),
				new WM("COMMAND", 273),
				new WM("SYSCOMMAND", 274),
				new WM("TIMER", 275),
				new WM("HSCROLL", 276),
				new WM("VSCROLL", 277),
				new WM("INITMENU", 278),
				new WM("INITMENUPOPUP", 279),
				new WM("SYSTIMER", 280),
				new WM("MENUSELECT", 287),
				new WM("MENUCHAR", 288),
				new WM("ENTERIDLE", 289),
				new WM("MENURBUTTONUP", 290),
				new WM("MENUDRAG", 291),
				new WM("MENUGETOBJECT", 292),
				new WM("UNINITMENUPOPUP", 293),
				new WM("MENUCOMMAND", 294),
				new WM("CHANGEUISTATE", 295),
				new WM("UPDATEUISTATE", 296),
				new WM("QUERYUISTATE", 297),
				new WM("CTLCOLORMSGBOX", 306),
				new WM("CTLCOLOREDIT", 307),
				new WM("CTLCOLORLISTBOX", 308),
				new WM("CTLCOLORBTN", 309),
				new WM("CTLCOLORDLG", 310),
				new WM("CTLCOLORSCROLLBAR", 311),
				new WM("CTLCOLORSTATIC", 312),
				new WM("MOUSEMOVE", 512),
				new WM("LBUTTONDOWN", 513),
				new WM("LBUTTONUP", 514),
				new WM("LBUTTONDBLCLK", 515),
				new WM("RBUTTONDOWN", 516),
				new WM("RBUTTONUP", 517),
				new WM("RBUTTONDBLCLK", 518),
				new WM("MBUTTONDOWN", 519),
				new WM("MBUTTONUP", 520),
				new WM("MBUTTONDBLCLK", 521),
				new WM("MOUSEWHEEL", 522),
				new WM("XBUTTONDOWN", 523),
				new WM("XBUTTONUP", 524),
				new WM("XBUTTONDBLCLK", 525),
				new WM("MOUSEHWHEEL", 526),
				new WM("PARENTNOTIFY", 528),
				new WM("ENTERMENULOOP", 529),
				new WM("EXITMENULOOP", 530),
				new WM("NEXTMENU", 531),
				new WM("SIZING", 532),
				new WM("CAPTURECHANGED", 533),
				new WM("MOVING", 534),
				new WM("POWERBROADCAST", 536),
				new WM("DEVICECHANGE", 537),
				new WM("MDICREATE", 544),
				new WM("MDIDESTROY", 545),
				new WM("MDIACTIVATE", 546),
				new WM("MDIRESTORE", 547),
				new WM("MDINEXT", 548),
				new WM("MDIMAXIMIZE", 549),
				new WM("MDITILE", 550),
				new WM("MDICASCADE", 551),
				new WM("MDIICONARRANGE", 552),
				new WM("MDIGETACTIVE", 553),
				new WM("MDISETMENU", 560),
				new WM("ENTERSIZEMOVE", 561),
				new WM("EXITSIZEMOVE", 562),
				new WM("DROPFILES", 563),
				new WM("MDIREFRESHMENU", 564),
				new WM("IME_SETCONTEXT", 641),
				new WM("IME_NOTIFY", 642),
				new WM("IME_CONTROL", 643),
				new WM("IME_COMPOSITIONFULL", 644),
				new WM("IME_SELECT", 645),
				new WM("IME_CHAR", 646),
				new WM("IME_REQUEST", 648),
				new WM("IME_KEYDOWN", 656),
				new WM("IME_KEYUP", 657),
				new WM("NCMOUSEHOVER", 672),
				new WM("MOUSEHOVER", 673),
				new WM("NCMOUSELEAVE", 674),
				new WM("MOUSELEAVE", 675),
				new WM("WTSSESSION_CHANGE", 689),
				new WM("TABLET_FIRST", 704),
				new WM("TABLET_LAST", 735),
				new WM("CUT", 768),
				new WM("COPY", 769),
				new WM("PASTE", 770),
				new WM("CLEAR", 771),
				new WM("UNDO", 772),
				new WM("RENDERFORMAT", 773),
				new WM("RENDERALLFORMATS", 774),
				new WM("DESTROYCLIPBOARD", 775),
				new WM("DRAWCLIPBOARD", 776),
				new WM("PAINTCLIPBOARD", 777),
				new WM("VSCROLLCLIPBOARD", 778),
				new WM("SIZECLIPBOARD", 779),
				new WM("ASKCBFORMATNAME", 780),
				new WM("CHANGECBCHAIN", 781),
				new WM("HSCROLLCLIPBOARD", 782),
				new WM("QUERYNEWPALETTE", 783),
				new WM("PALETTEISCHANGING", 784),
				new WM("PALETTECHANGED", 785),
				new WM("HOTKEY", 786),
				new WM("PRINT", 791),
				new WM("PRINTCLIENT", 792),
				new WM("APPCOMMAND", 793),
				new WM("THEMECHANGED", 794),
				new WM("CLIPBOARDUPDATE", 797),
				new WM("DWMCOMPOSITIONCHANGED", 798),
				new WM("DWMNCRENDERINGCHANGED", 799),
				new WM("DWMCOLORIZATIONCOLORCHANGED", 800),
				new WM("DWMWINDOWMAXIMIZEDCHANGE", 801),
				new WM("GETTITLEBARINFOEX", 831),
				new WM("HANDHELDFIRST", 856),
				new WM("HANDHELDLAST", 863),
				new WM("AFXFIRST", 864),
				new WM("AFXLAST", 895),
				new WM("PENWINFIRST", 896),
				new WM("PENWINLAST", 911),
				new WM("USER", 1024),
				new WM("CPL_LAUNCH", 5120),
				new WM("CPL_LAUNCHED", 5121),
				new WM("APP", 32768)
			};
		}

		public static List<GWL> AllGWLs()
		{
			return new List<GWL>
			{
				new GWL(true, "GWL_EXSTYLE","Sets a new extended window style.",-20, GWLExStyles()),
				new GWL(false, "GWL_HINSTANCE","Sets a new application instance handle.", -6),
				new GWL(false, "GWL_ID","Sets a new identifier of the child window. The window cannot be a top-level window.", -12),
				new GWL(true, "GWL_STYLE","Sets a new window style.", -16, GWLStyles()),
				new GWL(false, "GWL_USERDATA","Sets the user data associated with the window. This data is intended for use by the application that created the window. Its value is initially zero.",-21),
				new GWL(false, "GWL_WNDPROC","Sets a new address for the window procedure. You cannot change this attribute if the window does not belong to the same process as the calling thread.",-4),
				new GWL(false, "DWL_MSGRESULT","Sets the return value of a message processed in the dialog box procedure.",0)
			};
		}

		private static Dictionary<string, UInt32> GWLStyles() =>
			new Dictionary<string, UInt32>
			{
				{ "WS_BORDER", (UInt32)0x800000 },
				{ "WS_CAPTION", (UInt32)0xc00000 },
				{ "WS_CHILD", (UInt32)0x40000000 },
				{ "WS_CLIPCHILDREN", (UInt32)0x2000000 },
				{ "WS_CLIPSIBLINGS", (UInt32)0x4000000 },
				{ "WS_DISABLED", (UInt32)0x8000000 },
				{ "WS_DLGFRAME", (UInt32)0x400000 },
				{ "WS_GROUP", (UInt32)0x20000 },
				{ "WS_HSCROLL", (UInt32)0x100000 },
				{ "WS_MAXIMIZE", (UInt32)0x1000000 },
				{ "WS_MAXIMIZEBOX", (UInt32)0x10000 },
				{ "WS_MINIMIZE", (UInt32)0x20000000 },
				{ "WS_MINIMIZEBOX", (UInt32)0x20000 },
				{ "WS_OVERLAPPED", (UInt32)0x0 },
				{ "WS_OVERLAPPEDWINDOW", (UInt32)(0x0 | 0xc00000 | 0x80000 | 0x40000 | 0x20000 | 0x10000) },
				{ "WS_POPUP", (UInt32)0x80000000 },
				{ "WS_POPUPWINDOW", (UInt32)(0x80000000 | 0x800000 | 0x80000) },
				{ "WS_SIZEFRAME", (UInt32)0x40000 },
				{ "WS_SYSMENU", (UInt32)0x80000 },
				{ "WS_TABSTOP", (UInt32)0x10000 },
				{ "WS_VISIBLE", (UInt32)0x10000000 },
				{ "WS_VSCROLL", (UInt32)0x200000 }
			};

		private static Dictionary<string, UInt32> GWLExStyles() =>
			new Dictionary<string, UInt32>
			{
				{ "WS_EX_ACCEPTFILES", (UInt32)0x10},
				{ "WS_EX_APPWINDOW ", (UInt32)0x40000},
				{ "WS_EX_CLIENTEDGE", (UInt32)0x200},
				{ "WS_EX_COMPOSITED", (UInt32)0x2000000},
				{ "WS_EX_CONTEXTHELP", (UInt32)0x400},
				{ "WS_EX_CONTROLPARENT", (UInt32)0x10000},
				{ "WS_EX_DLGMODALFRAME", (UInt32)0x1},
				{ "WS_EX_LAYERED", (UInt32)0x80000},
				{ "WS_EX_LAYOUTRTL", (UInt32)0x400000},
				{ "WS_EX_LEFT", (UInt32)0x0},
				{ "WS_EX_LEFTSCROLLBAR", (UInt32)0x4000},
				{ "WS_EX_LTRREADING", (UInt32)0x0},
				{ "WS_EX_MDICHILD", (UInt32)0x40},
				{ "WS_EX_NOACTIVATE", (UInt32)0x8000000},
				{ "WS_EX_NOINHERITLAYOUT", (UInt32)0x100000},
				{ "WS_EX_NOPARENTNOTIFY", (UInt32)0x4},
				{ "WS_EX_OVERLAPPEDWINDOW", (UInt32)(0x100 | 0x200)},
				{ "WS_EX_PALETTEWINDOW", (UInt32)(0x100 | 0x80 | 0x8)},
				{ "WS_EX_RIGHT", (UInt32)0x1000},
				{ "WS_EX_RIGHTSCROLLBAR", (UInt32)0x0},
				{ "WS_EX_RTLREADING", (UInt32)0x2000},
				{ "WS_EX_STATICEDGE", (UInt32)0x20000},
				{ "WS_EX_TOOLWINDOW", (UInt32)0x80},
				{ "WS_EX_TOPMOST", (UInt32)0x8},
				{ "WS_EX_TRANSPARENT", (UInt32)0x20},
				{ "WS_EX_WINDOWEDGE", (UInt32)0x100}
			};
	}

	public class WM
	{
		public int ID;
		public string MessageName;
		public Dictionary<string, int> wParams;
		public Dictionary<string, IntPtr> lParams;

		public WM(string messageName, int id)
		{
			MessageName = messageName;
			ID = id;
			wParams = new Dictionary<string, int>();
			lParams = new Dictionary<string, IntPtr>();
		}
		public WM(string messageName, int id, Dictionary<string, int> w)
		{
			MessageName = messageName;
			ID = id;
			wParams = w;
			lParams = new Dictionary<string, IntPtr>();
		}

		public override string ToString() => MessageName;
	}

	public class GWL
	{
		public int ID;
		public string GWLName, Description;
		public Dictionary<string, UInt32> LongValues;
		public bool IsFlag;

		public GWL(bool isFlag, string gwlName, string description, int id)
		{
			IsFlag = isFlag;
			GWLName = gwlName;
			Description = description;
			ID = id;
			LongValues = new Dictionary<string, UInt32>();
		}

		public GWL(bool isFlag, string gwlName, string description, int id, Dictionary<string, UInt32> longValues)
		{
			IsFlag = isFlag;
			GWLName = gwlName;
			Description = description;
			ID = id;
			LongValues = longValues;
		}

		public override string ToString() => GWLName;
	}
}
