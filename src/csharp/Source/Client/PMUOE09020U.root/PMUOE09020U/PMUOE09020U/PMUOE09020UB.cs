//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 外車対応メーカー画面設定
// プログラム概要   : 外車対応メーカー画面設定を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 葛中華
// 作 成 日  2011/10/26  修正内容 : 新規作成
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
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using System.IO;
using System.Xml;
using System.Web;
using System.Collections;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 外車対応メーカー画面設定
    /// </summary>
    /// <remarks>
    /// <br>Note       : 外車対応メーカー画面設定フォームクラスです。</br>
    /// <br>Programmer : 葛中華</br>
    /// <br>Date       : 2011/10/26</br>
    /// </remarks>
    public partial class PMUOE09020UB : Form
    {
        # region Constructor
        public PMUOE09020UB()
        {
            InitializeComponent();

            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;

            this._makerAcs = new MakerAcs();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        }
        # endregion

        # region Private Members
        private bool _canClose;
        private bool bevalueFlag = true;
        private string _beMakerCd = string.Empty;
        private ImageList _imageList16 = null;
        private MakerAcs _makerAcs;                        // メーカーアクセスクラス
        private string _enterpriseCode;                    // 企業コード
        private ArrayList preList = new ArrayList();
        private UltraGridCell _preCell;

        /// <summary>データテーブル</summary>
        private DataTable _dt;

        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった際に発生します。</remarks>
        public event MasterMaintenanceArrayTypeUnDisplayingEventHandler UnDisplaying;

        private const string MAKER_TABLE = "Maker_table";
        private const string SAVE_XML_NAME = "PMUOE09020U_Maker.xml";

        private const string MAKERNO = "No.";
        private const string MAKERCOL = "EmptyCol";
        private const string MAKERCODE = "MakerCode";
        private const string MAKERGUID = "Guide";
        // プログラムID
        private const string ASSEMBLY_ID = "PMUOE09020UB";
        public string _UOECdparameter = null;
        public List<UoeCdparameterList> tempList = new List<UoeCdparameterList>();
        public List<string> list = new List<string>();
        /// <summary>画面終了設定プロパティ</summary>
        /// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
        /// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
        public bool CanClose
        {
            get
            {
                return _canClose;
            }
            set
            {
                _canClose = value;
            }
        }
        # endregion

        # region Event Methods
        /// <summary>
        /// Form.Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : Form.Loadときに発生します。</br>
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void PMUOE09020UB_Load(object sender, EventArgs e)
        {
            this.Ok_Button.ImageList = this._imageList16;
            this.Cancel_Button.ImageList = this._imageList16;

            this.Ok_Button.Appearance.Image = (int)Size16_Index.SAVE;
            this.Cancel_Button.Appearance.Image = (int)Size16_Index.CLOSE;

            DataTableConstruction();
            InitialSetGridCol();
            SetData();
            tempList = XmlLoad();
            for (int index = 0; index < uGrid.Rows.Count; index++)
            {
                string prestring = this.uGrid.Rows[index].Cells[MAKERCODE].Value.ToString();
                preList.Add(prestring);
            }

        }
        /// <summary>
        /// Control.Click イベント(Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : Control.Clickときに発生します。</br>
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            this.Ok_Button.Focus();
            this.DataToXmlFile(_dt);
            
        }
        /// <summary>
        /// Control.Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : Control.Clickときに発生します。</br>
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Cancel_Button.Focus();
            if (!CompareOriginalScreen())
            {
                //画面情報が変更されていた場合は、保存確認メッセージを表示する
                DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                  "",
                                                  0,
                                                  MessageBoxButtons.YesNoCancel,
                                                  MessageBoxDefaultButton.Button1);

                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            // 保存処理
                            Ok_Button_Click(sender, e);
                            int code = 0;
                            if (!CheckData(out code))
                            {
                                return;
                            }
                            this.DialogResult = DialogResult.OK;

                            break;
                        }
                    case DialogResult.No:
                        {
                            this.DialogResult = DialogResult.Cancel;
                            break;
                        }
                    default:
                        {
                            this.Cancel_Button.Focus();
                            return;
                        }
                }
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// tArrowKeyControl1_ChangeFocusイベント
        /// </summary>
        /// <param name= "sender">対象オブジェクト</param>
        /// <param name= "e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : tArrowKeyControl1_ChangeFocusイベント</br>
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }
            if (e.PrevCtrl == this.uGrid)
            {
                // シフトキーを押さない
                if (!e.ShiftKey)
                {
                    // アクティブセルが存在する
                    if (this.uGrid.ActiveCell != null)
                    {
                        if ((this.uGrid.ActiveCell.Row.Index == this.uGrid.Rows.Count - 1
                           && this.uGrid.ActiveCell.Column.Key == MAKERGUID) ||
                           this.uGrid.ActiveCell.Column.Key == MAKERCODE
                           && this.uGrid.ActiveCell.Row.Index == this.uGrid.Rows.Count - 1
                           && !string.IsNullOrEmpty(this.uGrid.Rows[this.uGrid.ActiveCell.Row.Index].Cells[MAKERCODE].Value.ToString()))
                        {
                            e.NextCtrl = Ok_Button;
                        }
                        else if (this.uGrid.ActiveCell.Row.Index < this.uGrid.Rows.Count
                                && this.uGrid.ActiveCell.Column.Key == MAKERCODE
                           && !string.IsNullOrEmpty(this.uGrid.Rows[this.uGrid.ActiveCell.Row.Index].Cells[MAKERCODE].Value.ToString())
                                 && e.Key != Keys.LButton)
                        {

                            this.uGrid.ActiveCell = this.uGrid.Rows[this.uGrid.ActiveCell.Row.Index + 1].Cells[MAKERCODE];
                            this.uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            e.NextCtrl = null;
                        }
                        else if (this.uGrid.ActiveCell.Row.Index == this.uGrid.Rows.Count - 1)
                        {
                            if (this.uGrid.Rows.Count < 99 && e.Key != Keys.LButton)
                            {
                                DataRow dr = this._dt.NewRow();
                                dr[MAKERNO] = this.uGrid.Rows.Count + 1;
                                dr[MAKERCODE] = string.Empty;
                                this._dt.Rows.Add(dr);
                                InitialSetGridCol();
                                this.uGrid.ActiveCell = this.uGrid.Rows[this.uGrid.Rows.Count - 1].Cells[MAKERCODE];
                                this.uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                e.NextCtrl = null;
                            }
                        }
                        else if (e.Key != Keys.LButton)
                        {
                            // 次のセルに移動
                            this.uGrid.PerformAction(UltraGridAction.NextCellByTab);
                            e.NextCtrl = null;
                        }
                       
                    }
                }
                // シフトキーを押す
                else
                {
                    // アクティブセルが存在する
                    if (this.uGrid.ActiveCell != null)
                    {
                        if (this.uGrid.ActiveCell.Row.Index == 0 && this.uGrid.ActiveCell.Column.Key == MAKERCODE)
                        {
                            e.NextCtrl = Cancel_Button;
                        }
                        else
                        {
                            // 前のセルに移動
                            this.uGrid.PerformAction(UltraGridAction.PrevCellByTab);
                            e.NextCtrl = null;
                        }
                    }
                }
            }
            if (e.PrevCtrl == this.Ok_Button)
            {
                if (e.ShiftKey)
                {
                    e.NextCtrl = this.uGrid;
                    this.uGrid.PerformAction(UltraGridAction.LastCellInGrid);
                }
            }
            if (e.PrevCtrl == this.Cancel_Button)
            {
                if (!e.ShiftKey && e.Key != Keys.LButton
                    && e.Key != Keys.Left
                    && e.Key != Keys.Up)
                {
                    e.NextCtrl = null;
                    this.uGrid.PerformAction(UltraGridAction.FirstCellInGrid);
                    this.uGrid.Rows[0].Cells[MAKERCODE].Activate();
                    this.uGrid.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
        }
        /// <summary>
        /// uGrid_AfterPerformActionイベント
        /// </summary>
        /// <param name= "sender">対象オブジェクト</param>
        /// <param name= "e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : uGrid_AfterPerformActionを行います。</br>
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void uGrid_AfterPerformAction(object sender, AfterUltraGridPerformActionEventArgs e)
        {
            switch (e.UltraGridAction)
            {
                case Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell:
                    // アクティブなセルがあるか？または編集可能セルか？
                    UltraGridCell ugCell = this.uGrid.ActiveCell;
                    if ((ugCell != null) &&
                        (ugCell.Column.CellActivation == Activation.AllowEdit) &&
                        (ugCell.Activation == Activation.AllowEdit))
                    {
                        // アクティブセルのスタイルを取得
                        switch (this.uGrid.ActiveCell.StyleResolved)
                        {
                            // エディット系スタイル
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                                {
                                    // 編集モードにある？
                                    if (this.uGrid.PerformAction(UltraGridAction.EnterEditMode))
                                    {
                                        if ((this.uGrid.ActiveCell.Value is System.DBNull) ||
                                            (this.uGrid.ActiveCell.Value == DBNull.Value))
                                        {
                                        }
                                        else
                                        {
                                            if (this.uGrid.ActiveCell.IsInEditMode)
                                            {
                                                // 全選択
                                                this.uGrid.ActiveCell.SelectAll();
                                            }
                                        }
                                    }
                                    break;
                                }
                            default:
                                {
                                    // エディット系以外のスタイルであれば、編集状態にする。
                                    this.uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    break;
                                }
                        }
                    }
                    break;
            }
        }
        /// <summary>
        /// uGrid_InitializeLayoutイベント
        /// </summary>
        /// <param name= "sender">対象オブジェクト</param>
        /// <param name= "e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : uGrid_FeeInfo_InitializeLayoutイベント</br>
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void uGrid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            MakeKeyMappingForGrid(uGrid);
        }
        /// <summary>
        /// Timer.Tick イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 指定された間隔の時間が経過したときに発生します。
        ///                   この処理は、システムが提供するスレッド プール
        ///	                  スレッドで実行されます。</br>
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.uGrid.ActiveCell = this._preCell;
            this.uGrid.PerformAction(UltraGridAction.EnterEditMode);
            this._preCell = null;
        }
        /// <summary>
        ///	ultraGrid.KeyPress イベント(Cell)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRIDのキー押下イベント処理。</br>
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void uGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid.ActiveCell;

            // メーカーコードの入力桁数チェック
            if (cell.Column.Key == MAKERCODE)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// Control.KeyDown イベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : キーが押されたときに発生します。</br>
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void uGrid_KeyDown(object sender, KeyEventArgs e)
        {
            // アクティブセルがnullの時は処理を行わず終了
            if (this.uGrid.ActiveCell == null)
            {
                return;
            }

            // グリッド状態取得()
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.uGrid.CurrentState;

            //ドロップダウン状態の時は処理しない(UltraGridのデフォルトの動きにする)
            Control nextControl = null;
            if ((e.Control == false) && (e.Shift == false) && (e.Alt == false) &&
                ((status & Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown) != Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown))
            {

                switch (e.KeyCode)
                {
                    // ↑キー
                    case Keys.Up:
                        {
                            // 上のセルへ移動
                            nextControl = MoveAboveCell();
                            e.Handled = true;
                            break;
                        }
                    // ↓キー
                    case Keys.Down:
                        {
                            // 下のセルへ移動
                            nextControl = MoveBelowCell();
                            e.Handled = true;
                            break;
                        }
                    // ←キー
                    case Keys.Left:
                        {
                            // leftのセルへ移動
                            if (this.uGrid.ActiveCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                            {
                                this.uGrid.PerformAction(UltraGridAction.PrevCellByTab);
                                e.Handled = true;
                            }
                            else
                            {
                                this.uGrid.PerformAction(UltraGridAction.ActivateCell);
                                e.Handled = true;
                            }
                           
                            break;
                        }
                    // →キー
                    case Keys.Right:
                        {
                            // rightのセルへ移動
                            if (this.uGrid.ActiveCell.StyleResolved != Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                            {
                                this.uGrid.PerformAction(UltraGridAction.NextCellByTab);
                                e.Handled = true;
                            }
                            else
                            {
                                this.uGrid.PerformAction(UltraGridAction.ActivateCell);
                                e.Handled = true;
                            }
                         
                            break;
                        }
                    case Keys.Space:
                        {
                            if (this.uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                            {
                                UltraGridCell ultraGridCell = this.uGrid.ActiveCell;
                                CellEventArgs cellEventArgs = new CellEventArgs(ultraGridCell);
                                uGrid_ClickCellButton(sender, cellEventArgs);
                            }
                            break;
                        }
                }

                if (nextControl != null)
                {
                    nextControl.Focus();
                }
            }
        }
        /// <summary>
        /// リッドガイドボタン
        /// </summary>
        /// <param name= "sender">対象オブジェクト</param>
        /// <param name= "e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : グリッドガイドボタン処理</br>
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void uGrid_ClickCellButton(object sender, CellEventArgs e)
        {
            bevalueFlag = true;
            MakerUMnt makerUMnt; 
            int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
            int index = e.Cell.Row.Index;
            if (e.Cell.Column.Key == MAKERGUID)
            {
                if (status == 0)
                {
                    // 結果セット
                    this.uGrid.Rows[index].Cells[MAKERCODE].Value = makerUMnt.GoodsMakerCd.ToString("0000");
                }
            }
        }
        /// <summary>
        /// uGrid_AfterCellUpdateイベント
        /// </summary>
        /// <param name= "sender">対象オブジェクト</param>
        /// <param name= "e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : uGrid_AfterCellUpdate</br>
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void uGrid_AfterCellUpdate(object sender, CellEventArgs e)
        {
            string cellKey = e.Cell.Column.Key;
            bevalueFlag = true;
            this.uGrid.ImeMode = ImeMode.Disable;
            if (!string.IsNullOrEmpty(_beMakerCd))
            {
                _beMakerCd = _beMakerCd.PadLeft(4, '0');
            }
            if (cellKey == MAKERCODE)
            {
                string code = e.Cell.Row.Cells[MAKERCODE].Value.ToString();
                if (!String.IsNullOrEmpty(code))
                {
                    code = code.PadLeft(4, '0');
                }
                string name = string.Empty;
                if (!_beMakerCd.Equals(code) && code != "")
                {
                    name = GetGoodsMaker(code);
                    if (name != null)
                    {
                        if (tempList == null)
                        {
                            if (list.Count == 0)
                            {
                                list.Add(code);
                                e.Cell.Value = code;
                            }
                            else
                            {
                                if (list.Contains(code))
                                {
                                    TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    ASSEMBLY_ID,
                                    "該当するメーカーコードが重複します。",
                                    -1,
                                    MessageBoxButtons.OK);
                                    bevalueFlag = false;
                                    e.Cell.Value = _beMakerCd;
                                    this._preCell = e.Cell;
                                    timer1.Enabled = true;
                                }
                                else
                                {
                                    list.Add(code);
                                    list.Remove(_beMakerCd);
                                    e.Cell.Value = code;
                                }
                            }
                        }
                        else
                        {
                            if (list.Count == 0)
                            {
                                list.Add(code);
                                e.Cell.Value = code;
                            }
                            else
                            {
                                if (list.Contains(code))
                                {
                                    TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    ASSEMBLY_ID,
                                    "該当するメーカーコードが重複します。",
                                    -1,
                                    MessageBoxButtons.OK);
                                    bevalueFlag = false;
                                    e.Cell.Value = _beMakerCd;
                                    this._preCell = e.Cell;
                                    timer1.Enabled = true;
                                }
                                else
                                {
                                    list.Add(code);
                                    list.Remove(_beMakerCd);
                                    e.Cell.Value = code;
                                }
                            }
                        }
                    }
                    else
                    {
                        // エラーメッセージ
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            ASSEMBLY_ID,
                            "該当するメーカーコードが存在しません。",
                            -1,
                            MessageBoxButtons.OK);
                        bevalueFlag = false;
                        e.Cell.Value = _beMakerCd;
                        this._preCell = e.Cell;
                        timer1.Enabled = true;
                    }
                }
                else
                {
                    if (code == "")
                    {
                        list.Remove(_beMakerCd);
                    }
                }
            }
        }
        /// <summary>
        /// uGrid_BeforeCellActivateイベント
        /// </summary>
        /// <param name= "sender">対象オブジェクト</param>
        /// <param name= "e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : uGrid_BeforeCellActivate</br>
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void uGrid_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            if (bevalueFlag)
            {
                _beMakerCd = e.Cell.Row.Cells[MAKERCODE].Value.ToString();
            }
        }
        # endregion 

        # region Private Methods
        /// <summary>
        /// 画面情報比較処理
        /// </summary>
        /// <returns>ステータス(True:変更なし False:変更あり)</returns>
        /// <remarks>
        /// <br>Note       : 画面読込時と画面終了時のデータを比較します。</br>
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private bool CompareOriginalScreen()
        {
            bool resflag = true;
            ArrayList list = new ArrayList();
            for (int index = 0; index < uGrid.Rows.Count; index++)
            {
                string str = this.uGrid.Rows[index].Cells[MAKERCODE].Value.ToString();
                list.Add(str);
            }
            if (preList.Count != list.Count)
            {
                resflag = false;
            }
            else
            {
                for (int i = 0; i < preList.Count; i++)
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (preList[i] != list[j] && i == j)
                        {
                            resflag = false;
                        }
                    }
                }
            }
            return resflag;
        }
        /// <summary>
        /// CheckData
        /// </summary>
        /// <param name="errorindex">errorindex</param>
        /// <returns>resultflag</returns>
        /// <remarks>
        /// <br>Note       : CheckData</br>
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private bool CheckData(out int errorindex)
        {
            bool resultflag = true;
            errorindex = 0;

            for (int i = 0; i < this.uGrid.Rows.Count; i++)
            {
                if (String.IsNullOrEmpty(this.uGrid.Rows[i].Cells[MAKERCODE].Value.ToString()))
                {
                    resultflag = false;
                    errorindex = i;
                    break;
                }
                if (!Int32.TryParse(this.uGrid.Rows[i].Cells[MAKERCODE].Value.ToString(), out errorindex))
                {
                    resultflag = false;
                    errorindex = i;
                    break;
                }

                if (this.uGrid.Rows[i].Cells[MAKERCODE].Value.ToString() == "0")
                {
                    this.uGrid.Rows[i].Cells[MAKERCODE].Value = DBNull.Value;
                }

                if (i != 0)
                {
                    if (this.uGrid.Rows[i].Cells[MAKERCODE].Value.ToString() != "")
                    {
                        resultflag = false;
                        errorindex = i;
                        break;
                    }
                }
            }
            return resultflag;
        }
        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <param name="defaultButton">初期表示ボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // 親ウィンドウフォーム
                                         errLevel,                          // エラーレベル
                                         ASSEMBLY_ID,                       // アセンブリID
                                         message,                           // 表示するメッセージ
                                         status,                            // ステータス値
                                         msgButton,                         // 表示するボタン
                                         defaultButton);                    // 初期表示ボタン
            return dialogResult;
        }
        /// <summary>
        /// グリッドキーマッピング設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッドキーマッピング設定処理を行います。</br>
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void MakeKeyMappingForGrid(UltraGrid grid)
        {
            Infragistics.Win.UltraWinGrid.GridKeyActionMapping enterMap;

            //----- Enterキー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- Shift + Enterキー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.AltCtrl,
                Infragistics.Win.SpecialKeys.Shift,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- ↑キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- ↑キー (最上段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- ↓キー (最下段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowLast | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- ↓キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- 前頁キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Prior,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- 次頁キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Next,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);
        }
        /// <summary>
        /// データテーブル設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データテーブルを設定します。</br>
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void DataTableConstruction()
        {
            if (this._dt == null)
            {
                //// テーブルの定義
                this._dt = new DataTable(MAKER_TABLE);

                this._dt.Columns.Add(MAKERNO, typeof(int));
                this._dt.Columns.Add(MAKERCOL, typeof(string));
                this._dt.Columns.Add(MAKERCODE, typeof(string));
                this._dt.Columns.Add(MAKERGUID, typeof(string));
            }
            this.uGrid.DataSource = this._dt.DefaultView;
        }
        /// <summary>
        /// xml to datatable処理
        /// </summary>
        /// <remarks>
        /// <br>Note       :datatable to xml処理を行います。</br>
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private List<UoeCdparameterList> XmlLoad()
        {
            List<UoeCdparameterList> fromXmlUoeList = null;
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, SAVE_XML_NAME)))
            {
                try
                {
                    // XMLから抽出条件アイテムクラス配列にデシリアライズする
                    fromXmlUoeList = UserSettingController.DeserializeUserSetting<List<UoeCdparameterList>>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, SAVE_XML_NAME));
                }
                catch (InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, SAVE_XML_NAME));
                }
                if (fromXmlUoeList.Count > 0 || fromXmlUoeList != null)
                {
                    for (int i = 0; i < fromXmlUoeList.Count; i++)
                    {
                        UoeCdparameterList fromXmlUoeCdList = (UoeCdparameterList)fromXmlUoeList[i];
                        if (fromXmlUoeCdList.UoeCdparameter.Equals(this._UOECdparameter))
                        {
                            for (int j = 0; j < fromXmlUoeCdList.MakerCdList.Count; j++)
                            {
                                this.uGrid.Rows[j].Cells[MAKERCODE].Value = fromXmlUoeCdList.MakerCdList[j];
                                this.uGrid.Rows[j].Activated = true;
                            }
                            this.uGrid.Rows[0].Activated = true;
                            list = fromXmlUoeCdList.MakerCdList;
                        }
                    }
                }
            }
            return fromXmlUoeList;
        }
        /// <summary>
        /// datatable to xml処理
        /// </summary>
        /// <param name="dt"> データテーブル</param>
        /// <remarks>
        /// <br>Note       :datatable to xml処理を行います。</br>
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void DataToXmlFile(DataTable dt)
        {
             List<UoeCdparameterList> uoeList = tempList;
           
            bool newflag = false;
            try
            {
                if (dt != null)
                {
                    // loop uoeList
                    if (uoeList == null)
                    {
                        uoeList = new List<UoeCdparameterList>();
                        UoeCdparameterList uoeCdList = new UoeCdparameterList();
                        uoeCdList.UoeCdparameter = this._UOECdparameter;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (!String.IsNullOrEmpty(dt.Rows[i][2].ToString()))
                            {
                                uoeCdList.MakerCdList.Add(dt.Rows[i][2].ToString());
                            }
                        }
                        uoeList.Add(uoeCdList);
                    }
                    else
                    {
                        for (int i = 0; i < uoeList.Count; i++)
                        {
                            UoeCdparameterList uoeCdList = (UoeCdparameterList)uoeList[i];
                            if (uoeCdList.UoeCdparameter.Equals(this._UOECdparameter))
                            {
                                newflag = true;
                                uoeCdList.MakerCdList = new List<string>();
                                for (int j = 0; j < dt.Rows.Count; j++)
                                {
                                    if (!String.IsNullOrEmpty(dt.Rows[j][2].ToString()))
                                    {
                                        uoeCdList.MakerCdList.Add(dt.Rows[j][2].ToString());
                                    }
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        if (!newflag)
                        {
                            if (uoeList == null)
                            {
                                uoeList = new List<UoeCdparameterList>();
                            }

                            UoeCdparameterList uoeCdList = new UoeCdparameterList();
                            uoeCdList.UoeCdparameter = this._UOECdparameter;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (!String.IsNullOrEmpty(dt.Rows[i][2].ToString()))
                                {
                                    uoeCdList.MakerCdList.Add(dt.Rows[i][2].ToString().PadLeft(4, '0'));                               
                                }
                            }
                            uoeList.Add(uoeCdList);
                        }
                    }
                  
                    // 抽出条件アイテムクラス配列をXMLにシリアライズする
                    UserSettingController.SerializeUserSetting(uoeList, Path.Combine(ConstantManagement_ClientDirectory.UISettings, SAVE_XML_NAME));
                    this.Close();
                }
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// メーカー名称取得処理
        /// </summary>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <returns>メーカー名称 ※該当するものがない場合、<c>null</c>を返します。</returns>
        /// <remarks>
        /// <br>Note       : メーカー名称を取得します。</br>
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// <br></br>
        /// </remarks>
        private string GetGoodsMaker(string goodsMakerCd)
        {
            string CoodsMakerName = string.Empty;
            MakerUMnt makerUMnt;
            try
            {
                int status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, Convert.ToInt32(goodsMakerCd));
                if (status == 0 && makerUMnt.LogicalDeleteCode == 0)
                {
                    // 結果セット
                    CoodsMakerName = makerUMnt.MakerName;
                }
                else
                {
                    // 結果セット
                    CoodsMakerName = null;
                }
            }
            catch
            {
                CoodsMakerName = null;
            }

            return CoodsMakerName;
        }
        /// <summary>
        /// 画面のグリトデータ設定
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 画面のグリトデータ設定を行います。</br>
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void SetData()
        {
            for (int i = 0; i < 10; i++)
            {
                DataRow dr = this._dt.NewRow();
                dr[MAKERNO] = i + 1;
                dr[MAKERCODE] = string.Empty;
                this._dt.Rows.Add(dr);
            }
        }
        /// <summary>
        /// 上のセルへ移動処理
        /// </summary>
        /// <returns>次のコントロール</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアクティブセルを上のセルに移動します。</br>
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private Control MoveAboveCell()
        {
            bool performActionResult;

            // アクティブセルがnull
            if (this.uGrid.ActiveCell == null)
            {
                return null;
            }

            // グリッド状態取得
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.uGrid.CurrentState;


            // 上のセルに移動
            performActionResult = this.uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell);
            if (performActionResult)
            {
                if ((this.uGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    this.uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            return null;
        }
        /// <summary>
        /// 下のセルへ移動処理
        /// </summary>
        /// <returns>次のコントロール</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアクティブセルを下のセルに移動します。</br>
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private Control MoveBelowCell()
        {
            bool performActionResult;

            // アクティブセルがnull
            if (this.uGrid.ActiveCell == null)
            {
                return null;
            }

            // グリッド状態取得
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.uGrid.CurrentState;


            // セル移動前アクティブセルのインデックス
            int prevCol = this.uGrid.ActiveCell.Column.Index;
            int prevRow = this.uGrid.ActiveCell.Row.Index;

            // 下のセルに移動
            performActionResult = this.uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);
            if (performActionResult)
            {
                if ((this.uGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    this.uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            return null;
        }
        /// <summary>
        /// 数値入力チェック処理
        /// </summary>
        /// <param name="keta">桁数(マイナス符号を含まず)</param>
        /// <param name="priod">小数点以下桁数</param>
        /// <param name="prevVal">現在の文字列</param>
        /// <param name="key">入力されたキー値</param>
        /// <param name="selstart">カーソル位置</param>
        /// <param name="sellength">選択文字長</param>
        /// <param name="minusFlg">マイナス入力可？</param>
        /// <param name="NumberFlg">数値入力可？</param>
        /// <returns>true=入力可,false=入力不可</returns>
        /// <remarks>
        /// Note		   : 押されたキーが数値のみ有効にする処理を行います。<br />
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg, Boolean NumberFlg)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }

            // 押されたキーが数値以外、かつ数値以外入力不可
            if (!Char.IsDigit(key) && !NumberFlg)
            {
                return false;
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string _strResult = "";
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // マイナスのチェック
            if (key == '-')
            {
                // マイナス(小数点)が入力可能か？
                if (minusFlg == false)
                {
                    return false;
                }
            }

            // 小数点のチェック
            if (key == '.')
            {
                // 小数点以下桁数が0か？
                if (priod == 0)
                {
                    return false;
                }
                else
                {
                    // 小数点が既に存在するか？
                    if (_strResult.Contains("."))
                    {
                        return false;
                    }
                }
            }
            else
            {
                // 小数点が既に存在するか？
                if (_strResult.Contains("."))
                {
                    int index = _strResult.IndexOf('.');
                    string strDecimal = _strResult.Substring(index + 1);

                    if ((strDecimal.Length >= priod) && (selstart > index))
                    {
                        // 小数桁が入力可能桁数以上で、カーソル位置が小数点以降
                        return false;
                    }
                    else if (((keta - priod) < index))
                    {
                        // 整数部の桁数が入力可能桁数を超えた
                        return false;
                    }
                }
                else
                {
                    // 小数点桁数を前提に整数部の桁数を決定
                    if (((keta - priod) <= _strResult.Length))
                    {
                        return false;
                    }
                }
            }

            // キーが押された結果の文字列を生成する。
            _strResult = prevVal.Substring(0, selstart) + key
                       + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // 桁数チェック！
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else if (_strResult.Contains("."))
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else if ((_strResult[0] == '-') && (_strResult.Contains(".")))
                {
                    if (_strResult.Length > (keta + 2))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// グリト設定
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面のグリト設定を行います。</br>
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void InitialSetGridCol()
        {
            // グリッドの背景色
            this.uGrid.DisplayLayout.Appearance.BackColor = Color.White;
            this.uGrid.DisplayLayout.Appearance.BackColor2 = Color.FromArgb(198, 219, 255);
            this.uGrid.DisplayLayout.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // 行の追加不可
            this.uGrid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            // 行のサイズ変更不可
            this.uGrid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            // 行の削除不可
            this.uGrid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            // 列の移動不可
            this.uGrid.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            // 列のサイズ変更不可
            this.uGrid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            // 列の交換不可
            this.uGrid.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            // フィルタの使用不可
            this.uGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // タイトルの外観設定
            this.uGrid.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.uGrid.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.uGrid.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
            this.uGrid.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

            // グリッドの選択方法を設定（セル単体の選択のみ許可）
            this.uGrid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.uGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            // 互い違いの行の色を変更
            this.uGrid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.White;
            // 行セレクタ表示無し
            this.uGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;

            this.uGrid.DisplayLayout.Override.EditCellAppearance.BackColor = Color.FromArgb(247, 227, 156);
            this.uGrid.DisplayLayout.Override.ActiveCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.uGrid.DisplayLayout.Override.EditCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.uGrid.DisplayLayout.Override.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            // 「ID」は編集不可（固定項目として設定）
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERNO].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERNO].TabStop = false;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERNO].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERNO].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERNO].CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERNO].CellAppearance.ForeColor = Color.White;

            //空白列の設定
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCOL].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCOL].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCOL].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCOL].CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCOL].TabStop = false;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCOL].Header.Caption = string.Empty;

            // メーカーコード列の設定
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].CellActivation = Activation.AllowEdit;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].TabStop = true;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].Header.Caption = string.Empty;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].MaxLength = 4;

            // ガイドボタンの設定
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERGUID].CellActivation = Activation.NoEdit;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERGUID].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERGUID].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERGUID].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERGUID].TabStop = true;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERGUID].CellAppearance.Cursor = Cursors.Hand;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERGUID].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERGUID].CellButtonAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERGUID].CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERGUID].Header.Caption = string.Empty;

            // セルの幅の設定
            if (this.uGrid.Rows.Count > 10)
            {
                this.uGrid.DisplayLayout.Bands[0].Columns[MAKERNO].Width = 50;
                this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCOL].Width = 24;
                this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].Width = 116;
                this.uGrid.DisplayLayout.Bands[0].Columns[MAKERGUID].Width = 24;
            }
            else
            {
                this.uGrid.DisplayLayout.Bands[0].Columns[MAKERNO].Width = 50;
                this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCOL].Width = 25;
                this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].Width = 132;
                this.uGrid.DisplayLayout.Bands[0].Columns[MAKERGUID].Width = 25;
            }

            // 選択行の外観設定
            this.uGrid.DisplayLayout.Override.SelectedRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            this.uGrid.DisplayLayout.Override.SelectedRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            this.uGrid.DisplayLayout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid.DisplayLayout.Override.SelectedRowAppearance.ForeColor = System.Drawing.Color.Black;
            this.uGrid.DisplayLayout.Override.SelectedRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(89, 135, 214);
            this.uGrid.DisplayLayout.Override.SelectedRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(7, 59, 150);

            // アクティブ行の外観設定
            this.uGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            this.uGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            this.uGrid.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = System.Drawing.Color.Black;
            this.uGrid.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(89, 135, 214);
            this.uGrid.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(7, 59, 150);

            // 行セレクタの外観設定
            this.uGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(89)), ((System.Byte)(135)), ((System.Byte)(214)));
            this.uGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(7)), ((System.Byte)(59)), ((System.Byte)(150)));
            this.uGrid.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // 罫線の色を変更
            this.uGrid.DisplayLayout.Appearance.BorderColor = Color.FromArgb(1, 68, 208);
        }
        /// <summary>
        /// 外車対応メーカー画面表示処理
        /// </summary>
        /// <param name="str">発注先コード</param>
        /// <remarks>
        /// <br>Note	   : 外車対応メーカー画面表示処理を行います。</br>
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        public void ShowDialog(string str)
        {
            this._UOECdparameter = str;
            this.ShowDialog();
        }
        # endregion 
    }
    /// <summary>
    /// UoeCdparameterListクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : UoeCdparameterListクラスの処理</br>
    /// <br>Programmer : 葛中華</br>
    /// <br>Date       : 2011/10/26</br>
    /// </remarks>
    public class UoeCdparameterList
    {
        private string _uoeCdparameter;
        private List<string> _makerCdList = new List<string>();
        /// <summary>
        /// 発注先コード
        /// </summary>
        /// <remarks>
        /// <br>Note       : 発注先コード</br>
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        public string UoeCdparameter
        { 
            get
            {
                return _uoeCdparameter;
            }
            set
            {
                _uoeCdparameter = value;
            }
        }
        /// <summary>
        /// メーカーコードのlist
        /// </summary>
        /// <remarks>
        /// <br>Note       : メーカーコードのlist</br>
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        public List<string> MakerCdList
        {
            get
            {
                return _makerCdList;
            }
            set
            {
                _makerCdList = value;
            }
        }
    }
}