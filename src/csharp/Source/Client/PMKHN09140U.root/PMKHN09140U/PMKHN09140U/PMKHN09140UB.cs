//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : 操作履歴ログ表示
// プログラム概要   : エラーログの表示を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/08/08  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 作 成 日  2010/02/22  修正内容 : 列サイズの自動調整=ONを初期値に変更。
//----------------------------------------------------------------------------//
//#define _UT_

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Common.Util;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms.Items;

using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    using SectionItemType   = CodeNamePair<string>;
    using CategoryItemType  = CodeNamePair<int>;
    using PgItemType        = CodeNamePair<string>;
    using LogKindItemType   = CodeNamePair<int>;

    /// <summary>
    /// エラーログの表示フォームコントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>Update Note: 2010.02.22  22018 鈴木 正臣</br>
    /// <br>           : 列サイズの自動調整=ONを初期値に変更。</br>
    /// </remarks>
    public partial class PMKHN09140UB : Form, ISecurityManagementForm
    {
        #region <ISecurityManagementForm メンバ/>

        /// <summary>
        /// 保存ボタンを表示するフラグ
        /// </summary>
        /// <value>true :保存ボタンを表示<br/>false:保存ボタンを非表示</value>
        public bool CanWrite
        {
            get { return false; }
        }

        /// <summary>
        /// 表示更新ボタンを表示するフラグ
        /// </summary>
        /// <value>true :表示更新ボタンを表示<br/>false:表示更新ボタンを非表示</value>
        public bool CanUpdateDisplay
        {
            get { return true; }
        }

        /// <summary>
        /// 保存ボタン押下時の処理を行います。
        /// </summary>
        /// <returns>成功時に 0(=(int)ResultCode.Normal) を返します。 </returns>
        public int Write()
        {
            return (int)ResultCode.Normal;  // 何も処理しない
        }

        /// <summary>
        /// 表示更新ボタン押下時の処理を行います。
        /// </summary>
        public void UpdateDisplay()
        {
            string message = string.Empty;
            if (!UIUtil.IsOKThatInputDateRangeCheck(this.fromTDateEdit, this.toTDateEdit, out message))
            {
                MessageBox.Show(message, MESSEAGE_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LogCondition condition = GetCondition();

            if (DateTimeUtil.HasError(condition.From, condition.To))
            {
                MessageBox.Show(
                    "日時の入力が不正です。",   // LITERAL:
                    MESSEAGE_CAPTION,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            if (condition.HasLogKind)
            {
                OperationHistoryAcs.Instance.RefreshLogSet(condition);
                this.errorLogDB = (LogDataSet)OperationHistoryAcs.Instance.LogSet.Copy();

                RefreshErrorLogGrid(this.errorLogDB, condition);
            }
            else
            {
                // エラーログ
                condition.LogKind = new LogKindItemType((int)LogDataKind.ErrorLog, string.Empty);
                OperationHistoryAcs.Instance.RefreshLogSet(condition);
                this.errorLogDB = (LogDataSet)OperationHistoryAcs.Instance.LogSet.Copy();

                // システムログ
                condition.LogKind = new LogKindItemType((int)LogDataKind.SystemLog, string.Empty);
                OperationHistoryAcs.Instance.RefreshLogSet(condition);
                this.errorLogDB.Merge(OperationHistoryAcs.Instance.LogSet.Copy());

                condition.LogKind = null;
                RefreshErrorLogGrid(this.errorLogDB, condition);
            }
        }

        /// <summary>
        /// 対応するタブがアクティブになった時の処理を行います。
        /// </summary>
        public void Active()
        {
            // TODO:必要に応じて
        }

        #endregion  // <ISecurityManagementForm メンバ/>

        #region <Const/>

        /// <summary>メッセージのキャプション</summary>
        private const string MESSEAGE_CAPTION = "情報－＜ログ表示＞";

        #endregion  // <Const/>

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public PMKHN09140UB()
        {
            #region <Designer Code/>

            InitializeComponent();

            #endregion  // <Designer Code/>

            // 拠点
            _sectionCheckedList = new SectionItemController(this.sectionCheckedListBox);

            // カテゴリ、機能
            _operationItemComboBox = new OperationItemController(
                this.categoryTComboEditor,
                this.pgIdTComboEditor,
                null
            );

            // 従業員ガイドのフォーカス制御
            _employeeGuideController = new GeneralGuideUIController(
                this.tEdit_EmployeeCode,
                this.employeeGuideButton,
                this.categoryTComboEditor
            );
        }

        #endregion  // <Constructor/>

        #region <フォーム/>

        /// <summary>
        /// フォームのLoadイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void PMKHN09140UB_Load(object sender, EventArgs e)
        {
            // 日時
            UIUtil.InitializeDateTimeUI(this.fromTDateEdit, this.toTDateEdit);
            InitializeFromTo();

            // 従業員
            this.employeeGuideButton.ImageList = IconResourceManagement.ImageList16;
            this.employeeGuideButton.Appearance.Image = (int)Size16_Index.STAR1;
            // 従業員ガイドのフォーカス制御の開始
            EmployeeGuideController.StartControl();

            // ログ種別
            InitializeLogDataKing();

            // エラーログ
            InitializeErrorLogGrid();

            // 文字サイズ
            UIUtil.InitializeFontSizeUI(this.fontSizeTComboEditor);

            // --- ADD m.suzuki 2010/02/22 ---------->>>>>
            this.autoFillToGridColumnCheckEditor.Checked = true;
            UIUtil.DoAutoFillToGridColumn( this.autoFillToGridColumnCheckEditor, this.errorLogGrid );
            // --- ADD m.suzuki 2010/02/22 ----------<<<<<

            #region <実験用/>

            this.searchLogButton.Visible = false;
            this.writeLogButton.Visible = false;
            ShowTestButton();

            #endregion  // <実験用/>
        }

        #endregion  // <フォーム/>

        #region <拠点/>

        /// <summary>拠点チェックリスト</summary>
        private readonly SectionItemController _sectionCheckedList;
        /// <summary>
        /// 拠点チェックリストを取得します。
        /// </summary>
        /// <value>拠点チェックリスト</value>
        private SectionItemController SectionCheckedList
        {
            get { return _sectionCheckedList; }
        }

        #endregion  // <拠点/>

        #region <日時/>

        /// <summary>
        /// 開始日時と終了日時を初期化します。
        /// </summary>
        private void InitializeFromTo()
        {
            DateTime now = DateTime.Now;
            DateTime from = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
            DateTime to = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);

            this.fromTime.Value = from;
            this.toTime.Value = to;
        }

        /// <summary>
        /// 開始日時のKeyDownイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void fromTime_KeyDown(object sender, KeyEventArgs e)
        {
            UIUtil.OnArrowKeyDown(e, UIUtil.GetDateItem(this.fromTDateEdit, UIUtil.TDateEditItemIndex.Day), this.toTDateEdit);
        }

        /// <summary>
        /// 終了日時のKeyDownイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void toTime_KeyDown(object sender, KeyEventArgs e)
        {
            UIUtil.OnArrowKeyDown(e, UIUtil.GetDateItem(this.toTDateEdit, UIUtil.TDateEditItemIndex.Day), this.machineNameTEdit);
        }

        #endregion  // <日時/>

        #region <カテゴリ、機能/>

        /// <summary>カテゴリ、機能コンボボックス</summary>
        private readonly OperationItemController _operationItemComboBox;
        /// <summary>
        /// カテゴリ、機能コンボボックスを取得します。
        /// </summary>
        /// <value>カテゴリ、機能コンボボックス</value>
        internal OperationItemController OperationItemComboBox
        {
            get { return _operationItemComboBox; }
        }

        #endregion  // <カテゴリ、機能/>

        #region <従業員/>

        /// <summary>従業員ガイドの制御オブジェクト</summary>
        private readonly GeneralGuideUIController _employeeGuideController;
        /// <summary>
        /// 従業員ガイドの制御オブジェクトを取得します。
        /// </summary>
        /// <value>従業員ガイドの制御オブジェクト</value>
        private GeneralGuideUIController EmployeeGuideController
        {
            get { return _employeeGuideController; }
        }

        /// <summary>
        /// 従業員ガイドボタンのClickイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void employeeGuideButton_Click(object sender, EventArgs e)
        {
            UIUtil.InputEmployeeCodeAndName(this.tEdit_EmployeeCode, this.employeeNameTEdit);
        }

        #endregion  // <従業員/>

        #region <ログ種別/>

        /// <summary>
        /// ログ種別を初期化します。
        /// </summary>
        private void InitializeLogDataKing()
        {
            this.logDataKingTComboEditor.Items.Add(new LogKindItemType(LogCondition.ALL_KIND_CODE, LogCondition.ALL_KIND_NAME));
            this.logDataKingTComboEditor.Items.Add(new LogKindItemType((int)LogDataKind.ErrorLog, "エラー"));     // LITERAL:
            this.logDataKingTComboEditor.Items.Add(new LogKindItemType((int)LogDataKind.SystemLog, "システム"));  // LITERAL:
            this.logDataKingTComboEditor.SelectedIndex = 0;
        }

        #endregion  // <ログ種別/>

        #region <エラーログ/>

        /// <summary>
        /// エラーログのデータグリッドビューを初期化します。
        /// </summary>
        private void InitializeErrorLogGrid()
        {
            // エラーログ
            OperationHistoryAcs.Instance.RefreshLogSet(
                new LogCondition(LogDataKind.ErrorLog)
            );
            this.errorLogDB = (LogDataSet)OperationHistoryAcs.Instance.LogSet.Copy();

            // システムログ
            OperationHistoryAcs.Instance.RefreshLogSet(
                new LogCondition(LogDataKind.SystemLog)
            );
            this.errorLogDB.Merge(OperationHistoryAcs.Instance.LogSet.Copy());

            RefreshErrorLogGrid(this.errorLogDB, null);

            // 列幅自動調整
            this.errorLogGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

            // 表示するカラムを設定
            IList<Pair<int, string>> columnIndexAndCaptionThatHiddenIsFalseList = new List<Pair<int, string>>();
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)LogDataSet.ClmIdx.Date,
                string.Empty
            ));
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)LogDataSet.ClmIdx.Time,
                string.Empty
            ));
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)LogDataSet.ClmIdx.LogKind,
                string.Empty
            ));
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)LogDataSet.ClmIdx.SectionName,
                string.Empty
            ));
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)LogDataSet.ClmIdx.MachineName,
                string.Empty
            ));
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)LogDataSet.ClmIdx.EmployeeName,
                string.Empty
            ));
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)LogDataSet.ClmIdx.CategoryName,
                string.Empty
            ));
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)LogDataSet.ClmIdx.PgName,
                string.Empty
            ));
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)LogDataSet.ClmIdx.Message,
                string.Empty
            ));

            FormControlUtil.SetDataGridColumnHidden(this.errorLogGrid, columnIndexAndCaptionThatHiddenIsFalseList);

            // セル選択時は行選択に
            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.errorLogGrid.DisplayLayout.Bands[0];
            for (int i = 0; i < band.Columns.Count; i++)
            {
                band.Columns[i].CellClickAction = CellClickAction.RowSelect;
            }

            // 列サイズの自動調整
            UIUtil.DoAutoFillToGridColumn(this.autoFillToGridColumnCheckEditor, this.errorLogGrid);
        }

        /// <summary>
        /// エラーログのデータグリッドビューの表示を更新します。
        /// </summary>
        /// <param name="errLogDB">エラーロググリッド</param>
        /// <param name="condition">検索条件</param>
        private void RefreshErrorLogGrid(
            LogDataSet errLogDB,
            LogCondition condition
        )
        {
            DataView dataView = errLogDB.Log.DefaultView;
            if (condition != null) dataView.RowFilter = condition.GetWhere();

            StringBuilder sort = new StringBuilder();
            sort.Append(LogDataSet.ClmIdx.Date).Append(ADOUtil.DESC);
            sort.Append(ADOUtil.COMMA);
            sort.Append(LogDataSet.ClmIdx.Time).Append(ADOUtil.DESC);
            sort.Append(ADOUtil.COMMA);
            sort.Append(LogDataSet.ClmIdx.SectionCode);
            sort.Append(ADOUtil.COMMA);
            sort.Append(LogDataSet.ClmIdx.MachineName);

            dataView.Sort = sort.ToString();

            this.errorLogGrid.DataSource = dataView;

            if (condition == null) return;

            if (dataView.Count.Equals(0))
            {
                MessageBox.Show(
                    "該当データが存在しません。",   // LITERAL:
                    MESSEAGE_CAPTION,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        #endregion  // <エラーログ/>

        #region <検索条件の構築/>

        /// <summary>
        /// 検索条件を取得します。
        /// </summary>
        /// <returns>検索条件</returns>
        private LogCondition GetCondition()
        {
            LogCondition condition = new LogCondition(LogDataKind.OperationLog);

            // 拠点
            List<SectionItemType> sectionList = SectionCheckedList.CreateCheckedItemList();
            foreach (SectionItemType section in sectionList)
            {
                if (section.Code.Equals(LogCondition.ALL_SECTION_CODE)) break;

                condition.AddSection(section);
            }

            // 日時
            string fromD = this.fromTDateEdit.GetDateTime().ToString(DateTimeUtil.DEFAULT_DATE_TIME_FORMAT);
            string fromT = DateTimeUtil.DEFAULT_FROM_TIME;
            condition.From = DateTime.Parse(fromD + " " + fromT);

            string toD = this.toTDateEdit.GetDateTime().ToString(DateTimeUtil.DEFAULT_DATE_TIME_FORMAT);
            string toT = DateTimeUtil.DEFAULT_TO_TIME;
            condition.To = DateTime.Parse(toD + " " + toT);

            // 端末名
            condition.MachineName = this.machineNameTEdit.Text.Trim();

            // 従業員
            condition.EmployeeCode = this.tEdit_EmployeeCode.Text.Trim();

            // カテゴリ
            condition.Category = (CategoryItemType)this.categoryTComboEditor.SelectedItem;

            // 機能
            condition.Pg = (PgItemType)this.pgIdTComboEditor.SelectedItem;

            // ログ種別
            condition.LogKind = (LogKindItemType)this.logDataKingTComboEditor.SelectedItem;

            return condition;
        }

        #endregion  // <検索条件の構築/>

        #region <列サイズの自動調整/>

        /// <summary>
        /// 列サイズの自動調整チェックボックスのCheckedChangedイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void autoFillToGridColumnCheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            UIUtil.DoAutoFillToGridColumn(this.autoFillToGridColumnCheckEditor, this.errorLogGrid);
        }

        #endregion  // <列サイズの自動調整/>

        #region <文字サイズ/>

        /// <summary>
        /// 文字サイズのValueChangedイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void fontSizeTComboEditor_ValueChanged(object sender, EventArgs e)
        {
            UIUtil.ChangeFontSize(this.fontSizeTComboEditor, this.errorLogGrid);
        }

        #endregion  // <文字サイズ/>

        /// <summary>
        /// コントロールのChangeFocusイベントハンドラ
        /// </summary>
        /// <remarks>
        /// 対象コントロール：arrowKeyControl, retKeyControl, uiSetControl
        /// </remarks>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void Control_ChangeFocus(
            object sender,
            Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e
        )
        {
            if (e.PrevCtrl == this.tEdit_EmployeeCode)
            {
                this.employeeNameTEdit.Text = UIUtil.GetEmployeeName(this.tEdit_EmployeeCode.Text.Trim());
            }

            UIUtil.UIColor.OnFocusChanged(e);
        }

        #region <実験/>

        /// <summary>
        /// 実験ボタンを表示します。
        /// </summary>
        [Conditional("_UT_")]
        private void ShowTestButton()
        {
            this.searchLogButton.Visible= true;
            this.writeLogButton.Visible = true;
        }

        /// <summary>
        /// 探す実験
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void searchLogButton_Click(object sender, EventArgs e)
        {
            OperationHistoryAcs.Instance.OperationHistoryLogDB.TestSearch();
        }

        /// <summary>
        /// 書く実験
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void writeLogButton_Click(object sender, EventArgs e)
        {
            OperationHistoryLog log = new OperationHistoryLog();
            log.WriteOperationLog(
                this,
                LogDataKind.ErrorLog,
                "MAHNB01010U",
                "売上伝票入力",
                "writeLogButton_Click",
                10,
                0,
                "操作ログ書き込みテスト",
                "実験データ"
            );
        }

        #endregion  // <実験/>
    }
}
