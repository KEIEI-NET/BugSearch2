using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 商品目標入力画面
	/// </summary>
	/// <remarks>
	/// <br>Note			 : 商品目標入力を行う画面です。</br>
	/// <br>Programmer		 : NEPCO</br>
	/// <br>Date			 : 2007.04.23</br>
	/// <br>Update Note		 : 2007.11.21 上野 弘貴</br>
	/// <br>                   流通.DC用に変更（項目追加・削除）</br>
	/// <br>Update Note		 : 2008.03.03 30167 上野　弘貴</br>
	/// <br>				   項目ゼロ埋め対応（画面デザインにコンポーネント追加、
	///						   Tedit、TNeditの設定変更）</br>
	/// <br>Update Note      : 2008.03.05 30167 上野　弘貴</br>
	/// <br>			       ・商品検索画面にメーカーコードを引き継ぐよう修正
	///					       ・商品曖昧検索でメーカーコードに対応したデータを検索するよう修正
	///					       ・画面コンポーネントの配置変更
	///					       ・メーカーコード設定時の商品コード検索修正
	///					 	   ・メーカーコードと商品コードの整合性チェック追加
	///					 	   ・ショートカットキーエラーチェック対応追加
	/// <br>Update Note		 : 2008.03.07 30167 上野　弘貴</br>
	///						   項目クリア後エンターキーで次項目へ移動するよう修正</br>
	/// </remarks>
	public partial class MAMOK09130UA : Form
	{
		# region Private Constants

		// PG名称
		private const string ctPGNM = "商品目標入力";

		//----- ueno del---------- start 2007.11.21
		// 比率
        //private const string RATIO_DEFAULT = "1.00";
		//----- ueno del---------- end   2007.11.21

        // 書式
        private const string FORMAT_NUM = "###,##0";
        private const string FORMAT_NUM_DECIMAL = "N1";

		// 機種コードなし
		private const string CELLPHONEMODELCODE_NONE = "none";

		# endregion Private Constants

		# region Private Members

		// 企業コード
		private string _enterpriseCode;
		// 拠点名
		private string _sectionName;

		//----- ueno add---------- start 2008.03.05
		// 拠点コード
		private string _sectionCode;
		//----- ueno add---------- end 2008.03.05

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA ADD START
        // BLグループガイドアクセスクラス
        private BLGroupUAcs _blGroupUAcs = null;

        // BLコードガイドアクセスクラス
        private BLGoodsCdAcs _blGoodsCdAcs = null;

        // ユーザーガイドアクセスクラスガイド定数
        private int SALES_TYPE_GUIDE = 71;      // 販売区分
        private int ITEM_TYPE_GUIDE = 41;       // 商品区分(旧：自社区分)

        // ユーザーガイドアクセスクラス
        private UserGuideAcs _userGuideAcs = null;

        // ユーザーガイドデータ格納用（販売区分）
        private SortedList _salesTypeCodeSList = null;

        // ユーザーガイドデータ格納用（商品区分）
        private SortedList _itemTypeCodeSList = null;

        // CONST
        private const int BL_GROUP_SELECTED = 42;       // 拠点+BLグループ
        private const int BL_CODE_SELECTED = 43;        // 拠点+BLコード
        private const int BL_SALES_TYPE_SELECTED = 44;  // 拠点+販売区分
        private const int BL_ITEM_TYPE_SELECTED = 45;   // 拠点+商品区分

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA ADD END

		// 目標データ
		private SalesTarget _salesTarget;
		// 目標マスタアクセスクラス
		private SalesTargetAcs _salesTargetAcs;
		// 目標データリスト
		private List<SalesTarget> _salesTargetList;

		//----- ueno add ---------- start 2008.03.05
		// メーカーアクセスクラス
		private MakerAcs _makerAcs = null;
		//----- ueno add ---------- end 2008.03.05

//----- ueno add---------- start 2007.11.21
		// 商品アクセスクラス
		private GoodsAcs _goodsAcs;
		
		// メーカーコード（ワーク）
		private int _goodsMakerCdWork = 0;
		
		// 商品コード（ワーク）
		private string _goodsCodeWork = "";

		// 目標対比区分ワーク
		private int _targetContrastCd_tComboEditorValue = -1;
		
//----- ueno add---------- start 2007.11.21

		//----- ueno add---------- start 2008.03.05
		// 文字列結合用
		private StringBuilder _stringBuilder = null;
		//----- ueno add---------- end 2008.03.05

		//----- ueno del---------- start 2007.11.21
		//// 休業日設定マスタ
		//private Dictionary<SectionAndDate, HolidaySetting> _holidaySettingDic;

		//// 着地計算比率リスト
		//private List<LdgCalcRatioMng> _ldgCalcRatioMngList;
		//----- ueno del---------- end   2007.11.21

		// 目標設定区分
		private int _targetSetCd;

		// 期間（開始）
		private DateTime _targetStaDate;
		// 期間（終了）
		private DateTime _targetEndDate;

		// モード(新規・編集)
		private int _mode;

		private bool _searchFlag;

		/// <summary>画面デザイン変更クラス</summary>
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		# endregion Private Members

		# region Constructor

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MAMOK09130UA()
		{
			InitializeComponent();

			//　企業コード取得
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA DEL START
            //// 拠点名称取得
            //SecInfoSet secInfoSet;
            //SecInfoAcs secInfoAcs = new SecInfoAcs();
            //secInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);
            //this._sectionName = secInfoSet.SectionGuideNm.TrimEnd();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA DEL END

			this._salesTargetAcs = new SalesTargetAcs();

			//----- ueno add ---------- start 2008.03.05
			// メーカーアクセスクラス
			this._makerAcs = new MakerAcs();
			//----- ueno add ---------- end 2008.03.05

//----- ueno add---------- start 2007.11.21
			// 商品アクセスクラス
			this._goodsAcs = new GoodsAcs();
//----- ueno add---------- start 2007.11.21

			// アイコン画像の設定
			// 商品コードガイドボタン
			this.GoodsCodeGuide_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

//----- ueno add---------- start 2007.11.21
			// メーカーコードガイドボタン
			this.GoodsMakerCdGuide_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
//----- ueno add---------- end   2007.11.21

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
            this._blGroupUAcs = new BLGroupUAcs();

            // BLコードガイドアクセスクラス
            this._blGoodsCdAcs = new BLGoodsCdAcs();

            // ユーザーガイドアクセスクラス
            this._userGuideAcs = new UserGuideAcs();

            // ユーザーガイドデータ格納用（業種コード）
            this._salesTypeCodeSList = new SortedList();

            // ユーザーガイドデータ格納用（販売エリアコード）
            this._itemTypeCodeSList = new SortedList();

            // BLグループガイドボタン
            this.BLGroupGuide_ultraButton.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            // BLコードガイドボタン
            this.BLCodeGuide_ultraButton.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            // 販売区分ガイドボタン
            this.SalesTypeGuide_ultraButton.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            // 商品区分ガイドボタン
            this.ItemTypeGuide_ultraButton.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END

			// 終了ボタン
			this.Close_Button.Appearance.Image
				= IconResourceManagement.ImageList24.Images[(int)Size24_Index.CLOSE];
			// 保存ボタン
			this.Save_Button.Appearance.Image
				= IconResourceManagement.ImageList24.Images[(int)Size24_Index.SAVE];

			//----- ueno add---------- start 2008.03.05
			// 文字列結合用
			this._stringBuilder = new StringBuilder();
			//----- ueno add---------- end 2008.03.05
		}

		# endregion Constructor

		#region enum

		//----- ueno upd ---------- start 2008.03.05	
		/// <summary>
		/// 入力エラーチェックステータス
		/// </summary>
		private enum InputChkStatus
		{
			// 未入力
			NotInput = -1,
			// 存在しない
			NotExist = -2,
			// 入力ミス
			InputErr = -3,
			// 正常
			Normal = 0,
			// キャンセル
			Cancel = 1
		}
		///// <summary>
		///// 入力エラーチェックフラグ
		///// </summary>
		//private enum InputChk
		//{
		//    // 存在しない
		//    None = 0,
		//    // 更新
		//    Update = 1,
		//    // 元に戻す
		//    Back = 2
		//}
		//----- ueno upd ---------- end 2008.03.05	

		//----- ueno add---------- start 2008.03.05
		/// <summary>
		/// 画面データ設定ステータス
		/// </summary>
		private enum DispSetStatus
		{
			// クリア
			Clear = 0,
			// 更新
			Update = 1,
			// 元に戻す
			Back = 2
		}
		//----- ueno add---------- end 2008.03.05
		
		#endregion enum

		# region Public Propaties

		/// public propaty name  :	SalesTarget
		/// <summary>目標データプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 目標データプロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public SalesTarget SalesTarget
		{
			get
			{
				return this._salesTarget;
			}
			set
			{
				this._salesTarget = value;
			}
		}

		/// public propaty name  :	Mode
		/// <summary>モードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 モードプロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public int Mode
		{
			get
			{
				return this._mode;
			}
			set
			{
				this._mode = value;
			}
		}

		/// public propaty name  :	SearchFlag
		/// <summary>検索フラグプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 検索フラグプロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public bool SearchFlag
		{
			get
			{
				return this._searchFlag;
			}
			set
			{
				this._searchFlag = value;
			}
		}

		# endregion Public Propaties

		# region Private Methods

		//----- ueno del---------- start 2007.11.21
		#region del
		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// マスタ読込処理
		///// </summary>
		///// <remarks>
		///// <br>Note		: 各マスタを読み込みます。</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.04.24</br>
		///// </remarks>
		//private bool LoadMasterTable()
		//{
		//    int status;

		//    // 休業日設定マスタ
		//    status = LoadHolidaySettingTable(this._salesTarget.SectionCode);
		//    if (status != 0)
		//    {
		//        return (false);
		//    }

		//    // 着地計算比率管理マスタ
		//    status = LoadLdgCalcRatioMngTable(this._salesTarget.SectionCode);

		//    if (status != 0)
		//    {
		//        return (false);
		//    }

		//    return (true);
		//}

		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// 休業日設定マスタ読み込み処理
		///// </summary>
		///// <param name="sectionCode">拠点コード</param>
		///// <remarks>
		///// <br>Note		: 休業日設定マスタを読み込み休業日適用区分を取得します。</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.07.11</br>
		///// </remarks>
		//private int LoadHolidaySettingTable(string sectionCode)
		//{
		//    int status;
		//    ArrayList retList;

		//    _holidaySettingDic = new Dictionary<SectionAndDate, HolidaySetting>();

		//    // 休業日設定マスタからデータを取得
		//    HolidaySettingAcs holidaySettingAcs = new HolidaySettingAcs();
		//    status = holidaySettingAcs.Search(
		//        out retList,
		//        this._enterpriseCode,
		//        sectionCode,
		//        DateTime.MinValue,
		//        DateTime.MaxValue);
		//    switch (status)
		//    {
		//        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
		//        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
		//        case (int)ConstantManagement.DB_Status.ctDB_EOF:
		//            break;
		//        default:
		//            TMsgDisp.Show(
		//                this,										// 親ウィンドウフォーム
		//                emErrorLevel.ERR_LEVEL_STOP,				// エラーレベル
		//                this.Name,									// アセンブリID
		//                ctPGNM,  　　								// プログラム名称
		//                "LoadHolidaySettingTable",					// 処理名称
		//                TMsgDisp.OPE_GET,							// オペレーション
		//                "休業日設定マスタの読み込みに失敗しました",					// 表示するメッセージ
		//                status,										// ステータス値
		//                holidaySettingAcs,							// エラーが発生したオブジェクト
		//                MessageBoxButtons.OK,			  			// 表示するボタン
		//                MessageBoxDefaultButton.Button1);			// 初期表示ボタン
		//            return (status);
		//    }

		//    // リスト作成
		//    SectionAndDate sectionAndDate;
		//    foreach (HolidaySetting holidaySetting in retList)
		//    {
		//        sectionAndDate.SectionCode = holidaySetting.SectionCode;
		//        sectionAndDate.Date = holidaySetting.ApplyDate;
		//        _holidaySettingDic.Add(sectionAndDate, holidaySetting);
		//    }

		//    return (0);

		//}

		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// 着地計算比率管理マスタ読み込み処理
		///// </summary>
		///// <param name="sectionCode">拠点コード</param>
		///// <remarks>
		///// <br>Note		: 着地計算比率管理マスタを読み込み各曜日の比率を取得します。</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.07.12</br>
		///// </remarks>
		//private int LoadLdgCalcRatioMngTable(string sectionCode)
		//{
		//    LdgCalcRatioMngAcs ldgCalcRatioMngAcs = new LdgCalcRatioMngAcs();
		//    this._ldgCalcRatioMngList = new List<LdgCalcRatioMng>();

		//    string[] sectionCodeList = new string[1];
		//    sectionCodeList[0] = sectionCode;

		//    // 着地計算比率管理マスタ取得
		//    int status = ldgCalcRatioMngAcs.Search(out this._ldgCalcRatioMngList, this._enterpriseCode, sectionCodeList);
		//    switch (status)
		//    {
		//        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
		//        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
		//        case (int)ConstantManagement.DB_Status.ctDB_EOF:
		//            // 正常
		//            break;
		//        default:
		//            // エラー
		//            return (status);
		//    }

		//    return (0);
		//}

		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// 比率から計算処理
		///// </summary>
		///// <remarks>
		///// <br>Note		: 一日単位の目標を比率から計算します。</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.04.02</br>
		///// </remarks>
		//private void CalcFromRatio()
		//{
		//    // 月間目標
		//    if (this._targetSetCd == 10)
		//    {
		//        if (this.ApplyStaDate_tDateEdit.GetDateTime() == DateTime.MinValue)
		//        {
		//            return;
		//        }
		//    }
		//    // 個別期間目標
		//    else
		//    {
		//        if (this.ApplyStaDate_tDateEdit.GetDateTime() == DateTime.MinValue ||
		//        this.ApplyEndDate_tDateEdit.GetDateTime() == DateTime.MinValue)
		//        {
		//            return;
		//        }
		//    }

		//    if (this.ApplyStaDate_tDateEdit.GetDateTime() > this.ApplyEndDate_tDateEdit.GetDateTime())
		//    {
		//        ClearRatioControl();
		//        return;
		//    }

		//    this._targetStaDate = this.ApplyStaDate_tDateEdit.GetDateTime();
		//    this._targetEndDate = this.ApplyEndDate_tDateEdit.GetDateTime();

		//    double salesTarget;
		//    double[] salesTargetDayOfWeek;

		//    // 計算して表示
		//    if (this.SalesTargetMoney_tNedit.DataText != "")
		//    {
		//        salesTarget = double.Parse(this.SalesTargetMoney_tNedit.DataText);
		//        // 比率計算
		//        SalesLandingAcs.CalcDaySalesTargetFromRatio(
		//            out salesTargetDayOfWeek,
		//            salesTarget,
		//            0,
		//            this._targetStaDate,
		//            this._targetEndDate,
		//            this._salesTarget.SectionCode,
		//            this._ldgCalcRatioMngList,
		//            this._holidaySettingDic);

		//        // 日曜売上
		//        this.SalesTargetMoneySunday_tNedit.Value = salesTargetDayOfWeek[0].ToString(FORMAT_NUM);
		//        // 月曜売上
		//        this.SalesTargetMoneyMonday_tNedit.Value = salesTargetDayOfWeek[1].ToString(FORMAT_NUM);
		//        // 火曜売上
		//        this.SalesTargetMoneyTuesday_tNedit.Value = salesTargetDayOfWeek[2].ToString(FORMAT_NUM);
		//        // 水曜売上
		//        this.SalesTargetMoneyWednesday_tNedit.Value = salesTargetDayOfWeek[3].ToString(FORMAT_NUM);
		//        // 木曜売上
		//        this.SalesTargetMoneyThursday_tNedit.Value = salesTargetDayOfWeek[4].ToString(FORMAT_NUM);
		//        // 金曜売上
		//        this.SalesTargetMoneyFriday_tNedit.Value = salesTargetDayOfWeek[5].ToString(FORMAT_NUM);
		//        // 土曜売上
		//        this.SalesTargetMoneySaturday_tNedit.Value = salesTargetDayOfWeek[6].ToString(FORMAT_NUM);
		//        // 祝祭日売上
		//        this.SalesTargetMoneyHoliday_tNedit.Value = salesTargetDayOfWeek[7].ToString(FORMAT_NUM);
		//    }
		//    else
		//    {
		//        this.SalesTargetMoneySunday_tNedit.DataText = "";
		//        this.SalesTargetMoneyMonday_tNedit.DataText = "";
		//        this.SalesTargetMoneyTuesday_tNedit.DataText = "";
		//        this.SalesTargetMoneyWednesday_tNedit.DataText = "";
		//        this.SalesTargetMoneyThursday_tNedit.DataText = "";
		//        this.SalesTargetMoneyFriday_tNedit.DataText = "";
		//        this.SalesTargetMoneySaturday_tNedit.DataText = "";
		//        this.SalesTargetMoneyHoliday_tNedit.DataText = "";
		//    }
		//    if (this.SalesTargetProfit_tNedit.DataText != "")
		//    {
		//        salesTarget = double.Parse(this.SalesTargetProfit_tNedit.DataText);
		//        // 比率計算
		//        SalesLandingAcs.CalcDaySalesTargetFromRatio(
		//            out salesTargetDayOfWeek,
		//            salesTarget,
		//            0,
		//            this._targetStaDate,
		//            this._targetEndDate,
		//            this._salesTarget.SectionCode,
		//            this._ldgCalcRatioMngList,
		//            this._holidaySettingDic);

		//        // 日曜粗利
		//        this.SalesTargetProfitSunday_tNedit.Value = salesTargetDayOfWeek[0].ToString(FORMAT_NUM);
		//        // 月曜粗利
		//        this.SalesTargetProfitMonday_tNedit.Value = salesTargetDayOfWeek[1].ToString(FORMAT_NUM);
		//        // 火曜粗利
		//        this.SalesTargetProfitTuesday_tNedit.Value = salesTargetDayOfWeek[2].ToString(FORMAT_NUM);
		//        // 水曜粗利
		//        this.SalesTargetProfitWednesday_tNedit.Value = salesTargetDayOfWeek[3].ToString(FORMAT_NUM);
		//        // 木曜粗利
		//        this.SalesTargetProfitThursday_tNedit.Value = salesTargetDayOfWeek[4].ToString(FORMAT_NUM);
		//        // 金曜粗利
		//        this.SalesTargetProfitFriday_tNedit.Value = salesTargetDayOfWeek[5].ToString(FORMAT_NUM);
		//        // 土曜粗利
		//        this.SalesTargetProfitSaturday_tNedit.Value = salesTargetDayOfWeek[6].ToString(FORMAT_NUM);
		//        // 祝祭日粗利
		//        this.SalesTargetProfitHoliday_tNedit.Value = salesTargetDayOfWeek[7].ToString(FORMAT_NUM);
		//    }
		//    else
		//    {
		//        this.SalesTargetProfitSunday_tNedit.DataText = "";
		//        this.SalesTargetProfitMonday_tNedit.DataText = "";
		//        this.SalesTargetProfitTuesday_tNedit.DataText = "";
		//        this.SalesTargetProfitWednesday_tNedit.DataText = "";
		//        this.SalesTargetProfitThursday_tNedit.DataText = "";
		//        this.SalesTargetProfitFriday_tNedit.DataText = "";
		//        this.SalesTargetProfitSaturday_tNedit.DataText = "";
		//        this.SalesTargetProfitHoliday_tNedit.DataText = "";
		//    }
		//    if (this.SalesTargetCount_tNedit.DataText != "")
		//    {
		//        salesTarget = double.Parse(this.SalesTargetCount_tNedit.DataText);
		//        // 比率計算
		//        SalesLandingAcs.CalcDaySalesTargetFromRatio(
		//            out salesTargetDayOfWeek,
		//            salesTarget,
		//            1,
		//            this._targetStaDate,
		//            this._targetEndDate,
		//            this._salesTarget.SectionCode,
		//            this._ldgCalcRatioMngList,
		//            this._holidaySettingDic);

		//        // 日曜数量
		//        this.SalesTargetCountSunday_tNedit.Value = salesTargetDayOfWeek[0].ToString(FORMAT_NUM_DECIMAL);
		//        // 月曜数量
		//        this.SalesTargetCouｎtMonday_tNedit.Value = salesTargetDayOfWeek[1].ToString(FORMAT_NUM_DECIMAL);
		//        // 火曜数量
		//        this.SalesTargetCountTuesday_tNedit.Value = salesTargetDayOfWeek[2].ToString(FORMAT_NUM_DECIMAL);
		//        // 水曜数量
		//        this.SalesTargetCountWednesday_tNedit.Value = salesTargetDayOfWeek[3].ToString(FORMAT_NUM_DECIMAL);
		//        // 木曜数量
		//        this.SalesTargetCountThursday_tNedit.Value = salesTargetDayOfWeek[4].ToString(FORMAT_NUM_DECIMAL);
		//        // 金曜数量
		//        this.SalesTargetCountFriday_tNedit.Value = salesTargetDayOfWeek[5].ToString(FORMAT_NUM_DECIMAL);
		//        // 土曜数量
		//        this.SalesTargetCountSaturday_tNedit.Value = salesTargetDayOfWeek[6].ToString(FORMAT_NUM_DECIMAL);
		//        // 祝祭日数量
		//        this.SalesTargetCountHoliday_tNedit.Value = salesTargetDayOfWeek[7].ToString(FORMAT_NUM_DECIMAL);
		//    }
		//    else
		//    {
		//        this.SalesTargetCountSunday_tNedit.DataText = "";
		//        this.SalesTargetCouｎtMonday_tNedit.DataText = "";
		//        this.SalesTargetCountTuesday_tNedit.DataText = "";
		//        this.SalesTargetCountWednesday_tNedit.DataText = "";
		//        this.SalesTargetCountThursday_tNedit.DataText = "";
		//        this.SalesTargetCountFriday_tNedit.DataText = "";
		//        this.SalesTargetCountSaturday_tNedit.DataText = "";
		//        this.SalesTargetCountHoliday_tNedit.DataText = "";
		//    }
		//}
		#endregion del
		//----- ueno del---------- start 2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 対象期間設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 期間の設定を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.17</br>
		/// </remarks>
		private void SetTargetDate()
		{
			// 月間目標
			if (this._targetSetCd == 10)
			{
				if (this.ApplyStaDate_tDateEdit.GetDateTime() == DateTime.MinValue)
				{
					return;
				}

				this._targetStaDate = new DateTime(ApplyStaDate_tDateEdit.GetDateYear(), ApplyStaDate_tDateEdit.GetDateMonth(), 1);
				int days = DateTime.DaysInMonth(ApplyStaDate_tDateEdit.GetDateYear(), ApplyStaDate_tDateEdit.GetDateMonth());
				this._targetEndDate = new DateTime(ApplyStaDate_tDateEdit.GetDateYear(), ApplyStaDate_tDateEdit.GetDateMonth(), days);
			}
			// 個別期間目標
			else
			{
				if (this.ApplyStaDate_tDateEdit.GetDateTime() == DateTime.MinValue ||
				this.ApplyEndDate_tDateEdit.GetDateTime() == DateTime.MinValue)
				{
					return;
				}

				this._targetStaDate = this.ApplyStaDate_tDateEdit.GetDateTime();
				this._targetEndDate = this.ApplyEndDate_tDateEdit.GetDateTime();
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 目標データ画面展開処理
		/// </summary>
		/// <param name="salesTarget">目標データ</param>
		/// <remarks>
		/// Note	   : 修正対象の目標データを画面に展開します。<br />
		/// Programmer : NEPCO<br />
		/// Date	   : 2007.04.03<br />
		/// </remarks>
		private void SalesTargetToScreen(SalesTarget salesTarget)
		{
//----- ueno add---------- start 2007.11.21
			// 目標対比区分
			if (salesTarget.TargetContrastCd != 0)
			{
				this.TargetContrastCd_tComboEditor.Value = (int)salesTarget.TargetContrastCd;
			}
//----- ueno add---------- end   2007.11.21

			// 目標設定区分
			//this.TargetSetCd_uOptionSet.Value = salesTarget.TargetSetCd;
            if (salesTarget.TargetSetCd == 10)
            {
                this.TargetSetCd_tComboEditor.SelectedIndex = 0;
            }
            else
            {
                this.TargetSetCd_tComboEditor.SelectedIndex = 1;
            }
			// 拠点名称
			this.SectionName_tEdit.DataText = this._sectionName;
			// 適用期間（開始）
			this.ApplyStaDate_tDateEdit.SetDateTime(salesTarget.ApplyStaDate);
			// 適用期間（終了）
			this.ApplyEndDate_tDateEdit.SetDateTime(salesTarget.ApplyEndDate);
			// 目標区分コード
			this.TargetDivideCode_tEdit.DataText = salesTarget.TargetDivideCode;
			// 目標区分名称
			this.TargetDivideName_tEdit.DataText = salesTarget.TargetDivideName;
			// 商品コード
			this.GoodsCode_tEdit.DataText = salesTarget.GoodsCode;
			// 商品名称
			this.GoodsName_tEdit.DataText = salesTarget.GoodsName;
//----- ueno upd---------- start 2007.11.21
			// メーカーコード
			this.GoodsMakerCd_tNedit.SetInt(salesTarget.MakerCode);
//----- ueno upd---------- end   2007.11.21
			// メーカー名称
			this.GoodsMakerCdNm_tEdit.DataText = salesTarget.MakerName;

			//----- ueno del---------- start 2007.11.21
			//// キャリアコード
			//this.CarrierName_tEdit.Tag = salesTarget.CarrierCode;
			//// キャリア名称
			//this.CarrierName_tEdit.DataText = salesTarget.CarrierName;
			//// 機種コード
			//this.CellphoneModelName_tEdit.Tag = salesTarget.CellphoneModelCode;
			//// 機種名称
			//this.CellphoneModelName_tEdit.DataText = salesTarget.CellphoneModelName;
			//----- ueno del---------- end   2007.11.21

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
            // BLグループコード
            this.BLGroupCode_tNedit.SetInt(salesTarget.BLGroupCode);
            // BLグループ名称
            this.BLGroupName_tEdit.DataText = salesTarget.BLGroupName;
            // BLコード
            this.BLCode_tNedit.SetInt(salesTarget.BLCode);
            // BLコード名称
            this.BLCodeName_tEdit.DataText = salesTarget.BLCodeName;
            // 販売区分コード
            this.SalesTypeCode_tNedit.SetInt(salesTarget.SalesTypeCode);
            // 販売区分名称
            this.SalesTypeName_tEdit.DataText = salesTarget.SalesTypeName;
            // 商品区分コード
            this.ItemTypeCode_tNedit.SetInt(salesTarget.ItemTypeCode);
            // 商品区分名称
            this.ItemTypeName_tEdit.DataText = salesTarget.ItemTypeName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END

			// 売上目標
			if (salesTarget.SalesTargetMoney == 0)
			{
				this.SalesTargetMoney_tNedit.DataText = "";
			}
			else
			{
				this.SalesTargetMoney_tNedit.DataText = salesTarget.SalesTargetMoney.ToString();
			}
			// 粗利目標
			if (salesTarget.SalesTargetProfit == 0)
			{
				this.SalesTargetProfit_tNedit.DataText = "";
			}
			else
			{
				this.SalesTargetProfit_tNedit.DataText = salesTarget.SalesTargetProfit.ToString();
			}
			// 数量目標
			if (salesTarget.SalesTargetCount == 0)
			{
				this.SalesTargetCount_tNedit.DataText = "";
			}
			else
			{
				this.SalesTargetCount_tNedit.DataText = salesTarget.SalesTargetCount.ToString();
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 修正目標データバッファ保存処理
		/// </summary>
		/// <param name="salesTarget">目標データ</param>
		/// <remarks>
		/// Note	   : 修正対象の目標データをバッファに保存します。<br />
		/// Programmer : NEPCO<br />
		/// Date	   : 2007.04.03<br />
		/// </remarks>
		private void ScreenToSalesTarget(out SalesTarget salesTarget)
		{
			salesTarget = this._salesTarget.Clone();

//----- ueno add---------- start 2007.11.21
			// 目標対比区分
			if (this.TargetContrastCd_tComboEditor.Value != null)
			{
				salesTarget.TargetContrastCd = (int)this.TargetContrastCd_tComboEditor.Value;
			}
//----- ueno add---------- end   2007.11.21

			// 目標設定区分
			//salesTarget.TargetSetCd = (int)TargetSetCd_uOptionSet.Value;
            salesTarget.TargetSetCd = int.Parse(TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString());
			// 期間（開始）
            //salesTarget.ApplyStaDate = this._targetStaDate;
            salesTarget.ApplyStaDate = this.ApplyStaDate_tDateEdit.GetDateTime();
			// 期間（終了）
            //salesTarget.ApplyEndDate = this._targetEndDate;
            salesTarget.ApplyEndDate = this.ApplyEndDate_tDateEdit.GetDateTime();
			// 目標区分コード
			salesTarget.TargetDivideCode = this.TargetDivideCode_tEdit.DataText;
			// 目標区分名称
			salesTarget.TargetDivideName = this.TargetDivideName_tEdit.DataText;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA MODIFY START
            // 商品コード
            if (this.GoodsCode_tEdit.DataText == null)
            {
                salesTarget.GoodsCode = string.Empty;
            }
            else
            {
                salesTarget.GoodsCode = this.GoodsCode_tEdit.DataText;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA MODIFY END

			// 商品名称
			salesTarget.GoodsName = this.GoodsName_tEdit.DataText;
//----- ueno upd---------- start 2007.11.21
			// メーカーコード
			salesTarget.MakerCode = this.GoodsMakerCd_tNedit.GetInt();
//----- ueno upd---------- end   2007.11.21
			// メーカー名称
			salesTarget.MakerName = this.GoodsMakerCdNm_tEdit.DataText;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
            salesTarget.BLGroupCode = this.BLGroupCode_tNedit.GetInt();
            salesTarget.BLGroupName = this.BLGroupName_tEdit.DataText;
            salesTarget.BLCode = this.BLCode_tNedit.GetInt();
            salesTarget.BLCodeName = this.BLCodeName_tEdit.DataText;
            salesTarget.SalesTypeCode = this.SalesTypeCode_tNedit.GetInt();
            salesTarget.SalesTypeName = this.SalesTypeName_tEdit.DataText;
            salesTarget.ItemTypeCode = this.ItemTypeCode_tNedit.GetInt();
            salesTarget.ItemTypeName = this.ItemTypeName_tEdit.DataText;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END


			//----- ueno del---------- start 2007.11.21
			//// キャリアコード
			//salesTarget.CarrierCode = (int)this.CarrierName_tEdit.Tag;
			//// キャリア名称
			//salesTarget.CarrierName = this.CarrierName_tEdit.DataText;
			//// 機種コード
			//salesTarget.CellphoneModelCode = (string)this.CellphoneModelName_tEdit.Tag;
			//if (salesTarget.CellphoneModelCode == "")
			//{
			//    salesTarget.CellphoneModelCode = CELLPHONEMODELCODE_NONE;
			//}
			//// 機種名称
			//salesTarget.CellphoneModelName = this.CellphoneModelName_tEdit.DataText;
			//----- ueno del---------- end   2007.11.21

			// 売上目標
			if (this.SalesTargetMoney_tNedit.DataText != "")
			{
				salesTarget.SalesTargetMoney = long.Parse(this.SalesTargetMoney_tNedit.DataText);
			}
			else
			{
				salesTarget.SalesTargetMoney = new long();
			}
			// 粗利目標
			if (this.SalesTargetProfit_tNedit.DataText != "")
			{
				salesTarget.SalesTargetProfit = long.Parse(this.SalesTargetProfit_tNedit.DataText);
			}
			else
			{
				salesTarget.SalesTargetProfit = new long();
			}
			// 数量目標
			if (this.SalesTargetCount_tNedit.DataText != "")
			{
				salesTarget.SalesTargetCount = double.Parse(this.SalesTargetCount_tNedit.DataText);
			}
			else
			{
				salesTarget.SalesTargetCount = new double();
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 修正目標データチェック処理
		/// </summary>
		/// <remarks>
		/// Note	   : 修正目標データをチェックします。<br />
		/// Programmer : NEPCO<br />
		/// Date	   : 2007.04.03<br />
		/// </remarks>
		private bool CheckInputData()
		{
			string errMsg = "";
			try
			{
				// 月間目標
				if (this._targetSetCd == 10)
				{
					if (this.ApplyStaDate_tDateEdit.GetDateYear() == 0 ||
						this.ApplyStaDate_tDateEdit.GetDateMonth() == 0)
					{
                        errMsg = "日付を正しく入力してください";
						this.ApplyStaDate_tDateEdit.Focus();
						return (false);
					}

					try
					{
						DateTime dummyDateTime = new DateTime(
								this.ApplyStaDate_tDateEdit.GetDateYear(),
								this.ApplyStaDate_tDateEdit.GetDateMonth(),
								1);
					}
					catch (ArgumentOutOfRangeException)
					{
						errMsg = "日付を正しく入力してください";
						this.ApplyStaDate_tDateEdit.Focus();
						return (false);
					}
				}
				// 個別目標
				else
				{
					if (this.ApplyStaDate_tDateEdit.GetDateYear() == 0 ||
						this.ApplyStaDate_tDateEdit.GetDateMonth() == 0 ||
						this.ApplyStaDate_tDateEdit.GetDateDay() == 0)
					{
                        errMsg = "日付を正しく入力してください";
						this.ApplyStaDate_tDateEdit.Focus();
						return (false);
					}

					try
					{
						DateTime dummyDateTime = new DateTime(
							this.ApplyStaDate_tDateEdit.GetDateYear(),
							this.ApplyStaDate_tDateEdit.GetDateMonth(),
							this.ApplyStaDate_tDateEdit.GetDateDay());
					}
					catch (ArgumentOutOfRangeException)
					{
						errMsg = "日付を正しく入力してください";
						this.ApplyStaDate_tDateEdit.Focus();
						return (false);
					}

					if (this.ApplyEndDate_tDateEdit.GetDateYear() == 0 ||
						this.ApplyEndDate_tDateEdit.GetDateMonth() == 0 ||
						this.ApplyEndDate_tDateEdit.GetDateDay() == 0)
					{
                        errMsg = "日付を正しく入力してください";
						this.ApplyEndDate_tDateEdit.Focus();
						return (false);
					}

					try
					{
						DateTime dummyDateTime = new DateTime(
							this.ApplyEndDate_tDateEdit.GetDateYear(),
							this.ApplyEndDate_tDateEdit.GetDateMonth(),
							this.ApplyEndDate_tDateEdit.GetDateDay());
					}
					catch (ArgumentOutOfRangeException)
					{
						errMsg = "日付を正しく入力してください";
						this.ApplyEndDate_tDateEdit.Focus();
						return (false);
					}

					if (this.ApplyStaDate_tDateEdit.GetDateTime() > this.ApplyEndDate_tDateEdit.GetDateTime())
					{
						errMsg = "開始　<=  終了で指定してください";
						this.ApplyStaDate_tDateEdit.Focus();
						return (false);
					}

					if (this.TargetDivideCode_tEdit.DataText == "")
					{
						errMsg = "目標区分コードを入力してください";
						this.TargetDivideCode_tEdit.Focus();
						return (false);
					}
					if (this.TargetDivideName_tEdit.DataText == "")
					{
						errMsg = "目標区分名称を入力してください";
						this.TargetDivideName_tEdit.Focus();
						return (false);
					}
				}

//----- ueno add---------- start 2007.11.21

				// 目標対比区分によりチェック変更
				switch((int)this.TargetContrastCd_tComboEditor.Value)
				{
					case (int)SalesTarget.ConstrastCd.SecAndMaker:				// 40:拠点＋メーカー
						{
							if ((this.GoodsMakerCd_tNedit.DataText == "") || (this.GoodsMakerCd_tNedit.GetInt() == 0))
							{
								errMsg = "メーカーコードを入力してください";
								this.GoodsMakerCd_tNedit.Focus();

								//----- ueno add---------- start 2008.03.05
								this.GoodsMakerCdNm_tEdit.Clear();	// メーカー名称クリア
								this._goodsMakerCdWork = 0;			// メーカーコードワーククリア

								this.GoodsCode_tEdit.Clear();		// 商品コードクリア
								this.GoodsName_tEdit.Clear();		// 商品名称クリア
								this._goodsCodeWork = "";			// 商品コードワーククリア
								//----- ueno add---------- end 2008.03.05

								return (false);
							}
							break;
						}
					case (int)SalesTarget.ConstrastCd.SecAndMakerAndGoods:		// 41:拠点＋メーカー＋商品
						{
							if ((this.GoodsMakerCd_tNedit.DataText == "") || (this.GoodsMakerCd_tNedit.GetInt() == 0))
							{
								errMsg = "メーカーコードを入力してください";
								this.GoodsMakerCd_tNedit.Focus();

								//----- ueno add---------- start 2008.03.05
								this.GoodsMakerCdNm_tEdit.Clear();	// メーカー名称クリア
								this._goodsMakerCdWork = 0;			// メーカーコードワーククリア

								this.GoodsCode_tEdit.Clear();		// 商品コードクリア
								this.GoodsName_tEdit.Clear();		// 商品名称クリア
								this._goodsCodeWork = "";			// 商品コードワーククリア
								//----- ueno add---------- end 2008.03.05

								return (false);
							}
							if (this.GoodsCode_tEdit.DataText == "")
							{
								errMsg = "商品コードを入力してください";
								this.GoodsCode_tEdit.Focus();

								//----- ueno add---------- start 2008.03.05
								this.GoodsName_tEdit.Clear();	// 商品名称クリア
								this._goodsCodeWork = "";		// 商品コードワーククリア
								//----- ueno add---------- end 2008.03.05

								return (false);
							}
							break;
						}
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
                    case (int)SalesTarget.ConstrastCd.SecAndBLGroup:		// 42:拠点＋BLグループ
                        {
                            if ((this.BLGroupCode_tNedit.DataText == "") || (this.BLGroupCode_tNedit.GetInt() == 0))
                            {
                                errMsg = "BLグループコードを入力してください";
                                this.BLGroupCode_tNedit.Focus();

                                return (false);
                            }
                            break;
                        }
                    case (int)SalesTarget.ConstrastCd.SecAndBlCode:		// 43:拠点＋BLコード
                        {
                            if ((this.BLCode_tNedit.DataText == "") || (this.BLCode_tNedit.GetInt() == 0))
                            {
                                errMsg = "BLコードを入力してください";
                                this.BLCode_tNedit.Focus();

                                return (false);
                            }
                            break;
                        }
                    case (int)SalesTarget.ConstrastCd.SecAndSalesType:		// 44:拠点＋販売区分
                        {
                            if ((this.SalesTypeCode_tNedit.DataText == "") || (this.SalesTypeCode_tNedit.GetInt() == 0))
                            {
                                errMsg = "販売区分を入力してください";
                                this.SalesTypeCode_tNedit.Focus();

                                return (false);
                            }
                            break;
                        }
                    case (int)SalesTarget.ConstrastCd.SecAndItemType:		// 45:拠点＋商品区分
                        {
                            if ((this.ItemTypeCode_tNedit.DataText == "") || (this.ItemTypeCode_tNedit.GetInt() == 0))
                            {
                                errMsg = "商品区分を入力してください";
                                this.ItemTypeCode_tNedit.Focus();

                                return (false);
                            }
                            break;
                        }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END
				}
//----- ueno add---------- end   2007.11.21

				//----- ueno add---------- start 2008.03.05
				DispSetStatus dispSetStatus = DispSetStatus.Clear;

				bool canChangeFocus = true;
				object inParamObj = null;
				object outParamObj = null;
				ArrayList inParamList = null;
				
				//------------------------
				// メーカーコードチェック
				//------------------------
				if (this.GoodsMakerCd_tNedit.Enabled == true)
				{
					// 条件設定クリア
					inParamObj = null;
					outParamObj = null;
					inParamList = new ArrayList();

					dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用

					// 条件設定
					inParamObj = this.GoodsMakerCd_tNedit.GetInt();

					// 存在チェック
					switch (CheckGoodsMakerCd(inParamObj, out outParamObj))
					{
						case (int)InputChkStatus.Normal:
							{
								dispSetStatus = DispSetStatus.Update;
								break;
							}
						case (int)InputChkStatus.NotInput:
							{
								dispSetStatus = DispSetStatus.Clear;
								break;
							}
						default:
							{
								errMsg = ShowNotFoundErrMsg("メーカーコード");
								dispSetStatus = this._goodsMakerCdWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
								break;
							}
					}
					// データ設定
					DispSetGoodsMakerCd(dispSetStatus, ref canChangeFocus, outParamObj);

					if (dispSetStatus != DispSetStatus.Update)
					{
						this.GoodsMakerCd_tNedit.Focus();
						return false;
					}
				}
				
				//------------------------
				// 商品コードチェック
				//------------------------
				if (this.GoodsCode_tEdit.Enabled == true)
				{
					// 条件設定クリア
					inParamObj = null;
					outParamObj = null;
					inParamList = new ArrayList();

					dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用

					// 条件設定
					inParamList.Add(this.GoodsMakerCd_tNedit.GetInt());
					inParamList.Add(this.GoodsCode_tEdit.Text);
					inParamObj = inParamList;

					// 存在チェック
					switch (CheckGoodsNoCd(inParamObj, out outParamObj))
					{
						case (int)InputChkStatus.Normal:
							{
								dispSetStatus = DispSetStatus.Update;
								break;
							}
						case (int)InputChkStatus.NotInput:
							{
								dispSetStatus = DispSetStatus.Clear;
								break;
							}
						case (int)InputChkStatus.Cancel:
							{
								dispSetStatus = DispSetStatus.Clear;
								break;
							}
						default:
							{
								errMsg = ShowNotFoundErrMsg("商品コード");
								dispSetStatus = this._goodsCodeWork == "" ? DispSetStatus.Clear : DispSetStatus.Back;
								break;
							}
					}
					// データ設定
					DispSetGoodsNoCd(dispSetStatus, ref canChangeFocus, outParamObj);

					if (dispSetStatus != DispSetStatus.Update)
					{
						this.GoodsCode_tEdit.Focus();
						return false;
					}
				}
				//----- ueno add---------- end 2008.03.05

				//----- ueno mov---------- start 2007.11.21
				// 上記目標対比区分の条件に追加
				//if (this.GoodsCode_tEdit.DataText == "")
				//{
				//    errMsg = "商品コードを入力してください";
				//    this.GoodsCode_tEdit.Focus();
				//    return (false);
				//}
				//----- ueno mov---------- end   2007.11.21

                if ((this.SalesTargetMoney_tNedit.DataText == "" || long.Parse(this.SalesTargetMoney_tNedit.DataText) == 0) &&
                    (this.SalesTargetProfit_tNedit.DataText == "" || long.Parse(this.SalesTargetProfit_tNedit.DataText) == 0) &&
                    (this.SalesTargetCount_tNedit.DataText == "" || double.Parse(this.SalesTargetCount_tNedit.DataText) == 0))
                {
                    errMsg = "目標金額または数量を入力してください";
                    this.SalesTargetMoney_tNedit.Focus();
                    return (false);
                }

				//----- ueno del---------- start 2007.11.21
				// 正当性チェックは入力域を離れたら行う(Change_focusで行っている)
				//string searchCode;
				//string goodsCode = this.GoodsCode_tEdit.Text.Trim();
				//int searchType = StockSlipInputInitDataAcs.GetSearchType(goodsCode, out searchCode);

				//List<GoodsUnitData> goodsUnitDataList;
				//string message;
				//MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();
				//int status = goodsSelectGuide.ReadGoods(this, this._enterpriseCode, searchType, searchCode, out goodsUnitDataList, out message);
				//if (!((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0)))
				//{
				//    errMsg = "商品コード [" + searchCode + "] に該当するデータが存在しません";
				//    this.GoodsCode_tEdit.Focus();
				//    return (false);
				//}
				//----- ueno del---------- end   2007.11.21
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
		/// 修正目標データ保存処理
		/// </summary>
		/// <param name="salesTarget">目標データ</param>
		/// <remarks>
		/// Note	   : 修正目標データを保存します。<br />
		/// Programmer : NEPCO<br />
		/// Date	   : 2007.04.11<br />
		/// </remarks>
		private bool SaveSalesTarget(ref SalesTarget salesTarget)
		{
			//----- ueno mov---------- start 2007.11.21
			//-----データ格納処理はメソッド外部で行うよう修正
			//bool retResult;

			//// チェック処理
			//retResult = CheckInputData();
			//if (!retResult)
			//{
			//    return (false);
			//}

			//SalesTarget salesTarget;

			//// 修正後目標データをバッファに保存
			//ScreenToSalesTarget(out salesTarget);
			//----- ueno mov---------- end   2007.11.21

			List<SalesTarget> salesTargetList = new List<SalesTarget>();
			salesTargetList.Add(salesTarget);

			int status;
            string checkMessage = "";

			// 目標データ更新
			status = this._salesTargetAcs.Write(ref salesTargetList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    checkMessage = "既に他端末より更新されています";
                    TMsgDisp.Show(
                        this,									// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, 	// エラーレベル
                        this.Name,								// アセンブリID
                        checkMessage,							// 表示するメッセージ
                        status,									// ステータス値
                        MessageBoxButtons.OK);					// 表示するボタン
                    return (false);
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    checkMessage = "既に他端末より削除されています";
                    TMsgDisp.Show(
                        this, 						                // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, 	    // エラーレベル
                        this.Name,								    // アセンブリID
                        checkMessage,		                        // 表示するメッセージ
                        status,									    // ステータス値
                        MessageBoxButtons.OK);					    // 表示するボタン
                    return (false);
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    checkMessage = "既に登録されている目標データです";
                    TMsgDisp.Show(
                        this,									// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, 	// エラーレベル
                        this.Name,								// アセンブリID
                        checkMessage,							// 表示するメッセージ
                        status,									// ステータス値
                        MessageBoxButtons.OK);					// 表示するボタン
                    return (false);
                default:
                    checkMessage = "目標データ保存時にエラーが発生しました";
                    TMsgDisp.Show(
                        this, 						                // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOP,			    // エラーレベル
                        this.Name,								    // アセンブリID
                        ctPGNM, 		  　　					    // プログラム名称
                        "SaveSalesTarget",						            // 処理名称
                        TMsgDisp.OPE_UPDATE,					    // オペレーション
                        checkMessage,	                            // 表示するメッセージ
                        status,									    // ステータス値
                        this._salesTargetAcs,					    // エラーが発生したオブジェクト
                        MessageBoxButtons.OK,			  		    // 表示するボタン
                        MessageBoxDefaultButton.Button1);		    // 初期表示ボタン
                    return (false);
            }

			this._salesTarget = salesTarget;
			this._salesTargetList = salesTargetList;

			return (true);
		}

		//----- ueno del---------- start 2007.11.21
		#region del
		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// 商品検索処理
		///// </summary>
		///// <param name="goodsCode">商品コード</param>
		///// <remarks>
		///// <br>Note		: 商品を検索します。</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.02.22</br>
		///// </remarks>
		//private int SearchGoods(string goodsCode)
		//{
		//    string searchCode;
		//    int searchType = StockSlipInputInitDataAcs.GetSearchType(goodsCode, out searchCode);

		//    List<GoodsUnitData> goodsUnitDataList;
		//    string message;
		//    MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();
		//    int status = goodsSelectGuide.ReadGoods(this, this._enterpriseCode, searchType, searchCode, out goodsUnitDataList, out message);
		//    if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
		//    {
		//        GoodsUnitData goodsUnitData;
		//        goodsUnitData = goodsUnitDataList[0];

		//        // メーカー
		//        this.GoodsMakerCd_tNedit.SetInt(goodsUnitData.GoodsMakerCd);

		//        // 商品
		//        this.GoodsCode_tEdit.DataText = goodsUnitData.GoodsNo;
		//        this.GoodsName_tEdit.DataText = goodsUnitData.GoodsName;
				
		//        //// キャリア
		//        //this.CarrierName_tEdit.Tag = goodsUnitData.CarrierCode;
		//        //this.CarrierName_tEdit.DataText = goodsUnitData.CarrierName;

		//        //// 機種
		//        //this.CellphoneModelName_tEdit.Tag = goodsUnitData.CellphoneModelCode;
		//        //this.CellphoneModelName_tEdit.DataText = goodsUnitData.CellphoneModelName;

		//        //// 系統色
		//        //this.SystematicColorNm_tEdit.Tag = goodsUnitData.SystematicColorCd;
		//        //this.SystematicColorNm_tEdit.DataText = goodsUnitData.SystematicColorNm;

		//        return (0);

		//    }
		//    else
		//    {
		//        //this.GoodsCode_tEdit.DataText = "";
		//        this.GoodsName_tEdit.DataText = "";
		//        this.GoodsMakerCdNm_tEdit.DataText = "";

		//        //----- ueno del---------- start 2007.11.21
		//        //this.GoodsMakerCdNm_tEdit.Tag = -1;
		//        //this.CarrierName_tEdit.DataText = "";
		//        //this.CarrierName_tEdit.Tag = -1;
		//        //this.CellphoneModelName_tEdit.DataText = "";
		//        //this.CellphoneModelName_tEdit.Tag = "";
		//        //----- ueno del---------- end   2007.11.21

		//        return (1);
		//    }
		//}
		#endregion del
		//----- ueno del---------- end   2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// コントロール制御処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: コントロールの制御を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.16</br>
		/// </remarks>
		private void ControlEnabled()
		{
			// 月間目標
			if (this._targetSetCd == 10)
			{
				this.ApplyStaDate_tDateEdit.DateFormat = emDateFormat.df4Y2M;
				this.Range_uLabel.Visible = false;
				this.ApplyEndDate_tDateEdit.Visible = false;
				this.ApplyDate_uLabel.Text = "適用年月";
//----- ueno add---------- start 2007.11.21
				this.TargetDivideCode_uLabel.Visible = false;
				this.TargetDivideCode_tEdit.Visible = false;
				this.TargetDivideName_uLabel.Visible = false;
				this.TargetDivideName_tEdit.Visible = false;
//----- ueno add---------- end   2007.11.21
			}
			// 個別目標
			else
			{
				this.ApplyStaDate_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
				this.Range_uLabel.Visible = true;
				this.ApplyEndDate_tDateEdit.Visible = true;
				this.ApplyDate_uLabel.Text = "適用期間";
//----- ueno add---------- start 2007.11.21
				this.TargetDivideCode_uLabel.Visible = true;
				this.TargetDivideCode_tEdit.Visible = true;
				this.TargetDivideName_uLabel.Visible = true;
				this.TargetDivideName_tEdit.Visible = true;
//----- ueno add---------- end   2007.11.21
			}

			// 新規モード
			if (this._mode == 0)
			{
				this.Mode_Label.Text = "新規";

//----- ueno upd---------- start 2007.11.21
				// 目標対比区分コンボボックス値で判定する
				if (this.TargetContrastCd_tComboEditor.Value != null)
				{
					TargetContrastCdChange((Int32)this.TargetContrastCd_tComboEditor.Value);
				}
				//this.GoodsCode_tEdit.Enabled = true;
				//this.GoodsCodeGuide_Button.Enabled = true;
//----- ueno upd---------- end   2007.11.21

				// 月間
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA MODIFY START
                if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 10)
				//if ((int)this.TargetSetCd_uOptionSet.Value == 10)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA MODIFY END
                {
					this.TargetDivideCode_tEdit.Enabled = false;
					this.TargetDivideName_tEdit.Enabled = false;
				}
				// 個別
				else
				{
					this.TargetDivideCode_tEdit.Enabled = true;
					this.TargetDivideName_tEdit.Enabled = true;
				}

				// 検索後の新規モードだった場合
				if (this._searchFlag == true)
				{
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA MODIFY START
                    this.TargetSetCd_tComboEditor.Enabled = false;
				    //this.TargetSetCd_uOptionSet.Enabled = false;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA MODIFY END
				    this.ApplyStaDate_tDateEdit.Enabled = false;
				    this.ApplyEndDate_tDateEdit.Enabled = false;
				    this.TargetDivideCode_tEdit.Enabled = false;
				    this.TargetDivideName_tEdit.Enabled = false;
				}
				// 検索前の新規モードだった場合
				else
				{
					this.ApplyStaDate_tDateEdit.Enabled = true;
					this.ApplyEndDate_tDateEdit.Enabled = true;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA MODIFY START
                    this.TargetSetCd_tComboEditor.Enabled = true;
					//this.TargetSetCd_uOptionSet.Enabled = true;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA MODIFY END				
                }
			}
			// 編集モード
			else
			{
				this.Mode_Label.Text = "編集";
				this.GoodsCode_tEdit.Enabled = false;
				this.GoodsCodeGuide_Button.Enabled = false;
//----- ueno add---------- start 2007.11.21
				this.TargetContrastCd_tComboEditor.Enabled = false;
				this.GoodsMakerCd_tNedit.Enabled = false;
				this.GoodsMakerCdGuide_Button.Enabled = false;
//----- ueno add---------- end   2007.11.21
			}

		}


		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 日付チェック処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 入力日付のチェックを行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.23</br>
		/// </remarks>
		private bool CheckDate()
		{
			string errMsg = "";

			try
			{
				// 月間目標
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA MODIFY START
				if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 10)
                //if ((int)this.TargetSetCd_uOptionSet.Value == 10)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA MODIFY END
				{
					if (this.ApplyStaDate_tDateEdit.GetDateYear() != 0 &&
						this.ApplyStaDate_tDateEdit.GetDateMonth() != 0)
					{
						try
						{
							DateTime dummyDateTime = new DateTime(
								this.ApplyStaDate_tDateEdit.GetDateYear(),
								this.ApplyStaDate_tDateEdit.GetDateMonth(),
								1);
						}
						catch (ArgumentOutOfRangeException)
						{
							errMsg = "日付を正しく入力してください";
							this.ApplyStaDate_tDateEdit.Focus();
							return (false);
						}
					}

                    if (this.ApplyStaDate_tDateEdit.GetDateYear() == 1 &&
                        this.ApplyStaDate_tDateEdit.GetDateMonth() == 1)
                    {
                        errMsg = "日付を正しく入力してください";
                        this.ApplyStaDate_tDateEdit.Focus();
                        return (false);
                    }
                    if (this.ApplyStaDate_tDateEdit.GetDateYear() < 1900)
                    {
                        errMsg = "日付を正しく入力してください";
                        this.ApplyStaDate_tDateEdit.Focus();
                        return (false);
                    }
				}
				// 個別期間目標
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA MODIFY START
				else if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 20)
                //else if ((int)this.TargetSetCd_uOptionSet.Value == 20)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA MODIFY END
				{
					if (this.ApplyStaDate_tDateEdit.GetDateYear() != 0 &&
						this.ApplyStaDate_tDateEdit.GetDateMonth() != 0 &&
						this.ApplyStaDate_tDateEdit.GetDateDay() != 0)
					{
						try
						{
							DateTime dummyDateTime = new DateTime(
								this.ApplyStaDate_tDateEdit.GetDateYear(),
								this.ApplyStaDate_tDateEdit.GetDateMonth(),
								this.ApplyStaDate_tDateEdit.GetDateDay());
						}
						catch (ArgumentOutOfRangeException)
						{
							errMsg = "日付を正しく入力してください";
							this.ApplyStaDate_tDateEdit.Focus();
							return (false);
						}

                        if (this.ApplyStaDate_tDateEdit.GetDateYear() < 1900)
                        {
                            errMsg = "日付を正しく入力してください";
                            this.ApplyStaDate_tDateEdit.Focus();
                            return (false);
                        }
					}

					if (this.ApplyEndDate_tDateEdit.GetDateYear() != 0 &&
						this.ApplyEndDate_tDateEdit.GetDateMonth() != 0 &&
						this.ApplyEndDate_tDateEdit.GetDateDay() != 0)
					{
						try
						{
							DateTime dummyDateTime = new DateTime(
								this.ApplyEndDate_tDateEdit.GetDateYear(),
								this.ApplyEndDate_tDateEdit.GetDateMonth(),
								this.ApplyEndDate_tDateEdit.GetDateDay());
						}
						catch (ArgumentOutOfRangeException)
						{
							errMsg = "日付を正しく入力してください";
							this.ApplyEndDate_tDateEdit.Focus();
							return (false);
						}

                        if (this.ApplyEndDate_tDateEdit.GetDateYear() < 1900)
                        {
                            errMsg = "日付を正しく入力してください";
                            this.ApplyEndDate_tDateEdit.Focus();
                            return (false);
                        }
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

		//----- ueno del---------- start 2007.11.21
		#region del
		////*----------------------------------------------------------------------------------*/
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
		//    this.RatioSunday_tNedit.Value = RATIO_DEFAULT;
		//    this.RatioMonday_tNedit.Value = RATIO_DEFAULT;
		//    this.RatioTuesday_tNedit.Value = RATIO_DEFAULT;
		//    this.RatioWednesday_tNedit.Value = RATIO_DEFAULT;
		//    this.RatioThursday_tNedit.Value = RATIO_DEFAULT;
		//    this.RatioFriday_tNedit.Value = RATIO_DEFAULT;
		//    this.RatioSaturday_tNedit.Value = RATIO_DEFAULT;
		//    this.RatioHoliday_tNedit.Value = RATIO_DEFAULT;

		//    foreach (LdgCalcRatioMng ldgCalcRatioMng in this._ldgCalcRatioMngList)
		//    {
		//        if (ldgCalcRatioMng.SectionCode == this._salesTarget.SectionCode)
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
		#endregion del
		//----- ueno del---------- end   2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// コントロールサイズ設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: コントロールサイズの設定を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.12</br>
		/// </remarks>
		private void SetControlSize()
		{
			//----- ueno del ---------- start 2008.03.05
			//-- 画面の設定は全て画面デザインで行うので以下削除
			//this.SectionName_tEdit.Size = new Size(179, 24);
			//this.TargetDivideCode_tEdit.Size = new Size(84, 24);
			//this.TargetDivideName_tEdit.Size = new Size(290, 24);
			////----- ueno upd---------- start   2007.11.21
			//this.GoodsCode_tEdit.Size = new Size(115, 24);
			//this.GoodsName_tEdit.Size = new Size(252, 24);
			//this.GoodsMakerCd_tNedit.Size = new Size(115, 24);
			//this.GoodsMakerCdNm_tEdit.Size = new Size(252, 24);
			////----- ueno upd---------- end   2007.11.21
			//this.SalesTargetMoney_tNedit.Size = new Size(131, 24);
			//this.SalesTargetProfit_tNedit.Size = new Size(131, 24);
			//this.SalesTargetCount_tNedit.Size = new Size(108, 24);
			//----- ueno del ---------- end 2008.03.05


			//----- ueno del---------- start 2007.11.21
			#region del
			//this.RatioSunday_tNedit.Size = new Size(84, 24);
			//this.RatioMonday_tNedit.Size = new Size(84, 24);
			//this.RatioTuesday_tNedit.Size = new Size(84, 24);
			//this.RatioWednesday_tNedit.Size = new Size(84, 24);
			//this.RatioThursday_tNedit.Size = new Size(84, 24);
			//this.RatioFriday_tNedit.Size = new Size(84, 24);
			//this.RatioSaturday_tNedit.Size = new Size(84, 24);
			//this.RatioHoliday_tNedit.Size = new Size(84, 24);
			//this.SalesTargetMoneySunday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetProfitSunday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetCountSunday_tNedit.Size = new Size(108, 24);
			//this.SalesTargetMoneyMonday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetProfitMonday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetCouｎtMonday_tNedit.Size = new Size(108, 24);
			//this.SalesTargetMoneyTuesday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetProfitTuesday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetCountTuesday_tNedit.Size = new Size(108, 24);
			//this.SalesTargetMoneyWednesday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetProfitWednesday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetCountWednesday_tNedit.Size = new Size(108, 24);
			//this.SalesTargetMoneyThursday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetProfitThursday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetCountThursday_tNedit.Size = new Size(108, 24);
			//this.SalesTargetMoneyFriday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetProfitFriday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetCountFriday_tNedit.Size = new Size(108, 24);
			//this.SalesTargetMoneySaturday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetProfitSaturday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetCountSaturday_tNedit.Size = new Size(108, 24);
			//this.SalesTargetMoneyHoliday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetProfitHoliday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetCountHoliday_tNedit.Size = new Size(108, 24);
			#endregion del
			//----- ueno del---------- end   2007.11.21
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Neditスタイル設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: Neditのスタイルを設定します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.12</br>
		/// </remarks>
		private void SetNeditStyle()
		{
            this.SalesTargetCount_tNedit.NumEdit.DecLen = 1;

			this.SalesTargetMoney_tNedit.NumEdit.CommaEdit = true;
			this.SalesTargetProfit_tNedit.NumEdit.CommaEdit = true;
			this.SalesTargetCount_tNedit.NumEdit.CommaEdit = true;
			this.SalesTargetMoney_tNedit.NumEdit.MinusSupp = true;
			this.SalesTargetProfit_tNedit.NumEdit.MinusSupp = true;
			this.SalesTargetCount_tNedit.NumEdit.MinusSupp = true;
            this.SalesTargetMoney_tNedit.ExtEdit.Column = 15;
            this.SalesTargetProfit_tNedit.ExtEdit.Column = 15;
            this.SalesTargetCount_tNedit.ExtEdit.Column = 10;

			//----- ueno del ---------- start 2008.03.05
            // 項目の最大入力可能桁数は画面デザインで設定する
			//this.TargetDivideCode_tEdit.MaxLength = 9;
			//this.TargetDivideName_tEdit.MaxLength = 30;
			//this.GoodsCode_tEdit.MaxLength = 15;
			//this.GoodsName_tEdit.MaxLength = 100;
			//----- ueno del ---------- end 2008.03.05
			
			//----- ueno del---------- start 2007.11.21
			#region del
			//this.GoodsMakerCdNm_tEdit.MaxLength = 30;
			//this.CarrierName_tEdit.MaxLength = 20;
            //this.CellphoneModelName_tEdit.MaxLength = 60;
			//this.RatioSunday_tNedit.ExtEdit.Column = 6;
			//this.RatioMonday_tNedit.ExtEdit.Column = 6;
			//this.RatioTuesday_tNedit.ExtEdit.Column = 6;
			//this.RatioWednesday_tNedit.ExtEdit.Column = 6;
			//this.RatioThursday_tNedit.ExtEdit.Column = 6;
			//this.RatioFriday_tNedit.ExtEdit.Column = 6;
			//this.RatioSaturday_tNedit.ExtEdit.Column = 6;
			//this.RatioHoliday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetMoneySunday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetProfitSunday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetCountSunday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetMoneyMonday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetProfitMonday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetCouｎtMonday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetMoneyTuesday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetProfitTuesday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetCountTuesday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetMoneyWednesday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetProfitWednesday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetCountWednesday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetMoneyThursday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetProfitThursday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetCountThursday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetMoneyFriday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetProfitFriday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetCountFriday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetMoneySaturday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetProfitSaturday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetCountSaturday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetMoneyHoliday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetProfitHoliday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetCountHoliday_tNedit.ExtEdit.Column = 6;

			//this.RatioSunday_tNedit.NumEdit.DecLen = 2;
			//this.RatioMonday_tNedit.NumEdit.DecLen = 2;
			//this.RatioTuesday_tNedit.NumEdit.DecLen = 2;
			//this.RatioWednesday_tNedit.NumEdit.DecLen = 2;
			//this.RatioThursday_tNedit.NumEdit.DecLen = 2;
			//this.RatioFriday_tNedit.NumEdit.DecLen = 2;
			//this.RatioSaturday_tNedit.NumEdit.DecLen = 2;
			//this.RatioHoliday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetMoneySunday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetProfitSunday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetCountSunday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetMoneyMonday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetProfitMonday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetCouｎtMonday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetMoneyTuesday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetProfitTuesday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetCountTuesday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetMoneyWednesday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetProfitWednesday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetCountWednesday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetMoneyThursday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetProfitThursday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetCountThursday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetMoneyFriday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetProfitFriday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetCountFriday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetMoneySaturday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetProfitSaturday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetCountSaturday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetMoneyHoliday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetProfitHoliday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetCountHoliday_tNedit.NumEdit.DecLen = 2;

			//this.RatioSunday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.RatioMonday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.RatioTuesday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.RatioWednesday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.RatioThursday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.RatioFriday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.RatioSaturday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.RatioHoliday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetMoneySunday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetProfitSunday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetCountSunday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetMoneyMonday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetProfitMonday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetCouｎtMonday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetMoneyTuesday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetProfitTuesday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetCountTuesday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetMoneyWednesday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetProfitWednesday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetCountWednesday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetMoneyThursday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetProfitThursday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetCountThursday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetMoneyFriday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetProfitFriday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetCountFriday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetMoneySaturday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetProfitSaturday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetCountSaturday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetMoneyHoliday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetProfitHoliday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetCountHoliday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;

			//this.RatioSunday_tNedit.NumEdit.MinusSupp = true;
			//this.RatioMonday_tNedit.NumEdit.MinusSupp = true;
			//this.RatioTuesday_tNedit.NumEdit.MinusSupp = true;
			//this.RatioWednesday_tNedit.NumEdit.MinusSupp = true;
			//this.RatioThursday_tNedit.NumEdit.MinusSupp = true;
			//this.RatioFriday_tNedit.NumEdit.MinusSupp = true;
			//this.RatioSaturday_tNedit.NumEdit.MinusSupp = true;
			//this.RatioHoliday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetMoneySunday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetProfitSunday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetCountSunday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetMoneyMonday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetProfitMonday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetCouｎtMonday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetMoneyTuesday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetProfitTuesday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetCountTuesday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetMoneyWednesday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetProfitWednesday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetCountWednesday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetMoneyThursday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetProfitThursday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetCountThursday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetMoneyFriday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetProfitFriday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetCountFriday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetMoneySaturday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetProfitSaturday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetCountSaturday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetMoneyHoliday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetProfitHoliday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetCountHoliday_tNedit.NumEdit.MinusSupp = true;

			//this.RatioSunday_tNedit.NumEdit.ZeroDisp = true;
			//this.RatioMonday_tNedit.NumEdit.ZeroDisp = true;
			//this.RatioTuesday_tNedit.NumEdit.ZeroDisp = true;
			//this.RatioWednesday_tNedit.NumEdit.ZeroDisp = true;
			//this.RatioThursday_tNedit.NumEdit.ZeroDisp = true;
			//this.RatioFriday_tNedit.NumEdit.ZeroDisp = true;
			//this.RatioSaturday_tNedit.NumEdit.ZeroDisp = true;
			//this.RatioHoliday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetMoneySunday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetProfitSunday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetCountSunday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetMoneyMonday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetProfitMonday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetCouｎtMonday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetMoneyTuesday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetProfitTuesday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetCountTuesday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetMoneyWednesday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetProfitWednesday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetCountWednesday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetMoneyThursday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetProfitThursday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetCountThursday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetMoneyFriday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetProfitFriday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetCountFriday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetMoneySaturday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetProfitSaturday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetCountSaturday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetMoneyHoliday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetProfitHoliday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetCountHoliday_tNedit.NumEdit.ZeroDisp = true;

			//this.SalesTargetMoneySunday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetProfitSunday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetCountSunday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetMoneyMonday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetProfitMonday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetCouｎtMonday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetMoneyTuesday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetProfitTuesday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetCountTuesday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetMoneyWednesday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetProfitWednesday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetCountWednesday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetMoneyThursday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetProfitThursday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetCountThursday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetMoneyFriday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetProfitFriday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetCountFriday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetMoneySaturday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetProfitSaturday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetCountSaturday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetMoneyHoliday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetProfitHoliday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetCountHoliday_tNedit.NumEdit.CommaEdit = true;
			#endregion del
			//----- ueno del---------- end   2007.11.21
		}

		//----- ueno del---------- start 2007.11.21
		#region del
		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// 画面初期化処理
		///// </summary>
		///// <remarks>
		///// <br>Note		: 画面の初期化を行います。</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.07.23</br>
		///// </remarks>
		//private void ClearRatioControl()
		//{
		//    this.SalesTargetMoneySunday_tNedit.DataText = "";
		//    this.SalesTargetProfitSunday_tNedit.DataText = "";
		//    this.SalesTargetCountSunday_tNedit.DataText = "";
		//    this.SalesTargetMoneyMonday_tNedit.DataText = "";
		//    this.SalesTargetProfitMonday_tNedit.DataText = "";
		//    this.SalesTargetCouｎtMonday_tNedit.DataText = "";
		//    this.SalesTargetMoneyTuesday_tNedit.DataText = "";
		//    this.SalesTargetProfitTuesday_tNedit.DataText = "";
		//    this.SalesTargetCountTuesday_tNedit.DataText = "";
		//    this.SalesTargetMoneyWednesday_tNedit.DataText = "";
		//    this.SalesTargetProfitWednesday_tNedit.DataText = "";
		//    this.SalesTargetCountWednesday_tNedit.DataText = "";
		//    this.SalesTargetMoneyThursday_tNedit.DataText = "";
		//    this.SalesTargetProfitThursday_tNedit.DataText = "";
		//    this.SalesTargetCountThursday_tNedit.DataText = "";
		//    this.SalesTargetMoneyFriday_tNedit.DataText = "";
		//    this.SalesTargetProfitFriday_tNedit.DataText = "";
		//    this.SalesTargetCountFriday_tNedit.DataText = "";
		//    this.SalesTargetMoneySaturday_tNedit.DataText = "";
		//    this.SalesTargetProfitSaturday_tNedit.DataText = "";
		//    this.SalesTargetCountSaturday_tNedit.DataText = "";
		//    this.SalesTargetMoneyHoliday_tNedit.DataText = "";
		//    this.SalesTargetProfitHoliday_tNedit.DataText = "";
		//    this.SalesTargetCountHoliday_tNedit.DataText = "";
		//}
        #endregion del
		//----- ueno del---------- end   2007.11.21

//----- ueno add---------- start 2007.11.21

		/// <summary>
		/// 検索タイプ取得処理
		/// </summary>
		/// <param name="inputCode">入力されたコード</param>
		/// <param name="searchCode">検索用コード（*を除く）</param>
		/// <returns>0:完全一致検索 1:前方一致検索 2:後方一致検索 3:曖昧検索</returns>
		/// <remarks>
		/// Note			:	検索する方法を取得する処理を行います。<br />
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		public int GetSearchType(string inputCode, out string searchCode)
		{
			searchCode = inputCode;
			if (String.IsNullOrEmpty(inputCode)) return 0;

			if (inputCode.Contains("*"))
			{
				searchCode = inputCode.Replace("*", "");
				string firstString = inputCode.Substring(0, 1);
				string lastString = inputCode.Substring(inputCode.Length - 1, 1);

				if ((firstString == "*") && (lastString == "*"))
				{
					return 3;
				}
				else if (firstString == "*")
				{
					return 2;
				}
				else if (lastString == "*")
				{
					return 1;
				}
				else
				{
					return 3;
				}
			}
			else
			{
				// *が存在しないため完全一致検索
				return 0;
			}
		}

		/// <summary>
		/// 商品メーカーコードガイド起動処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 商品メーカーコードガイドを起動します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		private void GoodsNoGuide(TNedit goodsMakerCd_tNedit)
		{
			MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();
			GoodsUnitData goodsUnitData = null;
			GoodsCndtn goodsCndtn = new GoodsCndtn();
			goodsCndtn.EnterpriseCode = this._enterpriseCode;

			//----- ueno add ---------- start 2008.03.05
			bool autoSearch = false;
			//----- ueno add ---------- end 2008.03.05			

			//------------------
			// 商品コードガイド
			//------------------
			if (goodsMakerCd_tNedit.Text != "")
			{
				// メーカーコード設定
				goodsCndtn.GoodsMakerCd = goodsMakerCd_tNedit.GetInt();

				//----- ueno add ---------- start 2008.03.05
				// メーカー名称設定
				goodsCndtn.MakerName = GoodsMakerCdNm_tEdit.Text.TrimEnd();
				autoSearch = true;
				//----- ueno add ---------- end 2008.03.05
			}

			//----- ueno upd ---------- start 2008.03.05
			// 自動検索はメーカーコードが存在する場合のみとする
			DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, autoSearch, goodsCndtn, out goodsUnitData);
			//DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, true, goodsCndtn, out goodsUnitData);
			//----- ueno upd ---------- end 2008.03.05

			if ((dialogResult == DialogResult.OK) && (goodsUnitData != null))
			{
				this.GoodsCode_tEdit.DataText = goodsUnitData.GoodsNo;
				this.GoodsName_tEdit.DataText = goodsUnitData.GoodsName;

				// 現在データ保存
				this._goodsCodeWork = this.GoodsCode_tEdit.DataText;

				//--------------------------------------
				// 商品コードに対するメーカーコード設定
				//--------------------------------------
				MakerUMnt makerUMnt = null;
				GoodsAcs goodsAcs = new GoodsAcs();

				// データ存在チェック
				int ret = goodsAcs.GetMaker(this._enterpriseCode, goodsUnitData.GoodsMakerCd, out makerUMnt);

				if (ret == 0)
				{
					// メーカーコードも設定
					this.GoodsMakerCd_tNedit.SetInt(goodsUnitData.GoodsMakerCd);
					this.GoodsMakerCdNm_tEdit.Text = makerUMnt.MakerName;

					// 現在データ保存
					this._goodsMakerCdWork = this.GoodsMakerCd_tNedit.GetInt();
				}
			}
		}

		/// <summary>
		/// 目標対比区分変更
		/// </summary>
		/// <param name="targetContrastCd">目標対比区分</param>
		/// <remarks>
		/// <br>Note　     : 目標対比区分の選択を変更したときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.31</br>
		/// </remarks>
		private void TargetContrastCdChange(int targetContrastCd)
		{
			if (this._targetContrastCd_tComboEditorValue == targetContrastCd) return;

			switch (targetContrastCd)
			{
				case (int)SalesTarget.ConstrastCd.SecAndMaker:			// 40:拠点＋メーカー
					{
						this.GoodsMakerCd_tNedit.Enabled = true;		// メーカーコード
						this.GoodsMakerCdGuide_Button.Enabled = true;	// メーカーガイド
						this.GoodsCode_tEdit.Enabled = false;			// 商品コード
						this.GoodsCodeGuide_Button.Enabled = false;		// 商品ガイド

                        this.BLGroupCode_tNedit.Enabled = false;        // BLグループ
                        this.BLGroupGuide_ultraButton.Enabled = false;  // BLグループガイド
                        this.BLCode_tNedit.Enabled = false;             // BLコード
                        this.BLCodeGuide_ultraButton.Enabled = false;   // BLコードガイド
                        this.SalesTypeCode_tNedit.Enabled = false;      // 販売区分
                        this.SalesTypeGuide_ultraButton.Enabled = false;// 販売区分ガイド
                        this.ItemTypeCode_tNedit.Enabled = false;       // 商品区分
                        this.ItemTypeGuide_ultraButton.Enabled = false; // 商品区分ガイド
						
						// 入力不可項目クリア
						this.GoodsCode_tEdit.Clear();
						this.GoodsName_tEdit.Clear();

                        this.BLGroupCode_tNedit.Clear();
                        this.BLGroupName_tEdit.Clear();
                        this.BLCode_tNedit.Clear();
                        this.BLCodeName_tEdit.Clear();
                        this.SalesTypeCode_tNedit.Clear();
                        this.SalesTypeName_tEdit.Clear();
                        this.ItemTypeCode_tNedit.Clear();
                        this.ItemTypeName_tEdit.Clear();
						break;
					}
				case (int)SalesTarget.ConstrastCd.SecAndMakerAndGoods:	// 41:拠点＋メーカー＋商品
					{
						this.GoodsMakerCd_tNedit.Enabled = true;		// メーカーコード
						this.GoodsMakerCdGuide_Button.Enabled = true;	// メーカーガイド
						this.GoodsCode_tEdit.Enabled = true;			// 商品コード
						this.GoodsCodeGuide_Button.Enabled = true;		// 商品ガイド

                        this.BLGroupCode_tNedit.Enabled = false;        // BLグループ
                        this.BLGroupGuide_ultraButton.Enabled = false;  // BLグループガイド
                        this.BLCode_tNedit.Enabled = false;             // BLコード
                        this.BLCodeGuide_ultraButton.Enabled = false;   // BLコードガイド
                        this.SalesTypeCode_tNedit.Enabled = false;      // 販売区分
                        this.SalesTypeGuide_ultraButton.Enabled = false;// 販売区分ガイド
                        this.ItemTypeCode_tNedit.Enabled = false;       // 商品区分
                        this.ItemTypeGuide_ultraButton.Enabled = false; // 商品区分ガイド

                        // 入力付加項目クリア
                        this.BLGroupCode_tNedit.Clear();
                        this.BLGroupName_tEdit.Clear();
                        this.BLCode_tNedit.Clear();
                        this.BLCodeName_tEdit.Clear();
                        this.SalesTypeCode_tNedit.Clear();
                        this.SalesTypeName_tEdit.Clear();
                        this.ItemTypeCode_tNedit.Clear();
                        this.ItemTypeName_tEdit.Clear();

						break;
					}
                case (int)SalesTarget.ConstrastCd.SecAndBLGroup:        // 42:拠点＋BLグループ
                    {
                        // BLグループを使用可能に
                        this.BLGroupCode_tNedit.Enabled = true;         // BLグループ
                        this.BLGroupGuide_ultraButton.Enabled = true;   // BLグループガイド
                        // それ以外は使用不能に
                        this.BLCode_tNedit.Enabled = false;             // BLコード
                        this.BLCodeGuide_ultraButton.Enabled = false;   // BLコードガイド
                        this.SalesTypeCode_tNedit.Enabled = false;      // 販売区分
                        this.SalesTypeGuide_ultraButton.Enabled = false;// 販売区分ガイド
                        this.ItemTypeCode_tNedit.Enabled = false;       // 商品区分
                        this.ItemTypeGuide_ultraButton.Enabled = false; // 商品区分ガイド

                        this.GoodsMakerCd_tNedit.Enabled = false;		// メーカーコード
                        this.GoodsMakerCdGuide_Button.Enabled = false;	// メーカーガイド
                        this.GoodsCode_tEdit.Enabled = false;			// 商品コード
                        this.GoodsCodeGuide_Button.Enabled = false;		// 商品ガイド

                        // 入力不可項目クリア
                        this.BLCode_tNedit.Clear();
                        this.BLCodeName_tEdit.Clear();
                        this.SalesTypeCode_tNedit.Clear();
                        this.SalesTypeName_tEdit.Clear();
                        this.ItemTypeCode_tNedit.Clear();
                        this.ItemTypeName_tEdit.Clear();

                        this.GoodsMakerCd_tNedit.Clear();
                        this.GoodsMakerCdNm_tEdit.Clear();
                        this.GoodsCode_tEdit.Clear();
                        this.GoodsName_tEdit.Clear();
                        break;
                    }
                case (int)SalesTarget.ConstrastCd.SecAndBlCode:         // 43:拠点＋BLコード
                    {
                        // BLコードを使用可能に
                        this.BLCode_tNedit.Enabled = true;              // BLコード
                        this.BLCodeGuide_ultraButton.Enabled = true;    // BLコードガイド
                        // それ以外は使用不能に
                        this.BLGroupCode_tNedit.Enabled = false;        // BLグループ
                        this.BLGroupGuide_ultraButton.Enabled = false;  // BLグループガイド
                        this.SalesTypeCode_tNedit.Enabled = false;      // 販売区分
                        this.SalesTypeGuide_ultraButton.Enabled = false;// 販売区分ガイド
                        this.ItemTypeCode_tNedit.Enabled = false;       // 商品区分
                        this.ItemTypeGuide_ultraButton.Enabled = false; // 商品区分ガイド

                        this.GoodsMakerCd_tNedit.Enabled = false;		// メーカーコード
                        this.GoodsMakerCdGuide_Button.Enabled = false;	// メーカーガイド
                        this.GoodsCode_tEdit.Enabled = false;			// 商品コード
                        this.GoodsCodeGuide_Button.Enabled = false;		// 商品ガイド

                        // 入力不可項目クリア
                        this.BLGroupCode_tNedit.Clear();
                        this.BLGroupName_tEdit.Clear();
                        this.SalesTypeCode_tNedit.Clear();
                        this.SalesTypeName_tEdit.Clear();
                        this.ItemTypeCode_tNedit.Clear();
                        this.ItemTypeName_tEdit.Clear();

                        this.GoodsMakerCd_tNedit.Clear();
                        this.GoodsMakerCdNm_tEdit.Clear();
                        this.GoodsCode_tEdit.Clear();
                        this.GoodsName_tEdit.Clear();
                        break;
                    }
                case (int)SalesTarget.ConstrastCd.SecAndSalesType:      // 44:拠点＋販売区分
                    {
                        // 販売区分を使用可能に
                        this.SalesTypeCode_tNedit.Enabled = true;       // 販売区分
                        this.SalesTypeGuide_ultraButton.Enabled = true; // 販売区分ガイド
                        // それ以外は使用不能に
                        this.BLGroupCode_tNedit.Enabled = false;        // BLグループ
                        this.BLGroupGuide_ultraButton.Enabled = false;  // BLグループガイド
                        this.BLCode_tNedit.Enabled = false;             // BLコード
                        this.BLCodeGuide_ultraButton.Enabled = false;   // BLコードガイド
                        this.ItemTypeCode_tNedit.Enabled = false;       // 商品区分
                        this.ItemTypeGuide_ultraButton.Enabled = false; // 商品区分ガイド

                        this.GoodsMakerCd_tNedit.Enabled = false;		// メーカーコード
                        this.GoodsMakerCdGuide_Button.Enabled = false;	// メーカーガイド
                        this.GoodsCode_tEdit.Enabled = false;			// 商品コード
                        this.GoodsCodeGuide_Button.Enabled = false;		// 商品ガイド

                        // 入力不可項目クリア
                        this.BLGroupCode_tNedit.Clear();
                        this.BLGroupName_tEdit.Clear();
                        this.BLCode_tNedit.Clear();
                        this.BLCodeName_tEdit.Clear();
                        this.ItemTypeCode_tNedit.Clear();
                        this.ItemTypeName_tEdit.Clear();

                        this.GoodsMakerCd_tNedit.Clear();
                        this.GoodsMakerCdNm_tEdit.Clear();
                        this.GoodsCode_tEdit.Clear();
                        this.GoodsName_tEdit.Clear();
                        break;
                    }
                case (int)SalesTarget.ConstrastCd.SecAndItemType:       // 45:拠点＋商品区分
                    {
                        // 商品区分を使用可能に
                        this.ItemTypeCode_tNedit.Enabled = true;        // 商品区分
                        this.ItemTypeGuide_ultraButton.Enabled = true;  // 商品区分ガイド
                        // それ以外は使用不能に
                        this.BLGroupCode_tNedit.Enabled = false;        // BLグループ
                        this.BLGroupGuide_ultraButton.Enabled = false;  // BLグループガイド
                        this.BLCode_tNedit.Enabled = false;             // BLコード
                        this.BLCodeGuide_ultraButton.Enabled = false;   // BLコードガイド
                        this.SalesTypeCode_tNedit.Enabled = false;      // 販売区分
                        this.SalesTypeGuide_ultraButton.Enabled = false;// 販売区分ガイド

                        this.GoodsMakerCd_tNedit.Enabled = false;		// メーカーコード
                        this.GoodsMakerCdGuide_Button.Enabled = false;	// メーカーガイド
                        this.GoodsCode_tEdit.Enabled = false;			// 商品コード
                        this.GoodsCodeGuide_Button.Enabled = false;		// 商品ガイド

                        // 入力不可項目クリア
                        this.BLGroupCode_tNedit.Clear();
                        this.BLGroupName_tEdit.Clear();
                        this.BLCode_tNedit.Clear();
                        this.BLCodeName_tEdit.Clear();
                        this.SalesTypeCode_tNedit.Clear();
                        this.SalesTypeName_tEdit.Clear();

                        this.GoodsMakerCd_tNedit.Clear();
                        this.GoodsMakerCdNm_tEdit.Clear();
                        this.GoodsCode_tEdit.Clear();
                        this.GoodsName_tEdit.Clear();
                        break;
                    }
			}
			// 選択した番号を保持
			this._targetContrastCd_tComboEditorValue = targetContrastCd;
		}

//----- ueno add---------- end   2007.11.21

		//----- ueno add---------- start 2008.03.05
		#region メーカーコードエラーチェック処理
		/// <summary>
		/// メーカーコードエラーチェック処理
		/// </summary>
		/// <param name="inParamObj">条件オブジェクト</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
		/// <remarks>
		/// <br>Note       : メーカーコードのエラーチェックを行います。
		///					 条件オブジェクト:メーカーコード
		///					 結果オブジェクト:メーカーマスタ検索結果ステータス, メーカー名称</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.03.05</br>
		/// </remarks>
		private int CheckGoodsMakerCd(object inParamObj, out object outParamObj)
		{
			outParamObj = null;
			ArrayList outParamList = new ArrayList();
			int ret = (int)InputChkStatus.NotInput;
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			try
			{
				//------------------
				// 必須入力チェック
				//------------------
				if (inParamObj == null) return ret;
				if ((inParamObj is int) == false) return ret;
				if ((int)inParamObj == 0) return ret;

				//--------------
				// 存在チェック
				//--------------
				MakerUMnt makerUMnt = null;

				this.Cursor = Cursors.WaitCursor;
				status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, (int)inParamObj);
				this.Cursor = Cursors.Default;

				outParamList.Add(status);	// メーカーマスタステータス設定

				if (makerUMnt == null)
				{
					ret = (int)InputChkStatus.NotExist;
				}
				else
				{
					ret = (int)InputChkStatus.Normal;
					outParamList.Add(makerUMnt.MakerName);	// メーカー名称設定
				}
			}
			catch (Exception)
			{
			}
			outParamObj = outParamList;

			return ret;
		}
		#endregion メーカーコードエラーチェック処理

		#region 商品コードエラーチェック処理
		/// <summary>
		/// 商品コードエラーチェック処理
		/// </summary>
		/// <param name="inParamObj">条件オブジェクト</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
		/// <remarks>
		/// <br>Note       : 商品コードのエラーチェックを行います。
		///					 条件オブジェクト:メーカーコード, 商品コード
		///					 結果オブジェクト:商品マスタ検索結果ステータス, 商品コード, 商品名称, メーカーコード, メーカー名称</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.03.05</br>
		/// </remarks>
		private int CheckGoodsNoCd(object inParamObj, out object outParamObj)
		{
			outParamObj = null;
			ArrayList outParamList = new ArrayList();
			int ret = (int)InputChkStatus.NotInput;
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			ArrayList inParamList = null;

			try
			{
				//------------------
				// 必須入力チェック
				//------------------
				if (inParamObj == null) return ret;
				if ((inParamObj is ArrayList) == false) return ret;

				inParamList = inParamObj as ArrayList;	// ArrayListへキャスト

				if ((inParamList == null) || (inParamList.Count != 2)) return ret;
				if ((inParamList[0] is int) == false) return ret;
				if ((inParamList[1] is string) == false) return ret;
				if ((string)inParamList[1] == "") return ret;

				//--------------
				// 存在チェック
				//--------------
				List<GoodsUnitData> goodsUnitDataList = null;

				// 検索の種類を取得
				string searchCode;
				int searchType = GetSearchType((string)inParamList[1], out searchCode);

				MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();
				GoodsCndtn goodsCndtn = new GoodsCndtn();

				// 商品検索条件設定
				goodsCndtn.EnterpriseCode = this._enterpriseCode;
				goodsCndtn.SectionCode = this._sectionCode;
				goodsCndtn.GoodsMakerCd = this.GoodsMakerCd_tNedit.GetInt();
				goodsCndtn.MakerName = this.GoodsMakerCdNm_tEdit.Text;
				goodsCndtn.GoodsNo = searchCode.TrimEnd();
				goodsCndtn.GoodsNoSrchTyp = searchType;

				string message;
				this.Cursor = Cursors.WaitCursor;
				// 読み込み
				status = goodsSelectGuide.ReadGoods(this, false, goodsCndtn, out goodsUnitDataList, out message);
				this.Cursor = Cursors.Default;

				outParamList.Add(status);	// 商品マスタステータス設定

				if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
				{
					// 商品マスタデータクラス
					GoodsUnitData goodsUnitData = new GoodsUnitData();
					goodsUnitData = goodsUnitDataList[0];

					outParamList.Add(goodsUnitData.GoodsNo);		// 商品コード
					outParamList.Add(goodsUnitData.GoodsName);		// 商品名称設定
					outParamList.Add(goodsUnitData.GoodsMakerCd);	// メーカーコード設定
					outParamList.Add(goodsUnitData.MakerName);		// メーカー名称設定

					ret = (int)InputChkStatus.Normal;
				}
				else if (status == -1)
				{
					// 選択ダイアログでキャンセル
					ret = (int)InputChkStatus.Cancel;
				}
				else
				{
					ret = (int)InputChkStatus.NotExist;
				}
			}
			catch (Exception)
			{
			}
			outParamObj = outParamList;

			return ret;
		}
		#endregion 商品コードエラーチェック処理

		#region メーカーコード設定処理
		/// <summary>
		/// メーカーコード設定処理
		/// </summary>
		/// <param name="dispSetStatus">入力チェックフラグ</param>
		/// <param name="canChangeFocus">フォーカスフラグ</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <remarks>
		/// <br>Note       : メーカーコード（単品）を画面に設定します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.03.05</br>
		/// </remarks>
		private void DispSetGoodsMakerCd(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
		{
			ArrayList outParamList = null;

			try
			{
				switch (dispSetStatus)
				{
					case DispSetStatus.Clear:	// データクリア
						{
							this.GoodsMakerCd_tNedit.Clear();
							this.GoodsMakerCdNm_tEdit.Clear();

							// 現在データクリア
							this._goodsMakerCdWork = 0;

							// 商品コードクリア
							this.GoodsCode_tEdit.Clear();
							this.GoodsName_tEdit.Clear();
							this._goodsCodeWork = "";

							//----- ueno upd ---------- start 2008.03.07
							// フォーカス
							canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
							//----- ueno upd ---------- end 2008.03.07

							break;
						}
					case DispSetStatus.Back:		// 元に戻す
						{
							this.GoodsMakerCd_tNedit.SetInt(this._goodsMakerCdWork);

							//----- ueno add ---------- start 2008.03.07
							// フォーカス移動しない
							canChangeFocus = false;
							//----- ueno add ---------- end 2008.03.07
							break;
						}
					case DispSetStatus.Update:	// 更新
						{
							if ((outParamObj != null) && (outParamObj is ArrayList))
							{
								outParamList = outParamObj as ArrayList;

								if ((outParamList != null)
									&& (outParamList.Count == 2)
									&& (outParamList[1] is string))
								{
									this.GoodsMakerCdNm_tEdit.Text = (string)outParamList[1];	// メーカー名称

									//----------------------------
									// メーカーコード変更チェック
									//----------------------------
									if (this._goodsMakerCdWork != this.GoodsMakerCd_tNedit.GetInt())
									{
										// メーカーコード変更時は、商品コードクリア
										this.GoodsCode_tEdit.Clear();
										this.GoodsName_tEdit.Clear();
										this._goodsCodeWork = "";
									}

									// 現在データ保存
									this._goodsMakerCdWork = this.GoodsMakerCd_tNedit.GetInt();
								}
							}
							break;
						}
				}
			}
			catch (Exception)
			{
			}
		}
		#endregion メーカーコード設定処理

		#region 商品コード設定処理
		/// <summary>
		/// 商品コード設定処理
		/// </summary>
		/// <param name="dispSetStatus">入力チェックフラグ</param>
		/// <param name="canChangeFocus">フォーカスフラグ</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 商品コードを画面に設定します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.03.05</br>
		/// </remarks>
		private void DispSetGoodsNoCd(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
		{
			ArrayList outParamList = null;

			try
			{
				switch (dispSetStatus)
				{
					case DispSetStatus.Clear:	// データクリア
						{
							this.GoodsCode_tEdit.Clear();
							this.GoodsName_tEdit.Clear();

							// 現在データクリア
							this._goodsCodeWork = "";

							//----- ueno upd ---------- start 2008.03.07
							// フォーカス
							canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
							//----- ueno upd ---------- end 2008.03.07

							break;
						}
					case DispSetStatus.Back:		// 元に戻す
						{
							this.GoodsCode_tEdit.DataText = this._goodsCodeWork;

							//----- ueno add ---------- start 2008.03.07
							// フォーカス移動しない
							canChangeFocus = false;
							//----- ueno add ---------- end 2008.03.07
							break;
						}
					case DispSetStatus.Update:	// 更新
						{
							if ((outParamObj != null) && (outParamObj is ArrayList))
							{
								outParamList = outParamObj as ArrayList;

								if ((outParamList != null)
									&& (outParamList.Count == 5)
									&& (outParamList[1] is string)
									&& (outParamList[2] is string)
									&& (outParamList[3] is int)
									&& (outParamList[4] is string))
								{
									this.GoodsCode_tEdit.Text = (string)outParamList[1];		// 商品コード
									this.GoodsName_tEdit.Text = (string)outParamList[2];		// 商品名称
									this.GoodsMakerCd_tNedit.SetInt((int)outParamList[3]);		// メーカーコード
									this.GoodsMakerCdNm_tEdit.Text = (string)outParamList[4];	// メーカー名称

									// 現在データ保存
									this._goodsCodeWork = this.GoodsCode_tEdit.DataText;
									this._goodsMakerCdWork = this.GoodsMakerCd_tNedit.GetInt();
								}
							}
							break;
						}
				}
			}
			catch (Exception)
			{
			}
		}
		#endregion 商品コード設定処理

		#region データ無しエラーメッセージ出力処理
		/// <summary>
		/// データ無しエラーメッセージ出力処理
		/// </summary>
		/// <param name="errMsg">エラー発生箇所</param>
		/// <returns>作成されたエラーメッセージ</returns>
		/// <remarks>
		/// <br>Note       : データ無しのエラーメッセージを出力します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.03.05</br>
		/// </remarks>
		private string ShowNotFoundErrMsg(string errMsg)
		{
			_stringBuilder.Remove(0, _stringBuilder.Length);
			_stringBuilder.Append("指定された条件で、");
			_stringBuilder.Append(errMsg);
			_stringBuilder.Append("は存在しませんでした。");
			errMsg = _stringBuilder.ToString();
			
			return errMsg;
		}
		#endregion データ無しエラーメッセージ出力処理

		//----- ueno add---------- end 2008.03.05

		# endregion Private Methods

		# region Control Events

//----- ueno add---------- start   2007.11.21

		/// <summary>Control.ChangeFocus イベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : フォーカス移動時に発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
			if ((e.PrevCtrl == null) || (e.NextCtrl == null)) return;

			//----- ueno add---------- start 2008.03.05
			//InputChk inputChk = InputChk.None;
			
			bool canChangeFocus = true;
			DispSetStatus dispSetStatus = DispSetStatus.Clear;
			
			object inParamObj = null;
			object outParamObj = null;
			ArrayList inParamList = new ArrayList();
			//----- ueno add---------- end 2008.03.05
			
			switch(e.PrevCtrl.Name)
			{
				#region case 目標設定区分
				case "TargetContrastCd_tComboEditor":
					{
						if (this.TargetContrastCd_tComboEditor.Value != null)
						{
							TargetContrastCdChange((Int32)this.TargetContrastCd_tComboEditor.Value);
						}
						break;
					}
				#endregion
			
				#region case メーカーコード（単品）
				case "GoodsMakerCd_tNedit":
					{
						// 変更が無ければ処理しない
						if (this.GoodsMakerCd_tNedit.GetInt() == this._goodsMakerCdWork)
						{
							break;
						}

						//--------------
						// 存在チェック
						//--------------
						//----- ueno add ---------- start 2008.03.05
						// 条件設定
						inParamObj = this.GoodsMakerCd_tNedit.GetInt();

						// 存在チェック
						switch (CheckGoodsMakerCd(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
								{
									dispSetStatus = DispSetStatus.Update;
									break;
								}
							case (int)InputChkStatus.NotInput:
								{
									dispSetStatus = DispSetStatus.Clear;
									break;
								}
							default:
								{
									TMsgDisp.Show(
											this, 									// 親ウィンドウフォーム
											emErrorLevel.ERR_LEVEL_INFO, 			// エラーレベル
											this.Name,								// アセンブリID
											ShowNotFoundErrMsg("メーカーコード"), 	// 表示するメッセージ
											0,										// ステータス値
											MessageBoxButtons.OK);					// 表示するボタン
									
									dispSetStatus = this._goodsMakerCdWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// データ設定
						DispSetGoodsMakerCd(dispSetStatus,  ref canChangeFocus, outParamObj);
						//----- ueno add ---------- end 2008.03.05

						#region del 2008.03.05
						//----- ueno del ---------- start 2008.03.05
						//MakerUMnt makerUMnt = null;
						//if (this.GoodsMakerCd_tNedit.DataText != "")
						//{
						//    MakerAcs makerAcs = new MakerAcs();

						//    // データ存在チェック
						//    this.Cursor = Cursors.WaitCursor;
						//    int ret = makerAcs.Read(out makerUMnt, this._enterpriseCode, this.GoodsMakerCd_tNedit.GetInt());
						//    this.Cursor = Cursors.Default;

						//    if (ret != 0)
						//    {
						//        string errMessage = "指定された条件で、メーカーコードは存在しませんでした。";
						//        TMsgDisp.Show(
						//                this, 							// 親ウィンドウフォーム
						//                emErrorLevel.ERR_LEVEL_INFO, 	// エラーレベル
						//                this.Name,						// アセンブリID
						//                errMessage, 					// 表示するメッセージ
						//                0,								// ステータス値
						//                MessageBoxButtons.OK);			// 表示するボタン

						//        inputChk = this._goodsMakerCdWork == 0 ? InputChk.None : InputChk.Back;
						//    }
						//    else
						//    {
						//        inputChk = InputChk.Update;
						//    }
						//}
						//else
						//{
						//    inputChk = InputChk.None;
						//}

						////----------
						//// 結果設定
						////----------
						//switch (inputChk)
						//{
						//    case InputChk.None:		// 未入力、または、存在しない
						//        {
						//            this.GoodsMakerCd_tNedit.Clear();
						//            this.GoodsMakerCdNm_tEdit.Clear();

						//            // 現在データクリア
						//            this._goodsMakerCdWork = 0;

						//            // フォーカス
						//            e.NextCtrl = e.PrevCtrl;
						//            break;
						//        }
						//    case InputChk.Back:		// 元に戻す
						//        {
						//            this.GoodsMakerCd_tNedit.SetInt(this._goodsMakerCdWork);
						//            break;
						//        }
						//    case InputChk.Update:	// 更新
						//        {
						//            this.GoodsMakerCdNm_tEdit.DataText = makerUMnt.MakerShortName;

						//            // 現在データ保存
						//            this._goodsMakerCdWork = this.GoodsMakerCd_tNedit.GetInt();

						//            // メーカーに紐づく商品コード, 商品名称クリア
						//            this.GoodsCode_tEdit.Clear();
						//            this.GoodsName_tEdit.Clear();
						//            this._goodsCodeWork = "";
						//            break;
						//        }
						//}
						//----- ueno del ---------- end 2008.03.05
						#endregion del 2008.03.05

						break;
					}
				#endregion

				#region case 商品コード
				case "GoodsCode_tEdit":
					{
						// 変更が無ければ処理しない
						if (string.Equals(this.GoodsCode_tEdit.DataText, this._goodsCodeWork) == true)
						{
							break;
						}

						//--------------
						// 存在チェック
						//--------------
						//----- ueno add ---------- start 2008.03.05
						// 条件設定
						inParamList.Add(this.GoodsMakerCd_tNedit.GetInt());
						inParamList.Add(this.GoodsCode_tEdit.Text);
						inParamObj = inParamList;

						// 存在チェック
						switch (CheckGoodsNoCd(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
								{
									dispSetStatus = DispSetStatus.Update;
									break;
								}
							case (int)InputChkStatus.NotInput:
								{
									dispSetStatus = DispSetStatus.Clear;
									break;
								}
							case (int)InputChkStatus.Cancel:
								{
									dispSetStatus = DispSetStatus.Clear;
									break;
								}
							default:
								{
									TMsgDisp.Show(
											this, 									// 親ウィンドウフォーム
											emErrorLevel.ERR_LEVEL_INFO, 			// エラーレベル
											this.Name,								// アセンブリID
											ShowNotFoundErrMsg("商品コード"), 		// 表示するメッセージ
											0,										// ステータス値
											MessageBoxButtons.OK);					// 表示するボタン

									dispSetStatus = this._goodsCodeWork == "" ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// データ設定
						DispSetGoodsNoCd(dispSetStatus,  ref canChangeFocus, outParamObj);
						break;
						//----- ueno add ---------- end 2008.03.05
						
						#region del 2008.03.05
						//----- ueno del ---------- start 2008.03.05
						//List<GoodsUnitData> goodsUnitDataList = null;
						//if (this.GoodsCode_tEdit.DataText != "")
						//{
						//    int ret = -1;

						//    // 検索の種類を取得
						//    string searchCode;
						//    int searchType = this.GetSearchType(this.GoodsCode_tEdit.DataText, out searchCode);

						//    // 通常検索
						//    if (searchType == 0)
						//    {
						//        this.Cursor = Cursors.WaitCursor;
						//        ret = this._goodsAcs.Read(this._enterpriseCode, searchCode, out goodsUnitDataList);
						//        this.Cursor = Cursors.Default;
						//    }
						//    // 曖昧検索
						//    else
						//    {
						//        MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

						//        string message;
						//        this.Cursor = Cursors.WaitCursor;
						//        int status = goodsSelectGuide.ReadGoods(this, this._enterpriseCode, searchType, searchCode, out goodsUnitDataList, out message);
						//        this.Cursor = Cursors.Default;

						//        if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
						//        {
						//            ret = 0;
						//        }
						//    }

						//    if ((goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
						//    {
						//        inputChk = InputChk.Update;
						//    }
						//    else
						//    {
						//        string errMessage = "指定された条件で、商品コードは存在しませんでした。";
						//        TMsgDisp.Show(
						//                this, 							// 親ウィンドウフォーム
						//                emErrorLevel.ERR_LEVEL_INFO, 	// エラーレベル
						//                this.Name,						// アセンブリID
						//                errMessage, 					// 表示するメッセージ
						//                0,								// ステータス値
						//                MessageBoxButtons.OK);			// 表示するボタン

						//        inputChk = this._goodsCodeWork == "" ? InputChk.None : InputChk.Back;
						//    }
						//}
						//else
						//{
						//    inputChk = InputChk.None;
						//}

						////----------
						//// 結果設定
						////----------
						//switch (inputChk)
						//{
						//    case InputChk.None:		// 未入力、または、存在しない
						//        {
						//            this.GoodsCode_tEdit.Clear();
						//            this.GoodsName_tEdit.Clear();

						//            // 現在データクリア
						//            this._goodsCodeWork = "";

						//            // フォーカス
						//            e.NextCtrl = e.PrevCtrl;
						//            break;
						//        }
						//    case InputChk.Back:		// 元に戻す
						//        {
						//            this.GoodsCode_tEdit.DataText = this._goodsCodeWork;
						//            break;
						//        }
						//    case InputChk.Update:	// 更新
						//        {
						//            if ((goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
						//            {
						//                // 商品マスタデータクラス
						//                GoodsUnitData wkGoodsUnitData = new GoodsUnitData();
						//                wkGoodsUnitData = goodsUnitDataList[0];

						//                this.GoodsCode_tEdit.DataText = wkGoodsUnitData.GoodsNo;			// 商品コード設定
						//                this.GoodsName_tEdit.DataText = wkGoodsUnitData.GoodsName;			// 商品名称設定
						//                this.GoodsMakerCd_tNedit.SetInt(wkGoodsUnitData.GoodsMakerCd);		// メーカーコード設定
						//                this.GoodsMakerCdNm_tEdit.DataText = wkGoodsUnitData.MakerName;		// メーカー名称設定

						//                // 現在データ保存
						//                this._goodsCodeWork = this.GoodsCode_tEdit.DataText;
						//                this._goodsMakerCdWork = this.GoodsMakerCd_tNedit.GetInt();
						//            }
						//            break;
						//        }
						//}
						//----- ueno del ---------- end 2008.03.05
						#endregion del 2008.03.05
					}
				#endregion
			}

			//----- ueno add ---------- start 2008.03.05
			// フォーカス制御
			if (canChangeFocus == false)
			{
				e.NextCtrl = e.PrevCtrl;

				//----- ueno add ---------- start 2008.03.07
				// 現在の項目から移動せず、テキスト全選択状態とする
				e.NextCtrl.Select();
				//----- ueno add ---------- end 2008.03.07
			}
			//----- ueno add ---------- end 2008.03.05
		}
//----- ueno add---------- end   2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Form_Load イベント処理(MAMOK09130U)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: フォームロード処理を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		private void MAMOK09130UA_Load(object sender, EventArgs e)
		{
			// 画面スキンファイルの読込(デフォルトスキン指定)
			this._controlScreenSkin.LoadSkin();

			// 画面スキン変更
			this._controlScreenSkin.SettingScreenSkin(this);

			// コントロールサイズ設定
			SetControlSize();

			// Neditスタイル設定
			SetNeditStyle();

//----- ueno add---------- start 2007.11.21
			// 目標対比区分コンボボックス設定
			this.TargetContrastCd_tComboEditor.Items.Clear();
			
			if (SalesTarget._targetContrastCdGoodsSList.Count > 0)
			{
				foreach (DictionaryEntry de in SalesTarget._targetContrastCdGoodsSList)
				{
					this.TargetContrastCd_tComboEditor.Items.Add(de.Key, de.Value.ToString());
				}
				this.TargetContrastCd_tComboEditor.Value = SalesTarget._targetContrastCdGoodsSList.GetKey(0);
			}
//----- ueno add---------- end   2007.11.21

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA ADD START
            // 拠点名称取得
            SecInfoSet secInfoSet;
            //SecInfoAcs secInfoAcs = new SecInfoAcs();
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();

            // 拠点名称を受け取ったsalesTargetオブジェクトの拠点コードから取得
            this._sectionCode = this._salesTarget.SectionCode;

            //----- ueno add---------- start 2008.03.05
            // 拠点コード取得
            //this._sectionCode = secInfoSet.SectionCode.TrimEnd();
            //----- ueno add---------- end 2008.03.05

            int status = secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, _sectionCode);

            if (secInfoSet != null)
            {
                this._sectionName = secInfoSet.SectionGuideNm.TrimEnd();
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA ADD END

            // 目標データ画面展開
            SalesTargetToScreen(this._salesTarget);

            // 目標設定区分
            this._targetSetCd = this._salesTarget.TargetSetCd;

			//----- ueno del---------- start 2007.11.21
			//// マスタ読み込み
			//bool result = LoadMasterTable();
			//if (!result)
			//{
			//    this.Close();
			//    return;
			//}

			//// 曜日別比率表示
			//DispRatioDayOfWeek();
			//----- ueno del---------- end   2007.11.21

            // 目標対比区分の値により入力できる項目を制御
            // 起動時は使用不能に
            this.SalesTypeCode_tNedit.Enabled = false;      // 販売区分
            this.SalesTypeGuide_ultraButton.Enabled = false;// 販売区分ガイド
            this.BLGroupCode_tNedit.Enabled = false;        // BLグループ
            this.BLGroupGuide_ultraButton.Enabled = false;  // BLグループガイド
            this.BLCode_tNedit.Enabled = false;             // BLコード
            this.BLCodeGuide_ultraButton.Enabled = false;   // BLコードガイド
            this.ItemTypeCode_tNedit.Enabled = false;       // 商品区分
            this.ItemTypeGuide_ultraButton.Enabled = false; // 商品区分ガイド

            this.BLGroupCode_tNedit.Clear();
            this.BLCode_tNedit.Clear();
            this.SalesTypeCode_tNedit.Clear();
            this.ItemTypeCode_tNedit.Clear();

//----- ueno add---------- start 2007.11.21
			this._targetContrastCd_tComboEditorValue = -1;	// 初期化
//----- ueno add---------- end   2007.11.21

            // コントロール制御
            ControlEnabled();

			// 期間設定
			SetTargetDate();

			//----- ueno del---------- start 2007.11.21
			// 比率計算
			//CalcFromRatio();
			//----- ueno del---------- end   2007.11.21
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// FormClosing イベント処理(MAMOK09130UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: フォームの×ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.07.31</br>
        /// </remarks>
        private void MAMOK09130UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            SalesTarget salesTarget;
            bool retResult;

            // 修正目標データバッファ保存
            ScreenToSalesTarget(out salesTarget);

            if (salesTarget.Equals(this._salesTarget))
            {
            }
            else
            {
                // 画面情報が変更されていた場合は、保存確認メッセージを表示
                DialogResult res = TMsgDisp.Show(this,					  // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_SAVECONFIRM, 				  // エラーレベル
                    this.Name, 											  // アセンブリＩＤ
                    null, 												  // 表示するメッセージ
                    0, 													  // ステータス値
                    MessageBoxButtons.YesNoCancel);						  // 表示するボタン

                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            bool bStatus;

                            bStatus = CheckInputData();

                            if (!bStatus)
                            {
                                e.Cancel = true;
                                return;
                            }

							//----- ueno del---------- start 2007.11.21		
							//// メソッド先頭で格納しているので不要
							//// 修正後の目標データを保存
							//ScreenToSalesTarget(out salesTarget);
							//----- ueno del---------- end   2007.11.21		

							retResult = SaveSalesTarget(ref salesTarget);
                            if (!retResult)
                            {
                                e.Cancel = true;
                                this.Close_Button.Focus();
                                break;
                            }
                            this.DialogResult = DialogResult.OK;
                            break;
                        }

                    case DialogResult.No:
                        {
                            this.DialogResult = DialogResult.Cancel;
                            break;
                        }

                    case DialogResult.Cancel:
                        {
                            //SalesTargetToScreen(salesTarget);
                            this.Close_Button.Focus();
                            e.Cancel = true;
                            break;
                        }
                }
            }
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click イベント処理(Save_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 保存ボタンがクリックされた時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.03</br>
		/// </remarks>
		private void Save_Button_Click(object sender, EventArgs e)
		{
//----- ueno add---------- start 2007.11.21
			SalesTarget salesTarget;

			// 修正後目標データをバッファに保存
			ScreenToSalesTarget(out salesTarget);

			// 変更点チェック
			if (salesTarget.Equals(this._salesTarget))
			{
				return;
			}

			// チェック処理
			if (!CheckInputData())
			{
				return;
			}
//----- ueno add---------- end   2007.11.21

			// 目標データ保存処理
			bool status = SaveSalesTarget(ref salesTarget);
			if (!status)
			{
				return;
			}
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click イベント処理(Close_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 閉じるボタンがクリックされた時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.03</br>
		/// </remarks>
		private void Close_Button_Click(object sender, EventArgs e)
		{
            this.Close();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click イベント処理(GoodsCodeGuide_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 商品ガイドボタンがクリックされた時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.12</br>
		/// </remarks>
		private void GoodsCodeGuide_Button_Click(object sender, EventArgs e)
		{
			//----- ueno upd---------- start 2007.11.21
			GoodsNoGuide(this.GoodsMakerCd_tNedit);
			//----- ueno upd---------- end   2007.11.21

			////----- ueno del---------- start 2007.11.21
			#region del
			//MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

			//GoodsUnitData goodsUnitData;
			//DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, this._enterpriseCode, out goodsUnitData);

			//if ((dialogResult == DialogResult.OK) && (goodsUnitData != null))
			//{
			//    // 商品
			//    this.GoodsCode_tEdit.DataText = goodsUnitData.GoodsNo;
			//    this.GoodsName_tEdit.DataText = goodsUnitData.GoodsName;

				//// キャリア
				//this.CarrierName_tEdit.Tag = goodsUnitData.CarrierCode;
				//this.CarrierName_tEdit.DataText = goodsUnitData.CarrierName;

				//// 機種
				//this.CellphoneModelName_tEdit.Tag = goodsUnitData.CellphoneModelCode;
				//this.CellphoneModelName_tEdit.DataText = goodsUnitData.CellphoneModelName;

				//// 系統色
				//this.SystematicColorNm_tEdit.Tag = goodsUnitData.SystematicColorCd;
				//this.SystematicColorNm_tEdit.DataText = goodsUnitData.SystematicColorNm;
			//}
			#endregion del
			//----- ueno del---------- end   2007.11.21
		}

//----- ueno add---------- start 2007.11.21
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click イベント処理(GoodsMakerCdGuide_Button_Click)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: メーカーガイドボタンがクリックされた時に発生します。</br>
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date		: 2007.11.22</br>
		/// </remarks>
		private void GoodsMakerCdGuide_Button_Click(object sender, EventArgs e)
		{
			MakerUMnt makerUMnt = null;
			
			if (this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt) == 0)
			{
				this.GoodsMakerCd_tNedit.SetInt(makerUMnt.GoodsMakerCd);
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA MODIFY START
				this.GoodsMakerCdNm_tEdit.DataText = makerUMnt.MakerName;//.MakerShortName;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA MODIFY END

				// 現在データ保存
				this._goodsMakerCdWork = this.GoodsMakerCd_tNedit.GetInt();
				
				// 商品コードが入力可のときのみ
				if(this.GoodsCode_tEdit.Enabled == true)
				{
					// 商品コードガイド
					GoodsNoGuide(this.GoodsMakerCd_tNedit);
				}
			}
		}

		/// <summary>
		/// TargetContrastCd_tComboEditor_SelectionChangeCommitted イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 目標対比区分が変化されたときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		private void TargetContrastCd_tComboEditor_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (this.TargetContrastCd_tComboEditor.Value != null)
			{
				TargetContrastCdChange((Int32)this.TargetContrastCd_tComboEditor.Value);
			}
		}

//----- ueno add---------- end   2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Leave イベント(SalesTarget_tNedit)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: コントロールのフォーカスが離れた時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.05</br>
		/// </remarks>
		private void SalesTarget_tNedit_Leave(object sender, EventArgs e)
		{
            TNedit salesTargetNedit = (TNedit)sender;

            // 数量目標の場合
            if (salesTargetNedit == this.SalesTargetCount_tNedit)
            {
                // 小数点桁数設定
                salesTargetNedit.NumEdit.DecLen = 1;
                if (salesTargetNedit.DataText != "")
                {
                    double salesTargetCount = double.Parse(salesTargetNedit.DataText);
                    salesTargetNedit.DataText = salesTargetCount.ToString();
                }
            }

			//----- ueno del---------- start 2007.11.21
			// 比率計算
			//CalcFromRatio();
			//----- ueno del---------- end   2007.11.21
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Enter イベント(SalesTargetCount_tNedit)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: コントロールにフォーカスが当たった時に発生します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.08.03</br>
        /// </remarks>
        private void SalesTargetCount_tNedit_Enter(object sender, EventArgs e)
        {
            // 小数点桁数設定
            this.SalesTargetCount_tNedit.NumEdit.DecLen = 0;
            if (this.SalesTargetCount_tNedit.DataText != "")
            {
                double salesTargetCount = double.Parse(this.SalesTargetCount_tNedit.DataText);
                this.SalesTargetCount_tNedit.DataText = salesTargetCount.ToString(FORMAT_NUM);
            }
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Leave イベント(GoodsCode_tEdit)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: コントロールのフォーカスが離れた時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.17</br>
		/// </remarks>
		private void GoodsCode_tEdit_Leave(object sender, EventArgs e)
		{
			//----- ueno del---------- start 2007.11.21
			//string goodsCode = this.GoodsCode_tEdit.Text.Trim();
			//if (goodsCode == "")
			//{
			//    this.GoodsCode_tEdit.DataText = "";
			//    this.GoodsName_tEdit.DataText = "";
			//    this.GoodsMakerCdNm_tEdit.DataText = "";

			//    //----- ueno del---------- start 2007.11.21
			//    //this.GoodsMakerCdNm_tEdit.Tag = -1;
			//    //this.CarrierName_tEdit.DataText = "";
			//    //this.CarrierName_tEdit.Tag = -1;
			//    //this.CellphoneModelName_tEdit.DataText = "";
			//    //this.CellphoneModelName_tEdit.Tag = "";
			//    //----- ueno del---------- end   2007.11.21

			//    return;
			//}
			//int status = SearchGoods(goodsCode);
			//----- ueno del---------- end   2007.11.21
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Leave イベント(ApplyStaDate_tDateEdit)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: コントロールのフォーカスが離れた時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.16</br>
		/// </remarks>
		private void ApplyStaDate_tDateEdit_Leave(object sender, EventArgs e)
		{
			bool bStatus;

			// 月間目標
			if (this._targetSetCd == 10)
			{
				if (this.ApplyStaDate_tDateEdit.GetDateYear() == 0 ||
					this.ApplyStaDate_tDateEdit.GetDateMonth() == 0)
				{
					this.TargetDivideCode_tEdit.DataText = "";

					//----- ueno del---------- start 2007.11.21
					//ClearRatioControl();
					//----- ueno del---------- end   2007.11.21
					return;
				}

				// 日付チェック
				bStatus = CheckDate();
				if (!bStatus)
				{
					return;
				}

                this._targetStaDate = new DateTime(ApplyStaDate_tDateEdit.GetDateYear(), ApplyStaDate_tDateEdit.GetDateMonth(), 1);
                this.ApplyStaDate_tDateEdit.SetDateTime(this._targetStaDate);

				this.TargetDivideCode_tEdit.DataText = this.ApplyStaDate_tDateEdit.GetDateYear().ToString("0000") +
													   this.ApplyStaDate_tDateEdit.GetDateMonth().ToString("00");

				int days = DateTime.DaysInMonth(ApplyStaDate_tDateEdit.GetDateYear(), ApplyStaDate_tDateEdit.GetDateMonth());
				this._targetEndDate = new DateTime(ApplyStaDate_tDateEdit.GetDateYear(), ApplyStaDate_tDateEdit.GetDateMonth(), days);
				this.ApplyEndDate_tDateEdit.SetDateTime(this._targetEndDate);
			}
			// 個別期間目標
			else
			{
                if (this.ApplyStaDate_tDateEdit.GetDateYear() == 0 ||
                    this.ApplyStaDate_tDateEdit.GetDateMonth() == 0 ||
                    this.ApplyStaDate_tDateEdit.GetDateDay() == 0)
                {
					//----- ueno del---------- start 2007.11.21
					//ClearRatioControl();
					//----- ueno del---------- end   2007.11.21
					return;
                }

				// 日付チェック
				bStatus = CheckDate();
				if (!bStatus)
				{
					return;
				}

				this._targetStaDate = this.ApplyStaDate_tDateEdit.GetDateTime();
			}

			//----- ueno del---------- start 2007.11.21
			// 比率計算
			//CalcFromRatio();
			//----- ueno del---------- end   2007.11.21
		}



		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Leave イベント(ApplyEndDate_tDateEdit)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: コントロールのフォーカスが離れた時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.17</br>
		/// </remarks>
		private void ApplyEndDate_tDateEdit_Leave(object sender, EventArgs e)
		{
            if (this.ApplyEndDate_tDateEdit.GetDateYear() == 0 ||
                this.ApplyEndDate_tDateEdit.GetDateMonth() == 0 ||
                this.ApplyEndDate_tDateEdit.GetDateDay() == 0)
            {
				//----- ueno del---------- start 2007.11.21
				//ClearRatioControl();
				//----- ueno del---------- end   2007.11.21
				return;
            }

			// 日付チェック
			bool bStatus = CheckDate();
			if (!bStatus)
			{
				return;
			}

			this._targetEndDate = this.ApplyEndDate_tDateEdit.GetDateTime();

			//----- ueno del---------- start 2007.11.21
			// 比率計算
			//CalcFromRatio();
			//----- ueno del---------- end   2007.11.21
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ValueChanged イベント(TargetSetCd_uOptionSet)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: ラジオボタンのチェックが変更された時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.16</br>
		/// </remarks>
		private void TargetSetCd_uOptionSet_ValueChanged(object sender, EventArgs e)
		{
			// 月間目標
            //if ((int)this.TargetSetCd_uOptionSet.Value == 10)
			if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 10)
			{
				this._targetSetCd = 10;
			}
			// 個別目標
			else
			{
				this._targetSetCd = 20;
			}

			// コントロール制御
			ControlEnabled();

			this.ApplyStaDate_tDateEdit.SetDateTime(new DateTime());
			this.ApplyEndDate_tDateEdit.SetDateTime(new DateTime());
			this.TargetDivideCode_tEdit.DataText = "";
			this.TargetDivideName_tEdit.DataText = "";
			this._targetStaDate = new DateTime();
			this._targetEndDate = new DateTime();
			this.SalesTargetMoney_tNedit.DataText = "";
			this.SalesTargetProfit_tNedit.DataText = "";
			this.SalesTargetCount_tNedit.DataText = "";
			//----- ueno del---------- start 2007.11.21
			//ClearRatioControl();
			//----- ueno del---------- end   2007.11.21
		}

		# endregion Control Events

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
        /// <summary>
        /// ValueChanged イベント(TargetSetCd_tComboEditor)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: プルダウンの値が変更された時に発生します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.05.16</br>
        /// </remarks>
        private void TargetSetCd_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // 月間目標
            if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 10)
            {
                this._targetSetCd = 10;
            }
            // 個別目標
            else
            {
                this._targetSetCd = 20;
            }

            // コントロール制御
            ControlEnabled();

            this.ApplyStaDate_tDateEdit.SetDateTime(new DateTime());
            this.ApplyEndDate_tDateEdit.SetDateTime(new DateTime());
            this.TargetDivideCode_tEdit.DataText = "";
            this.TargetDivideName_tEdit.DataText = "";
            this._targetStaDate = new DateTime();
            this._targetEndDate = new DateTime();
            this.SalesTargetMoney_tNedit.DataText = "";
            this.SalesTargetProfit_tNedit.DataText = "";
            this.SalesTargetCount_tNedit.DataText = "";
            //----- ueno del---------- start 2007.11.21
            //ClearRatioControl();
            //----- ueno del---------- end   2007.11.21

        }

        /// <summary>
        /// BLグループガイドボタンクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BLGroupGuide_ultraButton_Click(object sender, EventArgs e)
        {
            BLGroupU blGroupUnit;
            int status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupUnit);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.BLGroupCode_tNedit.DataText = blGroupUnit.BLGroupCode.ToString();
                this.BLGroupName_tEdit.DataText = blGroupUnit.BLGroupName;

                // データにセット
                this._salesTarget.BLGroupCode = blGroupUnit.BLGroupCode;
            }
        }

        /// <summary>
        /// BLグループ入力欄Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BLGroupCode_tNedit_Leave(object sender, EventArgs e)
        {
            // 何か入力されていれば変換
            if (!string.IsNullOrEmpty(this.BLGroupCode_tNedit.Text))
            {
                try
                {
                    int blGroupCode = int.Parse(this.BLGroupCode_tNedit.Text);

                    BLGroupU blGroupUnit;
                    int status = this._blGroupUAcs.Search(out blGroupUnit, this._enterpriseCode, blGroupCode);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this.BLGroupCode_tNedit.DataText = blGroupUnit.BLGroupCode.ToString();
                        this.BLGroupName_tEdit.DataText = blGroupUnit.BLGroupName;

                        // データにセット
                        this._salesTarget.BLGroupCode = blGroupUnit.BLGroupCode;
                    }
                }
                catch (Exception)
                {
                    // 変換失敗
                }
            }
        }

        /// <summary>
        /// BLコードガイドボタンクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BLCodeGuide_ultraButton_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt blGoodsUnit;
            int status = _blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsUnit);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.BLCode_tNedit.DataText = blGoodsUnit.BLGoodsCode.ToString();
                this.BLCodeName_tEdit.DataText = blGoodsUnit.BLGoodsFullName;

                // データにセット
                this._salesTarget.BLCode = blGoodsUnit.BLGoodsCode;
            }
        }

        /// <summary>
        /// BLコード入力欄Leaveイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BLCode_tNedit_Leave(object sender, EventArgs e)
        {
            // 何か入力されていれば変換
            if (!string.IsNullOrEmpty(this.BLCode_tNedit.Text))
            {
                try
                {
                    int blGoodsCode = int.Parse(this.BLCode_tNedit.Text);

                    BLGoodsCdUMnt blGoodsUnit;
                    int status = this._blGoodsCdAcs.Read(out blGoodsUnit, this._enterpriseCode, blGoodsCode);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this.BLCode_tNedit.DataText = blGoodsUnit.BLGoodsCode.ToString();
                        this.BLCodeName_tEdit.DataText = blGoodsUnit.BLGoodsFullName;

                        // データにセット
                        this._salesTarget.BLCode = blGoodsUnit.BLGoodsCode;
                    }
                }
                catch (Exception)
                {
                    // 変換失敗
                }
            }
        }


        /// <summary>
        /// 販売区分ガイドボタンクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SalesTypeGuide_ultraButton_Click(object sender, EventArgs e)
        {
            UserGdBd userGuideBdInfo;
            UserGdHd userGuideHdInfo;
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGuideHdInfo, out userGuideBdInfo, SALES_TYPE_GUIDE);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.SalesTypeCode_tNedit.DataText = userGuideBdInfo.GuideCode.ToString();
                this.SalesTypeName_tEdit.DataText = userGuideBdInfo.GuideName;

                // データにセット
                this._salesTarget.SalesTypeCode = userGuideBdInfo.GuideCode;
            }
        }

        /// <summary>
        /// 販売区分入力欄Leaveイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SalesTypeCode_tNedit_Leave(object sender, EventArgs e)
        {
            // 何か入力されていれば変換
            if (!string.IsNullOrEmpty(this.SalesTypeCode_tNedit.Text))
            {
                try
                {
                    int salesTypeCode = int.Parse(this.SalesTypeCode_tNedit.Text);

                    UserGdBd userGuideBdInfo;
                    int status = this._userGuideAcs.ReadStaticMemory(out userGuideBdInfo, SALES_TYPE_GUIDE, salesTypeCode);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this.SalesTypeCode_tNedit.DataText = userGuideBdInfo.GuideCode.ToString();
                        this.SalesTypeName_tEdit.DataText = userGuideBdInfo.GuideName;

                        // データにセット
                        this._salesTarget.SalesTypeCode = userGuideBdInfo.GuideCode;
                    }
                }
                catch (Exception)
                {
                    // 変換失敗
                    // 数字オンリーで縛ってあるから大丈夫なはずだけど…
                }
            }
        }

        /// <summary>
        /// 商品区分ガイドボタンクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemTypeGuide_ultraButton_Click(object sender, EventArgs e)
        {
            UserGdBd userGuideBdInfo;
            UserGdHd userGuideHdInfo;
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGuideHdInfo, out userGuideBdInfo, ITEM_TYPE_GUIDE);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.ItemTypeCode_tNedit.DataText = userGuideBdInfo.GuideCode.ToString();
                this.ItemTypeName_tEdit.DataText = userGuideBdInfo.GuideName;

                // データにセット
                this._salesTarget.ItemTypeCode = userGuideBdInfo.GuideCode;
            }
        }

        /// <summary>
        /// 商品区分入力欄Leaveイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemTypeCode_tNedit_Leave(object sender, EventArgs e)
        {
            // 何か入力されていれば変換
            if (!string.IsNullOrEmpty(this.ItemTypeCode_tNedit.Text))
            {
                try
                {
                    int itemTypeCode = int.Parse(this.ItemTypeCode_tNedit.Text);

                    UserGdBd userGuideBdInfo;
                    int status = this._userGuideAcs.ReadStaticMemory(out userGuideBdInfo, ITEM_TYPE_GUIDE, itemTypeCode);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this.ItemTypeCode_tNedit.DataText = userGuideBdInfo.GuideCode.ToString();
                        this.ItemTypeName_tEdit.DataText = userGuideBdInfo.GuideName;

                        // データにセット
                        this._salesTarget.ItemTypeCode = userGuideBdInfo.GuideCode;
                    }
                }
                catch (Exception)
                {
                    // 変換失敗
                }
            }
        }




        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END
	}
}