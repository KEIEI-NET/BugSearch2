using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 関連する伝票表示クラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 関連する伝票の表示を行います。</br>
    /// <br>Programmer  : 楊明俊</br>
    /// <br>Date        : 2010/11/25</br>
    /// <br>UpdateNote  : 2010/11/30 yangmj 障害改良対応</br>
    /// <br>UpdateNote  : 2010/12/01 yangmj 障害改良対応</br>
    /// </remarks>
    public partial class MAHNB01010UP : Form
    {
        //================================================================================
        //  コンストラクタ
        //================================================================================
        #region Constructor
        /// <summary>
        /// 関連する伝票表示クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 関連する伝票表示クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date        : 2010/11/25</br>
        /// </remarks>
        public MAHNB01010UP()
        {
            InitializeComponent();
            _delDetailDataTable = new SalesInputDataSet.DelDetailDataTable();
            _salesSlipInputAcs = SalesSlipInputAcs.GetInstance();
        }
        #endregion

        //================================================================================
        //  内部メンバー
        //================================================================================
        #region Private Members

        private SalesInputDataSet.DelDetailDataTable _delDetailDataTable;
        private SalesInputDataSet.SalesDetailDataTable _salesDetailDataTable;
        private SalesSlipInputAcs _salesSlipInputAcs;
        private List<SalesDetail> _salesDetailListSrc;
        // -----ADD 2010/11/30----->>>>>
        private List<SalesDetail> _salesDetailList; // 売上明細データオブジェクトリスト
        private int _type;　//操作ＴＹＰＥ　0：削除伝票　1：返品　2：赤伝
        // -----ADD 2010/11/30-----<<<<<

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        private DataView _delDetailView = null;

        //---UPD 2010/11/30----->>>>>
        //private DialogResult _dialogRes = DialogResult.Cancel;                  // ダイアログリザルト
        private DialogResult _dialogRes = DialogResult.No;                  // ダイアログリザルト
        //---UPD 2010/11/30-----<<<<<

        #endregion

        //================================================================================
        //  コントロールイベント
        //================================================================================
        #region Control Event
        #region < Form_Loadイベント >
        /// <summary>
        /// 画面ロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>UpdateNote  : 2010/11/30 yangmj 障害改良対応</br>
        /// <br>UpdateNote  : 2010/12/01 yangmj 障害改良対応</br>
        private void MAHNB01010UP_Load(object sender, EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();
            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // グリッド情報設定
            this._delDetailView = this._delDetailDataTable.DefaultView;
            this.ultraGrid_DetailControl.DataSource = this._delDetailView;

            // 画面初期設定処理
            this.InitializeDisplaySetting();

            this.Btn_No.Focus();
            this.ActiveControl = this.Btn_No;

            //---ADD 2010/11/30----->>>>>
            if (_type == 0)
            {
                this.ultraLabel_Message.Visible = true;
                this.ultraLabel_Message1.Visible = false;
                //---ADD 2010/12/01----->>>>>
                this.ultraLabel_Message.Text = "関連するデータが存在します。" + "\r\n" + "表示中の伝票を削除してもよろしいですか？";
                //---ADD 2010/12/01-----<<<<<
            }
            else if (_type == 1)
            {
                this.ultraLabel_Message1.Visible = true;
                this.ultraLabel_Message.Visible = false;
                //---UPD 2010/12/01----->>>>>
                //this.ultraLabel_Message1.Text = "関連するデータが存在します。       返品処理を行ってもよろしいですか。";
                this.ultraLabel_Message1.Text = "関連するデータが存在します。" + "\r\n" + "返品処理を行ってもよろしいですか？";
                //---UPD 2010/12/01-----<<<<<
            }
            else if (_type == 2)
            {
                this.ultraLabel_Message1.Visible = true;
                this.ultraLabel_Message.Visible = false;
                //---UPD 2010/12/01----->>>>>
                //this.ultraLabel_Message1.Text = "関連するデータが存在します。       赤伝処理を行ってもよろしいですか。";
                this.ultraLabel_Message1.Text = "関連するデータが存在します。" + "\r\n" + "赤伝処理を行ってもよろしいですか？";
                //---UPD 2010/12/01-----<<<<<
            }
            //---ADD 2010/11/30-----<<<<<
        }
        #endregion

        /// <summary>
        /// はいボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void Btn_OK_Click(object sender, EventArgs e)
        {
            _dialogRes = DialogResult.Yes;
            this.Close();
        }

        /// <summary>
        /// いいえボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>UpdateNote  : 2010/11/30 yangmj 障害改良対応</br>
        private void Btn_No_Click(object sender, EventArgs e)
        {
            //---UPD 2010/11/30----->>>>>
            //_dialogRes = DialogResult.Cancel;
            _dialogRes = DialogResult.No;
            //---UPD 2010/11/30-----<<<<<
            this.Close();
        }

        /// <summary>
        /// 抽出結果グリッドレイアウト初期化 イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : データソースからコントロールにデータがロードされるときなど、
        ///                   表示レイアウトが初期化されるときに発生します。 </br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date        : 2010/11/25</br>
        /// <br>UpdateNote  : 2010/11/30 yangmj 障害改良対応</br>
        /// <br>UpdateNote  : 2010/12/01 yangmj 障害改良対応</br>
        /// </remarks>
        private void ultraGrid_DetailControl_InitializeLayout_1(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.ultraGrid_DetailControl.DisplayLayout.Bands[0].Columns;

            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //非表示設定
                column.Hidden = true;
            }

            int visiblePosition = 0;

            //--------------------------------------------------------------------------------
            //  表示するカラム情報
            //--------------------------------------------------------------------------------

            this.ultraGrid_DetailControl.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;
         

            // 行数
            Columns[this._delDetailDataTable.RowNoColumn.ColumnName].Header.Fixed = true;				// 固定項目
            Columns[this._delDetailDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[this._delDetailDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.ultraGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;

            Columns[this._delDetailDataTable.RowNoColumn.ColumnName].Hidden = false;
            //---UPD 2010/12/01----->>>>>
            //Columns[this._delDetailDataTable.RowNoColumn.ColumnName].Width = 55;
            Columns[this._delDetailDataTable.RowNoColumn.ColumnName].Width = 25;
            //---UPD 2010/12/01-----<<<<<
            Columns[this._delDetailDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._delDetailDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //---UPD 2010/12/01----->>>>>
            //Columns[this._delDetailDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._delDetailDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //---UPD 2010/12/01-----<<<<<
            Columns[this._delDetailDataTable.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._delDetailDataTable.RowNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //---ADD 2010/12/01----->>>>>
            Columns[this._delDetailDataTable.RowNoColumn.ColumnName].Header.Caption = "No.";
            //---ADD 2010/12/01-----<<<<<

            //---DEL 2010/11/30----->>>>>
            //// 伝票番号
            //Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].Header.Fixed = true;				// 固定項目
            //Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].Hidden = false;
            //Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].Width = 55;
            //Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            //Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //---DEL 2010/11/30-----<<<<<

            // 伝票種別
            Columns[this._delDetailDataTable.SlipTypeColumn.ColumnName].Header.Fixed = true;				// 固定項目
            Columns[this._delDetailDataTable.SlipTypeColumn.ColumnName].Hidden = false;
            //---UPD 2010/12/01----->>>>>
            //Columns[this._delDetailDataTable.SlipTypeColumn.ColumnName].Width = 55;
            Columns[this._delDetailDataTable.SlipTypeColumn.ColumnName].Width = 70;
            //---UPD 2010/12/01-----<<<<<
            Columns[this._delDetailDataTable.SlipTypeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._delDetailDataTable.SlipTypeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this._delDetailDataTable.SlipTypeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._delDetailDataTable.SlipTypeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._delDetailDataTable.SlipTypeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;

            //---ADD 2010/11/30----->>>>>
            // 伝票番号
            Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].Header.Fixed = true;				// 固定項目
            Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].Hidden = false;
            //---UPD 2010/12/01----->>>>>
            //Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].Width = 55;
            Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].Width = 70;
            //---UPD 2010/12/01-----<<<<<
            Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //---ADD 2010/11/30-----<<<<<

            // 固定列区切り線設定
            this.ultraGrid_DetailControl.DisplayLayout.Override.FixedCellSeparatorColor = this.ultraGrid_DetailControl.DisplayLayout.Override.RowAppearance.BorderColor;

        }

        /// <summary>
        /// ChangeFocus イベント(tArrowKeyControl1)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 各コントロールからフォーカスが離れたときに発生します。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/11/25</br>
        /// <br>UpdateNote  : 2010/11/30 yangmj 障害改良対応</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null)
            {
                e.NextCtrl = this.Btn_No;
                return;
            } 

            switch (e.PrevCtrl.Name)
            {
                case "Btn_No":
                    {
                        switch (e.Key)
                        {
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.ultraGrid_DetailControl;
                                    this.ultraGrid_DetailControl.ActiveRow = this.ultraGrid_DetailControl.Rows[0];
                                    break;
                                }
                            case Keys.Down:
                                {
                                    e.NextCtrl = e.PrevCtrl;
                                    break;
                                }
                            case Keys.Return:
                                {
                                    // -----UPD 2010/11/30----->>>>>
                                    //_dialogRes = DialogResult.Cancel;
                                    _dialogRes = DialogResult.No;
                                    // -----UPD 2010/11/30-----<<<<<
                                    this.Close();
                                    break;
                                }
                        }
                        break;
                    }
                case "Btn_OK":
                    {
                        switch (e.Key)
                        {
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.ultraGrid_DetailControl;
                                    this.ultraGrid_DetailControl.ActiveRow = this.ultraGrid_DetailControl.Rows[0];
                                    break;
                                }
                            case Keys.Down:
                                {
                                    e.NextCtrl = e.PrevCtrl;
                                    break;
                                }
                            case Keys.Return:
                                {
                                    _dialogRes = DialogResult.Yes;
                                    this.Close();
                                    break;
                                }
                        }
                        break;
                    }
                //---------------------------------------------------------------
                // 明細部
                //---------------------------------------------------------------
                case "ultraGrid_DetailControl":
                    {
                        int afterRowIndex = this.ultraGrid_DetailControl.ActiveRow.Index;

                        switch (e.Key)
                        {
                            case Keys.Left:
                            case Keys.Right:
                                {
                                    this.ultraGrid_DetailControl.ActiveRow = this.ultraGrid_DetailControl.Rows[afterRowIndex];
                                    break;
                                }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/11/25</br>
        /// </remarks>
        private void ultraGrid_DetailControl_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.Right:
                    {
                        int afterRowIndex = this.ultraGrid_DetailControl.ActiveRow.Index;                       
                        this.ultraGrid_DetailControl.ActiveRow = this.ultraGrid_DetailControl.Rows[afterRowIndex];
                        e.Handled = true;
                        break;
                    }
            }

        }

        #endregion

        //================================================================================
        //  内部関数
        //================================================================================
        #region Private Methods

        // --------------------------------------------------
        #region < 画面表示設定等 >
		/// <summary>
		/// 画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期設定を行います。</br>
		/// <br>Programmer : 楊明俊</br>
		/// <br>Date       : 2010/11/25</br>
        /// <br>UpdateNote : 2010/11/30 yangmj 障害改良対応</br>
        /// <br>UpdateNote : 2010/12/01 yangmj 障害改良対応</br>
        /// </remarks>
        private void InitializeDisplaySetting()
        {
            int rowNo = 1;
            this._delDetailDataTable.Clear();
            // -----ADD 2010/11/30----->>>>>
            // 売上明細データオブジェクトリストがあるの場合、返品／赤伝時で、対象となる明細の計上元明細が存在する場合に表示するメッセージの設定
            if (_salesDetailList != null)
            {
                foreach (SalesDetail salesDetail in _salesDetailList)
                {
                    SalesInputDataSet.DelDetailRow row = this._delDetailDataTable.NewDelDetailRow();
                    SalesDetail salesDetailSrc = _salesDetailListSrc.Find(
                        delegate(SalesDetail src)
                        {
                            if ((salesDetail.AcptAnOdrStatusSrc == src.AcptAnOdrStatus) &&
                                (salesDetail.SalesSlipDtlNumSrc == src.SalesSlipDtlNum))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    );

                    if ((_salesDetailListSrc == null) || (salesDetailSrc == null)) continue;
                    // -----UPD 2010/12/01----->>>>>
                    //row.RowNo = string.Format("{0}行目", salesDetail.SalesRowNo);
                    row.RowNo = string.Format("{0}", salesDetail.SalesRowNo);
                    // -----UPD 2010/12/01-----<<<<<
                    row.SlipNo = salesDetailSrc.SalesSlipNum;
                    row.SlipType = this._salesSlipInputAcs.GetAcptAnOdrStatusName(salesDetailSrc.AcptAnOdrStatus) + "伝票";
                    this._delDetailDataTable.AddDelDetailRow(row);
                }
            }
            // 画面明細データがあるの場合、伝票削除で、対象となる明細の計上元明細が存在する場合に表示するメッセージの設定
            // -----ADD 2010/11/30-----<<<<<
            else if (_salesDetailListSrc != null && _salesDetailListSrc.Count > 0)
            {
                foreach (SalesInputDataSet.SalesDetailRow salesDetailRow in _salesDetailDataTable)
                {
                    SalesInputDataSet.DelDetailRow row = this._delDetailDataTable.NewDelDetailRow();

                    SalesDetail salesDetailSrc = _salesDetailListSrc.Find(
                        delegate(SalesDetail src)
                        {
                            if ((salesDetailRow.AcptAnOdrStatusSrc == src.AcptAnOdrStatus) &&
                                (salesDetailRow.SalesSlipDtlNumSrc == src.SalesSlipDtlNum))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    );

                    if ((_salesDetailListSrc == null) || (salesDetailSrc == null)) continue;

                    // -----UPD 2010/12/01----->>>>>
                    //row.RowNo = string.Format("{0}行目", salesDetailRow.SalesRowNo);
                    row.RowNo = string.Format("{0}", salesDetailRow.SalesRowNo);
                    // -----UPD 2010/12/01-----<<<<<
                    row.SlipNo = salesDetailSrc.SalesSlipNum;
                    row.SlipType = this._salesSlipInputAcs.GetAcptAnOdrStatusName(salesDetailSrc.AcptAnOdrStatus) + "伝票";
                    this._delDetailDataTable.AddDelDetailRow(row);
                    rowNo++;
                }
            }
        }
        #endregion
        // --------------------------------------------------
        #endregion

        //================================================================================
        //  外部提供関数
        //================================================================================
        #region Public Methods
        /// <summary>
        /// 注意 －＜売上伝票入力＞起動
        /// </summary>
        /// <param name="owner">owner</param>
        /// <param name="salesDetailListSrc">計上元明細読込</param>
        /// <param name="type">操作ＴＹＰＥ　0：削除伝票　1：返品　2：赤伝</param>
        /// /// <param name="salesDetailDataTable">売上明細データテーブルオブジェクト</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/11/25</br>
        /// <br>UpdateNote : 2010/11/30 yangmj 障害改良対応</br>
        /// </remarks>
        public DialogResult Show(IWin32Window owner, List<SalesDetail> salesDetailList, List<SalesDetail> salesDetailListSrc, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, int type)
        {
            _salesDetailListSrc = salesDetailListSrc;
            _salesDetailDataTable = salesDetailDataTable;
            //---ADD 2010/11/30----->>>>>
            _type = type;
            _salesDetailList = salesDetailList;
            //---ADD 2010/11/30-----<<<<<

            DialogResult dr = base.ShowDialog(owner);
            // -----UPD 2010/11/30----->>>>>
            //if (_dialogRes != DialogResult.Yes)
            //{
            //    _dialogRes = DialogResult.Cancel;
            //}
            if (dr != DialogResult.Cancel)
            {
                _dialogRes = DialogResult.No;
            }
            // -----UPD 2010/11/30-----<<<<<
            return _dialogRes;
        }
        #endregion

    }
    /// <summary>
    /// フッタ部フォーカス移動設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : フッタ部のフォーカス移動を管理するクラスです。</br>
    /// <br>Programmer : 楊明俊</br>
    /// <br>Date       : 2010/11/25</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class DelDetailConstruction
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private string _rowNo;
        private string _slipNo;
        private string _slipType;
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// 削除明細クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 削除明細クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/11/25</br>
        /// </remarks>
        public DelDetailConstruction()
        {
            this._rowNo = string.Empty;
            this._slipNo = string.Empty;
            this._slipType = string.Empty;
        }

        /// <summary>
        /// 削除明細クラス
        /// </summary>
        /// <param name="key">キー</param>
        /// <param name="caption">キャプション</param>
        /// <param name="enterStop">移動有無</param>
        /// <remarks>
        /// <br>Note       : 削除明細クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/11/25</br>
        /// </remarks>
        public DelDetailConstruction(string rowNo, string slipNo, string slipType)
        {
            this._rowNo = rowNo;
            this._slipNo = slipNo;
            this._slipType = slipType;
        }
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region Properties
        /// <summary>行数</summary>
        public string RowNo
        {
            get { return this._rowNo; }
            set { this._rowNo = value; }
        }
        /// <summary>伝票番号</summary>
        public string SlipNo
        {
            get { return this._slipNo; }
            set { this._slipNo = value; }
        }
        /// <summary>伝票種別</summary>
        public string SlipType
        {
            get { return this._slipType; }
            set { this._slipType = value; }
        }
        # endregion
    }
}