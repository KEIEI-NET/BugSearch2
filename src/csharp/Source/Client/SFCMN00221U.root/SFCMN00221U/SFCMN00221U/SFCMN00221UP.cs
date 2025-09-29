using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
	internal class SliderCommonLib
	{
		public SliderCommonLib(Encoding sjisEnc)
		{
			_sjisEnc = sjisEnc;
		}

		private Encoding _sjisEnc;

		/// <summary>
		/// ������E������
		/// </summary>
		/// <param name="totalLength">�ő僌���O�X</param>
		/// <param name="sourceString">��������</param>
		/// <param name="paddingChar">�ǉ�����</param>
		/// <returns>�ҏW�㕶����</returns>
		internal string PadRight(int totalLength, string sourceString, char paddingChar)
		{
			int currentLength = this._sjisEnc.GetByteCount(sourceString.Trim());

			StringBuilder builder = new StringBuilder(sourceString);

			for (int i = currentLength; i < totalLength; i++)
			{
				builder.Append(paddingChar);
			}

			return builder.ToString();
		}

		/// <summary>
		/// �d���`�����̎擾����
		/// </summary>
		/// <param name="searchRetStockSlip">�d�������߂�l�N���X</param>
		/// <returns>�d���`������</returns>
		internal static string GetSupplierFormalName(SearchRetStockSlip searchRetStockSlip)
		{
			// �d���`������
			string supplierFormalName = "";
			if (searchRetStockSlip.SupplierFormal == 1)
			{
				supplierFormalName = "����";
			}
			else
			{
				supplierFormalName = "�d��";
			}
			if (searchRetStockSlip.SupplierSlipCd == 20)
			{
				supplierFormalName += "(�ԕi)";
			}

			return supplierFormalName;
		}
	}
}
