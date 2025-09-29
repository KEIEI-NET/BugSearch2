//****************************************************************************//
// �V�X�e��         : ���M�O���X�g
// �v���O��������   : ���M�O���X�g�f�[�^�N���X
// �v���O�����T�v   : ���M�O���X�g�f�[�^�N���X���������܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/09/11  �C�����e : MAHNB02011E�F�����m�F�\���Q�l�ɐV�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ���M�O���X�g���o�N���X
    /// </summary>
    public sealed class PMUOE02032EA : IExtrProc
    {
        #region <IExtrProc �����o/>

        #region <������/>

        /// <summary>������</summary>
        private SFCMN06002C _printInfo;
        /// <summary>
        /// ������̃A�N�Z�T
        /// </summary>
        /// <value>������</value>
        public SFCMN06002C Printinfo
        {
            get { return _printInfo; }
            set { _printInfo = value; }
        }

        #endregion  // <������/>

        #region <���o����/>

        /// <summary>
        /// ���o�������s���܂��B
        /// </summary>
        /// <returns>���ʃR�[�h</returns>
        public int ExtrPrintData()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ���o����ʕ��i�𐶐�
            Broadleaf.Windows.Forms.SFCMN00299CA extractingForm = new Broadleaf.Windows.Forms.SFCMN00299CA();
            {
                // �\��������ݒ�
                extractingForm.Title    = "���o��";                     // LITERAL:
                extractingForm.Message  = "���݁A�f�[�^�𒊏o���ł��B"; // LITERAL:
            }
            try
            {
                extractingForm.Show();  // �_�C�A���O�\��
                status = ExtraProc();   // ���o�������s
            }
            finally
            {
                // �_�C�A���O�����
                extractingForm.Close();
                Printinfo.status = status;
            }

            return status;
        }

        /// <summary>
        /// ���o�������s���܂��B
        /// </summary>
        /// <returns>���ʃR�[�h</returns>
        private int ExtraProc()
        {
            const string PG_ID = "PMUOE02032E"; // HACK:�v���O����ID

            string errMsg = string.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                status = SendBeforeAcs.SearchSendBeforeList(ExtraInfo, out errMsg);
                if (status.Equals((int)ConstantManagement.MethodResult.ctFNC_NORMAL))
                {
                    // ����f�[�^��������ɐݒ�
                    Printinfo.rdData = SendBeforeAcs.SearchedResult;
                }
            }
            catch (Exception e)
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    PG_ID,
                    e.Message,
                    status,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1
                );
            }
            finally
            {
                // �߂�l��ݒ�B�ُ�̏ꍇ�̓��b�Z�[�W��\��
                switch (status)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                        break;

                    default:
                    {
                        // �X�e�[�^�X���ȏ�̂Ƃ��̓��b�Z�[�W��\��
                        TMsgDisp.Show(
                            emErrorLevel.ERR_LEVEL_STOPDISP,
                            PG_ID,
                            errMsg,
                            status,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1
                        );
                        break;
                    }
                }
            }

            return status;
        }

        #endregion  // <���o����/>

        #endregion  // <IExtrProc �����o/>

        #region <���o����/>

        /// <summary>���o����</summary>
        private readonly SendBeforeOrderCondition _extraInfo;
        /// <summary>
        /// ���o�������擾���܂��B
        /// </summary>
        /// <value>���o����</value>
        public SendBeforeOrderCondition ExtraInfo { get { return _extraInfo; } }

        #endregion  // <���o����

        #region <���M�O���X�g�A�N�Z�X/>

        /// <summary>���M�O���X�g�A�N�Z�X</summary>
        private readonly SendBeforeAcs _sendBeforeAcs;
        /// <summary>
        /// ���M�O���X�g�A�N�Z�X���擾���܂��B
        /// </summary>
        /// <value>���M�O���X�g�A�N�Z�X</value>
        private SendBeforeAcs SendBeforeAcs { get { return _sendBeforeAcs; } }

        #endregion  // <���M�O���X�g�A�N�Z�X/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="printInfo">������</param>
        public PMUOE02032EA(object printInfo)
        {
            // ������
            _printInfo = printInfo as SFCMN06002C;
            _extraInfo = _printInfo.jyoken as SendBeforeOrderCondition;
            _sendBeforeAcs = new SendBeforeAcs();
        }

        #endregion  // <Constructor/>
    }
}
