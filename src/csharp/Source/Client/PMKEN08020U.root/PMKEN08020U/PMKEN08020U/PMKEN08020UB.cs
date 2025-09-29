using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Library.Globarization;// ADD 譚洪  2019/01/08 FOR 新元号の対応

namespace Broadleaf.Library.Windows.Forms
{

    /// <summary>
    /// 型式選択ガイド
    /// </summary>
    /// <remarks>
    /// <br>Note       : 型式選択画面です。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br>----------------------------------------------------------------------------------</br>
    /// <br>Update Note: 車台番号⇒車台番号、車台番号（検索用）に修正</br>
    /// <br>Programmer : 21024 佐々木 健</br>
    /// <br>Date       : 2009.01.28</br>    
    /// <br>----------------------------------------------------------------------------------</br>
    /// <br>Update Note: MANTIS[0013545] 諸元グリッドから、Enterを２回押すと落ちる現象の修正</br>
    /// <br>Programmer : 21024 佐々木 健</br>
    /// <br>Date       : 2009.05.18</br>    
    /// <br>----------------------------------------------------------------------------------</br>
    /// <br>Update Note: MANTIS[0014519] フル型式固定番号がゼロのデータが正常に表示されない件の修正</br>
    /// <br>Programmer : 21024 佐々木 健</br>
    /// <br>Date       : 2009/10/30</br>    
    /// <br>----------------------------------------------------------------------------------</br>
    /// <br>Update Note: 車台番号開始・終了が非表示のデータで、入力車台番号が範囲外の場合にエラーにしないように修正(MANTIS[0013542])</br>
    /// <br>             車台番号、年式で入力エラー時、入力前の値に戻すように修正(MANTIS[0013548])</br>
    /// <br>Programmer : 21024 佐々木 健</br>
    /// <br>Date       : 2009/11/17</br>    
    /// <br>----------------------------------------------------------------------------------</br>
    /// <br>Update Note: 自由検索オプション対応</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2010/05/11</br>    
    /// <br>----------------------------------------------------------------------------------</br>
    /// <br>Update Note: 自由検索部品マスメンでの車輌検索に関連して変更</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2010/06/01</br>    
    /// <br>----------------------------------------------------------------------------------</br>
    /// <br>Update Note: 無効な年式の例外処理対応</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2010/06/04</br>    
    /// <br>----------------------------------------------------------------------------------</br>
    /// <br>Update Note: 無効な年式の例外処理を対応</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2010/07/05</br>    
    /// <br>----------------------------------------------------------------------------------</br>
    /// <br>Update Note: 車台番号（開始）が表示されない不具合の修正(MANTIS[0016415])</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2010/10/18</br>    
    /// <br>----------------------------------------------------------------------------------</br>
    /// <br>Update Note: 車台番号や年式を起動元から指定できるように修正</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2011/03/08</br>    
    /// <br>----------------------------------------------------------------------------------</br>
    /// <br>Update Note: redmine#8380 型式選択ウィンドウ画面にメッセージを表示</br>
    /// <br>Programmer : 葛中華</br>
    /// <br>Date       : 2011/12/02</br>  
    /// <br>----------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2017/01/22　王飛</br>
    /// <br>管理番号   : 11270046-00 車輌検索改良</br>
    /// <br>             Redmine#48967 車台番号初期フォーカス対応障害対応</br>
    /// <br>----------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2019/01/08　譚洪</br>
    /// <br>管理番号   : 11470076-00 新元号の対応</br>
    /// <br>----------------------------------------------------------------------------------</br>
    /// </remarks>
    internal partial class SelectionForm : Form
    {
        #region [ メンバー変数定義 ]
        private PMKEN01010E _orgDataSet = null;
        private PMKEN01010E.CarModelInfoDataTable _carModelTable = null;
        private PMKEN01010E.CtgyMdlLnkInfoDataTable _ctgyMdlLnkTable = null;
        private CarModelRel _carModelRel = null;
        private PMKEN01010E.CarModelInfoDataTable carModelInfoSum = new PMKEN01010E.CarModelInfoDataTable();
        private PMKEN01010E.CarModelInfoDataTable carModelInfoSumOrg;

        private bool _initialize = true;
        private bool isConditionInputState = false;
        private bool isSelectChangeDisabled = false;
        /// <summary>true：型式リスト false：同一型式表示</summary>        
        private bool isCarModelListDisplay = true;
        private bool BLCompoBugTaisaku = false;
        private bool isAllSelected = false;
        private bool eraNameDispDiv = false; // false:西暦　true:和暦

        private DateTimeFormatInfo dtfi;
        private string rowNoInput = string.Empty;
        private Dictionary<RowFilterKind, string> rowFilterList = new Dictionary<RowFilterKind, string>(18);
        private readonly string ColPartsEx = "PartsExistence";
        private readonly string ColEdTypeOfYear = "EdTypeOfYear";
        private readonly string ColEdFrameNo = "EdFrameNo";
        // --- ADD m.suzuki 2010/06/04 ---------->>>>>
        private readonly string ColStTypeOfYear = "StTypeOfYear";
        private readonly string ColStFrameNo = "StFrameNo";
        // --- ADD m.suzuki 2010/06/04 ----------<<<<<
        private List<string> colToShow;
        private Infragistics.Win.Appearance appearanceChildBand = new Infragistics.Win.Appearance();
        private readonly int conditionCellCount = 15;
        private const string MESSAGE_STATUSBAR = "行№、又はカーソルで選択しENTERを押下して下さい";  // ADD 2011/12/02 gezh redmine#8380
        private Dictionary<string, RowFilterKind> lstEnum = new Dictionary<string, RowFilterKind>(18);

        // 2009/11/17 Add >>>
        private int _dtProduceTypeOfYear = 0;
        private string _txtFrameNo = string.Empty;
        // 2009/11/17 Add <<<

        private Thread initDataThread;
        // --- ADD m.suzuki 2010/05/11 ---------->>>>>
        private bool _freeSearchModelOnly; // 自由検索型式のみ抽出区分
        // --- ADD m.suzuki 2010/05/11 ----------<<<<<

        // 2011/03/08 Add >>>
        /// <summary>入力年式</summary>
        private int _inputProduceTypeOfYear;
        /// <summary>入力車台番号</summary>
        private int _inputSearchFrameNo;
        // 2011/03/08 Add <<<

        #endregion

        #region プロパティ
        // 2011/03/08 Add >>>
        /// <summary>入力年式</summary>
        internal int InputProduceTypeOfYear
        {
            get { return _inputProduceTypeOfYear; }
            set { _inputProduceTypeOfYear = value; }
        }

        /// <summary>入力車台番号</summary>
        public int InputSearchFrameNo
        {
            get { return _inputSearchFrameNo; }
            set { _inputSearchFrameNo = value; }
        }
        // 2011/03/08 Add <<<

        //----- ADD 2017/01/22 王飛 Redmine#48967 ----->>>>>
        /// <summary> 設定画面クラス </summary>
        private PMKEN08020UF ModelSelectionSetting;
        //----- ADD 2017/01/22 王飛 Redmine#48967 -----<<<<<

        #endregion

        #region [ コンストラクタ／初期設定処理 ]
        /// <summary>
        /// 選択画面コンストラクタ
        /// </summary>
        /// <param name="dsCar"></param>
        /// <remarks>
        /// <br>Update Note: 2017/01/22 王飛</br>
        /// <br>管理番号   : 11270046-00 車輌検索改良</br>
        /// <br>             Redmine#48967 車台番号初期フォーカス対応障害対応</br>
        /// </remarks>
        public SelectionForm(PMKEN01010E dsCar)
        {
            _initialize = true;
            _orgDataSet = dsCar;
            //----- ADD 2017/01/22 王飛 Redmine#48967 ----->>>>>
            this.ModelSelectionSetting = new PMKEN08020UF();
            this.ModelSelectionSetting.Deserialize();
            //----- ADD 2017/01/22 王飛 Redmine#48967 -----<<<<<
            eraNameDispDiv = Convert.ToBoolean(dsCar.CarSearchCondition.EraNameDispCd1); // 0:西暦／1:和暦
            if (eraNameDispDiv) // 和暦表示の場合
            {
                dtfi = new CultureInfo("ja-JP").DateTimeFormat;
                dtfi.Calendar = new JapaneseCalendar();
            }

            _carModelTable = dsCar.CarModelInfo;
            _ctgyMdlLnkTable = dsCar.CtgyMdlLnkInfo;

            // --- ADD m.suzuki 2010/05/11 ---------->>>>>
            _freeSearchModelOnly = dsCar.CarSearchCondition.FreeSearchModelOnly; // true:自由検索型式のみ
            // --- ADD m.suzuki 2010/05/11 ----------<<<<<

            initDataThread = new Thread(InitializeData);
            initDataThread.Start();

            InitializeComponent();
            if (eraNameDispDiv) // 和暦表示か
            {
                dtProduceTypeOfYear.DateFormat = emDateFormat.dfG2Y2M;
                Point p = new Point(labelYear.Location.X + 22, labelYear.Location.Y);
                labelYear.Location = p;
                Size p2 = new Size(labelYear.Size.Width - 22, labelYear.Size.Height);
                labelYear.Size = p2;
            }
            InitializeForm();
            DisplaySummaryData();
            InitForShowDialog();
            isSelectChangeDisabled = true;
        }

        private void InitForShowDialog()
        {
            while (initDataThread.ThreadState == ThreadState.Running)
            {
                Thread.Sleep(10);
            }
            //InitializeComponentCustom();
            InitializeTable();
            RefreshDataCount(); // 以前のDisplaySummaryData処理時はデータカウンタを正しく更新するデータがないため、ここでもう一度処理する
            MakeConditionGridData();
            //InitializeData();
            if (gridCarModel.DisplayLayout.MaxRowScrollRegions < gridCarModel.Rows.VisibleRowCount)
            {
                gridCondition.DisplayLayout.Scrollbars = Scrollbars.Vertical;
            }
            else
            {
                gridCondition.DisplayLayout.Scrollbars = Scrollbars.None;
            }
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Update Note: 2017/01/22 王飛</br>
        /// <br>管理番号   : 11270046-00 車輌検索改良</br>
        /// <br>             Redmine#48967 車台番号初期フォーカス対応障害対応</br>
        /// </remarks>
        private void InitializeForm()
        {

            this.label_CarCode.Text = String.Format("{0:d3}-{1:d3}-{2:d3}",
                _carModelTable[0].MakerCode, _carModelTable[0].ModelCode, _carModelTable[0].ModelSubCode);
            //this.label_CarName.Text = _carModelTable[0].ModelFullName;
            this.label_CarName.Items.Add(_carModelTable[0].ModelFullName);

            // ステータスバーの初期化
            //StatusBar.Panels[0].Text = "";  // DEL 2011/12/02 gezh redmine#8380
            StatusBar.Panels[0].Text = MESSAGE_STATUSBAR;  // ADD 2011/12/02 gezh redmine#8380
            ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
            ToolbarsManager.Tools["Button_Select"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            ToolbarsManager.Tools["Button_SelectAll"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLSELECT;
            ToolbarsManager.Tools["Button_Back"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            ToolbarsManager.Tools["Button_ChangeDisplay"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.INDICATIONCHANGE;
            ToolbarsManager.Tools["Button_Clear"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;
#if CATEGORY_SECURITY_OK
            ToolbarsManager.Tools["Button_Category"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CAR;
            ToolbarsManager.Tools["Button_Category"].SharedProps.Enabled = false;
#else
            ToolbarsManager.Tools["Button_Category"].SharedProps.Visible = false;
#endif
            ToolbarsManager.Tools["Button_Clear"].SharedProps.Visible = false;

            //----- DEL 2017/01/22 王飛 Redmine#48967 ----->>>>>
            //if (carModelInfoSum[0].StProduceFrameNo == 0 && carModelInfoSum[0].EdProduceFrameNo == 0
            //    && _orgDataSet.PrdTypYearInfo.Count == 0)
            //{
            //    txtFrameNo.Enabled = false;
            //}
            //----- DEL 2017/01/22 王飛 Redmine#48967 -----<<<<<

            // --- ADD m.suzuki 2010/05/11 ---------->>>>>
            // 自由検索型式のみのモードの時は、全選択不可にする
            ToolbarsManager.Tools["Button_SelectAll"].SharedProps.Enabled = !_freeSearchModelOnly;
            // --- ADD m.suzuki 2010/05/11 ----------<<<<<
        }

        private void InitializeTable()
        {
            SetFilteringList();
            // ツールバーのイメージ(16x16)やメッセージを設定
            //ToolbarsManager.Enabled = false;  // データの読み込みが完了するまで使用不可

            gridCarModel.BeginUpdate();
            gridCarModel.DataSource = _carModelTable.DefaultView;

            UltraGridColumn col = gridCarModel.DisplayLayout.Bands[0].Columns.Add(ColEdTypeOfYear, "生産年式(終了)");
            col.DataType = typeof(string);
            col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            col = gridCarModel.DisplayLayout.Bands[0].Columns.Add(ColEdFrameNo, "車台番号(終了)");
            col.DataType = typeof(string);
            // --- ADD m.suzuki 2010/06/04 ---------->>>>>
            col = gridCarModel.DisplayLayout.Bands[0].Columns.Add( ColStTypeOfYear, "生産年式(開始)" );
            col.DataType = typeof( string );
            col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            col = gridCarModel.DisplayLayout.Bands[0].Columns.Add( ColStFrameNo, "車台番号(開始)" );
            col.DataType = typeof( string );
            // --- ADD m.suzuki 2010/06/04 ----------<<<<<
            col = gridCarModel.DisplayLayout.Bands[0].Columns.Add(ColPartsEx, "部品収録");
            // --- UPD m.suzuki 2010/05/11 ---------->>>>>
            //col.DataType = typeof(Image);
            col.DataType = typeof( object );
            // --- UPD m.suzuki 2010/05/11 ----------<<<<<

            gridCarModel.EndUpdate();
            colToShow = new List<string>(new string[]{ 
                _carModelTable.FullModelColumn.ColumnName,               // 0
                // --- UPD m.suzuki 2010/06/04 ---------->>>>>
                //_carModelTable.StProduceTypeOfYearColumn.ColumnName,     // 1
                ColStTypeOfYear,     // 1
                // --- UPD m.suzuki 2010/06/04 ----------<<<<<
                ColEdTypeOfYear,                                         // 2
                //_carModelTable.EdProduceTypeOfYearColumn.ColumnName,     // 2
                // --- UPD m.suzuki 2010/06/04 ---------->>>>>
                //_carModelTable.StProduceFrameNoColumn.ColumnName,        // 3
                ColStFrameNo,        // 3
                // --- UPD m.suzuki 2010/06/04 ----------<<<<<
                ColEdFrameNo,                                            // 4
                //_carModelTable.EdProduceFrameNoColumn.ColumnName,        // 4
                _carModelTable.ModelGradeNmColumn.ColumnName,            // 5
                _carModelTable.BodyNameColumn.ColumnName,                // 6
                _carModelTable.DoorCountColumn.ColumnName,               // 7
                _carModelTable.EngineModelNmColumn.ColumnName,           // 8
                _carModelTable.EngineDisplaceNmColumn.ColumnName,        // 9
                _carModelTable.EDivNmColumn.ColumnName,                  // 10
                _carModelTable.TransmissionNmColumn.ColumnName,          // 11
                _carModelTable.ShiftNmColumn.ColumnName,                 // 12
                _carModelTable.AddiCarSpec1Column.ColumnName,            // 13
                _carModelTable.AddiCarSpec2Column.ColumnName,            // 14
                _carModelTable.AddiCarSpec3Column.ColumnName,            // 15
                _carModelTable.AddiCarSpec4Column.ColumnName,            // 16
                _carModelTable.AddiCarSpec5Column.ColumnName,            // 17
                _carModelTable.AddiCarSpec6Column.ColumnName,            // 18
                _carModelTable.WheelDriveMethodNmColumn.ColumnName,      // 19
                ColPartsEx                                               // 20
            });

            // テーブルレイアウト用設定
            rowAppearance1 = new Infragistics.Win.Appearance();
            rowAppearance2 = new Infragistics.Win.Appearance();
            rowAppearance1.BackColor = System.Drawing.Color.Lavender;
            rowAppearance2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));

            appearanceChildBand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(159)))), ((int)(((byte)(225)))));
            appearanceChildBand.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            appearanceChildBand.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearanceChildBand.ForeColor = System.Drawing.Color.White;
            appearanceChildBand.BackGradientStyle = Infragistics.Win.GradientStyle.None;

            SetGridLayoutAsList();
            RefreshGridData();
        }

        /// <summary>
        /// 画面切替用データを用意しておく
        /// </summary>
        private void InitializeData()
        {
            MakeSummaryData(false);
            carModelInfoSumOrg = new PMKEN01010E.CarModelInfoDataTable();
            carModelInfoSumOrg.Merge(carModelInfoSum, false, MissingSchemaAction.Ignore);

            _carModelRel = new CarModelRel();
            Image img = IconResourceManagement.ImageList16.Images[(int)Size16_Index.INTERRUPTION];
            //if (eraNameDispDiv)
            //{
            //    for (int i = 0; i < _carModelTable.Rows.Count; i++)
            //    {
            //        _carModelTable[i].StProduceYear = GetDtFromInt(_carModelTable[i].StProduceTypeOfYear);
            //        _carModelTable[i].EdProduceYear = GetDtFromInt(_carModelTable[i].EdProduceTypeOfYear);
            //    }
            //}
            // --- UPD m.suzuki 2010/06/01 ---------->>>>>
            //for (int i = 0; i < _carModelTable.Rows.Count; i++)
            for ( int i = 0; i < _carModelTable.DefaultView.Count; i++ )
            // --- UPD m.suzuki 2010/06/01 ----------<<<<<
            {
                // --- UPD m.suzuki 2010/06/01 ---------->>>>>
                //PMKEN01010E.CarModelInfoRow carModelRow = _carModelTable[i];
                PMKEN01010E.CarModelInfoRow carModelRow = (PMKEN01010E.CarModelInfoRow)_carModelTable.DefaultView[i].Row;
                // --- UPD m.suzuki 2010/06/01 ----------<<<<<
                if (eraNameDispDiv)
                {
                    carModelRow.StProduceYear = GetDtFromInt(carModelRow.StProduceTypeOfYear);
                    carModelRow.EdProduceYear = GetDtFromInt(carModelRow.EdProduceTypeOfYear);
                }

                //string select = string.Format("FullModel = {0}", carModelRow.FullModel);
                //CarModelRel.CarModelHdRow[] hdRowRet = (CarModelRel.CarModelHdRow[])_carModelRel.CarModelHd.Select(select);
                // --- UPD m.suzuki 2010/05/11 ---------->>>>>
                //CarModelRel.CarModelHdRow hdRowRet = _carModelRel.CarModelHd.FindByFullModel(carModelRow.FullModel);

                // 同一フル型式でも自由検索型式とそれ以外は分ける
                CarModelRel.CarModelHdRow hdRowRet = _carModelRel.CarModelHd.FindByFullModelFreeSearchSortDiv( carModelRow.FullModel, carModelRow.FreeSearchSortDiv );
                // --- UPD m.suzuki 2010/05/11 ----------<<<<<

                if (hdRowRet != null) // ヘッダが既に登録されているので明細だけ登録
                {
                    CarModelRel.CarModelDtRow row = _carModelRel.CarModelDt.AddCarModelDtRow(
                        carModelRow.ModelGradeNm, carModelRow.BodyName, carModelRow.DoorCount,
                        carModelRow.EngineModelNm, carModelRow.EngineDisplaceNm, carModelRow.EDivNm,
                        carModelRow.TransmissionNm, carModelRow.ShiftNm, carModelRow.WheelDriveMethodNm,
                        carModelRow.AddiCarSpec1, carModelRow.AddiCarSpec2, carModelRow.AddiCarSpec3,
                        carModelRow.AddiCarSpec4, carModelRow.AddiCarSpec5, carModelRow.AddiCarSpec6,
                        carModelRow.AddiCarSpecTitle1, carModelRow.AddiCarSpecTitle2, carModelRow.AddiCarSpecTitle3,
                        carModelRow.AddiCarSpecTitle4, carModelRow.AddiCarSpecTitle5, carModelRow.AddiCarSpecTitle6,
                        // --- ADD m.suzuki 2010/05/11 ---------->>>>>
                        carModelRow.FreeSrchMdlFxdNo,carModelRow.FreeSearchSortDiv,
                        // --- ADD m.suzuki 2010/05/11 ----------<<<<<
                        hdRowRet);
                    if (carModelRow.PartsDataOfferFlag == 0)
                    {
                        row.PartsOfferFlag = img;
                    }
                    if (hdRowRet.StProduceTypeOfYear > carModelRow.StProduceTypeOfYear)    // 開始生産年式
                        hdRowRet.StProduceTypeOfYear = carModelRow.StProduceTypeOfYear;
                    if (hdRowRet.EdProduceTypeOfYear < carModelRow.EdProduceTypeOfYear)    // 終了生産年式
                        hdRowRet.EdProduceTypeOfYear = carModelRow.EdProduceTypeOfYear;
                    if (hdRowRet.StProduceFrameNo > carModelRow.StProduceFrameNo)          // 開始車台番号
                        hdRowRet.StProduceFrameNo = carModelRow.StProduceFrameNo;
                    if (hdRowRet.EdProduceFrameNo < carModelRow.EdProduceFrameNo)          // 終了車台番号
                        hdRowRet.EdProduceFrameNo = carModelRow.EdProduceFrameNo;
                }
                else // 新規登録
                {
                    // --- UPD m.suzuki 2010/05/11 ---------->>>>>
                    //CarModelRel.CarModelHdRow hdRow = _carModelRel.CarModelHd.AddCarModelHdRow(
                    //    carModelRow.StProduceTypeOfYear, carModelRow.EdProduceTypeOfYear, carModelRow.StProduceYear, carModelRow.EdProduceYear,
                    //    carModelRow.StProduceFrameNo, carModelRow.EdProduceFrameNo, carModelRow.FullModel);
                    CarModelRel.CarModelHdRow hdRow = _carModelRel.CarModelHd.AddCarModelHdRow(
                        carModelRow.StProduceTypeOfYear, carModelRow.EdProduceTypeOfYear, carModelRow.StProduceYear, carModelRow.EdProduceYear,
                        carModelRow.StProduceFrameNo, carModelRow.EdProduceFrameNo, carModelRow.FullModel, 
                        carModelRow.FreeSearchSortDiv );
                    // --- UPD m.suzuki 2010/05/11 ----------<<<<<
                    CarModelRel.CarModelDtRow row = _carModelRel.CarModelDt.AddCarModelDtRow(
                        carModelRow.ModelGradeNm, carModelRow.BodyName, carModelRow.DoorCount,
                        carModelRow.EngineModelNm, carModelRow.EngineDisplaceNm, carModelRow.EDivNm,
                        carModelRow.TransmissionNm, carModelRow.ShiftNm, carModelRow.WheelDriveMethodNm,
                        carModelRow.AddiCarSpec1, carModelRow.AddiCarSpec2, carModelRow.AddiCarSpec3,
                        carModelRow.AddiCarSpec4, carModelRow.AddiCarSpec5, carModelRow.AddiCarSpec6,
                        carModelRow.AddiCarSpecTitle1, carModelRow.AddiCarSpecTitle2, carModelRow.AddiCarSpecTitle3,
                        carModelRow.AddiCarSpecTitle4, carModelRow.AddiCarSpecTitle5, carModelRow.AddiCarSpecTitle6,
                        // --- ADD m.suzuki 2010/05/11 ---------->>>>>
                        carModelRow.FreeSrchMdlFxdNo, carModelRow.FreeSearchSortDiv,
                        // --- ADD m.suzuki 2010/05/11 ----------<<<<<
                        hdRow);
                    if (carModelRow.PartsDataOfferFlag == 0)
                    {
                        row.PartsOfferFlag = img;
                    }
                }
            }
            // --- UPD m.suzuki 2010/05/11 ---------->>>>>
            //string sort = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", _carModelTable.FullModelColumn.ColumnName,
            //    _carModelTable.ModelGradeNmColumn.ColumnName, _carModelTable.BodyNameColumn.ColumnName,
            //    _carModelTable.DoorCountColumn.ColumnName, _carModelTable.EngineModelNmColumn.ColumnName,
            //    _carModelTable.EngineDisplaceNmColumn.ColumnName, _carModelTable.EDivNmColumn.ColumnName,
            //    _carModelTable.TransmissionNmColumn.ColumnName, _carModelTable.ShiftNmColumn.ColumnName,
            //    _carModelTable.WheelDriveMethodNmColumn.ColumnName);
            string sort = string.Format( "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", 
                _carModelTable.FreeSearchSortDivColumn.ColumnName,
                _carModelTable.FullModelColumn.ColumnName,
                _carModelTable.ModelGradeNmColumn.ColumnName, _carModelTable.BodyNameColumn.ColumnName,
                _carModelTable.DoorCountColumn.ColumnName, _carModelTable.EngineModelNmColumn.ColumnName,
                _carModelTable.EngineDisplaceNmColumn.ColumnName, _carModelTable.EDivNmColumn.ColumnName,
                _carModelTable.TransmissionNmColumn.ColumnName, _carModelTable.ShiftNmColumn.ColumnName,
                _carModelTable.WheelDriveMethodNmColumn.ColumnName );
            // --- UPD m.suzuki 2010/05/11 ----------<<<<<
            _carModelTable.DefaultView.Sort = sort;
            // --- UPD m.suzuki 2010/05/11 ---------->>>>>
            //_carModelRel.CarModelHd.DefaultView.Sort = _carModelRel.CarModelHd.FullModelColumn.ColumnName;
            _carModelRel.CarModelHd.DefaultView.Sort = string.Format( "{0},{1}",
                _carModelRel.CarModelHd.FreeSearchSortDivColumn.ColumnName,
                _carModelRel.CarModelHd.FullModelColumn.ColumnName );
            // --- UPD m.suzuki 2010/05/11 ----------<<<<<
        }

        private DateTime GetDtFromInt(int dt)
        {
            if (dt <= 101)
                return DateTime.MinValue;
            if (dt > 220000)
                return DateTime.MaxValue;
            return new DateTime(dt / 100, dt % 100, 1);
        }

        /// <summary>
        /// 設定画面に初期フォーカスを車台番号に設定するかどうかの判断
        /// </summary>
        /// <returns>True：初期フォーカスが車台番号 False：車種名称</returns>
        /// <remarks>
        /// <br>Note       : 設定画面に初期フォーカスを車台番号に設定するかどうかの判断を行います。</br>
        /// <br>Programmer : 王飛</br>
        /// <br>Date       : 2017/01/22</br>
        /// <br>管理番号   : 11270046-00 車輌検索改良</br>
        /// </remarks>
        private bool IsInitFoucsOnFrameNo()
        {
            //初期フォーカス:車台番号
            return (this.ModelSelectionSetting != null && this.ModelSelectionSetting.SettingItemInfo != null
                && this.ModelSelectionSetting.SettingItemInfo.FocusPositionDiv == 1);
        }

        /// <summary>
        /// 設定画面に絞込条件からのEnter動作区分を全選択に設定するかどうかの判断
        /// </summary>
        /// <returns>True：全選択 False：次項目へ遷移</returns>
        /// <remarks>
        /// <br>Note       : 設定画面に絞込条件からのEnter動作区分を全選択に設定するかどうかの判断を行います。</br>
        /// <br>Programmer : 王飛</br>
        /// <br>Date       : 2017/01/22</br>
        /// <br>管理番号   : 11270046-00 車輌検索改良</br>
        /// </remarks>
        private bool IsInitOnAllSelect()
        {
            //Enter動作区分を全選択に設定するかどうかの判断
            return (this.ModelSelectionSetting != null && this.ModelSelectionSetting.SettingItemInfo != null
                && this.ModelSelectionSetting.SettingItemInfo.EnterActionDiv == 1);
        }

        #endregion

        #region [ グリッドレイアウト設定メソッド ]
        /// <summary>
        /// グリッドのレイアウト初期化 
        /// </summary>
        private void SetGridLayoutAsList()
        {
            gridCarModel.DisplayLayout.ViewStyle = ViewStyle.MultiBand;
            // 列幅の自動調整方法
            gridCarModel.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            gridCarModel.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            gridCarModel.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // バンドの取得
            UltraGridBand band = gridCarModel.DisplayLayout.Bands[0];
            band.Override.RowSizing = RowSizing.Fixed;
            band.Override.AllowColSizing = AllowColSizing.None;
            band.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            band.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.SeparateElement;
            band.Override.RowAppearance = rowAppearance2;
            band.Override.RowAlternateAppearance = rowAppearance1;

            // 上記コラム以外は非表示とする。
            foreach (UltraGridColumn col in band.Columns)
            {
                if (colToShow.Contains(col.Key) == false)
                {
                    col.Hidden = true;
                }
            }
            band.Columns[ColPartsEx].Hidden = false;
            band.Columns[ColPartsEx].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;

            band.UseRowLayout = true;

            for (int Index = 0; Index < band.Columns.Count; Index++)
            {
                if (band.Columns[Index].Hidden)
                {
                    continue;
                }
                // 水平表示位置
                if (band.Columns[Index].DataType == typeof(int))
                {
                    band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else
                {
                    band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }

                // 垂直表示位置
                band.Columns[Index].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }
            band.Columns[colToShow[1]].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;// StProduceTypeOfYear
            band.Columns[colToShow[2]].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;// EdProduceTypeOfYear
            band.Columns[colToShow[3]].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;   // 2010/10/18 Add
            band.Columns[colToShow[4]].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;// EdProduceFrameNo
            //追加諸元の表示設定（先頭が表示の場合全て表示する）
            SetAddCarSpecColumn(band);

            //１コマ３０で構成する。
            // 上段
            ColInfo.SetColInfo(band, colToShow[0], 2, 0, 6, 2, 180);    // FullModel
            //ColInfo.SetColInfo(band, colToShow[1], 8, 0, 6, 2, 180);    // StProduceTypeOfYear
            // --- UPD m.suzuki 2010/06/04 ---------->>>>>
            //if (eraNameDispDiv) // 和暦表示か
            //{
            //    band.Columns[_carModelTable.StProduceTypeOfYearColumn.ColumnName].Hidden = true;
            //    band.Columns[_carModelTable.StProduceYearColumn.ColumnName].Hidden = false;
            //    band.Columns[_carModelTable.EdProduceYearColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //    ColInfo.SetColInfo(band, _carModelTable.StProduceYearColumn.ColumnName, 8, 0, 6, 2, 180);    // StProduceTypeOfYear
            //    band.Columns[_carModelTable.StProduceYearColumn.ColumnName].Format = "gg yy年 MM月";
            //    band.Columns[_carModelTable.StProduceYearColumn.ColumnName].FormatInfo = dtfi;
            //}
            //else // 西暦表示か
            //{
            //    band.Columns[_carModelTable.StProduceYearColumn.ColumnName].Hidden = true;
            //    ColInfo.SetColInfo(band, colToShow[1], 8, 0, 6, 2, 180);    // StProduceTypeOfYear
            //}
            ColInfo.SetColInfo( band, colToShow[1], 8, 0, 6, 2, 180 );    // StProduceTypeOfYear
            // --- UPD m.suzuki 2010/06/04 ----------<<<<<
            ColInfo.SetColInfo(band, colToShow[2], 14, 0, 6, 2, 180);   // EdProduceTypeOfYear
            ColInfo.SetColInfo(band, colToShow[3], 20, 0, 6, 2, 180);   // StProduceFrameNo
            ColInfo.SetColInfo(band, colToShow[4], 26, 0, 6, 2, 180);   // EdProduceFrameNo
            // 下段
            ColInfo.SetColInfo(band, colToShow[5], 2, 2, 6, 2, 180);    // ModelGradeNm
            ColInfo.SetColInfo(band, colToShow[6], 8, 2, 3, 2, 90);     // BodyName
            ColInfo.SetColInfo(band, colToShow[7], 11, 2, 3, 2, 90);    // DoorCount
            ColInfo.SetColInfo(band, colToShow[8], 14, 2, 3, 2, 100);   // EngineModelNm
            ColInfo.SetColInfo(band, colToShow[9], 17, 2, 3, 2, 80);    // EngineDisplaceNm
            ColInfo.SetColInfo(band, colToShow[10], 20, 2, 3, 2, 90);   // EDivNm
            ColInfo.SetColInfo(band, colToShow[11], 23, 2, 3, 2, 90);   // TransmissionNm
            ColInfo.SetColInfo(band, colToShow[12], 26, 2, 2, 2, 40);   // ShiftNm
            ColInfo.SetColInfo(band, colToShow[19], 28, 2, 2, 2, 70);   // WheelDriveMethodNm
            ColInfo.SetColInfo(band, ColPartsEx, 30, 2, 2, 2, 70);      // PartsDataOfferFlag

            // 3段
            int originX = 2;
            if (band.Columns[colToShow[13]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[13], originX, 4, 5, 2, 150);   // 追加諸元1
                originX += 5;
            }
            if (band.Columns[colToShow[14]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[14], originX, 4, 5, 2, 150);   // 追加諸元2
                originX += 5;
            }
            if (band.Columns[colToShow[15]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[15], originX, 4, 5, 2, 150);  // 追加諸元3
                originX += 5;
            }
            if (band.Columns[colToShow[16]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[16], originX, 4, 5, 2, 150);  // 追加諸元4
                originX += 5;
            }
            if (band.Columns[colToShow[17]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[17], originX, 4, 5, 2, 150);  // 追加諸元5
                originX += 5;
            }
            if (band.Columns[colToShow[18]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[18], originX, 4, 5, 2, 150);  // 追加諸元6
            }
            gridCarModel.DisplayLayout.Override.DefaultRowHeight = 20;

            // 和暦表示の場合、この行は表示されません。
            band.Columns[colToShow[1]].Format = "####年 ##月";  // StProduceTypeOfYear
            //band.Columns[colToShow[2]].Format = "####年 ##月";  // EdProduceTypeOfYear
            band.Columns[colToShow[3]].Format = "#";   // StProduceFrameNo
            //band.Columns[colToShow[4]].Format = "#";   // EdProduceFrameNo

            // --- ADD m.suzuki 2010/06/04 ---------->>>>>
            band.Columns[colToShow[7]].Format = "#"; // DoorCount
            // --- ADD m.suzuki 2010/06/04 ----------<<<<<
        }

        private void SetGridLayoutAsMultiband()
        {
            gridCarModel.DisplayLayout.ViewStyle = ViewStyle.MultiBand;
            gridCarModel.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            gridCarModel.DisplayLayout.RowConnectorStyle = RowConnectorStyle.None;
            gridCarModel.DisplayLayout.InterBandSpacing = 0;
            UltraGridBand band0 = gridCarModel.DisplayLayout.Bands[0];
            UltraGridBand band1 = gridCarModel.DisplayLayout.Bands[1];
            band0.Indentation = 0;
            band0.Override.RowSizing = RowSizing.Fixed;
            band0.Override.AllowColSizing = AllowColSizing.None;
            band0.Override.ExpansionIndicator = ShowExpansionIndicator.Never;
            band0.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            band0.UseRowLayout = true;
            band0.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.SeparateElement;
            band0.Override.RowAppearance = rowAppearance2;
            band0.Override.RowAlternateAppearance = rowAppearance2;

            band1.Indentation = 0;
            band1.Override.RowSizing = RowSizing.Fixed;
            band1.Override.AllowColSizing = AllowColSizing.None;
            band1.Override.ExpansionIndicator = ShowExpansionIndicator.Never;
            band1.UseRowLayout = true;
            band1.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.SeparateElement;
            band1.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.None;
            band1.Override.SelectTypeRow = SelectType.Extended;
            band1.Override.RowSelectorAppearance = appearanceChildBand;
            band1.Override.BorderStyleRowSelector = Infragistics.Win.UIElementBorderStyle.None;
            band1.Override.RowAppearance = rowAppearance1;
            band1.Override.RowAlternateAppearance = rowAppearance1;

            band1.Columns[_carModelRel.CarModelDt.NoColumn.ColumnName].Hidden = true;
            band1.Columns[_carModelRel.CarModelDt.FullModelColumn.ColumnName].Hidden = true;
            foreach (UltraGridColumn col in band1.Columns)
            {
                if (colToShow.Contains(col.Key) == false)
                {
                    col.Hidden = true;
                }
            }

            for (int Index = 0; Index < band1.Columns.Count; Index++)
            {
                if (band1.Columns[Index].Hidden)
                {
                    continue;
                }
                // 水平表示位置
                if (band1.Columns[Index].DataType == typeof(int))
                {
                    band1.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else
                {
                    band1.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }

                // 垂直表示位置
                band1.Columns[Index].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }

            band0.Columns[ColPartsEx].Hidden = true;
            band1.Columns[ColPartsEx].Hidden = false;
            band1.Columns[ColPartsEx].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
            gridCarModel.Rows.ExpandAll(false);

            //追加諸元の表示設定（先頭が表示の場合全て表示する）
            SetAddCarSpecColumn(band1);

            //１コマ３０で構成する。
            // 上段
            ColInfo.SetColInfo(band0, colToShow[0], 2, 0, 6, 2, 180);    // FullModel
            //ColInfo.SetColInfo(band0, colToShow[1], 8, 0, 6, 2, 180);    // StProduceTypeOfYear
            if (eraNameDispDiv) // 和暦表示か
            {
                band0.Columns[_carModelTable.StProduceTypeOfYearColumn.ColumnName].Hidden = true;
                band0.Columns[_carModelTable.StProduceYearColumn.ColumnName].Hidden = false;
                band0.Columns[_carModelTable.EdProduceYearColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                ColInfo.SetColInfo(band0, _carModelTable.StProduceYearColumn.ColumnName, 8, 0, 6, 2, 180);    // StProduceTypeOfYear
                band0.Columns[_carModelTable.StProduceYearColumn.ColumnName].Format = "gg yy年 MM月";
                band0.Columns[_carModelTable.StProduceYearColumn.ColumnName].FormatInfo = dtfi;
            }
            else // 西暦表示か
            {
                band0.Columns[_carModelTable.StProduceYearColumn.ColumnName].Hidden = true;
                ColInfo.SetColInfo(band0, colToShow[1], 8, 0, 6, 2, 180);    // StProduceTypeOfYear
            }

            ColInfo.SetColInfo(band0, colToShow[2], 14, 0, 6, 2, 180);   // EdProduceTypeOfYear
            ColInfo.SetColInfo(band0, colToShow[3], 20, 0, 6, 2, 180);   // StProduceFrameNo
            ColInfo.SetColInfo(band0, colToShow[4], 26, 0, 6, 2, 180);   // EdProduceFrameNo
            // 下段
            ColInfo.SetColInfo(band1, colToShow[5], 2, 0, 6, 2, 180);    // ModelGradeNm
            ColInfo.SetColInfo(band1, colToShow[6], 8, 0, 3, 2, 90);     // BodyName
            ColInfo.SetColInfo(band1, colToShow[7], 11, 0, 3, 2, 90);    // DoorCount
            ColInfo.SetColInfo(band1, colToShow[8], 14, 0, 3, 2, 100);   // EngineModelNm
            ColInfo.SetColInfo(band1, colToShow[9], 17, 0, 3, 2, 80);    // EngineDisplaceNm
            ColInfo.SetColInfo(band1, colToShow[10], 20, 0, 3, 2, 90);   // EDivNm
            ColInfo.SetColInfo(band1, colToShow[11], 23, 0, 3, 2, 90);   // TransmissionNm
            ColInfo.SetColInfo(band1, colToShow[12], 26, 0, 2, 2, 40);   // ShiftNm
            ColInfo.SetColInfo(band1, colToShow[19], 28, 0, 2, 2, 70);   // WheelDriveMethodNm
            ColInfo.SetColInfo(band1, ColPartsEx, 30, 0, 2, 2, 70);      // PartsDataOfferFlag

            // 3段
            int originX = 2;
            if (band1.Columns[colToShow[13]].Hidden == false)
            {
                ColInfo.SetColInfo(band1, colToShow[13], originX, 2, 5, 2, 150);   // 追加諸元1
                originX += 5;
            }
            if (band1.Columns[colToShow[14]].Hidden == false)
            {
                ColInfo.SetColInfo(band1, colToShow[14], originX, 2, 5, 2, 150);   // 追加諸元2
                originX += 5;
            }
            if (band1.Columns[colToShow[15]].Hidden == false)
            {
                ColInfo.SetColInfo(band1, colToShow[15], originX, 2, 5, 2, 150);  // 追加諸元3
                originX += 5;
            }
            if (band1.Columns[colToShow[16]].Hidden == false)
            {
                ColInfo.SetColInfo(band1, colToShow[16], originX, 2, 5, 2, 150);  // 追加諸元4
                originX += 5;
            }
            if (band1.Columns[colToShow[17]].Hidden == false)
            {
                ColInfo.SetColInfo(band1, colToShow[17], originX, 2, 5, 2, 150);  // 追加諸元5
                originX += 5;
            }
            if (band1.Columns[colToShow[18]].Hidden == false)
            {
                ColInfo.SetColInfo(band1, colToShow[18], originX, 2, 5, 2, 150);  // 追加諸元6
            }
            gridCarModel.DisplayLayout.Override.DefaultRowHeight = 20;

            band0.Columns[colToShow[1]].Format = "####年 ##月";  // StProduceTypeOfYear
            //band0.Columns[colToShow[2]].Format = "####年 ##月";  // EdProduceTypeOfYear
            band0.Columns[colToShow[3]].Format = "#";   // StProduceFrameNo
            //band0.Columns[colToShow[4]].Format = "#";   // EdProduceFrameNo

        }

        private void SetAddCarSpecColumn(UltraGridBand band)
        {
            //追加諸元の表示設定（先頭が表示の場合全て表示する）
            if (_carModelTable[0].AddiCarSpec1 == "")
            {
                band.Columns[colToShow[13]].Hidden = true;
            }
            else
            {
                band.Columns[colToShow[13]].Header.Caption = _carModelTable[0].AddiCarSpecTitle1;
            }
            if (_carModelTable[0].AddiCarSpec2 == "")
            {
                band.Columns[colToShow[14]].Hidden = true;
            }
            else
            {
                band.Columns[colToShow[14]].Header.Caption = _carModelTable[0].AddiCarSpecTitle2;
            }
            if (_carModelTable[0].AddiCarSpec3 == "")
            {
                band.Columns[colToShow[15]].Hidden = true;
            }
            else
            {
                band.Columns[colToShow[15]].Header.Caption = _carModelTable[0].AddiCarSpecTitle3;
            }
            if (_carModelTable[0].AddiCarSpec4 == "")
            {
                band.Columns[colToShow[16]].Hidden = true;
            }
            else
            {
                band.Columns[colToShow[16]].Header.Caption = _carModelTable[0].AddiCarSpecTitle4;
            }
            if (_carModelTable[0].AddiCarSpec5 == "")
            {
                band.Columns[colToShow[17]].Hidden = true;
            }
            else
            {
                band.Columns[colToShow[17]].Header.Caption = _carModelTable[0].AddiCarSpecTitle5;
            }
            if (_carModelTable[0].AddiCarSpec6 == "")
            {
                band.Columns[colToShow[18]].Hidden = true;
            }
            else
            {
                band.Columns[colToShow[18]].Header.Caption = _carModelTable[0].AddiCarSpecTitle6;
            }
        }

        #endregion

        #region [ フォームイベント処理 ]
        /// <summary>
        /// FormClosing イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>不測の事態を避けるため、サブスレッドの実行中は終了できないようにする</br>
        /// </remarks>
        private void SelectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (gridCarModel.Rows.Count == 0 && DialogResult != DialogResult.Cancel)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Text, "絞込により選択されるデータが一件もありません。", 0, MessageBoxButtons.OK);
                e.Cancel = true;
            }
        }

        /// <summary>
        /// FormClosed イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>DialogResultがOKの場合にのみ、グリッド上で選択されている行に関連するDataRowオブジェクトを取得し、</br>
        /// <br>"選択状態"に相当する処理を行います。</br>
        /// </remarks>
        private void SelectionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (isAllSelected)
                {
                    if (isCarModelListDisplay)
                    {
                        for (int index = 0; index < gridCarModel.Rows.Count; index++)
                        {
                            gridCarModel.Rows[index].Cells["SelectionState"].Value = true;
                        }
                    }
                    else
                    {
                        for (int index = 0; index < gridCarModel.Rows.Count; index++)
                        {
                            if (gridCarModel.Rows[index].Band == gridCarModel.DisplayLayout.Bands[0])
                            {
                                string select = string.Format("FullModel = '{0}'",
                                    gridCarModel.Rows[index].Cells[_carModelRel.CarModelHd.FullModelColumn.ColumnName].Value);
                                PMKEN01010E.CarModelInfoRow[] rowToSetSelect = (PMKEN01010E.CarModelInfoRow[])_carModelTable.Select(select);
                                for (int i = 0; i < rowToSetSelect.Length; i++)
                                {
                                    rowToSetSelect[i].SelectionState = true;
                                }
                            }
                        }
                    }
                }
                else
                {
                    SelectedRowsCollection selectedRows;
                    selectedRows = gridCarModel.Selected.Rows;
                    if (isCarModelListDisplay)
                    {
                        for (int index = 0; index < selectedRows.Count; index++)
                        {
                            selectedRows[index].Cells["SelectionState"].Value = true;
                        }
                    }
                    else
                    {
                        for (int index = 0; index < selectedRows.Count; index++)
                        {
                            if (selectedRows[index].Band == gridCarModel.DisplayLayout.Bands[0])
                            {
                                string select = string.Format("FullModel = '{0}'",
                                    selectedRows[index].Cells[_carModelRel.CarModelHd.FullModelColumn.ColumnName].Value);
                                PMKEN01010E.CarModelInfoRow[] rowToSetSelect = (PMKEN01010E.CarModelInfoRow[])_carModelTable.Select(select);
                                for (int i = 0; i < rowToSetSelect.Length; i++)
                                {
                                    rowToSetSelect[i].SelectionState = true;
                                }
                            }
                        }
                    }
                }
            }

            if (_orgDataSet.CarModelUIData.Count > 0)
            {
                if (dtProduceTypeOfYear.LongDate > 0)
                {
                    _orgDataSet.CarModelUIData[0].ProduceTypeOfYearInput =
                        dtProduceTypeOfYear.GetDateYear() * 100 + dtProduceTypeOfYear.GetDateMonth();
                }
                if (txtFrameNo.Text != string.Empty)
                {
                    // 2009.01.28 >>>
                    //_orgDataSet.CarModelUIData[0].ProduceFrameNoInput = Convert.ToInt32(txtFrameNo.Text);
                    _orgDataSet.CarModelUIData[0].FrameNo = txtFrameNo.Text;
                    _orgDataSet.CarModelUIData[0].SearchFrameNo = Convert.ToInt32(txtFrameNo.Text);
                    // 2009.01.28 <<<
                }
            }
            gridCarModel.BeginUpdate();
            try
            {
                gridCarModel.DataSource = null;
            }
            finally
            {
                gridCarModel.EndUpdate();
            }
        }

        /// <summary>
        /// 画面の初期表示
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Update Note: 2017/01/22 王飛</br>
        /// <br>管理番号   : 11270046-00 車輌検索改良</br>
        /// <br>             Redmine#48967 車台番号初期フォーカス対応障害対応</br>
        /// </remarks>
        private void SelectionForm_Shown(object sender, EventArgs e)
        {
            //isSelectChangeDisabled = true;
            ToolbarsManager.Enabled = true;
            //----- UPD 2017/01/22 王飛 Redmine#48967 ----->>>>>
            //label_CarName.Focus();
            // 初期フォーカス設定
            if (IsInitFoucsOnFrameNo())
            {
                txtFrameNo.Focus();
            }
            else
            {
                label_CarName.Focus();
                isConditionInputState = false; // フォームを表示する際デートコントロールからのイベントによりこのフラグがTrueになる
            }
            //----- UPD 2017/01/22 王飛 Redmine#48967 -----<<<<<
            _initialize = false;
            isSelectChangeDisabled = false;
            //isConditionInputState = false; // フォームを表示する際デートコントロールからのイベントによりこのフラグがTrueになる// DEL 2017/01/22 王飛 Redmine#48967

            // 2011/03/08 Add >>>
            if (this._inputSearchFrameNo > 0)
            {
                if (this.TxtFrameNoRangeCheck(this._inputSearchFrameNo) || this._inputProduceTypeOfYear == 0)
                {
                    this.txtFrameNo.Text = this._inputSearchFrameNo.ToString();
                    CancelEventArgs args = new CancelEventArgs();
                    this.txtFrameNo_Validating(this.txtFrameNo, args);
                }
            }
            if (this._inputProduceTypeOfYear > 0)
            {
                this.dtProduceTypeOfYear.SetLongDate(this._inputProduceTypeOfYear * 100);
                CancelEventArgs args = new CancelEventArgs();
                this.dtProduceTypeOfYear_Validating(this.dtProduceTypeOfYear, args);
            }
            // 2011/03/08 Add <<<
        }

        /// <summary>
        /// ツールボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            if (_initialize) return;

            switch (e.Tool.Key)
            {
                case "Button_Select":
                    // 選択されている行を確定する
                    if (gridCarModel.Selected.Rows.Count == 0)
                    {
                        isAllSelected = true;
                        //SelectAll();
                    }
                    DialogResult = DialogResult.OK;
                    break;

                case "Button_SelectAll":
                    // 全ての行を選択して確定する。
                    isAllSelected = true;
                    //SelectAll();
                    DialogResult = DialogResult.OK;
                    break;

                case "Button_Back":
                    // 前の画面に戻る
                    DialogResult = DialogResult.Cancel;
                    break;
#if CATEGORY_SECURITY_OK
                case "Button_Category":
                    // 類別情報表示
                    ShowCategoryDialog();
                    break;
#endif
                case "Button_ChangeDisplay":
                    ChangeDisplay();
                    break;

                case "Button_Clear":
                    ClearCondition();
                    break;

                default:
                    break;
            }
        }
        #endregion

        #region [ 類別表示処理関連 - セキュリティ上、一応不使用とする ]
        // これを生かす時にはPMKEN08130Uの参照も追加すること。
#if CATEGORY_SECURITY_OK
        private void ShowCategoryDialog()
        {
            UltraGridRow activeRow = gridCarModel.ActiveRow;
            if (activeRow != null)
            {
                int fullModelFixedNo;
                if (this.isCarModelListDisplay)
                {
                    fullModelFixedNo = (int)activeRow.Cells[_carModelTable.FullModelFixedNoColumn.ColumnName].Value;
                }
                else
                {
                    string fullModel;
                    if (activeRow.Band == gridCarModel.DisplayLayout.Bands[1])
                    {
                        fullModel = activeRow.ParentRow.Cells[_carModelRel.CarModelHd.FullModelColumn.ColumnName].Value.ToString();
                    }
                    else
                    {
                        fullModel = activeRow.Cells[_carModelTable.FullModelColumn.ColumnName].Value.ToString();
                    }
                    string select = string.Format("FullModel = '{0}'", fullModel);
                    fullModelFixedNo = ((PMKEN01010E.CarModelInfoRow[])_carModelTable.Select(select))[0].FullModelFixedNo;
                    //fullModelFixedNo = ((PMKEN01010E.CarModelInfoRow)_carModelTable.Rows.Find(new object[] { fullModel })).FullModelFixedNo;
                }
                CategoryDataDataTable categoryData = new CategoryDataDataTable();
                PMKEN01010E.CtgyMdlLnkInfoRow[] selRow =
                    (PMKEN01010E.CtgyMdlLnkInfoRow[])_ctgyMdlLnkTable.Select(string.Format("FullModelFixedNo = {0}", fullModelFixedNo));

                for (int i = 0; i < selRow.Length; i++)
                {
                    string categoryModel = String.Format("{0:D5} - {1:D4}", selRow[i][0], selRow[i][1]);
                    string select = string.Format("[Model-Category] = '{0}'", categoryModel);
                    if (categoryData.Select(select).Length == 0) // 固有番号だけ違う同一データが複数存在する場合があるため。
                    {
                        categoryData.AddCategoryDataRow(categoryModel);
                    }
                }

                SelectionCtgyMdlLnk.ShowDialog(categoryData);

            }
        }
#endif
        #endregion

        #region [ データ表示関連処理 ]
        /// <summary>
        /// データ表示関連処理
        /// </summary>
        /// <remarks>
        /// <br>Update Note: 2017/01/22 王飛</br>
        /// <br>管理番号   : 11270046-00 車輌検索改良</br>
        /// <br>             Redmine#48967 車台番号初期フォーカス対応障害対応</br>
        /// </remarks>
        private void ChangeDisplay()
        {
            //gridCarModel.Selected.Rows.Clear();
            //gridCarModel.ActiveRow = null; 
            if (isCarModelListDisplay)  // 型式リスト → 同一型式表示
            {
                gridCarModel.BeginUpdate();
                gridCarModel.DataSource = _carModelRel.CarModelHd.DefaultView;
                gridCarModel.EndUpdate();

                SetGridLayoutAsMultiband();
                isCarModelListDisplay = false;
                GridFiltering();
            }
            else                        // 同一型式表示 → 型式リスト
            {
                gridCarModel.BeginUpdate();
                this.gridCarModel.DataSource = _carModelTable.DefaultView;
                gridCarModel.EndUpdate();

                SetGridLayoutAsList();
                isCarModelListDisplay = true;
                GridFiltering();        //RefreshDataCount();
            }
            //----- UPD 2017/01/22 王飛 Redmine#48967 ----->>>>>
            //label_CarName.Focus();
            // 初期フォーカス設定
            if (IsInitFoucsOnFrameNo())
            {
                txtFrameNo.Focus();
            }
            else
            {
                label_CarName.Focus();
            }
            //----- UPD 2017/01/22 王飛 Redmine#48967 -----<<<<<
            //gridCarModel.Rows[0].Activate();
            //gridCarModel.Rows[0].Selected = true;
        }

        private void MakeConditionGridData()
        {
            List<Infragistics.Win.ValueList> vlist = new List<Infragistics.Win.ValueList>();

            for (int i = 0; i < conditionCellCount; i++)
            {
                vlist.Add(new Infragistics.Win.ValueList());
                vlist[i].ValueListItems.Add("");
            }

            gridCondition.BeginUpdate();

            gridCondition.DisplayLayout.Bands[0].AddNew();

            for (int i = 0; i < conditionCellCount; i++)
            {
                if (i < 9)
                {
                    gridCondition.Rows[0].Cells[i].ValueList = vlist[i];
                }
                else
                {
                    gridCondition.Rows[0].Cells[i + 1].ValueList = vlist[i];
                }
            }
            SetAddCarSpecColumn(gridCondition.DisplayLayout.Bands[0]);

            for (int i = 0; i < _carModelTable.DefaultView.Count; i++)
            {
                PMKEN01010E.CarModelInfoRow rowToComp = (PMKEN01010E.CarModelInfoRow)_carModelTable.DefaultView[i].Row;

                if (vlist[0].FindByDataValue(rowToComp.ModelGradeNm) == null)      // 型式グレード名称
                    vlist[0].ValueListItems.Add(rowToComp.ModelGradeNm);
                if (vlist[1].FindByDataValue(rowToComp.BodyName) == null)          // ボディー名称
                    vlist[1].ValueListItems.Add(rowToComp.BodyName);
                if (vlist[2].FindByDataValue(rowToComp.DoorCount) == null)         // ドア数
                    vlist[2].ValueListItems.Add(rowToComp.DoorCount);
                if (vlist[3].FindByDataValue(rowToComp.EngineModelNm) == null)     // エンジン型式名称
                    vlist[3].ValueListItems.Add(rowToComp.EngineModelNm);
                if (vlist[4].FindByDataValue(rowToComp.EngineDisplaceNm) == null)  // 排気量名称
                    vlist[4].ValueListItems.Add(rowToComp.EngineDisplaceNm);
                if (vlist[5].FindByDataValue(rowToComp.EDivNm) == null)            // E区分名称
                    vlist[5].ValueListItems.Add(rowToComp.EDivNm);
                if (vlist[6].FindByDataValue(rowToComp.TransmissionNm) == null)    // ミッション名称
                    vlist[6].ValueListItems.Add(rowToComp.TransmissionNm);
                if (vlist[7].FindByDataValue(rowToComp.ShiftNm) == null)           // シフト名称
                    vlist[7].ValueListItems.Add(rowToComp.ShiftNm);
                if (vlist[8].FindByDataValue(rowToComp.WheelDriveMethodNm) == null)// 駆動方式名称
                    vlist[8].ValueListItems.Add(rowToComp.WheelDriveMethodNm);
                if (vlist[9].FindByDataValue(rowToComp.AddiCarSpec1) == null)      // 追加諸元1
                    vlist[9].ValueListItems.Add(rowToComp.AddiCarSpec1);
                if (vlist[10].FindByDataValue(rowToComp.AddiCarSpec2) == null)      // 追加諸元2
                    vlist[10].ValueListItems.Add(rowToComp.AddiCarSpec2);
                if (vlist[11].FindByDataValue(rowToComp.AddiCarSpec3) == null)      // 追加諸元3
                    vlist[11].ValueListItems.Add(rowToComp.AddiCarSpec3);
                if (vlist[12].FindByDataValue(rowToComp.AddiCarSpec4) == null)      // 追加諸元4
                    vlist[12].ValueListItems.Add(rowToComp.AddiCarSpec4);
                if (vlist[13].FindByDataValue(rowToComp.AddiCarSpec5) == null)      // 追加諸元5
                    vlist[13].ValueListItems.Add(rowToComp.AddiCarSpec5);
                if (vlist[14].FindByDataValue(rowToComp.AddiCarSpec6) == null)      // 追加諸元6
                    vlist[14].ValueListItems.Add(rowToComp.AddiCarSpec6);
            }

            for (int i = 0; i < conditionCellCount; i++)
            {
                if (vlist[i].ValueListItems.Count == 2) // 絞込条件が1個（先頭空白含めて2個）しかない場合
                {
                    gridCondition.Rows[0].Cells[i].Column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                    gridCondition.Rows[0].Cells[i].Column.CellClickAction = CellClickAction.CellSelect;
                    gridCondition.Rows[0].Cells[i].Value = vlist[i].ValueListItems[1].DisplayText;
                }
            }

            gridCondition.UpdateData();
            gridCondition.EndUpdate();

            UltraGridBand band = gridCondition.DisplayLayout.Bands[0];
            band.UseRowLayout = true;
            band.Columns[colToShow[7]].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            gridCondition.DisplayLayout.Override.RowSelectorWidth = gridCarModel.DisplayLayout.Override.RowSelectorWidth;
            ColInfo.SetColInfo(band, colToShow[5], 2, 0, 6, 2, 180);    // ModelGradeNm
            ColInfo.SetColInfo(band, colToShow[6], 8, 0, 3, 2, 90);     // BodyName
            ColInfo.SetColInfo(band, colToShow[7], 11, 0, 3, 2, 90);    // DoorCount
            ColInfo.SetColInfo(band, colToShow[8], 14, 0, 3, 2, 100);   // EngineModelNm
            ColInfo.SetColInfo(band, colToShow[9], 17, 0, 3, 2, 80);    // EngineDisplaceNm
            ColInfo.SetColInfo(band, colToShow[10], 20, 0, 3, 2, 90);   // EDivNm
            ColInfo.SetColInfo(band, colToShow[11], 23, 0, 3, 2, 90);   // TransmissionNm
            ColInfo.SetColInfo(band, colToShow[12], 26, 0, 2, 2, 40);   // ShiftNm
            ColInfo.SetColInfo(band, colToShow[19], 28, 0, 2, 2, 70);   // WheelDriveMethodNm
            ColInfo.SetColInfo(band, "NoData", 30, 0, 2, 2, 70);        // 空きコラム

            // 3段
            int originX = 2;
            if (band.Columns[colToShow[13]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[13], originX, 2, 5, 2, 150);   // 追加諸元1
                originX += 5;
            }
            if (band.Columns[colToShow[14]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[14], originX, 2, 5, 2, 150);   // 追加諸元2
                originX += 5;
            }
            if (band.Columns[colToShow[15]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[15], originX, 2, 5, 2, 150);  // 追加諸元3
                originX += 5;
            }
            if (band.Columns[colToShow[16]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[16], originX, 2, 5, 2, 150);  // 追加諸元4
                originX += 5;
            }
            if (band.Columns[colToShow[17]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[17], originX, 2, 5, 2, 150);  // 追加諸元5
                originX += 5;
            }
            if (band.Columns[colToShow[18]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[18], originX, 2, 5, 2, 120);  // 追加諸元6
            }

            if (originX > 2) // 追加諸元情報がある場合
            {
                gridCondition.Height = 94;
            }
            else
            {
                gridCondition.Height = 46;
            }
            gridCarModel.Top = gridCondition.Height + ultraGroupBox1.Height;
            gridCarModel.Height = SelectionForm_Fill_Panel.Height - gridCarModel.Top;
        }

        private void MakeSummaryData(bool flg)
        {
            carModelInfoSum.Clear();
            if (_carModelTable.DefaultView.Count > 0)
            {
                PMKEN01010E.CarModelInfoRow oRow = (PMKEN01010E.CarModelInfoRow)_carModelTable.DefaultView[0].Row;
                PMKEN01010E.CarModelInfoRow row = carModelInfoSum.AddCarModelInfoRowCopy(oRow);
                for (int i = 1; i < _carModelTable.DefaultView.Count; i++)
                {
                    PMKEN01010E.CarModelInfoRow rowToComp = (PMKEN01010E.CarModelInfoRow)_carModelTable.DefaultView[i].Row;
                    if (row.ProduceTypeOfYearCd != rowToComp.ProduceTypeOfYearCd)
                        row.ProduceTypeOfYearCd = 0;
                    if (row.StProduceTypeOfYear > rowToComp.StProduceTypeOfYear)    // 開始生産年式
                        row.StProduceTypeOfYear = rowToComp.StProduceTypeOfYear;
                    if (row.EdProduceTypeOfYear < rowToComp.EdProduceTypeOfYear)    // 終了生産年式
                        row.EdProduceTypeOfYear = rowToComp.EdProduceTypeOfYear;
                    if (row.StProduceFrameNo > rowToComp.StProduceFrameNo)          // 開始車台番号
                        row.StProduceFrameNo = rowToComp.StProduceFrameNo;
                    if (row.EdProduceFrameNo < rowToComp.EdProduceFrameNo)          // 終了車台番号
                        row.EdProduceFrameNo = rowToComp.EdProduceFrameNo;
                    if (row.ModelGradeNm != rowToComp.ModelGradeNm)                 // 型式グレード名称
                        row.ModelGradeNm = string.Empty;
                    if (row.BodyName != rowToComp.BodyName)                         // ボディー名称
                        row.BodyName = string.Empty;
                    if (row.DoorCount != rowToComp.DoorCount)                       // ドア数
                        row.DoorCount = 0;
                    if (row.EngineModelNm != rowToComp.EngineModelNm)               // エンジン型式名称
                        row.EngineModelNm = string.Empty;
                    if (row.EngineDisplaceNm != rowToComp.EngineDisplaceNm)         // 排気量名称
                        row.EngineDisplaceNm = string.Empty;
                    if (row.EDivNm != rowToComp.EDivNm)                             // E区分名称
                        row.EDivNm = string.Empty;
                    if (row.TransmissionNm != rowToComp.TransmissionNm)             // ミッション名称
                        row.TransmissionNm = string.Empty;
                    if (row.WheelDriveMethodNm != rowToComp.WheelDriveMethodNm)     // 駆動方式名称
                        row.WheelDriveMethodNm = string.Empty;
                    if (row.ShiftNm != rowToComp.ShiftNm)                           // シフト名称
                        row.ShiftNm = string.Empty;
                    if (row.SystematicCode != rowToComp.SystematicCode)
                        row.SystematicCode = 0;
                    if (row.FullModel != rowToComp.FullModel)                       // 型式
                    {   // 型式が違う時、シリーズモデルの共通部を表示するため、以下の処理を行う。
                        int j;
                        string compFullModel = _orgDataSet.CarModelUIData[0].FullModel;
                        if (row.SeriesModel.Contains(compFullModel))
                        {
                            for (j = row.SeriesModel.Length; j > 0; j--)
                            {
                                if (rowToComp.SeriesModel.Contains(row.SeriesModel.Substring(0, j)))
                                {
                                    row.FullModel = row.SeriesModel.Substring(0, j);
                                    break;
                                }
                            }
                            if (j == 0)
                                row.FullModel = string.Empty;
                        }
                        else
                        {
                            for (j = row.ExhaustGasSign.Length; j > 0; j--)
                            {
                                if (rowToComp.ExhaustGasSign.Contains(row.ExhaustGasSign.Substring(0, j)))
                                {
                                    row.FullModel = row.ExhaustGasSign.Substring(0, j);
                                    break;
                                }
                            }
                            if (j == 0)
                                row.FullModel = string.Empty;
                        }
                    }
                }

                // 要約情報の表示
                if (flg)
                {
                    DisplaySummaryData();
                }
            }
            else
            {
                if (flg)
                {
                    ClearAll();
                }
            }
        }

        private void DisplaySummaryData()
        {
            if (carModelInfoSum[0].StProduceTypeOfYear != 0 || carModelInfoSum[0].EdProduceTypeOfYear != 0)
            {
                dtProduceTypeOfYear.Enabled = true;
                string dt = string.Empty;
                // --- UPD m.suzuki 2010/05/11 ---------->>>>>
                //if (carModelInfoSum[0].EdProduceTypeOfYear != 999999)
                //{
                //    if (eraNameDispDiv)
                //    {
                //        dt = string.Format(dtfi, "{0:gg yy年 MM月} - {1:gg yy年 MM月}", GetDtFromInt(carModelInfoSum[0].StProduceTypeOfYear),
                //            GetDtFromInt(carModelInfoSum[0].EdProduceTypeOfYear));
                //    }
                //    else
                //    {
                //        dt = string.Format("{0:####年 ##月} - {1:####年 ##月}", carModelInfoSum[0].StProduceTypeOfYear,
                //            carModelInfoSum[0].EdProduceTypeOfYear);
                //    }
                //}
                //else
                //{
                //    if (eraNameDispDiv)
                //    {
                //        dt = string.Format(dtfi, "{0:gg yy年 MM月} - [現行モデル]", GetDtFromInt(carModelInfoSum[0].StProduceTypeOfYear));
                //    }
                //    else
                //    {
                //        dt = string.Format("{0:####年 ##月} - [現行モデル]", carModelInfoSum[0].StProduceTypeOfYear);
                //    }
                //}

                StringBuilder sb = new StringBuilder();

                if ( eraNameDispDiv )
                {
                    # region [和暦]
                    if ( carModelInfoSum[0].StProduceTypeOfYear == 0 )
                    {
                        sb.Append( new string( ' ', 14 ) );
                    }
                    else
                    {
                        try
                        {
                            //---- UPD 譚洪  2019/01/08 FOR 新元号の対応 ---->>>>>
                            //sb.Append( string.Format( dtfi, "{0:gg yy年 MM月}", GetDtFromInt( carModelInfoSum[0].StProduceTypeOfYear ) ) );
                            sb.Append(GetStrFromDt(GetDtFromInt(carModelInfoSum[0].StProduceTypeOfYear)));
                            //---- UPD 譚洪  2019/01/08 FOR 新元号の対応 ----<<<<<
                        }
                        catch
                        {
                            sb.Append( new string( ' ', 14 ) );
                        }
                    }

                    sb.Append( " - " );

                    if ( carModelInfoSum[0].EdProduceTypeOfYear == 0 )
                    {
                        //sb.Append( new string( ' ', 14 ) );
                    }
                    else if ( carModelInfoSum[0].EdProduceTypeOfYear == 999999 )
                    {
                        sb.Append( "[現行モデル]" );
                    }
                    else
                    {
                        try
                        {
                            //---- UPD 譚洪  2019/01/08 FOR 新元号の対応 ---->>>>>
                            //sb.Append( string.Format( dtfi, "{0:gg yy年 MM月}", GetDtFromInt( carModelInfoSum[0].EdProduceTypeOfYear ) ) );
                            sb.Append(GetStrFromDt(GetDtFromInt(carModelInfoSum[0].EdProduceTypeOfYear)));
                            //---- UPD 譚洪  2019/01/08 FOR 新元号の対応 ----<<<<<
                        }
                        catch
                        {
                            //sb.Append( new string( ' ', 14 ) );
                        }
                    }
                    # endregion
                }
                else
                {
                    # region [西暦]
                    if ( carModelInfoSum[0].StProduceTypeOfYear == 0 )
                    {
                        sb.Append( new string( ' ', 14 ) );
                    }
                    else
                    {
                        try
                        {
                            //>>>2010/07/05
                            //sb.Append(string.Format(dtfi, "{0:####年 ##月}", GetDtFromInt(carModelInfoSum[0].StProduceTypeOfYear)));
                            sb.Append(string.Format(dtfi, "{0:####年 ##月}", carModelInfoSum[0].StProduceTypeOfYear));
                            //<<<2010/07/05
                        }
                        catch
                        {
                            sb.Append( new string( ' ', 14 ) );
                        }
                    }

                    sb.Append( " - " );

                    if ( carModelInfoSum[0].EdProduceTypeOfYear == 0 )
                    {
                        //sb.Append( new string( ' ', 14 ) );
                    }
                    else if ( carModelInfoSum[0].EdProduceTypeOfYear == 999999 )
                    {
                        sb.Append( "[現行モデル]" );
                    }
                    else
                    {
                        try
                        {
                            //>>>2010/07/05
                            //sb.Append(string.Format(dtfi, "{0:####年 ##月}", GetDtFromInt(carModelInfoSum[0].EdProduceTypeOfYear)));
                            sb.Append(string.Format(dtfi, "{0:####年 ##月}", carModelInfoSum[0].EdProduceTypeOfYear));
                            //<<<2010/07/05
                        }
                        catch
                        {
                            //sb.Append( new string( ' ', 14 ) );
                        }
                    }
                    # endregion
                }

                dt = sb.ToString();
                // --- UPD m.suzuki 2010/05/11 ----------<<<<<
                labelYear.Text = dt;
            }
            else
            {
                dtProduceTypeOfYear.Enabled = false;
            }
            if (_orgDataSet.CarModelUIData.Count > 0)
                labelModel.Text = _orgDataSet.CarModelUIData[0].FullModel;
            else
                labelModel.Text = carModelInfoSum[0].FullModel;
            if (carModelInfoSum[0].StProduceFrameNo != 0 || carModelInfoSum[0].EdProduceFrameNo != 0)
            {
                if (carModelInfoSum[0].EdProduceFrameNo != 99999999)
                {
                    labelFrameNo.Text = string.Format("{0} - {1}", carModelInfoSum[0].StProduceFrameNo, carModelInfoSum[0].EdProduceFrameNo);
                }
                else
                {
                    labelFrameNo.Text = string.Format("{0} - ", carModelInfoSum[0].StProduceFrameNo);
                }
            }

            RefreshDataCount();
        }

        private void RefreshDataCount()
        {
            int cnt = gridCarModel.Rows.VisibleRowCount;
            string cntMsg;
            if (gridCarModel.Selected.Rows.Count != 0)
            {
                if (cnt != 0)
                {
                    if (gridCarModel.Selected.Rows[0].VisibleIndex != -1)
                    {
                        cntMsg = string.Format("{0} / {1}", gridCarModel.Selected.Rows[0].VisibleIndex + 1, cnt);
                    }
                    else
                    {
                        cntMsg = string.Format("1 / {0}", cnt);
                    }
                }
                else
                {
                    cntMsg = "0 / 0";
                }
            }
            else
            {
                if (cnt != 0)
                {
                    cntMsg = string.Format("ALL / {0}", cnt);
                }
                else
                {
                    cntMsg = "0 / 0";
                }
            }
            ToolbarsManager.Tools["LblCntDisplay"].SharedProps.Caption = cntMsg;
        }

        //---- ADD 譚洪  2019/01/08 FOR 新元号の対応 ---->>>>>
        /// <summary>
        /// 生産年式文字列取得処理
        /// </summary>
        /// <param name="produceTypeOfYear">生産年式</param>
        /// <remarks>
        /// <br>Note	   : 生産年式を和暦の「GG YY年 MM月」形式に変換する</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/01/08</br>
        /// </remarks>
        private string GetStrFromDt(DateTime produceTypeOfYear)
        {
            string retYear = string.Empty;
            retYear = TDateTime.DateTimeToString("GGYYMM", produceTypeOfYear);
            string gg = retYear.Substring(0, 2);
            string yy = retYear.Substring(2, 3);
            string mm = retYear.Substring(5, 3);
            retYear = gg + " " + yy + " " + mm;
            return retYear;
        }
        //---- ADD 譚洪  2019/01/08 FOR 新元号の対応 ----<<<<<
        #endregion

        #region [ イベント処理 ]

        /// <summary>
        /// アクティブ行変更後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridCarModel_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {

            //if (_initialize) return;
            if (isSelectChangeDisabled)
                return;
            ToolbarsManager.Tools["Button_Select"].SharedProps.Enabled = true;
            UltraGridRow activeRow = gridCarModel.ActiveRow;
            if (activeRow != null)
            {
                int fullModelFixedNo; // 類別表示機能のためなので現在不要だが、将来のため残しておく。
                if (this.isCarModelListDisplay)
                {
                    fullModelFixedNo = (int)gridCarModel.ActiveRow.Cells[_carModelTable.FullModelFixedNoColumn.ColumnName].Value;
                    isSelectChangeDisabled = true;
                    gridCarModel.Selected.Rows.Clear();
                    activeRow.Selected = true;
                    isSelectChangeDisabled = false;
                    RefreshDataCount();
                }
                else
                {
                    string fullModel = string.Empty;
                    if (activeRow.Band == gridCarModel.DisplayLayout.Bands[1])
                    {
                        if (!activeRow.Selected) // 子バンドの選択解除
                        {
                            isSelectChangeDisabled = true;
                            gridCarModel.Selected.Rows.Clear();
                            isSelectChangeDisabled = false;
                        }
                        else // 子バンドの選択
                        {
                            isSelectChangeDisabled = true;
                            activeRow.ParentRow.Activated = true;
                            gridCarModel.Selected.Rows.Clear();
                            activeRow.ParentRow.Selected = true;

                            for (int i = 0; i < activeRow.ParentRow.ChildBands[0].Rows.Count; i++)
                            {
                                gridCarModel.Selected.Rows.Add(activeRow.ParentRow.ChildBands[0].Rows[i]);
                            }
                            isSelectChangeDisabled = false;
                        }
                        fullModel = activeRow.ParentRow.Cells[_carModelRel.CarModelHd.FullModelColumn.ColumnName].Value.ToString();
                        RefreshDataCount();
                    }
                    else  // 親バンド
                    {
                        if (!activeRow.Selected) // 親バンドの洗濯解除
                        {
                            isSelectChangeDisabled = true;
                            gridCarModel.Selected.Rows.Clear();
                            isSelectChangeDisabled = false;
                        }
                        else // 親バンドの選択
                        {
                            isSelectChangeDisabled = true;
                            gridCarModel.Selected.Rows.Clear();
                            activeRow.Selected = true;
                            for (int i = 0; i < activeRow.ChildBands[0].Rows.Count; i++)
                            {
                                gridCarModel.Selected.Rows.Add(activeRow.ChildBands[0].Rows[i]);
                            }
                            isSelectChangeDisabled = false;
                        }
                        fullModel = activeRow.Cells[_carModelTable.FullModelColumn.ColumnName].Value.ToString();
                        RefreshDataCount();
                    }
                    string select = string.Format("FullModel = '{0}'", fullModel);
                    fullModelFixedNo = ((PMKEN01010E.CarModelInfoRow[])_carModelTable.Select(select))[0].FullModelFixedNo;
                }
#if CATEGORY_SECURITY_OK
                if (_ctgyMdlLnkTable.Select(string.Format("FullModelFixedNo = {0}", fullModelFixedNo)).Length > 0)
                {
                    ToolbarsManager.Tools["Button_Category"].SharedProps.Enabled = true;
                }
                else
                {
                    ToolbarsManager.Tools["Button_Category"].SharedProps.Enabled = false;
                }
#endif
            }
#if CATEGORY_SECURITY_OK
            else
            {
                ToolbarsManager.Tools["Button_Category"].SharedProps.Enabled = false;
            }
#endif
        }

        /// <summary>
        /// グリッド上でEnterキーが押された場合は、その行を選択する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridCarModel_KeyDown(object sender, KeyEventArgs e)
        {
            if (_initialize) return;
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// 行をダブルクリックされた場合は、その行を選択する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// データが表示されていない行をダブルクリックしても本イベントは発生しない。
        /// </remarks>
        private void gridCarModel_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            if (_initialize) return;
            DialogResult = DialogResult.OK;
        }

        private void gridCarModel_AfterSortChange(object sender, BandEventArgs e)
        {
            RefreshDataCount();
            if (gridCarModel.Selected.Rows.Count > 0)
            {
                gridCarModel.Rows[0].Activate();
                gridCarModel.Selected.Rows[0].Activate();
            }
        }

        /// <summary>
        /// ESCキー押下による終了処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (_initialize) return;

            if (isConditionInputState == false)
            {
                if (e.KeyCode == Keys.Back)
                {
                    int rowNo;
                    if (rowNoInput.Length > 1)
                    {
                        rowNoInput = rowNoInput.Remove(rowNoInput.Length - 1);
                        rowNo = int.Parse(rowNoInput);
                    }
                    else
                    {
                        rowNoInput = string.Empty;
                        rowNo = 1;
                    }
                    gridCarModel.Rows[rowNo - 1].Activate();
                    gridCarModel.Rows[rowNo - 1].Selected = true;
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    rowNoInput = string.Empty;
                    gridCarModel.Rows[0].Activate();
                    gridCarModel.Rows[0].Selected = true;
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }

            if (label_CarName.Focused) // 画面起動あと最初にフォーカス移動をキャッチするために必要
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up ||
                    e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
                {
                    gridCarModelSelect();
                }
                else if (e.KeyCode == Keys.Return)
                {
                    isAllSelected = true;
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void SelectionForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isConditionInputState == false && e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                string strRowNo = rowNoInput + e.KeyChar.ToString();

                int rowNo = int.Parse(strRowNo);
                if (rowNo > 0 && rowNo <= gridCarModel.Rows.VisibleRowCount)
                {
                    rowNoInput = strRowNo;
                }
                else
                {
                    if (e.KeyChar.Equals('0') == false)
                    {
                        rowNoInput = e.KeyChar.ToString();
                        rowNo = int.Parse(rowNoInput);
                        if (rowNo > gridCarModel.Rows.VisibleRowCount)
                        {
                            rowNoInput = string.Empty;
                            rowNo = 1;
                        }
                    }
                    else
                    {
                        rowNo = 1;
                    }
                }
                if (gridCarModel.Focused == false)
                    gridCarModel.Select();
                gridCarModel.Rows[rowNo - 1].Activate();
                gridCarModel.Rows[rowNo - 1].Selected = true;
            }
        }

        /// <summary>
        /// クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Update Note: 2017/01/22 王飛</br>
        /// <br>管理番号   : 11270046-00 車輌検索改良</br>
        /// <br>             Redmine#48967 車台番号初期フォーカス対応障害対応</br>
        /// </remarks>
        private void ClearCondition()
        {
            dtProduceTypeOfYear.Clear();
            txtFrameNo.Clear();
            dtProduceTypeOfYear.Tag = null;
            txtFrameNo.Tag = null;

            isSelectChangeDisabled = true;
            for (int i = 0; i < conditionCellCount; i++)
            {
                if (gridCondition.Rows[0].Cells[i].Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList)
                {
                    if (i < 9)
                    {
                        gridCondition.Rows[0].Cells[i].Value = string.Empty;
                    }
                    else
                    {
                        gridCondition.Rows[0].Cells[i + 1].Value = string.Empty;
                    }
                }
            }
            isSelectChangeDisabled = false;

            gridCondition.UpdateData();
            rowFilterList.Clear();

            GridFiltering();
            isSelectChangeDisabled = true;
            gridCarModel.Selected.Rows.Clear();
            isSelectChangeDisabled = false;
            //----- UPD 2017/01/22 王飛 Redmine#48967 ----->>>>>
            //label_CarName.Focus();
            // 初期フォーカス設定
            if (IsInitFoucsOnFrameNo())
            {
                txtFrameNo.Focus();
            }
            else
            {
                label_CarName.Focus();
            }
            //----- UPD 2017/01/22 王飛 Redmine#48967 -----<<<<<
            RefreshDataCount();
        }

        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (BLCompoBugTaisaku) // このコントロールのバグ対策。
            {
                BLCompoBugTaisaku = false;
                return;
            }
            if (e.PrevCtrl == gridCarModel)
            {
                if (e.Key == Keys.Enter)
                {
                    DialogResult = DialogResult.OK;
                    e.NextCtrl = e.PrevCtrl;
                }
            }
            else if (e.PrevCtrl == label_CarName)
            {
                if (gridCarModel.Selected.Rows.Count == 0 && e.Key == Keys.Enter)
                {
                    isAllSelected = true;
                    DialogResult = DialogResult.OK;
                    return;
                }
                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                {
                    e.NextCtrl = gridCarModel;
                    gridCarModelSelect();
                }
            }
            //----- ADD 2017/01/22 王飛 Redmine#48967 ----->>>>>
            else if ((e.PrevCtrl == txtFrameNo 
                || e.PrevCtrl == dtProduceTypeOfYear)
                && IsInitOnAllSelect()//絞込条件からのEnter動作区分:全選択
                && e.Key == Keys.Enter)
            {
                e.NextCtrl = label_CarName;
                return;
            }
            //----- ADD 2017/01/22 王飛 Redmine#48967 -----<<<<<

            // 2009.05.18 Add >>>
            // Enterで諸元グリッド⇒型式選択グリッドに移動する場合に、先頭行を選択状態にする
            if (e.PrevCtrl == this.gridCondition && e.NextCtrl == this.gridCarModel && e.Key == Keys.Enter)
            {
                gridCarModelSelect();
            }
            // 2009.05.18 Add <<<
        }

        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (BLCompoBugTaisaku) // このコントロールのバグ対策。
            {
                BLCompoBugTaisaku = false;
                return;
            }
            if (e.PrevCtrl == label_CarName)
            {
                if (e.Key == Keys.Down || e.Key == Keys.Up ||
                    e.Key == Keys.Right || e.Key == Keys.Left ||
                    e.Key == Keys.PageDown || e.Key == Keys.PageDown)
                {
                    e.NextCtrl = gridCarModel;
                    gridCarModelSelect();
                }
            }
            if (e.PrevCtrl == dtProduceTypeOfYear || e.PrevCtrl == txtFrameNo)
            {
                if (e.Key == Keys.Down ||
                    e.Key == Keys.PageDown || e.Key == Keys.PageDown)
                {
                    e.NextCtrl = gridCarModel;
                    gridCarModelSelect();
                }
            }
        }

        private void gridCarModelSelect()
        {
            gridCarModel.Select();
            if (gridCarModel.Selected.Rows.Count == 0)
            {
                if (gridCarModel.ActiveRow == null)
                {
                    if (gridCarModel.Rows.Count > 0)
                    {
                        gridCarModel.Rows[0].Activated = true;
                        gridCarModel.Rows[0].Selected = true;
                    }
                }
                else
                {
                    gridCarModel.ActiveRow.Selected = true;
                }
            }
        }

        private void gridCarModel_Leave(object sender, EventArgs e)
        {
            isSelectChangeDisabled = true;
            gridCarModel.Selected.Rows.Clear();
            isSelectChangeDisabled = false;
            gridCarModel.ActiveRow = null;
            RefreshDataCount();
        }

        #endregion

        #region [ 絞込み条件処理 ]
        private void dtProduceTypeOfYear_Validating(object sender, CancelEventArgs e)
        {
            if (_initialize)
                return;
            // 2009/11/17 Add >>>
            if (this.dtProduceTypeOfYear.GetLongDate().Equals(this._dtProduceTypeOfYear)) return;
            // 2009/11/17 Add <<<
            string rowFilter = string.Empty;
            isConditionInputState = false;
            int year = dtProduceTypeOfYear.GetDateYear() * 100 + dtProduceTypeOfYear.GetDateMonth();
            if ((dtProduceTypeOfYear.Tag == null && year == 0) ||
                (dtProduceTypeOfYear.Tag != null && year.Equals(dtProduceTypeOfYear.Tag)))
            {
                //gridCarModelSelect();
                return;
            }
            if (year == 0)
            {
                rowFilterList.Remove(RowFilterKind.ProduceTypeOfYear);
            }
            else if (year >= carModelInfoSumOrg[0].StProduceTypeOfYear && year <= carModelInfoSumOrg[0].EdProduceTypeOfYear)
            {
                if (rowFilterList.ContainsKey(RowFilterKind.ProduceTypeOfYear))
                {
                    rowFilterList[RowFilterKind.ProduceTypeOfYear] = string.Format("StProduceTypeOfYear <= {0} AND {1} <= EdProduceTypeOfYear", year, year);
                }
                else
                {
                    rowFilterList.Add(RowFilterKind.ProduceTypeOfYear,
                        string.Format("StProduceTypeOfYear <= {0} AND {1} <= EdProduceTypeOfYear", year, year));
                }
            }
            else
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Text, "生産年式の絞込条件が範囲外です。", 0, MessageBoxButtons.OK);
                BLCompoBugTaisaku = true;
                e.Cancel = true;
                // 2009/11/17 Add >>>
                this.dtProduceTypeOfYear.SetLongDate(this._dtProduceTypeOfYear);
                // 2009/11/17 Add <<<
                return;
            }
            GridFiltering();
            dtProduceTypeOfYear.Tag = year;
            RefreshDataCount();
            //----- UPD 2017/01/22 王飛 Redmine#48967 ----->>>>>
            //gridCarModelSelect();
            //絞込条件からのEnter動作区分:次項目へ遷移
            if (!IsInitOnAllSelect())
            {
                gridCarModelSelect();
            }
            //----- UPD 2017/01/22 王飛 Redmine#48967 -----<<<<<
        }

        private void txtFrameNo_Validating(object sender, CancelEventArgs e)
        {
            int frameNo;
            string rowFilter = string.Empty;
            isConditionInputState = false;

            // 2009/11/17 Add >>>
            if (this.txtFrameNo.Text.Equals(this._txtFrameNo)) return;
            // 2009/11/17 Add <<<

            if (int.TryParse(txtFrameNo.Text, out frameNo))
            {
                if (frameNo.Equals(txtFrameNo.Tag))
                {
                    gridCarModelSelect();
                    return;
                }
                if (carModelInfoSum[0].StProduceFrameNo != 0 || carModelInfoSum[0].EdProduceFrameNo != 0) // 型式情報に車台番号情報がある場合
                {
                    if (frameNo >= carModelInfoSumOrg[0].StProduceFrameNo && frameNo <= carModelInfoSumOrg[0].EdProduceFrameNo)
                    {
                        if (rowFilterList.ContainsKey(RowFilterKind.FrameNo))
                        {
                            rowFilterList[RowFilterKind.FrameNo] = string.Format("StProduceFrameNo <= {0} AND {1} <= EdProduceFrameNo", frameNo, frameNo);
                        }
                        else
                        {
                            rowFilterList.Add(RowFilterKind.FrameNo,
                                string.Format("StProduceFrameNo <= {0} AND {1} <= EdProduceFrameNo", frameNo, frameNo));
                        }
                    }
                    else
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Text, "車台番号の絞込条件が範囲外です。", 0, MessageBoxButtons.OK);
                        BLCompoBugTaisaku = true;
                        e.Cancel = true;
                        // 2009/11/17 Add >>>
                        this.txtFrameNo.Text = this._txtFrameNo;
                        // 2009/11/17 Add <<<
                        return;
                    }
                }
                else // 生産年式マスタから車台番号で絞り込む場合
                {
                    if (_orgDataSet.PrdTypYearInfo.Count == 0) // 生産年式情報がない場合はなにもせずに終了
                    {
                        return;
                    }
                    string cond = string.Empty;
                    string filter = string.Format("{0}<={1} AND {2}>={3}",
                            _orgDataSet.PrdTypYearInfo.StProduceFrameNoColumn.ColumnName, frameNo,
                            _orgDataSet.PrdTypYearInfo.EdProduceFrameNoColumn.ColumnName, frameNo);
                    PMKEN01010E.PrdTypYearInfoRow[] row =
                        (PMKEN01010E.PrdTypYearInfoRow[])_orgDataSet.PrdTypYearInfo.Select(filter);
                    if (row.Length == 0)
                    {
                        // 2009/11/17 Del >>>
                        //TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Text, "車台番号の絞込条件が範囲外です。", 0, MessageBoxButtons.OK);
                        //BLCompoBugTaisaku = true;
                        //e.Cancel = true;
                        //return;
                        // 2009/11/17 Del <<<
                    }
                    else    // 2009/11/17 Add 
                    {       // 2009/11/17 Add 
                    
                        for (int i = 0; i < row.Length; i++)
                        {
                            cond += string.Format("OR (StProduceTypeOfYear <= {0} AND {1} <= EdProduceTypeOfYear)", row[i].ProduceTypeOfYear, row[i].ProduceTypeOfYear);
                        }
                        int year = row[0].ProduceTypeOfYear / 100;
                        int month = row[0].ProduceTypeOfYear % 100;
                        if (year > 0 && month > 0 && month < 13)
                        {
                            dtProduceTypeOfYear.SetDateTime(new DateTime(year, month, 1));
                        }
                        cond = cond.Substring(2);
                        // フレームNoによる年式絞込なので年式絞込条件として登録する。
                        if (rowFilterList.ContainsKey(RowFilterKind.ProduceTypeOfYear))
                        {
                            rowFilterList[RowFilterKind.ProduceTypeOfYear] = cond;
                        }
                        else
                        {
                            rowFilterList.Add(RowFilterKind.ProduceTypeOfYear, cond);
                        }
                        this.dtProduceTypeOfYear.Tag = dtProduceTypeOfYear.GetDateYear() * 100 + dtProduceTypeOfYear.GetDateMonth();    // 2009/11/17 Add
                    }   // 2009/11/17 Add
                }
                txtFrameNo.Tag = frameNo;

                GridFiltering();
            }
            else
            {
                if (txtFrameNo.Tag != null)
                {
                    if (carModelInfoSum[0].StProduceFrameNo != 0 || carModelInfoSum[0].EdProduceFrameNo != 0) // 型式情報に車台番号情報がある場合
                        rowFilterList.Remove(RowFilterKind.FrameNo);
                    else
                    //----- ADD 2017/01/22 王飛 Redmine#48967 ----->>>>>
                    {
                        rowFilterList.Remove(RowFilterKind.FrameNo);
                    //----- ADD 2017/01/22 王飛 Redmine#48967 -----<<<<<
                        rowFilterList.Remove(RowFilterKind.ProduceTypeOfYear);
                    }   //ADD 2017/01/22 王飛 Redmine#48967
                    GridFiltering();
                }
                if (txtFrameNo.Text == string.Empty)
                {
                    if (carModelInfoSum[0].StProduceFrameNo == 0 && carModelInfoSum[0].EdProduceFrameNo == 0
                        && dtProduceTypeOfYear.GetDateYear() != 0)
                    {
                        dtProduceTypeOfYear.Clear();
                        dtProduceTypeOfYear.Tag = null;
                    }
                    txtFrameNo.Tag = null;
                }
                else
                {
                    txtFrameNo.Clear();
                    dtProduceTypeOfYear.Clear();
                    //txtFrameNo.Tag = null;
                    dtProduceTypeOfYear.Tag = null;
                    e.Cancel = true;
                }
                return;
            }
            RefreshDataCount();
            //----- UPD 2017/01/22 王飛 Redmine#48967 ----->>>>>
            //gridCarModelSelect();
            //絞込条件からのEnter動作区分:次項目へ遷移
            if (!IsInitOnAllSelect())
            {
                gridCarModelSelect();
            }
            else
            {
                this.label_CarName.Focus();
            }
            //----- UPD 2017/01/22 王飛 Redmine#48967 -----<<<<<
        }

        // 2011/03/08 Add >>>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="txtFrameNo"></param>
        /// <returns></returns>
        private bool TxtFrameNoRangeCheck(int frameNo)
        {
            bool ret = true;

            if (( carModelInfoSum[0].StProduceFrameNo != 0 || carModelInfoSum[0].EdProduceFrameNo != 0 ))
            {
                if (!( frameNo >= carModelInfoSumOrg[0].StProduceFrameNo && frameNo <= carModelInfoSumOrg[0].EdProduceFrameNo ))
                {
                    ret = false;
                }
            }

            return ret;
        }
        // 2011/03/08 Add <<<

        private void ConditionSettingBegin(object sender, EventArgs e)
        {
            isConditionInputState = true;

            // 2009/11/17 Add >>>
            if (sender == this.txtFrameNo)
            {
                this._txtFrameNo = this.txtFrameNo.Text;
            }
            else if (sender == this.dtProduceTypeOfYear)
            {
                this._dtProduceTypeOfYear = (int)this.dtProduceTypeOfYear.GetLongDate();
            }
            // 2009/11/17 Add <<<
        }

        #endregion

        #region [ フィルタリング関連処理 ]

        private void SetFilteringList()
        {
            lstEnum.Add("ProduceTypeOfYear", RowFilterKind.ProduceTypeOfYear);
            lstEnum.Add("FrameNo", RowFilterKind.FrameNo);
            lstEnum.Add("ModelGradeNm", RowFilterKind.ModelGradeNm);
            lstEnum.Add("BodyName", RowFilterKind.BodyName);
            lstEnum.Add("DoorCount", RowFilterKind.DoorCount);
            lstEnum.Add("EngineModelNm", RowFilterKind.EngineModelNm);
            lstEnum.Add("EngineDisplaceNm", RowFilterKind.EngineDisplaceNm);
            lstEnum.Add("EDivNm", RowFilterKind.EDivNm);
            lstEnum.Add("TransmissionNm", RowFilterKind.TransmissionNm);
            lstEnum.Add("ShiftNm", RowFilterKind.ShiftNm);
            lstEnum.Add("WheelDriveMethodNm", RowFilterKind.WheelDriveMethodNm);
            lstEnum.Add("PartsExistence", RowFilterKind.PartsExistence);
            lstEnum.Add("AddiCarSpec1", RowFilterKind.AddiCarSpec1);
            lstEnum.Add("AddiCarSpec2", RowFilterKind.AddiCarSpec2);
            lstEnum.Add("AddiCarSpec3", RowFilterKind.AddiCarSpec3);
            lstEnum.Add("AddiCarSpec4", RowFilterKind.AddiCarSpec4);
            lstEnum.Add("AddiCarSpec5", RowFilterKind.AddiCarSpec5);
            lstEnum.Add("AddiCarSpec6", RowFilterKind.AddiCarSpec6);
        }

        private void gridCondition_CellListSelect(object sender, CellEventArgs e)
        {
            if (isSelectChangeDisabled)
                return;
            string filterString = string.Empty;
            RowFilterKind selected = lstEnum[e.Cell.Column.Key];
            if (e.Cell.Text == string.Empty)
            {
                if (rowFilterList.ContainsKey(selected))
                {
                    rowFilterList.Remove(selected);
                }
            }
            else
            {
                filterString = string.Format("{0} = '{1}'", e.Cell.Column.Key, e.Cell.Text);
                if (rowFilterList.ContainsKey(selected))
                {
                    rowFilterList[selected] = filterString;
                }
                else
                {
                    rowFilterList.Add(selected, filterString);
                }
            }

            gridCondition.UpdateData();

            GridFiltering();
            gridCarModelSelect();
        }

        private void GridFiltering()
        {
            isSelectChangeDisabled = true;
            gridCarModel.Selected.Rows.Clear();//
            gridCarModel.ActiveRow = null; //
            isSelectChangeDisabled = false;

            string rowFilter = MakeRowFilterString();
            gridCarModel.BeginUpdate();
            _carModelTable.DefaultView.RowFilter = rowFilter; // 同一型式表示用
            _carModelRel.CarModelHd.DefaultView.RowFilter = MakeRowFilterString2(); // 型式リスト表示用
            if (isCarModelListDisplay == false)
            {
                int cnt = gridCarModel.Rows.Count;
                for (int i = 0; i < cnt; i++) // 親バンドの行数分
                {
                    bool isAnyRowShown = false;
                    RowsCollection rowsCollection = gridCarModel.Rows[i].ChildBands[0].Rows;
                    for (int j = 0; j < rowsCollection.Count; j++) // 子バンドの行数分
                    {
                        bool isRowFiltered = false;
                        for (int k = 0; k < conditionCellCount; k++) // 子バンドのコラム中フィルタリングするコラム数分
                        {
                            int index;
                            if (k < 9)
                            {
                                index = k;
                            }
                            else
                            {
                                index = k + 1;
                            }
                            string filterString = gridCondition.Rows[0].Cells[index].Text;
                            if (string.IsNullOrEmpty(filterString) == false
                                && (filterString.Equals(rowsCollection[j].Cells[index].Value.ToString()) == false)
                                && rowsCollection[j].Cells[index].Value.Equals(string.Empty) == false)
                            {
                                isRowFiltered = true;
                                break;
                            }
                        }
                        if (isRowFiltered)
                        {
                            rowsCollection[j].Hidden = true;
                        }
                        else
                        {
                            rowsCollection[j].Hidden = false;
                            isAnyRowShown = true;
                        }
                    }
                    if (isAnyRowShown)
                    {
                        gridCarModel.Rows[i].Hidden = false;
                    }
                    else
                    {
                        gridCarModel.Rows[i].Hidden = true;
                    }
                }
                gridCarModel.Rows.ExpandAll(false);
            }
            gridCarModel.EndUpdate();
            MakeSummaryData(true);
            if (rowFilter == string.Empty)
            {
                this.ToolbarsManager.Tools["Button_Clear"].SharedProps.Visible = false;
            }
            else
            {
                this.ToolbarsManager.Tools["Button_Clear"].SharedProps.Visible = true;
            }
            RefreshGridData();
            if (gridCarModel.DisplayLayout.MaxRowScrollRegions - 1 <= gridCarModel.Rows.VisibleRowCount)
            {
                gridCondition.DisplayLayout.Scrollbars = Scrollbars.Vertical;
            }
            else
            {
                gridCondition.DisplayLayout.Scrollbars = Scrollbars.None;
            }
            RefreshDataCount();
        }

        private string MakeRowFilterString()
        {
            StringBuilder retRowFilter = new StringBuilder();
            foreach (string rowFilter in rowFilterList.Values)
            {
                retRowFilter.Append(" AND " + rowFilter);
            }
            if (retRowFilter.Length > 4)
            {
                retRowFilter.Remove(0, 4);
            }
            return retRowFilter.ToString();
        }

        private string MakeRowFilterString2()
        {
            StringBuilder retRowFilter = new StringBuilder();
            foreach (string rowFilter in rowFilterList.Values)
            {
                if (rowFilter.Contains("ProduceTypeOfYear") || rowFilter.Contains("FrameNo"))
                {
                    retRowFilter.Append(" AND " + rowFilter);
                }
            }
            if (retRowFilter.Length > 4)
            {
                retRowFilter.Remove(0, 4);
            }
            return retRowFilter.ToString();
        }

        private void ClearAll()
        {
            labelYear.Text = string.Empty;
            labelFrameNo.Text = string.Empty;
        }

        /// <summary>
        /// グリッド再描画[グリッドにカラム追加した項目・年式などの表示を更新する（フィルタリング・表示切替時など）]
        /// </summary>
        /// <remarks>
        /// <br>UpdateNote   2019/01/08  譚洪</br>
        /// <br>修正内容     新元号の対応</br>
        /// </remarks>
        private void RefreshGridData()
        {
            string colEdProduceTypeOfYear = _carModelTable.EdProduceTypeOfYearColumn.ColumnName;
            string colEdProduceYear = _carModelTable.EdProduceYearColumn.ColumnName;
            string colEdProduceFrameNo = _carModelTable.EdProduceFrameNoColumn.ColumnName;
            // --- ADD m.suzuki 2010/06/04 ---------->>>>>
            string colStProduceTypeOfYear = _carModelTable.StProduceTypeOfYearColumn.ColumnName;
            string colStProduceYear = _carModelTable.StProduceYearColumn.ColumnName;
            string colStProduceFrameNo = _carModelTable.StProduceFrameNoColumn.ColumnName;
            // --- ADD m.suzuki 2010/06/04 ----------<<<<<


            Image img = IconResourceManagement.ImageList16.Images[(int)Size16_Index.INTERRUPTION];
            int rowCount = gridCarModel.Rows.Count;

            gridCarModel.BeginUpdate();
            if (isCarModelListDisplay)  // 同一型式表示
            {
                for (int i = 0; i < rowCount; i++)
                {
                    // --- ADD m.suzuki 2010/06/04 ---------->>>>>
                    if ( gridCarModel.Rows[i].Cells[colStProduceTypeOfYear].Value.Equals( 999999 ) )
                    {
                        gridCarModel.Rows[i].Cells[ColStTypeOfYear].Value = "";
                    }
                    else
                    {
                        if ( gridCarModel.Rows[i].Cells[colStProduceYear].Value != DBNull.Value ||
                             (int)gridCarModel.Rows[i].Cells[colStProduceYear].Value > 0 )
                        {
                            if ( eraNameDispDiv ) // 和暦表示か
                            {
                                try
                                {
                                    gridCarModel.Rows[i].Cells[ColStTypeOfYear].Value =
                                    //---- UPD 譚洪  2019/01/08 FOR 新元号の対応 ---->>>>>
                                    //    string.Format( dtfi, "{0:gg yy年 MM月}", gridCarModel.Rows[i].Cells[colStProduceYear].Value );
                                        GetStrFromDt(DateTime.Parse(gridCarModel.Rows[i].Cells[colStProduceYear].Value.ToString()));
                                    //---- UPD 譚洪  2019/01/08 FOR 新元号の対応 ----<<<<<
                                }
                                catch
                                {
                                    gridCarModel.Rows[i].Cells[ColStTypeOfYear].Value = DBNull.Value;
                                }
                            }
                            else
                            {
                                gridCarModel.Rows[i].Cells[ColStTypeOfYear].Value =
                                    string.Format( "{0:####年 ##月}", gridCarModel.Rows[i].Cells[colStProduceTypeOfYear].Value );
                            }
                        }
                        else
                        {
                            gridCarModel.Rows[i].Cells[ColStTypeOfYear].Value = DBNull.Value;
                        }
                    }
                    // --- ADD m.suzuki 2010/06/04 ----------<<<<<

                    if (gridCarModel.Rows[i].Cells[colEdProduceTypeOfYear].Value.Equals(999999))
                    {
                        gridCarModel.Rows[i].Cells[ColEdTypeOfYear].Value = "現行モデル";
                    }
                    else
                    {
                        // --- UPD m.suzuki 2010/06/04 ---------->>>>>
                        //if ( eraNameDispDiv ) // 和暦表示か
                        //{
                        //    gridCarModel.Rows[i].Cells[ColEdTypeOfYear].Value =
                        //        string.Format( dtfi, "{0:gg yy年 MM月}", gridCarModel.Rows[i].Cells[colEdProduceYear].Value );
                        //}
                        //else
                        //{
                        //    gridCarModel.Rows[i].Cells[ColEdTypeOfYear].Value =
                        //        string.Format( "{0:####年 ##月}", gridCarModel.Rows[i].Cells[colEdProduceTypeOfYear].Value );
                        //}

                        if ( gridCarModel.Rows[i].Cells[colEdProduceYear].Value != DBNull.Value ||
                             (int)gridCarModel.Rows[i].Cells[colEdProduceYear].Value > 0 )
                        {
                            if ( eraNameDispDiv ) // 和暦表示か
                            {
                                try
                                {
                                    gridCarModel.Rows[i].Cells[ColEdTypeOfYear].Value =
                                    //---- UPD 譚洪  2019/01/08 FOR 新元号の対応 ---->>>>>
                                    //    string.Format( dtfi, "{0:gg yy年 MM月}", gridCarModel.Rows[i].Cells[colEdProduceYear].Value );
                                        GetStrFromDt(DateTime.Parse(gridCarModel.Rows[i].Cells[colEdProduceYear].Value.ToString()));
                                    //---- UPD 譚洪  2019/01/08 FOR 新元号の対応 ----<<<<<
                                }
                                catch
                                {
                                    gridCarModel.Rows[i].Cells[ColEdTypeOfYear].Value = DBNull.Value;
                                }
                            }
                            else
                            {
                                gridCarModel.Rows[i].Cells[ColEdTypeOfYear].Value =
                                    string.Format( "{0:####年 ##月}", gridCarModel.Rows[i].Cells[colEdProduceTypeOfYear].Value );
                            }
                        }
                        else
                        {
                            gridCarModel.Rows[i].Cells[ColEdTypeOfYear].Value = DBNull.Value;
                        }
                        // --- UPD m.suzuki 2010/06/04 ----------<<<<<
                    }
                    // 2010/10/18 Add >>>
                    gridCarModel.Rows[i].Cells[ColStFrameNo].Value =
                        string.Format("{0:#}", gridCarModel.Rows[i].Cells[colStProduceFrameNo].Value);
                    // 2010/10/18 Add <<<
                    if (gridCarModel.Rows[i].Cells[colEdProduceFrameNo].Value.Equals(99999999))
                    {
                        gridCarModel.Rows[i].Cells[ColEdFrameNo].Value = "-   ";
                    }
                    else
                    {
                        gridCarModel.Rows[i].Cells[ColEdFrameNo].Value =
                            string.Format("{0:#}", gridCarModel.Rows[i].Cells[colEdProduceFrameNo].Value);
                    }
                    // 2009/10/30 >>>
                    // テーブルではなく、DataSouceから判断する
                    //if (_carModelTable[i].PartsDataOfferFlag == 0)
                    if ((int)gridCarModel.Rows[i].Cells[_carModelTable.PartsDataOfferFlagColumn.ColumnName].Value == 0)
                    // 2009/10/30 <<<
                    {
                        gridCarModel.Rows[i].Cells[ColPartsEx].Value = img;
                    }

                    // --- ADD m.suzuki 2010/05/11 ---------->>>>>
                    // 部品収録カラムのセット
                    if ( gridCarModel.Rows[i].Cells["FreeSearchSortDiv"].Value.Equals( 0 ) )
                    {
                        gridCarModel.Rows[i].Cells[ColPartsEx].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        gridCarModel.Rows[i].Cells[ColPartsEx].Value = "自由検索";
                    }
                    // --- ADD m.suzuki 2010/05/11 ----------<<<<<
                }
            }
            else                        // 型式リスト
            {
                for (int i = 0; i < rowCount; i++)
                {
                    // --- ADD m.suzuki 2010/06/04 ---------->>>>>
                    if ( gridCarModel.Rows[i].Cells[colStProduceTypeOfYear].Value.Equals( 999999 ) )
                    {
                        gridCarModel.Rows[i].Cells[ColStTypeOfYear].Value = "現行モデル";
                    }
                    else
                    {
                        if ( gridCarModel.Rows[i].Cells[ColStTypeOfYear].Value != DBNull.Value ||
                            (int)gridCarModel.Rows[i].Cells[ColStTypeOfYear].Value > 0 )
                        {
                            if ( eraNameDispDiv ) // 和暦表示か
                            {
                                try
                                {
                                    gridCarModel.Rows[i].Cells[ColStTypeOfYear].Value =
                                    //---- UPD 譚洪  2019/01/08 FOR 新元号の対応 ---->>>>>
                                    //    string.Format( dtfi, "{0:gg yy年 MM月}", gridCarModel.Rows[i].Cells[colStProduceYear].Value );
                                        GetStrFromDt(DateTime.Parse(gridCarModel.Rows[i].Cells[colStProduceYear].Value.ToString()));
                                    //---- UPD 譚洪  2019/01/08 FOR 新元号の対応 ----<<<<<
                                }
                                catch
                                {
                                    gridCarModel.Rows[i].Cells[ColStTypeOfYear].Value = DBNull.Value;
                                }
                            }
                            else
                            {
                                gridCarModel.Rows[i].Cells[ColStTypeOfYear].Value =
                                    string.Format( "{0:####年 ##月}", gridCarModel.Rows[i].Cells[colStProduceTypeOfYear].Value );
                            }
                        }
                        else
                        {
                            gridCarModel.Rows[i].Cells[ColStTypeOfYear].Value = DBNull.Value;
                        }
                    }
                    if ( gridCarModel.Rows[i].Cells[colStProduceFrameNo].Value.Equals( 99999999 ) )
                    {
                        gridCarModel.Rows[i].Cells[ColStFrameNo].Value = "-   ";
                    }
                    else
                    {
                        gridCarModel.Rows[i].Cells[ColStFrameNo].Value =
                            string.Format( "{0:#}", gridCarModel.Rows[i].Cells[colStProduceFrameNo].Value );
                    }
                    // --- ADD m.suzuki 2010/06/04 ----------<<<<<

                    if ( gridCarModel.Rows[i].Cells[colEdProduceTypeOfYear].Value.Equals( 999999 ) )
                    {
                        gridCarModel.Rows[i].Cells[ColEdTypeOfYear].Value = "現行モデル";
                    }
                    else
                    {
                        // --- UPD m.suzuki 2010/06/04 ---------->>>>>
                        //if ( eraNameDispDiv ) // 和暦表示か
                        //{
                        //    gridCarModel.Rows[i].Cells[ColEdTypeOfYear].Value =
                        //        string.Format( dtfi, "{0:gg yy年 MM月}", gridCarModel.Rows[i].Cells[colEdProduceYear].Value );
                        //}
                        //else
                        //{
                        //    gridCarModel.Rows[i].Cells[ColEdTypeOfYear].Value =
                        //        string.Format( "{0:####年 ##月}", gridCarModel.Rows[i].Cells[colEdProduceTypeOfYear].Value );
                        //}

                        if ( gridCarModel.Rows[i].Cells[ColEdTypeOfYear].Value != DBNull.Value ||
                            (int)gridCarModel.Rows[i].Cells[ColEdTypeOfYear].Value > 0 )
                        {
                            if ( eraNameDispDiv ) // 和暦表示か
                            {
                                try
                                {
                                    gridCarModel.Rows[i].Cells[ColEdTypeOfYear].Value =
                                    //---- UPD 譚洪  2019/01/08 FOR 新元号の対応 ---->>>>>
                                    //    string.Format( dtfi, "{0:gg yy年 MM月}", gridCarModel.Rows[i].Cells[colEdProduceYear].Value );
                                        GetStrFromDt(DateTime.Parse(gridCarModel.Rows[i].Cells[colEdProduceYear].Value.ToString()));
                                    //---- UPD 譚洪  2019/01/08 FOR 新元号の対応 ----<<<<<
                                }
                                catch
                                {
                                    gridCarModel.Rows[i].Cells[ColEdTypeOfYear].Value = DBNull.Value;
                                }
                            }
                            else
                            {
                                gridCarModel.Rows[i].Cells[ColEdTypeOfYear].Value =
                                    string.Format( "{0:####年 ##月}", gridCarModel.Rows[i].Cells[colEdProduceTypeOfYear].Value );
                            }
                        }
                        else
                        {
                            gridCarModel.Rows[i].Cells[ColEdTypeOfYear].Value = DBNull.Value;
                        }
                        // --- UPD m.suzuki 2010/06/04 ----------<<<<<
                    }
                    if (gridCarModel.Rows[i].Cells[colEdProduceFrameNo].Value.Equals(99999999))
                    {
                        gridCarModel.Rows[i].Cells[ColEdFrameNo].Value = "-   ";
                    }
                    else
                    {
                        gridCarModel.Rows[i].Cells[ColEdFrameNo].Value =
                            string.Format("{0:#}", gridCarModel.Rows[i].Cells[colEdProduceFrameNo].Value);
                    }
                    for (int j = 0; j < gridCarModel.Rows[i].ChildBands[0].Rows.Count; j++)
                    {
                        // --- UPD m.suzuki 2010/05/11 ---------->>>>>
                        //if (gridCarModel.Rows[i].ChildBands[0].Rows[j].Cells[_carModelRel.CarModelDt.PartsOfferFlagColumn.ColumnName].Value.Equals(0))
                        //    gridCarModel.Rows[i].ChildBands[0].Rows[j].Cells[ColPartsEx].Value = img;
                        if ( gridCarModel.Rows[i].ChildBands[0].Rows[j].Cells["FreeSearchSortDiv"].Value.Equals( 0 ) )
                        {
                            // 自由検索
                            gridCarModel.Rows[i].ChildBands[0].Rows[j].Cells[ColPartsEx].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                            gridCarModel.Rows[i].ChildBands[0].Rows[j].Cells[ColPartsEx].Value = "自由検索";
                        }
                        else if ( gridCarModel.Rows[i].ChildBands[0].Rows[j].Cells[_carModelRel.CarModelDt.PartsOfferFlagColumn.ColumnName].Value.Equals( 0 ) )
                        {
                            // 部品未収録（×アイコン）
                            gridCarModel.Rows[i].ChildBands[0].Rows[j].Cells[ColPartsEx].Value = img;
                        }
                        // --- UPD m.suzuki 2010/05/11 ----------<<<<<
                    }
                    // --- ADD m.suzuki 2010/05/11 ---------->>>>>
                    // TODO : 開始年式の空白判定
                    // --- ADD m.suzuki 2010/05/11 ----------<<<<<
                }
            }

            gridCarModel.EndUpdate();
            gridCarModel.UpdateData();

        }

        //private void SelectAll()
        //{
        //    gridCarModel.BeginUpdate();
        //    try
        //    {
        //        isSelectChangeDisabled = true;
        //        gridCarModel.Selected.Rows.Clear();

        //        foreach (UltraGridRow ulRow in gridCarModel.Rows)
        //        {
        //            if (!ulRow.IsFilteredOut)
        //            {
        //                gridCarModel.Selected.Rows.Add(ulRow);
        //            }
        //        }
        //    }
        //    finally
        //    {
        //        isSelectChangeDisabled = false;
        //        gridCarModel.EndUpdate();
        //    }
        //}
        #endregion

        private void label_CarName_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Brush myBrush = Brushes.Black;
            Rectangle bound = new Rectangle(e.Bounds.Left, e.Bounds.Top + 2, e.Bounds.Width, e.Bounds.Height);

            e.Graphics.DrawString(label_CarName.Items[e.Index].ToString(), e.Font, myBrush, bound, StringFormat.GenericDefault);
            //e.DrawFocusRectangle();
        }

        private void label_CarName_SelectedValueChanged(object sender, EventArgs e)
        {
            label_CarName.SelectedIndex = -1;
        }
#if Tuning
        private void InitializeComponentCustom()
        {
            this.components = new System.ComponentModel.Container();

        #region Instantiation
            this.dtProduceTypeOfYear = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.gridCarModel = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.SelectionForm_Fill_Panel = new System.Windows.Forms.Panel();
            this.gridCondition = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraDataSource5 = new Infragistics.Win.UltraWinDataSource.UltraDataSource(this.components);
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.label_CarName = new System.Windows.Forms.ListBox();
            this.labelModel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelFrameNo = new System.Windows.Forms.Label();
            this.labelYear = new System.Windows.Forms.Label();
            this.label_CarCode = new System.Windows.Forms.Label();
            this.txtFrameNo = new Broadleaf.Library.Windows.Forms.TEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ultraDataSource3 = new Infragistics.Win.UltraWinDataSource.UltraDataSource(this.components);
            this.ultraDataSource2 = new Infragistics.Win.UltraWinDataSource.UltraDataSource(this.components);
            this.ultraDataSource1 = new Infragistics.Win.UltraWinDataSource.UltraDataSource(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.ultraDataSource4 = new Infragistics.Win.UltraWinDataSource.UltraDataSource(this.components);
            this._SelectionForm_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ToolbarsManager = new Broadleaf.Library.Windows.Forms.TToolbarsManager(this.components);
            this._SelectionForm_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SelectionForm_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SelectionForm_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
        #endregion

            ((System.ComponentModel.ISupportInitialize)(this.gridCarModel)).BeginInit();
            this.SelectionForm_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrameNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToolbarsManager)).BeginInit();

            this.SuspendLayout();
            Thread InitializeCompoSub = new Thread(InitializeComponentCustomSub);
            InitializeCompoSub.Start();

            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();

            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();

        #region その他
            // 
            // dtProduceTypeOfYear
            // 
            this.dtProduceTypeOfYear.ActiveEditAppearance = appearance10;
            this.dtProduceTypeOfYear.BackColor = System.Drawing.Color.Transparent;
            this.dtProduceTypeOfYear.CalendarDisp = false;
            this.dtProduceTypeOfYear.DateFormat = Broadleaf.Library.Windows.Forms.emDateFormat.df4Y2M;
            appearance11.TextHAlignAsString = "Left";
            appearance11.TextVAlignAsString = "Middle";
            this.dtProduceTypeOfYear.EditAppearance = appearance11;
            this.dtProduceTypeOfYear.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.dtProduceTypeOfYear.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance12.TextHAlignAsString = "Left";
            appearance12.TextVAlignAsString = "Middle";
            this.dtProduceTypeOfYear.LabelAppearance = appearance12;
            this.dtProduceTypeOfYear.Location = new System.Drawing.Point(75, 63);
            this.dtProduceTypeOfYear.Name = "dtProduceTypeOfYear";
            this.dtProduceTypeOfYear.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.dtProduceTypeOfYear.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.dtProduceTypeOfYear.Size = new System.Drawing.Size(114, 24);
            this.dtProduceTypeOfYear.TabIndex = 2;
            this.dtProduceTypeOfYear.TabStop = true;
            this.dtProduceTypeOfYear.Validating += new System.ComponentModel.CancelEventHandler(this.dtProduceTypeOfYear_Validating);
            this.dtProduceTypeOfYear.Enter += new System.EventHandler(this.ConditionSettingBegin);

            // 
            // label_CarName
            // 
            this.label_CarName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.label_CarName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.label_CarName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.label_CarName.FormattingEnabled = true;
            this.label_CarName.Location = new System.Drawing.Point(195, 33);
            this.label_CarName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label_CarName.Name = "label_CarName";
            this.label_CarName.Size = new System.Drawing.Size(233, 24);
            this.label_CarName.TabIndex = 11;
            this.label_CarName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.label_CarName_DrawItem);
            this.label_CarName.SelectedValueChanged += new System.EventHandler(this.label_CarName_SelectedValueChanged);
            // 
            // labelModel
            // 
            this.labelModel.BackColor = System.Drawing.Color.Transparent;
            this.labelModel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelModel.Location = new System.Drawing.Point(527, 33);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(264, 24);
            this.labelModel.TabIndex = 9;
            this.labelModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(434, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "型式";
            //this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelFrameNo
            // 
            this.labelFrameNo.BackColor = System.Drawing.Color.Transparent;
            this.labelFrameNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelFrameNo.Location = new System.Drawing.Point(625, 63);
            this.labelFrameNo.Name = "labelFrameNo";
            this.labelFrameNo.Size = new System.Drawing.Size(166, 24);
            this.labelFrameNo.TabIndex = 10;
            this.labelFrameNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelYear
            // 
            this.labelYear.BackColor = System.Drawing.Color.Transparent;
            this.labelYear.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelYear.Location = new System.Drawing.Point(195, 63);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(234, 24);
            this.labelYear.TabIndex = 7;
            this.labelYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_CarCode
            // 
            this.label_CarCode.BackColor = System.Drawing.Color.Transparent;
            this.label_CarCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_CarCode.Location = new System.Drawing.Point(75, 33);
            this.label_CarCode.Name = "label_CarCode";
            this.label_CarCode.Size = new System.Drawing.Size(114, 24);
            this.label_CarCode.TabIndex = 0;
            this.label_CarCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFrameNo
            // 
            this.txtFrameNo.ActiveAppearance = appearance44;
            this.txtFrameNo.AutoSelect = true;
            this.txtFrameNo.DataText = "";
            this.txtFrameNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.txtFrameNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 36, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.txtFrameNo.Location = new System.Drawing.Point(527, 63);
            this.txtFrameNo.MaxLength = 36;
            this.txtFrameNo.Name = "txtFrameNo";
            this.txtFrameNo.Size = new System.Drawing.Size(90, 24);
            this.txtFrameNo.TabIndex = 4;
            this.txtFrameNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtFrameNo_Validating);
            this.txtFrameNo.Enter += new System.EventHandler(this.ConditionSettingBegin);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(434, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "車台番号(&F)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "年式(&Y)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "車種";

            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.AlwaysEvent = true;
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.AlwaysEvent = true;
            this.tRetKeyControl1.CatchMouse = true;
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);

        #endregion

        #region Container
            // 
            // StatusBar
            // 
            this.StatusBar.Location = new System.Drawing.Point(0, 606);
            this.StatusBar.Margin = new System.Windows.Forms.Padding(4);
            this.StatusBar.Name = "StatusBar";
            ultraStatusPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            this.StatusBar.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1});
            this.StatusBar.Size = new System.Drawing.Size(982, 29);
            this.StatusBar.TabIndex = 3;
            this.StatusBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // SelectionForm_Fill_Panel
            // 
            this.SelectionForm_Fill_Panel.Controls.Add(this.gridCondition);
            this.SelectionForm_Fill_Panel.Controls.Add(this.ultraGroupBox1);
            this.SelectionForm_Fill_Panel.Controls.Add(this.gridCarModel);
            this.SelectionForm_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.SelectionForm_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectionForm_Fill_Panel.Location = new System.Drawing.Point(0, 26);
            this.SelectionForm_Fill_Panel.Name = "SelectionForm_Fill_Panel";
            this.SelectionForm_Fill_Panel.Size = new System.Drawing.Size(982, 580);
            this.SelectionForm_Fill_Panel.TabIndex = 4;

            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularSolid;
            appearance8.BackColor = System.Drawing.Color.White;
            appearance8.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance8.BorderColor = System.Drawing.Color.MidnightBlue;
            this.ultraGroupBox1.ContentAreaAppearance = appearance8;
            this.ultraGroupBox1.Controls.Add(this.label_CarName);
            this.ultraGroupBox1.Controls.Add(this.labelModel);
            this.ultraGroupBox1.Controls.Add(this.label4);
            this.ultraGroupBox1.Controls.Add(this.labelFrameNo);
            this.ultraGroupBox1.Controls.Add(this.labelYear);
            this.ultraGroupBox1.Controls.Add(this.label_CarCode);
            this.ultraGroupBox1.Controls.Add(this.txtFrameNo);
            this.ultraGroupBox1.Controls.Add(this.label3);
            this.ultraGroupBox1.Controls.Add(this.label2);
            this.ultraGroupBox1.Controls.Add(this.label1);
            this.ultraGroupBox1.Controls.Add(this.dtProduceTypeOfYear);
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(60)))), ((int)(((byte)(151)))));
            appearance13.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(134)))), ((int)(((byte)(213)))));
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance13.ForeColor = System.Drawing.Color.White;
            this.ultraGroupBox1.HeaderAppearance = appearance13;
            this.ultraGroupBox1.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(981, 98);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.Text = "型式検索条件";
        #endregion

        #region ToolbarsManager
            // 
            // ToolbarsManager
            // 
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Main");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Button_Select");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Button_Back");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Button_SelectAll");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Button_ChangeDisplay");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Button_Clear");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Button_Category");
            Infragistics.Win.UltraWinToolbars.ButtonTool labelTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("LblCntDisplay");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Button_Select");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Button_SelectAll");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Button_Back");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Button_Category");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Button_ChangeDisplay");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Button_Clear");
            Infragistics.Win.UltraWinToolbars.ButtonTool labelTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("LblCntDisplay");

            this.ToolbarsManager.DesignerFlags = 0;
            this.ToolbarsManager.DockWithinContainer = this;
            this.ToolbarsManager.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.ToolbarsManager.ShowFullMenusDelay = 500;
            this.ToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            buttonTool3.InstanceProps.IsFirstInGroup = true;
            buttonTool6.InstanceProps.IsFirstInGroup = true;
            labelTool1.InstanceProps.IsFirstInGroup = true;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            buttonTool4,
            buttonTool5,
            buttonTool6,
            labelTool1});
            ultraToolbar1.Settings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockRight = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.ToolDisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            ultraToolbar1.Text = "型式選択ツールバー";
            this.ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            buttonTool7.SharedProps.Caption = "確定(F10)";
            buttonTool7.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F10;
            buttonTool8.SharedProps.Caption = "全選択(F6)";
            buttonTool8.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F6;
            buttonTool8.SharedProps.ToolTipText = "表示されている全ての行を選択します。";
            buttonTool9.SharedProps.Caption = "戻る(F11)";
            buttonTool9.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F11;
            buttonTool9.SharedProps.ToolTipText = "前の画面に戻ります。";
            buttonTool10.SharedProps.Caption = "類別表示(F9)";
            buttonTool10.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F9;
            buttonTool11.SharedProps.Caption = "表示切替(F7)";
            buttonTool11.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F7;
            buttonTool12.SharedProps.Caption = "絞込条件クリア(F8)";
            buttonTool12.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F8;
            buttonTool12.SharedProps.Visible = false;
            appearance3.FontData.BoldAsString = "True";
            appearance3.TextHAlignAsString = "Center";
            labelTool2.SharedProps.AppearancesSmall.Appearance = appearance3;
            this.ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool7,
            buttonTool8,
            buttonTool9,
            buttonTool10,
            buttonTool11,
            buttonTool12,
            labelTool2});
            this.ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ToolbarsManager_ToolClick);
        #endregion

        #region SelectionForm_Toolbars_Dock_Area
            // 
            // _SelectionForm_Toolbars_Dock_Area_Left
            // 
            this._SelectionForm_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SelectionForm_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SelectionForm_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._SelectionForm_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SelectionForm_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 26);
            this._SelectionForm_Toolbars_Dock_Area_Left.Name = "_SelectionForm_Toolbars_Dock_Area_Left";
            this._SelectionForm_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 580);
            this._SelectionForm_Toolbars_Dock_Area_Left.ToolbarsManager = this.ToolbarsManager;
            // 
            // _SelectionForm_Toolbars_Dock_Area_Right
            // 
            this._SelectionForm_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SelectionForm_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SelectionForm_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._SelectionForm_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SelectionForm_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(982, 26);
            this._SelectionForm_Toolbars_Dock_Area_Right.Name = "_SelectionForm_Toolbars_Dock_Area_Right";
            this._SelectionForm_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 580);
            this._SelectionForm_Toolbars_Dock_Area_Right.ToolbarsManager = this.ToolbarsManager;
            // 
            // _SelectionForm_Toolbars_Dock_Area_Top
            // 
            this._SelectionForm_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SelectionForm_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SelectionForm_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._SelectionForm_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SelectionForm_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._SelectionForm_Toolbars_Dock_Area_Top.Name = "_SelectionForm_Toolbars_Dock_Area_Top";
            this._SelectionForm_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(982, 26);
            this._SelectionForm_Toolbars_Dock_Area_Top.ToolbarsManager = this.ToolbarsManager;
            // 
            // _SelectionForm_Toolbars_Dock_Area_Bottom
            // 
            this._SelectionForm_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SelectionForm_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SelectionForm_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._SelectionForm_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SelectionForm_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 606);
            this._SelectionForm_Toolbars_Dock_Area_Bottom.Name = "_SelectionForm_Toolbars_Dock_Area_Bottom";
            this._SelectionForm_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(982, 0);
            this._SelectionForm_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ToolbarsManager;
        #endregion

        #region [ SelectionForm ]
            // 
            // SelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 635);
            this.Controls.Add(this.SelectionForm_Fill_Panel);
            this.Controls.Add(this._SelectionForm_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._SelectionForm_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._SelectionForm_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._SelectionForm_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.StatusBar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(990, 400);
            this.Name = "SelectionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "型式選択";
            this.Shown += new System.EventHandler(this.SelectionForm_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SelectionForm_FormClosed);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SelectionForm_KeyPress);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectionForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectionForm_KeyDown);
        #endregion

            ((System.ComponentModel.ISupportInitialize)(this.gridCarModel)).EndInit();
            this.SelectionForm_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrameNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToolbarsManager)).EndInit();

            this.ResumeLayout(false);
        }

        private void InitializeComponentCustomSub()
        {
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
        #region  gridCarModel
            // 
            // gridCarModel
            // 
            this.gridCarModel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.gridCarModel.DisplayLayout.Appearance = appearance1;
            this.gridCarModel.DisplayLayout.GroupByBox.Hidden = true;
            this.gridCarModel.DisplayLayout.InterBandSpacing = 10;
            this.gridCarModel.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.gridCarModel.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.gridCarModel.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.gridCarModel.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.gridCarModel.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.gridCarModel.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.gridCarModel.DisplayLayout.Override.CardAreaAppearance = appearance2;
            this.gridCarModel.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.gridCarModel.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance15.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance15.ForeColor = System.Drawing.Color.White;
            appearance15.TextHAlignAsString = "Left";
            appearance15.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.gridCarModel.DisplayLayout.Override.HeaderAppearance = appearance15;
            this.gridCarModel.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            this.gridCarModel.DisplayLayout.Override.HeaderPlacement = Infragistics.Win.UltraWinGrid.HeaderPlacement.FixedOnTop;
            this.gridCarModel.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.gridCarModel.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.ForeColor = System.Drawing.Color.White;
            this.gridCarModel.DisplayLayout.Override.RowSelectorAppearance = appearance6;
            this.gridCarModel.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            this.gridCarModel.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.gridCarModel.DisplayLayout.Override.RowSelectorWidth = 36;
            this.gridCarModel.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance7.ForeColor = System.Drawing.Color.Black;
            this.gridCarModel.DisplayLayout.Override.SelectedRowAppearance = appearance7;
            this.gridCarModel.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.gridCarModel.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.gridCarModel.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            this.gridCarModel.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.gridCarModel.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.gridCarModel.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridCarModel.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridCarModel.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.gridCarModel.Location = new System.Drawing.Point(1, 143);
            this.gridCarModel.Margin = new System.Windows.Forms.Padding(2);
            this.gridCarModel.Name = "gridCarModel";
            this.gridCarModel.Size = new System.Drawing.Size(980, 437);
            this.gridCarModel.TabIndex = 1;
            this.gridCarModel.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.gridCarModel_AfterSelectChange);
            this.gridCarModel.Leave += new System.EventHandler(this.gridCarModel_Leave);
            this.gridCarModel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridCarModel_KeyDown);
            this.gridCarModel.AfterSortChange += new Infragistics.Win.UltraWinGrid.BandEventHandler(this.gridCarModel_AfterSortChange);
            this.gridCarModel.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.gridCarModel_DoubleClickRow);
        #endregion


            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);

        #region gridCondition
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ModelGradeNm");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BodyName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DoorCount");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EngineModelNm");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EngineDisplaceNm");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EDivNm");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TransmissionNm");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ShiftNm");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("WheelDriveMethodNm");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NoData");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AddiCarSpec1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AddiCarSpec2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AddiCarSpec3");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AddiCarSpec4");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AddiCarSpec5");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AddiCarSpec6");

            // 
            // gridCondition
            // 
            this.gridCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridCondition.DataSource = this.ultraDataSource5;
            this.gridCondition.DisplayLayout.Appearance = appearance1;
            this.gridCondition.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            appearance4.TextHAlignAsString = "Center";
            ultraGridColumn1.Header.Appearance = appearance4;
            ultraGridColumn1.Header.Caption = "グレード";
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn1.Width = 59;
            ultraGridColumn2.Header.Appearance = appearance4;
            ultraGridColumn2.Header.Caption = "ボディー";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn2.Width = 54;
            ultraGridColumn3.Header.Appearance = appearance4;
            ultraGridColumn3.Header.Caption = "ドア";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn3.Width = 32;
            ultraGridColumn4.Header.Appearance = appearance4;
            ultraGridColumn4.Header.Caption = "エンジン";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn4.Width = 59;
            ultraGridColumn5.Header.Appearance = appearance4;
            ultraGridColumn5.Header.Caption = "排気量";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn5.Width = 35;
            ultraGridColumn6.Header.Appearance = appearance4;
            ultraGridColumn6.Header.Caption = "E区分";
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn6.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn6.Width = 66;
            ultraGridColumn7.Header.Appearance = appearance4;
            ultraGridColumn7.Header.Caption = "ミッション";
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn7.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn7.Width = 52;
            ultraGridColumn8.Header.Appearance = appearance4;
            ultraGridColumn8.Header.Caption = "シフト";
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn8.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn8.Width = 46;
            ultraGridColumn9.Header.Appearance = appearance4;
            ultraGridColumn9.Header.Caption = "駆動方式";
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn9.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn9.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn9.Width = 40;
            ultraGridColumn10.Header.Caption = "";
            ultraGridColumn10.Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            ultraGridColumn10.Header.VisiblePosition = 9;
            ultraGridColumn10.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn10.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Image;
            ultraGridColumn10.Width = 66;
            ultraGridColumn11.Header.Appearance = appearance4;
            ultraGridColumn11.Header.VisiblePosition = 10;
            ultraGridColumn11.RowLayoutColumnInfo.OriginY = 2;
            ultraGridColumn11.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn11.Width = 75;
            ultraGridColumn12.Header.Appearance = appearance4;
            ultraGridColumn12.Header.VisiblePosition = 11;
            ultraGridColumn12.RowLayoutColumnInfo.OriginY = 2;
            ultraGridColumn12.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn12.Width = 75;
            ultraGridColumn13.Header.Appearance = appearance4;
            ultraGridColumn13.Header.VisiblePosition = 12;
            ultraGridColumn13.RowLayoutColumnInfo.OriginY = 2;
            ultraGridColumn13.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn13.Width = 75;
            ultraGridColumn14.Header.Appearance = appearance4;
            ultraGridColumn14.Header.VisiblePosition = 13;
            ultraGridColumn14.RowLayoutColumnInfo.OriginY = 2;
            ultraGridColumn14.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn14.Width = 75;
            ultraGridColumn15.Header.Appearance = appearance4;
            ultraGridColumn15.Header.VisiblePosition = 14;
            ultraGridColumn15.RowLayoutColumnInfo.OriginY = 2;
            ultraGridColumn15.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn15.Width = 75;
            ultraGridColumn16.Header.Appearance = appearance4;
            ultraGridColumn16.Header.VisiblePosition = 15;
            ultraGridColumn16.RowLayoutColumnInfo.OriginY = 2;
            ultraGridColumn16.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn16.Width = 75;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16});
            ultraGridBand1.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            ultraGridBand1.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            ultraGridBand1.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            ultraGridBand1.Override.AllowRowLayoutCellSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            ultraGridBand1.Override.AllowRowLayoutColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.None;
            ultraGridBand1.Override.AllowRowLayoutLabelSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            this.gridCondition.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridCondition.DisplayLayout.Override.HeaderAppearance = appearance15;
            this.gridCondition.DisplayLayout.Override.RowSelectorAppearance = appearance6;
            this.gridCondition.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement;
            this.gridCondition.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.gridCondition.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.gridCondition.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.None;
            this.gridCondition.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.gridCondition.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gridCondition.Location = new System.Drawing.Point(1, 97);
            this.gridCondition.Name = "gridCondition";
            this.gridCondition.Size = new System.Drawing.Size(980, 45);
            this.gridCondition.TabIndex = 2;
            this.gridCondition.CellListSelect += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.gridCondition_CellListSelect);
        #endregion

        #region ultraDataSource
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn1 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("ModelGradeNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn2 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("BodyName");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn3 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("DoorCount");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn4 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("EngineModelNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn5 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("EngineDisplaceNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn6 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("EDivNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn7 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("TransmissionNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn8 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("ShiftNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn9 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("WheelDriveMethodNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn10 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("NoData");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn11 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("AddiCarSpec1");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn12 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("AddiCarSpec2");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn13 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("AddiCarSpec3");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn14 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("AddiCarSpec4");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn15 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("AddiCarSpec5");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn16 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("AddiCarSpec6");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn17 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("ModelGradeNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn18 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("BodyName");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn19 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("DoorCount");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn20 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("EngineModelNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn21 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("EngineDisplaceNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn22 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("EDivNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn23 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("TransmissionNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn24 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("ShiftNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn25 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("WheelDriveMethodNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn26 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("ModelGradeNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn27 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("BodyName");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn28 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("DoorCount");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn29 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("EngineModelNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn30 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("EngineDisplaceNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn31 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("EDivNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn32 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("TransmissionNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn33 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("ShiftNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn34 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("WheelDriveMethodNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn35 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("PartsExistence");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn36 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("ModelGradeNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn37 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("BodyName");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn38 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("DoorCount");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn39 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("EngineModelNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn40 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("EngineDisplaceNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn41 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("EDivNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn42 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("TransmissionNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn43 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("ShiftNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn44 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("WheelDriveMethodNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn45 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("ModelGradeNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn46 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("BodyName");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn47 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("DoorCount");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn48 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("EngineModelNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn49 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("EngineDisplaceNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn50 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("EDivNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn51 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("TransmissionNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn52 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("ShiftNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn53 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("WheelDriveMethodNm");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn54 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("NoData");
            // 
            // ultraDataSource5
            // 
            this.ultraDataSource5.Band.Columns.AddRange(new object[] {
            ultraDataColumn1,
            ultraDataColumn2,
            ultraDataColumn3,
            ultraDataColumn4,
            ultraDataColumn5,
            ultraDataColumn6,
            ultraDataColumn7,
            ultraDataColumn8,
            ultraDataColumn9,
            ultraDataColumn10,
            ultraDataColumn11,
            ultraDataColumn12,
            ultraDataColumn13,
            ultraDataColumn14,
            ultraDataColumn15,
            ultraDataColumn16});
            // 
            // ultraDataSource3
            // 
            this.ultraDataSource3.Band.Columns.AddRange(new object[] {
            ultraDataColumn17,
            ultraDataColumn18,
            ultraDataColumn19,
            ultraDataColumn20,
            ultraDataColumn21,
            ultraDataColumn22,
            ultraDataColumn23,
            ultraDataColumn24,
            ultraDataColumn25});
            // 
            // ultraDataSource2
            // 
            this.ultraDataSource2.Band.Columns.AddRange(new object[] {
            ultraDataColumn26,
            ultraDataColumn27,
            ultraDataColumn28,
            ultraDataColumn29,
            ultraDataColumn30,
            ultraDataColumn31,
            ultraDataColumn32,
            ultraDataColumn33,
            ultraDataColumn34,
            ultraDataColumn35});
            // 
            // ultraDataSource1
            // 
            ultraDataColumn36.DefaultValue = "\"\"";
            this.ultraDataSource1.Band.Columns.AddRange(new object[] {
            ultraDataColumn36,
            ultraDataColumn37,
            ultraDataColumn38,
            ultraDataColumn39,
            ultraDataColumn40,
            ultraDataColumn41,
            ultraDataColumn42,
            ultraDataColumn43,
            ultraDataColumn44});
            // 
            // ultraDataSource4
            // 
            this.ultraDataSource4.Band.Columns.AddRange(new object[] {
            ultraDataColumn45,
            ultraDataColumn46,
            ultraDataColumn47,
            ultraDataColumn48,
            ultraDataColumn49,
            ultraDataColumn50,
            ultraDataColumn51,
            ultraDataColumn52,
            ultraDataColumn53,
            ultraDataColumn54});

        #endregion
        }
#endif
    }
}