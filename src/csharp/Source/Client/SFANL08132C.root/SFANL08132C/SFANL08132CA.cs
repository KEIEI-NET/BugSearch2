using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// ���o�������͉�ʃC���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���o�������͉�ʗp�C���^�[�t�F�[�X�ł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.03.30</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	public interface IFreePrintUserControl
	{
		/// <summary>���R���[���o�������׃}�X�^���X�g</summary>
		List<FrePExCndD> FrePExCndDList { set; }

		/// <summary>
		/// ���̓`�F�b�N����
		/// </summary>
		/// <param name="message">�s�����̃��b�Z�[�W</param>
		/// <param name="control">�s���ӏ��̃R���g���[��</param>
		/// <param name="isNecessaryExtraCondCheck">�K�{�����`�F�b�N</param>
		/// <returns>�`�F�b�N����</returns>
		bool InputCheck(out string message, out Control control, bool isNecessaryExtraCondCheck);

		/// <summary>
		/// ���R���[���o�����ݒ���擾����
		/// </summary>
		/// <param name="frePprECnd">���R���[���o�����ݒ�}�X�^</param>
		/// <returns>�X�e�[�^�X</returns>
		void GetFrePprECndInfo(ref FrePprECnd frePprECnd);

		/// <summary>
		/// ���R���[���o�����ݒ���ݒ菈��
		/// </summary>
		/// <param name="frePprECnd">���R���[���o�����ݒ�}�X�^</param>
		void SetFrePprECndInfo(FrePprECnd frePprECnd);
	}

	/// <summary>
	/// ���o�����R���g���[�������N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���R���[�Ŏg�p���钊�o������ʐ����p�N���X�ł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.03.30</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	public class SFANL08132CA
	{
		#region PublicStaticMethod
		/// <summary>
		/// ���o�����R���g���[���擾����
		/// </summary>
		/// <param name="frePprECnd">���R���[���o�����ݒ�}�X�^</param>
		/// <param name="frePExCndDList">���R���[���o�������׃}�X�^���X�g</param>
		/// <returns>�擾�R���g���[��</returns>
		public static Control GetExtrSettingControl(FrePprECnd frePprECnd, List<FrePExCndD> frePExCndDList)
		{
			Control retControl = null;

			// ���o�����敪(0:�g�p�s��,1:���l�^,2:�����^�i���p�j,3:�����^�i�S�p�j,4:���t�^,5:�R���{�{�b�N�X�^)
			switch (frePprECnd.ExtraConditionDivCd)
			{
				case 1:
				{
					retControl = new SFANL08132CB();
					break;
				}
				case 2:
				case 3:
				{
					retControl = new SFANL08132CC();
					break;
				}
				case 4:
				{
					// ���o�����^�C�v(0:��v,1:�͈�,2:�����܂�,3:���ԁi�J�n����j,4:���ԁi�I������j)
					switch (frePprECnd.ExtraConditionTypeCd)
					{
						case 0:
						case 1:
						{
							retControl = new SFANL08132CD();
							break;
						}
						case 3:
						case 4:
						{
							retControl = new SFANL08132CE();
							break;
						}
					}
					break;
				}
				case 5:
				{
					retControl = new SFANL08132CF();
					break;
				}
				case 6:
				{
					retControl = new SFANL08132CH();
					break;
				}
				default:
				{
					return null;
				}
			}

			retControl.Name		= GetControlName(frePprECnd);
			retControl.TabIndex	= frePprECnd.DisplayOrder;

			IFreePrintUserControl iFreePrintUserControl = retControl as IFreePrintUserControl;
			if (iFreePrintUserControl != null)
			{
				iFreePrintUserControl.FrePExCndDList = frePExCndDList;
				iFreePrintUserControl.SetFrePprECndInfo(frePprECnd);
			}

			return retControl;
		}

		/// <summary>
		/// ���o�����R���g���[���擾����
		/// </summary>
		/// <param name="frePprECndList">���R���[���o�����ݒ�}�X�^���X�g</param>
		/// <param name="frePExCndDList">���R���[���o�������׃}�X�^���X�g</param>
		/// <returns>�擾�R���g���[�����X�g</returns>
		public static List<Control> GetExtrSettingControl(List<FrePprECnd> frePprECndList, List<FrePExCndD> frePExCndDList)
		{
			List<Control> userControlList = new List<Control>();

			foreach (FrePprECnd frePprECnd in frePprECndList)
			{
				Control control = GetExtrSettingControl(frePprECnd, frePExCndDList);
				if (control != null)
					userControlList.Add(control);
			}

			return userControlList;
		}

		/// <summary>
		/// �R���g���[�����擾����
		/// </summary>
		/// <param name="frePprECnd">���R���[���o�����ݒ�}�X�^</param>
		/// <returns>�R���g���[����</returns>
		public static string GetControlName(FrePprECnd frePprECnd)
		{
			return frePprECnd.OutputFormFileName + "_" + frePprECnd.UserPrtPprIdDerivNo + "_" + frePprECnd.DDName;
		}

		/// <summary>
		/// ���̓`�F�b�N����
		/// </summary>
		/// <param name="frePprECndList">���R���[���o�����ݒ�LIST</param>
		/// <param name="message">�s�����̃��b�Z�[�W</param>
		/// <param name="isNecessaryExtraCondCheck">�K�{�����`�F�b�N</param>
		/// <param name="errIndex">�s���ƂȂ鍀�ڂ�ListIndex</param>
		/// <returns>�`�F�b�N����</returns>
		public static bool InputCheck(List<FrePprECnd> frePprECndList, bool isNecessaryExtraCondCheck, out string message, out int errIndex)
		{
			message		= string.Empty;
			errIndex	= -1;

			bool checkRet = true;

			for (int ix = 0 ; ix != frePprECndList.Count ; ix++)
			{
				if (frePprECndList[ix].UsedFlg == 1)
				{
					checkRet = InputCheck(frePprECndList[ix], isNecessaryExtraCondCheck, out message);
					if (!checkRet)
					{
						errIndex = ix;
						break;
					}
				}
			}

			return checkRet;
		}

		/// <summary>
		/// ���̓`�F�b�N����
		/// </summary>
		/// <param name="frePprECnd">���R���[���o�����ݒ�}�X�^</param>
		/// <param name="message">�s�����̃��b�Z�[�W</param>
		/// <param name="isNecessaryExtraCondCheck">�K�{�����`�F�b�N</param>
		/// <returns>�`�F�b�N����</returns>
		public static bool InputCheck(FrePprECnd frePprECnd, bool isNecessaryExtraCondCheck, out string message)
		{
			message = string.Empty;

			bool checkRet = true;

			// ���o�����敪(0:�g�p�s��,1:���l�^,2:�����^�i���p�j,3:�����^�i�S�p�j,4:���t�^,5:�R���{�^,6:�`�F�b�N�^)
			switch (frePprECnd.ExtraConditionDivCd)
			{
				case 1:
				{
					checkRet = CheckNumType(frePprECnd, isNecessaryExtraCondCheck, out message);
					break;
				}
				case 2:
				case 3:
				{
					checkRet = CheckCharType(frePprECnd, isNecessaryExtraCondCheck, out message);
					break;
				}
				case 4:
				{
					checkRet = CheckDateType(frePprECnd, isNecessaryExtraCondCheck, out message);
					break;
				}
				case 5:
				case 6:
				{
					// �`�F�b�N����
					break;
				}
			}

			return checkRet;
		}
		#endregion

		#region PrivateStaticMethod
		/// <summary>
		/// ���̓`�F�b�N�����i���l�^�C�v�j
		/// </summary>
		/// <param name="frePprECnd">���R���[���o�����ݒ�}�X�^</param>
		/// <param name="message">�s�����̃��b�Z�[�W</param>
		/// <param name="isNecessaryExtraCondCheck">�K�{�����`�F�b�N</param>
		/// <returns>�`�F�b�N����</returns>
		private static bool CheckNumType(FrePprECnd frePprECnd, bool isNecessaryExtraCondCheck, out string message)
		{
			message = string.Empty;

			// ���o�����^�C�v(0:��v,1:�͈�,2:�����܂�,3:���ԁi�J�n����j,4:���ԁi�I������j)
			switch (frePprECnd.ExtraConditionTypeCd)
			{
				case 0:
				{
					if (frePprECnd.NecessaryExtraCondCd == 1 && isNecessaryExtraCondCheck)
					{
						if (frePprECnd.StExtraNumCode == 0)
						{
							message = frePprECnd.ExtraConditionTitle + "�����͂���Ă��܂���B";
							return false;
						}
					}
					break;
				}
				case 1:
				{
					if (frePprECnd.NecessaryExtraCondCd == 1 && isNecessaryExtraCondCheck)
					{
						if (frePprECnd.StExtraNumCode == 0 && frePprECnd.EdExtraNumCode == 0)
						{
							message = frePprECnd.ExtraConditionTitle + "�����͂���Ă��܂���B";
							return false;
						}
					}

					if (frePprECnd.StExtraNumCode != 0 && frePprECnd.EdExtraNumCode != 0)
					{
						if (frePprECnd.StExtraNumCode > frePprECnd.EdExtraNumCode)
						{
							message = frePprECnd.ExtraConditionTitle + "�͈͎̔w�肪�s���ł��B";
							return false;
						}
					}
					break;
				}
			}

			return true;
		}

		/// <summary>
		/// ���̓`�F�b�N�����i�����^�C�v�j
		/// </summary>
		/// <param name="frePprECnd">���R���[���o�����ݒ�}�X�^</param>
		/// <param name="message">�s�����̃��b�Z�[�W</param>
		/// <param name="isNecessaryExtraCondCheck">�K�{�����`�F�b�N</param>
		/// <returns>�`�F�b�N����</returns>
		private static bool CheckCharType(FrePprECnd frePprECnd, bool isNecessaryExtraCondCheck, out string message)
		{
			message = string.Empty;

			// ���o�����^�C�v(0:��v,1:�͈�,2:�����܂�,3:���ԁi�J�n����j,4:���ԁi�I������j)
			switch (frePprECnd.ExtraConditionTypeCd)
			{
				case 0:
				case 2:
				{
					if (frePprECnd.NecessaryExtraCondCd == 1 && isNecessaryExtraCondCheck)
					{
						if (string.IsNullOrEmpty(frePprECnd.StExtraCharCode))
						{
							message = frePprECnd.ExtraConditionTitle + "�����͂���Ă��܂���B";
							return false;
						}
					}
					break;
				}
				case 1:
				{
					if (frePprECnd.NecessaryExtraCondCd == 1 && isNecessaryExtraCondCheck)
					{
						if (string.IsNullOrEmpty(frePprECnd.StExtraCharCode) && string.IsNullOrEmpty(frePprECnd.EdExtraCharCode))
						{
							message = frePprECnd.ExtraConditionTitle + "�����͂���Ă��܂���B";
							return false;
						}
					}

					if (!string.IsNullOrEmpty(frePprECnd.StExtraCharCode) && !string.IsNullOrEmpty(frePprECnd.EdExtraCharCode))
					{
						if (string.Compare(frePprECnd.StExtraCharCode, frePprECnd.EdExtraCharCode) > 0)
						{
							message = frePprECnd.ExtraConditionTitle + "�͈͎̔w�肪�s���ł��B";
							return false;
						}
					}
					break;
				}
			}

			return true;
		}

		/// <summary>
		/// ���̓`�F�b�N�����i���t�^�C�v�j
		/// </summary>
		/// <param name="frePprECnd">���R���[���o�����ݒ�}�X�^</param>
		/// <param name="message">�s�����̃��b�Z�[�W</param>
		/// <param name="isNecessaryExtraCondCheck">�K�{�����`�F�b�N</param>
		/// <returns>�`�F�b�N����</returns>
		private static bool CheckDateType(FrePprECnd frePprECnd, bool isNecessaryExtraCondCheck, out string message)
		{
			message = string.Empty;

			if (frePprECnd.StExtraNumCode != 0)
				frePprECnd.StartExtraDate = TDateTime.DateTimeToLongDate(DateTime.Today);
			if (frePprECnd.EdExtraNumCode != 0)
				frePprECnd.EndExtraDate = TDateTime.DateTimeToLongDate(DateTime.Today);

			int startDate	= frePprECnd.StartExtraDate;
			int endDate		= frePprECnd.EndExtraDate;
			// ���o�����^�C�v(0:��v,1:�͈�,2:�����܂�,3:���ԁi�J�n����j,4:���ԁi�I������j)
			switch (frePprECnd.ExtraConditionTypeCd)
			{
				case 0:
				{
					// �K�{���ڃ`�F�b�N
					if (frePprECnd.NecessaryExtraCondCd == 1 && isNecessaryExtraCondCheck)
					{
						if (startDate == 0 || startDate == 10101)
						{
							message = frePprECnd.ExtraConditionTitle + "�����͂���Ă��܂���B";
							return false;
						}
					}

					if (startDate != 0 && !TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(startDate)))
					{
						message = frePprECnd.ExtraConditionTitle + "�̓��͂��s���ł��B";
						return false;
					}
					break;
				}
				case 1:
				{
					// �K�{���ڃ`�F�b�N
					if (frePprECnd.NecessaryExtraCondCd == 1 && isNecessaryExtraCondCheck)
					{
						if ((startDate == 10101 || startDate == 0) && (endDate == 10101 || endDate == 0))
						{
							message = frePprECnd.ExtraConditionTitle + "�����͂���Ă��܂���B";
							return false;
						}
					}

					if (startDate != 0 && !TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(startDate)))
					{
						message = frePprECnd.ExtraConditionTitle + "�i�J�n���j�̓��͂��s���ł��B";
						return false;
					}

					if (endDate != 0 && !TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(endDate)))
					{
						message = frePprECnd.ExtraConditionTitle + "�i�I�����j�̓��͂��s���ł��B";
						return false;
					}

					// �召�`�F�b�N
					if (startDate > 10101 && endDate > 10101)
					{
						if (startDate > endDate)
						{
							message = frePprECnd.ExtraConditionTitle + "�͈͎̔w�肪�s���ł��B";
							return false;
						}
					}
					break;
				}
				case 3:
				case 4:
				{
					// �K�{���ڃ`�F�b�N
					if (frePprECnd.NecessaryExtraCondCd == 1 && isNecessaryExtraCondCheck)
					{
						if ((startDate == 10101 || startDate == 0) && (endDate == 10101 || endDate == 0))
						{
							message = frePprECnd.ExtraConditionTitle + "�����͂���Ă��܂���B";
							return false;
						}
					}

					// �召�`�F�b�N
					if (startDate > 10101 && endDate > 10101)
					{
						if (startDate > endDate)
						{
							message = frePprECnd.ExtraConditionTitle + "�͈͎̔w�肪�s���ł��B";
							return false;
						}
					}
					break;
				}
			}

			return true;
		}
		#endregion
	}
}
