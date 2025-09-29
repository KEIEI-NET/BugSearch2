using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Broadleaf.Application.Resources;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Library.Windows.Forms;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// PM.NSサポートツール起動メニュー
    /// </summary>
    /// <remarks>
    /// <br>Note        : </br>
    /// <br>Programmer	: 23003 enokida</br>
    /// <br>Date        : 2014.09.08</br>
    /// </remarks>
    public partial class PMKHN00800UA : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PMKHN00800UA()
        {
            InitializeComponent();
        }

        #region Private Members
        /// <summary> グリッド用データセット </summary>
        private DataSet _dataset = null;
        /// <summary> 起動ツールリストファイルフルパス </summary>
        private string filePath = Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, "PMKHN00800UA_ToolList.xml");

        /// <summary> カラム名：ツール名称 </summary>
        private const string COL_TOOLNAME = "toolName";
        /// <summary> カラム名：アセンブリID </summary>
        private const string COL_TOOLASMID = "assemblyID";
        /// <summary> カラム名：クラス名 </summary>
        private const string COL_TOOLCLASSID = "className";
        /// <summary> カラム名：メソッド名 </summary>
        private const string COL_TOOLMETHOD = "methodName";
        /// <summary> カラム名：起動ボタン </summary>
        private const string COL_TOOLBOOTBTN = "bootBtn";

            #endregion

        #region Event Methods

        /// <summary>
        /// フォーム読込みイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKHN00800UA_Load(object sender, EventArgs e)
        {
            // XML読込み処理
            string errMsg = string.Empty;
            int status = ReadToolListXML(out errMsg);

            if (status == 0)
            {
                // 画面初期設定
                InitializeDisplaySetting();
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Name,
                    errMsg,
                    status,
                    MessageBoxButtons.OK);

                this.Close();
            }

        }

        /// <summary>
        /// グリッド内ボタンセルクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void supportTool_uGrid_ClickCellButton(object sender, CellEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor; // カーソルを待機中にする

                // 起動ボタンがクリックされた場合
                if (e.Cell.Column.Key == COL_TOOLBOOTBTN)
                {
                    string asmid = (string)e.Cell.Row.Cells[COL_TOOLASMID].Value; // アセンブリID取得
                    string classid = (string)e.Cell.Row.Cells[COL_TOOLCLASSID].Value; // クラス名取得                
                    string extension = System.IO.Path.GetExtension(asmid); // 拡張子取得
                    string methodnm = (string)e.Cell.Row.Cells[COL_TOOLMETHOD].Value; // メソッド名取得

                    AsmInvoked(asmid, classid, extension, methodnm);

                }

            }
            catch (FileNotFoundException)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Name,
                    "指定されたファイルが見つかりません。",
                    -1,
                    MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Name,
                    ex.Message,
                    -1,
                    MessageBoxButtons.OK);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// グリッド内キー押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void supportTool_uGrid_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // スペースキーを押下した場合、グリッド内ボタンセルクリック処理と同じ動きをします
                if ((e.KeyCode == Keys.Space) && (this.supportTool_uGrid.ActiveRow != null))
                {
                    this.Cursor = Cursors.WaitCursor; // カーソルを待機中にする

                    string asmid = (string)this.supportTool_uGrid.ActiveRow.Cells[COL_TOOLASMID].Value; // アセンブリID取得
                    string classid = (string)this.supportTool_uGrid.ActiveRow.Cells[COL_TOOLCLASSID].Value; // クラス名取得                
                    string extension = System.IO.Path.GetExtension(asmid); // 拡張子取得
                    string methodnm = (string)this.supportTool_uGrid.ActiveRow.Cells[COL_TOOLMETHOD].Value; // メソッド名取得

                    AsmInvoked(asmid, classid, extension, methodnm);

                }
            }
            catch (FileNotFoundException)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Name,
                    "指定されたファイルが見つかりません。",
                    -1,
                    MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Name,
                    ex.Message,
                    -1,
                    MessageBoxButtons.OK);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        /// <summary>
        /// フォーカス遷移イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if ((e.PrevCtrl == null) || (e.NextCtrl == null))
                return;

        }

        /// <summary>
        /// 閉じるボタンクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void close_uButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// ツールリストXML読込み処理
        /// </summary>
        /// <returns>ステータス[0:正常、-1:エラー、2:ファイルチェックエラー]</returns>
        /// <param name="errMsg">メッセージ</param>
        private int ReadToolListXML(out string errMsg)
        {
            int status = 0;
            errMsg = string.Empty;
            try
            {
                // ファイル存在チェック
                if (!File.Exists(filePath))
                {
                    errMsg = "設定ファイルがありません。";
                    return -1;
                }

                // XMLデータを DataSetに読み込みます
                _dataset = new DataSet();
                _dataset.ReadXml(filePath);
            }
            catch (Exception ex)
            {
                errMsg = "設定ファイルが壊れています。\r\n" + ex.Message;
                status = -1;
            }
            return status;
        }

        /// <summary>
        /// 画面初期設定
        /// </summary>
        private void InitializeDisplaySetting()
        {
            try
            {
                // グリッドにデータをバインド
                supportTool_uGrid.DataSource = _dataset;
                supportTool_uGrid.DataMember = "ToolList";

                // グリッド初期設定
                GridInitialSetting();

            }
            catch (Exception ex)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    ex.Message,
                    -1,
                    MessageBoxButtons.OK);

                this.Hide();
            }
        }

        /// <summary>
        /// グリッド初期設定
        /// </summary>
        private void GridInitialSetting()
        {
            // --- グリッド外観設定 --- //

            #region --- グリッド外観設定 ---
            // GroupByBoxを非表示
            this.supportTool_uGrid.DisplayLayout.GroupByBox.Hidden = true;
            // グリッド全体の外観設定
            this.supportTool_uGrid.DisplayLayout.Appearance.BackColor = Color.White;
            this.supportTool_uGrid.DisplayLayout.Appearance.BackColor2 = Color.FromArgb(198, 219, 255);
            this.supportTool_uGrid.DisplayLayout.Appearance.BackGradientStyle = GradientStyle.Vertical;
            // フォントサイズ
            this.supportTool_uGrid.DisplayLayout.Appearance.FontData.SizeInPoints = 14;

            // 行複数選択設定
            this.supportTool_uGrid.DisplayLayout.Override.SelectTypeRow = SelectType.None;
            // 行のサイズ変更不可
            this.supportTool_uGrid.DisplayLayout.Override.RowSizing = RowSizing.Fixed;
            // 列複数選択設定
            this.supportTool_uGrid.DisplayLayout.Override.SelectTypeCol = SelectType.None;
            // 列幅の自動調整
            this.supportTool_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            // 行の追加不可
            this.supportTool_uGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            // 行の削除不可
            this.supportTool_uGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            // 列の移動不可
            this.supportTool_uGrid.DisplayLayout.Override.AllowColMoving = AllowColMoving.NotAllowed;
            // 列のサイズ変更不可
            this.supportTool_uGrid.DisplayLayout.Override.AllowColSizing = AllowColSizing.None;
            // 列の交換不可
            this.supportTool_uGrid.DisplayLayout.Override.AllowColSwapping = AllowColSwapping.NotAllowed;
            // フィルタの使用不可
            this.supportTool_uGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.False;
            // IME制御
            this.supportTool_uGrid.ImeMode = ImeMode.Disable;
            // HeaderSortを追加
            this.supportTool_uGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
            // タイトルの外観設定
            this.supportTool_uGrid.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.supportTool_uGrid.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.supportTool_uGrid.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = GradientStyle.Vertical;
            this.supportTool_uGrid.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
            this.supportTool_uGrid.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Alpha.Transparent;
            // 行セレクタの外観設定
            this.supportTool_uGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.supportTool_uGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.supportTool_uGrid.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = GradientStyle.Vertical;
            this.supportTool_uGrid.DisplayLayout.Override.RowSelectorAppearance.ForeColor = Color.White;
            // 互い違いの行の色を変更
            this.supportTool_uGrid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Lavender;
            // 行セレクタ表示有り
            this.supportTool_uGrid.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True;
            // スクロールバー表示
            this.supportTool_uGrid.DisplayLayout.Scrollbars = Scrollbars.Vertical;
            this.supportTool_uGrid.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
            // アクティブ行の外観設定
            this.supportTool_uGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.White;
            this.supportTool_uGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = Color.FromArgb(251, 230, 148);
            this.supportTool_uGrid.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = GradientStyle.Vertical;
            this.supportTool_uGrid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Black;
            // 文字位置（縦）の設定
            this.supportTool_uGrid.DisplayLayout.Override.ActiveCellAppearance.TextVAlign = VAlign.Middle;
            this.supportTool_uGrid.DisplayLayout.Override.EditCellAppearance.TextVAlign = VAlign.Middle;
            this.supportTool_uGrid.DisplayLayout.Override.CellAppearance.TextVAlign = VAlign.Middle;
            // 行間の罫線色の設定
            this.supportTool_uGrid.DisplayLayout.Override.RowAppearance.BorderColor = Color.FromArgb(1, 68, 208);
            // 編集中の色の設定
            this.supportTool_uGrid.DisplayLayout.Override.EditCellAppearance.BackColor = Color.FromArgb(247, 227, 156);
            // マウスポインタのカーソル形状
            this.supportTool_uGrid.Cursor = Cursors.Arrow;
            // スクロールチップを非表示
            this.supportTool_uGrid.DisplayLayout.Override.TipStyleScroll = TipStyle.Hide;


            #endregion

            // --- グリッドカラム情報設定 --- //
            
            // グリッドのカラムを取得
            ColumnsCollection columns = this.supportTool_uGrid.DisplayLayout.Bands[0].Columns;
            // 一旦すべての列を非表示に設定する
            foreach (UltraGridColumn col in columns)
            {
                col.Hidden = true;
            }

            // ツール名（toolname）
            columns[COL_TOOLNAME].Header.Caption = "サポートツール名";
            columns[COL_TOOLNAME].Hidden = false;
            columns[COL_TOOLNAME].CellActivation = Activation.NoEdit;

            // ツールPGID
            columns[COL_TOOLASMID].Header.Caption = "PGID";
            columns[COL_TOOLASMID].Hidden = true;
            columns[COL_TOOLASMID].CellActivation = Activation.NoEdit;

            // ツールクラスID
            columns[COL_TOOLCLASSID].Header.Caption = "CLASSID";
            columns[COL_TOOLCLASSID].Hidden = true;
            columns[COL_TOOLCLASSID].CellActivation = Activation.NoEdit;

            // ツールメソッド
            columns[COL_TOOLMETHOD].Header.Caption = "METHOD";
            columns[COL_TOOLMETHOD].Hidden = true;
            columns[COL_TOOLMETHOD].CellActivation = Activation.NoEdit;

            // 特定行のボタンだけ押下不可ってできないのかな・・・

            // 起動ボタン
            columns[COL_TOOLBOOTBTN].Header.Caption = "起動";
            columns[COL_TOOLBOOTBTN].Hidden = false;
            columns[COL_TOOLBOOTBTN].CellActivation = Activation.NoEdit;
            columns[COL_TOOLBOOTBTN].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[COL_TOOLBOOTBTN].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[COL_TOOLBOOTBTN].CellButtonAppearance.ForeColorDisabled = Color.OrangeRed;
            columns[COL_TOOLBOOTBTN].Width = 10;
            columns[COL_TOOLBOOTBTN].CellButtonAppearance.TextHAlign = HAlign.Center;
            columns[COL_TOOLBOOTBTN].CellButtonAppearance.TextVAlign = VAlign.Middle;

        }

        /// <summary>
        /// アセンブリ起動
        /// </summary>
        /// <param name="asmid">アセンブリID</param>
        /// <param name="classid">クラス名</param>
        /// <param name="extension">拡張子</param>
        /// <param name="methodnm">メソッド名</param>
        private void AsmInvoked(string asmid, string classid, string extension, string methodnm)
        {

            switch (extension)
            {
                case ".exe":
                case ".EXE":
                    {
                        StringBuilder arguments = new StringBuilder();
                        // ログインパラメータを取得
                        Broadleaf.Application.Common.ApplicationStartControl applicationStartControl = new Broadleaf.Application.Common.ApplicationStartControl();
                        string[] loginArguments = applicationStartControl.Parameters;
                        foreach (string argument in loginArguments)
                        {
                            if (argument.Trim() != string.Empty)
                            {
                                arguments.Append(argument + " ");
                            }
                        }

                        // 起動パラメータを設定　特にない？　
                        //arguments.Append(　);

                        System.Diagnostics.Process proc = new System.Diagnostics.Process();
                        proc.StartInfo.FileName = asmid;
                        proc.StartInfo.Arguments = arguments.ToString(); //コマンドライン引数

                        // exe起動
                        proc.Start();
                        break;
                    }
                case ".dll":
                case ".DLL":
                    {

                        System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(asmid);
                        Type type = assembly.GetType(classid);
                        if (type != null)
                        {
                            object obj = Activator.CreateInstance(type);
                            if (methodnm != string.Empty)
                            {
                                //System.Reflection.MethodInfo myMethod = type.GetMethod(methodnm);
                                //myMethod.Invoke(obj, null); // パラメータなし

                                type.InvokeMember(methodnm, System.Reflection.BindingFlags.InvokeMethod, null, obj, null); // パラメータなし
                            }
                            else
                            {
                                Form form = obj as Form;
                                form.Show();
                            }
                        }
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion








    }
}