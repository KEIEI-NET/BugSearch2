//**********************************************************************//
// System			:	PM.NS									        //
// Sub System		:													//
// Program name		:	��`���ו\ �f�[�^�N���X		                    //
//					:	PMTEG02101EA.DLL								//
// Name Space		:	Broadleaf.Application.UIData					//
// Programmer		:	���J�� 											//
// Date				:	2010.04.28										//
//----------------------------------------------------------------------//
// Update Note		:													//
//----------------------------------------------------------------------//
//                 Copyright(c)2010 Broadleaf Co.,Ltd.                  //
//**********************************************************************//
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
    /// ��`���ו\ �f�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : ��`���ו\UI�t�H�[���N���X</br>
    /// <br>Programmer	: ���J��</br>
    /// <br>Date		: 2010.04.28</br>
    /// <br></br>
    /// </remarks>
    public class PMTEG02101EA : IExtrProc
    {
        #region �� Constructor
        /// <summary>
        /// ��`���ו\�ꗗ���o�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��`���ו\�ꗗUI�N���X</br>
        /// <br>Programmer	: ���J��</br>
        /// <br>Date		: 2010.04.28</br>
        /// <br></br>
        /// </remarks>
        public PMTEG02101EA(object printInfo)
        {
            // ������
            this._printInfo = printInfo as SFCMN06002C;
            this._tegataMeisaiListReportAcs = new TegataMeisaiListReportAcs();
            this._tegataMeisaiListReport = this._printInfo.jyoken as TegataMeisaiListReport;
        }
        #endregion �� Constructor

        #region �� private member
        private SFCMN06002C _printInfo = null;			// ������N���X
        private TegataMeisaiListReportAcs _tegataMeisaiListReportAcs = null;		// ��`���ו\�ꗗ�A�N�Z�X�N���X
        private TegataMeisaiListReport _tegataMeisaiListReport = null;	// ���o�����N���X
        #endregion �� private member

        #region �� private const
        // �N���XID
        private const string ct_PGID = "PMTEG02101E";
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
        /// <br>Programmer : ���J��</br>
        /// <br>Date		  : 2010.04.28</br>
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
        /// <br>Programmer  : ���J��</br>
        /// <br>Date		   : 2010.04.28</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {   // �f�[�^�e�[�u������A�f�[�^���������܂�
                status = this._tegataMeisaiListReportAcs.SearchTegataMeisaiListReportProcMain(this._tegataMeisaiListReport, out errMsg);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // ����f�[�^��ݒ菈��
                    this._printInfo.rdData = this._tegataMeisaiListReportAcs.DataSet;
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
        /// <br>Programmer : ���J��</br>
        /// <br>Date	   : 2010.04.28</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
        #endregion �� �G���[���b�Z�[�W�\��
        #endregion
    }
}
