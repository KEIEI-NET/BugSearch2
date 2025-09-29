//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : SCMデータ受信処理起動アクセスクラス
// プログラム概要   : SCMデータ受信処理起動リモートにアクセスする
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 10601193-00  作成担当 : 21024　佐々木 健
// 作 成 日  2010/05/20  修正内容 : 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 對馬 大輔
// 作 成 日  2010/07/30  修正内容 : クライアントアセンブリの受信処理を起動するように変更
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;

using System.Diagnostics; // 2010/07/30

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// SCMデータ受信処理起動アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 新規作成</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2010/05/20</br>
    /// <br>----------------------------------------------------------------------------</br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public class SCMDtRcveExecAcs
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructor
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新規作成</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2010/05/20</br>
        /// </remarks>
        public SCMDtRcveExecAcs()
        {
        }
        #endregion

        // ===================================================================================== //
        // 定数
        // ===================================================================================== //
        # region Const Members

        #region delegate
        //>>>2010/07/30
        /// <summary>
        /// 起動パラメータ取得デリゲート
        /// </summary>
        /// <param name="param"></param>
        public delegate void GetStartParameterEventHandler(out string param);
        //<<<2010/07/30
        #endregion

        #region Events
        //>>>2010/07/30
        public GetStartParameterEventHandler GetStartParameterEvent;
        //<<<2010/07/30
        #endregion

        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■ Private Member

        private ISCMDtRcveExecDB _iSCMDtRcveExecDB =null;

        #endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        # region ■ Public Method

        /// <summary>
        /// データ受信処理
        /// </summary>
        /// <param name="wait">True:受信処理の終了を待つ</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        public int DataReceive(bool wait, out string errMsg)
        {
            errMsg = string.Empty;

            //>>>2010/07/30
            //if (_iSCMDtRcveExecDB == null) _iSCMDtRcveExecDB = (ISCMDtRcveExecDB)MediationSCMDtRcveExecDB.GetSCMDtRcveExecDB();

            //int status = _iSCMDtRcveExecDB.ExecuteDataReceive(wait);

            int status = this.ExecuteDataReceive(wait);
            //<<<2010/07/30

            if (status != 0) errMsg = "受信でエラーが発生しました";

            return status;
        }

        //>>>2010/07/30
        /// <summary>
        /// データ受信処理を実行します
        /// </summary>
        /// <param name="wait"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : SCMデータ受信処理を実行します。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/05/19</br>
        /// </remarks>
        public int ExecuteDataReceive(bool wait)
        {
            return this.ExecuteDataReceiveProc(wait);
        }
        //<<<2010/07/30

        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■ Private Method

        //>>>2010/07/30
        /// <summary>
        /// データ受信処理を実行します
        /// </summary>
        /// <param name="wait"></param>
        /// <returns></returns>
        private int ExecuteDataReceiveProc(bool wait)
        {
            try
            {
                string dir = this.GetTargetDir();
                if (string.IsNullOrEmpty(dir) || !System.IO.Directory.Exists(dir))
                {
                    return -1;
                }

                string path = System.IO.Path.Combine(dir, "PMSCM01000U.exe");

                if (!System.IO.File.Exists(path)) return -2;

                string param;
                this.GetStartParameterDelegateCall(out param);

                if (!string.IsNullOrEmpty(param))
                {
                    Process pr = Process.Start(path, param);

                    if (wait) pr.WaitForExit();
                }
                else
                {
                    return -1;
                }

                return 0;
            }
            catch (Exception ex)
            {
                return -999;
            }
        }

        /// <summary>
        /// 対象ディレクトリのを取得します
        /// </summary>
        /// <returns>カレントディレクトリ</returns>
        private string GetTargetDir()
        {
            string dir = string.Empty;

            dir = System.IO.Directory.GetCurrentDirectory();

            return dir;
        }

        /// <summary>
        /// 起動パラメータ取得デリゲートコール
        /// </summary>
        /// <param name="param"></param>
        private void GetStartParameterDelegateCall(out string param)
        {
            param = string.Empty;
            if (this.GetStartParameterEvent != null)
            {
                this.GetStartParameterEvent(out param);
            }
        }
        //<<<2010/07/30

        #endregion

    }
}
