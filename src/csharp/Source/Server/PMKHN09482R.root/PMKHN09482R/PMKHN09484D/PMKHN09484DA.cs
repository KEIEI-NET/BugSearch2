using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;


namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RateProtyMngPatternWork
    /// <summary>
    ///                      �|���ݒ�}�X�^�������o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �|���ݒ�}�X�^�������o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/01/21  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RateProtyMngPatternWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode;

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>���i�|���O���[�v�R�[�h</summary>
        private Int32 _goodsRateGrpCode;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ�|���O���[�v�R�[�h</summary>
        private Int32 _custRateGrpCode;

        /// <summary>�i��</summary>
        /// <remarks></remarks>
        private String _goodsNo;

        /// <summary>BL�R�[�h</summary>
        /// <remarks></remarks>
        private Int32 _blGoodsCode;

        /// <summary>BL�O���[�v�R�[�h</summary>
        /// <remarks></remarks>
        private Int32 _blGroupCode;

        /// <summary>���i�|�������N</summary>
        /// <remarks></remarks>
        private String _goodsRateRank;

        /// <summary>�P���|���ݒ�敪</summary>
        /// <remarks></remarks>
        private String _unitRateSetDivCd;

        /// <summary>�P�����</summary>
        /// <remarks></remarks>
        private String _unitPriceKind;

        /// <summary>�|���ݒ�敪</summary>
        /// <remarks></remarks>
        private String _rateSettingDivide;

        /// <summary>�|���ݒ�敪�i���i�j</summary>
        /// <remarks></remarks>
        private String _rateMngGoodsCd;

        /// <summary>�|���ݒ薼�́i���i�j</summary>
        /// <remarks></remarks>
        private String _rateMngGoodsNm;

        /// <summary>�|���ݒ�敪�i���Ӑ�j</summary>
        /// <remarks></remarks>
        private String _rateMngCustCd;

        /// <summary>�|���ݒ薼�́i���Ӑ�j</summary>
        /// <remarks></remarks>
        private String _rateMngCustNm;

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  GoodsRateGrpCode
        /// <summary>���i�|���O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsRateGrpCode
        {
            get { return _goodsRateGrpCode; }
            set { _goodsRateGrpCode = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustRateGrpCode
        /// <summary>���Ӑ�|���O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�|���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustRateGrpCode
        {
            get { return _custRateGrpCode; }
            set { _custRateGrpCode = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  BlGoodsCode
        /// <summary>BL�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BlGoodsCode
        {
            get { return _blGoodsCode; }
            set { _blGoodsCode = value; }
        }

        /// public propaty name  :  BlGroupCodes
        /// <summary>BL�O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BlGroupCode
        {
            get { return _blGroupCode; }
            set { _blGroupCode = value; }
        }

        /// public propaty name  :  GoodsRateRank
        /// <summary>���i�|�������N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|�������N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsRateRank
        {
            get { return _goodsRateRank; }
            set { _goodsRateRank = value; }
        }

        /// public propaty name  :  UnitRateSetDivCd
        /// <summary>�P���|���ݒ�敪�����N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P���|���ݒ�敪�����N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UnitRateSetDivCd
        {
            get { return _unitRateSetDivCd; }
            set { _unitRateSetDivCd = value; }
        }

        /// public propaty name  :  UnitPriceKind
        /// <summary>�P����ރv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P����ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UnitPriceKind
        {
            get { return _unitPriceKind; }
            set { _unitPriceKind = value; }
        }

        /// public propaty name  :  RateSettingDivide
        /// <summary>�|���ݒ�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���ݒ�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateSettingDivide
        {
            get { return _rateSettingDivide; }
            set { _rateSettingDivide = value; }
        }

        /// public propaty name  :  RateMngGoodsCd
        /// <summary>�|���ݒ�敪�i���i�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���ݒ�敪�i���i�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateMngGoodsCd
        {
            get { return _rateMngGoodsCd; }
            set { _rateMngGoodsCd = value; }
        }

        /// public propaty name  :  RateMngGoodsNm
        /// <summary>�|���ݒ薼�́i���i�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���ݒ薼�́i���i�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateMngGoodsNm
        {
            get { return _rateMngGoodsNm; }
            set { _rateMngGoodsNm = value; }
        }

        /// public propaty name  :  RateMngCustCd
        /// <summary>�|���ݒ�敪�i���Ӑ�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���ݒ�敪�i���Ӑ�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateMngCustCd
        {
            get { return _rateMngCustCd; }
            set { _rateMngCustCd = value; }
        }

        /// public propaty name  :  RateMngCustNm
        /// <summary>�|���ݒ薼�́i���Ӑ�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���ݒ薼�́i���Ӑ�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateMngCustNm
        {
            get { return _rateMngCustNm; }
            set { _rateMngCustNm = value; }
        }


        /// <summary>
        /// �|���ꊇ�o�^�C�����o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SingleGoodsRateSearchParamWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SingleGoodsRateSearchParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RateProtyMngPatternWork()
        {
        }

    }
}
