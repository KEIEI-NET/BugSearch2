using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 一式入力フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 一式入力のフォームクラスです。</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2007.11.12</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.11.12 20056 對馬 大輔 新規作成</br>
    /// </remarks>
    public partial class MAHNB01010UH : Form
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructor
        public MAHNB01010UH()
        {
            InitializeComponent();

            _salesSlipInputAcs = SalesSlipInputAcs.GetInstance();
            _salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs.GetInstance();
            this._completeInfoDataTable = _salesSlipInputAcs.CompleteInfoDataTable;

            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Close"];
            this._decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Decision"];
            this._undoButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Undo"];
        }
        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private SalesSlipInputAcs _salesSlipInputAcs;
        private SalesSlipInputInitDataAcs _salesSlipInputInitDataAcs;
        private SalesInputDataSet.CompleteInfoDataTable _completeInfoDataTable = null;
        private ImageList _imageList16 = null;									// イメージリスト
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;		// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _decisionButton;	// 確定ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _undoButton;		// 取消ボタン
        private DialogResult _dialogRes = DialogResult.Cancel;                  // ダイアログリザルト
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        # endregion

        // ===================================================================================== //
        // 各種コンポーネントイベント処理郡
        // ===================================================================================== //
        # region Event Methods
        /// <summary>
        /// フォームLoadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAHNB01010UH_Load(object sender, EventArgs e)
        {
            // ツールバーボタン初期設定
            this.ButtonInitialSetting();

            // 初期設定タイマー起動
            this.Initial_Timer.Enabled = true;

        }
        /// <summary>
        /// Timer.Tick イベント イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 指定された間隔の時間が経過したときに発生します。
        ///	                 この処理は、システムが提供するスレッド プール
        ///	                 スレッドで実行されます。</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // 初期設定タイマー解除
            this.Initial_Timer.Enabled = false;

            // 画面初期設定            
            this.SetInitialInput();

            // 初期フォーカス位置指定
            this.tNedit_CmpltGoodsMakerCd.Focus();
        }

        /// <summary>
        /// ツールバーボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                //--------------------------------------------
                // 終了
                //--------------------------------------------
                case "ButtonTool_Close":
                    {
                        this.SetDialogRes(DialogResult.Cancel);
                        this.CloseForm();
                        break;
                    }
                //--------------------------------------------
                // 確定
                //--------------------------------------------
                case "ButtonTool_Decision":
                    {
                        if (DecisionProc())
                        {
                            this.SetDialogRes(DialogResult.OK);
                            this.CloseForm();
                        }
                        break;
                    }
                //--------------------------------------------
                // 取消
                //--------------------------------------------
                case "ButtonTool_Undo":
                    {
                        this.ClearDisplay();
                        this.SetDisplayInfo();

                        break;
                    }
            }
        }

        /// <summary>
        /// フォームクローズイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAHNB01010UH_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = _dialogRes;
        }

        /// <summary>
        /// フォーカス移動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {

            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            double cnt = 0;
            int code = 0;
            string name = "";

            switch (e.PrevCtrl.Name)
            {
                //------------------------------------------------
                // メーカーコード
                //------------------------------------------------
                case "tNedit_CmpltGoodsMakerCd":
                    code = this.tNedit_CmpltGoodsMakerCd.GetInt();
                    name = "";

                    if (code != 0)
                    {
                        name = this._salesSlipInputInitDataAcs.GetName_FromMaker(code);

                        if (String.IsNullOrEmpty(name))
                        {
                            code = 0;
                            name = "";
                        }
                    }
                    else
                    {
                        code = 0;
                        name = "";
                    }
                    this._salesSlipInputAcs.SetCmpltMakerInfo(code, name);
                    
                    switch (e.Key)
                    {
                        case Keys.Return:
                            if ((code != 0) && (name != ""))
                            {
                                e.NextCtrl = this.tEdit_CmpltGoodsName;
                            }
                            break;
                    }
                    break;
                //------------------------------------------------
                // メーカー名称
                //------------------------------------------------
                case "tEdit_CmpltMakerName":
                    code = this.tNedit_CmpltGoodsMakerCd.GetInt();
                    name = this.tEdit_CmpltMakerName.Text;
                    this._salesSlipInputAcs.SetCmpltMakerInfo(code, name);

                    switch (e.Key)
                    {
                        case Keys.Return:
                            if ((code != 0) && (name != ""))
                            {
                                e.NextCtrl = this.tEdit_CmpltGoodsName;
                            }
                            break;
                    }
                    break;
                //------------------------------------------------
                // 一式名称
                //------------------------------------------------
                case "tEdit_CmpltGoodsName":
                    name = this.tEdit_CmpltGoodsName.Text;
                    this._salesSlipInputAcs.SetCmpltGoodsName(name);
                    break;
                //------------------------------------------------
                // 数量
                //------------------------------------------------
                case "tNedit_CmpltShipmentCnt":
                    cnt = (double)this.tNedit_CmpltShipmentCnt.GetValue();
                    this._salesSlipInputAcs.SetCmpltPriceInfo(this._salesSlipInputAcs.TargetRowNo, cnt);
                    break;
                //------------------------------------------------
                // 得意先注番
                //------------------------------------------------
                case "tEdit_CmpltPartySalSlNum":
                    name = this.tEdit_CmpltPartySalSlNum.Text;
                    this._salesSlipInputAcs.SetCmpltPartySalSlNum(name);
                    break;
                //------------------------------------------------
                // 備考
                //------------------------------------------------
                case "tEdit_CmpltNote":
                    name = this.tEdit_CmpltNote.Text;
                    this._salesSlipInputAcs.SetCmpltNote(name);
                    break;
            }

            this.SetDisplayInfo();
        
        }

        /// <summary>
        /// メーカーガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_CmpltGoodsMakerGuide_Click(object sender, EventArgs e)
        {
            MakerAcs makerAcs = new MakerAcs();
            MakerUMnt makerUMnt;

            int status = makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._salesSlipInputAcs.SetCmpltMakerInfo(makerUMnt.GoodsMakerCd, makerUMnt.MakerName);
                this.SetDisplayInfo();
            }
        }
        # endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        # region Private Methods
        /// <summary>
        /// 画面初期情報設定処理
        /// </summary>
        private void SetInitialInput()
        {
            // ヘッダ情報クリア処理
            this.ClearDisplay();

            // ヘッダ初期表示処理
            this.SetDisplayInfo();
        }

        /// <summary>
        /// 画面ヘッダクリア処理
        /// </summary>
        private void ClearDisplay()
        {
            this.tNedit_CmpltGoodsMakerCd.BeginUpdate();
            this.tEdit_CmpltMakerName.BeginUpdate();
            this.uButton_CmpltGoodsMakerGuide.BeginUpdate();
            this.tEdit_CmpltGoodsName.BeginUpdate();
            this.tNedit_CmpltShipmentCnt.BeginUpdate();
            this.tNedit_CmpltSalesUnPrcFl.BeginUpdate();
            this.tNedit_CmpltSalesMoney.BeginUpdate();
            this.tNedit_CmpltSalesUnitCost.BeginUpdate();
            this.tNedit_CmpltCost.BeginUpdate();
            this.tEdit_CmpltPartySalSlNum.BeginUpdate();
            this.tEdit_CmpltNote.BeginUpdate();
            
            try
            {
                this.tNedit_CmpltGoodsMakerCd.Clear();
                this.tEdit_CmpltMakerName.Clear();
                this.tEdit_CmpltGoodsName.Clear();
                this.tNedit_CmpltShipmentCnt.Clear();
                this.tNedit_CmpltSalesUnPrcFl.Clear();
                this.tNedit_CmpltSalesMoney.Clear();
                this.tNedit_CmpltSalesUnitCost.Clear();
                this.tNedit_CmpltCost.Clear();
                this.tEdit_CmpltPartySalSlNum.Clear();
                this.tEdit_CmpltNote.Clear();
            }
            finally
            {
                this.tNedit_CmpltGoodsMakerCd.EndUpdate();
                this.tEdit_CmpltMakerName.EndUpdate();
                this.uButton_CmpltGoodsMakerGuide.EndUpdate();
                this.tEdit_CmpltGoodsName.EndUpdate();
                this.tNedit_CmpltShipmentCnt.EndUpdate();
                this.tNedit_CmpltSalesUnPrcFl.EndUpdate();
                this.tNedit_CmpltSalesMoney.EndUpdate();
                this.tNedit_CmpltSalesUnitCost.EndUpdate();
                this.tNedit_CmpltCost.EndUpdate();
                this.tEdit_CmpltPartySalSlNum.EndUpdate();
                this.tEdit_CmpltNote.EndUpdate();
            }
        }

        /// <summary>
        /// 画面ヘッダ表示処理
        /// </summary>
        private void SetDisplayInfo()
        {

            this.tNedit_CmpltGoodsMakerCd.BeginUpdate();
            this.tEdit_CmpltMakerName.BeginUpdate();
            this.uButton_CmpltGoodsMakerGuide.BeginUpdate();
            this.tEdit_CmpltGoodsName.BeginUpdate();
            this.tNedit_CmpltShipmentCnt.BeginUpdate();
            this.tNedit_CmpltSalesUnPrcFl.BeginUpdate();
            this.tNedit_CmpltSalesMoney.BeginUpdate();
            this.tNedit_CmpltSalesUnitCost.BeginUpdate();
            this.tNedit_CmpltCost.BeginUpdate();
            this.tEdit_CmpltPartySalSlNum.BeginUpdate();
            this.tEdit_CmpltNote.BeginUpdate();

            try
            {
                this.tNedit_CmpltGoodsMakerCd.SetInt(TStrConv.StrToIntDef(this._completeInfoDataTable[_salesSlipInputAcs.TargetIndex].CmpltGoodsMakerCd.ToString(), 0));
                this.tEdit_CmpltMakerName.Text = this._completeInfoDataTable[_salesSlipInputAcs.TargetIndex].CmpltGoodsMakerNm.ToString();
                this.tEdit_CmpltGoodsName.Text = this._completeInfoDataTable[_salesSlipInputAcs.TargetIndex].CmpltGoodsName.ToString();
                this.tNedit_CmpltShipmentCnt.SetInt(TStrConv.StrToIntDef(this._completeInfoDataTable[_salesSlipInputAcs.TargetIndex].CmpltShipmentCnt.ToString(), 0));

                this.tNedit_CmpltSalesUnPrcFl.SetValue(TStrConv.StrToDoubleDef(this._completeInfoDataTable[_salesSlipInputAcs.TargetIndex].CmpltSalesUnPrcFl.ToString(),0));
                this.tNedit_CmpltSalesMoney.SetValue(TStrConv.StrToDoubleDef(this._completeInfoDataTable[_salesSlipInputAcs.TargetIndex].CmpltSalesMoney.ToString(), 0));
                this.tNedit_CmpltSalesUnitCost.SetValue(TStrConv.StrToDoubleDef(this._completeInfoDataTable[_salesSlipInputAcs.TargetIndex].CmpltSalesUnitCost.ToString(), 0));
                this.tNedit_CmpltCost.SetValue(TStrConv.StrToDoubleDef(this._completeInfoDataTable[_salesSlipInputAcs.TargetIndex].CmpltCost.ToString(), 0));
                this.tEdit_CmpltPartySalSlNum.Text = this._completeInfoDataTable[_salesSlipInputAcs.TargetIndex].CmpltPartySalSlNum.ToString();
                this.tEdit_CmpltNote.Text = this._completeInfoDataTable[_salesSlipInputAcs.TargetIndex].CmpltNote.ToString();
            }
            finally
            {
                this.tNedit_CmpltGoodsMakerCd.EndUpdate();
                this.tEdit_CmpltMakerName.EndUpdate();
                this.uButton_CmpltGoodsMakerGuide.EndUpdate();
                this.tEdit_CmpltGoodsName.EndUpdate();
                this.tNedit_CmpltShipmentCnt.EndUpdate();
                this.tNedit_CmpltSalesUnPrcFl.EndUpdate();
                this.tNedit_CmpltSalesMoney.EndUpdate();
                this.tNedit_CmpltSalesUnitCost.EndUpdate();
                this.tNedit_CmpltCost.EndUpdate();
                this.tEdit_CmpltPartySalSlNum.EndUpdate();
                this.tEdit_CmpltNote.EndUpdate();
            }

 
        }
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager1.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._decisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            this._undoButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;

            this.uButton_CmpltGoodsMakerGuide.ImageList = this._imageList16;
            this.uButton_CmpltGoodsMakerGuide.Appearance.Image = (int)Size16_Index.STAR1;
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        private void CloseForm()
        {
            this.Close();
        }

        /// <summary>
        /// ダイアログリザルト設定処理
        /// </summary>
        /// <param name="dialogRes">ダイアログリザルト</param>
        private void SetDialogRes(DialogResult dialogRes)
        {
            _dialogRes = dialogRes;
        }

        /// <summary>
        /// 確定処理
        /// </summary>
        private bool DecisionProc()
        {

            Control control = null;
            string message = null;
            if (!ScreenDataCheck(ref control, ref message))
            {
                TMsgDisp.Show(this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    message,
                    0,
                    MessageBoxButtons.OK);

                control.Focus();
                return false;
            }

            this._completeInfoDataTable[_salesSlipInputAcs.TargetIndex].CmpltGoodsMakerCd = this.tNedit_CmpltGoodsMakerCd.GetInt();
            this._completeInfoDataTable[_salesSlipInputAcs.TargetIndex].CmpltGoodsMakerNm = this.tEdit_CmpltMakerName.Text;
            this._completeInfoDataTable[_salesSlipInputAcs.TargetIndex].CmpltGoodsName = this.tEdit_CmpltGoodsName.Text;
            this._completeInfoDataTable[_salesSlipInputAcs.TargetIndex].CmpltShipmentCnt = this.tNedit_CmpltShipmentCnt.GetInt();

            this._completeInfoDataTable[_salesSlipInputAcs.TargetIndex].CmpltSalesMoney = (Int64)this.tNedit_CmpltSalesMoney.GetValue();
            this._completeInfoDataTable[_salesSlipInputAcs.TargetIndex].CmpltSalesUnitCost = (Int64)this.tNedit_CmpltSalesUnitCost.GetValue();
            this._completeInfoDataTable[_salesSlipInputAcs.TargetIndex].CmpltSalesUnPrcFl = (Int64)this.tNedit_CmpltSalesUnPrcFl.GetValue();
            this._completeInfoDataTable[_salesSlipInputAcs.TargetIndex].CmpltCost = (Int64)this.tNedit_CmpltCost.GetValue();

            this._completeInfoDataTable[_salesSlipInputAcs.TargetIndex].CmpltPartySalSlNum = this.tEdit_CmpltPartySalSlNum.Text;
            this._completeInfoDataTable[_salesSlipInputAcs.TargetIndex].CmpltNote = this.tEdit_CmpltNote.Text;

            return true;

        }

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果（true:OK／false:NG）</returns>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            bool result = true;

            // 一式名称
            if (tEdit_CmpltGoodsName.Text.Trim() == "")
            {
                control = tEdit_CmpltGoodsName;
                message = "一式名称が入力されていません。";
                return false;
            }
            // 数量
            if ((double)this.tNedit_CmpltShipmentCnt.GetValue() == 0)
            {
                control = tNedit_CmpltGoodsMakerCd;
                message = "数量が入力されていません。";
                return false;
            }

            return result;
        }
        # endregion

    }
}