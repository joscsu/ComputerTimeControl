using System;
using System.Runtime.InteropServices;


namespace Worker
{

    public partial class InvisibleWindow 
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct CREATESTRUCT
        {
            public IntPtr lpCreateParams;
            public IntPtr hInstance;
            public IntPtr hMenu;
            public IntPtr hwndParent;
            public int cy;
            public int cx;
            public int y;
            public int x;
            public int style;
            public IntPtr lpszName;
            public IntPtr lpszClass;
            public int dwExStyle;
        }
    }
}
