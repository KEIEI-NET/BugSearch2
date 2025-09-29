using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 簡易マスメンマルチフォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 簡易マスメンの一覧編集タイプフォームクラスです。</br>
	/// <br>Programmer : 23001 秋山　亮介</br>
	/// <br>Date       : 2007.03.26</br>
	/// </remarks>
	public partial class SimpleMasterMaintenanceMulti : Form
	{
		#region << Constructor >>

		/// <summary>
		/// 簡易マスメンマルチフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 簡易マスメンマルチフォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public SimpleMasterMaintenanceMulti( Form editForm ) : this()
		{
			this._editForm                      = editForm;
			this._iSimpleMasterMaintenanceMulti = this._editForm as ISimpleMasterMaintenanceMulti;

			if( ( this._editForm == null ) || 
				( this._iSimpleMasterMaintenanceMulti == null ) ) {
				throw( new Exception( "編集フォームの読み込みに失敗しました。" ) );
			}

			// イベント設定
			this._editForm.VisibleChanged += new EventHandler( this.EditForm_VisibleChanged );
		}

		/// <summary>
		/// 簡易マスメンマルチフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 簡易マスメンマルチフォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public SimpleMasterMaintenanceMulti( Assembly assembly, string className, Type type ) : this()
		{
			this._editForm                      = this.LoadAssembly( assembly, className, type ) as Form;
			this._iSimpleMasterMaintenanceMulti = this._editForm as ISimpleMasterMaintenanceMulti;

			if( ( this._editForm == null ) || 
				( this._iSimpleMasterMaintenanceMulti == null ) ) {
				throw( new Exception( "編集フォームの読み込みに失敗しました。" ) );
			}

			// イベント設定
			this._editForm.VisibleChanged += new EventHandler( this.EditForm_VisibleChanged );
		}

		/// <summary>
		/// 簡易マスメンマルチフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 簡易マスメンマルチフォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public SimpleMasterMaintenanceMulti( string assemblyName, string className, Type type ) : this()
		{
			this._editForm                      = this.LoadAssembly( assemblyName, className, type ) as Form;
			this._iSimpleMasterMaintenanceMulti = this._editForm as ISimpleMasterMaintenanceMulti;

			if( ( this._editForm == null ) || 
				( this._iSimpleMasterMaintenanceMulti == null ) ) {
				throw( new Exception( "編集フォームの読み込みに失敗しました。" ) );
			}

			// イベント設定
			this._editForm.VisibleChanged += new EventHandler( this.EditForm_VisibleChanged );
		}

		/// <summary>
		/// 簡易マスメンマルチフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 簡易マスメンマルチフォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private SimpleMasterMaintenanceMulti()
		{
			InitializeComponent();
		}

		#endregion

		#region << Private Members >>

		/// <summary>編集フォーム</summary>
		private Form                                 _editForm                      = null;
		/// <summary>簡易マスメンマルチフォーム編集インターフェース</summary>
		private ISimpleMasterMaintenanceMulti        _iSimpleMasterMaintenanceMulti = null;

		/// <summary>一覧表示用DataSet</summary>
		private DataSet                              _dataSet                       = null;
		/// <summary>一覧表示用DataMember</summary>
		private string                               _dataMember                    = null;
		/// <summary>グリッド列外観設定</summary>
		private Dictionary<string,GridColAppearance> _gridColAppearanceDictionary   = null;

		/// <summary>オプションツール</summary>
		private SortedList<string,ToolStripItem>     _optionTools                   = null;

		#endregion

		#region << Private Methods >>

		#region ■アセンブリロード処理

		/// <summary>
		/// アセンブリロード処理
		/// </summary>
		/// <param name="asmName">アセンブリ名</param>
		/// <param name="className">クラス名</param>
		/// <param name="type">クラスの型</param>
		/// <returns>オブジェクトインスタンス</returns>
		private object LoadAssembly( string asmName, string className, Type type )
		{
			string asmPath = Path.Combine( Path.GetDirectoryName( Application.ExecutablePath ), asmName );
			Assembly assembly = System.Reflection.Assembly.LoadFrom( asmPath );
			return this.LoadAssembly( assembly, className, type );
		}

		/// <summary>
		/// アセンブリロード処理
		/// </summary>
		/// <param name="assembly">アセンブリクラス</param>
		/// <param name="className">クラス名</param>
		/// <param name="type">クラスの型</param>
		/// <returns>オブジェクトインスタンス</returns>
		private object LoadAssembly( Assembly assembly, string className, Type type )
		{
			object obj = null;
			Type objType = assembly.GetType( className );
			if( objType != null ) {
				if( ( objType == type ) || ( objType.IsSubclassOf( type ) == true ) || ( objType.GetInterface( type.Name ).Name == type.Name ) ) {
					obj = Activator.CreateInstance( objType );
				}
			}

			return obj;
		}

		#endregion

		#region ■初期設定処理

		/// <summary>
		/// 初期設定処理
		/// </summary>
		private void InitializeSetting()
		{
			// 新規・削除の有無設定
			this.NewData_toolStripMenuItem.Visible  = this._iSimpleMasterMaintenanceMulti.AllowNew;
			this.DelData_toolStripMenuItem.Visible  = this._iSimpleMasterMaintenanceMulti.AllowDelete;
			this.NewData_toolStripButton.Visible    = this._iSimpleMasterMaintenanceMulti.AllowNew;
			this.DelData_toolStripButton.Visible    = this._iSimpleMasterMaintenanceMulti.AllowDelete;

			// オプションツールを取得
			this._iSimpleMasterMaintenanceMulti.GetOptionTools( ref this._optionTools );
			if( this._optionTools != null ) {
				// オプションツールメニュー作成
				this.CreateOptionToolMenuItems( this._optionTools );
			}
			else {
				// オプションツールメニュー非表示
				this.Tool_toolStripMenuItem.Visible = false;
			}

			// DataSet を取得
			this._iSimpleMasterMaintenanceMulti.GetDataSet( ref this._dataSet, ref this._dataMember );
			// Grid にバインド
			this.SearchData_dataGridView.DataSource = this._dataSet;
			this.SearchData_dataGridView.DataMember = this._dataMember;

			// グリッド列外観設定取得
			this._gridColAppearanceDictionary = this._iSimpleMasterMaintenanceMulti.GetGridColAppearance();
			// グリッド列外観設定処理
			this.SettingGridColAppearance( this._gridColAppearanceDictionary );
		}

		#endregion

		#region ■オプションツールメニュー生成処理

		/// <summary>
		/// オプションツールメニュー生成処理
		/// </summary>
		/// <param name="optionTools">オプションツール</param>
		private void CreateOptionToolMenuItems( SortedList<string,ToolStripItem> optionTools )
		{
			this.Tool_toolStripMenuItem.DropDownItems.Clear();
			foreach( KeyValuePair<string,ToolStripItem> keyValue in optionTools )
			{
				ToolStripItem item = keyValue.Value;
				string        key  = keyValue.Key;

				item.Name  = "OptionTool_" + key;
				item.Click += new EventHandler( this.OptionTool_toolStripItem_Click );

				this.Tool_toolStripMenuItem.DropDownItems.Add( item );
			}
		}

		#endregion

		#region ■グリッド列外観設定処理

		/// <summary>
		/// グリッド列外観設定処理
		/// </summary>
		/// <param name="gridColAppearanceDictionary">グリッド列外観設定</param>
		private void SettingGridColAppearance( Dictionary<string,GridColAppearance> gridColAppearanceDictionary )
		{
            if (gridColAppearanceDictionary == null)
            {
                return;
            }

            // 昇順にインデックスを振りなおす
            List<DataGridViewColumn> dataGridViewColumnList = new List<DataGridViewColumn>();
            dataGridViewColumnList.AddRange( ( DataGridViewColumn[] ) ( new ArrayList( this.SearchData_dataGridView.Columns ) ).ToArray( typeof( DataGridViewColumn )));
            dataGridViewColumnList.Sort(new Comparison<DataGridViewColumn>(delegate(DataGridViewColumn x, DataGridViewColumn y)
            {
                GridColAppearance xApp = null;
                GridColAppearance yApp = null;

                // グリッド列外観設定があるか
                if (gridColAppearanceDictionary.ContainsKey(x.Name))
                {
                    xApp = gridColAppearanceDictionary[x.Name];
                }
                // グリッド列外観設定があるか
                if (gridColAppearanceDictionary.ContainsKey(y.Name))
                {
                    yApp = gridColAppearanceDictionary[y.Name];
                }

                if (xApp == null && yApp == null)
                {
                    return 0;
                }
                if (xApp != null && yApp == null)
                {
                    return 1;
                }
                if (xApp == null && yApp != null)
                {
                    return -1;
                }

                return xApp.DisplayIndex.CompareTo(yApp.DisplayIndex);
            }));

            int displayIndex = 0;
			// 各列ごとに設定
            foreach (DataGridViewColumn column in dataGridViewColumnList)
            {
				// グリッド列外観設定があるか
				if( ( gridColAppearanceDictionary != null ) && 
					( gridColAppearanceDictionary.ContainsKey( column.Name ) ) ) {

					// グリッド列外観設定取得
					GridColAppearance gridColAppearance = gridColAppearanceDictionary[ column.Name ];

					// 表示インデックス
                    column.DisplayIndex = displayIndex++;

					// キャプション
					if( ! String.IsNullOrEmpty( gridColAppearance.Caption ) ) {
						column.HeaderText                      = gridColAppearance.Caption;
					}

					// セルの内容の表示位置
					column.DefaultCellStyle.Alignment          = gridColAppearance.Alignment;

					// セルに適用する書式指定文字列
					column.DefaultCellStyle.Format             = gridColAppearance.Format;

					// セルの前景色
					column.DefaultCellStyle.ForeColor          = gridColAppearance.ForeColor;

					// 選択時のセルの前景色
					column.DefaultCellStyle.SelectionForeColor = gridColAppearance.SelectionForeColor;
				}
				else {
					// 列を表示しない
					column.Visible = false;
                    column.DisplayIndex = displayIndex++;
				}
			}
		}

		#endregion

		#region ■検索処理

		/// <summary>
		/// 検索処理
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 検索処理を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private int Search()
		{
			int status = -1;

			try {

				// 検索実行
				status = this._iSimpleMasterMaintenanceMulti.Search();
				if( status == 0 ) {
						this.SearchData_dataGridView.AutoResizeColumns( DataGridViewAutoSizeColumnsMode.DisplayedCells );
				}
			}
			catch( Exception ex ) {
				// TODO : エラーメッセージ表示
				MessageBox.Show( this, ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1 );
			}

			return status;
		}

		#endregion

		#region ■修正画面起動処理

		/// <summary>
		/// 修正画面起動処理
		/// </summary>
		/// <param name="isNew">新規かどうか</param>
		/// <remarks>
		/// <br>Note       : 修正画面を起動します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.27</br>
		/// </remarks>
		private void RunDtlEditor( bool isNew )
		{
			int dataIndex = 0;

			// 新規の場合
			if( isNew ) {
				dataIndex  = -1;
			}
			// 更新の場合
			else {
				if( this.SearchData_dataGridView.SelectedRows.Count == 0 ) {
					return;
				}

				dataIndex = this.SearchData_dataGridView.SelectedRows[ 0 ].Index;
			}

			this._iSimpleMasterMaintenanceMulti.DataIndex = dataIndex;


			if( this._editForm.Visible ) {
				this._editForm.Hide();
			}

			this._editForm.Show( this );

			if( this._editForm.DialogResult == DialogResult.OK ) {
			}
		}

		#endregion

		#region ■削除処理

		/// <summary>
		/// 削除処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 選択されているデータの削除を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.30</br>
		/// </remarks>
		private void Delete()
		{
			if( this.SearchData_dataGridView.SelectedRows.Count == 0 ) {
				return;
			}

			// 削除確認
			DialogResult result = MessageBox.Show( 
				this, "選択されているデータを削除します。よろしいですか？", "確認", 
				MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1 );
			if( result != DialogResult.Yes ) {
				// 削除しない
				return;
			}

			this._iSimpleMasterMaintenanceMulti.DataIndex = this.SearchData_dataGridView.SelectedRows[ 0 ].Index;

			// 削除実行
			int status = this._iSimpleMasterMaintenanceMulti.Delete();
			if( status == 0 ) {
			}
			else {
			}
		}

		#endregion

		#endregion

		#region << Public Methods >>

		#region ■画面表示処理

		/// <summary>
		/// 画面表示処理
		/// </summary>
		/// <param name="owner">このフォームを所有するトップレベルウィンドウ</param>
		/// <remarks>
		/// <br>Note       : 画面の表示を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public new void Show( IWin32Window owner )
		{
			if( this.Visible ) {
				this.Activate();
			}
			else {
				base.Show( owner );
			}
		}

		/// <summary>
		/// 画面表示処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の表示を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public new void Show()
		{
			if( this.Visible ) {
				this.Activate();
			}
			else {
				base.Show();
			}
		}

		#endregion

		#endregion

		#region << Control Events >>

		#region ■Load イベント (SimpleMasterMaintenanceMulti)

		/// <summary>
		/// Load イベント (SimpleMasterMaintenanceMulti)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : フォームが初めて表示されるときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void SimpleMasterMaintenanceMulti_Load( object sender, EventArgs e )
		{
			// 初期設定処理
			this.InitializeSetting();
			// 検索実行
			this.Search();
		}

		#endregion

		#region ■Click イベント (Exit_toolStripMenuItem)

		/// <summary>
		/// Click イベント (Exit_toolStripMenuItem)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void Exit_toolStripMenuItem_Click( object sender, EventArgs e )
		{
			// 終了
			this.Close();
		}

		#endregion

		#region ■Click イベント (NewData_toolStripMenuItem)

		/// <summary>
		/// Click イベント (NewData_toolStripMenuItem)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void NewData_toolStripMenuItem_Click( object sender, EventArgs e )
		{
			// 編集画面起動
			this.RunDtlEditor( true );
		}

		#endregion

		#region ■Click イベント (FixData_toolStripMenuItem)

		/// <summary>
		/// Click イベント (FixData_toolStripMenuItem)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void FixData_toolStripMenuItem_Click( object sender, EventArgs e )
		{
			// 編集画面起動
			this.RunDtlEditor( false );
		}

		#endregion

		#region ■Click イベント (DelData_toolStripMenuItem)

		/// <summary>
		/// Click イベント (DelData_toolStripMenuItem)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void DelData_toolStripMenuItem_Click( object sender, EventArgs e )
		{
			// 削除処理
			this.Delete();
		}

		#endregion

		#region ■MouseDoubleClick イベント (PgMulcasGd_dataGridView)

		/// <summary>
		/// MouseDoubleClick イベント (PgMulcasGd_dataGridView)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : マウスがダブルクリックされたときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void PgMulcasGd_dataGridView_MouseDoubleClick( object sender, MouseEventArgs e )
		{
			// マウスカーソルがある場所の情報を取得
			DataGridView.HitTestInfo hitTestInfo = this.SearchData_dataGridView.HitTest( e.X, e.Y );
			// セル上か、行ヘッダの場合のみ実行
			if( ( hitTestInfo.Type == DataGridViewHitTestType.Cell ) || 
				( hitTestInfo.Type == DataGridViewHitTestType.RowHeader ) ) {
				// 編集画面起動
				this.RunDtlEditor( false );
			}
		}

		#endregion

		#region ■VisibleChanged イベント (EditForm_VisibleChanged)

		/// <summary>
		/// VisibleChanged イベント (EditForm_VisibleChanged)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : Visible プロパティの値が変更された場合に発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void EditForm_VisibleChanged( object sender, EventArgs e )
		{
			if( this._editForm.Visible == true ) {
				// メニューのボタンを無効
				this.NewData_toolStripMenuItem.Enabled = false;
				this.FixData_toolStripMenuItem.Enabled = false;
				this.DelData_toolStripMenuItem.Enabled = false;
				this.Exit_toolStripMenuItem.Enabled    = false;

				this.NewData_toolStripButton.Enabled   = false;
				this.FixData_toolStripButton.Enabled   = false;
				this.DelData_toolStripButton.Enabled   = false;
				this.Exit_toolStripButton.Enabled      = false;

				// オプションツールがある場合
				if( this._optionTools != null ) {
					foreach( ToolStripItem item in this._optionTools.Values ) {
						item.Enabled                   = false;
					}
				}
			}
			else {
				// メニューのボタンを有効
				this.NewData_toolStripMenuItem.Enabled = true;
				this.FixData_toolStripMenuItem.Enabled = true;
				this.DelData_toolStripMenuItem.Enabled = true;
				this.Exit_toolStripMenuItem.Enabled    = true;

				this.NewData_toolStripButton.Enabled   = true;
				this.FixData_toolStripButton.Enabled   = true;
				this.DelData_toolStripButton.Enabled   = true;
				this.Exit_toolStripButton.Enabled      = true;

				// オプションツールがある場合
				if( this._optionTools != null ) {
					foreach( ToolStripItem item in this._optionTools.Values ) {
						item.Enabled                   = true;
					}
				}

				// 自分自身をアクティブにする
				if( ( Form.ActiveForm == null ) || 
					( Form.ActiveForm != this ) ) {
					this.Activate();
				}
			}
		}

		#endregion

		#region ■Click イベント (OptionTool_toolStripItem)

		/// <summary>
		/// Click イベント (OptionTool_toolStripItem)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void OptionTool_toolStripItem_Click( object sender, EventArgs e )
		{
			ToolStripItem item = sender as ToolStripItem;

			if( item == null ) {
				return;
			}

			// キーを取得
			string key = null;
			try {
				key = item.Name.Substring( 11 );
			}
			catch {
				return;
			}

			if( String.IsNullOrEmpty( key ) ) {
				return;
			}

			// コマンド処理
			this._iSimpleMasterMaintenanceMulti.OptionToolCommand( key, this );
		}

		#endregion

		#endregion
	}
}