//****************************************************************************//
// �V�X�e��         : �񓚑��M����
// �v���O��������   : �񓚑��M�����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ���F
// �� �� ��  2006/10/10  �C�����e : �V�K�쐬�F�s�r�o����M�����y�o�l���z(SFMIT02851A)
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/05/29  �C�����e : SCM�p�ɃA�����W
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �񓚑��M�����̐ݒ��ʃt�H�[��
    /// </summary>
    public partial class PMSCM01103AC : Form
    {
        #region <���M�f�[�^�t�H���_>

        /// <summary>SCM���M�f�[�^�t�H���_�p�X</summary>
        private string _scmDataPath;
        /// <summary>SCM���M�f�[�^�t�H���_�p�X���擾�܂��͐ݒ肵�܂��B</summary>
        public string SCMDataPath
        {
            get { return _scmDataPath; }
            set { _scmDataPath = value; }
        }

        #endregion // </���M�f�[�^�t�H���_>

        #region <�ۑ�����>

        /// <summary>�ۑ����Ԏ��</summary>
        private int _savePeriodType;
        /// <summary>�ۑ����Ԏ�ʂ��擾�܂��͐ݒ肵�܂��B</summary>
        public int SavePeriodType
        {
            get { return _savePeriodType; }
            set { _savePeriodType = value; }
        }

        #endregion // </�ۑ�����>

        #region <Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="scmDataPath">SCM���M�f�[�^�p�X</param>
        /// <param name="savePeriodType">�ۑ����Ԏ��</param>
        public PMSCM01103AC(
            string scmDataPath,
            int savePeriodType
        )
        {
            #region <Designer Code>

            InitializeComponent();

            #endregion // </Designer Code>

            _scmDataPath    = scmDataPath;
            _savePeriodType = savePeriodType;
            
            this.DialogResult = DialogResult.Cancel;
            this.txtSCMDataPath.Text = SCMDataPath;
            this.optSavePeriodType.CheckedIndex = SavePeriodType;
        }

        #endregion // </Constructor>

        /// <summary>
        /// [�m��]�{�^����Click�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            SCMDataPath     = this.txtSCMDataPath.Text;
            SavePeriodType  = this.optSavePeriodType.CheckedIndex;
            this.Close();
        }

        /// <summary>
        /// [�L�����Z��]�{�^����Click�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}