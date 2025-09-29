//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ԗ��Ǘ��I�u�W�F�N�g���N���X
// �v���O�����T�v   : ���q�Ǘ��}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/09/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// Update Note      :   2013/03/22 FSI���� ����
// �Ǘ��ԍ�         :   10900269-00 
//                      SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CarMangInputExtraInfo
    /// <summary>
    ///                      �ԗ��Ǘ��I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>note             :   �ԗ��Ǘ����[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/09/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   8/12  �v�ۓc</br>
    /// <br>                 :   �����I�u�W�F�N�g�z�� ��ǉ�</br>
    /// <br>                 :   �����@�^���i�G���W���j ��ǉ�</br>
    /// <br>Update Note      :   2010/04/27  gaoyh</br>
    /// <br>                 :   ���R�����^���Œ�ԍ��z���ǉ�</br>
    /// </remarks>
    public class CarMangInputExtraInfo
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>GUID</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ�R�[�h</summary>
        private string _customerCodeForGuide;

        /// <summary>���Ӑ於��</summary>
        private string _customerName = "";

        /// <summary>�ԗ��Ǘ��ԍ�</summary>
        /// <remarks>�����̔ԁi���d���̃V�[�P���X�jPM7�ł̎ԗ�SEQ</remarks>
        private Int32 _carMngNo;

        /// <summary>���q�Ǘ��R�[�h</summary>
        /// <remarks>��PM7�ł̎ԗ��Ǘ��ԍ�</remarks>
        private string _carMngCode = "";

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

        /// <summary>�ԗ��o�^�ԍ��i�K�C�h�p�j</summary>
        private string _numberPlateForGuide = "";

        /// <summary>�o�^�N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _entryDate;

        /// <summary>���N�x</summary>
        /// <remarks>YYYYMM</remarks>
        //private DateTime _firstEntryDate;
        private Int32 _firstEntryDate;  // ADD 2009/10/10

        /// <summary>���[�J�[�R�[�h</summary>
        /// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
        private Int32 _makerCode;

        /// <summary>���[�J�[�S�p����</summary>
        /// <remarks>�������́i�J�i�������݂őS�p�Ǘ��j</remarks>
        private string _makerFullName = "";

        /// <summary>���[�J�[���p����</summary>
        /// <remarks>�������́i���p�ŊǗ��j</remarks>
        private string _makerHalfName = "";

        /// <summary>�Ԏ�R�[�h</summary>
        /// <remarks>�Ԗ��R�[�h(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
        private Int32 _modelCode;

        /// <summary>�Ԏ�T�u�R�[�h</summary>
        /// <remarks>0�`899:�񋟕�,900�`հ�ް�o�^</remarks>
        private Int32 _modelSubCode;

        /// <summary>�Ԏ�S�p����</summary>
        /// <remarks>�������́i�J�i�������݂őS�p�Ǘ��j</remarks>
        private string _modelFullName = "";

        /// <summary>�Ԏ피�p����</summary>
        /// <remarks>�������́i���p�ŊǗ��j</remarks>
        private string _modelHalfName = "";

        /// <summary>�n���R�[�h</summary>
        private Int32 _systematicCode;

        /// <summary>�n������</summary>
        /// <remarks>140�n,180�n��</remarks>
        private string _systematicName = "";

        /// <summary>���Y�N���R�[�h</summary>
        private Int32 _produceTypeOfYearCd;

        /// <summary>���Y�N������</summary>
        private string _produceTypeOfYearNm = "";

        /// <summary>�J�n���Y�N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _stProduceTypeOfYear;

        /// <summary>�I�����Y�N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _edProduceTypeOfYear;

        /// <summary>�h�A��</summary>
        private Int32 _doorCount;

        /// <summary>�{�f�B�[���R�[�h</summary>
        private Int32 _bodyNameCode;

        /// <summary>�{�f�B�[����</summary>
        private string _bodyName = "";

        /// <summary>�r�K�X�L��</summary>
        private string _exhaustGasSign = "";

        /// <summary>�V���[�Y�^��</summary>
        private string _seriesModel = "";

        /// <summary>�^���i�ޕʋL���j</summary>
        private string _categorySignModel = "";

        /// <summary>�^���i�t���^�j</summary>
        /// <remarks>�t���^��(44���p)</remarks>
        private string _fullModel = "";

        /// <summary>�^���w��ԍ�</summary>
        private Int32 _modelDesignationNo;

        /// <summary>�ޕʔԍ�</summary>
        private Int32 _categoryNo;

        /// <summary>�ԑ�^��</summary>
        private string _frameModel = "";

        /// <summary>�ԑ�ԍ�</summary>
        /// <remarks>�Ԍ��؋L�ڃt�H�[�}�b�g�Ή��i HCR32-100251584 ���j</remarks>
        private string _frameNo = "";

        /// <summary>�ԑ�ԍ��i�����p�j</summary>
        /// <remarks>PM7�̎ԑ�ԍ��Ɠ���</remarks>
        private Int32 _searchFrameNo;

        /// <summary>���Y�ԑ�ԍ��J�n</summary>
        private Int32 _stProduceFrameNo;

        /// <summary>���Y�ԑ�ԍ��I��</summary>
        private Int32 _edProduceFrameNo;

        /// <summary>�����@�^���i�G���W���j</summary>
        /// <remarks>�Ԍ��؋L�ڌ����@�^��</remarks>
        private string _engineModel = "";

        /// <summary>�^���O���[�h����</summary>
        private string _modelGradeNm = "";

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
        /// <remarks>�V�K�ǉ�</remarks>
        private string _wheelDriveMethodNm = "";

        /// <summary>�ǉ�����1</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _addiCarSpec1 = "";

        /// <summary>�ǉ�����2</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _addiCarSpec2 = "";

        /// <summary>�ǉ�����3</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _addiCarSpec3 = "";

        /// <summary>�ǉ�����4</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _addiCarSpec4 = "";

        /// <summary>�ǉ�����5</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _addiCarSpec5 = "";

        /// <summary>�ǉ�����6</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _addiCarSpec6 = "";

        /// <summary>�ǉ������^�C�g��1</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _addiCarSpecTitle1 = "";

        /// <summary>�ǉ������^�C�g��2</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _addiCarSpecTitle2 = "";

        /// <summary>�ǉ������^�C�g��3</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _addiCarSpecTitle3 = "";

        /// <summary>�ǉ������^�C�g��4</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _addiCarSpecTitle4 = "";

        /// <summary>�ǉ������^�C�g��5</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _addiCarSpecTitle5 = "";

        /// <summary>�ǉ������^�C�g��6</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _addiCarSpecTitle6 = "";

        /// <summary>�֘A�^��</summary>
        /// <remarks>���T�C�N���n�Ŏg�p</remarks>
        private string _relevanceModel = "";

        /// <summary>�T�u�Ԗ��R�[�h</summary>
        /// <remarks>���T�C�N���n�Ŏg�p</remarks>
        private Int32 _subCarNmCd;

        /// <summary>�^���O���[�h����</summary>
        /// <remarks>���T�C�N���n�Ŏg�p</remarks>
        private string _modelGradeSname = "";

        /// <summary>�u���b�N�C���X�g�R�[�h</summary>
        /// <remarks>����̃u���b�N�I���Ɏg�p</remarks>
        private Int32 _blockIllustrationCd;

        /// <summary>3D�C���X�gNo</summary>
        /// <remarks>�����3D�C���X�g�I���Ɏg�p</remarks>
        private Int32 _threeDIllustNo;

        /// <summary>���i�f�[�^�񋟃t���O</summary>
        /// <remarks>0:�񋟂Ȃ�,1:�񋟂���</remarks>
        private Int32 _partsDataOfferFlag;

        /// <summary>�Ԍ�������</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _inspectMaturityDate;

        /// <summary>�O��Ԍ�������</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _lTimeCiMatDate;

        /// <summary>�Ԍ�����</summary>
        /// <remarks>1:1�N,2:2�N,3:3�N</remarks>
        private Int32 _carInspectYear;

        /// <summary>�ԗ����s����</summary>
        private Int32 _mileage;

        /// <summary>����</summary>
        private string _carNo = "";

        /// <summary>�J���[�R�[�h</summary>
        /// <remarks>�J�^���O�̐F�R�[�h</remarks>
        private string _colorCode = "";

        /// <summary>�J���[����1</summary>
        /// <remarks>��ʕ\���p��������</remarks>
        private string _colorName1 = "";

        /// <summary>�g�����R�[�h</summary>
        private string _trimCode = "";

        /// <summary>�g��������</summary>
        private string _trimName = "";

        /// <summary>�t���^���Œ�ԍ��z��</summary>
        /// <remarks>�t���^���Œ�A�Ԃ̔z��N���X���i�[�i�Č����s�v�ɂȂ�j</remarks>
        private Int32[] _fullModelFixedNoAry = new Int32[0];

        /// <summary>�����I�u�W�F�N�g�z��</summary>
        private Byte[] _categoryObjAry = new Byte[0];

        /// <summary>���q�ǉ����P</summary>
        private string _carAddInfo1 = "";

        /// <summary>���q�ǉ����Q</summary>
        private string _carAddInfo2 = "";

        /// <summary>���q���l</summary>
        private string _carNote = "";

        /// <summary>���R�����^���Œ�ԍ��z��</summary>
        /// <remarks>���R�����V���A�����̔z��N���X���i�[�i�Č����s�v�ɂȂ�j</remarks>
        private string[] _freeSrchMdlFxdNoAry = new string[0];

        /// <summary>�N��</summary>
        private Int32 _produceTypeOfYearInput;

        /// <summary>�ԗ��֘A�t��GUID</summary>
        /// <remarks>�ԗ��Ǘ����Ɠ`�[���ׂ�R�t����GUID�AUI���Őݒ�</remarks>
        private Guid _carRelationGuid;

        // ADD 2013/03/19 -------------------->>>>>
        /// <summary>���Y/�O�ԋ敪�R�[�h</summary>
        private Int32 _domesticForeignCode;

        /// <summary>�n���h���ʒu���R�[�h</summary>
        private Int32 _handleInfoCode;
        // ADD 2013/03/19 --------------------<<<<<

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
            get { return _createDateTime; }
            set { _createDateTime = value; }
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
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
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
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
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
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
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
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
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
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerCodeForGuide
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerCodeForGuide
        {
            get { return _customerCodeForGuide; }
            set { _customerCodeForGuide = value; }
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
            get { return _customerName; }
            set { _customerName = value; }
        }

        /// public propaty name  :  CarMngNo
        /// <summary>�ԗ��Ǘ��ԍ��v���p�e�B</summary>
        /// <value>�����̔ԁi���d���̃V�[�P���X�jPM7�ł̎ԗ�SEQ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ��Ǘ��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarMngNo
        {
            get { return _carMngNo; }
            set { _carMngNo = value; }
        }

        /// public propaty name  :  CarMngCode
        /// <summary>���q�Ǘ��R�[�h�v���p�e�B</summary>
        /// <value>��PM7�ł̎ԗ��Ǘ��ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���q�Ǘ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CarMngCode
        {
            get { return _carMngCode; }
            set { _carMngCode = value; }
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
            get { return _numberPlate1Code; }
            set { _numberPlate1Code = value; }
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
            get { return _numberPlate1Name; }
            set { _numberPlate1Name = value; }
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
            get { return _numberPlate2; }
            set { _numberPlate2 = value; }
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
            get { return _numberPlate3; }
            set { _numberPlate3 = value; }
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
            get { return _numberPlate4; }
            set { _numberPlate4 = value; }
        }

        /// public propaty name  :  NumberPlateForGuide
        /// <summary>�ԗ��o�^�ԍ��i�K�C�h�p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ��o�^�ԍ��i�K�C�h�p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string NumberPlateForGuide
        {
            get { return _numberPlateForGuide; }
            set { _numberPlateForGuide = value; }
        }

        /// public propaty name  :  EntryDate
        /// <summary>�o�^�N�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�^�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime EntryDate
        {
            get { return _entryDate; }
            set { _entryDate = value; }
        }

        /// public propaty name  :  FirstEntryDate
        /// <summary>���N�x�v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���N�x�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        // public DateTime FirstEntryDate
        public Int32 FirstEntryDate   // ADD 2009/10/10
        {
            get { return _firstEntryDate; }
            set { _firstEntryDate = value; }
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
            get { return _makerCode; }
            set { _makerCode = value; }
        }

        /// public propaty name  :  MakerFullName
        /// <summary>���[�J�[�S�p���̃v���p�e�B</summary>
        /// <value>�������́i�J�i�������݂őS�p�Ǘ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�S�p���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerFullName
        {
            get { return _makerFullName; }
            set { _makerFullName = value; }
        }

        /// public propaty name  :  MakerHalfName
        /// <summary>���[�J�[���p���̃v���p�e�B</summary>
        /// <value>�������́i���p�ŊǗ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���p���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerHalfName
        {
            get { return _makerHalfName; }
            set { _makerHalfName = value; }
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
            get { return _modelCode; }
            set { _modelCode = value; }
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
            get { return _modelSubCode; }
            set { _modelSubCode = value; }
        }

        /// public propaty name  :  ModelFullName
        /// <summary>�Ԏ�S�p���̃v���p�e�B</summary>
        /// <value>�������́i�J�i�������݂őS�p�Ǘ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�S�p���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ModelFullName
        {
            get { return _modelFullName; }
            set { _modelFullName = value; }
        }

        /// public propaty name  :  ModelHalfName
        /// <summary>�Ԏ피�p���̃v���p�e�B</summary>
        /// <value>�������́i���p�ŊǗ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ피�p���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ModelHalfName
        {
            get { return _modelHalfName; }
            set { _modelHalfName = value; }
        }

        /// public propaty name  :  SystematicCode
        /// <summary>�n���R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SystematicCode
        {
            get { return _systematicCode; }
            set { _systematicCode = value; }
        }

        /// public propaty name  :  SystematicName
        /// <summary>�n�����̃v���p�e�B</summary>
        /// <value>140�n,180�n��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SystematicName
        {
            get { return _systematicName; }
            set { _systematicName = value; }
        }

        /// public propaty name  :  ProduceTypeOfYearCd
        /// <summary>���Y�N���R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Y�N���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ProduceTypeOfYearCd
        {
            get { return _produceTypeOfYearCd; }
            set { _produceTypeOfYearCd = value; }
        }

        /// public propaty name  :  ProduceTypeOfYearNm
        /// <summary>���Y�N�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Y�N�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ProduceTypeOfYearNm
        {
            get { return _produceTypeOfYearNm; }
            set { _produceTypeOfYearNm = value; }
        }

        /// public propaty name  :  StProduceTypeOfYear
        /// <summary>�J�n���Y�N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���Y�N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StProduceTypeOfYear
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
        public DateTime EdProduceTypeOfYear
        {
            get { return _edProduceTypeOfYear; }
            set { _edProduceTypeOfYear = value; }
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

        /// public propaty name  :  BodyNameCode
        /// <summary>�{�f�B�[���R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �{�f�B�[���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BodyNameCode
        {
            get { return _bodyNameCode; }
            set { _bodyNameCode = value; }
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

        /// public propaty name  :  ExhaustGasSign
        /// <summary>�r�K�X�L���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �r�K�X�L���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ExhaustGasSign
        {
            get { return _exhaustGasSign; }
            set { _exhaustGasSign = value; }
        }

        /// public propaty name  :  SeriesModel
        /// <summary>�V���[�Y�^���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V���[�Y�^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SeriesModel
        {
            get { return _seriesModel; }
            set { _seriesModel = value; }
        }

        /// public propaty name  :  CategorySignModel
        /// <summary>�^���i�ޕʋL���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���i�ޕʋL���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CategorySignModel
        {
            get { return _categorySignModel; }
            set { _categorySignModel = value; }
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
            get { return _fullModel; }
            set { _fullModel = value; }
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
            get { return _modelDesignationNo; }
            set { _modelDesignationNo = value; }
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
            get { return _categoryNo; }
            set { _categoryNo = value; }
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
            get { return _frameModel; }
            set { _frameModel = value; }
        }

        /// public propaty name  :  FrameNo
        /// <summary>�ԑ�ԍ��v���p�e�B</summary>
        /// <value>�Ԍ��؋L�ڃt�H�[�}�b�g�Ή��i HCR32-100251584 ���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԑ�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrameNo
        {
            get { return _frameNo; }
            set { _frameNo = value; }
        }

        /// public propaty name  :  SearchFrameNo
        /// <summary>�ԑ�ԍ��i�����p�j�v���p�e�B</summary>
        /// <value>PM7�̎ԑ�ԍ��Ɠ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԑ�ԍ��i�����p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchFrameNo
        {
            get { return _searchFrameNo; }
            set { _searchFrameNo = value; }
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

        /// public propaty name  :  EngineModel
        /// <summary>�����@�^���i�G���W���j�v���p�e�B</summary>
        /// <value>�Ԍ��؋L�ڌ����@�^��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����@�^���i�G���W���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EngineModel
        {
            get { return _engineModel; }
            set { _engineModel = value; }
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
        /// <value>�V�K�ǉ�</value>
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

        /// public propaty name  :  AddiCarSpec1
        /// <summary>�ǉ�����1�v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ�����1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddiCarSpec1
        {
            get { return _addiCarSpec1; }
            set { _addiCarSpec1 = value; }
        }

        /// public propaty name  :  AddiCarSpec2
        /// <summary>�ǉ�����2�v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ�����2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddiCarSpec2
        {
            get { return _addiCarSpec2; }
            set { _addiCarSpec2 = value; }
        }

        /// public propaty name  :  AddiCarSpec3
        /// <summary>�ǉ�����3�v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ�����3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddiCarSpec3
        {
            get { return _addiCarSpec3; }
            set { _addiCarSpec3 = value; }
        }

        /// public propaty name  :  AddiCarSpec4
        /// <summary>�ǉ�����4�v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ�����4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddiCarSpec4
        {
            get { return _addiCarSpec4; }
            set { _addiCarSpec4 = value; }
        }

        /// public propaty name  :  AddiCarSpec5
        /// <summary>�ǉ�����5�v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ�����5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddiCarSpec5
        {
            get { return _addiCarSpec5; }
            set { _addiCarSpec5 = value; }
        }

        /// public propaty name  :  AddiCarSpec6
        /// <summary>�ǉ�����6�v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ�����6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddiCarSpec6
        {
            get { return _addiCarSpec6; }
            set { _addiCarSpec6 = value; }
        }

        /// public propaty name  :  AddiCarSpecTitle1
        /// <summary>�ǉ������^�C�g��1�v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ������^�C�g��1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddiCarSpecTitle1
        {
            get { return _addiCarSpecTitle1; }
            set { _addiCarSpecTitle1 = value; }
        }

        /// public propaty name  :  AddiCarSpecTitle2
        /// <summary>�ǉ������^�C�g��2�v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ������^�C�g��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddiCarSpecTitle2
        {
            get { return _addiCarSpecTitle2; }
            set { _addiCarSpecTitle2 = value; }
        }

        /// public propaty name  :  AddiCarSpecTitle3
        /// <summary>�ǉ������^�C�g��3�v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ������^�C�g��3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddiCarSpecTitle3
        {
            get { return _addiCarSpecTitle3; }
            set { _addiCarSpecTitle3 = value; }
        }

        /// public propaty name  :  AddiCarSpecTitle4
        /// <summary>�ǉ������^�C�g��4�v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ������^�C�g��4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddiCarSpecTitle4
        {
            get { return _addiCarSpecTitle4; }
            set { _addiCarSpecTitle4 = value; }
        }

        /// public propaty name  :  AddiCarSpecTitle5
        /// <summary>�ǉ������^�C�g��5�v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ������^�C�g��5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddiCarSpecTitle5
        {
            get { return _addiCarSpecTitle5; }
            set { _addiCarSpecTitle5 = value; }
        }

        /// public propaty name  :  AddiCarSpecTitle6
        /// <summary>�ǉ������^�C�g��6�v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ������^�C�g��6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddiCarSpecTitle6
        {
            get { return _addiCarSpecTitle6; }
            set { _addiCarSpecTitle6 = value; }
        }

        /// public propaty name  :  RelevanceModel
        /// <summary>�֘A�^���v���p�e�B</summary>
        /// <value>���T�C�N���n�Ŏg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �֘A�^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RelevanceModel
        {
            get { return _relevanceModel; }
            set { _relevanceModel = value; }
        }

        /// public propaty name  :  SubCarNmCd
        /// <summary>�T�u�Ԗ��R�[�h�v���p�e�B</summary>
        /// <value>���T�C�N���n�Ŏg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �T�u�Ԗ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SubCarNmCd
        {
            get { return _subCarNmCd; }
            set { _subCarNmCd = value; }
        }

        /// public propaty name  :  ModelGradeSname
        /// <summary>�^���O���[�h���̃v���p�e�B</summary>
        /// <value>���T�C�N���n�Ŏg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���O���[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ModelGradeSname
        {
            get { return _modelGradeSname; }
            set { _modelGradeSname = value; }
        }

        /// public propaty name  :  BlockIllustrationCd
        /// <summary>�u���b�N�C���X�g�R�[�h�v���p�e�B</summary>
        /// <value>����̃u���b�N�I���Ɏg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �u���b�N�C���X�g�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BlockIllustrationCd
        {
            get { return _blockIllustrationCd; }
            set { _blockIllustrationCd = value; }
        }

        /// public propaty name  :  ThreeDIllustNo
        /// <summary>3D�C���X�gNo�v���p�e�B</summary>
        /// <value>�����3D�C���X�g�I���Ɏg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   3D�C���X�gNo�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ThreeDIllustNo
        {
            get { return _threeDIllustNo; }
            set { _threeDIllustNo = value; }
        }

        /// public propaty name  :  PartsDataOfferFlag
        /// <summary>���i�f�[�^�񋟃t���O�v���p�e�B</summary>
        /// <value>0:�񋟂Ȃ�,1:�񋟂���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�f�[�^�񋟃t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsDataOfferFlag
        {
            get { return _partsDataOfferFlag; }
            set { _partsDataOfferFlag = value; }
        }

        /// public propaty name  :  InspectMaturityDate
        /// <summary>�Ԍ��������v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԍ��������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime InspectMaturityDate
        {
            get { return _inspectMaturityDate; }
            set { _inspectMaturityDate = value; }
        }

        /// public propaty name  :  LTimeCiMatDate
        /// <summary>�O��Ԍ��������v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O��Ԍ��������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime LTimeCiMatDate
        {
            get { return _lTimeCiMatDate; }
            set { _lTimeCiMatDate = value; }
        }

        /// public propaty name  :  CarInspectYear
        /// <summary>�Ԍ����ԃv���p�e�B</summary>
        /// <value>1:1�N,2:2�N,3:3�N</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԍ����ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarInspectYear
        {
            get { return _carInspectYear; }
            set { _carInspectYear = value; }
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
            get { return _mileage; }
            set { _mileage = value; }
        }

        /// public propaty name  :  CarNo
        /// <summary>���ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CarNo
        {
            get { return _carNo; }
            set { _carNo = value; }
        }

        /// public propaty name  :  ColorCode
        /// <summary>�J���[�R�[�h�v���p�e�B</summary>
        /// <value>�J�^���O�̐F�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J���[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ColorCode
        {
            get { return _colorCode; }
            set { _colorCode = value; }
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
            get { return _colorName1; }
            set { _colorName1 = value; }
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
            get { return _trimCode; }
            set { _trimCode = value; }
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
            get { return _trimName; }
            set { _trimName = value; }
        }

        /// public propaty name  :  FullModelFixedNoAry
        /// <summary>�t���^���Œ�ԍ��z��v���p�e�B</summary>
        /// <value>�t���^���Œ�A�Ԃ̔z��N���X���i�[�i�Č����s�v�ɂȂ�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t���^���Œ�ԍ��z��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32[] FullModelFixedNoAry
        {
            get { return _fullModelFixedNoAry; }
            set { _fullModelFixedNoAry = value; }
        }

        /// public propaty name  :  CategoryObjAry
        /// <summary>�����I�u�W�F�N�g�z��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����I�u�W�F�N�g�z��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Byte[] CategoryObjAry
        {
            get { return _categoryObjAry; }
            set { _categoryObjAry = value; }
        }

        /// public propaty name  :  CarRelationGuid
        /// <summary>�ԗ��֘A�t��GUID�v���p�e�B</summary>
        /// <value>�ԗ��Ǘ����Ɠ`�[���ׂ�R�t����GUID�AUI���Őݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ��֘A�t��GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid CarRelationGuid
        {
            get { return _carRelationGuid; }
            set { _carRelationGuid = value; }
        }

        /// public propaty name  :  CarAddInfo1
        /// <summary>���q�ǉ����P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���q�ǉ����P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CarAddInfo1
        {
            get { return _carAddInfo1; }
            set { _carAddInfo1 = value; }
        }

        /// public propaty name  :  CarAddInfo2
        /// <summary>���q�ǉ����Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���q�ǉ����Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CarAddInfo2
        {
            get { return _carAddInfo2; }
            set { _carAddInfo2 = value; }
        }

        /// public propaty name  :  CarNote
        /// <summary>���q���l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���q���l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CarNote
        {
            get { return _carNote; }
            set { _carNote = value; }
        }

        /// public propaty name  :  FreeSrchMdlFxdNoAry
        /// <summary>���R�����^���Œ�ԍ��z��v���p�e�B</summary>
        /// <value>���R�����V���A�����̔z��N���X���i�[�i�Č����s�v�ɂȂ�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���R�����^���Œ�ԍ��z��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] FreeSrchMdlFxdNoAry
        {
            get { return _freeSrchMdlFxdNoAry; }
            set { _freeSrchMdlFxdNoAry = value; }
        }

        /// public propaty name  :  ProduceTypeOfYearInput
        /// <summary>�N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ProduceTypeOfYearInput
        {
            get { return _produceTypeOfYearInput; }
            set { _produceTypeOfYearInput = value; }
        }

        // ADD 2013/03/19 -------------------->>>>>
        /// public propaty name  :  DomesticForeignCode
        /// <summary>���Y/�O�ԋ敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Y/�O�ԋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DomesticForeignCode
        {
            get { return _domesticForeignCode; }
            set { _domesticForeignCode = value; }
        }

        /// public propaty name  :  HandleInfoCode
        /// <summary>�n���h���ʒu���R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n���h���ʒu���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HandleInfoCode
        {
            get { return _handleInfoCode; }
            set { _handleInfoCode = value; }
        }
        // ADD 2013/03/19 --------------------<<<<<
        

        /// <summary>
        /// �ԗ��Ǘ����[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CarMangInputExtraInfo�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CarMangInputExtraInfo�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CarMangInputExtraInfo()
        {
        }

        /// <summary>
        /// ���q�Ǘ����I�u�W�F�N�g�̃R�s�[����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���q�Ǘ����I�u�W�F�N�g���R�s�[����</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public CarMangInputExtraInfo Clone()
        {
            CarMangInputExtraInfo newInfo = new CarMangInputExtraInfo();
            newInfo.EnterpriseCode = this._enterpriseCode;           // ��ƃR�[�h
            newInfo.CreateDateTime = this._createDateTime;           // �쐬����
            newInfo.FileHeaderGuid = this._fileHeaderGuid;           // GUID
            newInfo.UpdateDateTime = this._updateDateTime;           // �X�V���t
            newInfo.LogicalDeleteCode = this._logicalDeleteCode;     // �_���폜�敪
            newInfo.CustomerCode = this._customerCode;               // ���Ӑ�R�[�h
            newInfo.CustomerCodeForGuide = this._customerCodeForGuide;// ���Ӑ�R�[�h
            newInfo.CustomerName = this._customerName;               // ���Ӑ於��
            newInfo.CarMngNo = this._carMngNo;                       // �ԗ��Ǘ��ԍ�
            newInfo.CarMngCode = this._carMngCode;                   // ���q�Ǘ��R�[�h
            newInfo.NumberPlate1Code = this._numberPlate1Code;       // ���^�������ԍ�
            newInfo.NumberPlate1Name = this._numberPlate1Name;       // ���^�����ǖ���
            newInfo.NumberPlate2 = this._numberPlate2;               // �ԗ��o�^�ԍ��i��ʁj
            newInfo.NumberPlate3 = this._numberPlate3;               // �ԗ��o�^�ԍ��i�J�i�j
            newInfo.NumberPlate4 = this._numberPlate4;               // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            newInfo.NumberPlateForGuide = this._numberPlateForGuide; // �o�^�ԍ��i�K�C�h�p�j
            newInfo.EntryDate = this._entryDate;                     // �o�^�N����
            newInfo.FirstEntryDate = this._firstEntryDate;           // ���N�x
            newInfo.ProduceTypeOfYearInput = this._produceTypeOfYearInput; // �N��
            newInfo.MakerCode = this._makerCode;                     // ���[�J�[�R�[�h
            newInfo.MakerFullName = this._makerFullName;             // ���[�J�[�S�p����
            newInfo.MakerHalfName = this._makerHalfName;             // ���[�J�[���p����
            newInfo.ModelCode = this._modelCode;                     // �Ԏ�R�[�h
            newInfo.ModelSubCode = this._modelSubCode;               // �Ԏ�T�u�R�[�h
            newInfo.ModelFullName = this._modelFullName;             // �Ԏ�S�p����
            newInfo.ModelHalfName = this._modelHalfName;             // �Ԏ피�p����
            newInfo.SystematicCode = this._systematicCode;           // �n���R�[�h
            newInfo.SystematicName = this._systematicName;           // �n������
            newInfo.ProduceTypeOfYearCd = this._produceTypeOfYearCd; // ���Y�N���R�[�h
            newInfo.ProduceTypeOfYearNm = this._produceTypeOfYearNm; // ���Y�N������
            newInfo.StProduceTypeOfYear = this._stProduceTypeOfYear; // �J�n���Y�N��
            newInfo.EdProduceTypeOfYear = this._edProduceTypeOfYear; // �I�����Y�N��
            newInfo.DoorCount = this._doorCount;                     // �h�A��
            newInfo.BodyNameCode = this._bodyNameCode;               // �{�f�B�[���R�[�h
            newInfo.BodyName = this._bodyName;                       // �{�f�B�[����
            newInfo.ExhaustGasSign = this._exhaustGasSign;           // �r�K�X�L��
            newInfo.SeriesModel = this._seriesModel;                 // �V���[�Y�^��
            newInfo.CategorySignModel = this._categorySignModel;     // �^���i�ޕʋL���j
            newInfo.FullModel = this._fullModel;                     // �^���i�t���^�j
            newInfo.ModelDesignationNo = this._modelDesignationNo;   // �^���w��ԍ�
            newInfo.CategoryNo = this._categoryNo;                   // �ޕʔԍ�
            newInfo.FrameModel = this._frameModel;                   // �ԑ�^��
            newInfo.FrameNo = this._frameNo;                         // �ԑ�ԍ�
            newInfo.SearchFrameNo = this._searchFrameNo;             // �ԑ�ԍ��i�����p�j
            newInfo.StProduceFrameNo = this._stProduceFrameNo;       // ���Y�ԑ�ԍ��J�n
            newInfo.EdProduceFrameNo = this._edProduceFrameNo;       // ���Y�ԑ�ԍ��I��
            newInfo.EngineModel = this._engineModel;                 // �����@�^��
            newInfo.ModelGradeNm = this._modelGradeNm;               // �^���O���[�h����
            newInfo.EngineModelNm = this._engineModelNm;             // �G���W���^������
            newInfo.EngineDisplaceNm = this._engineDisplaceNm;       // �r�C�ʖ���
            newInfo.EDivNm = this._eDivNm;                           // E�敪����
            newInfo.TransmissionNm = this._transmissionNm;           // �~�b�V��������
            newInfo.ShiftNm = this._shiftNm;                         // �V�t�g����
            newInfo.WheelDriveMethodNm = this._wheelDriveMethodNm;   // �쓮��������
            newInfo.AddiCarSpec1 = this._addiCarSpec1;               // �ǉ�����1
            newInfo.AddiCarSpec2 = this._addiCarSpec2;               // �ǉ�����2
            newInfo.AddiCarSpec3 = this._addiCarSpec3;               // �ǉ�����3
            newInfo.AddiCarSpec4 = this._addiCarSpec4;               // �ǉ�����4
            newInfo.AddiCarSpec5 = this._addiCarSpec5;               // �ǉ�����5
            newInfo.AddiCarSpec6 = this._addiCarSpec6;               // �ǉ�����6
            newInfo.AddiCarSpecTitle1 = this._addiCarSpecTitle1;     // �ǉ������^�C�g��1
            newInfo.AddiCarSpecTitle2 = this._addiCarSpecTitle2;     // �ǉ������^�C�g��2
            newInfo.AddiCarSpecTitle3 = this._addiCarSpecTitle3;     // �ǉ������^�C�g��3
            newInfo.AddiCarSpecTitle4 = this._addiCarSpecTitle4;     // �ǉ������^�C�g��4
            newInfo.AddiCarSpecTitle5 = this._addiCarSpecTitle5;     // �ǉ������^�C�g��5
            newInfo.AddiCarSpecTitle6 = this._addiCarSpecTitle6;     // �ǉ������^�C�g��6
            newInfo.RelevanceModel = this._relevanceModel;           // �֘A�^��
            newInfo.SubCarNmCd = this._subCarNmCd;                   // �T�u�Ԗ��R�[�h
            newInfo.ModelGradeSname = this._modelGradeSname;         // �^���O���[�h����
            newInfo.BlockIllustrationCd = this._blockIllustrationCd; // �u���b�N�C���X�g�R�[�h
            newInfo.ThreeDIllustNo = this._threeDIllustNo;           // 3D�C���X�gNo
            newInfo.PartsDataOfferFlag = this._partsDataOfferFlag;   // ���i�f�[�^�񋟃t���O
            newInfo.InspectMaturityDate = this._inspectMaturityDate; // �Ԍ�������
            newInfo.LTimeCiMatDate = this._lTimeCiMatDate;           // �O��Ԍ�������
            newInfo.CarInspectYear = this._carInspectYear;           // �Ԍ�����
            newInfo.Mileage = this._mileage;                         // �ԗ����s����
            newInfo.CarNo = this._carNo;                             // ����
            newInfo.FullModelFixedNoAry = this._fullModelFixedNoAry; // �t���^���Œ�ԍ��z��
            newInfo.ColorCode = this._colorCode;                     // �J���[�R�[�h
            newInfo.ColorName1 = this._colorName1;                   // �J���[����
            newInfo.TrimCode = this._trimCode;                       // �g�����R�[�h
            newInfo.TrimName = this._trimName;                       // �g��������
            newInfo.CategoryObjAry = this._categoryObjAry;           // �����I�u�W�F�N�g�z��
            newInfo.CarAddInfo1 = this._carAddInfo1;                 // �ǉ����P
            newInfo.CarAddInfo2 = this._carAddInfo2;                 // �ǉ����Q
            newInfo.CarNote = this._carNote;                         // ���l
            newInfo.FreeSrchMdlFxdNoAry = this._freeSrchMdlFxdNoAry; // ���R�����^���Œ�ԍ��z��
            // ADD 2013/03/19 -------------------->>>>>
            newInfo.DomesticForeignCode = this._domesticForeignCode; // ���Y/�O�ԋ敪
            newInfo.HandleInfoCode = this._handleInfoCode;           // �n���h���ʒu���
            // ADD 2013/03/19 --------------------<<<<<

            return newInfo;
        }
    }
}
