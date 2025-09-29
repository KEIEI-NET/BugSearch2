using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.Misc;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 
    /// </summary>
    public class GridFormBase : Form
	{
        // ===================================================================================== //
        // �v���e�N�e�B�b�h�萔
        // ===================================================================================== //
        #region protected constant
        //���R���[�O���[�v�p
        /// <summary>�쐬���t</summary>
        protected const string CT_FREE_PPR_CRDT = "CREATE_DATETIME";   //�쐬���t
        /// <summary>�X�V���t</summary>
        protected const string CT_FREE_PPR_UPDT = "UPDATE_DATETIME";   //�X�V���t
        /// <summary>GUID</summary>
        protected const string CT_FREE_PPR_GUID = "FileHeaderGuid";    //GUID
        /// <summary>�e�[�u���^�C�g��</summary>
        protected const string CT_FREE_PPR_GR = "FREE_SHEET_GR";     //�e�[�u���^�C�g��
        /// <summary>�O���[�v����</summary>
        protected const string CT_FREE_PPR_GrNm = "�O���[�v����";      //�O���[�v����
        /// <summary>�O���[�v�R�[�h</summary>
        protected const string CT_FREE_PPR_GrCd = "�O���[�v�R�[�h";    //�O���[�v�R�[�h
        
        //���R���[����Ώۗp
        /// <summary>�e�[�u���^�C�g��</summary>
        protected const string CT_FREE_PPR_PRT = "FREE_SHEET_PRT";       //�e�[�u���^�C�g��
        /// <summary>�U�փR�[�h</summary>
        protected const string CT_FREE_PPR_TrsCd = "TransferCode";       //�U�փR�[�h
        /// <summary>�\������</summary>
        protected const string CT_FREE_PPR_DspOdr = "�\������";          //�\������
        /// <summary>�o�͖���</summary>
        protected const string CT_FREE_PPR_PrtNm = "���[����";       //�o�͖���
        /// <summary>�o�̓t�@�C����</summary>
        protected const string CT_FREE_PPR_OFrmFilNm = "OutPutFrmFilNm"; //�o�̓t�@�C����
        /// <summary>���[�U�[���[ID�}�ԍ�</summary>
        protected const string CT_FREE_PPR_DerivNo = "UPrtPprIDDerivNo"; //���[�U�[���[ID�}�ԍ�
        /// <summary>�ŏI�������</summary>
        protected const string CT_FREE_PPR_LstPrtDt = "�ŏI�������";    //�ŏI�������
        /// <summary>���[�U�[�R�����g</summary>
        protected const string CT_FREE_PPR_USRComment = "�R�����g";      //���[�U�[�R�����g

        //���[�I��
        /// <summary>�e�[�u���^�C�g��</summary>
        protected const string CT_FREE_PPR_SLCT = "FREE_PPR_SLCT";       //�e�[�u���^�C�g��

        //����
        /// <summary>RowADD</summary>
        protected const string CT_ROW_ADD = "RowADD";
        /// <summary>RowDelete</summary>
        protected const string CT_ROW_DELETE = "RowDelete";
        /// <summary>SFANL08201U</summary>
        protected const string PGID = "SFANL08201U";
        #endregion

        // ===================================================================================== //
        // �����g�p�֐�
        // ===================================================================================== //
        #region protected methods

        #region ��ʏ����ݒ�

        #region �c�[���o�[�̐ݒ�
        /// <summary>
        /// �c�[���o�[�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note		:	�c�[���o�[�̐ݒ���s���܂��B</br>
        /// <br>Programmer	:	22011 �����@���l</br>
        /// <br>Date		:	2007.03.26</br>
        /// </remarks>
        protected void SetToolbarAppearance(UltraToolbarsManager ultraToolbarsManager)
        {
            // �c�[���o�[�ɃA�C�R���ݒ�
            ultraToolbarsManager.ImageListSmall = IconResourceManagement.ImageList24;

            // �ǉ��ւ̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool selectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)ultraToolbarsManager.Tools[CT_ROW_ADD];
            if (selectButton != null) selectButton.SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.ROWINSERT;

            // �폜�ւ̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)ultraToolbarsManager.Tools[CT_ROW_DELETE];
            if (closeButton != null) closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.DELETE;

            // �c�[���o�[���J�X�^�}�C�Y�s�ɂ���
            ultraToolbarsManager.ToolbarSettings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbarsManager.ToolbarSettings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbarsManager.ToolbarSettings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbarsManager.ToolbarSettings.AllowDockRight = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbarsManager.ToolbarSettings.AllowDockTop = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbarsManager.ToolbarSettings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbarsManager.ToolbarSettings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
        }
        #endregion

        #region UltraGrid��UI�ݒ��ύX���郁�\�b�h
        /// <summary>
        /// UltraGrid�̔z�F���d�l�ʂ�ɐݒ肷��
        /// </summary>
        /// <param name="ugTarget"></param>
        protected void setGridAppearance(Infragistics.Win.UltraWinGrid.UltraGrid ugTarget)
        {
            //�^�C�g���̊O��
            ugTarget.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            ugTarget.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            ugTarget.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            ugTarget.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            ugTarget.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;

            //�w�i�F��ݒ�
            ugTarget.DisplayLayout.Appearance.BackColor = Color.White;

            //�������J�����ɓ���悤�ɐݒ肷��
            ugTarget.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

            //�s�Z���N�^�̐ݒ�
            ugTarget.DisplayLayout.Override.RowSelectorAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            ugTarget.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
            ugTarget.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            ugTarget.DisplayLayout.Override.RowSelectorAppearance.ForeColor = Color.White;

            //�C���W�Q�[�^��\��
            ugTarget.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;

            //�����̈��\��
            ugTarget.DisplayLayout.MaxColScrollRegions = 1;
            ugTarget.DisplayLayout.MaxRowScrollRegions = 1;

            //���݂ɍs�̐F��ς���
            ugTarget.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.FromArgb(192, 192, 255);

            //�����X�N���[���o�[�̂݋���
            ugTarget.DisplayLayout.Scrollbars = Scrollbars.Vertical;

            //�A�N�e�B�u�s�̊O�ς�ς���
            ugTarget.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Black;
            ugTarget.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
            ugTarget.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
            ugTarget.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            //�ŏI�s����ԏ�܂ł����Ȃ��悤�ɂ���
            ugTarget.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
        }


        /// <summary>
        /// UltraGrid�̋�����ݒ肷��
        /// </summary>
        /// <param name="ugTarget"></param>
        protected void setGridBehavior(Infragistics.Win.UltraWinGrid.UltraGrid ugTarget)
        {
            //�񕝂̎�������
            ugTarget.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

            //�s�̒ǉ��s��
            ugTarget.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;

            //�s�̍폜�s��
            ugTarget.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;

            // ��̈ړ��s��
            ugTarget.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;

            // ��̌����s��
            ugTarget.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;

            // �t�B���^�̎g�p�s��
            ugTarget.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            //�I����@���s�I���ɐݒ�B
            ugTarget.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;

            //+��I��s�ɂ��邱�ƂŃw�b�_���N���b�N���Ă������N����Ȃ�
            ugTarget.DisplayLayout.Override.SelectTypeCol = SelectType.None;

            //��s�̂ݑI���\�ɂ���
            ugTarget.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;

            //�X�N���[�����ɂ����܂ǂ��������Ă����ԂȂ̂����킩��悤�ɂ���
            ugTarget.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;

            //IME����
            ugTarget.ImeMode = ImeMode.Disable;

            //�h���b�O���Ă����̃A�C�e���Ɉړ����Ȃ��悤�ɂ���
            ugTarget.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;

        }
        #endregion

        #region �r�����䏈��
        /// <summary>
        ///	�r�����䏈��
        /// </summary>
        /// <remarks>
        /// <br>Programmer		:	22011 ���� ���l</br>
        /// <br>Note            :   �c�a�ɔr�����䂪�|�����Ă����ۂɃ��b�Z�[�W��\����UI��ʂ����</br>
        /// <br>Date			:	2007.04.13</br>
        /// </remarks>
        protected bool ExclusiveControl(int Status)
        {
            // ���ɍX�V���|�����Ă����Ƃ�
            if (Status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
            {
                TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    PGID, "���ɑ��[�����X�V����Ă��܂�", 0, MessageBoxButtons.OK);
                return false;
            }
            // ���ɍ폜����Ă����Ƃ�
            if (Status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
            {
                TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    PGID, "���ɑ��[���ō폜����Ă��܂�", 0, MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
        #endregion

        #endregion

        #endregion

    }
}
