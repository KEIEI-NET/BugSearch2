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

namespace Broadleaf.Application.UIData.WebDB
{
    using RecordType = Broadleaf.Application.UIData.ScmOdrData;

    /// <summary>
    /// Web-DB SCM�󔭒��f�[�^�̃��b�p�[�N���X�i�����j
    /// </summary>
    /// <remarks>
    /// ���񑩂̉ߕs����(���ISCMOrderHeaderRecord�̎���)���������܂��B
    /// </remarks>
    public abstract partial class WebSCMOrderHeaderWrapper
    {
        /// <summary>
        /// ��ƃR�[�h���擾�܂��͐ݒ肵�܂��B(��Web-DB�ɂ͑��݂��܂���)
        /// </summary>
        /// <remarks>
        /// �⍇�����ƃR�[�h���擾�܂��͐ݒ肵�܂��B
        /// </remarks>
        /// <see cref="ISCMOrderHeaderRecord"/>
        public string EnterpriseCode
        {
            get { return RealRecord.InqOtherEpCd; }
            set { RealRecord.InqOtherEpCd = value; }
        }

        /// <summary>���Ӑ�R�[�h</summary>
        private int _customerCode = -1;
        /// <summary>
        /// ���Ӑ�R�[�h���擾�܂��͐ݒ肵�܂��B(��Web-DB�ɂ͑��݂��܂���)
        /// </summary>
        /// <see cref="ISCMOrderHeaderRecord"/>
        public int CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// <summary>�󒍃X�e�[�^�X</summary>
        private int _acptAnOdrStatus;
        /// <summary>
        /// �󒍃X�e�[�^�X���擾�܂��͐ݒ肵�܂��B(��Web-DB�ɂ͑��݂��܂���)
        /// </summary>
        /// <remarks>10:����,20:��,30:����</remarks>
        /// <see cref="ISCMOrderHeaderRecord"/>
        public int AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// <summary>����`�[�ԍ�</summary>
        private string _salesSlipNum;
        /// <summary>
        /// ����`�[�ԍ����擾�܂��͐ݒ肵�܂��B(��Web-DB�ɂ͑��݂��܂���)
        /// </summary>
        /// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
        /// <see cref="ISCMOrderHeaderRecord"/>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// <summary>����`�[���v(�ō���)</summary>
        private long _salesTotalTaxInc;
        /// <summary>
        /// ����`�[���v(�ō���)���擾�܂��͐ݒ肵�܂��B(��Web-DB�ɂ͑��݂��܂���)
        /// </summary>
        /// <remarks>���㐳�����z+����l�����z�v(�Ŕ���)+������z����Ŋz</remarks>
        /// <see cref="ISCMOrderHeaderRecord"/>
        public long SalesTotalTaxInc
        {
            get { return _salesTotalTaxInc; }
            set { _salesTotalTaxInc = value; }
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
                csv.Append(LogicalDeleteCode).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOriginalEpCd.Trim()).Append(SCMEntityUtil.COMMA);//@@@@20230303
                csv.Append(InqOriginalSecCd).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOtherEpCd).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOtherSecCd).Append(SCMEntityUtil.COMMA);
                csv.Append(InquiryNumber).Append(SCMEntityUtil.COMMA);
                csv.Append(UpdateDate).Append(SCMEntityUtil.COMMA);
                csv.Append(UpdateTime).Append(SCMEntityUtil.COMMA);
                csv.Append(AnswerDivCd).Append(SCMEntityUtil.COMMA);
                csv.Append(JudgementDate).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOrdNote).Append(SCMEntityUtil.COMMA);
                csv.Append(InqEmployeeCd).Append(SCMEntityUtil.COMMA);
                csv.Append(InqEmployeeNm).Append(SCMEntityUtil.COMMA);
                csv.Append(AnsEmployeeCd).Append(SCMEntityUtil.COMMA);
                csv.Append(AnsEmployeeNm).Append(SCMEntityUtil.COMMA);
                csv.Append(InquiryDate).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOrdDivCd).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOrdAnsDivCd).Append(SCMEntityUtil.COMMA);
                csv.Append(ReceiveDateTime).Append(SCMEntityUtil.COMMA);
                // --- ADD 2013/06/24 Y.Wakita ---------->>>>>
                csv.Append(TabUseDiv).Append(SCMEntityUtil.COMMA);
                // --- ADD 2013/06/24 Y.Wakita ----------<<<<<
                // DEL 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ---------->>>>>
                //csv.Append(LatestDiscCode);
                // DEL 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ----------<<<<<
                // ADD 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ---------->>>>>
                csv.Append(LatestDiscCode).Append(SCMEntityUtil.COMMA);
                csv.Append(CancelDiv).Append(SCMEntityUtil.COMMA);
                // --- UPD m.suzuki 2011/05/23 ---------->>>>>
                // ADD 2013/05/24 SCM��Q��10537�Ή� ---------------------------------->>>>>
                csv.Append(CarMngCode).Append(SCMEntityUtil.COMMA);
                // ADD 2013/05/24 SCM��Q��10537�Ή� ----------------------------------<<<<<
                //csv.Append(CMTCooprtDiv);
                csv.Append( CMTCooprtDiv ).Append( SCMEntityUtil.COMMA );
                csv.Append( SfPmCprtInstSlipNo );
                // --- UPD m.suzuki 2011/05/23 ----------<<<<<
                // ADD 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ----------<<<<<
                csv.Append(AcceptOrOrderKind); // ADD 2011/08/10
            }
            return csv.ToString();
        }
    }
}
