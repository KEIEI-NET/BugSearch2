//***************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �d���ԕi�\��ꗗ�\
// �v���O�����T�v   : �d���ԕi�\��ꗗ�\ ���o���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : FSI���� ����
// �� �� ��   2013/01/28 �C�����e : �V�K�쐬 �d���ԕi�\��@�\�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ExtrInfo_PMKAK02034E
	/// <summary>
	///                      �d���ԕi�\��ꗗ�\���o�����N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   �d���ԕi�\��ꗗ�\���o�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// </remarks>
	public class ExtrInfo_PMKAK02034E
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";
		/// <summary>���_�R�[�h</summary>
		private string[] _sectionCodes ;
        /// <summary>�J�n�d����R�[�h</summary>
        private Int32 _supplierCdSt;
        /// <summary>�I���d����R�[�h</summary>
        private Int32 _supplierCdEd;
		/// <summary>�J�n���͓��t</summary>
		private Int32 _inputDaySt;
		/// <summary>�I�����͓��t</summary>
		private Int32 _inputDayEd;
		/// <summary>���s�^�C�v</summary>
		private Int32 _makeShowDiv;
		/// <summary>���s�^�C�v����</summary>
		private string _makeShowDivName = "";
		/// <summary>�o�͎w��</summary>
		private Int32 _slipDiv;
		/// <summary>�o�͎w�薼��</summary>
		private string _slipDivName = "";
        /// <summary>����</summary>
        private Int32 _newPageDiv;
        /// <summary>���t�w��</summary>
        private Int32 _printDailyFooter;

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
			get { return _enterpriseCode; }
			set { _enterpriseCode = value; }
		}

		/// public propaty name  :  SectionCodes
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// <value>(�z��)�@�S�Ўw���{""}</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get { return _sectionCodes; }
			set { _sectionCodes = value; }
		}


        /// public propaty name  :  CustomerCodeSt
        /// <summary>�J�n�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   30415 �ēc �ύK</br>
        /// </remarks>
        public Int32 SupplierCdSt
        {
            get { return _supplierCdSt; }
            set { _supplierCdSt = value; }
        }

        /// public propaty name  :  CustomerCodeEd
        /// <summary>�I���d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   30415 �ēc �ύK</br>
        /// </remarks>
        public Int32 SupplierCdEd
        {
            get { return _supplierCdEd; }
            set { _supplierCdEd = value; }
        }

		/// public propaty name  :  InputDaySt
		/// <summary>�J�n���͓��t�v���p�e�B</summary>
		/// <value>YYYYMMDD (�����͂�0)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���͓��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InputDaySt
		{
			get { return _inputDaySt; }
			set { _inputDaySt = value; }
		}

		/// public propaty name  :  InputDayEd
		/// <summary>�I�����͓��t�v���p�e�B</summary>
		/// <value>YYYYMMDD (�����͂�0)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����͓��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InputDayEd
		{
			get { return _inputDayEd; }
			set { _inputDayEd = value; }
		}

		/// public propaty name  :  MakeShowDiv
		/// <summary>���s�^�C�v�v���p�e�B</summary>
		/// <value>0:�ʏ�,1:�폜</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���s�^�C�v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MakeShowDiv
		{
			get { return _makeShowDiv; }
			set { _makeShowDiv = value; }
		}

		/// public propaty name  :  MakeShowDivName
		/// <summary>���s�^�C�v���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���s�^�C�v���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string MakeShowDivName
		{
			get { return _makeShowDivName; }
			set { _makeShowDivName = value; }
		}

		/// public propaty name  :  SlipDiv
		/// <summary>�o�͎w��v���p�e�B</summary>
		/// <value>0:�ԕi�\��̂�,1:�ԕi�ς̂�,2:���ׂ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�͎w��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SlipDiv
		{
			get { return _slipDiv; }
			set { _slipDiv = value; }
		}

		/// public propaty name  :  SlipDivName
		/// <summary>�o�͎w�薼�̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�͎w�薼�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SlipDivName
		{
			get { return _slipDivName; }
			set { _slipDivName = value; }
		}

        /// public propaty name  :  NewPageDiv
        /// <summary>���ŋ敪�v���p�e�B</summary>
        /// <value>0:���_,1:�d����,2:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ŋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NewPageDiv
        {
            get { return _newPageDiv; }
            set { _newPageDiv = value; }
        }

        /// public propaty name  :  PrintDailyFooter
        /// <summary>���t�w��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���t�w��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrintDailyFooter
        {
            get { return _printDailyFooter; }
            set { _printDailyFooter = value; }
        }

		/// <summary>
		/// �d���ԕi�\��ꗗ�\���o�����N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>StockRetPlnParamWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockRetPlnParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ExtrInfo_PMKAK02034E()
		{
		}

		/// <summary>
		/// �d���ԕi�\��ꗗ�\���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="sectionCodes">���_�R�[�h((�z��))</param>
        /// <param name="supplierCdSt">�J�n�d����R�[�h</param>
        /// <param name="supplierCdEd">�I���d����R�[�h</param>
		/// <param name="stockDateSt">�J�n�d�����t(YYYYMMDD)</param>
		/// <param name="stockDateEd">�I���d�����t(YYYYMMDD)</param>
		/// <param name="inputDaySt">�J�n���͓��t</param>
		/// <param name="inputDayEd">�I�����͓��t</param>
		/// <param name="makeShowDiv">���s�^�C�v</param>
		/// <param name="slipDiv">�o�͎w��</param>
        /// <param name="newPageDiv">���ŋ敪</param>
        /// <param name="printDailyFooter">���t�w��敪</param>
		/// <returns>StockRetPlnParamWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ShipmentListCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public ExtrInfo_PMKAK02034E(string enterpriseCode, string[] sectionCodes, Int32 makeShowDiv, Int32 slipDiv, Int32 inputDaySt, Int32 inputDayEd, Int32 newPageDiv, Int32 printDailyFooter)
        {
			this._enterpriseCode = enterpriseCode;
			this._sectionCodes = sectionCodes;
            this._supplierCdSt = SupplierCdSt;
            this._supplierCdEd = SupplierCdEd;
			this._inputDaySt = inputDaySt;
			this._inputDayEd = inputDayEd;
			this._slipDiv = slipDiv;
			this._makeShowDiv = makeShowDiv;
            this._newPageDiv = newPageDiv;
            this._printDailyFooter = printDailyFooter;
		}

		/// <summary>
		/// �d���ԕi�\��ꗗ�\���o�����N���X��������
		/// </summary>
		/// <returns>ShipmentListCndtn�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ShipmentListCndtn�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ExtrInfo_PMKAK02034E Clone()
		{
            return new ExtrInfo_PMKAK02034E(this._enterpriseCode, this._sectionCodes, this._makeShowDiv, this._slipDiv, this._inputDaySt, this._inputDayEd, this._newPageDiv, this._printDailyFooter);
        }

		/// <summary>
		/// �d���ԕi�\��ꗗ�\���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ShipmentListCndtn�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ShipmentListCndtn�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(ExtrInfo_PMKAK02034E target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SectionCodes == target.SectionCodes)
                 && (this.SupplierCdSt == target.SupplierCdSt)
                 && (this.SupplierCdEd == target.SupplierCdEd)
				 && (this.InputDaySt == target.InputDaySt)
				 && (this.InputDayEd == target.InputDayEd)
				 && (this.MakeShowDiv == target.MakeShowDiv)
				 && (this.SlipDiv == target.SlipDiv)
                 && (this.NewPageDiv == target.NewPageDiv)
                 && (this.PrintDailyFooter == target.PrintDailyFooter)
				 );
		}

		/// <summary>
		/// �d���ԕi�\��ꗗ�\���o�����N���X��r����
		/// </summary>
		/// <param name="shipmentListCndtn1">
		///                    ��r����ShipmentListCndtn�N���X�̃C���X�^���X
		/// </param>
		/// <param name="shipmentListCndtn2">��r����ShipmentListCndtn�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ShipmentListCndtn�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(ExtrInfo_PMKAK02034E shipmentListCndtn1, ExtrInfo_PMKAK02034E shipmentListCndtn2)
		{
			return ((shipmentListCndtn1.EnterpriseCode == shipmentListCndtn2.EnterpriseCode)
				 && (shipmentListCndtn1.SectionCodes == shipmentListCndtn2.SectionCodes)
                 && (shipmentListCndtn1.SupplierCdSt == shipmentListCndtn2.SupplierCdSt)
                 && (shipmentListCndtn1.SupplierCdEd == shipmentListCndtn2.SupplierCdEd)
				 && (shipmentListCndtn1.InputDaySt == shipmentListCndtn2.InputDaySt)
				 && (shipmentListCndtn1.InputDayEd == shipmentListCndtn2.InputDayEd)
				 && (shipmentListCndtn1.MakeShowDiv == shipmentListCndtn2.MakeShowDiv)
				 && (shipmentListCndtn1.SlipDiv == shipmentListCndtn2.SlipDiv)
                 && (shipmentListCndtn1.NewPageDiv == shipmentListCndtn2.NewPageDiv)
                 && (shipmentListCndtn1.PrintDailyFooter == shipmentListCndtn2.PrintDailyFooter)
				 );
		
		}
		/// <summary>
		/// �d���ԕi�\��ꗗ�\���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ShipmentListCndtn�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ShipmentListCndtn�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(ExtrInfo_PMKAK02034E target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCodes != target.SectionCodes)resList.Add("SectionCodes");
            if (this.SupplierCdSt != target.SupplierCdSt) resList.Add("SupplierCdSt");
            if (this.SupplierCdEd != target.SupplierCdEd) resList.Add("SupplierCdEd");
			if (this.InputDaySt != target.InputDaySt) resList.Add("InputDaySt");
			if (this.InputDayEd != target.InputDayEd) resList.Add("InputDayEd");
			if (this.MakeShowDiv != target.MakeShowDiv) resList.Add("MakeShowDiv");
			if(this.SlipDiv != target.SlipDiv)resList.Add("SlipDiv");
            if (this.NewPageDiv != target.NewPageDiv) resList.Add("NewPageDiv");
            if (this.PrintDailyFooter != target.PrintDailyFooter) resList.Add("PrintDailyFooter");

			return resList;
		}

		/// <summary>
		/// �d���ԕi�\��ꗗ�\���o�����N���X��r����
		/// </summary>
		/// <param name="shipmentListCndtn1">��r����ShipmentListCndtn�N���X�̃C���X�^���X</param>
		/// <param name="shipmentListCndtn2">��r����ShipmentListCndtn�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ShipmentListCndtn�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(ExtrInfo_PMKAK02034E shipmentListCndtn1, ExtrInfo_PMKAK02034E shipmentListCndtn2)
		{
			ArrayList resList = new ArrayList();
			if(shipmentListCndtn1.EnterpriseCode != shipmentListCndtn2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(shipmentListCndtn1.SectionCodes != shipmentListCndtn2.SectionCodes)resList.Add("SectionCodes");
            if (shipmentListCndtn1.SupplierCdSt != shipmentListCndtn2.SupplierCdSt) resList.Add("SupplierCdSt");
            if (shipmentListCndtn1.SupplierCdEd != shipmentListCndtn2.SupplierCdEd) resList.Add("SupplierCdEd");
			if(shipmentListCndtn1.MakeShowDiv != shipmentListCndtn2.MakeShowDiv)resList.Add("MakeShowDiv");
			if(shipmentListCndtn1.SlipDiv != shipmentListCndtn2.SlipDiv)resList.Add("SlipDiv");
			if (shipmentListCndtn1.InputDaySt != shipmentListCndtn2.InputDaySt) resList.Add("InputDaySt");
			if (shipmentListCndtn1.InputDayEd != shipmentListCndtn2.InputDayEd) resList.Add("InputDayEd");
            if (shipmentListCndtn1.NewPageDiv != shipmentListCndtn2.NewPageDiv) resList.Add("NewPageDiv");
            if (shipmentListCndtn1.PrintDailyFooter != shipmentListCndtn2.PrintDailyFooter) resList.Add("PrintDailyFooter");
			return resList;
		}
	}
}
