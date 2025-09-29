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
// �� �� ��  2010/06/17  �C�����e : �e�[�u���̃��C�A�E�g�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018�@��� ���b
// �� �� ��  2011/05/23  �C�����e : �e�[�u�����C�A�E�g�ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/08/10  �C�����e : PCCUOE�����񓚑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902175-00 �쐬�S�� : �e�c ���V
// �� �� ��  2013/06/24  �C�����e : �^�u���b�g�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/05/24  �C�����e : SCM��Q��10537�Ή� �ԗ��Ǘ��R�[�h�ǉ�
//----------------------------------------------------------------------------//
using System;
using System.Text;

using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.UIData
{
    using RecordType    = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork;
    using RecordTypeWeb = Broadleaf.Application.UIData.ScmOdrData;

    /// <summary>
    /// ���[�U�[DB SCM�󒍃f�[�^�̃��b�p�[�N���X�i�����j
    /// </summary>
    /// <remarks>
    /// ���񑩂̉ߕs����(���ISCMOrderHeaderRecord�̎���)���������܂��B
    /// </remarks>
    public abstract partial class UserSCMOrderHeaderWrapper
    {
        /// <summary>�m������擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B</remarks>
        /// <see cref="ISCMOrderHeaderRecord"/>
        public DateTime JudgementDate
        {
            get { return RealRecord.JudgementDate; }
            set { RealRecord.JudgementDate = value; }
        }

        /// <summary>�⍇�������擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>YYYYMMDD</remarks>
        /// <see cref="ISCMOrderHeaderRecord"/>
        public DateTime InquiryDate
        {
            get { return RealRecord.InquiryDate; }
            set { RealRecord.InquiryDate = value; }
        }

        /// <summary>��M�������擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>�iDateTime:���x��100�i�m�b�j</remarks>
        /// <see cref="ISCMOrderHeaderRecord"/>
        public DateTime ReceiveDateTime
        {
            get { return RealRecord.ReceiveDateTime; }
            set { RealRecord.ReceiveDateTime = value; }
        }

        /// <summary>
        /// �L�[�ɕϊ����܂��B
        /// </summary>
        /// <returns>�L�[</returns>
        /// <see cref="ISCMOrderHeaderRecord"/>
        public string ToKey()
        {
            return SCMEntityUtil.GetHeaderRecordKey(this);
        }

        /// <summary>
        /// SCM�󒍃f�[�^�̊֘A�L�[�ɕϊ����܂��B
        /// </summary>
        /// <returns>SCM�󒍃f�[�^�̊֘A�L�[</returns>
        /// <see cref="ISCMOrderHeaderRecord"/>
        public string ToRelationKey()
        {
            return SCMEntityUtil.GetRelationKey(this);
        }

        /// <summary>
        /// CSV�ɕϊ����܂��B
        /// </summary>
        /// <returns>CSV</returns>
        /// <see cref="ISCMOrderHeaderRecord"/>
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
                csv.Append(CustomerCode).Append(SCMEntityUtil.COMMA);
                csv.Append(UpdateDate).Append(SCMEntityUtil.COMMA);
                csv.Append(UpdateTime).Append(SCMEntityUtil.COMMA);
                csv.Append(AnswerDivCd).Append(SCMEntityUtil.COMMA);
                csv.Append(JudgementDate).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOrdNote).Append(SCMEntityUtil.COMMA);
                csv.Append(AppendingFile).Append(SCMEntityUtil.COMMA);
                csv.Append(AppendingFileNm).Append(SCMEntityUtil.COMMA);
                csv.Append(InqEmployeeCd).Append(SCMEntityUtil.COMMA);
                csv.Append(InqEmployeeNm).Append(SCMEntityUtil.COMMA);
                csv.Append(AnsEmployeeCd).Append(SCMEntityUtil.COMMA);
                csv.Append(AnsEmployeeNm).Append(SCMEntityUtil.COMMA);
                csv.Append(InquiryDate).Append(SCMEntityUtil.COMMA);
                csv.Append(AcptAnOdrStatus).Append(SCMEntityUtil.COMMA);
                csv.Append(SalesSlipNum).Append(SCMEntityUtil.COMMA);
                csv.Append(SalesTotalTaxInc).Append(SCMEntityUtil.COMMA);
                csv.Append(SalesSubtotalTax).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOrdDivCd).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOrdAnsDivCd).Append(SCMEntityUtil.COMMA);
                csv.Append(ReceiveDateTime).Append(SCMEntityUtil.COMMA);
                // --- ADD 2013/06/24 Y.Wakita ---------->>>>>
                csv.Append(TabUseDiv).Append(SCMEntityUtil.COMMA);
                // --- ADD 2013/06/24 Y.Wakita ----------<<<<<
                // DEL 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ---------->>>>>
                //csv.Append(AnswerCreateDiv);
                // DEL 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ----------<<<<<
                // ADD 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ---------->>>>>
                csv.Append(AnswerCreateDiv).Append(SCMEntityUtil.COMMA);
                csv.Append(CancelDiv).Append(SCMEntityUtil.COMMA);
                // --- UPD m.suzuki 2011/05/23 ---------->>>>>
                //csv.Append(CMTCooprtDiv);
                csv.Append( CMTCooprtDiv ).Append( SCMEntityUtil.COMMA );
                //csv.Append( SfPmCprtInstSlipNo ); // DEL 2011/08/10
                // --- UPD m.suzuki 2011/05/23 ----------<<<<<
                // ADD 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ----------<<<<<
                // ADD 2013/05/24 SCM��Q��10537�Ή� ---------------------------------->>>>>
                csv.Append(CarMngCode).Append(SCMEntityUtil.COMMA);
                // ADD 2013/05/24 SCM��Q��10537�Ή� ----------------------------------<<<<<
                csv.Append( SfPmCprtInstSlipNo ).Append(SCMEntityUtil.COMMA); // ADD 2011/08/10
                csv.Append(AcceptOrOrderKind); // ADD 2011/08/10

            }
            return csv.ToString();
        }
    }
}
