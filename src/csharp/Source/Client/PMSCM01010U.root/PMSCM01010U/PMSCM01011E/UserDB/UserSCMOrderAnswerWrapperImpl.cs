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
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2010/05/26  �C�����e : �e�[�u�����C�A�E�g�ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2010/06/17  �C�����e : �e�[�u���̃��C�A�E�g�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018�@��� ���b
// �� �� ��  2011/05/23  �C�����e : �e�[�u�����C�A�E�g�ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10900690-00 �쐬�S�� : qijh
// �� �� ��  2013/02/27  �C�����e : �z�M���Ȃ��� Redmine#34752 PM��Ǒq�ɏ���ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11470007-00 �쐬�S�� : �c����
// �C �� ��  2018/04/16  �C�����e : SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�
//----------------------------------------------------------------------------//
using System;
using System.Text;

using Broadleaf.Application.UIData.Util;
using Broadleaf.Library.Text;   // 2010/05/26 Add

namespace Broadleaf.Application.UIData
{
    using RecordType    = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlAsWork;
    using RecordTypeWeb = Broadleaf.Application.UIData.ScmOdDtAns;

    /// <summary>
    /// ���[�U�[DB SCM�󒍖��׃f�[�^(��)�̃��b�p�[�N���X�i�����j
    /// </summary>
    /// <remarks>
    /// ���񑩂̉ߕs����(���ISCMOrderAnswerRecord�̎���)���������܂��B
    /// </remarks>
    public abstract partial class UserSCMOrderAnswerWrapper
    {
        // 2010/05/26 Add >>>
        /// <summary>
        /// PM�󒍃X�e�[�^�X���擾�܂��͐ݒ肵�܂��B(��USER-DB��̎󒍃X�e�[�^�X�Ɠ���)
        /// </summary>
        /// <remarks>10:����,20:��,30:����</remarks>
        /// <see cref="ISCMOrderDetailRecord"/>
        public int PMAcptAnOdrStatus
        {
            get { return RealRecord.AcptAnOdrStatus; }
            set { RealRecord.AcptAnOdrStatus = value; }
        }

        /// <summary>
        /// PM����`�[�ԍ����擾�܂��͐ݒ肵�܂��B(��USER-DB��̔���`�[�ԍ����Ɠ���)
        /// </summary>
        /// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
        /// <see cref="ISCMOrderDetailRecord"/>
        public int PMSalesSlipNum
        {
            get { return TStrConv.StrToIntDef(RealRecord.SalesSlipNum.Trim(), 0); }
            set { RealRecord.SalesSlipNum = string.Format("{0:D9}", value); }
        }

        /// <summary>
        /// PM����s�ԍ����擾�܂��͐ݒ肵�܂��B(��USER-DB��̔���s�ԍ��Ɠ���)
        /// </summary>
        /// <see cref="ISCMOrderDetailRecord"/>
        public int PMSalesRowNo
        {
            get { return RealRecord.SalesRowNo; }
            set { RealRecord.SalesRowNo = value; }
        }
        // 2010/05/26 Add <<<

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
        /// <see cref="ISCMOrderAnswerRecord"/>
        public string ToKey()
        {
            return SCMEntityUtil.GetAnswerRecordKey(this);
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

        /// <summary>������Ƃ̊֘AGUID</summary>
        private Guid _salesRelationId = Guid.NewGuid();
        /// <summary>
        /// ������Ƃ̊֘AGUID(������Ƃ̊֘A�t���ɗp���܂�)
        /// </summary>
        /// <remarks>�e�[�u�����C�A�E�g�ɂ͑��݂��܂���B</remarks>
        /// <see cref="ISCMOrderAnswerRecord"/>
        public Guid SalesRelationId
        {
            get { return _salesRelationId; }
            set { _salesRelationId = value; }
        }

        /// <summary>
        /// CSV�ɕϊ����܂��B
        /// </summary>
        /// <returns>CSV</returns>
        /// <see cref="ISCMOrderAnswerRecord"/>
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
                csv.Append(AcptAnOdrStatus).Append(SCMEntityUtil.COMMA);
                csv.Append(SalesSlipNum).Append(SCMEntityUtil.COMMA);
                csv.Append(SalesRowNo).Append(SCMEntityUtil.COMMA);
                csv.Append(CampaignCode).Append(SCMEntityUtil.COMMA);
                csv.Append(StockDiv).Append(SCMEntityUtil.COMMA);
                // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                csv.Append(PmMainMngWarehouseCd).Append(SCMEntityUtil.COMMA);
                csv.Append(PmMainMngWarehouseName).Append(SCMEntityUtil.COMMA);
                csv.Append(PmMainMngShelfNo).Append(SCMEntityUtil.COMMA);
                csv.Append(PmMainMngPrsntCount).Append(SCMEntityUtil.COMMA);
                // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                csv.Append(InqOrdDivCd).Append(SCMEntityUtil.COMMA);
                csv.Append(DisplayOrder).Append(SCMEntityUtil.COMMA);
                // DEL 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ---------->>>>>
                //csv.Append(GoodsMngNo);
                // DEL 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ----------<<<<<
                // ADD 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ---------->>>>>
                csv.Append(GoodsMngNo).Append(SCMEntityUtil.COMMA);
                // --- UPD m.suzuki 2011/05/23 ---------->>>>>
                //csv.Append(CancelCndtinDiv);
                csv.Append( CancelCndtinDiv ).Append( SCMEntityUtil.COMMA );
                csv.Append( PMAcptAnOdrStatus ).Append( SCMEntityUtil.COMMA );
                csv.Append( PMSalesSlipNum ).Append( SCMEntityUtil.COMMA );
                csv.Append( PMSalesRowNo ).Append( SCMEntityUtil.COMMA );
                csv.Append( DtlTakeinDivCd ).Append( SCMEntityUtil.COMMA );
                csv.Append( PmWarehouseCd ).Append( SCMEntityUtil.COMMA );
                csv.Append( PmWarehouseName ).Append( SCMEntityUtil.COMMA );
                csv.Append( PmShelfNo );
                // --- UPD m.suzuki 2011/05/23 ----------<<<<<
                // ADD 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ----------<<<<<
                csv.Append(CampaignCode).Append(SCMEntityUtil.COMMA); // ADD 2011/10/10
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
