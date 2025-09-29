using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Runtime.InteropServices;

namespace Broadleaf.Windows.Forms
{

    public partial class Form1 : Form
    {

        FelicaAcs _felicaAcs = new FelicaAcs();
        public Form1()
        {
            InitializeComponent();
        }

        // ログ出力
        private void AddLogMsg(string msg)
        {
            LogMsgBox.AppendText(DateTime.Now.ToString() + " : " + msg + "\n");
            LogMsgBox.ScrollToCaret();
        }


        // ライブラリ初期化
        private void ultraButton1_Click(object sender, EventArgs e)
        {
            if (_felicaAcs.InitializeLibrary())
                AddLogMsg("ライブラリの初期化に成功");
            else
            {
                AddLogMsg("ライブラリの初期化に失敗");
                AddLogMsg(_felicaAcs.FelicaLastErrType.ToString());
                AddLogMsg(_felicaAcs.RwLastErrType.ToString());
                AddLogMsg(_felicaAcs.LastErrMsg);
            }
        }

        // リーダーライターオープン
        private void ultraButton3_Click(object sender, EventArgs e)
        {
            if (_felicaAcs.OpenReaderWriterAuto())
                AddLogMsg("オープンに成功");
            else
            {
                AddLogMsg("オープンに失敗");
                AddLogMsg(_felicaAcs.FelicaLastErrType.ToString());
                AddLogMsg(_felicaAcs.RwLastErrType.ToString());
                AddLogMsg(_felicaAcs.LastErrMsg);
            }
        }

        // ポーリング(IDm取得)
        private void ultraButton2_Click(object sender, EventArgs e)
        {
            UInt64 cardIdm, cardPmm;
            if (_felicaAcs.PollingAndGetCardInformation(Convert.ToUInt16(FelicaSystemCodes.Common), out cardIdm,out cardPmm))
            {
                AddLogMsg("ポーリングに成功");
                AddLogMsg("IDm : " + cardIdm.ToString());
                AddLogMsg("Pmm : " + cardPmm.ToString());
            }
            else
            {
                AddLogMsg("ポーリングに失敗");
                AddLogMsg(_felicaAcs.FelicaLastErrType.ToString());
                AddLogMsg(_felicaAcs.RwLastErrType.ToString());
                AddLogMsg(_felicaAcs.LastErrMsg);
            }
        }

        // 自作連続ポーリング
        private void timer1_Tick(object sender, EventArgs e)
        {
            UInt64 cardIdm, cardPmm;
            if (_felicaAcs.PollingAndGetCardInformation(Convert.ToUInt16(FelicaSystemCodes.Common), out cardIdm, out cardPmm))
            {
                AddLogMsg("ポーリングに成功");
                AddLogMsg("IDm : " + cardIdm.ToString());
                AddLogMsg("Pmm : " + cardPmm.ToString());
                timer1.Enabled = false;
            }
            else
            {
                AddLogMsg("連続ポーリング中・・・");
            }
        }

        // 連続ポーリング開始
        private void ultraButton4_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        // FeliCaAcsの連続ポーリング呼び出し
        private void ultraButton5_Click(object sender, EventArgs e)
        {
            AddLogMsg("連続ポーリング開始");
            // コールバックデリゲートに登録
            _felicaAcs.CallBackDelegate = new FelicaAcs.PollingCallBackDelegate(PollingSuccessCallBack);
            // 連続ポーリング開始
            _felicaAcs.StartPolling(tNedit1.GetInt(), tNedit2.GetInt());
        }

        // 連続ポーリングコールバック
        private bool PollingSuccessCallBack(UInt64 idm, UInt64 pmm, bool result)
        {
            if (result)
            {
                AddLogMsg("ポーリングに成功");
                AddLogMsg("IDm : " + idm.ToString());
                AddLogMsg("Pmm : " + pmm.ToString());
            }
            else
            {
                AddLogMsg("ポーリングに失敗");
                AddLogMsg(_felicaAcs.FelicaLastErrType.ToString());
                AddLogMsg(_felicaAcs.RwLastErrType.ToString());
                AddLogMsg(_felicaAcs.LastErrMsg);
            }
            return result;
        }

        // 連続ポーリング終了
        private void ultraButton6_Click(object sender, EventArgs e)
        {
            AddLogMsg("連続ポーリング終了");
            _felicaAcs.StopPolling();
        }

        // IDm取得ﾀﾞｲｱﾛｸﾞ表示
        private void IDmGetDlg_Click(object sender, EventArgs e)
        {
            UInt64 idm = 0;
            DialogResult ret = new DialogResult();
            SFCMN03505CE idmDlg = new SFCMN03505CE();
            idmDlg.PollingInterval = tNedit1.GetInt();
            idmDlg.PollingRetryCnt = tNedit2.GetInt();
            idmDlg.ShowErrMsg = ultraCheckEditor1.Checked;
            ret = idmDlg.ShowFeliCaReadForm(ref idm, this);

            if (ret == DialogResult.OK)
            {
                AddLogMsg("ポーリングに成功");
                AddLogMsg("IDm : " + idm.ToString());
            }
            else if (ret == DialogResult.Abort)
            {
                AddLogMsg("ポーリングに失敗");
                AddLogMsg(idmDlg.FelicaLastErrType.ToString());
                AddLogMsg(idmDlg.RwLastErrType.ToString());
            }
        }
     }
}