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
	public class MAKON02241EA : IExtrProc
	{
		//================================================================================
		//  �R���X�g���N�^�[
		//================================================================================
		#region �R���X�g���N�^�[
		public MAKON02241EA()
		{
        }

		public MAKON02241EA(object printInfo)
		{
			this._printInfo = printInfo as SFCMN06002C;
            this._extraInfo = this._printInfo.jyoken as ExtrInfo_MAKON02247E;

			// ���[�^�C�v�̎��ʂ��擾
			this._extraInfo.PrintDiv = this._printInfo.frycd;
			// ���[�^�C�v�̎��ʂ𖼏̎擾
			this._extraInfo.PrintDivName = this._printInfo.prpnm;

            this._stockConfListAcs = new StockConfAcs();
        }
		#endregion

		//================================================================================
		//  �����ϐ�
		//================================================================================
		#region private member
		private SFCMN06002C _printInfo = null;

        private StockConfAcs _stockConfListAcs = null;        // �d���m�F�\�A�N�Z�X�N���X
        private ExtrInfo_MAKON02247E _extraInfo = null;     // ���o�����N���X

        private string _PGID = "MAKON02241EA";

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
		private int ExtraProc()
		{
            int result = (int)Broadleaf.Library.Resources.ConstantManagement.MethodResult.ctFNC_ERROR;
            int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
            string message = "";

			try
			{
				// ������[�ɂ��擾�f�[�^��ύX����
				switch (this._extraInfo.PrintDiv)
				{
					case 1:// ���׌`��
						status = this._stockConfListAcs.Search(this._extraInfo, out message, 1);
						break;
					case 2:// �ڍ׌`��
						status = this._stockConfListAcs.Search(this._extraInfo, out message, 1);
						break;
					case 3:// �`�[�`��
						status = this._stockConfListAcs.SearchSlipTtl(this._extraInfo, out message);
						break;
				}

                if (status == 0)
                {
                    this._printInfo.rdData = this._stockConfListAcs._printDataSet;
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
			return TMsgDisp.Show(iLevel, "�d���m�F�\���o����", iMsg, iSt, iButton, iDefButton);
		}
	}
}
