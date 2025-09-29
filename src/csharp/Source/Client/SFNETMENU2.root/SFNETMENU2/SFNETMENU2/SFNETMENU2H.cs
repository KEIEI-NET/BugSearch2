using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Broadleaf.Library.Resources;


namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// パスワード入力画面クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : パスワード入力画面クラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    public partial class SFNETMENU2H : Form
    {

        /// <summary>
        /// パスワード入力画面コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       :パスワード入力画面コンストラクタ</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.09.04</br>
        /// </remarks>
        public SFNETMENU2H()
        {
            InitializeComponent();
        }

        //private bool bShowing;
        /// <summary>
        /// 入力パスワード
        /// </summary>
        public string Password;
        //private ScreenThemeInfomation _mScreenThemeInfomation;

        /// <summary>
        /// パスワード入力表示制御処理
        /// </summary>
        /// <param name="PasswordType">パスワードタイプ</param>
        /// <param name="sif">画面色情報</param>
        /// <returns>ダイアログ結果</returns>
        /// <remarks>
        /// <br>Note       :パスワード入力表示制御</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public DialogResult ShowPasswordSetting(int PasswordType, string PassKey, ScreenInfomation si)
        {

            //bShowing = true;

            btnSave.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.Decision];
            btnCancel.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.Back];
            btnSave.ForeColor = si.ToolBarForeColor;
            btnCancel.ForeColor = si.ToolBarForeColor;

            CustomProfessionalRenderer cpr = new CustomProfessionalRenderer();
            try
            {
                cpr._ToolStripGradientBegin = si.ToolBarColor.ToolStripGradientBegin;
                cpr._ToolStripGradientMiddle = si.ToolBarColor.ToolStripGradientMiddle;
                cpr._ToolStripGradientEnd = si.ToolBarColor.ToolStripGradientEnd;
                cpr._ToolStripPanelGradientBegin = si.ToolBarColor.ToolStripPanelGradientBegin;
                cpr._ToolStripPanelGradientEnd = si.ToolBarColor.ToolStripPanelGradientEnd;
            }
            catch (Exception)
            {
                cpr._ToolStripGradientBegin = Color.LightBlue;
                cpr._ToolStripGradientMiddle = Color.WhiteSmoke;
                cpr._ToolStripGradientEnd = Color.LightSkyBlue;
                cpr._ToolStripPanelGradientBegin = Color.LightSkyBlue;
                cpr._ToolStripPanelGradientEnd = Color.LightSkyBlue;
            }
            barSub.Renderer = new ToolStripProfessionalRenderer(cpr);

            BackColor = si.ScreenBackColor;

            if ((PasswordType % 10)  == 1)
            {
                lblMessage.ForeColor = Color.Red;
                lblPassKey1.Visible = true;
                lblPasskey2.Text = "パスキー ： " + PassKey;
                lblPasskey2.Visible = true;

            }
            else
            {
                lblMessage.ForeColor = Color.Black;
                lblPassKey1.Visible = false;
                lblPasskey2.Visible = false;
            }


            txtPassword.Text = "";

            //bShowing = false;

            return ShowDialog();

        }

        /// <summary>
        /// 確定ボタン押下時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length == 0)
            {
//                SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelInfo, "Password", "入力エラー", "パスワードを入力してください。", "");
                Password = "*_*";
//                return;
            }
            Password = txtPassword.Text;


            DialogResult = DialogResult.OK;
            Close();

        }

        /// <summary>
        /// 戻るボタン押下時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }


    }
}