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
// �� �� ��  2009/05/20  �C�����e : �V�K�쐬
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
// �� �� ��  2013/04/19  �C�����e : ��Q��10521 SCM�󒍃f�[�^(�ԗ����)�Ɏԗ��Ǘ��R�[�h��ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/05/09  �C�����e : ��Q��10384 SCM�󒍃f�[�^(�ԗ����)�ɓ��ɗ\�����ǉ�
//----------------------------------------------------------------------------//
using System;

using Broadleaf.Application.UIData.WebDB;
// ADD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
using Broadleaf.Library.Globarization;
// ADD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<

namespace Broadleaf.Application.UIData
{
    using RecordType    = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtCarWork;
    using RecordTypeWeb = Broadleaf.Application.UIData.ScmOdDtCar;

    /// <summary>
    /// ���[�U�[DB SCM�󒍃f�[�^(�ԗ����)�̃��R�[�h�N���X
    /// </summary>
    public class UserSCMOrderCarRecord : UserSCMOrderCarWrapper
    {
        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public UserSCMOrderCarRecord() : base() { }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="realRecord">�{���̃��R�[�h</param>
        public UserSCMOrderCarRecord(RecordType realRecord) : base(realRecord) { }

        #endregion // </Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="webRecord">SCM�󔭒��f�[�^(�ԗ����)</param>
        public UserSCMOrderCarRecord(WebSCMOrderCarRecord webRecord) : base(new RecordType())
        {
            RealRecord.LogicalDeleteCode = webRecord.LogicalDeleteCode; // �_���폜�敪
            RealRecord.InqOriginalEpCd = webRecord.InqOriginalEpCd.Trim(); // �⍇������ƃR�[�h//@@@@20230303
            RealRecord.InqOriginalSecCd = webRecord.InqOriginalSecCd; // �⍇�������_�R�[�h
            RealRecord.InquiryNumber = webRecord.InquiryNumber; // �⍇���ԍ�
            RealRecord.NumberPlate1Code = webRecord.NumberPlate1Code; // ���^�������ԍ�
            RealRecord.NumberPlate1Name = webRecord.NumberPlate1Name; // ���^�����ǖ���
            RealRecord.NumberPlate2 = webRecord.NumberPlate2; // �ԗ��o�^�ԍ�(���)
            RealRecord.NumberPlate3 = webRecord.NumberPlate3; // �ԗ��o�^�ԍ�(�J�i)
            RealRecord.NumberPlate4 = webRecord.NumberPlate4; // �ԗ��o�^�ԍ�(�v���[�g�ԍ�)
            RealRecord.ModelDesignationNo = webRecord.ModelDesignationNo; // �^���w��ԍ�
            RealRecord.CategoryNo = webRecord.CategoryNo; // �ޕʔԍ�
            RealRecord.MakerCode = webRecord.MakerCode; // ���[�J�[�R�[�h
            RealRecord.ModelCode = webRecord.ModelCode; // �Ԏ�R�[�h
            RealRecord.ModelSubCode = webRecord.ModelSubCode; // �Ԏ�T�u�R�[�h
            RealRecord.ModelName = webRecord.ModelName; // �Ԏ햼
            RealRecord.CarInspectCertModel = webRecord.CarInspectCertModel; // �Ԍ��،^��
            RealRecord.FullModel = webRecord.FullModel; // �^��(�t���^)
            RealRecord.FrameNo = webRecord.FrameNo; // �ԑ�ԍ�
            RealRecord.FrameModel = webRecord.FrameModel; // �ԑ�^��
            RealRecord.ChassisNo = webRecord.ChassisNo; // �V���V�[No
            RealRecord.CarProperNo = webRecord.CarProperNo; // �ԗ��ŗL�ԍ�
            RealRecord.ProduceTypeOfYearNum = webRecord.ProduceTypeOfYearNum; // ���Y�N��(Num�^�C�v)
            RealRecord.Comment = webRecord.Comment; // �R�����g
            RealRecord.RpColorCode = webRecord.RpColorCode; // ���y�A�J���[�R�[�h
            RealRecord.ColorName1 = webRecord.ColorName1; // �J���[����1
            RealRecord.TrimCode = webRecord.TrimCode; // �g�����R�[�h
            RealRecord.TrimName = webRecord.TrimName; // �g��������
            RealRecord.Mileage = webRecord.Mileage; // �ԗ����s����
            RealRecord.EquipObj = webRecord.EquipObj; // �����I�u�W�F�g
            // --- ADD LDNS wangqx 2011/08/08 ---------->>>>>
            RealRecord.CarNo = webRecord.CarNo; // ����
            RealRecord.MakerName = webRecord.MakerName; // ���[�J�[����
            RealRecord.GradeName = webRecord.GradeName; // �O���[�h����
            RealRecord.BodyName = webRecord.BodyName; // �{�f�B�[����
            RealRecord.DoorCount = webRecord.DoorCount; // �h�A��
            RealRecord.EngineModelNm = webRecord.EngineModelNm; // �G���W���^������
            RealRecord.CmnNmEngineDisPlace = webRecord.CmnNmEngineDisPlace; // �ʏ̔r�C��
            RealRecord.EngineModel = webRecord.EngineModel; // �����@�^���i�G���W���j
            RealRecord.NumberOfGear = webRecord.NumberOfGear; // �ϑ��i��
            RealRecord.GearNm = webRecord.GearNm; // �ϑ��@����
            RealRecord.EDivNm = webRecord.EDivNm; // E�敪����
            RealRecord.TransmissionNm = webRecord.TransmissionNm; // �~�b�V��������
            RealRecord.ShiftNm = webRecord.ShiftNm; // �V�t�g����
            // --- ADD LDNS wangqx 2011/08/08 ----------<<<<<
            // ADD 2012/05/31 -------------------------->>>>>
            RealRecord.FirstEntryDateNumTyp = webRecord.FirstEntryDateNumTyp; // ���N�x�iNUM�^�C�v�j
            RealRecord.CarAddInf = webRecord.CarAddInf; // �ԗ��t�����I�u�W�F�N�g
            RealRecord.EquipPrtsObj = webRecord.EquipPrtsObj; // �������i�I�u�W�F�N�g
            // ADD 2012/05/31 --------------------------<<<<<
            // ADD 2013/04/19 SCM��Q��10521�Ή� ----------------------------------->>>>>
            RealRecord.CarMngCode = webRecord.CarMngCode; // �ԗ��Ǘ��R�[�h
            // ADD 2013/04/19 SCM��Q��10521�Ή� -----------------------------------<<<<<
            // ADD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
            RealRecord.ExpectedCeDate = webRecord.ExpectedCeDate; // ���ɗ\���
            // ADD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<
        }

        /// <summary>
        /// �R�s�[�R���X�g���N�^
        /// </summary>
        /// <param name="other">�R�s�[��</param>
        public UserSCMOrderCarRecord(UserSCMOrderCarRecord other)
        {
            if (other == null || other == this) return;

            RealRecord.CreateDateTime = other.CreateDateTime; // �쐬����
            RealRecord.UpdateDateTime = other.UpdateDateTime; // �X�V����
            RealRecord.EnterpriseCode = other.EnterpriseCode; // ��ƃR�[�h
            RealRecord.FileHeaderGuid = other.FileHeaderGuid; // GUID
            RealRecord.UpdEmployeeCode = other.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            RealRecord.UpdAssemblyId1 = other.UpdAssemblyId1; // �X�V�A�Z���u��1
            RealRecord.UpdAssemblyId2 = other.UpdAssemblyId2; // �X�V�A�Z���u��2
            RealRecord.LogicalDeleteCode = other.LogicalDeleteCode; // �_���폜�敪

            RealRecord.InqOriginalEpCd = other.InqOriginalEpCd.Trim(); // �⍇������ƃR�[�h//@@@@20230303
            RealRecord.InqOriginalSecCd = other.InqOriginalSecCd; // �⍇�������_�R�[�h
            RealRecord.InquiryNumber = other.InquiryNumber; // �⍇���ԍ�
            RealRecord.NumberPlate1Code = other.NumberPlate1Code; // ���^�������ԍ�
            RealRecord.NumberPlate1Name = other.NumberPlate1Name; // ���^�����ǖ���
            RealRecord.NumberPlate2 = other.NumberPlate2; // �ԗ��o�^�ԍ�(���)
            RealRecord.NumberPlate3 = other.NumberPlate3; // �ԗ��o�^�ԍ�(�J�i)
            RealRecord.NumberPlate4 = other.NumberPlate4; // �ԗ��o�^�ԍ�(�v���[�g�ԍ�)
            RealRecord.ModelDesignationNo = other.ModelDesignationNo; // �^���w��ԍ�
            RealRecord.CategoryNo = other.CategoryNo; // �ޕʔԍ�
            RealRecord.MakerCode = other.MakerCode; // ���[�J�[�R�[�h
            RealRecord.ModelCode = other.ModelCode; // �Ԏ�R�[�h
            RealRecord.ModelSubCode = other.ModelSubCode; // �Ԏ�T�u�R�[�h
            RealRecord.ModelName = other.ModelName; // �Ԏ햼
            RealRecord.CarInspectCertModel = other.CarInspectCertModel; // �Ԍ��،^��
            RealRecord.FullModel = other.FullModel; // �^��(�t���^)
            RealRecord.FrameNo = other.FrameNo; // �ԑ�ԍ�
            RealRecord.FrameModel = other.FrameModel; // �ԑ�^��
            RealRecord.ChassisNo = other.ChassisNo; // �V���V�[No
            RealRecord.CarProperNo = other.CarProperNo; // �ԗ��ŗL�ԍ�
            RealRecord.ProduceTypeOfYearNum = other.ProduceTypeOfYearNum; // ���Y�N��(Num�^�C�v)
            RealRecord.Comment = other.Comment; // �R�����g
            RealRecord.RpColorCode = other.RpColorCode; // ���y�A�J���[�R�[�h
            RealRecord.ColorName1 = other.ColorName1; // �J���[����1
            RealRecord.TrimCode = other.TrimCode; // �g�����R�[�h
            RealRecord.TrimName = other.TrimName; // �g��������
            RealRecord.Mileage = other.Mileage; // �ԗ����s����
            RealRecord.EquipObj = other.EquipObj; // �����I�u�W�F�g
            RealRecord.AcptAnOdrStatus = other.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            RealRecord.SalesSlipNum = other.SalesSlipNum; // ����`�[�ԍ�
            // --- ADD LDNS wangqx 2011/08/08 ---------->>>>>
            RealRecord.CarNo = other.CarNo; // ����
            RealRecord.MakerName = other.MakerName; // ���[�J�[����
            RealRecord.GradeName = other.GradeName; // �O���[�h����
            RealRecord.BodyName = other.BodyName; // �{�f�B�[����
            RealRecord.DoorCount = other.DoorCount; // �h�A��
            RealRecord.EngineModelNm = other.EngineModelNm; // �G���W���^������
            RealRecord.CmnNmEngineDisPlace = other.CmnNmEngineDisPlace; // �ʏ̔r�C��
            RealRecord.EngineModel = other.EngineModel; // �����@�^���i�G���W���j
            RealRecord.NumberOfGear = other.NumberOfGear; // �ϑ��i��
            RealRecord.GearNm = other.GearNm; // �ϑ��@����
            RealRecord.EDivNm = other.EDivNm; // E�敪����
            RealRecord.TransmissionNm = other.TransmissionNm; // �~�b�V��������
            RealRecord.ShiftNm = other.ShiftNm; // �V�t�g����
            // --- ADD LDNS wangqx 2011/08/08 ----------<<<<<
            // ADD 2012/05/31 -------------------------->>>>>
            RealRecord.FirstEntryDateNumTyp = other.FirstEntryDateNumTyp; // ���N�x�iNUM�^�C�v�j
            RealRecord.CarAddInf = other.CarAddInf; // �ԗ��t�����I�u�W�F�N�g
            RealRecord.EquipPrtsObj = other.EquipPrtsObj; // �������i�I�u�W�F�N�g
            // ADD 2012/05/31 --------------------------<<<<<
            // ADD 2013/04/19 SCM��Q��10521�Ή� ----------------------------------->>>>>
            RealRecord.CarMngCode = other.CarMngCode; // �ԗ��Ǘ��R�[�h
            // ADD 2013/04/19 SCM��Q��10521�Ή� -----------------------------------<<<<<
            // ADD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
            RealRecord.ExpectedCeDate = other.ExpectedCeDate; // ���ɗ\���
            // ADD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<
        }

        #region <User��WEB�ϊ�>
        /// <summary>
        /// UserDB����WebDB�ւ̋l�ւ�����
        /// </summary>
        /// <returns>SCM�󔭒��f�[�^(�ԗ����)</returns>
        public WebSCMOrderCarRecord CopyToWebSCMOrderCarRecord()
        {
            RecordTypeWeb webRecord = new RecordTypeWeb();
            {
                webRecord.LogicalDeleteCode = RealRecord.LogicalDeleteCode; // �_���폜�敪
                webRecord.InqOriginalEpCd = RealRecord.InqOriginalEpCd.Trim(); // �⍇������ƃR�[�h//@@@@20230303
                webRecord.InqOriginalSecCd = RealRecord.InqOriginalSecCd; // �⍇�������_�R�[�h
                webRecord.InquiryNumber = RealRecord.InquiryNumber; // �⍇���ԍ�
                webRecord.NumberPlate1Code = RealRecord.NumberPlate1Code; // ���^�������ԍ�
                webRecord.NumberPlate1Name = RealRecord.NumberPlate1Name; // ���^�����ǖ���
                webRecord.NumberPlate2 = RealRecord.NumberPlate2; // �ԗ��o�^�ԍ�(���)
                webRecord.NumberPlate3 = RealRecord.NumberPlate3; // �ԗ��o�^�ԍ�(�J�i)
                webRecord.NumberPlate4 = RealRecord.NumberPlate4; // �ԗ��o�^�ԍ�(�v���[�g�ԍ�)
                webRecord.ModelDesignationNo = RealRecord.ModelDesignationNo; // �^���w��ԍ�
                webRecord.CategoryNo = RealRecord.CategoryNo; // �ޕʔԍ�
                webRecord.MakerCode = RealRecord.MakerCode; // ���[�J�[�R�[�h
                webRecord.ModelCode = RealRecord.ModelCode; // �Ԏ�R�[�h
                webRecord.ModelSubCode = RealRecord.ModelSubCode; // �Ԏ�T�u�R�[�h
                webRecord.ModelName = RealRecord.ModelName; // �Ԏ햼
                webRecord.CarInspectCertModel = RealRecord.CarInspectCertModel; // �Ԍ��،^��
                webRecord.FullModel = RealRecord.FullModel; // �^��(�t���^)
                webRecord.FrameNo = RealRecord.FrameNo; // �ԑ�ԍ�
                webRecord.FrameModel = RealRecord.FrameModel; // �ԑ�^��
                webRecord.ChassisNo = RealRecord.ChassisNo; // �V���V�[No
                webRecord.CarProperNo = RealRecord.CarProperNo; // �ԗ��ŗL�ԍ�
                webRecord.ProduceTypeOfYearNum = RealRecord.ProduceTypeOfYearNum; // ���Y�N��(Num�^�C�v)
                webRecord.Comment = RealRecord.Comment; // �R�����g
                webRecord.RpColorCode = RealRecord.RpColorCode; // ���y�A�J���[�R�[�h
                webRecord.ColorName1 = RealRecord.ColorName1; // �J���[����1
                webRecord.TrimCode = RealRecord.TrimCode; // �g�����R�[�h
                webRecord.TrimName = RealRecord.TrimName; // �g��������
                webRecord.Mileage = RealRecord.Mileage; // �ԗ����s����
                webRecord.EquipObj = RealRecord.EquipObj; // �����I�u�W�F�g
                // --- ADD LDNS wangqx 2011/08/08 ---------->>>>>
                webRecord.CarNo = RealRecord.CarNo; // ����
                webRecord.MakerName = RealRecord.MakerName; // ���[�J�[����
                webRecord.GradeName = RealRecord.GradeName; // �O���[�h����
                webRecord.BodyName = RealRecord.BodyName; // �{�f�B�[����
                webRecord.DoorCount = RealRecord.DoorCount; // �h�A��
                webRecord.EngineModelNm = RealRecord.EngineModelNm; // �G���W���^������
                webRecord.CmnNmEngineDisPlace = RealRecord.CmnNmEngineDisPlace; // �ʏ̔r�C��
                webRecord.EngineModel = RealRecord.EngineModel; // �����@�^���i�G���W���j
                webRecord.NumberOfGear = RealRecord.NumberOfGear; // �ϑ��i��
                webRecord.GearNm = RealRecord.GearNm; // �ϑ��@����
                webRecord.EDivNm = RealRecord.EDivNm; // E�敪����
                webRecord.TransmissionNm = RealRecord.TransmissionNm; // �~�b�V��������
                webRecord.ShiftNm = RealRecord.ShiftNm; // �V�t�g����
                // --- ADD LDNS wangqx 2011/08/08 ----------<<<<<
                // ADD 2012/05/31 -------------------------->>>>>
                webRecord.FirstEntryDateNumTyp = RealRecord.FirstEntryDateNumTyp; // ���N�x�iNUM�^�C�v�j
                webRecord.CarAddInf = RealRecord.CarAddInf; // �ԗ��t�����I�u�W�F�N�g
                webRecord.EquipPrtsObj = RealRecord.EquipPrtsObj; // �������i�I�u�W�F�N�g
                // ADD 2012/05/31 --------------------------<<<<<
                // ADD 2013/04/19 SCM��Q��10521�Ή� ----------------------------------->>>>>
                webRecord.CarMngCode = RealRecord.CarMngCode; // �ԗ��Ǘ��R�[�h
                // ADD 2013/04/19 SCM��Q��10521�Ή� -----------------------------------<<<<<
                // ADD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
                webRecord.ExpectedCeDate = TDateTime.LongDateToDateTime("YYYYMMDD", RealRecord.ExpectedCeDate); // ���ɗ\���
                // ADD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<
            }
            return new WebSCMOrderCarRecord(webRecord);
        }
        #endregion
    }
}
