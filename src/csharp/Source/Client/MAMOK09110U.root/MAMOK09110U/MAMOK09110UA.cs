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
	/// 従業員目標入力画面
	/// </summary>
	/// <remarks>
	/// <br>Note		: 従業員目標入力を行う画面です。</br>
	/// <br>Programmer	: NEPCO</br>
	/// <br>Date		: 2007.04.23</br>
	/// <br>Update Note : 2007.11.21 30167 上野　弘貴</br>
	/// <br> 			  流通.DC用に変更（項目追加・削除）</br>
	/// <br>Update Note : 2008.03.03 30167 上野　弘貴</br>
	/// <br>			  項目ゼロ埋め対応（画面デザインにコンポーネント追加、
	///					  Tedit、TNeditの設定変更）</br>
	/// <br>Update Note : 2008.03.06 30167 上野　弘貴</br>
	///	<br>		 	  ショートカットキーエラーチェック対応追加</br>
	/// <br>Update Note: 2008.03.07 30167 上野　弘貴</br>
	///					・項目クリア後エンターキーで次項目へ移動するよう修正</br>
	/// <br>Update Note: 2008.03.12 30167 上野　弘貴</br>
	///					・課ガイド、部門ガイド拠点絞り込み漏れ修正</br>
	/// </remarks>
	public partial class MAMOK09110UA : Form
	{
		# region Private Constants

		// PG名称
		private const string ctPGNM = "従業員目標入力";

		//----- ueno del---------- start 2007.11.21
		// 比率
        //private const string RATIO_DEFAULT = "1.00";
		//----- ueno del---------- end   2007.11.21

        // 書式
        private const string FORMAT_NUM = "###,##0";
        private const string FORMAT_NUM_DECIMAL = "N1";

		// 拠点目標用従業員コード
		private const string EMPLOYEECODE_SECTION = "SECTION";

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

//----- ueno add---------- start 2007.11.21
		// 部門コード（ワーク）
		private int _subSectionCodeWork = 0;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
		// 課コード（ワーク）
		//private int _minSectionCodeWork = 0;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
		
		// 従業員コード（ワーク）
		private string _employeeCodeWork = "";

		// 目標対比区分ワーク
		private int _targetContrastCd_tComboEditorValue = -1;

//----- ueno add---------- end   2007.11.21

		//----- ueno add---------- start 2008.03.06
		// 文字列結合用
		private StringBuilder _stringBuilder = null;

		// 部門アクセスクラス
		SubSectionAcs _subSectionAcs = null;
		
		// 課アクセスクラス
		MinSectionAcs _minSectionAcs = null;
		
		// 従業員アクセスクラス
		EmployeeAcs _employeeAcs = null;
		//----- ueno add---------- end 2008.03.06

		//----- ueno del---------- start 2007.11.21
		//// 休業日設定マスタ
		//private Dictionary<SectionAndDate, HolidaySetting> _holidaySettingDic;

		//// 着地計算比率リスト
		//private List<LdgCalcRatioMng> _ldgCalcRatioMngList;
		//----- ueno del---------- end   2007.11.21

		// 目標設定区分
		private int _targetSetCd;
		// 目標対比区分
		private int _targetContrastCd;

		// 期間（開始）
		private DateTime _targetStaDate;
		// 期間（終了）
		private DateTime _targetEndDate;

		// モード(新規 or 編集)
		private int _mode;

		private bool _searchFlag;

		/// <summary>画面デザイン変更クラス</summary>
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		# endregion Private Members

		# region Constructor

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MAMOK09110UA()
		{
			InitializeComponent();

			// 企業コードを取得
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA DEL START
            // _Loadに移行
			// 拠点名称取得
            //SecInfoSet secInfoSet;
            //SecInfoAcs secInfoAcs = new SecInfoAcs();
            //secInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);
            //this._sectionCode = secInfoSet.SectionCode;
            //this._sectionName = secInfoSet.SectionGuideNm.TrimEnd();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA DEL END

			this._salesTargetAcs = new SalesTargetAcs();

			//----- ueno add---------- start 2008.03.06
			// 部門アクセスクラス
			this._subSectionAcs = new SubSectionAcs();

			// 課アクセスクラス
			this._minSectionAcs = new MinSectionAcs();

			// 従業員アクセスクラス
			this._employeeAcs = new EmployeeAcs();

			// 文字列結合用
			this._stringBuilder = new StringBuilder();
			//----- ueno add---------- end 2008.03.06

			// アイコン画像の設定
//----- ueno add---------- start 2007.11.21		
			// 部門コードガイドボタン
			this.SubSectionCodeGuide_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA DEL START
            //// 課コードガイドボタン
            //this.MinSectionCodeGuide_Button.Appearance.Image
            //    = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA DEL END

//----- ueno add---------- end   2007.11.21

			// 従業員ガイドボタン
			this.EmployeeCodeGuide_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
			// 終了ボタン
			this.Close_Button.Appearance.Image
				= IconResourceManagement.ImageList24.Images[(int)Size24_Index.CLOSE];
			// 保存ボタン
			this.Save_Button.Appearance.Image
				= IconResourceManagement.ImageList24.Images[(int)Size24_Index.SAVE];
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

		/////*----------------------------------------------------------------------------------*/
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
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
			//this.TargetSetCd_uOptionSet.Value = salesTarget.TargetSetCd;
            //this.TargetSetCd_tComboEditor.SelectedItem.DataValue = salesTarget.TargetSetCd;
            if (salesTarget.TargetSetCd == 10)
            {
                this.TargetSetCd_tComboEditor.SelectedIndex = 0;
            }
            else
            {
                this.TargetSetCd_tComboEditor.SelectedIndex = 1;
            }
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

//----- ueno add---------- start 2007.11.21

			// 従業員区分
			if (salesTarget.EmployeeDivCd != 0)
			{
				// 0以外の場合は新規以外なので、取得したデータを設定する
				this.EmployeeDivCd_tComboEditor.Value = salesTarget.EmployeeDivCd; 
			}
			else
			{
				// 0の場合は新規なのでコンボボックスデフォルト値を設定する
				salesTarget.EmployeeDivCd = (int)this.EmployeeDivCd_tComboEditor.Value;
			}

			// 部門コード
			this.SubSectionCode_tNedit.SetInt(salesTarget.SubSectionCode);
			
			// 部門名称
			this.SubSectionCodeNm_tEdit.DataText = GetSubSectionName(salesTarget.SubSectionCode);
			
			// 課コード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
			//this.MinSectionCode_tNedit.SetInt(salesTarget.MinSectionCode);

            // 課名称
			//this.MinSectionCodeNm_tEdit.DataText = GetMinSectionName(salesTarget.SubSectionCode, salesTarget.MinSectionCode);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA DEL END

			
//----- ueno add---------- end   2007.11.21

			// 従業員コード
			this.EmployeeCode_tEdit.DataText = salesTarget.EmployeeCode;
			// 従業員名称
			this.EmployeeName_tEdit.DataText = salesTarget.EmployeeName;
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
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
			//salesTarget.TargetSetCd = (int)TargetSetCd_uOptionSet.Value;
            salesTarget.TargetSetCd = int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString());
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

//----- ueno add---------- start 2007.11.21
			// 従業員区分
			salesTarget.EmployeeDivCd = (int)this.EmployeeDivCd_tComboEditor.Value;
			
			// 部門コード
			salesTarget.SubSectionCode = this.SubSectionCode_tNedit.GetInt();
			
			// 課コード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
			//salesTarget.MinSectionCode = this.MinSectionCode_tNedit.GetInt();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
//----- ueno add---------- end   2007.11.21

			// 従業員コード
			if (this._targetContrastCd == (int)SalesTarget.ConstrastCd.Section)
			{
				// 拠点目標
				salesTarget.EmployeeCode = EMPLOYEECODE_SECTION;
			}
			else
			{
				// 従業員目標
				salesTarget.EmployeeCode = this.EmployeeCode_tEdit.DataText;
			}
			// 従業員名称
			salesTarget.EmployeeName = this.EmployeeName_tEdit.DataText;
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

				// 従業員目標（20:拠点+部門, 21:拠点+部門+課, 22:拠点+従業員）
				//----- ueno upd---------- start 2007.11.21
				if ((this._targetContrastCd == (int)SalesTarget.ConstrastCd.SecAndSubSec)
					//|| (this._targetContrastCd == (int)SalesTarget.ConstrastCd.SecAndSubSecAndMinSec)
					|| (this._targetContrastCd == (int)SalesTarget.ConstrastCd.SecAndEmp))
				//----- ueno upd---------- end   2007.11.21
				{
//----- ueno add---------- start 2007.11.21　
					
					// 目標対比区分によりチェック変更
					switch((int)this.TargetContrastCd_tComboEditor.Value)
					{
						case (int)SalesTarget.ConstrastCd.SecAndSubSec:				// 20:拠点＋部門
							{
								// 部門コード
								if ((this.SubSectionCode_tNedit.DataText == "") || (this.SubSectionCode_tNedit.GetInt() == 0))
								{
									errMsg = "部門コードを入力してください";
									this.SubSectionCode_tNedit.Focus();

									//----- ueno add ---------- start 2008.03.06
									this.SubSectionCodeNm_tEdit.Clear();	// 部門名称クリア
									this._subSectionCodeWork = 0;			// 部門コードワーククリア

                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
									//this.MinSectionCode_tNedit.Clear();		// 課コードクリア
									//this.MinSectionCodeNm_tEdit.Clear();	// 課名称クリア
									//this._minSectionCodeWork = 0;			// 課コードワーククリア
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
									//----- ueno add ---------- end 2008.03.06
									
									return (false);
								}
								break;
							}
                        //case (int)SalesTarget.ConstrastCd.SecAndSubSecAndMinSec:	// 21:拠点＋部門＋課
                        //    {
                        //        // 部門コード
                        //        if ((this.SubSectionCode_tNedit.DataText == "") || (this.SubSectionCode_tNedit.GetInt() == 0))
                        //        {
                        //            errMsg = "部門コードを入力してください";
                        //            this.SubSectionCode_tNedit.Focus();

                        //            //----- ueno add ---------- start 2008.03.06
                        //            this.SubSectionCodeNm_tEdit.Clear();	// 部門名称クリア
                        //            this._subSectionCodeWork = 0;			// 部門コードワーククリア

                        //            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
                        //            //this.MinSectionCode_tNedit.Clear();		// 課コードクリア
                        //            //this.MinSectionCodeNm_tEdit.Clear();	// 課名称クリア
                        //            //this._minSectionCodeWork = 0;			// 課コードワーククリア
                        //            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
                        //            //----- ueno add ---------- end 2008.03.06

                        //            return (false);
                        //        }
                        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
                        //        //// 課コード
                        //        //if ((this.MinSectionCode_tNedit.DataText == "") || (this.MinSectionCode_tNedit.GetInt() == 0))
                        //        //{
                        //        //    errMsg = "課コードを入力してください";
                        //        //    this.MinSectionCode_tNedit.Focus();

                        //        //    //----- ueno add ---------- start 2008.03.06
                        //        //    this.MinSectionCodeNm_tEdit.Clear();	// 課名称クリア
                        //        //    this._minSectionCodeWork = 0;			// 課コードワーククリア
                        //        //    //----- ueno add ---------- end 2008.03.06

                        //        //    return (false);
                        //        //}
                        //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
                        //        break;
                        //    }
						case (int)SalesTarget.ConstrastCd.SecAndEmp:	// 22:拠点＋従業員
							{
								if (this.EmployeeCode_tEdit.DataText == "")
								{
									errMsg = "従業員コードを入力してください";
									this.EmployeeCode_tEdit.Focus();

									//----- ueno add ---------- start 2008.03.06
									this.EmployeeName_tEdit.Clear();	// 従業員名称クリア
									this._employeeCodeWork = "";		// 従業員コードワーククリア
									//----- ueno add ---------- end 2008.03.06

									return (false);
								}

								#region del 2008.03.06
								//----- ueno del ---------- start 2008.03.06
								//--- 従業員チェックはこの下へ移動したので、ここは削除する
								//Employee employee;
								//EmployeeAcs employeeAcs = new EmployeeAcs();
								//string employeeCode = this.EmployeeCode_tEdit.DataText;

								//employeeAcs.Read(out employee, this._enterpriseCode, employeeCode);
								//if (employee == null)
								//{
								//    errMsg = "従業員コード [" + employeeCode + "] に該当するデータが存在しません";
								//    this.EmployeeCode_tEdit.Focus();
								//    return (false);
								//}

								//if (employee.BelongSectionCode.TrimEnd() != this._salesTarget.SectionCode.TrimEnd())
								//{
								//    errMsg = employee.Name.TrimEnd() + "さん" + "[" + employeeCode + "] は、" + this._sectionName + "に所属しておりません";
								//    this.EmployeeCode_tEdit.Focus();
								//    return (false);
								//}
								//----- ueno del ---------- end 2008.03.06
								#endregion del 2008.03.06

								break;
							}
					}

//----- ueno add---------- end   2007.11.21

					#region mov 2007.11.21
					//----- ueno mov---------- start 2007.11.21
					// 上記の目標対比区分の条件に追加した
					//if (this.EmployeeCode_tEdit.DataText == "")
					//{
					//    errMsg = "従業員コードを入力してください";
					//    this.EmployeeCode_tEdit.Focus();
					//    return (false);
					//}
					//Employee employee;
					//EmployeeAcs employeeAcs = new EmployeeAcs();
					//string employeeCode = this.EmployeeCode_tEdit.DataText;

					//employeeAcs.Read(out employee, this._enterpriseCode, employeeCode);
					//if (employee == null)
					//{
					//    errMsg = "従業員コード [" + employeeCode + "] に該当するデータが存在しません";
					//    this.EmployeeCode_tEdit.Focus();
					//    return (false);
					//}

					//if (employee.BelongSectionCode.TrimEnd() != this._salesTarget.SectionCode.TrimEnd())
					//{
					//    errMsg = employee.Name.TrimEnd() + "さん" + "[" + employeeCode + "] は、" + this._sectionName + "に所属しておりません";
					//    this.EmployeeCode_tEdit.Focus();
					//    return (false);
					//}
					//----- ueno mov---------- end   2007.11.21
					#endregion mov 2007.11.21
				}

				//----- ueno add ---------- start 2008.03.06
				DispSetStatus dispSetStatus = DispSetStatus.Clear;

				bool canChangeFocus = true;
				object inParamObj = null;
				object outParamObj = null;
				ArrayList inParamList = null;

				//------------------------
				// 部門コードチェック
				//------------------------
				if (this.SubSectionCode_tNedit.Enabled == true)
				{
					// 条件設定クリア
					inParamObj = null;
					outParamObj = null;
					inParamList = new ArrayList();

					dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用
					
					// 条件設定
					inParamList.Add(this._sectionCode);
					inParamList.Add(this.SubSectionCode_tNedit.GetInt());
					inParamObj = inParamList;

					// 存在チェック
					switch (CheckSubSectionCode(inParamObj, out outParamObj))
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
								errMsg = ShowNotFoundErrMsg("部門コード");
								dispSetStatus = this._subSectionCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
								break;
							}
					}
					// データ設定
					DispSetSubSectionCode(dispSetStatus, ref canChangeFocus, outParamObj);

					if (dispSetStatus != DispSetStatus.Update)
					{
						this.SubSectionCode_tNedit.Focus();
						return false;
					}
                }

                #region del 2008.07.03
                //------------------------
				// 課コードチェック
				//------------------------
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
                //if (this.MinSectionCode_tNedit.Enabled == true)
                //{
                //    // 条件設定クリア
                //    inParamObj = null;
                //    outParamObj = null;
                //    inParamList = new ArrayList();

                //    dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用
					
                //    // 条件設定
                //    inParamList.Add(this._sectionCode);
                //    inParamList.Add(this.SubSectionCode_tNedit.GetInt());
                //    inParamList.Add(this.MinSectionCode_tNedit.GetInt());
                //    inParamObj = inParamList;

                //    // 存在チェック
                //    switch (CheckMinSectionCode(inParamObj, out outParamObj))
                //    {
                //        case (int)InputChkStatus.Normal:
                //            {
                //                dispSetStatus = DispSetStatus.Update;
                //                break;
                //            }
                //        case (int)InputChkStatus.NotInput:
                //            {
                //                dispSetStatus = DispSetStatus.Clear;
                //                break;
                //            }
                //        default:
                //            {
                //                errMsg = ShowNotFoundErrMsg("課コード");
                //                dispSetStatus = this._minSectionCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
                //                break;
                //            }
                //    }
                //    // データ設定
                //    DispSetMinSectionCode(dispSetStatus, ref canChangeFocus, outParamObj);

                //    if (dispSetStatus != DispSetStatus.Update)
                //    {
                //        this.MinSectionCode_tNedit.Focus();
                //        return false;
                //    }
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
                #endregion // del 2008.07.03

                //------------------------
				// 従業員コードチェック
				//------------------------
				if (this.EmployeeCode_tEdit.Enabled == true)
				{
					// 条件設定クリア
					inParamObj = null;
					outParamObj = null;
					inParamList = new ArrayList();

					dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用

					// 条件設定
					inParamObj = this.EmployeeCode_tEdit.Text;

					// 存在チェック
					switch (CheckEmployeeCode(inParamObj, out outParamObj))
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
								errMsg = ShowNotFoundErrMsg("従業員コード");
								dispSetStatus = this._employeeCodeWork == "" ? DispSetStatus.Clear : DispSetStatus.Back;
								break;
							}
					}
					// データ設定
					DispSetEmployeeCode(dispSetStatus, ref canChangeFocus, outParamObj);

					if (dispSetStatus != DispSetStatus.Update)
					{
						this.EmployeeCode_tEdit.Focus();
						return false;
					}
				}
				//----- ueno add ---------- end 2008.03.06
				
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
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.23</br>
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
		///// 従業員検索処理
		///// </summary>
		///// <param name="employeeCode">従業員コード</param>
		///// <remarks>
		///// <br>Note		: 従業員を検索します。</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.04.18</br>
		///// </remarks>
		//private int SearchEmployee(string employeeCode)
		//{
		//    Employee employee;
		//    EmployeeAcs employeeAcs = new EmployeeAcs();

		//    employeeAcs.Read(out employee, this._enterpriseCode, employeeCode);

		//    if (employee == null)
		//    {
		//        this.EmployeeName_tEdit.DataText = "";
		//        return (1);
		//    }

		//    this.EmployeeName_tEdit.DataText = employee.Name;
		//    return (0);
		//}

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
			//----- ueno del ---------- start 2008.03.06
			//-- 画面の設定は全て画面デザインで行うので以下削除
			//this.SectionName_tEdit.Size = new Size(179, 24);
			//this.TargetDivideCode_tEdit.Size = new Size(84, 24);
			//this.TargetDivideName_tEdit.Size = new Size(290, 24);
			//this.EmployeeCode_tEdit.Size = new Size(84, 24);
			//this.EmployeeName_tEdit.Size = new Size(290, 24);
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

			//----- ueno del ---------- start 2008.03.06
			// 項目の最大入力可能桁数は画面デザインで設定する
			//this.TargetDivideCode_tEdit.MaxLength = 9;
			//this.TargetDivideName_tEdit.MaxLength = 30;
			//this.EmployeeCode_tEdit.MaxLength = 9;
			//this.EmployeeName_tEdit.MaxLength = 30;
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
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.12</br>
		/// </remarks>
		private void ControlEnabled()
		{
			// コントロールVisible制御
			// 拠点目標
			if (this._targetContrastCd == (int)SalesTarget.ConstrastCd.Section)
			{
				this.Text = "拠点目標";
//----- ueno add---------- start 2007.11.21
				this.TargetContrastCd_uLabel.Visible = false;
				this.TargetContrastCd_tComboEditor.Visible = false;
				this.EmployeeDivCd_uLabel.Visible = false;
				this.EmployeeDivCd_tComboEditor.Visible = false;
				this.SubSectionCode_uLabel.Visible = false;
				this.SubSectionCode_tNedit.Visible = false;
				this.SubSectionCodeNm_tEdit.Visible = false;
				this.SubSectionCodeGuide_Button.Visible = false;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
				//this.MinSectionCode_uLabel.Visible = false;
				//this.MinSectionCode_tNedit.Visible = false;
				//this.MinSectionCodeNm_tEdit.Visible = false;
				//this.MinSectionCodeGuide_Button.Visible = false;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
//----- ueno add---------- end   2007.11.21
				this.EmployeeCode_uLabel.Visible = false;
				this.EmployeeCode_tEdit.Visible = false;
				this.EmployeeName_tEdit.Visible = false;
				this.EmployeeCodeGuide_Button.Visible = false;
			}
			// 従業員目標
			else
			{
//----- ueno add---------- start 2007.11.21
				this.TargetContrastCd_uLabel.Visible = true;
				this.TargetContrastCd_tComboEditor.Visible = true;
				this.EmployeeDivCd_uLabel.Visible = true;
				this.EmployeeDivCd_tComboEditor.Visible = true;
				this.SubSectionCode_uLabel.Visible = true;
				this.SubSectionCode_tNedit.Visible = true;
				this.SubSectionCodeNm_tEdit.Visible = true;
				this.SubSectionCodeGuide_Button.Visible = true;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
				//this.MinSectionCode_uLabel.Visible = true;
				//this.MinSectionCode_tNedit.Visible = true;
				//this.MinSectionCodeNm_tEdit.Visible = true;
				//this.MinSectionCodeGuide_Button.Visible = true;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
//----- ueno add---------- end   2007.11.21
				this.Text = "従業員目標";
				this.EmployeeCode_uLabel.Visible = true;
				this.EmployeeCode_tEdit.Visible = true;
				this.EmployeeName_tEdit.Visible = true;
				this.EmployeeCodeGuide_Button.Visible = true;
			}

			// 月間目標
			if (this._targetSetCd == 10)
			{
				this.ApplyDate_uLabel.Text = "適用年月";
				this.ApplyStaDate_tDateEdit.DateFormat = emDateFormat.df4Y2M;
				this.Range_uLabel.Visible = false;
				this.ApplyEndDate_tDateEdit.Visible = false;
//----- ueno add---------- start 2007.11.21
				this.TargetDivideCode_uLabel.Visible = false;
				this.TargetDivideCode_tEdit.Visible = false;
				this.TargetDivideName_uLabel.Visible = false;
				this.TargetDivideName_tEdit.Visible = false;
//----- ueno add---------- end   2007.11.21
			}
			// 個別期間目標
			else
			{
				this.ApplyDate_uLabel.Text = "適用期間";
				this.ApplyStaDate_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
				this.Range_uLabel.Visible = true;
				this.ApplyEndDate_tDateEdit.Visible = true;
//----- ueno add---------- start 2007.11.21
				this.TargetDivideCode_uLabel.Visible = true;
				this.TargetDivideCode_tEdit.Visible = true;
				this.TargetDivideName_uLabel.Visible = true;
				this.TargetDivideName_tEdit.Visible = true;
//----- ueno add---------- end   2007.11.21
			}

			// コントロールEnabled制御
			// 新規モード
			if (this._mode == 0)
			{
				this.Mode_Label.Text = "新規";
//----- ueno upd---------- start 2007.11.21
				this.TargetContrastCd_tComboEditor.Enabled = true;
				this.EmployeeDivCd_tComboEditor.Enabled = true;
				
				// 目標対比区分コンボボックス値で判定する
				if (this.TargetContrastCd_tComboEditor.Value != null)
				{
					TargetContrastCdChange((Int32)this.TargetContrastCd_tComboEditor.Value);
				}
				//this.SubSectionCode_tNedit.Enabled = false;
				//this.SubSectionCodeGuide_Button.Enabled = false;
				//this.MinSectionCode_tNedit.Enabled = false;
				//this.MinSectionCodeGuide_Button.Enabled = false;
				//this.EmployeeCode_tEdit.Enabled = true;
				//this.EmployeeCodeGuide_Button.Enabled = true;
//----- ueno upd---------- end   2007.11.21
				this.ApplyStaDate_tDateEdit.Enabled = true;
				this.ApplyEndDate_tDateEdit.Enabled = true;

				// 月間目標
				if (this._targetSetCd == 10)
				{
					this.TargetDivideCode_tEdit.Enabled = false;
					this.TargetDivideName_tEdit.Enabled = false;
				}
				// 個別期間目標
				else
				{
					this.TargetDivideCode_tEdit.Enabled = true;
					this.TargetDivideName_tEdit.Enabled = true;
				}

                // 検索後の新規モードだった場合
                if (this._searchFlag == true)
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
                    //this.TargetSetCd_uOptionSet.Enabled = false;
                    this.TargetSetCd_tComboEditor.Enabled = false;
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
					//this.TargetSetCd_uOptionSet.Enabled = true;
                    this.TargetSetCd_tComboEditor.Enabled = true;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA MODIFY END
				}

				if (this._targetContrastCd == (int)SalesTarget.ConstrastCd.Section)
				{
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
                    this.TargetSetCd_tComboEditor.Enabled = false;
                    //this.TargetSetCd_uOptionSet.Enabled = false;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA MODIFY END
				}
			}
			// 編集モード
			else if (this._mode == 1)
			{
				this.Mode_Label.Text = "編集";
				this.ApplyStaDate_tDateEdit.Enabled = false;
				this.ApplyEndDate_tDateEdit.Enabled = false;
//----- ueno add---------- start 2007.11.21
				this.TargetContrastCd_tComboEditor.Enabled = false;
				this.EmployeeDivCd_tComboEditor.Enabled = false;
				this.SubSectionCode_tNedit.Enabled = false;
				this.SubSectionCodeGuide_Button.Enabled = false;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
				//this.MinSectionCode_tNedit.Enabled = false;
				//this.MinSectionCodeGuide_Button.Enabled = false;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
//----- ueno add---------- end   2007.11.21
				this.EmployeeCode_tEdit.Enabled = false;
				this.EmployeeCodeGuide_Button.Enabled = false;
				this.TargetDivideCode_tEdit.Enabled = false;
				this.TargetDivideName_tEdit.Enabled = false;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
                this.TargetSetCd_tComboEditor.Enabled = false;
                //this.TargetSetCd_uOptionSet.Enabled = false;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA MODIFY END
			}
			else
			{
				this.Mode_Label.Text = "参照";
				this.ApplyStaDate_tDateEdit.Enabled = false;
				this.ApplyEndDate_tDateEdit.Enabled = false;
				this.TargetDivideCode_tEdit.Enabled = false;
				this.TargetDivideName_tEdit.Enabled = false;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
                this.TargetSetCd_tComboEditor.Enabled = false;
                //this.TargetSetCd_uOptionSet.Enabled = false;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA MODIFY END
				this.SalesTargetMoney_tNedit.Enabled = false;
				this.SalesTargetProfit_tNedit.Enabled = false;
				this.SalesTargetCount_tNedit.Enabled = false;
				this.Save_Button.Visible = false;
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

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 部門名称取得処理
		/// </summary>
		/// <param name="subSectionCode">部門コード</param>
		/// <return>部門名称</return>
		/// <remarks>
		/// Note	   : 部門名称を取得します。<br />
		/// Programmer : 30167 上野　弘貴<br />
		/// Date	   : 2007.11.21<br />
		/// </remarks>
		private string GetSubSectionName(int subSectionCode)
		{
			SubSection subSection = null;
			string subSectionName = "";

			SubSectionAcs subSectionAcs = new SubSectionAcs();

			// データ存在チェック
			int ret = subSectionAcs.Read(out subSection, this._enterpriseCode, this._sectionCode, subSectionCode);
			if (ret == 0)
			{
				subSectionName = subSection.SubSectionName;
			}
			return subSectionName;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 課名称取得処理
		/// </summary>
		/// <param name="subSectionCode">部門コード</param>
		/// <param name="minSectionCode">課コード</param>
		/// <return>課名称</return>
		/// <remarks>
		/// Note	   : 課名称を取得します。<br />
		/// Programmer : 30167 上野　弘貴<br />
		/// Date	   : 2007.11.21<br />
		/// </remarks>
		private string GetMinSectionName(int subSectionCode, int minSectionCode)
		{
			MinSection minSection = null;
			string minSectionName = "";

			MinSectionAcs minSectionAcs = new MinSectionAcs();

			// データ存在チェック
			int ret = minSectionAcs.Read(out minSection, this._enterpriseCode, this._sectionCode, subSectionCode, minSectionCode);
			if (ret == 0)
			{
				minSectionName = minSection.MinSectionName;
			}
			return minSectionName;
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
			
			switch(targetContrastCd)
			{
				case (int)SalesTarget.ConstrastCd.SecAndSubSec:					// 20:拠点＋部門
					{
						this.SubSectionCode_tNedit.Enabled			= true;		// 部門コード
						this.SubSectionCodeGuide_Button.Enabled		= true;		// 部門ガイド
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
						//this.MinSectionCode_tNedit.Enabled			= false;	// 課
						//this.MinSectionCodeGuide_Button.Enabled		= false;	// 課ガイド
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
						this.EmployeeCode_tEdit.Enabled				= false;	// 従業員コード
						this.EmployeeCodeGuide_Button.Enabled		= false;	// 従業員ガイド
						
						// 入力不可項目クリア
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
						//this.MinSectionCode_tNedit.Clear();
						//this.MinSectionCodeNm_tEdit.Clear();
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
						this.EmployeeCode_tEdit.Clear();
						this.EmployeeName_tEdit.Clear();
						break;
					}
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
                //case (int)SalesTarget.ConstrastCd.SecAndSubSecAndMinSec:		// 21:拠点＋部門＋課
                //    {
                //        this.SubSectionCode_tNedit.Enabled			= true;		// 部門コード
                //        this.SubSectionCodeGuide_Button.Enabled		= true;		// 部門ガイド
                //        this.MinSectionCode_tNedit.Enabled			= true;		// 課
                //        this.MinSectionCodeGuide_Button.Enabled		= true;		// 課ガイド
                //        this.EmployeeCode_tEdit.Enabled				= false;	// 従業員コード
                //        this.EmployeeCodeGuide_Button.Enabled		= false;	// 従業員ガイド

                //        // 入力不可項目クリア
                //        this.EmployeeCode_tEdit.Clear();
                //        this.EmployeeName_tEdit.Clear();
                //        break;
                //    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
				case (int)SalesTarget.ConstrastCd.SecAndEmp:					// 22:拠点＋従業員
					{
						this.SubSectionCode_tNedit.Enabled			= false;	// 部門コード
						this.SubSectionCodeGuide_Button.Enabled		= false;	// 部門ガイド
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
						//this.MinSectionCode_tNedit.Enabled			= false;	// 課
						//this.MinSectionCodeGuide_Button.Enabled		= false;	// 課ガイド
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
						this.EmployeeCode_tEdit.Enabled				= true;		// 従業員コード
						this.EmployeeCodeGuide_Button.Enabled		= true;		// 従業員ガイド

						// 入力不可項目クリア
						this.SubSectionCode_tNedit.Clear();
						this.SubSectionCodeNm_tEdit.Clear();
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
						//this.MinSectionCode_tNedit.Clear();
						//this.MinSectionCodeNm_tEdit.Clear();
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
						break;
					}
			}
			// 選択した番号を保持
			this._targetContrastCd_tComboEditorValue = targetContrastCd;
		}

//----- ueno add---------- end   2007.11.21

		//----- ueno add---------- start 2008.03.06
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

		#region 部門コードエラーチェック処理
		/// <summary>
		/// 部門コードエラーチェック処理
		/// </summary>
		/// <param name="inParamObj">条件オブジェクト</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
		/// <remarks>
		/// <br>Note       : 部門コードエラーチェックを行います。
		///					 条件オブジェクト:拠点コード, 部門コード
		///					 結果オブジェクト:部門マスタ検索結果ステータス, 部門名称</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.03.06</br>
		/// </remarks>
		private int CheckSubSectionCode(object inParamObj, out object outParamObj)
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
				if (inParamObj == null)									return ret;
				if ((inParamObj is ArrayList) == false)					return ret;

				inParamList = inParamObj as ArrayList;	// ArrayListへキャスト

				if ((inParamList == null) || (inParamList.Count != 2))	return ret;
				if ((inParamList[0] is string) == false)				return ret;
				if ((inParamList[1] is int) == false)					return ret;
				if ((int)inParamList[1] == 0)							return ret;
				
				//--------------
				// 存在チェック
				//--------------
				SubSection subSection = null;
						
				this.Cursor = Cursors.WaitCursor;
				status = this._subSectionAcs.Read(out subSection, this._enterpriseCode, (string)inParamList[0], (int)inParamList[1]);
				this.Cursor = Cursors.Default;
				
				outParamList.Add(status);	// 部門マスタステータス設定
				
				if(subSection == null)
				{
					ret = (int)InputChkStatus.NotExist;
				}
				else
				{
					ret = (int)InputChkStatus.Normal;
					outParamList.Add(subSection.SubSectionName);	// 部門名称設定
				}
			}
			catch (Exception)
			{
			}
			outParamObj = outParamList;

			return ret;
		}
		#endregion 部門コードエラーチェック処理

		#region 課コードエラーチェック処理
		/// <summary>
		/// 課コードエラーチェック処理
		/// </summary>
		/// <param name="inParamObj">条件オブジェクト</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
		/// <remarks>
		/// <br>Note       : 課コードのエラーチェックを行います。
		///					 条件オブジェクト:拠点コード, 部門コード, 課コード
		///					 結果オブジェクト:課マスタ検索結果ステータス, 課コード, 課名称, 部門コード, 部門名称</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.03.06</br>
		/// </remarks>
		private int CheckMinSectionCode(object inParamObj, out object outParamObj)
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
				if (inParamObj == null)									return ret;
				if ((inParamObj is ArrayList) == false)					return ret;

				inParamList = inParamObj as ArrayList;	// ArrayListへキャスト

				if ((inParamList == null) || (inParamList.Count != 3))	return ret;
				if ((inParamList[0] is string) == false)				return ret;
				if ((inParamList[1] is int) == false)					return ret;
				if ((inParamList[2] is int) == false)					return ret;
				if ((int)inParamList[2] == 0)							return ret;

				//--------------
				// 存在チェック
				//--------------
				MinSection minSection = null;

				this.Cursor = Cursors.WaitCursor;
				status = this._minSectionAcs.Read(out minSection, this._enterpriseCode, (string)inParamList[0],
												(int)inParamList[1], (int)inParamList[2]);
				this.Cursor = Cursors.Default;

				outParamList.Add(status);	// 課マスタステータス設定

				if (minSection == null)
				{
					ret = (int)InputChkStatus.NotExist;
				}
				else
				{
					ret = (int)InputChkStatus.Normal;

					outParamList.Add(minSection.MinSectionCode);	// 課コード設定
					outParamList.Add(minSection.MinSectionName);	// 課名称設定
					outParamList.Add(minSection.SubSectionCode);	// 部門コード設定
					outParamList.Add(minSection.SubSectionName);	// 部門名称設定
				}
			}
			catch (Exception)
			{
			}
			outParamObj = outParamList;

			return ret;
		}
		#endregion 課コードエラーチェック処理

		#region 従業員コードエラーチェック処理
		/// <summary>
		/// 従業員コードエラーチェック処理
		/// </summary>
		/// <param name="inParamObj">条件オブジェクト</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
		/// <remarks>
		/// <br>Note       : メーカーコードのエラーチェックを行います。
		///					 条件オブジェクト:従業員コード
		///					 結果オブジェクト:従業員マスタ検索結果ステータス, 従業員名称</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.03.06</br>
		/// </remarks>
		private int CheckEmployeeCode(object inParamObj, out object outParamObj)
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
				if (inParamObj == null)					return ret;
				if ((inParamObj is string) == false)	return ret;
				if ((string)inParamObj == "")			return ret;
				
				//--------------
				// 存在チェック
				//--------------
				Employee employee = null;

			    this.Cursor = Cursors.WaitCursor;
				status = this._employeeAcs.Read(out employee, this._enterpriseCode, (string)inParamObj);
			    this.Cursor = Cursors.Default;

				outParamList.Add(status);	// 従業員マスタステータス設定

				if (employee == null)
				{
					ret = (int)InputChkStatus.NotExist;
				}
				else
				{
					//----- ueno upd ---------- start 2008.03.06
					// 従業員が拠点に所属しているかチェック
					if (employee.BelongSectionCode.TrimEnd() == this._salesTarget.SectionCode.TrimEnd())
					{
						ret = (int)InputChkStatus.Normal;
						outParamList.Add(employee.Name);	// 従業員名称設定
					}
					else
					{
						ret = (int)InputChkStatus.NotExist;
					}
					//----- ueno upd ---------- end 2008.03.06
				}
			}
			catch(Exception)
			{
			}
			outParamObj = outParamList;
			
			return ret;
		}
		#endregion 従業員コードエラーチェック処理

		#region 部門コード設定処理
		/// <summary>
		/// 部門コード設定処理
		/// </summary>
		/// <param name="dispSetStatus">入力チェックフラグ</param>
		/// <param name="canChangeFocus">フォーカスフラグ</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 部門コードを画面に設定します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.03.06</br>
		/// </remarks>
		private void DispSetSubSectionCode(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
		{
			ArrayList outParamList = null;

			try
			{
				switch (dispSetStatus)
				{
					case DispSetStatus.Clear:	// データクリア
						{
							this.SubSectionCode_tNedit.Clear();
							this.SubSectionCodeNm_tEdit.Clear();

							// 現在データクリア
							this._subSectionCodeWork = 0;
							
							// 課コードクリア
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
							//this.MinSectionCode_tNedit.Clear();
							//this.MinSectionCodeNm_tEdit.Clear();
							//this._minSectionCodeWork = 0;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END

							//----- ueno upd ---------- start 2008.03.07
							// フォーカス
							canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
							//----- ueno upd ---------- end 2008.03.07

							break;
						}
					case DispSetStatus.Back:		// 元に戻す
						{
							this.SubSectionCode_tNedit.SetInt(this._subSectionCodeWork);

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
									this.SubSectionCodeNm_tEdit.Text = (string)outParamList[1];	// 部門名称
									
									//----------------------------
									// 部門コード変更チェック
									//----------------------------
									if (this._subSectionCodeWork != this.SubSectionCode_tNedit.GetInt())
									{
										// 部門コード変更時は、課コードクリア
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
										//this.MinSectionCode_tNedit.Clear();
										//this.MinSectionCodeNm_tEdit.Clear();
										//this._minSectionCodeWork = 0;
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
									}

									// 現在データ保存
									this._subSectionCodeWork = this.SubSectionCode_tNedit.GetInt();
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
		#endregion 部門コード設定処理

        #region del 2008.07.03
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
        //#region 課コード設定処理
        ///// <summary>
        ///// 課コード設定処理
        ///// </summary>
        ///// <param name="dispSetStatus">入力チェックフラグ</param>
        ///// <param name="canChangeFocus">フォーカスフラグ</param>
        ///// <param name="outParamObj">結果オブジェクト</param>
        ///// <remarks>
        ///// <br>Note       : 課コードを画面に設定します。</br>
        ///// <br>Programmer : 30167 上野　弘貴</br>
        ///// <br>Date       : 2008.03.06</br>
        ///// </remarks>
        //private void DispSetMinSectionCode(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        //{
        //    ArrayList outParamList = null;

        //    try
        //    {
        //        switch (dispSetStatus)
        //        {
        //            case DispSetStatus.Clear:	// データクリア
        //                {
        //                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
        //                    //this.MinSectionCode_tNedit.Clear();
        //                    //this.MinSectionCodeNm_tEdit.Clear();
        //                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END

        //                    // 現在データクリア
        //                    this._minSectionCodeWork = 0;

        //                    //----- ueno upd ---------- start 2008.03.07
        //                    // フォーカス
        //                    canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
        //                    //----- ueno upd ---------- end 2008.03.07

        //                    break;
        //                }
        //            case DispSetStatus.Back:		// 元に戻す
        //                {
        //                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
        //                    //this.MinSectionCode_tNedit.SetInt(this._minSectionCodeWork);
        //                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
							
        //                    //----- ueno add ---------- start 2008.03.07
        //                    // フォーカス移動しない
        //                    canChangeFocus = false;
        //                    //----- ueno add ---------- end 2008.03.07
        //                    break;
        //                }
        //            case DispSetStatus.Update:	// 更新
        //                {
        //                    if ((outParamObj != null) && (outParamObj is ArrayList))
        //                    {
        //                        outParamList = outParamObj as ArrayList;

        //                        if ((outParamList != null)
        //                            && (outParamList.Count == 5)
        //                            && (outParamList[1] is int)
        //                            && (outParamList[2] is string)
        //                            && (outParamList[3] is int)
        //                            && (outParamList[4] is string))
        //                        {
        //                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
        //                            //this.MinSectionCode_tNedit.SetInt((int)outParamList[1]);	// 課コード
        //                            //this.MinSectionCodeNm_tEdit.Text = (string)outParamList[2];	// 課名称
        //                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
        //                            this.SubSectionCode_tNedit.SetInt((int)outParamList[3]);	// 部門コード
        //                            this.SubSectionCodeNm_tEdit.Text = (string)outParamList[4];	// 部門名称

        //                            // 現在データ保存
        //                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
        //                            //this._minSectionCodeWork = this.MinSectionCode_tNedit.GetInt();
        //                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
        //                            this._subSectionCodeWork = this.SubSectionCode_tNedit.GetInt();
        //                        }
        //                    }
        //                    break;
        //                }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}
        //#endregion 課コード設定処理
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
        #endregion // del 2008.07.03

        #region 従業員コード設定処理
        /// <summary>
		/// 従業員コード設定処理
		/// </summary>
		/// <param name="dispSetStatus">入力チェックフラグ</param>
		/// <param name="canChangeFocus">フォーカスフラグ</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 従業員コードを画面に設定します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.03.06</br>
		/// </remarks>
		private void DispSetEmployeeCode(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
		{
			ArrayList outParamList = null;

			try
			{
				switch (dispSetStatus)
				{
					case DispSetStatus.Clear:	// データクリア
						{
							this.EmployeeCode_tEdit.Clear();
							this.EmployeeName_tEdit.Clear();

							// 現在データクリア
							this._employeeCodeWork = "";

							//----- ueno upd ---------- start 2008.03.07
							// フォーカス
							canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
							//----- ueno upd ---------- end 2008.03.07

							break;
						}
					case DispSetStatus.Back:		// 元に戻す
						{
							this.EmployeeCode_tEdit.DataText = this._employeeCodeWork;

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
									this.EmployeeName_tEdit.DataText = (string)outParamList[1];

									// 現在データ保存
									this._employeeCodeWork = this.EmployeeCode_tEdit.DataText;
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
		#endregion 従業員コード設定処理
		//----- ueno add---------- end 2008.03.06

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
				
				#region case 部門コード
				case "SubSectionCode_tNedit":
					{
						// 変更が無ければ処理しない
						if (this.SubSectionCode_tNedit.GetInt() == this._subSectionCodeWork)
						{
							break;
						}

						//--------------
						// 存在チェック
						//--------------
						//----- ueno add ---------- start 2008.03.06
						// 条件設定
						inParamList.Add(this._sectionCode);
						inParamList.Add(this.SubSectionCode_tNedit.GetInt());
						inParamObj = inParamList;
						
						// 存在チェック
						switch (CheckSubSectionCode(inParamObj, out outParamObj))
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
											ShowNotFoundErrMsg("部門コード"),		// 表示するメッセージ
											0,										// ステータス値
											MessageBoxButtons.OK);					// 表示するボタン

									dispSetStatus = this._subSectionCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// データ設定
						DispSetSubSectionCode(dispSetStatus,  ref canChangeFocus, outParamObj);
						//----- ueno add ---------- end 2008.03.06
						
						#region del 2008.03.06
						//----- ueno del ---------- start 2008.03.06
						//SubSection subSection = null;
						
						//if (this.SubSectionCode_tNedit.DataText != "")
						//{
						//    SubSectionAcs subSectionAcs = new SubSectionAcs();
							
						//    // データ存在チェック
						//    this.Cursor = Cursors.WaitCursor;
						//    int ret = subSectionAcs.Read(out subSection, this._enterpriseCode, this._sectionCode,
						//                    this.SubSectionCode_tNedit.GetInt());
						//    this.Cursor = Cursors.Default;
							
						//    if (ret != 0)
						//    {
						//        string errMessage = "指定された条件で、部門コードは存在しませんでした。";
						//        TMsgDisp.Show(
						//                this, 							// 親ウィンドウフォーム
						//                emErrorLevel.ERR_LEVEL_INFO, 	// エラーレベル
						//                this.Name,						// アセンブリID
						//                errMessage, 					// 表示するメッセージ
						//                0,								// ステータス値
						//                MessageBoxButtons.OK);			// 表示するボタン

						//        inputChk = this._subSectionCodeWork == 0 ? InputChk.None : InputChk.Back;
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
						//            this.SubSectionCode_tNedit.Clear();
						//            this.SubSectionCodeNm_tEdit.Clear();

						//            // 現在データクリア
						//            this._subSectionCodeWork = 0;

						//            // フォーカス
						//            e.NextCtrl = e.PrevCtrl;
						//            break;
						//        }
						//    case InputChk.Back:		// 元に戻す
						//        {
						//            this.SubSectionCode_tNedit.SetInt(this._subSectionCodeWork);
						//            break;
						//        }
						//    case InputChk.Update:	// 更新
						//        {
						//            this.SubSectionCodeNm_tEdit.DataText = subSection.SubSectionName;

						//            // 現在データ保存
						//            this._subSectionCodeWork = this.SubSectionCode_tNedit.GetInt();

						//            // 部門コードに紐づく課コードをクリアする
						//            this.MinSectionCode_tNedit.Clear();
						//            this.MinSectionCodeNm_tEdit.Clear();
						//            this._minSectionCodeWork = 0;
						//            break;
						//        }
						//}
						//----- ueno del ---------- start 2008.03.06
						#endregion del 2008.03.06

						break;
					}
				#endregion

                #region del 2008.07.03
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
                //#region case 課コード
                //case "MinSectionCode_tNedit":
                //    {
                //        // 変更が無ければ処理しない
                //        if (this.MinSectionCode_tNedit.GetInt() == this._minSectionCodeWork)
                //        {
                //            break;
                //        }

                //        //--------------
                //        // 存在チェック
                //        //--------------
                //        //----- ueno add ---------- start 2008.03.06
                //        // 条件設定
                //        inParamList.Add(this._sectionCode);
                //        inParamList.Add(this.SubSectionCode_tNedit.GetInt());
                //        inParamList.Add(this.MinSectionCode_tNedit.GetInt());
                //        inParamObj = inParamList;

                //        // 存在チェック
                //        switch (CheckMinSectionCode(inParamObj, out outParamObj))
                //        {
                //            case (int)InputChkStatus.Normal:
                //                {
                //                    dispSetStatus = DispSetStatus.Update;
                //                    break;
                //                }
                //            case (int)InputChkStatus.NotInput:
                //                {
                //                    dispSetStatus = DispSetStatus.Clear;
                //                    break;
                //                }
                //            default:
                //                {
                //                    TMsgDisp.Show(
                //                            this, 									// 親ウィンドウフォーム
                //                            emErrorLevel.ERR_LEVEL_INFO, 			// エラーレベル
                //                            this.Name,								// アセンブリID
                //                            ShowNotFoundErrMsg("課コード"), 		// 表示するメッセージ
                //                            0,										// ステータス値
                //                            MessageBoxButtons.OK);					// 表示するボタン

                //                    dispSetStatus = this._minSectionCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
                //                    break;
                //                }
                //        }
                //        // データ設定
                //        DispSetMinSectionCode(dispSetStatus, ref canChangeFocus, outParamObj);
                //        break;
                //        //----- ueno add ---------- end 2008.03.06

                //        #region del 2008.03.06
                //        //----- ueno del ---------- start 2008.03.06
                //        //MinSection minSection = null;

                //        //if (this.MinSectionCode_tNedit.DataText != "")
                //        //{
                //        //    MinSectionAcs minSectionAcs = new MinSectionAcs();

                //        //    // データ存在チェック
                //        //    this.Cursor = Cursors.WaitCursor;
                //        //    int ret = minSectionAcs.Read(out minSection, this._enterpriseCode, this._sectionCode,
                //        //                this.SubSectionCode_tNedit.GetInt(), this.MinSectionCode_tNedit.GetInt());
                //        //    this.Cursor = Cursors.Default;

                //        //    if (ret != 0)
                //        //    {
                //        //        string errMessage = "指定された条件で、課コードは存在しませんでした。";
                //        //        TMsgDisp.Show(
                //        //                this, 							// 親ウィンドウフォーム
                //        //                emErrorLevel.ERR_LEVEL_INFO, 	// エラーレベル
                //        //                this.Name,						// アセンブリID
                //        //                errMessage, 					// 表示するメッセージ
                //        //                0,								// ステータス値
                //        //                MessageBoxButtons.OK);			// 表示するボタン

                //        //        inputChk = this._minSectionCodeWork == 0 ? InputChk.None : InputChk.Back;
                //        //    }
                //        //    else
                //        //    {
                //        //        inputChk = InputChk.Update;
                //        //    }
                //        //}
                //        //else
                //        //{
                //        //    inputChk = InputChk.None;
                //        //}

                //        ////----------
                //        //// 結果設定
                //        ////----------
                //        //switch (inputChk)
                //        //{
                //        //    case InputChk.None:		// 未入力、または、存在しない
                //        //        {
                //        //            this.MinSectionCode_tNedit.Clear();
                //        //            this.MinSectionCodeNm_tEdit.Clear();

                //        //            // 現在データクリア
                //        //            this._minSectionCodeWork = 0;

                //        //            // フォーカス
                //        //            e.NextCtrl = e.PrevCtrl;
                //        //            break;
                //        //        }
                //        //    case InputChk.Back:		// 元に戻す
                //        //        {
                //        //            this.MinSectionCode_tNedit.SetInt(this._minSectionCodeWork);
                //        //            break;
                //        //        }
                //        //    case InputChk.Update:	// 更新
                //        //        {
                //        //            this.MinSectionCodeNm_tEdit.DataText = minSection.MinSectionName;

                //        //            // 現在データ保存
                //        //            this._minSectionCodeWork = this.MinSectionCode_tNedit.GetInt();
                //        //            break;
                //        //        }
                //        //}
                //        //----- ueno del ---------- start 2008.03.06
                //        #endregion del 2008.03.06
                //    }
                //#endregion
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
                #endregion // del 2008.07.03

                #region case 従業員コード
                case "EmployeeCode_tEdit":
					{
						// 変更が無ければ処理しない
						if (string.Equals(this.EmployeeCode_tEdit.DataText.TrimEnd(), this._employeeCodeWork) == true)
						{
							break;
						}

						//--------------
						// 存在チェック
						//--------------
						//----- ueno add ---------- start 2008.03.06
						// 条件設定
						inParamObj = this.EmployeeCode_tEdit.Text;

						// 存在チェック
						switch (CheckEmployeeCode(inParamObj, out outParamObj))
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
											ShowNotFoundErrMsg("従業員コード"),		// 表示するメッセージ
											0,										// ステータス値
											MessageBoxButtons.OK);					// 表示するボタン

									dispSetStatus = this._employeeCodeWork == "" ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// データ設定
						DispSetEmployeeCode(dispSetStatus, ref canChangeFocus, outParamObj);
						break;
						//----- ueno add ---------- end 2008.03.06
						
						#region del 2008.03.06
						//----- ueno del ---------- start 2008.03.06					
						//Employee employee = null;

						//if (this.EmployeeCode_tEdit.DataText.TrimEnd() != "")
						//{
						//    EmployeeAcs employeeAcs = new EmployeeAcs();

						//    // データ存在チェック
						//    this.Cursor = Cursors.WaitCursor;
						//    int ret = employeeAcs.Read(out employee, this._enterpriseCode, this.EmployeeCode_tEdit.DataText);
						//    this.Cursor = Cursors.Default;

						//    if (ret != 0)
						//    {
						//        string errMessage = "指定された条件で、従業員コードは存在しませんでした。";
						//        TMsgDisp.Show(
						//                this, 							// 親ウィンドウフォーム
						//                emErrorLevel.ERR_LEVEL_INFO, 	// エラーレベル
						//                this.Name,						// アセンブリID
						//                errMessage, 					// 表示するメッセージ
						//                0,								// ステータス値
						//                MessageBoxButtons.OK);			// 表示するボタン

						//        inputChk = this._employeeCodeWork == "" ? InputChk.None : InputChk.Back;
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
						//            this.EmployeeCode_tEdit.Clear();
						//            this.EmployeeName_tEdit.Clear();

						//            // 現在データクリア
						//            this._employeeCodeWork = "";

						//            // フォーカス
						//            e.NextCtrl = e.PrevCtrl;
						//            break;
						//        }
						//    case InputChk.Back:		// 元に戻す
						//        {
						//            this.EmployeeCode_tEdit.DataText = this._employeeCodeWork;
						//            break;
						//        }
						//    case InputChk.Update:	// 更新
						//        {
						//            this.EmployeeName_tEdit.DataText = employee.Name;

						//            // 現在データ保存
						//            this._employeeCodeWork = this.EmployeeCode_tEdit.DataText;
						//            break;
						//        }
						//}
						//----- ueno del ---------- end 2008.03.06
						#endregion del 2008.03.06
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
//----- ueno add---------- end   2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Form_Load イベント処理(MAMOK09110UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: フォームロード処理を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		private void MAMOK09110UA_Load(object sender, EventArgs e)
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
			
			if(SalesTarget._targetContrastCdEmpSList.Count > 0)
			{
				foreach (DictionaryEntry de in SalesTarget._targetContrastCdEmpSList)
				{
					this.TargetContrastCd_tComboEditor.Items.Add(de.Key, de.Value.ToString());
				}
				this.TargetContrastCd_tComboEditor.Value = SalesTarget._targetContrastCdEmpSList.GetKey(0);
			}

			// 従業員区分コンボボックス設定
			this.EmployeeDivCd_tComboEditor.Items.Clear();

			if (EmpSalesTarget._employeeDivCdSList.Count > 0)
			{
				foreach (DictionaryEntry de in EmpSalesTarget._employeeDivCdSList)
				{
					this.EmployeeDivCd_tComboEditor.Items.Add(de.Key, de.Value.ToString());
				}
				this.EmployeeDivCd_tComboEditor.Value = EmpSalesTarget._employeeDivCdSList.GetKey(0);
			}		
//----- ueno add---------- end   2007.11.21

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

            // 目標設定区分
            this._targetSetCd = this._salesTarget.TargetSetCd;
            // 目標対比区分
            this._targetContrastCd = this._salesTarget.TargetContrastCd;

            // 目標データ画面展開
            SalesTargetToScreen(this._salesTarget);

			//----- ueno del---------- start 2007.11.21
			//// マスタ読み込み
			//bool result = LoadMasterTable();
			//if (!result)
			//{
			//    this.Close();
			//    return;
			//}

			// 曜日別比率表示
            //DispRatioDayOfWeek();
			//----- ueno del---------- end   2007.11.21

			// コントロール制御
			ControlEnabled();

//----- ueno add---------- start 2007.11.21
			this._targetContrastCd_tComboEditorValue = -1;	// 初期化
//----- ueno add---------- end   2007.11.21

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA ADD START
            this.TargetSetCd_tComboEditor.SelectedIndex = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA ADD END

			this._targetStaDate = this._salesTarget.ApplyStaDate.Date;
			this._targetEndDate = this._salesTarget.ApplyEndDate.Date;

			//----- ueno del---------- start 2007.11.21		
			// 比率計算
			//CalcFromRatio();
			//----- ueno del---------- end   2007.11.21
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// FormClosing イベント処理(MAMOK09110UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: フォームの×ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.07.31</br>
        /// </remarks>
        private void MAMOK09110UA_FormClosing(object sender, FormClosingEventArgs e)
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
							// メソッド先頭で格納しているので不要
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
			if(!CheckInputData())
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
		/// Button_Click イベント処理(EmployeeCodeGuide_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 従業員ガイドボタンがクリックされた時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.12</br>
		/// </remarks>
		private void EmployeeCodeGuide_Button_Click(object sender, EventArgs e)
		{
			Employee employee;
            
            int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, false, this._sectionCode, out employee);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				this.EmployeeCode_tEdit.DataText = employee.EmployeeCode.TrimEnd();
				this.EmployeeName_tEdit.DataText = employee.Name;
			}
		}

//----- ueno add---------- start 2007.11.21
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click イベント処理(SubSectionCodeGuide_Button_Click)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 部門コードガイドボタンがクリックされた時に発生します。</br>
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date		: 2007.11.21</br>
		/// </remarks>
		private void SubSectionCodeGuide_Button_Click(object sender, EventArgs e)
		{
			//----- ueno del ---------- start 2008.03.12
			//string belongSectionCode = "";
			//----- ueno del ---------- end 2008.03.12

			SubSection subSection = new SubSection();

			//----- ueno upd ---------- start 2008.03.12
			int status = this._subSectionAcs.ExecuteGuid(out subSection, this._enterpriseCode, this._sectionCode);
			//----- ueno upd ---------- end 2008.03.12

			if (status != 0) return;

			// 取得データ表示
			this.SubSectionCode_tNedit.SetInt(subSection.SubSectionCode);
			this.SubSectionCodeNm_tEdit.DataText = subSection.SubSectionName;
			
			// 前の部門コードと選択した部門コードが異なる場合
			if (subSection.SubSectionCode != this._subSectionCodeWork)
			{
				// 課コードをクリアする
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
				//this.MinSectionCode_tNedit.Clear();
				//this.MinSectionCodeNm_tEdit.Clear();
				//this._minSectionCodeWork = 0;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
			}
			
			// 現在データ保存
			this._subSectionCodeWork = this.SubSectionCode_tNedit.GetInt();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click イベント処理(MinSectionCodeGuide_Button_Click)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 課コードガイドボタンがクリックされた時に発生します。</br>
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date		: 2007.11.21</br>
		/// </remarks>
		private void MinSectionCodeGuide_Button_Click(object sender, EventArgs e)
		{
			//----- ueno del ---------- start 2008.03.12
			//string belongSectionCode = "";
			//----- ueno del ---------- end 2008.03.12

			MinSection minSection = new MinSection();

			//----- ueno upd ---------- start 2008.03.12
			int status = this._minSectionAcs.ExecuteGuid(out minSection, this._enterpriseCode, this._sectionCode);
			//----- ueno upd ---------- end 2008.03.12			
			
			if (status != 0) return;

			// 取得データ表示
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
			//this.MinSectionCode_tNedit.SetInt(minSection.MinSectionCode);
			//this.MinSectionCodeNm_tEdit.DataText = minSection.MinSectionName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
			
			this.SubSectionCode_tNedit.SetInt(minSection.SubSectionCode);
			this.SubSectionCodeNm_tEdit.DataText = minSection.SubSectionName;
			
			// 現在データ保存
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
			//this._minSectionCodeWork = this.MinSectionCode_tNedit.GetInt();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
			this._subSectionCodeWork = this.SubSectionCode_tNedit.GetInt();
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
		/// Leave イベント(ApplyStaDate_tDateEdit)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: コントロールのフォーカスが離れた時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
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
		/// <br>Programmer	: NEPCO</br>
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
		/// Leave イベント(EmployeeCode_tEdit)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: コントロールのフォーカスが離れた時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.18</br>
		/// </remarks>
		private void EmployeeCode_tEdit_Leave(object sender, EventArgs e)
		{
			//----- ueno del---------- start 2007.11.21
			//string employeeCode = this.EmployeeCode_tEdit.DataText.TrimEnd();
			//if (employeeCode == "")
			//{
			//    this.EmployeeName_tEdit.DataText = "";
			//    return;
			//}
			
			//int status = SearchEmployee(employeeCode);
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
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.16</br>
		/// </remarks>
		private void TargetDivideCode_uOptionSet_ValueChanged(object sender, EventArgs e)
		{
			// 月間目標
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
            if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 10)
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

	}
}