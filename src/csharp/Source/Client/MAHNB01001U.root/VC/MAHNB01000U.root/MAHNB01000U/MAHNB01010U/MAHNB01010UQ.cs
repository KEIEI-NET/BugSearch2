using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

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
    /// 伝票番号選択フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 伝票番号選択のフォームクラスです。</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2011/02/14</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2011/02/14 20056 對馬 大輔 新規作成</br>
    /// <br>Update Note: 2013/07/23 三戸 伸悟</br>
    /// <br>管理番号   : 10801804-00</br>
    /// <br>             SCM障害№10554対応（文字化け）</br>
    /// </remarks>
    public partial class MAHNB01010UQ : Form
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private SalesSlipInputAcs _salesSlipInputAcs;
        private ScmDataSet.SalesSlipNumDataTable _salesSlipNumDataTable;
        private DataView _salesSlipNumView = null;
        private DialogResult _dialogRes = DialogResult.Cancel;

        private String _salesSlipNum;
        private ArrayList _salesSlipNumList;
        private Int64 _inqueryNumber;

        private readonly Color _selectedBackColor = Color.FromArgb(216, 235, 253);
        private readonly Color _selectedBackColor2 = Color.FromArgb(101, 144, 218);
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region Properties
        /// <summary>伝票番号</summary>
        public string SalesSlipNum
        {
            get { return this._salesSlipNum; }
        }

        /// <summary>伝票番号リスト</summary>
        public ArrayList SalesSlipNumList
        {
            get { return this._salesSlipNumList; }
            set { this._salesSlipNumList = value; }
        }

        /// <summary>問合せ番号</summary>
        public Int64 InqueryNumber
        {
            get { return this._inqueryNumber; }
            set { this._inqueryNumber = value; }
        }
        # endregion

        // ===================================================================================== //
        // 外部に提供する定数群
        // ===================================================================================== //
        # region Public Readonly Members
        /// <summary>追加行リテラル</summary>
        public static readonly string ctAddPositionName = "新規問合せ";
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// MAHNB01010UQ
        /// </summary>
        public MAHNB01010UQ()
        {
            InitializeComponent();

            this._salesSlipInputAcs = SalesSlipInputAcs.GetInstance();
            this._salesSlipNumDataTable = new ScmDataSet.SalesSlipNumDataTable();
        }
        # endregion

        // ===================================================================================== //
        // 各種コンポーネントイベント処理郡
        // ===================================================================================== //
        # region Event Methods
        /// <summary>
        /// MAHNB01010UQ_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAHNB01010UQ_Load(object sender, EventArgs e)
        {
            
            //---------------------------------------------------------
            // 初期設定タイマー起動
            //---------------------------------------------------------
            this.Initial_Timer.Enabled = true;

            //---------------------------------------------------------
            // 売上伝票番号データテーブル
            //---------------------------------------------------------
            int i = 1;
            foreach (string salesSlipNum in this._salesSlipNumList)
            {
                ScmDataSet.SalesSlipNumRow row = (ScmDataSet.SalesSlipNumRow)this._salesSlipNumDataTable.NewRow();
                row.RowNo = i;
                if (salesSlipNum == SalesSlipInputAcs.ctDefaultSalesSlipNum)
                {
                    row.SalesSlipNum = ctAddPositionName;
                }
                else
                {
                    row.SalesSlipNum = salesSlipNum;
                }
                this._salesSlipNumDataTable.AddSalesSlipNumRow(row);
                i++;
            }

            //---------------------------------------------------------
            // 問合せ番号
            //---------------------------------------------------------
            this.tNedit_InqueryNumber.SetValue(this._inqueryNumber);

            //---------------------------------------------------------
            // グリッド情報設定
            //---------------------------------------------------------
            this._salesSlipNumView = this._salesSlipNumDataTable.DefaultView;
            this.uGrid_SalesSlipNum.DataSource = this._salesSlipNumView;

            //---------------------------------------------------------
            // アイコン設定
            //---------------------------------------------------------
            Bitmap icon = new Bitmap(32, 32);
            Graphics graphics = Graphics.FromImage(icon);
            try
            {
                graphics.DrawIcon(SystemIcons.Information, 0, 0);
            }
            finally
            {
                if (graphics != null) graphics.Dispose();
            }
            pictureBox1.Image = icon;
        }

        /// <summary>
        /// tArrowKeyControl1_ChangeFocus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                //---------------------------------------------------------------
                // 明細部
                //---------------------------------------------------------------
                case "uGrid_SalesSlipNum":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    // アクティブ行選択タイマー起動
                                    this.timer_SelectRow.Enabled = true;
                                    e.NextCtrl = e.PrevCtrl;
                                    break;
                                }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// Initial_Timer_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // 初期設定タイマー解除
            this.Initial_Timer.Enabled = false;

            // 初期フォーカス位置指定
            this.uGrid_SalesSlipNum.Focus();
            this.uGrid_SalesSlipNum.Rows[0].Selected = true;
        }

        /// <summary>
        /// uButton_Close_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>ESCで画面終了を行うときに使用</remarks>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            // ボタンは隠れてます
            this.SetDialogRes(DialogResult.Cancel);
            this.CloseForm();
        }

        /// <summary>
        /// ultraGrid1_InitializeLayout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_SalesSlipNum.DisplayLayout.Bands[0].Columns;

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
            this.uGrid_SalesSlipNum.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;
            this.uGrid_SalesSlipNum.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            this.uGrid_SalesSlipNum.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_SalesSlipNum.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_SalesSlipNum.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.uGrid_SalesSlipNum.DisplayLayout.Bands[0].Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;// None;
            this.uGrid_SalesSlipNum.DisplayLayout.Bands[0].Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // №
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].Header.Fixed = true;				// 固定項目
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_SalesSlipNum.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_SalesSlipNum.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_SalesSlipNum.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_SalesSlipNum.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_SalesSlipNum.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].Hidden = false;
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].Width = 25;
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_SalesSlipNum.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- ADD 2013/07/23 三戸 2013/08/07配信分 SCM障害№10554 --------->>>>>>>>>>>>>>>>>>>>>>>>
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].Header.Caption = "№";
            // --- ADD 2013/07/23 三戸 2013/08/07配信分 SCM障害№10554 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // 伝票番号
            Columns[this._salesSlipNumDataTable.SalesSlipNumColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._salesSlipNumDataTable.SalesSlipNumColumn.ColumnName].Hidden = false;
            Columns[this._salesSlipNumDataTable.SalesSlipNumColumn.ColumnName].Width = 150;
            Columns[this._salesSlipNumDataTable.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._salesSlipNumDataTable.SalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // --- ADD 2013/07/23 三戸 2013/08/07配信分 SCM障害№10554 --------->>>>>>>>>>>>>>>>>>>>>>>>
            Columns[this._salesSlipNumDataTable.SalesSlipNumColumn.ColumnName].Header.Caption = "伝票番号";
            // --- ADD 2013/07/23 三戸 2013/08/07配信分 SCM障害№10554 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // 受注ステータス
            Columns[this._salesSlipNumDataTable.AcptAnOdrStatusColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._salesSlipNumDataTable.AcptAnOdrStatusColumn.ColumnName].Hidden = true;
            Columns[this._salesSlipNumDataTable.AcptAnOdrStatusColumn.ColumnName].Width = 150;
            Columns[this._salesSlipNumDataTable.AcptAnOdrStatusColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._salesSlipNumDataTable.AcptAnOdrStatusColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // 選択
            Columns[this._salesSlipNumDataTable.CheckedColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._salesSlipNumDataTable.CheckedColumn.ColumnName].Hidden = true;
            Columns[this._salesSlipNumDataTable.CheckedColumn.ColumnName].Width = 150;
            Columns[this._salesSlipNumDataTable.CheckedColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._salesSlipNumDataTable.CheckedColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            
            // 固定列区切り線設定
            this.uGrid_SalesSlipNum.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_SalesSlipNum.DisplayLayout.Override.HeaderAppearance.BackColor2;

        }

        /// <summary>
        /// uGrid_SelectBLGoodsDr_DoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_SalesSlipNum_DoubleClick(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // マウスポインタがグリッドのどの位置にあるかを判定する
            Point point = System.Windows.Forms.Cursor.Position;
            point = targetGrid.PointToClient(point);

            // UIElementを取得する。
            Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
            if (objUIElement == null)
                return;

            // マウスポインターが列のヘッダ上にあるかチェック。
            Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
              (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

            if (objHeader != null) return;

            // マウスポインターが行の上にあるかチェック。
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
              (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

            if (objRow == null) return;

            // 伝票番号設定
            this.SetSalesSlipNum(objRow);
            this.SetDialogRes(DialogResult.OK);
            this.CloseForm();
        }

        /// <summary>
        /// timer_SelectRow_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_SelectRow_Tick(object sender, EventArgs e)
        {
            this.timer_SelectRow.Enabled = false;
            if (this.uGrid_SalesSlipNum.ActiveRow != null)
            {
                this.SetSalesSlipNum(this.uGrid_SalesSlipNum.ActiveRow);
                this.SetDialogRes(DialogResult.OK);
                this.CloseForm();
            }
        }
        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        # region Private Methods
        /// <summary>
        /// 画面終了処理
        /// </summary>
        private void CloseForm()
        {
            if (this._dialogRes == DialogResult.Cancel) this._salesSlipNum = string.Empty;
            this.DialogResult = this._dialogRes;
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
        /// 伝票番号設定処理
        /// </summary>
        /// <param name="objRow"></param>
        private void SetSalesSlipNum(Infragistics.Win.UltraWinGrid.UltraGridRow objRow)
        {
            if ((string)objRow.Cells[this._salesSlipNumDataTable.SalesSlipNumColumn.ColumnName].Value == ctAddPositionName)
            {
                this._salesSlipNum = SalesSlipInputAcs.ctDefaultSalesSlipNum;
            }
            else
            {
                this._salesSlipNum = (string)objRow.Cells[this._salesSlipNumDataTable.SalesSlipNumColumn.ColumnName].Value;
            }
        }
        # endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        #region Public Methods
        #endregion

    }
}