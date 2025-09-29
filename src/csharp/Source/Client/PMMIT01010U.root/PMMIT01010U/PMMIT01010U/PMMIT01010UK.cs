using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 検索見積 発注選択入力フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 検索見積のUOE発注を行うフォームクラスです。</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2008.10.17</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2008.10.17 men 新規作成</br>
    /// <br>Update     : 2011/02/14 dingjx</br>
    /// <br>Note       : 発注選択時の数量チェック処理追加</br>
    /// <br>Update     : 2011/03/08 dingjx</br>
    /// <br>Note       : 障害報告 #19686</br>
    /// <br>Update Note  : 2013/04/22 donggy</br>
    /// <br>管理番号     : 10900691-00 2013/05/15配信分</br>
    /// <br>               Redmine#35020　「検索見積」の「発注選択画面」のガイド修正</br>
    /// </remarks>
    public partial class PMMIT01010UK : Form
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region ■Constructors

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMMIT01010UK(EstimateInputAcs estimateInputAcs)
        {
            InitializeComponent();

            this._estimateInputOrderSelectAcs = new EstimateInputOrderSelectAcs();
            this._uOESupplierAcs = new UOESupplierAcs();

            this._detailInput = new PMMIT01010UL(this._estimateInputOrderSelectAcs);
            this._detailInput.GridKeyDownTopRow += new EventHandler(this.DetailInput_GridKeyDownTopRow);
            this._detailInput.DetailDataChanged += new PMMIT01010UL.DetailDataChangedEventHandler(this.DetailDataChenged);

            this._controlScreenSkin = new ControlScreenSkin();
            this._currentUOESupplier = new UOESupplier();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._estimateInputInitDataAcs = EstimateInputInitDataAcs.GetInstance();

            this._imageList16 = IconResourceManagement.ImageList16;
            this._backButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_Back"];
            this._decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_Decision"];
            this._nextSupplierButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_NextSupplier"];
            this._orderCancelButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_OrderCancel"];
            this._guideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_Guide"];

            this.tToolbarsManager_Main.ImageListSmall = this._imageList16;
            this._backButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            this._decisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            this._nextSupplierButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.INDICATIONCHANGE;
            this._orderCancelButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.INTERRUPTION;
            this._guideButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
        }

        #endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region ■Privaete Members

        private string _enterpriseCode;
        private UOESupplierAcs _uOESupplierAcs;
        private UOESupplier _currentUOESupplier;
        private DialogResult _dialogResult = DialogResult.Cancel;
        private EstimateInputDataSet.UOEOrderDataTable _uoeOrderDataTable;
        private EstimateInputDataSet.UOEOrderDetailDataTable _uoeOrderDetailDataTable;

        private EstimateInputInitDataAcs _estimateInputInitDataAcs;
        private EstimateInputOrderSelectAcs _estimateInputOrderSelectAcs;

        private ImageList _imageList16 = null;                                                  // イメージリスト
        private Infragistics.Win.UltraWinToolbars.ButtonTool _backButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _decisionButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _nextSupplierButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _orderCancelButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;


        private PMMIT01010UL _detailInput;

        private ControlScreenSkin _controlScreenSkin;

        #region ■Static Members

        #endregion

        #endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        #region ■Properties
        /// <summary>ＵＯＥ発注データテーブル</summary>
        public EstimateInputDataSet.UOEOrderDataTable UOEOrderDataTable
        {
            get { return this._uoeOrderDataTable; }
        }

        /// <summary>ＵＯＥ発注明細データテーブル</summary>
        public EstimateInputDataSet.UOEOrderDetailDataTable UOEOrderDetailDataTable
        {
            get { return this._uoeOrderDetailDataTable; }
        }
        #endregion

        // ===================================================================================== //
        // パブリック メソッド
        // ===================================================================================== //
        #region ■Public Methods

        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <param name="owner">オーナーフォーム</param>
        /// <param name="estimateDetailDataTable">見積明細テーブル</param>
        /// <param name="primeInfoDataTable">優良データテーブル</param>
        /// <param name="uoeOrderDataTable"></param>
        /// <param name="uoeOrderDetailDataTable"></param>
        /// <returns></returns>
        public DialogResult ShowDialog(IWin32Window owner, EstimateInputDataSet.EstimateDetailDataTable estimateDetailDataTable, EstimateInputDataSet.PrimeInfoDataTable primeInfoDataTable, EstimateInputDataSet.UOEOrderDataTable uoeOrderDataTable, EstimateInputDataSet.UOEOrderDetailDataTable uoeOrderDetailDataTable)
        {
            this._estimateInputOrderSelectAcs.CreateOrderSelectDataTable(estimateDetailDataTable, primeInfoDataTable, uoeOrderDataTable, uoeOrderDetailDataTable);

            if (!this._estimateInputOrderSelectAcs.ExistData())
            {
                TMsgDisp.Show(
                   this,
                   emErrorLevel.ERR_LEVEL_EXCLAMATION,
                   this.Name,
                   "発注対象となるデータが存在しません。",
                   0,
                   MessageBoxButtons.OK);
                return DialogResult.None;
            }
            
            return this.ShowDialog(owner);
        }

        #endregion

        // ===================================================================================== //
        // プライベート メソッド
        // ===================================================================================== //
        #region ■Private Methods

        /// <summary>
        /// 明細グリッド最上位行キーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void DetailInput_GridKeyDownTopRow(object sender, EventArgs e)
        {
            tComboEditor_UOEResvdSection.Focus();
        }

        /// <summary>
        /// 画面描画処理
        /// </summary>
        /// <param name="rowIndex"></param>
        private void SetDisplay(int rowIndex)
        {
            Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Supplier.Rows[rowIndex];
            //DataRowView drv = this._orderSelectHdView[rowIndex];
            if (row == null)
            {
                return;
            }
            this.tNedit_UOESupplierCd.BeginUpdate();
            this.uLabel_UOESupplierName.BeginUpdate();
            this.tEdit_UoeRemark1.BeginUpdate();
            this.tEdit_UoeRemark2.BeginUpdate();
            this.tComboEditor_DeliveredGoodsDiv.BeginUpdate();
            this.tComboEditor_FollowDeliGoodsDiv.BeginUpdate();
            this.tComboEditor_UOEResvdSection.BeginUpdate();
            this.uLabel_DeliveredGoodsDivTitle.BeginUpdate();
            this.uLabel_FollowDeliGoodsDivTitle.BeginUpdate();
            this.uLabel_UOEResvdSectionTitle.BeginUpdate();

            UOESupplier uOESupplier = (UOESupplier)row.Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOESupplier].Value;
            if (uOESupplier == null) uOESupplier = new UOESupplier();
            try
            {
                this.tNedit_UOESupplierCd.SetInt((int)row.Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOESupplierCd].Value);
                this.uLabel_UOESupplierName.Text = ( (string)row.Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOESupplierName].Value );
                this.tEdit_UoeRemark1.Text = ( (string)row.Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UoeRemark1].Value );
                this.tEdit_UoeRemark2.Text = ( (string)row.Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UoeRemark2].Value );
                ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_DeliveredGoodsDiv, ( (string)row.Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOEDeliGoodsDiv].Value ).ToString(), true);
                ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_FollowDeliGoodsDiv, (string)row.Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_FollowDeliGoodsDiv].Value, true);
                ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_UOEResvdSection, (string)row.Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOEResvdSection].Value, true);

                this.tEdit_UoeRemark1.Visible = UOESupplierAcs.EnabledUOERemark1(uOESupplier.CommAssemblyId);
                this.tEdit_UoeRemark1.MaxLength = UOESupplierAcs.MaxLengthUOERemark1(uOESupplier.CommAssemblyId);
                this.tEdit_UoeRemark2.Visible = UOESupplierAcs.EnabledUOERemark2(uOESupplier.CommAssemblyId);
                this.tEdit_UoeRemark2.MaxLength = UOESupplierAcs.MaxLengthUOERemark2(uOESupplier.CommAssemblyId);
                this.tComboEditor_DeliveredGoodsDiv.Visible= UOESupplierAcs.EnabledDeliveredGoodsDiv(uOESupplier.CommAssemblyId);
                this.uLabel_DeliveredGoodsDivTitle.Visible = UOESupplierAcs.EnabledDeliveredGoodsDiv(uOESupplier.CommAssemblyId);
                this.tComboEditor_FollowDeliGoodsDiv.Visible = UOESupplierAcs.EnabledFollowDeliGoodsDiv(uOESupplier.CommAssemblyId);
                this.uLabel_FollowDeliGoodsDivTitle.Visible = UOESupplierAcs.EnabledFollowDeliGoodsDiv(uOESupplier.CommAssemblyId);
                this.tComboEditor_UOEResvdSection.Visible = UOESupplierAcs.EnabledUOEResvdSection(uOESupplier.CommAssemblyId);
                this.uLabel_UOEResvdSectionTitle.Visible = UOESupplierAcs.EnabledUOEResvdSection(uOESupplier.CommAssemblyId);
            }
            finally
            {
                this.tNedit_UOESupplierCd.EndUpdate();
                this.uLabel_UOESupplierName.EndUpdate();
                this.tEdit_UoeRemark1.EndUpdate();
                this.tEdit_UoeRemark2.EndUpdate();
                this.tComboEditor_DeliveredGoodsDiv.EndUpdate();
                this.tComboEditor_FollowDeliGoodsDiv.EndUpdate();
                this.tComboEditor_UOEResvdSection.EndUpdate();
                this.uLabel_DeliveredGoodsDivTitle.EndUpdate();
                this.uLabel_FollowDeliGoodsDivTitle.EndUpdate();
                this.uLabel_UOEResvdSectionTitle.EndUpdate();
            }
        }


        /// <summary>
        /// ツールバーボタンEnabled設定
        /// </summary>
        /// <br>Update Note: 2013/04/22 donggy</br>
        /// <br>管理番号   : 10900691-00 2013/05/15配信分</br>
        /// <br>             Redmine#35020　「検索見積」の「発注選択画面」のガイド修正</br>
        private void SettingToolBarButtonEnabled(Control nextContrl)
        {
            if (this.uGrid_Supplier.ActiveRow != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Supplier.Rows[this.uGrid_Supplier.ActiveRow.Index];
                this._orderCancelButton.SharedProps.Enabled = ( (bool)row.Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_ExistOrder].Value );

                //DataRowView drv = this._orderSelectHdView[this.uGrid_Supplier.ActiveRow.Index];
                //this._orderCancelButton.SharedProps.Enabled = ( (bool)drv[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_ExistOrder] );
            }
            else
            {
                this._orderCancelButton.SharedProps.Enabled = false;
            }
            this._guideButton.SharedProps.Enabled = ( ( nextContrl == this.tNedit_UOESupplierCd ) || ( nextContrl == this.uButton_UOESupplierGuide ) );
            // --- ADD donggy 2013/04/22 for Redmine#35020 --->>>>>
            // フォーカスが発注先コードテキストボックス・発注先ガイドにある場合
            if ((this.tNedit_UOESupplierCd.Focused
                || this.uButton_UOESupplierGuide.Focused)
                && nextContrl.Equals(this.uGrid_Supplier))
            {
                this._guideButton.SharedProps.Enabled = true;
            }
            // --- ADD donggy 2013/04/22 for Redmine#35020 ---<<<<<
        }
        /// <summary>
        /// 各コンボエディタの設定
        /// </summary>
        /// <param name="uoeSupplier"></param>
        private void ComboEditorSetting(int rowIndex)
        {
            this.ComboEditorSetting((UOESupplier)this.uGrid_Supplier.Rows[rowIndex].Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOESupplier].Value);
        }

        /// <summary>
        /// 各コンボエディタの設定
        /// </summary>
        /// <param name="uoeSupplier"></param>
        private void ComboEditorSetting(UOESupplier uoeSupplier)
        {
            // 納品区分のコンボエディタアイテム設定
            this._estimateInputInitDataAcs.SetUOEGuideNameComboEditor(ref this.tComboEditor_DeliveredGoodsDiv, EstimateInputInitDataAcs.ctUOEGuideDivCd_DeliveredGoodsDiv, uoeSupplier.UOESupplierCd);
            // Ｈ納品区分のコンボエディタアイテム設定
            this._estimateInputInitDataAcs.SetUOEGuideNameComboEditor(ref this.tComboEditor_FollowDeliGoodsDiv, EstimateInputInitDataAcs.ctUOEGuideDivCd_DeliveredGoodsDiv, uoeSupplier.UOESupplierCd);
            // 指定拠点のコンボエディタアイテム設定
            this._estimateInputInitDataAcs.SetUOEGuideNameComboEditor(ref this.tComboEditor_UOEResvdSection, EstimateInputInitDataAcs.ctUOEGuideDivCd_UOEResvdSection, uoeSupplier.UOESupplierCd);
        }

        /// <summary>
        /// 納品区分変更処理
        /// </summary>
        /// <param name="index"></param>
        /// <returns>True:納品区分変更有</returns>
        private bool ChangeDeliveredGoodsDiv(int index)
        {
            if (( this.tComboEditor_DeliveredGoodsDiv.Items == null ) ||
                ( this.tComboEditor_DeliveredGoodsDiv.Items.Count == 0 ))
            {
                return false;
            }

            bool isChanged = false;

            DataRow row = this._estimateInputOrderSelectAcs.GetOrderSelectHeaderRow((int)this.uGrid_Supplier.Rows[index].Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd].Value);

            string oldValue = (string)row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOEDeliGoodsDiv];
            string newValue = (string)tComboEditor_DeliveredGoodsDiv.SelectedItem.DataValue;

            if (oldValue != newValue)
            {
                isChanged = true;
                string newName = ComboEditorItemControl.GetComboEditorText(this.tComboEditor_DeliveredGoodsDiv, newValue);

                row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOEDeliGoodsDiv] = newValue;
                row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_DeliveredGoodsDivNm] = newName;
                //row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOEDeliGoodsDiv] = newCode;
                //row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_DeliveredGoodsDivNm] = newName;
            }

            return isChanged;
        }

        /// <summary>
        /// H納品区分変更処理
        /// </summary>
        /// <param name="index"></param>
        /// <returns>True:H納品区分変更有</returns>
        private bool ChangeFollowDeliGoodsDiv(int index)
        {
            if (( this.tComboEditor_FollowDeliGoodsDiv.Items == null ) ||
                ( this.tComboEditor_FollowDeliGoodsDiv.Items.Count == 0 ))
            {
                return false;
            }

            DataRow row = this._estimateInputOrderSelectAcs.GetOrderSelectHeaderRow((int)this.uGrid_Supplier.Rows[index].Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd].Value);

            bool isChanged = false;
            string oldCode = (string)row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_FollowDeliGoodsDiv];
            string newValue = (string)tComboEditor_FollowDeliGoodsDiv.SelectedItem.DataValue;

            if (oldCode != newValue)
            {
                isChanged = true;
                row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_FollowDeliGoodsDiv] = newValue;
                row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_FollowDeliGoodsDivNm] = tComboEditor_FollowDeliGoodsDiv.SelectedItem.DisplayText;
            }

            return isChanged;
        }

        /// <summary>
        /// 指定拠点変更処理
        /// </summary>
        /// <param name="index"></param>
        /// <returns>True:H納品区分変更有</returns>
        private bool ChangeUOEResvdSection(int index)
        {
            if (( this.tComboEditor_UOEResvdSection.Items == null ) ||
                ( this.tComboEditor_UOEResvdSection.Items.Count == 0 ))
            {
                return false;
            }

            DataRow row = this._estimateInputOrderSelectAcs.GetOrderSelectHeaderRow((int)this.uGrid_Supplier.Rows[index].Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd].Value);

            bool isChanged = false;
            string oldCode = (string)row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOEResvdSection];
            string newValue = (string)tComboEditor_UOEResvdSection.SelectedItem.DataValue;
            if (oldCode != newValue)
            {
                isChanged = true;

                string newName = ComboEditorItemControl.GetComboEditorText(this.tComboEditor_UOEResvdSection, newValue);
                row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOEResvdSection] = newValue;
                row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOEResvdSectionNm] = tComboEditor_UOEResvdSection.SelectedItem.DisplayText;
            }

            return isChanged;
        }

        /// <summary>
        /// 次仕入先選択
        /// </summary>
        private void SelectNextSupplier()
        {
            if (this.uGrid_Supplier.ActiveRow != null)
            {
                int rowIndex = 0;
                if (( this.uGrid_Supplier.ActiveRow.Index + 1 ) < this.uGrid_Supplier.Rows.Count)
                {
                    rowIndex = this.uGrid_Supplier.ActiveRow.Index + 1;
                }
                this.uGrid_Supplier.Rows[rowIndex].Selected = true;
                this.uGrid_Supplier.ActiveRow = this.uGrid_Supplier.Rows[rowIndex];

            }
        }

        /// <summary>
        /// 明細変更時イベント
        /// </summary>
        /// <param name="supplierCd">仕入先</param>
        private void DetailDataChenged(int supplierCd)
        {
            this._estimateInputOrderSelectAcs.DetailDataChenged(supplierCd);
            
            this.SettingGrid();
        }

        /// <summary>
        /// 明細グリッド設定処理
        /// </summary>
        internal void SettingGrid()
        {
            try
            {
                // 描画を一時停止
                this.uGrid_Supplier.BeginUpdate();

                // 描画が必要な明細件数を取得する。
                int cnt = this.uGrid_Supplier.Rows.Count;

                // 各行ごとの設定
                for (int i = 0; i < cnt; i++)
                {
                    this.SettingGridRow(i);
                }
            }
            finally
            {
                // 描画を開始
                this.uGrid_Supplier.EndUpdate();
            }
        }

        /// <summary>
        /// 明細グリッド・行単位でのセル設定
        /// </summary>
        /// <param name="rowIndex">対象行インデックス</param>
        /// <param name="stockSlip">仕入データクラスオブジェクト</param>
        private void SettingGridRow(int rowIndex)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Supplier.DisplayLayout.Bands[0];
            if (editBand == null) return;

            // 指定行の全ての列に対して設定を行う。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // セル情報を取得
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Supplier.Rows[rowIndex].Cells[col];
                if (cell == null) continue;

                cell.Row.Hidden = false;

                // アンダーラインを全てのセルに対して非表示とする
                cell.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.False;

                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                // 発注有無を取得
                bool existOrder = (bool)this.uGrid_Supplier.Rows[rowIndex].Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_ExistOrder].Value;

                #region セルアイコンセット

                if (cell.Column.Key == EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_ExistOrderDisplay)
                {
                    if (existOrder)
                    {
                        cell.Appearance.Image = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                    }
                    else
                    {
                        cell.Appearance.Image = null;
                    }
                }
                #endregion
            }
        }

        //  ADD 2011/02/14  >>>
        /// <summary>
        /// 発注選択時の数量チェック
        /// </summary>
        private bool OrderSelectCheck()
        {
            bool flag = false;
            string eMessage = null;

            for (int i = 0; i < this._estimateInputOrderSelectAcs.HeaderView.Count; i++)
            {
                int supplierCd = (int)this._estimateInputOrderSelectAcs.HeaderView[i].Row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd];
                String supplierName = (this._estimateInputOrderSelectAcs.HeaderView[i].Row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierSnm]).ToString();

                string message = this._estimateInputOrderSelectAcs.CheckDetail(supplierCd);
                if (message != null)
                {
                    eMessage += "\r\n  仕入先  " + supplierName + "\r\n";
                    eMessage += message;
                }
            }

            // ADD 2011/03/08   >>>
            DataRow row = this._estimateInputOrderSelectAcs.GetOrderSelectHeaderRow((int)this.uGrid_Supplier.Rows[this.uGrid_Supplier.ActiveRow.Index].Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd].Value);
            int tempSupplier = (int)row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd];
            this._estimateInputOrderSelectAcs.ChangeSupplier(tempSupplier);
            // ADD 2011/03/08   <<<

            if (eMessage != null)
            {
                flag = true;
                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "発注数は999以内で入力して下さい。\r\n" + eMessage,
                                    -1,
                                    MessageBoxButtons.OK);
            }
            
            return flag;
        }
        //  ADD 2011/02/14  <<<

        #endregion

        // ===================================================================================== //
        // コントロールのイベント
        // ===================================================================================== //
        #region ■Control Events

        /// <summary>
        /// フォーム Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMMIT01010UK_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            this._controlScreenSkin.SettingScreenSkin(this._detailInput);

            this.uGrid_Supplier.DataSource = this._estimateInputOrderSelectAcs.HeaderView;

            //this.uGrid_Supplier.DataSource = this._orderSelectHdTable;

            //this._detailInput.DataSource = this._orderSelectDtlTable;

            this.panel_Detail.Controls.Add(this._detailInput);
            this._detailInput.Dock = DockStyle.Fill;

            this.uGrid_Supplier.Rows[0].Selected = true;
            this.uGrid_Supplier.ActiveRow = this.uGrid_Supplier.Rows[0];
            this.SettingToolBarButtonEnabled(this.uGrid_Supplier);

            this.uButton_UOESupplierGuide.ImageList = this._imageList16;
            this.uButton_UOESupplierGuide.Appearance.Image = (int)Size16_Index.STAR1;

            this.SettingGrid();
        }

        /// <summary>
        /// フォーム Closedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMMIT01010UK_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = this._dialogResult;
        }

        /// <summary>
        /// ChangeFocusイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note: 2013/04/22 donggy</br>
        /// <br>管理番号   : 10900691-00 2013/05/15配信分</br>
        /// <br>             Redmine#35020　「検索見積」の「発注選択画面」のガイド修正</br>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            bool isChanged = false;
            if (this._detailInput.Contains(e.PrevCtrl))
            {
                switch (e.PrevCtrl.Name)
                {
                    #region 明細グリッド
                    //---------------------------------------------------------------
                    // 明細グリッド
                    //---------------------------------------------------------------
                    case "uGrid_Details":
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                    {
                                        if (this._detailInput.uGrid_Details.ActiveCell != null)
                                        {
                                            if (this._detailInput.ReturnKeyDown())
                                            {
                                                e.NextCtrl = null;
                                            }
                                        }

                                        break;
                                    }
                            }
                            break;
                        }
                    #endregion
                }
            }
            else
            {
                int index = this.uGrid_Supplier.ActiveRow.Index;
                DataRow row = this._estimateInputOrderSelectAcs.GetOrderSelectHeaderRow((int)this.uGrid_Supplier.Rows[index].Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd].Value);
                //DataRowView row = this._orderSelectHdView[index];
                switch (e.PrevCtrl.Name)
                {
                    #region 発注先コード
                    case "tNedit_UOESupplierCd":
                        {
                            bool isError = false;

                            int supplierCd = (int)row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd];
                            int oldCode = (int)row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOESupplierCd];
                            int newCode = this.tNedit_UOESupplierCd.GetInt();
                            if (oldCode != newCode)
                            {
                                UOESupplier uOESupplier = new UOESupplier();
                                if (newCode == 0)
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "発注先が入力されていません。",
                                        -1,
                                        MessageBoxButtons.OK);
                                    e.NextCtrl = e.PrevCtrl;
                                    isError = true;
                                }
                                else if (newCode != 0)
                                {
                                    int status = this._uOESupplierAcs.Read(out uOESupplier, this._enterpriseCode, newCode, LoginInfoAcquisition.Employee.BelongSectionCode);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                    }
                                    else
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "該当する発注先が存在しません。",
                                            -1,
                                            MessageBoxButtons.OK);
                                        e.NextCtrl = e.PrevCtrl;

                                        isError = true;
                                    }
                                }
                                else
                                {
                                    uOESupplier = new UOESupplier();
                                }

                                if (!isError)
                                {
                                    //this.UOESupplierInfoDefaultSetting(supplierCd, uOESupplier);
                                    this._estimateInputOrderSelectAcs.UOESupplierInfoDefaultSetting(supplierCd, uOESupplier);
                                    this._estimateInputOrderSelectAcs.DetailOrderCancel(supplierCd);
                                    this._detailInput.SettingGrid();
                                    this.ComboEditorSetting(uOESupplier);
                                    this._estimateInputOrderSelectAcs.DetailDataChenged(supplierCd);
                                    this.SettingGridRow(index);
                                    this._detailInput.UOESupplier = uOESupplier;
                                }
                                isChanged = true;
                            }

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if ((int)row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOESupplierCd] == 0)
                                            {
                                                e.NextCtrl = this.uButton_UOESupplierGuide;
                                            }
                                            else if (!isError)
                                            {
                                                e.NextCtrl = this.tEdit_UoeRemark1;
                                            }
                                            break;
                                        }
                                    default:
                                        break;
                                }
                            }
                            break;
                        }
                    #endregion

                    #region 発注先ガイド
                    case "uButton_UOESupplierGuide":
                        {
                            break;
                        }
                    #endregion

                    #region ＵＯＥリマーク１
                    case "tEdit_UoeRemark1":
                        {
                            string oldValue = (string)row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UoeRemark1];
                            string newValue = tEdit_UoeRemark1.Text;

                            if (newValue != oldValue)
                            {
                                row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UoeRemark1] = newValue;
                                isChanged = true;
                            }
                            
                            break;
                        }
                    #endregion

                    #region ＵＯＥリマーク２
                    case "tEdit_UoeRemark2":
                        {
                            string oldValue = (string)row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UoeRemark2];
                            string newValue = tEdit_UoeRemark2.Text;
                            if (newValue != oldValue)
                            {
                                row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UoeRemark2] = newValue;
                                isChanged = true;
                            }
                            break;
                        }
                    #endregion

                    #region 納品区分
                    case "tComboEditor_DeliveredGoodsDiv":
                        {
                            this.tComboEditor_DeliveredGoodsDiv.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_DeliveredGoodsDiv_SelectionChangeCommitted);

                            isChanged = this.ChangeDeliveredGoodsDiv(index);

                            this.tComboEditor_DeliveredGoodsDiv.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_DeliveredGoodsDiv_SelectionChangeCommitted);
                            break;
                        }
                    #endregion

                    #region フォロー納品区分
                    case "tComboEditor_FollowDeliGoodsDiv":
                        {
                            this.tComboEditor_FollowDeliGoodsDiv.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_FollowDeliGoodsDiv_SelectionChangeCommitted);

                            isChanged = this.ChangeFollowDeliGoodsDiv(index);

                            this.tComboEditor_FollowDeliGoodsDiv.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_FollowDeliGoodsDiv_SelectionChangeCommitted);
                            break;
                        }
                    #endregion

                    #region 指定拠点
                    case "tComboEditor_UOEResvdSection":
                        {
                            this.tComboEditor_UOEResvdSection.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_UOEResvdSection_SelectionChangeCommitted);

                            isChanged = this.ChangeUOEResvdSection(index);

                            this.tComboEditor_UOEResvdSection.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_UOEResvdSection_SelectionChangeCommitted);
                            break;
                        }
                    #endregion
                }
            }

            if (isChanged)
            {
                this.SetDisplay(this.uGrid_Supplier.ActiveRow.Index);
            }

            this.SettingToolBarButtonEnabled(e.NextCtrl);
            // --- ADD donggy 2013/04/22 for Redmine#35020 --->>>>>
            // フォーカスが発注先コードテキストボックス・発注先ガイドにある場合
            if ((e.PrevCtrl.Name == "tNedit_UOESupplierCd"
                || e.PrevCtrl.Name == "uButton_UOESupplierGuide")
                && (e.NextCtrl is Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea))
            {
                this._guideButton.SharedProps.Enabled = true;
            }
            if ((e.PrevCtrl.Name == "tNedit_UOESupplierCd"
                || e.PrevCtrl.Name == "uButton_UOESupplierGuide")
                && (!(e.NextCtrl is Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea)
                    && e.NextCtrl.Name != "uButton_UOESupplierGuide"
                    && e.NextCtrl.Name != "tNedit_UOESupplierCd"))
            {
                this._guideButton.SharedProps.Enabled = false;
            }
            // --- ADD donggy 2013/04/22 for Redmine#35020 ---<<<<<
        }

        /// <summary>
        /// ＵＯＥ発注先ガイドボタン クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note: 2013/04/22 donggy</br>
        /// <br>管理番号   : 10900691-00 2013/05/15配信分</br>
        /// <br>             Redmine#35020　「検索見積」の「発注選択画面」のガイド修正</br>
        private void uButton_UOESupplierGuide_Click(object sender, EventArgs e)
        {
            if (this.uGrid_Supplier.ActiveRow == null) return;
            UOESupplier uOESupplier;

            int rowIndex = this.uGrid_Supplier.ActiveRow.Index;

            int status = this._uOESupplierAcs.ExecuteGuid(this._enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, out uOESupplier);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                DataRow row = this._estimateInputOrderSelectAcs.GetOrderSelectHeaderRow((int)this.uGrid_Supplier.Rows[rowIndex].Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd].Value);
                int supplierCd = (int)row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd];
                int uoeSupplierCd = (int)row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOESupplierCd];

                if (uoeSupplierCd != uOESupplier.UOESupplierCd)
                {
                    this._estimateInputOrderSelectAcs.UOESupplierInfoDefaultSetting(supplierCd, uOESupplier);
                    this._estimateInputOrderSelectAcs.DetailOrderCancel(supplierCd);
                    this._estimateInputOrderSelectAcs.DetailDataChenged(supplierCd);
                    this.ComboEditorSetting(uOESupplier);
                    this._detailInput.SettingGrid();
                    this.SettingGridRow(rowIndex);
                    this._detailInput.UOESupplier = uOESupplier;
                    this.SetDisplay(rowIndex);
                }
                // --- ADD donggy 2013/04/22 for Redmine#35020 --->>>>>>>
                if (this.tNedit_UOESupplierCd.Focused
                   || this.uButton_UOESupplierGuide.Focused)
                {
                    this._guideButton.SharedProps.Enabled = true;
                }
                else
                {
                    this._guideButton.SharedProps.Enabled = false;
                }
                // --- ADD donggy 2013/04/22 for Redmine#35020 ---<<<<<<<
            }
        }

        /// <summary>
        /// グリッド InitializeLayoutイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Supplier_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Supplier.DisplayLayout.Bands[0].Columns;

            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //非表示設定
                column.Hidden = true;
                column.Header.Fixed = false;
                //入力許可設定
                //column.AutoEdit = false;
            }

            int visiblePosition = 1;
            //--------------------------------------------------------------------------------
            //  表示するカラム情報
            //--------------------------------------------------------------------------------
            #region カラム情報の設定

            // 発注有無
            Columns[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_ExistOrderDisplay].Hidden = false;
            Columns[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_ExistOrderDisplay].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_ExistOrderDisplay].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_ExistOrderDisplay].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
            Columns[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_ExistOrderDisplay].Header.VisiblePosition = visiblePosition++;
            Columns[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_ExistOrderDisplay].Header.Caption = "発注";
            Columns[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_ExistOrderDisplay].Width = 60;

            // 仕入先
            Columns[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierSnm].Hidden = false;
            Columns[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierSnm].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierSnm].Header.VisiblePosition = visiblePosition++;
            Columns[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierSnm].Header.Caption = "仕入先";
            Columns[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierSnm].Width = 140;

            #endregion

            // 固定列区切り線設定
            this.uGrid_Supplier.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_Supplier.DisplayLayout.Override.HeaderAppearance.BackColor2;

            this.uGrid_Supplier.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
        }

        /// <summary>
        /// グリッド行アクティブ後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Supplier_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.uGrid_Supplier.ActiveRow != null)
            {
                DataRow row = this._estimateInputOrderSelectAcs.GetOrderSelectHeaderRow((int)this.uGrid_Supplier.Rows[this.uGrid_Supplier.ActiveRow.Index].Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd].Value);
                int supplierCd = (int)row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd];
                UOESupplier uOESupplier = (UOESupplier)row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOESupplier];

                this._estimateInputOrderSelectAcs.ChangeSupplier(supplierCd);
                this._detailInput.SupplierCd = supplierCd;
                this._detailInput.UOESupplier = uOESupplier;
                this.ComboEditorSetting(uOESupplier);
                this.SetDisplay(this.uGrid_Supplier.ActiveRow.Index);
                this.SettingToolBarButtonEnabled(this.uGrid_Supplier);
            }
        }

        /// <summary>
        /// フォロー納品区分選択確定後発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_FollowDeliGoodsDiv_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.uGrid_Supplier.ActiveRow != null)
            {
                this.ChangeFollowDeliGoodsDiv(this.uGrid_Supplier.ActiveRow.Index);
            }
        }

        /// <summary>
        /// 納品区分選択確定後発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_DeliveredGoodsDiv_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.uGrid_Supplier.ActiveRow != null)
            {
                this.ChangeDeliveredGoodsDiv(this.uGrid_Supplier.ActiveRow.Index);
            }
        }

        /// <summary>
        /// 指定拠点選択確定後発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_UOEResvdSection_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.uGrid_Supplier.ActiveRow != null)
            {
                this.ChangeUOEResvdSection(this.uGrid_Supplier.ActiveRow.Index);
            }
        }

        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note: 2013/04/22 donggy</br>
        /// <br>管理番号   : 10900691-00 2013/05/15配信分</br>
        /// <br>             Redmine#35020　「検索見積」の「発注選択画面」のガイド修正</br>
        private void tToolbarsManager_Main_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 戻る
                case "ButtonTool_Back":
                    {
                        this.Close();
                        break;
                    }
                // 確定
                case "ButtonTool_Decision":
                    {
                        //  UPD 2011/02/14  >>>
                        if (! this.OrderSelectCheck())
                        {
                            this._estimateInputOrderSelectAcs.GetOrderSelectData(out this._uoeOrderDataTable, out this._uoeOrderDetailDataTable);

                            this._dialogResult = DialogResult.OK;
                            this.Close();
                        }
                        //  UPD 2011/02/14  <<<
                        break;
                    }
                // 次の仕入先
                case "ButtonTool_NextSupplier":
                    {
                        this.SelectNextSupplier();
                        break;
                    }
                // 発注取消
                case "ButtonTool_OrderCancel":
                    {
                        if (this.uGrid_Supplier.ActiveRow != null)
                        {
                            int supplierCd = (int)this.uGrid_Supplier.Rows[this.uGrid_Supplier.ActiveRow.Index].Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd].Value;
                            this._estimateInputOrderSelectAcs.OrderCancel(supplierCd);
                            //this.OrderCancel((int)this._orderSelectHdView[this.uGrid_Supplier.ActiveRow.Index][EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd]);
                            this.ComboEditorSetting(this.uGrid_Supplier.ActiveRow.Index);
                            this.SettingGridRow(this.uGrid_Supplier.ActiveRow.Index);
                            this.SetDisplay(this.uGrid_Supplier.ActiveRow.Index);
                            this._detailInput.SettingGrid();
                        }
                        break;
                    }
                // ガイド
                case "ButtonTool_Guide":
                    {
                        uButton_UOESupplierGuide_Click(this.uButton_UOESupplierGuide, new EventArgs ()); // ADD donggy 2013/04/22 for Redmine#35020
                        break;
                    }
            }
        }

        #endregion

        /// <summary>
        /// フォームキーダウンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMMIT01010UK_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        // ===================================================================================== //
        // プライベート スタティック メソッド
        // ===================================================================================== //
        #region ■Private Static Methods
       
        #endregion
    }

}