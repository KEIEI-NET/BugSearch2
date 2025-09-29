using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   StockSignOrderCndtn
	/// <summary>
	///                      �݌ɊŔ�����o�����N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   �݌ɊŔ�����o�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/12/15  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class StockSignOrderCndtn
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h�i�����w��j</summary>
		private string[] _sectionCodes;

		/// <summary>�q�ɃR�[�h(�J�n)</summary>
		private string _st_WarehouseCode = "";

		/// <summary>�q�ɃR�[�h(�I��)</summary>
		private string _ed_WarehouseCode = "";

		/// <summary>���i���[�J�[�R�[�h(�J�n)</summary>
		private Int32 _st_GoodsMakerCd;

		/// <summary>���i���[�J�[�R�[�h(�I��)</summary>
		private Int32 _ed_GoodsMakerCd;

		/// <summary>�q�ɒI��(�J�n)</summary>
		private string _st_WarehouseShelfNo = "";

		/// <summary>�q�ɒI��(�I��)</summary>
		private string _ed_WarehouseShelfNo = "";

		/// <summary>���i�ԍ�(�J�n)</summary>
		private string _st_GoodsNo = "";

		/// <summary>���i�ԍ�(�I��)</summary>
		private string _ed_GoodsNo = "";

		/// <summary>����^�C�v</summary>
		/// <remarks>0:�I�ԃ��x�� 1:�݌ɖ�����</remarks>
        private PrintTypeState _printType;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

        // ���������ȊO
        /// <summary>���_�I�v�V�����敪</summary>
        private bool _isOptSection = false;
        /// <summary>�S���_�I���敪</summary>
        private bool _isSelectAllSection = false;

        /// <summary>�����</summary>
        private PrintOrderState _printOrder;
        /// <summary>���x���^�C�v</summary>
        private LabelTypeState _labelType;
        /// <summary>����J�n�s</summary>
        private PrintStartRowState _printStartRow;


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

		/// public propaty name  :  SectionCodes
		/// <summary>���_�R�[�h�i�����w��j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�i�����w��j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
		}

		/// public propaty name  :  St_WarehouseCode
		/// <summary>�q�ɃR�[�h(�J�n)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �q�ɃR�[�h(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string St_WarehouseCode
		{
			get{return _st_WarehouseCode;}
			set{_st_WarehouseCode = value;}
		}

		/// public propaty name  :  Ed_WarehouseCode
		/// <summary>�q�ɃR�[�h(�I��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �q�ɃR�[�h(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Ed_WarehouseCode
		{
			get{return _ed_WarehouseCode;}
			set{_ed_WarehouseCode = value;}
		}

		/// public propaty name  :  St_GoodsMakerCd
		/// <summary>���i���[�J�[�R�[�h(�J�n)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���[�J�[�R�[�h(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_GoodsMakerCd
		{
			get{return _st_GoodsMakerCd;}
			set{_st_GoodsMakerCd = value;}
		}

		/// public propaty name  :  Ed_GoodsMakerCd
		/// <summary>���i���[�J�[�R�[�h(�I��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���[�J�[�R�[�h(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_GoodsMakerCd
		{
			get{return _ed_GoodsMakerCd;}
			set{_ed_GoodsMakerCd = value;}
		}

		/// public propaty name  :  St_WarehouseShelfNo
		/// <summary>�q�ɒI��(�J�n)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �q�ɒI��(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string St_WarehouseShelfNo
		{
			get{return _st_WarehouseShelfNo;}
			set{_st_WarehouseShelfNo = value;}
		}

		/// public propaty name  :  Ed_WarehouseShelfNo
		/// <summary>�q�ɒI��(�I��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �q�ɒI��(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Ed_WarehouseShelfNo
		{
			get{return _ed_WarehouseShelfNo;}
			set{_ed_WarehouseShelfNo = value;}
		}

		/// public propaty name  :  St_GoodsNo
		/// <summary>���i�ԍ�(�J�n)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�ԍ�(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string St_GoodsNo
		{
			get{return _st_GoodsNo;}
			set{_st_GoodsNo = value;}
		}

		/// public propaty name  :  Ed_GoodsNo
		/// <summary>���i�ԍ�(�I��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�ԍ�(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Ed_GoodsNo
		{
			get{return _ed_GoodsNo;}
			set{_ed_GoodsNo = value;}
		}

		/// public propaty name  :  PrintType
		/// <summary>����^�C�v�v���p�e�B</summary>
		/// <value>0:�I�ԃ��x�� 1:�݌ɖ�����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public PrintTypeState PrintType
		{
			get{return _printType;}
			set{_printType = value;}
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

        // ���������ȊO

        /// <summary>
        /// ���_�I�v�V�����敪�v���p�e�B
        /// </summary>
        public bool IsOptSection
        {
            get { return this._isOptSection; }
            set { this._isOptSection = value; }
        }

        /// <summary>
        /// �S���_�I���敪�v���p�e�B
        /// </summary>
        public bool IsSelectAllSection
        {
            get { return this._isSelectAllSection; }
            set { this._isSelectAllSection = value; }
        }

        /// <summary>
        /// �����
        /// </summary>
        public PrintOrderState PrintOrder
        {
            get { return _printOrder; }
            set { _printOrder = value; }
        }

        /// <summary>
        /// ���x���^�C�v
        /// </summary>
        public LabelTypeState LabelType
        {
            get { return _labelType; }
            set { _labelType = value; }
        }

        /// <summary>
        /// ����J�n�s
        /// </summary>
        public PrintStartRowState PrintStartRow
        {
            get { return _printStartRow; }
            set { _printStartRow = value; }
        }


		/// <summary>
		/// �݌ɊŔ�����o�����N���X�R���X�g���N�^
		/// </summary>
		/// <returns>StockSignOrderCndtn�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockSignOrderCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockSignOrderCndtn()
		{
		}

		/// <summary>
		/// �݌ɊŔ�����o�����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="sectionCodes">���_�R�[�h�i�����w��j</param>
		/// <param name="st_WarehouseCode">�q�ɃR�[�h(�J�n)</param>
		/// <param name="ed_WarehouseCode">�q�ɃR�[�h(�I��)</param>
		/// <param name="st_GoodsMakerCd">���i���[�J�[�R�[�h(�J�n)</param>
		/// <param name="ed_GoodsMakerCd">���i���[�J�[�R�[�h(�I��)</param>
		/// <param name="st_WarehouseShelfNo">�q�ɒI��(�J�n)</param>
		/// <param name="ed_WarehouseShelfNo">�q�ɒI��(�I��)</param>
		/// <param name="st_GoodsNo">���i�ԍ�(�J�n)</param>
		/// <param name="ed_GoodsNo">���i�ԍ�(�I��)</param>
		/// <param name="printType">�����(0:�I�ԃ��x�� 1:�݌ɖ�����)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <returns>StockSignOrderCndtn�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockSignOrderCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public StockSignOrderCndtn(string enterpriseCode, string[] sectionCodes, string st_WarehouseCode, string ed_WarehouseCode, Int32 st_GoodsMakerCd, Int32 ed_GoodsMakerCd, string st_WarehouseShelfNo, string ed_WarehouseShelfNo, string st_GoodsNo, string ed_GoodsNo, PrintTypeState printType, string enterpriseName,
            bool isOptSection, bool isSelectAllSection, PrintOrderState printOrder, LabelTypeState labelType, PrintStartRowState printStartRow)
		{
			this._enterpriseCode = enterpriseCode;
			this._sectionCodes = sectionCodes;
			this._st_WarehouseCode = st_WarehouseCode;
			this._ed_WarehouseCode = ed_WarehouseCode;
			this._st_GoodsMakerCd = st_GoodsMakerCd;
			this._ed_GoodsMakerCd = ed_GoodsMakerCd;
			this._st_WarehouseShelfNo = st_WarehouseShelfNo;
			this._ed_WarehouseShelfNo = ed_WarehouseShelfNo;
			this._st_GoodsNo = st_GoodsNo;
			this._ed_GoodsNo = ed_GoodsNo;
			this._printType = printType;
			this._enterpriseName = enterpriseName;
            this._isOptSection = isOptSection;
            this._isSelectAllSection = isSelectAllSection;
            this._printOrder = printOrder;
            this._labelType = labelType;
            this._printStartRow = printStartRow;
		}

		/// <summary>
		/// �݌ɊŔ�����o�����N���X��������
		/// </summary>
		/// <returns>StockSignOrderCndtn�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����StockSignOrderCndtn�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockSignOrderCndtn Clone()
		{
            return new StockSignOrderCndtn(this._enterpriseCode, this._sectionCodes, this._st_WarehouseCode, this._ed_WarehouseCode, this._st_GoodsMakerCd, this._ed_GoodsMakerCd, this._st_WarehouseShelfNo, this._ed_WarehouseShelfNo, this._st_GoodsNo, this._ed_GoodsNo, this._printType, this._enterpriseName, this._isOptSection, this._isSelectAllSection, this._printOrder, this._labelType, this._printStartRow);
		}

		/// <summary>
		/// �݌ɊŔ�����o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�StockSignOrderCndtn�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockSignOrderCndtn�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(StockSignOrderCndtn target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SectionCodes == target.SectionCodes)
				 && (this.St_WarehouseCode == target.St_WarehouseCode)
				 && (this.Ed_WarehouseCode == target.Ed_WarehouseCode)
				 && (this.St_GoodsMakerCd == target.St_GoodsMakerCd)
				 && (this.Ed_GoodsMakerCd == target.Ed_GoodsMakerCd)
				 && (this.St_WarehouseShelfNo == target.St_WarehouseShelfNo)
				 && (this.Ed_WarehouseShelfNo == target.Ed_WarehouseShelfNo)
				 && (this.St_GoodsNo == target.St_GoodsNo)
				 && (this.Ed_GoodsNo == target.Ed_GoodsNo)
				 && (this.PrintType == target.PrintType)
				 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.IsOptSection == target.IsOptSection)
                 && (this.IsSelectAllSection == target.IsSelectAllSection)
                 && (this.PrintOrder == target.PrintOrder)
                 && (this.LabelType == target.LabelType)
                 && (this.PrintStartRow == target.PrintStartRow)
                 );
		}

		/// <summary>
		/// �݌ɊŔ�����o�����N���X��r����
		/// </summary>
		/// <param name="stockSignOrderCndtn1">
		///                    ��r����StockSignOrderCndtn�N���X�̃C���X�^���X
		/// </param>
		/// <param name="stockSignOrderCndtn2">��r����StockSignOrderCndtn�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockSignOrderCndtn�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(StockSignOrderCndtn stockSignOrderCndtn1, StockSignOrderCndtn stockSignOrderCndtn2)
		{
			return ((stockSignOrderCndtn1.EnterpriseCode == stockSignOrderCndtn2.EnterpriseCode)
				 && (stockSignOrderCndtn1.SectionCodes == stockSignOrderCndtn2.SectionCodes)
				 && (stockSignOrderCndtn1.St_WarehouseCode == stockSignOrderCndtn2.St_WarehouseCode)
				 && (stockSignOrderCndtn1.Ed_WarehouseCode == stockSignOrderCndtn2.Ed_WarehouseCode)
				 && (stockSignOrderCndtn1.St_GoodsMakerCd == stockSignOrderCndtn2.St_GoodsMakerCd)
				 && (stockSignOrderCndtn1.Ed_GoodsMakerCd == stockSignOrderCndtn2.Ed_GoodsMakerCd)
				 && (stockSignOrderCndtn1.St_WarehouseShelfNo == stockSignOrderCndtn2.St_WarehouseShelfNo)
				 && (stockSignOrderCndtn1.Ed_WarehouseShelfNo == stockSignOrderCndtn2.Ed_WarehouseShelfNo)
				 && (stockSignOrderCndtn1.St_GoodsNo == stockSignOrderCndtn2.St_GoodsNo)
				 && (stockSignOrderCndtn1.Ed_GoodsNo == stockSignOrderCndtn2.Ed_GoodsNo)
				 && (stockSignOrderCndtn1.PrintType == stockSignOrderCndtn2.PrintType)
				 && (stockSignOrderCndtn1.EnterpriseName == stockSignOrderCndtn2.EnterpriseName)
                 && (stockSignOrderCndtn1.IsOptSection == stockSignOrderCndtn2.IsOptSection)
                 && (stockSignOrderCndtn1.IsSelectAllSection == stockSignOrderCndtn2.IsSelectAllSection)
                 && (stockSignOrderCndtn1.PrintOrder == stockSignOrderCndtn2.PrintOrder)
                 && (stockSignOrderCndtn1.LabelType == stockSignOrderCndtn2.LabelType)
                 && (stockSignOrderCndtn1.PrintStartRow == stockSignOrderCndtn2.PrintStartRow)
                 );
		}
		/// <summary>
		/// �݌ɊŔ�����o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�StockSignOrderCndtn�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockSignOrderCndtn�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(StockSignOrderCndtn target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCodes != target.SectionCodes)resList.Add("SectionCodes");
			if(this.St_WarehouseCode != target.St_WarehouseCode)resList.Add("St_WarehouseCode");
			if(this.Ed_WarehouseCode != target.Ed_WarehouseCode)resList.Add("Ed_WarehouseCode");
			if(this.St_GoodsMakerCd != target.St_GoodsMakerCd)resList.Add("St_GoodsMakerCd");
			if(this.Ed_GoodsMakerCd != target.Ed_GoodsMakerCd)resList.Add("Ed_GoodsMakerCd");
			if(this.St_WarehouseShelfNo != target.St_WarehouseShelfNo)resList.Add("St_WarehouseShelfNo");
			if(this.Ed_WarehouseShelfNo != target.Ed_WarehouseShelfNo)resList.Add("Ed_WarehouseShelfNo");
			if(this.St_GoodsNo != target.St_GoodsNo)resList.Add("St_GoodsNo");
			if(this.Ed_GoodsNo != target.Ed_GoodsNo)resList.Add("Ed_GoodsNo");
			if(this.PrintType != target.PrintType)resList.Add("PrintType");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
            if (this.IsOptSection != target.IsOptSection) resList.Add("IsOptSection");
            if (this.IsOptSection != target.IsSelectAllSection) resList.Add("IsSelectAllSection");
            if (this.PrintOrder != target.PrintOrder) resList.Add("PrintOrder");
            if (this.LabelType != target.LabelType) resList.Add("LabelType");
            if (this.PrintStartRow != target.PrintStartRow) resList.Add("PrintStartRow");

			return resList;
		}

		/// <summary>
		/// �݌ɊŔ�����o�����N���X��r����
		/// </summary>
		/// <param name="stockSignOrderCndtn1">��r����StockSignOrderCndtn�N���X�̃C���X�^���X</param>
		/// <param name="stockSignOrderCndtn2">��r����StockSignOrderCndtn�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockSignOrderCndtn�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(StockSignOrderCndtn stockSignOrderCndtn1, StockSignOrderCndtn stockSignOrderCndtn2)
		{
			ArrayList resList = new ArrayList();
			if(stockSignOrderCndtn1.EnterpriseCode != stockSignOrderCndtn2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(stockSignOrderCndtn1.SectionCodes != stockSignOrderCndtn2.SectionCodes)resList.Add("SectionCodes");
			if(stockSignOrderCndtn1.St_WarehouseCode != stockSignOrderCndtn2.St_WarehouseCode)resList.Add("St_WarehouseCode");
			if(stockSignOrderCndtn1.Ed_WarehouseCode != stockSignOrderCndtn2.Ed_WarehouseCode)resList.Add("Ed_WarehouseCode");
			if(stockSignOrderCndtn1.St_GoodsMakerCd != stockSignOrderCndtn2.St_GoodsMakerCd)resList.Add("St_GoodsMakerCd");
			if(stockSignOrderCndtn1.Ed_GoodsMakerCd != stockSignOrderCndtn2.Ed_GoodsMakerCd)resList.Add("Ed_GoodsMakerCd");
			if(stockSignOrderCndtn1.St_WarehouseShelfNo != stockSignOrderCndtn2.St_WarehouseShelfNo)resList.Add("St_WarehouseShelfNo");
			if(stockSignOrderCndtn1.Ed_WarehouseShelfNo != stockSignOrderCndtn2.Ed_WarehouseShelfNo)resList.Add("Ed_WarehouseShelfNo");
			if(stockSignOrderCndtn1.St_GoodsNo != stockSignOrderCndtn2.St_GoodsNo)resList.Add("St_GoodsNo");
			if(stockSignOrderCndtn1.Ed_GoodsNo != stockSignOrderCndtn2.Ed_GoodsNo)resList.Add("Ed_GoodsNo");
			if(stockSignOrderCndtn1.PrintType != stockSignOrderCndtn2.PrintType)resList.Add("PrintType");
            if (stockSignOrderCndtn1.EnterpriseName != stockSignOrderCndtn2.EnterpriseName) resList.Add("EnterpriseName");
            if (stockSignOrderCndtn1.IsOptSection != stockSignOrderCndtn2.IsOptSection) resList.Add("IsOptSection");
            if (stockSignOrderCndtn1.IsSelectAllSection != stockSignOrderCndtn2.IsSelectAllSection) resList.Add("IsSelectAllSection");
            if (stockSignOrderCndtn1.PrintOrder != stockSignOrderCndtn2.PrintOrder) resList.Add("PrintOrder");
            if (stockSignOrderCndtn1.LabelType != stockSignOrderCndtn2.LabelType) resList.Add("LabelType");
            if (stockSignOrderCndtn1.PrintStartRow != stockSignOrderCndtn2.PrintStartRow) resList.Add("PrintStartRow");

			return resList;
		}

        #region ���񋓑�
        /// <summary>
        /// ����^�C�v
        /// </summary>
        public enum PrintTypeState
        {
            /// <summary>�I�ԃ��x��</summary>
            ShelfNo = 0,
            /// <summary>�݌ɖ�����</summary>
            StockNum = 1
        }

        /// <summary>
        /// �����
        /// </summary>
        public enum PrintOrderState
        {
            /// <summary>�i�ԏ�</summary>
            GoodsNo = 0,
            /// <summary>�I�ԏ�</summary>
            ShelfNo = 1
        }

        /// <summary>
        /// ���x���^�C�v
        /// </summary>
        public enum LabelTypeState
        {
            /// <summary>�T�~�X�i�h�b�g�j</summary>
            Dot_FiveByNine = 0,
            /// <summary>�R�~�X�i�h�b�g�j</summary>
            Dot_ThreeByNine = 1,
            /// <summary>�R�~�X�i���[�U�[�j</summary>
            Laser_ThreeByNine = 2,
            /// <summary>�S�~�P�P�i���[�U�[�j</summary>
            Laser_FourByEleven = 3
        }

        /// <summary>
        /// ����J�n�s
        /// </summary>
        public enum PrintStartRowState
        {
            /// <summary>1�s��</summary>
            One = 0,
            /// <summary>2�s��</summary>
            Two = 1,
            /// <summary>3�s��</summary>
            Three = 2,
            /// <summary>4�s��</summary>
            Four = 3,
            /// <summary>5�s��</summary>
            Five = 4,
            /// <summary>6�s��</summary>
            Six = 5,
            /// <summary>7�s��</summary>
            Seven = 6,
            /// <summary>8�s��</summary>
            Eight = 7,
            /// <summary>9�s��</summary>
            Nine = 8,
            /// <summary>10�s��</summary>
            Ten = 9,
            /// <summary>11�s��</summary>
            Eleven = 10
        }
        #endregion
    }
}
