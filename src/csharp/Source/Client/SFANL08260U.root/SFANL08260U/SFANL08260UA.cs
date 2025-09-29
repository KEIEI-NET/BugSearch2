using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;

using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
	public partial class SFANL08260UA : Form
	{
		// MessageBoxヘッダーキャプション
		internal const string ctMSG_CAPTION = "自由帳票ソート順位初期値設定";

		// テーブル名称
		private const string TBL_PRTITEMSET = "PrtItemSetRF";
		private const string TBL_FPSORTINIT = "FPSortInitRF";
		// 共通ファイルヘッダー
		private const string COL_COMMON_CREATEDATETIME		= "CreateDateTime";		// 作成日時
		private const string COL_COMMON_UPDATEDATETIME		= "UpdateDateTime";		// 更新日時
		private const string COL_COMMON_LOGICALDELETECODE	= "LogicalDeleteCode";	// 論理削除区分
		// 印字項目設定
		private const string COL_PRTITEMSET_FREEPRTPPRITEMGRPCD		= "FreePrtPprItemGrpCd";	// 自由帳票項目グループコード
		private const string COL_PRTITEMSET_FREEPRTPAPERITEMCD		= "FreePrtPaperItemCd";		// 自由帳票項目コード
		private const string COL_PRTITEMSET_FREEPRTPAPERITEMNM		= "FreePrtPaperItemNm";		// 自由帳票項目名称
		private const string COL_PRTITEMSET_FILENM					= "FileNm";					// ファイル名称
		private const string COL_PRTITEMSET_DDCHARCNT				= "DDCharCnt";				// DD桁数
		private const string COL_PRTITEMSET_DDNAME					= "DDName";					// DD名称
		private const string COL_PRTITEMSET_REPORTCONTROLCODE		= "ReportControlCode";		// レポートコントロール区分
		private const string COL_PRTITEMSET_HEADERUSEDIVCD			= "HeaderUseDivCd";			// ヘッダー使用区分
		private const string COL_PRTITEMSET_DETAILUSEDIVCD			= "DetailUseDivCd";			// 明細使用区分
		private const string COL_PRTITEMSET_FOOTERUSEDIVCD			= "FooterUseDivCd";			// フッター使用区分
		private const string COL_PRTITEMSET_EXTRACONDITIONDIVCD		= "ExtraConditionDivCd";	// 抽出条件区分
		private const string COL_PRTITEMSET_EXTRACONDITIONTYPECD	= "ExtraConditionTypeCd";	// 抽出条件タイプ
		private const string COL_PRTITEMSET_COMMAEDITEXISTCD		= "CommaEditExistCd";		// カンマ編集有無
		private const string COL_PRTITEMSET_PRINTPAGECTRLDIVCD		= "PrintPageCtrlDivCd";		// 印字ページ制御区分
		private const string COL_PRTITEMSET_SYSTEMDIVCD				= "SystemDivCd";			// システム区分
		private const string COL_PRTITEMSET_OPTIONCODE				= "OptionCode";				// オプションコード
		private const string COL_PRTITEMSET_EXTRACONDDETAILGRPCD	= "ExtraCondDetailGrpCd";	// 抽出条件明細グループコード
		private const string COL_PRTITEMSET_TOTALITEMDIVCD			= "TotalItemDivCd";			// 集計項目区分
		private const string COL_PRTITEMSET_FORMFEEDITEMDIVCD		= "FormFeedItemDivCd";		// 改頁項目区分
		private const string COL_PRTITEMSET_FREEPRTPPRDISPGRPCD		= "FreePrtPprDispGrpCd";	// 自由帳票表示グループコード
		private const string COL_PRTITEMSET_NECESSARYEXTRACONDCD	= "NecessaryExtraCondCd";	// 必須抽出条件区分
		private const string COL_PRTITEMSET_CIPHERFLG				= "CipherFlg";				// 暗号化フラグ
		private const string COL_PRTITEMSET_EXTRACTIONITDEDFLG		= "ExtractionItdedFlg";		// 抽出対象フラグ
		private const string COL_PRTITEMSET_GROUPSUPPRESSCD			= "GroupSuppressCd";		// グループサプレス区分
		private const string COL_PRTITEMSET_DTLCOLORCHANGECD		= "DtlColorChangeCd";		// 明細色変更区分
		private const string COL_PRTITEMSET_HEIGHTADJUSTDIVCD		= "HeightAdjustDivCd";		// 高さ調整区分
		private const string COL_PRTITEMSET_ADDITEMUSEDIVCD			= "AddItemUseDivCd";		// 追加項目使用区分
		// 自由帳票ソート順位初期値
		private const string COL_FPSORTINIT_FREEPRTPPRITEMGRPCD		= "FreePrtPprItemGrpCd";	// 自由帳票項目グループコード
		private const string COL_FPSORTINIT_FREEPRTPPRSCHMGRPCD		= "FreePrtPprSchmGrpCd";	// 自由帳票スキーマグループコード
		private const string COL_FPSORTINIT_SORTINGORDERCODE		= "SortingOrderCode";		// ソート順位コード
		private const string COL_FPSORTINIT_SORTINGORDER			= "SortingOrder";			// ソート順位
		private const string COL_FPSORTINIT_FREEPRTPAPERITEMNM		= "FreePrtPaperItemNm";		// 自由帳票項目名称
		private const string COL_FPSORTINIT_DDNAME					= "DDName";					// DD名称
		private const string COL_FPSORTINIT_FILENM					= "FileNm";					// ファイル名称
		private const string COL_FPSORTINIT_SORTINGORDERDIVCD		= "SortingOrderDivCd";		// 昇順降順区分

		#region PrivateMember
		// データ保持用DataSet
		private DataSet				_ds;
		// ファイルレイアウト情報保持用
		private List<SchemaInfo>	_fPSortInitSchemaInfoList;
		private List<SchemaInfo>	_prtItemSetSchemaInfoList;
		#endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SFANL08260UA()
		{
			InitializeComponent();

			_ds = new DataSet();
		}
		#endregion

		/// <summary>
		/// スキーマ情報LIST取得処理
		/// </summary>
		/// <param name="tableName">テーブル名称</param>
		/// <returns>スキーマ情報LIST</returns>
		private List<SchemaInfo> GetSchemaInfoList(string tableName)
		{
			List<SchemaInfo> schemaInfoList = new List<SchemaInfo>();

			switch (tableName)
			{
				case TBL_PRTITEMSET:
				{
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_CREATEDATETIME,			"作成日時",						typeof(long),	19));	// 作成日時
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_UPDATEDATETIME,			"更新日時",						typeof(long),	19));	// 更新日時
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_LOGICALDELETECODE,			"論理削除区分",					typeof(int),	2));	// 論理削除区分
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_FREEPRTPPRITEMGRPCD,	"自由帳票項目グループコード",		typeof(int),	4));	// 自由帳票項目グループコード
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_FREEPRTPAPERITEMCD,	"自由帳票項目コード",				typeof(int),	4));	// 自由帳票項目コード
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_FREEPRTPAPERITEMNM,	"自由帳票項目名称",				typeof(string),	30));	// 自由帳票項目名称
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_FILENM,				"ファイル名称",					typeof(string),	32));	// ファイル名称
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_DDCHARCNT,				"DD桁数",						typeof(int),	2));	// DD桁数
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_DDNAME,				"DD名称",						typeof(string),	30));	// DD名称
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_REPORTCONTROLCODE,		"レポートコントロール区分",		typeof(int),	2));	// レポートコントロール区分
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_HEADERUSEDIVCD,		"ヘッダー使用区分",				typeof(int),	2));	// ヘッダー使用区分
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_DETAILUSEDIVCD,		"明細使用区分",					typeof(int),	2));	// 明細使用区分
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_FOOTERUSEDIVCD,		"フッター使用区分",				typeof(int),	2));	// フッター使用区分
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_EXTRACONDITIONDIVCD,	"抽出条件区分",					typeof(int),	2));	// 抽出条件区分
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_EXTRACONDITIONTYPECD,	"抽出条件タイプ",				typeof(int),	2));	// 抽出条件タイプ
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_COMMAEDITEXISTCD,		"カンマ編集有無",				typeof(int),	2));	// カンマ編集有無
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_PRINTPAGECTRLDIVCD,	"印字ページ制御区分",				typeof(int),	2));	// 印字ページ制御区分
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_SYSTEMDIVCD,			"システム区分",					typeof(int),	2));	// システム区分
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_OPTIONCODE,			"オプションコード",				typeof(string),	16));	// オプションコード
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_EXTRACONDDETAILGRPCD,	"抽出条件明細グループコード",		typeof(int),	4));	// 抽出条件明細グループコード
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_TOTALITEMDIVCD,		"集計項目区分",					typeof(int),	2));	// 集計項目区分
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_FORMFEEDITEMDIVCD,		"改頁項目区分",					typeof(int),	2));	// 改頁項目区分
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_FREEPRTPPRDISPGRPCD,	"自由帳票表示グループコード",		typeof(int),	4));	// 自由帳票表示グループコード
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_NECESSARYEXTRACONDCD,	"必須抽出条件区分",				typeof(int),	2));	// 必須抽出条件区分
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_CIPHERFLG,				"暗号化フラグ",					typeof(int),	2));	// 暗号化フラグ
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_EXTRACTIONITDEDFLG,	"抽出対象フラグ",				typeof(int),	2));	// 抽出対象フラグ
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_GROUPSUPPRESSCD,		"グループサプレス区分",			typeof(int),	2));	// グループサプレス区分
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_DTLCOLORCHANGECD,		"明細色変更区分",				typeof(int),	2));	// 明細色変更区分
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_HEIGHTADJUSTDIVCD,		"高さ調整区分",					typeof(int),	2));	// 高さ調整区分
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_ADDITEMUSEDIVCD,		"追加項目使用区分",				typeof(int),	2));	// 追加項目使用区分
					break;
				}
				case TBL_FPSORTINIT:
				{
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_CREATEDATETIME,			"作成日時",						typeof(long),	19));	// 作成日時
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_UPDATEDATETIME,			"更新日時",						typeof(long),	19));	// 更新日時
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_LOGICALDELETECODE,			"論理削除区分",					typeof(int),	2));	// 論理削除区分
					schemaInfoList.Add(new SchemaInfo(COL_FPSORTINIT_FREEPRTPPRITEMGRPCD,	"自由帳票項目グループコード",		typeof(int),	4));	// 自由帳票項目グループコード
					schemaInfoList.Add(new SchemaInfo(COL_FPSORTINIT_FREEPRTPPRSCHMGRPCD,	"自由帳票スキーマグループコード",	typeof(int),	4));	// 自由帳票スキーマグループコード
					schemaInfoList.Add(new SchemaInfo(COL_FPSORTINIT_SORTINGORDERCODE,		"ソート順位コード",				typeof(int),	2));	// ソート順位コード
					schemaInfoList.Add(new SchemaInfo(COL_FPSORTINIT_SORTINGORDER,			"ソート順位",					typeof(int),	2));	// ソート順位
					schemaInfoList.Add(new SchemaInfo(COL_FPSORTINIT_FREEPRTPAPERITEMNM,	"自由帳票項目名称",				typeof(string),	30));	// 自由帳票項目名称
					schemaInfoList.Add(new SchemaInfo(COL_FPSORTINIT_DDNAME,				"DD名称",						typeof(string),	30));	// DD名称
					schemaInfoList.Add(new SchemaInfo(COL_FPSORTINIT_FILENM,				"ファイル名称",					typeof(string),	32));	// ファイル名称
					schemaInfoList.Add(new SchemaInfo(COL_FPSORTINIT_SORTINGORDERDIVCD,		"昇順降順区分",					typeof(int),	2));	// 昇順降順区分
					break;
				}
			}

			return schemaInfoList;
		}

		/// <summary>
		/// DataTableスキーマ作成処理
		/// </summary>
		/// <param name="ds">DataTable格納先DataSet</param>
		/// <param name="tableName">DataTable名称</param>
		private void CreateDataTableSchema(DataSet ds, string tableName)
		{
			List<SchemaInfo> schemaInfoList = GetSchemaInfoList(tableName);

			if (schemaInfoList != null)
			{
				switch (tableName)
				{
					case TBL_PRTITEMSET: _prtItemSetSchemaInfoList = schemaInfoList; break;
					case TBL_FPSORTINIT: _fPSortInitSchemaInfoList = schemaInfoList; break;
				}

				ds.Tables.Add(new DataTable(tableName));
				foreach (SchemaInfo schemaInfo in schemaInfoList)
				{
					// 型を動的に指定
					if (schemaInfo.Type != null)
						ds.Tables[tableName].Columns.Add(schemaInfo.Name, schemaInfo.Type);
					else
						ds.Tables[tableName].Columns.Add(schemaInfo.Name);

					// 文字列型の場合は空文字を初期値にする
					if (ds.Tables[tableName].Columns[schemaInfo.Name].DataType.Equals(typeof(string)))
					{
						ds.Tables[tableName].Columns[schemaInfo.Name].DefaultValue = string.Empty;
					}
					// GUID型の場合は新しいGUID値を初期値にする
					else if (ds.Tables[tableName].Columns[schemaInfo.Name].DataType.Equals(typeof(Guid)))
					{
						ds.Tables[tableName].Columns[schemaInfo.Name].DefaultValue = Guid.NewGuid();
					}
					// 数値型の場合は0を初期値(Booleanの場合はfalse)にする
					else if (ds.Tables[tableName].Columns[schemaInfo.Name].DataType.IsPrimitive)
					{
						if (ds.Tables[tableName].Columns[schemaInfo.Name].DataType.Equals(typeof(bool)))
							ds.Tables[tableName].Columns[schemaInfo.Name].DefaultValue = false;
						else
							ds.Tables[tableName].Columns[schemaInfo.Name].DefaultValue = 0;
					}

					// DBNullは許可しない
					ds.Tables[tableName].Columns[schemaInfo.Name].AllowDBNull = false;
				}
			}
		}

		/// <summary>
		/// 画面初期化処理
		/// </summary>
		private void DisplayInitialize()
		{
			_ds.Tables[TBL_PRTITEMSET].Rows.Clear();
			_ds.Tables[TBL_FPSORTINIT].Rows.Clear();

			this.ulFreePrtPprItemGrpCd.Text = string.Empty;
			this.tedPrtItemSetFilter.Text = string.Empty;

			StateButtonTool appendButtonTool = (StateButtonTool)this.utmMainToolbar.Tools["Append_StateButtonTool"];
			appendButtonTool.Checked = false;
			LabelTool modeLabelTool = (LabelTool)this.utmMainToolbar.Tools["Mode_LabelTool"];
			modeLabelTool.SharedProps.Caption = "CSV上書きモード";

			this.ndtFreePrtPprSchmGrpCd.Enabled = false;
			this.ubSchmAdd.Enabled = false;

			UpdateFilterCommboBox();

			ChangeEnableToSchmAdd();
		}

		/// <summary>
		/// フィルターコンボボックス更新処理
		/// </summary>
		private void UpdateFilterCommboBox()
		{
			this.cmbFreePrtPprSchmGrpCd.Items.Clear();

			if (_ds.Tables[TBL_FPSORTINIT].Rows.Count > 0)
			{
				List<int> schmGrpCdList = new List<int>();
				foreach (DataRow dr in _ds.Tables[TBL_FPSORTINIT].Rows)
				{
					if (!schmGrpCdList.Contains((int)dr[COL_FPSORTINIT_FREEPRTPPRSCHMGRPCD]))
						schmGrpCdList.Add((int)dr[COL_FPSORTINIT_FREEPRTPPRSCHMGRPCD]);
				}

				foreach (int schmGrpCd in schmGrpCdList)
					this.cmbFreePrtPprSchmGrpCd.Items.Add(schmGrpCd);
			}
			else
			{
				this.cmbFreePrtPprSchmGrpCd.Items.Add(0);
			}

			if (this.cmbFreePrtPprSchmGrpCd.Items.Count > 0)
				this.cmbFreePrtPprSchmGrpCd.SelectedIndex = 0;
		}

		/// <summary>
		/// 移動用ボタン入力制御処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 行移動用のボタンの入力制御を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.10.23</br>
		/// </remarks>
		private void ChangeEnableToMoveButton()
		{
			if (this.gridFPSortInit.ActiveRow != null)
			{
				if (this.gridFPSortInit.ActiveRow.Index == 0)
					this.ubUp.Enabled = false;
				else
					this.ubUp.Enabled = true;

				if (this.gridFPSortInit.ActiveRow.Index >= this.gridFPSortInit.Rows.Count - 1)
					this.ubDown.Enabled = false;
				else
					this.ubDown.Enabled = true;
			}
		}

		/// <summary>
		/// スキーマ追加用ボタン入力制御処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: スキーマ追加用のボタンの入力制御を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.10.23</br>
		/// </remarks>
		private void ChangeEnableToSchmAdd()
		{
			if (this.gridFPSortInit.Rows.Count > 0)
			{
				this.ndtFreePrtPprSchmGrpCd.Enabled = true;
				this.ubSchmAdd.Enabled = true;
			}
			else
			{
				this.ndtFreePrtPprSchmGrpCd.Enabled = false;
				this.ubSchmAdd.Enabled = false;
			}
		}

		/// <summary>
		/// データテーブル情報更新処理
		/// </summary>
        /// <param name="dr">自由帳票抽出条件設定マスタ</param>
        /// <param name="freePrtPprSchmGrpCd">インデックス</param>
		private void AddFPSortInitToDataTable(DataRow dr, int freePrtPprSchmGrpCd)
		{
			DataRow addRow = _ds.Tables[TBL_FPSORTINIT].NewRow();
			addRow[COL_COMMON_CREATEDATETIME]			= dr[COL_COMMON_CREATEDATETIME];			// 作成日時
			addRow[COL_COMMON_UPDATEDATETIME]			= dr[COL_COMMON_UPDATEDATETIME];			// 更新日時
			addRow[COL_COMMON_LOGICALDELETECODE]		= dr[COL_COMMON_LOGICALDELETECODE];			// 論理削除区分
			addRow[COL_FPSORTINIT_FREEPRTPPRITEMGRPCD]	= dr[COL_PRTITEMSET_FREEPRTPPRITEMGRPCD];	// 自由帳票項目グループコード
			addRow[COL_FPSORTINIT_FREEPRTPPRSCHMGRPCD]	= freePrtPprSchmGrpCd;						// 自由帳票スキーマグループコード
			addRow[COL_FPSORTINIT_SORTINGORDERCODE]		= dr[COL_PRTITEMSET_FREEPRTPAPERITEMCD];	// ソート順位コード
			addRow[COL_FPSORTINIT_SORTINGORDER]			= 0;										// ソート順位
			addRow[COL_FPSORTINIT_FREEPRTPAPERITEMNM]	= dr[COL_PRTITEMSET_FREEPRTPAPERITEMNM];	// 自由帳票項目名称
			addRow[COL_FPSORTINIT_DDNAME]				= dr[COL_PRTITEMSET_DDNAME];				// DD名称
			addRow[COL_FPSORTINIT_FILENM]				= dr[COL_PRTITEMSET_FILENM];				// ファイル名称
			addRow[COL_FPSORTINIT_SORTINGORDERDIVCD]	= 0;										// 昇順降順区分
			_ds.Tables[TBL_FPSORTINIT].Rows.Add(addRow);
		}

		/// <summary>
		/// 保存処理
		/// </summary>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス</returns>
		private int SaveProc(out string errMsg)
		{
			int status = 0;
			errMsg = string.Empty;

			string fileName = string.Empty;
			try
			{
				if (_ds.Tables[TBL_FPSORTINIT].Rows.Count != 0)
				{
					foreach (UltraGridRow row in this.gridFPSortInit.Rows)
						row.Cells[COL_FPSORTINIT_SORTINGORDER].Value = row.Index;

					Directory.SetCurrentDirectory(System.Windows.Forms.Application.StartupPath);

					StateButtonTool appendButtonTool = (StateButtonTool)this.utmMainToolbar.Tools["Append_StateButtonTool"];

					// ☆☆☆ CSVファイルの保存 ☆☆☆
					// 抽出条件初期値
					fileName = Path.Combine(SFANL08246CA.ctCSVSavePath, TBL_FPSORTINIT + ".csv");
					status = SFANL08246CA.SaveCsv(_ds, TBL_FPSORTINIT, SFANL08246CA.ctXSLFileName, fileName, appendButtonTool.Checked, out errMsg);

					// ☆☆☆ XMLファイルの保存 ☆☆☆
					if (status == 0)
					{
						int freePrtPprItemGrpCd = (int)_ds.Tables[TBL_PRTITEMSET].Rows[0][COL_PRTITEMSET_FREEPRTPPRITEMGRPCD];
						fileName = Path.Combine(SFANL08246CA.ctXMLSavePath, TBL_FPSORTINIT + "_" + freePrtPprItemGrpCd + ".xml");
						status = SFANL08246CA.SaveXml(_ds, TBL_FPSORTINIT, string.Empty, fileName, out errMsg);
					}
				}
				else
				{
					status = 4;
					errMsg = "データが入力されていません。";
				}
			}
			catch (Exception ex)
			{
				errMsg = "保存処理にて例外が発生しました。" + Environment.NewLine + ex.Message;
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// フォームロードイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.10.23</br>
		/// </remarks>
		private void SFANL08243UA_Load(object sender, EventArgs e)
		{
			string message = string.Empty;
			try
			{
				// 印字項目設定
				CreateDataTableSchema(_ds, TBL_PRTITEMSET);
				// 自由帳票抽出条件明細
				CreateDataTableSchema(_ds, TBL_FPSORTINIT);

				this.gridPrtItemSet.DataSource = _ds.Tables[TBL_PRTITEMSET];
				this.gridFPSortInit.DataSource = _ds.Tables[TBL_FPSORTINIT];

				DisplayInitialize();
			}
			catch (Exception ex)
			{
				message = "画面起動中に例外が発生しました。" + Environment.NewLine + ex.Message;
			}

			if (!string.IsNullOrEmpty(message))
			{
				MessageBox.Show(
					message,
					ctMSG_CAPTION,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1);

				this.Close();
			}
		}

		/// <summary>
		/// グリッドInitializeLayoutイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: レイアウトが初期化されたときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.10.23</br>
		/// </remarks>
		private void Grid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
			List<SchemaInfo> schemaInfoList = null;
			switch (e.Layout.Grid.Name)
			{
				case "gridFPSortInit": schemaInfoList = _fPSortInitSchemaInfoList; break;
				case "gridPrtItemSet": schemaInfoList = _prtItemSetSchemaInfoList; break;
			}

			if (schemaInfoList != null)
			{
				foreach (UltraGridColumn col in e.Layout.Bands[0].Columns)
				{
					SchemaInfo schemaInfo = schemaInfoList.Find(
						delegate(SchemaInfo wkSchemaInfo)
						{
							if (wkSchemaInfo.Name == col.Key)
								return true;
							else
								return false;
						}
					);

					col.Header.Caption = schemaInfo.Caption;
					col.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
					col.MaxLength = schemaInfo.Length;

					switch (e.Layout.Grid.Name)
					{
						case "gridPrtItemSet":
						{
							switch (col.Key)
							{
								case COL_PRTITEMSET_FREEPRTPAPERITEMCD:		// 自由帳票項目コード
								{
									col.CellAppearance.TextHAlign = HAlign.Right;
									break;
								}
								case COL_PRTITEMSET_FREEPRTPAPERITEMNM:		// 自由帳票項目名称
								{
									break;
								}
								default:
								{
									col.Hidden = true;
									break;
								}
							}
							break;
						}
						case "gridFPSortInit":
						{
							switch (col.Key)
							{
								case COL_FPSORTINIT_SORTINGORDERCODE:		// ソート順位コード
								{
									col.CellAppearance.TextHAlign = HAlign.Right;
									col.CellActivation = Activation.NoEdit;
									break;
								}
								case COL_FPSORTINIT_FREEPRTPAPERITEMNM:		// 自由帳票項目名称
								{
									col.CellActivation = Activation.NoEdit;
									break;
								}
								case COL_FPSORTINIT_SORTINGORDERDIVCD:		// 昇順降順区分
								{
									col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

									ValueList valueList = new ValueList();
									valueList.ValueListItems.Add(0, "なし");
									valueList.ValueListItems.Add(1, "昇順");
									valueList.ValueListItems.Add(2, "降順");
									col.ValueList = valueList;
									break;
								}
								default:
								{
									col.Hidden = true;
									break;
								}
							}
							break;
						}
					}
				}
			}
		}

		/// <summary>
		/// ↑ボタンClickイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ↑ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.10.23</br>
		/// </remarks>
		private void ubUp_Click(object sender, EventArgs e)
		{
			if (this.gridFPSortInit.ActiveRow != null)
			{
				int nowIndex = this.gridFPSortInit.ActiveRow.Index;
				if (nowIndex > 0)
				{
					this.gridFPSortInit.Rows.Move(this.gridFPSortInit.ActiveRow, nowIndex - 1, true);

					ChangeEnableToMoveButton();
				}
			}
		}

		/// <summary>
		/// ↓ボタンClickイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ↓ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.10.23</br>
		/// </remarks>
		private void ubDown_Click(object sender, EventArgs e)
		{
			if (this.gridFPSortInit.ActiveRow != null)
			{
				int nowIndex = this.gridFPSortInit.ActiveRow.Index;
				if (nowIndex < this.gridFPSortInit.Rows.Count - 1)
				{
					this.gridFPSortInit.Rows.Move(this.gridFPSortInit.ActiveRow, nowIndex + 1, true);

					ChangeEnableToMoveButton();
				}
			}
		}

		/// <summary>
		/// ×ボタンClickイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ×ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.10.23</br>
		/// </remarks>
		private void ubDelete_Click(object sender, EventArgs e)
		{
			int focusSetIndex = 0;

			if (this.gridFPSortInit.ActiveRow != null)
			{
				focusSetIndex = Math.Max(focusSetIndex, this.gridFPSortInit.ActiveRow.Index);

				int sortingOrderCode = (int)this.gridFPSortInit.ActiveRow.Cells[COL_FPSORTINIT_SORTINGORDERCODE].Value;
				DataRow[] drArray = _ds.Tables[TBL_FPSORTINIT].Select(COL_FPSORTINIT_SORTINGORDERCODE + "=" + sortingOrderCode);
				foreach (DataRow dr in drArray)
					_ds.Tables[TBL_FPSORTINIT].Rows.Remove(dr);

				if (focusSetIndex > 0) focusSetIndex--;

				ChangeEnableToMoveButton();

				ChangeEnableToSchmAdd();

				// 行が残っている場合は1行目をアクティブ化
				if (this.gridFPSortInit.Rows.Count > 0)
					this.gridFPSortInit.Rows[focusSetIndex].Activate();
			}
		}

		/// <summary>
		/// ツールバークリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: ツールバーがクリックされた時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.10.23</br>
		/// </remarks>
		private void utmMainToolbar_ToolClick(object sender, ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "Exit_ButtonTool":
				{
					this.Close();
					break;
				}
				case "Open_ButtonTool":
				{
					this.openFileDialog.Filter = "ソート順位初期値XMLファイル|FPSortInit*.xml";
					this.openFileDialog.InitialDirectory = Path.Combine(System.Windows.Forms.Application.StartupPath, SFANL08246CA.ctXMLSavePath);
					if (this.openFileDialog.ShowDialog() == DialogResult.OK)
					{
						DisplayInitialize();

						// 自由帳票抽出条件初期値
						_ds.Tables[TBL_FPSORTINIT].ReadXml(this.openFileDialog.FileName);

						// 印字項目グループ
						this.openFileDialog.Filter = "印字項目設定XMLファイル|PrtItemSet*.xml";
						this.openFileDialog.InitialDirectory = Path.Combine(System.Windows.Forms.Application.StartupPath, SFANL08246CA.ctXMLSavePath);
						if (this.openFileDialog.ShowDialog() == DialogResult.OK)
						{
							// 印字項目グループ
							_ds.Tables[TBL_PRTITEMSET].ReadXml(this.openFileDialog.FileName);

							UpdateFilterCommboBox();

							ChangeEnableToSchmAdd();
						}
						else
						{
							DisplayInitialize();
						}
					}
					break;
				}
				case "Save_ButtonTool":
				{
					string errMsg;
					int status = SaveProc(out errMsg);
					switch (status)
					{
						case 0:
						{
							MessageBox.Show(
								"保存しました。",
								ctMSG_CAPTION,
								MessageBoxButtons.OK,
								MessageBoxIcon.Information,
								MessageBoxDefaultButton.Button1);
							break;
						}
						case 4:
						{
							MessageBox.Show(
								errMsg,
								ctMSG_CAPTION,
								MessageBoxButtons.OK,
								MessageBoxIcon.Information,
								MessageBoxDefaultButton.Button1);
							break;
						}
						default:
						{
							MessageBox.Show(
								errMsg,
								ctMSG_CAPTION,
								MessageBoxButtons.OK,
								MessageBoxIcon.Error,
								MessageBoxDefaultButton.Button1);
							break;
						}
					}
					break;
				}
				case "New_ButtonTool":
				{
					this.openFileDialog.Filter = "印字項目設定XMLファイル|PrtItemSet*.xml";
					this.openFileDialog.InitialDirectory = Path.Combine(System.Windows.Forms.Application.StartupPath, SFANL08246CA.ctXMLSavePath);
					if (this.openFileDialog.ShowDialog() == DialogResult.OK)
					{
						DisplayInitialize();

						// 印字項目設定
						_ds.Tables[TBL_PRTITEMSET].ReadXml(this.openFileDialog.FileName);
						if (_ds.Tables[TBL_PRTITEMSET].Rows.Count > 0)
							this.ulFreePrtPprItemGrpCd.Text = _ds.Tables[TBL_PRTITEMSET].Rows[0][COL_PRTITEMSET_FREEPRTPPRITEMGRPCD].ToString();

						UpdateFilterCommboBox();
					}
					break;
				}
				case "Append_StateButtonTool":
				{
					StateButtonTool appendButtonTool = (StateButtonTool)e.Tool;
					LabelTool modeLabelTool = (LabelTool)this.utmMainToolbar.Tools["Mode_LabelTool"];
					if (appendButtonTool.Checked)
						modeLabelTool.SharedProps.Caption = "CSV追記モード";
					else
						modeLabelTool.SharedProps.Caption = "CSV上書きモード";
					break;
				}
			}
		}

		/// <summary>
		/// マウスグリッドダブルクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: マウスでコントロールをダブルクリックした時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.10.23</br>
		/// </remarks>
		private void gridPrtItemSet_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Point lastMouseDown = new Point(e.X, e.Y);
			// UIElementを利用して座標位置のコントロールを取得
			UIElement element = this.gridPrtItemSet.DisplayLayout.UIElement.ElementFromPoint(lastMouseDown);
			// クリックした位置がGridRowの場合のみ処理を行う
			UltraGridRow ultraGridRow = element.GetContext(typeof(UltraGridRow)) as UltraGridRow;
			if (ultraGridRow != null)
			{
				int freePrtPaperItemCd = (int)ultraGridRow.Cells[COL_PRTITEMSET_FREEPRTPAPERITEMCD].Value;
				DataRow[] drArray = _ds.Tables[TBL_FPSORTINIT].Select(COL_FPSORTINIT_SORTINGORDERCODE + "=" + freePrtPaperItemCd);
				if (drArray == null || drArray.Length == 0)
				{
					for (int ix = 0 ; ix != this.cmbFreePrtPprSchmGrpCd.Items.Count ; ix++)
						AddFPSortInitToDataTable(((DataRowView)ultraGridRow.ListObject).Row, (int)this.cmbFreePrtPprSchmGrpCd.Items[ix].DataValue);

					ChangeEnableToSchmAdd();
				}
			}
		}

		private void cmbFreePrtPprSchmGrpCd_SelectionChanged(object sender, EventArgs e)
		{
			if (this.cmbFreePrtPprSchmGrpCd.Items.Count > 0)
			{
				// ソート順位を採番
				foreach (UltraGridRow row in this.gridFPSortInit.Rows)
					row.Cells[COL_FPSORTINIT_SORTINGORDER].Value = row.Index;

				int freePrtPprSchmGrpCd = (int)this.cmbFreePrtPprSchmGrpCd.Value;
				_ds.Tables[TBL_FPSORTINIT].DefaultView.RowFilter = COL_FPSORTINIT_FREEPRTPPRSCHMGRPCD + "=" + freePrtPprSchmGrpCd;

				if (this.gridFPSortInit.Rows.Count > 0)
					this.gridFPSortInit.Rows[0].Activate();

				this.gridFPSortInit.DisplayLayout.Bands[0].Columns[COL_FPSORTINIT_SORTINGORDER].SortIndicator = SortIndicator.Ascending;
			}
		}

		private void ubSchmAdd_Click(object sender, EventArgs e)
		{
			try
			{
				int freePrtPprSchmGrpCd = this.ndtFreePrtPprSchmGrpCd.GetInt();

				// 既に追加済みのスキーマグループははじく
				for (int ix = 0 ; ix != this.cmbFreePrtPprSchmGrpCd.Items.Count ; ix++)
				{
					if (freePrtPprSchmGrpCd == (int)this.cmbFreePrtPprSchmGrpCd.Items[ix].DataValue)
					{
						MessageBox.Show("既に追加済みのスキーマグループコードです", ctMSG_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
						return;
					}
				}

				DataRow[] drArray = _ds.Tables[TBL_FPSORTINIT].Select(COL_FPSORTINIT_FREEPRTPPRSCHMGRPCD + "=" + 0);
				foreach (DataRow dr in drArray)
				{
					DataRow addRow = _ds.Tables[TBL_FPSORTINIT].NewRow();
					foreach (DataColumn col in _ds.Tables[TBL_FPSORTINIT].Columns)
					{
						if (col.ColumnName == COL_FPSORTINIT_FREEPRTPPRSCHMGRPCD)
							addRow[COL_FPSORTINIT_FREEPRTPPRSCHMGRPCD] = freePrtPprSchmGrpCd;
						else
							addRow[col.ColumnName] = dr[col.ColumnName];
					}
					_ds.Tables[TBL_FPSORTINIT].Rows.Add(addRow);
				}

				UpdateFilterCommboBox();
			}
			finally
			{
				this.ndtFreePrtPprSchmGrpCd.Clear();
			}
		}

		private void gridFPSortInit_AfterRowActivate(object sender, EventArgs e)
		{
			this.gridFPSortInit.ActiveRow.Selected = true;

			ChangeEnableToMoveButton();
		}

		private void tedPrtItemSetFilter_ValueChanged(object sender, EventArgs e)
		{
			if (_ds.Tables[TBL_PRTITEMSET].Rows.Count > 0)
			{
				if (!string.IsNullOrEmpty(this.tedPrtItemSetFilter.Text))
					_ds.Tables[TBL_PRTITEMSET].DefaultView.RowFilter = COL_PRTITEMSET_FREEPRTPAPERITEMNM + " LIKE '%" + this.tedPrtItemSetFilter.Text + "%'";
				else
					_ds.Tables[TBL_PRTITEMSET].DefaultView.RowFilter = string.Empty;
			}
		}
	}

	/// <summary>
	/// スキーマ情報クラス
	/// </summary>
	internal class SchemaInfo
	{
		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="name">名称</param>
		/// <param name="caption">キャプション</param>
		/// <param name="type">型</param>
        /// <param name="length"></param>
		public SchemaInfo(string name, string caption, Type type, int length)
		{
			_name = name;
			_caption = caption;
			_type = type;
			_length = length;
		}
		#endregion

		#region PrivateMember
		// 名称
		private string _name;
		// キャプション
		private string _caption;
		// 型
		private Type _type;
		// 桁数
		private int _length;
		#endregion

		#region Property
		/// <summary>名称</summary>
		public string Name
		{
			get
			{
				if (string.IsNullOrEmpty(_name))
					return string.Empty;
				else
					return _name;
			}
			set { _name = value; }
		}

		/// <summary>キャプション</summary>
		public string Caption
		{
			get
			{
				if (string.IsNullOrEmpty(_caption))
					return string.Empty;
				else
					return _caption;
			}
			set { _caption = value; }
		}

		/// <summary>型</summary>
		public Type Type
		{
			get { return _type; }
			set { _type = value; }
		}

		/// <summary>桁数</summary>
		public int Length
		{
			get { return _length; }
			set { _length = value; }
		}
		#endregion
	}
}