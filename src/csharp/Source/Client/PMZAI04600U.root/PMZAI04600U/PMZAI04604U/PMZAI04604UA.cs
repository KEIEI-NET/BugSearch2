//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 在庫移動電子元帳
// プログラム概要   : 在庫移動電子元帳 動作設定ＵＩクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/04/06  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : tianjw
// 作 成 日  2011/05/11  修正内容 : redmine #20955,#29951
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/05/25  修正内容 : redmine #21703、#21718
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/05/26  修正内容 : redmine #21752
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/05/27  修正内容 : redmine #21703，#21794
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
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 在庫移動電子元帳 動作設定ＵＩクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫移動電子元帳 動作設定ＵＩクラスです。</br>
    /// <br>Programmer : 高峰</br>
    /// <br>Date       : 2011/04/06</br>
    /// <br>Update Note: 2011/05/11 tianjw</br>
    /// <br>             redmine #20955,#29951</br>
    /// <br></br>
    /// </remarks>
    public partial class PMZAI04604UA : Form
    {
        /// <summary>
        /// 設定ファイル上の列番号は3桁ゼロ詰め
        /// </summary>
        static public readonly int ct_ColumnCountLength = 3;
        # region const
        // パターン削除確認メッセージ
        private const string MSG_CONFIRM_DELETE_PATTERN = "選択中の出力パターンを削除してよろしいですか？";

        // パターン未入力メッセージ
        private const string MSG_OUTPUTTEXT_NOPATTERN = "出力パターンを入力して下さい";


        # endregion

        # region event
        /// <summary>伝票グリッド設定初期化</summary>
        public event EventHandler ClearSettingStockMoveGrid;

        # endregion

        #region プライベート変数

        // 設定保存用共通オブジェクト

        /// <summary>設定XMLファイル名</summary>
        private const string XML_FILE_NAME = "PMZAI04600U_Construction.XML";

        // データセット
        private StockMoveDetailDataSet _stockMoveDataSet;
        private int prevDividerChar;
        private int prevParenthesis;
        private int prevTieNumeric;
        private int prevTieChar;
        private int prevTitleLine;

        // ユーザー設定
        private StockMoveUserConst _userSetting;

        // 区切り文字
        private string _divider;

        // パターン
        private string[] _outputPattern;

        // 選択されているパターン名
        private string _selectedPattern;

        // 伝票グリッドの設定
        private string _gridSetting_Slip = string.Empty;

        // 伝票項目indexディクショナリ
        private Dictionary<string, int> _columnIndexDicOfSlip;
        // 伝票グリッドカラム・コレクション
        private Infragistics.Win.UltraWinGrid.ColumnsCollection _slipColCollection;
        // フォーカス制御
        private FocusControl _focusControl1;
        // グリッド・カラムチューザー制御
        GridColumnChooserControl _gridColumnChooserControl;

        private bool _dividerCharClearFlg = true; // ADD 2011/05/25
        private bool _parenthesisClearFlg = true; // ADD 2011/05/25

        #endregion // プライベート変数

        #region プロパティ

        /// <summary>
        /// 在庫移動電子元帳ユーザー設定情報クラス複製処理
        /// </summary>
        /// <returns>在庫移動電子元帳ユーザー設定情報クラス</returns>
        public StockMoveUserConst UserSetting
        {
            get { return this._userSetting; }
        }

        /// <summary>
        /// 伝票グリッドカラム・コレクション 
        /// </summary>
        public Infragistics.Win.UltraWinGrid.ColumnsCollection SlipColCollection
        {
            get { return _slipColCollection; }
            set { _slipColCollection = value; }
        }

        /// <summary>
        /// 区切り文字
        /// </summary>
        private int DividerChar
        {
            get
            {
                if (rb_DividerChar_0.Checked)
                {
                    return 0;
                }
                else if (rb_DividerChar_1.Checked)
                {
                    return 1;
                }
                else if (rb_DividerChar_2.Checked)
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
                switch (value)
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
                if (rb_Parenthesis_0.Checked)
                {
                    return 0;
                }
                else if (rb_Parenthesis_1.Checked)
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
                switch (value)
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
                if (rb_TieNumeric_0.Checked)
                {
                    return 0;
                }
                else if (rb_TieNumeric_1.Checked)
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
                switch (value)
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
                if (rb_TieChar_0.Checked)
                {
                    return 0;
                }
                else if (rb_TieChar_1.Checked)
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
                switch (value)
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
                if (rb_TitleLine_0.Checked)
                {
                    return 0;
                }
                else if (rb_TitleLine_1.Checked)
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
                switch (value)
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

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : コンストラクタです。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        public PMZAI04604UA()
        {
            InitializeComponent();

            this._stockMoveDataSet = new StockMoveDetailDataSet();

            // 伝票項目index
            _columnIndexDicOfSlip = new Dictionary<string, int>();
            for (int index = 0; index < _stockMoveDataSet.StockMoveDetail.Columns.Count; index++)
            {
                _columnIndexDicOfSlip.Add(_stockMoveDataSet.StockMoveDetail.Columns[index].ColumnName, index);
            }

            this._userSetting = new StockMoveUserConst();

            // フォーカス制御(テキスト出力設定タブ)
            _focusControl1 = new FocusControl();
            _focusControl1.AddLine(tComboEditor_OutputStyle);
            _focusControl1.AddLine(rb_DividerChar_0, rb_DividerChar_1, tEdit_DividerChar, rb_DividerChar_2);
            _focusControl1.AddLine(rb_Parenthesis_0, rb_Parenthesis_1, tEdit_ParenthesisChar);
            _focusControl1.AddLine(rb_TieNumeric_0, rb_TieNumeric_1);
            _focusControl1.AddLine(rb_TieChar_0, rb_TieChar_1);
            _focusControl1.AddLine(rb_TitleLine_0, rb_TitleLine_1);

            _gridColumnChooserControl = new GridColumnChooserControl();
            _gridColumnChooserControl.Add(uGrid_ColumnItemSelector);

        }
        /// <summary>
        /// 伝票項目index取得処理
        /// </summary>
        /// <param name="patterns"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 伝票項目index取得処理。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private int GetColumnPositionOfSlip(string[] patterns, string columnName)
        {
            if (_columnIndexDicOfSlip.ContainsKey(columnName))
            {
                try
                {
                    return Int32.Parse(patterns[_columnIndexDicOfSlip[columnName]].ToString());
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
        /// 画面起動時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 画面起動時処理。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void PMZAI04604UA_Load(object sender, EventArgs e)
        {

            // グリッド毎に使用するデータビューを作成
            DataView dViewStockMove = new DataView(this._stockMoveDataSet.StockMoveDetail);


            // データソースとしてデータビューを指定
            this.uGrid_ColumnItemSelector.DataSource = dViewStockMove;

            // 設定値があればロード
            this._userSetting = new StockMoveUserConst();
            InitializeUserSetting(ref _userSetting);
            this.Deserialize();

            // パターン・区切り文字・設定名を取得
            if (this._userSetting != null)
            {
                this._outputPattern = this._userSetting.OutputPattern;
                this._divider = this._userSetting.DIVIDER;
                this._selectedPattern = this._userSetting.SelectedPatternName;
            }

            // カラム
            InitializeGridColumns(this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns);

            // ボタン設定
            this.uButton_FileSelect.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
            this.uButton_FileSelect.Appearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;

            // 基本パターン名作成
            if (_userSetting == null ||
                _userSetting.OutputPattern == null ||
                _userSetting.OutputPattern.Length == 0)
            {
                string tempName = string.Empty;
                createPatternStringNonCustom(0, out tempName, true);
                createPatternStringNonCustom(1, out tempName, true);
                createPatternStringNonCustom(2, out tempName, true);
            }

            // 画面の初期値をセット
            setInitialValue();

            // 画面の初期設定
            this.tComboEditor_OutputStyle_ValueChanged(null, null);

            tEdit_SettingFileName.Text = _userSetting.OutputFileName;
            //表示更新

            // 区切り文字任意
            if (prevDividerChar == 1)
            {
                this.tEdit_DividerChar.Enabled = true;
            }
            else
            {
                this.tEdit_DividerChar.Enabled = false;
                this.tEdit_DividerChar.Clear();
            }
            // 括り文字任意
            if (prevParenthesis == 1)
            {
                this.tEdit_ParenthesisChar.Enabled = true;
            }
            else
            {
                this.tEdit_ParenthesisChar.Enabled = false;
                this.tEdit_ParenthesisChar.Clear();
            }
        }

        /// <summary>
        /// ユーザー設定初期化処理
        /// </summary>
        /// <param name="userSetting"></param>
        /// <remarks>
        /// <br>Note       : ユーザー設定初期化処理。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void InitializeUserSetting(ref StockMoveUserConst userSetting)
        {
            userSetting = new StockMoveUserConst();
            InitializeStockMoveGrid(ref userSetting);
        }
        /// <summary>
        /// ユーザー設定初期化（伝票表示）
        /// </summary>
        /// <param name="userSetting"></param>
        /// <remarks>
        /// <br>Note       : ユーザー設定初期化（伝票表示）。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void InitializeStockMoveGrid(ref StockMoveUserConst userSetting)
        {
            userSetting.StockMoveColumnsList = new List<ColumnInfo>();
            userSetting.AutoAdjustStockMove = false;
        }

        #endregion // コンストラクタ

        #region プライベート関数

        /// <summary>
        /// 画面の初期値を設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期値を設定。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void setInitialValue()
        {
            // 設定値があればそれを設置
            if (this._outputPattern == null)
            {
                this.tEdit_DividerChar.Clear();
                this.tEdit_ParenthesisChar.Clear();
                this.tEdit_SettingFileName.Clear();
                this.tComboEditor_PetternSelect.Text = string.Empty;

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
                this.tComboEditor_PetternSelect.Items.Clear();

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

                // ＵＩ表示
                SetDisplayFromPattern(patternValue);
            }
        }

        /// <summary>
        /// パターンの内容を分解
        /// </summary>
        /// <param name="pBody"></param>
        /// <param name="pValue"></param>
        /// <remarks>
        /// <br>Note       : パターンの内容を分解。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void getPatternValue(string pBody, out string[] pValue)
        {
            const int ct_ItemCount = 10;
            pValue = new string[ct_ItemCount];

            string str1 = pBody;
            string str2 = string.Empty;

            for (int i = 0; i < ct_ItemCount; i++)
            {
                if (str1.Contains(this._divider))
                {
                    pValue[i] = str1.Substring(0, str1.IndexOf(this._divider));
                }
                else
                {
                    pValue[i] = str1.Substring(0);
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
        /// <remarks>
        /// <br>Note       : グリッドのセッティングを文字列から取り出す。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void getGridSettingPattern(string patternStr, out string[] gridSetting, bool isSlip)
        {
            int count = patternStr.Length / (ct_ColumnCountLength + 1);
            gridSetting = new string[count];

            for (int i = 0; i < count; i++)
            {
                gridSetting[i] = patternStr.Substring(i * (ct_ColumnCountLength + 1), (ct_ColumnCountLength + 1));
            }
        }

        /// <summary>
        /// 選択されたパターンを適用
        /// </summary>
        /// <remarks>
        /// <br>Note       : 選択されたパターンを適用。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
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

            // パターン名
            this.tComboEditor_PetternSelect.Text = this._selectedPattern;

            // ＵＩ表示
            SetDisplayFromPattern(patternValue);
        }

        /// <summary>
        /// SetDisplayFromPattern
        /// </summary>
        /// <param name="patternValue"></param>
        /// <remarks>
        /// <br>Note       : SetDisplayFromPattern。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void SetDisplayFromPattern(string[] patternValue)
        {
            try
            {
                // 出力形式
                this.tComboEditor_OutputStyle.SelectedIndex = Int32.Parse(patternValue[8].ToString());

                // 区切り文字
                this.DividerChar = Int32.Parse(patternValue[0].ToString());
                prevDividerChar = this.DividerChar;
                // 区切り文字任意
                this.tEdit_DividerChar.Text = patternValue[1].ToString();
                if (prevDividerChar == 1)
                {
                    this.tEdit_DividerChar.Enabled = true;
                }
                else
                {
                    this.tEdit_DividerChar.Enabled = false;
                    this.tEdit_DividerChar.Clear();
                }

                // 括り文字
                this.Parenthesis = Int32.Parse(patternValue[2].ToString());
                prevParenthesis = this.Parenthesis;
                // 括り文字任意
                this.tEdit_ParenthesisChar.Text = patternValue[3].ToString();
                if (prevParenthesis == 1)
                {
                    this.tEdit_ParenthesisChar.Enabled = true;
                }
                else
                {
                    this.tEdit_ParenthesisChar.Enabled = false;
                    this.tEdit_ParenthesisChar.Clear();
                }

                // 数値括り
                this.TieNumeric = Int32.Parse(patternValue[4].ToString());
                prevTieNumeric = this.TieNumeric;
                // 文字括り
                this.TieChar = Int32.Parse(patternValue[5].ToString());
                prevTieChar = this.TieChar;

                // タイトル行
                this.TitleLine = Int32.Parse(patternValue[6].ToString());
                prevTitleLine = this.TitleLine;

                // グリッド
                this._gridSetting_Slip = patternValue[7].ToString();

                // カラム設定
                InitializeGridColumns(this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns);
            }
            catch
            {
            }

        }

        /// <summary>
        /// データグリッドセット
        /// </summary>
        /// <param name="Columns"></param>
        /// <remarks>
        /// <br>Note       : データグリッドセット。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void InitializeGridColumns(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns)
        {
            // 表示位置初期値
            int visiblePosition = 1;

            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //非表示設定
                column.Hidden = true;
                column.ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;

                column.AutoEdit = false;
                column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }

            string[] gridPattern = new string[0];
            if (!string.IsNullOrEmpty(_gridSetting_Slip))
            {
                getGridSettingPattern(this._gridSetting_Slip, out gridPattern, true);
            }

            int position = 0;


            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn orgCol in _slipColCollection)
            {
                // 選択用のチェックボックスは除外
                if (orgCol.Key == _stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName) continue;

                // カラムチューザから除外されている項目は内部制御用とみなして除外
                if (orgCol.ExcludeFromColumnChooser == Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True) continue;

                // 元カラムからコピー
                Columns[orgCol.Key].CellAppearance.TextHAlign = orgCol.CellAppearance.TextHAlign;
                Columns[orgCol.Key].Header.Caption = orgCol.Header.Caption;
                Columns[orgCol.Key].Header.Appearance.TextHAlign = orgCol.Header.Appearance.TextHAlign;
                // 値セット
                Columns[orgCol.Key].Hidden = false;
                Columns[orgCol.Key].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                Columns[orgCol.Key].Header.VisiblePosition = visiblePosition++;

                if (!string.IsNullOrEmpty(_gridSetting_Slip))
                {
                    int hiddenFlag = (int)Math.Pow(10, ct_ColumnCountLength);

                    // 設定あり
                    position = GetColumnPositionOfSlip(gridPattern, orgCol.Key);
                    if (position >= hiddenFlag)
                    {
                        Columns[orgCol.Key].Hidden = true;
                        Columns[orgCol.Key].Header.VisiblePosition = position - hiddenFlag;
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
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor = this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackColor;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor2 = this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackColor2;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.BackGradientStyle = this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle;
            this.uGrid_ColumnItemSelector.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;

            #endregion // カラムチューザ設定

            // 列幅自動調整を設定値にしたがって行う
            autoColumnAdjust(false);

            // 外観設定
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;


        }

        /// <summary>
        /// 列幅自動調整
        /// </summary>
        /// <param name="autoAdjust">自動調整するかどうか</param>
        /// <remarks>
        /// <br>Note       : 列幅自動調整。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void autoColumnAdjust(bool autoAdjust)
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
            	if (this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns[i].Hidden) continue;
                this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
            }
        }

        /// <summary>
        /// 入力値チェック
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 入力値チェック。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private bool checkValues()
        {
            // パターン名
            if (String.IsNullOrEmpty(this.tComboEditor_PetternSelect.Text.Trim()))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, MSG_OUTPUTTEXT_NOPATTERN, -1, MessageBoxButtons.OK);
                this.tComboEditor_PetternSelect.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// パターンを更新
        /// </summary>
        /// <remarks>
        /// <br>Note       : パターンを更新。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br>Update Note: Redmine #21794</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/05/27</br>
        /// <br></br>
        /// </remarks>
        private void renewalOutputPattern(bool isDelete)
        {
            if (!isDelete)
            {
                // 名前
                string selectedPatternName = this.tComboEditor_PetternSelect.Text.Trim();
                string value01 = this.DividerChar.ToString();
                //string value02 = this.tEdit_DividerChar.Text.Trim(); // DEL 2011/05/27
                string value02 = this.tEdit_DividerChar.Text;// ADD 2011/05/27
                string value03 = this.Parenthesis.ToString();
                //string value04 = this.tEdit_ParenthesisChar.Text.Trim();// DEL 2011/05/27
                string value04 = this.tEdit_ParenthesisChar.Text;// ADD 2011/05/27
                string value05 = this.TieNumeric.ToString();
                string value06 = this.TieChar.ToString();
                string value07 = this.TitleLine.ToString();

                // グリッドから設定値を取得
                string value08 = string.Empty;
                createGridPatternString(out value08);
                string value09 = this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString();

                // 全て連結
                string convinedStr = selectedPatternName + this._divider +
                        value01 + this._divider + value02 + this._divider +
                        value03 + this._divider + value04 + this._divider +
                        value05 + this._divider + value06 + this._divider +
                        value07 + this._divider + value08 + this._divider +
                        value09 + this._divider;
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
                            if (pName == selectedPatternName)
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
        /// <param name="patternString"></param>
        /// <remarks>
        /// <br>Note       : グリッドの設定を文字列に変換。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void createGridPatternString(out string patternString)
        {
            patternString = string.Empty;

            Infragistics.Win.UltraWinGrid.ColumnsCollection col = this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns;
            string[] gridHeaderPattern = new string[col.Count];
            int visiblePosition = 0;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in col)
            {
                if (_columnIndexDicOfSlip.ContainsKey(column.Key))
                {
                    if (column.Hidden)
                    {
                        gridHeaderPattern[_columnIndexDicOfSlip[column.Key]] = "1" + visiblePosition.ToString().PadLeft(ct_ColumnCountLength, '0');
                    }
                    else
                    {
                        gridHeaderPattern[_columnIndexDicOfSlip[column.Key]] = "0" + visiblePosition.ToString().PadLeft(ct_ColumnCountLength, '0');
                    }
                    visiblePosition++;
                }
            }

            // 列の順に並ぶように文字列を作成（順番が異なると正常に修正できない）
            for (int i = 0; i < col.Count; i++)
            {
                patternString = patternString + gridHeaderPattern[i];
            }
        }

        /// <summary>
        /// 基本パターンを追加
        /// </summary>
        /// <param name="outputStyle"></param>
        /// <param name="patternString"></param>
        /// <param name="addPattern"></param>
        /// <remarks>
        /// <br>Note       : 基本パターンを追加。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
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
                        value07 = "0";

                        value08 = string.Empty;

                        value09 = "0";

                        value10 = "1";

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
                        value07 = "0";

                        value08 = string.Empty;

                        value09 = "1";

                        value10 = "1";

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

                        value07 = "0";

                        value08 = string.Empty;

                        value09 = "2";

                        value10 = "1";

                        break;
                    }

                default: break;
            }
            patternString = selectedPatternName + this._divider +
                value01 + this._divider + value02 + this._divider +
                value03 + this._divider + value04 + this._divider +
                value05 + this._divider + value06 + this._divider +
                value07 + this._divider + value08 + this._divider +

                value09 + this._divider + value10;

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
        /// 在庫移動電子元帳用ユーザー設定シリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫移動電子元帳用ユーザー設定シリアライズ処理。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        public void Serialize()
        {
            try
            {
                UserSettingController.SerializeUserSetting(_userSetting, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }

            if (DataChanged != null)
            {
                // データ変更後発生イベント実行
                DataChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// 在庫移動電子元帳用ユーザー設定デシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫移動電子元帳用ユーザー設定デシリアライズ処理。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
            {
                try
                {
                    this._userSetting = UserSettingController.DeserializeUserSetting<StockMoveUserConst>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
                }
                catch
                {
                    this._userSetting = new StockMoveUserConst();
                }
            }
        }


        /// <summary>
        /// 在庫移動電子元帳用ユーザー設定 設定内容分解処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫移動電子元帳用ユーザー設定 設定内容分解処理。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
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
            // 出力項目リスト (xx項目x3文字) 基本的に表示順の数字,非表示の場合は+100, 必ずExportColumnDataSet.StockMoveDetailの順に並んでいる 7

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
        /// <remarks>
        /// <br>Note       : カラム名のリスト取得。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        public List<String> GetColumnNameList(string sourceStr, bool isSlip)
        {
            List<String> columnList;
            columnList = new List<String>();
            string[] p;
            getGridSettingPattern(sourceStr, out p, true);

            for (int i = 0; i < p.Length; i++)
            {
                columnList.Add(p[i]);
            }

            return columnList;
        }

        #endregion // ユーザー設定の保存・読み込み

        #region イベント

        /// <summary>
        /// 出力形式変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 出力形式変更。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br>Update Note: Redmint #21703を対応</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/05/25</br>
        /// <br>Update Note: Redmint #21703を対応</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/05/27</br>
        /// <br></br>
        /// </remarks>
        private void tComboEditor_OutputStyle_ValueChanged(object sender, EventArgs e)
        {
            // 選択値
            string selected = this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString();
            string fileName = this.tEdit_SettingFileName.Text.Trim();

            fileName = StockMoveUserConst.ChangeFileExtension(fileName, selected);

            this.tEdit_SettingFileName.Text = fileName;

            // カスタムのときのみ有効
            bool val = (this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString() == "3");

            // 項目を調整
            this.pn_DividerChar.Enabled = val;
            this.pn_Parenthesis.Enabled = val;
            this.pn_TieChar.Enabled = val;
            this.pn_TieNumeric.Enabled = val;
            this.pn_TitleLine.Enabled = val;

            this.tEdit_DividerChar.Enabled = val;
            this.tEdit_ParenthesisChar.Enabled = val;

            // 区切り文字任意
            if (prevDividerChar == 1)
            {
                this.tEdit_DividerChar.Enabled = true;
            }
            else
            {
                this.tEdit_DividerChar.Enabled = false;
                this.tEdit_DividerChar.Clear();
            }
            // 括り文字任意
            if (prevParenthesis == 1)
            {
                this.tEdit_ParenthesisChar.Enabled = true;
            }
            else
            {
                this.tEdit_ParenthesisChar.Enabled = false;
                this.tEdit_ParenthesisChar.Clear();
            }

            // --- ADD 2011/05/25 ---------->>>>>
            switch (this.tComboEditor_OutputStyle.SelectedIndex)
            {
                case 0:
                    {
                        this.rb_DividerChar_1.Checked = true;
                        this.tEdit_DividerChar.Text = ",";
                        this.rb_Parenthesis_0.Checked = true;
                        this.rb_TieNumeric_0.Checked = true;
                        this.rb_TieChar_0.Checked = true;
                        this.rb_TitleLine_0.Checked = true;
                        this.ultraGroupBox1.Enabled = false;
                        break;
                    }
                case 1:
                    {
                        this.rb_DividerChar_0.Checked = true;
                        this.tEdit_DividerChar.Clear();
                        this.rb_Parenthesis_0.Checked = true;
                        this.rb_TieNumeric_0.Checked = true;
                        this.rb_TieChar_0.Checked = true;
                        this.rb_TitleLine_0.Checked = true;
                        this.ultraGroupBox1.Enabled = false;
                        break;
                    }
                case 2:
                    {
                        //this.rb_DividerChar_1.Checked = true; // DEL 2011/05/27
                        this.rb_DividerChar_2.Checked = true; // ADD 2011/05/27
                        this.tEdit_DividerChar.Text = " ";
                        this.rb_Parenthesis_0.Checked = true;
                        this.rb_TieNumeric_0.Checked = true;
                        this.rb_TieChar_0.Checked = true;
                        this.rb_TitleLine_0.Checked = true;
                        this.ultraGroupBox1.Enabled = false;
                        break;
                    }
                case 3:
                    {
                        this.ultraGroupBox1.Enabled = true;
                        this.tEdit_DividerChar.Enabled = this.rb_DividerChar_1.Checked;
                        this.tEdit_ParenthesisChar.Enabled = rb_Parenthesis_1.Checked;
                        break;
                    }
                default:
                    break;
            }
            // --- ADD 2011/05/25 ----------<<<<<

        }

        /// <summary>
        /// パターン変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : パターン変更。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uComboEditor_PetternSelect_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            if (tComboEditor_PetternSelect.SelectedItem != null)
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
        /// <remarks>
        /// <br>Note       : キャンセルボタン。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        /// <summary>
        /// OKボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : OKボタン。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uButton_OK_Click(object sender, EventArgs e)
        {
            // チェック
            if (!checkValues())
            {
                return;
            }

            if (Int32.Parse(this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString()) == 3)
            {
                renewalOutputPattern(false);
                this._userSetting.OutputStyle = 3;
            }
            else
            {
                renewalOutputPattern(false);
                this._userSetting.OutputStyle = Int32.Parse(this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString());
            }
            renewalOutputPattern(false);
            this._userSetting.OutputStyle = Int32.Parse(this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString());

            // ファイル名
            this._userSetting.OutputFileName = this.tEdit_SettingFileName.Text.Trim();

            // パターン名
            this._userSetting.SelectedPatternName = this.tComboEditor_PetternSelect.Text.Trim();

            // シリアライズ
            this.Serialize();

            this.DialogResult = DialogResult.OK;

            // 終了
            this.Close();
        }

        /// <summary>
        /// ファイルダイアログ表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ファイルダイアログ表示。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
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

        #region プライベート関数
        /// <summary>
        /// テキスト出力パターン削除ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : テキスト出力パターン削除ボタン押下処理。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uButton_PaternDelete_Click(object sender, EventArgs e)
        {
            if (this.tComboEditor_PetternSelect.SelectedItem == null) return;

            // 現在選択されているパターンを削除対象とする
            string deletePattern = this.tComboEditor_PetternSelect.SelectedItem.DataValue.ToString();

            // 確認ダイアログ
            if (TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_QUESTION, this.Name,
                MSG_CONFIRM_DELETE_PATTERN + Environment.NewLine + Environment.NewLine + string.Format("出力パターン：{0}", deletePattern),
                -1, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            // 削除
            # region [削除]
            // 現在のパターン一覧をリストに格納する
            List<string> patternList = new List<string>(_outputPattern);
            string pName = string.Empty;

            // 合致するパターン情報を削除
            foreach (string pattern in this._outputPattern)
            {
                // 最初の区切り文字までがパターン名
                if (pattern.Contains(this._divider))
                {
                    pName = pattern.Substring(0, pattern.IndexOf(this._divider));

                    // 設定されているパターンの場合は内容を取得
                    if (pName == deletePattern)
                    {
                        patternList.Remove(pattern);
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
                }
            }
            // 最初のパターンを選択する
            if (tComboEditor_PetternSelect.Items.Count > 0)
            {
                tComboEditor_PetternSelect.SelectedIndex = 0;
            }
            else
            {
                tComboEditor_PetternSelect.Text = string.Empty;
            }
            # endregion

        }
        /// <summary>
        /// パターンテキスト変更時イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : パターンテキスト変更時イベント処理。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void tComboEditor_PetternSelect_ValueChanged(object sender, EventArgs e)
        {
            if (tComboEditor_PetternSelect.SelectedItem != null)
            {
                // 既存のパターン
                this.uComboEditor_PetternSelect_SelectionChangeCommitted(sender, e);
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
        /// <remarks>
        /// <br>Note       : 設定ＵＩ初期表示イベント処理。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br>Update Note: 2011/05/11 tianjw</br>
        /// <br>             redmine #20955</br>
        /// <br></br>
        /// </remarks>
        private void PMZAI04604UA_Shown(object sender, EventArgs e)
        {
            if (uTabControl_Setting.Tabs["TextOutput"].Visible)
            {
                tEdit_SettingFileName.Focus();

                // ----- ADD 2011/05/11 tianjw ------------------------->>>>>
                if (!string.IsNullOrEmpty(tComboEditor_PetternSelect.Text))
                {
                    uButton_PaternDelete.Enabled = true;
                }
                // ----- ADD 2011/05/11 tianjw -------------------------<<<<<
            } 
            else 
            {
                uButton_Clear_StockMoveGrid.Focus();
            }
        }
        /// <summary>
        /// 初期化ボタン（在庫移動グリッド）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 初期化ボタン（在庫移動グリッド）。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uButton_Clear_StockMoveGrid_Click(object sender, EventArgs e)
        {
            InitializeStockMoveGrid(ref _userSetting);
            if (this.ClearSettingStockMoveGrid != null)
            {
                this.ClearSettingStockMoveGrid(this, new EventArgs());
            }
        }

        /// <summary>
        /// フォーカス移動イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : フォーカス移動イベント処理。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br>Update Note: 2011/05/11 tianjw</br>
        /// <br>             redmine #20951</br>
        /// <br>Update Note: Redmine #21703、#21718</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/05/25</br>
        /// <br>Update Note: Redmine #21752</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/05/26</br>
        /// <br></br>
        /// </remarks>
        private void tArrowKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                # region [テキスト出力]
                case "tEdit_SettingFileName":
                    {
                        # region [次フォーカス]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_SettingFileName.Text))
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
                            switch (e.Key)
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
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
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
                        # endregion
                    }
                    break;

                //case "tComboEditor_OutputStyle":
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
                //case "rb_TitleLine_1": // DEL 2011/05/11 tianjw
                case "rb_TitleLine_1": // ADD 2011/05/25
                    {
                        // 次項目を取得
                        Control nextControl = _focusControl1.GetNextControl(e.PrevCtrl, e.Key, e.ShiftKey);
                        if (nextControl != null)
                        {
                            e.NextCtrl = nextControl;
                        }
                        // ----- ADD 2011/05/25 ---------->>>>>
                        if (e.PrevCtrl.Name == "rb_TitleLine_1")
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

                                            e.NextCtrl = uButton_Clear_StockMoveGrid;
                                        }
                                        break;
                                }
                            }
                        }
                        // ----- ADD 2011/05/25 ----------<<<<<
                    }
                    break;
                // ----- DEL 2011/05/25 ---------->>>>>
                //// ----- ADD 2011/05/11 tianjw ----------------------------------------------->>>>>
                //case "rb_TitleLine_1":
                //    {
                //        if (!e.ShiftKey)
                //        {
                //            switch (e.Key)
                //            {
                //                case Keys.Tab:
                //                case Keys.Return:
                //                    {
                //                        // タブ切り替え
                //                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["SettingClear"];

                //                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;

                //                        e.NextCtrl = uButton_Clear_StockMoveGrid;
                //                    }
                //                    break;
                //            }
                //        }
                //    }
                //    break;
                //// ----- ADD 2011/05/11 tianjw -----------------------------------------------<<<<<
                // ----- DEL 2011/05/25 ----------<<<<<
                case "tComboEditor_OutputStyle":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Down:
                                    {
                                        // ----- ADD 2011/05/11 tianjw ------------------>>>>>
                                        if (tComboEditor_OutputStyle.SelectedIndex == 3)
                                        {
                                            e.NextCtrl = rb_DividerChar_0;
                                        }
                                        else
                                        {
                                        // ----- ADD 2011/05/11 tianjw ------------------<<<<<
                                            e.NextCtrl = e.PrevCtrl;
                                        }// ADD 2011/05/11 tianjw
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // ----- ADD 2011/05/11 tianjw ------------------------------------------>>>>>
                                        if (tComboEditor_OutputStyle.SelectedIndex == 3)
                                        {
                                            // 次項目を取得
                                            Control nextControl = _focusControl1.GetNextControl(e.PrevCtrl, e.Key, e.ShiftKey);
                                            if (nextControl != null)
                                            {
                                                e.NextCtrl = nextControl;
                                            }
                                        }
                                        else
                                        {
                                        // ----- ADD 2011/05/11 tianjw ------------------------------------------<<<<<
                                            // タブ切り替え
                                            uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["SettingClear"];

                                            uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;

                                            e.NextCtrl = uButton_Clear_StockMoveGrid;
                                        } // ADD 2011/05/11 tianjw
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

                # endregion

                # region [設定クリア]
                case "uButton_Clear_StockMoveGrid":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                    {
                                        uButton_Clear_StockMoveGrid_Click(this, new EventArgs());
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
                                        // --- ADD 2011/05/26 ---------->>>>>
                                        if (uTabControl_Setting.Tabs["TextOutput"].Visible)
                                        {
                                        // --- ADD 2011/05/26 ----------<<<<<
                                            // タブ切り替え
                                            uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["TextOutput"];
                                            uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                            e.NextCtrl = tComboEditor_OutputStyle;
                                        }
                                        // --- ADD 2011/05/26 ---------->>>>>
                                        else
                                        {
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                        // --- ADD 2011/05/26 ----------<<<<<
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                # endregion

                case "uButton_OK":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                    {
                                        // ボタン押下
                                        uButton_OK_Click(this, new EventArgs());
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "uButton_Cancel":
                    if (!e.ShiftKey)
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    // ボタン押下
                                    uButton_Cancel_Click(this, new EventArgs());
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
            // --- ADD 2011/05/25 ---------->>>>>
            if (e.Key != Keys.LButton)
            {
                if (e.NextCtrl != null && (e.NextCtrl.Name == "rb_DividerChar_0" || e.NextCtrl.Name == "rb_DividerChar_1" || e.NextCtrl.Name == "rb_DividerChar_2"))
                {
                    this._dividerCharClearFlg = false;
                }
                if (e.NextCtrl != null && (e.NextCtrl.Name == "rb_Parenthesis_0" || e.NextCtrl.Name == "rb_Parenthesis_1"))
                {
                    this._parenthesisClearFlg = false;
                }
            }
            else
            {
                this._dividerCharClearFlg = true;
                this._parenthesisClearFlg = true;
            }
            // --- ADD 2011/05/25 ----------<<<<<
        }
        /// <summary>
        /// 区切り文字Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 区切り文字Enter。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void rb_DividerChar_0_Enter(object sender, EventArgs e)
        {
            this.DividerChar = prevDividerChar;
        }
        /// <summary>
        /// 区切り文字Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 区切り文字Leave。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void rb_DividerChar_0_Leave(object sender, EventArgs e)
        {
            prevDividerChar = this.DividerChar;
        }
        /// <summary>
        /// 区切り文字Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 区切り文字Changed。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br>Update Note: Redmine 21703</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/05/25</br>
        /// <br></br>
        /// </remarks>
        private void rb_DividerChar_1_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_DividerChar_1.Checked)
            {
                tEdit_DividerChar.Enabled = true;
            }
            else
            {
                tEdit_DividerChar.Enabled = false;
                // --- UPD 2011/05/25 ---------->>>>>
                //tEdit_DividerChar.Clear();
                if (this._dividerCharClearFlg)
                {
                    tEdit_DividerChar.Clear();
                }
                else
                {
                    this._dividerCharClearFlg = true;
                }
                // --- UPD 2011/05/25 ----------<<<<<
            }
        }
        /// <summary>
        /// 括り文字Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 括り文字Enter。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void rb_Parenthesis_0_Enter(object sender, EventArgs e)
        {
            this.Parenthesis = prevParenthesis;
        }
        /// <summary>
        /// 括り文字Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 括り文字Leave。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void rb_Parenthesis_0_Leave(object sender, EventArgs e)
        {
            prevParenthesis = this.Parenthesis;
        }
        /// <summary>
        /// 括り文字Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 括り文字Changed。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void rb_Parenthesis_1_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Parenthesis_1.Checked)
            {
                tEdit_ParenthesisChar.Enabled = true;
            }
            else
            {
                tEdit_ParenthesisChar.Enabled = false;
                // --- UPD 2011/05/25 ---------->>>>>
                // tEdit_ParenthesisChar.Clear();
                if (this._parenthesisClearFlg)
                {
                    tEdit_ParenthesisChar.Clear();
                }
                else
                {
                    this._parenthesisClearFlg = true;
                }
                // --- UPD 2011/05/25 ----------<<<<<
            }
        }
        /// <summary>
        /// 数値括りEnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 数値括りEnter。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void rb_TieNumeric_0_Enter(object sender, EventArgs e)
        {
            this.TieNumeric = prevTieNumeric;
        }
        /// <summary>
        /// 数値括りLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 数値括りLeave。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void rb_TieNumeric_0_Leave(object sender, EventArgs e)
        {
            prevTieNumeric = this.TieNumeric;
        }
        /// <summary>
        /// 文字括りEnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 文字括りEnter。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void rb_TieChar_0_Enter(object sender, EventArgs e)
        {
            this.TieChar = prevTieChar;
        }
        /// <summary>
        /// 文字括りLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 文字括りLeave。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void rb_TieChar_0_Leave(object sender, EventArgs e)
        {
            prevTieChar = this.TieChar;
        }
        /// <summary>
        /// タイトル行Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : タイトル行Enter。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void rb_TitleLine_0_Enter(object sender, EventArgs e)
        {
            this.TitleLine = prevTitleLine;
        }
        /// <summary>
        /// タイトル行Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : タイトル行Leave。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void rb_TitleLine_0_Leave(object sender, EventArgs e)
        {
            prevTitleLine = this.TitleLine;
        }

        /// <summary>
        /// テキスト出力オプションの有効、無効で設定のテキスト出力タブの表示制御
        /// </summary>
        /// <param name="display">display</param>
        /// <remarks>
        /// <br>Note       : テキスト出力オプションの有効、無効で設定のテキスト出力タブの表示制御。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        public void uTabControlSet(bool display)
        {
            //テキスト出力オプションの有効、無効で設定のテキスト出力タブの表示制御を行う。
            uTabControl_Setting.Tabs["TextOutput"].Visible = display;
        }
        #endregion プライベート関数

    }

    /// <summary>
    /// 在庫移動電子元帳用ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫移動電子元帳のユーザー設定情報を管理するクラス</br>
    /// <br>Programmer : 高峰</br>
    /// <br>Date       : 2011/04/06</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class StockMoveUserConst
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

        /// <summary>項目区切り文字</summary>
        private const string STRING_DIVIDER = "'";
        // 有効な詳細条件リスト
        private List<string> _enabledConditionList;
        // 有効な基本条件リスト
        private List<string> _enabledCommonConditionList;
        // 詳細条件Enableリスト
        private List<string> _enabledList;
        // 伝票グリッドカラムリスト
        private List<ColumnInfo> _stockMoveColumnsList;

        // 詳細条件グループ展開状態
        private bool _extraConditionExpanded;
        // 合計表示グループ展開状態
        private bool _balanceChartExpanded;

        // 在庫移動グリッド自動サイズ調整
        private bool _autoAdjustStockMove;

        // 出力区分
        private int _outPutDiv;

        // 伝票区分
        private int _salesSlipDiv;

        # endregion // プライベート変数

        # region コンストラクタ

        /// <summary>
        /// 在庫移動電子元帳ユーザー設定情報クラス
        /// </summary>
        public StockMoveUserConst()
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

        /// <summary>区切り文字</summary>
        public string DIVIDER
        {
            get { return STRING_DIVIDER; }
        }

        /// <summary>有効な詳細条件リスト</summary>
        public List<string> EnabledConditionList
        {
            get { return this._enabledConditionList; }
            set { this._enabledConditionList = value; }
        }

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

        /// <summary>在庫移動グリッドカラムリスト</summary>
        public List<ColumnInfo> StockMoveColumnsList
        {
            get { return this._stockMoveColumnsList; }
            set { this._stockMoveColumnsList = value; }
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
        /// <summary>在庫移動グリッド自動サイズ調整</summary>
        public bool AutoAdjustStockMove
        {
            get { return _autoAdjustStockMove; }
            set { _autoAdjustStockMove = value; }
        }

        /// <summary>出力区分</summary>
        public int OutPutDiv
        {
            get { return this._outPutDiv; }
            set { this._outPutDiv = value; }
        }

        /// <summary>伝票区分</summary>
        public int SalesSlipDiv
        {
            get { return this._salesSlipDiv; }
            set { this._salesSlipDiv = value; }
        }
        # endregion

        /// <summary>
        /// 在庫移動電子元帳ユーザー設定情報クラス複製処理
        /// </summary>
        /// <returns>在庫移動電子元帳ユーザー設定情報クラス</returns>
        public StockMoveUserConst Clone()
        {
            StockMoveUserConst constObj = new StockMoveUserConst();
            return constObj;
        }

        /// <summary>
        /// ファイル拡張子変換処理
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="selectedValue"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ファイル拡張子変換処理</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        public static string ChangeFileExtension(string fileName, string selectedValue)
        {
            string newExt = string.Empty;
            switch (selectedValue)
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
            if (newExt != string.Empty)
            {
                try
                {
                    fileName = Path.ChangeExtension(fileName, newExt);
                }
                catch
                {
                }
            }
            return fileName;
        }
    }

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
        /// <remarks>
        /// <br>Note       : コンストラクタ</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        public ColumnInfo(string columnName, int visiblePosition, bool hidden, int width, bool columnFixed)
        {
            _columnName = columnName;
            _visiblePosition = visiblePosition;
            _hidden = hidden;
            _width = width;
            _columnFixed = columnFixed;
        }
    }

    /// <summary>
    /// ColumnInfo比較クラス（ソート用）
    /// </summary>
    /// <remarks>
    /// <br>Note       : ColumnInfo比較クラス（ソート用）</br>
    /// <br>Programmer : 高峰</br>
    /// <br>Date       : 2011/04/06</br>
    /// <br></br>
    /// </remarks>
    public class ColumnInfoComparer : IComparer<ColumnInfo>
    {
        /// <summary>
        /// ColumnInfo比較処理
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(ColumnInfo x, ColumnInfo y)
        {
            // 列表示順で比較
            int result = x.VisiblePosition.CompareTo(y.VisiblePosition);
            // 列表示順が一致する場合は列名で比較(通常は発生しない)
            if (result == 0)
            {
                result = x.ColumnName.CompareTo(y.ColumnName);
            }
            return result;
        }
    }

    # endregion

    # region [一般フォーカス制御クラス]
    /// <summary>
    /// 一般フォーカス制御クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 一般フォーカス制御クラス</br>
    /// <br>Programmer : 高峰</br>
    /// <br>Date       : 2011/04/06</br>
    /// <br></br>
    /// </remarks>
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
        /// <remarks>
        /// <br>Note       : 初期化処理</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
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
        /// <remarks>
        /// <br>Note       : １行追加</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        public void AddLine(params Control[] controls)
        {
            List<Control> line = new List<Control>(controls);

            for (int index = 0; index < line.Count; index++)
            {
                int col = index;
                int row = _controls.Count;

                _col.Add(line[index].Name, col);
                _row.Add(line[index].Name, row);
            }

            _controls.Add(line);
        }

        /// <summary>
        /// 次コントロール取得（フォーカス移動先）
        /// </summary>
        /// <param name="prevControl"></param>
        /// <param name="key"></param>
        /// <param name="shiftKey"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 次コントロール取得（フォーカス移動先）</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br>Update Note: 2011/05/11 tianjw</br>
        /// <br>             redmine #20951</br>
        /// <br></br>
        /// </remarks>
        public Control GetNextControl(Control prevControl, Keys key, bool shiftKey)
        {
            Control nextControl = null;

            if (!_col.ContainsKey(prevControl.Name)) return null;

            int col = _col[prevControl.Name];
            int row = _row[prevControl.Name];

            if (_controls[row][col].Name != prevControl.Name) return null;

            if (!shiftKey)
            {
                switch (key)
                {
                    # region [UP]
                    case Keys.Up:
                        {
                            if (row - 1 >= 0)
                            {
                                int originCol = col;
                                row--;

                                if (col > _controls[row].Count - 1)
                                {
                                    col = _controls[row].Count - 1;
                                }
                                nextControl = _controls[row][col];
                                while (nextControl == null || nextControl.Enabled == false)
                                {
                                    if (col > 0)
                                    {
                                        col--;
                                        nextControl = _controls[row][col];
                                    }
                                    else if (row > 0)
                                    {
                                        col = originCol;
                                        row--;
                                        if (col > _controls[row].Count - 1)
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
                            if (row + 1 <= _controls.Count - 1)
                            {
                                int originCol = col;
                                row++;

                                if (col > _controls[row].Count - 1)
                                {
                                    col = _controls[row].Count - 1;
                                }
                                nextControl = _controls[row][col];
                                while (nextControl == null || nextControl.Enabled == false)
                                {
                                    if (col > 0)
                                    {
                                        col--;
                                        nextControl = _controls[row][col];
                                    }
                                    else if (row + 1 <= _controls.Count - 1)
                                    {
                                        col = originCol;
                                        row++;
                                        if (col > _controls[row].Count - 1)
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
                                //nextControl = null; // DEL 2011/05/11 tianjw
                                nextControl = _controls[row][col]; // ADD 2011/05/11 tianjw
                            }
                        }
                        break;
                    # endregion

                    # region [LEFT]
                    case Keys.Left:
                        {
                            nextControl = null;
                            while (nextControl == null || nextControl.Enabled == false)
                            {
                                if (col > 0)
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
                            while (nextControl == null || nextControl.Enabled == false)
                            {
                                if (col < _controls[row].Count - 1)
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
                            while (nextControl == null || nextControl.Enabled == false)
                            {
                                if (col + 1 <= _controls[row].Count - 1)
                                {
                                    col++;
                                }
                                else if (row + 1 <= _controls.Count - 1)
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
                switch (key)
                {
                    # region [Tab順前]
                    case Keys.Tab:
                    case Keys.Return:
                        {
                            // Tab順前項目
                            nextControl = null;
                            while (nextControl == null || nextControl.Enabled == false)
                            {
                                if (col - 1 >= 0)
                                {
                                    col--;
                                }
                                else if (row - 1 >= 0)
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

    # region [グリッド・列選択ダイアログ制御クラス]
    /// <summary>
    /// グリッド・列選択ダイアログ制御クラス
    /// </summary>
    /// <remarks>Gridのカラムチューザを共通化します</remarks>
    /// <remarks>
    /// <br>Note       : グリッド・列選択ダイアログ制御クラス</br>
    /// <br>Programmer : 高峰</br>
    /// <br>Date       : 2011/04/06</br>
    /// <br></br>
    /// </remarks>
    public class GridColumnChooserControl
    {
        private List<Infragistics.Win.UltraWinGrid.UltraGrid> _targetList;
        private Dictionary<string, Infragistics.Win.UltraWinGrid.ColumnChooserDialog> _chooserDialogs;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : コンストラクタ</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        public GridColumnChooserControl()
        {
            _targetList = new List<Infragistics.Win.UltraWinGrid.UltraGrid>();
            _chooserDialogs = new Dictionary<string, Infragistics.Win.UltraWinGrid.ColumnChooserDialog>();
        }

        /// <summary>
        /// 対象追加
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <remarks>
        /// <br>Note       :対象追加</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        public void Add(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid)
        {
            if (!_targetList.Contains(targetGrid))
            {
                // 対象Gridリスト
                _targetList.Add(targetGrid);
                // カラムチューザダイアログ
                _chooserDialogs.Add(targetGrid.Name, CreateColumnChooser(targetGrid));

                // 対象Gridへの操作
                targetGrid.DisplayLayout.ColumnChooserEnabled = Infragistics.Win.DefaultableBoolean.False;
                targetGrid.BeforeColumnChooserDisplayed += new Infragistics.Win.UltraWinGrid.BeforeColumnChooserDisplayedEventHandler(uGrid_BeforeColumnChooserDisplayed);
            }
        }
        /// <summary>
        /// カラムチューザー表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>※Gridのデフォルトのカラムチューザーをカスタマイズします</remarks>
        /// <remarks>
        /// <br>Note       :カラムチューザー表示</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uGrid_BeforeColumnChooserDisplayed(object sender, Infragistics.Win.UltraWinGrid.BeforeColumnChooserDisplayedEventArgs e)
        {
            // デフォルトの処理はキャンセルする
            e.Cancel = true;

            // カラムチューザーダイアログ
            Infragistics.Win.UltraWinGrid.ColumnChooserDialog chooser = _chooserDialogs[(sender as Control).Name];
            if (chooser == null) return;

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
        /// <param name="sourceGrid"></param>
        /// <remarks>
        /// <br>Note       :カラムチューザー生成処理</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private Infragistics.Win.UltraWinGrid.ColumnChooserDialog CreateColumnChooser(Infragistics.Win.UltraWinGrid.UltraGrid sourceGrid)
        {
            Infragistics.Win.UltraWinGrid.ColumnChooserDialog chooser = new Infragistics.Win.UltraWinGrid.ColumnChooserDialog();

            chooser.Text = "表示項目の選択";
            chooser.StartPosition = FormStartPosition.CenterScreen;
            chooser.Size = new Size(250, 400);
            chooser.TopMost = true;

            // 表示→閉じた後、破棄しない
            chooser.DisposeOnClose = Infragistics.Win.DefaultableBoolean.False;

            chooser.ColumnChooserControl.SourceGrid = sourceGrid;
            chooser.ColumnChooserControl.Font = sourceGrid.Font;

            return chooser;
        }
    }
    # endregion

}