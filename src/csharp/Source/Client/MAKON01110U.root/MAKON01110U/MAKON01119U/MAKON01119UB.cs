using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
//using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 仕入入力用ユーザー設定クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 仕入入力のユーザー設定情報を管理するクラスです。</br>
	/// <br>Programmer : 21024 佐々木 健</br>
	/// <br>Date       : 2008.05.21</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2009.06.17 21024 佐々木 健 MANTIS[0013502] 保存後の画面初期化の初期値を「する」に変更</br>
    /// <br>2009.07.10 21024 佐々木 健 MANTIS[0013757] 仕入日変更時、入荷伝票も変更する区分を追加</br>
    /// <br>2009.11.13 30434 工藤 恵優 MANTIS[0013983] 入力区分の保持機能を追加</br>
    /// <br>2010.01.06 30434 工藤 恵優 MANTIS[0014857] 担当者を保存後も保持する設定を追加</br>
    /// <br>Update Note: 2014/09/01 衛忠明</br>
    /// <br>管理番号   : 11070149-00</br>
    /// <br>           : redmine　#43374 仕入伝票入力(保存後ロゴ表示制御)の追加対応</br>
    /// <br>UpdateNote : 2017/08/11 譚洪  </br>
    /// <br>管理番号   : 11370074-00</br>
    /// <br>             ハンディターミナル在庫仕入登録の対応</br> 
    /// </remarks>
	[Serializable]
	public class StockSlipInputConstruction
	{
		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region ■Private Members
		private int _focusPositionValue = DEFAULT_FocusPosition_VALUE;
		private int _dataInputCountValue = DEFAULT_DataInputCount_VALUE;
		private int _stockGoodsCdValue = DEFAULT_StockGoodsCd_VALUE;
		private int _accPayDivCdValue = DEFAULT_AccPayDivCd_VALUE;
		private int _fontSizeValue = DEFAULT_FontSize_VALUE;
		private int _clearAfterSave = DEFAULT_ClearAfterSave_VALUE;
		private int _saveInfoStore = DEFAULT_SaveInfoStore_VALUE;

        private int _saveAgentStore = DEFAULT_SaveAgentStore_VALUE; // ADD 2010/01/06 MANTIS対応[14857]：担当者を保存後も保持する設定を追加

		private int _functionMode = DEFAULT_FunctionMode_VALUE;
		private int _supplierFormalAfterSave = DEFAULT_SupplierFormalAfterSave_VALUE;
        private int _stockGoodsCdAfterSave = DEFAULT_StockGoodsCdAfterSave_VALUE;   // ADD 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加
		private int _dateClearAfterSave = DEFAULT_DateClearAfterSave_VALUE;
		private int _supplierFormalValue = DEFAULT_SupplierFormal_VALUE;
        private int _focusPositionAfterSaveValue = DEFAULT_FocusPositionAfterSave_VALUE;
        private int _useStockAgent = DEFAULT_UseStockAgent_VALUE;
        private int _reflectArrivalGoodsDay;    // 2009.07.10 Add

		private HeaderFocusConstructionList _headerFocusConstructionList;

		private const int DEFAULT_FocusPosition_VALUE = 1;
		private const int DEFAULT_DataInputCount_VALUE = 21;
		private const int DEFAULT_SupplierFormal_VALUE = 0;
		private const int DEFAULT_StockGoodsCd_VALUE = 0;
		private const int DEFAULT_AccPayDivCd_VALUE = 1;
		private const int DEFAULT_FontSize_VALUE = 11;
        // 2009.06.17 >>>
		//private const int DEFAULT_ClearAfterSave_VALUE = 0;
        private const int DEFAULT_ClearAfterSave_VALUE = 1;
        // 2009.06.17 <<<
        private const int DEFAULT_SaveInfoStore_VALUE = 0;
        private const int DEFAULT_SaveAgentStore_VALUE = 0; // ADD 2010/01/06 MANTIS対応[14857]：担当者を保存後も保持する設定を追加
		private const int DEFAULT_FunctionMode_VALUE = 0;
		private const int DEFAULT_DateClearAfterSave_VALUE = 1;
		private const int DEFAULT_SupplierFormalAfterSave_VALUE = 0;
        private const int DEFAULT_StockGoodsCdAfterSave_VALUE = 0;  // ADD 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加
        private const int DEFAULT_FocusPositionAfterSave_VALUE = 1;
        private const int DEFAULT_UseStockAgent_VALUE = 0;
        // 2009.07.10 Add >>>
        private const int DEFAULT_ReflectArrivalGoodsDay = 0;
        // 2009.07.10 Add <<<
		# endregion

		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region ■Constructors
		/// <summary>
		/// 仕入入力用ユーザー設定クラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : 仕入入力用ユーザー設定クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 21024 佐々木 健</br>
		/// <br>Date       : 2008.05.21</br>
		/// </remarks>
		public StockSlipInputConstruction()
		{
			this._focusPositionValue = DEFAULT_FocusPosition_VALUE;
			this._dataInputCountValue = DEFAULT_DataInputCount_VALUE;
			this._stockGoodsCdValue = DEFAULT_StockGoodsCd_VALUE;
			this._accPayDivCdValue = DEFAULT_AccPayDivCd_VALUE;
			this._fontSizeValue = DEFAULT_FontSize_VALUE;
			this._clearAfterSave = DEFAULT_ClearAfterSave_VALUE;
			this._saveInfoStore = DEFAULT_SaveInfoStore_VALUE;
			this._functionMode = DEFAULT_FunctionMode_VALUE;
			this._supplierFormalAfterSave = DEFAULT_SupplierFormalAfterSave_VALUE;
            this._stockGoodsCdAfterSave = DEFAULT_StockGoodsCd_VALUE;   // ADD 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加
			this._dateClearAfterSave = DEFAULT_DateClearAfterSave_VALUE;
			this._supplierFormalValue = DEFAULT_SupplierFormal_VALUE;
            this._focusPositionAfterSaveValue = DEFAULT_FocusPositionAfterSave_VALUE;
            this._useStockAgent = DEFAULT_UseStockAgent_VALUE;
            this._reflectArrivalGoodsDay = DEFAULT_ReflectArrivalGoodsDay;  // 2009.07.10 Add

			this._headerFocusConstructionList = new HeaderFocusConstructionList();

		}

		/// <summary>
		/// 仕入入力用ユーザー設定クラス
		/// </summary>
		/// <param name="focusPositionValue">初期フォーカス位置</param>
		/// <param name="dataInputCountValue">データ入力行数</param>
		/// <param name="supplierFormalValue">伝票種別</param>
		/// <param name="stockGoodsCdValue">商品区分</param>
		/// <param name="accPayDivCdValue">買掛区分</param>
		/// <param name="fontSizeValue">フォントサイズ</param>
		/// <param name="clearAfterSave">保存後初期化処理</param>
		/// <param name="saveInfoStore">保存情報の保持</param>
		/// <param name="functionMode">ファンクションモード</param>
		/// <param name="headerFocusConstructionList">ヘッダフォーカス設定リスト</param>
		/// <param name="supplierFormalAfterSave">保存後の仕入形式</param>
		/// <param name="dateClearAfterSave">保存後の日付初期化</param>
        /// <param name="focusPositionAfterSave">保存後のフォーカス位置</param>
        /// <param name="useStockAgent">仕入先担当者の使用</param>
        /// <param name="reflectArrivalGoodsDay">仕入日変更時の入荷日への反映</param>
        /// <param name="stockGoodsCdAfterSave">保存後の入力区分</param>
		/// <remarks>
		/// <br>Note       : 仕入入力用ユーザー設定クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 21024 佐々木 健</br>
		/// <br>Date       : 2008.05.21</br>
        /// <br>2009.11.13 30434 工藤 恵優 MANTIS[0013983] 入力区分の保持機能を追加</br>
		/// </remarks>
        // 2009.07.10 >>>
        //public StockSlipInputConstruction(int focusPositionValue, int dataInputCountValue, int supplierFormalValue, int stockGoodsCdValue, int accPayDivCdValue, int fontSizeValue, int clearAfterSave, int saveInfoStore, int functionMode, HeaderFocusConstructionList headerFocusConstructionList, int supplierFormalAfterSave, int dateClearAfterSave, int focusPositionAfterSave, int useStockAgent)
        public StockSlipInputConstruction(int focusPositionValue, int dataInputCountValue, int supplierFormalValue, int stockGoodsCdValue, int accPayDivCdValue, int fontSizeValue, int clearAfterSave, int saveInfoStore, int functionMode, HeaderFocusConstructionList headerFocusConstructionList, int supplierFormalAfterSave, int dateClearAfterSave, int focusPositionAfterSave, int useStockAgent, int reflectArrivalGoodsDay, int stockGoodsCdAfterSave)
        // 2009.07.10 <<<
        {
			this._focusPositionValue = focusPositionValue;
			this._dataInputCountValue = dataInputCountValue;
			this._supplierFormalValue = supplierFormalValue;
			this._stockGoodsCdValue = stockGoodsCdValue;
			this._accPayDivCdValue = accPayDivCdValue;
			this._fontSizeValue = fontSizeValue;
			this._clearAfterSave = clearAfterSave;
			this._saveInfoStore = saveInfoStore;
			this._functionMode = functionMode;
			this._headerFocusConstructionList = HeaderFocusConstructionList;
			this._supplierFormalAfterSave = supplierFormalAfterSave;
			this._dateClearAfterSave = dateClearAfterSave;
            this._focusPositionAfterSaveValue = focusPositionAfterSave;
            this._useStockAgent = useStockAgent;
            this._reflectArrivalGoodsDay = reflectArrivalGoodsDay;  // 2009.07.10 Add
            this._stockGoodsCdAfterSave = stockGoodsCdAfterSave;    // ADD 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加
		}

        // ADD 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加 ---------->>>>>
        // publicクラスのpublicコンストラクタであるため、旧I/Fを残す
        /// <summary>
        /// 仕入入力用ユーザー設定クラス
        /// </summary>
        /// <param name="focusPositionValue">初期フォーカス位置</param>
        /// <param name="dataInputCountValue">データ入力行数</param>
        /// <param name="supplierFormalValue">伝票種別</param>
        /// <param name="stockGoodsCdValue">商品区分</param>
        /// <param name="accPayDivCdValue">買掛区分</param>
        /// <param name="fontSizeValue">フォントサイズ</param>
        /// <param name="clearAfterSave">保存後初期化処理</param>
        /// <param name="saveInfoStore">保存情報の保持</param>
        /// <param name="functionMode">ファンクションモード</param>
        /// <param name="headerFocusConstructionList">ヘッダフォーカス設定リスト</param>
        /// <param name="supplierFormalAfterSave">保存後の仕入形式</param>
        /// <param name="dateClearAfterSave">保存後の日付初期化</param>
        /// <param name="focusPositionAfterSave">保存後のフォーカス位置</param>
        /// <param name="useStockAgent">仕入先担当者の使用</param>
        /// <param name="reflectArrivalGoodsDay">仕入日変更時の入荷日への反映</param>
        public StockSlipInputConstruction(
            int focusPositionValue,
            int dataInputCountValue,
            int supplierFormalValue,
            int stockGoodsCdValue,
            int accPayDivCdValue,
            int fontSizeValue,
            int clearAfterSave,
            int saveInfoStore,
            int functionMode,
            HeaderFocusConstructionList headerFocusConstructionList,
            int supplierFormalAfterSave,
            int dateClearAfterSave,
            int focusPositionAfterSave,
            int useStockAgent,
            int reflectArrivalGoodsDay
        ) : this(
            focusPositionValue,
            dataInputCountValue,
            supplierFormalValue,
            stockGoodsCdValue,
            accPayDivCdValue,
            fontSizeValue,
            clearAfterSave,
            saveInfoStore,
            functionMode,
            headerFocusConstructionList,
            supplierFormalAfterSave,
            dateClearAfterSave,
            focusPositionAfterSave,
            useStockAgent,
            reflectArrivalGoodsDay,
            DEFAULT_StockGoodsCd_VALUE
        ) { }
        // ADD 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加 ----------<<<<<

		# endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region ■Properties
		/// <summary>初期フォーカス位置</summary>
		public int FocusPositionValue
		{
			get { return this._focusPositionValue; }
			set { this._focusPositionValue = value; }
		}

		/// <summary>データ入力行数</summary>
		public int DataInputCountValue
		{
			get { return this._dataInputCountValue; }
			set { this._dataInputCountValue = value; }
		}

		/// <summary>仕入形式</summary>
		public int SupplierFormalValue
		{
			get { return this._supplierFormalValue; }
			set { this._supplierFormalValue = value; }
		}

		/// <summary>商品区分</summary>
		public int StockGoodsCdValue
		{
			get { return this._stockGoodsCdValue; }
			set { this._stockGoodsCdValue = value; }
		}

		/// <summary>買掛区分</summary>
		public int AccPayDivCdValue
		{
			get { return this._accPayDivCdValue; }
			set { this._accPayDivCdValue = value; }
		}

		/// <summary>フォントサイズ</summary>
		public int FontSizeValue
		{
			get { return this._fontSizeValue; }
			set { this._fontSizeValue = value; }
		}

		/// <summary>保存後初期化処理</summary>
		public int ClearAfterSave
		{
			get { return this._clearAfterSave; }
			set { this._clearAfterSave = value; }
		}

		/// <summary>保存情報の記憶</summary>
		public int SaveInfoStoreValue
		{
			get { return this._saveInfoStore; }
			set { this._saveInfoStore = value; }
		}

        // ADD 2010/01/06 MANTIS対応[14857]：担当者を保存後も保持する設定を追加 ---------->>>>>
        /// <summary>保存担当者の記憶</summary>
        public int SaveAgentStoreValue
        {
            get { return this._saveAgentStore; }
            set { this._saveAgentStore = value; }
        }
        // ADD 2010/01/06 MANTIS対応[14857]：担当者を保存後も保持する設定を追加 ----------<<<<<

		/// <summary>ファンクションモード</summary>
		public int FunctionMode
		{
			get { return this._functionMode; }
			set { this._functionMode = value; }
		}

		/// <summary>保存後の仕入形式</summary>
		public int SupplierFormalAfterSave
		{
			get { return this._supplierFormalAfterSave; }
			set { this._supplierFormalAfterSave = value; }
		}

        // ADD 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加 ---------->>>>>
        /// <summary>保存後の入力区分</summary>
        public int StockGoodsCdAfterSave
        {
            get { return this._stockGoodsCdAfterSave; }
            set { this._stockGoodsCdAfterSave = value; }
        }
        // ADD 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加 ----------<<<<<

		/// <summary>保存後の日付初期化</summary>
		public int DateClearAfterSave
		{
			get { return this._dateClearAfterSave; }
			set { this._dateClearAfterSave = value; }
		}

        /// <summary>保存後のフォーカス位置</summary>
        public int FocusPositionAfterSave
        {
            get { return this._focusPositionAfterSaveValue; }
            set { this._focusPositionAfterSaveValue = value; }
        }
        
        /// <summary>仕入先担当者の使用</summary>
        public int UseStockAgent
        {
            get { return this._useStockAgent; }
            set { this._useStockAgent = value; }
        }

		/// <summary>ヘッダフォーカス設定リスト</summary>
		public HeaderFocusConstructionList HeaderFocusConstructionList
		{
			get { return this._headerFocusConstructionList; }
			set { this._headerFocusConstructionList = value; }
		}

        // 2009.07.10 Add >>>
        /// <summary>入荷日へ反映</summary>
        public int ReflectArrivalGoodsDay
        {
            get { return _reflectArrivalGoodsDay; }
            set { _reflectArrivalGoodsDay = value; }
        }
        // 2009.07.10 Add <<<

		# endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		# region ■Public Methods
		/// <summary>
		/// 仕入入力用ユーザー設定クラス複製処理
		/// </summary>
		/// <returns>仕入入力用ユーザー設定クラス</returns>
		public StockSlipInputConstruction Clone()
		{
            return new StockSlipInputConstruction(
                this._focusPositionValue,
                this._dataInputCountValue,
                this._supplierFormalValue,
                this._stockGoodsCdValue,
                this._accPayDivCdValue,
                this._fontSizeValue,
                this._clearAfterSave,
                this._saveInfoStore,
                this._functionMode,
                this._headerFocusConstructionList,
                this._supplierFormalAfterSave,
                this._dateClearAfterSave,
                this._focusPositionAfterSaveValue,
                // 2009.07.10 >>>
                //this._useStockAgent);
                this._useStockAgent,
                this._reflectArrivalGoodsDay,
                this._stockGoodsCdAfterSave // ADD 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加
                );
                // 2009.07.10 <<<
        }
		# endregion
	}

	/// <summary>
	/// 仕入入力用設定アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 仕入入力のユーザー設定情報を管理するクラスです。</br>
	/// <br>Programmer : 21024　佐々木 健</br>
	/// <br>Date       : 2008.05.21</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2009.07.10 21024 佐々木 健 MANTIS[0013757] 仕入日変更時、入荷伝票も変更する区分を追加</br>
    /// <br>2009.11.13 30434 工藤 恵優 MANTIS[0013983] 入力区分の保持機能を追加</br>
    /// <br>2010.01.06 30434 工藤 恵優 MANTIS[0014857] 担当者を保存後も保持する設定を追加</br>
    /// <br>UpdateNote  : 2017/08/11 譚洪  </br>
    /// <br>管理番号    : 11370074-00</br>
    /// <br>              ハンディターミナル在庫仕入登録の対応</br> 
    /// </remarks>
	public class StockSlipInputConstructionAcs
	{
		// ===================================================================================== //
		// 外部に提供する定数群
		// ===================================================================================== //
		# region ■Public Const
		/// <summary>初期フォーカス位置（拠点）</summary>
		public const int ForcusPosition_SectionCode = 0;
        /// <summary>初期フォーカス位置（担当者）</summary>
        public const int ForcusPosition_StockAgentCode = 1;
        /// <summary>初期フォーカス位置（仕入先）</summary>
		public const int ForcusPosition_SupplierCode = 2;
        /// <summary>初期フォーカス位置（仕入SEQ番号）</summary>
        public const int ForcusPosition_SupplierSlipNo = 3;
        /// <summary>初期フォーカス位置（伝票種別）</summary>
		public const int ForcusPosition_SupplierFormal = 4;
        /// <summary>初期フォーカス位置（伝票番号）</summary>
        public const int ForcusPosition_PartySaleSlipNum = 5;

		/// <summary>保存後初期化処理（しない）</summary>
		public const int ClearAfterSave_OFF = 0;
		/// <summary>保存後初期化処理（する）</summary>
		public const int ClearAfterSave_ON = 1;

		/// <summary>保存後の伝票種別（元に戻す）</summary>
		public const int SupplierFormalAfterSave_Init = 0;
		/// <summary>保存後の伝票種別（入力値のまま）</summary>
		public const int SupplierFormalAfterSave_Keep = 1;

        // ADD 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加 ---------->>>>>
        /// <summary>保存後の入力区分（元に戻す）</summary>
        public const int StockGoodsCdAfterSave_Init = 0;
        /// <summary>保存後の入力区分（入力値のまま）</summary>
        public const int StockGoodsCdAfterSave_Keep = 1;
        // ADD 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加 ----------<<<<<

		/// <summary>保存後の日付初期化（仕入在庫全体設定参照）</summary>
		public const int DateClearAfterSave_Default = 0;
		/// <summary>保存後の日付初期化（システム日付に戻す）</summary>
		public const int DateClearAfterSave_ON = 1;
		/// <summary>保存後の日付初期化（入力日付のまま）</summary>
		public const int DateClearAfterSave_OFF = 2;

        /// <summary>保存後のフォーカス位置（初期値に戻す）</summary>
        public const int FocusPositionAfterSave_Detault = 0;
        /// <summary>保存後のフォーカス位置（伝票番号）</summary>
        public const int FocusPositionAfterSave_PartySaleSlipNum = 1;

        /// <summary>仕入先担当者の使用（しない）</summary>
        public const int UseStockAgent_OFF = 0;
        /// <summary>仕入先担当者の使用（する）</summary>
        public const int UseStockAgent_ON = 1;

		/// <summary>保存時情報の記憶（しない）</summary>
		public const int SaveInfoStore_OFF = 0;
		/// <summary>保存時情報の記憶（する）</summary>
		public const int SaveInfoStore_ON = 1;

        // ADD 2010/01/06 MANTIS対応[14857]：担当者を保存後も保持する設定を追加 ---------->>>>>
        /// <summary>前回保存時の担当者の記憶（しない）</summary>
        public const int SaveAgentStore_OFF = 0;
        /// <summary>前回保存時の担当者の記憶（する）</summary>
        public const int SaveAgentStore_ON = 1;
        // ADD 2010/01/06 MANTIS対応[14857]：担当者を保存後も保持する設定を追加 ----------<<<<<

        // 2009.07.10 >>>
        /// <summary>仕入日変更時に入荷日へ反映（無条件）</summary>
        public const int ReflectArrivalGoodsDay_ON = 0;
        /// <summary>仕入日変更時に入荷日へ反映（計上を除く）</summary>
        public const int ReflectArrivalGoodsDay_ExcludeAppropriate = 1;
        /// <summary>仕入日変更時に入荷日へ反映（しない）</summary>
        public const int ReflectArrivalGoodsDay_OFF = 2;
        // 2009.07.10 <<<

		# endregion

        // ------ ADD 2017/08/11 譚洪 ハンディターミナル二次開発 --------- >>>>
        #region ▼定数（ハンディターミナル用）
        /// <summary>ハンディターミナルコンストラクタのモード</summary>
        private const string ConstructorsModeHandy = "Handy";
        #endregion
        // ------ ADD 2017/08/11 譚洪 ハンディターミナル二次開発 --------- <<<<

        // ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region ■Private Members

		private StockSlipInputConstruction _stockSlipInputConstruction;
		private static StockSlipInputConstructionAcs _stockSlipInputConstructionAcs;
		private const string XML_FILE_NAME = "MAKON01112A_Construction.XML";
		private Dictionary<string, Control> _headerItemsDictionary;

		# endregion

		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region ■Constructors
		/// <summary>
		/// 仕入入力用ユーザー設定クラスアクセスクラス（Singletonデザインパターンを採用している為、privateとする）
		/// </summary>
		private StockSlipInputConstructionAcs()
		{
			_stockSlipInputConstruction = new StockSlipInputConstruction();
			_headerItemsDictionary = new Dictionary<string, Control>();
			this.Deserialize();
		}

		/// <summary>
		/// 仕入入力用ユーザー設定アクセスクラス インスタンス取得処理
		/// </summary>
		/// <returns>仕入入力用ユーザー設定アクセスクラス インスタンス</returns>
		public static StockSlipInputConstructionAcs GetInstance()
		{
			if (_stockSlipInputConstructionAcs == null)
			{
				_stockSlipInputConstructionAcs = new StockSlipInputConstructionAcs();
			}

			return _stockSlipInputConstructionAcs;
		}
		# endregion

		// ===================================================================================== //
		// デリゲート
		// ===================================================================================== //
		# region ■Delegate
		/// <summary>列情報リスト取得取得イベント</summary>
		public delegate List<ColDisplayInfo> GetColDisplayInfoEventHandler();
		/// <summary>列情報リストセットイベント</summary>
		public delegate void SetColDisplayInfoEventHandler( List<ColDisplayInfo> colDisplayInfoList );
		# endregion

		// ===================================================================================== //
		// イベント
		// ===================================================================================== //
		# region■ Event
		/// <summary>データ変更後発生イベント</summary>
		public event EventHandler DataChanged;
		/// <summary>列初期情報取得イベント</summary>
		public event GetColDisplayInfoEventHandler GetColDisplayInfoInitList;
		/// <summary>列最新情報取得イベント</summary>
		public event GetColDisplayInfoEventHandler GetColDisplayInfoList;
		/// <summary>列最新情報設定イベント</summary>
		public event SetColDisplayInfoEventHandler SetColDisplayInfoList;

		# endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region ■Properties
		/// <summary>
		/// 仕入入力用ユーザー設定クラス
		/// </summary>
		public StockSlipInputConstruction StockInputConstruction
		{
			get
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				return _stockSlipInputConstruction.Clone();
			}
		}

		/// <summary>初期フォーカス位置</summary>
		public int FocusPositionValue
		{
			get
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				return _stockSlipInputConstruction.FocusPositionValue;
			}
			set
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				_stockSlipInputConstruction.FocusPositionValue = value;
			}
		}

		/// <summary>データ入力行数</summary>
		public int DataInputCountValue
		{
			get
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				return _stockSlipInputConstruction.DataInputCountValue;
			}
			set
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				_stockSlipInputConstruction.DataInputCountValue = value;
			}
		}

		/// <summary>伝票種別</summary>
		public int SupplierFormalValue
		{
			get
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				return _stockSlipInputConstruction.SupplierFormalValue;
			}
			set
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				_stockSlipInputConstruction.SupplierFormalValue = value;
			}
		}

		/// <summary>商品区分</summary>
		public int StockGoodsCdValue
		{
			get
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				return _stockSlipInputConstruction.StockGoodsCdValue;
			}
			set
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				_stockSlipInputConstruction.StockGoodsCdValue = value;
			}
		}

		/// <summary>買掛区分</summary>
		public int AccPayDivCdValue
		{
			get
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				return _stockSlipInputConstruction.AccPayDivCdValue;
			}
			set
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				_stockSlipInputConstruction.AccPayDivCdValue = value;
			}
		}

		/// <summary>フォントサイズ</summary>
		public int FontSizeValue
		{
			get
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				return _stockSlipInputConstruction.FontSizeValue;
			}
			set
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				_stockSlipInputConstruction.FontSizeValue = value;
			}
		}

		/// <summary>保存後初期化処理</summary>
		public int ClearAfterSaveValue
		{
			get
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				return _stockSlipInputConstruction.ClearAfterSave;
			}
			set
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				_stockSlipInputConstruction.ClearAfterSave = value;
			}
		}

		/// <summary>保存時情報記憶</summary>
		public int SaveInfoStoreValue
		{
			get
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				return _stockSlipInputConstruction.SaveInfoStoreValue;
			}
			set
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				_stockSlipInputConstruction.SaveInfoStoreValue = value;
			}
		}

        // ADD 2010/01/06 MANTIS対応[14857]：担当者を保存後も保持する設定を追加 ---------->>>>>
        /// <summary>保存時担当者記憶</summary>
        public int SaveAgentStoreValue
        {
            get
            {
                if (_stockSlipInputConstruction == null)
                {
                    _stockSlipInputConstruction = new StockSlipInputConstruction();
                }
                return _stockSlipInputConstruction.SaveAgentStoreValue;
            }
            set
            {
                if (_stockSlipInputConstruction == null)
                {
                    _stockSlipInputConstruction = new StockSlipInputConstruction();
                }
                _stockSlipInputConstruction.SaveAgentStoreValue = value;
            }
        }
        // ADD 2010/01/06 MANTIS対応[14857]：担当者を保存後も保持する設定を追加 ----------<<<<<

		/// <summary>ファンクションモード</summary>
		public int FunctionModeValue
		{
			get
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				return _stockSlipInputConstruction.FunctionMode;
			}
			set
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				_stockSlipInputConstruction.FunctionMode = value;
			}
		}

		/// <summary>保存後の仕入形式</summary>
		public int SupplierFormalAfterSaveValue
		{
			get
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				return _stockSlipInputConstruction.SupplierFormalAfterSave;

			}
			set
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				_stockSlipInputConstruction.SupplierFormalAfterSave = value;
			}
		}

        // ADD 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加 ---------->>>>>
        /// <summary>保存後の入力区分</summary>
        public int StockGoodsCdAfterSaveValue
        {
            get
            {
                if (_stockSlipInputConstruction == null)
                {
                    _stockSlipInputConstruction = new StockSlipInputConstruction();
                }
                return _stockSlipInputConstruction.StockGoodsCdAfterSave;

            }
            set
            {
                if (_stockSlipInputConstruction == null)
                {
                    _stockSlipInputConstruction = new StockSlipInputConstruction();
                }
                _stockSlipInputConstruction.StockGoodsCdAfterSave = value;
            }
        }
        // ADD 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加 ----------<<<<<

		/// <summary>保存後の日付初期化</summary>
		public int DateClearAfterSaveValue
		{
			get
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				return _stockSlipInputConstruction.DateClearAfterSave;

			}
			set
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				_stockSlipInputConstruction.DateClearAfterSave = value;
			}
		}

        /// <summary>保存後のフォーカス位置</summary>
        public int FocusPositionAfterSaveValue
        {
            get
            {
                if (_stockSlipInputConstruction == null)
                {
                    _stockSlipInputConstruction = new StockSlipInputConstruction();
                }
                return _stockSlipInputConstruction.FocusPositionAfterSave;
            }
            set
            {
                if (_stockSlipInputConstruction == null)
                {
                    _stockSlipInputConstruction = new StockSlipInputConstruction();
                }
                _stockSlipInputConstruction.FocusPositionAfterSave = value;
            }
        }

        /// <summary>仕入先担当者の使用</summary>
        public int UseStockAgentValue
        {
            get
            {
                if (_stockSlipInputConstruction == null)
                {
                    _stockSlipInputConstruction = new StockSlipInputConstruction();
                }
                return _stockSlipInputConstruction.UseStockAgent;
            }

            set
            {
                if (_stockSlipInputConstruction == null)
                {
                    _stockSlipInputConstruction = new StockSlipInputConstruction();
                }
                _stockSlipInputConstruction.UseStockAgent = value;
            }
        }

        // 2009.07.10 Add >>>
        /// <summary>仕入日変更時に入荷日へ反映</summary>
        public int ReflectArrivalGoodsDayValue
        {
            get
            {
                if (_stockSlipInputConstruction == null)
                {
                    _stockSlipInputConstruction = new StockSlipInputConstruction();
                }
                return _stockSlipInputConstruction.ReflectArrivalGoodsDay;
            }

            set
            {
                if (_stockSlipInputConstruction == null)
                {
                    _stockSlipInputConstruction = new StockSlipInputConstruction();
                }
                _stockSlipInputConstruction.ReflectArrivalGoodsDay = value;
            }
        }
        // 2009.07.10 Add <<<

		/// <summary>ヘッダフォーカス設定リスト</summary>
		public HeaderFocusConstructionList HeaderFocusConstructionListValue
		{
			get
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}

                if (_stockSlipInputConstruction.HeaderFocusConstructionList.headerFocusConstruction.Count == 0)
                {
                    _stockSlipInputConstruction.HeaderFocusConstructionList.headerFocusConstruction = this.MakeHeaderFocusConstructionListFromHeaderItemsDictionary(this._headerItemsDictionary);
                }

				return _stockSlipInputConstruction.HeaderFocusConstructionList;
			}
			set
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				_stockSlipInputConstruction.HeaderFocusConstructionList = value;
			}
		}

		/// <summary>明細列情報初期情報リスト</summary>
		public List<ColDisplayInfo> ColDisplayInfoInitList
		{
			get 
			{
				if (this.GetColDisplayInfoInitList != null)
				{
					return GetColDisplayInfoInitList();
				}
				else
				{
					return null; 
				}
				
			}
		}

		/// <summary>明細列情報リスト</summary>
		public List<ColDisplayInfo> ColDisplayInfoList
		{
			get 
			{
				if (this.GetColDisplayInfoList != null)
				{
					return this.GetColDisplayInfoList();
				}
				else
				{
					return null;
				}
			}
			set 
			{
				if (this.SetColDisplayInfoList != null)
				{
					this.SetColDisplayInfoList(value);
				}
			}
		}

		/// <summary>ヘッダ項目Dictionary</summary>
		public Dictionary<string, Control> HeaderItemsDictionary
		{
			get { return this._headerItemsDictionary; }
			set { this._headerItemsDictionary = value; }
		}

		# endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		# region ■Public Methods

		/// <summary>
		/// 仕入入力用ユーザー設定クラスシリアライズ処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 仕入入力用ユーザー設定クラスのシリアライズを行います。</br>
		/// <br>Programmer : 21024　佐々木 健</br>
		/// <br>Date       : 2008.05.21</br>
		/// </remarks>
		public void Serialize()
		{
			UserSettingController.SerializeUserSetting(_stockSlipInputConstruction, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));

			if (DataChanged != null)
			{
				// データ変更後発生イベント実行
				DataChanged(this, new EventArgs());
			}
		}

		/// <summary>
		/// 仕入入力用ユーザー設定クラスデシリアライズ処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 仕入入力用ユーザー設定クラスをデシリアライズします。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.07.19</br>
		/// </remarks>
		public void Deserialize()
		{
			if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
			{
                try
                {
                    _stockSlipInputConstruction = UserSettingController.DeserializeUserSetting<StockSlipInputConstruction>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
                }
                catch (System.InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
                }
            }
		}

		/// <summary>
		/// 仕入入力用ユーザー設定クラス設定ファイル存在チェック
		/// </summary>
		/// <returns>True:ユーザー設定ファイル無し</returns>
		public bool IsUserSettingExists()
		{
			bool ret = false;
			if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
			{
				ret = true;
			}
			return ret;
		}
		# endregion

        //
        #region ■Internal & Private Methods

        /// <summary>
        /// HeaderFocusConstructionリスト生成
        /// </summary>
        /// <param name="headerItemsDictionary">ヘッダーアイテムディクショナリ</param>
        /// <returns>HeaderFocusConstructionリスト</returns>
        internal List<HeaderFocusConstruction> MakeHeaderFocusConstructionListFromHeaderItemsDictionary( Dictionary<string, Control> headerItemsDictionary )
        {
            List<HeaderFocusConstruction> retHeaderFocusConstructionList = new List<HeaderFocusConstruction>();

            if (headerItemsDictionary != null)
            {
                int index = 0;
                SortedDictionary<int, string> sortedDictionary = new SortedDictionary<int, string>();
                foreach (string key in headerItemsDictionary.Keys)
                {
                    Control control = headerItemsDictionary[key];
                    sortedDictionary.Add(index, key);
                    index++;
                }

                foreach (int keyIndex in sortedDictionary.Keys)
                {
                    string key = sortedDictionary[keyIndex];
                    HeaderFocusConstruction headerFocusConstruction = new HeaderFocusConstruction();
                    Control control = headerItemsDictionary[key];
                    headerFocusConstruction.Key = control.Name;
                    headerFocusConstruction.Caption = key;
                    headerFocusConstruction.EnterStop = true;
                    retHeaderFocusConstructionList.Add(headerFocusConstruction);
                }
            }
            return retHeaderFocusConstructionList;
        }
        #endregion

        // ------ ADD 2017/08/11 譚洪 ハンディターミナル二次開発 --------- >>>>
        #region ▼ハンディターミナル在庫仕入登録の対応
        // ===================================================================================== //
        // コンストラクタ（ハンディターミナル用）
        // ===================================================================================== //
        # region ■Constracter
        /// <summary>
        /// コンストラクタ（ハンディターミナル用）
        /// </summary>
        /// <param name="mode">入力機能モード</param>
        /// <remarks>
        /// <br>Note       : クラスの新しいインスタンスを初期化します。（ハンディターミナル用）</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public StockSlipInputConstructionAcs(string mode)
        {
            // 入力機能モードはハンディターミナル場合
            if (ConstructorsModeHandy.Equals(mode))
            {
                _stockSlipInputConstruction = new StockSlipInputConstruction();
                _headerItemsDictionary = new Dictionary<string, Control>();
                this.Deserialize();
            }
        }
        #endregion

        #endregion
        // ------ ADD 2017/08/11 譚洪 ハンディターミナル二次開発 --------- <<<<
    }

    // --- ADD  衛忠明　For redmine #43374 仕入伝票入力(保存後ロゴ表示制御) ------>>>>>
    /// <summary>
    /// 仕入入力用ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入入力のユーザー設定情報を管理するクラスです。</br>
    /// <br>Programmer : 衛忠明</br>
    /// <br>Date       : 2014/09/01</br>
    /// </remarks>
    public class StockSlipInputConstructionLog
    {
        // プライベート変数
        # region ■Private Members
        private int _logoDisp = DEFAULT_LogoDisp_VALUE;
        private int _logoDispTime = DEFAULT_LogoDispTime_VALUE;
        private const int DEFAULT_LogoDisp_VALUE = 0;  //保存後のロゴ表示
        private const int DEFAULT_LogoDispTime_VALUE = 2;　　//保存後のロゴ表示時間(デフォルト値)
        # endregion

        // コンストラクタ
        # region ■Constructors
        /// <summary>
        /// 新しいインスタンスの初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入入力用ユーザー設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 衛忠明</br>
        /// <br>Date       : 2014/09/01</br>
        /// </remarks>
        public StockSlipInputConstructionLog()
        {
            this._logoDisp = DEFAULT_LogoDisp_VALUE;
            this._logoDispTime = DEFAULT_LogoDispTime_VALUE;
        }

        /// <summary>
        /// 新しいインスタンスの初期化処理２
        /// </summary>      
        /// <remarks>
        /// <br>Note       : 仕入入力用ユーザー設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 衛忠明</br>
        /// <br>Date       : 2014/09/01</br>
        /// </remarks>
        public StockSlipInputConstructionLog(int logoDisp, int logoDispTime)
        {
            this._logoDisp = logoDisp;
            this._logoDispTime = logoDispTime;
        }
        
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region ■Properties
        /// <summary>保存後のロゴ表示</summary>
        public int LogoDisp
        {
            get { return _logoDisp; }
            set { _logoDisp = value; }
        }
        /// <summary>保存後のロゴ表示時間</summary>
        public int LogoDispTime
        {
            get { return _logoDispTime; }
            set { _logoDispTime = value; }
        }
        # endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        # region ■Public Methods
        /// <summary>
        /// 仕入入力用ユーザー設定クラス複製処理
        /// </summary>
        /// <returns>仕入入力用ユーザー設定クラス</returns>
        public StockSlipInputConstructionLog Clone()
        {
            return new StockSlipInputConstructionLog(
                this._logoDisp,
                this._logoDispTime              
                );
        }
        # endregion
    }
    /// <summary>
    /// 仕入入力用設定アクセスクラス
    /// </summary>
    public class StockSlipInputConstructionAcsLog
    {
        public const int LogoDisp_ON = 0;
        public const int LogoDisp_OFF = 1;

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■Private Members
        private StockSlipInputConstructionLog _stockSlipInputConstructionLog;
        private static StockSlipInputConstructionAcsLog _stockSlipInputConstructionAcsLog;
        private const string XML_FILE_NAME_LOGO = "SFMIT01210_Settings.xml";
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructors
        /// <summary>
        /// 仕入入力用ユーザー設定クラスアクセスクラス（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private StockSlipInputConstructionAcsLog()
        {
            _stockSlipInputConstructionLog = new StockSlipInputConstructionLog();
            this.Deserialize();
        }
        /// <summary>
        /// 仕入入力用ユーザー設定クラスデシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入入力用ユーザー設定クラスをデシリアライズします。</br>
        /// <br>Programmer : 衛忠明</br>
        /// <br>Date       : 2014/09/01</br>
        /// </remarks>
        private void Deserialize()
        {            
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME_LOGO)))
            {
                try
                {
                    _stockSlipInputConstructionLog = UserSettingController.DeserializeUserSetting<StockSlipInputConstructionLog>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME_LOGO));
                }
                catch (System.InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME_LOGO));
                }
            }
        }

        /// <summary>
        /// 仕入入力用ユーザー設定アクセスクラス インスタンス取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入入力用ユーザー設定アクセスクラス インスタンス取得処理します。</br>
        /// <br>Programmer : 衛忠明</br>
        /// <br>Date       : 2014/09/01</br>
        /// </remarks>
        public static StockSlipInputConstructionAcsLog GetInstance()
        {
            if (_stockSlipInputConstructionAcsLog == null)
            {
                _stockSlipInputConstructionAcsLog = new StockSlipInputConstructionAcsLog();
            }

            return _stockSlipInputConstructionAcsLog;
        }
        # endregion

        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        # region■ Event
        /// <summary>データ変更後発生イベント</summary>
        public event EventHandler DataChanged;
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region ■Properties
        /// <summary>
        /// 仕入入力用ユーザー設定クラス
        /// </summary>
        public StockSlipInputConstructionLog StockInputConstructionLog
        {
            get
            {
                if (_stockSlipInputConstructionLog == null)
                {
                    _stockSlipInputConstructionLog = new StockSlipInputConstructionLog();
                }
                return _stockSlipInputConstructionLog.Clone();
            }
        }

        /// <summary>保存後のロゴ表示</summary>
        public int LogoDispValue
        {
            get
            {
                if (_stockSlipInputConstructionLog == null)
                {
                    _stockSlipInputConstructionLog = new StockSlipInputConstructionLog();
                }
                return _stockSlipInputConstructionLog.LogoDisp;
            }

            set
            {
                if (_stockSlipInputConstructionLog == null)
                {
                    _stockSlipInputConstructionLog = new StockSlipInputConstructionLog();
                }
                _stockSlipInputConstructionLog.LogoDisp = value;
            }
        }
        /// <summary>保存後のロゴ表示時間</summary>
        public int LogoDispTimeValue
        {
            get
            {
                if (_stockSlipInputConstructionLog == null)
                {
                    _stockSlipInputConstructionLog = new StockSlipInputConstructionLog();
                }
                return _stockSlipInputConstructionLog.LogoDispTime;
            }

            set
            {
                if (_stockSlipInputConstructionLog == null)
                {
                    _stockSlipInputConstructionLog = new StockSlipInputConstructionLog();
                }
                _stockSlipInputConstructionLog.LogoDispTime = value;
            }
        }
        # endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        /// <summary>
        /// 仕入入力用ユーザー設定クラスシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入入力用ユーザー設定クラスのシリアライズを行います。</br>
        /// <br>Programmer : 衛忠明</br>
        /// <br>Date       : 2014/09/01</br>
        /// </remarks>
        public void Serialize()
        {
            UserSettingController.SerializeUserSetting(_stockSlipInputConstructionLog, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME_LOGO));

            if (DataChanged != null)
            {
                // データ変更後発生イベント実行
                DataChanged(this, new EventArgs());
            }
        }
    }
    // --- ADD  衛忠明　For redmine #43374 仕入伝票入力(保存後ロゴ表示制御) ------<<<<<
    
    
}
