//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : S&E����f�[�^�e�L�X�g�o��
// �v���O�����T�v   : S&E����f�[�^�e�L�X�g�o�͒��[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/08/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
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
    /// ����f�[�^�e�L�X�g���o�N���X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����f�[�^�e�L�X�gUI�t�H�[���N���X</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2009.08.17</br>
    /// <br>           : </br>
    /// </remarks>
    public class PMSAE02011EA : IExtrProc
    {
        #region �� Constructor
        /// <summary>
        /// ����f�[�^�e�L�X�g���o�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����f�[�^�e�L�X�gUI�N���X</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.17</br>
        /// <br></br>
        /// </remarks>
        public PMSAE02011EA(object printInfo)
        {
            // ������
            this._printInfo = printInfo as SFCMN06002C;
            this._salesHistoryAcs = new SalesHistoryAcs();
            this._salesHistoryCndtn = this._printInfo.jyoken as SalesHistoryCndtn;
        }
        #endregion �� Constructor

        #region �� private member
        private SFCMN06002C _printInfo = null;			        // ������N���X
        private SalesHistoryAcs _salesHistoryAcs = null;		// S&E����f�[�^�e�L�X�g�A�N�Z�X�N���X
        private SalesHistoryCndtn _salesHistoryCndtn = null;	// S&E����f�[�^�e�L�X�g���o�����N���X
        #endregion �� private member

        #region �� private const
        private const string ct_PGID = "PMSAE02011E";
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
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.17</br>
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
                form.Show();			// �_�C�A���O�\��
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
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.17</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = "";
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            DataTable printdataTable = new DataTable();
            try
            {
                if (_salesHistoryCndtn.Mode == 0)
                {
                    // ����f�[�^�擾
                    status = this._salesHistoryAcs.SearchSalesHistoryProcMain(this._salesHistoryCndtn, out errMsg);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // ����f�[�^�擾
                        this._printInfo.rdData = this._salesHistoryAcs.GetprintdataTable();
                    }
                }
                else
                {
                    if (this._printInfo.rdData != null)
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
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
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        }
                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                        {
                            break;
                        }
                    default:
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.17</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }

        #endregion �� �G���[���b�Z�[�W�\��
        #endregion
    }
}
