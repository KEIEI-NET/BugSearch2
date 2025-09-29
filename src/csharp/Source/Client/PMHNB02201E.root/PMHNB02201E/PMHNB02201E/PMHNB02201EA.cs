//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���������A���}�b�`���X�g
// �v���O�����T�v   : ���������A���}�b�`���X�g�����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/04/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
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
    /// ���������A���}�b�`���X�g�����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���������A���}�b�`���X�g�����N���X</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.04.07</br>
    /// <br></br>
    /// </remarks>
    public class PMHNB02201EA : IExtrProc
    {
        #region �� Constructor
		/// <summary>
        /// ���������A���}�b�`���X�g���o�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���������A���}�b�`���X�gUI�N���X</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.07</br>
        /// <br></br>
		/// </remarks>
        public PMHNB02201EA(object printInfo)
        {
            // ������
            this._printInfo = printInfo as SFCMN06002C;
            this._extraInfo = this._printInfo.jyoken as RateUnMatchCndtn;

            this._extraInfo.PrintDiv = this._printInfo.frycd;
            this._extraInfo.PrintDivName = this._printInfo.prpnm;
            this._rateUnMatchAcs = new RateUnMatchAcs();
        }
        #endregion �� Constructor

        #region �� private member

        private SFCMN06002C _printInfo = null;			        // ������N���X
        private RateUnMatchAcs _rateUnMatchAcs = null;	        // ���������A���}�b�`���X�g�A�N�Z�X�N���X
        private RateUnMatchCndtn _extraInfo = null;	            // ���o�����N���X
        #endregion �� private member

        #region �� private const
        private const string ct_PGID = "PMHNB02201E";
        private const string ct_PGNM = "���������A���}�b�`���X�g";
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
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.07</br>
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
                // �_�C�A���O�\��
                form.Show();

                // ���o�������s
                status = this.ExtraProc();

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    DataView dv = new DataView(this._rateUnMatchAcs.RateUnMatchDs.Tables[RateUnMatchResult.Tbl_Result_RateUnMatch], "", "", DataViewRowState.CurrentRows);

                    // ����f�[�^�擾
                    this._printInfo.rdData = dv;

                    if (dv.Table.Rows.Count == 0)
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                    }
                }
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
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = string.Empty;
            // ��������
            int status = this._rateUnMatchAcs.Search(this._extraInfo, out errMsg);
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
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
		#endregion �� �G���[���b�Z�[�W�\��
        #endregion
    }
}
