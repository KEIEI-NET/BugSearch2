using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   OfferPrimeSearchRetWork
    /// <summary>
    ///                      �D�ǂa�k�������o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �D�ǂa�k�������o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :    </br>
    /// <br>Genarated Date   :   2008/12/02  (CSharp File Generated Date)</br>
    /// <br></br>
    /// <br>Update Note      :   �����i���擾�J�[���[�J�[�R�[�h��ǉ�</br>
    /// <br>Programmer       :   21024�@���X�� ��</br>
    /// <br>Date             :   2009/10/22</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class OfferPrimeSearchRetWork
    {
        /// <summary>�D�ǐݒ�ڍ׃R�[�h�Q</summary>
        private Int32 _prmSetDtlNo2;

        /// <summary>�D�Ǖi��</summary>
        private string _primePartsNo = "";

        /// <summary>�D�Ǖ��i�ŗL�ԍ�</summary>
        private Int64 _prmPartsProperNo;

        /// <summary>���i�\������</summary>
        /// <remarks>4,5,6,7,8,10,12������̌������������݂���ꍇ�̘A��</remarks>
        private Int32 _partsDispOrder;

        /// <summary>�Z�b�g�i�ԃt���O</summary>
        /// <remarks>0:�Z�b�g�i�����@1:�Z�b�g�i�L��</remarks>
        private Int32 _setPartsFlg;

        /// <summary>�D��QTY</summary>
        private Double _primeQty;

        /// <summary>�D�Ǔ��L����</summary>
        private string _primeSpecialNote = "";

        /// <summary>�J�n���Y�N��</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _stProduceTypeOfYear;

        /// <summary>�I�����Y�N��</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _edProduceTypeOfYear;

        /// <summary>���Y�ԑ�ԍ��J�n</summary>
        private Int32 _stProduceFrameNo;

        /// <summary>���Y�ԑ�ԍ��I��</summary>
        private Int32 _edProduceFrameNo;

        /// <summary>�񋟓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _offerDate;

        /// <summary>���i�����ރR�[�h</summary>
        /// <remarks>��������</remarks>
        private Int32 _goodsMGroup;

        /// <summary>BL�R�[�h</summary>
        /// <remarks>�B�������ŗD�ǐݒ�}�X�^���`�F�b�N</remarks>
        private Int32 _tbsPartsCode;

        /// <summary>BL�R�[�h�}��</summary>
        /// <remarks>�����g�p���ځi���C�A�E�g�ɂ͓���Ă����j</remarks>
        private Int32 _tbsPartsCdDerivedNo;

        /// <summary>�D�ǐݒ�ڍ׃R�[�h�P</summary>
        /// <remarks>�B�������ŗD�ǐݒ�}�X�^���`�F�b�N</remarks>
        private Int32 _prmSetDtlNo1;

        /// <summary>���i���[�J�[�R�[�h</summary>
        /// <remarks>�B�������ŗD�ǐݒ�}�X�^���`�F�b�N</remarks>
        private Int32 _partsMakerCd;

        /// <summary>�D�Ǖi��(�|�t���i��)</summary>
        /// <remarks>�n�C�t���t��</remarks>
        private string _primePartsNoWithH = "";

        /// <summary>�D�Ǖi��(�|�����i��)</summary>
        /// <remarks>�n�C�t������</remarks>
        private string _primePartsNoNoneH = "";

        /// <summary>�D�Ǖ��i����</summary>
        private string _primePartsName = "";

        /// <summary>�D�Ǖ��i�J�i����</summary>
        /// <remarks>���p�J�i</remarks>
        private string _primePartsKanaNm = "";

        /// <summary>�w�ʃR�[�h</summary>
        private string _partsLayerCd = "";

        /// <summary>�D�Ǖ��i�K�i�E���L����</summary>
        private string _primePartsSpecialNote = "";

        /// <summary>���i����</summary>
        /// <remarks>0:���� ��D�ǁA�p�i�Ȃǂ���ʂ��邽�߂̑���</remarks>
        private Int32 _partsAttribute;

        /// <summary>�J�^���O�폜�t���O</summary>
        private Int32 _catalogDeleteFlag;

        /// <summary>�D�Ǖ��i�C���X�g�R�[�h</summary>
        private string _prmPartsIllustC = "";

        /// <summary>��փt���O</summary>
        /// <remarks>0:��ʁ@1:���</remarks>
        private Int32 _substFlag;

        /// <summary>�����i���i�S�p�j</summary>
        private string _searchPartsFullName = "";

        /// <summary>�����i���i���p�j</summary>
        private string _searchPartsHalfName = "";

        /// <summary>�^���O���[�h����</summary>
        private string _modelGradeNm = "";

        /// <summary>�{�f�B�[����</summary>
        private string _bodyName = "";

        /// <summary>�h�A��</summary>
        private Int32 _doorCount;

        /// <summary>�G���W���^������</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _engineModelNm = "";

        /// <summary>�r�C�ʖ���</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _engineDisplaceNm = "";

        /// <summary>E�敪����</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _eDivNm = "";

        /// <summary>�~�b�V��������</summary>
        private string _transmissionNm = "";

        /// <summary>�V�t�g����</summary>
        private string _shiftNm = "";

        /// <summary>�쓮��������</summary>
        private string _wheelDriveMethodNm = "";

        // 2009/10/22 Add >>>
        /// <summary>�����i���擾�J�[���[�J�[�R�[�h</summary>
        private Int32 _srchPNmAcqrCarMkrCd;
        // 2009/10/22 Add <<<

        /// public propaty name  :  PrmSetDtlNo2
        /// <summary>�D�ǐݒ�ڍ׃R�[�h�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǐݒ�ڍ׃R�[�h�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrmSetDtlNo2
        {
            get { return _prmSetDtlNo2; }
            set { _prmSetDtlNo2 = value; }
        }

        /// public propaty name  :  PrimePartsNo
        /// <summary>�D�Ǖi�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�Ǖi�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrimePartsNo
        {
            get { return _primePartsNo; }
            set { _primePartsNo = value; }
        }

        /// public propaty name  :  PrmPartsProperNo
        /// <summary>�D�Ǖ��i�ŗL�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�Ǖ��i�ŗL�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 PrmPartsProperNo
        {
            get { return _prmPartsProperNo; }
            set { _prmPartsProperNo = value; }
        }

        /// public propaty name  :  PartsDispOrder
        /// <summary>���i�\�����ʃv���p�e�B</summary>
        /// <value>4,5,6,7,8,10,12������̌������������݂���ꍇ�̘A��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�\�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsDispOrder
        {
            get { return _partsDispOrder; }
            set { _partsDispOrder = value; }
        }

        /// public propaty name  :  SetPartsFlg
        /// <summary>�Z�b�g�i�ԃt���O�v���p�e�B</summary>
        /// <value>0:�Z�b�g�i�����@1:�Z�b�g�i�L��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�b�g�i�ԃt���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SetPartsFlg
        {
            get { return _setPartsFlg; }
            set { _setPartsFlg = value; }
        }

        /// public propaty name  :  PrimeQty
        /// <summary>�D��QTY�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��QTY�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double PrimeQty
        {
            get { return _primeQty; }
            set { _primeQty = value; }
        }

        /// public propaty name  :  PrimeSpecialNote
        /// <summary>�D�Ǔ��L�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�Ǔ��L�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrimeSpecialNote
        {
            get { return _primeSpecialNote; }
            set { _primeSpecialNote = value; }
        }

        /// public propaty name  :  StProduceTypeOfYear
        /// <summary>�J�n���Y�N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���Y�N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StProduceTypeOfYear
        {
            get { return _stProduceTypeOfYear; }
            set { _stProduceTypeOfYear = value; }
        }

        /// public propaty name  :  EdProduceTypeOfYear
        /// <summary>�I�����Y�N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Y�N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EdProduceTypeOfYear
        {
            get { return _edProduceTypeOfYear; }
            set { _edProduceTypeOfYear = value; }
        }

        /// public propaty name  :  StProduceFrameNo
        /// <summary>���Y�ԑ�ԍ��J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Y�ԑ�ԍ��J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StProduceFrameNo
        {
            get { return _stProduceFrameNo; }
            set { _stProduceFrameNo = value; }
        }

        /// public propaty name  :  EdProduceFrameNo
        /// <summary>���Y�ԑ�ԍ��I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Y�ԑ�ԍ��I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EdProduceFrameNo
        {
            get { return _edProduceFrameNo; }
            set { _edProduceFrameNo = value; }
        }

        /// public propaty name  :  OfferDate
        /// <summary>�񋟓��t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񋟓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>���i�����ރR�[�h�v���p�e�B</summary>
        /// <value>��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  TbsPartsCode
        /// <summary>BL�R�[�h�v���p�e�B</summary>
        /// <value>�B�������ŗD�ǐݒ�}�X�^���`�F�b�N</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }

        /// public propaty name  :  TbsPartsCdDerivedNo
        /// <summary>BL�R�[�h�}�ԃv���p�e�B</summary>
        /// <value>�����g�p���ځi���C�A�E�g�ɂ͓���Ă����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�}�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TbsPartsCdDerivedNo
        {
            get { return _tbsPartsCdDerivedNo; }
            set { _tbsPartsCdDerivedNo = value; }
        }

        /// public propaty name  :  PrmSetDtlNo1
        /// <summary>�D�ǐݒ�ڍ׃R�[�h�P�v���p�e�B</summary>
        /// <value>�B�������ŗD�ǐݒ�}�X�^���`�F�b�N</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǐݒ�ڍ׃R�[�h�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrmSetDtlNo1
        {
            get { return _prmSetDtlNo1; }
            set { _prmSetDtlNo1 = value; }
        }

        /// public propaty name  :  PartsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>�B�������ŗD�ǐݒ�}�X�^���`�F�b�N</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsMakerCd
        {
            get { return _partsMakerCd; }
            set { _partsMakerCd = value; }
        }

        /// public propaty name  :  PrimePartsNoWithH
        /// <summary>�D�Ǖi��(�|�t���i��)�v���p�e�B</summary>
        /// <value>�n�C�t���t��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�Ǖi��(�|�t���i��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrimePartsNoWithH
        {
            get { return _primePartsNoWithH; }
            set { _primePartsNoWithH = value; }
        }

        /// public propaty name  :  PrimePartsNoNoneH
        /// <summary>�D�Ǖi��(�|�����i��)�v���p�e�B</summary>
        /// <value>�n�C�t������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�Ǖi��(�|�����i��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrimePartsNoNoneH
        {
            get { return _primePartsNoNoneH; }
            set { _primePartsNoNoneH = value; }
        }

        /// public propaty name  :  PrimePartsName
        /// <summary>�D�Ǖ��i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�Ǖ��i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrimePartsName
        {
            get { return _primePartsName; }
            set { _primePartsName = value; }
        }

        /// public propaty name  :  PrimePartsKanaNm
        /// <summary>�D�Ǖ��i�J�i���̃v���p�e�B</summary>
        /// <value>���p�J�i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�Ǖ��i�J�i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrimePartsKanaNm
        {
            get { return _primePartsKanaNm; }
            set { _primePartsKanaNm = value; }
        }

        /// public propaty name  :  PartsLayerCd
        /// <summary>�w�ʃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �w�ʃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartsLayerCd
        {
            get { return _partsLayerCd; }
            set { _partsLayerCd = value; }
        }

        /// public propaty name  :  PrimePartsSpecialNote
        /// <summary>�D�Ǖ��i�K�i�E���L�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�Ǖ��i�K�i�E���L�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrimePartsSpecialNote
        {
            get { return _primePartsSpecialNote; }
            set { _primePartsSpecialNote = value; }
        }

        /// public propaty name  :  PartsAttribute
        /// <summary>���i�����v���p�e�B</summary>
        /// <value>0:���� ��D�ǁA�p�i�Ȃǂ���ʂ��邽�߂̑���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsAttribute
        {
            get { return _partsAttribute; }
            set { _partsAttribute = value; }
        }

        /// public propaty name  :  CatalogDeleteFlag
        /// <summary>�J�^���O�폜�t���O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�^���O�폜�t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CatalogDeleteFlag
        {
            get { return _catalogDeleteFlag; }
            set { _catalogDeleteFlag = value; }
        }

        /// public propaty name  :  PrmPartsIllustC
        /// <summary>�D�Ǖ��i�C���X�g�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�Ǖ��i�C���X�g�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrmPartsIllustC
        {
            get { return _prmPartsIllustC; }
            set { _prmPartsIllustC = value; }
        }

        /// public propaty name  :  SubstFlag
        /// <summary>��փt���O�v���p�e�B</summary>
        /// <value>0:��ʁ@1:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��փt���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SubstFlag
        {
            get { return _substFlag; }
            set { _substFlag = value; }
        }

        /// public propaty name  :  SearchPartsFullName
        /// <summary>�����i���i�S�p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����i���i�S�p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchPartsFullName
        {
            get { return _searchPartsFullName; }
            set { _searchPartsFullName = value; }
        }

        /// public propaty name  :  SearchPartsHalfName
        /// <summary>�����i���i���p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����i���i���p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchPartsHalfName
        {
            get { return _searchPartsHalfName; }
            set { _searchPartsHalfName = value; }
        }

        /// public propaty name  :  ModelGradeNm
        /// <summary>�^���O���[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���O���[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ModelGradeNm
        {
            get { return _modelGradeNm; }
            set { _modelGradeNm = value; }
        }

        /// public propaty name  :  BodyName
        /// <summary>�{�f�B�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �{�f�B�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BodyName
        {
            get { return _bodyName; }
            set { _bodyName = value; }
        }

        /// public propaty name  :  DoorCount
        /// <summary>�h�A���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �h�A���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DoorCount
        {
            get { return _doorCount; }
            set { _doorCount = value; }
        }

        /// public propaty name  :  EngineModelNm
        /// <summary>�G���W���^�����̃v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���W���^�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EngineModelNm
        {
            get { return _engineModelNm; }
            set { _engineModelNm = value; }
        }

        /// public propaty name  :  EngineDisplaceNm
        /// <summary>�r�C�ʖ��̃v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �r�C�ʖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EngineDisplaceNm
        {
            get { return _engineDisplaceNm; }
            set { _engineDisplaceNm = value; }
        }

        /// public propaty name  :  EDivNm
        /// <summary>E�敪���̃v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   E�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EDivNm
        {
            get { return _eDivNm; }
            set { _eDivNm = value; }
        }

        /// public propaty name  :  TransmissionNm
        /// <summary>�~�b�V�������̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �~�b�V�������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TransmissionNm
        {
            get { return _transmissionNm; }
            set { _transmissionNm = value; }
        }

        /// public propaty name  :  ShiftNm
        /// <summary>�V�t�g���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V�t�g���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShiftNm
        {
            get { return _shiftNm; }
            set { _shiftNm = value; }
        }

        /// public propaty name  :  WheelDriveMethodNm
        /// <summary>�쓮�������̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쓮�������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WheelDriveMethodNm
        {
            get { return _wheelDriveMethodNm; }
            set { _wheelDriveMethodNm = value; }
        }

        // 2009/10/22 Add >>>
        /// <summary>
        /// �����i���擾�J�[���[�J�[�R�[�h
        /// </summary>
        public Int32 SrchPNmAcqrCarMkrCd
        {
            get { return _srchPNmAcqrCarMkrCd; }
            set { _srchPNmAcqrCarMkrCd = value; }
        }    
        // 2009/10/22 Add <<<


        /// <summary>
        /// �D�ǂa�k�������o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>OfferPrimeSearchRetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfferPrimeSearchRetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OfferPrimeSearchRetWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>OfferPrimeSearchRetWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   OfferPrimeSearchRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// <br></br>
    /// <br>Update Note      :   �����i���擾�J�[���[�J�[�R�[�h��ǉ�</br>
    /// <br>Programmer       :   21024�@���X�� ��</br>
    /// <br>Date             :   2009/10/22</br>
    /// </remarks>
    public class OfferPrimeSearchRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfferPrimeSearchRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  OfferPrimeSearchRetWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is OfferPrimeSearchRetWork || graph is ArrayList || graph is OfferPrimeSearchRetWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(OfferPrimeSearchRetWork).FullName));

            if (graph != null && graph is OfferPrimeSearchRetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.OfferPrimeSearchRetWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is OfferPrimeSearchRetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((OfferPrimeSearchRetWork[])graph).Length;
            }
            else if (graph is OfferPrimeSearchRetWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�D�ǐݒ�ڍ׃R�[�h�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmSetDtlNo2
            //�D�Ǖi��
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsNo
            //�D�Ǖ��i�ŗL�ԍ�
            serInfo.MemberInfo.Add(typeof(Int64)); //PrmPartsProperNo
            //���i�\������
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsDispOrder
            //�Z�b�g�i�ԃt���O
            serInfo.MemberInfo.Add(typeof(Int32)); //SetPartsFlg
            //�D��QTY
            serInfo.MemberInfo.Add(typeof(Double)); //PrimeQty
            //�D�Ǔ��L����
            serInfo.MemberInfo.Add(typeof(string)); //PrimeSpecialNote
            //�J�n���Y�N��
            serInfo.MemberInfo.Add(typeof(Int32)); //StProduceTypeOfYear
            //�I�����Y�N��
            serInfo.MemberInfo.Add(typeof(Int32)); //EdProduceTypeOfYear
            //���Y�ԑ�ԍ��J�n
            serInfo.MemberInfo.Add(typeof(Int32)); //StProduceFrameNo
            //���Y�ԑ�ԍ��I��
            serInfo.MemberInfo.Add(typeof(Int32)); //EdProduceFrameNo
            //�񋟓��t
            serInfo.MemberInfo.Add(typeof(Int64)); //OfferDate
            //���i�����ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //BL�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode
            //BL�R�[�h�}��
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCdDerivedNo
            //�D�ǐݒ�ڍ׃R�[�h�P
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmSetDtlNo1
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsMakerCd
            //�D�Ǖi��(�|�t���i��)
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsNoWithH
            //�D�Ǖi��(�|�����i��)
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsNoNoneH
            //�D�Ǖ��i����
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsName
            //�D�Ǖ��i�J�i����
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsKanaNm
            //�w�ʃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //PartsLayerCd
            //�D�Ǖ��i�K�i�E���L����
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsSpecialNote
            //���i����
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsAttribute
            //�J�^���O�폜�t���O
            serInfo.MemberInfo.Add(typeof(Int32)); //CatalogDeleteFlag
            //�D�Ǖ��i�C���X�g�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //PrmPartsIllustC
            //��փt���O
            serInfo.MemberInfo.Add(typeof(Int32)); //SubstFlag
            //�����i���i�S�p�j
            serInfo.MemberInfo.Add(typeof(string)); //SearchPartsFullName
            //�����i���i���p�j
            serInfo.MemberInfo.Add(typeof(string)); //SearchPartsHalfName
            //�^���O���[�h����
            serInfo.MemberInfo.Add(typeof(string)); //ModelGradeNm
            //�{�f�B�[����
            serInfo.MemberInfo.Add(typeof(string)); //BodyName
            //�h�A��
            serInfo.MemberInfo.Add(typeof(Int32)); //DoorCount
            //�G���W���^������
            serInfo.MemberInfo.Add(typeof(string)); //EngineModelNm
            //�r�C�ʖ���
            serInfo.MemberInfo.Add(typeof(string)); //EngineDisplaceNm
            //E�敪����
            serInfo.MemberInfo.Add(typeof(string)); //EDivNm
            //�~�b�V��������
            serInfo.MemberInfo.Add(typeof(string)); //TransmissionNm
            //�V�t�g����
            serInfo.MemberInfo.Add(typeof(string)); //ShiftNm
            //�쓮��������
            serInfo.MemberInfo.Add(typeof(string)); //WheelDriveMethodNm
            // 2009/10/22 Add >>>
            // �����i���擾�J�[���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32));  //SrchPNmAcqrCarMkrCd
            // 2009/10/22 Add <<<


            serInfo.Serialize(writer, serInfo);
            if (graph is OfferPrimeSearchRetWork)
            {
                OfferPrimeSearchRetWork temp = (OfferPrimeSearchRetWork)graph;

                SetOfferPrimeSearchRetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is OfferPrimeSearchRetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((OfferPrimeSearchRetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (OfferPrimeSearchRetWork temp in lst)
                {
                    SetOfferPrimeSearchRetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// OfferPrimeSearchRetWork�����o��(public�v���p�e�B��)
        /// </summary>
        // 2009/10/22 >>>
        //private const int currentMemberCount = 38;
        private const int currentMemberCount = 39;
        // 2009/10/22 <<<

        /// <summary>
        ///  OfferPrimeSearchRetWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfferPrimeSearchRetWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetOfferPrimeSearchRetWork(System.IO.BinaryWriter writer, OfferPrimeSearchRetWork temp)
        {
            //�D�ǐݒ�ڍ׃R�[�h�Q
            writer.Write(temp.PrmSetDtlNo2);
            //�D�Ǖi��
            writer.Write(temp.PrimePartsNo);
            //�D�Ǖ��i�ŗL�ԍ�
            writer.Write(temp.PrmPartsProperNo);
            //���i�\������
            writer.Write(temp.PartsDispOrder);
            //�Z�b�g�i�ԃt���O
            writer.Write(temp.SetPartsFlg);
            //�D��QTY
            writer.Write(temp.PrimeQty);
            //�D�Ǔ��L����
            writer.Write(temp.PrimeSpecialNote);
            //�J�n���Y�N��
            writer.Write(temp.StProduceTypeOfYear);
            //�I�����Y�N��
            writer.Write(temp.EdProduceTypeOfYear);
            //���Y�ԑ�ԍ��J�n
            writer.Write(temp.StProduceFrameNo);
            //���Y�ԑ�ԍ��I��
            writer.Write(temp.EdProduceFrameNo);
            //�񋟓��t
            writer.Write(temp.OfferDate.Ticks);
            //���i�����ރR�[�h
            writer.Write(temp.GoodsMGroup);
            //BL�R�[�h
            writer.Write(temp.TbsPartsCode);
            //BL�R�[�h�}��
            writer.Write(temp.TbsPartsCdDerivedNo);
            //�D�ǐݒ�ڍ׃R�[�h�P
            writer.Write(temp.PrmSetDtlNo1);
            //���i���[�J�[�R�[�h
            writer.Write(temp.PartsMakerCd);
            //�D�Ǖi��(�|�t���i��)
            writer.Write(temp.PrimePartsNoWithH);
            //�D�Ǖi��(�|�����i��)
            writer.Write(temp.PrimePartsNoNoneH);
            //�D�Ǖ��i����
            writer.Write(temp.PrimePartsName);
            //�D�Ǖ��i�J�i����
            writer.Write(temp.PrimePartsKanaNm);
            //�w�ʃR�[�h
            writer.Write(temp.PartsLayerCd);
            //�D�Ǖ��i�K�i�E���L����
            writer.Write(temp.PrimePartsSpecialNote);
            //���i����
            writer.Write(temp.PartsAttribute);
            //�J�^���O�폜�t���O
            writer.Write(temp.CatalogDeleteFlag);
            //�D�Ǖ��i�C���X�g�R�[�h
            writer.Write(temp.PrmPartsIllustC);
            //��փt���O
            writer.Write(temp.SubstFlag);
            //�����i���i�S�p�j
            writer.Write(temp.SearchPartsFullName);
            //�����i���i���p�j
            writer.Write(temp.SearchPartsHalfName);
            //�^���O���[�h����
            writer.Write(temp.ModelGradeNm);
            //�{�f�B�[����
            writer.Write(temp.BodyName);
            //�h�A��
            writer.Write(temp.DoorCount);
            //�G���W���^������
            writer.Write(temp.EngineModelNm);
            //�r�C�ʖ���
            writer.Write(temp.EngineDisplaceNm);
            //E�敪����
            writer.Write(temp.EDivNm);
            //�~�b�V��������
            writer.Write(temp.TransmissionNm);
            //�V�t�g����
            writer.Write(temp.ShiftNm);
            //�쓮��������
            writer.Write(temp.WheelDriveMethodNm);
            // 2009/10/22 Add >>>
            //�����i���擾�J�[���[�J�[�R�[�h
            writer.Write(temp.SrchPNmAcqrCarMkrCd);
            // 2009/10/22 Add <<<
        }

        /// <summary>
        ///  OfferPrimeSearchRetWork�C���X�^���X�擾
        /// </summary>
        /// <returns>OfferPrimeSearchRetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfferPrimeSearchRetWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private OfferPrimeSearchRetWork GetOfferPrimeSearchRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            OfferPrimeSearchRetWork temp = new OfferPrimeSearchRetWork();

            //�D�ǐݒ�ڍ׃R�[�h�Q
            temp.PrmSetDtlNo2 = reader.ReadInt32();
            //�D�Ǖi��
            temp.PrimePartsNo = reader.ReadString();
            //�D�Ǖ��i�ŗL�ԍ�
            temp.PrmPartsProperNo = reader.ReadInt64();
            //���i�\������
            temp.PartsDispOrder = reader.ReadInt32();
            //�Z�b�g�i�ԃt���O
            temp.SetPartsFlg = reader.ReadInt32();
            //�D��QTY
            temp.PrimeQty = reader.ReadDouble();
            //�D�Ǔ��L����
            temp.PrimeSpecialNote = reader.ReadString();
            //�J�n���Y�N��
            temp.StProduceTypeOfYear = reader.ReadInt32();
            //�I�����Y�N��
            temp.EdProduceTypeOfYear = reader.ReadInt32();
            //���Y�ԑ�ԍ��J�n
            temp.StProduceFrameNo = reader.ReadInt32();
            //���Y�ԑ�ԍ��I��
            temp.EdProduceFrameNo = reader.ReadInt32();
            //�񋟓��t
            temp.OfferDate = new DateTime(reader.ReadInt64());
            //���i�����ރR�[�h
            temp.GoodsMGroup = reader.ReadInt32();
            //BL�R�[�h
            temp.TbsPartsCode = reader.ReadInt32();
            //BL�R�[�h�}��
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();
            //�D�ǐݒ�ڍ׃R�[�h�P
            temp.PrmSetDtlNo1 = reader.ReadInt32();
            //���i���[�J�[�R�[�h
            temp.PartsMakerCd = reader.ReadInt32();
            //�D�Ǖi��(�|�t���i��)
            temp.PrimePartsNoWithH = reader.ReadString();
            //�D�Ǖi��(�|�����i��)
            temp.PrimePartsNoNoneH = reader.ReadString();
            //�D�Ǖ��i����
            temp.PrimePartsName = reader.ReadString();
            //�D�Ǖ��i�J�i����
            temp.PrimePartsKanaNm = reader.ReadString();
            //�w�ʃR�[�h
            temp.PartsLayerCd = reader.ReadString();
            //�D�Ǖ��i�K�i�E���L����
            temp.PrimePartsSpecialNote = reader.ReadString();
            //���i����
            temp.PartsAttribute = reader.ReadInt32();
            //�J�^���O�폜�t���O
            temp.CatalogDeleteFlag = reader.ReadInt32();
            //�D�Ǖ��i�C���X�g�R�[�h
            temp.PrmPartsIllustC = reader.ReadString();
            //��փt���O
            temp.SubstFlag = reader.ReadInt32();
            //�����i���i�S�p�j
            temp.SearchPartsFullName = reader.ReadString();
            //�����i���i���p�j
            temp.SearchPartsHalfName = reader.ReadString();
            //�^���O���[�h����
            temp.ModelGradeNm = reader.ReadString();
            //�{�f�B�[����
            temp.BodyName = reader.ReadString();
            //�h�A��
            temp.DoorCount = reader.ReadInt32();
            //�G���W���^������
            temp.EngineModelNm = reader.ReadString();
            //�r�C�ʖ���
            temp.EngineDisplaceNm = reader.ReadString();
            //E�敪����
            temp.EDivNm = reader.ReadString();
            //�~�b�V��������
            temp.TransmissionNm = reader.ReadString();
            //�V�t�g����
            temp.ShiftNm = reader.ReadString();
            //�쓮��������
            temp.WheelDriveMethodNm = reader.ReadString();
            // 2009/10/22 Add >>>
            //�����i���擾�J�[���[�J�[�R�[�h
            temp.SrchPNmAcqrCarMkrCd = reader.ReadInt32();
            // 2009/10/22 Add <<<


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
        /// <returns>OfferPrimeSearchRetWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfferPrimeSearchRetWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                OfferPrimeSearchRetWork temp = GetOfferPrimeSearchRetWork(reader, serInfo);
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
                    retValue = (OfferPrimeSearchRetWork[])lst.ToArray(typeof(OfferPrimeSearchRetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}