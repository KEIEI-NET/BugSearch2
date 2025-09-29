using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Broadleaf.Application.Resources;


namespace Broadleaf.Application.Common
{
	/// <summary>
	/// ���s���I�v�V�����擾�N���X
	/// </summary>
	internal class NsEMailSenderOption
	{
		private static string infoPath = Path.Combine(ConstantManagement_ClientDirectory.Temp_UserTemp, "NsEMailSender.xml");

		/// <summary>
		/// ���[�����M�I�v�V�������擾
		/// </summary>
		/// <param name="optionInfo">�I�v�V�������</param>
		/// <returns></returns>
		public static bool GetOptionInfo(out NsEMailSenderOptionInfo optionInfo)
		{
			optionInfo = null;

			if (UserSettingController.ExistUserSetting(infoPath))
			{
				try
				{
					optionInfo = UserSettingController.DeserializeUserSetting<NsEMailSenderOptionInfo>(infoPath);
					return true;
				}
				catch
				{
					;
				}
			}

			return false;
		}
	}

	/// <summary>
	/// ���s���I�v�V�������N���X
	/// </summary>
	/// <remarks>���s���I�v�V�����̐ݒ�f�[�^�N���X�ł�</remarks>
	public class NsEMailSenderOptionInfo
	{
		private bool _traceMode = false;
		private bool _traceLog = false;
		private string _traceLogPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), Path.Combine(ConstantManagement_ClientDirectory.Temp_UserTemp, "NsEMailSender_.log"));

		/// <summary>
		/// �g���[�X���[�h�v���p�e�B
		/// </summary>
		/// <value>True:�g���[�X���[�hON, False:�g���[�X���[�hOFF</value>
		public bool TraceMode
		{
			get { return this._traceMode; }
			set { this._traceMode = value; }
		}

		/// <summary>
		/// �g���[�X���O�v���p�e�B
		/// </summary>
		/// <value>True:���O�o�͂���, False:���O�o�͂��Ȃ�</value>
		public bool TraceLog
		{
			get { return this._traceLog; }
			set { this._traceLog = value; }
		}

		/// <summary>
		/// �g���[�X���O�p�X�v���p�e�B
		/// </summary>
		/// <value>�g���[�X���O�̏o�̓p�X</value>
		public string TraceLogPath
		{
			get { return this._traceLogPath; }
			set { ; }
		}
	}
}
