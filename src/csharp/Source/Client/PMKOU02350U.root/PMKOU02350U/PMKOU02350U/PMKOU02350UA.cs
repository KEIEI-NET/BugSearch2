//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 入荷差異表 UIフォームクラス
// プログラム概要   : 入荷差異表 UIフォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570136-00  作成担当 : 譚洪
// 作 成 日  K2019/08/14  修正内容 : 新規作成
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
using Broadleaf.Library.Windows.Forms;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using System.Text.RegularExpressions;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 入荷差異表UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 入荷差異表UIフォームクラス</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : K2019/08/14</br>
    /// </remarks>
    public partial class PMKOU02350UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ Constructor
        /// <summary>
        /// 入荷差異表UIフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入荷差異表UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        public PMKOU02350UA()
        {
            InitializeComponent();

            // 企業コード取得
            this.EnterpriseCd = LoginInfoAcquisition.EnterpriseCode;

            // ログイン拠点コード取得
            this.LoginSectionCd = LoginInfoAcquisition.Employee.BelongSectionCode;

            // 日付取得部品
            GateGetAccess = DateGetAcs.GetInstance();

            this.ArrGoodsDiffAccess = new ArrGoodsDiffAcs();
        }

        /// <summary>
        /// 入荷差異表UIフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入荷差異表UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
        /// <br></br>
        /// </remarks>
        public PMKOU02350UA(string para)
        {
            if ("NUnit".Equals(para))
            {
                InitializeComponent();
            }
        }
        #endregion

        #region ■ Private Member
        #region ◆ Interface member
        //--IPrintConditionInpTypeのプロパティ用変数 ----------------------------------
        // 抽出ボタン状態取得プロパティ
        private bool CanExtractField = false;
        // PDF出力ボタン状態取得プロパティ    
        private bool CanPdfField = true;
        // 印刷ボタン状態取得プロパティ
        private bool CanPrintField = true;
        // 抽出ボタン表示有無プロパティ
        private bool VisibledExtractButtonField = false;
        // PDF出力ボタン表示有無プロパティ	
        private bool VisibledPdfButtonField = true;
        // 印刷ボタン表示有無プロパティ
        private bool VisibledPrintButtonField = true;

        #endregion ◆ Interface member

        // 企業コード
        private string EnterpriseCd = "";

        // 拠点コード
        private string LoginSectionCd = "";

        // 画面イメージコントロール部品
        private ControlScreenSkin ControlSreSkin = new ControlScreenSkin();

        // 日付取得部品
        private DateGetAcs GateGetAccess;

        // 入荷差異表アクセス
        private ArrGoodsDiffAcs ArrGoodsDiffAccess;
        
        #endregion ■ Private Member

        #region ■ Private Const
        #region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
        // クラスID
        private const string ClassID = "PMKOU02350UA";
        // プログラムID
        private const string PgId = "PMKOU02350U";
        // 帳票名称
        private const string PrintNm = "入荷差異表";
        // 帳票キー	
        private const string PrintKeyValue = "52a4913e-2c26-42b8-8ea9-3942c2ff9ff9";

        private const string InputError = "の入力が不正です。";
        private const string NoInput = "を入力して下さい。";
        private const string NotFound = "該当するデータがありません。";
        private const string NotFoundSupplier = "発注先が存在しません。";
        #endregion ◆ Interface member

        // ExporerBar グループ名称
        private const string ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";	// 抽出条件
        #endregion

        # region ■ Properties
        # region UOE発注先マスタアクセスクラス
        /// <summary>
        /// UOE発注先マスタアクセスクラス
        /// </summary>
        public UOESupplierAcs uOESupplierAcs
        {
            get { return ArrGoodsDiffAccess.uOESupplierAcs; }
        }
        # endregion
        # endregion ■ Properties

        #region ■ IPrintConditionInpType メンバ
        #region ◆ Public Event
        /// <summary> 親ツールバー設定イベント </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion ◆ Public Event

        #region ◆ Public Property
        /// <summary> 抽出ボタン状態取得プロパティ </summary>
        public bool CanExtract
        {
            get { return this.CanExtractField; }
        }

        /// <summary> PDF出力ボタン状態取得プロパティ </summary>
        public bool CanPdf
        {
            get { return this.CanPdfField; }
        }

        /// <summary> 印刷ボタン状態取得プロパティ </summary>
        public bool CanPrint
        {
            get { return this.CanPrintField; }
        }

        /// <summary> 抽出ボタン表示有無プロパティ </summary>
        public bool VisibledExtractButton
        {
            get { return this.VisibledExtractButtonField; }
        }

        /// <summary> PDF出力ボタン表示有無プロパティ </summary>
        public bool VisibledPdfButton
        {
            get { return this.VisibledPdfButtonField; }
        }

        /// <summary> 印刷ボタン表示プロパティ </summary>
        public bool VisibledPrintButton
        {
            get { return this.VisibledPrintButtonField; }
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
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : K2019/08/14</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            SFCMN06001U printDialog = new SFCMN06001U();            // 帳票選択ガイド
            SFCMN06002C printInfo = parameter as SFCMN06002C;	    // 印刷情報パラメータ

            // 企業コードをセット
            printInfo.enterpriseCode = this.EnterpriseCd;
            // 起動PGID
            printInfo.kidopgid = PgId;				

            // PDF出力履歴用
            printInfo.key = PrintKeyValue;
            printInfo.prpnm = PrintNm;
            printInfo.PrintPaperSetCd = 0;

            // プレビュー有無:有り
            printInfo.prevkbn = 1;
            // PDF作業用パス
            printInfo.pdftemppath = string.Empty;                   

            // 条件クラス
            ArrGoodsDiffCndtnWork extrInfo = new ArrGoodsDiffCndtnWork();

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
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, NotFound, 0);
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
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
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
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : K2019/08/14</br>
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
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : K2019/08/14</br>
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
            get { return PrintKeyValue; }
        }

        /// <summary> 帳票名プロパティ </summary>
        public string PrintName
        {
            get { return PrintNm; }
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
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : K2019/08/14</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                this.tde_InspectDateTime.SetDateTime(DateTime.Today);// 検品日
                this.tNedit_SupplierCd.Clear();// 発注先コード
                this.uLabel_UOESupplierName.Text = string.Empty;// 発注先名
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
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : K2019/08/14</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;
            DateGetAcs.CheckDateResult cdResult;

            //検品日
            if (CallCheckDate(out cdResult, ref tde_InspectDateTime) == false)
            {
                switch (cdResult)
                {
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            errMessage = string.Format("検品日{0}", InputError);
                            errComponent = this.tde_InspectDateTime;
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            errMessage = string.Format("検品日{0}", NoInput);
                            errComponent = this.tde_InspectDateTime;
                        }
                        break;
                }
                status = false;

            }

            return status;
        }

        /// <summary>
        /// Coopyチェック処理                                              
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : Copy文字時に発生します</br>                  
        /// <br>Programmer  : 譚洪</br>                                    
        /// <br>Date        : K2019/08/14</br>                                        
        /// </remarks>
        private void WordCopyCheck()
        {
            Regex r = new Regex(@"^\d+(\.)?\d*$");
            // 検品日は数字ではない場合
            if (!this.IsNumber(this.tde_InspectDateTime.Controls["YearEdit"].Text)
                           || !this.IsNumber(this.tde_InspectDateTime.Controls["MonthEdit"].Text)
                           || !this.IsNumber(this.tde_InspectDateTime.Controls["DayEdit"].Text))
            {
                this.tde_InspectDateTime.Clear();
            }
            // 発注先
            if (!String.IsNullOrEmpty(this.tNedit_SupplierCd.DataText.TrimEnd()) && !r.IsMatch(this.tNedit_SupplierCd.DataText))
            {
                this.tNedit_SupplierCd.Text = String.Empty;
                this.uLabel_UOESupplierName.Text = String.Empty;
            }
        }

        /// <summary>
        /// 数字文字があるのチェック
        /// </summary>
        /// <param name="inputStr">チェック文字</param>
        /// <returns>true:数字文字がある false:数字文字がありません</returns>
        /// <remarks>
        /// <br>Note		: 数字文字チェック処理。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: K2019/08/14</br>
        /// </remarks>
        public bool IsNumber(string inputStr)
        {
            string reg = "^[0-9]*$";
            Regex regex = new Regex(reg);
            return regex.IsMatch(inputStr);
        }

        /// <summary>
        /// 日付チェック処理呼び出し（発注日用 単独）
        /// </summary>
        /// <param name="cdResult"></param>
        /// <param name="targetDateEdit"></param>
        /// <returns></returns>
        private bool CallCheckDate(out DateGetAcs.CheckDateResult cdResult, ref TDateEdit targetDateEdit)
        {
            cdResult = GateGetAccess.CheckDate(ref targetDateEdit);
            return (cdResult == DateGetAcs.CheckDateResult.OK);
        }
        #endregion

        #region ◎ 抽出条件設定処理(画面→抽出条件)
        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <param name="extrInfo">抽出条件クラス</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : K2019/08/14</br>
        /// </remarks>
        private int SetExtraInfoFromScreen(ArrGoodsDiffCndtnWork extrInfo)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // 企業コード
                extrInfo.EnterpriseCode = this.EnterpriseCd;

                // 拠点コード
                extrInfo.LoginSectionCode = this.LoginSectionCd;

                // 検品日
                extrInfo.InspectDate = this.tde_InspectDateTime.GetDateTime();

                // 発注先
                extrInfo.UOESupplierCd = this.tNedit_SupplierCd.GetInt();
                extrInfo.UOESupplierNm = this.uLabel_UOESupplierName.Text.Trim();
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
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : K2019/08/14</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                ClassID,							// アセンブリＩＤまたはクラスＩＤ
                PrintNm,						// プログラム名称
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
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : K2019/08/14</br>
        /// </remarks>
        private void MsgDispProc(string message, int status, string procnm, Exception ex)
        {
            string errMessage = message + "\r\n" + ex.Message;

            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                ClassID,							// アセンブリＩＤまたはクラスＩＤ
                PrintNm,						// プログラム名称
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
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, this.Name, iMsg, iSt, iButton, iDefButton);
        }
        #endregion

        # region ◆ 発注先ガイドボタンクリックイベント
        /// <summary>
        /// 発注先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 発注先ガイドボタンクリックイベントときに発生する</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : K2019/08/14</br>
        /// </remarks>
        private void uButton_UOESupplierGuide_Click(object sender, EventArgs e)
        {
            int status = -1;
            // インスタンス生成
            UOESupplier uOESupplier = null;

            // ガイド起動
            status = uOESupplierAcs.ExecuteGuid(EnterpriseCd, LoginSectionCd, out uOESupplier);

            // 項目に展開
            if (status == 0)
            {
                this.tNedit_SupplierCd.SetInt(uOESupplier.UOESupplierCd);
                this.uLabel_UOESupplierName.Text = uOESupplier.UOESupplierName;
            }
        }
        # endregion ◆ 発注先ガイドボタンクリックイベント
        #endregion ■ Private Method

        #region ■ Control Event
        #region ◆ PMKOU02350UA
        #region ◎ PMKOU02350UA_Load Event
        /// <summary>
        /// PMKOU02350UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがフォームを読み込むときに発生する</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : K2019/08/14</br>
        /// </remarks>
        /// 
        private void PMKOU02350UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // 初期化タイマー起動
            Initialize_Timer.Enabled = true;

            // 画面イメージ統一
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this.ControlSreSkin.LoadSkin();

            // 画面スキン変更
            this.ControlSreSkin.SettingScreenSkin(this);

            ParentToolbarSettingEvent(this);						// ツールバーボタン設定イベント起動
        }
        #endregion
        #endregion ◆ PMKOU02350UA

        #region ◆ ueb_MainExplorerBar
        #region ◎ GroupCollapsing Event
        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroupが縮小される前に発生する。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : K2019/08/14</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if (e.Group.Key == ExBarGroupNm_PrintConditionGroup)
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
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : K2019/08/14</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if (e.Group.Key == ExBarGroupNm_PrintConditionGroup)
            {
                // グループの展開をキャンセル
                e.Cancel = true;
            }

        }
        #endregion
        #endregion ◆ ueb_MainExplorerBar Event

        #region ◎ tArrowKeyControl1_ChangeFocus Event
        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 矢印キー、TABキー、ENTERキーが押下された時に発生します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks> 
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            
            bool canChangeFocus;

            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "tde_InspectDateTime":
                    // Coopyチェック
                    WordCopyCheck();
                    break;

                case "tNedit_SupplierCd":
                    #region [ tNedit_SupplierCd ]
                    canChangeFocus = true;
                    // Coopyチェック
                    WordCopyCheck();

                    int code = this.tNedit_SupplierCd.GetInt();

                    //発注先クリア
                    if (code == 0)
                    {
                        this.uLabel_UOESupplierName.Text = "";
                    }
                    else if (ArrGoodsDiffAccess.UOESupplierExists(code) == true)
                    {
                        //名称セット
                        string uoeSupplierName = ArrGoodsDiffAccess.GetName_FromUOESupplier(code).Trim();
                        this.uLabel_UOESupplierName.Text = uoeSupplierName;
                    }
                    else
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            NotFoundSupplier,
                            -1,
                            MessageBoxButtons.OK);
                        this.tNedit_SupplierCd.Text = String.Empty;
                        this.uLabel_UOESupplierName.Text = String.Empty;
                        canChangeFocus = false;
                    }

                    // NextCtrl制御
                    if (canChangeFocus)
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_SupplierCd.GetInt() == 0)
                                        {
                                            e.NextCtrl = this.uButton_UOESupplierGuide;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tde_InspectDateTime;
                                        }
                                        break;
                                    }
                            }
                        }
                    }
                    else
                    {
                        e.NextCtrl = e.PrevCtrl;
                    }
                    #endregion
                    break;
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
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
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
                this.SetIconImage(this.uButton_UOESupplierGuide, Size16_Index.STAR1);
                ParentToolbarSettingEvent(this);	// ツールバー設定イベント
            }
            finally
            {
                // 初期フォーカス
                this.tde_InspectDateTime.Focus();

                this.Cursor = Cursors.Default;
            }
        }
        #endregion
        #endregion ◆ Initialize_Timer
    }
}
