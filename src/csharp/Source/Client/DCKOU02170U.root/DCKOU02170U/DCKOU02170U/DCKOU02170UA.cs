using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// 売上仕入日報月報UIクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 売上仕入日報月報UIフォームクラス</br>
    /// <br>Programmer : 980035 金沢 貞義</br>
	/// <br>Date       : 2007.11.08</br>
    /// <br>Update Note: 2008.02.26 20081 疋田 勇人</br>
    /// <br>			 ・DC.NS対応（共通修正:日付チェック、０埋め対応）</br>
    /// <br>Update Note: 2008.03.06 980035 金沢 貞義</br>
    /// <br>			 ・不具合修正</br>
    /// </remarks>
	public partial class DCKOU02170UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer,		// 帳票業務（条件入力）PDF出力履歴管理
                                IPrintConditionInpTypeChart,
                                IPrintConditionInpTypeCondition
	{
		# region Constractor
		/// <summary>
        /// 売上仕入日報月報UIクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 売上仕入日報月報UIクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 980035 金沢 貞義</br>
        /// <br>Date       : 2007.11.08</br>
        /// <br></br>
		/// </remarks>
		public DCKOU02170UA()
		{
			InitializeComponent();

			// 企業コード取得
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 拠点用のHashtable作成
			this._selectedSectionList = new Hashtable();

            // 2008.03.06 削除 >>>>>>>>>>>>>>>>>>>>
            //this._companyInfAcs = new CompanyInfAcs();
            // 2008.03.06 削除 <<<<<<<<<<<<<<<<<<<<

            // 売上仕入日報月報アクセスクラス
            this._stockAdjustListAcs = new StockAdjustListAcs();

            //日付取得部品
            this._dateGet = DateGetAcs.GetInstance();   // 2008.02.26 add

        }
		# endregion

		# region Private Menbers
		/// <summary> 拠点コード </summary>
		private string _enterpriseCode = "";
		/// <summary> 画面イメージコントロール部品 </summary>
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        /// <summary> 売上仕入日報月報アクセスクラス </summary>
        private StockAdjustListAcs _stockAdjustListAcs = null;

        /// <summary> 担当者アクセスクラス </summary>
		private EmployeeAcs _employeeAcs = null;

        /// <summary> ユーザーガイドアクセスクラス </summary>
        private UserGuideGuide _userGuideGuide = null;

        // 2008.03.06 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary> 自社情報アクセスクラス </summary>
        //private CompanyInfAcs _companyInfAcs;
        //private CompanyInf _companyInf;
        // 2008.03.06 削除 <<<<<<<<<<<<<<<<<<<<

        //日付取得部品
        private DateGetAcs _dateGet;   // 2008.02.26 add

        // 2008.03.06 削除 >>>>>>>>>>>>>>>>>>>>
        //private int _companyBiginDate;
        //private int _companyEndDate;
        //private int _targetMonth;
        // 2008.03.06 削除 <<<<<<<<<<<<<<<<<<<<

        private SalesStockDailyMonthlyReportCndtn _chartSalesTableListCndtn = null;

        // 商品チャート抽出クラスメンバ
        private List<IChartExtract> _iChartExtractList;

        private bool _chartButtonVisibled = true;
        private bool _chartButtonEnabled = true;
        # endregion

		# region Private Menbers IPrintConditionInpType インターフェース
		/// <summary> 抽出ボタン状態取得プロパティ </summary>
		private bool _canExtract = false;
		/// <summary> PDF出力ボタン状態取得プロパティ </summary>
		private bool _canPdf = true;
		/// <summary> 印刷ボタン状態取得プロパティ </summary>
		private bool _canPrint = true;
		/// <summary> 抽出ボタン表示有無プロパティ </summary>
		private bool _visibledExtractButton = false;
		/// <summary> PDF出力ボタン表示有無プロパティ </summary>
		private bool _visibledPdfButton = true;
		/// <summary> 印刷ボタン表示有無プロパティ </summary>
		private bool _visibledPrintButton = true;
		# endregion

		# region Private Menbers IPrintConditionInpTypeSelectedSection インターフェース
		/// <summary> 計上拠点選択表示取得プロパティ </summary>
		private bool _visibledSelectAddUpCd = false;
		/// <summary> 拠点オプション有無 </summary>
		private bool _isOptSection = false;
		/// <summary> 本社機能有無 </summary>
		private bool _isMainOfficeFunc = false;
		/// <summary> 選択拠点リスト </summary>
		private Hashtable _selectedSectionList = new Hashtable();
		# endregion

		# region Private const Menbers
		# region ◆ Interface member
		//--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
		/// <summary> クラスID </summary>
		private const string ct_ClassID = "DCKOU02170UA";
		/// <summary> プログラムID </summary>
		private const string ct_PGID = "DCKOU02170U";
		/// <summary> 帳票名称 </summary>
        private const string ct_PrintName = "売上仕入日報月報";
		/// <summary> 帳票キー </summary>
		private const string ct_PrintKey = "f91b7283-9d5e-46d9-a4c2-1dcb12ac1145";
		# endregion ◆ Interface member

		// ExporerBar グループ名称
		private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";		// 出力条件
		private const string ct_ExBarGroupNm_ExtractConditionGroup = "ExtractConditionGroup";	// 抽出条件
		# endregion

		# region IPrintConditionInpType インターフェース
		# region Public Event
		/// <summary> 親ツールバー設定イベント </summary>
		public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
		# endregion

		# region Public Property
		/// <summary> 抽出ボタン状態取得プロパティ </summary>
		public bool CanExtract
		{
			get { return this._canExtract; }
		}

		/// <summary> PDF出力ボタン状態取得プロパティ </summary>
		public bool CanPdf
		{
			get { return this._canPdf; }
		}

		/// <summary> 印刷ボタン状態取得プロパティ </summary>
		public bool CanPrint
		{
			get { return this._canPrint; }
		}

		/// <summary> 抽出ボタン表示有無プロパティ </summary>
		public bool VisibledExtractButton
		{
			get { return this._visibledExtractButton; }
		}

		/// <summary> PDF出力ボタン表示有無プロパティ </summary>
		public bool VisibledPdfButton
		{
			get { return this._visibledPdfButton; }
		}

		/// <summary> 印刷ボタン表示プロパティ </summary>
		public bool VisibledPrintButton
		{
			get { return this._visibledPrintButton; }
		}
		# endregion

		# region Public Method
		/// <summary>
		/// 抽出処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>0( 固定 )</returns>
		/// <remarks>
		/// <br>Note		: 抽出処理を行う。</br>
        /// <br>Programmer  : 980035 金沢 貞義</br>
        /// <br>Date        : 2007.11.08</br>
        /// </remarks>
		public int Extract(ref object parameter)
		{
            string errMsg = "";
            int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;

            SalesStockDailyMonthlyReportCndtn extraInfo = new SalesStockDailyMonthlyReportCndtn();	   // 抽出条件クラス

            this.SetExtraInfoFromScreen(ref extraInfo);

            // チャート用条件設定
            _chartSalesTableListCndtn = extraInfo;

            // データ抽出
            status = this._stockAdjustListAcs.SearchConfirmStockAdjust(extraInfo, out errMsg);
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
            else if (status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "データの抽出でエラーが発生しました", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
            return status;
		}

        // ===================================================================================== //
        // IPrintConditionInpTypeCondition メンバ
        // ===================================================================================== //
        /// <summary>
        /// チャート用抽出条件設定
        /// </summary>
        public object ObjExtract
        {
            get
            {
                return this._chartSalesTableListCndtn;
            }
        }

        /// <summary>
		/// 印刷処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 印刷処理を行う。</br>
        /// <br>Programmer  : 980035 金沢 貞義</br>
        /// <br>Date        : 2007.11.08</br>
        /// </remarks>
		public int Print(ref object parameter)
		{
			SFCMN06001U printDialog = new SFCMN06001U();		// 帳票選択ガイド
			SFCMN06002C printInfo = parameter as SFCMN06002C;	// 印刷情報パラメータ


			printInfo.enterpriseCode	= this._enterpriseCode;	// 企業コード
			printInfo.kidopgid			= ct_PGID;				// 起動PGID
			printInfo.key				= ct_PrintKey;			// PDF出力履歴用
			printInfo.prpnm				= ct_PrintName;			// PDF出力履歴用

			// 抽出条件クラス
            SalesStockDailyMonthlyReportCndtn extrInfo = new SalesStockDailyMonthlyReportCndtn();

			// 抽出条件設定処理(画面→抽出条件)
			if (this.SetExtraInfoFromScreen(ref extrInfo) != 0) return -1;


			// 抽出条件の設定
//			printInfo.PrintPaperSetCd = extrInfo.PrintDiv;
			printInfo.jyoken = extrInfo;
			printDialog.PrintInfo = printInfo;

			// 帳票選択ガイド
			printDialog.ShowDialog();

			if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
			{
				MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0);
			}

			parameter = printInfo;

			return printInfo.status;
		}

		/// <summary>
		/// 印刷前確認処理
		/// </summary>
        /// <returns>status</returns>
		/// <remarks>
		/// <br>Note		: 印刷前確認処理を行う。(入力チェックなど)</br>
        /// <br>Programmer  : 980035 金沢 貞義</br>
        /// <br>Date        : 2007.11.08</br>
        /// </remarks>
		public bool PrintBeforeCheck()
		{
			bool status = true;

			string errMessage = "";
			Control errComponent = null;

			// 入力チェック処理
			if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
			{
				// メッセージを表示
				this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

				// コントロールにフォーカスをセット
				if (errComponent != null) errComponent.Focus();

				status = false;
			}

			return status;
		}

        // ===================================================================================== //
        // IPrintConditionInpTypeChart メンバ
        // ===================================================================================== //
        #region IPrintConditionInpTypeChart メンバ
        /// <summary>
        /// チャートボタンEnabled制御
        /// </summary>
        public bool CanChart
        {
            get { return this._chartButtonEnabled; }
        }

        /// <summary>
        /// チャートボタン表示制御
        /// </summary>
        public bool VisibledChartButton
        {
            get { return this._chartButtonVisibled; }
        }

        /// <summary>
        /// チャートデータの抽出チェック
        /// </summary>
        public bool CheckBefore()
        {
            // TODO チャートデータの抽出チェックを行います。
            return true;
        }

        /// <summary>
        /// チャート抽出クラスメンバ取得
        /// </summary>
        /// <param name="chartExtractMemberList"></param>
        /// <returns></returns>
        public int GetChartExtractMember(out List<IChartExtract> chartExtractMemberList)
        {
            try
            {
                string message;
                Control errControl = null;

                // 画面入力条件チェック
                bool result = this.ChartInputCheack(out message, ref errControl);
                if (result == false)
                {
                    //TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION, message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                    TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION, message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                    if (errControl != null) errControl.Focus();

                    chartExtractMemberList = null;

                    return 9;
                }

                if (this._iChartExtractList == null)
                {
                    this._iChartExtractList = new List<IChartExtract>();

                    AgentOrderChart chartExtract1 = new AgentOrderChart(0);
                    this._iChartExtractList.Add(chartExtract1);

                    //AgentOrderChart chartExtract2 = new AgentOrderChart(1);
                    //this._iChartExtractList.Add(chartExtract2);
                }

                chartExtractMemberList = this._iChartExtractList;
            }
            finally
            {
            }

            return 0;
        }

        #endregion

        // 2008.03.06 削除 >>>>>>>>>>>>>>>>>>>>
        # region 自社情報読み込み処理
        ///// <summary>
        ///// 自社情報読み込み処理
        ///// </summary>
        ///// <remarks>
        ///// <br>Note		: 自社情報の取得を行う。</br>
        ///// <br>Programmer  : 980035 金沢 貞義</br>
        ///// <br>Date        : 2007.11.08</br>
        ///// </remarks>
        //public void GetCompanyInf()
        //{
        //    int nowYear = System.DateTime.Now.Year;
        //    int nowMonth = System.DateTime.Now.Month;
        //    int nowDay = System.DateTime.Now.Day;
        //    int companyBiginDay;

        //    // 自社情報読み込み
        //    int status = this._companyInfAcs.Read(out this._companyInf, this._enterpriseCode);
        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        companyBiginDay = this._companyInf.CompanyBiginDate % 100;
        //        int targetDate = (nowYear * 10000) + (nowMonth * 100) + companyBiginDay;
        //        DateTime workDate = TDateTime.LongDateToDateTime(targetDate);

        //        // 月報日付・月間目標月取得
        //        if (nowDay >= companyBiginDay)
        //        {
        //            workDate = workDate.AddMonths(1);
        //            _companyBiginDate = targetDate;
        //            _companyEndDate = TDateTime.DateTimeToLongDate(workDate.AddDays(-1));
        //            if (this._companyInf.StartMonthDiv == 1)
        //            {
        //                _targetMonth = targetDate / 100;
        //            }
        //            else
        //            {
        //                _targetMonth = TDateTime.DateTimeToLongDate(workDate) / 100;
        //            }
        //        }
        //        else
        //        {
        //            _companyBiginDate = TDateTime.DateTimeToLongDate(workDate.AddMonths(-1));
        //            _companyEndDate = TDateTime.DateTimeToLongDate(workDate.AddDays(-1));
        //            if (this._companyInf.StartMonthDiv == 1)
        //            {
        //                _targetMonth = _companyBiginDate / 100;
        //            }
        //            else
        //            {
        //                _targetMonth = targetDate / 100;
        //            }
        //        }

        //    }
        //}
		# endregion
        // 2008.03.06 削除 <<<<<<<<<<<<<<<<<<<<

        /// <summary>
		/// 画面表示処理
		/// </summary>
		/// <param name="parameter">起動パラメータ</param>
		/// <remarks>
		/// <br>Note		: 画面表示を行う。</br>
        /// <br>Programmer  : 980035 金沢 貞義</br>
        /// <br>Date        : 2007.11.08</br>
        /// </remarks>
		public void Show(object parameter)
		{
			// Todo:起動パラメータを変更する場合はここで行う。
			this.Show();
			return;
		}
		# endregion
		# endregion

		# region IPrintConditionInpTypeSelectedSection インターフェース
		# region Public Property
		/// <summary> 本社機能プロパティ </summary>
		public bool IsMainOfficeFunc
		{
			get { return _isMainOfficeFunc; }
			set { _isMainOfficeFunc = value; }
		}

		/// <summary> 拠点オプションプロパティ </summary>
		public bool IsOptSection
		{
			get { return _isOptSection; }
			set { _isOptSection = value; }
		}

		/// <summary> 計上拠点選択表示取得プロパティ </summary>
		public bool VisibledSelectAddUpCd
		{
			get { return _visibledSelectAddUpCd; }
		}
		# endregion

		# region Public Method
		/// <summary>
		/// 拠点選択処理
		/// </summary>
		/// <param name="sectionCode">選択拠点コード</param>
		/// <param name="checkState">選択状態</param>
		/// <remarks>
		/// <br>Note		: 拠点選択処理を行う。</br>
        /// <br>Programmer  : 980035 金沢 貞義</br>
        /// <br>Date        : 2007.11.08</br>
        /// </remarks>
		public void CheckedSection(string sectionCode, CheckState checkState)
		{
			// 拠点を選択した時
			if (checkState == CheckState.Checked)
			{
				// 全社が選択された場合
				if (sectionCode == "0")
				{
					this._selectedSectionList.Clear();
				}

				if (!this._selectedSectionList.ContainsKey(sectionCode))
				{
					this._selectedSectionList.Add(sectionCode, sectionCode);
				}
			}
			// 拠点選択を解除した時
			else if (checkState == CheckState.Unchecked)
			{
				if (this._selectedSectionList.ContainsKey(sectionCode))
				{
					this._selectedSectionList.Remove(sectionCode);
				}
			}

		}

		/// <summary>
		/// 初期選択計上拠点設定処理( 未実装 )
		/// </summary>
		/// <param name="addUpCd"></param>
		/// <remarks>
		/// <br>Note		: 未実装</br>
        /// <br>Programmer  : 980035 金沢 貞義</br>
        /// <br>Date        : 2007.11.08</br>
        /// </remarks>
		public void InitSelectAddUpCd(int addUpCd)
		{
			// 計上拠点選択がないので未実装
		}

		/// <summary>
		/// 初期選択拠点設定処理
		/// </summary>
		/// <param name="sectionCodeLst">選択拠点コードリスト</param>
		/// <remarks>
		/// <br>Note		: 拠点リストの初期化を行う。</br>
        /// <br>Programmer  : 980035 金沢 貞義</br>
        /// <br>Date        : 2007.11.08</br>
        /// </remarks>
		public void InitSelectSection(string[] sectionCodeLst)
		{
			// 選択リスト初期化
			this._selectedSectionList.Clear();
			foreach (string wk in sectionCodeLst)
			{
				this._selectedSectionList.Add(wk, wk);
			}
		}

		/// <summary>
		/// 初期拠点選択表示チェック処理
		/// </summary>
		/// <param name="isDefaultState">true：スライダー表示　false：スライダー非表示</param>
		/// <remarks>
		/// <br>Note		: 拠点選択スライダーの表示有無を判定する。</br>
		/// <br>			: 拠点オプション、本社機能以外の個別の表示有無判定を行う。</br>
        /// <br>Programmer  : 980035 金沢 貞義</br>
        /// <br>Date        : 2007.11.08</br>
        /// </remarks>
		public bool InitVisibleCheckSection(bool isDefaultState)
		{
			return isDefaultState;
		}

		/// <summary>
		/// 計上拠点選択処理( 未実装 )
		/// </summary>
		/// <param name="addUpCd"></param>
		/// <remarks>
		/// <br>Note		: 未実装</br>
        /// <br>Programmer  : 980035 金沢 貞義</br>
        /// <br>Date        : 2007.11.08</br>
        /// </remarks>
		public void SelectedAddUpCd(int addUpCd)
		{
			// 計上拠点選択がないので未実装
		}
		# endregion
		# endregion

		# region IPrintConditionInpTypePdfCareer インターフェース
		# region Public Property
		/// <summary> 帳票キープロパティ </summary>
		public string PrintKey
		{
			get { return ct_PrintKey; }
		}

		/// <summary> 帳票名プロパティ </summary>
		public string PrintName
		{
			get { return ct_PrintName; }
		}
		# endregion
		# endregion

		# region Private Methods
		/// <summary>
		/// 画面初期化処理
		/// </summary>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note		: 入力項目の初期化を行う</br>
        /// <br>Programmer  : 980035 金沢 貞義</br>
        /// <br>Date        : 2007.11.08</br>
        /// </remarks>
		private int InitializeScreen(out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;

			try
			{
				// 対象日付
				this.detTargetDate_St.SetDateTime(TDateTime.GetSFDateNow());
				this.detTargetDate_Ed.SetDateTime(TDateTime.GetSFDateNow());
                // 担当者コード
                this.edtSalesEmployeeCd_St.DataText = "";
                this.edtSalesEmployeeCd_Ed.DataText = "";
                // 販売エリアコード
                //this.nedSalesAreaCode_St.SetInt(0);
                //this.nedSalesAreaCode_Ed.SetInt(9999);
                this.nedSalesAreaCode_St.DataText = "";
                this.nedSalesAreaCode_Ed.DataText = "";
                // 業種コード
                //this.nedBusinessTypeCode_St.SetInt(0);
                //this.nedBusinessTypeCode_Ed.SetInt(9999);
                this.nedBusinessTypeCode_St.DataText = "";
                this.nedBusinessTypeCode_Ed.DataText = "";
            }
			catch (Exception ex)
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}

			return status;
		}

		/// <summary>
		/// ボタンアイコン設定処理
		/// </summary>
		/// <param name="settingControl">アイコンセットするコントロール</param>
		/// <param name="iconIndex">アイコンインデックス</param>
		/// <remarks>
		/// <br>Note		: ボタンアイコンの設定を行う</br>
        /// <br>Programmer  : 980035 金沢 貞義</br>
        /// <br>Date        : 2007.11.08</br>
        /// </remarks>
		private void SetIconImage(object settingControl, Size16_Index iconIndex)
		{
			((Infragistics.Win.Misc.UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
			((Infragistics.Win.Misc.UltraButton)settingControl).Appearance.Image = iconIndex;
		}

		/// <summary>
		/// 抽出条件設定処理(画面→抽出条件)
		/// </summary>
		/// <param name="extraInfo">抽出条件</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer  : 980035 金沢 貞義</br>
        /// <br>Date        : 2007.11.08</br>
        /// </remarks>
        private int SetExtraInfoFromScreen(ref SalesStockDailyMonthlyReportCndtn extraInfo)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
				// 企業コード
				extraInfo.EnterpriseCode = this._enterpriseCode;
                //// 拠点オプション
				//extraInfo.IsOptSection = this._isOptSection;
                // 選択拠点
                extraInfo.SectionCodeList = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));
                // 対象日付
                extraInfo.TargetDateSt = this.detTargetDate_St.GetDateTime();
                extraInfo.TargetDateEd = this.detTargetDate_Ed.GetDateTime();

				// 集計単位
                extraInfo.TotalType = this.optTotalType.CheckedIndex;
                if (extraInfo.TotalType == 0)
                {
                    // 担当者コード
                    extraInfo.SalesEmployeeCdSt = this.edtSalesEmployeeCd_St.DataText.TrimEnd();
                    extraInfo.SalesEmployeeCdEd = this.edtSalesEmployeeCd_Ed.DataText.TrimEnd();
                }
                else if (extraInfo.TotalType == 2)
                {
                    // 販売エリアコード
                    extraInfo.SalesAreaCodeSt = this.nedSalesAreaCode_St.GetInt();
                    extraInfo.SalesAreaCodeEd = this.nedSalesAreaCode_Ed.GetInt();
                }
                else if (extraInfo.TotalType == 3)
                {
                    // 業種コード
                    extraInfo.BusinessTypeCodeSt = this.nedBusinessTypeCode_St.GetInt();
                    extraInfo.BusinessTypeCodeEd = this.nedBusinessTypeCode_Ed.GetInt();
                }

                // 2008.03.06 修正 >>>>>>>>>>>>>>>>>>>>
                //// 月報日付
                //extraInfo.MonthReportDateSt = _companyBiginDate;
                //extraInfo.MonthReportDateEd = _companyEndDate;
                //// 月間目標月
                //extraInfo.TargetMonth = _targetMonth;

                int targetYear;
                DateTime targetMonth;
                DateTime startMonthDate;
                DateTime endMonthDate;

                // 対象年月度取得
                this._dateGet.GetYearMonth(this.detTargetDate_St.GetDateTime(), out targetMonth, out targetYear, out startMonthDate, out endMonthDate);

                // 月報日付
                extraInfo.MonthReportDateSt = TDateTime.DateTimeToLongDate(startMonthDate);
                extraInfo.MonthReportDateEd = this.detTargetDate_Ed.GetLongDate();
                // 月間目標月
                extraInfo.TargetMonth = TDateTime.DateTimeToLongDate(targetMonth) / 100;
                // 2008.03.06 修正 <<<<<<<<<<<<<<<<<<<<
            }
			catch (Exception)
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}

			return status;
		}

		/// <summary>
		/// 入力チェック処理
		/// </summary>
		/// <param name="errMessage">エラーメッセージ</param>
		/// <param name="errComponent">エラー発生コントロール</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note		: 入力内容のチェック処理を行います。</br>
        /// <br>Programmer  : 980035 金沢 貞義</br>
        /// <br>Date        : 2007.11.08</br>
        /// </remarks>
		private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
		{
			bool status = true;
            
            // 2008.02.26 upd start -------------------------------------------------->>
            //int companyEndDate;
            //// 自社締め範囲算出
            //DateTime workDate = TDateTime.LongDateToDateTime(this._companyBiginDate);
            //if (this.detTargetDate_St.GetLongDate() < this._companyBiginDate)
            //{
            //    for (int ix = 0; ix < (this._companyBiginDate / 100) - (this.detTargetDate_St.GetLongDate() / 100) + 1; ix++)
            //    {
            //        workDate = workDate.AddMonths(-1);
            //        if (this.detTargetDate_St.GetLongDate() >= TDateTime.DateTimeToLongDate(workDate)) break;
            //    }
            //}
            //companyEndDate = TDateTime.DateTimeToLongDate((workDate.AddMonths(1)).AddDays(-1));


            //const string ct_InputError = "の入力が不正です";
            //const string ct_RangeError = "の範囲指定に誤りがあります";
            ////const string ct_BiginDateError = "は前回自社締日の翌日から１カ月以内で入力して下さい";

            //// 開始 対象日付のチェック
            //if ((this.detTargetDate_St.GetLongDate() != 0) && (TDateTime.IsAvailableDate(this.detTargetDate_St.GetDateTime()) == false))
            //{
            //    errMessage = string.Format("開始 対象日付{0}", ct_InputError);
            //    errComponent = this.detTargetDate_St;
            //    status = false;
            //}
            //// 終了 対象日付のチェック
            //else if ((this.detTargetDate_Ed.GetLongDate() != 0) && (TDateTime.IsAvailableDate(this.detTargetDate_Ed.GetDateTime()) == false))
            //{
            //    errMessage = string.Format("終了 対象日付{0}", ct_InputError);
            //    errComponent = this.detTargetDate_Ed;
            //    status = false;
            //}
            //// 日付の範囲をチェック(自社締日以前 → NG)
            ////else if (this.detTargetDate_St.GetLongDate() < _companyBiginDate)
            ////{
            ////    //errMessage = string.Format("対象日付{0}", ct_BiginDateError);
            ////    errComponent = this.detTargetDate_St;
            ////    status = false;
            ////}
            //// 日付の範囲をチェック(自社締日翌日の１カ月以降 → NG)
            //else if (this.detTargetDate_Ed.GetLongDate() > companyEndDate)
            //{
            //    //errMessage = string.Format("対象日付{0}", ct_BiginDateError);
            //    errMessage = string.Format("対象日付{0}", ct_RangeError);
            //    errComponent = this.detTargetDate_Ed;
            //    status = false;
            //}
            //// 日付の範囲をチェック(開始日 > 終了日 → NG)
            //else if (this.detTargetDate_St.GetLongDate() > this.detTargetDate_Ed.GetLongDate())
            //{
            //    errMessage = string.Format("対象日付{0}", ct_RangeError);
            //    errComponent = this.detTargetDate_St;
            //    status = false;
            //}
            const string ct_InputError = "の入力が不正です";
            const string ct_RangeError = "の範囲指定に誤りがあります";
            const string ct_RangeOverError = "は同一年度内で入力して下さい";
            // 2008.03.06 修正 >>>>>>>>>>>>>>>>>>>>
            const string ct_RangeMonthOverError = "の範囲は１ヵ月以内で入力して下さい";
            // 2008.03.06 修正 <<<<<<<<<<<<<<<<<<<<

            DateGetAcs.CheckDateRangeResult cdrResult;

            // 対象日付
            // 入力日付（開始～終了）
            if (CallCheckDateRange(out cdrResult, ref detTargetDate_St, ref detTargetDate_Ed) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = string.Format("開始対象日付{0}", ct_InputError);
                            errComponent = this.detTargetDate_St;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("開始対象日付{0}", ct_InputError);
                            errComponent = this.detTargetDate_St;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            errMessage = string.Format("終了対象日付{0}", ct_InputError);
                            errComponent = this.detTargetDate_Ed;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("終了対象日付{0}", ct_InputError);
                            errComponent = this.detTargetDate_Ed;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("対象日付{0}", ct_RangeError);
                            errComponent = this.detTargetDate_St;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                    case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnYear:
                        {
                            errMessage = string.Format("対象日付{0}", ct_RangeOverError);
                            errComponent = this.detTargetDate_St;
                        }
                        break;
                    // 2008.03.06 修正 >>>>>>>>>>>>>>>>>>>>
                    case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnMonth:
                        {
                            errMessage = string.Format("対象日付{0}", ct_RangeMonthOverError);
                            errComponent = this.detTargetDate_St;
                        }
                        break;
                    // 2008.03.06 修正 <<<<<<<<<<<<<<<<<<<<
                }
                status = false;
            }
            // 2008.02.26 upd end ----------------------------------------------------<<
            // 担当者コード
            else if (
               (this.edtSalesEmployeeCd_St.DataText.TrimEnd() != string.Empty) &&
               (this.edtSalesEmployeeCd_Ed.DataText.TrimEnd() != string.Empty) &&
               (this.edtSalesEmployeeCd_St.DataText.TrimEnd().CompareTo(this.edtSalesEmployeeCd_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("担当者コード{0}", ct_RangeError);
                errComponent = this.edtSalesEmployeeCd_St;
                status = false;
            }
            // 販売エリアコード
			else if (
                (this.nedSalesAreaCode_St.GetInt() != 0) &&
                (this.nedSalesAreaCode_Ed.GetInt() != 0) &&
                (this.nedSalesAreaCode_St.GetInt() > this.nedSalesAreaCode_Ed.GetInt()))
            {
				errMessage = string.Format("地区コード{0}", ct_RangeError);
				errComponent = this.nedSalesAreaCode_St;
				status = false;
			}
            // 業種コード
			else if (
                (this.nedBusinessTypeCode_St.GetInt() != 0) &&
                (this.nedBusinessTypeCode_Ed.GetInt() != 0) &&
                (this.nedBusinessTypeCode_St.GetInt() > this.nedBusinessTypeCode_Ed.GetInt()))
            {
				errMessage = string.Format("業種コード{0}", ct_RangeError);
				errComponent = this.nedBusinessTypeCode_St;
				status = false;
			}

			return status;
		}

        // 2008.02.26 add start ---------------------------------------->>
        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_OrderDataCreateDate"></param>
        /// <param name="tde_Ed_OrderDataCreateDate"></param>
        /// <returns></returns>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate)
        {
            // 2008.03.06 修正 >>>>>>>>>>>>>>>>>>>>
            //cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 1, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, true, true);
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 1, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, false, true, true);
            // 2008.03.06 修正 <<<<<<<<<<<<<<<<<<<<
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        // 2008.02.26 add end ------------------------------------------<<

        /// <summary>
        /// チャート用画面入力チェック処理
        /// </summary>
        private bool ChartInputCheack(out string message, ref Control errControl)
        {
            message = "";
            bool result = false;
            errControl = null;

            switch (this.optTotalType.CheckedIndex)
            {
                case 1: // 拠点別
                    {
                        break;
                    }
                case 0: // 仕入先別
                case 2: // 地区別
                case 3: // 業種別
                    {
                        // 拠点内容チェック
                        if ((this._selectedSectionList.Count > 1) || (this._selectedSectionList.ContainsKey("0")))
                        {
                            message = "グラフ出力の場合、拠点は対象が1つになるよう絞ってください";
                            return result;
                        }
                        break;
                    }
            }

            return true;
        }

        /// <summary>
		/// 選択中出力タイプ取得処理
		/// </summary>
		/// <param name="printDiv">出力区分</param>
		/// <param name="printDivName">出力名称</param>
		/// <remarks>
		/// <br>Note       : 選択中の出力タイプ情報の取得を行います。</br>
        /// <br>Programmer : 980035 金沢 貞義</br>
        /// <br>Date       : 2007.11.08</br>
        /// </remarks>
		private void GetSelectPrintType(out int printDiv, out string printDivName)
		{
			printDiv = (Int32)optTotalType.CheckedItem.DataValue;
			printDivName = optTotalType.CheckedItem.DisplayText;
		}

		/// <summary>
		/// エラーメッセージ表示処理
		/// </summary>
		/// <param name="iLevel">エラーレベル</param>
		/// <param name="message">表示メッセージ</param>
		/// <param name="status">ステータス</param>
		/// <remarks>
		/// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 980035 金沢 貞義</br>
        /// <br>Date       : 2007.11.08</br>
        /// </remarks>
		private void MsgDispProc(emErrorLevel iLevel, string message, int status)
		{
			TMsgDisp.Show(
				iLevel, 							// エラーレベル
				ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
				ct_PrintName,						// プログラム名称
				"", 								// 処理名称
				"",									// オペレーション
				message,							// 表示するメッセージ
				status, 							// ステータス値
				null, 								// エラーが発生したオブジェクト
				MessageBoxButtons.OK, 				// 表示するボタン
				MessageBoxDefaultButton.Button1);	// 初期表示ボタン
		}

		/// <summary>
		/// エラーメッセージ表示処理
		/// </summary>
		/// <param name="message">表示メッセージ</param>
		/// <param name="status">ステータス</param>
		/// <param name="procnm">発生メソッドID</param>
		/// <param name="ex">例外情報</param>
		/// <remarks>
		/// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 980035 金沢 貞義</br>
        /// <br>Date       : 2007.11.08</br>
        /// </remarks>
		private void MsgDispProc(string message, int status, string procnm, Exception ex)
		{
			string errMessage = message + "\r\n" + ex.Message;

			TMsgDisp.Show(
				this, 								// 親ウィンドウフォーム
				emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
				ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
				ct_PrintName,						// プログラム名称
				procnm, 							// 処理名称
				"",									// オペレーション
				errMessage,							// 表示するメッセージ
				status, 							// ステータス値
				null, 								// エラーが発生したオブジェクト
				MessageBoxButtons.OK, 				// 表示するボタン
				MessageBoxDefaultButton.Button1);	// 初期表示ボタン
		}

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
        /// <br>Note	   : エラーメッセージを表示します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date	   : 2007.11.08</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, this.Name, iMsg, iSt, iButton, iDefButton);
        }
        # endregion

		# region Control Events
		/// <summary>
		/// 画面のLOAD イベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント情報</param>
		/// <remarks>
		/// <br>Note       : 画面のLOAD時に発生します。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		private void DCKOU02170UA_Load(object sender, EventArgs e)
		{
			string errMsg = string.Empty;

			// コントロール初期化
			int status = this.InitializeScreen(out errMsg);
			if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
			{
				MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
				return;
			}

			// ガイドボタンのアイコン設定
			this.SetIconImage(this.btnSalesEmployeeCd_St, Size16_Index.STAR1);
			this.SetIconImage(this.btnSalesEmployeeCd_Ed, Size16_Index.STAR1);
            this.SetIconImage(this.btnSalesAreaCode_St, Size16_Index.STAR1);
            this.SetIconImage(this.btnSalesAreaCode_Ed, Size16_Index.STAR1);
            this.SetIconImage(this.btnBusinessTypeCode_St, Size16_Index.STAR1);
            this.SetIconImage(this.btnBusinessTypeCode_Ed, Size16_Index.STAR1);

			// 画面イメージ統一
			// 画面スキンファイルの読込(デフォルトスキン指定)
			this._controlScreenSkin.LoadSkin();

			// 画面スキン変更
			this._controlScreenSkin.SettingScreenSkin(this);

			// ツールバー設定イベント
			ParentToolbarSettingEvent(this);

            // 2008.03.06 削除 >>>>>>>>>>>>>>>>>>>>
            //// 自社情報取得
            //GetCompanyInf();
            // 2008.03.06 削除 <<<<<<<<<<<<<<<<<<<<
            
            // 抽出条件初期設定
            optPrintType_ValueChanged(sender, e);
        }

		/// <summary>
		/// 画面の表示状態切替 イベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント情報</param>
		/// <remarks>
		/// <br>Note       : 画面の表示状態が切替る時に発生します。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		private void DCKOU02170UA_VisibleChanged(object sender, EventArgs e)
		{
			if (this.Visible == true)
			{
				// 初期フォーカス設定
                this.detTargetDate_St.Focus();
			}
		}

		/// <summary>
		/// エクスプローラーバー グループ縮小 イベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント情報</param>
		/// <remarks>
		/// <br>Note       : グループが縮小される前に発生します。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		private void uebMainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			if ((e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup) ||
				(e.Group.Key == ct_ExBarGroupNm_ExtractConditionGroup))
			{
				// グループの縮小をキャンセル
				e.Cancel = true;
			}
		}

		/// <summary>
		/// エクスプローラーバー グループ展開 イベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント情報</param>
		/// <remarks>
		/// <br>Note       : グループが展開される前に発生します。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		private void uebMainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			if ((e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup) ||
				(e.Group.Key == ct_ExBarGroupNm_ExtractConditionGroup))
			{
				// グループの縮小をキャンセル
				e.Cancel = true;
			}
		}

		/// <summary>
		/// 終了 販売エリアコードLeave イベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント情報</param>
		/// <remarks>
		/// <br>Note       : フォーカスが抜ける時に発生します。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		private void nedSalesAreaCode_Ed_Leave(object sender, EventArgs e)
		{
			// 空白またはゼロの場合は初期値をセット
            //if ((((TNedit)sender).DataText == string.Empty) || (((TNedit)sender).GetInt() == 0)) ((TNedit)sender).SetInt(9999);
        }

        /// <summary>
        /// 終了 業種コードLeave イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note       : フォーカスが抜ける時に発生します。</br>
        /// <br>Programer  : 97036 amami</br>
        /// <br>Date       : 2007.03.14</br>
        /// </remarks>
        private void nedBusinessTypeCode_Ed_Leave(object sender, EventArgs e)
        {
            // 空白またはゼロの場合は初期値をセット
            //if ((((TNedit)sender).DataText == string.Empty) || (((TNedit)sender).GetInt() == 0)) ((TNedit)sender).SetInt(9999);
        }

        /// <summary>
        /// 開始 入力担当者ガイドボタン押下 イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note       : ガイドボタンが押下された時に発生します。</br>
        /// <br>Programer  : 97036 amami</br>
        /// <br>Date       : 2007.03.14</br>
        /// </remarks>
        private void btnInputAgenGuid_St_Click(object sender, EventArgs e)
        {
            if (this._employeeAcs == null) this._employeeAcs = new EmployeeAcs();
            Employee employee;
            if (this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee) == 0)
            {
                edtSalesEmployeeCd_St.DataText = employee.EmployeeCode.TrimEnd();
            }
        }

        /// <summary>
        /// 終了 入力担当者ガイドボタン押下 イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note       : ガイドボタンが押下された時に発生します。</br>
        /// <br>Programer  : 97036 amami</br>
        /// <br>Date       : 2007.03.14</br>
        /// </remarks>
        private void btnInputAgenGuid_Ed_Click(object sender, EventArgs e)
        {
            if (this._employeeAcs == null) this._employeeAcs = new EmployeeAcs();
            Employee employee;
            if (this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee) == 0)
            {
                edtSalesEmployeeCd_Ed.DataText = employee.EmployeeCode.TrimEnd();
            }
        }

        /// <summary>
        /// 開始 販売エリアガイドボタン押下 イベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント情報</param>
		/// <remarks>
		/// <br>Note       : ガイドボタンが押下された時に発生します。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		private void btnSalesAreaCode_St_Click(object sender, EventArgs e)
		{
            if (this._userGuideGuide == null) this._userGuideGuide = new UserGuideGuide();
            UserGdBd userGdBd = new UserGdBd();
            System.Windows.Forms.DialogResult result = _userGuideGuide.UserGuideGuideShow(21, 0, this._enterpriseCode, ref userGdBd);

            if ((result == DialogResult.OK) || (result == DialogResult.Yes))
            {
                nedSalesAreaCode_St.SetInt(userGdBd.GuideCode);
            }
        }

		/// <summary>
        /// 終了 販売エリアガイドボタン押下 イベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント情報</param>
		/// <remarks>
		/// <br>Note       : ガイドボタンが押下された時に発生します。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		private void btnSalesAreaCode_Ed_Click(object sender, EventArgs e)
		{
            if (this._userGuideGuide == null) this._userGuideGuide = new UserGuideGuide();
            UserGdBd userGdBd = new UserGdBd();
            System.Windows.Forms.DialogResult result = _userGuideGuide.UserGuideGuideShow(21, 0, this._enterpriseCode, ref userGdBd);

            if ((result == DialogResult.OK) || (result == DialogResult.Yes))
            {
                nedSalesAreaCode_Ed.SetInt(userGdBd.GuideCode);
            }
        }
        /// <summary>
        /// 開始 業種ガイドボタン押下 イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note       : ガイドボタンが押下された時に発生します。</br>
        /// <br>Programer  : 97036 amami</br>
        /// <br>Date       : 2007.03.14</br>
        /// </remarks>
        private void btnBusinessTypeCode_St_Click(object sender, EventArgs e)
        {
            if (this._userGuideGuide == null) this._userGuideGuide = new UserGuideGuide();
            UserGdBd userGdBd = new UserGdBd();
            System.Windows.Forms.DialogResult result = _userGuideGuide.UserGuideGuideShow(33, 0, this._enterpriseCode, ref userGdBd);

            if ((result == DialogResult.OK) || (result == DialogResult.Yes))
            {
                nedBusinessTypeCode_St.SetInt(userGdBd.GuideCode);
            }
        }

        /// <summary>
        /// 終了 業種ガイドボタン押下 イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note       : ガイドボタンが押下された時に発生します。</br>
        /// <br>Programer  : 97036 amami</br>
        /// <br>Date       : 2007.03.14</br>
        /// </remarks>
        private void btnBusinessTypeCode_Ed_Click(object sender, EventArgs e)
        {
            if (this._userGuideGuide == null) this._userGuideGuide = new UserGuideGuide();
            UserGdBd userGdBd = new UserGdBd();
            System.Windows.Forms.DialogResult result = _userGuideGuide.UserGuideGuideShow(33, 0, this._enterpriseCode, ref userGdBd);

            if ((result == DialogResult.OK) || (result == DialogResult.Yes))
            {
                nedBusinessTypeCode_Ed.SetInt(userGdBd.GuideCode);
            }
        }
        # endregion

        private void optPrintType_ValueChanged(object sender, EventArgs e)
        {
            bool salesEmployeeFlg = false;
            bool salesAreaFlg = false;
            bool businessTypeFlg = false;

            if (optTotalType.CheckedIndex == 0)
            {
                // 担当者
                salesEmployeeFlg = true;
                salesAreaFlg = false;
                businessTypeFlg = false;
            }
            else if (optTotalType.CheckedIndex == 1)
            {
                // 拠点
                salesEmployeeFlg = false;
                salesAreaFlg = false;
                businessTypeFlg = false;
            }
            else if (optTotalType.CheckedIndex == 2)
            {
                // 地区
                salesEmployeeFlg = false;
                salesAreaFlg = true;
                businessTypeFlg = false;
            }
            else if (optTotalType.CheckedIndex == 3)
            {
                // 業種
                salesEmployeeFlg = false;
                salesAreaFlg = false;
                businessTypeFlg = true;
            }

            // 担当者
            btnSalesEmployeeCd_St.Enabled = salesEmployeeFlg;
            btnSalesEmployeeCd_Ed.Enabled = salesEmployeeFlg;
            edtSalesEmployeeCd_St.ReadOnly = !(salesEmployeeFlg);
            edtSalesEmployeeCd_Ed.ReadOnly = !(salesEmployeeFlg);
            if (salesEmployeeFlg == false)
            {
                edtSalesEmployeeCd_St.DataText = string.Empty;
                edtSalesEmployeeCd_Ed.DataText = string.Empty;
            }

            // 地区
            btnSalesAreaCode_St.Enabled = salesAreaFlg;
            btnSalesAreaCode_Ed.Enabled = salesAreaFlg;
            nedSalesAreaCode_St.ReadOnly = !(salesAreaFlg);
            nedSalesAreaCode_Ed.ReadOnly = !(salesAreaFlg);
            if (salesAreaFlg == false)
            {
                nedSalesAreaCode_St.DataText = string.Empty;
                nedSalesAreaCode_Ed.DataText = string.Empty;
            }

            // 業種
            btnBusinessTypeCode_St.Enabled = businessTypeFlg;
            btnBusinessTypeCode_Ed.Enabled = businessTypeFlg;
            nedBusinessTypeCode_St.ReadOnly = !(businessTypeFlg);
            nedBusinessTypeCode_Ed.ReadOnly = !(businessTypeFlg);
            if (businessTypeFlg == false)
            {
                nedBusinessTypeCode_St.DataText = string.Empty;
                nedBusinessTypeCode_Ed.DataText = string.Empty;
            }
        }

    }
}