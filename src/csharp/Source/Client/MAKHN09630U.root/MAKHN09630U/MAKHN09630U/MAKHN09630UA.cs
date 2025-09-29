using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 画像情報マスタフォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 画像情報マスタの設定を行います。</br>
	/// <br>Programmer : 22022 段上 知子</br>
	/// <br>Date       : 2007.05.16</br>
    /// <br>UpdateNote : 2008/10/29 照田 貴志 バグ修正、仕様変更対応</br>
    /// <br>           : 2008/11/07           上記修正時に作り込んだバグを修正</br>
	/// </remarks>
	public partial class MAKHN09630UA : Form, IMasterMaintenanceMultiType
	{
		// --------------------------------------------------
		#region Constructor

		/// <summary>
        /// 画像情報マスタフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 画像情報マスタフォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		public MAKHN09630UA()
		{
			InitializeComponent();

			// プロパティ初期値
			this._canClose                          = false;    // 閉じる機能(false固定)
            this._canDelete                         = true;     // 削除機能
			this._canLogicalDeleteDataExtraction    = true;     // 論理削除データ表示機能
            this._canNew                            = true;     // 新規作成機能
			this._canPrint                          = false;    // 印刷機能
			this._canSpecificationSearch            = false;    // 件数指定検索機能
			this._defaultAutoFillToColumn           = true;     // 列サイズ自動調整機能

			// 企業コード取得
			this._enterpriseCode                    = LoginInfoAcquisition.EnterpriseCode;

			// インスタンス初期化
            this._imageInfoAcs                      = new ImageInfoAcs();

			// グリッド選択インデックス
			this._dataIndex                         = -1;
			this._indexBuf                          = -2;
		}

		#endregion

		// --------------------------------------------------
		#region Private Members

        private string                  _enterpriseCode = "";           // 企業コード

        private ImageInfoAcs            _imageInfoAcs   = null;

		// メイン用クローンオブジェクト
        private ImageInfo               _imageInfoClone = null;

		// _GridIndexバッファ（メインフレーム最小化対応）
		private int                     _dataIndex;
		private int                     _indexBuf;

		// プロパティ用
		private bool                    _canClose;
		private bool                    _canDelete;
		private bool                    _canLogicalDeleteDataExtraction;
		private bool                    _canNew;
		private bool                    _canPrint;
		private bool                    _canSpecificationSearch;
		private bool                    _defaultAutoFillToColumn;

        // 2009.03.25 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
        // 2009.03.25 30413 犬飼 新規モードからモード変更対応 <<<<<<END

		// 編集モード
		private int                     _editingMode    = 0;
		private const int               CT_EMODE_INSERT = -1;           // 新規モード
		private const int               CT_EMODE_UPDATE = 0;            // 更新モード
		private const int               CT_EMODE_DELETE = 1;            // 削除モード
		private const int               CT_EMODE_REFER  = 2;            // 参照モード
		private const string            INSERT_MODE     = "新規モード";
		private const string            UPDATE_MODE     = "更新モード";
		private const string            DELETE_MODE     = "削除モード";
		private const string            REFER_MODE      = "参照モード";

        // 画面レイアウト用定数
        private const int               BUTTON_LOCATION1_X  = 204;      // 完全削除ボタン位置X
        private const int               BUTTON_LOCATION2_X  = 331;      // 復活ボタン位置X
        private const int               BUTTON_LOCATION3_X  = 458;      // 保存ボタン位置X
        private const int               BUTTON_LOCATION4_X  = 585;      // 閉じるボタン位置X
        private const int               BUTTON_LOCATION_Y   = 9;        // ボタン位置Y(共通)

		// PG情報
		private const string            CT_PGID        = "MAKHN09630UA";
		private const string            CT_PGNAME      = "画像情報マスタ";
		private const string            CT_CLASSNAME   = "MAKHN09630UA";

        // Message関連定義
        private const string            ERR_READ_MSG   = "読み込みに失敗しました。";
        private const string            ERR_DPR_MSG    = "このコードは既に使用されています。";
        private const string            ERR_RDEL_MSG   = "削除に失敗しました。";
        private const string            ERR_UPDT_MSG   = "登録に失敗しました。";
        private const string            ERR_RVV_MSG    = "復活に失敗しました。";
        private const string            ERR_800_MSG    = "既に他端末より更新されています。";
        private const string            ERR_801_MSG    = "既に他端末より削除されています。";
        private const string            SDC_RDEL_MSG   = "マスタから削除されています。";
        private const string            SDC_NFND_MSG   = "マスタに登録されていません。";

		#endregion

		// --------------------------------------------------
		#region Events

		/// <summary>画面非表示イベント</summary>
		/// <remarks>画面が非表示状態になった時に発生します。</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;

		#endregion

		// --------------------------------------------------
		#region Delegate

		/// <summary>
		/// グリッド用非同期デリゲート
		/// </summary>
		/// <param name="rowIndex">行インデックス</param>
		/// <param name="columnName">カラム名</param>
		/// <remarks>
        /// <br>Note       : グリッドにおける非同期実行に使用するデリゲートです。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private delegate void GridMethodInvoker( int rowIndex, string columnName );

		#endregion

		// --------------------------------------------------
		#region Properties

		/// <summary>画面終了設定プロパティ</summary>
		/// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
		/// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
		public bool CanClose
		{
			get {
				return this._canClose;
			}
			set {
				this._canClose = value;
			}
		}

		/// <summary>削除可能設定プロパティ</summary>
		/// <value>削除が可能かどうかの設定を取得します。</value>
		public bool CanDelete
		{
			get {
				return this._canDelete;
			}
		}

		/// <summary>論理削除データ抽出可能設定プロパティ</summary>
		/// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
		public bool CanLogicalDeleteDataExtraction
		{
			get {
				return this._canLogicalDeleteDataExtraction;
			}
		}

		/// <summary>新規作成可能設定プロパティ</summary>
		/// <value>新規作成が可能かどうかの設定を取得します。</value>
		public bool CanNew
		{
			get {
				return this._canNew;
			}
		}

		/// <summary>印刷可能設定プロパティ</summary>
		/// <value>印刷が可能かどうかの設定を取得します。</value>
		public bool CanPrint
		{
			get {
				return this._canPrint;
			}
		}

		/// <summary>件数指定抽出可能設定プロパティ</summary>
		/// <value>件数指定抽出が可能かどうかの設定を取得します。</value>
		public bool CanSpecificationSearch
		{
			get {
				return this._canSpecificationSearch;
			}
		}

		/// <summary>データセットの選択データインデックスプロパティ</summary>
		/// <value>データセットの選択データインデックスを取得または設定します。</value>
		public int DataIndex
		{
			get {
				return this._dataIndex;
			}
			set {
				this._dataIndex = value;
			}
		}

		/// <summary>列のサイズの自動調整のデフォルト値プロパティ</summary>
		/// <value>列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
		public bool DefaultAutoFillToColumn
		{
			get {
				return this._defaultAutoFillToColumn;
			}
		}

		#endregion

        // --------------------------------------------------
        #region Frame Methods
        
		/// <summary>
		/// バインドデータセット取得処理
		/// </summary>
		/// <param name="bindDataSet">グリッド用データセット</param>
		/// <param name="tableName">テーブル名</param>
		/// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		public void GetBindDataSet( ref DataSet bindDataSet, ref string tableName )
		{
			bindDataSet		= this._imageInfoAcs.BindDataSet;
			tableName		= ImageInfoAcs.TBL_IMAGEINFO_TITLE;
		}
        
		/// <summary>
		/// グリッド列外観情報取得処理
		/// </summary>
		/// <returns>グリッド列外観情報格納Hashtable</returns>
		/// <remarks>
        /// <br>Note       : グリッドの各列の外観を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

			// 削除日
            appearanceTable.Add( ImageInfoAcs.COL_DELETEDATE_TITLE, 
                new GridColAppearance( MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red ) );
            // 画像情報区分コード
            appearanceTable.Add( ImageInfoAcs.COL_IMAGEINFODIVCODE_TITLE, 
				new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            // 画像情報区分名称
            /* --- DEL 2008/10/29 登録画面に無い項目の為、グリッドに表示させない ----------------------------->>>>>
            appearanceTable.Add( ImageInfoAcs.COL_IMAGEINFODIVNAME_TITLE, 
                new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black ) );
               --- DEL 2008/10/29 ----------------------------------------------------------------------------<<<<< */
            // --- ADD 2008/10/29 ---------------------------------------------------------------------------->>>>>
            appearanceTable.Add(ImageInfoAcs.COL_IMAGEINFODIVNAME_TITLE,
                new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2008/10/29 ----------------------------------------------------------------------------<<<<<
            // 画像情報コード
            appearanceTable.Add( ImageInfoAcs.COL_IMAGEINFOCODE_TITLE, 
				new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black ) );
            // 画像情報表示名称
            appearanceTable.Add( ImageInfoAcs.COL_IMAGEINFONAME_TITLE, 
				new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black ) );
            // 画像情報ファイルタイプ
            appearanceTable.Add( ImageInfoAcs.COL_IMAGEINFOFLTYPE_TITLE, 
				new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black ) );
            // 画像情報データ
            appearanceTable.Add( ImageInfoAcs.COL_IMAGEINFODATA_TITLE, 
				new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black ) );
            // GUID
            appearanceTable.Add( ImageInfoAcs.COL_GUID_TITLE, 
                new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black ) );

            return appearanceTable;
		}

        #endregion

        // --------------------------------------------------
        #region DataAccess Methods

		/// <summary>
		/// データ検索処理
		/// </summary>
		/// <param name="totalCount">全該当件数</param>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したデータセットと全該当件数を返します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		public int Search( ref int totalCount, int readCount )
		{
            // 画像情報取得処理
            return this.SearchProc(ref totalCount, readCount);
		}

		/// <summary>
		/// Nextデータ検索処理
		/// </summary>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : Nextデータの検索処理を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		public int SearchNext( int readCount )
		{
			// 未実装
			return ( int )ConstantManagement.DB_Status.ctDB_EOF;
		}

		/// <summary>
		/// データ検索処理
		/// </summary>
		/// <param name="totalCount">全該当件数</param>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : データの検索を行い抽出結果をDataSetに格納し、該当件数を返します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        private int SearchProc(ref int totalCount, int readCount)
		{
            const string ctPROCNM = "SearchProc";
			int status = ( int )ConstantManagement.DB_Status.ctDB_EOF;

			totalCount = 0;
			
			// 検索実行
			status = this._imageInfoAcs.SearchAll( out totalCount, this._enterpriseCode );
			switch( status ) {
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case ( int )ConstantManagement.DB_Status.ctDB_EOF:
				{
					break;
				}
				default:
				{
					// サーチ
					TMsgDisp.Show( 
						this,                               // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP,        // エラーレベル
						CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
						CT_PGNAME,                          // プログラム名称
						ctPROCNM,                           // 処理名称
						TMsgDisp.OPE_GET,                   // オペレーション
                        ERR_READ_MSG,                       // 表示するメッセージ
						status,                             // ステータス値
						this._imageInfoAcs,                 // エラーが発生したオブジェクト
						MessageBoxButtons.OK,               // 表示するボタン
						MessageBoxDefaultButton.Button1 );  // 初期表示ボタン
					 break;
				}
			}

			return status;
		}
        
		/// <summary>
		/// 登録・更新処理
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : マスタ情報の保存処理を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private bool SaveProc()
		{
			const string ctPROCNM = "SaveProc";
			bool result = false;

			// 入力チェック
			Control control = null;
			string message = null;
			if( this.ScreenDataCheck( ref control, ref message ) == false ) {
				// 入力チェック
				TMsgDisp.Show( 
					this,                               // 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
					CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
					message,                            // 表示するメッセージ
					0,                                  // ステータス値
					MessageBoxButtons.OK );             // 表示するボタン

				if( control != null ) {
					control.Focus();
					if( control is TEdit ) {
						( ( TEdit )control ).SelectAll();
					}
					else if( control is TNedit ) {
						( ( TNedit )control ).SelectAll();
					}
				}

				return result;
			}

            // 画面データ取得
            ImageInfo imageInfo = new ImageInfo();
			this.DispToImageInfo( ref imageInfo );

			// 書き込み処理
			int status = 0;
			status = this._imageInfoAcs.Write( imageInfo );

			switch( status ) {
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					result = true;
					break;
				}
				case ( int )ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					// コード重複
					TMsgDisp.Show(
						this,                           // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_INFO,    // エラーレベル
						CT_PGID,                        // アセンブリＩＤまたはクラスＩＤ
                        ERR_DPR_MSG,                    // 表示するメッセージ
						0,                              // ステータス値
						MessageBoxButtons.OK );         // 表示するボタン

                    this.ImageInfoCode_tNedit.Focus();
                    this.ImageInfoCode_tNedit.SelectAll();

					return result;
				}
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					this.ExclusiveTransaction( status, true );
					break;
				}
				default:
				{
					// 登録失敗
					TMsgDisp.Show(
						this,                               // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP,        // エラーレベル
						CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
						CT_PGNAME,                          // プログラム名称
						ctPROCNM,                           // 処理名称
						TMsgDisp.OPE_UPDATE,                // オペレーション
                        ERR_UPDT_MSG,                       // 表示するメッセージ
						status,                             // ステータス値
						this._imageInfoAcs,                 // エラーが発生したオブジェクト
						MessageBoxButtons.OK,               // 表示するボタン
						MessageBoxDefaultButton.Button1 );  // 初期表示ボタン
					this.CloseForm( DialogResult.Cancel );
					return result;
				}
			}

			return result;
		}

		/// <summary>
		/// データ削除処理
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 選択中のレコードの削除を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		public int Delete()
		{
			return this.LogicalDeleteProc();
		}
        
		/// <summary>
		/// 論理削除処理
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : マスタ情報の論理削除処理を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        private int LogicalDeleteProc()
        {
            const string ctPROCNM = "LogicalDeleteProc";
            int status = 0;

            DataTable dt = this._imageInfoAcs.BindDataSet.Tables[ImageInfoAcs.TBL_IMAGEINFO_TITLE];

            // グリッドが選択されていない時
            if ((this._dataIndex < 0) ||
                (this._dataIndex >= dt.Rows.Count))
            {
                return status;
            }

            // 選択データ取得
            Guid fileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][ImageInfoAcs.COL_GUID_TITLE]; // GUID

            // 論理削除実行
            status = this._imageInfoAcs.LogicalDelete(fileHeaderGuid);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                // 排他制御
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, false);
                        return status;
                    }
                default:
                    {
                        // 物理削除
                        TMsgDisp.Show(
                            this,                               // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,        // エラーレベル
                            CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
                            CT_PGNAME,                          // プログラム名称
                            ctPROCNM,                           // 処理名称
                            TMsgDisp.OPE_UPDATE,                // オペレーション
                            ERR_RDEL_MSG,                       // 表示するメッセージ
                            status,                             // ステータス値
                            this._imageInfoAcs,                 // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,               // 表示するボタン
                            MessageBoxDefaultButton.Button1);   // 初期表示ボタン
                        return status;
                    }
            }
            return status;
        }

		/// <summary>
		/// 論理削除復活処理
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 論理削除復活処理を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private int RevivalProc()
		{
			const string ctPROCNM = "RevivalProc";
			int status = 0;

            DataTable dt = this._imageInfoAcs.BindDataSet.Tables[ImageInfoAcs.TBL_IMAGEINFO_TITLE];

			// グリッドが選択されていない時
			if( ( this._indexBuf < 0 ) || 
				( this._indexBuf >= dt.Rows.Count ) ) {
				this.CloseForm( DialogResult.Cancel );
				return -1;
			}

            // 選択データ取得
            Guid fileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][ImageInfoAcs.COL_GUID_TITLE]; // GUID

			// 論理削除復活実行
            status = this._imageInfoAcs.Revival(fileHeaderGuid);

			switch( status ) {
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				// 排他制御
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction( status, true );
					return status;
				}
				default:
				{
					// 物理削除
					TMsgDisp.Show( 
						this,                               // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP,        // エラーレベル
						CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
						CT_PGNAME,                          // プログラム名称
						ctPROCNM,                           // 処理名称
						TMsgDisp.OPE_UPDATE,                // オペレーション
                        ERR_RVV_MSG,                        // 表示するメッセージ
						status,                             // ステータス値
						this._imageInfoAcs,                 // エラーが発生したオブジェクト
						MessageBoxButtons.OK,               // 表示するボタン
						MessageBoxDefaultButton.Button1 );  // 初期表示ボタン
					return status;
				}
			}

			return status;
		}

		/// <summary>
		/// 物理削除処理
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 物理削除処理を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private int PhysicalDeleteProc()
		{
			const string ctPROCNM = "PhysicalDeleteProc";
			int status = 0;

            DataTable dt = this._imageInfoAcs.BindDataSet.Tables[ImageInfoAcs.TBL_IMAGEINFO_TITLE];

			// グリッドが選択されていない時
			if( ( this._indexBuf < 0 ) || 
				( this._indexBuf >= dt.Rows.Count ) ) {
				this.CloseForm( DialogResult.Cancel );
				return -1;
            }

            // 選択データ取得
            Guid fileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][ImageInfoAcs.COL_GUID_TITLE]; // GUID

			// 物理削除実行
            status = this._imageInfoAcs.Delete(fileHeaderGuid);

			switch( status ) {
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				// 排他制御
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction( status, true );
					return status;
				}
				default:
				{
					// 物理削除
					TMsgDisp.Show( 
						this,                               // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP,        // エラーレベル
						CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
						CT_PGNAME,                          // プログラム名称
						ctPROCNM,                           // 処理名称
						TMsgDisp.OPE_DELETE,                // オペレーション
                        ERR_RDEL_MSG,                       // 表示するメッセージ
						status,                             // ステータス値
						this._imageInfoAcs,                 // エラーが発生したオブジェクト
						MessageBoxButtons.OK,               // 表示するボタン
						MessageBoxDefaultButton.Button1 );  // 初期表示ボタン
					return status;
				}
			}

			return status;
		}

		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 印刷処理を実行します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		public int Print()
		{
			// 印刷用アセンブリをロードする(未実装)
			return 0;
		}

		#endregion

        // --------------------------------------------------
        #region MemberCopy Methods
            
		/// <summary>
        /// データセット情報取得処理
        /// </summary>
        /// <param name="imageInfo">画像情報マスタオブジェクト</param>
        /// <param name="index">取得対象行</param>
		/// <remarks>
        /// <br>Note       : データセットからの情報取得を行います</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        private void CopyToImageInfoFromDataSet(ref ImageInfo imageInfo, int index)
        {
            // フレームで選択されているレコードのオブジェクトを取得
            DataRowView dr = this._imageInfoAcs.BindDataSet.Tables[ImageInfoAcs.TBL_IMAGEINFO_TITLE].DefaultView[index];

            if ((string)dr[ImageInfoAcs.COL_DELETEDATE_TITLE] != "") // 削除日
            {
                imageInfo.LogicalDeleteCode = 1;    // 論理削除区分
            }
            imageInfo.ImageInfoDiv      = (int   )dr[ImageInfoAcs.COL_IMAGEINFODIVCODE_TITLE];  // 画像情報区分
            //imageInfo.ImageInfoCode     = (int   )dr[ImageInfoAcs.COL_IMAGEINFOCODE_TITLE];     // 画像情報コード                 //DEL 2008/11/07 例外エラーで落ちる為
            imageInfo.ImageInfoCode     = int.Parse(dr[ImageInfoAcs.COL_IMAGEINFOCODE_TITLE].ToString());     // 画像情報コード     //ADD 2008/11/07
            imageInfo.ImageInfoName     = (string)dr[ImageInfoAcs.COL_IMAGEINFONAME_TITLE];     // 画像情報表示名称
            imageInfo.ImageInfoFlType   = (string)dr[ImageInfoAcs.COL_IMAGEINFOFLTYPE_TITLE];   // 画像情報ファイルタイプ
            imageInfo.ImageInfoData     = (Byte[])dr[ImageInfoAcs.COL_IMAGEINFODATA_TITLE];     // 画像情報データ
            imageInfo.FileHeaderGuid    = (Guid  )dr[ImageInfoAcs.COL_GUID_TITLE];              // GUID
        }

		/// <summary>
        /// マスタ情報画面展開処理
        /// </summary>
        /// <param name="imageInfo">画像情報マスタオブジェクト</param>
		/// <remarks>
        /// <br>Note       : マスタ情報を画面に展開します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        private void ImageInfoToScreen(ImageInfo imageInfo)
        {
            // DEL 2008/10/01 不具合対応[5962]↓
            //this.ImageInfoDiv_tComboEditor.Value        = imageInfo.ImageInfoDiv;               // 画像情報区分

            // 画像情報コード
            if (imageInfo.ImageInfoCode != 0)
            {
                //this.ImageInfoCode_tNedit.Value         = imageInfo.ImageInfoCode;                //DEL 2008/11/07 ゼロ詰め
                this.ImageInfoCode_tNedit.Text = imageInfo.ImageInfoCode.ToString("000000000");     //ADD 2008/11/07
            }
            this.ImageInfoName_tEdit.Text               = imageInfo.ImageInfoName;              // 画像情報表示名称
            this.ImageInfoFlType_tEdit.Text             = imageInfo.ImageInfoFlType;            // 画像情報ファイルタイプ
            // 画像情報データ
            MemoryStream mem = new MemoryStream(imageInfo.ImageInfoData);
            mem.Position = 0;
            this.ImageInfoData_UltraPictureBox.Image = Image.FromStream(mem);
        }
        
		/// <summary>
		/// 画面データ取得処理
		/// </summary>
        /// <param name="imageInfo">画像情報マスタオブジェクト</param>
		/// <remarks>
        /// <br>Note       : 画面データの取得を行います</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        private void DispToImageInfo(ref ImageInfo imageInfo)
        {
            // 更新モードの場合
            if (this._editingMode == CT_EMODE_UPDATE)
            {
                // Guid
                DataTable dt = this._imageInfoAcs.BindDataSet.Tables[ImageInfoAcs.TBL_IMAGEINFO_TITLE];
                imageInfo.FileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][ImageInfoAcs.COL_GUID_TITLE];
            }

            // DEL 2008/10/01 不具合対応[5962]---------->>>>>
            //// 画像情報区分
            //if (this.ImageInfoDiv_tComboEditor.SelectedIndex >= 0)
            //{
            //    imageInfo.ImageInfoDiv = (int)this.ImageInfoDiv_tComboEditor.Value;
            //}
            // DEL 2008/10/01 不具合対応[5962]----------<<<<<
            // ADD 2008/10/01 不具合対応[5962]↓
            imageInfo.ImageInfoDiv      = ImageInfo.CONST_IMAGEINFODIV_COM;         // 画像情報区分（自社画像）
            imageInfo.EnterpriseCode    = this._enterpriseCode;                     // 企業コード
            imageInfo.ImageInfoCode     = this.ImageInfoCode_tNedit.GetInt();       // 画像情報コード
            imageInfo.ImageInfoName     = this.ImageInfoName_tEdit.Text.TrimEnd();  // 画像情報表示名称
            imageInfo.ImageInfoFlType   = this.ImageInfoFlType_tEdit.Text;          // 画像情報ファイルタイプ
            // 画像情報データ
            if (this.ImageInfoData_UltraPictureBox.Image != null)
            {
                imageInfo.ImageInfoData = null;
                MemoryStream mem = new MemoryStream();
                Image img = (Image)this.ImageInfoData_UltraPictureBox.Image;
                img.Save(mem, System.Drawing.Imaging.ImageFormat.Bmp);
                imageInfo.ImageInfoData = mem.ToArray();
            }
        }

        #endregion

        // --------------------------------------------------
        #region Screen Methods
        
		/// <summary>
		/// 画面クリア処理
		/// </summary>
		/// <remarks>
        /// <br>Note       : 画面のクリアを行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private void ScreenClear()
        {
            // DEL 2008/10/01 不具合対応[5962]---------->>>>>
            // コンボボックスセット処理
            //this.SetComboEditor();

            //this.ImageInfoDiv_tComboEditor.Value = ImageInfo.CONST_IMAGEINFODIV_COM;    // 画像情報区分
            // DEL 2008/10/01 不具合対応[5962]----------<<<<<

            this.ImageInfoCode_tNedit.Clear();                                          // 画像情報コード
            this.ImageInfoName_tEdit.Clear();                                           // 画像情報表示名称
            this.ImageInfoFlType_tEdit.Clear();                                         // 画像情報ファイルタイプ
            this.ImageInfoData_UltraPictureBox.Image = null;                            // 画像情報データ
            this.ImageInfoData_OpenFileDialog.FileName = "";
        }

        // DEL 2008/10/01 不具合対応[5962]---------->>>>>
        ///// <summary>
        ///// コンボボックスセット処理
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : コンボボックスをセットします。</br>
        ///// <br>Programmer : 22022 段上 知子</br>
        ///// <br>Date       : 2007.05.16</br>
        ///// </remarks>
        //public void SetComboEditor()
        //{
        //    ImageInfo imageInfo = new ImageInfo();

        //    // 画像情報区分
        //    this.ImageInfoDiv_tComboEditor.Items.Clear();
        //    foreach (int code in ImageInfo.ImageInfoDivCodes)
        //    {
        //        this.ImageInfoDiv_tComboEditor.Items.Add(code, imageInfo.GetImageInfoDivName(code));
        //    }
        //}
        // DEL 2008/10/01 不具合対応[5962]----------<<<<<

        /// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
        /// <br>Note       : 画面の再構築処理を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private void ScreenReconstruction()
        {
            ImageInfo imageInfo = new ImageInfo();

			// 新規の時
            if (this._dataIndex < 0)
            {
                // 新規モードに設定
                this._editingMode = CT_EMODE_INSERT;
                this.Mode_Label.Text = INSERT_MODE;

                // クローン作成
                this._imageInfoClone = new ImageInfo();
                this.DispToImageInfo(ref this._imageInfoClone);

                // 画面入力許可制御設定
                this.ScreenInputPermissionControl(this._editingMode);
            }
            else
            {
                // フレームで選択されているレコードのオブジェクトを取得
                CopyToImageInfoFromDataSet(ref imageInfo, this._dataIndex);

                // 更新モード
                if (imageInfo.LogicalDeleteCode == 0)
                {
                    // 更新モードに設定
                    this._editingMode = CT_EMODE_UPDATE;
                    this.Mode_Label.Text = UPDATE_MODE;
                }
                // 削除モード
                else
                {
                    // 削除モードに設定
                    this._editingMode = CT_EMODE_DELETE;
                    this.Mode_Label.Text = DELETE_MODE;
                }

                // 画面に展開
                this.ImageInfoToScreen(imageInfo);

                // クローン作成
                this._imageInfoClone = new ImageInfo();
                this.DispToImageInfo(ref this._imageInfoClone);

                // 画面入力許可制御設定
                this.ScreenInputPermissionControl(this._editingMode);
            }

			// GridIndexバッファ保持
			this._indexBuf = this._dataIndex;
		}

		/// <summary>
		/// 画面入力許可制御処理
		/// </summary>
		/// <param name="editingMode">編集モード</param>
		/// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private void ScreenInputPermissionControl( int editingMode )
		{
			switch( editingMode ) {
				// 新規モード
				case CT_EMODE_INSERT:
				{
					// 表示設定
					this.Delete_Button.Visible              = false;    // 完全削除ボタン
					this.Revive_Button.Visible              = false;    // 復活ボタン
					this.Ok_Button.Visible                  = true;     // 保存ボタン
					this.Cancel_Button.Visible              = true;     // 閉じるボタン

                    // 入力許可設定
                    // DEL 2008/10/01 不具合対応[5962]↓
                    //this.ImageInfoDiv_tComboEditor.Enabled  = true;     // 画像情報区分
                    this.ImageInfoCode_tNedit.Enabled       = true;     // 画像情報コード
					this.ImageInfoName_tEdit.Enabled        = true;     // 画像情報表示名称
                    this.ImageInfoDataGuide_Button.Enabled  = true;     // 画像情報ガイドボタン
                    this.ImageInfoDataDelete_Button.Enabled = true;     // 画像情報削除ボタン

					// 初期フォーカス設定
                    // DEL 2008/10/01 不具合対応[5962]↓
                    //this.ImageInfoDiv_tComboEditor.Focus();
                    // DEL 2008/10/01 不具合対応[5009]↓
                    //this.ImageInfoDiv_tComboEditor.SelectAll();
                    ImageInfoCode_tNedit.Focus();   // ADD 2008/09/30 不具合対応[5962]
					break;
				}
				// 更新モード
				case CT_EMODE_UPDATE:
				{
					// 表示設定
					this.Delete_Button.Visible              = false;    // 完全削除ボタン
					this.Revive_Button.Visible              = false;    // 復活ボタン
					this.Ok_Button.Visible                  = true;     // 保存ボタン
					this.Cancel_Button.Visible              = true;     // 閉じるボタン

                    // 入力許可設定
                    // DEL 2008/10/01 不具合対応[5962]↓
                    //this.ImageInfoDiv_tComboEditor.Enabled  = false;    // 画像情報区分
                    this.ImageInfoCode_tNedit.Enabled       = false;    // 画像情報コード
                    this.ImageInfoName_tEdit.Enabled        = true;     // 画像情報表示名称
                    this.ImageInfoDataGuide_Button.Enabled  = true;     // 画像情報ガイドボタン
                    this.ImageInfoDataDelete_Button.Enabled = true;     // 画像情報削除ボタン

					// 初期フォーカス設定
					this.ImageInfoName_tEdit.Focus();
					this.ImageInfoName_tEdit.SelectAll();
					break;
				}
				// 削除モード
				case CT_EMODE_DELETE:
				{
					// 表示設定
					this.Ok_Button.Visible      = false;    // 保存ボタン
					this.Cancel_Button.Visible  = true;     // 閉じるボタン
                    this.Delete_Button.Visible  = true;     // 完全削除ボタン
                    this.Revive_Button.Visible  = true;     // 復活ボタン
                    this.Delete_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // 完全削除ボタン位置シフト
                    this.Revive_Button.Location = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // 復活ボタン位置シフト

                    // 入力許可設定
                    // DEL 2008/10/01 不具合対応[5962]↓
                    //this.ImageInfoDiv_tComboEditor.Enabled  = false;    // 画像情報区分
                    this.ImageInfoCode_tNedit.Enabled       = false;    // 画像情報コード
                    this.ImageInfoName_tEdit.Enabled        = false;    // 画像情報表示名称
                    this.ImageInfoDataGuide_Button.Enabled  = false;    // 画像情報ガイドボタン
                    this.ImageInfoDataDelete_Button.Enabled = false;    // 画像情報削除ボタン

					// 初期フォーカス設定
					this.Delete_Button.Focus();
					break;
				}
				// 参照モード
				case CT_EMODE_REFER:
				{
					// 表示設定
					this.Ok_Button.Visible                  = false;    // 保存ボタン
					this.Cancel_Button.Visible              = true;     // 閉じるボタン
					this.Revive_Button.Visible              = false;    // 復活ボタン
					this.Delete_Button.Visible              = false;    // 完全削除ボタン

					// 入力許可設定
                    // DEL 2008/10/01 不具合対応[5962]↓
                    //this.ImageInfoDiv_tComboEditor.Enabled  = false;    // 画像情報区分
                    this.ImageInfoCode_tNedit.Enabled       = false;    // 画像情報コード
                    this.ImageInfoName_tEdit.Enabled        = false;    // 画像情報表示名称
                    this.ImageInfoDataGuide_Button.Enabled  = false;    // 画像情報ガイドボタン
                    this.ImageInfoDataDelete_Button.Enabled = false;    // 画像情報削除ボタン

					// 初期フォーカス設定
					this.Cancel_Button.Focus();
					break;
				}
			}
		}
        
		/// <summary>
		/// 排他処理
		/// </summary>
		/// <param name="status">STATUS</param>
		/// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
		/// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private void ExclusiveTransaction( int status, bool hide )
		{
			switch( status ) {
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					// 他端末更新
					TMsgDisp.Show( 
						this,                               // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
						CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
                        ERR_800_MSG,                        // 表示するメッセージ
						0,                                  // ステータス値
						MessageBoxButtons.OK );             // 表示するボタン
					if( hide == true ) {
						this.CloseForm( DialogResult.Cancel );
					}
					break;
				}
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// 他端末削除
					TMsgDisp.Show( 
						this,                               // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
						CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
                        ERR_801_MSG,                        // 表示するメッセージ
						0,                                  // ステータス値
						MessageBoxButtons.OK );             // 表示するボタン
					if( hide == true ) {
						this.CloseForm( DialogResult.Cancel );
					}
					break;
				}
			}
		}
        
		/// <summary>
		/// フォームクローズ処理
		/// </summary>
		/// <param name="dialogResult">ダイアログ結果</param>
		/// <remarks>
        /// <br>Note       : フォームを閉じます。その際画面クローズイベント等の発生を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private void CloseForm( DialogResult dialogResult )
		{
			// 画面非表示イベント
			if ( this.UnDisplaying != null ) {
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( dialogResult );
				this.UnDisplaying( this, me );
			}

			this.DialogResult = dialogResult;

			// GridIndexバッファ初期化
			this._indexBuf    = -2;
			
			// CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
			// フォームを非表示化する。
			if( this._canClose == true ) {
				this.Close();
			}
			else {
				this.Hide();
			}
		}

		/// <summary>
		/// 画面入力情報不正チェック処理
		/// </summary>
		/// <param name="control">不正対象コントロール</param>
		/// <param name="message">メッセージ</param>
		/// <returns>チェック結果[true: OK, false: NG]</returns>
		/// <remarks>
        /// <br>Note       : 画面の入力情報の不正チェックを行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            bool result = true;

            // 画像情報コードが未入力
            if (this.ImageInfoCode_tNedit.GetInt() == 0)
            {
                message = this.ImageInfoCode_Title_Label.Text + "を入力してください。";
                control = this.ImageInfoCode_tNedit;
                result = false;
            }
            // 画像情報表示名称が未入力
            else if (this.ImageInfoName_tEdit.Text.TrimEnd() == "")
            {
                message = this.ImageInfoName_Title_Label.Text + "を入力してください。";
                control = this.ImageInfoName_tEdit;
                result = false;
            }
            // 画像情報データが未設定
            else if (this.ImageInfoData_UltraPictureBox.Image == null)
            {
                message = this.ImageInfoData_Title_Label.Text + "を設定してください。";
                control = this.ImageInfoDataGuide_Button;
                result = false;
            }

            return result;
        }

        #endregion

        // --------------------------------------------------
		#region Control Events

		/// <summary>
		/// Form.Load イベント (MAGRP09120UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
        /// <br>Note       : ユーザーがフォームを読み込む時に発生します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private void MAGRP09120UA_Load( object sender, EventArgs e )
		{
			ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Ok_Button.ImageList                    = imageList24;   // 保存ボタン
			this.Cancel_Button.ImageList                = imageList24;   // 閉じるボタン
			this.Revive_Button.ImageList                = imageList24;   // 復活ボタン
			this.Delete_Button.ImageList                = imageList24;   // 完全削除ボタン
            this.ImageInfoDataGuide_Button.ImageList    = imageList16;   // 画像情報ガイドボタン

			this.Ok_Button.Appearance.Image                 = Size24_Index.SAVE;      // 保存ボタン
			this.Cancel_Button.Appearance.Image             = Size24_Index.CLOSE;     // 閉じるボタン
			this.Revive_Button.Appearance.Image             = Size24_Index.REVIVAL;   // 復活ボタン
			this.Delete_Button.Appearance.Image             = Size24_Index.DELETE;    // 完全削除ボタン
            this.ImageInfoDataGuide_Button.Appearance.Image = Size16_Index.STAR1;     // 画像情報ガイドボタン
		}

		/// <summary>
        /// Form.FormClosing イベント (MAGRP09120UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
        /// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private void MAGRP09120UA_FormClosing( object sender, FormClosingEventArgs e )
		{
			// GridIndex保持用バッファ初期化処理
			this._indexBuf = -2;
			
			if( this._canClose == false ) {
				if( e.CloseReason == CloseReason.UserClosing ) {
					e.Cancel = true;
					this.Hide();
				}
			}
		}

		/// <summary>
        /// Form.VisibleChanged イベント (MAGRP09120UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
        /// <br>Note       : フォームの表示状態が変化した時に発生します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private void MAGRP09120UA_VisibleChanged( object sender, EventArgs e )
		{
			if( this.Visible == false ) {
				this.Owner.Activate();
				return;
			}

			// GridIndexバッファ（メインフレーム最小化対応）
			// ターゲットレコード(Index)が変わっていなかった場合以下の処理をキャンセルする
			if( this._dataIndex == this._indexBuf ) {
				return;
			}

			this.Initial_Timer.Enabled = true;
			this.ScreenClear();
		}

		/// <summary>
		/// Timer.Tick イベント (Initial_Timer)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
        /// <br>Note       : 指定された間隔の時間が経過した時に発生します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private void Initial_Timer_Tick( object sender, EventArgs e )
		{
			this.Initial_Timer.Enabled = false;

			// 画面再構築処理
			this.ScreenReconstruction();
		}

		/// <summary>
		/// UltraButton.Click イベント (Ok_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
        /// <br>Note       : 保存ボタンがクリックされたときに発生します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private void Ok_Button_Click( object sender, EventArgs e )
		{
			// 登録処理
			if( this.SaveProc() == false ) {
				return;
			}

			// イベント発生
			if( this.UnDisplaying != null ) {
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
				this.UnDisplaying( this, me );
			}

			// 新規モードの場合は画面を終了させずに連続入力を可能とする。
			if( this._editingMode == CT_EMODE_INSERT ) {
				// 画面を初期化
				this.ScreenClear();

				// 新規モードに設定
				this._editingMode    = CT_EMODE_INSERT;
				this.Mode_Label.Text = INSERT_MODE;

                ImageInfo newImageInfo = new ImageInfo();

				// クローン作成
                this._imageInfoClone = new ImageInfo();
				this.DispToImageInfo( ref this._imageInfoClone );

				// GridIndexバッファ初期化
				this._indexBuf    = -2;

				// 画面入力許可設定
                this.ScreenInputPermissionControl(this._editingMode);
			}
			else {
				this.DialogResult = DialogResult.OK;

				// GridIndexバッファ初期化
				this._indexBuf    = -2;

				if( this._canClose == true ) {
					this.Close();
				}
				else {
					this.Hide();
				}
			}
		}

		/// <summary>
		/// UltraButton.Click イベント (Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
        /// <br>Note       : 閉じるボタンがクリックされたときに発生します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private void Cancel_Button_Click( object sender, EventArgs e )
		{
			// 削除モード・参照モード以外の場合は保存確認処理を行う
			if( ( this._editingMode != CT_EMODE_DELETE ) && 
				( this._editingMode != CT_EMODE_REFER  ) ) {
				// 現在の画面情報を取得する
                ImageInfo compareImageInfo = this._imageInfoClone.Clone();
				this.DispToImageInfo( ref compareImageInfo );

				// 最初に取得した画面と比較
				if( this._imageInfoClone.Equals( compareImageInfo ) == false ) {
					// 画面情報が変更されていた場合は、保存確認メッセージを表示する。
					DialogResult res = TMsgDisp.Show( 
						this,                               // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
						CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
						null,                               // 表示するメッセージ
						0,                                  // ステータス値
						MessageBoxButtons.YesNoCancel );    // 表示するボタン
					switch( res ) {
						case DialogResult.Yes:
						{
							if( this.SaveProc() == false ) {
								return;
							}
							break;
						}
						case DialogResult.No:
						{
							break;
						}
						default:
						{
                            // 2009.03.25 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                            //this.Cancel_Button.Focus();
                            if (_modeFlg)
                            {
                                ImageInfoCode_tNedit.Focus();
                                _modeFlg = false;
                            }
                            else
                            {
                                this.Cancel_Button.Focus();
                            }
                            // 2009.03.25 30413 犬飼 新規モードからモード変更対応 <<<<<<END
                            return;
						}
					}
				}
			}

			// イベント発生
			if( this.UnDisplaying != null ) {
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
				this.UnDisplaying( this, me );
			}

			this.DialogResult = DialogResult.Cancel;

			// GridIndexバッファ初期化
			this._indexBuf    = -2;

			if( this._canClose == true ) {
				this.Close();
			}
			else {
				this.Hide();
			}
		}

		/// <summary>
		/// UltraButton.Click イベント (Revive_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
        /// <br>Note       : 復活ボタンがクリックされたときに発生します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private void Revive_Button_Click( object sender, EventArgs e )
		{
			if( this.RevivalProc() != 0 ) {
				return;
			}

			if( this.UnDisplaying != null ) {
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
				this.UnDisplaying( this, me );
			}

			this.DialogResult = DialogResult.OK;

			// GridIndexバッファ初期化
			this._indexBuf    = -2;

			if( this._canClose == true ) {
				this.Close();
			}
			else {
				this.Hide();
			}
		}

		/// <summary>
		/// UltraButton.Click イベント (Delete_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
        /// <br>Note       : 完全削除ボタンがクリックされたときに発生します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private void Delete_Button_Click( object sender, EventArgs e )
		{
			// 完全削除確認
			DialogResult result = TMsgDisp.Show( 
				this,                               // 親ウィンドウフォーム
				emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
				CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
				"データを削除します。" + "\r\n" + 
				"よろしいですか？",                 // 表示するメッセージ
				0,                                  // ステータス値
				MessageBoxButtons.OKCancel,         // 表示するボタン
				MessageBoxDefaultButton.Button2 );  // 初期表示ボタン

			if( result == DialogResult.OK ) {
				if( this.PhysicalDeleteProc() != 0 ) {
					return;
				}
            }
            else {
				this.Delete_Button.Focus();
                return;
            }

			if( this.UnDisplaying != null ) {
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
				this.UnDisplaying( this, me );
			}

            this.DialogResult = DialogResult.OK;

			// GridIndexバッファ初期化
			this._indexBuf    = -2;

			if( this._canClose == true ) {
				this.Close();
			}
			else {
				this.Hide();
			}
        }

        /// <summary>
        /// Control.Click イベント(ImageInfoDataGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 取込画像選択ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
        /// </remarks>
        private void ImageInfoDataGuide_Button_Click(object sender, EventArgs e)
        {
            DialogResult result = this.ImageInfoData_OpenFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.ImageInfoFlType_tEdit.DataText = Path.GetExtension(this.ImageInfoData_OpenFileDialog.FileName).TrimStart('.');

                // --- ADD 2008/10/29 --------------------------------------------------------------------------------->>>>>
                // 入力されたファイルの形式が"bmp"、"jpg"、"jpeg"かどうかのチェックを行う

                // 入力文字列から判定
                if ((this.ImageInfoFlType_tEdit.DataText.ToUpper() != "BMP") &&
                    (this.ImageInfoFlType_tEdit.DataText.ToUpper() != "JPG") &&
                    (this.ImageInfoFlType_tEdit.DataText.ToUpper() != "JPEG"))
                {
                    TMsgDisp.Show(
                        this,                               // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                        CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
                        "ファイル形式に誤りがあります。",   // 表示するメッセージ
                        0,                                  // ステータス値
                        MessageBoxButtons.OK);              // 表示するボタン
                    return;
                }

                // データから画像形式を判定
                try
                {
                    Bitmap bmp = new Bitmap(this.ImageInfoData_OpenFileDialog.FileName);

                    // bmp の画像形式を文字列で取得
                    string format = bmp.RawFormat.ToString();

                    // 画像の拡張子を求める
                    string ext =                                
                        (format.IndexOf("b96b3cab-0728-11d3-9d7b-0000f81ef32e") != -1) ? "bmp" :
                        (format.IndexOf("b96b3caf-0728-11d3-9d7b-0000f81ef32e") != -1) ? "jpg" :
                        (format.IndexOf("b96b3cae-0728-11d3-9d7b-0000f81ef32e") != -1) ? "jpeg" :
                        "xxx";

                    if (ext == "xxx")
                    {
                        TMsgDisp.Show(
                            this,                               // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
                            "ファイル形式に誤りがあります。",   // 表示するメッセージ
                            0,                                  // ステータス値
                            MessageBoxButtons.OK);              // 表示するボタン
                        return;
                    }
                }
                catch
                {
                    // 入力チェック
                    TMsgDisp.Show(
                        this,                               // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                        CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
                        "ファイル形式に誤りがあります。",   // 表示するメッセージ
                        0,                                  // ステータス値
                        MessageBoxButtons.OK);              // 表示するボタン
                    return;
                }
                // --- ADD 2008/10/29 --------------------------------------------------------------------------------->>>>>

                this.ImageInfoData_UltraPictureBox.Image = Image.FromFile(this.ImageInfoData_OpenFileDialog.FileName);
                // 拠点選択時はフォーカスを次へ移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// Control.Click イベント(ImageInfoDataDelete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 取込画像削除ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
        /// </remarks>
        private void ImageInfoDataDelete_Button_Click(object sender, EventArgs e)
        {
            this.ImageInfoData_UltraPictureBox.Image = null;
            this.ImageInfoFlType_tEdit.Clear();
            this.ImageInfoData_OpenFileDialog.FileName = "";
        }

		#endregion

		// --------------------------------------------------
		#region RetKeyControl Events

		/// <summary>
		/// リターンキー移動イベント
		/// </summary>
		/// <remarks>
        /// <br>Note		: リターンキー押下時の制御を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private void tRetKeyControl1_ChangeFocus( object sender, ChangeFocusEventArgs e )
		{
			if( e.PrevCtrl == null ) {
				return;
			}

            // 2009.03.25 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            _modeFlg = false;
            
            switch (e.PrevCtrl.Name)
            {
                case "ImageInfoCode_tNedit":
                    {
                        // 画像情報コード
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // 遷移先が閉じるボタン
                            _modeFlg = true;
                        }
                        else if (this._dataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = ImageInfoCode_tNedit;
                            }
                        }
                        break;
                    }
            }
            // 2009.03.25 30413 犬飼 新規モードからモード変更対応 <<<<<<END
		}

		#endregion

        // --- ADD 2008/10/29 --------------------------------------------------------------------------->>>>>
        // フォーカス遷移時
        private void ImageInfoCode_tNedit_Leave(object sender, EventArgs e)
        {
            // 0入力時は空にする
            if (this.ImageInfoCode_tNedit.GetInt() == 0)
            {
                this.ImageInfoCode_tNedit.Text = string.Empty;
                return;
            }

            // 0詰め
            this.ImageInfoCode_tNedit.Text = this.ImageInfoCode_tNedit.GetInt().ToString("000000000");
        }
        // フォーカス取得時
        private void ImageInfoCode_tNedit_Enter(object sender, EventArgs e)
        {
            // 0の時は何も表示しない
            if (this.ImageInfoCode_tNedit.GetInt() == 0)
            {
                return;
            }

            // 0詰めしない
            this.ImageInfoCode_tNedit.Text = this.ImageInfoCode_tNedit.GetInt().ToString();
        }
        // --- ADD 2008/10/29 ---------------------------------------------------------------------------<<<<<

        // 2009.03.25 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // 画像情報コード
            int imageInfoCode = ImageInfoCode_tNedit.GetInt();

            for (int i = 0; i < this._imageInfoAcs.BindDataSet.Tables[ImageInfoAcs.TBL_IMAGEINFO_TITLE].DefaultView.Count; i++)
            {
                // データセットと比較
                int dsImageInfoCode = int.Parse(this._imageInfoAcs.BindDataSet.Tables[ImageInfoAcs.TBL_IMAGEINFO_TITLE].DefaultView[i][ImageInfoAcs.COL_IMAGEINFOCODE_TITLE].ToString());
                if (imageInfoCode == dsImageInfoCode)
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this._imageInfoAcs.BindDataSet.Tables[ImageInfoAcs.TBL_IMAGEINFO_TITLE].DefaultView[i][ImageInfoAcs.COL_DELETEDATE_TITLE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          CT_PGID,						        // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの画像設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 画像情報コードのクリア
                        ImageInfoCode_tNedit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        CT_PGID,                                // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードの画像設定情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // 画像情報コードのクリア
                                ImageInfoCode_tNedit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.25 30413 犬飼 新規モードからモード変更対応 <<<<<<END
    }
}