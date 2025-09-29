//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d���摍���}�X�^�ꗗ�\ �f�[�^�N���X
// �v���O�����T�v   : �d���摍���}�X�^�ꗗ�\ �f�[�^�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�               �쐬�S�� : FSI�����@�v
// �� �� ��  2012/09/07   �C�����e : �V�K�쐬
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

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �d���摍���}�X�^�ꗗ�\ �f�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �d���摍���}�X�^�ꗗ�\UI�t�H�[���N���X</br>
    /// <br>Programmer  : FSI�����@�v</br>
    /// <br>Date        : 2012/09/07</br>
    /// <br></br>
    /// <br>Update Note :</br>
    /// </remarks>
    public class PMKAK09011EA : IExtrProc
    {
        #region �� Constructor
        /// <summary>
        /// �d���摍���}�X�^�ꗗ�\�ꗗ���o�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : �d���摍���}�X�^�ꗗ�\�ꗗUI�N���X</br>
        /// <br>Programmer  : FSI�����@�v</br>
        /// <br>Date        : 2012/09/07</br>
        /// <br></br>
        /// </remarks>
        public PMKAK09011EA(object printInfo)
        {
            // ������
            this._printInfo = printInfo as SFCMN06002C;
            this._sumSuppStPrintAcs = new SumSuppStPrintAcs();
            this._sumSuppStPrintUIParaWork = this._printInfo.jyoken as SumSuppStPrintUIParaWork;
        }
        #endregion �� Constructor

        #region �� private member
        private SFCMN06002C _printInfo = null;                            // ������N���X
        private SumSuppStPrintAcs _sumSuppStPrintAcs = null;              // �d���摍���}�X�^�ꗗ�\�A�N�Z�X�N���X
        private SumSuppStPrintUIParaWork _sumSuppStPrintUIParaWork = null;// ���o�����N���X
        #endregion �� private member

        #region �� private const
        // �N���XID
        private const string ct_PGID = "PMKAK09011E";
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
        /// <br>Programmer : FSI�����@�v</br>
        /// <br>Date       : 2012/09/07</br>
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
               this._printInfo.status = status;
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
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���o�̃��C���������s���܂��B</br>
        /// <br>Programmer : FSI�����@�v</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status = this._sumSuppStPrintAcs.SearchSumSuppStPrintProcMain(this._sumSuppStPrintUIParaWork, out errMsg);
                if(status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // ����f�[�^��ݒ菈��
                    this._printInfo.rdData = this._sumSuppStPrintAcs.DataSet;
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
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, errMsg, status,
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
        /// <br>Programmer : FSI�����@�v</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
        #endregion �� �G���[���b�Z�[�W�\��
        #endregion
    }
}
