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

namespace Broadleaf.Application.UIData
{

    using RecordType = Broadleaf.Application.Remoting.ParamData.SCMAcOdSetDtWork;
    using RecordTypeWeb = Broadleaf.Application.UIData.ScmOdSetDt;

    /// <summary>
    /// ���[�U�[DB SCM�󒍃Z�b�g���i�f�[�^�̃��b�p�[�N���X�i���񑩁j
    /// </summary>
    /// <remarks>
    /// <br>Update Note      :   2018/04/16 �c����</br>
    /// <br>�Ǘ��ԍ�         :   11470007-00</br>
    /// <br>                 :   SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�</br>
    /// </remarks>
    public abstract partial class UserSCMAcOdSetDtWrapper : ISCMAcOdSetDtRecord
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
        protected UserSCMAcOdSetDtWrapper() : this(new RecordType()) { }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="realRecord">�{���̃��R�[�h</param>
        protected UserSCMAcOdSetDtWrapper(RecordType realRecord)
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

        #region <14.�Z�b�g���i���[�J�[�R�[�h>

        /// <summary>�Z�b�g���i���[�J�[�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public int SetPartsMkrCd
        {
            get { return RealRecord.SetPartsMkrCd; }
            set { RealRecord.SetPartsMkrCd = value; }
        }

        #endregion </14.�Z�b�g���i���[�J�[�R�[�h>

        #region <15.�Z�b�g���i�ԍ�>

        /// <summary>�Z�b�g���i�ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        public string SetPartsNumber
        {
            get { return RealRecord.SetPartsNumber; }
            set { RealRecord.SetPartsNumber = value; }
        }

        #endregion </15.�Z�b�g���i�ԍ�>

        #region <16.�Z�b�g���i�e�q�ԍ�>

        /// <summary>�Z�b�g���i�e�q�ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        public int SetPartsMainSubNo
        {
            get { return RealRecord.SetPartsMainSubNo; }
            set { RealRecord.SetPartsMainSubNo = value; }
        }

        #endregion </16.�Z�b�g���i�e�q�ԍ�>

        #region <17.���i���>

        /// <summary>���i��ʂ��擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>0:�������i 1:�D�Ǖ��i 2:���T�C�N�����i 3:���ϑ���</remarks>
        public int GoodsDivCd
        {
            get { return RealRecord.GoodsDivCd; }
            set { RealRecord.GoodsDivCd = value; }
        }

        #endregion </17.���i���>

        #region <18.���T�C�N�����i���>

        /// <summary>���T�C�N�����i��ʂ��擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>1:���r���h 2:����</remarks>
        public int RecyclePrtKindCode
        {
            get { return RealRecord.RecyclePrtKindCode; }
            set { RealRecord.RecyclePrtKindCode = value; }
        }

        #endregion </18.���T�C�N�����i���>

        #region <19.���T�C�N�����i��ʖ���>

        /// <summary>���T�C�N�����i��ʖ��̂��擾�܂��͐ݒ肵�܂��B</summary>
        public string RecyclePrtKindName
        {
            get { return RealRecord.RecyclePrtKindName; }
            set { RealRecord.RecyclePrtKindName = value; }
        }

        #endregion </19.���T�C�N�����i��ʖ���>

        #region <20.�[�i�敪>

        /// <summary>�[�i�敪���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>0:�z��,1:����</remarks>
        public int DeliveredGoodsDiv
        {
            get { return RealRecord.DeliveredGoodsDiv; }
            set { RealRecord.DeliveredGoodsDiv = value; }
        }

        #endregion </20.�[�i�敪>

        #region <21.�戵�敪>

        /// <summary>�戵�敪���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>0:��舵���i,1:�[���m�F��,2:����舵���i</remarks>
        public int HandleDivCode
        {
            get { return RealRecord.HandleDivCode; }
            set { RealRecord.HandleDivCode = value; }
        }

        #endregion </21.�戵�敪>

        #region <22.���i�`��>

        /// <summary>���i�`�Ԃ��擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>1:���i,2:�p�i</remarks>
        public int GoodsShape
        {
            get { return RealRecord.GoodsShape; }
            set { RealRecord.GoodsShape = value; }
        }

        #endregion </22.���i�`��>

        #region <23.�[�i�m�F�敪>

        /// <summary>�[�i�m�F�敪���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>0:���m�F,1:�m�F</remarks>
        public int DelivrdGdsConfCd
        {
            get { return RealRecord.DelivrdGdsConfCd; }
            set { RealRecord.DelivrdGdsConfCd = value; }
        }

        #endregion </23.�[�i�m�F�敪>

        #region <24.�[�i�����\���>

        /// <summary>�[�i�����\������擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>�[�i�\����t YYYYMMDD</remarks>
        public DateTime DeliGdsCmpltDueDate
        {
            get { return RealRecord.DeliGdsCmpltDueDate; }
            set { RealRecord.DeliGdsCmpltDueDate = value; }
        }

        #endregion </24.�[�i�����\���>

        #region <25.�񓚔[��>

        /// <summary>�񓚔[�����擾�܂��͐ݒ肵�܂��B</summary>
        public string AnswerDeliveryDate
        {
            get { return RealRecord.AnswerDeliveryDate; }
            set { RealRecord.AnswerDeliveryDate = value; }
        }

        #endregion </25.�񓚔[��>

        #region <26.BL���i�R�[�h>

        /// <summary>BL���i�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public int BLGoodsCode
        {
            get { return RealRecord.BLGoodsCode; }
            set { RealRecord.BLGoodsCode = value; }
        }

        #endregion </26.BL���i�R�[�h>

        #region <27.BL���i�R�[�h�}��>

        /// <summary>BL���i�R�[�h�}�Ԃ��擾�܂��͐ݒ肵�܂��B</summary>
        public int BLGoodsDrCode
        {
            get { return RealRecord.BLGoodsDrCode; }
            set { RealRecord.BLGoodsDrCode = value; }
        }

        #endregion </27.BL���i�R�[�h�}��>

        #region <28.�┭���i��>

        /// <summary>�┭���i�����擾�܂��͐ݒ肵�܂��B</summary>
        public string InqGoodsName
        {
            get { return RealRecord.InqGoodsName; }
            set { RealRecord.InqGoodsName = value; }
        }

        #endregion </28.�┭���i��>

        #region <29.�񓚏��i��>

        /// <summary>�񓚏��i�����擾�܂��͐ݒ肵�܂��B</summary>
        public string AnsGoodsName
        {
            get { return RealRecord.AnsGoodsName; }
            set { RealRecord.AnsGoodsName = value; }
        }

        #endregion </29.�񓚏��i��>

        #region <30.������>

        /// <summary>���������擾�܂��͐ݒ肵�܂��B</summary>
        public double SalesOrderCount
        {
            get { return RealRecord.SalesOrderCount; }
            set { RealRecord.SalesOrderCount = value; }
        }

        #endregion </30.������>

        #region <31.�[�i��>

        /// <summary>�[�i�����擾�܂��͐ݒ肵�܂��B</summary>
        public double DeliveredGoodsCount
        {
            get { return RealRecord.DeliveredGoodsCount; }
            set { RealRecord.DeliveredGoodsCount = value; }
        }

        #endregion </31.�[�i��>

        #region <32.���i�ԍ�>

        /// <summary>���i�ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        public string GoodsNo
        {
            get { return RealRecord.GoodsNo; }
            set { RealRecord.GoodsNo = value; }
        }

        #endregion </32.���i�ԍ�>

        #region <33.���i���[�J�[�R�[�h>

        /// <summary>���i���[�J�[�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public int GoodsMakerCd
        {
            get { return RealRecord.GoodsMakerCd; }
            set { RealRecord.GoodsMakerCd = value; }
        }

        #endregion </33.���i���[�J�[�R�[�h>

        #region <34.���i���[�J�[����>

        /// <summary>���i���[�J�[���̂��擾�܂��͐ݒ肵�܂��B</summary>
        public string GoodsMakerNm
        {
            get { return RealRecord.GoodsMakerNm; }
            set { RealRecord.GoodsMakerNm = value; }
        }

        #endregion </34.���i���[�J�[����>

        #region <35.�������i���[�J�[�R�[�h>

        /// <summary>�������i���[�J�[�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public int PureGoodsMakerCd
        {
            get { return RealRecord.PureGoodsMakerCd; }
            set { RealRecord.PureGoodsMakerCd = value; }
        }

        #endregion </35.�������i���[�J�[�R�[�h>

        #region <36.�┭�������i�ԍ�>

        /// <summary>�┭�������i�ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        public string InqPureGoodsNo
        {
            get { return RealRecord.InqPureGoodsNo; }
            set { RealRecord.InqPureGoodsNo = value; }
        }

        #endregion </36.�┭�������i�ԍ�>

        #region <37.�񓚏������i�ԍ�>

        /// <summary>�񓚏������i�ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        public string AnsPureGoodsNo
        {
            get { return RealRecord.AnsPureGoodsNo; }
            set { RealRecord.AnsPureGoodsNo = value; }
        }

        #endregion </37.�񓚏������i�ԍ�>

        #region <38.�艿>

        /// <summary>�艿���擾�܂��͐ݒ肵�܂��B</summary>
        public long ListPrice
        {
            get { return RealRecord.ListPrice; }
            set { RealRecord.ListPrice = value; }
        }

        #endregion </38.�艿>

        #region <39.�P��>

        /// <summary>�P�����擾�܂��͐ݒ肵�܂��B</summary>
        public long UnitPrice
        {
            get { return RealRecord.UnitPrice; }
            set { RealRecord.UnitPrice = value; }
        }

        #endregion </39.�P��>

        #region <40.���i�⑫���>

        /// <summary>���i�⑫�����擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>PS�̂t�q�k</remarks>
        public string GoodsAddInfo
        {
            get { return RealRecord.GoodsAddInfo; }
            set { RealRecord.GoodsAddInfo = value; }
        }

        #endregion </40.���i�⑫���>

        #region <41.�e���z>

        /// <summary>�e���z���擾�܂��͐ݒ肵�܂��B</summary>
        public long RoughRrofit
        {
            get { return RealRecord.RoughRrofit; }
            set { RealRecord.RoughRrofit = value; }
        }

        #endregion </41.�e���z>

        #region <42.�e����>

        /// <summary>�e�������擾�܂��͐ݒ肵�܂��B</summary>
        public double RoughRate
        {
            get { return RealRecord.RoughRate; }
            set { RealRecord.RoughRate = value; }
        }

        #endregion </42.�e����>

        #region <43.�񓚊���>

        /// <summary>�񓚊������擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>YYYYMMDD</remarks>
        public DateTime AnswerLimitDate
        {
            get { return RealRecord.AnswerLimitDate; }
            set { RealRecord.AnswerLimitDate = value; }
        }

        #endregion </43.�񓚊���>

        #region <44.���l(����)>

        /// <summary>���l(����)���擾�܂��͐ݒ肵�܂��B</summary>
        public string CommentDtl
        {
            get { return RealRecord.CommentDtl; }
            set { RealRecord.CommentDtl = value; }
        }

        #endregion </44.���l(����)>

        #region <45.�I��>

        /// <summary>�I�Ԃ��擾�܂��͐ݒ肵�܂��B</summary>
        public string ShelfNo
        {
            get { return RealRecord.ShelfNo; }
            set { RealRecord.ShelfNo = value; }
        }

        #endregion </45.�I��>

        #region <46.PM�󒍃X�e�[�^�X>

        /// <summary>PM�󒍃X�e�[�^�X���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>10:����,20:��,30:����</remarks>
        public int PMAcptAnOdrStatus
        {
            get { return RealRecord.PMAcptAnOdrStatus; }
            set { RealRecord.PMAcptAnOdrStatus = value; }
        }

        #endregion </46.PM�󒍃X�e�[�^�X>

        #region <47.PM����`�[�ԍ�>

        /// <summary>�����敪���擾�܂��͐ݒ肵�܂��B</summary>
        public int PMSalesSlipNum
        {
            get { return RealRecord.PMSalesSlipNum; }
            set { RealRecord.PMSalesSlipNum = value; }
        }

        #endregion </47.PM����`�[�ԍ�>

        #region <48.PM����s�ԍ�>

        /// <summary>PM����s�ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        public int PMSalesRowNo
        {
            get { return RealRecord.PMSalesRowNo; }
            set { RealRecord.PMSalesRowNo = value; }
        }

        #endregion </48.PM����s�ԍ�>

        #region <49.PM�q�ɃR�[�h>

        /// <summary>
        /// PM�q�ɃR�[�h���擾�܂��͐ݒ肵�܂��B(�����ږ��̈Ⴂ���z��)
        /// </summary>
        public string PmWarehouseCd
        {
            get { return RealRecord.PmWarehouseCd; }
            set { RealRecord.PmWarehouseCd = value; }
        }

        #endregion </49.PM�q�ɃR�[�h>

        #region <50.PM�q�ɖ���>

        /// <summary>
        /// PM�q�ɖ��̂��擾�܂��͐ݒ肵�܂��B(�����ږ��̈Ⴂ���z��)
        /// </summary>
        public string PmWarehouseName
        {
            get { return RealRecord.PmWarehouseName; }
            set { RealRecord.PmWarehouseName = value; }
        }

        #endregion </50.PM�q�ɖ���>

        #region <51.PM�I��>

        /// <summary>
        /// PM�I�Ԃ��擾�܂��͐ݒ肵�܂��B(�����ږ��̈Ⴂ���z��)
        /// </summary>
        public string PmShelfNo
        {
            get { return RealRecord.PmShelfNo; }
            set { RealRecord.PmShelfNo = value; }
        }

        #endregion </51.PM�I��>

        #region <52.PM���݌�>

        /// <summary>PM���݌����擾�܂��͐ݒ肵�܂��B</summary>
        public double PmPrsntCount
        {
            get { return RealRecord.PmPrsntCount; }
            set { RealRecord.PmPrsntCount = value; }
        }

        #endregion </52.PM���݌�>

        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        #region <53.PM��Ǒq�ɃR�[�h>
        /// <summary>
        /// PM��Ǒq�ɃR�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        public string PmMainMngWarehouseCd
        {
            get { return RealRecord.PmMainMngWarehouseCd; }
            set { RealRecord.PmMainMngWarehouseCd = value; }
        }
        #endregion </53.PM��Ǒq�ɃR�[�h>

        #region <54.PM��Ǒq�ɖ���>
        /// <summary>
        /// PM��Ǒq�ɖ��̂��擾�܂��͐ݒ肵�܂��B
        /// </summary>
        public string PmMainMngWarehouseName
        {
            get { return RealRecord.PmMainMngWarehouseName; }
            set { RealRecord.PmMainMngWarehouseName = value; }
        }
        #endregion </54.PM��Ǒq�ɖ���>

        #region <55.PM��ǒI��>
        /// <summary>
        /// PM��ǒI�Ԃ��擾�܂��͐ݒ肵�܂��B
        /// </summary>
        public string PmMainMngShelfNo
        {
            get { return RealRecord.PmMainMngShelfNo; }
            set { RealRecord.PmMainMngShelfNo = value; }
        }
        #endregion </55.PM��ǒI��>

        #region <56.PM��ǌ��݌�>
        /// <summary>
        /// PM��ǌ��݌����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        public double PmMainMngPrsntCount
        {
            get { return RealRecord.PmMainMngPrsntCount; }
            set { RealRecord.PmMainMngPrsntCount = value; }
        }
        #endregion </56.PM��ǌ��݌�>
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

        // ADD 2013/05/09 SCM��Q��10470�Ή� ----------------------------------------->>>>>
        #region <57.���i�K�i�E���L����>

        /// <summary>���i�K�i�E���L�������擾�܂��͐ݒ肵�܂��B</summary>
        public string GoodsSpclInstruction
        {
            get { return RealRecord.GoodsSpclInstruction; }
            set { RealRecord.GoodsSpclInstruction = value; }
        }

        #endregion </53.���i�K�i�E���L����>
        // ADD 2013/05/09 SCM��Q��10470�Ή� -----------------------------------------<<<<<

        // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� --------------------------------->>>>>
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
        // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� ---------------------------------<<<<<
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

        // ADD 2015/02/27 SCM������ C������ʑΉ� -------------------------------->>>>>
        /// <summary>�D�ǐݒ�ڍ׃R�[�h�Q���擾�܂��͐ݒ肵�܂��B</summary>
        public int PrmSetDtlNo2
        {
            get { return RealRecord.PrmSetDtlNo2; }
            set { RealRecord.PrmSetDtlNo2 = value; }
        }
        /// <summary>�D�ǐݒ�ڍז��̂Q���擾�܂��͐ݒ肵�܂��B</summary>
        public string PrmSetDtlName2
        {
            get { return RealRecord.PrmSetDtlName2; }
            set { RealRecord.PrmSetDtlName2 = value; }
        }
        /// <summary>�݌ɏ󋵋敪���擾�܂��͐ݒ肵�܂��B</summary>
        public short StockStatusDiv
        {
            get { return RealRecord.StockStatusDiv; }
            set { RealRecord.StockStatusDiv = value; }
        }
        // ADD 2015/02/27 SCM������ C������ʑΉ� --------------------------------<<<<<

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

#endregion // </Automatic Code>

    }
}

