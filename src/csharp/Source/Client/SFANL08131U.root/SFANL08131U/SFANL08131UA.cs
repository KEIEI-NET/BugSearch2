using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���R���[��������UI�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���R���[��������UI�ł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.03.30</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	public partial class SFANL08131UA : Panel
	{
		#region PrivateMember
		// �G���[���b�Z�[�W
		private StringBuilder _errorStr;
		#endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SFANL08131UA()
		{
			InitializeComponent();

			_errorStr = new StringBuilder();
		}
		#endregion

		#region Property
		/// <summary>
		/// �G���[���b�Z�[�W�擾����
		/// </summary>
		/// <returns></returns>
		public string GetErrorMessage
		{
			get { return _errorStr.ToString(); }
		}
		#endregion

		#region PublicMethod
		/// <summary>
		/// ���R���[����������ʕ\������
		/// </summary>
		/// <param name="frePprECndList">���R���[���o�����ݒ�}�X�^���X�g</param>
		/// <param name="frePExCndDList">���R���[���o�������׃}�X�^���X�g</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: ���R���[����������ʂ̕\�������ł��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.30</br>
		/// </remarks>
		public int FreePrintExtrUIShow(List<FrePprECnd> frePprECndList, List<FrePExCndD> frePExCndDList)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			frePprECndList.Sort(new FrePprECndComparer());

			List<FrePprECnd> wkFrePprECndList = frePprECndList.FindAll(
				delegate(FrePprECnd frePprECnd)
				{
					if (frePprECnd.UsedFlg == 1)
						return true;
					else
						return false;
				}
			);

			this.Show();

			this.SuspendLayout();
			try
			{
				List<Control> addControlList = SFANL08132CA.GetExtrSettingControl(wkFrePprECndList, frePExCndDList);
				if (addControlList != null && addControlList.Count > 0)
				{
					while (this.Controls.Count > 0)
						this.Controls[0].Dispose();

					foreach (Control addControl in addControlList)
					{
						if (addControl is IFreePrintUserControl)
						{
							this.Controls.Add(addControl);
							addControl.Dock = DockStyle.Top;
							addControl.BringToFront();
						}
					}
				}
			}
			catch (Exception ex)
			{
				_errorStr.Append("���R���[����������ʕ\�������ɂė�O���������܂����B");
				_errorStr.Append("\r\n").Append(ex.Message);

				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
			finally
			{
				this.ResumeLayout(true);
			}

			return status;
		}

		/// <summary>
		/// ���̓`�F�b�N����
		/// </summary>
		/// <param name="message">�s�����̃��b�Z�[�W</param>
		/// <param name="errorControl">�s�����̃R���g���[��</param>
		/// <param name="frePprECndList">���R���[���o�����ݒ�}�X�^���X�g</param>
		/// <param name="isNecessaryExtraCondCheck">�K�{�����`�F�b�N</param>
		/// <returns>�`�F�b�N����</returns>
		/// <remarks>
		/// <br>Note		: ���R���[����������ʂ̓��̓`�F�b�N�����ł��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.30</br>
		/// </remarks>
		public bool InputCheck(List<FrePprECnd> frePprECndList, out string message, out Control errorControl, bool isNecessaryExtraCondCheck)
		{
			message = string.Empty;
			errorControl = null;

			for (int ix = 0 ; ix != frePprECndList.Count ; ix++)
			{
				FrePprECnd frePprECnd = frePprECndList[ix];
				if (frePprECnd.UsedFlg == 1)
				{
					string controlName = SFANL08132CA.GetControlName(frePprECnd);
					if (this.Controls.ContainsKey(controlName))
					{
						IFreePrintUserControl iFreePrintUserControl = this.Controls[controlName] as IFreePrintUserControl;
						if (iFreePrintUserControl != null)
						{
							if (isNecessaryExtraCondCheck && frePprECnd.NecessaryExtraCondCd == 1)
							{
								if (!iFreePrintUserControl.InputCheck(out message, out errorControl, true))
									return false;
							}
							else
							{
								if (!iFreePrintUserControl.InputCheck(out message, out errorControl, false))
									return false;
							}
						}
					}
				}
			}
			return true;
		}

		/// <summary>
		/// ���R���[���o�����ݒ�}�X�^�擾����
		/// </summary>
		/// <param name="frePprECndList">���R���[���o�����ݒ�}�X�^���X�g</param>
		/// <remarks>
		/// <br>Note		: ��ʂ�莩�R���[���o�����ݒ�}�X�^���擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.30</br>
		/// </remarks>
		public void GetFrePprECndList(ref List<FrePprECnd> frePprECndList)
		{
			for (int ix = 0 ; ix != frePprECndList.Count ; ix++)
			{
				FrePprECnd frePprECnd = frePprECndList[ix];
				if (frePprECnd.UsedFlg == 1)
				{
					string controlName = SFANL08132CA.GetControlName(frePprECnd);
					if (this.Controls.ContainsKey(controlName))
					{
						IFreePrintUserControl iFreePrintUserControl = this.Controls[controlName] as IFreePrintUserControl;
						if (iFreePrintUserControl != null)
							iFreePrintUserControl.GetFrePprECndInfo(ref frePprECnd);
					}
				}
			}
		}
		#endregion
	}

	/// <summary>
	/// ���R���[���o������r�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���R���[���o����LIST�p�̔�r�N���X�ł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.03.30</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal class FrePprECndComparer : IComparer<FrePprECnd>
	{
		#region IComparer<FrePprECnd> �����o
		/// <summary>
		/// ��r����
		/// </summary>
		/// <param name="x">��r�Ώ�1</param>
		/// <param name="y">��r�Ώ�2</param>
		/// <returns>��r����</returns>
		public int Compare(FrePprECnd x, FrePprECnd y)
		{
			int retInt = x.DisplayOrder.CompareTo(y.DisplayOrder);
			if (retInt != 0)
				return retInt;
			else
				return x.FrePrtPprExtraCondCd.CompareTo(y.FrePrtPprExtraCondCd);
		}
		#endregion
	}
}