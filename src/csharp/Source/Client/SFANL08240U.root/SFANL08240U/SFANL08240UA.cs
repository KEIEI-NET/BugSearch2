using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;

using Broadleaf.Tools;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 自由帳票印字項目設定UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 自由帳票印字項目設定UIクラスです。</br>
    /// <br>Programmer	: 22024 寺坂　誉志</br>
    /// <br>Date		: 2007.07.03</br>
    /// <br></br>
    /// <br>Update Note	: 2008.06.04  22018  鈴木 正臣</br>
    /// <br>             : 　①PM.NS向け変更</br>
    /// <br>             :   ②明細複写機能を追加</br>
    /// <br></br>
    /// <br>Update Note	: 2009.04.21  22018  鈴木 正臣</br>
    /// <br>             : 　①ソート順設定機能を追加</br>
    /// <br></br>
    /// </remarks>
    public partial class SFANL08240UA : Form
    {
        #region Const
        // MessageBoxヘッダーキャプション
        private const string ctMSG_CAPTION = "自由帳票印字項目設定";

        // Excelファイル名称
        private const string ctPrtItemGrpLayoutNm = "FNo0000印字項目グループマスタ.xls";
        private const string ctPrtItemSetLayoutNm = "FNo0000印字項目設定マスタ.xls";
        private const string ctFrePExCndDLayoutNm = "FNo0000自由帳票抽出条件明細マスタ.xls";

        // テーブル名称
        private const string TBL_PRTITEMGRP = "PrtItemGrpRF";
        private const string TBL_PRTITEMSET = "PrtItemSetRF";
        private const string TBL_FREPEXCNDD = "FrePExCndDRF";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/21 ADD
        private const string TBL_FPSORTINIT = "FPSortInitRF";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/21 ADD

        // 共通ファイルヘッダー
        private const string COL_COMMON_CREATEDATETIME = "CreateDateTime";		// 作成日時
        private const string COL_COMMON_UPDATEDATETIME = "UpdateDateTime";		// 更新日時
        private const string COL_COMMON_ENTERPRISECODE = "EnterpriseCode";		// 企業コード
        private const string COL_COMMON_FILEHEADERGUID = "FileHeaderGuid";		// GUID
        private const string COL_COMMON_UPDEMPLOYEECODE = "UpdEmployeeCode";	// 更新従業員コード
        private const string COL_COMMON_UPDASSEMBLYID1 = "UpdAssemblyId1";		// 更新アセンブリID1
        private const string COL_COMMON_UPDASSEMBLYID2 = "UpdAssemblyId2";		// 更新アセンブリID2
        private const string COL_COMMON_LOGICALDELETECODE = "LogicalDeleteCode";	// 論理削除区分
        // 印字項目グループ
        private const string COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD = "FreePrtPprItemGrpCd";	// 自由帳票項目グループコード
        private const string COL_PRTITEMGRP_FREEPRTPPRITEMGRPNM = "FreePrtPprItemGrpNm";	// 自由帳票項目グループ名称
        private const string COL_PRTITEMGRP_PRINTPAPERUSEDIVCD = "PrintPaperUseDivcd";		// 帳票使用区分
        private const string COL_PRTITEMGRP_EXTRACTIONPGID = "ExtractionPgId";			// 抽出プログラムID
        private const string COL_PRTITEMGRP_EXTRACTIONPGCLASSID = "ExtractionPgClassId";	// 抽出プログラムクラスID
        private const string COL_PRTITEMGRP_OUTPUTPGID = "OutputPgId";				// 出力プログラムID
        private const string COL_PRTITEMGRP_OUTPUTPGCLASSID = "OutputPgClassId";		// 出力プログラムクラスID
        private const string COL_PRTITEMGRP_DATAINPUTSYSTEM = "DataInputSystem";		// データ入力システム
        private const string COL_PRTITEMGRP_LINKSLIPDATAINPUTSYS = "LinkSlipDataInputSys";	// リンク伝票データ入力システム
        private const string COL_PRTITEMGRP_LINKSLIPPRTKIND = "LinkSlipPrtKind";		// リンク伝票印刷種別
        private const string COL_PRTITEMGRP_LINKSLIPPRTSETPPRID = "LinkSlipPrtSetPprId";	// リンク伝票印刷設定用帳票ID
        private const string COL_PRTITEMGRP_EXTRASECTIONKINDCD = "ExtraSectionKindCd";		// 抽出拠点種別区分
        private const string COL_PRTITEMGRP_EXTRASECTIONSELEXIST = "ExtraSectionSelExist";	// 抽出拠点選択有無
        private const string COL_PRTITEMGRP_FORMFEEDLINECOUNT = "FormFeedLineCount";		// 改頁行数
        private const string COL_PRTITEMGRP_CRCHARCNT = "CrCharCnt";				// 改行文字数
        private const string COL_PRTITEMGRP_FREEPRTPPRSPPRPSECD = "FreePrtPprSpPrpseCd";	// 自由帳票 特種用途区分
        // 印字項目設定
        private const string COL_PRTITEMSET_FREEPRTPPRITEMGRPCD = "FreePrtPprItemGrpCd";	// 自由帳票項目グループコード
        private const string COL_PRTITEMSET_FREEPRTPAPERITEMCD = "FreePrtPaperItemCd";		// 自由帳票項目コード
        private const string COL_PRTITEMSET_FREEPRTPAPERITEMNM = "FreePrtPaperItemNm";		// 自由帳票項目名称
        private const string COL_PRTITEMSET_FILENM = "FileNm";					// ファイル名称
        private const string COL_PRTITEMSET_DDCHARCNT = "DDCharCnt";				// DD桁数
        private const string COL_PRTITEMSET_DDNAME = "DDName";					// DD名称
        private const string COL_PRTITEMSET_REPORTCONTROLCODE = "ReportControlCode";		// レポートコントロール区分
        private const string COL_PRTITEMSET_HEADERUSEDIVCD = "HeaderUseDivCd";			// ヘッダー使用区分
        private const string COL_PRTITEMSET_DETAILUSEDIVCD = "DetailUseDivCd";			// 明細使用区分
        private const string COL_PRTITEMSET_FOOTERUSEDIVCD = "FooterUseDivCd";			// フッター使用区分
        private const string COL_PRTITEMSET_EXTRACONDITIONDIVCD = "ExtraConditionDivCd";	// 抽出条件区分
        private const string COL_PRTITEMSET_EXTRACONDITIONTYPECD = "ExtraConditionTypeCd";	// 抽出条件タイプ
        private const string COL_PRTITEMSET_COMMAEDITEXISTCD = "CommaEditExistCd";		// カンマ編集有無
        private const string COL_PRTITEMSET_PRINTPAGECTRLDIVCD = "PrintPageCtrlDivCd";		// 印字ページ制御区分
        private const string COL_PRTITEMSET_SYSTEMDIVCD = "SystemDivCd";			// システム区分
        private const string COL_PRTITEMSET_OPTIONCODE = "OptionCode";				// オプションコード
        private const string COL_PRTITEMSET_EXTRACONDDETAILGRPCD = "ExtraCondDetailGrpCd";	// 抽出条件明細グループコード
        private const string COL_PRTITEMSET_TOTALITEMDIVCD = "TotalItemDivCd";			// 集計項目区分
        private const string COL_PRTITEMSET_FORMFEEDITEMDIVCD = "FormFeedItemDivCd";		// 改頁項目区分
        private const string COL_PRTITEMSET_FREEPRTPPRDISPGRPCD = "FreePrtPprDispGrpCd";	// 自由帳票表示グループコード
        private const string COL_PRTITEMSET_NECESSARYEXTRACONDCD = "NecessaryExtraCondCd";	// 必須抽出条件区分
        private const string COL_PRTITEMSET_CIPHERFLG = "CipherFlg";				// 暗号化フラグ
        private const string COL_PRTITEMSET_EXTRACTIONITDEDFLG = "ExtractionItdedFlg";		// 抽出対象フラグ
        private const string COL_PRTITEMSET_GROUPSUPPRESSCD = "GroupSuppressCd";		// グループサプレス区分
        private const string COL_PRTITEMSET_DTLCOLORCHANGECD = "DtlColorChangeCd";		// 明細色変更区分
        private const string COL_PRTITEMSET_HEIGHTADJUSTDIVCD = "HeightAdjustDivCd";		// 高さ調整区分
        private const string COL_PRTITEMSET_ADDITEMUSEDIVCD = "AddItemUseDivCd";		// 追加項目使用区分
        private const string COL_PRTITEMSET_INPUTCHARCNT = "InputCharCnt";			// 入力桁数
        private const string COL_PRTITEMSET_BARCODESTYLE = "BarCodeStyle";			// バーコードスタイル
        // 自由帳票抽出条件明細
        private const string COL_FREPEXCNDD_EXTRACONDDETAILGRPCD = "ExtraCondDetailGrpCd";	// 抽出条件明細グループコード
        private const string COL_FREPEXCNDD_EXTRACONDDETAILCODE = "ExtraCondDetailCode";	// 抽出条件明細コード
        private const string COL_FREPEXCNDD_EXTRACONDDETAILNAME = "ExtraCondDetailName";	// 抽出条件明細名称
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/21 ADD
        // 自由帳票ソート順位初期値
        //private const string COL_FPSORTINIT_CREATEDATETIME = "CreateDateTime"; // 作成日時
        //private const string COL_FPSORTINIT_UPDATEDATETIME = "UpdateDateTime"; // 更新日時
        //private const string COL_FPSORTINIT_LOGICALDELETECODE = "LogicalDeleteCode"; // 論理削除区分
        private const string COL_FPSORTINIT_FREEPRTPPRITEMGRPCD = "FreePrtPprItemGrpCd"; // 自由帳票項目グループコード
        private const string COL_FPSORTINIT_FREEPRTPPRSCHMGRPCD = "FreePrtPprSchmGrpCd"; // 自由帳票スキーマグループコード
        private const string COL_FPSORTINIT_SORTINGORDERCODE = "SortingOrderCode"; // ソート順位コード
        private const string COL_FPSORTINIT_SORTINGORDER = "SortingOrder"; // ソート順位
        private const string COL_FPSORTINIT_FREEPRTPAPERITEMNM = "FreePrtPaperItemNm"; // 自由帳票項目名称
        private const string COL_FPSORTINIT_DDNAME = "DDName"; // DD名称
        private const string COL_FPSORTINIT_FILENM = "FileNm"; // ファイル名称
        private const string COL_FPSORTINIT_SORTINGORDERDIVCD = "SortingOrderDivCd"; // 昇順降順区分
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/21 ADD
        #endregion

        #region PrivateMember
        // ファイル仕様書アクセスコントロール
        private FileLayoutControl _layoutCtrl;
        // データ保持用DataSet
        private DataSet _ds;
        // ファイルレイアウト情報保持用
        private List<SchemaInfo> _prtItemGrpSchemaInfoList;
        private List<SchemaInfo> _prtItemSetSchemaInfoList;
        private List<SchemaInfo> _frePExCndDSchemaInfoList;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/21 ADD
        private List<SchemaInfo> _fPSortInitSchemaInfoList;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/21 ADD
        // 変更前の自由帳票項目グループコード
        private int _prevFreePrtPprItemGrpCd;
        // 変更チェックフラグ
        private bool _isChanged;
        // 抽出条件明細ロードフラグ
        private bool _isLoadFrePExCndD;
        #endregion

        #region Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SFANL08240UA()
        {
            InitializeComponent();

            _layoutCtrl = new FileLayoutControl();

            _ds = new DataSet();
        }
        #endregion

        #region PrivateMethod
        /// <summary>
        /// スキーマ情報LIST取得処理
        /// </summary>
        /// <param name="tableName">テーブル名称</param>
        /// <returns>スキーマ情報LIST</returns>
        private List<SchemaInfo> GetSchemaInfoList( string tableName )
        {
            List<SchemaInfo> schemaInfoList = new List<SchemaInfo>();

            switch ( tableName )
            {
                case TBL_PRTITEMGRP:
                    {
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_CREATEDATETIME, "作成日時", typeof( long ), 19 ) );	// 作成日時
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_UPDATEDATETIME, "更新日時", typeof( long ), 19 ) );	// 更新日時
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_LOGICALDELETECODE, "論理削除区分", typeof( int ), 2 ) );	// 論理削除区分
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD, "自由帳票項目グループコード", typeof( int ), 4 ) );	// 自由帳票項目グループコード
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_FREEPRTPPRITEMGRPNM, "自由帳票項目グループ名称", typeof( string ), 20 ) );	// 自由帳票項目グループ名称
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_PRINTPAPERUSEDIVCD, "帳票使用区分", typeof( int ), 2 ) );	// 帳票使用区分
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_EXTRACTIONPGID, "抽出プログラムID", typeof( string ), 16 ) );	// 抽出プログラムID
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_EXTRACTIONPGCLASSID, "抽出プログラムクラスID", typeof( string ), 80 ) );	// 抽出プログラムクラスID
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_OUTPUTPGID, "出力プログラムID", typeof( string ), 16 ) );	// 出力プログラムID
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_OUTPUTPGCLASSID, "出力プログラムクラスID", typeof( string ), 80 ) );	// 出力プログラムクラスID
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_DATAINPUTSYSTEM, "データ入力システム", typeof( int ), 2 ) );	// データ入力システム
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_LINKSLIPDATAINPUTSYS, "リンク伝票データ入力システム", typeof( int ), 2 ) );	// リンク伝票データ入力システム
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_LINKSLIPPRTKIND, "リンク伝票印刷種別", typeof( int ), 4 ) );	// リンク伝票印刷種別
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_LINKSLIPPRTSETPPRID, "リンク伝票印刷設定用帳票ID", typeof( string ), 24 ) );	// リンク伝票印刷設定用帳票ID
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_EXTRASECTIONKINDCD, "抽出拠点種別区分", typeof( int ), 2 ) );	// 抽出拠点種別区分
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_EXTRASECTIONSELEXIST, "抽出拠点選択有無", typeof( int ), 2 ) );	// 抽出拠点選択有無
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_FORMFEEDLINECOUNT, "改頁行数", typeof( int ), 4 ) );	// 改頁行数
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_CRCHARCNT, "改行文字数", typeof( int ), 4 ) );	// 改行文字数
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_FREEPRTPPRSPPRPSECD, "特種用途区分", typeof( int ), 2 ) );	// 自由帳票 特種用途区分
                        break;
                    }
                case TBL_PRTITEMSET:
                    {
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_CREATEDATETIME, "作成日時", typeof( long ), 19 ) );	// 作成日時
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_UPDATEDATETIME, "更新日時", typeof( long ), 19 ) );	// 更新日時
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_LOGICALDELETECODE, "論理削除区分", typeof( int ), 2 ) );	// 論理削除区分
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_FREEPRTPPRITEMGRPCD, "自由帳票項目グループコード", typeof( int ), 4 ) );	// 自由帳票項目グループコード
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_FREEPRTPAPERITEMCD, "自由帳票項目コード", typeof( int ), 4 ) );	// 自由帳票項目コード
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_FREEPRTPAPERITEMNM, "自由帳票項目名称", typeof( string ), 30 ) );	// 自由帳票項目名称
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_FILENM, "ファイル名称", typeof( string ), 32 ) );	// ファイル名称
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_DDCHARCNT, "DD桁数", typeof( int ), 2 ) );	// DD桁数
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_DDNAME, "DD名称", typeof( string ), 30 ) );	// DD名称
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_REPORTCONTROLCODE, "レポートコントロール区分", typeof( int ), 2 ) );	// レポートコントロール区分
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_HEADERUSEDIVCD, "ヘッダー使用区分", typeof( int ), 2 ) );	// ヘッダー使用区分
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_DETAILUSEDIVCD, "明細使用区分", typeof( int ), 2 ) );	// 明細使用区分
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_FOOTERUSEDIVCD, "フッター使用区分", typeof( int ), 2 ) );	// フッター使用区分
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_EXTRACONDITIONDIVCD, "抽出条件区分", typeof( int ), 2 ) );	// 抽出条件区分
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_EXTRACONDITIONTYPECD, "抽出条件タイプ", typeof( int ), 2 ) );	// 抽出条件タイプ
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_COMMAEDITEXISTCD, "カンマ編集有無", typeof( int ), 2 ) );	// カンマ編集有無
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_PRINTPAGECTRLDIVCD, "印字ページ制御区分", typeof( int ), 2 ) );	// 印字ページ制御区分
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_SYSTEMDIVCD, "システム区分", typeof( int ), 2 ) );	// システム区分
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_OPTIONCODE, "オプションコード", typeof( string ), 16 ) );	// オプションコード
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_EXTRACONDDETAILGRPCD, "抽出条件明細グループコード", typeof( int ), 4 ) );	// 抽出条件明細グループコード
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_TOTALITEMDIVCD, "集計項目区分", typeof( int ), 2 ) );	// 集計項目区分
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_FORMFEEDITEMDIVCD, "改頁項目区分", typeof( int ), 2 ) );	// 改頁項目区分
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_FREEPRTPPRDISPGRPCD, "自由帳票表示グループコード", typeof( int ), 4 ) );	// 自由帳票表示グループコード
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_NECESSARYEXTRACONDCD, "必須抽出条件区分", typeof( int ), 2 ) );	// 必須抽出条件区分
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_CIPHERFLG, "暗号化フラグ", typeof( int ), 2 ) );	// 暗号化フラグ
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_EXTRACTIONITDEDFLG, "抽出対象フラグ", typeof( int ), 2 ) );	// 抽出対象フラグ
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_GROUPSUPPRESSCD, "グループサプレス区分", typeof( int ), 2 ) );	// グループサプレス区分
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_DTLCOLORCHANGECD, "明細色変更区分", typeof( int ), 2 ) );	// 明細色変更区分
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_HEIGHTADJUSTDIVCD, "高さ調整区分", typeof( int ), 2 ) );	// 高さ調整区分
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_ADDITEMUSEDIVCD, "追加項目使用区分", typeof( int ), 2 ) );	// 追加項目使用区分
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_INPUTCHARCNT, "入力桁数", typeof( int ), 4 ) );	// 入力桁数
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_BARCODESTYLE, "バーコードスタイル", typeof( int ), 2 ) );	// バーコードスタイル
                        break;
                    }
                case TBL_FREPEXCNDD:
                    {
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_CREATEDATETIME, "作成日時", typeof( long ), 19 ) );	// 作成日時
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_UPDATEDATETIME, "更新日時", typeof( long ), 19 ) );	// 更新日時
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_ENTERPRISECODE, "企業コード", typeof( string ), 16 ) );	// 企業コード
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_FILEHEADERGUID, "GUID", typeof( Guid ), 32 ) );	// GUID
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_UPDEMPLOYEECODE, "更新従業員コード", typeof( string ), 9 ) );	// 更新従業員コード
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_UPDASSEMBLYID1, "更新アセンブリID1", typeof( string ), 30 ) );	// 更新アセンブリID1
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_UPDASSEMBLYID2, "更新アセンブリID2", typeof( string ), 30 ) );	// 更新アセンブリID2
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_LOGICALDELETECODE, "論理削除区分", typeof( int ), 2 ) );	// 論理削除区分
                        schemaInfoList.Add( new SchemaInfo( COL_FREPEXCNDD_EXTRACONDDETAILGRPCD, "抽出条件明細グループコード", typeof( int ), 4 ) );	// 抽出条件明細グループコード
                        schemaInfoList.Add( new SchemaInfo( COL_FREPEXCNDD_EXTRACONDDETAILCODE, "抽出条件明細コード", typeof( int ), 4 ) );	// 抽出条件明細コード
                        schemaInfoList.Add( new SchemaInfo( COL_FREPEXCNDD_EXTRACONDDETAILNAME, "抽出条件明細名称", typeof( string ), 20 ) );	// 抽出条件明細名称
                        break;
                    }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/21 ADD
                case TBL_FPSORTINIT:
                    {
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_CREATEDATETIME, "作成日時", typeof( long ), 19 ) );	// 作成日時
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_UPDATEDATETIME, "更新日時", typeof( long ), 19 ) );	// 更新日時
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_LOGICALDELETECODE, "論理削除区分", typeof( int ), 2 ) );	// 論理削除区分
                        schemaInfoList.Add( new SchemaInfo( COL_FPSORTINIT_FREEPRTPPRITEMGRPCD, "自由帳票項目グループコード", typeof( int ), 4 ) ); // 自由帳票項目グループコード
                        schemaInfoList.Add( new SchemaInfo( COL_FPSORTINIT_FREEPRTPPRSCHMGRPCD, "自由帳票スキーマグループコード", typeof( int ), 4 ) ); // 自由帳票スキーマグループコード
                        schemaInfoList.Add( new SchemaInfo( COL_FPSORTINIT_SORTINGORDERCODE, "ソート順位コード", typeof( int ), 2 ) ); // ソート順位コード
                        schemaInfoList.Add( new SchemaInfo( COL_FPSORTINIT_SORTINGORDER, "ソート順位", typeof( int ), 2 ) ); // ソート順位
                        schemaInfoList.Add( new SchemaInfo( COL_FPSORTINIT_FREEPRTPAPERITEMNM, "自由帳票項目名称", typeof( string ), 30 ) ); // 自由帳票項目名称
                        schemaInfoList.Add( new SchemaInfo( COL_FPSORTINIT_DDNAME, "DD名称", typeof( string ), 30 ) ); // DD名称
                        schemaInfoList.Add( new SchemaInfo( COL_FPSORTINIT_FILENM, "ファイル名称", typeof( string ), 32 ) ); // ファイル名称
                        schemaInfoList.Add( new SchemaInfo( COL_FPSORTINIT_SORTINGORDERDIVCD, "昇順降順区分", typeof( int ), 2 ) ); // 昇順降順区分
                        break;
                    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/21 ADD
            }

            return schemaInfoList;
        }

        /// <summary>
        /// DataTableスキーマ作成処理
        /// </summary>
        /// <param name="ds">DataTable格納先DataSet</param>
        /// <param name="tableName">DataTable名称</param>
        private void CreateDataTableSchema( DataSet ds, string tableName )
        {
            List<SchemaInfo> schemaInfoList = GetSchemaInfoList( tableName );

            if ( schemaInfoList != null )
            {
                switch ( tableName )
                {
                    case TBL_PRTITEMGRP: _prtItemGrpSchemaInfoList = schemaInfoList; break;
                    case TBL_PRTITEMSET: _prtItemSetSchemaInfoList = schemaInfoList; break;
                    case TBL_FREPEXCNDD: _frePExCndDSchemaInfoList = schemaInfoList; break;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/21 ADD
                    case TBL_FPSORTINIT: _fPSortInitSchemaInfoList = schemaInfoList; break;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/21 ADD
                }

                ds.Tables.Add( new DataTable( tableName ) );

                foreach ( SchemaInfo schemaInfo in schemaInfoList )
                {
                    // 型を動的に指定
                    if ( schemaInfo.Type != null )
                        ds.Tables[tableName].Columns.Add( schemaInfo.Name, schemaInfo.Type );
                    else
                        ds.Tables[tableName].Columns.Add( schemaInfo.Name );

                    // 文字列型の場合は空文字を初期値にする
                    if ( ds.Tables[tableName].Columns[schemaInfo.Name].DataType.Equals( typeof( string ) ) )
                    {
                        ds.Tables[tableName].Columns[schemaInfo.Name].DefaultValue = string.Empty;
                    }
                    // GUID型の場合は新しいGUID値を初期値にする
                    else if ( ds.Tables[tableName].Columns[schemaInfo.Name].DataType.Equals( typeof( Guid ) ) )
                    {
                        ds.Tables[tableName].Columns[schemaInfo.Name].DefaultValue = Guid.NewGuid();
                    }
                    // 数値型の場合は0を初期値(Booleanの場合はfalse)にする
                    else if ( ds.Tables[tableName].Columns[schemaInfo.Name].DataType.IsPrimitive )
                    {
                        if ( ds.Tables[tableName].Columns[schemaInfo.Name].DataType.Equals( typeof( bool ) ) )
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
        /// レイアウト情報展開処理
        /// </summary>
        /// <param name="filePath">レイアウトファイルパス</param>
        /// <param name="freePrtPprItemGrpCd">自由帳票項目グループコード</param>
        private void DeployLayoutInfo( string filePath, int freePrtPprItemGrpCd )
        {
            string msg;
            FileLayout layout = _layoutCtrl.ImportFileLayout( filePath, out msg );

            if ( string.IsNullOrEmpty( msg ) )
            {
                // 最大を取得
                int freePrtPaperItemCd = GetMaxFreePrtPaperItemCd( freePrtPprItemGrpCd );
                foreach ( LayoutField field in layout.FieldList )
                {
                    switch ( field.Name )
                    {
                        case COL_COMMON_CREATEDATETIME:
                        case COL_COMMON_UPDATEDATETIME:
                        case COL_COMMON_ENTERPRISECODE:
                        case COL_COMMON_FILEHEADERGUID:
                        case COL_COMMON_UPDEMPLOYEECODE:
                        case COL_COMMON_UPDASSEMBLYID1:
                        case COL_COMMON_UPDASSEMBLYID2:
                        case COL_COMMON_LOGICALDELETECODE:
                            {
                                // 共通ヘッダ部は展開しない
                                break;
                            }
                        default:
                            {
                                DataRow dr = _ds.Tables[TBL_PRTITEMSET].NewRow();

                                dr[COL_COMMON_CREATEDATETIME] = GetPrtItemGrpCreateDateTime();
                                dr[COL_COMMON_UPDATEDATETIME] = dr[COL_COMMON_CREATEDATETIME];
                                dr[COL_COMMON_LOGICALDELETECODE] = 0;
                                dr[COL_PRTITEMSET_FREEPRTPPRITEMGRPCD] = freePrtPprItemGrpCd;
                                dr[COL_PRTITEMSET_FREEPRTPAPERITEMCD] = ++freePrtPaperItemCd;
                                dr[COL_PRTITEMSET_FREEPRTPAPERITEMNM] = field.NameJp;
                                dr[COL_PRTITEMSET_FILENM] = layout.LayoutName + "RF";
                                dr[COL_PRTITEMSET_DDCHARCNT] = field.Length;
                                dr[COL_PRTITEMSET_DDNAME] = field.Name + "RF";

                                Type type = Type.GetType( "System." + field.Type );
                                if ( type == typeof( Image ) )
                                    dr[COL_PRTITEMSET_REPORTCONTROLCODE] = 3;
                                else
                                    dr[COL_PRTITEMSET_REPORTCONTROLCODE] = 1;

                                dr[COL_PRTITEMSET_HEADERUSEDIVCD] = 1;
                                dr[COL_PRTITEMSET_DETAILUSEDIVCD] = 1;
                                dr[COL_PRTITEMSET_FOOTERUSEDIVCD] = 1;
                                dr[COL_PRTITEMSET_EXTRACONDITIONDIVCD] = 0;
                                dr[COL_PRTITEMSET_EXTRACONDITIONTYPECD] = 0;
                                dr[COL_PRTITEMSET_COMMAEDITEXISTCD] = 0;
                                dr[COL_PRTITEMSET_PRINTPAGECTRLDIVCD] = 0;
                                dr[COL_PRTITEMSET_SYSTEMDIVCD] = 0;
                                dr[COL_PRTITEMSET_OPTIONCODE] = string.Empty;
                                dr[COL_PRTITEMSET_EXTRACONDDETAILGRPCD] = 0;
                                dr[COL_PRTITEMSET_TOTALITEMDIVCD] = 0;
                                dr[COL_PRTITEMSET_FORMFEEDITEMDIVCD] = 0;
                                dr[COL_PRTITEMSET_FREEPRTPPRDISPGRPCD] = 0;
                                dr[COL_PRTITEMSET_NECESSARYEXTRACONDCD] = 0;
                                if ( field.IsEncrypt )
                                    dr[COL_PRTITEMSET_CIPHERFLG] = 1;
                                else
                                    dr[COL_PRTITEMSET_CIPHERFLG] = 0;
                                dr[COL_PRTITEMSET_EXTRACTIONITDEDFLG] = 1;
                                dr[COL_PRTITEMSET_GROUPSUPPRESSCD] = 0;
                                dr[COL_PRTITEMSET_DTLCOLORCHANGECD] = 0;
                                dr[COL_PRTITEMSET_HEIGHTADJUSTDIVCD] = 0;
                                dr[COL_PRTITEMSET_ADDITEMUSEDIVCD] = 1;
                                dr[COL_PRTITEMSET_INPUTCHARCNT] = field.Width;
                                dr[COL_PRTITEMSET_BARCODESTYLE] = 0;

                                _ds.Tables[TBL_PRTITEMSET].Rows.Add( dr );
                                break;
                            }
                    }
                }
            }
        }

        /// <summary>
        /// 行追加処理
        /// </summary>
        /// <param name="tableName">DataTable名称</param>
        /// <param name="freePrtPprItemGrpCd">自由帳票項目グループコード</param>
        private void AddRow( string tableName, int freePrtPprItemGrpCd )
        {
            DataRow dr = _ds.Tables[tableName].NewRow();

            switch ( tableName )
            {
                case TBL_PRTITEMGRP:
                    {
                        dr[COL_COMMON_CREATEDATETIME] = DateTime.Now.Ticks;
                        dr[COL_COMMON_UPDATEDATETIME] = dr[COL_COMMON_CREATEDATETIME];
                        dr[COL_COMMON_LOGICALDELETECODE] = 0;
                        dr[COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD] = freePrtPprItemGrpCd;
                        dr[COL_PRTITEMGRP_FREEPRTPPRITEMGRPNM] = string.Empty;
                        dr[COL_PRTITEMGRP_PRINTPAPERUSEDIVCD] = 1;
                        dr[COL_PRTITEMGRP_EXTRACTIONPGID] = string.Empty;
                        dr[COL_PRTITEMGRP_EXTRACTIONPGCLASSID] = string.Empty;
                        dr[COL_PRTITEMGRP_OUTPUTPGID] = string.Empty;
                        dr[COL_PRTITEMGRP_OUTPUTPGCLASSID] = string.Empty;
                        dr[COL_PRTITEMGRP_DATAINPUTSYSTEM] = 0;
                        dr[COL_PRTITEMGRP_LINKSLIPDATAINPUTSYS] = 0;
                        dr[COL_PRTITEMGRP_LINKSLIPPRTKIND] = 0;
                        dr[COL_PRTITEMGRP_LINKSLIPPRTSETPPRID] = string.Empty;
                        dr[COL_PRTITEMGRP_EXTRASECTIONKINDCD] = 0;
                        dr[COL_PRTITEMGRP_EXTRASECTIONSELEXIST] = 0;
                        dr[COL_PRTITEMGRP_FORMFEEDLINECOUNT] = 0;
                        dr[COL_PRTITEMGRP_CRCHARCNT] = 0;
                        dr[COL_PRTITEMGRP_FREEPRTPPRSPPRPSECD] = 0;
                        break;
                    }
                case TBL_PRTITEMSET:
                    {
                        dr[COL_COMMON_CREATEDATETIME] = GetPrtItemGrpCreateDateTime();
                        dr[COL_COMMON_UPDATEDATETIME] = dr[COL_COMMON_CREATEDATETIME];
                        dr[COL_COMMON_LOGICALDELETECODE] = 0;
                        dr[COL_PRTITEMSET_FREEPRTPPRITEMGRPCD] = freePrtPprItemGrpCd;
                        dr[COL_PRTITEMSET_FREEPRTPAPERITEMCD] = GetMaxFreePrtPaperItemCd( freePrtPprItemGrpCd ) + 1;
                        dr[COL_PRTITEMSET_FREEPRTPAPERITEMNM] = string.Empty;
                        dr[COL_PRTITEMSET_FILENM] = string.Empty;
                        dr[COL_PRTITEMSET_DDCHARCNT] = 0;
                        dr[COL_PRTITEMSET_DDNAME] = string.Empty;
                        dr[COL_PRTITEMSET_REPORTCONTROLCODE] = 1;
                        dr[COL_PRTITEMSET_HEADERUSEDIVCD] = 1;
                        dr[COL_PRTITEMSET_DETAILUSEDIVCD] = 1;
                        dr[COL_PRTITEMSET_FOOTERUSEDIVCD] = 1;
                        dr[COL_PRTITEMSET_EXTRACONDITIONDIVCD] = 0;
                        dr[COL_PRTITEMSET_EXTRACONDITIONTYPECD] = 0;
                        dr[COL_PRTITEMSET_COMMAEDITEXISTCD] = 0;
                        dr[COL_PRTITEMSET_PRINTPAGECTRLDIVCD] = 0;
                        dr[COL_PRTITEMSET_SYSTEMDIVCD] = 0;
                        dr[COL_PRTITEMSET_OPTIONCODE] = string.Empty;
                        dr[COL_PRTITEMSET_EXTRACONDDETAILGRPCD] = 0;
                        dr[COL_PRTITEMSET_TOTALITEMDIVCD] = 0;
                        dr[COL_PRTITEMSET_FORMFEEDITEMDIVCD] = 0;
                        dr[COL_PRTITEMSET_FREEPRTPPRDISPGRPCD] = 0;
                        dr[COL_PRTITEMSET_NECESSARYEXTRACONDCD] = 0;
                        dr[COL_PRTITEMSET_CIPHERFLG] = 0;
                        dr[COL_PRTITEMSET_EXTRACTIONITDEDFLG] = 1;
                        dr[COL_PRTITEMSET_GROUPSUPPRESSCD] = 0;
                        dr[COL_PRTITEMSET_DTLCOLORCHANGECD] = 0;
                        dr[COL_PRTITEMSET_HEIGHTADJUSTDIVCD] = 0;
                        dr[COL_PRTITEMSET_ADDITEMUSEDIVCD] = 1;
                        dr[COL_PRTITEMSET_INPUTCHARCNT] = 0;
                        dr[COL_PRTITEMSET_BARCODESTYLE] = 0;
                        break;
                    }
                case TBL_FREPEXCNDD:
                    {
                        dr[COL_COMMON_CREATEDATETIME] = DateTime.Now.Ticks;
                        dr[COL_COMMON_UPDATEDATETIME] = dr[COL_COMMON_CREATEDATETIME];
                        dr[COL_COMMON_ENTERPRISECODE] = "TBS1            ";
                        dr[COL_COMMON_FILEHEADERGUID] = Guid.NewGuid();
                        dr[COL_COMMON_UPDEMPLOYEECODE] = "0283     ";
                        dr[COL_COMMON_UPDASSEMBLYID1] = "ImportData";
                        dr[COL_COMMON_UPDASSEMBLYID2] = "ImportData";
                        dr[COL_COMMON_LOGICALDELETECODE] = 0;
                        dr[COL_FREPEXCNDD_EXTRACONDDETAILGRPCD] = GetPrtItemSetExtraCondDtlGrpCd();
                        dr[COL_FREPEXCNDD_EXTRACONDDETAILCODE] = GetMaxExtraCondDetailCode( (int)dr[COL_FREPEXCNDD_EXTRACONDDETAILGRPCD] ) + 1;
                        dr[COL_FREPEXCNDD_EXTRACONDDETAILNAME] = "";
                        break;
                    }
            }

            _ds.Tables[tableName].Rows.Add( dr );
        }

        /// <summary>
        /// 印字項目設定デフォルト行追加処理
        /// </summary>
        /// <param name="freePrtPprItemGrpCd">自由帳票項目グループコード</param>
        private void AddPrtItemSetDefaultValueRow( int freePrtPprItemGrpCd )
        {
            string filePath = Path.Combine( System.Windows.Forms.Application.StartupPath, "PrtItemSet_Default.xml" );

            if ( File.Exists( filePath ) )
            {
                long createDateTime = 0;
                long updateDateTime = 0;

                DataRow[] drArray
                    = _ds.Tables[TBL_PRTITEMGRP].Select( COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD + "=" + freePrtPprItemGrpCd );
                if ( drArray != null && drArray.Length > 0 )
                {
                    createDateTime = (long)drArray[0][COL_COMMON_CREATEDATETIME];
                    updateDateTime = (long)drArray[0][COL_COMMON_UPDATEDATETIME];

                    DataSet ds = new DataSet();
                    ds.ReadXml( filePath );
                    if ( ds.Tables[0].Columns.Contains( COL_PRTITEMSET_FREEPRTPPRITEMGRPCD ) )
                    {
                        foreach ( DataRow dr in ds.Tables[0].Rows )
                        {
                            dr[COL_COMMON_CREATEDATETIME] = createDateTime;
                            dr[COL_COMMON_UPDATEDATETIME] = updateDateTime;
                            dr[COL_PRTITEMSET_FREEPRTPPRITEMGRPCD] = freePrtPprItemGrpCd;
                            _ds.Tables[TBL_PRTITEMSET].Rows.Add( dr.ItemArray );
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 印字項目グループ作成日時取得処理
        /// </summary>
        /// <returns>作成日時</returns>
        private long GetPrtItemGrpCreateDateTime()
        {
            long createDateTime = 0;

            if ( this.gridPrtItemGrp.ActiveRow != null )
            {
                createDateTime
                    = (long)this.gridPrtItemGrp.ActiveRow.Cells[COL_COMMON_CREATEDATETIME].Value;
            }

            return createDateTime;
        }

        /// <summary>
        /// 抽出条件明細グループコード取得処理
        /// </summary>
        /// <returns>抽出条件明細グループコード</returns>
        private long GetPrtItemSetExtraCondDtlGrpCd()
        {
            long extraCondDtlGrpCd = 0;

            if ( this.gridPrtItemSet.ActiveRow != null )
            {
                extraCondDtlGrpCd
                    = (int)this.gridPrtItemSet.ActiveRow.Cells[COL_PRTITEMSET_EXTRACONDDETAILGRPCD].Value;
            }

            return extraCondDtlGrpCd;
        }

        /// <summary>
        /// 自由帳票項目グループコード最大値取得処理
        /// </summary>
        /// <returns>自由帳票項目グループコード</returns>
        private int GetMaxFreePrtPprItemGrpCd()
        {
            int freePrtPprItemGrpCd = 0;

            string sort = COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD + " DESC";
            DataRow[] drArray = _ds.Tables[TBL_PRTITEMGRP].Select( "", sort );
            if ( drArray != null && drArray.Length > 0 )
                freePrtPprItemGrpCd = (int)drArray[0][COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD];

            return freePrtPprItemGrpCd;
        }

        /// <summary>
        /// 自由帳票項目コード最大値取得処理
        /// </summary>
        /// <param name="freePrtPprItemGrpCd">自由帳票項目グループコード</param>
        /// <returns>自由帳票項目コード</returns>
        private int GetMaxFreePrtPaperItemCd( int freePrtPprItemGrpCd )
        {
            int freePrtPaperItemCd = 100;

            string filter = COL_PRTITEMSET_FREEPRTPPRITEMGRPCD + "=" + freePrtPprItemGrpCd;
            string sort = COL_PRTITEMSET_FREEPRTPAPERITEMCD + " DESC";
            DataRow[] drArray = _ds.Tables[TBL_PRTITEMSET].Select( filter, sort );
            if ( drArray != null && drArray.Length > 0 )
                freePrtPaperItemCd = Math.Max( freePrtPaperItemCd, (int)drArray[0][COL_PRTITEMSET_FREEPRTPAPERITEMCD] );

            return freePrtPaperItemCd;
        }

        /// <summary>
        /// 抽出条件明細コード最大値取得処理
        /// </summary>
        /// <param name="extraCondDtlGrpCd">抽出条件明細グループコード</param>
        /// <returns>抽出条件明細コード</returns>
        private int GetMaxExtraCondDetailCode( int extraCondDtlGrpCd )
        {
            int extraCondDetailCode = 0;

            string filter = COL_FREPEXCNDD_EXTRACONDDETAILGRPCD + "=" + extraCondDtlGrpCd;
            string sort = COL_FREPEXCNDD_EXTRACONDDETAILCODE + " DESC";
            DataRow[] drArray = _ds.Tables[TBL_FREPEXCNDD].Select( filter, sort );
            if ( drArray != null && drArray.Length > 0 )
                extraCondDetailCode = (int)drArray[0][COL_FREPEXCNDD_EXTRACONDDETAILCODE];

            return extraCondDetailCode;
        }

        /// <summary>
        /// 抽出条件タイプ変更処理
        /// </summary>
        /// <param name="extraConditionDivCd">抽出条件区分</param>
        private void ChangeExtraConditionType( int extraConditionDivCd )
        {
            UltraGridColumn column
                = this.gridPrtItemSet.DisplayLayout.Bands[0].Columns[COL_PRTITEMSET_EXTRACONDITIONTYPECD];

            ValueList valueList = new ValueList();
            switch ( extraConditionDivCd )
            {
                case 0: // 使用しない
                case 5: // コンボボックス型
                case 6: // チェックボックス型
                    {
                        valueList.ValueListItems.Add( 0, " " );
                        break;
                    }
                case 1:	// 数値型
                    {
                        valueList.ValueListItems.Add( 0, "一致" );
                        valueList.ValueListItems.Add( 1, "範囲" );
                        break;
                    }
                case 2: // 文字型（半角）
                case 3: // 文字型（全角）
                    {
                        valueList.ValueListItems.Add( 0, "一致" );
                        valueList.ValueListItems.Add( 1, "範囲" );
                        valueList.ValueListItems.Add( 2, "あいまい" );
                        break;
                    }
                case 4: // 日付型
                    {
                        valueList.ValueListItems.Add( 0, "一致" );
                        valueList.ValueListItems.Add( 1, "範囲" );
                        valueList.ValueListItems.Add( 2, "あいまい" );
                        valueList.ValueListItems.Add( 3, "期間" );
                        break;
                    }
            }

            this.gridPrtItemSet.DisplayLayout.Bands[0].Columns[COL_PRTITEMSET_EXTRACONDITIONTYPECD].ValueList = valueList;
        }

        /// <summary>
        /// 入力チェック
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>チェック結果</returns>
        private bool InputCheck( out string errMsg )
        {
            errMsg = string.Empty;

            // 印字項目グループ
            foreach ( UltraGridRow grpRow in this.gridPrtItemGrp.Rows )
            {
                string filter = COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD + "=" + grpRow.Cells[COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD].Value;
                DataRow[] filterDrArray = _ds.Tables[TBL_PRTITEMGRP].Select( filter );
                if ( filterDrArray.Length > 1 )
                {
                    errMsg = "印字項目グループコードが重複しています";
                    this.gridPrtItemGrp.Focus();
                    this.gridPrtItemGrp.Rows[grpRow.Index].Activate();
                    return false;
                }

                // 印字項目明細
                foreach ( UltraGridRow setRow in this.gridPrtItemSet.Rows )
                {
                    filter = COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD + "=" + grpRow.Cells[COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD].Value
                        + " AND " + COL_PRTITEMSET_FREEPRTPAPERITEMCD + " = " + setRow.Cells[COL_PRTITEMSET_FREEPRTPAPERITEMCD].Value;
                    filterDrArray = _ds.Tables[TBL_PRTITEMSET].Select( filter );
                    if ( filterDrArray.Length > 1 )
                    {
                        errMsg = "印字項目コードが重複しています";
                        this.gridPrtItemSet.Focus();
                        this.gridPrtItemSet.Rows[setRow.Index].Activate();
                        return false;
                    }
                }
            }

            // 抽出条件明細
            foreach ( UltraGridRow row in this.gridFrePExCndD.Rows )
            {
                string filter = COL_FREPEXCNDD_EXTRACONDDETAILGRPCD + "=" + row.Cells[COL_FREPEXCNDD_EXTRACONDDETAILGRPCD].Value
                    + " AND " + COL_FREPEXCNDD_EXTRACONDDETAILCODE + "=" + row.Cells[COL_FREPEXCNDD_EXTRACONDDETAILCODE].Value;
                DataRow[] filterDrArray = _ds.Tables[TBL_FREPEXCNDD].Select( filter );
                if ( filterDrArray.Length > 1 )
                {
                    errMsg = "抽出明細コードが重複しています";
                    if ( !this.pnlFrePExCndD.Visible ) this.pnlFrePExCndD.Visible = true;
                    this.gridFrePExCndD.Focus();
                    this.gridFrePExCndD.Rows[row.Index].Activate();
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int SaveProc( out string errMsg )
        {
            int status = 0;
            errMsg = string.Empty;

            string fileName = string.Empty;
            try
            {
                this.ubPrtItemGrpAddRow.Focus();

                // 入力チェック
                if ( !InputCheck( out errMsg ) )
                    return 4;

                if ( _ds.Tables[TBL_PRTITEMGRP].Rows.Count != 0 ||
                    _ds.Tables[TBL_PRTITEMSET].Rows.Count != 0 )
                {
                    Directory.SetCurrentDirectory( System.Windows.Forms.Application.StartupPath );

                    StateButtonTool appendButtonTool = (StateButtonTool)this.utmMainToolbar.Tools["Append_StateButtonTool"];

                    // ☆☆☆ CSVファイルの保存 ☆☆☆
                    // 印字項目グループ
                    fileName = Path.Combine( SFANL08246CA.ctCSVSavePath, TBL_PRTITEMGRP + ".csv" );
                    status = SFANL08246CA.SaveCsv( _ds, TBL_PRTITEMGRP, SFANL08246CA.ctXSLFileName, fileName, appendButtonTool.Checked, out errMsg );
                    // 印字項目設定
                    if ( status == 0 )
                    {
                        fileName = Path.Combine( SFANL08246CA.ctCSVSavePath, TBL_PRTITEMSET + ".csv" );
                        status = SFANL08246CA.SaveCsv( _ds, TBL_PRTITEMSET, SFANL08246CA.ctXSLFileName, fileName, appendButtonTool.Checked, out errMsg );
                    }
                    // 自由帳票抽出条件明細
                    if ( status == 0 )
                    {
                        fileName = Path.Combine( SFANL08246CA.ctCSVSavePath, TBL_FREPEXCNDD + ".csv" );
                        status = SFANL08246CA.SaveCsv( _ds, TBL_FREPEXCNDD, SFANL08246CA.ctXSLFileName, fileName, appendButtonTool.Checked, out errMsg );
                    }
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/21 ADD
                    // 自由帳票ソート順位初期設定
                    if ( status == 0 )
                    {
                        fileName = Path.Combine( SFANL08246CA.ctCSVSavePath, TBL_FPSORTINIT + ".csv" );
                        status = SFANL08246CA.SaveCsv( _ds, TBL_FPSORTINIT, SFANL08246CA.ctXSLFileName, fileName, appendButtonTool.Checked, out errMsg );
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/21 ADD

                    // ☆☆☆ XMLファイルの保存 ☆☆☆
                    if ( status == 0 )
                    {
                        string filter = string.Empty;
                        foreach ( DataRow dr in _ds.Tables[TBL_PRTITEMGRP].Rows )
                        {
                            int freePrtPprItemGrpCd = (int)dr[COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD];
                            filter = COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD + "=" + freePrtPprItemGrpCd;
                            fileName = Path.Combine( SFANL08246CA.ctXMLSavePath, TBL_PRTITEMGRP + "_" + freePrtPprItemGrpCd + ".xml" );
                            status = SFANL08246CA.SaveXml( _ds, TBL_PRTITEMGRP, filter, fileName, out errMsg );
                            if ( status == 0 )
                            {
                                fileName = Path.Combine( SFANL08246CA.ctXMLSavePath, TBL_PRTITEMSET + "_" + freePrtPprItemGrpCd + ".xml" );
                                status = SFANL08246CA.SaveXml( _ds, TBL_PRTITEMSET, filter, COL_PRTITEMSET_FREEPRTPAPERITEMCD + " ASC", fileName, out errMsg );
                            }
                            if ( status == 0 )
                            {
                                fileName = Path.Combine( SFANL08246CA.ctXMLSavePath, TBL_FREPEXCNDD + ".xml" );
                                status = SFANL08246CA.SaveXml( _ds, TBL_FREPEXCNDD, string.Empty, fileName, out errMsg );
                            }
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/21 ADD
                            if ( status == 0 )
                            {
                                fileName = Path.Combine( SFANL08246CA.ctXMLSavePath, TBL_FPSORTINIT + "_" + freePrtPprItemGrpCd + ".xml" );
                                status = SFANL08246CA.SaveXml( _ds, TBL_FPSORTINIT, filter, fileName, out errMsg );
                            }
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/21 ADD

                            if ( status != 0 ) break;
                        }
                    }
                }
                else
                {
                    status = 4;
                    errMsg = "データが入力されていません。";
                }
            }
            catch ( Exception ex )
            {
                errMsg = "保存処理にて例外が発生しました。" + Environment.NewLine + ex.Message;
#if DEBUG
				errMsg += Environment.NewLine + ex.StackTrace;
#endif
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        private void DisplayInitialize()
        {
            _ds.Tables[TBL_PRTITEMGRP].Rows.Clear();
            _ds.Tables[TBL_PRTITEMSET].Rows.Clear();
            _ds.Tables[TBL_FREPEXCNDD].Rows.Clear();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/21 ADD
            _ds.Tables[TBL_FPSORTINIT].Rows.Clear();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/21 ADD

            this.ubPrtItemGrpDelRow.Enabled = false;
            this.ubPrtItemSetDelRow.Enabled = false;
            this.ubFrePExCndDDelRow.Enabled = false;

            this.pnlPrtItemSet.Enabled = false;

            StateButtonTool appendButtonTool = (StateButtonTool)this.utmMainToolbar.Tools["Append_StateButtonTool"];
            appendButtonTool.Checked = false;
            LabelTool modeLabelTool = (LabelTool)this.utmMainToolbar.Tools["Mode_LabelTool"];
            modeLabelTool.SharedProps.Caption = "CSV上書きモード";

            _isChanged = false;
            _isLoadFrePExCndD = false;
        }

        /// <summary>
        /// 抽出条件明細グループコード更新時の画面変更処理
        /// </summary>
        private void ChangeDispOfExtraCondDtlGrpCdUpdate()
        {
            if ( this.gridPrtItemSet.ActiveRow != null )
            {
                // フィルタ条件の変更
                int extraCondDtlGrpCd
                    = (int)this.gridPrtItemSet.ActiveRow.Cells[COL_PRTITEMSET_EXTRACONDDETAILGRPCD].Value;
                if ( uceFilterFrePExCndD.Checked )
                {
                    _ds.Tables[TBL_FREPEXCNDD].DefaultView.RowFilter
                        = COL_FREPEXCNDD_EXTRACONDDETAILGRPCD + "=" + extraCondDtlGrpCd;
                }

                if ( extraCondDtlGrpCd != 0 )
                {
                    this.pnlFrePExCndD.Visible = true;
                }
                else
                {
                    if ( !this.uceDispFrePExCndD.Checked )
                        this.pnlFrePExCndD.Visible = false;
                }
            }
        }
        #endregion

        #region Event
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void SFANL08240UA_Load( object sender, EventArgs e )
        {
            string message = string.Empty;
            try
            {
                // 印字項目グループ
                CreateDataTableSchema( _ds, TBL_PRTITEMGRP );

                // 印字項目設定
                CreateDataTableSchema( _ds, TBL_PRTITEMSET );

                // 自由帳票抽出条件明細
                CreateDataTableSchema( _ds, TBL_FREPEXCNDD );

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/21 ADD
                // 自由帳票ソート順位初期設定
                CreateDataTableSchema( _ds, TBL_FPSORTINIT );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/21 ADD

                this.gridPrtItemGrp.DataSource = _ds.Tables[TBL_PRTITEMGRP];
                this.gridPrtItemSet.DataSource = _ds.Tables[TBL_PRTITEMSET];
                this.gridFrePExCndD.DataSource = _ds.Tables[TBL_FREPEXCNDD];

                DisplayInitialize();
            }
            catch ( Exception ex )
            {
                message = "画面起動中に例外が発生しました。" + Environment.NewLine + ex.Message;
            }

            if ( !string.IsNullOrEmpty( message ) )
            {
                MessageBox.Show(
                    message,
                    ctMSG_CAPTION,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1 );

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
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void Grid_InitializeLayout( object sender, InitializeLayoutEventArgs e )
        {
            List<SchemaInfo> schemaInfoList = null;
            switch ( e.Layout.Grid.Name )
            {
                case "gridPrtItemGrp": schemaInfoList = _prtItemGrpSchemaInfoList; break;
                case "gridPrtItemSet": schemaInfoList = _prtItemSetSchemaInfoList; break;
                case "gridFrePExCndD": schemaInfoList = _frePExCndDSchemaInfoList; break;
            }

            if ( schemaInfoList != null )
            {
                foreach ( UltraGridColumn col in e.Layout.Bands[0].Columns )
                {
                    SchemaInfo schemaInfo = schemaInfoList.Find(
                        delegate( SchemaInfo wkSchemaInfo )
                        {
                            if ( wkSchemaInfo.Name == col.Key )
                                return true;
                            else
                                return false;
                        }
                    );

                    col.Header.Caption = schemaInfo.Caption;
                    col.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
                    col.MaxLength = schemaInfo.Length;

                    switch ( col.Key )
                    {
                        case COL_PRTITEMSET_FREEPRTPAPERITEMNM:
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/04 ADD
                        case COL_PRTITEMSET_FREEPRTPAPERITEMCD:
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/04 ADD
                            {
                                col.Header.Fixed = true;
                                break;
                            }
                        case COL_COMMON_CREATEDATETIME:
                        case COL_COMMON_UPDATEDATETIME:
                        case COL_COMMON_ENTERPRISECODE:
                        case COL_COMMON_FILEHEADERGUID:
                        case COL_COMMON_UPDEMPLOYEECODE:
                        case COL_COMMON_UPDASSEMBLYID1:
                        case COL_COMMON_UPDASSEMBLYID2:
                        case COL_COMMON_LOGICALDELETECODE:
                            {
                                if ( e.Layout.Grid.Name != "gridPrtItemGrp" )
                                    col.Hidden = true;
                                break;
                            }
                        case COL_PRTITEMGRP_PRINTPAPERUSEDIVCD:
                            {
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                                ValueList valueList = new ValueList();
                                valueList.ValueListItems.Add( 1, "帳票" );
                                valueList.ValueListItems.Add( 2, "伝票" );
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
                                //valueList.ValueListItems.Add(3, "DM一覧表");
                                //valueList.ValueListItems.Add(4, "DMはがき");
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
                                valueList.ValueListItems.Add( 5, "請求書" );
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
                                col.ValueList = valueList;
                                break;
                            }
                        case COL_PRTITEMSET_REPORTCONTROLCODE:
                            {
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                                ValueList valueList = new ValueList();
                                valueList.ValueListItems.Add( 1, "TextBox" );
                                valueList.ValueListItems.Add( 2, "Label" );
                                valueList.ValueListItems.Add( 3, "Picture" );
                                valueList.ValueListItems.Add( 4, "Shape" );
                                valueList.ValueListItems.Add( 5, "Line" );
                                valueList.ValueListItems.Add( 6, "BarCode" );
                                col.ValueList = valueList;
                                break;
                            }
                        case COL_PRTITEMSET_FREEPRTPPRITEMGRPCD:
                            {
                                if ( e.Layout.Grid.Name == "gridPrtItemSet" )
                                    col.Hidden = true;
                                break;
                            }
                        case COL_PRTITEMSET_HEADERUSEDIVCD:
                        case COL_PRTITEMSET_DETAILUSEDIVCD:
                        case COL_PRTITEMSET_FOOTERUSEDIVCD:
                        case COL_PRTITEMSET_TOTALITEMDIVCD:
                        case COL_PRTITEMSET_FORMFEEDITEMDIVCD:
                        case COL_PRTITEMSET_NECESSARYEXTRACONDCD:
                        case COL_PRTITEMSET_ADDITEMUSEDIVCD:
                            {
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                                ValueList valueList = new ValueList();
                                valueList.ValueListItems.Add( 0, "使用しない" );
                                valueList.ValueListItems.Add( 1, "使用する" );
                                col.ValueList = valueList;
                                break;
                            }
                        case COL_PRTITEMSET_DTLCOLORCHANGECD:
                        case COL_PRTITEMSET_GROUPSUPPRESSCD:
                        case COL_PRTITEMSET_CIPHERFLG:
                            {
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                                ValueList valueList = new ValueList();
                                valueList.ValueListItems.Add( 0, "なし" );
                                valueList.ValueListItems.Add( 1, "あり" );
                                col.ValueList = valueList;
                                break;
                            }
                        case COL_PRTITEMSET_EXTRACTIONITDEDFLG:
                        case COL_PRTITEMSET_HEIGHTADJUSTDIVCD:
                            {
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                                ValueList valueList = new ValueList();
                                valueList.ValueListItems.Add( 0, "非対象" );
                                valueList.ValueListItems.Add( 1, "対象" );
                                col.ValueList = valueList;
                                break;
                            }
                        case COL_PRTITEMSET_COMMAEDITEXISTCD:
                            {
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                                ValueList valueList = new ValueList();
                                valueList.ValueListItems.Add( 0, "使用しない" );
                                valueList.ValueListItems.Add( 1, "#,###" );
                                valueList.ValueListItems.Add( 2, "#,##0" );
                                valueList.ValueListItems.Add( 5, "\\#,##0" );
                                valueList.ValueListItems.Add( 6, "\\#,##0-" );
                                valueList.ValueListItems.Add( 3, "0.0" );
                                valueList.ValueListItems.Add( 4, "0.00" );
                                col.ValueList = valueList;
                                break;
                            }
                        case COL_PRTITEMSET_EXTRACONDITIONDIVCD:
                            {
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                                ValueList valueList = new ValueList();
                                valueList.ValueListItems.Add( 0, "使用しない" );
                                valueList.ValueListItems.Add( 1, "数値型" );
                                valueList.ValueListItems.Add( 2, "文字型（半角）" );
                                valueList.ValueListItems.Add( 3, "文字型（全角）" );
                                valueList.ValueListItems.Add( 4, "日付型" );
                                valueList.ValueListItems.Add( 5, "コンボボックス型" );
                                valueList.ValueListItems.Add( 6, "チェックボックス型" );
                                col.ValueList = valueList;
                                break;
                            }
                        case COL_PRTITEMSET_EXTRACONDITIONTYPECD:
                            {
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                                ValueList valueList = new ValueList();
                                valueList.ValueListItems.Add( 0, "一致" );
                                valueList.ValueListItems.Add( 1, "範囲" );
                                valueList.ValueListItems.Add( 2, "あいまい" );
                                valueList.ValueListItems.Add( 3, "期間" );
                                col.ValueList = valueList;
                                break;
                            }
                        case COL_PRTITEMSET_PRINTPAGECTRLDIVCD:
                            {
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                                ValueList valueList = new ValueList();
                                valueList.ValueListItems.Add( 0, "全ページ" );
                                valueList.ValueListItems.Add( 1, "1ページ目のみ" );
                                valueList.ValueListItems.Add( 2, "最終ページのみ" );
                                col.ValueList = valueList;
                                break;
                            }
                        case COL_PRTITEMGRP_DATAINPUTSYSTEM:
                        case COL_PRTITEMGRP_LINKSLIPDATAINPUTSYS:
                        case COL_PRTITEMSET_SYSTEMDIVCD:
                            {
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                                ValueList valueList = new ValueList();
                                valueList.ValueListItems.Add( 0, "共通" );
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 DEL
                                //valueList.ValueListItems.Add( 1, "整備" );
                                //valueList.ValueListItems.Add( 2, "鈑金" );
                                //valueList.ValueListItems.Add( 3, "車販" );
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 DEL
                                col.ValueList = valueList;
                                break;
                            }
                        case COL_PRTITEMGRP_EXTRASECTIONKINDCD:
                            {
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                                ValueList valueList = new ValueList();
                                valueList.ValueListItems.Add( 0, "使用しない" );
                                valueList.ValueListItems.Add( 1, "実績・請求" );
                                valueList.ValueListItems.Add( 2, "仕入・販売" );
                                col.ValueList = valueList;
                                break;
                            }
                        case COL_PRTITEMGRP_FREEPRTPPRSPPRPSECD:
                            {
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                                ValueList valueList = new ValueList();
                                valueList.ValueListItems.Add( 0, "使用しない" );
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 DEL
                                //valueList.ValueListItems.Add( 1, "案内文印刷タイプ" );
                                //valueList.ValueListItems.Add( 2, "専用帳票" );
                                //valueList.ValueListItems.Add( 3, "官製はがき" );
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 ADD
                                // 伝票関連（区分値は設計ＵＩでの区別の為だけに使用）
                                valueList.ValueListItems.Add( 1, "見積書" );
                                valueList.ValueListItems.Add( 4, "仕入返品伝票" );
                                valueList.ValueListItems.Add( 15, "在庫移動伝票" );
                                valueList.ValueListItems.Add( 16, "ＵＯＥ伝票" );
                                // 請求書関連（区分値をそのまま請求書管理マスタの印刷タイプにセット）
                                valueList.ValueListItems.Add( 50, "合計請求書" );
                                valueList.ValueListItems.Add( 60, "明細請求書" );
                                valueList.ValueListItems.Add( 70, "伝票合計請求書" );
                                valueList.ValueListItems.Add( 80, "領収書" );
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 ADD
                                col.ValueList = valueList;
                                break;
                            }
                        case COL_PRTITEMGRP_EXTRASECTIONSELEXIST:
                            {
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                                ValueList valueList = new ValueList();
                                valueList.ValueListItems.Add( 0, "使用しない" );
                                valueList.ValueListItems.Add( 1, "使用する(複数選択)" );
                                valueList.ValueListItems.Add( 2, "使用する(単体選択)" );
                                col.ValueList = valueList;
                                break;
                            }
                        case COL_PRTITEMSET_BARCODESTYLE:
                            {
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                                ValueList valueList = new ValueList();
                                valueList.ValueListItems.Add( 0, "なし" );
                                valueList.ValueListItems.Add( 1, "Code_128_A" );
                                valueList.ValueListItems.Add( 2, "JapanesePostal" );
                                valueList.ValueListItems.Add( 3, "QRCode" );
                                col.ValueList = valueList;
                                break;
                            }
                        default:
                            {
                                if ( col.DataType.IsPrimitive && !col.DataType.Equals( typeof( bool ) ) )
                                    col.CellAppearance.TextHAlign = HAlign.Right;
                                break;
                            }
                    }
                }
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
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void utmMainToolbar_ToolClick( object sender, ToolClickEventArgs e )
        {
            switch ( e.Tool.Key )
            {
                case "Exit_ButtonTool":
                    {
                        this.Close();
                        break;
                    }
                case "Open_ButtonTool":
                    {
                        this.openFileDialog.Filter = "印字項目グループXMLファイル|PrtItemGrp*.xml";
                        this.openFileDialog.InitialDirectory = Path.Combine( System.Windows.Forms.Application.StartupPath, SFANL08246CA.ctXMLSavePath );
                        if ( this.openFileDialog.ShowDialog() == DialogResult.OK )
                        {
                            // 印字項目グループ
                            _ds.Tables[TBL_PRTITEMGRP].ReadXml( this.openFileDialog.FileName );
                            // 印字項目設定
                            string fileName = Path.GetFileName( this.openFileDialog.FileName );
                            string filePath = Path.Combine( Path.GetDirectoryName( this.openFileDialog.FileName ), fileName.Replace( TBL_PRTITEMGRP, TBL_PRTITEMSET ) );
                            if ( File.Exists( filePath ) )
                                _ds.Tables[TBL_PRTITEMSET].ReadXml( filePath );
                            // 自由帳票抽出条件明細
                            if ( !_isLoadFrePExCndD )
                            {
                                filePath = Path.Combine( Path.GetDirectoryName( this.openFileDialog.FileName ), TBL_FREPEXCNDD + ".xml" );
                                if ( File.Exists( filePath ) )
                                {
                                    _ds.Tables[TBL_FREPEXCNDD].ReadXml( filePath );
                                    _isLoadFrePExCndD = true;
                                }
                            }
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/21 ADD
                            // 自由帳票ソート順位初期設定
                            filePath = Path.Combine( Path.GetDirectoryName( this.openFileDialog.FileName ), fileName.Replace( TBL_PRTITEMGRP, TBL_FPSORTINIT ) );
                            if ( File.Exists( filePath ) )
                            {
                                _ds.Tables[TBL_FPSORTINIT].ReadXml( filePath );
                            }
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/21 ADD

                            _isChanged = false;
                        }
                        break;
                    }
                case "Save_ButtonTool":
                    {
                        string errMsg;
                        int status = SaveProc( out errMsg );
                        switch ( status )
                        {
                            case 0:
                                {
                                    MessageBox.Show(
                                        "保存しました。",
                                        ctMSG_CAPTION,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information,
                                        MessageBoxDefaultButton.Button1 );
                                    _isChanged = false;
                                    break;
                                }
                            case 4:
                                {
                                    MessageBox.Show(
                                        errMsg,
                                        ctMSG_CAPTION,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information,
                                        MessageBoxDefaultButton.Button1 );
                                    break;
                                }
                            default:
                                {
                                    MessageBox.Show(
                                        errMsg,
                                        ctMSG_CAPTION,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error,
                                        MessageBoxDefaultButton.Button1 );
                                    break;
                                }
                        }
                        break;
                    }
                case "New_ButtonTool":
                    {
                        DisplayInitialize();
                        break;
                    }
                case "Append_StateButtonTool":
                    {
                        StateButtonTool appendButtonTool = (StateButtonTool)e.Tool;
                        LabelTool modeLabelTool = (LabelTool)this.utmMainToolbar.Tools["Mode_LabelTool"];
                        if ( appendButtonTool.Checked )
                            modeLabelTool.SharedProps.Caption = "CSV追記モード";
                        else
                            modeLabelTool.SharedProps.Caption = "CSV上書きモード";
                        break;
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
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void gridPrtItemGrp_AfterRowActivate( object sender, EventArgs e )
        {
            this.gridPrtItemGrp.Selected.Rows.Clear();
            this.gridPrtItemGrp.ActiveRow.Selected = true;

            // フィルタ条件の変更
            int freePrtPprItemGrpCd
                = (int)this.gridPrtItemGrp.ActiveRow.Cells[COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD].Value;
            _ds.Tables[TBL_PRTITEMSET].DefaultView.RowFilter
                = COL_PRTITEMSET_FREEPRTPPRITEMGRPCD + "=" + freePrtPprItemGrpCd;

            if ( freePrtPprItemGrpCd != 0 )
                this.pnlPrtItemSet.Enabled = true;

            this.ubPrtItemGrpDelRow.Enabled = true;
        }

        /// <summary>
        /// グリッドAfterRowActivateイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: グリッド上の行がアクティブ化した時に発生します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void gridPrtItemSet_AfterRowActivate( object sender, EventArgs e )
        {
            this.gridPrtItemSet.Selected.Rows.Clear();
            this.gridPrtItemSet.ActiveRow.Selected = true;

            ChangeDispOfExtraCondDtlGrpCdUpdate();

            this.ubPrtItemSetDelRow.Enabled = true;
        }

        /// <summary>
        /// グリッドAfterRowActivateイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: グリッド上の行がアクティブ化した時に発生します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void gridFrePExCndD_AfterRowActivate( object sender, EventArgs e )
        {
            this.gridFrePExCndD.Selected.Rows.Clear();
            this.gridFrePExCndD.ActiveRow.Selected = true;

            this.ubFrePExCndDDelRow.Enabled = true;
        }

        /// <summary>
        /// グリッドAfterCellUpdateイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: セルが新しい値を受け入れた後に発生します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void gridPrtItemGrp_AfterCellUpdate( object sender, CellEventArgs e )
        {
            switch ( e.Cell.Column.Key )
            {
                case COL_COMMON_CREATEDATETIME:
                case COL_COMMON_UPDATEDATETIME:
                case COL_COMMON_LOGICALDELETECODE:
                    {
                        int freePrtPprItemGrpCd = (int)e.Cell.Row.Cells[COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD].Value;
                        string filter = COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD + "=" + freePrtPprItemGrpCd;
                        DataRow[] drArray = _ds.Tables[TBL_PRTITEMSET].Select( filter );
                        foreach ( DataRow dr in drArray )
                            dr[e.Cell.Column.Key] = e.Cell.Value;
                        break;
                    }
                case COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD:
                    {
                        _ds.Tables[TBL_PRTITEMGRP].Rows[e.Cell.Row.ListIndex][COL_PRTITEMSET_FREEPRTPPRITEMGRPCD]
                            = e.Cell.Value;

                        string filter = COL_PRTITEMSET_FREEPRTPPRITEMGRPCD + "=" + _prevFreePrtPprItemGrpCd;
                        DataRow[] drArray = _ds.Tables[TBL_PRTITEMSET].Select( filter );
                        foreach ( DataRow dr in drArray )
                            dr[COL_PRTITEMSET_FREEPRTPPRITEMGRPCD] = e.Cell.Value;

                        // フィルタ設定を更新
                        _ds.Tables[TBL_PRTITEMSET].DefaultView.RowFilter
                            = COL_PRTITEMSET_FREEPRTPPRITEMGRPCD + "=" + e.Cell.Value;
                        break;
                    }
            }
            _isChanged = true;
        }

        /// <summary>
        /// グリッドBeforeCellUpdateイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: セルが新しい値を受け入れる前に発生します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void gridPrtItemGrp_BeforeCellUpdate( object sender, BeforeCellUpdateEventArgs e )
        {
            string message = string.Empty;

            switch ( e.Cell.Column.Key )
            {
                case COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD:
                    {
                        int freePrtPprItemGrpCd = (int)e.NewValue;
                        if ( freePrtPprItemGrpCd == 0 )
                        {
                            message = e.Cell.Column.Header.Caption + "に0は設定できません。";
                        }
                        else
                        {
                            DataRow[] drArray = _ds.Tables[TBL_PRTITEMGRP].Select( COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD + "=" + freePrtPprItemGrpCd );
                            if ( drArray == null || drArray.Length == 0 )
                                _prevFreePrtPprItemGrpCd = (int)e.Cell.Value;
                            else
                                message = e.Cell.Column.Header.Caption + "の重複は許可されていません。";
                        }
                        break;
                    }
            }

            if ( !string.IsNullOrEmpty( message ) )
            {
                MessageBox.Show(
                    message,
                    ctMSG_CAPTION,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1 );
                e.Cancel = true;
            }
        }

        /// <summary>
        /// グリッドBeforeCellUpdateイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: セルが新しい値を受け入れる前に発生します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void gridPrtItemSet_BeforeCellUpdate( object sender, BeforeCellUpdateEventArgs e )
        {
            string message = string.Empty;

            switch ( e.Cell.Column.Key )
            {
                case COL_PRTITEMSET_FREEPRTPAPERITEMCD:
                    {
                        int freePrtPprItemGrpCd = (int)e.Cell.Row.Cells[COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD].Value;
                        int freePrtPaperItemCd = (int)e.NewValue;
                        string filter = COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD + "=" + freePrtPprItemGrpCd + " AND " + COL_PRTITEMSET_FREEPRTPAPERITEMCD + "=" + freePrtPaperItemCd;
                        DataRow[] drArray = _ds.Tables[TBL_PRTITEMSET].Select( filter );
                        if ( drArray != null && drArray.Length > 0 )
                            message = e.Cell.Column.Header.Caption + "の重複は許可されていません。";
                        break;
                    }
                case COL_PRTITEMSET_EXTRACONDITIONTYPECD:
                    {
                        int extraConditionTypeCd = (int)e.NewValue;
                        int extraConditionDivCd = (int)e.Cell.Row.Cells[COL_PRTITEMSET_EXTRACONDITIONDIVCD].Value;
                        switch ( extraConditionDivCd )
                        {
                            case 1:	// 数値型
                                {
                                    if ( extraConditionTypeCd != 0 &&
                                        extraConditionTypeCd != 1 )
                                    {
                                        message =
                                            e.Cell.Row.Cells[COL_PRTITEMSET_EXTRACONDITIONDIVCD].Column.Header.Caption + "「"
                                            + e.Cell.Row.Cells[COL_PRTITEMSET_EXTRACONDITIONDIVCD].Text + "」の時、"
                                            + e.Cell.Column.Header.Caption + "「" + e.Cell.Text + "」は選択出来ません。";
                                    }
                                    break;
                                }
                            case 2: // 文字型（半角）
                            case 3: // 文字型（全角）
                                {
                                    if ( extraConditionTypeCd != 0 &&
                                        extraConditionTypeCd != 1 &&
                                        extraConditionTypeCd != 2 )
                                    {
                                        message =
                                            e.Cell.Row.Cells[COL_PRTITEMSET_EXTRACONDITIONDIVCD].Column.Header.Caption + "「"
                                            + e.Cell.Row.Cells[COL_PRTITEMSET_EXTRACONDITIONDIVCD].Text + "」の時、"
                                            + e.Cell.Column.Header.Caption + "「" + e.Cell.Text + "」は選択出来ません。";
                                    }
                                    break;
                                }
                            case 4: // 日付型
                                {
                                    if ( extraConditionTypeCd != 0 &&
                                        extraConditionTypeCd != 1 &&
                                        extraConditionTypeCd != 2 &&
                                        extraConditionTypeCd != 3 )
                                    {
                                        message =
                                            e.Cell.Row.Cells[COL_PRTITEMSET_EXTRACONDITIONDIVCD].Column.Header.Caption + "「"
                                            + e.Cell.Row.Cells[COL_PRTITEMSET_EXTRACONDITIONDIVCD].Text + "」の時、"
                                            + e.Cell.Column.Header.Caption + "「" + e.Cell.Text + "」は選択出来ません。";
                                    }
                                    break;
                                }
                            default:
                                {
                                    message =
                                        e.Cell.Row.Cells[COL_PRTITEMSET_EXTRACONDITIONDIVCD].Column.Header.Caption + "「"
                                        + e.Cell.Row.Cells[COL_PRTITEMSET_EXTRACONDITIONDIVCD].Text + "」の時、"
                                        + e.Cell.Column.Header.Caption + "「" + e.Cell.Text + "」は選択出来ません。";
                                    break;
                                }
                        }
                        break;
                    }
            }

            if ( !string.IsNullOrEmpty( message ) )
            {
                MessageBox.Show(
                    message,
                    ctMSG_CAPTION,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1 );
                e.Cancel = true;
            }
        }

        /// <summary>
        /// グリッドBeforeCellUpdateイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: セルが新しい値を受け入れる前に発生します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void gridFrePExCndD_BeforeCellUpdate( object sender, BeforeCellUpdateEventArgs e )
        {
            string message = string.Empty;

            switch ( e.Cell.Column.Key )
            {
                case COL_FREPEXCNDD_EXTRACONDDETAILCODE:
                    {
                        int extraCondDetailGrpCd = (int)e.Cell.Row.Cells[COL_FREPEXCNDD_EXTRACONDDETAILGRPCD].Value;
                        int extraCondDetailCode = (int)e.NewValue;
                        string filter = COL_FREPEXCNDD_EXTRACONDDETAILGRPCD + "=" + extraCondDetailGrpCd + " AND " + COL_FREPEXCNDD_EXTRACONDDETAILCODE + "=" + extraCondDetailCode;
                        DataRow[] drArray = _ds.Tables[TBL_FREPEXCNDD].Select( filter );
                        if ( drArray != null && drArray.Length > 0 )
                            message = e.Cell.Column.Header.Caption + "の重複は許可されていません。";
                        break;
                    }
            }

            if ( !string.IsNullOrEmpty( message ) )
            {
                MessageBox.Show(
                    message,
                    ctMSG_CAPTION,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1 );
                e.Cancel = true;
            }
        }

        /// <summary>
        /// グリッドAfterCellUpdateイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: セルが新しい値を受け入れた後に発生します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void gridPrtItemSet_AfterCellUpdate( object sender, CellEventArgs e )
        {
            switch ( e.Cell.Column.Key )
            {
                case COL_PRTITEMSET_EXTRACONDITIONDIVCD:
                    {
                        _ds.Tables[TBL_PRTITEMSET].Rows[e.Cell.Row.ListIndex][COL_PRTITEMSET_EXTRACONDITIONTYPECD] = 0;
                        break;
                    }
                case COL_PRTITEMSET_EXTRACONDDETAILGRPCD:
                    {
                        ChangeDispOfExtraCondDtlGrpCdUpdate();
                        break;
                    }
            }
            _isChanged = true;
        }

        /// <summary>
        /// グリッドAfterCellActivateイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: セルがアクティブになった後に発生します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void Gird_AfterCellActivate( object sender, EventArgs e )
        {
            UltraGrid ultraGrid = (UltraGrid)sender;

            if ( ultraGrid.ActiveCell.CanEnterEditMode )
                ultraGrid.PerformAction( UltraGridAction.EnterEditMode );
        }

        /// <summary>
        /// グリッドKeyDownイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: キーが最初に押されたときに発生します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void Grid_KeyDown( object sender, KeyEventArgs e )
        {
            UltraGrid ultraGrid = (UltraGrid)sender;
            switch ( e.KeyCode )
            {
                case Keys.Enter:
                    {
                        ultraGrid.PerformAction( UltraGridAction.NextCell );
                        e.Handled = true;
                        break;
                    }
                case Keys.Up:
                    {
                        if ( ultraGrid.ActiveCell != null )
                        {
                            switch ( ultraGrid.ActiveCell.Column.Style )
                            {
                                case Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList:
                                    {
                                        if ( e.Alt )
                                        {
                                            ultraGrid.ActiveCell.DroppedDown = true;
                                            e.Handled = true;
                                        }
                                        else if ( !ultraGrid.ActiveCell.DroppedDown )
                                        {
                                            ultraGrid.PerformAction( UltraGridAction.AboveCell );
                                            e.Handled = true;
                                        }
                                        break;
                                    }
                                default:
                                    {
                                        ultraGrid.PerformAction( UltraGridAction.AboveCell );
                                        e.Handled = true;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if ( ultraGrid.ActiveCell != null )
                        {
                            switch ( ultraGrid.ActiveCell.Column.Style )
                            {
                                case Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList:
                                    {
                                        if ( e.Alt )
                                        {
                                            ultraGrid.ActiveCell.DroppedDown = true;
                                            e.Handled = true;
                                        }
                                        else if ( !ultraGrid.ActiveCell.DroppedDown )
                                        {
                                            ultraGrid.PerformAction( UltraGridAction.BelowCell );
                                            e.Handled = true;
                                        }
                                        break;
                                    }
                                default:
                                    {
                                        ultraGrid.PerformAction( UltraGridAction.BelowCell );
                                        e.Handled = true;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        switch ( ultraGrid.ActiveCell.Column.Style )
                        {
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                                {
                                    if ( ultraGrid.ActiveCell.IsInEditMode )
                                    {
                                        if ( ultraGrid.ActiveCell.SelStart == 0 &&
                                            ultraGrid.ActiveCell.SelLength == 0 )
                                        {
                                            ultraGrid.PerformAction( UltraGridAction.PrevCell );
                                            e.Handled = true;
                                        }
                                    }
                                    else
                                    {
                                        ultraGrid.PerformAction( UltraGridAction.PrevCell );
                                        e.Handled = true;
                                    }
                                    break;
                                }
                            default:
                                {
                                    ultraGrid.PerformAction( UltraGridAction.PrevCell );
                                    e.Handled = true;
                                    break;
                                }
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        switch ( ultraGrid.ActiveCell.Column.Style )
                        {
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                                {
                                    if ( ultraGrid.ActiveCell.IsInEditMode )
                                    {
                                        if ( ultraGrid.ActiveCell.SelStart == ultraGrid.ActiveCell.Text.Length &&
                                            ultraGrid.ActiveCell.SelLength == 0 )
                                        {
                                            ultraGrid.PerformAction( UltraGridAction.NextCell );
                                            e.Handled = true;
                                        }
                                    }
                                    else
                                    {
                                        ultraGrid.PerformAction( UltraGridAction.NextCell );
                                        e.Handled = true;
                                    }
                                    break;
                                }
                            default:
                                {
                                    ultraGrid.PerformAction( UltraGridAction.NextCell );
                                    e.Handled = true;
                                    break;
                                }
                        }
                        break;
                    }
                case Keys.Delete:
                    {
                        if ( ultraGrid.ActiveCell != null )
                        {
                            if ( ultraGrid.ActiveCell.Column.DataType.Equals( typeof( int ) ) )
                                ultraGrid.ActiveCell.CancelUpdate();
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// 開くボタンClickイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 開くボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void ubFileOpen_Click( object sender, EventArgs e )
        {
            if ( this.gridPrtItemGrp.ActiveRow != null )
            {
                int freePrtPprItemGrpCd = (int)this.gridPrtItemGrp.ActiveRow.Cells[COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD].Value;
                this.openFileDialog.Filter = "ファイル仕様書(*.xls)|*.xls";
                if ( this.openFileDialog.ShowDialog() == DialogResult.OK )
                {
                    DeployLayoutInfo( this.openFileDialog.FileName, freePrtPprItemGrpCd );
                }
            }
            _isChanged = true;
        }

        /// <summary>
        /// 行追加ボタンClickイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 行追加ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void ubAddRow_Click( object sender, EventArgs e )
        {
            int freePrtPprItemGrpCd = 0;
            if ( sender == this.ubPrtItemGrpAddRow )
            {
                freePrtPprItemGrpCd = GetMaxFreePrtPprItemGrpCd() + 1;
                AddRow( TBL_PRTITEMGRP, freePrtPprItemGrpCd );

                // 自由帳票抽出条件明細
                if ( !_isLoadFrePExCndD )
                {
                    string filePath = Path.Combine( SFANL08246CA.ctXMLSavePath, TBL_FREPEXCNDD + ".xml" );
                    if ( File.Exists( filePath ) )
                    {
                        _ds.Tables[TBL_FREPEXCNDD].ReadXml( filePath );
                        _isLoadFrePExCndD = true;
                    }
                }

                AddPrtItemSetDefaultValueRow( freePrtPprItemGrpCd );
            }
            else if ( sender == this.ubPrtItemSetAddRow )
            {
                if ( this.gridPrtItemGrp.ActiveRow != null )
                {
                    freePrtPprItemGrpCd
                        = (int)this.gridPrtItemGrp.ActiveRow.Cells[COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD].Value;
                    AddRow( TBL_PRTITEMSET, freePrtPprItemGrpCd );
                }
            }
            else if ( sender == this.ubFrePExCndDAddRow )
            {
                AddRow( TBL_FREPEXCNDD, 0 );
            }
            _isChanged = true;
        }

        /// <summary>
        /// 行削除ボタンClickイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 行削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void ubDelRow_Click( object sender, EventArgs e )
        {
            int focusSetIndex = 0;

            if ( sender == this.ubPrtItemGrpDelRow )
            {
                if ( this.gridPrtItemGrp.ActiveRow != null )
                {
                    // 削除対象となるDataRowを取得
                    focusSetIndex = Math.Max( focusSetIndex, this.gridPrtItemGrp.ActiveRow.Index );
                    DataRow row = _ds.Tables[TBL_PRTITEMGRP].Rows[this.gridPrtItemGrp.ActiveRow.ListIndex];
                    int freePrtPprItemGrpCd = (int)row[COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD];

                    // 選択行を削除
                    _ds.Tables[TBL_PRTITEMGRP].Rows.Remove( row );
                    if ( focusSetIndex > 0 ) focusSetIndex--;

                    // 紐付く印字項目設定も削除
                    string filter = COL_PRTITEMSET_FREEPRTPPRITEMGRPCD + "=" + freePrtPprItemGrpCd;
                    DataRow[] drArray = _ds.Tables[TBL_PRTITEMSET].Select( filter );
                    foreach ( DataRow dr in drArray )
                        _ds.Tables[TBL_PRTITEMSET].Rows.Remove( dr );

                    // 行が残っている場合は1行目をアクティブ化
                    if ( this.gridPrtItemGrp.Rows.Count > 0 )
                    {
                        this.gridPrtItemGrp.Rows[focusSetIndex].Activate();
                    }
                    else
                    {
                        this.ubPrtItemGrpDelRow.Enabled = false;
                        this.pnlPrtItemSet.Enabled = false;
                    }
                }
            }
            else if ( sender == this.ubPrtItemSetDelRow )
            {
                if ( this.gridPrtItemSet.ActiveRow != null )
                {
                    // 削除対象となるDataRowを取得
                    List<DataRow> drList = new List<DataRow>();
                    focusSetIndex = Math.Max( focusSetIndex, this.gridPrtItemSet.ActiveRow.Index );

                    // 選択行を削除
                    DataRow row = ((DataRowView)this.gridPrtItemSet.ActiveRow.ListObject).Row;
                    _ds.Tables[TBL_PRTITEMSET].Rows.Remove( row );
                    if ( focusSetIndex > 0 ) focusSetIndex--;

                    // 行が残っている場合は1行目をアクティブ化
                    if ( this.gridPrtItemSet.Rows.Count > 0 )
                        this.gridPrtItemSet.Rows[focusSetIndex].Activate();
                    else
                        this.ubPrtItemSetDelRow.Enabled = false;
                }
            }
            else if ( sender == this.ubFrePExCndDDelRow )
            {
                if ( this.gridFrePExCndD.ActiveRow != null )
                {
                    // 削除対象となるDataRowを取得
                    focusSetIndex = Math.Max( focusSetIndex, this.gridFrePExCndD.ActiveRow.Index );

                    // 選択行を削除
                    DataRow row = _ds.Tables[TBL_FREPEXCNDD].Rows[this.gridFrePExCndD.ActiveRow.ListIndex];
                    _ds.Tables[TBL_FREPEXCNDD].Rows.Remove( row );
                    if ( focusSetIndex > 0 ) focusSetIndex--;

                    // 行が残っている場合は1行目をアクティブ化
                    if ( this.gridFrePExCndD.Rows.Count > 0 )
                        this.gridFrePExCndD.Rows[focusSetIndex].Activate();
                    else
                        this.ubFrePExCndDDelRow.Enabled = false;
                }
            }
            _isChanged = true;
        }

        /// <summary>
        /// コントロールCheckedChangedイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: Checkedプロパティの値が変更された後に発生します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void uceDispFrePExCndD_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.uceDispFrePExCndD.Checked )
            {
                this.pnlFrePExCndD.Visible = true;
            }
            else
            {
                if ( this.gridPrtItemSet.ActiveRow != null )
                {
                    int extraCondDtlGrpCd
                        = (int)this.gridPrtItemSet.ActiveRow.Cells[COL_PRTITEMSET_EXTRACONDDETAILGRPCD].Value;

                    if ( extraCondDtlGrpCd != 0 )
                        this.pnlFrePExCndD.Visible = true;
                    else
                        this.pnlFrePExCndD.Visible = false;
                }
                else
                {
                    this.pnlFrePExCndD.Visible = false;
                }
            }
        }

        /// <summary>
        /// コントロールCheckedChangedイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: Checkedプロパティの値が変更された後に発生します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void uceFilterFrePExCndD_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.uceFilterFrePExCndD.Checked )
            {
                // フィルタ条件の変更
                if ( this.gridPrtItemSet.ActiveRow != null )
                {
                    int extraCondDtlGrpCd
                        = (int)this.gridPrtItemSet.ActiveRow.Cells[COL_PRTITEMSET_EXTRACONDDETAILGRPCD].Value;

                    _ds.Tables[TBL_FREPEXCNDD].DefaultView.RowFilter
                        = COL_FREPEXCNDD_EXTRACONDDETAILGRPCD + "=" + extraCondDtlGrpCd;
                }
            }
            else
            {
                _ds.Tables[TBL_FREPEXCNDD].DefaultView.RowFilter = string.Empty;
            }
        }

        /// <summary>
        /// グリッドKeyPressイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: コントロールがフォーカスを持っていて、</br>
        /// <br>			: ユーザーがキーを押して離したときに発生します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void Grid_KeyPress( object sender, KeyPressEventArgs e )
        {
            UltraGrid ultraGrid = (UltraGrid)sender;
            // Ctrl、Altキーを押下していない
            if ( !Control.ModifierKeys.Equals( Keys.Control ) &&
                !Control.ModifierKeys.Equals( Keys.Alt ) )
            {
                // 列のスタイルがEdit
                if ( ultraGrid.ActiveCell != null &&
                    ultraGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Default )
                {
                    // 数値型の列
                    if ( ultraGrid.ActiveCell.Column.DataType.IsPrimitive &&
                        !ultraGrid.ActiveCell.Column.DataType.Equals( typeof( bool ) ) )
                    {
                        // 数字キー及びBackSpace以外は除外
                        if ( (!char.IsDigit( e.KeyChar )) &&
                            (!e.KeyChar.Equals( (char)Keys.Back )) )
                            e.Handled = true;
                    }
                }
            }
        }

        /// <summary>
        /// FormClosingイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがフォームを閉じるたびに、フォームが閉じられる前、</br>
        /// <br>			: および閉じる理由を指定する前に発生します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void SFANL08240UA_FormClosing( object sender, FormClosingEventArgs e )
        {
            if ( _isChanged )
            {
                if ( _ds.Tables[TBL_PRTITEMGRP].Rows.Count > 0 ||
                    _ds.Tables[TBL_PRTITEMSET].Rows.Count > 0 ||
                    _ds.Tables[TBL_FREPEXCNDD].Rows.Count > 0 )
                {
                    DialogResult dlgRet = MessageBox.Show(
                        "現在編集中のデータが存在します。" + Environment.NewLine + "データを保存しますか？"
                        , "保存確認"
                        , MessageBoxButtons.YesNoCancel
                        , MessageBoxIcon.Question
                        , MessageBoxDefaultButton.Button1
                    );
                    switch ( dlgRet )
                    {
                        case DialogResult.Yes:
                            {
                                string errMsg;
                                int status = SaveProc( out errMsg );
                                switch ( status )
                                {
                                    case 0:
                                        {
                                            break;
                                        }
                                    default:
                                        {
                                            MessageBox.Show(
                                                errMsg,
                                                ctMSG_CAPTION,
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error,
                                                MessageBoxDefaultButton.Button1 );
                                            break;
                                        }
                                }
                                break;
                            }
                        case DialogResult.No:
                            {
                                break;
                            }
                        case DialogResult.Cancel:
                            {
                                e.Cancel = true;
                                break;
                            }
                    }
                }
            }
        }

        /// <summary>
        /// 自由帳票項目コード採番ボタンClickイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 自由帳票項目コード採番ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void ubSetFreePrtPaperItemCd_Click( object sender, EventArgs e )
        {
            this.gridPrtItemSet.EventManager.AllEventsEnabled = false;
            try
            {
                int number = 101;
                foreach ( UltraGridRow row in this.gridPrtItemSet.Rows )
                {
                    int freePrtPaperItemCd;
                    int.TryParse( row.Cells[COL_PRTITEMSET_FREEPRTPAPERITEMCD].Value.ToString(), out freePrtPaperItemCd );
                    if ( freePrtPaperItemCd > 100 )
                        _ds.Tables[TBL_PRTITEMSET].Rows[row.ListIndex][COL_PRTITEMSET_FREEPRTPAPERITEMCD] = number++;
                }
            }
            finally
            {
                this.gridPrtItemSet.EventManager.AllEventsEnabled = true;
            }
        }

        /// <summary>
        /// グリッドAfterCellUpdateイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: セルが新しい値を受け入れた後に発生します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void gridFrePExCndD_AfterCellUpdate( object sender, CellEventArgs e )
        {
            _isChanged = true;
        }

        /// <summary>
        /// UPボタンClickイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: UPボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void ubUp_Click( object sender, EventArgs e )
        {
            if ( this.gridPrtItemSet.ActiveRow != null )
            {
                int rowIndex = this.gridPrtItemSet.ActiveRow.Index;
                if ( rowIndex > 0 )
                    this.gridPrtItemSet.Rows.Move( this.gridPrtItemSet.ActiveRow, rowIndex - 1, true );
                _isChanged = true;
            }
        }

        /// <summary>
        /// DOWNボタンClickイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: DOWNボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void ubDown_Click( object sender, EventArgs e )
        {
            if ( this.gridPrtItemSet.ActiveRow != null )
            {
                int rowIndex = this.gridPrtItemSet.ActiveRow.Index;
                if ( rowIndex < this.gridPrtItemSet.Rows.Count - 1 )
                    this.gridPrtItemSet.Rows.Move( this.gridPrtItemSet.ActiveRow, rowIndex + 1, true );
                _isChanged = true;
            }
        }

        /// <summary>
        /// グリッドENTERイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: コントロールがフォームのアクティブコントロールになったときに発生します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void Grid_Enter( object sender, EventArgs e )
        {
            UltraGrid ultraGrid = (UltraGrid)sender;
            if ( ultraGrid.Rows.Count > 0 )
            {
                if ( ultraGrid.ActiveCell == null )
                {
                    if ( ultraGrid.ActiveRow == null )
                        ultraGrid.Rows[0].Cells[0].Activate();
                    else
                        ultraGrid.ActiveRow.Cells[0].Activate();
                }
                ultraGrid.PerformAction( UltraGridAction.EnterEditMode );
            }
        }

        /// <summary>
        /// グリッドInitializeRowイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: 行が初期化された時に発生します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void gridPrtItemSet_InitializeRow( object sender, InitializeRowEventArgs e )
        {
            // バーコードスタイルはコントロールタイプがBarcodeの時のみ編集可能
            if ( (int)e.Row.Cells[COL_PRTITEMSET_REPORTCONTROLCODE].Value == 6 )
                e.Row.Cells[COL_PRTITEMSET_BARCODESTYLE].Activation = Activation.AllowEdit;
            else
                e.Row.Cells[COL_PRTITEMSET_BARCODESTYLE].Activation = Activation.Disabled;
        }
        #endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/04 ADD
        /// <summary>
        /// 明細複写ボタンクリックイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraButton1_Click( object sender, EventArgs e )
        {
            // アクティブな行のグループコードを取得
            int focusSetIndex = this.gridPrtItemGrp.ActiveRow.Index;
            DataRow row = _ds.Tables[TBL_PRTITEMGRP].Rows[this.gridPrtItemGrp.ActiveRow.ListIndex];
            int freePrtPprItemGrpCd = (int)row[COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD];

            // コピーフォーム呼び出し
            SFANL08240UB copyForm = new SFANL08240UB( _ds.Tables[TBL_PRTITEMSET], freePrtPprItemGrpCd );
            copyForm.Show();
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/04 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/21 ADD
        private void ultraButton2_Click( object sender, EventArgs e )
        {
            // データコピー
            CopyToSortInitFromPrtItem();

            // アクティブな行のグループコードを取得
            int focusSetIndex = this.gridPrtItemGrp.ActiveRow.Index;
            DataRow row = _ds.Tables[TBL_PRTITEMGRP].Rows[this.gridPrtItemGrp.ActiveRow.ListIndex];
            int freePrtPprItemGrpCd = (int)row[COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD];

            SFANL08240UC sortSettingForm = new SFANL08240UC( _ds.Tables[TBL_FPSORTINIT], freePrtPprItemGrpCd );
            sortSettingForm.ShowDialog();

            // 不要データ削除
            ComplessSortInit();
        }

        /// <summary>
        /// 自由帳票ソート順位初期設定 生成
        /// </summary>
        /// <remarks>印字項目設定の内容を元に、ソート順初期設定データを生成する</remarks>
        private void CopyToSortInitFromPrtItem()
        {
            bool createNew = (_ds.Tables[TBL_FPSORTINIT].Rows.Count == 0);


            int sortingOrder = _ds.Tables[TBL_FPSORTINIT].Rows.Count + 1;

            // 印字項目からコピーする
            foreach ( DataRow itemRow in _ds.Tables[TBL_PRTITEMSET].Rows )
            {
                // DD名の無い項目(固定文字,直線など)は除外する
                if ( itemRow[COL_PRTITEMSET_DDNAME] == DBNull.Value || string.IsNullOrEmpty( (string)itemRow[COL_PRTITEMSET_DDNAME] ) )
                {
                    continue;
                }

                // 既存項目は迂回
                if ( CheckExistsSortInit( (int)itemRow[COL_PRTITEMSET_FREEPRTPAPERITEMCD], _ds.Tables[TBL_FPSORTINIT] ) )
                {
                    continue;
                }

                // 項目追加
                DataRow newRow = _ds.Tables[TBL_FPSORTINIT].NewRow();

                # region [値セット]
                newRow[COL_COMMON_CREATEDATETIME] = itemRow[COL_COMMON_CREATEDATETIME]; // 作成日時
                newRow[COL_COMMON_UPDATEDATETIME] = itemRow[COL_COMMON_UPDATEDATETIME]; // 更新日時
                newRow[COL_COMMON_LOGICALDELETECODE] = itemRow[COL_COMMON_LOGICALDELETECODE]; // 論理削除区分

                newRow[COL_FPSORTINIT_FREEPRTPPRITEMGRPCD] = itemRow[COL_PRTITEMSET_FREEPRTPPRITEMGRPCD]; // 自由帳票項目グループコード
                newRow[COL_FPSORTINIT_FREEPRTPPRSCHMGRPCD] = 0; // 自由帳票スキーマグループコード (0:新規)
                newRow[COL_FPSORTINIT_SORTINGORDER] = sortingOrder++; // ソート順位 (1～)
                newRow[COL_FPSORTINIT_SORTINGORDERCODE] = itemRow[COL_PRTITEMSET_FREEPRTPAPERITEMCD]; // ソート順位コード
                newRow[COL_FPSORTINIT_FREEPRTPAPERITEMNM] = itemRow[COL_PRTITEMSET_FREEPRTPAPERITEMNM]; // 自由帳票項目名称
                newRow[COL_FPSORTINIT_DDNAME] = itemRow[COL_PRTITEMSET_DDNAME]; // DD名称
                newRow[COL_FPSORTINIT_FILENM] = itemRow[COL_PRTITEMSET_FILENM]; // ファイル名称

                if ( createNew )
                {
                    newRow[COL_FPSORTINIT_SORTINGORDERDIVCD] = 0; // 昇順降順区分 (0:ソート無)
                }
                else
                {
                    newRow[COL_FPSORTINIT_SORTINGORDERDIVCD] = -1; // 昇順降順区分 (-1:設定不可)
                }
                # endregion

                _ds.Tables[TBL_FPSORTINIT].Rows.Add( newRow );
            }
        }
        /// <summary>
        /// 自由帳票ソート順位初期設定の項目存在チェック
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        private bool CheckExistsSortInit( int itemCode, DataTable table )
        {
            DataView view = new DataView( table );
            view.RowFilter = string.Format( "{0}='{1}'", COL_FPSORTINIT_SORTINGORDERCODE, itemCode );

            return (view.Count > 0);
        }
        /// <summary>
        /// 自由帳票ソート順位初期設定圧縮処理（不要レコード削除）
        /// </summary>
        private void ComplessSortInit()
        {
            List<DataRow> deleteRowList = new List<DataRow>();
            DataView view = new DataView( _ds.Tables[TBL_FPSORTINIT] );

            foreach ( DataRowView rowView in view )
            {
                if ( (int)rowView[COL_FPSORTINIT_SORTINGORDERDIVCD] <= -1 )
                {
                    // -1:設定不可　は削除対象にする
                    deleteRowList.Add( rowView.Row );
                }
            }

            // テーブルから削除
            foreach ( DataRow row in deleteRowList )
            {
                _ds.Tables[TBL_FPSORTINIT].Rows.Remove( row );
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/21 ADD
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
        public SchemaInfo( string name, string caption, Type type, int length )
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
                if ( string.IsNullOrEmpty( _name ) )
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
                if ( string.IsNullOrEmpty( _caption ) )
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