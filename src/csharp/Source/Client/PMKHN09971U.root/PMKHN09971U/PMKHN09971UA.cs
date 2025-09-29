//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 開発ツール監視常駐
// プログラム概要   : 開発ツール監視常駐
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570189-00 作成担当 : 岸　傑
// 作 成 日  2020/01/24  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Windows.Forms;
using Microsoft.Win32;
using System.IO;

using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting;

using System.Security.Principal;
using System.Collections;
using System.ServiceProcess;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ツール常駐
    /// </summary>
    /// <remarks>
    /// <br>Note       : ツール常駐画面</br>
    /// <br>Programmer : BroadLeaf</br>
    /// <br>Date       : 2020/01/24</br>
    /// </remarks>
    public partial class PMKHN09971UA : Form
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region　コンスト Memebers
        /// <summary>プログラムID</summary>
        private const string AssemblyId = "PMKHN09971U";
        #endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region Private Members
        /// <summary>ツール</summary>
        private DevelopToolMonitoring DevMonitoring = null;
        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// <br>Note       : コンストラクタ</br>
        /// <br>Programmer : BroadLeaf</br>
        /// <br>Date       : 2020/01/24</br>
        /// </remarks>
        public PMKHN09971UA()
        {

            try
            {
                // 初期化処理
                InitializeComponent();

                // ツール初期化
                DevMonitoring = new DevelopToolMonitoring();
                DevMonitoring.WriteLog += new DevelopToolMonitoring.WriteLogHandler(PMKHN09971UA_WriteLog);
            }
            catch
            {
            }
        }
        #endregion

        // ===================================================================================== //
        // 画面操作処理
        // ===================================================================================== //
        #region Control Event Methods
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : フォームロードイベント</br>
        /// <br>Programmer : BroadLeaf</br>
        /// <br>Date       : 2020/01/24</br>
        /// </remarks>
        private void PMKHN09971UA_Load(object sender, EventArgs e)
        {
            this.notifyIcon1.Visible = false;
            this.Visible = false;

            try
            {
                // 重複起動チェック
                if (System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
                {
                    if (DevMonitoring != null)
                    {
                        DevMonitoring.Dispose();
                        DevMonitoring = null;
                    }
                    this.Close();
                    return;
                }

                // サーバ起動チェック
                if (System.Diagnostics.Process.GetProcessesByName("PMKHN09973U").Length > 0)
                {
                    if (DevMonitoring != null)
                    {
                        DevMonitoring.Dispose();
                        DevMonitoring = null;
                    }
                    this.Close();
                    return;
                }

                // オプションチェック
                PurchaseStatus ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_ToolMonitoring);
                if (ps != PurchaseStatus.Contract)
                {
                    if (DevMonitoring != null)
                    {
                        DevMonitoring.Dispose();
                        DevMonitoring = null;
                    }
                    this.Close();
                    return;
                }

                // 処理開始
                DevMonitoring.Start();

            }
            catch
            {

                if (DevMonitoring != null)
                {
                    DevMonitoring.Dispose();
                    DevMonitoring = null;
                }

                this.Close();
            }
        }

        // ===================================================================================== //
        // イベント処理
        // ===================================================================================== //
        /// <summary>
        /// ログ出力イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="message">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ログ出力イベント</br>
        /// <br>Programmer : BroadLeaf</br>
        /// <br>Date       : 2020/01/24</br>
        /// </remarks>
        private void PMKHN09971UA_WriteLog(object sender, string message)
        {
            try
            {
                // アクセスクラス
                TextOutPutOprtnHisLogAcs AcsObj = new TextOutPutOprtnHisLogAcs();

                // パラメータクラス
                TextOutPutOprtnHisLogWork WorkObj = new TextOutPutOprtnHisLogWork();
                WorkObj.LogDataObjAssemblyID = AssemblyId;          // アセンブリID
                WorkObj.LogDataObjAssemblyNm = AssemblyId;        // アセンブリ名
                WorkObj.LogDataObjProcNm = AssemblyId;            // 処理名
                WorkObj.LogDataObjBootProgramNm = AssemblyId;     // 起動プログラム名
                WorkObj.LogOperationData = message;                 // ログ出力メッセージ

                // エラーメッセージ受取用
                string resulMessage = string.Empty;

                // テキスト出力ログ部品呼出
                AcsObj.Write(this, ref WorkObj, out resulMessage);

            }
            catch
            {

            }
        }
        #endregion

        private void PMKHN09971UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if ( DevMonitoring != null)
                {
                    DevMonitoring.Dispose();
                    DevMonitoring = null;
                }
            }
            catch
            {
            }

        }
    }
}