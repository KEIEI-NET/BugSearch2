using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ShipGdsPrimeListCndtn
	/// <summary>
	///                      �o�׏��i�D�ǑΉ��\���o�����N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   �o�׏��i�D�ǑΉ��\���o�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/11/25  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
    /// <br>Update Note      :   2014/12/30 ������</br>
    /// <br>�Ǘ��ԍ�         :   11070263-00</br>
    /// <br>                 :  �E�����Y�ƗlSeiken�i�ԕύX</br>
    /// <br>Update Note      : 2015/03/27 ���V��</br>
    /// <br>�Ǘ��ԍ�         : 11070263-00</br>
    /// <br>                 : Redmine#44209��#423�i�ԏW�v�敪�̖��̕ύX</br>
	/// </remarks>
	public class ShipGdsPrimeListCndtn2
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h</summary>
		/// <remarks>(�z��) null�őS�Ўw��</remarks>
		private string[] _sectionCodes;

		/// <summary>�J�n�Ώ۔N��</summary>
		private DateTime _st_AddUpYearMonth;

		/// <summary>�I���Ώ۔N��</summary>
		private DateTime _ed_AddUpYearMonth;

		/// <summary>�J�n���[�J�[�R�[�h</summary>
		private Int32 _st_GoodsMakerCd;

		/// <summary>�I�����[�J�[�R�[�h</summary>
		private Int32 _ed_GoodsMakerCd;

		/// <summary>�J�n�啪�ރR�[�h</summary>
		/// <remarks>�O���[�v�R�[�h�}�X�^</remarks>
		private Int32 _st_GoodsLGroup;

		/// <summary>�I���啪�ރR�[�h</summary>
		/// <remarks>�O���[�v�R�[�h�}�X�^</remarks>
		private Int32 _ed_GoodsLGroup;

		/// <summary>�J�n�����ރR�[�h</summary>
		/// <remarks>�O���[�v�R�[�h�}�X�^</remarks>
		private Int32 _st_GoodsMGroup;

		/// <summary>�I�������ރR�[�h</summary>
		/// <remarks>�O���[�v�R�[�h�}�X�^</remarks>
		private Int32 _ed_GoodsMGroup;

		/// <summary>�J�n�O���[�v�R�[�h</summary>
		/// <remarks>BL�R�[�h�}�X�^</remarks>
		private Int32 _st_BLGroupCode;

		/// <summary>�I���O���[�v�R�[�h</summary>
		/// <remarks>BL�R�[�h�}�X�^</remarks>
		private Int32 _ed_BLGroupCode;

		/// <summary>�J�n�a�k�R�[�h</summary>
		private Int32 _st_BLGoodsCode;

		/// <summary>�I���a�k�R�[�h</summary>
		private Int32 _ed_BLGoodsCode;

		/// <summary>�o�׉�</summary>
		/// <remarks>���U�Ŏg�p</remarks>
		private Int32 _shipCount;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

        // ���������ȊO
        /// <summary>���_�I�v�V�����敪</summary>
        private bool _isOptSection = false;

        /// <summary>�S���_�I���敪</summary>
        private bool _isSelectAllSection = false;

        /// <summary>�o�͋敪</summary>
        /// <remarks>0:�S�� 1:�݌� 2:���</remarks>
        private OutputDivState _outputDiv;

        /// <summary>����</summary>
        /// <remarks>0:���_ 1:���Ȃ�</remarks>
        private NewPageDivState _newPageDiv;

        //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
        /// <summary>�i�ԏW�v�敪</summary>
        /// <remarks>0:�ʁX 1:���Z</remarks>
        private GoodsNoTtlDivState _goodsNoTtlDiv;

        /// <summary>�i�ԕ\���敪</summary>
        /// /// <remarks>0:�V�i�� 1:���i��</remarks>
        private GoodsNoShowDivState _goodsNoShowDiv;
        //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<

        /// <summary>����^�C�v</summary>
        /// <remarks>0:���� 1:����</remarks>
        private PrintTypeState _printType;

        /// <summary>���o�敪</summary>
        /// <remarks>0:���� 1:�D��</remarks>
        private ExtractDivState _extractDiv;

        /// <summary>�J�n�Ώ۔N��(����)</summary>
        private DateTime _st_AnnualAddUpYearMonth;

        /// <summary>�I���Ώ۔N��(����)</summary>
        private DateTime _ed_AnnualAddUpYearMonth;

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
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// <value>(�z��) null�őS�Ўw��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
		}

		/// public propaty name  :  St_AddUpYearMonth
		/// <summary>�J�n�Ώ۔N���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�Ώ۔N���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime St_AddUpYearMonth
		{
			get{return _st_AddUpYearMonth;}
			set{_st_AddUpYearMonth = value;}
		}

		/// public propaty name  :  Ed_AddUpYearMonth
		/// <summary>�I���Ώ۔N���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���Ώ۔N���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime Ed_AddUpYearMonth
		{
			get{return _ed_AddUpYearMonth;}
			set{_ed_AddUpYearMonth = value;}
		}

		/// public propaty name  :  St_GoodsMakerCd
		/// <summary>�J�n���[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_GoodsMakerCd
		{
			get{return _st_GoodsMakerCd;}
			set{_st_GoodsMakerCd = value;}
		}

		/// public propaty name  :  Ed_GoodsMakerCd
		/// <summary>�I�����[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_GoodsMakerCd
		{
			get{return _ed_GoodsMakerCd;}
			set{_ed_GoodsMakerCd = value;}
		}

		/// public propaty name  :  St_GoodsLGroup
		/// <summary>�J�n�啪�ރR�[�h�v���p�e�B</summary>
		/// <value>�O���[�v�R�[�h�}�X�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�啪�ރR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_GoodsLGroup
		{
			get{return _st_GoodsLGroup;}
			set{_st_GoodsLGroup = value;}
		}

		/// public propaty name  :  Ed_GoodsLGroup
		/// <summary>�I���啪�ރR�[�h�v���p�e�B</summary>
		/// <value>�O���[�v�R�[�h�}�X�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���啪�ރR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_GoodsLGroup
		{
			get{return _ed_GoodsLGroup;}
			set{_ed_GoodsLGroup = value;}
		}

		/// public propaty name  :  St_GoodsMGroup
		/// <summary>�J�n�����ރR�[�h�v���p�e�B</summary>
		/// <value>�O���[�v�R�[�h�}�X�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�����ރR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_GoodsMGroup
		{
			get{return _st_GoodsMGroup;}
			set{_st_GoodsMGroup = value;}
		}

		/// public propaty name  :  Ed_GoodsMGroup
		/// <summary>�I�������ރR�[�h�v���p�e�B</summary>
		/// <value>�O���[�v�R�[�h�}�X�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�������ރR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_GoodsMGroup
		{
			get{return _ed_GoodsMGroup;}
			set{_ed_GoodsMGroup = value;}
		}

		/// public propaty name  :  St_BLGroupCode
		/// <summary>�J�n�O���[�v�R�[�h�v���p�e�B</summary>
		/// <value>BL�R�[�h�}�X�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�O���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_BLGroupCode
		{
			get{return _st_BLGroupCode;}
			set{_st_BLGroupCode = value;}
		}

		/// public propaty name  :  Ed_BLGroupCode
		/// <summary>�I���O���[�v�R�[�h�v���p�e�B</summary>
		/// <value>BL�R�[�h�}�X�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���O���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_BLGroupCode
		{
			get{return _ed_BLGroupCode;}
			set{_ed_BLGroupCode = value;}
		}

		/// public propaty name  :  St_BLGoodsCode
		/// <summary>�J�n�a�k�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�a�k�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_BLGoodsCode
		{
			get{return _st_BLGoodsCode;}
			set{_st_BLGoodsCode = value;}
		}

		/// public propaty name  :  Ed_BLGoodsCode
		/// <summary>�I���a�k�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���a�k�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_BLGoodsCode
		{
			get{return _ed_BLGoodsCode;}
			set{_ed_BLGoodsCode = value;}
		}

		/// public propaty name  :  ShipCount
		/// <summary>�o�׉񐔃v���p�e�B</summary>
		/// <value>���U�Ŏg�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�׉񐔃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ShipCount
		{
			get{return _shipCount;}
			set{_shipCount = value;}
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
        /// �o�͋敪�v���p�e�B
        /// </summary>
        public OutputDivState OutputDiv
        {
            get { return this._outputDiv; }
            set { this._outputDiv = value; }
        }

        /// <summary>
        /// ���Ńv���p�e�B
        /// </summary>
        public NewPageDivState NewPageDiv
        {
            get { return this._newPageDiv; }
            set { this._newPageDiv = value; }
        }

        //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
        /// <summary>
        /// �i�ԏW�v�敪�@�v���p�e�B
        /// </summary>
        public GoodsNoTtlDivState GoodsNoTtlDiv
        {
            get { return this._goodsNoTtlDiv; }
            set { this._goodsNoTtlDiv = value; }
        }
        /// <summary>
        /// �i�ԕ\���敪�@�v���p�e�B
        /// </summary>
        public GoodsNoShowDivState GoodsNoShowDiv
        {
            get { return this._goodsNoShowDiv; }
            set { this._goodsNoShowDiv = value; }
        }
        //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<

        /// <summary>
        /// ����^�C�v�v���p�e�B
        /// </summary>
        public PrintTypeState PrintType
        {
            get { return this._printType; }
            set { this._printType = value; }
        }

        /// <summary>
        /// ���o�敪�v���p�e�B
        /// </summary>
        public ExtractDivState ExtractDiv
        {
            get { return this._extractDiv; }
            set { this._extractDiv = value; }
        }

        /// <summary>
        /// �J�n�Ώ۔N��(����)
        /// </summary>
        public DateTime St_AnnualAddUpYearMonth
        {
            get { return _st_AnnualAddUpYearMonth; }
            set { _st_AnnualAddUpYearMonth = value; }
        }

        /// <summary>
        /// �I���Ώ۔N��(����)
        /// </summary>
        public DateTime Ed_AnnualAddUpYearMonth
        {
            get { return _ed_AnnualAddUpYearMonth; }
            set { _ed_AnnualAddUpYearMonth = value; }
        }

		/// <summary>
		/// �o�׏��i�D�ǑΉ��\���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <returns>ShipGdsPrimeListCndtn�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ShipGdsPrimeListCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ShipGdsPrimeListCndtn2()
		{
		}

		/// <summary>
		/// �o�׏��i�D�ǑΉ��\���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="sectionCodes">���_�R�[�h((�z��) null�őS�Ўw��)</param>
		/// <param name="st_AddUpYearMonth">�J�n�Ώ۔N��</param>
		/// <param name="ed_AddUpYearMonth">�I���Ώ۔N��</param>
		/// <param name="st_GoodsMakerCd">�J�n���[�J�[�R�[�h</param>
		/// <param name="ed_GoodsMakerCd">�I�����[�J�[�R�[�h</param>
		/// <param name="st_GoodsLGroup">�J�n�啪�ރR�[�h(�O���[�v�R�[�h�}�X�^)</param>
		/// <param name="ed_GoodsLGroup">�I���啪�ރR�[�h(�O���[�v�R�[�h�}�X�^)</param>
		/// <param name="st_GoodsMGroup">�J�n�����ރR�[�h(�O���[�v�R�[�h�}�X�^)</param>
		/// <param name="ed_GoodsMGroup">�I�������ރR�[�h(�O���[�v�R�[�h�}�X�^)</param>
		/// <param name="st_BLGroupCode">�J�n�O���[�v�R�[�h(BL�R�[�h�}�X�^)</param>
		/// <param name="ed_BLGroupCode">�I���O���[�v�R�[�h(BL�R�[�h�}�X�^)</param>
		/// <param name="st_BLGoodsCode">�J�n�a�k�R�[�h</param>
		/// <param name="ed_BLGoodsCode">�I���a�k�R�[�h</param>
		/// <param name="shipCount">�o�׉�(���U�Ŏg�p)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
        /// /// <param name="goodsNoTtlDiv">�i�ԏW�v�敪</param> // ADD 2014/12/30 ������ FOR Redmine#44209����
        /// <param name="goodsNoShowDiv">�i�ԕ\���敪</param> // ADD 2014/12/30 ������ FOR Redmine#44209����
		/// <returns>ShipGdsPrimeListCndtn�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ShipGdsPrimeListCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public ShipGdsPrimeListCndtn2(string enterpriseCode, string[] sectionCodes, DateTime st_AddUpYearMonth, DateTime ed_AddUpYearMonth, Int32 st_GoodsMakerCd, Int32 ed_GoodsMakerCd, Int32 st_GoodsLGroup, Int32 ed_GoodsLGroup, Int32 st_GoodsMGroup, Int32 ed_GoodsMGroup, Int32 st_BLGroupCode, Int32 ed_BLGroupCode, Int32 st_BLGoodsCode, Int32 ed_BLGoodsCode, Int32 shipCount, string enterpriseName,
            //bool isOptSection, bool isSelectAllSection, OutputDivState outputDiv, NewPageDivState newPageDiv, PrintTypeState printType, ExtractDivState extractDiv, DateTime st_AnnualAddUpYearMonth, DateTime ed_AnnualAddUpYearMonth) // DEL 2014/12/30 ������ FOR Redmine#44209����
            bool isOptSection, bool isSelectAllSection, OutputDivState outputDiv, NewPageDivState newPageDiv, GoodsNoTtlDivState goodsNoTtlDiv, GoodsNoShowDivState goodsNoShowDiv, PrintTypeState printType, ExtractDivState extractDiv, DateTime st_AnnualAddUpYearMonth, DateTime ed_AnnualAddUpYearMonth)// ADD 2014/12/30 ������ FOR Redmine#44209����
		{
			this._enterpriseCode = enterpriseCode;
			this._sectionCodes = sectionCodes;
			this._st_AddUpYearMonth = st_AddUpYearMonth;
			this._ed_AddUpYearMonth = ed_AddUpYearMonth;
			this._st_GoodsMakerCd = st_GoodsMakerCd;
			this._ed_GoodsMakerCd = ed_GoodsMakerCd;
			this._st_GoodsLGroup = st_GoodsLGroup;
			this._ed_GoodsLGroup = ed_GoodsLGroup;
			this._st_GoodsMGroup = st_GoodsMGroup;
			this._ed_GoodsMGroup = ed_GoodsMGroup;
			this._st_BLGroupCode = st_BLGroupCode;
			this._ed_BLGroupCode = ed_BLGroupCode;
			this._st_BLGoodsCode = st_BLGoodsCode;
			this._ed_BLGoodsCode = ed_BLGoodsCode;
			this._shipCount = shipCount;
			this._enterpriseName = enterpriseName;

            this._isOptSection = isOptSection;
            this._isSelectAllSection = isSelectAllSection;
            this._outputDiv = outputDiv;
            this._newPageDiv = newPageDiv;
            //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
            this._goodsNoTtlDiv = goodsNoTtlDiv;
            this._goodsNoShowDiv = goodsNoShowDiv;
            //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<
            this._printType = printType;
            this._extractDiv = extractDiv;
            this._st_AnnualAddUpYearMonth = st_AnnualAddUpYearMonth;
            this._ed_AnnualAddUpYearMonth = ed_AnnualAddUpYearMonth;

		}

		/// <summary>
		/// �o�׏��i�D�ǑΉ��\���o�����N���X��������
		/// </summary>
		/// <returns>ShipGdsPrimeListCndtn�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ShipGdsPrimeListCndtn�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public ShipGdsPrimeListCndtn2 Clone()
		{
            //return new ShipGdsPrimeListCndtn2(this._enterpriseCode, this._sectionCodes, this._st_AddUpYearMonth, this._ed_AddUpYearMonth, this._st_GoodsMakerCd, this._ed_GoodsMakerCd, this._st_GoodsLGroup, this._ed_GoodsLGroup, this._st_GoodsMGroup, this._ed_GoodsMGroup, this._st_BLGroupCode, this._ed_BLGroupCode, this._st_BLGoodsCode, this._ed_BLGoodsCode, this._shipCount, this._enterpriseName, this._isOptSection, this._isSelectAllSection, this._outputDiv, this._newPageDiv, this._printType, this._extractDiv, this._st_AnnualAddUpYearMonth, this._ed_AnnualAddUpYearMonth);   // DEL 2014/12/30 ������ FOR Redmine#44209����
            return new ShipGdsPrimeListCndtn2(this._enterpriseCode, this._sectionCodes, this._st_AddUpYearMonth, this._ed_AddUpYearMonth, this._st_GoodsMakerCd, this._ed_GoodsMakerCd, this._st_GoodsLGroup, this._ed_GoodsLGroup, this._st_GoodsMGroup, this._ed_GoodsMGroup, this._st_BLGroupCode, this._ed_BLGroupCode, this._st_BLGoodsCode, this._ed_BLGoodsCode, this._shipCount, this._enterpriseName, this._isOptSection, this._isSelectAllSection, this._outputDiv, this._newPageDiv, this.GoodsNoTtlDiv, this.GoodsNoShowDiv, this._printType, this._extractDiv, this._st_AnnualAddUpYearMonth, this._ed_AnnualAddUpYearMonth);   // ADD 2014/12/30 ������ FOR Redmine#44209����
		}

		/// <summary>
		/// �o�׏��i�D�ǑΉ��\���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ShipGdsPrimeListCndtn�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ShipGdsPrimeListCndtn�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public bool Equals(ShipGdsPrimeListCndtn2 target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SectionCodes == target.SectionCodes)
				 && (this.St_AddUpYearMonth == target.St_AddUpYearMonth)
				 && (this.Ed_AddUpYearMonth == target.Ed_AddUpYearMonth)
				 && (this.St_GoodsMakerCd == target.St_GoodsMakerCd)
				 && (this.Ed_GoodsMakerCd == target.Ed_GoodsMakerCd)
				 && (this.St_GoodsLGroup == target.St_GoodsLGroup)
				 && (this.Ed_GoodsLGroup == target.Ed_GoodsLGroup)
				 && (this.St_GoodsMGroup == target.St_GoodsMGroup)
				 && (this.Ed_GoodsMGroup == target.Ed_GoodsMGroup)
				 && (this.St_BLGroupCode == target.St_BLGroupCode)
				 && (this.Ed_BLGroupCode == target.Ed_BLGroupCode)
				 && (this.St_BLGoodsCode == target.St_BLGoodsCode)
				 && (this.Ed_BLGoodsCode == target.Ed_BLGoodsCode)
				 && (this.ShipCount == target.ShipCount)
				 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.IsOptSection == target.IsOptSection)
                 && (this.IsSelectAllSection == target.IsSelectAllSection)
                 && (this.OutputDiv == target.OutputDiv)
                 //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
                 && (this.GoodsNoTtlDiv == target.GoodsNoTtlDiv)
                 && (this.GoodsNoShowDiv == target.GoodsNoShowDiv)
                 //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<
                 && (this.NewPageDiv == target.NewPageDiv)
                 && (this.PrintType == target.PrintType)
                 && (this.ExtractDiv == target.ExtractDiv)
                 && (this.St_AnnualAddUpYearMonth == target.St_AnnualAddUpYearMonth)
                 && (this.Ed_AnnualAddUpYearMonth == target.Ed_AnnualAddUpYearMonth)
                 );
		}

		/// <summary>
		/// �o�׏��i�D�ǑΉ��\���o�����N���X��r����
		/// </summary>
		/// <param name="shipGdsPrimeListCndtn1">
		///                    ��r����ShipGdsPrimeListCndtn�N���X�̃C���X�^���X
		/// </param>
		/// <param name="shipGdsPrimeListCndtn2">��r����ShipGdsPrimeListCndtn�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ShipGdsPrimeListCndtn�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public static bool Equals(ShipGdsPrimeListCndtn2 shipGdsPrimeListCndtn1, ShipGdsPrimeListCndtn2 shipGdsPrimeListCndtn2)
		{
			return ((shipGdsPrimeListCndtn1.EnterpriseCode == shipGdsPrimeListCndtn2.EnterpriseCode)
				 && (shipGdsPrimeListCndtn1.SectionCodes == shipGdsPrimeListCndtn2.SectionCodes)
				 && (shipGdsPrimeListCndtn1.St_AddUpYearMonth == shipGdsPrimeListCndtn2.St_AddUpYearMonth)
				 && (shipGdsPrimeListCndtn1.Ed_AddUpYearMonth == shipGdsPrimeListCndtn2.Ed_AddUpYearMonth)
				 && (shipGdsPrimeListCndtn1.St_GoodsMakerCd == shipGdsPrimeListCndtn2.St_GoodsMakerCd)
				 && (shipGdsPrimeListCndtn1.Ed_GoodsMakerCd == shipGdsPrimeListCndtn2.Ed_GoodsMakerCd)
				 && (shipGdsPrimeListCndtn1.St_GoodsLGroup == shipGdsPrimeListCndtn2.St_GoodsLGroup)
				 && (shipGdsPrimeListCndtn1.Ed_GoodsLGroup == shipGdsPrimeListCndtn2.Ed_GoodsLGroup)
				 && (shipGdsPrimeListCndtn1.St_GoodsMGroup == shipGdsPrimeListCndtn2.St_GoodsMGroup)
				 && (shipGdsPrimeListCndtn1.Ed_GoodsMGroup == shipGdsPrimeListCndtn2.Ed_GoodsMGroup)
				 && (shipGdsPrimeListCndtn1.St_BLGroupCode == shipGdsPrimeListCndtn2.St_BLGroupCode)
				 && (shipGdsPrimeListCndtn1.Ed_BLGroupCode == shipGdsPrimeListCndtn2.Ed_BLGroupCode)
				 && (shipGdsPrimeListCndtn1.St_BLGoodsCode == shipGdsPrimeListCndtn2.St_BLGoodsCode)
				 && (shipGdsPrimeListCndtn1.Ed_BLGoodsCode == shipGdsPrimeListCndtn2.Ed_BLGoodsCode)
				 && (shipGdsPrimeListCndtn1.ShipCount == shipGdsPrimeListCndtn2.ShipCount)
				 && (shipGdsPrimeListCndtn1.EnterpriseName == shipGdsPrimeListCndtn2.EnterpriseName)
                 && (shipGdsPrimeListCndtn1.IsOptSection == shipGdsPrimeListCndtn2.IsOptSection)
                 && (shipGdsPrimeListCndtn1.IsSelectAllSection == shipGdsPrimeListCndtn2.IsSelectAllSection)
                 && (shipGdsPrimeListCndtn1.OutputDiv == shipGdsPrimeListCndtn2.OutputDiv)
                 && (shipGdsPrimeListCndtn1.NewPageDiv == shipGdsPrimeListCndtn2.NewPageDiv)
                 //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
                 && (shipGdsPrimeListCndtn1.GoodsNoTtlDiv == shipGdsPrimeListCndtn2.GoodsNoTtlDiv)
                 && (shipGdsPrimeListCndtn1.GoodsNoShowDiv == shipGdsPrimeListCndtn2.GoodsNoShowDiv)
                 //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<
                 && (shipGdsPrimeListCndtn1.PrintType == shipGdsPrimeListCndtn2.PrintType)
                 && (shipGdsPrimeListCndtn1.ExtractDiv == shipGdsPrimeListCndtn2.ExtractDiv)
                 && (shipGdsPrimeListCndtn1.St_AnnualAddUpYearMonth == shipGdsPrimeListCndtn2.St_AnnualAddUpYearMonth)
                 && (shipGdsPrimeListCndtn1.Ed_AnnualAddUpYearMonth == shipGdsPrimeListCndtn2.Ed_AnnualAddUpYearMonth)
                 );
		}
		/// <summary>
		/// �o�׏��i�D�ǑΉ��\���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ShipGdsPrimeListCndtn�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ShipGdsPrimeListCndtn�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public ArrayList Compare(ShipGdsPrimeListCndtn2 target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCodes != target.SectionCodes)resList.Add("SectionCodes");
			if(this.St_AddUpYearMonth != target.St_AddUpYearMonth)resList.Add("St_AddUpYearMonth");
			if(this.Ed_AddUpYearMonth != target.Ed_AddUpYearMonth)resList.Add("Ed_AddUpYearMonth");
			if(this.St_GoodsMakerCd != target.St_GoodsMakerCd)resList.Add("St_GoodsMakerCd");
			if(this.Ed_GoodsMakerCd != target.Ed_GoodsMakerCd)resList.Add("Ed_GoodsMakerCd");
			if(this.St_GoodsLGroup != target.St_GoodsLGroup)resList.Add("St_GoodsLGroup");
			if(this.Ed_GoodsLGroup != target.Ed_GoodsLGroup)resList.Add("Ed_GoodsLGroup");
			if(this.St_GoodsMGroup != target.St_GoodsMGroup)resList.Add("St_GoodsMGroup");
			if(this.Ed_GoodsMGroup != target.Ed_GoodsMGroup)resList.Add("Ed_GoodsMGroup");
			if(this.St_BLGroupCode != target.St_BLGroupCode)resList.Add("St_BLGroupCode");
			if(this.Ed_BLGroupCode != target.Ed_BLGroupCode)resList.Add("Ed_BLGroupCode");
			if(this.St_BLGoodsCode != target.St_BLGoodsCode)resList.Add("St_BLGoodsCode");
			if(this.Ed_BLGoodsCode != target.Ed_BLGoodsCode)resList.Add("Ed_BLGoodsCode");
			if(this.ShipCount != target.ShipCount)resList.Add("ShipCount");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
            if (this.IsOptSection != target.IsOptSection) resList.Add("IsOptSection");
            if (this.IsSelectAllSection != target.IsSelectAllSection) resList.Add("IsSelectAllSection");
            if (this.OutputDiv != target.OutputDiv) resList.Add("OutputDiv");
            if (this.NewPageDiv != target.NewPageDiv) resList.Add("NewPageDiv");
            //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
            if (this.GoodsNoTtlDiv != target.GoodsNoTtlDiv) resList.Add("GoodsNoTtlDiv");
            if (this.GoodsNoShowDiv != target.GoodsNoShowDiv) resList.Add("GoodsNoShowDiv");
            //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<
            if (this.PrintType != target.PrintType) resList.Add("PrintType");
            if (this.ExtractDiv != target.ExtractDiv) resList.Add("ExtractDiv");
            if (this.St_AnnualAddUpYearMonth != target.St_AnnualAddUpYearMonth) resList.Add("St_AnnualAddUpYearMonth");
            if (this.Ed_AnnualAddUpYearMonth != target.Ed_AnnualAddUpYearMonth) resList.Add("Ed_AnnualAddUpYearMonth");

			return resList;
		}

		/// <summary>
		/// �o�׏��i�D�ǑΉ��\���o�����N���X��r����
		/// </summary>
		/// <param name="shipGdsPrimeListCndtn1">��r����ShipGdsPrimeListCndtn�N���X�̃C���X�^���X</param>
		/// <param name="shipGdsPrimeListCndtn2">��r����ShipGdsPrimeListCndtn�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ShipGdsPrimeListCndtn�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public static ArrayList Compare(ShipGdsPrimeListCndtn2 shipGdsPrimeListCndtn1, ShipGdsPrimeListCndtn2 shipGdsPrimeListCndtn2)
		{
			ArrayList resList = new ArrayList();
			if(shipGdsPrimeListCndtn1.EnterpriseCode != shipGdsPrimeListCndtn2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(shipGdsPrimeListCndtn1.SectionCodes != shipGdsPrimeListCndtn2.SectionCodes)resList.Add("SectionCodes");
			if(shipGdsPrimeListCndtn1.St_AddUpYearMonth != shipGdsPrimeListCndtn2.St_AddUpYearMonth)resList.Add("St_AddUpYearMonth");
			if(shipGdsPrimeListCndtn1.Ed_AddUpYearMonth != shipGdsPrimeListCndtn2.Ed_AddUpYearMonth)resList.Add("Ed_AddUpYearMonth");
			if(shipGdsPrimeListCndtn1.St_GoodsMakerCd != shipGdsPrimeListCndtn2.St_GoodsMakerCd)resList.Add("St_GoodsMakerCd");
			if(shipGdsPrimeListCndtn1.Ed_GoodsMakerCd != shipGdsPrimeListCndtn2.Ed_GoodsMakerCd)resList.Add("Ed_GoodsMakerCd");
			if(shipGdsPrimeListCndtn1.St_GoodsLGroup != shipGdsPrimeListCndtn2.St_GoodsLGroup)resList.Add("St_GoodsLGroup");
			if(shipGdsPrimeListCndtn1.Ed_GoodsLGroup != shipGdsPrimeListCndtn2.Ed_GoodsLGroup)resList.Add("Ed_GoodsLGroup");
			if(shipGdsPrimeListCndtn1.St_GoodsMGroup != shipGdsPrimeListCndtn2.St_GoodsMGroup)resList.Add("St_GoodsMGroup");
			if(shipGdsPrimeListCndtn1.Ed_GoodsMGroup != shipGdsPrimeListCndtn2.Ed_GoodsMGroup)resList.Add("Ed_GoodsMGroup");
			if(shipGdsPrimeListCndtn1.St_BLGroupCode != shipGdsPrimeListCndtn2.St_BLGroupCode)resList.Add("St_BLGroupCode");
			if(shipGdsPrimeListCndtn1.Ed_BLGroupCode != shipGdsPrimeListCndtn2.Ed_BLGroupCode)resList.Add("Ed_BLGroupCode");
			if(shipGdsPrimeListCndtn1.St_BLGoodsCode != shipGdsPrimeListCndtn2.St_BLGoodsCode)resList.Add("St_BLGoodsCode");
			if(shipGdsPrimeListCndtn1.Ed_BLGoodsCode != shipGdsPrimeListCndtn2.Ed_BLGoodsCode)resList.Add("Ed_BLGoodsCode");
			if(shipGdsPrimeListCndtn1.ShipCount != shipGdsPrimeListCndtn2.ShipCount)resList.Add("ShipCount");
			if(shipGdsPrimeListCndtn1.EnterpriseName != shipGdsPrimeListCndtn2.EnterpriseName)resList.Add("EnterpriseName");
            if (shipGdsPrimeListCndtn1.IsOptSection != shipGdsPrimeListCndtn2.IsOptSection) resList.Add("IsOptSection");
            if (shipGdsPrimeListCndtn1.IsSelectAllSection != shipGdsPrimeListCndtn2.IsSelectAllSection) resList.Add("IsSelectAllSection");
            if (shipGdsPrimeListCndtn1.OutputDiv != shipGdsPrimeListCndtn2.OutputDiv) resList.Add("OutputDiv");
            if (shipGdsPrimeListCndtn1.NewPageDiv != shipGdsPrimeListCndtn2.NewPageDiv) resList.Add("NewPageDiv");
            //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
            if (shipGdsPrimeListCndtn1.GoodsNoTtlDiv != shipGdsPrimeListCndtn2.GoodsNoTtlDiv) resList.Add("GoodsNoTtlDiv");
            if (shipGdsPrimeListCndtn1.GoodsNoShowDiv != shipGdsPrimeListCndtn2.GoodsNoShowDiv) resList.Add("GoodsNoShowDiv");
            //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<
            if (shipGdsPrimeListCndtn1.PrintType != shipGdsPrimeListCndtn2.PrintType) resList.Add("PrintType");
            if (shipGdsPrimeListCndtn1.ExtractDiv != shipGdsPrimeListCndtn2.ExtractDiv) resList.Add("ExtractDiv");
            if (shipGdsPrimeListCndtn1.St_AnnualAddUpYearMonth != shipGdsPrimeListCndtn2.St_AnnualAddUpYearMonth) resList.Add("St_AnnualAddUpYearMonth");
            if (shipGdsPrimeListCndtn1.Ed_AnnualAddUpYearMonth != shipGdsPrimeListCndtn2.Ed_AnnualAddUpYearMonth) resList.Add("Ed_AnnualAddUpYearMonth"); 

			return resList;
        }

        #region �����ږ��̃v���p�e�B
        /// <summary>
        /// �o�͋敪�^�C�g���@�v���p�e�B
        /// </summary>
        public string OutputDivStateTitle
        {
            get
            {
                switch (this._outputDiv)
                {
                    case OutputDivState.All: return ct_OutputDivState_All;
                    case OutputDivState.Stock: return ct_OutputDivState_Stock;
                    case OutputDivState.Order: return ct_OutputDivState_Order;
                    
                    default: return "";
                }
            }
        }

        /// <summary>
        /// ���y�[�W�敪�^�C�g���@�v���p�e�B
        /// </summary>
        public string NewPageDivStateTitle
        {
            get
            {
                switch (this._newPageDiv)
                {
                    case NewPageDivState.Section: return ct_NewPageDivState_Section;
                    case NewPageDivState.None: return ct_NewPageDivState_None;
                    default: return "";
                }
            }
        }

        //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
        /// <summary>
        /// �i�ԏW�v�敪�@�v���p�e�B
        /// </summary>
        public string GoodsNoTtlDivTitle
        {
            get
            {
                switch (this._goodsNoTtlDiv)
                {
                    case GoodsNoTtlDivState.Total:
                        return ct_GoodsNoTtlDivState_Total;
                    case GoodsNoTtlDivState.Separate:
                        return ct_GoodsNoTtlDivState_Separate;
                    default:
                        return "";
                }
            }
        }
        /// <summary>
        /// �i�ԕ\���敪�@�v���p�e�B
        /// </summary>
        public string GoodsNoShowDivTitle
        {
            get
            {
                switch (this._goodsNoShowDiv)
                {
                    case GoodsNoShowDivState.New:
                        return ct_GoodsNoShowDivState_New;
                    case GoodsNoShowDivState.Old:
                        return ct_GoodsNoShowDivState_Old;
                    default:
                        return "";
                }
            }
        }
        //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<

        /// <summary>
        /// ����^�C�v�^�C�g���@�v���p�e�B
        /// </summary>
        public string PrintTypeStateTitle
        {
            get
            {
                switch (this._printType)
                {
                    case PrintTypeState.Month: return ct_PrintTypeState_Month;
                    case PrintTypeState.Term: return ct_PrintTypeState_Term;

                    default: return "";
                }
            }
        }

        /// <summary>
        /// ���o�敪�^�C�g���@�v���p�e�B
        /// </summary>
        public string ExtractDivStateTitle
        {
            get
            {
                switch (this._extractDiv)
                {
                    case ExtractDivState.Pure: return ct_ExtractDivState_Pure;
                    case ExtractDivState.Superior: return ct_ExtractDivState_Superior;

                    default: return "";
                }
            }
        }

        
        #endregion

        #region ���񋓑�

        /// <summary>
        /// �����敪�@�񋓑�
        /// </summary>
        public enum OutputDivState
        {
            /// <summary>�S��</summary>
            All = 0,
            /// <summary>�݌�</summary>
            Stock = 1,
            /// <summary>���</summary>
            Order = 2,
        }

        /// <summary>
        /// ����^�C�v �񋓑�
        /// </summary>
        public enum PrintTypeState
        {
            /// <summary>����</summary>
            Month = 0,
            /// <summary>����</summary>
            Term = 1,

        }

        /// <summary>
        /// ���o�敪�@�񋓑�
        /// </summary>
        public enum ExtractDivState
        {
            /// <summary>����</summary>
            Pure = 0,
            /// <summary>�D��</summary>
            Superior = 1,
        }

        /// <summary>
        /// ���y�[�W�敪�@�񋓑�
        /// </summary>
        public enum NewPageDivState
        {
            /// <summary>���_��</summary>
            Section = 0,
            /// <summary>���Ȃ�</summary>
            None = 1,
        }

        //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
        /// <summary>
        /// �i�ԏW�v�敪�@�񋓌^
        /// </summary>
        public enum GoodsNoTtlDivState
        {
            /// <summary>�ʁX</summary>
            Separate = 0,
            /// <summary>���Z</summary>
            Total = 1,
        }

        /// <summary>
        /// �i�ԕ\���敪�@�񋓌^
        /// </summary>
        public enum GoodsNoShowDivState
        {
            /// <summary>�V�i��</summary>
            New = 0,
            /// <summary>���i��</summary>
            Old = 1,
        }
        //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<

        #endregion

        #region �����ږ���

        /// <summary>�o�͋敪 �S��</summary>
        private const string ct_OutputDivState_All = "�S��";
        /// <summary>�o�͋敪 �݌�</summary>
        private const string ct_OutputDivState_Stock = "�݌�";
        /// <summary>�o�͋敪 ���</summary>
        private const string ct_OutputDivState_Order = "���";

        /// <summary>����^�C�v�@����</summary>
        private const string ct_PrintTypeState_Month = "����";
        /// <summary>����^�C�v�@����</summary>
        private const string ct_PrintTypeState_Term = "����";

        /// <summary>���o�敪�@����</summary>
        private const string ct_ExtractDivState_Pure = "����";
        /// <summary>���o�敪�@�D��</summary>
        private const string ct_ExtractDivState_Superior = "�D��";


        /// <summary>���y�[�W�敪 ���_��</summary>
        private const string ct_NewPageDivState_Section = "���_�P��";
        /// <summary>���y�[�W�敪 ���Ȃ�</summary>
        private const string ct_NewPageDivState_None = "���Ȃ�";

        //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
        /// <summary>�i�ԏW�v�敪 ���Z</summary>
        public const string ct_GoodsNoTtlDivState_Total = "���Z";
        /// <summary>�i�ԏW�v�敪 �ʁX</summary>
        //public const string ct_GoodsNoTtlDivState_Separate = "�ʁX";// DEL 2015/03/27 Redmine#44209��#423�i�ԏW�v�敪�̖��̕ύX
        public const string ct_GoodsNoTtlDivState_Separate = "�ʏ�";// ADD 2015/03/27 Redmine#44209��#423�i�ԏW�v�敪�̖��̕ύX

        /// <summary>�i�ԕ\���敪 �V�i��</summary>
        public const string ct_GoodsNoShowDivState_New = "�V�i��";
        /// <summary>�i�ԕ\���敪 ���i��</summary>
        public const string ct_GoodsNoShowDivState_Old = "���i��";
        //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<

        #endregion
    }
}
