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
// �� �� ��  2010/06/24  �C�����e : �u�񓚍쐬�敪�v���u0:�����v�̏ꍇ�A�uCMT�A�g�敪�v��ݒ肷��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018�@��� ���b
// �� �� ��  2011/05/23  �C�����e : �e�[�u�����C�A�E�g�ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : LDNS wangqx
// �� �� ��  2011/08/08  �C�����e : PCCUOE�����񓚑Ή�
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
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 30744 ���� ����q
// �� �� ��  2014/12/19  �C�����e : SCM������ PMNS�Ή� �����񓚕����̒ǉ�
//----------------------------------------------------------------------------//
using System;

using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.UIData
{
    using RecordType    = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork;
    using RecordTypeWeb = Broadleaf.Application.UIData.ScmOdrData;

    /// <summary>
    /// ���[�U�[DB SCM�󒍃f�[�^�̃��b�p�[�N���X�i���񑩁j
    /// </summary>
    public abstract partial class UserSCMOrderHeaderWrapper : ISCMOrderHeaderRecord
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
        protected UserSCMOrderHeaderWrapper() : this(new RecordType()) { }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="realRecord">�{���̃��R�[�h</param>
        protected UserSCMOrderHeaderWrapper(RecordType realRecord)
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

        #region <11.�⍇�����ƃR�[�h>

        /// <summary>�⍇�����ƃR�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public string InqOtherEpCd
        {
            get { return RealRecord.InqOtherEpCd; }
            set { RealRecord.InqOtherEpCd = value; }
        }

        #endregion </11.�⍇�����ƃR�[�h>

        #region <12.�⍇���拒�_�R�[�h>

        /// <summary>�⍇���拒�_�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public string InqOtherSecCd
        {
            get { return RealRecord.InqOtherSecCd; }
            set { RealRecord.InqOtherSecCd = value; }
        }

        #endregion </12.�⍇���拒�_�R�[�h>

        #region <13.�⍇���ԍ�>

        /// <summary>�⍇���ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        public long InquiryNumber
        {
            get { return RealRecord.InquiryNumber; }
            set { RealRecord.InquiryNumber = value; }
        }

        #endregion </13.�⍇���ԍ�>

        #region <14.���Ӑ�R�[�h>

        /// <summary>���Ӑ�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public int CustomerCode
        {
            get { return RealRecord.CustomerCode; }
            set { RealRecord.CustomerCode = value; }
        }

        #endregion </14.���Ӑ�R�[�h>

        #region <15.�X�V�N����>

        /// <summary>�X�V�N�������擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>YYYYMMDD</remarks>
        public DateTime UpdateDate
        {
            get { return RealRecord.UpdateDate; }
            set { RealRecord.UpdateDate = value; }
        }

        #endregion </15.�X�V�N����>

        #region <16.�X�V�����b�~���b>

        /// <summary>�X�V�����b�~���b���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>HHMMSSXXX</remarks>
        public int UpdateTime
        {
            get { return RealRecord.UpdateTime; }
            set { RealRecord.UpdateTime = value; }
        }

        #endregion </16.�X�V�����b�~���b>

        #region <17.�񓚋敪>

        /// <summary>�񓚋敪���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>0:�A�N�V�����Ȃ� 10:�ꕔ�� 20:�񓚊��� 30:���F 99:�L�����Z��</remarks>
        public int AnswerDivCd
        {
            get { return RealRecord.AnswerDivCd; }
            set { RealRecord.AnswerDivCd = value; }
        }

        #endregion </17.�񓚋敪>

        #region <18.�m���>

        ///// <summary>�m������擾�܂��͐ݒ肵�܂��B</summary>
        ///// <remarks>YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B</remarks>
        //public DateTime JudgementDate
        //{
        //    get { return RealRecord.JudgementDate; }
        //    set { RealRecord.JudgementDate = value; }
        //}

        #endregion </18.�m���>

        #region <19.�⍇���E�������l>

        /// <summary>�⍇���E�������l���擾�܂��͐ݒ肵�܂��B</summary>
        public string InqOrdNote
        {
            get { return RealRecord.InqOrdNote; }
            set { RealRecord.InqOrdNote = value; }
        }

        #endregion </19.�⍇���E�������l>

        #region <20.�Y�t�t�@�C��>

        /// <summary>�Y�t�t�@�C�����擾�܂��͐ݒ肵�܂��B</summary>
        public byte[] AppendingFile
        {
            get { return RealRecord.AppendingFile; }
            set { RealRecord.AppendingFile = value; }
        }

        #endregion </20.�Y�t�t�@�C��>

        #region <21.�Y�t�t�@�C����>

        /// <summary>�Y�t�t�@�C�������擾�܂��͐ݒ肵�܂��B</summary>
        public string AppendingFileNm
        {
            get { return RealRecord.AppendingFileNm; }
            set { RealRecord.AppendingFileNm = value; }
        }

        #endregion </21.�Y�t�t�@�C����>

        #region <22.�⍇���]�ƈ��R�[�h>

        /// <summary>�⍇���]�ƈ��R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>�⍇�������]�ƈ��R�[�h</remarks>
        public string InqEmployeeCd
        {
            get { return RealRecord.InqEmployeeCd; }
            set { RealRecord.InqEmployeeCd = value; }
        }

        #endregion </22.�⍇���]�ƈ��R�[�h>

        #region <23.�⍇���]�ƈ�����>

        /// <summary>�⍇���]�ƈ����̂��擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>�⍇�������]�ƈ�����</remarks>
        public string InqEmployeeNm
        {
            get { return RealRecord.InqEmployeeNm; }
            set { RealRecord.InqEmployeeNm = value; }
        }

        #endregion </23.�⍇���]�ƈ�����>

        #region <24.�񓚏]�ƈ��R�[�h>

        /// <summary>�񓚏]�ƈ��R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public string AnsEmployeeCd
        {
            get { return RealRecord.AnsEmployeeCd; }
            set { RealRecord.AnsEmployeeCd = value; }
        }

        #endregion </24.�񓚏]�ƈ��R�[�h>

        #region <25.�񓚏]�ƈ�����>

        /// <summary>�񓚏]�ƈ����̂��擾�܂��͐ݒ肵�܂��B</summary>
        public string AnsEmployeeNm
        {
            get { return RealRecord.AnsEmployeeNm; }
            set { RealRecord.AnsEmployeeNm = value; }
        }

        #endregion </25.�񓚏]�ƈ�����>

        #region <26.�⍇����>

        ///// <summary>�⍇�������擾�܂��͐ݒ肵�܂��B</summary>
        ///// <remarks>YYYYMMDD</remarks>
        //public DateTime InquiryDate
        //{
        //    get { return RealRecord.InquiryDate; }
        //    set { RealRecord.InquiryDate = value; }
        //}

        #endregion </26.�⍇����>

        #region <27.�󒍃X�e�[�^�X>

        /// <summary>�󒍃X�e�[�^�X���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>10:����,20:��,30:����</remarks>
        public int AcptAnOdrStatus
        {
            get { return RealRecord.AcptAnOdrStatus; }
            set { RealRecord.AcptAnOdrStatus = value; }
        }

        #endregion </27.�󒍃X�e�[�^�X>

        #region <28.����`�[�ԍ�>

        /// <summary>����`�[�ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
        public string SalesSlipNum
        {
            get { return RealRecord.SalesSlipNum; }
            set { RealRecord.SalesSlipNum = value; }
        }

        #endregion </28.����`�[�ԍ�>

        #region <29.����`�[���v�i�ō��݁j>

        /// <summary>����`�[���v�i�ō��݁j���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz</remarks>
        public long SalesTotalTaxInc
        {
            get { return RealRecord.SalesTotalTaxInc; }
            set { RealRecord.SalesTotalTaxInc = value; }
        }

        #endregion </29.����`�[���v�i�ō��݁j>

        #region <30.���㏬�v�i�Łj>

        /// <summary>���㏬�v�i�Łj���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>�l����̐Ŋz�i�O�ŕ��A���ŕ��̍��v�j</remarks>
        public long SalesSubtotalTax
        {
            get { return RealRecord.SalesSubtotalTax; }
            set { RealRecord.SalesSubtotalTax = value; }
        }

        #endregion </30.���㏬�v�i�Łj>

        #region <31.�⍇���E�������>

        /// <summary>�⍇���E������ʂ��擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>1:�⍇�� 2:����</remarks>
        public int InqOrdDivCd
        {
            get { return RealRecord.InqOrdDivCd; }
            set { RealRecord.InqOrdDivCd = value; }
        }

        #endregion </31.�⍇���E�������>

        #region <32.�┭�E�񓚎��>

        /// <summary>�┭�E�񓚎�ʂ��擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>1:�⍇���E���� 2:��</remarks>
        public int InqOrdAnsDivCd
        {
            get { return RealRecord.InqOrdAnsDivCd; }
            set { RealRecord.InqOrdAnsDivCd = value; }
        }

        #endregion </32.�┭�E�񓚎��>

        #region <33.��M����>

        ///// <summary>��M�������擾�܂��͐ݒ肵�܂��B</summary>
        ///// <remarks>�iDateTime:���x��100�i�m�b�j</remarks>
        //public DateTime ReceiveDateTime
        //{
        //    get { return RealRecord.ReceiveDateTime; }
        //    set { RealRecord.ReceiveDateTime = value; }
        //}

        #endregion </33.��M����>

        #region <34.�񓚍쐬�敪>

        /// <summary>�񓚍쐬�敪���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>0:����, 1:�蓮�iWeb�j, 2:�蓮�i���̑��j</remarks>
        // DEL 2010/06/24 �u�񓚍쐬�敪�v���u0:�����v�̏ꍇ�A�uCMT�A�g�敪�v��ݒ肷�� ---------->>>>>
        //public int AnswerCreateDiv
        //{
        //    get { return RealRecord.AnswerCreateDiv; }
        //    set { RealRecord.AnswerCreateDiv = value; }
        //}
        // DEL 2010/06/24 �u�񓚍쐬�敪�v���u0:�����v�̏ꍇ�A�uCMT�A�g�敪�v��ݒ肷�� ----------<<<<<
        // ADD 2010/06/24 �u�񓚍쐬�敪�v���u0:�����v�̏ꍇ�A�uCMT�A�g�敪�v��ݒ肷�� ---------->>>>>
        public virtual int AnswerCreateDiv
        {
            get { return RealRecord.AnswerCreateDiv; }
            set { RealRecord.AnswerCreateDiv = value; } // �Z�b�^�Łu36.CMT�A�g�敪�v���ݒ肷��̂ŁAUserSCMOrderHeaderRecord�N���X�ŃI�[�o�[���C�h
        }
        // ADD 2010/06/24 �u�񓚍쐬�敪�v���u0:�����v�̏ꍇ�A�uCMT�A�g�敪�v��ݒ肷�� ----------<<<<<

        #endregion </34.�񓚍쐬�敪>

        // 2010/05/26 Add >>>
        #region <35.�L�����Z���敪>

        /// <summary>�L�����Z���敪���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>0:�L�����Z���Ȃ� 1:�L�����Z������</remarks>
        public short CancelDiv
        {
            get { return RealRecord.CancelDiv; }
            set { RealRecord.CancelDiv = value; }
        }

        #endregion </35.�L�����Z���敪>

        #region <36.CMT�A�g�敪>

        /// <summary>CMT�A�g�敪���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>0:�A�g�Ȃ� 1:�A�g����</remarks>
        public short CMTCooprtDiv
        {
            get { return RealRecord.CMTCooprtDiv; }
            set { RealRecord.CMTCooprtDiv = value; }
        }

        #endregion </36.CMT�A�g�敪>
        // 2010/05/26 Add <<<

        // --- ADD m.suzuki 2011/05/23 ---------->>>>>
        /// <summary>
        /// SF-PM�A�g�w�����ԍ����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        public string SfPmCprtInstSlipNo
        {
            get { return RealRecord.SfPmCprtInstSlipNo; }
            set { RealRecord.SfPmCprtInstSlipNo = value; }
        }
        // --- ADD m.suzuki 2011/05/23 ----------<<<<<

        // --- ADD LDNS wangqx 2011/08/08 ---------->>>>>
        /// <summary>
        /// PM���݌ɐ�
        /// </summary>
        public double PmPrsntCount
        {
            get { return RealRecord.PmPrsntCount; }
            set { RealRecord.PmPrsntCount = value; }
        }
        
        /// <summary>
        /// �Z�b�g���i���[�J�[�R�[�h
        /// </summary>
        public int SetPartsMkrCd
        {
            get { return RealRecord.SetPartsMkrCd; }
            set { RealRecord.SetPartsMkrCd = value; }
        }

        /// <summary>
        /// �Z�b�g���i�ԍ�
        /// </summary>
        public string SetPartsNumber
        {
            get { return RealRecord.SetPartsNumber; }
            set { RealRecord.SetPartsNumber = value; }
        }

        
        /// <summary>
        /// �Z�b�g���i�e�q�ԍ�
        /// </summary>
        public int SetPartsMainSubNo
        {
            get { return RealRecord.SetPartsMainSubNo; }
            set { RealRecord.SetPartsMainSubNo = value; }
        }
        // --- ADD LDNS wangqx 2011/08/08 ----------<<<<<
        
        // ----- ADD 2011/08/10 ----- >>>>>
        /// <summary>
        /// �󔭒���ʂ��擾�܂��͐ݒ肵�܂��B
        /// </summary>
        public Int16 AcceptOrOrderKind
        {
            get { return RealRecord.AcceptOrOrderKind; }
            set { RealRecord.AcceptOrOrderKind = value; }
        }
        // ----- ADD 2011/08/10 ----- <<<<<

        // --- ADD 2013/06/24 Y.Wakita ---------->>>>>
        /// <summary>
        /// �^�u���b�g�g�p�敪
        /// </summary>
        public int TabUseDiv
        {
            get { return RealRecord.TabUseDiv; }
            set { RealRecord.TabUseDiv = value; }
        }
        // --- ADD 2013/06/24 Y.Wakita ----------<<<<<

        // ADD 2013/05/24 SCM��Q��10537�Ή� ---------------------------------->>>>>
        /// <summary>
        /// �ԗ��Ǘ��R�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        public string CarMngCode
        {
            get { return RealRecord.CarMngCode; }
            set { RealRecord.CarMngCode = value; }
        }
        // ADD 2013/05/24 SCM��Q��10537�Ή� ----------------------------------<<<<<

        // ADD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
        /// <summary>
        /// �����񓚕������擾�܂��͐ݒ肵�܂�
        /// </summary>
        public Int16 AutoAnsMthd
        {
            get { return RealRecord.AutoAnsMthd; }
            set { RealRecord.AutoAnsMthd = value; }
        }
        // ADD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<

        #endregion // </Automatic Code>
    }
}
