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
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 30744 ���� ����q
// �� �� ��  2015/01/27  �C�����e : SCM������Redmine#39�Ή�
//----------------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.UIData.WebDB
{
    using RecordType = Broadleaf.Application.UIData.ScmOdrData;

    /// <summary>
    /// Web-DB SCM�󔭒��f�[�^�̃��b�p�[�N���X�i���񑩁j
    /// </summary>
    public abstract partial class WebSCMOrderHeaderWrapper : ISCMOrderHeaderRecord
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
        protected WebSCMOrderHeaderWrapper() : this(new RecordType()) { }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="realRecord">�{���̃��R�[�h</param>
        protected WebSCMOrderHeaderWrapper(RecordType realRecord)
        {
            _realRecord = realRecord;
        }

        #endregion // </Constructor>

        /// <summary>
        /// �f�B�[�v�R�s�[���s���܂��B
        /// </summary>
        /// <returns>�R�s�[�C���X�^���X</returns>
        public object Clone()
        {
            return RealRecord.Clone();
        }

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

        #region <03.�_���폜�敪>

        /// <summary>�_���폜�敪���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        public int LogicalDeleteCode
        {
            get { return RealRecord.LogicalDeleteCode; }
            set { RealRecord.LogicalDeleteCode = value; }
        }

        #endregion </03.�_���폜�敪>

        #region <04.�⍇������ƃR�[�h>

        /// <summary>�⍇������ƃR�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public string InqOriginalEpCd
        {
            get { return RealRecord.InqOriginalEpCd; }
            set { RealRecord.InqOriginalEpCd = value; }
        }

        #endregion </04.�⍇������ƃR�[�h>

        #region <05.�⍇�������_�R�[�h>

        /// <summary>�⍇�������_�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public string InqOriginalSecCd
        {
            get { return RealRecord.InqOriginalSecCd; }
            set { RealRecord.InqOriginalSecCd = value; }
        }

        #endregion </05.�⍇�������_�R�[�h>

        #region <06.�⍇�����ƃR�[�h>

        /// <summary>�⍇�����ƃR�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public string InqOtherEpCd
        {
            get { return RealRecord.InqOtherEpCd; }
            set { RealRecord.InqOtherEpCd = value; }
        }

        #endregion </06.�⍇�����ƃR�[�h>

        #region <07.�⍇���拒�_�R�[�h>

        /// <summary>�⍇���拒�_�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public string InqOtherSecCd
        {
            get { return RealRecord.InqOtherSecCd; }
            set { RealRecord.InqOtherSecCd = value; }
        }

        #endregion </07.�⍇���拒�_�R�[�h>

        #region <08.�⍇���ԍ�>

        /// <summary>�⍇���ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        public long InquiryNumber
        {
            get { return RealRecord.InquiryNumber; }
            set { RealRecord.InquiryNumber = value; }
        }

        #endregion </08.�⍇���ԍ�>

        #region <09.�X�V�N����>

        /// <summary>�X�V�N�������擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>YYYYMMDD</remarks>
        public DateTime UpdateDate
        {
            get { return RealRecord.UpdateDate; }
            set { RealRecord.UpdateDate = value; }
        }

        #endregion </09.�X�V�N����>

        #region <10.�X�V�����b�~���b>

        /// <summary>�X�V�����b�~���b���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>HHMMSSXXX</remarks>
        public int UpdateTime
        {
            get { return RealRecord.UpdateTime; }
            set { RealRecord.UpdateTime = value; }
        }

        #endregion </10.�X�V�����b�~���b>

        #region <11.�񓚋敪>

        /// <summary>�񓚋敪���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>0:�A�N�V�����Ȃ� 1:�񓚒� 10:�ꕔ�� 20:�񓚊��� 30:���F 99:�L�����Z��</remarks>
        public int AnswerDivCd
        {
            get { return RealRecord.AnswerDivCd; }
            set { RealRecord.AnswerDivCd = value; }
        }

        #endregion </11.�񓚋敪>

        #region <12.�m���>

        /// <summary>�m������擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B</remarks>
        public DateTime JudgementDate
        {
            get { return RealRecord.JudgementDate; }
            set { RealRecord.JudgementDate = value; }
        }

        #endregion </12.�m���>

        #region <13.�⍇���E�������l>

        /// <summary>�⍇���E�������l���擾�܂��͐ݒ肵�܂��B</summary>
        public string InqOrdNote
        {
            get { return RealRecord.InqOrdNote; }
            set { RealRecord.InqOrdNote = value; }
        }

        #endregion </13.�⍇���E�������l>

        #region <14.�⍇���]�ƈ��R�[�h>

        /// <summary>�⍇���]�ƈ��R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>�⍇�������]�ƈ��R�[�h</remarks>
        public string InqEmployeeCd
        {
            get { return RealRecord.InqEmployeeCd; }
            set { RealRecord.InqEmployeeCd = value; }
        }

        #endregion </14.�⍇���]�ƈ��R�[�h>

        #region <15.�⍇���]�ƈ�����>

        /// <summary>�⍇���]�ƈ����̂��擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>�⍇�������]�ƈ�����</remarks>
        public string InqEmployeeNm
        {
            get { return RealRecord.InqEmployeeNm; }
            set { RealRecord.InqEmployeeNm = value; }
        }

        #endregion </15.�⍇���]�ƈ�����>

        #region <16.�񓚏]�ƈ��R�[�h>

        /// <summary>�񓚏]�ƈ��R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public string AnsEmployeeCd
        {
            get { return RealRecord.AnsEmployeeCd; }
            set { RealRecord.AnsEmployeeCd = value; }
        }

        #endregion </16.�񓚏]�ƈ��R�[�h>

        #region <17.�񓚏]�ƈ�����>

        /// <summary>�񓚏]�ƈ����̂��擾�܂��͐ݒ肵�܂��B</summary>
        public string AnsEmployeeNm
        {
            get { return RealRecord.AnsEmployeeNm; }
            set { RealRecord.AnsEmployeeNm = value; }
        }

        #endregion </17.�񓚏]�ƈ�����>

        #region <18.�⍇����>

        /// <summary>�⍇�������擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>YYYYMMDD</remarks>
        public DateTime InquiryDate
        {
            get { return RealRecord.InquiryDate; }
            set { RealRecord.InquiryDate = value; }
        }

        #endregion </18.�⍇����>

        #region <19.�⍇���E�������>

        /// <summary>�⍇���E������ʂ��擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>1:�⍇�� 2:����</remarks>
        public int InqOrdDivCd
        {
            get { return RealRecord.InqOrdDivCd; }
            set { RealRecord.InqOrdDivCd = value; }
        }

        #endregion </19.�⍇���E�������>

        #region <20.�┭�E�񓚎��>

        /// <summary>�┭�E�񓚎�ʂ��擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>1:�⍇���E���� 2:��</remarks>
        public int InqOrdAnsDivCd
        {
            get { return RealRecord.InqOrdAnsDivCd; }
            set { RealRecord.InqOrdAnsDivCd = value; }
        }

        #endregion </20.�┭�E�񓚎��>

        #region <21.��M����>

        /// <summary>��M�������擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>�iDateTime:���x��100�i�m�b�j</remarks>
        public DateTime ReceiveDateTime
        {
            get { return RealRecord.ReceiveDateTime; }
            set { RealRecord.ReceiveDateTime = value; }
        }

        #endregion </21.��M����>

        #region <22.�ŐV���ʋ敪>

        /// <summary>�ŐV���ʋ敪���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>0:�ŐV�f�[�^ 1:���f�[�^</remarks>
        public short LatestDiscCode
        {
            get { return RealRecord.LatestDiscCode; }
            set { RealRecord.LatestDiscCode = value; }
        }

        #endregion </22.�ŐV���ʋ敪>

        // 2010/05/26 Add >>>
        #region <23.�L�����Z���敪>

        /// <summary>�L�����Z���敪���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>0:�L�����Z���Ȃ� 1:�L�����Z������</remarks>
        public short CancelDiv
        {
            get { return RealRecord.CancelDiv; }
            set { RealRecord.CancelDiv = value; }
        }

        #endregion </23.�L�����Z���敪>

        #region <24.CMT�A�g�敪>

        /// <summary>CMT�A�g�敪���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>0:�A�g�Ȃ� 1:�A�g����</remarks>
        public short CMTCooprtDiv
        {
            get { return RealRecord.CMTCooprtDiv; }
            set { RealRecord.CMTCooprtDiv = value; }
        }

        #endregion </24.CMT�A�g�敪>
        // 2010/05/26 Add <<<

        // ADD 2010/06/30 �u�񓚍쐬�敪�v��ǉ� ---------->>>>>
        private int _answerCreateDiv;
        /// <summary>
        /// �񓚍쐬�敪���擾�܂��͐ݒ肵�܂��B
        /// �i�{����SCM�󔭒��f�[�^�ɂ͑��݂��܂���j
        /// </summary>
        public int AnswerCreateDiv
        {
            get { return _answerCreateDiv; }
            set { _answerCreateDiv = value; }
        }
        // ADD 2010/06/30 �u�񓚍쐬�敪�v��ǉ� ----------<<<<<

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

        // ----- 2011/08/10 ----- >>>>>
        /// public propaty name  :  AcceptOrOrderKind
        /// <summary>�󔭒���ʃv���p�e�B</summary>
        /// <value>0:�ʏ�,1:PCC-UOE</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󔭒���ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 AcceptOrOrderKind
        {
            get { return RealRecord.AcceptOrOrderKind; }
            set { RealRecord.AcceptOrOrderKind = value; }
        }
        // ----- 2011/08/10 ----- <<<<<

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
        /// public propaty name  :  CarMngCode
        /// <summary>�ԗ��Ǘ��R�[�h</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ��Ǘ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CarMngCode
        {
            get { return RealRecord.CarMngCode; }
            set { RealRecord.CarMngCode = value; }
        }
        // ADD 2013/05/24 SCM��Q��10537�Ή� ----------------------------------<<<<<

        // ADD 2015/01/27 SCM������Redmine#39�Ή� --------------------------------->>>>>
        /// <summary>
        /// �����񓚕������擾�܂��͐ݒ肵�܂��B
        /// </summary>
        /// <see cref="ISCMOrderHeaderRecord"/>
        public Int16 AutoAnsMthd
        {
            get { return RealRecord.AutoAnsMthd; }
            set { RealRecord.AutoAnsMthd = value; }
        }
        // ADD 2015/01/27 SCM������Redmine#39�Ή� ---------------------------------<<<<<
	
        #endregion // </Automatic Code>
    }
}
