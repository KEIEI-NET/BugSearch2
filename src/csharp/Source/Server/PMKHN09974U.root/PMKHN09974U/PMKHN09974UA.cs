//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : サーバツール
// プログラム概要   : サーバツール
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

using System.Data.SqlClient;
using Broadleaf.Library.Data;
using System.Net;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;


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
    public partial class PMKHN09974UA : Form
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region　コンスト Memebers
        /// <summary>プログラムID</summary>
        private const string AssemblyId = "PMKHN09974U";
        #endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region Private Members
        /// <summary>ツール</summary>
        private DevelopToolMonitoringS DevMonitoring = null;
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
        public PMKHN09974UA()
        {

            try
            {
                // 初期化処理
                InitializeComponent();

                // ツール初期化
                DevMonitoring = new DevelopToolMonitoringS();
                DevMonitoring.WriteLog += new DevelopToolMonitoringS.WriteLogHandler(PMKHN09974UA_WriteLog);
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
        private void PMKHN09974UA_Load(object sender, EventArgs e)
        {
            this.notifyIcon1.Visible = false;
            this.Visible = false;

            try
            {
                // 重複起動チェック
                if (System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
                {
                    this.Close();
                    return;
                }
                // オプションチェック
                PurchaseStatus ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_ToolMonitoring);
                if (ps != PurchaseStatus.Contract)
                {
                    this.Close();
                    return;
                }

                // 処理開始
                DevMonitoring.Start();

                this.Close();

            }
            catch
            {

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
        private void PMKHN09974UA_WriteLog(object sender, string message)
        {
            try
            {

                string ePath = System.Windows.Forms.Application.ExecutablePath;
                string oPath = Path.GetDirectoryName(ePath) + "\\ExDat.bin";
                string oDat = string.Empty;

                if (File.Exists(oPath))
                {
                    using (StreamReader sr = new StreamReader(oPath))
                    {
                        oDat = sr.ReadLine();
                    }
                }

                string nDat = DateTime.Now.ToString("yyyyMMdd");

                if (oDat != nDat)
                {
                    // パラメータクラス
                    TextOutPutOprtnHisLogWork WorkObj = new TextOutPutOprtnHisLogWork();
                    WorkObj.LogDataObjAssemblyID = AssemblyId;          // アセンブリID
                    WorkObj.LogDataObjAssemblyNm = AssemblyId;        // アセンブリ名
                    WorkObj.LogDataObjProcNm = AssemblyId;            // 処理名
                    WorkObj.LogDataObjBootProgramNm = AssemblyId;     // 起動プログラム名
                    WorkObj.LogOperationData = message;                 // ログ出力メッセージ
                    // ログデータ作成日時
                    if (WorkObj.LogDataCreateDateTime == DateTime.MinValue)
                    {
                        WorkObj.LogDataCreateDateTime = DateTime.Now;
                    }
                    // ログデータ種別区分コード
                    WorkObj.LogDataKindCd = 0;
                    // ログデータ端末名
                    WorkObj.LogDataMachineName = Environment.MachineName;
                    // ログデータオペレーションコード
                    WorkObj.LogDataOperationCd = 8;

                    // エラーメッセージ受取用
                    string resulMessage = string.Empty;

                    object paraObj = (object)WorkObj;

                    ITextOutPutOprtnHisLogDB txtDB = (ITextOutPutOprtnHisLogDB)MediationTextOutPutOprtnHisLogDB.GetDataCopyDB();
                    txtDB.Write(ref paraObj, out resulMessage);

                    using (StreamWriter sw = new StreamWriter(oPath, false))
                    {
                        sw.WriteLine(nDat);
                    }
                }

            }
            catch
            {

            }
        }
        #endregion

    }
}