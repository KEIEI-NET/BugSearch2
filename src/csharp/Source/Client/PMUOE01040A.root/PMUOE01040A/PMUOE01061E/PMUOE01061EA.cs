using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   OrderLsthead
	/// <summary>
	///                      �����ꗗ�N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   �����ꗗ�N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2009/05/27  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class OrderLsthead
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private String _enterpriseCode;

		/// <summary>���_�R�[�h</summary>
		private String _sectionCode;

		/// <summary>UOE������R�[�h</summary>
		private Int32 _uOESupplierCd;

		/// <summary>�b�r�u���</summary>
		private Int32 _csvKnd;

		/// <summary>�b�r�u�t�@�C����</summary>
		private String _csvName;

		/// <summary>�b�r�u�t���p�X��</summary>
		private String _csvFullPath;

		/// <summary>�����ꗗ���׃N���X</summary>
		private ArrayList _lstDtl;

		/// <summary>�X�V����</summary>
		/// <remarks>9:������(�����ݒ�) 0:����I�� 1:�O�񐿋����Z�o�G���[ 2:�O�񏀔������ȑO 3:�捞�� -1:�ُ�I��</remarks>
		private Int32 _updRsl;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";


		/// public propaty name  :  EnterpriseCode
		/// <summary>��ƃR�[�h�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public String EnterpriseCode
		{
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  SectionCode
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public String SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

		/// public propaty name  :  UOESupplierCd
		/// <summary>UOE������R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   UOE������R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UOESupplierCd
		{
			get{return _uOESupplierCd;}
			set{_uOESupplierCd = value;}
		}

		/// public propaty name  :  CsvKnd
		/// <summary>�b�r�u��ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �b�r�u��ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CsvKnd
		{
			get{return _csvKnd;}
			set{_csvKnd = value;}
		}

		/// public propaty name  :  CsvName
		/// <summary>�b�r�u�t�@�C�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �b�r�u�t�@�C�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public String CsvName
		{
			get{return _csvName;}
			set{_csvName = value;}
		}

		/// public propaty name  :  CsvFullPath
		/// <summary>�b�r�u�t���p�X���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �b�r�u�t���p�X���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public String CsvFullPath
		{
			get{return _csvFullPath;}
			set{_csvFullPath = value;}
		}

		/// public propaty name  :  LstDtl
		/// <summary>�����ꗗ���׃N���X�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����ꗗ���׃N���X�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList LstDtl
		{
			get{return _lstDtl;}
			set{_lstDtl = value;}
		}

		/// public propaty name  :  UpdRsl
		/// <summary>�X�V���ʃv���p�e�B</summary>
		/// <value>9:������(�����ݒ�) 0:����I�� 1:�O�񐿋����Z�o�G���[ 2:�O�񏀔������ȑO 3:�捞�� -1:�ُ�I��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UpdRsl
		{
			get{return _updRsl;}
			set{_updRsl = value;}
		}

		/// public propaty name  :  EnterpriseName
		/// <summary>��Ɩ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��Ɩ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EnterpriseName
		{
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
		}


		/// <summary>
		/// �����ꗗ�N���X�R���X�g���N�^
		/// </summary>
		/// <returns>OrderLsthead�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   OrderLsthead�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public OrderLsthead()
		{
		}

		/// <summary>
		/// �����ꗗ�N���X�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="uOESupplierCd">UOE������R�[�h</param>
		/// <param name="csvKnd">�b�r�u���</param>
		/// <param name="csvName">�b�r�u�t�@�C����</param>
		/// <param name="csvFullPath">�b�r�u�t���p�X��</param>
		/// <param name="lstDtl">�����ꗗ���׃N���X</param>
		/// <param name="updRsl">�X�V����(9:������(�����ݒ�) 0:����I�� 1:�O�񐿋����Z�o�G���[ 2:�O�񏀔������ȑO 3:�捞�� -1:�ُ�I��)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <returns>OrderLsthead�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   OrderLsthead�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public OrderLsthead(String enterpriseCode,String sectionCode,Int32 uOESupplierCd,Int32 csvKnd,String csvName,String csvFullPath,ArrayList lstDtl,Int32 updRsl,string enterpriseName)
		{
			this._enterpriseCode = enterpriseCode;
			this._sectionCode = sectionCode;
			this._uOESupplierCd = uOESupplierCd;
			this._csvKnd = csvKnd;
			this._csvName = csvName;
			this._csvFullPath = csvFullPath;
			this._lstDtl = lstDtl;
			this._updRsl = updRsl;
			this._enterpriseName = enterpriseName;

		}

		/// <summary>
		/// �����ꗗ�N���X��������
		/// </summary>
		/// <returns>OrderLsthead�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����OrderLsthead�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public OrderLsthead Clone()
		{
			return new OrderLsthead(this._enterpriseCode,this._sectionCode,this._uOESupplierCd,this._csvKnd,this._csvName,this._csvFullPath,this._lstDtl,this._updRsl,this._enterpriseName);
		}

		/// <summary>
		/// �����ꗗ�N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�OrderLsthead�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   OrderLsthead�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(OrderLsthead target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SectionCode == target.SectionCode)
				 && (this.UOESupplierCd == target.UOESupplierCd)
				 && (this.CsvKnd == target.CsvKnd)
				 && (this.CsvName == target.CsvName)
				 && (this.CsvFullPath == target.CsvFullPath)
				 && (this.LstDtl == target.LstDtl)
				 && (this.UpdRsl == target.UpdRsl)
				 && (this.EnterpriseName == target.EnterpriseName));
		}

		/// <summary>
		/// �����ꗗ�N���X��r����
		/// </summary>
		/// <param name="orderLsthead1">
		///                    ��r����OrderLsthead�N���X�̃C���X�^���X
		/// </param>
		/// <param name="orderLsthead2">��r����OrderLsthead�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   OrderLsthead�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(OrderLsthead orderLsthead1, OrderLsthead orderLsthead2)
		{
			return ((orderLsthead1.EnterpriseCode == orderLsthead2.EnterpriseCode)
				 && (orderLsthead1.SectionCode == orderLsthead2.SectionCode)
				 && (orderLsthead1.UOESupplierCd == orderLsthead2.UOESupplierCd)
				 && (orderLsthead1.CsvKnd == orderLsthead2.CsvKnd)
				 && (orderLsthead1.CsvName == orderLsthead2.CsvName)
				 && (orderLsthead1.CsvFullPath == orderLsthead2.CsvFullPath)
				 && (orderLsthead1.LstDtl == orderLsthead2.LstDtl)
				 && (orderLsthead1.UpdRsl == orderLsthead2.UpdRsl)
				 && (orderLsthead1.EnterpriseName == orderLsthead2.EnterpriseName));
		}
		/// <summary>
		/// �����ꗗ�N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�OrderLsthead�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   OrderLsthead�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(OrderLsthead target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.UOESupplierCd != target.UOESupplierCd)resList.Add("UOESupplierCd");
			if(this.CsvKnd != target.CsvKnd)resList.Add("CsvKnd");
			if(this.CsvName != target.CsvName)resList.Add("CsvName");
			if(this.CsvFullPath != target.CsvFullPath)resList.Add("CsvFullPath");
			if(this.LstDtl != target.LstDtl)resList.Add("LstDtl");
			if(this.UpdRsl != target.UpdRsl)resList.Add("UpdRsl");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}

		/// <summary>
		/// �����ꗗ�N���X��r����
		/// </summary>
		/// <param name="orderLsthead1">��r����OrderLsthead�N���X�̃C���X�^���X</param>
		/// <param name="orderLsthead2">��r����OrderLsthead�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   OrderLsthead�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(OrderLsthead orderLsthead1, OrderLsthead orderLsthead2)
		{
			ArrayList resList = new ArrayList();
			if(orderLsthead1.EnterpriseCode != orderLsthead2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(orderLsthead1.SectionCode != orderLsthead2.SectionCode)resList.Add("SectionCode");
			if(orderLsthead1.UOESupplierCd != orderLsthead2.UOESupplierCd)resList.Add("UOESupplierCd");
			if(orderLsthead1.CsvKnd != orderLsthead2.CsvKnd)resList.Add("CsvKnd");
			if(orderLsthead1.CsvName != orderLsthead2.CsvName)resList.Add("CsvName");
			if(orderLsthead1.CsvFullPath != orderLsthead2.CsvFullPath)resList.Add("CsvFullPath");
			if(orderLsthead1.LstDtl != orderLsthead2.LstDtl)resList.Add("LstDtl");
			if(orderLsthead1.UpdRsl != orderLsthead2.UpdRsl)resList.Add("UpdRsl");
			if(orderLsthead1.EnterpriseName != orderLsthead2.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}
	}
}
