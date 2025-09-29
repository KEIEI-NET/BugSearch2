//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 仕入先電子元帳
// プログラム概要   : 仕入先電子元帳 動作設定ＵＩクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : FSI冨樫 紗由里
// 修 正 日  2013/01/21  修正内容 : 返品計上機能追加
//                                   1.選択チェックボックス処理追加
//                                   2.返品計上Grid処理追加
//----------------------------------------------------------------------------//
// 管理番号  10901273-00 作成担当 : gezh
// 修 正 日  2013/04/16  修正内容 : 2013/05/15配信分 Redmine#35309
//                                  №1871_仕入先電子元帳のテキスト出力の障害対応
//----------------------------------------------------------------------------//
// 管理番号  11170170-00    作成担当 : 田建委
// 修 正 日  2015/09/17     修正内容 : Redmine#47006 仕入先電子元帳の障害対応
//                                     現行保障をするため画面に区分を設ける
//----------------------------------------------------------------------------//

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
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    public partial class PMKOU04004UA : Form
    {
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
        # region const
        // パターン削除確認メッセージ
        private const string MSG_CONFIRM_DELETE_PATTERN = "選択中の出力パターンを削除してよろしいですか？";
        // ファイル名未入力メッセージ
        //private const string MSG_OUTPUTTEXT_NOFILENAME = "ファイル名を入力して下さい"; // DEL 2010/09/28 障害報告 #15619
        // パターン未入力メッセージ
        private const string MSG_OUTPUTTEXT_NOPATTERN = "出力パターンを入力して下さい";
        # endregion
        # region event
        /// <summary>伝票グリッド設定初期化</summary>
        public event EventHandler ClearSettingSlipGrid;
        /// <summary>明細グリッド設定初期化</summary>
        public event EventHandler ClearSettingDetailGrid;
        /// <summary>残高グリッド設定初期化</summary>
        public event EventHandler ClearSettingBalanceGrid;
        // ----------ADD 2013/01/21----------->>>>>
        /// <summary>返品計上入力グリッド設定初期化</summary>
        public event EventHandler ClearSettinRetGoodsAddUpInpGrid;
        // ----------ADD 2013/01/21-----------<<<<<
        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

        #region プライベート変数

        // 設定保存用共通オブジェクト

        //private UserSettingController uSettingControl;

        /// <summary>設定XMLファイル名</summary>
        private const string XML_FILE_NAME = "PMKOU04000U_Construction.XML";

        // データセット
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
        //private ExportColumnDataSet _dataSet;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
        private SuppPtrStcDetailDataSet _dataSet;
        private int prevDividerChar;
        private int prevParenthesis;
        private int prevTieNumeric;
        private int prevTieChar;
        private int prevTitleLine;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

        // ユーザー設定
        private SuppPtrStcUserConst _userSetting;

        //// ユーザー設定
        //private int _outputStyle;

        // **** スキン設定用クラス ****
        private ControlScreenSkin _controlScreenSkin;

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

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
        // 伝票項目indexディクショナリ
        private Dictionary<string, int> _columnIndexDicOfSlip;
        // 明細項目indexディクショナリ
        private Dictionary<string, int> _columnIndexDicOfDetail;
        // 伝票グリッドカラム・コレクション
        private Infragistics.Win.UltraWinGrid.ColumnsCollection _slipColCollection;
        // 明細グリッドカラム・コレクション
        private Infragistics.Win.UltraWinGrid.ColumnsCollection _detailColCollection;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 ADD
        // 残高グリッドカラム・コレクション
        private Infragistics.Win.UltraWinGrid.ColumnsCollection _balanceColCollection;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 ADD
        // フォーカス制御
        private FocusControl _focusControl1;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 ADD
        // グリッド・カラムチューザー制御
        private GridColumnChooserControl _gridColumnChooserControl;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 ADD

        // 2010/04/05 Add >>>
        /// <summary>テキスト出力オプション情報</summary>
        private int _opt_TextOutput;

        #region 列挙体
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
        #endregion // 列挙体

        /// <summary>
        /// テキスト出力オプション情報
        /// </summary>
        public int Opt_TextOutput
        {
            get { return this._opt_TextOutput; }
            set { this._opt_TextOutput = value; }
        }

        // 2010/04/05 Add <<<


        #endregion // プライベート変数

        #region プロパティ

        public SuppPtrStcUserConst UserSetting
        {
            get { return this._userSetting; }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
        /// <summary>
        /// 伝票グリッドカラム・コレクション 
        /// </summary>
        public Infragistics.Win.UltraWinGrid.ColumnsCollection SlipColCollection
        {
            get { return _slipColCollection; }
            set { _slipColCollection = value; }
        }
        /// <summary>
        /// 明細グリッドカラム・コレクション
        /// </summary>
        public Infragistics.Win.UltraWinGrid.ColumnsCollection DetailColCollection
        {
            get { return _detailColCollection; }
            set { _detailColCollection = value; }
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 ADD
        /// <summary>
        /// 明細グリッドカラム・コレクション
        /// </summary>
        public Infragistics.Win.UltraWinGrid.ColumnsCollection BalanceColCollection
        {
            get { return _balanceColCollection; }
            set { _balanceColCollection = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 ADD
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
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMKOU04004UA()
        {
            InitializeComponent();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
            this._dataSet = new SuppPtrStcDetailDataSet();

            // 伝票項目index
            _columnIndexDicOfSlip = new Dictionary<string, int>();
            for ( int index = 0; index < _dataSet.StcList.Columns.Count; index++ )
            {
                _columnIndexDicOfSlip.Add( _dataSet.StcList.Columns[index].ColumnName, index );
            }

            // 明細項目index
            _columnIndexDicOfDetail = new Dictionary<string, int>();
            for ( int index = 0; index < _dataSet.StcDetail.Columns.Count; index++ )
            {
                _columnIndexDicOfDetail.Add( _dataSet.StcDetail.Columns[index].ColumnName, index );
            }

            this._userSetting = new SuppPtrStcUserConst();

            // フォーカス制御(テキスト出力設定タブ)
            _focusControl1 = new FocusControl();
            _focusControl1.AddLine( tComboEditor_OutputStyle );
            _focusControl1.AddLine( rb_DividerChar_0, rb_DividerChar_1, tEdit_DividerChar, rb_DividerChar_2 );
            _focusControl1.AddLine( rb_Parenthesis_0, rb_Parenthesis_1, tEdit_ParenthesisChar );
            _focusControl1.AddLine( rb_TieNumeric_0, rb_TieNumeric_1 );
            _focusControl1.AddLine( rb_TieChar_0, rb_TieChar_1 );
            _focusControl1.AddLine( rb_TitleLine_0, rb_TitleLine_1 );
            _focusControl1.AddLine( tComboEditor_OutputType );

            _focusControl1.AddLine( uCheckEditor_RetSlipMinus_Saleslip ); // ADD 2015/09/17 田建委 Redmine#47006
            _focusControl1.AddLine( uCheckEditor_RetSlipMinus_Meisai ); // ADD 2015/09/17 田建委 Redmine#47006

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 ADD
            _gridColumnChooserControl = new GridColumnChooserControl();
            _gridColumnChooserControl.Add( uGrid_ColumnItemSelector );
            _gridColumnChooserControl.Add( uGrid_ColumnItemSelector2 );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 ADD
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
                    //return Int32.Parse( patterns[_columnIndexDicOfSlip[columnName]].ToString() );  // DEL 2013/04/16 gezh FOR Redmine#35309
                    // --------------- ADD 2013/04/16 gezh FOR Redmine#35309 ---------->>>>>
                    // XMLファイルが最新ではない場合
                    if (_columnIndexDicOfSlip.Count != patterns.Length)
                    {
                        return Int32.Parse(patterns[_columnIndexDicOfSlip[columnName] - 1].ToString());
                    }
                    // XMLファイルが最新場合
                    else
                    {
                        return Int32.Parse(patterns[_columnIndexDicOfSlip[columnName]].ToString());
                    }
                    // --------------- ADD 2013/04/16 gezh FOR Redmine#35309 ----------<<<<<
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
                    //return Int32.Parse(patterns[_columnIndexDicOfDetail[columnName]].ToString()); // DEL 2013/04/16 gezh FOR Redmine#35309
                    // --------------- ADD 2013/04/16 gezh FOR Redmine#35309 ---------->>>>>
                    // XMLファイルが最新ではない場合
                    if (_columnIndexDicOfDetail.Count != patterns.Length)
                    {
                        return Int32.Parse(patterns[_columnIndexDicOfDetail[columnName] - 1].ToString());
                    }
                    // XMLファイルが最新場合
                    else
                    {
                        return Int32.Parse(patterns[_columnIndexDicOfDetail[columnName]].ToString());
                    }
                    // --------------- ADD 2013/04/16 gezh FOR Redmine#35309 ----------<<<<<
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
        /// <remarks>
        /// <br>UpdateNote : 2010/07/20 chenyd</br>
        /// <br>           　テキスト出力対応</br>
        /// </remarks>
        private void PMKOU04004UA_Load(object sender, EventArgs e)
        {
            // 画面設定
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
            //this._dataSet = new ExportColumnDataSet();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL

            // グリッド毎に使用するデータビューを作成
            DataView dViewSlip = new DataView(this._dataSet.StcList);
            DataView dViewDetail = new DataView(this._dataSet.StcDetail);

            // データソースとしてデータビューを指定
            this.uGrid_ColumnItemSelector.DataSource = dViewSlip;
            this.uGrid_ColumnItemSelector2.DataSource = dViewDetail;

            // 設定値があればロード
            this._userSetting = new SuppPtrStcUserConst();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
            InitializeUserSetting( ref _userSetting );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
            this.Deserialize();

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

            // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
            this.uButton_AccpayFileName.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
            this.uButton_AccpayFileName.Appearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;

            this.uButton_PaymentFileName.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
            this.uButton_PaymentFileName.Appearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;
            // ---------------------- ADD 2010/07/20 ---------------------------------<<<<<

            // 基本パターン名作成
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
            //string tempName = string.Empty;
            //createPatternStringNonCustom(0, out tempName, true);
            //createPatternStringNonCustom(1, out tempName, true);
            //createPatternStringNonCustom(2, out tempName, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
            if ( _userSetting == null ||
                _userSetting.OutputPattern == null ||
                _userSetting.OutputPattern.Length == 0 )
            {
                string tempName = string.Empty;
                createPatternStringNonCustom( 0, out tempName, true );
                createPatternStringNonCustom( 1, out tempName, true );
                createPatternStringNonCustom( 2, out tempName, true );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

            //this._outputStyle = 0;// 初期設定

            // 画面の初期値をセット
            setInitialValue();

            // 画面の初期設定
            this.uComboEditor_OutputType_ValueChanged(null, null);
            this.uComboEditor_OutputStyle_ValueChanged(null, null);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
            // ValueChangedイベントで書き変わったファイル名を戻す
            tEdit_SettingFileName.Text = _userSetting.OutputFileName;
            // ---------------------- ADD  2010/07/20 ---------------->>>>>
            tEdit_AccpayFileName.Text = _userSetting.SuplierFileName;
            tEdit_PaymentFileName.Text = _userSetting.SuplAccFileName;
            // ---------------------- ADD  2010/07/20 ------------------>>>>>

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
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
        /// <summary>
        /// ユーザー設定初期化処理
        /// </summary>
        /// <param name="_userSetting"></param>
        private void InitializeUserSetting( ref SuppPtrStcUserConst userSetting )
        {
            userSetting = new SuppPtrStcUserConst();
            InitializeSlipGrid( ref userSetting );
            InitializeDetailGrid( ref userSetting );
            InitializeBalanceGrid( ref userSetting );
            InitializeRetGoodsAddUpInpGrid(ref userSetting);   // ADD  2013/01/21
        }
        /// <summary>
        /// ユーザー設定初期化（伝票表示）
        /// </summary>
        /// <param name="userSetting"></param>
        private void InitializeSlipGrid( ref SuppPtrStcUserConst userSetting )
        {
            userSetting.SlipColumnsList = new List<ColumnInfo>();
            userSetting.AutoAdjustSlip = false;
        }
        /// <summary>
        /// ユーザー設定初期化（明細表示）
        /// </summary>
        /// <param name="userSetting"></param>
        private void InitializeDetailGrid( ref SuppPtrStcUserConst userSetting )
        {
            userSetting.DetailColumnsList = new List<ColumnInfo>();
            userSetting.AutoAdjustDetail = false;
        }
        /// <summary>
        /// ユーザー設定初期化（残高一覧表示）
        /// </summary>
        /// <param name="userSetting"></param>
        private void InitializeBalanceGrid( ref SuppPtrStcUserConst userSetting )
        {
            userSetting.BalanceColumnsList = new List<ColumnInfo>();
            userSetting.AutoAdjustBalance = false;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
 
        // ----------ADD 2013/01/21----------->>>>>
        /// <summary>
        /// ユーザー設定初期化（返品計上入力）
        /// </summary>
        /// <param name="userSetting"></param>
        private void InitializeRetGoodsAddUpInpGrid(ref SuppPtrStcUserConst userSetting)
        {
            userSetting.RetGoodsAddUpInpColumnsList = new List<ColumnInfo>();
            userSetting.AutoAdjustRetGoodsAddUpInp = false;
        }
        // ----------ADD 2013/01/21-----------<<<<<
 
        #endregion // コンストラクタ

        #region プライベート関数

        /// <summary>
        /// 画面の初期値を設定
        /// </summary>
        private void setInitialValue()
        {
            // 設定値があればそれを設置
            if (this._outputPattern == null)
            {
                this.tEdit_DividerChar.Clear();
                this.tEdit_ParenthesisChar.Clear();
                this.tEdit_SettingFileName.Clear();
                this.tComboEditor_PetternSelect.Text = string.Empty;

                //this.uComboEditor_OutputType.SelectedIndex = 0;
                //this.uComboEditor_OutputStyle.SelectedIndex = 0;
                this.tComboEditor_OutputType.SelectedIndex = 0;
                this.tComboEditor_OutputStyle.SelectedIndex = 0;

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

                if (String.IsNullOrEmpty(this._selectedPattern))
                {
                    this._selectedPattern = "テキスト出力パターン1";
                }

                // 取得したパターンを分解し、パターン名のリストを作成
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                this.tComboEditor_PetternSelect.Items.Clear();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                Infragistics.Win.ValueListItem item;
                foreach (string pattern in this._outputPattern)
                {
                    item = new Infragistics.Win.ValueListItem();
                    
                    // 最初の区切り文字までがパターン名
                    if (pattern.Contains(this._divider))
                    {
                        pName = pattern.Substring(0, pattern.IndexOf(this._divider));
                        item.DataValue = pName;
                        item.DisplayText = pName;

                        this.tComboEditor_PetternSelect.Items.Add(item);

                        // 設定されているパターンの場合は内容を取得
                        if (pName == this._selectedPattern)
                        {
                            getPatternValue(pattern.Substring(pattern.IndexOf(this._divider) + 1), out patternValue);
                        }
                    }
                }

                // 取得が終わったら、画面を設定する

                // ファイル名
                this.tEdit_SettingFileName.Text = this._userSetting.OutputFileName;

                // パターン名
                this.tComboEditor_PetternSelect.Text = this._selectedPattern;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
                //// 出力形式
                ////this.uComboEditor_OutputStyle.Text = "カスタム";
                //this.uComboEditor_OutputStyle.SelectedIndex = Int32.Parse(patternValue[9].ToString());

                //// 区切り文字
                //this.uOptionSet_DividerChar.CheckedIndex = Int32.Parse(patternValue[0].ToString());
                //// 区切り文字任意
                //this.tEdit_DividerChar.Text = patternValue[1].ToString();

                //// 括り文字
                //this.uOptionSet_Parenthesis.CheckedIndex = Int32.Parse(patternValue[2].ToString());
                //// 括り文字任意
                //this.tEdit_ParenthesisChar.Text = patternValue[3].ToString();

                //// 数値括り
                //this.uOptionSet_TieNumeric.CheckedIndex = Int32.Parse(patternValue[4].ToString());
                //// 文字括り
                //this.uOptionSet_TieChar.CheckedIndex = Int32.Parse(patternValue[5].ToString());

                //// タイトル行
                //this.uOptionSet_TitleLine.CheckedIndex = Int32.Parse(patternValue[6].ToString());

                //// グリッド
                //this._gridSetting_Slip = patternValue[7].ToString();
                //this._gridSetting_Detail = patternValue[8].ToString();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
                // ＵＩ表示
                SetDisplayFromPattern( patternValue );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
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
            //const int ct_ItemCount = 11; // DEL 2015/09/17 田建委 Redmine#47006
            const int ct_ItemCount = 13; // ADD 2015/09/17 田建委 Redmine#47006
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
                if (str1.Contains(this._divider))
                {
                    pValue[i] = str1.Substring(0, str1.IndexOf(this._divider));
                }
                else
                {
                    pValue[i] = str1.Substring(0);

                    // ----- ADD 2015/09/17 田建委 Redmine#47006 ----->>>>>
                    // 既存XMLのパターンの内容は11つ項目だけ、12と13の項目の内容を追加します。
                    if (i == 10)
                    {
                        // 「返品伝票金額をマイナスで出力する」の場合、オフを設定します。
                        pValue[11] = "0";
                        // 「マイナス金額にはマイナス記号を付与する」の場合、オフを設定します。
                        pValue[12] = "0";
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
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
            //if (isSlip)
            //{
            //    //gridSetting = new string[32];
            //    gridSetting = new string[18];

            //    //for (int i = 0; i < 32; i++)
            //    for (int i = 0; i < 19; i++)
            //    {
            //        gridSetting[i] = patternStr.Substring(i * 3, 3);
            //    }
            //}
            //else
            //{
            //    //gridSetting = new string[57];
            //    gridSetting = new string[35];

            //    //for (int i = 0; i < 57; i++)
            //    for (int i = 0; i < 36; i++)
            //    {
            //        gridSetting[i] = patternStr.Substring(i * 3, 3);
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
            int count = patternStr.Length / 3;
            gridSetting = new string[count];

            for ( int i = 0; i < count; i++ )
            {
                gridSetting[i] = patternStr.Substring( i * 3, 3 );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
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
            //int counter = 0;
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

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
            //// ファイル名
            //this.tEdit_SettingFileName.Text = this._userSetting.OutputFileName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL

            // パターン名
            this.tComboEditor_PetternSelect.Text = this._selectedPattern;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
            //// 出力形式
            ////this.uComboEditor_OutputStyle.Text = "カスタム";
            //this.uComboEditor_OutputStyle.SelectedIndex = Int32.Parse(patternValue[9].ToString());

            //// 区切り文字
            //this.uOptionSet_DividerChar.CheckedIndex = Int32.Parse(patternValue[0].ToString());
            //// 区切り文字任意
            //this.tEdit_DividerChar.Text = patternValue[1].ToString();

            //// 括り文字
            //this.uOptionSet_Parenthesis.CheckedIndex = Int32.Parse(patternValue[2].ToString());
            //// 括り文字任意
            //this.tEdit_ParenthesisChar.Text = patternValue[3].ToString();

            //// 数値括り
            //this.uOptionSet_TieNumeric.CheckedIndex = Int32.Parse(patternValue[4].ToString());
            //// 文字括り
            //this.uOptionSet_TieChar.CheckedIndex = Int32.Parse(patternValue[5].ToString());

            //// タイトル行
            //this.uOptionSet_TitleLine.CheckedIndex = Int32.Parse(patternValue[6].ToString());

            //// グリッド
            //this._gridSetting_Slip = patternValue[7].ToString();
            //this._gridSetting_Detail = patternValue[8].ToString();

            //// カラム設定
            //InitializeGridColumns(this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns, 0);
            InitializeGridColumns(this.uGrid_ColumnItemSelector2.DisplayLayout.Bands[0].Columns, 1);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
            // ＵＩ表示
            SetDisplayFromPattern( patternValue );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
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
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                //----- ADD 2015/09/17 田建委 Redmine#47006 ---------->>>>>
                // 「返品伝票金額をマイナスで出力する」チェックオンの場合、
                if (patternValue[11] == "1")
                {
                    this.uCheckEditor_RetSlipMinus_Saleslip.Checked = true;
                }
                else
                {
                    this.uCheckEditor_RetSlipMinus_Saleslip.Checked = false;
                }

                // 「マイナス金額にはマイナス記号を付与する」チェックオンの場合、
                if (patternValue[12] == "1")
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
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/27 ADD

        /// <summary>
        /// データグリッドセット
        /// </summary>
        /// <param name="Columns"></param>
        /// <param name="tabNo"></param>
        /// <remarks>
        /// <br>Update Note : 2013/01/21 FSI冨樫 紗由里</br>
        /// <br>              [仕入返品予定機能] 選択チェックボックスの除外処理を追加</br>
        /// <br>Update Note: 2013/04/16 gezh</br>
        /// <br>管理番号   : 10901273-00 2013/05/15配信分</br>
        /// <br>             Redmine#35309 №1871_仕入先電子元帳のテキスト出力の障害対応</br>
        /// </remarks>
        private void InitializeGridColumns(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns, int tabNo)
        {
            // 表示位置初期値
            int visiblePosition = 1;

            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //非表示設定
                column.Hidden = true;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
                column.ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
                column.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False; // m.suzuki 2009/02/20 True->False

                column.AutoEdit = false;
                column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }


            switch (tabNo)
            {
                case 0:
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
                        # region // DEL
                        //#region 伝票

                        //// 設定があればそれに従い、なければ全表示
                        //if (String.IsNullOrEmpty(this._gridSetting_Slip))
                        //{
                        //    #region 伝票グリッドヘッダ作成（設定なし）

                        //    // 伝票日付
                        //    // カラムチューザ：対象　　フォーマット：日付（yyyy/mm/dd）
                        //    Columns[this._dataSet.StcList.StockDateColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.StockDateColumn.ColumnName].Width = 100;
                        //    Columns[this._dataSet.StcList.StockDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.StockDateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.StockDateColumn.ColumnName].Header.Caption = "伝票日付";
                        //    Columns[this._dataSet.StcList.StockDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.StockDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 伝票番号
                        //    // カラムチューザ：対象　　フォーマット：文字列
                        //    Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].Width = 110;
                        //    Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].Header.Caption = "伝票番号";
                        //    Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 区分名
                        //    // カラムチューザ：対象　　フォーマット：文字列
                        //    Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].Width = 80;
                        //    Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        //    Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].Header.Caption = "区分";
                        //    Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 担当者名
                        //    // カラムチューザ：対象　　フォーマット：文字列
                        //    Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].Width = 100;
                        //    Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].Header.Caption = "担当者名";
                        //    Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 金額
                        //    // カラムチューザ：対象　　フォーマット：金額
                        //    Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].Width = 100;
                        //    Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].Header.Caption = "金額";
                        //    Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 消費税
                        //    // カラムチューザ：対象　　フォーマット：金額
                        //    Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].Width = 100;
                        //    Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].Header.Caption = "消費税";
                        //    Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 備考１
                        //    // カラムチューザ：対象　　フォーマット：文字列
                        //    Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].Width = 100;
                        //    Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].Header.Caption = "備考１";
                        //    Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 備考２
                        //    // カラムチューザ：対象　　フォーマット：文字列
                        //    Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].Width = 100;
                        //    Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].Header.Caption = "備考２";
                        //    Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 拠点コード
                        //    // カラムチューザ：対象外　フォーマット：非表示
                        //    Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].Hidden = true;
                        //    Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].Width = 80;
                        //    Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].Header.Caption = "拠点コード";
                        //    Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 拠点
                        //    // カラムチューザ：対象　　フォーマット：文字列
                        //    Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].Width = 120;
                        //    Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].Header.Caption = "拠点";
                        //    Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 2008.12.05 del start [8726]
                        //    // 発行者
                        //    // カラムチューザ：対象　　フォーマット：文字列
                        //    //Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].Hidden = false;
                        //    //Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].Width = 100;
                        //    //Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    //Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    //Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].Header.Caption = "発行者";
                        //    //Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    //Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        //    // 2008.12.05 del end [8726]

                        //    // 仕入先コード
                        //    // カラムチューザ：対象　　フォーマット：文字列(数値)
                        //    Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].Width = 80;
                        //    Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].Header.Caption = "仕入先コード";
                        //    Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 仕入先名
                        //    // カラムチューザ：対象　　フォーマット：文字列
                        //    Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].Width = 100;
                        //    Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].Header.Caption = "仕入先名";
                        //    Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // UOEリマーク1
                        //    // カラムチューザ：対象　　フォーマット：文字列
                        //    Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].Width = 100;
                        //    Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].Header.Caption = "UOEリマーク1";
                        //    Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // UOEリマーク2
                        //    // カラムチューザ：対象　　フォーマット：文字列
                        //    Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].Width = 100;
                        //    Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].Header.Caption = "UOEリマーク2";
                        //    Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 仕入SEQ/支払No
                        //    // カラムチューザ：対象　　フォーマット：文字列
                        //    Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].Width = 100;
                        //    Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].Header.Caption = "仕入SEQ/支払No";
                        //    Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 計上日
                        //    // カラムチューザ：対象　　フォーマット：文字列(数値)
                        //    Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].Width = 100;
                        //    Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].Header.Caption = "計上日";
                        //    Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 買掛区分名
                        //    // カラムチューザ：対象　　フォーマット：文字列(数値)
                        //    Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].Width = 70;
                        //    Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].Header.Caption = "買掛区分";
                        //    Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 赤伝区分
                        //    // カラムチューザ：対象　　フォーマット：文字列(数値)
                        //    Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].Width = 50;
                        //    Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].Header.Caption = "赤伝区分";
                        //    Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    #endregion
                        //}
                        //else
                        //{
                        //    #region 伝票グリッドヘッダ作成（設定あり）

                        //    string[] gridPattern = new string[18];
                        //    getGridSettingPattern(this._gridSetting_Slip, out gridPattern, true);

                        //    int position = 0;

                        //    // 伝票日付
                        //    position = Int32.Parse(gridPattern[0].ToString());
                        //    Columns[this._dataSet.StcList.StockDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.StockDateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.StockDateColumn.ColumnName].Header.Caption = "伝票日付";
                        //    Columns[this._dataSet.StcList.StockDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.StockDateColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.StockDateColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.StockDateColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.StockDateColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 伝票番号
                        //    position = Int32.Parse(gridPattern[1].ToString());
                        //    Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].Header.Caption = "伝票番号";
                        //    Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 区分名
                        //    position = Int32.Parse(gridPattern[2].ToString());
                        //    Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        //    Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].Header.Caption = "区分";
                        //    Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 担当者名
                        //    position = Int32.Parse(gridPattern[3].ToString());
                        //    Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].Header.Caption = "担当者名";
                        //    Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 金額
                        //    position = Int32.Parse(gridPattern[4].ToString());
                        //    Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].Header.Caption = "金額";
                        //    Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 消費税
                        //    position = Int32.Parse(gridPattern[5].ToString());
                        //    Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].Header.Caption = "消費税";
                        //    Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 備考１
                        //    position = Int32.Parse(gridPattern[6].ToString());
                        //    Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].Header.Caption = "備考１";
                        //    Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 備考２
                        //    position = Int32.Parse(gridPattern[7].ToString());
                        //    Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].Header.Caption = "備考２";
                        //    Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 拠点コード
                        //    position = Int32.Parse(gridPattern[8].ToString());
                        //    Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].Header.Caption = "拠点コード";
                        //    Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 拠点
                        //    position = Int32.Parse(gridPattern[9].ToString());
                        //    Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].Header.Caption = "拠点";
                        //    Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 2008.12.05 del start [8726]
                        //    // 発行者
                        //    //position = Int32.Parse(gridPattern[10].ToString());
                        //    //Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    //Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    //Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].Header.Caption = "発行者";
                        //    //Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    //if (position > 100)
                        //    //{
                        //    //    Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].Hidden = true;
                        //    //    Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    //}
                        //    //else
                        //    //{
                        //    //    Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].Hidden = false;
                        //    //    Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    //}
                        //    // 2008.12.05 del end [8726]

                        //    // 仕入先コード
                        //    position = Int32.Parse(gridPattern[11].ToString());
                        //    Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].Header.Caption = "仕入先コード";
                        //    Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 仕入先名
                        //    position = Int32.Parse(gridPattern[12].ToString());
                        //    Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].Header.Caption = "仕入先名";
                        //    Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // UOEリマーク1
                        //    position = Int32.Parse(gridPattern[13].ToString());
                        //    Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].Header.Caption = "UOEリマーク1";
                        //    Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].Header.VisiblePosition = position;
                        //    }
      
                        //    // UOEリマーク2
                        //    position = Int32.Parse(gridPattern[14].ToString());
                        //    Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].Header.Caption = "UOEリマーク2";
                        //    Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 仕入SEQ/支払No
                        //    position = Int32.Parse(gridPattern[15].ToString());
                        //    Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].Header.Caption = "仕入SEQ/支払No";
                        //    Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 計上日
                        //    position = Int32.Parse(gridPattern[16].ToString());
                        //    Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].Header.Caption = "計上日";
                        //    Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 買掛区分名
                        //    position = Int32.Parse(gridPattern[17].ToString());
                        //    Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].Header.Caption = "買掛区分";
                        //    Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 赤伝区分
                        //    position = Int32.Parse(gridPattern[18].ToString());
                        //    Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].Header.Caption = "赤伝区分";
                        //    Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    #endregion
                        //}

                        //#region カラムチューザ設定

                        ////--------------------------------------------------------------------------------
                        ////  カラムチューザを有効にする
                        ////--------------------------------------------------------------------------------
                        //this.uGrid_ColumnItemSelector.DisplayLayout.ColumnChooserEnabled = Infragistics.Win.DefaultableBoolean.True;
                        //this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton;
                        //this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorWidth = 24;

                        //// カラムチューザボタンの外観を設定
                        //this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor = this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackColor;
                        //this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor2 = this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackColor2;
                        //this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.BackGradientStyle = this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle;
                        //this.uGrid_ColumnItemSelector.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
                        //this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;

                        //this.uGrid_ColumnItemSelector.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        //this.uGrid_ColumnItemSelector.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.WithinGroup;

                        //#endregion // カラムチューザ設定

                        //// 列幅自動調整を設定値にしたがって行う
                        //autoColumnAdjust(false, 0);

                        //#endregion // 伝票
                        # endregion
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
                        string[] gridPattern = new string[0];
                        if ( !string.IsNullOrEmpty( _gridSetting_Slip ) )
                        {
                            getGridSettingPattern( this._gridSetting_Slip, out gridPattern, true );
                        }

                        int position = 0;


                        foreach ( Infragistics.Win.UltraWinGrid.UltraGridColumn orgCol in _slipColCollection )
                        {
                            // ----------ADD 2013/01/21----------->>>>>
                            // 選択用のチェックボックスは除外
                            if (orgCol.Key == _dataSet.StcList.SelectionColumn.ColumnName) continue;
                            // ----------ADD 2013/01/21-----------<<<<<

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
                                // 設定あり
                                position = GetColumnPositionOfSlip( gridPattern, orgCol.Key );
                                //if ( position > 100 )  // DEL 2013/04/16 gezh FOR Redmine#35309
                                if (position >= 100)  // ADD 2013/04/16 gezh FOR Redmine#35309
                                {
                                    Columns[orgCol.Key].Hidden = true;
                                    Columns[orgCol.Key].Header.VisiblePosition = position - 100;
                                }
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

                        #region カラムチューザ設定

                        //--------------------------------------------------------------------------------
                        //  カラムチューザを有効にする
                        //--------------------------------------------------------------------------------
                        this.uGrid_ColumnItemSelector.DisplayLayout.ColumnChooserEnabled = Infragistics.Win.DefaultableBoolean.True;
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton;
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorWidth = 24;

                        // カラムチューザボタンの外観を設定
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromArgb( 89, 135, 214 );
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb( 7, 59, 150 );
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor = this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackColor;
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor2 = this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackColor2;
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.BackGradientStyle = this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle;
                        this.uGrid_ColumnItemSelector.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;

                        #endregion // カラムチューザ設定

                        // 列幅自動調整を設定値にしたがって行う
                        autoColumnAdjust( false, 0 );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
                        break;
                    }
                case 1:
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
                        # region // DEL
                        //#region 明細

                        //// 設定があればそれに従い、なければ全表示
                        //if (String.IsNullOrEmpty(this._gridSetting_Detail))
                        //{
                        //    #region 明細グリッドヘッダ作成（設定なし）

                        //    // 伝票日付
                        //    Columns[this._dataSet.StcDetail.StockDateColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.StockDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.StockDateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockDateColumn.ColumnName].Header.Caption = "伝票日付";
                        //    Columns[this._dataSet.StcDetail.StockDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.StockDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 伝票番号
                        //    Columns[this._dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName].Header.Caption = "伝票番号";
                        //    Columns[this._dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 行No
                        //    Columns[this._dataSet.StcDetail.StockRowNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.StockRowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcDetail.StockRowNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockRowNoColumn.ColumnName].Header.Caption = "行No";
                        //    Columns[this._dataSet.StcDetail.StockRowNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.StockRowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 区分名
                        //    Columns[this._dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName].Header.Caption = "区分";
                        //    Columns[this._dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 担当者名
                        //    Columns[this._dataSet.StcDetail.StockAgentNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.StockAgentNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.StockAgentNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockAgentNameColumn.ColumnName].Header.Caption = "担当者名";
                        //    Columns[this._dataSet.StcDetail.StockAgentNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.StockAgentNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 金額
                        //    Columns[this._dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName].Header.Caption = "金額";
                        //    Columns[this._dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 品名
                        //    Columns[this._dataSet.StcDetail.GoodsNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.GoodsNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.GoodsNameColumn.ColumnName].Header.Caption = "品名";
                        //    Columns[this._dataSet.StcDetail.GoodsNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.GoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 品番
                        //    Columns[this._dataSet.StcDetail.GoodsNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.GoodsNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.GoodsNoColumn.ColumnName].Header.Caption = "品番";
                        //    Columns[this._dataSet.StcDetail.GoodsNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.GoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // メーカーコード
                        //    Columns[this._dataSet.StcDetail.GoodsMakerCdColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.GoodsMakerCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.GoodsMakerCdColumn.ColumnName].Header.Caption = "メーカーコード";
                        //    Columns[this._dataSet.StcDetail.GoodsMakerCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // メーカー
                        //    Columns[this._dataSet.StcDetail.MakerNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.MakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.MakerNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.MakerNameColumn.ColumnName].Header.Caption = "メーカー";
                        //    Columns[this._dataSet.StcDetail.MakerNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.MakerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // BLコード
                        //    Columns[this._dataSet.StcDetail.BLGoodsCodeColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.BLGoodsCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.BLGoodsCodeColumn.ColumnName].Header.Caption = "BLｺｰﾄﾞ";
                        //    Columns[this._dataSet.StcDetail.BLGoodsCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // BLグループ
                        //    Columns[this._dataSet.StcDetail.BLGroupCodeColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.BLGroupCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.BLGroupCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.BLGroupCodeColumn.ColumnName].Header.Caption = "BLｸﾞﾙｰﾌﾟ";
                        //    Columns[this._dataSet.StcDetail.BLGroupCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.BLGroupCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 ADD
                        //    // 仕入原価
                        //    //Columns[this._dataSet.StcDetail.stockuni.ColumnName].Hidden = false;
                        //    //Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    //Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    //Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].Header.Caption = "標準価格";
                        //    //Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    //Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 ADD

                        //    // 数量
                        //    Columns[this._dataSet.StcDetail.StockCountColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.StockCountColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcDetail.StockCountColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockCountColumn.ColumnName].Header.Caption = "数量";
                        //    Columns[this._dataSet.StcDetail.StockCountColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.StockCountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 標準価格
                        //    Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].Header.Caption = "標準価格";
                        //    Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 消費税
                        //    Columns[this._dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName].Header.Caption = "消費税";
                        //    Columns[this._dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 備考１
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote1Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote1Column.ColumnName].Header.Caption = "備考１";
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote1Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 備考２
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote2Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote2Column.ColumnName].Header.Caption = "備考２";
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote2Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 拠点コード
                        //    Columns[this._dataSet.StcDetail.SectionCdColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.SectionCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcDetail.SectionCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SectionCdColumn.ColumnName].Header.Caption = "拠点コード";
                        //    Columns[this._dataSet.StcDetail.SectionCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.SectionCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 拠点
                        //    Columns[this._dataSet.StcDetail.SectionGuideNmColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.SectionGuideNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SectionGuideNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SectionGuideNmColumn.ColumnName].Header.Caption = "拠点";
                        //    Columns[this._dataSet.StcDetail.SectionGuideNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.SectionGuideNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 2008.12.05 del start [8726]
                        //    // 発行者
                        //    //Columns[this._dataSet.StcDetail.StockInputNameColumn.ColumnName].Hidden = false;
                        //    //Columns[this._dataSet.StcDetail.StockInputNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    //Columns[this._dataSet.StcDetail.StockInputNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    //Columns[this._dataSet.StcDetail.StockInputNameColumn.ColumnName].Header.Caption = "発行者";
                        //    //Columns[this._dataSet.StcDetail.StockInputNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    //Columns[this._dataSet.StcDetail.StockInputNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        //    // 2008.12.05 del end [8726]

                        //    // 仕入先コード
                        //    Columns[this._dataSet.StcDetail.SupplierCdColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcDetail.SupplierCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SupplierCdColumn.ColumnName].Header.Caption = "仕入先コード";
                        //    Columns[this._dataSet.StcDetail.SupplierCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.SupplierCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 仕入先
                        //    Columns[this._dataSet.StcDetail.SupplierSnmColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.SupplierSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SupplierSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SupplierSnmColumn.ColumnName].Header.Caption = "仕入先";
                        //    Columns[this._dataSet.StcDetail.SupplierSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.SupplierSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 在庫取寄区分
                        //    Columns[this._dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName].Header.Caption = "在庫取寄区分";
                        //    Columns[this._dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 倉庫コード
                        //    Columns[this._dataSet.StcDetail.WarehouseCdColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.WarehouseCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.WarehouseCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.WarehouseCdColumn.ColumnName].Header.Caption = "倉庫コード";
                        //    Columns[this._dataSet.StcDetail.WarehouseCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.WarehouseCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 倉庫
                        //    Columns[this._dataSet.StcDetail.WarehouseNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.WarehouseNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.WarehouseNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.WarehouseNameColumn.ColumnName].Header.Caption = "倉庫";
                        //    Columns[this._dataSet.StcDetail.WarehouseNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.WarehouseNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 棚番
                        //    Columns[this._dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName].Header.Caption = "棚番";
                        //    Columns[this._dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // UOEリマーク１
                        //    Columns[this._dataSet.StcDetail.UoeRemark1Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.UoeRemark1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.UoeRemark1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.UoeRemark1Column.ColumnName].Header.Caption = "UOEリマーク１";
                        //    Columns[this._dataSet.StcDetail.UoeRemark1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.UoeRemark1Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // UOEリマーク２
                        //    Columns[this._dataSet.StcDetail.UoeRemark2Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.UoeRemark2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.UoeRemark2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.UoeRemark2Column.ColumnName].Header.Caption = "UOEリマーク２";
                        //    Columns[this._dataSet.StcDetail.UoeRemark2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.UoeRemark2Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 仕入SEQ/支払No
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName].Header.Caption = "仕入SEQ/支払No";
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 計上日
                        //    Columns[this._dataSet.StcDetail.StockAddUpADateColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.StockAddUpADateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.StockAddUpADateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockAddUpADateColumn.ColumnName].Header.Caption = "計上日";
                        //    Columns[this._dataSet.StcDetail.StockAddUpADateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.StockAddUpADateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 買掛区分名
                        //    Columns[this._dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName].Header.Caption = "買掛区分";
                        //    Columns[this._dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 赤伝区分
                        //    Columns[this._dataSet.StcDetail.DebitNoteDivColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.DebitNoteDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.DebitNoteDivColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.DebitNoteDivColumn.ColumnName].Header.Caption = "赤伝区分";
                        //    Columns[this._dataSet.StcDetail.DebitNoteDivColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.DebitNoteDivColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 同時売上伝票番号
                        //    Columns[this._dataSet.StcDetail.SalesSlipNumColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.SalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SalesSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SalesSlipNumColumn.ColumnName].Header.Caption = "同時売上伝票番号";
                        //    Columns[this._dataSet.StcDetail.SalesSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 同時売上日付
                        //    Columns[this._dataSet.StcDetail.SalesDateColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.SalesDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SalesDateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SalesDateColumn.ColumnName].Header.Caption = "同時売上日付";
                        //    Columns[this._dataSet.StcDetail.SalesDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.SalesDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 得意先コード
                        //    Columns[this._dataSet.StcDetail.CustomerCodeColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.CustomerCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.CustomerCodeColumn.ColumnName].Header.Caption = "得意先コード";
                        //    Columns[this._dataSet.StcDetail.CustomerCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.CustomerCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 得意先名
                        //    Columns[this._dataSet.StcDetail.CustomerSnmColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.CustomerSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.CustomerSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.CustomerSnmColumn.ColumnName].Header.Caption = "得意先名";
                        //    Columns[this._dataSet.StcDetail.CustomerSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.CustomerSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    #endregion // 明細グリッドヘッダ作成（設定なし）
                        //}
                        //else
                        //{
                        //    #region 明細グリッドヘッダ作成（設定あり）

                        //    string[] gridPattern = new string[35];
                        //    getGridSettingPattern(this._gridSetting_Detail, out gridPattern, false);

                        //    int position = 0;

                        //    // 伝票日付
                        //    position = Int32.Parse(gridPattern[0].ToString());
                        //    Columns[this._dataSet.StcDetail.StockDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.StockDateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockDateColumn.ColumnName].Header.Caption = "伝票日付";
                        //    Columns[this._dataSet.StcDetail.StockDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockDateColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.StockDateColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockDateColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.StockDateColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 伝票番号
                        //    position = Int32.Parse(gridPattern[1].ToString());
                        //    Columns[this._dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName].Header.Caption = "伝票番号";
                        //    Columns[this._dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 行No
                        //    position = Int32.Parse(gridPattern[2].ToString());
                        //    Columns[this._dataSet.StcDetail.StockRowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcDetail.StockRowNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockRowNoColumn.ColumnName].Header.Caption = "行No";
                        //    Columns[this._dataSet.StcDetail.StockRowNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockRowNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.StockRowNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockRowNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.StockRowNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 区分名
                        //    position = Int32.Parse(gridPattern[3].ToString());
                        //    Columns[this._dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName].Header.Caption = "区分";
                        //    Columns[this._dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 担当者名
                        //    position = Int32.Parse(gridPattern[4].ToString());
                        //    Columns[this._dataSet.StcDetail.StockAgentNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.StockAgentNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockAgentNameColumn.ColumnName].Header.Caption = "担当者名";
                        //    Columns[this._dataSet.StcDetail.StockAgentNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockAgentNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.StockAgentNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockAgentNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.StockAgentNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 金額
                        //    position = Int32.Parse(gridPattern[5].ToString());
                        //    Columns[this._dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName].Header.Caption = "金額";
                        //    Columns[this._dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 品名
                        //    position = Int32.Parse(gridPattern[6].ToString());
                        //    Columns[this._dataSet.StcDetail.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.GoodsNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.GoodsNameColumn.ColumnName].Header.Caption = "品名";
                        //    Columns[this._dataSet.StcDetail.GoodsNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.GoodsNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.GoodsNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.GoodsNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.GoodsNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 品番
                        //    position = Int32.Parse(gridPattern[7].ToString());
                        //    Columns[this._dataSet.StcDetail.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.GoodsNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.GoodsNoColumn.ColumnName].Header.Caption = "品番";
                        //    Columns[this._dataSet.StcDetail.GoodsNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.GoodsNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.GoodsNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.GoodsNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.GoodsNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // メーカーコード
                        //    position = Int32.Parse(gridPattern[8].ToString());
                        //    Columns[this._dataSet.StcDetail.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.GoodsMakerCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.GoodsMakerCdColumn.ColumnName].Header.Caption = "メーカーコード";
                        //    Columns[this._dataSet.StcDetail.GoodsMakerCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.GoodsMakerCdColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.GoodsMakerCdColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // メーカー
                        //    position = Int32.Parse(gridPattern[9].ToString());
                        //    Columns[this._dataSet.StcDetail.MakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.MakerNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.MakerNameColumn.ColumnName].Header.Caption = "メーカー";
                        //    Columns[this._dataSet.StcDetail.MakerNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.MakerNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.MakerNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.MakerNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.MakerNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // BLコード
                        //    position = Int32.Parse(gridPattern[10].ToString());
                        //    Columns[this._dataSet.StcDetail.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.BLGoodsCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.BLGoodsCodeColumn.ColumnName].Header.Caption = "BLｺｰﾄﾞ";
                        //    Columns[this._dataSet.StcDetail.BLGoodsCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.BLGoodsCodeColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.BLGoodsCodeColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // BLグループ
                        //    position = Int32.Parse(gridPattern[11].ToString());
                        //    Columns[this._dataSet.StcDetail.BLGroupCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.BLGroupCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.BLGroupCodeColumn.ColumnName].Header.Caption = "BLｸﾞﾙｰﾌﾟ";
                        //    Columns[this._dataSet.StcDetail.BLGroupCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.BLGroupCodeColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.BLGroupCodeColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.BLGroupCodeColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.BLGroupCodeColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // 数量
                        //    position = Int32.Parse(gridPattern[12].ToString());
                        //    Columns[this._dataSet.StcDetail.StockCountColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcDetail.StockCountColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockCountColumn.ColumnName].Header.Caption = "数量";
                        //    Columns[this._dataSet.StcDetail.StockCountColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockCountColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.StockCountColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockCountColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.StockCountColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // 標準価格
                        //    position = Int32.Parse(gridPattern[13].ToString());
                        //    Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].Header.Caption = "標準価格";
                        //    Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // 消費税
                        //    position = Int32.Parse(gridPattern[14].ToString());
                        //    Columns[this._dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName].Header.Caption = "消費税";
                        //    Columns[this._dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // 備考１
                        //    position = Int32.Parse(gridPattern[15].ToString());
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote1Column.ColumnName].Header.Caption = "備考１";
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.SupplierSlipNote1Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.SupplierSlipNote1Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.SupplierSlipNote1Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.SupplierSlipNote1Column.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 備考２
                        //    position = Int32.Parse(gridPattern[16].ToString());
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote2Column.ColumnName].Header.Caption = "備考２";
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.SupplierSlipNote2Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.SupplierSlipNote2Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.SupplierSlipNote2Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.SupplierSlipNote2Column.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 拠点コード
                        //    position = Int32.Parse(gridPattern[17].ToString());
                        //    Columns[this._dataSet.StcDetail.SectionCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcDetail.SectionCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SectionCdColumn.ColumnName].Header.Caption = "拠点コード";
                        //    Columns[this._dataSet.StcDetail.SectionCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.SectionCdColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.SectionCdColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.SectionCdColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.SectionCdColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 拠点
                        //    position = Int32.Parse(gridPattern[18].ToString());
                        //    Columns[this._dataSet.StcDetail.SectionGuideNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SectionGuideNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SectionGuideNmColumn.ColumnName].Header.Caption = "拠点";
                        //    Columns[this._dataSet.StcDetail.SectionGuideNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.SectionGuideNmColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.SectionGuideNmColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.SectionGuideNmColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.SectionGuideNmColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 2008.12.05 del start [8726]
                        //    // 発行者
                        //    //position = Int32.Parse(gridPattern[19].ToString());
                        //    //Columns[this._dataSet.StcDetail.StockInputNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    //Columns[this._dataSet.StcDetail.StockInputNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    //Columns[this._dataSet.StcDetail.StockInputNameColumn.ColumnName].Header.Caption = "発行者";
                        //    //Columns[this._dataSet.StcDetail.StockInputNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    //if (position > 100)
                        //    //{
                        //    //    Columns[this._dataSet.StcDetail.StockInputNameColumn.ColumnName].Hidden = true;
                        //    //    Columns[this._dataSet.StcDetail.StockInputNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    //}
                        //    //else
                        //    //{
                        //    //    Columns[this._dataSet.StcDetail.StockInputNameColumn.ColumnName].Hidden = false;
                        //    //    Columns[this._dataSet.StcDetail.StockInputNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    //}
                        //    // 2008.12.05 del end [8726]

                        //    // 仕入先コード
                        //    position = Int32.Parse(gridPattern[20].ToString());
                        //    Columns[this._dataSet.StcDetail.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SupplierCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SupplierCdColumn.ColumnName].Header.Caption = "仕入先コード";
                        //    Columns[this._dataSet.StcDetail.SupplierCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.SupplierCdColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.SupplierCdColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.SupplierCdColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.SupplierCdColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 仕入先
                        //    position = Int32.Parse(gridPattern[21].ToString());
                        //    Columns[this._dataSet.StcDetail.SupplierSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcDetail.SupplierSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SupplierSnmColumn.ColumnName].Header.Caption = "仕入先";
                        //    Columns[this._dataSet.StcDetail.SupplierSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.SupplierSnmColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.SupplierSnmColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.SupplierSnmColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.SupplierSnmColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 在庫取寄区分
                        //    position = Int32.Parse(gridPattern[22].ToString());
                        //    Columns[this._dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName].Header.Caption = "在庫取寄区分";
                        //    Columns[this._dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 倉庫コード
                        //    position = Int32.Parse(gridPattern[23].ToString());
                        //    Columns[this._dataSet.StcDetail.WarehouseCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.WarehouseCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.WarehouseCdColumn.ColumnName].Header.Caption = "倉庫コード";
                        //    Columns[this._dataSet.StcDetail.WarehouseCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.WarehouseCdColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.WarehouseCdColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.WarehouseCdColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.WarehouseCdColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 倉庫
                        //    position = Int32.Parse(gridPattern[24].ToString());
                        //    Columns[this._dataSet.StcDetail.WarehouseNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.WarehouseNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.WarehouseNameColumn.ColumnName].Header.Caption = "倉庫";
                        //    Columns[this._dataSet.StcDetail.WarehouseNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.WarehouseNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.WarehouseNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.WarehouseNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.WarehouseNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // 棚番
                        //    position = Int32.Parse(gridPattern[25].ToString());
                        //    Columns[this._dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName].Header.Caption = "棚番";
                        //    Columns[this._dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // UOEリマーク１
                        //    position = Int32.Parse(gridPattern[26].ToString());
                        //    Columns[this._dataSet.StcDetail.UoeRemark1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.UoeRemark1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.UoeRemark1Column.ColumnName].Header.Caption = "UOEリマーク１";
                        //    Columns[this._dataSet.StcDetail.UoeRemark1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.UoeRemark1Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.UoeRemark1Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.UoeRemark1Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.UoeRemark1Column.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // UOEリマーク２
                        //    position = Int32.Parse(gridPattern[27].ToString());
                        //    Columns[this._dataSet.StcDetail.UoeRemark2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.UoeRemark2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.UoeRemark2Column.ColumnName].Header.Caption = "UOEリマーク２";
                        //    Columns[this._dataSet.StcDetail.UoeRemark2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.UoeRemark2Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.UoeRemark2Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.UoeRemark2Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.UoeRemark2Column.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // 仕入SEQ/支払No
                        //    position = Int32.Parse(gridPattern[28].ToString());
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName].Header.Caption = "仕入SEQ/支払No";
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // 計上日
                        //    position = Int32.Parse(gridPattern[29].ToString());
                        //    Columns[this._dataSet.StcDetail.StockAddUpADateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.StockAddUpADateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockAddUpADateColumn.ColumnName].Header.Caption = "計上日";
                        //    Columns[this._dataSet.StcDetail.StockAddUpADateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockAddUpADateColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.StockAddUpADateColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockAddUpADateColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.StockAddUpADateColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // 買掛区分名
                        //    position = Int32.Parse(gridPattern[30].ToString());
                        //    Columns[this._dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName].Header.Caption = "買掛区分";
                        //    Columns[this._dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // 赤伝区分
                        //    position = Int32.Parse(gridPattern[31].ToString());
                        //    Columns[this._dataSet.StcDetail.DebitNoteDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.DebitNoteDivColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.DebitNoteDivColumn.ColumnName].Header.Caption = "赤伝区分";
                        //    Columns[this._dataSet.StcDetail.DebitNoteDivColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.DebitNoteDivColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.DebitNoteDivColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.DebitNoteDivColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.DebitNoteDivColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
             
                        //    // 同時売上伝票番号
                        //    position = Int32.Parse(gridPattern[32].ToString());
                        //    Columns[this._dataSet.StcDetail.SalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SalesSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SalesSlipNumColumn.ColumnName].Header.Caption = "同時売上伝票番号";
                        //    Columns[this._dataSet.StcDetail.SalesSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.SalesSlipNumColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.SalesSlipNumColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // 同時売上日付
                        //    position = Int32.Parse(gridPattern[33].ToString());
                        //    Columns[this._dataSet.StcDetail.SalesDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SalesDateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SalesDateColumn.ColumnName].Header.Caption = "同時売上日付";
                        //    Columns[this._dataSet.StcDetail.SalesDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.SalesDateColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.SalesDateColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.SalesDateColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.SalesDateColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // 得意先コード
                        //    position = Int32.Parse(gridPattern[34].ToString());
                        //    Columns[this._dataSet.StcDetail.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.CustomerCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.CustomerCodeColumn.ColumnName].Header.Caption = "得意先コード";
                        //    Columns[this._dataSet.StcDetail.CustomerCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.CustomerCodeColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.CustomerCodeColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.CustomerCodeColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.CustomerCodeColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                           
                        //    // 得意先名
                        //    position = Int32.Parse(gridPattern[35].ToString());
                        //    Columns[this._dataSet.StcDetail.CustomerSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.CustomerSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.CustomerSnmColumn.ColumnName].Header.Caption = "得意先名";
                        //    Columns[this._dataSet.StcDetail.CustomerSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.CustomerSnmColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.CustomerSnmColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.CustomerSnmColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.CustomerSnmColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                        
                        //    #endregion // 明細グリッドヘッダ作成（設定あり）
                        //}

                        //#region カラムチューザ設定

                        ////--------------------------------------------------------------------------------
                        ////  カラムチューザを有効にする
                        ////--------------------------------------------------------------------------------
                        //this.uGrid_ColumnItemSelector2.DisplayLayout.ColumnChooserEnabled = Infragistics.Win.DefaultableBoolean.True;
                        //this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton;
                        //this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorWidth = 24;

                        //// カラムチューザボタンの外観を設定		
                        //this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor = this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackColor;
                        //this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor2 = this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackColor2;
                        //this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderAppearance.BackGradientStyle = this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle;
                        //this.uGrid_ColumnItemSelector2.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
                        //this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderAppearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;

                        //this.uGrid_ColumnItemSelector2.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        //this.uGrid_ColumnItemSelector2.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.WithinGroup;


                        //#endregion // カラムチューザ設定

                        //// 列幅自動調整を設定値にしたがって行う
                        //autoColumnAdjust(false, 1);

                        //#endregion //明細
                        # endregion
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
                        string[] gridPattern = new string[0];
                        if ( !string.IsNullOrEmpty( _gridSetting_Detail ) )
                        {
                            getGridSettingPattern( this._gridSetting_Detail, out gridPattern, true );
                        }

                        int position = 0;


                        foreach ( Infragistics.Win.UltraWinGrid.UltraGridColumn orgCol in _detailColCollection )
                        {
                            // ----------ADD 2013/01/21----------->>>>>
                            // 選択用のチェックボックスは除外
                            if (orgCol.Key == _dataSet.StcDetail.SelectionCheckColumn.ColumnName) continue;
                            // ----------ADD 2013/01/21-----------<<<<<

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
                                // 設定あり
                                position = GetColumnPositionOfDetail( gridPattern, orgCol.Key );
                                //if ( position > 100 )  // DEL 2013/04/16 gezh FOR Redmine#35309
                                if (position >= 100)  // ADD 2013/04/16 gezh FOR Redmine#35309
                                {
                                    Columns[orgCol.Key].Hidden = true;
                                    Columns[orgCol.Key].Header.VisiblePosition = position - 100;
                                }
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

                        #region カラムチューザ設定

                        //--------------------------------------------------------------------------------
                        //  カラムチューザを有効にする
                        //--------------------------------------------------------------------------------
                        this.uGrid_ColumnItemSelector2.DisplayLayout.ColumnChooserEnabled = Infragistics.Win.DefaultableBoolean.True;
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton;
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorWidth = 24;

                        // カラムチューザボタンの外観を設定		
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromArgb( 89, 135, 214 );
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb( 7, 59, 150 );
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor = this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackColor;
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor2 = this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackColor2;
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderAppearance.BackGradientStyle = this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle;
                        this.uGrid_ColumnItemSelector2.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderAppearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;

                        #endregion // カラムチューザ設定

                        // 列幅自動調整を設定値にしたがって行う
                        autoColumnAdjust( false, 1 );

                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

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
                            this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
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
                            this.uGrid_ColumnItemSelector2.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
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
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
            //// ファイル名
            //if (String.IsNullOrEmpty(this.tEdit_SettingFileName.Text.Trim()))
            //{
            //    string path =this.tEdit_SettingFileName.Text.Trim();
            //    if (!path.Contains("\\"))
            //    {
            //        return false;
            //    }
            //    else if (Directory.Exists(path))
            //    {
            //        // dirPathのディレクトリは存在する
            //        path = path.Substring(0, path.IndexOf("\\"));
            //        if (!Directory.Exists(path)) return false;
            //    } 
            //    return false;
            //}
            
            //// パターン名
            //if (String.IsNullOrEmpty(this.tComboEditor_PetternSelect.Text.Trim())) return false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
            // ファイル名
            // 2010/04/05 Add テキスト出力オプションが立っていない場合はチェックしない >>>
            if (this._opt_TextOutput == (int)Option.ON)
            {
                // --- DEL 2010/09/28 障害報告 #15619 ---------->>>>>
                // 2010/04/05 Add <<<
                //if (String.IsNullOrEmpty(this.tEdit_SettingFileName.Text.Trim()))
                //{
                //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, MSG_OUTPUTTEXT_NOFILENAME, -1, MessageBoxButtons.OK);
                //    this.tEdit_SettingFileName.Focus();
                //    return false;
                //}
                // --- DEL 2010/09/28 障害報告 #15619 ----------<<<<<
            }   // 2010/04/05 Add

            // パターン名
            if ( String.IsNullOrEmpty( this.tComboEditor_PetternSelect.Text.Trim() ) )
            {
                TMsgDisp.Show( this, emErrorLevel.ERR_LEVEL_INFO, this.Name, MSG_OUTPUTTEXT_NOPATTERN, -1, MessageBoxButtons.OK );
                this.tComboEditor_PetternSelect.Focus();
                return false;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
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
                //----- ADD 2015/09/17 田建委 Redmine#47006 ---------->>>>>
                string value12 = string.Empty;
                if (this.uCheckEditor_RetSlipMinus_Saleslip.Checked)
                {
                    // 「返品伝票金額をマイナスで出力する」をチェックオンする場合、「1」とする
                    value12 = "1";
                }
                else
                {
                    // 「返品伝票金額をマイナスで出力する」をチェックオフする場合、「0」とする
                    value12 = "0";
                }

                string value13 = string.Empty;
                if (this.uCheckEditor_RetSlipMinus_Meisai.Checked)
                {
                    // 「マイナス金額にはマイナス記号を付与する」をチェックオンする場合、「1」とする
                    value13 = "1";
                }
                else
                {
                    // 「マイナス金額にはマイナス記号を付与する」をチェックオフする場合、「0」とする
                    value13 = "0";
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
                        //value11; // DEL 2015/09/17 田建委 Redmine#47006
                        //----- ADD 2015/09/17 田建委 Redmine#47006 ---------->>>>>
                        value11 + this._divider +
                        value12 + this._divider +
                        value13;
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
        private void createGridPatternString(bool isSlip, out string patternString)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
            # region // DEL
            //patternString = string.Empty;

            //if (isSlip)
            //{
            //    #region 伝票グリッド

            //    string[] gridHeaderPattern = new string[18];

            //    Infragistics.Win.UltraWinGrid.ColumnsCollection col = this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns;
            //    //if (col[0].Header.Caption == "
            //    foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in col)
            //    {
            //        switch (column.Header.Caption)
            //        {
            //            case "伝票日付":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[0] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[0] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "伝票番号":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[1] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[1] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "区分":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[2] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[2] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "担当者名":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[3] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[3] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "金額":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[4] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[4] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "消費税":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[5] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[5] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "備考１":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[6] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[6] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "備考２":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[7] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[7] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "拠点コード":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[8] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[8] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "拠点":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[9] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[9] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            // 2008.12.05 del start [8726]
            //            //case "発行者":
            //            //    {
            //            //        if (column.Hidden)
            //            //            gridHeaderPattern[10] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //            //        else
            //            //            gridHeaderPattern[10] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //            //        break;
            //            //    }
            //            // 2008.12.05 del end [8726]
            //            case "仕入先コード":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[10] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[10] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "仕入先名":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[11] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[11] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "UOEリマーク1":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[12] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[12] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "UOEリマーク2":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[13] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[13] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "仕入SEQ/支払No":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[14] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[14] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "計上日":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[15] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[15] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "買掛区分":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[16] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[16] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "赤伝区分":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[17] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[17] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            default: break;
            //        }
            //    }

            //    // 列の順に並ぶように文字列を作成（順番が異なると正常に修正できない）
            //    for (int i = 0; i < 18; i++)
            //    {
            //        patternString = patternString + gridHeaderPattern[i];
            //    }

            //    #endregion // 伝票グリッド
            //}
            //else
            //{
            //    #region 明細グリッド

            //    string[] gridHeaderPattern = new string[35];

            //    // UIに表示されている情報はDisplayLayoutから取る必要がある
            //    Infragistics.Win.UltraWinGrid.ColumnsCollection col = this.uGrid_ColumnItemSelector2.DisplayLayout.Bands[0].Columns;
                
            //    foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in col)
            //    {
            //        switch (column.Header.Caption)
            //        {
            //            case "伝票日付":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[0] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[0] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "伝票番号":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[1] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[1] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "行No":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[2] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[2] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "区分":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[3] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[3] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "担当者名":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[4] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[4] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "金額":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[5] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[5] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "品名":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[6] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[6] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "品番":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[7] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[7] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "メーカーコード":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[8] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[8] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "メーカー":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[9] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[9] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "BLｺｰﾄﾞ":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[10] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[10] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "BLｸﾞﾙｰﾌﾟ":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[11] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[11] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "数量":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[12] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[12] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "標準価格":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[13] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[13] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "消費税":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[14] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[14] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "備考１":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[15] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[15] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "備考２":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[16] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[16] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "拠点コード":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[17] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[17] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "拠点":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[18] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[18] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            // 2008.12.05 del start [8726]
            //            //case "発行者":
            //            //    {
            //            //        if (column.Hidden)
            //            //            gridHeaderPattern[19] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //            //        else
            //            //            gridHeaderPattern[19] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //            //        break;
            //            //    }
            //            // 2008.12.05 del end [8726]
            //            case "仕入先コード":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[19] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[19] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "仕入先":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[20] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[20] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "在庫取寄区分":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[21] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[21] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "倉庫コード":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[22] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[22] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "倉庫":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[23] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[23] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "棚番":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[24] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[24] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "UOEリマーク１":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[25] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[25] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "UOEリマーク２":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[26] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[26] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "仕入SEQ/支払No":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[27] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[27] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "計上日":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[28] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[28] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "売掛区分":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[29] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[29] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "赤伝区分":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[30] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[30] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "同時売上伝票番号":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[31] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[31] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "同時売上日付":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[32] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[32] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "得意先コード":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[33] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[33] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "得意先名":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[34] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[34] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }

            //            default: break;
            //        }
            //    }

            //    // 列の順に並ぶように文字列を作成（順番が異なると正常に修正できない）
            //    for (int i = 0; i < 35; i++)
            //    {
            //        patternString = patternString + gridHeaderPattern[i];
            //    }

            //    #endregion // 明細グリッド
            //}
            # endregion
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
            patternString = string.Empty;

            if ( isSlip )
            {
                #region 伝票グリッド
                Infragistics.Win.UltraWinGrid.ColumnsCollection col = this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns;
                string[] gridHeaderPattern = new string[col.Count];
                foreach ( Infragistics.Win.UltraWinGrid.UltraGridColumn column in col )
                {
                    if ( _columnIndexDicOfSlip.ContainsKey( column.Key ) )
                    {
                        if ( column.Hidden )
                        {
                            gridHeaderPattern[_columnIndexDicOfSlip[column.Key]] = "1" + column.Header.VisiblePosition.ToString().PadLeft( 2, '0' );
                        }
                        else
                        {
                            gridHeaderPattern[_columnIndexDicOfSlip[column.Key]] = "0" + column.Header.VisiblePosition.ToString().PadLeft( 2, '0' );
                        }
                    }
                }
                for ( int i = 0; i < col.Count; i++ )
                {
                    patternString = patternString + gridHeaderPattern[i];
                }

                # endregion
            }
            else
            {
                #region 明細グリッド

                // UIに表示されている情報はDisplayLayoutから取る必要がある
                Infragistics.Win.UltraWinGrid.ColumnsCollection col = this.uGrid_ColumnItemSelector2.DisplayLayout.Bands[0].Columns;
                string[] gridHeaderPattern = new string[col.Count];

                foreach ( Infragistics.Win.UltraWinGrid.UltraGridColumn column in col )
                {
                    if ( _columnIndexDicOfDetail.ContainsKey( column.Key ) )
                    {
                        if ( column.Hidden )
                        {
                            gridHeaderPattern[_columnIndexDicOfDetail[column.Key]] = "1" + column.Header.VisiblePosition.ToString().PadLeft( 2, '0' );
                        }
                        else
                        {
                            gridHeaderPattern[_columnIndexDicOfDetail[column.Key]] = "0" + column.Header.VisiblePosition.ToString().PadLeft( 2, '0' );
                        }
                    }
                }
                for ( int i = 0; i < col.Count; i++ )
                {
                    patternString = patternString + gridHeaderPattern[i];
                }

                # endregion
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
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
                        value12 = "1"; // ADD 2015/09/17 田建委 Redmine#47006
                        value13 = "1"; // ADD 2015/09/17 田建委 Redmine#47006
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
                        value12 = "1"; // ADD 2015/09/17 田建委 Redmine#47006
                        value13 = "1"; // ADD 2015/09/17 田建委 Redmine#47006
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
                        value12 = "1"; // ADD 2015/09/17 田建委 Redmine#47006
                        value13 = "1"; // ADD 2015/09/17 田建委 Redmine#47006
                        break;
                    }

                default: break;
            }
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
                //----- ADD 2015/09/17 田建委 Redmine#47006 ---------->>>>>
                value11 + this._divider +
                value12 + this._divider +
                value13;
                //----- ADD 2015/09/17 田建委 Redmine#47006 ----------<<<<<
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

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
        /// 仕入先電子元帳用ユーザー設定シリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入先電子元帳用ユーザー設定のシリアライズを行います。</br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        /// <br>Update Note : 2010/07/20 chenyd</br>
        /// <br>           　テキスト出力対応</br>
        /// </remarks>
        public void Serialize()
        {
            // ---------------------- ADD  2010/07/20 --------------------------------->>>>>
            //UserSettingController.SerializeUserSetting(_userSetting, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
            UserSettingController.SerializeUserSetting(_userSetting, Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
            // ---------------------- ADD  2010/07/20 ---------------------------------<<<<<
            if (DataChanged != null)
            {
                // データ変更後発生イベント実行
                DataChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// 仕入先電子元帳用ユーザー設定デシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入先電子元帳用ユーザー設定クラスをデシリアライズします。</br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        /// <br>Update Note : 2010/07/20 chenyd</br>
        /// <br>           　テキスト出力対応</br>
        /// <br>Update Note : 2013/01/21 FSI冨樫 紗由里</br>
        /// <br>              [仕入返品予定機能] 選択チェックボックスの補完処理を追加</br>
        /// </remarks>
        public void Deserialize()
        {
            // ---------------------- ADD  2010/07/20 --------------------------------->>>>>
            //if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME))))
            // ---------------------- ADD  2010/07/20 ---------------------------------<<<<<
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
                //this._userSetting = UserSettingController.DeserializeUserSetting<SuppPtrStcUserConst>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
                try
                {
                    // ---------------------- ADD  2010/07/20 --------------------------------->>>>>
                    //this._userSetting = UserSettingController.DeserializeUserSetting<SuppPtrStcUserConst>( Path.Combine( ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME ) );
                    this._userSetting = UserSettingController.DeserializeUserSetting<SuppPtrStcUserConst>(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
                    // ---------------------- ADD  2010/07/20 ---------------------------------<<<<<

                    // ----------ADD 2013/01/21----------->>>>>
                    // 選択チェックボックス（伝票表示用）のユーザー設定の補完処理
                    bool SelectionFlg = false;

                    foreach (ColumnInfo SlipColumnInfo in this._userSetting.SlipColumnsList)
                    {
                        if (SlipColumnInfo.ColumnName == "Selection")
                        {
                            // 選択チェックボックス（伝票表示用）の設定が存在している
                            SelectionFlg = true;
                            break;
                        }
                    }

                    // 選択チェックボックス（伝票表示用）の設定が存在していない場合は補完を行う
                    if (SelectionFlg != true)
                    {
                        // 並び順の再設定
                        for (int i = 0; i < this._userSetting.SlipColumnsList.Count; i++)
                        {
                            ColumnInfo tempSlipColumns = this._userSetting.SlipColumnsList[i];

                            // 選択チェックボックス（伝票表示用）を挿入するため、並び順を1つ後ろにずらす
                            tempSlipColumns.VisiblePosition = this._userSetting.SlipColumnsList[i].VisiblePosition + 1;

                            this._userSetting.SlipColumnsList[i] = tempSlipColumns;
                        }

                        // 選択チェックボックス（伝票表示用）が一番左になるように初期設定値で挿入
                        this._userSetting.SlipColumnsList.Insert(0, new ColumnInfo("Selection", 0, false, 50, true));
                    }

                    // 選択チェックボックス（明細表示用）のユーザー設定の補完処理
                    bool SelectionCheckFlg = false;

                    foreach (ColumnInfo DetailColumnInfo in this._userSetting.DetailColumnsList)
                    {
                        if (DetailColumnInfo.ColumnName == "SelectionCheck")
                        {
                            // 選択チェックボックス（明細表示用）の設定が存在している
                            SelectionCheckFlg = true;
                            break;
                        }
                    }

                    // 選択チェックボックス（明細表示用）の設定が存在していない場合は補完を行う
                    if (SelectionCheckFlg != true)
                    {
                        // 並び順の再設定
                        for (int i = 0; i < this._userSetting.DetailColumnsList.Count; i++)
                        {
                            ColumnInfo tempDetailColumns = this._userSetting.DetailColumnsList[i];

                            // 選択チェックボックス（明細表示用）を挿入するため、並び順を1つ後ろにずらす
                            tempDetailColumns.VisiblePosition = this._userSetting.DetailColumnsList[i].VisiblePosition + 1;

                            this._userSetting.DetailColumnsList[i] = tempDetailColumns;
                        }

                        // 選択チェックボックス（明細表示用）が一番左になるように初期設定値で挿入
                        this._userSetting.DetailColumnsList.Insert(0, new ColumnInfo("SelectionCheck", 0, false, 50, true));
                    }
                    // ----------ADD 2013/01/21-----------<<<<<
                }
                catch
                {
                    this._userSetting = new SuppPtrStcUserConst();
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
            }
        }


        /// <summary>
        /// 仕入先電子元帳用ユーザー設定 設定内容分解処理
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
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
            //if (isSlip)
            //{
            //    columnList = new List<String>();//[32];
            //    string[] p = new string[18];
            //    getGridSettingPattern(sourceStr, out p, true);

            //    for (int i = 0; i < 18; i++)
            //    {
            //        columnList.Add(p[i]);
            //    }
            //}
            //else
            //{
            //    columnList = new List<String>();//[57];
            //    string[] p = new string[35];
            //    getGridSettingPattern(sourceStr, out p, true);

            //    for (int i = 0; i < 35; i++)
            //    {
            //        columnList.Add(p[i]);
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
            columnList = new List<String>();
            string[] p;
            getGridSettingPattern( sourceStr, out p, true );

            for ( int i = 0; i < p.Length; i++ )
            {
                columnList.Add( p[i] );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

            return columnList;
        }

        #endregion // ユーザー設定の保存・読み込み

        #region イベント

        /// <summary>
        /// 出力形式変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uComboEditor_OutputStyle_ValueChanged(object sender, EventArgs e)
        {
            // 選択値
            string selected = this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString();
            string fileName = this.tEdit_SettingFileName.Text.Trim();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
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
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
            fileName = SuppPtrStcUserConst.ChangeFileExtension( fileName, selected );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
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

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
            //if (val) this.tComboEditor_PetternSelect.Text = string.Empty;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
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
        private void uComboEditor_OutputType_ValueChanged(object sender, EventArgs e)
        {

            if (this.tComboEditor_OutputType.SelectedItem.DataValue.ToString() == "0") //伝票
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
        /// パターン変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_PetternSelect_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            this._selectedPattern = this.tComboEditor_PetternSelect.SelectedItem.DataValue.ToString();
            getSelectedPattern();

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
        /// <br>Update Note : 2010/07/20 chenyd</br>
        /// <br>           　テキスト出力対応</br>
        /// </remarks>
        private void uButton_OK_Click(object sender, EventArgs e)
        {
            // チェック
            if (!checkValues())
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
                this.DialogResult = DialogResult.None;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
                return;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
            //if (Int32.Parse(this.uComboEditor_OutputStyle.SelectedItem.DataValue.ToString()) == 3)
            //{
            //    renewalOutputPattern(false);
            //    this._userSetting.OutputStyle = 3;
            //}
            //else 
            //{
            //    renewalOutputPattern(false);
            //    this._userSetting.OutputStyle = Int32.Parse(this.uComboEditor_OutputStyle.SelectedItem.DataValue.ToString());
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
            renewalOutputPattern( false );
            this._userSetting.OutputStyle = Int32.Parse( this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString() );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

            // ファイル名
            this._userSetting.OutputFileName = this.tEdit_SettingFileName.Text.Trim();

            // パターン名
            this._userSetting.SelectedPatternName = this.tComboEditor_PetternSelect.Text.Trim();
            // ---------------------- ADD  2010/07/20 --------------------------------->>>>>
            this._userSetting.SuplierFileName = this.tEdit_AccpayFileName.Text;
            this._userSetting.SuplAccFileName = this.tEdit_PaymentFileName.Text;
            // ---------------------- ADD  2010/07/20 ---------------------------------<<<<<

            // シリアライズ
            this.Serialize();

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
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
            this.openFileDialog.Filter = string.Format( "{0} | {1}", "ファイル(*.*)", "*.*" );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

            // ファイル選択
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
                //this.tEdit_SettingFileName.Text = openFileDialog.FileName.ToUpper();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
                this.tEdit_SettingFileName.Text = openFileDialog.FileName;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
            }
        }

        #endregion // ボタン


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
                this.tComboEditor_PetternSelect_SelectionChangeCommitted( sender, e );
            }
            else
            {
                // 新規パターン
            }

            // 削除ボタンの有効無効制御
            uButton_PatternDelete.Enabled = (tComboEditor_PetternSelect.SelectedItem != null);
        }
        /// <summary>
        /// 設定ＵＩ初期表示イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKOU04004UA_Shown( object sender, EventArgs e )
        {
            tEdit_SettingFileName.Focus();
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
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
        // ----------ADD 2013/01/21----------->>>>>
        /// <summary>
        /// 初期化ボタン（返品計上入力グリッド）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Clear_RetGoodsAddUpInpGrid_Click(object sender, EventArgs e)
        {
            InitializeRetGoodsAddUpInpGrid(ref _userSetting);
            if (this.ClearSettinRetGoodsAddUpInpGrid != null)
            {
                this.ClearSettinRetGoodsAddUpInpGrid(this, new EventArgs());
            }
        }
        // ----------ADD 2013/01/21-----------<<<<<

        /// <summary>
        /// フォーカス移動イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note : 2010/07/20 chenyd</br>
        /// <br>           　テキスト出力対応</br>
        /// <br>Update Note: 2015/09/17 田建委</br>
        /// <br>管理番号   : 11170170-00</br>
        /// <br>           : Redmine#47006 現行保障をするため画面に区分を設ける</br>
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
                                            e.NextCtrl = tComboEditor_PetternSelect;
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
                                        e.NextCtrl = uButton_PatternDelete;
                                    }
                                    break;
                            }
                        }
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
                case "tComboEditor_OutputType": // ADD 2015/09/17 田建委 Redmine#47006
                    {
                        // 次項目を取得
                        Control nextControl = _focusControl1.GetNextControl( e.PrevCtrl, e.Key, e.ShiftKey );
                        if ( nextControl != null )
                        {
                            e.NextCtrl = nextControl;
                        }
                    }
                    break;
                //----- DEL 2015/09/17 田建委 Redmine#47006 ---------->>>>>
                //case "tComboEditor_OutputType":
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
                //                        // ---------------------- DEL 2010/07/20 --------------------------------->>>>>
                //                        // タブ切り替え
                //                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["SettingClear"];
                //                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                //                        // 次項目
                //                        e.NextCtrl = uButton_Clear_SlipGrid;
                //                        // ---------------------- DEL  2010/07/20 ---------------------------------<<<<<
                //                        // ---------------------- ADD  2010/07/20 --------------------------------->>>>>
                //                        // タブ切り替え
                //                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["BalanceOutput"];
                //                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                //                        // 次項目
                //                        e.NextCtrl = tEdit_AccpayFileName;
                //                        // ---------------------- ADD  2010/07/20 ---------------------------------<<<<<

                //                    }
                //                    break;
                //                default:
                //                    {
                //                        // 次項目を取得
                //                        Control nextControl = _focusControl1.GetNextControl( e.PrevCtrl, e.Key, e.ShiftKey );
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
                //----- DEL 2015/09/17 田建委 Redmine#47006 ----------<<<<<
                //----- ADD 2015/09/17 田建委 Redmine#47006 ---------->>>>>
                case "uCheckEditor_RetSlipMinus_Saleslip": // 返品伝票金額をマイナスで出力の区分
                case "uCheckEditor_RetSlipMinus_Meisai": 
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
                                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["BalanceOutput"];
                                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        // 次項目
                                        e.NextCtrl = tEdit_AccpayFileName;

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
                // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
                #region [残高出力]
                case "tEdit_AccpayFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_AccpayFileName.Text))
                                        {
                                            // 次項目
                                            e.NextCtrl = tEdit_PaymentFileName;
                                        }
                                        else
                                        {
                                            // ガイドボタン
                                            e.NextCtrl = uButton_AccpayFileName;
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
                                            //e.NextCtrl = tComboEditor_OutputType; // DEL 2015/09/17 田建委 Redmine#47006
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

                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "tEdit_PaymentFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_PaymentFileName.Text))
                                        {
                                            // 次項目
                                            uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["SettingClear"];
                                            uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                            e.NextCtrl = uButton_Clear_SlipGrid;
                                        }
                                        else
                                        {
                                            // ガイドボタン
                                            e.NextCtrl = uButton_PaymentFileName;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                case "uButton_PaymentFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // 次項目
                                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["SettingClear"];
                                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        e.NextCtrl = uButton_Clear_SlipGrid;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                #endregion
                // ---------------------- ADD 2010/07/20 ---------------------------------<<<<<
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
                                        // ---------------------- DEL 2010/07/20 --------------------------------->>>>>
                                        // タブ切り替え
                                        //uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["TextOutput"];
                                        //uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        // 次項目
                                        //e.NextCtrl = tComboEditor_OutputType;
                                        // ---------------------- DEL  2010/07/20 --------------------------------->>>>>
                                        // ---------------------- ADD  2010/07/20 --------------------------------->>>>>
                                        // タブ切り替え
                                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["BalanceOutput"];
                                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        // 次項目
                                        e.NextCtrl = uButton_PaymentFileName;
                                        // ---------------------- ADD  2010/07/20 ---------------------------------<<<<<
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
                case "uButton_Clear_BalanceGrid":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = uButton_OK;
                                    }
                                    break;
                                case Keys.Return:
                                    {
                                        uButton_Clear_BalanceGrid_Click( this, new EventArgs() );
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                # endregion
                    
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
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

        // 2010/04/05 Add >>>
        /// <summary>
        /// テキスト出力オプションの有効、無効で設定のテキスト出力タブの表示制御
        /// </summary>
        /// <param name="display">display</param>
        /// <remarks>
        /// <br>Note       : テキスト出力オプションの有効、無効で設定のテキスト出力タブの表示制御を行う。</br>
        /// <br>Programmer : 30517 夏野 駿希</br>
        /// <br>Date       : 2010/04/05</br>
        /// <br>Update Note : 2010/07/20 chenyd</br>
        /// <br>           　テキスト出力対応</br>
        /// </remarks>
        public void uTabControlSet(bool display)
        {
            //テキスト出力オプションの有効、無効で設定のテキスト出力タブの表示制御を行う。
            uTabControl_Setting.Tabs["TextOutput"].Visible = display;
            if (display)
            {
                this._opt_TextOutput = (int)Option.ON;
            }
            else
            {
                this._opt_TextOutput = (int)Option.OFF;
            }

            uTabControl_Setting.Tabs["BalanceOutput"].Visible = display;  // ADD 2010/07/20 
        }
        // 2010/04/05 Add <<<

        // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
        /// <summary>
        /// ファイル名（支払）ガイドボタンClick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ファイル名（支払）ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void uButton_AccpayFileName_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tEdit_AccpayFileName.Text))
            {
                this.openFileDialog.FileName = this.tEdit_AccpayFileName.Text.Trim();
            }
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;
            this.openFileDialog.Filter = string.Format("{0} | {1}", "ファイル(*.*)", "*.*");

            // ファイル選択
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tEdit_AccpayFileName.Text = openFileDialog.FileName.ToUpper();
            }

        }

        /// <summary>
        /// ファイル名（買掛）ガイドボタンClick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ファイル名（買掛）ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void uButton_PaymentFileName_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tEdit_PaymentFileName.Text))
            {
                this.openFileDialog.FileName = this.tEdit_PaymentFileName.Text.Trim();
            }
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;
            this.openFileDialog.Filter = string.Format("{0} | {1}", "ファイル(*.*)", "*.*");

            // ファイル選択
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tEdit_PaymentFileName.Text = openFileDialog.FileName.ToUpper();
            }
        }
    }
    // ---------------------- ADD 2010/07/20 ---------------------------------<<<<<

    /// <summary>
    /// 仕入先電子元帳用ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先電子元帳のユーザー設定情報を管理するクラス</br>
    /// <br>Programmer : </br>
    /// <br>Date       : </br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class SuppPtrStcUserConst
    {

        # region プライベート変数

        // 出力ファイル名
        private string _outputFileName;

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

        /// <summary>項目区切り文字</summary>
        private const string STRING_DIVIDER = "/";

        //private const int[] DEFAULT_VAL_SLIP = { 0, 0, 0, 2, 3, 0, 0, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 0, 27, 28, 29, 30, 31, 0, 32, 33 };

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
        // 有効な詳細条件リスト
        private List<string> _enabledConditionList;

        // 伝票グリッドカラムリスト
        private List<ColumnInfo> _slipColumnsList;
        // 明細グリッドカラムリスト
        private List<ColumnInfo> _detailColumnsList;
        // 残高グリッドカラムリスト
        private List<ColumnInfo> _balanceColumnsList;
        // ----------ADD 2013/01/21----------->>>>>
        // 返品計上入力グリッドカラムリスト
        private List<ColumnInfo> _retGoodsAddUpInpColumnsList;
        // ----------ADD 2013/01/21-----------<<<<<

        // 詳細条件グループ展開状態
        private bool _extraConditionExpanded;
        // 合計表示グループ展開状態
        private bool _balanceChartExpanded;

        // 伝票グリッド自動サイズ調整
        private bool _autoAdjustSlip;
        // 明細グリッド自動サイズ調整
        private bool _autoAdjustDetail;
        // 残高グリッド自動サイズ調整
        private bool _autoAdjustBalance;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

        // 返品計上入力グリッド自動サイズ調整
        private bool _autoAdjustRetGoodsAddUpInp; // ADD  2013/01/21

        // 出力ファイル名（支払）
        private string _suplierFileName;  // ADD 2010/07/20 

        // 出力ファイル名（買掛）
        private string _suplAccFileName;  // ADD 2010/07/20

        # endregion // プライベート変数

        # region コンストラクタ

        /// <summary>
        /// 仕入先電子元帳ユーザー設定情報クラス
        /// </summary>
        public SuppPtrStcUserConst()
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

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
        /// <summary>有効な詳細条件リスト</summary>
        public List<string> EnabledConditionList
        {
            get { return this._enabledConditionList; }
            set { this._enabledConditionList = value; }
        }
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
        public List<ColumnInfo> BalanceColumnsList
        {
            get { return this._balanceColumnsList; }
            set { this._balanceColumnsList = value; }
        }
        // ----------ADD 2013/01/21----------->>>>>
        /// <summary>返品計上入力グリッドカラムリスト</summary>
        public List<ColumnInfo> RetGoodsAddUpInpColumnsList
        {
            get { return this._retGoodsAddUpInpColumnsList; }
            set { this._retGoodsAddUpInpColumnsList = value; }
        }
        // ----------ADD 2013/01/21-----------<<<<<
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
        /// <summary>残高グリッド自動サイズ調整</summary>
        public bool AutoAdjustBalance
        {
            get { return _autoAdjustBalance; }
            set { _autoAdjustBalance = value; }
        }

        // ----------ADD 2013/01/21----------->>>>>
        /// <summary>返品計上入力グリッド自動サイズ調整</summary>
        public bool AutoAdjustRetGoodsAddUpInp
        {
            get { return _autoAdjustRetGoodsAddUpInp; }
            set { _autoAdjustRetGoodsAddUpInp = value; }
        }
        // ----------ADD 2013/01/21-----------<<<<<
        
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
        // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
        // 出力ファイル名（支払）
        public string SuplierFileName
        {
            get { return this._suplierFileName; }
            set { this._suplierFileName = value; }
        }

        // 出力ファイル名（買掛）
        public string SuplAccFileName
        {
            get { return this._suplAccFileName; }
            set { this._suplAccFileName = value; }
        }
        // ---------------------- ADD 2010/07/20 ---------------------------------<<<<<
        # endregion

        /// <summary>
        /// 仕入先電子元帳ユーザー設定情報クラス複製処理
        /// </summary>
        /// <returns>仕入先電子元帳ユーザー設定情報クラス</returns>
        public SuppPtrStcUserConst Clone()
        {
            SuppPtrStcUserConst constObj = new SuppPtrStcUserConst();
            return constObj;
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
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
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
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
    # endregion

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
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
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