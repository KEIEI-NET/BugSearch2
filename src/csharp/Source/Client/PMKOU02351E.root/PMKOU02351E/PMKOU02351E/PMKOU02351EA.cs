//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���׍��ٕ\ �f�[�^�N���X
// �v���O�����T�v   : ���׍��ٕ\ �f�[�^�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570136-00   �쐬�S�� : 杍^
// �� �� ��  K2019/08/14   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ���׍��ٕ\ �f�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : ���׍��ٕ\UI�t�H�[���N���X</br>
    /// <br>Programmer  : 杍^</br>
    /// <br>Date        : K2019/08/14</br>
    /// </remarks>
    public class PMKOU02351EA : IExtrProc
    {
        #region �� Constructor
        /// <summary>
        /// ���׍��ٕ\�ꗗ���o�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���׍��ٕ\�ꗗUI�N���X</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : K2019/08/14</br>
        /// </remarks>
        public PMKOU02351EA(object printInfo)
        {
            // ������
            this.PrintIf = printInfo as SFCMN06002C;
            this.arrGoodsDiffAccess = new ArrGoodsDiffAcs();
            this.ArrGoodsDiffCndWork = this.PrintIf.jyoken as ArrGoodsDiffCndtnWork;
        }
        #endregion �� Constructor

        #region �� private member
        private SFCMN06002C PrintIf = null;                            // ������N���X
        private ArrGoodsDiffAcs arrGoodsDiffAccess = null;              // ���׍��ٕ\�A�N�Z�X�N���X
        private ArrGoodsDiffCndtnWork ArrGoodsDiffCndWork = null;// ���o�����N���X
        #endregion �� private member

        #region �� private const
        // �N���XID
        private const string PgId = "PMKOU02351E";
        #endregion �� private const

        #region �� IExtrProc �����o
        #region �� Public Property
        /// <summary>
        /// ������N���X�v���p�e�B
        /// </summary>
        public SFCMN06002C Printinfo
        {
           get { return this.PrintIf; }
           set { this.PrintIf = value; }
        }
        #endregion �� Public Property

        #region �� Public Method
        #region �� ���o����
        /// <summary>
        /// ���o����
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : ����̃��C���������s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        public int ExtrPrintData()
        {
           int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
           // ���o����ʕ��i�̃C���X�^���X���쐬
           Broadleaf.Windows.Forms.SFCMN00299CA form = new SFCMN00299CA();
           // �\��������ݒ�
           form.Title = "���o��";
           form.Message = "���݁A�f�[�^�𒊏o���ł��B";

           try
           {
               form.Show();                 // �_�C�A���O�\��
               status = this.ExtraProc();   // ���o�������s
           }
           finally
           {
               // �_�C�A���O�����
               form.Close();
               this.PrintIf.status = status;
           }

           return status;
       }

        #endregion �� ���o����
        #endregion �� Public Method
        #endregion �� IExtrProc �����o

        #region �� Private Method
        #region �� ���o���C������
        /// <summary>
        /// ���o���C������
        /// </summary>
       /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : ���o�̃��C���������s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status = this.arrGoodsDiffAccess.SearchArrGoodsDiffProcMain(this.ArrGoodsDiffCndWork, out errMsg);
                if(status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // ����f�[�^��ݒ菈��
                    this.PrintIf.rdData = this.arrGoodsDiffAccess.DataSet;
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
                            // �X�e�[�^�X���ُ�̂Ƃ��̓��b�Z�[�W��\��
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PgId, errMsg, status,
                                       MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
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
        /// <br>Note       : �G���[���b�Z�[�W��\�����܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, PgId, iMsg, iSt, iButton, iDefButton);
        }
        #endregion �� �G���[���b�Z�[�W�\��
        #endregion
    }
}
