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
	/// <summary>
	/// �O�N�Δ�\���o�N���X
	/// </summary>
	public class DCTOK02091EA : IExtrProc
	{
		//================================================================================
		//  �R���X�g���N�^�[
		//================================================================================
		#region �R���X�g���N�^�[

		/// <summary>
		/// �R���X�g���N�^�[
		/// </summary>
		public DCTOK02091EA(object printInfo)
		{
			this._printInfo = printInfo as SFCMN06002C;
            this._extraInfo = this._printInfo.jyoken as ExtrInfo_DCTOK02093E;
			this._prevYearCpAcs = new PrevYearComparison();

            this._lastTimeExtraInfo = new ExtrInfo_DCTOK02093E();
        }
		#endregion

		//================================================================================
		//  �����ϐ�
		//================================================================================
		#region private member
		private SFCMN06002C _printInfo = null;

		private PrevYearComparison _prevYearCpAcs = null;        // ����m�F�\�A�N�Z�X�N���X
		private ExtrInfo_DCTOK02093E _extraInfo = null;			 // ���o�����N���X

		private ExtrInfo_DCTOK02093E _lastTimeExtraInfo = null;  // �O�񒊏o�����N���X

        private string _PGID = "DCTOK02091EA";

		#endregion
		
		// ===============================================================================
		// IExtrProc ������
		// ===============================================================================
		#region IExtrProc �����o

        /// <summary>
        /// 
        /// </summary>
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
        /// <br>Update Date: 2007.09.19 T.Kimura �O��Ə������ς���Ă���Ƃ��̓����[�g���f�[�^���擾����悤�ɕύX</br>
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
                    status = this._prevYearCpAcs.Search(this._extraInfo, out message,1);
                }
                else
                {
                    // �O��ƈႤ�����̂Ƃ��A�����[�g����Ď擾
                    status = this._prevYearCpAcs.Search(this._extraInfo, out message, 0);
                }

                if (status == 0)
                {
                    this._printInfo.rdData = this._prevYearCpAcs._printDataSet;

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
		/// <br>Programmer : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.11.25</br>
		/// </remarks>
		private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "�O�N�Δ�\���o����", iMsg, iSt, iButton, iDefButton);
		}
	}
}
