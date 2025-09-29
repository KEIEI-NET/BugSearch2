//****************************************************************************//
// システム         : LSMログチェックツール
// プログラム名称   : LSMログチェックツール
// プログラム概要   : LSMログチェックツール
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮本 利明
// 作 成 日  2015/09/24  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 作 成 日  2015/10/08  修正内容 : 改行処理追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮本 利明
// 作 成 日  2015/11/18  修正内容 : ①取得するインストールパスをクライアントに変更
//                                  ②例外発生時のログの出力先を変更
//                                  ③エラー発生時のログ出力を削除
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮本 利明
// 作 成 日  2015/11/24  修正内容 : ログ出力先パスを実行パス下に変更
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Collections;
using Microsoft.Win32;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    public partial class PMCMN00084UA : Form
    {
        /// <summary>自動モード</summary>
        private bool autoMode = false;

        /// <summary>標準配信フォルダバス</summary>
        private string installDirectory = "";


        #region Private Event
        /// <summary>
        /// 起動
        /// </summary>
        public PMCMN00084UA(bool autoMode)
        {
            InitializeComponent();

            this.autoMode = autoMode;

            //PMNSのインストールパスの取得(USER_AP)
            this.installDirectory = GetInstallDirectory();
        }

        /// <summary>
        /// FormLoad
        /// </summary>
        private void PMCMN00084UA_Load(object sender, EventArgs e)
        {
            if (this.autoMode)
            {
                //自動モード
                CallLsmCheck(); // LSMチェック呼出
                Close();
            }
        }

        /// <summary>
        /// 終了ボタン押下
        /// </summary>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// チェック開始ボタン押下
        /// </summary>
        private void btn_Start_Click(object sender, EventArgs e)
        {
            LsmLogLst.Items.Clear();
            CallLsmCheck(); // LSMチェック呼出
        }
        #endregion


        #region Private Method
        /// <summary>
        /// インストールパスの取得
        /// </summary>
        private string GetInstallDirectory()
        {
            // --- UPD 2015/11/18 T.Miyamoto ① ------------------------------>>>>>
            ////サーバー
            //string keyPath = @String.Format(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

            //RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath);
            //string directoryPath = "";
            //if (key.GetValue("InstallDirectory") != null)
            //{
            //    directoryPath = (string)key.GetValue("InstallDirectory");
            //}
            //key.Close();

            //return directoryPath;
            try
            {
                // --- UPD 2015/11/24 T.Miyamoto ------------------------------>>>>>
                ////クライアント
                //string keyPath = @String.Format(@"SOFTWARE\Broadleaf\Product\Partsman");
                //RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath);
                //string directoryPath = "";
                //if (key.GetValue("InstallDirectory") != null)
                //{
                //    directoryPath = (string)key.GetValue("InstallDirectory");
                //}
                //key.Close();
                //return directoryPath;
                return System.Windows.Forms.Application.StartupPath;
                // --- UPD 2015/11/24 T.Miyamoto ------------------------------<<<<<
            }
            catch (Exception ex)
            {
                return "";
            }
            // --- UPD 2015/11/18 T.Miyamoto ① ------------------------------<<<<<
        }

        /// <summary>
        /// LSMチェック呼出
        /// </summary>
        private void CallLsmCheck()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR; //ctDB_ERROR(1000)
            ArrayList list = new ArrayList();
            try
            {
                object objLsmCheckList = null;

                // LSMチェック呼出
                LsmHistoryLog lsmHistoryLog = new LsmHistoryLog();
                //--- ADD 2015/10/08 20073 T.Nishi ----->>>>>
                Boolean LsmWriteFlg = true;  //true:ログを書き込む  false:ログを書き込まない
                if (autoMode)
                {
                    LsmWriteFlg = false;
                }
                //--- ADD 2015/10/08 20073 T.Nishi -----<<<<<
                status = lsmHistoryLog.WriteLsmLog(out objLsmCheckList, LsmWriteFlg);

                // 結果表示
                string sMsg = string.Empty;
                //LogTextOut logTextOut = new LogTextOut(); // DEL 2015/11/18 T.Miyamoto ②
                foreach (LsmHisLogWork lsmHisLogWork in (ArrayList)objLsmCheckList)
                {
                    sMsg = lsmHisLogWork.LogDataMassage;
                    if (status.Equals((int)ConstantManagement.MethodResult.ctFNC_NORMAL))
                    {
                        sMsg = "問題ありません。";
                    }
                    else if (status.Equals((int)ConstantManagement.MethodResult.ctFNC_WARNING))
                    {
                        //メソッドの戻り値が警告の場合は、正常値として扱う
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                    else
                    {
                        sMsg = "【アプリケーションサーバー】" + "\r\n"
                                    + "LSMサービスでエラーが発生しています。"
                                    + "\r\n"
                                    + "\r\n"
                                    + sMsg;
                    }
                    if (autoMode)
                    {
                        list.Add(lsmHisLogWork);
                        if (lsmHisLogWork.LogDataOperationCd >= 1)
                        {
                            // --- DEL 2015/11/18 T.Miyamoto ③ ------------------------------>>>>>
                            //ログ出力
                            //logTextOut.Output("PMCMN00084U", sMsg, status);
                            // --- DEL 2015/11/18 T.Miyamoto ③ ------------------------------<<<<<
                            // LSMログデータ登録
                            lsmHistoryLog.Write(ref list);
                            if (lsmHisLogWork.LogDataOperationCd >= 2)
                            {
                                //メッセージ表示
                                DialogResult dResult = TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                sMsg,
                                0,
                                MessageBoxButtons.OK,
                                MessageBoxDefaultButton.Button1);
                            }
                        }
                    }
                    else
                    {
                        //改行コードが含まれる場合、改行
                        //始めの位置を探す
                        int foundIndex = sMsg.IndexOf("\r\n");
                        while (0 <= foundIndex)
                        {
                            string sMsg1 = sMsg.Substring(0, foundIndex);
                            LsmLogLst.Items.Add(sMsg1);
                            sMsg = sMsg.Substring(foundIndex + 2);
                            foundIndex = sMsg.IndexOf("\r\n");
                        }
                        LsmLogLst.Items.Add(sMsg);
                    }
                }
            }
            catch (Exception ex)
            {
                // --- UPD 2015/11/18 T.Miyamoto ② ------------------------------>>>>>
                //LogTextOut logTextOut = new LogTextOut();
                //logTextOut.Output("PMCMN00084U", ex.Message, 0);
                this.LogOutPut(ex.Message);
                // --- UPD 2015/11/18 T.Miyamoto ② ------------------------------<<<<<
            }
            finally
            {
                if (!autoMode)
                {
                    lblStatue.Text = (status == 0) ? "正常" : "異常";
                    lblStatue.ForeColor = (status == 0) ? Color.Black : Color.Red;
                }
            }
        }

        // --- ADD 2015/11/18 T.Miyamoto ② ------------------------------>>>>>
        /// <summary>
        /// ログ出力処理
        /// </summary>
        private void LogOutPut(string sMsg)
        {
            if (this.installDirectory != "")
            {
                StreamWriter writer = null; // テキストログ用

                //出力先  ：[クライアントのインストールパス]\Log\PMCMN00084U\PMCMN00084U_YYYYMMDD.Log
                //出力形式："YYYY/MM/DD hh:mm:ss    エラーメッセージ"
                Directory.CreateDirectory(@"" + this.installDirectory + @"\Log\PMCMN00084U");
                writer = new StreamWriter(@"" + this.installDirectory + @"\Log\PMCMN00084U\" + string.Format("PMCMN00084U_{0}.Log", DateTime.Now.ToString("yyyyMMdd")), true, System.Text.Encoding.GetEncoding("shift-jis"));

                writer.Write(DateTime.Now + "    " + sMsg + "\r\n");
                writer.Flush();
                if (writer != null) writer.Close();
            }
        }
        // --- ADD 2015/11/18 T.Miyamoto ② ------------------------------<<<<<
        #endregion


    }
}