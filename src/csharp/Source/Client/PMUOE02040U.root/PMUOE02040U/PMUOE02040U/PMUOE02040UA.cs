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
	/// 発行確認一覧表UIクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 発行確認一覧表UIフォームクラス</br>
	/// <br>Programmer : 30009 渋谷 大輔</br>
	/// <br>Date       : 2008.12.02</br>
    /// <br>UpdateNote : 2008.12.24  30009 渋谷 大輔</br>
    /// <br>           : ・不具合の修正</br>
    /// <br>UpdateNote : 2009.01.05  30009 渋谷 大輔</br>
    /// <br>           : ・不具合の修正</br>
    /// <br>Update Note: 2009/03/02 30452 上野 俊治</br>
    /// <br>            ・障害対応12053 システム区分の表示から数値部分を削除</br>
    /// <br></br>
    /// </remarks>
	public partial class PMUOE02040UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
	{
		# region Constractor
		/// <summary>
		/// 発行確認一覧表UIクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 発行確認一覧表UIクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
        /// <br></br>
		/// </remarks>
		public PMUOE02040UA()
		{
			InitializeComponent();

			// 企業コード取得
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// 拠点用のHashtable作成
			this._selectedSectionList = new Hashtable();

            // 日付取得部品
            _dateGet = DateGetAcs.GetInstance();   
		}
		# endregion

		# region Private Menbers
		/// <summary> 拠点コード </summary>
		private string _enterpriseCode = "";
		/// <summary> 画面イメージコントロール部品 </summary>
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 日付取得部品
        private DateGetAcs _dateGet;  

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
		private const string ct_ClassID = "PMUOE02040UA";
		/// <summary> プログラムID </summary>
		private const string ct_PGID = "PMUOE02040U";
		/// <summary> 帳票名称 </summary>
        private const string ct_PrintName = "発行確認一覧表";
        /// <summary> 帳票キー </summary>
		private const string ct_PrintKey = "f91b7283-9d5e-46d9-a4c2-1dcb12ac1145";
		# endregion ◆ Interface member

		// ExporerBar グループ名称
		private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";		// 出力条件

        // 印刷条件
        private const string ct_Chk = "チェック分のみ";
        private const string ct_All = "全て";

        // システム区分
        private const string ct_Type0 = "0:手入力";
        //private const string ct_Type1 = "1:伝発"; // DEL 2009/03/02
        private const string ct_Type1 = "伝発"; // ADD 2009/03/02
        private const string ct_Type2 = "2:検索";
        private const string ct_Type3 = "3:一括";
        private const string ct_Type4 = "4:補充";
        //private const string ct_Type9 = "9:全て";
        //private const string ct_Type9 = "9:伝発以外";    // 2009.01.05 UPD // DEL 2009/03/02
        private const string ct_Type9 = "伝発以外"; // ADD 2009/03/02

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
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
		public int Extract(ref object parameter)
		{
			// 抽出処理は無いので処理終了
			return 0;
		}

		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 印刷処理を行う。</br>
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
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
			PublicationConfOrderCndtn extrInfo = new PublicationConfOrderCndtn();

			// 抽出条件設定処理(画面→抽出条件)
			if (this.SetExtraInfoFromScreen(extrInfo) != 0) return -1;


			// 抽出条件の設定
            //printInfo.PrintPaperSetCd = 20;
            printInfo.PrintPaperSetCd = 0;
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
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
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

		/// <summary>
		/// 画面表示処理
		/// </summary>
		/// <param name="parameter">起動パラメータ</param>
		/// <remarks>
		/// <br>Note		: 画面表示を行う。</br>
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
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
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
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
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
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
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
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
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
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
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
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
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
		private int InitializeScreen(out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;

			try
			{
				// 調整日付
                this.tDateEdit_SalesOrderDate_St.SetDateTime(TDateTime.GetSFDateNow());
                this.tDateEdit_SalesOrderDate_Ed.SetDateTime(TDateTime.GetSFDateNow());
                
                // システム区分アイテム追加
                // 2009.01.05 UPD 必要ない区分を削除 --------------------------------------------------->>
                /*
                systemDivCdComboEditor.Items.Add(0, ct_Type0);
                systemDivCdComboEditor.Items.Add(1, ct_Type1);
                systemDivCdComboEditor.Items.Add(2, ct_Type2);
                systemDivCdComboEditor.Items.Add(3, ct_Type3);
                systemDivCdComboEditor.Items.Add(4, ct_Type4);
                systemDivCdComboEditor.Items.Add(5, ct_Type9);
                systemDivCdComboEditor.SelectedIndex = 0;
                */
                systemDivCdComboEditor.Items.Add(0, ct_Type1);
                systemDivCdComboEditor.Items.Add(1, ct_Type9);
                systemDivCdComboEditor.SelectedIndex = 0;
                // 2009.01.05 UPD ---------------------------------------------------------------------<<

                // 印刷条件アイテム追加
                printConditionComboEditor.Items.Add(0, ct_Chk);
                printConditionComboEditor.Items.Add(1, ct_All);
                printConditionComboEditor.SelectedIndex = 0;
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
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
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
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
        //private int SetExtraInfoFromScreen(ConfirmStockAdjustListCndtn extraInfo)
        private int SetExtraInfoFromScreen(PublicationConfOrderCndtn extraInfo)
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
				// 企業コード
				extraInfo.EnterpriseCode = this._enterpriseCode;

                // 選択拠点
                extraInfo.SectionCodes = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));

                // 受信日付
                extraInfo.St_ReceiveDate = this.tDateEdit_SalesOrderDate_St.GetDateTime();
                extraInfo.Ed_ReceiveDate = this.tDateEdit_SalesOrderDate_Ed.GetDateTime();

                // システム区分
                // 2009.01.05 UPD 必要ない区分を削除 --------------------------------------------------->>
                /*
                if (this.systemDivCdComboEditor.SelectedIndex == 0)
                {
                    // 手入力
                    extraInfo.SystemDivCd = 0;
                }
                else if (this.systemDivCdComboEditor.SelectedIndex == 1)
                {
                    // 伝発
                    extraInfo.SystemDivCd = 1;
                }
                else if (this.systemDivCdComboEditor.SelectedIndex == 2)
                {
                    // 検索
                    extraInfo.SystemDivCd = 2;
                }
                else if (this.systemDivCdComboEditor.SelectedIndex == 3)
                {
                    // 一括
                    extraInfo.SystemDivCd = 3;
                }
                else if (this.systemDivCdComboEditor.SelectedIndex == 4)
                {
                    // 補充
                    extraInfo.SystemDivCd = 4;
                }
                else if (this.systemDivCdComboEditor.SelectedIndex == 5)
                {
                    // 全て
                    extraInfo.SystemDivCd = 9;
                }
                */
                if (this.systemDivCdComboEditor.SelectedIndex == 0)
                {
                    // 伝発
                    extraInfo.SystemDivCd = 1;
                }
                else if (this.systemDivCdComboEditor.SelectedIndex == 1)
                {
                    // 伝発以外
                    extraInfo.SystemDivCd = 9;
                }
                // 2009.01.05 UPD ---------------------------------------------------------------------<<

                // 発行タイプ
                if (this.printConditionComboEditor.SelectedIndex == 0)
                {
                    // チェック分のみ
                    extraInfo.PrintCndtn = 0;
                }
                else if (this.printConditionComboEditor.SelectedIndex == 1)
                {
                    // 全て
                    extraInfo.PrintCndtn = 1;
                }

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
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
		private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
		{
			bool status = true;

			const string ct_InputError = "の入力が不正です";
			const string ct_RangeError = "の範囲指定に誤りがあります";

            DateGetAcs.CheckDateRangeResult cdrResult;
            // 発注日チェック
            // 2008.12.24 UPD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //if (!CallCheckDateRangeAllowNoInput(out cdrResult, ref tDateEdit_SalesOrderDate_St, ref tDateEdit_SalesOrderDate_Ed))
            if (CallCheckDateRange(out cdrResult, ref tDateEdit_SalesOrderDate_St, ref tDateEdit_SalesOrderDate_Ed) == false)
            // 2008.12.24 UPD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = string.Format("発注開始日{0}", ct_InputError);
                            errComponent = this.tDateEdit_SalesOrderDate_St;
                            break;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("発注開始日{0}", ct_InputError);
                            errComponent = this.tDateEdit_SalesOrderDate_St;
                            break;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            errMessage = string.Format("発注終了日{0}", ct_InputError);
                            errComponent = this.tDateEdit_SalesOrderDate_Ed;
                            break;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("発注終了日{0}", ct_InputError);
                            errComponent = this.tDateEdit_SalesOrderDate_Ed;
                            break;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("発注日{0}", ct_RangeError);
                            errComponent = this.tDateEdit_SalesOrderDate_St;
                            break;
                        }
                    default:
                        {
                            errMessage = string.Format("発注日{0}", ct_InputError);
                            errComponent = this.tDateEdit_SalesOrderDate_St;
                            break;
                        }
                }
                status = false;

            }


			return status;
		}

        #region ◎ 日付入力チェック処理
        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_AddUpADate"></param>
        /// <param name="tde_Ed_AddUpADate"></param>
        /// <returns></returns>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_AddUpADate, ref TDateEdit tde_Ed_AddUpADate)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 3, ref tde_St_AddUpADate, ref tde_Ed_AddUpADate, false, false);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// 日付チェック処理呼び出し(範囲チェックなし、未入力OK)
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_AddUpADate"></param>
        /// <param name="tde_Ed_AddUpADate"></param>
        /// <returns></returns>
        private bool CallCheckDateRangeAllowNoInput(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_AddUpADate, ref TDateEdit tde_Ed_AddUpADate)
        {
            cdrResult = DateGetAcs.CheckDateRangeResult.OK;
            if ((tde_St_AddUpADate.GetLongDate() != 0) && (tde_Ed_AddUpADate.GetLongDate() != 0))
            {
                cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref tde_St_AddUpADate, ref tde_Ed_AddUpADate, true);
            }
            else
                if (((tde_St_AddUpADate.GetLongDate() != 0) && (tde_Ed_AddUpADate.GetLongDate() == 0)) ||
                    ((tde_St_AddUpADate.GetLongDate() == 0) && (tde_Ed_AddUpADate.GetLongDate() != 0)))
                {
                    TDateEdit stDate = new TDateEdit();
                    TDateEdit edDate = new TDateEdit();
                    if (tde_St_AddUpADate.GetLongDate() != 0)
                    {
                        stDate = tde_St_AddUpADate;
                    }
                    else
                    {
                        stDate.SetDateTime(DateTime.MinValue);
                    }
                    if (tde_Ed_AddUpADate.GetLongDate() != 0)
                    {
                        edDate = tde_Ed_AddUpADate;

                        DateGetAcs.CheckDateResult cdrResult2 = _dateGet.CheckDate(ref tde_Ed_AddUpADate);
                        if (cdrResult2 != DateGetAcs.CheckDateResult.OK)
                        {
                            cdrResult = DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput;
                            return false;
                        }
                    }
                    else
                    {
                        edDate.SetDateTime(DateTime.MaxValue);
                    }
                    
                    cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 1, ref stDate, ref edDate, true);
                }
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        #endregion

		/// <summary>
		/// エラーメッセージ表示処理
		/// </summary>
		/// <param name="iLevel">エラーレベル</param>
		/// <param name="message">表示メッセージ</param>
		/// <param name="status">ステータス</param>
		/// <remarks>
		/// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
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
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
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
		# endregion

		# region Control Events
		/// <summary>
		/// 画面のLOAD イベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント情報</param>
		/// <remarks>
		/// <br>Note       : 画面のLOAD時に発生します。</br>
		/// </remarks>
		private void PMUOE02040UA_Load(object sender, EventArgs e)
		{
			string errMsg = string.Empty;

			// コントロール初期化
			int status = this.InitializeScreen(out errMsg);
			if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
			{
				MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
				return;
			}


			// 画面イメージ統一
			// 画面スキンファイルの読込(デフォルトスキン指定)
			this._controlScreenSkin.LoadSkin();

			// 画面スキン変更
			this._controlScreenSkin.SettingScreenSkin(this);

			// ツールバー設定イベント
			ParentToolbarSettingEvent(this);
		}

		/// <summary>
		/// 画面の表示状態切替 イベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント情報</param>
		/// <remarks>
		/// <br>Note       : 画面の表示状態が切替る時に発生します。</br>
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
		private void PMUOE02040UA_VisibleChanged(object sender, EventArgs e)
		{
			if (this.Visible == true)
			{
				// 初期フォーカス設定
                tDateEdit_SalesOrderDate_St.Focus();     // ADD 2008.07.04
			}
		}

		/// <summary>
		/// エクスプローラーバー グループ縮小 イベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント情報</param>
		/// <remarks>
		/// <br>Note       : グループが縮小される前に発生します。</br>
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
		private void uebMainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
            if (e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup)
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
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
		private void uebMainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
            if (e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup)
            {
				// グループの縮小をキャンセル
				e.Cancel = true;
			}
		}

        /// <summary>
        /// tRetKeyControl1_ChangeFocusイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : リターンキー押下時に発生するイベントです。</br>
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // 未実装
        }
        # endregion
    }
}