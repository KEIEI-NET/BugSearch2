//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R�����^���}�X�^�t�H�[���N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10602352-00 �쐬�S�� : �я���
// �� �� ��  2010/04/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���R�����^���}�X�^�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R�����^���}�X�^�̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : �я���</br>
    /// <br>Date       : 2010.04.26</br>
    /// <br></br>
    public partial class PMJKN09000UA : Form
    {
        # region �R���X�g���N�^
        /// <summary>
        /// ���R�����^���}�X�^�t�H�[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���R�����^���}�X�^�����̃R���X�g���N�^�ł��B</br>      
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/26</br>
        /// </remarks>
        public PMJKN09000UA()
        {
            InitializeComponent();
        }

        # endregion

        # region private Member
        /// <summary>���R�����^���}�X�^�t�H�[���N���X</summary>             
        /// <remarks>�Ȃ�</remarks>�@
        PMJKN09001UA _mPMJKN09001UAForm;
        # endregion

        # region �C�x���g
        /// <summary>
        /// ���[�h�C�x���g                                            
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                            
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ��ʂ����[�h���ɔ������܂��B</br>      
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/26</br>
        /// </remarks>
        private void PMJKN09000UA_Load(object sender, EventArgs e)
        {

            this._mPMJKN09001UAForm = new PMJKN09001UA();

            this._mPMJKN09001UAForm.TopLevel = false;
            this._mPMJKN09001UAForm.FormBorderStyle = FormBorderStyle.None;
            this._mPMJKN09001UAForm.Show();
            this._mPMJKN09001UAForm.Dock = DockStyle.Fill;
            this.Text = this._mPMJKN09001UAForm.Text;
            this.Controls.Add(this._mPMJKN09001UAForm);

            this._mPMJKN09001UAForm.FormClosed += new FormClosedEventHandler(this.PMJKN09000UA_FormClosed);
        }

        /// <summary>
        /// ����C�x���g                                        
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                           
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ��ʂ����鎞�ɔ������܂��B</br>      
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/26</br>
        /// </remarks>
        private void PMJKN09000UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        # endregion

    }
}