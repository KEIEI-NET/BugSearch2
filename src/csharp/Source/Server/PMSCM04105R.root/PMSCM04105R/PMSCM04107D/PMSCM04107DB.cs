using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SCMAnsHistResultWork
	/// <summary>
	///                      SCM����E�񓚗����Ɖ�ʃN���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM����E�񓚗����Ɖ�ʃN���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :    2009/4/13</br>
	/// <br>Genarated Date   :   2009/08/25  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SCMAnsHistResultWork
	{
		/// <summary>�⍇�����ƃR�[�h</summary>
		private string _inqOtherEpCd = "";

		/// <summary>�⍇���拒�_�R�[�h</summary>
		private string _inqOtherSecCd = "";

		/// <summary>���_����</summary>
		private string _sectionGuidNm = "";

		/// <summary>���Ӑ�R�[�h</summary>
		private Int32 _customerCode;

		/// <summary>���Ӑ於��</summary>
		private string _customerName = "";

		/// <summary>�⍇���ԍ�</summary>
		private Int64 _inquiryNumber;

		/// <summary>�X�V�N����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _updateDate;

		/// <summary>�X�V����</summary>
		/// <remarks>HHMMSSXXX</remarks>
		private Int32 _updateTime;

		/// <summary>�񓚋敪</summary>
		/// <remarks>0:�A�N�V�����Ȃ� 10:�ꕔ�� 20:�񓚊��� 30:���F 99:�L�����Z��</remarks>
		private Int32 _answerDivCd;

		/// <summary>�m���</summary>
		/// <remarks>YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B</remarks>
		private Int32 _judgementDate;

		/// <summary>�⍇���E�������l</summary>
		private string _inqOrdNote = "";

		/// <summary>�⍇���]�ƈ��R�[�h</summary>
		/// <remarks>�⍇�������]�ƈ��R�[�h</remarks>
		private string _inqEmployeeCd = "";

		/// <summary>�⍇���]�ƈ�����</summary>
		/// <remarks>�⍇�������]�ƈ�����</remarks>
		private string _inqEmployeeNm = "";

		/// <summary>�񓚏]�ƈ��R�[�h</summary>
		private string _ansEmployeeCd = "";

		/// <summary>�񓚏]�ƈ�����</summary>
		private string _ansEmployeeNm = "";

		/// <summary>�⍇����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _inquiryDate;

		/// <summary>���^�������ԍ�</summary>
		private Int32 _numberPlate1Code;

		/// <summary>���^�����ǖ���</summary>
		private string _numberPlate1Name = "";

		/// <summary>�ԗ��o�^�ԍ��i��ʁj</summary>
		private string _numberPlate2 = "";

		/// <summary>�ԗ��o�^�ԍ��i�J�i�j</summary>
		private string _numberPlate3 = "";

		/// <summary>�ԗ��o�^�ԍ��i�v���[�g�ԍ��j</summary>
		private Int32 _numberPlate4;

		/// <summary>�^���w��ԍ�</summary>
		private Int32 _modelDesignationNo;

		/// <summary>�ޕʔԍ�</summary>
		private Int32 _categoryNo;

		/// <summary>���[�J�[�R�[�h</summary>
		/// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
		private Int32 _makerCode;

		/// <summary>���[�J�[����</summary>
		private string _carMakerName = "";

		/// <summary>�Ԏ�R�[�h</summary>
		/// <remarks>�Ԗ��R�[�h(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
		private Int32 _modelCode;

		/// <summary>�Ԏ�T�u�R�[�h</summary>
		/// <remarks>0�`899:�񋟕�,900�`հ�ް�o�^</remarks>
		private Int32 _modelSubCode;

		/// <summary>�Ԏ햼</summary>
		private string _modelName = "";

		/// <summary>�Ԍ��،^��</summary>
		private string _carInspectCertModel = "";

		/// <summary>�^���i�t���^�j</summary>
		/// <remarks>�t���^��(44���p)</remarks>
		private string _fullModel = "";

		/// <summary>�ԑ�ԍ�</summary>
		private string _frameNo = "";

		/// <summary>�ԑ�^��</summary>
		private string _frameModel = "";

		/// <summary>�V���V�[No</summary>
		private string _chassisNo = "";

		/// <summary>�ԗ��ŗL�ԍ�</summary>
		/// <remarks>���j�[�N�ȌŒ�ԍ�</remarks>
		private Int32 _carProperNo;

		/// <summary>���Y�N���iNUM�^�C�v�j</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _produceTypeOfYearNum;

		/// <summary>�R�����g</summary>
		/// <remarks>�J�^���O�̃R�����g��P�ʁE�J���[���i�[</remarks>
		private string _comment = "";

		/// <summary>���y�A�J���[�R�[�h</summary>
		/// <remarks>�J�^���O�̐F�R�[�h�i���y�A�p���V�Ԏ��ƈقȂ�ꍇ�j</remarks>
		private string _rpColorCode = "";

		/// <summary>�J���[����1</summary>
		/// <remarks>��ʕ\���p��������</remarks>
		private string _colorName1 = "";

		/// <summary>�g�����R�[�h</summary>
		private string _trimCode = "";

		/// <summary>�g��������</summary>
		private string _trimName = "";

		/// <summary>�ԗ����s����</summary>
		private Int32 _mileage;

		/// <summary>�����I�u�W�F�N�g</summary>
		private byte[] _equipObj;

		/// <summary>�⍇���s�ԍ�</summary>
		private Int32 _inqRowNumber;

		/// <summary>�⍇���s�ԍ��}��</summary>
		private Int32 _inqRowNumDerivedNo;

		/// <summary>���i���</summary>
		/// <remarks>0:�������i 1:�D�Ǖ��i 2:���r���h 3:���� 4:���ϑ���</remarks>
		private Int32 _goodsDivCd;

		/// <summary>���T�C�N�����i���</summary>
		private Int32 _recyclePrtKindCode;

		/// <summary>���T�C�N�����i��ʖ���</summary>
		private string _recyclePrtKindName = "";

		/// <summary>�[�i�敪</summary>
		/// <remarks>0:�z��,1:����</remarks>
		private Int32 _deliveredGoodsDiv;

		/// <summary>�戵�敪</summary>
		/// <remarks>0:��舵���i,1:�[���m�F��,2:����舵���i</remarks>
		private Int32 _handleDivCode;

		/// <summary>���i�`��</summary>
		/// <remarks>1:���i,2:�p�i</remarks>
		private Int32 _goodsShape;

		/// <summary>�[�i�m�F�敪</summary>
		/// <remarks>0:���m�F,1:�m�F</remarks>
		private Int32 _delivrdGdsConfCd;

		/// <summary>�[�i�����\���</summary>
		/// <remarks>�[�i�\����t YYYYMMDD</remarks>
		private DateTime _deliGdsCmpltDueDate;

		/// <summary>BL���i�R�[�h</summary>
		private Int32 _bLGoodsCode;

		/// <summary>BL���i�R�[�h�}��</summary>
		private Int32 _bLGoodsDrCode;

		/// <summary>���i����</summary>
		private string _goodsName = "";

		/// <summary>������</summary>
		private Double _salesOrderCount;

		/// <summary>�[�i��</summary>
		private Double _deliveredGoodsCount;

		/// <summary>���i�ԍ�</summary>
		private string _goodsNo = "";

		/// <summary>���i���[�J�[�R�[�h</summary>
		private Int32 _goodsMakerCd;

		/// <summary>���[�J�[����</summary>
		private string _makerName = "";

		/// <summary>�������i���[�J�[�R�[�h</summary>
		private Int32 _pureGoodsMakerCd;

		/// <summary>�������i���[�J�[����</summary>
		private string _pureMakerName = "";

		/// <summary>�������i�ԍ�</summary>
		private string _pureGoodsNo = "";

		/// <summary>�������i����</summary>
		private string _pureGoodsName = "";

		/// <summary>�艿</summary>
		/// <remarks>0:�I�[�v�����i</remarks>
		private Int64 _listPrice;

		/// <summary>�P��</summary>
		private Int64 _unitPrice;

		/// <summary>���i�⑫���</summary>
		private string _goodsAddInfo = "";

		/// <summary>�e���z</summary>
		private Int64 _roughRrofit;

		/// <summary>�e����</summary>
		private Double _roughRate;

		/// <summary>�񓚊���</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _answerLimitDate;

		/// <summary>���l(����)</summary>
		private string _commentDtl = "";

		/// <summary>�I��</summary>
		private string _shelfNo = "";

		/// <summary>�ǉ��敪</summary>
		private Int32 _additionalDivCd;

		/// <summary>�����敪</summary>
		private Int32 _correctDivCD;

		/// <summary>�󒍃X�e�[�^�X</summary>
		/// <remarks>10:����,20:��,30:����</remarks>
		private Int32 _acptAnOdrStatus;

		/// <summary>����`�[�ԍ�</summary>
		/// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
		private string _salesSlipNum = "";

		/// <summary>����s�ԍ�</summary>
		private Int32 _salesRowNo;

		/// <summary>�݌ɋ敪</summary>
		/// <remarks>�ϑ��݌ɁA���Ӑ�݌ɁA�D��q�ɁA���Ѝ݌ɁA��݌�</remarks>
		private Int32 _stockDiv;

		/// <summary>�⍇���E�������</summary>
		/// <remarks>1:�⍇�� 2:����</remarks>
		private Int32 _inqOrdDivCd;

		/// <summary>�\������</summary>
		private Int32 _displayOrder;

		/// <summary>�L�����y�[���R�[�h</summary>
		private Int32 _campaignCode;

		/// <summary>�L�����y�[������</summary>
		private string _campaignName = "";

		/// <summary>����`�[���v�i�ō��݁j</summary>
		/// <remarks>���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz</remarks>
		private Int64 _salesTotalTaxInc;

		/// <summary>���㏬�v�i�Łj</summary>
		/// <remarks>�l����̐Ŋz�i�O�ŕ��A���ŕ��̍��v�j</remarks>
		private Int64 _salesSubtotalTax;

		/// <summary>�┭�E�񓚎��</summary>
		/// <remarks>1:�⍇���E���� 2:��</remarks>
		private Int32 _inqOrdAnsDivCd;

		/// <summary>��M����</summary>
		/// <remarks>�iDateTime:���x��100�i�m�b�j</remarks>
		private Int64 _receiveDateTime;

		/// <summary>�񓚍쐬�敪</summary>
		/// <remarks>0:����, 1:�蓮�iWeb�j, 2:�蓮�i���̑��j</remarks>
		private Int32 _answerCreateDiv;

		/// <summary>�񓚔[��</summary>
		private string _answerDeliveryDate = "";

		/// <summary>�┭���i��</summary>
		/// <remarks>(���p�S�p����)</remarks>
		private string _inqGoodsName = "";

		/// <summary>�񓚏��i��</summary>
		/// <remarks>(���p�S�p����)</remarks>
		private string _ansGoodsName = "";

		/// <summary>�┭�������i�ԍ�</summary>
		/// <remarks>(���p�̂�)</remarks>
		private string _inqPureGoodsNo = "";

		/// <summary>�񓚏������i�ԍ�</summary>
		/// <remarks>(���p�̂�)</remarks>
		private string _ansPureGoodsNo = "";

		/// <summary>�┭�������i��</summary>
		/// <remarks>(���p�S�p����)</remarks>
		private string _inqPureGoodsName = "";

		/// <summary>�񓚏������i��</summary>
		/// <remarks>(���p�S�p����)</remarks>
		private string _ansPureGoodsName = "";


		/// public propaty name  :  InqOtherEpCd
		/// <summary>�⍇�����ƃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇�����ƃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqOtherEpCd
		{
			get{return _inqOtherEpCd;}
			set{_inqOtherEpCd = value;}
		}

		/// public propaty name  :  InqOtherSecCd
		/// <summary>�⍇���拒�_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���拒�_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqOtherSecCd
		{
			get{return _inqOtherSecCd;}
			set{_inqOtherSecCd = value;}
		}

		/// public propaty name  :  SectionGuidNm
		/// <summary>���_���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SectionGuidNm
		{
			get{return _sectionGuidNm;}
			set{_sectionGuidNm = value;}
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

		/// public propaty name  :  InquiryNumber
		/// <summary>�⍇���ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 InquiryNumber
		{
			get{return _inquiryNumber;}
			set{_inquiryNumber = value;}
		}

		/// public propaty name  :  UpdateDate
		/// <summary>�X�V�N�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime UpdateDate
		{
			get{return _updateDate;}
			set{_updateDate = value;}
		}

		/// public propaty name  :  UpdateTime
		/// <summary>�X�V���ԃv���p�e�B</summary>
		/// <value>HHMMSSXXX</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UpdateTime
		{
			get{return _updateTime;}
			set{_updateTime = value;}
		}

		/// public propaty name  :  AnswerDivCd
		/// <summary>�񓚋敪�v���p�e�B</summary>
		/// <value>0:�A�N�V�����Ȃ� 10:�ꕔ�� 20:�񓚊��� 30:���F 99:�L�����Z��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AnswerDivCd
		{
			get{return _answerDivCd;}
			set{_answerDivCd = value;}
		}

		/// public propaty name  :  JudgementDate
		/// <summary>�m����v���p�e�B</summary>
		/// <value>YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �m����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 JudgementDate
		{
			get{return _judgementDate;}
			set{_judgementDate = value;}
		}

		/// public propaty name  :  InqOrdNote
		/// <summary>�⍇���E�������l�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���E�������l�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqOrdNote
		{
			get{return _inqOrdNote;}
			set{_inqOrdNote = value;}
		}

		/// public propaty name  :  InqEmployeeCd
		/// <summary>�⍇���]�ƈ��R�[�h�v���p�e�B</summary>
		/// <value>�⍇�������]�ƈ��R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqEmployeeCd
		{
			get{return _inqEmployeeCd;}
			set{_inqEmployeeCd = value;}
		}

		/// public propaty name  :  InqEmployeeNm
		/// <summary>�⍇���]�ƈ����̃v���p�e�B</summary>
		/// <value>�⍇�������]�ƈ�����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���]�ƈ����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqEmployeeNm
		{
			get{return _inqEmployeeNm;}
			set{_inqEmployeeNm = value;}
		}

		/// public propaty name  :  AnsEmployeeCd
		/// <summary>�񓚏]�ƈ��R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚏]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AnsEmployeeCd
		{
			get{return _ansEmployeeCd;}
			set{_ansEmployeeCd = value;}
		}

		/// public propaty name  :  AnsEmployeeNm
		/// <summary>�񓚏]�ƈ����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚏]�ƈ����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AnsEmployeeNm
		{
			get{return _ansEmployeeNm;}
			set{_ansEmployeeNm = value;}
		}

		/// public propaty name  :  InquiryDate
		/// <summary>�⍇�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InquiryDate
		{
			get{return _inquiryDate;}
			set{_inquiryDate = value;}
		}

		/// public propaty name  :  NumberPlate1Code
		/// <summary>���^�������ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���^�������ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 NumberPlate1Code
		{
			get{return _numberPlate1Code;}
			set{_numberPlate1Code = value;}
		}

		/// public propaty name  :  NumberPlate1Name
		/// <summary>���^�����ǖ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���^�����ǖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string NumberPlate1Name
		{
			get{return _numberPlate1Name;}
			set{_numberPlate1Name = value;}
		}

		/// public propaty name  :  NumberPlate2
		/// <summary>�ԗ��o�^�ԍ��i��ʁj�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԗ��o�^�ԍ��i��ʁj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string NumberPlate2
		{
			get{return _numberPlate2;}
			set{_numberPlate2 = value;}
		}

		/// public propaty name  :  NumberPlate3
		/// <summary>�ԗ��o�^�ԍ��i�J�i�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԗ��o�^�ԍ��i�J�i�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string NumberPlate3
		{
			get{return _numberPlate3;}
			set{_numberPlate3 = value;}
		}

		/// public propaty name  :  NumberPlate4
		/// <summary>�ԗ��o�^�ԍ��i�v���[�g�ԍ��j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԗ��o�^�ԍ��i�v���[�g�ԍ��j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 NumberPlate4
		{
			get{return _numberPlate4;}
			set{_numberPlate4 = value;}
		}

		/// public propaty name  :  ModelDesignationNo
		/// <summary>�^���w��ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �^���w��ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ModelDesignationNo
		{
			get{return _modelDesignationNo;}
			set{_modelDesignationNo = value;}
		}

		/// public propaty name  :  CategoryNo
		/// <summary>�ޕʔԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ޕʔԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CategoryNo
		{
			get{return _categoryNo;}
			set{_categoryNo = value;}
		}

		/// public propaty name  :  MakerCode
		/// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
		/// <value>1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MakerCode
		{
			get{return _makerCode;}
			set{_makerCode = value;}
		}

		/// public propaty name  :  CarMakerName
		/// <summary>���[�J�[���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CarMakerName
		{
			get{return _carMakerName;}
			set{_carMakerName = value;}
		}

		/// public propaty name  :  ModelCode
		/// <summary>�Ԏ�R�[�h�v���p�e�B</summary>
		/// <value>�Ԗ��R�[�h(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Ԏ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ModelCode
		{
			get{return _modelCode;}
			set{_modelCode = value;}
		}

		/// public propaty name  :  ModelSubCode
		/// <summary>�Ԏ�T�u�R�[�h�v���p�e�B</summary>
		/// <value>0�`899:�񋟕�,900�`հ�ް�o�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Ԏ�T�u�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ModelSubCode
		{
			get{return _modelSubCode;}
			set{_modelSubCode = value;}
		}

		/// public propaty name  :  ModelName
		/// <summary>�Ԏ햼�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Ԏ햼�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ModelName
		{
			get{return _modelName;}
			set{_modelName = value;}
		}

		/// public propaty name  :  CarInspectCertModel
		/// <summary>�Ԍ��،^���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Ԍ��،^���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CarInspectCertModel
		{
			get{return _carInspectCertModel;}
			set{_carInspectCertModel = value;}
		}

		/// public propaty name  :  FullModel
		/// <summary>�^���i�t���^�j�v���p�e�B</summary>
		/// <value>�t���^��(44���p)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �^���i�t���^�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string FullModel
		{
			get{return _fullModel;}
			set{_fullModel = value;}
		}

		/// public propaty name  :  FrameNo
		/// <summary>�ԑ�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԑ�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string FrameNo
		{
			get{return _frameNo;}
			set{_frameNo = value;}
		}

		/// public propaty name  :  FrameModel
		/// <summary>�ԑ�^���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԑ�^���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string FrameModel
		{
			get{return _frameModel;}
			set{_frameModel = value;}
		}

		/// public propaty name  :  ChassisNo
		/// <summary>�V���V�[No�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �V���V�[No�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ChassisNo
		{
			get{return _chassisNo;}
			set{_chassisNo = value;}
		}

		/// public propaty name  :  CarProperNo
		/// <summary>�ԗ��ŗL�ԍ��v���p�e�B</summary>
		/// <value>���j�[�N�ȌŒ�ԍ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԗ��ŗL�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CarProperNo
		{
			get{return _carProperNo;}
			set{_carProperNo = value;}
		}

		/// public propaty name  :  ProduceTypeOfYearNum
		/// <summary>���Y�N���iNUM�^�C�v�j�v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Y�N���iNUM�^�C�v�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ProduceTypeOfYearNum
		{
			get{return _produceTypeOfYearNum;}
			set{_produceTypeOfYearNum = value;}
		}

		/// public propaty name  :  Comment
		/// <summary>�R�����g�v���p�e�B</summary>
		/// <value>�J�^���O�̃R�����g��P�ʁE�J���[���i�[</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �R�����g�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Comment
		{
			get{return _comment;}
			set{_comment = value;}
		}

		/// public propaty name  :  RpColorCode
		/// <summary>���y�A�J���[�R�[�h�v���p�e�B</summary>
		/// <value>�J�^���O�̐F�R�[�h�i���y�A�p���V�Ԏ��ƈقȂ�ꍇ�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���y�A�J���[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string RpColorCode
		{
			get{return _rpColorCode;}
			set{_rpColorCode = value;}
		}

		/// public propaty name  :  ColorName1
		/// <summary>�J���[����1�v���p�e�B</summary>
		/// <value>��ʕ\���p��������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J���[����1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ColorName1
		{
			get{return _colorName1;}
			set{_colorName1 = value;}
		}

		/// public propaty name  :  TrimCode
		/// <summary>�g�����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �g�����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TrimCode
		{
			get{return _trimCode;}
			set{_trimCode = value;}
		}

		/// public propaty name  :  TrimName
		/// <summary>�g�������̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �g�������̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TrimName
		{
			get{return _trimName;}
			set{_trimName = value;}
		}

		/// public propaty name  :  Mileage
		/// <summary>�ԗ����s�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԗ����s�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Mileage
		{
			get{return _mileage;}
			set{_mileage = value;}
		}

		/// public propaty name  :  EquipObj
		/// <summary>�����I�u�W�F�N�g�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����I�u�W�F�N�g�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public byte[] EquipObj
		{
			get{return _equipObj;}
			set{_equipObj = value;}
		}

		/// public propaty name  :  InqRowNumber
		/// <summary>�⍇���s�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���s�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InqRowNumber
		{
			get{return _inqRowNumber;}
			set{_inqRowNumber = value;}
		}

		/// public propaty name  :  InqRowNumDerivedNo
		/// <summary>�⍇���s�ԍ��}�ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���s�ԍ��}�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InqRowNumDerivedNo
		{
			get{return _inqRowNumDerivedNo;}
			set{_inqRowNumDerivedNo = value;}
		}

		/// public propaty name  :  GoodsDivCd
		/// <summary>���i��ʃv���p�e�B</summary>
		/// <value>0:�������i 1:�D�Ǖ��i 2:���r���h 3:���� 4:���ϑ���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i��ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsDivCd
		{
			get{return _goodsDivCd;}
			set{_goodsDivCd = value;}
		}

		/// public propaty name  :  RecyclePrtKindCode
		/// <summary>���T�C�N�����i��ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���T�C�N�����i��ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 RecyclePrtKindCode
		{
			get{return _recyclePrtKindCode;}
			set{_recyclePrtKindCode = value;}
		}

		/// public propaty name  :  RecyclePrtKindName
		/// <summary>���T�C�N�����i��ʖ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���T�C�N�����i��ʖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string RecyclePrtKindName
		{
			get{return _recyclePrtKindName;}
			set{_recyclePrtKindName = value;}
		}

		/// public propaty name  :  DeliveredGoodsDiv
		/// <summary>�[�i�敪�v���p�e�B</summary>
		/// <value>0:�z��,1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DeliveredGoodsDiv
		{
			get{return _deliveredGoodsDiv;}
			set{_deliveredGoodsDiv = value;}
		}

		/// public propaty name  :  HandleDivCode
		/// <summary>�戵�敪�v���p�e�B</summary>
		/// <value>0:��舵���i,1:�[���m�F��,2:����舵���i</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �戵�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 HandleDivCode
		{
			get{return _handleDivCode;}
			set{_handleDivCode = value;}
		}

		/// public propaty name  :  GoodsShape
		/// <summary>���i�`�ԃv���p�e�B</summary>
		/// <value>1:���i,2:�p�i</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�`�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsShape
		{
			get{return _goodsShape;}
			set{_goodsShape = value;}
		}

		/// public propaty name  :  DelivrdGdsConfCd
		/// <summary>�[�i�m�F�敪�v���p�e�B</summary>
		/// <value>0:���m�F,1:�m�F</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�m�F�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DelivrdGdsConfCd
		{
			get{return _delivrdGdsConfCd;}
			set{_delivrdGdsConfCd = value;}
		}

		/// public propaty name  :  DeliGdsCmpltDueDate
		/// <summary>�[�i�����\����v���p�e�B</summary>
		/// <value>�[�i�\����t YYYYMMDD</value>
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

		/// public propaty name  :  BLGoodsDrCode
		/// <summary>BL���i�R�[�h�}�ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL���i�R�[�h�}�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BLGoodsDrCode
		{
			get{return _bLGoodsDrCode;}
			set{_bLGoodsDrCode = value;}
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

		/// public propaty name  :  DeliveredGoodsCount
		/// <summary>�[�i���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double DeliveredGoodsCount
		{
			get{return _deliveredGoodsCount;}
			set{_deliveredGoodsCount = value;}
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

		/// public propaty name  :  PureGoodsMakerCd
		/// <summary>�������i���[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������i���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PureGoodsMakerCd
		{
			get{return _pureGoodsMakerCd;}
			set{_pureGoodsMakerCd = value;}
		}

		/// public propaty name  :  PureMakerName
		/// <summary>�������i���[�J�[���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������i���[�J�[���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PureMakerName
		{
			get{return _pureMakerName;}
			set{_pureMakerName = value;}
		}

		/// public propaty name  :  PureGoodsNo
		/// <summary>�������i�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������i�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PureGoodsNo
		{
			get{return _pureGoodsNo;}
			set{_pureGoodsNo = value;}
		}

		/// public propaty name  :  PureGoodsName
		/// <summary>�������i���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������i���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PureGoodsName
		{
			get{return _pureGoodsName;}
			set{_pureGoodsName = value;}
		}

		/// public propaty name  :  ListPrice
		/// <summary>�艿�v���p�e�B</summary>
		/// <value>0:�I�[�v�����i</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �艿�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ListPrice
		{
			get{return _listPrice;}
			set{_listPrice = value;}
		}

		/// public propaty name  :  UnitPrice
		/// <summary>�P���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �P���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 UnitPrice
		{
			get{return _unitPrice;}
			set{_unitPrice = value;}
		}

		/// public propaty name  :  GoodsAddInfo
		/// <summary>���i�⑫���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�⑫���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsAddInfo
		{
			get{return _goodsAddInfo;}
			set{_goodsAddInfo = value;}
		}

		/// public propaty name  :  RoughRrofit
		/// <summary>�e���z�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 RoughRrofit
		{
			get{return _roughRrofit;}
			set{_roughRrofit = value;}
		}

		/// public propaty name  :  RoughRate
		/// <summary>�e�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double RoughRate
		{
			get{return _roughRate;}
			set{_roughRate = value;}
		}

		/// public propaty name  :  AnswerLimitDate
		/// <summary>�񓚊����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚊����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AnswerLimitDate
		{
			get{return _answerLimitDate;}
			set{_answerLimitDate = value;}
		}

		/// public propaty name  :  CommentDtl
		/// <summary>���l(����)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���l(����)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CommentDtl
		{
			get{return _commentDtl;}
			set{_commentDtl = value;}
		}

		/// public propaty name  :  ShelfNo
		/// <summary>�I�ԃv���p�e�B</summary>
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

		/// public propaty name  :  AdditionalDivCd
		/// <summary>�ǉ��敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ǉ��敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AdditionalDivCd
		{
			get{return _additionalDivCd;}
			set{_additionalDivCd = value;}
		}

		/// public propaty name  :  CorrectDivCD
		/// <summary>�����敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CorrectDivCD
		{
			get{return _correctDivCD;}
			set{_correctDivCD = value;}
		}

		/// public propaty name  :  AcptAnOdrStatus
		/// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
		/// <value>10:����,20:��,30:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AcptAnOdrStatus
		{
			get{return _acptAnOdrStatus;}
			set{_acptAnOdrStatus = value;}
		}

		/// public propaty name  :  SalesSlipNum
		/// <summary>����`�[�ԍ��v���p�e�B</summary>
		/// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</value>
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

		/// public propaty name  :  SalesRowNo
		/// <summary>����s�ԍ��v���p�e�B</summary>
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

		/// public propaty name  :  StockDiv
		/// <summary>�݌ɋ敪�v���p�e�B</summary>
		/// <value>�ϑ��݌ɁA���Ӑ�݌ɁA�D��q�ɁA���Ѝ݌ɁA��݌�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �݌ɋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockDiv
		{
			get{return _stockDiv;}
			set{_stockDiv = value;}
		}

		/// public propaty name  :  InqOrdDivCd
		/// <summary>�⍇���E������ʃv���p�e�B</summary>
		/// <value>1:�⍇�� 2:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���E������ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InqOrdDivCd
		{
			get{return _inqOrdDivCd;}
			set{_inqOrdDivCd = value;}
		}

		/// public propaty name  :  DisplayOrder
		/// <summary>�\�����ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �\�����ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DisplayOrder
		{
			get{return _displayOrder;}
			set{_displayOrder = value;}
		}

		/// public propaty name  :  CampaignCode
		/// <summary>�L�����y�[���R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �L�����y�[���R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CampaignCode
		{
			get{return _campaignCode;}
			set{_campaignCode = value;}
		}

		/// public propaty name  :  CampaignName
		/// <summary>�L�����y�[�����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �L�����y�[�����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CampaignName
		{
			get{return _campaignName;}
			set{_campaignName = value;}
		}

		/// public propaty name  :  SalesTotalTaxInc
		/// <summary>����`�[���v�i�ō��݁j�v���p�e�B</summary>
		/// <value>���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����`�[���v�i�ō��݁j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTotalTaxInc
		{
			get{return _salesTotalTaxInc;}
			set{_salesTotalTaxInc = value;}
		}

		/// public propaty name  :  SalesSubtotalTax
		/// <summary>���㏬�v�i�Łj�v���p�e�B</summary>
		/// <value>�l����̐Ŋz�i�O�ŕ��A���ŕ��̍��v�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���㏬�v�i�Łj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesSubtotalTax
		{
			get{return _salesSubtotalTax;}
			set{_salesSubtotalTax = value;}
		}

		/// public propaty name  :  InqOrdAnsDivCd
		/// <summary>�┭�E�񓚎�ʃv���p�e�B</summary>
		/// <value>1:�⍇���E���� 2:��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �┭�E�񓚎�ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InqOrdAnsDivCd
		{
			get{return _inqOrdAnsDivCd;}
			set{_inqOrdAnsDivCd = value;}
		}

		/// public propaty name  :  ReceiveDateTime
		/// <summary>��M�����v���p�e�B</summary>
		/// <value>�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��M�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ReceiveDateTime
		{
			get{return _receiveDateTime;}
			set{_receiveDateTime = value;}
		}

		/// public propaty name  :  AnswerCreateDiv
		/// <summary>�񓚍쐬�敪�v���p�e�B</summary>
		/// <value>0:����, 1:�蓮�iWeb�j, 2:�蓮�i���̑��j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚍쐬�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AnswerCreateDiv
		{
			get{return _answerCreateDiv;}
			set{_answerCreateDiv = value;}
		}

		/// public propaty name  :  AnswerDeliveryDate
		/// <summary>�񓚔[���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚔[���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AnswerDeliveryDate
		{
			get{return _answerDeliveryDate;}
			set{_answerDeliveryDate = value;}
		}

		/// public propaty name  :  InqGoodsName
		/// <summary>�┭���i���v���p�e�B</summary>
		/// <value>(���p�S�p����)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �┭���i���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqGoodsName
		{
			get{return _inqGoodsName;}
			set{_inqGoodsName = value;}
		}

		/// public propaty name  :  AnsGoodsName
		/// <summary>�񓚏��i���v���p�e�B</summary>
		/// <value>(���p�S�p����)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚏��i���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AnsGoodsName
		{
			get{return _ansGoodsName;}
			set{_ansGoodsName = value;}
		}

		/// public propaty name  :  InqPureGoodsNo
		/// <summary>�┭�������i�ԍ��v���p�e�B</summary>
		/// <value>(���p�̂�)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �┭�������i�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqPureGoodsNo
		{
			get{return _inqPureGoodsNo;}
			set{_inqPureGoodsNo = value;}
		}

		/// public propaty name  :  AnsPureGoodsNo
		/// <summary>�񓚏������i�ԍ��v���p�e�B</summary>
		/// <value>(���p�̂�)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚏������i�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AnsPureGoodsNo
		{
			get{return _ansPureGoodsNo;}
			set{_ansPureGoodsNo = value;}
		}

		/// public propaty name  :  InqPureGoodsName
		/// <summary>�┭�������i���v���p�e�B</summary>
		/// <value>(���p�S�p����)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �┭�������i���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqPureGoodsName
		{
			get{return _inqPureGoodsName;}
			set{_inqPureGoodsName = value;}
		}

		/// public propaty name  :  AnsPureGoodsName
		/// <summary>�񓚏������i���v���p�e�B</summary>
		/// <value>(���p�S�p����)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚏������i���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AnsPureGoodsName
		{
			get{return _ansPureGoodsName;}
			set{_ansPureGoodsName = value;}
		}


		/// <summary>
		/// SCM����E�񓚗����Ɖ�ʃN���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>SCMAnsHistResultWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAnsHistResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SCMAnsHistResultWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SCMAnsHistResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SCMAnsHistResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SCMAnsHistResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMAnsHistResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SCMAnsHistResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SCMAnsHistResultWork || graph is ArrayList || graph is SCMAnsHistResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SCMAnsHistResultWork).FullName));

            if (graph != null && graph is SCMAnsHistResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMAnsHistResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SCMAnsHistResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SCMAnsHistResultWork[])graph).Length;
            }
            else if (graph is SCMAnsHistResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�⍇�����ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
            //�⍇���拒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
            //���_����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuidNm
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ於��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
            //�⍇���ԍ�
            serInfo.MemberInfo.Add(typeof(Int64)); //InquiryNumber
            //�X�V�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDate
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateTime
            //�񓚋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDivCd
            //�m���
            serInfo.MemberInfo.Add(typeof(Int32)); //JudgementDate
            //�⍇���E�������l
            serInfo.MemberInfo.Add(typeof(string)); //InqOrdNote
            //�⍇���]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqEmployeeCd
            //�⍇���]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //InqEmployeeNm
            //�񓚏]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AnsEmployeeCd
            //�񓚏]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //AnsEmployeeNm
            //�⍇����
            serInfo.MemberInfo.Add(typeof(Int32)); //InquiryDate
            //���^�������ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //NumberPlate1Code
            //���^�����ǖ���
            serInfo.MemberInfo.Add(typeof(string)); //NumberPlate1Name
            //�ԗ��o�^�ԍ��i��ʁj
            serInfo.MemberInfo.Add(typeof(string)); //NumberPlate2
            //�ԗ��o�^�ԍ��i�J�i�j
            serInfo.MemberInfo.Add(typeof(string)); //NumberPlate3
            //�ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            serInfo.MemberInfo.Add(typeof(Int32)); //NumberPlate4
            //�^���w��ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelDesignationNo
            //�ޕʔԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //CategoryNo
            //���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //CarMakerName
            //�Ԏ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelCode
            //�Ԏ�T�u�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelSubCode
            //�Ԏ햼
            serInfo.MemberInfo.Add(typeof(string)); //ModelName
            //�Ԍ��،^��
            serInfo.MemberInfo.Add(typeof(string)); //CarInspectCertModel
            //�^���i�t���^�j
            serInfo.MemberInfo.Add(typeof(string)); //FullModel
            //�ԑ�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //FrameNo
            //�ԑ�^��
            serInfo.MemberInfo.Add(typeof(string)); //FrameModel
            //�V���V�[No
            serInfo.MemberInfo.Add(typeof(string)); //ChassisNo
            //�ԗ��ŗL�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //CarProperNo
            //���Y�N���iNUM�^�C�v�j
            serInfo.MemberInfo.Add(typeof(Int32)); //ProduceTypeOfYearNum
            //�R�����g
            serInfo.MemberInfo.Add(typeof(string)); //Comment
            //���y�A�J���[�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //RpColorCode
            //�J���[����1
            serInfo.MemberInfo.Add(typeof(string)); //ColorName1
            //�g�����R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //TrimCode
            //�g��������
            serInfo.MemberInfo.Add(typeof(string)); //TrimName
            //�ԗ����s����
            serInfo.MemberInfo.Add(typeof(Int32)); //Mileage
            //�����I�u�W�F�N�g
            serInfo.MemberInfo.Add(typeof(byte[])); //EquipObj
            //�⍇���s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //InqRowNumber
            //�⍇���s�ԍ��}��
            serInfo.MemberInfo.Add(typeof(Int32)); //InqRowNumDerivedNo
            //���i���
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsDivCd
            //���T�C�N�����i���
            serInfo.MemberInfo.Add(typeof(Int32)); //RecyclePrtKindCode
            //���T�C�N�����i��ʖ���
            serInfo.MemberInfo.Add(typeof(string)); //RecyclePrtKindName
            //�[�i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliveredGoodsDiv
            //�戵�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //HandleDivCode
            //���i�`��
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsShape
            //�[�i�m�F�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DelivrdGdsConfCd
            //�[�i�����\���
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliGdsCmpltDueDate
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL���i�R�[�h�}��
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsDrCode
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //������
            serInfo.MemberInfo.Add(typeof(Double)); //SalesOrderCount
            //�[�i��
            serInfo.MemberInfo.Add(typeof(Double)); //DeliveredGoodsCount
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //�������i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PureGoodsMakerCd
            //�������i���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //PureMakerName
            //�������i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //PureGoodsNo
            //�������i����
            serInfo.MemberInfo.Add(typeof(string)); //PureGoodsName
            //�艿
            serInfo.MemberInfo.Add(typeof(Int64)); //ListPrice
            //�P��
            serInfo.MemberInfo.Add(typeof(Int64)); //UnitPrice
            //���i�⑫���
            serInfo.MemberInfo.Add(typeof(string)); //GoodsAddInfo
            //�e���z
            serInfo.MemberInfo.Add(typeof(Int64)); //RoughRrofit
            //�e����
            serInfo.MemberInfo.Add(typeof(Double)); //RoughRate
            //�񓚊���
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerLimitDate
            //���l(����)
            serInfo.MemberInfo.Add(typeof(string)); //CommentDtl
            //�I��
            serInfo.MemberInfo.Add(typeof(string)); //ShelfNo
            //�ǉ��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AdditionalDivCd
            //�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CorrectDivCD
            //�󒍃X�e�[�^�X
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //����s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowNo
            //�݌ɋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDiv
            //�⍇���E�������
            serInfo.MemberInfo.Add(typeof(Int32)); //InqOrdDivCd
            //�\������
            serInfo.MemberInfo.Add(typeof(Int32)); //DisplayOrder
            //�L�����y�[���R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CampaignCode
            //�L�����y�[������
            serInfo.MemberInfo.Add(typeof(string)); //CampaignName
            //����`�[���v�i�ō��݁j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTotalTaxInc
            //���㏬�v�i�Łj
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSubtotalTax
            //�┭�E�񓚎��
            serInfo.MemberInfo.Add(typeof(Int32)); //InqOrdAnsDivCd
            //��M����
            serInfo.MemberInfo.Add(typeof(Int64)); //ReceiveDateTime
            //�񓚍쐬�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerCreateDiv
            //�񓚔[��
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDeliveryDate
            //�┭���i��
            serInfo.MemberInfo.Add(typeof(string)); //InqGoodsName
            //�񓚏��i��
            serInfo.MemberInfo.Add(typeof(string)); //AnsGoodsName
            //�┭�������i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //InqPureGoodsNo
            //�񓚏������i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //AnsPureGoodsNo
            //�┭�������i��
            serInfo.MemberInfo.Add(typeof(string)); //InqPureGoodsName
            //�񓚏������i��
            serInfo.MemberInfo.Add(typeof(string)); //AnsPureGoodsName


            serInfo.Serialize(writer, serInfo);
            if (graph is SCMAnsHistResultWork)
            {
                SCMAnsHistResultWork temp = (SCMAnsHistResultWork)graph;

                SetSCMAnsHistResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SCMAnsHistResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SCMAnsHistResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SCMAnsHistResultWork temp in lst)
                {
                    SetSCMAnsHistResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SCMAnsHistResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 94;

        /// <summary>
        ///  SCMAnsHistResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMAnsHistResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSCMAnsHistResultWork(System.IO.BinaryWriter writer, SCMAnsHistResultWork temp)
        {
            //�⍇�����ƃR�[�h
            writer.Write(temp.InqOtherEpCd);
            //�⍇���拒�_�R�[�h
            writer.Write(temp.InqOtherSecCd);
            //���_����
            writer.Write(temp.SectionGuidNm);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ於��
            writer.Write(temp.CustomerName);
            //�⍇���ԍ�
            writer.Write(temp.InquiryNumber);
            //�X�V�N����
            writer.Write((Int64)temp.UpdateDate.Ticks);
            //�X�V����
            writer.Write(temp.UpdateTime);
            //�񓚋敪
            writer.Write(temp.AnswerDivCd);
            //�m���
            writer.Write(temp.JudgementDate);
            //�⍇���E�������l
            writer.Write(temp.InqOrdNote);
            //�⍇���]�ƈ��R�[�h
            writer.Write(temp.InqEmployeeCd);
            //�⍇���]�ƈ�����
            writer.Write(temp.InqEmployeeNm);
            //�񓚏]�ƈ��R�[�h
            writer.Write(temp.AnsEmployeeCd);
            //�񓚏]�ƈ�����
            writer.Write(temp.AnsEmployeeNm);
            //�⍇����
            writer.Write(temp.InquiryDate);
            //���^�������ԍ�
            writer.Write(temp.NumberPlate1Code);
            //���^�����ǖ���
            writer.Write(temp.NumberPlate1Name);
            //�ԗ��o�^�ԍ��i��ʁj
            writer.Write(temp.NumberPlate2);
            //�ԗ��o�^�ԍ��i�J�i�j
            writer.Write(temp.NumberPlate3);
            //�ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            writer.Write(temp.NumberPlate4);
            //�^���w��ԍ�
            writer.Write(temp.ModelDesignationNo);
            //�ޕʔԍ�
            writer.Write(temp.CategoryNo);
            //���[�J�[�R�[�h
            writer.Write(temp.MakerCode);
            //���[�J�[����
            writer.Write(temp.CarMakerName);
            //�Ԏ�R�[�h
            writer.Write(temp.ModelCode);
            //�Ԏ�T�u�R�[�h
            writer.Write(temp.ModelSubCode);
            //�Ԏ햼
            writer.Write(temp.ModelName);
            //�Ԍ��،^��
            writer.Write(temp.CarInspectCertModel);
            //�^���i�t���^�j
            writer.Write(temp.FullModel);
            //�ԑ�ԍ�
            writer.Write(temp.FrameNo);
            //�ԑ�^��
            writer.Write(temp.FrameModel);
            //�V���V�[No
            writer.Write(temp.ChassisNo);
            //�ԗ��ŗL�ԍ�
            writer.Write(temp.CarProperNo);
            //���Y�N���iNUM�^�C�v�j
            writer.Write(temp.ProduceTypeOfYearNum);
            //�R�����g
            writer.Write(temp.Comment);
            //���y�A�J���[�R�[�h
            writer.Write(temp.RpColorCode);
            //�J���[����1
            writer.Write(temp.ColorName1);
            //�g�����R�[�h
            writer.Write(temp.TrimCode);
            //�g��������
            writer.Write(temp.TrimName);
            //�ԗ����s����
            writer.Write(temp.Mileage);
            //�����I�u�W�F�N�g
            writer.Write(temp.EquipObj.Length);
            writer.Write(temp.EquipObj);
            //�⍇���s�ԍ�
            writer.Write(temp.InqRowNumber);
            //�⍇���s�ԍ��}��
            writer.Write(temp.InqRowNumDerivedNo);
            //���i���
            writer.Write(temp.GoodsDivCd);
            //���T�C�N�����i���
            writer.Write(temp.RecyclePrtKindCode);
            //���T�C�N�����i��ʖ���
            writer.Write(temp.RecyclePrtKindName);
            //�[�i�敪
            writer.Write(temp.DeliveredGoodsDiv);
            //�戵�敪
            writer.Write(temp.HandleDivCode);
            //���i�`��
            writer.Write(temp.GoodsShape);
            //�[�i�m�F�敪
            writer.Write(temp.DelivrdGdsConfCd);
            //�[�i�����\���
            writer.Write((Int64)temp.DeliGdsCmpltDueDate.Ticks);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //BL���i�R�[�h�}��
            writer.Write(temp.BLGoodsDrCode);
            //���i����
            writer.Write(temp.GoodsName);
            //������
            writer.Write(temp.SalesOrderCount);
            //�[�i��
            writer.Write(temp.DeliveredGoodsCount);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���[�J�[����
            writer.Write(temp.MakerName);
            //�������i���[�J�[�R�[�h
            writer.Write(temp.PureGoodsMakerCd);
            //�������i���[�J�[����
            writer.Write(temp.PureMakerName);
            //�������i�ԍ�
            writer.Write(temp.PureGoodsNo);
            //�������i����
            writer.Write(temp.PureGoodsName);
            //�艿
            writer.Write(temp.ListPrice);
            //�P��
            writer.Write(temp.UnitPrice);
            //���i�⑫���
            writer.Write(temp.GoodsAddInfo);
            //�e���z
            writer.Write(temp.RoughRrofit);
            //�e����
            writer.Write(temp.RoughRate);
            //�񓚊���
            writer.Write(temp.AnswerLimitDate);
            //���l(����)
            writer.Write(temp.CommentDtl);
            //�I��
            writer.Write(temp.ShelfNo);
            //�ǉ��敪
            writer.Write(temp.AdditionalDivCd);
            //�����敪
            writer.Write(temp.CorrectDivCD);
            //�󒍃X�e�[�^�X
            writer.Write(temp.AcptAnOdrStatus);
            //����`�[�ԍ�
            writer.Write(temp.SalesSlipNum);
            //����s�ԍ�
            writer.Write(temp.SalesRowNo);
            //�݌ɋ敪
            writer.Write(temp.StockDiv);
            //�⍇���E�������
            writer.Write(temp.InqOrdDivCd);
            //�\������
            writer.Write(temp.DisplayOrder);
            //�L�����y�[���R�[�h
            writer.Write(temp.CampaignCode);
            //�L�����y�[������
            writer.Write(temp.CampaignName);
            //����`�[���v�i�ō��݁j
            writer.Write(temp.SalesTotalTaxInc);
            //���㏬�v�i�Łj
            writer.Write(temp.SalesSubtotalTax);
            //�┭�E�񓚎��
            writer.Write(temp.InqOrdAnsDivCd);
            //��M����
            writer.Write(temp.ReceiveDateTime);
            //�񓚍쐬�敪
            writer.Write(temp.AnswerCreateDiv);
            //�񓚔[��
            writer.Write(temp.AnswerDeliveryDate);
            //�┭���i��
            writer.Write(temp.InqGoodsName);
            //�񓚏��i��
            writer.Write(temp.AnsGoodsName);
            //�┭�������i�ԍ�
            writer.Write(temp.InqPureGoodsNo);
            //�񓚏������i�ԍ�
            writer.Write(temp.AnsPureGoodsNo);
            //�┭�������i��
            writer.Write(temp.InqPureGoodsName);
            //�񓚏������i��
            writer.Write(temp.AnsPureGoodsName);

        }

        /// <summary>
        ///  SCMAnsHistResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SCMAnsHistResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMAnsHistResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SCMAnsHistResultWork GetSCMAnsHistResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SCMAnsHistResultWork temp = new SCMAnsHistResultWork();

            //�⍇�����ƃR�[�h
            temp.InqOtherEpCd = reader.ReadString();
            //�⍇���拒�_�R�[�h
            temp.InqOtherSecCd = reader.ReadString();
            //���_����
            temp.SectionGuidNm = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ於��
            temp.CustomerName = reader.ReadString();
            //�⍇���ԍ�
            temp.InquiryNumber = reader.ReadInt64();
            //�X�V�N����
            temp.UpdateDate = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateTime = reader.ReadInt32();
            //�񓚋敪
            temp.AnswerDivCd = reader.ReadInt32();
            //�m���
            temp.JudgementDate = reader.ReadInt32();
            //�⍇���E�������l
            temp.InqOrdNote = reader.ReadString();
            //�⍇���]�ƈ��R�[�h
            temp.InqEmployeeCd = reader.ReadString();
            //�⍇���]�ƈ�����
            temp.InqEmployeeNm = reader.ReadString();
            //�񓚏]�ƈ��R�[�h
            temp.AnsEmployeeCd = reader.ReadString();
            //�񓚏]�ƈ�����
            temp.AnsEmployeeNm = reader.ReadString();
            //�⍇����
            temp.InquiryDate = reader.ReadInt32();
            //���^�������ԍ�
            temp.NumberPlate1Code = reader.ReadInt32();
            //���^�����ǖ���
            temp.NumberPlate1Name = reader.ReadString();
            //�ԗ��o�^�ԍ��i��ʁj
            temp.NumberPlate2 = reader.ReadString();
            //�ԗ��o�^�ԍ��i�J�i�j
            temp.NumberPlate3 = reader.ReadString();
            //�ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            temp.NumberPlate4 = reader.ReadInt32();
            //�^���w��ԍ�
            temp.ModelDesignationNo = reader.ReadInt32();
            //�ޕʔԍ�
            temp.CategoryNo = reader.ReadInt32();
            //���[�J�[�R�[�h
            temp.MakerCode = reader.ReadInt32();
            //���[�J�[����
            temp.CarMakerName = reader.ReadString();
            //�Ԏ�R�[�h
            temp.ModelCode = reader.ReadInt32();
            //�Ԏ�T�u�R�[�h
            temp.ModelSubCode = reader.ReadInt32();
            //�Ԏ햼
            temp.ModelName = reader.ReadString();
            //�Ԍ��،^��
            temp.CarInspectCertModel = reader.ReadString();
            //�^���i�t���^�j
            temp.FullModel = reader.ReadString();
            //�ԑ�ԍ�
            temp.FrameNo = reader.ReadString();
            //�ԑ�^��
            temp.FrameModel = reader.ReadString();
            //�V���V�[No
            temp.ChassisNo = reader.ReadString();
            //�ԗ��ŗL�ԍ�
            temp.CarProperNo = reader.ReadInt32();
            //���Y�N���iNUM�^�C�v�j
            temp.ProduceTypeOfYearNum = reader.ReadInt32();
            //�R�����g
            temp.Comment = reader.ReadString();
            //���y�A�J���[�R�[�h
            temp.RpColorCode = reader.ReadString();
            //�J���[����1
            temp.ColorName1 = reader.ReadString();
            //�g�����R�[�h
            temp.TrimCode = reader.ReadString();
            //�g��������
            temp.TrimName = reader.ReadString();
            //�ԗ����s����
            temp.Mileage = reader.ReadInt32();
            //�����I�u�W�F�N�g
            int equipObjLength = reader.ReadInt32();
            temp.EquipObj = reader.ReadBytes(equipObjLength);
            //�⍇���s�ԍ�
            temp.InqRowNumber = reader.ReadInt32();
            //�⍇���s�ԍ��}��
            temp.InqRowNumDerivedNo = reader.ReadInt32();
            //���i���
            temp.GoodsDivCd = reader.ReadInt32();
            //���T�C�N�����i���
            temp.RecyclePrtKindCode = reader.ReadInt32();
            //���T�C�N�����i��ʖ���
            temp.RecyclePrtKindName = reader.ReadString();
            //�[�i�敪
            temp.DeliveredGoodsDiv = reader.ReadInt32();
            //�戵�敪
            temp.HandleDivCode = reader.ReadInt32();
            //���i�`��
            temp.GoodsShape = reader.ReadInt32();
            //�[�i�m�F�敪
            temp.DelivrdGdsConfCd = reader.ReadInt32();
            //�[�i�����\���
            temp.DeliGdsCmpltDueDate = new DateTime(reader.ReadInt64());
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //BL���i�R�[�h�}��
            temp.BLGoodsDrCode = reader.ReadInt32();
            //���i����
            temp.GoodsName = reader.ReadString();
            //������
            temp.SalesOrderCount = reader.ReadDouble();
            //�[�i��
            temp.DeliveredGoodsCount = reader.ReadDouble();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���[�J�[����
            temp.MakerName = reader.ReadString();
            //�������i���[�J�[�R�[�h
            temp.PureGoodsMakerCd = reader.ReadInt32();
            //�������i���[�J�[����
            temp.PureMakerName = reader.ReadString();
            //�������i�ԍ�
            temp.PureGoodsNo = reader.ReadString();
            //�������i����
            temp.PureGoodsName = reader.ReadString();
            //�艿
            temp.ListPrice = reader.ReadInt64();
            //�P��
            temp.UnitPrice = reader.ReadInt64();
            //���i�⑫���
            temp.GoodsAddInfo = reader.ReadString();
            //�e���z
            temp.RoughRrofit = reader.ReadInt64();
            //�e����
            temp.RoughRate = reader.ReadDouble();
            //�񓚊���
            temp.AnswerLimitDate = reader.ReadInt32();
            //���l(����)
            temp.CommentDtl = reader.ReadString();
            //�I��
            temp.ShelfNo = reader.ReadString();
            //�ǉ��敪
            temp.AdditionalDivCd = reader.ReadInt32();
            //�����敪
            temp.CorrectDivCD = reader.ReadInt32();
            //�󒍃X�e�[�^�X
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //����`�[�ԍ�
            temp.SalesSlipNum = reader.ReadString();
            //����s�ԍ�
            temp.SalesRowNo = reader.ReadInt32();
            //�݌ɋ敪
            temp.StockDiv = reader.ReadInt32();
            //�⍇���E�������
            temp.InqOrdDivCd = reader.ReadInt32();
            //�\������
            temp.DisplayOrder = reader.ReadInt32();
            //�L�����y�[���R�[�h
            temp.CampaignCode = reader.ReadInt32();
            //�L�����y�[������
            temp.CampaignName = reader.ReadString();
            //����`�[���v�i�ō��݁j
            temp.SalesTotalTaxInc = reader.ReadInt64();
            //���㏬�v�i�Łj
            temp.SalesSubtotalTax = reader.ReadInt64();
            //�┭�E�񓚎��
            temp.InqOrdAnsDivCd = reader.ReadInt32();
            //��M����
            temp.ReceiveDateTime = reader.ReadInt64();
            //�񓚍쐬�敪
            temp.AnswerCreateDiv = reader.ReadInt32();
            //�񓚔[��
            temp.AnswerDeliveryDate = reader.ReadString();
            //�┭���i��
            temp.InqGoodsName = reader.ReadString();
            //�񓚏��i��
            temp.AnsGoodsName = reader.ReadString();
            //�┭�������i�ԍ�
            temp.InqPureGoodsNo = reader.ReadString();
            //�񓚏������i�ԍ�
            temp.AnsPureGoodsNo = reader.ReadString();
            //�┭�������i��
            temp.InqPureGoodsName = reader.ReadString();
            //�񓚏������i��
            temp.AnsPureGoodsName = reader.ReadString();


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
        /// <returns>SCMAnsHistResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMAnsHistResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SCMAnsHistResultWork temp = GetSCMAnsHistResultWork(reader, serInfo);
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
                    retValue = (SCMAnsHistResultWork[])lst.ToArray(typeof(SCMAnsHistResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

// 2009.08.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
#region �폜
//using System;
//using System.Collections;
//using Broadleaf.Library.Data;
//using Broadleaf.Library.Runtime.Serialization;
//using Broadleaf.Application.Resources;

//namespace Broadleaf.Application.Remoting.ParamData
//{
//    /// public class name:   SCMAnsHistResultWork
//    /// <summary>
//    ///                      SCM����E�񓚗����Ɖ�ʃN���X���[�N
//    /// </summary>
//    /// <remarks>
//    /// <br>note             :   SCM����E�񓚗����Ɖ�ʃN���X���[�N�w�b�_�t�@�C��</br>
//    /// <br>Programmer       :   ��������</br>
//    /// <br>Date             :    2009/4/13</br>
//    /// <br>Genarated Date   :   2009/06/19  (CSharp File Generated Date)</br>
//    /// <br>Update Note      :   </br>
//    /// </remarks>
//    [Serializable]
//    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
//    public class SCMAnsHistResultWork
//    {
//        /// <summary>�⍇�����ƃR�[�h</summary>
//        private string _inqOtherEpCd = "";

//        /// <summary>�⍇���拒�_�R�[�h</summary>
//        private string _inqOtherSecCd = "";

//        /// <summary>���_����</summary>
//        private string _sectionGuidNm = "";

//        /// <summary>���Ӑ�R�[�h</summary>
//        private Int32 _customerCode;

//        /// <summary>���Ӑ於��</summary>
//        private string _customerName = "";

//        /// <summary>�⍇���ԍ�</summary>
//        private Int64 _inquiryNumber;

//        /// <summary>�X�V�N����</summary>
//        /// <remarks>YYYYMMDD</remarks>
//        private DateTime _updateDate;

//        /// <summary>�X�V����</summary>
//        /// <remarks>HHMMSSXXX</remarks>
//        private Int32 _updateTime;

//        /// <summary>�񓚋敪</summary>
//        /// <remarks>0:�A�N�V�����Ȃ� 10:�ꕔ�� 20:�񓚊��� 30:���F 99:�L�����Z��</remarks>
//        private Int32 _answerDivCd;

//        /// <summary>�m���</summary>
//        /// <remarks>YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B</remarks>
//        private Int32 _judgementDate;

//        /// <summary>�⍇���E�������l</summary>
//        private string _inqOrdNote = "";

//        /// <summary>�⍇���]�ƈ��R�[�h</summary>
//        /// <remarks>�⍇�������]�ƈ��R�[�h</remarks>
//        private string _inqEmployeeCd = "";

//        /// <summary>�⍇���]�ƈ�����</summary>
//        /// <remarks>�⍇�������]�ƈ�����</remarks>
//        private string _inqEmployeeNm = "";

//        /// <summary>�񓚏]�ƈ��R�[�h</summary>
//        private string _ansEmployeeCd = "";

//        /// <summary>�񓚏]�ƈ�����</summary>
//        private string _ansEmployeeNm = "";

//        /// <summary>�⍇����</summary>
//        /// <remarks>YYYYMMDD</remarks>
//        private Int32 _inquiryDate;

//        /// <summary>���^�������ԍ�</summary>
//        private Int32 _numberPlate1Code;

//        /// <summary>���^�����ǖ���</summary>
//        private string _numberPlate1Name = "";

//        /// <summary>�ԗ��o�^�ԍ��i��ʁj</summary>
//        private string _numberPlate2 = "";

//        /// <summary>�ԗ��o�^�ԍ��i�J�i�j</summary>
//        private string _numberPlate3 = "";

//        /// <summary>�ԗ��o�^�ԍ��i�v���[�g�ԍ��j</summary>
//        private Int32 _numberPlate4;

//        /// <summary>�^���w��ԍ�</summary>
//        private Int32 _modelDesignationNo;

//        /// <summary>�ޕʔԍ�</summary>
//        private Int32 _categoryNo;

//        /// <summary>���[�J�[�R�[�h</summary>
//        /// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
//        private Int32 _makerCode;

//        /// <summary>���[�J�[����</summary>
//        private string _carMakerName = "";

//        /// <summary>�Ԏ�R�[�h</summary>
//        /// <remarks>�Ԗ��R�[�h(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
//        private Int32 _modelCode;

//        /// <summary>�Ԏ�T�u�R�[�h</summary>
//        /// <remarks>0�`899:�񋟕�,900�`հ�ް�o�^</remarks>
//        private Int32 _modelSubCode;

//        /// <summary>�Ԏ햼</summary>
//        private string _modelName = "";

//        /// <summary>�Ԍ��،^��</summary>
//        private string _carInspectCertModel = "";

//        /// <summary>�^���i�t���^�j</summary>
//        /// <remarks>�t���^��(44���p)</remarks>
//        private string _fullModel = "";

//        /// <summary>�ԑ�ԍ�</summary>
//        private string _frameNo = "";

//        /// <summary>�ԑ�^��</summary>
//        private string _frameModel = "";

//        /// <summary>�V���V�[No</summary>
//        private string _chassisNo = "";

//        /// <summary>�ԗ��ŗL�ԍ�</summary>
//        /// <remarks>���j�[�N�ȌŒ�ԍ�</remarks>
//        private Int32 _carProperNo;

//        /// <summary>���Y�N���iNUM�^�C�v�j</summary>
//        /// <remarks>YYYYMM</remarks>
//        private Int32 _produceTypeOfYearNum;

//        /// <summary>�R�����g</summary>
//        /// <remarks>�J�^���O�̃R�����g��P�ʁE�J���[���i�[</remarks>
//        private string _comment = "";

//        /// <summary>���y�A�J���[�R�[�h</summary>
//        /// <remarks>�J�^���O�̐F�R�[�h�i���y�A�p���V�Ԏ��ƈقȂ�ꍇ�j</remarks>
//        private string _rpColorCode = "";

//        /// <summary>�J���[����1</summary>
//        /// <remarks>��ʕ\���p��������</remarks>
//        private string _colorName1 = "";

//        /// <summary>�g�����R�[�h</summary>
//        private string _trimCode = "";

//        /// <summary>�g��������</summary>
//        private string _trimName = "";

//        /// <summary>�ԗ����s����</summary>
//        private Int32 _mileage;

//        /// <summary>�����I�u�W�F�N�g</summary>
//        private Byte[] _equipObj;

//        /// <summary>�⍇���s�ԍ�</summary>
//        private Int32 _inqRowNumber;

//        /// <summary>�⍇���s�ԍ��}��</summary>
//        private Int32 _inqRowNumDerivedNo;

//        /// <summary>���i���</summary>
//        /// <remarks>0:�������i 1:�D�Ǖ��i 2:���r���h 3:���� 4:���ϑ���</remarks>
//        private Int32 _goodsDivCd;

//        /// <summary>���T�C�N�����i���</summary>
//        private Int32 _recyclePrtKindCode;

//        /// <summary>���T�C�N�����i��ʖ���</summary>
//        private string _recyclePrtKindName = "";

//        /// <summary>�[�i�敪</summary>
//        /// <remarks>0:�z��,1:����</remarks>
//        private Int32 _deliveredGoodsDiv;

//        /// <summary>�戵�敪</summary>
//        /// <remarks>0:��舵���i,1:�[���m�F��,2:����舵���i</remarks>
//        private Int32 _handleDivCode;

//        /// <summary>���i�`��</summary>
//        /// <remarks>1:���i,2:�p�i</remarks>
//        private Int32 _goodsShape;

//        /// <summary>�[�i�m�F�敪</summary>
//        /// <remarks>0:���m�F,1:�m�F</remarks>
//        private Int32 _delivrdGdsConfCd;

//        /// <summary>�[�i�����\���</summary>
//        /// <remarks>�[�i�\����t YYYYMMDD</remarks>
//        private DateTime _deliGdsCmpltDueDate;

//        /// <summary>BL���i�R�[�h</summary>
//        private Int32 _bLGoodsCode;

//        /// <summary>BL���i�R�[�h�}��</summary>
//        private Int32 _bLGoodsDrCode;

//        /// <summary>�┭���i��</summary>
//        /// <remarks>(���p�S�p����)</remarks>
//        private string _inqGoodsName = "";

//        /// <summary>�񓚏��i��</summary>
//        /// <remarks>(���p�S�p����)</remarks>
//        private string _ansGoodsName = "";

//        /// <summary>������</summary>
//        private Double _salesOrderCount;

//        /// <summary>�[�i��</summary>
//        private Double _deliveredGoodsCount;

//        /// <summary>���i�ԍ�</summary>
//        private string _goodsNo = "";

//        /// <summary>���i���[�J�[�R�[�h</summary>
//        private Int32 _goodsMakerCd;

//        /// <summary>���[�J�[����</summary>
//        private string _makerName = "";

//        /// <summary>�������i���[�J�[�R�[�h</summary>
//        private Int32 _pureGoodsMakerCd;

//        /// <summary>�������i���[�J�[����</summary>
//        private string _pureMakerName = "";

//        /// <summary>�┭�������i�ԍ�</summary>
//        /// <remarks>(���p�̂�)</remarks>
//        private string _inqPureGoodsNo = "";

//        /// <summary>�񓚏������i�ԍ�</summary>
//        /// <remarks>(���p�̂�)</remarks>
//        private string _ansPureGoodsNo = "";

//        /// <summary>�┭�������i����</summary>
//        private string _inqPureGoodsName = "";

//        /// <summary>�񓚏������i����</summary>
//        private string _ansPureGoodsName = "";

//        /// <summary>�艿</summary>
//        /// <remarks>0:�I�[�v�����i</remarks>
//        private Int64 _listPrice;

//        /// <summary>�P��</summary>
//        private Int64 _unitPrice;

//        /// <summary>���i�⑫���</summary>
//        private string _goodsAddInfo = "";

//        /// <summary>�e���z</summary>
//        private Int64 _roughRrofit;

//        /// <summary>�e����</summary>
//        private Double _roughRate;

//        /// <summary>�񓚊���</summary>
//        /// <remarks>YYYYMMDD</remarks>
//        private Int32 _answerLimitDate;

//        /// <summary>���l(����)</summary>
//        private string _commentDtl = "";

//        /// <summary>�I��</summary>
//        private string _shelfNo = "";

//        /// <summary>�ǉ��敪</summary>
//        private Int32 _additionalDivCd;

//        /// <summary>�����敪</summary>
//        private Int32 _correctDivCD;

//        /// <summary>�󒍃X�e�[�^�X</summary>
//        /// <remarks>10:����,20:��,30:����</remarks>
//        private Int32 _acptAnOdrStatus;

//        /// <summary>����`�[�ԍ�</summary>
//        /// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
//        private string _salesSlipNum = "";

//        /// <summary>����s�ԍ�</summary>
//        private Int32 _salesRowNo;

//        /// <summary>�݌ɋ敪</summary>
//        /// <remarks>�ϑ��݌ɁA���Ӑ�݌ɁA�D��q�ɁA���Ѝ݌ɁA��݌�</remarks>
//        private Int32 _stockDiv;

//        /// <summary>�⍇���E�������</summary>
//        /// <remarks>1:�⍇�� 2:����</remarks>
//        private Int32 _inqOrdDivCd;

//        /// <summary>�\������</summary>
//        private Int32 _displayOrder;

//        /// <summary>�L�����y�[���R�[�h</summary>
//        private Int32 _campaignCode;

//        /// <summary>�L�����y�[������</summary>
//        private string _campaignName = "";

//        /// <summary>����`�[���v�i�ō��݁j</summary>
//        /// <remarks>���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz</remarks>
//        private Int64 _salesTotalTaxInc;

//        /// <summary>���㏬�v�i�Łj</summary>
//        /// <remarks>�l����̐Ŋz�i�O�ŕ��A���ŕ��̍��v�j</remarks>
//        private Int64 _salesSubtotalTax;

//        /// <summary>�┭�E�񓚎��</summary>
//        /// <remarks>1:�⍇���E���� 2:��</remarks>
//        private Int32 _inqOrdAnsDivCd;

//        /// <summary>��M����</summary>
//        /// <remarks>�iDateTime:���x��100�i�m�b�j</remarks>
//        private Int64 _receiveDateTime;

//        /// <summary>�񓚔[��</summary>
//        private string _answerDeliveryDate = "";


//        /// public propaty name  :  InqOtherEpCd
//        /// <summary>�⍇�����ƃR�[�h�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �⍇�����ƃR�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string InqOtherEpCd
//        {
//            get { return _inqOtherEpCd; }
//            set { _inqOtherEpCd = value; }
//        }

//        /// public propaty name  :  InqOtherSecCd
//        /// <summary>�⍇���拒�_�R�[�h�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �⍇���拒�_�R�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string InqOtherSecCd
//        {
//            get { return _inqOtherSecCd; }
//            set { _inqOtherSecCd = value; }
//        }

//        /// public propaty name  :  SectionGuidNm
//        /// <summary>���_���̃v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���_���̃v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string SectionGuidNm
//        {
//            get { return _sectionGuidNm; }
//            set { _sectionGuidNm = value; }
//        }

//        /// public propaty name  :  CustomerCode
//        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 CustomerCode
//        {
//            get { return _customerCode; }
//            set { _customerCode = value; }
//        }

//        /// public propaty name  :  CustomerName
//        /// <summary>���Ӑ於�̃v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���Ӑ於�̃v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string CustomerName
//        {
//            get { return _customerName; }
//            set { _customerName = value; }
//        }

//        /// public propaty name  :  InquiryNumber
//        /// <summary>�⍇���ԍ��v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �⍇���ԍ��v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int64 InquiryNumber
//        {
//            get { return _inquiryNumber; }
//            set { _inquiryNumber = value; }
//        }

//        /// public propaty name  :  UpdateDate
//        /// <summary>�X�V�N�����v���p�e�B</summary>
//        /// <value>YYYYMMDD</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �X�V�N�����v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public DateTime UpdateDate
//        {
//            get { return _updateDate; }
//            set { _updateDate = value; }
//        }

//        /// public propaty name  :  UpdateTime
//        /// <summary>�X�V���ԃv���p�e�B</summary>
//        /// <value>HHMMSSXXX</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �X�V���ԃv���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 UpdateTime
//        {
//            get { return _updateTime; }
//            set { _updateTime = value; }
//        }

//        /// public propaty name  :  AnswerDivCd
//        /// <summary>�񓚋敪�v���p�e�B</summary>
//        /// <value>0:�A�N�V�����Ȃ� 10:�ꕔ�� 20:�񓚊��� 30:���F 99:�L�����Z��</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �񓚋敪�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 AnswerDivCd
//        {
//            get { return _answerDivCd; }
//            set { _answerDivCd = value; }
//        }

//        /// public propaty name  :  JudgementDate
//        /// <summary>�m����v���p�e�B</summary>
//        /// <value>YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �m����v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 JudgementDate
//        {
//            get { return _judgementDate; }
//            set { _judgementDate = value; }
//        }

//        /// public propaty name  :  InqOrdNote
//        /// <summary>�⍇���E�������l�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �⍇���E�������l�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string InqOrdNote
//        {
//            get { return _inqOrdNote; }
//            set { _inqOrdNote = value; }
//        }

//        /// public propaty name  :  InqEmployeeCd
//        /// <summary>�⍇���]�ƈ��R�[�h�v���p�e�B</summary>
//        /// <value>�⍇�������]�ƈ��R�[�h</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �⍇���]�ƈ��R�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string InqEmployeeCd
//        {
//            get { return _inqEmployeeCd; }
//            set { _inqEmployeeCd = value; }
//        }

//        /// public propaty name  :  InqEmployeeNm
//        /// <summary>�⍇���]�ƈ����̃v���p�e�B</summary>
//        /// <value>�⍇�������]�ƈ�����</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �⍇���]�ƈ����̃v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string InqEmployeeNm
//        {
//            get { return _inqEmployeeNm; }
//            set { _inqEmployeeNm = value; }
//        }

//        /// public propaty name  :  AnsEmployeeCd
//        /// <summary>�񓚏]�ƈ��R�[�h�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �񓚏]�ƈ��R�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string AnsEmployeeCd
//        {
//            get { return _ansEmployeeCd; }
//            set { _ansEmployeeCd = value; }
//        }

//        /// public propaty name  :  AnsEmployeeNm
//        /// <summary>�񓚏]�ƈ����̃v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �񓚏]�ƈ����̃v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string AnsEmployeeNm
//        {
//            get { return _ansEmployeeNm; }
//            set { _ansEmployeeNm = value; }
//        }

//        /// public propaty name  :  InquiryDate
//        /// <summary>�⍇�����v���p�e�B</summary>
//        /// <value>YYYYMMDD</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �⍇�����v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 InquiryDate
//        {
//            get { return _inquiryDate; }
//            set { _inquiryDate = value; }
//        }

//        /// public propaty name  :  NumberPlate1Code
//        /// <summary>���^�������ԍ��v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���^�������ԍ��v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 NumberPlate1Code
//        {
//            get { return _numberPlate1Code; }
//            set { _numberPlate1Code = value; }
//        }

//        /// public propaty name  :  NumberPlate1Name
//        /// <summary>���^�����ǖ��̃v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���^�����ǖ��̃v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string NumberPlate1Name
//        {
//            get { return _numberPlate1Name; }
//            set { _numberPlate1Name = value; }
//        }

//        /// public propaty name  :  NumberPlate2
//        /// <summary>�ԗ��o�^�ԍ��i��ʁj�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �ԗ��o�^�ԍ��i��ʁj�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string NumberPlate2
//        {
//            get { return _numberPlate2; }
//            set { _numberPlate2 = value; }
//        }

//        /// public propaty name  :  NumberPlate3
//        /// <summary>�ԗ��o�^�ԍ��i�J�i�j�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �ԗ��o�^�ԍ��i�J�i�j�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string NumberPlate3
//        {
//            get { return _numberPlate3; }
//            set { _numberPlate3 = value; }
//        }

//        /// public propaty name  :  NumberPlate4
//        /// <summary>�ԗ��o�^�ԍ��i�v���[�g�ԍ��j�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �ԗ��o�^�ԍ��i�v���[�g�ԍ��j�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 NumberPlate4
//        {
//            get { return _numberPlate4; }
//            set { _numberPlate4 = value; }
//        }

//        /// public propaty name  :  ModelDesignationNo
//        /// <summary>�^���w��ԍ��v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �^���w��ԍ��v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 ModelDesignationNo
//        {
//            get { return _modelDesignationNo; }
//            set { _modelDesignationNo = value; }
//        }

//        /// public propaty name  :  CategoryNo
//        /// <summary>�ޕʔԍ��v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �ޕʔԍ��v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 CategoryNo
//        {
//            get { return _categoryNo; }
//            set { _categoryNo = value; }
//        }

//        /// public propaty name  :  MakerCode
//        /// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
//        /// <value>1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���[�J�[�R�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 MakerCode
//        {
//            get { return _makerCode; }
//            set { _makerCode = value; }
//        }

//        /// public propaty name  :  CarMakerName
//        /// <summary>���[�J�[���̃v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���[�J�[���̃v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string CarMakerName
//        {
//            get { return _carMakerName; }
//            set { _carMakerName = value; }
//        }

//        /// public propaty name  :  ModelCode
//        /// <summary>�Ԏ�R�[�h�v���p�e�B</summary>
//        /// <value>�Ԗ��R�[�h(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �Ԏ�R�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 ModelCode
//        {
//            get { return _modelCode; }
//            set { _modelCode = value; }
//        }

//        /// public propaty name  :  ModelSubCode
//        /// <summary>�Ԏ�T�u�R�[�h�v���p�e�B</summary>
//        /// <value>0�`899:�񋟕�,900�`հ�ް�o�^</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �Ԏ�T�u�R�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 ModelSubCode
//        {
//            get { return _modelSubCode; }
//            set { _modelSubCode = value; }
//        }

//        /// public propaty name  :  ModelName
//        /// <summary>�Ԏ햼�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �Ԏ햼�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string ModelName
//        {
//            get { return _modelName; }
//            set { _modelName = value; }
//        }

//        /// public propaty name  :  CarInspectCertModel
//        /// <summary>�Ԍ��،^���v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �Ԍ��،^���v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string CarInspectCertModel
//        {
//            get { return _carInspectCertModel; }
//            set { _carInspectCertModel = value; }
//        }

//        /// public propaty name  :  FullModel
//        /// <summary>�^���i�t���^�j�v���p�e�B</summary>
//        /// <value>�t���^��(44���p)</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �^���i�t���^�j�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string FullModel
//        {
//            get { return _fullModel; }
//            set { _fullModel = value; }
//        }

//        /// public propaty name  :  FrameNo
//        /// <summary>�ԑ�ԍ��v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �ԑ�ԍ��v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string FrameNo
//        {
//            get { return _frameNo; }
//            set { _frameNo = value; }
//        }

//        /// public propaty name  :  FrameModel
//        /// <summary>�ԑ�^���v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �ԑ�^���v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string FrameModel
//        {
//            get { return _frameModel; }
//            set { _frameModel = value; }
//        }

//        /// public propaty name  :  ChassisNo
//        /// <summary>�V���V�[No�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �V���V�[No�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string ChassisNo
//        {
//            get { return _chassisNo; }
//            set { _chassisNo = value; }
//        }

//        /// public propaty name  :  CarProperNo
//        /// <summary>�ԗ��ŗL�ԍ��v���p�e�B</summary>
//        /// <value>���j�[�N�ȌŒ�ԍ�</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �ԗ��ŗL�ԍ��v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 CarProperNo
//        {
//            get { return _carProperNo; }
//            set { _carProperNo = value; }
//        }

//        /// public propaty name  :  ProduceTypeOfYearNum
//        /// <summary>���Y�N���iNUM�^�C�v�j�v���p�e�B</summary>
//        /// <value>YYYYMM</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���Y�N���iNUM�^�C�v�j�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 ProduceTypeOfYearNum
//        {
//            get { return _produceTypeOfYearNum; }
//            set { _produceTypeOfYearNum = value; }
//        }

//        /// public propaty name  :  Comment
//        /// <summary>�R�����g�v���p�e�B</summary>
//        /// <value>�J�^���O�̃R�����g��P�ʁE�J���[���i�[</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �R�����g�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string Comment
//        {
//            get { return _comment; }
//            set { _comment = value; }
//        }

//        /// public propaty name  :  RpColorCode
//        /// <summary>���y�A�J���[�R�[�h�v���p�e�B</summary>
//        /// <value>�J�^���O�̐F�R�[�h�i���y�A�p���V�Ԏ��ƈقȂ�ꍇ�j</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���y�A�J���[�R�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string RpColorCode
//        {
//            get { return _rpColorCode; }
//            set { _rpColorCode = value; }
//        }

//        /// public propaty name  :  ColorName1
//        /// <summary>�J���[����1�v���p�e�B</summary>
//        /// <value>��ʕ\���p��������</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �J���[����1�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string ColorName1
//        {
//            get { return _colorName1; }
//            set { _colorName1 = value; }
//        }

//        /// public propaty name  :  TrimCode
//        /// <summary>�g�����R�[�h�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �g�����R�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string TrimCode
//        {
//            get { return _trimCode; }
//            set { _trimCode = value; }
//        }

//        /// public propaty name  :  TrimName
//        /// <summary>�g�������̃v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �g�������̃v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string TrimName
//        {
//            get { return _trimName; }
//            set { _trimName = value; }
//        }

//        /// public propaty name  :  Mileage
//        /// <summary>�ԗ����s�����v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �ԗ����s�����v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 Mileage
//        {
//            get { return _mileage; }
//            set { _mileage = value; }
//        }

//        /// public propaty name  :  EquipObj
//        /// <summary>�����I�u�W�F�N�g�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �����I�u�W�F�N�g�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Byte[] EquipObj
//        {
//            get { return _equipObj; }
//            set { _equipObj = value; }
//        }

//        /// public propaty name  :  InqRowNumber
//        /// <summary>�⍇���s�ԍ��v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �⍇���s�ԍ��v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 InqRowNumber
//        {
//            get { return _inqRowNumber; }
//            set { _inqRowNumber = value; }
//        }

//        /// public propaty name  :  InqRowNumDerivedNo
//        /// <summary>�⍇���s�ԍ��}�ԃv���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �⍇���s�ԍ��}�ԃv���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 InqRowNumDerivedNo
//        {
//            get { return _inqRowNumDerivedNo; }
//            set { _inqRowNumDerivedNo = value; }
//        }

//        /// public propaty name  :  GoodsDivCd
//        /// <summary>���i��ʃv���p�e�B</summary>
//        /// <value>0:�������i 1:�D�Ǖ��i 2:���r���h 3:���� 4:���ϑ���</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���i��ʃv���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 GoodsDivCd
//        {
//            get { return _goodsDivCd; }
//            set { _goodsDivCd = value; }
//        }

//        /// public propaty name  :  RecyclePrtKindCode
//        /// <summary>���T�C�N�����i��ʃv���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���T�C�N�����i��ʃv���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 RecyclePrtKindCode
//        {
//            get { return _recyclePrtKindCode; }
//            set { _recyclePrtKindCode = value; }
//        }

//        /// public propaty name  :  RecyclePrtKindName
//        /// <summary>���T�C�N�����i��ʖ��̃v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���T�C�N�����i��ʖ��̃v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string RecyclePrtKindName
//        {
//            get { return _recyclePrtKindName; }
//            set { _recyclePrtKindName = value; }
//        }

//        /// public propaty name  :  DeliveredGoodsDiv
//        /// <summary>�[�i�敪�v���p�e�B</summary>
//        /// <value>0:�z��,1:����</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �[�i�敪�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 DeliveredGoodsDiv
//        {
//            get { return _deliveredGoodsDiv; }
//            set { _deliveredGoodsDiv = value; }
//        }

//        /// public propaty name  :  HandleDivCode
//        /// <summary>�戵�敪�v���p�e�B</summary>
//        /// <value>0:��舵���i,1:�[���m�F��,2:����舵���i</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �戵�敪�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 HandleDivCode
//        {
//            get { return _handleDivCode; }
//            set { _handleDivCode = value; }
//        }

//        /// public propaty name  :  GoodsShape
//        /// <summary>���i�`�ԃv���p�e�B</summary>
//        /// <value>1:���i,2:�p�i</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���i�`�ԃv���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 GoodsShape
//        {
//            get { return _goodsShape; }
//            set { _goodsShape = value; }
//        }

//        /// public propaty name  :  DelivrdGdsConfCd
//        /// <summary>�[�i�m�F�敪�v���p�e�B</summary>
//        /// <value>0:���m�F,1:�m�F</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �[�i�m�F�敪�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 DelivrdGdsConfCd
//        {
//            get { return _delivrdGdsConfCd; }
//            set { _delivrdGdsConfCd = value; }
//        }

//        /// public propaty name  :  DeliGdsCmpltDueDate
//        /// <summary>�[�i�����\����v���p�e�B</summary>
//        /// <value>�[�i�\����t YYYYMMDD</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �[�i�����\����v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public DateTime DeliGdsCmpltDueDate
//        {
//            get { return _deliGdsCmpltDueDate; }
//            set { _deliGdsCmpltDueDate = value; }
//        }

//        /// public propaty name  :  BLGoodsCode
//        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 BLGoodsCode
//        {
//            get { return _bLGoodsCode; }
//            set { _bLGoodsCode = value; }
//        }

//        /// public propaty name  :  BLGoodsDrCode
//        /// <summary>BL���i�R�[�h�}�ԃv���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   BL���i�R�[�h�}�ԃv���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 BLGoodsDrCode
//        {
//            get { return _bLGoodsDrCode; }
//            set { _bLGoodsDrCode = value; }
//        }

//        /// public propaty name  :  InqGoodsName
//        /// <summary>�┭���i���v���p�e�B</summary>
//        /// <value>(���p�S�p����)</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �┭���i���v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string InqGoodsName
//        {
//            get { return _inqGoodsName; }
//            set { _inqGoodsName = value; }
//        }

//        /// public propaty name  :  AnsGoodsName
//        /// <summary>�񓚏��i���v���p�e�B</summary>
//        /// <value>(���p�S�p����)</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �񓚏��i���v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string AnsGoodsName
//        {
//            get { return _ansGoodsName; }
//            set { _ansGoodsName = value; }
//        }

//        /// public propaty name  :  SalesOrderCount
//        /// <summary>�������v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �������v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Double SalesOrderCount
//        {
//            get { return _salesOrderCount; }
//            set { _salesOrderCount = value; }
//        }

//        /// public propaty name  :  DeliveredGoodsCount
//        /// <summary>�[�i���v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �[�i���v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Double DeliveredGoodsCount
//        {
//            get { return _deliveredGoodsCount; }
//            set { _deliveredGoodsCount = value; }
//        }

//        /// public propaty name  :  GoodsNo
//        /// <summary>���i�ԍ��v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���i�ԍ��v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string GoodsNo
//        {
//            get { return _goodsNo; }
//            set { _goodsNo = value; }
//        }

//        /// public propaty name  :  GoodsMakerCd
//        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 GoodsMakerCd
//        {
//            get { return _goodsMakerCd; }
//            set { _goodsMakerCd = value; }
//        }

//        /// public propaty name  :  MakerName
//        /// <summary>���[�J�[���̃v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���[�J�[���̃v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string MakerName
//        {
//            get { return _makerName; }
//            set { _makerName = value; }
//        }

//        /// public propaty name  :  PureGoodsMakerCd
//        /// <summary>�������i���[�J�[�R�[�h�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �������i���[�J�[�R�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 PureGoodsMakerCd
//        {
//            get { return _pureGoodsMakerCd; }
//            set { _pureGoodsMakerCd = value; }
//        }

//        /// public propaty name  :  PureMakerName
//        /// <summary>�������i���[�J�[���̃v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �������i���[�J�[���̃v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string PureMakerName
//        {
//            get { return _pureMakerName; }
//            set { _pureMakerName = value; }
//        }

//        /// public propaty name  :  InqPureGoodsNo
//        /// <summary>�┭�������i�ԍ��v���p�e�B</summary>
//        /// <value>(���p�̂�)</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �┭�������i�ԍ��v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string InqPureGoodsNo
//        {
//            get { return _inqPureGoodsNo; }
//            set { _inqPureGoodsNo = value; }
//        }

//        /// public propaty name  :  AnsPureGoodsNo
//        /// <summary>�񓚏������i�ԍ��v���p�e�B</summary>
//        /// <value>(���p�̂�)</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �񓚏������i�ԍ��v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string AnsPureGoodsNo
//        {
//            get { return _ansPureGoodsNo; }
//            set { _ansPureGoodsNo = value; }
//        }

//        /// public propaty name  :  InqPureGoodsName
//        /// <summary>�┭�������i���̃v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �┭�������i���̃v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string InqPureGoodsName
//        {
//            get { return _inqPureGoodsName; }
//            set { _inqPureGoodsName = value; }
//        }

//        /// public propaty name  :  AnsPureGoodsName
//        /// <summary>�񓚏������i���̃v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �񓚏������i���̃v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string AnsPureGoodsName
//        {
//            get { return _ansPureGoodsName; }
//            set { _ansPureGoodsName = value; }
//        }

//        /// public propaty name  :  ListPrice
//        /// <summary>�艿�v���p�e�B</summary>
//        /// <value>0:�I�[�v�����i</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �艿�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int64 ListPrice
//        {
//            get { return _listPrice; }
//            set { _listPrice = value; }
//        }

//        /// public propaty name  :  UnitPrice
//        /// <summary>�P���v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �P���v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int64 UnitPrice
//        {
//            get { return _unitPrice; }
//            set { _unitPrice = value; }
//        }

//        /// public propaty name  :  GoodsAddInfo
//        /// <summary>���i�⑫���v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���i�⑫���v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string GoodsAddInfo
//        {
//            get { return _goodsAddInfo; }
//            set { _goodsAddInfo = value; }
//        }

//        /// public propaty name  :  RoughRrofit
//        /// <summary>�e���z�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �e���z�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int64 RoughRrofit
//        {
//            get { return _roughRrofit; }
//            set { _roughRrofit = value; }
//        }

//        /// public propaty name  :  RoughRate
//        /// <summary>�e�����v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �e�����v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Double RoughRate
//        {
//            get { return _roughRate; }
//            set { _roughRate = value; }
//        }

//        /// public propaty name  :  AnswerLimitDate
//        /// <summary>�񓚊����v���p�e�B</summary>
//        /// <value>YYYYMMDD</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �񓚊����v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 AnswerLimitDate
//        {
//            get { return _answerLimitDate; }
//            set { _answerLimitDate = value; }
//        }

//        /// public propaty name  :  CommentDtl
//        /// <summary>���l(����)�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���l(����)�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string CommentDtl
//        {
//            get { return _commentDtl; }
//            set { _commentDtl = value; }
//        }

//        /// public propaty name  :  ShelfNo
//        /// <summary>�I�ԃv���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �I�ԃv���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string ShelfNo
//        {
//            get { return _shelfNo; }
//            set { _shelfNo = value; }
//        }

//        /// public propaty name  :  AdditionalDivCd
//        /// <summary>�ǉ��敪�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �ǉ��敪�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 AdditionalDivCd
//        {
//            get { return _additionalDivCd; }
//            set { _additionalDivCd = value; }
//        }

//        /// public propaty name  :  CorrectDivCD
//        /// <summary>�����敪�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �����敪�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 CorrectDivCD
//        {
//            get { return _correctDivCD; }
//            set { _correctDivCD = value; }
//        }

//        /// public propaty name  :  AcptAnOdrStatus
//        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
//        /// <value>10:����,20:��,30:����</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 AcptAnOdrStatus
//        {
//            get { return _acptAnOdrStatus; }
//            set { _acptAnOdrStatus = value; }
//        }

//        /// public propaty name  :  SalesSlipNum
//        /// <summary>����`�[�ԍ��v���p�e�B</summary>
//        /// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string SalesSlipNum
//        {
//            get { return _salesSlipNum; }
//            set { _salesSlipNum = value; }
//        }

//        /// public propaty name  :  SalesRowNo
//        /// <summary>����s�ԍ��v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ����s�ԍ��v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 SalesRowNo
//        {
//            get { return _salesRowNo; }
//            set { _salesRowNo = value; }
//        }

//        /// public propaty name  :  StockDiv
//        /// <summary>�݌ɋ敪�v���p�e�B</summary>
//        /// <value>�ϑ��݌ɁA���Ӑ�݌ɁA�D��q�ɁA���Ѝ݌ɁA��݌�</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �݌ɋ敪�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 StockDiv
//        {
//            get { return _stockDiv; }
//            set { _stockDiv = value; }
//        }

//        /// public propaty name  :  InqOrdDivCd
//        /// <summary>�⍇���E������ʃv���p�e�B</summary>
//        /// <value>1:�⍇�� 2:����</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �⍇���E������ʃv���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 InqOrdDivCd
//        {
//            get { return _inqOrdDivCd; }
//            set { _inqOrdDivCd = value; }
//        }

//        /// public propaty name  :  DisplayOrder
//        /// <summary>�\�����ʃv���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �\�����ʃv���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 DisplayOrder
//        {
//            get { return _displayOrder; }
//            set { _displayOrder = value; }
//        }

//        /// public propaty name  :  CampaignCode
//        /// <summary>�L�����y�[���R�[�h�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �L�����y�[���R�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 CampaignCode
//        {
//            get { return _campaignCode; }
//            set { _campaignCode = value; }
//        }

//        /// public propaty name  :  CampaignName
//        /// <summary>�L�����y�[�����̃v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �L�����y�[�����̃v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string CampaignName
//        {
//            get { return _campaignName; }
//            set { _campaignName = value; }
//        }

//        /// public propaty name  :  SalesTotalTaxInc
//        /// <summary>����`�[���v�i�ō��݁j�v���p�e�B</summary>
//        /// <value>���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ����`�[���v�i�ō��݁j�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int64 SalesTotalTaxInc
//        {
//            get { return _salesTotalTaxInc; }
//            set { _salesTotalTaxInc = value; }
//        }

//        /// public propaty name  :  SalesSubtotalTax
//        /// <summary>���㏬�v�i�Łj�v���p�e�B</summary>
//        /// <value>�l����̐Ŋz�i�O�ŕ��A���ŕ��̍��v�j</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���㏬�v�i�Łj�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int64 SalesSubtotalTax
//        {
//            get { return _salesSubtotalTax; }
//            set { _salesSubtotalTax = value; }
//        }

//        /// public propaty name  :  InqOrdAnsDivCd
//        /// <summary>�┭�E�񓚎�ʃv���p�e�B</summary>
//        /// <value>1:�⍇���E���� 2:��</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �┭�E�񓚎�ʃv���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 InqOrdAnsDivCd
//        {
//            get { return _inqOrdAnsDivCd; }
//            set { _inqOrdAnsDivCd = value; }
//        }

//        /// public propaty name  :  ReceiveDateTime
//        /// <summary>��M�����v���p�e�B</summary>
//        /// <value>�iDateTime:���x��100�i�m�b�j</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ��M�����v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int64 ReceiveDateTime
//        {
//            get { return _receiveDateTime; }
//            set { _receiveDateTime = value; }
//        }

//        /// public propaty name  :  AnswerDeliveryDate
//        /// <summary>�񓚔[���v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �񓚔[���v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string AnswerDeliveryDate
//        {
//            get { return _answerDeliveryDate; }
//            set { _answerDeliveryDate = value; }
//        }


//        /// <summary>
//        /// SCM����E�񓚗����Ɖ�ʃN���X���[�N�R���X�g���N�^
//        /// </summary>
//        /// <returns>SCMAnsHistResultWork�N���X�̃C���X�^���X</returns>
//        /// <remarks>
//        /// <br>Note�@�@�@�@�@�@ :   SCMAnsHistResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public SCMAnsHistResultWork()
//        {
//        }

//    }

//    /// <summary>
//    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
//    /// </summary>
//    /// <returns>SCMAnsHistResultWork�N���X�̃C���X�^���X(object)</returns>
//    /// <remarks>
//    /// <br>Note�@�@�@�@�@�@ :   SCMAnsHistResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
//    /// <br>Programer        :   ��������</br>
//    /// </remarks>
//    public class SCMAnsHistResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
//    {
//        #region ICustomSerializationSurrogate �����o

//        /// <summary>
//        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
//        /// </summary>
//        /// <remarks>
//        /// <br>Note�@�@�@�@�@�@ :   SCMAnsHistResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public void Serialize(System.IO.BinaryWriter writer, object graph)
//        {
//            // TODO:  SCMAnsHistResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
//            if (writer == null)
//                throw new ArgumentNullException();

//            if (graph != null && !(graph is SCMAnsHistResultWork || graph is ArrayList || graph is SCMAnsHistResultWork[]))
//                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SCMAnsHistResultWork).FullName));

//            if (graph != null && graph is SCMAnsHistResultWork)
//            {
//                Type t = graph.GetType();
//                if (!CustomFormatterServices.NeedCustomSerialization(t))
//                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
//            }

//            //SerializationTypeInfo
//            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMAnsHistResultWork");

//            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
//            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
//            if (graph is ArrayList)
//            {
//                serInfo.RetTypeInfo = 0;
//                occurrence = ((ArrayList)graph).Count;
//            }
//            else if (graph is SCMAnsHistResultWork[])
//            {
//                serInfo.RetTypeInfo = 2;
//                occurrence = ((SCMAnsHistResultWork[])graph).Length;
//            }
//            else if (graph is SCMAnsHistResultWork)
//            {
//                serInfo.RetTypeInfo = 1;
//                occurrence = 1;
//            }

//            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

//            //�⍇�����ƃR�[�h
//            serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
//            //�⍇���拒�_�R�[�h
//            serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
//            //���_����
//            serInfo.MemberInfo.Add(typeof(string)); //SectionGuidNm
//            //���Ӑ�R�[�h
//            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
//            //���Ӑ於��
//            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
//            //�⍇���ԍ�
//            serInfo.MemberInfo.Add(typeof(Int64)); //InquiryNumber
//            //�X�V�N����
//            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDate
//            //�X�V����
//            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateTime
//            //�񓚋敪
//            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDivCd
//            //�m���
//            serInfo.MemberInfo.Add(typeof(Int32)); //JudgementDate
//            //�⍇���E�������l
//            serInfo.MemberInfo.Add(typeof(string)); //InqOrdNote
//            //�⍇���]�ƈ��R�[�h
//            serInfo.MemberInfo.Add(typeof(string)); //InqEmployeeCd
//            //�⍇���]�ƈ�����
//            serInfo.MemberInfo.Add(typeof(string)); //InqEmployeeNm
//            //�񓚏]�ƈ��R�[�h
//            serInfo.MemberInfo.Add(typeof(string)); //AnsEmployeeCd
//            //�񓚏]�ƈ�����
//            serInfo.MemberInfo.Add(typeof(string)); //AnsEmployeeNm
//            //�⍇����
//            serInfo.MemberInfo.Add(typeof(Int32)); //InquiryDate
//            //���^�������ԍ�
//            serInfo.MemberInfo.Add(typeof(Int32)); //NumberPlate1Code
//            //���^�����ǖ���
//            serInfo.MemberInfo.Add(typeof(string)); //NumberPlate1Name
//            //�ԗ��o�^�ԍ��i��ʁj
//            serInfo.MemberInfo.Add(typeof(string)); //NumberPlate2
//            //�ԗ��o�^�ԍ��i�J�i�j
//            serInfo.MemberInfo.Add(typeof(string)); //NumberPlate3
//            //�ԗ��o�^�ԍ��i�v���[�g�ԍ��j
//            serInfo.MemberInfo.Add(typeof(Int32)); //NumberPlate4
//            //�^���w��ԍ�
//            serInfo.MemberInfo.Add(typeof(Int32)); //ModelDesignationNo
//            //�ޕʔԍ�
//            serInfo.MemberInfo.Add(typeof(Int32)); //CategoryNo
//            //���[�J�[�R�[�h
//            serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
//            //���[�J�[����
//            serInfo.MemberInfo.Add(typeof(string)); //CarMakerName
//            //�Ԏ�R�[�h
//            serInfo.MemberInfo.Add(typeof(Int32)); //ModelCode
//            //�Ԏ�T�u�R�[�h
//            serInfo.MemberInfo.Add(typeof(Int32)); //ModelSubCode
//            //�Ԏ햼
//            serInfo.MemberInfo.Add(typeof(string)); //ModelName
//            //�Ԍ��،^��
//            serInfo.MemberInfo.Add(typeof(string)); //CarInspectCertModel
//            //�^���i�t���^�j
//            serInfo.MemberInfo.Add(typeof(string)); //FullModel
//            //�ԑ�ԍ�
//            serInfo.MemberInfo.Add(typeof(string)); //FrameNo
//            //�ԑ�^��
//            serInfo.MemberInfo.Add(typeof(string)); //FrameModel
//            //�V���V�[No
//            serInfo.MemberInfo.Add(typeof(string)); //ChassisNo
//            //�ԗ��ŗL�ԍ�
//            serInfo.MemberInfo.Add(typeof(Int32)); //CarProperNo
//            //���Y�N���iNUM�^�C�v�j
//            serInfo.MemberInfo.Add(typeof(Int32)); //ProduceTypeOfYearNum
//            //�R�����g
//            serInfo.MemberInfo.Add(typeof(string)); //Comment
//            //���y�A�J���[�R�[�h
//            serInfo.MemberInfo.Add(typeof(string)); //RpColorCode
//            //�J���[����1
//            serInfo.MemberInfo.Add(typeof(string)); //ColorName1
//            //�g�����R�[�h
//            serInfo.MemberInfo.Add(typeof(string)); //TrimCode
//            //�g��������
//            serInfo.MemberInfo.Add(typeof(string)); //TrimName
//            //�ԗ����s����
//            serInfo.MemberInfo.Add(typeof(Int32)); //Mileage
//            //�����I�u�W�F�N�g
//            serInfo.MemberInfo.Add(typeof(Byte[])); //EquipObj
//            //�⍇���s�ԍ�
//            serInfo.MemberInfo.Add(typeof(Int32)); //InqRowNumber
//            //�⍇���s�ԍ��}��
//            serInfo.MemberInfo.Add(typeof(Int32)); //InqRowNumDerivedNo
//            //���i���
//            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsDivCd
//            //���T�C�N�����i���
//            serInfo.MemberInfo.Add(typeof(Int32)); //RecyclePrtKindCode
//            //���T�C�N�����i��ʖ���
//            serInfo.MemberInfo.Add(typeof(string)); //RecyclePrtKindName
//            //�[�i�敪
//            serInfo.MemberInfo.Add(typeof(Int32)); //DeliveredGoodsDiv
//            //�戵�敪
//            serInfo.MemberInfo.Add(typeof(Int32)); //HandleDivCode
//            //���i�`��
//            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsShape
//            //�[�i�m�F�敪
//            serInfo.MemberInfo.Add(typeof(Int32)); //DelivrdGdsConfCd
//            //�[�i�����\���
//            serInfo.MemberInfo.Add(typeof(Int32)); //DeliGdsCmpltDueDate
//            //BL���i�R�[�h
//            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
//            //BL���i�R�[�h�}��
//            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsDrCode
//            //�┭���i��
//            serInfo.MemberInfo.Add(typeof(string)); //InqGoodsName
//            //�񓚏��i��
//            serInfo.MemberInfo.Add(typeof(string)); //AnsGoodsName
//            //������
//            serInfo.MemberInfo.Add(typeof(Double)); //SalesOrderCount
//            //�[�i��
//            serInfo.MemberInfo.Add(typeof(Double)); //DeliveredGoodsCount
//            //���i�ԍ�
//            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
//            //���i���[�J�[�R�[�h
//            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
//            //���[�J�[����
//            serInfo.MemberInfo.Add(typeof(string)); //MakerName
//            //�������i���[�J�[�R�[�h
//            serInfo.MemberInfo.Add(typeof(Int32)); //PureGoodsMakerCd
//            //�������i���[�J�[����
//            serInfo.MemberInfo.Add(typeof(string)); //PureMakerName
//            //�┭�������i�ԍ�
//            serInfo.MemberInfo.Add(typeof(string)); //InqPureGoodsNo
//            //�񓚏������i�ԍ�
//            serInfo.MemberInfo.Add(typeof(string)); //AnsPureGoodsNo
//            //�┭�������i����
//            serInfo.MemberInfo.Add(typeof(string)); //InqPureGoodsName
//            //�񓚏������i����
//            serInfo.MemberInfo.Add(typeof(string)); //AnsPureGoodsName
//            //�艿
//            serInfo.MemberInfo.Add(typeof(Int64)); //ListPrice
//            //�P��
//            serInfo.MemberInfo.Add(typeof(Int64)); //UnitPrice
//            //���i�⑫���
//            serInfo.MemberInfo.Add(typeof(string)); //GoodsAddInfo
//            //�e���z
//            serInfo.MemberInfo.Add(typeof(Int64)); //RoughRrofit
//            //�e����
//            serInfo.MemberInfo.Add(typeof(Double)); //RoughRate
//            //�񓚊���
//            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerLimitDate
//            //���l(����)
//            serInfo.MemberInfo.Add(typeof(string)); //CommentDtl
//            //�I��
//            serInfo.MemberInfo.Add(typeof(string)); //ShelfNo
//            //�ǉ��敪
//            serInfo.MemberInfo.Add(typeof(Int32)); //AdditionalDivCd
//            //�����敪
//            serInfo.MemberInfo.Add(typeof(Int32)); //CorrectDivCD
//            //�󒍃X�e�[�^�X
//            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
//            //����`�[�ԍ�
//            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
//            //����s�ԍ�
//            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowNo
//            //�݌ɋ敪
//            serInfo.MemberInfo.Add(typeof(Int32)); //StockDiv
//            //�⍇���E�������
//            serInfo.MemberInfo.Add(typeof(Int32)); //InqOrdDivCd
//            //�\������
//            serInfo.MemberInfo.Add(typeof(Int32)); //DisplayOrder
//            //�L�����y�[���R�[�h
//            serInfo.MemberInfo.Add(typeof(Int32)); //CampaignCode
//            //�L�����y�[������
//            serInfo.MemberInfo.Add(typeof(string)); //CampaignName
//            //����`�[���v�i�ō��݁j
//            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTotalTaxInc
//            //���㏬�v�i�Łj
//            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSubtotalTax
//            //�┭�E�񓚎��
//            serInfo.MemberInfo.Add(typeof(Int32)); //InqOrdAnsDivCd
//            //��M����
//            serInfo.MemberInfo.Add(typeof(Int64)); //ReceiveDateTime
//            //�񓚔[��
//            serInfo.MemberInfo.Add(typeof(string)); //AnswerDeliveryDate


//            serInfo.Serialize(writer, serInfo);
//            if (graph is SCMAnsHistResultWork)
//            {
//                SCMAnsHistResultWork temp = (SCMAnsHistResultWork)graph;

//                SetSCMAnsHistResultWork(writer, temp);
//            }
//            else
//            {
//                ArrayList lst = null;
//                if (graph is SCMAnsHistResultWork[])
//                {
//                    lst = new ArrayList();
//                    lst.AddRange((SCMAnsHistResultWork[])graph);
//                }
//                else
//                {
//                    lst = (ArrayList)graph;
//                }

//                foreach (SCMAnsHistResultWork temp in lst)
//                {
//                    SetSCMAnsHistResultWork(writer, temp);
//                }

//            }


//        }


//        /// <summary>
//        /// SCMAnsHistResultWork�����o��(public�v���p�e�B��)
//        /// </summary>
//        private const int currentMemberCount = 91;

//        /// <summary>
//        ///  SCMAnsHistResultWork�C���X�^���X��������
//        /// </summary>
//        /// <remarks>
//        /// <br>Note�@�@�@�@�@�@ :   SCMAnsHistResultWork�̃C���X�^���X����������</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        private void SetSCMAnsHistResultWork(System.IO.BinaryWriter writer, SCMAnsHistResultWork temp)
//        {
//            //�⍇�����ƃR�[�h
//            writer.Write(temp.InqOtherEpCd);
//            //�⍇���拒�_�R�[�h
//            writer.Write(temp.InqOtherSecCd);
//            //���_����
//            writer.Write(temp.SectionGuidNm);
//            //���Ӑ�R�[�h
//            writer.Write(temp.CustomerCode);
//            //���Ӑ於��
//            writer.Write(temp.CustomerName);
//            //�⍇���ԍ�
//            writer.Write(temp.InquiryNumber);
//            //�X�V�N����
//            writer.Write((Int64)temp.UpdateDate.Ticks);
//            //�X�V����
//            writer.Write(temp.UpdateTime);
//            //�񓚋敪
//            writer.Write(temp.AnswerDivCd);
//            //�m���
//            writer.Write(temp.JudgementDate);
//            //�⍇���E�������l
//            writer.Write(temp.InqOrdNote);
//            //�⍇���]�ƈ��R�[�h
//            writer.Write(temp.InqEmployeeCd);
//            //�⍇���]�ƈ�����
//            writer.Write(temp.InqEmployeeNm);
//            //�񓚏]�ƈ��R�[�h
//            writer.Write(temp.AnsEmployeeCd);
//            //�񓚏]�ƈ�����
//            writer.Write(temp.AnsEmployeeNm);
//            //�⍇����
//            writer.Write(temp.InquiryDate);
//            //���^�������ԍ�
//            writer.Write(temp.NumberPlate1Code);
//            //���^�����ǖ���
//            writer.Write(temp.NumberPlate1Name);
//            //�ԗ��o�^�ԍ��i��ʁj
//            writer.Write(temp.NumberPlate2);
//            //�ԗ��o�^�ԍ��i�J�i�j
//            writer.Write(temp.NumberPlate3);
//            //�ԗ��o�^�ԍ��i�v���[�g�ԍ��j
//            writer.Write(temp.NumberPlate4);
//            //�^���w��ԍ�
//            writer.Write(temp.ModelDesignationNo);
//            //�ޕʔԍ�
//            writer.Write(temp.CategoryNo);
//            //���[�J�[�R�[�h
//            writer.Write(temp.MakerCode);
//            //���[�J�[����
//            writer.Write(temp.CarMakerName);
//            //�Ԏ�R�[�h
//            writer.Write(temp.ModelCode);
//            //�Ԏ�T�u�R�[�h
//            writer.Write(temp.ModelSubCode);
//            //�Ԏ햼
//            writer.Write(temp.ModelName);
//            //�Ԍ��،^��
//            writer.Write(temp.CarInspectCertModel);
//            //�^���i�t���^�j
//            writer.Write(temp.FullModel);
//            //�ԑ�ԍ�
//            writer.Write(temp.FrameNo);
//            //�ԑ�^��
//            writer.Write(temp.FrameModel);
//            //�V���V�[No
//            writer.Write(temp.ChassisNo);
//            //�ԗ��ŗL�ԍ�
//            writer.Write(temp.CarProperNo);
//            //���Y�N���iNUM�^�C�v�j
//            writer.Write(temp.ProduceTypeOfYearNum);
//            //�R�����g
//            writer.Write(temp.Comment);
//            //���y�A�J���[�R�[�h
//            writer.Write(temp.RpColorCode);
//            //�J���[����1
//            writer.Write(temp.ColorName1);
//            //�g�����R�[�h
//            writer.Write(temp.TrimCode);
//            //�g��������
//            writer.Write(temp.TrimName);
//            //�ԗ����s����
//            writer.Write(temp.Mileage);
//            //�����I�u�W�F�N�g
//            writer.Write(temp.EquipObj.Length);
//            writer.Write(temp.EquipObj);
//            //�⍇���s�ԍ�
//            writer.Write(temp.InqRowNumber);
//            //�⍇���s�ԍ��}��
//            writer.Write(temp.InqRowNumDerivedNo);
//            //���i���
//            writer.Write(temp.GoodsDivCd);
//            //���T�C�N�����i���
//            writer.Write(temp.RecyclePrtKindCode);
//            //���T�C�N�����i��ʖ���
//            writer.Write(temp.RecyclePrtKindName);
//            //�[�i�敪
//            writer.Write(temp.DeliveredGoodsDiv);
//            //�戵�敪
//            writer.Write(temp.HandleDivCode);
//            //���i�`��
//            writer.Write(temp.GoodsShape);
//            //�[�i�m�F�敪
//            writer.Write(temp.DelivrdGdsConfCd);
//            //�[�i�����\���
//            writer.Write((Int64)temp.DeliGdsCmpltDueDate.Ticks);
//            //BL���i�R�[�h
//            writer.Write(temp.BLGoodsCode);
//            //BL���i�R�[�h�}��
//            writer.Write(temp.BLGoodsDrCode);
//            //�┭���i��
//            writer.Write(temp.InqGoodsName);
//            //�񓚏��i��
//            writer.Write(temp.AnsGoodsName);
//            //������
//            writer.Write(temp.SalesOrderCount);
//            //�[�i��
//            writer.Write(temp.DeliveredGoodsCount);
//            //���i�ԍ�
//            writer.Write(temp.GoodsNo);
//            //���i���[�J�[�R�[�h
//            writer.Write(temp.GoodsMakerCd);
//            //���[�J�[����
//            writer.Write(temp.MakerName);
//            //�������i���[�J�[�R�[�h
//            writer.Write(temp.PureGoodsMakerCd);
//            //�������i���[�J�[����
//            writer.Write(temp.PureMakerName);
//            //�┭�������i�ԍ�
//            writer.Write(temp.InqPureGoodsNo);
//            //�񓚏������i�ԍ�
//            writer.Write(temp.AnsPureGoodsNo);
//            //�┭�������i����
//            writer.Write(temp.InqPureGoodsName);
//            //�񓚏������i����
//            writer.Write(temp.AnsPureGoodsName);
//            //�艿
//            writer.Write(temp.ListPrice);
//            //�P��
//            writer.Write(temp.UnitPrice);
//            //���i�⑫���
//            writer.Write(temp.GoodsAddInfo);
//            //�e���z
//            writer.Write(temp.RoughRrofit);
//            //�e����
//            writer.Write(temp.RoughRate);
//            //�񓚊���
//            writer.Write(temp.AnswerLimitDate);
//            //���l(����)
//            writer.Write(temp.CommentDtl);
//            //�I��
//            writer.Write(temp.ShelfNo);
//            //�ǉ��敪
//            writer.Write(temp.AdditionalDivCd);
//            //�����敪
//            writer.Write(temp.CorrectDivCD);
//            //�󒍃X�e�[�^�X
//            writer.Write(temp.AcptAnOdrStatus);
//            //����`�[�ԍ�
//            writer.Write(temp.SalesSlipNum);
//            //����s�ԍ�
//            writer.Write(temp.SalesRowNo);
//            //�݌ɋ敪
//            writer.Write(temp.StockDiv);
//            //�⍇���E�������
//            writer.Write(temp.InqOrdDivCd);
//            //�\������
//            writer.Write(temp.DisplayOrder);
//            //�L�����y�[���R�[�h
//            writer.Write(temp.CampaignCode);
//            //�L�����y�[������
//            writer.Write(temp.CampaignName);
//            //����`�[���v�i�ō��݁j
//            writer.Write(temp.SalesTotalTaxInc);
//            //���㏬�v�i�Łj
//            writer.Write(temp.SalesSubtotalTax);
//            //�┭�E�񓚎��
//            writer.Write(temp.InqOrdAnsDivCd);
//            //��M����
//            writer.Write(temp.ReceiveDateTime);
//            //�񓚔[��
//            writer.Write(temp.AnswerDeliveryDate);

//        }

//        /// <summary>
//        ///  SCMAnsHistResultWork�C���X�^���X�擾
//        /// </summary>
//        /// <returns>SCMAnsHistResultWork�N���X�̃C���X�^���X</returns>
//        /// <remarks>
//        /// <br>Note�@�@�@�@�@�@ :   SCMAnsHistResultWork�̃C���X�^���X���擾���܂�</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        private SCMAnsHistResultWork GetSCMAnsHistResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
//        {
//            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
//            // serInfo.MemberInfo.Count < currentMemberCount
//            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

//            SCMAnsHistResultWork temp = new SCMAnsHistResultWork();

//            //�⍇�����ƃR�[�h
//            temp.InqOtherEpCd = reader.ReadString();
//            //�⍇���拒�_�R�[�h
//            temp.InqOtherSecCd = reader.ReadString();
//            //���_����
//            temp.SectionGuidNm = reader.ReadString();
//            //���Ӑ�R�[�h
//            temp.CustomerCode = reader.ReadInt32();
//            //���Ӑ於��
//            temp.CustomerName = reader.ReadString();
//            //�⍇���ԍ�
//            temp.InquiryNumber = reader.ReadInt64();
//            //�X�V�N����
//            temp.UpdateDate = new DateTime(reader.ReadInt64());
//            //�X�V����
//            temp.UpdateTime = reader.ReadInt32();
//            //�񓚋敪
//            temp.AnswerDivCd = reader.ReadInt32();
//            //�m���
//            temp.JudgementDate = reader.ReadInt32();
//            //�⍇���E�������l
//            temp.InqOrdNote = reader.ReadString();
//            //�⍇���]�ƈ��R�[�h
//            temp.InqEmployeeCd = reader.ReadString();
//            //�⍇���]�ƈ�����
//            temp.InqEmployeeNm = reader.ReadString();
//            //�񓚏]�ƈ��R�[�h
//            temp.AnsEmployeeCd = reader.ReadString();
//            //�񓚏]�ƈ�����
//            temp.AnsEmployeeNm = reader.ReadString();
//            //�⍇����
//            temp.InquiryDate = reader.ReadInt32();
//            //���^�������ԍ�
//            temp.NumberPlate1Code = reader.ReadInt32();
//            //���^�����ǖ���
//            temp.NumberPlate1Name = reader.ReadString();
//            //�ԗ��o�^�ԍ��i��ʁj
//            temp.NumberPlate2 = reader.ReadString();
//            //�ԗ��o�^�ԍ��i�J�i�j
//            temp.NumberPlate3 = reader.ReadString();
//            //�ԗ��o�^�ԍ��i�v���[�g�ԍ��j
//            temp.NumberPlate4 = reader.ReadInt32();
//            //�^���w��ԍ�
//            temp.ModelDesignationNo = reader.ReadInt32();
//            //�ޕʔԍ�
//            temp.CategoryNo = reader.ReadInt32();
//            //���[�J�[�R�[�h
//            temp.MakerCode = reader.ReadInt32();
//            //���[�J�[����
//            temp.CarMakerName = reader.ReadString();
//            //�Ԏ�R�[�h
//            temp.ModelCode = reader.ReadInt32();
//            //�Ԏ�T�u�R�[�h
//            temp.ModelSubCode = reader.ReadInt32();
//            //�Ԏ햼
//            temp.ModelName = reader.ReadString();
//            //�Ԍ��،^��
//            temp.CarInspectCertModel = reader.ReadString();
//            //�^���i�t���^�j
//            temp.FullModel = reader.ReadString();
//            //�ԑ�ԍ�
//            temp.FrameNo = reader.ReadString();
//            //�ԑ�^��
//            temp.FrameModel = reader.ReadString();
//            //�V���V�[No
//            temp.ChassisNo = reader.ReadString();
//            //�ԗ��ŗL�ԍ�
//            temp.CarProperNo = reader.ReadInt32();
//            //���Y�N���iNUM�^�C�v�j
//            temp.ProduceTypeOfYearNum = reader.ReadInt32();
//            //�R�����g
//            temp.Comment = reader.ReadString();
//            //���y�A�J���[�R�[�h
//            temp.RpColorCode = reader.ReadString();
//            //�J���[����1
//            temp.ColorName1 = reader.ReadString();
//            //�g�����R�[�h
//            temp.TrimCode = reader.ReadString();
//            //�g��������
//            temp.TrimName = reader.ReadString();
//            //�ԗ����s����
//            temp.Mileage = reader.ReadInt32();
//            //�����I�u�W�F�N�g
//            int equipObjLength = reader.ReadInt32();
//            temp.EquipObj = reader.ReadBytes(equipObjLength);
//            //�⍇���s�ԍ�
//            temp.InqRowNumber = reader.ReadInt32();
//            //�⍇���s�ԍ��}��
//            temp.InqRowNumDerivedNo = reader.ReadInt32();
//            //���i���
//            temp.GoodsDivCd = reader.ReadInt32();
//            //���T�C�N�����i���
//            temp.RecyclePrtKindCode = reader.ReadInt32();
//            //���T�C�N�����i��ʖ���
//            temp.RecyclePrtKindName = reader.ReadString();
//            //�[�i�敪
//            temp.DeliveredGoodsDiv = reader.ReadInt32();
//            //�戵�敪
//            temp.HandleDivCode = reader.ReadInt32();
//            //���i�`��
//            temp.GoodsShape = reader.ReadInt32();
//            //�[�i�m�F�敪
//            temp.DelivrdGdsConfCd = reader.ReadInt32();
//            //�[�i�����\���
//            temp.DeliGdsCmpltDueDate = new DateTime(reader.ReadInt64());
//            //BL���i�R�[�h
//            temp.BLGoodsCode = reader.ReadInt32();
//            //BL���i�R�[�h�}��
//            temp.BLGoodsDrCode = reader.ReadInt32();
//            //�┭���i��
//            temp.InqGoodsName = reader.ReadString();
//            //�񓚏��i��
//            temp.AnsGoodsName = reader.ReadString();
//            //������
//            temp.SalesOrderCount = reader.ReadDouble();
//            //�[�i��
//            temp.DeliveredGoodsCount = reader.ReadDouble();
//            //���i�ԍ�
//            temp.GoodsNo = reader.ReadString();
//            //���i���[�J�[�R�[�h
//            temp.GoodsMakerCd = reader.ReadInt32();
//            //���[�J�[����
//            temp.MakerName = reader.ReadString();
//            //�������i���[�J�[�R�[�h
//            temp.PureGoodsMakerCd = reader.ReadInt32();
//            //�������i���[�J�[����
//            temp.PureMakerName = reader.ReadString();
//            //�┭�������i�ԍ�
//            temp.InqPureGoodsNo = reader.ReadString();
//            //�񓚏������i�ԍ�
//            temp.AnsPureGoodsNo = reader.ReadString();
//            //�┭�������i����
//            temp.InqPureGoodsName = reader.ReadString();
//            //�񓚏������i����
//            temp.AnsPureGoodsName = reader.ReadString();
//            //�艿
//            temp.ListPrice = reader.ReadInt64();
//            //�P��
//            temp.UnitPrice = reader.ReadInt64();
//            //���i�⑫���
//            temp.GoodsAddInfo = reader.ReadString();
//            //�e���z
//            temp.RoughRrofit = reader.ReadInt64();
//            //�e����
//            temp.RoughRate = reader.ReadDouble();
//            //�񓚊���
//            temp.AnswerLimitDate = reader.ReadInt32();
//            //���l(����)
//            temp.CommentDtl = reader.ReadString();
//            //�I��
//            temp.ShelfNo = reader.ReadString();
//            //�ǉ��敪
//            temp.AdditionalDivCd = reader.ReadInt32();
//            //�����敪
//            temp.CorrectDivCD = reader.ReadInt32();
//            //�󒍃X�e�[�^�X
//            temp.AcptAnOdrStatus = reader.ReadInt32();
//            //����`�[�ԍ�
//            temp.SalesSlipNum = reader.ReadString();
//            //����s�ԍ�
//            temp.SalesRowNo = reader.ReadInt32();
//            //�݌ɋ敪
//            temp.StockDiv = reader.ReadInt32();
//            //�⍇���E�������
//            temp.InqOrdDivCd = reader.ReadInt32();
//            //�\������
//            temp.DisplayOrder = reader.ReadInt32();
//            //�L�����y�[���R�[�h
//            temp.CampaignCode = reader.ReadInt32();
//            //�L�����y�[������
//            temp.CampaignName = reader.ReadString();
//            //����`�[���v�i�ō��݁j
//            temp.SalesTotalTaxInc = reader.ReadInt64();
//            //���㏬�v�i�Łj
//            temp.SalesSubtotalTax = reader.ReadInt64();
//            //�┭�E�񓚎��
//            temp.InqOrdAnsDivCd = reader.ReadInt32();
//            //��M����
//            temp.ReceiveDateTime = reader.ReadInt64();
//            //�񓚔[��
//            temp.AnswerDeliveryDate = reader.ReadString();


//            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
//            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
//            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
//            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
//            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
//            {
//                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
//                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
//                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
//                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
//                int optCount = 0;
//                object oMemberType = serInfo.MemberInfo[k];
//                if (oMemberType is Type)
//                {
//                    Type t = (Type)oMemberType;
//                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
//                    if (t.Equals(typeof(int)))
//                    {
//                        optCount = Convert.ToInt32(oData);
//                    }
//                    else
//                    {
//                        optCount = 0;
//                    }
//                }
//                else if (oMemberType is string)
//                {
//                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
//                    object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
//                }
//            }
//            return temp;
//        }

//        /// <summary>
//        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
//        /// </summary>
//        /// <returns>SCMAnsHistResultWork�N���X�̃C���X�^���X(object)</returns>
//        /// <remarks>
//        /// <br>Note�@�@�@�@�@�@ :   SCMAnsHistResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public object Deserialize(System.IO.BinaryReader reader)
//        {
//            object retValue = null;
//            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
//            ArrayList lst = new ArrayList();
//            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
//            {
//                SCMAnsHistResultWork temp = GetSCMAnsHistResultWork(reader, serInfo);
//                lst.Add(temp);
//            }
//            switch (serInfo.RetTypeInfo)
//            {
//                case 0:
//                    retValue = lst;
//                    break;
//                case 1:
//                    retValue = lst[0];
//                    break;
//                case 2:
//                    retValue = (SCMAnsHistResultWork[])lst.ToArray(typeof(SCMAnsHistResultWork));
//                    break;
//            }
//            return retValue;
//        }

//        #endregion
//    }

//}
#endregion
// 2009.08.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
