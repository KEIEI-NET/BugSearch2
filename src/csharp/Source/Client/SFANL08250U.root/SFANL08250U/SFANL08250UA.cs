using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting.ParamData;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;

namespace Broadleaf.Windows.Forms
{
	public partial class SFANL08250UA : Form
	{
		#region Const
		// MessageBoxヘッダーキャプション
		internal const string ctMSG_CAPTION = "自由帳票抽出条件初期値設定";
		
		// テーブル名称
		private const string TBL_PRTITEMGRP = "PrtItemGrpRF";
		private const string TBL_PRTITEMSET = "PrtItemSetRF";
		private const string TBL_FREPEXCNDD = "FrePExCndDRF";
		private const string TBL_FPECNDINIT = "FPECndInitRF";
		// 画面表示用
		private const string TBL_FREPPRECND_SETTING		= "FrePprECnd2Setting";
		private const string COL_FREEPRTPPRSCHMGRPCD	= "FreePrtPprSchmGrpCd";	// 自由帳票スキーマグループコード
		private const string COL_EXTRACONDITIONTITLE	= "ExtraConditionTitle";	// 抽出条件タイトル
		private const string COL_DISPLAYORDER			= "DisplayOrder";			// 表示順位
		private const string COL_FREPRTPPREXTRACONDCD	= "FrePrtPprExtraCondCd";	// 自由帳票抽出条件枝番
		private const string COL_FREPPRECND				= "FrePprECnd2";			// 自由帳票抽出条件マスタ
		// 共通ファイルヘッダー
		#region CommonFileHeader
		private const string COL_COMMON_CREATEDATETIME		= "CreateDateTime";		// 作成日時
		private const string COL_COMMON_UPDATEDATETIME		= "UpdateDateTime";		// 更新日時
		private const string COL_COMMON_ENTERPRISECODE		= "EnterpriseCode";		// 企業コード
		private const string COL_COMMON_FILEHEADERGUID		= "FileHeaderGuid";		// GUID
		private const string COL_COMMON_UPDEMPLOYEECODE		= "UpdEmployeeCode";	// 更新従業員コード
		private const string COL_COMMON_UPDASSEMBLYID1		= "UpdAssemblyId1";		// 更新アセンブリID1
		private const string COL_COMMON_UPDASSEMBLYID2		= "UpdAssemblyId2";		// 更新アセンブリID2
		private const string COL_COMMON_LOGICALDELETECODE	= "LogicalDeleteCode";	// 論理削除区分
		#endregion
		// 印字項目グループ
		#region PrtItemGrp
		private const string COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD		= "FreePrtPprItemGrpCd";	// 自由帳票項目グループコード
		private const string COL_PRTITEMGRP_FREEPRTPPRITEMGRPNM		= "FreePrtPprItemGrpNm";	// 自由帳票項目グループ名称
		private const string COL_PRTITEMGRP_PRINTPAPERUSEDIVCD		= "PrintPaperUseDivcd";		// 帳票使用区分
		private const string COL_PRTITEMGRP_EXTRACTIONPGID			= "ExtractionPgId";			// 抽出プログラムID
		private const string COL_PRTITEMGRP_EXTRACTIONPGCLASSID		= "ExtractionPgClassId";	// 抽出プログラムクラスID
		private const string COL_PRTITEMGRP_OUTPUTPGID				= "OutputPgId";				// 出力プログラムID
		private const string COL_PRTITEMGRP_OUTPUTPGCLASSID			= "OutputPgClassId";		// 出力プログラムクラスID
		private const string COL_PRTITEMGRP_DATAINPUTSYSTEM			= "DataInputSystem";		// データ入力システム
		private const string COL_PRTITEMGRP_LINKSLIPDATAINPUTSYS	= "LinkSlipDataInputSys";	// リンク伝票データ入力システム
		private const string COL_PRTITEMGRP_LINKSLIPPRTKIND			= "LinkSlipPrtKind";		// リンク伝票印刷種別
		private const string COL_PRTITEMGRP_LINKSLIPPRTSETPPRID		= "LinkSlipPrtSetPprId";	// リンク伝票印刷設定用帳票ID
		private const string COL_PRTITEMGRP_EXTRASECTIONKINDCD		= "ExtraSectionKindCd";		// 抽出拠点種別区分
		private const string COL_PRTITEMGRP_EXTRASECTIONSELEXIST	= "ExtraSectionSelExist";	// 抽出拠点選択有無
		private const string COL_PRTITEMGRP_FORMFEEDLINECOUNT		= "FormFeedLineCount";		// 改頁行数
		private const string COL_PRTITEMGRP_CRCHARCNT				= "CrCharCnt";				// 改行文字数
		#endregion
		// 印字項目設定
		#region PrtItemSet
		private const string COL_PRTITEMSET_FREEPRTPPRITEMGRPCD		= "FreePrtPprItemGrpCd";	// 自由帳票項目グループコード
		internal const string COL_PRTITEMSET_FREEPRTPAPERITEMCD		= "FreePrtPaperItemCd";		// 自由帳票項目コード
		internal const string COL_PRTITEMSET_FREEPRTPAPERITEMNM		= "FreePrtPaperItemNm";		// 自由帳票項目名称
		private const string COL_PRTITEMSET_FILENM					= "FileNm";					// ファイル名称
		private const string COL_PRTITEMSET_DDCHARCNT				= "DDCharCnt";				// DD桁数
		private const string COL_PRTITEMSET_DDNAME					= "DDName";					// DD名称
		private const string COL_PRTITEMSET_REPORTCONTROLCODE		= "ReportControlCode";		// レポートコントロール区分
		private const string COL_PRTITEMSET_HEADERUSEDIVCD			= "HeaderUseDivCd";			// ヘッダー使用区分
		private const string COL_PRTITEMSET_DETAILUSEDIVCD			= "DetailUseDivCd";			// 明細使用区分
		private const string COL_PRTITEMSET_FOOTERUSEDIVCD			= "FooterUseDivCd";			// フッター使用区分
		internal const string COL_PRTITEMSET_EXTRACONDITIONDIVCD	= "ExtraConditionDivCd";	// 抽出条件区分
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
		#endregion
		// 自由帳票抽出条件明細
		#region FrePExCndD
		private const string COL_FREPEXCNDD_EXTRACONDDETAILGRPCD	= "ExtraCondDetailGrpCd";	// 抽出条件明細グループコード
		private const string COL_FREPEXCNDD_EXTRACONDDETAILCODE		= "ExtraCondDetailCode";	// 抽出条件明細コード
		private const string COL_FREPEXCNDD_EXTRACONDDETAILNAME		= "ExtraCondDetailName";	// 抽出条件明細名称
		#endregion
		// 自由帳票抽出条件初期値
		#region FPECndInit
		private const string COL_FPECNDINIT_FREEPRTPPRSCHMGRPCD		= "FreePrtPprSchmGrpCd";	// 自由帳票スキーマグループコード
		private const string COL_FPECNDINIT_FREPRTPPREXTRACONDCD	= "FrePrtPprExtraCondCd";	// 自由帳票抽出条件枝番
		private const string COL_FPECNDINIT_DISPLAYORDER			= "DisplayOrder";			// 表示順位
		private const string COL_FPECNDINIT_STEXTRANUMCODE			= "StExtraNumCode";			// 抽出開始コード（数値）
		private const string COL_FPECNDINIT_EDEXTRANUMCODE			= "EdExtraNumCode";			// 抽出終了コード（数値）
		private const string COL_FPECNDINIT_STEXTRACHARCODE			= "StExtraCharCode";		// 抽出開始コード（文字）
		private const string COL_FPECNDINIT_EDEXTRACHARCODE			= "EdExtraCharCode";		// 抽出終了コード（文字）
		private const string COL_FPECNDINIT_STEXTRADATEBASECD		= "StExtraDateBaseCd";		// 抽出開始日付（基準）
		private const string COL_FPECNDINIT_STEXTRADATESIGNCD		= "StExtraDateSignCd";		// 抽出開始日付（正負）
		private const string COL_FPECNDINIT_STEXTRADATENUM			= "StExtraDateNum";			// 抽出開始日付（数値）
		private const string COL_FPECNDINIT_STEXTRADATEUNITCD		= "StExtraDateUnitCd";		// 抽出開始日付（単位）
		private const string COL_FPECNDINIT_STARTEXTRADATE			= "StartExtraDate";			// 抽出開始日付（日付）
		private const string COL_FPECNDINIT_EDEXTRADATEBASECD		= "EdExtraDateBaseCd";		// 抽出終了日付（基準）
		private const string COL_FPECNDINIT_EDEXTRADATESIGNCD		= "EdExtraDateSignCd";		// 抽出終了日付（正負）
		private const string COL_FPECNDINIT_EDEXTRADATENUM			= "EdExtraDateNum";			// 抽出終了日付（数値）
		private const string COL_FPECNDINIT_EDEXTRADATEUNITCD		= "EdExtraDateUnitCd";		// 抽出終了日付（単位）
		private const string COL_FPECNDINIT_ENDEXTRADATE			= "EndExtraDate";			// 抽出終了日付（日付）
		private const string COL_FPECNDINIT_CHECKITEMCODE1			= "CheckItemCode1";			// チェック項目コード1
		private const string COL_FPECNDINIT_CHECKITEMCODE2			= "CheckItemCode2";			// チェック項目コード2
		private const string COL_FPECNDINIT_CHECKITEMCODE3			= "CheckItemCode3";			// チェック項目コード3
		private const string COL_FPECNDINIT_CHECKITEMCODE4			= "CheckItemCode4";			// チェック項目コード4
		private const string COL_FPECNDINIT_CHECKITEMCODE5			= "CheckItemCode5";			// チェック項目コード5
		private const string COL_FPECNDINIT_CHECKITEMCODE6			= "CheckItemCode6";			// チェック項目コード6
		private const string COL_FPECNDINIT_CHECKITEMCODE7			= "CheckItemCode7";			// チェック項目コード7
		private const string COL_FPECNDINIT_CHECKITEMCODE8			= "CheckItemCode8";			// チェック項目コード8
		private const string COL_FPECNDINIT_CHECKITEMCODE9			= "CheckItemCode9";			// チェック項目コード9
		private const string COL_FPECNDINIT_CHECKITEMCODE10			= "CheckItemCode10";		// チェック項目コード10
		#endregion
		#endregion

		#region PrivateMember
		// データ保持用DataSet
		private DataSet				_ds;
		// ファイルレイアウト情報保持用
		private List<SchemaInfo>	_fPECndInitSchemaInfoList;
		// 変更チェックフラグ
		private int					_buffCode;
		#endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SFANL08250UA()
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
				case TBL_FREPPRECND_SETTING:
				{
					schemaInfoList.Add(new SchemaInfo(COL_FREEPRTPPRSCHMGRPCD,	"スキーマグループ",		typeof(int),			4));	// 自由帳票スキーマグループコード
					schemaInfoList.Add(new SchemaInfo(COL_FREPRTPPREXTRACONDCD,	"抽出条件枝番",			typeof(int),			2));	// 自由帳票抽出条件枝番
					schemaInfoList.Add(new SchemaInfo(COL_DISPLAYORDER,			"表示順位",				typeof(int),			4));	// 表示順位
					schemaInfoList.Add(new SchemaInfo(COL_EXTRACONDITIONTITLE,	"条件タイトル",			typeof(string),			30));	// 抽出条件タイトル
					schemaInfoList.Add(new SchemaInfo(COL_FREPPRECND,			"自由帳票抽出条件マスタ",	typeof(FrePprECnd2),	1));	// 自由帳票抽出条件マスタ
					break;
				}
				case TBL_PRTITEMGRP:
				{
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_CREATEDATETIME,			"作成日時",						typeof(long),	19));	// 作成日時
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_UPDATEDATETIME,			"更新日時",						typeof(long),	19));	// 更新日時
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_LOGICALDELETECODE,			"論理削除区分",					typeof(int),	2));	// 論理削除区分
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD,	"自由帳票項目グループコード",		typeof(int),	4));	// 自由帳票項目グループコード
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_FREEPRTPPRITEMGRPNM,	"自由帳票項目グループ名称",		typeof(string),	20));	// 自由帳票項目グループ名称
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_PRINTPAPERUSEDIVCD,	"帳票使用区分",					typeof(int),	2));	// 帳票使用区分
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_EXTRACTIONPGID,		"抽出プログラムID",				typeof(string),	16));	// 抽出プログラムID
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_EXTRACTIONPGCLASSID,	"抽出プログラムクラスID",			typeof(string),	80));	// 抽出プログラムクラスID
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_OUTPUTPGID,			"出力プログラムID",				typeof(string),	16));	// 出力プログラムID
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_OUTPUTPGCLASSID,		"出力プログラムクラスID",			typeof(string),	80));	// 出力プログラムクラスID
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_DATAINPUTSYSTEM,		"データ入力システム",				typeof(int),	2));	// データ入力システム
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_LINKSLIPDATAINPUTSYS,	"リンク伝票データ入力システム",	typeof(int),	2));	// リンク伝票データ入力システム
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_LINKSLIPPRTKIND,		"リンク伝票印刷種別",				typeof(int),	4));	// リンク伝票印刷種別
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_LINKSLIPPRTSETPPRID,	"リンク伝票印刷設定用帳票ID",		typeof(string),	24));	// リンク伝票印刷設定用帳票ID
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_EXTRASECTIONKINDCD,	"抽出拠点種別区分",				typeof(int),	2));	// 抽出拠点種別区分
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_EXTRASECTIONSELEXIST,	"抽出拠点選択有無",				typeof(int),	2));	// 抽出拠点選択有無
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_FORMFEEDLINECOUNT,		"改頁行数",						typeof(int),	4));	// 改頁行数
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_CRCHARCNT,				"改行文字数",					typeof(int),	4));	// 改行文字数
					break;
				}
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
				case TBL_FREPEXCNDD:
				{
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_CREATEDATETIME,			"作成日時",						typeof(long),	19));	// 作成日時
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_UPDATEDATETIME,			"更新日時",						typeof(long),	19));	// 更新日時
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_ENTERPRISECODE,			"企業コード",					typeof(string),	16));	// 企業コード
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_FILEHEADERGUID,			"GUID",							typeof(Guid),	32));	// GUID
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_UPDEMPLOYEECODE,			"更新従業員コード",				typeof(string),	9));	// 更新従業員コード
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_UPDASSEMBLYID1,			"更新アセンブリID1",				typeof(string),	30));	// 更新アセンブリID1
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_UPDASSEMBLYID2,			"更新アセンブリID2",				typeof(string),	30));	// 更新アセンブリID2
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_LOGICALDELETECODE,			"論理削除区分",					typeof(int),	2));	// 論理削除区分
					schemaInfoList.Add(new SchemaInfo(COL_FREPEXCNDD_EXTRACONDDETAILGRPCD,	"抽出条件明細グループコード",		typeof(int),	4));	// 抽出条件明細グループコード
					schemaInfoList.Add(new SchemaInfo(COL_FREPEXCNDD_EXTRACONDDETAILCODE,	"抽出条件明細コード",				typeof(int),	4));	// 抽出条件明細コード
					schemaInfoList.Add(new SchemaInfo(COL_FREPEXCNDD_EXTRACONDDETAILNAME,	"抽出条件明細名称",				typeof(string),	20));	// 抽出条件明細名称
					break;
				}
				case TBL_FPECNDINIT:
				{
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_CREATEDATETIME,			"作成日時",						typeof(long),	19));	// 作成日時
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_UPDATEDATETIME,			"更新日時",						typeof(long),	19));	// 更新日時
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_LOGICALDELETECODE,			"論理削除区分",					typeof(int),	2));	// 論理削除区分
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_FREEPRTPPRSCHMGRPCD,	"自由帳票スキーマグループコード", typeof(int),		4));	// 自由帳票スキーマグループコード
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_FREPRTPPREXTRACONDCD,	"自由帳票抽出条件枝番",			typeof(int),	3));	// 自由帳票抽出条件枝番
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_DISPLAYORDER,			"表示順位",						typeof(int),	4));	// 表示順位
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_STEXTRANUMCODE,		"抽出開始コード（数値）",			typeof(int),	12));	// 抽出開始コード（数値）
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_EDEXTRANUMCODE,		"抽出終了コード（数値）",			typeof(int),	12));	// 抽出終了コード（数値）
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_STEXTRACHARCODE,		"抽出開始コード（文字）",			typeof(string),	30));	// 抽出開始コード（文字）
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_EDEXTRACHARCODE,		"抽出終了コード（文字）",			typeof(string),	20));	// 抽出終了コード（文字）
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_STEXTRADATEBASECD,		"抽出開始日付（基準）",			typeof(int),	2));	// 抽出開始日付（基準）
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_STEXTRADATESIGNCD,		"抽出開始日付（正負）",			typeof(int),	2));	// 抽出開始日付（正負）
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_STEXTRADATENUM,		"抽出開始日付（数値）",			typeof(int),	2));	// 抽出開始日付（数値）
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_STEXTRADATEUNITCD,		"抽出開始日付（単位）",			typeof(int),	2));	// 抽出開始日付（単位）
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_STARTEXTRADATE,		"抽出開始日付（日付）",			typeof(int),	8));	// 抽出開始日付（日付）
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_EDEXTRADATEBASECD,		"抽出終了日付（基準）",			typeof(int),	2));	// 抽出終了日付（基準）
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_EDEXTRADATESIGNCD,		"抽出終了日付（正負）",			typeof(int),	2));	// 抽出終了日付（正負）
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_EDEXTRADATENUM,		"抽出終了日付（数値）",			typeof(int),	2));	// 抽出終了日付（数値）
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_EDEXTRADATEUNITCD,		"抽出終了日付（単位）",			typeof(int),	2));	// 抽出終了日付（単位）
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_ENDEXTRADATE,			"抽出終了日付（日付）",			typeof(int),	8));	// 抽出終了日付（日付）
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_CHECKITEMCODE1,		"チェック項目コード1",			typeof(int),	8));	// チェック項目コード1
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_CHECKITEMCODE2,		"チェック項目コード1",			typeof(int),	8));	// チェック項目コード2
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_CHECKITEMCODE3,		"チェック項目コード1",			typeof(int),	8));	// チェック項目コード3
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_CHECKITEMCODE4,		"チェック項目コード1",			typeof(int),	8));	// チェック項目コード4
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_CHECKITEMCODE5,		"チェック項目コード1",			typeof(int),	8));	// チェック項目コード5
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_CHECKITEMCODE6,		"チェック項目コード1",			typeof(int),	8));	// チェック項目コード6
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_CHECKITEMCODE7,		"チェック項目コード1",			typeof(int),	8));	// チェック項目コード7
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_CHECKITEMCODE8,		"チェック項目コード1",			typeof(int),	8));	// チェック項目コード8
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_CHECKITEMCODE9,		"チェック項目コード1",			typeof(int),	8));	// チェック項目コード9
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_CHECKITEMCODE10,		"チェック項目コード1",			typeof(int),	8));	// チェック項目コード10
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
        /// <param name="allowDBNull"></param>
		private void CreateDataTableSchema(DataSet ds, string tableName, bool allowDBNull)
		{
			List<SchemaInfo> schemaInfoList = GetSchemaInfoList(tableName);

			if (schemaInfoList != null)
			{
				if (tableName == TBL_FREPPRECND_SETTING)
					_fPECndInitSchemaInfoList = schemaInfoList;

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
					ds.Tables[tableName].Columns[schemaInfo.Name].AllowDBNull = allowDBNull;
				}
			}
		}

		/// <summary>
		/// 画面初期化処理
		/// </summary>
		private void DisplayInitialize()
		{
			_ds.Tables[TBL_FREPPRECND_SETTING].Rows.Clear();
			_ds.Tables[TBL_PRTITEMGRP].Rows.Clear();
			_ds.Tables[TBL_PRTITEMSET].Rows.Clear();
			_ds.Tables[TBL_FREPEXCNDD].Rows.Clear();
			_ds.Tables[TBL_FPECNDINIT].Rows.Clear();

			StateButtonTool appendButtonTool = (StateButtonTool)this.utmMainToolbar.Tools["Append_StateButtonTool"];
			appendButtonTool.Checked = false;
			LabelTool modeLabelTool = (LabelTool)this.utmMainToolbar.Tools["Mode_LabelTool"];
			modeLabelTool.SharedProps.Caption = "CSV上書きモード";

			this.ndtDisplayOder.Clear();
			this.tedExtraConditionTitle.Text = string.Empty;
			this.cmdExtraConditionTypeCd.SelectedIndex = -1;

			UpdateFilterCommboBox();
		}

		private Type CreateDataClassFromDataRow<Type>(DataRow dr)
		{
			PropertyInfo[] propInfoArray = typeof(Type).GetProperties();

			Assembly assm = typeof(Type).Assembly;
			object instance = assm.CreateInstance(typeof(Type).FullName);

			foreach (PropertyInfo propInfo in propInfoArray)
			{
				if (dr.Table.Columns.Contains(propInfo.Name))
				{
					switch (propInfo.Name)
					{
						case COL_COMMON_CREATEDATETIME:
						case COL_COMMON_UPDATEDATETIME:
						{
							propInfo.SetValue(instance, new DateTime((long)dr[propInfo.Name]), null);
							break;
						}
						default:
						{
							if (propInfo.PropertyType.Equals(typeof(DateTime)))
								propInfo.SetValue(instance, TDateTime.LongDateToDateTime((int)dr[propInfo.Name]), null);
							else
								propInfo.SetValue(instance, dr[propInfo.Name], null);
							break;
						}
					}
				}
			}
			return (Type)instance;
		}

		private List<Type> CreateListFromDataSet<Type>(string tableName)
		{
			List<Type> retList = new List<Type>();
			PropertyInfo[] propInfoArray = typeof(Type).GetProperties();
			foreach (DataRow dr in _ds.Tables[tableName].Rows)
			{
				Assembly assm = typeof(Type).Assembly;
				object instance = assm.CreateInstance(typeof(Type).FullName);
				retList.Add((Type)instance);

				foreach (PropertyInfo propInfo in propInfoArray)
				{
					if (_ds.Tables[tableName].Columns.Contains(propInfo.Name))
					{
						switch (propInfo.Name)
						{
							case COL_COMMON_CREATEDATETIME:
							case COL_COMMON_UPDATEDATETIME:
							{
								propInfo.SetValue(instance, new DateTime((long)dr[propInfo.Name]), null);
								break;
							}
							default:
							{
								if (propInfo.PropertyType.Equals(typeof(DateTime)))
									propInfo.SetValue(instance, TDateTime.LongDateToDateTime((int)dr[propInfo.Name]), null);
								else
									propInfo.SetValue(instance, dr[propInfo.Name], null);
								break;
							}
						}
					}
				}
			}
			return retList;
		}

		/// <summary>
		/// 自由帳票抽出条件設定マスタ作成処理
		/// </summary>
        /// <param name="freePrtPprSchmGrpCd">スキーマグループ</param>
		/// <returns>自由帳票抽出条件設定マスタリスト</returns>
		private List<FrePprECnd2> CreateFrePprECnd2FromPrtItemSetList(int freePrtPprSchmGrpCd)
		{
			List<FrePprECnd2> frePprECndList = new List<FrePprECnd2>();
			List<PrtItemSetWork> prtItemSetList = CreateListFromDataSet<PrtItemSetWork>(TBL_PRTITEMSET);
			foreach (PrtItemSetWork prtItemSet in prtItemSetList)
			{
			    if (prtItemSet.ExtraConditionDivCd != 0)
					frePprECndList.Add(CreateFrePprECnd2FromPrtItemSet(prtItemSet, freePrtPprSchmGrpCd));
			}

			return frePprECndList;
		}

		private FrePprECnd2 CreateFrePprECnd2FromPrtItemSet(PrtItemSetWork prtItemSet, int freePrtPprSchmGrpCd)
		{
	        FrePprECnd2 frePprECnd = new FrePprECnd2();
			frePprECnd.CreateDateTime		= prtItemSet.CreateDateTime;
			frePprECnd.UpdateDateTime		= prtItemSet.UpdateDateTime;
			frePprECnd.LogicalDeleteCode	= prtItemSet.LogicalDeleteCode;
			frePprECnd.FreePrtPprSchmGrpCd	= freePrtPprSchmGrpCd;				// 自由帳票スキーマグループコード
	        frePprECnd.FrePrtPprExtraCondCd = prtItemSet.FreePrtPaperItemCd;	// 自由帳票抽出条件枝番
	        frePprECnd.ExtraConditionDivCd	= prtItemSet.ExtraConditionDivCd;	// 抽出条件区分
	        frePprECnd.ExtraConditionTypeCd	= prtItemSet.ExtraConditionTypeCd;	// 抽出条件タイプ
	        frePprECnd.ExtraConditionTitle	= prtItemSet.FreePrtPaperItemNm;	// 抽出条件タイトル
	        frePprECnd.DDName				= prtItemSet.DDName;				// DD名称
	        frePprECnd.DDCharCnt			= prtItemSet.DDCharCnt;				// DD桁数
	        frePprECnd.ExtraCondDetailGrpCd = prtItemSet.ExtraCondDetailGrpCd;	// 抽出条件明細グループコード
	        frePprECnd.StExtraDateBaseCd	= 2;								// 抽出開始日付（基準）
	        frePprECnd.EdExtraDateBaseCd	= 2;								// 抽出終了日付（基準）
	        frePprECnd.DisplayOrder			= 999;
	        frePprECnd.NecessaryExtraCondCd = prtItemSet.NecessaryExtraCondCd;	// 必須抽出条件区分
	        frePprECnd.FileNm				= prtItemSet.FileNm;				// ファイル名称

			return frePprECnd;
		}

		/// <summary>
		/// 自由帳票抽出条件設定マスタマージ処理
		/// </summary>
        /// <param name="frePprECndList">マージ対象自由帳票抽出条件設定マスタ</param>
        /// <param name="fPECndInitList">上書き対象自由帳票抽出条件設定マスタ</param>
		/// <returns>マージ済み自由帳票抽出条件設定マスタ</returns>
		private List<FrePprECnd2> MergeFrePprECnd2(List<FrePprECnd2> frePprECndList, List<FPECndInitWork> fPECndInitList)
		{
			List<FrePprECnd2> retList = new List<FrePprECnd2>();
			foreach (FrePprECnd2 frePprECnd in frePprECndList)
			{
				FrePprECnd2 frePprECndClone = frePprECnd.Clone();

				FPECndInitWork fPECndInit = fPECndInitList.Find(
						delegate(FPECndInitWork fPECndInitWork)
						{
							if (fPECndInitWork.FreePrtPprSchmGrpCd == frePprECnd.FreePrtPprSchmGrpCd &&
								fPECndInitWork.FrePrtPprExtraCondCd == frePprECnd.FrePrtPprExtraCondCd)
								return true;
							else
								return false;
						}
					);
				if (fPECndInit != null)
				{
					frePprECndClone.FreePrtPprSchmGrpCd = fPECndInit.FreePrtPprSchmGrpCd;
					frePprECndClone.DisplayOrder		= fPECndInit.DisplayOrder;
					frePprECndClone.StExtraNumCode		= fPECndInit.StExtraNumCode;
					frePprECndClone.EdExtraNumCode		= fPECndInit.EdExtraNumCode;
					frePprECndClone.StExtraCharCode		= fPECndInit.StExtraCharCode;
					frePprECndClone.EdExtraCharCode		= fPECndInit.EdExtraCharCode;
					frePprECndClone.StExtraDateBaseCd	= fPECndInit.StExtraDateBaseCd;
					frePprECndClone.StExtraDateSignCd	= fPECndInit.StExtraDateSignCd;
					frePprECndClone.StExtraDateNum		= fPECndInit.StExtraDateNum;
					frePprECndClone.StExtraDateUnitCd	= fPECndInit.StExtraDateUnitCd;
					frePprECndClone.StartExtraDate		= fPECndInit.StartExtraDate;
					frePprECndClone.EdExtraDateBaseCd	= fPECndInit.EdExtraDateBaseCd;
					frePprECndClone.EdExtraDateSignCd	= fPECndInit.EdExtraDateSignCd;
					frePprECndClone.EdExtraDateNum		= fPECndInit.EdExtraDateNum;
					frePprECndClone.EdExtraDateUnitCd	= fPECndInit.EdExtraDateUnitCd;
					frePprECndClone.EndExtraDate		= fPECndInit.EndExtraDate;
					frePprECndClone.CheckItemCode1		= fPECndInit.CheckItemCode1;
					frePprECndClone.CheckItemCode2		= fPECndInit.CheckItemCode2;
					frePprECndClone.CheckItemCode3		= fPECndInit.CheckItemCode3;
					frePprECndClone.CheckItemCode4		= fPECndInit.CheckItemCode4;
					frePprECndClone.CheckItemCode5		= fPECndInit.CheckItemCode5;
					frePprECndClone.CheckItemCode6		= fPECndInit.CheckItemCode6;
					frePprECndClone.CheckItemCode7		= fPECndInit.CheckItemCode7;
					frePprECndClone.CheckItemCode8		= fPECndInit.CheckItemCode8;
					frePprECndClone.CheckItemCode9		= fPECndInit.CheckItemCode9;
					frePprECndClone.CheckItemCode10		= fPECndInit.CheckItemCode10;

					retList.Add(frePprECndClone);
				}
			}

			return retList;
		}

		/// <summary>
		/// データテーブル情報更新処理
		/// </summary>
		/// <param name="frePprECnd">自由帳票抽出条件設定マスタ</param>
		/// <param name="index">インデックス</param>
		private void SetFrePprECnd2ToDataTable(FrePprECnd2 frePprECnd, int index)
		{
			DataRow dr;
			if (index < 0)
			{
				dr = _ds.Tables[TBL_FREPPRECND_SETTING].NewRow();
				_ds.Tables[TBL_FREPPRECND_SETTING].Rows.Add(dr);
			}
			else
			{
				dr = _ds.Tables[TBL_FREPPRECND_SETTING].Rows[index];
			}

			dr[COL_FREEPRTPPRSCHMGRPCD]		= frePprECnd.FreePrtPprSchmGrpCd;	// 自由帳票スキーマグループコード
			dr[COL_FREPRTPPREXTRACONDCD]	= frePprECnd.FrePrtPprExtraCondCd;	// 自由帳票抽出条件枝番
			dr[COL_DISPLAYORDER]			= frePprECnd.DisplayOrder;			// 表示順位
			dr[COL_EXTRACONDITIONTITLE]		= frePprECnd.ExtraConditionTitle;	// 抽出条件タイトル
			dr[COL_FREPPRECND]				= frePprECnd;						// 自由帳票抽出条件マスタ
		}

		private void UpdateFilterCommboBox()
		{
			this.cmbFreePrtPprSchmGrpCd.Items.Clear();
			List<int> schmGrpCdList = new List<int>();
			foreach (DataRow dr in _ds.Tables[TBL_FREPPRECND_SETTING].Rows)
			{
				if (!schmGrpCdList.Contains((int)dr[COL_FREEPRTPPRSCHMGRPCD]))
					schmGrpCdList.Add((int)dr[COL_FREEPRTPPRSCHMGRPCD]);
			}

			foreach (int schmGrpCd in schmGrpCdList)
				this.cmbFreePrtPprSchmGrpCd.Items.Add(schmGrpCd);

			if (this.cmbFreePrtPprSchmGrpCd.Items.Count > 0)
				this.cmbFreePrtPprSchmGrpCd.SelectedIndex = 0;
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
				if (_ds.Tables[TBL_FREPPRECND_SETTING].Rows.Count != 0)
				{
					this.ubFPECndInitAddRow.Focus();
					this.gridFPECndInit.ActiveRow = null;
					this.gridFPECndInit.Rows[0].Activate();

					Directory.SetCurrentDirectory(System.Windows.Forms.Application.StartupPath);

					StateButtonTool appendButtonTool = (StateButtonTool)this.utmMainToolbar.Tools["Append_StateButtonTool"];

					_ds.Tables[TBL_FPECNDINIT].Rows.Clear();
					List<FPECndInitWork> fPECndInitList = new List<FPECndInitWork>();
					foreach (DataRow dr in _ds.Tables[TBL_FREPPRECND_SETTING].Rows)
					{
						FrePprECnd2 frePprECnd2 = (FrePprECnd2)dr[COL_FREPPRECND];
						if (frePprECnd2.UsedFlg == 0)
						{
							frePprECnd2.StExtraNumCode		= 0;
							frePprECnd2.EdExtraNumCode		= 0;
							frePprECnd2.StExtraCharCode		= string.Empty;
							frePprECnd2.EdExtraCharCode		= string.Empty;
							frePprECnd2.StExtraDateBaseCd	= 2;
							frePprECnd2.StExtraDateSignCd	= 0;
							frePprECnd2.StExtraDateNum		= 0;
							frePprECnd2.StExtraDateUnitCd	= 0;
							frePprECnd2.StartExtraDate		= 0;
							frePprECnd2.EdExtraDateBaseCd	= 2;
							frePprECnd2.EdExtraDateSignCd	= 0;
							frePprECnd2.EdExtraDateNum		= 0;
							frePprECnd2.EdExtraDateUnitCd	= 0;
							frePprECnd2.EndExtraDate		= 0;
							frePprECnd2.CheckItemCode1		= -1;
							frePprECnd2.CheckItemCode2		= -1;
							frePprECnd2.CheckItemCode3		= -1;
							frePprECnd2.CheckItemCode4		= -1;
							frePprECnd2.CheckItemCode5		= -1;
							frePprECnd2.CheckItemCode6		= -1;
							frePprECnd2.CheckItemCode7		= -1;
							frePprECnd2.CheckItemCode8		= -1;
							frePprECnd2.CheckItemCode9		= -1;
							frePprECnd2.CheckItemCode10		= -1;
						}
						fPECndInitList.Add((FPECndInitWork)DBAndXMLDataMergeParts.CopyPropertyInClass(frePprECnd2, typeof(FPECndInitWork)));
					}
					PropertyInfo[] propInfoArray = typeof(FPECndInitWork).GetProperties();
					foreach (FPECndInitWork fPECndInit in fPECndInitList)
					{
						if (fPECndInit.FreePrtPprSchmGrpCd == 0) continue;

						DataRow dr = _ds.Tables[TBL_FPECNDINIT].NewRow();
						_ds.Tables[TBL_FPECNDINIT].Rows.Add(dr);

						foreach (PropertyInfo propInfo in propInfoArray)
						{
							if (_ds.Tables[TBL_FPECNDINIT].Columns.Contains(propInfo.Name))
							{
								switch (propInfo.Name)
								{
									case COL_COMMON_CREATEDATETIME:
									case COL_COMMON_UPDATEDATETIME:
									{
										dr[propInfo.Name] = ((DateTime)propInfo.GetValue(fPECndInit, null)).Ticks;
										break;
									}
									default:
									{
										if (propInfo.PropertyType.Equals(typeof(DateTime)))
											dr[propInfo.Name] = TDateTime.DateTimeToLongDate((DateTime)propInfo.GetValue(fPECndInit, null));
										else
											dr[propInfo.Name] = propInfo.GetValue(fPECndInit, null);
										break;
									}
								}
								
							}
						}
					}

					// ☆☆☆ CSVファイルの保存 ☆☆☆
					// 抽出条件初期値
					fileName = Path.Combine(SFANL08246CA.ctCSVSavePath, TBL_FPECNDINIT + ".csv");
					status = SFANL08246CA.SaveCsv(_ds, TBL_FPECNDINIT, SFANL08246CA.ctXSLFileName, fileName, appendButtonTool.Checked, out errMsg);

					// ☆☆☆ XMLファイルの保存 ☆☆☆
					if (status == 0)
					{
						int freePrtPprItemGrpCd = (int)_ds.Tables[TBL_PRTITEMGRP].Rows[0][COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD];
						fileName = Path.Combine(SFANL08246CA.ctXMLSavePath, TBL_FPECNDINIT + "_" + freePrtPprItemGrpCd + ".xml");
						status = SFANL08246CA.SaveXml(_ds, TBL_FPECNDINIT, string.Empty, fileName, out errMsg);
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
		/// ツールバークリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: ツールバーがクリックされた時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.10.22</br>
		/// </remarks>
		private void utmMainToolbar_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
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
					this.openFileDialog.Filter = "抽出条件初期値XMLファイル|FPECndInit*.xml";
					this.openFileDialog.InitialDirectory = Path.Combine(System.Windows.Forms.Application.StartupPath, SFANL08246CA.ctXMLSavePath);
					if (this.openFileDialog.ShowDialog() == DialogResult.OK)
					{
						DisplayInitialize();

						// 自由帳票抽出条件初期値
						_ds.Tables[TBL_FPECNDINIT].ReadXml(this.openFileDialog.FileName);

						// 印字項目グループ
						this.openFileDialog.Filter = "印字項目グループXMLファイル|PrtItemGrp*.xml";
						this.openFileDialog.InitialDirectory = Path.Combine(System.Windows.Forms.Application.StartupPath, SFANL08246CA.ctXMLSavePath);
						if (this.openFileDialog.ShowDialog() == DialogResult.OK)
						{
							// 印字項目グループ
							_ds.Tables[TBL_PRTITEMGRP].ReadXml(this.openFileDialog.FileName);
							// 印字項目設定
							string fileName = Path.GetFileName(this.openFileDialog.FileName);
							string filePath = Path.Combine(Path.GetDirectoryName(this.openFileDialog.FileName), fileName.Replace(TBL_PRTITEMGRP, TBL_PRTITEMSET));
							if (File.Exists(filePath))
								_ds.Tables[TBL_PRTITEMSET].ReadXml(filePath);
							// 自由帳票抽出条件明細
							filePath = Path.Combine(Path.GetDirectoryName(this.openFileDialog.FileName), TBL_FREPEXCNDD + ".xml");
							if (File.Exists(filePath))
								_ds.Tables[TBL_FREPEXCNDD].ReadXml(filePath);

							List<FPECndInitWork> fPECndInitList = CreateListFromDataSet<FPECndInitWork>(TBL_FPECNDINIT);
							List<int> schmGrpCdList = new List<int>();
							foreach (FPECndInitWork fPECndInitWork in fPECndInitList)
								if (!schmGrpCdList.Contains(fPECndInitWork.FreePrtPprSchmGrpCd))
									schmGrpCdList.Add(fPECndInitWork.FreePrtPprSchmGrpCd);

							List<FrePprECnd2> frePprECndList = new List<FrePprECnd2>();
							foreach (int schmGrpCd in schmGrpCdList)
							{
								List<FrePprECnd2> wkList = CreateFrePprECnd2FromPrtItemSetList(schmGrpCd);
								frePprECndList.AddRange(wkList);
							}
							frePprECndList = MergeFrePprECnd2(frePprECndList, fPECndInitList);
							foreach (FrePprECnd2 frePprECnd in frePprECndList)
								SetFrePprECnd2ToDataTable(frePprECnd, -1);

							UpdateFilterCommboBox();
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
					this.openFileDialog.Filter = "印字項目グループXMLファイル|PrtItemGrp*.xml";
					this.openFileDialog.InitialDirectory = Path.Combine(System.Windows.Forms.Application.StartupPath, SFANL08246CA.ctXMLSavePath);
					if (this.openFileDialog.ShowDialog() == DialogResult.OK)
					{
						DisplayInitialize();

						// 印字項目グループ
						_ds.Tables[TBL_PRTITEMGRP].ReadXml(this.openFileDialog.FileName);
						// 印字項目設定
						string fileName = Path.GetFileName(this.openFileDialog.FileName);
						string filePath = Path.Combine(Path.GetDirectoryName(this.openFileDialog.FileName), fileName.Replace(TBL_PRTITEMGRP, TBL_PRTITEMSET));
						if (File.Exists(filePath))
							_ds.Tables[TBL_PRTITEMSET].ReadXml(filePath);
						// 自由帳票抽出条件明細
						filePath = Path.Combine(Path.GetDirectoryName(this.openFileDialog.FileName), TBL_FREPEXCNDD + ".xml");
						if (File.Exists(filePath))
							_ds.Tables[TBL_FREPEXCNDD].ReadXml(filePath);

						// 印字項目設定→抽出条件設定作成
						List<FrePprECnd2> frePprECndList = CreateFrePprECnd2FromPrtItemSetList(0);
						// 表示順位ASC,必須抽出条件区分DESC,自由帳票抽出条件枝番ASC順でソート
						frePprECndList.Sort(new FrePprECnd2Compare());
						// 表示順位を採番
						int displayOrder = 1;
						foreach (FrePprECnd2 frePprECnd in frePprECndList)
						{
							if (frePprECnd.NecessaryExtraCondCd == 1)
								frePprECnd.DisplayOrder = displayOrder;
							displayOrder++;
						}

						foreach (FrePprECnd2 frePprECnd in frePprECndList)
							SetFrePprECnd2ToDataTable(frePprECnd, -1);

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
				case "Schema_ButtonTool":
				{
					try
					{
						List<int> schmGrpCdList = new List<int>();
						for (int ix = 0 ; ix != this.cmbFreePrtPprSchmGrpCd.Items.Count ; ix++)
							schmGrpCdList.Add((int)this.cmbFreePrtPprSchmGrpCd.Items[ix].DataValue);
						SFANL08250UC copySchmGrpSelectFrom = new SFANL08250UC();
						DialogResult dlgRet = copySchmGrpSelectFrom.ShowDialog(schmGrpCdList);
						switch (dlgRet)
						{
							case DialogResult.OK:
							{
								this.ubFPECndInitAddRow.Focus();

								if (copySchmGrpSelectFrom.SelectedSchmGrpCd < 0)
								{
									// 印字項目設定→抽出条件設定作成
									List<FrePprECnd2> frePprECndList = CreateFrePprECnd2FromPrtItemSetList(copySchmGrpSelectFrom.NewSchmGrpCd);
									// 表示順位ASC,必須抽出条件区分DESC,自由帳票抽出条件枝番ASC順でソート
									frePprECndList.Sort(new FrePprECnd2Compare());
									// 表示順位を採番
									int displayOrder = 1;
									foreach (FrePprECnd2 frePprECnd in frePprECndList)
									{
										if (frePprECnd.NecessaryExtraCondCd == 1)
											frePprECnd.DisplayOrder = displayOrder;
										displayOrder++;
									}

									foreach (FrePprECnd2 frePprECnd in frePprECndList)
										SetFrePprECnd2ToDataTable(frePprECnd, -1);
								}
								else
								{
									DataRow[] drArray
										= _ds.Tables[TBL_FREPPRECND_SETTING].Select(COL_FREEPRTPPRSCHMGRPCD + "=" + copySchmGrpSelectFrom.SelectedSchmGrpCd);
									if (drArray != null && drArray.Length > 0)
									{
										List<FrePprECnd2> frePprECndList = new List<FrePprECnd2>();
										foreach (DataRow dr in drArray)
										{
											FrePprECnd2 frePprECndClone = ((FrePprECnd2)dr[COL_FREPPRECND]).Clone();
											frePprECndClone.FreePrtPprSchmGrpCd = copySchmGrpSelectFrom.NewSchmGrpCd;
											frePprECndList.Add(frePprECndClone);
										}
										foreach (FrePprECnd2 frePprECnd in frePprECndList)
											SetFrePprECnd2ToDataTable(frePprECnd, -1);
									}
								}

								UpdateFilterCommboBox();
								break;
							}
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(
							ex.Message,
							ctMSG_CAPTION,
							MessageBoxButtons.OK,
							MessageBoxIcon.Error,
							MessageBoxDefaultButton.Button1);
					}
					break;
				}
			}
		}

		/// <summary>
		/// フォームロードイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.10.22</br>
		/// </remarks>
		private void SFANL08242UA_Load(object sender, EventArgs e)
		{
			string message = string.Empty;
			try
			{
				// 印字項目グループ
				CreateDataTableSchema(_ds, TBL_PRTITEMGRP, false);
				// 印字項目設定
				CreateDataTableSchema(_ds, TBL_PRTITEMSET, false);
				// 自由帳票抽出条件明細
				CreateDataTableSchema(_ds, TBL_FREPEXCNDD, false);
				// 自由帳票抽出条件初期値
				CreateDataTableSchema(_ds, TBL_FPECNDINIT, false);
				// 自由帳票抽出条件設定情報
				CreateDataTableSchema(_ds, TBL_FREPPRECND_SETTING, true);

				this.gridFPECndInit.DataSource = _ds.Tables[TBL_FREPPRECND_SETTING];

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
		/// <br>Date		: 2007.10.22</br>
		/// </remarks>
		private void gridFPECndInit_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			if (_fPECndInitSchemaInfoList != null)
			{
				foreach (UltraGridColumn col in e.Layout.Bands[0].Columns)
				{
					SchemaInfo schemaInfo = _fPECndInitSchemaInfoList.Find(
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

					switch (col.Key)
					{
						case COL_DISPLAYORDER:	// 表示順位
						{
							col.CellAppearance.TextHAlign = HAlign.Right;
							col.CellActivation = Activation.NoEdit;
							col.SortIndicator = SortIndicator.Ascending;
							break;
						}
						case COL_EXTRACONDITIONTITLE:	// 抽出条件タイトル
						{
							col.CellActivation = Activation.NoEdit;
							break;
						}
						case COL_FREEPRTPPRSCHMGRPCD:	// 自由帳票スキーマグループコード
						case COL_FREPRTPPREXTRACONDCD:	// 自由帳票抽出条件枝番
						case COL_FREPPRECND:	// 自由帳票抽出条件マスタ
						{
							col.Hidden = true;
							break;
						}
					}
				}
			}
		}

		/// <summary>
		/// グリッドAfterRowActivateイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: グリッド上の行がアクティブ化した時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.10.22</br>
		/// </remarks>
		private void gridFPECndInit_AfterRowActivate(object sender, EventArgs e)
		{
			this.gridFPECndInit.ActiveRow.Selected = true;

			this.pnlInitSetting.Controls.Clear();

			int freePrtPprSchmGrpCd = (int)this.cmbFreePrtPprSchmGrpCd.Value;
			int frePrtPprExtraCondCd = (int)this.gridFPECndInit.ActiveRow.Cells[COL_FREPRTPPREXTRACONDCD].Value;

			DataRow[] drArray = _ds.Tables[TBL_FREPPRECND_SETTING].Select(COL_FREEPRTPPRSCHMGRPCD + "=" + freePrtPprSchmGrpCd + " AND " + COL_FREPRTPPREXTRACONDCD + "=" + frePrtPprExtraCondCd);
			if (drArray != null && drArray.Length > 0)
			{
				FrePprECnd2 frePprECnd = drArray[0][COL_FREPPRECND] as FrePprECnd2;
				List<FrePExCndD> frePExCndDList = CreateListFromDataSet<FrePExCndD>(TBL_FREPEXCNDD);

				Control defSettingCtrl = SFANL08132CA.GetExtrSettingControl(frePprECnd, frePExCndDList);
				if (defSettingCtrl != null)
				{
					this.pnlInitSetting.Controls.Add(defSettingCtrl);
					defSettingCtrl.Dock = DockStyle.Top;

					this.cmdExtraConditionTypeCd.Items.Clear();
					switch (frePprECnd.ExtraConditionDivCd)
					{
						case 1:
						{
							this.cmdExtraConditionTypeCd.Items.Add(0, "完全一致");
							this.cmdExtraConditionTypeCd.Items.Add(1, "範囲");
							break;
						}
						case 2:
						case 3:
						{
							this.cmdExtraConditionTypeCd.Items.Add(0, "完全一致");
							this.cmdExtraConditionTypeCd.Items.Add(1, "範囲");
							this.cmdExtraConditionTypeCd.Items.Add(2, "あいまい検索");
							break;
						}
						case 4:
						{
							this.cmdExtraConditionTypeCd.Items.Add(0, "完全一致");
							this.cmdExtraConditionTypeCd.Items.Add(1, "範囲");
							this.cmdExtraConditionTypeCd.Items.Add(3, "期間（開始日基準）");
							this.cmdExtraConditionTypeCd.Items.Add(4, "期間（終了日基準）");
							break;
						}
						case 5:
						case 6:
						{
							this.cmdExtraConditionTypeCd.Items.Add(0, "　");
							break;
						}
					}

					this.tedExtraConditionTitle.Text = frePprECnd.ExtraConditionTitle;
					this.ndtDisplayOder.SetInt(frePprECnd.DisplayOrder);
					this.cmdExtraConditionTypeCd.Value = frePprECnd.ExtraConditionTypeCd;
				}
			}
		}

		/// <summary>
		/// BeforeRowDeactivateイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 行が非アクティブになる前に発生します。</br>
		/// <br>Programer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.10.22</br>
		/// </remarks>
		private void gridFPECndInit_BeforeRowDeactivate(object sender, CancelEventArgs e)
		{
			int freePrtPprSchmGrpCd = (int)this.cmbFreePrtPprSchmGrpCd.Value;
			int frePrtPprExtraCondCd = (int)this.gridFPECndInit.ActiveRow.Cells[COL_FREPRTPPREXTRACONDCD].Value;

			DataRow[] drArray = _ds.Tables[TBL_FREPPRECND_SETTING].Select(COL_FREEPRTPPRSCHMGRPCD + "=" + freePrtPprSchmGrpCd + " AND " + COL_FREPRTPPREXTRACONDCD + "=" + frePrtPprExtraCondCd);
			if (drArray != null && drArray.Length > 0)
			{
				FrePprECnd2 frePprECnd = drArray[0][COL_FREPPRECND] as FrePprECnd2;

				string controlName = SFANL08132CA.GetControlName(frePprECnd);
				if (this.pnlInitSetting.Controls.ContainsKey(controlName))
				{
					IFreePrintUserControl iFreePrintUserControl = this.pnlInitSetting.Controls[controlName] as IFreePrintUserControl;
					FrePprECnd wkFrePprECnd = (FrePprECnd)frePprECnd;
					iFreePrintUserControl.GetFrePprECndInfo(ref wkFrePprECnd);

					SetFrePprECnd2ToDataTable(frePprECnd, _ds.Tables[TBL_FREPPRECND_SETTING].Rows.IndexOf(drArray[0]));

					frePprECnd.ExtraConditionTitle = this.tedExtraConditionTitle.Text;
					frePprECnd.DisplayOrder = this.ndtDisplayOder.GetInt();
					frePprECnd.ExtraConditionTypeCd = (int)this.cmdExtraConditionTypeCd.Value;
				}
			}
		}

		private void ndtDisplayOder_AfterExitEditMode(object sender, EventArgs e)
		{
			if (_buffCode == this.ndtDisplayOder.GetInt()) return;

			int freePrtPprSchmGrpCd = (int)this.cmbFreePrtPprSchmGrpCd.Value;
			int frePrtPprExtraCondCd = (int)this.gridFPECndInit.ActiveRow.Cells[COL_FREPRTPPREXTRACONDCD].Value;

			DataRow[] drArray = _ds.Tables[TBL_FREPPRECND_SETTING].Select(COL_FREEPRTPPRSCHMGRPCD + "=" + freePrtPprSchmGrpCd + " AND " + COL_FREPRTPPREXTRACONDCD + "=" + frePrtPprExtraCondCd);
			if (drArray != null && drArray.Length > 0)
			{
				FrePprECnd2 frePprECnd = drArray[0][COL_FREPPRECND] as FrePprECnd2;
				frePprECnd.DisplayOrder = this.ndtDisplayOder.GetInt();

				SetFrePprECnd2ToDataTable(frePprECnd, _ds.Tables[TBL_FREPPRECND_SETTING].Rows.IndexOf(drArray[0]));

				this.gridFPECndInit.DisplayLayout.Bands[0].Columns[COL_DISPLAYORDER].SortIndicator
					= SortIndicator.Ascending;
			}
		}

		private void cmbFreePrtPprSchmGrpCd_SelectionChanged(object sender, EventArgs e)
		{
			int freePrtPprSchmGrpCd = (int)this.cmbFreePrtPprSchmGrpCd.Value;
			_ds.Tables[TBL_FREPPRECND_SETTING].DefaultView.RowFilter = COL_FREEPRTPPRSCHMGRPCD + "=" + freePrtPprSchmGrpCd;

			if (this.gridFPECndInit.Rows.Count > 0)
				this.gridFPECndInit.Rows[0].Activate();
		}

		private void ubFPECndInitAddRow_Click(object sender, EventArgs e)
		{
			try
			{
				List<int> extraCndCdList = new List<int>();
				foreach (UltraGridRow row in this.gridFPECndInit.Rows)
					extraCndCdList.Add((int)row.Cells[COL_FREPRTPPREXTRACONDCD].Value);

				SFANL08250UB newRowDataSelectForm = new SFANL08250UB();
				DialogResult dlgRet = newRowDataSelectForm.ShowDialog(_ds.Tables[TBL_PRTITEMSET], extraCndCdList);
				switch (dlgRet)
				{
					case DialogResult.OK:
					{
						if (newRowDataSelectForm.SelectedRow != null)
						{
							PrtItemSetWork prtItemSet
								= CreateDataClassFromDataRow<PrtItemSetWork>(newRowDataSelectForm.SelectedRow);
							if (prtItemSet != null)
							{
								FrePprECnd2 frePprECnd = CreateFrePprECnd2FromPrtItemSet(prtItemSet, (int)this.cmbFreePrtPprSchmGrpCd.Value);
								SetFrePprECnd2ToDataTable(frePprECnd, -1);
							}
						}
						break;
					}
					case DialogResult.Abort:
					{
						MessageBox.Show("追加出来る行はありません", ctMSG_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
						break;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					ctMSG_CAPTION,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1);
			}
		}

		private void ubFPECndInitDelRow_Click(object sender, EventArgs e)
		{
			int focusSetIndex = 0;

			if (this.gridFPECndInit.ActiveRow != null)
			{
				// 削除対象となるDataRowを取得
				focusSetIndex = Math.Max(focusSetIndex, this.gridFPECndInit.ActiveRow.Index);

				int freePrtPprSchmGrpCd = (int)this.cmbFreePrtPprSchmGrpCd.Value;
				int frePrtPprExtraCondCd = (int)this.gridFPECndInit.ActiveRow.Cells[COL_FREPRTPPREXTRACONDCD].Value;

				DataRow[] drArray = _ds.Tables[TBL_FREPPRECND_SETTING].Select(COL_FREEPRTPPRSCHMGRPCD + "=" + freePrtPprSchmGrpCd + " AND " + COL_FREPRTPPREXTRACONDCD + "=" + frePrtPprExtraCondCd);
				if (drArray != null && drArray.Length > 0)
				{
					// 選択行を削除
					_ds.Tables[TBL_FREPPRECND_SETTING].Rows.Remove(drArray[0]);
					if (focusSetIndex > 0) focusSetIndex--;

					// 行が残っている場合は1行目をアクティブ化
					if (this.gridFPECndInit.Rows.Count > 0)
						this.gridFPECndInit.Rows[focusSetIndex].Activate();
					else
						UpdateFilterCommboBox();
				}
			}
			else
			{
				MessageBox.Show("削除する行を選択してください", ctMSG_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			}
		}

		private void ndtDisplayOder_Enter(object sender, EventArgs e)
		{
			_buffCode = this.ndtDisplayOder.GetInt();
		}

		private void cmbFreePrtPprSchmGrpCd_Enter(object sender, EventArgs e)
		{
			if (this.gridFPECndInit.ActiveRow != null)
				gridFPECndInit_BeforeRowDeactivate(sender, new CancelEventArgs());
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

	/// <summary>
	/// 
	/// </summary>
	internal class FrePprECnd2 : FrePprECnd
	{
		#region PrivateMember
		/// <summary>自由帳票スキーマグループコード</summary>
		private Int32 _freePrtPprSchmGrpCd;
		#endregion

		#region Property
		/// public propaty name  :  FreePrtPprSchmGrpCd
		/// <summary>自由帳票スキーマグループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自由帳票スキーマグループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FreePrtPprSchmGrpCd
		{
			get { return _freePrtPprSchmGrpCd; }
			set { _freePrtPprSchmGrpCd = value; }
		}
		#endregion

		#region Constructor
		/// <summary>
		/// 自由帳票抽出条件設定マスタコンストラクタ
		/// </summary>
		/// <returns>FrePprECndクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePprECndクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public FrePprECnd2()
			: base()
		{
		}

		/// <summary>
		/// 自由帳票抽出条件設定マスタコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="outputFormFileName">出力ファイル名(フォームファイルID or フォーマットファイルID)</param>
		/// <param name="userPrtPprIdDerivNo">ユーザー帳票ID枝番号</param>
		/// <param name="frePrtPprExtraCondCd">自由帳票抽出条件枝番</param>
		/// <param name="displayOrder">表示順位</param>
		/// <param name="extraConditionDivCd">抽出条件区分(0:使用不可,1:数値型,2:文字型（半角）,3:文字型（全角）,4:日付型,5:コンボ型,6:チェック型)</param>
		/// <param name="extraConditionTypeCd">抽出条件タイプ(0:一致,1:範囲,2:あいまい,3:期間)</param>
		/// <param name="extraConditionTitle">抽出条件タイトル</param>
		/// <param name="dDCharCnt">DD桁数</param>
		/// <param name="dDName">DD名称(小文字で登録)</param>
		/// <param name="stExtraNumCode">抽出開始コード（数値）</param>
		/// <param name="edExtraNumCode">抽出終了コード（数値）</param>
		/// <param name="stExtraCharCode">抽出開始コード（文字）</param>
		/// <param name="edExtraCharCode">抽出終了コード（文字）</param>
		/// <param name="stExtraDateBaseCd">抽出開始日付（基準）(0:前々日,1:前日,2:本日,3:翌日,4:翌々日,5:日付指定)</param>
		/// <param name="stExtraDateSignCd">抽出開始日付（正負）(0:＋（プラス）,1:－（マイナス）)</param>
		/// <param name="stExtraDateNum">抽出開始日付（数値）</param>
		/// <param name="stExtraDateUnitCd">抽出開始日付（単位）(0:日,1:週,2:月,3:年)</param>
		/// <param name="startExtraDate">抽出開始日付（日付）</param>
		/// <param name="edExtraDateBaseCd">抽出終了日付（基準）(0:前々日,1:前日,2:本日,3:翌日,4:翌々日,5:日付指定)</param>
		/// <param name="edExtraDateSignCd">抽出終了日付（正負）(0:＋（プラス）,1:－（マイナス）)</param>
		/// <param name="edExtraDateNum">抽出終了日付（数値）</param>
		/// <param name="edExtraDateUnitCd">抽出終了日付（単位）(0:日,1:週,2:月,3:年)</param>
		/// <param name="endExtraDate">抽出終了日付（日付）</param>
		/// <param name="extraCondDetailGrpCd">抽出条件明細グループコード(抽出条件区分がコンボボックス型の時に使用)</param>
		/// <param name="necessaryExtraCondCd">必須抽出条件区分(0:任意,1:必須)</param>
		/// <param name="checkItemCode1">チェック項目コード1</param>
		/// <param name="checkItemCode2">チェック項目コード2</param>
		/// <param name="checkItemCode3">チェック項目コード3</param>
		/// <param name="checkItemCode4">チェック項目コード4</param>
		/// <param name="checkItemCode5">チェック項目コード5</param>
		/// <param name="checkItemCode6">チェック項目コード6</param>
		/// <param name="checkItemCode7">チェック項目コード7</param>
		/// <param name="checkItemCode8">チェック項目コード8</param>
		/// <param name="checkItemCode9">チェック項目コード9</param>
		/// <param name="checkItemCode10">チェック項目コード10</param>
		/// <param name="fileNm">ファイル名称(DBのテーブルID)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <param name="freePrtPprSchmGrpCd"></param>
		/// <returns>FrePprECndクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePprECndクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public FrePprECnd2(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string outputFormFileName, Int32 userPrtPprIdDerivNo, Int32 frePrtPprExtraCondCd, Int32 displayOrder, Int32 extraConditionDivCd, Int32 extraConditionTypeCd, string extraConditionTitle, Int32 dDCharCnt, string dDName, Int64 stExtraNumCode, Int64 edExtraNumCode, string stExtraCharCode, string edExtraCharCode, Int32 stExtraDateBaseCd, Int32 stExtraDateSignCd, Int32 stExtraDateNum, Int32 stExtraDateUnitCd, Int32 startExtraDate, Int32 edExtraDateBaseCd, Int32 edExtraDateSignCd, Int32 edExtraDateNum, Int32 edExtraDateUnitCd, Int32 endExtraDate, Int32 extraCondDetailGrpCd, Int32 necessaryExtraCondCd, Int32 checkItemCode1, Int32 checkItemCode2, Int32 checkItemCode3, Int32 checkItemCode4, Int32 checkItemCode5, Int32 checkItemCode6, Int32 checkItemCode7, Int32 checkItemCode8, Int32 checkItemCode9, Int32 checkItemCode10, string fileNm, string enterpriseName, string updEmployeeName, int freePrtPprSchmGrpCd)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this.EnterpriseCode = enterpriseCode;
			this.FileHeaderGuid = fileHeaderGuid;
			this.UpdEmployeeCode = updEmployeeCode;
			this.UpdAssemblyId1 = updAssemblyId1;
			this.UpdAssemblyId2 = updAssemblyId2;
			this.LogicalDeleteCode = logicalDeleteCode;
			this.OutputFormFileName = outputFormFileName;
			this.UserPrtPprIdDerivNo = userPrtPprIdDerivNo;
			this.FrePrtPprExtraCondCd = frePrtPprExtraCondCd;
			this.DisplayOrder = displayOrder;
			this.ExtraConditionDivCd = extraConditionDivCd;
			this.ExtraConditionTypeCd = extraConditionTypeCd;
			this.ExtraConditionTitle = extraConditionTitle;
			this.DDCharCnt = dDCharCnt;
			this.DDName = dDName;
			this.StExtraNumCode = stExtraNumCode;
			this.EdExtraNumCode = edExtraNumCode;
			this.StExtraCharCode = stExtraCharCode;
			this.EdExtraCharCode = edExtraCharCode;
			this.StExtraDateBaseCd = stExtraDateBaseCd;
			this.StExtraDateSignCd = stExtraDateSignCd;
			this.StExtraDateNum = stExtraDateNum;
			this.StExtraDateUnitCd = stExtraDateUnitCd;
			this.StartExtraDate = startExtraDate;
			this.EdExtraDateBaseCd = edExtraDateBaseCd;
			this.EdExtraDateSignCd = edExtraDateSignCd;
			this.EdExtraDateNum = edExtraDateNum;
			this.EdExtraDateUnitCd = edExtraDateUnitCd;
			this.EndExtraDate = endExtraDate;
			this.ExtraCondDetailGrpCd = extraCondDetailGrpCd;
			this.NecessaryExtraCondCd = necessaryExtraCondCd;
			this.CheckItemCode1 = checkItemCode1;
			this.CheckItemCode2 = checkItemCode2;
			this.CheckItemCode3 = checkItemCode3;
			this.CheckItemCode4 = checkItemCode4;
			this.CheckItemCode5 = checkItemCode5;
			this.CheckItemCode6 = checkItemCode6;
			this.CheckItemCode7 = checkItemCode7;
			this.CheckItemCode8 = checkItemCode8;
			this.CheckItemCode9 = checkItemCode9;
			this.CheckItemCode10 = checkItemCode10;
			this.FileNm = fileNm;
			this.EnterpriseName = enterpriseName;
			this.UpdEmployeeName = updEmployeeName;
			this._freePrtPprSchmGrpCd = freePrtPprSchmGrpCd;

		}
		#endregion

		#region PublicMethod
		/// <summary>
		/// 自由帳票抽出条件設定マスタ複製処理
		/// </summary>
		/// <returns>FrePprECndクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいFrePprECndクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public new FrePprECnd2 Clone()
		{
			return new FrePprECnd2(this.CreateDateTime, this.UpdateDateTime, this.EnterpriseCode, this.FileHeaderGuid, this.UpdEmployeeCode, this.UpdAssemblyId1, this.UpdAssemblyId2, this.LogicalDeleteCode, this.OutputFormFileName, this.UserPrtPprIdDerivNo, this.FrePrtPprExtraCondCd, this.DisplayOrder, this.ExtraConditionDivCd, this.ExtraConditionTypeCd, this.ExtraConditionTitle, this.DDCharCnt, this.DDName, this.StExtraNumCode, this.EdExtraNumCode, this.StExtraCharCode, this.EdExtraCharCode, this.StExtraDateBaseCd, this.StExtraDateSignCd, this.StExtraDateNum, this.StExtraDateUnitCd, this.StartExtraDate, this.EdExtraDateBaseCd, this.EdExtraDateSignCd, this.EdExtraDateNum, this.EdExtraDateUnitCd, this.EndExtraDate, this.ExtraCondDetailGrpCd, this.NecessaryExtraCondCd, this.CheckItemCode1, this.CheckItemCode2, this.CheckItemCode3, this.CheckItemCode4, this.CheckItemCode5, this.CheckItemCode6, this.CheckItemCode7, this.CheckItemCode8, this.CheckItemCode9, this.CheckItemCode10, this.FileNm, this.EnterpriseName, this.UpdEmployeeName, this._freePrtPprSchmGrpCd);
		}
		#endregion
	}

	/// <summary>
	/// 印字項目設定比較クラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 印字項目設定をソートする際に使用するCompareクラスです。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.05.10</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal class FrePprECnd2Compare : IComparer<FrePprECnd2>
	{
		#region PublicMethod
		/// <summary>
		/// 比較処理
		/// </summary>
		/// <param name="x">比較対象1</param>
		/// <param name="y">比較対象2</param>
		/// <returns>比較結果</returns>
		public int Compare(FrePprECnd2 x, FrePprECnd2 y)
		{
			int retCompare = 0;
			retCompare = x.DisplayOrder - y.DisplayOrder;
			if (retCompare == 0)
			{
				retCompare = y.NecessaryExtraCondCd - x.NecessaryExtraCondCd;
				if (retCompare == 0)
				{
					retCompare = x.FrePrtPprExtraCondCd - y.FrePrtPprExtraCondCd;
				}
			}
			return retCompare;
		}
		#endregion
	}
}