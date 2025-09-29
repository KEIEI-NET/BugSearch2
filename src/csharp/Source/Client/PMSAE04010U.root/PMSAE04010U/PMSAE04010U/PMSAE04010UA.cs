//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���M���ʕ\�� 
// �v���O�����T�v   : ���M���ʕ\�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10901034-00 �쐬�S�� : guomm
// �� �� ��  2013/06/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10901034-00  �쐬�S�� : �c����  
// �C �� ��  2013/08/07  �C�����e : Redmine#39695 ���o���ʖ����̌��ʉ�ʕ\���̕ύX�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.Misc;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���M����UI�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���M����UI�t�H�[���N���X�ł��B</br>
    /// <br>Programmer  : guomm</br>
    /// <br>Date        : 2013/06/26</br>
    /// <br>UpdateNote  : 2013/08/07 �c����</br>
    /// <br>            : Redmine#39695 ���o���ʖ����̌��ʉ�ʕ\���̕ύX�Ή�</br>
    /// </remarks>
    public partial class PMSAE04010UA : Form
    {
        #region �� Private Members ��
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton; // �I���{�^��
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel; // ���O�C���S���҃��x��
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginName; // ���O�C���S����

        private const string COL_STATUS1 = "����";
        private const string COL_STATUS2 = "���s";
        private const string COL_STATUS3 = "���M�ΏۂȂ�"; // ADD �c���� 2013/08/07 Redmine#39695
        private const string COL_ZERO = "0";
        private const string COL_FORMAT = "#,###";
        #endregion �� Private Members ��

        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���M���ʃt�H�[���N���X�ł��B</br>
        /// <br>Programmer  : guomm</br>
        /// <br>Date        : 2013/06/26</br>
        /// </remarks>
        public PMSAE04010UA()
        {
            InitializeComponent();

            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Close"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager1.Tools["LabelTool_LoginTitle"];
            this._loginName = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager1.Tools["LabelTool_LoginName"];
        }
        # endregion �� �R���X�g���N�^ ��

        #region �� �C�x���g ��
        /// <summary>
        /// PMSAE04010UA_Load�C�x���g
        /// </summary>
        /// <br>Programmer  : guomm</br>
        /// <br>Date        : 2013/06/26</br>
        private void PMSAE04010UA_Load(object sender, EventArgs e)
        {
            this.ButtonInitialSeting();
        }

        /// <summary>
        /// tToolbarsManager1_ToolClick�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Programmer  : guomm</br>
        /// <br>Date        : 2013/06/26</br>
        private void tToolbarsManager1_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // �I���{�^��
                case "ButtonTool_Close":
                    {
                        this.Close();
                        break;
                    }
            }
        }
        #endregion �� �C�x���g ��

        #region �� Public Methods ��
        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <param name="status"> ���M���� </param>
        /// <param name="time"> ���M���� </param>
        /// <param name="number"> ���M�`�[���� </param>
        /// <param name="detNum"> ���M�`�[���א� </param>
        /// <param name="sumMoney"> ���M�`�[���v���z </param>
        /// <param name="errMsg"> �G���[���b�Z�[�W </param>
        /// <remarks>
        /// <br>Note        : ��ʕ\����������B</br>
        /// <br>Programmer  : guomm</br>
        /// <br>Date        : 2013/06/26</br>
        /// <br>UpdateNote  : 2013/08/07 �c����</br>
        /// <br>            : Redmine#39695 ���o���ʖ����̌��ʉ�ʕ\���̕ύX�Ή�</br>
        /// </remarks>
        public void ShowDialog(int status, string time, int number, int detNum, Int64 sumMoney, string errMsg)
        {
            // ���M����
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                this.uLabel_Result.Text = COL_STATUS1;
            }
            //--- ADD �c���� 2013/08/07 Redmine#39695 --->>>>>
            else if (status == 2)
            {
                this.uLabel_Result.Text = COL_STATUS3;
            }
            //--- ADD �c���� 2013/08/07 Redmine#39695 ---<<<<<
            else
            {
                this.uLabel_Result.Text = COL_STATUS2;
            }

            // ���M����
            this.uLabel_Time.Text = time;

            // ���M�`�[����
            if (number != 0)
            {
                this.ultraLabel_Num.Text = number.ToString(COL_FORMAT);
            }
            else
            {
                this.ultraLabel_Num.Text = COL_ZERO;
            }

            // ���M�`�[���א�
            if (detNum != 0)
            {
                this.ultraLabel_DetNum.Text = detNum.ToString(COL_FORMAT);
            }
            else
            {
                this.ultraLabel_DetNum.Text = COL_ZERO;
            }

            // ���M�`�[���v���z
            if (sumMoney != 0)
            {
                this.ultraLabel_Sum.Text = sumMoney.ToString(COL_FORMAT);
            }
            else
            {
                this.ultraLabel_Sum.Text = COL_ZERO;
            }

            // ��ʕ\��
            this.ShowDialog();
        }
        #endregion �� Public Methods ��

        #region �� Private Methods ��
        /// <summary>
        /// �{�^�������ݒ�
        /// </summary>
        /// <br>Note        : �{�^�������ݒ肷��B</br>
        /// <br>Programmer  : guomm</br>
        /// <br>Date        : 2013/06/26</br>
        private void ButtonInitialSeting()
        {
            this.tToolbarsManager1.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            this._loginName.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
        }
        #endregion �� Private Methods ��
    }
}