//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d���s�����m�F�\
// �v���O�����T�v   : �d���s�����m�F�\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/04/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using System.Windows.Forms;
using System.Data;
using System.Collections;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Net.NetworkInformation;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �d���s�����m�F�\���o�N���X                                                        
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���s�����m�F�\���o�N���X�̃C���X�^���X�̍쐬���s���B</br>       
    /// <br>Programmer : ���痈</br>                                   
    /// <br>Date       : 2009.04.13</br>                                       
    /// </remarks>
    public class PMKOU02044EA : IExtrProc
    {

        #region �� Constructor
        /// <summary>
        /// �d���s�����m�F�\���o�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d���s�����m�F�\UI�N���X���s���܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.13</br>
        /// <br></br>
        /// </remarks>
        public PMKOU02044EA(object printInfo)
        {
            // ������
            this._printInfo = printInfo as SFCMN06002C;
            this._stockSalesInfoMainCndtn = this._printInfo.jyoken as StockSalesInfoMainCndtn;
            this._StockSalesInfoMainAcs = new StockSalesInfoMainAcs();
        }
        #endregion �� Constructor

        #region �� private member

        private SFCMN06002C _printInfo = null;			       // ������N���X
        private StockSalesInfoMainAcs _StockSalesInfoMainAcs = null;   // �d���s�����m�F�ꗗ�\�A�N�Z�X�N���X
        private StockSalesInfoMainCndtn _stockSalesInfoMainCndtn = null;		   // ���o�����N���X


        #endregion �� private member

        #region �� private const
        private const string ct_PGID = "PMKOU02044E";
        #endregion �� private const

        #region �� IExtrProc �����o
        #region �� Public Property
        /// <summary> ������N���X�v���p�e�B</summary>
        /// <value>Printinfo</value>               
        /// <remarks>������N���X�擾���̓Z�b�g�v���p�e�B </remarks> 
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
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.13</br>
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
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        private int ExtraProc()
        {

            string errMsg = "";
            //�S���X�e�[�^�X
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //CSV�f�[�^
            ArrayList accRec = new ArrayList();

            try
            {
                // �I�t���C����ԃ`�F�b�N	
                if (!CheckOnline())
                {
                    TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_STOP,
                        "�d���s�����m�F�\",
                        "�d���s�����m�F�\�f�[�^�ǂݍ��݂Ɏ��s���܂����B",
                        (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                    status = (int)ConstantManagement.DB_Status.ctDB_OFFLINE;
                    return status;
                }

                // ������[�f�[�^���擾����
                status = this._StockSalesInfoMainAcs.SearchCustAccRecMainForPdf(this._stockSalesInfoMainCndtn, out errMsg);

                // �o�̓^�C�v�ɂ��f�[�^���擾
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // ����f�[�^�擾
                    this._printInfo.rdData = this._StockSalesInfoMainAcs.CustAccRecDs;
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
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
        #endregion �� �G���[���b�Z�[�W�\��


        #region �� �I�t���C����ԃ`�F�b�N����

        /// <summary>
        /// ���O�I�����I�����C����ԃ`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N��������</returns>
        private bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ���[�J���G���A�ڑ���Ԃɂ��I�����C������
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// �����[�g�ڑ��\����
        /// </summary>
        /// <returns>���茋��</returns>
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

        #endregion

    }
}
