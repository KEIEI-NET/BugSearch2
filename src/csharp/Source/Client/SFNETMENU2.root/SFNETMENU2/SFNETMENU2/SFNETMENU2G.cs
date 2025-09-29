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
    /// �J�X�^���e�[�}���ݒ��ʃN���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �J�X�^���e�[�}���ݒ��ʃN���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    public partial class SFNETMENU2G : Form
    {

        /// <summary>
        /// �J�X�^���e�[�}���ݒ��ʃR���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       :�J�X�^���e�[�}���ݒ��ʃR���X�g���N�^</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.09.04</br>
        /// </remarks>
        public SFNETMENU2G()
        {
            InitializeComponent();
        }

        //private bool bShowing;
        /// <summary>
        /// �J�X�^���e�[�}
        /// </summary>
        public string CustonName;
        //private ScreenThemeInfomation _mScreenThemeInfomation;

        /// <summary>
        /// �J�X�^���e�[�}���ݒ�\�����䏈��
        /// </summary>
        /// <param name="iCustomName">�J�X�^���e�[�}</param>
        /// <param name="sif">��ʐF���</param>
        /// <returns>�_�C�A���O����</returns>
        /// <remarks>
        /// <br>Note       :�J�X�^���e�[�}���ݒ�\������</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
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