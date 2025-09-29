using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   AcceptOdrCar
    /// <summary>
    ///                      �󒍃}�X�^�i�ԗ��j
    /// </summary>
    /// <remarks>
    /// <br>note             :   �󒍃}�X�^�i�ԗ��j�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/4/24</br>
    /// <br>Genarated Date   :   2008/09/08  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/9  ����</br>
    /// <br>                 :   ���ڒǉ�</br>
    /// <br>                 :   �t���^���Œ�ԍ��z��</br>
    /// <br>Update Note      :   2008/6/23  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   �Ԏ피�p����</br>
    /// <br>                 :   ���[�J�[���p����</br>
    /// <br>Update Note      :   2008/6/30  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   �����I�u�W�F�N�g�z��</br>
    /// <br>Update Note      :   2008/09/08  ���M</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   ���q���l</br>
    /// <br>Update Note      :   2010/04/27 gaoyh</br>
    /// <br>                 :   �󒍃}�X�^�i�ԗ��j���R�����^���Œ�ԍ��z��̒ǉ��Ή�</br>
    /// <br>Update Note      :   2012/05/31 30744 ���� ����q</br>
    /// <br>                 :   ��QNo10277</br>
    /// <br>                 :   SCM�󒍃f�[�^(�ԗ����)�������̐ݒ���@�̕ύX</br>
    /// <br>Update Note      :   2013/03/21 FSI���� ���T</br>
    /// <br>�Ǘ��ԍ�         :   10900269-00</br>
    /// <br>                     SPK�ԑ�ԍ�������Ή�</br>   
    /// </remarks>
    public class AcceptOdrCar
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

        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>1:���� 2:���� 3:�� 4:���� 5:�o�� 6:�d�� 7:���� 8:�ԕi 9:���� 10:�x��</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>�f�[�^���̓V�X�e��</summary>
        /// <remarks>0:����,1:����,2:���,3:�Ԕ� 10:PM,11:�d��,12:�Ɏq,13:RC </remarks>
        private Int32 _dataInputSystem;

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

        /// <summary>���N�x</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _firstEntryDate;

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

        /// <summary>�G���W���^������</summary>
        /// <remarks>�G���W������</remarks>
        private string _engineModelNm = "";

        /// <summary>�֘A�^��</summary>
        /// <remarks>���T�C�N���n�Ŏg�p</remarks>
        private string _relevanceModel = "";

        /// <summary>�T�u�Ԗ��R�[�h</summary>
        /// <remarks>���T�C�N���n�Ŏg�p</remarks>
        private Int32 _subCarNmCd;

        /// <summary>�^���O���[�h����</summary>
        /// <remarks>���T�C�N���n�Ŏg�p</remarks>
        private string _modelGradeSname = "";

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

        /// <summary>�ԗ����s����</summary>
        private Int32 _mileage;

        /// <summary>�t���^���Œ�ԍ��z��</summary>
        /// <remarks>�t���^���Œ�A�Ԃ̔z��N���X���i�[�i�Č����s�v�ɂȂ�j</remarks>
        private Int32[] _fullModelFixedNoAry;

        /// <summary>�����I�u�W�F�N�g�z��</summary>
        private Byte[] _categoryObjAry;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>�f�[�^���̓V�X�e������</summary>
        /// <remarks>����,����,���,�Ԕ�</remarks>
        private string _dataInputSystemName = "";

        /// <summary>�J���[����</summary>
        private string _colorName = "";

        // --- ADD 2009/09/08 ---------->>>>>
        /// <summary>���q���l</summary>
        private string _carNote = "";
        // --- ADD 2009/09/08 ----------<<<<<

        // --- ADD 2010/04/27 ---------->>>>>
        /// <summary>���R�����^���Œ�ԍ��z��</summary>
        /// <remarks>���R�����V���A�����̔z��N���X���i�[�i�Č����s�v�ɂȂ�j</remarks>
        private string[] _freeSrchMdlFxdNoAry = new string[0];
        // --- ADD 2010/04/27 ----------<<<<<

        // --- ADD 2012/05/31 ---------->>>>>
        /// <summary>���N�x�iNUM�^�C�v�j</summary>
        private Int32 _firstEntryDateNumTyp;
        /// <summary>�ԗ��t�����I�u�W�F�N�g</summary>
        private Byte[] _carAddInf;
        /// <summary>�������i�I�u�W�F�N�g</summary>
        private Byte[] _equipPrtsObj;
        // --- ADD 2012/05/31 ----------<<<<<

        // PMNS:���Y/�O�ԋ敪 ��ǉ�
        // --- ADD 2013/03/21 ---------->>>>>
        /// <summary>���Y/�O�ԋ敪</summary>
        private int _domesticForeignCode;
        // --- ADD 2013/03/21 ----------<<<<<

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
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
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
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
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
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
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
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
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

        /// public propaty name  :  AcceptAnOrderNo
        /// <summary>�󒍔ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcceptAnOrderNo
        {
            get { return _acceptAnOrderNo; }
            set { _acceptAnOrderNo = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>1:���� 2:���� 3:�� 4:���� 5:�o�� 6:�d�� 7:���� 8:�ԕi 9:���� 10:�x��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  DataInputSystem
        /// <summary>�f�[�^���̓V�X�e���v���p�e�B</summary>
        /// <value>0:����,1:����,2:���,3:�Ԕ� 10:PM,11:�d��,12:�Ɏq,13:RC </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^���̓V�X�e���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DataInputSystem
        {
            get { return _dataInputSystem; }
            set { _dataInputSystem = value; }
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

        /// public propaty name  :  FirstEntryDate
        /// <summary>���N�x�v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���N�x�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FirstEntryDate
        {
            get { return _firstEntryDate; }
            set { _firstEntryDate = value; }
        }

        // --- UPD 2009/09/08 ---------->>>>>
        ///// public propaty name  :  FirstEntryDateJpFormal
        ///// <summary>���N�x �a��v���p�e�B</summary>
        ///// <value>YYYYMM</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���N�x �a��v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string FirstEntryDateJpFormal
        //{
        //    get { return TDateTime.DateTimeToString("GGYYMM", _firstEntryDate); }
        //    set { }
        //}

        ///// public propaty name  :  FirstEntryDateJpInFormal
        ///// <summary>���N�x �a��(��)�v���p�e�B</summary>
        ///// <value>YYYYMM</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���N�x �a��(��)�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string FirstEntryDateJpInFormal
        //{
        //    get { return TDateTime.DateTimeToString("ggYY/MM", _firstEntryDate); }
        //    set { }
        //}

        ///// public propaty name  :  FirstEntryDateAdFormal
        ///// <summary>���N�x ����v���p�e�B</summary>
        ///// <value>YYYYMM</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���N�x ����v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string FirstEntryDateAdFormal
        //{
        //    get { return TDateTime.DateTimeToString("YYYY/MM", _firstEntryDate); }
        //    set { }
        //}

        ///// public propaty name  :  FirstEntryDateAdInFormal
        ///// <summary>���N�x ����(��)�v���p�e�B</summary>
        ///// <value>YYYYMM</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���N�x ����(��)�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string FirstEntryDateAdInFormal
        //{
        //    get { return TDateTime.DateTimeToString("YY/MM", _firstEntryDate); }
        //    set { }
        //}

        // --- UPD 2009/09/08 ----------<<<<<

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

        /// public propaty name  :  EngineModelNm
        /// <summary>�G���W���^�����̃v���p�e�B</summary>
        /// <value>�G���W������</value>
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

        /// public propaty name  :  EnterpriseName
        /// <summary>��Ɩ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��Ɩ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
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
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }

        /// public propaty name  :  DataInputSystemName
        /// <summary>�f�[�^���̓V�X�e�����̃v���p�e�B</summary>
        /// <value>����,����,���,�Ԕ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^���̓V�X�e�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DataInputSystemName
        {
            get { return _dataInputSystemName; }
            set { _dataInputSystemName = value; }
        }

        /// public propaty name  :  ColorName
        /// <summary>�J���[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J���[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ColorName
        {
            get { return _colorName; }
            set { _colorName = value; }
        }

        // --- ADD 2009/09/08 ---------->>>>>
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
        // --- ADD 2009/09/08 ----------<<<<<

        // --- ADD 2010/04/27 ---------->>>>>
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
        // --- ADD 2010/04/27 ----------<<<<
        // --- ADD 2012/05/31 ---------->>>>>
        /// public propaty name  : FirstEntryDateNumTyp
        /// <summary>���N�x�iNUM�^�C�v�j</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���N�x�iNUM�^�C�v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FirstEntryDateNumTyp
        {
            get { return _firstEntryDateNumTyp; }
            set { _firstEntryDateNumTyp = value; }
        }

        /// public propaty name  : CarAddInf
        /// <summary>�ԗ��t�����I�u�W�F�N�g</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ��t�����I�u�W�F�N�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Byte[] CarAddInf
        {
            get { return _carAddInf; }
            set { _carAddInf = value; }
        }

        /// public propaty name  : EquipPrtsObj
        /// <summary>�������i�I�u�W�F�N�g</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������i�I�u�W�F�N�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Byte[] EquipPrtsObj
        {
            get { return _equipPrtsObj; }
            set { _equipPrtsObj = value; }
        }
        // --- ADD 2012/05/31 ----------<<<<<

        // PMNS:���Y/�O�ԋ敪 ��ǉ�
        // --- ADD 2013/03/21 ---------->>>>>
        /// public propaty name  :  DomesticForeignCode
        /// <summary>���Y/�O�ԋ敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Y/�O�ԋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int DomesticForeignCode
        {
            get { return _domesticForeignCode; }
            set { _domesticForeignCode = value; }
        }
        // --- ADD 2013/03/21 ----------<<<<<

        /// <summary>
        /// �󒍃}�X�^�i�ԗ��j�R���X�g���N�^
        /// </summary>
        /// <returns>AcceptOdrCar�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AcceptOdrCar�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public AcceptOdrCar()
        {
        }

        /// <summary>
        /// �󒍃}�X�^�i�ԗ��j�R���X�g���N�^
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
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X(1:���� 2:���� 3:�� 4:���� 5:�o�� 6:�d�� 7:���� 8:�ԕi 9:���� 10:�x��)</param>
        /// <param name="dataInputSystem">�f�[�^���̓V�X�e��(0:����,1:����,2:���,3:�Ԕ� 10:PM,11:�d��,12:�Ɏq,13:RC )</param>
        /// <param name="carMngNo">�ԗ��Ǘ��ԍ�(�����̔ԁi���d���̃V�[�P���X�jPM7�ł̎ԗ�SEQ)</param>
        /// <param name="carMngCode">���q�Ǘ��R�[�h(��PM7�ł̎ԗ��Ǘ��ԍ�)</param>
        /// <param name="numberPlate1Code">���^�������ԍ�</param>
        /// <param name="numberPlate1Name">���^�����ǖ���</param>
        /// <param name="numberPlate2">�ԗ��o�^�ԍ��i��ʁj</param>
        /// <param name="numberPlate3">�ԗ��o�^�ԍ��i�J�i�j</param>
        /// <param name="numberPlate4">�ԗ��o�^�ԍ��i�v���[�g�ԍ��j</param>
        /// <param name="firstEntryDate">���N�x(YYYYMM)</param>
        /// <param name="makerCode">���[�J�[�R�[�h(1�`899:�񋟕�, 900�`���[�U�[�o�^)</param>
        /// <param name="makerFullName">���[�J�[�S�p����(�������́i�J�i�������݂őS�p�Ǘ��j)</param>
        /// <param name="makerHalfName">���[�J�[���p����(�������́i���p�ŊǗ��j)</param>
        /// <param name="modelCode">�Ԏ�R�[�h(�Ԗ��R�[�h(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^)</param>
        /// <param name="modelSubCode">�Ԏ�T�u�R�[�h(0�`899:�񋟕�,900�`հ�ް�o�^)</param>
        /// <param name="modelFullName">�Ԏ�S�p����(�������́i�J�i�������݂őS�p�Ǘ��j)</param>
        /// <param name="modelHalfName">�Ԏ피�p����(�������́i���p�ŊǗ��j)</param>
        /// <param name="exhaustGasSign">�r�K�X�L��</param>
        /// <param name="seriesModel">�V���[�Y�^��</param>
        /// <param name="categorySignModel">�^���i�ޕʋL���j</param>
        /// <param name="fullModel">�^���i�t���^�j(�t���^��(44���p))</param>
        /// <param name="modelDesignationNo">�^���w��ԍ�</param>
        /// <param name="categoryNo">�ޕʔԍ�</param>
        /// <param name="frameModel">�ԑ�^��</param>
        /// <param name="frameNo">�ԑ�ԍ�(�Ԍ��؋L�ڃt�H�[�}�b�g�Ή��i HCR32-100251584 ���j)</param>
        /// <param name="searchFrameNo">�ԑ�ԍ��i�����p�j(PM7�̎ԑ�ԍ��Ɠ���)</param>
        /// <param name="engineModelNm">�G���W���^������(�G���W������)</param>
        /// <param name="relevanceModel">�֘A�^��(���T�C�N���n�Ŏg�p)</param>
        /// <param name="subCarNmCd">�T�u�Ԗ��R�[�h(���T�C�N���n�Ŏg�p)</param>
        /// <param name="modelGradeSname">�^���O���[�h����(���T�C�N���n�Ŏg�p)</param>
        /// <param name="colorCode">�J���[�R�[�h(�J�^���O�̐F�R�[�h)</param>
        /// <param name="colorName1">�J���[����1(��ʕ\���p��������)</param>
        /// <param name="trimCode">�g�����R�[�h</param>
        /// <param name="trimName">�g��������</param>
        /// <param name="mileage">�ԗ����s����</param>
        /// <param name="fullModelFixedNoAry">�t���^���Œ�ԍ��z��(�t���^���Œ�A�Ԃ̔z��N���X���i�[�i�Č����s�v�ɂȂ�j)</param>
        /// <param name="categoryObjAry">�����I�u�W�F�N�g�z��</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="dataInputSystemName">�f�[�^���̓V�X�e������(����,����,���,�Ԕ�)</param>
        /// <param name="colorName">�J���[����</param>
        /// <param name="carNote">���q���l</param>
        /// <param name="freeSrchMdlFxdNoAry"></param>
        /// <returns>AcceptOdrCar�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AcceptOdrCar�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        //public AcceptOdrCar(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acceptAnOrderNo, Int32 acptAnOdrStatus, Int32 dataInputSystem, Int32 carMngNo, string carMngCode, Int32 numberPlate1Code, string numberPlate1Name, string numberPlate2, string numberPlate3, Int32 numberPlate4, Int32 firstEntryDate, Int32 makerCode, string makerFullName, string makerHalfName, Int32 modelCode, Int32 modelSubCode, string modelFullName, string modelHalfName, string exhaustGasSign, string seriesModel, string categorySignModel, string fullModel, Int32 modelDesignationNo, Int32 categoryNo, string frameModel, string frameNo, Int32 searchFrameNo, string engineModelNm, string relevanceModel, Int32 subCarNmCd, string modelGradeSname, string colorCode, string colorName1, string trimCode, string trimName, Int32 mileage, Int32[] fullModelFixedNoAry, Byte[] categoryObjAry, string enterpriseName, string updEmployeeName, string dataInputSystemName, string colorName, string carNote) // DEL 2010/04/27
        // --- UPD 2012/05/31 ---------->>>>>
        //public AcceptOdrCar(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acceptAnOrderNo, Int32 acptAnOdrStatus, Int32 dataInputSystem, Int32 carMngNo, string carMngCode, Int32 numberPlate1Code, string numberPlate1Name, string numberPlate2, string numberPlate3, Int32 numberPlate4, Int32 firstEntryDate, Int32 makerCode, string makerFullName, string makerHalfName, Int32 modelCode, Int32 modelSubCode, string modelFullName, string modelHalfName, string exhaustGasSign, string seriesModel, string categorySignModel, string fullModel, Int32 modelDesignationNo, Int32 categoryNo, string frameModel, string frameNo, Int32 searchFrameNo, string engineModelNm, string relevanceModel, Int32 subCarNmCd, string modelGradeSname, string colorCode, string colorName1, string trimCode, string trimName, Int32 mileage, Int32[] fullModelFixedNoAry, Byte[] categoryObjAry, string enterpriseName, string updEmployeeName, string dataInputSystemName, string colorName, string carNote, string[] freeSrchMdlFxdNoAry) // ADD 2010/04/27
        // --- UPD 2013/03/21 ---------->>>>>
        //public AcceptOdrCar(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acceptAnOrderNo, Int32 acptAnOdrStatus, Int32 dataInputSystem, Int32 carMngNo, string carMngCode, Int32 numberPlate1Code, string numberPlate1Name, string numberPlate2, string numberPlate3, Int32 numberPlate4, Int32 firstEntryDate, Int32 makerCode, string makerFullName, string makerHalfName, Int32 modelCode, Int32 modelSubCode, string modelFullName, string modelHalfName, string exhaustGasSign, string seriesModel, string categorySignModel, string fullModel, Int32 modelDesignationNo, Int32 categoryNo, string frameModel, string frameNo, Int32 searchFrameNo, string engineModelNm, string relevanceModel, Int32 subCarNmCd, string modelGradeSname, string colorCode, string colorName1, string trimCode, string trimName, Int32 mileage, Int32[] fullModelFixedNoAry, Byte[] categoryObjAry, string enterpriseName, string updEmployeeName, string dataInputSystemName, string colorName, string carNote, string[] freeSrchMdlFxdNoAry, int firstEntryDateNumTypm, Byte[] carAddInf, Byte[] equipPrtsObj)
        public AcceptOdrCar(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acceptAnOrderNo, Int32 acptAnOdrStatus, Int32 dataInputSystem, Int32 carMngNo, string carMngCode, Int32 numberPlate1Code, string numberPlate1Name, string numberPlate2, string numberPlate3, Int32 numberPlate4, Int32 firstEntryDate, Int32 makerCode, string makerFullName, string makerHalfName, Int32 modelCode, Int32 modelSubCode, string modelFullName, string modelHalfName, string exhaustGasSign, string seriesModel, string categorySignModel, string fullModel, Int32 modelDesignationNo, Int32 categoryNo, string frameModel, string frameNo, Int32 searchFrameNo, string engineModelNm, string relevanceModel, Int32 subCarNmCd, string modelGradeSname, string colorCode, string colorName1, string trimCode, string trimName, Int32 mileage, Int32[] fullModelFixedNoAry, Byte[] categoryObjAry, string enterpriseName, string updEmployeeName, string dataInputSystemName, string colorName, string carNote, string[] freeSrchMdlFxdNoAry, int firstEntryDateNumTypm, Byte[] carAddInf, Byte[] equipPrtsObj, int domesticForeignCode)
        // --- UPD 2013/03/21 ----------<<<<<
        // --- UPD 2012/05/31 ----------<<<<<
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
            this._acptAnOdrStatus = acptAnOdrStatus;
            this._dataInputSystem = dataInputSystem;
            this._carMngNo = carMngNo;
            this._carMngCode = carMngCode;
            this._numberPlate1Code = numberPlate1Code;
            this._numberPlate1Name = numberPlate1Name;
            this._numberPlate2 = numberPlate2;
            this._numberPlate3 = numberPlate3;
            this._numberPlate4 = numberPlate4;
            this.FirstEntryDate = firstEntryDate;
            this._makerCode = makerCode;
            this._makerFullName = makerFullName;
            this._makerHalfName = makerHalfName;
            this._modelCode = modelCode;
            this._modelSubCode = modelSubCode;
            this._modelFullName = modelFullName;
            this._modelHalfName = modelHalfName;
            this._exhaustGasSign = exhaustGasSign;
            this._seriesModel = seriesModel;
            this._categorySignModel = categorySignModel;
            this._fullModel = fullModel;
            this._modelDesignationNo = modelDesignationNo;
            this._categoryNo = categoryNo;
            this._frameModel = frameModel;
            this._frameNo = frameNo;
            this._searchFrameNo = searchFrameNo;
            this._engineModelNm = engineModelNm;
            this._relevanceModel = relevanceModel;
            this._subCarNmCd = subCarNmCd;
            this._modelGradeSname = modelGradeSname;
            this._colorCode = colorCode;
            this._colorName1 = colorName1;
            this._trimCode = trimCode;
            this._trimName = trimName;
            this._mileage = mileage;
            this._fullModelFixedNoAry = fullModelFixedNoAry;
            this._categoryObjAry = categoryObjAry;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._dataInputSystemName = dataInputSystemName;
            this._colorName = colorName;
            this._carNote = CarNote;
            this._freeSrchMdlFxdNoAry = freeSrchMdlFxdNoAry; // ADD 2010/04/27
            // --- ADD 2012/05/31 ---------->>>>>
            this._firstEntryDateNumTyp = FirstEntryDateNumTyp;
            this._carAddInf = carAddInf;
            this._equipPrtsObj = EquipPrtsObj;
            // --- ADD 2012/05/31 ----------<<<<<
            // --- ADD 2013/03/21 ---------->>>>>
            this._domesticForeignCode = domesticForeignCode;
            // --- ADD 2013/03/21 ----------<<<<<
        }

        /// <summary>
        /// �󒍃}�X�^�i�ԗ��j��������
        /// </summary>
        /// <returns>AcceptOdrCar�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����AcceptOdrCar�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public AcceptOdrCar Clone()
        {
            //return new AcceptOdrCar(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acceptAnOrderNo, this._acptAnOdrStatus, this._dataInputSystem, this._carMngNo, this._carMngCode, this._numberPlate1Code, this._numberPlate1Name, this._numberPlate2, this._numberPlate3, this._numberPlate4, this._firstEntryDate, this._makerCode, this._makerFullName, this._makerHalfName, this._modelCode, this._modelSubCode, this._modelFullName, this._modelHalfName, this._exhaustGasSign, this._seriesModel, this._categorySignModel, this._fullModel, this._modelDesignationNo, this._categoryNo, this._frameModel, this._frameNo, this._searchFrameNo, this._engineModelNm, this._relevanceModel, this._subCarNmCd, this._modelGradeSname, this._colorCode, this._colorName1, this._trimCode, this._trimName, this._mileage, this._fullModelFixedNoAry, this._categoryObjAry, this._enterpriseName, this._updEmployeeName, this._dataInputSystemName, this._colorName, this._carNote); // DEL 2010/04/27
            // --- UPD 2012/05/31 ---------->>>>>
            //return new AcceptOdrCar(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acceptAnOrderNo, this._acptAnOdrStatus, this._dataInputSystem, this._carMngNo, this._carMngCode, this._numberPlate1Code, this._numberPlate1Name, this._numberPlate2, this._numberPlate3, this._numberPlate4, this._firstEntryDate, this._makerCode, this._makerFullName, this._makerHalfName, this._modelCode, this._modelSubCode, this._modelFullName, this._modelHalfName, this._exhaustGasSign, this._seriesModel, this._categorySignModel, this._fullModel, this._modelDesignationNo, this._categoryNo, this._frameModel, this._frameNo, this._searchFrameNo, this._engineModelNm, this._relevanceModel, this._subCarNmCd, this._modelGradeSname, this._colorCode, this._colorName1, this._trimCode, this._trimName, this._mileage, this._fullModelFixedNoAry, this._categoryObjAry, this._enterpriseName, this._updEmployeeName, this._dataInputSystemName, this._colorName, this._carNote, this._freeSrchMdlFxdNoAry); // ADD 2010/04/27
            // --- UPD 2013/03/21 ---------->>>>>
            //return new AcceptOdrCar(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acceptAnOrderNo, this._acptAnOdrStatus, this._dataInputSystem, this._carMngNo, this._carMngCode, this._numberPlate1Code, this._numberPlate1Name, this._numberPlate2, this._numberPlate3, this._numberPlate4, this._firstEntryDate, this._makerCode, this._makerFullName, this._makerHalfName, this._modelCode, this._modelSubCode, this._modelFullName, this._modelHalfName, this._exhaustGasSign, this._seriesModel, this._categorySignModel, this._fullModel, this._modelDesignationNo, this._categoryNo, this._frameModel, this._frameNo, this._searchFrameNo, this._engineModelNm, this._relevanceModel, this._subCarNmCd, this._modelGradeSname, this._colorCode, this._colorName1, this._trimCode, this._trimName, this._mileage, this._fullModelFixedNoAry, this._categoryObjAry, this._enterpriseName, this._updEmployeeName, this._dataInputSystemName, this._colorName, this._carNote, this._freeSrchMdlFxdNoAry, this._firstEntryDateNumTyp, this._carAddInf, this._equipPrtsObj);
            return new AcceptOdrCar(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acceptAnOrderNo, this._acptAnOdrStatus, this._dataInputSystem, this._carMngNo, this._carMngCode, this._numberPlate1Code, this._numberPlate1Name, this._numberPlate2, this._numberPlate3, this._numberPlate4, this._firstEntryDate, this._makerCode, this._makerFullName, this._makerHalfName, this._modelCode, this._modelSubCode, this._modelFullName, this._modelHalfName, this._exhaustGasSign, this._seriesModel, this._categorySignModel, this._fullModel, this._modelDesignationNo, this._categoryNo, this._frameModel, this._frameNo, this._searchFrameNo, this._engineModelNm, this._relevanceModel, this._subCarNmCd, this._modelGradeSname, this._colorCode, this._colorName1, this._trimCode, this._trimName, this._mileage, this._fullModelFixedNoAry, this._categoryObjAry, this._enterpriseName, this._updEmployeeName, this._dataInputSystemName, this._colorName, this._carNote, this._freeSrchMdlFxdNoAry, this._firstEntryDateNumTyp, this._carAddInf, this._equipPrtsObj, this._domesticForeignCode);
            // --- UPD 2013/03/21 ----------<<<<<
            // --- UPD 2012/05/31 ----------<<<<<
        }

        /// <summary>
        /// �󒍃}�X�^�i�ԗ��j��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�AcceptOdrCar�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AcceptOdrCar�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(AcceptOdrCar target)
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
                 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
                 && (this.DataInputSystem == target.DataInputSystem)
                 && (this.CarMngNo == target.CarMngNo)
                 && (this.CarMngCode == target.CarMngCode)
                 && (this.NumberPlate1Code == target.NumberPlate1Code)
                 && (this.NumberPlate1Name == target.NumberPlate1Name)
                 && (this.NumberPlate2 == target.NumberPlate2)
                 && (this.NumberPlate3 == target.NumberPlate3)
                 && (this.NumberPlate4 == target.NumberPlate4)
                 && (this.FirstEntryDate == target.FirstEntryDate)
                 && (this.MakerCode == target.MakerCode)
                 && (this.MakerFullName == target.MakerFullName)
                 && (this.MakerHalfName == target.MakerHalfName)
                 && (this.ModelCode == target.ModelCode)
                 && (this.ModelSubCode == target.ModelSubCode)
                 && (this.ModelFullName == target.ModelFullName)
                 && (this.ModelHalfName == target.ModelHalfName)
                 && (this.ExhaustGasSign == target.ExhaustGasSign)
                 && (this.SeriesModel == target.SeriesModel)
                 && (this.CategorySignModel == target.CategorySignModel)
                 && (this.FullModel == target.FullModel)
                 && (this.ModelDesignationNo == target.ModelDesignationNo)
                 && (this.CategoryNo == target.CategoryNo)
                 && (this.FrameModel == target.FrameModel)
                 && (this.FrameNo == target.FrameNo)
                 && (this.SearchFrameNo == target.SearchFrameNo)
                 && (this.EngineModelNm == target.EngineModelNm)
                 && (this.RelevanceModel == target.RelevanceModel)
                 && (this.SubCarNmCd == target.SubCarNmCd)
                 && (this.ModelGradeSname == target.ModelGradeSname)
                 && (this.ColorCode == target.ColorCode)
                 && (this.ColorName1 == target.ColorName1)
                 && (this.TrimCode == target.TrimCode)
                 && (this.TrimName == target.TrimName)
                 && (this.Mileage == target.Mileage)
                 && (this.FullModelFixedNoAry == target.FullModelFixedNoAry)
                 && (this.CategoryObjAry == target.CategoryObjAry)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.DataInputSystemName == target.DataInputSystemName)
                 && (this.ColorName == target.ColorName)
                 && (this.CarNote == target.CarNote)
                 && (this._freeSrchMdlFxdNoAry == target.FreeSrchMdlFxdNoAry) // ADD 2010/04/27
                // --- ADD 2012/05/31 ---------->>>>>
                 && (this.FirstEntryDateNumTyp == target.FirstEntryDateNumTyp)
                 && (this.CarAddInf == target.CarAddInf)
                 && (this.EquipPrtsObj == target.EquipPrtsObj)
                // --- ADD 2012/05/31 ----------<<<<<
            );
        }

        /// <summary>
        /// �󒍃}�X�^�i�ԗ��j��r����
        /// </summary>
        /// <param name="acceptOdrCar1">
        ///                    ��r����AcceptOdrCar�N���X�̃C���X�^���X
        /// </param>
        /// <param name="acceptOdrCar2">��r����AcceptOdrCar�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AcceptOdrCar�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(AcceptOdrCar acceptOdrCar1, AcceptOdrCar acceptOdrCar2)
        {
            return ((acceptOdrCar1.CreateDateTime == acceptOdrCar2.CreateDateTime)
                 && (acceptOdrCar1.UpdateDateTime == acceptOdrCar2.UpdateDateTime)
                 && (acceptOdrCar1.EnterpriseCode == acceptOdrCar2.EnterpriseCode)
                 && (acceptOdrCar1.FileHeaderGuid == acceptOdrCar2.FileHeaderGuid)
                 && (acceptOdrCar1.UpdEmployeeCode == acceptOdrCar2.UpdEmployeeCode)
                 && (acceptOdrCar1.UpdAssemblyId1 == acceptOdrCar2.UpdAssemblyId1)
                 && (acceptOdrCar1.UpdAssemblyId2 == acceptOdrCar2.UpdAssemblyId2)
                 && (acceptOdrCar1.LogicalDeleteCode == acceptOdrCar2.LogicalDeleteCode)
                 && (acceptOdrCar1.AcceptAnOrderNo == acceptOdrCar2.AcceptAnOrderNo)
                 && (acceptOdrCar1.AcptAnOdrStatus == acceptOdrCar2.AcptAnOdrStatus)
                 && (acceptOdrCar1.DataInputSystem == acceptOdrCar2.DataInputSystem)
                 && (acceptOdrCar1.CarMngNo == acceptOdrCar2.CarMngNo)
                 && (acceptOdrCar1.CarMngCode == acceptOdrCar2.CarMngCode)
                 && (acceptOdrCar1.NumberPlate1Code == acceptOdrCar2.NumberPlate1Code)
                 && (acceptOdrCar1.NumberPlate1Name == acceptOdrCar2.NumberPlate1Name)
                 && (acceptOdrCar1.NumberPlate2 == acceptOdrCar2.NumberPlate2)
                 && (acceptOdrCar1.NumberPlate3 == acceptOdrCar2.NumberPlate3)
                 && (acceptOdrCar1.NumberPlate4 == acceptOdrCar2.NumberPlate4)
                 && (acceptOdrCar1.FirstEntryDate == acceptOdrCar2.FirstEntryDate)
                 && (acceptOdrCar1.MakerCode == acceptOdrCar2.MakerCode)
                 && (acceptOdrCar1.MakerFullName == acceptOdrCar2.MakerFullName)
                 && (acceptOdrCar1.MakerHalfName == acceptOdrCar2.MakerHalfName)
                 && (acceptOdrCar1.ModelCode == acceptOdrCar2.ModelCode)
                 && (acceptOdrCar1.ModelSubCode == acceptOdrCar2.ModelSubCode)
                 && (acceptOdrCar1.ModelFullName == acceptOdrCar2.ModelFullName)
                 && (acceptOdrCar1.ModelHalfName == acceptOdrCar2.ModelHalfName)
                 && (acceptOdrCar1.ExhaustGasSign == acceptOdrCar2.ExhaustGasSign)
                 && (acceptOdrCar1.SeriesModel == acceptOdrCar2.SeriesModel)
                 && (acceptOdrCar1.CategorySignModel == acceptOdrCar2.CategorySignModel)
                 && (acceptOdrCar1.FullModel == acceptOdrCar2.FullModel)
                 && (acceptOdrCar1.ModelDesignationNo == acceptOdrCar2.ModelDesignationNo)
                 && (acceptOdrCar1.CategoryNo == acceptOdrCar2.CategoryNo)
                 && (acceptOdrCar1.FrameModel == acceptOdrCar2.FrameModel)
                 && (acceptOdrCar1.FrameNo == acceptOdrCar2.FrameNo)
                 && (acceptOdrCar1.SearchFrameNo == acceptOdrCar2.SearchFrameNo)
                 && (acceptOdrCar1.EngineModelNm == acceptOdrCar2.EngineModelNm)
                 && (acceptOdrCar1.RelevanceModel == acceptOdrCar2.RelevanceModel)
                 && (acceptOdrCar1.SubCarNmCd == acceptOdrCar2.SubCarNmCd)
                 && (acceptOdrCar1.ModelGradeSname == acceptOdrCar2.ModelGradeSname)
                 && (acceptOdrCar1.ColorCode == acceptOdrCar2.ColorCode)
                 && (acceptOdrCar1.ColorName1 == acceptOdrCar2.ColorName1)
                 && (acceptOdrCar1.TrimCode == acceptOdrCar2.TrimCode)
                 && (acceptOdrCar1.TrimName == acceptOdrCar2.TrimName)
                 && (acceptOdrCar1.Mileage == acceptOdrCar2.Mileage)
                 && (acceptOdrCar1.FullModelFixedNoAry == acceptOdrCar2.FullModelFixedNoAry)
                 && (acceptOdrCar1.CategoryObjAry == acceptOdrCar2.CategoryObjAry)
                 && (acceptOdrCar1.EnterpriseName == acceptOdrCar2.EnterpriseName)
                 && (acceptOdrCar1.UpdEmployeeName == acceptOdrCar2.UpdEmployeeName)
                 && (acceptOdrCar1.DataInputSystemName == acceptOdrCar2.DataInputSystemName)
                 && (acceptOdrCar1.ColorName == acceptOdrCar2.ColorName)
                 && (acceptOdrCar1.CarNote == acceptOdrCar2.CarNote)
                 && (acceptOdrCar1.FreeSrchMdlFxdNoAry == acceptOdrCar2.FreeSrchMdlFxdNoAry) // ADD 2010/04/27
                // --- ADD 2012/05/31 ---------->>>>>
                 && (acceptOdrCar1.FirstEntryDateNumTyp == acceptOdrCar2.FirstEntryDateNumTyp)
                 && (acceptOdrCar1.CarAddInf == acceptOdrCar2.CarAddInf)
                 && (acceptOdrCar1.EquipPrtsObj == acceptOdrCar2.EquipPrtsObj)
                // --- ADD 2012/05/31 ----------<<<<<
            );
        }
        /// <summary>
        /// �󒍃}�X�^�i�ԗ��j��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�AcceptOdrCar�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AcceptOdrCar�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(AcceptOdrCar target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.AcceptAnOrderNo != target.AcceptAnOrderNo) resList.Add("AcceptAnOrderNo");
            if (this.AcptAnOdrStatus != target.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (this.DataInputSystem != target.DataInputSystem) resList.Add("DataInputSystem");
            if (this.CarMngNo != target.CarMngNo) resList.Add("CarMngNo");
            if (this.CarMngCode != target.CarMngCode) resList.Add("CarMngCode");
            if (this.NumberPlate1Code != target.NumberPlate1Code) resList.Add("NumberPlate1Code");
            if (this.NumberPlate1Name != target.NumberPlate1Name) resList.Add("NumberPlate1Name");
            if (this.NumberPlate2 != target.NumberPlate2) resList.Add("NumberPlate2");
            if (this.NumberPlate3 != target.NumberPlate3) resList.Add("NumberPlate3");
            if (this.NumberPlate4 != target.NumberPlate4) resList.Add("NumberPlate4");
            if (this.FirstEntryDate != target.FirstEntryDate) resList.Add("FirstEntryDate");
            if (this.MakerCode != target.MakerCode) resList.Add("MakerCode");
            if (this.MakerFullName != target.MakerFullName) resList.Add("MakerFullName");
            if (this.MakerHalfName != target.MakerHalfName) resList.Add("MakerHalfName");
            if (this.ModelCode != target.ModelCode) resList.Add("ModelCode");
            if (this.ModelSubCode != target.ModelSubCode) resList.Add("ModelSubCode");
            if (this.ModelFullName != target.ModelFullName) resList.Add("ModelFullName");
            if (this.ModelHalfName != target.ModelHalfName) resList.Add("ModelHalfName");
            if (this.ExhaustGasSign != target.ExhaustGasSign) resList.Add("ExhaustGasSign");
            if (this.SeriesModel != target.SeriesModel) resList.Add("SeriesModel");
            if (this.CategorySignModel != target.CategorySignModel) resList.Add("CategorySignModel");
            if (this.FullModel != target.FullModel) resList.Add("FullModel");
            if (this.ModelDesignationNo != target.ModelDesignationNo) resList.Add("ModelDesignationNo");
            if (this.CategoryNo != target.CategoryNo) resList.Add("CategoryNo");
            if (this.FrameModel != target.FrameModel) resList.Add("FrameModel");
            if (this.FrameNo != target.FrameNo) resList.Add("FrameNo");
            if (this.SearchFrameNo != target.SearchFrameNo) resList.Add("SearchFrameNo");
            if (this.EngineModelNm != target.EngineModelNm) resList.Add("EngineModelNm");
            if (this.RelevanceModel != target.RelevanceModel) resList.Add("RelevanceModel");
            if (this.SubCarNmCd != target.SubCarNmCd) resList.Add("SubCarNmCd");
            if (this.ModelGradeSname != target.ModelGradeSname) resList.Add("ModelGradeSname");
            if (this.ColorCode != target.ColorCode) resList.Add("ColorCode");
            if (this.ColorName1 != target.ColorName1) resList.Add("ColorName1");
            if (this.TrimCode != target.TrimCode) resList.Add("TrimCode");
            if (this.TrimName != target.TrimName) resList.Add("TrimName");
            if (this.Mileage != target.Mileage) resList.Add("Mileage");
            if (this.FullModelFixedNoAry != target.FullModelFixedNoAry) resList.Add("FullModelFixedNoAry");
            if (this.CategoryObjAry != target.CategoryObjAry) resList.Add("CategoryObjAry");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.DataInputSystemName != target.DataInputSystemName) resList.Add("DataInputSystemName");
            if (this.ColorName != target.ColorName) resList.Add("ColorName");
            if (this.CarNote != target.CarNote) resList.Add("CarNote");
            if (this._freeSrchMdlFxdNoAry != target.FreeSrchMdlFxdNoAry) resList.Add("FreeSrchMdlFxdNoAry"); // ADD 2010/04/27
            // --- ADD 2012/05/31 ---------->>>>>
            if (this.FirstEntryDateNumTyp != target.FirstEntryDateNumTyp) resList.Add("FirstEntryDateNumTyp");
            if (this.CarAddInf != target.CarAddInf) resList.Add("CarAddInf");
            if (this.EquipPrtsObj != target.EquipPrtsObj) resList.Add("EquipPrtsObj");
            // --- ADD 2012/05/31 ----------<<<<<

            return resList;
        }

        /// <summary>
        /// �󒍃}�X�^�i�ԗ��j��r����
        /// </summary>
        /// <param name="acceptOdrCar1">��r����AcceptOdrCar�N���X�̃C���X�^���X</param>
        /// <param name="acceptOdrCar2">��r����AcceptOdrCar�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AcceptOdrCar�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(AcceptOdrCar acceptOdrCar1, AcceptOdrCar acceptOdrCar2)
        {
            ArrayList resList = new ArrayList();
            if (acceptOdrCar1.CreateDateTime != acceptOdrCar2.CreateDateTime) resList.Add("CreateDateTime");
            if (acceptOdrCar1.UpdateDateTime != acceptOdrCar2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (acceptOdrCar1.EnterpriseCode != acceptOdrCar2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (acceptOdrCar1.FileHeaderGuid != acceptOdrCar2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (acceptOdrCar1.UpdEmployeeCode != acceptOdrCar2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (acceptOdrCar1.UpdAssemblyId1 != acceptOdrCar2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (acceptOdrCar1.UpdAssemblyId2 != acceptOdrCar2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (acceptOdrCar1.LogicalDeleteCode != acceptOdrCar2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (acceptOdrCar1.AcceptAnOrderNo != acceptOdrCar2.AcceptAnOrderNo) resList.Add("AcceptAnOrderNo");
            if (acceptOdrCar1.AcptAnOdrStatus != acceptOdrCar2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (acceptOdrCar1.DataInputSystem != acceptOdrCar2.DataInputSystem) resList.Add("DataInputSystem");
            if (acceptOdrCar1.CarMngNo != acceptOdrCar2.CarMngNo) resList.Add("CarMngNo");
            if (acceptOdrCar1.CarMngCode != acceptOdrCar2.CarMngCode) resList.Add("CarMngCode");
            if (acceptOdrCar1.NumberPlate1Code != acceptOdrCar2.NumberPlate1Code) resList.Add("NumberPlate1Code");
            if (acceptOdrCar1.NumberPlate1Name != acceptOdrCar2.NumberPlate1Name) resList.Add("NumberPlate1Name");
            if (acceptOdrCar1.NumberPlate2 != acceptOdrCar2.NumberPlate2) resList.Add("NumberPlate2");
            if (acceptOdrCar1.NumberPlate3 != acceptOdrCar2.NumberPlate3) resList.Add("NumberPlate3");
            if (acceptOdrCar1.NumberPlate4 != acceptOdrCar2.NumberPlate4) resList.Add("NumberPlate4");
            if (acceptOdrCar1.FirstEntryDate != acceptOdrCar2.FirstEntryDate) resList.Add("FirstEntryDate");
            if (acceptOdrCar1.MakerCode != acceptOdrCar2.MakerCode) resList.Add("MakerCode");
            if (acceptOdrCar1.MakerFullName != acceptOdrCar2.MakerFullName) resList.Add("MakerFullName");
            if (acceptOdrCar1.MakerHalfName != acceptOdrCar2.MakerHalfName) resList.Add("MakerHalfName");
            if (acceptOdrCar1.ModelCode != acceptOdrCar2.ModelCode) resList.Add("ModelCode");
            if (acceptOdrCar1.ModelSubCode != acceptOdrCar2.ModelSubCode) resList.Add("ModelSubCode");
            if (acceptOdrCar1.ModelFullName != acceptOdrCar2.ModelFullName) resList.Add("ModelFullName");
            if (acceptOdrCar1.ModelHalfName != acceptOdrCar2.ModelHalfName) resList.Add("ModelHalfName");
            if (acceptOdrCar1.ExhaustGasSign != acceptOdrCar2.ExhaustGasSign) resList.Add("ExhaustGasSign");
            if (acceptOdrCar1.SeriesModel != acceptOdrCar2.SeriesModel) resList.Add("SeriesModel");
            if (acceptOdrCar1.CategorySignModel != acceptOdrCar2.CategorySignModel) resList.Add("CategorySignModel");
            if (acceptOdrCar1.FullModel != acceptOdrCar2.FullModel) resList.Add("FullModel");
            if (acceptOdrCar1.ModelDesignationNo != acceptOdrCar2.ModelDesignationNo) resList.Add("ModelDesignationNo");
            if (acceptOdrCar1.CategoryNo != acceptOdrCar2.CategoryNo) resList.Add("CategoryNo");
            if (acceptOdrCar1.FrameModel != acceptOdrCar2.FrameModel) resList.Add("FrameModel");
            if (acceptOdrCar1.FrameNo != acceptOdrCar2.FrameNo) resList.Add("FrameNo");
            if (acceptOdrCar1.SearchFrameNo != acceptOdrCar2.SearchFrameNo) resList.Add("SearchFrameNo");
            if (acceptOdrCar1.EngineModelNm != acceptOdrCar2.EngineModelNm) resList.Add("EngineModelNm");
            if (acceptOdrCar1.RelevanceModel != acceptOdrCar2.RelevanceModel) resList.Add("RelevanceModel");
            if (acceptOdrCar1.SubCarNmCd != acceptOdrCar2.SubCarNmCd) resList.Add("SubCarNmCd");
            if (acceptOdrCar1.ModelGradeSname != acceptOdrCar2.ModelGradeSname) resList.Add("ModelGradeSname");
            if (acceptOdrCar1.ColorCode != acceptOdrCar2.ColorCode) resList.Add("ColorCode");
            if (acceptOdrCar1.ColorName1 != acceptOdrCar2.ColorName1) resList.Add("ColorName1");
            if (acceptOdrCar1.TrimCode != acceptOdrCar2.TrimCode) resList.Add("TrimCode");
            if (acceptOdrCar1.TrimName != acceptOdrCar2.TrimName) resList.Add("TrimName");
            if (acceptOdrCar1.Mileage != acceptOdrCar2.Mileage) resList.Add("Mileage");
            if (acceptOdrCar1.FullModelFixedNoAry != acceptOdrCar2.FullModelFixedNoAry) resList.Add("FullModelFixedNoAry");
            if (acceptOdrCar1.CategoryObjAry != acceptOdrCar2.CategoryObjAry) resList.Add("CategoryObjAry");
            if (acceptOdrCar1.EnterpriseName != acceptOdrCar2.EnterpriseName) resList.Add("EnterpriseName");
            if (acceptOdrCar1.UpdEmployeeName != acceptOdrCar2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (acceptOdrCar1.DataInputSystemName != acceptOdrCar2.DataInputSystemName) resList.Add("DataInputSystemName");
            if (acceptOdrCar1.ColorName != acceptOdrCar2.ColorName) resList.Add("ColorName");
            if (acceptOdrCar1.CarNote != acceptOdrCar2.CarNote) resList.Add("CarNote");
            if (acceptOdrCar1.FreeSrchMdlFxdNoAry != acceptOdrCar2.FreeSrchMdlFxdNoAry) resList.Add("FreeSrchMdlFxdNoAry"); // ADD 2010/04/27
            // --- ADD 2012/05/31 ---------->>>>>
            if (acceptOdrCar1.FirstEntryDateNumTyp != acceptOdrCar2.FirstEntryDateNumTyp) resList.Add("FirstEntryDateNumTyp");
            if (acceptOdrCar1.CarAddInf != acceptOdrCar2.CarAddInf) resList.Add("CarAddInf");
            if (acceptOdrCar1.EquipPrtsObj != acceptOdrCar2.EquipPrtsObj) resList.Add("EquipPrtsObj");
            // --- ADD 2012/05/31 ----------<<<<<

            return resList;
        }
    }
}
