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
// �� �� ��  2013/04/19  �C�����e : ��Q��10521 SCM�󒍃f�[�^(�ԗ����)�̎ԗ��Ǘ��R�[�h�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/05/09  �C�����e : ��Q��10384 SCM�󒍃f�[�^(�ԗ����)�ɓ��ɗ\�����ǉ�
//----------------------------------------------------------------------------//
using System;
using System.Text;

using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ���[�U�[DB SCM�󒍃f�[�^(�ԗ����)�̃��b�p�[�N���X�i�����j
    /// </summary>
    /// <remarks>
    /// ���񑩂̉ߕs����(���ISCMOrderCarRecord�̎���)���������܂��B
    /// </remarks>
    public abstract partial class UserSCMOrderCarWrapper
    {
        /// <summary>
        /// �L�[�ɕϊ����܂��B
        /// </summary>
        /// <returns>�L�[</returns>
        /// <see cref="ISCMOrderCarRecord"/>
        public string ToKey()
        {
            return SCMEntityUtil.GetCarRecordKey(this);
        }

        /// <summary>������Ƃ̊֘AGUID</summary>
        private Guid _salesRelationId = Guid.NewGuid();
        /// <summary>
        /// ������Ƃ̊֘AGUID(������Ƃ̊֘A�t���ɗp���܂�)
        /// </summary>
        /// <remarks>�e�[�u�����C�A�E�g�ɂ͑��݂��܂���B</remarks>
        /// <see cref="ISCMOrderCarRecord"/>
        public Guid SalesRelationId
        {
            get { return _salesRelationId; }
            set { _salesRelationId = value; }
        }

        /// <summary>
        /// CSV�ɕϊ����܂��B
        /// </summary>
        /// <returns>CSV</returns>
        /// <see cref="ISCMOrderCarRecord"/>
        public string ToCSV()
        {
            StringBuilder csv = new StringBuilder();
            {
                csv.Append(CreateDateTime).Append(SCMEntityUtil.COMMA);
                csv.Append(UpdateDateTime).Append(SCMEntityUtil.COMMA);
                csv.Append(EnterpriseCode).Append(SCMEntityUtil.COMMA);
                csv.Append(FileHeaderGuid).Append(SCMEntityUtil.COMMA);
                csv.Append(UpdEmployeeCode).Append(SCMEntityUtil.COMMA);
                csv.Append(UpdAssemblyId1).Append(SCMEntityUtil.COMMA);
                csv.Append(UpdAssemblyId2).Append(SCMEntityUtil.COMMA);
                csv.Append(LogicalDeleteCode).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOriginalEpCd.Trim()).Append(SCMEntityUtil.COMMA);//@@@@20230303
                csv.Append(InqOriginalSecCd).Append(SCMEntityUtil.COMMA);
                csv.Append(InquiryNumber).Append(SCMEntityUtil.COMMA);
                csv.Append(NumberPlate1Code).Append(SCMEntityUtil.COMMA);
                csv.Append(NumberPlate1Name).Append(SCMEntityUtil.COMMA);
                csv.Append(NumberPlate2).Append(SCMEntityUtil.COMMA);
                csv.Append(NumberPlate3).Append(SCMEntityUtil.COMMA);
                csv.Append(NumberPlate4).Append(SCMEntityUtil.COMMA);
                csv.Append(ModelDesignationNo).Append(SCMEntityUtil.COMMA);
                csv.Append(CategoryNo).Append(SCMEntityUtil.COMMA);
                csv.Append(MakerCode).Append(SCMEntityUtil.COMMA);
                csv.Append(ModelCode).Append(SCMEntityUtil.COMMA);
                csv.Append(ModelSubCode).Append(SCMEntityUtil.COMMA);
                csv.Append(ModelName).Append(SCMEntityUtil.COMMA);
                csv.Append(CarInspectCertModel).Append(SCMEntityUtil.COMMA);
                csv.Append(FullModel).Append(SCMEntityUtil.COMMA);
                csv.Append(FrameNo).Append(SCMEntityUtil.COMMA);
                csv.Append(FrameModel).Append(SCMEntityUtil.COMMA);
                csv.Append(ChassisNo).Append(SCMEntityUtil.COMMA);
                csv.Append(CarProperNo).Append(SCMEntityUtil.COMMA);
                csv.Append(ProduceTypeOfYearNum).Append(SCMEntityUtil.COMMA);
                csv.Append(Comment).Append(SCMEntityUtil.COMMA);
                csv.Append(RpColorCode).Append(SCMEntityUtil.COMMA);
                csv.Append(ColorName1).Append(SCMEntityUtil.COMMA);
                csv.Append(TrimCode).Append(SCMEntityUtil.COMMA);
                csv.Append(TrimName).Append(SCMEntityUtil.COMMA);
                csv.Append(Mileage).Append(SCMEntityUtil.COMMA);
                csv.Append(EquipObj).Append(SCMEntityUtil.COMMA);
                csv.Append(AcptAnOdrStatus).Append(SCMEntityUtil.COMMA);
                // --- ADD LDNS wangqx 2011/08/08 ---------->>>>>
                csv.Append(CarNo).Append(SCMEntityUtil.COMMA);
                csv.Append(MakerName).Append(SCMEntityUtil.COMMA);
                csv.Append(GradeName).Append(SCMEntityUtil.COMMA);
                csv.Append(BodyName).Append(SCMEntityUtil.COMMA);
                csv.Append(DoorCount).Append(SCMEntityUtil.COMMA);
                csv.Append(EngineModelNm).Append(SCMEntityUtil.COMMA);
                csv.Append(CmnNmEngineDisPlace).Append(SCMEntityUtil.COMMA);
                csv.Append(EngineModel).Append(SCMEntityUtil.COMMA);
                csv.Append(NumberOfGear).Append(SCMEntityUtil.COMMA);
                csv.Append(GearNm).Append(SCMEntityUtil.COMMA);
                csv.Append(EDivNm).Append(SCMEntityUtil.COMMA);
                csv.Append(TransmissionNm).Append(SCMEntityUtil.COMMA);
                csv.Append(ShiftNm).Append(SCMEntityUtil.COMMA);
                // --- ADD LDNS wangqx 2011/08/08 ----------<<<<<
                // ADD 2012/05/31--------------------------->>>>>
                csv.Append(FirstEntryDateNumTyp).Append(SCMEntityUtil.COMMA);
                csv.Append(CarAddInf).Append(SCMEntityUtil.COMMA);
                csv.Append(EquipPrtsObj).Append(SCMEntityUtil.COMMA);
                // ADD 2012/05/31---------------------------<<<<<
                // ADD 2013/04/19 SCM��Q��10521�Ή� ----------------------------------->>>>>
                csv.Append(CarMngCode).Append(SCMEntityUtil.COMMA);
                // ADD 2013/04/19 SCM��Q��10521�Ή� -----------------------------------<<<<<
                // ADD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
                csv.Append(ExpectedCeDate).Append(SCMEntityUtil.COMMA);
                // ADD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<
                csv.Append(SalesSlipNum);
            }
            return csv.ToString();
        }
    }
}
