using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinTree;
using Broadleaf.Application.Resources;   // 2017/09/14 譚洪 ハンディターミナル二次開発

namespace Broadleaf.Windows.Forms
{
    // <summary>
    /// 入庫予定表UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 入庫予定表UIフォームクラス</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date       : 2008.12.03</br>
    /// -----------------------------------------------------------------------------------
    /// <br>Note       : ハンディターミナル二次開発の対応</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/09/14</br>
    /// -----------------------------------------------------------------------------------
    /// <br></br>
    /// </remarks>
    public partial class PMUOE02060UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {

        #region ■ Constructor
        /// <summary>
        /// 入庫予定表UIフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入庫予定表UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.12.03</br>
        /// <br>Note       : ハンディターミナル二次開発の対応</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/09/14</br>
        /// </remarks>
        public PMUOE02060UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 拠点用のHashtable作成
            this._selectedSectionList = new Hashtable();

            // 回収予定表アクセスクラス
            this._enterSchOrderAcs = new EnterSchOrderAcs();

            // 日付取得部品
            this._dateGetAcs = DateGetAcs.GetInstance();

            // UOE発注先マスタアクセスクラス
            this._uoeSupplierAcs = new UOESupplierAcs();

            // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
            // ハンディOP(仕入)オプション有無を取得する「false:OFF(使用不可) true:ON(使用可)」
            IsOptHandySup = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_HND_InspMng_Stock) > 0);
            // ハンディOP(仕入)オプションはOFF場合
            if (!IsOptHandySup)
            {
                // バーコード印字しない
                this.tComboEditor_BarCodeShow.Value = 1;
                this.tComboEditor_BarCodeShow.Visible = false;
                this.BarCodeShow_Label.Visible = false;
                this.uebcc_SelectList.Size = new System.Drawing.Size(714, 116);
                this.uebcc_SortOrder.Location = new System.Drawing.Point(18, 199);
                this.uebcc_ExtractCondition.Location = new System.Drawing.Point(18, 293);
            }
            // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<
        }
        #endregion

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
        // 選択拠点リスト
        private Hashtable _selectedSectionList = new Hashtable();
        #endregion ◆ Interface member

        // 拠点コード
        private string _enterpriseCode = "";
        // 回収予定表アクセスクラス
        private EnterSchOrderAcs _enterSchOrderAcs;
        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 日付取得部品
        private DateGetAcs _dateGetAcs;

        // UOE発注先マスタアクセスクラス
        private UOESupplierAcs _uoeSupplierAcs;
        
        #endregion ■ Private Member

        #region ■ Private Const
        #region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
        // クラスID
        private const string ct_ClassID = "PMUOE02060UA";
        // プログラムID
        private const string ct_PGID = "PMUOE02060U";
        // 帳票名称
        private const string ct_PrintName = "入庫予定表";
        // 帳票キー	
        private const string ct_PrintKey = "86aa7f12-55e0-4988-8585-1645e2ffbb5a";
        #endregion ◆ Interface member

        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
        /// <summary> ハンディOP(仕入)オプション区分「0:OFF(使用不可) 1:ON(使用可)」</summary>
        private bool IsOptHandySup = false;
        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<

        // ExporerBar グループ名称
        private const string ct_ExBarGroupNm_ReportSelectGroup = "ReportSelectGroup";		// 出力条件
        private const string ct_ExBarGroupNm_PrintOderGroup = "PrintOderGroup";			    // ソート順
        private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";	// 抽出条件
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
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.12.03</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
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
            EnterSchOrderCndtn extrInfo = new EnterSchOrderCndtn();

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
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0);
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
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.12.03</br>
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
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.12.03</br>
        /// </remarks>
        public void Show(object parameter)
        {
            // Todo:起動パラメータを変更する場合はここで行う。
            this.Show();
            return;
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
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.12.03</br>
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
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.12.03</br>
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
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.12.03</br>
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
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.12.03</br>
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
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.12.03</br>
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
            get { return ct_PrintKey; }
        }

        /// <summary> 帳票名プロパティ </summary>
        public string PrintName
        {
            get { return ct_PrintName; }
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
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.12.03</br>
        /// <br>Note		: ハンディターミナル二次開発の対応</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2017/09/14</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // 発注日
                this.tde_St_ReceiveDate.SetDateTime(TDateTime.GetSFDateNow());
                this.tde_Ed_ReceiveDate.SetDateTime(TDateTime.GetSFDateNow());
                // 印刷タイプ
                this.tComboEditor_PrintType.Value = 0;
                // 改頁
                this.tComboEditor_NewPageType.Value = 0;
                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
                // ハンディOP(仕入)オプションはOFF場合
                if (!IsOptHandySup)
                {
                    // バーコード印字しない
                    this.tComboEditor_BarCodeShow.Value = 1;
                }
                // ハンディOP(仕入)オプションはON場合
                else
                {
                    // バーコード印字する
                    this.tComboEditor_BarCodeShow.Value = 0;
                }
                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<
                // 印刷順
                this.tce_SortOrderDiv.Value = 0;
                // 発注先
                this.ce_SupplierExtra.Value = 0;
                // 発注先(範囲)
                this.tNedit_SupplierCd_St.Clear();
                this.tNedit_SupplierCd_Ed.Clear();
                // 発注先(単独)
                this.tNedit_SupplierCd1.Clear();
                this.tNedit_SupplierCd2.Clear();
                this.tNedit_SupplierCd3.Clear();
                this.tNedit_SupplierCd4.Clear();
                this.tNedit_SupplierCd5.Clear();
                this.tNedit_SupplierCd6.Clear();
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
            ((Infragistics.Win.Misc.UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((Infragistics.Win.Misc.UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion
        #endregion ◆ 画面初期化関係

        #region ◆ 印刷前処理
        #region ◎ 入力チェック処理
        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.12.03</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            const string ct_RangeError = "の範囲指定に誤りがあります";
            const string ct_InputUnitError = "の抽出条件が単独指定の場合は一つ以上入力して下さい";
            
            errMessage = "";
            errComponent = null;

            DateGetAcs.CheckDateRangeResult cdrResult;

            // 発注日（開始・終了）
            if ((this.tde_St_ReceiveDate.LongDate != 0) ||
                (this.tde_Ed_ReceiveDate.LongDate != 0))
            {
                if (CallCheckDateRange(out cdrResult, ref tde_St_ReceiveDate, ref tde_Ed_ReceiveDate) == false)
                {
                    switch (cdrResult)
                    {
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                            {
                                errMessage = "開始日を入力して下さい";
                                errComponent = this.tde_St_ReceiveDate;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                            {
                                errMessage = "開始日の入力が不正です";
                                errComponent = this.tde_St_ReceiveDate;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                            {
                                errMessage = "終了日を入力して下さい";
                                errComponent = this.tde_Ed_ReceiveDate;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                            {
                                errMessage = "終了日の入力が不正です";
                                errComponent = this.tde_Ed_ReceiveDate;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                            {
                                errMessage = "日付の範囲指定に誤りがあります";
                                errComponent = this.tde_St_ReceiveDate;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                            {
                                errMessage = "日付は３ヶ月の範囲で入力して下さい";
                                errComponent = this.tde_St_ReceiveDate;
                            }
                            break;

                    }
                    status = false;
                    return status;
                }
            }
            else
            {
                // 開始日と終了日の両方未入力
                errMessage = "開始日と終了日を入力して下さい";
                errComponent = this.tde_St_ReceiveDate;
                status = false;
                return status;
            }

            // 発注先チェック
            if ((int)this.ce_SupplierExtra.Value == 0)
            {
                // 範囲
                if ((this.tNedit_SupplierCd_St.DataText.Trim() != "") &&
                    (this.tNedit_SupplierCd_Ed.DataText.Trim() != "") &&
                    (this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt()))
                {
                    errMessage = string.Format("発注先{0}", ct_RangeError);
                    errComponent = this.tNedit_SupplierCd_St;
                    status = false;
                }
            }
            else if ((int)this.ce_SupplierExtra.Value == 1)
            {
                bool supplierFlg = false;
                // 単独
                if (this.tNedit_SupplierCd1.GetInt() != 0)
                {
                    supplierFlg = true;
                }
                else if (this.tNedit_SupplierCd2.GetInt() != 0)
                {
                    supplierFlg = true;
                }
                else if (this.tNedit_SupplierCd3.GetInt() != 0)
                {
                    supplierFlg = true;
                }
                else if (this.tNedit_SupplierCd4.GetInt() != 0)
                {
                    supplierFlg = true;
                }
                else if (this.tNedit_SupplierCd5.GetInt() != 0)
                {
                    supplierFlg = true;
                }
                else if (this.tNedit_SupplierCd6.GetInt() != 0)
                {
                    supplierFlg = true;
                }

                if (!supplierFlg)
                {
                    errMessage = string.Format("発注先{0}", ct_InputUnitError);
                    errComponent = this.tNedit_SupplierCd1;
                    status = false;
                }
            }

            return status;
        }
        #endregion

        #region ◎ 日付入力チェック処理
        /// <summary>
        /// 日付範囲チェック呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit startDate, ref TDateEdit endDate)
        {
            cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 3, ref startDate, ref endDate, false, false);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        #endregion

        #region ◎ 抽出条件設定処理(画面→抽出条件)
        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.12.03</br>
        /// <br>Note		: ハンディターミナル二次開発の対応</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2017/09/14</br>
        /// </remarks>
        private int SetExtraInfoFromScreen(EnterSchOrderCndtn enterSchOrderCndtn)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // 拠点オプション
                enterSchOrderCndtn.IsOptSection = this._isOptSection;
                // 企業コード
                enterSchOrderCndtn.EnterpriseCode = this._enterpriseCode;
                // 選択拠点
                enterSchOrderCndtn.SectionCodes = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));
                // 発注日
                enterSchOrderCndtn.St_ReceiveDate = this.tde_St_ReceiveDate.GetDateTime();
                enterSchOrderCndtn.Ed_ReceiveDate = this.tde_Ed_ReceiveDate.GetDateTime();
                // 印刷タイプ
                enterSchOrderCndtn.PrintTypeCndtn = (int)this.tComboEditor_PrintType.Value;
                // 改頁
                enterSchOrderCndtn.NewPageDiv = (int)this.tComboEditor_NewPageType.Value;

                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
                // バーコード印字区分
                enterSchOrderCndtn.BarCodeShowDiv = (int)this.tComboEditor_BarCodeShow.Value;
                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<

                // 印刷順
                enterSchOrderCndtn.SortOrderDiv = (int)this.tce_SortOrderDiv.Value;

                // 発注先抽出条件
                enterSchOrderCndtn.SupplierExtra = (int)this.ce_SupplierExtra.Value;

                if (enterSchOrderCndtn.SupplierExtra == 0)
                {
                    // 範囲
                    enterSchOrderCndtn.St_UOESupplierCd = this.tNedit_SupplierCd_St.GetInt();
                    enterSchOrderCndtn.Ed_UOESupplierCd = this.tNedit_SupplierCd_Ed.GetInt();
                    enterSchOrderCndtn.UOESupplierCds = null;
                }
                else
                {
                    // 単独
                    ArrayList unitList = new ArrayList();

                    if (this.tNedit_SupplierCd1.GetInt() != 0)
                    {
                        unitList.Add(this.tNedit_SupplierCd1.GetInt());
                    }
                    if (this.tNedit_SupplierCd2.GetInt() != 0)
                    {
                        unitList.Add(this.tNedit_SupplierCd2.GetInt());
                    }
                    if (this.tNedit_SupplierCd3.GetInt() != 0)
                    {
                        unitList.Add(this.tNedit_SupplierCd3.GetInt());
                    }
                    if (this.tNedit_SupplierCd4.GetInt() != 0)
                    {
                        unitList.Add(this.tNedit_SupplierCd4.GetInt());
                    }
                    if (this.tNedit_SupplierCd5.GetInt() != 0)
                    {
                        unitList.Add(this.tNedit_SupplierCd5.GetInt());
                    }
                    if (this.tNedit_SupplierCd6.GetInt() != 0)
                    {
                        unitList.Add(this.tNedit_SupplierCd6.GetInt());
                    }

                    int[] unitBuff = new int[unitList.Count];

                    for (int i = 0; i < unitList.Count; i++)
                    {
                        unitBuff[i] = (int)unitList[i];
                    }

                    enterSchOrderCndtn.UOESupplierCds = unitBuff;
                }

            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion
        #endregion ◆ 印刷前処理

        #region ◆ ControlEventから呼び出し
        #region ◎ Enabled設定関数
        /// <summary>
        /// Enabled設定関数
        /// </summary>
        /// <param name="isSort">印字順位Enabled</param>
        private void SetCtrlEnablePrintChange(bool isSort)
        {
            tce_SortOrderDiv.Enabled = isSort;				// 印字順位
        }
        #endregion
        #endregion ◆

        #region ◆ エラーメッセージ表示処理 ( +1のオーバーロード )
        #region ◎ エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note        : エラーメッセージの表示を行います。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.12.03</br>
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
        /// <br>Note        : エラーメッセージの表示を行います。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.12.03</br>
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
        #endregion ■ Private Method

        #region ■ Control Event
        #region ◆ PMUOE02060UA
        #region ◎ PMUOE02060UA_Load Event
        /// <summary>
        /// PMUOE02060UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.12.03</br>
        /// </remarks>
        /// 
        private void PMUOE02060UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // 初期化タイマー起動
            Initialize_Timer.Enabled = true;

            // 画面イメージ統一
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            ParentToolbarSettingEvent(this);						// ツールバーボタン設定イベント起動
        }
        #endregion
        #endregion ◆ PMUOE02060UA

        #region ◆ ueb_MainExplorerBar
        #region ◎ GroupCollapsing Event
        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroupが縮小される前に発生する。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.12.03</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup) ||
                (e.Group.Key == ct_ExBarGroupNm_PrintOderGroup) ||
                (e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup))
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
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.12.03</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup) ||
                (e.Group.Key == ct_ExBarGroupNm_PrintOderGroup) ||
                (e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup))
            {
                // グループの展開をキャンセル
                e.Cancel = true;
            }

        }
        #endregion
        #endregion ◆ ueb_MainExplorerBar Event


        #region ◎ ub_St_SupplierCodeGuide_Click Event
        /// <summary>
        /// 開始発注先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_St_SupplierCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            UOESupplier uoeSupplier = new UOESupplier();
            status = this._uoeSupplierAcs.ExecuteGuid(this._enterpriseCode, "", out uoeSupplier);

            // 項目に展開
            if (status == 0)
            {
                this.tNedit_SupplierCd_St.SetInt(uoeSupplier.UOESupplierCd);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region ◎ ub_Ed_SupplierCodeGuide_Click Event
        /// <summary>
        /// 終了仕入先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_Ed_SupplierCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            UOESupplier uoeSupplier = new UOESupplier();
            status = this._uoeSupplierAcs.ExecuteGuid(this._enterpriseCode, "", out uoeSupplier);

            // 項目に展開
            if (status == 0)
            {
                this.tNedit_SupplierCd_Ed.SetInt(uoeSupplier.UOESupplierCd);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region ◎ ub_Unit_SupplierCodeGuide_Click Event
        /// <summary>
        /// 単独仕入先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_Unit_SupplierCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            UOESupplier uoeSupplier = new UOESupplier();
            status = this._uoeSupplierAcs.ExecuteGuid(this._enterpriseCode, "", out uoeSupplier);

            // 項目に展開
            if (status == 0)
            {
                // 左から順に未入力の仕入先へ設定
                if (this.tNedit_SupplierCd1.Text == "")
                {
                    this.tNedit_SupplierCd1.SetInt(uoeSupplier.UOESupplierCd);
                    this.tNedit_SupplierCd2.Focus();
                }
                else if (this.tNedit_SupplierCd2.Text == "")
                {
                    this.tNedit_SupplierCd2.SetInt(uoeSupplier.UOESupplierCd);
                    this.tNedit_SupplierCd3.Focus();
                }
                else if (this.tNedit_SupplierCd3.Text == "")
                {
                    this.tNedit_SupplierCd3.SetInt(uoeSupplier.UOESupplierCd);
                    this.tNedit_SupplierCd4.Focus();
                }
                else if (this.tNedit_SupplierCd4.Text == "")
                {
                    this.tNedit_SupplierCd4.SetInt(uoeSupplier.UOESupplierCd);
                    this.tNedit_SupplierCd5.Focus();
                }
                else if (this.tNedit_SupplierCd5.Text == "")
                {
                    this.tNedit_SupplierCd5.SetInt(uoeSupplier.UOESupplierCd);
                    this.tNedit_SupplierCd6.Focus();
                }
                else if (this.tNedit_SupplierCd6.Text == "")
                {
                    this.tNedit_SupplierCd6.SetInt(uoeSupplier.UOESupplierCd);
                    this.tde_St_ReceiveDate.Focus();
                }
            }
        }
        #endregion

        #region ◎ ub_Unit_SupplierCodeGuide_Click Event
        /// <summary>
        /// 仕入先抽出条件 値変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ce_SupplierExtra_ValueChanged(object sender, EventArgs e)
        {
            TComboEditor tComboEditor = (sender as TComboEditor);

            if ((int)tComboEditor.Value == 0)
            {
                // 範囲の場合
                // 有効
                this.tNedit_SupplierCd_St.Enabled = true;
                this.ub_St_SupplierCodeGuide.Enabled = true;
                this.tNedit_SupplierCd_Ed.Enabled = true;
                this.ub_Ed_SupplierCodeGuide.Enabled = true;

                // 無効
                this.tNedit_SupplierCd1.Enabled = false;
                this.tNedit_SupplierCd2.Enabled = false;
                this.tNedit_SupplierCd3.Enabled = false;
                this.tNedit_SupplierCd4.Enabled = false;
                this.tNedit_SupplierCd5.Enabled = false;
                this.tNedit_SupplierCd6.Enabled = false;
                this.ub_Unit_SupplierCodeGuide.Enabled = false;
            }
            else
            {
                // 単独の場合
                // 有効
                this.tNedit_SupplierCd1.Enabled = true;
                this.tNedit_SupplierCd2.Enabled = true;
                this.tNedit_SupplierCd3.Enabled = true;
                this.tNedit_SupplierCd4.Enabled = true;
                this.tNedit_SupplierCd5.Enabled = true;
                this.tNedit_SupplierCd6.Enabled = true;
                this.ub_Unit_SupplierCodeGuide.Enabled = true;

                // 無効
                this.tNedit_SupplierCd_St.Enabled = false;
                this.ub_St_SupplierCodeGuide.Enabled = false;
                this.tNedit_SupplierCd_Ed.Enabled = false;
                this.ub_Ed_SupplierCodeGuide.Enabled = false;
            }
        }
        #endregion

        #region ◎ tArrowKeyControl1_ChangeFocus Event
        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFTキー未押下
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                    {
                        // 発注先(開始)→発注先(終了)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // 発注先(終了)→発注日(開始)
                        e.NextCtrl = this.tde_St_ReceiveDate;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd6)
                    {
                        // 発注先６(単独)→発注日(開始)
                        e.NextCtrl = this.tde_St_ReceiveDate;
                    }
                }
            }
            else
            {
                // SHIFTキー押下
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.tde_St_ReceiveDate)
                    {
                        // 発注日(開始)
                        if (this.tNedit_SupplierCd_Ed.Enabled)
                        {
                            // →発注先(終了)
                            e.NextCtrl = this.tNedit_SupplierCd_Ed;
                        }
                        else
                        {
                            // →発注先６(単独)
                            e.NextCtrl = this.tNedit_SupplierCd6;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // 発注先(終了)→発注先(開始)
                        e.NextCtrl = this.tNedit_SupplierCd_St;
                    }
                }
            }
        }
        #endregion
        #endregion ■ Control Event

        #region ◆ Initialize_Timer
        #region ◎ Tick Event
        /// <summary>
        /// Tick Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void Initialize_Timer_Tick(object sender, EventArgs e)
        {
            Initialize_Timer.Enabled = false;
            string errMsg = string.Empty;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // コントロール初期化
                int status = this.InitializeScreen(out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                    return;
                }
                
                // ガイドボタンのアイコン設定
                this.SetIconImage(this.ub_St_SupplierCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_SupplierCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Unit_SupplierCodeGuide, Size16_Index.STAR1);
                
                ParentToolbarSettingEvent(this);	// ツールバー設定イベント
            }
            finally
            {
                this.tde_St_ReceiveDate.Focus();

                this.Cursor = Cursors.Default;
            }
        }
        #endregion
        #endregion ◆ Initialize_Timer
    }
}
