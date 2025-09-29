//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 在庫照会
// プログラム概要   : 在庫照会 テキスト出力確認ＵＩクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI 斎藤 和宏
// 修 正 日  2012/09/18  修正内容 : 新規作成
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
    /// 在庫照会 テキスト出力確認ＵＩクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : テキスト出力時にファイル名・出力タイプを選択する為のＵＩです。</br>
    /// <br>Programmer : FSI 斎藤 和宏</br>
    /// <br>Date       : 2012/09/19</br>
    /// </remarks>
    public partial class MAZAI04110UC : Form
    {
        #region プライベート変数
        // ユーザー設定
        private StockUserConst _userSetting;

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
        public StockUserConst UserSetting
        {
            get { return this._userSetting; }
            set { this._userSetting = value; }
        }
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MAZAI04110UC()
        {
            InitializeComponent();

            this._userSetting = new StockUserConst();
        }
        #endregion

        #region プライベート関数

        /// <summary>
        /// 画面の初期値を設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期値を設定。</br>
        /// <br>Programmer : FSI 斎藤 和宏</br>
        /// <br>Date       : 2012/09/19</br>
        /// </remarks>
        private void setInitialValue()
        {
            // 設定値があればそれを設置
            if (this._outputPattern == null)
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
                // 出力項目リスト (35項目x4文字) 基本的に表示順の数字,非表示の場合は99, 必ずExportColumnDataSet.SalesListの順に並んでいる   7
                // パターン形式(.CSV/.TXT/.PRN/カスタム)            8

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

                        this.tComboEditor_PetternSelect.Items.Add( item );

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
            }
        }

        /// <summary>
        /// パターンの内容を分解
        /// </summary>
        /// <param name="pBody"></param>
        /// <param name="pValue"></param>
        /// <remarks>
        /// <br>Note       : パターンの内容を分解。</br>
        /// <br>Programmer : FSI 斎藤 和宏</br>
        /// <br>Date       : 2012/09/19</br>
        /// </remarks>
        private void getPatternValue(string pBody, out string[] pValue)
        {
            const int ct_ItemCount = 11;
            pValue = new string[ct_ItemCount];

            string str1 = pBody;
            string str2 = string.Empty;

            for ( int i = 0; i < ct_ItemCount; i++ )
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
        /// <br>Programmer : FSI 斎藤 和宏</br>
        /// <br>Date       : 2012/09/19</br>
        /// </remarks>
        private void getGridSettingPattern(string patternStr, out string[] gridSetting, bool isSlip)
        {
            int count = patternStr.Length / 4;
            gridSetting = new string[count];

            for ( int i = 0; i < count; i++ )
            {
                gridSetting[i] = patternStr.Substring( i * 4, 4 );
            }
        }

        /// <summary>
        /// 選択されたパターンを適用
        /// </summary>
        /// <remarks>
        /// <br>Note       : 選択されたパターンを適用。</br>
        /// <br>Programmer : FSI 斎藤 和宏</br>
        /// <br>Date       : 2012/09/19</br>
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
            // 出力項目リスト (35項目x4文字) 基本的に表示順の数字,非表示の場合は99, 必ずExportColumnDataSet.SalesListの順に並んでいる   7
            // パターン形式(.CSV/.TXT/.PRN/カスタム)            8

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

            // ファイル名へ適用
            this.OutputStyle_ValueChanged( patternValue[8].ToString() );
        }

        /// <summary>
        /// 出力形式変更
        /// </summary>
        /// <param name="selected"></param>
        /// <remarks>
        /// <br>Note       : 出力形式変更。</br>
        /// <br>Programmer : FSI 斎藤 和宏</br>
        /// <br>Date       : 2012/09/19</br>
        /// </remarks>
        private void OutputStyle_ValueChanged( string selected )
        {
            // 選択値
            string fileName = this.tEdit_SettingFileName.Text.Trim();

            // 拡張子変換
            fileName = StockUserConst.ChangeFileExtension(fileName, selected);
            this.tEdit_SettingFileName.Text = fileName;
        }

        /// <summary>
        /// 入力値チェック
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 入力値チェック。</br>
        /// <br>Programmer : FSI 斎藤 和宏</br>
        /// <br>Date       : 2012/09/19</br>
        /// </remarks>
        private bool checkValues()
        {
            // ファイル名
            if (String.IsNullOrEmpty(this.tEdit_SettingFileName.Text.Trim()))
            {
                // ファイル名が指定されていないとエラー
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "出力ファイル名が指定されていません。", -1, MessageBoxButtons.OK);

                return false;
            }

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
        /// <remarks>
        /// <br>Note       : 画面起動時処理。</br>
        /// <br>Programmer : FSI 斎藤 和宏</br>
        /// <br>Date       : 2012/09/19</br>
        /// </remarks>
        private void MAZAI04110UC_Load( object sender, EventArgs e )
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
        /// <remarks>
        /// <br>Note       : パターン変更。</br>
        /// <br>Programmer : FSI 斎藤 和宏</br>
        /// <br>Date       : 2012/09/19</br>
        /// </remarks>
        private void tComboEditor_PetternSelect_SelectionChangeCommitted(object sender, System.EventArgs e)
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
        /// <remarks>
        /// <br>Note       : パターンテキスト変更時イベント処理。</br>
        /// <br>Programmer : FSI 斎藤 和宏</br>
        /// <br>Date       : 2012/09/19</br>
        /// </remarks>
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
        /// <remarks>
        /// <br>Note       : 設定ＵＩ初期表示イベント処理。</br>
        /// <br>Programmer : FSI 斎藤 和宏</br>
        /// <br>Date       : 2012/09/19</br>
        /// </remarks>
        private void MAZAI04110UB_Shown( object sender, EventArgs e )
        {
            tEdit_SettingFileName.Focus();
        }
        /// <summary>
        /// フォーカス移動イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : フォーカス移動イベント処理。</br>
        /// <br>Programmer : FSI 斎藤 和宏</br>
        /// <br>Date       : 2012/09/19</br>
        /// <br></br>
        /// </remarks>
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
        /// <remarks>
        /// <br>Note       : キャンセルボタン。</br>
        /// <br>Programmer : FSI 斎藤 和宏</br>
        /// <br>Date       : 2012/09/19</br>
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
        /// <br>Programmer : FSI 斎藤 和宏</br>
        /// <br>Date       : 2012/09/19</br>
        /// </remarks>
        private void uButton_OK_Click(object sender, EventArgs e)
        {
            // チェック
            if (!checkValues())
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
        /// <remarks>
        /// <br>Note       : ファイルダイアログ表示。</br>
        /// <br>Programmer : FSI 斎藤 和宏</br>
        /// <br>Date       : 2012/09/19</br>
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

    }
}