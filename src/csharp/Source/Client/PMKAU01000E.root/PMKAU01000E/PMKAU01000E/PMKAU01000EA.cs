//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R���[�i�������j���o�N���X�N���X
// �v���O�����T�v   : ���R���[�i�������j���o�N���X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2022 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570183-00  �쐬�S�� : ���O
// �� �� ��  2022/03/07   �C�����e : ���������s(�d�q����A�g)�V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using System.Data;

namespace Broadleaf.Application.UIData
{

    /// <summary>
    /// ���R���[�i�������j���o�N���X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note         : ���R���[�i�������jUI�t�H�[���N���X</br>
    /// <br>Programmer   : ���O</br>
    /// <br>Date         : 2022/03/07</br>
    /// </remarks>
    public class PMKAU01000EA : IExtrProc
    {
        #region [private �t�B�[���h]
        private SFCMN06002C _printInfo = null;      // ������N���X
        private EBooksFrePBillAcs _frePBillAcs = null;    // ���R���[�i�������j�A�N�Z�X�N���X
        #endregion

        #region [private const �t�B�[���h]
        /// <summary>�v���O����ID (�A�Z���u����)</summary>
        private const string ct_PGID = "PMKAU01000E";
        #endregion

        #region [�R���X�g���N�^]
        /// <summary>
        /// ���R���[�i�������j���o�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���R���[�i�������jUI�N���X</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2022/03/07</br>
        /// <br></br>
        /// </remarks>
        public PMKAU01000EA(object printInfo)
        {
            // ������
            this._printInfo = printInfo as SFCMN06002C;
            this._frePBillAcs = new EBooksFrePBillAcs();
        }
        #endregion

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
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2022/03/07</br>
        /// </remarks>
        public int ExtrPrintData()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            try
            {
                status = this.ExtraProc();	// ���o�������s
            }
            finally
            {
                this._printInfo.status = status;
            }

            return status;
        }
        /// <summary>
        /// ���o�L�����Z������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���o�L�����Z�������B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2022/03/07</br>
        /// </remarks>
        public void Cancel()
        {
            // �A�N�Z�X�N���X�̒��o�L�����Z���������Ăяo��
            this._frePBillAcs.CancelButtonClick(this, new EventArgs());
        }
        #endregion
        #endregion �� Public Method
        #endregion �� IExtrProc �����o

        #region �� Private Method
        #region �� ���o���C������
        /// <summary>
        /// ���o���C������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note         : ���o�̃��C���������s���܂��B</br>
        /// <br>Programmer   : ���O</br>
        /// <br>Date         : 2022/03/07</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // Todo:Search Method Call
                status = this._frePBillAcs.SearchMain(this._printInfo.jyoken, (DataView)this._printInfo.rdData, out errMsg);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // ����f�[�^�擾
                    this._printInfo.rdData = this._frePBillAcs.PrintDataSet;
                }
            }
            catch (Exception ex)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                // �߂�l��ݒ�B�ُ�̏ꍇ�̓��b�Z�[�W��\��
                switch (status)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                        {
                            break;
                        }
                    default:
                        {
                            Form form = new Form();
                            form.TopMost = true;
                            // �X�e�[�^�X���ȏ�̂Ƃ��̓��b�Z�[�W��\��
                            TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, errMsg, status,
                                        MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            form.TopMost = false;
                            break;
                        }
                }
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
        /// <br>Note         : �G���[���b�Z�[�W��\�����܂��B</br>
        /// <br>Programmer   : ���O</br>
        /// <br>Date         : 2022/03/07</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            Form form = new Form();
            form.TopMost = true;
            DialogResult rst = TMsgDisp.Show(form, iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
            form.TopMost = false;
            return rst;
        }
        #endregion �� �G���[���b�Z�[�W�\��
        #endregion
    }
}
