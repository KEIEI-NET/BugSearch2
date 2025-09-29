//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン目標設定マスタ（印刷）
// プログラム概要   : キャンペーン目標設定マスタで設定した内容を一覧出力し
//                    確認する
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 楊明俊
// 作 成 日  2011/04/25  修正内容 : 新規作成
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
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Globarization;

using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// キャンペーン目標設定マスタ（印刷）UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン目標設定マスタ（印刷）UIフォームクラス</br>
    /// <br>Programmer : 楊明俊</br>
    /// <br>Date       : 2011/04/25</br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public partial class PMKHN08710UA : Form,
                                        IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                        IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ Private Member

        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 企業コード
        private string _enterpriseCode = "";
        private Employee _loginWorker = null;
        // 自拠点コード
        private string _ownSectionCode = "";

        //拠点ガイド用
        private SecInfoSetAcs _secInfoSetAcs;

        //キャンペーンガイド用
        private CampaignLinkAcs _campaignLinkAcs;

        // 担当者ガイド用
        private EmployeeAcs _employeeAcs;

        // ユーザーガイド用
        private UserGuideAcs _userGuideAcs;

        // グループコードガイド
        private BLGroupUAcs _blGroupUAcs;

        // BLコードガイド
        private BLGoodsCdAcs _blGoodsCdAcs;
        
        // 得意先ガイド結果OKフラグ
        private bool _customerGuideOK;
        private UltraButton _customerGuideSender;

        // 抽出条件クラス
        private CampaignTargetPrintWork _campaignTargetPrintWork;

        private CampaignTargetSetAcs _campaignTargetSetAcs;

        // 期首月
        private DateTime _startMonth;

        #region ◆ Interface member
        //--IPrintConditionInpTypeのプロパティ用変数 ----------------------------------
        // 抽出ボタン状態取得プロパティ
        private bool _canExtract = false;
        // PDF出力ボタン状態取得プロパティ    
        private bool _canPdf = true;
        // 印刷ボタン状態取得プロパティ
        private bool _canPrint = true;
        // 抽出ボタン表示有無プロパティ
        private bool _visibledExtractButton = false;
        // PDF出力ボタン表示有無プロパティ	
        private bool _visibledPdfButton = true;
        // 印刷ボタン表示有無プロパティ
        private bool _visibledPrintButton = true;
        #endregion ◆ Interface member

        #endregion

        #region ■ Private Const
        private const string PRINTSET_TABLE = "CAMPAIGNTARGET";

        // dataview名称用
        private const string CAMPAIGNCODE = "campaigncode";
        private const string CAMPAIGNNAME = "campaignname";
        private const string SECTIONCODE = "sectioncode";
        private const string SECTIONGUIDESNM = "sectionguidesnm";
        private const string CUSTOMERCODE = "customercode";
        private const string CUSTOMERSNM = "customersnm";
        private const string SALESEMPLOYEECD = "salesemployeecd";
        private const string SALESEMPLOYEENM = "salesemployeenm";
        private const string FRONTEMPLOYEECD = "frontemployeecd";
        private const string FRONTEMPLOYEENM = "frontemployeenm";
        private const string SALESINPUTCODE = "salesinputcode";
        private const string SALESINPUTNAME = "salesinputname";
        private const string SALESAREACODE = "salesareacode";
        private const string SALESAREACODENAME = "salesareacodename";
        private const string BLGROUPCODE = "blgroupcode";
        private const string BLGROUPCODENAME = "blgroupcodename";
        private const string BLGOODSCODE = "blgoodscode";
        private const string BLGOODSCODENAME = "blgoodscodename";
        private const string SALESCODE = "salescode";
        private const string SALESCODENAME = "salescodename";

        private const string MONTHLYSALESTARGET = "monthlysalestarget";
        private const string TERMSALESTARGET = "termsalestarget";
        private const string SALESTARGETMONEY1 = "salestargetmoney1";
        private const string SALESTARGETMONEY2 = "salestargetmoney2";
        private const string SALESTARGETMONEY3 = "salestargetmoney3";
        private const string SALESTARGETMONEY4 = "salestargetmoney4";
        private const string SALESTARGETMONEY5 = "salestargetmoney5";
        private const string SALESTARGETMONEY6 = "salestargetmoney6";
        private const string SALESTARGETMONEY7 = "salestargetmoney7";
        private const string SALESTARGETMONEY8 = "salestargetmoney8";
        private const string SALESTARGETMONEY9 = "salestargetmoney9";
        private const string SALESTARGETMONEY10 = "salestargetmoney10";
        private const string SALESTARGETMONEY11 = "salestargetmoney11";
        private const string SALESTARGETMONEY12 = "salestargetmoney12";
        private const string SALESTARGETMONEYALL = "salestargetmoneyall";

        private const string MONTHLYSALESTARGETPROFIT = "monthlysalestargetprofit";
        private const string TERMSALESTARGETPROFIT = "termsalestargetprofit";
        private const string SALESTARGETPROFIT1 = "salestargetprofit1";
        private const string SALESTARGETPROFIT2 = "salestargetprofit2";
        private const string SALESTARGETPROFIT3 = "salestargetprofit3";
        private const string SALESTARGETPROFIT4 = "salestargetprofit4";
        private const string SALESTARGETPROFIT5 = "salestargetprofit5";
        private const string SALESTARGETPROFIT6 = "salestargetprofit6";
        private const string SALESTARGETPROFIT7 = "salestargetprofit7";
        private const string SALESTARGETPROFIT8 = "salestargetprofit8";
        private const string SALESTARGETPROFIT9 = "salestargetprofit9";
        private const string SALESTARGETPROFIT10 = "salestargetprofit10";
        private const string SALESTARGETPROFIT11 = "salestargetprofit11";
        private const string SALESTARGETPROFIT12 = "salestargetprofit12";
        private const string SALESTARGETPROFITALL = "salestargetprofitall";

        private const string APPLYDATEALL = "applydate";

        private const string MONTHLYSALESTARGETCOUNT = "monthlysalestargetcount";
        private const string TERMSALESTARGETCOUNT = "termsalestargetcount";
        private const string SALESTARGETCOUNT1 = "salestargetcount1";
        private const string SALESTARGETCOUNT2 = "salestargetcount2";
        private const string SALESTARGETCOUNT3 = "salestargetcount3";
        private const string SALESTARGETCOUNT4 = "salestargetcount4";
        private const string SALESTARGETCOUNT5 = "salestargetcount5";
        private const string SALESTARGETCOUNT6 = "salestargetcount6";
        private const string SALESTARGETCOUNT7 = "salestargetcount7";
        private const string SALESTARGETCOUNT8 = "salestargetcount8";
        private const string SALESTARGETCOUNT9 = "salestargetcount9";
        private const string SALESTARGETCOUNT10 = "salestargetcount10";
        private const string SALESTARGETCOUNT11 = "salestargetcount11";
        private const string SALESTARGETCOUNT12 = "salestargetcount12";
        private const string SALESTARGETCOUNTALL = "salestargetcountall";

        private const string CAMPAIGNCODE_TITLE = "ｷｬﾝﾍﾟｰﾝ";
        private const string CAMPAIGNNAME_TITLE = "ｷｬﾝﾍﾟｰﾝ名";
        private const string SECTIONCODE_TITLE = "拠点";
        private const string SECTIONGUIDESNM_TITLE = "拠点名";
        private const string CUSTOMERCODE_TITLE = "得意先";
        private const string CUSTOMERSNM_TITLE = "得意先名";
        private const string SALESEMPLOYEECD_TITLE = "担当者";
        private const string SALESEMPLOYEENM_TITLE = "担当者名";
        private const string FRONTEMPLOYEECD_TITLE = "受注者";
        private const string FRONTEMPLOYEENM_TITLE = "受注者名";
        private const string SALESINPUTCODE_TITLE = "発行者";
        private const string SALESINPUTNAME_TITLE = "発行者名";
        private const string SALESAREACODE_TITLE = "地区";
        private const string SALESAREACODENAME_TITLE = "地区名";
        private const string BLGROUPCODE_TITLE = "ｸﾞﾙｰﾌﾟｺｰﾄﾞ";
        private const string BLGROUPCODENAME_TITLE = "ｸﾞﾙｰﾌﾟｺｰﾄﾞ名";
        private const string BLGOODSCODE_TITLE = "BLｺｰﾄﾞ";
        private const string BLGOODSCODENAME_TITLE = "BLｺｰﾄﾞ名";
        private const string SALESCODE_TITLE = "販売区分";
        private const string SALESCODENAME_TITLE = "販売区分名";

        private const string MONTHLYSALESTARGET_TITLE = "月間";
        private const string TERMSALESTARGET_TITLE = "期間";
        private const string SALESTARGETMONEY1_TITLE = "売上１";
        private const string SALESTARGETMONEY2_TITLE = "売上２";
        private const string SALESTARGETMONEY3_TITLE = "売上３";
        private const string SALESTARGETMONEY4_TITLE = "売上４";
        private const string SALESTARGETMONEY5_TITLE = "売上５";
        private const string SALESTARGETMONEY6_TITLE = "売上６";
        private const string SALESTARGETMONEY7_TITLE = "売上７";
        private const string SALESTARGETMONEY8_TITLE = "売上８";
        private const string SALESTARGETMONEY9_TITLE = "売上９";
        private const string SALESTARGETMONEY10_TITLE = "売上１０";
        private const string SALESTARGETMONEY11_TITLE = "売上１１";
        private const string SALESTARGETMONEY12_TITLE = "売上１２";
        private const string SALESTARGETMONEYALL_TITLE = "売上合計";

        private const string SALESTARGETPROFIT1_TITLE = "粗利１";
        private const string SALESTARGETPROFIT2_TITLE = "粗利２";
        private const string SALESTARGETPROFIT3_TITLE = "粗利３";
        private const string SALESTARGETPROFIT4_TITLE = "粗利４";
        private const string SALESTARGETPROFIT5_TITLE = "粗利５";
        private const string SALESTARGETPROFIT6_TITLE = "粗利６";
        private const string SALESTARGETPROFIT7_TITLE = "粗利７";
        private const string SALESTARGETPROFIT8_TITLE = "粗利８";
        private const string SALESTARGETPROFIT9_TITLE = "粗利９";
        private const string SALESTARGETPROFIT10_TITLE = "粗利１０";
        private const string SALESTARGETPROFIT11_TITLE = "粗利１１";
        private const string SALESTARGETPROFIT12_TITLE = "粗利１２";
        private const string SALESTARGETPROFITALL_TITLE = "粗利合計";

        private const string SALESTARGETCOUNT1_TITLE = "数量1";
        private const string SALESTARGETCOUNT2_TITLE = "数量2";
        private const string SALESTARGETCOUNT3_TITLE = "数量3";
        private const string SALESTARGETCOUNT4_TITLE = "数量4";
        private const string SALESTARGETCOUNT5_TITLE = "数量5";
        private const string SALESTARGETCOUNT6_TITLE = "数量6";
        private const string SALESTARGETCOUNT7_TITLE = "数量7";
        private const string SALESTARGETCOUNT8_TITLE = "数量8";
        private const string SALESTARGETCOUNT9_TITLE = "数量9";
        private const string SALESTARGETCOUNT10_TITLE = "数量10";
        private const string SALESTARGETCOUNT11_TITLE = "数量11";
        private const string SALESTARGETCOUNT12_TITLE = "数量12";
        private const string SALESTARGETCOUNTALL_TITLE = "数量合計";

        // プログラムID
        private const string ct_PGID = "PMKHN08710U";

        private const string ct_ClassID = "PMKHN08710UA";
        // 帳票名称
        private string _printName = "キャンペーン目標設定マスタ（印刷）";
        // 帳票キー	
        private string _printKey = "aa37c077-6bcb-4700-9938-a23a1f7545c2";

        // ExporerBar グループ名称
        private const string ct_ExBarGroupNm_ReportSelectGroup = "ReportSelectGroup";		// 出力条件
        private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";	// 抽出条件

        #endregion
        /// <summary>
        /// キャンペーン目標設定マスタ（印刷）UIフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : キャンペーン目標設定マスタ（印刷）UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br></br>
        /// </remarks>
        public PMKHN08710UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginWorker = LoginInfoAcquisition.Employee.Clone();
            this._ownSectionCode = this._loginWorker.BelongSectionCode;

            this._campaignTargetSetAcs = new CampaignTargetSetAcs();

            this._campaignLinkAcs = new CampaignLinkAcs();

            this._secInfoSetAcs = new SecInfoSetAcs();

            // 自社情報マスタ.期首月を取得する。
            DateGetAcs _dateGetAcs;
            _dateGetAcs = DateGetAcs.GetInstance();
            List<DateTime> startMonth;
            List<DateTime> endMonth;
            List<DateTime> yearMonth;
            int year;                                  // 会計年度
            try
            {
                _dateGetAcs.GetFinancialYearTable(0,
                                                       out startMonth,
                                                       out endMonth,
                                                       out yearMonth,
                                                       out year);
                _startMonth = yearMonth[0];
            }
            catch
            {
                startMonth = new List<DateTime>();
                endMonth = new List<DateTime>();
                yearMonth = new List<DateTime>();
                year = 0;
            }

            // データセット列情報構築処理
            DataSetColumnConstruction();
        }

        #region ■ IPrintConditionInpType メンバ
        #region ◆ Public Event
        /// <summary> 親ツールバー設定イベント </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion ◆ Public Event

        #region ◆ Public Property
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

        #endregion ◆ Public Property

        #region ◆ Public Method
        #region ◎ 抽出処理
        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>0( 固定 )</returns>
        /// <remarks>
        /// <br>Note       : 抽出処理を行う</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int Extract(ref object parameter)
        {
            int status = 0;
            ArrayList PrintSets = null;

            // 画面→抽出条件クラス
            status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Clear();

            if ((int)this.tComboEditor_LogicalDeleteCode.Value == 0)
            {
                status = this._campaignTargetSetAcs.Search(
                    out PrintSets,
                    this._enterpriseCode,
                    this._campaignTargetPrintWork);
            }
            else
            {
                status = this._campaignTargetSetAcs.SearchDelete(
                    out PrintSets,
                    this._enterpriseCode,
                    this._campaignTargetPrintWork);
            }

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        
                        // 商品クラスをデータセットへ展開する
                        int index = 0;
                        foreach (CampaignTargetSet campaignTargetSet in PrintSets)
                        {

                            SecPrintSetToDataSet(campaignTargetSet.Clone(), index);
                            ++index;
                        }
                        break;
                    }
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    {
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "PMKHN08630U", 						// アセンブリＩＤまたはクラスＩＤ
                            "キャンペーン目標設定マスタ（印刷）", 			// プログラム名称
                            "Extract", 							// 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._campaignTargetSetAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        break;
                    }
            }
            return 0;
        }
        #endregion

        #region ◎ 印刷処理
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 印刷処理を行う。</br>
        /// <br>Programmer	: 楊明俊</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            SFCMN06001U printDialog = new SFCMN06001U();		// 帳票選択ガイド
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// 印刷情報パラメータ

            // 企業コードをセット
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// 起動PGID

            // PDF出力履歴用
            printInfo.key = this._printKey;
            printInfo.prpnm = this._printName;

            // 画面→抽出条件クラス
            int status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            // 抽出条件の設定
            printInfo.jyoken = this._campaignTargetPrintWork;
            printDialog.PrintInfo = printInfo;

            // 帳票選択ガイド
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0);
            }

            parameter = printInfo;

            return printInfo.status;
        }
        #endregion

        #region ◎ 入力チェック処理
        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 楊明俊</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            const string ct_RangeError = "の範囲指定に誤りがあります";
            DateGetAcs _dateGetAcs;
            _dateGetAcs = DateGetAcs.GetInstance();

            int inputValueSt = 0;
            int inputValueEd = 0;
            int.TryParse(this.tEdit_CampaingCode_St.DataText.TrimEnd(), out inputValueSt);
            int.TryParse(this.tEdit_CampaingCode_Ed.DataText.TrimEnd(), out inputValueEd);
            // キャンペーンコード
            if (
                (this.tEdit_CampaingCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_CampaingCode_Ed.DataText.TrimEnd() != string.Empty) &&
                inputValueSt > inputValueEd)
            {
                errMessage = string.Format("キャンペーンコード{0}", ct_RangeError);
                errComponent = this.tEdit_CampaingCode_St;
                return (false);
            }

            int.TryParse(this.tEdit_SectionCode_St.DataText.TrimEnd(), out inputValueSt);
            int.TryParse(this.tEdit_SectionCode_Ed.DataText.TrimEnd(), out inputValueEd);
            // 拠点コード
            if (
                (this.tEdit_SectionCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_SectionCode_Ed.DataText.TrimEnd() != string.Empty) &&
                inputValueSt > inputValueEd)
            {
                errMessage = string.Format("拠点{0}", ct_RangeError);
                errComponent = this.tEdit_SectionCode_St;
                return (false);
            }

            int.TryParse(this.tEdit_EmployeeCode_St.DataText.TrimEnd(), out inputValueSt);
            int.TryParse(this.tEdit_EmployeeCode_Ed.DataText.TrimEnd(), out inputValueEd);
            // 担当者コード
            if (
                (this.tEdit_EmployeeCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_EmployeeCode_Ed.DataText.TrimEnd() != string.Empty) &&
                inputValueSt > inputValueEd)
            {
                errMessage = string.Format("担当者{0}", ct_RangeError);
                errComponent = this.tEdit_EmployeeCode_St;
                return (false);
            }

            // ＢＬコード
            if (
                (this.tNedit_BLGoodsCode_St.GetInt() != 0) &&
                (this.tNedit_BLGoodsCode_Ed.GetInt() != 0) &&
                this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt())
            {
                errMessage = string.Format("ＢＬコード{0}", ct_RangeError);
                errComponent = this.tNedit_BLGoodsCode_St;
                status = false;
                return (false);
            }

            // ＢＬグループ
            if (
                (this.tNedit_GroupCode_St.GetInt() != 0) &&
                (this.tNedit_GroupCode_Ed.GetInt() != 0) &&
                this.tNedit_GroupCode_St.GetInt() > this.tNedit_GroupCode_Ed.GetInt())
            {
                errMessage = string.Format("ＢＬグループ{0}", ct_RangeError);
                errComponent = this.tNedit_GroupCode_St;
                status = false;
                return (false);
            }

            // 各種コード
            if (
                (this.tNedit_GuideCode_St.GetInt() != 0) &&
                (this.tNedit_GuideCode_Ed.GetInt() != 0) &&
                this.tNedit_GuideCode_St.GetInt() > this.tNedit_GuideCode_Ed.GetInt())
            {
                switch ((int)this.tComboEditor_PrintType.Value)
                {
                    case 5:
                        errMessage = string.Format("地区{0}", ct_RangeError);
                        break;
                    case 8:
                        errMessage = string.Format("販売区分{0}", ct_RangeError);
                        break;
                }
                errComponent = this.tNedit_GuideCode_St;
                status = false;
                return (false);
            }

            // 得意先
            if (
                (this.tNedit_CustomerCode_St.GetInt() != 0) &&
                (this.tNedit_CustomerCode_Ed.GetInt() != 0) &&
                this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt())
            {
                errMessage = string.Format("得意先{0}", ct_RangeError);
                errComponent = this.tNedit_CustomerCode_St;
                status = false;
                return (false);
            }

            // 削除日付
            if ((int)this.tComboEditor_LogicalDeleteCode.Value == 1)
            {
                if (IsErrorTDateEdit(this.SerchSlipDataStRF_tDateEdit, false, true, out errMessage) == false)
                {
                    errComponent = this.SerchSlipDataStRF_tDateEdit;
                    return (false);
                }

                if (IsErrorTDateEdit(this.SerchSlipDataEdRF_tDateEdit, false, true, out errMessage) == false)
                {
                    errComponent = this.SerchSlipDataEdRF_tDateEdit;
                    return (false);
                }

                // 範囲チェック
                if ((this.SerchSlipDataStRF_tDateEdit.GetDateTime() != DateTime.MinValue) &&
                    (this.SerchSlipDataEdRF_tDateEdit.GetDateTime() != DateTime.MinValue))
                {
                    if (this.SerchSlipDataStRF_tDateEdit.GetDateTime() > this.SerchSlipDataEdRF_tDateEdit.GetDateTime())
                    {
                        errMessage = "削除日付の範囲指定に誤りがあります。";
                        errComponent = SerchSlipDataStRF_tDateEdit;
                        return (false);
                    }
                }
            }
            return status;
        }

        /// <summary>
        /// 日付入力チェック処理
        /// </summary>
        /// <param name="tDateEdit">チェック対象TDateEdit</param>
        /// <param name="minValueCheck">未入力チェックフラグ(True:未入力不可 False:未入力可)</param>
        /// <param name="DayCheck"></param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>true:チェックOK,false:チェックNG</returns>
        /// <remarks>
        /// <br>Note       : 日付の入力チェックを行います。</br>
        /// <br>Programmer	: 楊明俊</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private bool IsErrorTDateEdit(TDateEdit tDateEdit, bool minValueCheck, bool DayCheck, out string errMsg)
        {
            errMsg = "";

            int year = tDateEdit.GetDateYear();
            int month = tDateEdit.GetDateMonth();
            int day = tDateEdit.GetDateDay();

            if (minValueCheck == true)
            {
                if (DayCheck)
                {
                    if ((year == 0) || (month == 0) || (day == 0))
                    {
                        errMsg = "日付を指定してください。";
                        return (false);
                    }
                }
                else
                {
                    if ((year == 0) || (month == 0))
                    {
                        errMsg = "日付を指定してください。";
                        return (false);
                    }
                }
            }
            else
            {
                if ((year == 0) && (month == 0) && (day == 0))
                {
                    return (true);
                }
                if (DayCheck)
                {

                    if ((year == 0) || (month == 0) || (day == 0))
                    {
                        errMsg = "日付を指定してください。";
                        return (false);
                    }
                }
                else
                {
                    if ((year == 0) || (month == 0))
                    {
                        errMsg = "日付を指定してください。";
                        return (false);
                    }
                }
            }

            if (year < 1900)
            {
                errMsg = "正しい日付を指定してください。";
                return (false);
            }

            if (month > 12)
            {
                errMsg = "正しい日付を指定してください。";
                return (false);
            }

            if (day > DateTime.DaysInMonth(year, month))
            {
                errMsg = "正しい日付を指定してください。";
                return (false);
            }

            return (true);
        }
        #endregion

        #region ◎ 印刷前確認処理
        /// <summary>
        /// 印刷前確認処理
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: 印刷前確認処理を行う。(入力チェックなど)</br>
        /// <br>Programmer	: 楊明俊</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // コントロールにフォーカスをセット
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                status = false;
            }

            return status;
        }
        #endregion

        #region ◎ 画面表示処理
        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <param name="parameter">起動パラメータ</param>
        /// <remarks>
        /// <br>Note		: 画面表示を行う。</br>
        /// <br>Programmer	: 楊明俊</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this._campaignTargetPrintWork = new CampaignTargetPrintWork();

            this.Show();
            return;
        }
        #endregion

        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッドリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = PRINTSET_TABLE;
        }

        /// <summary>
        /// メインフレームグリットレイアウト設定
        /// </summary>
        /// <param name="UGrid"></param>
        /// <remarks>
        /// <br>Note       : メインフレームグリットレイアウト設定を行う</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public void SetGridStyle(ref Infragistics.Win.UltraWinGrid.UltraGrid UGrid)
        {

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = UGrid.DisplayLayout.Bands[0];
            if (editBand == null) return;

            UGrid.DisplayLayout.Bands[0].UseRowLayout = true;

            // 列幅の自動調整方法
            UGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            UGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            UGrid.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            UGrid.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            UGrid.DisplayLayout.Bands[0].Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;// None;
            UGrid.DisplayLayout.Bands[0].Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            UGrid.DisplayLayout.Bands[0].RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
            UGrid.DisplayLayout.Bands[0].RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;
            System.Drawing.Size sizeHeader = new Size();
            System.Drawing.Size sizeCell = new Size();

            #region 項目のサイズを設定
            sizeCell.Height = 22;
            sizeCell.Width = 60;
            sizeHeader.Height = 20;
            sizeHeader.Width = 60;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYDATEALL].Hidden = true;
            // コード
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 320;
            sizeHeader.Width = 320;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 100;
            sizeHeader.Width = 100;

            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 320;
            sizeHeader.Width = 320;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // 金額
            sizeCell.Width = 120;
            sizeHeader.Width = 120;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGET].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGET].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGET].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGET].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETPROFIT].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETPROFIT].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETPROFIT].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETPROFIT].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETCOUNT].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETCOUNT].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETCOUNT].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETCOUNT].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT1].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT1].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT2].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT2].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT3].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT3].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT4].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT4].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT5].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT5].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT6].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT6].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT7].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT7].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT8].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT8].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT9].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT9].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT10].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT10].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT11].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT11].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT12].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT12].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 150;
            sizeHeader.Width = 150;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNTALL].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNTALL].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            #endregion  項目のサイズを設定

            #region LabelSpanの設定
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGET].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGET].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETPROFIT].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETPROFIT].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETCOUNT].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETCOUNT].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT1].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT2].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT3].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT4].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT5].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT6].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT7].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT8].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT9].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT10].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT11].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT12].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNTALL].RowLayoutColumnInfo.LabelSpan = 2;
            #endregion LabelSpanの設定

            #region ヘッダ名称
            // ヘッダ名称を設定
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].Header.Caption = CAMPAIGNCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].Header.Caption = CAMPAIGNNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].Header.Caption = SECTIONCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].Header.Caption = SECTIONGUIDESNM_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Header.Caption = BLGOODSCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].Header.Caption = BLGOODSCODENAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Header.Caption = SALESEMPLOYEECD_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Header.Caption = SALESEMPLOYEENM_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Header.Caption = FRONTEMPLOYEECD_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Header.Caption = FRONTEMPLOYEENM_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Header.Caption = SALESINPUTCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Header.Caption = SALESINPUTNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Header.Caption = SALESCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Header.Caption = SALESCODENAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Header.Caption = BLGROUPCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].Header.Caption = BLGROUPCODENAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Header.Caption = CUSTOMERCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Header.Caption = CUSTOMERSNM_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Header.Caption = SALESAREACODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Header.Caption = SALESAREACODENAME_TITLE;

            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGET].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGET].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETPROFIT].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETPROFIT].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETCOUNT].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETCOUNT].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT1].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT2].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT3].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT4].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT5].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT6].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT7].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT8].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT9].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT10].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT11].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT12].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNTALL].Hidden = false;

            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGET].Header.Caption = MONTHLYSALESTARGET_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGET].Header.Caption = TERMSALESTARGET_TITLE;

            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETPROFIT].Header.Caption = MONTHLYSALESTARGET_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETPROFIT].Header.Caption = TERMSALESTARGET_TITLE;

            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETCOUNT].Header.Caption = MONTHLYSALESTARGET_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETCOUNT].Header.Caption = TERMSALESTARGET_TITLE;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].Header.Caption = _startMonth.Month + "月";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].Header.Caption = _startMonth.Month + "月";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT1].Header.Caption = _startMonth.Month + "月";

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].Header.Caption = _startMonth.AddMonths(1).Month + "月";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].Header.Caption = _startMonth.AddMonths(1).Month + "月";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT2].Header.Caption = _startMonth.AddMonths(1).Month + "月";

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].Header.Caption = _startMonth.AddMonths(2).Month + "月";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].Header.Caption = _startMonth.AddMonths(2).Month + "月";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT3].Header.Caption = _startMonth.AddMonths(2).Month + "月";

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].Header.Caption = _startMonth.AddMonths(3).Month + "月";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].Header.Caption = _startMonth.AddMonths(3).Month + "月";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT4].Header.Caption = _startMonth.AddMonths(3).Month + "月";

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].Header.Caption = _startMonth.AddMonths(4).Month + "月";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].Header.Caption = _startMonth.AddMonths(4).Month + "月";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT5].Header.Caption = _startMonth.AddMonths(4).Month + "月";

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].Header.Caption = _startMonth.AddMonths(5).Month + "月";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].Header.Caption = _startMonth.AddMonths(5).Month + "月";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT6].Header.Caption = _startMonth.AddMonths(5).Month + "月";

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].Header.Caption = _startMonth.AddMonths(6).Month + "月";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].Header.Caption = _startMonth.AddMonths(6).Month + "月";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT7].Header.Caption = _startMonth.AddMonths(6).Month + "月";

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].Header.Caption = _startMonth.AddMonths(7).Month + "月";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].Header.Caption = _startMonth.AddMonths(7).Month + "月";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT8].Header.Caption = _startMonth.AddMonths(7).Month + "月";

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].Header.Caption = _startMonth.AddMonths(8).Month + "月";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].Header.Caption = _startMonth.AddMonths(8).Month + "月";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT9].Header.Caption = _startMonth.AddMonths(8).Month + "月";

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].Header.Caption = _startMonth.AddMonths(9).Month + "月";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].Header.Caption = _startMonth.AddMonths(9).Month + "月";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT10].Header.Caption = _startMonth.AddMonths(9).Month + "月";

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].Header.Caption = _startMonth.AddMonths(10).Month + "月";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].Header.Caption = _startMonth.AddMonths(10).Month + "月";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT11].Header.Caption = _startMonth.AddMonths(10).Month + "月";

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].Header.Caption = _startMonth.AddMonths(11).Month + "月";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].Header.Caption = _startMonth.AddMonths(11).Month + "月";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT12].Header.Caption = _startMonth.AddMonths(11).Month + "月";

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].Header.Caption = SALESTARGETMONEYALL_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].Header.Caption = SALESTARGETPROFITALL_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNTALL].Header.Caption = SALESTARGETCOUNTALL_TITLE;

            #endregion

            #region 非表示処理

            switch ((int)this.tComboEditor_PrintType.Value)
            {
                case 0: //拠点
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Hidden = true;
                    break;
                case 1: //拠点-得意先
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Hidden = true;
                    break;
                case 2: //拠点-担当者 
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Hidden = true;
                    break;
                case 3: //拠点-受注者 
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Hidden = true;
                    break;
                case 4: //拠点-発行者 
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Hidden = true;
                    break;
                case 5: //拠点＋地区
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Hidden = false;

                    break;
                case 6: //拠点＋ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Hidden = true;
                    break;
                case 7: //拠点＋BLｺｰﾄﾞ
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Hidden = true;
                    break;
                case 8: //拠点＋販売区分
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Hidden = true;
                    break;
            }
            #endregion

            // 文字表示位置の設定
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGET].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGET].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETPROFIT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETPROFIT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETCOUNT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETCOUNT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT4].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT5].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT6].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT7].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT8].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT9].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT10].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT11].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT12].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNTALL].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // 表示フォーマットの設定
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGET].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGET].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETPROFIT].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETPROFIT].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETCOUNT].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETCOUNT].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT1].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT2].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT3].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT4].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT5].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT6].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT7].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT8].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT9].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT10].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT11].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT12].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNTALL].Format = "#,##0";

            #region 列配置

            int i_spanY = 4;

            // 1行目

            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].RowLayoutColumnInfo.OriginX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].RowLayoutColumnInfo.OriginX = 4;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].RowLayoutColumnInfo.SpanY = 2 + i_spanY;

            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.OriginX = 6;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.OriginX = 8;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
            switch ((int)this.tComboEditor_PrintType.Value)
            {
                case 1: //拠点-得意先 
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginX = 10;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanY = 2 + i_spanY;

                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginX = 12;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
                    break;
                case 2: //拠点-担当者 
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].RowLayoutColumnInfo.OriginX = 10;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].RowLayoutColumnInfo.SpanY = 2 + i_spanY;

                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].RowLayoutColumnInfo.OriginX = 12;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
                    break;
                case 3: //拠点-受注者 
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].RowLayoutColumnInfo.OriginX = 10;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].RowLayoutColumnInfo.SpanY = 2 + i_spanY;

                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].RowLayoutColumnInfo.OriginX = 12;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
                    break;
                case 4: //拠点-発行者 
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].RowLayoutColumnInfo.OriginX = 10;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].RowLayoutColumnInfo.SpanY = 2 + i_spanY;

                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].RowLayoutColumnInfo.OriginX = 12;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
                    break;
                case 5: //拠点-地区
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].RowLayoutColumnInfo.OriginX = 10;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].RowLayoutColumnInfo.SpanY = 2 + i_spanY;

                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].RowLayoutColumnInfo.OriginX = 12;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
                    break;
                case 6: //拠点＋ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.OriginX = 10;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.SpanY = 2 + i_spanY;

                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].RowLayoutColumnInfo.OriginX = 12;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
                    break;
                case 7: //拠点＋BLｺｰﾄﾞ 
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.OriginX = 10;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.SpanY = 2 + i_spanY;

                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].RowLayoutColumnInfo.OriginX = 12;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
                    break;
                case 8: //拠点-販売区分
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.OriginX = 10;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.SpanY = 2 + i_spanY;

                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].RowLayoutColumnInfo.OriginX = 12;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
                    break;
             
            }


            int cnt = 0;

            if ((int)this.tComboEditor_PrintType.Value != 0)
            {
                cnt = 4;
            }

            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGET].RowLayoutColumnInfo.OriginX = 10 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGET].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGET].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGET].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGET].RowLayoutColumnInfo.OriginX = 12 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGET].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGET].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGET].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].RowLayoutColumnInfo.OriginX = 14 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].RowLayoutColumnInfo.OriginX = 16 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].RowLayoutColumnInfo.OriginX = 18 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].RowLayoutColumnInfo.OriginX = 20 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].RowLayoutColumnInfo.OriginX = 22 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].RowLayoutColumnInfo.OriginX = 24 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].RowLayoutColumnInfo.OriginX = 26 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].RowLayoutColumnInfo.OriginX = 28 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].RowLayoutColumnInfo.OriginX = 30 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].RowLayoutColumnInfo.OriginX = 32 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].RowLayoutColumnInfo.OriginX = 34 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].RowLayoutColumnInfo.OriginX = 36 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].RowLayoutColumnInfo.OriginX = 38 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETPROFIT].RowLayoutColumnInfo.OriginX = 10 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETPROFIT].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETPROFIT].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETPROFIT].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETPROFIT].RowLayoutColumnInfo.OriginX = 12 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETPROFIT].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETPROFIT].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETPROFIT].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].RowLayoutColumnInfo.OriginX = 14 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].RowLayoutColumnInfo.OriginX = 16 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].RowLayoutColumnInfo.OriginX = 18 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].RowLayoutColumnInfo.OriginX = 20 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].RowLayoutColumnInfo.OriginX = 22 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].RowLayoutColumnInfo.OriginX = 24 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].RowLayoutColumnInfo.OriginX = 26 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].RowLayoutColumnInfo.OriginX = 28 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].RowLayoutColumnInfo.OriginX = 30 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].RowLayoutColumnInfo.OriginX = 32 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].RowLayoutColumnInfo.OriginX = 34 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].RowLayoutColumnInfo.OriginX = 36 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].RowLayoutColumnInfo.SpanY = 2;


            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].RowLayoutColumnInfo.OriginX = 38 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].RowLayoutColumnInfo.SpanY = 2;


            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETCOUNT].RowLayoutColumnInfo.OriginX = 10 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETCOUNT].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETCOUNT].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETCOUNT].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETCOUNT].RowLayoutColumnInfo.OriginX = 12 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETCOUNT].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETCOUNT].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETCOUNT].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT1].RowLayoutColumnInfo.OriginX = 14 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT1].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT1].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT1].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT2].RowLayoutColumnInfo.OriginX = 16 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT2].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT2].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT2].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT3].RowLayoutColumnInfo.OriginX = 18 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT3].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT3].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT3].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT4].RowLayoutColumnInfo.OriginX = 20 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT4].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT4].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT4].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT5].RowLayoutColumnInfo.OriginX = 22 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT5].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT5].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT5].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT6].RowLayoutColumnInfo.OriginX = 24 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT6].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT6].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT6].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT7].RowLayoutColumnInfo.OriginX = 26 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT7].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT7].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT7].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT8].RowLayoutColumnInfo.OriginX = 28 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT8].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT8].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT8].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT9].RowLayoutColumnInfo.OriginX = 30 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT9].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT9].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT9].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT10].RowLayoutColumnInfo.OriginX = 32 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT10].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT10].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT10].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT11].RowLayoutColumnInfo.OriginX = 34 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT11].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT11].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT11].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT12].RowLayoutColumnInfo.OriginX = 36 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT12].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT12].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT12].RowLayoutColumnInfo.SpanY = 2;


            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNTALL].RowLayoutColumnInfo.OriginX = 38 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNTALL].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNTALL].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNTALL].RowLayoutColumnInfo.SpanY = 2;

            #endregion 列配置

        }

        /// <summary>
        /// 抽出条件チェック処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 抽出条件チェック処理を行う</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public bool DataCheck()
        {
            bool status = true;

            //印刷パターン
            if (this._campaignTargetPrintWork.PrintType != (int)this.tComboEditor_PrintType.Value)
            {
                status = false;
                return status;
            }

            int inputValue = 0;
            int.TryParse(tEdit_CampaingCode_St.DataText, out inputValue);
            //開始キャンペーンコード
            if (this._campaignTargetPrintWork.CampaignCodeSt != inputValue)
            {
                status = false;
                return status;
            }

            int.TryParse(this.tEdit_CampaingCode_Ed.DataText, out inputValue);
            //終了キャンペーンコード
            if (this._campaignTargetPrintWork.CampaignCodeEd != inputValue)
            {
                status = false;
                return status;
            }

            //開始拠点
            if (this._campaignTargetPrintWork.SectionCodeSt != this.tEdit_SectionCode_St.DataText)
            {
                status = false;
                return status;
            }

            //終了拠点
            if (this._campaignTargetPrintWork.SectionCodeEd != this.tEdit_SectionCode_Ed.DataText)
            {
                status = false;
                return status;
            }
            switch ((int)this.tComboEditor_PrintType.Value)
            {
                case 1: //拠点-得意先
                    if (this._campaignTargetPrintWork.CustomerCodeSt != this.tNedit_CustomerCode_St.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    if (this._campaignTargetPrintWork.CustomerCodeEd != this.tNedit_CustomerCode_Ed.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    break;
                case 2: //拠点-担当者 
                case 3: //拠点-受注者 
                case 4: //拠点-発行者 
                    if (this._campaignTargetPrintWork.EmployeeCodeSt != this.tEdit_EmployeeCode_St.DataText)
                    {
                        status = false;
                        return status;
                    }
                    if (this._campaignTargetPrintWork.EmployeeCodeEd != this.tEdit_EmployeeCode_Ed.DataText)
                    {
                        status = false;
                        return status;
                    }
                    break;
                case 5: //拠点-地区 
                    if (this._campaignTargetPrintWork.SalesAreaCodeSt != this.tNedit_GuideCode_St.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    if (this._campaignTargetPrintWork.SalesAreaCodeEd != this.tNedit_GuideCode_Ed.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    break;
                case 6: //拠点＋ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                    if (this._campaignTargetPrintWork.BlGroupCodeSt != this.tNedit_GroupCode_St.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    if (this._campaignTargetPrintWork.BlGroupCodeEd != this.tNedit_GroupCode_Ed.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    break;
                case 7: //拠点-BLｺｰﾄﾞ 
                    if (this._campaignTargetPrintWork.BlGoodsCdSt != this.tNedit_BLGoodsCode_St.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    if (this._campaignTargetPrintWork.BlGoodsCdEd != this.tNedit_BLGoodsCode_Ed.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    break;
                case 8: //拠点-販売区分

                    if (this._campaignTargetPrintWork.SalesCodeSt != this.tNedit_GuideCode_St.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    if (this._campaignTargetPrintWork.SalesCodeEd != this.tNedit_GuideCode_Ed.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    break;
            }

            // 削除指定
            if (this._campaignTargetPrintWork.LogicalDeleteCode != (int)this.tComboEditor_LogicalDeleteCode.Value)
            {
                status = false;
                return status;
            }
            // 開始削除年月日
            if (this._campaignTargetPrintWork.DeleteDateTimeSt != this.SerchSlipDataStRF_tDateEdit.GetLongDate())
            {
                status = false;
                return status;
            }
            // 終了削除年月日
            if (this._campaignTargetPrintWork.DeleteDateTimeEd != this.SerchSlipDataEdRF_tDateEdit.GetLongDate())
            {
                status = false;
                return status;
            }
            return status;
        }
        #endregion ◆ Public Method
        #endregion ■ IPrintConditionInpType メンバ

        #region ■ IPrintConditionInpTypePdfCareer メンバ
        #region ◆ Public Property

        /// <summary> 帳票キープロパティ </summary>
        public string PrintKey
        {
            get { return this._printKey; }
        }

        /// <summary> 帳票名プロパティ </summary>
        public string PrintName
        {
            get { return this._printName; }
        }

        #endregion ◆ Public Method
        #endregion ■ IPrintConditionInpTypePdfCareer メンバ

        /// <summary>
        /// PMKHN08710UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: </br>
        /// </remarks>
        private void PMKHN08710UA_Load(object sender, EventArgs e)
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
            this._controlScreenSkin.LoadSkin();						// 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.SettingScreenSkin(this);		// 画面スキン変更

            ParentToolbarSettingEvent(this);						// ツールバーボタン設定イベント起動
            this.tComboEditor_PrintType.Focus();
        }

        #region ◆ エラーメッセージ表示処理 ( +1のオーバーロード )
        #region ◎ エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer	: 楊明俊</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
                this._printName,					// プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
        #endregion

        #region ◎ エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <param name="procnm">発生メソッドID</param>
        /// <param name="ex">例外情報</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer	: 楊明俊</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private void MsgDispProc(string message, int status, string procnm, Exception ex)
        {
            string errMessage = message + "\r\n" + ex.Message;

            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
                this._printName,					// プログラム名称
                procnm, 							// 処理名称
                "",									// オペレーション
                errMessage,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
        #endregion
        #endregion ◆ エラーメッセージ表示処理 ( +1のオーバーロード )

        #region DataSet関連
        /// <summary>
        /// 商品クラスデータセット展開処理
        /// </summary>
        /// <param name="campaignTargetSet">商品クラス</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 商品クラスをデータセットへ格納します。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void SecPrintSetToDataSet(CampaignTargetSet campaignTargetSet, int index)
        {

            if ((index < 0) || (this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[PRINTSET_TABLE].NewRow();
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count - 1;

            }
            if (campaignTargetSet.CampaignCode.Trim().PadLeft(6, '0').Equals("000000"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CAMPAIGNCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CAMPAIGNCODE] = campaignTargetSet.CampaignCode.Trim().PadLeft(6, '0');
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CAMPAIGNNAME] = campaignTargetSet.CampaignCodeName;

            if (string.IsNullOrEmpty(campaignTargetSet.SectionCode.Trim()))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONCODE] = campaignTargetSet.SectionCode.Trim().PadLeft(2, '0');
            }
            if (campaignTargetSet.SectionCode.Trim().PadLeft(2, '0').Equals("00"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONGUIDESNM] = "全社";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONGUIDESNM] = campaignTargetSet.SectionGuideSnm;
            }
            if (campaignTargetSet.BlGoodsCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGOODSCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGOODSCODE] = campaignTargetSet.BlGoodsCode.ToString("00000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGOODSCODENAME] = campaignTargetSet.BlGoodsCodeName;
            if (campaignTargetSet.SalesEmployeeCd.Trim().PadLeft(4, '0').Equals("0000"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESEMPLOYEECD] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESEMPLOYEECD] = campaignTargetSet.SalesEmployeeCd.Trim().PadLeft(4, '0');
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESEMPLOYEENM] = campaignTargetSet.SalesEmployeeNm;
            if (campaignTargetSet.FrontEmployeeCd.Trim().PadLeft(4, '0').Equals("0000"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][FRONTEMPLOYEECD] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][FRONTEMPLOYEECD] = campaignTargetSet.FrontEmployeeCd.Trim().PadLeft(4, '0');
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][FRONTEMPLOYEENM] = campaignTargetSet.FrontEmployeeNm;
            if (campaignTargetSet.SalesInputCode.Trim().PadLeft(4, '0').Equals("0000"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESINPUTCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESINPUTCODE] = campaignTargetSet.SalesInputCode.Trim().PadLeft(4, '0');
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESINPUTNAME] = campaignTargetSet.SalesInputName;
            if (campaignTargetSet.SalesCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESCODE] = campaignTargetSet.SalesCode.ToString("0000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESCODENAME] = campaignTargetSet.SalesCodeName;
            if (campaignTargetSet.BlGroupCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGROUPCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGROUPCODE] = campaignTargetSet.BlGroupCode.ToString("00000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGROUPCODENAME] = campaignTargetSet.BlGroupCodeName;
            if (campaignTargetSet.CustomerCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERCODE] = campaignTargetSet.CustomerCode.ToString("00000000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERSNM] = campaignTargetSet.CustomerSnm;
            if (campaignTargetSet.SalesAreaCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESAREACODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESAREACODE] = campaignTargetSet.SalesAreaCode.ToString("0000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESAREACODENAME] = campaignTargetSet.SalesAreaCodeName;

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MONTHLYSALESTARGET] = campaignTargetSet.MonthlySalesTarget;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][TERMSALESTARGET] = campaignTargetSet.TermSalesTarget;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY1] = campaignTargetSet.SalesTargetMoney1;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY2] = campaignTargetSet.SalesTargetMoney2;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY3] = campaignTargetSet.SalesTargetMoney3;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY4] = campaignTargetSet.SalesTargetMoney4;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY5] = campaignTargetSet.SalesTargetMoney5;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY6] = campaignTargetSet.SalesTargetMoney6;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY7] = campaignTargetSet.SalesTargetMoney7;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY8] = campaignTargetSet.SalesTargetMoney8;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY9] = campaignTargetSet.SalesTargetMoney9;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY10] = campaignTargetSet.SalesTargetMoney10;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY11] = campaignTargetSet.SalesTargetMoney11;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY12] = campaignTargetSet.SalesTargetMoney12;

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEYALL] = campaignTargetSet.SalesTargetMoney1 +
                                                                                        campaignTargetSet.SalesTargetMoney2 +
                                                                                        campaignTargetSet.SalesTargetMoney3 +
                                                                                        campaignTargetSet.SalesTargetMoney4 +
                                                                                        campaignTargetSet.SalesTargetMoney5 +
                                                                                        campaignTargetSet.SalesTargetMoney6 +
                                                                                        campaignTargetSet.SalesTargetMoney7 +
                                                                                        campaignTargetSet.SalesTargetMoney8 +
                                                                                        campaignTargetSet.SalesTargetMoney9 +
                                                                                        campaignTargetSet.SalesTargetMoney10 +
                                                                                        campaignTargetSet.SalesTargetMoney11 +
                                                                                        campaignTargetSet.SalesTargetMoney12;

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MONTHLYSALESTARGETPROFIT] = campaignTargetSet.MonthlySalesTargetProfit;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][TERMSALESTARGETPROFIT] = campaignTargetSet.TermSalesTargetProfit;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT1] = campaignTargetSet.SalesTargetProfit1;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT2] = campaignTargetSet.SalesTargetProfit2;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT3] = campaignTargetSet.SalesTargetProfit3;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT4] = campaignTargetSet.SalesTargetProfit4;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT5] = campaignTargetSet.SalesTargetProfit5;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT6] = campaignTargetSet.SalesTargetProfit6;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT7] = campaignTargetSet.SalesTargetProfit7;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT8] = campaignTargetSet.SalesTargetProfit8;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT9] = campaignTargetSet.SalesTargetProfit9;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT10] = campaignTargetSet.SalesTargetProfit10;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT11] = campaignTargetSet.SalesTargetProfit11;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT12] = campaignTargetSet.SalesTargetProfit12;

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFITALL] = campaignTargetSet.SalesTargetProfit1 +
                                                                                        campaignTargetSet.SalesTargetProfit2 +
                                                                                        campaignTargetSet.SalesTargetProfit3 +
                                                                                        campaignTargetSet.SalesTargetProfit4 +
                                                                                        campaignTargetSet.SalesTargetProfit5 +
                                                                                        campaignTargetSet.SalesTargetProfit6 +
                                                                                        campaignTargetSet.SalesTargetProfit7 +
                                                                                        campaignTargetSet.SalesTargetProfit8 +
                                                                                        campaignTargetSet.SalesTargetProfit9 +
                                                                                        campaignTargetSet.SalesTargetProfit10 +
                                                                                        campaignTargetSet.SalesTargetProfit11 +
                                                                                        campaignTargetSet.SalesTargetProfit12;

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MONTHLYSALESTARGETCOUNT] = campaignTargetSet.MonthlySalesTargetCount;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][TERMSALESTARGETCOUNT] = campaignTargetSet.TermSalesTargetCount;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETCOUNT1] = campaignTargetSet.SalesTargetCount1;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETCOUNT2] = campaignTargetSet.SalesTargetCount2;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETCOUNT3] = campaignTargetSet.SalesTargetCount3;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETCOUNT4] = campaignTargetSet.SalesTargetCount4;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETCOUNT5] = campaignTargetSet.SalesTargetCount5;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETCOUNT6] = campaignTargetSet.SalesTargetCount6;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETCOUNT7] = campaignTargetSet.SalesTargetCount7;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETCOUNT8] = campaignTargetSet.SalesTargetCount8;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETCOUNT9] = campaignTargetSet.SalesTargetCount9;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETCOUNT10] = campaignTargetSet.SalesTargetCount10;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETCOUNT11] = campaignTargetSet.SalesTargetCount11;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETCOUNT12] = campaignTargetSet.SalesTargetCount12;

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETCOUNTALL] = campaignTargetSet.SalesTargetCount1 +
                                                                                        campaignTargetSet.SalesTargetCount2 +
                                                                                        campaignTargetSet.SalesTargetCount3 +
                                                                                        campaignTargetSet.SalesTargetCount4 +
                                                                                        campaignTargetSet.SalesTargetCount5 +
                                                                                        campaignTargetSet.SalesTargetCount6 +
                                                                                        campaignTargetSet.SalesTargetCount7 +
                                                                                        campaignTargetSet.SalesTargetCount8 +
                                                                                        campaignTargetSet.SalesTargetCount9 +
                                                                                        campaignTargetSet.SalesTargetCount10 +
                                                                                        campaignTargetSet.SalesTargetCount11 +
                                                                                        campaignTargetSet.SalesTargetCount12;
            const string dateFormat = "YYYY/MM/DD";
            string stTarget = TDateTime.DateTimeToString(dateFormat, campaignTargetSet.ApplyStaDate);
            string edTarget = TDateTime.DateTimeToString(dateFormat, campaignTargetSet.ApplyEndDate);
            if (!string.IsNullOrEmpty(stTarget) && !string.IsNullOrEmpty(edTarget))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][APPLYDATEALL] = "[" + stTarget + "～" + edTarget + "]";
            }
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSetの列情報を構築します。データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable PrintSetTable = new DataTable(PRINTSET_TABLE);

            // Addを行う順番が、列の表示順位となります。
            PrintSetTable.Columns.Add(CAMPAIGNCODE, typeof(string));		        // 	ｷｬﾝﾍﾟｰﾝ
            PrintSetTable.Columns.Add(CAMPAIGNNAME, typeof(string));		        // 	ｷｬﾝﾍﾟｰﾝ名
            PrintSetTable.Columns.Add(SECTIONCODE, typeof(string));		            // 	拠点
            PrintSetTable.Columns.Add(SECTIONGUIDESNM, typeof(string));		        // 	拠点名
            PrintSetTable.Columns.Add(CUSTOMERCODE, typeof(string));		        // 	得意先
            PrintSetTable.Columns.Add(CUSTOMERSNM, typeof(string));		            // 	得意先名
            PrintSetTable.Columns.Add(SALESEMPLOYEECD, typeof(string));		        // 	担当者
            PrintSetTable.Columns.Add(SALESEMPLOYEENM, typeof(string));		        // 	担当者名
            PrintSetTable.Columns.Add(FRONTEMPLOYEECD, typeof(string));		        // 	受注者
            PrintSetTable.Columns.Add(FRONTEMPLOYEENM, typeof(string));		        // 	受注者名
            PrintSetTable.Columns.Add(SALESINPUTCODE, typeof(string));		        // 	発行者
            PrintSetTable.Columns.Add(SALESINPUTNAME, typeof(string));		        // 	発行者名
            PrintSetTable.Columns.Add(SALESAREACODE, typeof(string));		        // 	地区
            PrintSetTable.Columns.Add(SALESAREACODENAME, typeof(string));		    // 	地区名
            PrintSetTable.Columns.Add(BLGROUPCODE, typeof(string));		            // 	ｸﾞﾙｰﾌﾟｺｰﾄﾞ
            PrintSetTable.Columns.Add(BLGROUPCODENAME, typeof(string));		        // 	ｸﾞﾙｰﾌﾟｺｰﾄﾞ名
            PrintSetTable.Columns.Add(BLGOODSCODE, typeof(string));		            // 	BLｺｰﾄﾞ
            PrintSetTable.Columns.Add(BLGOODSCODENAME, typeof(string));		        // 	BLｺｰﾄﾞ名
            PrintSetTable.Columns.Add(SALESCODE, typeof(string));		            // 	販売区分
            PrintSetTable.Columns.Add(SALESCODENAME, typeof(string));		        // 	販売区分名

            PrintSetTable.Columns.Add(MONTHLYSALESTARGET, typeof(Int64));		    // 	月間　売上目標
            PrintSetTable.Columns.Add(TERMSALESTARGET, typeof(Int64));		        // 	期間　売上目標
            PrintSetTable.Columns.Add(SALESTARGETMONEY1, typeof(Int64));		    // 	売上１
            PrintSetTable.Columns.Add(SALESTARGETMONEY2, typeof(Int64));		    // 	売上２
            PrintSetTable.Columns.Add(SALESTARGETMONEY3, typeof(Int64));		    // 	売上３
            PrintSetTable.Columns.Add(SALESTARGETMONEY4, typeof(Int64));		    // 	売上４
            PrintSetTable.Columns.Add(SALESTARGETMONEY5, typeof(Int64));		    // 	売上５
            PrintSetTable.Columns.Add(SALESTARGETMONEY6, typeof(Int64));		    // 	売上６
            PrintSetTable.Columns.Add(SALESTARGETMONEY7, typeof(Int64));		    // 	売上７
            PrintSetTable.Columns.Add(SALESTARGETMONEY8, typeof(Int64));		    // 	売上８
            PrintSetTable.Columns.Add(SALESTARGETMONEY9, typeof(Int64));		    // 	売上９
            PrintSetTable.Columns.Add(SALESTARGETMONEY10, typeof(Int64));		    // 	売上１０
            PrintSetTable.Columns.Add(SALESTARGETMONEY11, typeof(Int64));		    // 	売上１１
            PrintSetTable.Columns.Add(SALESTARGETMONEY12, typeof(Int64));		    // 	売上１２
            PrintSetTable.Columns.Add(SALESTARGETMONEYALL, typeof(Int64));		    // 	売上合計

            PrintSetTable.Columns.Add(MONTHLYSALESTARGETPROFIT, typeof(Int64));		// 	月間　粗利目標
            PrintSetTable.Columns.Add(TERMSALESTARGETPROFIT, typeof(Int64));		// 	期間　粗利目標
            PrintSetTable.Columns.Add(SALESTARGETPROFIT1, typeof(Int64));		    // 	粗利１
            PrintSetTable.Columns.Add(SALESTARGETPROFIT2, typeof(Int64));		    // 	粗利２
            PrintSetTable.Columns.Add(SALESTARGETPROFIT3, typeof(Int64));		    // 	粗利３
            PrintSetTable.Columns.Add(SALESTARGETPROFIT4, typeof(Int64));		    // 	粗利４
            PrintSetTable.Columns.Add(SALESTARGETPROFIT5, typeof(Int64));		    // 	粗利５
            PrintSetTable.Columns.Add(SALESTARGETPROFIT6, typeof(Int64));		    // 	粗利６
            PrintSetTable.Columns.Add(SALESTARGETPROFIT7, typeof(Int64));		    // 	粗利７
            PrintSetTable.Columns.Add(SALESTARGETPROFIT8, typeof(Int64));		    // 	粗利８
            PrintSetTable.Columns.Add(SALESTARGETPROFIT9, typeof(Int64));		    // 	粗利９
            PrintSetTable.Columns.Add(SALESTARGETPROFIT10, typeof(Int64));		    // 	粗利１０
            PrintSetTable.Columns.Add(SALESTARGETPROFIT11, typeof(Int64));		    // 	粗利１１
            PrintSetTable.Columns.Add(SALESTARGETPROFIT12, typeof(Int64));		    // 	粗利１２
            PrintSetTable.Columns.Add(SALESTARGETPROFITALL, typeof(Int64));		    // 	粗利合計

            PrintSetTable.Columns.Add(MONTHLYSALESTARGETCOUNT, typeof(Int64));		// 	月間　数量目標
            PrintSetTable.Columns.Add(TERMSALESTARGETCOUNT, typeof(Int64));		// 	期間　数量目標
            PrintSetTable.Columns.Add(SALESTARGETCOUNT1, typeof(Int64));		    // 	数量１
            PrintSetTable.Columns.Add(SALESTARGETCOUNT2, typeof(Int64));		    // 	数量２
            PrintSetTable.Columns.Add(SALESTARGETCOUNT3, typeof(Int64));		    // 	数量３
            PrintSetTable.Columns.Add(SALESTARGETCOUNT4, typeof(Int64));		    // 	数量４
            PrintSetTable.Columns.Add(SALESTARGETCOUNT5, typeof(Int64));		    // 	数量５
            PrintSetTable.Columns.Add(SALESTARGETCOUNT6, typeof(Int64));		    // 	数量６
            PrintSetTable.Columns.Add(SALESTARGETCOUNT7, typeof(Int64));		    // 	数量７
            PrintSetTable.Columns.Add(SALESTARGETCOUNT8, typeof(Int64));		    // 	数量８
            PrintSetTable.Columns.Add(SALESTARGETCOUNT9, typeof(Int64));		    // 	数量９
            PrintSetTable.Columns.Add(SALESTARGETCOUNT10, typeof(Int64));		    // 	数量１０
            PrintSetTable.Columns.Add(SALESTARGETCOUNT11, typeof(Int64));		    // 	数量１１
            PrintSetTable.Columns.Add(SALESTARGETCOUNT12, typeof(Int64));		    // 	数量１２
            PrintSetTable.Columns.Add(SALESTARGETCOUNTALL, typeof(Int64));		    // 	数量合計
            PrintSetTable.Columns.Add(APPLYDATEALL, typeof(string));		        // 	数量合計
            this.Bind_DataSet.Tables.Add(PrintSetTable);
        }

        #endregion DataSet関連

        #region ◎ 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 入力項目の初期化を行う</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: </br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // 初期値セット・文字列
                this.tEdit_SectionCode_St.DataText = string.Empty;
                this.tEdit_SectionCode_Ed.DataText = string.Empty;
                this.tEdit_EmployeeCode_St.DataText = string.Empty;
                this.tEdit_EmployeeCode_Ed.DataText = string.Empty;
                this.tNedit_GroupCode_St.DataText = string.Empty;
                this.tNedit_GroupCode_Ed.DataText = string.Empty;
                this.tNedit_GuideCode_St.DataText = string.Empty;
                this.tNedit_GuideCode_Ed.DataText = string.Empty;
                this.tNedit_CustomerCode_St.DataText = string.Empty;
                this.tNedit_CustomerCode_Ed.DataText = string.Empty;
                this.SerchSlipDataStRF_tDateEdit.SetDateTime(DateTime.MinValue);
                this.SerchSlipDataEdRF_tDateEdit.SetDateTime(DateTime.MinValue);
                this.tNedit_BLGoodsCode_St.DataText = string.Empty;
                this.tNedit_BLGoodsCode_Ed.DataText = string.Empty;
                this.tEdit_CampaingCode_St.DataText = string.Empty;
                this.tEdit_CampaingCode_Ed.DataText = string.Empty;

                // ボタン設定
                this.SetIconImage(this.ub_St_SectionCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_SectionCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_EmployeeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_EmployeeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_GroupCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GroupCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_GuideCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GuideCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_CustomerCd, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_CustomerCd, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BlCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BlCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_CampaingCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_CampaingCode, Size16_Index.STAR1);

                // コンボの初期化
                this.tComboEditor_PrintType.Value = 0;

                // 削除指定コンボの設定
                this.tComboEditor_LogicalDeleteCode.Value = 0;
                this.SerchSlipDataStRF_tDateEdit.Enabled = false;
                this.SerchSlipDataEdRF_tDateEdit.Enabled = false;

                // サブ項目の非表示
                this.pn_Employee.Visible = false;
                this.pn_GroupCode.Visible = false;
                this.pn_Guide.Visible = false;
                this.pn_Customer.Visible = false;

                // 初期フォーカスセット
                this.tComboEditor_PrintType.Focus();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #region ◎ ボタンアイコン設定処理
        /// <summary>
        /// ボタンアイコン設定処理
        /// </summary>
        /// <param name="settingControl">アイコンセットするコントロール</param>
        /// <param name="iconIndex">アイコンインデックス</param>
        /// <remarks>
        /// <br>Note       : ボタンアイコン設定処理を行う</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion

        #region ◎ 抽出条件設定処理(画面→抽出条件)
        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer	: 楊明俊</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                this._campaignTargetPrintWork.StartMonth = this._startMonth;

                //印刷パターン
                this._campaignTargetPrintWork.PrintType = this.tComboEditor_PrintType.SelectedIndex;

                int inputValue = 0;
                int.TryParse(this.tEdit_CampaingCode_St.DataText, out inputValue);
                //開始キャンペーンコード
                if (!string.IsNullOrEmpty(this.tEdit_CampaingCode_St.DataText))
                {
                    this._campaignTargetPrintWork.CampaignCodeSt = inputValue;
                }
                else
                {
                    this._campaignTargetPrintWork.CampaignCodeSt = 0;
                }

                int.TryParse(this.tEdit_CampaingCode_Ed.DataText, out inputValue);
                //終了キャンペーンコード
                if (!string.IsNullOrEmpty(this.tEdit_CampaingCode_Ed.DataText))
                {
                    this._campaignTargetPrintWork.CampaignCodeEd = inputValue;
                }
                else
                {
                    this._campaignTargetPrintWork.CampaignCodeEd = 0;
                }

                //開始拠点
                if (!string.IsNullOrEmpty(this.tEdit_SectionCode_St.DataText))
                {
                    this._campaignTargetPrintWork.SectionCodeSt = this.tEdit_SectionCode_St.DataText.Trim().PadLeft(2, '0');
                    if ("00".Equals(this._campaignTargetPrintWork.SectionCodeSt))
                    {
                        this._campaignTargetPrintWork.SectionCodeSt = string.Empty;
                    }
                }
                else
                {
                    this._campaignTargetPrintWork.SectionCodeSt = string.Empty;
                }

                //終了拠点
                if (!string.IsNullOrEmpty(this.tEdit_SectionCode_Ed.DataText))
                {
                    this._campaignTargetPrintWork.SectionCodeEd = this.tEdit_SectionCode_Ed.DataText.Trim().PadLeft(2, '0');
                    if ("00".Equals(this._campaignTargetPrintWork.SectionCodeEd))
                    {
                        this._campaignTargetPrintWork.SectionCodeEd = string.Empty;
                    }
                }
                else
                {
                    this._campaignTargetPrintWork.SectionCodeEd = string.Empty;
                }

                switch ((int)this.tComboEditor_PrintType.Value)
                {
                    case 0: //拠点
                        this._campaignTargetPrintWork.EmployeeCodeSt = "";
                        this._campaignTargetPrintWork.EmployeeCodeEd = "";
                        this._campaignTargetPrintWork.SalesCodeSt = 0;
                        this._campaignTargetPrintWork.SalesCodeEd = 0;
                        this._campaignTargetPrintWork.CustomerCodeSt = 0;
                        this._campaignTargetPrintWork.CustomerCodeEd = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeSt = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeEd = 0;
                        this._campaignTargetPrintWork.BlGoodsCdSt = 0;
                        this._campaignTargetPrintWork.BlGoodsCdEd = 0;
                        this._campaignTargetPrintWork.BlGroupCodeSt = 0;
                        this._campaignTargetPrintWork.BlGroupCodeEd = 0;
                        this._campaignTargetPrintWork.EmployeeDivCd = 0;

                        break;
                    case 1: //拠点＋得意先
                        this._campaignTargetPrintWork.EmployeeCodeSt = "";
                        this._campaignTargetPrintWork.EmployeeCodeEd = "";
                        this._campaignTargetPrintWork.SalesCodeSt = 0;
                        this._campaignTargetPrintWork.SalesCodeEd = 0;
                        this._campaignTargetPrintWork.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
                        this._campaignTargetPrintWork.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
                        this._campaignTargetPrintWork.SalesAreaCodeSt = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeEd = 0;
                        this._campaignTargetPrintWork.BlGoodsCdSt = 0;
                        this._campaignTargetPrintWork.BlGoodsCdEd = 0;
                        this._campaignTargetPrintWork.BlGroupCodeSt = 0;
                        this._campaignTargetPrintWork.BlGroupCodeEd = 0;
                        this._campaignTargetPrintWork.EmployeeDivCd = 0;
                        break;
                    case 2: //拠点-担当者 
                        if (!string.IsNullOrEmpty(this.tEdit_EmployeeCode_St.DataText))
                        {
                            this._campaignTargetPrintWork.EmployeeCodeSt = this.tEdit_EmployeeCode_St.DataText.Trim().PadLeft(4, '0');
                            if ("0000".Equals(this._campaignTargetPrintWork.EmployeeCodeSt))
                            {
                                this._campaignTargetPrintWork.EmployeeCodeSt = string.Empty;
                            }
                        }
                        else
                        {
                            this._campaignTargetPrintWork.EmployeeCodeSt = string.Empty;
                        }

                        if (!string.IsNullOrEmpty(this.tEdit_EmployeeCode_Ed.DataText))
                        {
                            this._campaignTargetPrintWork.EmployeeCodeEd = this.tEdit_EmployeeCode_Ed.DataText.Trim().PadLeft(4, '0');

                            if ("0000".Equals(this._campaignTargetPrintWork.EmployeeCodeEd))
                            {
                                this._campaignTargetPrintWork.EmployeeCodeEd = string.Empty;
                            }
                        }
                        else
                        {
                            this._campaignTargetPrintWork.EmployeeCodeEd = string.Empty;
                        }

                        this._campaignTargetPrintWork.SalesCodeSt = 0;
                        this._campaignTargetPrintWork.SalesCodeEd = 0;
                        this._campaignTargetPrintWork.CustomerCodeSt = 0;
                        this._campaignTargetPrintWork.CustomerCodeEd = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeSt = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeEd = 0;
                        this._campaignTargetPrintWork.BlGoodsCdSt = 0;
                        this._campaignTargetPrintWork.BlGoodsCdEd = 0;
                        this._campaignTargetPrintWork.BlGroupCodeSt = 0;
                        this._campaignTargetPrintWork.BlGroupCodeEd = 0;
                        this._campaignTargetPrintWork.EmployeeDivCd = 10;
                        break;
                    case 3: //拠点-受注者 
                        if (!string.IsNullOrEmpty(this.tEdit_EmployeeCode_St.DataText))
                        {
                            this._campaignTargetPrintWork.EmployeeCodeSt = this.tEdit_EmployeeCode_St.DataText.Trim().PadLeft(4, '0');
                            if ("0000".Equals(this._campaignTargetPrintWork.EmployeeCodeSt))
                            {
                                this._campaignTargetPrintWork.EmployeeCodeSt = string.Empty;
                            }
                        }
                        else
                        {
                            this._campaignTargetPrintWork.EmployeeCodeSt = string.Empty;
                        }

                        if (!string.IsNullOrEmpty(this.tEdit_EmployeeCode_Ed.DataText))
                        {
                            this._campaignTargetPrintWork.EmployeeCodeEd = this.tEdit_EmployeeCode_Ed.DataText.Trim().PadLeft(4, '0');

                            if ("0000".Equals(this._campaignTargetPrintWork.EmployeeCodeEd))
                            {
                                this._campaignTargetPrintWork.EmployeeCodeEd = string.Empty;
                            }
                        }
                        else
                        {
                            this._campaignTargetPrintWork.EmployeeCodeEd = string.Empty;
                        }
                        this._campaignTargetPrintWork.SalesCodeSt = 0;
                        this._campaignTargetPrintWork.SalesCodeEd = 0;
                        this._campaignTargetPrintWork.CustomerCodeSt = 0;
                        this._campaignTargetPrintWork.CustomerCodeEd = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeSt = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeEd = 0;
                        this._campaignTargetPrintWork.BlGoodsCdSt = 0;
                        this._campaignTargetPrintWork.BlGoodsCdEd = 0;
                        this._campaignTargetPrintWork.BlGroupCodeSt = 0;
                        this._campaignTargetPrintWork.BlGroupCodeEd = 0;
                        this._campaignTargetPrintWork.EmployeeDivCd = 20;
                        break;
                    case 4: //拠点-発行者 
                        if (!string.IsNullOrEmpty(this.tEdit_EmployeeCode_St.DataText))
                        {
                            this._campaignTargetPrintWork.EmployeeCodeSt = this.tEdit_EmployeeCode_St.DataText.Trim().PadLeft(4, '0');
                            if ("0000".Equals(this._campaignTargetPrintWork.EmployeeCodeSt))
                            {
                                this._campaignTargetPrintWork.EmployeeCodeSt = string.Empty;
                            }
                        }
                        else
                        {
                            this._campaignTargetPrintWork.EmployeeCodeSt = string.Empty;
                        }

                        if (!string.IsNullOrEmpty(this.tEdit_EmployeeCode_Ed.DataText))
                        {
                            this._campaignTargetPrintWork.EmployeeCodeEd = this.tEdit_EmployeeCode_Ed.DataText.Trim().PadLeft(4, '0');

                            if ("0000".Equals(this._campaignTargetPrintWork.EmployeeCodeEd))
                            {
                                this._campaignTargetPrintWork.EmployeeCodeEd = string.Empty;
                            }
                        }
                        else
                        {
                            this._campaignTargetPrintWork.EmployeeCodeEd = string.Empty;
                        }
                        this._campaignTargetPrintWork.SalesCodeSt = 0;
                        this._campaignTargetPrintWork.SalesCodeEd = 0;
                        this._campaignTargetPrintWork.CustomerCodeSt = 0;
                        this._campaignTargetPrintWork.CustomerCodeEd = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeSt = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeEd = 0;
                        this._campaignTargetPrintWork.BlGoodsCdSt = 0;
                        this._campaignTargetPrintWork.BlGoodsCdEd = 0;
                        this._campaignTargetPrintWork.BlGroupCodeSt = 0;
                        this._campaignTargetPrintWork.BlGroupCodeEd = 0;
                        this._campaignTargetPrintWork.EmployeeDivCd = 30;
                        break;
                    case 5: //拠点＋地区
                        this._campaignTargetPrintWork.EmployeeCodeSt = "";
                        this._campaignTargetPrintWork.EmployeeCodeEd = "";
                        this._campaignTargetPrintWork.SalesCodeSt = 0;
                        this._campaignTargetPrintWork.SalesCodeEd = 0;
                        this._campaignTargetPrintWork.CustomerCodeSt = 0;
                        this._campaignTargetPrintWork.CustomerCodeEd = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeSt = this.tNedit_GuideCode_St.GetInt();
                        this._campaignTargetPrintWork.SalesAreaCodeEd = this.tNedit_GuideCode_Ed.GetInt();
                        this._campaignTargetPrintWork.BlGoodsCdSt = 0;
                        this._campaignTargetPrintWork.BlGoodsCdEd = 0;
                        this._campaignTargetPrintWork.BlGroupCodeSt = 0;
                        this._campaignTargetPrintWork.BlGroupCodeEd = 0;
                        this._campaignTargetPrintWork.EmployeeDivCd = 0;
                        break;
                    case 6: //拠点＋ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                        this._campaignTargetPrintWork.EmployeeCodeSt = "";
                        this._campaignTargetPrintWork.EmployeeCodeEd = "";
                        this._campaignTargetPrintWork.SalesCodeSt = 0;
                        this._campaignTargetPrintWork.SalesCodeEd = 0;
                        this._campaignTargetPrintWork.CustomerCodeSt = 0;
                        this._campaignTargetPrintWork.CustomerCodeEd = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeSt = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeEd = 0;
                        this._campaignTargetPrintWork.BlGoodsCdSt = 0;
                        this._campaignTargetPrintWork.BlGoodsCdEd = 0;
                        this._campaignTargetPrintWork.BlGroupCodeSt = this.tNedit_GroupCode_St.GetInt();
                        this._campaignTargetPrintWork.BlGroupCodeEd = this.tNedit_GroupCode_Ed.GetInt();
                        this._campaignTargetPrintWork.EmployeeDivCd = 0;
                        break;
                    case 7: //拠点＋BLｺｰﾄﾞ
                        this._campaignTargetPrintWork.EmployeeCodeSt = "";
                        this._campaignTargetPrintWork.EmployeeCodeEd = "";
                        this._campaignTargetPrintWork.CustomerCodeSt = 0;
                        this._campaignTargetPrintWork.CustomerCodeEd = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeSt = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeEd = 0;
                        this._campaignTargetPrintWork.BlGoodsCdSt = this.tNedit_BLGoodsCode_St.GetInt();
                        this._campaignTargetPrintWork.BlGoodsCdEd = this.tNedit_BLGoodsCode_Ed.GetInt();
                        this._campaignTargetPrintWork.BlGroupCodeSt = 0;
                        this._campaignTargetPrintWork.BlGroupCodeEd = 0;
                        this._campaignTargetPrintWork.EmployeeDivCd = 0;
                        break;
                    case 8: //拠点＋販売区分
                        this._campaignTargetPrintWork.EmployeeCodeSt = "";
                        this._campaignTargetPrintWork.EmployeeCodeEd = "";
                        this._campaignTargetPrintWork.SalesCodeSt = this.tNedit_GuideCode_St.GetInt();
                        this._campaignTargetPrintWork.SalesCodeEd = this.tNedit_GuideCode_Ed.GetInt();
                        this._campaignTargetPrintWork.CustomerCodeSt = 0;
                        this._campaignTargetPrintWork.CustomerCodeEd = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeSt = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeEd = 0;
                        this._campaignTargetPrintWork.BlGoodsCdSt = 0;
                        this._campaignTargetPrintWork.BlGoodsCdEd = 0;
                        this._campaignTargetPrintWork.BlGroupCodeSt = 0;
                        this._campaignTargetPrintWork.BlGroupCodeEd = 0;
                        this._campaignTargetPrintWork.EmployeeDivCd = 0;
                        break;
                }
                // 削除指定区分
                this._campaignTargetPrintWork.LogicalDeleteCode = (int)this.tComboEditor_LogicalDeleteCode.Value;
                // 開始削除日付
                this._campaignTargetPrintWork.DeleteDateTimeSt = this.SerchSlipDataStRF_tDateEdit.GetLongDate();
                // 終了削除日付
                this._campaignTargetPrintWork.DeleteDateTimeEd = this.SerchSlipDataEdRF_tDateEdit.GetLongDate();
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        #endregion

        /// <summary>
        /// 印刷パターン変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 印刷パターン変更を行う</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void tComboEditor_PrintType_ValueChanged(object sender, EventArgs e)
        {
            switch ((int)this.tComboEditor_PrintType.Value)
            {
                case 0: //拠点
                    this.pn_GroupCode.Visible = false;
                    this.pn_Employee.Visible = false;
                    this.pn_Guide.Visible = false;
                    this.pn_Customer.Visible = false;
                    this.pn_Bl.Visible = false;
                    break;

                case 1: //拠点＋得意先 
                    this.pn_GroupCode.Visible = false;
                    this.pn_Employee.Visible = false;
                    this.pn_Guide.Visible = false;
                    this.pn_Customer.Visible = true;
                    this.pn_Customer.Location = this.pn_Employee.Location;
                    this.pn_Bl.Visible = false;
                    break;
                case 2: //拠点-担当者 
                case 3: //拠点-受注者 
                case 4: //拠点-発行者 
                    this.pn_Employee.Visible = true;
                    this.pn_GroupCode.Visible = false;
                    this.pn_Guide.Visible = false;
                    this.pn_Customer.Visible = false;

                    break;
                case 5: //拠点＋地区 
                    this.pn_Guide.Visible = true;
                    this.pn_Guide.Location = this.pn_Employee.Location;

                    this.pn_Employee.Visible = false;
                    this.pn_GroupCode.Visible = false;
                    this.pn_Customer.Visible = false;
                    this.pn_Bl.Visible = false;

                    this.Lb_Guide.Text = "地区";
                    Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfowk = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("地区ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
                    ultraToolTipInfowk.ToolTipText = "地区ガイド";
                    this.ultraToolTipManager1.SetUltraToolTip(this.ub_St_GuideCode, ultraToolTipInfowk);
                    this.ultraToolTipManager1.SetUltraToolTip(this.ub_Ed_GuideCode, ultraToolTipInfowk);

                    break;
                case 6: //拠点＋ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                    this.pn_Guide.Visible = false;
                    this.pn_Employee.Visible = false;
                    this.pn_GroupCode.Visible = true;
                    this.pn_GroupCode.Location = this.pn_Employee.Location;
                    this.pn_Customer.Visible = false;
                    this.pn_Bl.Visible = false;
                    break;
                case 7: //拠点＋BLｺｰﾄﾞ
                    this.pn_Bl.Visible = true;
                    this.pn_Bl.Location = this.pn_Employee.Location;

                    this.pn_Customer.Visible = false;
                    this.pn_Employee.Visible = false;
                    this.pn_GroupCode.Visible = false;
                    this.pn_Guide.Visible = false;

                    break;
                case 8: //拠点＋販売区分
                    this.pn_Guide.Visible = true;
                    this.pn_Guide.Location = this.pn_Employee.Location;

                    this.pn_Employee.Visible = false;
                    this.pn_GroupCode.Visible = false;
                    this.pn_Customer.Visible = false;
                    this.pn_Bl.Visible = false;

                    this.Lb_Guide.Text = "販売区分";
                    Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfowk3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("販売区分ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
                    ultraToolTipInfowk3.ToolTipText = "販売区分ガイド";
                    this.ultraToolTipManager1.SetUltraToolTip(this.ub_St_GuideCode, ultraToolTipInfowk3);
                    this.ultraToolTipManager1.SetUltraToolTip(this.ub_Ed_GuideCode, ultraToolTipInfowk3);
                    break;
            }

            this.tEdit_EmployeeCode_St.DataText = string.Empty;
            this.tEdit_EmployeeCode_Ed.DataText = string.Empty;
            this.tNedit_GroupCode_St.DataText = string.Empty;
            this.tNedit_GroupCode_Ed.DataText = string.Empty;
            this.tNedit_GuideCode_St.DataText = string.Empty;
            this.tNedit_GuideCode_Ed.DataText = string.Empty;
            this.tNedit_CustomerCode_St.DataText = string.Empty;
            this.tNedit_CustomerCode_Ed.DataText = string.Empty;
            this.tNedit_BLGoodsCode_St.DataText = string.Empty;
            this.tNedit_BLGoodsCode_Ed.DataText = string.Empty;
        }

        /// <summary>
        /// キャンペーンボタンのクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : キャンペーンボタンのクリックを行う</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ub_St_CampaingCode_Click(object sender, EventArgs e)
        {
            CampaignSt campaignSt;
            TEdit targetControl = null;
            Control nextControl = null;
            try
            {
                //this.Cursor = Cursors.WaitCursor;

                // ガイド起動
                int status = _campaignLinkAcs.CampaignStAcs.ExecuteGuid(this._enterpriseCode, out campaignSt);
                if (status == 0)
                {
                    string tag = (string)((UltraButton)sender).Tag;

                    if (tag.ToString().CompareTo("1") == 0)
                    {
                        targetControl = this.tEdit_CampaingCode_St;
                        nextControl = this.tEdit_CampaingCode_Ed;
                    }
                    else if (tag.ToString().CompareTo("2") == 0)
                    {
                        targetControl = this.tEdit_CampaingCode_Ed;
                        nextControl = this.tEdit_SectionCode_St;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }

                // コード展開
                targetControl.DataText = campaignSt.CampaignCode.ToString().PadLeft(6, '0');
                // フォーカス
                nextControl.Focus();
            }
            finally
            {
                //this.Cursor = Cursors.Default;

            }
        }

        /// <summary>
        /// 拠点ボタンのクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 拠点ボタンのクリックを行う</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ub_St_SectionCode_Click(object sender, EventArgs e)
        {
            int status = 0;

            SecInfoSet secInfoSet;

            // 拠点ガイド表示
            status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);

            string tag = (string)((UltraButton)sender).Tag;
            TEdit targetControl = null;
            Control nextControl = null;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tEdit_SectionCode_St;
                nextControl = this.tEdit_SectionCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tEdit_SectionCode_Ed;
                switch ((int)this.tComboEditor_PrintType.Value)
                {
                    case 0: //拠点 
                        nextControl = this.tComboEditor_LogicalDeleteCode;
                        break;
                    case 1: //拠点-得意先  
                        nextControl = this.tNedit_CustomerCode_St;
                        break;
                    case 2: //拠点-担当者 
                    case 3: //拠点-受注者 
                    case 4: //拠点-発行者 
                        nextControl = this.tEdit_EmployeeCode_St;
                        break;
                    case 5: //拠点-地区
                    case 8: //拠点-販売区分 
                        nextControl = this.tNedit_GuideCode_St;
                        break;
                    case 6: //拠点＋ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                        nextControl = this.tNedit_GroupCode_St;
                        break;
                    case 7: //拠点＋BLｺｰﾄﾞ
                        nextControl = this.tNedit_BLGoodsCode_St;
                        break;
                }

            }
            else
            {
                return;
            }

            if (status != 0)
            {
                return;
            }

            // コード展開
            targetControl.DataText = secInfoSet.SectionCode.Trim();
            // フォーカス
            nextControl.Focus();
        }

        /// <summary>
        /// 担当者ガイドボタンのクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 担当者ガイドボタンのクリックを行う</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ub_St_EmployeeGuide_Click(object sender, EventArgs e)
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }

            Employee employee;
            int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == 0)
            {
                if (sender == this.ub_St_EmployeeGuide)
                {
                    this.tEdit_EmployeeCode_St.Text = employee.EmployeeCode.TrimEnd();
                    this.tEdit_EmployeeCode_Ed.Focus();
                }
                else
                {
                    this.tEdit_EmployeeCode_Ed.Text = employee.EmployeeCode.TrimEnd();
                    this.tComboEditor_LogicalDeleteCode.Focus();
                }
            }
        }

        /// <summary>
        /// BLグループガイドのクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : BLグループガイドのクリックを行う</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ub_St_GroupCode_Click(object sender, EventArgs e)
        {
            // BLグループガイド起動

            if (this._blGroupUAcs == null)
            {
                this._blGroupUAcs = new BLGroupUAcs();
            }

            BLGroupU blGroupU;

            int status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);

            if (status == 0)
            {
                if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                {
                    this.tNedit_GroupCode_St.SetInt(blGroupU.BLGroupCode);
                    this.tNedit_GroupCode_Ed.Focus();
                }
                else
                {
                    this.tNedit_GroupCode_Ed.SetInt(blGroupU.BLGroupCode);
                    this.tComboEditor_LogicalDeleteCode.Focus();
                }
            }
        }

        /// <summary>
        /// ユーザーガイドのクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ユーザーガイドのクリックを行う</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ub_St_GuideCode_Click(object sender, EventArgs e)
        {
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }

            UserGdHd userGdHd = new UserGdHd();
            UserGdBd userGdBd = new UserGdBd();

            int GuideNo = 0;
            switch ((int)this.tComboEditor_PrintType.Value)
            {
                case 5: //拠点-地区
                    GuideNo = 21;
                    break;
                case 8: //拠点-販売区分  
                    GuideNo = 71;
                    break;
            }

            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, GuideNo);

            if (status != 0) return;

            TNedit targetControl;
            Control nextControl;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_GuideCode_St;
                nextControl = this.tNedit_GuideCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_GuideCode_Ed;
                nextControl = this.tComboEditor_LogicalDeleteCode;
            }
            else
            {
                return;
            }

            targetControl.DataText = userGdBd.GuideCode.ToString("0000");

            // フォーカス移動
            nextControl.Focus();
        }

        /// <summary>
        /// 得意先ガイドのクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 得意先ガイドのクリックを行う</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ub_St_CustomerCd_Click(object sender, EventArgs e)
        {
            _customerGuideOK = false;

            // 押下されたボタンを退避
            if (sender is UltraButton)
            {
                _customerGuideSender = (UltraButton)sender;
            }
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.customerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);
            // ガイド後次フォーカス
            if (_customerGuideOK)
            {
                Control nextControl;
                if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                {
                    nextControl = this.tNedit_CustomerCode_Ed;
                }
                else
                {
                    nextControl = this.tComboEditor_LogicalDeleteCode;
                }
                // フォーカス移動
                nextControl.Focus();
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note       : 得意先選択時発生イベントを行う</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void customerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            if (_customerGuideSender == this.ub_St_CustomerCd)
            {
                this.tNedit_CustomerCode_St.SetInt(customerSearchRet.CustomerCode);
                _customerGuideOK = true;
            }
            else
            {
                this.tNedit_CustomerCode_Ed.SetInt(customerSearchRet.CustomerCode);
                _customerGuideOK = true;
            }
        }

        /// <summary>
        /// Blコードガイドのクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : Blコードガイドのクリックを行う</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ub_St_BlCode_Click(object sender, EventArgs e)
        {
             BLGoodsCdUMnt bLGoodsCdUMnt;

            if (_blGoodsCdAcs == null)
            {
                _blGoodsCdAcs = new BLGoodsCdAcs();
            }

            int status = _blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tNedit_BLGoodsCode_St.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                this.tNedit_BLGoodsCode_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_BLGoodsCode_Ed.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                this.tComboEditor_LogicalDeleteCode.Focus();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 削除指定設定時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 削除指定設定を行う</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void tComboEditor_LogicalDeleteCode_ValueChanged(object sender, EventArgs e)
        {
         if ((int)tComboEditor_LogicalDeleteCode.Value == 1)
            {
                this.SerchSlipDataStRF_tDateEdit.Enabled = true;
                this.SerchSlipDataEdRF_tDateEdit.Enabled = true;
                this.SerchSlipDataStRF_tDateEdit.SetDateTime(DateTime.Now);
                this.SerchSlipDataEdRF_tDateEdit.SetDateTime(DateTime.Now);
            }
            else
            {
                this.SerchSlipDataStRF_tDateEdit.Enabled = false;
                this.SerchSlipDataEdRF_tDateEdit.Enabled = false;
                this.SerchSlipDataStRF_tDateEdit.SetDateTime(DateTime.MinValue);
                this.SerchSlipDataEdRF_tDateEdit.SetDateTime(DateTime.MinValue);
            }
        }
    }
}