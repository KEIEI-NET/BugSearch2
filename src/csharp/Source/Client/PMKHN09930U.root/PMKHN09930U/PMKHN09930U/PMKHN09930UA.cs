using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 掛率優先設定自動登録　メインクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 掛率優先設定自動登録UIクラスを表示します。</br>
    /// <br>Programmer  : Miwa Honda</br>
    /// <br>Date        : 2013/11/06</br>
    /// <br>UpDate        : 2014.09.19 Miwa Honda　サポートの管理拠点(1)がないときエラー</br>
    /// </remarks>
    public partial class PMKHN09930UA : Form
    {
        public PMKHN09930UA()
        {
            InitializeComponent();
        }

        private RateProtyMngConvertClass _convertClass;

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面がLoadされた時に発生します。</br>
        /// </remarks>
        private void PMKHN09930UA_Load(object sender, EventArgs e)
        {
            try
            {
                // 従業員
               Employee employee = LoginInfoAcquisition.Employee;
                string belongSectionName = employee.BelongSectionName;

                // 拠点情報取得
                SecInfoAcs secInfoAcs = new SecInfoAcs();


                this._convertClass = new RateProtyMngConvertClass();
                _convertClass.SecInfoSetList = secInfoAcs.SecInfoSetList;

                // 拠点コンボボックス
                this.UtilityDiv_tComboEditor.Items.Clear();
                this.UtilityDiv_tComboEditor.Items.Add(RateProtyMngCnvConst.ALL_SECTION_CODE, RateProtyMngCnvConst.ALL_MODE);
                this.UtilityDiv_tComboEditor.Items.Add(RateProtyMngCnvConst.COM_SECTION_CODE, RateProtyMngCnvConst.COMMON_MODE);
                foreach (SecInfoSet secInfoSet in _convertClass.SecInfoSetList)
                {
                    this.UtilityDiv_tComboEditor.Items.Add(secInfoSet.SectionCode.Trim().PadLeft(2, '0'), secInfoSet.SectionGuideNm);
                }

                // 全社共通を設定する　　
                this.UtilityDiv_tComboEditor.Value = RateProtyMngCnvConst.ALL_SECTION_CODE;　// 2014.09.19 add honda
                // 自拠点を初期表示する
                //this.UtilityDiv_tComboEditor.Value = employee.BelongSectionCode.Trim().PadLeft(2, '0'); // 2014.09.19 del honda
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 登録ボタン　クリックイベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面がLoadされた時に発生します。</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            // コンボボックス未設定の場合
            // 2014.09.19 add honda sta ---
            if (this.UtilityDiv_tComboEditor.Value == null)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "拠点を選択してください。\r\n" ,0, MessageBoxButtons.OK);
                return;         
            }
            // 2014.09.19 add honda sta ---

            //処理開始
            this._convertClass.SectionCode = this.UtilityDiv_tComboEditor.Value.ToString().Trim();
            if (this._convertClass.SectionCode == RateProtyMngCnvConst.ALL_SECTION_CODE)
                this._convertClass.SelectAllSecFlg = true;
            else
                this._convertClass.SelectAllSecFlg = false;

            this._convertClass.Confirmation_checkBox = Confirmation_checkBox.Checked;

            int status = this._convertClass.StartProc(this);

            this.UtilityDiv_tComboEditor.Dispose();
            Close();

            return;

        }

        /// <summary>
        /// 終了ボタン　クリックイベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面がLoadされた時に発生します。</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// ValueChanged イベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: 拠点を変更した場合に発生します。</br>
        /// </remarks>
        private void UtilityDiv_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            if (this.UtilityDiv_tComboEditor.Value == null) return;   // 2014.09.19 add honda 

            if (UtilityDiv_tComboEditor.Value.ToString() == "")
                Warning_label.Text = "※抽出に時間がかかる場合があります。";
            else
                Warning_label.Text = "";
        }

        /// <summary>
        /// ValueChanged イベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: チェックが変更した場合に発生します。</br>
        /// </remarks>
        private void Confirmation_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Confirmation_checkBox.Checked)
            {
                Ok_Button.Text = "画面表示(&S)";
            }
            else
            {
                Ok_Button.Text = "登録(&S)";

            }
        }
    }
}