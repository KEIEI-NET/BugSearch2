using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

using Infragistics.Win.UltraWinExplorerBar;
using Infragistics.Win.UltraWinGrid;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 売上目標設定(月間)画面
	/// </summary>
	/// <remarks>
	/// <br>Note		: 売上目標設定(月間)を行う画面です。</br>
	/// <br>Programmer	: NEPCO</br>
	/// <br>Date		: 2007.03.29</br>
    /// <br></br>
    /// <br>UpdateNote: 2007.10.01 鈴木 正臣
    /// <br>            流通.NS用に変更</br>
	/// </remarks>
	public partial class MAMOK01110UA : Form, ISalesMonTargetMDIChild
	{
		# region Private Constants

        // 画面状態保存用ファイル名
        private const string XML_FILE_INITIAL_DATA = "MAMOK01110U.dat";

		// PG名称
        private const string ctPGNM = "売上目標設定(月間)";

		private const string COL_SALESTARGET_HEADER = "SalesTargetHeader";

		// Grid列のKEY情報 (Headerのwidth部となります)
        private const int WIDTH_SALESTARGET_TITLE = 150;
        private const int WIDTH_SALESTARGET = 115;

		// Grid列のKEY情報 (HeaderのTitle部となります)
		private const string VIEW_SALESTARGET_CLEAR = "クリア";
		private const string VIEW_SALESTARGET_MONTH = "適用月";
		private const string VIEW_SALESTARGET_MONEY = "売上目標(円/月)";
        private const string VIEW_SALESTARGET_PROFIT = "粗利目標(円/月)";
        private const string VIEW_SALESTARGET_COUNT = "数量目標(台/月)";
        private const string VIEW_SALESTARGET_MONEY_SUNDAY = "日曜売上目標(円/日)";
        private const string VIEW_SALESTARGET_PROFIT_SUNDAY = "日曜粗利目標(円/日)";
        private const string VIEW_SALESTARGET_COUNT_SUNDAY = "日曜数量目標(台/日)";
        private const string VIEW_SALESTARGET_MONEY_MONDAY = "月曜売上目標(円/日)";
        private const string VIEW_SALESTARGET_PROFIT_MONDAY = "月曜粗利目標(円/日)";
        private const string VIEW_SALESTARGET_COUNT_MONDAY = "月曜数量目標(台/日)";
        private const string VIEW_SALESTARGET_MONEY_TUESDAY = "火曜売上目標(円/日)";
        private const string VIEW_SALESTARGET_PROFIT_TUESWDAY = "火曜粗利目標(円/日)";
        private const string VIEW_SALESTARGET_COUNT_TUESDAY = "火曜数量目標(台/日)";
        private const string VIEW_SALESTARGET_MONEY_WEDNESDAY = "水曜売上目標(円/日)";
        private const string VIEW_SALESTARGET_PROFIT_WEDNESDAY = "水曜粗利目標(円/日)";
        private const string VIEW_SALESTARGET_COUNT_WEDNESDAY = "水曜数量目標(台/日)";
        private const string VIEW_SALESTARGET_MONEY_THURSDAY = "木曜売上目標(円/日)";
        private const string VIEW_SALESTARGET_PROFIT_THURSDAY = "木曜粗利目標(円/日)";
        private const string VIEW_SALESTARGET_COUNT_THURSDAY = "木曜数量目標(台/日)";
        private const string VIEW_SALESTARGET_MONEY_FRIDAY = "金曜売上目標(円/日)";
        private const string VIEW_SALESTARGET_PROFIT_FRIDAY = "金曜粗利目標(円/日)";
        private const string VIEW_SALESTARGET_COUNT_FRIDAY = "金曜数量目標(台/日)";
        private const string VIEW_SALESTARGET_MONEY_SATURDAY = "土曜売上目標(円/日)";
        private const string VIEW_SALESTARGET_PROFIT_SATURDAY = "土曜粗利目標(円/日)";
        private const string VIEW_SALESTARGET_COUNT_SATURDAY = "土曜数量目標(台/日)";
        private const string VIEW_SALESTARGET_MONEY_HOLIDAY = "祝祭日売上目標(円/日)";
        private const string VIEW_SALESTARGET_PROFIT_HOLIDAY = "祝祭日粗利目標(円/日)";
        private const string VIEW_SALESTARGET_COUNT_HOLIDAY = "祝祭日数量目標(台/日)";

        // Grid行のKEY情報 (行のインデックスとなります)
        private const int ROW_CLEAR = 0;
        private const int ROW_DATE = 1;
        private const int ROW_SALESTARGETMONEY = 2;
        private const int ROW_SALESTARGETPROFIT = 3;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //private const int ROW_SALESTARGETCOUNT = 4;
        //private const int ROW_SALESTARGET_MONEY_SUNDAY = 5;
        //private const int ROW_SALESTARGET_PROFIT_SUNDAY = 6;
        //private const int ROW_SALESTARGET_COUNT_SUNDAY = 7;
        //private const int ROW_SALESTARGET_MONEY_MONDAY = 8;
        //private const int ROW_SALESTARGET_PROFIT_MONDAY = 9;
        //private const int ROW_SALESTARGET_COUNT_MONDAY = 10;
        //private const int ROW_SALESTARGET_MONEY_TUESDAY = 11;
        //private const int ROW_SALESTARGET_PROFIT_TUESWDAY = 12;
        //private const int ROW_SALESTARGET_COUNT_TUESDAY = 13;
        //private const int ROW_SALESTARGET_MONEY_WEDNESDAY = 14;
        //private const int ROW_SALESTARGET_PROFIT_WEDNESDAY = 15;
        //private const int ROW_SALESTARGET_COUNT_WEDNESDAY = 16;
        //private const int ROW_SALESTARGET_MONEY_THURSDAY = 17;
        //private const int ROW_SALESTARGET_PROFIT_THURSDAY = 18;
        //private const int ROW_SALESTARGET_COUNT_THURSDAY = 19;
        //private const int ROW_SALESTARGET_MONEY_FRIDAY = 20;
        //private const int ROW_SALESTARGET_PROFIT_FRIDAY = 21;
        //private const int ROW_SALESTARGET_COUNT_FRIDAY = 22;
        //private const int ROW_SALESTARGET_MONEY_SATURDAY = 23;
        //private const int ROW_SALESTARGET_PROFIT_SATURDAY = 24;
        //private const int ROW_SALESTARGET_COUNT_SATURDAY = 25;
        //private const int ROW_SALESTARGET_MONEY_HOLIDAY = 26;
        //private const int ROW_SALESTARGET_PROFIT_HOLIDAY = 27;
        //private const int ROW_SALESTARGET_COUNT_HOLIDAY = 28;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

		private const string RATIO = "1.00";
        private const string FORMAT_NUM = "###,###";
        private const string FORMAT_NUM_ZERO = "###,##0";
        private const string FORMAT_NUM_DECIMAL = "N1";

        private const int HEIGHT_EXPLORERBAR = 223;
        private const int HEIGHT_PANEL = 191;

        // 拠点目標用従業員コード
        private const string EMPLOYEECODE_SECTION = "SECTION";

		private readonly Color COLOR_BACKCOLOR = Color.FromArgb(89, 135, 214);
		private readonly Color COLOR_BACKCOLOR2 = Color.FromArgb(7, 59, 150);

        # endregion Private Constants

        # region Private Members

        // タイトル
		private readonly string _title;
		// 保存ボタン
		private bool _saveButton;
		// 比率から計算ボタン
		private bool _calcFromRatioButton;
        // 元に戻すボタン
        private bool _undoButton;
        // 年度目標ボタン
        private bool _yearTargetButton;

		// 企業コード
		private string _enterpriseCode;
		// 拠点コード
		private string _sectionCode;
		// 拠点名
		private string _sectionName;
        // 期首月
        private int _companyBiginMonth;

		//コントロールの配列
		private Infragistics.Win.Misc.UltraLabel[] _ratioMonth_uLabel;
		private Broadleaf.Library.Windows.Forms.TNedit[] _ratioMonth_tNedit;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.23 TOKUNAGA ADD START
        // 拠点アクセスクラス
        private SecInfoSetAcs _secInfoSetAcs = null;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.23 TOKUNAGA ADD END

        // 目標マスタアクセスクラス
        private SalesTargetAcs _salesTargetAcs;
        // 目標データリスト
        private List<SalesTarget> _salesTargetList;
        // 検索条件
        private ExtrInfo_MAMOK09197EA _extrInfo;

        // 休業日設定マスタ
        private Dictionary<SectionAndDate, HolidaySetting> _holidaySettingDic;

        // 着地計算比率リスト
        private List<LdgCalcRatioMng> _ldgCalcRatioMngList;

        // グリッド設定制御クラス
        private GridStateController _gridStateController;

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 期間（開始）
		private DateTime _targetDateSt;
        // 期間（終了）
        private DateTime _targetDateEd;
        // 編集行
		private int _editRowIndex;
		// 編集列
        private int _editColumnIndex;

        // 検索フラグ
        private bool _searchFlag;

        private bool _closing;

        private bool _cancelFlag;

        # endregion Private Members

        # region Constructor

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MAMOK01110UA()
		{
			this._saveButton = true;
			this._calcFromRatioButton = true;
            this._undoButton = true;
            this._yearTargetButton = true;

			InitializeComponent();

            this._title = ctPGNM;

			// 企業コードを取得
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// 拠点情報取得
			SecInfoSet secInfoSet;
			SecInfoAcs secInfoAcs = new SecInfoAcs();
			secInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);
			this._sectionCode = secInfoSet.SectionCode.TrimEnd();
			this._sectionName = secInfoSet.SectionGuideNm.TrimEnd();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.23 TOKUNAGA ADD START
            this._secInfoSetAcs = new SecInfoSetAcs();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.23 TOKUNAGA ADD END

            this._gridStateController = new GridStateController();

            this._salesTargetAcs = new SalesTargetAcs();
            this._salesTargetList = new List<SalesTarget>();

			// アイコン画像の設定
			// 検索ボタン
			this.Search_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.SEARCH];
            // クリアボタン
            this.Clear_Button.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.RETRY];
        }

        # endregion Constructor

        # region ISalesMonTargetMDIChild メンバ

        /// <summary>
		/// タイトル
		/// </summary>
		public string Title
		{
			get
			{
				return (_title);
			}
		}
		/// <summary>
		/// 保存ボタン
		/// </summary>
		public bool SaveButton
		{
			get
			{
				return (_saveButton);
			}
		}
		/// <summary>
		/// 比率から計算ボタン
		/// </summary>
		public bool CalcFromRatioButton
		{
			get
			{
				return (_calcFromRatioButton);
			}
		}
        /// <summary>
        /// 元に戻すボタン
        /// </summary>
        public bool UndoButton
        {
            get
            {
                return (_undoButton);
            }
        }
        /// <summary>
        /// 年度目標ボタン
        /// </summary>
        public bool YearTargetButton
        {
            get
            {
                return (_yearTargetButton);
            }
        }

		/// <summary>
		/// 選択拠点取得イベント
		/// </summary>
		/// <remarks>
		/// <br>Note		: フレームにて選択されている拠点コードを取得します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
        //public event GetSalesMonTargetSelectSectionCodeEventHandler GetSelectSectionCodeEvent;

		/// <summary>
		/// ツールバーボタン制御イベント
		/// </summary>
		/// <remarks>
		/// <br>Note		: フレームのボタン有効無効制御をしたい場合に発生させます。
		///					  (IPaymentInputMDIChildインターフェースの実装)</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		public event ParentToolbarSalesMonTargetSettingEventHandler ParentToolbarSettingEvent;

		/// <summary>
		/// 拠点変更後処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: フレームの拠点を変更後に処理されます。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		public void AfterSectionChange()
		{

		}

		/// <summary>
		/// 終了前処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 画面を閉じる前に処理されます。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		public int BeforeClose(object parameter)
		{
			bool status = CloseSalesTarget();
			if (!status)
			{
				return (1);
			}

            // 画面状態を保存
            SaveStateXmlData();

            this._closing = true;

			return (0);
		}

		/// <summary>
		/// 拠点変更前処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: フレームにて拠点が変更される前に処理されます。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		public int BeforeSectionChange()
		{
			return (0);
		}

		/// <summary>
		/// タブ切替前処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: フレームにてタブが切り替えられる前に処理されます。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		public int BeforeTabChange(object parameter)
		{
			return (0);
		}

        /// <summary>
        /// フォーム初期化処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: フレームにてフォームが生成される前に処理されます。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.06.11</br>
        /// </remarks>
        public int InitializeForm()
        {
            int status = LoadMasterTable();
            if (status != 0)
            {
                // ツールバー初期化
                this._saveButton = false;
                this._calcFromRatioButton = false;
                this._undoButton = false;
                this._yearTargetButton = false;
                if (ParentToolbarSettingEvent != null) this.ParentToolbarSettingEvent(this);
            }

            return (status);

        }

		/// <summary>
		/// モードレス表示処理（パラメータ有り）
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <remarks>
		/// <br>Note		: 通常起動時にフレームから呼び出されます。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		public void Show(object parameter)
		{
			this.Show();
		}

		/// <summary>
		/// 保存処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 保存ボタンがクリックされた時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		public void SaveSalesMonTargetProc()
		{
            bool retResult;

            if (this._editRowIndex >= ROW_SALESTARGETMONEY &&
                this._editColumnIndex > 0)
            {
                retResult = CheckEditCharacter();
                if (!retResult)
                {
                    return;
                }
            }

            retResult = BeforeSaveSalesTarget();
            if (!retResult)
            {
                return;
            }

            List<SalesTarget> salesTargetList;
            List<SalesTarget> deleteSalesTargetList;

            // 修正後の勤怠データをバッファに取得
            ScreenToSalesTarget(out salesTargetList, out deleteSalesTargetList);

            // 目標データ保存
            retResult = SaveSalesTarget(ref salesTargetList);
            if (!retResult)
            {
                return;
            }

            // 目標データ削除
            retResult = DeleteSalesTarget(deleteSalesTargetList);
            if (!retResult)
            {
                return;
            }

            this._salesTargetList = salesTargetList;

            // グリッド表示
            DispScreen(this._salesTargetList);
            // グリッドレイアウト設定
            SetLayout_SalesTarget_uGrid();

		}

		/// <summary>
		/// 比率から計算処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 比率から計算ボタンがクリックされた時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		public void CalcFromRatioSalesMonTargetProc()
		{
            if (this._searchFlag == false)
            {
                return;
            }

            bool retResult;

            if (this._editRowIndex >= ROW_SALESTARGETMONEY &&
                this._editColumnIndex > 0)
            {
                retResult = CheckEditCharacter();
                if (!retResult)
                {
                    return;
                }
            }

			// 計算条件チェック処理
            retResult = CheckCalcCondition();
            if (!retResult)
			{
				return;
			}

            // 比率計算前処理
            BeforeCalcFromRatio();
        }

        /// <summary>
        /// 元に戻す処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 元に戻すボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.03.29</br>
        /// </remarks>
        public void UndoSalesMonTargetProc()
        {
            bool retResult;

            if (this._editRowIndex >= ROW_SALESTARGETMONEY &&
                this._editColumnIndex > 0)
            {
                retResult = CheckEditCharacter();
                if (!retResult)
                {
                    return;
                }
            }

            // 画面情報初期化
            UndoScreenInfo();
        }

        /// <summary>
        /// 年度目標ガイド処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 年度目標ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.03.29</br>
        /// </remarks>
        public void YearTargetSalesMonTargetProc()
        {
            bool retResult;

            if (this._editRowIndex >= ROW_SALESTARGETMONEY &&
                this._editColumnIndex > 0)
            {
                retResult = CheckEditCharacter();
                if (!retResult)
                {
                    return;
                }
            }

            // 年度目標ガイド表示
            ShowYearSalesTarget();
        }

        # endregion ISalesMonTargetMDIChild メンバ

        # region Private Methods

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 各マスタを読み込みます。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.25</br>
        /// </remarks>
        private int LoadMasterTable()
        {
            int status;

            // 自社情報マスタ
            status = LoadCompanyInfTable();
            if (status != 0)
            {
                return (status);
            }

            // 休業日設定マスタ
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //status = LoadHolidaySettingTable(this._sectionCode);
            //if (status != 0)
            //{
            //    return (status);
            //}

            //// 着地計算比率管理マスタ
            //status = LoadLdgCalcRatioMngTable(this._sectionCode);
            //if (status != 0)
            //{
            //    return (status);
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            
            return (0);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 自社情報マスタ読み込み処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 自社情報マスタを読み込み、期首月を取得します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.25</br>
        /// </remarks>
        private int LoadCompanyInfTable()
        {
            int status;

            // 自社情報マスタから期首月を取得
            CompanyInfAcs companyInfAcs = new CompanyInfAcs();
            CompanyInf companyInf;

            status = companyInfAcs.Read(out companyInf, this._enterpriseCode);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:
                    TMsgDisp.Show(
                        this,										// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOP,				// エラーレベル
                        this.Name,									// アセンブリID
                        ctPGNM,  　　								// プログラム名称
                        "LoadCompanyInfTable",				   // 処理名称
                        TMsgDisp.OPE_GET,							// オペレーション
                        "自社情報マスタの読み込みに失敗しました",					// 表示するメッセージ
                        status,										// ステータス値
                        companyInfAcs,									// エラーが発生したオブジェクト
                        MessageBoxButtons.OK,			  			// 表示するボタン
                        MessageBoxDefaultButton.Button1);			// 初期表示ボタン
                    return (status);
            }

            // 期首月設定
            this._companyBiginMonth = companyInf.CompanyBiginMonth;

            return (0);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 休業日設定マスタ読み込み処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <remarks>
        /// <br>Note		: 休業日設定マスタを読み込み休業日適用区分を取得します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.07.11</br>
        /// </remarks>
        private int LoadHolidaySettingTable(string sectionCode)
        {
            int status;
            ArrayList retList;

            _holidaySettingDic = new Dictionary<SectionAndDate, HolidaySetting>();

            // 休業日設定マスタからデータを取得
            HolidaySettingAcs holidaySettingAcs = new HolidaySettingAcs();
            status = holidaySettingAcs.Search(
                out retList,
                this._enterpriseCode,
                sectionCode,
                DateTime.MinValue,
                DateTime.MaxValue);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:
                    TMsgDisp.Show(
                        this,										// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOP,				// エラーレベル
                        this.Name,									// アセンブリID
                        ctPGNM,  　　								// プログラム名称
                        "LoadHolidaySettingTable",					// 処理名称
                        TMsgDisp.OPE_GET,							// オペレーション
                        "休業日設定マスタの読み込みに失敗しました",					// 表示するメッセージ
                        status,										// ステータス値
                        holidaySettingAcs,							// エラーが発生したオブジェクト
                        MessageBoxButtons.OK,			  			// 表示するボタン
                        MessageBoxDefaultButton.Button1);			// 初期表示ボタン
                    return (status);
            }

            // リスト作成
            SectionAndDate sectionAndDate;
            foreach (HolidaySetting holidaySetting in retList)
            {
                sectionAndDate.SectionCode = holidaySetting.SectionCode;
                sectionAndDate.Date = holidaySetting.ApplyDate;
                _holidaySettingDic.Add(sectionAndDate, holidaySetting);
            }

            return (0);

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 着地計算比率管理マスタ読み込み処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <remarks>
        /// <br>Note		: 着地計算比率管理マスタを読み込み各曜日の比率を取得します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.07.12</br>
        /// </remarks>
        private int LoadLdgCalcRatioMngTable(string sectionCode)
        {
            LdgCalcRatioMngAcs ldgCalcRatioMngAcs = new LdgCalcRatioMngAcs();
            this._ldgCalcRatioMngList = new List<LdgCalcRatioMng>();

            string[] sectionCodeList = new string[1];
            sectionCodeList[0] = sectionCode;

            // 着地計算比率管理マスタ取得
            int status = ldgCalcRatioMngAcs.Search(out this._ldgCalcRatioMngList, this._enterpriseCode, sectionCodeList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    // 正常
                    break;
                default:
                    // エラー
                    return (status);
            }

            return (0);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 年度目標ガイド表示処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 年度目標ガイドを表示します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.25</br>
        /// </remarks>
        private void ShowYearSalesTarget()
        {
            DateTime applyStaDate;
            DateTime applyEndDate;

            MAMOK04110UA yearSalesTarget = new MAMOK04110UA();
            DialogResult dialogResult = yearSalesTarget.ShowGuide(this, out applyStaDate, out applyEndDate);

            if (dialogResult == DialogResult.OK)
            {
                // 検索前
                if (this._searchFlag == false)
                {
                    this.ApplyStaMonth_tDateEdit.SetDateTime(applyStaDate);
                    this.ApplyEndMonth_tDateEdit.SetDateTime(applyEndDate);

                    // 目標データ画面表示処理
                    DispScreenSalesTarget();
                    return;
                }

                List<SalesTarget> salesTargetList;
                List<SalesTarget> deleteSalesTargetList;

                // 修正後の勤怠データをバッファに保存
                ScreenToSalesTarget(out salesTargetList, out deleteSalesTargetList);

                bool retResult;

                // 修正目標データ比較
                retResult = CompareSalesTarget(salesTargetList);
                if (retResult)
                {
                    this.ApplyStaMonth_tDateEdit.SetDateTime(applyStaDate);
                    this.ApplyEndMonth_tDateEdit.SetDateTime(applyEndDate);

                    // 目標データ画面表示処理
                    DispScreenSalesTarget();

                    return;
                }

                // 保存確認
                DialogResult res = TMsgDisp.Show(
                    this, 							        // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_SAVECONFIRM, 	// エラーレベル
                    this.Name,						        // アセンブリID
                    "", 						            // 表示するメッセージ
                    0,								        // ステータス値
                    MessageBoxButtons.YesNoCancel);		    // 表示するボタン
                switch (res)
                {
                    case DialogResult.Yes:
                        // 保存前チェック
                        retResult = CheckSaveData();
                        if (!retResult)
                        {
                            return;
                        }

                        // 目標データ保存
                        retResult = SaveSalesTarget(ref salesTargetList);
                        if (!retResult)
                        {
                            return;
                        }

                        // 目標データ削除
                        retResult = DeleteSalesTarget(deleteSalesTargetList);
                        if (!retResult)
                        {
                            return;
                        }

                        this._salesTargetList = salesTargetList;

                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        return;
                }

                this.ApplyStaMonth_tDateEdit.SetDateTime(applyStaDate);
                this.ApplyEndMonth_tDateEdit.SetDateTime(applyEndDate);

                // 目標データ画面表示処理
                DispScreenSalesTarget();
            }

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ＸＭＬデータの保存処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面状態保持用のＸＭＬの保存処理を行います。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.27</br>
        /// </remarks>
        private void SaveStateXmlData()
        {
            if (this.uceAutoFitCol.Checked)
            {
                this.SalesTarget_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                this.SalesTarget_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
            }
            // グリッド情報を保存
            _gridStateController.SaveGridState(XML_FILE_INITIAL_DATA, ref this.SalesTarget_uGrid);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ＸＭＬデータの読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面状態保持用のＸＭＬの読込処理を行います。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.27</br>
        /// </remarks>
        private void LoadStateXmlData()
        {
            int status = _gridStateController.LoadGridState(XML_FILE_INITIAL_DATA, ref this.SalesTarget_uGrid);
            if (status == 0)
            {
                GridStateController.GridStateInfo gridStateInfo = _gridStateController.GetGridStateInfo(ref this.SalesTarget_uGrid);
                if (gridStateInfo != null)
                {
                    // フォントサイズ
                    this.cmbFontSize.Value = (int)gridStateInfo.FontSize;
                    // 列の自動調整
                    this.uceAutoFitCol.Checked = gridStateInfo.AutoFit;
                }
                else
                {
                    status = 4;
                }
            }
            if (status != 0)
            {
                // フォントサイズ
                this.cmbFontSize.Value = 10;
                // 列の自動調整
                this.uceAutoFitCol.Checked = false;
            }
        }

        /*----------------------------------------------------------------------------------*/
		/// <summary>
		/// コントロール配列化処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: RatioMonth_uLabelとRatioMonth_tNeditを配列化します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private void InitRatioMonthControl()
		{
			this._ratioMonth_uLabel = new Infragistics.Win.Misc.UltraLabel[12];

			this._ratioMonth_uLabel[0] = this.RatioMonth_uLabel1;
			this._ratioMonth_uLabel[1] = this.RatioMonth_uLabel2;
			this._ratioMonth_uLabel[2] = this.RatioMonth_uLabel3;
			this._ratioMonth_uLabel[3] = this.RatioMonth_uLabel4;
			this._ratioMonth_uLabel[4] = this.RatioMonth_uLabel5;
			this._ratioMonth_uLabel[5] = this.RatioMonth_uLabel6;
			this._ratioMonth_uLabel[6] = this.RatioMonth_uLabel7;
			this._ratioMonth_uLabel[7] = this.RatioMonth_uLabel8;
			this._ratioMonth_uLabel[8] = this.RatioMonth_uLabel9;
			this._ratioMonth_uLabel[9] = this.RatioMonth_uLabel10;
			this._ratioMonth_uLabel[10] = this.RatioMonth_uLabel11;
			this._ratioMonth_uLabel[11] = this.RatioMonth_uLabel12;

			this._ratioMonth_tNedit = new TNedit[12];

			this._ratioMonth_tNedit[0] = this.RatioMonth_tNedit;
			this._ratioMonth_tNedit[1] = this.RatioMonth_tNedit2;
			this._ratioMonth_tNedit[2] = this.RatioMonth_tNedit3;
			this._ratioMonth_tNedit[3] = this.RatioMonth_tNedit4;
			this._ratioMonth_tNedit[4] = this.RatioMonth_tNedit5;
			this._ratioMonth_tNedit[5] = this.RatioMonth_tNedit6;
			this._ratioMonth_tNedit[6] = this.RatioMonth_tNedit7;
			this._ratioMonth_tNedit[7] = this.RatioMonth_tNedit8;
			this._ratioMonth_tNedit[8] = this.RatioMonth_tNedit9;
			this._ratioMonth_tNedit[9] = this.RatioMonth_tNedit10;
			this._ratioMonth_tNedit[10] = this.RatioMonth_tNedit11;
			this._ratioMonth_tNedit[11] = this.RatioMonth_tNedit12;
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 画面情報初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面情報を初期化します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.25</br>
        /// </remarks>
        private void UndoScreenInfo()
        {
            if (this._searchFlag == false)
            {
                return;
            }

            List<SalesTarget> salesTargetList;
            List<SalesTarget> deleteSalesTargetList;

            // 修正後の勤怠データをバッファに保存
            ScreenToSalesTarget(out salesTargetList, out deleteSalesTargetList);

            bool retResult;

            // 修正目標データ比較
            retResult = CompareSalesTarget(salesTargetList);
            if (!retResult)
            {
                //
                // 変更あり
                //
                // 保存確認
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "現在、編集中のデータが存在します" + "\r\n" + "\r\n" +
                    "初期状態に戻しますか？",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);
                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }
            }

            // コントロール初期化
            ClearScreen();

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 修正目標データ比較処理
        /// </summary>
        /// <param name="salesTargetList">目標データリスト</param>
        /// <remarks>
        /// Note	   : 修正目標データを比較します。<br />
        /// Programmer : NEPCO<br />
        /// Date	   : 2007.05.08<br />
        /// </remarks>
        private bool CompareSalesTarget(List<SalesTarget> salesTargetList)
        {
            // 目標データ比較
            if (salesTargetList.Count != this._salesTargetList.Count)
            {
                return (false);
            }
            else
            {
                for (int i = 0; i < salesTargetList.Count; i++)
                {
                    if (!salesTargetList[i].Equals(this._salesTargetList[i]))
                    {
                        return (false);
                    }
                }
            }
            return (true);
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 終了前処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 画面を閉じる前に、目標データのチェックと保存を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private bool CloseSalesTarget()
		{
			if (this._searchFlag == false)
			{
				return (true);
			}

            List<SalesTarget> salesTargetList;
            List<SalesTarget> deleteSalesTargetList;

			// 修正後の勤怠データをバッファに保存
			ScreenToSalesTarget(out salesTargetList, out deleteSalesTargetList);

            bool retResult;

            // 修正目標データ比較
            retResult = CompareSalesTarget(salesTargetList);
            if (retResult)
            {
                // 変更なし
                return (true);
            }

            // 保存確認
            DialogResult res = TMsgDisp.Show(
                this, 							        // 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_SAVECONFIRM, 	// エラーレベル
                this.Name,						        // アセンブリID
                "", 						            // 表示するメッセージ
                0,								        // ステータス値
                MessageBoxButtons.YesNoCancel);		    // 表示するボタン
            switch (res)
            {
                case DialogResult.Yes:
                    break;
                case DialogResult.No:
                    return (true);
                case DialogResult.Cancel:
                    return (false);
            }

            // 入力値が正の半角数字かチェック
            retResult = CheckEditCharacter();
            if (!retResult)
            {
                return (false);
            }

            // 保存前チェック
            retResult = CheckSaveData();
            if (!retResult)
            {
                return (false);
            }

            // 目標データ保存
            retResult = SaveSalesTarget(ref salesTargetList);
            if (!retResult)
            {
                return (false);
            }

            // 目標データ削除
            retResult = DeleteSalesTarget(deleteSalesTargetList);
            if (!retResult)
            {
                return (false);
            }

            this._salesTargetList = salesTargetList;

			return (true);

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 目標データ保存前処理
		/// </summary>
		/// <remarks>
		/// Note	   : 修正目標データを保存前に処理します。<br />
		/// Programmer : NEPCO<br />
		/// Date	   : 2007.04.09<br />
		/// </remarks>
		private bool BeforeSaveSalesTarget()
		{
            // 検索チェック
            bool retResult = CheckSearchFlag();
            if (!retResult)
            {
                return (false);
            }

            // 保存前チェック
            retResult = CheckSaveData();
            if (!retResult)
            {
                return (false);
            }

			return (true);

		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 目標データ削除処理
        /// </summary>
        /// <param name="deleteSalesTargetList">削除用目標データリスト</param>
        /// <remarks>
        /// Note	   : 目標データを削除します。<br />
        /// Programmer : NEPCO<br />
        /// Date	   : 2007.05.08<br />
        /// </remarks>
        private bool DeleteSalesTarget(List<SalesTarget> deleteSalesTargetList)
        {
            List<SalesTarget> deleteList = new List<SalesTarget>();
            SalesTarget salesTargetComp;
            int targetIndex;

            foreach (SalesTarget salesTarget in deleteSalesTargetList)
            {
                salesTargetComp = new SalesTarget();
                salesTargetComp.ApplyStaDate = salesTarget.ApplyStaDate;
                targetIndex = this._salesTargetList.BinarySearch(salesTargetComp, new SalesTargetCompApplyStaDate());
                if (targetIndex >= 0)
                {
                    deleteList.Add(salesTarget);
                }
            }

            if (deleteList.Count == 0)
            {
                return (true);
            }

            // 目標データ更新
            int status = this._salesTargetAcs.Delete(deleteList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    TMsgDisp.Show(
                        this, 						                // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, 	    // エラーレベル
                        this.Name,								    // アセンブリID
                        "既に他端末より更新されています",           // 表示するメッセージ
                        status,									    // ステータス値
                        MessageBoxButtons.OK);					    // 表示するボタン
                    return (false);
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    TMsgDisp.Show(
                        this, 						                // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, 	    // エラーレベル
                        this.Name,								    // アセンブリID
                        "既に他端末より削除されています",		    // 表示するメッセージ
                        status,									    // ステータス値
                        MessageBoxButtons.OK);					    // 表示するボタン
                    return (false);
                default:
                    TMsgDisp.Show(
                        this, 						                // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOP,			    // エラーレベル
                        this.Name,								    // アセンブリID
                        ctPGNM, 		  　　					    // プログラム名称
                        "DeleteSalesTarget",						            // 処理名称
                        TMsgDisp.OPE_DELETE,					    // オペレーション
                        "目標データ修正時にエラーが発生しました",	// 表示するメッセージ
                        status,									    // ステータス値
                        this._salesTargetAcs,					    // エラーが発生したオブジェクト
                        MessageBoxButtons.OK,			  		    // 表示するボタン
                        MessageBoxDefaultButton.Button1);		    // 初期表示ボタン
                    return (false);
            }

            return (true);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 目標データ保存処理
        /// </summary>
        /// <param name="salesTargetList">目標データリスト</param>
        /// <remarks>
        /// Note	   : 目標データを保存します。<br />
        /// Programmer : NEPCO<br />
        /// Date	   : 2007.05.08<br />
        /// </remarks>
        private bool SaveSalesTarget(ref List<SalesTarget> salesTargetList)
        {
            // 目標データ更新
            int status = this._salesTargetAcs.Write(ref salesTargetList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    TMsgDisp.Show(
                        this, 						                // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, 	    // エラーレベル
                        this.Name,								    // アセンブリID
                        "既に他端末より更新されています",           // 表示するメッセージ
                        status,									    // ステータス値
                        MessageBoxButtons.OK);					    // 表示するボタン
                    return (false);
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    TMsgDisp.Show(
                        this, 						                // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, 	    // エラーレベル
                        this.Name,								    // アセンブリID
                        "既に他端末より削除されています",		    // 表示するメッセージ
                        status,									    // ステータス値
                        MessageBoxButtons.OK);					    // 表示するボタン
                    return (false);
                default:
                    TMsgDisp.Show(
                        this, 						                // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOP,			    // エラーレベル
                        this.Name,								    // アセンブリID
                        ctPGNM, 		  　　					    // プログラム名称
                        "SaveSalesTarget",						            // 処理名称
                        TMsgDisp.OPE_UPDATE,					    // オペレーション
                        "目標データ修正時にエラーが発生しました",	// 表示するメッセージ
                        status,									    // ステータス値
                        this._salesTargetAcs,					    // エラーが発生したオブジェクト
                        MessageBoxButtons.OK,			  		    // 表示するボタン
                        MessageBoxDefaultButton.Button1);		    // 初期表示ボタン
                    return (false);
            }

            SaveCompletionDialog dialog = new SaveCompletionDialog();
            dialog.ShowDialog(2);

            return (true);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 保存前チェック処理
        /// </summary>
        /// <remarks>
        /// Note	   : 目標データの保存前チェックをします。<br />
        /// Programmer : NEPCO<br />
        /// Date	   : 2007.05.08<br />
        /// </remarks>
        private bool CheckSaveData()
        {
            // 入力チェック
            bool retResult = CheckInputData();
            if (!retResult)
            {
                return (false);
            }

            // 入力合算値チェック
            retResult = CheckSalesTarget();
            if (!retResult)
            {
                return (false);
            }

            return (true);
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 修正目標データバッファ保存処理
		/// </summary>
        /// <param name="newSalesTargetList">保存用目標データリスト</param>
        /// <param name="deleteSalesTargetList">削除用目標データリスト</param>
		/// <remarks>
		/// Note	   : 修正対象の目標データをバッファに保存します。<br />
		/// Programmer : NEPCO<br />
		/// Date	   : 2007.04.09<br />
		/// </remarks>
		private void ScreenToSalesTarget(out List<SalesTarget> newSalesTargetList, out List<SalesTarget> deleteSalesTargetList)
		{
			newSalesTargetList = new List<SalesTarget>();
            deleteSalesTargetList = new List<SalesTarget>();

			SalesTarget salesTargetNew;
			SalesTarget salesTargetComp;

            string columnName;
			string targetText;
			string retText;
			int targetIndex;
            long longWork;
            double doubleWork;

			for (DateTime targetDate = this._targetDateSt; targetDate <= this._targetDateEd; targetDate = targetDate.AddMonths(1))
			{
                columnName = targetDate.Year.ToString() + targetDate.Month.ToString("00");

				salesTargetComp = new SalesTarget();
				salesTargetComp.ApplyStaDate = targetDate;
                // 保存データを検索
				targetIndex = this._salesTargetList.BinarySearch(salesTargetComp, new SalesTargetCompApplyStaDate());

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //if (this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Text == "" &&
                //    this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Text == "" &&
                //    this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Text == "")
                if ( this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Text == "" &&
                     this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Text == "")
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                {
                    //
                    // データ未設定の場合
                    //
                    if (targetIndex >= 0)
                    {
                        // 削除リストに追加
                        deleteSalesTargetList.Add(this._salesTargetList[targetIndex].Clone());
                    }
                    continue;
                }
                else
                {
                    //
                    // データが設定されている場合
                    //
                    if (targetIndex < 0)
                    {
                        // 新規
                        salesTargetNew = CreateSalesTarget(targetDate);
                    }
                    else
                    {
                        // 既存
                        salesTargetNew = this._salesTargetList[targetIndex].Clone();

                    }

                    // 売上目標
                    if (this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Text != "")
                    {
                        targetText = this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Text;
                        RemoveComma(targetText, out retText);

                        long.TryParse(retText, out longWork);
                        salesTargetNew.SalesTargetMoney = longWork;
                    }
                    else
                    {
                        salesTargetNew.SalesTargetMoney = 0;
                    }

                    // 粗利目標
                    if (this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Text != "")
                    {
                        targetText = this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Text;
                        RemoveComma(targetText, out retText);
                        //salesTargetNew.SalesTargetProfit = long.Parse(retText);

                        long.TryParse(retText, out longWork);
                        salesTargetNew.SalesTargetProfit = longWork;
                    }
                    else
                    {
                        salesTargetNew.SalesTargetProfit = 0;
                    }

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //// 数量目標
                    //if (this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Text != "")
                    //{
                    //    targetText = this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Text;
                    //    RemoveComma(targetText, out retText);
                    //    //salesTargetNew.SalesTargetCount = double.Parse(retText);

                    //    double.TryParse(retText, out doubleWork);
                    //    salesTargetNew.SalesTargetCount = doubleWork;
                    //}
                    //else
                    //{
                    //    salesTargetNew.SalesTargetCount = 0;
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                }

				newSalesTargetList.Add(salesTargetNew);
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 目標データ新規作成処理
		/// </summary>
        /// <param name="targetDate">適用年月</param>
		/// <remarks>
		/// Note	   : 目標データを新規作成します。<br />
		/// Programmer : NEPCO<br />
		/// Date	   : 2007.04.09<br />
		/// </remarks>
		private SalesTarget CreateSalesTarget(DateTime targetDate)
		{
			SalesTarget salesTarget = new SalesTarget();

            // 企業コード
            salesTarget.EnterpriseCode = this._enterpriseCode;
			// 拠点コード
            salesTarget.SectionCode = this._sectionCode;
			// 目標設定区分
			salesTarget.TargetSetCd = 10;
			// 目標対比区分
            salesTarget.TargetContrastCd = (int)SalesTarget.ConstrastCd.Section;
			// 目標区分コード
			salesTarget.TargetDivideCode = targetDate.Year.ToString("0000") + targetDate.Month.ToString("00");
			// 目標区分名称
			salesTarget.TargetDivideName = "";
			// 期間（開始）
			salesTarget.ApplyStaDate = targetDate.Date;
			// 期間（終了）
			int days = DateTime.DaysInMonth(targetDate.Year, targetDate.Month);
            salesTarget.ApplyEndDate = new DateTime(targetDate.Year, targetDate.Month, days);
            // 従業員コード
            salesTarget.EmployeeCode = EMPLOYEECODE_SECTION;

            return (salesTarget);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 入力合算値計算処理
		/// </summary>
        /// <param name="inputSalesTarget">入力テキスト</param>
        /// <param name="rowIndex">行インデックス</param>
		/// <remarks>
		/// <br>Note		: グリッドから入力合算値を求めます。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private void CalcInputSalesTarget(out double inputSalesTarget, int rowIndex)
		{
			inputSalesTarget = 0;
            string columnName;

			// 編集した行の入力合算値を求めます
			for (DateTime targetDate = this._targetDateSt; targetDate <= this._targetDateEd; targetDate = targetDate.AddMonths(1))
			{
                columnName = targetDate.Year.ToString() + targetDate.Month.ToString("00");

                if (this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnName].Text != "")
				{
                    inputSalesTarget += double.Parse(this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnName].Text);
				}
			}
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 比率計算前処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 比率から目標を計算します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.03.29</br>
        /// </remarks>
        private void BeforeCalcFromRatio()
        {
            // 比率計算（月別）
            CalcFromRatioSalesMon();

            string targetText;
            int columnIndex = 1;
            for (DateTime targetDate = this._targetDateSt; targetDate <= this._targetDateEd; targetDate = targetDate.AddMonths(1))
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 比率計算（日別）
                //CalcFromRatioSalesDay(targetDate);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //for (int rowIndex = ROW_SALESTARGETMONEY; rowIndex <= ROW_SALESTARGETCOUNT; rowIndex++)
                for ( int rowIndex = ROW_SALESTARGETMONEY; rowIndex <= ROW_SALESTARGETPROFIT; rowIndex++ )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                {
                    targetText = this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex].Text;
                    // テキスト色変更
                    SetEditTextColor(targetText, rowIndex, columnIndex);
                }
                columnIndex++;
            }
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 比率計算結果表示処理（月別）
		/// </summary>
		/// <remarks>
		/// <br>Note		: 比率から目標（月別）を計算し表示します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private void CalcFromRatioSalesMon()
		{
			double ratio = 0;
			int index = 0;

			// 比率合計
			for (DateTime targetDate = this._targetDateSt; targetDate <= this._targetDateEd; targetDate = targetDate.AddMonths(1))
			{
                if (this._ratioMonth_tNedit[index].DataText == "")
                {
                    ratio += 0;
                }
                else
                {
                    ratio += double.Parse(this._ratioMonth_tNedit[index].DataText);
                }
				index++;
			}

			// 期間目標
			double salesTargetMoney = 0;
			double salesTargetProfit = 0;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //double salesTargetCount = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			double targetMoney = 0;
			double targetProfit = 0;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //double targetCount = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            long salesMoney = 0;
            long salesProfit = 0;

			// 入力合算値
			double inputSalesTarget = 0;
			double inputSalesTargetProfit = 0;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //double inputSalesTargetCount = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			// 目標を比率から計算し、グリッドに表示
            if (this.SalesTargetMoney_tNedit.DataText != "")
            {
                salesTargetMoney = double.Parse(this.SalesTargetMoney_tNedit.DataText);
            }
            if (this.SalesTargetProfit_tNedit.DataText != "")
            {
                salesTargetProfit = double.Parse(this.SalesTargetProfit_tNedit.DataText);
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (this.SalesTargetCount_tNedit.DataText != "")
            //{
            //    salesTargetCount = double.Parse(this.SalesTargetCount_tNedit.DataText);
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // カラムのキー情報
            string columnName = "";
			index = 0;
            int columnIndex = 1;
			for (DateTime targetDate = this._targetDateSt; targetDate <= this._targetDateEd; targetDate = targetDate.AddMonths(1))
			{
                columnName = targetDate.Year.ToString() + targetDate.Month.ToString("00");

                // 売上目標（円）
                if (this.SalesTargetMoney_tNedit.DataText != "")
                {
                    if (this._ratioMonth_tNedit[index].DataText == "")
                    {
                        targetMoney = 0;
                    }
                    else
                    {
                        targetMoney = salesTargetMoney * double.Parse(this._ratioMonth_tNedit[index].DataText) / ratio;
                    }
                    salesMoney = (long)Math.Round(targetMoney, MidpointRounding.AwayFromZero);
                    inputSalesTarget += salesMoney;

                    if ((int)salesMoney == 0)
                    {
                        this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Value = null;
                    }
                    else
                    {
                        this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Value = salesMoney.ToString(FORMAT_NUM);
                    }
                }
                else
                {
                    this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Value = null;
                }
                // 粗利目標（円）
                if (this.SalesTargetProfit_tNedit.DataText != "")
                {
                    if (this._ratioMonth_tNedit[index].DataText == "")
                    {
                        targetProfit = 0;
                    }
                    else
                    {
                        targetProfit = salesTargetProfit * double.Parse(this._ratioMonth_tNedit[index].DataText) / ratio;
                    }
                    salesProfit = (long)Math.Round(targetProfit, MidpointRounding.AwayFromZero);
                    inputSalesTargetProfit += salesProfit;

                    if ((int)salesProfit == 0)
                    {
                        this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Value = null;
                    }
                    else
                    {
                        this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Value = salesProfit.ToString(FORMAT_NUM);
                    }
                }
                else
                {
                    this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Value = null;
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 数量目標（個）
                //if (this.SalesTargetCount_tNedit.DataText != "")
                //{
                //    if (this._ratioMonth_tNedit[index].DataText == "")
                //    {
                //        targetCount = 0;
                //    }
                //    else
                //    {
                //        targetCount = salesTargetCount * double.Parse(this._ratioMonth_tNedit[index].DataText) / ratio;
                //    }
                //    targetCount = Math.Round(targetCount, MidpointRounding.AwayFromZero);
                //    inputSalesTargetCount += targetCount;

                //    if ((int)targetCount == 0)
                //    {
                //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Value = null;
                //    }
                //    else
                //    {
                //        //this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Value = targetCount.ToString(FORMAT_NUM);
                //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Value = targetCount.ToString(FORMAT_NUM_DECIMAL);
                //    }
                //}
                //else
                //{
                //    this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Value = null;
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
				index++;
                columnIndex++;
			}

            //
			// 期間目標と入力合算値の整合性をとります
			//
            if (this.SalesTargetMoney_tNedit.DataText != "")
            {
                // 売上目標（円）
                salesMoney += (long)(salesTargetMoney - inputSalesTarget);
                this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Value = salesMoney.ToString(FORMAT_NUM);
            }
            if (this.SalesTargetProfit_tNedit.DataText != "")
            {
                // 粗利目標（円）
                salesProfit += (long)(salesTargetProfit - inputSalesTargetProfit);
                this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Value = salesProfit.ToString(FORMAT_NUM);
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (this.SalesTargetCount_tNedit.DataText != "")
            //{
            //    // 数量目標（個）
            //    targetCount += (salesTargetCount - inputSalesTargetCount);
            //    //this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Value = targetCount.ToString(FORMAT_NUM);
            //    this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Value = targetCount.ToString(FORMAT_NUM_DECIMAL);
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			this.InputSalesTargetMoney_tNedit.DataText = this.SalesTargetMoney_tNedit.DataText;
			this.InputSalesTargetProfit_tNedit.DataText = this.SalesTargetProfit_tNedit.DataText;
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.InputSalesTargetCount_tNedit.DataText = this.SalesTargetCount_tNedit.DataText;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		}

        /*----------------------------------------------------------------------------------*/
        ///// <summary>
        ///// 比率計算結果表示処理（日別）
        ///// </summary>
        ///// <param name="targetDate">適用年月</param>
        ///// <param name="weekdayRatio">平日比率</param>
        ///// <param name="satSunRatio">土日比率</param>
        ///// <remarks>
        ///// <br>Note		: 比率から目標（日別）を計算し表示します。</br>
        ///// <br>Programmer	: NEPCO</br>
        ///// <br>Date		: 2007.03.29</br>
        ///// </remarks>
        //private void CalcFromRatioSalesDay(DateTime targetDate)
        //{
        //    double[] salesTargetDayOfWeek;
        //    double salesTarget = 0;

        //    string columnName = targetDate.Year.ToString() + targetDate.Month.ToString("00");

        //    // 日数取得
        //    int iDaysInMonth = DateTime.DaysInMonth(targetDate.Year, targetDate.Month);
        //    // 月末取得
        //    DateTime endDate = new DateTime(targetDate.Year, targetDate.Month, iDaysInMonth);

        //    // 売上（円）
        //    if (this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Text != "")
        //    {
        //        salesTarget = double.Parse(this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Text);
        //        // 比率計算
        //        SalesLandingAcs.CalcDaySalesTargetFromRatio(
        //            out salesTargetDayOfWeek,
        //            salesTarget,
        //            0,
        //            targetDate,
        //            endDate,
        //            this._sectionCode,
        //            this._ldgCalcRatioMngList,
        //            this._holidaySettingDic);

        //        // 日曜売上
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_SUNDAY].Cells[columnName].Value = salesTargetDayOfWeek[0].ToString(FORMAT_NUM_ZERO);
        //        // 月曜売上
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_MONDAY].Cells[columnName].Value = salesTargetDayOfWeek[1].ToString(FORMAT_NUM_ZERO);
        //        // 火曜売上
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_TUESDAY].Cells[columnName].Value = salesTargetDayOfWeek[2].ToString(FORMAT_NUM_ZERO);
        //        // 水曜売上
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_WEDNESDAY].Cells[columnName].Value = salesTargetDayOfWeek[3].ToString(FORMAT_NUM_ZERO);
        //        // 木曜売上
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_THURSDAY].Cells[columnName].Value = salesTargetDayOfWeek[4].ToString(FORMAT_NUM_ZERO);
        //        // 金曜売上
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_FRIDAY].Cells[columnName].Value = salesTargetDayOfWeek[5].ToString(FORMAT_NUM_ZERO);
        //        // 土曜売上
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_SATURDAY].Cells[columnName].Value = salesTargetDayOfWeek[6].ToString(FORMAT_NUM_ZERO);
        //        // 祝祭日売上
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_HOLIDAY].Cells[columnName].Value = salesTargetDayOfWeek[7].ToString(FORMAT_NUM_ZERO);
        //    }
        //    else
        //    {
        //        // 日曜売上
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_SUNDAY].Cells[columnName].Value = null;
        //        // 月曜売上
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_MONDAY].Cells[columnName].Value = null;
        //        // 火曜売上
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_TUESDAY].Cells[columnName].Value = null;
        //        // 水曜売上
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_WEDNESDAY].Cells[columnName].Value = null;
        //        // 木曜売上
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_THURSDAY].Cells[columnName].Value = null;
        //        // 金曜売上
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_FRIDAY].Cells[columnName].Value = null;
        //        // 土曜売上
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_SATURDAY].Cells[columnName].Value = null;
        //        // 祝祭日売上
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_HOLIDAY].Cells[columnName].Value = null;
        //    }
        //    // 粗利（円）
        //    if (this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Text != "")
        //    {
        //        salesTarget = double.Parse(this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Text);
        //        // 比率計算
        //        SalesLandingAcs.CalcDaySalesTargetFromRatio(
        //            out salesTargetDayOfWeek,
        //            salesTarget,
        //            0,
        //            targetDate,
        //            endDate,
        //            this._sectionCode,
        //            this._ldgCalcRatioMngList,
        //            this._holidaySettingDic);

        //        // 日曜粗利
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_SUNDAY].Cells[columnName].Value = salesTargetDayOfWeek[0].ToString(FORMAT_NUM_ZERO);
        //        // 月曜粗利
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_MONDAY].Cells[columnName].Value = salesTargetDayOfWeek[1].ToString(FORMAT_NUM_ZERO);
        //        // 火曜粗利
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_TUESWDAY].Cells[columnName].Value = salesTargetDayOfWeek[2].ToString(FORMAT_NUM_ZERO);
        //        // 水曜粗利
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_WEDNESDAY].Cells[columnName].Value = salesTargetDayOfWeek[3].ToString(FORMAT_NUM_ZERO);
        //        // 木曜粗利
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_THURSDAY].Cells[columnName].Value = salesTargetDayOfWeek[4].ToString(FORMAT_NUM_ZERO);
        //        // 金曜粗利
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_FRIDAY].Cells[columnName].Value = salesTargetDayOfWeek[5].ToString(FORMAT_NUM_ZERO);
        //        // 土曜粗利
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_SATURDAY].Cells[columnName].Value = salesTargetDayOfWeek[6].ToString(FORMAT_NUM_ZERO);
        //        // 祝祭日粗利
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_HOLIDAY].Cells[columnName].Value = salesTargetDayOfWeek[7].ToString(FORMAT_NUM_ZERO);
        //    }
        //    else
        //    {
        //        // 日曜粗利
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_SUNDAY].Cells[columnName].Value = null;
        //        // 月曜粗利
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_MONDAY].Cells[columnName].Value = null;
        //        // 火曜粗利
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_TUESWDAY].Cells[columnName].Value = null;
        //        // 水曜粗利
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_WEDNESDAY].Cells[columnName].Value = null;
        //        // 木曜粗利
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_THURSDAY].Cells[columnName].Value = null;
        //        // 金曜粗利
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_FRIDAY].Cells[columnName].Value = null;
        //        // 土曜粗利
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_SATURDAY].Cells[columnName].Value = null;
        //        // 祝祭日粗利
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_HOLIDAY].Cells[columnName].Value = null;
        //    }
        //    // 数量（個）
        //    if (this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Text != "")
        //    {
        //        salesTarget = double.Parse(this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Text);
        //        // 比率計算
        //        SalesLandingAcs.CalcDaySalesTargetFromRatio(
        //            out salesTargetDayOfWeek,
        //            salesTarget,
        //            1,
        //            targetDate,
        //            endDate,
        //            this._sectionCode,
        //            this._ldgCalcRatioMngList,
        //            this._holidaySettingDic);

        //        // 日曜数量
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_SUNDAY].Cells[columnName].Value = salesTargetDayOfWeek[0].ToString(FORMAT_NUM_DECIMAL);
        //        // 月曜数量
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_MONDAY].Cells[columnName].Value = salesTargetDayOfWeek[1].ToString(FORMAT_NUM_DECIMAL);
        //        // 火曜数量
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_TUESDAY].Cells[columnName].Value = salesTargetDayOfWeek[2].ToString(FORMAT_NUM_DECIMAL);
        //        // 水曜数量
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_WEDNESDAY].Cells[columnName].Value = salesTargetDayOfWeek[3].ToString(FORMAT_NUM_DECIMAL);
        //        // 木曜数量
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_THURSDAY].Cells[columnName].Value = salesTargetDayOfWeek[4].ToString(FORMAT_NUM_DECIMAL);
        //        // 金曜数量
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_FRIDAY].Cells[columnName].Value = salesTargetDayOfWeek[5].ToString(FORMAT_NUM_DECIMAL);
        //        // 土曜数量
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_SATURDAY].Cells[columnName].Value = salesTargetDayOfWeek[6].ToString(FORMAT_NUM_DECIMAL);
        //        // 祝祭日数量
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_HOLIDAY].Cells[columnName].Value = salesTargetDayOfWeek[7].ToString(FORMAT_NUM_DECIMAL);
        //    }
        //    else
        //    {
        //        // 日曜数量
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_SUNDAY].Cells[columnName].Value = null;
        //        // 月曜数量
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_MONDAY].Cells[columnName].Value = null;
        //        // 火曜数量
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_TUESDAY].Cells[columnName].Value = null;
        //        // 水曜数量
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_WEDNESDAY].Cells[columnName].Value = null;
        //        // 木曜数量
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_THURSDAY].Cells[columnName].Value = null;
        //        // 金曜数量
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_FRIDAY].Cells[columnName].Value = null;
        //        // 土曜数量
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_SATURDAY].Cells[columnName].Value = null;
        //        // 祝祭日数量
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_HOLIDAY].Cells[columnName].Value = null;
        //    }
        //}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// テキスト色変更処理
        /// </summary>
        /// <param name="targetText">対象テキスト</param>
        /// <param name="rowIndex">行インデックス</param>
        /// <param name="columnIndex">カラムインデックス</param>
        /// <remarks>
        /// <br>Note		: 修正した目標のテキスト色を変更します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        private void SetEditTextColor(string targetText, int rowIndex, int columnIndex)
        {
            if (targetText == "")
            {
                return;
            }
            
            bool targetFlag = false;
            string targetDivideCode = this.SalesTarget_uGrid.Rows[ROW_DATE].Cells[columnIndex].Text;
            targetDivideCode = targetDivideCode.Substring(0, 4) + targetDivideCode.Substring(5, 2);

            // カンマ削除
            RemoveComma(targetText, out targetText);
            switch (rowIndex)
            {
                // 売上
                case ROW_SALESTARGETMONEY:
                    long salesTargetMoney = long.Parse(targetText);
                    foreach (SalesTarget salesTarget in this._salesTargetList)
                    {
                        if (salesTarget.TargetDivideCode.TrimEnd() == targetDivideCode.TrimEnd())
                        {
                            if (salesTarget.SalesTargetMoney != salesTargetMoney)
                            {
                                this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex].Appearance.ForeColor = Color.Red;
                            }
                            else
                            {
                                this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex].Appearance.ForeColor = Color.Black;
                            }
                            targetFlag = true;
                        }
                    }
                    break;
                // 粗利
                case ROW_SALESTARGETPROFIT:
                    long salesTargetProfit = long.Parse(targetText);
                    foreach (SalesTarget salesTarget in this._salesTargetList)
                    {
                        if (salesTarget.TargetDivideCode.TrimEnd() == targetDivideCode.TrimEnd())
                        {
                            if (salesTarget.SalesTargetProfit != salesTargetProfit)
                            {
                                this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex].Appearance.ForeColor = Color.Red;
                            }
                            else
                            {
                                this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex].Appearance.ForeColor = Color.Black;
                            }
                            targetFlag = true;
                        }
                    }
                    break;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 数量
                //case ROW_SALESTARGETCOUNT:
                //    double salesTargetCount = double.Parse(targetText);
                //    foreach (SalesTarget salesTarget in this._salesTargetList)
                //    {
                //        if (salesTarget.TargetDivideCode.TrimEnd() == targetDivideCode.TrimEnd())
                //        {
                //            if (salesTarget.SalesTargetCount != salesTargetCount)
                //            {
                //                this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex].Appearance.ForeColor = Color.Red;
                //            }
                //            else
                //            {
                //                this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex].Appearance.ForeColor = Color.Black;
                //            }
                //            targetFlag = true;
                //        }
                //    }
                //    break;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }
            if (targetFlag != true)
            {
                this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex].Appearance.ForeColor = Color.Red;
            }

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// セル幅取得処理
        /// </summary>
        /// <param name="fontSize">フォントサイズ</param>
        /// <remarks>
        /// <br>Note		: グリッドの見出しのセル幅を取得します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.06.20</br>
        /// </remarks>
        private int GetCellWidth(int fontSize)
        {
            int cellWidth;

            switch (fontSize)
            {
                case 6:
                    cellWidth = 100;
                    break;
                case 8:
                    cellWidth = 125;
                    break;
                case 9:
                    cellWidth = 140;
                    break;
                case 10:
                    cellWidth = 155;
                    break;
                case 11:
                    cellWidth = 170;
                    break;
                case 12:
                    cellWidth = 185;
                    break;
                case 14:
                    cellWidth = 215;
                    break;
                default:
                    cellWidth = 155;
                    break;
            }

            return cellWidth;
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// グリッドレイアウト設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: グリッドのレイアウト設定を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private void SetLayout_SalesTarget_uGrid()
		{
			this.SalesTarget_uGrid.DisplayLayout.UseFixedHeaders = true;

			this.SalesTarget_uGrid.DisplayLayout.Bands[0].ColHeadersVisible = false;

            // 列スタイル設定（Header）
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_HEADER].Header.Fixed = true;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_HEADER].Width = GetCellWidth((int)this.cmbFontSize.Value);
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_HEADER].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_HEADER].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_HEADER].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_HEADER].CellAppearance.BackColor = COLOR_BACKCOLOR;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_HEADER].CellAppearance.BackColor2 = COLOR_BACKCOLOR2;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_HEADER].CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_HEADER].CellAppearance.ForeColor = Color.White;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_HEADER].CellAppearance.ForeColorDisabled = Color.White;

            // 行固定
            this.SalesTarget_uGrid.DisplayLayout.Rows[ROW_CLEAR].Fixed = true;
            this.SalesTarget_uGrid.DisplayLayout.Rows[ROW_DATE].Fixed = true;

			// 見出し設定
            this.SalesTarget_uGrid.Rows[ROW_CLEAR].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_CLEAR;
            this.SalesTarget_uGrid.Rows[ROW_DATE].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_MONTH;
            this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_MONEY;
            this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_PROFIT;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_COUNT;

            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_SUNDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_MONEY_SUNDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_SUNDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_PROFIT_SUNDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_SUNDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_COUNT_SUNDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_MONDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_MONEY_MONDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_MONDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_PROFIT_MONDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_MONDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_COUNT_MONDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_TUESDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_MONEY_TUESDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_TUESWDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_PROFIT_TUESWDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_TUESDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_COUNT_TUESDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_WEDNESDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_MONEY_WEDNESDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_WEDNESDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_PROFIT_WEDNESDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_WEDNESDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_COUNT_WEDNESDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_THURSDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_MONEY_THURSDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_THURSDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_PROFIT_THURSDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_THURSDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_COUNT_THURSDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_FRIDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_MONEY_FRIDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_FRIDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_PROFIT_FRIDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_FRIDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_COUNT_FRIDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_SATURDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_MONEY_SATURDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_SATURDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_PROFIT_SATURDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_SATURDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_COUNT_SATURDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_HOLIDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_MONEY_HOLIDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_HOLIDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_PROFIT_HOLIDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_HOLIDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_COUNT_HOLIDAY;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
			if (this._searchFlag == false)
			{
				return;
			}

            // カラムのキー情報
            string columnName = "";
            int count = 0;

            // 動的カラムスタイル設定
			for (DateTime targetDate = this._targetDateSt; targetDate <= this._targetDateEd; targetDate = targetDate.AddMonths(1))
			{
                count++;

                columnName = targetDate.Year.ToString() + targetDate.Month.ToString("00");

                this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[columnName].Width = WIDTH_SALESTARGET;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[columnName].CellAppearance.ForeColorDisabled = Color.Black;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[columnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[columnName].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[columnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[columnName].MaxLength = 12;

				// クリア行設定
                this.SalesTarget_uGrid.Rows[ROW_CLEAR].Cells[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
                this.SalesTarget_uGrid.Rows[ROW_CLEAR].Cells[columnName].Activation = Activation.ActivateOnly;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[columnName].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
                this.SalesTarget_uGrid.Rows[ROW_CLEAR].Cells[columnName].ButtonAppearance.Image = IconResourceManagement.ImageList32.Images[(int)Size32_Index.RETRY];
                this.SalesTarget_uGrid.Rows[ROW_CLEAR].Cells[columnName].ButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                this.SalesTarget_uGrid.Rows[ROW_CLEAR].Cells[columnName].ButtonAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;

				// 年月
                this.SalesTarget_uGrid.DisplayLayout.Rows[ROW_DATE].Cells[columnName].Appearance.BackColor = COLOR_BACKCOLOR;
                this.SalesTarget_uGrid.DisplayLayout.Rows[ROW_DATE].Cells[columnName].Appearance.BackColor2 = COLOR_BACKCOLOR2;
                this.SalesTarget_uGrid.DisplayLayout.Rows[ROW_DATE].Cells[columnName].Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                this.SalesTarget_uGrid.DisplayLayout.Rows[ROW_DATE].Cells[columnName].Appearance.ForeColor = Color.White;
                this.SalesTarget_uGrid.DisplayLayout.Rows[ROW_DATE].Cells[columnName].Appearance.ForeColorDisabled = Color.White;
                this.SalesTarget_uGrid.DisplayLayout.Rows[ROW_DATE].Cells[columnName].Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                this.SalesTarget_uGrid.DisplayLayout.Rows[ROW_DATE].Cells[columnName].Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
                this.SalesTarget_uGrid.DisplayLayout.Rows[ROW_DATE].Cells[columnName].Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                this.SalesTarget_uGrid.DisplayLayout.Rows[ROW_DATE].Cells[columnName].Value = targetDate.Year.ToString() + "/" + targetDate.Month.ToString("00");
			}

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 「日曜売上」～「祝祭日数量」
            //for (int rowIndex = ROW_SALESTARGET_MONEY_SUNDAY; rowIndex <= ROW_SALESTARGET_COUNT_HOLIDAY; rowIndex++)
            //{
            //    // セル動作設定（比率部分）
            //    this.SalesTarget_uGrid.DisplayLayout.Rows[rowIndex].Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;

            //    for (DateTime targetDate = this._targetDateSt; targetDate <= this._targetDateEd; targetDate = targetDate.AddMonths(1))
            //    {
            //        columnName = targetDate.Year.ToString() + targetDate.Month.ToString("00");

            //        // セル背景色設定（比率部分）
            //        this.SalesTarget_uGrid.DisplayLayout.Rows[rowIndex].Cells[columnName].Appearance.BackColor = Color.FromName("control");
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// グリッド作成処理
		/// </summary>
        /// <param name="salesTargetList">目標データリスト</param>
		/// <remarks>
		/// <br>Note		: グリッドを作成します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private void DispScreen(List<SalesTarget> salesTargetList)
		{
			// データ追加用
			DataRow dataRow;

			// テーブルの定義
			DataTable dataTable = new DataTable();

			// カラム作成
			dataTable.Columns.Add(COL_SALESTARGET_HEADER, typeof(string));

            // カラムのキー情報
            string columnName = "";

			if (this._searchFlag == true)
			{
                for (DateTime targetDate = this._targetDateSt; targetDate <= this._targetDateEd; targetDate = targetDate.AddMonths(1))
                {
                    columnName = targetDate.Year.ToString() + targetDate.Month.ToString("00");

                    dataTable.Columns.Add(columnName, typeof(string));
                }
			}

			// データ行作成
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //for ( int index = ROW_CLEAR; index <= ROW_SALESTARGET_COUNT_HOLIDAY; index++ )
            for ( int index = ROW_CLEAR; index <= ROW_SALESTARGETPROFIT; index++ )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
			{
				dataRow = dataTable.NewRow();

				dataRow[COL_SALESTARGET_HEADER] = "";

				if (this._searchFlag == true)
				{
					for (DateTime targetDate = this._targetDateSt; targetDate <= this._targetDateEd; targetDate = targetDate.AddMonths(1))
					{
                        columnName = targetDate.Year.ToString() + targetDate.Month.ToString("00");

                        dataRow[columnName] = DBNull.Value;
					}
				}
				dataTable.Rows.Add(dataRow);
			}

			this.SalesTarget_uGrid.DataSource = dataTable;
			this.SalesTarget_uGrid.DataBind();
			
			if (this._searchFlag == false)
			{
				return;
			}

            // データ設定
			for (DateTime targetDate = this._targetDateSt; targetDate <= this._targetDateEd; targetDate = targetDate.AddMonths(1))
			{
                columnName = targetDate.Year.ToString() + targetDate.Month.ToString("00");

				foreach (SalesTarget salesTarget in salesTargetList)
				{
					if (salesTarget.ApplyStaDate.Date == targetDate.Date)
					{
                        this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Value = salesTarget.SalesTargetMoney.ToString(FORMAT_NUM);
                        this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Value = salesTarget.SalesTargetProfit.ToString(FORMAT_NUM);
                        
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                        ////this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Value = salesTarget.SalesTargetCount.ToString(FORMAT_NUM);
                        //if (salesTarget.SalesTargetCount == 0)
                        //{
                        //    this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Value = salesTarget.SalesTargetCount.ToString(FORMAT_NUM);
                        //}
                        //else
                        //{
                        //    this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Value = salesTarget.SalesTargetCount.ToString(FORMAT_NUM_DECIMAL);
                        //}

                        //// 比率計算（日別）
                        //CalcFromRatioSalesDay(targetDate);
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
					}
				}
			}
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 検索チェック処理
        /// </summary>
        /// <remarks>
        /// Note	   : 目標を検索済みかどうかチェックします。<br />
        /// Programmer : NEPCO<br />
        /// Date	   : 2007.04.27<br />
        /// </remarks>
        private bool CheckSearchFlag()
        {
            string errMsg = "";

            try
            {
                if (this._searchFlag == false)
                {
                    errMsg = "目標が入力されていません";
                    this.Search_Button.Focus();
                    return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    TMsgDisp.Show(
                            this, 							// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_INFO, 	// エラーレベル
                            this.Name,						// アセンブリID
                            errMsg, 						// 表示するメッセージ
                            0,								// ステータス値
                            MessageBoxButtons.OK);			// 表示するボタン
                }
            }
            return (true);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 入力合算値チェック処理
        /// </summary>
        /// <remarks>
        /// Note	   : 入力合算値と期間目標の値を比較します。<br />
        /// Programmer : NEPCO<br />
        /// Date	   : 2007.04.09<br />
        /// </remarks>
        private bool CheckSalesTarget()
        {
            bool checkDialog = false;

            if (this.SalesTargetMoney_tNedit.DataText != "")
            {
                if (this.SalesTargetMoney_tNedit.DataText != this.InputSalesTargetMoney_tNedit.DataText)
                {
                    checkDialog = true;
                }
            }
            if (this.SalesTargetProfit_tNedit.DataText != "")
            {
                if (this.SalesTargetProfit_tNedit.DataText != this.InputSalesTargetProfit_tNedit.DataText)
                {
                    checkDialog = true;
                }
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (this.SalesTargetCount_tNedit.DataText != "")
            //{
            //    if (this.SalesTargetCount_tNedit.DataText != this.InputSalesTargetCount_tNedit.DataText)
            //    {
            //        checkDialog = true;
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            if (checkDialog)
            {
                DialogResult res = TMsgDisp.Show(
                        this, 							// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO, 	// エラーレベル
                        this.Name,						// アセンブリID
                        "期間目標と入力合算値が違いますが保存しますか？", 						// 表示するメッセージ
                        0,								// ステータス値
                        MessageBoxButtons.OKCancel);			// 表示するボタン

                switch (res)
                {
                    case DialogResult.OK:
                        {
                            return (true);
                        }
                    case DialogResult.Cancel:
                        {
                            return (false);
                        }
                }
            }

            return (true);
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 修正目標データチェック処理
		/// </summary>
		/// <remarks>
		/// Note	   : 修正目標データをチェックします。<br />
		/// Programmer : NEPCO<br />
		/// Date	   : 2007.04.09<br />
		/// </remarks>
		private bool CheckInputData()
		{
            string columnName = "";

            // 目標入力チェック
            for (DateTime targetYearMonth = this._targetDateSt; targetYearMonth <= this._targetDateEd; targetYearMonth = targetYearMonth.AddMonths(1))
            {
                columnName = targetYearMonth.Year.ToString() + targetYearMonth.Month.ToString("00");

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //if (this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Text == "" &&
                //    this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Text == "" &&
                //    this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Text == "")
                if ( this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Text == "" &&
                    this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Text == "")
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                {
                    TMsgDisp.Show(
                            this, 							// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_INFO, 	// エラーレベル
                            this.Name,						// アセンブリID
                            "目標を入力してください", 						// 表示するメッセージ
                            0,								// ステータス値
                            MessageBoxButtons.OK);			// 表示するボタン

                    this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Activate();
                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                    return (false);
                }

                double inputSalesTarget = 0;
                double inputSalesTargetProfit = 0;
                double inputSalesTargetCount = 0;
                if (this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Text != "")
                {
                    inputSalesTarget = double.Parse(this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Text);
                }
                if (this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Text != "")
                {
                    inputSalesTargetProfit = double.Parse(this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Text);
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //if (this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Text != "")
                //{
                //    inputSalesTargetCount = double.Parse(this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Text);
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                if (inputSalesTarget == 0 && inputSalesTargetProfit == 0 && inputSalesTargetCount == 0)
                {
                    TMsgDisp.Show(
                            this, 							// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_INFO, 	// エラーレベル
                            this.Name,						// アセンブリID
                            "目標を入力してください", 						// 表示するメッセージ
                            0,								// ステータス値
                            MessageBoxButtons.OK);			// 表示するボタン

                    this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Activate();
                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                    return (false);
                }
            }

            return (true);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 検索条件チェック処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 検索条件の入力チェックを行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private bool CheckSearchCondition()
		{
			string errMsg = "";
			
			try
			{
                // 適用月(開始）
                if (this.ApplyStaMonth_tDateEdit.GetDateYear() == 0 ||
                    this.ApplyStaMonth_tDateEdit.GetDateMonth() == 0)
                {
                    errMsg = "日付を入力してください";
                    this.ApplyStaMonth_tDateEdit.Focus();
                    return (false);
                }
                if (this.ApplyStaMonth_tDateEdit.GetDateYear() != 0 &&
                    this.ApplyStaMonth_tDateEdit.GetDateMonth() != 0)
                {
                    try
                    {
                        DateTime dummyDateTime = new DateTime(
                            this.ApplyStaMonth_tDateEdit.GetDateYear(),
                            this.ApplyStaMonth_tDateEdit.GetDateMonth(),
                            1);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        errMsg = "日付を正しく入力してください";
                        this.ApplyStaMonth_tDateEdit.Focus();
                        return (false);
                    }
                }

                // 適用月(終了)
                if (this.ApplyEndMonth_tDateEdit.GetDateYear() == 0 ||
                    this.ApplyEndMonth_tDateEdit.GetDateMonth() == 0)
                {
                    errMsg = "日付を入力してください";
                    this.ApplyEndMonth_tDateEdit.Focus();
                    return (false);
                }
                if (this.ApplyEndMonth_tDateEdit.GetDateYear() != 0 &&
                    this.ApplyEndMonth_tDateEdit.GetDateMonth() != 0)
                {
                    try
                    {
                        DateTime dummyDateTime = new DateTime(
                            this.ApplyEndMonth_tDateEdit.GetDateYear(),
                            this.ApplyEndMonth_tDateEdit.GetDateMonth(),
                            1);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        errMsg = "日付を正しく入力してください";
                        this.ApplyEndMonth_tDateEdit.Focus();
                        return (false);
                    }
                }

				int salesTargetYmSt = this.ApplyStaMonth_tDateEdit.GetDateYear() * 100 + this.ApplyStaMonth_tDateEdit.GetDateMonth();
				int salesTargetYmEd = this.ApplyEndMonth_tDateEdit.GetDateYear() * 100 + this.ApplyEndMonth_tDateEdit.GetDateMonth();

				if (salesTargetYmSt > salesTargetYmEd)
				{
					errMsg = "開始　<=  終了で指定してください";
					this.ApplyStaMonth_tDateEdit.Focus();
					return (false);
				}
				if (salesTargetYmSt + 100 <= salesTargetYmEd)
				{
					errMsg = "期間は12ヶ月以内で指定してください";
					this.ApplyStaMonth_tDateEdit.Focus();
					return (false);
				}
			}
			finally
			{
				if (errMsg.Length > 0)
				{
					TMsgDisp.Show(
							this, 							        // 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_EXCLAMATION, 	// エラーレベル
							this.Name,						        // アセンブリID
							errMsg, 						        // 表示するメッセージ
							0,								        // ステータス値
							MessageBoxButtons.OK);			        // 表示するボタン
				}
			}

			return (true);
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 検索条件設定処理
        /// </summary>
        /// <param name="extrInfo">検索条件</param>
        /// <remarks>
        /// <br>Note		: 目標データの検索条件を設定します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.23</br>
        /// </remarks>
        private void GetExtrInfo(out ExtrInfo_MAMOK09197EA extrInfo)
        {
            extrInfo = new ExtrInfo_MAMOK09197EA();

            // 企業コード
            extrInfo.EnterpriseCode = this._enterpriseCode;
            // 拠点コード
            extrInfo.SelectSectCd = new string[1];
            extrInfo.SelectSectCd[0] = this._sectionCode;
            // 目標設定区分
            extrInfo.TargetSetCd = 10;
            // 目標対比区分
            extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.Section;

            int days;

            // 適用開始日（開始）
            extrInfo.ApplyStaDateSt = this._targetDateSt.Date;
            // 適用開始日（終了）
            extrInfo.ApplyStaDateEd = DateTime.MinValue;
            // 適用終了日（開始）
            extrInfo.ApplyEndDateSt = DateTime.MinValue;
            // 適用終了日（終了）
            days = DateTime.DaysInMonth(this._targetDateEd.Year, this._targetDateEd.Month);
            extrInfo.ApplyEndDateEd = new DateTime(this._targetDateEd.Year, this._targetDateEd.Month, days);

        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 計算条件チェック処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 比率から計算するための入力チェックを行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private bool CheckCalcCondition()
		{
			string errMsg = "";

			try
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //if (this.SalesTargetMoney_tNedit.DataText == "" &&
                //    this.SalesTargetProfit_tNedit.DataText == "" &&
                //    this.SalesTargetCount_tNedit.DataText == "")
                if ( this.SalesTargetMoney_tNedit.DataText == "" &&
                    this.SalesTargetProfit_tNedit.DataText == "" )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                {
                    errMsg = "目標金額または数量を入力してください";
                    this.SalesTargetMoney_tNedit.Focus();
                    return (false);
                }

                bool ratioFlag = true;
				int index = 0;
                for (DateTime targetDate = this._targetDateSt; targetDate <= this._targetDateEd; targetDate = targetDate.AddMonths(1))
                {
                    if (this._ratioMonth_tNedit[index].Value == null || double.Parse(this._ratioMonth_tNedit[index].DataText) == 0)
                    {
                        ratioFlag = false;
                    }
                    else
                    {
                        ratioFlag = true;
                        break;
                    }
                    index++;
                }
                if (ratioFlag == false)
                {
                    errMsg = "月別の比率を入力してください";
                    this._ratioMonth_tNedit[0].Focus();
                    return (false);
                }
			}
			finally
			{
				if (errMsg.Length > 0)
				{
					TMsgDisp.Show(
							this, 							// 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_INFO, 	// エラーレベル
							this.Name,						// アセンブリID
							errMsg, 						// 表示するメッセージ
							0,								// ステータス値
							MessageBoxButtons.OK);			// 表示するボタン
				}
			}
			return (true);
		}
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 入力値チェック処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 入力値が正の半角数字かどうかチェックを行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private bool CheckEditCharacter()
		{
            if (!this._searchFlag)
            {
                return (true);
            }
            if (this._editRowIndex < ROW_SALESTARGETMONEY)
            {
                return (true);
            }
            if (this._editColumnIndex < 1)
            {
                return (true);
            }
			if (this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Text == "")
			{
				return (true);
			}

			string errMsg = "";
			string checkText = "";
			double num;

			checkText = this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Text;

            try
            {
                if (!double.TryParse(checkText, out num) ||
                    checkText.Substring(0, 1) == "-")
                {
                    errMsg = "正の数値を入力してください";
                    this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Activate();
                    return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    TMsgDisp.Show(
                            this, 							// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_INFO, 	// エラーレベル
                            this.Name,						// アセンブリID
                            errMsg, 						// 表示するメッセージ
                            0,								// ステータス値
                            MessageBoxButtons.OK);			// 表示するボタン
                }
            }

            return (true);
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 入力日付チェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 入力された日付をチェックします。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.23</br>
        /// </remarks>
        private bool CheckInputDate(TDateEdit tDateEdit)
        {
            string errMsg = "";

            try
            {
                if (tDateEdit.GetDateYear() != 0 &&
                    tDateEdit.GetDateMonth() != 0)
                {
                    try
                    {
                        DateTime dummyDateTime = new DateTime(
                            tDateEdit.GetDateYear(),
                            tDateEdit.GetDateMonth(),
                            1);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        errMsg = "日付を正しく入力してください";
                        tDateEdit.Focus();
                        return (false);
                    }

                    if (tDateEdit.GetDateYear() == 1 &&
                    tDateEdit.GetDateMonth() == 1)
                    {
                        errMsg = "日付を正しく入力してください";
                        tDateEdit.Focus();
                        return (false);
                    }

                    if (tDateEdit.GetDateYear() < 1900)
                    {
                        errMsg = "日付を正しく入力してください";
                        tDateEdit.Focus();
                        return (false);
                    }
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    TMsgDisp.Show(
                                    this, 							// 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_INFO, 	// エラーレベル
                                    this.Name,						// アセンブリID
                                    errMsg, 						// 表示するメッセージ
                                    0,								// ステータス値
                                    MessageBoxButtons.OK);			// 表示するボタン
                }
            }
            return (true);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 列データ削除チェック処理
        /// </summary>
        /// <param name="columnIndex">カラムインデックス</param>
        /// <remarks>
        /// <br>Note		: 列データを削除する前にダイアログ確認を行います。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.03.30</br>
        /// </remarks>
        private void ClearTargetColumnData(int columnIndex)
        {
            string msg = "";

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 「売上目標」～「数量目標」
            //for (int rowIndex = ROW_SALESTARGETMONEY; rowIndex <= ROW_SALESTARGETCOUNT; rowIndex++)
            // 「売上目標」～「粗利目標」
            for ( int rowIndex = ROW_SALESTARGETMONEY; rowIndex <= ROW_SALESTARGETPROFIT; rowIndex++ )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            {
                if (this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex].Text != "")
                {
                    DateTime targetMonth = this._targetDateSt.AddMonths(columnIndex - 1);
                    msg = targetMonth.Year.ToString("0000") + "年" + targetMonth.Month.ToString("00") + "月の目標データをクリアしますが、よろしいですか？";

                    break;
                }
            }
            if (msg.Length <= 0)
            {
                return;
            }

            DialogResult res = TMsgDisp.Show(
                                    this, 							// 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_INFO, 	// エラーレベル
                                    this.Name,						// アセンブリID
                                    msg, 						    // 表示するメッセージ
                                    0,								// ステータス値
                                    MessageBoxButtons.OKCancel);	// 表示するボタン
            if (res != DialogResult.OK)
            {
                return;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 「売上目標」～「祝祭日数量」
            //for (int rowIndex = ROW_SALESTARGETMONEY; rowIndex <= ROW_SALESTARGET_COUNT_HOLIDAY; rowIndex++)
            // 「売上目標」～「粗利目標」
            for ( int rowIndex = ROW_SALESTARGETMONEY; rowIndex <= ROW_SALESTARGETPROFIT; rowIndex++ )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            {
                // 入力値の初期化
                this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex].Value = "";

                // 入力合算値表示
                SetInputSalesTarget(rowIndex);
            }
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// カンマ削除処理
		/// </summary>
        /// <param name="targetText">カンマ削除前テキスト</param>
        /// <param name="retText">カンマ削除済みテキスト</param>
		/// <remarks>
		/// <br>Note		: 対象のテキストからカンマを削除します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.30</br>
		/// </remarks>
		private void RemoveComma(string targetText, out string retText)
		{
			retText = "";

			// セル値編集用にカンマ削除
            for (int i = targetText.Length - 1; i >= 0; i--)
            {
                if (targetText[i].ToString() == ",")
                {
                    targetText = targetText.Remove(i, 1);
                }
            }

			retText = targetText;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// コントロールサイズ設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: コントロールサイズの設定を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private void SetControlSize()
		{
			// コントロールサイズ設定
			this.SalesTargetMoney_tNedit.Size = new Size(155, 24);
			this.SalesTargetProfit_tNedit.Size = new Size(155, 24);
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.SalesTargetCount_tNedit.Size = new Size(131, 24);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
			this.InputSalesTargetMoney_tNedit.Size = new Size(155, 24);
			this.InputSalesTargetProfit_tNedit.Size = new Size(155, 24);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.InputSalesTargetCount_tNedit.Size = new Size(131, 24);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.RatioSunday_tNedit.Size = new Size(66, 22);
            //this.RatioMonth_tNedit.Size = new Size(66, 22);
            //this.RatioTuesday_tNedit.Size = new Size(66, 22);
            //this.RatioWednesday_tNedit.Size = new Size(66, 22);
            //this.RatioThursday_tNedit.Size = new Size(66, 22);
            //this.RatioFriday_tNedit.Size = new Size(66, 22);
            //this.RatioSaturday_tNedit.Size = new Size(66, 22);
            //this.RatioHoliday_tNedit.Size = new Size(66, 22);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Neditスタイル設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: Neditのスタイルを設定します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.20</br>
        /// </remarks>
        private void SetNeditStyle()
        {
            this.SalesTargetMoney_tNedit.NumEdit.CommaEdit = true;
            this.SalesTargetMoney_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
            this.SalesTargetMoney_tNedit.NumEdit.MinusSupp = true;
            this.SalesTargetProfit_tNedit.NumEdit.CommaEdit = true;
            this.SalesTargetProfit_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
            this.SalesTargetProfit_tNedit.NumEdit.MinusSupp = true;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.SalesTargetCount_tNedit.NumEdit.CommaEdit = true;
            //this.SalesTargetCount_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
            //this.SalesTargetCount_tNedit.NumEdit.MinusSupp = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this.InputSalesTargetMoney_tNedit.NumEdit.CommaEdit = true;
            this.InputSalesTargetProfit_tNedit.NumEdit.CommaEdit = true;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.InputSalesTargetCount_tNedit.NumEdit.CommaEdit = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            for (int index = 0; index < 12; index++)
            {
                this._ratioMonth_tNedit[index].NumEdit.DecLen = 2;
                this._ratioMonth_tNedit[index].NumEdit.ZeroSupp = emZeroSupp.zsON;
                this._ratioMonth_tNedit[index].NumEdit.MinusSupp = true;
            }

            this.SalesTargetMoney_tNedit.ExtEdit.Column = 15;
            this.SalesTargetProfit_tNedit.ExtEdit.Column = 15;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.SalesTargetCount_tNedit.ExtEdit.Column = 10;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this.InputSalesTargetMoney_tNedit.ExtEdit.Column = 15;
            this.InputSalesTargetProfit_tNedit.ExtEdit.Column = 15;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.InputSalesTargetCount_tNedit.ExtEdit.Column = 10;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.RatioSunday_tNedit.NumEdit.DecLen = 2;
            //this.RatioSunday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
            //this.RatioSunday_tNedit.NumEdit.MinusSupp = true;
            //this.RatioSunday_tNedit.ExtEdit.Column = 6;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this.RatioMonth_tNedit.NumEdit.DecLen = 2;
            this.RatioMonth_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
            this.RatioMonth_tNedit.NumEdit.MinusSupp = true;
            this.RatioMonth_tNedit.ExtEdit.Column = 6;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.RatioTuesday_tNedit.NumEdit.DecLen = 2;
            //this.RatioTuesday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
            //this.RatioTuesday_tNedit.NumEdit.MinusSupp = true;
            //this.RatioTuesday_tNedit.ExtEdit.Column = 6;
            //this.RatioWednesday_tNedit.NumEdit.DecLen = 2;
            //this.RatioWednesday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
            //this.RatioWednesday_tNedit.NumEdit.MinusSupp = true;
            //this.RatioWednesday_tNedit.ExtEdit.Column = 6;
            //this.RatioThursday_tNedit.NumEdit.DecLen = 2;
            //this.RatioThursday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
            //this.RatioThursday_tNedit.NumEdit.MinusSupp = true;
            //this.RatioThursday_tNedit.ExtEdit.Column = 6;
            //this.RatioFriday_tNedit.NumEdit.DecLen = 2;
            //this.RatioFriday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
            //this.RatioFriday_tNedit.NumEdit.MinusSupp = true;
            //this.RatioFriday_tNedit.ExtEdit.Column = 6;
            //this.RatioSaturday_tNedit.NumEdit.DecLen = 2;
            //this.RatioSaturday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
            //this.RatioSaturday_tNedit.NumEdit.MinusSupp = true;
            //this.RatioSaturday_tNedit.ExtEdit.Column = 6;
            //this.RatioHoliday_tNedit.NumEdit.DecLen = 2;
            //this.RatioHoliday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
            //this.RatioHoliday_tNedit.NumEdit.MinusSupp = true;
            //this.RatioHoliday_tNedit.ExtEdit.Column = 6;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            for (int index = 0; index < 12; index++)
            {
                this._ratioMonth_tNedit[index].ExtEdit.Column = 6;
            }
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 目標データ検索処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: グリッドに表示する目標データを設定します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.09</br>
		/// </remarks>
		private bool SearchSalesTarget()
		{
			int status;
			ExtrInfo_MAMOK09197EA extrInfo;

            // 検索条件設定
            GetExtrInfo(out extrInfo);

			status = this._salesTargetAcs.Search(out this._salesTargetList, extrInfo, ConstantManagement.LogicalMode.GetData0);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
					break;
				default:
					TMsgDisp.Show(this, 						// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
						this.Name,								// アセンブリID
						ctPGNM, 			 　　				// プログラム名称
						"Search",								// 処理名称
						TMsgDisp.OPE_GET,						// オペレーション
						"目標データの読み込みに失敗しました", // 表示するメッセージ
						status,									// ステータス値
						this._salesTargetAcs,					// エラーが発生したオブジェクト
						MessageBoxButtons.OK,					// 表示するボタン
						MessageBoxDefaultButton.Button1);		// 初期表示ボタン
					return (false);
			}

			this._extrInfo = extrInfo;

			return (true);
		}

        /*----------------------------------------------------------------------------------*/
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// 曜日別比率表示処理
        ///// </summary>
        ///// <remarks>
        ///// <br>Note		: 曜日別の比率を画面に表示します。</br>
        ///// <br>Programmer	: NEPCO</br>
        ///// <br>Date		: 2007.07.12</br>
        ///// </remarks>
        //private void DispRatioDayOfWeek()
        //{
        //    // 比率を初期化します
        //    this.RatioSunday_tNedit.Value = RATIO;
        //    this.RatioMonday_tNedit.Value = RATIO;
        //    this.RatioTuesday_tNedit.Value = RATIO;
        //    this.RatioWednesday_tNedit.Value = RATIO;
        //    this.RatioThursday_tNedit.Value = RATIO;
        //    this.RatioFriday_tNedit.Value = RATIO;
        //    this.RatioSaturday_tNedit.Value = RATIO;
        //    this.RatioHoliday_tNedit.Value = RATIO;

        //    foreach (LdgCalcRatioMng ldgCalcRatioMng in this._ldgCalcRatioMngList)
        //    {
        //        if (ldgCalcRatioMng.SectionCode == this._sectionCode)
        //        {
        //            switch (ldgCalcRatioMng.DivisionAtDate)
        //            {
        //                case 0:
        //                    // 日曜
        //                    this.RatioSunday_tNedit.Value = ldgCalcRatioMng.Ratio.ToString("F");
        //                    break;
        //                case 1:
        //                    // 月曜
        //                    this.RatioMonday_tNedit.Value = ldgCalcRatioMng.Ratio.ToString("F");
        //                    break;
        //                case 2:
        //                    // 火曜
        //                    this.RatioTuesday_tNedit.Value = ldgCalcRatioMng.Ratio.ToString("F");
        //                    break;
        //                case 3:
        //                    // 水曜
        //                    this.RatioWednesday_tNedit.Value = ldgCalcRatioMng.Ratio.ToString("F");
        //                    break;
        //                case 4:
        //                    // 木曜
        //                    this.RatioThursday_tNedit.Value = ldgCalcRatioMng.Ratio.ToString("F");
        //                    break;
        //                case 5:
        //                    // 金曜
        //                    this.RatioFriday_tNedit.Value = ldgCalcRatioMng.Ratio.ToString("F");
        //                    break;
        //                case 6:
        //                    // 土曜
        //                    this.RatioSaturday_tNedit.Value = ldgCalcRatioMng.Ratio.ToString("F");
        //                    break;
        //                case 7:
        //                    // 祝祭日
        //                    this.RatioHoliday_tNedit.Value = ldgCalcRatioMng.Ratio.ToString("F");
        //                    break;
        //            }
        //        }
        //    }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 目標データ画面表示処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 目標データを表示します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.09</br>
        /// </remarks>
        private void DispScreenSalesTarget()
        {
            // 検索条件チェック処理
            bool bStatus = CheckSearchCondition();
            if (!bStatus)
            {
                return;
            }

            // 検索対象期間を取得
            this._targetDateSt = new DateTime(this.ApplyStaMonth_tDateEdit.GetDateYear(), this.ApplyStaMonth_tDateEdit.GetDateMonth(), 1);
            this._targetDateEd = new DateTime(this.ApplyEndMonth_tDateEdit.GetDateYear(), this.ApplyEndMonth_tDateEdit.GetDateMonth(), 1);

            // 目標データ検索
            bStatus = SearchSalesTarget();
            if (!bStatus)
            {
                return;
            }

            // 検索フラグ
            this._searchFlag = true;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 各曜日の比率取得
            //DispRatioDayOfWeek();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 比率コントロール表示
            ShowRatioControl();

            // グリッド作成
            DispScreen(this._salesTargetList);
            // グリッドレイアウト設定
            SetLayout_SalesTarget_uGrid();

            // 入力合算値取得
            // 売上
            SetInputSalesTarget(ROW_SALESTARGETMONEY);
            this.SalesTargetMoney_tNedit.DataText = this.InputSalesTargetMoney_tNedit.DataText;

            // 粗利
            SetInputSalesTarget(ROW_SALESTARGETPROFIT);
            this.SalesTargetProfit_tNedit.DataText = this.InputSalesTargetProfit_tNedit.DataText;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 数量
            //SetInputSalesTarget(ROW_SALESTARGETCOUNT);
            //this.SalesTargetCount_tNedit.DataText = InputSalesTargetCount_tNedit.DataText;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // コントロール制御
            SetControlEnabled();
            
            // 列サイズ自動調整
            ChangeAutoFitStyle();
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 画面情報クリア処理
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 画面情報をクリアします。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.09</br>
		/// </remarks>
		private void ClearScreen()
		{
            // 検索フラグ
            this._searchFlag = false;

            // コントロールサイズ設定
            SetControlSize();

            // Nedit スタイル設定
            SetNeditStyle();

            // コントロール制御
            SetControlEnabled();

			// 売上目標の初期化
			this.SalesTargetMoney_tNedit.DataText = "";
			this.SalesTargetProfit_tNedit.DataText = "";
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.SalesTargetCount_tNedit.DataText = "";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			// 入力合算値の初期化
            this.InputSalesTargetMoney_tNedit.DataText = "";
            this.InputSalesTargetProfit_tNedit.DataText = "";
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.InputSalesTargetCount_tNedit.DataText = "";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 曜日別比率
            //this.RatioSunday_tNedit.Value = "";
            //this.RatioMonday_tNedit.Value = "";
            //this.RatioTuesday_tNedit.Value = "";
            //this.RatioWednesday_tNedit.Value = "";
            //this.RatioThursday_tNedit.Value = "";
            //this.RatioFriday_tNedit.Value = "";
            //this.RatioSaturday_tNedit.Value = "";
            //this.RatioHoliday_tNedit.Value = "";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			for (int index = 0; index < 12; index++)
			{
				this._ratioMonth_uLabel[index].Visible = true;
				this._ratioMonth_tNedit[index].Visible = true;
                this._ratioMonth_tNedit[index].Enabled = false;
                this._ratioMonth_uLabel[index].Text = "";
                this._ratioMonth_tNedit[index].DataText = "";
			}

            this._salesTargetList = new List<SalesTarget>();

            this._targetDateSt = DateTime.MinValue;
            this._targetDateEd = DateTime.MinValue;

            // グリッド表示
            DispScreen(this._salesTargetList);
            // グリッドレイアウト設定
            SetLayout_SalesTarget_uGrid();

            // 列サイズ自動調整
            ChangeAutoFitStyle();

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// コントロール制御処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: コントロールの制御を行います。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.20</br>
        /// </remarks>
        private void SetControlEnabled()
        {
            // 検索後
            if (this._searchFlag == true)
            {
                this.Search_Button.Enabled = true;
                this.Clear_Button.Enabled = false;
                this.ApplyStaMonth_tDateEdit.Enabled = false;
                this.ApplyEndMonth_tDateEdit.Enabled = false;

                this.SalesTargetMoney_tNedit.Enabled = true;
                this.SalesTargetProfit_tNedit.Enabled = true;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //this.SalesTargetCount_tNedit.Enabled = true;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }
            // 検索前
            else
            {
                this.Search_Button.Enabled = true;
                this.Clear_Button.Enabled = true;
                this.ApplyStaMonth_tDateEdit.Enabled = true;
                this.ApplyEndMonth_tDateEdit.Enabled = true;

                this.SalesTargetMoney_tNedit.Enabled = false;
                this.SalesTargetProfit_tNedit.Enabled = false;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //this.SalesTargetCount_tNedit.Enabled = false;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 比率コントロール表示処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 比率コントロールを動的に表示します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.20</br>
        /// </remarks>
        private void ShowRatioControl()
        {
            int index = 0;
            // 検索期間の比率コントロールを表示します。
            for (DateTime targetDate = this._targetDateSt; targetDate <= this._targetDateEd; targetDate = targetDate.AddMonths(1))
            {
                this._ratioMonth_uLabel[index].Visible = true;
                this._ratioMonth_tNedit[index].Visible = true;
                this._ratioMonth_tNedit[index].Enabled = true;

                // 目標データが１件以上ある場合
                if (this._salesTargetList.Count > 0)
                {
                    this._ratioMonth_tNedit[index].Value = "";
                }
                // 目標データが１件もない場合
                else
                {
                    this._ratioMonth_tNedit[index].Value = RATIO;
                }

                this._ratioMonth_uLabel[index].Text = targetDate.Year.ToString() + "/" + targetDate.Month.ToString("00");

                index++;
            }
            // 検索期間がひと月の場合、比率コントロールを変更不可にします。
            if (index == 1)
            {
                this._ratioMonth_tNedit[index - 1].Value = RATIO;
                this._ratioMonth_tNedit[index - 1].Enabled = false;
            }
            // 検索期間外の比率コントロールを非表示にします。
            for (int i = index; i < 12; i++)
            {
                this._ratioMonth_uLabel[i].Visible = false;
                this._ratioMonth_tNedit[i].Visible = false;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 入力合算値表示処理
        /// </summary>
        /// <param name="rowIndex">行インデックス</param>
        /// <remarks>
        /// <br>Note		: 入力合算値を計算し、コントロールに表示します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.05.08</br>
        /// </remarks>
        private void SetInputSalesTarget(int rowIndex)
        {
            double inputSalesTarget;

            // 売上目標（円）の入力合算値
            if (rowIndex == ROW_SALESTARGETMONEY)
            {
                CalcInputSalesTarget(out inputSalesTarget, rowIndex);
                this.InputSalesTargetMoney_tNedit.DataText = inputSalesTarget.ToString();
            }
            // 粗利目標（円）の入力合算値
            else if (rowIndex == ROW_SALESTARGETPROFIT)
            {
                CalcInputSalesTarget(out inputSalesTarget, rowIndex);
                this.InputSalesTargetProfit_tNedit.DataText = inputSalesTarget.ToString();
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 数量目標（個）の入力合算値
            //else if (rowIndex == ROW_SALESTARGETCOUNT)
            //{
            //    CalcInputSalesTarget(out inputSalesTarget, rowIndex);
            //    this.InputSalesTargetCount_tNedit.DataText = inputSalesTarget.ToString();
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 列サイズ自動調整処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: チェックボックスのチェック状態によって列サイズの自動調整を制御します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.07.26</br>
        /// </remarks>
        private void ChangeAutoFitStyle()
        {
            string columnName = "";

            if (this.SalesTarget_uGrid.DataSource == null ||
                this._salesTargetList == null ||
                this._salesTargetList.Count <= 0)
            {
                this.SalesTarget_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
                return;
            }

            if (this.uceAutoFitCol.Checked)
            {
                this.SalesTarget_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                this.SalesTarget_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
                // グリッドの見出しの幅設定
                this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_HEADER].Width = GetCellWidth((int)this.cmbFontSize.Value);

                for (DateTime targetDate = this._targetDateSt; targetDate <= this._targetDateEd; targetDate = targetDate.AddMonths(1))
                {
                    columnName = targetDate.Year.ToString() + targetDate.Month.ToString("00");
                    this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[columnName].Width = WIDTH_SALESTARGET;
                }
            }
        }

        # endregion Private Methods

        # region Control Events

        /*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Form_Load イベント処理(MAMOK01110UA)
		/// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: フォームロード処理を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private void MAMOK01110UA_Load(object sender, EventArgs e)
		{
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

			// コントロール配列化
			InitRatioMonthControl();

            // 画面クリア
            ClearScreen();

            this.ApplyStaMonth_tDateEdit.Focus();

            this.SalesTarget_uGrid.ActiveRow = null;

            // 期首月設定
            int year = DateTime.Now.Year;
            DateTime targetDateSt = new DateTime(year, this._companyBiginMonth, 1);
            this.ApplyStaMonth_tDateEdit.SetDateTime(targetDateSt);
            this.ApplyEndMonth_tDateEdit.SetDateTime(targetDateSt.AddMonths(11));

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.23 TOKUNAGA ADD START
            // 拠点情報取得 画面上にセット
            this.SectionCode_tNedit.DataText = this._sectionCode.TrimEnd();
            this.SectionName_tEdit.DataText = this._sectionName.TrimEnd();

            // 拠点コードガイドボタン
            this.SectionCodeGuide_ultraButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.23 TOKUNAGA ADD END

            // XMLデータ読込
            LoadStateXmlData();

            // メインフレームにツールバー設定通知
            if (ParentToolbarSettingEvent != null) this.ParentToolbarSettingEvent(this);
        }

        /// <summary>
        /// 画面アクティブイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 画面がアクティブになったときのイベント処理です。</br>
        /// <br>Programer  : NEPCO</br>
        /// <br>Date       : 2007.05.08</br>
        /// </remarks>
        private void MAMOK01110UA_Activated(object sender, EventArgs e)
        {
            // メインフレームにツールバー設定通知
            if (ParentToolbarSettingEvent != null) this.ParentToolbarSettingEvent(this);
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click イベント処理(Search_Button)
		/// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 検索ボタンをクリックされた時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private void Search_Button_Click(object sender, EventArgs e)
		{
            // 再検索の場合
            if (this._searchFlag == true)
            {
                string errMsg = "編集中のデータは破棄されますが、よろしいですか？";
                DialogResult res = TMsgDisp.Show(
                                this, 							// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO, 	// エラーレベル
                                this.Name,						// アセンブリID
                                errMsg, 						// 表示するメッセージ
                                0,								// ステータス値
                                MessageBoxButtons.OKCancel);	// 表示するボタン
                switch (res)
                {
                    case DialogResult.OK:
                        break;
                    case DialogResult.Cancel:
                        return;
                }
            }

            // 目標データ画面表示処理
            DispScreenSalesTarget();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click イベント処理(Clear_Button)
		/// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: クリアボタンをクリックされた時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.09</br>
		/// </remarks>
		private void Clear_Button_Click(object sender, EventArgs e)
		{
            this.ApplyStaMonth_tDateEdit.SetDateTime(new DateTime());
            this.ApplyEndMonth_tDateEdit.SetDateTime(new DateTime());
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Leave イベント(ApplyStaMonth_tDateEdit)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: コントロールからフォーカスが離れた時に発生します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.17</br>
        /// </remarks>
        private void ApplyStaMonth_tDateEdit_Leave(object sender, EventArgs e)
        {
            if (this.ApplyStaMonth_tDateEdit.GetDateYear() == 0 ||
                this.ApplyStaMonth_tDateEdit.GetDateMonth() == 0)
            {
                return;
            }

            // 入力日付チェック
            bool bStatus = CheckInputDate(this.ApplyStaMonth_tDateEdit);
            if (!bStatus)
            {
                return;
            }

            this.ApplyStaMonth_tDateEdit.SetDateTime(new DateTime(ApplyStaMonth_tDateEdit.GetDateYear(), ApplyStaMonth_tDateEdit.GetDateMonth(), 1));
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Leave イベント(ApplyEndMonth_tDateEdit)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: コントロールからフォーカスが離れた時に発生します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.17</br>
        /// </remarks>
        private void ApplyEndMonth_tDateEdit_Leave(object sender, EventArgs e)
        {
            if (this.ApplyEndMonth_tDateEdit.GetDateYear() == 0 ||
                this.ApplyEndMonth_tDateEdit.GetDateMonth() == 0)
            {
                return;
            }

            // 入力日付チェック
            bool bStatus = CheckInputDate(this.ApplyEndMonth_tDateEdit);
            if (!bStatus)
            {
                return;
            }

            this.ApplyEndMonth_tDateEdit.SetDateTime(new DateTime(ApplyEndMonth_tDateEdit.GetDateYear(), ApplyEndMonth_tDateEdit.GetDateMonth(), 1));
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Leave イベント(SalesTarget_uGrid)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: コントロールからフォーカスが離れた時に発生します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.17</br>
        /// </remarks>
        private void SalesTarget_uGrid_Leave(object sender, EventArgs e)
        {
            if (this._closing)
            {
                return;
            }

            this.SalesTarget_uGrid.ActiveCell = null;
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// セル編集前イベント
		/// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: セルが編集モードになった時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.30</br>
		/// </remarks>
		private void SalesTarget_uGrid_AfterEnterEditMode(object sender, EventArgs e)
		{
            // 編集する行を取得
            this._editRowIndex = this.SalesTarget_uGrid.ActiveRow.Index;
            this._editColumnIndex = this.SalesTarget_uGrid.ActiveCell.Column.Index;

            if (this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Text == "")
            {
                return;
            }
            double salesTarget = double.Parse(this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Text);
            //string targetText = this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Text;
            string targetText = salesTarget.ToString(FORMAT_NUM);
            string retText;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (this._editRowIndex <= ROW_SALESTARGETCOUNT)
            if ( this._editRowIndex <= ROW_SALESTARGETPROFIT )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            {
                // カンマ削除処理
                RemoveComma(targetText, out retText);
            }
            else
            {
                retText = targetText;
            }

            this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Value = retText;
            this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].SelStart = 0;
            this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].SelLength = retText.Length;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// セル編集終了前イベント
		/// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: セルの編集を終了する前に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private void SalesTarget_uGrid_BeforeExitEditMode(object sender, BeforeExitEditModeEventArgs e)
		{
            if (this._closing)
            {
                return;
            }

			// 入力値が正の半角数字かチェック
            bool status = CheckEditCharacter();
            if (!status)
            {
                e.Cancel = true;
                this._cancelFlag = true;
                return;
            }
            string targetText = this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Text;

            // テキスト色変更
            SetEditTextColor(targetText, this._editRowIndex, this._editColumnIndex);

            this._cancelFlag = false;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// セル編集後イベント
		/// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: セルの編集を終了した後に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private void SalesTarget_uGrid_AfterExitEditMode(object sender, EventArgs e)
		{
            if (!this._searchFlag)
            {
                return;
            }

            if (this._closing)
            {
                return;
            }

			double inputSalesTarget;

            // 入力合算値表示
            SetInputSalesTarget(this._editRowIndex);

            // セルに値がある場合
            if (this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Text != "")
            {
                // セル値の書式変換
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //if (this._editRowIndex < ROW_SALESTARGETCOUNT)
                if ( this._editRowIndex <= ROW_SALESTARGETPROFIT )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                {
                    inputSalesTarget = double.Parse(this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Text);
                    this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Value = inputSalesTarget.ToString(FORMAT_NUM);
                }
                else
                {
                    inputSalesTarget = double.Parse(this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Text);
                    //this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Value = inputSalesTarget.ToString(FORMAT_NUM);
                    if (inputSalesTarget == 0)
                    {
                        this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Value = inputSalesTarget.ToString(FORMAT_NUM);
                    }
                    else
                    {
                        this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Value = inputSalesTarget.ToString(FORMAT_NUM_DECIMAL);
                    }
                }
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// セルの値を消去した場合
            //if (this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Text == "")
            //{
            //    // 売上
            //    if (this._editRowIndex == ROW_SALESTARGETMONEY)
            //    {
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_SUNDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_MONDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_TUESDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_WEDNESDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_THURSDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_FRIDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_SATURDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_HOLIDAY].Cells[this._editColumnIndex].Value = "";
            //    }
            //    // 粗利
            //    else if (this._editRowIndex == ROW_SALESTARGETPROFIT)
            //    {
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_SUNDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_MONDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_TUESWDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_WEDNESDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_THURSDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_FRIDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_SATURDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_HOLIDAY].Cells[this._editColumnIndex].Value = "";
            //    }
            //    // 数量
            //    else if (this._editRowIndex == ROW_SALESTARGETCOUNT)
            //    {
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_SUNDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_MONDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_TUESDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_WEDNESDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_THURSDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_FRIDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_SATURDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_HOLIDAY].Cells[this._editColumnIndex].Value = "";
            //    }
            //    return;
            //}

            //// 比率計算
            //CalcFromRatioSalesDay(this._targetDateSt.AddMonths(this._editColumnIndex - 1));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
        /// ClickCellButton イベント(SalesTarget_uGrid)
		/// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: クリアボタンをクリックした時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private void SalesTarget_uGrid_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
		{
            if (this._cancelFlag)
            {
                return;
            }
            int columnIndex = this.SalesTarget_uGrid.ActiveCell.Column.Index;

            // 列データ削除チェック処理
            ClearTargetColumnData(columnIndex);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// フォントサイズ変更イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: フォントサイズの値が変更された後に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.30</br>
		/// </remarks>
		private void cmbFontSize_ValueChanged(object sender, EventArgs e)
		{
			// フォントサイズを変更
			this.SalesTarget_uGrid.DisplayLayout.Appearance.FontData.SizeInPoints
				= (int)cmbFontSize.Value;

            // グリッドの見出しの幅設定
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_HEADER].Width = GetCellWidth((int)this.cmbFontSize.Value);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 列サイズの自動調整チェックチェンジイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: チェックボックスのチェック状態が変更されたタイミングで発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.30</br>
		/// </remarks>
		private void uceAutoFitCol_CheckedChanged(object sender, EventArgs e)
		{
            // 列サイズ自動調整処理
            ChangeAutoFitStyle();   
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// tArrowKeyControlChangeFocusイベント
		/// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: コントロールのフォーカスが変わるタイミングで発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.05</br>
		/// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            int rowCount = this.SalesTarget_uGrid.Rows.Count;
            int columnCount = this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns.Count;

            // Nextフォーカスがグリッドの場合
            if (e.NextCtrl == this.SalesTarget_uGrid)
            {
                // 検索後
                if (this._searchFlag == true)
                {
                    if (e.Key == Keys.Down)
                    {
                        e.NextCtrl = null;
                        this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[1].Activate();
                        this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                    }
                    else if (e.Key == Keys.Up)
                    {
                        e.NextCtrl = null;
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                        //this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[1].Activate();
                        this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[1].Activate();
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                        this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                    }
                    else if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                    {
                        e.NextCtrl = null;
                        this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[1].Activate();
                        this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                    }
                    return;
                }
                // 検索前
                else
                {
                    if (e.Key == Keys.Up)
                    {
                        e.NextCtrl = this.Search_Button;
                    }
                    else if (e.Key == Keys.Down)
                    {
                        e.NextCtrl = this.cmbFontSize;
                    }
                    else if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                    {
                        e.NextCtrl = this.cmbFontSize;
                    }
                }
            }
            if (e.PrevCtrl == this.SalesTarget_uGrid)
            {
                // 入力値が正の半角数字かチェック
                bool status = CheckEditCharacter();
                if (!status)
                {
                    e.NextCtrl = null;
                    return;
                }
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// KeyDown イベント(SalesTarget_uGrid)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: カーソルボタンを押した時に発生します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.05.28</br>
        /// </remarks>
        private void SalesTarget_uGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.SalesTarget_uGrid.Rows.Count < 1)
            {
                return;
            }

            if (this.SalesTarget_uGrid.ActiveCell == null)
            {
                return;
            }

            int rowIndex = this.SalesTarget_uGrid.ActiveRow.Index;
            int rowCount = this.SalesTarget_uGrid.Rows.Count;
            int columnIndex = this.SalesTarget_uGrid.ActiveCell.Column.Index;
            int columnCount = this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns.Count;

            if (e.KeyCode == Keys.Up)
            {
                if (rowIndex == ROW_CLEAR)
                {
                    this.RatioMonth_tNedit.Focus();
                }
                else if (rowIndex > ROW_CLEAR && rowIndex <= ROW_SALESTARGETMONEY)
                {
                    this.SalesTarget_uGrid.Rows[ROW_CLEAR].Cells[columnIndex].Activate();
                    e.Handled = true;
                    return;
                }
                else if (rowIndex > ROW_SALESTARGETMONEY)
                {
                    this.SalesTarget_uGrid.Rows[rowIndex - 1].Cells[columnIndex].Activate();
                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode, true, false);
                    e.Handled = true;
                    return;
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //if (rowIndex != ROW_SALESTARGETCOUNT)
                if ( rowIndex != ROW_SALESTARGETPROFIT )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                {
                    if (rowIndex == ROW_CLEAR)
                    {
                        this.SalesTarget_uGrid.Rows[rowIndex + 2].Cells[columnIndex].Activate();
                    }
                    else
                    {
                        this.SalesTarget_uGrid.Rows[rowIndex + 1].Cells[columnIndex].Activate();
                    }
                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode, true, false);
                    e.Handled = true;
                    return;
                }
                else
                {
                    this.cmbFontSize.Focus();
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (columnIndex + 1 != columnCount)
                {
                    this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex + 1].Activate();
                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode, true, false);
                    e.Handled = true;
                    return;
                }
                else
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //if (rowIndex != ROW_SALESTARGETCOUNT)
                    if ( rowIndex != ROW_SALESTARGETPROFIT )
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    {
                        if (rowIndex == ROW_CLEAR)
                        {
                            this.SalesTarget_uGrid.Rows[rowIndex + 2].Cells[1].Activate();
                        }
                        else
                        {
                            this.SalesTarget_uGrid.Rows[rowIndex + 1].Cells[1].Activate();
                        }
                        
                        this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode, true, false);
                        e.Handled = true;
                        return;
                    }
                    else
                    {
                        this.cmbFontSize.Focus();
                    }
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (columnIndex != 1)
                {
                    this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex - 1].Activate();
                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode, true, false);
                    e.Handled = true;
                    return;
                }
                else
                {
                    if (rowIndex == ROW_CLEAR)
                    {
                        this.RatioMonth_tNedit.Focus();
                    }
                    else if (rowIndex > ROW_CLEAR && rowIndex <= ROW_SALESTARGETMONEY)
                    {
                        this.SalesTarget_uGrid.Rows[ROW_CLEAR].Cells[columnCount - 1].Activate();
                        e.Handled = true;
                        return;
                    }
                    else if (rowIndex > ROW_SALESTARGETMONEY)
                    {
                        this.SalesTarget_uGrid.Rows[rowIndex - 1].Cells[columnCount - 1].Activate();
                        this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode, true, false);
                        e.Handled = true;
                        return;
                    }
                }
            }
            else if (e.KeyCode == Keys.Space)
            {
                if (rowIndex == ROW_CLEAR)
                {
                    // 列データ削除チェック処理
                    ClearTargetColumnData(columnIndex);
                }
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// KeyPress イベント(SalesTarget_uGrid)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: キーが押された時に発生します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.06.19</br>
        /// </remarks>
        private void SalesTarget_uGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.SalesTarget_uGrid.ActiveCell == null)
            {
                return;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (!this.Main_ultraExplorerBar.Groups[4].Expanded)
            if ( !this.Main_ultraExplorerBar.Groups[this.Main_ultraExplorerBar.Groups.Count-1].Expanded )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            {
                return;
            }

            int activeRowIndex = this.SalesTarget_uGrid.ActiveRow.Index;

            if (activeRowIndex == ROW_DATE)
            {
                return;
            }
            
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (activeRowIndex > ROW_SALESTARGETCOUNT)
            if ( activeRowIndex > ROW_SALESTARGETPROFIT )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            {
                return;
            }

            string targetText = this.SalesTarget_uGrid.ActiveCell.Text;

            // 「Backspace」キーを押された時
            if ((byte)e.KeyChar == (byte)'\b')
            {
                return;
            }
            string retText;
            switch (activeRowIndex)
            {
                case ROW_CLEAR:
                    //if ((byte)e.KeyChar != (byte)' ')
                    //{
                    //    e.KeyChar = '\0';
                    //}
                    break;
                // 目標金額
                case ROW_SALESTARGETMONEY:
                case ROW_SALESTARGETPROFIT:
                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    // セルのテキストが選択されている場合
                    if (this.SalesTarget_uGrid.ActiveCell.SelText == targetText)
                    {
                        // 数値のみ入力可
                        if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                        {
                            e.KeyChar = '\0';
                        }
                    }
                    else
                    {
                        RemoveComma(targetText, out retText);
                        // 文字数が１２文字だったら入力不可
                        if (retText.Length == 12)
                        {
                            e.KeyChar = '\0';
                        }
                        else
                        {
                            // 数値以外の時
                            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                            {
                                // 入力値の1文字目は「,」不可
                                if (targetText == "")
                                {
                                    e.KeyChar = '\0';
                                }
                                else
                                {
                                    // 「,」は入力可
                                    if ((byte)e.KeyChar != ',')
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                        }
                    }
                    break;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //case ROW_SALESTARGETCOUNT:
                //    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                //    // セルのテキストが選択されている場合
                //    if (this.SalesTarget_uGrid.ActiveCell.SelText == targetText)
                //    {
                //        // 数値のみ入力可
                //        if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                //        {
                //            e.KeyChar = '\0';
                //        }
                //    }
                //    else
                //    {
                //        RemoveComma(targetText, out retText);
                //        // 文字数が９文字だったら入力不可
                //        if (retText.Length == 9)
                //        {
                //            e.KeyChar = '\0';
                //        }
                //        else
                //        {
                //            // 数値以外の時
                //            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                //            {
                //                // 入力値の1文字目は「,」不可
                //                if (targetText == "")
                //                {
                //                    e.KeyChar = '\0';
                //                }
                //                else
                //                {
                //                    // 「,」は入力可
                //                    if ((byte)e.KeyChar != ',')
                //                    {
                //                        e.KeyChar = '\0';
                //                    }
                //                }
                //            }
                //        }
                //    }
                //    break;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// GroupClick イベント(Main_ultraExplorerBar)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: ExplorerBarのヘッダーがクリックされた時に発生します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.07.12</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupClick(object sender, Infragistics.Win.UltraWinExplorerBar.GroupEventArgs e)
        {
            UltraExplorerBar explorerBar = (UltraExplorerBar)sender;

            // 今現在のクライアントサイズ
            int clientHeight = explorerBar.ClientSize.Height;
            // ヘッダーの高さ合計
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //int headerHeight = 165;
            int headerHeight = 33 * explorerBar.Groups.Count;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            int height = 0;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //for (int index = 0; index < 4; index++)
            for ( int index = 0; index < (explorerBar.Groups.Count) -1; index++ )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            {
                if (explorerBar.Groups[index].Expanded)
                {
                    height += explorerBar.Groups[index].Settings.ContainerHeight;
                }
                else
                {
                    height -= 3;
                }
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            int containerHeight = clientHeight - headerHeight - height;
            if ( containerHeight < 0 ) {
                containerHeight = 0;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // グリッドのグループのサイズを動的に変更します
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //explorerBar.Groups[4].Settings.ContainerHeight = clientHeight - headerHeight - height;
            explorerBar.Groups[explorerBar.Groups.Count - 1].Settings.ContainerHeight = containerHeight;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki



        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ClientSizeChanged イベント(Main_ultraExplorerBar)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: ExplorerBarのクライントサイズが変更された時に発生します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.07.13</br>
        /// </remarks>
        private void Main_ultraExplorerBar_ClientSizeChanged(object sender, EventArgs e)
        {
            
            UltraExplorerBar explorerBar = (UltraExplorerBar)sender;

            // 今現在のクライアントサイズ
            int clientHeight = explorerBar.ClientSize.Height;

            // ヘッダーの高さ合計
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //int headerHeight = 165;
            int headerHeight = 33 * explorerBar.Groups.Count;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            int height = 0;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //for (int index = 0; index < 4; index++)
            for ( int index = 0; index < (explorerBar.Groups.Count) - 1; index++ )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            {
                if (this.Main_ultraExplorerBar.Groups[index].Expanded)
                {
                    height += this.Main_ultraExplorerBar.Groups[index].Settings.ContainerHeight;
                }
                else
                {
                    height -= 3;
                }
            }

            int containerHeight = clientHeight - headerHeight - height;
            if (containerHeight < 0) {
                containerHeight = 0;
            }

            // グリッドのグループのサイズを動的に変更します
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //explorerBar.Groups[4].Settings.ContainerHeight = containerHeight;
            explorerBar.Groups[explorerBar.Groups.Count-1].Settings.ContainerHeight = containerHeight;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }


        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.23 TOKUNAGA ADD START

        /// <summary>
        /// 拠点コード入力欄Leave処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: 拠点コード入力欄をLeaveした時に発生します。</br>
        /// <br>Programmer	: 徳永 俊詞</br>
        /// <br>Date		: 2008.07.03</br>
        /// </remarks>
        private void SectionCode_tNedit_Leave(object sender, EventArgs e)
        {
            string sectionCode = this.SectionCode_tNedit.Text;

            if (!String.IsNullOrEmpty(sectionCode))
            {
                SecInfoSet sectionInfo;
                int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.SectionName_tEdit.DataText = sectionInfo.SectionGuideNm.TrimEnd();

                    // 共通変数に保存
                    this._sectionCode = sectionInfo.SectionCode.TrimEnd();
                    this._sectionName = sectionInfo.SectionGuideNm.TrimEnd();

                }
            }
        }

        /// <summary>
        /// 拠点ガイドボタンクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: 拠点ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: 徳永 俊詞</br>
        /// <br>Date		: 2008.07.03</br>
        /// </remarks>
        private void SectionCodeGuide_ultraButton_Click(object sender, EventArgs e)
        {
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out sectionInfo);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.SectionCode_tNedit.DataText = sectionInfo.SectionCode.TrimEnd();
                this.SectionName_tEdit.DataText = sectionInfo.SectionGuideNm.TrimEnd();

                // 共通変数に保存
                this._sectionCode = sectionInfo.SectionCode.TrimEnd();
                this._sectionName = sectionInfo.SectionGuideNm.TrimEnd();
            }
        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.23 TOKUNAGA ADD END

        # endregion Control Events

    }

	/// <summary>
	/// 目標データ比較クラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 目標データの比較を行います。</br>
	/// <br>Programmer	: NEPCO</br>
	/// <br>Date		: 2007.01.30</br>
	/// </remarks>
	public class SalesTargetCompApplyStaDate : IComparer<SalesTarget>
	{
		#region IComparer<SalesTarget> メンバ

		/// <summary>
		/// 目標データ比較処理
		/// </summary>
        /// <param name="x">比較用目標データ</param>
        /// <param name="y">比較用目標データ</param>
		/// <remarks>
		/// <br>Note		: 目標データの日付の比較を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.30</br>
		/// </remarks>
		public int Compare(SalesTarget x, SalesTarget y)
		{
			if (x.ApplyStaDate.Date == y.ApplyStaDate.Date)
			{
				return (0);
			}
			else if (x.ApplyStaDate.Date > y.ApplyStaDate.Date)
			{
				return (1);
			}
			else
			{
				return (-1);
			}
		}

		#endregion
	}
}