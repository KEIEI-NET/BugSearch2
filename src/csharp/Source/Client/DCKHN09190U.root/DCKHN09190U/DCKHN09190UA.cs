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
	/// 得意先目標入力画面
	/// </summary>
	/// <remarks>
	/// <br>Note		: 得意先目標入力を行う画面です。</br>
	/// <br>Programmer	: 30167 上野　弘貴</br>
	/// <br>Date		: 2007.11.21</br>
	/// <br>Update Note : 2008.03.03 30167 上野　弘貴</br>
	/// <br>			  項目ゼロ埋め対応（画面デザインにコンポーネント追加、
	///					  Tedit、TNeditの設定変更）</br>
	/// <br>Update Note : 2008.03.06 30167 上野　弘貴</br>
	///	<br>		 	  ショートカットキーエラーチェック対応追加</br>
	/// <br>Update Note: 2008.03.07 30167 上野　弘貴</br>
	///					  項目クリア後エンターキーで次項目へ移動するよう修正</br>
	/// </remarks>
	public partial class DCKHN09190UA : Form
	{
		# region Private Constants

		// PG名称
		private const string ctPGNM = "得意先目標入力";

		//----- ueno del---------- start 2007.11.21
		// 比率
        //private const string RATIO_DEFAULT = "1.00";
		//----- ueno del---------- end   2007.11.21

        // 書式
        private const string FORMAT_NUM = "###,##0";
        private const string FORMAT_NUM_DECIMAL = "N1";

		// 拠点目標用従業員コード
		private const string EMPLOYEECODE_SECTION = "SECTION";

		private const int GUIDEDIVCD_BUSINESSTYPECODE = 33;	// ユーザーガイド区分（業種コード）
		private const int GUIDEDIVCD_SALESAREACODE = 21;	// ユーザーガイド区分（販売エリアコード）

		# endregion Private Constants

		# region Private Members

		// 企業コード
		private string _enterpriseCode;
        // 拠点コード
        private string _sectionCode;
		// 拠点名
		private string _sectionName;

		// 目標データ
		private SalesTarget _salesTarget;
		// 目標マスタアクセスクラス
		private SalesTargetAcs _salesTargetAcs;
		// 目標データリスト
		private List<SalesTarget> _salesTargetList;

		// 得意先コード（ワーク）
		private int _customerCodeWork = 0;

		// 目標対比区分ワーク
		private int _targetContrastCd_tComboEditorValue = -1;

		//----- ueno add---------- start 2008.03.06
		// 文字列結合用
		private StringBuilder _stringBuilder = null;
		//----- ueno add---------- end 2008.03.06

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

		// モード(新規 or 編集)
		private int _mode;

		private bool _searchFlag;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA ADD START
        // 拠点コードアクセスクラス
        // 拠点アクセスクラス
        private SecInfoSetAcs _secInfoSetAcs = null;

        // ユーザーガイドアクセスクラスガイド定数
        private int BUSINESS_TYPE_GUIDE = 33;   // 業種コード
        private int SALES_AREA_GUIDE = 21;      // 販売エリア
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA ADD END

		//----- ueno add---------- start 2008.03.06
		// 得意先アクセスクラス
		private CustomerInfoAcs _customerInfoAcs = null;
		//----- ueno add---------- end 2008.03.06

		// ユーザーガイドアクセスクラス
		private UserGuideAcs _userGuideAcs = null;

		// ユーザーガイドデータ格納用（業種コード）
		private SortedList _businessTypeCodeSList = null;

		// ユーザーガイドデータ格納用（販売エリアコード）
		private SortedList _salesAreaCodeSList = null;
		
		/// <summary>画面デザイン変更クラス</summary>
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		# endregion Private Members

		# region Constructor

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public DCKHN09190UA()
		{
			InitializeComponent();

			// 企業コードを取得
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// 拠点名称取得
			//SecInfoSet secInfoSet;
			//SecInfoAcs secInfoAcs = new SecInfoAcs();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA MODIFY START
			//secInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);
            //this._sectionCode = secInfoSet.SectionCode;
            // 拠点名称を受け取ったsalesTargetオブジェクトの拠点コードから取得
            //this._sectionCode = this._salesTarget.SectionCode;
            //secInfoAcs.GetSecInfo(_sectionCode, out secInfoSet);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA MODIFY END

            //this._sectionName = secInfoSet.SectionGuideNm.TrimEnd();

			this._salesTargetAcs = new SalesTargetAcs();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA ADD START
            // 拠点アクセスクラス
            this._secInfoSetAcs = new SecInfoSetAcs();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA ADD END

			//----- ueno add---------- start 2008.03.06
			this._customerInfoAcs = new CustomerInfoAcs();	// 得意先アクセスクラス
			//----- ueno add---------- end 2008.03.06

			this._userGuideAcs = new UserGuideAcs();		// ユーザーガイドアクセスクラス

			// ユーザーガイドデータ格納用（業種コード）
			this._businessTypeCodeSList = new SortedList();

			// ユーザーガイドデータ格納用（販売エリアコード）
			this._salesAreaCodeSList = new SortedList();

			// アイコン画像の設定

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA ADD START
            // 業種コードガイドボタン
            this.BusinessTypeCodeGuide_ultraButton.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            // 販売エリアコードガイドボタン
            this.SalesAreaCodeGuide_ultraButton.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA ADD END

			// 得意先コードガイドボタン
			this.CustomerCodeGuide_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

			// 終了ボタン
			this.Close_Button.Appearance.Image
				= IconResourceManagement.ImageList24.Images[(int)Size24_Index.CLOSE];
			// 保存ボタン
			this.Save_Button.Appearance.Image
				= IconResourceManagement.ImageList24.Images[(int)Size24_Index.SAVE];

			//----- ueno add---------- start 2008.03.06
			// 文字列結合用
			this._stringBuilder = new StringBuilder();
			//----- ueno add---------- end 2008.03.06
		}

		# endregion Constructor

		#region enum

		//----- ueno upd ---------- start 2008.03.06
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
		//----- ueno upd ---------- end 2008.03.06

		//----- ueno add---------- start 2008.03.06
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
		//----- ueno add---------- end 2008.03.06

		#endregion

		# region Public Propaties

		/// public propaty name  :	SalesTarget
		/// <summary>目標データプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 目標データプロパティ</br>
		/// <br>Programer		 :	 30167 上野　弘貴</br>
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
		/// <br>Programer		 :	 30167 上野　弘貴</br>
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
		/// <br>Programer		 :	 30167 上野　弘貴</br>
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
		///// <br>Programmer	: 30167 上野　弘貴</br>
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
		//    status = LoadLdgCalcRatioMngTable(this._sectionCode);

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
		///// <br>Programmer	: 30167 上野　弘貴</br>
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
		///// <br>Programmer	: 30167 上野　弘貴</br>
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
		///// <br>Programmer	: 30167 上野　弘貴</br>
		///// <br>Date		: 2007.11.21</br>
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
		//            this._sectionCode,
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
		//            this._sectionCode,
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
		//            this._sectionCode,
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
		//----- ueno del---------- end   2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 対象期間設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 期間の設定を行います。</br>
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date		: 2007.11.21</br>
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
		/// Programmer : 30167 上野　弘貴<br />
		/// Date	   : 2007.04.03<br />
		/// </remarks>
		private void SalesTargetToScreen(SalesTarget salesTarget)
		{
			// 目標対比区分
			if (salesTarget.TargetContrastCd != 0)
			{
				this.TargetContrastCd_tComboEditor.Value = (int)salesTarget.TargetContrastCd;
			}
		
			// 目標設定区分
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
            if (salesTarget.TargetSetCd == 10)
            {
                this.TargetSetCd_tComboEditor.SelectedIndex = 0;
            }
            else
            {   
                this.TargetSetCd_tComboEditor.SelectedIndex = 1;// salesTarget.TargetSetCd;
            }
            //this.TargetSetCd_uOptionSet.Value = salesTarget.TargetSetCd;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA MODIFY END
			// 拠点名称
			this.SectionName_tEdit.DataText = this._sectionName;
			// 適用期間（開始）
			this.ApplyStaDate_tDateEdit.SetDateTime(salesTarget.ApplyStaDate.Date);
			// 適用期間（終了）
			this.ApplyEndDate_tDateEdit.SetDateTime(salesTarget.ApplyEndDate.Date);
			// 目標区分コード
			this.TargetDivideCode_tEdit.DataText = salesTarget.TargetDivideCode;
			// 目標区分名称
			this.TargetDivideName_tEdit.DataText = salesTarget.TargetDivideName;
			
			// 業種コンボボックス
			if (salesTarget.BusinessTypeCode != 0)
			{
				this.BusinessTypeCode_tNedit.SetInt(salesTarget.BusinessTypeCode);
                this.BusinessTypeName_tEdit.DataText = salesTarget.BusinessTypeName;
			}
			// 販売エリアコンボボックス
			if (salesTarget.SalesAreaCode != 0)
			{
				this.SalesAreaCode_tNedit.SetInt(salesTarget.SalesAreaCode);
                this.SalesAreaName_tEdit.DataText = salesTarget.SalesAreaName;
			}
			// 得意先コード
			this.CustomerCode_tNedit.SetInt(salesTarget.CustomerCode);

			// 得意先名称
			this.CustomerCodeNm_tEdit.DataText = GetCustomerName(salesTarget.CustomerCode);

			// 売上目標
			if (salesTarget.SalesTargetMoney != 0)
			{
				this.SalesTargetMoney_tNedit.DataText = salesTarget.SalesTargetMoney.ToString();
			}
			else
			{
				this.SalesTargetMoney_tNedit.DataText = "";
			}
			// 粗利目標
			if (salesTarget.SalesTargetProfit != 0)
			{
				this.SalesTargetProfit_tNedit.DataText = salesTarget.SalesTargetProfit.ToString();
			}
			else
			{
				this.SalesTargetProfit_tNedit.DataText = "";
			}
			// 数量目標
			if (salesTarget.SalesTargetCount != 0)
			{
				this.SalesTargetCount_tNedit.DataText = salesTarget.SalesTargetCount.ToString();
			}
			else
			{
				this.SalesTargetCount_tNedit.DataText = "";
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 修正目標データバッファ保存処理
		/// </summary>
		/// <param name="salesTarget">目標データ</param>
		/// <remarks>
		/// Note	   : 修正対象の目標データをバッファに保存します。<br />
		/// Programmer : 30167 上野　弘貴<br />
		/// Date	   : 2007.11.21<br />
		/// </remarks>
		private void ScreenToSalesTarget(out SalesTarget salesTarget)
		{
			salesTarget = this._salesTarget.Clone();

            // 目標対比区分
			if (this.TargetContrastCd_tComboEditor.Value != null)
			{
				salesTarget.TargetContrastCd = (int)this.TargetContrastCd_tComboEditor.Value;
			}

			// 目標設定区分
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
            salesTarget.TargetSetCd = int.Parse(TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString());
            //salesTarget.TargetSetCd = (int)TargetSetCd_uOptionSet.Value;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA MODIFY END
			// 期間（開始）
            //salesTarget.ApplyStaDate = this._targetStaDate.Date;
            salesTarget.ApplyStaDate = this.ApplyStaDate_tDateEdit.GetDateTime();
			// 期間（終了）
            //salesTarget.ApplyEndDate = this._targetEndDate.Date;
            salesTarget.ApplyEndDate = this.ApplyEndDate_tDateEdit.GetDateTime();
			// 目標区分コード
			salesTarget.TargetDivideCode = this.TargetDivideCode_tEdit.DataText;
			// 目標区分名称
			salesTarget.TargetDivideName = this.TargetDivideName_tEdit.DataText;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
			// 業種コード
            int businessTypeCode = this.BusinessTypeCode_tNedit.GetInt();
            if (businessTypeCode != 0)
            {
                salesTarget.BusinessTypeCode = businessTypeCode;
                salesTarget.BusinessTypeName = this.BusinessTypeName_tEdit.DataText;
            }
            //if (this.BusinessTypeCode_tComboEditor.Value != null)
            //{
            //    salesTarget.BusinessTypeCode = (int)this.BusinessTypeCode_tComboEditor.Value;
            //}

			// 販売エリアコード
            int salesAreaCode = this.SalesAreaCode_tNedit.GetInt();
            if (salesAreaCode != 0)
            {
                salesTarget.SalesAreaCode = salesAreaCode;
                salesTarget.SalesAreaName = this.SalesAreaName_tEdit.DataText;
            }
            //if (this.SalesAreaCode_tComboEditor.Value != null)
            //{
            //    salesTarget.SalesAreaCode = (int)this.SalesAreaCode_tComboEditor.Value;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA MODIFY END

			
			// 得意先コード
			if (this.CustomerCode_tNedit.DataText != "")
			{
				salesTarget.CustomerCode = Int32.Parse(this.CustomerCode_tNedit.DataText);
			}

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
		/// 得意先名称取得処理
		/// </summary>
		/// <param name="customerCode">得意先コード</param>
		/// <return>得意先名称</return>
		/// <remarks>
		/// Note	   : 得意先名称を取得します。<br />
		/// Programmer : 30167 上野　弘貴<br />
		/// Date	   : 2007.11.21<br />
		/// </remarks>
		private string GetCustomerName(int customerCode)
		{
			CustomerInfo customerInfo = null;
			CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
			string customerName = "";

            if (customerCode != 0)
            {
                // データ存在チェック
                int ret = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode,
                                customerCode, out customerInfo);
                if (ret == 0)
                {
                    customerName = customerInfo.Name;
                }
            }

			return customerName;
		}
		
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 修正目標データチェック処理
		/// </summary>
		/// <remarks>
		/// Note	   : 修正目標データをチェックします。<br />
		/// Programmer : 30167 上野　弘貴<br />
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

				// 目標対比区分によりチェック変更
				switch((int)this.TargetContrastCd_tComboEditor.Value)
				{
					case (int)SalesTarget.ConstrastCd.SecAndCust:				// 30:拠点＋得意先
						{
							// 得意先コード
							if ((this.CustomerCode_tNedit.DataText == "") || (this.CustomerCode_tNedit.GetInt() == 0))
							{
								errMsg = "得意先コードを入力してください";
								this.CustomerCode_tNedit.Focus();

								//----- ueno add---------- start 2008.03.06
								this.CustomerCodeNm_tEdit.Clear();	// 得意先名称クリア
								this._customerCodeWork = 0;			// 得意先コードワーククリア
								//----- ueno add---------- end 2008.03.06
								
								return (false);
							}
							break;
						}
					case (int)SalesTarget.ConstrastCd.SecAndBusinessType:		// 31:拠点＋業種
						{
							// 業種コード
							if (this.BusinessTypeCode_tNedit.DataText != null)
							{
								if((int.Parse(this.BusinessTypeCode_tNedit.DataText)) == 0)
								{
									errMsg = "業種コードを選択してください";
                                    this.BusinessTypeCode_tNedit.Focus();
									return (false);
								}
							}
							else
							{
								errMsg = "業種コードが存在しません";
                                this.BusinessTypeCode_tNedit.Focus();
								return (false);
							}
							break;
						}
					case (int)SalesTarget.ConstrastCd.SecAndSalesArea:			// 32:拠点＋販売エリア
						{
							// 販売エリアコード
							if (this.SalesAreaCode_tNedit.DataText != null)
							{
                                if ((int.Parse(this.SalesAreaCode_tNedit.DataText)) == 0)
								{
									errMsg = "販売エリアコードを選択してください";
                                    this.SalesAreaCode_tNedit.Focus();
									return (false);
								}
							}
							else
							{
								errMsg = "販売エリアコードが存在しません";
                                this.SalesAreaCode_tNedit.Focus();
								return (false);
							}
							break;
						}
				}

				//----- ueno add---------- start 2008.03.06
				DispSetStatus dispSetStatus = DispSetStatus.Clear;

				bool canChangeFocus = true;
				object inParamObj = null;
				object outParamObj = null;
				ArrayList inParamList = null;

				//------------------------
				// 得意先コードチェック
				//------------------------
				if (this.CustomerCode_tNedit.Enabled == true)
				{
					// 条件設定クリア
					inParamObj = null;
					outParamObj = null;
					inParamList = new ArrayList();

					dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用
					
					// 条件設定
					inParamObj = this.CustomerCode_tNedit.GetInt();

					// 存在チェック
					switch (CheckCustomerCode(inParamObj, out outParamObj))
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
								errMsg = ShowNotFoundErrMsg("得意先コード");
								dispSetStatus = this._customerCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
								break;
							}
					}
					// データ設定
					DispSetCustomerCode(dispSetStatus, ref canChangeFocus, outParamObj);

					if (dispSetStatus != DispSetStatus.Update)
					{
						this.CustomerCode_tNedit.Focus();
						return false;
					}
				}
				//----- ueno add---------- end 2008.03.06
				
                if ((this.SalesTargetMoney_tNedit.DataText == "" || long.Parse(this.SalesTargetMoney_tNedit.DataText) == 0) &&
                    (this.SalesTargetProfit_tNedit.DataText == "" || long.Parse(this.SalesTargetProfit_tNedit.DataText) == 0) &&
                    (this.SalesTargetCount_tNedit.DataText == "" || double.Parse(this.SalesTargetCount_tNedit.DataText) == 0))
                {
                    errMsg = "目標金額または数量を入力してください";
                    this.SalesTargetMoney_tNedit.Focus();
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
		/// 日付チェック処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 入力日付のチェックを行います。</br>
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date		: 2007.11.21</br>
		/// </remarks>
		private bool CheckDate()
		{
			string errMsg = "";

			try
			{
				// 月間目標
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
                if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 10)
                //if ((int)this.TargetSetCd_uOptionSet.Value == 10)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA MODIFY END
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
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
                else if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 20)
                //else if ((int)this.TargetSetCd_uOptionSet.Value == 20)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA MODIFY END
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

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 修正目標データ保存処理
		/// </summary>
		/// <param name="salesTarget">目標データ</param>
		/// <remarks>
		/// Note	   : 修正目標データを保存します。<br />
		/// Programmer : 30167 上野　弘貴<br />
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

			//// 修正後のデータをバッファに保存
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
		////*----------------------------------------------------------------------------------*/
		///// <summary>
		///// 曜日別比率表示処理
		///// </summary>
		///// <remarks>
		///// <br>Note		: 曜日別の比率を画面に表示します。</br>
		///// <br>Programmer	: 30167 上野　弘貴</br>
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
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date		: 2007.11.22</br>
		/// </remarks>
		private void SetControlSize()
		{
			//----- ueno del ---------- start 2008.03.06
			//-- 画面の設定は全て画面デザインで行うので以下削除
			//this.SectionName_tEdit.Size = new Size(179, 24);
			//this.TargetDivideCode_tEdit.Size = new Size(84, 24);
			//this.TargetDivideName_tEdit.Size = new Size(290, 24);
			//this.BusinessTypeCode_tComboEditor.Size = new Size(144, 24);
			//this.SalesAreaCode_tComboEditor.Size = new Size(144, 24);
			//this.CustomerCode_tNedit.Size = new Size(92, 24);
			//this.CustomerCodeNm_tEdit.Size = new Size(226, 24);
			//this.SalesTargetMoney_tNedit.Size = new Size(131, 24);
			//this.SalesTargetProfit_tNedit.Size = new Size(131, 24);
			//this.SalesTargetCount_tNedit.Size = new Size(108, 24);
			//----- ueno del ---------- end 2008.03.06

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
		/// <br>Programmer	: 30167 上野　弘貴</br>
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

			//----- ueno del ---------- start 2008.03.06
			// 項目の最大入力可能桁数は画面デザインで設定する
			//this.TargetDivideCode_tEdit.MaxLength = 9;
			//this.TargetDivideName_tEdit.MaxLength = 30;
			//this.CustomerCode_tNedit.MaxLength = 9;
			//----- ueno del ---------- end 2008.03.06

			//----- ueno del---------- start 2007.11.21
			#region del
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

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// コントロール制御処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: コントロールの制御の設定を行います。</br>
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date		: 2007.04.12</br>
		/// </remarks>
		private void ControlEnabled()
		{
			// 月間目標
			if (this._targetSetCd == 10)
			{
				this.ApplyDate_uLabel.Text = "適用年月";
				this.ApplyStaDate_tDateEdit.DateFormat = emDateFormat.df4Y2M;
				this.Range_uLabel.Visible = false;
				this.ApplyEndDate_tDateEdit.Visible = false;
				this.TargetDivideCode_uLabel.Visible = false;
				this.TargetDivideCode_tEdit.Visible = false;
				this.TargetDivideName_uLabel.Visible = false;
				this.TargetDivideName_tEdit.Visible = false;
			}
			// 個別期間目標
			else
			{
				this.ApplyDate_uLabel.Text = "適用期間";
				this.ApplyStaDate_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
				this.Range_uLabel.Visible = true;
				this.ApplyEndDate_tDateEdit.Visible = true;
				this.TargetDivideCode_uLabel.Visible = true;
				this.TargetDivideCode_tEdit.Visible = true;
				this.TargetDivideName_uLabel.Visible = true;
				this.TargetDivideName_tEdit.Visible = true;
			}

			// コントロールEnabled制御
			// 新規モード
			if (this._mode == 0)
			{
				this.Mode_Label.Text = "新規";

				// 目標対比区分コンボボックス値で判定する
				if (this.TargetContrastCd_tComboEditor.Value != null)
				{
					TargetContrastCdChange((Int32)this.TargetContrastCd_tComboEditor.Value);
				}

				// 月間
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
                // 直接キャストではなくパースかけないとエラーとなる
                if (int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString()) == 10)
                //if ((int)this.TargetSetCd_uOptionSet.Value == 10)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA MODIFY END
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

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
                    this.TargetSetCd_tComboEditor.Enabled = false;
                    //this.TargetSetCd_uOptionSet.Enabled = false;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA MODIFY END
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
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
                    this.TargetSetCd_tComboEditor.Enabled = true;
                    //this.TargetSetCd_uOptionSet.Enabled = true;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA MODIFY END
				}
			}
			// 編集モード
			else
			{
				this.Mode_Label.Text = "編集";
				this.TargetContrastCd_tComboEditor.Enabled = false;
				this.BusinessTypeCode_tNedit.Enabled = false;
                this.SalesAreaCode_tNedit.Enabled = false;
				this.CustomerCode_tNedit.Enabled = false;
				this.CustomerCodeGuide_Button.Enabled = false;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA ADD START
                this.SalesAreaCodeGuide_ultraButton.Enabled = false;
                this.BusinessTypeCodeGuide_ultraButton.Enabled = false;
                this.TargetSetCd_tComboEditor.Enabled = false;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA ADD END
			}
		}

		//----- ueno del---------- start 2007.11.21
		#region del
		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// 画面初期化処理
		///// </summary>
		///// <remarks>
		///// <br>Note		: 画面の初期化を行います。</br>
		///// <br>Programmer	: 30167 上野　弘貴</br>
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

			//----- ueno add---------- start 2008.03.06
			//InputChk inputChk = InputChk.None;

			bool canChangeFocus = true;
			DispSetStatus dispSetStatus = DispSetStatus.Clear;

			object inParamObj = null;
			object outParamObj = null;
			ArrayList inParamList = new ArrayList();
			//----- ueno add---------- end 2008.03.06
			
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

				#region case 得意先コード
				case "CustomerCode_tNedit":
					{
						// 変更が無ければ処理しない
						if (this.CustomerCode_tNedit.GetInt() == this._customerCodeWork)
						{
							break;
						}

						//--------------
						// 存在チェック
						//--------------
						//----- ueno add ---------- start 2008.03.06
						// 条件設定
						inParamObj = this.CustomerCode_tNedit.GetInt();

						// 存在チェック
						switch (CheckCustomerCode(inParamObj, out outParamObj))
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
											ShowNotFoundErrMsg("得意先コード"), 	// 表示するメッセージ
											0,										// ステータス値
											MessageBoxButtons.OK);					// 表示するボタン
									
									dispSetStatus = this._customerCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// データ設定
						DispSetCustomerCode(dispSetStatus, ref canChangeFocus, outParamObj);
						//----- ueno add ---------- end 2008.03.06

						#region del 2008.03.06
						//----- ueno del ---------- start 2008.03.06
						//CustomerInfo customerInfo = null;
						
						//if (this.CustomerCode_tNedit.DataText != "")
						//{
						//    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
							
						//    // データ存在チェック
						//    this.Cursor = Cursors.WaitCursor;
						//    int ret = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode,
						//                    this.CustomerCode_tNedit.GetInt(), out customerInfo);
						//    this.Cursor = Cursors.Default;

						//    if(ret == 0)
						//    {
						//        // 入力データが得意先でない場合
						//        if (customerInfo.IsCustomer == false)
						//        {
						//            // エラー
						//            ret = -1;
						//        }
						//    }

						//    if (ret != 0)
						//    {
						//        string errMessage = "指定された条件で、得意先コードは存在しませんでした。";
						//        TMsgDisp.Show(
						//                this, 							// 親ウィンドウフォーム
						//                emErrorLevel.ERR_LEVEL_INFO, 	// エラーレベル
						//                this.Name,						// アセンブリID
						//                errMessage, 					// 表示するメッセージ
						//                0,								// ステータス値
						//                MessageBoxButtons.OK);			// 表示するボタン

						//        inputChk = this._customerCodeWork == 0 ? InputChk.None : InputChk.Back;
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
						//            this.CustomerCode_tNedit.Clear();
						//            this.CustomerCodeNm_tEdit.Clear();
									
						//            // 現在データクリア
						//            this._customerCodeWork = 0;

						//            // フォーカス
						//            e.NextCtrl = e.PrevCtrl;
						//            break;
						//        }
						//    case InputChk.Back:		// 元に戻す
						//        {
						//            this.CustomerCode_tNedit.SetInt(this._customerCodeWork);
						//            break;
						//        }
						//    case InputChk.Update:	// 更新
						//        {
						//            this.CustomerCodeNm_tEdit.DataText = customerInfo.Name;

						//            // 現在データ保存
						//            this._customerCodeWork = this.CustomerCode_tNedit.GetInt();
						//            break;
						//        }
						//}
						//----- ueno del ---------- end 2008.03.06
						#endregion del 2008.03.06

						break;
					}
				#endregion
			}

			//----- ueno add ---------- start 2008.03.06
			// フォーカス制御
			if (canChangeFocus == false)
			{
				e.NextCtrl = e.PrevCtrl;

				//----- ueno add ---------- start 2008.03.07
				// 現在の項目から移動せず、テキスト全選択状態とする
				e.NextCtrl.Select();
				//----- ueno add ---------- end 2008.03.07
			}
			//----- ueno add ---------- end 2008.03.06
		}

		/// <summary>
		/// ユーザーガイドマスタボディ部リスト取得処理
		/// </summary>
		/// <returns>STATUS [0:取得 0以外:取得失敗]</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイドマスタボディ部のリストを取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		public int GetUserGdBdList(out ArrayList userGdBdList, int guideDivCode)
		{
			userGdBdList = null;
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			try
			{
				status = this._userGuideAcs.SearchAllDivCodeBody(out userGdBdList, this._enterpriseCode, guideDivCode, UserGuideAcsData.UserBodyData);
			}
			catch (Exception e)
			{
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.ToString(),
					"ユーザーガイド（ヘッダ）情報の取得に失敗しました。" + "\r\n" + e.Message,
					-1,
					MessageBoxButtons.OK);

				status = -1;
			}
			return status;
		}

		/// <summary>
		/// ユーザーガイドボディデータ設定処理
		/// </summary>
		/// <returns>STATUS [0:取得 0以外:取得失敗]</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイドボディデータを設定します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		public void SetUserGdBd(ref SortedList sList, ref ArrayList userGdBdList)
		{
			foreach (UserGdBd userGdBd in userGdBdList)
			{
				sList.Add(userGdBd.GuideCode, userGdBd.GuideName);
			}
		}

		/// <summary>
		/// ユーザーガイド名称取得処理
		/// </summary>
		/// <param name="userGuideSList"></param>
		/// <param name="userGuideCode"></param>
		/// <remarks>
		/// <br>Note       : ユーザーガイドコードから名称を取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		public string GetUserGdBdNm(ref SortedList userGuideSList, int userGuideCode)
		{
			string retStr = "";

			if (userGuideSList.ContainsKey(userGuideCode) == true)
			{
				retStr = userGuideSList[userGuideCode].ToString();
			}
			return retStr;
		}

		/// <summary>
		/// 目標対比区分変更
		/// </summary>
		/// <param name="targetContrastCd">目標対比区分</param>
		/// <remarks>
		/// <br>Note　     : 目標対比区分の選択を変更したときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		private void TargetContrastCdChange(int targetContrastCd)
		{
			if (this._targetContrastCd_tComboEditorValue == targetContrastCd) return;

			switch (targetContrastCd)
			{
				case (int)SalesTarget.ConstrastCd.SecAndCust:				// 30:拠点＋得意先
					{
						this.BusinessTypeCode_tNedit.Enabled = false;	    // 業種コード
                        this.BusinessTypeCodeGuide_ultraButton.Enabled = false;
						this.SalesAreaCode_tNedit.Enabled = false;	        // 販売エリアコード
                        this.SalesAreaCodeGuide_ultraButton.Enabled = false;
						this.CustomerCode_tNedit.Enabled = true;			// 得意先コード
						this.CustomerCodeGuide_Button.Enabled = true;		// 得意先ガイド
						
						// 入力不可項目クリア
                        this.BusinessTypeCode_tNedit.Clear();		        // 空白
                        this.BusinessTypeName_tEdit.Clear();
                        this.SalesAreaCode_tNedit.Clear();			        // 空白
                        this.SalesAreaName_tEdit.Clear();
						break;
					}
				case (int)SalesTarget.ConstrastCd.SecAndBusinessType:		// 31:拠点＋業種
					{
                        this.BusinessTypeCode_tNedit.Enabled = true;	    // 業種コード
                        this.BusinessTypeCodeGuide_ultraButton.Enabled = true;
                        this.SalesAreaCode_tNedit.Enabled = false;	        // 販売エリアコード
                        this.SalesAreaCodeGuide_ultraButton.Enabled = false;
						this.CustomerCode_tNedit.Enabled = false;			// 得意先コード
						this.CustomerCodeGuide_Button.Enabled = false;		// 得意先ガイド

						// 入力不可項目クリア
                        this.BusinessTypeCode_tNedit.Clear();   			// 空白
                        this.BusinessTypeName_tEdit.Clear();
						this.CustomerCode_tNedit.Clear();
						this.CustomerCodeNm_tEdit.Clear();
						break;
					}

				case (int)SalesTarget.ConstrastCd.SecAndSalesArea:			// 32:拠点＋販売エリア
					{
                        this.BusinessTypeCode_tNedit.Enabled = false;	    // 業種コード
                        this.BusinessTypeCodeGuide_ultraButton.Enabled = false;
                        this.SalesAreaCode_tNedit.Enabled = true;		    // 販売エリアコード
                        this.SalesAreaCodeGuide_ultraButton.Enabled = true;
						this.CustomerCode_tNedit.Enabled = false;			// 得意先コード
						this.CustomerCodeGuide_Button.Enabled = false;		// 得意先ガイド

						// 入力不可項目クリア
                        this.BusinessTypeCode_tNedit.Clear();			    // 空白
                        this.BusinessTypeName_tEdit.Clear();
						this.CustomerCode_tNedit.Clear();
						this.CustomerCodeNm_tEdit.Clear();
						break;
					}
			}
			// 選択した番号を保持
			this._targetContrastCd_tComboEditorValue = targetContrastCd;
		}

		//----- ueno add---------- start 2008.03.06
		#region 得意先コードエラーチェック処理
		/// <summary>
		/// 得意先コードエラーチェック処理
		/// </summary>
		/// <param name="inParamObj">条件オブジェクト</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
		/// <remarks>
		/// <br>Note       : 得意先コードエラーチェックを行います。
		///					 条件オブジェクト:得意先コード
		///					 結果オブジェクト:得意先マスタ検索結果ステータス, 得意先名称</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.03.06</br>
		/// </remarks>
		private int CheckCustomerCode(object inParamObj, out object outParamObj)
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
				CustomerInfo customerInfo = null;

				this.Cursor = Cursors.WaitCursor;
				ret = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, (int)inParamObj, out customerInfo);
				this.Cursor = Cursors.Default;

				outParamList.Add(status);	// 得意先マスタステータス設定

				// 入力データが得意先か判定
				if ((customerInfo != null) && (customerInfo.IsCustomer == true))
				{
					ret = (int)InputChkStatus.Normal;
					outParamList.Add(customerInfo.Name);	// 得意先名称設定
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
		#endregion 得意先コードエラーチェック処理

		#region 得意先コード設定処理
		/// <summary>
		/// 得意先コード設定処理
		/// </summary>
		/// <param name="dispSetStatus">入力チェックフラグ</param>
		/// <param name="canChangeFocus">フォーカスフラグ</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 得意先コードを画面に設定します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.03.06</br>
		/// </remarks>
		private void DispSetCustomerCode(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
		{
			ArrayList outParamList = null;

			try
			{
				switch (dispSetStatus)
				{
					case DispSetStatus.Clear:	// データクリア
						{
							this.CustomerCode_tNedit.Clear();
							this.CustomerCodeNm_tEdit.Clear();

							// 現在データクリア
							this._customerCodeWork = 0;

							//----- ueno upd ---------- start 2008.03.07
							// フォーカス
							canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
							//----- ueno upd ---------- end 2008.03.07

							break;
						}
					case DispSetStatus.Back:	// 元に戻す
						{
							this.CustomerCode_tNedit.SetInt(this._customerCodeWork);

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
									this.CustomerCodeNm_tEdit.Text = (string)outParamList[1];

									// 現在データ保存
									this._customerCodeWork = this.CustomerCode_tNedit.GetInt();
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
		#endregion 得意先コード設定処理

		#region データ無しエラーメッセージ出力処理
		/// <summary>
		/// データ無しエラーメッセージ出力処理
		/// </summary>
		/// <param name="errMsg">エラー発生箇所</param>
		/// <returns>作成されたエラーメッセージ</returns>
		/// <remarks>
		/// <br>Note       : データ無しのエラーメッセージを出力します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.03.06</br>
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
		//----- ueno add---------- end 2008.03.06

		# endregion Private Methods

		# region Control Events

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Form_Load イベント処理(DCKHN09190U)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: フォームロード処理を行います。</br>
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date		: 2007.11.21</br>
		/// </remarks>
		private void DCKHN09190UA_Load(object sender, EventArgs e)
		{
            this.TargetSetCd_tComboEditor.SelectedIndex = 0;


			// 画面スキンファイルの読込(デフォルトスキン指定)
			this._controlScreenSkin.LoadSkin();

			// 画面スキン変更
			this._controlScreenSkin.SettingScreenSkin(this);

			// コントロールサイズ設定
			SetControlSize();

			// Neditスタイル設定
			SetNeditStyle();

			// 目標対比区分コンボボックス設定
			this.TargetContrastCd_tComboEditor.Items.Clear();

			if (SalesTarget._targetContrastCdCustSList.Count > 0)
			{
				foreach (DictionaryEntry de in SalesTarget._targetContrastCdCustSList)
				{
					this.TargetContrastCd_tComboEditor.Items.Add(de.Key, de.Value.ToString());
				}
				this.TargetContrastCd_tComboEditor.Value = SalesTarget._targetContrastCdCustSList.GetKey(0);
			}

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA ADD START
            // 拠点名称取得
            SecInfoSet secInfoSet;
            //SecInfoAcs secInfoAcs = new SecInfoAcs();
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();

            // 拠点名称を受け取ったsalesTargetオブジェクトの拠点コードから取得
            this._sectionCode = this._salesTarget.SectionCode;
            int status = secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, _sectionCode);

            if (secInfoSet != null)
            {
                this._sectionName = secInfoSet.SectionGuideNm.TrimEnd();
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA ADD END

			//--------------------------
			// ユーザーガイドデータ取得
			//--------------------------
			ArrayList userGdBdList;
			
			// 業種コード取得
			userGdBdList = null;
			GetUserGdBdList(out userGdBdList, GUIDEDIVCD_BUSINESSTYPECODE);
			SetUserGdBd(ref this._businessTypeCodeSList, ref userGdBdList);
			
			// 販売エリア取得
			userGdBdList = null;
			GetUserGdBdList(out userGdBdList, GUIDEDIVCD_SALESAREACODE);
			SetUserGdBd(ref this._salesAreaCodeSList, ref userGdBdList);
			
            //// 業種コードコンボボックス設定
            //this.BusinessTypeCode_tNedit.BusinessTypeCode_tComboEditor.Items.Clear();

            //if (this._businessTypeCodeSList.Count > 0)
            //{
            //    // 空白設定
            //    this.BusinessTypeCode_tComboEditor.Items.Add(0, " ");
				
            //    foreach (DictionaryEntry de in this._businessTypeCodeSList)
            //    {
            //        this.BusinessTypeCode_tComboEditor.Items.Add(de.Key, de.Value.ToString());
            //    }
            //    this.BusinessTypeCode_tComboEditor.Value = 0;
            //}
			
            //// 販売エリアコードコンボボックス設定
            //this.SalesAreaCode_tComboEditor.Items.Clear();

            //if (this._salesAreaCodeSList.Count > 0)
            //{
            //    // 空白設定
            //    this.SalesAreaCode_tComboEditor.Items.Add(0, " ");
				
            //    foreach (DictionaryEntry de in this._salesAreaCodeSList)
            //    {
            //        this.SalesAreaCode_tComboEditor.Items.Add(de.Key, de.Value.ToString());
            //    }
            //    this.SalesAreaCode_tComboEditor.Value = 0;
            //}

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

			// コントロール制御
			ControlEnabled();

			this._targetContrastCd_tComboEditorValue = -1;	// 初期化

			// 期間設定
			SetTargetDate();

			//----- ueno del---------- start 2007.11.21
			//// 比率計算
			//CalcFromRatio();
			//----- ueno del---------- end   2007.11.21
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// FormClosing イベント処理(DCKHN09190UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: フォームの×ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: 30167 上野　弘貴</br>
        /// <br>Date		: 2007.07.31</br>
        /// </remarks>
        private void DCKHN09190UA_FormClosing(object sender, FormClosingEventArgs e)
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
							//----- メソッド先頭で格納しているので不要
							//// 修正後の目標データを保存
							//ScreenToSalesTarget(out salesTarget);
							//----- ueno del---------- end   2007.11.21		

							retResult = SaveSalesTarget(ref salesTarget);
                            if (!retResult)
                            {
                                this.Close_Button.Focus();
                                e.Cancel = true;
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
		/// <br>Programmer	: 30167 上野　弘貴</br>
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
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date		: 2007.04.03</br>
		/// </remarks>
		private void Close_Button_Click(object sender, EventArgs e)
		{
            this.Close();
		}

		/*----------------------------------------------------------------------------------*/

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA ADD START
        /// <summary>
        /// 業種コード入力欄Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BusinessTypeCode_tNedit_Leave(object sender, EventArgs e)
        {
            // 業種コード入力値を取得
            int businessTypeCode = this.BusinessTypeCode_tNedit.GetInt();

            // 入力されていれば変換
            if (businessTypeCode != 0)
            {
                UserGdBd userGuideBdInfo;
                int status = this._userGuideAcs.ReadStaticMemory(out userGuideBdInfo, BUSINESS_TYPE_GUIDE, businessTypeCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.BusinessTypeName_tEdit.DataText = userGuideBdInfo.GuideName;
                }
            }
        }

        /// <summary>
        /// 業種コードガイドボタンクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BusinessTypeCodeGuide_ultraButton_Click(object sender, EventArgs e)
        {
            UserGdBd userGuideBdInfo;
            UserGdHd userGuideHdInfo;
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGuideHdInfo, out userGuideBdInfo, BUSINESS_TYPE_GUIDE);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.BusinessTypeCode_tNedit.DataText = userGuideBdInfo.GuideCode.ToString();
                this.BusinessTypeName_tEdit.DataText = userGuideBdInfo.GuideName;
            }
        }

        /// <summary>
        /// 販売エリアコード入力欄Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SalesAreaCode_tNedit_Leave(object sender, EventArgs e)
        {
            // 販売エリアコード入力値を取得
            int businessTypeCode = this.SalesAreaCode_tNedit.GetInt();

            // 入力されていれば変換
            if (businessTypeCode != 0)
            {
                UserGdBd userGuideBdInfo;
                int status = this._userGuideAcs.ReadStaticMemory(out userGuideBdInfo, SALES_AREA_GUIDE, businessTypeCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.SalesAreaName_tEdit.DataText = userGuideBdInfo.GuideName;
                }
            }
        }

        /// <summary>
        /// 販売エリアコードガイドボタンクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SalesAreaCodeGuide_ultraButton_Click(object sender, EventArgs e)
        {
            UserGdBd userGuideBdInfo;
            UserGdHd userGuideHdInfo;
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGuideHdInfo, out userGuideBdInfo, SALES_AREA_GUIDE);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.SalesAreaCode_tNedit.DataText = userGuideBdInfo.GuideCode.ToString();
                this.SalesAreaName_tEdit.DataText = userGuideBdInfo.GuideName;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA ADD END
        
        /// <summary>
		/// Button_Click イベント処理(CustomerCodeGuide_Button_Click)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 得意先コードガイドボタンがクリックされた時に発生します。</br>
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date		: 2007.11.21</br>
		/// </remarks>
		private void CustomerCodeGuide_Button_Click(object sender, EventArgs e)
		{
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);	// 得意先検索アクセスクラス
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
//			customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
			customerSearchForm.ShowDialog(this);
		}

		/// <summary>
		/// 得意先選択時発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="customerSearchRet">得意先検索戻り値クラス</param>
		/// <remarks>
		/// <br>Note       : 得意先選択時に発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
		{
			if (customerSearchRet == null) return;

			CustomerInfo customerInfo;

			//選択された得意先の状態をチェック
			int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode,
									customerSearchRet.CustomerCode, out customerInfo);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// 選択データが得意先でない場合
				if (customerInfo.IsCustomer == false)
				{
					string errMessage = "指定された条件で、得意先は存在しませんでした。";

					// エラー
					TMsgDisp.Show(
						this,									// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION, 	// エラーレベル
						this.Name,								// アセンブリID
						errMessage,								// 表示するメッセージ
						status,									// ステータス値
						MessageBoxButtons.OK);					// 表示するボタン
					return;
				}
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				string errMessage = "選択した得意先は既に削除されています。";

				// エラー
				TMsgDisp.Show(
					this,									// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_EXCLAMATION, 	// エラーレベル
					this.Name,								// アセンブリID
					errMessage,								// 表示するメッセージ
					status,									// ステータス値
					MessageBoxButtons.OK);					// 表示するボタン
				return;
			}
			else
			{
				string errMessage = "得意先情報の取得に失敗しました。";

				// エラー
				TMsgDisp.Show(
					this,									// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_EXCLAMATION, 	// エラーレベル
					this.Name,								// アセンブリID
					errMessage,								// 表示するメッセージ
					status,									// ステータス値
					MessageBoxButtons.OK);					// 表示するボタン
				return;
			}

			this.CustomerCode_tNedit.SetInt(customerSearchRet.CustomerCode);
			this.CustomerCodeNm_tEdit.Text = customerSearchRet.Name;

			// 現在データ保存
			this._customerCodeWork = this.CustomerCode_tNedit.GetInt();
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

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Leave イベント(SalesTarget_tNedit)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: コントロールのフォーカスが離れた時に発生します。</br>
		/// <br>Programmer	: 30167 上野　弘貴</br>
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
			//// 比率計算
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
        /// <br>Programmer	: 30167 上野　弘貴</br>
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
		/// Leave イベント(ApplyStaDate_tDateEdit)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: コントロールのフォーカスが離れた時に発生します。</br>
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date		: 2007.04.17</br>
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
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date		: 2007.04.17</br>
		/// </remarks>
		private void ApplyEndDate_tDateEdit_Leave(object sender, EventArgs e)
		{
			bool bStatus;
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
			bStatus = CheckDate();
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
		/// ValueChanged イベント処理(TargetDivideCode_uOptionSet)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 目標設定区分のチェックを変更した時に発生します。</br>
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date		: 2007.04.16</br>
		/// </remarks>
		private void TargetDivideCode_uOptionSet_ValueChanged(object sender, EventArgs e)
		{
			// 月間目標
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
            if ((int)this.TargetSetCd_tComboEditor.SelectedItem.DataValue == 10)
            //if ((int)this.TargetSetCd_uOptionSet.Value == 10)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA MODIFY END
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

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA ADD STA
        /// <summary>
        /// 目標設定区分変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TargetSetCd_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // 月間目標
            if (int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString()) == 10)
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
        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA ADD END

	}
}