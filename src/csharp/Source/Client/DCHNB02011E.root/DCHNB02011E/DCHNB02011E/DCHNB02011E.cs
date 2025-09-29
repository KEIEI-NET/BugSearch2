using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.UIData
{
	public class DCHNB02011EA : IExtrProc
	{
		//================================================================================
		//  �R���X�g���N�^�[
		//================================================================================
		#region �R���X�g���N�^�[
		public DCHNB02011EA()
		{
        }

		public DCHNB02011EA(object printInfo)
		{
			this._printInfo = printInfo as SFCMN06002C;
            this._extraInfo = this._printInfo.jyoken as ExtrInfo_DCHNB02013E;
            this._saleConfListAcs = new SaleConfAcs();

            this._lastTimeExtraInfo = new ExtrInfo_DCHNB02013E();

			//���[�^�C�v�敪���擾
			this._extraInfo.PrintDiv = this._printInfo.frycd;
			//���[�^�C�v�敪���̂��擾
			this._extraInfo.PrintDivName = this._printInfo.prpnm;

	     }
		#endregion

		//================================================================================
		//  �����ϐ�
		//================================================================================
		#region private member
		private SFCMN06002C _printInfo = null;

        private SaleConfAcs _saleConfListAcs = null;        // �󒍑ݏo�m�F�\�A�N�Z�X�N���X
        private ExtrInfo_DCHNB02013E _extraInfo = null;     // ���o�����N���X

        private ExtrInfo_DCHNB02013E _lastTimeExtraInfo = null;    // �O�񒊏o�����N���X

        private string _PGID = "DCHNB02011EA";

		#endregion
		
		// ===============================================================================
		// IExtrProc ������
		// ===============================================================================
		#region IExtrProc �����o

		public SFCMN06002C Printinfo
		{
			get { return this._printInfo; }
			set { this._printInfo = value; }
		}

		/// <summary>
		/// ���o����
		/// </summary>
		public int ExtrPrintData()
		{
			int status = (int)Broadleaf.Library.Resources.ConstantManagement.MethodResult.ctFNC_ERROR;

			// ���o����ʃC���X�^���X�쐬
			Broadleaf.Windows.Forms.SFCMN00299CA pd = new Broadleaf.Windows.Forms.SFCMN00299CA();
			pd.Title = "���o��";
			pd.Message = "���݁A�f�[�^���o���ł��B";

			try
			{
				pd.Show();
				status = this.ExtraProc();
			}
			finally
			{
				pd.Close();
				this._printInfo.status = status;
			}

			return status;
		}
		#endregion

		// ===============================================================================
		// �����g�p�֐�
		// ===============================================================================
		#region private methods
		/// <summary>
		/// ���o���C������
		/// </summary>
        /// <remarks>
        /// <br>�O��Ə������ς���Ă���Ƃ��̓����[�g����f�[�^���擾����</br>
        /// </remarks>
		private int ExtraProc()
		{
            int result = (int)Broadleaf.Library.Resources.ConstantManagement.MethodResult.ctFNC_ERROR;
            int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
            string message = "";

			try
			{
				if (this._lastTimeExtraInfo.Equals(this._extraInfo))
				{
					// �O��Ɠ��������̂Ƃ�
					status = this._saleConfListAcs.Search(this._extraInfo, out message, 1);
				}
				else
				{
					// �O��ƈႤ�����̂Ƃ��A�����[�g����Ď擾
					status = this._saleConfListAcs.Search(this._extraInfo, out message, 0);
				}

				if (status == 0)
				{
					this._printInfo.rdData = this._saleConfListAcs._printDataSet;

					this._lastTimeExtraInfo = this._extraInfo.Clone();
				}
			}
			catch (Exception ex)
			{
				TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, status,
					MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}
            finally
            {
                // �߂�l��ݒ�B�ُ�̏ꍇ�̓��b�Z�[�W��\��
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            result = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            result = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, this._PGID, message, status,
                                        MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            result = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                            break;
                        }
                }
            }
            return result;
		}


		#endregion


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
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.03.25</br>
		/// </remarks>
		private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
            // 2008.08.02 30413 ���� �o�ׁ��ݏo�ɕύX >>>>>>START
            //return TMsgDisp.Show(iLevel, "�󒍏o�׊m�F�\���o����", iMsg, iSt, iButton, iDefButton);
            return TMsgDisp.Show(iLevel, "�󒍑ݏo�m�F�\���o����", iMsg, iSt, iButton, iDefButton);
            // 2008.08.02 30413 ���� �o�ׁ��ݏo�ɕύX <<<<<<END
        }
	}
}
