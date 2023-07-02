using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.InteropServices;  // 
using Unity.VisualScripting;

namespace MarimoDesktopMascot
{
    namespace UI
    {
        namespace Window
        {

            public class TransparentWindow
            {
#if UNITY_STANDALONE_WIN
                [DllImport("user32.dll")]
                private static extern int GetActiveWindow();
                [DllImport("user32.dll")]
                private static extern int SetWindowLongA(int hWnd, int nIndex, int dwNewLong);

                [DllImport("user32.dll")]
                private static extern bool SetLayeredWindowAttributes(int hWnd, uint crKey, byte bAlpha, uint dwFlags);

                public static void DoTransparentWindow()
                {
                    int windowHandle = GetActiveWindow();
                    const int GWL_EXSTYLE = -20;
                    const int WS_EX_LAYERED = 0x00080000;
                    SetWindowLongA(windowHandle, GWL_EXSTYLE, WS_EX_LAYERED);

                    const uint TRANSPARENT_COLOR = 0x00090909;
                    const uint LWA_COLORKEY = 0x00000001;
                    SetLayeredWindowAttributes(windowHandle, TRANSPARENT_COLOR, 0, LWA_COLORKEY);
                }
#elif UNITY_STANDALONE_OSX
                public static void DoTransparentWindow()
                {
                }
#else
                public static void DoTransparentWindow()
                {
                    Debug.Log("DoTransparentWindow() is not implemented on this platform.");
                }
#endif
            }

        }
    }
}
