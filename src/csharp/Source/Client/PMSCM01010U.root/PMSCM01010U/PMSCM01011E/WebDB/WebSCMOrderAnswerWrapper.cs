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
// �� �� ��  2010/05/26  �C�����e :�e�[�u�����C�A�E�g�ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2011/02/09  �C�����e :�e�[�u�����C�A�E�g�ύX�Ή�(���׎捞�敪�̒ǉ�)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018�@��� ���b
// �� �� ��  2011/05/23  �C�����e : �e�[�u�����C�A�E�g�ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : LDNS�@wangqx
// �� �� ��  2011/08/08  �C�����e : �e�[�u�����C�A�E�g�ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10800003-00 �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  2012/01/16  �C�����e : SCM���ǑΉ��E���L�����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : 30745 �g�� �F��
// �� �� ��  2012/04/12  �C�����e : ��Q��170 PS�Ǘ��ԍ����ڒǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : 20073 �� �B
// �� �� ��  2012/05/30  �C�����e : SCM���ǑΉ��E�������ϕ��i�R�[�h
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : 30745 �g��
// �� �� ��  2013/05/08  �C�����e : 2013/06/18�z�M�@SCM��Q��10308,��10528
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : 30745 �g��
// �� �� ��  2013/05/15  �C�����e : 2013/06/18�z�M�@SCM��Q��10410
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �C �� ��  2014/06/04  �C�����e : SCM�d�|�ꗗ��10659�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 30744 ���� ����q
// �C �� ��  2014/12/19  �C�����e : SCM������ PMNS�Ή� ���ڒǉ��@�ݏo�敪�A���[�J�[��]�������i�A�I�[�v�����i�敪
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 31065 �L�� ���O
// �C �� ��  2015/01/19  �C�����e : ���R�����h�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 30744 ���� ����q
// �C �� ��  2015/01/30  �C�����e : SCM������ ���Y�N���A�ԑ�ԍ��Ή��@���ڒǉ��@�^���ʕ��i�̗p�N���A�^���ʕ��i�p�~�N���A�^���ʕ��i�̗p�ԑ�ԍ��A�^���ʕ��i�p�~�ԑ�ԍ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 30745 �g��
// �C �� ��  2015/02/10  �C�����e : SCM������ �񓚔[���敪�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 30746 ���� ��
// �C �� ��  2015/02/20  �C�����e : SCM������ C������ʁE���L�����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11470007-00 �쐬�S�� : �c����
// �C �� ��  2018/04/16  �C�����e : SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.UIData.Util; // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή�

namespace Broadleaf.Application.UIData.WebDB
{
    using RecordType = Broadleaf.Application.UIData.ScmOdDtAns;

    /// <summary>
    /// Web-DB SCM�󒍖��׃f�[�^(��)�̃��b�p�[�N���X�i���񑩁j
    /// </summary>
    /// <remarks>
    /// <br>Update Note      :   2018/04/16 �c����</br>
    /// <br>�Ǘ��ԍ�         :   11470007-00</br>
    /// <br>                 :   SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�</br>
    /// </remarks>
    public abstract partial class WebSCMOrderAnswerWrapper : ISCMOrderAnswerRecord
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
        protected WebSCMOrderAnswerWrapper() : this(new RecordType()) { }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="realRecord">�{���̃��R�[�h</param>
        protected WebSCMOrderAnswerWrapper(RecordType realRecord)
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

        #region <11.�⍇���s�ԍ�>

        /// <summary>�⍇���s�ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        public int InqRowNumber
        {
            get { return RealRecord.InqRowNumber; }
            set { RealRecord.InqRowNumber = value; }
        }

        #endregion </11.�⍇���s�ԍ�>

        #region <12.�⍇���s�ԍ��}��>

        /// <summary>�⍇���s�ԍ��}�Ԃ��擾�܂��͐ݒ肵�܂��B</summary>
        public int InqRowNumDerivedNo
        {
            get { return RealRecord.InqRowNumDerivedNo; }
            set { RealRecord.InqRowNumDerivedNo = value; }
        }

        #endregion </12.�⍇���s�ԍ��}��>

        #region <13.�⍇�������׎���GUID>

        /// <summary>�⍇�������׎���GUID���擾�܂��͐ݒ肵�܂��B</summary>
        public Guid InqOrgDtlDiscGuid
        {
            get { return RealRecord.InqOrgDtlDiscGuid; }
            set { RealRecord.InqOrgDtlDiscGuid = value; }
        }

        #endregion </13.�⍇�������׎���GUID>

        #region <14.�⍇���斾�׎���GUID>

        /// <summary>�⍇���斾�׎���GUID���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>�񓚃f�[�^�̏ꍇ�L���A�⍇���^�������̖���GUID��ݒ�</remarks>
        public Guid InqOthDtlDiscGuid
        {
            get { return RealRecord.InqOthDtlDiscGuid; }
            set { RealRecord.InqOthDtlDiscGuid = value; }
        }

        #endregion </14.�⍇���斾�׎���GUID>

        #region <15.���i���>

        /// <summary>���i��ʂ��擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>0:�������i 1:�D�Ǖ��i 2:���T�C�N�����i 3:���ϑ���</remarks>
        public int GoodsDivCd
        {
            get { return RealRecord.GoodsDivCd; }
            set { RealRecord.GoodsDivCd = value; }
        }

        #endregion </15.���i���>

        #region <16.���T�C�N�����i���>

        /// <summary>���T�C�N�����i��ʂ��擾�܂��͐ݒ肵�܂��B</summary>
        public int RecyclePrtKindCode
        {
            get { return RealRecord.RecyclePrtKindCode; }
            set { RealRecord.RecyclePrtKindCode = value; }
        }

        #endregion </16.���T�C�N�����i���>

        #region <17.���T�C�N�����i��ʖ���>

        /// <summary>���T�C�N�����i��ʖ��̂��擾�܂��͐ݒ肵�܂��B</summary>
        public string RecyclePrtKindName
        {
            get { return RealRecord.RecyclePrtKindName; }
            set { RealRecord.RecyclePrtKindName = value; }
        }

        #endregion </17.���T�C�N�����i��ʖ���>

        #region <18.�[�i�敪>

        /// <summary>�[�i�敪���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>0:�z��,1:����</remarks>
        public int DeliveredGoodsDiv
        {
            get { return RealRecord.DeliveredGoodsDiv; }
            set { RealRecord.DeliveredGoodsDiv = value; }
        }

        #endregion </18.�[�i�敪>

        #region <19.�戵�敪>

        /// <summary>�戵�敪���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>0:��舵���i,1:�[���m�F��,2:����舵���i</remarks>
        public int HandleDivCode
        {
            get { return RealRecord.HandleDivCode; }
            set { RealRecord.HandleDivCode = value; }
        }

        #endregion </19.�戵�敪>

        #region <20.���i�`��>

        /// <summary>���i�`�Ԃ��擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>1:���i,2:�p�i</remarks>
        public int GoodsShape
        {
            get { return RealRecord.GoodsShape; }
            set { RealRecord.GoodsShape = value; }
        }

        #endregion </20.���i�`��>

        #region <21.�[�i�m�F�敪>

        /// <summary>�[�i�m�F�敪���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>0:���m�F,1:�m�F</remarks>
        public int DelivrdGdsConfCd
        {
            get { return RealRecord.DelivrdGdsConfCd; }
            set { RealRecord.DelivrdGdsConfCd = value; }
        }

        #endregion </21.�[�i�m�F�敪>

        #region <22.�[�i�����\���>

        /// <summary>�[�i�����\������擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>�[�i�\����t YYYYMMDD</remarks>
        public DateTime DeliGdsCmpltDueDate
        {
            get { return RealRecord.DeliGdsCmpltDueDate; }
            set { RealRecord.DeliGdsCmpltDueDate = value; }
        }

        #endregion </22.�[�i�����\���>

        #region <23.�񓚔[��>

        /// <summary>�񓚔[�����擾�܂��͐ݒ肵�܂��B</summary>
        public string AnswerDeliveryDate
        {
            get { return RealRecord.AnswerDeliveryDate; }
            set { RealRecord.AnswerDeliveryDate = value; }
        }

        #endregion </23.�񓚔[��>

        #region <24.BL���i�R�[�h>

        /// <summary>BL���i�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public int BLGoodsCode
        {
            get { return RealRecord.BLGoodsCode; }
            set { RealRecord.BLGoodsCode = value; }
        }

        #endregion </24.BL���i�R�[�h>

        #region <25.BL���i�R�[�h�}��>

        /// <summary>BL���i�R�[�h�}�Ԃ��擾�܂��͐ݒ肵�܂��B</summary>
        public int BLGoodsDrCode
        {
            get { return RealRecord.BLGoodsDrCode; }
            set { RealRecord.BLGoodsDrCode = value; }
        }

        #endregion </25.BL���i�R�[�h�}��>

        #region <26.�┭���i��>

        /// <summary>�┭���i�����擾�܂��͐ݒ肵�܂��B</summary>
        public string InqGoodsName
        {
            get { return RealRecord.InqGoodsName; }
            set { RealRecord.InqGoodsName = value; }
        }

        #endregion </26.�┭���i��>

        #region <27.�񓚏��i��>

        /// <summary>�񓚏��i�����擾�܂��͐ݒ肵�܂��B</summary>
        public string AnsGoodsName
        {
            get { return RealRecord.AnsGoodsName; }
            set { RealRecord.AnsGoodsName = value; }
        }

        #endregion </27.�񓚏��i��>

        #region <28.������>

        /// <summary>���������擾�܂��͐ݒ肵�܂��B</summary>
        public double SalesOrderCount
        {
            get { return RealRecord.SalesOrderCount; }
            set { RealRecord.SalesOrderCount = value; }
        }

        #endregion </28.������>

        #region <29.�[�i��>

        /// <summary>�[�i�����擾�܂��͐ݒ肵�܂��B</summary>
        public double DeliveredGoodsCount
        {
            get { return RealRecord.DeliveredGoodsCount; }
            set { RealRecord.DeliveredGoodsCount = value; }
        }

        #endregion </29.�[�i��>

        #region <30.���i�ԍ�>

        /// <summary>���i�ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        public string GoodsNo
        {
            get { return RealRecord.GoodsNo; }
            set { RealRecord.GoodsNo = value; }
        }

        #endregion </30.���i�ԍ�>

        #region <31.���i���[�J�[�R�[�h>

        /// <summary>���i���[�J�[�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public int GoodsMakerCd
        {
            get { return RealRecord.GoodsMakerCd; }
            set { RealRecord.GoodsMakerCd = value; }
        }

        #endregion </31.���i���[�J�[�R�[�h>

        #region <32.���i���[�J�[����>

        /// <summary>���i���[�J�[���̂��擾�܂��͐ݒ肵�܂��B</summary>
        public string GoodsMakerNm
        {
            get { return RealRecord.GoodsMakerNm; }
            set { RealRecord.GoodsMakerNm = value; }
        }

        #endregion </32.���i���[�J�[����>

        #region <33.�������i���[�J�[�R�[�h>

        /// <summary>�������i���[�J�[�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public int PureGoodsMakerCd
        {
            get { return RealRecord.PureGoodsMakerCd; }
            set { RealRecord.PureGoodsMakerCd = value; }
        }

        #endregion </33.�������i���[�J�[�R�[�h>

        #region <34.�┭�������i�ԍ�>

        /// <summary>�┭�������i�ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        public string InqPureGoodsNo
        {
            get { return RealRecord.InqPureGoodsNo; }
            set { RealRecord.InqPureGoodsNo = value; }
        }

        #endregion </34.�┭�������i�ԍ�>

        #region <35.�񓚏������i�ԍ�>

        /// <summary>�񓚏������i�ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        public string AnsPureGoodsNo
        {
            get { return RealRecord.AnsPureGoodsNo; }
            set { RealRecord.AnsPureGoodsNo = value; }
        }

        #endregion </35.�񓚏������i�ԍ�>

        #region <36.�艿>

        /// <summary>�艿���擾�܂��͐ݒ肵�܂��B</summary>
        public long ListPrice
        {
            get { return RealRecord.ListPrice; }
            set { RealRecord.ListPrice = value; }
        }

        #endregion </36.�艿>

        #region <37.�P��>

        /// <summary>�P�����擾�܂��͐ݒ肵�܂��B</summary>
        public long UnitPrice
        {
            get { return RealRecord.UnitPrice; }
            set { RealRecord.UnitPrice = value; }
        }

        #endregion </37.�P��>

        #region <38.���i�⑫���>

        /// <summary>���i�⑫�����擾�܂��͐ݒ肵�܂��B</summary>
        public string GoodsAddInfo
        {
            get { return RealRecord.GoodsAddInfo; }
            set { RealRecord.GoodsAddInfo = value; }
        }

        #endregion </38.���i�⑫���>

        #region <39.�e���z>

        /// <summary>�e���z���擾�܂��͐ݒ肵�܂��B</summary>
        public long RoughRrofit
        {
            get { return RealRecord.RoughRrofit; }
            set { RealRecord.RoughRrofit = value; }
        }

        #endregion </39.�e���z>

        #region <40.�e����>

        /// <summary>�e�������擾�܂��͐ݒ肵�܂��B</summary>
        public double RoughRate
        {
            get { return RealRecord.RoughRate; }
            set { RealRecord.RoughRate = value; }
        }

        #endregion </40.�e����>

        #region <41.�񓚊���>

        /// <summary>�񓚊������擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>YYYYMMDD</remarks>
        public DateTime AnswerLimitDate
        {
            get { return RealRecord.AnswerLimitDate; }
            set { RealRecord.AnswerLimitDate = value; }
        }

        #endregion </41.�񓚊���>

        #region <42.���l(����)>

        /// <summary>���l(����)���擾�܂��͐ݒ肵�܂��B</summary>
        public string CommentDtl
        {
            get { return RealRecord.CommentDtl; }
            set { RealRecord.CommentDtl = value; }
        }

        #endregion </42.���l(����)>

        #region <43.�I��>

        /// <summary>�I�Ԃ��擾�܂��͐ݒ肵�܂��B</summary>
        public string ShelfNo
        {
            get { return RealRecord.ShelfNo; }
            set { RealRecord.ShelfNo = value; }
        }

        #endregion </43.�I��>

        #region <44.�ǉ��敪>

        /// <summary>�ǉ��敪���擾�܂��͐ݒ肵�܂��B</summary>
        public int AdditionalDivCd
        {
            get { return RealRecord.AdditionalDivCd; }
            set { RealRecord.AdditionalDivCd = value; }
        }

        #endregion </44.�ǉ��敪>

        #region <45.�����敪>

        /// <summary>�����敪���擾�܂��͐ݒ肵�܂��B</summary>
        public int CorrectDivCD
        {
            get { return RealRecord.CorrectDivCD; }
            set { RealRecord.CorrectDivCD = value; }
        }

        #endregion </45.�����敪>

        #region <46.�⍇���E�������>

        /// <summary>�⍇���E������ʂ��擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>1:�⍇�� 2:����</remarks>
        public int InqOrdDivCd
        {
            get { return RealRecord.InqOrdDivCd; }
            set { RealRecord.InqOrdDivCd = value; }
        }

        #endregion </46.�⍇���E�������>

        #region <47.�\������>

        /// <summary>�\�����ʂ��擾�܂��͐ݒ肵�܂��B</summary>
        public int DisplayOrder
        {
            get { return RealRecord.DisplayOrder; }
            set { RealRecord.DisplayOrder = value; }
        }

        #endregion </47.�\������>

        #region <48.�ŐV���ʋ敪>

        /// <summary>�ŐV���ʋ敪���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>0:�ŐV�f�[�^ 1:���f�[�^</remarks>
        public short LatestDiscCode
        {
            get { return RealRecord.LatestDiscCode; }
            set { RealRecord.LatestDiscCode = value; }
        }

        #endregion </48.�ŐV���ʋ敪>

        // 2010/05/26 Add >>>

        #region <49.�L�����Z����ԋ敪>
        /// <summary>�L�����Z����ԋ敪���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>0:�L�����Z���Ȃ� 10:�L�����Z���v�� 20:�L�����Z���p�� 30:�L�����Z���m��</remarks>
        public short CancelCndtinDiv
        {
            get { return RealRecord.CancelCndtinDiv; }
            set { RealRecord.CancelCndtinDiv = value; }
        }
        #endregion </49.�L�����Z����ԋ敪>

        #region <50.PM�󒍃X�e�[�^�X>
        /// <summary>PM�󒍃X�e�[�^�X���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>10�F���� 20:�� 30:���� 40:�o��</remarks>
        public int PMAcptAnOdrStatus
        {
            get { return RealRecord.PMAcptAnOdrStatus; }
            set { RealRecord.PMAcptAnOdrStatus = value; }
        }
        #endregion </50.PM�󒍃X�e�[�^�X>

        #region <51.PM����`�[�ԍ�>
        /// <summary>PM����`�[�ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        public int PMSalesSlipNum
        {
            get { return RealRecord.PMSalesSlipNum; }
            set { RealRecord.PMSalesSlipNum = value; }
        }
        #endregion </51.PM����`�[�ԍ�>

        #region <52.PM����s�ԍ�>
        /// <summary>PM����s�ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        public int PMSalesRowNo
        {
            get { return RealRecord.PMSalesRowNo; }
            set { RealRecord.PMSalesRowNo = value; }
        }
        #endregion </52.PM����s�ԍ�>

        // 2010/05/26 Add <<<

        // 2011/02/09 Add >>>
        #region <53.���׎捞�敪>
        /// <summary>���׎捞�敪���擾�܂��͐ݒ肵�܂��B</summary>
        public int DtlTakeinDivCd
        {
            get { return RealRecord.DtlTakeinDivCd; }
            set { RealRecord.DtlTakeinDivCd = value; }
        }
        #endregion </53.���׎捞�敪>
        // 2011/02/09 Add <<<

        // --- ADD m.suzuki 2011/05/23 ---------->>>>>
        /// <summary>PM�q�ɃR�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public string PmWarehouseCd 
        {
            get { return RealRecord.PmWarehouseCd; }
            set { RealRecord.PmWarehouseCd = value; }
        }
        /// <summary>PM�q�ɖ��̂��擾�܂��͐ݒ肵�܂��B</summary>
        public string PmWarehouseName
        {
            get { return RealRecord.PmWarehouseName; }
            set { RealRecord.PmWarehouseName = value; }
        }
        /// <summary>PM�I�Ԃ��擾�܂��͐ݒ肵�܂��B</summary>
        public string PmShelfNo
        {
            get { return RealRecord.PmShelfNo; }
            set { RealRecord.PmShelfNo = value; }
        }
        // --- ADD m.suzuki 2011/05/23 ----------<<<<<

        // --- ADD LDNS wangqx 2011/08/08 ---------->>>>>
        /// <summary>�Z�b�g���i���[�J�[�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public double PmPrsntCount
        {
            get { return RealRecord.PmPrsntCount; }
            set { RealRecord.PmPrsntCount = value; }
        }
        /// <summary>�Z�b�g���i���[�J�[�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public int SetPartsMkrCd
        {
            get { return RealRecord.SetPartsMkrCd; }
            set { RealRecord.SetPartsMkrCd = value; }
        }
        /// <summary>�Z�b�g���i�ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        public string SetPartsNumber
        {
            get { return RealRecord.SetPartsNumber; }
            set { RealRecord.SetPartsNumber = value; }
        }
        /// <summary>�Z�b�g���i�e�q�ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        public int SetPartsMainSubNo
        {
            get { return RealRecord.SetPartsMainSubNo; }
            set { RealRecord.SetPartsMainSubNo = value; }
        }
        // --- ADD LDNS wangqx 2011/08/08 ----------<<<<<

        // --- ADD 2011/10/10 ---------->>>>>
        /// <summary>
        /// �L�����y�[���R�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        public int CampaignCode
        {
            get { return RealRecord.CampaignCode; }
            set { RealRecord.CampaignCode = value; }
        }
        // --- ADD 2011/10/10 ----------<<<<<

        // 2012/01/16 Add >>>
        /// <summary>
        /// ���L�������擾�܂��͐ݒ肵�܂��B
        /// </summary>
        public string GoodsSpecialNote
        {
            get { return RealRecord.GoodsSpecialNote; }
            set { RealRecord.GoodsSpecialNote = value; }
        }
        // 2012/01/16 Add <<<

        // --- ADD �g�� 2012/04/12 ��170 ---------->>>>>
        /// <summary>
        /// PS�Ǘ��ԍ�
        /// </summary>
        public int PsMngNo
        {
            get { return RealRecord.PSMngNo; }
            set { RealRecord.PSMngNo = value; }
        }
        // --- ADD �g�� 2012/04/12 ��170 ----------<<<<<
        // --- ADD T.Nishi 2012/05/30 ---------->>>>>
        /// <summary>
        /// �������ϕ��i�R�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        public string AutoEstimatePartsCd
        {
            get { return RealRecord.AutoEstimatePartsCd; }
            set { RealRecord.AutoEstimatePartsCd = value; }
        }
        // --- ADD T.Nishi 2012/05/30 ---------->>>>>

        // ADD 2013/05/08 �g�� 2013/06/18�z�M SCM��Q��10308,��10528 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>����`�[���v�i�ō��j���擾�܂��͐ݒ肵�܂��B</summary>
        public Int64 SalesTotalTaxInc
        {
            get { return RealRecord.SalesTotalTaxInc; }// SalesTotalTaxInc
            set { RealRecord.SalesTotalTaxInc = value; }
        }

        /// <summary>����`�[���v�i�Ŕ��j���擾�܂��͐ݒ肵�܂��B</summary>
        public Int64 SalesTotalTaxExc
        {
            get { return RealRecord.SalesTotalTaxExc; }
            set { RealRecord.SalesTotalTaxExc = value; }
        }

        /// <summary>SCM����œ]�ŕ������擾�܂��͐ݒ肵�܂��B</summary>
        public Int32 ScmConsTaxLayMethod
        {
            get { return RealRecord.ScmConsTaxLayMethod; }
            set { RealRecord.ScmConsTaxLayMethod = value; }
        }

        /// <summary>����Őŗ����擾�܂��͐ݒ肵�܂��B</summary>
        public Double ConsTaxRate
        {
            get { return RealRecord.ConsTaxRate; }
            set { RealRecord.ConsTaxRate = value; }
        }

        /// <summary>SCM�[�������敪���擾�܂��͐ݒ肵�܂��B</summary>
        public Int32 ScmFractionProcCd
        {
            get { return RealRecord.ScmFractionProcCd; }
            set { RealRecord.ScmFractionProcCd = value; }
        }

        /// <summary>���|����ł��擾�܂��͐ݒ肵�܂��B</summary>
        public Int64 AccRecConsTax
        {
            get { return RealRecord.AccRecConsTax; }
            set { RealRecord.AccRecConsTax = value; }
        }

        /// <summary>PM��������擾�܂��͐ݒ肵�܂��B</summary>
        public Int32 PMSalesDate
        {
            get { return Int32.Parse(RealRecord.PMSalesDate.ToString("yyyyMMdd")); }
            //set { RealRecord.PMSalesDate = DateTime.ParseExact(value.ToString() ,"yyyyMMdd" ,null); }
            set
            {
                DateTime PMSalesDate;
                if (DateTime.TryParseExact(value.ToString(), "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out PMSalesDate))
                {
                    RealRecord.PMSalesDate = PMSalesDate;
                }
            }
        }

        /// <summary>�d����`�[���s�������擾�܂��͐ݒ肵�܂��B</summary>
        public Int32 SuppSlpPrtTime
        {
            get { return RealRecord.SuppSlpPrtTime; }
            set { RealRecord.SuppSlpPrtTime = value; }
        }

        /// <summary>������z�i�ō��݁j���擾�܂��͐ݒ肵�܂��B</summary>
        public Int64 SalesMoneyTaxInc
        {
            get { return RealRecord.SalesMoneyTaxInc; }
            set { RealRecord.SalesMoneyTaxInc = value; }
        }

        /// <summary>������z�i�Ŕ����j���擾�܂��͐ݒ肵�܂��B</summary>
        public Int64 SalesMoneyTaxExc
        {
            get { return RealRecord.SalesMoneyTaxExc; }
            set { RealRecord.SalesMoneyTaxExc = value; }
        }
        // ADD 2013/05/08 �g�� 2013/06/18�z�M SCM��Q��10308,��10528 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        // ADD 2013/05/15 �g�� 2013/06/18�z�M SCM��Q��10410 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary> �f�[�^���̓V�X�e�����擾�܂��͐ݒ肵�܂��B </summary>
        public Int32 DataInputSystem
        {
            get { return RealRecord.DataInputSystem; }
            set { RealRecord.DataInputSystem = value; }
        }
        // ADD 2013/05/15 �g�� 2013/06/18�z�M SCM��Q��10410 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion // </Automatic Code>

        // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� ------------------------------------------------------->>>>>
        /// <summary> �D�ǐݒ�ڍ׃R�[�h�Q���擾�܂��͐ݒ肵�܂��B </summary>
        public Int32 PrmSetDtlNo2
        {
            get { return RealRecord.PrmSetDtlNo2; }
            set { RealRecord.PrmSetDtlNo2 = value; }
        }
        /// <summary> �D�ǐݒ�ڍז��̂��擾�܂��͐ݒ肵�܂��B </summary>
        public string PrmSetDtlName2
        {
            get { return RealRecord.PrmSetDtlName2; }
            set { RealRecord.PrmSetDtlName2 = value; }
        }
        /// <summary> �݌ɏ󋵋敪���擾�܂��͐ݒ肵�܂��B </summary>
        public Int16 StockStatusDiv
        {
            get { return RealRecord.StockStatusDiv; }
            set { RealRecord.StockStatusDiv = value; }
        }
        // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� -------------------------------------------------------<<<<<

        // ADD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
        /// <summary> �ݏo�敪���擾�܂��͐ݒ肵�܂��B </summary>
        public Int16 RentDiv
        {
            get { return RealRecord.RentDiv; }
            set { RealRecord.RentDiv = value; }
        }
        /// <summary> ���[�J�[��]�������i���擾�܂��͐ݒ肵�܂��B </summary>
        public Int64 MkrSuggestRtPric
        {
            get { return RealRecord.MkrSuggestRtPric; }
            set { RealRecord.MkrSuggestRtPric = value; }
        }
        /// <summary> �I�[�v�����i�敪���擾�܂��͐ݒ肵�܂��B </summary>
        public Int32 OpenPriceDiv
        {
            get { return RealRecord.OpenPriceDiv; }
            set { RealRecord.OpenPriceDiv = value; }
        }
        // ADD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<

        // ADD 2015/01/19 �L�� ���R�����h�Ή� --------------------->>>>>
        /// <summary>���������i�I���敪</summary>
        public Int16 BgnGoodsDiv
        {
            get { return RealRecord.BgnGoodsDiv; }
            set { RealRecord.BgnGoodsDiv = value; }
        }
        // ADD 2015/01/19 �L�� ���R�����h�Ή� ---------------------<<<<<

        // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� ----------------------------->>>>>
        /// <summary> �^���ʕ��i�̗p�N�����擾�܂��͐ݒ肵�܂��B </summary>
        public int ModelPrtsAdptYm
        {
            get { return int.Parse(RealRecord.ModelPrtsAdptYm.ToString("yyyyMMdd").Substring(0, 6)); }
            set
            {
                RealRecord.PMSalesDate = SCMEntityUtil.ConvertModelPrtsAdptYm(value);
            }
        }

        /// <summary> �^���ʕ��i�p�~�N�����擾�܂��͐ݒ肵�܂��B </summary>
        public int ModelPrtsAblsYm
        {
            get { return int.Parse(RealRecord.ModelPrtsAblsYm.ToString("yyyyMMdd").Substring(0, 6)); }
            set
            {
                RealRecord.PMSalesDate = SCMEntityUtil.ConvertModelPrtsAblsYm(value);
            }
        }

        /// <summary> �^���ʕ��i�̗p�ԑ�ԍ����擾�܂��͐ݒ肵�܂��B </summary>
        public Int32 ModelPrtsAdptFrameNo
        {
            get { return RealRecord.ModelPrtsAdptFrameNo; }
            set { RealRecord.ModelPrtsAdptFrameNo = value; }
        }

        /// <summary> �^���ʕ��i�p�~�ԑ�ԍ����擾�܂��͐ݒ肵�܂��B </summary>
        public Int32 ModelPrtsAblsFrameNo
        {
            get { return RealRecord.ModelPrtsAblsFrameNo; }
            set { RealRecord.ModelPrtsAblsFrameNo = value; }
        }
        // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� -----------------------------<<<<<
        // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary> �񓚔[���敪���擾�܂��͐ݒ肵�܂��B </summary>
        public Int16 AnsDeliDateDiv
        {
            get { return RealRecord.AnsDeliDateDiv; }
            set { RealRecord.AnsDeliDateDiv = value; }
        }
        // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ---------->>>>>>>>>>
        /// <summary>���i�K�i�E���L����(�H�����)���擾�܂��͐ݒ肵�܂��B</summary>
        public string GoodsSpecialNtForFac
        {
            get { return RealRecord.GoodsSpecialNtForFac; }
            set { RealRecord.GoodsSpecialNtForFac = value; }
        }
        /// <summary>���i�K�i�E���L����(�J�[�I�[�i�[����)���擾�܂��͐ݒ肵�܂��B</summary>
        public string GoodsSpecialNtForCOw
        {
            get { return RealRecord.GoodsSpecialNtForCOw; }
            set { RealRecord.GoodsSpecialNtForCOw = value; }
        }
        /// <summary>�D�ǐݒ�ڍז��̂Q(�H�����)���擾�܂��͐ݒ肵�܂��B</summary>
        public string PrmSetDtlName2ForFac
        {
            get { return RealRecord.PrmSetDtlName2ForFac; }
            set { RealRecord.PrmSetDtlName2ForFac = value; }
        }
        /// <summary>�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)���擾�܂��͐ݒ肵�܂��B</summary>
        public string PrmSetDtlName2ForCOw
        {
            get { return RealRecord.PrmSetDtlName2ForCOw; }
            set { RealRecord.PrmSetDtlName2ForCOw = value; }
        }
        // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ----------<<<<<<<<<<

        // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>�┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)���擾�܂��͐ݒ肵�܂��B</summary>
        public string InqBlUtyPtThCd
        {
            get { return RealRecord.InqBlUtyPtThCd; }
            set { RealRecord.InqBlUtyPtThCd = value; }
        }

        /// <summary>�┭BL���ꕔ�i�T�u�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public Int32 InqBlUtyPtSbCd
        {
            get { return RealRecord.InqBlUtyPtSbCd; }
            set { RealRecord.InqBlUtyPtSbCd = value; }
        }

        /// <summary>��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)���擾�܂��͐ݒ肵�܂��B</summary>
        public string AnsBlUtyPtThCd
        {
            get { return RealRecord.AnsBlUtyPtThCd; }
            set { RealRecord.AnsBlUtyPtThCd = value; }
        }

        /// <summary>��BL���ꕔ�i�T�u�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public Int32 AnsBlUtyPtSbCd
        {
            get { return RealRecord.AnsBlUtyPtSbCd; }
            set { RealRecord.AnsBlUtyPtSbCd = value; }
        }

        /// <summary>��BL���i�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public Int32 AnsBLGoodsCode
        {
            get { return RealRecord.AnsBLGoodsCode; }
            set { RealRecord.AnsBLGoodsCode = value; }
        }

        /// <summary>��BL���i�R�[�h�}�Ԃ��擾�܂��͐ݒ肵�܂��B</summary>
        public Int32 AnsBLGoodsDrCode
        {
            get { return RealRecord.AnsBLGoodsDrCode; }
            set { RealRecord.AnsBLGoodsDrCode = value; }
        }
        // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
    }
}
