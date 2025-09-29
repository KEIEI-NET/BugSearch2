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
    /// �J�X�^���e�[�}�쐬��ʃN���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �J�X�^���e�[�}�쐬��ʃN���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    public partial class SFNETMENU2F : Form
    {

        /// <summary>
        /// �J�X�^���e�[�}�쐬��ʃR���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       :�J�X�^���e�[�}�쐬��ʃR���X�g���N�^</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.09.04</br>
        /// </remarks>
        public SFNETMENU2F()
        {
            InitializeComponent();
        }

        //private bool bShowing;
        public string CustonName;
        public Guid ThemeID;
        private ScreenThemeInfomation _mScreenThemeInfomation;

        /// <summary>
        /// �J�X�^���e�[�}�쐬�\�����䏈��
        /// </summary>
        /// <param name="stif">��ʃe�[�}���</param>
        /// <param name="sif">��ʐF���</param>
        /// <returns>�_�C�A���O����</returns>
        /// <remarks>
        /// <br>Note       :�J�X�^���e�[�}�쐬�\������</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public DialogResult ShowCustomColorSetting(ScreenThemeInfomation stif, ScreenInfomation si)
        {

            //bShowing = true;

            _mScreenThemeInfomation = stif;

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

            cmbOriginalTheme.Items.Clear();
            cmbOriginalTheme.SelectedIndex = -1;
            for (int i = 0; i < stif.ThemeFig; i++)
            {
                cmbOriginalTheme.Items.Add(((ScreenInfomation)stif.SceenTehme[i]).ThemeName);
            }
            CustonName = "";
            ThemeID = Guid.Empty;

            //bShowing = false;

            return ShowDialog();

        }

        /// <summary>
        /// �m��{�^�������������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtThemaName.Text.Length == 0)
            {
                SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelInfo, "Option", "�I���G���[", "�e�[�}����ݒ肵�Ă��������B", "");
                return;
            }
            CustonName = txtThemaName.Text;

            if (cmbOriginalTheme.SelectedIndex != -1)
            {
                ThemeID = ((ScreenInfomation)_mScreenThemeInfomation.SceenTehme[cmbOriginalTheme.SelectedIndex]).ThemeID;
            }

            DialogResult = DialogResult.OK;
            Close();

        }

        /// <summary>
        /// �߂�{�^�������������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }


    }
}