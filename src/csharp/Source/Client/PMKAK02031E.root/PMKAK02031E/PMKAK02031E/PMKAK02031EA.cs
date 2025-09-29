//***************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �d���ԕi�\��ꗗ�\
// �v���O�����T�v   : �d���ԕi�\��ꗗ�\ ���o�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : FSI���� ����
// �� �� ��   2013/01/28 �C�����e : �V�K�쐬 �d���ԕi�\��@�\�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �d���ԕi�\��ꗗ�\���o�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���ԕi�\��ꗗ�\UI�t�H�[���N���X</br>
    /// <br>Programmer : FSI���� ����</br>
    /// <br>Date       :  2013/01/28</br>
    /// </remarks>
    public class PMKAK02031EA : IExtrProc
    {
        //================================================================================
        //  �R���X�g���N�^�[
        //================================================================================
        #region �R���X�g���N�^�[
        /// <summary>
        /// �d���ԕi�\��ꗗ�\���o�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d���ԕi�\��ꗗ�\UI�N���X</br>
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        /// <br></br>
        /// </remarks>
        public PMKAK02031EA()
        {
        }

        /// <summary>
        /// �d���ԕi�\��ꗗ�\���o�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d���ԕi�\��ꗗ�\UI�N���X</br>
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        /// <br></br>
        /// </remarks>
        public PMKAK02031EA(object printInfo)
        {
            this._printInfo = printInfo as SFCMN06002C;
			this._extraInfo = this._printInfo.jyoken as ExtrInfo_PMKAK02034E;
            this._salesTableListAcs = new PMKAK02032A();
        }
        #endregion

        //================================================================================
        //  �����ϐ�
        //================================================================================
        #region private member
        private SFCMN06002C _printInfo = null;

        private PMKAK02032A _salesTableListAcs = null;        // �d���ԕi�\��ꗗ�\�A�N�Z�X�N���X
		private ExtrInfo_PMKAK02034E _extraInfo = null;            // ���o�����N���X

		private string _PGID = "PMKAK02031EA";

        #endregion

        // ===============================================================================
        // IExtrProc ������
        // ===============================================================================
        #region IExtrProc �����o

        /// <summary> ������N���X�v���p�e�B </summary>
        public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }

        /// <summary>
        /// ���o����
        /// </summary>
        public int ExtrPrintData()
        {
            int status = (int)Broadleaf.Library.Resources.ConstantManagement.MethodResult.ctFNC_ERROR;

            // ���o����ʃC���X�^���X�쐬
            Broadleaf.Windows.Forms.SFCMN00299CA pd = new Broadleaf.Windows.Forms.SFCMN00299CA();
            pd.Title = "���o��";
            pd.Message = "���݁A�f�[�^���o���ł��B";

            try
            {
                pd.Show();
                status = this.ExtraProc();
            }
            finally
            {
                pd.Close();
                this._printInfo.status = status;
            }

            return status;
        }
        #endregion

        // ===============================================================================
        // �����g�p�֐�
        // ===============================================================================
        #region private methods
        /// <summary>
        /// ���o���C������
        /// </summary>
        private int ExtraProc()
        {
            int result = (int)Broadleaf.Library.Resources.ConstantManagement.MethodResult.ctFNC_ERROR;
            int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
            string message = "";

            try
            {
                status = this._salesTableListAcs.Search(this._extraInfo, out message, 0);
                if (status == 0)
                {
                    this._printInfo.rdData = this._salesTableListAcs._printDataSet;
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, status,
                    MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                // �߂�l��ݒ�B�ُ�̏ꍇ�̓��b�Z�[�W��\��
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            result = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            result = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, this._PGID, message, status,
                                        MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            result = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                            break;
                        }
                }
            }
            return result;
        }

        #endregion


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
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "�d���ԕi�\��ꗗ�\���o����", iMsg, iSt, iButton, iDefButton);
        }
    }
}
