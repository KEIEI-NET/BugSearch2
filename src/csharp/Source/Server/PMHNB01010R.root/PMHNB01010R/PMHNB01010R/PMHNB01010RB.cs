using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting.ParamData
{
	#region ���P���v�Z�p�����[�^�N���X
    /// public class name:   UnitPriceCalcParam
    /// <summary>
    ///                      �P���v�Z�p�����[�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �P���v�Z�p�����[�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/12/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class UnitPriceCalcParamWork
    {
        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i�|�������N</summary>
        /// <remarks>�w��</remarks>
        private string _goodsRateRank = "";

        /// <summary>���i�|���O���[�v�R�[�h</summary>
        /// <remarks>�����ނ��g�p</remarks>
        private Int32 _goodsRateGrpCode;

        /// <summary>BL�O���[�v�R�[�h</summary>
        private Int32 _bLGroupCode;

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ�|���O���[�v�R�[�h</summary>
        private Int32 _custRateGrpCode;

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>���i�K�p��</summary>
        private DateTime _priceApplyDate;

        /// <summary>����</summary>
        private Double _countFl;

        /// <summary>�ېŋ敪</summary>
        private Int32 _taxationDivCd;

        /// <summary>�ŗ�</summary>
        private Double _taxRate;

        /// <summary>�������Œ[�������R�[�h</summary>
        /// <remarks>0�̏ꍇ�͕W���ݒ�(����P���A�艿���Z�o����ۂɎg�p)</remarks>
        private Int32 _salesCnsTaxFrcProcCd;

        /// <summary>�d������Œ[�������R�[�h</summary>
        /// <remarks>0�̏ꍇ�� �W���ݒ�(�����P�����Z�o����ۂɎg�p)</remarks>
        private Int32 _stockCnsTaxFrcProcCd;

        /// <summary>���z�\�����@�敪</summary>
        /// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
        private Int32 _totalAmountDispWayCd;

        /// <summary>���z�\���|���K�p�敪</summary>
        /// <remarks>0�F�ō��P��, 1:�Ŕ��P��</remarks>
        private Int32 _ttlAmntDspRateDivCd;

        /// <summary>����P���[�������R�[�h</summary>
        /// <remarks>0�̏ꍇ�͕W���ݒ�(����P���A�艿���Z�o����ۂɎg�p)</remarks>
        private Int32 _salesUnPrcFrcProcCd;

        /// <summary>�d���P���[�������R�[�h</summary>
        /// <remarks>0�̏ꍇ�� �W���ݒ�(�����P�����Z�o����ۂɎg�p)</remarks>
        private Int32 _stockUnPrcFrcProcCd;

        /// <summary>����œ]�ŕ���</summary>
        /// <remarks>0:�`�[�P��1:���גP��2:�����e3:�����q�@9:��ې�</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>BL���i�R�[�h����</summary>
        private string _bLGoodsName = "";


        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  GoodsNo
        /// <summary>���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsRateRank
        /// <summary>���i�|�������N�v���p�e�B</summary>
        /// <value>�w��</value>
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

        /// public propaty name  :  GoodsRateGrpCode
        /// <summary>���i�|���O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>�����ނ��g�p</value>
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

        /// public propaty name  :  BLGroupCode
        /// <summary>BL�O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
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

        /// public propaty name  :  PriceApplyDate
        /// <summary>���i�K�p���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�K�p���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime PriceApplyDate
        {
            get { return _priceApplyDate; }
            set { _priceApplyDate = value; }
        }

        /// public propaty name  :  CountFl
        /// <summary>���ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double CountFl
        {
            get { return _countFl; }
            set { _countFl = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>�ېŋ敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ېŋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TaxationDivCd
        {
            get { return _taxationDivCd; }
            set { _taxationDivCd = value; }
        }

        /// public propaty name  :  TaxRate
        /// <summary>�ŗ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TaxRate
        {
            get { return _taxRate; }
            set { _taxRate = value; }
        }

        /// public propaty name  :  SalesCnsTaxFrcProcCd
        /// <summary>�������Œ[�������R�[�h�v���p�e�B</summary>
        /// <value>0�̏ꍇ�͕W���ݒ�(����P���A�艿���Z�o����ۂɎg�p)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������Œ[�������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCnsTaxFrcProcCd
        {
            get { return _salesCnsTaxFrcProcCd; }
            set { _salesCnsTaxFrcProcCd = value; }
        }

        /// public propaty name  :  StockCnsTaxFrcProcCd
        /// <summary>�d������Œ[�������R�[�h�v���p�e�B</summary>
        /// <value>0�̏ꍇ�� �W���ݒ�(�����P�����Z�o����ۂɎg�p)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d������Œ[�������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockCnsTaxFrcProcCd
        {
            get { return _stockCnsTaxFrcProcCd; }
            set { _stockCnsTaxFrcProcCd = value; }
        }

        /// public propaty name  :  TotalAmountDispWayCd
        /// <summary>���z�\�����@�敪�v���p�e�B</summary>
        /// <value>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���z�\�����@�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalAmountDispWayCd
        {
            get { return _totalAmountDispWayCd; }
            set { _totalAmountDispWayCd = value; }
        }

        /// public propaty name  :  TtlAmntDspRateDivCd
        /// <summary>���z�\���|���K�p�敪�v���p�e�B</summary>
        /// <value>0�F�ō��P��, 1:�Ŕ��P��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���z�\���|���K�p�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TtlAmntDspRateDivCd
        {
            get { return _ttlAmntDspRateDivCd; }
            set { _ttlAmntDspRateDivCd = value; }
        }

        /// public propaty name  :  SalesUnPrcFrcProcCd
        /// <summary>����P���[�������R�[�h�v���p�e�B</summary>
        /// <value>0�̏ꍇ�͕W���ݒ�(����P���A�艿���Z�o����ۂɎg�p)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����P���[�������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesUnPrcFrcProcCd
        {
            get { return _salesUnPrcFrcProcCd; }
            set { _salesUnPrcFrcProcCd = value; }
        }

        /// public propaty name  :  StockUnPrcFrcProcCd
        /// <summary>�d���P���[�������R�[�h�v���p�e�B</summary>
        /// <value>0�̏ꍇ�� �W���ݒ�(�����P�����Z�o����ۂɎg�p)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���[�������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockUnPrcFrcProcCd
        {
            get { return _stockUnPrcFrcProcCd; }
            set { _stockUnPrcFrcProcCd = value; }
        }

        /// public propaty name  :  ConsTaxLayMethod
        /// <summary>����œ]�ŕ����v���p�e�B</summary>
        /// <value>0:�`�[�P��1:���גP��2:�����e3:�����q�@9:��ې�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����œ]�ŕ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ConsTaxLayMethod
        {
            get { return _consTaxLayMethod; }
            set { _consTaxLayMethod = value; }
        }

        /// public propaty name  :  BLGoodsName
        /// <summary>BL���i�R�[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsName
        {
            get { return _bLGoodsName; }
            set { _bLGoodsName = value; }
        }


        /// <summary>
        /// �P���v�Z�p�����[�^�R���X�g���N�^
        /// </summary>
        /// <returns>UnitPriceCalcParam�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UnitPriceCalcParam�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UnitPriceCalcParamWork()
        {
        }

        /// <summary>
        /// �P���v�Z�p�����[�^�R���X�g���N�^
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="goodsRateRank">���i�|�������N(�w��)</param>
        /// <param name="goodsRateGrpCode">���i�|���O���[�v�R�[�h(�����ނ��g�p)</param>
        /// <param name="bLGroupCode">BL�O���[�v�R�[�h</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="priceApplyDate">���i�K�p��</param>
        /// <param name="countFl">����</param>
        /// <param name="taxationDivCd">�ېŋ敪</param>
        /// <param name="taxRate">�ŗ�</param>
        /// <param name="salesCnsTaxFrcProcCd">�������Œ[�������R�[�h(0�̏ꍇ�͕W���ݒ�(����P���A�艿���Z�o����ۂɎg�p))</param>
        /// <param name="stockCnsTaxFrcProcCd">�d������Œ[�������R�[�h(0�̏ꍇ�� �W���ݒ�(�����P�����Z�o����ۂɎg�p))</param>
        /// <param name="totalAmountDispWayCd">���z�\�����@�敪(0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j)</param>
        /// <param name="ttlAmntDspRateDivCd">���z�\���|���K�p�敪(0�F�ō��P��, 1:�Ŕ��P��)</param>
        /// <param name="salesUnPrcFrcProcCd">����P���[�������R�[�h(0�̏ꍇ�͕W���ݒ�(����P���A�艿���Z�o����ۂɎg�p))</param>
        /// <param name="stockUnPrcFrcProcCd">�d���P���[�������R�[�h(0�̏ꍇ�� �W���ݒ�(�����P�����Z�o����ۂɎg�p))</param>
        /// <param name="consTaxLayMethod">����œ]�ŕ���(0:�`�[�P��1:���גP��2:�����e3:�����q�@9:��ې�)</param>
        /// <param name="bLGoodsName">BL���i�R�[�h����</param>
        /// <returns>UnitPriceCalcParam�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UnitPriceCalcParam�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UnitPriceCalcParamWork(string sectionCode, Int32 goodsMakerCd, string goodsNo, string goodsRateRank, Int32 goodsRateGrpCode, Int32 bLGroupCode, Int32 bLGoodsCode, Int32 customerCode, Int32 custRateGrpCode, Int32 supplierCd, DateTime priceApplyDate, Double countFl, Int32 taxationDivCd, Double taxRate, Int32 salesCnsTaxFrcProcCd, Int32 stockCnsTaxFrcProcCd, Int32 totalAmountDispWayCd, Int32 ttlAmntDspRateDivCd, Int32 salesUnPrcFrcProcCd, Int32 stockUnPrcFrcProcCd, Int32 consTaxLayMethod, string bLGoodsName)
        {
            this._sectionCode = sectionCode;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsNo = goodsNo;
            this._goodsRateRank = goodsRateRank;
            this._goodsRateGrpCode = goodsRateGrpCode;
            this._bLGroupCode = bLGroupCode;
            this._bLGoodsCode = bLGoodsCode;
            this._customerCode = customerCode;
            this._custRateGrpCode = custRateGrpCode;
            this._supplierCd = supplierCd;
            this._priceApplyDate = priceApplyDate;
            this._countFl = countFl;
            this._taxationDivCd = taxationDivCd;
            this._taxRate = taxRate;
            this._salesCnsTaxFrcProcCd = salesCnsTaxFrcProcCd;
            this._stockCnsTaxFrcProcCd = stockCnsTaxFrcProcCd;
            this._totalAmountDispWayCd = totalAmountDispWayCd;
            this._ttlAmntDspRateDivCd = ttlAmntDspRateDivCd;
            this._salesUnPrcFrcProcCd = salesUnPrcFrcProcCd;
            this._stockUnPrcFrcProcCd = stockUnPrcFrcProcCd;
            this._consTaxLayMethod = consTaxLayMethod;
            this._bLGoodsName = bLGoodsName;

        }

        /// <summary>
        /// �P���v�Z�p�����[�^��������
        /// </summary>
        /// <returns>UnitPriceCalcParam�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����UnitPriceCalcParam�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UnitPriceCalcParamWork Clone()
        {
            return new UnitPriceCalcParamWork(this._sectionCode, this._goodsMakerCd, this._goodsNo, this._goodsRateRank, this._goodsRateGrpCode, this._bLGroupCode, this._bLGoodsCode, this._customerCode, this._custRateGrpCode, this._supplierCd, this._priceApplyDate, this._countFl, this._taxationDivCd, this._taxRate, this._salesCnsTaxFrcProcCd, this._stockCnsTaxFrcProcCd, this._totalAmountDispWayCd, this._ttlAmntDspRateDivCd, this._salesUnPrcFrcProcCd, this._stockUnPrcFrcProcCd, this._consTaxLayMethod, this._bLGoodsName);
        }

        /// <summary>
        /// �P���v�Z�p�����[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�UnitPriceCalcParam�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UnitPriceCalcParam�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(UnitPriceCalcParamWork target)
        {
            return ( ( this.SectionCode == target.SectionCode )
                 && ( this.GoodsMakerCd == target.GoodsMakerCd )
                 && ( this.GoodsNo == target.GoodsNo )
                 && ( this.GoodsRateRank == target.GoodsRateRank )
                 && ( this.GoodsRateGrpCode == target.GoodsRateGrpCode )
                 && ( this.BLGroupCode == target.BLGroupCode )
                 && ( this.BLGoodsCode == target.BLGoodsCode )
                 && ( this.CustomerCode == target.CustomerCode )
                 && ( this.CustRateGrpCode == target.CustRateGrpCode )
                 && ( this.SupplierCd == target.SupplierCd )
                 && ( this.PriceApplyDate == target.PriceApplyDate )
                 && ( this.CountFl == target.CountFl )
                 && ( this.TaxationDivCd == target.TaxationDivCd )
                 && ( this.TaxRate == target.TaxRate )
                 && ( this.SalesCnsTaxFrcProcCd == target.SalesCnsTaxFrcProcCd )
                 && ( this.StockCnsTaxFrcProcCd == target.StockCnsTaxFrcProcCd )
                 && ( this.TotalAmountDispWayCd == target.TotalAmountDispWayCd )
                 && ( this.TtlAmntDspRateDivCd == target.TtlAmntDspRateDivCd )
                 && ( this.SalesUnPrcFrcProcCd == target.SalesUnPrcFrcProcCd )
                 && ( this.StockUnPrcFrcProcCd == target.StockUnPrcFrcProcCd )
                 && ( this.ConsTaxLayMethod == target.ConsTaxLayMethod )
                 && ( this.BLGoodsName == target.BLGoodsName ) );
        }

        /// <summary>
        /// �P���v�Z�p�����[�^��r����
        /// </summary>
        /// <param name="unitPriceCalcParam1">
        ///                    ��r����UnitPriceCalcParam�N���X�̃C���X�^���X
        /// </param>
        /// <param name="unitPriceCalcParam2">��r����UnitPriceCalcParam�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UnitPriceCalcParam�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(UnitPriceCalcParamWork unitPriceCalcParam1, UnitPriceCalcParamWork unitPriceCalcParam2)
        {
            return ( ( unitPriceCalcParam1.SectionCode == unitPriceCalcParam2.SectionCode )
                 && ( unitPriceCalcParam1.GoodsMakerCd == unitPriceCalcParam2.GoodsMakerCd )
                 && ( unitPriceCalcParam1.GoodsNo == unitPriceCalcParam2.GoodsNo )
                 && ( unitPriceCalcParam1.GoodsRateRank == unitPriceCalcParam2.GoodsRateRank )
                 && ( unitPriceCalcParam1.GoodsRateGrpCode == unitPriceCalcParam2.GoodsRateGrpCode )
                 && ( unitPriceCalcParam1.BLGroupCode == unitPriceCalcParam2.BLGroupCode )
                 && ( unitPriceCalcParam1.BLGoodsCode == unitPriceCalcParam2.BLGoodsCode )
                 && ( unitPriceCalcParam1.CustomerCode == unitPriceCalcParam2.CustomerCode )
                 && ( unitPriceCalcParam1.CustRateGrpCode == unitPriceCalcParam2.CustRateGrpCode )
                 && ( unitPriceCalcParam1.SupplierCd == unitPriceCalcParam2.SupplierCd )
                 && ( unitPriceCalcParam1.PriceApplyDate == unitPriceCalcParam2.PriceApplyDate )
                 && ( unitPriceCalcParam1.CountFl == unitPriceCalcParam2.CountFl )
                 && ( unitPriceCalcParam1.TaxationDivCd == unitPriceCalcParam2.TaxationDivCd )
                 && ( unitPriceCalcParam1.TaxRate == unitPriceCalcParam2.TaxRate )
                 && ( unitPriceCalcParam1.SalesCnsTaxFrcProcCd == unitPriceCalcParam2.SalesCnsTaxFrcProcCd )
                 && ( unitPriceCalcParam1.StockCnsTaxFrcProcCd == unitPriceCalcParam2.StockCnsTaxFrcProcCd )
                 && ( unitPriceCalcParam1.TotalAmountDispWayCd == unitPriceCalcParam2.TotalAmountDispWayCd )
                 && ( unitPriceCalcParam1.TtlAmntDspRateDivCd == unitPriceCalcParam2.TtlAmntDspRateDivCd )
                 && ( unitPriceCalcParam1.SalesUnPrcFrcProcCd == unitPriceCalcParam2.SalesUnPrcFrcProcCd )
                 && ( unitPriceCalcParam1.StockUnPrcFrcProcCd == unitPriceCalcParam2.StockUnPrcFrcProcCd )
                 && ( unitPriceCalcParam1.ConsTaxLayMethod == unitPriceCalcParam2.ConsTaxLayMethod )
                 && ( unitPriceCalcParam1.BLGoodsName == unitPriceCalcParam2.BLGoodsName ) );
        }
        /// <summary>
        /// �P���v�Z�p�����[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�UnitPriceCalcParam�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UnitPriceCalcParam�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(UnitPriceCalcParamWork target)
        {
            ArrayList resList = new ArrayList();
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsRateRank != target.GoodsRateRank) resList.Add("GoodsRateRank");
            if (this.GoodsRateGrpCode != target.GoodsRateGrpCode) resList.Add("GoodsRateGrpCode");
            if (this.BLGroupCode != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustRateGrpCode != target.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.PriceApplyDate != target.PriceApplyDate) resList.Add("PriceApplyDate");
            if (this.CountFl != target.CountFl) resList.Add("CountFl");
            if (this.TaxationDivCd != target.TaxationDivCd) resList.Add("TaxationDivCd");
            if (this.TaxRate != target.TaxRate) resList.Add("TaxRate");
            if (this.SalesCnsTaxFrcProcCd != target.SalesCnsTaxFrcProcCd) resList.Add("SalesCnsTaxFrcProcCd");
            if (this.StockCnsTaxFrcProcCd != target.StockCnsTaxFrcProcCd) resList.Add("StockCnsTaxFrcProcCd");
            if (this.TotalAmountDispWayCd != target.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
            if (this.TtlAmntDspRateDivCd != target.TtlAmntDspRateDivCd) resList.Add("TtlAmntDspRateDivCd");
            if (this.SalesUnPrcFrcProcCd != target.SalesUnPrcFrcProcCd) resList.Add("SalesUnPrcFrcProcCd");
            if (this.StockUnPrcFrcProcCd != target.StockUnPrcFrcProcCd) resList.Add("StockUnPrcFrcProcCd");
            if (this.ConsTaxLayMethod != target.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");

            return resList;
        }

        /// <summary>
        /// �P���v�Z�p�����[�^��r����
        /// </summary>
        /// <param name="unitPriceCalcParam1">��r����UnitPriceCalcParam�N���X�̃C���X�^���X</param>
        /// <param name="unitPriceCalcParam2">��r����UnitPriceCalcParam�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UnitPriceCalcParam�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(UnitPriceCalcParamWork unitPriceCalcParam1, UnitPriceCalcParamWork unitPriceCalcParam2)
        {
            ArrayList resList = new ArrayList();
            if (unitPriceCalcParam1.SectionCode != unitPriceCalcParam2.SectionCode) resList.Add("SectionCode");
            if (unitPriceCalcParam1.GoodsMakerCd != unitPriceCalcParam2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (unitPriceCalcParam1.GoodsNo != unitPriceCalcParam2.GoodsNo) resList.Add("GoodsNo");
            if (unitPriceCalcParam1.GoodsRateRank != unitPriceCalcParam2.GoodsRateRank) resList.Add("GoodsRateRank");
            if (unitPriceCalcParam1.GoodsRateGrpCode != unitPriceCalcParam2.GoodsRateGrpCode) resList.Add("GoodsRateGrpCode");
            if (unitPriceCalcParam1.BLGroupCode != unitPriceCalcParam2.BLGroupCode) resList.Add("BLGroupCode");
            if (unitPriceCalcParam1.BLGoodsCode != unitPriceCalcParam2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (unitPriceCalcParam1.CustomerCode != unitPriceCalcParam2.CustomerCode) resList.Add("CustomerCode");
            if (unitPriceCalcParam1.CustRateGrpCode != unitPriceCalcParam2.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (unitPriceCalcParam1.SupplierCd != unitPriceCalcParam2.SupplierCd) resList.Add("SupplierCd");
            if (unitPriceCalcParam1.PriceApplyDate != unitPriceCalcParam2.PriceApplyDate) resList.Add("PriceApplyDate");
            if (unitPriceCalcParam1.CountFl != unitPriceCalcParam2.CountFl) resList.Add("CountFl");
            if (unitPriceCalcParam1.TaxationDivCd != unitPriceCalcParam2.TaxationDivCd) resList.Add("TaxationDivCd");
            if (unitPriceCalcParam1.TaxRate != unitPriceCalcParam2.TaxRate) resList.Add("TaxRate");
            if (unitPriceCalcParam1.SalesCnsTaxFrcProcCd != unitPriceCalcParam2.SalesCnsTaxFrcProcCd) resList.Add("SalesCnsTaxFrcProcCd");
            if (unitPriceCalcParam1.StockCnsTaxFrcProcCd != unitPriceCalcParam2.StockCnsTaxFrcProcCd) resList.Add("StockCnsTaxFrcProcCd");
            if (unitPriceCalcParam1.TotalAmountDispWayCd != unitPriceCalcParam2.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
            if (unitPriceCalcParam1.TtlAmntDspRateDivCd != unitPriceCalcParam2.TtlAmntDspRateDivCd) resList.Add("TtlAmntDspRateDivCd");
            if (unitPriceCalcParam1.SalesUnPrcFrcProcCd != unitPriceCalcParam2.SalesUnPrcFrcProcCd) resList.Add("SalesUnPrcFrcProcCd");
            if (unitPriceCalcParam1.StockUnPrcFrcProcCd != unitPriceCalcParam2.StockUnPrcFrcProcCd) resList.Add("StockUnPrcFrcProcCd");
            if (unitPriceCalcParam1.ConsTaxLayMethod != unitPriceCalcParam2.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
            if (unitPriceCalcParam1.BLGoodsName != unitPriceCalcParam2.BLGoodsName) resList.Add("BLGoodsName");

            return resList;
        }
    }
    #endregion 

	#region ���P���Z�o���ʃN���X
    /// public class name:   UnitPriceCalcRet
    /// <summary>
    ///                      �P���v�Z����
    /// </summary>
    /// <remarks>
    /// <br>note             :   �P���v�Z���ʃw�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/09  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class UnitPriceCalcRetWork
    {
        /// <summary>�P�����</summary>
        /// <remarks>1:����P���@2:���㌴���@3:�d���P�� 4:�艿 5:��ƌ��� 6:��Ɣ���</remarks>
        private string _unitPriceKind = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>�|���ݒ�敪</summary>
        /// <remarks>A1,A2��</remarks>
        private string _rateSettingDivide = "";

        /// <summary>�|���ݒ�敪�i���i�j</summary>
        /// <remarks>A�`O�@</remarks>
        private string _rateMngGoodsCd = "";

        /// <summary>�|���ݒ薼�́i���i�j</summary>
        /// <remarks>A�F "���[�J�[�{���i"</remarks>
        private string _rateMngGoodsNm = "";

        /// <summary>�|���ݒ�敪�i���Ӑ�j</summary>
        /// <remarks>1�`9�@</remarks>
        private string _rateMngCustCd = "";

        /// <summary>�|���ݒ薼�́i���Ӑ�j</summary>
        /// <remarks>1�F "���Ӑ�{�d����"</remarks>
        private string _rateMngCustNm = "";

        /// <summary>�P���Z�o�敪</summary>
        /// <remarks>1:�|��,2:�����t�o��,3:�e����</remarks>
        private Int32 _unitPrcCalcDiv;

        /// <summary>���i�敪</summary>
        /// <remarks>0:�艿 �Œ�</remarks>
        private Int32 _priceDiv;

        /// <summary>��P��</summary>
        private Double _stdUnitPrice;

        /// <summary>�|��</summary>
        /// <remarks>�������A�������A�d�����A�艿UP��</remarks>
        private Double _rateVal;

        /// <summary>�P���[�������P��</summary>
        private Double _unPrcFracProcUnit;

        /// <summary>�P���[�������敪</summary>
        private Int32 _unPrcFracProcDiv;

        /// <summary>�P���i�Ŕ��C�����j</summary>
        private Double _unitPriceTaxExcFl;

        /// <summary>�P���i�ō��C�����j</summary>
        private Double _unitPriceTaxIncFl;

        /// <summary>�I�[�v�����i�敪</summary>
        private Int32 _openPriceDiv;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�|���D�揇��</summary>
        private Int32 _ratePriorityOrder;

        /// <summary>���i�J�n��</summary>
        /// <remarks>���i�}�X�^�̉��i�J�n��</remarks>
        private DateTime _priceStartDate;

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;


        /// public propaty name  :  UnitPriceKind
        /// <summary>�P����ރv���p�e�B</summary>
        /// <value>1:����P���@2:���㌴���@3:�d���P�� 4:�艿 5:��ƌ��� 6:��Ɣ���</value>
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

        /// public propaty name  :  GoodsNo
        /// <summary>���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  RateSettingDivide
        /// <summary>�|���ݒ�敪�v���p�e�B</summary>
        /// <value>A1,A2��</value>
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
        /// <value>A�`O�@</value>
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
        /// <value>A�F "���[�J�[�{���i"</value>
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
        /// <value>1�`9�@</value>
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
        /// <value>1�F "���Ӑ�{�d����"</value>
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

        /// public propaty name  :  UnitPrcCalcDiv
        /// <summary>�P���Z�o�敪�v���p�e�B</summary>
        /// <value>1:�|��,2:�����t�o��,3:�e����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P���Z�o�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UnitPrcCalcDiv
        {
            get { return _unitPrcCalcDiv; }
            set { _unitPrcCalcDiv = value; }
        }

        /// public propaty name  :  PriceDiv
        /// <summary>���i�敪�v���p�e�B</summary>
        /// <value>0:�艿 �Œ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceDiv
        {
            get { return _priceDiv; }
            set { _priceDiv = value; }
        }

        /// public propaty name  :  StdUnitPrice
        /// <summary>��P���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StdUnitPrice
        {
            get { return _stdUnitPrice; }
            set { _stdUnitPrice = value; }
        }

        /// public propaty name  :  RateVal
        /// <summary>�|���v���p�e�B</summary>
        /// <value>�������A�������A�d�����A�艿UP��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double RateVal
        {
            get { return _rateVal; }
            set { _rateVal = value; }
        }

        /// public propaty name  :  UnPrcFracProcUnit
        /// <summary>�P���[�������P�ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P���[�������P�ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double UnPrcFracProcUnit
        {
            get { return _unPrcFracProcUnit; }
            set { _unPrcFracProcUnit = value; }
        }

        /// public propaty name  :  UnPrcFracProcDiv
        /// <summary>�P���[�������敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P���[�������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UnPrcFracProcDiv
        {
            get { return _unPrcFracProcDiv; }
            set { _unPrcFracProcDiv = value; }
        }

        /// public propaty name  :  UnitPriceTaxExcFl
        /// <summary>�P���i�Ŕ��C�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P���i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double UnitPriceTaxExcFl
        {
            get { return _unitPriceTaxExcFl; }
            set { _unitPriceTaxExcFl = value; }
        }

        /// public propaty name  :  UnitPriceTaxIncFl
        /// <summary>�P���i�ō��C�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P���i�ō��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double UnitPriceTaxIncFl
        {
            get { return _unitPriceTaxIncFl; }
            set { _unitPriceTaxIncFl = value; }
        }

        /// public propaty name  :  OpenPriceDiv
        /// <summary>�I�[�v�����i�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�[�v�����i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OpenPriceDiv
        {
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  RatePriorityOrder
        /// <summary>�|���D�揇�ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���D�揇�ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RatePriorityOrder
        {
            get { return _ratePriorityOrder; }
            set { _ratePriorityOrder = value; }
        }

        /// public propaty name  :  PriceStartDate
        /// <summary>���i�J�n���v���p�e�B</summary>
        /// <value>���i�}�X�^�̉��i�J�n��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
        }

        /// public propaty name  :  PriceStartDateJpFormal
        /// <summary>���i�J�n�� �a��v���p�e�B</summary>
        /// <value>���i�}�X�^�̉��i�J�n��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�J�n�� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriceStartDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _priceStartDate); }
            set { }
        }

        /// public propaty name  :  PriceStartDateJpInFormal
        /// <summary>���i�J�n�� �a��(��)�v���p�e�B</summary>
        /// <value>���i�}�X�^�̉��i�J�n��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�J�n�� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriceStartDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _priceStartDate); }
            set { }
        }

        /// public propaty name  :  PriceStartDateAdFormal
        /// <summary>���i�J�n�� ����v���p�e�B</summary>
        /// <value>���i�}�X�^�̉��i�J�n��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�J�n�� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriceStartDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _priceStartDate); }
            set { }
        }

        /// public propaty name  :  PriceStartDateAdInFormal
        /// <summary>���i�J�n�� ����(��)�v���p�e�B</summary>
        /// <value>���i�}�X�^�̉��i�J�n��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�J�n�� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriceStartDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _priceStartDate); }
            set { }
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


        /// <summary>
        /// �P���v�Z���ʃR���X�g���N�^
        /// </summary>
        /// <returns>UnitPriceCalcRet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UnitPriceCalcRet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UnitPriceCalcRetWork()
        {
        }

        /// <summary>
        /// �P���v�Z���ʃR���X�g���N�^
        /// </summary>
        /// <param name="unitPriceKind">�P�����(1:����P���@2:���㌴���@3:�d���P�� 4:�艿 5:��ƌ��� 6:��Ɣ���)</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="rateSettingDivide">�|���ݒ�敪(A1,A2��)</param>
        /// <param name="rateMngGoodsCd">�|���ݒ�敪�i���i�j(A�`O�@)</param>
        /// <param name="rateMngGoodsNm">�|���ݒ薼�́i���i�j(A�F "���[�J�[�{���i")</param>
        /// <param name="rateMngCustCd">�|���ݒ�敪�i���Ӑ�j(1�`9�@)</param>
        /// <param name="rateMngCustNm">�|���ݒ薼�́i���Ӑ�j(1�F "���Ӑ�{�d����")</param>
        /// <param name="unitPrcCalcDiv">�P���Z�o�敪(1:�|��,2:�����t�o��,3:�e����)</param>
        /// <param name="priceDiv">���i�敪(0:�艿 �Œ�)</param>
        /// <param name="stdUnitPrice">��P��</param>
        /// <param name="rateVal">�|��(�������A�������A�d�����A�艿UP��)</param>
        /// <param name="unPrcFracProcUnit">�P���[�������P��</param>
        /// <param name="unPrcFracProcDiv">�P���[�������敪</param>
        /// <param name="unitPriceTaxExcFl">�P���i�Ŕ��C�����j</param>
        /// <param name="unitPriceTaxIncFl">�P���i�ō��C�����j</param>
        /// <param name="openPriceDiv">�I�[�v�����i�敪</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="ratePriorityOrder">�|���D�揇��</param>
        /// <param name="priceStartDate">���i�J�n��(���i�}�X�^�̉��i�J�n��)</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <returns>UnitPriceCalcRet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UnitPriceCalcRet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UnitPriceCalcRetWork(string unitPriceKind, Int32 goodsMakerCd, string goodsNo, string rateSettingDivide, string rateMngGoodsCd, string rateMngGoodsNm, string rateMngCustCd, string rateMngCustNm, Int32 unitPrcCalcDiv, Int32 priceDiv, Double stdUnitPrice, Double rateVal, Double unPrcFracProcUnit, Int32 unPrcFracProcDiv, Double unitPriceTaxExcFl, Double unitPriceTaxIncFl, Int32 openPriceDiv, string sectionCode, Int32 ratePriorityOrder, DateTime priceStartDate, Int32 supplierCd)
        {
            this._unitPriceKind = unitPriceKind;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsNo = goodsNo;
            this._rateSettingDivide = rateSettingDivide;
            this._rateMngGoodsCd = rateMngGoodsCd;
            this._rateMngGoodsNm = rateMngGoodsNm;
            this._rateMngCustCd = rateMngCustCd;
            this._rateMngCustNm = rateMngCustNm;
            this._unitPrcCalcDiv = unitPrcCalcDiv;
            this._priceDiv = priceDiv;
            this._stdUnitPrice = stdUnitPrice;
            this._rateVal = rateVal;
            this._unPrcFracProcUnit = unPrcFracProcUnit;
            this._unPrcFracProcDiv = unPrcFracProcDiv;
            this._unitPriceTaxExcFl = unitPriceTaxExcFl;
            this._unitPriceTaxIncFl = unitPriceTaxIncFl;
            this._openPriceDiv = openPriceDiv;
            this._sectionCode = sectionCode;
            this._ratePriorityOrder = ratePriorityOrder;
            this.PriceStartDate = priceStartDate;
            this._supplierCd = supplierCd;

        }

        /// <summary>
        /// �P���v�Z���ʕ�������
        /// </summary>
        /// <returns>UnitPriceCalcRet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����UnitPriceCalcRet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UnitPriceCalcRetWork Clone()
        {
            return new UnitPriceCalcRetWork(this._unitPriceKind, this._goodsMakerCd, this._goodsNo, this._rateSettingDivide, this._rateMngGoodsCd, this._rateMngGoodsNm, this._rateMngCustCd, this._rateMngCustNm, this._unitPrcCalcDiv, this._priceDiv, this._stdUnitPrice, this._rateVal, this._unPrcFracProcUnit, this._unPrcFracProcDiv, this._unitPriceTaxExcFl, this._unitPriceTaxIncFl, this._openPriceDiv, this._sectionCode, this._ratePriorityOrder, this._priceStartDate, this._supplierCd);
        }

        /// <summary>
        /// �P���v�Z���ʔ�r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�UnitPriceCalcRet�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UnitPriceCalcRet�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(UnitPriceCalcRetWork target)
        {
            return ( ( this.UnitPriceKind == target.UnitPriceKind )
                 && ( this.GoodsMakerCd == target.GoodsMakerCd )
                 && ( this.GoodsNo == target.GoodsNo )
                 && ( this.RateSettingDivide == target.RateSettingDivide )
                 && ( this.RateMngGoodsCd == target.RateMngGoodsCd )
                 && ( this.RateMngGoodsNm == target.RateMngGoodsNm )
                 && ( this.RateMngCustCd == target.RateMngCustCd )
                 && ( this.RateMngCustNm == target.RateMngCustNm )
                 && ( this.UnitPrcCalcDiv == target.UnitPrcCalcDiv )
                 && ( this.PriceDiv == target.PriceDiv )
                 && ( this.StdUnitPrice == target.StdUnitPrice )
                 && ( this.RateVal == target.RateVal )
                 && ( this.UnPrcFracProcUnit == target.UnPrcFracProcUnit )
                 && ( this.UnPrcFracProcDiv == target.UnPrcFracProcDiv )
                 && ( this.UnitPriceTaxExcFl == target.UnitPriceTaxExcFl )
                 && ( this.UnitPriceTaxIncFl == target.UnitPriceTaxIncFl )
                 && ( this.OpenPriceDiv == target.OpenPriceDiv )
                 && ( this.SectionCode == target.SectionCode )
                 && ( this.RatePriorityOrder == target.RatePriorityOrder )
                 && ( this.PriceStartDate == target.PriceStartDate )
                 && ( this.SupplierCd == target.SupplierCd ) );
        }

        /// <summary>
        /// �P���v�Z���ʔ�r����
        /// </summary>
        /// <param name="unitPriceCalcRet1">
        ///                    ��r����UnitPriceCalcRet�N���X�̃C���X�^���X
        /// </param>
        /// <param name="unitPriceCalcRet2">��r����UnitPriceCalcRet�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UnitPriceCalcRet�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(UnitPriceCalcRetWork unitPriceCalcRet1, UnitPriceCalcRetWork unitPriceCalcRet2)
        {
            return ( ( unitPriceCalcRet1.UnitPriceKind == unitPriceCalcRet2.UnitPriceKind )
                 && ( unitPriceCalcRet1.GoodsMakerCd == unitPriceCalcRet2.GoodsMakerCd )
                 && ( unitPriceCalcRet1.GoodsNo == unitPriceCalcRet2.GoodsNo )
                 && ( unitPriceCalcRet1.RateSettingDivide == unitPriceCalcRet2.RateSettingDivide )
                 && ( unitPriceCalcRet1.RateMngGoodsCd == unitPriceCalcRet2.RateMngGoodsCd )
                 && ( unitPriceCalcRet1.RateMngGoodsNm == unitPriceCalcRet2.RateMngGoodsNm )
                 && ( unitPriceCalcRet1.RateMngCustCd == unitPriceCalcRet2.RateMngCustCd )
                 && ( unitPriceCalcRet1.RateMngCustNm == unitPriceCalcRet2.RateMngCustNm )
                 && ( unitPriceCalcRet1.UnitPrcCalcDiv == unitPriceCalcRet2.UnitPrcCalcDiv )
                 && ( unitPriceCalcRet1.PriceDiv == unitPriceCalcRet2.PriceDiv )
                 && ( unitPriceCalcRet1.StdUnitPrice == unitPriceCalcRet2.StdUnitPrice )
                 && ( unitPriceCalcRet1.RateVal == unitPriceCalcRet2.RateVal )
                 && ( unitPriceCalcRet1.UnPrcFracProcUnit == unitPriceCalcRet2.UnPrcFracProcUnit )
                 && ( unitPriceCalcRet1.UnPrcFracProcDiv == unitPriceCalcRet2.UnPrcFracProcDiv )
                 && ( unitPriceCalcRet1.UnitPriceTaxExcFl == unitPriceCalcRet2.UnitPriceTaxExcFl )
                 && ( unitPriceCalcRet1.UnitPriceTaxIncFl == unitPriceCalcRet2.UnitPriceTaxIncFl )
                 && ( unitPriceCalcRet1.OpenPriceDiv == unitPriceCalcRet2.OpenPriceDiv )
                 && ( unitPriceCalcRet1.SectionCode == unitPriceCalcRet2.SectionCode )
                 && ( unitPriceCalcRet1.RatePriorityOrder == unitPriceCalcRet2.RatePriorityOrder )
                 && ( unitPriceCalcRet1.PriceStartDate == unitPriceCalcRet2.PriceStartDate )
                 && ( unitPriceCalcRet1.SupplierCd == unitPriceCalcRet2.SupplierCd ) );
        }
        /// <summary>
        /// �P���v�Z���ʔ�r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�UnitPriceCalcRet�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UnitPriceCalcRet�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(UnitPriceCalcRetWork target)
        {
            ArrayList resList = new ArrayList();
            if (this.UnitPriceKind != target.UnitPriceKind) resList.Add("UnitPriceKind");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.RateSettingDivide != target.RateSettingDivide) resList.Add("RateSettingDivide");
            if (this.RateMngGoodsCd != target.RateMngGoodsCd) resList.Add("RateMngGoodsCd");
            if (this.RateMngGoodsNm != target.RateMngGoodsNm) resList.Add("RateMngGoodsNm");
            if (this.RateMngCustCd != target.RateMngCustCd) resList.Add("RateMngCustCd");
            if (this.RateMngCustNm != target.RateMngCustNm) resList.Add("RateMngCustNm");
            if (this.UnitPrcCalcDiv != target.UnitPrcCalcDiv) resList.Add("UnitPrcCalcDiv");
            if (this.PriceDiv != target.PriceDiv) resList.Add("PriceDiv");
            if (this.StdUnitPrice != target.StdUnitPrice) resList.Add("StdUnitPrice");
            if (this.RateVal != target.RateVal) resList.Add("RateVal");
            if (this.UnPrcFracProcUnit != target.UnPrcFracProcUnit) resList.Add("UnPrcFracProcUnit");
            if (this.UnPrcFracProcDiv != target.UnPrcFracProcDiv) resList.Add("UnPrcFracProcDiv");
            if (this.UnitPriceTaxExcFl != target.UnitPriceTaxExcFl) resList.Add("UnitPriceTaxExcFl");
            if (this.UnitPriceTaxIncFl != target.UnitPriceTaxIncFl) resList.Add("UnitPriceTaxIncFl");
            if (this.OpenPriceDiv != target.OpenPriceDiv) resList.Add("OpenPriceDiv");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.RatePriorityOrder != target.RatePriorityOrder) resList.Add("RatePriorityOrder");
            if (this.PriceStartDate != target.PriceStartDate) resList.Add("PriceStartDate");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");

            return resList;
        }

        /// <summary>
        /// �P���v�Z���ʔ�r����
        /// </summary>
        /// <param name="unitPriceCalcRet1">��r����UnitPriceCalcRet�N���X�̃C���X�^���X</param>
        /// <param name="unitPriceCalcRet2">��r����UnitPriceCalcRet�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UnitPriceCalcRet�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(UnitPriceCalcRetWork unitPriceCalcRet1, UnitPriceCalcRetWork unitPriceCalcRet2)
        {
            ArrayList resList = new ArrayList();
            if (unitPriceCalcRet1.UnitPriceKind != unitPriceCalcRet2.UnitPriceKind) resList.Add("UnitPriceKind");
            if (unitPriceCalcRet1.GoodsMakerCd != unitPriceCalcRet2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (unitPriceCalcRet1.GoodsNo != unitPriceCalcRet2.GoodsNo) resList.Add("GoodsNo");
            if (unitPriceCalcRet1.RateSettingDivide != unitPriceCalcRet2.RateSettingDivide) resList.Add("RateSettingDivide");
            if (unitPriceCalcRet1.RateMngGoodsCd != unitPriceCalcRet2.RateMngGoodsCd) resList.Add("RateMngGoodsCd");
            if (unitPriceCalcRet1.RateMngGoodsNm != unitPriceCalcRet2.RateMngGoodsNm) resList.Add("RateMngGoodsNm");
            if (unitPriceCalcRet1.RateMngCustCd != unitPriceCalcRet2.RateMngCustCd) resList.Add("RateMngCustCd");
            if (unitPriceCalcRet1.RateMngCustNm != unitPriceCalcRet2.RateMngCustNm) resList.Add("RateMngCustNm");
            if (unitPriceCalcRet1.UnitPrcCalcDiv != unitPriceCalcRet2.UnitPrcCalcDiv) resList.Add("UnitPrcCalcDiv");
            if (unitPriceCalcRet1.PriceDiv != unitPriceCalcRet2.PriceDiv) resList.Add("PriceDiv");
            if (unitPriceCalcRet1.StdUnitPrice != unitPriceCalcRet2.StdUnitPrice) resList.Add("StdUnitPrice");
            if (unitPriceCalcRet1.RateVal != unitPriceCalcRet2.RateVal) resList.Add("RateVal");
            if (unitPriceCalcRet1.UnPrcFracProcUnit != unitPriceCalcRet2.UnPrcFracProcUnit) resList.Add("UnPrcFracProcUnit");
            if (unitPriceCalcRet1.UnPrcFracProcDiv != unitPriceCalcRet2.UnPrcFracProcDiv) resList.Add("UnPrcFracProcDiv");
            if (unitPriceCalcRet1.UnitPriceTaxExcFl != unitPriceCalcRet2.UnitPriceTaxExcFl) resList.Add("UnitPriceTaxExcFl");
            if (unitPriceCalcRet1.UnitPriceTaxIncFl != unitPriceCalcRet2.UnitPriceTaxIncFl) resList.Add("UnitPriceTaxIncFl");
            if (unitPriceCalcRet1.OpenPriceDiv != unitPriceCalcRet2.OpenPriceDiv) resList.Add("OpenPriceDiv");
            if (unitPriceCalcRet1.SectionCode != unitPriceCalcRet2.SectionCode) resList.Add("SectionCode");
            if (unitPriceCalcRet1.RatePriorityOrder != unitPriceCalcRet2.RatePriorityOrder) resList.Add("RatePriorityOrder");
            if (unitPriceCalcRet1.PriceStartDate != unitPriceCalcRet2.PriceStartDate) resList.Add("PriceStartDate");
            if (unitPriceCalcRet1.SupplierCd != unitPriceCalcRet2.SupplierCd) resList.Add("SupplierCd");

            return resList;
        }
    }
    #endregion
}
