using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   ScmOdDtCar
    /// <summary>
    ///                      SCM�󔭒��f�[�^(�ԗ����)
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM�󔭒��f�[�^(�ԗ����)�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2009/2/20</br>
    /// <br>Genarated Date   :   2011/08/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2011/7/28  ���Ԍ��@�[</br>
    /// <br>                 :   ���ڒǉ�</br>
    /// <br>                 :    No32.����</br>
    /// <br>Update Note      :   2011/7/29  ��{�@�E</br>
    /// <br>                 :   ���ڒǉ�</br>
    /// <br>                 :   �@No33-No42</br>
    /// <br>Update Note      :   2011/8/23  ��{�@�E</br>
    /// <br>                 :   ���ڒǉ�</br>
    /// <br>                 :   43,44</br>
    /// </remarks>
    public class ScmOdDtCar
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�⍇������ƃR�[�h</summary>
        private string _inqOriginalEpCd = "";

        /// <summary>�⍇�������_�R�[�h</summary>
        private string _inqOriginalSecCd = "";

        /// <summary>�⍇���ԍ�</summary>
        private Int64 _inquiryNumber;

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

        /// <summary>����</summary>
        private string _carNo = "";

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

        /// <summary>�O���[�h����</summary>
        private string _gradeName = "";

        /// <summary>�{�f�B�[����</summary>
        private string _bodyName = "";

        /// <summary>�h�A��</summary>
        private Int32 _doorCount;

        /// <summary>�G���W���^������</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _engineModelNm = "";

        /// <summary>�ʏ̔r�C��</summary>
        /// <remarks>1600,2000��</remarks>
        private Int32 _cmnNmEngineDisPlace;

        /// <summary>�����@�^���i�G���W���j</summary>
        /// <remarks>�Ԍ��؋L�ڌ����@�^��</remarks>
        private string _engineModel = "";

        /// <summary>�ϑ��i��</summary>
        /// <remarks>2:2��,3:3�����,6:6��</remarks>
        private Int32 _numberOfGear;

        /// <summary>�ϑ��@����</summary>
        private string _gearNm = "";

        /// <summary>E�敪����</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _eDivNm = "";

        /// <summary>�~�b�V��������</summary>
        private string _transmissionNm = "";

        /// <summary>�V�t�g����</summary>
        private string _shiftNm = "";


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

        /// public propaty name  :  InqOriginalEpCd
        /// <summary>�⍇������ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇������ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalEpCd
        {
            get { return _inqOriginalEpCd; }
            set { _inqOriginalEpCd = value; }
        }

        /// public propaty name  :  InqOriginalSecCd
        /// <summary>�⍇�������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalSecCd
        {
            get { return _inqOriginalSecCd; }
            set { _inqOriginalSecCd = value; }
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
            get { return _inquiryNumber; }
            set { _inquiryNumber = value; }
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

        /// public propaty name  :  ModelName
        /// <summary>�Ԏ햼�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ햼�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ModelName
        {
            get { return _modelName; }
            set { _modelName = value; }
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
            get { return _carInspectCertModel; }
            set { _carInspectCertModel = value; }
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

        /// public propaty name  :  FrameNo
        /// <summary>�ԑ�ԍ��v���p�e�B</summary>
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

        /// public propaty name  :  ChassisNo
        /// <summary>�V���V�[No�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V���V�[No�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChassisNo
        {
            get { return _chassisNo; }
            set { _chassisNo = value; }
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
            get { return _carProperNo; }
            set { _carProperNo = value; }
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
            get { return _produceTypeOfYearNum; }
            set { _produceTypeOfYearNum = value; }
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
            get { return _comment; }
            set { _comment = value; }
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
            get { return _rpColorCode; }
            set { _rpColorCode = value; }
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

        /// public propaty name  :  EquipObj
        /// <summary>�����I�u�W�F�N�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����I�u�W�F�N�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public byte[] EquipObj
        {
            get { return _equipObj; }
            set { _equipObj = value; }
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

        /// public propaty name  :  MakerName
        /// <summary>���[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  GradeName
        /// <summary>�O���[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O���[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GradeName
        {
            get { return _gradeName; }
            set { _gradeName = value; }
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

        /// public propaty name  :  CmnNmEngineDisPlace
        /// <summary>�ʏ̔r�C�ʃv���p�e�B</summary>
        /// <value>1600,2000��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ʏ̔r�C�ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CmnNmEngineDisPlace
        {
            get { return _cmnNmEngineDisPlace; }
            set { _cmnNmEngineDisPlace = value; }
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

        /// public propaty name  :  NumberOfGear
        /// <summary>�ϑ��i���v���p�e�B</summary>
        /// <value>2:2��,3:3�����,6:6��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϑ��i���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NumberOfGear
        {
            get { return _numberOfGear; }
            set { _numberOfGear = value; }
        }

        /// public propaty name  :  GearNm
        /// <summary>�ϑ��@���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϑ��@���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GearNm
        {
            get { return _gearNm; }
            set { _gearNm = value; }
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


        /// <summary>
        /// SCM�󔭒��f�[�^(�ԗ����)�R���X�g���N�^
        /// </summary>
        /// <returns>ScmOdDtCar�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ScmOdDtCar�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ScmOdDtCar()
        {
        }

        /// <summary>
        /// SCM�󔭒��f�[�^(�ԗ����)�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="inqOriginalEpCd">�⍇������ƃR�[�h</param>
        /// <param name="inqOriginalSecCd">�⍇�������_�R�[�h</param>
        /// <param name="inquiryNumber">�⍇���ԍ�</param>
        /// <param name="numberPlate1Code">���^�������ԍ�</param>
        /// <param name="numberPlate1Name">���^�����ǖ���</param>
        /// <param name="numberPlate2">�ԗ��o�^�ԍ��i��ʁj</param>
        /// <param name="numberPlate3">�ԗ��o�^�ԍ��i�J�i�j</param>
        /// <param name="numberPlate4">�ԗ��o�^�ԍ��i�v���[�g�ԍ��j</param>
        /// <param name="modelDesignationNo">�^���w��ԍ�</param>
        /// <param name="categoryNo">�ޕʔԍ�</param>
        /// <param name="makerCode">���[�J�[�R�[�h(1�`899:�񋟕�, 900�`���[�U�[�o�^)</param>
        /// <param name="modelCode">�Ԏ�R�[�h(�Ԗ��R�[�h(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^)</param>
        /// <param name="modelSubCode">�Ԏ�T�u�R�[�h(0�`899:�񋟕�,900�`հ�ް�o�^)</param>
        /// <param name="modelName">�Ԏ햼</param>
        /// <param name="carInspectCertModel">�Ԍ��،^��</param>
        /// <param name="fullModel">�^���i�t���^�j(�t���^��(44���p))</param>
        /// <param name="frameNo">�ԑ�ԍ�</param>
        /// <param name="frameModel">�ԑ�^��</param>
        /// <param name="chassisNo">�V���V�[No</param>
        /// <param name="carProperNo">�ԗ��ŗL�ԍ�(���j�[�N�ȌŒ�ԍ�)</param>
        /// <param name="produceTypeOfYearNum">���Y�N���iNUM�^�C�v�j(YYYYMM)</param>
        /// <param name="comment">�R�����g(�J�^���O�̃R�����g��P�ʁE�J���[���i�[)</param>
        /// <param name="rpColorCode">���y�A�J���[�R�[�h(�J�^���O�̐F�R�[�h�i���y�A�p���V�Ԏ��ƈقȂ�ꍇ�j)</param>
        /// <param name="colorName1">�J���[����1(��ʕ\���p��������)</param>
        /// <param name="trimCode">�g�����R�[�h</param>
        /// <param name="trimName">�g��������</param>
        /// <param name="mileage">�ԗ����s����</param>
        /// <param name="equipObj">�����I�u�W�F�N�g</param>
        /// <param name="carNo">����</param>
        /// <param name="makerName">���[�J�[����</param>
        /// <param name="gradeName">�O���[�h����</param>
        /// <param name="bodyName">�{�f�B�[����</param>
        /// <param name="doorCount">�h�A��</param>
        /// <param name="engineModelNm">�G���W���^������(�^���ɂ��ϓ�)</param>
        /// <param name="cmnNmEngineDisPlace">�ʏ̔r�C��(1600,2000��)</param>
        /// <param name="engineModel">�����@�^���i�G���W���j(�Ԍ��؋L�ڌ����@�^��)</param>
        /// <param name="numberOfGear">�ϑ��i��(2:2��,3:3�����,6:6��)</param>
        /// <param name="gearNm">�ϑ��@����</param>
        /// <param name="eDivNm">E�敪����(�^���ɂ��ϓ�)</param>
        /// <param name="transmissionNm">�~�b�V��������</param>
        /// <param name="shiftNm">�V�t�g����</param>
        /// <returns>ScmOdDtCar�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ScmOdDtCar�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ScmOdDtCar(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, Int64 inquiryNumber, Int32 numberPlate1Code, string numberPlate1Name, string numberPlate2, string numberPlate3, Int32 numberPlate4, Int32 modelDesignationNo, Int32 categoryNo, Int32 makerCode, Int32 modelCode, Int32 modelSubCode, string modelName, string carInspectCertModel, string fullModel, string frameNo, string frameModel, string chassisNo, Int32 carProperNo, Int32 produceTypeOfYearNum, string comment, string rpColorCode, string colorName1, string trimCode, string trimName, Int32 mileage, byte[] equipObj, string carNo, string makerName, string gradeName, string bodyName, Int32 doorCount, string engineModelNm, Int32 cmnNmEngineDisPlace, string engineModel, Int32 numberOfGear, string gearNm, string eDivNm, string transmissionNm, string shiftNm)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._inqOriginalEpCd = inqOriginalEpCd;
            this._inqOriginalSecCd = inqOriginalSecCd;
            this._inquiryNumber = inquiryNumber;
            this._numberPlate1Code = numberPlate1Code;
            this._numberPlate1Name = numberPlate1Name;
            this._numberPlate2 = numberPlate2;
            this._numberPlate3 = numberPlate3;
            this._numberPlate4 = numberPlate4;
            this._modelDesignationNo = modelDesignationNo;
            this._categoryNo = categoryNo;
            this._makerCode = makerCode;
            this._modelCode = modelCode;
            this._modelSubCode = modelSubCode;
            this._modelName = modelName;
            this._carInspectCertModel = carInspectCertModel;
            this._fullModel = fullModel;
            this._frameNo = frameNo;
            this._frameModel = frameModel;
            this._chassisNo = chassisNo;
            this._carProperNo = carProperNo;
            this._produceTypeOfYearNum = produceTypeOfYearNum;
            this._comment = comment;
            this._rpColorCode = rpColorCode;
            this._colorName1 = colorName1;
            this._trimCode = trimCode;
            this._trimName = trimName;
            this._mileage = mileage;
            this._equipObj = equipObj;
            this._carNo = carNo;
            this._makerName = makerName;
            this._gradeName = gradeName;
            this._bodyName = bodyName;
            this._doorCount = doorCount;
            this._engineModelNm = engineModelNm;
            this._cmnNmEngineDisPlace = cmnNmEngineDisPlace;
            this._engineModel = engineModel;
            this._numberOfGear = numberOfGear;
            this._gearNm = gearNm;
            this._eDivNm = eDivNm;
            this._transmissionNm = transmissionNm;
            this._shiftNm = shiftNm;

        }

        /// <summary>
        /// SCM�󔭒��f�[�^(�ԗ����)��������
        /// </summary>
        /// <returns>ScmOdDtCar�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ScmOdDtCar�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ScmOdDtCar Clone()
        {
            return new ScmOdDtCar(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inquiryNumber, this._numberPlate1Code, this._numberPlate1Name, this._numberPlate2, this._numberPlate3, this._numberPlate4, this._modelDesignationNo, this._categoryNo, this._makerCode, this._modelCode, this._modelSubCode, this._modelName, this._carInspectCertModel, this._fullModel, this._frameNo, this._frameModel, this._chassisNo, this._carProperNo, this._produceTypeOfYearNum, this._comment, this._rpColorCode, this._colorName1, this._trimCode, this._trimName, this._mileage, this._equipObj, this._carNo, this._makerName, this._gradeName, this._bodyName, this._doorCount, this._engineModelNm, this._cmnNmEngineDisPlace, this._engineModel, this._numberOfGear, this._gearNm, this._eDivNm, this._transmissionNm, this._shiftNm);
        }

        /// <summary>
        /// SCM�󔭒��f�[�^(�ԗ����)��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�ScmOdDtCar�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ScmOdDtCar�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(ScmOdDtCar target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InqOriginalEpCd == target.InqOriginalEpCd)
                 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
                 && (this.InquiryNumber == target.InquiryNumber)
                 && (this.NumberPlate1Code == target.NumberPlate1Code)
                 && (this.NumberPlate1Name == target.NumberPlate1Name)
                 && (this.NumberPlate2 == target.NumberPlate2)
                 && (this.NumberPlate3 == target.NumberPlate3)
                 && (this.NumberPlate4 == target.NumberPlate4)
                 && (this.ModelDesignationNo == target.ModelDesignationNo)
                 && (this.CategoryNo == target.CategoryNo)
                 && (this.MakerCode == target.MakerCode)
                 && (this.ModelCode == target.ModelCode)
                 && (this.ModelSubCode == target.ModelSubCode)
                 && (this.ModelName == target.ModelName)
                 && (this.CarInspectCertModel == target.CarInspectCertModel)
                 && (this.FullModel == target.FullModel)
                 && (this.FrameNo == target.FrameNo)
                 && (this.FrameModel == target.FrameModel)
                 && (this.ChassisNo == target.ChassisNo)
                 && (this.CarProperNo == target.CarProperNo)
                 && (this.ProduceTypeOfYearNum == target.ProduceTypeOfYearNum)
                 && (this.Comment == target.Comment)
                 && (this.RpColorCode == target.RpColorCode)
                 && (this.ColorName1 == target.ColorName1)
                 && (this.TrimCode == target.TrimCode)
                 && (this.TrimName == target.TrimName)
                 && (this.Mileage == target.Mileage)
                 && (this.EquipObj == target.EquipObj)
                 && (this.CarNo == target.CarNo)
                 && (this.MakerName == target.MakerName)
                 && (this.GradeName == target.GradeName)
                 && (this.BodyName == target.BodyName)
                 && (this.DoorCount == target.DoorCount)
                 && (this.EngineModelNm == target.EngineModelNm)
                 && (this.CmnNmEngineDisPlace == target.CmnNmEngineDisPlace)
                 && (this.EngineModel == target.EngineModel)
                 && (this.NumberOfGear == target.NumberOfGear)
                 && (this.GearNm == target.GearNm)
                 && (this.EDivNm == target.EDivNm)
                 && (this.TransmissionNm == target.TransmissionNm)
                 && (this.ShiftNm == target.ShiftNm));
        }

        /// <summary>
        /// SCM�󔭒��f�[�^(�ԗ����)��r����
        /// </summary>
        /// <param name="scmOdDtCar1">
        ///                    ��r����ScmOdDtCar�N���X�̃C���X�^���X
        /// </param>
        /// <param name="scmOdDtCar2">��r����ScmOdDtCar�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ScmOdDtCar�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(ScmOdDtCar scmOdDtCar1, ScmOdDtCar scmOdDtCar2)
        {
            return ((scmOdDtCar1.CreateDateTime == scmOdDtCar2.CreateDateTime)
                 && (scmOdDtCar1.UpdateDateTime == scmOdDtCar2.UpdateDateTime)
                 && (scmOdDtCar1.LogicalDeleteCode == scmOdDtCar2.LogicalDeleteCode)
                 && (scmOdDtCar1.InqOriginalEpCd == scmOdDtCar2.InqOriginalEpCd)
                 && (scmOdDtCar1.InqOriginalSecCd == scmOdDtCar2.InqOriginalSecCd)
                 && (scmOdDtCar1.InquiryNumber == scmOdDtCar2.InquiryNumber)
                 && (scmOdDtCar1.NumberPlate1Code == scmOdDtCar2.NumberPlate1Code)
                 && (scmOdDtCar1.NumberPlate1Name == scmOdDtCar2.NumberPlate1Name)
                 && (scmOdDtCar1.NumberPlate2 == scmOdDtCar2.NumberPlate2)
                 && (scmOdDtCar1.NumberPlate3 == scmOdDtCar2.NumberPlate3)
                 && (scmOdDtCar1.NumberPlate4 == scmOdDtCar2.NumberPlate4)
                 && (scmOdDtCar1.ModelDesignationNo == scmOdDtCar2.ModelDesignationNo)
                 && (scmOdDtCar1.CategoryNo == scmOdDtCar2.CategoryNo)
                 && (scmOdDtCar1.MakerCode == scmOdDtCar2.MakerCode)
                 && (scmOdDtCar1.ModelCode == scmOdDtCar2.ModelCode)
                 && (scmOdDtCar1.ModelSubCode == scmOdDtCar2.ModelSubCode)
                 && (scmOdDtCar1.ModelName == scmOdDtCar2.ModelName)
                 && (scmOdDtCar1.CarInspectCertModel == scmOdDtCar2.CarInspectCertModel)
                 && (scmOdDtCar1.FullModel == scmOdDtCar2.FullModel)
                 && (scmOdDtCar1.FrameNo == scmOdDtCar2.FrameNo)
                 && (scmOdDtCar1.FrameModel == scmOdDtCar2.FrameModel)
                 && (scmOdDtCar1.ChassisNo == scmOdDtCar2.ChassisNo)
                 && (scmOdDtCar1.CarProperNo == scmOdDtCar2.CarProperNo)
                 && (scmOdDtCar1.ProduceTypeOfYearNum == scmOdDtCar2.ProduceTypeOfYearNum)
                 && (scmOdDtCar1.Comment == scmOdDtCar2.Comment)
                 && (scmOdDtCar1.RpColorCode == scmOdDtCar2.RpColorCode)
                 && (scmOdDtCar1.ColorName1 == scmOdDtCar2.ColorName1)
                 && (scmOdDtCar1.TrimCode == scmOdDtCar2.TrimCode)
                 && (scmOdDtCar1.TrimName == scmOdDtCar2.TrimName)
                 && (scmOdDtCar1.Mileage == scmOdDtCar2.Mileage)
                 && (scmOdDtCar1.EquipObj == scmOdDtCar2.EquipObj)
                 && (scmOdDtCar1.CarNo == scmOdDtCar2.CarNo)
                 && (scmOdDtCar1.MakerName == scmOdDtCar2.MakerName)
                 && (scmOdDtCar1.GradeName == scmOdDtCar2.GradeName)
                 && (scmOdDtCar1.BodyName == scmOdDtCar2.BodyName)
                 && (scmOdDtCar1.DoorCount == scmOdDtCar2.DoorCount)
                 && (scmOdDtCar1.EngineModelNm == scmOdDtCar2.EngineModelNm)
                 && (scmOdDtCar1.CmnNmEngineDisPlace == scmOdDtCar2.CmnNmEngineDisPlace)
                 && (scmOdDtCar1.EngineModel == scmOdDtCar2.EngineModel)
                 && (scmOdDtCar1.NumberOfGear == scmOdDtCar2.NumberOfGear)
                 && (scmOdDtCar1.GearNm == scmOdDtCar2.GearNm)
                 && (scmOdDtCar1.EDivNm == scmOdDtCar2.EDivNm)
                 && (scmOdDtCar1.TransmissionNm == scmOdDtCar2.TransmissionNm)
                 && (scmOdDtCar1.ShiftNm == scmOdDtCar2.ShiftNm));
        }
        /// <summary>
        /// SCM�󔭒��f�[�^(�ԗ����)��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�ScmOdDtCar�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ScmOdDtCar�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(ScmOdDtCar target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.InqOriginalEpCd != target.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
            if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (this.InquiryNumber != target.InquiryNumber) resList.Add("InquiryNumber");
            if (this.NumberPlate1Code != target.NumberPlate1Code) resList.Add("NumberPlate1Code");
            if (this.NumberPlate1Name != target.NumberPlate1Name) resList.Add("NumberPlate1Name");
            if (this.NumberPlate2 != target.NumberPlate2) resList.Add("NumberPlate2");
            if (this.NumberPlate3 != target.NumberPlate3) resList.Add("NumberPlate3");
            if (this.NumberPlate4 != target.NumberPlate4) resList.Add("NumberPlate4");
            if (this.ModelDesignationNo != target.ModelDesignationNo) resList.Add("ModelDesignationNo");
            if (this.CategoryNo != target.CategoryNo) resList.Add("CategoryNo");
            if (this.MakerCode != target.MakerCode) resList.Add("MakerCode");
            if (this.ModelCode != target.ModelCode) resList.Add("ModelCode");
            if (this.ModelSubCode != target.ModelSubCode) resList.Add("ModelSubCode");
            if (this.ModelName != target.ModelName) resList.Add("ModelName");
            if (this.CarInspectCertModel != target.CarInspectCertModel) resList.Add("CarInspectCertModel");
            if (this.FullModel != target.FullModel) resList.Add("FullModel");
            if (this.FrameNo != target.FrameNo) resList.Add("FrameNo");
            if (this.FrameModel != target.FrameModel) resList.Add("FrameModel");
            if (this.ChassisNo != target.ChassisNo) resList.Add("ChassisNo");
            if (this.CarProperNo != target.CarProperNo) resList.Add("CarProperNo");
            if (this.ProduceTypeOfYearNum != target.ProduceTypeOfYearNum) resList.Add("ProduceTypeOfYearNum");
            if (this.Comment != target.Comment) resList.Add("Comment");
            if (this.RpColorCode != target.RpColorCode) resList.Add("RpColorCode");
            if (this.ColorName1 != target.ColorName1) resList.Add("ColorName1");
            if (this.TrimCode != target.TrimCode) resList.Add("TrimCode");
            if (this.TrimName != target.TrimName) resList.Add("TrimName");
            if (this.Mileage != target.Mileage) resList.Add("Mileage");
            if (this.EquipObj != target.EquipObj) resList.Add("EquipObj");
            if (this.CarNo != target.CarNo) resList.Add("CarNo");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.GradeName != target.GradeName) resList.Add("GradeName");
            if (this.BodyName != target.BodyName) resList.Add("BodyName");
            if (this.DoorCount != target.DoorCount) resList.Add("DoorCount");
            if (this.EngineModelNm != target.EngineModelNm) resList.Add("EngineModelNm");
            if (this.CmnNmEngineDisPlace != target.CmnNmEngineDisPlace) resList.Add("CmnNmEngineDisPlace");
            if (this.EngineModel != target.EngineModel) resList.Add("EngineModel");
            if (this.NumberOfGear != target.NumberOfGear) resList.Add("NumberOfGear");
            if (this.GearNm != target.GearNm) resList.Add("GearNm");
            if (this.EDivNm != target.EDivNm) resList.Add("EDivNm");
            if (this.TransmissionNm != target.TransmissionNm) resList.Add("TransmissionNm");
            if (this.ShiftNm != target.ShiftNm) resList.Add("ShiftNm");

            return resList;
        }

        /// <summary>
        /// SCM�󔭒��f�[�^(�ԗ����)��r����
        /// </summary>
        /// <param name="scmOdDtCar1">��r����ScmOdDtCar�N���X�̃C���X�^���X</param>
        /// <param name="scmOdDtCar2">��r����ScmOdDtCar�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ScmOdDtCar�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(ScmOdDtCar scmOdDtCar1, ScmOdDtCar scmOdDtCar2)
        {
            ArrayList resList = new ArrayList();
            if (scmOdDtCar1.CreateDateTime != scmOdDtCar2.CreateDateTime) resList.Add("CreateDateTime");
            if (scmOdDtCar1.UpdateDateTime != scmOdDtCar2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (scmOdDtCar1.LogicalDeleteCode != scmOdDtCar2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (scmOdDtCar1.InqOriginalEpCd != scmOdDtCar2.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
            if (scmOdDtCar1.InqOriginalSecCd != scmOdDtCar2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (scmOdDtCar1.InquiryNumber != scmOdDtCar2.InquiryNumber) resList.Add("InquiryNumber");
            if (scmOdDtCar1.NumberPlate1Code != scmOdDtCar2.NumberPlate1Code) resList.Add("NumberPlate1Code");
            if (scmOdDtCar1.NumberPlate1Name != scmOdDtCar2.NumberPlate1Name) resList.Add("NumberPlate1Name");
            if (scmOdDtCar1.NumberPlate2 != scmOdDtCar2.NumberPlate2) resList.Add("NumberPlate2");
            if (scmOdDtCar1.NumberPlate3 != scmOdDtCar2.NumberPlate3) resList.Add("NumberPlate3");
            if (scmOdDtCar1.NumberPlate4 != scmOdDtCar2.NumberPlate4) resList.Add("NumberPlate4");
            if (scmOdDtCar1.ModelDesignationNo != scmOdDtCar2.ModelDesignationNo) resList.Add("ModelDesignationNo");
            if (scmOdDtCar1.CategoryNo != scmOdDtCar2.CategoryNo) resList.Add("CategoryNo");
            if (scmOdDtCar1.MakerCode != scmOdDtCar2.MakerCode) resList.Add("MakerCode");
            if (scmOdDtCar1.ModelCode != scmOdDtCar2.ModelCode) resList.Add("ModelCode");
            if (scmOdDtCar1.ModelSubCode != scmOdDtCar2.ModelSubCode) resList.Add("ModelSubCode");
            if (scmOdDtCar1.ModelName != scmOdDtCar2.ModelName) resList.Add("ModelName");
            if (scmOdDtCar1.CarInspectCertModel != scmOdDtCar2.CarInspectCertModel) resList.Add("CarInspectCertModel");
            if (scmOdDtCar1.FullModel != scmOdDtCar2.FullModel) resList.Add("FullModel");
            if (scmOdDtCar1.FrameNo != scmOdDtCar2.FrameNo) resList.Add("FrameNo");
            if (scmOdDtCar1.FrameModel != scmOdDtCar2.FrameModel) resList.Add("FrameModel");
            if (scmOdDtCar1.ChassisNo != scmOdDtCar2.ChassisNo) resList.Add("ChassisNo");
            if (scmOdDtCar1.CarProperNo != scmOdDtCar2.CarProperNo) resList.Add("CarProperNo");
            if (scmOdDtCar1.ProduceTypeOfYearNum != scmOdDtCar2.ProduceTypeOfYearNum) resList.Add("ProduceTypeOfYearNum");
            if (scmOdDtCar1.Comment != scmOdDtCar2.Comment) resList.Add("Comment");
            if (scmOdDtCar1.RpColorCode != scmOdDtCar2.RpColorCode) resList.Add("RpColorCode");
            if (scmOdDtCar1.ColorName1 != scmOdDtCar2.ColorName1) resList.Add("ColorName1");
            if (scmOdDtCar1.TrimCode != scmOdDtCar2.TrimCode) resList.Add("TrimCode");
            if (scmOdDtCar1.TrimName != scmOdDtCar2.TrimName) resList.Add("TrimName");
            if (scmOdDtCar1.Mileage != scmOdDtCar2.Mileage) resList.Add("Mileage");
            if (scmOdDtCar1.EquipObj != scmOdDtCar2.EquipObj) resList.Add("EquipObj");
            if (scmOdDtCar1.CarNo != scmOdDtCar2.CarNo) resList.Add("CarNo");
            if (scmOdDtCar1.MakerName != scmOdDtCar2.MakerName) resList.Add("MakerName");
            if (scmOdDtCar1.GradeName != scmOdDtCar2.GradeName) resList.Add("GradeName");
            if (scmOdDtCar1.BodyName != scmOdDtCar2.BodyName) resList.Add("BodyName");
            if (scmOdDtCar1.DoorCount != scmOdDtCar2.DoorCount) resList.Add("DoorCount");
            if (scmOdDtCar1.EngineModelNm != scmOdDtCar2.EngineModelNm) resList.Add("EngineModelNm");
            if (scmOdDtCar1.CmnNmEngineDisPlace != scmOdDtCar2.CmnNmEngineDisPlace) resList.Add("CmnNmEngineDisPlace");
            if (scmOdDtCar1.EngineModel != scmOdDtCar2.EngineModel) resList.Add("EngineModel");
            if (scmOdDtCar1.NumberOfGear != scmOdDtCar2.NumberOfGear) resList.Add("NumberOfGear");
            if (scmOdDtCar1.GearNm != scmOdDtCar2.GearNm) resList.Add("GearNm");
            if (scmOdDtCar1.EDivNm != scmOdDtCar2.EDivNm) resList.Add("EDivNm");
            if (scmOdDtCar1.TransmissionNm != scmOdDtCar2.TransmissionNm) resList.Add("TransmissionNm");
            if (scmOdDtCar1.ShiftNm != scmOdDtCar2.ShiftNm) resList.Add("ShiftNm");

            return resList;
        }
    }
}
