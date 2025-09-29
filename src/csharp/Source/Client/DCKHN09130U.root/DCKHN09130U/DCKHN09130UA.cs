//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 伝票設定マスタ
// プログラム概要   : 伝票設定マスタの登録・更新・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2008/04/24  修正内容 : PM.NS 共通修正 得意先・仕入先分離対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2008/06/20  修正内容 : PM.NS対応(拠点コードを追加)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30462 行澤仁美
// 作 成 日  2008/10/06  修正内容 : バグ修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/06/01  修正内容 : 障害ID:13412、13413対応
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
	/// 得意先マスタ(伝票管理)マスタフォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 得意先マスタ(伝票管理)マスタの設定を行います。</br>
	/// <br>Programmer : 20081 疋田 勇人</br>
	/// <br>Date       : 2007.09.18</br>
	/// <br>Update Note: 2008.03.17  30167 上野　弘貴</br>
	/// <br>             ・データ入力システムを非表示
	///					 ・伝票印刷種別ワークシート, ボディ寸法図削除</br>
	/// <br>Update Note: 2008.03.28  30167 上野　弘貴</br>
	/// <br>             ・ゼロデータが表示されない不具合修正</br>
	/// <br>Update Note : 2008.03.31 30167 上野　弘貴</br>
	///	<br>			・得意先コードアクティブ時の表示不具合修正</br>
    /// <br></br>
    /// <br>Update Note : 2008.04.24 20056 對馬 大輔</br>
    ///	<br>			・PM.NS 共通修正 得意先・仕入先分離対応</br>
    /// <br>Update Note : 2008.06.20 30413 犬飼</br>
    /// <br>              ・PM.NS対応(拠点コードを追加)</br>
    /// <br>UpdateNote : 2008/10/06 30462 行澤 仁美　バグ修正</br>
    /// </remarks>
	public partial class DCKHN09130UA : Form, IMasterMaintenanceMultiType
	{
		// --------------------------------------------------
		#region Constructor

		/// <summary>
		/// 得意先マスタ(伝票管理)マスタフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 得意先マスタ(伝票管理)マスタフォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		public DCKHN09130UA()
		{
			InitializeComponent();

			// プロパティ初期値
			this._canClose = false;     // 閉じる機能(false固定)
			this._canDelete = true;     // 削除機能
			this._canLogicalDeleteDataExtraction = true;     // 論理削除データ表示機能
			this._canNew = true;                             // 新規作成機能
			this._canPrint = false;                          // 印刷機能
			this._canSpecificationSearch = false;            // 件数指定検索機能
			this._defaultAutoFillToColumn = true;            // 列サイズ自動調整機能

            // 2008.06.20 30413 犬飼 拠点コードガイドボタンの画像イメージ追加 >>>>>>START
            this.uButton_SectionGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            // 2008.06.20 30413 犬飼 拠点コードガイドボタンの画像イメージ追加 <<<<<<END

			this.uButton_CustomerGuide.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

			// 企業コード取得
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// インスタンス初期化
			this._custSlipMngAcs = new CustSlipMngAcs();

            // 2008.06.20 30413 犬飼 拠点コード追加 >>>>>>START
            this._secInfoSetAcs = new SecInfoSetAcs();
            // 2008.06.20 30413 犬飼 拠点コード追加 <<<<<<END

			this._customerInfoAcs = new CustomerInfoAcs();
            this._supplierAcs = new SupplierAcs(); // ADD 2008.04.24

			// グリッド選択インデックス
			this._dataIndex = -1;
			this._indexBuf = -2;
		}

		#endregion

		// --------------------------------------------------
		#region Private Members

		private string _enterpriseCode = "";           // 企業コード

		private CustSlipMngAcs _custSlipMngAcs = null;

        // 2008.06.20 30413 犬飼 拠点コード追加 >>>>>>START
        private SecInfoSetAcs _secInfoSetAcs = null;
        // 2008.06.20 30413 犬飼 拠点コード追加 <<<<<<END

		private CustomerInfoAcs _customerInfoAcs = null;
        private SupplierAcs _supplierAcs = null; // ADD 2008.04.24

		// メイン用クローンオブジェクト
		private CustSlipMng _custSlipMngClone = null;

		// _GridIndexバッファ（メインフレーム最小化対応）
		private int _dataIndex;
		private int _indexBuf;

		//----- h.ueno add ---------- start 2008.03.17
		private int _slipPrtKind_tComboEditorValue = -1;	// 伝票印刷種別コンボボックスデータワーク

        // 2008.06.20 30413 犬飼 拠点コード（ワーク）追加 >>>>>>START
        private int _sectionCodeWork = 0;
        // 2008.06.20 30413 犬飼 拠点コード（ワーク）追加 <<<<<<END

		// 得意先コード（ワーク）
		private int _customerCodeWork = 0;
		//----- h.ueno add ---------- end 2008.03.17

		// プロパティ用
		private bool _canClose;
		private bool _canDelete;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canNew;
		private bool _canPrint;
		private bool _canSpecificationSearch;
		private bool _defaultAutoFillToColumn;

		// 編集モード
		private int _editingMode = 0;
		private const int CT_EMODE_INSERT = -1;           // 新規モード
		private const int CT_EMODE_UPDATE = 0;            // 更新モード
		private const int CT_EMODE_DELETE = 1;            // 削除モード
		private const int CT_EMODE_REFER = 2;            // 参照モード
		private const string INSERT_MODE = "新規モード";
		private const string UPDATE_MODE = "更新モード";
		private const string DELETE_MODE = "削除モード";
		private const string REFER_MODE = "参照モード";

		// 画面レイアウト用定数
		private const int BUTTON_LOCATION1_X = 67;        // 完全削除ボタン位置X
		private const int BUTTON_LOCATION2_X = 194;      // 復活ボタン位置X
		private const int BUTTON_LOCATION3_X = 321;      // 保存ボタン位置X
		private const int BUTTON_LOCATION4_X = 448;      // 閉じるボタン位置X
		private const int BUTTON_LOCATION_Y = 9;        // ボタン位置Y(共通)

		// PG情報
		private const string CT_PGID = "DCKHN09130U";
		//private const string CT_PGNAME = "得意先マスタ(伝票管理)";
		private const string CT_CLASSNAME = "DCKHN09130UA";

		// Message関連定義
		private const string ERR_READ_MSG = "読み込みに失敗しました。";
		private const string ERR_DPR_MSG = "このコードは既に使用されています。";
		private const string ERR_RDEL_MSG = "削除に失敗しました。";
		private const string ERR_UPDT_MSG = "登録に失敗しました。";
		private const string ERR_RVV_MSG = "復活に失敗しました。";
		private const string ERR_800_MSG = "既に他端末より更新されています。";
		private const string ERR_801_MSG = "既に他端末より削除されています。";
		private const string SDC_RDEL_MSG = "マスタから削除されています。";

        //----- h.ueno add ---------- start 2008.03.17
		private const string CUSTOMER_COMMON = "共通";
		//----- h.ueno add ---------- end 2008.03.17

        // 全社共通の拠点コード
        private const string SECTION_COMMON_CODE = "00";    // ADD 2009/06/01

        // 2008.09.29 30413 犬飼 全社共通を追加 >>>>>>START
        private const string SECTION_COMMON = "全社共通";
        // 2008.09.29 30413 犬飼 全社共通を追加 <<<<<<END

		#endregion

		//----- h.ueno upd ---------- start 2008.03.17
		#region enum
		/// <summary>
		/// 入力エラーチェックステータス
		/// </summary>
		private enum InputChkStatus
		{
			// 未入力
			NotInput = -1,
			// 存在しない
			NotExist = -2,
			// 入力ミス
			InputErr = -3,
			// 正常
			Normal = 0,
			// キャンセル
			Cancel = 1,
			// 異なる
			Different
		}

		/// <summary>
		/// 画面データ設定ステータス
		/// </summary>
		private enum DispSetStatus
		{
			// クリア
			Clear = 0,
			// 更新
			Update = 1,
			// 元に戻す
			Back = 2
		}
		#endregion enum
		//----- h.ueno add---------- end 2008.03.17

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
		private delegate void GridMethodInvoker(int rowIndex, string columnName);

		#endregion

		// --------------------------------------------------
		#region Properties

		/// <summary>画面終了設定プロパティ</summary>
		/// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
		/// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
		public bool CanClose
		{
			get
			{
				return this._canClose;
			}
			set
			{
				this._canClose = value;
			}
		}

		/// <summary>削除可能設定プロパティ</summary>
		/// <value>削除が可能かどうかの設定を取得します。</value>
		public bool CanDelete
		{
			get
			{
				return this._canDelete;
			}
		}

		/// <summary>論理削除データ抽出可能設定プロパティ</summary>
		/// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
		public bool CanLogicalDeleteDataExtraction
		{
			get
			{
				return this._canLogicalDeleteDataExtraction;
			}
		}

		/// <summary>新規作成可能設定プロパティ</summary>
		/// <value>新規作成が可能かどうかの設定を取得します。</value>
		public bool CanNew
		{
			get
			{
				return this._canNew;
			}
		}

		/// <summary>印刷可能設定プロパティ</summary>
		/// <value>印刷が可能かどうかの設定を取得します。</value>
		public bool CanPrint
		{
			get
			{
				return this._canPrint;
			}
		}

		/// <summary>件数指定抽出可能設定プロパティ</summary>
		/// <value>件数指定抽出が可能かどうかの設定を取得します。</value>
		public bool CanSpecificationSearch
		{
			get
			{
				return this._canSpecificationSearch;
			}
		}

		/// <summary>データセットの選択データインデックスプロパティ</summary>
		/// <value>データセットの選択データインデックスを取得または設定します。</value>
		public int DataIndex
		{
			get
			{
				return this._dataIndex;
			}
			set
			{
				this._dataIndex = value;
			}
		}

		/// <summary>列のサイズの自動調整のデフォルト値プロパティ</summary>
		/// <value>列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
		public bool DefaultAutoFillToColumn
		{
			get
			{
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
		public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
		{
			bindDataSet = this._custSlipMngAcs.BindDataSet;
			tableName = CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE;
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
			appearanceTable.Add(CustSlipMngAcs.COL_DELETEDATE_TITLE,
				new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));

			//----- h.ueno upd ---------- start 2008.03.17 非表示にする
			// データ入力システム
			appearanceTable.Add(CustSlipMngAcs.COL_DATAINPUTSYSTEM_TITLE,
				new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			// データ入力システム名称
			appearanceTable.Add(CustSlipMngAcs.COL_DATAINPUTSYSTEMNAME_TITLE,
				new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			//----- h.ueno upd ---------- end 2008.03.17

			// 伝票印刷種別コード
			appearanceTable.Add(CustSlipMngAcs.COL_SLIPPRTKIND_TITLE,
				new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			// 伝票印刷種別名称
			appearanceTable.Add(CustSlipMngAcs.COL_SLIPPRTKINDNAME_TITLE,
				new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2008.06.20 30413 犬飼 拠点コード追加 >>>>>>START
            // 拠点コード
            appearanceTable.Add(CustSlipMngAcs.COL_SECTIONCODE_TITLE,
                new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(CustSlipMngAcs.COL_SECTIONNAME_TITLE,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2008.06.20 30413 犬飼 拠点コード追加 <<<<<<END
			// 得意先コード
			appearanceTable.Add(CustSlipMngAcs.COL_CUSTOMERCODE_TITLE,
				new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			// 得意先名称
			appearanceTable.Add(CustSlipMngAcs.COL_CUSTOMERNAME_TITLE,
				new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			// 帳票ID
            // DEL 2008/10/06 不具合対応[6222] ---------->>>>>              
            //appearanceTable.Add(CustSlipMngAcs.COL_SLIPPRTSETPAPERID_TITLE,
            //    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // DEL 2008/10/06 不具合対応[6222] ----------<<<<<
            // ADD 2008/10/06 不具合対応[6222] ---------->>>>>
            appearanceTable.Add(CustSlipMngAcs.COL_SLIPPRTSETPAPERID_TITLE,
                new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // 帳票ID(名称）                          
            appearanceTable.Add(CustSlipMngAcs.COL_SLIPPRTSETPAPERNAME_TITLE,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ADD 2008/10/06 不具合対応[6222] ----------<<<<<

			// GUID
			appearanceTable.Add(CustSlipMngAcs.COL_GUID_TITLE,
				new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

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
		public int Search(ref int totalCount, int readCount)
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
		public int SearchNext(int readCount)
		{
			// 未実装
			return (int)ConstantManagement.DB_Status.ctDB_EOF;
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
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			totalCount = 0;

			// 検索実行
			status = this._custSlipMngAcs.SearchAll(out totalCount, this._enterpriseCode);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						break;
					}
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
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
                            //CT_PGNAME,                          // プログラム名称
                            this.Name,                          // プログラム名称
							ctPROCNM,                           // 処理名称
							TMsgDisp.OPE_GET,                   // オペレーション
							ERR_READ_MSG,                       // 表示するメッセージ
							status,                             // ステータス値
							this._custSlipMngAcs,               // エラーが発生したオブジェクト
							MessageBoxButtons.OK,               // 表示するボタン
							MessageBoxDefaultButton.Button1);  // 初期表示ボタン
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
			if (this.ScreenDataCheck(ref control, ref message) == false)
			{
				// 入力チェック
				TMsgDisp.Show(
					this,                               // 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
					CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
					message,                            // 表示するメッセージ
					0,                                  // ステータス値
					MessageBoxButtons.OK);             // 表示するボタン

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
			CustSlipMng custSlipMng = new CustSlipMng();
			this.DispToCustSlipMng(ref custSlipMng);

			// 書き込み処理
			int status = 0;
			status = this._custSlipMngAcs.Write(custSlipMng);

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
							MessageBoxButtons.OK);         // 表示するボタン
						
						// 伝票印刷種別にフォーカスセット
						this.SlipPrtKind_tComboEditor.Focus();

						//----- h.ueno add ---------- start 2008.03.31
						// 拠点コードの先頭ゼロ詰めを削除
						this.tNedit_CustomerCode.Text = GetZeroPadCanceledTextProc(this.tNedit_CustomerCode.Text);
						//----- h.ueno add ---------- end 2008.03.31

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
                            //CT_PGNAME,                          // プログラム名称
                            this.Name,                          // プログラム名称
                            ctPROCNM,                           // 処理名称
							TMsgDisp.OPE_UPDATE,                // オペレーション
							ERR_UPDT_MSG,                       // 表示するメッセージ
							status,                             // ステータス値
							this._custSlipMngAcs,               // エラーが発生したオブジェクト
							MessageBoxButtons.OK,               // 表示するボタン
							MessageBoxDefaultButton.Button1);  // 初期表示ボタン
						this.CloseForm(DialogResult.Cancel);

						//----- h.ueno add ---------- start 2008.03.31
						// 拠点コードの先頭ゼロ詰めを削除
						this.tNedit_CustomerCode.Text = GetZeroPadCanceledTextProc(this.tNedit_CustomerCode.Text);
						//----- h.ueno add ---------- end 2008.03.31

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

			DataTable dt = this._custSlipMngAcs.BindDataSet.Tables[CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE];

			// グリッドが選択されていない時
			if ((this._dataIndex < 0) ||
				(this._dataIndex >= dt.Rows.Count))
			{
				return status;
			}

            // 2008.09.22 30413 犬飼 拠点が全社設定のデータは削除不可 >>>>>>START
            string sectionCode = (string)dt.DefaultView[this._dataIndex][CustSlipMngAcs.COL_SECTIONCODE_TITLE];
            int customerCode = (int)dt.DefaultView[this._dataIndex][CustSlipMngAcs.COL_CUSTOMERCODE_TITLE];
            //if ((sectionCode.TrimEnd() == "0") && (customerCode == 0))    // DEL 2009/06/01
            if ((sectionCode.TrimEnd() == SECTION_COMMON_CODE) && (customerCode == 0))  // ADD 2009/06/01
            {
                TMsgDisp.Show(this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    CT_PGID,
                    "全社設定のレコードは削除できません",
                    status,
                    MessageBoxButtons.OK);
                this.Hide();

                return -2;
            }

			// 選択データ取得
			Guid fileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][CustSlipMngAcs.COL_GUID_TITLE]; // GUID

			// 論理削除実行
			status = this._custSlipMngAcs.LogicalDelete(fileHeaderGuid);

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
                            //CT_PGNAME,                          // プログラム名称
                            this.Name,                          // プログラム名称
                            ctPROCNM,                           // 処理名称
							TMsgDisp.OPE_UPDATE,                // オペレーション
							ERR_RDEL_MSG,                       // 表示するメッセージ
							status,                             // ステータス値
							this._custSlipMngAcs,               // エラーが発生したオブジェクト
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

			DataTable dt = this._custSlipMngAcs.BindDataSet.Tables[CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE];

			// グリッドが選択されていない時
			if ((this._indexBuf < 0) ||
				(this._indexBuf >= dt.Rows.Count))
			{
				this.CloseForm(DialogResult.Cancel);
				return -1;
			}

			// 選択データ取得
			Guid fileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][CustSlipMngAcs.COL_GUID_TITLE]; // GUID

			// 論理削除復活実行
			status = this._custSlipMngAcs.Revival(fileHeaderGuid);

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
                            //CT_PGNAME,                          // プログラム名称
                            this.Name,                          // プログラム名称
                            ctPROCNM,                           // 処理名称
							TMsgDisp.OPE_UPDATE,                // オペレーション
							ERR_RVV_MSG,                        // 表示するメッセージ
							status,                             // ステータス値
							this._custSlipMngAcs,               // エラーが発生したオブジェクト
							MessageBoxButtons.OK,               // 表示するボタン
							MessageBoxDefaultButton.Button1);  // 初期表示ボタン
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

			DataTable dt = this._custSlipMngAcs.BindDataSet.Tables[CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE];

			// グリッドが選択されていない時
			if ((this._indexBuf < 0) ||
				(this._indexBuf >= dt.Rows.Count))
			{
				this.CloseForm(DialogResult.Cancel);
				return -1;
			}

			// 選択データ取得
			Guid fileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][CustSlipMngAcs.COL_GUID_TITLE]; // GUID

			// 物理削除実行
			status = this._custSlipMngAcs.Delete(fileHeaderGuid);

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
                            //CT_PGNAME,                          // プログラム名称
                            this.Name,                          // プログラム名称
                            ctPROCNM,                           // 処理名称
							TMsgDisp.OPE_DELETE,                // オペレーション
							ERR_RDEL_MSG,                       // 表示するメッセージ
							status,                             // ステータス値
							this._custSlipMngAcs,               // エラーが発生したオブジェクト
							MessageBoxButtons.OK,               // 表示するボタン
							MessageBoxDefaultButton.Button1);  // 初期表示ボタン
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
		/// <param name="custSlipMng">得意先マスタ(伝票管理)マスタオブジェクト</param>
		/// <remarks>
		/// <br>Note       : マスタ情報を画面に展開します。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void CustSlipMngToScreen(CustSlipMng custSlipMng)
		{
			// 新規モードの場合
			if (this._editingMode == CT_EMODE_INSERT)
			{
				this.DataInputSystemt_ComboEditor.SelectedIndex = 0; // システムタイプ(共通)
				
				//----- h.ueno upd ---------- start 2008.03.17
				//this.SlipPrtKind_tComboEditor.Clear();               // 伝票印刷種別コード
				this.SlipPrtKind_tComboEditor.SelectedIndex = 0;

				// コンボボックスフィルター設定（伝票印刷設定用帳票ID設定）
				if (this.SlipPrtKind_tComboEditor.Value != null)
				{
					SlipPrtKindVisibleChange((Int32)this.SlipPrtKind_tComboEditor.Value);
				}

                // 2008.09.22 30413 犬飼 設定種別の追加 >>>>>>START
                this.SetKind_tComboEditor.Value = 0;
                // 2008.09.22 30413 犬飼 設定種別の追加 <<<<<<END
            
                // 2008.06.20 30413 犬飼 拠点コード追加 >>>>>>START
                this.tEdit_SectionCodeAllowZero.Clear();            // 拠点コード
                this.SectionCodeNm_tEdit.Clear();                   // 拠点名称
                // 2008.06.20 30413 犬飼 拠点コード追加 <<<<<<END

				this.tNedit_CustomerCode.Clear();                   // 得意先コード
				this.CustomerCodeNm_tEdit.Clear();                  // 得意先名称
				//----- h.ueno upd ---------- end 2008.03.17
			}
			// 新規モード以外の場合
			else
			{
				this.DataInputSystemt_ComboEditor.Value = custSlipMng.DataInputSystem;// システムタイプ 
				this.SlipPrtKind_tComboEditor.Value = custSlipMng.SlipPrtKind;        // 伝票印刷種別コード

				//----- h.ueno upd ---------- start 2008.03.17
				// コンボボックスフィルター設定（伝票印刷設定用帳票ID設定）初期化されるので更新データの設定はこの後に行う
				SlipPrtKindVisibleChange(custSlipMng.SlipPrtKind);

                // 2008.09.22 30413 犬飼 設定種別の追加 >>>>>>START
                if (custSlipMng.CustomerCode == 0)
                {
                    // 得意先コードの設定無
                    this.SetKind_tComboEditor.Value = 0;

                    // 拠点
                    if (int.Parse(custSlipMng.SectionCode) == 0)
                    {
                        //this.tEdit_SectionCodeAllowZero.Text = "00";      // DEL 2009/06/01
                        this.tEdit_SectionCodeAllowZero.Text = SECTION_COMMON_CODE;     // ADD 2009/06/01
                        this.SectionCodeNm_tEdit.Text = SECTION_COMMON;
                    }
                    else
                    {
                        this.tEdit_SectionCodeAllowZero.Text = custSlipMng.SectionCode;             // 拠点コード
                        this.SectionCodeNm_tEdit.Text = GetSectionName(custSlipMng.SectionCode);    // 拠点名称
                    }

                    // 得意先は未設定とする
                    this.tNedit_CustomerCode.Clear();                   // 得意先コード
                    this.CustomerCodeNm_tEdit.Clear();                  // 得意先名称
                }
                else
                {
                    // 得意先コードの設定無
                    this.SetKind_tComboEditor.Value = 1;

                    // 拠点は未設定とする
                    this.tEdit_SectionCodeAllowZero.Clear();            // 拠点コード
                    this.SectionCodeNm_tEdit.Clear();                   // 拠点名称

                    // 得意先
                    this.tNedit_CustomerCode.SetInt(custSlipMng.CustomerCode);					// 得意先コード
                    this.CustomerCodeNm_tEdit.Text = custSlipMng.CustomerSnm;					// 得意先名称
                }
                // 2008.09.22 30413 犬飼 設定種別の追加 <<<<<<END

                // 2008.09.22 30413 犬飼 ↑の処理追加でコメント >>>>>>START
                //// 2008.06.20 30413 犬飼 拠点コード追加 >>>>>>START
                //if (custSlipMng.SectionCode.TrimEnd().Equals("0"))
                //{
                //    this.tEdit_SectionCodeAllowZero.Text = "";
                //    this.SectionCodeNm_tEdit.Text = "";
                //}
                //else
                //{
                //    this.tEdit_SectionCodeAllowZero.Text = custSlipMng.SectionCode;             // 拠点コード
                //    this.SectionCodeNm_tEdit.Text = GetSectionName(custSlipMng.SectionCode);    // 拠点名称
                //}
                //// 2008.06.20 30413 犬飼 拠点コード追加 <<<<<<END

                //this.tNedit_CustomerCode.SetInt(custSlipMng.CustomerCode);					// 得意先コード
                //this.CustomerCodeNm_tEdit.Text = custSlipMng.CustomerSnm;					// 得意先名称
                // 2008.09.22 30413 犬飼 ↑の処理追加でコメント <<<<<<END

                this.SlipPrtSetPaperId_tComboEditor.Value = custSlipMng.SlipPrtSetPaperId;	// 帳票ID
				//----- h.ueno upd ---------- end 2008.03.17
			}
			//----- h.ueno mov ---------- start 2008.03.17
			//this.SlipPrtSetPaperId_tEdit.Text = custSlipMng.SlipPrtSetPaperId;        // 帳票ID
			//----- h.ueno mov ---------- end 2008.03.17
		}

		/// <summary>
		/// 画面データ取得処理
		/// </summary>
		/// <param name="custSlipMng">得意先マスタ(伝票管理)マスタオブジェクト</param>
		/// <remarks>
		/// <br>Note       : 画面データの取得を行います</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void DispToCustSlipMng(ref CustSlipMng custSlipMng)
		{
			// 更新モードの場合
			if (this._editingMode == CT_EMODE_UPDATE)
			{
				// Guid
				DataTable dt = this._custSlipMngAcs.BindDataSet.Tables[CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE];
				custSlipMng.FileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][CustSlipMngAcs.COL_GUID_TITLE];
			}

			// 企業コード
			custSlipMng.EnterpriseCode = this._enterpriseCode;
			// システムタイプ
			if (this.DataInputSystemt_ComboEditor.SelectedIndex != -1)
			{
				custSlipMng.DataInputSystem = (int)this.DataInputSystemt_ComboEditor.Value;
			}
			// 伝票印刷種別コード
			if (this.SlipPrtKind_tComboEditor.SelectedIndex != -1)
			{
				custSlipMng.SlipPrtKind = (int)this.SlipPrtKind_tComboEditor.Value;
			}

            // 2008.09.22 30413 犬飼 設定種別の追加 >>>>>>START
            if (this.SetKind_tComboEditor.SelectedIndex == 0)
            {
                // 拠点単位
                // 拠点コード
                //if (this.tEdit_SectionCodeAllowZero.Text.TrimEnd() == "00")
                if (this.tEdit_SectionCodeAllowZero.Text.TrimEnd().PadLeft(2, '0') == SECTION_COMMON_CODE)
                {
                    // 全社設定
                    //custSlipMng.SectionCode = "0";    // DEL 2009/06/01
                    custSlipMng.SectionCode = SECTION_COMMON_CODE;  // ADD 2009/06/01
                }
                else
                {
                    // 全社設定以外
                    //custSlipMng.SectionCode = this.tEdit_SectionCodeAllowZero.Text.TrimEnd();     // DEL 2009/06/01
                    custSlipMng.SectionCode = this.tEdit_SectionCodeAllowZero.Text.TrimEnd().PadLeft(2, '0');   // ADD 2009/06/01
                }

                // 得意先コード
                custSlipMng.CustomerCode = 0;
            }
            else
            {
                // 拠点コード
                custSlipMng.SectionCode = "0";

                // 得意先コード
                custSlipMng.CustomerCode = this.tNedit_CustomerCode.GetInt();

                // ADD 2008/10/07 不具合対応[6221] ---------->>>>>
                // 得意先名称を設定
                custSlipMng.CustomerSnm = this.CustomerCodeNm_tEdit.Text;
                // ADD 2008/10/07 不具合対応[6221] ----------<<<<<

            }
            // 2008.09.22 30413 犬飼 設定種別の追加 <<<<<<END

            // 2008.09.22 30413 犬飼 設定種別の追加でコメント >>>>>>START
            //// 2008.06.20 30413 犬飼 拠点コード追加 >>>>>>START
            //// 拠点コード
            //if (this.tEdit_SectionCodeAllowZero.Text.TrimEnd().Equals(""))
            //{
            //    custSlipMng.SectionCode = "0";
            //}
            //else
            //{
            //    custSlipMng.SectionCode = this.tEdit_SectionCodeAllowZero.Text.TrimEnd();
            //}
            //// 2008.06.20 30413 犬飼 拠点コード追加 <<<<<<END

            ////----- h.ueno upd ---------- start 2008.03.17
            //// 得意先コード
            //custSlipMng.CustomerCode = this.tNedit_CustomerCode.GetInt();
            //// 得意先名称
            //custSlipMng.CustomerSnm = this.CustomerCodeNm_tEdit.Text.TrimEnd();
            // 2008.09.22 30413 犬飼 設定種別の追加でコメント <<<<<<END
            
            // 帳票ID
			custSlipMng.SlipPrtSetPaperId = (string)this.SlipPrtSetPaperId_tComboEditor.Value;
			//----- h.ueno upd ---------- end 2008.03.17
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
			this.DataInputSystemt_ComboEditor.SelectedIndex = -1;   // システムタイプ
			this.SlipPrtKind_tComboEditor.SelectedIndex = -1;       // 伝票種別

            // 2008.09.22 30413 犬飼 設定種別の追加 >>>>>>START
            this.SetKind_tComboEditor.Value = 0;
            // 2008.09.22 30413 犬飼 設定種別の追加 <<<<<<END
            
            // 2008.06.20 30413 犬飼 拠点コード追加 >>>>>>START
            this.tEdit_SectionCodeAllowZero.Clear();                // 拠点コード
            this.SectionCodeNm_tEdit.Clear();                       // 拠点名称
            // 2008.06.20 30413 犬飼 拠点コード追加 <<<<<<END

			this.tNedit_CustomerCode.Clear();                       // 得意先
			//----- h.ueno upd ---------- start 2008.03.17
			this.CustomerCodeNm_tEdit.Clear();                      // 得意先名 
			this.SlipPrtSetPaperId_tComboEditor.SelectedIndex = 0;	// 帳票ID
			_slipPrtKind_tComboEditorValue = -1;	                // 伝票印刷種別コンボボックスデータワーク
			//----- h.ueno upd ---------- end 2008.03.17
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
			CustSlipMng custSlipMng = new CustSlipMng();

			//----- h.ueno add ---------- start 2008.03.17				
			// 伝票印刷設定用帳票ID設定
			foreach (DictionaryEntry de in this._custSlipMngAcs._slipPrtSetPaperIdList)
			{
				SlipPrtSet slipPrtSetWk = (SlipPrtSet)de.Value;
				this.SlipPrtSetPaperId_tComboEditor.Items.Add(slipPrtSetWk.SlipPrtSetPaperId, slipPrtSetWk.SlipComment);
			}
			//----- h.ueno add ---------- end 2008.03.17

			// 新規の時
			if (this._dataIndex < 0)
			{
				// 新規モードに設定
				this._editingMode = CT_EMODE_INSERT;
				this.Mode_Label.Text = INSERT_MODE;

				// 画面に展開
				this.CustSlipMngToScreen(custSlipMng);
				
				// クローン作成
				this._custSlipMngClone = new CustSlipMng();
				this.DispToCustSlipMng(ref this._custSlipMngClone);

				// 画面入力許可制御設定
				this.ScreenInputPermissionControl(this._editingMode);

                // 2009.02.04 30413 犬飼 初期フォーカスを設定種別に設定 >>>>>>START
                this.SetKind_tComboEditor.Focus();
                // 2009.02.04 30413 犬飼 初期フォーカスを設定種別に設定 <<<<<<END
            }
			else
			{
				// フレームで選択されているレコードのオブジェクトを取得
				DataRowView dr = this._custSlipMngAcs.BindDataSet.Tables[CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE].DefaultView[this._dataIndex];

				if ((string)dr[CustSlipMngAcs.COL_DELETEDATE_TITLE] != "") // 削除日
				{
					custSlipMng.LogicalDeleteCode = 1;
				}
				custSlipMng.DataInputSystem = (int)dr[CustSlipMngAcs.COL_DATAINPUTSYSTEM_TITLE];        // システムタイプ
				custSlipMng.SlipPrtKind = (int)dr[CustSlipMngAcs.COL_SLIPPRTKIND_TITLE];                // 伝票印刷種別コード

                // 2008.06.20 30413 犬飼 拠点コード追加 >>>>>>START
                custSlipMng.SectionCode = (string)dr[CustSlipMngAcs.COL_SECTIONCODE_TITLE];             // 拠点コード
                // 2008.06.20 30413 犬飼 拠点コード追加 <<<<<<END

				custSlipMng.CustomerCode = (int)dr[CustSlipMngAcs.COL_CUSTOMERCODE_TITLE];              // 得意先コード
				custSlipMng.CustomerSnm = (string)dr[CustSlipMngAcs.COL_CUSTOMERNAME_TITLE];            // 得意先名
				custSlipMng.SlipPrtSetPaperId = (string)dr[CustSlipMngAcs.COL_SLIPPRTSETPAPERID_TITLE]; // 帳票ID

				// 更新モード
				if (custSlipMng.LogicalDeleteCode == 0)
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
				this.CustSlipMngToScreen(custSlipMng);

				// クローン作成
				this._custSlipMngClone = new CustSlipMng();
				this.DispToCustSlipMng(ref this._custSlipMngClone);

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
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void ScreenInputPermissionControl(int editingMode)
		{
			switch (editingMode)
			{
				// 新規モード
				case CT_EMODE_INSERT:
					{
						// 表示設定
						this.Delete_Button.Visible = false;		// 完全削除ボタン
						this.Revive_Button.Visible = false;		// 復活ボタン
						this.Ok_Button.Visible = true;			// 保存ボタン
                        // --- ADD 2009/03/26 残案件No.14対応------------------------------------------------------>>>>>
                        this.Renewal_Button.Visible = true;
                        // --- ADD 2009/03/26 残案件No.14対応------------------------------------------------------<<<<<
                        this.Cancel_Button.Visible = true;		// 閉じるボタン

						// 入力許可設定
						//----- h.ueno del ---------- start 2008.03.17
						//this.DataInputSystemt_ComboEditor.Enabled = true;
						//----- h.ueno del ---------- end 2008.03.17

                        // 2008.09.22 30413 犬飼 設定種別の追加 >>>>>>START
                        this.SetKind_tComboEditor.Enabled = true;
                        // 2008.09.22 30413 犬飼 設定種別の追加 <<<<<<END
                        
						this.SlipPrtKind_tComboEditor.Enabled = true;		// 伝票印刷種別コード

                        // 2008.06.20 30413 犬飼 拠点コード追加 >>>>>>START
                        this.tEdit_SectionCodeAllowZero.Enabled = true;              // 拠点コード
                        this.uButton_SectionGuide.Enabled = true;           // 拠点ガイド
                        // 2008.06.20 30413 犬飼 拠点コード追加 <<<<<<END

						this.tNedit_CustomerCode.Enabled = true;			// 得意先コード

						//----- h.ueno upd ---------- start 2008.03.17
						this.uButton_CustomerGuide.Enabled = true;			// 得意先ガイド
						this.SlipPrtSetPaperId_tComboEditor.Enabled = true;	// 帳票ID
						//----- h.ueno upd ---------- end 2008.03.17

						// 初期フォーカス設定
						this.DataInputSystemt_ComboEditor.Focus();
						this.DataInputSystemt_ComboEditor.SelectAll();
						break;
					}
				// 更新モード
				case CT_EMODE_UPDATE:
					{
						// 表示設定
						this.Delete_Button.Visible = false;		// 完全削除ボタン
						this.Revive_Button.Visible = false;		// 復活ボタン
						this.Ok_Button.Visible = true;			// 保存ボタン
                        // --- ADD 2009/03/26 残案件No.14対応------------------------------------------------------>>>>>
                        this.Renewal_Button.Visible = true;
                        // --- ADD 2009/03/26 残案件No.14対応------------------------------------------------------<<<<<
                        this.Cancel_Button.Visible = true;		// 閉じるボタン

						// 入力許可設定
						//----- h.ueno del ---------- start 2008.03.17
						//this.DataInputSystemt_ComboEditor.Enabled = true;
						//----- h.ueno del ---------- end 2008.03.17

                        // 2008.09.22 30413 犬飼 設定種別の追加 >>>>>>START
                        this.SetKind_tComboEditor.Enabled = false;
                        // 2008.09.22 30413 犬飼 設定種別の追加 <<<<<<END
                        
						//----- h.ueno upd ---------- start 2008.03.17
						this.SlipPrtKind_tComboEditor.Enabled = false;		// 伝票印刷種別コード

                        // 2008.06.20 30413 犬飼 拠点コード追加 >>>>>>START
                        this.tEdit_SectionCodeAllowZero.Enabled = false;             // 拠点コード
                        this.uButton_SectionGuide.Enabled = false;          // 拠点ガイド
                        // 2008.06.20 30413 犬飼 拠点コード追加 <<<<<<END

						this.tNedit_CustomerCode.Enabled = false;			// 得意先コード
						this.uButton_CustomerGuide.Enabled = false;			// 得意先ガイド
						this.SlipPrtSetPaperId_tComboEditor.Enabled = true;	// 帳票ID
						//----- h.ueno upd ---------- end 2008.03.17

						// 初期フォーカス設定
						//----- h.ueno upd ---------- start 2008.03.17
						this.SlipPrtSetPaperId_tComboEditor.Focus();
						//----- h.ueno upd ---------- end 2008.03.17
						break;
					}
				// 削除モード
				case CT_EMODE_DELETE:
					{
						// 表示設定
						this.Ok_Button.Visible = false;			// 保存ボタン
                        // --- ADD 2009/03/26 残案件No.14対応------------------------------------------------------>>>>>
                        this.Renewal_Button.Visible = false;
                        // --- ADD 2009/03/26 残案件No.14対応------------------------------------------------------<<<<<
                        this.Cancel_Button.Visible = true;		// 閉じるボタン

						this.Delete_Button.Visible = true;		// 完全削除ボタン
						this.Revive_Button.Visible = true;		// 復活ボタン
						this.Delete_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // 完全削除ボタン位置シフト
						this.Revive_Button.Location = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // 復活ボタン位置シフト

						// 入力許可設定
						//----- h.ueno del ---------- start 2008.03.17
						//this.DataInputSystemt_ComboEditor.Enabled = false;
						//----- h.ueno del ---------- end 2008.03.17

                        // 2008.09.22 30413 犬飼 設定種別の追加 >>>>>>START
                        this.SetKind_tComboEditor.Enabled = false;
                        // 2008.09.22 30413 犬飼 設定種別の追加 <<<<<<END
                        
						this.SlipPrtKind_tComboEditor.Enabled = false;			// 伝票印刷種別コード

                        // 2008.06.20 30413 犬飼 拠点コード追加 >>>>>>START
                        this.tEdit_SectionCodeAllowZero.Enabled = false;                 // 拠点コード
                        this.uButton_SectionGuide.Enabled = false;              // 拠点ガイド
                        // 2008.06.20 30413 犬飼 拠点コード追加 <<<<<<END

						this.tNedit_CustomerCode.Enabled = false;				// 得意先コード

						//----- h.ueno upd ---------- start 2008.03.17
						this.uButton_CustomerGuide.Enabled = false;				// 得意先ガイド
						this.SlipPrtSetPaperId_tComboEditor.Enabled = false;	// 帳票ID
						//----- h.ueno upd ---------- end 2008.03.17

						// 初期フォーカス設定
						this.Delete_Button.Focus();
						break;
					}
				// 参照モード
				case CT_EMODE_REFER:
					{
						// 表示設定
						this.Ok_Button.Visible = false;			// 保存ボタン
                        // --- ADD 2009/03/26 残案件No.14対応------------------------------------------------------>>>>>
                        this.Renewal_Button.Visible = false;
                        // --- ADD 2009/03/26 残案件No.14対応------------------------------------------------------<<<<<
                        this.Cancel_Button.Visible = true;		// 閉じるボタン
						this.Revive_Button.Visible = false;		// 復活ボタン
						this.Delete_Button.Visible = false;		// 完全削除ボタン

						// 入力許可設定
						//----- h.ueno del ---------- start 2008.03.17
						//this.DataInputSystemt_ComboEditor.Enabled = false;
						//----- h.ueno del ---------- end 2008.03.17

                        // 2008.09.22 30413 犬飼 設定種別の追加 >>>>>>START
                        this.SetKind_tComboEditor.Enabled = false;
                        // 2008.09.22 30413 犬飼 設定種別の追加 <<<<<<END
                        
						this.SlipPrtKind_tComboEditor.Enabled = false;			// 伝票印刷種別コード

                        // 2008.06.20 30413 犬飼 拠点コード追加 >>>>>>START
                        this.tEdit_SectionCodeAllowZero.Enabled = false;                 // 拠点コード
                        this.uButton_SectionGuide.Enabled = false;              // 拠点ガイド
                        // 2008.06.20 30413 犬飼 拠点コード追加 <<<<<<END

						this.tNedit_CustomerCode.Enabled = false;				// 得意先コード

						//----- h.ueno del ---------- start 2008.03.17
						this.uButton_CustomerGuide.Enabled = false;				// 得意先ガイド
						this.SlipPrtSetPaperId_tComboEditor.Enabled = false;	// 帳票ID
						//----- h.ueno del ---------- end 2008.03.17

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
		private void ExclusiveTransaction(int status, bool hide)
		{
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					{
						// 他端末更新
						TMsgDisp.Show(
							this,                               // 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
							CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
							ERR_800_MSG,                        // 表示するメッセージ
							0,                                  // ステータス値
							MessageBoxButtons.OK);             // 表示するボタン
						if (hide == true)
						{
							this.CloseForm(DialogResult.Cancel);
						}
						break;
					}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						// 他端末削除
						TMsgDisp.Show(
							this,                               // 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
							CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
							ERR_801_MSG,                        // 表示するメッセージ
							0,                                  // ステータス値
							MessageBoxButtons.OK);             // 表示するボタン
						if (hide == true)
						{
							this.CloseForm(DialogResult.Cancel);
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
		private void CloseForm(DialogResult dialogResult)
		{
			// 画面非表示イベント
			if (this.UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
				this.UnDisplaying(this, me);
			}

			this.DialogResult = dialogResult;

			// GridIndexバッファ初期化
			this._indexBuf = -2;

			// CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
			// フォームを非表示化する。
			if (this._canClose == true)
			{
				this.Close();
			}
			else
			{
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
		private bool ScreenDataCheck(ref Control control, ref string message)
		{
			bool result = true;

			//----- h.ueno del ---------- start 2008.03.17
			//if (this.SlipPrtSetPaperId_tEdit.Text.TrimEnd() == "")
			//{
			//    message = this.SlipPrtSetPaperId_Title_Label.Text + "を入力してください。";
			//    control = this.SlipPrtSetPaperId_tEdit;
			//    result = false;
			//}
			//// 伝票印刷設定
			//else if (this.SlipPrtKind_tComboEditor.SelectedIndex == -1)
			//{
			//    message = this.SlipPrtKind_Title_Label.Text + "を選択して下さい。";
			//    control = this.SlipPrtKind_tComboEditor;
			//    result = false;
			//}
			//else if (this.DataInputSystemt_ComboEditor.SelectedIndex == -1)
			//{
			//    message = this.ultraLabel1.Text + "を選択して下さい。";
			//    control = this.DataInputSystemt_ComboEditor;
			//    result = false;
			//}
			//----- h.ueno del ---------- end 2008.03.17

			//----- ueno add---------- start 2008.03.17
            // 2009.02.04 30413 犬飼 拠点と得意先の入力チェックを修正 >>>>>>START
            //DispSetStatus dispSetStatus = DispSetStatus.Clear;

            //bool canChangeFocus = true;	// ここでは未使用
            // 2009.02.04 30413 犬飼 拠点と得意先の入力チェックを修正 <<<<<<END
            
			object inParamObj = null;
			object outParamObj = null;
			ArrayList inParamList = null;

            // 2008.09.22 30413 犬飼 拠点と得意先のチェックを変更 >>>>>>START
            if (this.SetKind_tComboEditor.SelectedIndex == 0)
            {
                // 拠点単位
                if (this.tEdit_SectionCodeAllowZero.Enabled == true)
                {
                    // 条件設定クリア
                    inParamObj = null;
                    outParamObj = null;

                    // 2009.02.04 30413 犬飼 拠点の入力チェックを修正 >>>>>>START
                    //// 拠点が未入力または「0」の場合
                    //if ((this.tEdit_SectionCodeAllowZero.Text.Equals("")) || (this.tEdit_SectionCodeAllowZero.Text == "00"))
                    //{
                    //    this.tEdit_SectionCodeAllowZero.Text = "00";
                    //    //sectionCodeFlg = false;
                    //}
                    //else
                    //{
                    //    // 条件設定
                    //    inParamObj = this.tEdit_SectionCodeAllowZero.Text;

                    //    // 拠点名称取得
                    //    outParamObj = GetSectionName((string)inParamObj);

                    //    // 拠点名称の存在チェック
                    //    if (outParamObj.Equals(""))
                    //    {
                    //        message = "指定された条件で、拠点コードは存在しませんでした。";
                    //        control = this.tEdit_SectionCodeAllowZero;
                    //        this.tEdit_SectionCodeAllowZero.Text = this._sectionCodeWork.ToString();
                    //        return false;
                    //    }

                    //    // データ設定
                    //    this.SectionCodeNm_tEdit.Text = (string)outParamObj;
                    //}
                    // 2009.04.02 30413 犬飼 全社設定のチェック修正 >>>>>>START
                    //if (this.tEdit_SectionCodeAllowZero.Text.Equals(""))
                    if ((this.tEdit_SectionCodeAllowZero.Text.Equals("")) ||
                        //(this.tEdit_SectionCodeAllowZero.Text.TrimEnd().PadLeft(2, '0') == "00"))     // DEL 2009/06/01
                        (this.tEdit_SectionCodeAllowZero.Text.TrimEnd().PadLeft(2, '0') == SECTION_COMMON_CODE))    // ADD 2009/06/01
                    // 2009.04.02 30413 犬飼 全社設定のチェック修正 <<<<<<END
                    {
                        // 未入力時は全社設定
                        //this.tEdit_SectionCodeAllowZero.Text = "00";      // DEL 2009/06/01
                        this.tEdit_SectionCodeAllowZero.Text = SECTION_COMMON_CODE;     // ADD 2009/06/01
                        this.SectionCodeNm_tEdit.Text = SECTION_COMMON;
                    }
                    else
                    {
                        // 条件設定
                        inParamObj = this.tEdit_SectionCodeAllowZero.Text;

                        // 拠点名称取得
                        outParamObj = GetSectionName((string)inParamObj);

                        // 拠点名称の存在チェック
                        if (outParamObj.Equals(""))
                        {
                            message = "拠点コードが存在しません。";
                            control = this.tEdit_SectionCodeAllowZero;
                            return false;
                        }
                    }
                    // 2009.02.04 30413 犬飼 拠点の入力チェックを修正 <<<<<<END
                }
            }
            else
            {
                // 得意先単位
                if (this.tNedit_CustomerCode.Enabled == true)
                {
                    // 条件設定クリア
                    inParamObj = null;
                    outParamObj = null;
                    inParamList = new ArrayList();

                    // 2009.02.04 30413 犬飼 得意先の入力チェックを修正 >>>>>>START
                    //dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用

                    // 条件設定
                    inParamObj = this.tNedit_CustomerCode.GetInt();

                    // サーチモード決定(伝票印刷種別により変化)
                    int searchMode = PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY;
                    if (this.SlipPrtKind_tComboEditor.Value != null)
                    {
                        searchMode = JudgeCallCustmerGuide((Int32)this.SlipPrtKind_tComboEditor.Value);
                    }

                    //if (searchMode == PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY)
                    //{
                    //    // 存在チェック
                    //    switch (CheckCustomerCode(inParamObj, out outParamObj))
                    //    {
                    //        case (int)InputChkStatus.Normal:
                    //            {
                    //                dispSetStatus = DispSetStatus.Update;
                    //                break;
                    //            }
                    //        case (int)InputChkStatus.NotInput:
                    //            {
                    //                message = "得意先コードを入力してください。";
                    //                dispSetStatus = DispSetStatus.Clear;
                    //                break;
                    //            }
                    //        default:
                    //            {
                    //                message = "指定された条件で、得意先コードは存在しませんでした。";

                    //                // 共通コードが判定
                    //                if ((this._customerCodeWork == 0) && (this.CustomerCodeNm_tEdit.Text == CUSTOMER_COMMON))
                    //                {
                    //                    dispSetStatus = DispSetStatus.Back;
                    //                }
                    //                else
                    //                {
                    //                    dispSetStatus = this._customerCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
                    //                }
                    //                break;
                    //            }
                    //    }
                    //}
                    //else
                    //{
                    //    // 存在チェック
                    //    switch (CheckSupplierCode(inParamObj, out outParamObj))
                    //    {
                    //        case (int)InputChkStatus.Normal:
                    //            {
                    //                dispSetStatus = DispSetStatus.Update;
                    //                break;
                    //            }
                    //        case (int)InputChkStatus.NotInput:
                    //            {
                    //                message = "仕入先コードを入力してください。";
                    //                dispSetStatus = DispSetStatus.Clear;
                    //                break;
                    //            }
                    //        default:
                    //            {
                    //                message = "指定された条件で、仕入先コードは存在しませんでした。";

                    //                // 共通コードが判定
                    //                if ((this._customerCodeWork == 0) && (this.CustomerCodeNm_tEdit.Text == CUSTOMER_COMMON))
                    //                {
                    //                    dispSetStatus = DispSetStatus.Back;
                    //                }
                    //                else
                    //                {
                    //                    dispSetStatus = this._customerCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
                    //                }
                    //                break;
                    //            }
                    //    }
                    //}


                    //// データ設定
                    //DispSetCustomerCode(dispSetStatus, ref canChangeFocus, outParamObj);

                    //if (dispSetStatus != DispSetStatus.Update)
                    //{
                    //    control = this.tNedit_CustomerCode;
                    //    return false;
                    //}

                    if (searchMode == PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY)
                    {
                        this.CheckCustomerCode(inParamObj, out outParamObj);
                    }
                    else
                    {
                        this.CheckSupplierCode(inParamObj, out outParamObj);
                    }
                    // 得意先名の設定
                    if ((outParamObj != null) &&
                        (((ArrayList)outParamObj).Count == 2) &&
                        (((ArrayList)outParamObj)[1] is string))
                    {
                        ;
                    }
                    else
                    {
                        message = "得意先コードが存在しません。";
                        control = this.tNedit_CustomerCode;
                        return false;
                    }
                    // 2009.02.04 30413 犬飼 得意先の入力チェックを修正 <<<<<<END
                }
            }
            // 2008.09.22 30413 犬飼 拠点と得意先のチェックを変更 <<<<<<END
            
            // 2008.06.20 30413 犬飼 拠点コード追加 >>>>>>START
            //bool sectionCodeFlg = true;

            //// 拠点コード
            //if (this.tEdit_SectionCodeAllowZero.Enabled == true)
            //{
            //    // 条件設定クリア
            //    inParamObj = null;
            //    outParamObj = null;

            //    // 拠点が未入力または「0」の場合
            //    if ((this.tEdit_SectionCodeAllowZero.Text.Equals("")) || (this.tEdit_SectionCodeAllowZero.Text.Equals("0")))
            //    {
            //        sectionCodeFlg = false;
            //    }
            //    else
            //    {
            //        // 条件設定
            //        inParamObj = this.tEdit_SectionCodeAllowZero.Text;

            //        // 拠点名称取得
            //        outParamObj = GetSectionName((string)inParamObj);

            //        // 拠点名称の存在チェック
            //        if (outParamObj.Equals(""))
            //        {
            //            message = "指定された条件で、拠点コードは存在しませんでした。";
            //            control = this.tEdit_SectionCodeAllowZero;
            //            this.tEdit_SectionCodeAllowZero.Text = this._sectionCodeWork.ToString();
            //            return false;
            //        }

            //        // データ設定
            //        this.SectionCodeNm_tEdit.Text = (string)outParamObj;
            //    }
            //}
            //// 2008.06.20 30413 犬飼 拠点コード追加 <<<<<<END

            ////------------------------
            //// 得意先コードチェック
            ////------------------------
            //// 2008.06.20 30413 犬飼 拠点コードチェックとの関連を追加 >>>>>>START
            //if (this.tNedit_CustomerCode.Enabled == true)
            //{
            //    // 条件設定クリア
            //    inParamObj = null;
            //    outParamObj = null;
            //    inParamList = new ArrayList();

            //    dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用
                
            //    // 拠点コードが未入力の場合はチェックを行う
            //    if (sectionCodeFlg == false)
            //    {
            //        // 「0」の場合、共通とする
            //        if ((this.tNedit_CustomerCode.Text != "") && (this.tNedit_CustomerCode.GetInt() == 0))
            //        {
            //            // 2008.06.20 30413 犬飼 得意先名称への"共通"の設定コメント >>>>>>START
            //            //this.CustomerCodeNm_tEdit.Text = CUSTOMER_COMMON;
            //            // 2008.06.20 30413 犬飼 得意先名称への"共通"の設定コメント <<<<<<END
            //            this._customerCodeWork = 0;

            //            return true;
            //        }

            //        // 条件設定
            //        inParamObj = this.tNedit_CustomerCode.GetInt();

            //        // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //        //// 存在チェック
            //        //switch (CheckCustomerSupplierCode(inParamObj, out outParamObj))
            //        //{
            //        //    case (int)InputChkStatus.Normal:
            //        //        {
            //        //            dispSetStatus = DispSetStatus.Update;
            //        //            break;
            //        //        }
            //        //    case (int)InputChkStatus.NotInput:
            //        //        {
            //        //            message = "得意先コードを入力してください。";
            //        //            dispSetStatus = DispSetStatus.Clear;
            //        //            break;
            //        //        }
            //        //    default:
            //        //        {
            //        //            message = "指定された条件で、得意先コードは存在しませんでした。";

            //        //            //----- h.ueno add---------- start 2008.03.31
            //        //            // 共通コードが判定
            //        //            if ((this._customerCodeWork == 0)&&(this.CustomerCodeNm_tEdit.Text == CUSTOMER_COMMON))
            //        //            {
            //        //                dispSetStatus = DispSetStatus.Back;
            //        //            }
            //        //            else
            //        //            {
            //        //                dispSetStatus = this._customerCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
            //        //            }
            //        //            //----- h.ueno add---------- end 2008.03.31

            //        //            break;
            //        //        }
            //        //}


            //        // サーチモード決定(伝票印刷種別により変化)
            //        // 2008.06.20 30413 犬飼 得意先ガイド表示のアセンブリ参照を変更 >>>>>>START
            //        //int searchMode = PMKHN04001UA.SEARCHMODE_CUSTOMER_ONLY;
            //        int searchMode = PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY;
            //        // 2008.06.20 30413 犬飼 得意先ガイド表示のアセンブリ参照を変更 <<<<<<END
            //        if (this.SlipPrtKind_tComboEditor.Value != null) searchMode = JudgeCallCustmerGuide((Int32)this.SlipPrtKind_tComboEditor.Value);

            //        // 2008.06.20 30413 犬飼 得意先ガイド表示のアセンブリ参照を変更 >>>>>>START
            //        //if (searchMode == PMKHN04001UA.SEARCHMODE_CUSTOMER_ONLY)
            //        if (searchMode == PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY)
            //        // 2008.06.20 30413 犬飼 得意先ガイド表示のアセンブリ参照を変更 <<<<<<END
            //        {
            //            // 存在チェック
            //            switch (CheckCustomerCode(inParamObj, out outParamObj))
            //            {
            //                case (int)InputChkStatus.Normal:
            //                    {
            //                        dispSetStatus = DispSetStatus.Update;
            //                        break;
            //                    }
            //                case (int)InputChkStatus.NotInput:
            //                    {
            //                        message = "得意先コードを入力してください。";
            //                        dispSetStatus = DispSetStatus.Clear;
            //                        break;
            //                    }
            //                default:
            //                    {
            //                        message = "指定された条件で、得意先コードは存在しませんでした。";

            //                        // 共通コードが判定
            //                        if ((this._customerCodeWork == 0) && (this.CustomerCodeNm_tEdit.Text == CUSTOMER_COMMON))
            //                        {
            //                            dispSetStatus = DispSetStatus.Back;
            //                        }
            //                        else
            //                        {
            //                            dispSetStatus = this._customerCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
            //                        }
            //                        break;
            //                    }
            //            }
            //        }
            //        else
            //        {
            //            // 存在チェック
            //            switch (CheckSupplierCode(inParamObj, out outParamObj))
            //            {
            //                case (int)InputChkStatus.Normal:
            //                    {
            //                        dispSetStatus = DispSetStatus.Update;
            //                        break;
            //                    }
            //                case (int)InputChkStatus.NotInput:
            //                    {
            //                        message = "仕入先コードを入力してください。";
            //                        dispSetStatus = DispSetStatus.Clear;
            //                        break;
            //                    }
            //                default:
            //                    {
            //                        message = "指定された条件で、仕入先コードは存在しませんでした。";

            //                        // 共通コードが判定
            //                        if ((this._customerCodeWork == 0) && (this.CustomerCodeNm_tEdit.Text == CUSTOMER_COMMON))
            //                        {
            //                            dispSetStatus = DispSetStatus.Back;
            //                        }
            //                        else
            //                        {
            //                            dispSetStatus = this._customerCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
            //                        }
            //                        break;
            //                    }
            //            }
            //        }

            //        // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            //        // データ設定
            //        DispSetCustomerCode(dispSetStatus, ref canChangeFocus, outParamObj);

            //        if (dispSetStatus != DispSetStatus.Update)
            //        {
            //            control = this.tNedit_CustomerCode;
            //            return false;
            //        }
            //    }
            //    // 拠点コードが入力されている場合は、得意先が未入力かチェックを行う
            //    else
            //    {
            //        if (!this.tNedit_CustomerCode.Text.Equals(""))
            //        {
            //            message = "拠点コードが入力されている場合、得意先コードは入力できません。";
            //            control = this.tNedit_CustomerCode;
            //        }
            //    }
            //}
            // 2008.06.20 30413 犬飼 拠点コードチェックとの関連を追加 <<<<<<END
			
			//------------------------------
			// 伝票印刷設定用帳票IDチェック
			//------------------------------
			if(this.SlipPrtSetPaperId_tComboEditor.SelectedIndex == -1)
			{
				if (this.SlipPrtSetPaperId_tComboEditor.Items.Count > 0)
				{
					message = "伝票印刷設定用帳票IDが選択されていません。";
				}
				else
				{
					message = "伝票印刷設定用帳票IDが存在しません。" +
								"\n\n伝票印刷設定画面でデータを追加してください。";
				}
				control = this.SlipPrtSetPaperId_tComboEditor;
				return false;
			}
			//----- ueno add---------- end 2008.03.17
			
			return result;
		}

		//----- h.ueno upd ---------- start 2008.03.17
		#region SlipPrtKindVisibleChange
		/// <summary>
		/// 伝票印刷種別表示変更
		/// </summary>
		/// <param name="slipPrtKind">伝票印刷種別</param>
		/// <remarks>
		/// <br>Note　     : 伝票印刷種別の選択を変更したときに発生します。</br>
		/// <br>			 伝票印刷種別の値によって伝票印刷設定用帳票IDコンボボックス表示を制御します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2008.03.17</br>
		/// </remarks>
		private void SlipPrtKindVisibleChange(int slipPrtKind)
		{
			try
			{
				if (this._slipPrtKind_tComboEditorValue == slipPrtKind) return;

				//-------------------------------------------------
				// 得意先コード判定（仕入先or得意先）
				// （得意先コードは伝票印刷種別によって決まるため）
				//-------------------------------------------------
				// ワークデータと現在選択中のデータが同じモードかチェック
				int workSearch = JudgeCallCustmerGuide(this._slipPrtKind_tComboEditorValue);
				int search = JudgeCallCustmerGuide(slipPrtKind);
				
				if (workSearch != search)
				{
					this.tNedit_CustomerCode.Clear();	// 得意先コード
					this.CustomerCodeNm_tEdit.Clear();	// 得意先名称
				}
				
				//--------------------------
				// 伝票印刷設定用帳票ID設定
				//--------------------------
				this.SlipPrtSetPaperId_tComboEditor.BeginUpdate();

				// コンボボックスアイテムクリア
				this.SlipPrtSetPaperId_tComboEditor.Items.Clear();	// 一度クリアする

				// 伝票印刷設定用帳票ID再設定
				foreach (DictionaryEntry de in this._custSlipMngAcs._slipPrtSetPaperIdList)
				{
					SlipPrtSet slipPrtSetWk = (SlipPrtSet)de.Value;
					
					if (slipPrtSetWk.SlipPrtKind == slipPrtKind)
					{
						this.SlipPrtSetPaperId_tComboEditor.Items.Add(slipPrtSetWk.SlipPrtSetPaperId, slipPrtSetWk.SlipComment);
					}
				}

				// 先頭データを表示する
				if (this.SlipPrtSetPaperId_tComboEditor.Items.Count > 0)
				{
					this.SlipPrtSetPaperId_tComboEditor.Value = this.SlipPrtSetPaperId_tComboEditor.Items[0].DataValue;
				}
				this.SlipPrtSetPaperId_tComboEditor.EndUpdate();

				// 選択した番号を保持
				this._slipPrtKind_tComboEditorValue = slipPrtKind;
			}
			catch
			{
			}
		}
		#endregion SlipPrtKindVisibleChange

		#region 得意先・仕入先コードエラーチェック処理
        // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// 得意先・仕入先コードエラーチェック処理
        ///// </summary>
        ///// <param name="inParamObj">条件オブジェクト</param>
        ///// <param name="outParamObj">結果オブジェクト</param>
        ///// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
        ///// <remarks>
        ///// <br>Note       : 得意先・仕入先コードエラーチェックを行います。
        /////					 条件オブジェクト:得意先コード
        /////					 結果オブジェクト:得意先マスタ検索結果ステータス, 得意先名称</br>
        ///// <br>Programmer : 30167 上野　弘貴</br>
        ///// <br>Date       : 2008.03.17</br>
        ///// </remarks>
        //private int CheckCustomerCode(object inParamObj, out object outParamObj)
        //{
        //    outParamObj = null;
        //    ArrayList outParamList = new ArrayList();
        //    int ret = (int)InputChkStatus.NotInput;
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

        //    try
        //    {
        //        //------------------
        //        // 必須入力チェック
        //        //------------------
        //        if (inParamObj == null) return ret;
        //        if ((inParamObj is int) == false) return ret;
        //        if ((int)inParamObj == 0) return ret;

        //        //--------------
        //        // 存在チェック
        //        //--------------
        //        CustomerInfo customerInfo = null;

        //        this.Cursor = Cursors.WaitCursor;
        //        ret = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, (int)inParamObj, out customerInfo);
        //        this.Cursor = Cursors.Default;

        //        outParamList.Add(status);	// 得意先マスタステータス設定

        //        // 入力データ判定
        //        if (customerInfo != null)
        //        {
        //            //----------------------------------------
        //            // 伝票印刷種別によって得意先、仕入先判定
        //            //----------------------------------------
        //            int searchMode = SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY;	// 得意先設定
					
        //            // 伝票印刷種別によって呼び出しを分ける
        //            if (this.SlipPrtKind_tComboEditor.Value != null)
        //            {
        //                // 得意先ガイド呼び出し判定
        //                searchMode = JudgeCallCustmerGuide((Int32)this.SlipPrtKind_tComboEditor.Value);
        //            }
					
        //            // 得意先モードの場合
        //            if (searchMode == SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY)
        //            {
        //                // 選択データが得意先でない場合
        //                if (customerInfo.IsCustomer == false)
        //                {
        //                    TMsgDisp.Show(
        //                            this, 													// 親ウィンドウフォーム
        //                            emErrorLevel.ERR_LEVEL_INFO, 							// エラーレベル
        //                            this.Name,												// アセンブリID
        //                            "得意先データを入力してください。",						// 表示するメッセージ
        //                            0,														// ステータス値
        //                            MessageBoxButtons.OK);									// 表示するボタン

        //                    ret = (int)InputChkStatus.Different;

        //                    return ret;
        //                }
        //            }
        //            // 仕入先モードでガイドを起動した場合
        //            else
        //            {
        //                // 選択データが仕入先でない場合
        //                if (customerInfo.IsSupplier == false)
        //                {
        //                    TMsgDisp.Show(
        //                            this, 													// 親ウィンドウフォーム
        //                            emErrorLevel.ERR_LEVEL_INFO, 							// エラーレベル
        //                            this.Name,												// アセンブリID
        //                            "仕入先データを入力してください。",							// 表示するメッセージ
        //                            0,														// ステータス値
        //                            MessageBoxButtons.OK);									// 表示するボタン
							
        //                    ret = (int)InputChkStatus.Different;

        //                    return ret;
        //                }
        //            }
					
        //            ret = (int)InputChkStatus.Normal;
        //            outParamList.Add(customerInfo.CustomerSnm);	// 得意先略称設定
        //        }
        //        else
        //        {
        //            ret = (int)InputChkStatus.NotExist;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    outParamObj = outParamList;

        //    return ret;
        //}

        /// <summary>
        /// 得意先コードエラーチェック処理
        /// </summary>
        /// <param name="inParamObj">条件オブジェクト</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <returns>チェック結果（0:正常 0以外:エラー）</returns>
        /// <remarks>
        /// <br>Note       : 得意先コードエラーチェックを行います。</br>
        ///	<br>			 条件オブジェクト:得意先コード</br>
        ///	<br>			 結果オブジェクト:得意先マスタ検索結果ステータス, 得意先名称</br>
        /// </remarks>
        private int CheckCustomerCode(object inParamObj, out object outParamObj)
        {
            //-------------------------------------------------------------
            // 初期値設定
            //-------------------------------------------------------------
            outParamObj = null;
            ArrayList outParamList = new ArrayList();
            int ret = (int)InputChkStatus.NotInput;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                //-------------------------------------------------------------
                // 実行チェック
                //-------------------------------------------------------------
                if (inParamObj == null) return ret;             // 入力なし
                if ((inParamObj is int) == false) return ret;   // 入力値Ｉｎｔ以外
                if ((int)inParamObj == 0) return ret;           // 入力値ゼロ

                //-------------------------------------------------------------
                // 得意先マスタ読込
                //-------------------------------------------------------------
                CustomerInfo customerInfo = null;
                this.Cursor = Cursors.WaitCursor;
                ret = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, (int)inParamObj, out customerInfo);
                this.Cursor = Cursors.Default;

                outParamList.Add(status);	// 得意先マスタステータス設定

                //-------------------------------------------------------------
                // 得意先情報設定
                //-------------------------------------------------------------
                if (customerInfo != null)
                {
                    ret = (int)InputChkStatus.Normal;
                    outParamList.Add(customerInfo.CustomerSnm);	// 得意先略称設定
                }
                else
                {
                    ret = (int)InputChkStatus.NotExist;
                }
            }
            catch (Exception)
            {
            }
            outParamObj = outParamList;

            return ret;
        }
        // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        // ADD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 仕入先コードエラーチェック処理
        /// </summary>
        /// <param name="inParamObj">条件オブジェクト</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <returns>チェック結果（0:正常 0以外:エラー）</returns>
        /// <remarks>
        /// <br>Note       : 仕入先コードエラーチェックを行います。</br>
        ///	<br>			 条件オブジェクト:仕入先コード</br>
        ///	<br>			 結果オブジェクト:仕入先マスタ検索結果ステータス, 仕入先名称</br>
        /// </remarks>
        private int CheckSupplierCode(object inParamObj, out object outParamObj)
        {
            //-------------------------------------------------------------
            // 初期値設定
            //-------------------------------------------------------------
            outParamObj = null;
            ArrayList outParamList = new ArrayList();
            int ret = (int)InputChkStatus.NotInput;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                //-------------------------------------------------------------
                // 実行チェック
                //-------------------------------------------------------------
                if (inParamObj == null) return ret;             // 入力なし
                if ((inParamObj is int) == false) return ret;   // 入力値Ｉｎｔ以外
                if ((int)inParamObj == 0) return ret;           // 入力値ゼロ

                //-------------------------------------------------------------
                // 仕入先マスタ読込
                //-------------------------------------------------------------
                Supplier supplier = null;
                this.Cursor = Cursors.WaitCursor;
                ret = this._supplierAcs.Read(out supplier, this._enterpriseCode, (int)inParamObj);
                this.Cursor = Cursors.Default;

                outParamList.Add(status);

                //-------------------------------------------------------------
                // 仕入先情報設定
                //-------------------------------------------------------------
                if (supplier != null)
                {
                    ret = (int)InputChkStatus.Normal;
                    outParamList.Add(supplier.SupplierSnm);	// 仕入先略称設定
                }
                else
                {
                    ret = (int)InputChkStatus.NotExist;
                }
            }
            catch (Exception)
            {
            }
            outParamObj = outParamList;

            return ret;
        }
        // ADD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		#endregion 得意先・仕入先コードエラーチェック処理

		#region 得意先コード設定処理
		/// <summary>
		/// 得意先コード設定処理
		/// </summary>
		/// <param name="dispSetStatus">入力チェックフラグ</param>
		/// <param name="canChangeFocus">フォーカスフラグ</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 得意先コードを画面に設定します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.03.17</br>
		/// </remarks>
		private void DispSetCustomerCode(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
		{
			ArrayList outParamList = null;

			try
			{
				switch (dispSetStatus)
				{
					case DispSetStatus.Clear:	// データクリア
						{
							this.tNedit_CustomerCode.Clear();
							this.CustomerCodeNm_tEdit.Clear();

							// 現在データクリア
							this._customerCodeWork = 0;

							// フォーカス
							canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
							break;
						}
					case DispSetStatus.Back:	// 元に戻す
						{
							this.tNedit_CustomerCode.SetInt(this._customerCodeWork);

							// フォーカス移動しない
							canChangeFocus = false;
							break;
						}
					case DispSetStatus.Update:	// 更新
						{
							if ((outParamObj != null) && (outParamObj is ArrayList))
							{
								outParamList = outParamObj as ArrayList;

								if ((outParamList != null)
									&& (outParamList.Count == 2)
									&& (outParamList[1] is string))
								{
									this.CustomerCodeNm_tEdit.Text = (string)outParamList[1];

									// 現在データ保存
									this._customerCodeWork = this.tNedit_CustomerCode.GetInt();

                                    // 2008.06.20 30413 犬飼 拠点の入力情報クリアを追加 >>>>>>START
                                    // 拠点の入力情報はクリアする
                                    this.tEdit_SectionCodeAllowZero.Clear();
                                    this.SectionCodeNm_tEdit.Clear();
                                    // 2008.06.20 30413 犬飼 拠点の入力情報クリアを追加 <<<<<<END
								}
							}
							break;
						}
				}
			}
			catch (Exception)
			{
			}
		}
		#endregion 得意先コード設定処理

		#region 得意先ガイド呼び出し判定
		/// <summary>
		/// 得意先ガイド呼び出し判定
		/// </summary>
		/// <param name="slipPrtKind">伝票印刷種別</param>
		/// <returns>サーチモード（1:仕入先, 3:得意先）</returns>
		/// <remarks>
		/// <br>Note       : 得意先ガイドの呼び出し（仕入先or得意先）を判定します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.03.17</br>
		/// </remarks>
		private int JudgeCallCustmerGuide(int slipPrtKind)
		{
            // 2008.06.20 30413 犬飼 得意先ガイド表示のアセンブリ参照を変更 >>>>>>START
            //int searchMode = PMKHN04001UA.SEARCHMODE_CUSTOMER_ONLY;
            int searchMode = PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY;
            // 2008.06.20 30413 犬飼 得意先ガイド表示のアセンブリ参照を変更 <<<<<<END
			
			switch (slipPrtKind)
			{
				case 10:	// 見積書
				case 20:	// 指示書
				case 21:	// 承り書
				case 30:	// 納品書
					{
                        // 2008.06.20 30413 犬飼 得意先ガイド表示のアセンブリ参照を変更 >>>>>>START
                        //searchMode = PMKHN04001UA.SEARCHMODE_CUSTOMER_ONLY;
                        searchMode = PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY;
                        // 2008.06.20 30413 犬飼 得意先ガイド表示のアセンブリ参照を変更 <<<<<<END
						break;
					}
				case 40:	// 返品伝票
					{
                        // 2008.06.20 30413 犬飼 SEARCHMODE_SUPPLIERがないのでSEARCHMODE_RECEIVER >>>>>>START
                        //searchMode = PMKHN04001UA.SEARCHMODE_SUPPLIER;
                        searchMode = PMKHN04005UA.SEARCHMODE_RECEIVER;
                        // 2008.06.20 30413 犬飼 SEARCHMODE_SUPPLIERがないのでSEARCHMODE_RECEIVER <<<<<<END
						break;
					}
			}
			return searchMode;
		}
		#endregion 得意先ガイド呼び出し判定
		//----- h.ueno upd ---------- end 2008.03.17
		
		#endregion

        // --------------------------------------------------
        #region Private Methods

        /// <summary>
        /// 拠点ガイド起動処理
        /// </summary>
        /// <param name="secInfoSet">拠点マスタオブジェクト</param>
        /// <returns>結果(0:OK, 1:Cancel)</returns>
        /// <remarks>
        /// <br>Note       : 拠点ガイドの起動を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.20</br>
        /// </remarks>
        private int ShowSecInfoGuide(out SecInfoSet secInfoSet)
        {
            secInfoSet = new SecInfoSet();
            return this._secInfoSetAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, false, out secInfoSet);
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008/06/20</br>
        /// </remarks>
        /// 
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
                        this._sectionCodeWork = int.Parse(sectionCode);
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

        #endregion
        
		// --------------------------------------------------
		#region Control Events

		/// <summary>
		/// Form.Load イベント (DCKHN09130UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ユーザーがフォームを読み込む時に発生します。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void DCKHN09130UA_Load(object sender, EventArgs e)
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

            // --- ADD 2009/03/26 残案件No.14対応------------------------------------------------------>>>>>
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.Renewal_Button.ImageList = imageList16;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;
            // --- ADD 2009/03/26 残案件No.14対応------------------------------------------------------<<<<<
        }

		/// <summary>
		/// Form.FormClosing イベント (DCKHN09130UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void DCKHN09130UA_FormClosing(object sender, FormClosingEventArgs e)
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
		/// Form.VisibleChanged イベント (DCKHN09130UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : フォームの表示状態が変化した時に発生します。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void DCKHN09130UA_VisibleChanged(object sender, EventArgs e)
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
		private void Initial_Timer_Tick(object sender, EventArgs e)
		{
			this.Initial_Timer.Enabled = false;

			// 画面再構築処理
			this.ScreenReconstruction();
		}

		//----- h.ueno add ---------- start 2008.03.31
		/// <summary>
		/// ゼロ埋めキャンセル後テキスト取得処理実装
		/// </summary>
		/// <param name="fullText">入力済みテキスト</param>
		/// <returns>ゼロ埋めキャンセルしたテキスト</returns>
		/// <br>Note       : 文字列からゼロを削除します。</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.03.31</br>
		private static string GetZeroPadCanceledTextProc(string fullText)
		{
			if (fullText.Trim() != string.Empty)
			{
				int cnt = 0;
				string wkStr = fullText;
				
				// 先頭のゼロ詰めを削除
				while (fullText.StartsWith("0"))
				{
					fullText = fullText.Substring(1, fullText.Length - 1);
					cnt++;
				}
					
				// オールゼロは共通コード
				if (cnt == wkStr.Length)
				{
					fullText = "0";
				}
				return fullText;
			}
			else
			{
				return string.Empty;
			}
		}
		//----- h.ueno add ---------- end 2008.03.31

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
		private void Ok_Button_Click(object sender, EventArgs e)
		{
			// 登録処理
			if (this.SaveProc() == false)
			{
				return;
			}

			// イベント発生
			if (this.UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				this.UnDisplaying(this, me);
			}

			// 新規モードの場合は画面を終了させずに連続入力を可能とする。
			if (this._editingMode == CT_EMODE_INSERT)
			{
				// 画面を初期化
				this.ScreenClear();

				// 新規モードに設定
				this._editingMode = CT_EMODE_INSERT;
				this.Mode_Label.Text = INSERT_MODE;

				CustSlipMng newCustSlipMng = new CustSlipMng();

				// 画面に展開
				this.CustSlipMngToScreen(newCustSlipMng);

				// クローン作成
				this._custSlipMngClone = new CustSlipMng();
				this.DispToCustSlipMng(ref this._custSlipMngClone);

				// GridIndexバッファ初期化
				this._indexBuf = -2;

				// 画面入力許可設定
				this.ScreenInputPermissionControl(this._editingMode);
			}
			else
			{
				this.DialogResult = DialogResult.OK;

				// GridIndexバッファ初期化
				this._indexBuf = -2;

				if (this._canClose == true)
				{
					this.Close();
				}
				else
				{
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
		private void Cancel_Button_Click(object sender, EventArgs e)
		{
			// 削除モード・参照モード以外の場合は保存確認処理を行う
			if ((this._editingMode != CT_EMODE_DELETE) &&
				(this._editingMode != CT_EMODE_REFER))
			{
				// 現在の画面情報を取得する
				CustSlipMng compareCustSlipMng = this._custSlipMngClone.Clone();
				this.DispToCustSlipMng(ref compareCustSlipMng);

				// 最初に取得した画面と比較
				if (this._custSlipMngClone.Equals(compareCustSlipMng) == false)
				{
					// 画面情報が変更されていた場合は、保存確認メッセージを表示する。
					DialogResult res = TMsgDisp.Show(
						this,                               // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
						CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
						null,                               // 表示するメッセージ
						0,                                  // ステータス値
						MessageBoxButtons.YesNoCancel);    // 表示するボタン
					switch (res)
					{
						case DialogResult.Yes:
							{
								if (this.SaveProc() == false)
								{
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
			if (this.UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				this.UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.Cancel;

			// GridIndexバッファ初期化
			this._indexBuf = -2;

			if (this._canClose == true)
			{
				this.Close();
			}
			else
			{
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
		private void Revive_Button_Click(object sender, EventArgs e)
		{
			if (this.RevivalProc() != 0)
			{
				return;
			}

			if (this.UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				this.UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

			// GridIndexバッファ初期化
			this._indexBuf = -2;

			if (this._canClose == true)
			{
				this.Close();
			}
			else
			{
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
		private void Delete_Button_Click(object sender, EventArgs e)
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
				MessageBoxDefaultButton.Button2);  // 初期表示ボタン

			if (result == DialogResult.OK)
			{
				if (this.PhysicalDeleteProc() != 0)
				{
					return;
				}
			}
			else
			{
				this.Delete_Button.Focus();
				return;
			}

			if (this.UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				this.UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

			// GridIndexバッファ初期化
			this._indexBuf = -2;

			if (this._canClose == true)
			{
				this.Close();
			}
			else
			{
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
		private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
			if (e.PrevCtrl == null || e.NextCtrl == null) return;

			//----- ueno add---------- start 2008.03.17
			bool canChangeFocus = true;
            // 2009.02.04 30413 犬飼 未使用のため、コメント化 >>>>>>START
            DispSetStatus dispSetStatus = DispSetStatus.Clear;
            // 2009.02.04 30413 犬飼 未使用のため、コメント化 <<<<<<END
            
			object inParamObj = null;
			object outParamObj = null;
			ArrayList inParamList = new ArrayList();
			//----- ueno add---------- end 2008.03.17
			
			switch (e.PrevCtrl.Name)
			{
                // 2008.06.20 30413 犬飼 拠点コード追加 >>>>>>START
                case "tEdit_SectionCodeAllowZero":
                    {
                        // 条件設定クリア
                        inParamObj = null;
                        outParamObj = null;

                        if ((this.tEdit_SectionCodeAllowZero.Text == "") || (int.Parse(this.tEdit_SectionCodeAllowZero.DataText) == 0))
                        {
                            // 2009.02.04 30413 犬飼 未入力時は、ガイドボタンへフォーカス制御 >>>>>>START
                            if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_SectionCodeAllowZero.Text == "")
                                {
                                    // 未入力時
                                    e.NextCtrl = this.uButton_SectionGuide;
                                }
                                else
                                {
                                    // "0"または"00"入力時
                                    e.NextCtrl = this.SlipPrtKind_tComboEditor;
                                }
                            }
                            // 2009.02.04 30413 犬飼 未入力時は、ガイドボタンへフォーカス制御 <<<<<<END
                            
                            // 未入力、またはゼロの場合は全社設定扱い
                            //this.tEdit_SectionCodeAllowZero.Text = "00";  // DEL 2009/06/01
                            this.tEdit_SectionCodeAllowZero.Text = SECTION_COMMON_CODE; // ADD 2009/06/01
                            this.SectionCodeNm_tEdit.Text = SECTION_COMMON;
                            this._sectionCodeWork = 0;
                            // 2009.02.04 30413 犬飼 未入力時は、ガイドボタンへフォーカス制御 >>>>>>START
                            //// 2008.09.22 30413 犬飼 ガイドボタンのフォーカス制御を変更 >>>>>>START
                            //if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
                            //{
                            //    e.NextCtrl = this.SlipPrtKind_tComboEditor;
                            //}
                            //// 2008.09.22 30413 犬飼 ガイドボタンのフォーカス制御を変更 <<<<<<END
                            // 2009.02.04 30413 犬飼 未入力時は、ガイドボタンへフォーカス制御 <<<<<<END
                            
                        }
                        else if (e.NextCtrl == this.Cancel_Button)
                        {
                            // 遷移先のフォーカスが閉じるボタンの時はチェックしない
                            ;
                        }
                        else
                        {
                            // 条件設定
                            inParamObj = this.tEdit_SectionCodeAllowZero.Text;

                            // 拠点名称取得
                            outParamObj = GetSectionName((string)inParamObj);

                            // 2009.02.04 30413 犬飼 拠点のチェックは登録に変更 >>>>>>START
                            //// 拠点名称の存在チェック
                            //if (outParamObj.Equals(""))
                            //{
                            //    TMsgDisp.Show(
                            //        this, 													// 親ウィンドウフォーム
                            //        emErrorLevel.ERR_LEVEL_INFO, 							// エラーレベル
                            //        this.Name,												// アセンブリID
                            //        "指定された条件で、拠点コードは存在しませんでした。",	// 表示するメッセージ
                            //        0,														// ステータス値
                            //        MessageBoxButtons.OK);									// 表示するボタン

                            //    // 2008.09.29 30413 犬飼  >>>>>>START
                            //    //this.tEdit_SectionCodeAllowZero.Clear();
                            //    //this.SectionCodeNm_tEdit.Clear();
                            //    this.tEdit_SectionCodeAllowZero.Text = this._sectionCodeWork.ToString("d02");                                
                            //}
                            //else
                            //{
                            //    // 拠点名称設定
                            //    this.SectionCodeNm_tEdit.Text = (string)outParamObj;
                            //    // 2008.09.22 30413 犬飼 ガイドボタンのフォーカス制御を変更 >>>>>>START
                            //    if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
                            //    {
                            //        e.NextCtrl = this.SlipPrtKind_tComboEditor;
                            //    }
                            //    // 2008.09.22 30413 犬飼 ガイドボタンのフォーカス制御を変更 <<<<<<END
                            //    //// 得意先の入力情報はクリアする
                            //    //this.tNedit_CustomerCode.Clear();
                            //    //this.CustomerCodeNm_tEdit.Clear();
                            //}
                            // 拠点名称設定
                            this.SectionCodeNm_tEdit.Text = (string)outParamObj;
                            if (!e.ShiftKey)
                            {
                                if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
                                {
                                    e.NextCtrl = this.SlipPrtKind_tComboEditor;
                                }
                            }
                            // 2009.02.04 30413 犬飼 拠点のチェックは登録に変更 <<<<<<END
                        }
                        break;
                    }
                // 2008.06.20 30413 犬飼 拠点コード追加 <<<<<<END
                case "tNedit_CustomerCode":
					{
                        // 2008.06.20 30413 犬飼 条件設定変数のクリア >>>>>>START
                        // 条件設定クリア
                        inParamObj = null;
                        outParamObj = null;
                        // 2008.06.20 30413 犬飼 条件設定変数のクリア <<<<<<END

						//----- ueno add ---------- start 2008.03.17
						// 「0」の場合、共通とする
						if ((this.tNedit_CustomerCode.Text != "")&&(this.tNedit_CustomerCode.GetInt() == 0))
						{
                            // 2008.06.20 30413 犬飼 得意先名称への"共通"の設定コメント >>>>>>START
							//this.CustomerCodeNm_tEdit.Text = CUSTOMER_COMMON;
                            this.CustomerCodeNm_tEdit.Text = "";
                            // 2008.06.20 30413 犬飼 得意先名称への"共通"の設定コメント <<<<<<END
							this._customerCodeWork = 0;
							break;
						}
                        else if (e.NextCtrl == this.Cancel_Button)
                        {
                            // 遷移先のフォーカスが閉じるボタンの時はチェックしない
                            ;
                        }
                        else
                        {
                            // 条件設定
                            inParamObj = this.tNedit_CustomerCode.GetInt();

                            // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //// 存在チェック
                            //switch (CheckCustomerCode(inParamObj, out outParamObj))
                            //{
                            //    case (int)InputChkStatus.Normal:
                            //        {
                            //            dispSetStatus = DispSetStatus.Update;
                            //            break;
                            //        }
                            //    case (int)InputChkStatus.NotInput:
                            //        {
                            //            dispSetStatus = DispSetStatus.Clear;
                            //            break;
                            //        }
                            //    case (int)InputChkStatus.Different:
                            //        {
                            //            // エラーメッセージはチェックの内部で行っている

                            //            //----- h.ueno add---------- start 2008.03.31
                            //            // 共通コードが判定
                            //            if ((this._customerCodeWork == 0) && (this.CustomerCodeNm_tEdit.Text == CUSTOMER_COMMON))
                            //            {
                            //                dispSetStatus = DispSetStatus.Back;
                            //            }
                            //            else
                            //            {
                            //                dispSetStatus = this._customerCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
                            //            }
                            //            //----- h.ueno add---------- end 2008.03.31
                            //            break;
                            //        }
                            //    default:
                            //        {
                            //            TMsgDisp.Show(
                            //                    this, 													// 親ウィンドウフォーム
                            //                    emErrorLevel.ERR_LEVEL_INFO, 							// エラーレベル
                            //                    this.Name,												// アセンブリID
                            //                    "指定された条件で、得意先コードは存在しませんでした。",	// 表示するメッセージ
                            //                    0,														// ステータス値
                            //                    MessageBoxButtons.OK);									// 表示するボタン

                            //            //----- h.ueno add---------- start 2008.03.31
                            //            // 共通コードが判定
                            //            if ((this._customerCodeWork == 0)&&(this.CustomerCodeNm_tEdit.Text == CUSTOMER_COMMON))
                            //            {
                            //                dispSetStatus = DispSetStatus.Back;
                            //            }
                            //            else
                            //            {
                            //                dispSetStatus = this._customerCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
                            //            }
                            //            //----- h.ueno add---------- end 2008.03.31

                            //            break;
                            //        }
                            //}

                            // サーチモード決定(伝票印刷種別により変化)
                            // 2008.06.20 30413 犬飼 得意先ガイド表示のアセンブリ参照を変更 >>>>>>START
                            //int searchMode = PMKHN04001UA.SEARCHMODE_CUSTOMER_ONLY;
                            int searchMode = PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY;
                            // 2008.06.20 30413 犬飼 得意先ガイド表示のアセンブリ参照を変更 <<<<<<END
                            if (this.SlipPrtKind_tComboEditor.Value != null) searchMode = JudgeCallCustmerGuide((Int32)this.SlipPrtKind_tComboEditor.Value);

                            // 2009.02.04 30413 犬飼 得意先のチェックは登録に変更 >>>>>>START
                            //// 2008.06.20 30413 犬飼 得意先ガイド表示のアセンブリ参照を変更 >>>>>>START
                            ////if (searchMode == PMKHN04001UA.SEARCHMODE_CUSTOMER_ONLY)
                            //if (searchMode == PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY)
                            //// 2008.06.20 30413 犬飼 得意先ガイド表示のアセンブリ参照を変更 <<<<<<END
                            //{
                            //    // 存在チェック
                            //    switch (this.CheckCustomerCode(inParamObj, out outParamObj))
                            //    {
                            //        case (int)InputChkStatus.Normal:
                            //            {
                            //                dispSetStatus = DispSetStatus.Update;
                            //                break;
                            //            }
                            //        case (int)InputChkStatus.NotInput:
                            //            {
                            //                dispSetStatus = DispSetStatus.Clear;
                            //                break;
                            //            }
                            //        case (int)InputChkStatus.Different:
                            //            {
                            //                // エラーメッセージはチェックの内部で行っている

                            //                // 共通コードが判定
                            //                if ((this._customerCodeWork == 0) && (this.CustomerCodeNm_tEdit.Text == CUSTOMER_COMMON))
                            //                {
                            //                    dispSetStatus = DispSetStatus.Back;
                            //                }
                            //                else
                            //                {
                            //                    dispSetStatus = this._customerCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
                            //                }
                            //                break;
                            //            }
                            //        default:
                            //            {
                            //                TMsgDisp.Show(
                            //                        this, 													// 親ウィンドウフォーム
                            //                        emErrorLevel.ERR_LEVEL_INFO, 							// エラーレベル
                            //                        this.Name,												// アセンブリID
                            //                        "指定された条件で、得意先コードは存在しませんでした。",	// 表示するメッセージ
                            //                        0,														// ステータス値
                            //                        MessageBoxButtons.OK);									// 表示するボタン

                            //                // 共通コードが判定
                            //                if ((this._customerCodeWork == 0) && (this.CustomerCodeNm_tEdit.Text == CUSTOMER_COMMON))
                            //                {
                            //                    dispSetStatus = DispSetStatus.Back;
                            //                }
                            //                else
                            //                {
                            //                    dispSetStatus = this._customerCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
                            //                }
                            //                break;
                            //            }
                            //    }
                            //}
                            //else
                            //{
                            //    // 存在チェック
                            //    switch (this.CheckSupplierCode(inParamObj, out outParamObj))
                            //    {
                            //        case (int)InputChkStatus.Normal:
                            //            {
                            //                dispSetStatus = DispSetStatus.Update;
                            //                break;
                            //            }
                            //        case (int)InputChkStatus.NotInput:
                            //            {
                            //                dispSetStatus = DispSetStatus.Clear;
                            //                break;
                            //            }
                            //        case (int)InputChkStatus.Different:
                            //            {
                            //                // エラーメッセージはチェックの内部で行っている

                            //                // 共通コードが判定
                            //                if ((this._customerCodeWork == 0) && (this.CustomerCodeNm_tEdit.Text == CUSTOMER_COMMON))
                            //                {
                            //                    dispSetStatus = DispSetStatus.Back;
                            //                }
                            //                else
                            //                {
                            //                    dispSetStatus = this._customerCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
                            //                }
                            //                break;
                            //            }
                            //        default:
                            //            {
                            //                TMsgDisp.Show(
                            //                        this, 													// 親ウィンドウフォーム
                            //                        emErrorLevel.ERR_LEVEL_INFO, 							// エラーレベル
                            //                        this.Name,												// アセンブリID
                            //                        "指定された条件で、仕入先コードは存在しませんでした。",	// 表示するメッセージ
                            //                        0,														// ステータス値
                            //                        MessageBoxButtons.OK);									// 表示するボタン

                            //                // 共通コードが判定
                            //                if ((this._customerCodeWork == 0) && (this.CustomerCodeNm_tEdit.Text == CUSTOMER_COMMON))
                            //                {
                            //                    dispSetStatus = DispSetStatus.Back;
                            //                }
                            //                else
                            //                {
                            //                    dispSetStatus = this._customerCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
                            //                }
                            //                break;
                            //            }
                            //    }
                            //}
                            //// UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                            //// データ設定
                            //DispSetCustomerCode(dispSetStatus, ref canChangeFocus, outParamObj);
                            //----- ueno add ---------- end 2008.03.17

                            // 2008.09.22 30413 犬飼 ガイドボタンのフォーカス制御を変更 >>>>>>START
                            //if ((dispSetStatus == DispSetStatus.Update) && ((e.Key == Keys.Return) || (e.Key == Keys.Tab)))
                            //{
                            //    e.NextCtrl = this.SlipPrtKind_tComboEditor;
                            //}
                            // 2008.09.22 30413 犬飼 ガイドボタンのフォーカス制御を変更 <<<<<<END

                            if (searchMode == PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY)
                            {
                                this.CheckCustomerCode(inParamObj, out outParamObj);
                            }
                            else
                            {
                                this.CheckSupplierCode(inParamObj, out outParamObj);
                            }
                            // 得意先名の設定
                            if ((outParamObj != null) &&
                                (((ArrayList)outParamObj).Count == 2) &&
                                (((ArrayList)outParamObj)[1] is string))
                            {
                                this.CustomerCodeNm_tEdit.Text = (string)((ArrayList)outParamObj)[1];
                            }
                            else
                            {
                                this.CustomerCodeNm_tEdit.Text = "";
                            }
                            if (!e.ShiftKey)
                            {
                                if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
                                {
                                    e.NextCtrl = this.SlipPrtKind_tComboEditor;
                                }
                            }
                            // 2009.02.04 30413 犬飼 得意先のチェックは登録に変更 <<<<<<END
                        }
                        #region del 2008.03.17
						//----- h.ueno del ---------- start 2008.03.17
						//if (CustomerCode0_tNedit.GetInt() == 0)
						//{
						//    this.uLabel_CustomerName.Text = "共通"; // 略称
						//    return;
						//}

						//CustomerInfo customerInfo;
						//int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, CustomerCode0_tNedit.GetInt(), true, out customerInfo);

						//if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						//{
						//}
						//else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
						//{
						//    TMsgDisp.Show(
						//        this,
						//        emErrorLevel.ERR_LEVEL_EXCLAMATION,
						//        this.Name,
						//        "選択した得意先は既に削除されています。",
						//        status,
						//        MessageBoxButtons.OK);
						//    return;
						//}
						//else
						//{
						//    TMsgDisp.Show(this,
						//                  emErrorLevel.ERR_LEVEL_STOPDISP,
						//                  this.Name,
						//                  "得意先情報の取得に失敗しました。",
						//                  status,
						//                  MessageBoxButtons.OK);
						//    return;
						//}

						//this.CustomerCode0_tNedit.Text = customerInfo.CustomerCode.ToString().Trim();
						//this.uLabel_CustomerName.Text = customerInfo.CustomerSnm; // 略称
						//----- h.ueno del ---------- end 2008.03.17
						#endregion del 2008.03.17

						break;
					}
				//----- h.ueno add---------- start 2008.03.17
				case "SlipPrtKind_tComboEditor":
					{
						if (this.SlipPrtKind_tComboEditor.Value != null)
						{
							SlipPrtKindVisibleChange((Int32)this.SlipPrtKind_tComboEditor.Value);
						}
						break;
					}
				//----- h.ueno add---------- end 2008.03.17
			}

			//----- h.ueno add ---------- start 2008.03.17
			// フォーカス制御
			if (canChangeFocus == false)
			{
				e.NextCtrl = e.PrevCtrl;

				// 現在の項目から移動せず、テキスト全選択状態とする
				e.NextCtrl.Select();
			}
			//----- h.ueno add ---------- end 2008.03.17

            // 2009.03.26 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            switch (e.NextCtrl.Name)
            {
                case "SlipPrtSetPaperId_tComboEditor":      // 印刷設定用帳票ID
                case "Ok_Button":
                    {
                        if (this._dataIndex < 0)
                        {
                            if (SetKind_tComboEditor.SelectedIndex == 0)
                            {
                                if (ModeChangeProcSection())
                                {
                                    e.NextCtrl = tEdit_SectionCodeAllowZero;
                                }
                            }
                            else
                            {
                                if (ModeChangeProcCustomer())
                                {
                                    e.NextCtrl = tNedit_CustomerCode;
                                }
                            }
                        }
                        break;
                    }
            }
            // 2009.03.26 30413 犬飼 新規モードからモード変更対応 <<<<<<END
		}

		#endregion

		private void uButton_CustomerGuide_Click(object sender, EventArgs e)
		{

			// UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// 得意先ガイド
            ////----- ueno upd ---------- start 2008.03.17
            //int searchMode = SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY;	// 得意先設定

            //// 伝票印刷種別によって呼び出しを分ける
            //if (this.SlipPrtKind_tComboEditor.Value != null)
            //{
            //    // 得意先ガイド呼び出し判定
            //    searchMode = JudgeCallCustmerGuide((Int32)this.SlipPrtKind_tComboEditor.Value);
            //}
            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(searchMode, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            ////----- ueno upd ---------- end 2008.03.17
			
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            //customerSearchForm.ShowDialog(this);

            // 2008.09.22 30413 犬飼 ガイドボタンのフォーカス制御を変更 >>>>>>START
            // フォーカス制御用、ガイド呼出前の得意先コード
            int beCustCd = this.tNedit_CustomerCode.GetInt();
            // 2008.09.22 30413 犬飼 ガイドボタンのフォーカス制御を変更 <<<<<<END
                            
            // サーチモード決定(伝票印刷種別により変化)
            // 2008.06.20 30413 犬飼 得意先ガイド表示のアセンブリ参照を変更 >>>>>>START
            //int searchMode = PMKHN04001UA.SEARCHMODE_CUSTOMER_ONLY;
            int searchMode = PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY;
            // 2008.06.20 30413 犬飼 得意先ガイド表示のアセンブリ参照を変更 <<<<<<END
            if (this.SlipPrtKind_tComboEditor.Value != null) searchMode = JudgeCallCustmerGuide((Int32)this.SlipPrtKind_tComboEditor.Value);

            // 2008.06.20 30413 犬飼 得意先ガイド表示のアセンブリ参照を変更 >>>>>>START
            //if (searchMode == PMKHN04001UA.SEARCHMODE_CUSTOMER_ONLY)
            if (searchMode == PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY)
            // 2008.06.20 30413 犬飼 得意先ガイド表示のアセンブリ参照を変更 <<<<<<END
            {
                //-----------------------------------------
                // 得意先
                //-----------------------------------------
                // 2008.06.20 30413 犬飼 得意先ガイド表示のアセンブリ参照を変更 >>>>>>START
                //PMKHN04001UA customerSearchForm = new PMKHN04001UA(searchMode, PMKHN04001UA.EXECUTEMODE_GUIDE_ONLY);
                //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(searchMode, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                // 2008.06.20 30413 犬飼 得意先ガイド表示のアセンブリ参照を変更 <<<<<<END
                customerSearchForm.ShowDialog(this);
            }
            else
            {
                //-----------------------------------------
                // 仕入先
                //-----------------------------------------
                Supplier supplier;
                this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, string.Empty);
                this.SupplierSearchForm_SupplierSelect(supplier);
            }
            // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // 2008.09.22 30413 犬飼 ガイドボタンのフォーカス制御を変更 >>>>>>START
            if ((!beCustCd.Equals(this.tNedit_CustomerCode.GetInt())) && (this.tNedit_CustomerCode.Text != "") 
                && (this.CustomerCodeNm_tEdit.Text != ""))
            {
                // ガイド呼出前と違う、クリアされていない場合
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            // 2008.09.22 30413 犬飼 ガイドボタンのフォーカス制御を変更 <<<<<<END
        }

        // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>得意先選択時発生イベント</summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        //private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    CustomerInfo customerInfo;

        //    int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        //----- ueno add ---------- start 2008.03.17
        //        //--------------------------
        //        // 得意先ガイド呼び出し判定
        //        //--------------------------
        //        int searchMode = SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY;	// 得意先設定

        //        // 伝票印刷種別によって呼び出しを分ける
        //        if (this.SlipPrtKind_tComboEditor.Value != null)
        //        {
        //            // 得意先ガイド呼び出し判定
        //            searchMode = JudgeCallCustmerGuide((Int32)this.SlipPrtKind_tComboEditor.Value);
        //        }

        //        // 得意先モードでガイドを起動した場合
        //        if (searchMode == SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY)
        //        {
        //            // 選択データが得意先でない場合
        //            if (customerInfo.IsCustomer == false)
        //            {
        //                // エラー
        //                TMsgDisp.Show(
        //                    this,
        //                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //                    this.Name,
        //                    "得意先データではありません。",
        //                    status,
        //                    MessageBoxButtons.OK);
						
        //                return;
        //            }
        //        }
        //        // 仕入先モードでガイドを起動した場合
        //        else
        //        {
        //            // 選択データが仕入先でない場合
        //            if (customerInfo.IsSupplier == false)
        //            {
        //                // エラー
        //                TMsgDisp.Show(
        //                    this,
        //                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //                    this.Name,
        //                    "仕入先データではありません。",
        //                    status,
        //                    MessageBoxButtons.OK);
						
        //                return;
        //            }
        //        }
        //        //----- ueno add ---------- end 2008.03.17
        //    }
        //    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
        //    {
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //            this.Name,
        //            "選択した得意先は既に削除されています。",
        //            status,
        //            MessageBoxButtons.OK);

        //        return;
        //    }
        //    else
        //    {
        //        TMsgDisp.Show(this,
        //                      emErrorLevel.ERR_LEVEL_STOPDISP,
        //                      this.Name,
        //                      "得意先情報の取得に失敗しました。",
        //                      status,
        //                      MessageBoxButtons.OK);

        //        return;
        //    }

        //    //----- h.ueno upd ---------- start 2008.03.17
        //    this.CustomerCode_tNedit.SetInt(customerInfo.CustomerCode);
        //    this.CustomerCodeNm_tEdit.Text = customerInfo.CustomerSnm;  // 略称
        //    this._customerCodeWork = this.CustomerCode_tNedit.GetInt();
        //    //----- h.ueno upd ---------- end 2008.03.17
        //}

        ///// <summary>得意先選択時発生イベント</summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;

            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //--------------------------
                // 得意先ガイド呼び出し判定
                //--------------------------
                // 2008.06.20 30413 犬飼 得意先ガイド表示のアセンブリ参照を変更 >>>>>>START
                //int searchMode = PMKHN04001UA.SEARCHMODE_CUSTOMER_ONLY;	// 得意先設定
                int searchMode = PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY;	// 得意先設定
                // 2008.06.20 30413 犬飼 得意先ガイド表示のアセンブリ参照を変更 <<<<<<END

                // 伝票印刷種別によって呼び出しを分ける
                if (this.SlipPrtKind_tComboEditor.Value != null)
                {
                    // 得意先ガイド呼び出し判定
                    searchMode = JudgeCallCustmerGuide((Int32)this.SlipPrtKind_tComboEditor.Value);
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "選択した得意先は既に削除されています。",
                    status,
                    MessageBoxButtons.OK);

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

                return;
            }

            this.tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);
            this.CustomerCodeNm_tEdit.Text = customerInfo.CustomerSnm;  // 略称
            this._customerCodeWork = this.tNedit_CustomerCode.GetInt();

            // 2008.06.20 30413 犬飼 拠点の入力情報はクリア >>>>>>START
            this.tEdit_SectionCodeAllowZero.Clear();
            this.SectionCodeNm_tEdit.Clear();
            // 2008.06.20 30413 犬飼 拠点の入力情報はクリア <<<<<<END
        }
        // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        // ADD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 仕入先情報設定処理
        /// </summary>
        /// <param name="supplier">仕入先情報</param>
        private void SupplierSearchForm_SupplierSelect(Supplier supplier)
        {
            //---------------------------------------------
            // 設定チェック
            //---------------------------------------------
            if (supplier == null) return;                                           // nullの場合、処理なし

            //---------------------------------------------
            // 仕入先情報再読込
            //---------------------------------------------
            Supplier tempSupplier;
            // 仕入先情報読込
            int status = this._supplierAcs.Read(out tempSupplier, this._enterpriseCode, supplier.SupplierCd);

            //---------------------------------------------
            // チェック処理
            //---------------------------------------------
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "選択した仕入先は既に削除されています。",
                    status,
                    MessageBoxButtons.OK);
                return;
            }
            else if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "仕入先情報の取得に失敗しました。",
                    status,
                    MessageBoxButtons.OK);
                return;
            }

            //---------------------------------------------
            // 仕入先情報設定
            //---------------------------------------------
            this.tNedit_CustomerCode.SetInt(tempSupplier.SupplierCd);
            this.CustomerCodeNm_tEdit.Text = tempSupplier.SupplierSnm;  // 略称
            this._customerCodeWork = this.tNedit_CustomerCode.GetInt();

        }
        // ADD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		//----- h.ueno upd ---------- start 2008.03.17
		/// <summary>
		/// SlipPrtKind_tComboEditor_SelectionChangeCommitted イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 伝票印刷種別が変化したときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2008.03.17</br>
		/// </remarks>
		private void SlipPrtKind_tComboEditor_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (this.SlipPrtKind_tComboEditor.Value != null)
			{
				SlipPrtKindVisibleChange((Int32)this.SlipPrtKind_tComboEditor.Value);
			}
		}

		//----- h.ueno upd ---------- end 2008.03.17

		//----- h.ueno add ---------- start 2008.03.17
		/// <summary>
		/// CustomerCode_tNedit_Leave イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : フォーカスを失ったときに発生</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2008.03.28</br>
		/// </remarks>
		private void CustomerCode_tNedit_Leave(object sender, EventArgs e)
		{
			// 得意先コードが空白ならば何もしない
			if (this.tNedit_CustomerCode.Text == "")
			{
				this.tNedit_CustomerCode.Clear();
				this.CustomerCodeNm_tEdit.Clear();
			}
		}

		//----- h.ueno add ---------- end 2008.03.17

		//----- h.ueno add ---------- start 2008.03.31
		/// <summary>
		/// CustomerCode_tNedit_BeforeEnterEditMode
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note        : コントロールが編集モードに入る前に発生します。</br>
		/// <br>Programmer  : 30167 上野　弘貴</br>
		/// <br>Date        : 2008.03.31</br>
		/// </remarks>
		private void CustomerCode_tNedit_BeforeEnterEditMode(object sender, CancelEventArgs e)
		{
			// ChangeFocusイベント一時停止
			this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

			// 先頭のゼロ詰めを削除
			this.tNedit_CustomerCode.Text = GetZeroPadCanceledTextProc(this.tNedit_CustomerCode.Text);

			// ChangeFocusイベント再開
			this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
		}
		//----- h.ueno add ---------- end 2008.03.31

        /// <summary>
        /// 拠点ガイドボタン押下イベント
        /// </summary>
        /// <param name="sender">コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 拠点ガイドボタン押下時の処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.20</br>
        /// </remarks>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            SecInfoSet secInfoSet = null;
            int status = this.ShowSecInfoGuide(out secInfoSet);
            if (status == 0)
            {
                // 選択した情報を取得
                this.tEdit_SectionCodeAllowZero.Text = secInfoSet.SectionCode;
                this.SectionCodeNm_tEdit.Text = secInfoSet.SectionGuideNm;

                // 得意先の入力情報はクリアする
                this.tNedit_CustomerCode.Clear();
                this.CustomerCodeNm_tEdit.Clear();

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// Tedit_SectionCode_Leave イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォーカスを失ったときに発生</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.20</br>
        /// </remarks>
        private void Tedit_SectionCode_Leave(object sender, EventArgs e)
        {
            // 拠点コードが空白ならば何もしない
            if (this.tEdit_SectionCodeAllowZero.Text.Equals(""))
            {
                this.tEdit_SectionCodeAllowZero.Clear();
                this.SectionCodeNm_tEdit.Clear();
            }
        }

        /// <summary>
        /// Tedit_SectionCode_BeforeEnterEditMode
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : コントロールが編集モードに入る前に発生します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.06.20</br>
        /// </remarks>
        private void Tedit_SectionCode_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            // ChangeFocusイベント一時停止
            this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

            // 先頭のゼロ詰めを削除
            this.tEdit_SectionCodeAllowZero.Text = GetZeroPadCanceledTextProc(this.tEdit_SectionCodeAllowZero.Text.TrimEnd());

            // ChangeFocusイベント再開
            this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
        }

        /// <summary>
        /// 設定種別変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 設定種別の値が変更されたときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008/09/22</br>
        /// </remarks>
        private void SetKind_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            TComboEditor tComboEditor = sender as TComboEditor;
            Point point = new Point();
            point.X = 3;
            point.Y = 81;

            if (tComboEditor.SelectedIndex == 0)
            {
                // 拠点単位
                this.panel_Section.Visible = true;
                this.panel_Customer.Visible = false;
                // 2009.02.04 30413 犬飼 拠点単位の場合は得意先情報をクリア >>>>>>START
                // 得意先の情報クリア
                this.tNedit_CustomerCode.Clear();
                this.CustomerCodeNm_tEdit.Clear();
                // 2009.02.04 30413 犬飼 拠点単位の場合は得意先情報をクリア <<<<<<END
            }
            else
            {
                // 得意先単位
                this.panel_Section.Visible = false;
                this.panel_Customer.Visible = true;
                this.panel_Customer.Location = point;
                // 2009.02.04 30413 犬飼 得意先単位の場合は拠点情報をクリア >>>>>>START
                // 拠点の情報クリア
                this.tEdit_SectionCodeAllowZero.Clear();
                this.SectionCodeNm_tEdit.Clear();
                // 2009.02.04 30413 犬飼 得意先単位の場合は拠点情報をクリア <<<<<<END
            }
        }

        // --- ADD 2009/03/26 残案件No.14対応------------------------------------------------------>>>>>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            string msg;
            int totalCount;
            int status = this._custSlipMngAcs.Search(out totalCount, this._enterpriseCode);
            if (status == 0)
            {
                _slipPrtKind_tComboEditorValue = -1;

                string index = (string)this.SlipPrtSetPaperId_tComboEditor.Value;
                this.SlipPrtSetPaperId_tComboEditor.Items.Clear();
                SlipPrtKind_tComboEditor_SelectionChangeCommitted(SlipPrtKind_tComboEditor, new EventArgs());
                this.SlipPrtSetPaperId_tComboEditor.Value = index;
                msg = "最新情報を取得しました。";
            }
            else
            {
                msg = "最新情報の取得に失敗しました。";
            }

            TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          this.Name,						    // アセンブリＩＤまたはクラスＩＤ
                          msg, 			                        // 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
        }
        // --- ADD 2009/03/26 残案件No.14対応------------------------------------------------------<<<<<

        // 2009.03.26 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理(拠点別)
        /// </summary>
        private bool ModeChangeProcSection()
        {
            string msg = "入力されたコードの伝票設定情報が既に登録されています。\n編集を行いますか？";

            // 拠点コード
            string sectionCd = tEdit_SectionCodeAllowZero.Text.TrimEnd().PadLeft(2, '0');
            // 伝票印刷種別
            int slipPrtKind = (int)SlipPrtKind_tComboEditor.SelectedItem.DataValue;

            for (int i = 0; i < this._custSlipMngAcs.BindDataSet.Tables[CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE].DefaultView.Count; i++)
            {
                // データセットと比較
                string dsSecCd = (string)this._custSlipMngAcs.BindDataSet.Tables[CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE].DefaultView[i][CustSlipMngAcs.COL_SECTIONCODE_TITLE];
                int dsSlipPrtKind = (int)this._custSlipMngAcs.BindDataSet.Tables[CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE].DefaultView[i][CustSlipMngAcs.COL_SLIPPRTKIND_TITLE];
                int dsCustomerCode = (int)this._custSlipMngAcs.BindDataSet.Tables[CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE].DefaultView[i][CustSlipMngAcs.COL_CUSTOMERCODE_TITLE];
                if ((sectionCd.Equals(dsSecCd.TrimEnd().PadLeft(2, '0'))) &&
                    (slipPrtKind == dsSlipPrtKind) &&
                    (dsCustomerCode == 0))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this._custSlipMngAcs.BindDataSet.Tables[CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE].DefaultView[i][CustSlipMngAcs.COL_DELETEDATE_TITLE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          CT_PGID,						        // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの伝票設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 拠点コード、伝票印刷種別のクリア
                        tEdit_SectionCodeAllowZero.Clear();
                        SectionCodeNm_tEdit.Clear();
                        this._slipPrtKind_tComboEditorValue = -1;
                        SlipPrtKind_tComboEditor.SelectedIndex = 0;
                        SlipPrtKindVisibleChange((Int32)this.SlipPrtKind_tComboEditor.Value);
                        return true;
                    }

                    //if (sectionCd == "00")    // DEL 2009/06/01
                    if (sectionCd == SECTION_COMMON_CODE)   // ADD 2009/06/01
                    {
                        // 全社共通のメッセージ変更
                        msg = "入力されたコードの伝票設定情報が既に登録されています。\n　【拠点名称：全社共通】\n編集を行いますか？";
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        CT_PGID,                                // アセンブリＩＤまたはクラスＩＤ
                        msg,                                    // 表示するメッセージ
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
                                // 拠点コード、伝票印刷種別のクリア
                                tEdit_SectionCodeAllowZero.Clear();
                                SectionCodeNm_tEdit.Clear();
                                this._slipPrtKind_tComboEditorValue = -1;
                                SlipPrtKind_tComboEditor.SelectedIndex = 0;
                                SlipPrtKindVisibleChange((Int32)this.SlipPrtKind_tComboEditor.Value);
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// モード変更処理(得意先別)
        /// </summary>
        private bool ModeChangeProcCustomer()
        {
            // 得意先コード
            int customerCode = tNedit_CustomerCode.GetInt();
            // 伝票印刷種別
            int slipPrtKind = (int)SlipPrtKind_tComboEditor.SelectedItem.DataValue;

            for (int i = 0; i < this._custSlipMngAcs.BindDataSet.Tables[CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE].DefaultView.Count; i++)
            {
                // データセットと比較
                int dsCustomerCode = (int)this._custSlipMngAcs.BindDataSet.Tables[CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE].DefaultView[i][CustSlipMngAcs.COL_CUSTOMERCODE_TITLE];
                int dsSlipPrtKind = (int)this._custSlipMngAcs.BindDataSet.Tables[CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE].DefaultView[i][CustSlipMngAcs.COL_SLIPPRTKIND_TITLE];
                if ((customerCode == dsCustomerCode) &&
                    (slipPrtKind == dsSlipPrtKind))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this._custSlipMngAcs.BindDataSet.Tables[CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE].DefaultView[i][CustSlipMngAcs.COL_DELETEDATE_TITLE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          CT_PGID,						        // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの伝票設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 得意先コード、伝票印刷種別のクリア
                        tNedit_CustomerCode.Clear();
                        CustomerCodeNm_tEdit.Clear();
                        this._slipPrtKind_tComboEditorValue = -1;
                        SlipPrtKind_tComboEditor.SelectedIndex = 0;
                        SlipPrtKindVisibleChange((Int32)this.SlipPrtKind_tComboEditor.Value);
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        CT_PGID,                                // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードの伝票設定情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
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
                                // 得意先コード、伝票印刷種別のクリア
                                tNedit_CustomerCode.Clear();
                                CustomerCodeNm_tEdit.Clear();
                                this._slipPrtKind_tComboEditorValue = -1;
                                SlipPrtKind_tComboEditor.SelectedIndex = 0;
                                SlipPrtKindVisibleChange((Int32)this.SlipPrtKind_tComboEditor.Value);
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