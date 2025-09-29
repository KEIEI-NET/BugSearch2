using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// �݌ɕ��i�p�o�[�R�[�h�ҏW���i
	/// </summary>
	/// <remarks>
	/// <br>Note       : �݌ɕ��i�p�Ƀo�[�R�[�h�ҏW�̊֐���񋟂��܂��B</br>
	/// <br>Programer  : 21027 �{��  ���u�Y</br>
	/// <br>Date       : 2007.01.15</br>
	/// </remarks>
	public class StockPartsBarcodeEditor
	{
		/// <summary>
		/// �o�[�R�[�h�쐬����
		/// </summary>
		/// <param name="barcode">�쐬�o�[�R�[�h������</param>
		/// <param name="stockPartsMakerCd">�݌ɕ��i�p���[�J�[�R�[�h</param>
		/// <param name="stckWithHyphenPartNo">�݌ɕ��i�p�n�C�t���t�i��</param>
		/// <returns>�X�e�[�^�X(true:����, false:���s)</returns>
		public static bool CreateBarcode(out string barcode, int stockPartsMakerCd, string stckWithHyphenPartNo)
		{
			barcode = "";

			barcode =
				String.Format("{0}{1:d2}{2:d4}{3:d4}{4}",
					TBarcodeEditor.BarcodeNoticeCode,
					TBarcodeEditor.BarcodeInputSys_ALL,
					TBarcodeEditor.BarcodeFuncDiv_StockParts,
					stockPartsMakerCd,
					stckWithHyphenPartNo);

			return true;
		}

#if false	// 2007.01.15 ���̂Ƃ���s�v�̈�,������
		/// <summary>
		/// �o�[�R�[�h�쐬����
		/// </summary>
		/// <param name="barcode">�쐬�o�[�R�[�h������</param>
		/// <param name="dispBarCode">�\���p�o�[�R�[�h������</param>
		/// <param name="stockPartsMakerCd">�݌ɕ��i�p���[�J�[�R�[�h</param>
		/// <param name="stckWithHyphenPartNo">�݌ɕ��i�p�n�C�t���t�i��</param>
		/// <returns>�X�e�[�^�X(true:����, false:���s)</returns>
		public static bool CreateBarcode(out string barcode, out string dispBarCode, int stockPartsMakerCd, string stckWithHyphenPartNo)
		{
			barcode = "";
			dispBarCode = "";

			barcode =
				String.Format("{0}{1:d2}{2:d4}{3:d4}{4}",
					TBarcodeEditor.BarcodeNoticeCode,
					TBarcodeEditor.BarcodeInputSys_ALL,
					TBarcodeEditor.BarcodeFuncDiv_StockParts,
					stockPartsMakerCd,
					stckWithHyphenPartNo);

			dispBarCode =
				String.Format("{1:d2}{2:d4}{3:d4}{4}",
					TBarcodeEditor.BarcodeNoticeCode,
					TBarcodeEditor.BarcodeInputSys_ALL,
					TBarcodeEditor.BarcodeFuncDiv_StockParts,
					stockPartsMakerCd,
					stckWithHyphenPartNo);

			return true;
		}
#endif

		/// <summary>
		/// �o�[�R�[�h��͏����i���l�R�[�h�j
		/// </summary>
		/// <param name="barcode">��̓o�[�R�[�h������</param>
		/// <param name="stockPartsMakerCd">�d���݌ɗp���i���[�J�[�R�[�h</param>
		/// <param name="stckWithHyphenPartNo">�d���݌ɗp�n�C�t���t���i�i��</param>
		/// <returns>�X�e�[�^�X(true:����, false:���s)</returns>
		/// <remarks>
		/// <br>Note       : �o�[�R�[�g���������͂��āA�݌ɕ��i�p�Ƀ��[�J�[�R�[�h�ƕ��i�i�Ԃ��擾���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.12.20</br>
		/// </remarks>
		public static bool AnalyzeBarcode(string barcode, out int stockPartsMakerCd, out string stckWithHyphenPartNo)
		{
			string codeStr;
			int inputSys = -1;
			int funcDiv = -1;

			stockPartsMakerCd = 0;
			stckWithHyphenPartNo = "";

			try
			{
				if (TBarcodeEditor.AnalyzeBarcode(barcode, out inputSys, out funcDiv, out codeStr))
				{
					if (funcDiv != TBarcodeEditor.BarcodeFuncDiv_StockParts)
					{
						// �@�\�敪���݌ɕ��i�ȊO�͎��s
						return false;
					}
					else
					{
						// ���[�J�[�R�[�h�擾
						if (!Int32.TryParse(codeStr.Substring(0, 4), out stockPartsMakerCd))
						{
							return false;
						}

						// �i�Ԏ擾
						stckWithHyphenPartNo = codeStr.Substring(4);
					}
				}
				else
				{
					return false;
				}
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}
	}
}
