/// <br>Update Note: 2012/05/24配信分 2012/04/01 Redmine#29250 </br>
/// <br>             得意先電子元帳　データ更新日時の追加について(明細更新日時の追加)</br>
/// <br>Update Note:                  2012/06/01 30744 湯上 千加子</br>
/// <br>             得意先電子元帳　残高一覧表示の抽出拠点追加</br>
/// <br>Update Note:                  2012/08/22 FSI菅原　要</br>
/// <br>             得意先電子元帳　ユーザー設定の仕入日補完処理追加</br>
/// <br>Update Note:                  2013/04/19 宮本 利明</br>
/// <br>             得意先電子元帳　赤伝発行・再発行時の印刷確認ダイアログ表示設定を追加</br>
/// <br>Update Note:                  2013/05/20 #35729 liusy</br>
/// <br>             得意先電子元帳　 テキスト出力時の和暦対応</br>
/// <br>Update Note:                  2014/02/05 宮本 利明</br>
/// <br>             得意先電子元帳　仕掛一覧 №2290</br>
/// <br>Update Note:                  K2014/05/28 林超凡 </br>
/// <br>           : 得意先電子元帳  Redmine#42764 受入テスト障害対応。東亜商会個別対応</br>
/// <br>Update Note:                  K2014/06/04 呉軍 </br>
/// <br>           : 得意先電子元帳  Redmine#42764 東亜商会個別受入テスト障害対応№8</br>
/// <br>Update Note:                  2015/03/16 陳永康</br>
/// <br>           : 得意先電子元帳  変換後品番 初期値の非表示対応</br>
/// <br>UpdateNote : 2015/02/05 王亜楠 </br>
/// <br>           : テキスト出力件数制限なしモードの追加</br>
/// <br>UpdateNote : 2015/02/25 王亜楠 Redmine#44701 No.1 </br>
/// <br>           : テキスト出力件数制限なし位置の調整</br>
/// <br>UpdateNote : 2015/03/03 王亜楠 Redmine#44701</br>
/// <br>           : 抽出件数制限なしチェック時のメッセージの変更</br>
/// <br>Update Note: K2015/04/27 陳亮 </br>
/// <br>管理番号   : 11100842-00 モモセ部品㈱の個別開発依頼 </br>
/// <br>           : 得意先電子元帳第二売価を追加する。モモセ部品㈱オプションが有効の場合のみ。</br>
/// <br>Update Note: 得意先電子元帳  K2015/06/16 鮑晶 </br>
/// <br>管理番号   :                 11101427-00</br>
/// <br>           :                 メイゴ㈱の個別開発依頼 </br>
/// <br>           :                 得意先電子元帳「地区」と「分析コード」を追加する。</br>
/// <br>Update Note:                  2015/09/17 田建委</br>
/// <br>           : 得意先電子元帳  Redmine#47006 得意先電子元帳の障害対応</br>
/// <br>           :                 現行保障をするため画面に区分を設ける</br>
/// <br>Update Note:                  2015/11/13 陳艶丹</br>
/// <br>           : 得意先電子元帳  Redmine#47636 メイゴ㈱とモモセ部品㈱マージ</br>
/// <br>           :                 マージした後、得意先電子元帳のテキスト出力で、地区が出力されないの障害対応</br>
/// <br>Update Note: K2015/11/17  周健 </br>
/// <br>管理番号   : 11170188-00  </br>
/// <br>           : Redmine#47636　#6設定情報を更新しない場合、設定前のxmlファイルと比較値が変わっているの障害対応。</br>
/// <br>Update Note: 2018/09/04 譚洪</br>
/// <br>管理番号   : 11470152-00</br>
/// <br>           : 履歴自動表示機能追加対応</br>
/// <br>Update Note: 2022/05/05 仰亮亮</br>
/// <br>管理番号   : 11870080-00</br>
/// <br>           : 納品書電子帳簿連携対応</br>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Broadleaf.Application.Common;     // UserSettingControllerに使用
//using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
using Broadleaf.Application.Controller;
// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
// --------ADD 2022/05/05 仰亮亮 納品書電子帳簿対応　-------->>>>>
using Broadleaf.Library.Resources;
using System.Collections;
using Broadleaf.Application.UIData;
// --------ADD 2022/05/05 仰亮亮 納品書電子帳簿対応　-------<<<<<

namespace Broadleaf.Windows.Forms
{
    public partial class PMKAU04004UA : Form
    {
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.27 ADD
        // 設定ファイル上の列番号は3桁ゼロ詰め
        static public readonly int ct_ColumnCountLength = 3;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.27 ADD

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
        # region const
        // パターン削除確認メッセージ
        private const string MSG_CONFIRM_DELETE_PATTERN = "選択中の出力パターンを削除してよろしいですか？";
        // ファイル名未入力メッセージ
        private const string MSG_OUTPUTTEXT_NOFILENAME = "ファイル名を入力して下さい";
        
        // パターン未入力メッセージ
        private const string MSG_OUTPUTTEXT_NOPATTERN = "出力パターンを入力して下さい";
        // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿対応　-------->>>>>
        ///<summary> PDFプリンタ管理番号 必須入力チェック メッセージ</summary>
        private const string MSG_PDFPRINTERNUMBER_NOPATTERN = "プリンタ設定で、PDFプリンタを正しく登録してください。";
        ///<summary> PDFプリンタ管理番号 必須入力チェック メッセージ</summary>
        private const string MSG_PDFPRINTERWAIT_NOPATTERN = "PDFプリンタ待機時間を設定して下さい。";
        ///<summary> 「PDF出力しない」モード</summary>
        private const int MODE_NONE = 1;
        // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿対応　-------<<<<<

        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/15 ADD
        # region event
        /// <summary>伝票グリッド設定初期化</summary>
        public event EventHandler ClearSettingSlipGrid;
        /// <summary>明細グリッド設定初期化</summary>
        public event EventHandler ClearSettingDetailGrid;
        /// <summary>赤伝グリッド設定初期化</summary>
        public event EventHandler ClearSettingRedSlipGrid;
        /// <summary>残高グリッド設定初期化</summary>
        public event EventHandler ClearSettingBalanceGrid;

        //----- ADD 2015/02/05 王亜楠 -------------------->>>>>
        public event EventHandler TextOutputEvent;
        //----- ADD 2015/02/05 王亜楠 --------------------<<<<<
        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/15 ADD

        #region プライベート変数

        // 設定保存用共通オブジェクト

        //private UserSettingController uSettingControl;

        /// <summary>設定XMLファイル名</summary>
        private const string XML_FILE_NAME = "PMKAU04000U_Construction.XML";

        //----- DEL K2014/06/04 By 呉軍 Redmine42764 №8 -------->>>>>
        ////----- ADD K2014/05/28 By 林超凡 Redmine#42764 受入テスト障害対応 BEGIN--------->>>>>
        ///// <summary>伝票グリッド原始コード(東亜商会用)</summary>
        //private const string XML_SLIP_CODE_TOUA = "1039104010410000000110421043000200030004000500060007000900100011001200130014001500160017001800190020002100220023002400250026002700280029003000311044003210450033003400350036104600371047003810481049105010510008";
        ///// <summary>明細グリッド原始コード(東亜商会用)</summary>
        //private const string XML_DETAIL_CODE_TOUA = "107310741075000000010002107610770003107800040005107900060007000800090010001100120013001400151080001600170018108110820019108300200021002200240025002600270028002900300031003200330034003500360037003800390040004110840042108500431086004400451087004600470048004900500051005200530054005500560057005800590060108800610062108900631090006400650066109100670068109200231093109410951096109710981099110011011102110311041105110611071108110900691110111111121113111411151116111711180070007100721119112011211122";        
        ////----- ADD K2014/05/28 By 林超凡 Redmine#42764 受入テスト障害対応 END---------<<<<<
        //----- DEL K2014/06/04 By 呉軍 Redmine42764 №8 --------<<<<<

        // データセット
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
        //private ExportColumnDataSet _dataSet;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
        private CustPtrSalesDetailDataSet _dataSet;
        private int prevDividerChar;
        private int prevParenthesis;
        private int prevTieNumeric;
        private int prevTieChar;
        private int prevTitleLine;
        private int prevSlipNote;
        private int prevSlipNote2;
        private int prevSlipNote3;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD

        // ユーザー設定
        private CustPtrSalesUserConst _userSetting;
        // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿対応　-------->>>>>
        /// <summary>PDF出力設定の設定項目（得意先電子元帳）</summary>
        private const string ctPrint_PMKAU04001U_PDFOutputSettings_Xml = "PMKAU04001U_PDFOutputSettings.xml";
        /// <summary>PDF出力設定の設定項目（得意先電子元帳）</summary>
        private const string ctPrint_PMKAU04001U_PDFPrinterSettingEnable_Xml = "PMKAU04001U_PDFPrinterSettingEnable.xml";
        /// <summary>Windows標準 PDFプリンタ名　Microsoft Print to PDF</summary>
        private const string ctBase_PrintName = "MICROSOFT PRINT TO PDF";
        /// <summary>その他 Cube PDFプリンタ名　CUBEPDF</summary>
        private const string ctOther_CubePrintName = "CUBEPDF";
        /// <summary> PDF出力設定ファイル構造体</summary>
        private eBooksOutputSetting _eBooksOutputSetting;
        /// <summary> プリンタ設定アクセスクラス</summary>
        private PrtManageAcs _prtManageAcs = null;
        /// <summary> プリンタDic</summary>
        private Dictionary<string, string> _printDic = null;

        /// <summary>スクリプトEnum(0:Windows標準 Microsoft Print to PDF /1:その他 PRIMOPDF・CUBEPDF)</summary>
        private enum pdfPrinterEnum : int
        {
            BaseSetting_Xml = 0,　　// Windows標準
            OtherSetting_Xml = 1,   // その他
        }

        /// <summary>出力伝票区分 0:両方選択なし/1:赤伝/2:再発行/3:両方選択あり </summary>
        private enum outPutSlipTypeEnum : int
        {
            No = 0,                 // 0:両方選択なし
            DebitNoteChecked = 1,   // 赤伝のみ
            RePrintChecked = 2,     // 再発行
            All = 3,                // 両方選択あり
        }

        // PDF出力区分デフォルト値 「しない」
        private const string DEFAULT_PDFOUTPUT_VALUE = "1";
        // 出力伝票区分_赤伝
        private const string DEFAULT_OUTPUTSLIPTYPE_VALUE = "1";
        // PDFプリンター
        private const string DEFAULT_PRINTER_VALUE = "0";
        // PDFプリンターNo
        private const string DEFAULT_PRINTERNO_VALUE = "9999";
        // PDFプリンター待機時間
        private const string DEFAULT_PRINTERWAUTTIME_VALUE = "0";

        /// <summary>電子帳簿連携オプション(OPT-PM03300)</summary>
        public int _opt_EBooksLink;
        /// <summary>電子帳簿連携オプション(OPT-PM03300)</summary>
        public int Opt_EBooksLink
        {
            get { return _opt_EBooksLink; }
            set { _opt_EBooksLink = value; }
        }
        // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿対応　-------<<<<<

        // --- DEL 2020/12/21 警告対応 ---------->>>>>
        //// ユーザー設定
        //private int _outputStyle;
        //
        //// **** スキン設定用クラス ****
        //private ControlScreenSkin _controlScreenSkin;
        // --- DEL 2020/12/21 警告対応 ----------<<<<<

        // 区切り文字
        private string _divider;

        // パターン
        private string[] _outputPattern;

        // 選択されているパターン名
        private string _selectedPattern;

        // 伝票グリッドの設定
        private string _gridSetting_Slip = string.Empty;

        // 明細グリッドの設定
        private string _gridSetting_Detail = string.Empty;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
        // 伝票項目indexディクショナリ
        private Dictionary<string, int> _columnIndexDicOfSlip;
        // 明細項目indexディクショナリ
        private Dictionary<string, int> _columnIndexDicOfDetail;
        // 伝票グリッドカラム・コレクション
        private Infragistics.Win.UltraWinGrid.ColumnsCollection _slipColCollection;
        // 明細グリッドカラム・コレクション
        private Infragistics.Win.UltraWinGrid.ColumnsCollection _detailColCollection;
        // フォーカス制御
        private FocusControl _focusControl1;
        private FocusControl _focusControl2;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 ADD
        // グリッド・カラムチューザー制御
        GridColumnChooserControl _gridColumnChooserControl;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 ADD

        // ----- ADD huangt 2013/05/27 Redmine#35729 ---------- >>>>> 
        // 藤木自動車オプション
        private bool _opFujikiCustom = false;
        // ----- ADD huangt 2013/05/27 Redmine#35729 ---------- <<<<<

        //----- ADD K2014/05/28 By 林超凡 Redmine#42764 受入テスト障害対応 BEGIN--------->>>>>
        /// <summary>東亜オプション情報</summary>
        private int _opt_Toua;
        /// <summary>車種メーカーコードクラムの名</summary>
        private const string CL_CARMAKERCODE_NAME = "MakerCode";

        //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する----->>>>>
        /// <summary>メイゴ㈱オプション情報</summary>
        private int _opt_Meigo;
        /// <summary>地区</summary>
        private const string SALESAREA_NAME = "SalesAreaName";
        /// <summary>分析コード1</summary>
        private const string CUSTANALYSCODE1_NAME = "CustAnalysCode1";
        /// <summary>分析コード2</summary>
        private const string CUSTANALYSCODE2_NAME = "CustAnalysCode2";
        /// <summary>分析コード3</summary>
        private const string CUSTANALYSCODE3_NAME = "CustAnalysCode3";
        /// <summary>分析コード4</summary>
        private const string CUSTANALYSCODE4_NAME = "CustAnalysCode4";
        /// <summary>分析コード5</summary>
        private const string CUSTANALYSCODE5_NAME = "CustAnalysCode5";
        /// <summary>分析コード6</summary>
        private const string CUSTANALYSCODE6_NAME = "CustAnalysCode6";
        //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する-----<<<<<

        /// <summary>設定XMLファイルパス</summary>
        private const string XML_FILE_PATH = "UISettings\\";
        /// <summary>
        /// オプション有効有無
        /// </summary>
        public enum Option : int
        {
            /// <summary>無効</summary>
            OFF = 0,
            /// <summary>有効</summary>
            ON = 1,
        }
        //----- ADD K2014/05/28 By 林超凡 Redmine#42764 受入テスト障害対応 END---------<<<<<

        // ---- ADD K2015/04/27 陳亮 モモセ部品の第二売価追加 ---->>>>>
        /// <summary>モモセ部品</summary>
        private int _opt_Momose;
        /// <summary>第二売価クラムの名</summary>
        private const string CL_SECONDSALEPRICE_NAME = "SecondSalePrice";
        // ---- ADD K2015/04/27 陳亮 モモセ部品の第二売価追加 ----<<<<<

        #endregion // プライベート変数

        #region プロパティ

        public CustPtrSalesUserConst UserSetting
        {
            get { return this._userSetting; }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
        /// <summary>
        /// 伝票グリッドカラム・コレクション 
        /// </summary>
        public Infragistics.Win.UltraWinGrid.ColumnsCollection SlipColCollection
        {
            get { return _slipColCollection; }
            set { _slipColCollection = value;}
        }
        /// <summary>
        /// 明細グリッドカラム・コレクション
        /// </summary>
        public Infragistics.Win.UltraWinGrid.ColumnsCollection DetailColCollection
        {
            get { return _detailColCollection; }
            set { _detailColCollection = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/27 ADD
        /// <summary>
        /// 区切り文字
        /// </summary>
        private int DividerChar
        {
            get
            {
                if ( rb_DividerChar_0.Checked )
                {
                    return 0;
                }
                else if ( rb_DividerChar_1.Checked )
                {
                    return 1;
                }
                else if ( rb_DividerChar_2.Checked )
                {
                    return 2;
                }
                else
                {
                    rb_DividerChar_0.Checked = true;
                    return 0;
                }
            }
            set
            {
                switch ( value )
                {
                    default:
                    case 0:
                        rb_DividerChar_0.Checked = true;
                        tEdit_DividerChar.Enabled = false;
                        break;
                    case 1:
                        rb_DividerChar_1.Checked = true;
                        tEdit_DividerChar.Enabled = true;
                        break;
                    case 2:
                        rb_DividerChar_2.Checked = true;
                        tEdit_DividerChar.Enabled = false;
                        break;
                }
            }
        }
        /// <summary>
        /// 括り文字
        /// </summary>
        private int Parenthesis
        {
            get
            {
                if ( rb_Parenthesis_0.Checked )
                {
                    return 0;
                }
                else if ( rb_Parenthesis_1.Checked )
                {
                    return 1;
                }
                else
                {
                    rb_Parenthesis_0.Checked = true;
                    return 0;
                }
            }
            set
            {
                switch ( value )
                {
                    default:
                    case 0:
                        rb_Parenthesis_0.Checked = true;
                        tEdit_ParenthesisChar.Enabled = false;
                        break;
                    case 1:
                        rb_Parenthesis_1.Checked = true;
                        tEdit_ParenthesisChar.Enabled = true;
                        break;
                }
            }
        }
        /// <summary>
        /// 数値括り
        /// </summary>
        private int TieNumeric
        {
            get
            {
                if ( rb_TieNumeric_0.Checked )
                {
                    return 0;
                }
                else if ( rb_TieNumeric_1.Checked )
                {
                    return 1;
                }
                else
                {
                    rb_TieNumeric_0.Checked = true;
                    return 0;
                }
            }
            set
            {
                switch ( value )
                {
                    default:
                    case 0:
                        rb_TieNumeric_0.Checked = true;
                        break;
                    case 1:
                        rb_TieNumeric_1.Checked = true;
                        break;
                }
            }
        }
        /// <summary>
        /// 文字括り
        /// </summary>
        private int TieChar
        {
            get
            {
                if ( rb_TieChar_0.Checked )
                {
                    return 0;
                }
                else if ( rb_TieChar_1.Checked )
                {
                    return 1;
                }
                else
                {
                    rb_TieChar_0.Checked = true;
                    return 0;
                }
            }
            set
            {
                switch ( value )
                {
                    default:
                    case 0:
                        rb_TieChar_0.Checked = true;
                        break;
                    case 1:
                        rb_TieChar_1.Checked = true;
                        break;
                }
            }
        }
        /// <summary>
        /// タイトル行
        /// </summary>
        private int TitleLine
        {
            get
            {
                if ( rb_TitleLine_0.Checked )
                {
                    return 0;
                }
                else if ( rb_TitleLine_1.Checked )
                {
                    return 1;
                }
                else
                {
                    rb_TitleLine_0.Checked = true;
                    return 0;
                }
            }
            set
            {
                switch ( value )
                {
                    default:
                    case 0:
                        rb_TitleLine_0.Checked = true;
                        break;
                    case 1:
                        rb_TitleLine_1.Checked = true;
                        break;
                }
            }
        }
        /// <summary>
        /// 備考１
        /// </summary>
        private int SlipNote
        {
            get
            {
                if ( rb_SlipNote_0.Checked )
                {
                    return 0;
                }
                else if ( rb_SlipNote_1.Checked )
                {
                    return 1;
                }
                else if ( rb_SlipNote_2.Checked )
                {
                    return 2;
                }
                // ---------ADD 2010/01/29--------->>>>>
                else if (rb_SlipNote_3.Checked)
                {
                    return 3;
                }
                // ---------ADD 2010/01/29---------<<<<<
                else
                {
                    rb_SlipNote_0.Checked = true;
                    return 0;
                }
            }
            set
            {
                switch ( value )
                {
                    default:
                    case 0:
                        rb_SlipNote_0.Checked = true;
                        break;
                    case 1:
                        rb_SlipNote_1.Checked = true;
                        break;
                    case 2:
                        rb_SlipNote_2.Checked = true;
                        break;
                    // ---------ADD 2010/01/29--------->>>>>
                    case 3:
                        rb_SlipNote_3.Checked = true;
                        break;
                    // ---------ADD 2010/01/29---------<<<<<
                }
            }
        }
        /// <summary>
        /// 備考２
        /// </summary>
        private int SlipNote2
        {
            get
            {
                if ( rb_SlipNote2_0.Checked )
                {
                    return 0;
                }
                else if ( rb_SlipNote2_1.Checked )
                {
                    return 1;
                }
                else if ( rb_SlipNote2_2.Checked )
                {
                    return 2;
                }
                // ---------ADD 2010/01/29--------->>>>>
                else if (rb_SlipNote2_3.Checked)
                {
                    return 3;
                }
                // ---------ADD 2010/01/29---------<<<<<
                else
                {
                    rb_SlipNote2_0.Checked = true;
                    return 0;
                }
            }
            set
            {
                switch ( value )
                {
                    default:
                    case 0:
                        rb_SlipNote2_0.Checked = true;
                        break;
                    case 1:
                        rb_SlipNote2_1.Checked = true;
                        break;
                    case 2:
                        rb_SlipNote2_2.Checked = true;
                        break;
                    // ---------ADD 2010/01/29--------->>>>>
                    case 3:
                        rb_SlipNote2_3.Checked = true;
                        break;
                    // ---------ADD 2010/01/29---------<<<<<
                }
            }
        }
        /// <summary>
        /// 備考３
        /// </summary>
        private int SlipNote3
        {
            get
            {
                if ( rb_SlipNote3_0.Checked )
                {
                    return 0;
                }
                else if ( rb_SlipNote3_1.Checked )
                {
                    return 1;
                }
                else if ( rb_SlipNote3_2.Checked )
                {
                    return 2;
                }
                // ---------ADD 2010/01/29--------->>>>>
                else if (rb_SlipNote3_3.Checked)
                {
                    return 3;
                }
                // ---------ADD 2010/01/29---------<<<<<
                else
                {
                    rb_SlipNote3_0.Checked = true;
                    return 0;
                }
            }
            set
            {
                switch ( value )
                {
                    default:
                    case 0:
                        rb_SlipNote3_0.Checked = true;
                        break;
                    case 1:
                        rb_SlipNote3_1.Checked = true;
                        break;
                    case 2:
                        rb_SlipNote3_2.Checked = true;
                        break;
                    // ---------ADD 2010/01/29--------->>>>>
                    case 3:
                        rb_SlipNote3_3.Checked = true;
                        break;
                    // ---------ADD 2010/01/29---------<<<<<
                }
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/27 ADD
        // ADD 2013/04/19 T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// 伝票印刷確認ダイアログ(赤伝発行)
        /// </summary>
        private bool RedPrintDialog
        {
            get
            {
                if (tComboEditor_RedPrintDialog.SelectedIndex == 0) //表示しない
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                switch (value)
                {
                    default:
                    case false:
                        tComboEditor_RedPrintDialog.SelectedIndex = 0; //表示しない
                        break;
                    case true:
                        tComboEditor_RedPrintDialog.SelectedIndex = 1; //表示する
                        break;
                }
            }
        }
        /// <summary>
        /// 伝票印刷確認ダイアログ(再発行)
        /// </summary>
        private bool ReisssuePrintDialog
        {
            get
            {
                if (tComboEditor_ReisssuePrintDialog.SelectedIndex == 0) //表示しない
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                switch (value)
                {
                    default:
                    case false:
                        tComboEditor_ReisssuePrintDialog.SelectedIndex = 0; //表示しない
                        break;
                    case true:
                        tComboEditor_ReisssuePrintDialog.SelectedIndex = 1; //表示する
                        break;
                }
            }
        }
        // ADD 2013/04/19 T.Miyamoto ------------------------------<<<<<
        //----- ADD　2018/09/04 譚洪　履歴自動表示の対応------>>>>>
        /// <summary>
        /// タブ制御の初期設定
        /// </summary>
        private int InitSelectDisplay
        {
            get
            {
                if (tComboEditor_InitSelectDisplay.SelectedIndex == 0) //残高照会初期表示
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            set
            {
                switch (value)
                {
                    default:
                    case 0:
                        tComboEditor_InitSelectDisplay.SelectedIndex = 0; //残高照会初期表示
                        break;
                    case 1:
                        tComboEditor_InitSelectDisplay.SelectedIndex = 1; //合計照会初期表示
                        break;
                }
            }
            //----- ADD　2018/09/04 譚洪　履歴自動表示の対応-------<<<<<
        }

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <br>Update Note : K2015/06/16 鮑晶</br>
        /// <br>管理番号    : 11101427-00</br>
        /// <br>            : メイゴ㈱得意先電子元帳「地区」と「分析コード」を追加する。</br>
        /// <br>Update Note : K2015/11/17  周健 </br>
        /// <br>管理番号    : 11170188-00  </br>
        /// <br>            : Redmine#47636　#6設定情報を更新しない場合、設定前のxmlファイルと比較値が変わっているの障害対応。</br>
        public PMKAU04004UA()
        {
            InitializeComponent();
            // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿対応　-------->>>>>
            #region ● 電子帳簿連携オプション(OPT-PM03300)
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus eBooksLinkOpt;
            eBooksLinkOpt = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_EBooks);
            if (eBooksLinkOpt == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_EBooksLink = (int)Option.ON;
            }
            else
            {
                this._opt_EBooksLink = (int)Option.OFF;
            }
            #endregion
            // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿対応　-------<<<<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
            this._dataSet = new CustPtrSalesDetailDataSet();

            //----- ADD K2015/11/17  周健　Redmine#47636　#6不具合の対応--------->>>>>
            #region 東亜商会オプション
            // 東亜商会個別オプションコードの追加
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus touaCustom;
            touaCustom = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_ToaCustom);
            if (touaCustom == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Toua = Convert.ToInt32(Option.ON);
            }
            else
            {
                this._opt_Toua = Convert.ToInt32(Option.OFF);
            }
            #endregion

            // モモセ部品㈱の個別オプションコードの追加
            #region モモセ部品オプション
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus momoseCustom;
            momoseCustom = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MomoseCustom);
            if (momoseCustom == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Momose = Convert.ToInt32(Option.ON);
            }
            else
            {
                this._opt_Momose = Convert.ToInt32(Option.OFF);
            }
            #endregion

            #region メイゴ㈱オプション
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus meigoCustom;
            meigoCustom = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MeigoLedgerCustom);
            if (meigoCustom == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Meigo = Convert.ToInt32(Option.ON);
            }
            else
            {
                this._opt_Meigo = Convert.ToInt32(Option.OFF);
            }
            #endregion
            //----- ADD K2015/11/17  周健　Redmine#47636　#6不具合の対応---------<<<<<


            // 伝票項目index
            int i = 0; //ADD K2015/11/17  周健　Redmine#47636　#6不具合の対応
            _columnIndexDicOfSlip = new Dictionary<string, int>();
            for ( int index = 0; index < _dataSet.SalesList.Columns.Count; index++ )
            {
                //_columnIndexDicOfSlip.Add(_dataSet.SalesList.Columns[index].ColumnName, index);//DEL K2015/11/17  周健　Redmine#47636　#6不具合の対応
                //----- ADD K2015/11/17  周健　Redmine#47636　#6不具合の対応--------->>>>>
                if (this._opt_Toua == Convert.ToInt32(Option.OFF) && _dataSet.SalesList.Columns[index].ColumnName == CL_CARMAKERCODE_NAME)
                {
                    continue;

                }

                if (_opt_Meigo == (Int32)Option.OFF)
                {

                    if (_dataSet.SalesList.Columns[index].ColumnName == SALESAREA_NAME || _dataSet.SalesList.Columns[index].ColumnName == CUSTANALYSCODE1_NAME || _dataSet.SalesList.Columns[index].ColumnName == CUSTANALYSCODE2_NAME || _dataSet.SalesList.Columns[index].ColumnName == CUSTANALYSCODE3_NAME ||
                         _dataSet.SalesList.Columns[index].ColumnName == CUSTANALYSCODE4_NAME || _dataSet.SalesList.Columns[index].ColumnName == CUSTANALYSCODE5_NAME || _dataSet.SalesList.Columns[index].ColumnName == CUSTANALYSCODE6_NAME)
                    {
                        continue;
                    }
                }
                
                _columnIndexDicOfSlip.Add( _dataSet.SalesList.Columns[index].ColumnName, i );
                i++;
                //----- ADD K2015/11/17  周健　Redmine#47636　#6不具合の対応---------<<<<<
            }

            // 明細項目index
            int ii = 0;//ADD K2015/11/17  周健　Redmine#47636　#6不具合の対応
            _columnIndexDicOfDetail = new Dictionary<string, int>();
            for ( int index = 0; index < _dataSet.SalesDetail.Columns.Count; index++ )
            {
                //_columnIndexDicOfDetail.Add(_dataSet.SalesDetail.Columns[index].ColumnName, index);//DEL K2015/11/17  周健　Redmine#47636　#6不具合の対応
                //----- ADD K2015/11/17  周健　Redmine#47636　#6不具合の対応--------->>>>>
                if (this._opt_Momose == Convert.ToInt32(Option.OFF) && _dataSet.SalesDetail.Columns[index].ColumnName == CL_SECONDSALEPRICE_NAME)
                {
                    continue;
                }
                if (_opt_Meigo == (Int32)Option.OFF)
                {

                    if (_dataSet.SalesDetail.Columns[index].ColumnName == SALESAREA_NAME || _dataSet.SalesDetail.Columns[index].ColumnName == CUSTANALYSCODE1_NAME || _dataSet.SalesDetail.Columns[index].ColumnName == CUSTANALYSCODE2_NAME || _dataSet.SalesDetail.Columns[index].ColumnName == CUSTANALYSCODE3_NAME ||
                         _dataSet.SalesDetail.Columns[index].ColumnName == CUSTANALYSCODE4_NAME || _dataSet.SalesDetail.Columns[index].ColumnName == CUSTANALYSCODE5_NAME || _dataSet.SalesDetail.Columns[index].ColumnName == CUSTANALYSCODE6_NAME)
                    {
                        continue;
                    }
                }
                
                _columnIndexDicOfDetail.Add( _dataSet.SalesDetail.Columns[index].ColumnName, ii );
                ii++;
                //----- ADD K2015/11/17  周健　Redmine#47636　#6不具合の対応---------<<<<<
            }

            this._userSetting = new CustPtrSalesUserConst();

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/27 ADD
            // フォーカス制御(テキスト出力設定タブ)
            _focusControl1 = new FocusControl();
            _focusControl1.AddLine( tComboEditor_OutputStyle );
            _focusControl1.AddLine( rb_DividerChar_0, rb_DividerChar_1, tEdit_DividerChar, rb_DividerChar_2 );
            _focusControl1.AddLine( rb_Parenthesis_0, rb_Parenthesis_1, tEdit_ParenthesisChar );
            _focusControl1.AddLine( rb_TieNumeric_0, rb_TieNumeric_1 );
            _focusControl1.AddLine( rb_TieChar_0, rb_TieChar_1 );
            _focusControl1.AddLine( rb_TitleLine_0, rb_TitleLine_1 );
            _focusControl1.AddLine( tComboEditor_OutputType );
            //add by liusy #35729 2013/05/20 -----<<<<<
            _focusControl1.AddLine( tComboEditor_DateType );
            //add by liusy #35729 2013/05/20 ----->>>>>

            _focusControl1.AddLine(uCheckEditor_RetSlipMinus_Saleslip); // ADD 2015/09/17 田建委 Redmine#47006
            _focusControl1.AddLine(uCheckEditor_RetSlipMinus_Meisai); // ADD 2015/09/17 田建委 Redmine#47006

            // フォーカス制御(赤伝設定タブ)
            _focusControl2 = new FocusControl();
            //_focusControl2.AddLine( rb_SlipNote_0, rb_SlipNote_1, rb_SlipNote_2 );// DEL 2010/01/29
            _focusControl2.AddLine(rb_SlipNote_0, rb_SlipNote_1, rb_SlipNote_2, rb_SlipNote_3);// ADD 2010/01/29
            _focusControl2.AddLine( tEdit_SlipNote );
            //_focusControl2.AddLine( rb_SlipNote2_0, rb_SlipNote2_1, rb_SlipNote2_2 );// DEL 2010/01/29
            _focusControl2.AddLine(rb_SlipNote2_0, rb_SlipNote2_1, rb_SlipNote2_2, rb_SlipNote2_3);// ADD 2010/01/29
            _focusControl2.AddLine( tEdit_SlipNote2 );
            //_focusControl2.AddLine( rb_SlipNote3_0, rb_SlipNote3_1, rb_SlipNote3_2 );// DEL 2010/01/29
            _focusControl2.AddLine(rb_SlipNote3_0, rb_SlipNote3_1, rb_SlipNote3_2, rb_SlipNote3_3);// ADD 2010/01/29
            _focusControl2.AddLine( tEdit_SlipNote3 );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/27 ADD
            // ADD 2013/04/19 T.Miyamoto ------------------------------>>>>>
            _focusControl2.AddLine(tComboEditor_RedPrintDialog);
            _focusControl2.AddLine(tComboEditor_ReisssuePrintDialog);
            // ADD 2013/04/19 T.Miyamoto ------------------------------<<<<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 ADD
            _gridColumnChooserControl = new GridColumnChooserControl();
            _gridColumnChooserControl.Add( uGrid_ColumnItemSelector );
            _gridColumnChooserControl.Add( uGrid_ColumnItemSelector2 );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 ADD

            // ----- ADD huangt 2013/05/27 Redmine#35729 ---------- >>>>>
            // 藤木自動車オプションの判定
            this._opFujikiCustom = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FujikiCustom) > 0);
            // ----- ADD huangt 2013/05/27 Redmine#35729 ---------- <<<<<

           // ----- DEL K2015/11/17  周健　Redmine#47636　#6不具合の対応--------->>>>>
           // //----- ADD K2014/05/28 By 林超凡 Redmine#42764 受入テスト障害対応 BEGIN--------->>>>>
           // #region 東亜商会オプション
           // // 東亜商会個別オプションコードの追加
           // Broadleaf.Application.Remoting.ParamData.PurchaseStatus touaCustom;
           // touaCustom = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_ToaCustom);
           // if (touaCustom == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
           // {
           //     this._opt_Toua = Convert.ToInt32(Option.ON);
           // }
           // else
           // {
           //     this._opt_Toua = Convert.ToInt32(Option.OFF);
           // }
           // #endregion
           // //----- ADD K2014/05/28 By 林超凡 Redmine#42764 受入テスト障害対応 END---------<<<<<

           //// ---- ADD K2015/04/29 陳亮 テキスト出力項目に第二売価を追加する ---->>>>>
           // // モモセ部品㈱の個別オプションコードの追加
           // #region モモセ部品オプション
           // Broadleaf.Application.Remoting.ParamData.PurchaseStatus momoseCustom;
           // momoseCustom = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MomoseCustom);
           // if (momoseCustom == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
           // {
           //     this._opt_Momose = Convert.ToInt32(Option.ON);
           // }
           // else
           // {
           //     this._opt_Momose = Convert.ToInt32(Option.OFF);
           // }
           // #endregion
           // // ---- ADD K2015/04/29 BY 陳亮 テキスト出力項目に第二売価を追加する ----<<<<<

           // //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する----->>>>>
           // #region メイゴ㈱オプション
           // Broadleaf.Application.Remoting.ParamData.PurchaseStatus meigoCustom;
           // meigoCustom = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MeigoLedgerCustom);
           // if (meigoCustom == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
           // {
           //     this._opt_Meigo = Convert.ToInt32(Option.ON);
           // }
           // else
           // {
           //     this._opt_Meigo = Convert.ToInt32(Option.OFF);
           // }
           // #endregion
           // //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する-----<<<<<
           // ----- DEL K2015/11/17  周健　Redmine#47636　#6不具合の対応---------<<<<<
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
        /// <summary>
        /// 伝票項目index取得処理
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        private int GetColumnPositionOfSlip( string[] patterns, string columnName )
        {
            if ( _columnIndexDicOfSlip.ContainsKey( columnName ) )
            {
                try
                {
                    return Int32.Parse( patterns[_columnIndexDicOfSlip[columnName]].ToString() );
                }
                catch
                {
                    return _columnIndexDicOfSlip.Count + 1;
                }
            }
            else
            {
                return _columnIndexDicOfSlip.Count + 1;
            }
        }
        /// <summary>
        /// 明細項目index取得処理
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        private int GetColumnPositionOfDetail( string[] patterns, string columnName )
        {
            if ( _columnIndexDicOfDetail.ContainsKey( columnName ) )
            {
                try
                {
                    return Int32.Parse( patterns[_columnIndexDicOfDetail[columnName]].ToString() );
                }
                catch
                {
                    return _columnIndexDicOfDetail.Count + 1;
                }
            }
            else
            {
                return _columnIndexDicOfDetail.Count + 1;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD

        /// <summary>
        /// 画面起動時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note: K2015/11/17  周健</br>
        /// <br>           : 得意先電子元帳  Redmine#47636　#6不具合の対応</br>
        /// <br>           : 設定情報を更新しない場合、設定前のxmlファイルと比較値が変わっているの障害対応</br>
        /// <br>Update Note: 2018/09/04 譚洪</br>
        /// <br>管理番号   : 11470152-00</br>
        /// <br>           : 履歴自動表示機能追加対応</br>
        private void PMKAU04004UA_Load(object sender, EventArgs e)
        {
            // 画面設定
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
            //this._dataSet = new ExportColumnDataSet();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
            //----- ADD K2015/11/17  周健　Redmine#47636　#6不具合の対応--------->>>>>
            if (this._opt_Toua == Convert.ToInt32(Option.OFF) && this._dataSet.SalesList.Columns.Contains(CL_CARMAKERCODE_NAME))
            {
                this._dataSet.SalesList.Columns.Remove(CL_CARMAKERCODE_NAME);
            }

            // 第二売価コードを削除します
            if (this._opt_Momose == Convert.ToInt32(Option.OFF) && this._dataSet.SalesDetail.Columns.Contains(CL_SECONDSALEPRICE_NAME))
            {
                this._dataSet.SalesDetail.Columns.Remove(CL_SECONDSALEPRICE_NAME);
            }

            if (this._opt_Meigo == Convert.ToInt32(Option.OFF) && this._dataSet.SalesList.Columns.Contains(SALESAREA_NAME))
            {
                #region 伝票表示
                this._dataSet.SalesList.Columns.Remove(SALESAREA_NAME);          //地区
                this._dataSet.SalesList.Columns.Remove(CUSTANALYSCODE1_NAME);    //分析コード1
                this._dataSet.SalesList.Columns.Remove(CUSTANALYSCODE2_NAME);    //分析コード2
                this._dataSet.SalesList.Columns.Remove(CUSTANALYSCODE3_NAME);    //分析コード3
                this._dataSet.SalesList.Columns.Remove(CUSTANALYSCODE4_NAME);    //分析コード4
                this._dataSet.SalesList.Columns.Remove(CUSTANALYSCODE5_NAME);    //分析コード5
                this._dataSet.SalesList.Columns.Remove(CUSTANALYSCODE6_NAME);    //分析コード6
                #endregion

                #region 明細表示
                this._dataSet.SalesDetail.Columns.Remove(SALESAREA_NAME);        //地区
                this._dataSet.SalesDetail.Columns.Remove(CUSTANALYSCODE1_NAME);  //分析コード1 
                this._dataSet.SalesDetail.Columns.Remove(CUSTANALYSCODE2_NAME);  //分析コード2
                this._dataSet.SalesDetail.Columns.Remove(CUSTANALYSCODE3_NAME);  //分析コード3
                this._dataSet.SalesDetail.Columns.Remove(CUSTANALYSCODE4_NAME);  //分析コード4
                this._dataSet.SalesDetail.Columns.Remove(CUSTANALYSCODE5_NAME);  //分析コード5
                this._dataSet.SalesDetail.Columns.Remove(CUSTANALYSCODE6_NAME);  //分析コード6
                #endregion
            }
            //----- ADD K2015/11/17  周健　Redmine#47636　#6不具合の対応---------<<<<<
            // グリッド毎に使用するデータビューを作成
            DataView dViewSlip = new DataView( this._dataSet.SalesList );
            DataView dViewDetail = new DataView( this._dataSet.SalesDetail );


            // データソースとしてデータビューを指定
            this.uGrid_ColumnItemSelector.DataSource = dViewSlip;
            this.uGrid_ColumnItemSelector2.DataSource = dViewDetail;

            // 設定値があればロード
            this._userSetting = new CustPtrSalesUserConst();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/15 ADD
            InitializeUserSetting( ref _userSetting );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/15 ADD
            this.Deserialize();

            // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿対応　-------->>>>>
            // 電子帳簿連携タブ初期化設定
            InitEBooksLinkSetting();
            // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿対応　-------<<<<<

            // パターン・区切り文字・設定名を取得
            if (this._userSetting != null)
            {
                this._outputPattern = this._userSetting.OutputPattern;
                this._divider = this._userSetting.DIVIDER;
                this._selectedPattern = this._userSetting.SelectedPatternName;
            }

            // カラム
            InitializeGridColumns(this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns, 0);
            InitializeGridColumns(this.uGrid_ColumnItemSelector2.DisplayLayout.Bands[0].Columns, 1);

            // ボタン設定
            this.uButton_FileSelect.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
            this.uButton_FileSelect.Appearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;

            // 2010/04/15 Add >>>
            this.uButton_ClaimeFileName.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
            this.uButton_ClaimeFileName.Appearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;

            this.uButton_ChargeFileName.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
            this.uButton_ChargeFileName.Appearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;
            // 2010/04/15 Add <<<

            // 基本パターン名作成
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
            //string tempName = string.Empty;
            //createPatternStringNonCustom(0, out tempName, true);
            //createPatternStringNonCustom(1, out tempName, true);
            //createPatternStringNonCustom(2, out tempName, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
            if ( _userSetting == null ||
                _userSetting.OutputPattern == null ||
                _userSetting.OutputPattern.Length == 0 )
            {
                string tempName = string.Empty;
                createPatternStringNonCustom( 0, out tempName, true );
                createPatternStringNonCustom( 1, out tempName, true );
                createPatternStringNonCustom( 2, out tempName, true );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD

            // --- DEL 2020/12/21 警告対応 ---------->>>>>
            //this._outputStyle = 0;// 初期設定
            // --- DEL 2020/12/21 警告対応 ----------<<<<<

            // 画面の初期値をセット
            setInitialValue();

            // 画面の初期設定
            this.tComboEditor_OutputType_ValueChanged( null, null );
            //add by liusy #35729 2013/05/20 -----<<<<<
            this.tComboEditor_DateType_ValueChanged(null, null);
            //add by liusy #35729 2013/05/20 ----->>>>>
            this.tComboEditor_OutputStyle_ValueChanged( null, null );

            // -------------ADD 2009/12/28------------>>>>>
            //明細制御
            this.tComboEditor_AllowRowFiltering.SelectedIndex = _userSetting.AllowRowFiltering;
            this.tComboEditor_AllowColSwapping.SelectedIndex = _userSetting.AllowColSwapping;
            this.tComboEditor_FixedHeaderIndicator.SelectedIndex = _userSetting.FixedHeaderIndicator;
            // -------------ADD 2009/12/28------------<<<<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
            // ValueChangedイベントで書き変わったファイル名を戻す
            tEdit_SettingFileName.Text = _userSetting.OutputFileName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD

            //----- ADD 2015/02/25 王亜楠 Redmine#44701 No.1 -------------------->>>>>
            uCheckEditor_NoCountCtrl.CheckedChanged -= new System.EventHandler(this.uCheckEditor_NoCountCtrl_CheckedChanged);
            if (_userSetting.SearchCountCtrl == 1)
            {
                this.uCheckEditor_NoCountCtrl.Checked = true;
            }
            else
            {
                this.uCheckEditor_NoCountCtrl.Checked = false;
            }
            uCheckEditor_NoCountCtrl.CheckedChanged += new System.EventHandler(this.uCheckEditor_NoCountCtrl_CheckedChanged);
            //----- ADD 2015/02/25 王亜楠 Redmine#44701 No.1 --------------------<<<<<

            // 2010/04/15 Add >>>
            tEdit_ClaimeFileName.Text = _userSetting.ClaimeFileName;
            tEdit_ChargeFileName.Text = _userSetting.ChargeFileName;
            // 2010/04/15 Add <<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 ADD
            //表示更新

            // 区切り文字任意
            if ( prevDividerChar == 1 )
            {
                this.tEdit_DividerChar.Enabled = true;
            }
            else
            {
                this.tEdit_DividerChar.Enabled = false;
                this.tEdit_DividerChar.Clear();
            }
            // 括り文字任意
            if ( prevParenthesis == 1 )
            {
                this.tEdit_ParenthesisChar.Enabled = true;
            }
            else
            {
                this.tEdit_ParenthesisChar.Enabled = false;
                this.tEdit_ParenthesisChar.Clear();
            }
            // 赤伝備考１
            //if ( this.SlipNote == 2 )// DEL 2010/01/29
            if (this.SlipNote == 3)// ADD 2010/01/29
            {
                this.tEdit_SlipNote.Enabled = true;
            }
            else
            {
                this.tEdit_SlipNote.Enabled = false;
                this.tEdit_SlipNote.Clear();
            }
            // 赤伝備考２
            //if ( this.SlipNote2 == 2 )// DEL 2010/01/29
            if (this.SlipNote2 == 3)// ADD 2010/01/29
            {
                this.tEdit_SlipNote2.Enabled = true;
            }
            else
            {
                this.tEdit_SlipNote2.Enabled = false;
                this.tEdit_SlipNote2.Clear();
            }
            // 赤伝備考３
            //if (this.SlipNote3 == 2)// DEL 2010/01/29
            if (this.SlipNote3 == 3)// ADD 2010/01/29
            {
                this.tEdit_SlipNote3.Enabled = true;
            }
            else
            {
                this.tEdit_SlipNote3.Enabled = false;
                this.tEdit_SlipNote3.Clear();
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 ADD
            // ADD 2013/04/19 T.Miyamoto ------------------------------>>>>>
            // 伝票印刷確認ダイアログ(赤伝発行)
            this.tComboEditor_RedPrintDialog.SelectedIndex = (_userSetting.RedPrintDialog) ? 1 : 0;
            // 伝票印刷確認ダイアログ(再発行)
            this.tComboEditor_ReisssuePrintDialog.SelectedIndex = (_userSetting.ReisssuePrintDialog) ? 1 : 0;
            // ADD 2013/04/19 T.Miyamoto ------------------------------<<<<<

            // ----- ADD huangt 2013/05/27 Redmine#35729 ---------- >>>>> 
            // 藤木自動車オプション無しの場合
            if (!this._opFujikiCustom)
            {
                // 元号表示区分項目は非表示
                this.ultraLabel44.Visible = false;
                this.tComboEditor_DateType.Visible = false;
                this.tComboEditor_DateType.Enabled = false; // ADD 2015/09/17 田建委 Redmine#47006
            }
            // ----- ADD huangt 2013/05/27 Redmine#35729 ---------- <<<<<
            this.tComboEditor_InitSelectDisplay.SelectedIndex = _userSetting.InitSelectDisplay;// 2018/09/04 譚洪　履歴自動表示の対応
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/15 ADD
        /// <summary>
        /// ユーザー設定初期化処理
        /// </summary>
        /// <param name="_userSetting"></param>
        private void InitializeUserSetting( ref CustPtrSalesUserConst userSetting )
        {
            userSetting = new CustPtrSalesUserConst();
            InitializeSlipGrid( ref userSetting );
            InitializeDetailGrid( ref userSetting );
            InitializeRedSlipGrid( ref userSetting );
            InitializeBalanceGrid( ref userSetting );
        }
        /// <summary>
        /// ユーザー設定初期化（伝票表示）
        /// </summary>
        /// <param name="userSetting"></param>
        private void InitializeSlipGrid( ref CustPtrSalesUserConst userSetting )
        {
            userSetting.SlipColumnsList = new List<ColumnInfo>();
            userSetting.AutoAdjustSlip = false;
        }
        /// <summary>
        /// ユーザー設定初期化（明細表示）
        /// </summary>
        /// <param name="userSetting"></param>
        private void InitializeDetailGrid( ref CustPtrSalesUserConst userSetting )
        {
            userSetting.DetailColumnsList = new List<ColumnInfo>();
            userSetting.AutoAdjustDetail = false;
        }
        /// <summary>
        /// ユーザー設定初期化（赤伝発行入力の明細表示）
        /// </summary>
        /// <param name="userSetting"></param>
        private void InitializeRedSlipGrid( ref CustPtrSalesUserConst userSetting )
        {
            userSetting.RedSlipColumnsList = new List<ColumnInfo>();
            userSetting.AutoAdjustRedSlip = false;
            // ADD 2013/04/19 T.Miyamoto ------------------------------>>>>>
            userSetting.RedPrintDialog = false;
            userSetting.ReisssuePrintDialog = false;
            // ADD 2013/04/19 T.Miyamoto ------------------------------<<<<<
        }
        /// <summary>
        /// ユーザー設定初期化（残高一覧表示）
        /// </summary>
        /// <param name="userSetting"></param>
        private void InitializeBalanceGrid( ref CustPtrSalesUserConst userSetting )
        {
            userSetting.BalanceColumnsList = new List<ColumnInfo>();
            userSetting.AutoAdjustBalance = false;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/15 ADD

        #endregion // コンストラクタ

        #region プライベート関数

        /// <summary>
        /// 画面の初期値を設定
        /// </summary>
        private void setInitialValue()
        {
            // 設定値があればそれを設置
            if ( this._outputPattern == null )
            {
                this.tEdit_DividerChar.Clear();
                this.tEdit_ParenthesisChar.Clear();
                this.tEdit_SettingFileName.Clear();
                this.tComboEditor_PetternSelect.Text = string.Empty;

                this.tComboEditor_OutputType.SelectedIndex = 0;
                //add by liusy #35729 2013/05/20 -----<<<<<
                this.tComboEditor_DateType.SelectedIndex = 0;
                //add by liusy #35729 2013/05/20 ----->>>>>
                this.tComboEditor_OutputStyle.SelectedIndex = 0;

                //this.uOptionSet_SlipNote.CheckedIndex = 0;
                //this.uOptionSet_SlipNote2.CheckedIndex = 0;
                //this.uOptionSet_SlipNote3.CheckedIndex = 1;
                this.SlipNote = 0;
                this.SlipNote2 = 0;
                this.SlipNote3 = 1;
            }
            else
            {
                string pName = string.Empty;
                string[] patternValue = new string[9];

                // パターンの構成
                // 区切り文字(タブ・任意・固定長）/区切り文字任意/  0-1
                // 括り文字(”・任意）/括り文字任意/                2-3
                // 数値括り（する／しない)                          4
                // 文字括り（する／しない)                          5
                // タイトル行（あり／なし）                         6
                // 伝票出力項目リスト (32項目x2文字) 基本的に表示順の数字,非表示の場合は99, 必ずExportColumnDataSet.SalesListの順に並んでいる   7
                // 明細出力項目リスト (57項目x2文字) 基本的に表示順の数字,非表示の場合は99, 必ずExportColumnDataSet.SalesDetailの順に並んでいる 8
                // パターン形式(.CSV/.TXT/.PRN/カスタム)            9

                if ( String.IsNullOrEmpty( this._selectedPattern ) )
                {
                    this._selectedPattern = "テキスト出力パターン1";
                }

                // 取得したパターンを分解し、パターン名のリストを作成
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                this.tComboEditor_PetternSelect.Items.Clear();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                Infragistics.Win.ValueListItem item;
                foreach ( string pattern in this._outputPattern )
                {
                    item = new Infragistics.Win.ValueListItem();

                    // 最初の区切り文字までがパターン名
                    if ( pattern.Contains( this._divider ) )
                    {
                        pName = pattern.Substring( 0, pattern.IndexOf( this._divider ) );
                        item.DataValue = pName;
                        item.DisplayText = pName;

                        this.tComboEditor_PetternSelect.Items.Add( item );

                        // 設定されているパターンの場合は内容を取得
                        if ( pName == this._selectedPattern )
                        {
                            getPatternValue( pattern.Substring( pattern.IndexOf( this._divider ) + 1 ), out patternValue );
                        }
                    }
                }

                // 取得が終わったら、画面を設定する

                // ファイル名
                this.tEdit_SettingFileName.Text = this._userSetting.OutputFileName;

                //----- ADD 2015/02/25 王亜楠 Redmine#44701 No.1 -------------------->>>>>
                uCheckEditor_NoCountCtrl.CheckedChanged -= new System.EventHandler(this.uCheckEditor_NoCountCtrl_CheckedChanged);
                if (_userSetting.SearchCountCtrl == 1)
                {
                    this.uCheckEditor_NoCountCtrl.Checked = true;
                }
                else
                {
                    this.uCheckEditor_NoCountCtrl.Checked = false;
                }
                uCheckEditor_NoCountCtrl.CheckedChanged += new System.EventHandler(this.uCheckEditor_NoCountCtrl_CheckedChanged);
                //----- ADD 2015/02/25 王亜楠 Redmine#44701 No.1 --------------------<<<<<

                // パターン名
                this.tComboEditor_PetternSelect.Text = this._selectedPattern;

                // ＵＩ表示
                SetDisplayFromPattern( patternValue );
            }
        }

        /// <summary>
        /// パターンの内容を分解
        /// </summary>
        /// <param name="pBody"></param>
        /// <param name="pValue"></param>
        /// <remarks>
        /// <br>Update Note: 2015/09/17 田建委</br>
        /// <br>管理番号   : 11170170-00</br>
        /// <br>           : Redmine#47006 現行保障をするため画面に区分を設ける</br>
        /// </remarks>
        private void getPatternValue(string pBody, out string[] pValue)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
            //pValue = new string[10];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
            //const int ct_ItemCount = 11;   del by liusy #35729 2013/05/20
            //const int ct_ItemCount = 12; //add by liusy #35729 2013/05/20 // DEL 2015/09/17 田建委 Redmine#47006

            const int ct_ItemCount = 14; // ADD 2015/09/17 田建委 Redmine#47006

            pValue = new string[ct_ItemCount];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD

            string str1 = pBody;
            string str2 = string.Empty;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
            //for (int i=0; i < 10; i++)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
            for ( int i = 0; i < ct_ItemCount; i++ )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
            {
                // DEL 2015/09/17 田建委 Redmine#47006 ---------- >>>>>
                // ----- ADD huangt 2013/05/27 Redmine#35729 ---------- >>>>>
                //if (i == 11 && this._opFujikiCustom == false)
                //{
                //    str1 = "0";
                //    continue;
                //}
                // ----- ADD huangt 2013/05/27 Redmine#35729 ---------- <<<<<
                // DEL 2015/09/17 田建委 Redmine#47006 ---------- <<<<<

                if (str1.Contains(this._divider))
                {
                    pValue[i] = str1.Substring(0, str1.IndexOf(this._divider));
                }
                else
                {

                    pValue[i] = str1.Substring(0);

                    // ----- DEL 2015/09/17 田建委 Redmine#47006 ----->>>>>
                    //add by liusy #35729 2013/05/20 -----<<<<<
                    //if (str1.Length == 1)
                    //{
                    //    str1 = "0";
                    //    continue;
                    //}
                    //add by liusy #35729 2013/05/20 ----->>>>>
                    // ----- DEL 2015/09/17 田建委 Redmine#47006 -----<<<<<

                    // ----- ADD 2015/09/17 田建委 Redmine#47006 ----->>>>>
                    // 既存XMLのパターンの内容は11つ項目の場合、新しい項目の内容を追加します。
                    if (i == 10)
                    {
                        // 既存の項目「元号表示区分」の場合、「0」を設定します。
                        pValue[11] = "0";
                        // 「返品伝票金額をマイナスで出力する」の場合、オフを設定します。
                        pValue[12] = "0";
                        // 「マイナス金額にはマイナス記号を付与する」の場合、オンを設定します。
                        pValue[13] = "1";
                        break;
                    }
                    // 既存XMLのパターンの内容は12つ項目の場合、新しい項目の内容を追加します。
                    else if (i == 11)
                    {
                        // 「返品伝票金額をマイナスで出力する」の場合、オフを設定します。
                        pValue[12] = "0";
                        // 「マイナス金額にはマイナス記号を付与する」の場合、オンを設定します。
                        pValue[13] = "1";
                        break;
                    }
                    // ----- ADD 2015/09/17 田建委 Redmine#47006 -----<<<<<
                }
                str2 = str1.Substring(str1.IndexOf(this._divider) + 1);
                str1 = str2;
            }
        }

        /// <summary>
        /// グリッドのセッティングを文字列から取り出す
        /// </summary>
        /// <param name="patternStr"></param>
        /// <param name="gridSetting"></param>
        /// <param name="isSlip"></param>
        private void getGridSettingPattern(string patternStr, out string[] gridSetting, bool isSlip)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
            //if (isSlip)
            //{
            //    gridSetting = new string[32];

            //    for (int i = 0; i < 32; i++)
            //    {
            //        gridSetting[i] = patternStr.Substring(i * 3, 3);
            //    }
            //}
            //else
            //{
            //    gridSetting = new string[57];
                
            //    for (int i = 0; i < 57; i++)
            //    {
            //        gridSetting[i] = patternStr.Substring(i * 3, 3);
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.27 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
            //int count = patternStr.Length / 3;
            //gridSetting = new string[count];

            //for ( int i = 0; i < count; i++ )
            //{
            //    gridSetting[i] = patternStr.Substring( i * 3, 3 );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.27 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.27 ADD
            int count = patternStr.Length / (ct_ColumnCountLength + 1);
            gridSetting = new string[count];

            for ( int i = 0; i < count; i++ )
            {
                gridSetting[i] = patternStr.Substring( i * (ct_ColumnCountLength + 1), (ct_ColumnCountLength + 1) );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.27 ADD
        }

        /// <summary>
        /// 選択されたパターンを適用
        /// </summary>
        private void getSelectedPattern()
        {

            string pName = string.Empty;
            string[] patternValue = new string[9];

            // パターンの構成
            // 区切り文字(タブ・任意・固定長）/区切り文字任意/  0-1
            // 括り文字(”・任意）/括り文字任意/                2-3
            // 数値括り（する／しない)                          4
            // 文字括り（する／しない)                          5
            // タイトル行（あり／なし）                         6
            // 伝票出力項目リスト (32項目x3文字) 基本的に表示順の数字,非表示の場合は+100, 必ずExportColumnDataSet.SalesListの順に並んでいる   7
            // 明細出力項目リスト (57項目x3文字) 基本的に表示順の数字,非表示の場合は+100, 必ずExportColumnDataSet.SalesDetailの順に並んでいる 8
            // パターン形式(.CSV/.TXT/.PRN/カスタム)            9

            // 取得したパターンを分解し、パターン名のリストを作成
            // --- DEL 2020/12/21 警告対応 ---------->>>>>
            //int counter = 0;
            // --- DEL 2020/12/21 警告対応 ----------<<<<<
            foreach (string pattern in this._outputPattern)
            {
                // 最初の区切り文字までがパターン名
                if (pattern.Contains(this._divider))
                {
                    pName = pattern.Substring(0, pattern.IndexOf(this._divider));

                    // 設定されているパターンの場合は内容を取得
                    if (pName == this._selectedPattern)
                    {
                        getPatternValue(pattern.Substring(pattern.IndexOf(this._divider) + 1), out patternValue);
                        break;
                    }
                }
            }

            // 取得が終わったら、画面を設定する

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
            //// ファイル名
            //this.tEdit_SettingFileName.Text = this._userSetting.OutputFileName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL

            // パターン名
            this.tComboEditor_PetternSelect.Text = this._selectedPattern;

            // ＵＩ表示
            SetDisplayFromPattern( patternValue );
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/27 ADD
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patternValue"></param>
        /// <remarks>
        /// <br>Update Note: 2015/09/17 田建委</br>
        /// <br>管理番号   : 11170170-00</br>
        /// <br>           : Redmine#47006 現行保障をするため画面に区分を設ける</br>
        /// </remarks>
        private void SetDisplayFromPattern( string[] patternValue )
        {
            try
            {
                // 出力形式
                //this.uComboEditor_OutputStyle.Text = "カスタム";
                this.tComboEditor_OutputStyle.SelectedIndex = Int32.Parse( patternValue[9].ToString() );

                // 区切り文字
                //this.uOptionSet_DividerChar.CheckedIndex = Int32.Parse( patternValue[0].ToString() );
                this.DividerChar = Int32.Parse( patternValue[0].ToString() );
                prevDividerChar = this.DividerChar;
                // 区切り文字任意
                this.tEdit_DividerChar.Text = patternValue[1].ToString();
                if ( prevDividerChar == 1 )
                {
                    this.tEdit_DividerChar.Enabled = true;
                }
                else
                {
                    this.tEdit_DividerChar.Enabled = false;
                    this.tEdit_DividerChar.Clear();
                }

                // 括り文字
                //this.uOptionSet_Parenthesis.CheckedIndex = Int32.Parse( patternValue[2].ToString() );
                this.Parenthesis = Int32.Parse( patternValue[2].ToString() );
                prevParenthesis = this.Parenthesis;
                // 括り文字任意
                this.tEdit_ParenthesisChar.Text = patternValue[3].ToString();
                if ( prevParenthesis == 1 )
                {
                    this.tEdit_ParenthesisChar.Enabled = true;
                }
                else
                {
                    this.tEdit_ParenthesisChar.Enabled = false;
                    this.tEdit_ParenthesisChar.Clear();
                }

                // 数値括り
                //this.uOptionSet_TieNumeric.CheckedIndex = Int32.Parse( patternValue[4].ToString() );
                this.TieNumeric = Int32.Parse( patternValue[4].ToString() );
                prevTieNumeric = this.TieNumeric;
                // 文字括り
                //this.uOptionSet_TieChar.CheckedIndex = Int32.Parse( patternValue[5].ToString() );
                this.TieChar = Int32.Parse( patternValue[5].ToString() );
                prevTieChar = this.TieChar;

                // タイトル行
                //this.uOptionSet_TitleLine.CheckedIndex = Int32.Parse( patternValue[6].ToString() );
                this.TitleLine = Int32.Parse( patternValue[6].ToString() );
                prevTitleLine = this.TitleLine;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                // グリッド選択	
                this.tComboEditor_OutputType.SelectedIndex = Int32.Parse( patternValue[10].ToString() );
                // --- UPD 2014/02/05 T.Miyamoto ------------------------------>>>>>
                ////add by liusy #35729 2013/05/20 -----<<<<<
                //this.tComboEditor_DateType.SelectedIndex = Int32.Parse(patternValue[11].ToString());
                ////add by liusy #35729 2013/05/20 ----->>>>>
                if (this._opFujikiCustom)
                {
                    this.tComboEditor_DateType.SelectedIndex = Int32.Parse(patternValue[11].ToString());
                }
                // --- UPD 2014/02/05 T.Miyamoto ------------------------------<<<<<
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD

                //----- ADD 2015/09/17 田建委 Redmine#47006 ---------->>>>>
                // 「返品伝票金額をマイナスで出力する」チェックオンの場合、
                if (patternValue[12] == "1")
                {
                    this.uCheckEditor_RetSlipMinus_Saleslip.Checked = true;
                }
                else
                {
                    this.uCheckEditor_RetSlipMinus_Saleslip.Checked = false;
                }

                // 「マイナス金額にはマイナス記号を付与する」チェックオンの場合、
                if (patternValue[13] == "1")
                {
                    this.uCheckEditor_RetSlipMinus_Meisai.Checked = true;
                }
                else
                {
                    this.uCheckEditor_RetSlipMinus_Meisai.Checked = false;
                }
                //----- ADD 2015/09/17 田建委 Redmine#47006 ----------<<<<<

                // グリッド
                this._gridSetting_Slip = patternValue[7].ToString();
                this._gridSetting_Detail = patternValue[8].ToString();

                // カラム設定
                InitializeGridColumns( this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns, 0 );
                InitializeGridColumns( this.uGrid_ColumnItemSelector2.DisplayLayout.Bands[0].Columns, 1 );
            }
            catch
            {
            }

            try
            {
                // 赤伝設定
                //this.uOptionSet_SlipNote.CheckedIndex = this._userSetting.SlipNote1Pattern;
                this.SlipNote = this._userSetting.SlipNote1Pattern;
                prevSlipNote = this.SlipNote;
                this.tEdit_SlipNote.Text = this._userSetting.SlipNote1Default;
                //if ( this.SlipNote == 2 )// DEL 2010/01/29
                if (this.SlipNote == 3)// ADD 2010/01/29
                {
                    this.tEdit_SlipNote.Enabled = true;
                }
                else
                {
                    this.tEdit_SlipNote.Enabled = false;
                    this.tEdit_SlipNote.Clear();
                }
                //this.uOptionSet_SlipNote2.CheckedIndex = this._userSetting.SlipNote2Pattern;
                this.SlipNote2 = this._userSetting.SlipNote2Pattern;
                prevSlipNote2 = this.SlipNote2;
                this.tEdit_SlipNote2.Text = this._userSetting.SlipNote2Default;
                //if ( this.SlipNote2 == 2 )// DEL 2010/01/29
                if (this.SlipNote2 == 3)// ADD 2010/01/29
                {
                    this.tEdit_SlipNote2.Enabled = true;
                }
                else
                {
                    this.tEdit_SlipNote2.Enabled = false;
                    this.tEdit_SlipNote2.Clear();
                }
                //this.uOptionSet_SlipNote3.CheckedIndex = this._userSetting.SlipNote3Pattern;
                this.SlipNote3 = this._userSetting.SlipNote3Pattern;
                prevSlipNote3 = this.SlipNote3;
                this.tEdit_SlipNote3.Text = this._userSetting.SlipNote3Default;
                //if ( this.SlipNote3 == 2 )// DEL 2010/01/29
                if (this.SlipNote3 == 3)// ADD 2010/01/29
                {
                    this.tEdit_SlipNote3.Enabled = true;
                }
                else
                {
                    this.tEdit_SlipNote3.Enabled = false;
                    this.tEdit_SlipNote3.Clear();
                }
            }
            catch
            {
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/27 ADD

        /// <summary>
        /// データグリッドセット
        /// </summary>
        /// <param name="Columns"></param>
        /// <param name="tabNo"></param>
        private void InitializeGridColumns(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns, int tabNo)
        {
            // 表示位置初期値
            int visiblePosition = 1;

            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //非表示設定
                column.Hidden = true;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                column.ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                //column.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL

                column.AutoEdit = false;
                column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }


            switch (tabNo)
            {
                case 0:
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                        # region // DEL
                        //// 設定があればそれに従い、なければ全表示
                        //if (String.IsNullOrEmpty(this._gridSetting_Slip))
                        //{
                        //#region 伝票グリッドヘッダ作成（設定なし）

                        //    // 伝票日付
                        //    Columns[this._dataSet.SalesList.SalesDateColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.SalesDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SalesDateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SalesDateColumn.ColumnName].Header.Caption = "伝票日付";
                        //    Columns[this._dataSet.SalesList.SalesDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.SalesDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 伝票番号
                        //    Columns[this._dataSet.SalesList.SalesSlipNumColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.SalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SalesSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SalesSlipNumColumn.ColumnName].Header.Caption = "伝票番号";
                        //    Columns[this._dataSet.SalesList.SalesSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 区分名
                        //    Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        //    Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].Header.Caption = "区分";
                        //    Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 担当者名
                        //    Columns[this._dataSet.SalesList.SalesEmployeeNmColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.SalesEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SalesEmployeeNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SalesEmployeeNmColumn.ColumnName].Header.Caption = "担当者名";
                        //    Columns[this._dataSet.SalesList.SalesEmployeeNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.SalesEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 金額
                        //    Columns[this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName].Header.Caption = "金額";
                        //    Columns[this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 消費税
                        //    Columns[this._dataSet.SalesList.ConsumeTaxColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.ConsumeTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesList.ConsumeTaxColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.ConsumeTaxColumn.ColumnName].Header.Caption = "消費税";
                        //    Columns[this._dataSet.SalesList.ConsumeTaxColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.ConsumeTaxColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 粗利
                        //    Columns[this._dataSet.SalesList.GrossProfitColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.GrossProfitColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesList.GrossProfitColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.GrossProfitColumn.ColumnName].Header.Caption = "粗利";
                        //    Columns[this._dataSet.SalesList.GrossProfitColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.GrossProfitColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 類別番号
                        //    Columns[this._dataSet.SalesList.CategoryNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.CategoryNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.CategoryNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.CategoryNoColumn.ColumnName].Header.Caption = "類別番号";
                        //    Columns[this._dataSet.SalesList.CategoryNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.CategoryNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 車種
                        //    Columns[this._dataSet.SalesList.ModelFullNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.ModelFullNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.ModelFullNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.ModelFullNameColumn.ColumnName].Header.Caption = "車種";
                        //    Columns[this._dataSet.SalesList.ModelFullNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.ModelFullNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 年式
                        //    Columns[this._dataSet.SalesList.FirstEntryDateColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.FirstEntryDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesList.FirstEntryDateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.FirstEntryDateColumn.ColumnName].Header.Caption = "年式";
                        //    Columns[this._dataSet.SalesList.FirstEntryDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.FirstEntryDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 車台No
                        //    Columns[this._dataSet.SalesList.FrameNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.FrameNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesList.FrameNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.FrameNoColumn.ColumnName].Header.Caption = "車台No";
                        //    Columns[this._dataSet.SalesList.FrameNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.FrameNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 型式
                        //    Columns[this._dataSet.SalesList.FullModelColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.FullModelColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.FullModelColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.FullModelColumn.ColumnName].Header.Caption = "型式";
                        //    Columns[this._dataSet.SalesList.FullModelColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.FullModelColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 備考１
                        //    Columns[this._dataSet.SalesList.SlipNoteColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.SlipNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SlipNoteColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SlipNoteColumn.ColumnName].Header.Caption = "備考１";
                        //    Columns[this._dataSet.SalesList.SlipNoteColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.SlipNoteColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 備考２
                        //    Columns[this._dataSet.SalesList.SlipNote2Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.SlipNote2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SlipNote2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SlipNote2Column.ColumnName].Header.Caption = "備考２";
                        //    Columns[this._dataSet.SalesList.SlipNote2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.SlipNote2Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 備考３
                        //    Columns[this._dataSet.SalesList.SlipNote3Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.SlipNote3Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SlipNote3Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SlipNote3Column.ColumnName].Header.Caption = "備考３";
                        //    Columns[this._dataSet.SalesList.SlipNote3Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.SlipNote3Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 受注者
                        //    Columns[this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName].Header.Caption = "受注者";
                        //    Columns[this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 発行者
                        //    Columns[this._dataSet.SalesList.SalesInputNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.SalesInputNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SalesInputNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SalesInputNameColumn.ColumnName].Header.Caption = "発行者";
                        //    Columns[this._dataSet.SalesList.SalesInputNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.SalesInputNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 得意先コード
                        //    Columns[this._dataSet.SalesList.CustomerCodeColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.CustomerCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.CustomerCodeColumn.ColumnName].Header.Caption = "得意先コード";
                        //    Columns[this._dataSet.SalesList.CustomerCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.CustomerCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 得意先名
                        //    Columns[this._dataSet.SalesList.CustomerSnmColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.CustomerSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.CustomerSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.CustomerSnmColumn.ColumnName].Header.Caption = "得意先名";
                        //    Columns[this._dataSet.SalesList.CustomerSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.CustomerSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 得意先注番
                        //    Columns[this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName].Header.Caption = "得意先注番";
                        //    Columns[this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 管理No
                        //    Columns[this._dataSet.SalesList.CarMngCodeColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.CarMngCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.CarMngCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.CarMngCodeColumn.ColumnName].Header.Caption = "管理No";
                        //    Columns[this._dataSet.SalesList.CarMngCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.CarMngCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 計上元受注No
                        //    Columns[this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName].Header.Caption = "計上元受注No";
                        //    Columns[this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 計上先出荷No
                        //    Columns[this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName].Header.Caption = "計上先出荷No";
                        //    Columns[this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // UOEリマーク1
                        //    Columns[this._dataSet.SalesList.UoeRemark1Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.UoeRemark1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.UoeRemark1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.UoeRemark1Column.ColumnName].Header.Caption = "UOEリマーク1";
                        //    Columns[this._dataSet.SalesList.UoeRemark1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.UoeRemark1Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // UOEリマーク2
                        //    Columns[this._dataSet.SalesList.UoeRemark2Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.UoeRemark2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.UoeRemark2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.UoeRemark2Column.ColumnName].Header.Caption = "UOEリマーク2";
                        //    Columns[this._dataSet.SalesList.UoeRemark2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.UoeRemark2Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 拠点
                        //    Columns[this._dataSet.SalesList.SectionGuideNmColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.SectionGuideNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SectionGuideNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SectionGuideNmColumn.ColumnName].Header.Caption = "拠点";
                        //    Columns[this._dataSet.SalesList.SectionGuideNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.SectionGuideNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // カラー名称
                        //    Columns[this._dataSet.SalesList.ColorName1Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.ColorName1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.ColorName1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.ColorName1Column.ColumnName].Header.Caption = "カラー名称";
                        //    Columns[this._dataSet.SalesList.ColorName1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.ColorName1Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // トリム名称
                        //    Columns[this._dataSet.SalesList.TrimNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.TrimNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.TrimNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.TrimNameColumn.ColumnName].Header.Caption = "トリム名称";
                        //    Columns[this._dataSet.SalesList.TrimNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.TrimNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 得意先伝票番号
                        //    Columns[this._dataSet.SalesList.CustSlipNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.CustSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.CustSlipNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.CustSlipNoColumn.ColumnName].Header.Caption = "得意先伝票番号";
                        //    Columns[this._dataSet.SalesList.CustSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.CustSlipNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 計上日
                        //    Columns[this._dataSet.SalesList.AddUpADateColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.AddUpADateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.AddUpADateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.AddUpADateColumn.ColumnName].Header.Caption = "計上日";
                        //    Columns[this._dataSet.SalesList.AddUpADateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.AddUpADateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 売掛区分
                        //    Columns[this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName].Header.Caption = "売掛区分";
                        //    Columns[this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 赤伝区分
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                        //    //Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].Hidden = false;
                        //    //Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    //Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    //Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].Header.Caption = "赤伝区分";
                        //    //Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    //Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                        //    Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].Hidden = true;
                        //    Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;
                        //    Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].Header.Caption = "赤伝区分";
                        //    Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD

                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
                        //    // 納入先コード
                        //    Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].Header.Caption = "納入先コード";
                        //    Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 納入先名
                        //    Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].Header.Caption = "納入先名";
                        //    Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD

                        //    #endregion
                        //}
                        //else
                        //{
                        //#region 伝票グリッドヘッダ作成（設定あり）

                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //string[] gridPattern = new string[32];
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    string[] gridPattern;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    getGridSettingPattern(this._gridSetting_Slip, out gridPattern, true);

                        //    int position = 0;

                        //    // 伝票日付
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse(gridPattern[0].ToString());
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.SalesDateColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.SalesDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SalesDateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SalesDateColumn.ColumnName].Header.Caption = "伝票日付";
                        //    Columns[this._dataSet.SalesList.SalesDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.SalesDateColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.SalesDateColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.SalesDateColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.SalesDateColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 伝票番号
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[1].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.SalesSlipNumColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.SalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SalesSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SalesSlipNumColumn.ColumnName].Header.Caption = "伝票番号";
                        //    Columns[this._dataSet.SalesList.SalesSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.SalesSlipNumColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.SalesSlipNumColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 区分名
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[2].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        //    Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].Header.Caption = "区分";
                        //    Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 担当者名
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[3].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.SalesEmployeeNmColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.SalesEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SalesEmployeeNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SalesEmployeeNmColumn.ColumnName].Header.Caption = "担当者名";
                        //    Columns[this._dataSet.SalesList.SalesEmployeeNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.SalesSlipCdNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.SalesEmployeeNmColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.SalesEmployeeNmColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.SalesEmployeeNmColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 金額
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[4].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName].Header.Caption = "金額";
                        //    Columns[this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 消費税
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[5].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.ConsumeTaxColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.ConsumeTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesList.ConsumeTaxColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.ConsumeTaxColumn.ColumnName].Header.Caption = "消費税";
                        //    Columns[this._dataSet.SalesList.ConsumeTaxColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.ConsumeTaxColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.ConsumeTaxColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.ConsumeTaxColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.ConsumeTaxColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 粗利
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[6].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.GrossProfitColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.GrossProfitColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesList.GrossProfitColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.GrossProfitColumn.ColumnName].Header.Caption = "粗利";
                        //    Columns[this._dataSet.SalesList.GrossProfitColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.GrossProfitColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.GrossProfitColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.GrossProfitColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.GrossProfitColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 類別番号
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[7].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.CategoryNoColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.CategoryNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.CategoryNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.CategoryNoColumn.ColumnName].Header.Caption = "類別番号";
                        //    Columns[this._dataSet.SalesList.CategoryNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.CategoryNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.CategoryNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.CategoryNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.CategoryNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 車種
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[8].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.ModelFullNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.ModelFullNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.ModelFullNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.ModelFullNameColumn.ColumnName].Header.Caption = "車種";
                        //    Columns[this._dataSet.SalesList.ModelFullNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.ModelFullNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.ModelFullNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.ModelFullNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.ModelFullNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 年式
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[9].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.FirstEntryDateColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.FirstEntryDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesList.FirstEntryDateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.FirstEntryDateColumn.ColumnName].Header.Caption = "年式";
                        //    Columns[this._dataSet.SalesList.FirstEntryDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.FirstEntryDateColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.FirstEntryDateColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.FirstEntryDateColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.FirstEntryDateColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 車台No
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[10].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.FrameNoColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.FrameNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesList.FrameNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.FrameNoColumn.ColumnName].Header.Caption = "車台No";
                        //    Columns[this._dataSet.SalesList.FrameNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.FrameNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.FrameNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.FrameNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.FrameNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 型式
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[11].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.FullModelColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.FullModelColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.FullModelColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.FullModelColumn.ColumnName].Header.Caption = "型式";
                        //    Columns[this._dataSet.SalesList.FullModelColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.FullModelColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.FullModelColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.FullModelColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.FullModelColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 備考１
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[12].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.SlipNoteColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.SlipNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SlipNoteColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SlipNoteColumn.ColumnName].Header.Caption = "備考１";
                        //    Columns[this._dataSet.SalesList.SlipNoteColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.SlipNoteColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.SlipNoteColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.SlipNoteColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.SlipNoteColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 備考２
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[13].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.SlipNote2Column.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.SlipNote2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SlipNote2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SlipNote2Column.ColumnName].Header.Caption = "備考２";
                        //    Columns[this._dataSet.SalesList.SlipNote2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.SlipNote2Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.SlipNote2Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.SlipNote2Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.SlipNote2Column.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 備考３
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[14].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.SlipNote3Column.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.SlipNote3Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SlipNote3Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SlipNote3Column.ColumnName].Header.Caption = "備考３";
                        //    Columns[this._dataSet.SalesList.SlipNote3Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.SlipNote3Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.SlipNote3Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.SlipNote3Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.SlipNote3Column.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 受注者
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[15].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName].Header.Caption = "受注者";
                        //    Columns[this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.FrontEmployeeNmColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 発行者
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[16].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.SalesInputNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.SalesInputNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SalesInputNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SalesInputNameColumn.ColumnName].Header.Caption = "発行者";
                        //    Columns[this._dataSet.SalesList.SalesInputNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.SalesInputNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.SalesInputNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.SalesInputNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.SalesInputNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 得意先コード
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[17].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.CustomerCodeColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.CustomerCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.CustomerCodeColumn.ColumnName].Header.Caption = "得意先コード";
                        //    Columns[this._dataSet.SalesList.CustomerCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.CustomerCodeColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.CustomerCodeColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.CustomerCodeColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.CustomerCodeColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 得意先名
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[18].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.CustomerSnmColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.CustomerSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.CustomerSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.CustomerSnmColumn.ColumnName].Header.Caption = "得意先名";
                        //    Columns[this._dataSet.SalesList.CustomerSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.CustomerSnmColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.CustomerSnmColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.CustomerSnmColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.CustomerSnmColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 得意先注番
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[19].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName].Header.Caption = "得意先注番";
                        //    Columns[this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 管理No
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[20].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.CarMngCodeColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.CarMngCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.CarMngCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.CarMngCodeColumn.ColumnName].Header.Caption = "管理No";
                        //    Columns[this._dataSet.SalesList.CarMngCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.CarMngCodeColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.CarMngCodeColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.CarMngCodeColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.CarMngCodeColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 計上元受注No
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[21].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName].Header.Caption = "計上元受注No";
                        //    Columns[this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 計上先出荷No
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[22].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName].Header.Caption = "計上先出荷No";
                        //    Columns[this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // UOEリマーク1
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[23].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.UoeRemark1Column.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.UoeRemark1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.UoeRemark1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.UoeRemark1Column.ColumnName].Header.Caption = "UOEリマーク1";
                        //    Columns[this._dataSet.SalesList.UoeRemark1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.UoeRemark1Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.UoeRemark1Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.UoeRemark1Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.UoeRemark1Column.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // UOEリマーク2
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[24].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.UoeRemark2Column.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.UoeRemark2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.UoeRemark2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.UoeRemark2Column.ColumnName].Header.Caption = "UOEリマーク2";
                        //    Columns[this._dataSet.SalesList.UoeRemark2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.UoeRemark2Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.UoeRemark2Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.UoeRemark2Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.UoeRemark2Column.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 拠点
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[25].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.SectionGuideNmColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.SectionGuideNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.SectionGuideNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.SectionGuideNmColumn.ColumnName].Header.Caption = "拠点";
                        //    Columns[this._dataSet.SalesList.SectionGuideNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.SectionGuideNmColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.SectionGuideNmColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.SectionGuideNmColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.SectionGuideNmColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // カラー名称
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[26].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.ColorName1Column.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.ColorName1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.ColorName1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.ColorName1Column.ColumnName].Header.Caption = "カラー名称";
                        //    Columns[this._dataSet.SalesList.ColorName1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.ColorName1Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.ColorName1Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.ColorName1Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.ColorName1Column.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // トリム名称
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[27].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.TrimNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.TrimNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.TrimNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.TrimNameColumn.ColumnName].Header.Caption = "トリム名称";
                        //    Columns[this._dataSet.SalesList.TrimNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.TrimNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.TrimNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.TrimNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.TrimNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 得意先伝票番号
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[28].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.CustSlipNoColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.CustSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.CustSlipNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.CustSlipNoColumn.ColumnName].Header.Caption = "得意先伝票番号";
                        //    Columns[this._dataSet.SalesList.CustSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.CustSlipNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.CustSlipNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.CustSlipNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.CustSlipNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 計上日
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[29].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.AddUpADateColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.AddUpADateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.AddUpADateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.AddUpADateColumn.ColumnName].Header.Caption = "計上日";
                        //    Columns[this._dataSet.SalesList.AddUpADateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.AddUpADateColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.AddUpADateColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.AddUpADateColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.AddUpADateColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 売掛区分
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[30].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName].Header.Caption = "売掛区分";
                        //    Columns[this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.AccRecDivCdNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                        //    //// 赤伝区分
                        //    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    ////position = Int32.Parse( gridPattern[31].ToString() );
                        //    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    //position = GetColumnPositionOfSlip( gridPattern, this._dataSet.SalesList.DebitNoteDivColumn.ColumnName );
                        //    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    //Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    //Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    //Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].Header.Caption = "赤伝区分";
                        //    //Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    //if (position > 100)
                        //    //{
                        //    //    Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].Hidden = true;
                        //    //    Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    //}
                        //    //else
                        //    //{
                        //    //    Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].Hidden = false;
                        //    //    Columns[this._dataSet.SalesList.DebitNoteDivColumn.ColumnName].Header.VisiblePosition = position;
                        //    //}
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL

                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
                        //    // 納入先コード
                        //    Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].Header.Caption = "納入先コード";
                        //    Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if ( position > 100 )
                        //    {
                        //        Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.AddresseeCodeColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 納入先名
                        //    Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].Header.Caption = "納入先名";
                        //    Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if ( position > 100 )
                        //    {
                        //        Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesList.AddresseeNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD

                        //    #endregion
                        //}
                        # endregion
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD

                        string[] gridPattern = new string[0];
                        if ( !string.IsNullOrEmpty( _gridSetting_Slip ) )
                        {
                            getGridSettingPattern( this._gridSetting_Slip, out gridPattern, true );
                        }

                        int position = 0;


                        foreach ( Infragistics.Win.UltraWinGrid.UltraGridColumn orgCol in _slipColCollection )
                        {
                            // 選択用のチェックボックスは除外
                            if ( orgCol.Key == _dataSet.SalesList.SelectionColumn.ColumnName ) continue;

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                            // 履歴区分は除外
                            if ( orgCol.Key == _dataSet.SalesList.HistoryDivNameColumn.ColumnName ) continue;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD

                            // カラムチューザから除外されている項目は内部制御用とみなして除外
                            if ( orgCol.ExcludeFromColumnChooser == Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True ) continue;

                            // 元カラムからコピー
                            Columns[orgCol.Key].CellAppearance.TextHAlign = orgCol.CellAppearance.TextHAlign;
                            Columns[orgCol.Key].Header.Caption = orgCol.Header.Caption;
                            Columns[orgCol.Key].Header.Appearance.TextHAlign = orgCol.Header.Appearance.TextHAlign;
                            // 値セット
                            Columns[orgCol.Key].Hidden = false;
                            Columns[orgCol.Key].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                            Columns[orgCol.Key].Header.VisiblePosition = visiblePosition++;

                            if ( !string.IsNullOrEmpty( _gridSetting_Slip ) )
                            {
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/11/24 ADD
                                int hiddenFlag = (int)Math.Pow( 10, ct_ColumnCountLength );
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/11/24 ADD

                                // 設定あり
                                position = GetColumnPositionOfSlip( gridPattern, orgCol.Key );
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/11/24 UPD
                                //if ( position > 100 )
                                if ( position >= hiddenFlag )
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/11/24 UPD
                                {
                                    Columns[orgCol.Key].Hidden = true;
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/11/24 UPD
                                    //Columns[orgCol.Key].Header.VisiblePosition = position - 100;
                                    Columns[orgCol.Key].Header.VisiblePosition = position - hiddenFlag;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/11/24 UPD
                                }
                                // ADD 2012/04/01 gezh Redmine#29250 ----------------------------------------------------------->>>>>
                                else if (position > gridPattern.Length && orgCol.Key == _dataSet.SalesList.UpdateDateTimeColumn.ColumnName)
                                {
                                    Columns[orgCol.Key].Hidden = true;
                                    Columns[orgCol.Key].Header.VisiblePosition = position;
                                }
                                // ADD 2012/04/01 gezh Redmine#29250 -----------------------------------------------------------<<<<<
                                else
                                {
                                    Columns[orgCol.Key].Hidden = false;
                                    Columns[orgCol.Key].Header.VisiblePosition = position;
                                }
                            }
                            else
                            {
                                // 設定なし
                                Columns[orgCol.Key].Hidden = false;
                                Columns[orgCol.Key].Header.VisiblePosition = position++;
                            }
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD

                        #region カラムチューザ設定

                        //--------------------------------------------------------------------------------
                        //  カラムチューザを有効にする
                        //--------------------------------------------------------------------------------
                        this.uGrid_ColumnItemSelector.DisplayLayout.ColumnChooserEnabled = Infragistics.Win.DefaultableBoolean.True;
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton;
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorWidth = 24;

                        // カラムチューザボタンの外観を設定
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/03 ADD
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromArgb( 89, 135, 214 );
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb( 7, 59, 150 );
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/03 ADD
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor = this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackColor;
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor2 = this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackColor2;
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.BackGradientStyle = this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle;
                        this.uGrid_ColumnItemSelector.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;

                        #endregion // カラムチューザ設定

                        // 列幅自動調整を設定値にしたがって行う
                        autoColumnAdjust(false, 0);

                        break;
                    }
                case 1:
                    {
                        #region 明細

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                        # region // DEL
                        //// 設定があればそれに従い、なければ全表示
                        //if (String.IsNullOrEmpty(this._gridSetting_Detail))
                        //{
                        //    #region 明細グリッドヘッダ作成（設定なし）

                        //    // 伝票日付
                        //    Columns[this._dataSet.SalesDetail.SalesDateColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SalesDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SalesDateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesDateColumn.ColumnName].Header.Caption = "伝票日付";
                        //    Columns[this._dataSet.SalesDetail.SalesDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SalesDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 伝票番号
                        //    Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].Header.Caption = "伝票番号";
                        //    Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 行No
                        //    Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Header.Caption = "行No";
                        //    Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 区分名
                        //    Columns[this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName].Header.Caption = "区分";
                        //    Columns[this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 担当者名
                        //    Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].Header.Caption = "担当者名";
                        //    Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 品名
                        //    Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Header.Caption = "品名";
                        //    Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 品番
                        //    Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Header.Caption = "品番";
                        //    Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // BLコード
                        //    Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Header.Caption = "BLｺｰﾄﾞ";
                        //    Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // BLグループ
                        //    Columns[this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName].Header.Caption = "BLｸﾞﾙｰﾌﾟ";
                        //    Columns[this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 数量
                        //    Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Header.Caption = "数量";
                        //    Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 標準価格
                        //    Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Header.Caption = "標準価格";
                        //    Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 単価
                        //    Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Header.Caption = "単価";
                        //    Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 原価
                        //    Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Header.Caption = "原価";
                        //    Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 金額
                        //    Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Header.Caption = "金額";
                        //    Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 消費税
                        //    Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].Header.Caption = "消費税";
                        //    Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/03 DEL
                        //    //// 粗利（売上伝票合計）
                        //    //Columns[this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName].Hidden = false;
                        //    //Columns[this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    //Columns[this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    //Columns[this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName].Header.Caption = "粗利";
                        //    //Columns[this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    //Columns[this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/03 DEL

                        //    // 類別番号
                        //    Columns[this._dataSet.SalesDetail.CategoryNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.CategoryNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.CategoryNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.CategoryNoColumn.ColumnName].Header.Caption = "類別番号";
                        //    Columns[this._dataSet.SalesDetail.CategoryNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.CategoryNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 車種
                        //    Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].Header.Caption = "車種";
                        //    Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 年式
                        //    Columns[this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName].Header.Caption = "年式";
                        //    Columns[this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 車台No
                        //    Columns[this._dataSet.SalesDetail.FrameNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.FrameNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.FrameNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.FrameNoColumn.ColumnName].Header.Caption = "車台No";
                        //    Columns[this._dataSet.SalesDetail.FrameNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.FrameNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 型式
                        //    Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].Header.Caption = "型式";
                        //    Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 備考１
                        //    Columns[this._dataSet.SalesDetail.SlipNoteColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SlipNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SlipNoteColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SlipNoteColumn.ColumnName].Header.Caption = "備考１";
                        //    Columns[this._dataSet.SalesDetail.SlipNoteColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SlipNoteColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 備考２
                        //    Columns[this._dataSet.SalesDetail.SlipNote2Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SlipNote2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SlipNote2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SlipNote2Column.ColumnName].Header.Caption = "備考２";
                        //    Columns[this._dataSet.SalesDetail.SlipNote2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SlipNote2Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 備考３
                        //    Columns[this._dataSet.SalesDetail.SlipNote3Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SlipNote3Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SlipNote3Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SlipNote3Column.ColumnName].Header.Caption = "備考３";
                        //    Columns[this._dataSet.SalesDetail.SlipNote3Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SlipNote3Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 受注者
                        //    Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].Header.Caption = "受注者";
                        //    Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 発行者
                        //    Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].Header.Caption = "発行者";
                        //    Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 得意先コード
                        //    Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].Header.Caption = "得意先コード";
                        //    Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 得意先名
                        //    Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].Header.Caption = "得意先名";
                        //    Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 仕入先コード
                        //    Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].Header.Caption = "仕入先コード";
                        //    Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 仕入先
                        //    Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Header.Caption = "仕入先";
                        //    Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 得意先注番
                        //    Columns[this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName].Header.Caption = "得意先注番";
                        //    Columns[this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 管理No
                        //    Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].Header.Caption = "管理No";
                        //    Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 計上元受注No
                        //    Columns[this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName].Header.Caption = "計上元受注No";
                        //    Columns[this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 計上先出荷No
                        //    Columns[this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName].Header.Caption = "計上先出荷No";
                        //    Columns[this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 元黒No
                        //    Columns[this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName].Header.Caption = "元黒No";
                        //    Columns[this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 在庫取寄区分
                        //    Columns[this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName].Header.Caption = "在庫取寄区分";
                        //    Columns[this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 倉庫
                        //    Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].Header.Caption = "倉庫";
                        //    Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 同時仕入No
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                        //    Columns[this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName].Hidden = true;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                        //    Columns[this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName].Header.Caption = "同時仕入No";
                        //    Columns[this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                        //    Columns[this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName].Hidden = true;
                        //    Columns[this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName].Header.Caption = "同時仕入No";
                        //    Columns[this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD

                        //    // 発注先コード
                        //    Columns[this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName].Header.Caption = "発注先コード";
                        //    Columns[this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 発注先
                        //    Columns[this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName].Header.Caption = "発注先";
                        //    Columns[this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // UOEリマーク１
                        //    Columns[this._dataSet.SalesDetail.UOERemark1Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.UOERemark1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.UOERemark1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.UOERemark1Column.ColumnName].Header.Caption = "UOEリマーク１";
                        //    Columns[this._dataSet.SalesDetail.UOERemark1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.UOERemark1Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // UOEリマーク２
                        //    Columns[this._dataSet.SalesDetail.UOERemark2Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.UOERemark2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.UOERemark2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.UOERemark2Column.ColumnName].Header.Caption = "UOEリマーク２";
                        //    Columns[this._dataSet.SalesDetail.UOERemark2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.UOERemark2Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 販売区分
                        //    Columns[this._dataSet.SalesDetail.GuideNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.GuideNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.GuideNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.GuideNameColumn.ColumnName].Header.Caption = "販売区分";
                        //    Columns[this._dataSet.SalesDetail.GuideNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.GuideNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 拠点
                        //    Columns[this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName].Header.Caption = "拠点";
                        //    Columns[this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 明細備考
                        //    Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Header.Caption = "明細備考";
                        //    Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // カラー名
                        //    Columns[this._dataSet.SalesDetail.ColorName1Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.ColorName1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.ColorName1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.ColorName1Column.ColumnName].Header.Caption = "カラー名";
                        //    Columns[this._dataSet.SalesDetail.ColorName1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.ColorName1Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // トリム名
                        //    Columns[this._dataSet.SalesDetail.TrimNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.TrimNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.TrimNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.TrimNameColumn.ColumnName].Header.Caption = "トリム名";
                        //    Columns[this._dataSet.SalesDetail.TrimNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.TrimNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 算出価格
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Header.Caption = "算出価格";
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 算出売価
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName].Header.Caption = "算出売価";
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 算出原価
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName].Header.Caption = "算出原価";
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // メーカーコード
                        //    Columns[this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName].Header.Caption = "メーカーコード";
                        //    Columns[this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // メーカー
                        //    Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Header.Caption = "メーカー";
                        //    Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/03 DEL
                        //    //// 原価（粗利）
                        //    //Columns[this._dataSet.SalesDetail.CostColumn.ColumnName].Hidden = false;
                        //    //Columns[this._dataSet.SalesDetail.CostColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    //Columns[this._dataSet.SalesDetail.CostColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    //Columns[this._dataSet.SalesDetail.CostColumn.ColumnName].Header.Caption = "原価（粗利）";
                        //    //Columns[this._dataSet.SalesDetail.CostColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    //Columns[this._dataSet.SalesDetail.CostColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/03 DEL

                        //    // 得意先伝票番号
                        //    Columns[this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName].Header.Caption = "得意先伝票番号";
                        //    Columns[this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 計上日
                        //    Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].Header.Caption = "計上日";
                        //    Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 売掛区分名
                        //    Columns[this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName].Header.Caption = "売掛区分";
                        //    Columns[this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 赤伝区分
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                        //    //Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].Hidden = false;
                        //    //Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    //Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    //Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].Header.Caption = "赤伝区分";
                        //    //Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    //Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                        //    Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].Hidden = true;
                        //    Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;
                        //    Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].Header.Caption = "赤伝区分";
                        //    Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD

                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
                        //    // 納入先コード
                        //    Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].Header.Caption = "納入先コード";
                        //    Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 納入先名
                        //    Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].Header.Caption = "納入先名";
                        //    Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD

                        //    #endregion // 明細グリッドヘッダ作成（設定なし）
                        //}
                        //else
                        //{
                        //    #region 明細グリッドヘッダ作成（設定あり）

                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //string[] gridPattern = new string[57];
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    string[] gridPattern;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    getGridSettingPattern(this._gridSetting_Detail, out gridPattern, false);

                        //    int position = 0;

                        //    // 伝票日付
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse(gridPattern[0].ToString());
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SalesDateColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD

                        //    Columns[this._dataSet.SalesDetail.SalesDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SalesDateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesDateColumn.ColumnName].Header.Caption = "伝票日付";
                        //    Columns[this._dataSet.SalesDetail.SalesDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesDateColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SalesDateColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesDateColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SalesDateColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 伝票番号
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse(gridPattern[1].ToString());
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].Header.Caption = "伝票番号";
                        //    Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 行No
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[2].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Header.Caption = "行No";
                        //    Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 区分名
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[3].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName].Header.Caption = "区分";
                        //    Columns[this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 担当者名
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[4].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].Header.Caption = "担当者名";
                        //    Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 品名
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[5].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.GoodsNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Header.Caption = "品名";
                        //    Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 品番
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[6].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.GoodsNoColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Header.Caption = "品番";
                        //    Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // BLコード
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[7].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Header.Caption = "BLｺｰﾄﾞ";
                        //    Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // BLグループ
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[8].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName].Header.Caption = "BLｸﾞﾙｰﾌﾟ";
                        //    Columns[this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 数量
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[9].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Header.Caption = "数量";
                        //    Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 標準価格
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[10].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Header.Caption = "標準価格";
                        //    Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 単価
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[11].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Header.Caption = "単価";
                        //    Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 原価
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[12].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Header.Caption = "原価";
                        //    Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 金額
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[13].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Header.Caption = "金額";
                        //    Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 消費税
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[14].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].Header.Caption = "消費税";
                        //    Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 粗利（売上伝票合計）
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[15].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName].Header.Caption = "粗利";
                        //    Columns[this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 類別番号
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[16].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.CategoryNoColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.CategoryNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.CategoryNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.CategoryNoColumn.ColumnName].Header.Caption = "類別番号";
                        //    Columns[this._dataSet.SalesDetail.CategoryNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.CategoryNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.CategoryNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.CategoryNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.CategoryNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 車種
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[17].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].Header.Caption = "車種";
                        //    Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 年式
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[18].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName].Header.Caption = "年式";
                        //    Columns[this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.FirstEntryDateColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 車台No
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[19].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.FrameNoColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.FrameNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.FrameNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.FrameNoColumn.ColumnName].Header.Caption = "車台No";
                        //    Columns[this._dataSet.SalesDetail.FrameNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.FrameNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.FrameNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.FrameNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.FrameNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 型式
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[20].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.FullModelColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].Header.Caption = "型式";
                        //    Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 備考１
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[21].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SlipNoteColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SlipNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SlipNoteColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SlipNoteColumn.ColumnName].Header.Caption = "備考１";
                        //    Columns[this._dataSet.SalesDetail.SlipNoteColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SlipNoteColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SlipNoteColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SlipNoteColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SlipNoteColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 備考２
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[22].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SlipNote2Column.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SlipNote2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SlipNote2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SlipNote2Column.ColumnName].Header.Caption = "備考２";
                        //    Columns[this._dataSet.SalesDetail.SlipNote2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SlipNote2Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SlipNote2Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SlipNote2Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SlipNote2Column.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 備考３
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[23].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SlipNote3Column.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SlipNote3Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SlipNote3Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SlipNote3Column.ColumnName].Header.Caption = "備考３";
                        //    Columns[this._dataSet.SalesDetail.SlipNote3Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SlipNote3Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SlipNote3Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SlipNote3Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SlipNote3Column.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 受注者
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[24].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].Header.Caption = "受注者";
                        //    Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 発行者
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[25].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].Header.Caption = "発行者";
                        //    Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 得意先コード
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[26].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].Header.Caption = "得意先コード";
                        //    Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 得意先名
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[27].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].Header.Caption = "得意先名";
                        //    Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 仕入先コード
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[28].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SupplierCdColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].Header.Caption = "仕入先コード";
                        //    Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {   
                        //        Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 仕入先
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[29].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Header.Caption = "仕入先";
                        //    Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 得意先注番
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[30].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName].Header.Caption = "得意先注番";
                        //    Columns[this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 管理No
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[31].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].Header.Caption = "管理No";
                        //    Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 計上元受注No
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[32].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName].Header.Caption = "計上元受注No";
                        //    Columns[this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 計上先出荷No
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[33].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName].Header.Caption = "計上先出荷No";
                        //    Columns[this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 元黒No
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[34].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName].Header.Caption = "元黒No";
                        //    Columns[this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 在庫取寄区分
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[35].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName].Header.Caption = "在庫取寄区分";
                        //    Columns[this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 倉庫
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[36].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].Header.Caption = "倉庫";
                        //    Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 同時仕入No
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                        //    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    ////position = Int32.Parse( gridPattern[37].ToString() );
                        //    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    //position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName );
                        //    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    //Columns[this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    //Columns[this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    //Columns[this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName].Header.Caption = "同時仕入No";
                        //    //Columns[this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    //if (position > 100)
                        //    //{
                        //    //    Columns[this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName].Hidden = true;
                        //    //    Columns[this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    //}
                        //    //else
                        //    //{
                        //    //    Columns[this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName].Hidden = false;
                        //    //    Columns[this._dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    //}
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName );
                        //    Columns[this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName].Header.Caption = "同時仕入No";
                        //    Columns[this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if ( position > 100 )
                        //    {
                        //        Columns[this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD


                        //    // 発注先コード
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[38].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName].Header.Caption = "発注先コード";
                        //    Columns[this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.UOESupplierCdColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 発注先
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[39].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName].Header.Caption = "発注先";
                        //    Columns[this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // UOEリマーク１
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse(gridPattern[40].ToString());
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.UOERemark1Column.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.UOERemark1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.UOERemark1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.UOERemark1Column.ColumnName].Header.Caption = "UOEリマーク１";
                        //    Columns[this._dataSet.SalesDetail.UOERemark1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.UOERemark1Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.UOERemark1Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.UOERemark1Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.UOERemark1Column.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // UOEリマーク２
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[41].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.UOERemark2Column.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.UOERemark2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.UOERemark2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.UOERemark2Column.ColumnName].Header.Caption = "UOEリマーク２";
                        //    Columns[this._dataSet.SalesDetail.UOERemark2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.UOERemark2Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.UOERemark2Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.UOERemark2Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.UOERemark2Column.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 販売区分
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[42].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.GuideNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.GuideNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.GuideNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.GuideNameColumn.ColumnName].Header.Caption = "販売区分";
                        //    Columns[this._dataSet.SalesDetail.GuideNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.GuideNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.GuideNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.GuideNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.GuideNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 拠点
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[43].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName].Header.Caption = "拠点";
                        //    Columns[this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.SectionGuideNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 明細備考
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[44].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.DtlNoteColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Header.Caption = "明細備考";
                        //    Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // カラー名
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[45].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.ColorName1Column.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.ColorName1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.ColorName1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.ColorName1Column.ColumnName].Header.Caption = "カラー名";
                        //    Columns[this._dataSet.SalesDetail.ColorName1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.ColorName1Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.ColorName1Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.ColorName1Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.ColorName1Column.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // トリム名
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[46].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.TrimNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.TrimNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.TrimNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.TrimNameColumn.ColumnName].Header.Caption = "トリム名";
                        //    Columns[this._dataSet.SalesDetail.TrimNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.TrimNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.TrimNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.TrimNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.TrimNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 算出価格
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[47].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Header.Caption = "算出価格";
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 算出売価
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[48].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName].Header.Caption = "算出売価";
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 算出原価
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[49].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName].Header.Caption = "算出原価";
                        //    Columns[this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // メーカーコード
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[50].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName].Header.Caption = "メーカーコード";
                        //    Columns[this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // メーカー
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[51].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.MakerNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Header.Caption = "メーカー";
                        //    Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/03 DEL
                        //    //// 原価（粗利）
                        //    //position = Int32.Parse(gridPattern[52].ToString());
                        //    //Columns[this._dataSet.SalesDetail.CostColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    //Columns[this._dataSet.SalesDetail.CostColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    //Columns[this._dataSet.SalesDetail.CostColumn.ColumnName].Header.Caption = "原価（粗利）";
                        //    //Columns[this._dataSet.SalesDetail.CostColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    //if (position > 100)
                        //    //{
                        //    //    Columns[this._dataSet.SalesDetail.CostColumn.ColumnName].Hidden = true;
                        //    //    Columns[this._dataSet.SalesDetail.CostColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    //}
                        //    //else
                        //    //{
                        //    //    Columns[this._dataSet.SalesDetail.CostColumn.ColumnName].Hidden = false;
                        //    //    Columns[this._dataSet.SalesDetail.CostColumn.ColumnName].Header.VisiblePosition = position;
                        //    //}
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/03 DEL

                        //    // 得意先伝票番号
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[53].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName].Header.Caption = "得意先伝票番号";
                        //    Columns[this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.CustSlipNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 計上日
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[54].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.AddUpADateColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].Header.Caption = "計上日";
                        //    Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 売掛区分名
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    //position = Int32.Parse( gridPattern[55].ToString() );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    Columns[this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName].Header.Caption = "売掛区分";
                        //    Columns[this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                        //    //// 赤伝区分
                        //    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //    ////position = Int32.Parse( gridPattern[56].ToString() );
                        //    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        //    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        //    //position = GetColumnPositionOfDetail( gridPattern, this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName );
                        //    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                        //    //Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    //Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    //Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].Header.Caption = "赤伝区分";
                        //    //Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    //if (position > 100)
                        //    //{
                        //    //    Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].Hidden = true;
                        //    //    Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    //}
                        //    //else
                        //    //{
                        //    //    Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].Hidden = false;
                        //    //    Columns[this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName].Header.VisiblePosition = position;
                        //    //}
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL

                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
                        //    // 納入先コード
                        //    Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].Header.Caption = "納入先コード";
                        //    Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if ( position > 100 )
                        //    {
                        //        Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 納入先名
                        //    Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].Header.Caption = "納入先名";
                        //    Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if ( position > 100 )
                        //    {
                        //        Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD

                        //    #endregion // 明細グリッドヘッダ作成（設定あり）
                        //}
                        # endregion
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                        string[] gridPattern = new string[0];
                        if ( !string.IsNullOrEmpty( _gridSetting_Detail) )
                        {
                            getGridSettingPattern( this._gridSetting_Detail, out gridPattern, true );
                        }

                        int position = 0;


                        foreach ( Infragistics.Win.UltraWinGrid.UltraGridColumn orgCol in _detailColCollection )
                        {
                            // 選択用のチェックボックスは除外
                            if ( orgCol.Key == _dataSet.SalesDetail.SelectionCheckColumn.ColumnName ) continue;

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                            // 履歴区分は除外
                            if ( orgCol.Key == _dataSet.SalesDetail.HistoryDivNameColumn.ColumnName ) continue;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD

                            // カラムチューザから除外されている項目は内部制御用とみなして除外
                            if ( orgCol.ExcludeFromColumnChooser == Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True ) continue;

                            // 元カラムからコピー
                            Columns[orgCol.Key].CellAppearance.TextHAlign = orgCol.CellAppearance.TextHAlign;
                            Columns[orgCol.Key].Header.Caption = orgCol.Header.Caption;
                            Columns[orgCol.Key].Header.Appearance.TextHAlign = orgCol.Header.Appearance.TextHAlign;
                            // 値セット
                            Columns[orgCol.Key].Hidden = false;
                            Columns[orgCol.Key].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                            Columns[orgCol.Key].Header.VisiblePosition = visiblePosition++;

                            if ( !string.IsNullOrEmpty( _gridSetting_Detail ) )
                            {
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/11/24 ADD
                                int hiddenFlag = (int)Math.Pow( 10, ct_ColumnCountLength );
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/11/24 ADD

                                // 設定あり
                                position = GetColumnPositionOfDetail( gridPattern, orgCol.Key );
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/11/24 UPD
                                //if ( position > 100 )
                                if ( position >= hiddenFlag )
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/11/24 UPD
                                {
                                    Columns[orgCol.Key].Hidden = true;
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/11/24 UPD
                                    //Columns[orgCol.Key].Header.VisiblePosition = position - 100;
                                    Columns[orgCol.Key].Header.VisiblePosition = position - hiddenFlag;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/11/24 UPD
                                }
                                // ADD 2012/04/01 gezh Redmine#29250 ----------------------------------------------------------->>>>>
                                else if (position > gridPattern.Length && orgCol.Key == _dataSet.SalesDetail.UpdateDateTimeColumn.ColumnName)
                                {
                                    Columns[orgCol.Key].Hidden = true;
                                    Columns[orgCol.Key].Header.VisiblePosition = position;
                                }
                                // ADD 2012/04/01 gezh Redmine#29250 -----------------------------------------------------------<<<<<
                                // --- ADD 陳永康 2015/03/16 変換後品番 初期値の非表示対応 ----->>>>> 
                                else if (position > gridPattern.Length && orgCol.Key == _dataSet.SalesDetail.ChangeGoodsNoColumn.ColumnName)
                                {
                                    Columns[orgCol.Key].Hidden = true;
                                    Columns[orgCol.Key].Header.VisiblePosition = position;
                                }
                                // --- ADD 陳永康 2015/03/16 変換後品番 初期値の非表示対応 -----<<<<<
                                else
                                {
                                    Columns[orgCol.Key].Hidden = false;
                                    Columns[orgCol.Key].Header.VisiblePosition = position;
                                }
                            }
                            else
                            {
                                // 設定なし
                                Columns[orgCol.Key].Hidden = false;
                                Columns[orgCol.Key].Header.VisiblePosition = position++;
                                // --- ADD 陳永康 2015/03/16 変換後品番 初期値の非表示対応 ----->>>>> 
                                if (orgCol.Key == _dataSet.SalesDetail.ChangeGoodsNoColumn.ColumnName)
                                {
                                    Columns[orgCol.Key].Hidden = true;
                                }
                                // --- ADD 陳永康 2015/03/16 変換後品番 初期値の非表示対応 -----<<<<<
                            }
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD

                        #region カラムチューザ設定

                        //--------------------------------------------------------------------------------
                        //  カラムチューザを有効にする
                        //--------------------------------------------------------------------------------
                        this.uGrid_ColumnItemSelector2.DisplayLayout.ColumnChooserEnabled = Infragistics.Win.DefaultableBoolean.True;
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton;
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorWidth = 24;

                        // カラムチューザボタンの外観を設定		
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/03 ADD
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromArgb( 89, 135, 214 );
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb( 7, 59, 150 );
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/03 ADD
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor = this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackColor;
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor2 = this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackColor2;
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderAppearance.BackGradientStyle = this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle;
                        this.uGrid_ColumnItemSelector2.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderAppearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;

                        #endregion // カラムチューザ設定

                        // 列幅自動調整を設定値にしたがって行う
                        autoColumnAdjust(false, 1);

                        #endregion //明細

                        break;
                    }
                default: break;
            }

            // 外観設定
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            // 外観設定
            this.uGrid_ColumnItemSelector2.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.uGrid_ColumnItemSelector2.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.uGrid_ColumnItemSelector2.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_ColumnItemSelector2.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
            this.uGrid_ColumnItemSelector2.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_ColumnItemSelector2.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGrid_ColumnItemSelector2.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_ColumnItemSelector2.DisplayLayout.Override.HeaderAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

        }

        /// <summary>
        /// 列幅自動調整
        /// </summary>
        /// <param name="autoAdjust">自動調整するかどうか</param>
        /// <param name="targetGrid">対象となるグリッド 0:伝票一覧, 1:明細</param>
        private void autoColumnAdjust(bool autoAdjust, int targetGrid)
        {
            switch (targetGrid)
            {
                case 0:
                    {
                        // 自動調整プロパティを調整
                        if (autoAdjust)
                        {
                            this.uGrid_ColumnItemSelector.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
                        }
                        else
                        {
                            this.uGrid_ColumnItemSelector.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
                        }
                        // 全ての列でサイズ調整
                        for (int i = 0; i < this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns.Count; i++)
                        {
                            //this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();   // DEL 2012/04/01 gezh Redmine#29250
                            // ADD 2012/04/01 gezh Redmine#29250 ----------------------------------------------------------->>>>>
                            if (!this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns[i].Hidden)
                            {
                                this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
                            }
                            // ADD 2012/04/01 gezh Redmine#29250 -----------------------------------------------------------<<<<<
                        }
                        break;
                    }
                case 1:
                    {
                        // 自動調整プロパティを調整
                        if (autoAdjust)
                        {
                            this.uGrid_ColumnItemSelector2.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
                        }
                        else
                        {
                            this.uGrid_ColumnItemSelector2.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
                        }
                        // 全ての列でサイズ調整
                        for (int i = 0; i < this.uGrid_ColumnItemSelector2.DisplayLayout.Bands[0].Columns.Count; i++)
                        {
                            //this.uGrid_ColumnItemSelector2.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();   // ADD 2012/04/01 gezh Redmine#29250
                            // ADD 2012/04/01 gezh Redmine#29250 ----------------------------------------------------------->>>>>
                            if (!this.uGrid_ColumnItemSelector2.DisplayLayout.Bands[0].Columns[i].Hidden)
                            {
                                this.uGrid_ColumnItemSelector2.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
                            }
                            // ADD 2012/04/01 gezh Redmine#29250 -----------------------------------------------------------<<<<<
                        }
                        break;
                    }
                default: break;
            }
        }

        /// <summary>
        /// 入力値チェック
        /// </summary>
        /// <returns></returns>
        private bool checkValues()
        {
            /* ---DEL 2009/02/10 不具合対応[10726] ----------------------------------------------->>>>>
            // ファイル名
            if (String.IsNullOrEmpty(this.tEdit_SettingFileName.Text.Trim())) return false;

            // パターン名
            if ( String.IsNullOrEmpty( this.tComboEditor_PetternSelect.Text.Trim() ) ) return false;
               ---DEL 2009/02/10 不具合対応[10726] -----------------------------------------------<<<<< */
            // ---ADD 2009/02/10 不具合対応[10726] ----------------------------------------------->>>>>
            // ------------DEL 2010/01/29----------->>>>>
            //// ファイル名
            //if (String.IsNullOrEmpty(this.tEdit_SettingFileName.Text.Trim()))
            //{
            //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, MSG_OUTPUTTEXT_NOFILENAME, -1, MessageBoxButtons.OK);
            //    this.tEdit_SettingFileName.Focus();
            //    return false;
            //}
            // ------------DEL 2010/01/29-----------<<<<<
            // パターン名
            if (String.IsNullOrEmpty(this.tComboEditor_PetternSelect.Text.Trim()))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, MSG_OUTPUTTEXT_NOPATTERN, -1, MessageBoxButtons.OK);
                this.tComboEditor_PetternSelect.Focus();
                return false;
            }
            // ---ADD 2009/02/10 不具合対応[10726] -----------------------------------------------<<<<<
            // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿対応　-------->>>>>
            if (this._opt_EBooksLink == (int)Option.ON)
            {
                //「PDF出力しない」以外の場合
                if ((tComboEditor_OutPutMode.SelectedIndex) != MODE_NONE)
                {
                    // PDFプリンタ管理番号　必須入力チェック
                    if (string.IsNullOrEmpty(tEdit_PdfPrinterNumber.Text.Trim()))
                    {
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, MSG_PDFPRINTERNUMBER_NOPATTERN, -1, MessageBoxButtons.OK);
                        this.tEdit_PdfPrinterNumber.Focus();
                        return false;
                    }
                }
                // PDFプリンタ待機時間(ミリ秒) 必須入力チェック
                if (string.IsNullOrEmpty(tEdit_PdfPrinterWait.Text.Trim()))
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, MSG_PDFPRINTERWAIT_NOPATTERN, -1, MessageBoxButtons.OK);
                    this.tEdit_PdfPrinterWait.Focus();
                    return false;
                }

            }
            // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿対応　-------<<<<<
            return true;
        }

        /// <summary>
        /// パターンを更新
        /// </summary>
        /// <remarks>
        /// <br>Update Note: 2015/09/17 田建委</br>
        /// <br>管理番号   : 11170170-00</br>
        /// <br>           : Redmine#47006 現行保障をするため画面に区分を設ける</br>
        /// </remarks>
        private void renewalOutputPattern(bool isDelete)
        {
            if (!isDelete)
            {
                // 名前
                string selectedPatternName = this.tComboEditor_PetternSelect.Text.Trim();
                //string value01 = this.uOptionSet_DividerChar.CheckedIndex.ToString();
                string value01 = this.DividerChar.ToString();
                string value02 = this.tEdit_DividerChar.Text.Trim();
                //string value03 = this.uOptionSet_Parenthesis.CheckedIndex.ToString();
                string value03 = this.Parenthesis.ToString();
                string value04 = this.tEdit_ParenthesisChar.Text.Trim();
                //string value05 = this.uOptionSet_TieNumeric.CheckedIndex.ToString();
                string value05 = this.TieNumeric.ToString();
                //string value06 = this.uOptionSet_TieChar.CheckedIndex.ToString();
                string value06 = this.TieChar.ToString();
                //string value07 = this.uOptionSet_TitleLine.CheckedIndex.ToString();
                string value07 = this.TitleLine.ToString();

                // グリッドから設定値を取得
                string value08 = string.Empty;
                createGridPatternString(true, out value08);
                string value09 = string.Empty;
                createGridPatternString(false, out value09);
                //string value08 = "00100200300400500600700800901001101201301401501601701801902021022023024025026027028029030031032";
                //string value09 = "010203040506070809101112131415161718192021222324252627282930313233343536373839404142434445464748495051525354555657";
                string value10 = this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString();
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                string value11 = this.tComboEditor_OutputType.SelectedItem.DataValue.ToString();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                //add by liusy #35729 2013/05/20 -----<<<<<
                string value12 = "0";
                if (this._opFujikiCustom)
                {
                    value12 = this.tComboEditor_DateType.SelectedItem.DataValue.ToString();
                }
                //add by liusy #35729 2013/05/20 ----->>>>>

                //----- ADD 2015/09/17 田建委 Redmine#47006 ---------->>>>>
                string value13 = string.Empty;
                if (this.uCheckEditor_RetSlipMinus_Saleslip.Checked)
                {
                    // 「返品伝票金額をマイナスで出力する」をチェックオンする場合、「1」とする
                    value13 = "1";
                }
                else
                {
                    // 「返品伝票金額をマイナスで出力する」をチェックオフする場合、「0」とする
                    value13 = "0";
                }

                string value14 = string.Empty;
                if (this.uCheckEditor_RetSlipMinus_Meisai.Checked)
                {
                    // 「マイナス金額にはマイナス記号を付与する」をチェックオンする場合、「1」とする
                    value14 = "1";
                }
                else
                {
                    // 「マイナス金額にはマイナス記号を付与する」をチェックオフする場合、「0」とする
                    value14 = "0";
                }
                //----- ADD 2015/09/17 田建委 Redmine#47006 ----------<<<<<

                // 全て連結
                string convinedStr = selectedPatternName + this._divider +
                        value01 + this._divider + value02 + this._divider +
                        value03 + this._divider + value04 + this._divider +
                        value05 + this._divider + value06 + this._divider +
                        value07 + this._divider + value08 + this._divider +
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //value09 + this._divider + value10;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        value09 + this._divider +
                        value10 + this._divider +
                        //value11;  //del by liusy #35729 2013/05/20
                        //add by liusy #35729 2013/05/20 -----<<<<<
                        value11+ this._divider +
                        //value12; // DEL 2015/09/17 田建委 Redmine#47006
                        //add by liusy #35729 2013/05/20 ----->>>>>
                        
                        //----- ADD 2015/09/17 田建委 Redmine#47006 ---------->>>>>
                        value12 + this._divider +
                        value13 + this._divider +
                        value14;
                        //----- ADD 2015/09/17 田建委 Redmine#47006 ----------<<<<<

                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                string[] newOutputPattern;

                if (this._outputPattern == null)
                {
                    newOutputPattern = new string[1];
                    newOutputPattern[0] = convinedStr;
                }
                else
                {
                    bool exists = false;
                    string pName = string.Empty;
                    int count = 0;

                    // 既存でないか検査
                    foreach (string pattern in this._outputPattern)
                    {
                        // 最初の区切り文字までがパターン名
                        if (pattern.Contains(this._divider))
                        {
                            pName = pattern.Substring(0, pattern.IndexOf(this._divider));
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
                            //if (pName == this._selectedPattern)
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                            if ( pName == selectedPatternName )
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                            {
                                this._outputPattern[count] = convinedStr;
                                exists = true;
                                break;
                            }
                        }
                        count++;
                    }

                    if (exists)
                    {
                        // 更新
                        this._userSetting.OutputPattern = this._outputPattern;
                    }
                    else
                    {
                        newOutputPattern = new string[this._outputPattern.Length + 1];
                        count = 0;
                        foreach (string pattern in _outputPattern)
                        {
                            newOutputPattern[count] = pattern;
                            count++;
                        }
                        newOutputPattern[count] = convinedStr;

                        // 追加
                        this._userSetting.OutputPattern = newOutputPattern;
                    }
                }
            }
        }

        /// <summary>
        /// グリッドの設定を文字列に変換
        /// </summary>
        /// <param name="isSlip"></param>
        /// <param name="patternString"></param>
        /// <br>Update Note : K2015/07/15 陳亮</br>
        /// <br>管理番号    : 11101427-00</br>
        /// <br>            : メイゴ㈱得意先電子元帳「地区」と「分析コード」を追加する。</br>
        /// <br>Update Note : K2015/11/17  周健</br>
        /// <br>            : 得意先電子元帳  Redmine#47636　#6不具合の対応</br>
        /// <br>            : 設定情報を更新しない場合、設定前のxmlファイルと比較値が変わっているの障害対応</br>
        private void createGridPatternString(bool isSlip, out string patternString)
        {
            patternString = string.Empty;

            if (isSlip)
            {
                #region 伝票グリッド
                
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                //string[] gridHeaderPattern = new string[32];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL

                Infragistics.Win.UltraWinGrid.ColumnsCollection col = this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                string[] gridHeaderPattern = new string[col.Count];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD

                //if (col[0].Header.Caption == "
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in col)
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                    # region // DEL
                    //switch (column.Header.Caption)
                    //{
                    //    case "伝票日付":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[0] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[0] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "伝票番号":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[1] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[1] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "区分":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[2] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[2] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "担当者名":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[3] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[3] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "金額":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[4] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[4] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "消費税":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[5] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[5] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "粗利":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[6] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[6] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "類別番号":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[7] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[7] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "車種":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[8] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[8] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "年式":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[9] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[9] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "車台No":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[10] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[10] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "型式":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[11] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[11] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "備考１":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[12] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[12] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "備考２":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[13] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[13] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "備考３":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[14] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[14] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "受注者":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[15] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[15] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "発行者":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[16] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[16] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "得意先コード":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[17] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[17] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "得意先名":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[18] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[18] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "得意先注番":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[19] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[19] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "管理No":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[20] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[20] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "計上元受注No":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[21] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[21] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "計上先出荷No":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[22] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[22] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "UOEリマーク1":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[23] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[23] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "UOEリマーク2":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[24] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[24] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "拠点":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[25] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[25] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "カラー名称":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[26] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[26] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "トリム名称":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[27] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[27] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "得意先伝票番号":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[28] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[28] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "計上日":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[29] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[29] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "売掛区分":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[30] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[30] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "赤伝区分":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[31] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[31] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    default: break;
                    //}
                    # endregion
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD

                    //----- DEL K2015/11/17  周健　Redmine#47636　#6不具合の対応--------->>>>>
                    //----- ADD K2015/07/15 陳亮 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する----->>>>>
                    //if (_opt_Toua == (Int32)Option.OFF && column.Key == CL_CARMAKERCODE_NAME) continue;

                    //if (_opt_Meigo == (Int32)Option.OFF)
                    //{

                    //    if (column.Key == SALESAREA_NAME || column.Key == CUSTANALYSCODE1_NAME || column.Key == CUSTANALYSCODE2_NAME || column.Key == CUSTANALYSCODE3_NAME ||
                    //        column.Key == CUSTANALYSCODE4_NAME || column.Key == CUSTANALYSCODE5_NAME || column.Key == CUSTANALYSCODE6_NAME)
                    //    {
                    //        continue;
                    //    }
                    //}
                    //----- ADD K2015/07/15 陳亮 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する-----<<<<<
                    //----- DEL K2015/11/17  周健　Redmine#47636　#6不具合の対応---------<<<<<

                    if ( _columnIndexDicOfSlip.ContainsKey( column.Key ) )
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.27 DEL
                        //if ( column.Hidden )
                        //{
                        //    gridHeaderPattern[_columnIndexDicOfSlip[column.Key]] = "1" + column.Header.VisiblePosition.ToString().PadLeft( 2, '0' );
                        //}
                        //else
                        //{
                        //    gridHeaderPattern[_columnIndexDicOfSlip[column.Key]] = "0" + column.Header.VisiblePosition.ToString().PadLeft( 2, '0' );
                        //}
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.27 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.27 ADD
                        if ( column.Hidden )
                        {
                            gridHeaderPattern[_columnIndexDicOfSlip[column.Key]] = "1" + column.Header.VisiblePosition.ToString().PadLeft( ct_ColumnCountLength, '0' );
                        }
                        else
                        {
                            gridHeaderPattern[_columnIndexDicOfSlip[column.Key]] = "0" + column.Header.VisiblePosition.ToString().PadLeft( ct_ColumnCountLength, '0' );
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.27 ADD
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                }

                // 列の順に並ぶように文字列を作成（順番が異なると正常に修正できない）
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                //for (int i = 0; i < 32; i++)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                for ( int i = 0; i < col.Count; i++ )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                {
                    patternString = patternString + gridHeaderPattern[i];
                }

                #endregion // 伝票グリッド
            }
            else
            {
                #region 明細グリッド

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                //string[] gridHeaderPattern = new string[57];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL

                // UIに表示されている情報はDisplayLayoutから取る必要がある
                Infragistics.Win.UltraWinGrid.ColumnsCollection col = this.uGrid_ColumnItemSelector2.DisplayLayout.Bands[0].Columns;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                string[] gridHeaderPattern = new string[col.Count];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD

                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in col)
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                    # region // DEL
                    //switch (column.Header.Caption)
                    //{
                    //    case "伝票日付":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[0] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[0] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "伝票番号":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[1] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[1] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "行No":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[2] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[2] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "区分":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[3] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[3] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "担当者名":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[4] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[4] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "品名":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[5] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[5] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "品番":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[6] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[6] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "BLｺｰﾄﾞ":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[7] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[7] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "BLｸﾞﾙｰﾌﾟ":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[8] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[8] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "数量":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[9] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[9] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "標準価格":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[10] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[10] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "単価":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[11] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[11] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "原価":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[12] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[12] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "金額":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[13] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[13] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "消費税":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[14] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[14] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "粗利":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[15] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[15] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "類別番号":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[16] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[16] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "車種":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[17] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[17] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "年式":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[18] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[18] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "車台No":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[19] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[19] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "型式":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[20] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[20] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "備考１":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[21] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[21] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "備考２":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[22] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[22] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "備考３":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[23] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[23] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "受注者":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[24] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[24] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "発行者":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[25] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[25] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "得意先コード":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[26] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[26] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "得意先名":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[27] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[27] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "仕入先コード":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[28] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[28] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "仕入先":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[29] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[29] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "得意先注番":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[30] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[30] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "管理No":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[31] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[31] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "計上元受注No":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[32] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[32] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "計上先出荷No":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[33] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[33] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "元黒No":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[34] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[34] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "在庫取寄区分":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[35] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[35] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "倉庫":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[36] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[36] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "同時仕入No":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[37] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[37] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "発注先コード":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[38] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[38] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "発注先":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[39] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[39] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "UOEリマーク１":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[40] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[40] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "UOEリマーク２":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[41] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[41] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "販売区分":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[42] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[42] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "拠点":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[43] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[43] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "明細備考":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[44] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[44] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "カラー名":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[45] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[45] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "トリム名":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[46] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[46] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "算出価格":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[47] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[47] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "算出売価":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[48] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[48] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "算出原価":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[49] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[49] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "メーカーコード":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[50] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[50] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "メーカー":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[51] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[51] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "原価（粗利）":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[52] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[52] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "得意先伝票番号":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[53] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[53] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "計上日":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[54] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[54] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "売掛区分":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[55] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[55] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    case "赤伝区分":
                    //        {
                    //            if (column.Hidden)
                    //                gridHeaderPattern[56] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            else
                    //                gridHeaderPattern[56] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
                    //            break;
                    //        }
                    //    default: break;
                    //}
                    # endregion
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD

                    //----- DEL K2015/11/17  周健　Redmine#47636　#6不具合の対応--------->>>>>
                    //if (_opt_Momose == (Int32)Option.OFF && column.Key == CL_SECONDSALEPRICE_NAME) continue;//ADD K2015/11/13 陳艶丹 モモセ部品㈱の個別開発依頼:得意先電子元帳「第二売価」を追加する
                    ////----- ADD K2015/07/15 陳亮 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する----->>>>>
                    //if (_opt_Meigo == (Int32)Option.OFF)
                    //{

                    //    if (column.Key == SALESAREA_NAME || column.Key == CUSTANALYSCODE1_NAME || column.Key == CUSTANALYSCODE2_NAME || column.Key == CUSTANALYSCODE3_NAME ||
                    //        column.Key == CUSTANALYSCODE4_NAME || column.Key == CUSTANALYSCODE5_NAME || column.Key == CUSTANALYSCODE6_NAME)
                    //    {
                    //        continue;
                    //    }
                    //}
                    ////----- ADD K2015/07/15 陳亮 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する-----<<<<<
                    //----- DEL K2015/11/17  周健　Redmine#47636　#6不具合の対応---------<<<<<
                    if ( _columnIndexDicOfDetail.ContainsKey( column.Key ) )
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.27 DEL
                        //if ( column.Hidden )
                        //{
                        //    gridHeaderPattern[_columnIndexDicOfDetail[column.Key]] = "1" + column.Header.VisiblePosition.ToString().PadLeft( 2, '0' );
                        //}
                        //else
                        //{
                        //    gridHeaderPattern[_columnIndexDicOfDetail[column.Key]] = "0" + column.Header.VisiblePosition.ToString().PadLeft( 2, '0' );
                        //}
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.27 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.27 ADD
                        if ( column.Hidden )
                        {
                            gridHeaderPattern[_columnIndexDicOfDetail[column.Key]] = "1" + column.Header.VisiblePosition.ToString().PadLeft( ct_ColumnCountLength, '0' );
                        }
                        else
                        {
                            gridHeaderPattern[_columnIndexDicOfDetail[column.Key]] = "0" + column.Header.VisiblePosition.ToString().PadLeft( ct_ColumnCountLength, '0' );
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.27 ADD
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                }

                // 列の順に並ぶように文字列を作成（順番が異なると正常に修正できない）
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                //for (int i = 0; i < 57; i++)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                for (int i = 0; i < col.Count; i++)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                {
                    patternString = patternString + gridHeaderPattern[i];
                }

                #endregion // 明細グリッド
            }
        }

        /// <summary>
        /// 基本パターンを追加
        /// </summary>
        /// <param name="outputStyle"></param>
        /// <param name="patternString"></param>
        /// <param name="addPattern"></param>
        /// <remarks>
        /// <br>Update Note: 2015/09/17 田建委</br>
        /// <br>管理番号   : 11170170-00</br>
        /// <br>           : Redmine#47006 現行保障をするため画面に区分を設ける</br>
        /// </remarks>
        private void createPatternStringNonCustom(int outputStyle, out string patternString, bool addPattern)
        {

            patternString = string.Empty;
            string selectedPatternName = string.Empty;
            string value01 = string.Empty;
            string value02 = string.Empty;
            string value03 = string.Empty;
            string value04 = string.Empty;
            string value05 = string.Empty;
            string value06 = string.Empty;
            string value07 = string.Empty;
            string value08 = string.Empty;
            string value09 = string.Empty;
            string value10 = string.Empty;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
            string value11 = string.Empty;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

            string value12 = string.Empty; // ADD 2015/09/17 田建委 Redmine#47006
            string value13 = string.Empty; // ADD 2015/09/17 田建委 Redmine#47006
            string value14 = string.Empty; // ADD 2015/09/17 田建委 Redmine#47006

            switch (outputStyle)
            {
                case 0:
                    {
                        selectedPatternName = "テキスト出力パターン1";
                        value01 = "1";
                        value02 = ",";
                        value03 = "0";
                        value04 = string.Empty;
                        value05 = "0";
                        value06 = "0";
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
                        //value07 = "1";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                        value07 = "0";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                        value08 = string.Empty;
                        value09 = string.Empty;
                        value10 = "0";
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                        value11 = "1";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                        value12 = "0"; // ADD 2015/09/17 田建委 Redmine#47006
                        value13 = "1"; // ADD 2015/09/17 田建委 Redmine#47006
                        value14 = "1"; // ADD 2015/09/17 田建委 Redmine#47006
                        break;
                    }
                case 1:
                    {
                        selectedPatternName = "テキスト出力パターン2";
                        value01 = "0";
                        value02 = string.Empty;
                        value03 = "0";
                        value04 = string.Empty;
                        value05 = "0";
                        value06 = "0";
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
                        //value07 = "1";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                        value07 = "0";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                        value08 = string.Empty;
                        value09 = string.Empty;
                        value10 = "1";
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                        value11 = "1";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                        value12 = "0"; // ADD 2015/09/17 田建委 Redmine#47006
                        value13 = "1"; // ADD 2015/09/17 田建委 Redmine#47006
                        value14 = "1"; // ADD 2015/09/17 田建委 Redmine#47006
                        break;
                    }
                case 2:
                    {
                        selectedPatternName = "テキスト出力パターン3";
                        value01 = "1";
                        value02 = " ";
                        value03 = "0";
                        value04 = string.Empty;
                        value05 = "0";
                        value06 = "0";
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
                        //value07 = "1";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                        value07 = "0";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                        value08 = string.Empty;
                        value09 = string.Empty;
                        value10 = "2";
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                        value11 = "1";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                        value12 = "0"; // ADD 2015/09/17 田建委 Redmine#47006
                        value13 = "1"; // ADD 2015/09/17 田建委 Redmine#47006
                        value14 = "1"; // ADD 2015/09/17 田建委 Redmine#47006
                        break;
                    }

                default: break;
            }

            //----- DEL K2014/06/04 By 呉軍 Redmine42764 №8 -------->>>>>
            ////----- ADD K2014/05/28 By 林超凡 Redmine#42764 受入テスト障害対応 BEGIN--------->>>>>
            //// 東亜商会制御オプションは「ON」の場合、東亜商会用コードを設定します
            //if (this._opt_Toua == Convert.ToInt32(Option.ON))
            //{
            //    value08 = XML_SLIP_CODE_TOUA;
            //    value09 = XML_DETAIL_CODE_TOUA;
            //}
            ////----- ADD K2014/05/28 By 林超凡 Redmine#42764 受入テスト障害対応 END---------<<<<<
            //----- DEL K2014/06/04 By 呉軍 Redmine42764 №8 --------<<<<

            patternString = selectedPatternName + this._divider +
                value01 + this._divider + value02 + this._divider +
                value03 + this._divider + value04 + this._divider +
                value05 + this._divider + value06 + this._divider +
                value07 + this._divider + value08 + this._divider +
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
                //value09 + this._divider + value10;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                value09 + this._divider + value10 + this._divider +
                //value11; // DEL 2015/09/17 田建委 Redmine#47006
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

                //----- ADD 2015/09/17 田建委 Redmine#47006 ---------->>>>>
                value11 + this._divider +
                value12 + this._divider +
                value13 + this._divider +
                value14;
                //----- ADD 2015/09/17 田建委 Redmine#47006 ----------<<<<<


            if (addPattern)
            {

                string[] newOutputPattern;

                if (this._outputPattern == null)
                {
                    newOutputPattern = new string[1];
                    newOutputPattern[0] = patternString;
                    this._outputPattern = newOutputPattern;
                }
                else
                {
                    bool exists = false;
                    string pName = string.Empty;
                    int count = 0;

                    // 既存でないか検査
                    foreach (string pattern in this._outputPattern)
                    {
                        // 最初の区切り文字までがパターン名
                        if (pattern.Contains(this._divider))
                        {
                            pName = pattern.Substring(0, pattern.IndexOf(this._divider));
                            //if (pName == this._selectedPattern)
                            if (pName == selectedPatternName)
                            {
                                this._outputPattern[count] = patternString;
                                exists = true;
                                break;
                            }
                        }
                        count++;
                    }

                    if (exists)
                    {
                        // 更新
                        this._userSetting.OutputPattern = this._outputPattern;
                    }
                    else
                    {
                        newOutputPattern = new string[this._outputPattern.Length + 1];
                        count = 0;
                        foreach (string pattern in _outputPattern)
                        {
                            newOutputPattern[count] = pattern;
                            count++;
                        }
                        newOutputPattern[count] = patternString;

                        // 追加
                        this._outputPattern = newOutputPattern;
                        this._userSetting.OutputPattern = newOutputPattern;
                    }
                }
            }
        }
        #endregion // プライベート関数

        #region ユーザー設定の保存・読み込み

        /// <summary>データ変更後発生イベント</summary>
        public event EventHandler DataChanged;

        /// <summary>
        /// 得意先電子元帳用ユーザー設定シリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先電子元帳用ユーザー設定のシリアライズを行います。</br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        /// <br>Update Note: 2010/06/08 呉元嘯 テキスト出力先が保存されない不具合の対応</br>
        /// </remarks>
        public void Serialize()
        {
            try
            {
                // ----------UPD 2010/06/08 ----------->>>>>
                //UserSettingController.SerializeUserSetting( _userSetting, Path.Combine( ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME ) );
                UserSettingController.SerializeUserSetting(_userSetting, Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
                // ----------UPD 2010/06/08 -----------<<<<<
            }
            catch(Exception ex)
            {
                MessageBox.Show( ex.InnerException.Message );
            }

            if (DataChanged != null)
            {
                // データ変更後発生イベント実行
                DataChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// 得意先電子元帳用ユーザー設定デシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先電子元帳用ユーザー設定クラスをデシリアライズします。</br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        /// <br>Update Note: 2010/06/08 呉元嘯 テキスト出力先が保存されない不具合の対応</br>
        /// <br>Update Note: K2014/05/28 林超凡 </br>
        /// <br>           : Redmine#42764 受入テスト障害対応。東亜商会個別対応</br>
        /// <br>Update Note: K2015/4/27 陳亮</br>
        /// <br>           : 11100842-00 モモセ部品㈱の個別開発依頼
        /// <br>           : 得意先電子元帳第二売価を追加する。モモセ部品㈱オプションが有効の場合のみ。</br>
        /// <br>Update Note: K2015/06/16 鮑晶</br>
        /// <br>管理番号   : 11101427-00</br>
        /// <br>           : メイゴ㈱得意先電子元帳「地区」と「分析コード」を追加する。</br>
        /// </remarks>
        public void Deserialize()
        {
            // -----------UPD 2010/06/08------------>>>>>
            //if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME))))
            // -----------UPD 2010/06/08------------<<<<<
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                try
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                {
                    // -----------UPD 2010/06/08------------>>>>>
                    //this._userSetting = UserSettingController.DeserializeUserSetting<CustPtrSalesUserConst>( Path.Combine( ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME ) );
                    this._userSetting = UserSettingController.DeserializeUserSetting<CustPtrSalesUserConst>(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
                    // -----------UPD 2010/06/08------------<<<<<

                    //----- ADD K2014/05/28 By 林超凡 Redmine#42764 受入テスト障害対応 BEGIN--------->>>>>
                    if (this._opt_Toua == Convert.ToInt32(Option.ON))
                    {
                        try
                        {
                            if (this._userSetting != null &&
                                this._userSetting.SlipColumnsList != null &&
                                this._userSetting.SlipColumnsList.Count != 0)
                            {
                                List<ColumnInfo> slipColumnList = this._userSetting.SlipColumnsList;
                                //XMLファイルは最新かどうか判断フラグ
                                bool isNewXmlFile = false;
                                foreach (ColumnInfo columnInfo in slipColumnList)
                                {
                                    if (columnInfo.ColumnName.Equals(CL_CARMAKERCODE_NAME))
                                    {
                                        isNewXmlFile = true;
                                        break;
                                    }
                                }
                                if (!isNewXmlFile && File.Exists(XML_FILE_PATH + XML_FILE_NAME))
                                {
                                    File.Delete(XML_FILE_PATH + XML_FILE_NAME);
                                    this._userSetting = new CustPtrSalesUserConst();
                                    InitializeUserSetting(ref _userSetting);
                                    return;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            //処理不要
                        }
                    }
                    //----- ADD K2014/05/28 By 林超凡 Redmine#42764 受入テスト障害対応 END---------<<<<<

                    // ---- ADD K2015/04/29 陳亮 モモセ部品の第二売価追加 ---->>>>>
                    if (this._opt_Momose == Convert.ToInt32(Option.ON))
                    {
                        if (this._userSetting != null &&
                            this._userSetting.DetailColumnsList != null &&
                            this._userSetting.DetailColumnsList.Count != 0)
                        {
                            //存在列のチェック
                            if (!CheckExistColumn(CL_SECONDSALEPRICE_NAME))
                            {
                                return;
                            }
                        }
                    }
                    // ---- ADD K2015/04/29 陳亮 モモセ部品の第二売価追加 ----<<<<<
                    
                    //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する----->>>>>
                    if (this._opt_Meigo == Convert.ToInt32(Option.ON))
                    {
                        if (this.MeigoCheckColumn()) {
                            return;
                        }
                    }
                    //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する-----<<<<<
                   
                    // ---------- ADD 2012/08/22 ---------->>>>>
                    // 仕入日のユーザー設定の補完処理
                    int index = -1;
                    int StockPartySaleSlipNumVP = 1;
                    bool StockDateflg = false;

                    for (int i = 0; i < this._userSetting.RedSlipColumnsList.Count; i++)
                    {
                        if (this._userSetting.RedSlipColumnsList[i].ColumnName == "StockPartySaleSlipNum")
                        {
                            // 仕入伝票番号のインデックスと並び順を取得
                            index = i;
                            StockPartySaleSlipNumVP = this._userSetting.RedSlipColumnsList[i].VisiblePosition;
                        }

                        if (this._userSetting.RedSlipColumnsList[i].ColumnName == "StockDate")
                        {
                            // 仕入日の設定が存在している
                            StockDateflg = true;
                            break;
                        }
                    }

                    // 仕入伝票番号の設定が存在していて、仕入日の設定が存在していなかったら
                    if (index > -1 && StockDateflg != true)
                    {
                        // 仕入伝票番号以降の並び順の再設定
                        for (int j = 0; j < this._userSetting.RedSlipColumnsList.Count; j++)
                        {
                            if (this._userSetting.RedSlipColumnsList[j].VisiblePosition > StockPartySaleSlipNumVP)
                            {
                                ColumnInfo tempRedSlipColumnsList = this._userSetting.RedSlipColumnsList[j];

                                // 仕入日を挿入するため、並び順を1つ後ろにずらす
                                tempRedSlipColumnsList.VisiblePosition = this._userSetting.RedSlipColumnsList[j].VisiblePosition + 1;

                                this._userSetting.RedSlipColumnsList[j] = tempRedSlipColumnsList;
                            }
                        }

                        // 仕入伝票番号の後に仕入日を初期設定値で挿入
                        this._userSetting.RedSlipColumnsList.Insert(index + 1, new ColumnInfo("StockDate", StockPartySaleSlipNumVP + 1, false, 130, false));
                    }
                    // ---------- ADD 2012/08/22 ----------<<<<<
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                catch
                {
                    this._userSetting = new CustPtrSalesUserConst();
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
            }
        }

                // ---- ADD K2015/04/29 陳亮 テキスト出力項目に第二売価を追加する ---->>>>>
        /// <summary>
        /// XMLファイルは最新かどうか判断フラグ
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <returns>存在列のチェック true:存在する　false:存在なし</returns>
        /// <remarks>
        /// <br>Note		: 得意先電子元帳第二売価を追加する。</br>
        /// <br>Programmer	: 陳亮</br>
        /// <br>Date		: K2015/04/29</br>
        /// <br>管理番号    : 11100842-00 モモセ部品㈱の個別開発依頼</br>
        /// </remarks>
        private bool CheckExistColumn(string columnName)
        {
            // 存在フラグ (true:存在する　false:存在なし)
            bool isExist = false;

            try
            {
                List<ColumnInfo> detailColumnList = this._userSetting.DetailColumnsList;

                foreach (ColumnInfo columnInfo in detailColumnList)
                {
                    if (columnInfo.ColumnName.Equals(columnName))
                    {
                        isExist = true;
                        break;
                    }
                }
                if (!isExist && File.Exists(Path.Combine(XML_FILE_PATH, XML_FILE_NAME)))
                {
                    File.Delete(Path.Combine(XML_FILE_PATH, XML_FILE_NAME));
                    this._userSetting = new CustPtrSalesUserConst();
                    InitializeUserSetting(ref _userSetting);
                }
            }
            catch (Exception)
            {
                //処理不要
            }

            return isExist;
        }

        //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する----->>>>>
        #region メイゴ㈱オプション
        /// <summary>
        /// メイゴ㈱オプション
        /// </summary>
        /// <remark>
        /// <br>Note		: メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する</br>
        /// <br>管理番号    : 11101427-00</br>
        /// <br>Programmer	: 鮑晶</br>
        /// <br>Date		: K2015/06/16</br>
        /// </remark>
        private bool MeigoCheckColumn()
        {
            bool returnFlag = false;
            // 存在フラグ (true:存在する　false:存在なし)
            bool existAllFlag = false;
            try
            {
                if (this._userSetting != null &&
                    this._userSetting.SlipColumnsList != null &&
                    this._userSetting.SlipColumnsList.Count != 0)
                {
                    //地区
                    Boolean checkArea = false;
                    //分析コード1
                    Boolean checkCustanalysCode1 = false;
                    //分析コード2
                    Boolean checkCustanalysCode2 = false;
                    //分析コード3
                    Boolean checkCustanalysCode3 = false;
                    //分析コード4
                    Boolean checkCustanalysCode4 = false;
                    //分析コード5
                    Boolean checkCustanalysCode5 = false;
                    //分析コード6
                    Boolean checkCustanalysCode6 = false;
                    List<ColumnInfo> slipColumnList = this._userSetting.SlipColumnsList;
                    //XMLファイルは最新かどうか判断フラグ
                    foreach (ColumnInfo columnInfo in slipColumnList)
                    {
                        if (columnInfo.ColumnName.Equals(SALESAREA_NAME))
                        {
                            checkArea = true;
                        }
                        if (columnInfo.ColumnName.Equals(CUSTANALYSCODE1_NAME))
                        {
                            checkCustanalysCode1 = true;
                        }
                        if (columnInfo.ColumnName.Equals(CUSTANALYSCODE2_NAME))
                        {
                            checkCustanalysCode2 = true;
                        }
                        if (columnInfo.ColumnName.Equals(CUSTANALYSCODE3_NAME))
                        {
                            checkCustanalysCode3 = true;
                        }
                        if (columnInfo.ColumnName.Equals(CUSTANALYSCODE4_NAME))
                        {
                            checkCustanalysCode4 = true;
                        }
                        if (columnInfo.ColumnName.Equals(CUSTANALYSCODE5_NAME))
                        {
                            checkCustanalysCode5 = true;
                        }
                        if (columnInfo.ColumnName.Equals(CUSTANALYSCODE6_NAME))
                        {
                            checkCustanalysCode6 = true;
                        }
                        if (checkArea && checkCustanalysCode1 && checkCustanalysCode2 && checkCustanalysCode3 && checkCustanalysCode4 && checkCustanalysCode5 && checkCustanalysCode6)
                        {
                            existAllFlag = true;
                            break;
                        }
                    }
                    if (!existAllFlag && File.Exists(Path.Combine(XML_FILE_PATH, XML_FILE_NAME)))
                    {
                        File.Delete(Path.Combine(XML_FILE_PATH, XML_FILE_NAME));
                        this._userSetting = new CustPtrSalesUserConst();
                        InitializeUserSetting(ref _userSetting);
                        returnFlag = true;
                    }
                }
            }
            catch (Exception)
            {
                return returnFlag;
            }
            return returnFlag;
        }
        #endregion
        //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する-----<<<<<

        /// <summary>
        /// 得意先電子元帳用ユーザー設定 設定内容分解処理
        /// </summary>
        public void Degradation(string selectedSettingName, out string[] patternValue)
        {
            // 設定されたパターン名(基本的に引数と同じになる)
            if (String.IsNullOrEmpty(selectedSettingName))
            {
                selectedSettingName = this._userSetting.SelectedPatternName;
            }

            // パターンおよび区切り文字を取得
            this._outputPattern = this._userSetting.OutputPattern;
            this._divider = this._userSetting.DIVIDER;

            string pName = string.Empty;
            //string[] 
            patternValue = new string[9];

            // パターンの構成
            // 区切り文字(タブ・任意・固定長）/区切り文字任意/  0-1
            // 括り文字(”・任意）/括り文字任意/                2-3
            // 数値括り（する／しない)                          4
            // 文字括り（する／しない)                          5
            // タイトル行（あり／なし）                         6
            // 伝票出力項目リスト (32項目x3文字) 基本的に表示順の数字,非表示の場合は+100, 必ずExportColumnDataSet.SalesListの順に並んでいる   7
            // 明細出力項目リスト (57項目x3文字) 基本的に表示順の数字,非表示の場合は+100, 必ずExportColumnDataSet.SalesDetailの順に並んでいる 8

            // 取得したパターンを分解し、パターン名のリストを作成
            foreach (string pattern in this._outputPattern)
            {
                // 最初の区切り文字までがパターン名
                if (pattern.Contains(this._divider))
                {
                    pName = pattern.Substring(0, pattern.IndexOf(this._divider));
                    // 要求されたパターンか？
                    if (pName == selectedSettingName)
                    {
                        getPatternValue(pattern.Substring(pattern.IndexOf(this._divider) + 1), out patternValue);
                    }
                }
            }
        }

        /// <summary>
        /// カラム名のリスト取得
        /// </summary>
        /// <param name="sourceStr"></param>
        /// <param name="isSlip"></param>
        /// <returns></returns>
        public List<String> GetColumnNameList(string sourceStr, bool isSlip)
        {
            List<String> columnList;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
            //if (isSlip)
            //{
            //    columnList = new List<String>();//[32];
            //    string[] p = new string[32];
            //    getGridSettingPattern( sourceStr, out p, true );

            //    for ( int i = 0; i < 32; i++ )
            //    {
            //        columnList.Add( p[i] );
            //    }
            //}
            //else
            //{
            //    columnList = new List<String>();//[57];
            //    string[] p = new string[57];
            //    getGridSettingPattern( sourceStr, out p, true );

            //    for ( int i = 0; i < 57; i++ )
            //    {
            //        columnList.Add( p[i] );
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
            columnList = new List<String>();
            string[] p;
            getGridSettingPattern( sourceStr, out p, true );

            for ( int i = 0; i < p.Length; i++ )
            {
                columnList.Add( p[i] );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD

            return columnList;
        }

        #endregion // ユーザー設定の保存・読み込み

        #region イベント

        /// <summary>
        /// 出力形式変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_OutputStyle_ValueChanged(object sender, EventArgs e)
        {
            // 選択値
            string selected = this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString();
            string fileName = this.tEdit_SettingFileName.Text.Trim();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
            //string ext = string.Empty;
            //if (fileName.Length > 4) ext = fileName.Substring(fileName.Length - 4, 4);

            //string newExt = string.Empty;
            //switch (selected)
            //{
            //    case "0": newExt = ".CSV"; break;
            //    case "1": newExt = ".TXT"; break;
            //    case "2": newExt = ".PRN"; break;
            //    case "3": newExt = ext; break;
            //    default:break;
            //}
            //if (fileName.Length > 4)
            //{
                
            //    if (ext.Contains("."))
            //    {
            //        if (ext.ToLower() == ".txt" || ext.ToLower() == ".prn" || ext.ToLower() == ".csv")
            //        {
            //            fileName = fileName.ToUpper().Replace(".TXT", newExt).Replace(".PRN", newExt).Replace(".CSV", newExt);
            //        }
            //    }
            //    else if (fileName.Contains("."))
            //    {
            //        fileName = fileName.Substring(1, fileName.IndexOf(".", 1)) + newExt;
            //    }
            //    else
            //    {
            //        fileName = fileName + newExt;
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
            fileName = CustPtrSalesUserConst.ChangeFileExtension( fileName, selected );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
            this.tEdit_SettingFileName.Text = fileName;

            // カスタムのときのみ有効
            bool val = (this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString() == "3");

            // 項目を調整
            //this.uOptionSet_DividerChar.Enabled = val;
            this.pn_DividerChar.Enabled = val;
            //this.uOptionSet_Parenthesis.Enabled = val;
            this.pn_Parenthesis.Enabled = val;
            //this.uOptionSet_TieChar.Enabled = val;
            this.pn_TieChar.Enabled = val;
            //this.uOptionSet_TieNumeric.Enabled = val;
            this.pn_TieNumeric.Enabled = val;
            //this.uOptionSet_TitleLine.Enabled = val;
            this.pn_TitleLine.Enabled = val;

            this.tEdit_DividerChar.Enabled = val;
            this.tEdit_ParenthesisChar.Enabled = val;

            //this.uComboEditor_OutputType.Enabled = val;

            //this.uGrid_ColumnItemSelector.Enabled = val;
            //this.uGrid_ColumnItemSelector2.Enabled = val;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
            //if (val) this.uComboEditor_PetternSelect.Text = string.Empty;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
        }

        /// <summary>
        /// 出力タイプ変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2015/09/17 田建委</br>
        /// <br>管理番号   : 11170170-00</br>
        /// <br>           : Redmine#47006 現行保障をするため画面に区分を設ける</br>
        /// </remarks>
        private void tComboEditor_OutputType_ValueChanged(object sender, EventArgs e)
        {

            if ( this.tComboEditor_OutputType.SelectedItem == null ||
                 this.tComboEditor_OutputType.SelectedItem.DataValue.ToString() == "0" ) //伝票
            {
                this.uGrid_ColumnItemSelector.Visible = true;
                this.uGrid_ColumnItemSelector2.Visible = false;

                // ----- ADD 2015/09/17 田建委 Redmine#47006 ----->>>>>
                this.uCheckEditor_RetSlipMinus_Meisai.Visible = false;
                this.uCheckEditor_RetSlipMinus_Meisai.Enabled = false;
                this.uCheckEditor_RetSlipMinus_Saleslip.Enabled = true;
                this.uCheckEditor_RetSlipMinus_Saleslip.Visible = true;
                // ----- ADD 2015/09/17 田建委 Redmine#47006 -----<<<<<
            }
            else
            {
                this.uGrid_ColumnItemSelector.Visible = false;
                this.uGrid_ColumnItemSelector2.Visible = true;

                // ----- ADD 2015/09/17 田建委 Redmine#47006 ----->>>>>
                this.uCheckEditor_RetSlipMinus_Meisai.Enabled = true;
                this.uCheckEditor_RetSlipMinus_Meisai.Visible = true;
                this.uCheckEditor_RetSlipMinus_Saleslip.Visible = false;
                this.uCheckEditor_RetSlipMinus_Saleslip.Enabled = false;
                // ----- ADD 2015/09/17 田建委 Redmine#47006 -----<<<<<
            }
        }

        /// <summary>
        /// 元号表示変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_DateType_ValueChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// パターン変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uComboEditor_PetternSelect_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            if ( tComboEditor_PetternSelect.SelectedItem != null )
            {
                this._selectedPattern = this.tComboEditor_PetternSelect.SelectedItem.DataValue.ToString();
                getSelectedPattern();
            }
        }

        #endregion // イベント

        #region ボタン

        /// <summary>
        /// キャンセルボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Cancel_Click(object sender, EventArgs e)
        {
            //string str = string.Empty;
            //createGridPatternString(true, out str);
            //createGridPatternString(false, out str);

            //return;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
            //// シリアライズ
            //this.Serialize();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
            this.DialogResult = DialogResult.Cancel;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD

            this.Close();
        }

        /// <summary>
        /// OKボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2018/09/04 譚洪</br>
        /// <br>管理番号   : 11470152-00</br>
        /// <br>           : 履歴自動表示機能追加対応</br>
        /// </remarks>
        private void uButton_OK_Click(object sender, EventArgs e)
        {
            // チェック
            if (!checkValues())
            {
                return;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
            if ( Int32.Parse( this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString() ) == 3 )
            {
                renewalOutputPattern(false);
                this._userSetting.OutputStyle = 3;
            }
            else 
            {
                renewalOutputPattern(false);
                this._userSetting.OutputStyle = Int32.Parse( this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString() );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
            renewalOutputPattern( false );
            this._userSetting.OutputStyle = Int32.Parse( this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString() );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

            // ファイル名
            this._userSetting.OutputFileName = this.tEdit_SettingFileName.Text.Trim();

            //----- ADD 2015/02/25 王亜楠 Redmine#44701 No.1 -------------------->>>>>
            if (this.uCheckEditor_NoCountCtrl.Checked)
            {
                _userSetting.SearchCountCtrl = 1;
            }
            else
            {
                _userSetting.SearchCountCtrl = 0;
            }
            //----- ADD 2015/02/25 王亜楠 Redmine#44701 No.1 --------------------<<<<<

            // パターン名
            this._userSetting.SelectedPatternName = this.tComboEditor_PetternSelect.Text.Trim();

            // 赤伝発行タブの内容
            //this._userSetting.SlipNote1Pattern = this.uOptionSet_SlipNote.CheckedIndex;
            this._userSetting.SlipNote1Pattern = this.SlipNote;
            this._userSetting.SlipNote1Default = this.tEdit_SlipNote.Text.Trim();
            //this._userSetting.SlipNote2Pattern = this.uOptionSet_SlipNote2.CheckedIndex;
            this._userSetting.SlipNote2Pattern = this.SlipNote2;
            this._userSetting.SlipNote2Default = this.tEdit_SlipNote2.Text.Trim();
            //this._userSetting.SlipNote3Pattern = this.uOptionSet_SlipNote3.CheckedIndex;
            this._userSetting.SlipNote3Pattern = this.SlipNote3;
            this._userSetting.SlipNote3Default = this.tEdit_SlipNote3.Text.Trim();
            // ADD 2013/04/19 T.Miyamoto ------------------------------>>>>>
            this._userSetting.RedPrintDialog = this.RedPrintDialog;
            this._userSetting.ReisssuePrintDialog = this.ReisssuePrintDialog;
            // ADD 2013/04/19 T.Miyamoto ------------------------------<<<<<

            // -----------ADD 2009/12/28------------>>>>>
            this._userSetting.AllowRowFiltering = this.tComboEditor_AllowRowFiltering.SelectedIndex;
            this._userSetting.AllowColSwapping = this.tComboEditor_AllowColSwapping.SelectedIndex;
            this._userSetting.FixedHeaderIndicator = this.tComboEditor_FixedHeaderIndicator.SelectedIndex;
            // -----------ADD 2009/12/28------------<<<<<

            // 2010/04/15 Add >>>
            this._userSetting.ClaimeFileName = this.tEdit_ClaimeFileName.Text;
            this._userSetting.ChargeFileName = this.tEdit_ChargeFileName.Text;
            // 2010/04/15 Add <<<
            this._userSetting.InitSelectDisplay = this.InitSelectDisplay;// 2018/09/04 譚洪　履歴自動表示の対応

            // シリアライズ
            this.Serialize();

            // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿対応　-------->>>>>
            if (this._opt_EBooksLink == (int)Option.ON)
            {
                // 電子帳簿連携設定情報保存　
                // PDFプリンタ項目設定情報を書き込み
                WriteEBooksOutputSetting();
            }
            // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿対応　-------<<<<<

            //----- ADD 2015/02/05 王亜楠 -------------------->>>>>
            if (TextOutputEvent != null)
            {
                TextOutputEvent(this, e);
            }
            //----- ADD 2015/02/05 王亜楠 --------------------<<<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
            this.DialogResult = DialogResult.OK;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD

            // 終了
            this.Close();
        }

        /// <summary>
        /// ファイルダイアログ表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_FileSelect_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tEdit_SettingFileName.Text))
            {
                this.openFileDialog.FileName = this.tEdit_SettingFileName.Text.Trim();
            }
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;

            // ファイル選択
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tEdit_SettingFileName.Text = openFileDialog.FileName.ToUpper();
            }
        }

        #endregion // ボタン

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
        /// <summary>
        /// 赤伝設定　備考１初期表示　変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uOptionSet_SlipNote_ValueChanged( object sender, EventArgs e )
        {
            //switch ( (int)uOptionSet_SlipNote.Value )
            switch ( this.SlipNote )
            {
                default:
                // 空白
                case 0:
                    {
                        tEdit_SlipNote.Text = string.Empty;
                        tEdit_SlipNote.Enabled = false;
                    }
                    break;
                // 日付・伝票番号
                case 1:
                    {
                        tEdit_SlipNote.Text = string.Empty;
                        tEdit_SlipNote.Enabled = false;
                    }
                    break;
                // ---------ADD 2010/01/29--------->>>>>
                // 元黒
                case 2:
                    {
                        tEdit_SlipNote.Text = string.Empty;
                        tEdit_SlipNote.Enabled = false;
                    }
                    break;
                // ---------ADD 2010/01/29---------<<<<<
                // 任意
                //case 2:// DEL 2010/01/29
                case 3:// ADD 2010/01/29
                    {
                        tEdit_SlipNote.Enabled = true;
                    }
                    break;
            }
        }
        /// <summary>
        /// 赤伝設定　備考２初期表示　変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uOptionSet_SlipNote2_ValueChanged( object sender, EventArgs e )
        {
            //switch ( (int)uOptionSet_SlipNote2.Value )
            switch ( this.SlipNote2 )
            {
                default:
                // 空白
                case 0:
                    {
                        tEdit_SlipNote2.Text = string.Empty;
                        tEdit_SlipNote2.Enabled = false;
                    }
                    break;
                // 日付・伝票番号
                case 1:
                    {
                        tEdit_SlipNote2.Text = string.Empty;
                        tEdit_SlipNote2.Enabled = false;
                    }
                    break;
                // ---------ADD 2010/01/29--------->>>>>
                // 元黒
                case 2:
                    {
                        tEdit_SlipNote2.Text = string.Empty;
                        tEdit_SlipNote2.Enabled = false;
                    }
                    break;
                // ---------ADD 2010/01/29---------<<<<<
                // 任意
                //case 2:// DEL 2010/01/29
                case 3:// ADD 2010/01/29
                    {
                        tEdit_SlipNote2.Enabled = true;
                    }
                    break;
            }
        }
        /// <summary>
        /// 赤伝設定　備考３初期表示　変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uOptionSet_SlipNote3_ValueChanged( object sender, EventArgs e )
        {
            //switch ( (int)uOptionSet_SlipNote3.Value )
            switch ( this.SlipNote3 )
            {
                default:
                // 空白
                case 0:
                    {
                        tEdit_SlipNote3.Text = string.Empty;
                        tEdit_SlipNote3.Enabled = false;
                    }
                    break;
                // 日付・伝票番号
                case 1:
                    {
                        tEdit_SlipNote3.Text = string.Empty;
                        tEdit_SlipNote3.Enabled = false;
                    }
                    break;
                // ---------ADD 2010/01/29--------->>>>>
                // 元黒
                case 2:
                    {
                        tEdit_SlipNote3.Text = string.Empty;
                        tEdit_SlipNote3.Enabled = false;
                    }
                    break;
                // ---------ADD 2010/01/29---------<<<<<
                // 任意
                //case 2:// DEL 2010/01/29
                case 3:// ADD 2010/01/29
                    {
                        tEdit_SlipNote3.Enabled = true;
                    }
                    break;
            }
        }
        /// <summary>
        /// 設定タブ変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uTabControl_Setting_SelectedTabChanged( object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e )
        {
            switch ( uTabControl_Setting.SelectedTab.Key )
            {
                default:
                    {
                    }
                    break;
                // 赤伝設定
                case "RedSlip":
                    {
                        // 表示更新
                        uOptionSet_SlipNote_ValueChanged( sender, new EventArgs() );
                        uOptionSet_SlipNote2_ValueChanged( sender, new EventArgs() );
                        uOptionSet_SlipNote3_ValueChanged( sender, new EventArgs() );
                    }
                    break;
            }
        }
        /// <summary>
        /// テキスト出力パターン削除ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_PaternDelete_Click( object sender, EventArgs e )
        {
            if ( this.tComboEditor_PetternSelect.SelectedItem == null ) return;

            // 現在選択されているパターンを削除対象とする
            string deletePattern = this.tComboEditor_PetternSelect.SelectedItem.DataValue.ToString();

            // 確認ダイアログ
            if ( TMsgDisp.Show( this, emErrorLevel.ERR_LEVEL_QUESTION, this.Name,
                MSG_CONFIRM_DELETE_PATTERN + Environment.NewLine + Environment.NewLine + string.Format( "出力パターン：{0}", deletePattern ),
                -1, MessageBoxButtons.YesNo ) == DialogResult.No )
            {
                return;
            }

            // 削除
            # region [削除]
            // 現在のパターン一覧をリストに格納する
            List<string> patternList = new List<string>( _outputPattern );
            string pName = string.Empty;

            // 合致するパターン情報を削除
            foreach ( string pattern in this._outputPattern )
            {
                // 最初の区切り文字までがパターン名
                if ( pattern.Contains( this._divider ) )
                {
                    pName = pattern.Substring( 0, pattern.IndexOf( this._divider ) );

                    // 設定されているパターンの場合は内容を取得
                    if ( pName == deletePattern )
                    {
                        patternList.Remove( pattern );
                        break;
                    }
                }
            }
            // 削除後のリスト内容で置き換える
            _outputPattern = patternList.ToArray();
            # endregion

            // 表示更新
            # region [表示更新]
            // 取得したパターンを分解し、パターン名のリストを作成
            this.tComboEditor_PetternSelect.Items.Clear();

            Infragistics.Win.ValueListItem item;
            foreach ( string pattern in this._outputPattern )
            {
                item = new Infragistics.Win.ValueListItem();

                // 最初の区切り文字までがパターン名
                if ( pattern.Contains( this._divider ) )
                {
                    pName = pattern.Substring( 0, pattern.IndexOf( this._divider ) );
                    item.DataValue = pName;
                    item.DisplayText = pName;

                    this.tComboEditor_PetternSelect.Items.Add( item );
                }
            }
            // 最初のパターンを選択する
            if ( tComboEditor_PetternSelect.Items.Count > 0 )
            {
                tComboEditor_PetternSelect.SelectedIndex = 0;
            }
            else
            {
                tComboEditor_PetternSelect.Text = string.Empty;
            }
            # endregion

            //// 結果ダイアログ
            //TMsgDisp.Show( this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
            //    "削除しました。",
            //    -1, MessageBoxButtons.OK );
        }
        /// <summary>
        /// パターンテキスト変更時イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_PetternSelect_ValueChanged( object sender, EventArgs e )
        {
            if ( tComboEditor_PetternSelect.SelectedItem != null )
            {
                // 既存のパターン
                this.uComboEditor_PetternSelect_SelectionChangeCommitted( sender, e );
            }
            else
            {
                // 新規パターン
            }

            // 削除ボタンの有効無効制御
            uButton_PaternDelete.Enabled = (tComboEditor_PetternSelect.SelectedItem != null);
        }
        /// <summary>
        /// 設定ＵＩ初期表示イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKAU04004UA_Shown( object sender, EventArgs e )
        {
            tEdit_SettingFileName.Focus();
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/15 ADD
        /// <summary>
        /// 初期化ボタン（伝票グリッド）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Clear_SlipGrid_Click( object sender, EventArgs e )
        {
            InitializeSlipGrid( ref _userSetting );
            if ( this.ClearSettingSlipGrid != null )
            {
                this.ClearSettingSlipGrid( this, new EventArgs() );
            }
        }
        /// <summary>
        /// 初期化ボタン（明細グリッド）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Clear_DetailGrid_Click( object sender, EventArgs e )
        {
            InitializeDetailGrid( ref _userSetting );
            if ( this.ClearSettingDetailGrid != null )
            {
                this.ClearSettingDetailGrid( this, new EventArgs() );
            }
        }
        /// <summary>
        /// 初期化ボタン（赤伝グリッド）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Clear_RedSlipGrid_Click( object sender, EventArgs e )
        {
            InitializeRedSlipGrid( ref _userSetting );
            if ( this.ClearSettingRedSlipGrid != null )
            {
                this.ClearSettingRedSlipGrid( this, new EventArgs() );
            }
        }
        /// <summary>
        /// 初期化ボタン（残高グリッド）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Clear_BalanceGrid_Click( object sender, EventArgs e )
        {
            InitializeBalanceGrid( ref _userSetting );
            if ( this.ClearSettingBalanceGrid != null )
            {
                this.ClearSettingBalanceGrid( this, new EventArgs() );
            }
        }

        /// <summary>
        /// フォーカス移動イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2015/09/17 田建委</br>
        /// <br>管理番号   : 11170170-00</br>
        /// <br>           : Redmine#47006 現行保障をするため画面に区分を設ける</br>
        /// <br>Update Note: 2018/09/04 譚洪</br>
        /// <br>管理番号   : 11470152-00 履歴自動表示の対応</br>
        /// </remarks>
        private void tArrowKeyControl_ChangeFocus( object sender, ChangeFocusEventArgs e )
        {
            //if ( e.PrevCtrl == null || e.NextCtrl == null ) return;
            if ( e.PrevCtrl == null ) return;

            switch ( e.PrevCtrl.Name )
            {
                # region [テキスト出力]
                case "tEdit_SettingFileName":
                    {
                        # region [次フォーカス]
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if ( !string.IsNullOrEmpty( tEdit_SettingFileName.Text ) )
                                        {
                                            // 次項目
                                            //e.NextCtrl = tComboEditor_PetternSelect; // DEL 2015/02/25 王亜楠 Redmine#44701 No.1
                                            e.NextCtrl = this.uCheckEditor_NoCountCtrl; // ADD 2015/02/25 王亜楠 Redmine#44701 No.1
                                        }
                                        else
                                        {
                                            // ガイドボタン
                                            e.NextCtrl = uButton_FileSelect;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            switch ( e.Key )
                            {
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                case "uButton_FileSelect":
                    //----- ADD 2015/02/25 王亜楠 Redmine#44701 No.1 -------------------->>>>>
                    if (!e.ShiftKey)
                    {
                        switch (e.Key)
                        {
                            case Keys.Tab:
                            case Keys.Return:
                                {
                                    e.NextCtrl = this.uCheckEditor_NoCountCtrl;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    //----- ADD 2015/02/25 王亜楠 Redmine#44701 No.1 --------------------<<<<<
                    break;
                case "tComboEditor_PetternSelect":
                    {
                        # region [次フォーカス]
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Down:
                                    {
                                        e.NextCtrl = tComboEditor_OutputStyle;
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = uButton_PaternDelete;
                                    }
                                    break;
                            }
                        }
                        //----- ADD 2015/02/25 王亜楠 Redmine#44701 No.1 -------------------->>>>>
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = this.uCheckEditor_NoCountCtrl;
                                    }
                                    break;
                            }
                        }
                        //----- ADD 2015/02/25 王亜楠 Redmine#44701 No.1 --------------------<<<<<
                        # endregion
                    }
                    break;

                case "tComboEditor_OutputStyle":
                case "rb_DividerChar_0":
                case "rb_DividerChar_1":
                case "tEdit_DividerChar":
                case "rb_DividerChar_2":
                case "rb_Parenthesis_0":
                case "rb_Parenthesis_1":
                case "tEdit_ParenthesisChar":
                case "rb_TieNumeric_0":
                case "rb_TieNumeric_1":
                case "rb_TieChar_0":
                case "rb_TieChar_1":
                case "rb_TitleLine_0":
                case "rb_TitleLine_1":
                //case "tComboEditor_OutputType":     //add by liusy #35729 2013/05/20 // DEL 2015/09/17 田建委 Redmine#47006
                    {
                        // 次項目を取得
                        Control nextControl = _focusControl1.GetNextControl( e.PrevCtrl, e.Key, e.ShiftKey );
                        if ( nextControl != null )
                        {
                            e.NextCtrl = nextControl;
                        }

                        //----- DEL 2015/09/17 田建委 Redmine#47006 ---------->>>>>
                        // ----- ADD huangt 2013/05/27 Redmine#35729 ---------- >>>>>
                        //if (!this._opFujikiCustom)
                        //{
                        //    if (e.PrevCtrl.Name == "tComboEditor_OutputType")
                        //    {

                        //        if (!e.ShiftKey)
                        //        {
                        //            switch (e.Key)
                        //            {
                        //                case Keys.Down:
                        //                    {
                        //                        e.NextCtrl = e.PrevCtrl;
                        //                    }
                        //                    break;
                        //                case Keys.Tab:
                        //                case Keys.Return:
                        //                    {
                        //                        // タブ切り替え
                        //                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["BalanceOutput"];
                        //                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                        //                        // 次項目
                        //                        e.NextCtrl = tEdit_ClaimeFileName;
                        //                    }
                        //                    break;
                        //                default:
                        //                    {
                        //                        // 次項目を取得
                        //                        Control nextActiveControl = _focusControl1.GetNextControl(e.PrevCtrl, e.Key, e.ShiftKey);
                        //                        if (nextActiveControl != null)
                        //                        {
                        //                            e.NextCtrl = nextActiveControl;
                        //                        }
                        //                    }
                        //                    break;
                        //            }
                        //        }
                        //    }
                        //}
                        // ----- ADD huangt 2013/05/27 Redmine#35729 ---------- <<<<<
                        //----- DEL 2015/09/17 田建委 Redmine#47006 ----------<<<<<
                    }
                    break;
                /*del by liusy #35729 2013/05/20 -----<<<<<
                case "tComboEditor_OutputType":
                        {
                                if (!e.ShiftKey)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Down:
                                            {
                                                e.NextCtrl = e.PrevCtrl;
                                            }
                                            break;
                                        case Keys.Tab:
                                        case Keys.Return:
                                            {
                                                // タブ切り替え
                                        // 2010/04/15 >>>
                                        //uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["RedSlip"];
                                                uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["BalanceOutput"];
                                        // 2010/04/15 <<<
                                                uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                                // 次項目
                                        // 2010/04/15 >>>
                                        //e.NextCtrl = rb_SlipNote_0;
                                                e.NextCtrl = tEdit_ClaimeFileName;
                                        // 2010/04/15 <<<
                                            }
                                            break;
                                        default:
                                            {
                                                // 次項目を取得
                                        Control nextControl = _focusControl1.GetNextControl( e.PrevCtrl, e.Key, e.ShiftKey );
                                        if ( nextControl != null )
                                                {
                                            e.NextCtrl = nextControl;
                                                }
                                            }
                                            break;
                                    }
                                }
                            }
                    break;
                   del by liusy #35729 2013/05/20 ----->>>>>*/
                //----- DEL 2015/09/17 田建委 Redmine#47006 ---------->>>>>
                //add by liusy #35729 2013/05/20 -----<<<<<
                //case "tComboEditor_DateType":
                //    {
                //        if (!e.ShiftKey)
                //        {
                //            switch (e.Key)
                //            {
                //                case Keys.Down:
                //                    {
                //                        e.NextCtrl = e.PrevCtrl;
                //                    }
                //                    break;
                //                case Keys.Tab:
                //                case Keys.Return:
                //                    {
                //                        // タブ切り替え
                //                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["BalanceOutput"];
                //                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                //                        // 次項目
                //                        e.NextCtrl = tEdit_ClaimeFileName;
                //                    }
                //                    break;
                //                default:
                //                    {
                //                        // 次項目を取得
                //                        Control nextControl = _focusControl1.GetNextControl(e.PrevCtrl, e.Key, e.ShiftKey);
                //                        if (nextControl != null)
                //                        {
                //                            e.NextCtrl = nextControl;
                //                        }
                //                    }
                //                    break;
                //            }
                //        }
                //    }
                //    break;
                   //add by liusy #35729 2013/05/20 ----->>>>>
                //----- DEL 2015/09/17 田建委 Redmine#47006 ----------<<<<<

                //----- ADD 2015/09/17 田建委 Redmine#47006 ---------->>>>>
                case "tComboEditor_OutputType":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Down:
                                    {
                                        if (this.uCheckEditor_RetSlipMinus_Saleslip.Visible)
                                        {
                                            e.NextCtrl = uCheckEditor_RetSlipMinus_Saleslip;
                                        }
                                        else
                                        {
                                            e.NextCtrl = uCheckEditor_RetSlipMinus_Meisai;
                                        }
                                    }
                                    break;
                                default:
                                    {
                                        // 次項目を取得
                                        Control nextControl = _focusControl1.GetNextControl(e.PrevCtrl, e.Key, e.ShiftKey);
                                        if (nextControl != null)
                                        {
                                            e.NextCtrl = nextControl;
                                        }
                                    }
                                    break;
                            }
                        }
                                    }
                                    break;
                case "tComboEditor_DateType":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Up:
                                    {
                                        // 次項目を取得
                                        Control nextControl = _focusControl1.GetNextControl(tComboEditor_OutputType, e.Key, e.ShiftKey);
                                        if (nextControl != null)
                                    {
                                            e.NextCtrl = nextControl;
                                        }
                                    }
                                    break;
                                default:
                                    {
                                        // 次項目を取得
                                        Control nextControl = _focusControl1.GetNextControl( e.PrevCtrl, e.Key, e.ShiftKey );
                                        if ( nextControl != null )
                                        {
                                            e.NextCtrl = nextControl;
                                        }
                                    }
                                    break;
                            }
                        }
                        //----- ADD 2015/02/05 王亜楠 -------------------->>>>>
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // 次項目を取得
                                        e.NextCtrl = this.tComboEditor_OutputType;
                                    }
                                    break;
                            }
                        } 
                        //----- ADD 2015/02/05 王亜楠 --------------------<<<<<
                    }
                    break;
                   //add by liusy #35729 2013/05/20 ----->>>>>
                //----- ADD 2015/02/05 王亜楠 -------------------->>>>>
                case "uCheckEditor_NoCountCtrl":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // 次項目
                                        e.NextCtrl = this.tComboEditor_PetternSelect;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // 次項目
                                        e.NextCtrl = this.uButton_FileSelect;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                //----- ADD 2015/02/05 王亜楠 --------------------<<<<<

                case "uCheckEditor_RetSlipMinus_Saleslip": // 返品伝票金額をマイナスで出力の区分
                case "uCheckEditor_RetSlipMinus_Meisai":
                    {

                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Up:
                                    {
                                        e.NextCtrl = tComboEditor_OutputType;
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // タブ切り替え
                                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["BalanceOutput"];
                                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        // 次項目
                                        e.NextCtrl = tEdit_ClaimeFileName;

                                    }
                                    break;
                                default:
                                    {
                                        // 次項目を取得
                                        Control nextControl = _focusControl1.GetNextControl(e.PrevCtrl, e.Key, e.ShiftKey);
                                        if (nextControl != null)
                                        {
                                            e.NextCtrl = nextControl;
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            // 次項目
                            e.NextCtrl = tComboEditor_OutputType;
                        }
                    }
                    break;
                //----- ADD 2015/09/17 田建委 Redmine#47006 ----------<<<<<

                # endregion

                // 2010/04/15 Add >>>
                #region [残高出力]
                case "tEdit_ClaimeFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_ClaimeFileName.Text))
                                        {
                                            // 次項目
                                            e.NextCtrl = tEdit_ChargeFileName;
                                        }
                                        else
                                        {
                                            // ガイドボタン
                                            e.NextCtrl = uButton_ClaimeFileName;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Down:
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (uTabControl_Setting.Tabs["TextOutput"].Visible == true)
                                        {
                                            // タブ切り替え
                                            uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["TextOutput"];
                                            uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                            // 次項目
                                            //e.NextCtrl = tComboEditor_OutputType; del by liusy #35729 2013/05/20

                                            //----- DEL 2015/09/17 田建委 Redmine#47006 ---------->>>>>
                                            //if (this.tComboEditor_DateType.Visible)
                                            //{
                                            //    e.NextCtrl = tComboEditor_DateType; //add by liusy #35729 2013/05/20
                                            //}
                                            //else
                                            //{
                                            //    e.NextCtrl = tComboEditor_OutputType;
                                            //}
                                            //----- DEL 2015/09/17 田建委 Redmine#47006 ----------<<<<<

                                            //----- ADD 2015/09/17 田建委 Redmine#47006 ---------->>>>>
                                            // 次項目
                                            if (this.tComboEditor_OutputType.SelectedItem.DataValue.ToString() == "0")
                                            {
                                                e.NextCtrl = uCheckEditor_RetSlipMinus_Saleslip; // 「返品伝票金額をマイナスで出力する」の区分
                                            }
                                            else
                                            {
                                                e.NextCtrl = uCheckEditor_RetSlipMinus_Meisai; // 「マイナス金額にはマイナス記号を付与する」の区分
                                            }
                                            //----- ADD 2015/09/17 田建委 Redmine#47006 ----------<<<<<
                                        }
                                        else
                                        {
                                            // 次項目
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                        // ----------UPD 2010/01/29----------<<<<<

                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "tEdit_ChargeFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_ChargeFileName.Text))
                                        {
                                            // 次項目
                                            uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["RedSlip"];
                                            uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                            e.NextCtrl = rb_SlipNote_0;
                                        }
                                        else
                                        {
                                            // ガイドボタン
                                            e.NextCtrl = uButton_ChargeFileName;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                case "uButton_ChargeFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // 次項目
                                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["RedSlip"];
                                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        e.NextCtrl = rb_SlipNote_0;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                #endregion
                // 2010/04/15 Add <<<

                # region [赤伝発行]
                case "rb_SlipNote_0":
                    {
                        if ( !e.ShiftKey )
                        {
                            // 次項目を取得
                            Control nextControl = _focusControl2.GetNextControl( e.PrevCtrl, e.Key, e.ShiftKey );
                            if ( nextControl != null )
                            {
                                e.NextCtrl = nextControl;
                            }
                        }
                        else
                        {
                            switch ( e.Key )
                            {
                                case Keys.Down:
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // ----------UPD 2010/01/29---------->>>>>
                                        //// タブ切り替え
                                        //uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["TextOutput"];
                                        //uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        //// 次項目
                                        //e.NextCtrl = tComboEditor_OutputType;
                                        // 2010/04/15 >>>
                                        //if (uTabControl_Setting.Tabs["TextOutput"].Visible == true)
                                        if (uTabControl_Setting.Tabs["BalanceOutput"].Visible == true)
                                        // 2010/04/15 <<<
                                        {
                                            // タブ切り替え
                                            // 2010/04/15 >>>
                                            //uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["TextOutput"];
                                            uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["BalanceOutput"];
                                            // 2010/04/15 <<<
                                            uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                            // 次項目
                                            // 2010/04/15 >>>
                                            //e.NextCtrl = tComboEditor_OutputType;
                                            e.NextCtrl = tEdit_ChargeFileName;
                                            // 2010/04/15 <<<
                                        }
                                        else
                                        {
                                            // 次項目
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                        // ----------UPD 2010/01/29----------<<<<<

                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "rb_SlipNote_1":
                case "rb_SlipNote_2":
                case "rb_SlipNote_3":// ADD 2010/01/29
                case "tEdit_SlipNote":
                case "rb_SlipNote2_0":
                case "rb_SlipNote2_1":
                case "rb_SlipNote2_2":
                case "rb_SlipNote2_3":// ADD 2010/01/29
                case "tEdit_SlipNote2":
                case "rb_SlipNote3_0":  // ADD 2013/04/19 T.Miyamoto
                case "rb_SlipNote3_1":  // ADD 2013/04/19 T.Miyamoto
                case "rb_SlipNote3_2":  // ADD 2013/04/19 T.Miyamoto
                case "rb_SlipNote3_3":  // ADD 2013/04/19 T.Miyamoto
                case "tEdit_SlipNote3": // ADD 2013/04/19 T.Miyamoto
                    {
                        // 次項目を取得
                        Control nextControl = _focusControl2.GetNextControl( e.PrevCtrl, e.Key, e.ShiftKey );
                        if ( nextControl != null )
                        {
                            e.NextCtrl = nextControl;
                        }
                    }
                    break;
                // DEL 2013/04/19 T.Miyamoto ------------------------------>>>>>
                //case "rb_SlipNote3_0":
                //case "rb_SlipNote3_1":
                //case "rb_SlipNote3_2":// ADD 2010/01/29
                //    {
                //        // 次項目を取得
                //        Control nextControl = _focusControl2.GetNextControl( e.PrevCtrl, e.Key, e.ShiftKey );
                //        if ( nextControl != null )
                //        {
                //            e.NextCtrl = nextControl;
                //        }

                //        if ( !tEdit_SlipNote3.Enabled )
                //        {
                //            if ( !e.ShiftKey )
                //            {
                //                switch ( e.Key )
                //                {
                //                    case Keys.Down:
                //                        {
                //                            e.NextCtrl = e.PrevCtrl;
                //                        }
                //                        break;
                //                }
                //            }
                //        }
                //    }
                //    break;
                ////case "rb_SlipNote3_2":// DE; 2010/01/29
                //case "rb_SlipNote3_3":// ADD 2010/01/29
                //    {
                //        // 次項目を取得
                //        Control nextControl = _focusControl2.GetNextControl( e.PrevCtrl, e.Key, e.ShiftKey );
                //        if ( nextControl != null )
                //        {
                //            e.NextCtrl = nextControl;
                //        }

                //        if ( !tEdit_SlipNote3.Enabled )
                //        {
                //            if ( !e.ShiftKey )
                //            {
                //                switch ( e.Key )
                //                {
                //                    case Keys.Down:
                //                        {
                //                            e.NextCtrl = e.PrevCtrl;
                //                        }
                //                        break;
                //                    case Keys.Tab:
                //                    case Keys.Return:
                //                        {
                //                            // ---------------UPD 2009/12/28--------------->>>>>
                //                            // タブ切り替え
                //                            //uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["SettingClear"];
                //                            uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["DetailControl"];
                //                            uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                //                            // 次項目
                //                            //e.NextCtrl = uButton_Clear_SlipGrid;
                //                            e.NextCtrl = tComboEditor_AllowRowFiltering;
                //                            // ---------------UPD 2009/12/28---------------<<<<<
                //                        }
                //                        break;
                //                }
                //            }
                //        }
                //    }
                //    break;
                //case "tEdit_SlipNote3":
                //    {
                //        if ( !e.ShiftKey )
                //        {
                //            switch ( e.Key )
                //            {
                //                case Keys.Down:
                //                    {
                //                        e.NextCtrl = e.PrevCtrl;
                //                    }
                //                    break;
                //                case Keys.Tab:
                //                case Keys.Return:
                //                    {
                //                        // -------------UPD 2009/12/28------------->>>>>
                //                        // タブ切り替え
                //                        //uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["SettingClear"];
                //                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["DetailControl"];
                //                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                //                        // 次項目
                //                        //e.NextCtrl = uButton_Clear_SlipGrid;
                //                        e.NextCtrl = tComboEditor_AllowRowFiltering;
                //                        // -------------UPD 2009/12/28-------------<<<<<
                //                    }
                //                    break;
                //                default:
                //                    {
                //                        // 次項目を取得
                //                        Control nextControl = _focusControl2.GetNextControl( e.PrevCtrl, e.Key, e.ShiftKey );
                //                        if ( nextControl != null )
                //                        {
                //                            e.NextCtrl = nextControl;
                //                        }
                //                    }
                //                    break;
                //            }
                //        }
                //    }
                //    break;
                // DEL 2013/04/19 T.Miyamoto ------------------------------<<<<<
                // ADD 2013/04/19 T.Miyamoto ------------------------------>>>>>
                case "tComboEditor_RedPrintDialog":
                        {
                            if ( !e.ShiftKey )
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                        e.NextCtrl = tComboEditor_ReisssuePrintDialog;
                                        }
                                        break;
                                }
                            }
                        }
                    break;
                case "tComboEditor_ReisssuePrintDialog":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // タブ切り替え
                                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["DetailControl"];
                                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        // 次項目
                                        e.NextCtrl = tComboEditor_AllowRowFiltering;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // ADD 2013/04/19 T.Miyamoto ------------------------------<<<<<
                # endregion

                // ------------ADD 2009/12/28------------->>>>>
                # region [明細制御]
                case "tComboEditor_AllowRowFiltering":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = tComboEditor_AllowColSwapping;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // タブ切り替え
                                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["RedSlip"];
                                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        // 次項目
                                        // UPD 2013/04/19 T.Miyamoto ------------------------------>>>>>
                                        //if (tEdit_SlipNote3.Enabled)
                                        //{
                                        //    e.NextCtrl = tEdit_SlipNote3;
                                        //}
                                        //else
                                        //{
                                        //    e.NextCtrl = rb_SlipNote3_3;
                                        //}
                                        e.NextCtrl = tComboEditor_ReisssuePrintDialog;
                                        // UPD 2013/04/19 T.Miyamoto ------------------------------<<<<<
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "tComboEditor_AllowColSwapping":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = tComboEditor_FixedHeaderIndicator;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "tComboEditor_FixedHeaderIndicator":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        //----- UPD　2018/09/04 譚洪　履歴自動表示の対応------->>>>>
                                        // タブ切り替え
                                        //uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["SettingClear"];
                                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["TabControl"];
                                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        // 次項目
                                        //e.NextCtrl = uButton_Clear_SlipGrid;
                                        e.NextCtrl = tComboEditor_InitSelectDisplay;
                                        //----- UPD　2018/09/04 譚洪　履歴自動表示の対応-------<<<<<
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                # endregion
                // ------------ADD 2009/12/28-------------<<<<<
                //----- ADD　2018/09/04 譚洪　履歴自動表示の対応------->>>>>
                # region [タブ制御]
                case "tComboEditor_InitSelectDisplay":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // タブ切り替え
                                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["SettingClear"];
                                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        // 次項目
                                        e.NextCtrl = uButton_Clear_SlipGrid;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // タブ切り替え
                                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["DetailControl"];
                                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        // 次項目
                                        e.NextCtrl = tComboEditor_FixedHeaderIndicator;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                # endregion
                //----- ADD　2018/09/04 譚洪　履歴自動表示の対応-------<<<<<
                # region [設定クリア]
                case "uButton_Clear_SlipGrid":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Return:
                                    {
                                        uButton_Clear_SlipGrid_Click( this, new EventArgs() );
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch ( e.Key )
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {

                                        //----- UPD　2018/09/04 譚洪　履歴自動表示の対応------->>>>>
                                        // -------------UPD 2009/12/28--------------->>>>>
                                        // タブ切り替え
                                        //uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["RedSlip"];
                                        //uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["DetailControl"];
                                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["TabControl"];
                                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        // 次項目
                                        //e.NextCtrl = tComboEditor_FixedHeaderIndicator;
                                        e.NextCtrl = tComboEditor_InitSelectDisplay;
                                        // -------------UPD 2009/12/28---------------<<<<<
                                        //----- UPD　2018/09/04 譚洪　履歴自動表示の対応-------<<<<<
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "uButton_Clear_DetailGrid":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Return:
                                    {
                                        uButton_Clear_DetailGrid_Click( this, new EventArgs() );
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "uButton_Clear_RedSlipGrid":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Return:
                                    {
                                        uButton_Clear_RedSlipGrid_Click( this, new EventArgs() );
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "uButton_Clear_BalanceGrid":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Tab:
                                    {
                                        //e.NextCtrl = uButton_OK;  // DEL 2022/05/05 仰亮亮 納品書電子帳簿連携対応
                                        // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿連携対応　------->>>>>
                                        // タブ切り替え
                                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["EbooksLinkSetting"];
                                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        // 次項目
                                        e.NextCtrl = tComboEditor_OutPutMode;
                                        // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿連携対応　-------<<<<<
                                    }
                                    break;
                                case Keys.Return:
                                    {
                                        uButton_Clear_BalanceGrid_Click( this, new EventArgs() );
                                        // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿連携対応　------->>>>>
                                        // タブ切り替え
                                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["EbooksLinkSetting"];
                                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        // 次項目
                                        e.NextCtrl = tComboEditor_OutPutMode;
                                        // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿連携対応　-------<<<<<
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                # endregion

                // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿連携対応　------->>>>>
                // 
                case "tComboEditor_OutPutMode":
                    if (e.ShiftKey)
                    {
                        switch (e.Key)
                        {
                            case Keys.Tab:
                            case Keys.Return:
                                {
                                    // タブ切り替え
                                    uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["SettingClear"];
                                    uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                    // 次項目
                                    e.NextCtrl = uButton_Clear_SlipGrid;
                                }
                                break;
                        }
                    }
                    break;
                // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿連携対応　-------<<<<<
                case "uButton_OK":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Return:
                                    {
                                        // ボタン押下
                                        uButton_OK_Click( this, new EventArgs() );
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "uButton_Cancel":
                    if ( !e.ShiftKey )
                    {
                        switch ( e.Key )
                        {
                            case Keys.Return:
                                {
                                    // ボタン押下
                                    uButton_Cancel_Click( this, new EventArgs() );
                                }
                                break;
                            case Keys.Tab:
                                {
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 区切り文字Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_DividerChar_0_Enter( object sender, EventArgs e )
        {
            this.DividerChar = prevDividerChar;
        }
        /// <summary>
        /// 区切り文字Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_DividerChar_0_Leave( object sender, EventArgs e )
        {
            prevDividerChar = this.DividerChar;
        }
        /// <summary>
        /// 区切り文字Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_DividerChar_1_CheckedChanged( object sender, EventArgs e )
        {
            if ( rb_DividerChar_1.Checked )
            {
                tEdit_DividerChar.Enabled = true;
            }
            else
            {
                tEdit_DividerChar.Enabled = false;
                tEdit_DividerChar.Clear();
            }
        }
        /// <summary>
        /// 括り文字Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_Parenthesis_0_Enter( object sender, EventArgs e )
        {
            this.Parenthesis = prevParenthesis;
        }
        /// <summary>
        /// 括り文字Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_Parenthesis_0_Leave( object sender, EventArgs e )
        {
            prevParenthesis = this.Parenthesis;
        }
        /// <summary>
        /// 括り文字Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_Parenthesis_1_CheckedChanged( object sender, EventArgs e )
        {
            if ( rb_Parenthesis_1.Checked )
            {
                tEdit_ParenthesisChar.Enabled = true;
            }
            else
            {
                tEdit_ParenthesisChar.Enabled = false;
                tEdit_ParenthesisChar.Clear();
            }
        }
        /// <summary>
        /// 数値括りEnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_TieNumeric_0_Enter( object sender, EventArgs e )
        {
            this.TieNumeric = prevTieNumeric;
        }
        /// <summary>
        /// 数値括りLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_TieNumeric_0_Leave( object sender, EventArgs e )
        {
            prevTieNumeric = this.TieNumeric;
        }
        /// <summary>
        /// 文字括りEnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_TieChar_0_Enter( object sender, EventArgs e )
        {
            this.TieChar = prevTieChar;
        }
        /// <summary>
        /// 文字括りLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_TieChar_0_Leave( object sender, EventArgs e )
        {
            prevTieChar = this.TieChar;
        }
        /// <summary>
        /// タイトル行Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_TitleLine_0_Enter( object sender, EventArgs e )
        {
            this.TitleLine = prevTitleLine;
        }
        /// <summary>
        /// タイトル行Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_TitleLine_0_Leave( object sender, EventArgs e )
        {
            prevTitleLine = this.TitleLine;
        }
        /// <summary>
        /// 伝票備考１Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_SlipNote_0_Enter( object sender, EventArgs e )
        {
            this.SlipNote = prevSlipNote;
        }
        /// <summary>
        /// 伝票備考１Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_SlipNote_0_Leave( object sender, EventArgs e )
        {
            prevSlipNote = this.SlipNote;
        }
        /// <summary>
        /// 伝票備考２Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_SlipNote2_0_Enter( object sender, EventArgs e )
        {
            this.SlipNote2 = prevSlipNote2;
        }
        /// <summary>
        /// 伝票備考２Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_SlipNote2_0_Leave( object sender, EventArgs e )
        {
            prevSlipNote2 = this.SlipNote2;
        }
        /// <summary>
        /// 伝票備考３Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_SlipNote3_0_Enter( object sender, EventArgs e )
        {
            this.SlipNote3 = prevSlipNote3;
        }
        /// <summary>
        /// 伝票備考３Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_SlipNote3_0_Leave( object sender, EventArgs e )
        {
            prevSlipNote3 = this.SlipNote3;
        }
        /// <summary>
        /// 備考１任意チェック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void rb_SlipNote_2_CheckedChanged( object sender, EventArgs e )// DEL 2010/01/29
        private void rb_SlipNote_3_CheckedChanged(object sender, EventArgs e)// ADD 2010/01/29
        {
            if ( rb_SlipNote_3.Checked )
            {
                tEdit_SlipNote.Enabled = true;
            }
            else
            {
                tEdit_SlipNote.Enabled = false;
                tEdit_SlipNote.Clear();
            }
        }
        /// <summary>
        /// 備考２任意チェック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void rb_SlipNote2_2_CheckedChanged( object sender, EventArgs e )// DEL 2010/01/29
        private void rb_SlipNote2_3_CheckedChanged(object sender, EventArgs e)// ADD 2010/01/29
        {
            if ( rb_SlipNote2_3.Checked )
            {
                tEdit_SlipNote2.Enabled = true;
            }
            else
            {
                tEdit_SlipNote2.Enabled = false;
                tEdit_SlipNote2.Clear();
            }
        }
        /// <summary>
        /// 備考３任意チェック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void rb_SlipNote3_2_CheckedChanged( object sender, EventArgs e )// DEL 2010/01/29
        private void rb_SlipNote3_3_CheckedChanged(object sender, EventArgs e)// ADD 2010/01/29
        {
            if ( rb_SlipNote3_3.Checked )
            {
                tEdit_SlipNote3.Enabled = true;
            }
            else
            {
                tEdit_SlipNote3.Enabled = false;
                tEdit_SlipNote3.Clear();
            }
        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/15 ADD
        /// <summary>
        /// テキスト出力オプションの有効、無効で設定のテキスト出力タブの表示制御
        /// </summary>
        /// <param name="display">display</param>
        /// <remarks>
        /// <br>Note       : テキスト出力オプションの有効、無効で設定のテキスト出力タブの表示制御を行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/01/29</br>
        /// <remarks>
        public void uTabControlSet(bool display)
        {
            //テキスト出力オプションの有効、無効で設定のテキスト出力タブの表示制御を行う。
            uTabControl_Setting.Tabs["TextOutput"].Visible = display;
            // 2010/04/15 Add >>>
            uTabControl_Setting.Tabs["BalanceOutput"].Visible = display;
            // 2010/04/15 Add <<<
        }

        // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿対応　-------->>>>>
        /// <summary>
        /// 電子帳簿連携オプションの有効、無効で設定の電子帳簿連携タブの表示制御
        /// </summary>
        /// <param name="display">display</param>
        /// <remarks>
        /// <br>Note       : 電子帳簿連携オプションの有効、無効で設定の電子帳簿連携タブの表示制御を行う。</br>
        /// <br>Programmer : 仰亮亮</br>
        /// <br>Date       : 2022/05/05</br>
        /// </remarks>
        public void uTabControlEbookLinkSet(bool display)
        {
            // 電子帳簿連携オプションの有効、無効で設定の電子帳簿連携タブの表示制御を行う。
            uTabControl_Setting.Tabs["EbooksLinkSetting"].Visible = display;
        }
        // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿対応　-------<<<<<

        // 2010/04/15 Add >>>
        /// <summary>
        /// ファイルダイアログ表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_ClaimeFileName_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tEdit_ClaimeFileName.Text))
            {
                this.openFileDialog.FileName = this.tEdit_ClaimeFileName.Text.Trim();
            }
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;

            // ファイル選択
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tEdit_ClaimeFileName.Text = openFileDialog.FileName.ToUpper();
            }
        }

        /// <summary>
        /// ファイルダイアログ表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_ChargeFileName_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tEdit_ChargeFileName.Text))
            {
                this.openFileDialog.FileName = this.tEdit_ChargeFileName.Text.Trim();
            }
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;

            // ファイル選択
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tEdit_ChargeFileName.Text = openFileDialog.FileName.ToUpper();
            }
        }

        //----- ADD 2015/02/05 王亜楠 -------------------->>>>>
        /// <summary>
        /// 抽出件数制限なし選択変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 抽出件数制限なし選択変更イベント</br>
        /// <br>Programmer : 王亜楠</br>
        /// <br>Date       : 2015/02/05</br>
        /// <br>UpdateNote : 2015/03/03 王亜楠 Redmine#44701</br>
        /// <br>           : 抽出件数制限なしチェック時のメッセージの変更</br>
        /// </remarks>
        private void uCheckEditor_NoCountCtrl_CheckedChanged(object sender, EventArgs e)
        {
            if (uCheckEditor_NoCountCtrl.Checked)
            {
                if (TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_QUESTION, this.Name,
                    //"抽出件数制限なしで出力します。よろしいですか？", -1, MessageBoxButtons.YesNo) == DialogResult.No) // DEL 2015/03/03 王亜楠 Redmine#44701
                    "20,000件の抽出件数制限なしで出力します。\nよろしいですか？", -1, MessageBoxButtons.YesNo) == DialogResult.No) // ADD 2015/03/03 王亜楠 Redmine#44701
                { 
                    uCheckEditor_NoCountCtrl.CheckedChanged -= new System.EventHandler(this.uCheckEditor_NoCountCtrl_CheckedChanged);
                    uCheckEditor_NoCountCtrl.Checked = false;
                    uCheckEditor_NoCountCtrl.CheckedChanged += new System.EventHandler(this.uCheckEditor_NoCountCtrl_CheckedChanged);
                }
            }
        }
        //----- ADD 2015/02/05 王亜楠 --------------------<<<<<
        // 2010/04/15 Add <<<
        // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿対応　-------->>>>>
        #region[電子帳簿連携初期化表示]
        /// <summary>
        /// 電子帳簿連携初期化表示
        /// </summary>
        private void InitEBooksLinkSetting()
        {

            if (this._opt_EBooksLink == (int)Option.ON)
            {
                // プリンタDic
                _printDic = new Dictionary<string, string>();
                // プリンタDic情報を取得
                ArrayList printerList = new ArrayList();
                // プリンタマスタアクセスクラス
                _prtManageAcs = new PrtManageAcs();
                try
                {
                    if (_prtManageAcs.SearchAll(out printerList, LoginInfoAcquisition.EnterpriseCode) == 0)
                    {
                        foreach (PrtManage prtManage in printerList)
                        {
                            // 論理削除されているプリンタ設定マスタデータは無視
                            if (!prtManage.LogicalDeleteCode.Equals(0)) continue;
                            // プリンタDic
                            _printDic.Add(prtManage.PrinterMngNo.ToString(), prtManage.PrinterName.ToUpper());
                        }
                    }
                }
                catch (Exception)
                {
                    // プリンタDic
                    _printDic = new Dictionary<string, string>();
                }

                // 得意先電子元帳のPDF出力設定ファイル情報取得
                _eBooksOutputSetting = geteBooksOutputSetting();
                // 特定ファイル存在判断
                if (!UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctPrint_PMKAU04001U_PDFPrinterSettingEnable_Xml)))
                {
                    // PDFプリンタ項目 操作不可
                    tComboEditor_PdfPrinter.Enabled = false;
                }
                else
                {
                    // PDFプリンタ項目 操作可
                    tComboEditor_PdfPrinter.Enabled = true;
                }

                // 伝票PDF出力 
                tComboEditor_OutPutMode.SelectedIndex = Convert.ToInt32(_eBooksOutputSetting.OutputMode);
                // 出力伝票区分
                uCheckEditor_DebitNote.Checked = false;
                uCheckEditor_RePrint.Checked = false;
                switch (Convert.ToInt32(_eBooksOutputSetting.OutputSlipType))
                {
                    case (Int32)outPutSlipTypeEnum.DebitNoteChecked:
                        uCheckEditor_DebitNote.Checked = true;
                        break;
                    case (Int32)outPutSlipTypeEnum.RePrintChecked:
                        uCheckEditor_RePrint.Checked = true;
                        break;
                    case (Int32)outPutSlipTypeEnum.All:
                        uCheckEditor_DebitNote.Checked = true;
                        uCheckEditor_RePrint.Checked = true;
                        break;
                    case (Int32)outPutSlipTypeEnum.No:
                        uCheckEditor_DebitNote.Checked = false;
                        uCheckEditor_RePrint.Checked = false;
                        break;
                    default:
                        uCheckEditor_DebitNote.Checked = true;
                        uCheckEditor_RePrint.Checked = false;
                        break;
                }
                // PDFプリンタ [Windows標準／その他]
                tComboEditor_PdfPrinter.SelectedIndex = Convert.ToInt32(_eBooksOutputSetting.PDFPrinter);
                // 割り当て済みのプリンタ管理番号
                string sPrintName = string.Empty;
                // 割り当て済みのプリンタ管理番号
                _eBooksOutputSetting.PDFPrinterNumber = string.Empty;
                foreach (string key in _printDic.Keys)
                {
                    sPrintName = _printDic[key].ToUpper();
                    // Windows標準
                    if (Convert.ToInt32(_eBooksOutputSetting.PDFPrinter) == (int)pdfPrinterEnum.BaseSetting_Xml)
                    {
                        if (sPrintName.Contains(ctBase_PrintName))
                        {
                            // プリンタ番号
                            _eBooksOutputSetting.PDFPrinterNumber = key;
                            break;
                        }

                    }
                    // その他
                    else
                    {
                        // PRIMO PDF・Cube PDF プリンタ
                        if (sPrintName.Contains(ctOther_CubePrintName))
                        {
                            // プリンタ番号
                            _eBooksOutputSetting.PDFPrinterNumber = key;
                            break;
                        }
                    }
                }

                tEdit_PdfPrinterNumber.Text = _eBooksOutputSetting.PDFPrinterNumber;
                // 想プリンタ制御が終了するまでの待機時間ミリ秒
                tEdit_PdfPrinterWait.Text = _eBooksOutputSetting.PDFPrinterWait;
            }
        }
        #endregion

        # region[得意先電子元帳のPDF出力設定ファイル情報取得]
        /// <summary>
        /// 得意先電子元帳のPDF出力設定ファイル情報取得
        /// </summary>
        public eBooksOutputSetting geteBooksOutputSetting()
        {
            eBooksOutputSetting eBookSetting = null;
            try
            {
                // 特定ファイル且つPDFプリンタ項目設定XMLファイル存在の場合
                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctPrint_PMKAU04001U_PDFOutputSettings_Xml)))
                    {
                        eBookSetting = UserSettingController.DeserializeUserSetting<eBooksOutputSetting>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctPrint_PMKAU04001U_PDFOutputSettings_Xml));
                    }
            }
            catch (Exception)
            {
                //　既存処理影響なし
            }

            // PDFプリンタ設定項目のデフォルト値を設定
            if (eBookSetting == null)
            {
                eBookSetting = new eBooksOutputSetting();
                eBookSetting.OutputMode = DEFAULT_PDFOUTPUT_VALUE;           　 // 伝票PDF出力
                eBookSetting.OutputSlipType = DEFAULT_OUTPUTSLIPTYPE_VALUE;     // 出力伝票区分
                eBookSetting.PDFPrinter = DEFAULT_PRINTER_VALUE;                // PDFプリンタ [Windows標準／その他]
                eBookSetting.PDFPrinterNumber = DEFAULT_PRINTERNO_VALUE;        // 割り当て済みのプリンタ管理番号
                eBookSetting.PDFPrinterWait = DEFAULT_PRINTERWAUTTIME_VALUE;    // 仮想プリンタ制御が終了するまでの待機時間(ミリ秒)
            }

            return eBookSetting;
        }
        # endregion

        # region[PDFプリンタ項目設定情報を書き込み]
        /// <summary>
        ///PDFプリンタ項目設定情報を書き込み
        /// </summary>
        /// <returns></returns>
        public void WriteEBooksOutputSetting()
        {
            try
            {
                eBooksOutputSetting setting = new eBooksOutputSetting();

                // 伝票PDF出力
                setting.OutputMode = Convert.ToString(tComboEditor_OutPutMode.SelectedIndex);
                // 出力伝票区分
                int iOutputSlipType = 0;
                if ((!uCheckEditor_DebitNote.Checked) && (!uCheckEditor_RePrint.Checked)) 
                {
                    iOutputSlipType = (int)outPutSlipTypeEnum.No;
                }
                else if ((uCheckEditor_DebitNote.Checked) && (uCheckEditor_RePrint.Checked)) 
                {
                    iOutputSlipType = (int)outPutSlipTypeEnum.All;
                }
                else if (uCheckEditor_RePrint.Checked)
                {
                    iOutputSlipType = (int)outPutSlipTypeEnum.RePrintChecked;
                }
                else if (uCheckEditor_DebitNote.Checked)
                {
                    iOutputSlipType = (int)outPutSlipTypeEnum.DebitNoteChecked;
                }
                setting.OutputSlipType = iOutputSlipType.ToString();

                // PDFプリンタ [Windows標準／その他] 
                setting.PDFPrinter = Convert.ToString(tComboEditor_PdfPrinter.SelectedIndex);
                // 割り当て済みのプリンタ管理番号
                setting.PDFPrinterNumber = tEdit_PdfPrinterNumber.Text.Trim();
                // 仮想プリンタ制御が終了するまでの待機時間(ミリ秒)
                setting.PDFPrinterWait = Convert.ToString(tEdit_PdfPrinterWait.GetInt());

                UserSettingController.SerializeUserSetting(setting, Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctPrint_PMKAU04001U_PDFOutputSettings_Xml)));
            }
            catch (Exception)
            {
                //　既存処理影響なし
            }
 
        }
        #endregion

        #region [PDFプリンタ変更連動処理]
        /// <summary>
        /// PDFプリンタ変更連動処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_PdfPrinter_ValueChanged(object sender, EventArgs e)
        {
            tEdit_PdfPrinterNumber.Text = string.Empty;
            if (_printDic.Count > 0) 
            {
                string sPrintName = string.Empty;
                foreach (string key in _printDic.Keys)
                {
                    sPrintName = _printDic[key].ToUpper();
                    // Windows標準
                    if (tComboEditor_PdfPrinter.SelectedIndex == (int)pdfPrinterEnum.BaseSetting_Xml)
                    {
                        if (sPrintName.Contains(ctBase_PrintName))
                        {
                            // プリンタ番号
                            tEdit_PdfPrinterNumber.Text = key;
                            break;
                        }
                    }
                    // その他
                    else
                    {
                        // Cube PDF プリンタ
                        if (sPrintName.Contains(ctOther_CubePrintName))
                        {
                            // プリンタ番号
                            tEdit_PdfPrinterNumber.Text = key;
                            break;
                        }
                    }
                }
            }
        }
        #endregion
        // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿対応　-------<<<<<
    }

    // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿対応　-------->>>>>
    # region [PDFプリンタ項目設定情報]
    /// <summary>
    /// PDFプリンタ項目設定情報
    /// </summary>
    /// <remarks> 
    /// </remarks>
    public class eBooksOutputSetting
    {
        /// <summary>PDFプリンタ項目設定情報</summary>
        public eBooksOutputSetting()
        {

        }

        /// <summary>伝票PDF出力</summary>
        private string _outputMode;
        /// <summary>出力伝票区分</summary>
        private string _outputSlipType;
        /// <summary>PDFプリンタ [Windows標準／その他] </summary>
        private string _pDFPrinter;
        /// <summary>割り当て済みのプリンタ管理番号 </summary>
        private string _pDFPrinterNumber;
        /// <summary>仮想プリンタ制御が終了するまでの待機時間(ミリ秒)</summary>
        private string _pDFPrinterWait;

        /// <summary>伝票PDF出力</summary>
        public string OutputMode
        {
            get { return _outputMode; }
            set { _outputMode = value; }
        }

        /// <summary>出力伝票区分</summary>
        public string OutputSlipType
        {
            get { return _outputSlipType; }
            set { _outputSlipType = value; }
        }
        /// <summary>PDFプリンタ [Windows標準／その他] </summary>
        public string PDFPrinter
        {
            get { return _pDFPrinter; }
            set { _pDFPrinter = value; }
        }

        /// <summary>割り当て済みのプリンタ管理番号 </summary>
        public string PDFPrinterNumber
        {
            get { return _pDFPrinterNumber; }
            set { _pDFPrinterNumber = value; }
        }

        /// <summary>仮想プリンタ制御が終了するまでの待機時間</summary>
        public string PDFPrinterWait
        {
            get { return _pDFPrinterWait; }
            set { _pDFPrinterWait = value; }
        }

    }
    #endregion
    // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿対応　-------<<<<<

    /// <summary>
    /// 得意先電子元帳用ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先電子元帳のユーザー設定情報を管理するクラス</br>
    /// <br>Programmer : </br>
    /// <br>Date       : </br>
    /// <br>Update Note: 2018/09/04 譚洪</br>
    /// <br>管理番号   : 11470152-00 履歴自動表示の対応</br>
    /// </remarks>
    [Serializable]
    public class CustPtrSalesUserConst
    {

        # region プライベート変数

        // 出力ファイル名
        private string _outputFileName;

        //----- ADD 2015/02/25 王亜楠 Redmine#44701 No.1 -------------------->>>>>
        // 抽出件数制限なし
        private int _searchCountCtrl;
        //----- ADD 2015/02/25 王亜楠 Redmine#44701 No.1 --------------------<<<<<

        // 出力形式
        private int _outputStyle;

        // 出力パターン
        private string[] _outputPattern;

        // 選択されたパターン名
        private string _selectedPatternName;

        // 備考１パターン
        private int _slipNote1Pattern;

        // 備考１任意
        private string _slipNote1Default;

        // 備考２パターン
        private int _slipNote2Pattern;

        // 備考２任意
        private string _slipNote2Default;

        // 備考３パターン
        private int _slipNote3Pattern;

        // 備考３任意
        private string _slipNote3Default;

        // 2010/04/15 Add >>>
        // 出力ファイル名（請求）
        private string _claimeFileName;

        // 出力ファイル名（売掛）
        private string _chargeFileName;
        // 2010/04/15 Add <<<

        /// <summary>項目区切り文字</summary>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
        //private const string STRING_DIVIDER = "/";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
        private const string STRING_DIVIDER = "'";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

        //private const int[] DEFAULT_VAL_SLIP = { 0, 0, 0, 2, 3, 0, 0, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 0, 27, 28, 29, 30, 31, 0, 32, 33 };

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
        // 有効な詳細条件リスト
        private List<string> _enabledConditionList;
        // --------------ADD 2009/12/28------------->>>>>
        // 有効な基本条件リスト
        private List<string> _enabledCommonConditionList;
        // 詳細条件Enableリスト
        private List<string> _enabledList;
        // --------------ADD 2009/12/28-------------<<<<<
        // 伝票グリッドカラムリスト
        private List<ColumnInfo> _slipColumnsList;
        // 明細グリッドカラムリスト
        private List<ColumnInfo> _detailColumnsList;
        // 伝票グリッドカラムリスト
        private List<ColumnInfo> _redSlipColumnsList;
        // 残高グリッドカラムリスト
        private List<ColumnInfo> _balanceColumnsList;

        // 詳細条件グループ展開状態
        private bool _extraConditionExpanded;
        // 合計表示グループ展開状態
        private bool _balanceChartExpanded;

        // 伝票グリッド自動サイズ調整
        private bool _autoAdjustSlip;
        // 明細グリッド自動サイズ調整
        private bool _autoAdjustDetail;
        // 赤伝グリッド自動サイズ調整
        private bool _autoAdjustRedSlip;
        // 残高グリッド自動サイズ調整
        private bool _autoAdjustBalance;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD

        // ------------ADD 2009/12/28------------>>>>>
        // 行フィルタ
        private int _allowRowFiltering;
        // 列交換
        private int _allowColSwapping;
        // 列固定
        private int _fixedHeaderIndicator;
        // ------------ADD 2009/12/28------------<<<<<

        // ADD 2012/06/01 ----------------------->>>>>
        // 抽出拠点種別
        private int _remainSectionType;
        // ADD 2012/06/01 ----------------------->>>>>

        // ADD 2013/04/19 T.Miyamoto ------------------------------>>>>>
        // 伝票印刷確認ダイアログ(赤伝発行)
        private bool _RedPrintDialog;
        // 伝票印刷確認ダイアログ(再発行)
        private bool _ReisssuePrintDialog;
        // ADD 2013/04/19 T.Miyamoto ------------------------------<<<<<
        private int _initSelectDisplay;// 2018/09/04 譚洪　履歴自動表示の対応

        # endregion // プライベート変数

        # region コンストラクタ

        /// <summary>
        /// 得意先電子元帳ユーザー設定情報クラス
        /// </summary>
        public CustPtrSalesUserConst()
        {
            
        }

        # endregion // コンストラクタ

        # region プロパティ

        /// <summary>出力ファイル名</summary>
        public string OutputFileName
        {
            get { return this._outputFileName; }
            set { this._outputFileName = value; }
        }

        //----- ADD 2015/02/25 王亜楠 Redmine#44701 No.1 -------------------->>>>>
        /// <summary>
        /// 抽出件数制限なし
        /// </summary>
        public int SearchCountCtrl
        {
            get { return _searchCountCtrl; }
            set { _searchCountCtrl = value; }
        }
        //----- ADD 2015/02/25 王亜楠 Redmine#44701 No.1 --------------------<<<<<

        /// <summary>出力型式</summary>
        public int OutputStyle
        {
            get { return this._outputStyle; }
            set { this._outputStyle = value; }
        }

        /// <summary>出力パターン</summary>
        public string[] OutputPattern
        {
            get { return this._outputPattern; }
            set { this._outputPattern = value; }
        }

        /// <summary>選択パターン名</summary>
        public string SelectedPatternName
        {
            get { return this._selectedPatternName; }
            set { this._selectedPatternName = value; }
        }

        /// <summary>備考１パターン</summary>
        public int SlipNote1Pattern
        {
            get { return this._slipNote1Pattern; }
            set { this._slipNote1Pattern = value; }
        }

        /// <summary>備考１任意設定</summary>
        public string SlipNote1Default
        {
            get { return this._slipNote1Default; }
            set { this._slipNote1Default = value; }
        }

        /// <summary>備考２パターン</summary>
        public int SlipNote2Pattern
        {
            get { return this._slipNote2Pattern; }
            set { this._slipNote2Pattern = value; }
        }

        /// <summary>備考２任意設定</summary>
        public string SlipNote2Default
        {
            get { return this._slipNote2Default; }
            set { this._slipNote2Default = value; }
        }
        /// <summary>備考３パターン</summary>
        public int SlipNote3Pattern
        {
            get { return this._slipNote3Pattern; }
            set { this._slipNote3Pattern = value; }
        }

        /// <summary>備考３任意設定</summary>
        public string SlipNote3Default
        {
            get { return this._slipNote3Default; }
            set { this._slipNote3Default = value; }
        }

        /// <summary>区切り文字</summary>
        public string DIVIDER
        {
            get { return STRING_DIVIDER; }
        }

        // 2010/04/15 Add >>>
        // 出力ファイル名（請求）
        public string ClaimeFileName
        {
            get { return this._claimeFileName; }
            set { this._claimeFileName = value; }
        }

        // 出力ファイル名（売掛）
        public string ChargeFileName
        {
            get { return this._chargeFileName; }
            set { this._chargeFileName = value; }
        }
        // 2010/04/15 Add <<<

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
        /// <summary>有効な詳細条件リスト</summary>
        public List<string> EnabledConditionList
        {
            get { return this._enabledConditionList; }
            set { this._enabledConditionList = value; }
        }
        // -----------ADD 2009/12/28----------->>>>>
        /// <summary>有効な基本条件リスト</summary>
        public List<string> EnabledCommonConditionList
        {
            get { return this._enabledCommonConditionList; }
            set { this._enabledCommonConditionList = value; }
        }
        /// <summary>有効な基本条件Enableリスト</summary>
        public List<string> EnabledList
        {
            get { return this._enabledList; }
            set { this._enabledList = value; }
        }
        // -----------ADD 2009/12/28-----------<<<<<
        /// <summary>伝票グリッドカラムリスト</summary>
        public List<ColumnInfo> SlipColumnsList
        {
            get { return this._slipColumnsList; }
            set { this._slipColumnsList = value; }
        }
        /// <summary>明細グリッドカラムリスト</summary>
        public List<ColumnInfo> DetailColumnsList
        {
            get { return this._detailColumnsList; }
            set { this._detailColumnsList = value; }
        }
        /// <summary>残高グリッドカラムリスト</summary>
        public List<ColumnInfo> RedSlipColumnsList
        {
            get { return this._redSlipColumnsList; }
            set { this._redSlipColumnsList = value; }
        }
        /// <summary>残高グリッドカラムリスト</summary>
        public List<ColumnInfo> BalanceColumnsList
        {
            get { return this._balanceColumnsList; }
            set { this._balanceColumnsList = value; }
        }
        /// <summary>詳細条件グループ展開状態</summary>
        public bool ExtraConditionExpanded
        {
            get { return _extraConditionExpanded; }
            set { _extraConditionExpanded = value; }
        }
        /// <summary>合計表示グループ展開状態</summary>
        public bool BalanceChartExpanded
        {
            get { return _balanceChartExpanded; }
            set { _balanceChartExpanded = value; }
        }
        /// <summary>伝票グリッド自動サイズ調整</summary>
        public bool AutoAdjustSlip
        {
            get { return _autoAdjustSlip; }
            set { _autoAdjustSlip = value; }
        }
        /// <summary>明細グリッド自動サイズ調整</summary>
        public bool AutoAdjustDetail
        {
            get { return _autoAdjustDetail; }
            set { _autoAdjustDetail = value; }
        }
        /// <summary>赤伝グリッド自動サイズ調整</summary>
        public bool AutoAdjustRedSlip
        {
            get { return _autoAdjustRedSlip; }
            set { _autoAdjustRedSlip = value; }
        }
        /// <summary>残高グリッド自動サイズ調整</summary>
        public bool AutoAdjustBalance
        {
            get { return _autoAdjustBalance; }
            set { _autoAdjustBalance = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD

        // -----------ADD 2009/12/28----------->>>>>
        /// <summary>行フィルタ</summary>
        public int AllowRowFiltering
        {
            get { return _allowRowFiltering; }
            set { _allowRowFiltering = value; }
        }
        /// <summary>列交換</summary>
        public int AllowColSwapping
        {
            get { return _allowColSwapping; }
            set { _allowColSwapping = value; }
        }
        /// <summary>列固定</summary>
        public int FixedHeaderIndicator
        {
            get { return _fixedHeaderIndicator; }
            set { _fixedHeaderIndicator = value; }
        }
        // -----------ADD 2009/12/28-----------<<<<<

        // ADD 2012/06/01 ----------------------->>>>>
        /// <summary>抽出拠点種別</summary>
        public int RemainSectionType
        {
            get { return _remainSectionType; }
            set { _remainSectionType = value; }
        }
        // ADD 2012/06/01 -----------------------<<<<<

        // ADD 2013/04/19 T.Miyamoto ------------------------------>>>>>
        /// <summary>伝票印刷確認ダイアログ(赤伝発行)</summary>
        public bool RedPrintDialog
        {
            get { return this._RedPrintDialog; }
            set { this._RedPrintDialog = value; }
        }
        /// <summary>伝票印刷確認ダイアログ(再発行)</summary>
        public bool ReisssuePrintDialog
        {
            get { return this._ReisssuePrintDialog; }
            set { this._ReisssuePrintDialog = value; }
        }
        // ADD 2013/04/19 T.Miyamoto ------------------------------<<<<<
        //----- ADD　2018/09/04 譚洪　履歴自動表示の対応------->>>>>
        /// <summary>タブ制御の初期選択</summary>
        public int InitSelectDisplay
        {
            get { return this._initSelectDisplay; }
            set { this._initSelectDisplay = value; }
        }
        //----- ADD　2018/09/04 譚洪　履歴自動表示の対応-------<<<<<

        # endregion

        /// <summary>
        /// 得意先電子元帳ユーザー設定情報クラス複製処理
        /// </summary>
        /// <returns>得意先電子元帳ユーザー設定情報クラス</returns>
        public CustPtrSalesUserConst Clone()
        {
            CustPtrSalesUserConst constObj = new CustPtrSalesUserConst();
            return constObj;
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
        /// <summary>
        /// ファイル拡張子変換処理
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="newExtension"></param>
        /// <returns></returns>
        public static string ChangeFileExtension( string fileName, string selectedValue )
        {
            string newExt = string.Empty;
            switch ( selectedValue )
            {
                case "0":
                    newExt = ".CSV";
                    break;
                case "1":
                    newExt = ".TXT";
                    break;
                case "2":
                    newExt = ".PRN";
                    break;
                case "3":
                default:
                    break;
            }
            if ( newExt != string.Empty )
            {
                try
                {
                    fileName = Path.ChangeExtension( fileName, newExt );
                }
                catch
                {
                }
            }
            return fileName;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
    }
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
    # region [ColumnInfo]
    /// <summary>
    /// ColumnInfo
    /// </summary>
    [Serializable]
    public struct ColumnInfo
    {
        /// <summary>列名</summary>
        private string _columnName;
        /// <summary>並び順</summary>
        private int _visiblePosition;
        /// <summary>非表示フラグ</summary>
        private bool _hidden;
        /// <summary>幅</summary>
        private int _width;
        /// <summary>固定フラグ</summary>
        private bool _columnFixed;
        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }
        /// <summary>
        /// 並び順
        /// </summary>
        public int VisiblePosition
        {
            get { return _visiblePosition; }
            set { _visiblePosition = value; }
        }
        /// <summary>
        /// 非表示フラグ
        /// </summary>
        public bool Hidden
        {
            get { return _hidden; }
            set { _hidden = value; }
        }
        /// <summary>
        /// 幅
        /// </summary>
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        /// <summary>
        /// 固定フラグ
        /// </summary>
        public bool ColumnFixed
        {
            get { return _columnFixed; }
            set { _columnFixed = value; }
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <param name="visiblePosition">並び順</param>
        /// <param name="hidden">非表示フラグ</param>
        /// <param name="width">幅</param>
        /// <param name="columnFixed">固定フラグ</param>
        public ColumnInfo( string columnName, int visiblePosition, bool hidden, int width, bool columnFixed )
        {
            _columnName = columnName;
            _visiblePosition = visiblePosition;
            _hidden = hidden;
            _width = width;
            _columnFixed = columnFixed;
        }
    }
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/11/24 ADD
    /// <summary>
    /// ColumnInfo比較クラス（ソート用）
    /// </summary>
    public class ColumnInfoComparer : IComparer<ColumnInfo>
    {
        /// <summary>
        /// ColumnInfo比較処理
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare( ColumnInfo x, ColumnInfo y )
        {
            // 列表示順で比較
            int result = x.VisiblePosition.CompareTo( y.VisiblePosition );
            // 列表示順が一致する場合は列名で比較(通常は発生しない)
            if ( result == 0 )
            {
                result = x.ColumnName.CompareTo( y.ColumnName );
            }
            return result;
        }
    }
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/11/24 ADD
    # endregion
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/27 ADD
    # region [一般フォーカス制御クラス]
    /// <summary>
    /// 一般フォーカス制御クラス
    /// </summary>
    internal class FocusControl
    {
        List<List<Control>> _controls;
        Dictionary<string, int> _col;
        Dictionary<string, int> _row;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FocusControl()
        {
            this.Clear();
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Clear()
        {
            _controls = new List<List<Control>>();
            _col = new Dictionary<string, int>();
            _row = new Dictionary<string, int>();
        }

        /// <summary>
        /// １行追加
        /// </summary>
        /// <param name="controls"></param>
        public void AddLine( params Control[] controls )
        {
            List<Control> line = new List<Control>( controls );

            for ( int index = 0; index < line.Count; index++ )
            {
                int col = index;
                int row = _controls.Count;

                _col.Add( line[index].Name, col );
                _row.Add( line[index].Name, row );
            }
            
            _controls.Add( line );
        }

        /// <summary>
        /// 次コントロール取得（フォーカス移動先）
        /// </summary>
        /// <param name="prevControl"></param>
        /// <param name="key"></param>
        /// <param name="shiftKey"></param>
        /// <returns></returns>
        public Control GetNextControl( Control prevControl, Keys key, bool shiftKey )
        {
            Control nextControl = null;

            if ( !_col.ContainsKey( prevControl.Name ) ) return null;

            int col = _col[prevControl.Name];
            int row = _row[prevControl.Name];

            if ( _controls[row][col].Name != prevControl.Name ) return null;

            if ( !shiftKey )
            {
                switch ( key )
                {
                    # region [UP]
                    case Keys.Up:
                        {
                            if ( row - 1 >= 0 )
                            {
                                int originCol = col;
                                row--;

                                if ( col > _controls[row].Count - 1 )
                                {
                                    col = _controls[row].Count - 1;
                                }
                                nextControl = _controls[row][col];
                                while ( nextControl == null || nextControl.Enabled == false )
                                {
                                    if ( col > 0 )
                                    {
                                        col--;
                                        nextControl = _controls[row][col];
                                    }
                                    else if ( row > 0 )
                                    {
                                        col = originCol;
                                        row--;
                                        if ( col > _controls[row].Count - 1 )
                                        {
                                            col = _controls[row].Count - 1;
                                        }
                                        nextControl = _controls[row][col];
                                    }
                                    else
                                    {
                                        nextControl = null;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                nextControl = null;
                            }
                        }
                        break;
                    # endregion

                    # region [DOWN]
                    case Keys.Down:
                        {
                            if ( row + 1 <= _controls.Count - 1 )
                            {
                                int originCol = col;
                                row++;

                                if ( col > _controls[row].Count - 1 )
                                {
                                    col = _controls[row].Count - 1;
                                }
                                nextControl = _controls[row][col];
                                while ( nextControl == null || nextControl.Enabled == false )
                                {
                                    if ( col > 0 )
                                    {
                                        col--;
                                        nextControl = _controls[row][col];
                                    }
                                    else if ( row + 1 <= _controls.Count - 1 )
                                    {
                                        col = originCol;
                                        row++;
                                        if ( col > _controls[row].Count - 1 )
                                        {
                                            col = _controls[row].Count - 1;
                                        }
                                        nextControl = _controls[row][col];
                                    }
                                    else
                                    {
                                        nextControl = null;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                nextControl = null;
                            }
                        }
                        break;
                    # endregion

                    # region [LEFT]
                    case Keys.Left:
                        {
                            nextControl = null;
                            while ( nextControl == null || nextControl.Enabled == false )
                            {
                                if ( col > 0 )
                                {
                                    col--;
                                    nextControl = _controls[row][col];
                                }
                                else
                                {
                                    nextControl = null;
                                    break;
                                }
                            }
                        }
                        break;
                    # endregion

                    # region [RIGHT]
                    case Keys.Right:
                        {
                            nextControl = null;
                            while ( nextControl == null || nextControl.Enabled == false )
                            {
                                if ( col < _controls[row].Count - 1 )
                                {
                                    col++;
                                    nextControl = _controls[row][col];
                                }
                                else
                                {
                                    nextControl = null;
                                    break;
                                }
                            }
                        }
                        break;
                    # endregion

                    # region [Tab順次]
                    case Keys.Tab:
                    case Keys.Return:
                        {
                            // Tab順次項目
                            nextControl = null;
                            while ( nextControl == null || nextControl.Enabled == false )
                            {
                                if ( col + 1 <= _controls[row].Count - 1 )
                                {
                                    col++;
                                }
                                else if ( row + 1 <= _controls.Count - 1 )
                                {
                                    row++;
                                    col = 0;
                                }
                                else
                                {
                                    break;
                                }
                                nextControl = _controls[row][col];
                            }
                        }
                        break;
                    # endregion
                }
            }
            else
            {
                switch ( key )
                {
                    # region [Tab順前]
                    case Keys.Tab:
                    case Keys.Return:
                        {
                            // Tab順前項目
                            nextControl = null;
                            while ( nextControl == null || nextControl.Enabled == false )
                            {
                                if ( col - 1 >= 0 )
                                {
                                    col--;
                                }
                                else if ( row - 1 >= 0 )
                                {
                                    row--;
                                    col = _controls[row].Count - 1;
                                }
                                else
                                {
                                    break;
                                }

                                nextControl = _controls[row][col];
                            }
                        }
                        break;
                    # endregion
                }
            }

            return nextControl;
        }
    }
    # endregion
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/27 ADD
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 ADD
    # region [グリッド・列選択ダイアログ制御クラス]
    /// <summary>
    /// グリッド・列選択ダイアログ制御クラス
    /// </summary>
    /// <remarks>Gridのカラムチューザを共通化します</remarks>
    public class GridColumnChooserControl
    {
        private List<Infragistics.Win.UltraWinGrid.UltraGrid> _targetList;
        private Dictionary<string, Infragistics.Win.UltraWinGrid.ColumnChooserDialog> _chooserDialogs;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GridColumnChooserControl()
        {
            _targetList = new List<Infragistics.Win.UltraWinGrid.UltraGrid>();
            _chooserDialogs = new Dictionary<string, Infragistics.Win.UltraWinGrid.ColumnChooserDialog>();
        }

        /// <summary>
        /// 対象追加
        /// </summary>
        /// <param name="targetGrid"></param>
        public void Add( Infragistics.Win.UltraWinGrid.UltraGrid targetGrid )
        {
            if ( !_targetList.Contains( targetGrid ) )
            {
                // 対象Gridリスト
                _targetList.Add( targetGrid );
                // カラムチューザダイアログ
                _chooserDialogs.Add( targetGrid.Name, CreateColumnChooser( targetGrid ) );

                // 対象Gridへの操作
                targetGrid.DisplayLayout.ColumnChooserEnabled = Infragistics.Win.DefaultableBoolean.False;
                targetGrid.BeforeColumnChooserDisplayed += new Infragistics.Win.UltraWinGrid.BeforeColumnChooserDisplayedEventHandler( uGrid_BeforeColumnChooserDisplayed );
            }
        }
        /// <summary>
        /// カラムチューザー表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>※Gridのデフォルトのカラムチューザーをカスタマイズします</remarks>
        private void uGrid_BeforeColumnChooserDisplayed( object sender, Infragistics.Win.UltraWinGrid.BeforeColumnChooserDisplayedEventArgs e )
        {
            // デフォルトの処理はキャンセルする
            e.Cancel = true;
            //bool flag = false;

            // カラムチューザーダイアログ
            Infragistics.Win.UltraWinGrid.ColumnChooserDialog chooser = _chooserDialogs[(sender as Control).Name];
            if ( chooser == null ) return;

            try
            {
                //-----------------------------------------------------------------
                // ※注意：
                //   意図的に無効な値-1を与える事で直前にソートがかからないようにする。
                //-----------------------------------------------------------------
                chooser.ColumnChooserControl.ColumnDisplayOrder = (Infragistics.Win.UltraWinGrid.ColumnDisplayOrder)(-1);
                chooser.Show();
            }
            catch
            {
                // 例外
            }
        }
        /// <summary>
        /// カラムチューザー生成処理
        /// </summary>
        /// <param name="chooser"></param>
        private Infragistics.Win.UltraWinGrid.ColumnChooserDialog CreateColumnChooser( Infragistics.Win.UltraWinGrid.UltraGrid sourceGrid )
        {
            Infragistics.Win.UltraWinGrid.ColumnChooserDialog chooser = new Infragistics.Win.UltraWinGrid.ColumnChooserDialog();

            chooser.Text = "表示項目の選択";
            chooser.StartPosition = FormStartPosition.CenterScreen;
            chooser.Size = new Size( 250, 400 );
            chooser.TopMost = true;

            // 表示→閉じた後、破棄しない
            chooser.DisposeOnClose = Infragistics.Win.DefaultableBoolean.False;

            chooser.ColumnChooserControl.SourceGrid = sourceGrid;
            chooser.ColumnChooserControl.Font = sourceGrid.Font;

            return chooser;
        }
    }
    # endregion
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 ADD
}