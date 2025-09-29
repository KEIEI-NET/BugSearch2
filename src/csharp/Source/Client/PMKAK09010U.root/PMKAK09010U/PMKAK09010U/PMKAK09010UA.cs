//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入先総括マスタ一覧表 UIフォームクラス
// プログラム概要   : 仕入先総括マスタ一覧表 UIフォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号               作成担当 : FSI菅原　要
// 作 成 日  2012/09/07   修正内容 : 新規作成
//----------------------------------------------------------------------------//
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

namespace Broadleaf.Windows.Forms
{
    // <summary>
    /// 仕入先総括マスタ一覧表UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先総括マスタ一覧表UIフォームクラス</br>
    /// <br>Programmer : FSI菅原　要</br>
    /// <br>Date       : 2012/09/07</br>
    /// -----------------------------------------------------------------------------------
    /// <br></br>
    /// </remarks>
    public partial class PMKAK09010UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {

        #region ■ Constructor
        /// <summary>
        /// 仕入先総括マスタ一覧表UIフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入先総括マスタ一覧表UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2012/09/07</br>
        /// <br></br>
        /// </remarks>
        public PMKAK09010UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 拠点情報設定、仕入先アクセスクラス取得
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._supplierAcs = new SupplierAcs();

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

        #endregion ◆ Interface member

        // 拠点コード
        private string _enterpriseCode = "";
        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // ガイド用アクセスクラス
        // 拠点情報設定マスタアクセスクラス
        private SecInfoSetAcs _secInfoSetAcs;
        // 仕入先マスタアクセスクラス
        private SupplierAcs _supplierAcs;
        
        #endregion ■ Private Member

        #region ■ Private Const
        #region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
        // クラスID
        private const string ct_ClassID = "PMKAK09010UA";
        // プログラムID
        private const string ct_PGID = "PMKAK09010U";
        // 帳票名称
        private const string ct_PrintName = "仕入先総括マスタ一覧表";
        // 帳票キー	
        private const string ct_PrintKey = "55a4913e-2c26-42b8-8ea9-3942c2ff9ff9";
        #endregion ◆ Interface member

        // ExporerBar グループ名称
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
        /// <br>Programmer  : FSI菅原　要</br>
        /// <br>Date        : 2012/09/07</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            SFCMN06001U printDialog = new SFCMN06001U();            // 帳票選択ガイド
            SFCMN06002C printInfo = parameter as SFCMN06002C;	    // 印刷情報パラメータ

            // 企業コードをセット
            printInfo.enterpriseCode = this._enterpriseCode;
            // 起動PGID
            printInfo.kidopgid = ct_PGID;				

            // PDF出力履歴用
            printInfo.key = ct_PrintKey;
            printInfo.prpnm = ct_PrintName;
            printInfo.PrintPaperSetCd = 0;

            // プレビュー有無:有り
            printInfo.prevkbn = 1;
            // PDF作業用パス
            printInfo.pdftemppath = string.Empty;                   

            // 条件クラス
            SumSuppStPrintUIParaWork extrInfo = new SumSuppStPrintUIParaWork();

            // 画面→抽出条件クラス
            int status = this.SetExtraInfoFromScreen(extrInfo);
            if (status != 0)
            {
                return -1;
            }
            printInfo.jyoken = extrInfo;

            // 帳票選択ガイド
            printDialog.PrintInfo = printInfo;
            DialogResult dialogResult = printDialog.ShowDialog();
            if (dialogResult == DialogResult.Cancel)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            // 該当データが無い場合
            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません。", 0);
            }


            return printInfo.status;
        }
        #endregion

        #region ◎ クラスインスタンス化
        /// <summary>
        /// 指定されたアセンブリ及びクラス名より、クラスをインスタンス化
        /// </summary>
        /// <param name="asmname">アセンブリ名称</param>
        /// <param name="classname">クラス名称</param>
        /// <returns>インスタンス化されたクラス</returns>
        /// <remarks>
        /// <br>Note 　　  : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        private object LoadAssemblyFrom(string asmname, string classname)
        {
            object obj = null;
            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
                Type objType = asm.GetType(classname);
                if (objType != null)
                {
                    obj = Activator.CreateInstance(objType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return obj;
        }
        #endregion

        #region ◎ 印刷前確認処理
        /// <summary>
        /// 印刷前確認処理
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: 印刷前確認処理を行う。(入力チェックなど)</br>
        /// <br>Programmer  : FSI菅原　要</br>
        /// <br>Date        : 2012/09/07</br>
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
        /// <br>Programmer  : FSI菅原　要</br>
        /// <br>Date        : 2012/09/07</br>
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
        /// <br>Programmer  : FSI菅原　要</br>
        /// <br>Date        : 2012/09/07</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // 総括拠点
                this.tEdit_SectionCode_St.Clear();
                this.tEdit_SectionCode_Ed.Clear();
                // 総括仕入先
                this.tNedit_SupplierCd_St.Clear();
                this.tNedit_SupplierCd_Ed.Clear();
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
        /// <br>Programmer  : FSI菅原　要</br>
        /// <br>Date        : 2012/09/07</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            int SectionCodeSt = 0;
            int SectionCodeEd = 99;
            int SupplierCdSt = 0;
            int SupplierCdEd = 999999;

            #region [数値チェック]
            // 総括拠点開始が数値かチェック
            if (!tEdit_SectionCode_St.Text.Equals(string.Empty) &&
                 !int.TryParse(tEdit_SectionCode_St.Text, out SectionCodeSt))
            {
                errMessage = "入力されたコードが不正です。";
                errComponent = tEdit_SectionCode_St;
                status = false;
            }
            // 総括拠点終了が数値かチェック
            else if (!tEdit_SectionCode_Ed.Text.Equals(string.Empty) &&
                     !int.TryParse(tEdit_SectionCode_Ed.Text, out SectionCodeEd))
            {
                errMessage = "入力されたコードが不正です。";
                errComponent = tEdit_SectionCode_Ed;
                status = false;
            }
            // 総括仕入先開始が数値かチェック
            else if (!tNedit_SupplierCd_St.Text.Equals(string.Empty) &&
                 !int.TryParse(tNedit_SupplierCd_St.Text, out SupplierCdSt))
            {
                errMessage = "入力されたコードが不正です。";
                errComponent = tNedit_SupplierCd_St;
                status = false;
            }
            // 総括仕入先終了が数値かチェック
            else if (!tNedit_SupplierCd_Ed.Text.Equals(string.Empty) &&
                     !int.TryParse(tNedit_SupplierCd_Ed.Text, out SupplierCdEd))
            {
                errMessage = "入力されたコードが不正です。";
                errComponent = tNedit_SupplierCd_Ed;
                status = false;
            }
            #endregion

            #region [正数値チェック]
            // 総括拠点開始が数値で、正の値であるかチェック
            if (!tEdit_SectionCode_St.Text.Equals(string.Empty) &&
                 int.TryParse(tEdit_SectionCode_St.Text, out SectionCodeSt))
            {
                if (SectionCodeSt <= 0)
                {
                    errMessage = "入力されたコードが不正です。";
                    errComponent = tEdit_SectionCode_St;
                    return false;
                }
            }
            // 総括拠点終了が数値で、正の値であるかチェック
            else if (!tEdit_SectionCode_Ed.Text.Equals(string.Empty) &&
                     int.TryParse(tEdit_SectionCode_Ed.Text, out SectionCodeEd))
            {
                if (SectionCodeEd <= 0)
                {
                    errMessage = "入力されたコードが不正です。";
                    errComponent = tEdit_SectionCode_Ed;
                    return false;
                }
            }
            // 総括仕入先開始が数値で、正の値であるかチェック
            else if (!tNedit_SupplierCd_St.Text.Equals(string.Empty) &&
                    int.TryParse(tNedit_SupplierCd_St.Text, out SupplierCdSt))
            {
                if (SupplierCdSt <= 0)
                {
                    errMessage = "入力されたコードが不正です。";
                    errComponent = tNedit_SupplierCd_St;
                    return false;
                }
            }
            // 総括仕入先終了が数値で、正の値であるかチェック
            else if (!tNedit_SupplierCd_Ed.Text.Equals(string.Empty) &&
                     int.TryParse(tNedit_SupplierCd_Ed.Text, out SupplierCdEd))
            {
                if (SupplierCdEd <= 0)
                {
                    errMessage = "入力されたコードが不正です。";
                    errComponent = tNedit_SupplierCd_Ed;
                    return false;
                }
            }
            #endregion
            
            #region [大小チェック]
            // 総括拠点の大小チェック
            if (SectionCodeEd < SectionCodeSt)
            {
                errMessage = "入力された総括拠点の範囲が不正です。";
                errComponent = tEdit_SectionCode_St;
                status = false;
            }
            // 総括仕入先の大小チェック
            else if (SupplierCdEd < SupplierCdSt)
            {
                errMessage = "入力された総括仕入先の範囲が不正です。";
                errComponent = tNedit_SupplierCd_St;
                status = false;
            }
            #endregion

            return status;
        }
        #endregion

        #region ◎ 抽出条件設定処理(画面→抽出条件)
        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <param name="extrInfo_StockMasterTbl">抽出条件クラス</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer  : FSI菅原　要</br>
        /// <br>Date        : 2012/09/07</br>
        /// </remarks>
        private int SetExtraInfoFromScreen(SumSuppStPrintUIParaWork extrInfo)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // 企業コード
                extrInfo.EnterpriseCode = this._enterpriseCode;

                // 総括拠点（開始）
                if (this.tEdit_SectionCode_St.Text.Equals(string.Empty))
                {
                    extrInfo.SumSectionCodeSt = "";
                }
                else
                {
                    extrInfo.SumSectionCodeSt = this.tEdit_SectionCode_St.Text.ToString();
                }

                // 総括拠点（終了）
                if (this.tEdit_SectionCode_Ed.Text.Equals(string.Empty))
                {
                    extrInfo.SumSectionCodeEd = "";
                }
                else
                {
                    extrInfo.SumSectionCodeEd = this.tEdit_SectionCode_Ed.Text.ToString();
                }

                // 総括仕入先（開始）
                if (this.tNedit_SupplierCd_St.Text.Equals(string.Empty))
                {
                    extrInfo.SumSupplierCdSt = 0;
                }
                else
                {
                    extrInfo.SumSupplierCdSt = int.Parse(this.tNedit_SupplierCd_St.Text);
                }

                // 総括仕入先（終了）
                if (this.tNedit_SupplierCd_Ed.Text.Equals(string.Empty))
                {
                    extrInfo.SumSupplierCdEd = 0;
                }
                else
                {
                    extrInfo.SumSupplierCdEd = int.Parse(this.tNedit_SupplierCd_Ed.Text);
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
        /// <br>Programmer  : FSI菅原　要</br>
        /// <br>Date        : 2012/09/07</br>
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
        /// <br>Programmer  : FSI菅原　要</br>
        /// <br>Date        : 2012/09/07</br>
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

        #region ◆ エラーメッセージ表示
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
        /// <br>Note       : エラーメッセージを表示します。</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, this.Name, iMsg, iSt, iButton, iDefButton);
        }
        #endregion
        #endregion ■ Private Method

        #region ■ Control Event
        #region ◆ PMKAK09010UA
        #region ◎ PMKAK09010UA_Load Event
        /// <summary>
        /// PMKAK09010UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがフォームを読み込むときに発生する</br>
        /// <br>Programmer  : FSI菅原　要</br>
        /// <br>Date        : 2012/09/07</br>
        /// </remarks>
        /// 
        private void PMKAK09010UA_Load(object sender, EventArgs e)
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
        #endregion ◆ PMZAI02020UA

        #region ◆ ueb_MainExplorerBar
        #region ◎ GroupCollapsing Event
        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroupが縮小される前に発生する。</br>
        /// <br>Programmer  : FSI菅原　要</br>
        /// <br>Date        : 2012/09/07</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if (e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup)
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
        /// <br>Programmer  : FSI菅原　要</br>
        /// <br>Date        : 2012/09/07</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if (e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup)
            {
                // グループの展開をキャンセル
                e.Cancel = true;
            }

        }
        #endregion
        #endregion ◆ ueb_MainExplorerBar Event

        #region ◆ ガイドボタン
        /// <summary>総括拠点開始ガイドボタンイベント</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 総括拠点開始ガイドボタンが押下された時に発生します。</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks> 
        private void ub_SectionCodeStartGuideButton_Click(object sender, EventArgs e)
        {
            int status = -1;

            // 取得用パラメータ生成
            SecInfoSet secInfoSet = new SecInfoSet();

            try
            {
                // ガイドより取得
                status = _secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    tEdit_SectionCode_St.Text = secInfoSet.SectionCode.Trim();
                    tEdit_SectionCode_Ed.Focus();
                }
            }
            catch
            {
            }

            return;
        }

        /// <summary>総括拠点終了ガイドボタンイベント</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 総括拠点終了ガイドボタンが押下された時に発生します。</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks> 
        private void ub_SectionCodeEndGuideButton_Click(object sender, EventArgs e)
        {
            int status = -1;

            // 取得用パラメータ生成
            SecInfoSet secInfoSet = new SecInfoSet();

            try
            {
                // ガイドより取得
                status = _secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    tEdit_SectionCode_Ed.Text = secInfoSet.SectionCode.Trim();
                    tNedit_SupplierCd_St.Focus();
                }
            }
            catch
            {
            }

            return;
        }

        /// <summary>総括仕入先開始ガイドボタンイベント</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 総括仕入先開始ガイドボタンが押下された時に発生します。</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks> 
        private void ub_SupplierCodeStartGuideButton_Click(object sender, EventArgs e)
        {
            int status = -1;

            // 取得用パラメータ生成
            Supplier supplierInfo;

            try
            {
                // ガイドより取得
                status = this._supplierAcs.ExecuteGuid(out supplierInfo, this._enterpriseCode, string.Empty);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    tNedit_SupplierCd_St.SetInt(supplierInfo.SupplierCd);
                    tNedit_SupplierCd_Ed.Focus();
                }
            }
            catch
            {
            }
        }
        /// <summary>総括仕入先終了ガイドボタンイベント</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 総括仕入先終了ガイドボタンが押下された時に発生します。</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks> 
        private void ub_SupplierCodeEndGuideButton_Click(object sender, EventArgs e)
        {
            int status = -1;

            // 取得用パラメータ生成
            Supplier supplierInfo;

            try
            {
                // ガイドより取得
                status = this._supplierAcs.ExecuteGuid(out supplierInfo, this._enterpriseCode, string.Empty);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    tNedit_SupplierCd_Ed.SetInt(supplierInfo.SupplierCd);
                    tEdit_SectionCode_St.Focus();
                }
            }
            catch
            {
            }

            return;
        }
        #endregion

        #region ◎ tArrowKeyControl1_ChangeFocus Event
        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 矢印キー、TABキー、ENTERキーが押下された時に発生します。</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks> 
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFTキー未押下
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tEdit_SectionCode_St)
                    {
                        // 総括拠点(開始)→総括拠点(終了)
                        e.NextCtrl = this.tEdit_SectionCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_SectionCode_Ed)
                    {
                        // 総括拠点(終了)→総括仕入先(開始)
                        e.NextCtrl = this.tNedit_SupplierCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                    {
                        // 総括仕入先(開始)→総括仕入先(終了)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // 総括仕入先(終了)→総括拠点(開始)
                        e.NextCtrl = this.tEdit_SectionCode_St;
                    }
                }
            }
            else
            {
                // SHIFTキー押下
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // 総括仕入先(終了)→総括仕入先(開始)
                        e.NextCtrl = this.tNedit_SupplierCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                    {
                        // 総括仕入先(開始)→総括拠点(終了)
                        e.NextCtrl = this.tEdit_SectionCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_SectionCode_Ed)
                    {
                        // 総括拠点(終了)→総括拠点(開始)
                        e.NextCtrl = this.tEdit_SectionCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_SectionCode_St)
                    {
                        // 総括拠点(開始)→総括仕入先(終了)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
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
        /// <remarks>
        /// <br>Note       : 画面初期化タイマイベントです。</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks> 
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
                this.SetIconImage(this.ub_SectionCodeStartGuideButton, Size16_Index.STAR1);
                this.SetIconImage(this.ub_SectionCodeEndGuideButton, Size16_Index.STAR1);
                this.SetIconImage(this.ub_SupplierCodeStartGuideButton, Size16_Index.STAR1);
                this.SetIconImage(this.ub_SupplierCodeEndGuideButton, Size16_Index.STAR1);

                ParentToolbarSettingEvent(this);	// ツールバー設定イベント
            }
            finally
            {
                // 初期フォーカス
                this.tEdit_SectionCode_St.Focus();

                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #endregion ◆ Initialize_Timer



    }
}
