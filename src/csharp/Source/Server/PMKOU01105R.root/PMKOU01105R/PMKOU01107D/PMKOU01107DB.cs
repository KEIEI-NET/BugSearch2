using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{

	/// public class name:   SupplierCheckResultWork
	/// <summary>
	///                      �d���`�F�b�N�������o���ʃN���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �d���`�F�b�N�������o���ʃN���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/12/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2010/10/21 ����� PM1012PM.NS��Q���ǑΉ��i�W�����j</br>
    /// <br>Update Note      :   2012/08/30 ������  Redmine#31879�̑Ή� UOE�d���f�[�^�̋敪���擾</br>
    /// <br>Update Note      :   2012/10/09 �� ��  Redmine#31879�̑Ή� �ԓ`�敪���擾</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SupplierCheckResultWork : IFileHeader
	{
		/// <summary>�쐬����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _createDateTime;

		/// <summary>�X�V����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _updateDateTime;

		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>GUID</summary>
		/// <remarks>���ʃt�@�C���w�b�_</remarks>
		private Guid _fileHeaderGuid;

		/// <summary>�X�V�]�ƈ��R�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_</remarks>
		private string _updEmployeeCode = "";

		/// <summary>�X�V�A�Z���u��ID1</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
		private string _updAssemblyId1 = "";

		/// <summary>�X�V�A�Z���u��ID2</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
		private string _updAssemblyId2 = "";

		/// <summary>�_���폜�敪</summary>
		/// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>���_�R�[�h</summary>
		private string _sectionCode = "";

		/// <summary>�d���`�F�b�N�敪�i�����j</summary>
		/// <remarks>0:������,1:�����ρ@�i���׃f�[�^�Ǝd����`�[���ׂ̔�r�j</remarks>
		private Int32 _stockCheckDivCAddUp;

		/// <summary>�d���`�F�b�N�敪�i�����j</summary>
		/// <remarks>0:������,1:�����ρ@�i���׃f�[�^�Ǝd����`�[���ׂ̔�r�j</remarks>
		private Int32 _stockCheckDivDaily;

		/// <summary>�d����</summary>
		/// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
		private DateTime _stockDate;

		/// <summary>���͓�</summary>
		/// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
		private DateTime _inputDay;

		/// <summary>�d���`�[�ԍ�</summary>
		/// <remarks>�����`�[�ԍ��A�d���`�[�ԍ��A���ד`�[�ԍ������˂�</remarks>
		private Int32 _supplierSlipNo;

		/// <summary>�����`�[�ԍ�</summary>
		/// <remarks>�d����`�[�ԍ��Ɏg�p����</remarks>
		private string _partySaleSlipNum = "";

		/// <summary>�d�����z�i�ō��݁j</summary>
		private Int64 _stockPriceTaxInc;

		/// <summary>�d�����z�i�Ŕ����j</summary>
		private Int64 _stockPriceTaxExc;

		/// <summary>�d�����z����Ŋz(����)</summary>
		/// <remarks>�d�����z�i�ō��݁j- �d�����z�i�Ŕ����j������Œ����z�����˂�</remarks>
		private Int64 _stockPriceConsTax;

		/// <summary>���i�ԍ�</summary>
		private string _goodsNo = "";

		/// <summary>�d����</summary>
		private Double _stockCount;

		/// <summary>BL���i�R�[�h</summary>
		private Int32 _bLGoodsCode;

		/// <summary>���i����</summary>
		private string _goodsName = "";

		/// <summary>�d���P���i�Ŕ��C�����j</summary>
		/// <remarks>�Ŕ���</remarks>
		private Double _stockUnitPriceFl;

		/// <summary>�艿�i�Ŕ��C�����j</summary>
		/// <remarks>�Ŕ���</remarks>
		private Double _listPriceTaxExcFl;

		/// <summary>����P���i�Ŕ��C�����j</summary>
		private Double _salesUnPrcTaxExcFl;

		/// <summary>������z�i�Ŕ����j</summary>
		private Int64 _salesMoneyTaxExc;

		/// <summary>������t</summary>
		/// <remarks>(YYYYMMDD)</remarks>
		private DateTime _salesDate;

		/// <summary>����`�[�ԍ�</summary>
		private string _salesSlipNum = "";

		/// <summary>���Ӑ�R�[�h</summary>
		private Int32 _customerCode;

		/// <summary>���Ӑ旪��</summary>
		private string _customerSnm = "";

		/// <summary>�̔��]�ƈ�����</summary>
		private string _salesEmployeeNm = "";

		/// <summary>��t�]�ƈ�����</summary>
		private string _frontEmployeeNm = "";

		/// <summary>������͎Җ���</summary>
		private string _salesInputName = "";

		/// <summary>�t�n�d���}�[�N�P</summary>
		/// <remarks>UserOrderEntory</remarks>
		private string _uoeRemark1 = "";

		/// <summary>�t�n�d���}�[�N�Q</summary>
		private string _uoeRemark2 = "";

		/// <summary>�d����R�[�h</summary>
		private Int32 _supplierCd;

		/// <summary>�d���旪��</summary>
		private string _supplierSnm = "";

		/// <summary>�d���`��</summary>
		/// <remarks>0:�d���@�i�󒍃X�e�[�^�X�j</remarks>
		private Int32 _supplierFormal;

		/// <summary>�d�����גʔ�</summary>
		private Int64 _stockSlipDtlNum;

		/// <summary>�ύX�O�d���P���i�����j</summary>
		/// <remarks>�Ŕ����A�|���Z�o����</remarks>
		private Double _bfStockUnitPriceFl;

		/// <summary>�d���`�[�敪</summary>
		/// <remarks>10:�d��,20:�ԕi</remarks>
		private Int32 _supplierSlipCd;

		/// <summary>�d�����i�敪</summary>
		/// <remarks>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,6:���v����</remarks>
		private Int32 _stockGoodsCd;

		/// <summary>�d�������œ]�ŕ����R�[�h</summary>
		/// <remarks>0:�`�[�P�� 1:���גP�� 2:�����P�ʁi������j3:�����P�ʁi���Ӑ�j9:��ې�</remarks>
		private Int32 _suppCTaxLayCd;

		/// <summary>�d�����z�v�i�ō��݁j</summary>
		/// <remarks>�O�Ŏ��F�Ŕ����{����ŁA���Ŏ��F���ŉ��i�i�ō��j�̏W�v</remarks>
		private Int64 _stockTtlPricTaxInc;

		/// <summary>�d�����z�v�i�Ŕ����j</summary>
		/// <remarks>�O�Ŏ��F�Ŕ����i�̏W�v�A���Ŏ��F���ŉ��i�i�ō��j�̏W�v�|�����</remarks>
		private Int64 _stockTtlPricTaxExc;

		/// <summary>�d�����z����Ŋz(�`�[)</summary>
		/// <remarks>�d�����z����Ŋz�i�O�Łj+�d�����z����Ŋz�i���Łj</remarks>
		private Int64 _stockTtlPriceConsTax;

        // --- ADD 2010/10/21 ---------->>>>>
        /// <summary>�d�����z���v</summary>
        /// <remarks>�d�����z�v�i�ō��݁j�{��ېőΏۊz���v</remarks>
        private Int64 _stockTotalPrice;

        /// <summary>�d�����z���v</summary>
        /// <remarks>�d�����z�v�i�Ŕ����j�{��ېőΏۊz���v</remarks>
        private Int64 _stockSubttlPrice;
        // --- ADD 2010/10/21 ----------<<<<<

        //---ADD BY �� �� on 2012/10/09 for Redmine#31879----->>>>>
        /// <summary> �ԓ`�敪</summary>
        /// <remarks>0:���`,1:�ԓ`,2:����</remarks>
        private Int32 _debitNoteDiv;
        //---ADD BY �� �� on 2012/10/09 for Redmine#31879-----<<<<<

        //---ADD BY ������ on 2012/08/30 for Redmine#31879----->>>>>
        /// <summary> �������@</summary>
        /// <remarks>0:����������,1:FAX���M,2:�I�����C������,4:�����ώ���o�^</remarks>
        private Int32 _wayToOrder;


        /// public propaty name  :  WayToOrder
        /// <summary>�������@�v���p�e�B</summary>
        /// <value>0:����������,1:FAX���M,2:�I�����C������,4:�����ώ���o�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������@�v���p�e�B</br>
        /// <br>Programer        :   �ǉ�</br>
        /// </remarks>
        public Int32 WayToOrder
        {
            get { return _wayToOrder; }
            set { _wayToOrder = value; }
        }
        //---ADD BY ������ on 2012/08/30 for Redmine#31879-----<<<<<

        //---ADD BY �� �� on 2012/10/09 for Redmine#31879----->>>>>
        /// public propaty name  :  DebitNoteDiv
        /// <summary>�ԓ`�敪�v���p�e�B</summary>
        /// <value>0:���`,1:�ԓ`,2:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԓ`�敪�v���p�e�B</br>
        /// <br>Programer        :   �ǉ�</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }
        //---ADD BY �� �� on 2012/10/09 for Redmine#31879-----<<<<<

		/// public propaty name  :  CreateDateTime
		/// <summary>�쐬�����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime CreateDateTime
		{
			get{return _createDateTime;}
			set{_createDateTime = value;}
		}

		/// public propaty name  :  UpdateDateTime
		/// <summary>�X�V�����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime UpdateDateTime
		{
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
		}

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

		/// public propaty name  :  FileHeaderGuid
		/// <summary>GUID�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   GUID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Guid FileHeaderGuid
		{
			get{return _fileHeaderGuid;}
			set{_fileHeaderGuid = value;}
		}

		/// public propaty name  :  UpdEmployeeCode
		/// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdEmployeeCode
		{
			get{return _updEmployeeCode;}
			set{_updEmployeeCode = value;}
		}

		/// public propaty name  :  UpdAssemblyId1
		/// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdAssemblyId1
		{
			get{return _updAssemblyId1;}
			set{_updAssemblyId1 = value;}
		}

		/// public propaty name  :  UpdAssemblyId2
		/// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdAssemblyId2
		{
			get{return _updAssemblyId2;}
			set{_updAssemblyId2 = value;}
		}

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>�_���폜�敪�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �_���폜�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 LogicalDeleteCode
		{
			get{return _logicalDeleteCode;}
			set{_logicalDeleteCode = value;}
		}

		/// public propaty name  :  SectionCode
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

		/// public propaty name  :  StockCheckDivCAddUp
		/// <summary>�d���`�F�b�N�敪�i�����j�v���p�e�B</summary>
		/// <value>0:������,1:�����ρ@�i���׃f�[�^�Ǝd����`�[���ׂ̔�r�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���`�F�b�N�敪�i�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockCheckDivCAddUp
		{
			get{return _stockCheckDivCAddUp;}
			set{_stockCheckDivCAddUp = value;}
		}

		/// public propaty name  :  StockCheckDivDaily
		/// <summary>�d���`�F�b�N�敪�i�����j�v���p�e�B</summary>
		/// <value>0:������,1:�����ρ@�i���׃f�[�^�Ǝd����`�[���ׂ̔�r�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���`�F�b�N�敪�i�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockCheckDivDaily
		{
			get{return _stockCheckDivDaily;}
			set{_stockCheckDivDaily = value;}
		}

		/// public propaty name  :  StockDate
		/// <summary>�d�����v���p�e�B</summary>
		/// <value>YYYYMMDD�@�i�X�V�N�����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime StockDate
		{
			get{return _stockDate;}
			set{_stockDate = value;}
		}

		/// public propaty name  :  InputDay
		/// <summary>���͓��v���p�e�B</summary>
		/// <value>YYYYMMDD�@�i�X�V�N�����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���͓��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime InputDay
		{
			get{return _inputDay;}
			set{_inputDay = value;}
		}

		/// public propaty name  :  SupplierSlipNo
		/// <summary>�d���`�[�ԍ��v���p�e�B</summary>
		/// <value>�����`�[�ԍ��A�d���`�[�ԍ��A���ד`�[�ԍ������˂�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierSlipNo
		{
			get{return _supplierSlipNo;}
			set{_supplierSlipNo = value;}
		}

		/// public propaty name  :  PartySaleSlipNum
		/// <summary>�����`�[�ԍ��v���p�e�B</summary>
		/// <value>�d����`�[�ԍ��Ɏg�p����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PartySaleSlipNum
		{
			get{return _partySaleSlipNum;}
			set{_partySaleSlipNum = value;}
		}

		/// public propaty name  :  StockPriceTaxInc
		/// <summary>�d�����z�i�ō��݁j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����z�i�ō��݁j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StockPriceTaxInc
		{
			get{return _stockPriceTaxInc;}
			set{_stockPriceTaxInc = value;}
		}

		/// public propaty name  :  StockPriceTaxExc
		/// <summary>�d�����z�i�Ŕ����j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����z�i�Ŕ����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StockPriceTaxExc
		{
			get{return _stockPriceTaxExc;}
			set{_stockPriceTaxExc = value;}
		}

		/// public propaty name  :  StockPriceConsTax
		/// <summary>�d�����z����Ŋz(����)�v���p�e�B</summary>
		/// <value>�d�����z�i�ō��݁j- �d�����z�i�Ŕ����j������Œ����z�����˂�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����z����Ŋz(����)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StockPriceConsTax
		{
			get{return _stockPriceConsTax;}
			set{_stockPriceConsTax = value;}
		}

		/// public propaty name  :  GoodsNo
		/// <summary>���i�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsNo
		{
			get{return _goodsNo;}
			set{_goodsNo = value;}
		}

		/// public propaty name  :  StockCount
		/// <summary>�d�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double StockCount
		{
			get{return _stockCount;}
			set{_stockCount = value;}
		}

		/// public propaty name  :  BLGoodsCode
		/// <summary>BL���i�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BLGoodsCode
		{
			get{return _bLGoodsCode;}
			set{_bLGoodsCode = value;}
		}

		/// public propaty name  :  GoodsName
		/// <summary>���i���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsName
		{
			get{return _goodsName;}
			set{_goodsName = value;}
		}

		/// public propaty name  :  StockUnitPriceFl
		/// <summary>�d���P���i�Ŕ��C�����j�v���p�e�B</summary>
		/// <value>�Ŕ���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���P���i�Ŕ��C�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double StockUnitPriceFl
		{
			get{return _stockUnitPriceFl;}
			set{_stockUnitPriceFl = value;}
		}

		/// public propaty name  :  ListPriceTaxExcFl
		/// <summary>�艿�i�Ŕ��C�����j�v���p�e�B</summary>
		/// <value>�Ŕ���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �艿�i�Ŕ��C�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double ListPriceTaxExcFl
		{
			get{return _listPriceTaxExcFl;}
			set{_listPriceTaxExcFl = value;}
		}

		/// public propaty name  :  SalesUnPrcTaxExcFl
		/// <summary>����P���i�Ŕ��C�����j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����P���i�Ŕ��C�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double SalesUnPrcTaxExcFl
		{
			get{return _salesUnPrcTaxExcFl;}
			set{_salesUnPrcTaxExcFl = value;}
		}

		/// public propaty name  :  SalesMoneyTaxExc
		/// <summary>������z�i�Ŕ����j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������z�i�Ŕ����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesMoneyTaxExc
		{
			get{return _salesMoneyTaxExc;}
			set{_salesMoneyTaxExc = value;}
		}

		/// public propaty name  :  SalesDate
		/// <summary>������t�v���p�e�B</summary>
		/// <value>(YYYYMMDD)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime SalesDate
		{
			get{return _salesDate;}
			set{_salesDate = value;}
		}

		/// public propaty name  :  SalesSlipNum
		/// <summary>����`�[�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesSlipNum
		{
			get{return _salesSlipNum;}
			set{_salesSlipNum = value;}
		}

		/// public propaty name  :  CustomerCode
		/// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get{return _customerCode;}
			set{_customerCode = value;}
		}

		/// public propaty name  :  CustomerSnm
		/// <summary>���Ӑ旪�̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CustomerSnm
		{
			get{return _customerSnm;}
			set{_customerSnm = value;}
		}

		/// public propaty name  :  SalesEmployeeNm
		/// <summary>�̔��]�ƈ����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �̔��]�ƈ����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesEmployeeNm
		{
			get{return _salesEmployeeNm;}
			set{_salesEmployeeNm = value;}
		}

		/// public propaty name  :  FrontEmployeeNm
		/// <summary>��t�]�ƈ����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��t�]�ƈ����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string FrontEmployeeNm
		{
			get{return _frontEmployeeNm;}
			set{_frontEmployeeNm = value;}
		}

		/// public propaty name  :  SalesInputName
		/// <summary>������͎Җ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������͎Җ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesInputName
		{
			get{return _salesInputName;}
			set{_salesInputName = value;}
		}

		/// public propaty name  :  UoeRemark1
		/// <summary>�t�n�d���}�[�N�P�v���p�e�B</summary>
		/// <value>UserOrderEntory</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �t�n�d���}�[�N�P�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UoeRemark1
		{
			get{return _uoeRemark1;}
			set{_uoeRemark1 = value;}
		}

		/// public propaty name  :  UoeRemark2
		/// <summary>�t�n�d���}�[�N�Q�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �t�n�d���}�[�N�Q�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UoeRemark2
		{
			get{return _uoeRemark2;}
			set{_uoeRemark2 = value;}
		}

		/// public propaty name  :  SupplierCd
		/// <summary>�d����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierCd
		{
			get{return _supplierCd;}
			set{_supplierCd = value;}
		}

		/// public propaty name  :  SupplierSnm
		/// <summary>�d���旪�̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���旪�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SupplierSnm
		{
			get{return _supplierSnm;}
			set{_supplierSnm = value;}
		}

		/// public propaty name  :  SupplierFormal
		/// <summary>�d���`���v���p�e�B</summary>
		/// <value>0:�d���@�i�󒍃X�e�[�^�X�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���`���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierFormal
		{
			get{return _supplierFormal;}
			set{_supplierFormal = value;}
		}

		/// public propaty name  :  StockSlipDtlNum
		/// <summary>�d�����גʔԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����גʔԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StockSlipDtlNum
		{
			get{return _stockSlipDtlNum;}
			set{_stockSlipDtlNum = value;}
		}

		/// public propaty name  :  BfStockUnitPriceFl
		/// <summary>�ύX�O�d���P���i�����j�v���p�e�B</summary>
		/// <value>�Ŕ����A�|���Z�o����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ύX�O�d���P���i�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double BfStockUnitPriceFl
		{
			get{return _bfStockUnitPriceFl;}
			set{_bfStockUnitPriceFl = value;}
		}

		/// public propaty name  :  SupplierSlipCd
		/// <summary>�d���`�[�敪�v���p�e�B</summary>
		/// <value>10:�d��,20:�ԕi</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���`�[�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierSlipCd
		{
			get{return _supplierSlipCd;}
			set{_supplierSlipCd = value;}
		}

		/// public propaty name  :  StockGoodsCd
		/// <summary>�d�����i�敪�v���p�e�B</summary>
		/// <value>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,6:���v����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����i�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockGoodsCd
		{
			get{return _stockGoodsCd;}
			set{_stockGoodsCd = value;}
		}

		/// public propaty name  :  SuppCTaxLayCd
		/// <summary>�d�������œ]�ŕ����R�[�h�v���p�e�B</summary>
		/// <value>0:�`�[�P�� 1:���גP�� 2:�����P�ʁi������j3:�����P�ʁi���Ӑ�j9:��ې�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�������œ]�ŕ����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SuppCTaxLayCd
		{
			get{return _suppCTaxLayCd;}
			set{_suppCTaxLayCd = value;}
		}

		/// public propaty name  :  StockTtlPricTaxInc
		/// <summary>�d�����z�v�i�ō��݁j�v���p�e�B</summary>
		/// <value>�O�Ŏ��F�Ŕ����{����ŁA���Ŏ��F���ŉ��i�i�ō��j�̏W�v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����z�v�i�ō��݁j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StockTtlPricTaxInc
		{
			get{return _stockTtlPricTaxInc;}
			set{_stockTtlPricTaxInc = value;}
		}

		/// public propaty name  :  StockTtlPricTaxExc
		/// <summary>�d�����z�v�i�Ŕ����j�v���p�e�B</summary>
		/// <value>�O�Ŏ��F�Ŕ����i�̏W�v�A���Ŏ��F���ŉ��i�i�ō��j�̏W�v�|�����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����z�v�i�Ŕ����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StockTtlPricTaxExc
		{
			get{return _stockTtlPricTaxExc;}
			set{_stockTtlPricTaxExc = value;}
		}

		/// public propaty name  :  StockTtlPriceConsTax
		/// <summary>�d�����z����Ŋz(�`�[)�v���p�e�B</summary>
		/// <value>�d�����z����Ŋz�i�O�Łj+�d�����z����Ŋz�i���Łj</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����z����Ŋz(�`�[)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StockTtlPriceConsTax
		{
			get{return _stockTtlPriceConsTax;}
			set{_stockTtlPriceConsTax = value;}
		}

        // --- ADD 2010/10/21 ---------->>>>>
        /// public propaty name  :  StockTotalPrice
        /// <summary>�d�����z���v�v���p�e�B</summary>
        /// <value>�d�����z�v�i�ō��݁j�{��ېőΏۊz���v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTotalPrice
        {
            get { return _stockTotalPrice; }
            set { _stockTotalPrice = value; }
        }

        /// public propaty name  :  StockSubttlPrice
        /// <summary>�d�����z���v�v���p�e�B</summary>
        /// <value>�d�����z�v�i�Ŕ����j�{��ېőΏۊz���v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockSubttlPrice
        {
            get { return _stockSubttlPrice; }
            set { _stockSubttlPrice = value; }
        }
        // --- ADD 2010/10/21 ----------<<<<<

		/// <summary>
		/// �d���`�F�b�N�������o���ʃN���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>SupplierCheckResultWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SupplierCheckResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SupplierCheckResultWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SupplierCheckResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SupplierCheckResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SupplierCheckResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SupplierCheckResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SupplierCheckResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SupplierCheckResultWork || graph is ArrayList || graph is SupplierCheckResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SupplierCheckResultWork).FullName));

            if (graph != null && graph is SupplierCheckResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SupplierCheckResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SupplierCheckResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SupplierCheckResultWork[])graph).Length;
            }
            else if (graph is SupplierCheckResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //�X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //�d���`�F�b�N�敪�i�����j
            serInfo.MemberInfo.Add(typeof(Int32)); //StockCheckDivCAddUp
            //�d���`�F�b�N�敪�i�����j
            serInfo.MemberInfo.Add(typeof(Int32)); //StockCheckDivDaily
            //�d����
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDate
            //���͓�
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //�d���`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //�����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNum
            //�d�����z�i�ō��݁j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxInc
            //�d�����z�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxExc
            //�d�����z����Ŋz(����)
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceConsTax
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //�d����
            serInfo.MemberInfo.Add(typeof(Double)); //StockCount
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //�d���P���i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //�艿�i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            //����P���i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxExcFl
            //������z�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //������t
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ旪��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //�̔��]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeNm
            //��t�]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //FrontEmployeeNm
            //������͎Җ���
            serInfo.MemberInfo.Add(typeof(string)); //SalesInputName
            //�t�n�d���}�[�N�P
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark1
            //�t�n�d���}�[�N�Q
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark2
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //�d���`��
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //�d�����גʔ�
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSlipDtlNum
            //�ύX�O�d���P���i�����j
            serInfo.MemberInfo.Add(typeof(Double)); //BfStockUnitPriceFl
            //�d���`�[�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipCd
            //�d�����i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockGoodsCd
            //�d�������œ]�ŕ����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppCTaxLayCd
            //�d�����z�v�i�ō��݁j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPricTaxInc
            //�d�����z�v�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPricTaxExc
            //�d�����z����Ŋz(�`�[)
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPriceConsTax
            // --- ADD 2010/10/21 ---------->>>>>
            //�d�����z���v
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalPrice
            //�d�����z���v
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSubttlPrice
            // --- ADD 2010/10/21 ----------<<<<<
            //�������@
            serInfo.MemberInfo.Add(typeof(Int32)); //WayToOrder //ADD BY ������ on 2012/08/30 for Redmine#31879
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv //�ԓ`�敪 ADD BY �� �� on 2012/10/09 for Redmine#31879


            serInfo.Serialize(writer, serInfo);
            if (graph is SupplierCheckResultWork)
            {
                SupplierCheckResultWork temp = (SupplierCheckResultWork)graph;

                SetSupplierCheckResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SupplierCheckResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SupplierCheckResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SupplierCheckResultWork temp in lst)
                {
                    SetSupplierCheckResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SupplierCheckResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        // --- UPD 2010/10/21 ---------->>>>>
        //private const int currentMemberCount = 46;
        //private const int currentMemberCount = 48;//DEL BY ������ on 2012/08/30 for Redmine#31879
        //private const int currentMemberCount = 49;//ADD BY ������ on 2012/08/30 for Redmine#31879
        private const int currentMemberCount = 50;//ADD BY �� �� on 2012/10/09 for Redmine#31879
        // --- UPD 2010/10/21 ----------<<<<<

        /// <summary>
        ///  SupplierCheckResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SupplierCheckResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSupplierCheckResultWork(System.IO.BinaryWriter writer, SupplierCheckResultWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //�X�V�]�ƈ��R�[�h
            writer.Write(temp.UpdEmployeeCode);
            //�X�V�A�Z���u��ID1
            writer.Write(temp.UpdAssemblyId1);
            //�X�V�A�Z���u��ID2
            writer.Write(temp.UpdAssemblyId2);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //�d���`�F�b�N�敪�i�����j
            writer.Write(temp.StockCheckDivCAddUp);
            //�d���`�F�b�N�敪�i�����j
            writer.Write(temp.StockCheckDivDaily);
            //�d����
            writer.Write((Int64)temp.StockDate.Ticks);
            //���͓�
            writer.Write((Int64)temp.InputDay.Ticks);
            //�d���`�[�ԍ�
            writer.Write(temp.SupplierSlipNo);
            //�����`�[�ԍ�
            writer.Write(temp.PartySaleSlipNum);
            //�d�����z�i�ō��݁j
            writer.Write(temp.StockPriceTaxInc);
            //�d�����z�i�Ŕ����j
            writer.Write(temp.StockPriceTaxExc);
            //�d�����z����Ŋz(����)
            writer.Write(temp.StockPriceConsTax);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //�d����
            writer.Write(temp.StockCount);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //���i����
            writer.Write(temp.GoodsName);
            //�d���P���i�Ŕ��C�����j
            writer.Write(temp.StockUnitPriceFl);
            //�艿�i�Ŕ��C�����j
            writer.Write(temp.ListPriceTaxExcFl);
            //����P���i�Ŕ��C�����j
            writer.Write(temp.SalesUnPrcTaxExcFl);
            //������z�i�Ŕ����j
            writer.Write(temp.SalesMoneyTaxExc);
            //������t
            writer.Write((Int64)temp.SalesDate.Ticks);
            //����`�[�ԍ�
            writer.Write(temp.SalesSlipNum);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ旪��
            writer.Write(temp.CustomerSnm);
            //�̔��]�ƈ�����
            writer.Write(temp.SalesEmployeeNm);
            //��t�]�ƈ�����
            writer.Write(temp.FrontEmployeeNm);
            //������͎Җ���
            writer.Write(temp.SalesInputName);
            //�t�n�d���}�[�N�P
            writer.Write(temp.UoeRemark1);
            //�t�n�d���}�[�N�Q
            writer.Write(temp.UoeRemark2);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //�d���`��
            writer.Write(temp.SupplierFormal);
            //�d�����גʔ�
            writer.Write(temp.StockSlipDtlNum);
            //�ύX�O�d���P���i�����j
            writer.Write(temp.BfStockUnitPriceFl);
            //�d���`�[�敪
            writer.Write(temp.SupplierSlipCd);
            //�d�����i�敪
            writer.Write(temp.StockGoodsCd);
            //�d�������œ]�ŕ����R�[�h
            writer.Write(temp.SuppCTaxLayCd);
            //�d�����z�v�i�ō��݁j
            writer.Write(temp.StockTtlPricTaxInc);
            //�d�����z�v�i�Ŕ����j
            writer.Write(temp.StockTtlPricTaxExc);
            //�d�����z����Ŋz(�`�[)
            writer.Write(temp.StockTtlPriceConsTax);
            // --- ADD 2010/10/21 ---------->>>>>
            //�d�����z���v
            writer.Write(temp.StockTotalPrice);
            //�d�����z���v
            writer.Write(temp.StockSubttlPrice);
            // --- ADD 2010/10/21 ----------<<<<<
            //�������@
            writer.Write(temp.WayToOrder); //ADD BY ������ on 2012/08/30 for Redmine#31879
            writer.Write(temp.DebitNoteDiv); //ADD BY �� �� on 2012/10/09 for Redmine#31879

        }

        /// <summary>
        ///  SupplierCheckResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SupplierCheckResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SupplierCheckResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SupplierCheckResultWork GetSupplierCheckResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SupplierCheckResultWork temp = new SupplierCheckResultWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //�X�V�]�ƈ��R�[�h
            temp.UpdEmployeeCode = reader.ReadString();
            //�X�V�A�Z���u��ID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //�X�V�A�Z���u��ID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //�d���`�F�b�N�敪�i�����j
            temp.StockCheckDivCAddUp = reader.ReadInt32();
            //�d���`�F�b�N�敪�i�����j
            temp.StockCheckDivDaily = reader.ReadInt32();
            //�d����
            temp.StockDate = new DateTime(reader.ReadInt64());
            //���͓�
            temp.InputDay = new DateTime(reader.ReadInt64());
            //�d���`�[�ԍ�
            temp.SupplierSlipNo = reader.ReadInt32();
            //�����`�[�ԍ�
            temp.PartySaleSlipNum = reader.ReadString();
            //�d�����z�i�ō��݁j
            temp.StockPriceTaxInc = reader.ReadInt64();
            //�d�����z�i�Ŕ����j
            temp.StockPriceTaxExc = reader.ReadInt64();
            //�d�����z����Ŋz(����)
            temp.StockPriceConsTax = reader.ReadInt64();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //�d����
            temp.StockCount = reader.ReadDouble();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //���i����
            temp.GoodsName = reader.ReadString();
            //�d���P���i�Ŕ��C�����j
            temp.StockUnitPriceFl = reader.ReadDouble();
            //�艿�i�Ŕ��C�����j
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //����P���i�Ŕ��C�����j
            temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
            //������z�i�Ŕ����j
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //������t
            temp.SalesDate = new DateTime(reader.ReadInt64());
            //����`�[�ԍ�
            temp.SalesSlipNum = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ旪��
            temp.CustomerSnm = reader.ReadString();
            //�̔��]�ƈ�����
            temp.SalesEmployeeNm = reader.ReadString();
            //��t�]�ƈ�����
            temp.FrontEmployeeNm = reader.ReadString();
            //������͎Җ���
            temp.SalesInputName = reader.ReadString();
            //�t�n�d���}�[�N�P
            temp.UoeRemark1 = reader.ReadString();
            //�t�n�d���}�[�N�Q
            temp.UoeRemark2 = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //�d���`��
            temp.SupplierFormal = reader.ReadInt32();
            //�d�����גʔ�
            temp.StockSlipDtlNum = reader.ReadInt64();
            //�ύX�O�d���P���i�����j
            temp.BfStockUnitPriceFl = reader.ReadDouble();
            //�d���`�[�敪
            temp.SupplierSlipCd = reader.ReadInt32();
            //�d�����i�敪
            temp.StockGoodsCd = reader.ReadInt32();
            //�d�������œ]�ŕ����R�[�h
            temp.SuppCTaxLayCd = reader.ReadInt32();
            //�d�����z�v�i�ō��݁j
            temp.StockTtlPricTaxInc = reader.ReadInt64();
            //�d�����z�v�i�Ŕ����j
            temp.StockTtlPricTaxExc = reader.ReadInt64();
            //�d�����z����Ŋz(�`�[)
            temp.StockTtlPriceConsTax = reader.ReadInt64();
            // --- ADD 2010/10/21 ---------->>>>>
            //�d�����z���v
            temp.StockTotalPrice = reader.ReadInt64();
            //�d�����z���v
            temp.StockSubttlPrice = reader.ReadInt64();
            // --- ADD 2010/10/21 ----------<<<<<
            //�������@
            temp.WayToOrder = reader.ReadInt32(); //ADD BY ������ on 2012/08/30 for Redmine#31879
            temp.DebitNoteDiv = reader.ReadInt32(); //�ԓ`�敪 ADD BY �� �� on 2012/10/09 for Redmine#31879


            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>SupplierCheckResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SupplierCheckResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SupplierCheckResultWork temp = GetSupplierCheckResultWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (SupplierCheckResultWork[])lst.ToArray(typeof(SupplierCheckResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }



}