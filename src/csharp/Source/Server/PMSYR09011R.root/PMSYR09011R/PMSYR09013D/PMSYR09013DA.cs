//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �ԗ��Ǘ��}�X�^�f�[�^�p�����[�^
//                  :   PMSYR09013D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112�@�v�ۓc
// Date             :   2008.06.02
// Note             :   �t���^���Œ�ԍ��z��ɂ��ẮA�c�[���Ő���
//�@�@�@�@�@�@�@�@�@:�@ ���ꂽ�R�[�h���C������K�v������_�ɒ��ӂ���
//----------------------------------------------------------------------
// Update Note      :   2009/09/11 �����
//                      ���q�Ǘ��}�X�^ LDNS�J���Ή�
// Update Note      :   2010/04/27 gaoyh
//                      ���R�����^���Œ�ԍ��z���ǉ�
// Update Note      :   2013/03/22 FSI���� ����
// �Ǘ��ԍ�         :   10900269-00 
//                      SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ�
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    // MANTIS 11632 �Ή�
    // FirstEntryDate DataTime �� Int32 
    // �����������͎蓮�ŕύX����K�v����


    /// ���ԗ��Ǘ��}�X�^��r������ǋL���Ă���_�ɒ��ӂ��鎖
    /// public class name:   CarManagementWork
    /// <summary>
    ///                      �ԗ��Ǘ����[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �ԗ��Ǘ����[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/09/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   8/12  �v�ۓc</br>
    /// <br>                 :   �����I�u�W�F�N�g�z�� ��ǉ�</br>
    /// <br>                 :   �����@�^���i�G���W���j ��ǉ�</br>
    /// <br>Update Note      :   2009/09/11 �����</br>
    /// <br>                 :   ���q�Ǘ��}�X�^ LDNS�J���Ή�</br>
    /// <br>                 :   </br>
    /// <br>Update Note      :   2010/04/27 gaoyh</br>
    /// <br>                 :   ���R�����^���Œ�ԍ��z���ǉ�</br>
    /// <br>                 :   </br>
    /// <br>Update Note      :   2013/03/22 FSI���� ����</br>
    /// <br>                 :   SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ�</br>
    /// <br>                 :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CarManagementWork : IFileHeader
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

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

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

        /// <summary>�o�^�N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _entryDate;

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

        // --- ADD 2009/09/08 ---------->>>>>
        /// <summary>���q���l</summary>
        private string _carNote = "";
        // --- ADD 2009/09/08 ----------<<<<<

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

        /// <summary>���R�����^���Œ�ԍ��z��</summary>
        /// <remarks>���R�����V���A�����̔z��N���X���i�[�i�Č����s�v�ɂȂ�j</remarks>
        private Byte[] _freeSrchMdlFxdNoAry = new Byte[0];

        /// <summary>�ԗ��֘A�t��GUID</summary>
        /// <remarks>�ԗ��Ǘ����Ɠ`�[���ׂ�R�t����GUID�AUI���Őݒ�</remarks>
        private Guid _carRelationGuid;

        // ADD 2013/03/22  -------------------->>>>>
        /// <summary>���Y/�O�ԋ敪</summary>
        private Int32 _domesticForeignCode;

        /// <summary>�n���h���ʒu���R�[�h</summary>
        private Int32 _handleInfoCode;
        // ADD 2013/03/22  --------------------<<<<<

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
        public Int32 FirstEntryDate
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

        /// public propaty name  :  FreeSrchMdlFxdNoAry
        /// <summary>���R�����^���Œ�ԍ��z��v���p�e�B</summary>
        /// <value>���R�����V���A�����̔z��N���X���i�[�i�Č����s�v�ɂȂ�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���R�����^���Œ�ԍ��z��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Byte[] FreeSrchMdlFxdNoAry
        {
            get { return _freeSrchMdlFxdNoAry; }
            set { _freeSrchMdlFxdNoAry = value; }
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

        // --- ADD 2009/09/11 ---------->>>>>
        /// <summary>���q�ǉ����P</summary>
        private string _carAddInfo1 = "";

        /// <summary>���q�ǉ����Q</summary>
        private string _carAddInfo2 = "";

        /// <summary>���Ӑ�J�n</summary>
        private int _customerCodeSt;

        /// <summary>���Ӑ�I��</summary>
        private int _customerCodeEd;

        /// <summary>���q�Ǘ��R�[�h�����敪</summary>
        private int _carMngCodeSearchDiv;

        /// <summary>���Ӑ於��</summary>
        private string _customerName = "";

        /// <summary>�^��</summary>
        private string _kindModel = "";

        /// <summary>���q���l�����敪</summary>
        private int _carNoteSearchDiv;

        /// <summary>�^�������敪</summary>
        private int _kindModelSearchDiv;

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

        /// public propaty name  :  CustomerCodeSt
        /// <summary>���Ӑ�J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int CustomerCodeSt
        {
            get { return _customerCodeSt; }
            set { _customerCodeSt = value; }
        }

        /// public propaty name  :  CustomerCodeEd
        /// <summary>���Ӑ�I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int CustomerCodeEd
        {
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
        }

        /// public propaty name  :  CarMngNoSearchDiv
        /// <summary>���q�Ǘ��R�[�h�����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���q�Ǘ��R�[�h�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int CarMngCodeSearchDiv
        {
            get { return _carMngCodeSearchDiv; }
            set { _carMngCodeSearchDiv = value; }
        }

        /// public propaty name  :  CarNoteSearchDiv
        /// <summary>���q���l�����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���q���l�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int CarNoteSearchDiv 
        {
            get { return _carNoteSearchDiv; }
            set { _carNoteSearchDiv = value; }
        }

        /// public propaty name  :  KindModelSearchDiv
        /// <summary>�^�������敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int KindModelSearchDiv 
        {
            get { return _kindModelSearchDiv; }
            set { _kindModelSearchDiv = value; }
        }

        /// public propaty name  :  KindModel
        /// <summary>�^���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string KindModel 
        {
            get { return _kindModel; }
            set { _kindModel = value; }
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
        // --- ADD 2009/09/11 ----------<<<<<

        // ADD 2013/03/22  -------------------->>>>>
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
        // ADD 2013/03/22  --------------------<<<<<
        

        /// <summary>
        /// �ԗ��Ǘ����[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CarManagementWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CarManagementWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CarManagementWork()
        {
        }


        /// <summary>
        /// �ԗ��Ǘ��}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CarManagement�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CarManagement�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2009/09/11 �����</br>
        /// <br>                 :   ���q�Ǘ��}�X�^ LDNS�J���Ή�</br>
        /// <br>Update Note      :   2013/03/22 FSI���� ����</br>
        /// <br>                 :   SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ�</br>
        /// </remarks>
        public ArrayList Compare(CarManagementWork target)
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
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CarMngNo != target.CarMngNo) resList.Add("CarMngNo");
            if (this.CarMngCode != target.CarMngCode) resList.Add("CarMngCode");
            if (this.NumberPlate1Code != target.NumberPlate1Code) resList.Add("NumberPlate1Code");
            if (this.NumberPlate1Name != target.NumberPlate1Name) resList.Add("NumberPlate1Name");
            if (this.NumberPlate2 != target.NumberPlate2) resList.Add("NumberPlate2");
            if (this.NumberPlate3 != target.NumberPlate3) resList.Add("NumberPlate3");
            if (this.NumberPlate4 != target.NumberPlate4) resList.Add("NumberPlate4");
            if (this.EntryDate != target.EntryDate) resList.Add("EntryDate");
            if (this.FirstEntryDate != target.FirstEntryDate) resList.Add("FirstEntryDate");
            if (this.MakerCode != target.MakerCode) resList.Add("MakerCode");
            if (this.MakerFullName != target.MakerFullName) resList.Add("MakerFullName");
            if (this.MakerHalfName != target.MakerHalfName) resList.Add("MakerHalfName");
            if (this.ModelCode != target.ModelCode) resList.Add("ModelCode");
            if (this.ModelSubCode != target.ModelSubCode) resList.Add("ModelSubCode");
            if (this.ModelFullName != target.ModelFullName) resList.Add("ModelFullName");
            if (this.ModelHalfName != target.ModelHalfName) resList.Add("ModelHalfName");
            if (this.SystematicCode != target.SystematicCode) resList.Add("SystematicCode");
            if (this.SystematicName != target.SystematicName) resList.Add("SystematicName");
            if (this.ProduceTypeOfYearCd != target.ProduceTypeOfYearCd) resList.Add("ProduceTypeOfYearCd");
            if (this.ProduceTypeOfYearNm != target.ProduceTypeOfYearNm) resList.Add("ProduceTypeOfYearNm");
            if (this.StProduceTypeOfYear != target.StProduceTypeOfYear) resList.Add("StProduceTypeOfYear");
            if (this.EdProduceTypeOfYear != target.EdProduceTypeOfYear) resList.Add("EdProduceTypeOfYear");
            if (this.DoorCount != target.DoorCount) resList.Add("DoorCount");
            if (this.BodyNameCode != target.BodyNameCode) resList.Add("BodyNameCode");
            if (this.BodyName != target.BodyName) resList.Add("BodyName");
            if (this.ExhaustGasSign != target.ExhaustGasSign) resList.Add("ExhaustGasSign");
            if (this.SeriesModel != target.SeriesModel) resList.Add("SeriesModel");
            if (this.CategorySignModel != target.CategorySignModel) resList.Add("CategorySignModel");
            if (this.FullModel != target.FullModel) resList.Add("FullModel");
            if (this.ModelDesignationNo != target.ModelDesignationNo) resList.Add("ModelDesignationNo");
            if (this.CategoryNo != target.CategoryNo) resList.Add("CategoryNo");
            if (this.FrameModel != target.FrameModel) resList.Add("FrameModel");
            if (this.FrameNo != target.FrameNo) resList.Add("FrameNo");
            if (this.SearchFrameNo != target.SearchFrameNo) resList.Add("SearchFrameNo");
            if (this.StProduceFrameNo != target.StProduceFrameNo) resList.Add("StProduceFrameNo");
            if (this.EdProduceFrameNo != target.EdProduceFrameNo) resList.Add("EdProduceFrameNo");
            if (this.EngineModel != target.EngineModel) resList.Add("EngineModel");
            if (this.ModelGradeNm != target.ModelGradeNm) resList.Add("ModelGradeNm");
            if (this.EngineModelNm != target.EngineModelNm) resList.Add("EngineModelNm");
            if (this.EngineDisplaceNm != target.EngineDisplaceNm) resList.Add("EngineDisplaceNm");
            if (this.EDivNm != target.EDivNm) resList.Add("EDivNm");
            if (this.TransmissionNm != target.TransmissionNm) resList.Add("TransmissionNm");
            if (this.ShiftNm != target.ShiftNm) resList.Add("ShiftNm");
            if (this.WheelDriveMethodNm != target.WheelDriveMethodNm) resList.Add("WheelDriveMethodNm");
            if (this.AddiCarSpec1 != target.AddiCarSpec1) resList.Add("AddiCarSpec1");
            if (this.AddiCarSpec2 != target.AddiCarSpec2) resList.Add("AddiCarSpec2");
            if (this.AddiCarSpec3 != target.AddiCarSpec3) resList.Add("AddiCarSpec3");
            if (this.AddiCarSpec4 != target.AddiCarSpec4) resList.Add("AddiCarSpec4");
            if (this.AddiCarSpec5 != target.AddiCarSpec5) resList.Add("AddiCarSpec5");
            if (this.AddiCarSpec6 != target.AddiCarSpec6) resList.Add("AddiCarSpec6");
            if (this.AddiCarSpecTitle1 != target.AddiCarSpecTitle1) resList.Add("AddiCarSpecTitle1");
            if (this.AddiCarSpecTitle2 != target.AddiCarSpecTitle2) resList.Add("AddiCarSpecTitle2");
            if (this.AddiCarSpecTitle3 != target.AddiCarSpecTitle3) resList.Add("AddiCarSpecTitle3");
            if (this.AddiCarSpecTitle4 != target.AddiCarSpecTitle4) resList.Add("AddiCarSpecTitle4");
            if (this.AddiCarSpecTitle5 != target.AddiCarSpecTitle5) resList.Add("AddiCarSpecTitle5");
            if (this.AddiCarSpecTitle6 != target.AddiCarSpecTitle6) resList.Add("AddiCarSpecTitle6");
            if (this.RelevanceModel != target.RelevanceModel) resList.Add("RelevanceModel");
            if (this.SubCarNmCd != target.SubCarNmCd) resList.Add("SubCarNmCd");
            if (this.ModelGradeSname != target.ModelGradeSname) resList.Add("ModelGradeSname");
            if (this.BlockIllustrationCd != target.BlockIllustrationCd) resList.Add("BlockIllustrationCd");
            if (this.ThreeDIllustNo != target.ThreeDIllustNo) resList.Add("ThreeDIllustNo");
            if (this.PartsDataOfferFlag != target.PartsDataOfferFlag) resList.Add("PartsDataOfferFlag");
            if (this.InspectMaturityDate != target.InspectMaturityDate) resList.Add("InspectMaturityDate");
            if (this.LTimeCiMatDate != target.LTimeCiMatDate) resList.Add("LTimeCiMatDate");
            if (this.CarInspectYear != target.CarInspectYear) resList.Add("CarInspectYear");
            if (this.Mileage != target.Mileage) resList.Add("Mileage");
            if (this.CarNote != target.CarNote) resList.Add("CarNote");  // ADD 2009/09/08
            if (this.CarNo != target.CarNo) resList.Add("CarNo");
            if (this.ColorCode != target.ColorCode) resList.Add("ColorCode");
            if (this.ColorName1 != target.ColorName1) resList.Add("ColorName1");
            if (this.TrimCode != target.TrimCode) resList.Add("TrimCode");
            if (this.TrimName != target.TrimName) resList.Add("TrimName");
            if (this.CarAddInfo1 != target.CarAddInfo1) resList.Add("CarAddInfo1");  // ADD 2009/09/11
            if (this.CarAddInfo2 != target.CarAddInfo2) resList.Add("CarAddInfo2");  // ADD 2009/09/11
            if (this.CustomerName != target.CustomerName) resList.Add("CustomerName");  // ADD 2009/09/11
            // ADD 2013/03/22 -------------------->>>>>
            if (this.DomesticForeignCode != target.DomesticForeignCode) resList.Add("DomesticForeignCode");
            if (this.HandleInfoCode != target.HandleInfoCode) resList.Add("HandleInfoCode");
            // ADD 2013/03/22 --------------------<<<<<
            if (this.FullModelFixedNoAry.Length != target.FullModelFixedNoAry.Length)
            {
                resList.Add("FullModelFixedNoAry");
            }
            else
            {
                for (int i = 0; this.FullModelFixedNoAry.Length > i; i++)
                {
                    if (this.FullModelFixedNoAry[i] != target.FullModelFixedNoAry[i])
                    {
                        resList.Add("FullModelFixedNoAry");
                        break;
                    }
                }
            }

            if (this.CategoryObjAry.Length != target.CategoryObjAry.Length)
            {
                resList.Add("CategoryObjAry");
            }
            else
            {
                for (int i = 0; this.CategoryObjAry.Length > i; i++)
                {
                    if (this.CategoryObjAry[i] != target.CategoryObjAry[i])
                    {
                        resList.Add("CategoryObjAry");
                        break;
                    }
                }
            }
            // ----- ADD 2010/04/27 ------------>>>
            if (this.FreeSrchMdlFxdNoAry.Length != target.FreeSrchMdlFxdNoAry.Length)
            {
                resList.Add("FreeSrchMdlFxdNoAry");
            }
            else
            {
                for (int i = 0; this.FreeSrchMdlFxdNoAry.Length > i; i++ )
                {
                    if (this.FreeSrchMdlFxdNoAry[i] != target.FreeSrchMdlFxdNoAry[i])
                    {
                        resList.Add("FreeSrchMdlFxdNoAry");
                        break;
                    }
                }
            }
            // ----- ADD 2010/04/27 ------------<<<

            if (this.CarRelationGuid != target.CarRelationGuid) resList.Add("CarRelationGuid");

            return resList;
        }
    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>CarManagementWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   CarManagementWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// <br>Update Note      :   2009/09/11 �����</br>
    /// <br>                 :   ���q�Ǘ��}�X�^ LDNS�J���Ή�</br>
    /// <br>Update Note      :   2013/03/22 FSI���� ����</br>
    /// <br>                 :   SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ�</br>
    /// </remarks>
    public class CarManagementWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CarManagementWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CarManagementWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CarManagementWork || graph is ArrayList || graph is CarManagementWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(CarManagementWork).FullName));

            if (graph != null && graph is CarManagementWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CarManagementWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CarManagementWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CarManagementWork[])graph).Length;
            }
            else if (graph is CarManagementWork)
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
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //�ԗ��Ǘ��ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //CarMngNo
            //���q�Ǘ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //CarMngCode
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
            //�o�^�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //EntryDate
            //���N�x
            serInfo.MemberInfo.Add(typeof(Int32)); //FirstEntryDate
            //���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
            //���[�J�[�S�p����
            serInfo.MemberInfo.Add(typeof(string)); //MakerFullName
            //���[�J�[���p����
            serInfo.MemberInfo.Add(typeof(string)); //MakerHalfName
            //�Ԏ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelCode
            //�Ԏ�T�u�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelSubCode
            //�Ԏ�S�p����
            serInfo.MemberInfo.Add(typeof(string)); //ModelFullName
            //�Ԏ피�p����
            serInfo.MemberInfo.Add(typeof(string)); //ModelHalfName
            //�n���R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SystematicCode
            //�n������
            serInfo.MemberInfo.Add(typeof(string)); //SystematicName
            //���Y�N���R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ProduceTypeOfYearCd
            //���Y�N������
            serInfo.MemberInfo.Add(typeof(string)); //ProduceTypeOfYearNm
            //�J�n���Y�N��
            serInfo.MemberInfo.Add(typeof(Int32)); //StProduceTypeOfYear
            //�I�����Y�N��
            serInfo.MemberInfo.Add(typeof(Int32)); //EdProduceTypeOfYear
            //�h�A��
            serInfo.MemberInfo.Add(typeof(Int32)); //DoorCount
            //�{�f�B�[���R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BodyNameCode
            //�{�f�B�[����
            serInfo.MemberInfo.Add(typeof(string)); //BodyName
            //�r�K�X�L��
            serInfo.MemberInfo.Add(typeof(string)); //ExhaustGasSign
            //�V���[�Y�^��
            serInfo.MemberInfo.Add(typeof(string)); //SeriesModel
            //�^���i�ޕʋL���j
            serInfo.MemberInfo.Add(typeof(string)); //CategorySignModel
            //�^���i�t���^�j
            serInfo.MemberInfo.Add(typeof(string)); //FullModel
            //�^���w��ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelDesignationNo
            //�ޕʔԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //CategoryNo
            //�ԑ�^��
            serInfo.MemberInfo.Add(typeof(string)); //FrameModel
            //�ԑ�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //FrameNo
            //�ԑ�ԍ��i�����p�j
            serInfo.MemberInfo.Add(typeof(Int32)); //SearchFrameNo
            //���Y�ԑ�ԍ��J�n
            serInfo.MemberInfo.Add(typeof(Int32)); //StProduceFrameNo
            //���Y�ԑ�ԍ��I��
            serInfo.MemberInfo.Add(typeof(Int32)); //EdProduceFrameNo
            //�����@�^���i�G���W���j
            serInfo.MemberInfo.Add(typeof(string)); //EngineModel
            //�^���O���[�h����
            serInfo.MemberInfo.Add(typeof(string)); //ModelGradeNm
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
            //�ǉ�����1
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpec1
            //�ǉ�����2
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpec2
            //�ǉ�����3
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpec3
            //�ǉ�����4
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpec4
            //�ǉ�����5
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpec5
            //�ǉ�����6
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpec6
            //�ǉ������^�C�g��1
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpecTitle1
            //�ǉ������^�C�g��2
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpecTitle2
            //�ǉ������^�C�g��3
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpecTitle3
            //�ǉ������^�C�g��4
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpecTitle4
            //�ǉ������^�C�g��5
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpecTitle5
            //�ǉ������^�C�g��6
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpecTitle6
            //�֘A�^��
            serInfo.MemberInfo.Add(typeof(string)); //RelevanceModel
            //�T�u�Ԗ��R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SubCarNmCd
            //�^���O���[�h����
            serInfo.MemberInfo.Add(typeof(string)); //ModelGradeSname
            //�u���b�N�C���X�g�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BlockIllustrationCd
            //3D�C���X�gNo
            serInfo.MemberInfo.Add(typeof(Int32)); //ThreeDIllustNo
            //���i�f�[�^�񋟃t���O
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsDataOfferFlag
            //�Ԍ�������
            serInfo.MemberInfo.Add(typeof(Int32)); //InspectMaturityDate
            //�O��Ԍ�������
            serInfo.MemberInfo.Add(typeof(Int32)); //LTimeCiMatDate
            //�Ԍ�����
            serInfo.MemberInfo.Add(typeof(Int32)); //CarInspectYear
            //�ԗ����s����
            serInfo.MemberInfo.Add(typeof(Int32)); //Mileage
            // --- ADD 2009/09/08 ---------->>>>>
            //���q���l
            serInfo.MemberInfo.Add(typeof(string)); //CarNote
            // --- ADD 2009/09/08 ----------<<<<<
            //����
            serInfo.MemberInfo.Add(typeof(string)); //CarNo
            //�J���[�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //ColorCode
            //�J���[����1
            serInfo.MemberInfo.Add(typeof(string)); //ColorName1
            //�g�����R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //TrimCode
            //�g��������
            serInfo.MemberInfo.Add(typeof(string)); //TrimName
            //�t���^���Œ�ԍ��z��
            serInfo.MemberInfo.Add(typeof(Int32[])); //FullModelFixedNoAry
            //�����I�u�W�F�N�g�z��
            serInfo.MemberInfo.Add(typeof(Byte[])); //CategoryObjAry
            //�ԗ��֘A�t��GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //CarRelationGuid
            // --- ADD 2009/09/11 ---------->>>>>
            //���q�ǉ����P
            serInfo.MemberInfo.Add(typeof(string)); //CarAddInfo1
            //���q�ǉ����Q
            serInfo.MemberInfo.Add(typeof(string)); //CarAddInfo2
            //���Ӑ於��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
            // --- ADD 2009/09/11 ----------<<<<<
            // --- ADD 2010/04/27 ---------->>>>>
            serInfo.MemberInfo.Add(typeof(Byte[])); // FreeSrchMdlFxdNoAryRF
            // --- ADD 2010/04/27 ----------<<<<<
            // ADD 2013/03/22 -------------------->>>>>
            // ���Y/�O�ԋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); // DomesticForeignCode
            // �n���h���ʒu���
            serInfo.MemberInfo.Add(typeof(Int32)); // HandleInfoCode
            // ADD 2013/03/22 --------------------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is CarManagementWork)
            {
                CarManagementWork temp = (CarManagementWork)graph;

                SetCarManagementWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CarManagementWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CarManagementWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CarManagementWork temp in lst)
                {
                    SetCarManagementWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CarManagementWork�����o��(public�v���p�e�B��)
        /// </summary>
        //private const int currentMemberCount = 84; // DEL 2009/09/11
        //private const int currentMemberCount = 87;  // ADD 2009/09/11 // DEL 2010/04/27
        //private const int currentMemberCount = 88;  // ADD 2010/04/27 // DEL 2013/03/22
        private const int currentMemberCount = 90;  // ADD 2013/03/22

        /// <summary>
        ///  CarManagementWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CarManagementWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2009/09/11 �����</br>
        /// <br>                 :   ���q�Ǘ��}�X�^ LDNS�J���Ή�</br>
        /// <br>Update Note      :   2013/03/22 FSI���� ����</br>
        /// <br>                 :   SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ�</br>
        /// </remarks>
        private void SetCarManagementWork(System.IO.BinaryWriter writer, CarManagementWork temp)
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
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //�ԗ��Ǘ��ԍ�
            writer.Write(temp.CarMngNo);
            //���q�Ǘ��R�[�h
            writer.Write(temp.CarMngCode);
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
            //�o�^�N����
            writer.Write((Int64)temp.EntryDate.Ticks);
            //���N�x
            writer.Write(temp.FirstEntryDate);
            //���[�J�[�R�[�h
            writer.Write(temp.MakerCode);
            //���[�J�[�S�p����
            writer.Write(temp.MakerFullName);
            //���[�J�[���p����
            writer.Write(temp.MakerHalfName);
            //�Ԏ�R�[�h
            writer.Write(temp.ModelCode);
            //�Ԏ�T�u�R�[�h
            writer.Write(temp.ModelSubCode);
            //�Ԏ�S�p����
            writer.Write(temp.ModelFullName);
            //�Ԏ피�p����
            writer.Write(temp.ModelHalfName);
            //�n���R�[�h
            writer.Write(temp.SystematicCode);
            //�n������
            writer.Write(temp.SystematicName);
            //���Y�N���R�[�h
            writer.Write(temp.ProduceTypeOfYearCd);
            //���Y�N������
            writer.Write(temp.ProduceTypeOfYearNm);
            //�J�n���Y�N��
            writer.Write((Int64)temp.StProduceTypeOfYear.Ticks);
            //�I�����Y�N��
            writer.Write((Int64)temp.EdProduceTypeOfYear.Ticks);
            //�h�A��
            writer.Write(temp.DoorCount);
            //�{�f�B�[���R�[�h
            writer.Write(temp.BodyNameCode);
            //�{�f�B�[����
            writer.Write(temp.BodyName);
            //�r�K�X�L��
            writer.Write(temp.ExhaustGasSign);
            //�V���[�Y�^��
            writer.Write(temp.SeriesModel);
            //�^���i�ޕʋL���j
            writer.Write(temp.CategorySignModel);
            //�^���i�t���^�j
            writer.Write(temp.FullModel);
            //�^���w��ԍ�
            writer.Write(temp.ModelDesignationNo);
            //�ޕʔԍ�
            writer.Write(temp.CategoryNo);
            //�ԑ�^��
            writer.Write(temp.FrameModel);
            //�ԑ�ԍ�
            writer.Write(temp.FrameNo);
            //�ԑ�ԍ��i�����p�j
            writer.Write(temp.SearchFrameNo);
            //���Y�ԑ�ԍ��J�n
            writer.Write(temp.StProduceFrameNo);
            //���Y�ԑ�ԍ��I��
            writer.Write(temp.EdProduceFrameNo);
            //�����@�^���i�G���W���j
            writer.Write(temp.EngineModel);
            //�^���O���[�h����
            writer.Write(temp.ModelGradeNm);
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
            //�ǉ�����1
            writer.Write(temp.AddiCarSpec1);
            //�ǉ�����2
            writer.Write(temp.AddiCarSpec2);
            //�ǉ�����3
            writer.Write(temp.AddiCarSpec3);
            //�ǉ�����4
            writer.Write(temp.AddiCarSpec4);
            //�ǉ�����5
            writer.Write(temp.AddiCarSpec5);
            //�ǉ�����6
            writer.Write(temp.AddiCarSpec6);
            //�ǉ������^�C�g��1
            writer.Write(temp.AddiCarSpecTitle1);
            //�ǉ������^�C�g��2
            writer.Write(temp.AddiCarSpecTitle2);
            //�ǉ������^�C�g��3
            writer.Write(temp.AddiCarSpecTitle3);
            //�ǉ������^�C�g��4
            writer.Write(temp.AddiCarSpecTitle4);
            //�ǉ������^�C�g��5
            writer.Write(temp.AddiCarSpecTitle5);
            //�ǉ������^�C�g��6
            writer.Write(temp.AddiCarSpecTitle6);
            //�֘A�^��
            writer.Write(temp.RelevanceModel);
            //�T�u�Ԗ��R�[�h
            writer.Write(temp.SubCarNmCd);
            //�^���O���[�h����
            writer.Write(temp.ModelGradeSname);
            //�u���b�N�C���X�g�R�[�h
            writer.Write(temp.BlockIllustrationCd);
            //3D�C���X�gNo
            writer.Write(temp.ThreeDIllustNo);
            //���i�f�[�^�񋟃t���O
            writer.Write(temp.PartsDataOfferFlag);
            //�Ԍ�������
            writer.Write((Int64)temp.InspectMaturityDate.Ticks);
            //�O��Ԍ�������
            writer.Write((Int64)temp.LTimeCiMatDate.Ticks);
            //�Ԍ�����
            writer.Write(temp.CarInspectYear);
            //�ԗ����s����
            writer.Write(temp.Mileage);
            // --- ADD 2009/09/08 ---------->>>>>
            //���q���l
            writer.Write(temp.CarNote);
            // --- ADD 2009/09/08 ----------<<<<<
            //����
            writer.Write(temp.CarNo);
            //�J���[�R�[�h
            writer.Write(temp.ColorCode);
            //�J���[����1
            writer.Write(temp.ColorName1);
            //�g�����R�[�h
            writer.Write(temp.TrimCode);
            //�g��������
            writer.Write(temp.TrimName);
            //�t���^���Œ�ԍ��z��
            int length = temp.FullModelFixedNoAry.Length;
            writer.Write(length);
            for (int cnt = 0; cnt < length; cnt++)
                writer.Write(temp.FullModelFixedNoAry[cnt]);
            //�����I�u�W�F�N�g�z��
            writer.Write(temp.CategoryObjAry.Length);
            writer.Write(temp.CategoryObjAry);
            //�ԗ��֘A�t��GUID
            byte[] carRelationGuidArray = temp.CarRelationGuid.ToByteArray();
            writer.Write(carRelationGuidArray.Length);
            writer.Write(temp.CarRelationGuid.ToByteArray());
            // --- ADD 2009/09/11 ---------->>>>>
            writer.Write(temp.CarAddInfo1);
            writer.Write(temp.CarAddInfo2);
            writer.Write(temp.CustomerName);
            // --- ADD 2009/09/11 ----------<<<<<
            // --- ADD 2010/04/27 ---------->>>>>
            //���R�����^���Œ�ԍ��z��
            writer.Write(temp.FreeSrchMdlFxdNoAry.Length);
            writer.Write(temp.FreeSrchMdlFxdNoAry);
            // --- ADD 2010/04/27 ----------<<<<<
            // ADD 2013/03/22 -------------------->>>>>
            // ���Y/�O�ԋ敪
            writer.Write(temp.DomesticForeignCode);
            // �n���h���ʒu���
            writer.Write(temp.HandleInfoCode);
            // ADD 2013/03/22 --------------------<<<<<
        }

        /// <summary>
        ///  CarManagementWork�C���X�^���X�擾
        /// </summary>
        /// <returns>CarManagementWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CarManagementWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2009/09/11 �����</br>
        /// <br>                 :   ���q�Ǘ��}�X�^ LDNS�J���Ή�</br>
        /// <br>Update Note      :   2013/03/22 FSI���� ����</br>
        /// <br>                 :   SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ�</br>
        /// </remarks>
        private CarManagementWork GetCarManagementWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            CarManagementWork temp = new CarManagementWork();

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
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //�ԗ��Ǘ��ԍ�
            temp.CarMngNo = reader.ReadInt32();
            //���q�Ǘ��R�[�h
            temp.CarMngCode = reader.ReadString();
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
            //�o�^�N����
            temp.EntryDate = new DateTime(reader.ReadInt64());
            //���N�x
            temp.FirstEntryDate = reader.ReadInt32();
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
            temp.StProduceTypeOfYear = new DateTime(reader.ReadInt64());
            //�I�����Y�N��
            temp.EdProduceTypeOfYear = new DateTime(reader.ReadInt64());
            //�h�A��
            temp.DoorCount = reader.ReadInt32();
            //�{�f�B�[���R�[�h
            temp.BodyNameCode = reader.ReadInt32();
            //�{�f�B�[����
            temp.BodyName = reader.ReadString();
            //�r�K�X�L��
            temp.ExhaustGasSign = reader.ReadString();
            //�V���[�Y�^��
            temp.SeriesModel = reader.ReadString();
            //�^���i�ޕʋL���j
            temp.CategorySignModel = reader.ReadString();
            //�^���i�t���^�j
            temp.FullModel = reader.ReadString();
            //�^���w��ԍ�
            temp.ModelDesignationNo = reader.ReadInt32();
            //�ޕʔԍ�
            temp.CategoryNo = reader.ReadInt32();
            //�ԑ�^��
            temp.FrameModel = reader.ReadString();
            //�ԑ�ԍ�
            temp.FrameNo = reader.ReadString();
            //�ԑ�ԍ��i�����p�j
            temp.SearchFrameNo = reader.ReadInt32();
            //���Y�ԑ�ԍ��J�n
            temp.StProduceFrameNo = reader.ReadInt32();
            //���Y�ԑ�ԍ��I��
            temp.EdProduceFrameNo = reader.ReadInt32();
            //�����@�^���i�G���W���j
            temp.EngineModel = reader.ReadString();
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
            //�V�t�g����
            temp.ShiftNm = reader.ReadString();
            //�쓮��������
            temp.WheelDriveMethodNm = reader.ReadString();
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
            //�Ԍ�������
            temp.InspectMaturityDate = new DateTime(reader.ReadInt64());
            //�O��Ԍ�������
            temp.LTimeCiMatDate = new DateTime(reader.ReadInt64());
            //�Ԍ�����
            temp.CarInspectYear = reader.ReadInt32();
            //�ԗ����s����
            temp.Mileage = reader.ReadInt32();
            // --- ADD 2009/09/08 ---------->>>>>
            //���q���l
            temp.CarNote = reader.ReadString();
            // --- ADD 2009/09/08 ----------<<<<<
            //����
            temp.CarNo = reader.ReadString();
            //�J���[�R�[�h
            temp.ColorCode = reader.ReadString();
            //�J���[����1
            temp.ColorName1 = reader.ReadString();
            //�g�����R�[�h
            temp.TrimCode = reader.ReadString();
            //�g��������
            temp.TrimName = reader.ReadString();
            //�t���^���Œ�ԍ��z��
            int length = reader.ReadInt32();
            temp.FullModelFixedNoAry = new int[length];
            for (int cnt = 0; cnt < length; cnt++)
                temp.FullModelFixedNoAry[cnt] = reader.ReadInt32();

            //�����I�u�W�F�N�g�z��
            length = reader.ReadInt32();
            temp.CategoryObjAry = reader.ReadBytes(length);

            //�ԗ��֘A�t��GUID
            int lenOfCarRelationGuidArray = reader.ReadInt32();
            byte[] carRelationGuidArray = reader.ReadBytes(lenOfCarRelationGuidArray);
            temp.CarRelationGuid = new Guid(carRelationGuidArray);

            // --- ADD 2009/09/11 ---------->>>>>
            //���q�ǉ����P
            temp.CarAddInfo1 = reader.ReadString();
            //���q�ǉ����Q
            temp.CarAddInfo2 = reader.ReadString();
            //���Ӑ於��
            temp.CustomerName = reader.ReadString();
            // --- ADD 2009/09/11 ----------<<<<<
            // --- ADD 2010/04/27 ---------->>>>>
            //���R�����^���Œ�ԍ��z��
            length = reader.ReadInt32();
            temp.FreeSrchMdlFxdNoAry = reader.ReadBytes(length);
            // --- ADD 2010/04/27 ----------<<<<<
            // ADD 2013/03/22 -------------------->>>>>
            // ���Y/�O�ԋ敪
            temp.DomesticForeignCode = reader.ReadInt32();
            // �n���h���ʒu���
            temp.HandleInfoCode = reader.ReadInt32();
            // ADD 2013/03/22 --------------------<<<<<
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
        /// <returns>CarManagementWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CarManagementWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CarManagementWork temp = GetCarManagementWork(reader, serInfo);
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
                    retValue = (CarManagementWork[])lst.ToArray(typeof(CarManagementWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

    /// <summary>
    /// �ԗ��Ǘ��f�[�^���L�[���ɕ��ёւ���
    /// </summary>
    public class CarManagementComparer : IComparer
    {
        /// <summary>
        /// 2 �̃I�u�W�F�N�g�̖��׊֘A�t��GUID���r���A�����������菬�������A���������A�傫�����������l��Ԃ��܂��B
        /// </summary>
        /// <param name="x">��r�Ώۂ̑� 1 �I�u�W�F�N�g</param>
        /// <param name="y">��r�Ώۂ̑� 2 �I�u�W�F�N�g</param>
        /// <returns>0 ��菬�����l: x �� y ��菬�����B 0: x �� y �͓������B 0 ���傫���l: x �� y ���傫���l�ł��B</returns>
        public int Compare(object x, object y)
        {
            Guid xGuid = Guid.Empty;
            Guid yGuid = Guid.Empty;

            if (x is CarManagementWork)
            {
                xGuid = (x as CarManagementWork).CarRelationGuid;
            }
            else if (x is Guid)
            {
                xGuid = (Guid)x;
            }

            if (y is CarManagementWork)
            {
                yGuid = (y as CarManagementWork).CarRelationGuid;
            }
            else if (y is Guid)
            {
                yGuid = (Guid)y;
            }

            return xGuid.CompareTo(yGuid);
        }
    }
}
