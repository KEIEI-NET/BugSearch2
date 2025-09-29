using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   StockDayMonthReportWork
	/// <summary>
	///                      �d�����񌎕񒊏o�������[�N���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �d�����񌎕񒊏o�������[�N���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/08/12  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class StockDayMonthReportWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h</summary>
		/// <remarks>(�z��)�@�S�Ўw���{""}</remarks>
		private string[] _depositStockSecCodeList;

		/// <summary>�d����R�[�h(�J�n)</summary>
		private Int32 _supplierCdSt;

		/// <summary>�d����R�[�h(�I��)</summary>
		private Int32 _supplierCdEd;

		/// <summary>�J�n�d����(���v)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _dayStockDateSt;

		/// <summary>�I���d����(���v)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _dayStockDateEd;

		/// <summary>�J�n�d����(�݌v)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _monthStockDateSt;

		/// <summary>�I���d����(�݌v)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _monthStockDateEd;


		/// public propaty name  :  EnterpriseCode
		/// <summary>��ƃR�[�h�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EnterpriseCode
		{
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  DepositStockSecCodeList
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// <value>(�z��)�@�S�Ўw���{""}</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string[] DepositStockSecCodeList
		{
			get{return _depositStockSecCodeList;}
			set{_depositStockSecCodeList = value;}
		}

		/// public propaty name  :  SupplierCdSt
		/// <summary>�d����R�[�h(�J�n)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d����R�[�h(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierCdSt
		{
			get{return _supplierCdSt;}
			set{_supplierCdSt = value;}
		}

		/// public propaty name  :  SupplierCdEd
		/// <summary>�d����R�[�h(�I��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d����R�[�h(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierCdEd
		{
			get{return _supplierCdEd;}
			set{_supplierCdEd = value;}
		}

		/// public propaty name  :  DayStockDateSt
		/// <summary>�J�n�d����(���v)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�d����(���v)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime DayStockDateSt
		{
			get{return _dayStockDateSt;}
			set{_dayStockDateSt = value;}
		}

		/// public propaty name  :  DayStockDateEd
		/// <summary>�I���d����(���v)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���d����(���v)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime DayStockDateEd
		{
			get{return _dayStockDateEd;}
			set{_dayStockDateEd = value;}
		}

		/// public propaty name  :  MonthStockDateSt
		/// <summary>�J�n�d����(�݌v)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�d����(�݌v)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime MonthStockDateSt
		{
			get{return _monthStockDateSt;}
			set{_monthStockDateSt = value;}
		}

		/// public propaty name  :  MonthStockDateEd
		/// <summary>�I���d����(�݌v)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���d����(�݌v)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime MonthStockDateEd
		{
			get{return _monthStockDateEd;}
			set{_monthStockDateEd = value;}
		}


		/// <summary>
		/// �d�����񌎕񒊏o�������[�N���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>StockDayMonthReportWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockDayMonthReportWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockDayMonthReportWork()
		{
		}

	}
}
