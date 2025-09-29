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
    /// 金額一括計算クラス
    /// </summary>
    public partial class CalcPriceForm : Form
    {
        public CalcPriceForm(int bootMode)
        {
            InitializeComponent();
            this._percentage_PM = 0;
            this._percentage_SF = 0;
            this._originCol_PM = "";
            this._originCol_SF = "";
            this._targetCol_PM = "";
            this._targetCol_SF = "";
            this._bootMode = 0;
            this._calcDiv = true;


            // 計算対象は今のところ固定
            this._targetCol_SF = COL_SHOP_PRICE;
            this._targetCol_PM = COL_TRADE_PRICE;

            this.SF_TARGET_ComboEditor.Items.Add(1, COL_SUGGEST_PRICE);
            if (bootMode == 2)
            {
                // 整備工場モード 整備工場モードの場合は標準価格と仕入原価
                this.SF_TARGET_ComboEditor.Items.Add(2, COL_PURCHASE_COST);
            }
            else
            {
                // 部品商モード 部品商モードの場合は標準価格と売価
                this.SF_TARGET_ComboEditor.Items.Add(2, COL_TRADE_PRICE);
            }

            this.SF_TARGET_ComboEditor.Value = 1;

            // 部品商部分
            this.PM_TARGET_ComboEditor.Items.Add(1, COL_SUGGEST_PRICE);
            this.PM_TARGET_ComboEditor.Items.Add(2, COL_PURCHASE_COST);
            this.PM_TARGET_ComboEditor.Value = 2;

            // 端数処理区分
            this.Digit_ComboEditor.Value = -12;
        }

        /// <summary>
        /// 起動処理
        /// </summary>
        /// <returns></returns>
        public DialogResult ShowCalcPriceForm()
        {
            if (this._bootMode == 2)
            {
                // 整備工場モード
                this.SFModeTitle_Lable.Visible = true;
                this.SF_CheckEditor.Visible = false;
                this.PMTITLE_panel.Visible = false;
                this.PMCALC_panel.Visible = false;

                this.Size = new Size(490, 220);

                // 計算対象
                if ((int)this.SF_TARGET_ComboEditor.Value == 1)
                {
                    this._originCol_SF = COL_SUGGEST_PRICE;
                }
                else
                {
                    // 整備工場モードの場合は売価＝仕入原価となる為
                    this._originCol_SF = COL_TRADE_PRICE;
                }
            }
            else
            {
                // 部品商モード
                this.Size = new Size(490, 310);

                // 計算対象
                if ((int)this.PM_TARGET_ComboEditor.Value == 1)
                {
                    this._originCol_PM = COL_SUGGEST_PRICE;
                }
                else
                {
                    this._originCol_PM = COL_PURCHASE_COST;
                }

                if ((int)this.SF_TARGET_ComboEditor.Value == 1)
                {
                    this._originCol_SF = COL_SUGGEST_PRICE;
                }
                else
                {
                    this._originCol_SF = COL_TRADE_PRICE;
                }
            }

            // 共通
            this._percentage_PM = this.PM_TARGET_tNedit.GetInt();
            this._percentage_SF = this.SF_TARGET_tNedit.GetInt();

            // 金額入力分のみチェック
            if (this.CalcDiv_CheckEditor.Checked)
            {
                this._calcDiv = true;
            }
            else
            {
                this._calcDiv = false;
            }

            // 端数処理区分
            this._fracCd = Convert.ToInt32(this.Digit_ComboEditor.Value);

            return this.ShowDialog();
        }

        private const string CT_ASSEMBLYID = "SFMIT10201U";

        private const string COL_SUGGEST_PRICE = "標準価格";
        private const string COL_TRADE_PRICE = "売価";
        private const string COL_PURCHASE_COST = "仕入原価";
        private const string COL_SHOP_PRICE = "店頭価格";


        // 起動モード
        public int _bootMode;

        // 計算元カラム
        public string _originCol_SF;
        public string _originCol_PM;

        // 計算対象カラム
        public string _targetCol_SF;
        public string _targetCol_PM;


        // パーセンテージ
        public int _percentage_SF;
        public int _percentage_PM;

        // 端数処理区分
        public bool _calcDiv;

        // 端数処理区分
        public int _fracCd;

        /// <summary>
        /// SF_CheckEditor_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SF_CheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            if (this.SF_CheckEditor.Checked)
            {
                this.SF_TARGET_ComboEditor.Enabled = true;
                this.SF_TARGET_tNedit.Enabled = true;
            }
            else
            {
                this.SF_TARGET_ComboEditor.Enabled = false;
                this.SF_TARGET_tNedit.Enabled = false;
            }
        }
        /// <summary>
        /// PM_CheckEditor_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PM_CheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            if (this.PM_CheckEditor.Checked)
            {
                this.PM_TARGET_ComboEditor.Enabled = true;
                this.PM_TARGET_tNedit.Enabled = true;
            }
            else
            {
                this.PM_TARGET_ComboEditor.Enabled = false;
                this.PM_TARGET_tNedit.Enabled = false;
            }
        }



        /// <summary>
        /// 閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 計算実行ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (this._bootMode == 1)
            {
                // 部品商モード

                if (this.PM_CheckEditor.Checked)
                {
                    if (this.PM_TARGET_tNedit.GetInt() == 0)
                    {
                        // メッセージを表示
                        TMsgDisp.Show(
                           this,							        // 親ウィンドウフォーム
                           emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // エラーレベル
                           CT_ASSEMBLYID,					        // アセンブリIDまたはクラスID
                           "パーセンテージを入力して下さい。",	    // 表示するメッセージ 
                           0,								        // ステータス値
                           MessageBoxButtons.OK);
                        this.PM_TARGET_tNedit.Focus();
                        return;
                    }
                }


                if (this.SF_CheckEditor.Checked)
                {
                    if (this.SF_TARGET_tNedit.GetInt() == 0)
                    {
                        // メッセージを表示
                        TMsgDisp.Show(
                           this,							        // 親ウィンドウフォーム
                           emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // エラーレベル
                           CT_ASSEMBLYID,					        // アセンブリIDまたはクラスID
                           "パーセンテージを入力して下さい。",	    // 表示するメッセージ 
                           0,								        // ステータス値
                           MessageBoxButtons.OK);
                         this.SF_TARGET_tNedit.Focus();
                         return;
                    }
                }
              
                if (this.SF_CheckEditor.Checked == false && this.PM_CheckEditor.Checked == false)
                {
                    // メッセージを表示
                    TMsgDisp.Show(
                       this,							        // 親ウィンドウフォーム
                       emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // エラーレベル
                       CT_ASSEMBLYID,					        // アセンブリIDまたはクラスID
                       "計算対象を選択して下さい。",	        // 表示するメッセージ 
                       0,								        // ステータス値
                       MessageBoxButtons.OK);
                    this.SF_CheckEditor.Focus();
                    return;
                }

                if (this.SF_CheckEditor.Checked)
                {
                    if ((int)this.SF_TARGET_ComboEditor.Value == 1)
                    {
                        this._originCol_SF = COL_SUGGEST_PRICE;
                    }
                    else
                    {
                        this._originCol_SF = COL_TRADE_PRICE;
                    }
                    this._percentage_SF = this.SF_TARGET_tNedit.GetInt();
                }

                if (this.PM_CheckEditor.Checked)
                {
                    if ((int)this.PM_TARGET_ComboEditor.Value == 1)
                    {
                        this._originCol_PM = COL_SUGGEST_PRICE;
                    }
                    else
                    {
                        this._originCol_PM = COL_PURCHASE_COST;
                    }
                    this._percentage_PM = this.PM_TARGET_tNedit.GetInt();
                }
            }
            else
            {
                // 整備工場モード
                if (this.SF_TARGET_tNedit.GetInt() == 0)
                {
                    // メッセージを表示
                    TMsgDisp.Show(
                       this,							        // 親ウィンドウフォーム
                       emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // エラーレベル
                       CT_ASSEMBLYID,					        // アセンブリIDまたはクラスID
                       "パーセンテージを入力して下さい。",	    // 表示するメッセージ 
                       0,								        // ステータス値
                       MessageBoxButtons.OK);
                    this.SF_TARGET_tNedit.Focus();
                    return;
                }

                if ((int)this.SF_TARGET_ComboEditor.Value == 1)
                {
                    this._originCol_SF = COL_SUGGEST_PRICE;
                }
                else
                {
                    // 整備工場モードの場合は売価＝仕入原価となる為
                    this._originCol_SF = COL_TRADE_PRICE;
                }
                this._percentage_SF = this.SF_TARGET_tNedit.GetInt();
            }

            // 端数処理区分
            this._fracCd = Convert.ToInt32(this.Digit_ComboEditor.Value);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// CalcDiv_CheckEditor_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalcDiv_CheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            if(this.CalcDiv_CheckEditor.Checked)
            {
                this._calcDiv = true;
            }
            else
            {
                this._calcDiv = false;
            }
        }
    }
}