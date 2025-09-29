//**********************************************************************//
// System			:	PM.NS									        //
// Sub System		:													//
// Program name		:	��`�����ʕ\ �f�[�^�N���X		                //
//					:	PMTEG02301EA.DLL								//
// Name Space		:	Broadleaf.Application.UIData					//
// Programmer		:	���J�� 											//
// Date				:	2010.05.05										//
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
    /// ��`�����ʕ\ �f�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : ��`�����ʕ\UI�t�H�[���N���X</br>
    /// <br>Programmer	: ���J��</br>
    /// <br>Date		: 2010.05.05</br>
    /// <br></br>
    /// </remarks>
    public class PMTEG02301EA : IExtrProc
    {
        #region �� Constructor
        /// <summary>
        /// ��`�����ʕ\�ꗗ���o�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��`�����ʕ\�ꗗUI�N���X</br>
        /// <br>Programmer	: ���J��</br>
        /// <br>Date		: 2010.05.05</br>
        /// <br></br>
        /// </remarks>
        public PMTEG02301EA(object printInfo)
        {
            // ������
            this._printInfo = printInfo as SFCMN06002C;
            this._tegataKibiListReportAcs = new TegataKibiListReportAcs();
            this._tegataKibiListReport = this._printInfo.jyoken as TegataKibiListReport;
        }
        #endregion �� Constructor

        #region �� private member
        private SFCMN06002C _printInfo = null;			// ������N���X
        private TegataKibiListReportAcs _tegataKibiListReportAcs = null;		// ��`�����ʕ\�ꗗ�A�N�Z�X�N���X
        private TegataKibiListReport _tegataKibiListReport = null;	// ���o�����N���X
        #endregion �� private member

        #region �� private const
        // �N���XID
        private const string ct_PGID = "PMTEG02301E";
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
        /// <br>Date		  : 2010.05.05</br>
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
        /// <br>Date		   : 2010.05.05</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {   // �f�[�^�e�[�u������A�f�[�^���������܂�
                status = this._tegataKibiListReportAcs.SearchTegataKibiListReportProcMain(this._tegataKibiListReport, out errMsg);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // ����f�[�^��ݒ菈��
                    this._printInfo.rdData = this._tegataKibiListReportAcs.DataSet;

                    // �������i�J�n�����`�U�����ڕ��j�̌����^�C�g��
                    int[] monthTitleInt = new int[6];
                    string[] monthTitle = new string[6];
                    for (int i = 0; i < 6; i++)
                    {
                        monthTitleInt[i] = this._tegataKibiListReportAcs.CalculateYearMonth(
                                this._tegataKibiListReportAcs.DateTimeToLongDateYM(this._tegataKibiListReport.SalesDate), i);
                        string str = monthTitleInt[i].ToString().Substring(4, 2);
                        monthTitle[i] = getMonthTitle(Convert.ToInt16(str));
                    }
                    this._tegataKibiListReport.MonthTitles = monthTitle;
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

        /// <summary>
        /// �����^�C�g���̓]��
        /// </summary>
        /// <param name="month">int</param>
        /// <returns>string</returns>
        /// <remarks>
        /// <br>Note       : �����^�C�g���̓]�����s���B</br>
        /// <br>Programmer : wangkq</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private string getMonthTitle(int month)
        {
            switch (month)
            {
                case 1:
                    return "�P��";
                case 2:
                    return "�Q��";
                case 3:
                    return "�R��";
                case 4:
                    return "�S��";
                case 5:
                    return "�T��";
                case 6:
                    return "�U��";
                case 7:
                    return "�V��";
                case 8:
                    return "�W��";
                case 9:
                    return "�X��";
                case 10:
                    return "�P�O��";
                case 11:
                    return "�P�P��";
                case 12:
                    return "�P�Q��";
            }
            return string.Empty;
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
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
        #endregion �� �G���[���b�Z�[�W�\��
        #endregion
    }
}
