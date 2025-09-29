using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RateProcParamWork
    /// <summary>
    ///                      �|���}�X�^���o�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �|���}�X�^���o�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011/08/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class APRateProcParamWork
    {
        /// <summary>�J�n����</summary>
        private Int64 _beginningDate;

        /// <summary>�I������</summary>
        private Int64 _endingDate;

        /// <summary>�P�����</summary>
        private string _unitPriceKind = "";

        /// <summary>�ݒ���@</summary>
        private string _setFun = "";

        /// <summary>�P��</summary>
        private string _rateSettingDivide = "";

        /// <summary>���_(�J�n)</summary>
        private string _belongSectionCdBegin = "";

        /// <summary>���_(�I��)</summary>
        private string _belongSectionCdEnd = "";

        /// <summary>���Ӑ�|��GR(�J�n)</summary>
        private Int32 _custRateGrpCodeBegin;

        /// <summary>���Ӑ�|��GR(�I��)</summary>
        private Int32 _custRateGrpCodeEnd;

        /// <summary>���Ӑ�R�[�h(�J�n)</summary>
        private Int32 _customerCodeBegin;

        /// <summary>���Ӑ�R�[�h(�I��)</summary>
        private Int32 _customerCodeEnd;

        /// <summary>�d����R�[�h(�J�n)</summary>
        private Int32 _supplierCdBegin;

        /// <summary>�d����R�[�h(�I��)</summary>
        private Int32 _supplierCdEnd;

        /// <summary>���i���[�J�[�R�[�h(�J�n)</summary>
        private Int32 _goodsMakerCdBegin;

        /// <summary>���i���[�J�[�R�[�h(�I��)</summary>
        private Int32 _goodsMakerCdEnd;

        /// <summary>�w��(�J�n)</summary>
        private string _goodsRateRankBegin = "";

        /// <summary>�w��(�I��)</summary>
        private string _goodsRateRankEnd = "";

        /// <summary>���i�|��GR(�J�n)</summary>
        private Int32 _goodsRateGrpCodeBegin;

        /// <summary>���i�|��GR(�I��)</summary>
        private Int32 _goodsRateGrpCodeEnd;

        /// <summary>BL�R�[�h(�J�n)</summary>
        private Int32 _bLGoodsCodeBegin;

        /// <summary>BL�R�[�h(�I��)</summary>
        private Int32 _bLGoodsCodeEnd;

        /// <summary>�i��(�J�n)</summary>
        private string _goodsNoBegin = "";

        /// <summary>�i��(�I��)</summary>
        private string _goodsNoEnd = "";


        /// public propaty name  :  BeginningDate
        /// <summary>�J�n�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 UpdateDateTimeBegin
        {
            get { return _beginningDate; }
            set { _beginningDate = value; }
        }

        /// public propaty name  :  EndingDate
        /// <summary>�I�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 UpdateDateTimeEnd
        {
            get { return _endingDate; }
            set { _endingDate = value; }
        }

        /// public propaty name  :  UnitPriceKind
        /// <summary>�P����ރv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P����ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UnitPriceKindRF
        {
            get { return _unitPriceKind; }
            set { _unitPriceKind = value; }
        }

        /// public propaty name  :  SetFun
        /// <summary>�ݒ���@�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ݒ���@�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SetFunRF
        {
            get { return _setFun; }
            set { _setFun = value; }
        }

        /// public propaty name  :  RateSettingDivide
        /// <summary>�P�ƃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P�ƃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateSettingDivideRF
        {
            get { return _rateSettingDivide; }
            set { _rateSettingDivide = value; }
        }

        /// public propaty name  :  SectionCodeBegin
        /// <summary>���_(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCodeBeginRF
        {
            get { return _belongSectionCdBegin; }
            set { _belongSectionCdBegin = value; }
        }

        /// public propaty name  :  SectionCodeEnd
        /// <summary>���_(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCodeEndRF
        {
            get { return _belongSectionCdEnd; }
            set { _belongSectionCdEnd = value; }
        }

        /// public propaty name  :  CustRateGrpCodeBegin
        /// <summary>���Ӑ�|��GR(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�|��GR(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustRateGrpCodeBeginRF
        {
            get { return _custRateGrpCodeBegin; }
            set { _custRateGrpCodeBegin = value; }
        }

        /// public propaty name  :  CustRateGrpCodeEnd
        /// <summary>���Ӑ�|��GR(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�|��GR(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustRateGrpCodeEndRF
        {
            get { return _custRateGrpCodeEnd; }
            set { _custRateGrpCodeEnd = value; }
        }

        /// public propaty name  :  CustomerCodeBegin
        /// <summary>���Ӑ�R�[�h(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCodeBeginRF
        {
            get { return _customerCodeBegin; }
            set { _customerCodeBegin = value; }
        }

        /// public propaty name  :  CustomerCodeEnd
        /// <summary>���Ӑ�R�[�h(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCodeEndRF
        {
            get { return _customerCodeEnd; }
            set { _customerCodeEnd = value; }
        }

        /// public propaty name  :  SupplierCdBegin
        /// <summary>�d����R�[�h(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCdBeginRF
        {
            get { return _supplierCdBegin; }
            set { _supplierCdBegin = value; }
        }

        /// public propaty name  :  SupplierCdEnd
        /// <summary>�d����R�[�h(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCdEndRF
        {
            get { return _supplierCdEnd; }
            set { _supplierCdEnd = value; }
        }

        /// public propaty name  :  GoodsMakerCdBegin
        /// <summary>���i���[�J�[�R�[�h(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCdBeginRF
        {
            get { return _goodsMakerCdBegin; }
            set { _goodsMakerCdBegin = value; }
        }

        /// public propaty name  :  GoodsMakerCdEnd
        /// <summary>���i���[�J�[�R�[�h(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCdEndRF
        {
            get { return _goodsMakerCdEnd; }
            set { _goodsMakerCdEnd = value; }
        }

        /// public propaty name  :  GoodsRateRankBegin
        /// <summary>�w��(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �w��(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsRateRankBeginRF
        {
            get { return _goodsRateRankBegin; }
            set { _goodsRateRankBegin = value; }
        }

        /// public propaty name  :  GoodsRateRankEnd
        /// <summary>�w��(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �w��(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsRateRankEndRF
        {
            get { return _goodsRateRankEnd; }
            set { _goodsRateRankEnd = value; }
        }

        /// public propaty name  :  GoodsRateGrpCodeBegin
        /// <summary>���i�|��GR(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|��GR(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsRateGrpCodeBeginRF
        {
            get { return _goodsRateGrpCodeBegin; }
            set { _goodsRateGrpCodeBegin = value; }
        }

        /// public propaty name  :  GoodsRateGrpCodeEnd
        /// <summary>���i�|��GR(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|��GR(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsRateGrpCodeEndRF
        {
            get { return _goodsRateGrpCodeEnd; }
            set { _goodsRateGrpCodeEnd = value; }
        }

        /// public propaty name  :  BLGoodsCodeBegin
        /// <summary>BL�R�[�h(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCodeBeginRF
        {
            get { return _bLGoodsCodeBegin; }
            set { _bLGoodsCodeBegin = value; }
        }

        /// public propaty name  :  BLGoodsCodeEnd
        /// <summary>BL�R�[�h(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCodeEndRF
        {
            get { return _bLGoodsCodeEnd; }
            set { _bLGoodsCodeEnd = value; }
        }

        /// public propaty name  :  GoodsNoBegin
        /// <summary>�i��(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i��(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoBeginRF
        {
            get { return _goodsNoBegin; }
            set { _goodsNoBegin = value; }
        }

        /// public propaty name  :  GoodsNoEnd
        /// <summary>�i��(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i��(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoEndRF
        {
            get { return _goodsNoEnd; }
            set { _goodsNoEnd = value; }
        }


        /// <summary>
        /// �|���}�X�^���o�������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>RateProcParamWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RateProcParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public APRateProcParamWork()
        {
        }

    }
}

