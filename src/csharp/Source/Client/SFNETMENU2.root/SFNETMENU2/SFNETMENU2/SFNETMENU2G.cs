using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
//using System.Collections.Generic;
using Broadleaf.Library.Resources;


namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// カスタムテーマ名設定画面クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : カスタムテーマ名設定画面クラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    public partial class SFNETMENU2G : Form
    {

        /// <summary>
        /// カスタムテーマ名設定画面コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       :カスタムテーマ名設定画面コンストラクタ</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.09.04</br>
        /// </remarks>
        public SFNETMENU2G()
        {
            InitializeComponent();
        }

        //private bool bShowing;
        /// <summary>
        /// カスタムテーマ
        /// </summary>
        public string CustonName;
        //private ScreenThemeInfomation _mScreenThemeInfomation;

        /// <summary>
        /// カスタムテーマ名設定表示制御処理
        /// </summary>
        /// <param name="iCustomName">カスタムテーマ</param>
        /// <param name="sif">画面色情報</param>
        /// <returns>ダイアログ結果</returns>
        /// <remarks>
        /// <br>Note       :カスタムテーマ名設定表示制御</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public DialogResult ShowCustomNameSetting(string iCustomName, ScreenInfomation si)
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

            txtThemaName.Text = iCustomName;

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
            if (txtThemaName.Text.Length == 0)
            {
                SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelInfo, "Option", "選択エラー", "テーマ名を設定してください。", "");
                return;
            }
            CustonName = txtThemaName.Text;


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