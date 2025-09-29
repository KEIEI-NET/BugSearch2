using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 分析チャートビューフォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 分析チャートを表示するフォームクラスです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2010.02.18</br>
    /// </remarks>
	internal partial class AnalysisChartViewForm : Form
	{
		#region Constructor
		/// <summary>
		/// 分析チャートビューフォームクラスコンストラクタ
		/// </summary>
		/// <param name="parentForm">親フォーム（分析チャートメインフレーム）</param>
		/// <remarks>
        /// <br>Note       : 分析チャートビューフォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30462 行澤　仁美</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
        internal AnalysisChartViewForm(PMKOU04110UA parentForm)
		{
			InitializeComponent();

			// 親フォーム（分析チャートメインフレーム）
			this._parentForm				= parentForm;

			// ドリルダウン有り分析チャート情報管理クラスリスト初期化
			this._drillDownChartList		= new SortedList();

			// 条件ボタン有り分析チャート情報管理クラスリスト初期化
			this._condtionClickChartList	= new SortedList();

			// チャートパラメータリスト初期化
			this._chartInfoList				= new SortedList();

			// 分析チャート表示設定アクセスクラス
			this._analysisChartSettingAcs	= new AnalysisChartSettingAcs();

            // チャート抽出クラスオブジェクトリスト初期化
            //this._chartExtractList = new List<IChartExtract>();

            // チャート表示用データセットインスタンス化
            this._chartDataSet = new DataSet();

            // チャート表示用データセットスキーマ設定
            SetTableSchema();
        }
		#endregion

		#region Private Member
		/// <summary>親フォーム（分析チャートメインフレーム）</summary>
        private PMKOU04110UA _parentForm = null;

		/// <summary>ドリルダウン有り分析チャート情報管理クラスリスト</summary>
		private SortedList _drillDownChartList						= null;

		/// <summary>条件ボタン有り分析チャート情報管理クラスリスト</summary>
		private SortedList _condtionClickChartList					= null;

		/// <summary>チャートパラメータリスト</summary>
		private SortedList _chartInfoList							= null;

		/// <summary>チャート生成クラス</summary>
		private ChartLibrary _chartLibrary							= null;

        /// <summary>チャート表示用データセット</summary>
        private DataSet _chartDataSet;

        /// <summary>分析チャート表示設定アクセスクラス</summary>
		private AnalysisChartSettingAcs _analysisChartSettingAcs	= null;

        /// <summary>年度取得用</summary>
        private string _totalYear = "";

        /// <summary>チャート抽出クラスオブジェクトリスト</summary>
        //private List<IChartExtract> _chartExtractList = null;

        // 2010/04/30 Add >>>
        /// <summary>チャートスタイルキャッシュ</summary>
        private int[] _chartStyle = new int[2] { 0, 0 };

        /// <summary>折れ線＋棒グラフ用キャッシュ</summary>
        private List<int>[] _seriesList = new List<int>[2] { null, null };
        // 2010/04/30 Add <<<
        #endregion

        #region const
        // DataTable名＜チャート用テーブル＞
        private const string TBL_ANNUALDATA_TITLE  = "ANNUALDATA_TABLE";

        // DataTable列名＜チャート用テーブル＞
        private const string COL_TITLE      = "COL_TITLE";   //集計月
        private const string COL_ST_STOCK      = "COL_PARA1";   //在庫仕入金額
        private const string COL_ST_RETGOODS   = "COL_PARA2";   //在庫返品金額
        private const string COL_ST_DISCOUNT   = "COL_PARA3";   //在庫値引金額
        private const string COL_ST_GSTOCK     = "COL_PARA4";   //在庫純仕入金額
        private const string COL_OR_STOCK = "COL_PARA5";   //取寄仕入金額
        private const string COL_OR_RETGOODS = "COL_PARA6";   //取寄返品金額
        private const string COL_OR_DISCOUNT = "COL_PARA7";   //取寄値引金額
        private const string COL_OR_GSTOCK = "COL_PARA8";   //取寄純仕入金額
        private const string COL_TO_STOCK   = "COL_PARA9";   //合計仕入金額
        private const string COL_TO_RETGOODS   = "COL_PARA10";  //合計返品金額
        private const string COL_TO_DISCOUNT   = "COL_PARA11";  //合計値引金額
        private const string COL_TO_GSTOCK = "COL_PARA12";  //合計純仕入金額
        #endregion

        #region Property
        ///// <summary>チャート抽出オブジェクトリストプロパティ</summary>
        //internal List<IChartExtract> ChartExtractList
        //{
        //    get { return this._chartExtractList; }
        //    set { this._chartExtractList = value; }
        //}

		/// <summary>分析チャート情報管理クラスリスト文字列プロパティ（読み取り専用）</summary>
		internal string AnalysisChartControlListString
		{
			get
			{
				StringBuilder analysisChartControlListString = new StringBuilder(string.Empty);
				return analysisChartControlListString.ToString();
			}
		}
		#endregion

		#region Private Method

		#region 分析チャートデータ生成処理
		/// <summary>
		/// 分析チャートデータ生成処理
		/// </summary>
        /// <param name="analysisChartControlList">売上実績情報クラスリスト</param>
		/// <returns>RESULT（true:OK,false:NG）</returns>
		/// <remarks>
        /// <br>Note       : 分析チャート抽出クラスにて分析チャートデータの生成を行います。</br>
        /// <br>Programmer : 30462 行澤　仁美</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
        private bool CreateChartData(InventoryUpdateDataSet resultData)
        {
			try
			{
				string errorMessage = "";
				int result = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

                try
                {
                    if (resultData.MonthResult.Count == 0)
                    {
                        errorMessage = "仕入年間実績情報が存在しません。";
                        result = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                    }
                    else
                    {
                        //表示データ作成処理
                        CreatDispData(resultData);
                        result = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                }
                catch (Exception)
                {
                    errorMessage = "仕入年間実績情報の取得に失敗しました。";
                    result = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
                        
				switch (result)
				{
					case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
					case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
						{
							break;
						}
					default:
						{
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMKOU04110UA.programID, errorMessage, result, MessageBoxButtons.OK);
							return false;
						}
				}
			}
			catch (Exception ex)
			{
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMKOU04110UA.programID, "分析チャートデータの生成に失敗しました。" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK);
				return false;
			}

			return true;
		}
		#endregion

        /// <summary>
        /// チャートパラメータ取得処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="parameter">引数パラメータ</param>
        /// <param name="chartInfo">取得したチャートパラメータ</param>
        /// <param name="errorMessage">エラー発生時のエラーメッセージ</param>
        /// <returns>RESULT</returns>
        /// <remarks>
        /// <br>Note       : 表示するチャートパラメータを取得します。</br>
        /// <br>Programmer : 30462 行澤　仁美</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
        // 2010/04/30 >>>
        //public int GetChartInfo(object sender, object parameter, out ChartInfo chartInfo, out string errorMessage)
        public int GetChartInfo(object sender, object parameter, object parameter2, out ChartInfo chartInfo, out string errorMessage)
        // 2010/04/30 <<<
        {
            chartInfo = new ChartInfo();
            int[] seriesVisible;

            // 売上年間実績チャート
            chartInfo.Title = "仕入年間実績";                       // タイトル
            //chartInfo.SubTitle = "（" + _totalYear + "年度）";      // サブタイトル
            chartInfo.YLabel = "金額（円）";                        // Y軸ラベル
            chartInfo.Palette = PaletteStyle.DefaultWindows;        // パレット(色の組み合わせ)
            //chartInfo.LegendBox = true;								// X軸の凡例の表示非表示
            chartInfo.Legend = true;								// 凡例の表示非表示
            chartInfo.DockPosition = EditorDockPosition.Top;		// データエディターポジション
            chartInfo.PanelColor = Color.FromArgb(198, 219, 255);   // パネルの色
            chartInfo.Ydecimal = 0;									// Y軸小数点以下桁
            chartInfo.Ydecimal2 = 0;								// Y軸２小数点以下桁
            chartInfo.View3DDepth = 100;							// 3Dグラフの奥行き

            chartInfo.AngleX = 20;									// X軸の回転
            chartInfo.AngleY = 40;							    	// Y軸の回転

            //Color[] piecolor;
            //piecolor = new Color[3];                      // 行毎の色設定
            //piecolor[0] = Color.FromArgb(0, 99, 224);     // 青
            //piecolor[1] = Color.FromArgb(226, 53, 0);     // 赤
            //piecolor[2] = Color.FromArgb(255, 220, 0);    // 黄
            //chartInfo.PieColor = piecolor;

            // 2010/04/30 Add >>>
            chartInfo.Style = ChartStyle.Line;

            if (_chartInfoList.Count == 0)
            {
                _chartStyle[0] = 1;
            }
            else if (_chartInfoList.Count == 1)
            {
                _chartStyle[1] = 1;
            }
            
            // 自由回転
            if (this._chartLibrary == null)
            {
                this._chartLibrary = new ChartLibrary();
            }
            this._chartLibrary.FreeRationVisible = true;
            // 2010/04/30 Add <<<
            
            //データが存在しない場合はそのままフレームに返す
            if (this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Rows.Count == 0)
            {
                errorMessage = "仕入年間実績情報が存在しません。";
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }


            chartInfo.DataSource = this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE]; // データ 

            // 2010/04/30 Add >>>
            // 設定内容ロード
            if (parameter == null)
            {
                List<List<int>> dummyPara = new List<List<int>>();
                PMKOU04110UD form1 = new PMKOU04110UD();
                form1._graphId = _chartInfoList.Count + 1;
                int status = form1.LoadToFiles(out dummyPara);
                if (status == 0)
                {
                    if (dummyPara.Count < 2)
                    {
                        parameter = null;
                        parameter2 = null;
                    }
                    else if (dummyPara[0] == null || dummyPara[1] == null)
                    {
                        parameter = null;
                        parameter2 = null;
                    }
                    else if (dummyPara[0].Count != 13 || dummyPara[1].Count != 13)
                    {
                        parameter = null;
                        parameter2 = null;
                    }
                    else
                    {
                        parameter = dummyPara[0];
                        parameter2 = dummyPara[1];
                    }
                }
            }
            // 2010/04/30 Add <<<

            if (parameter == null)
            {
                
                if (this._chartInfoList.Count == 0)
                {
                    // 在庫
                    seriesVisible = new int[8];
                    seriesVisible[0] = 4;
                    seriesVisible[1] = 5;
                    seriesVisible[2] = 6;
                    seriesVisible[3] = 7;
                    seriesVisible[4] = 8;
                    seriesVisible[5] = 9;
                    seriesVisible[6] = 10;
                    seriesVisible[7] = 11;
                    chartInfo.SeriesVisible = seriesVisible;
                }
                else
                {
                    // 取寄
                    seriesVisible = new int[8];
                    seriesVisible[0] = 0;
                    seriesVisible[1] = 1;
                    seriesVisible[2] = 2;
                    seriesVisible[3] = 3;
                    seriesVisible[4] = 8;
                    seriesVisible[5] = 9;
                    seriesVisible[6] = 10;
                    seriesVisible[7] = 11;
                    chartInfo.SeriesVisible = seriesVisible;
                }

            }
            else
            {
                //chartInfo.SubTitle = "（" + _totalYear + "年度）"; // サブタイトル

                List<int> para = (List<int>)parameter;
                List<int> para2 = (List<int>)parameter2;    // 2010/04/30 Add
                // 棒グラフ
                if (para[0] == 0)
                {
                    chartInfo.Style = ChartStyle.Bar;						// チャートのスタイル
                    // 2010/04/30 Add >>>
                    for (int i = 1; i < 13; i++)
                    {
                        chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Bar, YAxisSelect.Left, false, 80));
                    }
                    // 2010/04/30 Add <<<
                }
                // 折れ線グラフ
                else if (para[0] == 1)
                {
                    chartInfo.Style = ChartStyle.Line;						// チャートのスタイル
                    // 2010/04/30 Add >>>
                    for (int i = 1; i < 13; i++)
                    {
                        chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Line, YAxisSelect.Left, false, 80));
                    }
                    // 2010/04/30 Add <<<
                }
                // 円グラフ
                else if (para[0] == 2)
                {
                    chartInfo.Style = ChartStyle.Pie;						// チャートのスタイル
                    chartInfo.Legend = false;								// 凡例の表示非表示
                    // 2010/04/30 Add >>>
                    for (int i = 1; i < 13; i++)
                    {
                        chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Pie, YAxisSelect.Left, false, 80));
                    }
                    // 2010/04/30 Add <<<
                }
                // 2010/04/30 Add >>>
                // レーダー
                else if (para[0] == 3)
                {
                    chartInfo.Style = ChartStyle.Radar;                     // チャートのスタイル
                    chartInfo.View3DDepth = 0;							    // 3Dグラフの奥行き
                    chartInfo.AngleX = 0;									// X軸の回転
                    chartInfo.AngleY = 0;                                   // Y軸の回転
                }
                // 折れ線＋棒グラフ
                else if (para[0] == 4)
                {
                    List<int> seriesList = new List<int>();
                    for (int i = 1; i < 13; i++)
                    {
                        seriesList.Add(para2[i]);
                        switch (para2[i])
                        {
                            case 0:
                                chartInfo.Style = ChartStyle.Bar;           // チャートのスタイル
                                chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Bar, YAxisSelect.Left, false, 100));
                                break;
                            case 1:
                                chartInfo.Style = ChartStyle.Bar;           // チャートのスタイル
                                chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Bar, YAxisSelect.Left, false, 50));
                                break;
                            case 2:
                                chartInfo.Style = ChartStyle.Line;          // チャートのスタイル
                                chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Line, YAxisSelect.Left, false, 100));
                                break;
                            case 3:
                                chartInfo.Style = ChartStyle.Line;          // チャートのスタイル
                                chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Line, YAxisSelect.Left, false, 50));
                                break;
                            default:
                                break;

                        }
                    }
                    _seriesList[para2[0] - 1] = seriesList;
                    chartInfo.Cluster = true;
                }
                _chartStyle[para2[0] - 1] = para[0];
                // 2010/04/30 Add <<<

                int cnt = 0;
                for (int ix = 1; ix < para.Count; ix++)
                {
                    if (para[ix] == 1) cnt++;
                }
                seriesVisible = new int[cnt];

                if (cnt > 0)
                {
                    cnt = 0;
                    for (int ix = 1; ix < para.Count; ix++)
                    {
                        if (para[ix] == 1) seriesVisible[cnt++] = ix - 1;
                    }
                    chartInfo.SeriesVisible = seriesVisible;
                }
                else
                {
                    chartInfo.SeriesVisible = null;
                }
            }

            errorMessage = "";
            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        /// チャート表示データ作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : チャート表示用データセットを作成します。</br>
        /// <br>Programmer : 30462 行澤　仁美</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
        private void CreatDispData(InventoryUpdateDataSet resultData)
        {
            InventoryUpdateDataSet.MonthResultRow data;
            DataRow dr;

            // 年度取得
            if (resultData.MonthResult[0].RowSetFlg != 0)
            {
                int totalYear = resultData.MonthResult[0].RowSetFlg / 100;
                _totalYear = totalYear.ToString();
            }

            // テーブル作成
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Clear();
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].BeginLoadData();

            for (int ix = 0; ix < resultData.MonthResult.Count; ix++)
            {
                data = resultData.MonthResult[ix];

                // 純売上金額
                dr = this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].NewRow();
                // 集計月
                dr[COL_TITLE] = data.RowTitle;
                if (data.RowSetFlg != 0)
                {
                    // 仕入金額（在庫）
                    dr[COL_ST_STOCK] = data.St_StockPriceTaxExc;
                    // 返品金額（在庫）
                    dr[COL_ST_RETGOODS] = data.St_StockRetGoodsPrice;
                    // 値引金額（在庫）
                    dr[COL_ST_DISCOUNT] = data.St_StockTotalDiscount;
                    // 純仕入金額（在庫）
                    dr[COL_ST_GSTOCK] = data.St_StockPriceSum;

                    // 仕入金額（取寄）
                    dr[COL_OR_STOCK] = data.Or_StockPriceTaxExc;
                    // 返品金額（取寄）
                    dr[COL_OR_RETGOODS] = data.Or_StockRetGoodsPrice;
                    // 値引金額（取寄）
                    dr[COL_OR_DISCOUNT] = data.Or_StockTotalDiscount;
                    // 純仕入金額（取寄）
                    dr[COL_OR_GSTOCK] = data.Or_StockPriceSum;

                    // 仕入金額（合計）
                    dr[COL_TO_STOCK] = data.To_StockPriceTaxExc;
                    // 返品金額（合計）
                    dr[COL_TO_RETGOODS] = data.To_StockRetGoodsPrice;
                    // 値引金額（合計）
                    dr[COL_TO_DISCOUNT] = data.To_StockTotalDiscount;
                    // 純仕入金額（合計）
                    dr[COL_TO_GSTOCK] = data.To_StockPriceSum;

                    // チャートテーブルに追加
                    this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Rows.Add(dr);
                }
                else if (data.RowMonth != 0)
                {
                    // 仕入金額（在庫）
                    dr[COL_ST_STOCK] = 0;
                    // 返品金額（在庫）
                    dr[COL_ST_RETGOODS] = 0;
                    // 値引金額（在庫）
                    dr[COL_ST_DISCOUNT] = 0;
                    // 純仕入金額（在庫）
                    dr[COL_ST_GSTOCK] = 0;

                    // 仕入金額（取寄）
                    dr[COL_OR_STOCK] = 0;
                    // 返品金額（取寄）
                    dr[COL_OR_RETGOODS] = 0;
                    // 値引金額（取寄）
                    dr[COL_OR_DISCOUNT] = 0;
                    // 純仕入金額（取寄）
                    dr[COL_OR_GSTOCK] = 0;

                    // 仕入金額（合計）
                    dr[COL_TO_STOCK] = 0;
                    // 返品金額（合計）
                    dr[COL_TO_RETGOODS] = 0;
                    // 値引金額（合計）
                    dr[COL_TO_DISCOUNT] = 0;
                    // 純仕入金額（合計）
                    dr[COL_TO_GSTOCK] = 0;

                    // チャートテーブルに追加
                    this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Rows.Add(dr);
                }
            }

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].EndLoadData();
        }

        #region 分析チャートパラメータリスト取得処理
		/// <summary>
		/// 分析チャートパラメータリスト取得処理
		/// </summary>
		/// <param name="analysisChartControlList">分析チャート情報管理クラスリスト</param>
		/// <returns>RESULT（true:OK,false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 分析チャート抽出クラスから分析チャートパラメータのリストを取得します。
        ///                  また、ドリルダウンの有る分析チャート情報管理クラスのリストを生成します。</br>
        /// <br>Programmer : 30462 行澤　仁美</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
        //private bool GetChartInfoList(List<IChartExtract> chartExtractObjList)
        private bool GetChartInfoList()
        {
			try
			{
				// ドリルダウン有り分析チャート情報管理クラスリストクリア
				this._drillDownChartList.Clear();

				// 条件ボタン有り分析チャート情報管理クラスリストクリア
				this._condtionClickChartList.Clear();

				// チャートパラメータリストクリア
				this._chartInfoList.Clear();

                for (int i = 0; i < 2; i++)
                {
                    string errorMessage = "";
                    ChartInfo chartInfo;

                    // チャート情報
                    // 2010/04/30 >>>
                    //int result = this.GetChartInfo(this, null, out chartInfo, out errorMessage);
                    int result = this.GetChartInfo(this, null, null, out chartInfo, out errorMessage);
                    // 2010/04/30 <<<

                    switch (result)
                    {
                        case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                        case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                            {
                                // チャート番号を取得
                                int number = this._chartInfoList.Count + 1;

                                // 詳細表示初期値をセット
                                chartInfo.Grid = this._analysisChartSettingAcs.DetailDisplayInitialValue;
                                // ポイントラベル表示初期値をセット
                                chartInfo.PointLabel = this._analysisChartSettingAcs.PointLabelInitialValue;
                                // ラベル角度初期値をセット
                                chartInfo.XLabelVertical = this._analysisChartSettingAcs.LabelVerticalInitialValue;
                                // ３Ｄ／２Ｄ表示初期値をセット
                                chartInfo.Chart3D = this._analysisChartSettingAcs.View3D2DInitialValue;

                                // チャートパラメータリストに格納
                                this._chartInfoList.Add(number, chartInfo);

                                //// ドリルダウンチャート有り
                                //if (chartExtractObj.ChartParamater.IsDrillDown)
                                //{
                                //    // ドリルダウン有り分析チャート情報管理クラスリストに格納
                                //    this._drillDownChartList.Add(number, chartExtractObj);
                                //}

                                //// 条件（条件ボタン）有り
                                //if (chartExtractObj.ChartParamater.IsCondtnButton)
                                //{
                                //    // 条件ボタン有り分析チャート情報管理クラスリストに格納
                                //    this._condtionClickChartList.Add(number, chartExtractObj);
                                //
                                    // 条件ボタン可視設定
                                    this.ConditionButtonVisibleFalse(number, true);
                                //}
                                //else
                                //{
                                //    // 条件ボタン可視設定
                                //    this.ConditionButtonVisibleFalse(number, false);
                                //}
                                break;
                            }

                        default:
                            {
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMKOU04110UA.programID, errorMessage, result, MessageBoxButtons.OK);
                                return false;
                            }
                    }
                }

				if (this._chartInfoList.Count == 0)
				{
					return false;
				}

				if (this._drillDownChartList.Count > 0)
				{
					foreach (int number in this._drillDownChartList.Keys)
					{
						// チャート切替イベント（ドリルダウン用）登録
						this.RegistChartSwitch(number);
					}
				}

				//if (this._condtionClickChartList.Count > 0)
				//{
					// 条件ボタンクリックイベント登録
					this.RegistConditionClick();
				//}
			}
			catch (Exception ex)
			{
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMKOU04110UA.programID, "分析チャートデータの取得に失敗しました。" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK);
				return false;
			}

			return true;
		}
		#endregion

		#region 分析チャート表示処理
		/// <summary>
		/// 分析チャート表示処理
		/// </summary>
		/// <remarks>
        /// <br>Note       : チャート生成クラスにて分析チャートを生成し表示します。</br>
        /// <br>Programmer : 30462 行澤　仁美</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
		private void ShowChartData()
		{
			if (this._chartLibrary == null)
			{
				this._chartLibrary				= new ChartLibrary();
			}

			// パネルに既にコントロールが有る場合はクリアする
			if (this.AnalysisChartView_panel.Controls.Count > 0)
			{
				this.AnalysisChartView_panel.Controls.Remove(this.AnalysisChartView_panel.Controls[0]);
			}

			// ポイントラベルフォントサイズ初期値をセット
			this._chartLibrary.PointLabelSizeInitialValue	= this._analysisChartSettingAcs.PointLabelSizeInitialValue;

			// ラベル最大桁数初期値をセット
			this._chartLibrary.LabelMaxLengthInitialValue	= this._analysisChartSettingAcs.LabelMaxLengthInitialValue;

			// ラベルフォントサイズ初期値をセット
			this._chartLibrary.LabelSizeInitialValue		= this._analysisChartSettingAcs.LabelSizeInitialValue;

			// チャート生成
			this._chartLibrary.GenerateChart(new ArrayList(this._chartInfoList.Values));

			// チャート表示
			this._chartLibrary.TopLevel			= false;
			this._chartLibrary.FormBorderStyle	= FormBorderStyle.None;
			this._chartLibrary.Show();

			// パネルにチャートを表示
			this.AnalysisChartView_panel.Controls.Add(this._chartLibrary);
			this._chartLibrary.Dock				= System.Windows.Forms.DockStyle.Fill;
		}
		#endregion

		#region チャート切替イベント（ドリルダウン用）登録処理
		/// <summary>
		/// チャート切替イベント（ドリルダウン用）登録処理
		/// </summary>
		/// <param name="number">チャート番号</param>
		private void RegistChartSwitch(int number)
		{
			if (this._chartLibrary == null)
			{
				this._chartLibrary = new ChartLibrary();
			}

			switch (number)
			{
				case 1: { this._chartLibrary.ChartSwitch1 += new ChartSwitchingEventHandler(this.ChartSwitch); break; }
				case 2: { this._chartLibrary.ChartSwitch2 += new ChartSwitchingEventHandler(this.ChartSwitch); break; }
				case 3: { this._chartLibrary.ChartSwitch3 += new ChartSwitchingEventHandler(this.ChartSwitch); break; }
				case 4: { this._chartLibrary.ChartSwitch4 += new ChartSwitchingEventHandler(this.ChartSwitch); break; }
			}
		}
		#endregion

		#region チャート切替イベント（ドリルダウン用）削除処理
		/// <summary>
		/// チャート切替イベント（ドリルダウン用）削除処理
		/// </summary>
		/// <param name="number">チャート番号</param>
		private void RemoveChartSwitch(int number)
		{
			if (this._chartLibrary == null)
			{
				this._chartLibrary = new ChartLibrary();
			}

			switch (number)
			{
				case 1: { this._chartLibrary.ChartSwitch1 -= new ChartSwitchingEventHandler(this.ChartSwitch); break; }
				case 2: { this._chartLibrary.ChartSwitch2 -= new ChartSwitchingEventHandler(this.ChartSwitch); break; }
				case 3: { this._chartLibrary.ChartSwitch3 -= new ChartSwitchingEventHandler(this.ChartSwitch); break; }
				case 4: { this._chartLibrary.ChartSwitch4 -= new ChartSwitchingEventHandler(this.ChartSwitch); break; }
			}
		}
		#endregion

		#region チャート切替イベント（ドリルダウンからの戻り用）登録処理
		/// <summary>
		/// チャート切替イベント（ドリルダウンからの戻り用）登録処理
		/// </summary>
		/// <param name="number">チャート番号</param>
		private void RegistBackChartSwitch(int number)
		{
			if (this._chartLibrary == null)
			{
				this._chartLibrary = new ChartLibrary();
			}

			switch (number)
			{
				case 1: { this._chartLibrary.ChartSwitch1 += new ChartSwitchingEventHandler(this.BackChartSwitch); break; }
				case 2: { this._chartLibrary.ChartSwitch2 += new ChartSwitchingEventHandler(this.BackChartSwitch); break; }
				case 3: { this._chartLibrary.ChartSwitch3 += new ChartSwitchingEventHandler(this.BackChartSwitch); break; }
				case 4: { this._chartLibrary.ChartSwitch4 += new ChartSwitchingEventHandler(this.BackChartSwitch); break; }
			}
		}
		#endregion

		#region チャート切替イベント（ドリルダウンからの戻り用）削除処理
		/// <summary>
		/// チャート切替イベント（ドリルダウンからの戻り用）削除処理
		/// </summary>
		/// <param name="number">チャート番号</param>
		private void RemoveBackChartSwitch(int number)
		{
			if (this._chartLibrary == null)
			{
				this._chartLibrary = new ChartLibrary();
			}

			switch (number)
			{
				case 1: { this._chartLibrary.ChartSwitch1 -= new ChartSwitchingEventHandler(this.BackChartSwitch); break; }
				case 2: { this._chartLibrary.ChartSwitch2 -= new ChartSwitchingEventHandler(this.BackChartSwitch); break; }
				case 3: { this._chartLibrary.ChartSwitch3 -= new ChartSwitchingEventHandler(this.BackChartSwitch); break; }
				case 4: { this._chartLibrary.ChartSwitch4 -= new ChartSwitchingEventHandler(this.BackChartSwitch); break; }
			}
		}
		#endregion

		#region チャート切替処理（ドリルダウン用）
		/// <summary>
		/// チャート切替処理（ドリルダウン用）
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void ChartSwitch(object sender, ChartSwitchingEventArgs e)
		{
			try
			{
				if (this._drillDownChartList.ContainsKey(e.Number))
				{
					IChartExtract iChartExtract = this._drillDownChartList[e.Number] as IChartExtract;
					if (iChartExtract != null)
					{
						string errorMessage;
						ChartInfo chartInfo;

						// ドリルダウンチャートパラメータ取得
						int result = iChartExtract.GetDrillDownChartInfo(this, e.Element, out chartInfo, out errorMessage);
						switch (result)
						{
							case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
								{
									// 詳細表示初期値をセット
									chartInfo.Grid				= this._analysisChartSettingAcs.DetailDisplayInitialValue;
									// ポイントラベル表示初期値をセット
									chartInfo.PointLabel		= this._analysisChartSettingAcs.PointLabelInitialValue;
									// ラベル角度初期値をセット
									chartInfo.XLabelVertical	= this._analysisChartSettingAcs.LabelVerticalInitialValue;
									// ３Ｄ／２Ｄ表示初期値をセット
									chartInfo.Chart3D			= this._analysisChartSettingAcs.View3D2DInitialValue;

									// チャートパラメータの削除
									if (this._chartInfoList.ContainsKey(e.Number))
									{
										this._chartInfoList.Remove(e.Number);
									}
									// チャートパラメータリストに格納
									this._chartInfoList.Add(e.Number, chartInfo);

									// チャート再生成
									this._chartLibrary.GenerateChart(new ArrayList(this._chartInfoList.Values));

									// チャート切替イベント（ドリルダウン用）削除
									this.RemoveChartSwitch(e.Number);
									// チャート切替イベント（ドリルダウンからの戻り用）登録
									this.RegistBackChartSwitch(e.Number);

									break;
								}
							case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
								{
									break;
								}
							default:
								{
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMKOU04110UA.programID, errorMessage, result, MessageBoxButtons.OK);
									return;
								}
						}
					}
				}
			}
			catch (Exception ex)
			{
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMKOU04110UA.programID, "分析チャート（ドリルダウン）データの取得に失敗しました。" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK);
			}
		}
		#endregion

		#region チャート切替処理（ドリルダウンからの戻り用）
		/// <summary>
		/// チャート切替処理（ドリルダウンからの戻り用）
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void BackChartSwitch(object sender, ChartSwitchingEventArgs e)
		{
            try
			{
				if (this._drillDownChartList.ContainsKey(e.Number))
				{
					IChartExtract iChartExtract = this._drillDownChartList[e.Number] as IChartExtract;
					if (iChartExtract != null)
					{
						string errorMessage;
						ChartInfo chartInfo;

						int result = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

						// チャートパラメータ取得
                        //result = iChartExtract.GetChartInfo(this, this._extractObj, out chartInfo, out errorMessage);
                        result = iChartExtract.GetChartInfo(this, null, out chartInfo, out errorMessage);

						switch (result)
						{
							case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
							case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
								{
									// 詳細表示初期値をセット
									chartInfo.Grid				= this._analysisChartSettingAcs.DetailDisplayInitialValue;
									// ポイントラベル表示初期値をセット
									chartInfo.PointLabel		= this._analysisChartSettingAcs.PointLabelInitialValue;
									// ラベル角度初期値をセット
									chartInfo.XLabelVertical	= this._analysisChartSettingAcs.LabelVerticalInitialValue;
									// ３Ｄ／２Ｄ表示初期値をセット
									chartInfo.Chart3D			= this._analysisChartSettingAcs.View3D2DInitialValue;

									// チャートパラメータの削除
									if (this._chartInfoList.ContainsKey(e.Number))
									{
										this._chartInfoList.Remove(e.Number);
									}
									// チャートパラメータリストに格納
									this._chartInfoList.Add(e.Number, chartInfo);

									// チャート再生成
									this._chartLibrary.GenerateChart(new ArrayList(this._chartInfoList.Values));

									// チャート切替イベント（ドリルダウンからの戻り用）削除
									this.RemoveBackChartSwitch(e.Number);
									// チャート切替イベント（ドリルダウン用）登録
									this.RegistChartSwitch(e.Number);

									break;
								}
							default:
								{
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMKOU04110UA.programID, errorMessage, result, MessageBoxButtons.OK);
									return;
								}
						}
					}
				}
			}
			catch (Exception ex)
			{
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMKOU04110UA.programID, "分析チャートデータの取得に失敗しました。" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK);
			}
		}
		#endregion

		#region 条件ボタン可視設定処理
		/// <summary>
		/// 条件ボタン可視設定処理
		/// </summary>
		/// <param name="number">チャート番号</param>
		/// <param name="visible">可視</param>
		private void ConditionButtonVisibleFalse(int number, bool visible)
		{
			if (this._chartLibrary == null)
			{
				this._chartLibrary = new ChartLibrary();
			}

			switch (number)
			{
				case 1: { this._chartLibrary.Condition1ButtonVisible = visible; break; }
				case 2: { this._chartLibrary.Condition2ButtonVisible = visible; break; }
				case 3: { this._chartLibrary.Condition3ButtonVisible = visible; break; }
				case 4: { this._chartLibrary.Condition4ButtonVisible = visible; break; }
			}
		}
		#endregion

		#region 条件ボタンクリックイベント登録処理
		/// <summary>
		/// 条件ボタンクリックイベント登録処理
		/// </summary>
		private void RegistConditionClick()
		{
			if (this._chartLibrary == null)
			{
				this._chartLibrary = new ChartLibrary();
			}

			this._chartLibrary.ConditionClick += new ConditionClickEventHandler(this.ConditionClick);
		}
		#endregion

		#region 条件ボタンクリック処理
		/// <summary>
		/// 条件ボタンクリック処理
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void ConditionClick(object sender, ConditionClickEventArgs e)
		{
			try
			{
                //if (this._condtionClickChartList.ContainsKey(e.Number))
                //{
                // 条件入力ＵＩ画面表示
                PMKOU04110UD _singleTypeObj = new PMKOU04110UD();

                #region パラメータセット
                _singleTypeObj._titleList = new List<string>();
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_ST_STOCK].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_ST_RETGOODS].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_ST_DISCOUNT].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_ST_GSTOCK].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_OR_STOCK].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_OR_RETGOODS].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_OR_DISCOUNT].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_OR_GSTOCK].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TO_STOCK].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TO_RETGOODS].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TO_DISCOUNT].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TO_GSTOCK].Caption);

                int flg;
                _singleTypeObj._graphPara = new List<int>();
                _singleTypeObj._graphPara2 = new List<int>();   // 2010/04/30 Add
                ChartInfo _chartInfo = (ChartInfo)_chartInfoList[e.Number];

                // 2010/04/30 Del >>>
                //if (_chartInfo.Style == ChartStyle.Pie) flg = 2;
                //else if (_chartInfo.Style == ChartStyle.Line) flg = 1;
                //else flg = 0;
                // 2010/04/30 Del <<<
                flg = _chartStyle[e.Number - 1];    // 2010/04/30 Add
                _singleTypeObj._graphPara.Add(flg);
                _singleTypeObj._graphPara2.Add(e.Number);   // 2010/04/30 Add

                for (int ix = 1; ix < this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Count; ix++)
                {
                    flg = 1;
                    if (_chartInfo.SeriesVisible != null)
                    {
                        for (int ix2 = 0; ix2 < _chartInfo.SeriesVisible.Length; ix2++)
                        {
                            if (_chartInfo.SeriesVisible[ix2] == ix - 1)
                            {
                                flg = 0;
                                break;
                            }
                        }
                    }
                    _singleTypeObj._graphPara.Add(flg);
                }
                // 2010/04/30 Add >>>
                List<int> seriesList = new List<int>();
                seriesList = _seriesList[e.Number - 1];
                for (int i = 0; i < 12; i++)
                {
                    if (seriesList != null && seriesList.Count != 0)
                    {
                        _singleTypeObj._graphPara2.Add(seriesList[i]);
                    }
                    else
                    {
                        _singleTypeObj._graphPara2.Add(2);
                    }
                }
                // 2010/04/30 Add <<<
                #endregion

                Form customForm = (Form)_singleTypeObj;
                customForm.StartPosition = FormStartPosition.CenterScreen;
                _singleTypeObj._graphId = e.Number; // 2010/04/30 Add
                customForm.ShowDialog(this);
                int result = 0;
                if (_singleTypeObj._graphPara[0] < 0) result = _singleTypeObj._graphPara[0];
                if (result == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    string errorMessage;
                    ChartInfo chartInfo;

                    // チャートパラメータ取得
                    // 2010/04/30 >>>
                    //result = this.GetChartInfo(this, _singleTypeObj._graphPara, out chartInfo, out errorMessage);
                    result = this.GetChartInfo(this, _singleTypeObj._graphPara, _singleTypeObj._graphPara2, out chartInfo, out errorMessage);
                    // 2010/04/30 <<<
                    switch (result)
                    {
                        case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                        case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                            {
                                // 詳細表示初期値をセット
                                chartInfo.Grid = this._analysisChartSettingAcs.DetailDisplayInitialValue;
                                // ポイントラベル表示初期値をセット
                                chartInfo.PointLabel = this._analysisChartSettingAcs.PointLabelInitialValue;
                                // ラベル角度初期値をセット
                                chartInfo.XLabelVertical = this._analysisChartSettingAcs.LabelVerticalInitialValue;
                                // ３Ｄ／２Ｄ表示初期値をセット
                                chartInfo.Chart3D = this._analysisChartSettingAcs.View3D2DInitialValue;

                                // チャートパラメータの削除
                                if (this._chartInfoList.ContainsKey(e.Number))
                                {
                                    this._chartInfoList.Remove(e.Number);
                                }
                                // チャートパラメータリストに格納
                                this._chartInfoList.Add(e.Number, chartInfo);

                                // チャート再生成
                                this._chartLibrary.GenerateChart(new ArrayList(this._chartInfoList.Values));

                                break;
                            }
                        default:
                            {
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMKOU04110UA.programID, errorMessage, result, MessageBoxButtons.OK);
                                return;
                            }
                    }
                //}
                }
			}
			catch (Exception ex)
			{
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMKOU04110UA.programID, "条件設定に失敗しました。" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK);
			}
		}
		#endregion

		#endregion

		#region Internal Method

		#region 分析チャート情報管理クラスリストクリア処理
        ///// <summary>
        ///// 分析チャート情報管理クラスリストクリア処理
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : 分析チャート情報管理クラスリストをクリアします。</br>
        /// <br>Programmer   : 980035 金沢　貞義</br>
        /// <br>Date         : 2007.10.31</br>
        ///// </remarks>
		//internal void ClearAnalysisChartControlList()
		//{
        //    if ((this._chartExtractList == null) || (this._chartExtractList.Count == 0))
		//	{
		//		return;
		//	}
        //
		//	// 分析チャート情報管理クラスリストクリア
        //    this._chartExtractList.Clear();
        //}
		#endregion

		#region 分析チャートビューフォーム表示処理
		/// <summary>
		/// 分析チャートビューフォーム表示処理
		/// </summary>
		/// <remarks>
        /// <br>Note       : 分析チャートビューフォームを表示します。</br>
        /// <br>Programmer : 30462 行澤　仁美</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
		internal void ShowMe(InventoryUpdateDataSet resultData)
		{
			// 画面表示
			this.Show();

			// 分析チャートデータ生成
            if (this.CreateChartData(resultData))
            {

                // 分析チャートパラメータリスト取得
                if (this.GetChartInfoList())
                {
                    // 分析チャート表示
					this.ShowChartData();
                }
			}
		}
		#endregion

		#endregion

        #region チャート用データセットスキーマ設定処理
        /// <summary>
        /// チャート用データセットスキーマ設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : チャート表示用データセットのスキーマを設定します。</br>
        /// </remarks>
        private void SetTableSchema()
        {
            this._chartDataSet.Tables.Clear();

            // 売上年間実績照会チャート
            this._chartDataSet.Tables.Add(TBL_ANNUALDATA_TITLE);
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_TITLE, typeof(string));	// 集計月
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TITLE].DefaultValue = "";
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TITLE].Caption = "集計月";

            // 2010/04/30 Del >>>
            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_ST_STOCK, typeof(int));       // 仕入金額 // DEL 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_ST_STOCK, typeof(double));      // 仕入金額 // ADD 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_ST_STOCK].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_ST_STOCK].Caption = "仕入(在庫)";

            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_ST_RETGOODS, typeof(int));    // 返品金額 // DEL 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_ST_RETGOODS, typeof(double));   // 返品金額 // ADD 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_ST_RETGOODS].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_ST_RETGOODS].Caption = "返品(在庫)";

            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_ST_DISCOUNT, typeof(int));	// 値引金額 // DEL 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_ST_DISCOUNT, typeof(double));	// 値引金額 // ADD 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_ST_DISCOUNT].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_ST_DISCOUNT].Caption = "値引(在庫)";

            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_ST_GSTOCK, typeof(int));      // 純仕入金額 // DEL 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_ST_GSTOCK, typeof(double));     // 純仕入金額 // ADD 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_ST_GSTOCK].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_ST_GSTOCK].Caption = "純仕入(在庫)";

            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_OR_STOCK, typeof(int));       // 仕入金額 // DEL 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_OR_STOCK, typeof(double));      // 仕入金額 // ADD 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_OR_STOCK].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_OR_STOCK].Caption = "仕入(取寄)";

            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_OR_RETGOODS, typeof(int));    // 返品金額 // DEL 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_OR_RETGOODS, typeof(double));   // 返品金額 // ADD 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_OR_RETGOODS].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_OR_RETGOODS].Caption = "返品(取寄)";

            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_OR_DISCOUNT, typeof(int));    // 値引金額 // DEL 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_OR_DISCOUNT, typeof(double));   // 値引金額 // ADD 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_OR_DISCOUNT].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_OR_DISCOUNT].Caption = "値引(取寄)";

            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_OR_GSTOCK, typeof(int));      // 純仕入金額 // DEL 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_OR_GSTOCK, typeof(double));     // 純仕入金額 // ADD 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_OR_GSTOCK].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_OR_GSTOCK].Caption = "純仕入(取寄)";

            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_TO_STOCK, typeof(int));       // 仕入金額 // DEL 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_TO_STOCK, typeof(double));      // 仕入金額 // ADD 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TO_STOCK].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TO_STOCK].Caption = "仕入(合計)";

            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_TO_RETGOODS, typeof(int));    // 返品金額 // DEL 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_TO_RETGOODS, typeof(double));   // 返品金額 // ADD 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TO_RETGOODS].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TO_RETGOODS].Caption = "返品(合計)";

            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_TO_DISCOUNT, typeof(int));    // 値引金額 // DEL 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_TO_DISCOUNT, typeof(double));   // 値引金額 // ADD 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TO_DISCOUNT].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TO_DISCOUNT].Caption = "値引(合計)";

            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_TO_GSTOCK, typeof(int));      // 純仕入金額 // DEL 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_TO_GSTOCK, typeof(double));     // 純仕入金額 // ADD 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TO_GSTOCK].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TO_GSTOCK].Caption = "純仕入(合計)";
            // 2010/04/30 Del <<<

            // 2010/04/30 Add >>>
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_ST_DISCOUNT, typeof(double));	// 値引金額 // ADD 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_ST_DISCOUNT].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_ST_DISCOUNT].Caption = "値引(在庫)";

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_ST_RETGOODS, typeof(double));   // 返品金額 // ADD 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_ST_RETGOODS].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_ST_RETGOODS].Caption = "返品(在庫)";

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_ST_GSTOCK, typeof(double));     // 純仕入金額 // ADD 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_ST_GSTOCK].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_ST_GSTOCK].Caption = "純仕入(在庫)";

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_ST_STOCK, typeof(double));      // 仕入金額 // ADD 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_ST_STOCK].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_ST_STOCK].Caption = "仕入(在庫)";

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_OR_DISCOUNT, typeof(double));   // 値引金額 // ADD 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_OR_DISCOUNT].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_OR_DISCOUNT].Caption = "値引(取寄)";

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_OR_RETGOODS, typeof(double));   // 返品金額 // ADD 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_OR_RETGOODS].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_OR_RETGOODS].Caption = "返品(取寄)";

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_OR_GSTOCK, typeof(double));     // 純仕入金額 // ADD 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_OR_GSTOCK].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_OR_GSTOCK].Caption = "純仕入(取寄)";

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_OR_STOCK, typeof(double));      // 仕入金額 // ADD 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_OR_STOCK].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_OR_STOCK].Caption = "仕入(取寄)";

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_TO_DISCOUNT, typeof(double));   // 値引金額 // ADD 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TO_DISCOUNT].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TO_DISCOUNT].Caption = "値引(合計)";

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_TO_RETGOODS, typeof(double));   // 返品金額 // ADD 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TO_RETGOODS].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TO_RETGOODS].Caption = "返品(合計)";

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_TO_GSTOCK, typeof(double));     // 純仕入金額 // ADD 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TO_GSTOCK].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TO_GSTOCK].Caption = "純仕入(合計)";

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_TO_STOCK, typeof(double));      // 仕入金額 // ADD 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TO_STOCK].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TO_STOCK].Caption = "仕入(合計)";
            // 2010/04/30 Add <<<
        }
        #endregion

    }
}