using System;
using System.Collections;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// �o�[�R�[�g�ҏW���i
	/// </summary>
	/// <remarks>
	/// <br>Note       : �o�[�R�[�h�ҏW�̊֐���񋟂��܂��B</br>
	/// <br>Programer  : 21027 �{��  ���u�Y</br>
	/// <br>Date       : 2005.12.20</br>
	/// <br></br>
	/// <br>Update Note: 2006.02.07  21027 �{��  ���u�Y</br>
	/// <br>           : �݌Ɏԗ��Ǘ��ԍ���ǉ�</br>
	/// <br>Update Note: 2006.09.22  21027 �{��  ���u�Y</br>
	/// <br>           : 1.TSP�@�\�敪�폜, TSP�@�\�敪�O���[�v�ǉ�</br>
	/// <br>           : 2.NSQR�R�[�h���菈���ǉ�</br>
	/// <br>           : 2006.11.30  20015 ���c�@�`��</br>
	/// <br>           : 1.�`�[QR�R�[�h����Ή�(��`�̒ǉ�)</br>
	/// <br>Update Note: 2006.12.21  21027 �{��  ���u�Y</br>
	/// <br>           : �݌ɕ��i�ԍ���ǉ�</br>
	/// <br>Update Note: 2007.08.16  21027 �{��  ���u�Y</br>
	/// <br>           : </br>
	/// </remarks>
	public class TBarcodeEditor
	{
		#region Public Members
		/* �V�K�ɃR�[�h��ǉ������ꍇ�͐ÓI�R���X�g���N�^���v�ύX!! */
		/// <summary>�o�[�R�[�h�ʒm�R�[�h����</summary>
		public static readonly char BarcodeNoticeCode			= '^';
		/// <summary>�o�[�R�[�h�f�[�^���̓V�X�e���F����</summary>
		public static readonly int BarcodeInputSys_ALL			= 0;
		/// <summary>�o�[�R�[�h�f�[�^���̓V�X�e���F����</summary>
		public static readonly int BarcodeInputSys_SF			= 1;
		/// <summary>�o�[�R�[�h�f�[�^���̓V�X�e���F���</summary>
		public static readonly int BarcodeInputSys_BK			= 2;
		/// <summary>�o�[�R�[�h�f�[�^���̓V�X�e���F�Ԕ�</summary>
		public static readonly int BarcodeInputSys_CS			= 3;

		/// <summary>�o�[�R�[�h�@�\�敪�F�`�[(�`�[�ԍ�)</summary>
		public static readonly int BarcodeFuncDiv_SlipNo		= 101;
		/// <summary>�o�[�R�[�h�@�\�敪�F�`�[(�󒍔ԍ�)</summary>
		public static readonly int BarcodeFuncDiv_AcceptNo		= 102;
		/// <summary>�o�[�R�[�h�@�\�敪�F�Z�b�g���</summary>
		public static readonly int BarcodeFuncDiv_SetWork		= 201;
		/// <summary>�o�[�R�[�h�@�\�敪�F���</summary>
		public static readonly int BarcodeFuncDiv_Work			= 202;
		/// <summary>�o�[�R�[�h�@�\�敪�F���i</summary>
		public static readonly int BarcodeFuncDiv_Parts			= 203;
		/// <summary>�o�[�R�[�h�@�\�敪�F�݌ɕ��i</summary>
		public static readonly int BarcodeFuncDiv_StockParts	= 210;
		/// <summary>�o�[�R�[�h�@�\�敪�F����p</summary>
		public static readonly int BarcodeFuncDiv_VarCost		= 301;
		/// <summary>�o�[�R�[�h�@�\�敪�F���Ӑ�</summary>
		public static readonly int BarcodeFuncDiv_Customer		= 401;
		/// <summary>�o�[�R�[�h�@�\�敪�F�ԗ��Ǘ��ԍ�</summary>
		public static readonly int BarcodeFuncDiv_CarMng		= 501;
		/// <summary>�o�[�R�[�h�@�\�敪�F�ԗ��Ǘ��ԍ�</summary>
		public static readonly int BarcodeFuncDiv_StockCarMng	= 502;
		/// <summary>�o�[�R�[�h�@�\�敪�FWEB���L�݌Ɏԗ�</summary>
		public static readonly int BarcodeFuncDiv_WebStockCar	= 503;		// 2007.08.16 Add T.Sugawa
		/// <summary>�o�[�R�[�h�@�\�敪�F�]�ƈ�</summary>
		public static readonly int BarcodeFuncDiv_Employee		= 601;
//		/// <summary>�o�[�R�[�h�@�\�敪�FTSP�I�t���C��</summary>
//		public static readonly int BarcodeFuncDiv_TSP			= 1001;

		/// <summary>�o�[�R�[�h�@�\�敪�O���[�v�FTSP�I�t���C��</summary>
		public static readonly int BarcodeFuncDivGrp_TSP		= 10;
		/// <summary>�o�[�R�[�h�@�\�敪�O���[�v�F�`�[QR���</summary>
		public static readonly int BarcodeFuncDivGrp_SlipPrt	= 20;


		/// <summary>�o�[�R�[�h�@�\�敪�F����R�[�h</summary>
		public static readonly int BarcodeFuncDiv_Ctrl			= 9901;
		#endregion

		#region Private Members
		// �o�[�R�[�h�f�[�^���̓V�X�e���p�e�[�u��
		private static Hashtable inputSysTable;
		// �o�[�R�[�h�@�\�敪�p�e�[�u��
		private static Hashtable funcDivTable;
		// �o�[�R�[�h�@�\�敪(�O���[�v�p)�e�[�u��
		private static Hashtable funcDivGrpTable;				// 2006.11.30 ���c Add

		// �o�[�R�[�h�ŏ�������
		private const int ctCodeMinLength = 6;
		#endregion

		#region Constructor
		/// <summary>
		/// �ÓI�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �o�[�R�[�g�ҏW���i�N���X�̐ÓI���������s���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.12.20</br>
		/// </remarks>
		static TBarcodeEditor()
		{
			// �o�[�R�[�h�f�[�^���̓V�X�e���p�e�[�u���쐬
			inputSysTable = new Hashtable(4);
			inputSysTable.Add(BarcodeInputSys_ALL, null);
			inputSysTable.Add(BarcodeInputSys_SF, null);
			inputSysTable.Add(BarcodeInputSys_BK, null);
			inputSysTable.Add(BarcodeInputSys_CS, null);

			// �o�[�R�[�h�@�\�敪�p�e�[�u���쐬
			funcDivTable = new Hashtable(13);
			funcDivTable.Add(BarcodeFuncDiv_SlipNo, null);
			funcDivTable.Add(BarcodeFuncDiv_AcceptNo, null);
			funcDivTable.Add(BarcodeFuncDiv_SetWork, null);
			funcDivTable.Add(BarcodeFuncDiv_Work, null);
			funcDivTable.Add(BarcodeFuncDiv_Parts, null);
			funcDivTable.Add(BarcodeFuncDiv_StockParts, null);			// 2006.12.21 Add T.Sugawa
			funcDivTable.Add(BarcodeFuncDiv_VarCost, null);
			funcDivTable.Add(BarcodeFuncDiv_Customer, null);
			funcDivTable.Add(BarcodeFuncDiv_CarMng, null);
			funcDivTable.Add(BarcodeFuncDiv_StockCarMng, null);
			funcDivTable.Add(BarcodeFuncDiv_WebStockCar, null);			// 2007.08.16 Add T.Sugawa
			funcDivTable.Add(BarcodeFuncDiv_Employee, null);
//			funcDivTable.Add(BarcodeFuncDiv_TSP, null);
			funcDivTable.Add(BarcodeFuncDiv_Ctrl, null);

// >>>> 2006.11.30 ���c Add �������� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
			// �o�[�R�[�h�@�\�敪(�O���[�v�p)�e�[�u���쐬
			funcDivGrpTable = new Hashtable(2);
			funcDivGrpTable.Add(BarcodeFuncDivGrp_TSP, null);
			funcDivGrpTable.Add(BarcodeFuncDivGrp_SlipPrt, null);
// <<<< 2006.11.30 ���c Add �����܂� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		}

		/// <summary>
		/// �f�t�H���g�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �o�[�R�[�g�ҏW���i�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.12.20</br>
		/// </remarks>
		public TBarcodeEditor()
		{
			// 
			// TODO: �R���X�g���N�^ ���W�b�N�������ɒǉ����Ă��������B
			//
		}
		#endregion

		#region Properties
		/// <summary>
		/// �m�菈���o�[�R�[�h
		/// </summary>
		public static string EnterBarcode
		{
			get
			{
				string retStr, dmyStr = "";
				CreateBarcode(out dmyStr, out retStr, BarcodeInputSys_ALL, BarcodeFuncDiv_Ctrl, "{0:d3}", 0);
				return retStr;
			}
		}

		/// <summary>
		/// �L�����Z�������o�[�R�[�h
		/// </summary>
		public static string CancelBarcode
		{
			get
			{
				string retStr, dmyStr = "";
				CreateBarcode(out dmyStr, out retStr, BarcodeInputSys_ALL, BarcodeFuncDiv_Ctrl, "{0:d3}", 1);
				return retStr;
			}
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// �o�[�R�[�h�쐬����
		/// </summary>
		/// <param name="barcode">�쐬�o�[�R�[�h������</param>
		/// <param name="inputSys">�o�[�R�[�h�f�[�^���̓V�X�e��</param>
		/// <param name="funcDiv">�o�[�R�[�h�@�\�敪</param>
		/// <param name="code">�o�[�R�[�h�v�f������</param>
		/// <returns>�X�e�[�^�X(true:����, false:���s)</returns>
		/// <remarks>
		/// <br>Note       : �o�[�R�[�h�ʒm�R�[�h�t�̃o�[�R�[�h��������쐬���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.12.20</br>
		/// </remarks>
		public static bool CreateBarcode(out string barcode, int inputSys, int funcDiv, string code)
		{
			barcode = "";

			if (!inputSysTable.Contains(inputSys) || !(funcDivTable.Contains(funcDiv)))
			{
				return false;
			}

			barcode = String.Format("{0}{1:d2}{2:d4}{3}", BarcodeNoticeCode, inputSys, funcDiv, code);

			return true;
		}

		/// <summary>
		/// �o�[�R�[�h�쐬����
		/// </summary>
		/// <param name="barcode">�쐬�o�[�R�[�h������</param>
		/// <param name="dispBarCode">�\���p�o�[�R�[�h������</param>
		/// <param name="inputSys">�o�[�R�[�h�f�[�^���̓V�X�e��</param>
		/// <param name="funcDiv">�o�[�R�[�h�@�\�敪</param>
		/// <param name="code">�o�[�R�[�h�v�f������</param>
		/// <returns>�X�e�[�^�X(true:����, false:���s)</returns>
		/// <remarks>
		/// <br>Note       : �o�[�R�[�h�ʒm�R�[�h�t�̃o�[�R�[�h��������쐬���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.12.20</br>
		/// </remarks>
		public static bool CreateBarcode(out string barcode, out string dispBarCode, int inputSys, int funcDiv, string code)
		{
			barcode = "";
			dispBarCode = "";

			if (!inputSysTable.Contains(inputSys) || !(funcDivTable.Contains(funcDiv)))
			{
				return false;
			}

			barcode = String.Format("{0}{1:d2}{2:d4}{3}", BarcodeNoticeCode, inputSys, funcDiv, code);
			dispBarCode = String.Format("{1:d2}{2:d4}{3}", BarcodeNoticeCode, inputSys, funcDiv, code);

			return true;
		}
		
		/// <summary>
		/// �o�[�R�[�h�쐬����
		/// </summary>
		/// <param name="barcode">�쐬�o�[�R�[�h������</param>
		/// <param name="inputSys">�o�[�R�[�h�f�[�^���̓V�X�e��</param>
		/// <param name="funcDiv">�o�[�R�[�h�@�\�敪</param>
		/// <param name="format">����������</param>
		/// <param name="code">�o�[�R�[�h�v�f</param>
		/// <returns>�X�e�[�^�X(true:����, false:���s)</returns>
		/// <remarks>
		/// <br>Note       : �����t�Ńo�[�R�[�h�ʒm�R�[�h�t�̃o�[�R�[�h��������쐬���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.12.20</br>
		/// </remarks>
		public static bool CreateBarcode(out string barcode, int inputSys, int funcDiv, string format, object code)
		{
			string wkCodeStr = "";
			barcode = "";
			try
			{
				wkCodeStr = String.Format(format, code);
			}
			catch (Exception)
			{
				return false;
			}

			return CreateBarcode(out barcode, inputSys, funcDiv, wkCodeStr);
		}

		/// <summary>
		/// �o�[�R�[�h�쐬����
		/// </summary>
		/// <param name="barcode">�쐬�o�[�R�[�h������</param>
		/// <param name="dispBarCode">�\���p�o�[�R�[�h������</param>
		/// <param name="inputSys">�o�[�R�[�h�f�[�^���̓V�X�e��</param>
		/// <param name="funcDiv">�o�[�R�[�h�@�\�敪</param>
		/// <param name="format">����������</param>
		/// <param name="code">�o�[�R�[�h�v�f</param>
		/// <returns>�X�e�[�^�X(true:����, false:���s)</returns>
		/// <remarks>
		/// <br>Note       : �����t�Ńo�[�R�[�h�ʒm�R�[�h�t�̃o�[�R�[�h��������쐬���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.12.20</br>
		/// </remarks>
		public static bool CreateBarcode(out string barcode, out string dispBarCode, int inputSys, int funcDiv, string format, object code)
		{
			string wkCodeStr = "";
			barcode = "";
			dispBarCode = "";

			try
			{
				wkCodeStr = String.Format(format, code);
			}
			catch (Exception)
			{
				return false;
			}

			return CreateBarcode(out barcode, out dispBarCode, inputSys, funcDiv, wkCodeStr);
		}

		/// <summary>
		/// QR�R�[�h�p�o�[�R�[�h�쐬����
		/// </summary>
		/// <param name="barcode">�쐬�o�[�R�[�h������</param>
		/// <param name="inputSys">�f�[�^���̓V�X�e��</param>
		/// <param name="funcDivGrp">�o�[�R�[�h�O���[�v�R�[�h</param>
		/// <param name="funcDivSubCd">�o�[�R�[�h�O���[�v�T�u�R�[�h</param>
		/// <param name="code">�o�[�R�[�h�v�f</param>
		/// <returns>�X�e�[�^�X(true:����, false:���s)</returns>
		/// <remarks>
		/// <br>Note       : QR�R�[�h�p�̃o�[�R�[�h������𐶐����܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y AND 20015 ���c�@�`��</br>
		/// <br>Date       : 2006.11.30</br>
		/// </remarks>
		public static bool CreateNSQRCode(out string barcode, int inputSys, int funcDivGrp, int funcDivSubCd, string code)
		{
			barcode = "";

			if (!inputSysTable.Contains(inputSys) || !(funcDivGrpTable.Contains(funcDivGrp)) || (funcDivSubCd >= 100))
			{
				return false;
			}

			barcode = String.Format("{0}{1:d2}{2:d2}{3:d2}{4}", BarcodeNoticeCode, inputSys, funcDivGrp, funcDivSubCd, code);

			return true;
		}

		/// <summary>
		/// �o�[�R�[�h��͏����i���̓V�X�e���Ƌ@�\�敪�j
		/// </summary>
		/// <param name="barcode">��̓o�[�R�[�h������</param>
		/// <param name="inputSys">�o�[�R�[�h�f�[�^���̓V�X�e��</param>
		/// <param name="funcDiv">�o�[�R�[�h�@�\�敪</param>
		/// <returns>�X�e�[�^�X(true:����, false:���s)</returns>
		/// <remarks>
		/// <br>Note       : �o�[�R�[�g���������͂��āA�o�[�R�[�h�����擾���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.12.20</br>
		/// </remarks>
		public static bool AnalyzeBarcode(string barcode, out int inputSys, out int funcDiv)
		{
			inputSys = -1;
			funcDiv = -1;

			// �ŏ�������`�F�b�N
			if (barcode.Length <= ctCodeMinLength) return false;

			try
			{
				string wkInputSysStr = barcode.Substring(0, 2);
				string wkFuncDivStr = barcode.Substring(2, 4);

				inputSys = Convert.ToInt32(wkInputSysStr);
				funcDiv = Convert.ToInt32(wkFuncDivStr);

				// ��`�ς݃R�[�h����
				if (!inputSysTable.Contains(inputSys) || !(funcDivTable.Contains(funcDiv)))
				{
//-- 2006.09.21 Add Start by T.Sugawa ------------------------------------------------------------//
					if (IsNSQRCode(barcode) > 0)
					{
						return true;
					}
//-- 2006.09.21 Add End by T.Sugawa --------------------------------------------------------------//

					inputSys = -1;
					funcDiv = -1;
					return false;
				}
			}
			catch (Exception)
			{
				inputSys = -1;
				funcDiv = -1;
				return false;
			}

			return true;
		}

		/// <summary>
		/// �o�[�R�[�h��͏����i������R�[�h�j
		/// </summary>
		/// <param name="barcode">��̓o�[�R�[�h������</param>
		/// <param name="inputSys">�o�[�R�[�h�f�[�^���̓V�X�e��</param>
		/// <param name="funcDiv">�o�[�R�[�h�@�\�敪</param>
		/// <param name="code">�o�[�R�[�h�v�f������</param>
		/// <returns>�X�e�[�^�X(true:����, false:���s)</returns>
		/// <remarks>
		/// <br>Note       : �o�[�R�[�g���������͂��āA�o�[�R�[�h�����擾���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.12.20</br>
		/// </remarks>
		public static bool AnalyzeBarcode(string barcode, out int inputSys, out int funcDiv, out string code)
		{
			inputSys = -1;
			funcDiv = -1;
			code = "";

			try
			{
				if (AnalyzeBarcode(barcode, out inputSys, out funcDiv))
				{
					code = barcode.Substring(6, barcode.Length - 6);
				}
				else
				{
					return false;
				}
			}
			catch (Exception)
			{
				inputSys = -1;
				funcDiv = -1;
				code = "";
				return false;
			}

			return true;
		}

		/// <summary>
		/// �o�[�R�[�h��͏����i���l�R�[�h�j
		/// </summary>
		/// <param name="barcode">��̓o�[�R�[�h������</param>
		/// <param name="inputSys">�o�[�R�[�h�f�[�^���̓V�X�e��</param>
		/// <param name="funcDiv">�o�[�R�[�h�@�\�敪</param>
		/// <param name="code">�o�[�R�[�h�v�f���l</param>
		/// <returns>�X�e�[�^�X(true:����, false:���s)</returns>
		/// <remarks>
		/// <br>Note       : �o�[�R�[�g���������͂��āA�o�[�R�[�h�����擾���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.12.20</br>
		/// </remarks>
		public static bool AnalyzeBarcode(string barcode, out int inputSys, out int funcDiv, out int code)
		{
			string codeStr;
			inputSys = -1;
			funcDiv = -1;
			code = 0;

			try
			{
				if (AnalyzeBarcode(barcode, out inputSys, out funcDiv, out codeStr))
				{
					code = Convert.ToInt32(codeStr.Trim());
				}
				else
				{
					code = 0;
					return false;
				}
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// �o�[�R�[�h���̓V�X�e���擾����
		/// </summary>
		/// <param name="barcode">��̓o�[�R�[�h������</param>
		/// <returns>�o�[�R�[�h���̓V�X�e��(�擾���s��-1)</returns>
		/// <remarks>
		/// <br>Note       : �o�[�R�[�g���������͂��āA�o�[�R�[�h���̓V�X�e�����擾���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.12.20</br>
		/// </remarks>
		public static int GetInputSys(string barcode)
		{
			int inputSys = -1, funcDiv = -1;

			if (!AnalyzeBarcode(barcode, out inputSys, out funcDiv))
			{
				return -1;
			}

			return inputSys;
		}

		/// <summary>
		/// �o�[�R�[�h�@�\�敪�擾����
		/// </summary>
		/// <param name="barcode">��̓o�[�R�[�h������</param>
		/// <returns>�o�[�R�[�h�@�\�敪(�擾���s��-1)</returns>
		/// <remarks>
		/// <br>Note       : �o�[�R�[�g���������͂��āA�o�[�R�[�h�@�\�敪���擾���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.12.20</br>
		/// </remarks>
		public static int GetFunkDiv(string barcode)
		{
			int inputSys = -1, funcDiv = -1;

			if (!AnalyzeBarcode(barcode, out inputSys, out funcDiv))
			{
				return -1;
			}

			return funcDiv;
		}

		/// <summary>
		/// NSQR�R�[�h���菈��
		/// </summary>
		/// <param name="barcode">��̓o�[�R�[�h������</param>
		/// <returns>NSQR�R�[�h�@�\�敪�O���[�v(-1:�擾���s, 0:NSQR�R�[�h�ȊO)</returns>
		/// <remarks>
		/// <br>Note       : �o�[�R�[�g���������͂��āANSQR�R�[�h�̏ꍇ�͋@�\�敪�O���[�v�R�[�h��Ԃ��܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2006.09.22</br>
		/// </remarks>
		public static int IsNSQRCode(string barcode)
		{
			try
			{
				// �ŏ�������`�F�b�N
				if (barcode.Length > ctCodeMinLength)
				{
					int inputSys = Convert.ToInt32(barcode.Substring(0, 2));
					int funcDiv = Convert.ToInt32(barcode.Substring(2, 4));

					// TSP�I�t���C���pQR�R�[�h�`�F�b�N(1000�`1012�܂ł��L��)
					if ((funcDiv >= 1000) && (funcDiv <= 1012))
					{
						return funcDiv / 100;
					}
// >>>> 2006.11.30 ���c Add �������� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
					if ((funcDiv >= 2000) && (funcDiv <= 2012))
					{
						return funcDiv / 100;
					}
// <<<< 2006.11.30 ���c Add �����܂� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

				}
			}
			catch (Exception)
			{
				return -1;
			}

			return 0;
		}
		#endregion
	}
}
