using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
using UBAU.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;

using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;


namespace Broadleaf.Windows.Forms
{
    public partial class PMUOE00004U : Form
    {
        #region プライベートメンバ
        private const string SETCOM1 = "COM1";
        private const string SETCOM2 = "COM2";
        private const string SETCOM3 = "COM3";
        private const int SETCOM1_VALUE = 0;
        private const int SETCOM2_VALUE = 1;
        private const int SETCOM3_VALUE = 2;

        private PMUOE00004U _customerSearchForm;
        #endregion

        public PMUOE00004U()
        {
            InitializeComponent();

            this.ultraComboEditor1.Items.Clear();
            this.ultraComboEditor1.Items.Add(SETCOM1_VALUE, SETCOM1);
            this.ultraComboEditor1.Items.Add(SETCOM2_VALUE, SETCOM2);
            this.ultraComboEditor1.Items.Add(SETCOM3_VALUE, SETCOM3);
            this.ultraComboEditor1.MaxDropDownItems = this.ultraComboEditor1.Items.Count;
            this.ultraComboEditor1.SelectedIndex = 0;

            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.Ok_Button.ImageList = imageList24;                     // 保存ボタン
            this.Cancel_Button.ImageList = imageList24;                 // 閉じるボタン
            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;        // 保存ボタン
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;   // 閉じるボタン
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            int status = -1;

            string comPort = "";
            string paraKey = "";

            //インストールパス読み込み
            status = GetRegistryValue(out paraKey);

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();

            //ComSpecのパスを取得する
            psi.FileName = System.Environment.GetEnvironmentVariable("ComSpec");

            if (status == -1)
            {
                TMsgDisp.Show(
                              this,
                              emErrorLevel.ERR_LEVEL_EXCLAMATION,
                              this.Name,
                              "インストール情報の取得に失敗しました。\n正しくインストールが行われているかどうか確認してください",
                              -1,
                              MessageBoxButtons.OK);
                return;
            }

            //出力を読み取れるようにする
            psi.RedirectStandardInput = false;
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            //ウィンドウを表示しないようにする
            psi.CreateNoWindow = true;
            psi.WorkingDirectory = paraKey;
            //コマンドラインを指定（"/c"は実行後閉じるために必要）
            psi.Arguments = @"/c chktcom.exe " + this.ultraComboEditor1.SelectedItem;

            //起動
            System.Diagnostics.Process p = System.Diagnostics.Process.Start(psi);

            //出力を読み取る
            string results = p.StandardOutput.ReadToEnd();
            //WaitForExitはReadToEndの後である必要がある
            //(親プロセス、子プロセスでブロック防止のため)
            p.WaitForExit();

            if (results.Contains("TCOM56KFHA")/*TCOM56K*/)
            {
                comPort = "TRANS_BC.PRG";
            }
            else if (results.Contains("TCOM336FHA(C)")/*TCOM336C*/)
            {
                comPort = "TRANS_BC.PRG";
            }
            else if (results.Contains("TCOM336FHA")/*TCOM336*/)
            {
                comPort = "TRANS_B.PRG";
            }
            else if(results.Contains("No way to identify this device"))
            {
                TMsgDisp.Show(
                              this,
                              emErrorLevel.ERR_LEVEL_EXCLAMATION,
                              this.Name,
                              "選択したCOMポートが存在しません。",
                              -1,
                              MessageBoxButtons.OK);
                this.Enabled = true;
                return;
            }
            else if(results.Contains("Fail to open"))
            {
                TMsgDisp.Show(
                              this,
                              emErrorLevel.ERR_LEVEL_EXCLAMATION,
                              this.Name,
                              "COMポートの接続に失敗しました。",
                              -1,
                              MessageBoxButtons.OK);
                this.Enabled = true;
                return;
            }
            else
            {
                TMsgDisp.Show(
                              this,
                              emErrorLevel.ERR_LEVEL_EXCLAMATION,
                              this.Name,
                              "このモデムは使用できません。",
                              -1,
                              MessageBoxButtons.OK);
                this.Enabled = true;
                return;
            }

            psi.Arguments = @"/c LOADTCOM.EXE "+ this.ultraComboEditor1.SelectedItem + " " + comPort;

            //起動
            System.Diagnostics.Process q = System.Diagnostics.Process.Start(psi);
            //出力を読み取る
            string qresults = q.StandardOutput.ReadToEnd();
            //WaitForExitはReadToEndの後である必要がある
            //(親プロセス、子プロセスでブロック防止のため)
            q.WaitForExit();
            this.Enabled = true;
        }

        /// <summary>
        /// レジストリ情報取得
        /// </summary>
        /// <param name="paraKey">レジストリKEY</param>
        /// <returns>レジストリ値</returns>
        private int GetRegistryValue(out string paraKey)
        {
            int status = -1;
            paraKey = string.Empty;
            /*  対象となる製品の情報を代入します。
             *  MenuアプリなどはApplicationTypeでClientを選択
             */
            RegistryTargetProductInfo registryTargetProductInfo = new RegistryTargetProductInfo();
            registryTargetProductInfo.ProductCode = LoginInfoAcquisition.ProductCode;

            registryTargetProductInfo.ApplicationType = ApplicationType.Client;
            registryTargetProductInfo.TargetServiceName = String.Empty;
            Dictionary<string, object> regTable =ServiceFactory.GetInstance().GetRemoteService().GetRegistryInfo(registryTargetProductInfo);
            
            if (regTable.Count != 0)
            {
                string ret = regTable["InstallDirectory"].ToString();
                if (ret != null)
                {
                    paraKey = ret;
                    status = 0;
                }
            }
            return status;
        }

        /// <summary>
        /// ボタンクリックイベント(閉じる)
        /// </summary>
        private void ultraButton_Close_Click(object sender, System.EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// ロードイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMUOE00004U_Load(object sender, EventArgs e)
        {
            this._customerSearchForm = new PMUOE00004U();
            this._customerSearchForm.TopLevel = false;
            this._customerSearchForm.FormBorderStyle = FormBorderStyle.None;
            this._customerSearchForm.Dock = DockStyle.Fill;
        }
    }
}