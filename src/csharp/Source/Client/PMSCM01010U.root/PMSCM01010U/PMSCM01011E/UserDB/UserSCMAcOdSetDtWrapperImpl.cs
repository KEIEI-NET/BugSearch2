//****************************************************************************//
// �V�X�e��         : �����񓚏���
// �v���O��������   : �����񓚏����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : qijh  
// �� �� ��  2013/02/27  �C�����e : Redmine#34752
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/05/09  �C�����e : SCM��Q��10470�Ή��E���i�K�i�E���L�����ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 31065 �L�� ���O
// �C �� ��  2015/01/19  �C�����e : SCM������ PMNS�Ή� ���ڒǉ� ���[�J�[��]�������i�A�I�[�v�����i�敪
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 30745 �g��
// �C �� ��  2015/02/10  �C�����e : SCM������ �񓚔[���敪�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 30746 ���� ��
// �C �� ��  2015/02/20  �C�����e : SCM������ C������ʁE���L�����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 30744 ���� ����q
// �C �� ��  2015/02/27  �C�����e : SCM������ �Z�b�g�i�ɗD�ǐݒ�ڍ׃R�[�h�Q�A�D�ǐݒ�ڍז��́A�݌ɏ󋵋敪�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11470007-00 �쐬�S�� : �c����
// �C �� ��  2018/04/16  �C�����e : SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�
//----------------------------------------------------------------------------//

using System;
using System.Text;

using Broadleaf.Application.UIData.Util;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.UIData
{
    using RecordType = Broadleaf.Application.Remoting.ParamData.SCMAcOdSetDtWork;
    using RecordTypeWeb = Broadleaf.Application.UIData.ScmOdSetDt;

    /// <summary>
    /// ���[�U�[DB SCM�󒍃Z�b�g���i�f�[�^�̃��b�p�[�N���X�i�����j
    /// </summary>
    /// <remarks>
    /// ���񑩂̉ߕs����(���ISCMAcOdSetDtRecord�̎���)���������܂��B
    /// </remarks>
    public abstract partial class UserSCMAcOdSetDtWrapper
    {
        ///// <summary>
        ///// �L�[�ɕϊ����܂��B
        ///// </summary>
        ///// <returns>�L�[</returns>
        ///// <see cref="ISCMOrderAnswerRecord"/>
        //public string ToKey()
        //{
        //    return SCMEntityUtil.GetAnswerRecordKey(this);
        //}

        ///// <summary>
        ///// SCM�󒍃f�[�^�̊֘A�L�[�ɕϊ����܂��B
        ///// </summary>
        ///// <returns>SCM�󒍃f�[�^�̊֘A�L�[</returns>
        ///// <see cref="ISCMOrderDetailRecord"/>
        //public string ToRelationKey()
        //{
        //    return SCMEntityUtil.GetRelationKey(this);
        //}


        ///// <summary>������Ƃ̊֘AGUID</summary>
        //private Guid _salesRelationId = Guid.NewGuid();
        ///// <summary>
        ///// ������Ƃ̊֘AGUID(������Ƃ̊֘A�t���ɗp���܂�)
        ///// </summary>
        ///// <remarks>�e�[�u�����C�A�E�g�ɂ͑��݂��܂���B</remarks>
        ///// <see cref="ISCMOrderAnswerRecord"/>
        //public Guid SalesRelationId
        //{
        //    get { return _salesRelationId; }
        //    set { _salesRelationId = value; }
        //}

        /// <summary>
        /// CSV�ɕϊ����܂��B
        /// </summary>
        /// <returns>CSV</returns>
        /// <see cref="ISCMAcOdSetDtRecord"/>
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
                csv.Append(SetPartsMkrCd).Append(SCMEntityUtil.COMMA);
                csv.Append(SetPartsNumber).Append(SCMEntityUtil.COMMA);
                csv.Append(SetPartsMainSubNo).Append(SCMEntityUtil.COMMA);
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
                csv.Append(ShelfNo).Append(SCMEntityUtil.COMMA);
                csv.Append(PMAcptAnOdrStatus).Append(SCMEntityUtil.COMMA);
                csv.Append(PMSalesSlipNum).Append(SCMEntityUtil.COMMA);
                csv.Append(PMSalesRowNo).Append(SCMEntityUtil.COMMA);
                // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                csv.Append(PmMainMngWarehouseCd).Append(SCMEntityUtil.COMMA);
                csv.Append(PmMainMngWarehouseName).Append(SCMEntityUtil.COMMA);
                csv.Append(PmMainMngShelfNo).Append(SCMEntityUtil.COMMA);
                csv.Append(PmMainMngPrsntCount).Append(SCMEntityUtil.COMMA);
                // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                csv.Append(PmWarehouseCd).Append(SCMEntityUtil.COMMA);
                csv.Append(PmWarehouseName).Append(SCMEntityUtil.COMMA);
                csv.Append(PmShelfNo);
                csv.Append(PmPrsntCount).Append(SCMEntityUtil.COMMA);
                // ADD 2013/05/09 SCM��Q��10470�Ή� ----------------------------------------->>>>>
                csv.Append(GoodsSpclInstruction).Append(SCMEntityUtil.COMMA);
                // ADD 2013/05/09 SCM��Q��10470�Ή� -----------------------------------------<<<<<
                // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� --------------------------------->>>>>
                csv.Append(MkrSuggestRtPric).Append(SCMEntityUtil.COMMA);
                csv.Append(OpenPriceDiv).Append(SCMEntityUtil.COMMA);
                // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� ---------------------------------<<<<<
                // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                csv.Append(AnsDeliDateDiv).Append(SCMEntityUtil.COMMA);
                // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ---------->>>>>>>>>>
                csv.Append(GoodsSpecialNtForFac).Append(SCMEntityUtil.COMMA);
                csv.Append(GoodsSpecialNtForCOw).Append(SCMEntityUtil.COMMA);
                csv.Append(PrmSetDtlName2ForFac).Append(SCMEntityUtil.COMMA);
                csv.Append(PrmSetDtlName2ForCOw).Append(SCMEntityUtil.COMMA);
                // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ----------<<<<<<<<<<
                // ADD 2015/02/27 SCM������ C������ʑΉ� -------------------------------->>>>>
                csv.Append(PrmSetDtlNo2).Append(SCMEntityUtil.COMMA);
                csv.Append(PrmSetDtlName2).Append(SCMEntityUtil.COMMA);
                csv.Append(StockStatusDiv).Append(SCMEntityUtil.COMMA);
                // ADD 2015/02/27 SCM������ C������ʑΉ� --------------------------------<<<<<

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
