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
	/// 離島価格マスタフォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 離島価格マスタの設定を行います。</br>
	/// <br>Programmer : 30416 長沼 賢二</br>
	/// <br>Date       : 2008.06.27</br>
    /// <br>UpdateNote : 2008/11/13 照田 貴志　バグ修正、仕様変更対応</br>
    /// <br>UpdateNote : 2009/02/05 忍 幸史　障害ID:11061対応</br>
	/// </remarks>
	public partial class PMKHN09040UA : Form, IMasterMaintenanceMultiType
	{
		// --------------------------------------------------
		#region Constructor

		/// <summary>
        /// 離島価格マスタフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 離島価格マスタフォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
        /// <br>Update Note: 2008.09.25 30452 上野 俊治</br>
        /// <br>             PM.NS対応(不具合対応)</br>
        /// <br>             ・changeForcusイベント追加</br>
        /// <br>             ・メーカーガイド削除</br>
        /// <br>             ・グリッドに拠点名称追加</br>
		/// </remarks>
		public PMKHN09040UA()
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

            this.uButton_SectionGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            // --- DEL 2008/09/25 -------------------------------->>>>>
            //this.uButton_MakerGuide.Appearance.Image
            //    = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            // --- DEL 2008/09/25 --------------------------------<<<<<

			// 企業コード取得
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// インスタンス初期化
            this._isolIslandPrcAcs = new IsolIslandPrcAcs();

			// グリッド選択インデックス
			this._dataIndex                      = -1;
			this._indexBuf                       = -2;
		}

		#endregion

		// --------------------------------------------------
		#region Private Members

        private string _enterpriseCode = "";           // 企業コード

        private IsolIslandPrcAcs _isolIslandPrcAcs = null;

		// メイン用クローンオブジェクト
        private IsolIslandPrc _isolIslandPrcClone = null;

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
		private const string            CT_PGID        = "PMKHN09040U";
		private const string            CT_PGNAME      = "離島価格マスタ";
		private const string            CT_CLASSNAME   = "PMKHN09040UA";

        // Message関連定義
        private const string            ERR_READ_MSG   = "読み込みに失敗しました。";
        private const string            ERR_DPR_MSG    = "このコードは既に使用されています。";
        private const string            ERR_RDEL_MSG   = "削除に失敗しました。";
        private const string            ERR_UPDT_MSG   = "登録に失敗しました。";
        private const string            ERR_RVV_MSG    = "復活に失敗しました。";
        private const string            ERR_800_MSG    = "既に他端末より更新されています。";
        private const string            ERR_801_MSG    = "既に他端末より削除されています。";
        private const string            SDC_RDEL_MSG   = "マスタから削除されています。";

        // 端数処理区分
        /* --- DEL 2008/11/13 表示位置変更の為 ------------------------->>>>>
        private const string            FRACTIONPROCCD_KIND1 = "四捨五入";
        private const string            FRACTIONPROCCD_KIND2 = "切り上げ";
        private const string            FRACTIONPROCCD_KIND3 = "切り捨て";
           --- DEL 2008/11/13 ------------------------------------------<<<<< */
        // --- ADD 2008/11/13 ------------------------------------------>>>>>
        private const string FRACTIONPROCCD_KIND1 = "切り捨て";
        private const string FRACTIONPROCCD_KIND2 = "四捨五入";
        private const string FRACTIONPROCCD_KIND3 = "切り上げ";
        // --- ADD 2008/11/13 ------------------------------------------<<<<<
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
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
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
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
		public void GetBindDataSet( ref DataSet bindDataSet, ref string tableName )
		{
            bindDataSet = this._isolIslandPrcAcs.BindDataSet;
            tableName = IsolIslandPrcAcs.TBL_ISOLISLANDPRC_TITLE;
		}
        
		/// <summary>
		/// グリッド列外観情報取得処理
		/// </summary>
		/// <returns>グリッド列外観情報格納Hashtable</returns>
		/// <remarks>
        /// <br>Note       : グリッドの各列の外観を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

			// 削除日
            appearanceTable.Add(IsolIslandPrcAcs.COL_DELETEDATE_TITLE, 
                new GridColAppearance( MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red ) );

            // 拠点コード
            appearanceTable.Add(IsolIslandPrcAcs.COL_SECTIONCODE_TITLE, 
				new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black ) );
            // --- ADD 2008/09/25 -------------------------------->>>>>
            // 拠点名称
            appearanceTable.Add(IsolIslandPrcAcs.COL_SECTIONNAME_TITLE,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2008/09/25 --------------------------------<<<<<
            // メーカーコード
            appearanceTable.Add(IsolIslandPrcAcs.COL_MAKERCODE_TITLE,
            //    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black)); // DEL 2008/09/24
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "000", Color.Black)); // ADD 2008/09/24
            // メーカー名称
            appearanceTable.Add(IsolIslandPrcAcs.COL_MAKERNAME_TITLE,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // 価格上限
            appearanceTable.Add(IsolIslandPrcAcs.COL_UPPERLIMITPRICE_TITLE,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "###,#0", Color.Black));
            // 価格UP率
            appearanceTable.Add(IsolIslandPrcAcs.COL_UPRATE_TITLE,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 端数処理単位
            appearanceTable.Add(IsolIslandPrcAcs.COL_FRACTIONPROCUNIT_TITLE,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "###,#0", Color.Black));
            // 端数処理区分
            appearanceTable.Add(IsolIslandPrcAcs.COL_FRACTIONPROCCD_TITLE,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // GUID
            appearanceTable.Add(IsolIslandPrcAcs.COL_GUID_TITLE, 
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
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
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
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
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
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
        private int SearchProc(ref int totalCount, int readCount)
		{
            const string ctPROCNM = "SearchProc";
			int status = ( int )ConstantManagement.DB_Status.ctDB_EOF;

			totalCount = 0;
			
			// 検索実行
            status = this._isolIslandPrcAcs.SearchAll(out totalCount, this._enterpriseCode);
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
                        this._isolIslandPrcAcs,             // エラーが発生したオブジェクト
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
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
        private bool SaveProc()
        {
            const string ctPROCNM = "SaveProc";
            bool result = false;
            ArrayList isolIslandPrcArray = new ArrayList();

            // 入力チェック
            Control control = null;
            string message = null;
            if (this.ScreenDataCheck(ref control, ref message) == false)
            {
                // 入力チェック
                TMsgDisp.Show(
                    this,                               // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
                    message,                            // 表示するメッセージ
                    0,                                  // ステータス値
                    MessageBoxButtons.OK);              // 表示するボタン

                if (control != null)
                {
                    control.Focus();
                    if (control is TEdit)
                    {
                        ((TEdit)control).SelectAll();
                    }
                    else if (control is TNedit)
                    {
                        ((TNedit)control).SelectAll();
                    }
                }
                return result;
            }

            // 画面データ取得
            IsolIslandPrc isolIslandPrc = new IsolIslandPrc();
            this.DispToIsolIslandPrc(ref isolIslandPrc, 0);

            // 書き込み処理
            int status = 0;
            status = this._isolIslandPrcAcs.Write(isolIslandPrc);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        result = true;
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // コード重複
                        TMsgDisp.Show(
                            this,                           // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_INFO,    // エラーレベル
                            CT_PGID,                        // アセンブリＩＤまたはクラスＩＤ
                            ERR_DPR_MSG,                    // 表示するメッセージ
                            0,                              // ステータス値
                            MessageBoxButtons.OK);          // 表示するボタン

                        this.tEdit_SectionCode.Focus();
                        this.tEdit_SectionCode.SelectAll();

                        return result;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        this.ExclusiveTransaction(status, true);
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
                            this._isolIslandPrcAcs,             // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,               // 表示するボタン
                            MessageBoxDefaultButton.Button1);   // 初期表示ボタン
                        this.CloseForm(DialogResult.Cancel);
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
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
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
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
        private int LogicalDeleteProc()
        {
            const string ctPROCNM = "LogicalDeleteProc";
            int status = 0;
            ArrayList fileHeaderGuidArray = new ArrayList();

            DataTable dt = this._isolIslandPrcAcs.BindDataSet.Tables[IsolIslandPrcAcs.TBL_ISOLISLANDPRC_TITLE];

            // グリッドが選択されていない時
            if ((this._dataIndex < 0) ||
                (this._dataIndex >= dt.Rows.Count))
            {
                return status;
            }

            // 選択データ取得
            Guid fileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][IsolIslandPrcAcs.COL_GUID_TITLE]; // GUID


            // 論理削除実行
            status = this._isolIslandPrcAcs.LogicalDelete(fileHeaderGuid);

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
                            this._isolIslandPrcAcs,             // エラーが発生したオブジェクト
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
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
        private int RevivalProc()
        {
            const string ctPROCNM = "RevivalProc";
            int status = 0;
            ArrayList fileHeaderGuidArray = new ArrayList();

            DataTable dt = this._isolIslandPrcAcs.BindDataSet.Tables[IsolIslandPrcAcs.TBL_ISOLISLANDPRC_TITLE];

            // グリッドが選択されていない時
            if ((this._indexBuf < 0) ||
                (this._indexBuf >= dt.Rows.Count))
            {
                this.CloseForm(DialogResult.Cancel);
                return -1;
            }

            // 選択データ取得
            Guid fileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][IsolIslandPrcAcs.COL_GUID_TITLE]; // GUID

            // 論理削除復活実行
            status = this._isolIslandPrcAcs.Revival(fileHeaderGuid);

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
                        ExclusiveTransaction(status, true);
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
                            this._isolIslandPrcAcs,             // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,               // 表示するボタン
                            MessageBoxDefaultButton.Button1);   // 初期表示ボタン
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
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
		private int PhysicalDeleteProc()
		{
			const string ctPROCNM = "PhysicalDeleteProc";
			int status = 0;

            DataTable dt = this._isolIslandPrcAcs.BindDataSet.Tables[IsolIslandPrcAcs.TBL_ISOLISLANDPRC_TITLE];

			// グリッドが選択されていない時
			if( ( this._indexBuf < 0 ) || 
				( this._indexBuf >= dt.Rows.Count ) ) {
				this.CloseForm( DialogResult.Cancel );
				return -1;
            }

            // 選択データ取得
            Guid fileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][IsolIslandPrcAcs.COL_GUID_TITLE]; // GUID

            // 物理削除実行
            status = this._isolIslandPrcAcs.Delete(fileHeaderGuid);

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
                        this._isolIslandPrcAcs,             // エラーが発生したオブジェクト
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
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
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
        /// <param name="isolIslandPrc">離島価格マスタオブジェクト</param>
		/// <remarks>
        /// <br>Note       : マスタ情報を画面に展開します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
        private void IsolIslandPrcToScreen(IsolIslandPrc isolIslandPrc)
        {
            // 新規モードの場合
            if (this._editingMode == CT_EMODE_INSERT)
            {
                this.tEdit_SectionCode.Clear();        // 拠点コード
                this.uLabel_SectionName.Text = "";      // 拠点名称
            }
            // 新規モード以外の場合
            else
            {
                this.tEdit_SectionCode.Text = isolIslandPrc.SectionCode.ToString();                        // 拠点コード
                this.uLabel_SectionName.Text = GetSectionName(isolIslandPrc.SectionCode.ToString());        // 拠点名称
                //this.tNedit_CarMakerCd.Text = isolIslandPrc.MakerCode.ToString();                            // メーカーコード        //DEL 2008/11/13 3桁ゼロ詰めの為
                this.tNedit_CarMakerCd.Text = isolIslandPrc.MakerCode.ToString("000");                      // メーカーコード           //ADD 2008/11/13
                this.uLabel_MakerName.Text = GetMakerName(isolIslandPrc.MakerCode);                         // メーカー名称
            }

            this.UpperLimitPrice_tNedit.SetValue(isolIslandPrc.UpperLimitPrice);                            // 価格上限
            this.UpRate_tNedit.SetValue(isolIslandPrc.UpRate);                                              // 価格UP率
            this.FractionProcUnit_tNedit.SetValue(isolIslandPrc.FractionProcUnit);                          // 端数処理単位
        }

		/// <summary>
		/// 画面データ取得処理
		/// </summary>
        /// <param name="isolIslandPrc">離島価格マスタオブジェクト</param>
		/// <remarks>
        /// <br>Note       : 画面データの取得を行います</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
        private void DispToIsolIslandPrc(ref IsolIslandPrc isolIslandPrc, int getCnt)
        {
            // 更新モードの場合
            if (this._editingMode == CT_EMODE_UPDATE)
            {
                // Guid
                DataTable dt = this._isolIslandPrcAcs.BindDataSet.Tables[IsolIslandPrcAcs.TBL_ISOLISLANDPRC_TITLE];
                isolIslandPrc.FileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][IsolIslandPrcAcs.COL_GUID_TITLE];
            }

            // 企業コード
            isolIslandPrc.EnterpriseCode = this._enterpriseCode;

            // 拠点コード
            isolIslandPrc.SectionCode = this.tEdit_SectionCode.Text;

            // メーカーコード
            isolIslandPrc.MakerCode = IsolIslandPrcAcs.NullChgInt(this.tNedit_CarMakerCd.Text);

            // 価格上限
            isolIslandPrc.UpperLimitPrice = this.UpperLimitPrice_tNedit.GetValue();
            // 価格UP率
            isolIslandPrc.UpRate = this.UpRate_tNedit.GetValue();
            // 端数処理単位
            // --- CHG 2009/02/05 障害ID:11061対応------------------------------------------------------>>>>>
            //isolIslandPrc.FractionProcUnit = this.FractionProcUnit_tNedit.GetValue();
            if (this.FractionProcUnit_tNedit.GetInt() != 0)
            {
                isolIslandPrc.FractionProcUnit = this.FractionProcUnit_tNedit.GetValue();
            }
            else
            {
                isolIslandPrc.FractionProcUnit = 1;
            }
            // --- CHG 2009/02/05 障害ID:11061対応------------------------------------------------------<<<<<
            // 端数処理区分
            //isolIslandPrc.FractionProcCd = this.FractionProcCd1_tEdittComboEditor.SelectedIndex;      //DEL 2008/11/13 表示位置変更の為
            isolIslandPrc.FractionProcCd = (int)this.FractionProcCd1_tEdittComboEditor.Value;           //ADD 2008/11/13
        }

        #endregion

        // --------------------------------------------------
        #region Screen Methods
        
		/// <summary>
		/// 画面クリア処理
		/// </summary>
		/// <remarks>
        /// <br>Note       : 画面のクリアを行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
		private void ScreenClear()
        {
            this.tEdit_SectionCode.Clear();                            // 拠点コード
            this.tNedit_CarMakerCd.Clear();                              // メーカーコード

            this.uLabel_SectionName.Text = "";                          // 拠点名称
            this.uLabel_MakerName.Text = "";                            // メーカー名称

            // --- CHG 2009/02/05 障害ID:11061対応------------------------------------------------------>>>>>
            //this.UpperLimitPrice_tNedit.Clear();                        // 価格上限
            //this.UpRate_tNedit.Clear();                                 // 価格UP率
            //this.FractionProcUnit_tNedit.Clear();                       // 端数処理単位
            this.UpperLimitPrice_tNedit.SetInt(9999999);
            this.UpRate_tNedit.SetInt(100);                                 // 価格UP率
            this.FractionProcUnit_tNedit.SetInt(10);                       // 端数処理単位
            // --- CHG 2009/02/05 障害ID:11061対応------------------------------------------------------<<<<<
            //this.FractionProcCd1_tEdittComboEditor.SelectedIndex = 0;   // 端数処理区分       //DEL 2008/11/13 表示位置変更の為
            this.FractionProcCd1_tEdittComboEditor.SelectedIndex = 1;   // 端数処理区分         //ADD 2008/11/13
        }
        
        /// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
        /// <br>Note       : 画面の再構築処理を行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
		private void ScreenReconstruction()
        {
            IsolIslandPrc isolIslandPrc = new IsolIslandPrc();

			// 新規の時
            if (this._dataIndex < 0)
            {
                // 新規モードに設定
                this._editingMode = CT_EMODE_INSERT;
                this.Mode_Label.Text = INSERT_MODE;

                // --- DEL 2009/02/05 障害ID:11061対応------------------------------------------------------>>>>>
                //// 画面に展開
                //this.IsolIslandPrcToScreen(isolIslandPrc);
                // --- DEL 2009/02/05 障害ID:11061対応------------------------------------------------------<<<<<

                // クローン作成
                this._isolIslandPrcClone = new IsolIslandPrc();
                this.DispToIsolIslandPrc(ref this._isolIslandPrcClone, 0);

                // 画面入力許可制御設定
                this.ScreenInputPermissionControl(this._editingMode);

                this.Enabled = true;

                this.tEdit_SectionCode.Focus();
                this.tEdit_SectionCode.SelectAll();
            }
            else
            {
                // フレームで選択されているレコードのオブジェクトを取得
                DataRowView dr = this._isolIslandPrcAcs.BindDataSet.Tables[IsolIslandPrcAcs.TBL_ISOLISLANDPRC_TITLE].DefaultView[this._dataIndex];

                if ((string)dr[IsolIslandPrcAcs.COL_DELETEDATE_TITLE] != "") // 削除日
                {
                    isolIslandPrc.LogicalDeleteCode = 1;
                }

                isolIslandPrc.SectionCode = dr[IsolIslandPrcAcs.COL_SECTIONCODE_TITLE].ToString();    　　　　　            // 拠点コード

                isolIslandPrc.MakerCode = (int)dr[IsolIslandPrcAcs.COL_MAKERCODE_TITLE];       　　　　　　                 // メーカーコード

                isolIslandPrc.UpperLimitPrice = (double)dr[IsolIslandPrcAcs.COL_UPPERLIMITPRICE_TITLE];　                   // 価格上限
                isolIslandPrc.UpRate = (double)dr[IsolIslandPrcAcs.COL_UPRATE_TITLE]; 　　　　　　                          // 価格UP率
                isolIslandPrc.FractionProcUnit = (double)dr[IsolIslandPrcAcs.COL_FRACTIONPROCUNIT_TITLE];                   // 端数処理単位

                //this.FractionProcCd1_tEdittComboEditor.Text = dr[IsolIslandPrcAcs.COL_FRACTIONPROCCD_TITLE].ToString();     // 端数処理区分       //DEL 2008/11/13 データが古い場合に値が無い為、初期値を表示する
                // --- ADD 2008/11/13 ---------------------------------------------------------------------------------------->>>>>
                if ((string.IsNullOrEmpty(dr[IsolIslandPrcAcs.COL_FRACTIONPROCCD_TITLE].ToString())) ||
                    (dr[IsolIslandPrcAcs.COL_FRACTIONPROCCD_TITLE].ToString() == "0"))
                {
                    // データが古い場合、値が無いので初期値を表示                    
                    this.FractionProcCd1_tEdittComboEditor.Text = "2";
                }
                else
                {
                    this.FractionProcCd1_tEdittComboEditor.Text = dr[IsolIslandPrcAcs.COL_FRACTIONPROCCD_TITLE].ToString();
                }
                // --- ADD 2008/11/13 ----------------------------------------------------------------------------------------<<<<<

                // 更新モード
                if (isolIslandPrc.LogicalDeleteCode == 0)
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
                this.IsolIslandPrcToScreen(isolIslandPrc);

                // クローン作成
                this._isolIslandPrcClone = new IsolIslandPrc();
                this.DispToIsolIslandPrc(ref this._isolIslandPrcClone, 0);

                // 画面入力許可制御設定
                this.ScreenInputPermissionControl(this._editingMode);

                this.Enabled = true;

                if (this._editingMode == CT_EMODE_UPDATE)
                {
                    this.UpRate_tNedit.Focus();
                    this.UpRate_tNedit.SelectAll();
                }
                else
                {
                    this.Delete_Button.Focus();
                }
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
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
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
                    // 拠点コード
                    this.tEdit_SectionCode.Enabled = true;
                    // 拠点ガイドボタン
                    this.uButton_SectionGuide.Enabled = true;

                    // メーカーコード
                    this.tNedit_CarMakerCd.Enabled = true;
                    // メーカーガイドボタン
                    //this.uButton_MakerGuide.Enabled = true; // DEL 2008/09/25
					
                    // 価格上限
                    this.UpperLimitPrice_tNedit.Enabled = true;
                    // 価格UP率
                    this.UpRate_tNedit.Enabled = true;
                    // 端数処理単位
                    this.FractionProcUnit_tNedit.Enabled = true;
                    // 端数処理区分
                    this.FractionProcCd1_tEdittComboEditor.Enabled = true;

                    // 初期フォーカス設定
                    this.tEdit_SectionCode.Focus();
                    this.tEdit_SectionCode.SelectAll();
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
                    // 拠点コード
                    this.tEdit_SectionCode.Enabled = false;
                    // 拠点ガイドボタン
                    this.uButton_SectionGuide.Enabled = false;

                    // メーカーコード
                    this.tNedit_CarMakerCd.Enabled = false;
                    // メーカーガイドボタン
                    //this.uButton_MakerGuide.Enabled = false; // DEL 2008/09/25

                    // 価格上限
                    this.UpperLimitPrice_tNedit.Enabled = false;

                    // 価格UP率
                    this.UpRate_tNedit.Enabled = true;
                    // 端数処理単位
                    this.FractionProcUnit_tNedit.Enabled = true;
                    // 端数処理区分
                    this.FractionProcCd1_tEdittComboEditor.Enabled = true;

  					// 初期フォーカス設定
                    this.UpRate_tNedit.Focus();
                    this.UpRate_tNedit.SelectAll();
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
                    // 拠点コード
                    this.tEdit_SectionCode.Enabled = false;
                    // 拠点ガイドボタン
                    this.uButton_SectionGuide.Enabled = false;

                    // メーカーコード
                    this.tNedit_CarMakerCd.Enabled = false;
                    // メーカーガイドボタン
                    //this.uButton_MakerGuide.Enabled = false; // DEL 2008/09/24

                    // 価格上限
                    this.UpperLimitPrice_tNedit.Enabled = false;
                    // 価格UP率
                    this.UpRate_tNedit.Enabled = false;
                    // 端数処理単位
                    this.FractionProcUnit_tNedit.Enabled = false;
                    // 端数処理区分
                    this.FractionProcCd1_tEdittComboEditor.Enabled = false;

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
                    // 拠点コード
                    this.tEdit_SectionCode.Enabled = false;
                    // 拠点ガイドボタン
                    this.uButton_SectionGuide.Enabled = false;

                    // メーカーコード
                    this.tNedit_CarMakerCd.Enabled = false;
                    // メーカーガイドボタン
                    //this.uButton_MakerGuide.Enabled = false; // DEL 2008/09/24

                    // 価格上限
                    this.UpperLimitPrice_tNedit.Enabled = false;
                    // 価格UP率
                    this.UpRate_tNedit.Enabled = false;
                    // 端数処理単位
                    this.FractionProcUnit_tNedit.Enabled = false;
                    // 端数処理区分
                    this.FractionProcCd1_tEdittComboEditor.Enabled = false;
                    
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
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
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
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
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
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
		private bool ScreenDataCheck( ref Control control, ref string message )
		{
			bool result = true;

            // 拠点コード
            if (this.tEdit_SectionCode.Text.Trim() == "")
            {
                message = this.SectionCode_Title_Label.Text + "を入力してください。";
                control = this.tEdit_SectionCode;
                result = false;

                return result; // ADD 2008/09/24
            }

            // メーカーコード
            if (this.tNedit_CarMakerCd.Text.Trim() == "")
            {
                message = this.MakerCode_Title_Label.Text + "を入力してください。";
                control = this.tNedit_CarMakerCd;
                result = false;

                return result; // ADD 2008/09/24
            }
            // --- ADD 2008/09/25 -------------------------------->>>>>
            else if (this.GetMakerDataRow(this.tNedit_CarMakerCd.GetInt().ToString()) == null)
            {
                // 該当のメーカーが存在しない場合、エラー
                message =  "入力した" + this.MakerCode_Title_Label.Text + "は存在しません。";
                control = this.tNedit_CarMakerCd;
                result = false;

                return result;
            }
            // --- ADD 2008/09/25 --------------------------------<<<<<
            // 価格上限1
            if (this.UpperLimitPrice_tNedit.Text.Trim() == "")
            {
                message = this.UpperLimitPrice_Title_Label.Text + "を入力してください。";
                control = this.UpperLimitPrice_tNedit;
                result = false;

                return result; // ADD 2008/09/24
            }

            return result;
		}

        #endregion

        // --------------------------------------------------
		#region Control Events

		/// <summary>
        /// Form.Load イベント (PMKHN09040UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
        /// <br>Note       : ユーザーがフォームを読み込む時に発生します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
        private void PMKHN09040UA_Load(object sender, EventArgs e)
        {
            ImageList imageList24 = IconResourceManagement.ImageList24;

            this.Ok_Button.ImageList = imageList24;        // 保存ボタン
            this.Cancel_Button.ImageList = imageList24;    // 閉じるボタン
            this.Revive_Button.ImageList = imageList24;    // 復活ボタン
            this.Delete_Button.ImageList = imageList24;    // 完全削除ボタン

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;           // 保存ボタン
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;      // 閉じるボタン
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;    // 復活ボタン
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;     // 完全削除ボタン

            // 端数処理区分(No.1)
            /* --- DEL 2008/11/13 表示位置、値変更の為 ----------------------------->>>>>
            this.FractionProcCd1_tEdittComboEditor.Items.Add(0, FRACTIONPROCCD_KIND1);
            this.FractionProcCd1_tEdittComboEditor.Items.Add(0, FRACTIONPROCCD_KIND2);
            this.FractionProcCd1_tEdittComboEditor.Items.Add(0, FRACTIONPROCCD_KIND3);
            this.FractionProcCd1_tEdittComboEditor.SelectedIndex = 0;
               --- DEL 2008/11/13 --------------------------------------------------<<<<< */
            // --- ADD 2008/11/13 -------------------------------------------------->>>>>
            this.FractionProcCd1_tEdittComboEditor.Items.Add(1, FRACTIONPROCCD_KIND1);      // 切り捨て
            this.FractionProcCd1_tEdittComboEditor.Items.Add(2, FRACTIONPROCCD_KIND2);      // 四捨五入
            this.FractionProcCd1_tEdittComboEditor.Items.Add(3, FRACTIONPROCCD_KIND3);      // 切り上げ
            this.FractionProcCd1_tEdittComboEditor.SelectedIndex = 1;
            // --- ADD 2008/11/13 --------------------------------------------------<<<<<
        }

		/// <summary>
        /// Form.FormClosing イベント (PMKHN09040UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
        /// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
        private void PMKHN09040UA_FormClosing(object sender, FormClosingEventArgs e)
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
        /// Form.VisibleChanged イベント (PMKHN09040UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
        /// <br>Note       : フォームの表示状態が変化した時に発生します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
        private void PMKHN09040UA_VisibleChanged(object sender, EventArgs e)
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

            this.Enabled = false;

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
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
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
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
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

                IsolIslandPrc newIsolIslandPrc = new IsolIslandPrc();

				// 画面に展開
                this.IsolIslandPrcToScreen(newIsolIslandPrc);

				// クローン作成
                this._isolIslandPrcClone = new IsolIslandPrc();
                this.DispToIsolIslandPrc(ref this._isolIslandPrcClone,0);

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
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
		private void Cancel_Button_Click( object sender, EventArgs e )
		{
			// 削除モード・参照モード以外の場合は保存確認処理を行う
			if( ( this._editingMode != CT_EMODE_DELETE ) && 
				( this._editingMode != CT_EMODE_REFER  ) ) {
				// 現在の画面情報を取得する
                IsolIslandPrc compareIsolIslandPrc = this._isolIslandPrcClone.Clone();
                this.DispToIsolIslandPrc(ref compareIsolIslandPrc, 0);

				// 最初に取得した画面と比較
                if (this._isolIslandPrcClone.Equals(compareIsolIslandPrc) == false)
                {
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
							this.Cancel_Button.Focus();
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
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
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
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
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
        /// Control.Click イベント(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 拠点ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void uButton_SelectionGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                SecInfoSet secInfoSet = new SecInfoSet();
                SecInfoAcs secInfoAcs = new SecInfoAcs();
                secInfoAcs.ResetSectionInfo();

                status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    this.tEdit_SectionCode.Text = secInfoSet.SectionCode.Trim().PadLeft(2, '0');
                    this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm.Trim();

                    this.tNedit_CarMakerCd.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click イベント(MakerGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : メーカーガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        private void uButton_MakerGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                MakerAcs makerAcs = new MakerAcs();
                MakerUMnt makerUMnt = new MakerUMnt();

                status = makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
                if (status == 0)
                {
                    this.tNedit_CarMakerCd.DataText = makerUMnt.GoodsMakerCd.ToString();
                    this.uLabel_MakerName.Text = makerUMnt.MakerName.Trim();

                    this.UpperLimitPrice_tNedit.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        // --- DEL 2008/09/25 -------------------------------->>>>>
        ///// <summary>
        ///// 拠点コード Leave処理
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : 拠点名称表示処理</br>
        ///// <br>Programmer : 30416 長沼 賢二</br>
        ///// <br>Date       : 2008.07.01</br>
        ///// </remarks>
        //private void tEdit_SectionCode_Leave(object sender, EventArgs e)
        //{
        //    // 拠点コード入力あり？
        //    if (this.tEdit_SectionCode.Text != "")
        //    {
        //        // 拠点名称設定
        //        this.uLabel_SectionName.Text = GetSectionName(this.tEdit_SectionCode.Text.Trim());
        //    }
        //    else
        //    {
        //        // 拠点名称クリア
        //        this.uLabel_SectionName.Text = "";
        //    }
        //}

        ///// <summary>
        ///// メーカーコード Leave処理
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : メーカー名称表示処理</br>
        ///// <br>Programmer : 30416 長沼 賢二</br>
        ///// <br>Date       : 2008.07.01</br>
        ///// </remarks>
        //private void tNedit_CarMakerCd_Leave(object sender, EventArgs e)
        //{
        //    // メーカーコード入力あり？
        //    if (this.tNedit_CarMakerCd.Text != "")
        //    {
        //        // メーカー名称設定
        //        this.uLabel_MakerName.Text = GetMakerName(this.tNedit_CarMakerCd.GetInt());
        //    }
        //    else
        //    {
        //        // メーカー名称クリア
        //        this.uLabel_MakerName.Text = "";
        //    }
        //}
        // --- DEL 2008/09/25 --------------------------------<<<<<
		#endregion

        // --------------------------------------------------
        #region Private Methods
        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            ArrayList retList = new ArrayList();
            SecInfoAcs secInfoAcs = new SecInfoAcs();

            try
            {
                foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        return sectionName;
                    }
                }
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
        }

        /// <summary>
        /// メーカー名称取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>メーカー名称</returns>
        /// <remarks>
        /// <br>Note       : メーカー名称を取得します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private string GetMakerName(int makerCode)
        {
            string makerName = "";

            int status;

            MakerUMnt makerUMnt = new MakerUMnt();
            MakerAcs makerAcs = new MakerAcs();

            try
            {
                status = makerAcs.Read(out makerUMnt, this._enterpriseCode, makerCode);

                if (status == 0)
                {
                    makerName = makerUMnt.MakerName.Trim();
                }
            }
            catch
            {
                makerName = "";
            }

            return makerName;
        }
        #endregion


        // --- ADD 2008/09/25 -------------------------------->>>>>
        /// <summary>
        /// ChangeFocusイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            if (e.PrevCtrl.Name == "tEdit_SectionCode")
            {
                // 入力無し、全社の場合は処理なし
                if (this.tEdit_SectionCode.Text != "")
                {
                    bool exist = false;

                    SecInfoAcs secInfoAcs = new SecInfoAcs();
                    secInfoAcs.ResetSectionInfo();

                    foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
                    {
                        if (secInfoSet.SectionCode.Trim() == this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0'))
                        {
                            // 拠点名称をセット
                            this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm.Trim();

                            // 2009.03.26 30413 犬飼 フォーカス制御を修正 >>>>>>START
                            //// 見積書発行区分にフォーカスを変更
                            //e.NextCtrl = this.tNedit_CarMakerCd;
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    // 存在する場合はメーカーコードにフォーカスを変更
                                    e.NextCtrl = this.tNedit_CarMakerCd;
                                }
                            }
                            // 2009.03.26 30413 犬飼 フォーカス制御を修正 <<<<<<END
                            
                            exist = true;
                        }
                    }

                    if (!exist)
                    {
                        // 存在しない場合
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "指定した拠点コードは存在しません。",
                            -1,
                            MessageBoxButtons.OK);

                        // 現在の入力をクリア
                        this.tEdit_SectionCode.DataText = "";
                        this.uLabel_SectionName.Text = "";

                        // 2009.03.26 30413 犬飼 フォーカス制御を修正 >>>>>>START
                        //// 存在しない場合はガイドボタンへフォーカスを変更
                        //e.NextCtrl = this.uButton_SectionGuide;
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // 存在する場合はメーカーコードにフォーカスを変更
                                e.NextCtrl = this.uButton_SectionGuide;
                            }
                        }
                        // 2009.03.26 30413 犬飼 フォーカス制御を修正 <<<<<<END
                    }
                }
                else
                {
                    // --- ADD 2008/09/30 -------------------------------->>>>>
                    // 拠点名称をクリア
                    this.uLabel_SectionName.Text = "";
                    // --- ADD 2008/09/30 --------------------------------<<<<<
                }
            }
            else if (e.PrevCtrl.Name == "tNedit_CarMakerCd")
            {
                DataRow dr = this.GetMakerDataRow(this.tNedit_CarMakerCd.GetInt().ToString());

                if (dr != null)
                {
                    // 存在する場合、名称を取得
                    this.uLabel_MakerName.Text = dr["MakerName"].ToString();
                }
                else
                {
                    // 存在しない場合クリアする
                    this.uLabel_MakerName.Text = "";
                }
            }

            // 2009.03.26 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            switch (e.NextCtrl.Name)
            {
                case "UpRate_tNedit":                       // 価格UP率
                case "FractionProcUnit_tNedit":             // 端数処理単位
                case "FractionProcCd1_tEdittComboEditor":   // 端数処理区分
                    {
                        if (this._dataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = tEdit_SectionCode;
                            }
                        }
                        break;
                    }
            }
            // 2009.03.26 30413 犬飼 新規モードからモード変更対応 <<<<<<END

            return;
        }

        /// <summary>
        /// 指定したメーカーコードのDataRowを取得する。
        /// </summary>
        /// <returns></returns>
        private DataRow GetMakerDataRow(string makerCd)
        {
            int status;
            MakerAcs makerAcs = new MakerAcs();
            MakerUMnt makerUMnt = new MakerUMnt();

            Hashtable hash = new Hashtable();
            hash.Add("EnterpriseCode", this._enterpriseCode);

            DataSet ds = new DataSet();

            status = makerAcs.GetGuideData(0, hash, ref ds);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["GoodsMakerCd"].ToString() == makerCd)
                {
                    return ds.Tables[0].Rows[i];
                }
            }

            return null;
        }
        // --- ADD 2008/09/25 --------------------------------<<<<<

        // 2009.03.26 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // 拠点コード
            string secCd = tEdit_SectionCode.Text.TrimEnd().PadLeft(2, '0');
            // メーカーコード
            int makerCd = tNedit_CarMakerCd.GetInt();
            // 上限金額
            double upperLimitPrice = UpperLimitPrice_tNedit.GetValue();

            for (int i = 0; i < this._isolIslandPrcAcs.BindDataSet.Tables[IsolIslandPrcAcs.TBL_ISOLISLANDPRC_TITLE].DefaultView.Count; i++)
            {
                // データセットと比較
                string dsSecCd = (string)this._isolIslandPrcAcs.BindDataSet.Tables[IsolIslandPrcAcs.TBL_ISOLISLANDPRC_TITLE].DefaultView[i][IsolIslandPrcAcs.COL_SECTIONCODE_TITLE];
                int dsMakerCd = (int)this._isolIslandPrcAcs.BindDataSet.Tables[IsolIslandPrcAcs.TBL_ISOLISLANDPRC_TITLE].DefaultView[i][IsolIslandPrcAcs.COL_MAKERCODE_TITLE];
                double dsUpperLimitPrice = (double)this._isolIslandPrcAcs.BindDataSet.Tables[IsolIslandPrcAcs.TBL_ISOLISLANDPRC_TITLE].DefaultView[i][IsolIslandPrcAcs.COL_UPPERLIMITPRICE_TITLE];
                if ((secCd.Equals(dsSecCd.TrimEnd())) &&
                    (makerCd == dsMakerCd) &&
                    (upperLimitPrice == dsUpperLimitPrice))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this._isolIslandPrcAcs.BindDataSet.Tables[IsolIslandPrcAcs.TBL_ISOLISLANDPRC_TITLE].DefaultView[i][IsolIslandPrcAcs.COL_DELETEDATE_TITLE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          CT_PGID,						        // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの離島価格マスタ情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 拠点コード、メーカーコード、上限金額のクリア
                        tEdit_SectionCode.Clear();
                        uLabel_SectionName.Text = "";
                        tNedit_CarMakerCd.Clear();
                        uLabel_MakerName.Text = "";
                        UpperLimitPrice_tNedit.SetInt(9999999);
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        CT_PGID,                                // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードの離島価格マスタ情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
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
                                // 拠点コード、メーカーコード、上限金額のクリア
                                tEdit_SectionCode.Clear();
                                uLabel_SectionName.Text = "";
                                tNedit_CarMakerCd.Clear();
                                uLabel_MakerName.Text = "";
                                UpperLimitPrice_tNedit.SetInt(9999999);
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.26 30413 犬飼 新規モードからモード変更対応 <<<<<<END
    }
}