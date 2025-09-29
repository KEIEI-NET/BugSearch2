//****************************************************************************//
// システム         : 送信前リスト
// プログラム名称   : 送信前リスト入力フォーム
// プログラム概要   : 送信前リスト入力フォームを実装します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/09/11  修正内容 : MAHNB02010U：入金確認表を参考に新規作成
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
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinTree;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 送信前リストフォームクラス
    /// </summary>
	public partial class PMUOE02031UA
    :   Form,
        IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
        IPrintConditionInpTypeSelectedSection,  // 帳票業務（条件入力）拠点選択
        IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region <IPrintConditionInpType メンバ/>

        /// <summary>親ツールバー設定イベント</summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;

        #region <抽出ボタン/> ※抽出ボタンなし

        /// <summary>
        /// 抽出ボタン状態取得プロパティ
        /// </summary>
        public bool CanExtract
        {
            get { return false; }
        }

        /// <summary>
        /// 抽出ボタン表示有無プロパティ
        /// </summary>
        public bool VisibledExtractButton
        {
            get { return false; }
        }

        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>0( 固定 )</returns>
        public int Extract(ref object parameter)
        {
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        #endregion  // <抽出ボタン/>

        #region <印刷ボタン/>

        /// <summary>
        /// 印刷ボタン状態取得プロパティ
        /// </summary>
        public bool CanPrint
        {
            get { return true; }
        }

        /// <summary>
        /// 印刷ボタン表示プロパティ
        /// </summary>
        public bool VisibledPrintButton
        {
            get { return true; }
        }

        #endregion  // <印刷ボタン/>

        #region <PDF表示ボタン/>

        /// <summary>
        /// PDF表示ボタン状態取得プロパティ
        /// </summary>
        public bool CanPdf
        {
            get { return true; }
        }

        /// <summary>
        /// PDF表示ボタン表示有無プロパティ
        /// </summary>
        public bool VisibledPdfButton
        {
            get { return true; }
        }

        #endregion  // <PDF表示ボタン/>

        #region <印刷前確認処理/>

        /// <summary>
        /// 印刷前確認処理
        /// </summary>
        /// <returns>
        /// <c>true</c> :OK<br/>
        /// <c>false</c>:NG
        /// </returns>
        public bool PrintBeforeCheck()
        {
            string errMessage = string.Empty;
            Control errComponent = null;
            if (!CheckScreenInput(ref errMessage, ref errComponent))
            {
                // メッセージを表示
                ShowErrorMessage(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, STATUS_OF_NORMAL);

                // エラーコントロールにフォーカス
                if (errComponent != null) errComponent.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// 画面入力をチェックします。
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <returns>
        /// <c>true</c> :OK<br/>
        /// <c>false</c>:NG
        /// </returns>
        private bool CheckScreenInput(
            ref string errMessage,
            ref Control errComponent
        )
        {
            const string THERE_IS_RANGE_ERROR_IN = "の範囲指定に誤りがあります";    // LITERAL:

            // 注文番号
            if (
                (!this.endOnlineNoTNedit.GetInt().Equals(0))
                    &&
                (this.startOnlineNoTNedit.GetInt() > this.endOnlineNoTNedit.GetInt())
            )
            {
                errMessage  = "注文番号" + THERE_IS_RANGE_ERROR_IN; // LITERAL:
                errComponent= this.startOnlineNoTNedit;
                return false;
            }

            // 発注先
            if (
                (!this.endUOESupplierCodeTNedit.GetInt().Equals(0))
                    &&
                (this.startUOESupplierCodeTNedit.GetInt() > this.endUOESupplierCodeTNedit.GetInt())
            )
            {
                errMessage  = "発注先" + THERE_IS_RANGE_ERROR_IN;   // LITERAL:
                errComponent= this.startUOESupplierCodeTNedit;
                 return false;
            }

            return true;
        }

        #endregion  // <印刷前確認処理/>

        #region <印刷処理/>

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>ステータス</returns>
        public int Print(ref object parameter)
        {
            const string PG_ID = "PMUOE02031U"; // HACK:プログラムID

            // 印刷情報パラメータ
            SFCMN06002C printInfo = parameter as SFCMN06002C;

            // 企業コードを設定
            printInfo.enterpriseCode = EnterpriseCode;
            printInfo.kidopgid = PG_ID; // 起動PGID

            // PDF出力履歴用
            printInfo.key   = PrintKey;
            printInfo.prpnm = PrintName;
            printInfo.PrintPaperSetCd = 0;  // UNDONE:Magic Number

            // 抽出条件
            SendBeforeOrderCondition extractionCondition = new SendBeforeOrderCondition();

            // 画面→抽出条件クラス
            int status = SetExtraInfoFromScreen(extractionCondition);
            if (!status.Equals((int)ConstantManagement.MethodResult.ctFNC_NORMAL))
            {
                return STATUS_OF_ERROR;
            }
            
            // 抽出条件の設定
            printInfo.jyoken = extractionCondition;

            // 帳票選択ガイド
            SFCMN06001U printDialog = new SFCMN06001U();
            printDialog.PrintInfo = printInfo;

            // 帳票選択ガイド
            DialogResult dialogResult = printDialog.ShowDialog();
            if (printInfo.status.Equals((int)ConstantManagement.MethodResult.ctFNC_NO_RETURN))
            {
                ShowErrorMessage(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", STATUS_OF_NORMAL);  // LITERAL:
            }

            parameter = printInfo;

            return printInfo.status;
        }

        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        private int SetExtraInfoFromScreen(SendBeforeOrderCondition extractionCondition)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // 企業コード
                extractionCondition.EnterpriseCode = EnterpriseCode;

                // システム区分
                extractionCondition.SystemDivCd = (int)this.systemDivCdComboEditor.SelectedItem.DataValue;

                // 開始オンライン番号
                extractionCondition.St_OnlineNo = this.startOnlineNoTNedit.GetInt();

                // 終了オンライン番号
                extractionCondition.Ed_OnlineNo = this.endOnlineNoTNedit.GetInt();

                // 選択拠点
                string[] sectionCodes = (string[])new ArrayList(SelectedSectionMap.Values).ToArray(typeof(string));
                extractionCondition.SectionCodes = sectionCodes;

                // 開始UOE発注先コード
                extractionCondition.St_UOESupplierCd = this.startUOESupplierCodeTNedit.GetInt();

                // 終了UOE発注先コード
                extractionCondition.Ed_UOESupplierCd = this.endUOESupplierCodeTNedit.GetInt();

                // 印刷順
                extractionCondition.PrintOrder = (SendBeforeOrderCondition.PrintOrderType)this.printOrderCommboEditor.SelectedItem.DataValue;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        #endregion  // <印刷処理/>

        #region <画面表示処理/>

        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <param name="parameter">起動パラメータ</param>
        public void Show(object parameter)
        {
            // Todo:起動パラメータを変更する場合はここで行う。
            this.Show();
            return;
        }

        #endregion  // <画面表示処理/>

        #endregion  // <IPrintConditionInpType メンバ/>

        #region <IPrintConditionInpTypeSelectedSection メンバ/>

        #region <本社機能有無/>

        /// <summary>本社機能有無</summary>
        private bool _isMainOfficeFunc;
        /// <summary>
        /// 本社機能有無プロパティ
        /// </summary>
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }

        #endregion  // <本社機能有無/>

        #region <拠点オプション有無/>

        /// <summary>拠点オプション有無</summary>
        private bool _isOptSection;
        /// <summary> 拠点オプションプロパティ </summary>
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        #endregion  // <拠点オプション有無/>

        #region <計上拠点選択表示/> ※計上拠点選択表示なし

        /// <summary>
        /// 計上拠点選択表示取得プロパティ
        /// </summary>
        public bool VisibledSelectAddUpCd
        {
            get { return false; }
        }

        /// <summary>
        /// 初期選択計上拠点設定処理
        /// </summary>
        /// <param name="addUpCd"></param>
        public void InitSelectAddUpCd(int addUpCd)
        {
            // 計上拠点選択がないので未実装
        }

        /// <summary>
        /// 計上拠点選択処理
        /// </summary>
        /// <param name="addUpCd"></param>
        public void SelectedAddUpCd(int addUpCd)
        {
            // 計上拠点選択がないので未実装
        }

        #endregion  // <計上拠点選択表示/>

        /// <summary>
        /// 拠点選択処理
        /// </summary>
        /// <param name="sectionCode">選択拠点コード</param>
        /// <param name="checkState">選択状態</param>
        public void CheckedSection(string sectionCode, CheckState checkState)
        {
            // 拠点を選択した時
            if (checkState.Equals(CheckState.Checked))
            {
                // 全社が選択された場合
                if (sectionCode.Trim().Equals("0") || sectionCode.Trim().Equals("00"))  // LITERAL:全社共通
                {
                    SelectedSectionMap.Clear();
                }

                if (!SelectedSectionMap.ContainsKey(sectionCode))
                {
                    SelectedSectionMap.Add(sectionCode, sectionCode);
                }
            }
            // 拠点選択を解除した時
            else if (checkState.Equals(CheckState.Unchecked))
            {
                if (SelectedSectionMap.ContainsKey(sectionCode))
                {
                    SelectedSectionMap.Remove(sectionCode);
                }
            }

        }

        /// <summary>
        /// 初期選択拠点設定処理
        /// </summary>
        /// <param name="sectionCodeLst">選択拠点コードリスト</param>
        public void InitSelectSection(string[] sectionCodeLst)
        {
            // 選択リスト初期化
            SelectedSectionMap.Clear();
            foreach (string sectionCode in sectionCodeLst)
            {
                SelectedSectionMap.Add(sectionCode, sectionCode);
            }
        }

        /// <summary>
        /// 初期拠点選択表示チェック処理
        /// </summary>
        /// <param name="isDefaultState">true：スライダー表示　false：スライダー非表示</param>
        /// <remarks>
        /// <br>Note		: 拠点選択スライダーの表示有無を判定する。</br>
        /// <br>			: 拠点オプション、本社機能以外の個別の表示有無判定を行う。</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.06</br>
        /// </remarks>
        public bool InitVisibleCheckSection(bool isDefaultState)
        {
            return isDefaultState;
        }

        #endregion  // <IPrintConditionInpTypeSelectedSection メンバ/>

        #region <IPrintConditionInpTypePdfCareer メンバ/>

        /// <summary>帳票キー</summary>
        private const string PRINT_KEY = "077369c7-6a45-4b34-a29e-1e0dbfe16baf";    // UNDONE:帳票キー
        /// <summary>
        /// 帳票キープロパティ
        /// </summary>
        public string PrintKey
        {
            get { return PRINT_KEY; }
        }

        /// <summary>帳票名称</summary>
        private const string PRINT_NAME = "送信前リスト";
        /// <summary>
        /// 帳票名称プロパティ
        /// </summary>
        public string PrintName
        {
            get { return PRINT_NAME; }
        }

        #endregion  // <IPrintConditionInpTypePdfCareer メンバ/>

        #region <企業コード/>

        /// <summary>企業コード</summary>
        private readonly string _enterpriseCode;
        /// <summary>
        /// 企業コードを取得します。
        /// </summary>
        /// <value>企業コード</value>
        private string EnterpriseCode { get { return _enterpriseCode; } }

        #endregion  // <企業コード/>

        #region <拠点コード/>

        /// <summary>拠点コード</summary>
        private readonly string _sectionCode;
        /// <summary>
        /// 拠点コードを取得します。
        /// </summary>
        /// <value>拠点コード</value>
        public string SectionCode { get { return _sectionCode; } }

        /// <summary>選択拠点マップ</summary>
        private readonly Dictionary<string, string> _selectedSectionMap;
        /// <summary>
        /// 選択拠点マップを取得します。
        /// </summary>
        /// <value>選択拠点マップ</value>
        private Dictionary<string, string> SelectedSectionMap { get { return _selectedSectionMap; } }

        #endregion  // <拠点コード/>

        #region <画面イメージコントロール部品/>

        /// <summary>画面イメージコントロール部品</summary>
        private readonly ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        /// <summary>
        /// 画面イメージコントロール部品を取得します。
        /// </summary>
        /// <value>画面イメージコントロール部品</value>
        private ControlScreenSkin ControlScreenSkin { get { return _controlScreenSkin; } }

        #endregion  // <画面イメージコントロール部品/>

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
		/// </summary>
		public PMUOE02031UA()
        {
            #region <Designer Code/>

            InitializeComponent();

            #endregion  // <Designer Code/>

            // 企業コード
			_enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 拠点コード
            _sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

			// 拠点用マップ
            _selectedSectionMap = new Dictionary<string, string>();
        }

        #endregion  // <Constructor/>

        #region <フォーム/>

        /// <summary>
        /// 送信前リストフォームのLoadイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void MAHNB02010UA_Load(object sender, EventArgs e)
        {
            // 初期化タイマー起動(リモートのリードが走るのでTimerで行う)
            this.initializeTimer.Enabled = true;

            // 画面イメージの統一
            ControlScreenSkin.LoadSkin();               // 画面スキンファイルの読込(デフォルトスキン指定)
            ControlScreenSkin.SettingScreenSkin(this);  // 画面スキン変更

            // 範囲指定ガイドのフォーカス制御オブジェクトの設定
            // 発注先：開始
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.startUOESupplierCodeTNedit,
                this.startUOESupplierCodeGuideButton,
                this.endUOESupplierCodeTNedit
            ));
            // 発注先：終了
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.endUOESupplierCodeTNedit,
                this.endUOESupplierCodeGuideButton,
                this.systemDivCdComboEditor
            ));
            // ガイドのフォーカス制御を開始
            foreach (GeneralRangeGuideUIController rangeGuideController in RangeGuideControllerList)
            {
                rangeGuideController.StartControl();
            }
        }

        #endregion  // <フォーム/>

        #region <初期化タイマ/>

        /// <summary>
        /// 初期化タイマのTickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void initializeTimer_Tick(object sender, EventArgs e)
        {
            this.initializeTimer.Enabled = false;
            string errMsg = string.Empty;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // システム区分
                this.systemDivCdComboEditor.SelectedIndex = 0;

                // 印刷順
                this.printOrderCommboEditor.SelectedIndex = 0;

                // ガイドボタンのアイコン設定
                SetGuideIconImage(this.startUOESupplierCodeGuideButton, Size16_Index.STAR1);
                SetGuideIconImage(this.endUOESupplierCodeGuideButton, Size16_Index.STAR1);

                // ツールバー設定イベント
                ParentToolbarSettingEvent(this);
            }
            finally
            {
                this.systemDivCdComboEditor.Focus();
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ガイドボタンアイコンを設定します。
        /// </summary>
        /// <param name="settingControl">アイコンセットするコントロール</param>
        /// <param name="iconIndex">アイコンインデックス</param>
        private static void SetGuideIconImage(
            object settingControl,
            Size16_Index iconIndex
        )
        {
            ((Infragistics.Win.Misc.UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((Infragistics.Win.Misc.UltraButton)settingControl).Appearance.Image = iconIndex;
        }

        #endregion  // <初期化タイマ/>

        #region <UOE発注先コードのガイドボタン/>

        /// <summary>UOE発注先コードのフォーマット</summary>
        private const string UOE_SUPPLIER_CODE_FORMAT = "000000";

        /// <summary>範囲指定ガイドのフォーカス制御オブジェクトのリスト</summary>
        private readonly IList<GeneralRangeGuideUIController> _rangeGuideControllerList = new List<GeneralRangeGuideUIController>();
        /// <summary>
        /// 範囲指定ガイドのフォーカス制御オブジェクトのリストを取得します。
        /// </summary>
        /// <value>範囲指定ガイドのフォーカス制御オブジェクトのリスト</value>
        private IList<GeneralRangeGuideUIController> RangeGuideControllerList
        {
            get { return _rangeGuideControllerList; }
        }

        /// <summary>
        /// 開始UOE発注先コードのガイドボタンのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void startUOESupplierCodeGuideButton_Click(object sender, EventArgs e)
        {
            ShowUOESupplierCodeGuide(sender, this.startUOESupplierCodeTNedit);
        }

        /// <summary>
        /// 終了UOE発注先コードのガイドボタンのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void endUOESupplierCodeGuideButton_Click(object sender, EventArgs e)
        {
            ShowUOESupplierCodeGuide(sender, this.endUOESupplierCodeTNedit);
        }

        /// <summary>
        /// UOE発注先コードガイドを表示します。
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="uoeSupplierCodeTextBox">UOE発注先コードを設定するテキストボックス</param>
        private void ShowUOESupplierCodeGuide(
            object sender,
            TNedit uoeSupplierCodeTextBox
        )
        {
            UOESupplier uoeSupplier = new UOESupplier();
            UOESupplierAcs uoeSupplierAcs = new UOESupplierAcs();

            // UOE発注先ガイド表示
            int status = uoeSupplierAcs.ExecuteGuid(EnterpriseCode, SectionCode, out uoeSupplier);
            if ((status.Equals((int)ConstantManagement.DB_Status.ctDB_NORMAL)) && (uoeSupplier != null))
            {
                if (uoeSupplier.UOESupplierCd > 0)
                {
                    uoeSupplierCodeTextBox.Value = uoeSupplier.UOESupplierCd.ToString(UOE_SUPPLIER_CODE_FORMAT);
                }
                else
                {
                    uoeSupplierCodeTextBox.Value = string.Empty;
                    ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS;
                }
            }
        }

        #endregion  // <UOE発注先コードのガイドボタン/>

        #region <メインエクスプローラーバー/>

        /// <summary>
        /// メインエクスプローラーバーのGroupCollapsingイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void mainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            e.Cancel = true;    // グループの縮小をキャンセル
        }

        #endregion  // <メインエクスプローラーバー/>

        #region <フォーカス移動/>

        /// <summary>
        /// 矢印キーコントールのChangeFocusイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void tArrowKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // 特になし
        }

        #endregion  // <フォーカス移動/>

        #region <エラーメッセージの表示処理/>

        /// <summary>正常</summary>
        private const int STATUS_OF_NORMAL = 0;
        /// <summary>異常</summary>
        private const int STATUS_OF_ERROR = -1;

        /// <summary>
        /// エラーメッセージを表示します。
        /// </summary>
        /// <param name="errorLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        private static void ShowErrorMessage(
            emErrorLevel errorLevel,
            string message,
            int status
        )
        {
            const string CLASS_ID = "PMUOE02031UA"; // HACK:クラスID

            TMsgDisp.Show(
                errorLevel, 						// エラーレベル
                CLASS_ID,							// アセンブリＩＤまたはクラスＩＤ
                PRINT_NAME,						    // プログラム名称
                string.Empty, 						// 処理名称
                string.Empty,						// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1     // 初期表示ボタン
            );
        }

        #endregion  // <エラーメッセージの表示処理/>
    }
}