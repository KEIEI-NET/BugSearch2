using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockSlipNewEntryWork
	/// <summary>
	///                      �d���f�[�^�����Ǎ��p�����[�^���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �d���f�[�^�����Ǎ��p�����[�^���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/05/14  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class StockSlipNewEntryWork : IFileHeader
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

		/// <summary>�d���`��</summary>
		/// <remarks>0:����(�d��),1:���</remarks>
		private Int32 _supplierFormal;

		/// <summary>�d���`�[�ԍ�</summary>
		private Int32 _supplierSlipNo;

		/// <summary>�����`�[�ԍ�</summary>
		/// <remarks>�d����`�[�ԍ��Ɏg�p����</remarks>
		private string _partySaleSlipNum = "";

		/// <summary>�d�����_�R�[�h</summary>
		private string _stockSectionCd = "";

		/// <summary>�d���v�㋒�_�R�[�h</summary>
		/// <remarks>�����^ �d���v��Ώۂ̋��_�R�[�h(���_����̎x���v�㋒�_�̂���)</remarks>
		private string _stockAddUpSectionCd = "";

		/// <summary>�d���S���҃R�[�h</summary>
		private string _stockAgentCode = "";

		/// <summary>�d���S���Җ���</summary>
		private string _stockAgentName = "";

		/// <summary>���Ӑ�R�[�h</summary>
		private Int32 _customerCode;

		/// <summary>���Ӑ於��</summary>
		private string _customerName = "";

		/// <summary>���Ӑ於��2</summary>
		private string _customerName2 = "";

		/// <summary>�x����R�[�h</summary>
		/// <remarks>�x����(���Z��)�R�[�h�B�x�������͎x����P�ʂŏW�v�E�v�Z�B</remarks>
		private Int32 _payeeCode;

		/// <summary>�x���於��1</summary>
		/// <remarks>�x���ΏۂƂȂ链�Ӑ�̓��Ӑ�R�[�h</remarks>
		private string _payeeName1 = "";

		/// <summary>�x���於��2</summary>
		private string _payeename2 = "";

		/// <summary>�x�����t</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _paymentDate;

		/// <summary>���͓�</summary>
		private DateTime _inputDay;

		/// <summary>���ד�</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _arrivalGoodsDay;

		/// <summary>�d����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _stockDate;

		/// <summary>�d���v����t</summary>
		/// <remarks>�d���v���</remarks>
		private DateTime _stockAddUpADate;

		/// <summary>�d���`�[�敪</summary>
		/// <remarks>10:�d��,20:�ԕi</remarks>
		private Int32 _supplierSlipCd;

		/// <summary>���|�敪</summary>
		/// <remarks>0:���|�Ȃ�,1:���|</remarks>
		private Int32 _accPayDivCd;

		/// <summary>�ԓ`�敪</summary>
		/// <remarks>0:���`,1:�ԓ`,2:����</remarks>
		private Int32 _debitNoteDiv;

		/// <summary>�ԍ��A���d���`�[�ԍ�</summary>
		private Int32 _debitNLnkSuppSlipNo;

		/// <summary>�d�����z���v</summary>
		/// <remarks>�d�����z���v���d�����z�v�i�ō��݁j�{��ېőΏۊz���v</remarks>
		private Int64 _stockTotalPrice;

		/// <summary>�d�����z���v</summary>
		/// <remarks>�d�����z���v���d�����z�v�i�Ŕ����j�{��ېőΏۊz���v</remarks>
		private Int64 _stockSubttlPrice;

		/// <summary>�d�����z�v�i�ō��݁j</summary>
		/// <remarks>�O�Ŏ��F�Ŕ����{����ŁA���Ŏ��F���ŉ��i�i�ō��j�̏W�v</remarks>
		private Int64 _stockTtlPricTaxInc;

		/// <summary>�d�����z�v�i�Ŕ����j</summary>
		/// <remarks>�O�Ŏ��F�Ŕ����i�̏W�v�A���Ŏ��F���ŉ��i�i�ō��j�̏W�v�|�����</remarks>
		private Int64 _stockTtlPricTaxExc;

		/// <summary>�d����ېőΏۊz���v</summary>
		/// <remarks>��ېőΏۋ��z�̏W�v</remarks>
		private Int64 _ttlItdedStockTaxFree;

		/// <summary>�d�����z����Ŋz</summary>
		/// <remarks>���ł̏ꍇ:�ō���/105*5,�O�ł̏ꍇ:�Ŕ���*5/100</remarks>
		private Int64 _stockPriceConsTax;

		/// <summary>�d�������œ]�ŕ����R�[�h</summary>
		/// <remarks>�[�������敪�ݒ�}�X�^�Q�� 0:�`�[�P��1:���גP��2:�������ꊇ</remarks>
		private Int32 _suppCTaxLayCd;

		/// <summary>�d�������Őŗ�</summary>
		private Double _supplierConsTaxRate;

		/// <summary>�d���[�������敪</summary>
		/// <remarks>0:�������Ȃ�����Â�����i���j�d������</remarks>
		private Int32 _stockFractionProcCd;

		/// <summary>�d���摍�z�\�����@�敪</summary>
		/// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
		private Int32 _suppTtlAmntDspWayCd;

		/// <summary>�d���`�[���l1</summary>
		private string _supplierSlipNote1 = "";

		/// <summary>�d���`�[���l2</summary>
		private string _supplierSlipNote2 = "";

		/// <summary>���Ǝ҃R�[�h</summary>
		/// <remarks>1�`8999:�񋟕�,9000�`:���[�U�[�o�^</remarks>
		private Int32 _carrierEpCode;

		/// <summary>���ƎҖ���</summary>
		private string _carrierEpName = "";

		/// <summary>�q�ɃR�[�h</summary>
		private string _warehouseCode = "";

		/// <summary>�q�ɖ���</summary>
		private string _warehouseName = "";

		/// <summary>�d�����i�敪</summary>
		/// <remarks>0:���i,1:���i�O,2:����Œ���,3:�c������4:���|�p����Œ���,5:���|�p�c������</remarks>
		private Int32 _stockGoodsCd;

		/// <summary>����Œ����z</summary>
		private Int64 _taxAdjust;

		/// <summary>�c�������z</summary>
		private Int64 _balanceAdjust;

		/// <summary>����v��d���敪</summary>
		/// <remarks>0:�ʏ�d��,1:����v��d��,2:���㎞��������v��d��</remarks>
		private Int32 _trustAddUpSpCd;

		/// <summary>�ԕi���R�R�[�h</summary>
		private Int32 _retGoodsReasonDiv;

		/// <summary>�ԕi���R</summary>
		private string _retGoodsReason = "";

		/// <summary>�󒍔ԍ�</summary>
		/// <remarks>����E�d�������쐬���Ɋi�[�����󒍔ԍ�</remarks>
		private Int32 _acceptAnOrderNo;

		/// <summary>����s�ԍ�</summary>
		/// <remarks>����E�d�������쐬���Ɋi�[����锄��s�ԍ�</remarks>
		private Int32 _salesRowNo;


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

		/// public propaty name  :  SupplierFormal
		/// <summary>�d���`���v���p�e�B</summary>
		/// <value>0:����(�d��),1:���</value>
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

		/// public propaty name  :  SupplierSlipNo
		/// <summary>�d���`�[�ԍ��v���p�e�B</summary>
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

		/// public propaty name  :  StockSectionCd
		/// <summary>�d�����_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StockSectionCd
		{
			get{return _stockSectionCd;}
			set{_stockSectionCd = value;}
		}

		/// public propaty name  :  StockAddUpSectionCd
		/// <summary>�d���v�㋒�_�R�[�h�v���p�e�B</summary>
		/// <value>�����^ �d���v��Ώۂ̋��_�R�[�h(���_����̎x���v�㋒�_�̂���)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���v�㋒�_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StockAddUpSectionCd
		{
			get{return _stockAddUpSectionCd;}
			set{_stockAddUpSectionCd = value;}
		}

		/// public propaty name  :  StockAgentCode
		/// <summary>�d���S���҃R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���S���҃R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StockAgentCode
		{
			get{return _stockAgentCode;}
			set{_stockAgentCode = value;}
		}

		/// public propaty name  :  StockAgentName
		/// <summary>�d���S���Җ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���S���Җ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StockAgentName
		{
			get{return _stockAgentName;}
			set{_stockAgentName = value;}
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

		/// public propaty name  :  CustomerName
		/// <summary>���Ӑ於�̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ於�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CustomerName
		{
			get{return _customerName;}
			set{_customerName = value;}
		}

		/// public propaty name  :  CustomerName2
		/// <summary>���Ӑ於��2�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ於��2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CustomerName2
		{
			get{return _customerName2;}
			set{_customerName2 = value;}
		}

		/// public propaty name  :  PayeeCode
		/// <summary>�x����R�[�h�v���p�e�B</summary>
		/// <value>�x����(���Z��)�R�[�h�B�x�������͎x����P�ʂŏW�v�E�v�Z�B</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PayeeCode
		{
			get{return _payeeCode;}
			set{_payeeCode = value;}
		}

		/// public propaty name  :  PayeeName1
		/// <summary>�x���於��1�v���p�e�B</summary>
		/// <value>�x���ΏۂƂȂ链�Ӑ�̓��Ӑ�R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x���於��1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PayeeName1
		{
			get{return _payeeName1;}
			set{_payeeName1 = value;}
		}

		/// public propaty name  :  Payeename2
		/// <summary>�x���於��2�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x���於��2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Payeename2
		{
			get{return _payeename2;}
			set{_payeename2 = value;}
		}

		/// public propaty name  :  PaymentDate
		/// <summary>�x�����t�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x�����t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime PaymentDate
		{
			get{return _paymentDate;}
			set{_paymentDate = value;}
		}

		/// public propaty name  :  InputDay
		/// <summary>���͓��v���p�e�B</summary>
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

		/// public propaty name  :  ArrivalGoodsDay
		/// <summary>���ד��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ד��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime ArrivalGoodsDay
		{
			get{return _arrivalGoodsDay;}
			set{_arrivalGoodsDay = value;}
		}

		/// public propaty name  :  StockDate
		/// <summary>�d�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
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

		/// public propaty name  :  StockAddUpADate
		/// <summary>�d���v����t�v���p�e�B</summary>
		/// <value>�d���v���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���v����t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime StockAddUpADate
		{
			get{return _stockAddUpADate;}
			set{_stockAddUpADate = value;}
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

		/// public propaty name  :  AccPayDivCd
		/// <summary>���|�敪�v���p�e�B</summary>
		/// <value>0:���|�Ȃ�,1:���|</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���|�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AccPayDivCd
		{
			get{return _accPayDivCd;}
			set{_accPayDivCd = value;}
		}

		/// public propaty name  :  DebitNoteDiv
		/// <summary>�ԓ`�敪�v���p�e�B</summary>
		/// <value>0:���`,1:�ԓ`,2:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԓ`�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DebitNoteDiv
		{
			get{return _debitNoteDiv;}
			set{_debitNoteDiv = value;}
		}

		/// public propaty name  :  DebitNLnkSuppSlipNo
		/// <summary>�ԍ��A���d���`�[�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԍ��A���d���`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DebitNLnkSuppSlipNo
		{
			get{return _debitNLnkSuppSlipNo;}
			set{_debitNLnkSuppSlipNo = value;}
		}

		/// public propaty name  :  StockTotalPrice
		/// <summary>�d�����z���v�v���p�e�B</summary>
		/// <value>�d�����z���v���d�����z�v�i�ō��݁j�{��ېőΏۊz���v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����z���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StockTotalPrice
		{
			get{return _stockTotalPrice;}
			set{_stockTotalPrice = value;}
		}

		/// public propaty name  :  StockSubttlPrice
		/// <summary>�d�����z���v�v���p�e�B</summary>
		/// <value>�d�����z���v���d�����z�v�i�Ŕ����j�{��ېőΏۊz���v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����z���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StockSubttlPrice
		{
			get{return _stockSubttlPrice;}
			set{_stockSubttlPrice = value;}
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

		/// public propaty name  :  TtlItdedStockTaxFree
		/// <summary>�d����ېőΏۊz���v�v���p�e�B</summary>
		/// <value>��ېőΏۋ��z�̏W�v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d����ېőΏۊz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TtlItdedStockTaxFree
		{
			get{return _ttlItdedStockTaxFree;}
			set{_ttlItdedStockTaxFree = value;}
		}

		/// public propaty name  :  StockPriceConsTax
		/// <summary>�d�����z����Ŋz�v���p�e�B</summary>
		/// <value>���ł̏ꍇ:�ō���/105*5,�O�ł̏ꍇ:�Ŕ���*5/100</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����z����Ŋz�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StockPriceConsTax
		{
			get{return _stockPriceConsTax;}
			set{_stockPriceConsTax = value;}
		}

		/// public propaty name  :  SuppCTaxLayCd
		/// <summary>�d�������œ]�ŕ����R�[�h�v���p�e�B</summary>
		/// <value>�[�������敪�ݒ�}�X�^�Q�� 0:�`�[�P��1:���גP��2:�������ꊇ</value>
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

		/// public propaty name  :  SupplierConsTaxRate
		/// <summary>�d�������Őŗ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�������Őŗ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double SupplierConsTaxRate
		{
			get{return _supplierConsTaxRate;}
			set{_supplierConsTaxRate = value;}
		}

		/// public propaty name  :  StockFractionProcCd
		/// <summary>�d���[�������敪�v���p�e�B</summary>
		/// <value>0:�������Ȃ�����Â�����i���j�d������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���[�������敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockFractionProcCd
		{
			get{return _stockFractionProcCd;}
			set{_stockFractionProcCd = value;}
		}

		/// public propaty name  :  SuppTtlAmntDspWayCd
		/// <summary>�d���摍�z�\�����@�敪�v���p�e�B</summary>
		/// <value>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���摍�z�\�����@�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SuppTtlAmntDspWayCd
		{
			get{return _suppTtlAmntDspWayCd;}
			set{_suppTtlAmntDspWayCd = value;}
		}

		/// public propaty name  :  SupplierSlipNote1
		/// <summary>�d���`�[���l1�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���`�[���l1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SupplierSlipNote1
		{
			get{return _supplierSlipNote1;}
			set{_supplierSlipNote1 = value;}
		}

		/// public propaty name  :  SupplierSlipNote2
		/// <summary>�d���`�[���l2�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���`�[���l2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SupplierSlipNote2
		{
			get{return _supplierSlipNote2;}
			set{_supplierSlipNote2 = value;}
		}

		/// public propaty name  :  CarrierEpCode
		/// <summary>���Ǝ҃R�[�h�v���p�e�B</summary>
		/// <value>1�`8999:�񋟕�,9000�`:���[�U�[�o�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ǝ҃R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CarrierEpCode
		{
			get{return _carrierEpCode;}
			set{_carrierEpCode = value;}
		}

		/// public propaty name  :  CarrierEpName
		/// <summary>���ƎҖ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ƎҖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CarrierEpName
		{
			get{return _carrierEpName;}
			set{_carrierEpName = value;}
		}

		/// public propaty name  :  WarehouseCode
		/// <summary>�q�ɃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �q�ɃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string WarehouseCode
		{
			get{return _warehouseCode;}
			set{_warehouseCode = value;}
		}

		/// public propaty name  :  WarehouseName
		/// <summary>�q�ɖ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �q�ɖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string WarehouseName
		{
			get{return _warehouseName;}
			set{_warehouseName = value;}
		}

		/// public propaty name  :  StockGoodsCd
		/// <summary>�d�����i�敪�v���p�e�B</summary>
		/// <value>0:���i,1:���i�O,2:����Œ���,3:�c������4:���|�p����Œ���,5:���|�p�c������</value>
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

		/// public propaty name  :  TaxAdjust
		/// <summary>����Œ����z�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����Œ����z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TaxAdjust
		{
			get{return _taxAdjust;}
			set{_taxAdjust = value;}
		}

		/// public propaty name  :  BalanceAdjust
		/// <summary>�c�������z�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �c�������z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 BalanceAdjust
		{
			get{return _balanceAdjust;}
			set{_balanceAdjust = value;}
		}

		/// public propaty name  :  TrustAddUpSpCd
		/// <summary>����v��d���敪�v���p�e�B</summary>
		/// <value>0:�ʏ�d��,1:����v��d��,2:���㎞��������v��d��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����v��d���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TrustAddUpSpCd
		{
			get{return _trustAddUpSpCd;}
			set{_trustAddUpSpCd = value;}
		}

		/// public propaty name  :  RetGoodsReasonDiv
		/// <summary>�ԕi���R�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԕi���R�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 RetGoodsReasonDiv
		{
			get{return _retGoodsReasonDiv;}
			set{_retGoodsReasonDiv = value;}
		}

		/// public propaty name  :  RetGoodsReason
		/// <summary>�ԕi���R�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԕi���R�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string RetGoodsReason
		{
			get{return _retGoodsReason;}
			set{_retGoodsReason = value;}
		}

		/// public propaty name  :  AcceptAnOrderNo
		/// <summary>�󒍔ԍ��v���p�e�B</summary>
		/// <value>����E�d�������쐬���Ɋi�[�����󒍔ԍ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󒍔ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AcceptAnOrderNo
		{
			get{return _acceptAnOrderNo;}
			set{_acceptAnOrderNo = value;}
		}

		/// public propaty name  :  SalesRowNo
		/// <summary>����s�ԍ��v���p�e�B</summary>
		/// <value>����E�d�������쐬���Ɋi�[����锄��s�ԍ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����s�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesRowNo
		{
			get{return _salesRowNo;}
			set{_salesRowNo = value;}
		}


		/// <summary>
		/// �d���f�[�^�����Ǎ��p�����[�^���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>StockSlipNewEntryWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockSlipNewEntryWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockSlipNewEntryWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>StockSlipNewEntryWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   StockSlipNewEntryWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class StockSlipNewEntryWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockSlipNewEntryWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockSlipNewEntryWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockSlipNewEntryWork || graph is ArrayList || graph is StockSlipNewEntryWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(StockSlipNewEntryWork).FullName));

            if (graph != null && graph is StockSlipNewEntryWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockSlipNewEntryWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockSlipNewEntryWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockSlipNewEntryWork[])graph).Length;
            }
            else if (graph is StockSlipNewEntryWork)
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
            //�d���`��
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //�d���`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //�����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNum
            //�d�����_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionCd
            //�d���v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockAddUpSectionCd
            //�d���S���҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentCode
            //�d���S���Җ���
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentName
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ於��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
            //���Ӑ於��2
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName2
            //�x����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PayeeCode
            //�x���於��1
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName1
            //�x���於��2
            serInfo.MemberInfo.Add(typeof(string)); //Payeename2
            //�x�����t
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentDate
            //���͓�
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //���ד�
            serInfo.MemberInfo.Add(typeof(Int32)); //ArrivalGoodsDay
            //�d����
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDate
            //�d���v����t
            serInfo.MemberInfo.Add(typeof(Int32)); //StockAddUpADate
            //�d���`�[�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipCd
            //���|�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AccPayDivCd
            //�ԓ`�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
            //�ԍ��A���d���`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNLnkSuppSlipNo
            //�d�����z���v
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalPrice
            //�d�����z���v
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSubttlPrice
            //�d�����z�v�i�ō��݁j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPricTaxInc
            //�d�����z�v�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPricTaxExc
            //�d����ېőΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedStockTaxFree
            //�d�����z����Ŋz
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceConsTax
            //�d�������œ]�ŕ����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppCTaxLayCd
            //�d�������Őŗ�
            serInfo.MemberInfo.Add(typeof(Double)); //SupplierConsTaxRate
            //�d���[�������敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockFractionProcCd
            //�d���摍�z�\�����@�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppTtlAmntDspWayCd
            //�d���`�[���l1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSlipNote1
            //�d���`�[���l2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSlipNote2
            //���Ǝ҃R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CarrierEpCode
            //���ƎҖ���
            serInfo.MemberInfo.Add(typeof(string)); //CarrierEpName
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //�q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //�d�����i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockGoodsCd
            //����Œ����z
            serInfo.MemberInfo.Add(typeof(Int64)); //TaxAdjust
            //�c�������z
            serInfo.MemberInfo.Add(typeof(Int64)); //BalanceAdjust
            //����v��d���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TrustAddUpSpCd
            //�ԕi���R�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //RetGoodsReasonDiv
            //�ԕi���R
            serInfo.MemberInfo.Add(typeof(string)); //RetGoodsReason
            //�󒍔ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //AcceptAnOrderNo
            //����s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowNo


            serInfo.Serialize(writer, serInfo);
            if (graph is StockSlipNewEntryWork)
            {
                StockSlipNewEntryWork temp = (StockSlipNewEntryWork)graph;

                SetStockSlipNewEntryWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockSlipNewEntryWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockSlipNewEntryWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockSlipNewEntryWork temp in lst)
                {
                    SetStockSlipNewEntryWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockSlipNewEntryWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 55;

        /// <summary>
        ///  StockSlipNewEntryWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockSlipNewEntryWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetStockSlipNewEntryWork(System.IO.BinaryWriter writer, StockSlipNewEntryWork temp)
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
            //�d���`��
            writer.Write(temp.SupplierFormal);
            //�d���`�[�ԍ�
            writer.Write(temp.SupplierSlipNo);
            //�����`�[�ԍ�
            writer.Write(temp.PartySaleSlipNum);
            //�d�����_�R�[�h
            writer.Write(temp.StockSectionCd);
            //�d���v�㋒�_�R�[�h
            writer.Write(temp.StockAddUpSectionCd);
            //�d���S���҃R�[�h
            writer.Write(temp.StockAgentCode);
            //�d���S���Җ���
            writer.Write(temp.StockAgentName);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ於��
            writer.Write(temp.CustomerName);
            //���Ӑ於��2
            writer.Write(temp.CustomerName2);
            //�x����R�[�h
            writer.Write(temp.PayeeCode);
            //�x���於��1
            writer.Write(temp.PayeeName1);
            //�x���於��2
            writer.Write(temp.Payeename2);
            //�x�����t
            writer.Write((Int64)temp.PaymentDate.Ticks);
            //���͓�
            writer.Write((Int64)temp.InputDay.Ticks);
            //���ד�
            writer.Write((Int64)temp.ArrivalGoodsDay.Ticks);
            //�d����
            writer.Write((Int64)temp.StockDate.Ticks);
            //�d���v����t
            writer.Write((Int64)temp.StockAddUpADate.Ticks);
            //�d���`�[�敪
            writer.Write(temp.SupplierSlipCd);
            //���|�敪
            writer.Write(temp.AccPayDivCd);
            //�ԓ`�敪
            writer.Write(temp.DebitNoteDiv);
            //�ԍ��A���d���`�[�ԍ�
            writer.Write(temp.DebitNLnkSuppSlipNo);
            //�d�����z���v
            writer.Write(temp.StockTotalPrice);
            //�d�����z���v
            writer.Write(temp.StockSubttlPrice);
            //�d�����z�v�i�ō��݁j
            writer.Write(temp.StockTtlPricTaxInc);
            //�d�����z�v�i�Ŕ����j
            writer.Write(temp.StockTtlPricTaxExc);
            //�d����ېőΏۊz���v
            writer.Write(temp.TtlItdedStockTaxFree);
            //�d�����z����Ŋz
            writer.Write(temp.StockPriceConsTax);
            //�d�������œ]�ŕ����R�[�h
            writer.Write(temp.SuppCTaxLayCd);
            //�d�������Őŗ�
            writer.Write(temp.SupplierConsTaxRate);
            //�d���[�������敪
            writer.Write(temp.StockFractionProcCd);
            //�d���摍�z�\�����@�敪
            writer.Write(temp.SuppTtlAmntDspWayCd);
            //�d���`�[���l1
            writer.Write(temp.SupplierSlipNote1);
            //�d���`�[���l2
            writer.Write(temp.SupplierSlipNote2);
            //���Ǝ҃R�[�h
            writer.Write(temp.CarrierEpCode);
            //���ƎҖ���
            writer.Write(temp.CarrierEpName);
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //�q�ɖ���
            writer.Write(temp.WarehouseName);
            //�d�����i�敪
            writer.Write(temp.StockGoodsCd);
            //����Œ����z
            writer.Write(temp.TaxAdjust);
            //�c�������z
            writer.Write(temp.BalanceAdjust);
            //����v��d���敪
            writer.Write(temp.TrustAddUpSpCd);
            //�ԕi���R�R�[�h
            writer.Write(temp.RetGoodsReasonDiv);
            //�ԕi���R
            writer.Write(temp.RetGoodsReason);
            //�󒍔ԍ�
            writer.Write(temp.AcceptAnOrderNo);
            //����s�ԍ�
            writer.Write(temp.SalesRowNo);

        }

        /// <summary>
        ///  StockSlipNewEntryWork�C���X�^���X�擾
        /// </summary>
        /// <returns>StockSlipNewEntryWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockSlipNewEntryWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private StockSlipNewEntryWork GetStockSlipNewEntryWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            StockSlipNewEntryWork temp = new StockSlipNewEntryWork();

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
            //�d���`��
            temp.SupplierFormal = reader.ReadInt32();
            //�d���`�[�ԍ�
            temp.SupplierSlipNo = reader.ReadInt32();
            //�����`�[�ԍ�
            temp.PartySaleSlipNum = reader.ReadString();
            //�d�����_�R�[�h
            temp.StockSectionCd = reader.ReadString();
            //�d���v�㋒�_�R�[�h
            temp.StockAddUpSectionCd = reader.ReadString();
            //�d���S���҃R�[�h
            temp.StockAgentCode = reader.ReadString();
            //�d���S���Җ���
            temp.StockAgentName = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ於��
            temp.CustomerName = reader.ReadString();
            //���Ӑ於��2
            temp.CustomerName2 = reader.ReadString();
            //�x����R�[�h
            temp.PayeeCode = reader.ReadInt32();
            //�x���於��1
            temp.PayeeName1 = reader.ReadString();
            //�x���於��2
            temp.Payeename2 = reader.ReadString();
            //�x�����t
            temp.PaymentDate = new DateTime(reader.ReadInt64());
            //���͓�
            temp.InputDay = new DateTime(reader.ReadInt64());
            //���ד�
            temp.ArrivalGoodsDay = new DateTime(reader.ReadInt64());
            //�d����
            temp.StockDate = new DateTime(reader.ReadInt64());
            //�d���v����t
            temp.StockAddUpADate = new DateTime(reader.ReadInt64());
            //�d���`�[�敪
            temp.SupplierSlipCd = reader.ReadInt32();
            //���|�敪
            temp.AccPayDivCd = reader.ReadInt32();
            //�ԓ`�敪
            temp.DebitNoteDiv = reader.ReadInt32();
            //�ԍ��A���d���`�[�ԍ�
            temp.DebitNLnkSuppSlipNo = reader.ReadInt32();
            //�d�����z���v
            temp.StockTotalPrice = reader.ReadInt64();
            //�d�����z���v
            temp.StockSubttlPrice = reader.ReadInt64();
            //�d�����z�v�i�ō��݁j
            temp.StockTtlPricTaxInc = reader.ReadInt64();
            //�d�����z�v�i�Ŕ����j
            temp.StockTtlPricTaxExc = reader.ReadInt64();
            //�d����ېőΏۊz���v
            temp.TtlItdedStockTaxFree = reader.ReadInt64();
            //�d�����z����Ŋz
            temp.StockPriceConsTax = reader.ReadInt64();
            //�d�������œ]�ŕ����R�[�h
            temp.SuppCTaxLayCd = reader.ReadInt32();
            //�d�������Őŗ�
            temp.SupplierConsTaxRate = reader.ReadDouble();
            //�d���[�������敪
            temp.StockFractionProcCd = reader.ReadInt32();
            //�d���摍�z�\�����@�敪
            temp.SuppTtlAmntDspWayCd = reader.ReadInt32();
            //�d���`�[���l1
            temp.SupplierSlipNote1 = reader.ReadString();
            //�d���`�[���l2
            temp.SupplierSlipNote2 = reader.ReadString();
            //���Ǝ҃R�[�h
            temp.CarrierEpCode = reader.ReadInt32();
            //���ƎҖ���
            temp.CarrierEpName = reader.ReadString();
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //�q�ɖ���
            temp.WarehouseName = reader.ReadString();
            //�d�����i�敪
            temp.StockGoodsCd = reader.ReadInt32();
            //����Œ����z
            temp.TaxAdjust = reader.ReadInt64();
            //�c�������z
            temp.BalanceAdjust = reader.ReadInt64();
            //����v��d���敪
            temp.TrustAddUpSpCd = reader.ReadInt32();
            //�ԕi���R�R�[�h
            temp.RetGoodsReasonDiv = reader.ReadInt32();
            //�ԕi���R
            temp.RetGoodsReason = reader.ReadString();
            //�󒍔ԍ�
            temp.AcceptAnOrderNo = reader.ReadInt32();
            //����s�ԍ�
            temp.SalesRowNo = reader.ReadInt32();


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
        /// <returns>StockSlipNewEntryWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockSlipNewEntryWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockSlipNewEntryWork temp = GetStockSlipNewEntryWork(reader, serInfo);
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
                    retValue = (StockSlipNewEntryWork[])lst.ToArray(typeof(StockSlipNewEntryWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
