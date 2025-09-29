using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Windows.Forms;
using Broadleaf.Library.Resources;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// ActiveReport���ʃ��|�[�g�������N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ActiveRepotr������̈������N���X�ł��B</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2007.03.02</br>
	/// </remarks>
	public class ARptPrintCtrl
	{
		//================================================================================
		//  �R���X�g���N�^�[
		//================================================================================
		#region �R���X�g���N�^�[
		/// <summary>
		/// ActiveReport���ʃ��|�[�g�������N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.02</br>
		/// </remarks>
		public ARptPrintCtrl()
		{
			// ���ʊ֐����i�C���X�^���X�쐬
			this._commonLib = new SFCMN00293UZ();

			// �󎚈ʒu�������i�C���X�^���X�쐬
			this._positionAdjPrtLib = new SFCMN00294CA();
		}
		#endregion

		//================================================================================
		//  �����ϐ�
		//================================================================================
		#region Private Member
		private SFCMN00293UZ _commonLib;
		private SFCMN00293UC _commonInfo;
		private SFCMN00294CA _positionAdjPrtLib;				// �󎚈ʒu�������i(����p)
		#endregion

		//================================================================================
		//  �O���񋟃v���p�e�B
		//================================================================================
		#region Public Property
		
		/// <summary>���ʉ�ʏ����v���p�e�B</summary>
		public SFCMN00293UC CommonInfo
		{
			get { return this._commonInfo; }
			set { this._commonInfo = value; }
		}
		
		#endregion

		//================================================================================
		//  �O���񋟃v���p�e�B
		//================================================================================
		#region Public Methods
		
		/// <summary>
		/// ������C������
		/// </summary>
		/// <param name="rpt">�Ώ�ActiveReport�N���X</param>
		/// <param name="IsPrint">����L��[T:�������,F:�h�L�������g�쐬�̂�]</param>
		/// <param name="msg">�G���[���b�Z�[�W</param>
		/// <remarks>
		/// <br>Note       : ����̃��C���������s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.01</br>
		/// </remarks>
		public int Run(DataDynamics.ActiveReports.ActiveReport3 rpt, bool IsPrint, out string msg)
		{
			msg = "";
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			try
			{
				// �󎚈ʒu����
				this._commonLib.AdjustPrintPosition(ref this._positionAdjPrtLib, ref rpt, this._commonInfo, false);

				// ������ݒ�
				if (this._commonLib.SetPrinterInfo(ref rpt, this._commonInfo, out msg) != 0)
				{
					return status;
				}

				// ����J�n
				rpt.Run();

				if (rpt.Document != null && rpt.Document.Pages.Count != 0)
				{
					// �������ꍇ�̂�
					if (IsPrint)
					{
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 DEL
                        //rpt.Document.Print(false, false, false);
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 ADD
                        this._commonLib.PrintDocument( false, rpt, _commonInfo.PrinterName );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 ADD
					}

					// �߂�STATUS�ݒ�
					status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
				}
				else
				{
					status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
				}
			}
			catch (Exception ex)
			{
				msg = "������������ɂė�O���������܂����B"
					+ "\n\r" + ex.Message;
			}
			finally
			{
				this._commonInfo.Status = status;

				// �󎚈ʒu�������i�j��
				if (this._positionAdjPrtLib != null)
				{
					this._positionAdjPrtLib.Dispose();
				}
			}

			return status;
		}

		#endregion

	}
}
