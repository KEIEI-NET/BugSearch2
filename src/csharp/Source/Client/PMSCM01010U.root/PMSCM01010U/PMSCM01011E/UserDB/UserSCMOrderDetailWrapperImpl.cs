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
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/06/17  �C�����e : �e�[�u���̃��C�A�E�g�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018�@��� ���b
// �� �� ��  2011/05/23  �C�����e : �e�[�u�����C�A�E�g�ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11470007-00 �쐬�S�� : �c����
// �C �� ��  2018/04/16  �C�����e : SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�
//----------------------------------------------------------------------------//
using System;
using System.Text;

using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.UIData
{
    using RecordType    = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlIqWork;
    using RecordTypeWeb = Broadleaf.Application.UIData.ScmOdDtInq;

    /// <summary>
    /// ���[�U�[DB SCM�󒍖��׃f�[�^(�⍇���E����)�̃��b�p�[�N���X�i�����j
    /// </summary>
    /// <remarks>
    /// ���񑩂̉ߕs����(���ISCMOrderDetailRecord�̎���)���������܂��B
    /// </remarks>
    public abstract partial class UserSCMOrderDetailWrapper
    {
        /// <summary>�񓚊������擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>YYYYMMDD</remarks>
        public DateTime AnswerLimitDate
        {
            get { return RealRecord.AnswerLimitDate; }
            set { RealRecord.AnswerLimitDate = value; }
        }

        /// <summary>
        /// �L�[�ɕϊ����܂��B
        /// </summary>
        /// <returns>�L�[</returns>
        /// <see cref="ISCMOrderDetailRecord"/>
        public string ToKey()
        {
            return SCMEntityUtil.GetDetailRecordKey(this);
        }

        /// <summary>
        /// SCM�󒍃f�[�^(�ԗ����)�̃L�[�ɕϊ����܂��B
        /// </summary>
        /// <returns>SCM�󒍃f�[�^(�ԗ����)�̃L�[</returns>
        /// <see cref="ISCMOrderDetailRecord"/>
        public string ToCarKey()
        {
            return SCMEntityUtil.GetCarRecordKey(this);
        }

        /// <summary>
        /// SCM�󒍃f�[�^�̊֘A�L�[�ɕϊ����܂��B
        /// </summary>
        /// <returns>SCM�󒍃f�[�^�̊֘A�L�[</returns>
        /// <see cref="ISCMOrderDetailRecord"/>
        public string ToRelationKey()
        {
            return SCMEntityUtil.GetRelationKey(this);
        }

        /// <summary>
        /// CSV�ɕϊ����܂��B
        /// </summary>
        /// <returns>CSV</returns>
        /// <see cref="ISCMOrderDetailRecord"/>
        /// <remarks>
        /// <br>Update Note      :   2018/04/16 �c����</br>
        /// <br>�Ǘ��ԍ�         :   11470007-00</br>
        /// <br>                 :   SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�</br>
        /// </remarks>
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
                csv.Append(InqOtherEpCd).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOtherSecCd).Append(SCMEntityUtil.COMMA);
                csv.Append(InquiryNumber).Append(SCMEntityUtil.COMMA);
                csv.Append(UpdateDate).Append(SCMEntityUtil.COMMA);
                csv.Append(UpdateTime).Append(SCMEntityUtil.COMMA);
                csv.Append(InqRowNumber).Append(SCMEntityUtil.COMMA);
                csv.Append(InqRowNumDerivedNo).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOrgDtlDiscGuid).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOthDtlDiscGuid).Append(SCMEntityUtil.COMMA);
                csv.Append(GoodsDivCd).Append(SCMEntityUtil.COMMA);
                csv.Append(RecyclePrtKindCode).Append(SCMEntityUtil.COMMA);
                csv.Append(RecyclePrtKindName).Append(SCMEntityUtil.COMMA);
                csv.Append(DeliveredGoodsDiv).Append(SCMEntityUtil.COMMA);
                csv.Append(HandleDivCode).Append(SCMEntityUtil.COMMA);
                csv.Append(GoodsShape).Append(SCMEntityUtil.COMMA);
                csv.Append(DelivrdGdsConfCd).Append(SCMEntityUtil.COMMA);
                csv.Append(DeliGdsCmpltDueDate).Append(SCMEntityUtil.COMMA);
                csv.Append(AnswerDeliveryDate).Append(SCMEntityUtil.COMMA);
                csv.Append(BLGoodsCode).Append(SCMEntityUtil.COMMA);
                csv.Append(BLGoodsDrCode).Append(SCMEntityUtil.COMMA);
                csv.Append(InqGoodsName).Append(SCMEntityUtil.COMMA);
                csv.Append(AnsGoodsName).Append(SCMEntityUtil.COMMA);
                csv.Append(SalesOrderCount).Append(SCMEntityUtil.COMMA);
                csv.Append(DeliveredGoodsCount).Append(SCMEntityUtil.COMMA);
                csv.Append(GoodsNo).Append(SCMEntityUtil.COMMA);
                csv.Append(GoodsMakerCd).Append(SCMEntityUtil.COMMA);
                csv.Append(GoodsMakerNm).Append(SCMEntityUtil.COMMA);
                csv.Append(PureGoodsMakerCd).Append(SCMEntityUtil.COMMA);
                csv.Append(InqPureGoodsNo).Append(SCMEntityUtil.COMMA);
                csv.Append(AnsPureGoodsNo).Append(SCMEntityUtil.COMMA);
                csv.Append(ListPrice).Append(SCMEntityUtil.COMMA);
                csv.Append(UnitPrice).Append(SCMEntityUtil.COMMA);
                csv.Append(GoodsAddInfo).Append(SCMEntityUtil.COMMA);
                csv.Append(RoughRrofit).Append(SCMEntityUtil.COMMA);
                csv.Append(RoughRate).Append(SCMEntityUtil.COMMA);
                csv.Append(AnswerLimitDate).Append(SCMEntityUtil.COMMA);
                csv.Append(CommentDtl).Append(SCMEntityUtil.COMMA);
                csv.Append(AppendingFileDtl).Append(SCMEntityUtil.COMMA);
                csv.Append(AppendingFileNmDtl).Append(SCMEntityUtil.COMMA);
                csv.Append(ShelfNo).Append(SCMEntityUtil.COMMA);
                csv.Append(AdditionalDivCd).Append(SCMEntityUtil.COMMA);
                csv.Append(CorrectDivCD).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOrdDivCd).Append(SCMEntityUtil.COMMA);
                // DEL 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ---------->>>>>
                //csv.Append(DisplayOrder);
                // DEL 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ----------<<<<<
                // ADD 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ---------->>>>>
                csv.Append(DisplayOrder).Append(SCMEntityUtil.COMMA);
                csv.Append(CancelCndtinDiv).Append(SCMEntityUtil.COMMA);
                csv.Append(AcptAnOdrStatus).Append(SCMEntityUtil.COMMA);
                csv.Append(SalesSlipNum).Append(SCMEntityUtil.COMMA);
                // --- UPD m.suzuki 2011/05/23 ---------->>>>>
                //csv.Append( SalesRowNo );
                csv.Append( SalesRowNo ).Append( SCMEntityUtil.COMMA );
                csv.Append( PmWarehouseCd ).Append( SCMEntityUtil.COMMA );
                csv.Append( PmWarehouseName ).Append( SCMEntityUtil.COMMA );
                csv.Append( PmShelfNo );
                // --- UPD m.suzuki 2011/05/23 ----------<<<<<
                // ADD 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ----------<<<<<

                csv.Append(CampaignCode).Append(SCMEntityUtil.COMMA);  // ADD 2011/10/10
                // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                csv.Append(InqBlUtyPtThCd).Append(SCMEntityUtil.COMMA);
                csv.Append(InqBlUtyPtSbCd).Append(SCMEntityUtil.COMMA);
                csv.Append(AnsBlUtyPtThCd).Append(SCMEntityUtil.COMMA);
                csv.Append(AnsBlUtyPtSbCd).Append(SCMEntityUtil.COMMA);
                csv.Append(AnsBLGoodsCode).Append(SCMEntityUtil.COMMA);
                csv.Append(AnsBLGoodsDrCode);
                // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            return csv.ToString();
        }
    }
}
