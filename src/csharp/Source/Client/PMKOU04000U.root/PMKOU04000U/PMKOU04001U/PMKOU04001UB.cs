using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    public partial class PMKOU04001UB : Form
    {

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
        #region プライベート変数
        // ユーザー設定
        private SuppPtrStcUserConst _userSetting;

        // 区切り文字
        private string _divider;

        // パターン
        private string[] _outputPattern;

        // 選択されているパターン名
        private string _selectedPattern;
        #endregion // プライベート変数

        #region プロパティ
        /// <summary>
        /// ユーザー設定定義
        /// </summary>
        public SuppPtrStcUserConst UserSetting
        {
            get { return this._userSetting; }
            set { this._userSetting = value; }
        }
        #endregion // プロパティ
        /// <summary>
        /// テキスト出力確認
        /// </summary>
        public PMKOU04001UB()
        {
            InitializeComponent();

            this._userSetting = new SuppPtrStcUserConst();
        }

        #region プライベート関数

        /// <summary>
        /// 画面の初期値を設定
        /// </summary>
        private void setInitialValue()
        {
            // 設定値があればそれを設置
            if ( this._outputPattern == null )
            {
                this.tEdit_SettingFileName.Clear();
                this.tComboEditor_PetternSelect.Text = string.Empty;
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

                // パターン名
                this.tComboEditor_PetternSelect.Text = this._selectedPattern;
            }
        }

        /// <summary>
        /// パターンの内容を分解
        /// </summary>
        /// <param name="pBody"></param>
        /// <param name="pValue"></param>
        private void getPatternValue( string pBody, out string[] pValue )
        {
            const int ct_ItemCount = 11;
            pValue = new string[ct_ItemCount];

            string str1 = pBody;
            string str2 = string.Empty;

            for ( int i = 0; i < ct_ItemCount; i++ )
            {
                if ( str1.Contains( this._divider ) )
                {
                    pValue[i] = str1.Substring( 0, str1.IndexOf( this._divider ) );
                }
                else
                {
                    pValue[i] = str1.Substring( 0 );
                }
                str2 = str1.Substring( str1.IndexOf( this._divider ) + 1 );
                str1 = str2;
            }
        }

        /// <summary>
        /// グリッドのセッティングを文字列から取り出す
        /// </summary>
        /// <param name="patternStr"></param>
        /// <param name="gridSetting"></param>
        /// <param name="isSlip"></param>
        private void getGridSettingPattern( string patternStr, out string[] gridSetting, bool isSlip )
        {
            int count = patternStr.Length / 3;
            gridSetting = new string[count];

            for ( int i = 0; i < count; i++ )
            {
                gridSetting[i] = patternStr.Substring( i * 3, 3 );
            }
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
            foreach ( string pattern in this._outputPattern )
            {
                // 最初の区切り文字までがパターン名
                if ( pattern.Contains( this._divider ) )
                {
                    pName = pattern.Substring( 0, pattern.IndexOf( this._divider ) );

                    // 設定されているパターンの場合は内容を取得
                    if ( pName == this._selectedPattern )
                    {
                        getPatternValue( pattern.Substring( pattern.IndexOf( this._divider ) + 1 ), out patternValue );
                        break;
                    }
                }
            }

            // 取得が終わったら、画面を設定する

            ////// ファイル名
            ////this.tEdit_SettingFileName.Text = this._userSetting.OutputFileName;

            // パターン名
            this.tComboEditor_PetternSelect.Text = this._selectedPattern;

            // ファイル名へ適用
            this.OutputStyle_ValueChanged( patternValue[9].ToString() );
        }

        /// <summary>
        /// 出力形式変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutputStyle_ValueChanged( string selected )
        {
            // 選択値
            string fileName = this.tEdit_SettingFileName.Text.Trim();

            // 拡張子変換
            fileName = SuppPtrStcUserConst.ChangeFileExtension( fileName, selected );
            this.tEdit_SettingFileName.Text = fileName;
        }

        /// <summary>
        /// 入力値チェック
        /// </summary>
        /// <returns></returns>
        private bool checkValues()
        {
            // ファイル名
            if ( String.IsNullOrEmpty( this.tEdit_SettingFileName.Text.Trim() ) ) return false;

            // パターン名
            if ( String.IsNullOrEmpty( this.tComboEditor_PetternSelect.Text.Trim() ) ) return false;

            return true;
        }
        #endregion // プライベート関数

        #region イベント

        /// <summary>
        /// 画面起動時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKOU04001UB_Load( object sender, EventArgs e )
        {
            // パターン・区切り文字・設定名を取得
            if ( this._userSetting != null )
            {
                this._outputPattern = this._userSetting.OutputPattern;
                this._divider = this._userSetting.DIVIDER;
                this._selectedPattern = this._userSetting.SelectedPatternName;
            }

            // ボタン設定
            this.uButton_FileSelect.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
            this.uButton_FileSelect.Appearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;

            // 画面の初期値をセット
            setInitialValue();

            // ValueChangedイベントで書き変わったファイル名を戻す
            tEdit_SettingFileName.Text = _userSetting.OutputFileName;
        }

        /// <summary>
        /// パターン変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_PetternSelect_SelectionChangeCommitted( object sender, System.EventArgs e )
        {
            if ( tComboEditor_PetternSelect.SelectedItem != null )
            {
                this._selectedPattern = this.tComboEditor_PetternSelect.SelectedItem.DataValue.ToString();
                getSelectedPattern();
            }
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
        /// <summary>
        /// フォーカス移動イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl_ChangeFocus( object sender, ChangeFocusEventArgs e )
        {
            if ( e.PrevCtrl == null || e.NextCtrl == null ) return;

            switch ( e.PrevCtrl.Name )
            {
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
                    break;
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
        #endregion // イベント

        #region ボタン

        /// <summary>
        /// キャンセルボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Cancel_Click( object sender, EventArgs e )
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// OKボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_OK_Click( object sender, EventArgs e )
        {
            // チェック
            if ( !checkValues() )
            {
                return;
            }

            // ファイル名
            this._userSetting.OutputFileName = this.tEdit_SettingFileName.Text.Trim();

            // パターン名
            this._userSetting.SelectedPatternName = this.tComboEditor_PetternSelect.Text.Trim();

            this.DialogResult = DialogResult.OK;

            // 終了
            this.Close();
        }

        /// <summary>
        /// ファイルダイアログ表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_FileSelect_Click( object sender, EventArgs e )
        {
            if ( !String.IsNullOrEmpty( this.tEdit_SettingFileName.Text ) )
            {
                this.openFileDialog.FileName = this.tEdit_SettingFileName.Text.Trim();
            }
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
            this.openFileDialog.Filter = string.Format( "{0} | {1}", "ファイル(*.*)", "*.*" );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

            // ファイル選択
            if ( this.openFileDialog.ShowDialog() == DialogResult.OK )
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

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
        # region // DEL
        ///// <summary>
        ///// テキスト出力確認
        ///// </summary>
        //public PMKOU04001UB()
        //{
        //    InitializeComponent();
            
        //}
        ///// <summary>出力ファイル名</summary>
        //private string _outputFileName = string.Empty;

        ///// <summary>出力パターン</summary>
        //private string[] _outputPattern;

        ///// <summary>出力パターン名</summary>
        //private string _selectedPatternName = string.Empty;

        //// 区切り文字
        //private string _divider = "/";
        ////private const string STRING_DIVIDER = "/";
        ///// <summary>出力ファイル名</summary>
        //public string OutputFileName
        //{
        //    get { return this._outputFileName; }
        //    set { this._outputFileName = value; }
        //}

        ///// <summary>出力パターン</summary>
        //public string[] OutputPattern
        //{
        //    get { return this._outputPattern; }
        //    set { this._outputPattern = value; }
        //}

        ///// <summary>出力パターン名</summary>
        //public string SelectedPatternName
        //{
        //    get { return this._selectedPatternName; }
        //    set { this._selectedPatternName = value; }
        //}
        //private void PMKOU04001UB_Load(object sender, System.EventArgs e)
        //{
        //    InitializeVariable();
        //}

        //private void InitializeVariable()
        //{
        //    // 初期値がセットされていたら画面に表示
        //    if (!String.IsNullOrEmpty(this._outputFileName))
        //    {
        //        this.tEdit_SettingFileName.Text = this._outputFileName;
        //    }

        //    PMKOU04004UA settingConstForm = new PMKOU04004UA();
        //    settingConstForm.Deserialize();


        //    Infragistics.Win.ValueListItem item;
        //    string pName = string.Empty;
        //    string[] patternSetting = new string[9];
        //    this.tComboEditor_PetternSelect.Items.Clear();

        //    foreach (string pattern in this._outputPattern)
        //    {
        //        item = new Infragistics.Win.ValueListItem();

        //        // 最初の区切り文字までがパターン名
        //        if (pattern.Contains(this._divider))
        //        {
        //            pName = pattern.Substring(0, pattern.IndexOf(this._divider));
        //            settingConstForm.Degradation(pName, out patternSetting);
        //            if (patternSetting[9] == "0") // CSV
        //            {
        //                item.DataValue = ".csv";
        //            }
        //            else if (patternSetting[9] == "1") // TXT
        //            {
        //                item.DataValue = ".txt";
        //            }
        //            else if (patternSetting[9] == "2") // PRN
        //            {
        //                item.DataValue = ".prn";
        //            }
        //            else
        //            {
        //                item.DataValue = "";
        //            }
        //            item.DisplayText = pName;

        //            this.tComboEditor_PetternSelect.Items.Add(item);
        //        }
        //    }
        //}

        //#region ボタン

        ///// <summary>
        ///// ファイルダイアログ表示
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void uButton_FileSelect_Click(object sender, EventArgs e)
        //{
        //    if (!String.IsNullOrEmpty(this.tEdit_SettingFileName.Text))
        //    {
        //        this.openFileDialog.FileName = this.tEdit_SettingFileName.Text.Trim();
        //    }
        //    this.openFileDialog.Multiselect = false;
        //    this.openFileDialog.CheckFileExists = false;

        //    // ファイル選択
        //    if (this.openFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        this.tEdit_SettingFileName.Text = openFileDialog.FileName.ToUpper();
        //    }
        //}

        //private void uButton_OK_Click(object sender, EventArgs e)
        //{
        //    this.OutputFileName = this.tEdit_SettingFileName.Text;
        //    this._selectedPatternName = this.tComboEditor_PetternSelect.SelectedText;
        //    this.DialogResult = DialogResult.OK;
        //    this.Close();
        //}

        //private void uButton_Cancel_Click(object sender, EventArgs e)
        //{
        //    this.DialogResult = DialogResult.Cancel;
        //    this.Close();
        //}

        //#endregion // ボタン

        //private void tComboEditor_PetternSelect_ValueChanged(object sender, EventArgs e)
        //{
        //    string fileName = this.tEdit_SettingFileName.Text.Trim();
        //    if (!String.IsNullOrEmpty(fileName) && fileName.Contains("."))
        //    {
        //        fileName = fileName.Substring(0, fileName.IndexOf(".")) + (string)this.tComboEditor_PetternSelect.SelectedItem.DataValue;
        //        this.tEdit_SettingFileName.Text = fileName;
        //    }
        //}
        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
    }
}