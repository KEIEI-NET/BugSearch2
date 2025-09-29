//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 簡単問合せ接続情報フォームクラス
// プログラム概要   : 簡単問合せ接続情報を表示・クリアする
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 10601193-00  作成担当 : 21024　佐々木 健
// 作 成 日  2010/03/25  修正内容 : 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Library.Windows.Forms;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 簡単問合せ接続情報フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 新規作成</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2010/03/25</br>
    /// </remarks>
    public partial class PMSCM00201UA : Form
    {

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■ Constructor
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新規作成</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        public PMSCM00201UA()
        {
            InitializeComponent();
            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"];
            this._sectionTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_SectionTitle"];
            this._sectionNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_SectionName"];
            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginName"];
            // ログイン担当者
            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            this._controlScreenSkin = new ControlScreenSkin();
        }
        #endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■Private Member

        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;          // 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;          // クリアボタン
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;       // ログイン担当者ラベル
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;		// ログイン担当者名称
        private Infragistics.Win.UltraWinToolbars.LabelTool _sectionTitleLabel;     // ログイン担当者ラベル
        private Infragistics.Win.UltraWinToolbars.LabelTool _sectionNameLabel;		// ログイン担当者名称
        private SimplInqCnectInfoAcs _simplInqCnectInfoAcs = new SimplInqCnectInfoAcs();
        private ControlScreenSkin _controlScreenSkin;
        private DataView _dataView;
        private bool closeFlg = true;

        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■Private Method

        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新規作成</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            this._sectionTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
            // 拠点名称
            this._sectionNameLabel.SharedProps.Caption = this._simplInqCnectInfoAcs.GetOwnSectionName(LoginInfoAcquisition.Employee.BelongSectionCode);
        }

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 新規作成</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        private int Clear()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // 画面クリア
            this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.Clear();

            // 初期化検索
            status = this._simplInqCnectInfoAcs.Search(LoginInfoAcquisition.EnterpriseCode);
            this.uCheckEditor_Own.Checked = true;

            if (this.uGrid_Result.Rows.Count > 0)
            {
                this.uGrid_Result.Select();
                this.uGrid_Result.Rows[0].Selected = true;
                this.uGrid_Result.Rows[0].Activate();
            }

            return status;
        }

        /// <summary>
        /// 画面保存処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新規作成</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        private void Save()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.AcceptChanges();
            // 保存チェック
            bool check = this.CheckSaveData();

            if (!check)
            {
                return;
            }

            DialogResult ret = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_INFO,
                this.Name,
                "選択された接続情報をクリアします。" + Environment.NewLine + "よろしいですか？",
                -1, MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button2);

            if (ret == DialogResult.Yes)
            {
                // 保存処理
                status = this._simplInqCnectInfoAcs.Save(LoginInfoAcquisition.EnterpriseCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       "接続情報をクリアしました。",
                       -1,
                       MessageBoxButtons.OK);

                    this.Clear();
                }
                else
                {
                    // メッセージを呼び出す
                    TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_STOPDISP,
                       this.Name,
                       "接続情報をクリアに失敗しました。",
                       -1,
                       MessageBoxButtons.OK);
                    // 空白行を追加する
                }
            }
        }

        /// <summary>
        /// 保存前チェック
        /// </summary>
        /// <returns>フラグ</returns>
        /// <remarks>
        /// <br>Note       : 新規作成</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        private bool CheckSaveData()
        {
            // 存在フラグ
            bool isExistFlg = false;

            string defFilter = this._dataView.RowFilter;
            string filter = this._dataView.RowFilter;

            this.uGrid_Result.BeginUpdate();
            try
            {
                if (!string.IsNullOrEmpty(filter)) filter += " AND ";

                filter += string.Format("{0} = True", this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.SelectedColumn.ColumnName);

                this._dataView.RowFilter = filter;


                isExistFlg = ( this._dataView.Count > 0 );
            }
            finally
            {
                this._dataView.RowFilter = defFilter;
                this.uGrid_Result.EndUpdate();
            }
            if (!isExistFlg)
            {
                 TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           this.Name,
                           "データが選択されていません。",
                           -1,
                           MessageBoxButtons.OK);

                 return false;
            }

            return true;
        }

        /// <summary>
        /// データにフィルタをかけます。
        /// </summary>
        /// <param name="mode">0:自端末のデータのみ、1:全て表示</param>
        private void DataFilter(int mode)
        {
            string filter = string.Empty;

            // 一旦全件選択を解除する
            this.button_AllCancel_Click(this.button_AllCancel, new EventArgs());

            switch (mode)
            {
                case 0:
                    filter = string.Format("{0}={1}", this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.CashRegisterNoColumn.ColumnName, this._simplInqCnectInfoAcs.GetOwnCashRegisterNo(LoginInfoAcquisition.EnterpriseCode));
                    break;
                case 1:
                    break;
            }
            this._dataView.RowFilter = filter;
        }

        /// <summary>
        /// 選択・非選択変更処理（反転）
        /// </summary>
        /// <param name="gridRow"></param>
        private void ChangedSelect(Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            bool newSelectedValue = !(bool)gridRow.Cells[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.SelectedColumn.ColumnName].Value;

            gridRow.Cells[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.SelectedColumn.ColumnName].Value = newSelectedValue;
        }

        #endregion

        // ===================================================================================== //
        // 各コントロールイベント処理
        // ===================================================================================== //
        # region ■Control Event Methods
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void PMKYO09301UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add(this.uGroupBox_ExtractInfo.Name);
            this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);
            this._controlScreenSkin.SettingScreenSkin(this.uGrid_Result);

            this._dataView = this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.DefaultView;
            this._dataView.Sort = string.Format("{0},{1}", this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.CashRegisterNoColumn.ColumnName, this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.CustomerCodeColumn.ColumnName);
            this.uGrid_Result.DataSource = this._dataView;

            // ボタン初期設定処理
            this.ButtonInitialSetting();

            // 初期化検索
            closeFlg = true;
            int status = this.Clear();

            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                this.closeFlg = false;
                return;
            }

            this.timer_setFocus.Enabled = true;
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Result_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Result.DisplayLayout.Bands[0];
            if (editBand == null) return;

            // グリッド
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.SelectedColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.CashRegisterNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.MachineNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.CustomerCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.CustomerSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;

            // CellAppearance設定
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.SelectedColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.CashRegisterNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.MachineNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.CustomerSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

            //// 表示幅設定
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.SelectedColumn.ColumnName].Width = 60;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.CashRegisterNoColumn.ColumnName].Width = 80;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.MachineNameColumn.ColumnName].Width = 170;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.CustomerCodeColumn.ColumnName].Width = 164;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.CustomerSnmColumn.ColumnName].Width = 240;

            // フォーマット
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.CashRegisterNoColumn.ColumnName].Format = "000";
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.CustomerCodeColumn.ColumnName].Format = "00000000";

            // 固定列区切り線設定
            //this.uGrid_Result.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor2;
        }

        
        /// <summary>
        /// ChangeFocusイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "uGrid_Result":
                    {
                        
                        break;
                    }
                default:
                    break;
            }

            if (e.NextCtrl != null)
            {
                switch (e.NextCtrl.Name)
                {
                    case "uGrid_Result":
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Return)
                            {
                                if (e.NextCtrl == this.uGrid_Result)
                                {
                                }
                            }
                            break;
                        }
                    default:
                        break;
                }
            }

            // 削除ボタン状態設定
           this.DelButtonSetting();
        }

        /// <summary>
        /// 削除ボタン状態設定
        /// </summary>
        private void DelButtonSetting()
        {
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Result.ActiveCell;
            Infragistics.Win.UltraWinGrid.SelectedRowsCollection rows = this.uGrid_Result.Selected.Rows;
            if ((cell == null) && (rows == null || rows.Count == 0)) return;

            // アクティブ行取得
            int activeRowIndex;
            if (this.uGrid_Result.ActiveRow != null)
            {
                activeRowIndex = this.uGrid_Result.ActiveRow.Index;
            }
            else
            {
                if (this.uGrid_Result.ActiveCell != null)
                {
                    activeRowIndex = this.uGrid_Result.ActiveCell.Row.Index;
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void timer_setFocus_Tick(object sender, EventArgs e)
        {
            if (closeFlg)
            {
                // フォーカス設定
                this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
            }

            this.timer_setFocus.Enabled = false;
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // 画面を閉じる
                        this.Close();
                        break;
                    }
                case "ButtonTool_Clear":
                    {
                        this.Save();
                        break;
                    }
            }
        }

        /// <summary>
        /// チェックエディタ チェック変更時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_Own_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == this.uCheckEditor_Own )
            {
                if (this.uCheckEditor_Own.Checked)
                {
                    this.DataFilter(0);
                    this.uCheckEditor_All.Checked = false;
                }
                else
                {
                    if (!this.uCheckEditor_All.Checked)
                    {
                        this.uCheckEditor_Own.Checked = true;
                    }
                }
            }
            else if (sender == this.uCheckEditor_All)
            {
                if (this.uCheckEditor_All.Checked)
                {
                    this.DataFilter(1);
                    this.uCheckEditor_Own.Checked = false;
                }
                else
                {
                    if (!this.uCheckEditor_Own.Checked)
                    {
                        this.uCheckEditor_All.Checked = true;
                    }
                }
            }
        }

        /// <summary>
        /// 全て選択ボタン クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_AllSelect_Click(object sender, EventArgs e)
        {
            this.uGrid_Result.BeginUpdate();
            foreach (DataRowView dv in this._dataView)
            {
                dv[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.SelectedColumn.ColumnName] = true;
            }

            this.uGrid_Result.EndUpdate();
        }

        /// <summary>
        /// 全て解除ボタン クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_AllCancel_Click(object sender, EventArgs e)
        {
            this.uGrid_Result.BeginUpdate();
            foreach (DataRowView dv in this._dataView)
            {
                dv[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.SelectedColumn.ColumnName] = false;
            }
            this.uGrid_Result.EndUpdate();
        }


        /// <summary>
        /// マウスダブルクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Result_DoubleClick(object sender, EventArgs e)
        {

            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // マウスが入った最後の要素を取得します。
            Infragistics.Win.UIElement lastElementEntered = targetGrid.DisplayLayout.UIElement.LastElementEntered;

            // チェーン内に RowUIElement があるかどうかを調べます。
            Infragistics.Win.UltraWinGrid.RowUIElement rowElement;
            if (lastElementEntered is Infragistics.Win.UltraWinGrid.RowUIElement)
                rowElement = (Infragistics.Win.UltraWinGrid.RowUIElement)lastElementEntered;
            else
            {
                rowElement = (Infragistics.Win.UltraWinGrid.RowUIElement)lastElementEntered.GetAncestor(typeof(Infragistics.Win.UltraWinGrid.RowUIElement));
            }

            if (rowElement == null) return;

            // 要素から行を取得します。
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow = (Infragistics.Win.UltraWinGrid.UltraGridRow)rowElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

            // 行が返されなかった場合、マウスは行の上にありません。
            if (objRow == null)
                return;

            // マウスは行の上にあります。

            // この部分はオプションです。しかし、ユーザーが行セレクタ間の行を
            // ダブルクリックした場合、デフォルトで行のサイズを自動調整します。
            // その場合、通常、ダブルクリックコードは記述しません。

            // 現在のマウスポインタの位置を取得してグリッド座標に変換します。
            Point MousePosition = targetGrid.PointToClient(Control.MousePosition);
            // 座標点が AdjustableElement 上にあるかどうかを調べます。すなわち、
            // ユーザーが行セレクタ上の行をクリックしているかどうか。
            if (lastElementEntered.AdjustableElementFromPoint(MousePosition) != null)
                return;

            if (objRow != null)
            {
                this.ChangedSelect(objRow);
            }
        }


        /// <summary>
        /// グリッド　クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Result_Click(object sender, EventArgs e)
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

            if (objRow != null)
            {
                // マウスポインターが印刷有無セル上にあるか？
                Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
                  (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));
                if (objCell != null)
                {
                    // 印刷フラグ列
                    if (objCell.Column.Key == _simplInqCnectInfoAcs.SimplInqCnectInfoTable.SelectedColumn.ColumnName)
                    {
                        this.ChangedSelect(objRow);
                    }
                }

            }
        }

        /// <summary>
        /// グリッド　キーダウンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Result_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Shift && !e.Control && !e.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.Space:
                        if (this.uGrid_Result.ActiveRow != null)
                        {
                            this.ChangedSelect(this.uGrid_Result.ActiveRow);
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion
    }
}