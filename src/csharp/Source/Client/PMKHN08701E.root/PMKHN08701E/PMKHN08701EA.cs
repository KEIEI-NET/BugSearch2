//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[���}�X�^���
// �v���O�����T�v   : ���o���ʂ��o�͌��ʃC���[�W�\���E�o�c�e�o�́E������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �� �� ��  2011/04/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Application.UIData
{

    /// <summary>
    /// �L�����y�[���}�X�^�i����j�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���}�X�^�i����jUI�t�H�[���N���X</br>
    /// <br>Programmer : liyp</br>
    /// <br>Date       : 2011/04/25</br>
    /// <br></br>
    /// <br>UpdateNote : </br>
    /// <br>           : </br>
    /// </remarks>
    public class PMKHN08701EA : IExtrProc
    {
        #region �� Constructor
        /// <summary>
        /// �L�����y�[���}�X�^�i����j�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^�i����jUI�N���X</br>
        /// <br>Programmer : liyp</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br></br>
        /// </remarks>
        public PMKHN08701EA(object printInfo)
        {
            // ������
            this._printInfo = printInfo as SFCMN06002C;
        }
        #endregion �� Constructor

        #region �� private member
        private SFCMN06002C _printInfo = null;			                    // ������N���X
        #endregion �� private member

        #region �� private const
        private const string ct_PGID = "PMKHN08701E";
        #endregion �� private const


        #region �� IExtrProc �����o
        #region �� Public Property
        /// <summary>
        /// ������N���X�v���p�e�B
        /// </summary>
        public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }
        #endregion �� Public Property

        #region �� Public Method
        #region �� ���o����
        /// <summary>
        /// ���o����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ����̃��C���������s���܂��B</br>
        /// <br>Programmer : liyp</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int ExtrPrintData()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // ���o����ʕ��i�̃C���X�^���X���쐬
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // �\��������ݒ�
            form.Title = "���o��";
            form.Message = "���݁A�f�[�^�𒊏o���ł��B";

            try
            {
                form.Show();			    // �_�C�A���O�\��
                status = this.ExtraProc();	// ���o�������s
            }
            finally
            {
                // �_�C�A���O�����
                form.Close();
                this._printInfo.status = status;
            }

            return status;
        }
        #endregion
        #endregion �� Public Method
        #endregion �� IExtrProc �����o

        #region �� Private Method
        #region �� ���o���C������
        /// <summary>
        /// ���o���C������
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���o�̃��C���������s���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int ExtraProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if ((this._printInfo.rdData as DataView).Count == 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            return status;
        }
        #endregion �� ���o���C������

        #region �� �G���[���b�Z�[�W�\��
        /// <summary>
        /// �G���[���b�Z�[�W�\��
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="iMsg">�G���[���b�Z�[�W</param>
        /// <param name="iSt">�G���[�X�e�[�^�X</param>
        /// <param name="iButton">�\���{�^��</param>
        /// <param name="iDefButton">�����t�H�[�J�X�{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W��\�����܂��B</br>
        /// <br>Programmer : liyp</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
        #endregion �� �G���[���b�Z�[�W�\��
        #endregion
    }
}
