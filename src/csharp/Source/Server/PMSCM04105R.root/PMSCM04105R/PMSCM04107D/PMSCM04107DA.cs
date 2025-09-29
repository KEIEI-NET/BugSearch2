using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
 	/// public class name:   SCMAnsHistOrderWork
	/// <summary>
	///                      SCM����E�񓚗����Ɖ�o�����N���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM����E�񓚗����Ɖ�o�����N���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :    2009/4/13</br>
	/// <br>Genarated Date   :   2009/06/02  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SCMAnsHistOrderWork
	{
		/// <summary>�⍇�����ƃR�[�h</summary>
		private string _inqOtherEpCd = "";

		/// <summary>�񓚋敪</summary>
		/// <remarks>0:�A�N�V�����Ȃ� 1:�񓚒� 10:�ꕔ�� 20:�񓚊��� 30:���F 99:�L�����Z��</remarks>
		private Int32[] _answerDivCd;

		/// <summary>�J�n�⍇����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _st_InquiryDate;

		/// <summary>�I���⍇����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _ed_InquiryDate;

		/// <summary>�⍇���拒�_�R�[�h</summary>
		private string _inqOtherSecCd = "";

		/// <summary>�J�n���Ӑ�R�[�h</summary>
		private Int32 _st_CustomerCode;

		/// <summary>�I�����Ӑ�R�[�h</summary>
		private Int32 _ed_CustomerCode;

		/// <summary>�񓚕��@</summary>
		private Int32[] _awnserMethod;

		/// <summary>�󒍃X�e�[�^�X</summary>
		/// <remarks>10:����,20:��,30:����,40:�o��</remarks>
		private Int32[] _acptAnOdrStatus;

		/// <summary>�J�n����`�[�ԍ�</summary>
		/// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
		private string _st_SalesSlipNum = "";

		/// <summary>�I������`�[�ԍ�</summary>
		/// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
		private string _ed_SalesSlipNum = "";

		/// <summary>�J�n�⍇���ԍ�</summary>
		private Int64 _st_InquiryNumber;

		/// <summary>�I���⍇���ԍ�</summary>
		private Int64 _ed_InquiryNumber;

		/// <summary>�ԗ��o�^�ԍ��i�v���[�g�ԍ��j</summary>
		private Int32 _numberPlate4;

		/// <summary>�^���i�t���^�j</summary>
		/// <remarks>�t���^��(44���p)</remarks>
		private string _fullModel = "";

		/// <summary>�Ԏ�R�[�h</summary>
		/// <remarks>�Ԗ��R�[�h(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
		private Int32 _modelCode;

		/// <summary>�Ԏ�T�u�R�[�h</summary>
		/// <remarks>0�`899:�񋟕�,900�`հ�ް�o�^</remarks>
		private Int32 _modelSubCode;

		/// <summary>���i���[�J�[�R�[�h</summary>
		private Int32 _goodsMakerCd;

		/// <summary>BL���i�R�[�h</summary>
		private Int32 _bLGoodsCode;

		/// <summary>���i�ԍ�</summary>
		private string _goodsNo = "";

		/// <summary>�������i�ԍ�</summary>
		private string _pureGoodsNo = "";

		/// <summary>�⍇���E�������</summary>
		/// <remarks>1:�⍇�� 2:����</remarks>
		private Int32[] _inqOrdDivCd;

        /// <summary>���[�J�[�R�[�h(�ԗ����)</summary>
        private Int32 _carMakerCode;

        /// <summary>�����^�C�v�i�^���j</summary>
        /// <remarks>1:�O����v 2:�����v 3:�B������</remarks>
        private Int32 _serchTypeModelCd;

        /// <summary>�����^�C�v�i���i�ԍ��j</summary>
        /// <remarks>1:�O����v 2:�����v 3:�B������</remarks>
        private Int32 _serchTypeGoodsNo;

        /// <summary>�����^�C�v�i�������i�ԍ��j</summary>
        /// <remarks>1:�O����v 2:�����v 3:�B������</remarks>
        private Int32 _serchTypePureGoodsNo;



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

		/// public propaty name  :  AnswerDivCd
		/// <summary>�񓚋敪�v���p�e�B</summary>
		/// <value>0:�A�N�V�����Ȃ� 1:�񓚒� 10:�ꕔ�� 20:�񓚊��� 30:���F 99:�L�����Z��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32[] AnswerDivCd
		{
			get{return _answerDivCd;}
			set{_answerDivCd = value;}
		}

		/// public propaty name  :  St_InquiryDate
		/// <summary>�J�n�⍇�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�⍇�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_InquiryDate
		{
			get{return _st_InquiryDate;}
			set{_st_InquiryDate = value;}
		}

		/// public propaty name  :  Ed_InquiryDate
		/// <summary>�I���⍇�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���⍇�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_InquiryDate
		{
			get{return _ed_InquiryDate;}
			set{_ed_InquiryDate = value;}
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

		/// public propaty name  :  St_CustomerCode
		/// <summary>�J�n���Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_CustomerCode
		{
			get{return _st_CustomerCode;}
			set{_st_CustomerCode = value;}
		}

		/// public propaty name  :  Ed_CustomerCode
		/// <summary>�I�����Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_CustomerCode
		{
			get{return _ed_CustomerCode;}
			set{_ed_CustomerCode = value;}
		}

		/// public propaty name  :  AwnserMethod
		/// <summary>�񓚕��@�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚕��@�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32[] AwnserMethod
		{
			get{return _awnserMethod;}
			set{_awnserMethod = value;}
		}

		/// public propaty name  :  AcptAnOdrStatus
		/// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
		/// <value>10:����,20:��,30:����,40:�o��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32[] AcptAnOdrStatus
		{
			get{return _acptAnOdrStatus;}
			set{_acptAnOdrStatus = value;}
		}

		/// public propaty name  :  St_SalesSlipNum
		/// <summary>�J�n����`�[�ԍ��v���p�e�B</summary>
		/// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n����`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string St_SalesSlipNum
		{
			get{return _st_SalesSlipNum;}
			set{_st_SalesSlipNum = value;}
		}

		/// public propaty name  :  Ed_SalesSlipNum
		/// <summary>�I������`�[�ԍ��v���p�e�B</summary>
		/// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I������`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Ed_SalesSlipNum
		{
			get{return _ed_SalesSlipNum;}
			set{_ed_SalesSlipNum = value;}
		}

		/// public propaty name  :  St_InquiryNumber
		/// <summary>�J�n�⍇���ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�⍇���ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 St_InquiryNumber
		{
			get{return _st_InquiryNumber;}
			set{_st_InquiryNumber = value;}
		}

		/// public propaty name  :  Ed_InquiryNumber
		/// <summary>�I���⍇���ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���⍇���ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 Ed_InquiryNumber
		{
			get{return _ed_InquiryNumber;}
			set{_ed_InquiryNumber = value;}
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

		/// public propaty name  :  InqOrdDivCd
		/// <summary>�⍇���E������ʃv���p�e�B</summary>
		/// <value>1:�⍇�� 2:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���E������ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public Int32[] InqOrdDivCd
		{
			get{return _inqOrdDivCd;}
			set{_inqOrdDivCd = value;}
		}

        /// public propaty name  :  CarMakerCode
        /// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�[���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarMakerCode
        {
            get { return _carMakerCode; }
            set { _carMakerCode = value; }
        }

        /// public propaty name  :  SerchTypeModelCd
        /// <summary>�����^�C�v�i�^���j�v���p�e�B</summary>
        /// <value>1:�O����v 2:�����v 3:�B������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����^�C�v�i�^���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SerchTypeModelCd
        {
            get { return _serchTypeModelCd; }
            set { _serchTypeModelCd = value; }
        }

        /// public propaty name  :  SerchTypeGoodsNo
        /// <summary>�����^�C�v�i���i�ԍ��j�v���p�e�B</summary>
        /// <value>1:�O����v 2:�����v 3:�B������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����^�C�v�i���i�ԍ��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SerchTypeGoodsNo
        {
            get { return _serchTypeGoodsNo; }
            set { _serchTypeGoodsNo = value; }
        }

        /// public propaty name  :  SerchTypePureGoodsNo
        /// <summary>�����^�C�v�i�������i�ԍ��j�v���p�e�B</summary>
        /// <value>1:�O����v 2:�����v 3:�B������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����^�C�v�i�������i�ԍ��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SerchTypePureGoodsNo
        {
            get { return _serchTypePureGoodsNo; }
            set { _serchTypePureGoodsNo = value; }
        }


		/// <summary>
		/// SCM����E�񓚗����Ɖ�o�����N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>SCMAnsHistOrderWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAnsHistOrderWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SCMAnsHistOrderWork()
		{
		}

	}
}




