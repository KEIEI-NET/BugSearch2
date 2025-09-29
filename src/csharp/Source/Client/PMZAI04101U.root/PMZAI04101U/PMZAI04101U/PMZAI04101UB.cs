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
    /// <br>Programmer : 980035 金沢　貞義</br>
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
        internal AnalysisChartViewForm(PMZAI04101UA parentForm)
        {
            InitializeComponent();

            // 親フォーム（分析チャートメインフレーム）
            this._parentForm = parentForm;

            // ドリルダウン有り分析チャート情報管理クラスリスト初期化
            this._drillDownChartList = new SortedList();

            // 条件ボタン有り分析チャート情報管理クラスリスト初期化
            this._condtionClickChartList = new SortedList();

            // チャートパラメータリスト初期化
            this._chartInfoList = new SortedList();

            // 分析チャート表示設定アクセスクラス
            this._analysisChartSettingAcs = new AnalysisChartSettingAcs();

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
        private PMZAI04101UA _parentForm = null;

        /// <summary>ドリルダウン有り分析チャート情報管理クラスリスト</summary>
        private SortedList _drillDownChartList = null;

        /// <summary>条件ボタン有り分析チャート情報管理クラスリスト</summary>
        private SortedList _condtionClickChartList = null;

        /// <summary>チャートパラメータリスト</summary>
        private SortedList _chartInfoList = null;

        /// <summary>チャート生成クラス</summary>
        private ChartLibrary _chartLibrary = null;

        /// <summary>チャート表示用データセット</summary>
        private DataSet _chartDataSet;

        /// <summary>分析チャート表示設定アクセスクラス</summary>
        private AnalysisChartSettingAcs _analysisChartSettingAcs = null;

        /// <summary>チャート抽出クラスオブジェクトリスト</summary>
        //private List<IChartExtract> _chartExtractList = null;

        // 2010/04/30 Add >>>
        /// <summary>チャートスタイルキャッシュ</summary>
        private int[] _chartStyle = new int[3] { 0, 0, 0 };

        /// <summary>折れ線＋棒グラフ用キャッシュ</summary>
        private List<int>[] _seriesList = new List<int>[3] { null, null, null };
        // 2010/04/30 Add <<<
        #endregion

        #region const
        // DataTable名＜チャート用テーブル＞
        private const string TBL_ANNUALDATA_TITLE = "ANNUALDATA_TABLE";

        // DataTable列名＜チャート用テーブル＞
        private const string COL_TITLE = "COL_TITLE";
        private const string COL_SALESTIMES = "COL_PARA01";
        private const string COL_SALESCOUNT = "COL_PARA02";
        private const string COL_SALESMONEY = "COL_PARA03";
        private const string COL_STOCKTIMES = "COL_PARA04";
        private const string COL_STOCKCOUNT = "COL_PARA05";
        private const string COL_STOCKMONEY = "COL_PARA06";
        private const string COL_GRPROFIT = "COL_PARA07";
        private const string COL_MOVEACOUNT = "COL_PARA08";
        private const string COL_MOVEAPRICE = "COL_PARA09";
        private const string COL_MOVESCOUNT = "COL_PARA10";
        private const string COL_MOVESPRICE = "COL_PARA11";
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
        private bool CreateChartData(List<StockHistoryDspSearchResult> resultData)
        {
            try
            {
                string errorMessage = "";
                int result = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

                try
                {
                    if (resultData.Count == 0)
                    {
                        errorMessage = "在庫年間実績情報が存在しません。";
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
                    errorMessage = "在庫年間実績情報の取得に失敗しました。";
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
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMZAI04101UA.programID, errorMessage, result, MessageBoxButtons.OK);
                            return false;
                        }
                }
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMZAI04101UA.programID, "分析チャートデータの生成に失敗しました。" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK);
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
        //public int GetChartInfo(object sender, object parameter, int number, out ChartInfo chartInfo, out string errorMessage)
        public int GetChartInfo(object sender, object parameter, object paramete2, int number, out ChartInfo chartInfo, out string errorMessage)
        // 2010/04/30 <<<
        {
            chartInfo = new ChartInfo();
            int[] seriesVisible;

            // 在庫年間実績チャート
            chartInfo.Title = "在庫年間実績";                       // タイトル
            //chartInfo.YLabel = "金額（円）";                        // Y軸ラベル
            chartInfo.Palette = PaletteStyle.DefaultWindows;        // パレット(色の組み合わせ)
            //chartInfo.LegendBox = true;								// X軸の凡例の表示非表示
            chartInfo.Legend = true;								// 凡例の表示非表示
            chartInfo.DockPosition = EditorDockPosition.Top;		// データエディターポジション
            chartInfo.PanelColor = Color.FromArgb(198, 219, 255);   // パネルの色
            chartInfo.Ydecimal = 0;									// Y軸小数点以下桁
            chartInfo.Ydecimal2 = 0;								// Y軸２小数点以下桁
            chartInfo.View3DDepth = 100;							// 3Dグラフの奥行き

            chartInfo.AngleX = 20;									// X軸の回転
            chartInfo.AngleY = 40;								    // Y軸の回転

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
            else if (_chartInfoList.Count == 2)
            {
                _chartStyle[2] = 1;
            }
            // 自由回転
            if (this._chartLibrary == null)
            {
                this._chartLibrary = new ChartLibrary();
            }
            this._chartLibrary.FreeRationVisible = true;
            // 2010/04/30 Add <<<

            //Color[] piecolor;
            //piecolor = new Color[3];                      // 行毎の色設定
            //piecolor[0] = Color.FromArgb(0, 99, 224);     // 青
            //piecolor[1] = Color.FromArgb(226, 53, 0);     // 赤
            //piecolor[2] = Color.FromArgb(255, 220, 0);    // 黄
            //chartInfo.PieColor = piecolor;

            //データが存在しない場合はそのままフレームに返す
            if (this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Rows.Count == 0)
            {
                errorMessage = "在庫年間実績情報が存在しません。";
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            chartInfo.DataSource = this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE]; // データ

            // 2010/04/30 Add >>>
            if (parameter == null)
            {
                List<List<int>> dummyPara = new List<List<int>>();
                DCHNB04180UD form1 = new DCHNB04180UD();
                form1._graphId = _chartInfoList.Count + 1;
                int status = form1.LoadToFiles(out dummyPara);
                if (status == 0)
                {
                    if (dummyPara.Count < 2)
                    {
                        parameter = null;
                        paramete2 = null;
                    }
                    else if (dummyPara[0] == null || dummyPara[1] == null)
                    {
                        parameter = null;
                        paramete2 = null;
                    }
                    else if (dummyPara[0].Count != 12 || dummyPara[1].Count != 12)
                    {
                        parameter = null;
                        paramete2 = null;
                    }
                    else
                    {
                        parameter = dummyPara[0];
                        paramete2 = dummyPara[1];
                        number = form1._graphId;
                    }
                }
            }
            // 2010/04/30 Add <<<

            if (parameter == null)
            {
                switch (this._chartInfoList.Count)
                {
                    case 0:
                        {
                            // 金額
                            chartInfo.SubTitle = "≪ 金額 ≫";  // サブタイトル
                            chartInfo.YLabel = "金額（円）";    // Y軸ラベル
                            seriesVisible = new int[6];
                            // 2010/04/30 >>>
                            //seriesVisible[0] = 0;
                            //seriesVisible[1] = 1;
                            //seriesVisible[2] = 3;
                            //seriesVisible[3] = 4;
                            //seriesVisible[4] = 7;
                            //seriesVisible[5] = 9;
                            seriesVisible[0] = 0;
                            seriesVisible[1] = 1;
                            seriesVisible[2] = 2;
                            seriesVisible[3] = 3;
                            seriesVisible[4] = 4;
                            seriesVisible[5] = 5;
                            // 2010/04/30 <<<
                            chartInfo.SeriesVisible = seriesVisible;
                            break;
                        }
                    case 1:
                        {
                            // 数量
                            chartInfo.SubTitle = "≪ 数量 ≫";  // サブタイトル
                            chartInfo.YLabel = "数量（個）";    // Y軸ラベル
                            seriesVisible = new int[7];
                            // 2010/04/30 >>>
                            //seriesVisible[0] = 0;
                            //seriesVisible[1] = 2;
                            //seriesVisible[2] = 3;
                            //seriesVisible[3] = 5;
                            //seriesVisible[4] = 6;
                            //seriesVisible[5] = 8;
                            //seriesVisible[6] = 10;
                            seriesVisible[0] = 0;
                            seriesVisible[1] = 1;
                            seriesVisible[2] = 6;
                            seriesVisible[3] = 7;
                            seriesVisible[4] = 8;
                            seriesVisible[5] = 9;
                            seriesVisible[6] = 10;
                            // 2010/04/30 <<<
                            chartInfo.SeriesVisible = seriesVisible;
                            break;
                        }
                    case 2:
                        {
                            // 回数
                            chartInfo.SubTitle = "≪ 回数 ≫";  // サブタイトル
                            chartInfo.YLabel = "回数（回）";    // Y軸ラベル
                            seriesVisible = new int[9];
                            // 2010/04/30 >>>
                            //seriesVisible[0] = 1;
                            //seriesVisible[1] = 2;
                            //seriesVisible[2] = 4;
                            //seriesVisible[3] = 5;
                            //seriesVisible[4] = 6;
                            //seriesVisible[5] = 7;
                            //seriesVisible[6] = 8;
                            //seriesVisible[7] = 9;
                            //seriesVisible[8] = 10;
                            seriesVisible[0] = 2;
                            seriesVisible[1] = 3;
                            seriesVisible[2] = 4;
                            seriesVisible[3] = 5;
                            seriesVisible[4] = 6;
                            seriesVisible[5] = 7;
                            seriesVisible[6] = 8;
                            seriesVisible[7] = 9;
                            seriesVisible[8] = 10;
                            // 2010/04/30 <<<
                            chartInfo.SeriesVisible = seriesVisible;
                            break;
                        }
                }
            }
            else
            {
                List<int> para = (List<int>)parameter;
                List<int> para2 = (List<int>)paramete2; // 2010/04/30 Add
                if (para[0] == 0)
                {
                    chartInfo.Style = ChartStyle.Bar;						// チャートのスタイル
                    // 2010/04/30 Add >>>
                    for (int i = 1; i < 12; i++)
                    {
                        chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Bar, YAxisSelect.Left, false, 80));
                    }
                    // 2010/04/30 Add <<<
                }
                else if (para[0] == 1)
                {
                    chartInfo.Style = ChartStyle.Line;						// チャートのスタイル
                    // 2010/04/30 Add >>>
                    for (int i = 1; i < 12; i++)
                    {
                        chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Line, YAxisSelect.Left, false, 80));
                    }
                    // 2010/04/30 Add <<<
                }
                else if (para[0] == 2)
                {
                    chartInfo.Style = ChartStyle.Pie;						// チャートのスタイル
                    chartInfo.Legend = false;								// 凡例の表示非表示
                    // 2010/04/30 Add >>>
                    for (int i = 1; i < 12; i++)
                    {
                        chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Pie, YAxisSelect.Left, false, 80));
                    }
                    // 2010/04/30 Add <<<
                }
                // 2010/04/30 Add >>>
                else if (para[0] == 3)
                {
                    chartInfo.Style = ChartStyle.Radar;                     // チャートのスタイル
                    chartInfo.View3DDepth = 0;						    	// 3Dグラフの奥行き
                    chartInfo.AngleX = 0;									// X軸の回転
                    chartInfo.AngleY = 0;                                   // Y軸の回転
                }
                else if (para[0] == 4 || para[0] == 5)
                {
                    bool leftFlg = true;
                    List<int> seriesList = new List<int>();
                    for (int i = 1; i < 12; i++)
                    {
                        seriesList.Add(para2[i]);
                        switch (i)
                        {
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                            case 11:
                                // 金額
                                if (number == 1)
                                    leftFlg = true;
                                else
                                    leftFlg = false;
                                break;
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                                // 数量
                                if (number == 2)
                                    leftFlg = true;
                                else
                                    leftFlg = false;
                                break;
                            case 1:
                            case 2:
                                // 回数
                                if (number == 3)
                                    leftFlg = true;
                                else
                                    leftFlg = false;
                                break;
                        }
                        SeriesAdd(ref chartInfo, para2[i], leftFlg);
                    }
                    _seriesList[number - 1] = seriesList;
                }
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

                switch (number)
                {
                    case 1:
                        {
                            // 金額
                            chartInfo.SubTitle = "≪ 金額 ≫";  // サブタイトル
                            chartInfo.YLabel = "金額（円）";    // Y軸ラベル
                            // 2010/04/30 Add >>>
                            // 金額＋回数
                            if (para[0] == 4)
                            {
                                chartInfo.SubTitle = "≪ 金額＋回数 ≫";  // サブタイトル
                                chartInfo.YLabel2 = "回数（回）";    // Y軸ラベル
                            }
                            // 金額＋数量
                            else if (para[0] == 5)
                            {
                                chartInfo.SubTitle = "≪ 金額＋数量 ≫";  // サブタイトル
                                chartInfo.YLabel2 = "数量（個）";    // Y軸ラベル
                            }
                            // 2010/04/30 Add <<<
                            break;
                        }
                    case 2:
                        {
                            // 数量
                            chartInfo.SubTitle = "≪ 数量 ≫";  // サブタイトル
                            chartInfo.YLabel = "数量（個）";    // Y軸ラベル
                            // 2010/04/30 Add >>>
                            // 数量＋金額
                            if (para[0] == 4)
                            {
                                chartInfo.SubTitle = "≪ 数量＋金額 ≫";  // サブタイトル
                                chartInfo.YLabel2 = "金額（円）";    // Y軸ラベル
                            }
                            // 数量＋回数
                            else if (para[0] == 5)
                            {
                                chartInfo.SubTitle = "≪ 数量＋回数 ≫";  // サブタイトル
                                chartInfo.YLabel2 = "回数（回）";    // Y軸ラベル
                            }
                            // 2010/04/30 Add <<<
                            break;
                        }
                    case 3:
                        {
                            // 回数
                            chartInfo.SubTitle = "≪ 回数 ≫";  // サブタイトル
                            chartInfo.YLabel = "回数（回）";    // Y軸ラベル
                            // 2010/04/30 Add >>>
                            // 回数＋数量
                            if (para[0] == 4)
                            {
                                chartInfo.SubTitle = "≪ 回数＋数量 ≫";  // サブタイトル
                                chartInfo.YLabel2 = "数量（個）";    // Y軸ラベル
                            }
                            // 回数＋金額
                            else if (para[0] == 5)
                            {
                                chartInfo.SubTitle = "≪ 回数＋金額 ≫";  // サブタイトル
                                chartInfo.YLabel2 = "金額（円）";    // Y軸ラベル
                            }
                            // 2010/04/30 Add <<<
                            break;
                        }
                }
                _chartStyle[number - 1] = para[0];
            }

            errorMessage = "";
            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        private void SeriesAdd(ref ChartInfo chartInfo, int para2, bool leftFlg)
        {
            switch (para2)
            {
                case 0: // 棒グラフ（大）
                    if (leftFlg)
                        chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Bar, YAxisSelect.Left, false, 100));
                    else
                        chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Bar, YAxisSelect.Right, false, 100));
                    break;
                case 1: // 棒グラフ（小）
                    if (leftFlg)
                        chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Bar, YAxisSelect.Left, false, 50));
                    else
                        chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Bar, YAxisSelect.Right, false, 50));
                    break;
                case 2: // 折れ線グラフ（大）
                    if (leftFlg)
                        chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Line, YAxisSelect.Left, false, 100));
                    else
                        chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Line, YAxisSelect.Right, false, 100));
                    break;
                case 3: // 折れ線グラフ（小）
                    if (leftFlg)
                        chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Line, YAxisSelect.Left, false, 50));
                    else
                        chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Line, YAxisSelect.Right, false, 50));
                    break;
            }
        }

        /// <summary>
        /// チャート表示データ作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : チャート表示用データセットを作成します。</br>
        /// <br>Programmer : 30462 行澤　仁美</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
        private void CreatDispData(List<StockHistoryDspSearchResult> resultData)
        {
            StockHistoryDspSearchResult data;
            DataRow dr;
            int monthCount = 0;
            int monthWork = 0;

            // 表示月チェック(今回分は除くため-1する)
            if (resultData.Count - 1 <= 12)
            {
                monthCount = 12 - (resultData.Count - 1);
                monthWork = resultData[1].AddUpYearMonth.Month - monthCount;
            }

            // テーブル作成
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Clear();
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].BeginLoadData();

            for (int ix = 0; ix < monthCount; ix++)
            {
                data = null;

                // 表示月セット
                int setMonth = monthWork + ix;
                if (setMonth < 1) setMonth = setMonth + 12;

                this.CreatDispDataSub(setMonth, data, out dr);

                // チャートテーブルに追加
                this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Rows.Add(dr);
            }

            for (int ix = 1; ix < resultData.Count; ix++)
            {
                data = resultData[ix];
                this.CreatDispDataSub(0, data, out dr);

                // チャートテーブルに追加
                this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Rows.Add(dr);
            }

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].EndLoadData();
        }

        /// <summary>
        /// チャート表示データ作成サブ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : チャート表示用データセットを作成します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2010.02.18</br>
        /// </remarks>
        private void CreatDispDataSub(int month, StockHistoryDspSearchResult data, out DataRow dr)
        {
            dr = this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].NewRow();

            if ((data == null) ||
                (data.AddUpYearMonth == DateTime.MinValue))
            {
                // 集計月
                dr[COL_TITLE] = month.ToString() + "月";

                // 売上回数
                dr[COL_SALESTIMES] = 0;
                // 売上数
                dr[COL_SALESCOUNT] = 0;
                // 売上金額（税抜き）
                dr[COL_SALESMONEY] = 0;

                // 仕入回数
                dr[COL_STOCKTIMES] = 0;
                // 仕入数
                dr[COL_STOCKCOUNT] = 0;
                // 仕入金額（税抜き）
                dr[COL_STOCKMONEY] = 0;

                // 粗利金額
                dr[COL_GRPROFIT] = 0;

                // 移動入荷数
                dr[COL_MOVEACOUNT] = 0;
                // 移動入荷額
                dr[COL_MOVEAPRICE] = 0;

                // 移動出荷数
                dr[COL_MOVESCOUNT] = 0;
                // 移動出荷額
                dr[COL_MOVESPRICE] = 0;
            }
            else
            {
                // 集計月
                dr[COL_TITLE] = data.AddUpYearMonth.Month.ToString() + "月";

                // 売上回数
                dr[COL_SALESTIMES] = data.SalesTimes;
                // 売上数
                dr[COL_SALESCOUNT] = data.SalesCount;
                // 売上金額（税抜き）
                dr[COL_SALESMONEY] = data.SalesMoneyTaxExc;

                // 仕入回数
                dr[COL_STOCKTIMES] = data.StockTimes;
                // 仕入数
                dr[COL_STOCKCOUNT] = data.StockCount;
                // 仕入金額（税抜き）
                dr[COL_STOCKMONEY] = data.StockPriceTaxExc;

                // 粗利金額
                dr[COL_GRPROFIT] = data.GrossProfit;

                // 移動入荷数
                dr[COL_MOVEACOUNT] = data.MoveArrivalCnt;
                // 移動入荷額
                dr[COL_MOVEAPRICE] = data.MoveArrivalPrice;

                // 移動出荷数
                dr[COL_MOVESCOUNT] = data.MoveShipmentCnt;
                // 移動出荷額
                dr[COL_MOVESPRICE] = data.MoveShipmentPrice;
            }
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

                for (int i = 0; i < 3; i++)
                {
                    string errorMessage = "";
                    ChartInfo chartInfo;

                    // チャート情報
                    int result = this.GetChartInfo(this, null, null, 0, out chartInfo, out errorMessage);

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
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMZAI04101UA.programID, errorMessage, result, MessageBoxButtons.OK);
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
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMZAI04101UA.programID, "分析チャートデータの取得に失敗しました。" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK);
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
                this._chartLibrary = new ChartLibrary();
            }

            // パネルに既にコントロールが有る場合はクリアする
            if (this.AnalysisChartView_panel.Controls.Count > 0)
            {
                this.AnalysisChartView_panel.Controls.Remove(this.AnalysisChartView_panel.Controls[0]);
            }

            // ポイントラベルフォントサイズ初期値をセット
            this._chartLibrary.PointLabelSizeInitialValue = this._analysisChartSettingAcs.PointLabelSizeInitialValue;

            // ラベル最大桁数初期値をセット
            this._chartLibrary.LabelMaxLengthInitialValue = this._analysisChartSettingAcs.LabelMaxLengthInitialValue;

            // ラベルフォントサイズ初期値をセット
            this._chartLibrary.LabelSizeInitialValue = this._analysisChartSettingAcs.LabelSizeInitialValue;

            // チャート生成
            this._chartLibrary.GenerateChart(new ArrayList(this._chartInfoList.Values));

            // チャート表示
            this._chartLibrary.TopLevel = false;
            this._chartLibrary.FormBorderStyle = FormBorderStyle.None;
            this._chartLibrary.Show();

            // パネルにチャートを表示
            this.AnalysisChartView_panel.Controls.Add(this._chartLibrary);
            this._chartLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
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
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMZAI04101UA.programID, errorMessage, result, MessageBoxButtons.OK);
                                    return;
                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMZAI04101UA.programID, "分析チャート（ドリルダウン）データの取得に失敗しました。" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK);
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

                                    // チャート切替イベント（ドリルダウンからの戻り用）削除
                                    this.RemoveBackChartSwitch(e.Number);
                                    // チャート切替イベント（ドリルダウン用）登録
                                    this.RegistChartSwitch(e.Number);

                                    break;
                                }
                            default:
                                {
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMZAI04101UA.programID, errorMessage, result, MessageBoxButtons.OK);
                                    return;
                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMZAI04101UA.programID, "分析チャートデータの取得に失敗しました。" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK);
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
                DCHNB04180UD _singleTypeObj = new DCHNB04180UD();

                #region パラメータセット
                _singleTypeObj._titleList = new List<string>();
                switch (e.Number)
                {
                    case 1: // 金額
                        {
                            // 2010/04/30 Add >>>
                            // 金額＋回数
                            if (_chartStyle[e.Number - 1] == 4)
                            {
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESTIMES].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKTIMES].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESMONEY].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKMONEY].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GRPROFIT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEAPRICE].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESPRICE].Caption);
                            }
                            // 金額＋数量
                            else if (_chartStyle[e.Number - 1] == 5)
                            {
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESCOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKCOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEACOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESCOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESMONEY].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKMONEY].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GRPROFIT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEAPRICE].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESPRICE].Caption);
                            }
                            else
                            {
                                // 2010/04/30 Add <<<
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESMONEY].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKMONEY].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GRPROFIT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEAPRICE].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESPRICE].Caption);
                            }   // 2010/04/30 Add
                            break;
                        }
                    case 2: // 数量
                        {
                            // 2010/04/30 Add >>>
                            // 数量＋金額
                            if (_chartStyle[e.Number - 1] == 4)
                            {
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESCOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKCOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEACOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESCOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESMONEY].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKMONEY].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GRPROFIT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEAPRICE].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESPRICE].Caption);
                            }
                            // 数量＋回数
                            else if (_chartStyle[e.Number - 1] == 5)
                            {
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESTIMES].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKTIMES].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESCOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKCOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEACOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESCOUNT].Caption);
                            }
                            else
                            {
                                // 2010/04/30 Add <<<
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESCOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKCOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEACOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESCOUNT].Caption);
                            }   // 2010/04/30 Add
                            break;
                        }
                    case 3: // 回数
                        {
                            // 2010/04/30 Add >>>
                            // 回数＋数量
                            if (_chartStyle[e.Number - 1] == 4)
                            {
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESTIMES].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKTIMES].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESCOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKCOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEACOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESCOUNT].Caption);
                            }
                            // 回数＋金額
                            else if (_chartStyle[e.Number - 1] == 5)
                            {
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESTIMES].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKTIMES].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESMONEY].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKMONEY].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GRPROFIT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEAPRICE].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESPRICE].Caption);
                            }
                            else
                            {
                                // 2010/04/30 Add <<<
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESTIMES].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKTIMES].Caption);
                            }   // 2010/04/30 Add
                            break;
                        }
                }

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
                                switch (e.Number)
                                {
                                    case 1: // 金額
                                        {
                                            // 2010/04/30 Add >>>
                                            // 金額＋回数
                                            if (_chartStyle[e.Number - 1] == 4)
                                            {
                                                switch (ix - 1)
                                                {
                                                    case 2:
                                                    case 3:
                                                    case 4:
                                                    case 5:
                                                        {
                                                            flg = -1;
                                                            break;
                                                        }
                                                }
                                            }
                                            // 金額＋数量
                                            else if (_chartStyle[e.Number - 1] == 5)
                                            {
                                                switch (ix - 1)
                                                {
                                                    case 0:
                                                    case 1:
                                                        {
                                                            flg = -1;
                                                            break;
                                                        }
                                                }
                                            }
                                            else
                                            {
                                                // 2010/04/30 Add <<<
                                                switch (ix - 1)
                                                {
                                                    // 2010/04/30 >>>
                                                    //case 0:
                                                    //case 1:
                                                    //case 3:
                                                    //case 4:
                                                    //case 7:
                                                    //case 9:
                                                    case 0:
                                                    case 1:
                                                    case 2:
                                                    case 3:
                                                    case 4:
                                                    case 5:
                                                        // 2010/04/30 <<<
                                                        {
                                                            flg = -1;
                                                            break;
                                                        }
                                                }
                                            }   // 2010/04/30 Add
                                            break;
                                        }
                                    case 2: // 数量
                                        {
                                            // 2010/04/30 Add >>>
                                            // 数量＋金額
                                            if (_chartStyle[e.Number - 1] == 4)
                                            {
                                                switch (ix - 1)
                                                {
                                                    case 0:
                                                    case 1:
                                                        {
                                                            flg = -1;
                                                            break;
                                                        }
                                                }
                                            }
                                            // 数量＋回数
                                            else if (_chartStyle[e.Number - 1] == 5)
                                            {
                                                switch (ix - 1)
                                                {
                                                    case 6:
                                                    case 7:
                                                    case 8:
                                                    case 9:
                                                    case 10:
                                                        {
                                                            flg = -1;
                                                            break;
                                                        }
                                                }
                                            }
                                            else
                                            {
                                                // 2010/04/30 Add <<<
                                                switch (ix - 1)
                                                {
                                                    // 2010/04/30 >>>
                                                    //case 0:
                                                    //case 2:
                                                    //case 3:
                                                    //case 5:
                                                    //case 6:
                                                    //case 8:
                                                    //case 10:
                                                    case 0:
                                                    case 1:
                                                    case 6:
                                                    case 7:
                                                    case 8:
                                                    case 9:
                                                    case 10:
                                                        // 2010/04/30 <<<
                                                        {
                                                            flg = -1;
                                                            break;
                                                        }
                                                }
                                            }   // 2010/04/30 Add
                                            break;
                                        }
                                    case 3: // 回数
                                        {
                                            // 2010/04/30 Add >>>
                                            // 回数＋数量
                                            if (_chartStyle[e.Number - 1] == 4)
                                            {
                                                switch (ix - 1)
                                                {
                                                    case 6:
                                                    case 7:
                                                    case 8:
                                                    case 9:
                                                    case 10:
                                                        {
                                                            flg = -1;
                                                            break;
                                                        }
                                                }
                                            }
                                            // 回数＋金額
                                            else if (_chartStyle[e.Number - 1] == 5)
                                            {
                                                switch (ix - 1)
                                                {
                                                    case 2:
                                                    case 3:
                                                    case 4:
                                                    case 5:
                                                        {
                                                            flg = -1;
                                                            break;
                                                        }
                                                }
                                            }
                                            // 2010/04/30 Add <<<
                                            switch (ix - 1)
                                            {
                                                // 2010/04/30 >>>
                                                //case 1:
                                                //case 2:
                                                //case 4:
                                                //case 5:
                                                //case 6:
                                                //case 7:
                                                //case 8:
                                                //case 9:
                                                //case 10:
                                                case 2:
                                                case 3:
                                                case 4:
                                                case 5:
                                                case 6:
                                                case 7:
                                                case 8:
                                                case 9:
                                                case 10:
                                                    // 2010/04/30 <<<
                                                    {
                                                        flg = -1;
                                                        break;
                                                    }
                                            }
                                            break;
                                        }
                                }
                                break;
                            }
                        }
                    }
                    _singleTypeObj._graphPara.Add(flg);
                }

                // 2010/04/30 Add >>>
                List<int> seriesList = new List<int>();
                seriesList = _seriesList[e.Number - 1];
                for (int i = 0; i < 11; i++)
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
                    result = this.GetChartInfo(this, _singleTypeObj._graphPara, _singleTypeObj._graphPara2, e.Number, out chartInfo, out errorMessage);
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
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMZAI04101UA.programID, errorMessage, result, MessageBoxButtons.OK);
                                return;
                            }
                    }
                    //}
                }
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMZAI04101UA.programID, "条件設定に失敗しました。" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK);
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
        internal void ShowMe(List<StockHistoryDspSearchResult> resultData)
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

            // 在庫年間実績照会チャート
            this._chartDataSet.Tables.Add(TBL_ANNUALDATA_TITLE);
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_TITLE, typeof(string));	// 集計月
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TITLE].DefaultValue = "";
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TITLE].Caption = "集計月";

            // 2010/04/30 Del >>>
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_SALESTIMES, typeof(int));	// 売上回数
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESTIMES].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESTIMES].Caption = "売上回数";

            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_SALESCOUNT, typeof(int));	// 売上数
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESCOUNT].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESCOUNT].Caption = "売上数";

            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_SALESMONEY, typeof(int));	// 売上金額 // DEL 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_SALESMONEY, typeof(double));	// 売上金額 // ADD 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESMONEY].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESMONEY].Caption = "売上金額";

            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_STOCKTIMES, typeof(int));	// 仕入回数
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKTIMES].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKTIMES].Caption = "仕入回数";

            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_STOCKCOUNT, typeof(int));	// 仕入数
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKCOUNT].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKCOUNT].Caption = "仕入数";

            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_STOCKMONEY, typeof(int));	// 仕入金額 // DEL 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_STOCKMONEY, typeof(double));	// 仕入金額 // ADD 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKMONEY].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKMONEY].Caption = "仕入金額";

            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_GRPROFIT, typeof(int)); // 粗利金額 // DEL 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_GRPROFIT, typeof(double)); // 粗利金額 // ADD 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GRPROFIT].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GRPROFIT].Caption = "粗利金額";

            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_MOVEACOUNT, typeof(int)); // 移動入荷数
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEACOUNT].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEACOUNT].Caption = "移動入荷数";

            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_MOVEAPRICE, typeof(int)); // 移動入荷額 // DEL 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_MOVEAPRICE, typeof(double)); // 移動入荷額 // ADD 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEAPRICE].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEAPRICE].Caption = "移動入荷額";

            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_MOVESCOUNT, typeof(int)); // 移動出荷数
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESCOUNT].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESCOUNT].Caption = "移動出荷数";

            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_MOVESPRICE, typeof(int)); // 移動出荷額 // DEL 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_MOVESPRICE, typeof(double)); // 移動出荷額 // ADD 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESPRICE].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESPRICE].Caption = "移動出荷額";
            // 2010/04/30 Del <<<
            // 2010/04/30 Add >>>
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_SALESTIMES, typeof(int));	// 売上回数
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESTIMES].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESTIMES].Caption = "売上回数";

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_STOCKTIMES, typeof(int));	// 仕入回数
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKTIMES].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKTIMES].Caption = "仕入回数";

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_SALESCOUNT, typeof(int));	// 売上数
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESCOUNT].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESCOUNT].Caption = "売上数";

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_STOCKCOUNT, typeof(int));	// 仕入数
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKCOUNT].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKCOUNT].Caption = "仕入数";

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_MOVEACOUNT, typeof(int)); // 移動入荷数
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEACOUNT].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEACOUNT].Caption = "移動入荷数";

            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_SALESMONEY, typeof(int));	// 売上金額 // DEL 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_MOVESCOUNT, typeof(int)); // 移動出荷数
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESCOUNT].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESCOUNT].Caption = "移動出荷数";

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_SALESMONEY, typeof(double));	// 売上金額 // ADD 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESMONEY].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESMONEY].Caption = "売上金額";

            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_STOCKMONEY, typeof(int));	// 仕入金額 // DEL 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_STOCKMONEY, typeof(double));	// 仕入金額 // ADD 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKMONEY].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKMONEY].Caption = "仕入金額";

            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_GRPROFIT, typeof(int)); // 粗利金額 // DEL 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_GRPROFIT, typeof(double)); // 粗利金額 // ADD 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GRPROFIT].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GRPROFIT].Caption = "粗利金額";

            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_MOVEAPRICE, typeof(int)); // 移動入荷額 // DEL 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_MOVEAPRICE, typeof(double)); // 移動入荷額 // ADD 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEAPRICE].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEAPRICE].Caption = "移動入荷額";

            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_MOVESPRICE, typeof(int)); // 移動出荷額 // DEL 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_MOVESPRICE, typeof(double)); // 移動出荷額 // ADD 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESPRICE].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESPRICE].Caption = "移動出荷額";
            // 2010/04/30 Add <<<

        }
        #endregion

    }
}