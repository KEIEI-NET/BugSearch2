//****************************************************************************//
// �V�X�e��         : �����񓚏���
// �v���O��������   : �����񓚏����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/05/29  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : LDNS wangqx
// �� �� ��  2010/08/08  �C�����e : ���ԁA���[�J�[���́A�O���[�h���́A
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�{�f�B�[���́A�h�A���A�G���W���^�����́A
//                                  �ʏ̔r�C�ʁA�����@�^���i�G���W���j�A�ϑ��i���A
//                                  �ϑ��@���́AE�敪���́A�~�b�V�������́A
//                                  �V�t�g���̂̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2012/05/31  �C�����e : ��Q��10277 SCM�󒍃f�[�^(�ԗ����)�������̐ݒ���@�̕ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/04/19  �C�����e : ��Q��1521 SCM�󒍃f�[�^(�ԗ����)�̎ԗ��Ǘ��R�[�h�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/05/09  �C�����e : ��Q��10384 SCM�󒍃f�[�^(�ԗ����)�ɓ��ɗ\�����ǉ�
//----------------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.UIData
{
    using RecordType    = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtCarWork;
    using RecordTypeWeb = Broadleaf.Application.UIData.ScmOdDtCar;

    /// <summary>
    /// ���[�U�[DB SCM�󒍃f�[�^(�ԗ����)�̃��b�p�[�N���X�i���񑩁j
    /// </summary>
    public abstract partial class UserSCMOrderCarWrapper : ISCMOrderCarRecord
    {
        #region <Override>

        /// <summary>
        /// �����������f���܂��B
        /// </summary>
        /// <param name="obj">�I�u�W�F�N�g</param>
        /// <returns><c>true</c> :�������ł��B<br/><c>false</c>:����������܂���B</returns>
        public override bool Equals(object obj)
        {
            return RealRecord.Equals(obj);
        }

        /// <summary>
        /// �n�b�V���R�[�h���擾���܂��B
        /// </summary>
        /// <returns>�n�b�V���R�[�h</returns>
        public override int GetHashCode()
        {
            return RealRecord.GetHashCode();
        }

        /// <summary>
        /// ������ɕϊ����܂��B
        /// </summary>
        /// <returns>������</returns>
        public override string ToString()
        {
            return RealRecord.ToString();
        }

        #endregion // </Override>

        #region <Adaptee>

        /// <summary>�{���̃��R�[�h</summary>
        private readonly RecordType _realRecord;
        /// <summary>�{���̃��R�[�h���擾���܂��B</summary>
        public RecordType RealRecord { get { return _realRecord; } }

        #endregion // </Adaptee>

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        protected UserSCMOrderCarWrapper() : this(new RecordType()) { }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="realRecord">�{���̃��R�[�h</param>
        protected UserSCMOrderCarWrapper(RecordType realRecord)
        {
            _realRecord = realRecord;
        }

        #endregion // </Constructor>

        #region <Automatic Code>

        #region <01.�쐬����>

        /// <summary>�쐬�������擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        public DateTime CreateDateTime
        {
            get { return RealRecord.CreateDateTime; }
            set { RealRecord.CreateDateTime = value; }
        }

        #endregion </01.�쐬����>

        #region <02.�X�V����>

        /// <summary>�X�V�������擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        public DateTime UpdateDateTime
        {
            get { return RealRecord.UpdateDateTime; }
            set { RealRecord.UpdateDateTime = value; }
        }

        #endregion </02.�X�V����>

        #region <03.��ƃR�[�h>

        /// <summary>��ƃR�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        public string EnterpriseCode
        {
            get { return RealRecord.EnterpriseCode; }
            set { RealRecord.EnterpriseCode = value; }
        }

        #endregion </03.��ƃR�[�h>

        #region <04.GUID>

        /// <summary>GUID���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        public Guid FileHeaderGuid
        {
            get { return RealRecord.FileHeaderGuid; }
            set { RealRecord.FileHeaderGuid = value; }
        }

        #endregion </04.GUID>

        #region <05.�X�V�]�ƈ��R�[�h>

        /// <summary>�X�V�]�ƈ��R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        public string UpdEmployeeCode
        {
            get { return RealRecord.UpdEmployeeCode; }
            set { RealRecord.UpdEmployeeCode = value; }
        }

        #endregion </05.�X�V�]�ƈ��R�[�h>

        #region <06.�X�V�A�Z���u��ID1>

        /// <summary>�X�V�A�Z���u��ID1���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        public string UpdAssemblyId1
        {
            get { return RealRecord.UpdAssemblyId1; }
            set { RealRecord.UpdAssemblyId1 = value; }
        }

        #endregion </06.�X�V�A�Z���u��ID1>

        #region <07.�X�V�A�Z���u��ID2>

        /// <summary>�X�V�A�Z���u��ID2���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        public string UpdAssemblyId2
        {
            get { return RealRecord.UpdAssemblyId2; }
            set { RealRecord.UpdAssemblyId2 = value; }
        }

        #endregion </07.�X�V�A�Z���u��ID2>

        #region <08.�_���폜�敪>

        /// <summary>�_���폜�敪���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        public int LogicalDeleteCode
        {
            get { return RealRecord.LogicalDeleteCode; }
            set { RealRecord.LogicalDeleteCode = value; }
        }

        #endregion </08.�_���폜�敪>

        #region <09.�⍇������ƃR�[�h>

        /// <summary>�⍇������ƃR�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public string InqOriginalEpCd
        {
            get { return RealRecord.InqOriginalEpCd; }
            set { RealRecord.InqOriginalEpCd = value; }
        }

        #endregion </09.�⍇������ƃR�[�h>

        #region <10.�⍇�������_�R�[�h>

        /// <summary>�⍇�������_�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public string InqOriginalSecCd
        {
            get { return RealRecord.InqOriginalSecCd; }
            set { RealRecord.InqOriginalSecCd = value; }
        }

        #endregion </10.�⍇�������_�R�[�h>

        #region <11.�⍇���ԍ�>

        /// <summary>�⍇���ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        public long InquiryNumber
        {
            get { return RealRecord.InquiryNumber; }
            set { RealRecord.InquiryNumber = value; }
        }

        #endregion </11.�⍇���ԍ�>

        #region <12.���^�������ԍ�>

        /// <summary>���^�������ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        public int NumberPlate1Code
        {
            get { return RealRecord.NumberPlate1Code; }
            set { RealRecord.NumberPlate1Code = value; }
        }

        #endregion </12.���^�������ԍ�>

        #region <13.���^�����ǖ���>

        /// <summary>���^�����ǖ��̂��擾�܂��͐ݒ肵�܂��B</summary>
        public string NumberPlate1Name
        {
            get { return RealRecord.NumberPlate1Name; }
            set { RealRecord.NumberPlate1Name = value; }
        }

        #endregion </13.���^�����ǖ���>

        #region <14.�ԗ��o�^�ԍ��i��ʁj>

        /// <summary>�ԗ��o�^�ԍ��i��ʁj���擾�܂��͐ݒ肵�܂��B</summary>
        public string NumberPlate2
        {
            get { return RealRecord.NumberPlate2; }
            set { RealRecord.NumberPlate2 = value; }
        }

        #endregion </14.�ԗ��o�^�ԍ��i��ʁj>

        #region <15.�ԗ��o�^�ԍ��i�J�i�j>

        /// <summary>�ԗ��o�^�ԍ��i�J�i�j���擾�܂��͐ݒ肵�܂��B</summary>
        public string NumberPlate3
        {
            get { return RealRecord.NumberPlate3; }
            set { RealRecord.NumberPlate3 = value; }
        }

        #endregion </15.�ԗ��o�^�ԍ��i�J�i�j>

        #region <16.�ԗ��o�^�ԍ��i�v���[�g�ԍ��j>

        /// <summary>�ԗ��o�^�ԍ��i�v���[�g�ԍ��j���擾�܂��͐ݒ肵�܂��B</summary>
        public int NumberPlate4
        {
            get { return RealRecord.NumberPlate4; }
            set { RealRecord.NumberPlate4 = value; }
        }

        #endregion </16.�ԗ��o�^�ԍ��i�v���[�g�ԍ��j>

        #region <17.�^���w��ԍ�>

        /// <summary>�^���w��ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        public int ModelDesignationNo
        {
            get { return RealRecord.ModelDesignationNo; }
            set { RealRecord.ModelDesignationNo = value; }
        }

        #endregion </17.�^���w��ԍ�>

        #region <18.�ޕʔԍ�>

        /// <summary>�ޕʔԍ����擾�܂��͐ݒ肵�܂��B</summary>
        public int CategoryNo
        {
            get { return RealRecord.CategoryNo; }
            set { RealRecord.CategoryNo = value; }
        }

        #endregion </18.�ޕʔԍ�>

        #region <19.���[�J�[�R�[�h>

        /// <summary>���[�J�[�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
        public int MakerCode
        {
            get { return RealRecord.MakerCode; }
            set { RealRecord.MakerCode = value; }
        }

        #endregion </19.���[�J�[�R�[�h>

        #region <20.�Ԏ�R�[�h>

        /// <summary>�Ԏ�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>�Ԗ��R�[�h(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
        public int ModelCode
        {
            get { return RealRecord.ModelCode; }
            set { RealRecord.ModelCode = value; }
        }

        #endregion </20.�Ԏ�R�[�h>

        #region <21.�Ԏ�T�u�R�[�h>

        /// <summary>�Ԏ�T�u�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>0�`899:�񋟕�,900�`հ�ް�o�^</remarks>
        public int ModelSubCode
        {
            get { return RealRecord.ModelSubCode; }
            set { RealRecord.ModelSubCode = value; }
        }

        #endregion </21.�Ԏ�T�u�R�[�h>

        #region <22.�Ԏ햼>

        /// <summary>�Ԏ햼���擾�܂��͐ݒ肵�܂��B</summary>
        public string ModelName
        {
            get { return RealRecord.ModelName; }
            set { RealRecord.ModelName = value; }
        }

        #endregion </22.�Ԏ햼>

        #region <23.�Ԍ��،^��>

        /// <summary>�Ԍ��،^�����擾�܂��͐ݒ肵�܂��B</summary>
        public string CarInspectCertModel
        {
            get { return RealRecord.CarInspectCertModel; }
            set { RealRecord.CarInspectCertModel = value; }
        }

        #endregion </23.�Ԍ��،^��>

        #region <24.�^���i�t���^�j>

        /// <summary>�^���i�t���^�j���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>�t���^��(44���p)</remarks>
        public string FullModel
        {
            get { return RealRecord.FullModel; }
            set { RealRecord.FullModel = value; }
        }

        #endregion </24.�^���i�t���^�j>

        #region <25.�ԑ�ԍ�>

        /// <summary>�ԑ�ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        public string FrameNo
        {
            get { return RealRecord.FrameNo; }
            set { RealRecord.FrameNo = value; }
        }

        #endregion </25.�ԑ�ԍ�>

        #region <26.�ԑ�^��>

        /// <summary>�ԑ�^�����擾�܂��͐ݒ肵�܂��B</summary>
        public string FrameModel
        {
            get { return RealRecord.FrameModel; }
            set { RealRecord.FrameModel = value; }
        }

        #endregion </26.�ԑ�^��>

        #region <27.�V���V�[No>

        /// <summary>�V���V�[No���擾�܂��͐ݒ肵�܂��B</summary>
        public string ChassisNo
        {
            get { return RealRecord.ChassisNo; }
            set { RealRecord.ChassisNo = value; }
        }

        #endregion </27.�V���V�[No>

        #region <28.�ԗ��ŗL�ԍ�>

        /// <summary>�ԗ��ŗL�ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>���j�[�N�ȌŒ�ԍ�</remarks>
        public int CarProperNo
        {
            get { return RealRecord.CarProperNo; }
            set { RealRecord.CarProperNo = value; }
        }

        #endregion </28.�ԗ��ŗL�ԍ�>

        #region <29.���Y�N���iNUM�^�C�v�j>

        /// <summary>���Y�N���iNUM�^�C�v�j���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>YYYYMM</remarks>
        public int ProduceTypeOfYearNum
        {
            get { return RealRecord.ProduceTypeOfYearNum; }
            set { RealRecord.ProduceTypeOfYearNum = value; }
        }

        #endregion </29.���Y�N���iNUM�^�C�v�j>

        #region <30.�R�����g>

        /// <summary>�R�����g���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>�J�^���O�̃R�����g��P�ʁE�J���[���i�[</remarks>
        public string Comment
        {
            get { return RealRecord.Comment; }
            set { RealRecord.Comment = value; }
        }

        #endregion </30.�R�����g>

        #region <31.���y�A�J���[�R�[�h>

        /// <summary>���y�A�J���[�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>�J�^���O�̐F�R�[�h�i���y�A�p���V�Ԏ��ƈقȂ�ꍇ�j</remarks>
        public string RpColorCode
        {
            get { return RealRecord.RpColorCode; }
            set { RealRecord.RpColorCode = value; }
        }

        #endregion </31.���y�A�J���[�R�[�h>

        #region <32.�J���[����1>

        /// <summary>�J���[����1���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>��ʕ\���p��������</remarks>
        public string ColorName1
        {
            get { return RealRecord.ColorName1; }
            set { RealRecord.ColorName1 = value; }
        }

        #endregion </32.�J���[����1>

        #region <33.�g�����R�[�h>

        /// <summary>�g�����R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public string TrimCode
        {
            get { return RealRecord.TrimCode; }
            set { RealRecord.TrimCode = value; }
        }

        #endregion </33.�g�����R�[�h>

        #region <34.�g��������>

        /// <summary>�g�������̂��擾�܂��͐ݒ肵�܂��B</summary>
        public string TrimName
        {
            get { return RealRecord.TrimName; }
            set { RealRecord.TrimName = value; }
        }

        #endregion </34.�g��������>

        #region <35.�ԗ����s����>

        /// <summary>�ԗ����s�������擾�܂��͐ݒ肵�܂��B</summary>
        public int Mileage
        {
            get { return RealRecord.Mileage; }
            set { RealRecord.Mileage = value; }
        }

        #endregion </35.�ԗ����s����>

        #region <36.�����I�u�W�F�N�g>

        /// <summary>�����I�u�W�F�N�g���擾�܂��͐ݒ肵�܂��B</summary>
        public byte[] EquipObj
        {
            get { return RealRecord.EquipObj; }
            set { RealRecord.EquipObj = value; }
        }

        #endregion </36.�����I�u�W�F�N�g>

        #region <37.�󒍃X�e�[�^�X>

        /// <summary>�󒍃X�e�[�^�X���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>10:����,20:��,30:����</remarks>
        public int AcptAnOdrStatus
        {
            get { return RealRecord.AcptAnOdrStatus; }
            set { RealRecord.AcptAnOdrStatus = value; }
        }

        #endregion </37.�󒍃X�e�[�^�X>

        #region <38.����`�[�ԍ�>

        /// <summary>����`�[�ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
        public string SalesSlipNum
        {
            get { return RealRecord.SalesSlipNum; }
            set { RealRecord.SalesSlipNum = value; }
        }

        #endregion </38.����`�[�ԍ�>
        // --- ADD LDNS wangqx 2011/08/08 ---------->>>>>
        #region <32.����>

        /// <summary>���Ԃ��擾�܂��͐ݒ肵�܂��B</summary>
        public string CarNo
        {
            get { return RealRecord.CarNo; }
            set { RealRecord.CarNo = value; }
        }

        #endregion </32.����>

        #region <33.���[�J�[����>

        /// <summary>���[�J�[���̂��擾�܂��͐ݒ肵�܂��B</summary>
        public string MakerName
        {
            get { return RealRecord.MakerName; }
            set { RealRecord.MakerName = value; }
        }

        #endregion </33.���[�J�[����>

        #region <34.�O���[�h����>

        /// <summary>�O���[�h���̂��擾�܂��͐ݒ肵�܂��B</summary>
        public string GradeName
        {
            get { return RealRecord.GradeName; }
            set { RealRecord.GradeName = value; }
        }

        #endregion </34.�O���[�h����>

        #region <35.�{�f�B�[����>

        /// <summary>�{�f�B�[���̂��擾�܂��͐ݒ肵�܂��B</summary>
        public string BodyName
        {
            get { return RealRecord.BodyName; }
            set { RealRecord.BodyName = value; }
        }

        #endregion </35.�{�f�B�[����>

        #region <36.�h�A��>

        /// <summary>�h�A�����擾�܂��͐ݒ肵�܂��B</summary>
        public int DoorCount
        {
            get { return RealRecord.DoorCount; }
            set { RealRecord.DoorCount = value; }
        }

        #endregion </36.�h�A��>

        #region <37.�G���W���^������>

        /// <summary>�G���W���^�����̂��擾�܂��͐ݒ肵�܂��B</summary>
        public string EngineModelNm
        {
            get { return RealRecord.EngineModelNm; }
            set { RealRecord.EngineModelNm = value; }
        }

        #endregion </37.�G���W���^������>

        #region <38.�ʏ̔r�C��>

        /// <summary>�ʏ̔r�C�ʂ��擾�܂��͐ݒ肵�܂��B</summary>
        public int CmnNmEngineDisPlace
        {
            get { return RealRecord.CmnNmEngineDisPlace; }
            set { RealRecord.CmnNmEngineDisPlace = value; }
        }

        #endregion </38.�ʏ̔r�C��>

        #region <39.�����@�^���i�G���W���j>

        /// <summary>�����@�^���i�G���W���j���擾�܂��͐ݒ肵�܂��B</summary>
        public string EngineModel
        {
            get { return RealRecord.EngineModel; }
            set { RealRecord.EngineModel = value; }
        }

        #endregion </39.�����@�^���i�G���W���j>

        #region <40.�ϑ��i��>

        /// <summary>�ϑ��i�����擾�܂��͐ݒ肵�܂��B</summary>
        public int NumberOfGear
        {
            get { return RealRecord.NumberOfGear; }
            set { RealRecord.NumberOfGear = value; }
        }

        #endregion </40.�ϑ��i��>

        #region <41.�ϑ��@����>

        /// <summary>�ϑ��@���̂��擾�܂��͐ݒ肵�܂��B</summary>
        public string GearNm
        {
            get { return RealRecord.GearNm; }
            set { RealRecord.GearNm = value; }
        }

        #endregion </41.�ϑ��@����>

        #region <42.E�敪����>

        /// <summary>E�敪���̂��擾�܂��͐ݒ肵�܂��B</summary>
        public string EDivNm
        {
            get { return RealRecord.EDivNm; }
            set { RealRecord.EDivNm = value; }
        }

        #endregion </42.E�敪����>

        #region <43.�~�b�V��������>

        /// <summary>�~�b�V�������̂��擾�܂��͐ݒ肵�܂��B</summary>
        public string TransmissionNm
        {
            get { return RealRecord.TransmissionNm; }
            set { RealRecord.TransmissionNm = value; }
        }

         #endregion </43.�~�b�V��������>

        #region <44.�V�t�g����>

        /// <summary>�V�t�g���̂��擾�܂��͐ݒ肵�܂��B</summary>
        public string ShiftNm
        {
            get { return RealRecord.ShiftNm; }
            set { RealRecord.ShiftNm = value; }
        }

        #endregion </44.�V�t�g����>
        // --- ADD LDNS wangqx 2011/08/08 ----------<<<<<

        // ADD 2012/05/31 -------------------------->>>>>
        #region <45.���N�x�iNUM�^�C�v�j>

        /// <summary>���N�x�iNUM�^�C�v�j���擾�܂��͐ݒ肵�܂��B</summary>
        public Int32 FirstEntryDateNumTyp
        {
            get { return RealRecord.FirstEntryDateNumTyp; }
            set { RealRecord.FirstEntryDateNumTyp = value; }
        }

        #endregion </45.���N�x�iNUM�^�C�v�j>

        #region <46.�ԗ��t�����I�u�W�F�N�g>

        /// <summary>�ԗ��t�����I�u�W�F�N�g���擾�܂��͐ݒ肵�܂��B</summary>
        public Byte[] CarAddInf
        {
            get { return RealRecord.CarAddInf; }
            set { RealRecord.CarAddInf = value; }
        }

        #endregion </46.�ԗ��t�����I�u�W�F�N�g>

        #region <47.�������i�I�u�W�F�N�g>

        /// <summary>�������i�I�u�W�F�N�g���擾�܂��͐ݒ肵�܂��B</summary>
        public Byte[] EquipPrtsObj
        {
            get { return RealRecord.EquipPrtsObj; }
            set { RealRecord.EquipPrtsObj = value; }
        }

        #endregion </47.�������i�I�u�W�F�N�g>

        // ADD 2012/05/31 --------------------------<<<<<

        // ADD 2013/04/19 SCM��Q��10521�Ή� ----------------------------------->>>>>
        #region <48.�ԗ��Ǘ��R�[�h>

        /// <summary>�ԗ��Ǘ��R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public string CarMngCode
        {
            get { return RealRecord.CarMngCode; }
            set { RealRecord.CarMngCode = value; }
        }

        #endregion </48.�ԗ��Ǘ��R�[�h>
        // ADD 2013/04/19 SCM��Q��10521�Ή� -----------------------------------<<<<<

        // ADD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
        #region <49.���ɗ\���>

        /// <summary>���ɗ\������擾�܂��͐ݒ肵�܂��B</summary>
        public Int32 ExpectedCeDate
        {
            get
            {
                return RealRecord.ExpectedCeDate;
            }
            set
            {
                RealRecord.ExpectedCeDate = value;
            }
        }

        #endregion </49.���ɗ\���>
        // ADD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<

        #endregion // </Automatic Code>
    }
}
