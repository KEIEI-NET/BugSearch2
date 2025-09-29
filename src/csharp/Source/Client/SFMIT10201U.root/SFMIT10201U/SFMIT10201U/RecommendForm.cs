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
    /// <summary>
    /// 簡易オススメ選択
    /// </summary>
    public partial class RecommendForm : Form
    {
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RecommendForm()
        {
            InitializeComponent();
        }
        #endregion

        #region メンバ
        /// <summary>選択件数</summary>
        public int _count;
        /// <summary>対象(1:部品商、2：整備工場)</summary>
        public int _target;
        #endregion

        #region Public
        /// <summary>
        /// 起動処理
        /// </summary>
        /// <returns></returns>
        public DialogResult ShowRecomendForm(int bootMode, long categoryId, string categoryName)
        {
            if (bootMode == 2)
            {
                this.Target1_panel.Visible = false;
                this.SF_Lable.Visible = true;
                this.PM_Label.Visible = false;
            }
            else
            {
                this.Target1_ComboEditor.Items.Add(2,"整備工場");
                this.Target1_ComboEditor.Items.Add(1, "部品商");
                this.Target1_ComboEditor.SelectedIndex = 0;
                this.SF_Lable.Visible = false;
                this.PM_Label.Visible = true;
            }

            this.Target2_ComboEditor.Items.Add(1, "1");
            this.Target2_ComboEditor.Items.Add(2, "2");
            this.Target2_ComboEditor.Items.Add(3, "3");
            this.Target2_ComboEditor.SelectedIndex = 0;

            this.Category_textBox.Text = categoryName;

            switch (categoryId)
            {
                case 1: // タイヤ
                    this.Cndition_Lable.Text = "各サイズの中で";
                    break;
                case 2: // バッテリ
                    this.Cndition_Lable.Text = "各規格の中で";
                    break;
                case 3: // オイル
                    this.Cndition_Lable.Text = "各粘度の中で";
                    break;
            }
            return this.ShowDialog();
        }
        #endregion

        #region Private
        /// <summary>
        /// 数値入力チェック処理
        /// </summary>
        /// <param name="keta">桁数(マイナス符号を含まず)</param>
        /// <param name="priod">小数点以下桁数</param>
        /// <param name="prevVal">現在の文字列</param>
        /// <param name="key">入力されたキー値</param>
        /// <param name="selstart">カーソル位置</param>
        /// <param name="sellength">選択文字長</param>
        /// <param name="minusFlg">マイナス入力可？</param>
        /// <returns>true=入力可,false=入力不可</returns>
        private Boolean KeyPressCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // 制御キーが押された？
            if (Char.IsControl(key) == true)
            {
                return true;
            }
            // 数値以外は、ＮＧ
            if (Char.IsNumber(key) == false)
            {
                // 小数点または、マイナス以外
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string _strResult = "";
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // マイナスのチェック
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // 小数点のチェック
            if (key == '.')
            {
                if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // キーが押された結果の文字列を生成する。
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // 桁数チェック！
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // 小数点以下のチェック
            if (priod > 0)
            {
                // 小数点の位置決定
                int _pointPos = _strResult.IndexOf('.');

                // 整数部に入力可能な桁数を決定！
                int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
                // 整数部の桁数をチェック
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (_strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // 小数部の桁数をチェック
                if (_pointPos != -1)
                {
                    // 小数部の桁数を計算
                    int _priketa = _strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        #endregion

        #region Event
        /// <summary>
        /// 確定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Button_Click(object sender, EventArgs e)
        {
            this._count = Convert.ToInt32(this.Target2_ComboEditor.Value);

            if (this._count == 0)
            {
                // メッセージを表示
                TMsgDisp.Show(
                this,							        // 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // エラーレベル
                "SFMIT010201U",					        // アセンブリIDまたはクラスID
                 "件数を入力して下さい。", 	            // 表示するメッセージ 
                0,								        // ステータス値
                   MessageBoxButtons.OK);
                this.Target2_ComboEditor.Focus();
                return;
            }

            if (this.Target1_panel.Visible)
            {
                this._target = (int)this.Target1_ComboEditor.Value;
            }

            

            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// キャンセル
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// tComboEditor1_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!KeyPressCheck(2, 0, this.Target2_ComboEditor.Text, e.KeyChar, this.Target2_ComboEditor.SelectionStart, this.Target2_ComboEditor.SelectionLength, false))
            {
                e.Handled = true;
            }
        }

        #endregion
    }
}