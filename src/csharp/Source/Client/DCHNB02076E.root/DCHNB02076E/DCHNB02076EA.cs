using System;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;


using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 売上月報年報チャートデータ作成クラス
    /// </summary>
    /// <br>Update Note: 2008.09.08 30452 上野 俊治</br>
    /// <br>			 ・PM.NS対応</br>
    public class AgentOrderChart : IChartExtract
    {

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public AgentOrderChart(int index)
        {
            this._ChartScIndex = index;

            this._chartParamater = new ChartParamater();

            this._chartParamater.IsCondtnButton = true;     // 絞込条件ボタン(表示しない)
            this._chartParamater.IsDrillDown = false;       // チャートのドリルダウン機能(なし)                 

            this._salesTableAcs = new SalesTableAcs();

            // チャート表示用データセットインスタンス化
            this._chartDataSet = new DataSet();

            // チャート表示用データセットスキーマ設定
            SetTableSchema();
        }
        #endregion

        #region const

        //public const string CT_SecSalesOrderTrancDataTable = "SecSalesOrderTrancDataTable";
        #endregion

        #region Private Members

        private string _PGID = "DCHNB02076E";

        private int _ChartScIndex = 0;
        private bool _ExtraProcFlg = false;

        private SalesTableAcs _salesTableAcs = null;    // 売上月報年報アクセスクラス

        /// <summary>チャート情報パラメータ</summary>
        private ChartParamater _chartParamater;
        private int _paraStyle = 0;

        /// <summary>チャート表示パラメータリスト</summary>
        private List<int> _chartInfoList;

        /// <summary>ベースデータ保持用データセット</summary>
        private DataSet _baseDataSet;
        /// <summary>チャート表示用データセット</summary>
        private DataSet _chartDataSet;

        // 抽出条件クラス
        private SalesMonthYearReportCndtn _extraparam;

        /// <summary>売上月報年報データテーブル名(ベース用)</summary>
        private string _MonthYearReportTable;
        /// <summary>売上月報年報データテーブル名(チャート用)</summary>
        private string _MonthYearReportDataTable = "MonthYearReportDtl";

        // DataTable列名＜チャート用テーブル＞
        private const string COL_TITLE      = "COL_TITLE";
        private const string COL_SALES      = "COL_PARA01";
        private const string COL_RETGOODS   = "COL_PARA02";
        private const string COL_DISCOUNT   = "COL_PARA03";
        private const string COL_GSALES     = "COL_PARA04";
        private const string COL_TARGET     = "COL_PARA05";
        private const string COL_GRPROFIT   = "COL_PARA06";
        private const string COL_GRTARGET   = "COL_PARA07";
        private const string COL_ANSALES    = "COL_PARA08";
        private const string COL_ANRETGOODS = "COL_PARA09";
        private const string COL_ANDISCOUNT = "COL_PARA10";
        private const string COL_ANGSALES   = "COL_PARA11";
        private const string COL_ANTARGET   = "COL_PARA12";
        private const string COL_ANGRPROFIT = "COL_PARA13";
        private const string COL_ANGRTARGET = "COL_PARA14";

        #endregion

        #region IChartExtract メンバ

        /// <summary>
        /// 
        /// </summary>
        public ChartParamater ChartParamater
        {
            get { return this._chartParamater; }
            set { this._chartParamater = value; }
        }

        #region ◆チャートデータ作成処理
        /// <summary>
        /// チャートデータ作成処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameter"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int MakeChartData(object sender, object parameter, out string msg)
        {
            msg = "";

            try
            {
                this._extraparam = (SalesMonthYearReportCndtn)parameter;

                int result = (int)Broadleaf.Library.Resources.ConstantManagement.MethodResult.ctFNC_ERROR;
                int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
                string message = "";

                try
                {                    
                    status = this._salesTableAcs.SearchStatic(out message);
                    if (status == 0)
                    {
                        this._MonthYearReportTable = Broadleaf.Application.UIData.DCHNB02074EA.ct_Tbl_SalesMonthYearReportDtl;
                        
                        // アクセスクラスから取得したテーブルを、チャート用ベーステーブルとして保持
                        this._baseDataSet = this._salesTableAcs._printDataSet.Copy();
                        //this._baseDataSet.Tables[this._MonthYearReportTable].DefaultView.Sort = CT_RankingNo_Odr;

                        this.CreateTable();

                        // チャート表示パラメータリスト初期化
                        #region < パラメータ初期化 >
                        this._chartInfoList = new List<int>();
                        for (int ix = 1; ix < this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Count; ix++)
                        {
                            if (this._ChartScIndex == 0)
                            {
                                if (ix <= 7)
                                {
                                    this._chartInfoList.Add(1);
                                }
                                else
                                {
                                    this._chartInfoList.Add(0);
                                }
                            }
                            else
                            {
                                if (ix > 7)
                                {
                                    this._chartInfoList.Add(1);
                                }
                                else
                                {
                                    this._chartInfoList.Add(0);
                                }
                            }
                        }
                        #endregion
                    }
                }
                catch (Exception ex)
                {
                    TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, status,
                                MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    // 戻り値を設定。異常の場合はメッセージを表示
                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            {
                                result = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                                break;
                            }
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            {
                                result = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                                break;
                            }
                        default:
                            {
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, this._PGID, message, status,
                                            MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                result = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                                break;
                            }
                    }
                }
                msg = message;
                return result;
            }
            catch (Exception)
            {
                msg = "売上月報年報情報の取得に失敗しました。";
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }
        #endregion

        #region ◆チャートパラメータ取得処理
        /// <summary>
        /// チャートパラメータ取得処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameter"></param>
        /// <param name="chartInfo"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int GetChartInfo(object sender, object parameter, out ChartInfo chartInfo, out string msg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            msg = "";
            chartInfo = new ChartInfo();

            try
            {
                // チャート部品情報の作成
                this.CreateChartInfo(ref chartInfo, this._extraparam);

                // チャート用データテーブルの作成
                this.ExtraProcMain(ref this._chartDataSet, this._baseDataSet, this._extraparam);

                if (this._chartDataSet.Tables[this._MonthYearReportDataTable].Rows.Count == 0)
                {
                    msg = "データが存在しませんでした。";
                    return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }

                // データソースの設定
                chartInfo.DataSource = this._chartDataSet.Tables[this._MonthYearReportDataTable];

            }
            catch (Exception ex)
            {
                msg = "チャート部品情報作成に失敗しました。" + ex;
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion

        #region ◆ドリルダウンチャートパラメータ取得処理
        /// <summary>
        /// ドリルダウンチャートパラメータ取得処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameter"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int GetDrillDownChartInfo(object sender, object parameter, out ChartInfo chartInfo, out string msg)
        {

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            msg = "";
            chartInfo = new ChartInfo();

            // TODO チャート表示用パラメータの取得
            // あれば取得

            try
            {
                // チャート部品情報の作成
                //this.CreateChartInfo(1, ref chartInfo);

                //DataRow parentRow = this._chartDataSet.Tables[CT_TableName_GoodsKind].Rows[(int)parameter];

                //// ドリルダウン元情報の取得
                //string goodsKindName = (string)parentRow[CT_COL_GoodsKindName];
                //chartInfo.SubTitle = "（" + goodsKindName + "）";

                //// チャート用データテーブルの作成
                //this.ExtraProcMaker(parentRow, ref this._chartDataSet);
                //if (this._chartDataSet.Tables[CT_TableName_GoodsMaker].Rows.Count == 0)
                //{
                //    msg = "データが存在しませんでした。";
                //    return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                //}

                //// -- データソースの設定 -// 
                //chartInfo.DataSource = this._chartDataSet.Tables[CT_TableName_GoodsMaker];

            }
            catch (Exception ex)
            {
                msg = "チャート部品情報の作成で例外が発生しました" + "\n\r" + "[" + ex.Message + "]";
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion

        #region ◆チャート条件画面表示処理
        /// <summary>
        /// チャート絞込条件画面表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameter"></param>
        public int ShowCondition(object sender, object parameter)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // 条件入力ＵＩ画面表示
            DCHNB04180UD _singleTypeObj = new DCHNB04180UD();

            #region パラメータセット
            _singleTypeObj._titleList = new List<string>();
            if (this._ChartScIndex == 0)
            {
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[_MonthYearReportDataTable].Columns[COL_SALES].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[_MonthYearReportDataTable].Columns[COL_RETGOODS].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[_MonthYearReportDataTable].Columns[COL_DISCOUNT].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[_MonthYearReportDataTable].Columns[COL_GSALES].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[_MonthYearReportDataTable].Columns[COL_TARGET].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[_MonthYearReportDataTable].Columns[COL_GRPROFIT].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[_MonthYearReportDataTable].Columns[COL_GRTARGET].Caption);
            }
            else
            {
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[_MonthYearReportDataTable].Columns[COL_ANSALES].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[_MonthYearReportDataTable].Columns[COL_ANRETGOODS].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[_MonthYearReportDataTable].Columns[COL_ANDISCOUNT].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[_MonthYearReportDataTable].Columns[COL_ANGSALES].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[_MonthYearReportDataTable].Columns[COL_ANTARGET].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[_MonthYearReportDataTable].Columns[COL_ANGRPROFIT].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[_MonthYearReportDataTable].Columns[COL_ANGRTARGET].Caption);
            }

            _singleTypeObj._graphPara = new List<int>();
            _singleTypeObj._graphPara.Add(this._paraStyle);

            _singleTypeObj._graphShow = new List<int>();
            for (int ix = 0; ix < this._chartInfoList.Count; ix++)
            {
                if ((this._ChartScIndex == 0) && (ix <  7)) _singleTypeObj._graphShow.Add(this._chartInfoList[ix]);
                if ((this._ChartScIndex == 1) && (ix >= 7)) _singleTypeObj._graphShow.Add(this._chartInfoList[ix]);
            }
            #endregion

            Form customForm = (Form)_singleTypeObj;
            customForm.StartPosition = FormStartPosition.CenterScreen;
            customForm.ShowDialog();

            #region パラメータゲット
            if (_singleTypeObj._graphPara[0] > -1)
            {
                int cnt = 0;
                this._paraStyle = _singleTypeObj._graphPara[0];
                for (int ix = 0; ix < this._chartInfoList.Count; ix++)
                {
                    if (((this._ChartScIndex == 0) && (ix < 7)) ||
                        ((this._ChartScIndex == 1) && (ix >= 7)))
                    {
                        this._chartInfoList[ix] = _singleTypeObj._graphShow[cnt];
                        cnt++;
                    }
                }
            }
            #endregion

            return status;
        }
        #endregion

        #endregion


        #region private Method

        #region ◆チャート部品情報作成処理
        /// <summary>
        /// チャート部品情報作成処理
        /// </summary>
        /// <param name="mode">[0:担当者別,1:拠点別,2:機種別]</param>
        /// <param name="chartInfo">チャートパラメータ</param>
        private void CreateChartInfo(ref ChartInfo chartInfo, SalesMonthYearReportCndtn extraparam)
        {

            chartInfo.Palette = PaletteStyle.DefaultWindows;		   	// パレット(色の組み合わせ)
            chartInfo.DockPosition = EditorDockPosition.Top;			// データエディターポジション
            chartInfo.PanelColor = Color.FromArgb(198, 219, 255);		// パネルの色
            chartInfo.Ydecimal = 0;										// Y軸小数点以下桁
            chartInfo.Ydecimal2 = 0;									// Y軸２小数点以下桁
            chartInfo.Stacked = StackStyle.No;                          // データの積層(奥・横に並べる)
            //chartInfo.Cluster = false;                                // Z軸に向けて系統を並べるかどうか    // DEL 2008.08.14
            chartInfo.Cluster = true;                                   // Z軸に向けて系統を並べるかどうか    // ADD 2008.08.14
            chartInfo.Legend = true;                                    // 凡例(表示する)
            chartInfo.LegendBox = false;								// X軸の凡例の表示非表示
            chartInfo.Grid = true;                                      // データグリッド(表示する)
            //chartInfo.View3DDepth = 50; 								// 3Dグラフの奥行き     // DEL 2008.08.14
            chartInfo.View3DDepth = 100; 								// 3Dグラフの奥行き     // ADD 2008.08.14

            //chartInfo.PointLabel = false;                             // チャートの上に値表示(しない)
            //chartInfo.Chart3D = true;                                 // チャート3D or 2D (3D)

            //--- DEL 2008.08.14 ---------->>>>>
            //chartInfo.AngleX = 20;									// X軸の回転
            //chartInfo.AngleY = 0;										// Y軸の回転
            //--- DEL 2008.08.14 ----------<<<<<

            //--- ADD 2008.08.14 ---------->>>>>
            chartInfo.AngleX = 30;										// X軸の回転
            chartInfo.AngleY = 30;										// Y軸の回転
            //--- ADD 2008.08.14 ----------<<<<<

            //chartInfo.DataSource = this._chartDataSet.Tables[this._MonthYearReportDataTable];

            #region < 系統非表示設定 >
            int[] seriesVisible;
            int cnt   = 0;
            int index = 0;
            for (int ix = 0; ix < this._chartInfoList.Count; ix++)
            {
                if (this._chartInfoList[ix] == 0) cnt++;
            }
            seriesVisible = new int[cnt];
            for (int ix = 0; ix < this._chartInfoList.Count; ix++)
            {
                if (this._chartInfoList[ix] == 0)
                {
                    seriesVisible[index] = ix;
                    index++;
                }
            }
            chartInfo.SeriesVisible = seriesVisible;                    // 系の非表示設定
            #endregion

            #region < チャートスタイル設定 >
            if (this._paraStyle == 0)
            {
                chartInfo.Style = ChartStyle.Bar;						// チャートのスタイル
                //chartInfo.View3DDepth = 0; 							// 3Dグラフの奥行き     // DEL 2008.08.14
                chartInfo.View3DDepth = 100; 							// 3Dグラフの奥行き     // ADD 2008.08.14
                //chartInfo.AngleX = 0;									// X軸の回転            // DEL 2008.08.14
                chartInfo.AngleX = 10;									// X軸の回転            // ADD 2008.08.14
                //chartInfo.Cluster = true;                             // Z軸に向けて系統を並べるかどうか
            }
            //else if (this._paraStyle == 1)
            //{
            //    chartInfo.Style = ChartStyle.Line;						// チャートのスタイル
            //    chartInfo.AngleY = 30;									// Y軸の回転
            //}
            //else if (this._paraStyle == 2)
            else if (this._paraStyle == 1)
            {
                chartInfo.Style = ChartStyle.Pie;						// チャートのスタイル
                chartInfo.Legend = false;								// 凡例の表示非表示
            }
            #endregion

            #region < タイトル設定 >
            chartInfo.Title = "売上月報年報";                           // タイトル

            string subtitle = "";
            subtitle = extraparam.TotalTypeName;
            string extraTitle = "";
            if (this._ChartScIndex == 0)
            {
                extraTitle = "（期間）";
            }
            else
            {
                extraTitle = "（当期）";
            }
            chartInfo.SubTitle = subtitle + "  " + extraTitle;          // サブタイトル

            switch (extraparam.TotalType)
            {
                //--- DEL 2008.08.14 ---------->>>>>
                //case 0: // 拠点別
                //    {
                //        chartInfo.XLabel = "拠点";
                //        break;
                //    }
                //case 1: // 得意先別
                //    {
                //        chartInfo.XLabel = "得意先";
                //        break;
                //    }
                //case 2: // 地区別得意先別
                //    {
                //        chartInfo.XLabel = "地区・得意先";
                //        break;
                //    }
                //case 3: // 業種別得意先別
                //    {
                //        chartInfo.XLabel = "業種・得意先";
                //        break;
                //    }
                //case 4: // 地区別
                //    {
                //        chartInfo.XLabel = "地区";
                //        break;
                //    }
                //case 5: // 業種別
                //    {
                //        chartInfo.XLabel = "業種";
                //        break;
                //    }
                //case 6: // 担当者別
                //    {
                //        chartInfo.XLabel = "担当者";
                //        break;
                //    }
                //case 7: // 部署別
                //    {
                //        chartInfo.XLabel = "部署";
                //        break;
                //    }
                //case 8: // メーカー別
                //    {
                //        chartInfo.XLabel = "メーカー";
                //        break;
                //    }
                //case 9: // 得意先別メーカー別
                //    {
                //        chartInfo.XLabel = "得意先／メーカー";
                //        break;
                //    }
                //--- DEL 2008.08.14 ----------<<<<<
                //--- ADD 2008.08.14 ---------->>>>>
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Customer: // 得意先別
                    {
                        chartInfo.XLabel = "得意先";
                        break;
                    }
                //--- ADD 2008.08.14 ----------<<<<<
                // --- ADD 2008/09/08 -------------------------------->>>>>
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesEmployee: // 担当者
                    {
                        chartInfo.XLabel = "担当者";
                        break;
                    }
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.FrontEmployee: // 受注者
                    {
                        chartInfo.XLabel = "受注者";
                        break;
                    }
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesInput: // 発行者 
                    {
                        chartInfo.XLabel = "発行者";
                        break;
                    }
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Area: // 地区
                    {
                        chartInfo.XLabel = "地区";
                        break;
                    }
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.BusinessType: // 業種
                    {
                        chartInfo.XLabel = "業種";
                        break;
                    }
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesDivision: // 販売区分
                    {
                        chartInfo.XLabel = "販売区分";
                        break;
                    }
                // --- ADD 2008/09/08 --------------------------------<<<<< 
            }

            if (extraparam.MoneyUnit == 0)
            {
                chartInfo.YLabel = "円";
            }
            else
            {
                chartInfo.YLabel = "千円";
            }
            #endregion
        }
        #endregion

        #region ◆テーブルスキーマ作成
        /// <summary>
        /// テーブルスキーマ作成
        /// </summary>
        private void CreateTable()
        {
            // ベーステーブル作成
            if (this._baseDataSet == null)
            {
                this._baseDataSet = new DataSet();
            }

            // チャート抽出用テーブル作成
            if (this._chartDataSet == null)
            {
                this._chartDataSet = new DataSet();
            }

            // チャート用テーブルデータ作成フラグクリア
            this._ExtraProcFlg = false;
        }
        #endregion

        #region ◆チャート用テーブルデータ作成処理
        /// <summary>
        /// チャート用テーブルデータ作成処理
        /// </summary>
        private void ExtraProcMain(ref DataSet chartDs, DataSet baseDs, SalesMonthYearReportCndtn extraparam)
        {
            DataRow dr;
            DataRow data;

            // 作成済みの時は処理をスキップ
            if (this._ExtraProcFlg == true) return;

            // テーブル作成
            chartDs.Tables[this._MonthYearReportDataTable].Clear();
            //chartDs.Tables[this._MonthYearReportDataTable].BeginLoadData(); // DEL 2008/10/08

            // --- ADD 2008/09/08 -------------------------------->>>>>
            // baseDsをソートした、DataRowを取得する。

            string sortStr = "";

            switch(extraparam.TotalType)
            {
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Customer: // 得意先
                    {
                        switch (extraparam.OutType) // 出力順
                        {
                            case 0: // 得意先
                            case 3: // 管理拠点
                            case 4: // 請求先
                                {
                                    if (extraparam.PrintOrder == SalesMonthYearReportCndtn.PrintOrderDivState.Order) // 印刷順 順位
                                    {
                                        sortStr = "SectionCode, Order, CustomerCode asc";
                                    }
                                    else // コード
                                    {
                                        sortStr = "SectionCode, CustomerCode asc";
                                    }
                                    break;
                                }
                            case 1: // 拠点
                                {
                                    if (extraparam.PrintOrder == SalesMonthYearReportCndtn.PrintOrderDivState.Order)
                                    {
                                        sortStr = "Order, SectionCode asc";
                                    }
                                    else
                                    {
                                        sortStr = "SectionCode asc";
                                    }
                                    break;
                                }
                            case 2: // 得意先－拠点
                                {
                                    if (extraparam.PrintOrder == SalesMonthYearReportCndtn.PrintOrderDivState.Order)
                                    {
                                        sortStr = "CustomerCode, Order, SectionCode asc";
                                    }
                                    else
                                    {
                                        sortStr = "CustomerCode, SectionCode asc";
                                    }
                                    break;
                                }
                        }

                        break;
                    }

                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesEmployee:
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.FrontEmployee:
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesInput:
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Area:
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.BusinessType:
                    {
                        switch (extraparam.OutType) // 出力順
                        {
                            case 0: // 検索条件名 (担当者 等)
                            case 3: // 管理拠点
                                {
                                    if (extraparam.PrintOrder == SalesMonthYearReportCndtn.PrintOrderDivState.Order) // 印刷順 順位
                                    {
                                        sortStr = "SectionCode, Order, Code asc";
                                    }
                                    else // コード
                                    {
                                        sortStr = "SectionCode, Code asc";
                                    }
                                    break;
                                }
                            case 1: // 得意先
                                {
                                    if (extraparam.PrintOrder == SalesMonthYearReportCndtn.PrintOrderDivState.Order)
                                    {
                                        sortStr = "SectionCode, Code, Order, CustomerCode asc";
                                    }
                                    else
                                    {
                                        sortStr = "SectionCode, Code, CustomerCode asc";
                                    }
                                    break;
                                }
                            case 2: // 検索条件-拠点
                                {
                                    if (extraparam.PrintOrder == SalesMonthYearReportCndtn.PrintOrderDivState.Order)
                                    {
                                        sortStr = "Code, Order, SectionCode asc";
                                    }
                                    else
                                    {
                                        sortStr = "Code, SectionCode asc";
                                    }
                                    break;
                                }
                        }

                        break;
                    }

                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesDivision:
                    {
                        if (extraparam.PrintOrder == SalesMonthYearReportCndtn.PrintOrderDivState.Order)
                        {
                            //sortStr = "SectionCode, Order asc"; // DEL 2009/02/06
                            sortStr = "SectionCode, Order, Code asc"; // ADD 2009/02/06
                        }
                        else
                        {
                            //sortStr = "SectionCode asc"; // DEL 2009/02/06
                            sortStr = "SectionCode, Code asc"; // ADD 2009/02/06
                        }
                        break;
                    }
            }  

            DataRow[] baseDr = baseDs.Tables[this._MonthYearReportTable].Select("", sortStr);

            // --- ADD 2008/09/08 --------------------------------<<<<<
            // --- DEL 2008/09/08 -------------------------------->>>>>
            //for (int ix = 0; ix < baseDs.Tables[this._MonthYearReportTable].Rows.Count; ix++)
            //{
            //    data = baseDs.Tables[this._MonthYearReportTable].Rows[ix];
            // --- DEL 2008/09/08 --------------------------------<<<<<
            // --- ADD 2008/09/08 -------------------------------->>>>>
            for (int ix = 0; ix < baseDr.Length; ix++)
            {
                data = baseDr[ix];
            // --- ADD 2008/09/08 -------------------------------->>>>>
                dr = chartDs.Tables[this._MonthYearReportDataTable].NewRow();

                // 小計タイトル
                switch (extraparam.TotalType)
                {
                    //--- DEL 2008.08.14 ---------->>>>>
                    //case 0: // 拠点別
                    //    {
                    //        dr[COL_TITLE] = data[DCHNB02074EA.CT_SectionName];
                    //        break;
                    //    }
                    //case 1: // 得意先別
                    //    {
                    //        dr[COL_TITLE] = data[DCHNB02074EA.CT_CustomerName];
                    //        break;
                    //    }
                    //case 2: // 地区別得意先別
                    //    {
                    //        dr[COL_TITLE] = data[DCHNB02074EA.CT_SalesAreaName] + " " + data[DCHNB02074EA.CT_CustomerName];
                    //        break;
                    //    }
                    //case 3: // 業種別得意先別
                    //    {
                    //        dr[COL_TITLE] = data[DCHNB02074EA.CT_BusinessTypeName] + " " + data[DCHNB02074EA.CT_CustomerName];
                    //        break;
                    //    }
                    //case 4: // 地区別
                    //    {
                    //        dr[COL_TITLE] = data[DCHNB02074EA.CT_SalesAreaName];
                    //        break;
                    //    }
                    //case 5: // 業種別
                    //    {
                    //        dr[COL_TITLE] = data[DCHNB02074EA.CT_BusinessTypeName];
                    //        break;
                    //    }
                    //case 6: // 担当者別
                    //    {
                    //        dr[COL_TITLE] = data[DCHNB02074EA.CT_EmployeeName];
                    //        break;
                    //    }
                    //case 7: // 部署別
                    //    {
                    //        dr[COL_TITLE] = data[DCHNB02074EA.CT_SubSectionName] + " " + data[DCHNB02074EA.CT_MinSectionName];
                    //        break;
                    //    }
                    //case 8: // メーカー別
                    //    {
                    //        dr[COL_TITLE] = data[DCHNB02074EA.CT_MakerName];
                    //        break;
                    //    }
                    //case 9: // 得意先別メーカー別
                    //    {
                    //        dr[COL_TITLE] = data[DCHNB02074EA.CT_CustomerName] + " " + data[DCHNB02074EA.CT_MakerName];
                    //        break;
                    //    }
                    //--- DEL 2008.08.14 ----------<<<<<
                    //--- ADD 2008.08.14 ---------->>>>>
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Customer: // 得意先別
                        {
                            dr[COL_TITLE] = data[DCHNB02074EA.CT_CustomerName];
                            break;
                        }
                    //--- ADD 2008.08.14 ----------<<<<<
                    // --- ADD 2008/09/08 -------------------------------->>>>>
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesEmployee: // 担当者
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.FrontEmployee: // 受注者
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesInput: // 発行者 
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Area: // 地区
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.BusinessType: // 業種
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesDivision: // 販売区分
                        {
                            dr[COL_TITLE] = data[DCHNB02074EA.CT_Name];
                            break;
                        }
                    // --- ADD 2008/09/08 --------------------------------<<<<<
                }

                // 売上金額
                dr[COL_SALES]       = data[DCHNB02074EA.CT_SalesTtlPrice];
                // 返品金額
                dr[COL_RETGOODS]    = data[DCHNB02074EA.CT_RetGoodsTtlPrice];
                // 値引金額
                dr[COL_DISCOUNT]    = data[DCHNB02074EA.CT_DiscountTtlPrice];
                // 純売上金額
                dr[COL_GSALES]      = data[DCHNB02074EA.CT_PureSalesTtlPrice];
                // 純売上目標金額
                dr[COL_TARGET]      = data[DCHNB02074EA.CT_TargetMoney];
                // 粗利金額
                dr[COL_GRPROFIT]    = data[DCHNB02074EA.CT_GrossProfitPrice];
                // 粗利目標金額
                dr[COL_GRTARGET]    = data[DCHNB02074EA.CT_TargetProfit];

                // 年間売上金額
                dr[COL_ANSALES]     = data[DCHNB02074EA.CT_AnSalesTtlPrice];
                // 年間返品金額
                dr[COL_ANRETGOODS]  = data[DCHNB02074EA.CT_AnRetGoodsTtlPrice];
                // 年間値引金額
                dr[COL_ANDISCOUNT]  = data[DCHNB02074EA.CT_AnDiscountTtlPrice];
                // 年間純売上金額
                dr[COL_ANGSALES]    = data[DCHNB02074EA.CT_AnPureSalesTtlPrice];
                // 純売上目標金額
                dr[COL_ANTARGET]    = data[DCHNB02074EA.CT_AnTargetMoney];
                // 粗利金額
                dr[COL_ANGRPROFIT]  = data[DCHNB02074EA.CT_AnGrossProfitPrice];
                // 粗利目標金額
                dr[COL_ANGRTARGET]  = data[DCHNB02074EA.CT_AnTargetProfit];

                // チャートテーブルに追加
                chartDs.Tables[this._MonthYearReportDataTable].Rows.Add(dr);
            }

            //this._chartDataSet.Tables[this._MonthYearReportDataTable].EndLoadData(); // DEL 2008/10/08

            // チャート用テーブルデータ作成フラグセット
            this._ExtraProcFlg = true;
        }
        #endregion

        #region ◆チャート用データセットスキーマ設定処理
        /// <summary>
        /// チャート用データセットスキーマ設定処理
        /// </summary>
        private void SetTableSchema()
        {
            this._chartDataSet.Tables.Clear();

            
            // 売上月報年報チャート
            this._chartDataSet.Tables.Add(this._MonthYearReportDataTable);

            /* --- DEL 2008/09/08 -------------------------------->>>>>
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_TITLE, typeof(string));   // 小計タイトル
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_TITLE].DefaultValue = "";
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_TITLE].Caption = "小計";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_GRPROFIT, typeof(Int64)); // 粗利金額
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_GRPROFIT].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_GRPROFIT].Caption = "粗利金額";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_GRTARGET, typeof(Int64)); // 粗利目標金額
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_GRTARGET].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_GRTARGET].Caption = "粗利目標";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_DISCOUNT, typeof(Int64)); // 値引金額
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_DISCOUNT].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_DISCOUNT].Caption = "値引";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_RETGOODS, typeof(Int64)); // 返品金額
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_RETGOODS].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_RETGOODS].Caption = "返品";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_GSALES, typeof(Int64));   // 純売上金額
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_GSALES].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_GSALES].Caption = "純売上";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_SALES, typeof(Int64));    // 売上金額
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_SALES].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_SALES].Caption = "売上";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_TARGET, typeof(Int64));   // 目標金額
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_TARGET].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_TARGET].Caption = "目標";


            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_ANGRPROFIT, typeof(Int64));   // 粗利金額
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANGRPROFIT].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANGRPROFIT].Caption = "粗利金額";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_ANGRTARGET, typeof(Int64));   // 粗利目標金額
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANGRTARGET].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANGRTARGET].Caption = "粗利目標";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_ANDISCOUNT, typeof(Int64));   // 年間値引
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANDISCOUNT].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANDISCOUNT].Caption = "値引";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_ANRETGOODS, typeof(Int64));   // 年間返品
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANRETGOODS].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANRETGOODS].Caption = "返品";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_ANGSALES, typeof(Int64));     // 年間純売上
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANGSALES].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANGSALES].Caption = "純売上";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_ANSALES, typeof(Int64));      // 年間売上
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANSALES].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANSALES].Caption = "売上";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_ANTARGET, typeof(Int64));     // 純売上目標金額
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANTARGET].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANTARGET].Caption = "目標";
            --- DEL 2008/09/08 -------------------------------->>>>> */

            // --- ADD 2008/09/08 -------------------------------->>>>> 表示順変更のみ
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_TITLE, typeof(string));   // 小計タイトル
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_TITLE].DefaultValue = "";
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_TITLE].Caption = "小計";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_GRPROFIT, typeof(Int64)); // 粗利金額
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_GRPROFIT].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_GRPROFIT].Caption = "粗利金額";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_GRTARGET, typeof(Int64)); // 粗利目標金額
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_GRTARGET].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_GRTARGET].Caption = "粗利目標";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_DISCOUNT, typeof(Int64)); // 値引金額
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_DISCOUNT].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_DISCOUNT].Caption = "値引";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_RETGOODS, typeof(Int64)); // 返品金額
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_RETGOODS].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_RETGOODS].Caption = "返品";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_GSALES, typeof(Int64));   // 純売上金額
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_GSALES].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_GSALES].Caption = "純売上";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_SALES, typeof(Int64));    // 売上金額
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_SALES].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_SALES].Caption = "売上";
            
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_TARGET, typeof(Int64));   // 目標金額
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_TARGET].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_TARGET].Caption = "売上目標";

            // 当期
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_ANGRPROFIT, typeof(Int64));   // 粗利金額
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANGRPROFIT].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANGRPROFIT].Caption = "粗利金額";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_ANGRTARGET, typeof(Int64));   // 粗利目標金額
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANGRTARGET].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANGRTARGET].Caption = "粗利目標";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_ANDISCOUNT, typeof(Int64));   // 年間値引
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANDISCOUNT].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANDISCOUNT].Caption = "値引";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_ANRETGOODS, typeof(Int64));   // 年間返品
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANRETGOODS].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANRETGOODS].Caption = "返品";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_ANGSALES, typeof(Int64));     // 年間純売上
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANGSALES].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANGSALES].Caption = "純売上";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_ANSALES, typeof(Int64));      // 年間売上
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANSALES].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANSALES].Caption = "売上";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_ANTARGET, typeof(Int64));     // 純売上目標金額
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANTARGET].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANTARGET].Caption = "売上目標";          
            // --- ADD 2008/09/08 --------------------------------<<<<<
        }
        #endregion

        #endregion

        /// <summary>
        /// エラーメッセージ表示
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="iMsg">エラーメッセージ</param>
        /// <param name="iSt">エラーステータス</param>
        /// <param name="iButton">表示ボタン</param>
        /// <param name="iDefButton">初期フォーカスボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : エラーメッセージを表示します。</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "売上月報年報抽出処理", iMsg, iSt, iButton, iDefButton);
        }

    }

}
