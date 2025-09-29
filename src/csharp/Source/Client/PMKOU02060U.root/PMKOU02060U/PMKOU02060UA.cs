//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入売上実績表
// プログラム概要   : 仕入売上実績表帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009/05/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 孫東響
// 修 正 日  2013/04/08  修正内容 : 2013/05/15配信分
//                                  Redmine#34806 メニュー起動直後、画面を閉じるエラーが発生
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 孫東響
// 修 正 日  2013/05/03  修正内容 : 2013/05/15配信分
//                                  Redmine#34806 #31初期化前に終了した場合画面の条件を保存しない
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using System.IO;
using Broadleaf.Library.Text;
using System.Net.NetworkInformation;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// 仕入売上実績表フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入売上実績表フォームクラスのインスタンスの作成を行う。</br>
    /// <br>Programmer : 汪千来</br>
    /// <br>Date       : 2009.05.11</br>
    /// </remarks>
    public partial class PMKOU02060UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {

        #region ■ Constructor

        /// <summary>
        /// 仕入売上実績表UIクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入売上実績表UIクラスの作成を行う。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.11</br>
        /// <br></br>
        /// </remarks>
        public PMKOU02060UA()
        {
            //初期化
            InitializeComponent();

            //エラーチェック
            hasCheckError = false;

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            //日付取得部品
            this._dateGet = DateGetAcs.GetInstance();

            // 拠点用のHashtable作成
            this._selectedSectionList = new Hashtable();

            //ログイン担当者の拠点
            _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            //仕入先アクセス
            this._supplierAcs = new SupplierAcs();

            // ログイン担当者
            this._loginEmployee = LoginInfoAcquisition.Employee.Clone();

            //拠点情報設定アクセスクラス
            this._mSecInfoAcs = new SecInfoAcs();

            // UI設定保存コンポーネント設定
            this.SetUIMemInputControl();

        }
        #endregion ■ Constructor

        #region ■ Private Member

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

        //--IPrintConditionInpTypeSelectedSectionのプロパティ用変数 -------------------
        // 計上拠点選択表示取得プロパティ
        private bool _visibledSelectAddUpCd = false;
        // 拠点オプション有無
        private bool _isOptSection = false;
        // 本社機能有無
        private bool _isMainOfficeFunc = false;

        #endregion ◆ Interface member

        #region
        // 企業コード
        private string _enterpriseCode = string.Empty;

        // 売上全体設定マスタ
        private SalesTtlStAcs _salesTtlStAcs;
        private SalesTtlSt _salesTtlSt;

        //拠点アクセス
        private SecInfoAcs _mSecInfoAcs = null;

        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 選択拠点リスト
        private Hashtable _selectedSectionList = new Hashtable();

        //日付取得部品
        private DateGetAcs _dateGet;

        //仕入先アクセス
        SupplierAcs _supplierAcs;

        //ログイン担当者拠点コード
        private string _loginSectionCode = string.Empty;

        //ログイン担当者
        private Employee _loginEmployee = null;

        //エラーチェック
        private bool hasCheckError = false;

        private Control _prevControl = null;

        #endregion

        #endregion ■ Private Member

        #region ■ Private Const
        #region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
        // クラスID
        private const string ct_ClassID = "PMKOU02060UA";
        // プログラムID
        private const string ct_PGID = "PMKOU02060U";
        // 帳票名称
        private const string ct_PrintName = "仕入売上実績表";
        // 帳票キー	
        private const string ct_PrintKey = "c1521de4-9268-48d3-af87-ea5ad569213b";
        //全社
        private const string ct_All = "00";

        // ExporerBar グループ名称
        private const string ct_ExBarGroupNm_CustomerConditionGroup = "CustomerConditionGroup";
        private const string ct_ExBarGroupNm_ExtraConditionCodeGroup = "ExtraConditionCodeGroup";

        //対象年月　設定チェック
        private const string ct_MustInputError = "を設定してください。";

        //エラー条件メッセージ
        const string ct_InputError = "の入力が不正です。";
        const string ct_NoInput = "を入力して下さい。";
        const string ct_RangeError = "の範囲に誤りがあります。";
        const string ct_RangeOverError = "は３ヶ月の範囲内で入力してください。";

        #endregion ◆ Interface member

        #endregion

        #region ■ IPrintConditionInpTypePdfCareer メンバ
        #region ◆ Public Property

        /// <summary> 帳票キー</summary>
        /// <value>PrintKey</value>               
        /// <remarks>帳票キー取得プロパティ </remarks>  
        public string PrintKey
        {
            get { return ct_PrintKey; }
        }

        /// <summary> 帳票名</summary>
        /// <value>PrintName</value>               
        /// <remarks>帳票名取得ププロパティ </remarks>  
        public string PrintName
        {
            get { return ct_PrintName; }
        }

        /// <summary> 計上拠点選択表示</summary>
        /// <value>VisibledSelectAddUpCd</value>               
        /// <remarks>計上拠点選択表示取得又はセットププロパティ</remarks>  
        public bool VisibledSelectAddUpCd
        {
            get { return _visibledSelectAddUpCd; }
            set { _visibledSelectAddUpCd = value; }
        }

        /// <summary> 拠点オプションプ</summary>
        /// <value>IsOptSection</value>               
        /// <remarks>拠点オプションプ取得又はセットププロパティ</remarks>  
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// <summary> 本社機能</summary>
        /// <value>IsMainOfficeFunc</value>               
        /// <remarks>本社機能取得又はセットプロパティ</remarks>  
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }

        #endregion ◆ Public Method
        #endregion ■ IPrintConditionInpTypePdfCareer メンバ

        #region ■ IPrintConditionInpType メンバ

        #region ◆ Public Event
        /// <summary> 親ツールバー設定イベント </summary>
        /// <remarks>親ツールバー設定イベントを実行します。</remarks>   
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion ◆ Public Event

        #region ◆ Public Property
        /// <summary> 抽出ボタン状態</summary>
        /// <value>CanExtract</value>               
        /// <remarks>抽出ボタン状態取得プロパティ </remarks> 
        public bool CanExtract
        {
            get { return this._canExtract; }
        }

        /// <summary> PDF出力ボタン状態</summary>
        /// <value>CanPdf</value>               
        /// <remarks>PDF出力ボタン状態取得プロパティ </remarks> 
        public bool CanPdf
        {
            get { return this._canPdf; }
        }

        /// <summary> 印刷ボタン状態</summary>
        /// <value>CanPrint</value>               
        /// <remarks>印刷ボタン状態取得プロパティ </remarks> 
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// <summary> 抽出ボタン表示有無プロパティ</summary>
        /// <value>VisibledExtractButton</value>               
        /// <remarks>抽出ボタン表示有無取得プロパティ </remarks> 
        public bool VisibledExtractButton
        {
            get { return this._visibledExtractButton; }
        }

        /// <summary> PDF出力ボタン表示有無</summary>
        /// <value>CanPrint</value>               
        /// <remarks>PDF出力ボタン表示有無プロパティ取得プロパティ </remarks> 
        public bool VisibledPdfButton
        {
            get { return this._visibledPdfButton; }
        }

        /// <summary> 印刷ボタン表示</summary>
        /// <value>VisibledPrintButton</value>               
        /// <remarks>印刷ボタン表示取得プロパティ </remarks> 
        public bool VisibledPrintButton
        {
            get { return this._visibledPrintButton; }
        }

        #endregion ◆ Public Property

        #region ◆ 画面設定保存
        /// <summary>
        /// UIMemInputの保存項目設定
        /// </summary>
        /// <remarks>
        /// <br>Note		: UIMemInputの保存項目設定を行う。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // 入力保存項目をセット
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.StockDateStRF_tDateEdit);
            saveCtrAry.Add(this.StockDateEdRF_tDateEdit);
            saveCtrAry.Add(this.InputDayStRF_tDateEdit);
            saveCtrAry.Add(this.InputDayEdRF_tDateEdit);

            saveCtrAry.Add(this.tComboEditor_NewPageType);
            saveCtrAry.Add(this.tNedit_SupplierCd_St);
            saveCtrAry.Add(this.tNedit_SupplierCd_Ed);

            saveCtrAry.Add(this.tComboEditor_WayToOrderType);
            saveCtrAry.Add(this.tComboEditor_StockOrderDivCdType);
            saveCtrAry.Add(this.tComboEditor_SalesType);
            saveCtrAry.Add(this.tComboEditor_StockUnitChngDivType);


            saveCtrAry.Add(this.GrsProfitCheckLower_tNedit);
            saveCtrAry.Add(this.GrossMarginSt_Nedit);
            saveCtrAry.Add(this.GrossMargin2Ed_Nedit);
            saveCtrAry.Add(this.GrossMargin3Ed_Nedit);
            saveCtrAry.Add(this.GrsProfitCheckBest_tNedit);
            saveCtrAry.Add(this.GrsProfitCheckUpper_tNedit);
            saveCtrAry.Add(this.GrossMargin1Mark_tEdit);
            saveCtrAry.Add(this.GrossMargin2Mark_tEdit);
            saveCtrAry.Add(this.GrossMargin3Mark_tEdit);
            saveCtrAry.Add(this.GrossMargin4Mark_tEdit);

            this.uiMemInput1.TargetControls = saveCtrAry;
            this.uiMemInput1.ReadOnLoad = false;
        }
        #endregion

        #region ◎ 抽出処理
        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>0( 固定 )</returns>
        /// <remarks>
        /// <br>Note		: 抽出処理を行う。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
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
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            // オフライン状態チェック	
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    "仕入売上実績表データ読み込みに失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return -1;
            }

            SFCMN06001U printDialog = new SFCMN06001U();		// 帳票選択ガイド
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// 印刷情報パラメータ

            // 企業コードをセット
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// 起動PGID

            // PDF出力履歴用
            printInfo.key = ct_PrintKey;
            printInfo.prpnm = ct_PrintName;
            printInfo.PrintPaperSetCd = 0;

            // 抽出条件クラス
            StockSalesResultInfoMainCndtn extrInfo = new StockSalesResultInfoMainCndtn();

            // 画面→抽出条件クラス
            int status = this.SetExtraInfoFromScreen(extrInfo);
            if (status != 0)
            {
                return -1;
            }
            // 抽出条件の設定
            printInfo.jyoken = extrInfo;
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

        #region ◎ 画面表示処理
        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <param name="parameter">起動パラメータ</param>
        /// <remarks>
        /// <br>Note		: 画面表示を行う。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this.Show();

            // UI設定保存コンポーネント設定
            this.uiMemInput1.OptionCode = "0";

            return;
        }

        #endregion

        #region ◎ 印刷前確認処理
        /// <summary>
        /// 印刷前確認処理
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: 印刷前確認処理を行う。(入力チェックなど)</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            if (this._prevControl != null)
            {
                hasCheckError = false;
                ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tArrowKeyControl1_ChangeFocus(this, e);
            }

            bool status = true;

            if (hasCheckError)
            {
                status = false;
                return status;
            }


            string message;
            Control errControl = null;

            // 画面入力条件チェック
            bool result = this.ScreenInputCheck(out message, ref errControl);
            if (!result)
            {
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, message, 0);
                if (errControl != null) errControl.Focus();
            }
            return result;
        }

        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_OrderDataCreateDate"></param>
        /// <param name="tde_Ed_OrderDataCreateDate"></param>
        /// <param name="mode"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: 日付チェック処理呼び出しを行う。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate, bool mode, int range)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, range, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, mode, false);

            if (tde_St_OrderDataCreateDate.Name == "InputDayStRF_tDateEdit")
            {
                if (cdrResult == DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver)
                {
                    cdrResult = DateGetAcs.CheckDateRangeResult.OK;
                }
            }

            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// 入力日付チェック処理呼び出し(範囲チェックなし、未入力OK)
        /// </summary>
        /// <param name="cdrResult">チェック結果</param>
        /// <param name="tde_St_AddUpADate">入力日（開始）</param>
        /// <param name="tde_Ed_AddUpADate">入力日（終了）</param>
        /// <param name="mode">モード</param>
        /// <param name="range">範囲</param>
        /// <returns><c>true</c> :OK<br/><c>false</c>:NG</returns>
        /// <remarks>
        /// <br>Note		: 入力日付チェック処理呼び出し(範囲チェックなし、未入力OK)を行う。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private bool CallCheckInputDateRange(
            out DateGetAcs.CheckDateRangeResult cdrResult,
            ref TDateEdit tde_St_AddUpADate,
            ref TDateEdit tde_Ed_AddUpADate,
            bool mode,
            int range
        )
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref tde_St_AddUpADate, ref tde_Ed_AddUpADate, true);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// 画面入力チェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の入力チェックを行います。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private bool ScreenInputCheck(out string message, ref Control errControl)
        {
            message = "";
            bool result = false;
            errControl = null;

            DateGetAcs.CheckDateRangeResult cdrResult;

            // 仕入日（開始・終了）
            //if ((this.StockDateStRF_tDateEdit.LongDate != 0) ||
            //    (this.StockDateEdRF_tDateEdit.LongDate != 0))
            //{
            if (CallCheckInputDateRange(out cdrResult, ref StockDateStRF_tDateEdit, ref StockDateEdRF_tDateEdit, false, 3) == false)   // ADD 2008/07/16
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        //{
                        //    message = "仕入日を入力して下さい。";
                        //    errControl = this.StockDateStRF_tDateEdit;
                        //}
                        //break;
                        return true;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            message = "仕入日の入力が不正です。";
                            errControl = this.StockDateStRF_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        //{
                        //    message = "仕入日を入力して下さい。";
                        //    errControl = this.StockDateEdRF_tDateEdit;
                        //}
                        //break;
                        return true;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            message = "仕入日の入力が不正です。";
                            errControl = this.StockDateEdRF_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            //message = "日付の範囲指定に誤りがあります";
                            message = "仕入日の範囲に誤りがあります。";
                            errControl = this.StockDateStRF_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        //{
                        //    //message = "日付は３ヶ月の範囲で入力して下さい";
                        //    message = "仕入日は３ヶ月の範囲で入力してください。";
                        //    errControl = this.StockDateStRF_tDateEdit;
                        //}
                        //break;
                        return true;
                }
                return result;
            }
            //}
            //else
            //{
            //    // 開始日と終了日の両方未入力
            //    message = "仕入日を入力して下さい。";
            //    errControl = this.StockDateStRF_tDateEdit;
            //    return result;
            //}


            // 入力日付（開始～終了）
            //if (CallCheckInputDateRange(out cdrResult, ref InputDayStRF_tDateEdit, ref InputDayEdRF_tDateEdit, false, 3) == false)   
            if (CallCheckInputDateRange(out cdrResult, ref InputDayStRF_tDateEdit, ref InputDayEdRF_tDateEdit, false, 3) == false)   
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        return true;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            message = string.Format("入力日{0}", ct_InputError);
                            errControl = this.InputDayStRF_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        return true;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            message = string.Format("入力日{0}", ct_InputError);
                            errControl = this.InputDayEdRF_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            message = string.Format("入力日{0}", ct_RangeError);
                            errControl = this.InputDayStRF_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        //{
                        //    message = string.Format("入力日{0}", ct_RangeOverError);
                        //    errControl = this.InputDayStRF_tDateEdit;
                        //}
                        //break;
                        return true;
                }
                //result = false;
                //return result;
                return result;
            }


            // 仕入先範囲チェック
            if ((this.tNedit_SupplierCd_Ed.GetInt() != 0) &&
                (this.tNedit_SupplierCd_St.GetInt()) > (this.tNedit_SupplierCd_Ed.GetInt()))
            {
                message = "仕入先の範囲に誤りがあります。";
                errControl = this.tNedit_SupplierCd_St;
                return result;
            }


            // 粗利チェックの入力範囲 空白だとエラー表示
            if (this.GrsProfitCheckLower_tNedit.Text == "")
            {
                message = "粗利チェックを入力して下さい。";
                errControl = this.GrsProfitCheckLower_tNedit;
                return result;
            }

            // 粗利チェックの適正と上限のチェックを変更 
            if ((this.GrsProfitCheckBest_tNedit.Text == "") || (double.Parse(this.GrsProfitCheckBest_tNedit.Text) == 0.0))
            {
                message = "粗利チェックを入力して下さい。";
                errControl = this.GrsProfitCheckBest_tNedit;
                return result;
            }


            if ((this.GrsProfitCheckUpper_tNedit.Text == "") || (double.Parse(this.GrsProfitCheckUpper_tNedit.Text) == 0.0))
            {
                message = "粗利チェックを入力して下さい。";
                errControl = this.GrsProfitCheckUpper_tNedit;
                return result;
            }

            // 粗利チェックの範囲が同数値の場合エラーとする 
            if ((double.Parse(this.GrsProfitCheckBest_tNedit.Text) != 0.0) &&
                (double.Parse(this.GrsProfitCheckLower_tNedit.Text).CompareTo(double.Parse(this.GrsProfitCheckBest_tNedit.Text)) >= 0))
            {
                message = "粗利チェックの範囲に誤りがあります。";
                errControl = this.GrsProfitCheckLower_tNedit;
                return result;
            }

            // 上限より適正値が大きいとエラー表示
            if ((double.Parse(this.GrsProfitCheckUpper_tNedit.Text) != 0.0) &&
                (double.Parse(this.GrsProfitCheckBest_tNedit.Text).CompareTo(double.Parse(this.GrsProfitCheckUpper_tNedit.Text)) >= 0))
            {
                message = "粗利チェックの範囲に誤りがあります。";
                errControl = this.GrsProfitCheckBest_tNedit;
                return result;
            }

            return true;
        }

        #endregion
        #endregion

        #region ■ IPrintConditionInpTypeSelectedSection メンバ
        #region ◎ 拠点選択処理
        /// <summary>
        /// 拠点選択処理
        /// </summary>
        /// <param name="sectionCode">選択拠点コード</param>
        /// <param name="checkState">選択状態</param>
        /// <remarks>
        /// <br>Note		: 拠点選択処理を行う。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.11</br>
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

        #region ◎ 初期選択計上拠点設定処理（実装の必要がない）
        /// <summary>
        /// 初期選択計上拠点設定処理
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: 実装の必要がない</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        public void InitSelectAddUpCd(int addUpCd)
        {
            // 計上拠点選択がないので、実装の必要がない
        }
        #endregion

        #region ◎ 初期選択拠点設定処理
        /// <summary>
        /// 初期選択拠点設定処理
        /// </summary>
        /// <param name="sectionCodeLst">選択拠点コードリスト</param>
        /// <remarks>
        /// <br>Note		: 拠点リストの初期化を行う。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.11</br>
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
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        public bool InitVisibleCheckSection(bool isDefaultState)
        {
            return isDefaultState;
        }
        #endregion

        #region ◎ 計上拠点選択処理( 実装の必要がない )
        /// <summary>
        /// 計上拠点選択処理( 未実装 )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: 実装の必要がない</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        public void SelectedAddUpCd(int addUpCd)
        {
            // 計上拠点選択がないので実装の必要がない
        }
        #endregion
        #endregion

        #region ■ Control Event
        #region ◆ PMKOU02060UA
        #region ◎ PMKOU02060UA_Load Event
        /// <summary>
        /// PMKOU02060UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生するを行う。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private void PMKOU02060UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // 拠点オプション有無チェック
            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0)
            {
                _isOptSection = true;
            }
            else
            {
                _isOptSection = false;
            }

            // 売上全体設定マスタから粗利率と粗利マークを取得する
            this._salesTtlStAcs = new SalesTtlStAcs();
            this._salesTtlSt = new SalesTtlSt();
            int status = 0;
            ArrayList retList = null;

            // 拠点コード"0"のレコードを取得 
            status = this._salesTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            if (status == 0)
            {
                foreach (SalesTtlSt wkSalesTtlSt in retList)
                {
                    if ((wkSalesTtlSt.SectionCode.Trim().Equals(this._loginSectionCode.TrimEnd())) 
                        && (0==wkSalesTtlSt.LogicalDeleteCode))
                    {
                        this._salesTtlSt = wkSalesTtlSt.Clone();
                        break;
                    }

                    if ((wkSalesTtlSt.SectionCode.Trim().Equals(ct_All))
                        &&(0==wkSalesTtlSt.LogicalDeleteCode))
                    {
                        this._salesTtlSt = wkSalesTtlSt.Clone();
                    }
                }
            }

            // 初期化タイマー起動
            Initialize_Timer.Enabled = true;

            // 画面イメージ統一
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);
        }
        #endregion
        #endregion ◆ PMKOU02060UA

        #region ◆ Initialize_Timer
        #region ◎ Tick Event
        /// <summary>
        /// Tick イベント                                               
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>                             
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : timer tick時に発生しますを行う。</br>                  
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private void Initialize_Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string errMsg = string.Empty;

                this.Initialize_Timer.Enabled = false;

                // 画面初期表示
                int status = this.InitialScreenSetting(out errMsg);

                // メインフレームにツールバー設定通知
                if (ParentToolbarSettingEvent != null) this.ParentToolbarSettingEvent(this);
            }
            finally
            {
                // 初期フォーカス設定
                this.StockDateStRF_tDateEdit.Focus();
                _prevControl = this.StockDateStRF_tDateEdit;
                this.Cursor = Cursors.Default;
            }
        }
        #endregion
        #endregion ◆ Initialize_Timer

        /// <summary>
        /// 初期画面設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初期画面設定を行います。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private int InitialScreenSetting(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                int nowLongDate = TDateTime.DateTimeToLongDate(DateTime.Now);

                // 仕入日
                this.StockDateStRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
                this.StockDateEdRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
                this.StockDateStRF_tDateEdit.SetLongDate(nowLongDate);
                this.StockDateEdRF_tDateEdit.SetLongDate(nowLongDate);

                //改頁
                tComboEditor_NewPageType.SelectedIndex = 0;
                //出力指定
                this.tComboEditor_WayToOrderType.SelectedIndex = 0;
                //在取取寄指定
                this.tComboEditor_StockOrderDivCdType.SelectedIndex = 0;
                //売上伝票指定
                this.tComboEditor_SalesType.SelectedIndex = 0;
                //原価指定
                this.tComboEditor_StockUnitChngDivType.SelectedIndex = 0;

                // 粗利チェックの初期値(売上全体設定マスタから読み込む)
                //粗利率の下限値
                this.GrsProfitCheckLower_tNedit.SetValue(this._salesTtlSt.GrsProfitCheckLower);

                //粗利率の適正値
                this.GrsProfitCheckBest_tNedit.SetValue(this._salesTtlSt.GrsProfitCheckBest);

                //粗利率の上限値
                this.GrsProfitCheckUpper_tNedit.SetValue(this._salesTtlSt.GrsProfitCheckUpper);

                //粗利マーク(下限値未満の記号)
                this.GrossMargin1Mark_tEdit.Text = this._salesTtlSt.GrsProfitChkLowSign.Trim();

                //粗利マーク(適正値から下限値までの記号)
                this.GrossMargin2Mark_tEdit.Text = this._salesTtlSt.GrsProfitChkBestSign.Trim();

                //粗利マーク(上限値から適正値までの記号)
                this.GrossMargin3Mark_tEdit.Text = this._salesTtlSt.GrsProfitChkUprSign.Trim();

                //粗利マーク(粗利チェックの上限値オーバーの記号)
                this.GrossMargin4Mark_tEdit.Text = this._salesTtlSt.GrsProfitChkMaxSign.Trim();

                // ガイドボタンのアイコン設定
                this.SetIconImage(this.SupplierCdSt_GuideBtn, Size16_Index.STAR1);
                this.SetIconImage(this.SupplierCdEd_GuideBtn, Size16_Index.STAR1);

                // 前回表示状態が保存されていれば上書き
                this.uiMemInput1.ReadMemInput();

                //--- ADD By 孫東響 2013/05/03 For Redmine #34806 #31---->>>>>
                //初期化前に終了した場合画面の条件を保存しない
                uiMemInput1.WriteOnClose = true;
                //--- ADD By 孫東響 2013/05/03 For Redmine #34806 #31----<<<<<
            }

            catch (Exception ex)
            {

                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }


        /// <summary> 
        /// UI保存コンポーネント読込みイベント 
        /// </summary> 
        /// <param name="targetControls">コンポーネント</param> 
        /// <param name="customizeData">保存データ</param> 
        /// <remarks> 
        /// <br>Programmer : 汪千来 </br> 
        /// <br>Date       : 2009.05.11</br> 
        /// <br>改行条件チェックボックスの状態を復元する。</br> 
        /// </remarks> 
        private void uiMemInput1_CustomizeRead(Control[] targetControls, string[] customizeData)
        {
            if (customizeData.Length > 0)
            {
                this.StockDateStRF_tDateEdit.LongDate = int.Parse(customizeData[0]);
                this.StockDateEdRF_tDateEdit.LongDate = int.Parse(customizeData[1]);
                this.InputDayStRF_tDateEdit.LongDate = int.Parse(customizeData[2]);
                this.InputDayEdRF_tDateEdit.LongDate = int.Parse(customizeData[3]);
                this.tComboEditor_NewPageType.SelectedIndex = int.Parse(customizeData[4]);
                if (!"-1".Equals(customizeData[5]))
                {
                    this.tNedit_SupplierCd_St.SetInt(int.Parse(customizeData[5]));
                }
                if (!"-1".Equals(customizeData[6]))
                {
                    this.tNedit_SupplierCd_Ed.SetInt(int.Parse(customizeData[6]));
                }
                this.tComboEditor_WayToOrderType.SelectedIndex = int.Parse(customizeData[7]);
                this.tComboEditor_StockOrderDivCdType.SelectedIndex = int.Parse(customizeData[8]);
                this.tComboEditor_SalesType.SelectedIndex = int.Parse(customizeData[9]);
                this.tComboEditor_StockUnitChngDivType.SelectedIndex = int.Parse(customizeData[10]);

                this.GrsProfitCheckLower_tNedit.Text = customizeData[11];
                this.GrossMarginSt_Nedit.Text = customizeData[12];
                this.GrossMargin2Ed_Nedit.Text = customizeData[13];
                this.GrossMargin3Ed_Nedit.Text = customizeData[14];
                this.GrsProfitCheckBest_tNedit.Text = customizeData[15];
                this.GrsProfitCheckUpper_tNedit.Text = customizeData[16];
                this.GrossMargin1Mark_tEdit.Text = customizeData[17];
                this.GrossMargin2Mark_tEdit.Text = customizeData[18];
                this.GrossMargin3Mark_tEdit.Text = customizeData[19];
                this.GrossMargin4Mark_tEdit.Text = customizeData[20];


            }
        }

        /// <summary> 
        /// UI保存コンポーネント書込みイベント 
        /// </summary> 
        /// <param name="targetControls">コンポーネント</param> 
        /// <param name="customizeData">保存データ</param> 
        /// <remarks> 
        /// <br>Programmer : 汪千来</br> 
        /// <br>Date       : 2009.05.11</br> 
        /// <br>改行条件チェックボックスの状態を保存する。</br> 
        /// </remarks> 
        private void uiMemInput1_CustomizeWrite(Control[] targetControls, out string[] customizeData)
        {
            customizeData = new string[21];
            customizeData[0] = this.StockDateStRF_tDateEdit.LongDate.ToString();
            customizeData[1] = this.StockDateEdRF_tDateEdit.LongDate.ToString();
            customizeData[2] = this.InputDayStRF_tDateEdit.LongDate.ToString();
            customizeData[3] = this.InputDayEdRF_tDateEdit.LongDate.ToString();

            //customizeData[4] = Convert.ToInt32(tComboEditor_NewPageType.SelectedItem.DataValue).ToString();// DEL By 孫東響 2013/04/08 For Redmine #34806
            customizeData[4] = tComboEditor_NewPageType.SelectedIndex.ToString();// ADD By 孫東響 2013/04/08 For Redmine #34806
            if (!string.IsNullOrEmpty(this.tNedit_SupplierCd_St.Text))
            {
                customizeData[5] = this.tNedit_SupplierCd_St.GetInt().ToString();
            }
            else
            {
                customizeData[5] = "-1";
            }
            if (!string.IsNullOrEmpty(this.tNedit_SupplierCd_Ed.Text))
            {
                customizeData[6] = this.tNedit_SupplierCd_Ed.GetInt().ToString();
            }
            else
            {
                customizeData[6] = "-1";
            }

            //------------ DEL By 孫東響 2013/04/08 For Redmine #34806----------------------------------------->>>>>
            //customizeData[7] = Convert.ToInt32(tComboEditor_WayToOrderType.SelectedItem.DataValue).ToString();
            //customizeData[8] = Convert.ToInt32(tComboEditor_StockOrderDivCdType.SelectedItem.DataValue).ToString();
            //customizeData[9] = Convert.ToInt32(tComboEditor_SalesType.SelectedItem.DataValue).ToString();
            //customizeData[10] = Convert.ToInt32(tComboEditor_StockUnitChngDivType.SelectedItem.DataValue).ToString();
            //------------ DEL By 孫東響 2013/04/08 For Redmine #34806-----------------------------------------<<<<<
            //------------ ADD By 孫東響 2013/04/08 For Redmine #34806----------------------------------------->>>>>
            customizeData[7] = tComboEditor_WayToOrderType.SelectedIndex.ToString();
            customizeData[8] = tComboEditor_StockOrderDivCdType.SelectedIndex.ToString();
            customizeData[9] = tComboEditor_SalesType.SelectedIndex.ToString();
            customizeData[10] = tComboEditor_StockUnitChngDivType.SelectedIndex.ToString();
            //------------ ADD By 孫東響 2013/04/08 For Redmine #34806-----------------------------------------<<<<<

            customizeData[11] = this.GrsProfitCheckLower_tNedit.Text;
            customizeData[12] = this.GrossMarginSt_Nedit.Text;
            customizeData[13] = this.GrossMargin2Ed_Nedit.Text;
            customizeData[14] = this.GrossMargin3Ed_Nedit.Text;
            customizeData[15] = this.GrsProfitCheckBest_tNedit.Text;
            customizeData[16] = this.GrsProfitCheckUpper_tNedit.Text;
            customizeData[17] = this.GrossMargin1Mark_tEdit.Text;
            customizeData[18] = this.GrossMargin2Mark_tEdit.Text;
            customizeData[19] = this.GrossMargin3Mark_tEdit.Text;
            customizeData[20] = this.GrossMargin4Mark_tEdit.Text;
        }

        /// <summary>
        /// Control.Click イベント(SupplierCdSt_GuideBtn)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 仕入先（開始）ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private void SupplierCdSt_GuideBtn_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            Supplier supplier = new Supplier();
            status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "0");

            // 項目に展開
            if (status == 0)
            {
                this.tNedit_SupplierCd_St.SetInt(supplier.SupplierCd);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        /// <summary>
        /// Control.Click イベント(SupplierCdEd_GuideBtn)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 仕入先（終了）ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private void SupplierCdEd_GuideBtn_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            Supplier supplier = new Supplier();
            status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "0");

            // 項目に展開
            if (status == 0)
            {
                this.tNedit_SupplierCd_Ed.SetInt(supplier.SupplierCd);

                // 2008.10.02 30413 犬飼 フォーカス制御を追加 >>>>>>START
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // 2008.10.02 30413 犬飼 フォーカス制御を追加 <<<<<<END
            }
        }

        /// <summary>
        /// 粗利チェックの下限Control.ValueChanged イベント(GrsProfitCheckLower_tNedit)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 粗利チェックの下限Control.ValueChangedに発生します。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private void GrsProfitCheckLower_tNedit_ValueChanged(object sender, EventArgs e)
        {
            this.GrossMarginSt_Nedit.Text = this.GrsProfitCheckLower_tNedit.Text;
        }

        /// <summary>
        /// 粗利チェックの最適.ValueChanged イベント(GrsProfitCheckBest_tNedit)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 粗利チェックの最適.ValueChangedに発生します。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private void GrsProfitCheckBest_tNedit_ValueChanged(object sender, EventArgs e)
        {
            this.GrossMargin2Ed_Nedit.Text = this.GrsProfitCheckBest_tNedit.Text;
        }

        /// <summary>
        /// 粗利チェックの上限.ValueChanged イベント(GrsProfitCheckUpper_tNedit)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 粗利チェックの上限.ValueChangedに発生します。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private void GrsProfitCheckUpper_tNedit_ValueChanged(object sender, EventArgs e)
        {
            this.GrossMargin3Ed_Nedit.Text = this.GrsProfitCheckUpper_tNedit.Text;
        }

        /// <summary>
        /// Control.Leave イベント(GrsProfitCheckLower_tNedit)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 粗利チェックの下限値からフォーカスを失ったときに発生します。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private void GrsProfitCheckLower_tNedit_Leave(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;

            if (tNedit.Text == "")
            {
                // 空の場合は、初期値を設定
                tNedit.Text = "0.0";
            }
        }

        /// <summary>
        /// Control.Leave イベント(GrsProfitCheckBest_tNedit)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 粗利チェックの適正値からフォーカスを失ったときに発生します。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private void GrsProfitCheckBest_tNedit_Leave(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;

            if (tNedit.Text == "")
            {
                // 空の場合は、初期値を設定
                tNedit.Text = "0.0";
            }
        }

        /// <summary>
        /// Control.Leave イベント(GrsProfitCheckUpper_tNedit)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 粗利チェックの上限値からフォーカスを失ったときに発生します。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private void GrsProfitCheckUpper_tNedit_Leave(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;

            if (tNedit.Text == "")
            {
                // 空の場合は、初期値を設定
                tNedit.Text = "0.0";
            }
        }

        #region ◎ GroupCollapsing Event
        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroupが縮小される前に発生する。</br>PrintSettingGroup
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == ct_ExBarGroupNm_CustomerConditionGroup) ||
                (e.Group.Key == ct_ExBarGroupNm_ExtraConditionCodeGroup))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }
        #endregion

        #region ◎ GroupExpanding Event
        /// <summary>
        /// GroupExpanding Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroupが展開される前に発生する。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == ct_ExBarGroupNm_CustomerConditionGroup) ||
                (e.Group.Key == ct_ExBarGroupNm_ExtraConditionCodeGroup))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }

        #endregion

        #endregion

        #region ■ Private Method
        #region ◆ 画面初期化関係





        #region ◎ ボタンアイコン設定処理
        /// <summary>
        /// ボタンアイコン設定処理
        /// </summary>
        /// <param name="settingControl">アイコンセットするコントロール</param>
        /// <param name="iconIndex">アイコンインデックス</param>
        /// <remarks>
        /// <br>Note		: ボタンアイコン設定処理を行う</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((Infragistics.Win.Misc.UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((Infragistics.Win.Misc.UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion
        #endregion ◆ 画面初期化関係

        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 矢印キーでのフォーカス移動イベントを行う</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // ガイドボタン遷移制御 >>>>>>START
            if (!e.ShiftKey)
            {
                // SHIFTキー未押下
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                    {
                        // 仕入先(開始)→仕入先(終了)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // 仕入先(終了)→出力指定
                        e.NextCtrl = this.tComboEditor_WayToOrderType;
                    }
                }
            }
            else
            {
                // SHIFTキー押下
                //if (e.Key == Keys.Tab)
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tComboEditor_WayToOrderType)
                    {
                        // 出力指定→仕入先(終了)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // 仕入先(終了)→仕入先(開始)
                        e.NextCtrl = this.tNedit_SupplierCd_St;
                    }
                }
            }

            //leave event
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            this._prevControl = e.NextCtrl;
            switch (e.PrevCtrl.Name)
            {
                //仕入先コード(開始)
                case "tNedit_SupplierCd_St":
                    if ((!string.IsNullOrEmpty(tNedit_SupplierCd_St.Text))
                         && (!IsNumber(tNedit_SupplierCd_St.Text)))
                    {
                        tNedit_SupplierCd_St.Text = string.Empty;
                        tNedit_SupplierCd_St.Focus();
                        return;
                    }
                    break;
                //仕入先コード(終了)
                case "tNedit_SupplierCd_Ed":
                    if ((!string.IsNullOrEmpty(tNedit_SupplierCd_Ed.Text))
                        && (!IsNumber(tNedit_SupplierCd_Ed.Text)))
                    {
                        tNedit_SupplierCd_Ed.Text = string.Empty;
                        tNedit_SupplierCd_Ed.Focus();
                        return;
                    }
                    break;
                //粗利ﾁｪｯｸ 2
                case "GrsProfitCheckLower_tNedit":
                    if ((!string.IsNullOrEmpty(GrsProfitCheckLower_tNedit.Text))
                        && (!IsNumberOrDot(GrsProfitCheckLower_tNedit.Text)))
                    {
                        GrsProfitCheckLower_tNedit.Text = string.Empty;
                        GrsProfitCheckLower_tNedit.Focus();
                        return;
                    }
                    break;
                //粗利ﾁｪｯｸ 4
                case "GrsProfitCheckBest_tNedit":
                    if ((!string.IsNullOrEmpty(GrsProfitCheckBest_tNedit.Text))
                        && (!IsNumberOrDot(GrsProfitCheckBest_tNedit.Text)))
                    {
                        GrsProfitCheckBest_tNedit.Text = string.Empty;
                        GrsProfitCheckBest_tNedit.Focus();
                        return;
                    }
                    break;
                //粗利ﾁｪｯｸ 6
                case "GrsProfitCheckUpper_tNedit":
                    if ((!string.IsNullOrEmpty(GrsProfitCheckUpper_tNedit.Text))
                        && (!IsNumberOrDot(GrsProfitCheckUpper_tNedit.Text)))
                    {
                        GrsProfitCheckUpper_tNedit.Text = string.Empty;
                        GrsProfitCheckUpper_tNedit.Focus();
                        return;
                    }
                    break;
                default: return;
            }
        }

        /// <summary>
        /// 数字を判断処理
        /// </summary>
        /// <param name="s">str</param>
        /// <remarks>
        /// <br>Note		: 数字を判断処理を行い</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private static bool IsNumber(string s)
        {
            int Flag = 0;
            char[] str = s.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsNumber(str[i]))
                {
                    Flag++;
                }
                else
                {
                    Flag = -1;
                    break;
                }
            }
            if (Flag > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 数字を判断処理
        /// </summary>
        /// <param name="s">str</param>
        /// <remarks>
        /// <br>Note		: 数字を判断処理を行い</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private static bool IsNumberOrDot(string s)
        {
            int Flag = 0;
            char[] str = s.ToCharArray();
            char dotChar = '.';
            for (int i = 0; i < str.Length; i++)
            {
                if ((dotChar.Equals(str[i])) || (Char.IsNumber(str[i])))
                {
                    Flag++;
                }
                else
                {
                    Flag = -1;
                    break;
                }
            }
            if (Flag > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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
        /// <br>Programmer : 汪千来</br>
        /// <br>Date	   : 2009.05.11</br>
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
        /// <br>Programmer : 汪千来</br>
        /// <br>Date	   : 2009.05.11</br>
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
        #endregion
        #endregion ◆ エラーメッセージ表示処理 ( +1のオーバーロード )

        #region ◎ 抽出条件設定処理(画面→抽出条件)
        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private int SetExtraInfoFromScreen(StockSalesResultInfoMainCndtn extraInfo)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {

                // 拠点オプション
                extraInfo.IsOptSection = this._isOptSection;
                // 企業コード
                extraInfo.EnterpriseCode = this._enterpriseCode;

                // 選択拠点
                extraInfo.CollectAddupSecCodeList = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));

                // 仕入日(開始)        
                extraInfo.StStockDate = this.StockDateStRF_tDateEdit.GetLongDate();
                // 仕入日(終了)        
                extraInfo.EdStockDate = this.StockDateEdRF_tDateEdit.GetLongDate();

                // 仕入日(開始)        
                extraInfo.StInputDay = this.InputDayStRF_tDateEdit.GetLongDate();
                // 仕入日(終了)        
                extraInfo.EdInputDay = this.InputDayEdRF_tDateEdit.GetLongDate();

                //改頁
                extraInfo.NewPageType = Convert.ToInt32(tComboEditor_NewPageType.SelectedItem.DataValue);
                extraInfo.NewPageTypeName = Convert.ToString(tComboEditor_NewPageType.SelectedItem.DisplayText);

                // 仕入先(開始)
                extraInfo.StSupplierCd = this.tNedit_SupplierCd_St.GetInt();

                // 仕入先(終了)
                extraInfo.EdSupplierCd = this.tNedit_SupplierCd_Ed.GetInt();

                //出力指定
                extraInfo.WayToOrderType = Convert.ToInt32(tComboEditor_WayToOrderType.SelectedItem.DataValue);
                extraInfo.WayToOrderTypeName = Convert.ToString(tComboEditor_WayToOrderType.SelectedItem.DisplayText);

                //在庫取寄指定
                extraInfo.StockOrderDivCdType = Convert.ToInt32(tComboEditor_StockOrderDivCdType.SelectedItem.DataValue);
                extraInfo.StockOrderDivCdTypeName = Convert.ToString(tComboEditor_StockOrderDivCdType.SelectedItem.DisplayText);

                //売上伝票指定
                extraInfo.SalesType = Convert.ToInt32(tComboEditor_SalesType.SelectedItem.DataValue);
                extraInfo.SalesTypeName = Convert.ToString(tComboEditor_SalesType.SelectedItem.DisplayText);

                //原価指定
                extraInfo.StockUnitChngDivType = Convert.ToInt32(tComboEditor_StockUnitChngDivType.SelectedItem.DataValue);
                extraInfo.StockUnitChngDivTypeName = Convert.ToString(tComboEditor_StockUnitChngDivType.SelectedItem.DisplayText);

                //粗利チェック下限
                extraInfo.GrsProfitCheckLower = double.Parse(this.GrsProfitCheckLower_tNedit.Text);

                //粗利チェック2
                extraInfo.GrossMarginSt = this.GrossMarginSt_Nedit.GetValue();

                //粗利チェック3
                extraInfo.GrossMargin2Ed = this.GrossMargin2Ed_Nedit.GetValue();

                //粗利チェック4
                extraInfo.GrossMargin3Ed = this.GrossMargin3Ed_Nedit.GetValue();

                //粗利チェック適正
                extraInfo.GrsProfitCheckBest = double.Parse(this.GrsProfitCheckBest_tNedit.Text);

                //粗利チェック上限
                extraInfo.GrsProfitCheckUpper = double.Parse(this.GrsProfitCheckUpper_tNedit.Text);

                //粗利チェック1(マーク)
                extraInfo.GrossMargin1Mark = this.GrossMargin1Mark_tEdit.Text;

                //粗利チェック2(マーク)
                extraInfo.GrossMargin2Mark = this.GrossMargin2Mark_tEdit.Text;

                //粗利チェック3(マーク)
                extraInfo.GrossMargin3Mark = this.GrossMargin3Mark_tEdit.Text;

                //粗利チェック4(マーク)
                extraInfo.GrossMargin4Mark = this.GrossMargin4Mark_tEdit.Text;

            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion

        #region ◎ オフライン状態チェック処理

        /// <summary>
        /// ログオン時オンライン状態チェック処理
        /// </summary>
        /// <returns>チェック処理結果</returns>
        /// <remarks>
        /// <br>Note		: ログオン時オンライン状態チェック処理を行い</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ローカルエリア接続状態によるオンライン判定
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// リモート接続可能判定
        /// </summary>
        /// <returns>判定結果</returns>
        /// <remarks>
        /// <br>Note		: リモート接続可能判定を行い</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // インターネット接続不能状態
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #endregion

    }
}