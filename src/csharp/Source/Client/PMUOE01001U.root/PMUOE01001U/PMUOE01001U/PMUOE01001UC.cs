//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送信処理 Ｕｉフォームクラス
// プログラム概要   : ＵＯＥ送信処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/11/23  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Infragistics.Win;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 未送信言一覧フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 未送信言一覧フォームクラスです。</br>
    /// <br>Programmer  : 李占川</br>
    /// <br>Date        : 2009/11/23</br>
    /// </remarks>
    public partial class PMUOE01001UC : Form
    {
        #region ■ コンストラクタ ■
        /// <summary>
        /// 未送信言一覧UIクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 未送信言一覧UIフォームクラスのインスタンスを生成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/11/23</br>
        /// </remarks>
        public PMUOE01001UC()
        {
            InitializeComponent();

            this._imageList16 = IconResourceManagement.ImageList16;
            this._okButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_OKBUTTON_KEY];
            this._backButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_BACKBUTTON_KEY];

            this._stockInputAcs = StockInputAcs.GetInstance();
            this._uOESendNotDataTable = this._stockInputAcs.uOESendNotDataTable;

            // ボタン初期設定処理
            this.ButtonInitialSetting();

            // ソート順はシステム区分、端末番号、発注先コードとする。
            DataView dv = this._uOESendNotDataTable.DefaultView;
            dv.Sort = "SystemDivCd, CashRegisterNo, UOESupplierCd";
            this.uGrid_Details.DataSource = dv;

            // 検索処理
            this.SearchSendNot();
        }
        #endregion

        #region ■ private定数 ■
        // ツールバーツールキー設定
        private const string TOOLBAR_OKBUTTON_KEY = "ButtonTool_OK";
        private const string TOOLBAR_BACKBUTTON_KEY = "ButtonTool_Back";

        // グリッド列
        private const string column_SelectionState = "SelectionState";
        private const string column_SystemDivCd = "SystemDivCd";
        private const string column_CashRegisterNo = "CashRegisterNo";
        private const string column_UOESupplierCd = "UOESupplierCd";
        #endregion

        #region ■ private変数 ■
        private ImageList _imageList16 = null;										// イメージリスト
        private Infragistics.Win.UltraWinToolbars.ButtonTool _okButton;				// 確定ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _backButton;			// 戻るボタン

        private StockInputAcs _stockInputAcs;
        private StockInputDataSet.UOESendNotDataTable _uOESendNotDataTable;

        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        private string _loginSectionName = LoginInfoAcquisition.Employee.BelongSectionName;
        private string _employeeCode = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
        private string _employeeName = LoginInfoAcquisition.Employee.Name;

        /// <summary> 選択リスト </summary>
        private Dictionary<int, UltraGridRow> _lstSelInf = new Dictionary<int, UltraGridRow>();
        #endregion

        #region ■ コントロールイベント ■
        /// <summary>
        /// グリッド初期レイアウト設定イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 画面初期化時、グリッド初期レイアウト設定を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/11/23</br>
        /// </remarks>
        private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // グリッド列初期設定処理
            this.InitialSettingGridCol();

            // グリッド列表示非表示設定処理
            this.SetGridColVisible();
        }

        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : ツールバークリック時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/11/23</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 確定
                case TOOLBAR_OKBUTTON_KEY:
                    {
                        // 確定時のエラーチェック処理
                        if (this.OKSelectCheck())
                        {
                            // 確定処理
                            int status = this.Confim();
                            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                            {
                                DialogResult = DialogResult.OK;
                            }
                        }
                        else
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "明細が選択されていません。",
                                -1,
                                MessageBoxButtons.OK);
                        }
                        break;
                    }
                // 戻る
                case TOOLBAR_BACKBUTTON_KEY:
                    {
                        // 前の画面に戻る                    
                        DialogResult = DialogResult.Cancel;
                        break;
                    }
            }
        }

        /// <summary>
        /// 行をダブルクリックされた場合は、その行を選択する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note        : データが表示されていない行をダブルクリックしても本イベントは発生しない。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/11/23</br>
        /// </remarks>
        private void uGrid_Details_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            this.SetSelect(false);
        }

        /// <summary>
        /// グリッド上でEnterキーが押された場合は、その行を選択する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/11/23</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    // Enterキー(ダブルクリック)による選択処理
                    this.SetSelect(true);
                    break;
            }
        }
        #endregion

        #region ■ privateメソッド ■
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面初期化の時、ボタン初期設定処理を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/11/23</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;

            this._okButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            this._backButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
        }

        /// <summary>
        /// グリッド列初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面初期化の時、グリッド列初期設定を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/11/23</br>
        /// </remarks>
        private void InitialSettingGridCol()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if (editBand == null) return;

            // 複数行選択可
            editBand.Layout.Override.SelectTypeRow = SelectType.Single;

            StockInputDataSet.UOESendNotDataTable table = this._uOESendNotDataTable;
            ColumnsCollection columns = editBand.Columns;

            //--------------------------------------
            // 入力不可
            //--------------------------------------
            for (int index = 0; index < columns.Count; index++)
            {
                columns[index].CellActivation = Activation.NoEdit;
            }

            //--------------------------------------
            // キャプション
            //--------------------------------------
            columns[table.SelImageColumn.ColumnName].Header.Caption = "";
            columns[table.SystemDivNmColumn.ColumnName].Header.Caption = "システム区分";
            columns[table.CashRegisterNoColumn.ColumnName].Header.Caption = "端末番号";
            columns[table.UOESupplierNameColumn.ColumnName].Header.Caption = "発注先";

            //--------------------------------------
            // ヘッダのテキスト位置(HAlign)
            //--------------------------------------
            columns[table.SystemDivNmColumn.ColumnName].Header.Appearance.TextHAlign = HAlign.Left;
            columns[table.CashRegisterNoColumn.ColumnName].Header.Appearance.TextHAlign = HAlign.Left;
            columns[table.UOESupplierNameColumn.ColumnName].Header.Appearance.TextHAlign = HAlign.Left;

            //--------------------------------------
            // 列幅
            //--------------------------------------
            columns[table.SelImageColumn.ColumnName].Width = 18;
            columns[table.SystemDivNmColumn.ColumnName].Width = 70;
            columns[table.CashRegisterNoColumn.ColumnName].Width = 60;
            columns[table.UOESupplierNameColumn.ColumnName].Width = 160;

            //--------------------------------------
            // テキスト位置(HAlign)
            //--------------------------------------
            columns[table.SelImageColumn.ColumnName].CellAppearance.ImageHAlign = HAlign.Center;
            columns[table.SystemDivNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.CashRegisterNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.UOESupplierNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;

            //--------------------------------------
            // テキスト位置(VAlign)
            //--------------------------------------
            for (int index = 0; index < columns.Count; index++)
            {
                columns[index].CellAppearance.TextVAlign = VAlign.Middle;
            }
            columns[table.SelImageColumn.ColumnName].CellAppearance.ImageVAlign = VAlign.Middle;


            //--------------------------------------
            // フォーマット設定
            //--------------------------------------
            columns[table.CashRegisterNoColumn.ColumnName].Format = "000";

            //--------------------------------------
            // クリック時動作制御
            //--------------------------------------
            for (int index = 0; index < columns.Count; index++)
            {
                columns[index].CellClickAction = CellClickAction.RowSelect;
            }
        }

        /// <summary>
        /// グリッド列表示非表示設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面初期化の時、グリッド列初期設定を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/11/23</br>
        /// </remarks>
        private void SetGridColVisible()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if (editBand == null) return;

            StockInputDataSet.UOESendNotDataTable table = this._uOESendNotDataTable;
            ColumnsCollection columns = editBand.Columns;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in columns)
            {
                // 全ての列をいったん非表示にする。
                col.Hidden = true;
            }

            columns[table.SelImageColumn.ColumnName].Hidden = false;
            columns[table.SelectionStateColumn.ColumnName].Hidden = true;
            columns[table.SystemDivCdColumn.ColumnName].Hidden = true;
            columns[table.SystemDivNmColumn.ColumnName].Hidden = false;
            columns[table.CashRegisterNoColumn.ColumnName].Hidden = false;
            columns[table.UOESupplierCdColumn.ColumnName].Hidden = true;
            columns[table.UOESupplierNameColumn.ColumnName].Hidden = false;
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 検索クリックの時、検索を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/11/23</br>
        /// </remarks>
        private bool SearchSendNot()
        {
            string message = "";

            InpDisplay inpDisplay = new InpDisplay();
            //環境項目
            inpDisplay.EnterpriseCode = this._enterpriseCode;	//企業コード
            inpDisplay.SectionCode = this._loginSectionCode;	//拠点コード
            inpDisplay.SectionName = this._loginSectionName;	//拠点名
            inpDisplay.EmployeeCode = this._employeeCode;		//入力担当者コード
            inpDisplay.EmployeeName = this._employeeName;		//入力担当者名

            inpDisplay.BusinessCode = 0;
            inpDisplay.SystemDivCd = -1;
            inpDisplay.CashRegisterNoDiv = 2;

            // ＵＯＥ発注データ 検索処理
            int status = _stockInputAcs.SearchDB2(inpDisplay, out message);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    message,
                    -1,
                    MessageBoxButtons.OK);
                return (false);
            }

            return (true);
        }

        /// <summary>
        /// 確定処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 確定クリックの時、確定を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/11/23</br>
        /// </remarks>
        private int Confim()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            Dictionary<int, InpDisplay> sefInfo = new Dictionary<int, InpDisplay>();
            foreach (UltraGridRow row in _lstSelInf.Values)
            {
                InpDisplay inpDisplay = new InpDisplay();
                inpDisplay.SystemDivCd = (int)row.Cells[column_SystemDivCd].Value;
                inpDisplay.CashRegisterNo = (int)row.Cells[column_CashRegisterNo].Value;
                inpDisplay.UOESupplierCd = (int)row.Cells[column_UOESupplierCd].Value;

                sefInfo.Add(row.ListIndex, inpDisplay);
            }

            // 送信処理画面データの設定処理
            status = this._stockInputAcs.GetMenuData(sefInfo);

            return status;
        }

        /// <summary>
        /// Enterキー(ダブルクリック)による選択処理
        /// </summary>
        /// <param name="moveFlg">true:次の行を選択状態に／false:なにもしない（マウスダブルクリック時）</param>
        /// <remarks>
        /// <br>Note		: Enterキー(ダブルクリック)による選択処理を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/11/23</br>
        /// </remarks>
        private void SetSelect(bool moveFlg)
        {
            UltraGridRow activeRow = uGrid_Details.ActiveRow;

            if (activeRow != null)
            {
                CellsCollection activeCells = activeRow.Cells;

                if (activeCells[_uOESendNotDataTable.SelImageColumn.ColumnName].Value != DBNull.Value)
                {
                    activeCells[_uOESendNotDataTable.SelImageColumn.ColumnName].Value = DBNull.Value;
                    activeCells[_uOESendNotDataTable.SelectionStateColumn.ColumnName].Value = false;

                    if (_lstSelInf.ContainsKey(activeRow.ListIndex)) // 選択解除する
                    {
                        _lstSelInf.Remove(activeRow.ListIndex);
                    }
                }
                else
                {
                    int sysDiv = (int)activeCells[_uOESendNotDataTable.SystemDivCdColumn.ColumnName].Value;

                    if (!_lstSelInf.ContainsKey(activeRow.ListIndex))
                    {
                        _lstSelInf.Add(activeRow.ListIndex, activeRow);
                    }

                    // 選択時のエラーチェック処理
                    if (this.SelectCheck())
                    {
                        // 選択ON
                        activeCells[_uOESendNotDataTable.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                        activeCells[_uOESendNotDataTable.SelectionStateColumn.ColumnName].Value = true;
                    }
                    else
                    {
                        if (_lstSelInf.ContainsKey(activeRow.ListIndex)) // 選択解除する
                        {
                            _lstSelInf.Remove(activeRow.ListIndex);
                        }

                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "複数のシステム区分は選択出来ません。",
                            -1,
                            MessageBoxButtons.OK);
                    }
                }

                // マウスダブルクリックによる場合は以下の処理しない。
                if (moveFlg)
                {
                    UltraGridRow ugr = activeRow.GetSibling(SiblingRow.Next);
                    if (ugr != null)
                    {
                        ugr.Activate();
                        ugr.Selected = true;
                    }
                }
            }
        }

        /// <summary>
        /// 選択時のエラーチェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 選択時のエラーチェック処理を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/11/23</br>
        /// </remarks>
        private bool SelectCheck()
        {
            List<int> selectSysDiv = new List<int>();
            // 複数のシステム区分の明細が選択された場合
            foreach (UltraGridRow row in _lstSelInf.Values)
            {
                int sysDiv = (int)row.Cells[column_SystemDivCd].Value;
                if (!selectSysDiv.Contains(sysDiv))
                {
                    selectSysDiv.Add(sysDiv);
                }
            }

            // 複数のシステム区分
            if (selectSysDiv.Count > 1)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 確定時のエラーチェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 確定時のエラーチェック処理を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/11/23</br>
        /// </remarks>
        private bool OKSelectCheck()
        {
            // 明細が一つも選択されていない状態
            foreach (UltraGridRow row in this.uGrid_Details.Rows)
            {
                if ((bool)row.Cells[column_SelectionState].Value)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion ■ privateメソッド ■

        #region ■ publicメソッド ■
        /// <summary>
        /// 画面表示
        /// </summary>
        /// <param name="owner">owner</param>
        /// <remarks>
        /// <br>Note        : 画面表示時に発生します。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/11/23</br>
        /// </remarks> 
        public new DialogResult ShowDialog(IWin32Window owner)
        {
            if (this.uGrid_Details.Rows.Count > 0)
            {
                // 先頭行を選択状態にする
                uGrid_Details.Rows[0].Activate();
                uGrid_Details.Rows[0].Selected = true;
            }
            else
            {
                // 該当データがない場合には、その旨を表示して画面の表示は行わない。
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "該当データがありません。",
                    -1,
                    MessageBoxButtons.OK);

                return DialogResult.Cancel;
            }

            return base.ShowDialog(owner);
        }
        #endregion ■publicメソッド ■
    }
}