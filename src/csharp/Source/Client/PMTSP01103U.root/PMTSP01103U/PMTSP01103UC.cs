using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Broadleaf.Application;
using Broadleaf.Application.Controller;


namespace Broadleaf.Windows.Forms
{
	public partial class PMTSP01103UC : Form
	{
		#region コンストラクタ
		
		/// <summary>
		/// コンストラクタ
		/// </summary>
        public PMTSP01103UC(ref TspSendController tspController, FormStartPosition Position)
		{
			InitializeComponent();
            TspController = tspController;
            this.StartPosition = Position;

		}

		#endregion

		#region フィールド
        // 定数
        private const string AssmblyID = "PMTSP01103U";
        private const string AssmblyTitle = "ＴＳＰ送信処理";
		/// <summary>
		/// 送信データ
		/// </summary>

        private TspSendController TspController = null;
        
        #endregion

		#region プロパティ

		#endregion

		#region ・コントロールイベント

		private void PMTSP01103UB_Load(object sender, EventArgs e)
		{
			send_timer.Enabled = true;
		}

        private void send_timer_Tick(object sender, EventArgs e)
        {
            int iStat;
            send_timer.Enabled = false;
            this.Refresh();
            //TSP-SENDフォルダの読込み
            iStat = TspController.SearchTspSdRvDt(TspController.TspInfo.TSPSdRvDataPath, TspSendTableCls.SDR_TABLENAME);
            if (iStat == -1)
            {
                ErrorSet(); 
                return;
            }
            this.Refresh();
            //削除フォルダが無い場合は処理しない
            if (Directory.Exists(TspController.TspInfo.TSPSdRvDataPath + @"\TRASH") == true)
            {
                //TRASHフォルダ（削除データ）の読込み　　　　
                iStat = TspController.SearchTspSdRvDt(TspController.TspInfo.TSPSdRvDataPath + @"\TRASH", TspSendTableCls.TRASH_TABLENAME);
                if (iStat == -1)
                {
                    ErrorSet();
                    return;
                }
                this.Refresh();
            }
            //ステータス取得
            iStat = TspController.Check();
            if (iStat == -1)
            {
                ErrorSet();
                return;
            }
            this.Refresh();
            //送信
            iStat = TspController.Send();
            if (iStat == -1)
            {
                ErrorSet();
                return;
            }
            TspController.TspInfo.LastDate = System.DateTime.Now;
            this.Refresh();
            //削除
            iStat = TspController.TrashDelete();
            if (iStat == -1)
            {
                ErrorSet();
                return;
            }
            this.Refresh();

            this.DialogResult = DialogResult.OK;
        }

        private void ErrorSet()
        {
            this.pBWait.Visible = false;
            this.label1.Text = "送信中にエラーが発生しました。";
            this.label2.Text = "詳細はエラーログを参照してください。";
            this.cancel_Button.Visible = true;
        }

		private void cancel_Button_Click(object sender, EventArgs e)
		{
			//this._msg = "送信処理を中断しました。";
            this.DialogResult = DialogResult.OK;
		}

		#endregion
	}
}