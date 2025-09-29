/// <summary>
/// デジタルデータ検索　共有フォルダ接続処理
/// </summary>
/// <remarks>
/// <br>Programmer : moriyama</br>
/// <br>Date       : 2017.10.16</br>
/// <br>Note       : /br>
/// </remarks>
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;

namespace Broadleaf.Web
{
    /// <summary>
    /// PMTABサムネイル画像取得　共有フォルダ接続クラス
    /// </summary>
    /// <remarks>
    /// <br>Programmer  : moriyama</br>
    /// <br>Date        : 2017.10.16</br>
    /// <br>Note        : PMTABサムネイル画像取得共有フォルダ接続処理を制御します。</br>
    /// </remarks>
    public class PMTAB04061AD : IDisposable
    {
        #region << Private Const >>

        #endregion

        #region << Private Member >>

        //接続切断するWin32 API を宣言
        [DllImport("mpr.dll", EntryPoint = "WNetCancelConnection2", CharSet =
              System.Runtime.InteropServices.CharSet.Unicode)]
        private static extern int WNetCancelConnection2(string lpName, Int32 dwFlags, bool fForce);

        [DllImport("mpr.dll", EntryPoint = "WNetAddConnection2", CharSet =
              System.Runtime.InteropServices.CharSet.Unicode)]

        private static extern int WNetAddConnection2(
            ref NETRESOURCE lpNetResource, string lpPassword, string lpUsername, Int32 dwFlags);

        [StructLayout(LayoutKind.Sequential)]
        internal struct NETRESOURCE
        {
            public int dwScope;
            public int dwType;
            public int dwDisplayType;
            public int dwUsage;

            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpLocalName;

            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpRemoteName;

            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpComment;

            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpProvider;

        }

        ///<summary>接続先パス（IPアドレス/ホスト名）</summary>
        private string connectPath = "";
        ///<summary>ユーザID</summary>
        private string usrId = "";
        ///<summary>パスワード</summary>
        private string passWord = "";
        ///<summary>接続の有無</summary>
        private bool isConnect = false;
        ///<summary>ロガー</summary>
        private PMTAB04061AC logger = PMTAB04061AC.getInstance();

        #endregion

        #region << Public Method >>

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="connectPath">接続先パス（IPアドレス/ホスト名）</param>
        /// <param name="usrName">ユーザID</param>
        /// <param name="passWord">パスワード</param>
        /// <remarks>
        /// <br>Note        : PMTABサムネイル画像取得　共有フォルダ接続クラスのコンストラクタ</br>
        /// <br>Programmer	: moriyama</br>
        /// <br>Date        : 2017.10.16</br>
        ///</remarks>
        public PMTAB04061AD(string connectPath, string usrName, string passWord)
        {
            this.connectPath = connectPath;
            this.usrId = usrName;
            this.passWord = passWord;
        }

        /// <summary>
        /// 共有フォルダへの接続
        /// </summary>
        /// <param name="mode">ログ出力モード</param>
        /// <returns>正常終了：0、異常終了：-1</returns>
        /// <remarks>
        /// <br>Note        : 共有フォルダへの接続処理を行います</br>
        /// <br>Programmer	: moriyama</br>
        /// <br>Date        : 2017.10.16</br>
        ///</remarks>
        public int Connect()
        {
            // >NETのリソースを初期化
            NETRESOURCE netResource = new NETRESOURCE();
            netResource.dwScope = 0;
            netResource.dwType = 1;
            netResource.dwDisplayType = 0;
            netResource.dwUsage = 0;
            netResource.lpLocalName = "";
            netResource.lpRemoteName = connectPath;
            netResource.lpProvider = "";

            int ret = 0;
            try
            {
                // .NETの共有フォルダ接続処理を呼出し
                ret = WNetAddConnection2(ref netResource, passWord, usrId, 0);
            }
            catch (Exception exp)
            {
                logger.WriteLog("接続エラー " + exp.Message);
                return -1;
            }

            isConnect = true;
            return ret;
        }

        /// <summary>
        /// 共有フォルダの切断
        /// </summary>
        /// <returns>正常終了：0、異常終了：-1</returns>
        /// <remarks>
        /// <br>Note        : 共有フォルダへの切断処理を行います</br>
        /// <br>Programmer	: moriyama</br>
        /// <br>Date        : 2017.10.16</br>
        ///</remarks>
        public int DisConnect()
        {
            // 接続状態の場合、切断を行う
            if (isConnect)
            {
                // .NETの共有フォルダ切断処理を呼出し
                return WNetCancelConnection2(connectPath, 0, false);
            }
            else 
            {
                return 0;
            }
        }

        /// <summary>
        /// 共有フォルダ接続の破棄
        /// </summary>
        /// <returns>正常終了：0、異常終了：-1</returns>
        /// <remarks>
        /// <br>Note        : 共有フォルダへの接続の破棄を行います</br>
        /// <br>Programmer	: moriyama</br>
        /// <br>Date        : 2017.10.16</br>
        ///</remarks>
        public void Dispose()
        {
            try
            {
                // 接続状態の場合、切断を行う
                if (isConnect)
                {
                    // .NETの共有フォルダ切断処理を呼出し
                    WNetCancelConnection2(connectPath, 0, false);
                }
            }
            catch (Exception exp)
            {
                string msg = exp.Message;
            }
        }
        #endregion

        #region << Private Method >>

        #endregion

    }
}