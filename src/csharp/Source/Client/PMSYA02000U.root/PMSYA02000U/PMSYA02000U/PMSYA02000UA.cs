//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車輌別出荷実績表
// プログラム概要   : 車輌別出荷実績表帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2009/09/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using System.Collections;
using Broadleaf.Library.Resources;
using Infragistics.Win.Misc;
using Broadleaf.Library.Globarization;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 車輌別出荷実績表UIクラス                                                         
    /// </summary>
    /// <remarks>
    /// <br>Note       : 車輌別出荷実績表UIで、抽出条件を入力します。</br>       
    /// <br>Programmer : 張莉莉</br>                                   
    /// <br>Date       : 2009.09.15</br>                                   
    /// </remarks>
    public partial class PMSYA02000UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ Constructor
        /// <summary>
        /// 車輌別出荷実績表UIクラスコンストラクタ　　　　　　　　　　　　　　　　　　 　
        /// </summary>
        /// <remarks>
        /// <br>Note       : 車輌別出荷実績表UI初期化およびインスタンスの生成を行う</br>                 
        /// <br>Programmer : 張莉莉</br>                                  
        /// <br>Date       : 2009.09.15</br>                                     
        /// </remarks>
        public PMSYA02000UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ログイン拠点を取得
            this._loginWorker = LoginInfoAcquisition.Employee.Clone();
            this._ownSectionCode = this._loginWorker.BelongSectionCode;

            // 拠点用のHashtable作成
            this._selectedSectionList = new Hashtable();

            // 日付取得部品
            _dateGet = DateGetAcs.GetInstance();

            this._carMngInputAcs = CarMngInputAcs.GetInstance();
        }

        #endregion ■ Constructor

        #region ■ Private Member
        #region ◆ Interface member

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
        // 設定ボタン表示有無プロパティ
        private bool _visibledSetButton = true;
        // 計上拠点選択表示取得プロパティ
        private bool _visibledSelectAddUpCd = false;
        // 拠点オプション有無
        private bool _isOptSection = false;
        // 本社機能有無
        private bool _isMainOfficeFunc = false;
        // 選択拠点リスト
        private Hashtable _selectedSectionList = new Hashtable();
        #endregion ◆ Interface member

        // 企業コード
        private string _enterpriseCode = "";
        // ログイン情報
        private Employee _loginWorker = null;
        // 自拠点コード
        private string _ownSectionCode = "";

        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 抽出条件クラス
        private CarShipRsltListCndtn _carShipRsltListCndtn;

        //日付取得部品
        private DateGetAcs _dateGet;

        private CarMngInputAcs _carMngInputAcs;

        // 得意先ガイド結果OKフラグ
        private bool _customerGuideOK;
        // 得意先ガイド用
        private UltraButton _customerGuideSender;
        // グループコードガイド
        private BLGroupUAcs _blGroupUAcs;
        // BLコードガイド
        private BLGoodsCdAcs _blGoodsCdAcs;

        /// <summary>車輌備考ガイド区分 </summary>
        public static readonly int CT_DIVCODE_NOTEGUIDEDIVCD_4 = 201;
        #endregion ■ Private Member

        #region ■ Private Const
        #region ◆ Interface member
        // クラスID
        private const string ct_ClassID = "PMSYA02000UA";
        // プログラムID
        private const string ct_PGID = "PMSYA02000U";
        // 帳票名称
        private const string PDF_PRINT_NAME = "車輌別出荷実績表";
        private string _printName = PDF_PRINT_NAME;
        // 帳票キー	
        private const string PDF_PRINT_KEY = "156cc2cb-3afc-45bc-ac54-5017c884fa2f";
        private string _printKey = PDF_PRINT_KEY;
        #endregion ◆ Interface member

        //エラー条件メッセージ
        const string ct_InputError = "の入力が不正です。";
        const string ct_RangeError = "の範囲指定に誤りがあります。";

        #endregion

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

        /// <summary> 設定ボタン表示プロパティ </summary>
        public bool VisibledSetButton
        {
            get { return this._visibledSetButton; }
        }

        #endregion ◆ Public Property

        #region ◆ Public Method
        #region ◎ 抽出処理
        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>0( 固定 )</returns>
        public int Extract(ref object parameter)
        {
            // 抽出処理は無いので処理終了
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
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.09.15</br>
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
            printInfo.jyoken = this._carShipRsltListCndtn;
            printDialog.PrintInfo = printInfo;

            // 帳票選択ガイド
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません。", 0);
            }

            parameter = printInfo;

            return printInfo.status;
        }
        #endregion

        #region ◎ 印刷前確認処理
        /// <summary>
        /// 印刷前確認処理
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: 印刷前確認処理を行う。(入力チェックなど)</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.09.15</br>
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
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this.Show();
        }
        #endregion

        #endregion ◆ Public Method
        #endregion ■ IPrintConditionInpType メンバ

        #region ■ IPrintConditionInpTypeSelectedSection メンバ
        #region ◆ Public Property

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

        #endregion ◆ Public Property

        #region ◆ Public Method

        #region ◎ 拠点選択処理
        /// <summary>
        /// 拠点選択処理
        /// </summary>
        /// <param name="sectionCode">選択拠点コード</param>
        /// <param name="checkState">選択状態</param>
        /// <remarks>
        /// <br>Note		: 拠点選択処理を行う。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.09.15</br>
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
        #endregion

        #region ◎ 初期選択計上拠点設定処理( 未実装 )
        /// <summary>
        /// 初期選択計上拠点設定処理( 未実装 )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: 未実装</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        public void InitSelectAddUpCd(int addUpCd)
        {
            // 計上拠点選択がないので未実装
        }
        #endregion

        #region ◎ 初期選択拠点設定処理
        /// <summary>
        /// 初期選択拠点設定処理
        /// </summary>
        /// <param name="sectionCodeLst">選択拠点コードリスト</param>
        /// <remarks>
        /// <br>Note		: 拠点リストの初期化を行う。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.09.15</br>
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
        #endregion

        #region ◎ 初期拠点選択表示チェック処理
        /// <summary>
        /// 初期拠点選択表示チェック処理
        /// </summary>
        /// <param name="isDefaultState">true：スライダー表示　false：スライダー非表示</param>
        /// <remarks>
        /// <br>Note		: 拠点選択スライダーの表示有無を判定する。</br>
        /// <br>			: 拠点オプション、本社機能以外の個別の表示有無判定を行う。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        public bool InitVisibleCheckSection(bool isDefaultState)
        {
            return isDefaultState;
        }
        #endregion

        #region ◎ 計上拠点選択処理( 未実装 )
        /// <summary>
        /// 計上拠点選択処理( 未実装 )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: 未実装</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        public void SelectedAddUpCd(int addUpCd)
        {
            // 計上拠点選択がないので未実装
        }
        #endregion

        #endregion ◆ Public Method
        #endregion ■ IPrintConditionInpTypeSelectedSection メンバ

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
            get { return _printName; }
        }

        #endregion ◆ Public Method
        #endregion ■ IPrintConditionInpTypePdfCareer メンバ

        #region ■ Private Method
        #region ◆ 画面初期化関係
        #region ◎ 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 入力項目の初期化を行う</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // 初期値セット・区分
                this.uos_GroupBySectionDiv.Value = 0;   // 集計方法
                this.uos_RsltTtlDiv.Value = 0;          //在庫取寄指定
                this.uos_GoodsNoPrint.Value = 1;        //品番出力
                this.uos_CostGrossPrint.Value = 1;      //原価・粗利出力
                this.uos_NewPageDiv.Value = 1;          //改頁

                // 初期値セット・文字列
                this.tNedit_CustomerCode_St.DataText = string.Empty;
                this.tNedit_CustomerCode_Ed.DataText = string.Empty;
                this.tEdit_CarMngCode_St.DataText = string.Empty;
                this.tEdit_CarMngCode_Ed.DataText = string.Empty;
                this.tNedit_BLGloupCode_St.DataText = string.Empty;
                this.tNedit_BLGloupCode_Ed.DataText = string.Empty;
                this.tNedit_BLGoodsCode_St.DataText = string.Empty;
                this.tNedit_BLGoodsCode_Ed.DataText = string.Empty;
                this.tEdit_GoodsNo_St.DataText = string.Empty;
                this.tEdit_GoodsNo_Ed.DataText = string.Empty;
                this.tEdit_CarSlipNote.DataText = string.Empty;
                this.tComboEditor_ModelFullNameFuzzy.Value = 0;

                // 売上日
                this.tde_St_SalesDay.SetDateTime(DateTime.Now);
                this.tde_Ed_SalesDay.SetDateTime(DateTime.Now);

                // 明細単位
                Infragistics.Win.ValueListItem listItem;
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                listItem.DisplayText = "品番";
                this.tComboEditor_Detail.Items.Add(listItem);
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 1;
                listItem.DataValue = 1;
                listItem.DisplayText = "ＢＬコード";
                this.tComboEditor_Detail.Items.Add(listItem);
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 2;
                listItem.DataValue = 2;
                listItem.DisplayText = "グループコード";
                this.tComboEditor_Detail.Items.Add(listItem);
                this.tComboEditor_Detail.Value = 0;

                // ボタン設定
                this.SetIconImage(this.ub_St_CustomerGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_CustomerGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_CarMngNoGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_CarMngNoGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BlGroupCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BlGroupCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_SlipNoteCar, Size16_Index.STAR1);


                // 初期フォーカスセット
                this.uos_GroupBySectionDiv.Focus();
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
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion
        #endregion ◆ 画面初期化関係

        #region ◆ 印刷前処理
        #region ◎ 入力チェック処理

        /// <summary>
        /// 日付範囲チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_OrderDataCreateDate"></param>
        /// <param name="tde_Ed_OrderDataCreateDate"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonthDay, 0, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, false, false, false);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;
            DateGetAcs.CheckDateRangeResult cdrResult;


            // 売上日（開始～終了）
            if (CallCheckDateRange(out cdrResult, ref tde_St_SalesDay, ref tde_Ed_SalesDay) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("開始日{0}", ct_InputError);
                            errComponent = this.tde_St_SalesDay;
                            status = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("終了日{0}", ct_InputError);
                            errComponent = this.tde_Ed_SalesDay;
                            status = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("売上日{0}", ct_RangeError);
                            errComponent = this.tde_Ed_SalesDay;
                            status = false;
                        }
                        break;
                }
            }
            if(status == false)
            {
                return status;
            }
            // 入力日（開始～終了）
            if (CallCheckDateRange(out cdrResult, ref tde_St_InputDay, ref tde_Ed_InputDay) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("開始日{0}", ct_InputError);
                            errComponent = this.tde_St_InputDay;
                        }
                        status = false;
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("終了日{0}", ct_InputError);
                            errComponent = this.tde_Ed_InputDay;
                        }
                        status = false;
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("入力日{0}", ct_RangeError);
                            errComponent = this.tde_Ed_InputDay;
                        }
                        status = false;
                        break;
                }
            }
            if (status == false)
            {
                return status;
            }
            // 得意先
            if (this.tNedit_CustomerCode_St.GetInt() > GetEndCode(this.tNedit_CustomerCode_Ed))
            {
                errMessage = string.Format("得意先{0}", ct_RangeError);
                errComponent = this.tNedit_CustomerCode_Ed;
                status = false;
            }
            // 管理番号
            else if((this.tEdit_CarMngCode_St.DataText.TrimEnd() != string.Empty) &&
                 (this.tEdit_CarMngCode_Ed.DataText.TrimEnd() != string.Empty) &&
                 (this.tEdit_CarMngCode_St.DataText.TrimEnd().CompareTo(this.tEdit_CarMngCode_Ed.DataText.TrimEnd()) > 0)) 
            {
                errMessage = string.Format("管理番号{0}", ct_RangeError);
                errComponent = this.tEdit_CarMngCode_Ed;
                status = false;
            }
            // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
            else if (this.tNedit_BLGloupCode_St.GetInt() > GetEndCode(this.tNedit_BLGloupCode_Ed))
            {
                errMessage = string.Format("グループコード{0}", ct_RangeError);
                errComponent = this.tNedit_BLGloupCode_Ed;
                status = false;
            }
            // ＢＬｺｰﾄﾞ
            else if (this.tNedit_BLGoodsCode_St.GetInt() > GetEndCode(this.tNedit_BLGoodsCode_Ed))
            {
                errMessage = string.Format("ＢＬコード{0}", ct_RangeError);
                errComponent = this.tNedit_BLGoodsCode_Ed;
                status = false;
            }
            // 品番
            else if ((this.tEdit_GoodsNo_St.DataText.TrimEnd() != string.Empty) &&
                 (this.tEdit_GoodsNo_Ed.DataText.TrimEnd() != string.Empty) &&
                 (this.tEdit_GoodsNo_St.DataText.TrimEnd().CompareTo(this.tEdit_GoodsNo_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("品番{0}", ct_RangeError);
                errComponent = this.tEdit_GoodsNo_Ed;
                status = false;
            }

            return status;
        }

        /// <summary>
        /// 数値項目　終了コード取得処理
        /// </summary>
        /// <param name="tNedit"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>数値コード項目の内容を取得する</br>
        /// <br>　コード値＝ゼロ　→　ＭＡＸ値</br>
        /// <br>　コード値≠ゼロ　→　入力値</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private int GetEndCode(TNedit tNedit)
        {
            // 画面上コンポーネントのColumnで終了コードを取得
            return GetEndCode(tNedit, Int32.Parse(new string('9', (tNedit.ExtEdit.Column))));
        }

        /// <summary>
        /// 数値項目　終了コード取得処理
        /// </summary>
        /// <param name="tNedit"></param>
        /// <param name="endCodeOnDB"></param>
        /// <returns></returns>
        private int GetEndCode(TNedit tNedit, int endCodeOnDB)
        {
            if (tNedit.GetInt() == 0)
            {
                return endCodeOnDB;
            }
            else
            {
                return tNedit.GetInt();
            }
        }

        #endregion

        #region ◎ 抽出条件設定処理(画面→抽出条件)
        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            this._carShipRsltListCndtn = new CarShipRsltListCndtn();
            try
            {
                // 企業コード
                this._carShipRsltListCndtn.EnterpriseCode = this._enterpriseCode;
                // 「全拠点」が選択されている場合はリストをクリア
                bool allSections = false;

                foreach (object obj in _selectedSectionList.Values)
                {
                    if (obj is string)
                    {
                        if ((obj as string) == "0")
                        {
                            allSections = true;
                            break;
                        }
                    }
                }
                if (allSections)
                {
                    _selectedSectionList.Clear();
                }

                // 拠点オプション
                this._carShipRsltListCndtn.IsOptSection = this._isOptSection;
                // 計上拠点コード（複数指定）
                ArrayList sectionList = new ArrayList(this._selectedSectionList.Values);
                this._carShipRsltListCndtn.SectionCodeList = (string[])sectionList.ToArray(typeof(string));

                // 集計方法
                this._carShipRsltListCndtn.GroupBySectionDiv = (CarShipRsltListCndtn.GroupBySectionDivState)this.uos_GroupBySectionDiv.Value;
                // 売上日
                this._carShipRsltListCndtn.SalesDateSt = this.tde_St_SalesDay.GetDateTime();
                this._carShipRsltListCndtn.SalesDateEd = this.tde_Ed_SalesDay.GetDateTime();
                // 入力日
                this._carShipRsltListCndtn.InputDateSt = this.tde_St_InputDay.GetDateTime();
                this._carShipRsltListCndtn.InputDateEd = this.tde_Ed_InputDay.GetDateTime();
                // 在庫取寄指定
                this._carShipRsltListCndtn.RsltTtlDiv = (CarShipRsltListCndtn.RsltTtlDivState)this.uos_RsltTtlDiv.Value;
                // 品番出力
                this._carShipRsltListCndtn.GoodsNoPrint = (CarShipRsltListCndtn.GoodsNoPrintState)this.uos_GoodsNoPrint.Value;
                // 原価・粗利出力
                this._carShipRsltListCndtn.CostGrossPrint = (CarShipRsltListCndtn.CostGrossPrintState)this.uos_CostGrossPrint.Value;
                // 改頁
                this._carShipRsltListCndtn.NewPageDiv = (CarShipRsltListCndtn.NewPageDivState)this.uos_NewPageDiv.Value;
                // 明細単位
                this._carShipRsltListCndtn.DetailDataValue = (CarShipRsltListCndtn.DetailDataValueState)this.tComboEditor_Detail.Value;
                // 得意先
                this._carShipRsltListCndtn.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
                this._carShipRsltListCndtn.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
                // 管理番号
                this._carShipRsltListCndtn.CarMngCodeSt = this.tEdit_CarMngCode_St.Text;
                this._carShipRsltListCndtn.CarMngCodeEd = this.tEdit_CarMngCode_Ed.Text;
                // グループコード
                this._carShipRsltListCndtn.BLGroupCodeSt = this.tNedit_BLGloupCode_St.GetInt();
                this._carShipRsltListCndtn.BLGroupCodeEd = this.tNedit_BLGloupCode_Ed.GetInt();
                // ＢＬコード
                this._carShipRsltListCndtn.BLGoodsCodeSt = this.tNedit_BLGoodsCode_St.GetInt();
                this._carShipRsltListCndtn.BLGoodsCodeEd = this.tNedit_BLGoodsCode_Ed.GetInt();
                // 品番
                this._carShipRsltListCndtn.GoodsNoSt = this.tEdit_GoodsNo_St.Text;
                this._carShipRsltListCndtn.GoodsNoEd = this.tEdit_GoodsNo_Ed.Text;
                // 車輌備考
                this._carShipRsltListCndtn.SlipNoteCar = this.tEdit_CarSlipNote.Text;
                // 車輌抽出区分
                this._carShipRsltListCndtn.CarOutDiv = (CarShipRsltListCndtn.CarOutDivState)this.tComboEditor_ModelFullNameFuzzy.Value;

            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion
        #endregion ◆ 印刷前処理

        #region ◎ エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.09.15</br>
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

        #endregion ■ Private Method

        # region Control Events

        /// <summary>
        /// PMSYA02000UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        private void PMSYA02000UA_Load(object sender, EventArgs e)
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
        # endregion

        # region ガイド イベント
        /// <summary>
        /// エクスプローラーバー グループ縮小 イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note       : グループが縮小される前に発生します。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "ReportPublishGroup") ||
                (e.Group.Key == "PrintConditionGroup"))
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
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "ReportPublishGroup") ||
                (e.Group.Key == "PrintConditionGroup"))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 得意先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_St_CustomerGuide_Click(object sender, EventArgs e)
        {
            _customerGuideOK = false;

            // 押下されたボタンを退避
            if (sender is UltraButton)
            {
                _customerGuideSender = (UltraButton)sender;
            }

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.customerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (_customerGuideOK)
            {
                if (sender == ub_St_CustomerGuide)
                {
                    this.tNedit_CustomerCode_Ed.Focus();
                }
                else
                {
                    this.tEdit_CarMngCode_St.Focus();
                }
            }
        }

        /// <summary>
        /// 得意先ガイド選択イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="customerSearchRet"></param>
        void customerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
            if (status != 0) return;

            if (_customerGuideSender == this.ub_St_CustomerGuide)
            {
                this.tNedit_CustomerCode_St.SetInt(customerInfo.CustomerCode);
            }
            else
            {
                this.tNedit_CustomerCode_Ed.SetInt(customerInfo.CustomerCode);
            }
            _customerGuideOK = true;

        }

        /// <summary>
        /// グループコードガイドボタンクリックイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_BlGroupCodeGuide_Click(object sender, EventArgs e)
        {
            BLGroupU blGroupU;

            if (this._blGroupUAcs == null)
            {
                this._blGroupUAcs = new BLGroupUAcs();
            }

            int status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tNedit_BLGloupCode_St.SetInt(blGroupU.BLGroupCode);
                this.tNedit_BLGloupCode_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_BLGloupCode_Ed.SetInt(blGroupU.BLGroupCode);
                this.tNedit_BLGoodsCode_St.Focus();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// ＢＬコードガイドボタンクリックイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_BLGoodsCodeGuide_Click(object sender, EventArgs e)
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
                this.tEdit_GoodsNo_St.Focus();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 車輌備考ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        /// <remarks>
        /// <br>Note       : 車輌備考ガイド画面を表示します。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        private void ub_SlipNoteCar_Click(object sender, EventArgs e)
        {
            NoteGuidAcs noteGuideAcs = new NoteGuidAcs();
            NoteGuidBd noteGuideBd;

            int status = noteGuideAcs.ExecuteGuide(out noteGuideBd, this._enterpriseCode, CT_DIVCODE_NOTEGUIDEDIVCD_4);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_CarSlipNote.Text = noteGuideBd.NoteGuideName;
                // 次フォーカス
                this.tComboEditor_ModelFullNameFuzzy.Focus();
              
            }
        }

        /// <summary>
        /// 管理番号ガイド イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 管理番号ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 張莉莉</br>
        /// <br>Date        : 2009.09.15</br>
        /// </remarks>
        private void ub_St_CarMngNoGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CarMangInputExtraInfo selectedInfo = new CarMangInputExtraInfo();
                CarMngGuideParamInfo paramInfo = new CarMngGuideParamInfo();
                paramInfo.EnterpriseCode = this._enterpriseCode;
                // 「新規登録」行表示なし
                paramInfo.IsDispNewRow = false;
                // 得意先表示あり
                paramInfo.IsDispCustomerInfo = true;
                // 得意先コード絞り込み無し
                paramInfo.IsCheckCustomerCode = false;
                // 管理番号絞り込み無し
                paramInfo.IsCheckCarMngCode = false;
                paramInfo.IsGuideClick = true;

                int status = this._carMngInputAcs.ExecuteGuid(paramInfo, out selectedInfo);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    if (selectedInfo.CarMngCode != "新規登録")
                    {
                        this.tEdit_CarMngCode_St.Text = selectedInfo.CarMngCode;
                        this.tEdit_CarMngCode_Ed.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 管理番号ガイド イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 管理番号ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 張莉莉</br>
        /// <br>Date        : 2009.09.15</br>
        /// </remarks>
        private void ub_Ed_CarMngNoGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CarMangInputExtraInfo selectedInfo = new CarMangInputExtraInfo();
                CarMngGuideParamInfo paramInfo = new CarMngGuideParamInfo();
                paramInfo.EnterpriseCode = this._enterpriseCode;
                // 「新規登録」行表示なし
                paramInfo.IsDispNewRow = false;
                // 得意先表示あり
                paramInfo.IsDispCustomerInfo = true;
                // 得意先コード絞り込み無し
                paramInfo.IsCheckCustomerCode = false;
                // 管理番号絞り込み無し
                paramInfo.IsCheckCarMngCode = false;
                paramInfo.IsGuideClick = true;

                int status = this._carMngInputAcs.ExecuteGuid(paramInfo, out selectedInfo);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    if (selectedInfo.CarMngCode != "新規登録")
                    {
                        this.tEdit_CarMngCode_Ed.Text = selectedInfo.CarMngCode;
                        this.tNedit_BLGloupCode_St.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 集計方法　変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uos_GroupBySectionDiv_ValueChanged(object sender, EventArgs e)
        {
            // 実績表
            if((int)this.uos_GroupBySectionDiv.Value == 0)
            {
                this.tComboEditor_Detail.Enabled = true;
            }
            // リスト
            else if ((int)this.uos_GroupBySectionDiv.Value == 1)
            {
                this.tComboEditor_Detail.Enabled = false;
                this.tComboEditor_Detail.Value = 0;
            }
        }

        /// <summary>
        /// 発行タイプ　変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_Detail_ValueChanged(object sender, EventArgs e)
        {
            if ((int)this.tComboEditor_Detail.SelectedItem.DataValue == 0)
            {
                // 品番出力
                this.uos_GoodsNoPrint.Enabled = true;
                this.uos_GoodsNoPrint.Value = 1;
            }
            else
            {
                // 品番出力
                this.uos_GoodsNoPrint.Enabled = false;
                this.uos_GoodsNoPrint.Value = 0;
            }

        }

        /// <summary>
        /// フォーカスコントロールイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : フォーカスコント時に発生します。</br>
        /// <br>Programmer  : 張莉莉</br>
        /// <br>Date        : 2009.09.15</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }
            string str = null;
            if (!e.ShiftKey)
            {
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    switch (e.PrevCtrl.Name)
                    {
                        case "tNedit_CustomerCode_St":
                            {
                                if (0 == this.tNedit_CustomerCode_St.GetInt())
                                {
                                    this.tNedit_CustomerCode_St.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_CustomerCode_Ed;
                                break;
                            }
                        case "tNedit_CustomerCode_Ed":
                            {
                                if (0 == this.tNedit_CustomerCode_Ed.GetInt())
                                {
                                    this.tNedit_CustomerCode_Ed.Text = string.Empty;
                                }
                                e.NextCtrl = this.tEdit_CarMngCode_St;
                                break;
                            }
                        case "tEdit_CarMngCode_St":
                            {
                                str = this.tEdit_CarMngCode_St.Text;
                                if (str.Length != Encoding.Default.GetByteCount(str))
                                {
                                    this.tEdit_CarMngCode_St.Text = string.Empty;
                                }
                                e.NextCtrl = this.tEdit_CarMngCode_Ed;
                                break;
                            }
                        case "tEdit_CarMngCode_Ed":
                            {
                                str = this.tEdit_CarMngCode_Ed.Text;
                                if (str.Length != Encoding.Default.GetByteCount(str))
                                {
                                    this.tEdit_CarMngCode_Ed.Text = string.Empty;
                                }

                                e.NextCtrl = this.tNedit_BLGloupCode_St;
                                break;
                            }
                        case "tNedit_BLGloupCode_St":
                            {
                                if (0 == this.tNedit_BLGloupCode_St.GetInt())
                                {
                                    this.tNedit_BLGloupCode_St.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                                break;
                            }
                        case "tNedit_BLGloupCode_Ed":
                            {
                                if (0 == this.tNedit_BLGloupCode_Ed.GetInt())
                                {
                                    this.tNedit_BLGloupCode_Ed.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_BLGoodsCode_St;
                                break;
                            }
                        case "tNedit_BLGoodsCode_St":
                            {
                                if (0 == this.tNedit_BLGoodsCode_St.GetInt())
                                {
                                    this.tNedit_BLGoodsCode_St.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                                break;
                            }
                        case "tNedit_BLGoodsCode_Ed":
                            {
                                if (0 == this.tNedit_BLGoodsCode_Ed.GetInt())
                                {
                                    this.tNedit_BLGoodsCode_Ed.Text = string.Empty;
                                }
                                e.NextCtrl = this.tEdit_GoodsNo_St;
                                break;
                            }
                        case "tEdit_GoodsNo_St":
                            {
                                str = this.tEdit_GoodsNo_St.Text;
                                if (str.Length != Encoding.Default.GetByteCount(str))
                                {
                                    this.tEdit_GoodsNo_St.Text = string.Empty;
                                }
                                e.NextCtrl = this.tEdit_GoodsNo_Ed;
                                break;
                            }
                        case "tEdit_GoodsNo_Ed":
                            {
                                str = this.tEdit_GoodsNo_Ed.Text;
                                if (str.Length != Encoding.Default.GetByteCount(str))
                                {
                                    this.tEdit_GoodsNo_Ed.Text = string.Empty;
                                }
                                e.NextCtrl = this.tEdit_CarSlipNote;
                                break;
                            }
                        case "tEdit_CarSlipNote":
                            {
                                e.NextCtrl = this.tComboEditor_ModelFullNameFuzzy;
                                break;
                            }
                    }
                }
            }
            else
            {
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    switch (e.PrevCtrl.Name)
                    {
                        case "tNedit_CustomerCode_St":
                            {
                                if (0 == this.tNedit_CustomerCode_St.GetInt())
                                {
                                    this.tNedit_CustomerCode_St.Text = string.Empty;
                                }
                                e.NextCtrl = this.tComboEditor_Detail;
                                break;
                            }
                        case "tNedit_CustomerCode_Ed":
                            {
                                if (0 == this.tNedit_CustomerCode_Ed.GetInt())
                                {
                                    this.tNedit_CustomerCode_Ed.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_CustomerCode_St;
                                break;
                            }
                        case "tEdit_CarMngCode_St":
                            {
                                str = this.tEdit_CarMngCode_St.Text;
                                if (str.Length != Encoding.Default.GetByteCount(str))
                                {
                                    this.tEdit_CarMngCode_St.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_CustomerCode_Ed;
                                break;
                            }
                        case "tEdit_CarMngCode_Ed":
                            {
                                str = this.tEdit_CarMngCode_Ed.Text;
                                if (str.Length != Encoding.Default.GetByteCount(str))
                                {
                                    this.tEdit_CarMngCode_Ed.Text = string.Empty;
                                }

                                e.NextCtrl = this.tEdit_CarMngCode_St;
                                break;
                            }
                        case "tNedit_BLGloupCode_St":
                            {
                                if (0 == this.tNedit_BLGloupCode_St.GetInt())
                                {
                                    this.tNedit_BLGloupCode_St.Text = string.Empty;
                                }
                                e.NextCtrl = this.tEdit_CarMngCode_Ed;
                                break;
                            }
                        case "tNedit_BLGloupCode_Ed":
                            {
                                if (0 == this.tNedit_BLGloupCode_Ed.GetInt())
                                {
                                    this.tNedit_BLGloupCode_Ed.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_BLGloupCode_St;
                                break;
                            }
                        case "tNedit_BLGoodsCode_St":
                            {
                                if (0 == this.tNedit_BLGoodsCode_St.GetInt())
                                {
                                    this.tNedit_BLGoodsCode_St.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                                break;
                            }
                        case "tNedit_BLGoodsCode_Ed":
                            {
                                if (0 == this.tNedit_BLGoodsCode_Ed.GetInt())
                                {
                                    this.tNedit_BLGoodsCode_Ed.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_BLGoodsCode_St;
                                break;
                            }
                        case "tEdit_GoodsNo_St":
                            {
                                str = this.tEdit_GoodsNo_St.Text;
                                if (str.Length != Encoding.Default.GetByteCount(str))
                                {
                                    this.tEdit_GoodsNo_St.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                                break;
                            }
                        case "tEdit_GoodsNo_Ed":
                            {
                                str = this.tEdit_GoodsNo_Ed.Text;
                                if (str.Length != Encoding.Default.GetByteCount(str))
                                {
                                    this.tEdit_GoodsNo_Ed.Text = string.Empty;
                                }
                                e.NextCtrl = this.tEdit_GoodsNo_St;
                                break;
                            }
                        case "tEdit_CarSlipNote":
                            {
                                e.NextCtrl = this.tEdit_GoodsNo_Ed;
                                break;
                            }
                        case "uos_GroupBySectionDiv":
                            {
                                e.NextCtrl = this.tComboEditor_ModelFullNameFuzzy;
                                break;
                            }
                        case "tComboEditor_ModelFullNameFuzzy":
                            {
                                e.NextCtrl = this.tEdit_CarSlipNote;
                                break;
                            }
                    }
                }
            }
            
        }


        # endregion
        
    }
}
