using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    #region �d�����׃f�[�^�N���X
    /// public class name:   StockDetail
	/// <summary>
	///                      �d�����׃f�[�^
	/// </summary>
	/// <remarks>
	/// <br>note             :   �d�����׃f�[�^�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/09/11  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class StockDetail
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

		/// <summary>�󒍔ԍ�</summary>
		private Int32 _acceptAnOrderNo;

		/// <summary>�d���`��</summary>
		/// <remarks>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</remarks>
		private Int32 _supplierFormal;

		/// <summary>�d���`�[�ԍ�</summary>
		/// <remarks>�d���`�[�ԍ�,���ד`�[�ԍ�,�������ԍ�(����)�����˂�B�i�������̓[���j</remarks>
		private Int32 _supplierSlipNo;

		/// <summary>�d���s�ԍ�</summary>
		private Int32 _stockRowNo;

		/// <summary>���_�R�[�h</summary>
		private string _sectionCode = "";

		/// <summary>����R�[�h</summary>
		private Int32 _subSectionCode;

		/// <summary>���ʒʔ�</summary>
		private Int64 _commonSeqNo;

		/// <summary>�d�����גʔ�</summary>
		private Int64 _stockSlipDtlNum;

		/// <summary>�d���`���i���j</summary>
		/// <remarks>0:�d��,1:����,2:����</remarks>
		private Int32 _supplierFormalSrc;

		/// <summary>�d�����גʔԁi���j</summary>
		/// <remarks>�v�㎞�̌��f�[�^���גʔԂ��Z�b�g</remarks>
		private Int64 _stockSlipDtlNumSrc;

		/// <summary>�󒍃X�e�[�^�X�i�����j</summary>
		/// <remarks>30:����,40:�o��</remarks>
		private Int32 _acptAnOdrStatusSync;

		/// <summary>���㖾�גʔԁi�����j</summary>
		/// <remarks>�����v�㎞�̎d�����גʔԂ��Z�b�g</remarks>
		private Int64 _salesSlipDtlNumSync;

		/// <summary>�d���`�[�敪�i���ׁj</summary>
		/// <remarks>0:�d��,1:�ԕi,2:�l��</remarks>
		private Int32 _stockSlipCdDtl;

		/// <summary>�d�����͎҃R�[�h</summary>
		private string _stockInputCode = "";

		/// <summary>�d�����͎Җ���</summary>
		private string _stockInputName = "";

		/// <summary>�d���S���҃R�[�h</summary>
		private string _stockAgentCode = "";

		/// <summary>�d���S���Җ���</summary>
		private string _stockAgentName = "";

		/// <summary>���i����</summary>
		private Int32 _goodsKindCode;

		/// <summary>���i���[�J�[�R�[�h</summary>
		/// <remarks>�߯���ޖ���հ�ް�o�^�͈͂��قȂ�</remarks>
		private Int32 _goodsMakerCd;

		/// <summary>���[�J�[����</summary>
		private string _makerName = "";

		/// <summary>���[�J�[�J�i����</summary>
		private string _makerKanaName = "";

		/// <summary>���[�J�[�J�i���́i�ꎮ�j</summary>
		private string _cmpltMakerKanaName = "";

		/// <summary>���i�ԍ�</summary>
		private string _goodsNo = "";

		/// <summary>���i����</summary>
		private string _goodsName = "";

		/// <summary>���i���̃J�i</summary>
		private string _goodsNameKana = "";

		/// <summary>���i�啪�ރR�[�h</summary>
		/// <remarks>���啪�ށi���[�U�[�K�C�h�j</remarks>
		private Int32 _goodsLGroup;

		/// <summary>���i�啪�ޖ���</summary>
		private string _goodsLGroupName = "";

		/// <summary>���i�����ރR�[�h</summary>
		/// <remarks>�������ރR�[�h</remarks>
		private Int32 _goodsMGroup;

		/// <summary>���i�����ޖ���</summary>
		private string _goodsMGroupName = "";

		/// <summary>BL�O���[�v�R�[�h</summary>
		/// <remarks>���O���[�v�R�[�h</remarks>
		private Int32 _bLGroupCode;

		/// <summary>BL�O���[�v�R�[�h����</summary>
		private string _bLGroupName = "";

		/// <summary>BL���i�R�[�h</summary>
		private Int32 _bLGoodsCode;

		/// <summary>BL���i�R�[�h���́i�S�p�j</summary>
		private string _bLGoodsFullName = "";

		/// <summary>���Е��ރR�[�h</summary>
		private Int32 _enterpriseGanreCode;

		/// <summary>���Е��ޖ���</summary>
		private string _enterpriseGanreName = "";

		/// <summary>�q�ɃR�[�h</summary>
		private string _warehouseCode = "";

		/// <summary>�q�ɖ���</summary>
		private string _warehouseName = "";

		/// <summary>�q�ɒI��</summary>
		private string _warehouseShelfNo = "";

		/// <summary>�d���݌Ɏ�񂹋敪</summary>
		/// <remarks>0:���,1:�݌�</remarks>
		private Int32 _stockOrderDivCd;

		/// <summary>�I�[�v�����i�敪</summary>
		/// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
		private Int32 _openPriceDiv;

		/// <summary>���i�|�������N</summary>
		/// <remarks>���i�̊|���p�����N</remarks>
		private string _goodsRateRank = "";

		/// <summary>���Ӑ�|���O���[�v�R�[�h</summary>
		private Int32 _custRateGrpCode;

		/// <summary>�d����|���O���[�v�R�[�h</summary>
		private Int32 _suppRateGrpCode;

		/// <summary>�艿�i�Ŕ��C�����j</summary>
		/// <remarks>�Ŕ���</remarks>
		private Double _listPriceTaxExcFl;

		/// <summary>�艿�i�ō��C�����j</summary>
		/// <remarks>�ō���</remarks>
		private Double _listPriceTaxIncFl;

		/// <summary>�d����</summary>
		private Double _stockRate;

		/// <summary>�|���ݒ苒�_�i�d���P���j</summary>
		/// <remarks>0:�S�Аݒ�, ���̑�:���_�R�[�h</remarks>
		private string _rateSectStckUnPrc = "";

		/// <summary>�|���ݒ�敪�i�d���P���j</summary>
		/// <remarks>A7,A8,�c</remarks>
		private string _rateDivStckUnPrc = "";

		/// <summary>�P���Z�o�敪�i�d���P���j</summary>
		/// <remarks>1:�|��,2:�����t�o��,3:�e����</remarks>
		private Int32 _unPrcCalcCdStckUnPrc;

		/// <summary>���i�敪�i�d���P���j</summary>
		/// <remarks>0:�艿,1:�o�^�̔��X���i,�c</remarks>
		private Int32 _priceCdStckUnPrc;

		/// <summary>��P���i�d���P���j</summary>
		private Double _stdUnPrcStckUnPrc;

		/// <summary>�[�������P�ʁi�d���P���j</summary>
		private Double _fracProcUnitStcUnPrc;

		/// <summary>�[�������i�d���P���j</summary>
		/// <remarks>1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ</remarks>
		private Int32 _fracProcStckUnPrc;

		/// <summary>�d���P���i�Ŕ��C�����j</summary>
		/// <remarks>�Ŕ���</remarks>
		private Double _stockUnitPriceFl;

		/// <summary>�d���P���i�ō��C�����j</summary>
		/// <remarks>�ō���</remarks>
		private Double _stockUnitTaxPriceFl;

		/// <summary>�d���P���ύX�敪</summary>
		/// <remarks>0:�ύX�Ȃ�,1:�ύX����@�i�d���P������́j</remarks>
		private Int32 _stockUnitChngDiv;

		/// <summary>�ύX�O�d���P���i�����j</summary>
		/// <remarks>�Ŕ����A�|���Z�o����</remarks>
		private Double _bfStockUnitPriceFl;

		/// <summary>�ύX�O�艿</summary>
		/// <remarks>�Ŕ����A�|���Z�o����</remarks>
		private Double _bfListPrice;

		/// <summary>BL���i�R�[�h�i�|���j</summary>
		/// <remarks>�|���Z�o���Ɏg�p����BL�R�[�h�i���i�������ʁj</remarks>
		private Int32 _rateBLGoodsCode;

		/// <summary>BL���i�R�[�h���́i�|���j</summary>
		/// <remarks>�|���Z�o���Ɏg�p����BL�R�[�h���́i���i�������ʁj</remarks>
		private string _rateBLGoodsName = "";

		/// <summary>���i�|���O���[�v�R�[�h�i�|���j</summary>
		/// <remarks>�|���Z�o���Ɏg�p�������i�|���R�[�h�i���i�������ʁj</remarks>
		private Int32 _rateGoodsRateGrpCd;

		/// <summary>���i�|���O���[�v���́i�|���j</summary>
		/// <remarks>�|���Z�o���Ɏg�p�������i�|�����́i���i�������ʁj</remarks>
		private string _rateGoodsRateGrpNm = "";

		/// <summary>BL�O���[�v�R�[�h�i�|���j</summary>
		/// <remarks>�|���Z�o���Ɏg�p����BL�O���[�v�R�[�h�i���i�������ʁj</remarks>
		private Int32 _rateBLGroupCode;

		/// <summary>BL�O���[�v���́i�|���j</summary>
		/// <remarks>�|���Z�o���Ɏg�p����BL�O���[�v���́i���i�������ʁj</remarks>
		private string _rateBLGroupName = "";

		/// <summary>�d����</summary>
		private Double _stockCount;

		/// <summary>��������</summary>
		/// <remarks>����,���ׂŎg�p</remarks>
		private Double _orderCnt;

		/// <summary>����������</summary>
		/// <remarks>���݂̔������́u�������ʁ{�����������v�ŎZ�o</remarks>
		private Double _orderAdjustCnt;

		/// <summary>�����c��</summary>
		/// <remarks>�������ʁ{�����������|�d����</remarks>
		private Double _orderRemainCnt;

		/// <summary>�c���X�V��</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _remainCntUpdDate;

		/// <summary>�d�����z�i�Ŕ����j</summary>
		private Int64 _stockPriceTaxExc;

		/// <summary>�d�����z�i�ō��݁j</summary>
		private Int64 _stockPriceTaxInc;

		/// <summary>�d�����i�敪</summary>
		/// <remarks>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,6:���v����,10:���p����Œ���(����)</remarks>
		private Int32 _stockGoodsCd;

		/// <summary>�d�����z����Ŋz</summary>
		/// <remarks>�d�����z�i�ō��݁j- �d�����z�i�Ŕ����j������Œ����z�����˂�</remarks>
		private Int64 _stockPriceConsTax;

		/// <summary>�ېŋ敪</summary>
		/// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
		private Int32 _taxationCode;

		/// <summary>�d���`�[���ה��l1</summary>
		private string _stockDtiSlipNote1 = "";

		/// <summary>�̔���R�[�h</summary>
		private Int32 _salesCustomerCode;

		/// <summary>�̔��旪��</summary>
		private string _salesCustomerSnm = "";

		/// <summary>�`�[�����P</summary>
		private string _slipMemo1 = "";

		/// <summary>�`�[�����Q</summary>
		private string _slipMemo2 = "";

		/// <summary>�`�[�����R</summary>
		private string _slipMemo3 = "";

		/// <summary>�Г������P</summary>
		private string _insideMemo1 = "";

		/// <summary>�Г������Q</summary>
		private string _insideMemo2 = "";

		/// <summary>�Г������R</summary>
		private string _insideMemo3 = "";

		/// <summary>�d����R�[�h</summary>
		/// <remarks>�����p</remarks>
		private Int32 _supplierCd;

		/// <summary>�d���旪��</summary>
		/// <remarks>�����p</remarks>
		private string _supplierSnm = "";

		/// <summary>�[�i��R�[�h</summary>
		/// <remarks>�����p</remarks>
		private Int32 _addresseeCode;

		/// <summary>�[�i�於��</summary>
		/// <remarks>�����p</remarks>
		private string _addresseeName = "";

		/// <summary>�����敪</summary>
		/// <remarks>0:�����Ȃ�,1:��������@�i�������̒�����󎚐���j</remarks>
		private Int32 _directSendingCd;

		/// <summary>�����ԍ�</summary>
		/// <remarks>�����p</remarks>
		private string _orderNumber = "";

		/// <summary>�������@</summary>
		/// <remarks>0:����������,1:FAX���M,2:�I�����C������,4:�����ώ���o�^</remarks>
		private Int32 _wayToOrder;

		/// <summary>�[�i�����\���</summary>
		/// <remarks>�����p�@�i�����񓚔[���j</remarks>
		private DateTime _deliGdsCmpltDueDate;

		/// <summary>��]�[��</summary>
		/// <remarks>�����p</remarks>
		private DateTime _expectDeliveryDate;

		/// <summary>�����f�[�^�쐬�敪</summary>
		/// <remarks>1:�󔭒��������,2:��������,3:�݌ɕ�[����,4:�����_����@�i�������j</remarks>
		private Int32 _orderDataCreateDiv;

		/// <summary>�����f�[�^�쐬��</summary>
		/// <remarks>�����p</remarks>
		private DateTime _orderDataCreateDate;

		/// <summary>���������s�ϋ敪</summary>
		/// <remarks>0:�����s,1:���s��</remarks>
		private Int32 _orderFormIssuedDiv;

		/// <summary>���׊֘A�t��GUID</summary>
		private Guid _dtlRelationGuid;

		/// <summary>���i�񋟓��t</summary>
		/// <remarks>YYYYMMDD�@���i�}�X�^�ɓo�^����񋟓��t�AUI���Őݒ�@��DateTime�^</remarks>
		private DateTime _goodsOfferDate;

		/// <summary>���i�J�n���t</summary>
		/// <remarks>YYYYMMDD�@���i�}�X�^�ɓo�^���鉿�i�J�n���AUI���Őݒ�@��DateTime�^</remarks>
		private DateTime _priceStartDate;

		/// <summary>���i�񋟓��t</summary>
		/// <remarks>YYYYMMDD�@���i�}�X�^�ɓo�^����񋟓��t�AUI���Őݒ�@��DateTime�^</remarks>
		private DateTime _priceOfferDate;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>�X�V�]�ƈ�����</summary>
		private string _updEmployeeName = "";

		/// <summary>BL���i�R�[�h����</summary>
		private string _bLGoodsName = "";


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

		/// public propaty name  :  CreateDateTimeJpFormal
		/// <summary>�쐬���� �a��v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeJpInFormal
		/// <summary>�쐬���� �a��(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeAdFormal
		/// <summary>�쐬���� ����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeAdInFormal
		/// <summary>�쐬���� ����(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime);}
			set{}
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

		/// public propaty name  :  UpdateDateTimeJpFormal
		/// <summary>�X�V���� �a��v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeJpInFormal
		/// <summary>�X�V���� �a��(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeAdFormal
		/// <summary>�X�V���� ����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeAdInFormal
		/// <summary>�X�V���� ����(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime);}
			set{}
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

		/// public propaty name  :  AcceptAnOrderNo
		/// <summary>�󒍔ԍ��v���p�e�B</summary>
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

		/// public propaty name  :  SupplierFormal
		/// <summary>�d���`���v���p�e�B</summary>
		/// <value>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</value>
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
		/// <value>�d���`�[�ԍ�,���ד`�[�ԍ�,�������ԍ�(����)�����˂�B�i�������̓[���j</value>
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

		/// public propaty name  :  StockRowNo
		/// <summary>�d���s�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���s�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockRowNo
		{
			get{return _stockRowNo;}
			set{_stockRowNo = value;}
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

		/// public propaty name  :  SubSectionCode
		/// <summary>����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SubSectionCode
		{
			get{return _subSectionCode;}
			set{_subSectionCode = value;}
		}

		/// public propaty name  :  CommonSeqNo
		/// <summary>���ʒʔԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ʒʔԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 CommonSeqNo
		{
			get{return _commonSeqNo;}
			set{_commonSeqNo = value;}
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

		/// public propaty name  :  SupplierFormalSrc
		/// <summary>�d���`���i���j�v���p�e�B</summary>
		/// <value>0:�d��,1:����,2:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���`���i���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierFormalSrc
		{
			get{return _supplierFormalSrc;}
			set{_supplierFormalSrc = value;}
		}

		/// public propaty name  :  StockSlipDtlNumSrc
		/// <summary>�d�����גʔԁi���j�v���p�e�B</summary>
		/// <value>�v�㎞�̌��f�[�^���גʔԂ��Z�b�g</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����גʔԁi���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StockSlipDtlNumSrc
		{
			get{return _stockSlipDtlNumSrc;}
			set{_stockSlipDtlNumSrc = value;}
		}

		/// public propaty name  :  AcptAnOdrStatusSync
		/// <summary>�󒍃X�e�[�^�X�i�����j�v���p�e�B</summary>
		/// <value>30:����,40:�o��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󒍃X�e�[�^�X�i�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AcptAnOdrStatusSync
		{
			get{return _acptAnOdrStatusSync;}
			set{_acptAnOdrStatusSync = value;}
		}

		/// public propaty name  :  SalesSlipDtlNumSync
		/// <summary>���㖾�גʔԁi�����j�v���p�e�B</summary>
		/// <value>�����v�㎞�̎d�����גʔԂ��Z�b�g</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���㖾�גʔԁi�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesSlipDtlNumSync
		{
			get{return _salesSlipDtlNumSync;}
			set{_salesSlipDtlNumSync = value;}
		}

		/// public propaty name  :  StockSlipCdDtl
		/// <summary>�d���`�[�敪�i���ׁj�v���p�e�B</summary>
		/// <value>0:�d��,1:�ԕi,2:�l��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���`�[�敪�i���ׁj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockSlipCdDtl
		{
			get{return _stockSlipCdDtl;}
			set{_stockSlipCdDtl = value;}
		}

		/// public propaty name  :  StockInputCode
		/// <summary>�d�����͎҃R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����͎҃R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StockInputCode
		{
			get{return _stockInputCode;}
			set{_stockInputCode = value;}
		}

		/// public propaty name  :  StockInputName
		/// <summary>�d�����͎Җ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����͎Җ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StockInputName
		{
			get{return _stockInputName;}
			set{_stockInputName = value;}
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

		/// public propaty name  :  GoodsKindCode
		/// <summary>���i�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsKindCode
		{
			get{return _goodsKindCode;}
			set{_goodsKindCode = value;}
		}

		/// public propaty name  :  GoodsMakerCd
		/// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
		/// <value>�߯���ޖ���հ�ް�o�^�͈͂��قȂ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsMakerCd
		{
			get{return _goodsMakerCd;}
			set{_goodsMakerCd = value;}
		}

		/// public propaty name  :  MakerName
		/// <summary>���[�J�[���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string MakerName
		{
			get{return _makerName;}
			set{_makerName = value;}
		}

		/// public propaty name  :  MakerKanaName
		/// <summary>���[�J�[�J�i���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[�J�i���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string MakerKanaName
		{
			get{return _makerKanaName;}
			set{_makerKanaName = value;}
		}

		/// public propaty name  :  CmpltMakerKanaName
		/// <summary>���[�J�[�J�i���́i�ꎮ�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[�J�i���́i�ꎮ�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CmpltMakerKanaName
		{
			get{return _cmpltMakerKanaName;}
			set{_cmpltMakerKanaName = value;}
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

		/// public propaty name  :  GoodsNameKana
		/// <summary>���i���̃J�i�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���̃J�i�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsNameKana
		{
			get{return _goodsNameKana;}
			set{_goodsNameKana = value;}
		}

		/// public propaty name  :  GoodsLGroup
		/// <summary>���i�啪�ރR�[�h�v���p�e�B</summary>
		/// <value>���啪�ށi���[�U�[�K�C�h�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�啪�ރR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsLGroup
		{
			get{return _goodsLGroup;}
			set{_goodsLGroup = value;}
		}

		/// public propaty name  :  GoodsLGroupName
		/// <summary>���i�啪�ޖ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�啪�ޖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsLGroupName
		{
			get{return _goodsLGroupName;}
			set{_goodsLGroupName = value;}
		}

		/// public propaty name  :  GoodsMGroup
		/// <summary>���i�����ރR�[�h�v���p�e�B</summary>
		/// <value>�������ރR�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�����ރR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsMGroup
		{
			get{return _goodsMGroup;}
			set{_goodsMGroup = value;}
		}

		/// public propaty name  :  GoodsMGroupName
		/// <summary>���i�����ޖ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�����ޖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsMGroupName
		{
			get{return _goodsMGroupName;}
			set{_goodsMGroupName = value;}
		}

		/// public propaty name  :  BLGroupCode
		/// <summary>BL�O���[�v�R�[�h�v���p�e�B</summary>
		/// <value>���O���[�v�R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL�O���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BLGroupCode
		{
			get{return _bLGroupCode;}
			set{_bLGroupCode = value;}
		}

		/// public propaty name  :  BLGroupName
		/// <summary>BL�O���[�v�R�[�h���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL�O���[�v�R�[�h���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BLGroupName
		{
			get{return _bLGroupName;}
			set{_bLGroupName = value;}
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

		/// public propaty name  :  BLGoodsFullName
		/// <summary>BL���i�R�[�h���́i�S�p�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL���i�R�[�h���́i�S�p�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BLGoodsFullName
		{
			get{return _bLGoodsFullName;}
			set{_bLGoodsFullName = value;}
		}

		/// public propaty name  :  EnterpriseGanreCode
		/// <summary>���Е��ރR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Е��ރR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EnterpriseGanreCode
		{
			get{return _enterpriseGanreCode;}
			set{_enterpriseGanreCode = value;}
		}

		/// public propaty name  :  EnterpriseGanreName
		/// <summary>���Е��ޖ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Е��ޖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EnterpriseGanreName
		{
			get{return _enterpriseGanreName;}
			set{_enterpriseGanreName = value;}
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

		/// public propaty name  :  WarehouseShelfNo
		/// <summary>�q�ɒI�ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �q�ɒI�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string WarehouseShelfNo
		{
			get{return _warehouseShelfNo;}
			set{_warehouseShelfNo = value;}
		}

		/// public propaty name  :  StockOrderDivCd
		/// <summary>�d���݌Ɏ�񂹋敪�v���p�e�B</summary>
		/// <value>0:���,1:�݌�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���݌Ɏ�񂹋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockOrderDivCd
		{
			get{return _stockOrderDivCd;}
			set{_stockOrderDivCd = value;}
		}

		/// public propaty name  :  OpenPriceDiv
		/// <summary>�I�[�v�����i�敪�v���p�e�B</summary>
		/// <value>0:�ʏ�^1:�I�[�v�����i</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�[�v�����i�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OpenPriceDiv
		{
			get{return _openPriceDiv;}
			set{_openPriceDiv = value;}
		}

		/// public propaty name  :  GoodsRateRank
		/// <summary>���i�|�������N�v���p�e�B</summary>
		/// <value>���i�̊|���p�����N</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�|�������N�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsRateRank
		{
			get{return _goodsRateRank;}
			set{_goodsRateRank = value;}
		}

		/// public propaty name  :  CustRateGrpCode
		/// <summary>���Ӑ�|���O���[�v�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�|���O���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustRateGrpCode
		{
			get{return _custRateGrpCode;}
			set{_custRateGrpCode = value;}
		}

		/// public propaty name  :  SuppRateGrpCode
		/// <summary>�d����|���O���[�v�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d����|���O���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SuppRateGrpCode
		{
			get{return _suppRateGrpCode;}
			set{_suppRateGrpCode = value;}
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

		/// public propaty name  :  ListPriceTaxIncFl
		/// <summary>�艿�i�ō��C�����j�v���p�e�B</summary>
		/// <value>�ō���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �艿�i�ō��C�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double ListPriceTaxIncFl
		{
			get{return _listPriceTaxIncFl;}
			set{_listPriceTaxIncFl = value;}
		}

		/// public propaty name  :  StockRate
		/// <summary>�d�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double StockRate
		{
			get{return _stockRate;}
			set{_stockRate = value;}
		}

		/// public propaty name  :  RateSectStckUnPrc
		/// <summary>�|���ݒ苒�_�i�d���P���j�v���p�e�B</summary>
		/// <value>0:�S�Аݒ�, ���̑�:���_�R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �|���ݒ苒�_�i�d���P���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string RateSectStckUnPrc
		{
			get{return _rateSectStckUnPrc;}
			set{_rateSectStckUnPrc = value;}
		}

		/// public propaty name  :  RateDivStckUnPrc
		/// <summary>�|���ݒ�敪�i�d���P���j�v���p�e�B</summary>
		/// <value>A7,A8,�c</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �|���ݒ�敪�i�d���P���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string RateDivStckUnPrc
		{
			get{return _rateDivStckUnPrc;}
			set{_rateDivStckUnPrc = value;}
		}

		/// public propaty name  :  UnPrcCalcCdStckUnPrc
		/// <summary>�P���Z�o�敪�i�d���P���j�v���p�e�B</summary>
		/// <value>1:�|��,2:�����t�o��,3:�e����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �P���Z�o�敪�i�d���P���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UnPrcCalcCdStckUnPrc
		{
			get{return _unPrcCalcCdStckUnPrc;}
			set{_unPrcCalcCdStckUnPrc = value;}
		}

		/// public propaty name  :  PriceCdStckUnPrc
		/// <summary>���i�敪�i�d���P���j�v���p�e�B</summary>
		/// <value>0:�艿,1:�o�^�̔��X���i,�c</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�敪�i�d���P���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PriceCdStckUnPrc
		{
			get{return _priceCdStckUnPrc;}
			set{_priceCdStckUnPrc = value;}
		}

		/// public propaty name  :  StdUnPrcStckUnPrc
		/// <summary>��P���i�d���P���j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��P���i�d���P���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double StdUnPrcStckUnPrc
		{
			get{return _stdUnPrcStckUnPrc;}
			set{_stdUnPrcStckUnPrc = value;}
		}

		/// public propaty name  :  FracProcUnitStcUnPrc
		/// <summary>�[�������P�ʁi�d���P���j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�������P�ʁi�d���P���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double FracProcUnitStcUnPrc
		{
			get{return _fracProcUnitStcUnPrc;}
			set{_fracProcUnitStcUnPrc = value;}
		}

		/// public propaty name  :  FracProcStckUnPrc
		/// <summary>�[�������i�d���P���j�v���p�e�B</summary>
		/// <value>1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�������i�d���P���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 FracProcStckUnPrc
		{
			get{return _fracProcStckUnPrc;}
			set{_fracProcStckUnPrc = value;}
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

		/// public propaty name  :  StockUnitTaxPriceFl
		/// <summary>�d���P���i�ō��C�����j�v���p�e�B</summary>
		/// <value>�ō���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���P���i�ō��C�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double StockUnitTaxPriceFl
		{
			get{return _stockUnitTaxPriceFl;}
			set{_stockUnitTaxPriceFl = value;}
		}

		/// public propaty name  :  StockUnitChngDiv
		/// <summary>�d���P���ύX�敪�v���p�e�B</summary>
		/// <value>0:�ύX�Ȃ�,1:�ύX����@�i�d���P������́j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���P���ύX�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockUnitChngDiv
		{
			get{return _stockUnitChngDiv;}
			set{_stockUnitChngDiv = value;}
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

		/// public propaty name  :  BfListPrice
		/// <summary>�ύX�O�艿�v���p�e�B</summary>
		/// <value>�Ŕ����A�|���Z�o����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ύX�O�艿�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double BfListPrice
		{
			get{return _bfListPrice;}
			set{_bfListPrice = value;}
		}

		/// public propaty name  :  RateBLGoodsCode
		/// <summary>BL���i�R�[�h�i�|���j�v���p�e�B</summary>
		/// <value>�|���Z�o���Ɏg�p����BL�R�[�h�i���i�������ʁj</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL���i�R�[�h�i�|���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 RateBLGoodsCode
		{
			get{return _rateBLGoodsCode;}
			set{_rateBLGoodsCode = value;}
		}

		/// public propaty name  :  RateBLGoodsName
		/// <summary>BL���i�R�[�h���́i�|���j�v���p�e�B</summary>
		/// <value>�|���Z�o���Ɏg�p����BL�R�[�h���́i���i�������ʁj</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL���i�R�[�h���́i�|���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string RateBLGoodsName
		{
			get{return _rateBLGoodsName;}
			set{_rateBLGoodsName = value;}
		}

		/// public propaty name  :  RateGoodsRateGrpCd
		/// <summary>���i�|���O���[�v�R�[�h�i�|���j�v���p�e�B</summary>
		/// <value>�|���Z�o���Ɏg�p�������i�|���R�[�h�i���i�������ʁj</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�|���O���[�v�R�[�h�i�|���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 RateGoodsRateGrpCd
		{
			get{return _rateGoodsRateGrpCd;}
			set{_rateGoodsRateGrpCd = value;}
		}

		/// public propaty name  :  RateGoodsRateGrpNm
		/// <summary>���i�|���O���[�v���́i�|���j�v���p�e�B</summary>
		/// <value>�|���Z�o���Ɏg�p�������i�|�����́i���i�������ʁj</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�|���O���[�v���́i�|���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string RateGoodsRateGrpNm
		{
			get{return _rateGoodsRateGrpNm;}
			set{_rateGoodsRateGrpNm = value;}
		}

		/// public propaty name  :  RateBLGroupCode
		/// <summary>BL�O���[�v�R�[�h�i�|���j�v���p�e�B</summary>
		/// <value>�|���Z�o���Ɏg�p����BL�O���[�v�R�[�h�i���i�������ʁj</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL�O���[�v�R�[�h�i�|���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 RateBLGroupCode
		{
			get{return _rateBLGroupCode;}
			set{_rateBLGroupCode = value;}
		}

		/// public propaty name  :  RateBLGroupName
		/// <summary>BL�O���[�v���́i�|���j�v���p�e�B</summary>
		/// <value>�|���Z�o���Ɏg�p����BL�O���[�v���́i���i�������ʁj</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL�O���[�v���́i�|���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string RateBLGroupName
		{
			get{return _rateBLGroupName;}
			set{_rateBLGroupName = value;}
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

		/// public propaty name  :  OrderCnt
		/// <summary>�������ʃv���p�e�B</summary>
		/// <value>����,���ׂŎg�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double OrderCnt
		{
			get{return _orderCnt;}
			set{_orderCnt = value;}
		}

		/// public propaty name  :  OrderAdjustCnt
		/// <summary>�����������v���p�e�B</summary>
		/// <value>���݂̔������́u�������ʁ{�����������v�ŎZ�o</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double OrderAdjustCnt
		{
			get{return _orderAdjustCnt;}
			set{_orderAdjustCnt = value;}
		}

		/// public propaty name  :  OrderRemainCnt
		/// <summary>�����c���v���p�e�B</summary>
		/// <value>�������ʁ{�����������|�d����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����c���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double OrderRemainCnt
		{
			get{return _orderRemainCnt;}
			set{_orderRemainCnt = value;}
		}

		/// public propaty name  :  RemainCntUpdDate
		/// <summary>�c���X�V���v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �c���X�V���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime RemainCntUpdDate
		{
			get{return _remainCntUpdDate;}
			set{_remainCntUpdDate = value;}
		}

		/// public propaty name  :  RemainCntUpdDateJpFormal
		/// <summary>�c���X�V�� �a��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �c���X�V�� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string RemainCntUpdDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _remainCntUpdDate);}
			set{}
		}

		/// public propaty name  :  RemainCntUpdDateJpInFormal
		/// <summary>�c���X�V�� �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �c���X�V�� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string RemainCntUpdDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _remainCntUpdDate);}
			set{}
		}

		/// public propaty name  :  RemainCntUpdDateAdFormal
		/// <summary>�c���X�V�� ����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �c���X�V�� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string RemainCntUpdDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _remainCntUpdDate);}
			set{}
		}

		/// public propaty name  :  RemainCntUpdDateAdInFormal
		/// <summary>�c���X�V�� ����(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �c���X�V�� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string RemainCntUpdDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _remainCntUpdDate);}
			set{}
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

		/// public propaty name  :  StockGoodsCd
		/// <summary>�d�����i�敪�v���p�e�B</summary>
		/// <value>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,6:���v����,10:���p����Œ���(����)</value>
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

		/// public propaty name  :  StockPriceConsTax
		/// <summary>�d�����z����Ŋz�v���p�e�B</summary>
		/// <value>�d�����z�i�ō��݁j- �d�����z�i�Ŕ����j������Œ����z�����˂�</value>
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

		/// public propaty name  :  TaxationCode
		/// <summary>�ېŋ敪�v���p�e�B</summary>
		/// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ېŋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TaxationCode
		{
			get{return _taxationCode;}
			set{_taxationCode = value;}
		}

		/// public propaty name  :  StockDtiSlipNote1
		/// <summary>�d���`�[���ה��l1�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���`�[���ה��l1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StockDtiSlipNote1
		{
			get{return _stockDtiSlipNote1;}
			set{_stockDtiSlipNote1 = value;}
		}

		/// public propaty name  :  SalesCustomerCode
		/// <summary>�̔���R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �̔���R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesCustomerCode
		{
			get{return _salesCustomerCode;}
			set{_salesCustomerCode = value;}
		}

		/// public propaty name  :  SalesCustomerSnm
		/// <summary>�̔��旪�̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �̔��旪�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesCustomerSnm
		{
			get{return _salesCustomerSnm;}
			set{_salesCustomerSnm = value;}
		}

		/// public propaty name  :  SlipMemo1
		/// <summary>�`�[�����P�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[�����P�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SlipMemo1
		{
			get{return _slipMemo1;}
			set{_slipMemo1 = value;}
		}

		/// public propaty name  :  SlipMemo2
		/// <summary>�`�[�����Q�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[�����Q�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SlipMemo2
		{
			get{return _slipMemo2;}
			set{_slipMemo2 = value;}
		}

		/// public propaty name  :  SlipMemo3
		/// <summary>�`�[�����R�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[�����R�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SlipMemo3
		{
			get{return _slipMemo3;}
			set{_slipMemo3 = value;}
		}

		/// public propaty name  :  InsideMemo1
		/// <summary>�Г������P�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Г������P�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InsideMemo1
		{
			get{return _insideMemo1;}
			set{_insideMemo1 = value;}
		}

		/// public propaty name  :  InsideMemo2
		/// <summary>�Г������Q�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Г������Q�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InsideMemo2
		{
			get{return _insideMemo2;}
			set{_insideMemo2 = value;}
		}

		/// public propaty name  :  InsideMemo3
		/// <summary>�Г������R�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Г������R�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InsideMemo3
		{
			get{return _insideMemo3;}
			set{_insideMemo3 = value;}
		}

		/// public propaty name  :  SupplierCd
		/// <summary>�d����R�[�h�v���p�e�B</summary>
		/// <value>�����p</value>
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
		/// <value>�����p</value>
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

		/// public propaty name  :  AddresseeCode
		/// <summary>�[�i��R�[�h�v���p�e�B</summary>
		/// <value>�����p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AddresseeCode
		{
			get{return _addresseeCode;}
			set{_addresseeCode = value;}
		}

		/// public propaty name  :  AddresseeName
		/// <summary>�[�i�於�̃v���p�e�B</summary>
		/// <value>�����p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�於�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddresseeName
		{
			get{return _addresseeName;}
			set{_addresseeName = value;}
		}

		/// public propaty name  :  DirectSendingCd
		/// <summary>�����敪�v���p�e�B</summary>
		/// <value>0:�����Ȃ�,1:��������@�i�������̒�����󎚐���j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DirectSendingCd
		{
			get{return _directSendingCd;}
			set{_directSendingCd = value;}
		}

		/// public propaty name  :  OrderNumber
		/// <summary>�����ԍ��v���p�e�B</summary>
		/// <value>�����p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string OrderNumber
		{
			get{return _orderNumber;}
			set{_orderNumber = value;}
		}

		/// public propaty name  :  WayToOrder
		/// <summary>�������@�v���p�e�B</summary>
		/// <value>0:����������,1:FAX���M,2:�I�����C������,4:�����ώ���o�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������@�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 WayToOrder
		{
			get{return _wayToOrder;}
			set{_wayToOrder = value;}
		}

		/// public propaty name  :  DeliGdsCmpltDueDate
		/// <summary>�[�i�����\����v���p�e�B</summary>
		/// <value>�����p�@�i�����񓚔[���j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�����\����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime DeliGdsCmpltDueDate
		{
			get{return _deliGdsCmpltDueDate;}
			set{_deliGdsCmpltDueDate = value;}
		}

		/// public propaty name  :  DeliGdsCmpltDueDateJpFormal
		/// <summary>�[�i�����\��� �a��v���p�e�B</summary>
		/// <value>�����p�@�i�����񓚔[���j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�����\��� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _deliGdsCmpltDueDate);}
			set{}
		}

		/// public propaty name  :  DeliGdsCmpltDueDateJpInFormal
		/// <summary>�[�i�����\��� �a��(��)�v���p�e�B</summary>
		/// <value>�����p�@�i�����񓚔[���j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�����\��� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _deliGdsCmpltDueDate);}
			set{}
		}

		/// public propaty name  :  DeliGdsCmpltDueDateAdFormal
		/// <summary>�[�i�����\��� ����v���p�e�B</summary>
		/// <value>�����p�@�i�����񓚔[���j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�����\��� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _deliGdsCmpltDueDate);}
			set{}
		}

		/// public propaty name  :  DeliGdsCmpltDueDateAdInFormal
		/// <summary>�[�i�����\��� ����(��)�v���p�e�B</summary>
		/// <value>�����p�@�i�����񓚔[���j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�����\��� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _deliGdsCmpltDueDate);}
			set{}
		}

		/// public propaty name  :  ExpectDeliveryDate
		/// <summary>��]�[���v���p�e�B</summary>
		/// <value>�����p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��]�[���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime ExpectDeliveryDate
		{
			get{return _expectDeliveryDate;}
			set{_expectDeliveryDate = value;}
		}

		/// public propaty name  :  ExpectDeliveryDateJpFormal
		/// <summary>��]�[�� �a��v���p�e�B</summary>
		/// <value>�����p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��]�[�� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ExpectDeliveryDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _expectDeliveryDate);}
			set{}
		}

		/// public propaty name  :  ExpectDeliveryDateJpInFormal
		/// <summary>��]�[�� �a��(��)�v���p�e�B</summary>
		/// <value>�����p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��]�[�� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ExpectDeliveryDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _expectDeliveryDate);}
			set{}
		}

		/// public propaty name  :  ExpectDeliveryDateAdFormal
		/// <summary>��]�[�� ����v���p�e�B</summary>
		/// <value>�����p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��]�[�� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ExpectDeliveryDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _expectDeliveryDate);}
			set{}
		}

		/// public propaty name  :  ExpectDeliveryDateAdInFormal
		/// <summary>��]�[�� ����(��)�v���p�e�B</summary>
		/// <value>�����p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��]�[�� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ExpectDeliveryDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _expectDeliveryDate);}
			set{}
		}

		/// public propaty name  :  OrderDataCreateDiv
		/// <summary>�����f�[�^�쐬�敪�v���p�e�B</summary>
		/// <value>1:�󔭒��������,2:��������,3:�݌ɕ�[����,4:�����_����@�i�������j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����f�[�^�쐬�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OrderDataCreateDiv
		{
			get{return _orderDataCreateDiv;}
			set{_orderDataCreateDiv = value;}
		}

		/// public propaty name  :  OrderDataCreateDate
		/// <summary>�����f�[�^�쐬���v���p�e�B</summary>
		/// <value>�����p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����f�[�^�쐬���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime OrderDataCreateDate
		{
			get{return _orderDataCreateDate;}
			set{_orderDataCreateDate = value;}
		}

		/// public propaty name  :  OrderDataCreateDateJpFormal
		/// <summary>�����f�[�^�쐬�� �a��v���p�e�B</summary>
		/// <value>�����p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����f�[�^�쐬�� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string OrderDataCreateDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _orderDataCreateDate);}
			set{}
		}

		/// public propaty name  :  OrderDataCreateDateJpInFormal
		/// <summary>�����f�[�^�쐬�� �a��(��)�v���p�e�B</summary>
		/// <value>�����p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����f�[�^�쐬�� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string OrderDataCreateDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _orderDataCreateDate);}
			set{}
		}

		/// public propaty name  :  OrderDataCreateDateAdFormal
		/// <summary>�����f�[�^�쐬�� ����v���p�e�B</summary>
		/// <value>�����p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����f�[�^�쐬�� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string OrderDataCreateDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _orderDataCreateDate);}
			set{}
		}

		/// public propaty name  :  OrderDataCreateDateAdInFormal
		/// <summary>�����f�[�^�쐬�� ����(��)�v���p�e�B</summary>
		/// <value>�����p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����f�[�^�쐬�� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string OrderDataCreateDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _orderDataCreateDate);}
			set{}
		}

		/// public propaty name  :  OrderFormIssuedDiv
		/// <summary>���������s�ϋ敪�v���p�e�B</summary>
		/// <value>0:�����s,1:���s��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���������s�ϋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OrderFormIssuedDiv
		{
			get{return _orderFormIssuedDiv;}
			set{_orderFormIssuedDiv = value;}
		}

		/// public propaty name  :  DtlRelationGuid
		/// <summary>���׊֘A�t��GUID�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���׊֘A�t��GUID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Guid DtlRelationGuid
		{
			get{return _dtlRelationGuid;}
			set{_dtlRelationGuid = value;}
		}

		/// public propaty name  :  GoodsOfferDate
		/// <summary>���i�񋟓��t�v���p�e�B</summary>
		/// <value>YYYYMMDD�@���i�}�X�^�ɓo�^����񋟓��t�AUI���Őݒ�@��DateTime�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�񋟓��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime GoodsOfferDate
		{
			get{return _goodsOfferDate;}
			set{_goodsOfferDate = value;}
		}

		/// public propaty name  :  PriceStartDate
		/// <summary>���i�J�n���t�v���p�e�B</summary>
		/// <value>YYYYMMDD�@���i�}�X�^�ɓo�^���鉿�i�J�n���AUI���Őݒ�@��DateTime�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�J�n���t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime PriceStartDate
		{
			get{return _priceStartDate;}
			set{_priceStartDate = value;}
		}

		/// public propaty name  :  PriceStartDateJpFormal
		/// <summary>���i�J�n���t �a��v���p�e�B</summary>
		/// <value>YYYYMMDD�@���i�}�X�^�ɓo�^���鉿�i�J�n���AUI���Őݒ�@��DateTime�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�J�n���t �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PriceStartDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _priceStartDate);}
			set{}
		}

		/// public propaty name  :  PriceStartDateJpInFormal
		/// <summary>���i�J�n���t �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD�@���i�}�X�^�ɓo�^���鉿�i�J�n���AUI���Őݒ�@��DateTime�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�J�n���t �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PriceStartDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _priceStartDate);}
			set{}
		}

		/// public propaty name  :  PriceStartDateAdFormal
		/// <summary>���i�J�n���t ����v���p�e�B</summary>
		/// <value>YYYYMMDD�@���i�}�X�^�ɓo�^���鉿�i�J�n���AUI���Őݒ�@��DateTime�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�J�n���t ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PriceStartDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _priceStartDate);}
			set{}
		}

		/// public propaty name  :  PriceStartDateAdInFormal
		/// <summary>���i�J�n���t ����(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD�@���i�}�X�^�ɓo�^���鉿�i�J�n���AUI���Őݒ�@��DateTime�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�J�n���t ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PriceStartDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _priceStartDate);}
			set{}
		}

		/// public propaty name  :  PriceOfferDate
		/// <summary>���i�񋟓��t�v���p�e�B</summary>
		/// <value>YYYYMMDD�@���i�}�X�^�ɓo�^����񋟓��t�AUI���Őݒ�@��DateTime�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�񋟓��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime PriceOfferDate
		{
			get{return _priceOfferDate;}
			set{_priceOfferDate = value;}
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

		/// public propaty name  :  UpdEmployeeName
		/// <summary>�X�V�]�ƈ����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�]�ƈ����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdEmployeeName
		{
			get{return _updEmployeeName;}
			set{_updEmployeeName = value;}
		}

		/// public propaty name  :  BLGoodsName
		/// <summary>BL���i�R�[�h���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL���i�R�[�h���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BLGoodsName
		{
			get{return _bLGoodsName;}
			set{_bLGoodsName = value;}
		}


		/// <summary>
		/// �d�����׃f�[�^�R���X�g���N�^
		/// </summary>
		/// <returns>StockDetail�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockDetail�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockDetail()
		{
		}

		/// <summary>
		/// �d�����׃f�[�^�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
		/// <param name="acceptAnOrderNo">�󒍔ԍ�</param>
		/// <param name="supplierFormal">�d���`��(0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j)</param>
		/// <param name="supplierSlipNo">�d���`�[�ԍ�(�d���`�[�ԍ�,���ד`�[�ԍ�,�������ԍ�(����)�����˂�B�i�������̓[���j)</param>
		/// <param name="stockRowNo">�d���s�ԍ�</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="subSectionCode">����R�[�h</param>
		/// <param name="commonSeqNo">���ʒʔ�</param>
		/// <param name="stockSlipDtlNum">�d�����גʔ�</param>
		/// <param name="supplierFormalSrc">�d���`���i���j(0:�d��,1:����,2:����)</param>
		/// <param name="stockSlipDtlNumSrc">�d�����גʔԁi���j(�v�㎞�̌��f�[�^���גʔԂ��Z�b�g)</param>
		/// <param name="acptAnOdrStatusSync">�󒍃X�e�[�^�X�i�����j(30:����,40:�o��)</param>
		/// <param name="salesSlipDtlNumSync">���㖾�גʔԁi�����j(�����v�㎞�̎d�����גʔԂ��Z�b�g)</param>
		/// <param name="stockSlipCdDtl">�d���`�[�敪�i���ׁj(0:�d��,1:�ԕi,2:�l��)</param>
		/// <param name="stockInputCode">�d�����͎҃R�[�h</param>
		/// <param name="stockInputName">�d�����͎Җ���</param>
		/// <param name="stockAgentCode">�d���S���҃R�[�h</param>
		/// <param name="stockAgentName">�d���S���Җ���</param>
		/// <param name="goodsKindCode">���i����</param>
		/// <param name="goodsMakerCd">���i���[�J�[�R�[�h(�߯���ޖ���հ�ް�o�^�͈͂��قȂ�)</param>
		/// <param name="makerName">���[�J�[����</param>
		/// <param name="makerKanaName">���[�J�[�J�i����</param>
		/// <param name="cmpltMakerKanaName">���[�J�[�J�i���́i�ꎮ�j</param>
		/// <param name="goodsNo">���i�ԍ�</param>
		/// <param name="goodsName">���i����</param>
		/// <param name="goodsNameKana">���i���̃J�i</param>
		/// <param name="goodsLGroup">���i�啪�ރR�[�h(���啪�ށi���[�U�[�K�C�h�j)</param>
		/// <param name="goodsLGroupName">���i�啪�ޖ���</param>
		/// <param name="goodsMGroup">���i�����ރR�[�h(�������ރR�[�h)</param>
		/// <param name="goodsMGroupName">���i�����ޖ���</param>
		/// <param name="bLGroupCode">BL�O���[�v�R�[�h(���O���[�v�R�[�h)</param>
		/// <param name="bLGroupName">BL�O���[�v�R�[�h����</param>
		/// <param name="bLGoodsCode">BL���i�R�[�h</param>
		/// <param name="bLGoodsFullName">BL���i�R�[�h���́i�S�p�j</param>
		/// <param name="enterpriseGanreCode">���Е��ރR�[�h</param>
		/// <param name="enterpriseGanreName">���Е��ޖ���</param>
		/// <param name="warehouseCode">�q�ɃR�[�h</param>
		/// <param name="warehouseName">�q�ɖ���</param>
		/// <param name="warehouseShelfNo">�q�ɒI��</param>
		/// <param name="stockOrderDivCd">�d���݌Ɏ�񂹋敪(0:���,1:�݌�)</param>
		/// <param name="openPriceDiv">�I�[�v�����i�敪(0:�ʏ�^1:�I�[�v�����i)</param>
		/// <param name="goodsRateRank">���i�|�������N(���i�̊|���p�����N)</param>
		/// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h</param>
		/// <param name="suppRateGrpCode">�d����|���O���[�v�R�[�h</param>
		/// <param name="listPriceTaxExcFl">�艿�i�Ŕ��C�����j(�Ŕ���)</param>
		/// <param name="listPriceTaxIncFl">�艿�i�ō��C�����j(�ō���)</param>
		/// <param name="stockRate">�d����</param>
		/// <param name="rateSectStckUnPrc">�|���ݒ苒�_�i�d���P���j(0:�S�Аݒ�, ���̑�:���_�R�[�h)</param>
		/// <param name="rateDivStckUnPrc">�|���ݒ�敪�i�d���P���j(A7,A8,�c)</param>
		/// <param name="unPrcCalcCdStckUnPrc">�P���Z�o�敪�i�d���P���j(1:�|��,2:�����t�o��,3:�e����)</param>
		/// <param name="priceCdStckUnPrc">���i�敪�i�d���P���j(0:�艿,1:�o�^�̔��X���i,�c)</param>
		/// <param name="stdUnPrcStckUnPrc">��P���i�d���P���j</param>
		/// <param name="fracProcUnitStcUnPrc">�[�������P�ʁi�d���P���j</param>
		/// <param name="fracProcStckUnPrc">�[�������i�d���P���j(1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ)</param>
		/// <param name="stockUnitPriceFl">�d���P���i�Ŕ��C�����j(�Ŕ���)</param>
		/// <param name="stockUnitTaxPriceFl">�d���P���i�ō��C�����j(�ō���)</param>
		/// <param name="stockUnitChngDiv">�d���P���ύX�敪(0:�ύX�Ȃ�,1:�ύX����@�i�d���P������́j)</param>
		/// <param name="bfStockUnitPriceFl">�ύX�O�d���P���i�����j(�Ŕ����A�|���Z�o����)</param>
		/// <param name="bfListPrice">�ύX�O�艿(�Ŕ����A�|���Z�o����)</param>
		/// <param name="rateBLGoodsCode">BL���i�R�[�h�i�|���j(�|���Z�o���Ɏg�p����BL�R�[�h�i���i�������ʁj)</param>
		/// <param name="rateBLGoodsName">BL���i�R�[�h���́i�|���j(�|���Z�o���Ɏg�p����BL�R�[�h���́i���i�������ʁj)</param>
		/// <param name="rateGoodsRateGrpCd">���i�|���O���[�v�R�[�h�i�|���j(�|���Z�o���Ɏg�p�������i�|���R�[�h�i���i�������ʁj)</param>
		/// <param name="rateGoodsRateGrpNm">���i�|���O���[�v���́i�|���j(�|���Z�o���Ɏg�p�������i�|�����́i���i�������ʁj)</param>
		/// <param name="rateBLGroupCode">BL�O���[�v�R�[�h�i�|���j(�|���Z�o���Ɏg�p����BL�O���[�v�R�[�h�i���i�������ʁj)</param>
		/// <param name="rateBLGroupName">BL�O���[�v���́i�|���j(�|���Z�o���Ɏg�p����BL�O���[�v���́i���i�������ʁj)</param>
		/// <param name="stockCount">�d����</param>
		/// <param name="orderCnt">��������(����,���ׂŎg�p)</param>
		/// <param name="orderAdjustCnt">����������(���݂̔������́u�������ʁ{�����������v�ŎZ�o)</param>
		/// <param name="orderRemainCnt">�����c��(�������ʁ{�����������|�d����)</param>
		/// <param name="remainCntUpdDate">�c���X�V��(YYYYMMDD)</param>
		/// <param name="stockPriceTaxExc">�d�����z�i�Ŕ����j</param>
		/// <param name="stockPriceTaxInc">�d�����z�i�ō��݁j</param>
		/// <param name="stockGoodsCd">�d�����i�敪(0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,6:���v����,10:���p����Œ���(����))</param>
		/// <param name="stockPriceConsTax">�d�����z����Ŋz(�d�����z�i�ō��݁j- �d�����z�i�Ŕ����j������Œ����z�����˂�)</param>
		/// <param name="taxationCode">�ېŋ敪(0:�ې�,1:��ې�,2:�ېŁi���Łj)</param>
		/// <param name="stockDtiSlipNote1">�d���`�[���ה��l1</param>
		/// <param name="salesCustomerCode">�̔���R�[�h</param>
		/// <param name="salesCustomerSnm">�̔��旪��</param>
		/// <param name="slipMemo1">�`�[�����P</param>
		/// <param name="slipMemo2">�`�[�����Q</param>
		/// <param name="slipMemo3">�`�[�����R</param>
		/// <param name="insideMemo1">�Г������P</param>
		/// <param name="insideMemo2">�Г������Q</param>
		/// <param name="insideMemo3">�Г������R</param>
		/// <param name="supplierCd">�d����R�[�h(�����p)</param>
		/// <param name="supplierSnm">�d���旪��(�����p)</param>
		/// <param name="addresseeCode">�[�i��R�[�h(�����p)</param>
		/// <param name="addresseeName">�[�i�於��(�����p)</param>
		/// <param name="directSendingCd">�����敪(0:�����Ȃ�,1:��������@�i�������̒�����󎚐���j)</param>
		/// <param name="orderNumber">�����ԍ�(�����p)</param>
		/// <param name="wayToOrder">�������@(0:����������,1:FAX���M,2:�I�����C������,4:�����ώ���o�^)</param>
		/// <param name="deliGdsCmpltDueDate">�[�i�����\���(�����p�@�i�����񓚔[���j)</param>
		/// <param name="expectDeliveryDate">��]�[��(�����p)</param>
		/// <param name="orderDataCreateDiv">�����f�[�^�쐬�敪(1:�󔭒��������,2:��������,3:�݌ɕ�[����,4:�����_����@�i�������j)</param>
		/// <param name="orderDataCreateDate">�����f�[�^�쐬��(�����p)</param>
		/// <param name="orderFormIssuedDiv">���������s�ϋ敪(0:�����s,1:���s��)</param>
		/// <param name="dtlRelationGuid">���׊֘A�t��GUID</param>
		/// <param name="goodsOfferDate">���i�񋟓��t(YYYYMMDD�@���i�}�X�^�ɓo�^����񋟓��t�AUI���Őݒ�@��DateTime�^)</param>
		/// <param name="priceStartDate">���i�J�n���t(YYYYMMDD�@���i�}�X�^�ɓo�^���鉿�i�J�n���AUI���Őݒ�@��DateTime�^)</param>
		/// <param name="priceOfferDate">���i�񋟓��t(YYYYMMDD�@���i�}�X�^�ɓo�^����񋟓��t�AUI���Őݒ�@��DateTime�^)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <param name="bLGoodsName">BL���i�R�[�h����</param>
		/// <returns>StockDetail�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockDetail�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockDetail(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,Int32 acceptAnOrderNo,Int32 supplierFormal,Int32 supplierSlipNo,Int32 stockRowNo,string sectionCode,Int32 subSectionCode,Int64 commonSeqNo,Int64 stockSlipDtlNum,Int32 supplierFormalSrc,Int64 stockSlipDtlNumSrc,Int32 acptAnOdrStatusSync,Int64 salesSlipDtlNumSync,Int32 stockSlipCdDtl,string stockInputCode,string stockInputName,string stockAgentCode,string stockAgentName,Int32 goodsKindCode,Int32 goodsMakerCd,string makerName,string makerKanaName,string cmpltMakerKanaName,string goodsNo,string goodsName,string goodsNameKana,Int32 goodsLGroup,string goodsLGroupName,Int32 goodsMGroup,string goodsMGroupName,Int32 bLGroupCode,string bLGroupName,Int32 bLGoodsCode,string bLGoodsFullName,Int32 enterpriseGanreCode,string enterpriseGanreName,string warehouseCode,string warehouseName,string warehouseShelfNo,Int32 stockOrderDivCd,Int32 openPriceDiv,string goodsRateRank,Int32 custRateGrpCode,Int32 suppRateGrpCode,Double listPriceTaxExcFl,Double listPriceTaxIncFl,Double stockRate,string rateSectStckUnPrc,string rateDivStckUnPrc,Int32 unPrcCalcCdStckUnPrc,Int32 priceCdStckUnPrc,Double stdUnPrcStckUnPrc,Double fracProcUnitStcUnPrc,Int32 fracProcStckUnPrc,Double stockUnitPriceFl,Double stockUnitTaxPriceFl,Int32 stockUnitChngDiv,Double bfStockUnitPriceFl,Double bfListPrice,Int32 rateBLGoodsCode,string rateBLGoodsName,Int32 rateGoodsRateGrpCd,string rateGoodsRateGrpNm,Int32 rateBLGroupCode,string rateBLGroupName,Double stockCount,Double orderCnt,Double orderAdjustCnt,Double orderRemainCnt,DateTime remainCntUpdDate,Int64 stockPriceTaxExc,Int64 stockPriceTaxInc,Int32 stockGoodsCd,Int64 stockPriceConsTax,Int32 taxationCode,string stockDtiSlipNote1,Int32 salesCustomerCode,string salesCustomerSnm,string slipMemo1,string slipMemo2,string slipMemo3,string insideMemo1,string insideMemo2,string insideMemo3,Int32 supplierCd,string supplierSnm,Int32 addresseeCode,string addresseeName,Int32 directSendingCd,string orderNumber,Int32 wayToOrder,DateTime deliGdsCmpltDueDate,DateTime expectDeliveryDate,Int32 orderDataCreateDiv,DateTime orderDataCreateDate,Int32 orderFormIssuedDiv,Guid dtlRelationGuid,DateTime goodsOfferDate,DateTime priceStartDate,DateTime priceOfferDate,string enterpriseName,string updEmployeeName,string bLGoodsName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._acceptAnOrderNo = acceptAnOrderNo;
			this._supplierFormal = supplierFormal;
			this._supplierSlipNo = supplierSlipNo;
			this._stockRowNo = stockRowNo;
			this._sectionCode = sectionCode;
			this._subSectionCode = subSectionCode;
			this._commonSeqNo = commonSeqNo;
			this._stockSlipDtlNum = stockSlipDtlNum;
			this._supplierFormalSrc = supplierFormalSrc;
			this._stockSlipDtlNumSrc = stockSlipDtlNumSrc;
			this._acptAnOdrStatusSync = acptAnOdrStatusSync;
			this._salesSlipDtlNumSync = salesSlipDtlNumSync;
			this._stockSlipCdDtl = stockSlipCdDtl;
			this._stockInputCode = stockInputCode;
			this._stockInputName = stockInputName;
			this._stockAgentCode = stockAgentCode;
			this._stockAgentName = stockAgentName;
			this._goodsKindCode = goodsKindCode;
			this._goodsMakerCd = goodsMakerCd;
			this._makerName = makerName;
			this._makerKanaName = makerKanaName;
			this._cmpltMakerKanaName = cmpltMakerKanaName;
			this._goodsNo = goodsNo;
			this._goodsName = goodsName;
			this._goodsNameKana = goodsNameKana;
			this._goodsLGroup = goodsLGroup;
			this._goodsLGroupName = goodsLGroupName;
			this._goodsMGroup = goodsMGroup;
			this._goodsMGroupName = goodsMGroupName;
			this._bLGroupCode = bLGroupCode;
			this._bLGroupName = bLGroupName;
			this._bLGoodsCode = bLGoodsCode;
			this._bLGoodsFullName = bLGoodsFullName;
			this._enterpriseGanreCode = enterpriseGanreCode;
			this._enterpriseGanreName = enterpriseGanreName;
			this._warehouseCode = warehouseCode;
			this._warehouseName = warehouseName;
			this._warehouseShelfNo = warehouseShelfNo;
			this._stockOrderDivCd = stockOrderDivCd;
			this._openPriceDiv = openPriceDiv;
			this._goodsRateRank = goodsRateRank;
			this._custRateGrpCode = custRateGrpCode;
			this._suppRateGrpCode = suppRateGrpCode;
			this._listPriceTaxExcFl = listPriceTaxExcFl;
			this._listPriceTaxIncFl = listPriceTaxIncFl;
			this._stockRate = stockRate;
			this._rateSectStckUnPrc = rateSectStckUnPrc;
			this._rateDivStckUnPrc = rateDivStckUnPrc;
			this._unPrcCalcCdStckUnPrc = unPrcCalcCdStckUnPrc;
			this._priceCdStckUnPrc = priceCdStckUnPrc;
			this._stdUnPrcStckUnPrc = stdUnPrcStckUnPrc;
			this._fracProcUnitStcUnPrc = fracProcUnitStcUnPrc;
			this._fracProcStckUnPrc = fracProcStckUnPrc;
			this._stockUnitPriceFl = stockUnitPriceFl;
			this._stockUnitTaxPriceFl = stockUnitTaxPriceFl;
			this._stockUnitChngDiv = stockUnitChngDiv;
			this._bfStockUnitPriceFl = bfStockUnitPriceFl;
			this._bfListPrice = bfListPrice;
			this._rateBLGoodsCode = rateBLGoodsCode;
			this._rateBLGoodsName = rateBLGoodsName;
			this._rateGoodsRateGrpCd = rateGoodsRateGrpCd;
			this._rateGoodsRateGrpNm = rateGoodsRateGrpNm;
			this._rateBLGroupCode = rateBLGroupCode;
			this._rateBLGroupName = rateBLGroupName;
			this._stockCount = stockCount;
			this._orderCnt = orderCnt;
			this._orderAdjustCnt = orderAdjustCnt;
			this._orderRemainCnt = orderRemainCnt;
			this.RemainCntUpdDate = remainCntUpdDate;
			this._stockPriceTaxExc = stockPriceTaxExc;
			this._stockPriceTaxInc = stockPriceTaxInc;
			this._stockGoodsCd = stockGoodsCd;
			this._stockPriceConsTax = stockPriceConsTax;
			this._taxationCode = taxationCode;
			this._stockDtiSlipNote1 = stockDtiSlipNote1;
			this._salesCustomerCode = salesCustomerCode;
			this._salesCustomerSnm = salesCustomerSnm;
			this._slipMemo1 = slipMemo1;
			this._slipMemo2 = slipMemo2;
			this._slipMemo3 = slipMemo3;
			this._insideMemo1 = insideMemo1;
			this._insideMemo2 = insideMemo2;
			this._insideMemo3 = insideMemo3;
			this._supplierCd = supplierCd;
			this._supplierSnm = supplierSnm;
			this._addresseeCode = addresseeCode;
			this._addresseeName = addresseeName;
			this._directSendingCd = directSendingCd;
			this._orderNumber = orderNumber;
			this._wayToOrder = wayToOrder;
			this.DeliGdsCmpltDueDate = deliGdsCmpltDueDate;
			this.ExpectDeliveryDate = expectDeliveryDate;
			this._orderDataCreateDiv = orderDataCreateDiv;
			this.OrderDataCreateDate = orderDataCreateDate;
			this._orderFormIssuedDiv = orderFormIssuedDiv;
			this._dtlRelationGuid = dtlRelationGuid;
			this._goodsOfferDate = goodsOfferDate;
			this.PriceStartDate = priceStartDate;
			this._priceOfferDate = priceOfferDate;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
			this._bLGoodsName = bLGoodsName;

		}

		/// <summary>
		/// �d�����׃f�[�^��������
		/// </summary>
		/// <returns>StockDetail�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����StockDetail�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockDetail Clone()
		{
			return new StockDetail(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._acceptAnOrderNo,this._supplierFormal,this._supplierSlipNo,this._stockRowNo,this._sectionCode,this._subSectionCode,this._commonSeqNo,this._stockSlipDtlNum,this._supplierFormalSrc,this._stockSlipDtlNumSrc,this._acptAnOdrStatusSync,this._salesSlipDtlNumSync,this._stockSlipCdDtl,this._stockInputCode,this._stockInputName,this._stockAgentCode,this._stockAgentName,this._goodsKindCode,this._goodsMakerCd,this._makerName,this._makerKanaName,this._cmpltMakerKanaName,this._goodsNo,this._goodsName,this._goodsNameKana,this._goodsLGroup,this._goodsLGroupName,this._goodsMGroup,this._goodsMGroupName,this._bLGroupCode,this._bLGroupName,this._bLGoodsCode,this._bLGoodsFullName,this._enterpriseGanreCode,this._enterpriseGanreName,this._warehouseCode,this._warehouseName,this._warehouseShelfNo,this._stockOrderDivCd,this._openPriceDiv,this._goodsRateRank,this._custRateGrpCode,this._suppRateGrpCode,this._listPriceTaxExcFl,this._listPriceTaxIncFl,this._stockRate,this._rateSectStckUnPrc,this._rateDivStckUnPrc,this._unPrcCalcCdStckUnPrc,this._priceCdStckUnPrc,this._stdUnPrcStckUnPrc,this._fracProcUnitStcUnPrc,this._fracProcStckUnPrc,this._stockUnitPriceFl,this._stockUnitTaxPriceFl,this._stockUnitChngDiv,this._bfStockUnitPriceFl,this._bfListPrice,this._rateBLGoodsCode,this._rateBLGoodsName,this._rateGoodsRateGrpCd,this._rateGoodsRateGrpNm,this._rateBLGroupCode,this._rateBLGroupName,this._stockCount,this._orderCnt,this._orderAdjustCnt,this._orderRemainCnt,this._remainCntUpdDate,this._stockPriceTaxExc,this._stockPriceTaxInc,this._stockGoodsCd,this._stockPriceConsTax,this._taxationCode,this._stockDtiSlipNote1,this._salesCustomerCode,this._salesCustomerSnm,this._slipMemo1,this._slipMemo2,this._slipMemo3,this._insideMemo1,this._insideMemo2,this._insideMemo3,this._supplierCd,this._supplierSnm,this._addresseeCode,this._addresseeName,this._directSendingCd,this._orderNumber,this._wayToOrder,this._deliGdsCmpltDueDate,this._expectDeliveryDate,this._orderDataCreateDiv,this._orderDataCreateDate,this._orderFormIssuedDiv,this._dtlRelationGuid,this._goodsOfferDate,this._priceStartDate,this._priceOfferDate,this._enterpriseName,this._updEmployeeName,this._bLGoodsName);
		}

		/// <summary>
		/// �d�����׃f�[�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�StockDetail�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockDetail�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(StockDetail target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.AcceptAnOrderNo == target.AcceptAnOrderNo)
				 && (this.SupplierFormal == target.SupplierFormal)
				 && (this.SupplierSlipNo == target.SupplierSlipNo)
				 && (this.StockRowNo == target.StockRowNo)
				 && (this.SectionCode == target.SectionCode)
				 && (this.SubSectionCode == target.SubSectionCode)
				 && (this.CommonSeqNo == target.CommonSeqNo)
				 && (this.StockSlipDtlNum == target.StockSlipDtlNum)
				 && (this.SupplierFormalSrc == target.SupplierFormalSrc)
				 && (this.StockSlipDtlNumSrc == target.StockSlipDtlNumSrc)
				 && (this.AcptAnOdrStatusSync == target.AcptAnOdrStatusSync)
				 && (this.SalesSlipDtlNumSync == target.SalesSlipDtlNumSync)
				 && (this.StockSlipCdDtl == target.StockSlipCdDtl)
				 && (this.StockInputCode == target.StockInputCode)
				 && (this.StockInputName == target.StockInputName)
				 && (this.StockAgentCode == target.StockAgentCode)
				 && (this.StockAgentName == target.StockAgentName)
				 && (this.GoodsKindCode == target.GoodsKindCode)
				 && (this.GoodsMakerCd == target.GoodsMakerCd)
				 && (this.MakerName == target.MakerName)
				 && (this.MakerKanaName == target.MakerKanaName)
				 && (this.CmpltMakerKanaName == target.CmpltMakerKanaName)
				 && (this.GoodsNo == target.GoodsNo)
				 && (this.GoodsName == target.GoodsName)
				 && (this.GoodsNameKana == target.GoodsNameKana)
				 && (this.GoodsLGroup == target.GoodsLGroup)
				 && (this.GoodsLGroupName == target.GoodsLGroupName)
				 && (this.GoodsMGroup == target.GoodsMGroup)
				 && (this.GoodsMGroupName == target.GoodsMGroupName)
				 && (this.BLGroupCode == target.BLGroupCode)
				 && (this.BLGroupName == target.BLGroupName)
				 && (this.BLGoodsCode == target.BLGoodsCode)
				 && (this.BLGoodsFullName == target.BLGoodsFullName)
				 && (this.EnterpriseGanreCode == target.EnterpriseGanreCode)
				 && (this.EnterpriseGanreName == target.EnterpriseGanreName)
				 && (this.WarehouseCode == target.WarehouseCode)
				 && (this.WarehouseName == target.WarehouseName)
				 && (this.WarehouseShelfNo == target.WarehouseShelfNo)
				 && (this.StockOrderDivCd == target.StockOrderDivCd)
				 && (this.OpenPriceDiv == target.OpenPriceDiv)
				 && (this.GoodsRateRank == target.GoodsRateRank)
				 && (this.CustRateGrpCode == target.CustRateGrpCode)
				 && (this.SuppRateGrpCode == target.SuppRateGrpCode)
				 && (this.ListPriceTaxExcFl == target.ListPriceTaxExcFl)
				 && (this.ListPriceTaxIncFl == target.ListPriceTaxIncFl)
				 && (this.StockRate == target.StockRate)
				 && (this.RateSectStckUnPrc == target.RateSectStckUnPrc)
				 && (this.RateDivStckUnPrc == target.RateDivStckUnPrc)
				 && (this.UnPrcCalcCdStckUnPrc == target.UnPrcCalcCdStckUnPrc)
				 && (this.PriceCdStckUnPrc == target.PriceCdStckUnPrc)
				 && (this.StdUnPrcStckUnPrc == target.StdUnPrcStckUnPrc)
				 && (this.FracProcUnitStcUnPrc == target.FracProcUnitStcUnPrc)
				 && (this.FracProcStckUnPrc == target.FracProcStckUnPrc)
				 && (this.StockUnitPriceFl == target.StockUnitPriceFl)
				 && (this.StockUnitTaxPriceFl == target.StockUnitTaxPriceFl)
				 && (this.StockUnitChngDiv == target.StockUnitChngDiv)
				 && (this.BfStockUnitPriceFl == target.BfStockUnitPriceFl)
				 && (this.BfListPrice == target.BfListPrice)
				 && (this.RateBLGoodsCode == target.RateBLGoodsCode)
				 && (this.RateBLGoodsName == target.RateBLGoodsName)
				 && (this.RateGoodsRateGrpCd == target.RateGoodsRateGrpCd)
				 && (this.RateGoodsRateGrpNm == target.RateGoodsRateGrpNm)
				 && (this.RateBLGroupCode == target.RateBLGroupCode)
				 && (this.RateBLGroupName == target.RateBLGroupName)
				 && (this.StockCount == target.StockCount)
				 && (this.OrderCnt == target.OrderCnt)
				 && (this.OrderAdjustCnt == target.OrderAdjustCnt)
				 && (this.OrderRemainCnt == target.OrderRemainCnt)
				 && (this.RemainCntUpdDate == target.RemainCntUpdDate)
				 && (this.StockPriceTaxExc == target.StockPriceTaxExc)
				 && (this.StockPriceTaxInc == target.StockPriceTaxInc)
				 && (this.StockGoodsCd == target.StockGoodsCd)
				 && (this.StockPriceConsTax == target.StockPriceConsTax)
				 && (this.TaxationCode == target.TaxationCode)
				 && (this.StockDtiSlipNote1 == target.StockDtiSlipNote1)
				 && (this.SalesCustomerCode == target.SalesCustomerCode)
				 && (this.SalesCustomerSnm == target.SalesCustomerSnm)
				 && (this.SlipMemo1 == target.SlipMemo1)
				 && (this.SlipMemo2 == target.SlipMemo2)
				 && (this.SlipMemo3 == target.SlipMemo3)
				 && (this.InsideMemo1 == target.InsideMemo1)
				 && (this.InsideMemo2 == target.InsideMemo2)
				 && (this.InsideMemo3 == target.InsideMemo3)
				 && (this.SupplierCd == target.SupplierCd)
				 && (this.SupplierSnm == target.SupplierSnm)
				 && (this.AddresseeCode == target.AddresseeCode)
				 && (this.AddresseeName == target.AddresseeName)
				 && (this.DirectSendingCd == target.DirectSendingCd)
				 && (this.OrderNumber == target.OrderNumber)
				 && (this.WayToOrder == target.WayToOrder)
				 && (this.DeliGdsCmpltDueDate == target.DeliGdsCmpltDueDate)
				 && (this.ExpectDeliveryDate == target.ExpectDeliveryDate)
				 && (this.OrderDataCreateDiv == target.OrderDataCreateDiv)
				 && (this.OrderDataCreateDate == target.OrderDataCreateDate)
				 && (this.OrderFormIssuedDiv == target.OrderFormIssuedDiv)
				 && (this.DtlRelationGuid == target.DtlRelationGuid)
				 && (this.GoodsOfferDate == target.GoodsOfferDate)
				 && (this.PriceStartDate == target.PriceStartDate)
				 && (this.PriceOfferDate == target.PriceOfferDate)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
				 && (this.BLGoodsName == target.BLGoodsName));
		}

		/// <summary>
		/// �d�����׃f�[�^��r����
		/// </summary>
		/// <param name="stockDetail1">
		///                    ��r����StockDetail�N���X�̃C���X�^���X
		/// </param>
		/// <param name="stockDetail2">��r����StockDetail�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockDetail�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(StockDetail stockDetail1, StockDetail stockDetail2)
		{
			return ((stockDetail1.CreateDateTime == stockDetail2.CreateDateTime)
				 && (stockDetail1.UpdateDateTime == stockDetail2.UpdateDateTime)
				 && (stockDetail1.EnterpriseCode == stockDetail2.EnterpriseCode)
				 && (stockDetail1.FileHeaderGuid == stockDetail2.FileHeaderGuid)
				 && (stockDetail1.UpdEmployeeCode == stockDetail2.UpdEmployeeCode)
				 && (stockDetail1.UpdAssemblyId1 == stockDetail2.UpdAssemblyId1)
				 && (stockDetail1.UpdAssemblyId2 == stockDetail2.UpdAssemblyId2)
				 && (stockDetail1.LogicalDeleteCode == stockDetail2.LogicalDeleteCode)
				 && (stockDetail1.AcceptAnOrderNo == stockDetail2.AcceptAnOrderNo)
				 && (stockDetail1.SupplierFormal == stockDetail2.SupplierFormal)
				 && (stockDetail1.SupplierSlipNo == stockDetail2.SupplierSlipNo)
				 && (stockDetail1.StockRowNo == stockDetail2.StockRowNo)
				 && (stockDetail1.SectionCode == stockDetail2.SectionCode)
				 && (stockDetail1.SubSectionCode == stockDetail2.SubSectionCode)
				 && (stockDetail1.CommonSeqNo == stockDetail2.CommonSeqNo)
				 && (stockDetail1.StockSlipDtlNum == stockDetail2.StockSlipDtlNum)
				 && (stockDetail1.SupplierFormalSrc == stockDetail2.SupplierFormalSrc)
				 && (stockDetail1.StockSlipDtlNumSrc == stockDetail2.StockSlipDtlNumSrc)
				 && (stockDetail1.AcptAnOdrStatusSync == stockDetail2.AcptAnOdrStatusSync)
				 && (stockDetail1.SalesSlipDtlNumSync == stockDetail2.SalesSlipDtlNumSync)
				 && (stockDetail1.StockSlipCdDtl == stockDetail2.StockSlipCdDtl)
				 && (stockDetail1.StockInputCode == stockDetail2.StockInputCode)
				 && (stockDetail1.StockInputName == stockDetail2.StockInputName)
				 && (stockDetail1.StockAgentCode == stockDetail2.StockAgentCode)
				 && (stockDetail1.StockAgentName == stockDetail2.StockAgentName)
				 && (stockDetail1.GoodsKindCode == stockDetail2.GoodsKindCode)
				 && (stockDetail1.GoodsMakerCd == stockDetail2.GoodsMakerCd)
				 && (stockDetail1.MakerName == stockDetail2.MakerName)
				 && (stockDetail1.MakerKanaName == stockDetail2.MakerKanaName)
				 && (stockDetail1.CmpltMakerKanaName == stockDetail2.CmpltMakerKanaName)
				 && (stockDetail1.GoodsNo == stockDetail2.GoodsNo)
				 && (stockDetail1.GoodsName == stockDetail2.GoodsName)
				 && (stockDetail1.GoodsNameKana == stockDetail2.GoodsNameKana)
				 && (stockDetail1.GoodsLGroup == stockDetail2.GoodsLGroup)
				 && (stockDetail1.GoodsLGroupName == stockDetail2.GoodsLGroupName)
				 && (stockDetail1.GoodsMGroup == stockDetail2.GoodsMGroup)
				 && (stockDetail1.GoodsMGroupName == stockDetail2.GoodsMGroupName)
				 && (stockDetail1.BLGroupCode == stockDetail2.BLGroupCode)
				 && (stockDetail1.BLGroupName == stockDetail2.BLGroupName)
				 && (stockDetail1.BLGoodsCode == stockDetail2.BLGoodsCode)
				 && (stockDetail1.BLGoodsFullName == stockDetail2.BLGoodsFullName)
				 && (stockDetail1.EnterpriseGanreCode == stockDetail2.EnterpriseGanreCode)
				 && (stockDetail1.EnterpriseGanreName == stockDetail2.EnterpriseGanreName)
				 && (stockDetail1.WarehouseCode == stockDetail2.WarehouseCode)
				 && (stockDetail1.WarehouseName == stockDetail2.WarehouseName)
				 && (stockDetail1.WarehouseShelfNo == stockDetail2.WarehouseShelfNo)
				 && (stockDetail1.StockOrderDivCd == stockDetail2.StockOrderDivCd)
				 && (stockDetail1.OpenPriceDiv == stockDetail2.OpenPriceDiv)
				 && (stockDetail1.GoodsRateRank == stockDetail2.GoodsRateRank)
				 && (stockDetail1.CustRateGrpCode == stockDetail2.CustRateGrpCode)
				 && (stockDetail1.SuppRateGrpCode == stockDetail2.SuppRateGrpCode)
				 && (stockDetail1.ListPriceTaxExcFl == stockDetail2.ListPriceTaxExcFl)
				 && (stockDetail1.ListPriceTaxIncFl == stockDetail2.ListPriceTaxIncFl)
				 && (stockDetail1.StockRate == stockDetail2.StockRate)
				 && (stockDetail1.RateSectStckUnPrc == stockDetail2.RateSectStckUnPrc)
				 && (stockDetail1.RateDivStckUnPrc == stockDetail2.RateDivStckUnPrc)
				 && (stockDetail1.UnPrcCalcCdStckUnPrc == stockDetail2.UnPrcCalcCdStckUnPrc)
				 && (stockDetail1.PriceCdStckUnPrc == stockDetail2.PriceCdStckUnPrc)
				 && (stockDetail1.StdUnPrcStckUnPrc == stockDetail2.StdUnPrcStckUnPrc)
				 && (stockDetail1.FracProcUnitStcUnPrc == stockDetail2.FracProcUnitStcUnPrc)
				 && (stockDetail1.FracProcStckUnPrc == stockDetail2.FracProcStckUnPrc)
				 && (stockDetail1.StockUnitPriceFl == stockDetail2.StockUnitPriceFl)
				 && (stockDetail1.StockUnitTaxPriceFl == stockDetail2.StockUnitTaxPriceFl)
				 && (stockDetail1.StockUnitChngDiv == stockDetail2.StockUnitChngDiv)
				 && (stockDetail1.BfStockUnitPriceFl == stockDetail2.BfStockUnitPriceFl)
				 && (stockDetail1.BfListPrice == stockDetail2.BfListPrice)
				 && (stockDetail1.RateBLGoodsCode == stockDetail2.RateBLGoodsCode)
				 && (stockDetail1.RateBLGoodsName == stockDetail2.RateBLGoodsName)
				 && (stockDetail1.RateGoodsRateGrpCd == stockDetail2.RateGoodsRateGrpCd)
				 && (stockDetail1.RateGoodsRateGrpNm == stockDetail2.RateGoodsRateGrpNm)
				 && (stockDetail1.RateBLGroupCode == stockDetail2.RateBLGroupCode)
				 && (stockDetail1.RateBLGroupName == stockDetail2.RateBLGroupName)
				 && (stockDetail1.StockCount == stockDetail2.StockCount)
				 && (stockDetail1.OrderCnt == stockDetail2.OrderCnt)
				 && (stockDetail1.OrderAdjustCnt == stockDetail2.OrderAdjustCnt)
				 && (stockDetail1.OrderRemainCnt == stockDetail2.OrderRemainCnt)
				 && (stockDetail1.RemainCntUpdDate == stockDetail2.RemainCntUpdDate)
				 && (stockDetail1.StockPriceTaxExc == stockDetail2.StockPriceTaxExc)
				 && (stockDetail1.StockPriceTaxInc == stockDetail2.StockPriceTaxInc)
				 && (stockDetail1.StockGoodsCd == stockDetail2.StockGoodsCd)
				 && (stockDetail1.StockPriceConsTax == stockDetail2.StockPriceConsTax)
				 && (stockDetail1.TaxationCode == stockDetail2.TaxationCode)
				 && (stockDetail1.StockDtiSlipNote1 == stockDetail2.StockDtiSlipNote1)
				 && (stockDetail1.SalesCustomerCode == stockDetail2.SalesCustomerCode)
				 && (stockDetail1.SalesCustomerSnm == stockDetail2.SalesCustomerSnm)
				 && (stockDetail1.SlipMemo1 == stockDetail2.SlipMemo1)
				 && (stockDetail1.SlipMemo2 == stockDetail2.SlipMemo2)
				 && (stockDetail1.SlipMemo3 == stockDetail2.SlipMemo3)
				 && (stockDetail1.InsideMemo1 == stockDetail2.InsideMemo1)
				 && (stockDetail1.InsideMemo2 == stockDetail2.InsideMemo2)
				 && (stockDetail1.InsideMemo3 == stockDetail2.InsideMemo3)
				 && (stockDetail1.SupplierCd == stockDetail2.SupplierCd)
				 && (stockDetail1.SupplierSnm == stockDetail2.SupplierSnm)
				 && (stockDetail1.AddresseeCode == stockDetail2.AddresseeCode)
				 && (stockDetail1.AddresseeName == stockDetail2.AddresseeName)
				 && (stockDetail1.DirectSendingCd == stockDetail2.DirectSendingCd)
				 && (stockDetail1.OrderNumber == stockDetail2.OrderNumber)
				 && (stockDetail1.WayToOrder == stockDetail2.WayToOrder)
				 && (stockDetail1.DeliGdsCmpltDueDate == stockDetail2.DeliGdsCmpltDueDate)
				 && (stockDetail1.ExpectDeliveryDate == stockDetail2.ExpectDeliveryDate)
				 && (stockDetail1.OrderDataCreateDiv == stockDetail2.OrderDataCreateDiv)
				 && (stockDetail1.OrderDataCreateDate == stockDetail2.OrderDataCreateDate)
				 && (stockDetail1.OrderFormIssuedDiv == stockDetail2.OrderFormIssuedDiv)
				 && (stockDetail1.DtlRelationGuid == stockDetail2.DtlRelationGuid)
				 && (stockDetail1.GoodsOfferDate == stockDetail2.GoodsOfferDate)
				 && (stockDetail1.PriceStartDate == stockDetail2.PriceStartDate)
				 && (stockDetail1.PriceOfferDate == stockDetail2.PriceOfferDate)
				 && (stockDetail1.EnterpriseName == stockDetail2.EnterpriseName)
				 && (stockDetail1.UpdEmployeeName == stockDetail2.UpdEmployeeName)
				 && (stockDetail1.BLGoodsName == stockDetail2.BLGoodsName));
		}
		/// <summary>
		/// �d�����׃f�[�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�StockDetail�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockDetail�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(StockDetail target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime != target.CreateDateTime)resList.Add("CreateDateTime");
			if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.FileHeaderGuid != target.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(this.UpdEmployeeCode != target.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(this.UpdAssemblyId1 != target.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(this.UpdAssemblyId2 != target.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(this.AcceptAnOrderNo != target.AcceptAnOrderNo)resList.Add("AcceptAnOrderNo");
			if(this.SupplierFormal != target.SupplierFormal)resList.Add("SupplierFormal");
			if(this.SupplierSlipNo != target.SupplierSlipNo)resList.Add("SupplierSlipNo");
			if(this.StockRowNo != target.StockRowNo)resList.Add("StockRowNo");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.SubSectionCode != target.SubSectionCode)resList.Add("SubSectionCode");
			if(this.CommonSeqNo != target.CommonSeqNo)resList.Add("CommonSeqNo");
			if(this.StockSlipDtlNum != target.StockSlipDtlNum)resList.Add("StockSlipDtlNum");
			if(this.SupplierFormalSrc != target.SupplierFormalSrc)resList.Add("SupplierFormalSrc");
			if(this.StockSlipDtlNumSrc != target.StockSlipDtlNumSrc)resList.Add("StockSlipDtlNumSrc");
			if(this.AcptAnOdrStatusSync != target.AcptAnOdrStatusSync)resList.Add("AcptAnOdrStatusSync");
			if(this.SalesSlipDtlNumSync != target.SalesSlipDtlNumSync)resList.Add("SalesSlipDtlNumSync");
			if(this.StockSlipCdDtl != target.StockSlipCdDtl)resList.Add("StockSlipCdDtl");
			if(this.StockInputCode != target.StockInputCode)resList.Add("StockInputCode");
			if(this.StockInputName != target.StockInputName)resList.Add("StockInputName");
			if(this.StockAgentCode != target.StockAgentCode)resList.Add("StockAgentCode");
			if(this.StockAgentName != target.StockAgentName)resList.Add("StockAgentName");
			if(this.GoodsKindCode != target.GoodsKindCode)resList.Add("GoodsKindCode");
			if(this.GoodsMakerCd != target.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(this.MakerName != target.MakerName)resList.Add("MakerName");
			if(this.MakerKanaName != target.MakerKanaName)resList.Add("MakerKanaName");
			if(this.CmpltMakerKanaName != target.CmpltMakerKanaName)resList.Add("CmpltMakerKanaName");
			if(this.GoodsNo != target.GoodsNo)resList.Add("GoodsNo");
			if(this.GoodsName != target.GoodsName)resList.Add("GoodsName");
			if(this.GoodsNameKana != target.GoodsNameKana)resList.Add("GoodsNameKana");
			if(this.GoodsLGroup != target.GoodsLGroup)resList.Add("GoodsLGroup");
			if(this.GoodsLGroupName != target.GoodsLGroupName)resList.Add("GoodsLGroupName");
			if(this.GoodsMGroup != target.GoodsMGroup)resList.Add("GoodsMGroup");
			if(this.GoodsMGroupName != target.GoodsMGroupName)resList.Add("GoodsMGroupName");
			if(this.BLGroupCode != target.BLGroupCode)resList.Add("BLGroupCode");
			if(this.BLGroupName != target.BLGroupName)resList.Add("BLGroupName");
			if(this.BLGoodsCode != target.BLGoodsCode)resList.Add("BLGoodsCode");
			if(this.BLGoodsFullName != target.BLGoodsFullName)resList.Add("BLGoodsFullName");
			if(this.EnterpriseGanreCode != target.EnterpriseGanreCode)resList.Add("EnterpriseGanreCode");
			if(this.EnterpriseGanreName != target.EnterpriseGanreName)resList.Add("EnterpriseGanreName");
			if(this.WarehouseCode != target.WarehouseCode)resList.Add("WarehouseCode");
			if(this.WarehouseName != target.WarehouseName)resList.Add("WarehouseName");
			if(this.WarehouseShelfNo != target.WarehouseShelfNo)resList.Add("WarehouseShelfNo");
			if(this.StockOrderDivCd != target.StockOrderDivCd)resList.Add("StockOrderDivCd");
			if(this.OpenPriceDiv != target.OpenPriceDiv)resList.Add("OpenPriceDiv");
			if(this.GoodsRateRank != target.GoodsRateRank)resList.Add("GoodsRateRank");
			if(this.CustRateGrpCode != target.CustRateGrpCode)resList.Add("CustRateGrpCode");
			if(this.SuppRateGrpCode != target.SuppRateGrpCode)resList.Add("SuppRateGrpCode");
			if(this.ListPriceTaxExcFl != target.ListPriceTaxExcFl)resList.Add("ListPriceTaxExcFl");
			if(this.ListPriceTaxIncFl != target.ListPriceTaxIncFl)resList.Add("ListPriceTaxIncFl");
			if(this.StockRate != target.StockRate)resList.Add("StockRate");
			if(this.RateSectStckUnPrc != target.RateSectStckUnPrc)resList.Add("RateSectStckUnPrc");
			if(this.RateDivStckUnPrc != target.RateDivStckUnPrc)resList.Add("RateDivStckUnPrc");
			if(this.UnPrcCalcCdStckUnPrc != target.UnPrcCalcCdStckUnPrc)resList.Add("UnPrcCalcCdStckUnPrc");
			if(this.PriceCdStckUnPrc != target.PriceCdStckUnPrc)resList.Add("PriceCdStckUnPrc");
			if(this.StdUnPrcStckUnPrc != target.StdUnPrcStckUnPrc)resList.Add("StdUnPrcStckUnPrc");
			if(this.FracProcUnitStcUnPrc != target.FracProcUnitStcUnPrc)resList.Add("FracProcUnitStcUnPrc");
			if(this.FracProcStckUnPrc != target.FracProcStckUnPrc)resList.Add("FracProcStckUnPrc");
			if(this.StockUnitPriceFl != target.StockUnitPriceFl)resList.Add("StockUnitPriceFl");
			if(this.StockUnitTaxPriceFl != target.StockUnitTaxPriceFl)resList.Add("StockUnitTaxPriceFl");
			if(this.StockUnitChngDiv != target.StockUnitChngDiv)resList.Add("StockUnitChngDiv");
			if(this.BfStockUnitPriceFl != target.BfStockUnitPriceFl)resList.Add("BfStockUnitPriceFl");
			if(this.BfListPrice != target.BfListPrice)resList.Add("BfListPrice");
			if(this.RateBLGoodsCode != target.RateBLGoodsCode)resList.Add("RateBLGoodsCode");
			if(this.RateBLGoodsName != target.RateBLGoodsName)resList.Add("RateBLGoodsName");
			if(this.RateGoodsRateGrpCd != target.RateGoodsRateGrpCd)resList.Add("RateGoodsRateGrpCd");
			if(this.RateGoodsRateGrpNm != target.RateGoodsRateGrpNm)resList.Add("RateGoodsRateGrpNm");
			if(this.RateBLGroupCode != target.RateBLGroupCode)resList.Add("RateBLGroupCode");
			if(this.RateBLGroupName != target.RateBLGroupName)resList.Add("RateBLGroupName");
			if(this.StockCount != target.StockCount)resList.Add("StockCount");
			if(this.OrderCnt != target.OrderCnt)resList.Add("OrderCnt");
			if(this.OrderAdjustCnt != target.OrderAdjustCnt)resList.Add("OrderAdjustCnt");
			if(this.OrderRemainCnt != target.OrderRemainCnt)resList.Add("OrderRemainCnt");
			if(this.RemainCntUpdDate != target.RemainCntUpdDate)resList.Add("RemainCntUpdDate");
			if(this.StockPriceTaxExc != target.StockPriceTaxExc)resList.Add("StockPriceTaxExc");
			if(this.StockPriceTaxInc != target.StockPriceTaxInc)resList.Add("StockPriceTaxInc");
			if(this.StockGoodsCd != target.StockGoodsCd)resList.Add("StockGoodsCd");
			if(this.StockPriceConsTax != target.StockPriceConsTax)resList.Add("StockPriceConsTax");
			if(this.TaxationCode != target.TaxationCode)resList.Add("TaxationCode");
			if(this.StockDtiSlipNote1 != target.StockDtiSlipNote1)resList.Add("StockDtiSlipNote1");
			if(this.SalesCustomerCode != target.SalesCustomerCode)resList.Add("SalesCustomerCode");
			if(this.SalesCustomerSnm != target.SalesCustomerSnm)resList.Add("SalesCustomerSnm");
			if(this.SlipMemo1 != target.SlipMemo1)resList.Add("SlipMemo1");
			if(this.SlipMemo2 != target.SlipMemo2)resList.Add("SlipMemo2");
			if(this.SlipMemo3 != target.SlipMemo3)resList.Add("SlipMemo3");
			if(this.InsideMemo1 != target.InsideMemo1)resList.Add("InsideMemo1");
			if(this.InsideMemo2 != target.InsideMemo2)resList.Add("InsideMemo2");
			if(this.InsideMemo3 != target.InsideMemo3)resList.Add("InsideMemo3");
			if(this.SupplierCd != target.SupplierCd)resList.Add("SupplierCd");
			if(this.SupplierSnm != target.SupplierSnm)resList.Add("SupplierSnm");
			if(this.AddresseeCode != target.AddresseeCode)resList.Add("AddresseeCode");
			if(this.AddresseeName != target.AddresseeName)resList.Add("AddresseeName");
			if(this.DirectSendingCd != target.DirectSendingCd)resList.Add("DirectSendingCd");
			if(this.OrderNumber != target.OrderNumber)resList.Add("OrderNumber");
			if(this.WayToOrder != target.WayToOrder)resList.Add("WayToOrder");
			if(this.DeliGdsCmpltDueDate != target.DeliGdsCmpltDueDate)resList.Add("DeliGdsCmpltDueDate");
			if(this.ExpectDeliveryDate != target.ExpectDeliveryDate)resList.Add("ExpectDeliveryDate");
			if(this.OrderDataCreateDiv != target.OrderDataCreateDiv)resList.Add("OrderDataCreateDiv");
			if(this.OrderDataCreateDate != target.OrderDataCreateDate)resList.Add("OrderDataCreateDate");
			if(this.OrderFormIssuedDiv != target.OrderFormIssuedDiv)resList.Add("OrderFormIssuedDiv");
			if(this.DtlRelationGuid != target.DtlRelationGuid)resList.Add("DtlRelationGuid");
			if(this.GoodsOfferDate != target.GoodsOfferDate)resList.Add("GoodsOfferDate");
			if(this.PriceStartDate != target.PriceStartDate)resList.Add("PriceStartDate");
			if(this.PriceOfferDate != target.PriceOfferDate)resList.Add("PriceOfferDate");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(this.BLGoodsName != target.BLGoodsName)resList.Add("BLGoodsName");

			return resList;
		}

		/// <summary>
		/// �d�����׃f�[�^��r����
		/// </summary>
		/// <param name="stockDetail1">��r����StockDetail�N���X�̃C���X�^���X</param>
		/// <param name="stockDetail2">��r����StockDetail�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockDetail�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(StockDetail stockDetail1, StockDetail stockDetail2)
		{
			ArrayList resList = new ArrayList();
			if(stockDetail1.CreateDateTime != stockDetail2.CreateDateTime)resList.Add("CreateDateTime");
			if(stockDetail1.UpdateDateTime != stockDetail2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(stockDetail1.EnterpriseCode != stockDetail2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(stockDetail1.FileHeaderGuid != stockDetail2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(stockDetail1.UpdEmployeeCode != stockDetail2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(stockDetail1.UpdAssemblyId1 != stockDetail2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(stockDetail1.UpdAssemblyId2 != stockDetail2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(stockDetail1.LogicalDeleteCode != stockDetail2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(stockDetail1.AcceptAnOrderNo != stockDetail2.AcceptAnOrderNo)resList.Add("AcceptAnOrderNo");
			if(stockDetail1.SupplierFormal != stockDetail2.SupplierFormal)resList.Add("SupplierFormal");
			if(stockDetail1.SupplierSlipNo != stockDetail2.SupplierSlipNo)resList.Add("SupplierSlipNo");
			if(stockDetail1.StockRowNo != stockDetail2.StockRowNo)resList.Add("StockRowNo");
			if(stockDetail1.SectionCode != stockDetail2.SectionCode)resList.Add("SectionCode");
			if(stockDetail1.SubSectionCode != stockDetail2.SubSectionCode)resList.Add("SubSectionCode");
			if(stockDetail1.CommonSeqNo != stockDetail2.CommonSeqNo)resList.Add("CommonSeqNo");
			if(stockDetail1.StockSlipDtlNum != stockDetail2.StockSlipDtlNum)resList.Add("StockSlipDtlNum");
			if(stockDetail1.SupplierFormalSrc != stockDetail2.SupplierFormalSrc)resList.Add("SupplierFormalSrc");
			if(stockDetail1.StockSlipDtlNumSrc != stockDetail2.StockSlipDtlNumSrc)resList.Add("StockSlipDtlNumSrc");
			if(stockDetail1.AcptAnOdrStatusSync != stockDetail2.AcptAnOdrStatusSync)resList.Add("AcptAnOdrStatusSync");
			if(stockDetail1.SalesSlipDtlNumSync != stockDetail2.SalesSlipDtlNumSync)resList.Add("SalesSlipDtlNumSync");
			if(stockDetail1.StockSlipCdDtl != stockDetail2.StockSlipCdDtl)resList.Add("StockSlipCdDtl");
			if(stockDetail1.StockInputCode != stockDetail2.StockInputCode)resList.Add("StockInputCode");
			if(stockDetail1.StockInputName != stockDetail2.StockInputName)resList.Add("StockInputName");
			if(stockDetail1.StockAgentCode != stockDetail2.StockAgentCode)resList.Add("StockAgentCode");
			if(stockDetail1.StockAgentName != stockDetail2.StockAgentName)resList.Add("StockAgentName");
			if(stockDetail1.GoodsKindCode != stockDetail2.GoodsKindCode)resList.Add("GoodsKindCode");
			if(stockDetail1.GoodsMakerCd != stockDetail2.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(stockDetail1.MakerName != stockDetail2.MakerName)resList.Add("MakerName");
			if(stockDetail1.MakerKanaName != stockDetail2.MakerKanaName)resList.Add("MakerKanaName");
			if(stockDetail1.CmpltMakerKanaName != stockDetail2.CmpltMakerKanaName)resList.Add("CmpltMakerKanaName");
			if(stockDetail1.GoodsNo != stockDetail2.GoodsNo)resList.Add("GoodsNo");
			if(stockDetail1.GoodsName != stockDetail2.GoodsName)resList.Add("GoodsName");
			if(stockDetail1.GoodsNameKana != stockDetail2.GoodsNameKana)resList.Add("GoodsNameKana");
			if(stockDetail1.GoodsLGroup != stockDetail2.GoodsLGroup)resList.Add("GoodsLGroup");
			if(stockDetail1.GoodsLGroupName != stockDetail2.GoodsLGroupName)resList.Add("GoodsLGroupName");
			if(stockDetail1.GoodsMGroup != stockDetail2.GoodsMGroup)resList.Add("GoodsMGroup");
			if(stockDetail1.GoodsMGroupName != stockDetail2.GoodsMGroupName)resList.Add("GoodsMGroupName");
			if(stockDetail1.BLGroupCode != stockDetail2.BLGroupCode)resList.Add("BLGroupCode");
			if(stockDetail1.BLGroupName != stockDetail2.BLGroupName)resList.Add("BLGroupName");
			if(stockDetail1.BLGoodsCode != stockDetail2.BLGoodsCode)resList.Add("BLGoodsCode");
			if(stockDetail1.BLGoodsFullName != stockDetail2.BLGoodsFullName)resList.Add("BLGoodsFullName");
			if(stockDetail1.EnterpriseGanreCode != stockDetail2.EnterpriseGanreCode)resList.Add("EnterpriseGanreCode");
			if(stockDetail1.EnterpriseGanreName != stockDetail2.EnterpriseGanreName)resList.Add("EnterpriseGanreName");
			if(stockDetail1.WarehouseCode != stockDetail2.WarehouseCode)resList.Add("WarehouseCode");
			if(stockDetail1.WarehouseName != stockDetail2.WarehouseName)resList.Add("WarehouseName");
			if(stockDetail1.WarehouseShelfNo != stockDetail2.WarehouseShelfNo)resList.Add("WarehouseShelfNo");
			if(stockDetail1.StockOrderDivCd != stockDetail2.StockOrderDivCd)resList.Add("StockOrderDivCd");
			if(stockDetail1.OpenPriceDiv != stockDetail2.OpenPriceDiv)resList.Add("OpenPriceDiv");
			if(stockDetail1.GoodsRateRank != stockDetail2.GoodsRateRank)resList.Add("GoodsRateRank");
			if(stockDetail1.CustRateGrpCode != stockDetail2.CustRateGrpCode)resList.Add("CustRateGrpCode");
			if(stockDetail1.SuppRateGrpCode != stockDetail2.SuppRateGrpCode)resList.Add("SuppRateGrpCode");
			if(stockDetail1.ListPriceTaxExcFl != stockDetail2.ListPriceTaxExcFl)resList.Add("ListPriceTaxExcFl");
			if(stockDetail1.ListPriceTaxIncFl != stockDetail2.ListPriceTaxIncFl)resList.Add("ListPriceTaxIncFl");
			if(stockDetail1.StockRate != stockDetail2.StockRate)resList.Add("StockRate");
			if(stockDetail1.RateSectStckUnPrc != stockDetail2.RateSectStckUnPrc)resList.Add("RateSectStckUnPrc");
			if(stockDetail1.RateDivStckUnPrc != stockDetail2.RateDivStckUnPrc)resList.Add("RateDivStckUnPrc");
			if(stockDetail1.UnPrcCalcCdStckUnPrc != stockDetail2.UnPrcCalcCdStckUnPrc)resList.Add("UnPrcCalcCdStckUnPrc");
			if(stockDetail1.PriceCdStckUnPrc != stockDetail2.PriceCdStckUnPrc)resList.Add("PriceCdStckUnPrc");
			if(stockDetail1.StdUnPrcStckUnPrc != stockDetail2.StdUnPrcStckUnPrc)resList.Add("StdUnPrcStckUnPrc");
			if(stockDetail1.FracProcUnitStcUnPrc != stockDetail2.FracProcUnitStcUnPrc)resList.Add("FracProcUnitStcUnPrc");
			if(stockDetail1.FracProcStckUnPrc != stockDetail2.FracProcStckUnPrc)resList.Add("FracProcStckUnPrc");
			if(stockDetail1.StockUnitPriceFl != stockDetail2.StockUnitPriceFl)resList.Add("StockUnitPriceFl");
			if(stockDetail1.StockUnitTaxPriceFl != stockDetail2.StockUnitTaxPriceFl)resList.Add("StockUnitTaxPriceFl");
			if(stockDetail1.StockUnitChngDiv != stockDetail2.StockUnitChngDiv)resList.Add("StockUnitChngDiv");
			if(stockDetail1.BfStockUnitPriceFl != stockDetail2.BfStockUnitPriceFl)resList.Add("BfStockUnitPriceFl");
			if(stockDetail1.BfListPrice != stockDetail2.BfListPrice)resList.Add("BfListPrice");
			if(stockDetail1.RateBLGoodsCode != stockDetail2.RateBLGoodsCode)resList.Add("RateBLGoodsCode");
			if(stockDetail1.RateBLGoodsName != stockDetail2.RateBLGoodsName)resList.Add("RateBLGoodsName");
			if(stockDetail1.RateGoodsRateGrpCd != stockDetail2.RateGoodsRateGrpCd)resList.Add("RateGoodsRateGrpCd");
			if(stockDetail1.RateGoodsRateGrpNm != stockDetail2.RateGoodsRateGrpNm)resList.Add("RateGoodsRateGrpNm");
			if(stockDetail1.RateBLGroupCode != stockDetail2.RateBLGroupCode)resList.Add("RateBLGroupCode");
			if(stockDetail1.RateBLGroupName != stockDetail2.RateBLGroupName)resList.Add("RateBLGroupName");
			if(stockDetail1.StockCount != stockDetail2.StockCount)resList.Add("StockCount");
			if(stockDetail1.OrderCnt != stockDetail2.OrderCnt)resList.Add("OrderCnt");
			if(stockDetail1.OrderAdjustCnt != stockDetail2.OrderAdjustCnt)resList.Add("OrderAdjustCnt");
			if(stockDetail1.OrderRemainCnt != stockDetail2.OrderRemainCnt)resList.Add("OrderRemainCnt");
			if(stockDetail1.RemainCntUpdDate != stockDetail2.RemainCntUpdDate)resList.Add("RemainCntUpdDate");
			if(stockDetail1.StockPriceTaxExc != stockDetail2.StockPriceTaxExc)resList.Add("StockPriceTaxExc");
			if(stockDetail1.StockPriceTaxInc != stockDetail2.StockPriceTaxInc)resList.Add("StockPriceTaxInc");
			if(stockDetail1.StockGoodsCd != stockDetail2.StockGoodsCd)resList.Add("StockGoodsCd");
			if(stockDetail1.StockPriceConsTax != stockDetail2.StockPriceConsTax)resList.Add("StockPriceConsTax");
			if(stockDetail1.TaxationCode != stockDetail2.TaxationCode)resList.Add("TaxationCode");
			if(stockDetail1.StockDtiSlipNote1 != stockDetail2.StockDtiSlipNote1)resList.Add("StockDtiSlipNote1");
			if(stockDetail1.SalesCustomerCode != stockDetail2.SalesCustomerCode)resList.Add("SalesCustomerCode");
			if(stockDetail1.SalesCustomerSnm != stockDetail2.SalesCustomerSnm)resList.Add("SalesCustomerSnm");
			if(stockDetail1.SlipMemo1 != stockDetail2.SlipMemo1)resList.Add("SlipMemo1");
			if(stockDetail1.SlipMemo2 != stockDetail2.SlipMemo2)resList.Add("SlipMemo2");
			if(stockDetail1.SlipMemo3 != stockDetail2.SlipMemo3)resList.Add("SlipMemo3");
			if(stockDetail1.InsideMemo1 != stockDetail2.InsideMemo1)resList.Add("InsideMemo1");
			if(stockDetail1.InsideMemo2 != stockDetail2.InsideMemo2)resList.Add("InsideMemo2");
			if(stockDetail1.InsideMemo3 != stockDetail2.InsideMemo3)resList.Add("InsideMemo3");
			if(stockDetail1.SupplierCd != stockDetail2.SupplierCd)resList.Add("SupplierCd");
			if(stockDetail1.SupplierSnm != stockDetail2.SupplierSnm)resList.Add("SupplierSnm");
			if(stockDetail1.AddresseeCode != stockDetail2.AddresseeCode)resList.Add("AddresseeCode");
			if(stockDetail1.AddresseeName != stockDetail2.AddresseeName)resList.Add("AddresseeName");
			if(stockDetail1.DirectSendingCd != stockDetail2.DirectSendingCd)resList.Add("DirectSendingCd");
			if(stockDetail1.OrderNumber != stockDetail2.OrderNumber)resList.Add("OrderNumber");
			if(stockDetail1.WayToOrder != stockDetail2.WayToOrder)resList.Add("WayToOrder");
			if(stockDetail1.DeliGdsCmpltDueDate != stockDetail2.DeliGdsCmpltDueDate)resList.Add("DeliGdsCmpltDueDate");
			if(stockDetail1.ExpectDeliveryDate != stockDetail2.ExpectDeliveryDate)resList.Add("ExpectDeliveryDate");
			if(stockDetail1.OrderDataCreateDiv != stockDetail2.OrderDataCreateDiv)resList.Add("OrderDataCreateDiv");
			if(stockDetail1.OrderDataCreateDate != stockDetail2.OrderDataCreateDate)resList.Add("OrderDataCreateDate");
			if(stockDetail1.OrderFormIssuedDiv != stockDetail2.OrderFormIssuedDiv)resList.Add("OrderFormIssuedDiv");
			if(stockDetail1.DtlRelationGuid != stockDetail2.DtlRelationGuid)resList.Add("DtlRelationGuid");
			if(stockDetail1.GoodsOfferDate != stockDetail2.GoodsOfferDate)resList.Add("GoodsOfferDate");
			if(stockDetail1.PriceStartDate != stockDetail2.PriceStartDate)resList.Add("PriceStartDate");
			if(stockDetail1.PriceOfferDate != stockDetail2.PriceOfferDate)resList.Add("PriceOfferDate");
			if(stockDetail1.EnterpriseName != stockDetail2.EnterpriseName)resList.Add("EnterpriseName");
			if(stockDetail1.UpdEmployeeName != stockDetail2.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(stockDetail1.BLGoodsName != stockDetail2.BLGoodsName)resList.Add("BLGoodsName");

			return resList;
		}

        #region �d�����׃f�[�^��r�p�̃N���X
        /// <summary>
        /// �d�����׃f�[�^��r�N���X(�d���`�[�ԍ�(����)�A�d�����׍s�ԍ�(����))
        /// </summary>
        /// <remarks></remarks>
        public class StockDetailComparer : Comparer<StockDetail>
        {
            public override int Compare(StockDetail x, StockDetail y)
            {
                int result = x.SupplierSlipNo.CompareTo(y.SupplierSlipNo);
                if (result != 0) return result;

                result = x.StockRowNo.CompareTo(y.StockRowNo);
                return result;
            }
        }
        #endregion
    }
    #endregion

}
