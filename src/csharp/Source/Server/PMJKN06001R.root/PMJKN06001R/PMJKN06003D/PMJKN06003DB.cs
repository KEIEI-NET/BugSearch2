using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   FreeSearchModelSRetWork
    /// <summary>
    ///                      ���R�����^�����o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���R�����^�����o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2010/04/19</br>
    /// <br>Genarated Date   :   2010/04/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FreeSearchModelSRetWork
    {
        /// <summary>���[�J�[�R�[�h</summary>
        /// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
        private Int32 _makerCode;

        /// <summary>���[�J�[�S�p����</summary>
        /// <remarks>�������́i�J�i�������݂őS�p�Ǘ��j</remarks>
        private string _makerFullName = "";

        /// <summary>���[�J�[���p����</summary>
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
        private Int32 _stProduceTypeOfYear;

        /// <summary>�I�����Y�N��</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _edProduceTypeOfYear;

        /// <summary>�h�A��</summary>
        private Int32 _doorCount;

        /// <summary>�{�f�B�[���R�[�h</summary>
        private Int32 _bodyNameCode;

        /// <summary>�{�f�B�[����</summary>
        private string _bodyName = "";

        /// <summary>�ԗ��ŗL�ԍ�</summary>
        /// <remarks>���j�[�N�ȌŒ�ԍ�</remarks>
        private Int32 _carProperNo;

        /// <summary>�t���^���Œ�ԍ�</summary>
        private Int32 _fullModelFixedNo;

        /// <summary>�r�K�X�L��</summary>
        private string _exhaustGasSign = "";

        /// <summary>�V���[�Y�^��</summary>
        private string _seriesModel = "";

        /// <summary>�^���i�ޕʋL���j</summary>
        private string _categorySignModel = "";

        /// <summary>�^���i�t���^�j</summary>
        /// <remarks>�t���^��(44���p)</remarks>
        private string _fullModel = "";

        /// <summary>�ԑ�^��</summary>
        private string _frameModel = "";

        /// <summary>���Y�ԑ�ԍ��J�n</summary>
        private Int32 _stProduceFrameNo;

        /// <summary>���Y�ԑ�ԍ��I��</summary>
        private Int32 _edProduceFrameNo;

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

        /// <summary>�쓮��������</summary>        
        private string _wheelDriveMethodNm = "";

        /// <summary>�V�t�g����</summary>
        private string _shiftNm = "";

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

        /// <summary>���R�����^���Œ�ԍ�</summary>
        /// <remarks>���R�����V���A����</remarks>
        private string _freeSrchMdlFxdNo;


        /// public property name  :  MakerCode
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

        /// public property name  :  MakerFullName
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


        /// public property name  :  ModelCode
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

        /// public property name  :  ModelSubCode
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

        /// public property name  :  ModelFullName
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

        /// public property name  :  SystematicCode
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

        /// public property name  :  SystematicName
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

        /// public property name  :  ProduceTypeOfYearCd
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

        /// public property name  :  ProduceTypeOfYearNm
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

        /// public property name  :  StProduceTypeOfYear
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

        /// public property name  :  EdProduceTypeOfYear
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

        /// public property name  :  DoorCount
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

        /// public property name  :  BodyNameCode
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

        /// public property name  :  BodyName
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

        /// public property name  :  CarProperNo
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

        /// public property name  :  FullModelFixedNo
        /// <summary>�t���^���Œ�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t���^���Œ�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FullModelFixedNo
        {
            get { return _fullModelFixedNo; }
            set { _fullModelFixedNo = value; }
        }

        /// public property name  :  ExhaustGasSign
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

        /// public property name  :  SeriesModel
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

        /// public property name  :  CategorySignModel
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

        /// public property name  :  FullModel
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

        /// public property name  :  FrameModel
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

        /// public property name  :  StProduceFrameNo
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

        /// public property name  :  EdProduceFrameNo
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

        /// public property name  :  ModelGradeNm
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

        /// public property name  :  EngineModelNm
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

        /// public property name  :  EngineDisplaceNm
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

        /// public property name  :  EDivNm
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

        /// public property name  :  TransmissionNm
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

        /// public property name  :  WheelDriveMethodNm
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

        /// public property name  :  ShiftNm
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

        /// public property name  :  AddiCarSpec1
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

        /// public property name  :  AddiCarSpec2
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

        /// public property name  :  AddiCarSpec3
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

        /// public property name  :  AddiCarSpec4
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

        /// public property name  :  AddiCarSpec5
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

        /// public property name  :  AddiCarSpec6
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

        /// public property name  :  AddiCarSpecTitle1
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

        /// public property name  :  AddiCarSpecTitle2
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

        /// public property name  :  AddiCarSpecTitle3
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

        /// public property name  :  AddiCarSpecTitle4
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

        /// public property name  :  AddiCarSpecTitle5
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

        /// public property name  :  AddiCarSpecTitle6
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

        /// public property name  :  RelevanceModel
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

        /// public property name  :  SubCarNmCd
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

        /// public property name  :  ModelGradeSname
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

        /// public property name  :  BlockIllustrationCd
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

        /// public property name  :  ThreeDIllustNo
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

        /// public property name  :  PartsDataOfferFlag
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

        /// public property name  :  FreeSrchMdlFxdNo
        /// <summary>���R�����^���Œ�ԍ��v���p�e�B</summary>
        /// <value>���R�����V���A����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���R�����^���Œ�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FreeSrchMdlFxdNo
        {
            get { return _freeSrchMdlFxdNo; }
            set { _freeSrchMdlFxdNo = value; }
        }


        /// <summary>
        /// ���q�^�����o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>FreeSearchModelSCndtnWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FreeSearchModelSCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public FreeSearchModelSRetWork()
        {
        }

        /// <summary>
        /// �P�J�^���O�i������
        /// </summary>
        /// <param name="FreeSearchModelSCndtnWork">��r�Ώ�</param>
        /// <returns></returns>
        public bool IsCatalogEqual( FreeSearchModelSRetWork FreeSearchModelSCndtnWork )
        {
            if ( (_makerCode == FreeSearchModelSCndtnWork.MakerCode)
                && (_modelCode == FreeSearchModelSCndtnWork.ModelCode)
                && (_modelSubCode == FreeSearchModelSCndtnWork.ModelSubCode)
                && (_systematicCode == FreeSearchModelSCndtnWork.SystematicCode)
                && (_produceTypeOfYearCd == FreeSearchModelSCndtnWork.ProduceTypeOfYearCd)
                && (_doorCount == FreeSearchModelSCndtnWork.DoorCount)
                && (_bodyNameCode == FreeSearchModelSCndtnWork.BodyNameCode) )
                return true;
            return false;
        }

        /// <summary>
        /// �P�ԑ�^���i������
        /// </summary>
        /// <param name="FreeSearchModelSCndtnWork">��r�Ώ�</param>
        /// <returns></returns>
        public bool IsFrameModelEqual( FreeSearchModelSRetWork FreeSearchModelSCndtnWork )
        {
            if ( (_makerCode == FreeSearchModelSCndtnWork.MakerCode)
                    && (_frameModel == FreeSearchModelSCndtnWork.FrameModel) )
            {
                return true;
            }
            return false;
        }
    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>FreeSearchModelSCndtnWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   FreeSearchModelSCndtnWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class FreeSearchModelSRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FreeSearchModelSCndtnWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  FreeSearchModelSRetWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if ( writer == null )
                throw new ArgumentNullException();

            if ( graph != null && !(graph is FreeSearchModelSRetWork || graph is ArrayList || graph is FreeSearchModelSRetWork[]) )
                throw new ArgumentException( string.Format( "graph��{0}�̃C���X�^���X�ł���܂���", typeof( FreeSearchModelSRetWork ).FullName ) );

            if ( graph != null && graph is FreeSearchModelSRetWork )
            {
                Type t = graph.GetType();
                if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
                    throw new ArgumentException( string.Format( "graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelSRetWork" );

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if ( graph is ArrayList )
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if ( graph is FreeSearchModelSRetWork[] )
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((FreeSearchModelSRetWork[])graph).Length;
            }
            else if ( graph is FreeSearchModelSRetWork )
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //���[�J�[�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MakerCode
            //���[�J�[�S�p����
            serInfo.MemberInfo.Add( typeof( string ) ); //MakerFullName
            //���[�J�[���p����
            serInfo.MemberInfo.Add( typeof( string ) ); //MakerHalfName
            //�Ԏ�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelCode
            //�Ԏ�T�u�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelSubCode
            //�Ԏ�S�p����
            serInfo.MemberInfo.Add( typeof( string ) ); //ModelFullName
            //�Ԏ피�p����
            serInfo.MemberInfo.Add( typeof( string ) ); //ModelHalfName
            //�n���R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SystematicCode
            //�n������
            serInfo.MemberInfo.Add( typeof( string ) ); //SystematicName
            //���Y�N���R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ProduceTypeOfYearCd
            //���Y�N������
            serInfo.MemberInfo.Add( typeof( string ) ); //ProduceTypeOfYearNm
            //�J�n���Y�N��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //StProduceTypeOfYear
            //�I�����Y�N��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //EdProduceTypeOfYear
            //�h�A��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DoorCount
            //�{�f�B�[���R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //BodyNameCode
            //�{�f�B�[����
            serInfo.MemberInfo.Add( typeof( string ) ); //BodyName
            //�ԗ��ŗL�ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CarProperNo
            //�t���^���Œ�ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //FullModelFixedNo
            //�r�K�X�L��
            serInfo.MemberInfo.Add( typeof( string ) ); //ExhaustGasSign
            //�V���[�Y�^��
            serInfo.MemberInfo.Add( typeof( string ) ); //SeriesModel
            //�^���i�ޕʋL���j
            serInfo.MemberInfo.Add( typeof( string ) ); //CategorySignModel
            //�^���i�t���^�j
            serInfo.MemberInfo.Add( typeof( string ) ); //FullModel
            //�ԑ�^��
            serInfo.MemberInfo.Add( typeof( string ) ); //FrameModel
            //���Y�ԑ�ԍ��J�n
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //StProduceFrameNo
            //���Y�ԑ�ԍ��I��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //EdProduceFrameNo
            //�^���O���[�h����
            serInfo.MemberInfo.Add( typeof( string ) ); //ModelGradeNm
            //�G���W���^������
            serInfo.MemberInfo.Add( typeof( string ) ); //EngineModelNm
            //�r�C�ʖ���
            serInfo.MemberInfo.Add( typeof( string ) ); //EngineDisplaceNm
            //E�敪����
            serInfo.MemberInfo.Add( typeof( string ) ); //EDivNm
            //�~�b�V��������
            serInfo.MemberInfo.Add( typeof( string ) ); //TransmissionNm
            //�쓮��������
            serInfo.MemberInfo.Add( typeof( string ) ); //WheelDriveMethodNm
            //�V�t�g����
            serInfo.MemberInfo.Add( typeof( string ) ); //ShiftNm
            //�ǉ�����1
            serInfo.MemberInfo.Add( typeof( string ) ); //AddiCarSpec1
            //�ǉ�����2
            serInfo.MemberInfo.Add( typeof( string ) ); //AddiCarSpec2
            //�ǉ�����3
            serInfo.MemberInfo.Add( typeof( string ) ); //AddiCarSpec3
            //�ǉ�����4
            serInfo.MemberInfo.Add( typeof( string ) ); //AddiCarSpec4
            //�ǉ�����5
            serInfo.MemberInfo.Add( typeof( string ) ); //AddiCarSpec5
            //�ǉ�����6
            serInfo.MemberInfo.Add( typeof( string ) ); //AddiCarSpec6
            //�ǉ������^�C�g��1
            serInfo.MemberInfo.Add( typeof( string ) ); //AddiCarSpecTitle1
            //�ǉ������^�C�g��2
            serInfo.MemberInfo.Add( typeof( string ) ); //AddiCarSpecTitle2
            //�ǉ������^�C�g��3
            serInfo.MemberInfo.Add( typeof( string ) ); //AddiCarSpecTitle3
            //�ǉ������^�C�g��4
            serInfo.MemberInfo.Add( typeof( string ) ); //AddiCarSpecTitle4
            //�ǉ������^�C�g��5
            serInfo.MemberInfo.Add( typeof( string ) ); //AddiCarSpecTitle5
            //�ǉ������^�C�g��6
            serInfo.MemberInfo.Add( typeof( string ) ); //AddiCarSpecTitle6
            //�֘A�^��
            serInfo.MemberInfo.Add( typeof( string ) ); //RelevanceModel
            //�T�u�Ԗ��R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SubCarNmCd
            //�^���O���[�h����
            serInfo.MemberInfo.Add( typeof( string ) ); //ModelGradeSname
            //�u���b�N�C���X�g�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //BlockIllustrationCd
            //3D�C���X�gNo
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ThreeDIllustNo
            //���i�f�[�^�񋟃t���O
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //PartsDataOfferFlag
            //���R�����^���Œ�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //FreeSrchMdlFxdNo

            serInfo.Serialize( writer, serInfo );
            if ( graph is FreeSearchModelSRetWork )
            {
                FreeSearchModelSRetWork temp = (FreeSearchModelSRetWork)graph;

                SetFreeSearchModelSRetWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if ( graph is FreeSearchModelSRetWork[] )
                {
                    lst = new ArrayList();
                    lst.AddRange( (FreeSearchModelSRetWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach ( FreeSearchModelSRetWork temp in lst )
                {
                    SetFreeSearchModelSRetWork( writer, temp );
                }

            }


        }


        /// <summary>
        /// FreeSearchModelSCndtnWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 51;

        /// <summary>
        ///  FreeSearchModelSCndtnWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FreeSearchModelSCndtnWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetFreeSearchModelSRetWork( System.IO.BinaryWriter writer, FreeSearchModelSRetWork temp )
        {
            //���[�J�[�R�[�h
            writer.Write( temp.MakerCode );
            //���[�J�[�S�p����
            writer.Write( temp.MakerFullName );
            //���[�J�[���p����
            writer.Write( temp.MakerHalfName );
            //�Ԏ�R�[�h
            writer.Write( temp.ModelCode );
            //�Ԏ�T�u�R�[�h
            writer.Write( temp.ModelSubCode );
            //�Ԏ�S�p����
            writer.Write( temp.ModelFullName );
            //�Ԏ피�p����
            writer.Write( temp.ModelHalfName );
            //�n���R�[�h
            writer.Write( temp.SystematicCode );
            //�n������
            writer.Write( temp.SystematicName );
            //���Y�N���R�[�h
            writer.Write( temp.ProduceTypeOfYearCd );
            //���Y�N������
            writer.Write( temp.ProduceTypeOfYearNm );
            //�J�n���Y�N��
            writer.Write( temp.StProduceTypeOfYear );
            //�I�����Y�N��
            writer.Write( temp.EdProduceTypeOfYear );
            //�h�A��
            writer.Write( temp.DoorCount );
            //�{�f�B�[���R�[�h
            writer.Write( temp.BodyNameCode );
            //�{�f�B�[����
            writer.Write( temp.BodyName );
            //�ԗ��ŗL�ԍ�
            writer.Write( temp.CarProperNo );
            //�t���^���Œ�ԍ�
            writer.Write( temp.FullModelFixedNo );
            //�r�K�X�L��
            writer.Write( temp.ExhaustGasSign );
            //�V���[�Y�^��
            writer.Write( temp.SeriesModel );
            //�^���i�ޕʋL���j
            writer.Write( temp.CategorySignModel );
            //�^���i�t���^�j
            writer.Write( temp.FullModel );
            //�ԑ�^��
            writer.Write( temp.FrameModel );
            //���Y�ԑ�ԍ��J�n
            writer.Write( temp.StProduceFrameNo );
            //���Y�ԑ�ԍ��I��
            writer.Write( temp.EdProduceFrameNo );
            //�^���O���[�h����
            writer.Write( temp.ModelGradeNm );
            //�G���W���^������
            writer.Write( temp.EngineModelNm );
            //�r�C�ʖ���
            writer.Write( temp.EngineDisplaceNm );
            //E�敪����
            writer.Write( temp.EDivNm );
            //�~�b�V��������
            writer.Write( temp.TransmissionNm );
            //�쓮��������
            writer.Write( temp.WheelDriveMethodNm );
            //�V�t�g����
            writer.Write( temp.ShiftNm );
            //�ǉ�����1
            writer.Write( temp.AddiCarSpec1 );
            //�ǉ�����2
            writer.Write( temp.AddiCarSpec2 );
            //�ǉ�����3
            writer.Write( temp.AddiCarSpec3 );
            //�ǉ�����4
            writer.Write( temp.AddiCarSpec4 );
            //�ǉ�����5
            writer.Write( temp.AddiCarSpec5 );
            //�ǉ�����6
            writer.Write( temp.AddiCarSpec6 );
            //�ǉ������^�C�g��1
            writer.Write( temp.AddiCarSpecTitle1 );
            //�ǉ������^�C�g��2
            writer.Write( temp.AddiCarSpecTitle2 );
            //�ǉ������^�C�g��3
            writer.Write( temp.AddiCarSpecTitle3 );
            //�ǉ������^�C�g��4
            writer.Write( temp.AddiCarSpecTitle4 );
            //�ǉ������^�C�g��5
            writer.Write( temp.AddiCarSpecTitle5 );
            //�ǉ������^�C�g��6
            writer.Write( temp.AddiCarSpecTitle6 );
            //�֘A�^��
            writer.Write( temp.RelevanceModel );
            //�T�u�Ԗ��R�[�h
            writer.Write( temp.SubCarNmCd );
            //�^���O���[�h����
            writer.Write( temp.ModelGradeSname );
            //�u���b�N�C���X�g�R�[�h
            writer.Write( temp.BlockIllustrationCd );
            //3D�C���X�gNo
            writer.Write( temp.ThreeDIllustNo );
            //���i�f�[�^�񋟃t���O
            writer.Write( temp.PartsDataOfferFlag );
            //���R�����^���Œ�ԍ�
            writer.Write( temp.FreeSrchMdlFxdNo );
        }

        /// <summary>
        ///  FreeSearchModelSCndtnWork�C���X�^���X�擾
        /// </summary>
        /// <returns>FreeSearchModelSCndtnWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FreeSearchModelSCndtnWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private FreeSearchModelSRetWork GetFreeSearchModelSRetWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            FreeSearchModelSRetWork temp = new FreeSearchModelSRetWork();

            //���[�J�[�R�[�h
            temp.MakerCode = reader.ReadInt32();
            //���[�J�[�S�p����
            temp.MakerFullName = reader.ReadString();
            //���[�J�[���p����
            temp.MakerHalfName = reader.ReadString();
            //�Ԏ�R�[�h
            temp.ModelCode = reader.ReadInt32();
            //�Ԏ�T�u�R�[�h
            temp.ModelSubCode = reader.ReadInt32();
            //�Ԏ�S�p����
            temp.ModelFullName = reader.ReadString();
            //�Ԏ피�p����
            temp.ModelHalfName = reader.ReadString();
            //�n���R�[�h
            temp.SystematicCode = reader.ReadInt32();
            //�n������
            temp.SystematicName = reader.ReadString();
            //���Y�N���R�[�h
            temp.ProduceTypeOfYearCd = reader.ReadInt32();
            //���Y�N������
            temp.ProduceTypeOfYearNm = reader.ReadString();
            //�J�n���Y�N��
            temp.StProduceTypeOfYear = reader.ReadInt32();
            //�I�����Y�N��
            temp.EdProduceTypeOfYear = reader.ReadInt32();
            //�h�A��
            temp.DoorCount = reader.ReadInt32();
            //�{�f�B�[���R�[�h
            temp.BodyNameCode = reader.ReadInt32();
            //�{�f�B�[����
            temp.BodyName = reader.ReadString();
            //�ԗ��ŗL�ԍ�
            temp.CarProperNo = reader.ReadInt32();
            //�t���^���Œ�ԍ�
            temp.FullModelFixedNo = reader.ReadInt32();
            //�r�K�X�L��
            temp.ExhaustGasSign = reader.ReadString();
            //�V���[�Y�^��
            temp.SeriesModel = reader.ReadString();
            //�^���i�ޕʋL���j
            temp.CategorySignModel = reader.ReadString();
            //�^���i�t���^�j
            temp.FullModel = reader.ReadString();
            //�ԑ�^��
            temp.FrameModel = reader.ReadString();
            //���Y�ԑ�ԍ��J�n
            temp.StProduceFrameNo = reader.ReadInt32();
            //���Y�ԑ�ԍ��I��
            temp.EdProduceFrameNo = reader.ReadInt32();
            //�^���O���[�h����
            temp.ModelGradeNm = reader.ReadString();
            //�G���W���^������
            temp.EngineModelNm = reader.ReadString();
            //�r�C�ʖ���
            temp.EngineDisplaceNm = reader.ReadString();
            //E�敪����
            temp.EDivNm = reader.ReadString();
            //�~�b�V��������
            temp.TransmissionNm = reader.ReadString();
            //�쓮��������
            temp.WheelDriveMethodNm = reader.ReadString();
            //�V�t�g����
            temp.ShiftNm = reader.ReadString();
            //�ǉ�����1
            temp.AddiCarSpec1 = reader.ReadString();
            //�ǉ�����2
            temp.AddiCarSpec2 = reader.ReadString();
            //�ǉ�����3
            temp.AddiCarSpec3 = reader.ReadString();
            //�ǉ�����4
            temp.AddiCarSpec4 = reader.ReadString();
            //�ǉ�����5
            temp.AddiCarSpec5 = reader.ReadString();
            //�ǉ�����6
            temp.AddiCarSpec6 = reader.ReadString();
            //�ǉ������^�C�g��1
            temp.AddiCarSpecTitle1 = reader.ReadString();
            //�ǉ������^�C�g��2
            temp.AddiCarSpecTitle2 = reader.ReadString();
            //�ǉ������^�C�g��3
            temp.AddiCarSpecTitle3 = reader.ReadString();
            //�ǉ������^�C�g��4
            temp.AddiCarSpecTitle4 = reader.ReadString();
            //�ǉ������^�C�g��5
            temp.AddiCarSpecTitle5 = reader.ReadString();
            //�ǉ������^�C�g��6
            temp.AddiCarSpecTitle6 = reader.ReadString();
            //�֘A�^��
            temp.RelevanceModel = reader.ReadString();
            //�T�u�Ԗ��R�[�h
            temp.SubCarNmCd = reader.ReadInt32();
            //�^���O���[�h����
            temp.ModelGradeSname = reader.ReadString();
            //�u���b�N�C���X�g�R�[�h
            temp.BlockIllustrationCd = reader.ReadInt32();
            //3D�C���X�gNo
            temp.ThreeDIllustNo = reader.ReadInt32();
            //���i�f�[�^�񋟃t���O
            temp.PartsDataOfferFlag = reader.ReadInt32();
            //���R�����^���Œ�ԍ�
            temp.FreeSrchMdlFxdNo = reader.ReadString();

            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for ( int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k )
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if ( oMemberType is Type )
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
                    if ( t.Equals( typeof( int ) ) )
                    {
                        optCount = Convert.ToInt32( oData );
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if ( oMemberType is string )
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
                    object userData = formatter.Deserialize( reader );  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>FreeSearchModelSCndtnWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FreeSearchModelSCndtnWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
            {
                FreeSearchModelSRetWork temp = GetFreeSearchModelSRetWork( reader, serInfo );
                lst.Add( temp );
            }
            switch ( serInfo.RetTypeInfo )
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (FreeSearchModelSRetWork[])lst.ToArray( typeof( FreeSearchModelSRetWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
