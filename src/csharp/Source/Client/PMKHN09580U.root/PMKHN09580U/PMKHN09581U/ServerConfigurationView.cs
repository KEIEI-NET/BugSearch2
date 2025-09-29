//****************************************************************************//
// システム         : プリンタ設定マスタ（サーバ用）
// プログラム名称   : プリンタ設定マスタ（サーバ用）ビュー
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/09/16  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// サーバ構成設定ビューコントロール
    /// </summary>
    public partial class ServerConfigurationView : UserControl
    {
        #region <Controller>

        /// <summary>サーバ構成設定コントローラ</summary>
        private IServerConfigurationController _controller;
        /// <summary>サーバ構成設定コントローラを取得します。</summary>
        private IServerConfigurationController Controller
        {
            get
            {
                if (_controller == null)
                {
                    _controller = CreateController();
                    _controller.UpdatingView += new UpdateViewEventHandler(OnUpdateView);
                }
                return _controller;
            }
        }

        /// <summary>
        /// サーバ構成設定コントローラを生成します。
        /// </summary>
        /// <remarks>
        /// サブクラス側でオーバーライドが必須です。
        /// </remarks>
        /// <returns>各機能用のサーバ構成設定コントローラ ※要オーバーライド</returns>
        protected virtual IServerConfigurationController CreateController()
        {
            return null;    // TODO:要オーバーライド
        }

        #endregion // </Controller>

        #region <キャプション>

        /// <summary>キャプション</summary>
        private string _caption;
        /// <summary>キャプションを取得または設定します。</summary>
        public string Caption
        {
            get { return _caption; }
            set { _caption = value; }
        }

        #endregion // </キャプション>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public ServerConfigurationView()
        {
            #region <Designer Code>

            InitializeComponent();

            #endregion // </Designer Code>
        }

        #endregion // </Constructor>

        #region <初期化>

        /// <summary>
        /// サーバ構成設定ビューコントロールのLoadイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void ServerConfiguratorView_Load(object sender, EventArgs e)
        {
            InitializeMemberControls(); // メンバコントロールを初期化
            InitializeEventHandler();   // イベントハンドラを初期化
        }

        /// <summary>
        /// メンバコントロールを初期化します。
        /// </summary>
        private void InitializeMemberControls()
        {
            ShowImportControl();// デバッグ用
            InitializeGrid();   // グリッドを初期化
        }

        /// <summary>
        /// イベントハンドラを初期化します。
        /// </summary>
        private void InitializeEventHandler()
        {
            InitializeNewEventHandler();    // 新規登録イベントハンドラを初期化
            InitializeDeleteEventHandler(); // 削除イベントハンドラを初期化
            InitializeEditEventHandler();   // 修正イベントハンドラを初期化
            InitializeImportEventHandler(); // インポートイベントハンドラを初期化
        }

        #endregion // </初期化>

        #region <グリッド>

        /// <summary>
        /// グリッドのカラムインデックス列挙型
        /// </summary>
        protected enum GridColumnIndex : int
        {
            /// <summary>削除日</summary>
            DeletedDate = 0
        }

        /// <summary>
        /// DB表示用グリッドを取得します。
        /// </summary>
        protected DataGridView GridDB
        {
            get { return this.gridDB; }
        }

        /// <summary>
        /// グリッドを初期化します。
        /// </summary>
        private void InitializeGrid()
        {
            RefleshGrid();
        }

        /// <summary>
        /// グリッドの表示を更新します。
        /// </summary>
        protected void RefleshGrid()
        {
            // データソースを設定
            GridDB.DataSource = GetBindingData();

            // グリッドのカラム属性を設定
            SetGridColumnsProperty();

            // 削除済みデータをフィルタ
            FilterDeletedData(VisiblesDeletedData);

            // 列サイズの自動調整
            SetGridAutoSizeColumnsMode();
        }

        /// <summary>
        /// グリッドにバインドするデータを取得します。
        /// </summary>
        /// <returns>
        /// <c>Controller.DefaultView</c>
        /// </returns>
        private object GetBindingData()
        {
            return Controller.DefaultView;
        }

        /// <summary>
        /// 削除済みデータをフィルタします。
        /// </summary>
        /// <param name="showingAllData">全データを表示するフラグ</param>
        private void FilterDeletedData(bool showingAllData)
        {
            Controller.DefaultView.RowFilter = showingAllData ? string.Empty : GetAvailableRecordQuery();

            // 表示色を変更
            if (string.IsNullOrEmpty(Controller.DefaultView.RowFilter))
            {
                foreach (DataGridViewRow row in GridDB.Rows)
                {
                    row.Cells[(int)GridColumnIndex.DeletedDate].Style.ForeColor = Color.Red;
                }
            }
        }

        /// <summary>
        /// 有効なレコードの条件式を取得します。
        /// </summary>
        /// <returns>"LogicalDeleteCode = 0"</returns>
        protected virtual string GetAvailableRecordQuery()
        {
            return "LogicalDeleteCode = 0";
        }

        /// <summary>
        /// グリッドのカラム属性を設定します。
        /// </summary>
        /// <remarks>
        /// ヘッダの名称をデータテーブルのキャプションで設定します。
        /// </remarks>
        private void SetGridColumnsProperty()
        {
            List<string> hideColumnNameList = CreateHideColumnNameList();

            foreach (DataGridViewColumn column in GridDB.Columns)
            {
                DataColumn dataColumn = ((DataView)GridDB.DataSource).Table.Columns[column.Index];
                {
                    column.HeaderText = dataColumn.Caption;

                    column.Visible = !hideColumnNameList.Exists(
                        delegate(string item)
                        {
                            return dataColumn.ColumnName.Equals(item);
                        }
                    );
                }
                // 削除日は先頭に表示
                if (IsDeletedDateColumn(dataColumn.ColumnName))
                {
                    column.DisplayIndex = (int)GridColumnIndex.DeletedDate;
                }
            }
        }

        /// <summary>
        /// 隠すカラム名のリストを生成します。
        /// </summary>
        /// <returns>隠すカラム名のリスト</returns>
        protected virtual List<string> CreateHideColumnNameList()
        {
            return new List<string>();
        }

        /// <summary>デフォルト削除日カラム名</summary>
        protected const string DEFAULT_DELETEAD_DATE_COLUMN_NAME = "DeletedDate";

        /// <summary>
        /// 削除日カラムであるか判断します。
        /// </summary>
        /// <param name="columnName">カラム名</param>
        /// <returns>
        /// <c>true</c> :削除日カラムです。<br/>
        /// <c>false</c>:削除日カラムではありません。
        /// </returns>
        protected virtual bool IsDeletedDateColumn(string columnName)
        {
            return columnName.Equals(DEFAULT_DELETEAD_DATE_COLUMN_NAME);
        }

        /// <summary>
        /// DB表示用グリッドのMouseDoubleClickイベントハンドラ
        /// </summary>
        /// <remarks>
        /// 修正処理を行います。他の処理を行う場合、サブクラス側でオーバーライドすること。
        /// </remarks>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        protected virtual void ActOnGridCellMouseDoubleClick(
            object sender,
            DataGridViewCellMouseEventArgs e
        )
        {
            OnEdit(sender, new EditEventArgs(e));
        }

        /// <summary>
        /// DB表示用グリッドのMouseDoubleClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void gridDB_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ActOnGridCellMouseDoubleClick(sender, e);
        }

        /// <summary>nullを表すインデックス</summary>
        private const int NULL_INDEX = -1;

        /// <summary>デフォルトカラムのインデックス</summary>
        private int _defaultColumnIndex = NULL_INDEX;
        /// <summary>デフォルトカラムのインデックスを取得または設定します。</summary>
        private int DefaultColumnIndex
        {
            get { return _defaultColumnIndex; }
            set { _defaultColumnIndex = value; }
        }

        /// <summary>
        /// DB表示用グリッドのKeyDownイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void gridDB_KeyDown(object sender, KeyEventArgs e)
        {
            // [Enter]キー押下時は修正
            if (e.KeyCode.Equals(Keys.Enter))
            {
                e.Handled = true;
                OnEdit(sender, new EditEventArgs(e));
                return;
            }

            // [Tab]キー押下時は選択行を移動
            if (e.KeyCode.Equals(Keys.Tab))
            {
                if (DefaultColumnIndex.Equals(NULL_INDEX))
                {
                    DefaultColumnIndex = GridDB.CurrentCell.ColumnIndex;
                }

                if (!e.Shift)
                {
                    if (GridDB.CurrentRow.Index + 1 < GridDB.Rows.Count)
                    {
                        GridDB.CurrentCell = GridDB[DefaultColumnIndex, GridDB.CurrentCell.RowIndex + 1];
                        GridDB.CurrentCell.Selected = true;
                    }
                    else
                    {
                        this.chkAdjustAutomatically.Focus();    // TODO:次の移動先コントロールを取得する方式があるはず
                    }
                }
                else
                {
                    if (GridDB.CurrentRow.Index - 1 >= 0)
                    {
                        GridDB.CurrentCell = GridDB[DefaultColumnIndex, GridDB.CurrentCell.RowIndex];
                        GridDB.CurrentCell.Selected = true;
                    }
                    else
                    {
                        this.btnEdit.Focus();   // TODO:前の移動先コントロールを取得する方式があるはず
                    }
                }

                return;
            }   // if (e.KeyCode.Equals(Keys.Tab))
        }

        #endregion // </グリッド>

        #region <新規操作>

        /// <summary>新規登録イベント</summary>
        public event NewEventHandler Newing;

        /// <summary>
        /// 新規登録イベントハンドラを初期化します。
        /// </summary>
        private void InitializeNewEventHandler()
        {
            Newing += new NewEventHandler(OnNew);
        }

        /// <summary>
        /// 新規登録します。
        /// </summary>
        /// <remarks>
        /// 新規登録機能がある場合、サブクラス側でオーバーライドすること。
        /// </remarks>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        protected virtual void OnNew(
            object sender,
            NewEventArgs e
        )
        {
            Debug.WriteLine("デフォルト新規登録処理");
        }

        /// <summary>
        /// [新規]ボタンのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">ベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            Newing(sender, new NewEventArgs(e));
        }

        #endregion // </新規操作>

        #region <削除操作>

        /// <summary>削除イベント</summary>
        public event DeleteEventHandler Deleting;

        /// <summary>
        /// 削除イベントハンドラを初期化します。
        /// </summary>
        private void InitializeDeleteEventHandler()
        {
            Deleting += new DeleteEventHandler(OnDelete);
        }

        /// <summary>
        /// 削除します。
        /// </summary>
        /// <remarks>
        /// 削除機能がある場合、サブクラス側でオーバーライドすること。
        /// </remarks>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        protected virtual void OnDelete(
            object sender,
            DeleteEventArgs e
        )
        {
            Debug.WriteLine("デフォルト削除処理");
        }

        /// <summary>
        /// [削除]ボタンのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">ベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Deleting(sender, new DeleteEventArgs(e));
        }

        #endregion // </削除操作>

        #region <修正操作>

        /// <summary>修正イベント</summary>
        public event EditEventHandler Editing;

        /// <summary>
        /// 修正イベントハンドラを初期化します。
        /// </summary>
        private void InitializeEditEventHandler()
        {
            Editing += new EditEventHandler(OnEdit);
        }

        /// <summary>
        /// 修正します。
        /// </summary>
        /// <remarks>
        /// 修正機能がある場合、サブクラス側でオーバーライドすること。
        /// </remarks>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        protected virtual void OnEdit(
            object sender,
            EditEventArgs e
        )
        {
            Debug.WriteLine("デフォルト修正処理");
        }

        /// <summary>
        /// [修正]ボタンのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">ベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Editing(sender, new EditEventArgs(e));
        }

        #endregion // </修正操作>

        #region <インポート操作>

        /// <summary>インポートイベント</summary>
        public event ImportEventHandler Importing;

        /// <summary>
        /// [インポート]ボタンを表示します。
        /// </summary>
        [Conditional("DEBUG")]
        private void ShowImportControl()
        {
            this.btnImport.Visible = true;
        }

        /// <summary>
        /// インポートイベントハンドラを初期化します。
        /// </summary>
        private void InitializeImportEventHandler()
        {
            Importing += new ImportEventHandler(OnImport);
        }

        /// <summary>
        /// インポートします。
        /// </summary>
        /// <remarks>
        /// インポート機能がある場合、サブクラス側でオーバーライドすること。
        /// </remarks>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        protected virtual void OnImport(
            object sender,
            ImportEventArgs e
        )
        {
            Controller.Import();
            RefleshGrid();
        }

        /// <summary>
        /// [インポート]ボタンのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">ベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            Importing(sender, new ImportEventArgs(e));
        }

        #endregion // <インポート操作>

        #region <削除済みデータの表示>

        /// <summary>
        /// 削除済みデータを表示するか判断します。
        /// </summary>
        /// <value>
        /// <c>true</c> :削除済みデータを表示します。<br/>
        /// <c>false</c>:削除済みデータを表示しません。
        /// </value>
        protected bool VisiblesDeletedData
        {
            get { return this.chkShowDeletedData.Checked; }
        }

        /// <summary>
        /// [削除済みデータを表示する]チェックボックスのCheckedChangeedイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントハンドラ</param>
        private void chkShowDeletedData_CheckedChanged(object sender, EventArgs e)
        {
            RefleshGrid();
        }

        #endregion // </削除済みデータの表示>

        #region <列サイズの自動調整>

        /// <summary>
        /// 列サイズの自動調整を行います。
        /// </summary>
        private void SetGridAutoSizeColumnsMode()
        {
            // 列サイズの自動調整
            if (this.chkAdjustAutomatically.Checked)
            {
                GridDB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                GridDB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            }
        }

        /// <summary>
        /// [列サイズの自動調整]チェックボックスのCheckedChangeedイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントハンドラ</param>
        private void chkAdjustAutomatically_CheckedChanged(object sender, EventArgs e)
        {
            SetGridAutoSizeColumnsMode();
        }

        #endregion // </列サイズの自動調整>

        #region <表示更新>

        /// <summary>
        /// 表示を更新するイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        protected virtual void OnUpdateView(
            object sender,
            UpdateViewEventArgs e
        )
        {
            RefleshGrid();
        }

        #endregion // </表示更新>
    }

    #region <新規登録イベント定義>

    /// <summary>
    /// 新規登録イベントハンドラ
    /// </summary>
    /// <param name="sender">イベントソース</param>
    /// <param name="e">イベントパラメータ</param>
    public delegate void NewEventHandler(
        object sender,
        NewEventArgs e
    );

    /// <summary>
    /// 新規登録イベントパラメータクラス
    /// </summary>
    public sealed class NewEventArgs : EventArgs
    {
        #region <元となったイベントのパラメータ>

        /// <summary>元となったイベントのパラメータ</summary>
        private readonly EventArgs _innerEventArgs;
        /// <summary>元となったイベントのパラメータを取得します。</summary>
        public EventArgs InnerEventArgs { get { return _innerEventArgs; } }

        #endregion // </元となったイベントのパラメータ>

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="innerEventArgs">元となったイベントのパラメータ</param>
        public NewEventArgs(EventArgs innerEventArgs)
            : base()
        {
            _innerEventArgs = innerEventArgs;
        }

        #endregion // </Constructor>
    }

    #endregion // </新規登録イベント定義>

    #region <削除イベント定義>

    /// <summary>
    /// 削除イベントハンドラ
    /// </summary>
    /// <param name="sender">イベントソース</param>
    /// <param name="e">イベントパラメータ</param>
    public delegate void DeleteEventHandler(
        object sender,
        DeleteEventArgs e
    );

    /// <summary>
    /// 削除イベントパラメータクラス
    /// </summary>
    public sealed class DeleteEventArgs : EventArgs
    {
        #region <元となったイベントのパラメータ>

        /// <summary>元となったイベントのパラメータ</summary>
        private readonly EventArgs _innerEventArgs;
        /// <summary>元となったイベントのパラメータを取得します。</summary>
        public EventArgs InnerEventArgs { get { return _innerEventArgs; } }

        #endregion // </元となったイベントのパラメータ>

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="innerEventArgs">元となったイベントのパラメータ</param>
        public DeleteEventArgs(EventArgs innerEventArgs) : base()
        {
            _innerEventArgs = innerEventArgs;
        }

        #endregion // </Constructor>
    }

    #endregion // </削除イベント定義>

    #region <修正イベント定義>

    /// <summary>
    /// 修正イベントハンドラ
    /// </summary>
    /// <param name="sender">イベントソース</param>
    /// <param name="e">イベントパラメータ</param>
    public delegate void EditEventHandler(
        object sender,
        EditEventArgs e
    );

    /// <summary>
    /// 修正イベントパラメータクラス
    /// </summary>
    public sealed class EditEventArgs : EventArgs
    {
        #region <元となったイベントのパラメータ>

        /// <summary>元となったイベントのパラメータ</summary>
        private readonly EventArgs _innerEventArgs;
        /// <summary>元となったイベントのパラメータを取得します。</summary>
        public EventArgs InnerEventArgs { get { return _innerEventArgs; } }

        #endregion // </元となったイベントのパラメータ>

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="innerEventArgs">元となったイベントのパラメータ</param>
        public EditEventArgs(EventArgs innerEventArgs) : base()
        {
            _innerEventArgs = innerEventArgs;
        }

        #endregion // </Constructor>
    }

    #endregion // </修正イベント定義>

    #region <インポートイベント定義>

    /// <summary>
    /// インポートイベントハンドラ
    /// </summary>
    /// <param name="sender">イベントソース</param>
    /// <param name="e">イベントパラメータ</param>
    public delegate void ImportEventHandler(
        object sender,
        ImportEventArgs e
    );

    /// <summary>
    /// インポートイベントパラメータクラス
    /// </summary>
    public sealed class ImportEventArgs : EventArgs
    {
        #region <元となったイベントのパラメータ>

        /// <summary>元となったイベントのパラメータ</summary>
        private readonly EventArgs _innerEventArgs;
        /// <summary>元となったイベントのパラメータを取得します。</summary>
        public EventArgs InnerEventArgs { get { return _innerEventArgs; } }

        #endregion // </元となったイベントのパラメータ>

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="innerEventArgs">元となったイベントのパラメータ</param>
        public ImportEventArgs(EventArgs innerEventArgs)
            : base()
        {
            _innerEventArgs = innerEventArgs;
        }

        #endregion // </Constructor>
    }

    #endregion // </インポートイベント定義>
}
