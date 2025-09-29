//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 在庫仕入確認表
// プログラム概要   : 在庫仕入確認表のUIフォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 久保 将太
// 作 成 日  2007/03/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 古賀　小百合
// 修 正 日  2007/07/13  修正内容 : 「不良品確認表」帳票出力を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2007/10/04  修正内容 : DC.NS対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2008/01/22  修正内容 : DC.NS対応（不具合対応）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 疋田 勇人
// 修 正 日  2008/02/26  修正内容 : DC.NS対応（共通修正:日付チェック、0埋め対応）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2008/09/22  修正内容 : PM.NS対応（不具合対応:仕入日の背景色、リターンキー押下イベント追加）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/10/07  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 行澤 仁美
// 修 正 日  2008/10/09  修正内容 : バグ修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/01/22  修正内容 : 不具合対応[10000][10002]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/01/26  修正内容 : 不具合対応[10505]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/07  修正内容 : 障害対応13059
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : tianjw
// 修 正 日  2010/11/15  修正内容 : ＰＭ．ＮＳ　機能改良Ｑ４
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : tianjw
// 修 正 日  2010/11/25  修正内容 : 障害報告 #17555
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 許培珠
// 修 正 日  2011/11/15  修正内容 : redmine#26559 在庫仕入確認表／担当者の出力について
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 3H 楊善娟
// 修 正 日  2017/09/11 修正内容 : ハンディ対応（2次）在庫補充情報の印刷を可能対応
//----------------------------------------------------------------------------//
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
	/// 在庫調整確認表UIクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 入金一覧表UIフォームクラス</br>
	/// <br>Programmer : 22013 久保 将太</br>
	/// <br>Date       : 2007.03.14</br>
	/// <br></br>
    /// <br>UpdateNote : 2007.07.13  20031 古賀　小百合</br>
    /// <br>           :    ・「不良品確認表」帳票出力を追加</br>
    /// <br>UpdateNote : 2007.10.04 980035 金沢 貞義</br>
    /// <br>                ・ DC.NS対応</br>
    /// <br>Update Note: 2008.01.22 980035 金沢 貞義</br>
    /// <br>			    ・DC.NS対応（不具合対応）</br>
    /// <br>Update Note: 2008.02.26 20081 疋田 勇人</br>
    /// <br>			    ・DC.NS対応（共通修正:日付チェック、0埋め対応）</br>
    /// <br>Update Note: 2008.09.22 30452 上野 俊治</br>
    /// <br>			    ・PM.NS対応（不具合対応:仕入日の背景色、リターンキー押下イベント追加）</br>
    /// <br>UpdateNote : 2008/10/07       照田 貴志</br>
    /// <br>			    ・バグ修正、仕様変更対応</br>
    /// <br>UpdateNote : 2008/10/09 30462 行澤 仁美　バグ修正</br>
    /// <br>           : 2009/01/22       照田 貴志　不具合対応[10000][10002]</br>
    /// <BR>             2009/01/26       照田 貴志　不具合対応[10505]</BR>
    /// <br>Update Note: 2009/04/07 30452 上野 俊治</br>
    /// <br>            ・障害対応13059</br>
    /// <br>Update Note: 2010/11/15 tianjw</br>
    /// <br>            ・ＰＭ．ＮＳ　機能改良Ｑ４</br>
    /// <br>Update Note: 2010/11/25 tianjw</br>
    /// <br>            ・障害報告 #17555</br>
    /// <br>Update Note: 2017/09/11 3H 楊善娟</br>
    /// <br>管理番号   : 11370074-00 ハンディ対応（2次）</br>
    /// <br>             在庫補充情報の印刷を可能対応</br> 
    /// </remarks>
	public partial class MAZAI02050UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
	{
		# region Constractor
		/// <summary>
		/// 在庫調整確認表UIクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫調整確認表UIクラスの初期化およびインスタンスの生成を行う</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.14</br>
		/// <br></br>
		/// </remarks>
		public MAZAI02050UA()
		{
			InitializeComponent();

			// 企業コード取得
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// 拠点用のHashtable作成
			this._selectedSectionList = new Hashtable();

            // 日付取得部品
            _dateGet = DateGetAcs.GetInstance();   // 2008.02.26 add
		}
		# endregion

		# region Private Menbers
		/// <summary> 拠点コード </summary>
		private string _enterpriseCode = "";
		/// <summary> 画面イメージコントロール部品 </summary>
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		/// <summary> 担当者アクセスクラス </summary>
		private EmployeeAcs _employeeAcs = null;

        //--- DEL 2008/07/04 ---------->>>>>
        ///// <summary> メーカーアクセスクラス </summary>
        //private MakerAcs _makerAcs = null;
        //--- DEL 2008/07/04 ----------<<<<<

        //--- DEL 2008/07/04 ---------->>>>>
        ///// <summary> 商品ガイドフォーム </summary>
        //private MAKHN04110UA _MAKHN04110UA = null;
        //--- DEL 2008/07/04 ----------<<<<<

        // 2008.01.22 追加 >>>>>>>>>>>>>>>>>>>>
        /// <summary> 倉庫アクセスクラス </summary>
        private WarehouseAcs _warehouseGuideAcs = null;
        // 2008.01.22 追加 <<<<<<<<<<<<<<<<<<<<

        // 日付取得部品
        private DateGetAcs _dateGet;  // 2008.02.26 add

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

        // ----- ADD 2010/11/25 ----------->>>>>
        private int _pretComboEditor2Index = 0;
        private int _pretComboEditor1Index = 0;
        private int _pretComboEditor3Index = 0;
        // ----- ADD 2010/11/25 -----------<<<<<
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
		private const string ct_ClassID = "MAZAI02050UA";
		/// <summary> プログラムID </summary>
		private const string ct_PGID = "MAZAI02050U";
		/// <summary> 帳票名称 </summary>
        //private const string ct_PrintName = "在庫調整確認表";     // DEL 2008.07.04
        //private const string ct_PrintName = "在庫品仕入確認表";     // ADD 2008.07.04 //DEL 2008/09/24
        private const string ct_PrintName = "在庫仕入確認表";     // ADD 2008/09/24
        /// <summary> 帳票キー </summary>
		private const string ct_PrintKey = "f91b7283-9d5e-46d9-a4c2-1dcb12ac1145";
		# endregion ◆ Interface member

		// ExporerBar グループ名称
		private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";		// 出力条件
        private const string ct_ExBarGroupNm_SortOrderGroup = "SortOrderGroup";	// ソート順　// ADD 2010/11/15
		private const string ct_ExBarGroupNm_ExtractConditionGroup = "ExtractConditionGroup";	// 抽出条件

        //--- ADD 2008/07/04 ---------->>>>>
        // 改頁項目
        private const string ct_Section   = "拠点";
        private const string ct_Warehouse = "倉庫";
        private const string ct_Nothing   = "しない";

        // ----- ADD 2010/11/15 ---------->>>>>
        private const string ct_AdjustDateSort = "仕入日順";
        private const string ct_WarehouseShelfNoSort = "棚番順";
        // ----- ADD 2010/11/15 ----------<<<<<

        // 発行タイプ
        // --- DEL 2008/09/19 -------------------------------->>>>>
        //private const string ct_Type1 = "調整入力分";
        // --- DEL 2008/09/19 --------------------------------<<<<<
        // --- ADD 2008/09/19 -------------------------------->>>>>
        private const string ct_Type1 = "在庫仕入入力分";
        // --- ADD 2008/09/19 --------------------------------<<<<<
        private const string ct_Type2 = "棚卸調整分";
        private const string ct_Type3 = "マスメン調整分";
        private const string ct_Type4 = "全て";
        private const string ct_Type5 = "委託在庫補充分"; // --- ADD 3H 楊善娟 2017/09/11

        // 倉庫コード
        private const string ct_WarehouseCode_Max = "9999";
        private const string ct_WarehouseCode_Min = "0";
        // 入力担当者コード
        private const string ct_InputAgenCd_Max = "9999";
        private const string ct_InputAgenCd_Min = "0";
        //--- ADD 2008/07/04 ---------->>>>>
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
		/// <br>Programmer	: 97036 amami</br>
		/// <br>Date		: 2007.03.14</br>
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
		/// <br>Programmer	: 97036 amami</br>
		/// <br>Date		: 2007.03.14</br>
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
			ConfirmStockAdjustListCndtn extrInfo = new ConfirmStockAdjustListCndtn();

			// 抽出条件設定処理(画面→抽出条件)
			if (this.SetExtraInfoFromScreen(extrInfo) != 0) return -1;


			// 抽出条件の設定
            //printInfo.PrintPaperSetCd = extrInfo.PrintDiv;        // DEL 2008.07.04
            printInfo.PrintPaperSetCd = 20;                         // ADD 2008.07.04
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
		/// <br>Programmer	: 97036 amami</br>
		/// <br>Date		: 2007.03.14</br>
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
		/// <br>Programmer	: 97036 amami</br>
		/// <br>Date		: 2007.03.14</br>
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
		/// <br>Programmer	: 97036 amami</br>
		/// <br>Date		: 2007.03.14</br>
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
		/// <br>Programmer	: 97036 amami</br>
		/// <br>Date		: 2007.03.14</br>
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
		/// <br>Programmer	: 97036 amami</br>
		/// <br>Date		: 2007.03.14</br>
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
		/// <br>Programmer	: 97036 amami</br>
		/// <br>Date		: 2007.03.14</br>
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
		/// <br>Programmer	: 97036 amami</br>
		/// <br>Date		: 2007.03.14</br>
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
		/// <br>Programmer	: 97036 amami</br>
        /// <br>Date		: 2007.03.14</br>
        /// <br>Update Note: 2010/11/15 tianjw</br>
        /// <br>            ・ＰＭ．ＮＳ　機能改良Ｑ４</br>
		/// </remarks>
		private int InitializeScreen(out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;

			try
			{

				// 調整日付
                this.detAdjustDate_St.SetDateTime(TDateTime.GetSFDateNow());
                this.detAdjustDate_Ed.SetDateTime(TDateTime.GetSFDateNow());
                // 在庫調整伝票番号
                // 2008.01.22 修正 >>>>>>>>>>>>>>>>>>>>
                //this.nedStockAdjustSlipNo_St.SetInt(0);
				//this.nedStockAdjustSlipNo_Ed.SetInt(999999999);
                //--- DEL 2008/07/04 ---------->>>>>
                //this.nedStockAdjustSlipNo_St.Clear();
                //this.nedStockAdjustSlipNo_Ed.Clear();
                //--- DEL 2008/07/04 ----------<<<<<
                // 2008.01.22 修正 <<<<<<<<<<<<<<<<<<<<
                // メーカーコード
                // 2008.01.22 修正 >>>>>>>>>>>>>>>>>>>>
                //this.nedMakerCode_St.SetInt(0);
                //// 2007.10.04 修正 >>>>>>>>>>>>>>>>>>>>
                ////this.nedMakerCode_Ed.SetInt(999);
                //this.nedMakerCode_Ed.SetInt(999999);
                //// 2007.10.04 修正 <<<<<<<<<<<<<<<<<<<<
                //--- DEL 2008/07/04 ---------->>>>>
                //this.nedMakerCode_St.Clear();
                //this.nedMakerCode_Ed.Clear();
                //--- DEL 2008/07/04 ----------<<<<<
                // 2008.01.22 修正 <<<<<<<<<<<<<<<<<<<<
                //--- DEL 2008/07/04 ---------->>>>>
                // 商品コード
                //this.edtGoodsCode_St.DataText = "";
                //this.edtGoodsCode_Ed.DataText = "";
                //--- DEL 2008/07/04 ----------<<<<<
                // 2007.10.04 削除 >>>>>>>>>>>>>>>>>>>>
                //// 製造番号
				//this.edtProductNumber_St.DataText = "";
				//this.edtProductNumber_Ed.DataText = "";
				//// 携帯電話番号
				//this.edtStockTelNo_St.DataText = "";
				//this.edtStockTelNo_Ed.DataText = "";
                // 2007.10.04 削除 <<<<<<<<<<<<<<<<<<<<
                // 入力担当者コード
				this.tEdit_EmployeeCode_St.DataText = "";
				this.tEdit_EmployeeCode_Ed.DataText = "";
                // 2008.01.22 追加 >>>>>>>>>>>>>>>>>>>>
                // 倉庫コード
                this.tEdit_WarehouseCode_St.DataText = "";
                this.tEdit_WarehouseCode_Ed.DataText = "";
                // 2008.01.22 追加 <<<<<<<<<<<<<<<<<<<<

                // ---------- ADD 2010/11/15 ---------->>>>>
                // ソート順アイテム追加
                tComboEditor3.Items.Add(0, ct_AdjustDateSort);
                tComboEditor3.Items.Add(1, ct_WarehouseShelfNoSort);
                tComboEditor3.SelectedIndex = 0;
                tComboEditor1.Items.Clear();
                // ---------- ADD 2010/11/15 ----------<<<<<

                //--- ADD 2008/07/04 ---------->>>>>
                // 改頁アイテム追加
                tComboEditor1.Items.Add(0, ct_Section);
                tComboEditor1.Items.Add(1, ct_Warehouse);
                tComboEditor1.Items.Add(2, ct_Nothing);
                tComboEditor1.SelectedIndex = 0;

                // 発行タイプアイテム追加
                tComboEditor2.Items.Add(0, ct_Type1);
                tComboEditor2.Items.Add(1, ct_Type2);
                tComboEditor2.Items.Add(2, ct_Type3);
                // --- ADD 3H 楊善娟 2017/09/11---------->>>>>
                tComboEditor2.Items.Add(3, ct_Type5);
                tComboEditor2.Items.Add(4, ct_Type4);
                // --- ADD 3H 楊善娟 2017/09/11----------<<<<<
                //tComboEditor2.Items.Add(3, ct_Type4); // --- DEL 3H 楊善娟 2017/09/11
                tComboEditor2.SelectedIndex = 0;
                //--- ADD 2008/07/04 ----------<<<<<

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
		/// <br>Programmer	: 97036 amami</br>
		/// <br>Date		: 2007.03.14</br>
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
		/// <br>Programmer	: 97036 amami</br>
        /// <br>Date		: 2007.03.14</br>
        /// <br>Update Note: 2010/11/15 tianjw</br>
        /// <br>            ・ＰＭ．ＮＳ　機能改良Ｑ４</br>
        /// <br>Update Note: 2017/09/11 3H 楊善娟</br>
        /// <br>管理番号   : 11370074-00 ハンディ対応（2次）</br>
        /// <br>             在庫補充情報の印刷を可能対応</br>
		/// </remarks>
		private int SetExtraInfoFromScreen(ConfirmStockAdjustListCndtn extraInfo)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
				// 企業コード
				extraInfo.EnterpriseCode = this._enterpriseCode;
                // 2007.10.04 修正 >>>>>>>>>>>>>>>>>>>>
                //// 拠点オプション
				//extraInfo.IsOptSection = this._isOptSection;
				//// 選択拠点
				//extraInfo.SecCodeList = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));
                // 選択拠点
                extraInfo.SectionCodeList = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));
                // 2007.10.04 修正 <<<<<<<<<<<<<<<<<<<<
                // 調整日付
                extraInfo.St_AdjustDate = this.detAdjustDate_St.GetDateTime();
                extraInfo.Ed_AdjustDate = this.detAdjustDate_Ed.GetDateTime();
                //--- ADD 2008/07/04 ---------->>>>>
                // 入力日付
                extraInfo.St_InputDay = this.detInputDay_St.GetDateTime();
                extraInfo.Ed_InputDay = this.detInputDay_Ed.GetDateTime();
                //--- ADD 2008/07/04 ----------<<<<<
                //--- DEL 2008/07/04 ---------->>>>>
                // 在庫調整伝票番号
                //extraInfo.St_StockAdjustSlipNo = this.nedStockAdjustSlipNo_St.GetInt();
                //--- DEL 2008/07/04 ----------<<<<<
                // 2008.01.22 修正 >>>>>>>>>>>>>>>>>>>>
                //extraInfo.Ed_StockAdjustSlipNo = this.nedStockAdjustSlipNo_Ed.GetInt();
                //--- DEL 2008/07/04 ---------->>>>>
                //if (this.nedStockAdjustSlipNo_Ed.GetInt() == 0)
                //{
                //    extraInfo.Ed_StockAdjustSlipNo = 999999999;
                //}
                //else
                //{
                //    extraInfo.Ed_StockAdjustSlipNo = this.nedStockAdjustSlipNo_Ed.GetInt();
                //}
                //--- DEL 2008/07/04 ----------<<<<<
                // 2008.01.22 修正 <<<<<<<<<<<<<<<<<<<<
                // 2007.10.04 修正 >>>>>>>>>>>>>>>>>>>>
                //// メーカーコード
				//extraInfo.St_MakerCode = this.nedMakerCode_St.GetInt();
				//extraInfo.Ed_MakerCode = this.nedMakerCode_Ed.GetInt();
				//// 商品コード
				//extraInfo.St_GoodsCode = this.edtGoodsCode_St.DataText.TrimEnd();
				//extraInfo.Ed_GoodsCode = this.edtGoodsCode_Ed.DataText.TrimEnd();
                //--- DEL 2008/07/04 ---------->>>>>
                // メーカーコード
                //extraInfo.St_GoodsMakerCd = this.nedMakerCode_St.GetInt();
                //--- DEL 2008/07/04 ----------<<<<<
                // 2008.01.22 修正 >>>>>>>>>>>>>>>>>>>>
                //extraInfo.Ed_GoodsMakerCd = this.nedMakerCode_Ed.GetInt();
                //--- DEL 2008/07/04 ---------->>>>>
                //if (this.nedMakerCode_Ed.GetInt() == 0)
                //{
                //    extraInfo.Ed_GoodsMakerCd = 999999;
                //}
                //else
                //{
                //    extraInfo.Ed_GoodsMakerCd = this.nedMakerCode_Ed.GetInt();
                //}
                //--- DEL 2008/07/04 ----------<<<<<
                // 2008.01.22 修正 <<<<<<<<<<<<<<<<<<<<
                //--- DEL 2008/07/04 ---------->>>>>
                // 商品コード
                //extraInfo.St_GoodsNo = this.edtGoodsCode_St.DataText.TrimEnd();
                //extraInfo.Ed_GoodsNo = this.edtGoodsCode_Ed.DataText.TrimEnd();
                //--- DEL 2008/07/04 ----------<<<<<
                // 2007.10.04 修正 <<<<<<<<<<<<<<<<<<<<
                // 2007.10.04 削除 >>>>>>>>>>>>>>>>>>>>
                //// 製造番号
				//extraInfo.St_ProductNumber = this.edtProductNumber_St.DataText.TrimEnd();
				//extraInfo.Ed_ProductNumber = this.edtProductNumber_Ed.DataText.TrimEnd();
				//// 電話番号
				//extraInfo.St_StockTelNo1 = this.edtStockTelNo_St.DataText.TrimEnd();
				//extraInfo.Ed_StockTelNo1 = this.edtStockTelNo_Ed.DataText.TrimEnd();
                // 2007.10.04 削除 <<<<<<<<<<<<<<<<<<<<
                // 入力担当者コード
				extraInfo.St_InputAgenCd = this.tEdit_EmployeeCode_St.DataText.TrimEnd();
				extraInfo.Ed_InputAgenCd = this.tEdit_EmployeeCode_Ed.DataText.TrimEnd();
				// 帳票区分
                //--- DEL 2008.07.04 ---------->>>>>
                //int printDiv;
                //string printDivName;
                //this.GetSelectPrintType(out printDiv, out printDivName);          
                //extraInfo.PrintDiv = printDiv;
                //extraInfo.PrintDivName = printDivName;
                //--- DEL 2008.07.04 ----------<<<<<

                // 2008.01.22 追加 >>>>>>>>>>>>>>>>>>>>
                // 倉庫コード
                extraInfo.St_WarehouseCode = this.tEdit_WarehouseCode_St.DataText.TrimEnd();
                extraInfo.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.DataText.TrimEnd();
                // 2008.01.22 追加 <<<<<<<<<<<<<<<<<<<<

                //--- ADD 2008.07.07 ---------->>>>>
                // 改頁条件
                extraInfo.ChangePage = this.tComboEditor1.SelectedIndex;

                // ---------- ADD 2010/11/15 ---------->>>>>
                // 出力順条件
                extraInfo.OutputSort = this.tComboEditor3.SelectedIndex;
                // ---------- ADD 2010/11/15 ----------<<<<<

                /* ---DEL 2009/01/26 不具合対応[10505] -------------------------------------->>>>>
                // 発行タイプ
                if (this.tComboEditor2.SelectedIndex == 0)
                {
                    // --- DEL 2008/09/19 -------------------------------->>>>>
                    // 調整入力分
                    //extraInfo.AcPaySlipCd = 40;
                    // --- DEL 2008/09/19 --------------------------------<<<<<
                    // --- ADD 2008/09/19 -------------------------------->>>>>
                    // 在庫仕入入力分
                    extraInfo.AcPaySlipCd = 13;
                    // --- ADD 2008/09/19 --------------------------------<<<<<
                }
                else if (this.tComboEditor2.SelectedIndex == 1)
                {
                    // 棚卸調整分
                    extraInfo.AcPaySlipCd = 50;
                }
                else if (this.tComboEditor2.SelectedIndex == 2)
                {
                    // マスメン調整分
                    extraInfo.AcPaySlipCd = 42;
                }
                else if (this.tComboEditor2.SelectedIndex == 3)
                {
                    // 全て
                    extraInfo.AcPaySlipCd = -1;
                }
                //--- ADD 2008.07.07 ----------<<<<<
                   ---DEL 2009/01/26 不具合対応[10505] --------------------------------------<<<<< */
                // ---ADD 2009/01/26 不具合対応[10505] -------------------------------------->>>>>
                ArrayList ary = new ArrayList();
                if (this.tComboEditor2.SelectedIndex == 0)
                {
                    // 在庫仕入入力分
                    ary.Add(13);
                    extraInfo.AcPaySlipCd = (Int32[])ary.ToArray(typeof(Int32));
                }
                else if (this.tComboEditor2.SelectedIndex == 1)
                {
                    // 棚卸調整分
                    ary.Add(50);
                    extraInfo.AcPaySlipCd = (Int32[])ary.ToArray(typeof(Int32));
                }
                else if (this.tComboEditor2.SelectedIndex == 2)
                {
                    // マスメン調整分
                    ary.Add(42);
                    ary.Add(60);
                    ary.Add(61);
                    ary.Add(70);
                    ary.Add(71);
                    extraInfo.AcPaySlipCd = (Int32[])ary.ToArray(typeof(Int32));
                }
                // --- ADD 3H 楊善娟 2017/09/11---------->>>>>
                else if (this.tComboEditor2.SelectedIndex == 3)
                {
                    // 委託在庫補充分
                    ary.Add(70);  // 70:補充入庫
                    ary.Add(71);  // 71:補充出庫
                    extraInfo.AcPaySlipCd = (Int32[])ary.ToArray(typeof(Int32));
                }
                else if (this.tComboEditor2.SelectedIndex == 4)
                {
                    // 全て
                    extraInfo.AcPaySlipCd = null;
                }
                // --- ADD 3H 楊善娟 2017/09/11----------<<<<<
                // --- DEL 3H 楊善娟 2017/09/11---------->>>>>
                //else if (this.tComboEditor2.SelectedIndex == 3)
                //{
                //// 全て
                //extraInfo.AcPaySlipCd = null;
                //}
                // --- DEL 3H 楊善娟 2017/09/11----------<<<<<
                // ---ADD 2009/01/26 不具合対応[10505] --------------------------------------<<<<<
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
		/// <br>Programmer	: 97036 amami</br>
		/// <br>Date		: 2007.03.14</br>
		/// </remarks>
		private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
		{
			bool status = true;

			const string ct_InputError = "の入力が不正です";
			const string ct_RangeError = "の範囲指定に誤りがあります";

            // 2008.02.26 upd start -------------------------------------->>
            //// 開始 調整日付のチェック
            //if ((this.detAdjustDate_St.GetLongDate() != 0) && (TDateTime.IsAvailableDate(this.detAdjustDate_St.GetDateTime()) == false))
            //{
            //    errMessage = string.Format("開始 調整日付{0}", ct_InputError);
            //    errComponent = this.detAdjustDate_St;
            //    status = false;
            //}
            //// 終了 調整日付のチェック
            //else if ((this.detAdjustDate_Ed.GetLongDate() != 0) && (TDateTime.IsAvailableDate(this.detAdjustDate_Ed.GetDateTime()) == false))
            //{
            //    errMessage = string.Format("終了 調整日付{0}", ct_InputError);
            //    // 2008.01.22 修正 >>>>>>>>>>>>>>>>>>>>
            //    //errComponent = this.detAdjustDate_St;
            //    errComponent = this.detAdjustDate_Ed;
            //    // 2008.01.22 修正 <<<<<<<<<<<<<<<<<<<<
            //    status = false;
            //}
            //// 日付の範囲をチェック(開始日 > 終了日 → NG)
            //else if (this.detAdjustDate_St.GetLongDate() > this.detAdjustDate_Ed.GetLongDate())
            //{
            //    errMessage = string.Format("調整日付{0}", ct_RangeError);
            //    errComponent = this.detAdjustDate_St;
            //    status = false;
            //}
            //const string ct_RangeError1 = "の範囲指定に誤りがあります(１ヶ月以内で設定して下さい)";       // DEL 2008.07.04
            const string ct_RangeError1 = "の範囲指定に誤りがあります(３ヶ月以内で設定して下さい)";         // ADD 2008.07.04

            DateGetAcs.CheckDateRangeResult cdrResult;
            // 調整日（開始～終了）
            //if (CallCheckDateRange(out cdrResult, ref detAdjustDate_St, ref detAdjustDate_Ed) == false) // DEL 2009/04/07
            if (!CallCheckDateRangeAllowNoInput(out cdrResult, ref detAdjustDate_St, ref detAdjustDate_Ed)) // ADD 2009/04/07
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            /* --- DEL 2008/10/07 文言変更 ---------------------------->>>>>
                            // --- DEL 2008/09/19 -------------------------------->>>>>
                            //errMessage = string.Format("調整開始日{0}", ct_InputError);
                            // --- DEL 2008/09/19 -------------------------------->>>>>
                            // --- ADD 2008/09/19 -------------------------------->>>>>
                            errMessage = string.Format("仕入開始日付{0}", ct_InputError);
                            // --- ADD 2008/09/19 --------------------------------<<<<<
                               --- DEL 2008/10/07 -------------------------------------<<<<< */
                            errMessage = string.Format("仕入開始日{0}", ct_InputError);     // ADD 2008/10/07

                            errComponent = this.detAdjustDate_St;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            /* --- DEL 2008/10/07 文言変更 ---------------------------->>>>>
                            // --- DEL 2008/09/19 -------------------------------->>>>>
                            //errMessage = string.Format("調整開始日{0}", ct_InputError);
                            // --- DEL 2008/09/19 -------------------------------->>>>>
                            // --- ADD 2008/09/19 -------------------------------->>>>>
                            errMessage = string.Format("仕入開始日付{0}", ct_InputError);
                            // --- ADD 2008/09/19 --------------------------------<<<<<
                               --- DEL 2008/10/07 -------------------------------------<<<<< */
                            errMessage = string.Format("仕入開始日{0}", ct_InputError);     //ADD 2008/10/07

                            errComponent = this.detAdjustDate_St;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            /* --- DEL 2008/10/07 文言変更 ---------------------------->>>>>
                            // --- DEL 2008/09/19 -------------------------------->>>>>
                            //errMessage = string.Format("調整終了日{0}", ct_InputError);
                            // --- DEL 2008/09/19 --------------------------------<<<<<
                            // --- ADD 2008/09/19 -------------------------------->>>>>
                            errMessage = string.Format("仕入終了日付{0}", ct_InputError);
                            // --- ADD 2008/09/19 --------------------------------<<<<<
                               --- DEL 2008/10/07 -------------------------------------<<<<< */
                            errMessage = string.Format("仕入終了日{0}", ct_InputError);     //ADD 2008/10/07

                            errComponent = this.detAdjustDate_Ed;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            /* --- DEL 2008/10/07 文言変更 ---------------------------->>>>>
                            // --- DEL 2008/09/19 -------------------------------->>>>>
                            //errMessage = string.Format("調整終了日{0}", ct_InputError);
                            // --- DEL 2008/09/19 -------------------------------->>>>>
                            // --- ADD 2008/09/19 -------------------------------->>>>>
                            errMessage = string.Format("仕入終了日付{0}", ct_InputError);
                            // --- ADD 2008/09/19 --------------------------------<<<<<
                               --- DEL 2008/10/07 -------------------------------------<<<<< */
                            errMessage = string.Format("仕入終了日{0}", ct_InputError);     //ADD 2008/10/07

                            errComponent = this.detAdjustDate_Ed;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            /* --- DEL 2008/10/07 文言変更 ---------------------------->>>>>
                            // --- DEL 2008/09/19 -------------------------------->>>>>
                            //errMessage = string.Format("調整日{0}", ct_RangeError);
                            // --- DEL 2008/09/19 --------------------------------<<<<<
                            // --- ADD 2008/09/19 -------------------------------->>>>>
                            errMessage = string.Format("仕入日付{0}", ct_RangeError);
                            // --- ADD 2008/09/19 --------------------------------<<<<<
                               --- DEL 2008/10/07 -------------------------------------<<<<< */
                            errMessage = string.Format("仕入日{0}", ct_RangeError);         //ADD 2008/10/07

                            errComponent = this.detAdjustDate_St;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        {
                            /* --- DEL 2008/10/07 文言変更 ---------------------------->>>>>
                            // --- DEL 2008/09/19 -------------------------------->>>>>
                            //errMessage = string.Format("調整日{0}", ct_RangeError1);
                            // --- DEL 2008/09/19 -------------------------------->>>>>
                            // --- ADD 2008/09/19 -------------------------------->>>>>
                            errMessage = string.Format("仕入日付{0}", ct_RangeError1);
                            // --- ADD 2008/09/19 --------------------------------<<<<<
                               --- DEL 2008/10/07 -------------------------------------<<<<< */
                            errMessage = string.Format("仕入日{0}", ct_RangeError1);        //ADD 2008/10/07

                            errComponent = this.detAdjustDate_St;
                        }
                        break;
                }
                //status = false; // DEL 2009/04/07
                // --- ADD 2009/04/07 -------------------------------->>>>>
                if (errComponent != null)
                {
                    return false;
                }
                // --- ADD 2009/04/07 --------------------------------<<<<<
            }

            // --- ADD 2008/09/19 -------------------------------->>>>>
            // 入力日チェック
            if (!CallCheckDateRangeAllowNoInput(out cdrResult, ref detInputDay_St, ref detInputDay_Ed))
            {
                switch (cdrResult)
                {
                    /* ---DEL 2009/01/22 不具合対応[10000] ---------------------------->>>>>
                    // ADD 2008/10/09 不具合対応[6375] ---------->>>>>
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = string.Format("入力開始日{0}", ct_InputError);
                            errComponent = this.detInputDay_St;
                            break;
                        }
                    // ADD 2008/10/09 不具合対応[6375] ----------<<<<<
                       ---DEL 2009/01/22 不具合対応[10000] ----------------------------<<<<< */
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("入力開始日{0}", ct_InputError);
                            errComponent = this.detInputDay_St;
                            break;
                        }
                    /* ---DEL 2009/01/22 不具合対応[10000] ---------------------------->>>>>
                    // ADD 2008/10/09 不具合対応[6375] ---------->>>>>
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            errMessage = string.Format("入力終了日{0}", ct_InputError);
                            errComponent = this.detInputDay_Ed;
                            break;
                        }
                    // ADD 2008/10/09 不具合対応[6375] ----------<<<<<
                       ---DEL 2009/01/22 不具合対応[10000] ----------------------------<<<<< */
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("入力終了日{0}", ct_InputError);
                            errComponent = this.detInputDay_Ed;
                            break;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("入力日{0}", ct_RangeError);
                            errComponent = this.detInputDay_St;
                            break;
                        }
                    default:
                        {
                            errMessage = string.Format("入力日{0}", ct_InputError);
                            errComponent = this.detInputDay_St;
                            break;
                        }
                }
                //status = false; // DEL 2009/04/07

                // --- ADD 2009/04/07 -------------------------------->>>>>
                if (errComponent != null)
                {
                    return false;
                }
                // --- ADD 2009/04/07 --------------------------------<<<<<
            }
            // --- ADD 2008/09/19 --------------------------------<<<<<

            //--- ADD 2008/07/04 ---------->>>>>
            // 入力日（開始～終了）
            //if (CallCheckDateRange(out cdrResult, ref detInputDay_St, ref detInputDay_Ed) == false)
            //{
            //    switch (cdrResult)
            //    {
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
            //            {
            //                errMessage = string.Format("入力開始日{0}", ct_InputError);
            //                errComponent = this.detAdjustDate_St;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
            //            {
            //                errMessage = string.Format("入力開始日{0}", ct_InputError);
            //                errComponent = this.detAdjustDate_St;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
            //            {
            //                errMessage = string.Format("入力終了日{0}", ct_InputError);
            //                errComponent = this.detAdjustDate_Ed;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
            //            {
            //                errMessage = string.Format("入力終了日{0}", ct_InputError);
            //                errComponent = this.detAdjustDate_Ed;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
            //            {
            //                errMessage = string.Format("入力日{0}", ct_RangeError);
            //                errComponent = this.detAdjustDate_St;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
            //            {
            //                errMessage = string.Format("入力日{0}", ct_RangeError1);
            //                errComponent = this.detAdjustDate_St;
            //            }
            //            break;
            //    }
            //    status = false;
            //}
            //--- ADD 2008/07/04 ----------<<<<<
            // 2008.02.26 upd end -----------------------------------------<<

            // 2008.01.22 修正 >>>>>>>>>>>>>>>>>>>>
            //// 得意先コード
            //else if (this.nedStockAdjustSlipNo_St.GetInt() > this.nedStockAdjustSlipNo_Ed.GetInt())
            //{
            //    errMessage = string.Format("得意先コード{0}", ct_RangeError);
            //    errComponent = this.nedStockAdjustSlipNo_St;
            //    status = false;
            //}
            //--- DEL 2008/07/04 ---------->>>>>
            // 在庫調整伝票番号
            //else if (                     // DEL 2008.07.04
            //        (this.nedStockAdjustSlipNo_St.GetInt() != 0) &&
            //        (this.nedStockAdjustSlipNo_Ed.GetInt() != 0) &&
            //        (this.nedStockAdjustSlipNo_St.GetInt() > this.nedStockAdjustSlipNo_Ed.GetInt()))
            //{
            //    errMessage = string.Format("在庫調整伝票番号{0}", ct_RangeError);
            //    errComponent = this.nedStockAdjustSlipNo_St;
            //    status = false;
            //}
            //--- DEL 2008/07/04 ----------<<<<<
            // 2008.01.22 修正 <<<<<<<<<<<<<<<<<<<<
            // メーカーコード
            // 2008.01.22 修正 >>>>>>>>>>>>>>>>>>>>
            //else if (this.nedMakerCode_St.GetInt() > this.nedMakerCode_Ed.GetInt())
            //--- DEL 2008/07/04 ---------->>>>>
            //else if (
            //        (this.nedMakerCode_St.GetInt() != 0) &&
            //        (this.nedMakerCode_Ed.GetInt() != 0) &&
            //        (this.nedMakerCode_St.GetInt() > this.nedMakerCode_Ed.GetInt()))
            //// 2008.01.22 修正 <<<<<<<<<<<<<<<<<<<<
            //{
            //    errMessage = string.Format("メーカーコード{0}", ct_RangeError);
            //    errComponent = this.nedMakerCode_St;
            //    status = false;
            //}
            //// 商品コード
            //else if (
            //        (this.edtGoodsCode_St.DataText.TrimEnd() != string.Empty) &&
            //        (this.edtGoodsCode_Ed.DataText.TrimEnd() != string.Empty) &&
            //        (this.edtGoodsCode_St.DataText.TrimEnd().CompareTo(this.edtGoodsCode_Ed.DataText.TrimEnd()) > 0))
            //{
            //    errMessage = string.Format("商品コード{0}", ct_RangeError);
            //    errComponent = this.edtGoodsCode_St;
            //    status = false;
            //}
            //--- DEL 2008/07/04 ----------<<<<<
            // 2007.10.04 削除 >>>>>>>>>>>>>>>>>>>>
            //// 製造番号
            //else if (
            //		(this.edtProductNumber_St.DataText.TrimEnd() != string.Empty) &&
            //		(this.edtProductNumber_Ed.DataText.TrimEnd() != string.Empty) &&
            //		(this.edtProductNumber_St.DataText.TrimEnd().CompareTo(this.edtProductNumber_Ed.DataText.TrimEnd()) > 0))
            //{
            //	errMessage = string.Format("製造番号{0}", ct_RangeError);
            //	errComponent = this.edtProductNumber_St;
            //	status = false;
            //}
            //// 携帯電話番号
            //else if (
            //		(this.edtStockTelNo_St.DataText.TrimEnd() != string.Empty) &&
            //		(this.edtStockTelNo_Ed.DataText.TrimEnd() != string.Empty) &&
            //		(this.edtStockTelNo_St.DataText.TrimEnd().CompareTo(this.edtStockTelNo_Ed.DataText.TrimEnd()) > 0))
            //{
            //	errMessage = string.Format("携帯電話番号{0}", ct_RangeError);
            //	errComponent = this.edtStockTelNo_St;
            //	status = false;
            //}
            // 2007.10.04 削除 <<<<<<<<<<<<<<<<<<<<
            // 入力担当者コード
            //else if (             // DEL 2008.07.04
			if (
					(this.tEdit_EmployeeCode_St.DataText.TrimEnd() != string.Empty) &&
					(this.tEdit_EmployeeCode_Ed.DataText.TrimEnd() != string.Empty) &&
					(this.tEdit_EmployeeCode_St.DataText.TrimEnd().CompareTo(this.tEdit_EmployeeCode_Ed.DataText.TrimEnd()) > 0))
			{
				errMessage = string.Format("入力担当者コード{0}", ct_RangeError);
				errComponent = this.tEdit_EmployeeCode_St;
				status = false;
			}
            // 2008.01.22 追加 >>>>>>>>>>>>>>>>>>>>
            // 倉庫コード
            else if (
                    (this.tEdit_WarehouseCode_St.DataText.TrimEnd() != string.Empty) &&
                    (this.tEdit_WarehouseCode_Ed.DataText.TrimEnd() != string.Empty) &&
                    (this.tEdit_WarehouseCode_St.DataText.TrimEnd().CompareTo(this.tEdit_WarehouseCode_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("倉庫コード{0}", ct_RangeError);
                errComponent = this.tEdit_WarehouseCode_St;
                status = false;
            }
            // 2008.01.22 追加 <<<<<<<<<<<<<<<<<<<<

			return status;
		}

        #region ◎ 日付入力チェック処理
        // 2008.02.26 add start ------------------------------------->>
        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_AddUpADate"></param>
        /// <param name="tde_Ed_AddUpADate"></param>
        /// <returns></returns>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_AddUpADate, ref TDateEdit tde_Ed_AddUpADate)
        {
            //--- DEL 2008/07/04 ---------->>>>>
            //cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 1, ref tde_St_AddUpADate, ref tde_Ed_AddUpADate, false, false);
            //--- DEL 2008/07/04 ----------<<<<<
            //--- ADD 2008/07/04 ---------->>>>>
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 3, ref tde_St_AddUpADate, ref tde_Ed_AddUpADate, false, false);
            //--- ADD 2008/07/04 ----------<<<<<
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        // 2008.02.26 add end ---------------------------------------<<

        // --- ADD 2008/09/19 -------------------------------->>>>>
        /// <summary>
        /// 日付チェック処理呼び出し(範囲チェックなし、未入力OK)
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_AddUpADate"></param>
        /// <param name="tde_Ed_AddUpADate"></param>
        /// <returns></returns>
        private bool CallCheckDateRangeAllowNoInput(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_AddUpADate, ref TDateEdit tde_Ed_AddUpADate)
        {
            DateGetAcs.CheckDateResult checkDateResult;         //ADD 2009/01/22 不具合対応[10000]
            // DEL 2008/10/09 不具合対応[6375] ---------->>>>>
            //cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref tde_St_AddUpADate, ref tde_Ed_AddUpADate, true);

            //return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
            // DEL 2008/10/09 不具合対応[6375] ----------<<<<<

            // ADD 2008/10/09 不具合対応[6375] ---------->>>>>
            cdrResult = DateGetAcs.CheckDateRangeResult.OK;
            if ((tde_St_AddUpADate.GetLongDate() != 0) && (tde_Ed_AddUpADate.GetLongDate() != 0))
            {
                cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref tde_St_AddUpADate, ref tde_Ed_AddUpADate, true);
            }
            else
                /*  ---ADD 2009/01/22 不具合対応[10000] ------------------------------------------------------>>>>>
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
                   ---ADD 2009/01/22 不具合対応[10000] ------------------------------------------------------<<<<< */
                // ---ADD 2009/01/22 不具合対応[10000] ------------------------------------------------------>>>>>
                // 開始日チェック
                if (tde_St_AddUpADate.GetLongDate() != 0)
                {
                    checkDateResult = this._dateGet.CheckDate(ref tde_St_AddUpADate, true);
                    if (checkDateResult == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                    {
                        cdrResult = DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid;
                        return false;
                    }
                }
                // 終了日チェック
                else if (tde_Ed_AddUpADate.GetLongDate() != 0)
                {
                    checkDateResult = this._dateGet.CheckDate(ref tde_Ed_AddUpADate, true);
                    if (checkDateResult == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                    {
                        cdrResult = DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid;
                        return false;
                    }
                }
                // ---ADD 2009/01/22 不具合対応[10000] ------------------------------------------------------<<<<<

            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
            // ADD 2008/10/09 不具合対応[6375] ----------<<<<<
        }
        // --- ADD 2008/09/19 --------------------------------<<<<<
        #endregion

        //--- DEL 2008/07/04 ---------->>>>>
        ///// <summary>
        ///// 選択中出力タイプ取得処理
        ///// </summary>
        ///// <param name="printDiv">出力区分</param>
        ///// <param name="printDivName">出力名称</param>
        ///// <remarks>
        ///// <br>Note       : 選択中の出力タイプ情報の取得を行います。</br>
        ///// <br>Programmer : 97036 amami</br>
        ///// <br>Date       : 2007.03.14</br>
        ///// </remarks>
        //private void GetSelectPrintType(out int printDiv, out string printDivName)
        //{
            //printDiv = (Int32)optPrintType.CheckedItem.DataValue;
            //printDivName = optPrintType.CheckedItem.DisplayText;
        //}
        //--- DEL 2008/07/04 ----------<<<<<

		/// <summary>
		/// エラーメッセージ表示処理
		/// </summary>
		/// <param name="iLevel">エラーレベル</param>
		/// <param name="message">表示メッセージ</param>
		/// <param name="status">ステータス</param>
		/// <remarks>
		/// <br>Note       : エラーメッセージの表示を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.14</br>
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
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.14</br>
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
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		private void MAZAI02050UA_Load(object sender, EventArgs e)
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
            //--- DEL 2008/07/04 ---------->>>>>
            //this.SetIconImage(this.btnMakerGuid_St, Size16_Index.STAR1);
            //this.SetIconImage(this.btnMakerGuid_Ed, Size16_Index.STAR1);
            //this.SetIconImage(this.btnGoodsGuid_St, Size16_Index.STAR1);
            //this.SetIconImage(this.btnGoodsGuid_Ed, Size16_Index.STAR1);
            //--- DEL 2008/07/04 ----------<<<<<
            this.SetIconImage(this.btnInputAgenGuid_St, Size16_Index.STAR1);
			this.SetIconImage(this.btnInputAgenGuid_Ed, Size16_Index.STAR1);
            // 2008.01.22 追加 >>>>>>>>>>>>>>>>>>>>
            this.SetIconImage(this.btnWarehouseCode_St, Size16_Index.STAR1);
            this.SetIconImage(this.btnWarehouseCode_Ed, Size16_Index.STAR1);
            // 2008.01.22 追加 <<<<<<<<<<<<<<<<<<<<

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
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		private void MAZAI02050UA_VisibleChanged(object sender, EventArgs e)
		{
			if (this.Visible == true)
			{
				// 初期フォーカス設定
                //optPrintType.Focus();       // DEL 2008.07.04
                detAdjustDate_St.Focus();     // ADD 2008.07.04
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
        /// <br>Update Note: 2010/11/15 tianjw</br>
        /// <br>            ・ＰＭ．ＮＳ　機能改良Ｑ４</br>
		/// </remarks>
		private void uebMainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
            // ----- UPD 2010/11/15 ----------------------------->>>>>
            //if ((e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup) ||
            //    (e.Group.Key == ct_ExBarGroupNm_ExtractConditionGroup))
            if ((e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup) ||
                (e.Group.Key == ct_ExBarGroupNm_ExtractConditionGroup) ||
                (e.Group.Key == ct_ExBarGroupNm_SortOrderGroup))
            // ----- UPD 2010/11/15 -----------------------------<<<<<
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
        /// <br>Update Note: 2010/11/15 tianjw</br>
        /// <br>            ・ＰＭ．ＮＳ　機能改良Ｑ４</br>
		/// </remarks>
		private void uebMainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
            // ----- UPD 2010/11/15 ----------------------------->>>>>
            //if ((e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup) ||
            //    (e.Group.Key == ct_ExBarGroupNm_ExtractConditionGroup))
            if ((e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup) ||
                (e.Group.Key == ct_ExBarGroupNm_ExtractConditionGroup) ||
                (e.Group.Key == ct_ExBarGroupNm_SortOrderGroup))
            // ----- UPD 2010/11/15 -----------------------------<<<<<
			{
				// グループの縮小をキャンセル
				e.Cancel = true;
			}
		}

		/// <summary>
		/// 開始 数値型エディットLeave イベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント情報</param>
		/// <remarks>
		/// <br>Note       : フォーカスが抜ける時に発生します。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		private void nedStockAdjustSlipNo_St_Leave(object sender, EventArgs e)
		{
			// 空白の場合は初期値をセット
            // 2008.01.22 修正 >>>>>>>>>>>>>>>>>>>>
            //if (((TNedit)sender).DataText == string.Empty) ((TNedit)sender).SetInt(0);
            if ((((TNedit)sender).DataText == string.Empty) || (((TNedit)sender).GetInt() == 0)) ((TNedit)sender).Clear();
            // 2008.01.22 修正 <<<<<<<<<<<<<<<<<<<<
        }

		/// <summary>
		/// 終了 在庫調整伝票番号Leave イベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント情報</param>
		/// <remarks>
		/// <br>Note       : フォーカスが抜ける時に発生します。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		private void nedStockAdjustSlipNo_Ed_Leave(object sender, EventArgs e)
		{
			// 空白またはゼロの場合は初期値をセット
            // 2008.01.22 修正 >>>>>>>>>>>>>>>>>>>>
            //if ((((TNedit)sender).DataText == string.Empty) || (((TNedit)sender).GetInt() == 0)) ((TNedit)sender).SetInt(999999999);
            if ((((TNedit)sender).DataText == string.Empty) || (((TNedit)sender).GetInt() == 0)) ((TNedit)sender).Clear();
            // 2008.01.22 修正 <<<<<<<<<<<<<<<<<<<<
        }

		/// <summary>
		/// 終了 メーカーコードLeave イベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント情報</param>
		/// <remarks>
		/// <br>Note       : フォーカスが抜ける時に発生します。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		private void nedMakerCode_Ed_Leave(object sender, EventArgs e)
		{
			// 空白またはゼロの場合は初期値をセット
            // 2007.10.04 修正 >>>>>>>>>>>>>>>>>>>>
            //if ((((TNedit)sender).DataText == string.Empty) || (((TNedit)sender).GetInt() == 0)) ((TNedit)sender).SetInt(999);
            // 2008.01.22 修正 >>>>>>>>>>>>>>>>>>>>
            //if ((((TNedit)sender).DataText == string.Empty) || (((TNedit)sender).GetInt() == 0)) ((TNedit)sender).SetInt(999999);
            if ((((TNedit)sender).DataText == string.Empty) || (((TNedit)sender).GetInt() == 0)) ((TNedit)sender).Clear();
            // 2008.01.22 修正 <<<<<<<<<<<<<<<<<<<<
            // 2007.10.04 修正 <<<<<<<<<<<<<<<<<<<<
        }

        //--- DEL 2008/07/04 ---------->>>>>
        ///// <summary>
        ///// 開始 メーカーガイドボタン押下 イベント
        ///// </summary>
        ///// <param name="sender">イベントオブジェクト</param>
        ///// <param name="e">イベント情報</param>
        ///// <remarks>
        ///// <br>Note       : ガイドボタンが押下された時に発生します。</br>
        ///// <br>Programer  : 97036 amami</br>
        ///// <br>Date       : 2007.03.14</br>
        ///// </remarks>
        //private void btnMakerGuid_St_Click(object sender, EventArgs e)
        //{
        //    if (this._makerAcs == null) this._makerAcs = new MakerAcs();

        //    // 2007.10.04 修正 >>>>>>>>>>>>>>>>>>>>
        //    //Maker maker;
        //    //if (this._makerAcs.ExecuteGuid(this._enterpriseCode, out maker) == 0)
        //    //{
        //    //    nedMakerCode_St.SetInt(maker.MakerCode);
        //    //}
        //    MakerUMnt makerUMnt;
        //    if (this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt) == 0)
        //    {
        //        nedMakerCode_St.SetInt(makerUMnt.GoodsMakerCd);
        //    }
        //    // 2007.10.04 修正 <<<<<<<<<<<<<<<<<<<<
        //}
        //--- DEL 2008/07/04 ----------<<<<<

        //--- DEL 2008/07/04 ---------->>>>>
        ///// <summary>
        ///// 終了 メーカーガイドボタン押下 イベント
        ///// </summary>
        ///// <param name="sender">イベントオブジェクト</param>
        ///// <param name="e">イベント情報</param>
        ///// <remarks>
        ///// <br>Note       : ガイドボタンが押下された時に発生します。</br>
        ///// <br>Programer  : 97036 amami</br>
        ///// <br>Date       : 2007.03.14</br>
        ///// </remarks>
        //private void btnMakerGuid_Ed_Click(object sender, EventArgs e)
        //{
        //    if (this._makerAcs == null) this._makerAcs = new MakerAcs();

        //    // 2007.10.04 修正 >>>>>>>>>>>>>>>>>>>>
        //    //Maker maker;
        //    //if (this._makerAcs.ExecuteGuid(this._enterpriseCode, out maker) == 0)
        //    //{
        //    //    nedMakerCode_Ed.SetInt(maker.MakerCode);
        //    //}
        //    MakerUMnt makerUMnt;
        //    if (this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt) == 0)
        //    {
        //        nedMakerCode_Ed.SetInt(makerUMnt.GoodsMakerCd);
        //    }
        //    // 2007.10.04 修正 <<<<<<<<<<<<<<<<<<<<
        //}
        //--- DEL 2008/07/04 ----------<<<<<

        //--- DEL 2008/07/04 ---------->>>>>
        ///// <summary>
        ///// 開始 商品ガイドボタン押下 イベント
        ///// </summary>
        ///// <param name="sender">イベントオブジェクト</param>
        ///// <param name="e">イベント情報</param>
        ///// <remarks>
        ///// <br>Note       : ガイドボタンが押下された時に発生します。</br>
        ///// <br>Programer  : 97036 amami</br>
        ///// <br>Date       : 2007.03.14</br>
        ///// </remarks>
        //private void btnGoodsGuid_St_Click(object sender, EventArgs e)
        //{
        //    if (this._MAKHN04110UA == null) this._MAKHN04110UA = new MAKHN04110UA();

        //    GoodsUnitData goodsUnitData;
        //    if (this._MAKHN04110UA.ShowGuide(this, this._enterpriseCode, out goodsUnitData) == DialogResult.OK)
        //    {
        //        // 2007.10.04 修正 >>>>>>>>>>>>>>>>>>>>
        //        //edtGoodsCode_St.DataText = goodsUnitData.GoodsCode;
        //        edtGoodsCode_St.DataText = goodsUnitData.GoodsNo;
        //        // 2007.10.04 修正 <<<<<<<<<<<<<<<<<<<<
        //    }
        //}
        //--- DEL 2008/07/04 ----------<<<<<

        //--- DEL 2008/07/04 ---------->>>>>
        ///// <summary>
        ///// 終了 商品ガイドボタン押下 イベント
        ///// </summary>
        ///// <param name="sender">イベントオブジェクト</param>
        ///// <param name="e">イベント情報</param>
        ///// <remarks>
        ///// <br>Note       : ガイドボタンが押下された時に発生します。</br>
        ///// <br>Programer  : 97036 amami</br>
        ///// <br>Date       : 2007.03.14</br>
        ///// </remarks>
        //private void btnGoodsGuid_Ed_Click(object sender, EventArgs e)
        //{
        //    if (this._MAKHN04110UA == null) this._MAKHN04110UA = new MAKHN04110UA();

        //    GoodsUnitData goodsUnitData;
        //    if (this._MAKHN04110UA.ShowGuide(this, this._enterpriseCode, out goodsUnitData) == DialogResult.OK)
        //    {
        //        // 2007.10.04 修正 >>>>>>>>>>>>>>>>>>>>
        //        //edtGoodsCode_Ed.DataText = goodsUnitData.GoodsCode;
        //        edtGoodsCode_Ed.DataText = goodsUnitData.GoodsNo;
        //        // 2007.10.04 修正 <<<<<<<<<<<<<<<<<<<<
        //    }
        //}
        //--- DEL 2008/07/04 ----------<<<<<

        // ----- DEL 2011/11/15 xupz---------->>>>>
        ///// <summary>
        ///// 開始 入力担当者ガイドボタン押下 イベント 
        ///// </summary>
        ///// <param name="sender">イベントオブジェクト</param>
        ///// <param name="e">イベント情報</param>
        ///// <remarks>
        ///// <br>Note       : ガイドボタンが押下された時に発生します。</br>
        ///// <br>Programer  : 97036 amami</br>
        ///// <br>Date       : 2007.03.14</br>
        ///// </remarks>
        //private void btnInputAgenGuid_St_Click(object sender, EventArgs e)
        //{
        //    if (this._employeeAcs == null) this._employeeAcs = new EmployeeAcs();

        //    Employee employee;
        //    if (this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee) == 0)
        //    {
        //        tEdit_EmployeeCode_St.DataText = employee.EmployeeCode.TrimEnd();
        //        tEdit_EmployeeCode_Ed.Focus();          //ADD 2009/01/22 不具合対応[10002]
        //    }
        //}

        ///// <summary>
        ///// 終了 入力担当者ガイドボタン押下 イベント
        ///// </summary>
        ///// <param name="sender">イベントオブジェクト</param>
        ///// <param name="e">イベント情報</param>
        ///// <remarks>
        ///// <br>Note       : ガイドボタンが押下された時に発生します。</br>
        ///// <br>Programer  : 97036 amami</br>
        ///// <br>Date       : 2007.03.14</br>
        ///// </remarks>
        //private void btnInputAgenGuid_Ed_Click(object sender, EventArgs e)
        //{
        //    if (this._employeeAcs == null) this._employeeAcs = new EmployeeAcs();

        //    Employee employee;
        //    if (this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee) == 0)
        //    {
        //        tEdit_EmployeeCode_Ed.DataText = employee.EmployeeCode.TrimEnd();
        //        tComboEditor2.Focus();                  //ADD 2009/01/22 不具合対応[10002]
        //    }
        //}
        // ----- DEL 2011/11/15 xupz----------<<<<<
        // ----- ADD 2011/11/15 xupz---------->>>>>
        /// <summary>
        /// 開始 仕入担当者ガイドボタン押下 イベント 
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note       : ガイドボタンが押下された時に発生します。</br>
        /// </remarks>
        private void btnStockAgenGuid_St_Click(object sender, EventArgs e)
        {
            if (this._employeeAcs == null) this._employeeAcs = new EmployeeAcs();

            Employee employee;
            if (this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee) == 0)
            {
                tEdit_EmployeeCode_St.DataText = employee.EmployeeCode.TrimEnd();
                tEdit_EmployeeCode_Ed.Focus();        
            }
        }

        /// <summary>
        /// 終了 仕入担当者ガイドボタン押下 イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note       : ガイドボタンが押下された時に発生します。</br>
        /// </remarks>
        private void btnStockAgenGuid_Ed_Click(object sender, EventArgs e)
        {
            if (this._employeeAcs == null) this._employeeAcs = new EmployeeAcs();

            Employee employee;
            if (this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee) == 0)
            {
                tEdit_EmployeeCode_Ed.DataText = employee.EmployeeCode.TrimEnd();
                tComboEditor2.Focus();                  
            }
        }
        // ----- ADD 2011/11/15 xupz----------<<<<<

        // 2008.01.22 追加 >>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 倉庫ガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 倉庫ガイドボタンが押下された時に発生します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2008.01.22</br>
        /// </remarks>    
        private void btnWarehouseCode_Click(object sender, EventArgs e)
        {
            Warehouse warehouseData = null;
            if (this._warehouseGuideAcs == null) this._warehouseGuideAcs = new WarehouseAcs();

            //倉庫ガイド起動
            int status = this._warehouseGuideAcs.ExecuteGuid(out warehouseData, this._enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);

            if (status == 0)
            {
                if (warehouseData != null)
                {
                    //開始、終了どちらのボタンが押されたか？
                    if ((Infragistics.Win.Misc.UltraButton)sender == this.btnWarehouseCode_St)
                    {
                        //開始
                        this.tEdit_WarehouseCode_St.DataText = warehouseData.WarehouseCode.TrimEnd();
                        this.tEdit_WarehouseCode_Ed.Focus();        //ADD 2009/01/22 不具合対応[10002]
                    }
                    else
                    {
                        //終了
                        this.tEdit_WarehouseCode_Ed.DataText = warehouseData.WarehouseCode.TrimEnd();
                        this.tEdit_EmployeeCode_St.Focus();         //ADD 2009/01/22 不具合対応[10002]
                    }
                }
            }
            else
            {
                //キャンセルなのでなにもしない
            }

        }
        // 2008.01.22 追加 <<<<<<<<<<<<<<<<<<<<

        //--- ADD 2008/07/08 ---------->>>>>
        /// <summary>
        /// edtWarehouseCode_St_Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 開始倉庫コードからフォーカスが離れた時に発生するイベントです。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.07.08</br>
        /// </remarks>
        private void edtWarehouseCode_St_Leave(object sender, EventArgs e)
        {
            /* --- DEL 2008/10/07 不要 ------------------------------------------------>>>>>
            //if (this.tEdit_WarehouseCode_St.Text == ct_WarehouseCode_Min)
            //{
            //    this.tEdit_WarehouseCode_St.Text = "";
            //}
               --- DEL 2008/10/07 -----------------------------------------------------<<<<< */
        }

        /// <summary>
        /// edtWarehouseCode_Ed_Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 終了倉庫コードからフォーカスが離れた時に発生するイベントです。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.07.08</br>
        /// </remarks>
        private void edtWarehouseCode_Ed_Leave(object sender, EventArgs e)
        {
            /* --- DEL 2008/10/07 不要 ------------------------------------------------>>>>>
            //if (this.tEdit_WarehouseCode_Ed.Text == ct_WarehouseCode_Max)
            //{
            //    this.tEdit_WarehouseCode_Ed.Text = "";
            //}
               --- DEL 2008/10/07 -----------------------------------------------------<<<<< */
        }

        /// <summary>
        /// edtInputAgenCd_St_Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 開始入力担当者コードからフォーカスが離れた時に発生するイベントです。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.07.08</br>
        /// </remarks>
        private void edtInputAgenCd_St_Leave(object sender, EventArgs e)
        {
            /* --- DEL 2008/10/07 不要 ------------------------------------------------>>>>>
            //if (this.tEdit_EmployeeCode_St.Text == ct_InputAgenCd_Min)
            //{
            //    this.tEdit_EmployeeCode_St.Text = "";
            //}
               --- DEL 2008/10/07 -----------------------------------------------------<<<<< */
        }

        /// <summary>
        /// edtInputAgenCd_Ed_Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 終了入力担当者コードからフォーカスが離れた時に発生するイベントです。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.07.08</br>
        /// </remarks>
        private void edtInputAgenCd_Ed_Leave(object sender, EventArgs e)
        {
            /* --- DEL 2008/10/07 不要 ------------------------------------------------>>>>>
            //if (this.tEdit_EmployeeCode_Ed.Text == ct_InputAgenCd_Max)
            //{
            //    this.tEdit_EmployeeCode_Ed.Text = "";
            //}
               --- DEL 2008/10/07 -----------------------------------------------------<<<<< */
        }
        //--- ADD 2008/07/08 ----------<<<<<

        // --- ADD 2008/09/22 -------------------------------->>>>>
        /// <summary>
        /// tRetKeyControl1_ChangeFocusイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : リターンキー押下時に発生するイベントです。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.09.22</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            switch (e.PrevCtrl.Name)
            {
                case "tEdit_WarehouseCode_St":
                    {
                        if (this.tEdit_WarehouseCode_St.DataText != "")
                        {
                            e.NextCtrl = tEdit_WarehouseCode_Ed;
                        }
                        break;
                    }
                case "tEdit_WarehouseCode_Ed":
                    {
                        if (this.tEdit_WarehouseCode_Ed.DataText != "")
                        {
                            e.NextCtrl = tEdit_EmployeeCode_St;
                        }
                        break;
                    }
                case "tEdit_EmployeeCode_St":
                    {
                        if (this.tEdit_EmployeeCode_St.DataText != "")
                        {
                            e.NextCtrl = tEdit_EmployeeCode_Ed;
                        }
                        break;
                    }
                case "tEdit_EmployeeCode_Ed":
                    {
                        if (this.tEdit_EmployeeCode_Ed.DataText != "")
                        {
                            e.NextCtrl = tComboEditor2;
                        }
                        break;
                    }
            }
        }
        // --- ADD 2008/09/22 -------------------------------->>>>>

        // ---------- ADD 2010/11/15 ---------->>>>>
        /// <summary>
        /// 発行タイプが「棚卸調整分」の場合のみ、出力順を入力可能に変更する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 発行タイプが「棚卸調整分」の場合のみ、出力順を入力可能に変更する。</br>
        /// <br>Programmer : tianjw</br>
        /// <br>Date       : 2010/11/15</br>
        /// <br>Update Note: 2010/11/25 tianjw</br>
        /// <br>            ・障害報告 #17555</br>
        /// </remarks>
        private void tComboEditor2_ValueChanged(object sender, EventArgs e)
        {
            // ----- ADD 2010/11/25 ----------->>>>>
            this._pretComboEditor1Index = this.tComboEditor1.SelectedIndex;
            this._pretComboEditor3Index = this.tComboEditor3.SelectedIndex;
            // ----- ADD 2010/11/25 -----------<<<<<
            this.tComboEditor3.ValueChanged -= new System.EventHandler(this.tComboEditor3_ValueChanged);
            // 棚卸調整分以外の場合
            if (this.tComboEditor2.SelectedIndex != 1)
            {
                // ----- ADD 2010/11/25 ----------->>>>>
                if (this._pretComboEditor2Index == 1)
                {
                    // 改頁アイテム追加
                    tComboEditor1.Items.Clear();
                    tComboEditor1.Items.Add(0, ct_Section);
                    tComboEditor1.Items.Add(1, ct_Warehouse);
                    tComboEditor1.Items.Add(2, ct_Nothing);
                    if (this._pretComboEditor3Index == 1)
                    {
                        tComboEditor1.SelectedIndex = this._pretComboEditor1Index + 1;
                    }
                    else
                    {
                        tComboEditor1.SelectedIndex = this._pretComboEditor1Index;
                    }
                }
                // ----- ADD 2010/11/25 -----------<<<<<
                this.tComboEditor3.Items.Clear();
                this.tComboEditor3.Items.Add(0, ct_AdjustDateSort);
                this.tComboEditor3.SelectedIndex = 0;
            }
            // 棚卸調整分の場合
            else
            {
                this.tComboEditor3.Items.Clear();
                this.tComboEditor3.Items.Add(0, ct_AdjustDateSort);
                this.tComboEditor3.Items.Add(1, ct_WarehouseShelfNoSort);
                this.tComboEditor3.SelectedIndex = 0;
            }
            this.tComboEditor3.ValueChanged += new System.EventHandler(this.tComboEditor3_ValueChanged);
            this._pretComboEditor2Index = this.tComboEditor2.SelectedIndex; // ADD 2010/11/25
        }

        /// <summary>
        /// 出力順が「棚番順」場合、改頁は「倉庫」と「しない」だけ表示へ変更します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : tianjw</br>
        /// <br>Date       : 2010/11/15</br>
        /// </remarks>
        private void tComboEditor3_ValueChanged(object sender, EventArgs e)
        {
            int ComboEditor1Index = tComboEditor1.SelectedIndex;
            // 棚番順の場合
            if (this.tComboEditor3.SelectedIndex == 1)
            {
                // 改頁アイテム追加
                tComboEditor1.Items.Clear();
                tComboEditor1.Items.Add(0, ct_Warehouse);
                tComboEditor1.Items.Add(1, ct_Nothing);
                if (ComboEditor1Index == 0)
                {
                    tComboEditor1.SelectedIndex = 0;
                } 
                else 
                {
                    tComboEditor1.SelectedIndex = ComboEditor1Index - 1;
                }
            }
            // 仕入日順の場合
            else
            {
                // 改頁アイテム追加
                tComboEditor1.Items.Clear();
                tComboEditor1.Items.Add(0, ct_Section);
                tComboEditor1.Items.Add(1, ct_Warehouse);
                tComboEditor1.Items.Add(2, ct_Nothing);
                tComboEditor1.SelectedIndex = ComboEditor1Index + 1;
            }
        }
        // ---------- ADD 2010/11/15 ---------->>>>>
        # endregion
    }
}