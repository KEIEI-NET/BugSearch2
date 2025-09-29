using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ���Ӑ挳�����o�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ挳�����o�N���X</br>
    /// <br>Programmer : 20081 �D�c �E�l</br>
    /// <br>Date       : 2007.11.12</br>
    /// <br>Programmer : 30009 �a�J ���</br>
    /// <br>Date       : 2009.01.21</br>
    /// <br>Note       : PM.NS�p�ɏC��</br>
    /// <br>Note       : ��DC��PM�ŕύX���K�v�ȕ����̂ݏC�����܂����B��</br>
    /// <br>Note       : ��PM�ŕs�v�ȏ����������Ă���肪�Ȃ���΂��̂܂܂ɂ��Ă���܂���</br>
    /// <br></br>
    /// </remarks>
    public class PMHNB02194EA : IExtrProc
    {
        #region �� Constructor
		/// <summary>
        /// ���Ӑ挳�����o�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���Ӑ挳��UI�N���X</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.12</br>
		/// <br></br>
		/// </remarks>
        public PMHNB02194EA( object printInfo )
        {
            // ������
            this._printInfo = printInfo as SFCMN06002C;
            this._extraInfo = this._printInfo.jyoken as LedgerCmnCndtn;
            this._csLedgerDmdAcs = new CsLedgerDmdAcs();
        }
        #endregion �� Constructor

        #region �� private member

        private SFCMN06002C _printInfo = null;			       // ������N���X
        private CsLedgerDmdAcs _csLedgerDmdAcs = null;         // ���Ӑ挳���Ɖ�A�N�Z�X�N���X
        private LedgerCmnCndtn _extraInfo = null;	           // ���o�����N���X
        #endregion �� private member

        #region �� private const
        private const string ct_PGID = "PMHNB02194E";
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
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.11.12</br>
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
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.11.12</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = string.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // �o�͋敪(�����c�E���|�c)
                int mode = this._extraInfo.ListDivCode;
                
   				status = this._csLedgerDmdAcs.Read(
				    mode, 
                    this._extraInfo.EnterpriseCode,
                    0,
                    this._extraInfo.StartCustomerCode,
                    this._extraInfo.EndCustomerCode,
                    this._extraInfo.StartTargetYearMonth,
                    this._extraInfo.EndTargetYearMonth,
                    this._extraInfo.AddupSecCodeList[0].ToString(),
                    this._extraInfo.AddupSecCodeList,
					true,
                    out errMsg,
                    (int)this._extraInfo.OutMoneyDiv);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
                {
                    // ����f�[�^�擾
                    this._printInfo.rdData = this._csLedgerDmdAcs.CustDmdPrcDataView;
                }
            }
            catch (Exception ex)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                // �߂�l��ݒ�B�ُ�̏ꍇ�̓��b�Z�[�W��\��
                switch ( status )
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                        {
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                            break;
                        }
                    default:
                        {
							// �X�e�[�^�X���ȏ�̂Ƃ��̓��b�Z�[�W��\��
                            TMsgDisp.Show( emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, errMsg, status,
                                        MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
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
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.11.12</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
		#endregion �� �G���[���b�Z�[�W�\��
        #endregion
	}
}
