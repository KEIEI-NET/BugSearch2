using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.InteropServices;

namespace Broadleaf.NSNetworkTest.Net
{
    /// <summary>
    /// WinHttpÇÃAPIèàóùÉNÉâÉX
    /// </summary>
    public class WinHttpAPI
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct WINHTTP_PROXY_INFO
        {
            [MarshalAs(UnmanagedType.U4)]
            public int dwAccessType;
            public string lpszProxy;
            public string lpszProxyBypass;
        }

        /// <summary>
        /// WinHttp
        /// </summary>
        /// <param name="pProxyInfo"></param>
        /// <returns></returns>
        [DllImport("winhttp.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern bool WinHttpGetDefaultProxyConfiguration(ref WINHTTP_PROXY_INFO pProxyInfo);

    }
}
