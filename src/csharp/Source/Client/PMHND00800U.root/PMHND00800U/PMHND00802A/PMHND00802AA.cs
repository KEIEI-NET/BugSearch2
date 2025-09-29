//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : HTプログラム導入処理
// プログラム概要   : HTプログラム導入処理 アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370104-00 作成担当 : 森山　浩
// 作 成 日  2017/12/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace Broadleaf.Windows.Forms
{
    using BTCOMM_HHT = System.Int32;

    /// <summary>
    /// HTプログラム導入処理アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : HTプログラム導入処理アクセスクラス</br>
    /// <br>Programmer : 森山浩</br>
    /// <br>Date       : 2017/12/22</br>
    /// </remarks>
    public class PMHND00802AA
    {

        // ===================================================================================== //
        // プライベート定数
        // ===================================================================================== //
        #region コンスト Memebers

        /// <summary>
        /// MAX_PATH
        /// </summary>
        private static int MAX_PATH = 260;

        #endregion

        // ===================================================================================== //
        // ログ出力メッセージ
        // ===================================================================================== //
        #region 出力メッセージ
        private static string LogMsgSrchTtErr = "ハンディターミナルの検索に失敗しました。（エラーコード：{0}）";

        private static string LogMsgNoHt = "ハンディターミナルが接続されていません。\n電源オフにして通信ユニットに接続し、「送信」ボタンを押してください。";

        private static string LogMsgSrchHtInfoErr = "ハンディターミナルの検索（情報取得）に失敗しました。";

        private static string LogMsgCreHtHandleErr = "ＨＴハンドル生成に失敗しました。";

        private static string LogMsgConHtErr = "ハンディターミナルとの接続に失敗しました。（エラーコード：{0}）";

        private static string LogMsgGetVerFileErr = "バージョンファイルの取得に失敗しました。（エラーコード：{0}）";

        private static string LogMsgDisconnectErr = "ハンディターミナルとの接続解除に失敗しました。（エラーコード：{0}）";

        private static string LogMsgCloseHtHandleErr = "ＨＴハンドルの開放に失敗しました。";

        private static string LogMsgSendFileErr = "ファイルの送信に失敗しました。（エラーコード：{0}）";

        private static string LogMsgSendInCompleteErr = "ファイルの送信に失敗しました。\nハンディターミナルのログイン画面を終了し、「送信」ボタンを押してください。";

        #endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region プライベート Members

        /// <summary>
        /// ロガー
        /// </summary>
        PMHND00804AE logger = null;

        #endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        #region プロパティ Members

        /// <summary>XML設定ファイル情報</summary>
        public PMHND00802AB settingInfo;

        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="settingInfo">設定ファイル情報</param>
        /// <remarks>
        /// <br>Note       : コンストラクタ</br>
        /// <br>Programmer : 森山　浩</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        public PMHND00802AA(PMHND00802AB settingInfo)
        {
            this.settingInfo = settingInfo;
            logger = PMHND00804AE.getInstance();
        }
        #endregion

        #region Public Method

        #region ファイル送信処理
        /// <summary>
        ///	ファイル送信処理
        /// </summary>
        /// <param name="sendPath">クライアント側の送信用ファイルのフォルダ名</param>
        /// <param name="remotePath">端末側のパス</param>
        /// <param name="fileNames">送信するファイル名のリスト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note	   : ファイルのハンディ端末への送信を行います。</br>
        /// <br>Programmer : 森山　浩</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        public unsafe BTCOMM_RESULT SendFile(string sendPath, string sendSettingPath, string[] remotePath, string[] fileNames, out string errMsg)
        {
            int ht_num;
            bool status;

            errMsg = string.Empty;

            // ハンディターミナル検索処理
            BTCOMM_RESULT result = SearchHT(out ht_num, out errMsg);
            if (result != BTCOMM_RESULT.BTCOMM_OK)
            {
                return result;
            }

            // 見つかった台数分だけ端末情報を取得し、ファイルを転送する
            for (int i = 0; i < ht_num; i++)
            {
                BTCOMM_HHT hHT = 0;

                // 検索にヒットした端末の端末情報を取得し、HTハンドルを作成し、接続する
                result = CreateHT(true, sendPath, ".\\", settingInfo.SendTimeoutVal, ref hHT, out errMsg);
                if (result == BTCOMM_RESULT.BTCOMM_OK)
                {
                    for (int ii = 0; ii < fileNames.Length; ii++)
                    {
                        string localfile = fileNames[ii];
                        string remotefile = remotePath[ii] + fileNames[ii];

                        // ファイル送信
                        result = btcommclass.btcommPutFile(hHT, localfile, remotefile, settingInfo.SendTimeoutVal);
                        if (result != BTCOMM_RESULT.BTCOMM_OK)
                        {
                            // ファイル送信に失敗したらエラーメッセージを出す
                            errMsg = String.Format(LogMsgSendFileErr, result);
                            if (result == BTCOMM_RESULT.BTCOMM_INCOMPLETE)
                            {
                                // ファイル送信に失敗したらエラーメッセージを出す
                                errMsg = String.Format(LogMsgSendInCompleteErr, result);
                            }
                            break;
                        }
                    }

                    // 接続を切断し、HTハンドルを解放する
                    status = CloseHT(hHT, settingInfo.SendTimeoutVal, ref errMsg);
                    if (!(status))
                    {
                        result = BTCOMM_RESULT.BTCOMM_OTHER;
                        break;
                    }
                }
            }

            return result;

        }
        #endregion

        #region ファイル受信処理
        /// <summary>
        ///	ファイル受信処理
        /// </summary>
        /// <param name="recvPath">受信フォルダ名</param>
        /// <param name="remotePath">端末側パス</param>
        /// <param name="fileNames">ファイル名リスト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note	   : ファイルのハンディ端末からの受信を行います。</br>
        /// <br>Programmer : 森山　浩</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        public unsafe BTCOMM_RESULT RecvFile(string recvPath, string[] remotePaths, string[] fileNames, out string errMsg)
        {
            int ht_num;

            string[] localfiles = fileNames;
            string[] remotefiles = new string[fileNames.Length];

            errMsg = string.Empty;

            for (int ii = 0; ii < fileNames.Length; ii++)
            {
                remotefiles[ii] = remotePaths[ii] + fileNames[ii];
            }
            
            // ハンディターミナル検索処理
            BTCOMM_RESULT result = SearchHT(out ht_num, out errMsg);
            if (result != BTCOMM_RESULT.BTCOMM_OK)
            {
                return result;
            }

            // 見つかった台数分だけ端末情報を取得し、ファイルを転送する
            for (int i = 0; i < ht_num; i++)
            {
                bool status = false;
                BTCOMM_HHT hHT = 0;

                // 検索にヒットした端末の端末情報を取得し、HTハンドルを作成し、接続する
                result = CreateHT(false, ".\\", recvPath, settingInfo.RecvTimeoutVal, ref hHT, out errMsg);
                if (result == BTCOMM_RESULT.BTCOMM_OK)
                {
                    for (int jj = 0; jj < fileNames.Length; jj++)
                    {
                        result = btcommclass.btcommGetFile(hHT, remotefiles[jj], localfiles[jj], settingInfo.RecvTimeoutVal);
                        if (result != BTCOMM_RESULT.BTCOMM_OK && result != BTCOMM_RESULT.BTCOMM_FILENOTFOUND)
                        {
                            // エラーでも次のファイル受信できるかもしれないので、処理続行
                            errMsg = string.Format(LogMsgGetVerFileErr, result);
                            break;
                        }
                    }

                    // 接続を切断し、HTハンドルを解放する
                    status = CloseHT(hHT, settingInfo.RecvTimeoutVal, ref errMsg);
                    if (!(status))
                    {
                        result = BTCOMM_RESULT.BTCOMM_OTHER;
                        break;
                    }
                }
            }

            return result;

        }
        #endregion

        #region ハンディ端末共通処理
        /// <summary>
        /// ハンディ端末検索処理
        /// </summary>
        /// <param name="_ht_num"></param>
        /// <param name="_errMsg"></param>
        /// <remarks>
        /// <br>Note	   : ポートからハンディ端末を検索する</br>
        /// <br>Programmer : 森山　浩</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private unsafe BTCOMM_RESULT SearchHT(out int _ht_num, out string _errMsg)
        {
            int ht_num;
            _ht_num = 0;
            _errMsg = string.Empty;

            // COMポートから端末を検索する。
            // (USBポートから端末を検索するときはBTCOMM_CRADLE_USBALL、
            //  LAN置き台から端末を検索するときはBTCOMM_CRADLE_LANALL(「_IPADRS.TXT」が必要)、
            //  無線端末から検索するときはBTCOMM_TERM_WLANALLを論理和で設定する)
            BTCOMM_RESULT result = btcommclass.btcommSearchHT(IntPtr.Zero, 0, btcommclass.BTCOMM_CRADLE_USBALL, &ht_num);
            if (result == BTCOMM_RESULT.BTCOMM_OK)
            {
                if (ht_num == 0)
                {
                    _errMsg = LogMsgNoHt;
                    result = BTCOMM_RESULT.BTCOMM_OTHER;
                }
                _ht_num = ht_num;
            }
            else
            {
                _errMsg = string.Format(LogMsgSrchTtErr, result);
            }

            return result;
        }

        /// <summary>
        /// ハンディ端末接続処理
        /// </summary>
        /// <param name="dispFlg">1：受信、2：送信</param>
        /// <param name="sendPath"></param>
        /// <param name="recvPath"></param>
        /// <param name="timeoutVal"></param>
        /// <param name="hHT"></param>
        /// <remarks>
        /// <br>Note	   : 検索したハンディ端末を接続する</br>
        /// <br>Programmer : 森山　浩</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private BTCOMM_RESULT CreateHT(bool dispFlg, string sendPath, string recvPath, int timeoutVal, ref BTCOMM_HHT hHT, out string errMsg)
        {
            errMsg = string.Empty;
            bool status;
            BTCOMM_RESULT result;
            BTCOMM_HTInfo info;

            // 検索にヒットした端末の端末情報を取得し、HTハンドルを作成し、接続する
            status = btcommclass.btcommGetHTNext(out info);
            if (!status)
            {
                errMsg = LogMsgSrchHtInfoErr;
                return BTCOMM_RESULT.BTCOMM_OTHER;
            }

            BTCOMM_Param param = new BTCOMM_Param();
            param.hWnd = IntPtr.Zero;	// イベント配信先は同期型なのでNULL
            param.dwMsgID = 0;	        // イベントIDは同期型なのでNULL
            param.strSendPath = StringToCharArray(sendPath, MAX_PATH);	// ファイル送信時のカレントフォルダはカレントフォルダ
            param.strRecvPath = StringToCharArray(recvPath, MAX_PATH);	// ファイル受信時のカレントフォルダはカレントフォルダ
            param.bDispDialog = dispFlg;    // 通信中のダイアログを表示する
            param.bSetTime = true;	        // 端末の時刻をPCに合わせる

            hHT = btcommclass.btcommCreateHTHandle(ref info, ref param);
            if (hHT == 0)
            {
                errMsg = LogMsgCreHtHandleErr;
                return BTCOMM_RESULT.BTCOMM_OTHER;
            }

            result = btcommclass.btcommConnect(hHT, timeoutVal);
            if (!result.Equals(BTCOMM_RESULT.BTCOMM_OK))
            {
                // 接続状態に無かったらエラーメッセージを出す
                errMsg = String.Format(LogMsgConHtErr, result);

                return BTCOMM_RESULT.BTCOMM_OTHER;
            }

            return BTCOMM_RESULT.BTCOMM_OK;
        }

        /// <summary>
        /// ハンディ端末接続切断/解放処理
        /// </summary>
        /// <param name="hHT"></param>
        /// <param name="timeoutVal"></param>
        /// <remarks>
        /// <br>Note	   : ハンディ端末から接続を切断し、HTハンドルを解放する</br>
        /// <br>Programmer : 森山　浩</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private bool CloseHT(BTCOMM_HHT hHT, int timeoutVal, ref string errMsg)
        {
            bool status = false;

            // 接続を切断し、HTハンドルを解放する
            BTCOMM_RESULT result = btcommclass.btcommDisconnect(hHT, timeoutVal);
            if (result != BTCOMM_RESULT.BTCOMM_OK)
            {
                if (errMsg != string.Empty) errMsg += "\n";
                errMsg += string.Format(LogMsgDisconnectErr, result);
            }

            status = btcommclass.btcommCloseHTHandle(hHT);
            if (!status)
            {
                if (errMsg != string.Empty) errMsg += "\n";
                errMsg += LogMsgCloseHtHandleErr;
            }

            if (result != BTCOMM_RESULT.BTCOMM_OK)
            {
                status = false;
            }

            return status;
        }

        #endregion

        #region 文字列→char配列変換処理
        /// <summary>
        ///	文字列→char配列変換処理
        /// </summary>
        /// <param name="str">変換前文字列</param>
        /// <param name="size">変換後配列のサイズ</param>
        /// <returns>変換後のchar配列</returns>
        /// <remarks>
        /// <br>Note	   : 文字列をcharの配列に変換する処理を行います。</br>
        /// <br>Programmer : 森山　浩</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private char[] StringToCharArray(string str, int size)
        {
            char[] dstCharArray = new char[size];
            char[] srcCharArray = str.ToCharArray();
            for (int ii = 0; ii < size; ii++)
            {
                char cc = (Char)0x00;
                if (ii < srcCharArray.Length)
                {
                    cc = srcCharArray[ii];
                }
                dstCharArray[ii] = cc;
            }
            return dstCharArray;
        }
        #endregion

        #endregion
    
    }
}
