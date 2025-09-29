//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 在庫仕入伝票照会
// プログラム概要   : 在庫仕入伝票照会フォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鈴木 正臣
// 作 成 日  2008/09/02  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/11/17  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/02/05  修正内容 : 不具合対応[10681]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2009/03/12  修正内容 : 不具合対応[12294]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/02  修正内容 : 不具合対応[13064]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/03  修正内容 : 不具合対応[12857]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/13  修正内容 : 上野 俊治[13113]
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 在庫仕入伝票照会フォームクラス（伝票毎）
    /// </summary>
    /// <remarks>
    /// Note       : 在庫仕入伝票の一覧表示を行うフォームクラスです。<br />
    /// Programmer : 22018 鈴木 正臣<br />
    /// Date       : 2008.09.02<br />
    /// <br />
    /// Update Note: 2008/11/17 照田 貴志　バグ修正、仕様変更対応<br />
    /// <br>         2009/02/05 照田 貴志　不具合対応[10681]</br>
    /// <br>         2009/03/12 忍 幸史　不具合対応[12294]</br>
    /// <br>         2009/04/02 上野 俊治　不具合対応[13064]</br>
    /// <br>         2009/04/03 照田 貴志　不具合対応[12857]</br>
    /// <br>         2009/04/13 上野 俊治　不具合対応[13113]</br>
    /// </remarks>
	public partial class PMZAI04001UA : Form
    {
        # region [privateフィールド]
        private StockAdjRefAcs _searchSlipAcs;
        private StockAdjDataSet _dataSet;
        private PMZAI04001UB _inputDetails;
        private StockAdjRefSearchParaWork _paraStockSlipCache_Display;
        private SecInfoSetAcs _secInfoSetAcs;
		private WarehouseAcs _warehouseAcs;
        private MakerAcs _makerAcs;
        private EmployeeAcs _employeeAcs;

        // 締日算出モジュール
        private TotalDayCalculator _totalDayCalculator;     //ADD 2008/11/17

        private string _enterpriseCode;             // 企業コード
        private string _loginSectionCode;           // 自拠点コード
        private bool _optSection;                   // 拠点オプション有無フラグ
        private bool _mainOfficeFunc;               // 本社/拠点判断フラグ
        private ImageList _imageList16 = null;									// イメージリスト
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;		// 終了ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _decisionButton;	// 確定ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _undoButton;		// 取消ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;		// 検索ボタン
        private ControlScreenSkin _controlScreenSkin;
        private DialogResult _dialogRes = DialogResult.Cancel;
        # endregion

        # region [private const]
        private const string MESSAGE_StartEndError = "開始≦終了となるよう設定してください。";
        private const string MESSAGE_NoInput = "必須入力項目です。";
        private const string MESSAGE_InvalidDate = "有効な日付ではありません。";

        // 2009.01.06 add [9633]
        /// <summary> 全社コード [00] </summary>
        private const string WHOLE_SECTION_CODE = "00";
        /// <summary> 全社名称 [全社] </summary>
        private const string WHOLE_SECTION_NAME = "全社";
        // 2009.01.06 add [9633]
        # endregion

        # region [public プロパティ]
        /// <summary>
        /// 選択伝票データ取得プロパティ
        /// </summary>
        public StockAdjRefSearchRetWork StockAdjRefSearchRetWork
        {
            get { return this._inputDetails._stockAdjRefSearchRetWork; }
        }

        ///// <summary>
        ///// プロパティ
        ///// </summary>
        //public bool TComboEditor_SupplierFormal
        //{
        //    get {return this.tComboEditor_SupplierFormal.Enabled; }
        //    set {this.tComboEditor_SupplierFormal.Enabled = value;}
        //}
        # endregion


        # region [コンストラクタ]
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public PMZAI04001UA()
        {
            InitializeComponent();

            // 変数初期化
            this._searchSlipAcs = StockAdjRefAcs.GetInstance();
            this._dataSet = _searchSlipAcs.DataSet;
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            this._decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"];
            this._undoButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Undo"];
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];
            this._controlScreenSkin = new ControlScreenSkin();

            this._paraStockSlipCache_Display = new StockAdjRefSearchParaWork();
            if ( this._searchSlipAcs.GetParaStockSlipCache() != null )
            {
                this._paraStockSlipCache_Display = this._searchSlipAcs.GetParaStockSlipCache();
            }

            this._inputDetails = new PMZAI04001UB();
            this._inputDetails.StatusBarMessageSetting += new PMZAI04001UB.SettingStatusBarMessageEventHandler( this.SetStatusBarMessage );
            this._searchSlipAcs.StatusBarMessageSetting += new StockAdjRefAcs.SettingStatusBarMessageEventHandler( this.SetStatusBarMessage );
            this._inputDetails.CloseMain += new PMZAI04001UB.CloseMainEventHandler( this.CloseForm );
            this._inputDetails.SetMainDialogResult += new PMZAI04001UB.SetDialogResEventHandler( this.SetDialogRes );
            this._inputDetails.DecisionButtonEnableSet += new PMZAI04001UB.SettingDecisionButtonEnableEventHandler( this.ChangeDecisionButtonEnable );
            this._searchSlipAcs.GetNameList += new StockAdjRefAcs.GetNameListEventHandler( this.GetDisplayNameList );
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="startMovment"></param>
        /// <remarks>
        /// <br>照会EXEから単独起動する場合は引数=1を与えて制御します。</br>
        /// </remarks>
        public PMZAI04001UA( int startMovment )
            : this()
        {
            this._inputDetails.StartMovment = startMovment;
            if ( this._inputDetails.StartMovment == 0 )
            {
                //------------------------------------------------
                // エントリからの照会呼び出し
                //------------------------------------------------
                // 伝票区分をエントリ「入力分」で固定にする
                tComboEditor_AcPaySlipCd.Value = 13;
                tComboEditor_AcPaySlipCd.Enabled = false;
            }
            else
            {
                //------------------------------------------------
                // startMovment=1 は照会EXEからの起動(選択機能なし)
                //------------------------------------------------
                // 確定ボタンを隠す
                ChangeDecisionButtonEnable( false );
                ChangeDecisionButtonVisible( false );
            }
        }
        # endregion


        # region [初期化処理]
        /// <summary>
        /// 画面初期情報設定処理
        /// </summary>
        private void SetInitialInput()
        {
            StockAdjDataSet.StockAdjustDataTable stockDatail = this._searchSlipAcs.GetStockSlipTableCache();

            // 締日算出モジュール
            _totalDayCalculator = TotalDayCalculator.GetInstance();         //ADD 2008/11/17

            // 拠点情報表示切替
            if (this._optSection == false)
            {
                // 拠点オプション無し
                ChangeSectionDisplay(false,false);
            }
            else
            {
                if (this._mainOfficeFunc == false)
                {
                    // 拠点設定
                    ChangeSectionDisplay(true, false);
                }
                else
                {
                    // 本社設定
                    ChangeSectionDisplay(true, true);
                }
            }

            // 前回検索情報有無判断
            if ((stockDatail == null) ||
                (stockDatail.Count == 0))
            {
                // グリッド情報クリア
                this._searchSlipAcs.ClearStockAdjustDataTable();

                // ヘッダ情報クリア処理
                this.ClearDisplayHeader();

                // ヘッダ初期表示処理
                this.SetDisplayHeaderInfo();
            }
            else
            {
                // 前回起動ヘッダ情報設定処理
                this.SetPrevHeader();

                // グリッドに初期フォーカスを設定
                this._inputDetails.timer_GridSetFocus.Enabled = true;
            }
        }
		
        /// <summary>
        /// 画面ヘッダクリア処理
        /// </summary>
        private void ClearDisplayHeader()
        {
            // 拠点
            this.tEdit_SectionCode.Text = string.Empty;
            this.uLabel_SectionName.Text = string.Empty;

            // 倉庫
            this.tEdit_WarehouseCode.Text = string.Empty;
            this.uLabel_WarehouseName.Text = string.Empty;

            // 受払元伝票区分
            this.tComboEditor_AcPaySlipCd.SelectedIndex = 0;

            // 入力日
            this.tDateEdit_St_InputDay.Clear();
            this.tDateEdit_Ed_InputDay.Clear();

            // 作成日
            /* --- DEL 2008/11/17 初期値変更 -------------------------->>>>>
            this.tDateEdit_St_AdjustDate.SetDateTime( DateTime.Today );
            this.tDateEdit_Ed_AdjustDate.SetDateTime( DateTime.Today );
               --- DEL 2008/11/17 -------------------------------------<<<<< */
            // --- ADD 2008/11/17 ------------------------------------->>>>>
            this.tDateEdit_St_AdjustDate.SetDateTime(this.GetPrevTotalDayNextDay(LoginInfoAcquisition.Employee.BelongSectionCode));
            this.tDateEdit_Ed_AdjustDate.SetDateTime(DateTime.Today);
            // --- ADD 2008/11/17 -------------------------------------<<<<<

            // 伝票番号
            this.tNedit_SupplierSlipNo_St.Clear();
            this.tNedit_SupplierSlipNo_Ed.Clear();

            // 担当者
            this.tEdit_StockAgentCode.Text = string.Empty;
            this.uLabel_StockAgentName.Text = string.Empty;

            // メーカー
            this.tNedit_GoodsMakerCd.Clear();
            this.uLabel_MakerName.Text = string.Empty;

            // 品番
            this.tEdit_GoodsNo.Text = string.Empty;
            // 品名
            this.tEdit_GoodsName.Text = string.Empty;
            // 棚番
            this.tEdit_WarehouseShelfNo.Text = string.Empty;


            this.ChangeDecisionButtonEnable( false );
            this.timer_InitialSetFocus.Enabled = true;
        }

        // --- ADD 2008/11/17 -------------------------------------------------------------------------------->>>>>
        /// <summary>
        /// 前回月次締処理日取得
        /// </summary>
        /// <returns></returns>
        private DateTime GetPrevTotalDayNextDay(string sectionCode)
        {
            DateTime prevTotalDay;
            int status = _totalDayCalculator.GetHisTotalDayMonthlyAccRec(sectionCode.Trim(), out prevTotalDay);

            // 取得日が不正な場合は３ヶ月前をセット
            if (status != 0 || prevTotalDay == DateTime.MinValue || prevTotalDay > DateTime.Today)
            {
                prevTotalDay = DateTime.Today.AddMonths(-3);
            }
            // 翌日取得
            prevTotalDay = prevTotalDay.AddDays(1);

            return prevTotalDay;
        }
        // --- ADD 2008/11/17 --------------------------------------------------------------------------------<<<<<

        /// <summary>
        /// 画面ヘッダ表示処理
        /// </summary>
        private void SetDisplayHeaderInfo()
        {
            // コンボボックス項目初期表示
            this.tComboEditor_AcPaySlipCd.SelectedIndex = 0;

            if ( this._inputDetails.StartMovment == 0 )
            {
                //------------------------------------------------
                // エントリからの照会呼び出し
                //------------------------------------------------
                // 伝票区分をエントリ「入力分」で固定にする
                tComboEditor_AcPaySlipCd.Value = 13;
                tComboEditor_AcPaySlipCd.Enabled = false;
            }
            else
            {
                //------------------------------------------------
                // 照会EXEからの起動(選択機能なし)
                //------------------------------------------------
                // 確定ボタンを隠す
                ChangeDecisionButtonEnable( false );
                ChangeDecisionButtonVisible( false );
                tComboEditor_AcPaySlipCd.Enabled = true;
            }

            // 日付項目初期表示
            this.tDateEdit_St_InputDay.Clear();
            this.tDateEdit_Ed_InputDay.Clear();
            /* --- DEL 2008/11/17 初期値変更 ------------------------------------------------------------------------------->>>>>
            this.tDateEdit_St_AdjustDate.SetDateTime( DateTime.Today );
			this.tDateEdit_Ed_AdjustDate.SetDateTime( DateTime.Today );
               --- DEL 2008/11/17 ------------------------------------------------------------------------------------------<<<<< */
            // --- ADD 2008/11/17 ------------------------------------------------------------------------------------------>>>>>
            this.tDateEdit_St_AdjustDate.SetDateTime(this.GetPrevTotalDayNextDay(LoginInfoAcquisition.Employee.BelongSectionCode));
            this.tDateEdit_Ed_AdjustDate.SetDateTime(DateTime.Today);
            // --- ADD 2008/11/17 ------------------------------------------------------------------------------------------<<<<<


            // 拠点設定
            this.tEdit_SectionCode.Text = this._loginSectionCode;
            this._paraStockSlipCache_Display.SectionCode = this._loginSectionCode;

            if ( _secInfoSetAcs == null )
            {
                _secInfoSetAcs = new SecInfoSetAcs();
            }

            SecInfoSet secInfoSet;
			int status = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, this._loginSectionCode);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm;
			}
        }

        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._decisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            this._undoButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;

            this.uButton_SectionGuide.ImageList = this._imageList16;
            this.uButton_WarehouseGuide.ImageList = this._imageList16;
            this.uButton_EmployeeGuide.ImageList = this._imageList16;
            this.uButton_GoodsMakerGuide.ImageList = this._imageList16;

            this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_WarehouseGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_EmployeeGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_GoodsMakerGuide.Appearance.Image = (int)Size16_Index.STAR1;
        }
        /// <summary>
        /// 拠点 表示切替処理
        /// </summary>
        private void ChangeSectionDisplay( bool visible, bool enabled )
        {
            this.uLabel_SectionTitle.Visible = visible;
            this.tEdit_SectionCode.Visible = visible;
            this.uLabel_SectionName.Visible = visible;
            this.uButton_SectionGuide.Visible = visible;

            this.uLabel_SectionTitle.Enabled = enabled;
            this.tEdit_SectionCode.Enabled = enabled;
            this.uLabel_SectionName.Enabled = enabled;
            this.uButton_SectionGuide.Enabled = enabled;
        }

        /// <summary>
        /// 前回起動ヘッダ情報設定処理
        /// </summary>
        private void SetPrevHeader()
        {
            StockAdjRefSearchParaWork stockAdjRefSearchParaWork = this._searchSlipAcs.GetParaStockSlipCache();

            if(stockAdjRefSearchParaWork == null)
            {
                return;
            }

            SortedList nameList = this._searchSlipAcs.GetCacheNmaeList();

			if (nameList == null)
			{
				return;
			}

            // 拠点
            this.tEdit_SectionCode.Text = stockAdjRefSearchParaWork.SectionCode;
            this.uLabel_SectionName.Text = nameList["SectionName"].ToString();
            // 倉庫
            this.tEdit_WarehouseCode.Text = stockAdjRefSearchParaWork.WarehouseCode;
            this.uLabel_WarehouseName.Text = nameList["WarehouseName"].ToString();
            // 伝票区分
            this.tComboEditor_AcPaySlipCd.Value = stockAdjRefSearchParaWork.AcPaySlipCd;
            // 入力日
            this.tDateEdit_St_InputDay.SetLongDate( stockAdjRefSearchParaWork.St_InputDay );
            this.tDateEdit_Ed_InputDay.SetLongDate( stockAdjRefSearchParaWork.Ed_InputDay );
            // 作成日
            this.tDateEdit_St_AdjustDate.SetLongDate( stockAdjRefSearchParaWork.St_AdjustDate );
            this.tDateEdit_Ed_AdjustDate.SetLongDate( stockAdjRefSearchParaWork.St_AdjustDate );
            // 伝票番号
            this.tNedit_SupplierSlipNo_St.SetInt( stockAdjRefSearchParaWork.St_StockAdjustSlipNo );
            this.tNedit_SupplierSlipNo_Ed.SetInt( stockAdjRefSearchParaWork.Ed_StockAdjustSlipNo );
            // 担当者
            this.tEdit_StockAgentCode.Text = stockAdjRefSearchParaWork.StockAgentCode;
            this.uLabel_StockAgentName.Text = nameList["StockAgentName"].ToString();
            // メーカー
            this.tNedit_GoodsMakerCd.SetInt( stockAdjRefSearchParaWork.GoodsMakerCd );
            this.uLabel_MakerName.Text = nameList["MakerName"].ToString();
            // 品番
            this.tEdit_GoodsNo.Text = GetSearchTextOrigin( stockAdjRefSearchParaWork.GoodsNo, stockAdjRefSearchParaWork.GoodsNoTyp );
            // 品名
            this.tEdit_GoodsName.Text = GetSearchTextOrigin( stockAdjRefSearchParaWork.GoodsName, stockAdjRefSearchParaWork.GoodsNameTyp );
            // 棚番
            this.tEdit_WarehouseShelfNo.Text = GetSearchTextOrigin( stockAdjRefSearchParaWork.WarehouseShelfNo, stockAdjRefSearchParaWork.WarehouseShelfNoTyp );
        }

        # endregion

        # region [読み込み条件]

        /// <summary>
        /// 読込条件パラメータ設定処理
        /// </summary>
        /// </return> 読込条件パラメータクラス
        public void SetReadPara(out StockAdjRefSearchParaWork stockAdjRefSearchParaWork)
        {
            stockAdjRefSearchParaWork = new StockAdjRefSearchParaWork();

			//企業コード
            stockAdjRefSearchParaWork.EnterpriseCode = this._enterpriseCode;

            // 拠点コード
            //stockAdjRefSearchParaWork.SectionCode = tEdit_SectionCode.Text;       //DEL 2009/02/05 不具合対応[10681]
            // ---ADD 2009/02/05 不具合対応[10681] -------------------------------------------------------------->>>>>
            if (tEdit_SectionCode.Text == "00")
            {
                stockAdjRefSearchParaWork.SectionCode = string.Empty;
            }
            else
            {
                stockAdjRefSearchParaWork.SectionCode = tEdit_SectionCode.Text;
            }
            // ---ADD 2009/02/05 不具合対応[10681] --------------------------------------------------------------<<<<<

            // 倉庫コード
            stockAdjRefSearchParaWork.WarehouseCode = tEdit_WarehouseCode.Text;
            
            // 受払元伝票区分
            stockAdjRefSearchParaWork.AcPaySlipCd = (int)tComboEditor_AcPaySlipCd.Value;

            // 受払元取引区分
            stockAdjRefSearchParaWork.AcPayTransCd = 0; // 0:未指定

            // 開始入力日付
            stockAdjRefSearchParaWork.St_InputDay = tDateEdit_St_InputDay.GetLongDate();
            
            // 終了入力日付
            stockAdjRefSearchParaWork.Ed_InputDay = tDateEdit_Ed_InputDay.GetLongDate();
            
            // 開始調整日付
            stockAdjRefSearchParaWork.St_AdjustDate = tDateEdit_St_AdjustDate.GetLongDate();
            
            // 終了調整日付
            stockAdjRefSearchParaWork.Ed_AdjustDate = tDateEdit_Ed_AdjustDate.GetLongDate();
            
            // 開始在庫調整伝票番号
            stockAdjRefSearchParaWork.St_StockAdjustSlipNo = tNedit_SupplierSlipNo_St.GetInt();
            
            // 終了在庫調整伝票番号
            stockAdjRefSearchParaWork.Ed_StockAdjustSlipNo = tNedit_SupplierSlipNo_Ed.GetInt();
            
            // 仕入担当者コード
            stockAdjRefSearchParaWork.StockAgentCode = tEdit_StockAgentCode.Text;
            
            // 商品メーカーコード
            stockAdjRefSearchParaWork.GoodsMakerCd = tNedit_GoodsMakerCd.GetInt();


            string searchText;
            int searchType;

            // 商品番号・商品番号検索タイプ
            GetSearchType( tEdit_GoodsNo.Text, out searchText, out searchType );
            stockAdjRefSearchParaWork.GoodsNo = searchText;
            stockAdjRefSearchParaWork.GoodsNoTyp = searchType;

            // 商品名称・商品名称検索タイプ
            GetSearchType( tEdit_GoodsName.Text, out searchText, out searchType );
            stockAdjRefSearchParaWork.GoodsName = searchText;
            stockAdjRefSearchParaWork.GoodsNameTyp = searchType;

            // 倉庫棚番・倉庫棚番検索タイプ
            GetSearchType( tEdit_WarehouseShelfNo.Text, out searchText, out searchType );
            stockAdjRefSearchParaWork.WarehouseShelfNo = searchText;
            stockAdjRefSearchParaWork.WarehouseShelfNoTyp = searchType;


			this._inputDetails._stockAdjRefSearchParaWork = stockAdjRefSearchParaWork;
			this._inputDetails.DisplayModeSetting();
        }

        /// <summary>
        /// 前回/今回検索条件比較処理
        /// </summary>
        /// <param name="">検索条件クラス(今回条件)</param>
        /// <returns>true:一致、false:不一致</returns>
        private bool CheckSearchParam(StockAdjRefSearchParaWork stockAdjRefSearchParaWork)
        {
            // 前回検索条件の取得
            StockAdjRefSearchParaWork prevStockAdjRefSearchParaWork = this._searchSlipAcs.GetParaStockSlipCache();
            if (prevStockAdjRefSearchParaWork == null)
            {
                return false;
            }

            // 拠点
            if ( stockAdjRefSearchParaWork.SectionCode != prevStockAdjRefSearchParaWork.SectionCode )
            {
                return false;
            }
            // 倉庫
            if ( stockAdjRefSearchParaWork.WarehouseCode != prevStockAdjRefSearchParaWork.WarehouseCode )
            {
                return false;
            }
            // 伝票区分
            if ( stockAdjRefSearchParaWork.AcPaySlipCd != prevStockAdjRefSearchParaWork.AcPaySlipCd )
            {
                return false;
            }
            // 入力日
            if ( stockAdjRefSearchParaWork.St_InputDay != prevStockAdjRefSearchParaWork.St_InputDay )
            {
                return false;
            }
            if ( stockAdjRefSearchParaWork.Ed_InputDay != prevStockAdjRefSearchParaWork.Ed_InputDay )
            {
                return false;
            }
            // 作成日
            if ( stockAdjRefSearchParaWork.St_AdjustDate != prevStockAdjRefSearchParaWork.St_AdjustDate )
            {
                return false;
            }
            if ( stockAdjRefSearchParaWork.Ed_AdjustDate != prevStockAdjRefSearchParaWork.Ed_AdjustDate )
            {
                return false;
            }
            // 伝票番号
            if ( stockAdjRefSearchParaWork.St_StockAdjustSlipNo != prevStockAdjRefSearchParaWork.St_StockAdjustSlipNo )
            {
                return false;
            }
            if ( stockAdjRefSearchParaWork.Ed_StockAdjustSlipNo != prevStockAdjRefSearchParaWork.Ed_StockAdjustSlipNo )
            {
                return false;
            }
            // 担当者
            if ( stockAdjRefSearchParaWork.StockAgentCode != prevStockAdjRefSearchParaWork.StockAgentCode )
            {
                return false;
            }
            // メーカー
            if ( stockAdjRefSearchParaWork.GoodsMakerCd != prevStockAdjRefSearchParaWork.GoodsMakerCd )
            {
                return false;
            }
            // 品番
            if ( stockAdjRefSearchParaWork.GoodsNo != prevStockAdjRefSearchParaWork.GoodsNo )
            {
                return false;
            }
            if ( stockAdjRefSearchParaWork.GoodsNoTyp != prevStockAdjRefSearchParaWork.GoodsNoTyp )
            {
                return false;
            }
            // 品名
            if ( stockAdjRefSearchParaWork.GoodsName != prevStockAdjRefSearchParaWork.GoodsName )
            {
                return false;
            }
            if ( stockAdjRefSearchParaWork.GoodsNameTyp != prevStockAdjRefSearchParaWork.GoodsNameTyp )
            {
                return false;
            }
            // 棚番
            if ( stockAdjRefSearchParaWork.WarehouseShelfNo != prevStockAdjRefSearchParaWork.WarehouseShelfNo )
            {
                return false;
            }
            if ( stockAdjRefSearchParaWork.WarehouseShelfNoTyp != prevStockAdjRefSearchParaWork.WarehouseShelfNoTyp )
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 終了項目値自動設定処理(TDateEdit)
        /// </summary>
        /// <param name="startDate">開始日付項目TDateEdit</param>
        /// <param name="endDate">終了日付項目TDateEdit</param>
        private void AutoSetEndValue( TDateEdit startDate, TDateEdit endDate )
        {
            // 終了日未入力ならば、終了日に開始日と同じ値をセットする
            if ( endDate.LongDate == 0 )
            {
                endDate.SetLongDate( startDate.LongDate );
            }
        }

        /// <summary>
        /// 文字列あいまい検索情報取得
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private void GetSearchType( string originText, out string searchText, out int searchType )
        {
            searchText = originText;
            bool stLike = originText.StartsWith( "*" );
            bool edLike = originText.EndsWith( "*" );

            if ( stLike )
            {
                // 先頭の * を取り除く
                searchText = searchText.Substring( 1 );
            }
            if ( edLike )
            {
                // 末尾の * を取り除く
                searchText = searchText.Substring( 0, searchText.Length - 1 );
            }

            // 先頭＆末尾の*を取り除いてもまだ*がある場合→3:あいまい
            if ( searchText.Contains( "*" ) )
            {
                searchText = searchText.Replace( "*", "%" );
                searchType = 3;
                return;
            }


            // 検索タイプの判定
            if ( stLike )
            {
                if ( edLike )
                {
                    // 3:あいまい
                    searchType = 3;
                }
                else
                {
                    // 2:後方一致
                    searchType = 2;
                }
            }
            else
            {
                if ( edLike )
                {
                    // 1:前方一致
                    searchType = 1;
                }
                else
                {
                    // 0:完全一致
                    searchType = 0;
                }
            }
        }
        /// <summary>
        /// 検索テキスト取得処理(条件→入力された元々の文字列を復元する)
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        /// <returns></returns>
        private string GetSearchTextOrigin( string searchText, int searchType )
        {
            switch ( searchType )
            {
                case 0:
                    // 完全一致
                    return string.Format( "{0}", searchText.Trim().Replace( "%", "*" ) );
                case 1:
                    // 前方一致
                    return string.Format( "{0}*", searchText.Trim().Replace( "%", "*" ) );
                case 2:
                    // 後方一致
                    return string.Format( "*{0}", searchText.Trim().Replace( "%", "*" ) );
                case 3:
                default:
                    // あいまい
                    return string.Format( "*{0}*", searchText.Trim().Replace( "%", "*" ) );
            }
        }

        # endregion

        # region [入力チェック]
        /// <summary>
        /// 入力項目チェック処理
        /// </summary>
        private Control CheckInputPara()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //// 入力日付
            //if ( !CheckDate( ref tDateEdit_St_InputDay ) )
            //{
            //    SetStatusBarMessage( this, "開始入力日が不正です。" );
            //    tDateEdit_St_InputDay.Focus();
            //    return tDateEdit_St_InputDay;
            //}
            //if ( !CheckDate( ref tDateEdit_Ed_InputDay ) )
            //{
            //    SetStatusBarMessage( this, "終了入力日が不正です。" );
            //    tDateEdit_Ed_InputDay.Focus();
            //    return tDateEdit_Ed_InputDay;
            //}
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2008/09/30 DEL
            ////if (this.tDateEdit_St_InputDay.LongDate > this.tDateEdit_Ed_InputDay.LongDate)
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2008/09/30 DEL
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2008/09/30 ADD
            //if ( tDateEdit_St_InputDay.LongDate != 0 &&
            //     tDateEdit_Ed_InputDay.LongDate != 0 &&
            //     (this.tDateEdit_St_InputDay.LongDate > this.tDateEdit_Ed_InputDay.LongDate) )
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2008/09/30 ADD
            //{
            //    this.tDateEdit_St_InputDay.Focus();
            //    SetStatusBarMessage( this, MESSAGE_StartEndError );
            //    return tDateEdit_St_InputDay;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL

            // --- DEL 2009/04/02 -------------------------------->>>>>
            // 作成日
            //// （３ヶ月範囲チェック）
            //DateGetAcs.CheckDateRangeResult cdrResult;
            //if ( !CheckDateRange( out cdrResult, ref tDateEdit_St_AdjustDate, ref tDateEdit_Ed_AdjustDate ) )
            //{
            //    Control retControl = tDateEdit_St_AdjustDate;
            //    switch ( cdrResult )
            //    {
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
            //            {
            //                // 開始不正
            //                retControl = tDateEdit_St_AdjustDate;
            //                //SetStatusBarMessage( this, "開始作成日が不正です。" );        //DEL 2008/11/17 メッセージボックス表示
            //                // --- ADD 2008/11/17 --------------------------------------------------------------------------->>>>>
            //                TMsgDisp.Show(
            //                            this,
            //                            emErrorLevel.ERR_LEVEL_INFO,
            //                            this.Name,
            //                            "開始作成日が不正です。",
            //                            0,
            //                            MessageBoxButtons.OK);
            //                // --- ADD 2008/11/17 ---------------------------------------------------------------------------<<<<<
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
            //            {
            //                // 終了不正
            //                retControl = tDateEdit_Ed_AdjustDate;
            //                //SetStatusBarMessage( this, "終了作成日が不正です。" );        //DEL 2008/11/17 メッセージボックス表示
            //                // --- ADD 2008/11/17 --------------------------------------------------------------------------->>>>>
            //                TMsgDisp.Show(
            //                            this,
            //                            emErrorLevel.ERR_LEVEL_INFO,
            //                            this.Name,
            //                            "終了作成日が不正です。",
            //                            0,
            //                            MessageBoxButtons.OK);
            //                // --- ADD 2008/11/17 ---------------------------------------------------------------------------<<<<<
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
            //            {
            //                // 範囲外
            //                retControl = tDateEdit_St_AdjustDate;
            //                //SetStatusBarMessage( this, "作成日は３ヶ月の範囲内で入力して下さい。" );      //DEL 2008/11/17 メッセージボックス表示
            //                // --- ADD 2008/11/17 --------------------------------------------------------------------------->>>>>
            //                TMsgDisp.Show(
            //                            this,
            //                            emErrorLevel.ERR_LEVEL_INFO,
            //                            this.Name,
            //                            "作成日は３ヶ月の範囲内で入力して下さい。",
            //                            0,
            //                            MessageBoxButtons.OK);
            //                // --- ADD 2008/11/17 ---------------------------------------------------------------------------<<<<<
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
            //            {
            //                // 大小逆転
            //                retControl = tDateEdit_St_AdjustDate;
            //                //SetStatusBarMessage( this, MESSAGE_StartEndError );           //DEL 2008/11/17 メッセージボックス表示
            //                // --- ADD 2008/11/17 --------------------------------------------------------------------------->>>>>
            //                TMsgDisp.Show(
            //                            this,
            //                            emErrorLevel.ERR_LEVEL_INFO,
            //                            this.Name,
            //                            MESSAGE_StartEndError,
            //                            0,
            //                            MessageBoxButtons.OK);
            //                // --- ADD 2008/11/17 ---------------------------------------------------------------------------<<<<<
            //            }
            //            break;
            //    }
            //    retControl.Focus();
            //    return retControl;
            //}
            // --- DEL 2009/04/02 --------------------------------<<<<<
            // --- ADD 2009/04/02 -------------------------------->>>>>
            // 作成日
            if (!CheckDate(ref tDateEdit_St_AdjustDate))
            {
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            //"開始作成日が不正です。",         //DEL 2009/04/03 不具合対応[12857]
                            "開始仕入日が不正です。",           //ADD 2009/04/03 不具合対応[12857]
                            0,
                            MessageBoxButtons.OK);
                tDateEdit_St_AdjustDate.Focus();
                return tDateEdit_St_AdjustDate;
            }

            if (!CheckDate(ref tDateEdit_Ed_AdjustDate))
            {
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            //"終了作成日が不正です。",         //DEL 2009/04/03 不具合対応[12857]
                            "終了仕入日が不正です。",           //ADD 2009/04/03 不具合対応[12857]
                            0,
                            MessageBoxButtons.OK);

                tDateEdit_Ed_AdjustDate.Focus();
                return tDateEdit_Ed_AdjustDate;
            }

            if (tDateEdit_St_AdjustDate.LongDate != 0 &&
                 tDateEdit_Ed_AdjustDate.LongDate != 0 &&
                 (this.tDateEdit_St_AdjustDate.LongDate > this.tDateEdit_Ed_AdjustDate.LongDate))
            {
                this.tDateEdit_St_AdjustDate.Focus();

                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            MESSAGE_StartEndError,
                            0,
                            MessageBoxButtons.OK);

                return tDateEdit_St_AdjustDate;
            }
            // --- ADD 2009/04/02 --------------------------------<<<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            // 入力日付
            if ( !CheckDate( ref tDateEdit_St_InputDay ) )
            {
                //SetStatusBarMessage( this, "開始入力日が不正です。" );        //DEL 2008/11/17 メッセージボックス表示
                // --- ADD 2008/11/17 --------------------------------------------------------------------------->>>>>
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "開始入力日が不正です。",
                            0,
                            MessageBoxButtons.OK);
                // --- ADD 2008/11/17 ---------------------------------------------------------------------------<<<<<
                tDateEdit_St_InputDay.Focus();
                return tDateEdit_St_InputDay;
            }
            if ( !CheckDate( ref tDateEdit_Ed_InputDay ) )
            {
                //SetStatusBarMessage( this, "終了入力日が不正です。" );        //DEL 2008/11/17 メッセージボックス表示
                // --- ADD 2008/11/17 --------------------------------------------------------------------------->>>>>
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "終了入力日が不正です。",
                            0,
                            MessageBoxButtons.OK);
                // --- ADD 2008/11/17 ---------------------------------------------------------------------------<<<<<
                tDateEdit_Ed_InputDay.Focus();
                return tDateEdit_Ed_InputDay;
            }
            if ( tDateEdit_St_InputDay.LongDate != 0 &&
                 tDateEdit_Ed_InputDay.LongDate != 0 &&
                 (this.tDateEdit_St_InputDay.LongDate > this.tDateEdit_Ed_InputDay.LongDate) )
            {
                this.tDateEdit_St_InputDay.Focus();
                //SetStatusBarMessage( this, MESSAGE_StartEndError );           //DEL 2008/11/17 メッセージボックス表示
                // --- ADD 2008/11/17 --------------------------------------------------------------------------->>>>>
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            MESSAGE_StartEndError,
                            0,
                            MessageBoxButtons.OK);
                // --- ADD 2008/11/17 ---------------------------------------------------------------------------<<<<<
                return tDateEdit_St_InputDay;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD


            // 伝票番号大小チェック
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2008/09/30 DEL
            //if ( tNedit_SupplierSlipNo_St.GetInt() > tNedit_SupplierSlipNo_Ed.GetInt() )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2008/09/30 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2008/09/30 ADD
            if (tNedit_SupplierSlipNo_St.GetInt() > 0 &&
                tNedit_SupplierSlipNo_Ed.GetInt() > 0 &&
                　tNedit_SupplierSlipNo_St.GetInt() > tNedit_SupplierSlipNo_Ed.GetInt() )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2008/09/30 ADD
            {
                //SetStatusBarMessage( this, MESSAGE_StartEndError );           //DEL 2008/11/17 メッセージボックス表示 
                // --- ADD 2008/11/17 --------------------------------------------------------------------------->>>>>
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            MESSAGE_StartEndError,
                            0,
                            MessageBoxButtons.OK);
                // --- ADD 2008/11/17 ---------------------------------------------------------------------------<<<<<
                tNedit_SupplierSlipNo_St.Focus();
                return tNedit_SupplierSlipNo_St;
            }

            return null;
        }

        /// <summary>
        /// 日付チェック単独
        /// </summary>
        /// <param name="tDateEdit_St_AdjustDate"></param>
        /// <returns></returns>
        private bool CheckDate( ref TDateEdit tDateEdit_St_AdjustDate )
        {
            DateGetAcs dateGetAcs = DateGetAcs.GetInstance();

            DateGetAcs.CheckDateResult result;
            result = dateGetAcs.CheckDate( ref tDateEdit_St_AdjustDate, true );
            return (result == DateGetAcs.CheckDateResult.OK);
        }

        /// <summary>
        /// 日付３ヶ月範囲チェック
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="stDate"></param>
        /// <param name="edDate"></param>
        /// <returns></returns>
        private bool CheckDateRange( out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit stDate, ref TDateEdit edDate )
        {
            DateGetAcs dateGetAcs = DateGetAcs.GetInstance();
            cdrResult = dateGetAcs.CheckDateRange( DateGetAcs.YmdType.YearMonth, 3, ref stDate, ref edDate, false );
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        # endregion


        # region [検索]
        /// <summary>
        /// 伝票検索実行処理
        /// </summary>
        private Control SearchSlip()
        {
            // 入力項目チェック処理
            Control control = this.CheckInputPara();
            
			if (control != null)
			{
                return control;
            }

            StockAdjRefSearchParaWork stockAdjRefSearchParaWork = new StockAdjRefSearchParaWork();
            bool setEnable = false;

            // 読込条件パラメータクラス設定処理
            this.SetReadPara(out stockAdjRefSearchParaWork);

			// 伝票情報読込・データセット格納処理
			this._searchSlipAcs.SetSearchData(stockAdjRefSearchParaWork);
			
			setEnable = this._inputDetails.SetGridEnable();
            if (setEnable == true)
            {
                // 2009.01.06 add [9675]
                // 明細情報ボタン・確定ボタンのEnable操作はGridのEnterイベントで
                // 行われているため、Gridにフォーカスがあってはいけない
                if (this._inputDetails.uGrid_Details.Focused)
                {
                    this.uButton_SectionGuide.Focus();
                }
                // 2009.01.06 add [9675]
                this._inputDetails.uGrid_Details.Focus();
                this._inputDetails.timer_GridSetFocus.Enabled = true;
            }
            else
            {
                this._inputDetails.uButton_StockSearch.Enabled = false;
            }

			return null;
        }
        # endregion


        # region 各コントロールイベント処理

        /// <summary>
        /// ツールバーボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        this.SetDialogRes(DialogResult.Cancel);
                        // 終了処理
                        this.CloseForm();
                        break;
                    }
                case "ButtonTool_Decision":
                    {
                        // 確定処理
                        if (_inputDetails.ReturnSelectData())
                        {
                            this.SetDialogRes(DialogResult.OK);
                            this.CloseForm();
                        }
                        break;
                    }
                case "ButtonTool_Undo":
                    {
                        // 元に戻す処理
                        // 2009.01.06 add [9676]
                        // 明細ボタンのEnable操作はGridのLeaveイベントで行われて
                        // いるため、フォーカスを当てておく必要がある
                        if (!this._inputDetails.uGrid_Details.Focused)
                        {
                            this._inputDetails.uGrid_Details.Focus();
                        }
                        // 2009.01.06 add [9676]
                        this.ClearDisplayHeader();
                        this.SetDisplayHeaderInfo();
                        this._searchSlipAcs.ClearStockAdjustDataTable();

                        // 初期フォーカス
                        this.SetInitFocus( this );

                        break;
                    }
                case "ButtonTool_Search":
                    {
                        // 検索処理
                        SearchSlip();

                        break;
                    }
            }
        }

        /// <summary>
        /// 検索ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void Search_Button_Click(object sender, EventArgs e)
        {
            SearchSlip();
        }

        /// <summary>
        /// ステータスバーメッセージ表示イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="message">メッセージ</param>
        private void SetStatusBarMessage(object sender, string message)
        {
            this.uStatusBar_Main.Panels[0].Text = message;
        }

        # region [フォーム・イベント]
        /// <summary>
        /// フォームロード・イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load( object sender, EventArgs e )
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // スキン変更除外設定
            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add( this.Standard_UGroupBox.Name );
            excCtrlNm.Add( this.Detail_UGroupBox.Name );
            this._controlScreenSkin.SetExceptionCtrl( excCtrlNm );

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin( this );
            this._controlScreenSkin.SettingScreenSkin( this._inputDetails );

            // PMZAI04001UB を、panel_Detailを親としたコントロールにする
            this.panel_Detail.Controls.Add( this._inputDetails );
            this._inputDetails.Dock = DockStyle.Fill;

            //　企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 自拠点コードを取得する
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();
            // 拠点オプション有無を取得する
            this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany( ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION ) > 0);
            // 本社/拠点情報を取得する
            // 2008.12.25 [9573]
            //this._mainOfficeFunc = this._searchSlipAcs.IsMainOfficeFunc();
            this._mainOfficeFunc = true;
            // 2008.12.25 [9573]

            // ボタン初期設定処理
            this.ButtonInitialSetting();

            // 画面初期情報設定処理
            this.SetInitialInput();

            // 元に戻す処理
            this.ClearDisplayHeader();
            this.SetDisplayHeaderInfo();
            this._searchSlipAcs.ClearStockAdjustDataTable();
        }


        /// <summary>
        /// フォーム終了イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void PMZAI04001UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = _dialogRes;
        }
        /// <summary>
        /// フォーム初回表示イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMZAI04001UA_Shown( object sender, EventArgs e )
        {
            this.SetInitFocus( this );
        }

        # endregion

        # region [ChangeFocus]

        /// <summary>
        /// Enterキーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tRetKeyControl1_ChangeFocus( object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e )
        {
            // PMZAI04001UBのグリッドでのEnterキー押下処理で、PMZAI04001UAのtRetKeyControlに制御を奪われるため
            // イベントが発生しなくなる現象の回避策
            if ( e.PrevCtrl == this._inputDetails.uGrid_Details )
            {
                // グリッド上でのEnterキー押下では、他コントロールにフォーカスを移さない
                e.NextCtrl = e.PrevCtrl;
                // グリッド行選択処理タイマー発動
                this._inputDetails.timer_SelectRow.Enabled = true;
            }

            if ( e.NextCtrl.Parent == this.panel_Detail )
            {
                Control control = SearchSlip();

                if ( (this._inputDetails.uGrid_Details.Rows.Count > 0) &&
                   (this._inputDetails.uGrid_Details.Enabled == true) )
                {
                    e.NextCtrl = this._inputDetails.uGrid_Details;
                }
                else
                {
                    if ( control == null )
                    {
                        e.NextCtrl = e.PrevCtrl;
                    }
                    else
                    {
                        e.NextCtrl = control;
                    }
                }
            }
        }

        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tArrowKeyControl1_ChangeFocus( object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e )
        {
            if ( e.PrevCtrl == null || e.NextCtrl == null ) return;

            SetStatusBarMessage( this, "" );


            // フォーカス制御 ============================================ //
            # region [フォーカス制御]
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //    //(e.PrevCtrl == this.tEdit_PartySaleSlipNum) ||
            //    //(e.PrevCtrl == this.tComboEditor_StockGoodsCd) ||
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //    (e.PrevCtrl == this.tEdit_SectionCode) ||
            //    (e.PrevCtrl == this.uButton_SectionGuide))
            //{
            //    if (e.Key == Keys.Down)
            //    {
            //        if (Detail_UGroupBox.Expanded == true)
            //        {
            //            e.NextCtrl = this.tNedit_GoodsMakerCd;
            //        }
            //        else
            //        {
            //            e.NextCtrl = this._inputDetails.uGrid_Details; ;
            //        }
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (((e.PrevCtrl.Parent.Parent == this.Standard_UGroupBox) ||
            //    (e.PrevCtrl.Parent.Parent == this.Detail_UGroupBox) 
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //    //|| (e.PrevCtrl.Parent.Parent == this.Select_UGroupBox) 
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //    ) &&
            //    ((e.NextCtrl.Parent == this.panel_Detail) ||
            //     (e.NextCtrl == this._inputDetails.uGrid_Details)))
            //{
            //    Control control = SearchSlip();
            //    if ((this._inputDetails.uGrid_Details.Rows.Count > 0) &&
            //       (this._inputDetails.uGrid_Details.Enabled == true))
            //    {
            //        e.NextCtrl = this._inputDetails.uGrid_Details;
            //    }
            //    else
            //    {
            //        if (control == null)
            //        {
            //            e.NextCtrl = e.PrevCtrl;
            //        }
            //        else
            //        {
            //            e.NextCtrl = control;
            //        }
            //    }
            //}
            //else if (e.PrevCtrl == this._inputDetails.uButton_StockSearch)
            //{
            //    switch (e.Key)
            //    {
            //        case Keys.Up:
            //            {
            //                if (this.Detail_UGroupBox.Expanded == true)
            //                {
            //                    e.NextCtrl = this.tEdit_GoodsName;
            //                }
            //                else
            //                {
            //                    e.NextCtrl = this.SetInitFocus(this);
            //                }

            //                break;
            //            }
            //        case Keys.Left:
            //            {
            //                e.NextCtrl = e.PrevCtrl;

            //                break;
            //            }
            //        case Keys.Right:
            //        case Keys.Return:
            //        case Keys.Tab:
            //            {
            //                e.NextCtrl = this._inputDetails.uGrid_Details;
            //                break;
            //            }
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            # endregion

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2008/09/30 DEL
            //// 入力支援 ============================================ //
            //# region [入力支援]
            //// 入荷日
            //if ( (e.PrevCtrl == this.tDateEdit_St_AdjustDate) ||
            //    (e.PrevCtrl == this.tDateEdit_Ed_AdjustDate) )
            //{
            //    AutoSetEndValue( this.tDateEdit_St_AdjustDate, this.tDateEdit_Ed_AdjustDate );
            //}
            //// 計上日
            //if ( (e.PrevCtrl == this.tDateEdit_St_InputDay) ||
            //    (e.PrevCtrl == this.tDateEdit_Ed_InputDay) )
            //{
            //    AutoSetEndValue( this.tDateEdit_St_InputDay, this.tDateEdit_Ed_InputDay );
            //}
            //# endregion
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2008/09/30 DEL

            // 名称取得 ============================================ //
            # region [名称取得]
            switch ( e.PrevCtrl.Name )
            {
                //-----------------------------------------------------
                // 拠点
                //-----------------------------------------------------
                case "tEdit_SectionCode":
                    {
                        # region [拠点]

                        bool status;

                        if ( tEdit_SectionCode.Text == _paraStockSlipCache_Display.SectionCode )
                        {
                            status = true;
                        }
                        else
                        {
                            string code;
                            string name;

                            // 拠点読み込み
                            status = ReadSection( tEdit_SectionCode.Text, out code, out name );

                            // コード・名称を更新
                            tEdit_SectionCode.Text = code.TrimEnd();
                            _paraStockSlipCache_Display.SectionCode = code.TrimEnd();
                            uLabel_SectionName.Text = name;
                        }

                        if ( status == true )
                        {
                            if ( !e.ShiftKey )
                            {
                                // NextCtrl制御
                                switch ( e.Key )
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if ( _paraStockSlipCache_Display.SectionCode == string.Empty )
                                            {
                                                e.NextCtrl = this.uButton_SectionGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_WarehouseCode;
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "拠点が存在しません。",
                                -1,
                                MessageBoxButtons.OK );
                        }
                        # endregion
                    }
                    break;
                //-----------------------------------------------------
                // 倉庫
                //-----------------------------------------------------
                case "tEdit_WarehouseCode":
                    {
                        # region [倉庫]

                        bool status;

                        if ( tEdit_WarehouseCode.Text == _paraStockSlipCache_Display.WarehouseCode )
                        {
                            status = true;
                        }
                        else
                        {
                            string code;
                            string name;

                            // 読み込み
                            status = ReadWarehouse( tEdit_WarehouseCode.Text, out code, out name );

                            // コード・名称を更新
                            tEdit_WarehouseCode.Text = code.TrimEnd();
                            _paraStockSlipCache_Display.WarehouseCode = code.TrimEnd();
                            uLabel_WarehouseName.Text = name;
                        }

                        if ( status == true )
                        {
                            if ( !e.ShiftKey )
                            {
                                // NextCtrl制御
                                switch ( e.Key )
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if ( _paraStockSlipCache_Display.WarehouseCode == string.Empty )
                                            {
                                                e.NextCtrl = this.uButton_WarehouseGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tComboEditor_AcPaySlipCd;
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "倉庫が存在しません。",
                                -1,
                                MessageBoxButtons.OK );
                        }

                        # endregion
                    }
                    break;
                //-----------------------------------------------------
                // 担当者
                //-----------------------------------------------------
                case "tEdit_StockAgentCode":
                    {
                        # region [担当者]
                        bool status;

                        if ( tEdit_StockAgentCode.Text == _paraStockSlipCache_Display.StockAgentCode )
                        {
                            status = true;
                        }
                        else
                        {
                            string code;
                            string name;

                            // 読み込み
                            status = ReadEmployee( tEdit_StockAgentCode.Text, out code, out name );

                            // コード・名称を更新
                            tEdit_StockAgentCode.Text = code.TrimEnd();
                            _paraStockSlipCache_Display.StockAgentCode = code.TrimEnd();
                            uLabel_StockAgentName.Text = name;
                        }

                        if ( status == true )
                        {
                            if ( !e.ShiftKey )
                            {
                                // NextCtrl制御
                                switch ( e.Key )
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if ( _paraStockSlipCache_Display.StockAgentCode == string.Empty )
                                            {
                                                e.NextCtrl = this.uButton_EmployeeGuide;
                                            }
                                            else
                                            {
                                                if ( Detail_UGroupBox.Expanded == true )
                                                {
                                                    e.NextCtrl = this.tNedit_GoodsMakerCd;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this._inputDetails;
                                                }
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "従業員が存在しません。",
                                -1,
                                MessageBoxButtons.OK );
                        }
                        # endregion
                    }
                    break;
                //-----------------------------------------------------
                // メーカー
                //-----------------------------------------------------
                case "tNedit_GoodsMakerCd":
                    {
                        # region [メーカー]
                        bool status;

                        if ( tNedit_GoodsMakerCd.GetInt() == _paraStockSlipCache_Display.GoodsMakerCd )
                        {
                            status = true;
                        }
                        else
                        {
                            int code;
                            string name;

                            // 読み込み
                            status = ReadGoodsMaker( tNedit_GoodsMakerCd.GetInt(), out code, out name );

                            // コード・名称を更新
                            tNedit_GoodsMakerCd.SetInt( code );
                            _paraStockSlipCache_Display.GoodsMakerCd = code;
                            uLabel_MakerName.Text = name;
                        }

                        if ( status == true )
                        {
                            if ( !e.ShiftKey )
                            {
                                // NextCtrl制御
                                switch ( e.Key )
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if ( _paraStockSlipCache_Display.GoodsMakerCd == 0 )
                                            {
                                                e.NextCtrl = this.uButton_GoodsMakerGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_GoodsNo;
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "メーカーが存在しません。",
                                -1,
                                MessageBoxButtons.OK );
                        }

                        # endregion
                    }
                    break;
                //-----------------------------------------------------
                // 棚番
                //-----------------------------------------------------
                case "tEdit_WarehouseShelfNo":
                    {
                        # region [フォーカス制御]
                        // フォーカス制御
                        if ( !e.ShiftKey )
                        {
                            // NextCtrl制御
                            switch ( e.Key )
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // 移動しない
                                        e.NextCtrl = this._inputDetails;
                                        break;
                                    }
                            }
                        }
                        # endregion
                    }
                    break;
            }
            # endregion

            // RetKeyControl用処理
            if ( (e.Key == Keys.Return) ||
                (e.Key == Keys.Tab) )
            {
                // PMZAI04001UBのグリッドでのEnterキー押下処理で、PMZAI04001UAのtRetKeyControlに制御を奪われるため
                // イベントが発生しなくなる現象の回避策
                if ( e.PrevCtrl == this._inputDetails.uGrid_Details )
                {
                    // グリッド上でのEnterキー押下では、他コントロールにフォーカスを移さない
                    e.NextCtrl = e.PrevCtrl;
                    // グリッド行選択処理タイマー発動
                    //this._inputDetails.timer_SelectRow.Enabled = true;
                }

                //if (e.PrevCtrl == this.tEdit_PartySaleSlipNum)
                //{
                //    e.NextCtrl = this.tEdit_GoodsCode;
                //}
                else
                    if ( e.NextCtrl.Parent == this.panel_Detail )
                    {
                        Control control = SearchSlip();

                        if ( (this._inputDetails.uGrid_Details.Rows.Count > 0) &&
                           (this._inputDetails.uGrid_Details.Enabled == true) )
                        {
                            e.NextCtrl = this._inputDetails.uGrid_Details;
                        }
                        else
                        {
                            if ( control == null )
                            {
                                e.NextCtrl = e.PrevCtrl;
                            }
                            else
                            {
                                e.NextCtrl = control;
                            }
                        }
                    }
            }
        }

        # region [ChangeFocus時のRead処理]
        /// <summary>
        /// 拠点Read
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ReadSection( string sectionCode, out string code, out string name )
        {
            bool result = false;

            // 未入力判定
            if ( sectionCode != string.Empty && sectionCode != WHOLE_SECTION_CODE ) // 2009.01.06 add [9693]
            {
                // 読み込み
                if ( _secInfoSetAcs == null )
                {
                    _secInfoSetAcs = new SecInfoSetAcs();
                }
                SecInfoSet secInfoSet;
                int status = _secInfoSetAcs.Read( out secInfoSet, this._enterpriseCode, sectionCode );

                if ( status == 0 && secInfoSet != null )
                {
                    // 該当あり→表示
                    code = secInfoSet.SectionCode.TrimEnd();
                    name = secInfoSet.SectionGuideNm;

                    result = true;
                }
                else
                {
                    // 該当なし→クリア
                    // 2009.01.06 modify [9693]
                    //code = string.Empty;
                    //name = string.Empty;
                    code = WHOLE_SECTION_CODE;
                    name = WHOLE_SECTION_NAME;
                    // 2009.01.06 modify [9693]

                    // ＮＧにする
                    result = false;
                }
            }
            else
            {
                // 未入力→クリア
                // 2009.01.06 modify [9633]
                //code = string.Empty;
                //name = string.Empty;
                code = WHOLE_SECTION_CODE;
                name = WHOLE_SECTION_NAME;
                // 2009.01.06 modify [9633]

                result = true;
            }

            return result;
        }
        /// <summary>
        /// 倉庫Read
        /// </summary>
        /// <param name="p"></param>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ReadWarehouse( string warehouseCode, out string code, out string name )
        {
            bool result = false;

            // 未入力判定
            if ( warehouseCode != string.Empty )
            {
                // 読み込み
                if ( _warehouseAcs == null )
                {
                    _warehouseAcs = new WarehouseAcs();
                }
                Warehouse warehouse;
                int status = _warehouseAcs.Read( out warehouse, this._enterpriseCode, string.Empty, warehouseCode );

                if ( status == 0 && warehouse != null )
                {
                    // 該当あり→表示
                    code = warehouse.WarehouseCode.TrimEnd();
                    name = warehouse.WarehouseName;

                    result = true;
                }
                else
                {
                    // 該当なし→クリア
                    code = string.Empty;
                    name = string.Empty;

                    // ＮＧにする
                    result = false;
                }
            }
            else
            {
                // 未入力→クリア
                code = string.Empty;
                name = string.Empty;

                result = true;
            }

            return result;
        }
        /// <summary>
        /// 従業員Read
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ReadEmployee( string employeeCode, out string code, out string name )
        {
            bool result = false;

            // 未入力判定
            if ( employeeCode != string.Empty )
            {
                // 読み込み
                if ( _employeeAcs == null )
                {
                    _employeeAcs = new EmployeeAcs();
                }
                Employee employee;
                int status = _employeeAcs.Read( out employee, this._enterpriseCode, employeeCode );

                if ( status == 0 && employee != null )
                {
                    // 該当あり→表示
                    code = employee.EmployeeCode.TrimEnd();
                    name = employee.Name;

                    result = true;
                }
                else
                {
                    // 該当なし→クリア
                    code = string.Empty;
                    name = string.Empty;

                    // ＮＧにする
                    result = false;
                }
            }
            else
            {
                // 未入力→クリア
                code = string.Empty;
                name = string.Empty;

                result = true;
            }

            return result;
        }
        /// <summary>
        /// 商品メーカーRead
        /// </summary>
        /// <param name="goodsMakerCd"></param>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ReadGoodsMaker( int goodsMakerCd, out int code, out string name )
        {
            bool result = false;

            // 未入力判定
            if ( goodsMakerCd != 0 )
            {
                // 読み込み
                if ( _makerAcs == null )
                {
                    _makerAcs = new MakerAcs();
                }
                MakerUMnt maker;
                int status = _makerAcs.Read( out maker, this._enterpriseCode, goodsMakerCd );

                if ( status == 0 && maker != null )
                {
                    // 該当あり→表示
                    code = maker.GoodsMakerCd;
                    name = maker.MakerName;

                    result = true;
                }
                else
                {
                    // 該当なし→クリア
                    code = 0;
                    name = string.Empty;

                    // ＮＧにする
                    result = false;
                }
            }
            else
            {
                // 未入力→クリア
                code = 0;
                name = string.Empty;

                result = true;
            }

            return result;
        }
        # endregion

        # endregion

        # region [ガイドボタンクリック]
        /// <summary>
        /// 拠点ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            if ( _secInfoSetAcs == null )
            {
                _secInfoSetAcs = new SecInfoSetAcs();
            }
           
            SecInfoSet secInfoSet;
            int status = _secInfoSetAcs.ExecuteGuid( this._enterpriseCode, false, out secInfoSet );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                tEdit_SectionCode.Text = secInfoSet.SectionCode.Trim();
                uLabel_SectionName.Text = secInfoSet.SectionGuideNm.Trim();
                this._paraStockSlipCache_Display.SectionCode = secInfoSet.SectionCode.Trim();

                // フォーカス移動
                tEdit_WarehouseCode.Focus();
            }
        }

        /// <summary>
        /// 従業員ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_EmployeeGuide_Click(object sender, EventArgs e)
        {
            if ( _employeeAcs == null )
            {
                _employeeAcs = new EmployeeAcs();
            }
            
            Employee employee;
            int status = _employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tEdit_StockAgentCode.Text = employee.EmployeeCode.Trim();
                uLabel_StockAgentName.Text = employee.Name.Trim();
                this._paraStockSlipCache_Display.StockAgentCode = employee.EmployeeCode.Trim();

                // フォーカス移動
                if ( Detail_UGroupBox.Expanded == true )
                {
                    tNedit_GoodsMakerCd.Focus();
                }
                else
                {
                    this._inputDetails.Focus();
                }
            }
        }

		/// <summary>
		/// メーカーガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_GoodsMakerGuide_Click(object sender, EventArgs e)
		{
            if ( _makerAcs == null )
            {
                _makerAcs = new MakerAcs();
            }
			
			MakerUMnt makerUMnt;
			int status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                tNedit_GoodsMakerCd.SetInt( makerUMnt.GoodsMakerCd );
				uLabel_MakerName.Text = makerUMnt.MakerName.Trim();
				this._paraStockSlipCache_Display.GoodsMakerCd = makerUMnt.GoodsMakerCd;

                // フォーカス移動
                tEdit_GoodsNo.Focus();
			}
		}
        /// <summary>
        /// 倉庫ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_WarehouseGuide_Click( object sender, EventArgs e )
        {
            if ( _warehouseAcs == null )
            {
                _warehouseAcs = new WarehouseAcs();
            }

            Warehouse warehouse;
            int status = _warehouseAcs.ExecuteGuid( out warehouse, this._enterpriseCode, this.tEdit_SectionCode.Text );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                tEdit_WarehouseCode.Text = warehouse.WarehouseCode.TrimEnd();
                uLabel_WarehouseName.Text = warehouse.WarehouseName.TrimEnd();
                this._paraStockSlipCache_Display.WarehouseCode = warehouse.WarehouseCode.TrimEnd();

                // フォーカス移動
                tComboEditor_AcPaySlipCd.Focus();
            }
        }
        # endregion

        #region [棚番入力制御]
        // --- ADD 2009/04/13 -------------------------------->>>>>
        /// <summary>
        /// tEdit_WarehouseShelfNo_KeyPressイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_WarehouseShelfNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_WarehouseShelfNo.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_WarehouseShelfNo.SelectionStart) // 選択前の部分
                                 + e.KeyChar.ToString() // 選択部が入力キーに置換される部分
                                 + prevStr.Substring(this.tEdit_WarehouseShelfNo.SelectionStart + this.tEdit_WarehouseShelfNo.SelectionLength,
                                                      this.tEdit_WarehouseShelfNo.Text.Length - (this.tEdit_WarehouseShelfNo.SelectionStart + this.tEdit_WarehouseShelfNo.SelectionLength)); // 選択後の部分

                Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                int byteLength = sjis.GetByteCount(resultStr);

                // 8バイト(半角8桁、全角4桁)まで入力可
                if (byteLength > 8)
                {
                    e.Handled = true;
                    return;
                }
            }
        }
        // --- ADD 2009/04/13 --------------------------------<<<<<
        #endregion

        # endregion


        # region [確定ボタン制御]
        /// <summary>
        /// 「確定」ボタン有効無効変更処理
        /// </summary>
        /// <param name="enable">表示設定(true:有効、false:無効)</param>
        private void ChangeDecisionButtonEnable( bool enabled )
        {
            if ( this._inputDetails.StartMovment != 0 )
            {
                // StartMovment ≠ 0で起動されている場合は、常にfalse
                enabled = false;
            }
            this._decisionButton.SharedProps.Enabled = enabled;
        }
        /// <summary>
        /// 「確定」ボタン表示有無変更処理
        /// </summary>
        /// <param name="visible">表示設定(true:有効、false:無効)</param>
        private void ChangeDecisionButtonVisible( bool visible )
        {
            if ( this._inputDetails.StartMovment != 0 )
            {
                // StartMovment ≠ 0で起動されている場合は、常にfalse
                visible = false;
            }
            this._decisionButton.SharedProps.Visible = visible;
        }
        # endregion

        # region [その他の処理]
        /// <summary>
        /// 画面名称リスト取得処理
        /// </summary>
        /// <returns>画面名称値リスト</returns>
        private SortedList GetDisplayNameList()
        {
            // 【項目名→表示の値】を取得するSortedList (アクセスクラスに渡す)
            SortedList nameList = new SortedList();

            nameList.Add( "SectionName", this.uLabel_SectionName.Text );
            nameList.Add( "WarehouseName", this.uLabel_WarehouseName.Text );
            nameList.Add( "MakerName", this.uLabel_MakerName.Text );
            nameList.Add( "StockAgentName", this.uLabel_StockAgentName.Text );

            return nameList;
        }

        /// <summary>
        /// 初期フォーカス設定処理
        /// </summary>
        public Control SetInitFocus( object sender )
        {
            this.tEdit_SectionCode.Focus();
            this.tEdit_SectionCode.SelectAll();
            return this.tEdit_SectionCode;
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        public void CloseForm()
        {
            this.Close();
        }

        /// <summary>
        /// ダイアログリザルト設定処理
        /// </summary>
        /// <param name="dialogRes">ダイアログリザルト</param>
        public void SetDialogRes( DialogResult dialogRes )
        {
            _dialogRes = dialogRes;
        }
        # endregion

        
    }
}