using System;
using System.IO;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �d��DX�ʒm�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note        : �d��DX�ʒm�ݒ�̃f�[�^������s���܂��B</br>
	/// <br>Programmer  : 32281 ���� �Ȍ�</br>
	/// <br>Date        : 2023.12.20</br>
	/// </remarks>
	public class EBookLinkSettingsNtcSetAcs
	{
		#region Public Methods
		/// <summary>
		/// �d��DX�ʒm���Ǎ�����
		/// </summary>
		/// <param name="settingInfo">�d��DX�ʒm���</param>
		/// <returns>�X�e�[�^�X</returns>
		public int ReadSettingInfo(out EBookLinkSettingsNtcSet settingInfo)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			settingInfo = null;
			// �ݒ�t�@�C���̃t���p�X
			string fullPath = Path.Combine(ConstantManagement_ClientDirectory.UISettings, EBookLinkSettingsNtcHelper.CT_FILE_SETTING);
			if (UserSettingController.ExistUserSetting(fullPath))
			{
				try
				{
					// �d��DX�ʒm�����f�V���A���C�Y����
					settingInfo = UserSettingController.DeserializeUserSetting<EBookLinkSettingsNtcSet>(fullPath);
					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
				catch (Exception)
				{
					settingInfo = null;
					
				}
			}
			return status;
		}

		/// <summary>
		/// �ʒm��񏑍�����
		/// </summary>
		/// <param name="settingInfo">�d��DX�ʒm���</param>
		/// <returns>�X�e�[�^�X</returns>
		public int WriteSettingInfo(ref EBookLinkSettingsNtcSet settingInfo)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			// �ݒ�t�@�C���̃t���p�X
			string fullPath = Path.Combine(ConstantManagement_ClientDirectory.UISettings, EBookLinkSettingsNtcHelper.CT_FILE_SETTING);
			try
			{
				//�d��DX�ʒm�����V���A���C�Y����
				UserSettingController.SerializeUserSetting(settingInfo, fullPath);
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (Exception)
			{
				// �Ȃ�
			}
			return status;
		}
		#endregion
	}
}
