//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 得意先マスタ(変動情報)
// プログラム概要   : 得意先(変動情報)の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 作 成 日  2008/09/16  修正内容 : 得意先コードの表示桁制御(コントロール名をXMLに合わせ修正)
//                                : 画面名を"得意先マスタ(変動情報)"に変更 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30462 行澤 仁美
// 修 正 日  2008/10/06  修正内容 : バグ修正、画面レイアウト変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30307 照田 貴志
// 修 正 日  2008/11/20  修正内容 : 子の得意先で「与信管理：する」の場合は設定可とする
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30307 照田 貴志
// 修 正 日  2008/12/03  修正内容 : バグ修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30307 照田 貴志
// 修 正 日  2008/12/10  修正内容 : マウスで登録時、得意先の論理削除チェックが行われないバグ修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30307 照田 貴志
// 修 正 日  2008/12/25  修正内容 : 子の得意先は登録、更新不可とする(11/20の修正は間違い)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30307 照田 貴志
// 修 正 日  2009/01/23  修正内容 : 不具合対応[9199]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 修 正 日  2009/02/10  修正内容 : 不具合対応[11288] 与信額>0の場合のみ、与信額と警告与信額のチェックを行う
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/04/13  修正内容 : Mantis【13175】与信額=0の場合もエラーチェックを行うように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/04/14  修正内容 : Mantis【13175】上記の修正を2009/02/10時点のチェックに戻す
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
	/// 得意先マスタ(変動情報)フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 得意先マスタ(変動情報)の設定を行います。</br>
	/// <br>Programmer : 20081 疋田 勇人</br>
	/// <br>Date       : 2007.09.18</br>
    /// <br>Update Note: 2008.09.16 30452 上野 俊治</br>
    /// <br>             ・得意先コードの表示桁制御(コントロール名をXMLに合わせ修正)</br>
    /// <br>             ・画面名を"得意先マスタ(変動情報)"に変更</br>
    /// <br>UpdateNote : 2008/10/06 30462 行澤 仁美　バグ修正、画面レイアウト変更</br>
    /// <br>           : 2008/11/20       照田 貴志　子の得意先で「与信管理：する」の場合は設定可とする</br>
    /// <br>           : 2008/12/03       照田 貴志　バグ修正</br>
    /// <br>           : 2008/12/10       照田 貴志　マウスで登録時、得意先の論理削除チェックが行われないバグ修正</br>
    /// <br>           : 2008/12/25       照田 貴志　子の得意先は登録、更新不可とする(11/20の修正は間違い)</br>
    /// <br>           : 2009/01/23       照田 貴志　不具合対応[9199]</br>
    /// <br>           : 2009/02/10       上野 俊治　不具合対応[11288] 与信額>0の場合のみ、与信額と警告与信額のチェックを行う</br>
    /// </remarks>
	public partial class DCKHN09140UA : Form, IMasterMaintenanceMultiType
	{
		// --------------------------------------------------
		#region Constructor

		/// <summary>
        /// 得意先マスタ(変動情報)フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 得意先マスタ(変動情報)フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
		public DCKHN09140UA()
		{
			InitializeComponent();

			// プロパティ初期値
			this._canClose = false;                          // 閉じる機能(false固定)
            this._canDelete = true;                          // 削除機能
			this._canLogicalDeleteDataExtraction = true;     // 論理削除データ表示機能
            this._canNew = true;                             // 新規作成機能
			this._canPrint = false;                          // 印刷機能
			this._canSpecificationSearch = false;            // 件数指定検索機能
			this._defaultAutoFillToColumn = true;            // 列サイズ自動調整機能

            this.uButton_CustomerGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

			// 企業コード取得
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// インスタンス初期化
            this._customerChangeAcs = new CustomerChangeAcs();

            this._customerInfoAcs = new CustomerInfoAcs();

			// グリッド選択インデックス
			this._dataIndex                      = -1;
			this._indexBuf                       = -2;
		}

		#endregion

		// --------------------------------------------------
		#region Private Members

        private string _enterpriseCode = "";           // 企業コード

        private CustomerChangeAcs _customerChangeAcs = null;

        private CustomerInfoAcs _customerInfoAcs = null;

		// メイン用クローンオブジェクト
        private CustomerChange _customerChangeClone = null;

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

        // 2009.03.30 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
        // 2009.03.30 30413 犬飼 新規モードからモード変更対応 <<<<<<END

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
        private const int               BUTTON_LOCATION1_X  = 3;        // 完全削除ボタン位置X
        private const int               BUTTON_LOCATION2_X  = 130;      // 復活ボタン位置X
        private const int               BUTTON_LOCATION3_X  = 257;      // 保存ボタン位置X
        private const int               BUTTON_LOCATION4_X  = 384;      // 閉じるボタン位置X
        private const int               BUTTON_LOCATION_Y   = 9;        // ボタン位置Y(共通)

		// PG情報
		private const string            CT_PGID        = "DCKHN09140U";
		private const string            CT_PGNAME      = "得意先マスタ(変動情報)";
		private const string            CT_CLASSNAME   = "DCKHN09140UA";

        // Message関連定義
        private const string            ERR_READ_MSG   = "読み込みに失敗しました。";
        private const string            ERR_DPR_MSG    = "このコードは既に使用されています。";
        private const string            ERR_RDEL_MSG   = "削除に失敗しました。";
        private const string            ERR_UPDT_MSG   = "登録に失敗しました。";
        private const string            ERR_RVV_MSG    = "復活に失敗しました。";
        private const string            ERR_800_MSG    = "既に他端末より更新されています。";
        private const string            ERR_801_MSG    = "既に他端末より削除されています。";
        private const string            SDC_RDEL_MSG   = "マスタから削除されています。";

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
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
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
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
		public void GetBindDataSet( ref DataSet bindDataSet, ref string tableName )
		{
			bindDataSet	= this._customerChangeAcs.BindDataSet;
            tableName = CustomerChangeAcs.TBL_CUSTOMERCHANGE_TITLE;
		}
        
		/// <summary>
		/// グリッド列外観情報取得処理
		/// </summary>
		/// <returns>グリッド列外観情報格納Hashtable</returns>
		/// <remarks>
        /// <br>Note       : グリッドの各列の外観を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

			// 削除日
            appearanceTable.Add(CustomerChangeAcs.COL_DELETEDATE_TITLE, 
                new GridColAppearance( MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red ) );
            // 得意先コード
            //appearanceTable.Add(CustomerChangeAcs.COL_CUSTOMERCODE_TITLE,
            //    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black)); // DEL 2008/10/06
            appearanceTable.Add(CustomerChangeAcs.COL_CUSTOMERCODE_TITLE,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "00000000", Color.Black)); // ADD 2008/10/06
            // 得意先名称
            appearanceTable.Add(CustomerChangeAcs.COL_CUSTOMERSNM_TITLE, 
				new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black ) );
            // 与信額
            // DEL 2008/10/06 不具合対応[6231]↓
            //appearanceTable.Add(CustomerChangeAcs.COL_CREDITMONEY_TITLE,
            //    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ---ADD 2008/10/06 不具合対応[6231] ------------------------------------------->>>>>
            appearanceTable.Add(CustomerChangeAcs.COL_CREDITMONEY_TITLE,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#,##0", Color.Black));
            // ---ADD 2008/10/06 不具合対応[6231] -------------------------------------------<<<<<
            
            // 警告与信額
            // DEL 2008/10/06 不具合対応[6231]↓
            //appearanceTable.Add(CustomerChangeAcs.COL_WARNINGCREDITMONEY_TITLE,
            //    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ---ADD 2008/10/06 不具合対応[6231] ------------------------------------------->>>>>
            appearanceTable.Add(CustomerChangeAcs.COL_WARNINGCREDITMONEY_TITLE,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#,##0", Color.Black));
            // ---ADD 2008/10/06 不具合対応[6231] -------------------------------------------<<<<<
            // 現在売掛残高
            // DEL 2008/10/06 不具合対応[6231]↓
            //appearanceTable.Add(CustomerChangeAcs.COL_PRSNTACCRECBALANCE_TITLE,
            //    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ---ADD 2008/10/06 不具合対応[6231] ------------------------------------------->>>>>
            appearanceTable.Add(CustomerChangeAcs.COL_PRSNTACCRECBALANCE_TITLE,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#,##0", Color.Black));
            // ---ADD 2008/10/06 不具合対応[6231] -------------------------------------------<<<<<

            //--- DEL 2008/06/26 ---------->>>>>
            //// 現在得意先伝票番号
            //appearanceTable.Add(CustomerChangeAcs.COL_PRESENTCUSTSLIPNO_TITLE,
            //    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //// 開始得意先伝票番号
            //appearanceTable.Add(CustomerChangeAcs.COL_STARTCUSTSLIPNO_TITLE,
            //    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //// 終了得意先伝票番号
            //appearanceTable.Add(CustomerChangeAcs.COL_ENDCUSTSLIPNO_TITLE,
            //    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //// 番号桁数
            //appearanceTable.Add(CustomerChangeAcs.COL_NOCHARCTERCOUNT_TITLE,
            //    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //--- DEL 2008/06/26 ----------<<<<<
            // 得意先伝票番号ヘッダ
            appearanceTable.Add(CustomerChangeAcs.COL_CUSTSLIPNOHEADER_TITLE,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 得意先伝票番号フッタ
            appearanceTable.Add(CustomerChangeAcs.COL_CUSTSLIPNOFOOTER_TITLE,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            
            // GUID
            appearanceTable.Add(CustomerChangeAcs.COL_GUID_TITLE, 
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
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
		public int Search( ref int totalCount, int readCount )
		{
            // 情報取得処理
            return this.SearchProc(ref totalCount, readCount);
		}

		/// <summary>
		/// Nextデータ検索処理
		/// </summary>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : Nextデータの検索処理を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
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
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private int SearchProc(ref int totalCount, int readCount)
		{
            const string ctPROCNM = "SearchProc";
			int status = ( int )ConstantManagement.DB_Status.ctDB_EOF;

			totalCount = 0;
			
			// 検索実行
			status = this._customerChangeAcs.SearchAll( out totalCount, this._enterpriseCode );
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
						this._customerChangeAcs,            // エラーが発生したオブジェクト
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
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
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
            CustomerChange customerChange = new CustomerChange();
            this.DispToCustomerChange(ref customerChange);

			// 書き込み処理
			int status = 0;
			status = this._customerChangeAcs.Write( customerChange );

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

                    this.tNedit_CustomerCode.Focus();
                    this.tNedit_CustomerCode.SelectAll();

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
						this._customerChangeAcs,            // エラーが発生したオブジェクト
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
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
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
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private int LogicalDeleteProc()
        {
            const string ctPROCNM = "LogicalDeleteProc";
            int status = 0;

            DataTable dt = this._customerChangeAcs.BindDataSet.Tables[CustomerChangeAcs.TBL_CUSTOMERCHANGE_TITLE];

            // グリッドが選択されていない時
            if ((this._dataIndex < 0) ||
                (this._dataIndex >= dt.Rows.Count))
            {
                return status;
            }

            // 選択データ取得
            Guid fileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][CustomerChangeAcs.COL_GUID_TITLE]; // GUID

            // --- ADD 2008/10/16 -------------------------------------------------------------------->>>>>
            // 得意先マスタ与信管理チェック
            int creditMngCode;
            if (this._customerChangeAcs.GetCreditMngCode(fileHeaderGuid, out creditMngCode) == false)
            {
                TMsgDisp.Show(this,
                            emErrorLevel.ERR_LEVEL_STOPDISP,
                            this.Name,
                            "得意先情報の取得に失敗しました。",
                            status,
                            MessageBoxButtons.OK);
                return -1;
            }
            if (creditMngCode == 1)
            {
                TMsgDisp.Show(this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            CT_PGID,
                            //"与信管理されている得意先なので削除できません。。",
                            "与信管理されている得意先なので削除できません。",
                            0,
                            MessageBoxButtons.OK);
                return -1;
            }
            // --- ADD 2008/10/16 --------------------------------------------------------------------<<<<<

            // 論理削除実行
            status = this._customerChangeAcs.LogicalDelete(fileHeaderGuid);

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
                            this._customerChangeAcs,            // エラーが発生したオブジェクト
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
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private int RevivalProc()
		{
			const string ctPROCNM = "RevivalProc";
			int status = 0;

            DataTable dt = this._customerChangeAcs.BindDataSet.Tables[CustomerChangeAcs.TBL_CUSTOMERCHANGE_TITLE];

			// グリッドが選択されていない時
			if( ( this._indexBuf < 0 ) || 
				( this._indexBuf >= dt.Rows.Count ) ) {
				this.CloseForm( DialogResult.Cancel );
				return -1;
			}

            // 選択データ取得
            Guid fileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][CustomerChangeAcs.COL_GUID_TITLE]; // GUID

			// 論理削除復活実行
            status = this._customerChangeAcs.Revival(fileHeaderGuid);

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
						this._customerChangeAcs,            // エラーが発生したオブジェクト
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
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private int PhysicalDeleteProc()
		{
			const string ctPROCNM = "PhysicalDeleteProc";
			int status = 0;

            DataTable dt = this._customerChangeAcs.BindDataSet.Tables[CustomerChangeAcs.TBL_CUSTOMERCHANGE_TITLE];

			// グリッドが選択されていない時
			if( ( this._indexBuf < 0 ) || 
				( this._indexBuf >= dt.Rows.Count ) ) {
				this.CloseForm( DialogResult.Cancel );
				return -1;
            }

            // 選択データ取得
            Guid fileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][CustomerChangeAcs.COL_GUID_TITLE]; // GUID

			// 物理削除実行
            status = this._customerChangeAcs.Delete(fileHeaderGuid);

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
						this._customerChangeAcs,            // エラーが発生したオブジェクト
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
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
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
        /// マスタ情報画面展開処理
        /// </summary>
        /// <param name="customerChange">得意先マスタ(変動情報)オブジェクト</param>
		/// <remarks>
        /// <br>Note       : マスタ情報を画面に展開します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private void CustomerChangeToScreen(CustomerChange customerChange)
        {
            // 新規モードの場合
            if (this._editingMode == CT_EMODE_INSERT)
            {
                this.tNedit_CustomerCode.Clear();        // 得意先コード
                this.uLabel_CustomerName.Text = "";      // 得意先名称
            }
            // 新規モード以外の場合
            else
            {
                // --- DEL 2008/09/16 -------------------------------->>>>>
                //this.tNedit_CustomerCode.Text = customerChange.CustomerCode.ToString(); 
                // --- DEL 2008/09/16 --------------------------------<<<<<
                // --- ADD 2008/09/16 -------------------------------->>>>>
                this.tNedit_CustomerCode.SetInt(customerChange.CustomerCode); // 得意先コード
                // --- ADD 2008/09/16 --------------------------------<<<<<
                //this.uLabel_CustomerName.Text = customerChange.CustomerSnm;                              // 得意先略称  // DEL 2008/06/23
                this.uLabel_CustomerName.Text = GetCustomerName(customerChange.CustomerCode);              // 得意先略称  // ADD 2008/06/23
            }
            this.CreditMoney_tNedit.Text = customerChange.CreditMoney.ToString("#,##0");                   // 与信額
            this.WarningCreditMoney_tNedit.Text = customerChange.WarningCreditMoney.ToString("#,##0");     // 警告与信額
            this.PrsntAccRecBalance_tNedit.Text = customerChange.PrsntAccRecBalance.ToString("#,##0");     // 現在売掛残高
            //--- DEL 2008/06/23 ---------->>>>>
            //this.PresentCustSlipNo_tN.Text = customerChange.PresentCustSlipNo.ToString();                // 現在得意先伝票番号
            //this.StartCustSlipNo_tN.Text = customerChange.StartCustSlipNo.ToString();                    // 開始得意先伝票番号
            //this.EndCustSlipNo_tN.Text = customerChange.EndCustSlipNo.ToString();                        // 終了得意先伝票番号
            //this.NoCharcterCount_tNedit.Text = customerChange.NoCharcterCount.ToString();                // 番号桁数
            //this.CustSlipNoHeader_tEdit.Text = customerChange.CustSlipNoHeader;                          // 得意先伝票番号ヘッダ
            //this.CustSlipNoFooter_tEdit.Text = customerChange.CustSlipNoFooter;                          // 得意先伝票番号フッタ
            //--- DEL 2008/06/23 ----------<<<<<
        }
        
		/// <summary>
		/// 画面データ取得処理
		/// </summary>
        /// <param name="customerChange">得意先マスタ(変動情報)オブジェクト</param>
		/// <remarks>
        /// <br>Note       : 画面データの取得を行います</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private void DispToCustomerChange(ref CustomerChange customerChange)
        {
            // 更新モードの場合
            if (this._editingMode == CT_EMODE_UPDATE)
            {
                // Guid
                DataTable dt = this._customerChangeAcs.BindDataSet.Tables[CustomerChangeAcs.TBL_CUSTOMERCHANGE_TITLE];
                customerChange.FileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][CustomerChangeAcs.COL_GUID_TITLE];
            }

            // 企業コード
            customerChange.EnterpriseCode = this._enterpriseCode;
            // 得意先コード
            customerChange.CustomerCode = this.tNedit_CustomerCode.GetInt();
            // 得意先名称
            //customerChange.CustomerSnm = this.uLabel_CustomerName.Text;       // DEL 2008/06/23
            // 与信額
            customerChange.CreditMoney = this.CreditMoney_tNedit.GetInt();
            // 警告与信額
            customerChange.WarningCreditMoney = this.WarningCreditMoney_tNedit.GetInt();
            // 現在売掛残高
            customerChange.PrsntAccRecBalance = this.PrsntAccRecBalance_tNedit.GetInt();
            //--- DEL 2008/06/23 ---------->>>>>
            //// 現在得意先伝票番号
            //customerChange.PresentCustSlipNo = this.PresentCustSlipNo_tN.GetInt();
            //// 開始得意先伝票番号
            //customerChange.StartCustSlipNo = this.StartCustSlipNo_tN.GetInt();
            //// 終了得意先伝票番号
            //customerChange.EndCustSlipNo = this.EndCustSlipNo_tN.GetInt();
            //// 番号桁数
            //customerChange.NoCharcterCount = this.NoCharcterCount_tNedit.GetInt();
            //// 得意先伝票番号ヘッダ
            //customerChange.CustSlipNoHeader = this.CustSlipNoHeader_tEdit.Text;
            //// 得意先伝票番号フッタ
            //customerChange.CustSlipNoFooter = this.CustSlipNoFooter_tEdit.Text;
            //--- DEL 2008/06/23 ----------<<<<<
        }

        #endregion

        // --------------------------------------------------
        #region Screen Methods
        
		/// <summary>
		/// 画面クリア処理
		/// </summary>
		/// <remarks>
        /// <br>Note       : 画面のクリアを行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void ScreenClear()
        {
            this.tNedit_CustomerCode.Clear();                     // 得意先
            //this.CustSlipNoFooter_tEdit.Clear();                 // 帳票ID        // DEL 2008/06/23
        }
        
        /// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
        /// <br>Note       : 画面の再構築処理を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void ScreenReconstruction()
        {
            CustomerChange customerChange = new CustomerChange();

			// 新規の時
            if (this._dataIndex < 0)
            {
                // 新規モードに設定
                this._editingMode = CT_EMODE_INSERT;
                this.Mode_Label.Text = INSERT_MODE;

                // 画面に展開
                this.CustomerChangeToScreen(customerChange);

                // クローン作成
                this._customerChangeClone = new CustomerChange();
                this.DispToCustomerChange(ref this._customerChangeClone);

                // 画面入力許可制御設定
                this.ScreenInputPermissionControl(this._editingMode);

                //--- ADD 2008/06/24 ---------->>>>>
                this.Enabled = true;        

                this.tNedit_CustomerCode.Focus();
                this.tNedit_CustomerCode.SelectAll();
                //--- ADD 2008/06/24 ----------<<<<<
            }
            else
            {
                // フレームで選択されているレコードのオブジェクトを取得
                DataRowView dr = this._customerChangeAcs.BindDataSet.Tables[CustomerChangeAcs.TBL_CUSTOMERCHANGE_TITLE].DefaultView[this._dataIndex];

                if ((string)dr[CustomerChangeAcs.COL_DELETEDATE_TITLE] != "") // 削除日
                {
                    customerChange.LogicalDeleteCode = 1;
                }

                customerChange.CustomerCode = (Int32)dr[CustomerChangeAcs.COL_CUSTOMERCODE_TITLE];    　　　　　 // 得意先コード
                //customerChange.CustomerSnm = (string)dr[CustomerChangeAcs.COL_CUSTOMERSNM_TITLE];   　　　　　 // 得意先略称        // DEL 2008/06/23
                customerChange.CreditMoney = (long)dr[CustomerChangeAcs.COL_CREDITMONEY_TITLE];     　　　　　　 // 与信額
                customerChange.WarningCreditMoney = (long)dr[CustomerChangeAcs.COL_WARNINGCREDITMONEY_TITLE];    // 警告与信額
                customerChange.PrsntAccRecBalance = (long)dr[CustomerChangeAcs.COL_PRSNTACCRECBALANCE_TITLE];    // 現在売掛残高
                //--- DEL 2008/06/24 ---------->>>>>
                //customerChange.PresentCustSlipNo = (long)dr[CustomerChangeAcs.COL_PRESENTCUSTSLIPNO_TITLE];      // 現在得意先伝票番号
                //customerChange.StartCustSlipNo = (long)dr[CustomerChangeAcs.COL_STARTCUSTSLIPNO_TITLE];          // 開始得意先伝票番号
                //customerChange.EndCustSlipNo = (long)dr[CustomerChangeAcs.COL_ENDCUSTSLIPNO_TITLE];              // 終了得意先伝票番号
                //customerChange.NoCharcterCount = (Int32)dr[CustomerChangeAcs.COL_NOCHARCTERCOUNT_TITLE];         // 番号桁数
                //customerChange.CustSlipNoHeader = (string)dr[CustomerChangeAcs.COL_CUSTSLIPNOHEADER_TITLE];      // 得意先伝票番号ヘッダ
                //customerChange.CustSlipNoFooter = (string)dr[CustomerChangeAcs.COL_CUSTSLIPNOFOOTER_TITLE];      // 得意先伝票番号フッタ
                //--- DEL 2008/06/24 ----------<<<<<

                // 更新モード
                if (customerChange.LogicalDeleteCode == 0)
                {
                    // 更新モードに設定
                    this._editingMode = CT_EMODE_UPDATE;
                    this.Mode_Label.Text = UPDATE_MODE;

                    CustomerInfo customerInfo;
                    int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, customerChange.CustomerCode, true, out customerInfo);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 親かを判定し、子の場合は与信額・警告与信額・現在売掛残高は入力不可
                        if (customerInfo.ClaimCode != customerChange.CustomerCode)
                        {
                            /* --- DEL 2008/12/25 不具合対応[9454] ---------------------------->>>>>
                            // 子の場合、与信管理「しない」時のみ入力不可
                            if (customerInfo.CreditMngCode == 0)                    //ADD 2008/11/20
                            {                                                       //ADD 2008/11/20
                                this.CreditMoney_tNedit.Enabled = false;
                                this.WarningCreditMoney_tNedit.Enabled = false;
                                this.PrsntAccRecBalance_tNedit.Enabled = false;
                            }                                                       //ADD 2008/11/20
                            else                                                    //ADD 2008/11/20
                            {                                                       //ADD 2008/11/20
                                this.CreditMoney_tNedit.Enabled = true;             //ADD 2008/11/20
                                this.WarningCreditMoney_tNedit.Enabled = true;      //ADD 2008/11/20
                                this.PrsntAccRecBalance_tNedit.Enabled = true;      //ADD 2008/11/20
                            }                                                       //ADD 2008/11/20
                               --- DEL 2008/12/25 ---------------------------------------------<<<<< */
                            // --- ADD 2008/12/25 --------------------------------------------->>>>>
                            this.CreditMoney_tNedit.Enabled = false;
                            this.WarningCreditMoney_tNedit.Enabled = false;
                            this.PrsntAccRecBalance_tNedit.Enabled = false;
                            // --- ADD 2008/12/25 ---------------------------------------------<<<<<
                        }
                        else
                        {
                            this.CreditMoney_tNedit.Enabled = true;
                            this.WarningCreditMoney_tNedit.Enabled = true;
                            this.PrsntAccRecBalance_tNedit.Enabled = true;
                        }
                    }
                }
                // 削除モード
                else
                {
                    // 削除モードに設定
                    this._editingMode = CT_EMODE_DELETE;
                    this.Mode_Label.Text = DELETE_MODE;
                }

                // 画面に展開
                this.CustomerChangeToScreen(customerChange);

                // クローン作成
                this._customerChangeClone = new CustomerChange();
                this.DispToCustomerChange(ref this._customerChangeClone);

                // 画面入力許可制御設定
                this.ScreenInputPermissionControl(this._editingMode);

                //--- ADD 2008/06/24 ---------->>>>>
                this.Enabled = true;        

                if (this._editingMode == CT_EMODE_UPDATE)
                {
                    this.CreditMoney_tNedit.Focus();
                    this.CreditMoney_tNedit.SelectAll();
                }
                else
                {
                    this.Delete_Button.Focus();
                }
                //--- ADD 2008/06/24 ----------<<<<<
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
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void ScreenInputPermissionControl( int editingMode )
		{
			switch( editingMode ) {
				// 新規モード
				case CT_EMODE_INSERT:
				{
					// 表示設定
					this.Delete_Button.Visible                  = false;    // 完全削除ボタン
					this.Revive_Button.Visible                  = false;    // 復活ボタン
					this.Ok_Button.Visible                      = true;     // 保存ボタン
					this.Cancel_Button.Visible                  = true;     // 閉じるボタン

                    // 入力許可設定
                    // 得意先コード
                    this.tNedit_CustomerCode.Enabled = true;
                    // 得意先ガイドボタン
                    this.uButton_CustomerGuide.Enabled = true;       
                    // 与信額
                    this.CreditMoney_tNedit.Enabled = true;
                    // 警告与信額
                    this.WarningCreditMoney_tNedit.Enabled = true;
                    // 現在売掛残高
                    this.PrsntAccRecBalance_tNedit.Enabled = true;
                    //--- DEL 2008/06/23 ---------->>>>>
                    //// 現在得意先伝票番号
                    //this.PresentCustSlipNo_tN.Enabled = true;
                    //// 開始得意先伝票番号
                    //this.StartCustSlipNo_tN.Enabled = true;
                    //// 終了得意先伝票番号
                    //this.EndCustSlipNo_tN.Enabled = true;
                    //// 番号桁数
                    //this.NoCharcterCount_tNedit.Enabled = true;
                    //// 得意先伝票番号ヘッダ
                    //this.CustSlipNoHeader_tEdit.Enabled = true;
                    //// 得意先伝票番号フッタ
                    //this.CustSlipNoFooter_tEdit.Enabled = true;
                    //--- DEL 2008/06/23 ----------<<<<<
					
					// 初期フォーカス設定
                    this.tNedit_CustomerCode.Focus();
                    this.tNedit_CustomerCode.SelectAll();
					break;
				}
				// 更新モード
				case CT_EMODE_UPDATE:
				{
					// 表示設定
					this.Delete_Button.Visible                  = false;    // 完全削除ボタン
					this.Revive_Button.Visible                  = false;    // 復活ボタン
					this.Ok_Button.Visible                      = true;     // 保存ボタン
					this.Cancel_Button.Visible                  = true;     // 閉じるボタン

                    // 入力許可設定
                    this.tNedit_CustomerCode.Enabled = false;         // 得意先コード
                    this.uButton_CustomerGuide.Enabled = false;       // 得意先ガイドボタン

                    //--- DEL 2008/06/23 ---------->>>>>
                    //// 現在得意先伝票番号
                    //this.PresentCustSlipNo_tN.Enabled = true;
                    //// 開始得意先伝票番号
                    //this.StartCustSlipNo_tN.Enabled = true;
                    //// 終了得意先伝票番号
                    //this.EndCustSlipNo_tN.Enabled = true;
                    //// 番号桁数
                    //this.NoCharcterCount_tNedit.Enabled = true;
                    //// 得意先伝票番号ヘッダ
                    //this.CustSlipNoHeader_tEdit.Enabled = true;
                    //// 得意先伝票番号フッタ
                    //this.CustSlipNoFooter_tEdit.Enabled = true;
                    //--- DEL 2008/06/23 ----------<<<<<
                    
  					// 初期フォーカス設定
                    this.CreditMoney_tNedit.Focus();
                    //this.CustSlipNoFooter_tEdit.SelectAll();      // DEL 2008/06/23
					break;
				}
				// 削除モード
				case CT_EMODE_DELETE:
				{
					// 表示設定
					this.Ok_Button.Visible                      = false;    // 保存ボタン
					this.Cancel_Button.Visible                  = true;     // 閉じるボタン
                    
                    this.Delete_Button.Visible                  = true;     // 完全削除ボタン
                    this.Revive_Button.Visible                  = true;     // 復活ボタン
                    this.Delete_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // 完全削除ボタン位置シフト
                    this.Revive_Button.Location = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // 復活ボタン位置シフト

                    // 入力許可設定
                    // 得意先コード
                    this.tNedit_CustomerCode.Enabled = false;         
                    // 得意先ガイドボタン
                    this.uButton_CustomerGuide.Enabled = false;
                    // 与信額
                    this.CreditMoney_tNedit.Enabled = false;
                    // 警告与信額
                    this.WarningCreditMoney_tNedit.Enabled = false;
                    // 現在売掛残高
                    this.PrsntAccRecBalance_tNedit.Enabled = false;
                    //--- DEL 2008/06/23 ---------->>>>>
                    //// 現在得意先伝票番号
                    //this.PresentCustSlipNo_tN.Enabled = false;
                    //// 開始得意先伝票番号
                    //this.StartCustSlipNo_tN.Enabled = false;
                    //// 終了得意先伝票番号
                    //this.EndCustSlipNo_tN.Enabled = false;
                    //// 番号桁数
                    //this.NoCharcterCount_tNedit.Enabled = false;
                    //// 得意先伝票番号ヘッダ
                    //this.CustSlipNoHeader_tEdit.Enabled = false;
                    //this.CustSlipNoFooter_tEdit.Enabled = false;      // フッタ
                    //--- DEL 2008/06/23 ----------<<<<<
                    

					// 初期フォーカス設定
					this.Delete_Button.Focus();
					break;
				}
				// 参照モード
				case CT_EMODE_REFER:
				{
					// 表示設定
					this.Ok_Button.Visible                      = false;    // 保存ボタン
					this.Cancel_Button.Visible                  = true;     // 閉じるボタン
					this.Revive_Button.Visible                  = false;    // 復活ボタン
					this.Delete_Button.Visible                  = false;    // 完全削除ボタン

					// 入力許可設定
                    // 得意先コード
                    this.tNedit_CustomerCode.Enabled = false;         
                    // 得意先ガイドボタン
                    this.uButton_CustomerGuide.Enabled = false;
                    // 与信額
                    this.CreditMoney_tNedit.Enabled = false;
                    // 警告与信額
                    this.WarningCreditMoney_tNedit.Enabled = false;
                    // 現在売掛残高
                    this.PrsntAccRecBalance_tNedit.Enabled = false;
                    //--- DEL 2008/06/23 ---------->>>>>
                    //// 現在得意先伝票番号
                    //this.PresentCustSlipNo_tN.Enabled = false;
                    //// 開始得意先伝票番号
                    //this.StartCustSlipNo_tN.Enabled = false;
                    //// 終了得意先伝票番号
                    //this.EndCustSlipNo_tN.Enabled = false;
                    //// 番号桁数
                    //this.NoCharcterCount_tNedit.Enabled = false;
                    //// 得意先伝票番号ヘッダ
                    //this.CustSlipNoHeader_tEdit.Enabled = false;
                    //this.CustSlipNoFooter_tEdit.Enabled = false;      // フッタ
                    //--- DEL 2008/06/23 ----------<<<<<
                    
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
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
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
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
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
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private bool ScreenDataCheck( ref Control control, ref string message )
		{
			bool result = true;

            // 得意先コード
            //if (this.tNedit_CustomerCode.Text.Trim() == "") {                                             //DEL 2008/12/03 文字をペーストするとOKとなり、0で登録される為
            if ((this.tNedit_CustomerCode.Text.Trim() == "") || (this.tNedit_CustomerCode.GetInt() == 0))
            {  //ADD 2008/12/03
                message = this.CustomerCode_Title_Label.Text + "を入力してください。";
                control = this.tNedit_CustomerCode;
                this.tNedit_CustomerCode.Clear();                                                           //ADD 2008/12/03
                result = false;
            }
            //--- ADD 2008/12/10 不具合対応[8901] マウスで登録クリック時、得意先コード論理削除チェックが行われない為----->>>>>
            else
            {
                // 得意先コード論理削除チェック
                CustomerSearchPara customerSearchPara = new CustomerSearchPara();
                customerSearchPara.EnterpriseCode = this._enterpriseCode;
                customerSearchPara.CustomerCode = this.tNedit_CustomerCode.GetInt();
                int logicalDeleteCode = this._customerChangeAcs.GetCustomerLogicalDelete(customerSearchPara);                 //DEL 2008/12/25 不具合対応[9454]
                if (logicalDeleteCode != 0)                                                                                   //DEL 2008/12/25
                {
                    message = "指定した得意先コードは存在しません。";
                    control = this.tNedit_CustomerCode;
                    this.tNedit_CustomerCode.Clear();
                    result = false;
                }
                // --- ADD 2008/12/25 不具合対応[9454] ---------------------------------------->>>>>
                else
                {
                    CustomerInfo customerInfo;
                    int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, tNedit_CustomerCode.GetInt(), true, out customerInfo);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 親かどうかを判定
                        if (customerInfo.ClaimCode != tNedit_CustomerCode.GetInt())
                        {
                            message = "親の得意先を設定して下さい。";

                            control = this.tNedit_CustomerCode;
                            this.tNedit_CustomerCode.Clear();
                            this.uLabel_CustomerName.Text = string.Empty;
                            return false;
                        }
                        // ---ADD 2009/01/23 不具合対応[9199] ----------------------------------------------------->>>>>
                        if (customerInfo.CreditMngCode == 0)
                        {
                            message = "指定した得意先は与信管理が設定されていません。";

                            control = this.tNedit_CustomerCode;
                            this.tNedit_CustomerCode.Clear();
                            this.uLabel_CustomerName.Text = string.Empty;
                            return false;
                        }
                        // ---ADD 2009/01/23 不具合対応[9199] -----------------------------------------------------<<<<<
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        message = "指定した得意先コードは存在しません。";

                        control = this.tNedit_CustomerCode;
                        this.tNedit_CustomerCode.Clear();
                        this.uLabel_CustomerName.Text = string.Empty;
                        return false;
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                    {
                        message = "指定した得意先コードは既に削除されています。";

                        control = this.tNedit_CustomerCode;
                        this.tNedit_CustomerCode.Clear();
                        this.uLabel_CustomerName.Text = string.Empty;
                        return false;
                    }

                }
                // --- ADD 2008/12/25 不具合対応[9454] ----------------------------------------<<<<<
            }
            //--- ADD 2008/12/10 不具合対応[8901] -----------------------------------------------------------------------<<<<<

            // 与信額＜与信警告額はエラーにする
            //if ((this.CreditMoney_tNedit.GetInt() < this.WarningCreditMoney_tNedit.GetInt()) && (this.CreditMoney_tNedit.GetInt() != this.WarningCreditMoney_tNedit.GetInt())) // DEL 2009/02/10
            // DEL 2009/04/13 ------>>>
            //if ((this.CreditMoney_tNedit.GetInt() > 0)
            //    && (this.CreditMoney_tNedit.GetInt() < this.WarningCreditMoney_tNedit.GetInt())
            //    && (this.CreditMoney_tNedit.GetInt() != this.WarningCreditMoney_tNedit.GetInt())) // ADD 2009/02/10
            // DEL 2009/04/13 ------<<<
            // DEL 2009/04/14 ------>>>
            //// 与信額＜与信警告額はエラーにする(与信額ゼロを対象に修正)
            //if (this.CreditMoney_tNedit.GetInt() < this.WarningCreditMoney_tNedit.GetInt())     // ADD 2009/04/13             
            // DEL 2009/04/14 ------<<<
            // 2009/02/10のチェックに戻す
            if ((this.CreditMoney_tNedit.GetInt() > 0)
                && (this.CreditMoney_tNedit.GetInt() < this.WarningCreditMoney_tNedit.GetInt())
                && (this.CreditMoney_tNedit.GetInt() != this.WarningCreditMoney_tNedit.GetInt())) // ADD 2009/04/14
            {
                message = "与信警告額が与信額を越えています。";
                control = this.CreditMoney_tNedit;
				result  = false;
            }
            //--- DEL 2008/06/23 ---------->>>>>
            //// 番号桁数
            //if (this.NoCharcterCount_tNedit.GetInt() > 19)
            //{
            //    message = this.ultraLabel2.Text + "は19までの入力にしてください。";
            //    control = this.NoCharcterCount_tNedit;
            //    result = false;
            //}
            //// 現在得意伝票番号
            //if ((this.StartCustSlipNo_tN.GetInt() <= this.PresentCustSlipNo_tN.GetInt()) && (this.PresentCustSlipNo_tN.GetInt() <= this.EndCustSlipNo_tN.GetInt()))
            //{
            //    // OK
            //}
            //else
            //{
            //    message = this.ultraLabel5.Text + "を範囲内で入力してください。";
            //    control = this.PresentCustSlipNo_tN;
            //    result = false;
            //}

            //// 番号桁数が０の場合は不要項目はクリアし、桁数のチェックを行わない
            //if (this.NoCharcterCount_tNedit.GetInt() == 0)
            //{
            //    this.PresentCustSlipNo_tN.Clear();
            //    this.StartCustSlipNo_tN.Clear();
            //    this.EndCustSlipNo_tN.Clear();
            //    this.CustSlipNoHeader_tEdit.Clear();
            //    this.CustSlipNoFooter_tEdit.Clear();
            //    return result;
            //}

            //string endSlipNo = this.EndCustSlipNo_tN.GetInt().ToString();
            //string slipNoHeader = this.CustSlipNoHeader_tEdit.Text.Trim();
            //string slipNoFooter = this.CustSlipNoFooter_tEdit.Text.Trim();

            //int endSlipNoCount = endSlipNo.Length;
            //int slipNoHeaderCount = slipNoHeader.Length;
            //int slipNoFooterCount = slipNoFooter.Length;
            //int noCharcterCount = this.NoCharcterCount_tNedit.GetInt();

            //// 番号桁数≧（終了番号桁数＋ヘッダー桁数＋フッター桁数）であること　番号桁数はMAX19桁
            //if (noCharcterCount >= endSlipNoCount + slipNoHeaderCount + slipNoFooterCount)
            //{
            //    // 何もしない
            //}
            //else
            //{
            //    message = "終了番号桁数＋ヘッダー桁数＋フッター桁数は番号桁数範囲内で入力してください。";
            //    control = this.EndCustSlipNo_tN;
            //    result = false;
            //}
            //--- DEL 2008/06/23 ----------<<<<<

            return result;
		}

        #endregion

        // --------------------------------------------------
		#region Control Events

		/// <summary>
        /// Form.Load イベント (DCKHN09140UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
        /// <br>Note       : ユーザーがフォームを読み込む時に発生します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private void DCKHN09140UA_Load(object sender, EventArgs e)
        {
            ImageList imageList24 = IconResourceManagement.ImageList24;

            this.Ok_Button.ImageList = imageList24;    // 保存ボタン
            this.Cancel_Button.ImageList = imageList24;    // 閉じるボタン
            this.Revive_Button.ImageList = imageList24;    // 復活ボタン
            this.Delete_Button.ImageList = imageList24;    // 完全削除ボタン

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;       // 保存ボタン
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;      // 閉じるボタン
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;    // 復活ボタン
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;     // 完全削除ボタン
        }


		/// <summary>
        /// Form.FormClosing イベント (DCKHN09140UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
        /// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private void DCKHN09140UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // GridIndex保持用バッファ初期化処理
            this._indexBuf = -2;

            if (this._canClose == false)
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = true;
                    this.Hide();
                }
            }
        }

		/// <summary>
        /// Form.VisibleChanged イベント (DCKHN09140UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
        /// <br>Note       : フォームの表示状態が変化した時に発生します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private void DCKHN09140UA_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                this.Owner.Activate();
                return;
            }

            // GridIndexバッファ（メインフレーム最小化対応）
            // ターゲットレコード(Index)が変わっていなかった場合以下の処理をキャンセルする
            if (this._dataIndex == this._indexBuf)
            {
                return;
            }

            this.Enabled = false;           // ADD 2008/06/24

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
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
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
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
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

                CustomerChange newCustomerChange = new CustomerChange();

				// 画面に展開
                this.CustomerChangeToScreen(newCustomerChange);

				// クローン作成
                this._customerChangeClone = new CustomerChange();
				this.DispToCustomerChange( ref this._customerChangeClone );

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
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void Cancel_Button_Click( object sender, EventArgs e )
		{
			// 削除モード・参照モード以外の場合は保存確認処理を行う
			if( ( this._editingMode != CT_EMODE_DELETE ) && 
				( this._editingMode != CT_EMODE_REFER  ) ) {
				// 現在の画面情報を取得する
                CustomerChange compareCustomerChange = this._customerChangeClone.Clone();
                this.DispToCustomerChange(ref compareCustomerChange);

				// 最初に取得した画面と比較
				if( this._customerChangeClone.Equals( compareCustomerChange ) == false ) {
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
                            // 2009.03.30 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                            //this.Cancel_Button.Focus();
                            if (_modeFlg)
                            {
                                tNedit_CustomerCode.Focus();
                                _modeFlg = false;
                            }
                            else
                            {
                                this.Cancel_Button.Focus();
                            }
                            // 2009.03.30 30413 犬飼 新規モードからモード変更対応 <<<<<<END
                                
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
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void Revive_Button_Click( object sender, EventArgs e )
		{
            // --- ADD 2008/12/03 ------------------------------------------------------------------------->>>>>
            DialogResult dialogResult = TMsgDisp.Show(
                                                    this,
                                                    emErrorLevel.ERR_LEVEL_QUESTION,
                                                    this.Name,
                                                    "現在表示中の得意先設定(変動情報)を復活します。" + "\r\n" +
                                                    "よろしいですか？",
                                                    0,
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxDefaultButton.Button2);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }
            // --- ADD 2008/12/03 -------------------------------------------------------------------------<<<<<


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
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
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

		#endregion

		// --------------------------------------------------
		#region RetKeyControl Events

		/// <summary>
		/// リターンキー移動イベント
		/// </summary>
		/// <remarks>
        /// <br>Note		: リターンキー押下時の制御を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void tRetKeyControl1_ChangeFocus( object sender, ChangeFocusEventArgs e )
		{
			if( e.PrevCtrl == null ) {
				return;
			}

            // 2009.03.30 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            _modeFlg = false;
            // 2009.03.30 30413 犬飼 新規モードからモード変更対応 <<<<<<END
            
            switch (e.PrevCtrl.Name)
            {

                case "tNedit_CustomerCode":
                    {
                        if (tNedit_CustomerCode.GetInt() == 0) return;

                        // 2009.03.30 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // 遷移先が閉じるボタン
                            _modeFlg = true;
                            return;
                        }
                        // 2009.03.30 30413 犬飼 新規モードからモード変更対応 <<<<<<END
                           
                        CustomerInfo customerInfo;

                        int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, tNedit_CustomerCode.GetInt(), true, out customerInfo);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // 親かを判定し、子の場合は与信額・警告与信額・現在売掛残高は入力不可
                            if (customerInfo.ClaimCode != tNedit_CustomerCode.GetInt())
                            {
                                /* --- DEL 2008/12/25 不具合対応[9454] ------------------------------>>>>>
                                // 子の場合、与信管理「しない」時のみ入力不可
                                //if (customerInfo.CreditMngCode == 0)                    //ADD 2008/11/20 
                                //{                                                       //ADD 2008/11/20
                                    this.CreditMoney_tNedit.Enabled = false;
                                    this.WarningCreditMoney_tNedit.Enabled = false;
                                    this.PrsntAccRecBalance_tNedit.Enabled = false;
                                //}                                                       //ADD 2008/11/20
                                //else                                                    //ADD 2008/11/20
                                //{                                                       //ADD 2008/11/20
                                //    this.CreditMoney_tNedit.Enabled = true;             //ADD 2008/11/20
                                //    this.WarningCreditMoney_tNedit.Enabled = true;      //ADD 2008/11/20
                                //    this.PrsntAccRecBalance_tNedit.Enabled = true;      //ADD 2008/11/20
                                //}                                                       //ADD 2008/11/20
                                   --- DEL 2008/12/25 -----------------------------------------------<<<<< */
                                // --- ADD 2008/12/25 ----------------------------------------------->>>>>
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    this.Name,
                                    "親の得意先を設定して下さい。",
                                    status,
                                    MessageBoxButtons.OK);
                                this.tNedit_CustomerCode.Text = string.Empty;
                                this.uLabel_CustomerName.Text = string.Empty;

                                e.NextCtrl = e.PrevCtrl;
                                return;
                                // --- ADD 2008/12/25 -----------------------------------------------<<<<<
                            }
                            else
                            {
                                // ---ADD 2009/01/23 不具合対応[9199] ----------------------------------------------------->>>>>
                                if (customerInfo.CreditMngCode == 0)
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.Name,
                                        "指定した得意先は与信管理が設定されていません。",
                                        status,
                                        MessageBoxButtons.OK);
                                    this.tNedit_CustomerCode.Text = string.Empty;
                                    this.uLabel_CustomerName.Text = string.Empty;

                                    e.NextCtrl = e.PrevCtrl;
                                    return;
                                }
                                // ---ADD 2009/01/23 不具合対応[9199] -----------------------------------------------------<<<<<

                                this.CreditMoney_tNedit.Enabled = true;
                                this.WarningCreditMoney_tNedit.Enabled = true;
                                this.PrsntAccRecBalance_tNedit.Enabled = true;
                            }
                            this.CreditMoney_tNedit.Text = "0";
                            this.WarningCreditMoney_tNedit.Text = "0";
                            this.PrsntAccRecBalance_tNedit.Text = "0";

                            // --- ADD 2008/09/08 -------------------------------->>>>>
                            e.NextCtrl = CreditMoney_tNedit;
                            // --- ADD 2008/09/08 --------------------------------<<<<<

                            // 2009.03.30 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                            if (this._dataIndex < 0)
                            {
                                if (ModeChangeProc())
                                {
                                    e.NextCtrl = tNedit_CustomerCode;
                                }
                            }
                            // 2009.03.30 30413 犬飼 新規モードからモード変更対応 <<<<<<END
                        }
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                // --- DEL 2008/09/08 -------------------------------->>>>>
                                //"選択した得意先は既に削除されています。",
                                // --- DEL 2008/09/08 --------------------------------<<<<<
                                // --- ADD 2008/09/08 -------------------------------->>>>>
                                "指定した得意先コードは存在しません。",
                                // --- ADD 2008/09/08 --------------------------------<<<<<
                                status,
                                MessageBoxButtons.OK);
                            this.tNedit_CustomerCode.Text = string.Empty;
                            this.uLabel_CustomerName.Text = string.Empty;

                            return;
                        }
                        // --- ADD 2008/09/08 -------------------------------->>>>>
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "指定した得意先コードは既に削除されています。",
                                status,
                                MessageBoxButtons.OK);
                            this.tNedit_CustomerCode.Text = string.Empty;
                            this.uLabel_CustomerName.Text = string.Empty;

                            return;
                        }
                        // --- ADD 2008/09/08 --------------------------------<<<<<
                        else
                        {
                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_STOPDISP,
                                          this.Name,
                                          "得意先情報の取得に失敗しました。",
                                          status,
                                          MessageBoxButtons.OK);
                            this.tNedit_CustomerCode.Text = string.Empty;
                            this.uLabel_CustomerName.Text = string.Empty;

                            return;
                        }
                        // --- DEL 2008/09/16 -------------------------------->>>>>
                        //this.tNedit_CustomerCode.Text = customerInfo.CustomerCode.ToString().Trim();
                        // --- DEL 2008/09/16 --------------------------------<<<<< 
                        // --- ADD 2008/09/16 -------------------------------->>>>>
                        this.tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);
                        // --- ADD 2008/09/16 --------------------------------<<<<<
                        this.uLabel_CustomerName.Text = customerInfo.CustomerSnm; // 略称
                        break;
                    }
            }
		}

		#endregion

        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            // 得意先ガイド
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            // ---ADD 2008/12/25 不具合対応[9454] ------------------------------------------->>>>>
            if (string.IsNullOrEmpty(this.tNedit_CustomerCode.Text))
            {
                return;
            }
            // ---ADD 2008/12/25 ------------------------------------------------------------<<<<<
            // ---ADD 2008/10/06 不具合対応[6229] ------------------------------------------->>>>>
            this.CreditMoney_tNedit.Focus();
            this.CreditMoney_tNedit.SelectAll();
            // ---ADD 2008/10/06 不具合対応[6229] -------------------------------------------<<<<<

            // 2009.03.30 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            if (this._dataIndex < 0)
            {
                if (ModeChangeProc())
                {
                    ((Control)sender).Focus();
                }
            }
            // 2009.03.30 30413 犬飼 新規モードからモード変更対応 <<<<<<END
        }

        /// <summary>得意先選択時発生イベント</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;

            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 親かを判定し、子の場合は与信額・警告与信額・現在売掛残高は入力不可
                if (customerInfo.ClaimCode != customerSearchRet.CustomerCode)
                {
                    /* --- DEL 2008/12/25 不具合対応[9454] ------------------------------>>>>>
                    // 子の場合、与信管理「しない」時のみ入力不可
                    //if (customerInfo.CreditMngCode == 0)                    //ADD 2008/11/20
                    //{                                                       //ADD 2008/11/20
                        this.CreditMoney_tNedit.Enabled = false;
                        this.WarningCreditMoney_tNedit.Enabled = false;
                        this.PrsntAccRecBalance_tNedit.Enabled = false;
                    //}                                                       //ADD 2008/11/20
                    //else                                                    //ADD 2008/11/20
                    //{                                                       //ADD 2008/11/20
                    //    this.CreditMoney_tNedit.Enabled = true;             //ADD 2008/11/20
                    //    this.WarningCreditMoney_tNedit.Enabled = true;      //ADD 2008/11/20
                    //    this.PrsntAccRecBalance_tNedit.Enabled = true;      //ADD 2008/11/20
                    //}                                                       //ADD 2008/11/20
                       --- DEL 2008/12/25 -----------------------------------------------<<<<< */
                    // --- ADD 2008/12/25 ----------------------------------------------->>>>>
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "親の得意先を設定して下さい。",
                        status,
                        MessageBoxButtons.OK);
                    this.tNedit_CustomerCode.Text = string.Empty;
                    this.uLabel_CustomerName.Text = string.Empty;

                    return;
                    // --- ADD 2008/12/25 -----------------------------------------------<<<<<
                }
                else
                {
                    this.CreditMoney_tNedit.Enabled = true;
                    this.WarningCreditMoney_tNedit.Enabled = true;
                    this.PrsntAccRecBalance_tNedit.Enabled = true;
                }
                this.CreditMoney_tNedit.Text = "0";
                this.WarningCreditMoney_tNedit.Text = "0";
                this.PrsntAccRecBalance_tNedit.Text = "0";
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    //"選択した得意先は既に削除されています。",     // DEL 2008.08.29
                    "既存の得意先コードを設定して下さい。",         // ADD 2008.08.29
                    status,
                    MessageBoxButtons.OK);
                this.tNedit_CustomerCode.Text = string.Empty;
                this.uLabel_CustomerName.Text = string.Empty;

                return;
            }
            else
            {
                TMsgDisp.Show(this,
                              emErrorLevel.ERR_LEVEL_STOPDISP,
                              this.Name,
                              "得意先情報の取得に失敗しました。",
                              status,
                              MessageBoxButtons.OK);
                this.tNedit_CustomerCode.Text = string.Empty;
                this.uLabel_CustomerName.Text = string.Empty;

                return;
            }

            // --- DEL 2008/09/16 -------------------------------->>>>>
            //this.tNedit_CustomerCode.Text = customerInfo.CustomerCode.ToString().Trim();
            // --- DEL 2008/09/16 --------------------------------<<<<<
            // --- ADD 2008/09/16 -------------------------------->>>>>
            this.tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);
            // --- ADD 2008/09/16 --------------------------------<<<<< 
            
            this.uLabel_CustomerName.Text = customerInfo.CustomerSnm; // 略称
        }

        //--- ADD 2008/06/24 ---------->>>>>
        /// <summary>
        /// 得意先名称取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先名称</returns>
        /// <remarks>
        /// <br>Note       : 得意先名称を取得します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.24</br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            string customerName = "";

            int status;

            CustomerInfo customerInfo = new CustomerInfo();
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            
            try
            {
                status = customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);

                if (status == 0)
                {
                    customerName = customerInfo.CustomerSnm.Trim();
                }
            }
            catch
            {
                customerName = "";
            }

            return customerName;
        }
        //--- ADD 2008/06/24 ----------<<<<<

        // ---ADD 2008/10/06 不具合対応[6230] ------------------------------------------->>>>>
        /// <summary>Leave  イベント</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : アクティブコントロールでなくなった時に発生します。</br>
        /// <br>Programmer : 30462 行澤　仁美</br>
        /// <br>Date       : 2008.10.06</br>
        /// </remarks>
        private void tNedit_CustomerCode_Leave(object sender, EventArgs e)
        {
            if (this.tNedit_CustomerCode.Text.Trim().Length == 0)
            {
                this.uLabel_CustomerName.Text = "";
            }

        }
        // ---ADD 2008/10/06 不具合対応[6230] -------------------------------------------<<<<<

        // 2009.03.30 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // 得意先コード
            int customerCode = tNedit_CustomerCode.GetInt();

            for (int i = 0; i < this._customerChangeAcs.BindDataSet.Tables[CustomerChangeAcs.TBL_CUSTOMERCHANGE_TITLE].DefaultView.Count; i++)
            {
                // データセットと比較
                int dsCustomerCode = (int)this._customerChangeAcs.BindDataSet.Tables[CustomerChangeAcs.TBL_CUSTOMERCHANGE_TITLE].DefaultView[i][CustomerChangeAcs.COL_CUSTOMERCODE_TITLE];
                if (customerCode == dsCustomerCode)
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this._customerChangeAcs.BindDataSet.Tables[CustomerChangeAcs.TBL_CUSTOMERCHANGE_TITLE].DefaultView[i][CustomerChangeAcs.COL_DELETEDATE_TITLE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          CT_PGID,						        // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの得意先変動情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 得意先コードのクリア
                        tNedit_CustomerCode.Clear();
                        uLabel_CustomerName.Text = "";
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        CT_PGID,                                // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードの得意先変動情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
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
                                // 得意先コードのクリア
                                tNedit_CustomerCode.Clear();
                                uLabel_CustomerName.Text = "";
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.30 30413 犬飼 新規モードからモード変更対応 <<<<<<END
	}
}