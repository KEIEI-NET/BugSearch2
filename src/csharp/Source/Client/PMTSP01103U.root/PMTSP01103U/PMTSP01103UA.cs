using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ＴＳＰ送受信処理【ＰＭ側】
    /// </summary>
    /// <remarks>
    /// <br>Note		: </br>
    /// <br>Programmer	: 小原</br>
    /// <br>Date		: 2020/12/01</br>
    /// <br></br>
    /// </remarks>
    public partial class PMTSP01103UA : Form
    {
        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMTSP01103UA()
        {
            InitializeComponent();
        }

        #endregion

        #region フィールド
        private TspSendController TspController = null;
        private Process extProcess = null;
        private Thread extThread = null;
        string NotePadProgram = "";

        // 定数
        private const string AssmblyID = "PMTSP01103U";
        private const string AssmblyTitle = "ＴＳＰ送信処理";

        // 画面Ｂ（詳細画面）
        private PMTSP01103UB PMTSP01103UB_Form = null;

        #endregion

        #region プロパティ

        #endregion

        #region パブリックメソッド
        #endregion

        #region プライベイトメソッド

        #endregion

        #region コントロールイベント

        /// <summary>
        /// Form.Load イベント
        /// </summary>
        private void PMTSP01103UA_Load(object sender, EventArgs e)
        {
            TspController = new TspSendController();
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            // ツールボタン
            this.Toolbar.ImageListSmall = IconResourceManagement.ImageList24;
            this.Toolbar.Tools["exit"].SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.CLOSE;
            this.Toolbar.Tools["send"].SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.DEMANDPROP;
            this.Toolbar.Tools["detail"].SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.MODIFY;
            this.Toolbar.Tools["delete"].SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.DELETE;
            this.Toolbar.Tools["log"].SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.AMBIGUOUSSEARCH;
            this.Toolbar.Tools["setting"].SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.SETUP1;
            // ツールボタンを無効にする
            this.Toolbar.Tools["exit"].SharedProps.Enabled = false;
            this.Toolbar.Tools["send"].SharedProps.Enabled = false;
            this.Toolbar.Tools["log"].SharedProps.Enabled = false;
            this.Toolbar.Tools["setting"].SharedProps.Enabled = false;
            this.Toolbar.Tools["detail"].SharedProps.Enabled = false;
            this.Toolbar.Tools["delete"].SharedProps.Enabled = false;
            this.Toolbar.Tools["filter"].SharedProps.Enabled = false;
            
            this.Stat0Cnt_label.Text = "0件";
            this.Stat1Cnt_label.Text = "0件";
            this.Stat2Cnt_label.Text = "0件";
            this.lastdate_label.Text = "--/--/-- --:--:--";

            Infragistics.Win.UltraWinToolbars.ComboBoxTool combo =
              (Infragistics.Win.UltraWinToolbars.ComboBoxTool)Toolbar.Tools.GetItem(Toolbar.Tools.IndexOf("filter"));
            combo.SelectedIndex = 0;

            NotePadProgram = @"NOTEPAD.EXE";
            // タイマー ON
            timer1.Enabled = true;
        }

        /// <summary>
        /// 起動後処理
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            // タイマー OFF
            timer1.Enabled = false;
            if (TspController.TspInfo.TSPSdRvDataPath == "")
            {
                MessageBox.Show("送信フォルダが設定されていません。\n送信フォルダの設定を行ってください。", AssmblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                // ツールボタンを無効にする
                this.Toolbar.Tools["exit"].SharedProps.Enabled = true;
                this.Toolbar.Tools["setting"].SharedProps.Enabled = true;

                return;
            }

            if (Directory.Exists(TspController.TspInfo.TSPSdRvDataPath) == false)
            {
                MessageBox.Show("送信フォルダが存在しません。\n送信フォルダの設定を行ってください。", AssmblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                // ツールボタンを無効にする
                this.Toolbar.Tools["exit"].SharedProps.Enabled = true;
                this.Toolbar.Tools["setting"].SharedProps.Enabled = true;
                TspController.WriteErrorLog("処理中断\r\n");
                TspController.CloseErrorLog();
                return;
            }

            if (TspController.OpenErrorLog() == -1)
            {
                MessageBox.Show("他の端末で送信中の為読込みできませんでした。", AssmblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                // ツールボタンを無効にする
                this.Toolbar.Tools["exit"].SharedProps.Enabled = true;
                return;
            }
            TspController.WriteErrorLog("一括送信起動");

            if (TspController.ReadTSPList() > 0)
            {
                TSPCustGrid.DataSource = TspController.TSPCustomerList;
                TSPCustGrid_InitializeLayout();
            }
            else
            {
                MessageBox.Show("送信先得意先が存在しません。\nTSP連携マスタの設定を行って下さい。", AssmblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                // ツールボタンを無効にする
                this.Toolbar.Tools["exit"].SharedProps.Enabled = true;
                TspController.WriteErrorLog("処理中断\r\n");
                TspController.CloseErrorLog();
                return;

            }
            // 送受信データを検索
            if (TspController.Start_EnterpriseCD != "")
            {
                int iStat = 0;
                //TSP-SENDフォルダの対象データ読込み
                toolStripStatusLabel1.Text = "送信フォルダを読み込み中…";
                toolStripProgressBar1.PerformStep();
                this.Refresh();
                //TSP-SENDフォルダ読込み
                iStat = TspController.SearchTspSdRvDt(TspController.TspInfo.TSPSdRvDataPath, TspSendTableCls.SDR_TABLENAME);
                if (iStat == -1)
                {
                    MessageBox.Show("送信データ読込み中にエラーが発生しました。\n詳細はエラーログを参照してください。", AssmblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Toolbar.Tools["exit"].SharedProps.Enabled = true;
                    this.Toolbar.Tools["log"].SharedProps.Enabled = true;
                    toolStripStatusLabel1.Text = "処理中断";
                    TspController.WriteErrorLog("処理中断\r\n");
                    TspController.CloseErrorLog();
                    return;
                }

                //削除フォルダが無い場合は処理しない
                if (Directory.Exists(TspController.TspInfo.TSPSdRvDataPath + @"\TRASH") == true)
                {
                    //TRASHフォルダ読込み　　　　
                    iStat = TspController.SearchTspSdRvDt(TspController.TspInfo.TSPSdRvDataPath + @"\TRASH", TspSendTableCls.TRASH_TABLENAME);
                    if (iStat == -1)
                    {
                        MessageBox.Show("削除データ読込み中にエラーが発生しました。\n詳細はエラーログを参照してください。", AssmblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Toolbar.Tools["exit"].SharedProps.Enabled = true;
                        this.Toolbar.Tools["log"].SharedProps.Enabled = true;
                        toolStripStatusLabel1.Text = "処理中断";
                        TspController.WriteErrorLog("処理中断\r\n");
                        TspController.CloseErrorLog();
                        return;
                    }
                }
                //更新チェック
                toolStripStatusLabel1.Text = "更新内容をチェックしています…";
                toolStripProgressBar1.PerformStep();
                this.Refresh();
                iStat = TspController.Check();
                if (iStat == -1)
                {
                    MessageBox.Show("更新内容をチェック中にエラーが発生しました。\n詳細はエラーログを参照してください。", AssmblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Toolbar.Tools["exit"].SharedProps.Enabled = true;
                    this.Toolbar.Tools["log"].SharedProps.Enabled = true;
                    toolStripStatusLabel1.Text = "処理中断";
                    TspController.WriteErrorLog("処理中断\r\n");
                    TspController.CloseErrorLog();
                    return;
                }

                //削除データチェック
                iStat = TspController.TrashDelete();
                if (iStat == -1)
                {
                    MessageBox.Show("削除データを処理中にエラーが発生しました。\n詳細はエラーログを参照してください。", AssmblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Toolbar.Tools["exit"].SharedProps.Enabled = true;
                    this.Toolbar.Tools["log"].SharedProps.Enabled = true;
                    toolStripStatusLabel1.Text = "処理中断";
                    TspController.WriteErrorLog("処理中断\r\n");
                    TspController.CloseErrorLog();
                    return;
                }
                TspController.WriteErrorLog("起動時処理終了\r\n");
                TspController.CloseErrorLog();

                toolStripProgressBar1.PerformStep();
                toolStripStatusLabel1.Text = "送信ボタンでデータ送信できます。";

                // 回答データグリッドのデータソースを設定
                SdRvDtGrid.DataSource = TspController.TspSendData.SdrvView;
                TSPSdRvDtGrid_InitializeLayout();
                TspController.TspSendData.SetRowFilter(TspController.Start_EnterpriseCD);

                SlipCountRefresh();
            }

            // ツールボタンを有効にする
            this.Toolbar.Tools["exit"].SharedProps.Enabled = true;
            this.Toolbar.Tools["send"].SharedProps.Enabled = true;
            this.Toolbar.Tools["log"].SharedProps.Enabled = true;
            this.Toolbar.Tools["setting"].SharedProps.Enabled = true;
            this.Toolbar.Tools["filter"].SharedProps.Enabled = true;

            // ツールボタンを無効にする
            this.Toolbar.Tools["detail"].SharedProps.Enabled = false;
            this.Toolbar.Tools["delete"].SharedProps.Enabled = false;
            if (TSPCustGrid.ActiveRow != null) TSPCustGrid.ActiveRow.Selected = true;
            

        }

        private void SlipCountRefresh()
        {
            TspController.GetSlipCnt();
            this.Stat0Cnt_label.Text = String.Format("{0}件", TspController.Stat0Cnt);
            this.Stat1Cnt_label.Text = String.Format("{0}件", TspController.Stat1Cnt);
            this.Stat2Cnt_label.Text = String.Format("{0}件", TspController.Stat2Cnt);
            if (TspController.TspInfo.LastDate == DateTime.MinValue)
            {
                this.lastdate_label.Text = "--/--/-- --:--:--";
            }
            else
            {
                this.lastdate_label.Text = (TspController.TspInfo.LastDate.ToShortDateString() + " " + TspController.TspInfo.LastDate.ToShortTimeString());
            }

        }

        private void send_Button_Click()
        {
            if (TspController.OpenErrorLog() == -1) 
            {
                MessageBox.Show("他の端末で処理中の為送信出来ませんでした。\nしばらくしてから再度処理を行ってください。", AssmblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TspController.WriteErrorLog("手動送信開始");
            PMTSP01103UC form = null;
            form = new PMTSP01103UC(ref this.TspController, FormStartPosition.CenterParent);
            form.ShowDialog();
            TspController.WriteErrorLog("終了\r\n");
            TspController.CloseErrorLog();

            string epcode = (string)this.TSPCustGrid.ActiveRow.Cells[TspCustomer.CUST_SfEnterpriseCode].Value;
            SlipCountRefresh();

        }

        private void setting_Button_Click()
        {
            TspController.TspInfo.Setting();
        }

        private void detail_Button_Click()
        {
            if (SdRvDtGrid.ActiveRow == null) return;
            TspSdRvDtl[] dtl;
            dtl = (TspSdRvDtl[])this.SdRvDtGrid.ActiveRow.Cells[TspSendTableCls.DTL_DataClass].Value;
            TspSdRvDt dt;
            dt = (TspSdRvDt)this.SdRvDtGrid.ActiveRow.Cells[TspSendTableCls.SDR_DataClass].Value;
            this.PMTSP01103UB_Form = new PMTSP01103UB(dt,dtl);
            this.PMTSP01103UB_Form.ShowDialog();
        }

        private void delete_Button_Click()
        {
            if (TspController.OpenErrorLog() == -1)
            {
                MessageBox.Show("他の端末で処理中の為削除できませんでした。\nしばらくしてから再度処理を行ってください。", AssmblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TspSdRvDt tspdt = (TspSdRvDt)this.SdRvDtGrid.ActiveRow.Cells[TspSendTableCls.SDR_DataClass].Value;
            TspController.Delete((DataRowView)this.SdRvDtGrid.ActiveRow.ListObject);
            SdRvDtGrid.Refresh();
            SlipCountRefresh();

            TspController.CloseErrorLog();

        }

        private void exit_Button_Click()
        {
            this.Close();
        }

        private void log_Button_Click()
        {

            extThread = new Thread(new ThreadStart(ProcessWorker));
            extThread.Start();
        }


        //外部プロセスを起動するためのスレッド
        private void ProcessWorker()
        {
            //外部プロセスの起動
            try
            {
                extProcess = new Process();
                extProcess.StartInfo.FileName = NotePadProgram;//起動するファイル名
                extProcess.StartInfo.Arguments = TspController.LogFilePath;
                extProcess.Start();

                //スレッドが終了されるまで待機
                while (!extProcess.HasExited)
                {
                    Thread.Sleep(100);
                }
            }
            catch
            {
            }
            finally
            {
            }
        }

        private void TSPCustGrid_AfterRowActivate(object sender, EventArgs e)
        {
            if (TSPCustGrid.ActiveRow == null) return;
            int[] arg = { 0, 1, 9 };
            string epcode;
            epcode = (string)this.TSPCustGrid.ActiveRow.Cells[TspCustomer.CUST_SfEnterpriseCode].Value;
            Infragistics.Win.UltraWinToolbars.ComboBoxTool combo =
              (Infragistics.Win.UltraWinToolbars.ComboBoxTool)Toolbar.Tools.GetItem(Toolbar.Tools.IndexOf("filter"));
            if (combo.SelectedIndex == 0)
            {
                TspController.TspSendData.SetRowFilter(epcode);
            }
            else
            {
                TspController.TspSendData.SetRowFilter(epcode, arg);
            }
            SlipCountRefresh();

        }

        private void SdRvFilterCombo_SelectedIndexChanged(int SelectedIndex)
        {
            if (TSPCustGrid.ActiveRow == null) return;
            string epcode;
            int[] arg = { 0, 1, 9 };

            switch (SelectedIndex)
            {
                case 0:
                    {
                        epcode = (string)this.TSPCustGrid.ActiveRow.Cells[TspCustomer.CUST_SfEnterpriseCode].Value;
                        TspController.TspSendData.SetRowFilter(epcode);
                        break;
                    }
                case 1:
                    {
                        epcode = (string)this.TSPCustGrid.ActiveRow.Cells[TspCustomer.CUST_SfEnterpriseCode].Value;
                        TspController.TspSendData.SetRowFilter(epcode, arg);
                        break;
                    }
            }
        }


        private void PMTSP01103UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            //送信が無効の場合は終了処理を行わない
            if (this.Toolbar.Tools["send"].SharedProps.Enabled == false) return;

            if (TspController.OpenErrorLog() == -1) return;
            //削除
            TspController.AutoDelete();
            TspController.CloseErrorLog();

        }
        #endregion



        #region 得意先グリッド初期化
        /// <summary>
        /// 
        /// </summary>
        private void TSPCustGrid_InitializeLayout()
        {
            Infragistics.Win.UltraWinGrid.UltraGrid grid = TSPCustGrid;
            //バンドを取得
            Infragistics.Win.UltraWinGrid.UltraGridBand band = grid.DisplayLayout.Bands[0];

            //列幅自動調整
            grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
            for (int ix = 0; ix < band.Columns.Count; ix++)
            {
                // 列の表示／非表示（デフォルト）
                switch (band.Columns[ix].Key)
                {
                    case TspCustomer.CUST_PmCustomerCode:	//通信状態
                    case TspCustomer.CUST_PmCustomerName:	//備考
#if DEBUG
                    case TspCustomer.CUST_PmEnterpriseCode:	//PM企業コード
                    case TspCustomer.CUST_SfEnterpriseCode:	//SF企業コード
#endif
                        band.Columns[ix].Hidden = false;
                        break;
                    default:
                        band.Columns[ix].Hidden = true;
                        break;
                }

            }
            //幅
            band.Columns[TspCustomer.CUST_PmCustomerCode].Width = 160;	//得意先コード
            band.Columns[TspCustomer.CUST_PmCustomerName].Width = 280;	//得意先名称
            // 表示順
            band.Columns[TspCustomer.CUST_PmCustomerCode].Header.VisiblePosition = 0;	//得意先コード
            band.Columns[TspCustomer.CUST_PmCustomerName].Header.VisiblePosition = 1;	//得意先名称
            // 表示位置
            band.Columns[TspCustomer.CUST_PmCustomerCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;	//得意先コード
            band.Columns[TspCustomer.CUST_PmCustomerName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;	//得意先名称

        }
        #endregion

        #region 送信データグリッド初期化

        private void TSPSdRvDtGrid_InitializeLayout()
        {

            Infragistics.Win.UltraWinGrid.UltraGrid grid = SdRvDtGrid;

            //バンドを取得
            Infragistics.Win.UltraWinGrid.UltraGridBand band = grid.DisplayLayout.Bands[0];

            //列幅自動調整
            grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;

            for (int ix = 0; ix < band.Columns.Count; ix++)
            {
                // 列の表示／非表示（デフォルト）
                switch (band.Columns[ix].Key)
                {
                    case TspSendTableCls.SDR_CommConditionDivCd:	//通信状態
                    case TspSendTableCls.SDR_InstSlipNoStr:	//指示書番号
                    case TspSendTableCls.SDR_PmSlipKind:	//PM部品名（カナ）
                    case TspSendTableCls.SDR_PmSlipNo:	//PM伝票番号
                    case TspSendTableCls.SDR_AcceptAnOrderDate:	//受注日
                    case TspSendTableCls.SDR_TspTotalSlipPrice:	//合計金額
                    case TspSendTableCls.SDR_PmComment:	//備考
#if DEBUG
                    case TspSendTableCls.SDR_PmEnterpriseCode://PM企業コード
                    case TspSendTableCls.SDR_SfEnterpriseCode://SF企業コード
                    case TspSendTableCls.SDR_TspCommNo://SF企業コード
#endif
                        band.Columns[ix].Hidden = false;
                        break;
                    default:
                        band.Columns[ix].Hidden = true;
                        break;
                }

            }
            band.Columns[TspSendTableCls.SDR_CommConditionDivCd].Width = 70;	//通信状態
            band.Columns[TspSendTableCls.SDR_InstSlipNoStr].Width = 90;	//指示書番号
            band.Columns[TspSendTableCls.SDR_PmSlipKind].Width = 70;	//PM伝票種別
            band.Columns[TspSendTableCls.SDR_PmSlipNo].Width = 70;	//PM伝票番号
            band.Columns[TspSendTableCls.SDR_AcceptAnOrderDate].Width = 90;	//受注日
            band.Columns[TspSendTableCls.SDR_TspTotalSlipPrice].Width = 80;	//合計金額
            band.Columns[TspSendTableCls.SDR_PmComment].Width = 300;	//備考

            // 表示順
            band.Columns[TspSendTableCls.SDR_CommConditionDivCd].Header.VisiblePosition = 0;	//通信状態
            band.Columns[TspSendTableCls.SDR_InstSlipNoStr].Header.VisiblePosition = 1;	//指示書番号
            band.Columns[TspSendTableCls.SDR_PmSlipKind].Header.VisiblePosition = 2;	//PM伝票種別
            band.Columns[TspSendTableCls.SDR_PmSlipNo].Header.VisiblePosition = 3;	//PM伝票番号
            band.Columns[TspSendTableCls.SDR_AcceptAnOrderDate].Header.VisiblePosition = 4;	//受注日
            band.Columns[TspSendTableCls.SDR_TspTotalSlipPrice].Header.VisiblePosition = 5;	//合計金額
            band.Columns[TspSendTableCls.SDR_PmComment].Header.VisiblePosition = 6;	//備考

            // 書式
            band.Columns[TspSendTableCls.SDR_TspTotalSlipPrice].Format = "#,##0;-#,##0;";	//合計金額

            // 表示位置
            band.Columns[TspSendTableCls.SDR_CommConditionDivCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;	//通信状態
            band.Columns[TspSendTableCls.SDR_InstSlipNoStr].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;	///指示書番号
            band.Columns[TspSendTableCls.SDR_PmSlipKind].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;	//PM伝票種別
            band.Columns[TspSendTableCls.SDR_PmSlipNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;	//PM伝票番号
            band.Columns[TspSendTableCls.SDR_AcceptAnOrderDate].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;	//受注日
            band.Columns[TspSendTableCls.SDR_TspTotalSlipPrice].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;	//合計金額
            band.Columns[TspSendTableCls.SDR_PmComment].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;	//備考

            // 値リストを初期化し、グリッドへ追加します。
            grid.DisplayLayout.ValueLists.Clear();
            Infragistics.Win.ValueList vl1 = grid.DisplayLayout.ValueLists.Add();
            vl1.ValueListItems.Add(0, "未送信");
            vl1.ValueListItems.Add(1, "送信済");
            vl1.ValueListItems.Add(2, "処理済");
            vl1.ValueListItems.Add(4, "削除済");
            vl1.ValueListItems.Add(9, "送信ｴﾗｰ");
            band.Columns[TspSendTableCls.SDR_CommConditionDivCd].ValueList = vl1;

            Infragistics.Win.ValueList vl2 = grid.DisplayLayout.ValueLists.Add();
            vl2.ValueListItems.Add(10, "売上");
            vl2.ValueListItems.Add(11, "修正");
            vl2.ValueListItems.Add(20, "返品");
            vl2.ValueListItems.Add(21, "修正");
            band.Columns[TspSendTableCls.SDR_PmSlipKind].ValueList = vl2;

            // キー動作マッピングを追加
            grid.KeyActionMappings.Add(
                new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                    Keys.Enter,	//Enterキー
                    Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
                    0,
                    Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                    Infragistics.Win.SpecialKeys.All,
                    0)
                );

        }

        #endregion

        private void SdRvDtGrid_Enter(object sender, EventArgs e)
        {
            if (this.Toolbar.Tools["send"].SharedProps.Enabled == false)
            {
                // ツールボタンを無効にする
                this.Toolbar.Tools["detail"].SharedProps.Enabled = false;
                this.Toolbar.Tools["delete"].SharedProps.Enabled = false;
            }
            else
            {
                // ツールボタンを有効にする
                this.Toolbar.Tools["detail"].SharedProps.Enabled = true;
                this.Toolbar.Tools["delete"].SharedProps.Enabled = true;
            }
        }

        private void SdRvDtGrid_Leave(object sender, EventArgs e)
        {
            // ツールボタンを無効にする
            this.Toolbar.Tools["detail"].SharedProps.Enabled = false;
            this.Toolbar.Tools["delete"].SharedProps.Enabled = false;

        }

        private void SdRvDtGrid_DblClick(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (e.Row == null) return;

            if (SdRvDtGrid.ActiveRow == null) return;
            TspSdRvDtl[] dtl;
            dtl = (TspSdRvDtl[])this.SdRvDtGrid.ActiveRow.Cells[TspSendTableCls.DTL_DataClass].Value;
            TspSdRvDt dt;
            dt = (TspSdRvDt)this.SdRvDtGrid.ActiveRow.Cells[TspSendTableCls.SDR_DataClass].Value;
            this.PMTSP01103UB_Form = new PMTSP01103UB(dt, dtl);
            this.PMTSP01103UB_Form.ShowDialog();


        }

        private void Toolbar_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "send":	//終了
                    send_Button_Click();
                    break;

                case "setting"://設定
                    setting_Button_Click();
                    break;

                case "detail":	//詳細
                    detail_Button_Click();
                    break;

                case "delete":	//削除
                    delete_Button_Click();
                    break;

                case "exit":	//終了
                    exit_Button_Click();
                    break;

                case "log":	//ログ
                    log_Button_Click();
                    break;

            }

        }

        private void Toolbar_ToolValueChanged(object sender, Infragistics.Win.UltraWinToolbars.ToolEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "filter":	//終了

                    Infragistics.Win.UltraWinToolbars.ComboBoxTool combo =
                      (Infragistics.Win.UltraWinToolbars.ComboBoxTool)e.Tool;
                    SdRvFilterCombo_SelectedIndexChanged(combo.SelectedIndex);
                    break;
            }
        }
    }
}