//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����_�ݒ�}�X�^���X�g �f�[�^�N���X
// �v���O�����T�v   : �����_�ݒ�}�X�^���X�g�f�[�^��ۑ�����
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/04/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using System.Windows.Forms;
using System.Data;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using System.Net.NetworkInformation;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �����_�ݒ�}�X�^���X�g �f�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �Ȃ�</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.04.01</br>
    /// </remarks>
    public class PMHAT02021EA : IExtrProc
    {
        #region �� Private Members
        private SFCMN06002C _printInfo = null;			       // ������N���X
        private OrderSetMasListPara _extraInfo = null;		   // ���o�����N���X
        private OrderSetMasListReportAcs _aControlAcs = null;
        #endregion

        #region �� Private Const Members
        private const string ct_PGID = "PMHAT02021E";
        #endregion �� private const

        #region �� �R���X�g���N�^
        /// <summary>
        /// �����_�ݒ�}�X�^���X�g ���o�N���X�R���X�g���N�^
        /// </summary>
        /// <param name="printInfo"></param>
        public PMHAT02021EA(object printInfo)
        {
            _printInfo = printInfo as SFCMN06002C;
            _extraInfo = _printInfo.jyoken as OrderSetMasListPara;
            _aControlAcs = new OrderSetMasListReportAcs();
        }
        #endregion

        #region �� IExtrProc �����o
        #region �� ���o����
        /// <summary>
        /// ���o����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����̃��C���������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.01</br>
        /// <br></br>
        /// </remarks>
        public int ExtrPrintData()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ���o����ʕ��i�̃C���X�^���X���쐬
            SFCMN00299CA form = new SFCMN00299CA();
            form.Title = "���o��";
            form.Message = "���݁A�f�[�^�𒊏o���ł��B";

            try
            {
                form.Show();                // �_�C�A���O�\��
                status = this.ExtraProc();  // ���o�������s
            }
            finally
            {
                form.Close();
                this._printInfo.status = status;
            }
            return status;
        }
        #endregion

        #region �� Public Members
        /// <summary>
        /// ������N���X�v���p�e�B
        /// </summary>
        public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }
        #endregion

        #endregion

        #region �� ���o���C������
        /// <summary>
        /// ���o���C������
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���o�̃��C���������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = string.Empty;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                if(!CheckOnlineStatus("PDF�̃f�[�^�o�͏���"))
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_OFFLINE;
                    return status;
                }

                // �f�[�^�e�[�u������A�f�[�^���������܂�
                status = this._aControlAcs.Search(this._extraInfo, out errMsg);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // ����f�[�^��ݒ菈��
                    _printInfo.rdData = this._aControlAcs.DataSet;
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
                    case (int)ConstantManagement.DB_Status.ctDB_OFFLINE:
                        {
                            break;
                        }
                    default:
                        {
                            // �X�e�[�^�X���ȏ�̂Ƃ��̓��b�Z�[�W��\��
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, errMsg, status,
                                        MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            break;
                        }
                }
            }

            return status;
        }
        #endregion

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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
        #endregion

        #region �� �I�t���C����ԃ`�F�b�N����
        /// <summary>
        /// �I�t���C���`�F�b�N���O�o�͂��鏈��
        /// </summary>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note		: �I�t���C���`�F�b�N���O�o�͂��鏈�����s���B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009.04.01</br>
        /// </remarks>
        private bool CheckOnlineStatus(String msg)
        {
            bool succFlg = true;

            // �I�t���C����ԃ`�F�b�N									
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    "�����_�ݒ�}�X�^",
                    "�����_�ݒ�}�X�^" + msg + "�����s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                succFlg = false;
            }

            return succFlg;
        }
        /// <summary>
        /// ���O�I�����I�����C����ԃ`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N��������</returns>
        /// <remarks>
        /// <br>Note		: ���O�I�����I�����C����ԃ`�F�b�N�������s���B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009.04.01</br>
        /// </remarks>
        private bool CheckOnline()
        {
            // ���[�J���G���A�ڑ���Ԃɂ��I�����C������
            if (CheckRemoteOn() == false)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// �����[�g�ڑ��\���菈��
        /// </summary>
        /// <returns>���茋��</returns>
        /// <remarks>
        /// <br>Note		: �����[�g�ڑ��\���菈�����s���B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009.04.01</br>
        /// </remarks>
        private bool CheckRemoteOn()
        {

            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // �C���^�[�l�b�g�ڑ��s�\���
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}
