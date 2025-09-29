using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   BuyOutLsthead
	/// <summary>
	///                         �N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   ����ꗗ�N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2009/05/27  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class BuyOutLsthead
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private String _enterpriseCode;

		/// <summary>���_�R�[�h</summary>
		private String _sectionCode;

		/// <summary>UOE������R�[�h</summary>
		private Int32 _uOESupplierCd;

		/// <summary>�b�r�u���</summary>
		/// <remarks>0�Œ�</remarks>
		private Int32 _csvKnd;

		/// <summary>�S���҃R�[�h</summary>
		private String _stockAgentCode;

		/// <summary>�S���Җ���</summary>
		private String _stockAgentName;

		/// <summary>�����X�V�敪</summary>
		/// <remarks>0:�Ȃ� 1:����</remarks>
		private Int32 _costUpdtDiv;

		/// <summary>�d���f�[�^�쐬�敪</summary>
		/// <remarks>0:�Ȃ� 1:����</remarks>
		private Int32 _stcCreDiv;

		/// <summary>�b�r�u�t�@�C����</summary>
		private String _csvName;

		/// <summary>�b�r�u�t���p�X��</summary>
		private String _csvFullPath;

		/// <summary>���㖾�׃N���X</summary>
		private ArrayList _lstDtl;

		/// <summary>�X�V����</summary>
		/// <remarks>9:������(�����ݒ�) 0:����I�� -1:�G���[</remarks>
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
		/// <value>0�Œ�</value>
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

		/// public propaty name  :  StockAgentCode
		/// <summary>�S���҃R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �S���҃R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public String StockAgentCode
		{
			get{return _stockAgentCode;}
			set{_stockAgentCode = value;}
		}

		/// public propaty name  :  StockAgentName
		/// <summary>�S���Җ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �S���Җ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public String StockAgentName
		{
			get{return _stockAgentName;}
			set{_stockAgentName = value;}
		}

		/// public propaty name  :  CostUpdtDiv
		/// <summary>�����X�V�敪�v���p�e�B</summary>
		/// <value>0:�Ȃ� 1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����X�V�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CostUpdtDiv
		{
			get{return _costUpdtDiv;}
			set{_costUpdtDiv = value;}
		}

		/// public propaty name  :  StcCreDiv
		/// <summary>�d���f�[�^�쐬�敪�v���p�e�B</summary>
		/// <value>0:�Ȃ� 1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���f�[�^�쐬�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StcCreDiv
		{
			get{return _stcCreDiv;}
			set{_stcCreDiv = value;}
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
		/// <summary>���㖾�׃N���X�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���㖾�׃N���X�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList LstDtl
		{
			get{return _lstDtl;}
			set{_lstDtl = value;}
		}

		/// public propaty name  :  UpdRsl
		/// <summary>�X�V���ʃv���p�e�B</summary>
		/// <value>9:������(�����ݒ�) 0:����I�� -1:�G���[</value>
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
		/// ����ꗗ�N���X�R���X�g���N�^
		/// </summary>
		/// <returns>BuyOutLsthead�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   BuyOutLsthead�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public BuyOutLsthead()
		{
		}

		/// <summary>
		/// ����ꗗ�N���X�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="uOESupplierCd">UOE������R�[�h</param>
		/// <param name="csvKnd">�b�r�u���(0�Œ�)</param>
		/// <param name="stockAgentCode">�S���҃R�[�h</param>
		/// <param name="stockAgentName">�S���Җ���</param>
		/// <param name="costUpdtDiv">�����X�V�敪(0:�Ȃ� 1:����)</param>
		/// <param name="stcCreDiv">�d���f�[�^�쐬�敪(0:�Ȃ� 1:����)</param>
		/// <param name="csvName">�b�r�u�t�@�C����</param>
		/// <param name="csvFullPath">�b�r�u�t���p�X��</param>
		/// <param name="lstDtl">���㖾�׃N���X</param>
		/// <param name="updRsl">�X�V����(9:������(�����ݒ�) 0:����I�� -1:�G���[)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <returns>BuyOutLsthead�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   BuyOutLsthead�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public BuyOutLsthead(String enterpriseCode,String sectionCode,Int32 uOESupplierCd,Int32 csvKnd,String stockAgentCode,String stockAgentName,Int32 costUpdtDiv,Int32 stcCreDiv,String csvName,String csvFullPath,ArrayList lstDtl,Int32 updRsl,string enterpriseName)
		{
			this._enterpriseCode = enterpriseCode;
			this._sectionCode = sectionCode;
			this._uOESupplierCd = uOESupplierCd;
			this._csvKnd = csvKnd;
			this._stockAgentCode = stockAgentCode;
			this._stockAgentName = stockAgentName;
			this._costUpdtDiv = costUpdtDiv;
			this._stcCreDiv = stcCreDiv;
			this._csvName = csvName;
			this._csvFullPath = csvFullPath;
			this._lstDtl = lstDtl;
			this._updRsl = updRsl;
			this._enterpriseName = enterpriseName;

		}

		/// <summary>
		/// ����ꗗ�N���X��������
		/// </summary>
		/// <returns>BuyOutLsthead�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����BuyOutLsthead�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public BuyOutLsthead Clone()
		{
			return new BuyOutLsthead(this._enterpriseCode,this._sectionCode,this._uOESupplierCd,this._csvKnd,this._stockAgentCode,this._stockAgentName,this._costUpdtDiv,this._stcCreDiv,this._csvName,this._csvFullPath,this._lstDtl,this._updRsl,this._enterpriseName);
		}

		/// <summary>
		/// ����ꗗ�N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�BuyOutLsthead�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   BuyOutLsthead�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(BuyOutLsthead target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SectionCode == target.SectionCode)
				 && (this.UOESupplierCd == target.UOESupplierCd)
				 && (this.CsvKnd == target.CsvKnd)
				 && (this.StockAgentCode == target.StockAgentCode)
				 && (this.StockAgentName == target.StockAgentName)
				 && (this.CostUpdtDiv == target.CostUpdtDiv)
				 && (this.StcCreDiv == target.StcCreDiv)
				 && (this.CsvName == target.CsvName)
				 && (this.CsvFullPath == target.CsvFullPath)
				 && (this.LstDtl == target.LstDtl)
				 && (this.UpdRsl == target.UpdRsl)
				 && (this.EnterpriseName == target.EnterpriseName));
		}

		/// <summary>
		/// ����ꗗ�N���X��r����
		/// </summary>
		/// <param name="buyOutLsthead1">
		///                    ��r����BuyOutLsthead�N���X�̃C���X�^���X
		/// </param>
		/// <param name="buyOutLsthead2">��r����BuyOutLsthead�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   BuyOutLsthead�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(BuyOutLsthead buyOutLsthead1, BuyOutLsthead buyOutLsthead2)
		{
			return ((buyOutLsthead1.EnterpriseCode == buyOutLsthead2.EnterpriseCode)
				 && (buyOutLsthead1.SectionCode == buyOutLsthead2.SectionCode)
				 && (buyOutLsthead1.UOESupplierCd == buyOutLsthead2.UOESupplierCd)
				 && (buyOutLsthead1.CsvKnd == buyOutLsthead2.CsvKnd)
				 && (buyOutLsthead1.StockAgentCode == buyOutLsthead2.StockAgentCode)
				 && (buyOutLsthead1.StockAgentName == buyOutLsthead2.StockAgentName)
				 && (buyOutLsthead1.CostUpdtDiv == buyOutLsthead2.CostUpdtDiv)
				 && (buyOutLsthead1.StcCreDiv == buyOutLsthead2.StcCreDiv)
				 && (buyOutLsthead1.CsvName == buyOutLsthead2.CsvName)
				 && (buyOutLsthead1.CsvFullPath == buyOutLsthead2.CsvFullPath)
				 && (buyOutLsthead1.LstDtl == buyOutLsthead2.LstDtl)
				 && (buyOutLsthead1.UpdRsl == buyOutLsthead2.UpdRsl)
				 && (buyOutLsthead1.EnterpriseName == buyOutLsthead2.EnterpriseName));
		}
		/// <summary>
		/// ����ꗗ�N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�BuyOutLsthead�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   BuyOutLsthead�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(BuyOutLsthead target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.UOESupplierCd != target.UOESupplierCd)resList.Add("UOESupplierCd");
			if(this.CsvKnd != target.CsvKnd)resList.Add("CsvKnd");
			if(this.StockAgentCode != target.StockAgentCode)resList.Add("StockAgentCode");
			if(this.StockAgentName != target.StockAgentName)resList.Add("StockAgentName");
			if(this.CostUpdtDiv != target.CostUpdtDiv)resList.Add("CostUpdtDiv");
			if(this.StcCreDiv != target.StcCreDiv)resList.Add("StcCreDiv");
			if(this.CsvName != target.CsvName)resList.Add("CsvName");
			if(this.CsvFullPath != target.CsvFullPath)resList.Add("CsvFullPath");
			if(this.LstDtl != target.LstDtl)resList.Add("LstDtl");
			if(this.UpdRsl != target.UpdRsl)resList.Add("UpdRsl");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}

		/// <summary>
		/// ����ꗗ�N���X��r����
		/// </summary>
		/// <param name="buyOutLsthead1">��r����BuyOutLsthead�N���X�̃C���X�^���X</param>
		/// <param name="buyOutLsthead2">��r����BuyOutLsthead�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   BuyOutLsthead�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(BuyOutLsthead buyOutLsthead1, BuyOutLsthead buyOutLsthead2)
		{
			ArrayList resList = new ArrayList();
			if(buyOutLsthead1.EnterpriseCode != buyOutLsthead2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(buyOutLsthead1.SectionCode != buyOutLsthead2.SectionCode)resList.Add("SectionCode");
			if(buyOutLsthead1.UOESupplierCd != buyOutLsthead2.UOESupplierCd)resList.Add("UOESupplierCd");
			if(buyOutLsthead1.CsvKnd != buyOutLsthead2.CsvKnd)resList.Add("CsvKnd");
			if(buyOutLsthead1.StockAgentCode != buyOutLsthead2.StockAgentCode)resList.Add("StockAgentCode");
			if(buyOutLsthead1.StockAgentName != buyOutLsthead2.StockAgentName)resList.Add("StockAgentName");
			if(buyOutLsthead1.CostUpdtDiv != buyOutLsthead2.CostUpdtDiv)resList.Add("CostUpdtDiv");
			if(buyOutLsthead1.StcCreDiv != buyOutLsthead2.StcCreDiv)resList.Add("StcCreDiv");
			if(buyOutLsthead1.CsvName != buyOutLsthead2.CsvName)resList.Add("CsvName");
			if(buyOutLsthead1.CsvFullPath != buyOutLsthead2.CsvFullPath)resList.Add("CsvFullPath");
			if(buyOutLsthead1.LstDtl != buyOutLsthead2.LstDtl)resList.Add("LstDtl");
			if(buyOutLsthead1.UpdRsl != buyOutLsthead2.UpdRsl)resList.Add("UpdRsl");
			if(buyOutLsthead1.EnterpriseName != buyOutLsthead2.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}
	}
}
