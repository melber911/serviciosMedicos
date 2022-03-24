using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Bus.Utilities
{
    public class Forms
    {
        private const int WM_SYSCOMMAND = 0x112;
        private const int MOUSE_MOVE = 0xF012;

        // Constantes para SetWindowsPos y Valores de wFlags
        const int SWP_NOSIZE = 0x1;
        const int SWP_NOMOVE = 0x2;
        const int SWP_NOACTIVATE = 0x10;
        const int wFlags = SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE;
        // Valores de hwndInsertAfter
        const int HWND_TOPMOST = -1;
        const int HWND_NOTOPMOST = -2;

        /// <summary>
        /// Mantener la ventana siempre visible
        /// </summary>
        /// <remarks>No utilizamos el valor devuelto</remarks>
        //[DllImport("user32.DLL")]
        static void SetWindowPos(int hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, int wFlags)
        {
        }

        /// <summary>
        ///     ''' Mantener la ventana siempre encima de todos los formularios.
        ///     ''' </summary>
        ///     ''' <param name="handle"></param>
        public static void FormAlwaysVisible(int handle)
        {
            SetWindowPos(handle, HWND_TOPMOST, 0, 0, 0, 0, wFlags);
        }

        /// <summary>
        ///     ''' Mantiene la ventana por encima del formulario pero no siempre
        ///     ''' </summary>
        ///     ''' <param name="handle"></param>
        public static void FormNotAlwaysVisible(int handle)
        {
            SetWindowPos(handle, HWND_NOTOPMOST, 0, 0, 0, 0, wFlags);
        }
    }
}
