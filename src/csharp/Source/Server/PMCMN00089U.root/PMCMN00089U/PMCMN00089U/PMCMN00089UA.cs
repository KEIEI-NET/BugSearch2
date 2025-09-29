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
// 管理番号              作成担当 : 西 毅
// 作 成 日  2016/10/20  修正内容 : ローカルに出力されているログを削除
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

namespace Broadleaf.Windows.Forms
{
    public partial class PMCMN00089UA : Form
    {
        /// <summary>自動モード</summary>
        private bool autoMode = false;

        /// <summary>標準配信フォルダバス</summary>
        private string installDirectory = "";


        #region Private Event
        /// <summary>
        /// 起動
        /// </summary>
        public PMCMN00089UA(bool autoMode)
        {
            InitializeComponent();

            this.autoMode = autoMode;

            //PMNSのインストールパスの取得(USER_AP)
            this.installDirectory = GetInstallDirectory();
        }

        /// <summary>
        /// FormLoad
        /// </summary>
        private void PMCMN00089UA_Load(object sender, EventArgs e)
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
            //サーバー
            string keyPath = @String.Format(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

            RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath);
            string directoryPath = "";
            if (key.GetValue("InstallDirectory") != null)
            {
                directoryPath = (string)key.GetValue("InstallDirectory");
            }
            key.Close();

            return directoryPath;
        }

        /// <summary>
        /// LSMチェック呼出
        /// </summary>
        private void CallLsmCheck()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR; //ctDB_ERROR(1000)
            try
            {
                object objLsmCheckList = null;

                // LSMチェック呼出
                LsmHistoryLog lsmHistoryLog = new LsmHistoryLog();
                //--- ADD 2015/10/08 20073 T.Nishi ----->>>>>
                Boolean LsmWriteFlg = true;  //true:ログを書き込む  false:ログを書き込まない
                status = lsmHistoryLog.WriteLsmLog(out objLsmCheckList, LsmWriteFlg);
                //--- ADD 2015/10/08 20073 T.Nishi -----<<<<<

                // 結果表示
                string sMsg = string.Empty;
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
                                    + "サーバー環境の「LSMService_Log.txt」の内容を確認して下さい。"
                                    + "\r\n"
                                    + "\r\n"
                                    + sMsg;
                    }
                    if (autoMode)
                    {
                        //--- DEL 2016/10/20 T.Nishi ----->>>>>
                        //LogTextOut logTextOut = new LogTextOut();
                        //logTextOut.Output("PMCMN00089U", sMsg, status);
                        //--- DEL 2016/10/20 T.Nishi -----<<<<<
                    }
                    else
                    {
                        //--- ADD 2015/10/08 20073 T.Nishi ----->>>>>
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
                        //--- ADD 2015/10/08 20073 T.Nishi -----<<<<<
                        LsmLogLst.Items.Add(sMsg);
                    }

                }
            }
            catch (Exception ex)
            {
                //--- DEL 2016/10/20 T.Nishi ----->>>>>
                //LogTextOut logTextOut = new LogTextOut();
                //logTextOut.Output("PMCMN00089U", ex.Message, 0);
                //--- DEL 2016/10/20 T.Nishi -----<<<<<
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
        #endregion
    }
}