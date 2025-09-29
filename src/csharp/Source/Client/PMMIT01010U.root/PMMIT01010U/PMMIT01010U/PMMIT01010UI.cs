using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 検索見積 印刷設定フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 検索見積の印刷設定を行うフォームクラスです。。</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2008.08.12</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2008.08.12 men 新規作成</br>
    /// </remarks>
	public partial class PMMIT01010UI : Form
    {

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region ■Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="estimateInputAcs">検索見積アクセスクラス</param>
        public PMMIT01010UI( EstimateInputAcs estimateInputAcs )
		{
			InitializeComponent();

            this._controlScreenSkin = new ControlScreenSkin();
            this._estimateInputAcs = estimateInputAcs;
            this._estimateInputInitDataAcs = EstimateInputInitDataAcs.GetInstance();

            this._estimateInputConstructionAcs = EstimateInputConstructionAcs.GetInstance();
            this._estimateInputInitData = new EstimateInputInitData();

            this._imageList16 = IconResourceManagement.ImageList16;
            this._backButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_Back"];
            this._entryAndPrintButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_EntryAndPrint"];

            this.tToolbarsManager_Main.ImageListSmall = this._imageList16;
            this._backButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            this._entryAndPrintButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINTOUT;
        }
        #endregion

        // ==================================================================================== //
        // プライベート変数
        // ==================================================================================== //
        #region ■Private Member

        private EstimateInputAcs _estimateInputAcs;
        private EstimateInputInitDataAcs _estimateInputInitDataAcs;
        private EstimateInputConstructionAcs _estimateInputConstructionAcs;
        private EstimateInputInitData _estimateInputInitData;
        private ControlScreenSkin _controlScreenSkin;

        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

        private ImageList _imageList16 = null;                                                  // イメージリスト
        private Infragistics.Win.UltraWinToolbars.ButtonTool _backButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _entryAndPrintButton;

        DialogResult _result = DialogResult.Cancel;

        private ConstantManagement.MethodResult _saveResult = ConstantManagement.MethodResult.ctFNC_NO_RETURN;
        private ConstantManagement.MethodResult _printResult = ConstantManagement.MethodResult.ctFNC_NO_RETURN;

        #endregion

        // ===================================================================================== //
        // デリゲート
        // ===================================================================================== //
        #region ■Delegate

        internal delegate void RefreshScreenEventHandler();

        #endregion

        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        #region ■Events

        internal event RefreshScreenEventHandler RefreshScreen;

        internal event EventHandler InitialScreen;

        internal event EventHandler Reload;

        internal event EventHandler InitialScreenAfterSave;

        #endregion

        // ===================================================================================== //
        // 列挙型
        // ===================================================================================== //
        #region ■Enums

        #endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        #region ■Properties

        /// <summary>データ保存結果</summary>
        internal ConstantManagement.MethodResult SaveResult
        {
            get { return _saveResult; }
        }

        /// <summary>データ印刷結果</summary>
        internal ConstantManagement.MethodResult PrintResult
        {
            get { return _printResult; }
        }

        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■Private Methods

        /// <summary>
        /// 画面設定処理
        /// </summary>
        /// <param name="salesSlip">売上データオブジェクト</param>
        private void SetDisplay(SalesSlip salesSlip)
        {
            try
            {
                this.tEdit_EstimateTitle1.BeginUpdate();
                this.tEdit_EstimateNote1.BeginUpdate();
                this.tEdit_EstimateNote2.BeginUpdate();
                this.tEdit_EstimateNote3.BeginUpdate();
                this.tComboEditor_ListPricePrintDiv.BeginUpdate();
                this.tComboEditor_EstimateDtCreateDiv.BeginUpdate();
                this.tComboEditor_PartsNoPrtCd.BeginUpdate();
                this.tComboEditor_RateUseCode.BeginUpdate();

                // 見積タイトル
                this.tEdit_EstimateTitle1.Text = salesSlip.EstimateTitle1;      
                // 見積備考1
                this.tEdit_EstimateNote1.Text = salesSlip.EstimateNote1;        
                // 見積備考2
                this.tEdit_EstimateNote2.Text = salesSlip.EstimateNote2;        
                // 見積備考3
                this.tEdit_EstimateNote3.Text = salesSlip.EstimateNote3;        
                // 定価印刷
                ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_ListPricePrintDiv, salesSlip.ListPricePrintDiv, true);
                // 品番印刷
                ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_PartsNoPrtCd, salesSlip.PartsNoPrtCd, true);
                // 見積データ作成
                ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_EstimateDtCreateDiv, salesSlip.EstimateDtCreateDiv, true);
                // 掛率使用区分
                ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_RateUseCode, salesSlip.RateUseCode, true);
                // 売価率
                this.tNedit_Rate.SetValue(salesSlip.SalesRate);

                if (salesSlip.RateUseCode == 1)
                {
                    this.tNedit_Rate.Visible = true;
                    this.uLabel_RateMark.Visible = true;
                }
                else
                {
                    this.tNedit_Rate.Visible = false;
                    this.uLabel_RateMark.Visible = false;
                }

                if (( this.tNedit_PrintCnt_All.GetInt() == 0 ) &&
                    ( this.tNedit_PrintCnt_Prime.GetInt() == 0 ) &&
                    ( this.tNedit_PrintCnt_Pure.GetInt() == 0 ) &&
                    ( this.tNedit_PrintCnt_Selected.GetInt() == 0 ) &&
                    ( salesSlip.EstimateDtCreateDiv == 1 ))
                {
                    this._entryAndPrintButton.SharedProps.Enabled = false;
                }
                else
                {
                    this._entryAndPrintButton.SharedProps.Enabled = true;
                }
            }
            finally
            {
                this.tEdit_EstimateTitle1.EndUpdate();
                this.tEdit_EstimateNote1.EndUpdate();
                this.tEdit_EstimateNote2.EndUpdate();
                this.tEdit_EstimateNote3.EndUpdate();
                this.tComboEditor_ListPricePrintDiv.EndUpdate();
                this.tComboEditor_EstimateDtCreateDiv.EndUpdate();
                this.tComboEditor_PartsNoPrtCd.EndUpdate();
                this.tComboEditor_RateUseCode.EndUpdate();
            }
        }

        #region 各区分値変更時処理

        /// <summary>
        /// 品番印刷区分変更処理
        /// </summary>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="isCache">キャッシュ有無</param>
        /// <returns>True:品番印刷区分変更有</returns>
        private bool ChangePartsNoPrtCd( ref SalesSlip salesSlip, bool isCache )
        {
            bool changePartsNoPrtCd = false;

            int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_PartsNoPrtCd, ComboEditorGetDataType.TAG);

            if (salesSlip.PartsNoPrtCd != code)
            {
                changePartsNoPrtCd = true;
            }

            if (changePartsNoPrtCd)
            {
                salesSlip.PartsNoPrtCd = code;

                if (isCache)
                {
                    this._estimateInputAcs.Cache(salesSlip);
                }
            }
            return changePartsNoPrtCd;
        }

        /// <summary>
        /// 定価印刷区分変更処理
        /// </summary>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="isCache">キャッシュ有無</param>
        /// <returns>True:定価印刷区分変更有</returns>
        private bool ChangeListPricePrintDiv( ref SalesSlip salesSlip, bool isCache )
        {
            bool changeListPricePrintDiv = false;

            int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_ListPricePrintDiv, ComboEditorGetDataType.TAG);

            if (salesSlip.ListPricePrintDiv != code)
            {
                changeListPricePrintDiv = true;
            }

            if (changeListPricePrintDiv)
            {
                salesSlip.ListPricePrintDiv = code;

                if (isCache)
                {
                    this._estimateInputAcs.Cache(salesSlip);
                }
            }
            return changeListPricePrintDiv;
        }

        /// <summary>
        /// 売価計算区分変更処理
        /// </summary>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="isCache">キャッシュ有無</param>
        /// <returns>True:売価計算区分変更有</returns>
        private bool ChangeRateUseCode( ref SalesSlip salesSlip, bool isCache )
        {
            bool changeRateUseCode = false;

            int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_RateUseCode, ComboEditorGetDataType.TAG);

            if (salesSlip.RateUseCode != code)
            {
                changeRateUseCode = true;
            }

            if (changeRateUseCode)
            {
                salesSlip.RateUseCode = code;

                if (isCache)
                {
                    this._estimateInputAcs.Cache(salesSlip);
                }
            }
            return changeRateUseCode;
        }

        /// <summary>
        /// 見積データ作成区分変更処理
        /// </summary>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="isCache">キャッシュ有無</param>
        /// <returns>True:見積データ作成区分変更有</returns>
        private bool ChangeEstimateDtCreateDiv( ref SalesSlip salesSlip, bool isCache )
        {
            bool changeEstimateDtCreateDiv = false;

            int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_EstimateDtCreateDiv, ComboEditorGetDataType.TAG);

            if (salesSlip.EstimateDtCreateDiv != code)
            {
                changeEstimateDtCreateDiv = true;
            }

            if (changeEstimateDtCreateDiv)
            {
                salesSlip.EstimateDtCreateDiv = code;

                if (isCache)
                {
                    this._estimateInputAcs.Cache(salesSlip);
                }
            }
            return changeEstimateDtCreateDiv;
        }

        #endregion

        /// <summary>
        /// 保存＆印刷前チェック
        /// </summary>
        /// <returns></returns>
        private bool CheckPrintAndSave()
        {
            bool checkResult = true;

            int makeData = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_EstimateDtCreateDiv, ComboEditorGetDataType.TAG);

            if (( this.tNedit_PrintCnt_All.GetInt() == 0 ) &&
                ( this.tNedit_PrintCnt_Pure.GetInt() == 0 ) &&
                ( this.tNedit_PrintCnt_Prime.GetInt() == 0 ) &&
                ( this.tNedit_PrintCnt_Selected.GetInt() == 0 ) &&
                ( makeData == 1 ))
            {
                TMsgDisp.Show(
                   this,
                   emErrorLevel.ERR_LEVEL_EXCLAMATION,
                   this.Name,
                   "見積データ作成、印刷部数のどちらかを指定して下さい。",
                   0,
                   MessageBoxButtons.OK);

                checkResult = false;
            }
            else if (( this.tNedit_PrintCnt_Pure.GetInt() != 0 ) ||
                     ( this.tNedit_PrintCnt_Prime.GetInt() != 0 ) ||
                     ( this.tNedit_PrintCnt_Selected.GetInt() != 0 ))
            {
                List<string> targetdataList;
                if (!this._estimateInputAcs.ExistPrintTargetData(this.tNedit_PrintCnt_Pure.GetInt(), this.tNedit_PrintCnt_Prime.GetInt(), this.tNedit_PrintCnt_Selected.GetInt(), out targetdataList))
                {
                    StringBuilder message = new StringBuilder();
                    message.Append("印刷対象となる明細が無い見積書があります。" + Environment.NewLine + Environment.NewLine);

                    foreach (string s in targetdataList)
                    {
                        message.Append(s + "\r\n");
                    }

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        message.ToString(),
                        0,
                        MessageBoxButtons.OK);

                    checkResult = false;
                }
            }

            return checkResult;
        }

        /// <summary>
        /// 印刷登録処理
        /// </summary>
        /// <returns>True:画面を閉じる</returns>
        private bool PrintAndSave()
        {
            this._saveResult = ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            this._printResult = ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            bool initialScreenAfterSave = false;
            bool initialScreen = false;
            bool reLoad = false;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                #region 前処理

                // 全明細の売上金額計算
                this._estimateInputAcs.CalsclateDetialSalesPrice();

                #endregion

                #region 保存処理

                // 見積データ作成「する」
                if (this._estimateInputAcs.SalesSlip.EstimateDtCreateDiv == 0)
                {
                    // 不要な行の削除
                    this._estimateInputAcs.AdjustSaveData();

                    string retMessage;
                    int status = this._estimateInputAcs.SaveDBData(this._enterpriseCode, this._estimateInputAcs.SalesSlip.SalesSlipNum, out retMessage);

                    this.RefreshScreenCall();

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {

                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);
                        this._saveResult = ConstantManagement.MethodResult.ctFNC_NORMAL;

                        if (this._estimateInputConstructionAcs.SaveInfoStoreValue == EstimateInputConstructionAcs.SaveInfoStore_ON)
                        {
                            // 見積入力用初期値クラスをシリアライズ
                            this._estimateInputInitData.EnterpriseCode = this._estimateInputAcs.SalesSlip.EnterpriseCode;
                            this._estimateInputInitData.CustomerCode = this._estimateInputAcs.SalesSlip.CustomerCode;
                            this._estimateInputInitData.Serialize();
                        }
                        initialScreenAfterSave = true;
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)             // 排他（別端末更新済）
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "現在、編集中の見積データは既に更新されています。" + "\r\n" + "\r\n" +
                            "最新の情報を取得します。",
                            -1,
                            MessageBoxButtons.OK);

                        reLoad = true;

                        this._saveResult = ConstantManagement.MethodResult.ctFNC_ERROR;

                        return true;
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)             // 排他（別端末物理削除済）
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "現在、編集中の見積データは既に削除されています。",
                            -1,
                            MessageBoxButtons.OK);

                        initialScreen = true;
                        this._saveResult = ConstantManagement.MethodResult.ctFNC_ERROR;
                        return true;
                    }
                    else if (status == 999)                                                             // 排他（別端末更新済）
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "保存に失敗しました。" + retMessage + "\r\n" + "\r\n" +
                            "申し訳ありませんが、再度処理を行ってください。",
                            -1,
                            MessageBoxButtons.OK);

                        initialScreen = true;

                        this._saveResult = ConstantManagement.MethodResult.ctFNC_ERROR;
                        return true;
                    }
                    else if (status == 811)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_STOPDISP,
                            this.Name,
                            "保存に失敗しました。（タイムアウトエラー）" + "\r\n" + "\r\n" + retMessage,
                            status,
                            MessageBoxButtons.OK);
                        this._saveResult = ConstantManagement.MethodResult.ctFNC_ERROR;

                        return false;
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_STOPDISP,
                            this.Name,
                            "保存に失敗しました。" + "\r\n"
                            + "\r\n" +
                            "シェアチェックエラー（企業ロック）です。" + "\r\n" +
                            "月次処理か、その他の業務を行っているため本処理は行えません。" + "\r\n" +
                            "再試行するか、しばらく待ってから再度処理を行ってください。",
                            status,
                            MessageBoxButtons.OK);
                        this._saveResult = ConstantManagement.MethodResult.ctFNC_ERROR;

                        return false;
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_STOPDISP,
                            this.Name,
                            "保存に失敗しました。" + "\r\n"
                            + "\r\n" +
                            "シェアチェックエラー（拠点ロック）です。" + "\r\n" +
                            "締処理か、処理が込み合っているためタイムアウトしました。" + "\r\n" +
                            "再試行するか、しばらく待ってから再度処理を行ってください。",
                            status,
                            MessageBoxButtons.OK);
                        this._saveResult = ConstantManagement.MethodResult.ctFNC_ERROR;

                        return false;
                    }
                    else
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_STOPDISP,
                            this.Name,
                            "保存に失敗しました。" + "\r\n" + "\r\n" + retMessage,
                            status,
                            MessageBoxButtons.OK);
                        this._saveResult = ConstantManagement.MethodResult.ctFNC_ERROR;

                        return false;
                    }
                }
                #endregion

                #region 印刷

                if (( this.tNedit_PrintCnt_All.GetInt() != 0 ) ||
                    ( this.tNedit_PrintCnt_Prime.GetInt() != 0 ) ||
                    ( this.tNedit_PrintCnt_Pure.GetInt() != 0 ) ||
                    ( this.tNedit_PrintCnt_Selected.GetInt() != 0 ))
                {
                    // 印刷データの取得
                    EstFmPrintCndtn estFmPrintCndtn = this._estimateInputAcs.GetPrintData(this.tNedit_PrintCnt_All.GetInt(), this.tNedit_PrintCnt_Pure.GetInt(), this.tNedit_PrintCnt_Prime.GetInt(), this.tNedit_PrintCnt_Selected.GetInt());
                        
                    if (estFmPrintCndtn == null)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_STOPDISP,
                            this.Name,
                            "印刷データがありません。",
                            -1,
                            MessageBoxButtons.OK);
                        initialScreenAfterSave = false;
                        initialScreen = false;
                        reLoad = false;

                        return false;
                    }

                    DCCMN02000UA slipPrintDialog = new DCCMN02000UA();
                    slipPrintDialog.ShowDialog(estFmPrintCndtn, false);

                    this._printResult = ConstantManagement.MethodResult.ctFNC_NORMAL;
                }

                #endregion
            }
            finally
            {
                this.Cursor = Cursors.Default;

                if (initialScreenAfterSave)
                {
                    if (this.InitialScreenAfterSave != null) this.InitialScreenAfterSave(this, new EventArgs());
                }
                if (initialScreen)
                {
                    if (this.InitialScreen != null) this.InitialScreen(this, new EventArgs());
                }
                else if (reLoad)
                {
                    if (this.Reload != null) this.Reload(this, new EventArgs());
                }
            }

            return true;
        }

        /// <summary>
        /// 画面再描画イベントコール
        /// </summary>
        private void RefreshScreenCall()
        {
            if (this.RefreshScreen != null)
            {
                this.RefreshScreen();
            }
        }
        #endregion

        // ===================================================================================== //
        // コントロールイベント
        // ===================================================================================== //
        #region ■Control Events
        /// <summary>
        /// 画面Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMMIT01010UK_Load( object sender, EventArgs e )
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            this.tNedit_PrintCnt_All.SetInt(0);
            this.tNedit_PrintCnt_Prime.SetInt(0);
            this.tNedit_PrintCnt_Pure.SetInt(0);
            this.tNedit_PrintCnt_Selected.SetInt(0);

            this.SetDisplay(this._estimateInputAcs.SalesSlip);

            this._printResult = ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            this._saveResult = ConstantManagement.MethodResult.ctFNC_NO_RETURN;
        }

        /// <summary>
        /// ChangeFocusイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl1_ChangeFocus( object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e )
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            SalesSlip salesSlipCurrent = this._estimateInputAcs.SalesSlip.Clone();
            if (salesSlipCurrent == null) return;

            SalesSlip salesSlip = salesSlipCurrent.Clone();

            switch (e.PrevCtrl.Name)
            {
                #region ●見積タイトル１
                case "tEdit_EstimateTitle1":
                    {
                        string estimateTitle1 = this.tEdit_EstimateTitle1.Text;
                        if (estimateTitle1 != salesSlipCurrent.EstimateTitle1)
                        {
                            salesSlip.EstimateTitle1 = estimateTitle1;
                        }
                        break;
                    }
                #endregion

                #region ●見積備考１
                case "tEdit_EstimateNote1":
                    {
                        string estimateNote1 = this.tEdit_EstimateNote1.Text;
                        if (estimateNote1 != salesSlipCurrent.EstimateNote1)
                        {
                            salesSlip.EstimateNote1 = estimateNote1;
                        }
                        break;
                    }
                #endregion

                #region ●見積備考２
                case "tEdit_EstimateNote2":
                    {
                        string estimateNote2 = this.tEdit_EstimateNote2.Text;
                        if (estimateNote2 != salesSlipCurrent.EstimateNote2)
                        {
                            salesSlip.EstimateNote2 = estimateNote2;
                        }
                        break;
                    }
                #endregion

                #region ●見積備考３
                case "tEdit_EstimateNote3":
                    {
                        string estimateNote3 = this.tEdit_EstimateNote3.Text;
                        if (estimateNote3 != salesSlipCurrent.EstimateNote3)
                        {
                            salesSlip.EstimateNote3 = estimateNote3;
                        }
                        break;
                    }
                #endregion

                #region ●品番印刷区分
                case "tComboEditor_PartsNoPrtCd":
                    {
                        this.tComboEditor_PartsNoPrtCd.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_PartsNoPrtCd_SelectionChangeCommitted);

                        this.ChangePartsNoPrtCd(ref salesSlip, false);

                        this.tComboEditor_PartsNoPrtCd.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_PartsNoPrtCd_SelectionChangeCommitted);
                        break;
                    }
                #endregion

                #region ●定価印刷区分
                case "tComboEditor_ListPricePrintDiv":
                    {
                        this.tComboEditor_ListPricePrintDiv.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_ListPricePrintDiv_SelectionChangeCommitted);

                        this.ChangeListPricePrintDiv(ref salesSlip, false);

                        this.tComboEditor_ListPricePrintDiv.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_ListPricePrintDiv_SelectionChangeCommitted);

                        break;
                    }
                #endregion

                #region ●売価計算区分
                case "tComboEditor_RateUseCode":
                    {
                        this.tComboEditor_RateUseCode.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_RateUseCode_SelectionChangeCommitted);

                        bool changeRateUseCode = this.ChangeRateUseCode(ref salesSlip, false);

                        this.tComboEditor_RateUseCode.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_RateUseCode_SelectionChangeCommitted);

                        if (changeRateUseCode)
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        if (salesSlip.RateUseCode == 1)
                                        {
                                            e.NextCtrl = this.tNedit_Rate;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tComboEditor_EstimateDtCreateDiv;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region ●見積データ作成区分
                case "tComboEditor_EstimateDtCreateDiv":
                    {
                        this.tComboEditor_EstimateDtCreateDiv.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_EstimateDtCreateDiv_SelectionChangeCommitted);

                        this.ChangeEstimateDtCreateDiv(ref salesSlip, false);

                        this.tComboEditor_EstimateDtCreateDiv.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_EstimateDtCreateDiv_SelectionChangeCommitted);
                        break;
                    }
                #endregion

                #region ●売価率
                case "tNedit_Rate":
                    {
                        double code = this.tNedit_Rate.GetValue();

                        if (code != salesSlipCurrent.SalesRate)
                        {
                            salesSlip.SalesRate = code;
                        }
                        break;
                    }
                #endregion

                #region ●印刷部数
                case "tNedit_PrintCnt_All":
                case "tNedit_PrintCnt_Pure":
                case "tNedit_PrintCnt_Prime":
                case "tNedit_PrintCnt_Selected":
                    {
                        this.SetDisplay(salesSlip);
                        break;
                    }
                #endregion
            }

            //---------------------------------------------------------------
            // メモリ上の内容と比較
            //---------------------------------------------------------------
            ArrayList arRetList = salesSlip.Compare(salesSlipCurrent);

            //---------------------------------------------------------------
            // 売上データ変更時
            //---------------------------------------------------------------
            if (arRetList.Count > 0)
            {
                // 売上データキャッシュ処理
                this._estimateInputAcs.Cache(salesSlip);

                // 売上データクラス→画面格納処理
                this.SetDisplay(salesSlip);

                // データ変更フラグプロパティをTrueにする
                this._estimateInputAcs.IsDataChanged = true;
            }
        }

        /// <summary>
        /// 品番印刷区分コンボボックス SelectionChangeCommittedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_PartsNoPrtCd_SelectionChangeCommitted( object sender, EventArgs e )
        {
            SalesSlip salesSlip = this._estimateInputAcs.SalesSlip;

            this.ChangePartsNoPrtCd(ref salesSlip, true);

            this.SetDisplay(salesSlip);
        }

        /// <summary>
        /// 定価印刷区分コンボボックス SelectionChangeCommittedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_ListPricePrintDiv_SelectionChangeCommitted( object sender, EventArgs e )
        {
            SalesSlip salesSlip = this._estimateInputAcs.SalesSlip;

            this.ChangeListPricePrintDiv(ref salesSlip, true);

            this.SetDisplay(salesSlip);
        }

        /// <summary>
        /// 売価計算区分コンボボックス SelectionChangeCommittedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_RateUseCode_SelectionChangeCommitted( object sender, EventArgs e )
        {
            SalesSlip salesSlip = this._estimateInputAcs.SalesSlip;

            this.ChangeRateUseCode(ref salesSlip, true);

            this.SetDisplay(salesSlip);
        }

        /// <summary>
        /// データ作成区分コンボボックス SelectionChangeCommittedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_EstimateDtCreateDiv_SelectionChangeCommitted( object sender, EventArgs e )
        {
            SalesSlip salesSlip = this._estimateInputAcs.SalesSlip;

            this.ChangeEstimateDtCreateDiv(ref salesSlip, true);

            this.SetDisplay(salesSlip);
        }

        /// <summary>
        /// ツールボタン クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tToolbarsManager_Main_ToolClick( object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e )
        {
            switch (e.Tool.Key)
            {
                // 戻る
                case "ButtonTool_Back":
                    {
                        this.Close();
                        break;
                    }
                // 印刷登録
                case "ButtonTool_EntryAndPrint":
                    {
                        if (this.CheckPrintAndSave())
                        {
                            if (this.PrintAndSave())
                            {
                                this._result = DialogResult.OK;
                                this.Close();
                            }
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// 印刷部数変更時発生イベント(全ての部数でこのイベントが発生）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tNedit_PrintCnt_All_ValueChanged( object sender, EventArgs e )
        {
            this.SetDisplay(this._estimateInputAcs.SalesSlip);
        }

        /// <summary>
        /// フォームクローズ後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void PMMIT01010UK_FormClosed( object sender, FormClosedEventArgs e )
        {
            DialogResult = this._result;
        }

        /// <summary>
        /// フォーム　キーダウンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMMIT01010UI_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        #endregion

    }
}