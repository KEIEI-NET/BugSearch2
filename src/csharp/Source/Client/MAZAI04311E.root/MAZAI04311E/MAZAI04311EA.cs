using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   StockAcPayHisSearchRet
	/// <summary>
	///                      �݌Ɏ󕥗��𒊏o���ʃN���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   �݌Ɏ󕥗��𒊏o���ʃN���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/07/22  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class StockAcPayHisSearchRet
	{
		/// <summary>���_�R�[�h</summary>
		private string _sectionCode = "";

		/// <summary>���_�K�C�h����</summary>
		private string _sectionGuideNm = "";

		/// <summary>�q�ɃR�[�h</summary>
		private string _warehouseCode = "";

		/// <summary>�q�ɖ���</summary>
		private string _warehouseName = "";

		/// <summary>���i���[�J�[�R�[�h</summary>
		private Int32 _goodsMakerCd;

		/// <summary>���[�J�[����</summary>
		private string _makerName = "";

		/// <summary>���i�ԍ�</summary>
		private string _goodsNo = "";

		/// <summary>���i����</summary>
		private string _goodsName = "";

		/// <summary>���o�ד�</summary>
		private DateTime _ioGoodsDay;

		/// <summary>�󕥌��`�[�ԍ�</summary>
		/// <remarks>�u�󕥌��`�[�v�̓`�[�ԍ����i�[</remarks>
		private string _acPaySlipNum = "";

		/// <summary>�󕥌��`�[�敪</summary>
		/// <remarks>10:�d��,11:����,12:��v��,20:����,21:���v��,22:�o��,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,50:�I��(���̕ύX 11:���->���ׁ@22:�ϑ�->�o�ׁj</remarks>
		private Int32 _acPaySlipCd;

		/// <summary>�󕥌�����敪</summary>
		/// <remarks>10:�ʏ�`�[,11:�ԕi,12:�l��,20:�ԓ`,21:�폜,22:����30:�݌ɐ�����,31:��������,32:���Ԓ���,33:�s�Ǖi,34:���o,35:����,36:�ꊇ�o�^,40:�ߕs���X�V,90:���</remarks>
		private Int32 _acPayTransCd;

		/// <summary>�ړ��拒�_�R�[�h</summary>
		/// <remarks>�ړ��i�o�ׁj�̏ꍇ�� ������@�@�ړ��i���ׁj�̏ꍇ�͎����</remarks>
		private string _afSectionCode = "";

		/// <summary>�ړ��拒�_�K�C�h����</summary>
		/// <remarks>����</remarks>
		private string _afSectionGuideNm = "";

		/// <summary>�ړ���q�ɃR�[�h</summary>
		/// <remarks>����</remarks>
		private string _afEnterWarehCode = "";

		/// <summary>�ړ���q�ɖ���</summary>
		/// <remarks>����</remarks>
		private string _afEnterWarehName = "";

		/// <summary>�ړ���I��</summary>
		/// <remarks>����</remarks>
		private string _afShelfNo = "";

		/// <summary>�o�א��i���v��j</summary>
		/// <remarks>�ݏo�A�o�ׂƓ���</remarks>
		private Double _nonAddUpShipmCnt;

		/// <summary>���א��i���v��j</summary>
		/// <remarks>����</remarks>
		private Double _nonAddUpArrGdsCnt;

		/// <summary>�艿�i�Ŕ��C�����j</summary>
		/// <remarks>�Ŕ���</remarks>
		private Double _listPriceTaxExcFl;

		/// <summary>�d���P���i�Ŕ��C�����j</summary>
		/// <remarks>����̏ꍇ�����P��</remarks>
		private Double _stockUnitPriceFl;

		/// <summary>�v����t</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _addUpADate;

		/// <summary>�󕥌��s�ԍ�</summary>
		/// <remarks>�u�󕥌��`�[�v�̓`�[�s�ԍ����i�[</remarks>
		private Int32 _acPaySlipRowNo;

		/// <summary>���͋��_�R�[�h</summary>
		/// <remarks>���͂��s�������_����</remarks>
		private string _inputSectionCd = "";

		/// <summary>���͋��_�K�C�h����</summary>
		private string _inputSectionGuidNm = "";

		/// <summary>���͒S���҃R�[�h</summary>
		private string _inputAgenCd = "";

		/// <summary>���͒S���Җ���</summary>
		private string _inputAgenNm = "";

		/// <summary>�ړ����</summary>
		/// <remarks>0:�ړ��ΏۊO�A1:���o�׏�ԁA2:�ړ����A9:���׍�</remarks>
		private Int32 _moveStatus;

		/// <summary>�����`�[�ԍ�</summary>
		/// <remarks>���Ӑ�`�[�ԍ��A�d����`�[�ԍ�</remarks>
		private string _custSlipNo = "";

		/// <summary>���גʔ�</summary>
		private Int64 _slipDtlNum;

		/// <summary>�󕥔��l</summary>
		/// <remarks>�󕥂��������i�[</remarks>
		private string _acPayNote = "";

		/// <summary>BL���i�R�[�h</summary>
		private Int32 _bLGoodsCode;

		/// <summary>BL���i�R�[�h���́i�S�p�j</summary>
		private string _bLGoodsFullName = "";

		/// <summary>�ړ������_�R�[�h</summary>
		/// <remarks>�ړ��i�o�ׁj�̏ꍇ�� �����@�@�ړ��i���ׁj�̏ꍇ�͑�����</remarks>
		private string _bfSectionCode = "";

		/// <summary>�ړ������_�K�C�h����</summary>
		/// <remarks>����</remarks>
		private string _bfSectionGuideNm = "";

		/// <summary>�ړ����q�ɃR�[�h</summary>
		/// <remarks>����</remarks>
		private string _bfEnterWarehCode = "";

		/// <summary>�ړ����q�ɖ���</summary>
		/// <remarks>����</remarks>
		private string _bfEnterWarehName = "";

		/// <summary>�ړ����I��</summary>
		/// <remarks>����</remarks>
		private string _bfShelfNo = "";

		/// <summary>���Ӑ�R�[�h</summary>
		/// <remarks>���㎞�̓��Ӑ�R�[�h���Z�b�g</remarks>
		private Int32 _customerCode;

		/// <summary>���Ӑ旪��</summary>
		private string _customerSnm = "";

		/// <summary>�d����R�[�h</summary>
		/// <remarks>�d�����̎d����R�[�h���Z�b�g</remarks>
		private Int32 _supplierCd;

		/// <summary>�d���旪��</summary>
		private string _supplierSnm = "";

		/// <summary>�I�[�v�����i�敪</summary>
		/// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
		private Int32 _openPriceDiv;

		/// <summary>�d�����z</summary>
		/// <remarks>����̏ꍇ�������z</remarks>
		private Int64 _stockPrice;

		/// <summary>����P���i�Ŕ��C�����j</summary>
		private Double _salesUnPrcTaxExcFl;

		/// <summary>������z</summary>
		/// <remarks>�Ŕ���</remarks>
		private Int64 _salesMoney;

		/// <summary>�d���݌ɐ�</summary>
		/// <remarks>���א�(���v��j�A�o�א�(���v��j���܂܂Ȃ��݌ɐ��i���Ѝ݌Ɂj</remarks>
		private Double _supplierStock;

		/// <summary>�󒍐�</summary>
		private Double _acpOdrCount;

		/// <summary>������</summary>
		private Double _salesOrderCount;

		/// <summary>�ړ����d���݌ɐ�</summary>
		/// <remarks>�݌Ɉړ���A���ړ��悪���ׂ���O�܂ł̊ԂɗL���l������B</remarks>
		private Double _movingSupliStock;

		/// <summary>�o�׉\��</summary>
		/// <remarks>�o�׉\�����d���݌ɐ��{���א�(���v��j�|�o�א��i���v��j�|�󒍐� �| �ړ����d���݌ɐ�</remarks>
		private Double _shipmentPosCnt;

		/// <summary>���݌ɐ���</summary>
		/// <remarks>���݌ɐ��ʁ��d���݌ɐ��{���א��i���v��j�|�o�א��i���v��j�|�ړ����d���݌ɐ�</remarks>
		private Double _presentStockCnt;

		/// <summary>���א�</summary>
		/// <remarks>�d�����́A�݌Ɉړ��i���ׁj�A�݌ɒ����A�I�������ɃZ�b�g</remarks>
		private Double _arrivalCnt;

		/// <summary>�o�א�</summary>
		/// <remarks>������́A�݌Ɉړ��i�o�ׁj���ɃZ�b�g</remarks>
		private Double _shipmentCnt;

		/// <summary>�󕥗����쐬����</summary>
		/// <remarks>DateTime:���x��100�i�m�b</remarks>
		private DateTime _acPayHistDateTime;

		/// <summary>�I��</summary>
		/// <remarks>�o�ׁA���ׂ���������I��</remarks>
		private string _shelfNo = "";

		/// <summary>BL���i�R�[�h����</summary>
		private string _bLGoodsName = "";


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

		/// public propaty name  :  SectionGuideNm
		/// <summary>���_�K�C�h���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SectionGuideNm
		{
			get{return _sectionGuideNm;}
			set{_sectionGuideNm = value;}
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

		/// public propaty name  :  GoodsMakerCd
		/// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
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

		/// public propaty name  :  IoGoodsDay
		/// <summary>���o�ד��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�ד��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime IoGoodsDay
		{
			get{return _ioGoodsDay;}
			set{_ioGoodsDay = value;}
		}

		/// public propaty name  :  IoGoodsDayJpFormal
		/// <summary>���o�ד� �a��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�ד� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string IoGoodsDayJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _ioGoodsDay);}
			set{}
		}

		/// public propaty name  :  IoGoodsDayJpInFormal
		/// <summary>���o�ד� �a��(��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�ד� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string IoGoodsDayJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _ioGoodsDay);}
			set{}
		}

		/// public propaty name  :  IoGoodsDayAdFormal
		/// <summary>���o�ד� ����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�ד� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string IoGoodsDayAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _ioGoodsDay);}
			set{}
		}

		/// public propaty name  :  IoGoodsDayAdInFormal
		/// <summary>���o�ד� ����(��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�ד� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string IoGoodsDayAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _ioGoodsDay);}
			set{}
		}

		/// public propaty name  :  AcPaySlipNum
		/// <summary>�󕥌��`�[�ԍ��v���p�e�B</summary>
		/// <value>�u�󕥌��`�[�v�̓`�[�ԍ����i�[</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󕥌��`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AcPaySlipNum
		{
			get{return _acPaySlipNum;}
			set{_acPaySlipNum = value;}
		}

		/// public propaty name  :  AcPaySlipCd
		/// <summary>�󕥌��`�[�敪�v���p�e�B</summary>
		/// <value>10:�d��,11:����,12:��v��,20:����,21:���v��,22:�o��,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,50:�I��(���̕ύX 11:���->���ׁ@22:�ϑ�->�o�ׁj</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󕥌��`�[�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AcPaySlipCd
		{
			get{return _acPaySlipCd;}
			set{_acPaySlipCd = value;}
		}

		/// public propaty name  :  AcPayTransCd
		/// <summary>�󕥌�����敪�v���p�e�B</summary>
		/// <value>10:�ʏ�`�[,11:�ԕi,12:�l��,20:�ԓ`,21:�폜,22:����30:�݌ɐ�����,31:��������,32:���Ԓ���,33:�s�Ǖi,34:���o,35:����,36:�ꊇ�o�^,40:�ߕs���X�V,90:���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󕥌�����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AcPayTransCd
		{
			get{return _acPayTransCd;}
			set{_acPayTransCd = value;}
		}

		/// public propaty name  :  AfSectionCode
		/// <summary>�ړ��拒�_�R�[�h�v���p�e�B</summary>
		/// <value>�ړ��i�o�ׁj�̏ꍇ�� ������@�@�ړ��i���ׁj�̏ꍇ�͎����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ړ��拒�_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AfSectionCode
		{
			get{return _afSectionCode;}
			set{_afSectionCode = value;}
		}

		/// public propaty name  :  AfSectionGuideNm
		/// <summary>�ړ��拒�_�K�C�h���̃v���p�e�B</summary>
		/// <value>����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ړ��拒�_�K�C�h���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AfSectionGuideNm
		{
			get{return _afSectionGuideNm;}
			set{_afSectionGuideNm = value;}
		}

		/// public propaty name  :  AfEnterWarehCode
		/// <summary>�ړ���q�ɃR�[�h�v���p�e�B</summary>
		/// <value>����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ړ���q�ɃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AfEnterWarehCode
		{
			get{return _afEnterWarehCode;}
			set{_afEnterWarehCode = value;}
		}

		/// public propaty name  :  AfEnterWarehName
		/// <summary>�ړ���q�ɖ��̃v���p�e�B</summary>
		/// <value>����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ړ���q�ɖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AfEnterWarehName
		{
			get{return _afEnterWarehName;}
			set{_afEnterWarehName = value;}
		}

		/// public propaty name  :  AfShelfNo
		/// <summary>�ړ���I�ԃv���p�e�B</summary>
		/// <value>����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ړ���I�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AfShelfNo
		{
			get{return _afShelfNo;}
			set{_afShelfNo = value;}
		}

		/// public propaty name  :  NonAddUpShipmCnt
		/// <summary>�o�א��i���v��j�v���p�e�B</summary>
		/// <value>�ݏo�A�o�ׂƓ���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�א��i���v��j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double NonAddUpShipmCnt
		{
			get{return _nonAddUpShipmCnt;}
			set{_nonAddUpShipmCnt = value;}
		}

		/// public propaty name  :  NonAddUpArrGdsCnt
		/// <summary>���א��i���v��j�v���p�e�B</summary>
		/// <value>����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���א��i���v��j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double NonAddUpArrGdsCnt
		{
			get{return _nonAddUpArrGdsCnt;}
			set{_nonAddUpArrGdsCnt = value;}
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

		/// public propaty name  :  StockUnitPriceFl
		/// <summary>�d���P���i�Ŕ��C�����j�v���p�e�B</summary>
		/// <value>����̏ꍇ�����P��</value>
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

		/// public propaty name  :  AddUpADate
		/// <summary>�v����t�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v����t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime AddUpADate
		{
			get{return _addUpADate;}
			set{_addUpADate = value;}
		}

		/// public propaty name  :  AddUpADateJpFormal
		/// <summary>�v����t �a��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v����t �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddUpADateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _addUpADate);}
			set{}
		}

		/// public propaty name  :  AddUpADateJpInFormal
		/// <summary>�v����t �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v����t �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddUpADateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _addUpADate);}
			set{}
		}

		/// public propaty name  :  AddUpADateAdFormal
		/// <summary>�v����t ����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v����t ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddUpADateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _addUpADate);}
			set{}
		}

		/// public propaty name  :  AddUpADateAdInFormal
		/// <summary>�v����t ����(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v����t ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddUpADateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _addUpADate);}
			set{}
		}

		/// public propaty name  :  AcPaySlipRowNo
		/// <summary>�󕥌��s�ԍ��v���p�e�B</summary>
		/// <value>�u�󕥌��`�[�v�̓`�[�s�ԍ����i�[</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󕥌��s�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AcPaySlipRowNo
		{
			get{return _acPaySlipRowNo;}
			set{_acPaySlipRowNo = value;}
		}

		/// public propaty name  :  InputSectionCd
		/// <summary>���͋��_�R�[�h�v���p�e�B</summary>
		/// <value>���͂��s�������_����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���͋��_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InputSectionCd
		{
			get{return _inputSectionCd;}
			set{_inputSectionCd = value;}
		}

		/// public propaty name  :  InputSectionGuidNm
		/// <summary>���͋��_�K�C�h���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���͋��_�K�C�h���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InputSectionGuidNm
		{
			get{return _inputSectionGuidNm;}
			set{_inputSectionGuidNm = value;}
		}

		/// public propaty name  :  InputAgenCd
		/// <summary>���͒S���҃R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���͒S���҃R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InputAgenCd
		{
			get{return _inputAgenCd;}
			set{_inputAgenCd = value;}
		}

		/// public propaty name  :  InputAgenNm
		/// <summary>���͒S���Җ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���͒S���Җ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InputAgenNm
		{
			get{return _inputAgenNm;}
			set{_inputAgenNm = value;}
		}

		/// public propaty name  :  MoveStatus
		/// <summary>�ړ���ԃv���p�e�B</summary>
		/// <value>0:�ړ��ΏۊO�A1:���o�׏�ԁA2:�ړ����A9:���׍�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ړ���ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MoveStatus
		{
			get{return _moveStatus;}
			set{_moveStatus = value;}
		}

		/// public propaty name  :  CustSlipNo
		/// <summary>�����`�[�ԍ��v���p�e�B</summary>
		/// <value>���Ӑ�`�[�ԍ��A�d����`�[�ԍ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CustSlipNo
		{
			get{return _custSlipNo;}
			set{_custSlipNo = value;}
		}

		/// public propaty name  :  SlipDtlNum
		/// <summary>���גʔԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���גʔԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SlipDtlNum
		{
			get{return _slipDtlNum;}
			set{_slipDtlNum = value;}
		}

		/// public propaty name  :  AcPayNote
		/// <summary>�󕥔��l�v���p�e�B</summary>
		/// <value>�󕥂��������i�[</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󕥔��l�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AcPayNote
		{
			get{return _acPayNote;}
			set{_acPayNote = value;}
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

		/// public propaty name  :  BfSectionCode
		/// <summary>�ړ������_�R�[�h�v���p�e�B</summary>
		/// <value>�ړ��i�o�ׁj�̏ꍇ�� �����@�@�ړ��i���ׁj�̏ꍇ�͑�����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ړ������_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BfSectionCode
		{
			get{return _bfSectionCode;}
			set{_bfSectionCode = value;}
		}

		/// public propaty name  :  BfSectionGuideNm
		/// <summary>�ړ������_�K�C�h���̃v���p�e�B</summary>
		/// <value>����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ړ������_�K�C�h���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BfSectionGuideNm
		{
			get{return _bfSectionGuideNm;}
			set{_bfSectionGuideNm = value;}
		}

		/// public propaty name  :  BfEnterWarehCode
		/// <summary>�ړ����q�ɃR�[�h�v���p�e�B</summary>
		/// <value>����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ړ����q�ɃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BfEnterWarehCode
		{
			get{return _bfEnterWarehCode;}
			set{_bfEnterWarehCode = value;}
		}

		/// public propaty name  :  BfEnterWarehName
		/// <summary>�ړ����q�ɖ��̃v���p�e�B</summary>
		/// <value>����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ړ����q�ɖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BfEnterWarehName
		{
			get{return _bfEnterWarehName;}
			set{_bfEnterWarehName = value;}
		}

		/// public propaty name  :  BfShelfNo
		/// <summary>�ړ����I�ԃv���p�e�B</summary>
		/// <value>����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ړ����I�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BfShelfNo
		{
			get{return _bfShelfNo;}
			set{_bfShelfNo = value;}
		}

		/// public propaty name  :  CustomerCode
		/// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
		/// <value>���㎞�̓��Ӑ�R�[�h���Z�b�g</value>
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

		/// public propaty name  :  SupplierCd
		/// <summary>�d����R�[�h�v���p�e�B</summary>
		/// <value>�d�����̎d����R�[�h���Z�b�g</value>
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

		/// public propaty name  :  StockPrice
		/// <summary>�d�����z�v���p�e�B</summary>
		/// <value>����̏ꍇ�������z</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StockPrice
		{
			get{return _stockPrice;}
			set{_stockPrice = value;}
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

		/// public propaty name  :  SalesMoney
		/// <summary>������z�v���p�e�B</summary>
		/// <value>�Ŕ���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesMoney
		{
			get{return _salesMoney;}
			set{_salesMoney = value;}
		}

		/// public propaty name  :  SupplierStock
		/// <summary>�d���݌ɐ��v���p�e�B</summary>
		/// <value>���א�(���v��j�A�o�א�(���v��j���܂܂Ȃ��݌ɐ��i���Ѝ݌Ɂj</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���݌ɐ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double SupplierStock
		{
			get{return _supplierStock;}
			set{_supplierStock = value;}
		}

		/// public propaty name  :  AcpOdrCount
		/// <summary>�󒍐��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󒍐��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double AcpOdrCount
		{
			get{return _acpOdrCount;}
			set{_acpOdrCount = value;}
		}

		/// public propaty name  :  SalesOrderCount
		/// <summary>�������v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double SalesOrderCount
		{
			get{return _salesOrderCount;}
			set{_salesOrderCount = value;}
		}

		/// public propaty name  :  MovingSupliStock
		/// <summary>�ړ����d���݌ɐ��v���p�e�B</summary>
		/// <value>�݌Ɉړ���A���ړ��悪���ׂ���O�܂ł̊ԂɗL���l������B</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ړ����d���݌ɐ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double MovingSupliStock
		{
			get{return _movingSupliStock;}
			set{_movingSupliStock = value;}
		}

		/// public propaty name  :  ShipmentPosCnt
		/// <summary>�o�׉\���v���p�e�B</summary>
		/// <value>�o�׉\�����d���݌ɐ��{���א�(���v��j�|�o�א��i���v��j�|�󒍐� �| �ړ����d���݌ɐ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�׉\���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double ShipmentPosCnt
		{
			get{return _shipmentPosCnt;}
			set{_shipmentPosCnt = value;}
		}

		/// public propaty name  :  PresentStockCnt
		/// <summary>���݌ɐ��ʃv���p�e�B</summary>
		/// <value>���݌ɐ��ʁ��d���݌ɐ��{���א��i���v��j�|�o�א��i���v��j�|�ړ����d���݌ɐ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���݌ɐ��ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double PresentStockCnt
		{
			get{return _presentStockCnt;}
			set{_presentStockCnt = value;}
		}

		/// public propaty name  :  ArrivalCnt
		/// <summary>���א��v���p�e�B</summary>
		/// <value>�d�����́A�݌Ɉړ��i���ׁj�A�݌ɒ����A�I�������ɃZ�b�g</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���א��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double ArrivalCnt
		{
			get{return _arrivalCnt;}
			set{_arrivalCnt = value;}
		}

		/// public propaty name  :  ShipmentCnt
		/// <summary>�o�א��v���p�e�B</summary>
		/// <value>������́A�݌Ɉړ��i�o�ׁj���ɃZ�b�g</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�א��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double ShipmentCnt
		{
			get{return _shipmentCnt;}
			set{_shipmentCnt = value;}
		}

		/// public propaty name  :  AcPayHistDateTime
		/// <summary>�󕥗����쐬�����v���p�e�B</summary>
		/// <value>DateTime:���x��100�i�m�b</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󕥗����쐬�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime AcPayHistDateTime
		{
			get{return _acPayHistDateTime;}
			set{_acPayHistDateTime = value;}
		}

		/// public propaty name  :  AcPayHistDateTimeJpFormal
		/// <summary>�󕥗����쐬���� �a��v���p�e�B</summary>
		/// <value>DateTime:���x��100�i�m�b</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󕥗����쐬���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AcPayHistDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _acPayHistDateTime);}
			set{}
		}

		/// public propaty name  :  AcPayHistDateTimeJpInFormal
		/// <summary>�󕥗����쐬���� �a��(��)�v���p�e�B</summary>
		/// <value>DateTime:���x��100�i�m�b</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󕥗����쐬���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AcPayHistDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _acPayHistDateTime);}
			set{}
		}

		/// public propaty name  :  AcPayHistDateTimeAdFormal
		/// <summary>�󕥗����쐬���� ����v���p�e�B</summary>
		/// <value>DateTime:���x��100�i�m�b</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󕥗����쐬���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AcPayHistDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _acPayHistDateTime);}
			set{}
		}

		/// public propaty name  :  AcPayHistDateTimeAdInFormal
		/// <summary>�󕥗����쐬���� ����(��)�v���p�e�B</summary>
		/// <value>DateTime:���x��100�i�m�b</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󕥗����쐬���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AcPayHistDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _acPayHistDateTime);}
			set{}
		}

		/// public propaty name  :  ShelfNo
		/// <summary>�I�ԃv���p�e�B</summary>
		/// <value>�o�ׁA���ׂ���������I��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ShelfNo
		{
			get{return _shelfNo;}
			set{_shelfNo = value;}
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
		/// �݌Ɏ󕥗��𒊏o���ʃN���X�R���X�g���N�^
		/// </summary>
		/// <returns>StockAcPayHisSearchRet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockAcPayHisSearchRet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockAcPayHisSearchRet()
		{
		}

		/// <summary>
		/// �݌Ɏ󕥗��𒊏o���ʃN���X�R���X�g���N�^
		/// </summary>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="sectionGuideNm">���_�K�C�h����</param>
		/// <param name="warehouseCode">�q�ɃR�[�h</param>
		/// <param name="warehouseName">�q�ɖ���</param>
		/// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
		/// <param name="makerName">���[�J�[����</param>
		/// <param name="goodsNo">���i�ԍ�</param>
		/// <param name="goodsName">���i����</param>
		/// <param name="ioGoodsDay">���o�ד�</param>
		/// <param name="acPaySlipNum">�󕥌��`�[�ԍ�(�u�󕥌��`�[�v�̓`�[�ԍ����i�[)</param>
		/// <param name="acPaySlipCd">�󕥌��`�[�敪(10:�d��,11:����,12:��v��,20:����,21:���v��,22:�o��,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,50:�I��(���̕ύX 11:���->���ׁ@22:�ϑ�->�o�ׁj)</param>
		/// <param name="acPayTransCd">�󕥌�����敪(10:�ʏ�`�[,11:�ԕi,12:�l��,20:�ԓ`,21:�폜,22:����30:�݌ɐ�����,31:��������,32:���Ԓ���,33:�s�Ǖi,34:���o,35:����,36:�ꊇ�o�^,40:�ߕs���X�V,90:���)</param>
		/// <param name="afSectionCode">�ړ��拒�_�R�[�h(�ړ��i�o�ׁj�̏ꍇ�� ������@�@�ړ��i���ׁj�̏ꍇ�͎����)</param>
		/// <param name="afSectionGuideNm">�ړ��拒�_�K�C�h����(����)</param>
		/// <param name="afEnterWarehCode">�ړ���q�ɃR�[�h(����)</param>
		/// <param name="afEnterWarehName">�ړ���q�ɖ���(����)</param>
		/// <param name="afShelfNo">�ړ���I��(����)</param>
		/// <param name="nonAddUpShipmCnt">�o�א��i���v��j(�ݏo�A�o�ׂƓ���)</param>
		/// <param name="nonAddUpArrGdsCnt">���א��i���v��j(����)</param>
		/// <param name="listPriceTaxExcFl">�艿�i�Ŕ��C�����j(�Ŕ���)</param>
		/// <param name="stockUnitPriceFl">�d���P���i�Ŕ��C�����j(����̏ꍇ�����P��)</param>
		/// <param name="addUpADate">�v����t(YYYYMMDD)</param>
		/// <param name="acPaySlipRowNo">�󕥌��s�ԍ�(�u�󕥌��`�[�v�̓`�[�s�ԍ����i�[)</param>
		/// <param name="inputSectionCd">���͋��_�R�[�h(���͂��s�������_����)</param>
		/// <param name="inputSectionGuidNm">���͋��_�K�C�h����</param>
		/// <param name="inputAgenCd">���͒S���҃R�[�h</param>
		/// <param name="inputAgenNm">���͒S���Җ���</param>
		/// <param name="moveStatus">�ړ����(0:�ړ��ΏۊO�A1:���o�׏�ԁA2:�ړ����A9:���׍�)</param>
		/// <param name="custSlipNo">�����`�[�ԍ�(���Ӑ�`�[�ԍ��A�d����`�[�ԍ�)</param>
		/// <param name="slipDtlNum">���גʔ�</param>
		/// <param name="acPayNote">�󕥔��l(�󕥂��������i�[)</param>
		/// <param name="bLGoodsCode">BL���i�R�[�h</param>
		/// <param name="bLGoodsFullName">BL���i�R�[�h���́i�S�p�j</param>
		/// <param name="bfSectionCode">�ړ������_�R�[�h(�ړ��i�o�ׁj�̏ꍇ�� �����@�@�ړ��i���ׁj�̏ꍇ�͑�����)</param>
		/// <param name="bfSectionGuideNm">�ړ������_�K�C�h����(����)</param>
		/// <param name="bfEnterWarehCode">�ړ����q�ɃR�[�h(����)</param>
		/// <param name="bfEnterWarehName">�ړ����q�ɖ���(����)</param>
		/// <param name="bfShelfNo">�ړ����I��(����)</param>
		/// <param name="customerCode">���Ӑ�R�[�h(���㎞�̓��Ӑ�R�[�h���Z�b�g)</param>
		/// <param name="customerSnm">���Ӑ旪��</param>
		/// <param name="supplierCd">�d����R�[�h(�d�����̎d����R�[�h���Z�b�g)</param>
		/// <param name="supplierSnm">�d���旪��</param>
		/// <param name="openPriceDiv">�I�[�v�����i�敪(0:�ʏ�^1:�I�[�v�����i)</param>
		/// <param name="stockPrice">�d�����z(����̏ꍇ�������z)</param>
		/// <param name="salesUnPrcTaxExcFl">����P���i�Ŕ��C�����j</param>
		/// <param name="salesMoney">������z(�Ŕ���)</param>
		/// <param name="supplierStock">�d���݌ɐ�(���א�(���v��j�A�o�א�(���v��j���܂܂Ȃ��݌ɐ��i���Ѝ݌Ɂj)</param>
		/// <param name="acpOdrCount">�󒍐�</param>
		/// <param name="salesOrderCount">������</param>
		/// <param name="movingSupliStock">�ړ����d���݌ɐ�(�݌Ɉړ���A���ړ��悪���ׂ���O�܂ł̊ԂɗL���l������B)</param>
		/// <param name="shipmentPosCnt">�o�׉\��(�o�׉\�����d���݌ɐ��{���א�(���v��j�|�o�א��i���v��j�|�󒍐� �| �ړ����d���݌ɐ�)</param>
		/// <param name="presentStockCnt">���݌ɐ���(���݌ɐ��ʁ��d���݌ɐ��{���א��i���v��j�|�o�א��i���v��j�|�ړ����d���݌ɐ�)</param>
		/// <param name="arrivalCnt">���א�(�d�����́A�݌Ɉړ��i���ׁj�A�݌ɒ����A�I�������ɃZ�b�g)</param>
		/// <param name="shipmentCnt">�o�א�(������́A�݌Ɉړ��i�o�ׁj���ɃZ�b�g)</param>
		/// <param name="acPayHistDateTime">�󕥗����쐬����(DateTime:���x��100�i�m�b)</param>
		/// <param name="shelfNo">�I��(�o�ׁA���ׂ���������I��)</param>
		/// <param name="bLGoodsName">BL���i�R�[�h����</param>
		/// <returns>StockAcPayHisSearchRet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockAcPayHisSearchRet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockAcPayHisSearchRet(string sectionCode,string sectionGuideNm,string warehouseCode,string warehouseName,Int32 goodsMakerCd,string makerName,string goodsNo,string goodsName,DateTime ioGoodsDay,string acPaySlipNum,Int32 acPaySlipCd,Int32 acPayTransCd,string afSectionCode,string afSectionGuideNm,string afEnterWarehCode,string afEnterWarehName,string afShelfNo,Double nonAddUpShipmCnt,Double nonAddUpArrGdsCnt,Double listPriceTaxExcFl,Double stockUnitPriceFl,DateTime addUpADate,Int32 acPaySlipRowNo,string inputSectionCd,string inputSectionGuidNm,string inputAgenCd,string inputAgenNm,Int32 moveStatus,string custSlipNo,Int64 slipDtlNum,string acPayNote,Int32 bLGoodsCode,string bLGoodsFullName,string bfSectionCode,string bfSectionGuideNm,string bfEnterWarehCode,string bfEnterWarehName,string bfShelfNo,Int32 customerCode,string customerSnm,Int32 supplierCd,string supplierSnm,Int32 openPriceDiv,Int64 stockPrice,Double salesUnPrcTaxExcFl,Int64 salesMoney,Double supplierStock,Double acpOdrCount,Double salesOrderCount,Double movingSupliStock,Double shipmentPosCnt,Double presentStockCnt,Double arrivalCnt,Double shipmentCnt,DateTime acPayHistDateTime,string shelfNo,string bLGoodsName)
		{
			this._sectionCode = sectionCode;
			this._sectionGuideNm = sectionGuideNm;
			this._warehouseCode = warehouseCode;
			this._warehouseName = warehouseName;
			this._goodsMakerCd = goodsMakerCd;
			this._makerName = makerName;
			this._goodsNo = goodsNo;
			this._goodsName = goodsName;
			this.IoGoodsDay = ioGoodsDay;
			this._acPaySlipNum = acPaySlipNum;
			this._acPaySlipCd = acPaySlipCd;
			this._acPayTransCd = acPayTransCd;
			this._afSectionCode = afSectionCode;
			this._afSectionGuideNm = afSectionGuideNm;
			this._afEnterWarehCode = afEnterWarehCode;
			this._afEnterWarehName = afEnterWarehName;
			this._afShelfNo = afShelfNo;
			this._nonAddUpShipmCnt = nonAddUpShipmCnt;
			this._nonAddUpArrGdsCnt = nonAddUpArrGdsCnt;
			this._listPriceTaxExcFl = listPriceTaxExcFl;
			this._stockUnitPriceFl = stockUnitPriceFl;
			this.AddUpADate = addUpADate;
			this._acPaySlipRowNo = acPaySlipRowNo;
			this._inputSectionCd = inputSectionCd;
			this._inputSectionGuidNm = inputSectionGuidNm;
			this._inputAgenCd = inputAgenCd;
			this._inputAgenNm = inputAgenNm;
			this._moveStatus = moveStatus;
			this._custSlipNo = custSlipNo;
			this._slipDtlNum = slipDtlNum;
			this._acPayNote = acPayNote;
			this._bLGoodsCode = bLGoodsCode;
			this._bLGoodsFullName = bLGoodsFullName;
			this._bfSectionCode = bfSectionCode;
			this._bfSectionGuideNm = bfSectionGuideNm;
			this._bfEnterWarehCode = bfEnterWarehCode;
			this._bfEnterWarehName = bfEnterWarehName;
			this._bfShelfNo = bfShelfNo;
			this._customerCode = customerCode;
			this._customerSnm = customerSnm;
			this._supplierCd = supplierCd;
			this._supplierSnm = supplierSnm;
			this._openPriceDiv = openPriceDiv;
			this._stockPrice = stockPrice;
			this._salesUnPrcTaxExcFl = salesUnPrcTaxExcFl;
			this._salesMoney = salesMoney;
			this._supplierStock = supplierStock;
			this._acpOdrCount = acpOdrCount;
			this._salesOrderCount = salesOrderCount;
			this._movingSupliStock = movingSupliStock;
			this._shipmentPosCnt = shipmentPosCnt;
			this._presentStockCnt = presentStockCnt;
			this._arrivalCnt = arrivalCnt;
			this._shipmentCnt = shipmentCnt;
			this.AcPayHistDateTime = acPayHistDateTime;
			this._shelfNo = shelfNo;
			this._bLGoodsName = bLGoodsName;

		}

		/// <summary>
		/// �݌Ɏ󕥗��𒊏o���ʃN���X��������
		/// </summary>
		/// <returns>StockAcPayHisSearchRet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����StockAcPayHisSearchRet�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockAcPayHisSearchRet Clone()
		{
			return new StockAcPayHisSearchRet(this._sectionCode,this._sectionGuideNm,this._warehouseCode,this._warehouseName,this._goodsMakerCd,this._makerName,this._goodsNo,this._goodsName,this._ioGoodsDay,this._acPaySlipNum,this._acPaySlipCd,this._acPayTransCd,this._afSectionCode,this._afSectionGuideNm,this._afEnterWarehCode,this._afEnterWarehName,this._afShelfNo,this._nonAddUpShipmCnt,this._nonAddUpArrGdsCnt,this._listPriceTaxExcFl,this._stockUnitPriceFl,this._addUpADate,this._acPaySlipRowNo,this._inputSectionCd,this._inputSectionGuidNm,this._inputAgenCd,this._inputAgenNm,this._moveStatus,this._custSlipNo,this._slipDtlNum,this._acPayNote,this._bLGoodsCode,this._bLGoodsFullName,this._bfSectionCode,this._bfSectionGuideNm,this._bfEnterWarehCode,this._bfEnterWarehName,this._bfShelfNo,this._customerCode,this._customerSnm,this._supplierCd,this._supplierSnm,this._openPriceDiv,this._stockPrice,this._salesUnPrcTaxExcFl,this._salesMoney,this._supplierStock,this._acpOdrCount,this._salesOrderCount,this._movingSupliStock,this._shipmentPosCnt,this._presentStockCnt,this._arrivalCnt,this._shipmentCnt,this._acPayHistDateTime,this._shelfNo,this._bLGoodsName);
		}

		/// <summary>
		/// �݌Ɏ󕥗��𒊏o���ʃN���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�StockAcPayHisSearchRet�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockAcPayHisSearchRet�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(StockAcPayHisSearchRet target)
		{
			return ((this.SectionCode == target.SectionCode)
				 && (this.SectionGuideNm == target.SectionGuideNm)
				 && (this.WarehouseCode == target.WarehouseCode)
				 && (this.WarehouseName == target.WarehouseName)
				 && (this.GoodsMakerCd == target.GoodsMakerCd)
				 && (this.MakerName == target.MakerName)
				 && (this.GoodsNo == target.GoodsNo)
				 && (this.GoodsName == target.GoodsName)
				 && (this.IoGoodsDay == target.IoGoodsDay)
				 && (this.AcPaySlipNum == target.AcPaySlipNum)
				 && (this.AcPaySlipCd == target.AcPaySlipCd)
				 && (this.AcPayTransCd == target.AcPayTransCd)
				 && (this.AfSectionCode == target.AfSectionCode)
				 && (this.AfSectionGuideNm == target.AfSectionGuideNm)
				 && (this.AfEnterWarehCode == target.AfEnterWarehCode)
				 && (this.AfEnterWarehName == target.AfEnterWarehName)
				 && (this.AfShelfNo == target.AfShelfNo)
				 && (this.NonAddUpShipmCnt == target.NonAddUpShipmCnt)
				 && (this.NonAddUpArrGdsCnt == target.NonAddUpArrGdsCnt)
				 && (this.ListPriceTaxExcFl == target.ListPriceTaxExcFl)
				 && (this.StockUnitPriceFl == target.StockUnitPriceFl)
				 && (this.AddUpADate == target.AddUpADate)
				 && (this.AcPaySlipRowNo == target.AcPaySlipRowNo)
				 && (this.InputSectionCd == target.InputSectionCd)
				 && (this.InputSectionGuidNm == target.InputSectionGuidNm)
				 && (this.InputAgenCd == target.InputAgenCd)
				 && (this.InputAgenNm == target.InputAgenNm)
				 && (this.MoveStatus == target.MoveStatus)
				 && (this.CustSlipNo == target.CustSlipNo)
				 && (this.SlipDtlNum == target.SlipDtlNum)
				 && (this.AcPayNote == target.AcPayNote)
				 && (this.BLGoodsCode == target.BLGoodsCode)
				 && (this.BLGoodsFullName == target.BLGoodsFullName)
				 && (this.BfSectionCode == target.BfSectionCode)
				 && (this.BfSectionGuideNm == target.BfSectionGuideNm)
				 && (this.BfEnterWarehCode == target.BfEnterWarehCode)
				 && (this.BfEnterWarehName == target.BfEnterWarehName)
				 && (this.BfShelfNo == target.BfShelfNo)
				 && (this.CustomerCode == target.CustomerCode)
				 && (this.CustomerSnm == target.CustomerSnm)
				 && (this.SupplierCd == target.SupplierCd)
				 && (this.SupplierSnm == target.SupplierSnm)
				 && (this.OpenPriceDiv == target.OpenPriceDiv)
				 && (this.StockPrice == target.StockPrice)
				 && (this.SalesUnPrcTaxExcFl == target.SalesUnPrcTaxExcFl)
				 && (this.SalesMoney == target.SalesMoney)
				 && (this.SupplierStock == target.SupplierStock)
				 && (this.AcpOdrCount == target.AcpOdrCount)
				 && (this.SalesOrderCount == target.SalesOrderCount)
				 && (this.MovingSupliStock == target.MovingSupliStock)
				 && (this.ShipmentPosCnt == target.ShipmentPosCnt)
				 && (this.PresentStockCnt == target.PresentStockCnt)
				 && (this.ArrivalCnt == target.ArrivalCnt)
				 && (this.ShipmentCnt == target.ShipmentCnt)
				 && (this.AcPayHistDateTime == target.AcPayHistDateTime)
				 && (this.ShelfNo == target.ShelfNo)
				 && (this.BLGoodsName == target.BLGoodsName));
		}

		/// <summary>
		/// �݌Ɏ󕥗��𒊏o���ʃN���X��r����
		/// </summary>
		/// <param name="stockAcPayHisSearchRet1">
		///                    ��r����StockAcPayHisSearchRet�N���X�̃C���X�^���X
		/// </param>
		/// <param name="stockAcPayHisSearchRet2">��r����StockAcPayHisSearchRet�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockAcPayHisSearchRet�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(StockAcPayHisSearchRet stockAcPayHisSearchRet1, StockAcPayHisSearchRet stockAcPayHisSearchRet2)
		{
			return ((stockAcPayHisSearchRet1.SectionCode == stockAcPayHisSearchRet2.SectionCode)
				 && (stockAcPayHisSearchRet1.SectionGuideNm == stockAcPayHisSearchRet2.SectionGuideNm)
				 && (stockAcPayHisSearchRet1.WarehouseCode == stockAcPayHisSearchRet2.WarehouseCode)
				 && (stockAcPayHisSearchRet1.WarehouseName == stockAcPayHisSearchRet2.WarehouseName)
				 && (stockAcPayHisSearchRet1.GoodsMakerCd == stockAcPayHisSearchRet2.GoodsMakerCd)
				 && (stockAcPayHisSearchRet1.MakerName == stockAcPayHisSearchRet2.MakerName)
				 && (stockAcPayHisSearchRet1.GoodsNo == stockAcPayHisSearchRet2.GoodsNo)
				 && (stockAcPayHisSearchRet1.GoodsName == stockAcPayHisSearchRet2.GoodsName)
				 && (stockAcPayHisSearchRet1.IoGoodsDay == stockAcPayHisSearchRet2.IoGoodsDay)
				 && (stockAcPayHisSearchRet1.AcPaySlipNum == stockAcPayHisSearchRet2.AcPaySlipNum)
				 && (stockAcPayHisSearchRet1.AcPaySlipCd == stockAcPayHisSearchRet2.AcPaySlipCd)
				 && (stockAcPayHisSearchRet1.AcPayTransCd == stockAcPayHisSearchRet2.AcPayTransCd)
				 && (stockAcPayHisSearchRet1.AfSectionCode == stockAcPayHisSearchRet2.AfSectionCode)
				 && (stockAcPayHisSearchRet1.AfSectionGuideNm == stockAcPayHisSearchRet2.AfSectionGuideNm)
				 && (stockAcPayHisSearchRet1.AfEnterWarehCode == stockAcPayHisSearchRet2.AfEnterWarehCode)
				 && (stockAcPayHisSearchRet1.AfEnterWarehName == stockAcPayHisSearchRet2.AfEnterWarehName)
				 && (stockAcPayHisSearchRet1.AfShelfNo == stockAcPayHisSearchRet2.AfShelfNo)
				 && (stockAcPayHisSearchRet1.NonAddUpShipmCnt == stockAcPayHisSearchRet2.NonAddUpShipmCnt)
				 && (stockAcPayHisSearchRet1.NonAddUpArrGdsCnt == stockAcPayHisSearchRet2.NonAddUpArrGdsCnt)
				 && (stockAcPayHisSearchRet1.ListPriceTaxExcFl == stockAcPayHisSearchRet2.ListPriceTaxExcFl)
				 && (stockAcPayHisSearchRet1.StockUnitPriceFl == stockAcPayHisSearchRet2.StockUnitPriceFl)
				 && (stockAcPayHisSearchRet1.AddUpADate == stockAcPayHisSearchRet2.AddUpADate)
				 && (stockAcPayHisSearchRet1.AcPaySlipRowNo == stockAcPayHisSearchRet2.AcPaySlipRowNo)
				 && (stockAcPayHisSearchRet1.InputSectionCd == stockAcPayHisSearchRet2.InputSectionCd)
				 && (stockAcPayHisSearchRet1.InputSectionGuidNm == stockAcPayHisSearchRet2.InputSectionGuidNm)
				 && (stockAcPayHisSearchRet1.InputAgenCd == stockAcPayHisSearchRet2.InputAgenCd)
				 && (stockAcPayHisSearchRet1.InputAgenNm == stockAcPayHisSearchRet2.InputAgenNm)
				 && (stockAcPayHisSearchRet1.MoveStatus == stockAcPayHisSearchRet2.MoveStatus)
				 && (stockAcPayHisSearchRet1.CustSlipNo == stockAcPayHisSearchRet2.CustSlipNo)
				 && (stockAcPayHisSearchRet1.SlipDtlNum == stockAcPayHisSearchRet2.SlipDtlNum)
				 && (stockAcPayHisSearchRet1.AcPayNote == stockAcPayHisSearchRet2.AcPayNote)
				 && (stockAcPayHisSearchRet1.BLGoodsCode == stockAcPayHisSearchRet2.BLGoodsCode)
				 && (stockAcPayHisSearchRet1.BLGoodsFullName == stockAcPayHisSearchRet2.BLGoodsFullName)
				 && (stockAcPayHisSearchRet1.BfSectionCode == stockAcPayHisSearchRet2.BfSectionCode)
				 && (stockAcPayHisSearchRet1.BfSectionGuideNm == stockAcPayHisSearchRet2.BfSectionGuideNm)
				 && (stockAcPayHisSearchRet1.BfEnterWarehCode == stockAcPayHisSearchRet2.BfEnterWarehCode)
				 && (stockAcPayHisSearchRet1.BfEnterWarehName == stockAcPayHisSearchRet2.BfEnterWarehName)
				 && (stockAcPayHisSearchRet1.BfShelfNo == stockAcPayHisSearchRet2.BfShelfNo)
				 && (stockAcPayHisSearchRet1.CustomerCode == stockAcPayHisSearchRet2.CustomerCode)
				 && (stockAcPayHisSearchRet1.CustomerSnm == stockAcPayHisSearchRet2.CustomerSnm)
				 && (stockAcPayHisSearchRet1.SupplierCd == stockAcPayHisSearchRet2.SupplierCd)
				 && (stockAcPayHisSearchRet1.SupplierSnm == stockAcPayHisSearchRet2.SupplierSnm)
				 && (stockAcPayHisSearchRet1.OpenPriceDiv == stockAcPayHisSearchRet2.OpenPriceDiv)
				 && (stockAcPayHisSearchRet1.StockPrice == stockAcPayHisSearchRet2.StockPrice)
				 && (stockAcPayHisSearchRet1.SalesUnPrcTaxExcFl == stockAcPayHisSearchRet2.SalesUnPrcTaxExcFl)
				 && (stockAcPayHisSearchRet1.SalesMoney == stockAcPayHisSearchRet2.SalesMoney)
				 && (stockAcPayHisSearchRet1.SupplierStock == stockAcPayHisSearchRet2.SupplierStock)
				 && (stockAcPayHisSearchRet1.AcpOdrCount == stockAcPayHisSearchRet2.AcpOdrCount)
				 && (stockAcPayHisSearchRet1.SalesOrderCount == stockAcPayHisSearchRet2.SalesOrderCount)
				 && (stockAcPayHisSearchRet1.MovingSupliStock == stockAcPayHisSearchRet2.MovingSupliStock)
				 && (stockAcPayHisSearchRet1.ShipmentPosCnt == stockAcPayHisSearchRet2.ShipmentPosCnt)
				 && (stockAcPayHisSearchRet1.PresentStockCnt == stockAcPayHisSearchRet2.PresentStockCnt)
				 && (stockAcPayHisSearchRet1.ArrivalCnt == stockAcPayHisSearchRet2.ArrivalCnt)
				 && (stockAcPayHisSearchRet1.ShipmentCnt == stockAcPayHisSearchRet2.ShipmentCnt)
				 && (stockAcPayHisSearchRet1.AcPayHistDateTime == stockAcPayHisSearchRet2.AcPayHistDateTime)
				 && (stockAcPayHisSearchRet1.ShelfNo == stockAcPayHisSearchRet2.ShelfNo)
				 && (stockAcPayHisSearchRet1.BLGoodsName == stockAcPayHisSearchRet2.BLGoodsName));
		}
		/// <summary>
		/// �݌Ɏ󕥗��𒊏o���ʃN���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�StockAcPayHisSearchRet�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockAcPayHisSearchRet�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(StockAcPayHisSearchRet target)
		{
			ArrayList resList = new ArrayList();
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.SectionGuideNm != target.SectionGuideNm)resList.Add("SectionGuideNm");
			if(this.WarehouseCode != target.WarehouseCode)resList.Add("WarehouseCode");
			if(this.WarehouseName != target.WarehouseName)resList.Add("WarehouseName");
			if(this.GoodsMakerCd != target.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(this.MakerName != target.MakerName)resList.Add("MakerName");
			if(this.GoodsNo != target.GoodsNo)resList.Add("GoodsNo");
			if(this.GoodsName != target.GoodsName)resList.Add("GoodsName");
			if(this.IoGoodsDay != target.IoGoodsDay)resList.Add("IoGoodsDay");
			if(this.AcPaySlipNum != target.AcPaySlipNum)resList.Add("AcPaySlipNum");
			if(this.AcPaySlipCd != target.AcPaySlipCd)resList.Add("AcPaySlipCd");
			if(this.AcPayTransCd != target.AcPayTransCd)resList.Add("AcPayTransCd");
			if(this.AfSectionCode != target.AfSectionCode)resList.Add("AfSectionCode");
			if(this.AfSectionGuideNm != target.AfSectionGuideNm)resList.Add("AfSectionGuideNm");
			if(this.AfEnterWarehCode != target.AfEnterWarehCode)resList.Add("AfEnterWarehCode");
			if(this.AfEnterWarehName != target.AfEnterWarehName)resList.Add("AfEnterWarehName");
			if(this.AfShelfNo != target.AfShelfNo)resList.Add("AfShelfNo");
			if(this.NonAddUpShipmCnt != target.NonAddUpShipmCnt)resList.Add("NonAddUpShipmCnt");
			if(this.NonAddUpArrGdsCnt != target.NonAddUpArrGdsCnt)resList.Add("NonAddUpArrGdsCnt");
			if(this.ListPriceTaxExcFl != target.ListPriceTaxExcFl)resList.Add("ListPriceTaxExcFl");
			if(this.StockUnitPriceFl != target.StockUnitPriceFl)resList.Add("StockUnitPriceFl");
			if(this.AddUpADate != target.AddUpADate)resList.Add("AddUpADate");
			if(this.AcPaySlipRowNo != target.AcPaySlipRowNo)resList.Add("AcPaySlipRowNo");
			if(this.InputSectionCd != target.InputSectionCd)resList.Add("InputSectionCd");
			if(this.InputSectionGuidNm != target.InputSectionGuidNm)resList.Add("InputSectionGuidNm");
			if(this.InputAgenCd != target.InputAgenCd)resList.Add("InputAgenCd");
			if(this.InputAgenNm != target.InputAgenNm)resList.Add("InputAgenNm");
			if(this.MoveStatus != target.MoveStatus)resList.Add("MoveStatus");
			if(this.CustSlipNo != target.CustSlipNo)resList.Add("CustSlipNo");
			if(this.SlipDtlNum != target.SlipDtlNum)resList.Add("SlipDtlNum");
			if(this.AcPayNote != target.AcPayNote)resList.Add("AcPayNote");
			if(this.BLGoodsCode != target.BLGoodsCode)resList.Add("BLGoodsCode");
			if(this.BLGoodsFullName != target.BLGoodsFullName)resList.Add("BLGoodsFullName");
			if(this.BfSectionCode != target.BfSectionCode)resList.Add("BfSectionCode");
			if(this.BfSectionGuideNm != target.BfSectionGuideNm)resList.Add("BfSectionGuideNm");
			if(this.BfEnterWarehCode != target.BfEnterWarehCode)resList.Add("BfEnterWarehCode");
			if(this.BfEnterWarehName != target.BfEnterWarehName)resList.Add("BfEnterWarehName");
			if(this.BfShelfNo != target.BfShelfNo)resList.Add("BfShelfNo");
			if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
			if(this.CustomerSnm != target.CustomerSnm)resList.Add("CustomerSnm");
			if(this.SupplierCd != target.SupplierCd)resList.Add("SupplierCd");
			if(this.SupplierSnm != target.SupplierSnm)resList.Add("SupplierSnm");
			if(this.OpenPriceDiv != target.OpenPriceDiv)resList.Add("OpenPriceDiv");
			if(this.StockPrice != target.StockPrice)resList.Add("StockPrice");
			if(this.SalesUnPrcTaxExcFl != target.SalesUnPrcTaxExcFl)resList.Add("SalesUnPrcTaxExcFl");
			if(this.SalesMoney != target.SalesMoney)resList.Add("SalesMoney");
			if(this.SupplierStock != target.SupplierStock)resList.Add("SupplierStock");
			if(this.AcpOdrCount != target.AcpOdrCount)resList.Add("AcpOdrCount");
			if(this.SalesOrderCount != target.SalesOrderCount)resList.Add("SalesOrderCount");
			if(this.MovingSupliStock != target.MovingSupliStock)resList.Add("MovingSupliStock");
			if(this.ShipmentPosCnt != target.ShipmentPosCnt)resList.Add("ShipmentPosCnt");
			if(this.PresentStockCnt != target.PresentStockCnt)resList.Add("PresentStockCnt");
			if(this.ArrivalCnt != target.ArrivalCnt)resList.Add("ArrivalCnt");
			if(this.ShipmentCnt != target.ShipmentCnt)resList.Add("ShipmentCnt");
			if(this.AcPayHistDateTime != target.AcPayHistDateTime)resList.Add("AcPayHistDateTime");
			if(this.ShelfNo != target.ShelfNo)resList.Add("ShelfNo");
			if(this.BLGoodsName != target.BLGoodsName)resList.Add("BLGoodsName");

			return resList;
		}

		/// <summary>
		/// �݌Ɏ󕥗��𒊏o���ʃN���X��r����
		/// </summary>
		/// <param name="stockAcPayHisSearchRet1">��r����StockAcPayHisSearchRet�N���X�̃C���X�^���X</param>
		/// <param name="stockAcPayHisSearchRet2">��r����StockAcPayHisSearchRet�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockAcPayHisSearchRet�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(StockAcPayHisSearchRet stockAcPayHisSearchRet1, StockAcPayHisSearchRet stockAcPayHisSearchRet2)
		{
			ArrayList resList = new ArrayList();
			if(stockAcPayHisSearchRet1.SectionCode != stockAcPayHisSearchRet2.SectionCode)resList.Add("SectionCode");
			if(stockAcPayHisSearchRet1.SectionGuideNm != stockAcPayHisSearchRet2.SectionGuideNm)resList.Add("SectionGuideNm");
			if(stockAcPayHisSearchRet1.WarehouseCode != stockAcPayHisSearchRet2.WarehouseCode)resList.Add("WarehouseCode");
			if(stockAcPayHisSearchRet1.WarehouseName != stockAcPayHisSearchRet2.WarehouseName)resList.Add("WarehouseName");
			if(stockAcPayHisSearchRet1.GoodsMakerCd != stockAcPayHisSearchRet2.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(stockAcPayHisSearchRet1.MakerName != stockAcPayHisSearchRet2.MakerName)resList.Add("MakerName");
			if(stockAcPayHisSearchRet1.GoodsNo != stockAcPayHisSearchRet2.GoodsNo)resList.Add("GoodsNo");
			if(stockAcPayHisSearchRet1.GoodsName != stockAcPayHisSearchRet2.GoodsName)resList.Add("GoodsName");
			if(stockAcPayHisSearchRet1.IoGoodsDay != stockAcPayHisSearchRet2.IoGoodsDay)resList.Add("IoGoodsDay");
			if(stockAcPayHisSearchRet1.AcPaySlipNum != stockAcPayHisSearchRet2.AcPaySlipNum)resList.Add("AcPaySlipNum");
			if(stockAcPayHisSearchRet1.AcPaySlipCd != stockAcPayHisSearchRet2.AcPaySlipCd)resList.Add("AcPaySlipCd");
			if(stockAcPayHisSearchRet1.AcPayTransCd != stockAcPayHisSearchRet2.AcPayTransCd)resList.Add("AcPayTransCd");
			if(stockAcPayHisSearchRet1.AfSectionCode != stockAcPayHisSearchRet2.AfSectionCode)resList.Add("AfSectionCode");
			if(stockAcPayHisSearchRet1.AfSectionGuideNm != stockAcPayHisSearchRet2.AfSectionGuideNm)resList.Add("AfSectionGuideNm");
			if(stockAcPayHisSearchRet1.AfEnterWarehCode != stockAcPayHisSearchRet2.AfEnterWarehCode)resList.Add("AfEnterWarehCode");
			if(stockAcPayHisSearchRet1.AfEnterWarehName != stockAcPayHisSearchRet2.AfEnterWarehName)resList.Add("AfEnterWarehName");
			if(stockAcPayHisSearchRet1.AfShelfNo != stockAcPayHisSearchRet2.AfShelfNo)resList.Add("AfShelfNo");
			if(stockAcPayHisSearchRet1.NonAddUpShipmCnt != stockAcPayHisSearchRet2.NonAddUpShipmCnt)resList.Add("NonAddUpShipmCnt");
			if(stockAcPayHisSearchRet1.NonAddUpArrGdsCnt != stockAcPayHisSearchRet2.NonAddUpArrGdsCnt)resList.Add("NonAddUpArrGdsCnt");
			if(stockAcPayHisSearchRet1.ListPriceTaxExcFl != stockAcPayHisSearchRet2.ListPriceTaxExcFl)resList.Add("ListPriceTaxExcFl");
			if(stockAcPayHisSearchRet1.StockUnitPriceFl != stockAcPayHisSearchRet2.StockUnitPriceFl)resList.Add("StockUnitPriceFl");
			if(stockAcPayHisSearchRet1.AddUpADate != stockAcPayHisSearchRet2.AddUpADate)resList.Add("AddUpADate");
			if(stockAcPayHisSearchRet1.AcPaySlipRowNo != stockAcPayHisSearchRet2.AcPaySlipRowNo)resList.Add("AcPaySlipRowNo");
			if(stockAcPayHisSearchRet1.InputSectionCd != stockAcPayHisSearchRet2.InputSectionCd)resList.Add("InputSectionCd");
			if(stockAcPayHisSearchRet1.InputSectionGuidNm != stockAcPayHisSearchRet2.InputSectionGuidNm)resList.Add("InputSectionGuidNm");
			if(stockAcPayHisSearchRet1.InputAgenCd != stockAcPayHisSearchRet2.InputAgenCd)resList.Add("InputAgenCd");
			if(stockAcPayHisSearchRet1.InputAgenNm != stockAcPayHisSearchRet2.InputAgenNm)resList.Add("InputAgenNm");
			if(stockAcPayHisSearchRet1.MoveStatus != stockAcPayHisSearchRet2.MoveStatus)resList.Add("MoveStatus");
			if(stockAcPayHisSearchRet1.CustSlipNo != stockAcPayHisSearchRet2.CustSlipNo)resList.Add("CustSlipNo");
			if(stockAcPayHisSearchRet1.SlipDtlNum != stockAcPayHisSearchRet2.SlipDtlNum)resList.Add("SlipDtlNum");
			if(stockAcPayHisSearchRet1.AcPayNote != stockAcPayHisSearchRet2.AcPayNote)resList.Add("AcPayNote");
			if(stockAcPayHisSearchRet1.BLGoodsCode != stockAcPayHisSearchRet2.BLGoodsCode)resList.Add("BLGoodsCode");
			if(stockAcPayHisSearchRet1.BLGoodsFullName != stockAcPayHisSearchRet2.BLGoodsFullName)resList.Add("BLGoodsFullName");
			if(stockAcPayHisSearchRet1.BfSectionCode != stockAcPayHisSearchRet2.BfSectionCode)resList.Add("BfSectionCode");
			if(stockAcPayHisSearchRet1.BfSectionGuideNm != stockAcPayHisSearchRet2.BfSectionGuideNm)resList.Add("BfSectionGuideNm");
			if(stockAcPayHisSearchRet1.BfEnterWarehCode != stockAcPayHisSearchRet2.BfEnterWarehCode)resList.Add("BfEnterWarehCode");
			if(stockAcPayHisSearchRet1.BfEnterWarehName != stockAcPayHisSearchRet2.BfEnterWarehName)resList.Add("BfEnterWarehName");
			if(stockAcPayHisSearchRet1.BfShelfNo != stockAcPayHisSearchRet2.BfShelfNo)resList.Add("BfShelfNo");
			if(stockAcPayHisSearchRet1.CustomerCode != stockAcPayHisSearchRet2.CustomerCode)resList.Add("CustomerCode");
			if(stockAcPayHisSearchRet1.CustomerSnm != stockAcPayHisSearchRet2.CustomerSnm)resList.Add("CustomerSnm");
			if(stockAcPayHisSearchRet1.SupplierCd != stockAcPayHisSearchRet2.SupplierCd)resList.Add("SupplierCd");
			if(stockAcPayHisSearchRet1.SupplierSnm != stockAcPayHisSearchRet2.SupplierSnm)resList.Add("SupplierSnm");
			if(stockAcPayHisSearchRet1.OpenPriceDiv != stockAcPayHisSearchRet2.OpenPriceDiv)resList.Add("OpenPriceDiv");
			if(stockAcPayHisSearchRet1.StockPrice != stockAcPayHisSearchRet2.StockPrice)resList.Add("StockPrice");
			if(stockAcPayHisSearchRet1.SalesUnPrcTaxExcFl != stockAcPayHisSearchRet2.SalesUnPrcTaxExcFl)resList.Add("SalesUnPrcTaxExcFl");
			if(stockAcPayHisSearchRet1.SalesMoney != stockAcPayHisSearchRet2.SalesMoney)resList.Add("SalesMoney");
			if(stockAcPayHisSearchRet1.SupplierStock != stockAcPayHisSearchRet2.SupplierStock)resList.Add("SupplierStock");
			if(stockAcPayHisSearchRet1.AcpOdrCount != stockAcPayHisSearchRet2.AcpOdrCount)resList.Add("AcpOdrCount");
			if(stockAcPayHisSearchRet1.SalesOrderCount != stockAcPayHisSearchRet2.SalesOrderCount)resList.Add("SalesOrderCount");
			if(stockAcPayHisSearchRet1.MovingSupliStock != stockAcPayHisSearchRet2.MovingSupliStock)resList.Add("MovingSupliStock");
			if(stockAcPayHisSearchRet1.ShipmentPosCnt != stockAcPayHisSearchRet2.ShipmentPosCnt)resList.Add("ShipmentPosCnt");
			if(stockAcPayHisSearchRet1.PresentStockCnt != stockAcPayHisSearchRet2.PresentStockCnt)resList.Add("PresentStockCnt");
			if(stockAcPayHisSearchRet1.ArrivalCnt != stockAcPayHisSearchRet2.ArrivalCnt)resList.Add("ArrivalCnt");
			if(stockAcPayHisSearchRet1.ShipmentCnt != stockAcPayHisSearchRet2.ShipmentCnt)resList.Add("ShipmentCnt");
			if(stockAcPayHisSearchRet1.AcPayHistDateTime != stockAcPayHisSearchRet2.AcPayHistDateTime)resList.Add("AcPayHistDateTime");
			if(stockAcPayHisSearchRet1.ShelfNo != stockAcPayHisSearchRet2.ShelfNo)resList.Add("ShelfNo");
			if(stockAcPayHisSearchRet1.BLGoodsName != stockAcPayHisSearchRet2.BLGoodsName)resList.Add("BLGoodsName");

			return resList;
		}
	}
}
