//****************************************************************************//
// �V�X�e��         : �����񓚏���
// �v���O��������   : �����񓚏����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/05/09  �C�����e : SCM��Q��10470�Ή��E���i�K�i�E���L�����ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 31065 �L�� ���O
// �C �� ��  2015/01/19  �C�����e : SCM������ PMNS�Ή� �Z�b�g�i�Ƀ��[�J�[��]�������i�A�I�[�v�����i�敪�̒ǉ�
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

namespace Broadleaf.Application.UIData.WebDB
{
    using RecordType = Broadleaf.Application.UIData.ScmOdSetDt;
    using Broadleaf.Library.Globarization;

    /// <summary>
    /// Web-DB SCM�󒍃Z�b�g���i�f�[�^�̃��b�p�[�N���X�i���񑩁j
    /// </summary>
    /// <remarks>
    /// <br>Update Note      :   2018/04/16 �c����</br>
    /// <br>�Ǘ��ԍ�         :   11470007-00</br>
    /// <br>                 :   SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�</br>
    /// </remarks>
    public abstract partial class WebSCMAcOdSetDtWrapper : ISCMAcOdSetDtRecord
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
        protected WebSCMAcOdSetDtWrapper() : this(new RecordType()) { }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="realRecord">�{���̃��R�[�h</param>
        protected WebSCMAcOdSetDtWrapper(RecordType realRecord)
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

        #region <09.�Z�b�g���i���[�J�[�R�[�h>

        /// <summary>�Z�b�g���i���[�J�[�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public int SetPartsMkrCd
        {
            get { return RealRecord.SetPartsMkrCd; }
            set { RealRecord.SetPartsMkrCd = value; }
        }

        #endregion </09.�Z�b�g���i���[�J�[�R�[�h>

        #region <10.�Z�b�g���i�ԍ�>

        /// <summary>�Z�b�g���i�ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        public string SetPartsNumber
        {
            get { return RealRecord.SetPartsNumber; }
            set { RealRecord.SetPartsNumber = value; }
        }

        #endregion </10.�Z�b�g���i�ԍ�>

        #region <11.�Z�b�g���i�e�q�ԍ�>

        /// <summary>�Z�b�g���i�e�q�ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        public int SetPartsMainSubNo
        {
            get { return RealRecord.SetPartsMainSubNo; }
            set { RealRecord.SetPartsMainSubNo = value; }
        }

        #endregion </11.�Z�b�g���i�e�q�ԍ�>

        #region <12.���i���>

        /// <summary>���i��ʂ��擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>0:�������i 1:�D�Ǖ��i 2:���T�C�N�����i 3:���ϑ���</remarks>
        public int GoodsDivCd
        {
            get { return RealRecord.GoodsDivCd; }
            set { RealRecord.GoodsDivCd = value; }
        }

        #endregion </12.���i���>

        #region <13.���T�C�N�����i���>

        /// <summary>���T�C�N�����i��ʂ��擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>1:���r���h 2:����</remarks>
        public int RecyclePrtKindCode
        {
            get { return RealRecord.RecyclePrtKindCode; }
            set { RealRecord.RecyclePrtKindCode = value; }
        }

        #endregion </13.���T�C�N�����i���>

        #region <14.���T�C�N�����i��ʖ���>

        /// <summary>���T�C�N�����i��ʖ��̂��擾�܂��͐ݒ肵�܂��B</summary>
        public string RecyclePrtKindName
        {
            get { return RealRecord.RecyclePrtKindName; }
            set { RealRecord.RecyclePrtKindName = value; }
        }

        #endregion </14.���T�C�N�����i��ʖ���>

        #region <15.�[�i�敪>

        /// <summary>�[�i�敪���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>0:�z��,1:����</remarks>
        public int DeliveredGoodsDiv
        {
            get { return RealRecord.DeliveredGoodsDiv; }
            set { RealRecord.DeliveredGoodsDiv = value; }
        }

        #endregion </15.�[�i�敪>

        #region <16.�戵�敪>

        /// <summary>�戵�敪���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>0:��舵���i,1:�[���m�F��,2:����舵���i</remarks>
        public int HandleDivCode
        {
            get { return RealRecord.HandleDivCode; }
            set { RealRecord.HandleDivCode = value; }
        }

        #endregion </16.�戵�敪>

        #region <17.���i�`��>

        /// <summary>���i�`�Ԃ��擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>1:���i,2:�p�i</remarks>
        public int GoodsShape
        {
            get { return RealRecord.GoodsShape; }
            set { RealRecord.GoodsShape = value; }
        }

        #endregion </17.���i�`��>

        #region <18.�[�i�m�F�敪>

        /// <summary>�[�i�m�F�敪���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>0:���m�F,1:�m�F</remarks>
        public int DelivrdGdsConfCd
        {
            get { return RealRecord.DelivrdGdsConfCd; }
            set { RealRecord.DelivrdGdsConfCd = value; }
        }

        #endregion </18.�[�i�m�F�敪>

        #region <19.�[�i�����\���>

        /// <summary>�[�i�����\������擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>�[�i�\����t YYYYMMDD</remarks>
        public DateTime DeliGdsCmpltDueDate
        {
            get { return RealRecord.DeliGdsCmpltDueDate; }
            set { RealRecord.DeliGdsCmpltDueDate = value; }
        }

        #endregion </19.�[�i�����\���>

        #region <20.�񓚔[��>

        /// <summary>�񓚔[�����擾�܂��͐ݒ肵�܂��B</summary>
        public string AnswerDeliveryDate
        {
            get { return RealRecord.AnswerDeliveryDate; }
            set { RealRecord.AnswerDeliveryDate = value; }
        }

        #endregion </20.�񓚔[��>

        #region <21.BL���i�R�[�h>

        /// <summary>BL���i�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public int BLGoodsCode
        {
            get { return RealRecord.BLGoodsCode; }
            set { RealRecord.BLGoodsCode = value; }
        }

        #endregion </21.BL���i�R�[�h>

        #region <22.BL���i�R�[�h�}��>

        /// <summary>BL���i�R�[�h�}�Ԃ��擾�܂��͐ݒ肵�܂��B</summary>
        public int BLGoodsDrCode
        {
            get { return RealRecord.BLGoodsDrCode; }
            set { RealRecord.BLGoodsDrCode = value; }
        }

        #endregion </22.BL���i�R�[�h�}��>

        #region <23.�┭���i��>

        /// <summary>�┭���i�����擾�܂��͐ݒ肵�܂��B</summary>
        public string InqGoodsName
        {
            get { return RealRecord.InqGoodsName; }
            set { RealRecord.InqGoodsName = value; }
        }

        #endregion </23.�┭���i��>

        #region <24.�񓚏��i��>

        /// <summary>�񓚏��i�����擾�܂��͐ݒ肵�܂��B</summary>
        public string AnsGoodsName
        {
            get { return RealRecord.AnsGoodsName; }
            set { RealRecord.AnsGoodsName = value; }
        }

        #endregion </24.�񓚏��i��>

        #region <25.������>

        /// <summary>���������擾�܂��͐ݒ肵�܂��B</summary>
        public double SalesOrderCount
        {
            get { return RealRecord.SalesOrderCount; }
            set { RealRecord.SalesOrderCount = value; }
        }

        #endregion </25.������>

        #region <26.�[�i��>

        /// <summary>�[�i�����擾�܂��͐ݒ肵�܂��B</summary>
        public double DeliveredGoodsCount
        {
            get { return RealRecord.DeliveredGoodsCount; }
            set { RealRecord.DeliveredGoodsCount = value; }
        }

        #endregion </26.�[�i��>

        #region <27.���i�ԍ�>

        /// <summary>���i�ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        public string GoodsNo
        {
            get { return RealRecord.GoodsNo; }
            set { RealRecord.GoodsNo = value; }
        }

        #endregion </27.���i�ԍ�>

        #region <28.���i���[�J�[�R�[�h>

        /// <summary>���i���[�J�[�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public int GoodsMakerCd
        {
            get { return RealRecord.GoodsMakerCd; }
            set { RealRecord.GoodsMakerCd = value; }
        }

        #endregion </28.���i���[�J�[�R�[�h>

        #region <29.���i���[�J�[����>

        /// <summary>���i���[�J�[���̂��擾�܂��͐ݒ肵�܂��B</summary>
        public string GoodsMakerNm
        {
            get { return RealRecord.GoodsMakerNm; }
            set { RealRecord.GoodsMakerNm = value; }
        }

        #endregion </29.���i���[�J�[����>

        #region <30.�������i���[�J�[�R�[�h>

        /// <summary>�������i���[�J�[�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public int PureGoodsMakerCd
        {
            get { return RealRecord.PureGoodsMakerCd; }
            set { RealRecord.PureGoodsMakerCd = value; }
        }

        #endregion </30.�������i���[�J�[�R�[�h>

        #region <31.�┭�������i�ԍ�>

        /// <summary>�┭�������i�ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        public string InqPureGoodsNo
        {
            get { return RealRecord.InqPureGoodsNo; }
            set { RealRecord.InqPureGoodsNo = value; }
        }

        #endregion </31.�┭�������i�ԍ�>

        #region <32.�񓚏������i�ԍ�>

        /// <summary>�񓚏������i�ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        public string AnsPureGoodsNo
        {
            get { return RealRecord.AnsPureGoodsNo; }
            set { RealRecord.AnsPureGoodsNo = value; }
        }

        #endregion </32.�񓚏������i�ԍ�>

        #region <33.�艿>

        /// <summary>�艿���擾�܂��͐ݒ肵�܂��B</summary>
        public long ListPrice
        {
            get { return RealRecord.ListPrice; }
            set { RealRecord.ListPrice = value; }
        }

        #endregion </33.�艿>

        #region <34.�P��>

        /// <summary>�P�����擾�܂��͐ݒ肵�܂��B</summary>
        public long UnitPrice
        {
            get { return RealRecord.UnitPrice; }
            set { RealRecord.UnitPrice = value; }
        }

        #endregion </34.�P��>

        #region <35.���i�⑫���>

        /// <summary>���i�⑫�����擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>PS�̂t�q�k</remarks>
        public string GoodsAddInfo
        {
            get { return RealRecord.GoodsAddInfo; }
            set { RealRecord.GoodsAddInfo = value; }
        }

        #endregion </35.���i�⑫���>

        #region <36.�e���z>

        /// <summary>�e���z���擾�܂��͐ݒ肵�܂��B</summary>
        public long RoughRrofit
        {
            get { return RealRecord.RoughRrofit; }
            set { RealRecord.RoughRrofit = value; }
        }

        #endregion </36.�e���z>

        #region <37.�e����>

        /// <summary>�e�������擾�܂��͐ݒ肵�܂��B</summary>
        public double RoughRate
        {
            get { return RealRecord.RoughRate; }
            set { RealRecord.RoughRate = value; }
        }

        #endregion </37.�e����>

        #region <38.�񓚊���>

        /// <summary>�񓚊������擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>YYYYMMDD</remarks>
        public DateTime AnswerLimitDate
        {
            get { return RealRecord.AnswerLimitDate; }
            set { RealRecord.AnswerLimitDate = value; }
        }

        #endregion </38.�񓚊���>

        #region <39.���l(����)>

        /// <summary>���l(����)���擾�܂��͐ݒ肵�܂��B</summary>
        public string CommentDtl
        {
            get { return RealRecord.CommentDtl; }
            set { RealRecord.CommentDtl = value; }
        }

        #endregion </39.���l(����)>

        #region <40.�I��>

        /// <summary>�I�Ԃ��擾�܂��͐ݒ肵�܂��B</summary>
        public string ShelfNo
        {
            get { return RealRecord.ShelfNo; }
            set { RealRecord.ShelfNo = value; }
        }

        #endregion </40.�I��>

        #region <41.PM�󒍃X�e�[�^�X>

        /// <summary>PM�󒍃X�e�[�^�X���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>10:����,20:��,30:����</remarks>
        public int PMAcptAnOdrStatus
        {
            get { return RealRecord.PMAcptAnOdrStatus; }
            set { RealRecord.PMAcptAnOdrStatus = value; }
        }

        #endregion </41.PM�󒍃X�e�[�^�X>

        #region <42.PM����`�[�ԍ�>

        /// <summary>�����敪���擾�܂��͐ݒ肵�܂��B</summary>
        public int PMSalesSlipNum
        {
            get { return RealRecord.PMSalesSlipNum; }
            set { RealRecord.PMSalesSlipNum = value; }
        }

        #endregion </42.PM����`�[�ԍ�>

        #region <43.PM����s�ԍ�>

        /// <summary>PM����s�ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        public int PMSalesRowNo
        {
            get { return RealRecord.PMSalesRowNo; }
            set { RealRecord.PMSalesRowNo = value; }
        }

        #endregion </43.PM����s�ԍ�>

        #region <44.PM�q�ɃR�[�h>

        /// <summary>
        /// PM�q�ɃR�[�h���擾�܂��͐ݒ肵�܂��B(�����ږ��̈Ⴂ���z��)
        /// </summary>
        public string PmWarehouseCd
        {
            get { return RealRecord.PmWarehouseCd; }
            set { RealRecord.PmWarehouseCd = value; }
        }

        #endregion </44.PM�q�ɃR�[�h>

        #region <45.PM�q�ɖ���>

        /// <summary>
        /// PM�q�ɖ��̂��擾�܂��͐ݒ肵�܂��B(�����ږ��̈Ⴂ���z��)
        /// </summary>
        public string PmWarehouseName
        {
            get { return RealRecord.PmWarehouseName; }
            set { RealRecord.PmWarehouseName = value; }
        }

        #endregion </45.PM�q�ɖ���>

        #region <46.PM�I��>

        /// <summary>
        /// PM�I�Ԃ��擾�܂��͐ݒ肵�܂��B(�����ږ��̈Ⴂ���z��)
        /// </summary>
        public string PmShelfNo
        {
            get { return RealRecord.ShelfNo; }
            set { RealRecord.ShelfNo = value; }
        }

        #endregion </46.PM�I��>

        #region <47.PM���݌�>

        /// <summary>PM���݌����擾�܂��͐ݒ肵�܂��B</summary>
        public double PmPrsntCount
        {
            get { return RealRecord.PmPrsntCount; }
            set { RealRecord.PmPrsntCount = value; }
        }

        #endregion </47.PM���݌�>

        #region <48.��ƃR�[�h>

        /// <summary>��ƃR�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public string EnterpriseCode
        {
            get { return string.Empty; }
            set { }
        }

        #endregion </48.��ƃR�[�h>

        // ADD 2013/05/09 SCM��Q��10470�Ή� ----------------------------------------->>>>>
        #region <49.���i�K�i�E���L����>

        /// <summary>���i�K�i�E���L�������擾�܂��͐ݒ肵�܂��B</summary>
        public string GoodsSpclInstruction
        {
            get { return RealRecord.GoodsSpclInstruction; }
            set { RealRecord.GoodsSpclInstruction = value; }
        }

        #endregion </49.���i�K�i�E���L����>
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
