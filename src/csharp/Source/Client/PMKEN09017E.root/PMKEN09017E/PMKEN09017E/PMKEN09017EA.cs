using System;
using System.Data;
using System.Collections;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �i�Ԍ����T�u�N���X
	/// </summary>
	public class PartsSerchSub
	{
		# region �R���X�g���N�^�[
		/// <summary>
		///	���i�����R���g���[���[ �R���X�g���N�^�[
		/// </summary>
		public PartsSerchSub()
		{
		}
		# endregion

		# region �f�[�^�e�[�u���̗���쐬
		/// <summary>
		/// �f�[�^�e�[�u���̗���쐬
		/// </summary>
		/// <param name="columnName">��</param>
		/// <param name="type">�^</param>
		/// <param name="caption">�L���v�V����</param>
		/// <returns></returns>
		public static DataColumn CreateColumn(string columnName, Type type, string caption)
		{
			DataColumn dc = new DataColumn();

			dc.ColumnName = columnName;
			dc.DataType = type;
			dc.Caption = caption;

			return dc;
		}
		# endregion

	}
}
