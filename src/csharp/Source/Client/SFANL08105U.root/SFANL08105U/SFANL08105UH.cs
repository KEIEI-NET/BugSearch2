using System;
using System.Text;
using System.Collections.Generic;

using Broadleaf.Library.Text;
using Broadleaf.Application.Remoting.ParamData;

using DataDynamics.ActiveReports;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���R���[�󎚈ʒu�ݒ��ʗp�e�틤�ʐ��䕔�i
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���R���[�󎚈ʒu�ݒ��ʂŎg�p���鋤�ʕ��i�ł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.06.06</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal static class SFANL08105UH
	{
		#region Const
		public const string ctASSEMBLY_ID = "SFANL08105U";	// �A�Z���u��ID
		#endregion

		#region PublicMethod
		/// <summary>
		/// ���l���̓`�F�b�N����
		/// </summary>
		/// <param name="keta">����(�}�C�i�X�������܂܂�)</param>
		/// <param name="priod">�����_�ȉ�����</param>
		/// <param name="prevVal">���݂̕�����</param>
		/// <param name="key">���͂��ꂽ�L�[�l</param>
		/// <param name="selstart">�J�[�\���ʒu</param>
		/// <param name="sellength">�I�𕶎���</param>
		/// <param name="minusFlg">�}�C�i�X���͉H</param>
		/// <returns>true=���͉�,false=���͕s��</returns>
		/// <remarks>
		/// <br>Note		: ���l���͒l�̑Ó����`�F�b�N���s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.04.18</br>
		/// </remarks>
		public static bool KeyPressCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
		{
			// ����L�[�������ꂽ�H
			if (Char.IsControl(key) == true)
			{
				return true;
			}
			// ���l�ȊO�́A�m�f
			if (Char.IsNumber(key) == false)
			{
				// �����_�܂��́A�}�C�i�X�ȊO
				if ((key != '.') && (key != '-'))
				{
					return false;
				}
			}

			// �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
			string strResult = "";
			if (sellength > 0)
			{
				strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
			}
			else
			{
				strResult = prevVal;
			}

			// �}�C�i�X�̃`�F�b�N
			if (key == '-')
			{
				if ((minusFlg == false) || (selstart > 0) || (strResult.IndexOf('-') != -1))
				{
					return false;
				}
			}

			// �����_�̃`�F�b�N
			if (key == '.')
			{
				if ((priod <= 0) || (strResult.IndexOf('.') != -1))
				{
					return false;
				}
			}
			// �L�[�������ꂽ���ʂ̕�����𐶐�����B
			strResult = prevVal.Substring(0, selstart)
				+ key
				+ prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

			// �����`�F�b�N�I
			if (strResult.Length > keta)
			{
				if (strResult[0] == '-')
				{
					if (strResult.Length > (keta + 1))
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}

			// �����_�ȉ��̃`�F�b�N
			if (priod > 0)
			{
				// �����_�̈ʒu����
				int pointPos = strResult.IndexOf('.');

				// �������ɓ��͉\�Ȍ���������I
				int _Rketa = (strResult[0] == '-') ? keta - priod : keta - priod - 1;
				// �������̌������`�F�b�N
				if (pointPos != -1)
				{
					if (pointPos > _Rketa)
					{
						return false;
					}
				}
				else
				{
					if (strResult.Length > _Rketa)
					{
						return false;
					}
				}

				// �������̌������`�F�b�N
				if (pointPos != -1)
				{
					// �������̌������v�Z
					int priketa = strResult.Length - pointPos - 1;
					if (priod < priketa)
					{
						return false;
					}
				}
			}
			return true;
		}
		#endregion
	}
}
