using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 売上速報表示 設定UI
    /// </summary>
    ///<remarks>
    /// <br>Note        : 売上速報表示 設定UIフォームクラス</br>
    /// <br>Programmer  : 30418 徳永</br>
    /// <br>Date        : 2008/11/21</br>
    /// </remarks>
    public partial class PMHNB04151UB : Form
    {
        #region コンストラクタ

        public PMHNB04151UB()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初期フォーカス用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMHNB04151UB_Shown(object sender, System.EventArgs e)
        {
            // 2008.12.01 add start [8494]
            this.uComboEditor_StartupSearch.Focus();
            // 2008.12.01 add end [8494]
        }

        /// <summary>
        /// ロード時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMHNB04151UB_Load(object sender, System.EventArgs e)
        {
            //if (this._alreadySetup)
            //{
            // 起動時検索
            foreach (Infragistics.Win.ValueListItem item in this.uComboEditor_StartupSearch.Items)
            {
                if ((int)item.DataValue == this._startupSearch)
                {
                    this.uComboEditor_StartupSearch.SelectedItem = item;
                    this.uComboEditor_StartupSearch.Text = item.DisplayText;
                }
            }

            // 自動更新
            foreach (Infragistics.Win.ValueListItem item in this.uComboEditor_AutoUpdate.Items)
            {
                if ((int)item.DataValue == this._autoUpdate)
                {
                    this.uComboEditor_AutoUpdate.SelectedItem = item;
                    this.uComboEditor_AutoUpdate.Text = item.DisplayText;
                }
            }

            // 初期拠点
            foreach (Infragistics.Win.ValueListItem item in this.uComboEditor_DefaultSecCode.Items)
            {
                if ((int)item.DataValue == this._initialSectionCode)
                {
                    this.uComboEditor_DefaultSecCode.SelectedItem = item;
                    this.uComboEditor_DefaultSecCode.Text = item.DisplayText;
                }
            }
            //}
        }

        #endregion // コンストラクタ

        #region プライベート変数

        /// <summary>設定が行われているかどうか</summary>
        private bool _alreadySetup = false;

        /// <summary>起動時の抽出</summary>
        private int _startupSearch = 0;

        /// <summary>自動更新</summary>
        private int _autoUpdate = 0;

        /// <summary>拠点の初期値</summary>
        private int _initialSectionCode = 0;

        /// <summary>設定保存ファイル名</summary>
        private string _xmlFileName = string.Empty;

        #endregion // プライベート変数

        #region プロパティ

        /// <summary>設定が行われているかどうか</summary>
        public bool AlreadySetup
        {
            get { return this._alreadySetup; }
            set { this._alreadySetup = value; }
        }

        /// <summary>起動時の抽出</summary>
        public int StartupSearch
        {
            get { return this._startupSearch; }
            set { this._startupSearch = value; }
        }

        /// <summary>自動更新</summary>
        public int AutoUpdate
        {
            get { return this._autoUpdate; }
            set { this._autoUpdate = value; }
        }

        /// <summary>拠点の初期値</summary>
        public int InitialSectionCode
        {
            get { return this._initialSectionCode; }
            set { this._initialSectionCode = value; }
        }

        /// <summary>設定保存ファイル名</summary>
        public string XmlFileName
        {
            get { return this._xmlFileName; }
            set { this._xmlFileName = value; }
        }

        #endregion // プロパティ

        #region コントロールメソッド

        /// <summary>
        /// OKボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_OK_Click(object sender, EventArgs e)
        {
            this.AlreadySetup = true;
            this.AutoUpdate = (int)this.uComboEditor_AutoUpdate.SelectedItem.DataValue;
            this.StartupSearch = (int)this.uComboEditor_StartupSearch.SelectedItem.DataValue;
            this.InitialSectionCode = (int)this.uComboEditor_DefaultSecCode.SelectedItem.DataValue;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// キャンセルボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // 2008.12.01 add start [8494]
        /// <summary>
        /// キーコントロール
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // 名前により分岐
            switch (e.PrevCtrl.Name)
            {
                //---------------------------------------------------------------
                // フィールド間移動
                //---------------------------------------------------------------

                #region 起動時の抽出
                case "uComboEditor_StartupSearch":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.uComboEditor_AutoUpdate;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // 起動時の抽出

                #region 自動更新
                case "uComboEditor_AutoUpdate":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.uComboEditor_DefaultSecCode;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.uComboEditor_StartupSearch;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // 自動更新

                #region 拠点の初期値
                case "uComboEditor_DefaultSecCode":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.uButton_OK;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.uComboEditor_AutoUpdate;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // 拠点の初期値

                #region OKボタン
                case "uButton_OK":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.uButton_Cancel;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.uComboEditor_DefaultSecCode;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // OKボタン

                #region キャンセルボタン
                case "uButton_Cancel":
                    {
                        switch (e.Key)
                        {
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.uComboEditor_DefaultSecCode;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // キャンセルボタン

                default: break;

            }
        }

        /// <summary>
        /// 項目編集を無効に
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uComboEditor_StartupSearch_Leave(object sender, EventArgs e)
        {
            bool found = false;
            string uitext = this.uComboEditor_StartupSearch.Text.Trim();
            foreach (Infragistics.Win.ValueListItem v in this.uComboEditor_StartupSearch.Items)
            {
                if (v.DisplayText.Equals(uitext))
                {
                    found = true;
                }
            }

            // 編集されていたら戻す
            if (!found)
            {
                this.uComboEditor_StartupSearch.SelectedItem = this.uComboEditor_StartupSearch.Items[0];
            }
        }

        /// <summary>
        /// 項目編集を無効に
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uComboEditor_AutoUpdate_Leave(object sender, EventArgs e)
        {
            bool found = false;
            string uitext = this.uComboEditor_AutoUpdate.Text.Trim();
            foreach (Infragistics.Win.ValueListItem v in this.uComboEditor_AutoUpdate.Items)
            {
                if (v.DisplayText.Equals(uitext))
                {
                    found = true;
                }
            }

            // 編集されていたら戻す
            if (!found)
            {
                this.uComboEditor_AutoUpdate.SelectedItem = this.uComboEditor_AutoUpdate.Items[1];
            }
        }

        /// <summary>
        /// 項目編集を無効に
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uComboEditor_DefaultSecCode_Leave(object sender, EventArgs e)
        {
            bool found = false;
            string uitext = this.uComboEditor_DefaultSecCode.Text.Trim();
            foreach (Infragistics.Win.ValueListItem v in this.uComboEditor_DefaultSecCode.Items)
            {
                if (v.DisplayText.Equals(uitext))
                {
                    found = true;
                }
            }

            // 編集されていたら戻す
            if (!found)
            {
                this.uComboEditor_DefaultSecCode.SelectedItem = this.uComboEditor_DefaultSecCode.Items[0];
            }
        }


        // 2008.12.01 add end [8494]

        #endregion // コントロールメソッド

    }
}