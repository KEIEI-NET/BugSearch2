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
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2010/05/26  �C�����e : �e�[�u�����C�A�E�g�ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2010/06/24  �C�����e : �u�񓚍쐬�敪�v���u0:�����v�̏ꍇ�A�uCMT�A�g�敪�v��ݒ肷��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018�@��� ���b
// �� �� ��  2011/05/23  �C�����e : �e�[�u�����C�A�E�g�ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/08/10  �C�����e : PCCUOE�����񓚑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2012/06/07  �C�����e : ��10285 WebDB�ւ̕ϊ����A���ړ��̓f�[�^�̐ݒ�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902175-00 �쐬�S�� : �e�c ���V
// �� �� ��  2013/06/24  �C�����e : �^�u���b�g�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/05/24  �C�����e : SCM��Q��10537�Ή� �ԗ��Ǘ��R�[�h�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902175-00 �쐬�S�� : �e�c ���V
// �� �� ��  2013/07/31  �C�����e : 2013/08/09�z�M �V�X�e���e�X�g��Q�ꗗ��15�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 30744 ���� ����q
// �� �� ��  2014/12/19  �C�����e : SCM������ PMNS�Ή� �����񓚕����̒ǉ�
//----------------------------------------------------------------------------//
using System;

using Broadleaf.Application.UIData.Util;
using Broadleaf.Application.UIData.WebDB;

namespace Broadleaf.Application.UIData
{
    using RecordType    = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork;
    using RecordTypeWeb = Broadleaf.Application.UIData.ScmOdrData;

    /// <summary>
    /// ���[�U�[DB SCM�󒍃f�[�^�̃��R�[�h�N���X
    /// </summary>
    public class UserSCMOrderHeaderRecord : UserSCMOrderHeaderWrapper
    {
        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public UserSCMOrderHeaderRecord() : base() { }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="realRecord">�{���̃��R�[�h</param>
        public UserSCMOrderHeaderRecord(RecordType realRecord) : base(realRecord) { }

        #endregion // </Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^(Web��User�ϊ��B���Ӑ擙�͕ʓr�ݒ肪�K�v)
        /// </summary>
        /// <param name="webRecord">SCM�󔭒��f�[�^</param>
        public UserSCMOrderHeaderRecord(WebSCMOrderHeaderRecord webRecord) : base(new RecordType())
        {
            RealRecord.CreateDateTime = webRecord.CreateDateTime; // �쐬����
            RealRecord.UpdateDateTime = webRecord.UpdateDateTime; // �X�V����
            RealRecord.EnterpriseCode = webRecord.EnterpriseCode; // ��ƃR�[�h
            //RealRecord.FileHeaderGuid = webRecord.FileHeaderGuid; // GUID
            //RealRecord.UpdEmployeeCode = webRecord.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            //RealRecord.UpdAssemblyId1 = webRecord.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            //RealRecord.UpdAssemblyId2 = webRecord.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            RealRecord.LogicalDeleteCode = webRecord.LogicalDeleteCode; // �_���폜�敪
            RealRecord.InqOriginalEpCd = webRecord.InqOriginalEpCd.Trim(); // �⍇������ƃR�[�h//@@@@20230303
            //RealRecord.InqOriginalEpNm = webRecord.InqOriginalEpNm; // �⍇������Ɩ���
            RealRecord.InqOriginalSecCd = webRecord.InqOriginalSecCd; // �⍇�������_�R�[�h
            //RealRecord.InqOriginalSecNm = webRecord.InqOriginalSecNm; // �⍇�������_����
            RealRecord.InqOtherEpCd = webRecord.InqOtherEpCd; // �⍇�����ƃR�[�h
            RealRecord.InqOtherSecCd = webRecord.InqOtherSecCd; // �⍇���拒�_�R�[�h
            RealRecord.InquiryNumber = webRecord.InquiryNumber; // �⍇���ԍ�
            RealRecord.CustomerCode = webRecord.CustomerCode; // ���Ӑ�R�[�h
            RealRecord.UpdateDate = webRecord.UpdateDate; // �X�V�N����
            RealRecord.UpdateTime = webRecord.UpdateTime; // �X�V�����b�~���b
            RealRecord.AnswerDivCd = webRecord.AnswerDivCd; // �񓚋敪

            RealRecord.JudgementDate = webRecord.JudgementDate; // �m���

            RealRecord.InqOrdNote = webRecord.InqOrdNote; // �⍇���E�������l
            //RealRecord.AppendingFile = webRecord.AppendingFile; // �Y�t�t�@�C��
            //RealRecord.AppendingFileNm = webRecord.AppendingFileNm; // �Y�t�t�@�C����
            RealRecord.InqEmployeeCd = webRecord.InqEmployeeCd; // �⍇���]�ƈ��R�[�h
            RealRecord.InqEmployeeNm = webRecord.InqEmployeeNm; // �⍇���]�ƈ�����
            RealRecord.AnsEmployeeCd = webRecord.AnsEmployeeCd; // �񓚏]�ƈ��R�[�h
            RealRecord.AnsEmployeeNm = webRecord.AnsEmployeeNm; // �񓚏]�ƈ�����

            RealRecord.InquiryDate = webRecord.InquiryDate; // �⍇����

            RealRecord.AcptAnOdrStatus = webRecord.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            RealRecord.SalesSlipNum = webRecord.SalesSlipNum; // ����`�[�ԍ�
            //RealRecord.SalesTotalTaxInc = webRecord.SalesTotalTaxInc; // ����`�[���v�i�ō��݁j
            //RealRecord.SalesSubtotalTax = webRecord.SalesSubtotalTax; // ���㏬�v�i�Łj
            RealRecord.InqOrdDivCd = webRecord.InqOrdDivCd; // �⍇���E�������
            RealRecord.InqOrdAnsDivCd = webRecord.InqOrdAnsDivCd; // �┭�E�񓚎��

            RealRecord.ReceiveDateTime = webRecord.ReceiveDateTime; // ��M����

            //RealRecord.AnswerCreateDiv = webRecord.AnswerCreateDiv; // �񓚍쐬�敪

            // 2010/05/26 Add >>>
            RealRecord.CancelDiv = webRecord.CancelDiv; // �L�����Z���敪
            RealRecord.CMTCooprtDiv = webRecord.CMTCooprtDiv; // CMT�A�g�敪
            // 2010/05/26 Add <<<
            // --- ADD m.suzuki 2011/05/23 ---------->>>>>
            RealRecord.SfPmCprtInstSlipNo = webRecord.SfPmCprtInstSlipNo; // SF-PM�A�g�w�����ԍ�
            // --- ADD m.suzuki 2011/05/23 ----------<<<<<
            RealRecord.AcceptOrOrderKind = webRecord.AcceptOrOrderKind; // �󔭒���� // ADD 2011/08/10
            // --- ADD 2013/06/24 Y.Wakita ---------->>>>>
            RealRecord.TabUseDiv = webRecord.TabUseDiv;  // �^�u���b�g�g�p�敪
            // --- ADD 2013/06/24 Y.Wakita ----------<<<<<
            // ADD 2013/05/24 SCM��Q��10537�Ή� ---------------------------------->>>>>
            RealRecord.CarMngCode = webRecord.CarMngCode; // �ԗ��Ǘ��R�[�h
            // ADD 2013/05/24 SCM��Q��10537�Ή� ----------------------------------<<<<<
            // ADD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
            RealRecord.AutoAnsMthd = webRecord.AutoAnsMthd; // �����񓚕���
            // ADD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<
        }

        /// <summary>
        /// �R�s�[�R���X�g���N�^
        /// </summary>
        /// <param name="other">�R�s�[��</param>
        public UserSCMOrderHeaderRecord(UserSCMOrderHeaderRecord other) : base()
        {
            if (other == null || other == this) return;

            RealRecord.EnterpriseCode = other.EnterpriseCode; // ��ƃR�[�h
            RealRecord.FileHeaderGuid = other.FileHeaderGuid; // GUID
            RealRecord.UpdEmployeeCode = other.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            RealRecord.UpdAssemblyId1 = other.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            RealRecord.UpdAssemblyId2 = other.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            RealRecord.LogicalDeleteCode = other.LogicalDeleteCode; // �_���폜�敪
            RealRecord.InqOriginalEpCd = other.InqOriginalEpCd.Trim(); // �⍇������ƃR�[�h//@@@@20230303
            //RealRecord.InqOriginalEpNm = other.InqOriginalEpNm; // �⍇������Ɩ���
            RealRecord.InqOriginalSecCd = other.InqOriginalSecCd; // �⍇�������_�R�[�h
            //RealRecord.InqOriginalSecNm = other.InqOriginalSecNm; // �⍇�������_����
            RealRecord.InqOtherEpCd = other.InqOtherEpCd; // �⍇�����ƃR�[�h
            RealRecord.InqOtherSecCd = other.InqOtherSecCd; // �⍇���拒�_�R�[�h
            RealRecord.InquiryNumber = other.InquiryNumber; // �⍇���ԍ�
            RealRecord.CustomerCode = other.CustomerCode; // ���Ӑ�R�[�h
            RealRecord.UpdateDate = other.UpdateDate; // �X�V�N����
            RealRecord.UpdateTime = other.UpdateTime; // �X�V�����b�~���b
            RealRecord.AnswerDivCd = other.AnswerDivCd; // �񓚋敪

            RealRecord.JudgementDate = other.JudgementDate; // �m���

            RealRecord.InqOrdNote = other.InqOrdNote; // �⍇���E�������l
            RealRecord.AppendingFile = other.AppendingFile; // �Y�t�t�@�C��
            RealRecord.AppendingFileNm = other.AppendingFileNm; // �Y�t�t�@�C����
            RealRecord.InqEmployeeCd = other.InqEmployeeCd; // �⍇���]�ƈ��R�[�h
            RealRecord.InqEmployeeNm = other.InqEmployeeNm; // �⍇���]�ƈ�����
            RealRecord.AnsEmployeeCd = other.AnsEmployeeCd; // �񓚏]�ƈ��R�[�h
            RealRecord.AnsEmployeeNm = other.AnsEmployeeNm; // �񓚏]�ƈ�����

            RealRecord.InquiryDate = other.InquiryDate; // �⍇����

            RealRecord.AcptAnOdrStatus = other.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            RealRecord.SalesSlipNum = other.SalesSlipNum; // ����`�[�ԍ�
            RealRecord.SalesTotalTaxInc = other.SalesTotalTaxInc; // ����`�[���v�i�ō��݁j
            RealRecord.SalesSubtotalTax = other.SalesSubtotalTax; // ���㏬�v�i�Łj
            RealRecord.InqOrdDivCd = other.InqOrdDivCd; // �⍇���E�������
            RealRecord.InqOrdAnsDivCd = other.InqOrdAnsDivCd; // �┭�E�񓚎��

            RealRecord.ReceiveDateTime = other.ReceiveDateTime; // ��M����

            RealRecord.AnswerCreateDiv = other.AnswerCreateDiv; // �񓚍쐬�敪

            // 2010/05/26 Add >>>
            RealRecord.CancelDiv = other.CancelDiv; // �L�����Z���敪
            RealRecord.CMTCooprtDiv = other.CMTCooprtDiv; // CMT�A�g�敪
            // 2010/05/26 Add <<<

            // --- ADD m.suzuki 2011/05/23 ---------->>>>>
            RealRecord.SfPmCprtInstSlipNo = other.SfPmCprtInstSlipNo; // SF-PM�A�g�w�����ԍ�
            // --- ADD m.suzuki 2011/05/23 ----------<<<<<
            RealRecord.AcceptOrOrderKind = other.AcceptOrOrderKind; // �󔭒���� // ADD 2011/08/10
            // --- ADD 2013/06/24 Y.Wakita ---------->>>>>
            RealRecord.TabUseDiv = other.TabUseDiv;  // �^�u���b�g�g�p�敪
            // --- ADD 2013/06/24 Y.Wakita ----------<<<<<
            // ADD 2013/05/24 SCM��Q��10537�Ή� ---------------------------------->>>>>
            RealRecord.CarMngCode = other.CarMngCode; // �ԗ��Ǘ��R�[�h
            // ADD 2013/05/24 SCM��Q��10537�Ή� ----------------------------------<<<<<
            // ADD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
            RealRecord.AutoAnsMthd = other.AutoAnsMthd; // �����񓚕���
            // ADD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<
        }

        #region <User��WEB�ϊ�>
        /// <summary>
        /// UserDB����WebDB�ւ̋l�ւ�����
        /// </summary>
        /// <returns>SCM�󔭒��f�[�^</returns>
        public WebSCMOrderHeaderRecord CopyToWebSCMOrderHeaderRecord()
        {
            RecordTypeWeb webRecord = new RecordTypeWeb();
            {
                //webRecord.EnterpriseCode = RealRecord.EnterpriseCode; // ��ƃR�[�h
                //webRecord.FileHeaderGuid = RealRecord.FileHeaderGuid; // GUID
                //webRecord.UpdEmployeeCode = RealRecord.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
                //webRecord.UpdAssemblyId1 = RealRecord.UpdAssemblyId1; // �X�V�A�Z���u��ID1
                //webRecord.UpdAssemblyId2 = RealRecord.UpdAssemblyId2; // �X�V�A�Z���u��ID2
                webRecord.LogicalDeleteCode = RealRecord.LogicalDeleteCode; // �_���폜�敪
                webRecord.InqOriginalEpCd = RealRecord.InqOriginalEpCd.Trim(); // �⍇������ƃR�[�h//@@@@20230303
                //webRecord.InqOriginalEpNm = RealRecord.InqOriginalEpNm; // �⍇������Ɩ���
                webRecord.InqOriginalSecCd = RealRecord.InqOriginalSecCd; // �⍇�������_�R�[�h
                //webRecord.InqOriginalSecNm = RealRecord.InqOriginalSecNm; // �⍇�������_����
                webRecord.InqOtherEpCd = RealRecord.InqOtherEpCd; // �⍇�����ƃR�[�h
                webRecord.InqOtherSecCd = RealRecord.InqOtherSecCd; // �⍇���拒�_�R�[�h
                webRecord.InquiryNumber = RealRecord.InquiryNumber; // �⍇���ԍ�
                //webRecord.CustomerCode = RealRecord.CustomerCode; // ���Ӑ�R�[�h
                webRecord.UpdateDate = RealRecord.UpdateDate; // �X�V�N����
                webRecord.UpdateTime = RealRecord.UpdateTime; // �X�V�����b�~���b
                webRecord.AnswerDivCd = RealRecord.AnswerDivCd; // �񓚋敪

                webRecord.JudgementDate = RealRecord.JudgementDate; // �m���

                webRecord.InqOrdNote = RealRecord.InqOrdNote; // �⍇���E�������l
                //webRecord.AppendingFile = RealRecord.AppendingFile; // �Y�t�t�@�C��
                //webRecord.AppendingFileNm = RealRecord.AppendingFileNm; // �Y�t�t�@�C����
                webRecord.InqEmployeeCd = RealRecord.InqEmployeeCd; // �⍇���]�ƈ��R�[�h
                webRecord.InqEmployeeNm = RealRecord.InqEmployeeNm; // �⍇���]�ƈ�����
                webRecord.AnsEmployeeCd = RealRecord.AnsEmployeeCd; // �񓚏]�ƈ��R�[�h
                webRecord.AnsEmployeeNm = RealRecord.AnsEmployeeNm; // �񓚏]�ƈ�����

                webRecord.InquiryDate = RealRecord.InquiryDate; // �⍇����

                //webRecord.AcptAnOdrStatus = RealRecord.AcptAnOdrStatus; // �󒍃X�e�[�^�X
                //webRecord.SalesSlipNum = RealRecord.SalesSlipNum; // ����`�[�ԍ�
                //webRecord.SalesTotalTaxInc = RealRecord.SalesTotalTaxInc; // ����`�[���v�i�ō��݁j
                //webRecord.SalesSubtotalTax = RealRecord.SalesSubtotalTax; // ���㏬�v�i�Łj
                webRecord.InqOrdDivCd = RealRecord.InqOrdDivCd; // �⍇���E�������
                webRecord.InqOrdAnsDivCd = RealRecord.InqOrdAnsDivCd; // �┭�E�񓚎��

                webRecord.ReceiveDateTime = RealRecord.ReceiveDateTime; // ��M����

                //webRecord.AnswerCreateDiv = RealRecord.AnswerCreateDiv; // �񓚍쐬�敪

                // 2010/05/26 Add >>>
                webRecord.CancelDiv = RealRecord.CancelDiv; // �L�����Z���敪
                webRecord.CMTCooprtDiv = RealRecord.CMTCooprtDiv; // CMT�A�g�敪
                // 2010/05/26 Add <<<

                // --- ADD m.suzuki 2011/05/23 ---------->>>>>
                webRecord.SfPmCprtInstSlipNo = RealRecord.SfPmCprtInstSlipNo; // SF-PM�A�g�w�����ԍ�
                // --- ADD m.suzuki 2011/05/23 ----------<<<<<
                webRecord.AcceptOrOrderKind = RealRecord.AcceptOrOrderKind; // �󔭒���� // ADD 2011/08/10
                // ADD 2012/06/07 --------------------------------------->>>>>
                webRecord.DataInputSystem = 10; // ���ڃf�[�^���̓V�X�e�� 10:PM
                // ADD 2012/06/07 ---------------------------------------<<<<<
                // --- UPD 2013/07/31 Y.Wakita ---------->>>>>
                //// --- ADD 2013/06/24 Y.Wakita ---------->>>>>
                //webRecord.TabUseDiv = webRecord.TabUseDiv;  // �^�u���b�g�g�p�敪
                //// --- ADD 2013/06/24 Y.Wakita ----------<<<<<
                webRecord.TabUseDiv = RealRecord.TabUseDiv; // �^�u���b�g�g�p�敪
                // --- UPD 2013/07/31 Y.Wakita ----------<<<<<
                // ADD 2013/05/24 SCM��Q��10537�Ή� ---------------------------------->>>>>
                webRecord.CarMngCode = RealRecord.CarMngCode; // �ԗ��Ǘ��R�[�h
                // ADD 2013/05/24 SCM��Q��10537�Ή� ----------------------------------<<<<<
                // ADD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
                webRecord.AutoAnsMthd = RealRecord.AutoAnsMthd; // �����񓚕���
                // ADD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<
            }
            return new WebSCMOrderHeaderRecord(webRecord);
        }
        #endregion

        // ADD 2010/06/24 �u�񓚍쐬�敪�v���u0:�����v�̏ꍇ�A�uCMT�A�g�敪�v��ݒ肷�� ---------->>>>>
        #region <34.�񓚍쐬�敪>

        /// <summary>�񓚍쐬�敪���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>0:����, 1:�蓮�iWeb�j, 2:�蓮�i���̑��j</remarks>
        public override int AnswerCreateDiv
        {
            get { return RealRecord.AnswerCreateDiv; }
            set
            {
                RealRecord.AnswerCreateDiv = value;
                if (RealRecord.AnswerCreateDiv.Equals((int)AnswerCreateDivValue.Auto))
                {
                    BackupCMTCooprtDiv = CMTCooprtDiv;

                    // �u�񓚍쐬�敪�v���u0:�����v
                    // �u�⍇�E������ʁv���u1:�⍇���v�̏ꍇ�A�uCMT�A�g�敪�v�́u11:�⍇��(����)�v
                    // �u�⍇�E������ʁv���u2:�����v�̏ꍇ�A�uCMT�A�g�敪�v�́u12:����(����)�v
                    RealRecord.CMTCooprtDiv = RealRecord.InqOrdDivCd.Equals((int)InqOrdDivCdValue.Ordering)
                        ?
                    (short)CMTCooprtDivValue.OrderedAutomatically : (short)CMTCooprtDivValue.MadeInquiriesAutomatically;
                }
                else
                {
                    // �u�񓚍쐬�敪�v���u0:�����v�ȊO�͌��ɖ߂�
                    if (BackupCMTCooprtDiv > 0)
                    {
                        RealRecord.CMTCooprtDiv = BackupCMTCooprtDiv;
                    }
                }
            }
        }

        /// <summary>CMT�A�g�敪�̃o�b�N�A�b�v</summary>
        private short _backupCMTCooprtDiv = -1;
        /// <summary>CMT�A�g�敪�̃o�b�N�A�b�v���擾�܂��͐ݒ肵�܂��B</summary>
        private short BackupCMTCooprtDiv
        {
            get { return _backupCMTCooprtDiv; }
            set { _backupCMTCooprtDiv = value; }
        }

        #endregion </34.�񓚍쐬�敪>
        // ADD 2010/06/24 �u�񓚍쐬�敪�v���u0:�����v�̏ꍇ�A�uCMT�A�g�敪�v��ݒ肷�� ----------<<<<<
    }
}
