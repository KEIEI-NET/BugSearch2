using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StcDtlDataRefWork
    /// <summary>
    ///                      �d�����׃f�[�^�Q�ƃ��[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d�����׃f�[�^�Q�ƃ��[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/12/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StcDtlDataRefWork
    {
        /// <summary>�󒍔ԍ�</summary>
        private Int32 _acceptAnOrderNo;

        /// <summary>�d���`��</summary>
        /// <remarks>0:�d���@�i�󒍃X�e�[�^�X�j</remarks>
        private Int32 _supplierFormal;

        /// <summary>�d���`�[�ԍ�</summary>
        /// <remarks>�����`�[�ԍ��A�d���`�[�ԍ��A���ד`�[�ԍ������˂�</remarks>
        private Int32 _supplierSlipNo;

        /// <summary>�d���s�ԍ�</summary>
        private Int32 _stockRowNo;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���_����</summary>
        private string _sectionGuideNm = "";

        /// <summary>����R�[�h</summary>
        private Int32 _subSectionCode;

        /// <summary>�ۃR�[�h</summary>
        private Int32 _minSectionCode;

        /// <summary>���ʒʔ�</summary>
        private Int64 _commonSeqNo;

        /// <summary>�d�����גʔ�</summary>
        private Int64 _stockSlipDtlNum;

        /// <summary>�d���`���i���j</summary>
        /// <remarks>0:�d��</remarks>
        private Int32 _supplierFormalSrc;

        /// <summary>�d�����גʔԁi���j</summary>
        private Int64 _stockSlipDtlNumSrc;

        /// <summary>�󒍃X�e�[�^�X�i�����j</summary>
        /// <remarks>30:����,40:�o��</remarks>
        private Int32 _acptAnOdrStatusSync;

        /// <summary>���㖾�גʔԁi�����j</summary>
        /// <remarks>�����v�㎞�̎d�����גʔԂ��Z�b�g</remarks>
        private Int64 _salesSlipDtlNumSync;

        /// <summary>�d���`�[�敪�i���ׁj</summary>
        /// <remarks>0:�d��,1:�ԕi,2:�l��</remarks>
        private Int32 _stockSlipCdDtl;

        /// <summary>�d���S���҃R�[�h</summary>
        private string _stockAgentCode = "";

        /// <summary>�d���S���Җ���</summary>
        private string _stockAgentName = "";

        /// <summary>�݌ɊǗ��L���敪</summary>
        /// <remarks>0:�݌ɊǗ����Ȃ�,1:�݌ɊǗ�����</remarks>
        private Int32 _stockMngExistCd;

        /// <summary>���i����</summary>
        private Int32 _goodsKindCode;

        /// <summary>���i���[�J�[�R�[�h</summary>
        /// <remarks>�߯���ޖ���հ�ް�o�^�͈͂��قȂ�</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>���i�敪�O���[�v�R�[�h</summary>
        /// <remarks>���F���i�啪�ރR�[�h</remarks>
        private string _largeGoodsGanreCode = "";

        /// <summary>���i�敪�O���[�v����</summary>
        /// <remarks>���F���i�啪�ޖ���</remarks>
        private string _largeGoodsGanreName = "";

        /// <summary>���i�敪�R�[�h</summary>
        /// <remarks>���F���i�����ރR�[�h</remarks>
        private string _mediumGoodsGanreCode = "";

        /// <summary>���i�敪����</summary>
        /// <remarks>���F���i�����ޖ���</remarks>
        private string _mediumGoodsGanreName = "";

        /// <summary>���i�敪�ڍ׃R�[�h</summary>
        private string _detailGoodsGanreCode = "";

        /// <summary>���i�敪�ڍז���</summary>
        private string _detailGoodsGanreName = "";

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL���i�R�[�h���́i�S�p�j</summary>
        private string _bLGoodsFullName = "";

        /// <summary>���Е��ރR�[�h</summary>
        private Int32 _enterpriseGanreCode;

        /// <summary>���Е��ޖ���</summary>
        private string _enterpriseGanreName = "";

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        /// <summary>�q�ɖ���</summary>
        private string _warehouseName = "";

        /// <summary>�q�ɒI��</summary>
        private string _warehouseShelfNo = "";

        /// <summary>�d���݌Ɏ�񂹋敪</summary>
        /// <remarks>0:���,1:�݌�</remarks>
        private Int32 _stockOrderDivCd;

        /// <summary>�I�[�v�����i�敪</summary>
        /// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
        private Int32 _openPriceDiv;

        /// <summary>�P�ʃR�[�h</summary>
        private Int32 _unitCode;

        /// <summary>�P�ʖ���</summary>
        private string _unitName = "";

        /// <summary>���i�|�������N</summary>
        /// <remarks>���i�̊|���p�����N</remarks>
        private string _goodsRateRank = "";

        /// <summary>���Ӑ�|���O���[�v�R�[�h</summary>
        private Int32 _custRateGrpCode;

        /// <summary>�d����|���O���[�v�R�[�h</summary>
        private Int32 _suppRateGrpCode;

        /// <summary>�艿�i�Ŕ��C�����j</summary>
        /// <remarks>�Ŕ���</remarks>
        private Double _listPriceTaxExcFl;

        /// <summary>�艿�i�ō��C�����j</summary>
        /// <remarks>�ō���</remarks>
        private Double _listPriceTaxIncFl;

        /// <summary>�d����</summary>
        private Double _stockRate;

        /// <summary>�|���ݒ苒�_�i�d���P���j</summary>
        /// <remarks>0:�S�Аݒ�, ���̑�:���_�R�[�h</remarks>
        private string _rateSectStckUnPrc = "";

        /// <summary>�|���ݒ�敪�i�d���P���j</summary>
        /// <remarks>A7,A8,�c</remarks>
        private string _rateDivStckUnPrc = "";

        /// <summary>�P���Z�o�敪�i�d���P���j</summary>
        /// <remarks>1:�|��,2:�����t�o��,3:�e����</remarks>
        private Int32 _unPrcCalcCdStckUnPrc;

        /// <summary>���i�敪�i�d���P���j</summary>
        /// <remarks>0:�艿,1:�o�^�̔��X���i,�c</remarks>
        private Int32 _priceCdStckUnPrc;

        /// <summary>��P���i�d���P���j</summary>
        private Double _stdUnPrcStckUnPrc;

        /// <summary>�[�������P�ʁi�d���P���j</summary>
        private Double _fracProcUnitStcUnPrc;

        /// <summary>�[�������i�d���P���j</summary>
        /// <remarks>0:�؏グ,1:�؎̂�,2:�l�̌ܓ�</remarks>
        private Int32 _fracProcStckUnPrc;

        /// <summary>�d���P���i�Ŕ��C�����j</summary>
        /// <remarks>�Ŕ���</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>�d���P���i�ō��C�����j</summary>
        /// <remarks>�ō���</remarks>
        private Double _stockUnitTaxPriceFl;

        /// <summary>�d���P���ύX�敪</summary>
        /// <remarks>1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ</remarks>
        private Int32 _stockUnitChngDiv;

        /// <summary>�ύX�O�d���P���i�����j</summary>
        /// <remarks>�Ŕ����A�|���Z�o����</remarks>
        private Double _bfStockUnitPriceFl;

        /// <summary>BL���i�R�[�h�i�|���j</summary>
        /// <remarks>�|���Z�o���Ɏg�p����BL�R�[�h�i���i�������ʁj</remarks>
        private Int32 _rateBLGoodsCode;

        /// <summary>BL���i�R�[�h���́i�|���j</summary>
        /// <remarks>�|���Z�o���Ɏg�p����BL�R�[�h���́i���i�������ʁj</remarks>
        private string _rateBLGoodsName = "";

        /// <summary>�����敪�R�[�h</summary>
        private Int32 _bargainCd;

        /// <summary>�����敪����</summary>
        private string _bargainNm = "";

        /// <summary>�d����</summary>
        private Double _stockCount;

        /// <summary>�d�����z�i�Ŕ����j</summary>
        private Int64 _stockPriceTaxExc;

        /// <summary>�d�����z�i�ō��݁j</summary>
        private Int64 _stockPriceTaxInc;

        /// <summary>�d�����i�敪</summary>
        /// <remarks>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,6:���v����</remarks>
        private Int32 _stockGoodsCd;

        /// <summary>�d�����z����Ŋz</summary>
        /// <remarks>�d�����z�i�ō��݁j- �d�����z�i�Ŕ����j������Œ����z�����˂�</remarks>
        private Int64 _stockPriceConsTax;

        /// <summary>����Œ����z</summary>
        private Int64 _taxAdjust;

        /// <summary>�c�������z</summary>
        private Int64 _balanceAdjust;

        /// <summary>�ېŋ敪</summary>
        /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
        private Int32 _taxationCode;

        /// <summary>�d���`�[���ה��l1</summary>
        private string _stockDtiSlipNote1 = "";

        /// <summary>�̔���R�[�h</summary>
        private Int32 _salesCustomerCode;

        /// <summary>�̔��於��</summary>
        private string _salesCustomerName = "";

        /// <summary>�����ԍ�</summary>
        /// <remarks>�����p</remarks>
        private string _orderNumber = "";

        /// <summary>�`�[�����P</summary>
        private string _slipMemo1 = "";

        /// <summary>�`�[�����Q</summary>
        private string _slipMemo2 = "";

        /// <summary>�`�[�����R</summary>
        private string _slipMemo3 = "";

        /// <summary>�`�[�����S</summary>
        private string _slipMemo4 = "";

        /// <summary>�`�[�����T</summary>
        private string _slipMemo5 = "";

        /// <summary>�`�[�����U</summary>
        private string _slipMemo6 = "";

        /// <summary>�Г������P</summary>
        private string _insideMemo1 = "";

        /// <summary>�Г������Q</summary>
        private string _insideMemo2 = "";

        /// <summary>�Г������R</summary>
        private string _insideMemo3 = "";

        /// <summary>�Г������S</summary>
        private string _insideMemo4 = "";

        /// <summary>�Г������T</summary>
        private string _insideMemo5 = "";

        /// <summary>�Г������U</summary>
        private string _insideMemo6 = "";

        /// <summary>�d���`�F�b�N�敪�i�����j</summary>
        /// <remarks>0:������,1:�����ρ@�i���׃f�[�^�Ǝd����`�[���ׂ̔�r�j</remarks>
        private Int32 _stockCheckDivCAddUp;

        /// <summary>�d���`�F�b�N�敪�i�����j</summary>
        /// <remarks>0:������,1:�����ρ@�i���׃f�[�^�Ǝd����`�[���ׂ̔�r�j</remarks>
        private Int32 _stockCheckDivDaily;


        /// public propaty name  :  AcceptAnOrderNo
        /// <summary>�󒍔ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcceptAnOrderNo
        {
            get { return _acceptAnOrderNo; }
            set { _acceptAnOrderNo = value; }
        }

        /// public propaty name  :  SupplierFormal
        /// <summary>�d���`���v���p�e�B</summary>
        /// <value>0:�d���@�i�󒍃X�e�[�^�X�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierFormal
        {
            get { return _supplierFormal; }
            set { _supplierFormal = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>�d���`�[�ԍ��v���p�e�B</summary>
        /// <value>�����`�[�ԍ��A�d���`�[�ԍ��A���ד`�[�ԍ������˂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  StockRowNo
        /// <summary>�d���s�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockRowNo
        {
            get { return _stockRowNo; }
            set { _stockRowNo = value; }
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

        /// public propaty name  :  SectionGuideNm
        /// <summary>���_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  SubSectionCode
        /// <summary>����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SubSectionCode
        {
            get { return _subSectionCode; }
            set { _subSectionCode = value; }
        }

        /// public propaty name  :  MinSectionCode
        /// <summary>�ۃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ۃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MinSectionCode
        {
            get { return _minSectionCode; }
            set { _minSectionCode = value; }
        }

        /// public propaty name  :  CommonSeqNo
        /// <summary>���ʒʔԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ʒʔԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CommonSeqNo
        {
            get { return _commonSeqNo; }
            set { _commonSeqNo = value; }
        }

        /// public propaty name  :  StockSlipDtlNum
        /// <summary>�d�����גʔԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����גʔԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockSlipDtlNum
        {
            get { return _stockSlipDtlNum; }
            set { _stockSlipDtlNum = value; }
        }

        /// public propaty name  :  SupplierFormalSrc
        /// <summary>�d���`���i���j�v���p�e�B</summary>
        /// <value>0:�d��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`���i���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierFormalSrc
        {
            get { return _supplierFormalSrc; }
            set { _supplierFormalSrc = value; }
        }

        /// public propaty name  :  StockSlipDtlNumSrc
        /// <summary>�d�����גʔԁi���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����גʔԁi���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockSlipDtlNumSrc
        {
            get { return _stockSlipDtlNumSrc; }
            set { _stockSlipDtlNumSrc = value; }
        }

        /// public propaty name  :  AcptAnOdrStatusSync
        /// <summary>�󒍃X�e�[�^�X�i�����j�v���p�e�B</summary>
        /// <value>30:����,40:�o��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X�i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptAnOdrStatusSync
        {
            get { return _acptAnOdrStatusSync; }
            set { _acptAnOdrStatusSync = value; }
        }

        /// public propaty name  :  SalesSlipDtlNumSync
        /// <summary>���㖾�גʔԁi�����j�v���p�e�B</summary>
        /// <value>�����v�㎞�̎d�����גʔԂ��Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㖾�גʔԁi�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesSlipDtlNumSync
        {
            get { return _salesSlipDtlNumSync; }
            set { _salesSlipDtlNumSync = value; }
        }

        /// public propaty name  :  StockSlipCdDtl
        /// <summary>�d���`�[�敪�i���ׁj�v���p�e�B</summary>
        /// <value>0:�d��,1:�ԕi,2:�l��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�敪�i���ׁj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockSlipCdDtl
        {
            get { return _stockSlipCdDtl; }
            set { _stockSlipCdDtl = value; }
        }

        /// public propaty name  :  StockAgentCode
        /// <summary>�d���S���҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAgentCode
        {
            get { return _stockAgentCode; }
            set { _stockAgentCode = value; }
        }

        /// public propaty name  :  StockAgentName
        /// <summary>�d���S���Җ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���S���Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAgentName
        {
            get { return _stockAgentName; }
            set { _stockAgentName = value; }
        }

        /// public propaty name  :  StockMngExistCd
        /// <summary>�݌ɊǗ��L���敪�v���p�e�B</summary>
        /// <value>0:�݌ɊǗ����Ȃ�,1:�݌ɊǗ�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɊǗ��L���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockMngExistCd
        {
            get { return _stockMngExistCd; }
            set { _stockMngExistCd = value; }
        }

        /// public propaty name  :  GoodsKindCode
        /// <summary>���i�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsKindCode
        {
            get { return _goodsKindCode; }
            set { _goodsKindCode = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>�߯���ޖ���հ�ް�o�^�͈͂��قȂ�</value>
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

        /// public propaty name  :  MakerName
        /// <summary>���[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
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

        /// public propaty name  :  GoodsName
        /// <summary>���i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  LargeGoodsGanreCode
        /// <summary>���i�敪�O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>���F���i�啪�ރR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LargeGoodsGanreCode
        {
            get { return _largeGoodsGanreCode; }
            set { _largeGoodsGanreCode = value; }
        }

        /// public propaty name  :  LargeGoodsGanreName
        /// <summary>���i�敪�O���[�v���̃v���p�e�B</summary>
        /// <value>���F���i�啪�ޖ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�O���[�v���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LargeGoodsGanreName
        {
            get { return _largeGoodsGanreName; }
            set { _largeGoodsGanreName = value; }
        }

        /// public propaty name  :  MediumGoodsGanreCode
        /// <summary>���i�敪�R�[�h�v���p�e�B</summary>
        /// <value>���F���i�����ރR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MediumGoodsGanreCode
        {
            get { return _mediumGoodsGanreCode; }
            set { _mediumGoodsGanreCode = value; }
        }

        /// public propaty name  :  MediumGoodsGanreName
        /// <summary>���i�敪���̃v���p�e�B</summary>
        /// <value>���F���i�����ޖ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MediumGoodsGanreName
        {
            get { return _mediumGoodsGanreName; }
            set { _mediumGoodsGanreName = value; }
        }

        /// public propaty name  :  DetailGoodsGanreCode
        /// <summary>���i�敪�ڍ׃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�ڍ׃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DetailGoodsGanreCode
        {
            get { return _detailGoodsGanreCode; }
            set { _detailGoodsGanreCode = value; }
        }

        /// public propaty name  :  DetailGoodsGanreName
        /// <summary>���i�敪�ڍז��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�ڍז��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DetailGoodsGanreName
        {
            get { return _detailGoodsGanreName; }
            set { _detailGoodsGanreName = value; }
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

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL���i�R�[�h���́i�S�p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i�S�p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set { _bLGoodsFullName = value; }
        }

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>���Е��ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Е��ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnterpriseGanreCode
        {
            get { return _enterpriseGanreCode; }
            set { _enterpriseGanreCode = value; }
        }

        /// public propaty name  :  EnterpriseGanreName
        /// <summary>���Е��ޖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Е��ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseGanreName
        {
            get { return _enterpriseGanreName; }
            set { _enterpriseGanreName = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  WarehouseName
        /// <summary>�q�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>�q�ɒI�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɒI�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  StockOrderDivCd
        /// <summary>�d���݌Ɏ�񂹋敪�v���p�e�B</summary>
        /// <value>0:���,1:�݌�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���݌Ɏ�񂹋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockOrderDivCd
        {
            get { return _stockOrderDivCd; }
            set { _stockOrderDivCd = value; }
        }

        /// public propaty name  :  OpenPriceDiv
        /// <summary>�I�[�v�����i�敪�v���p�e�B</summary>
        /// <value>0:�ʏ�^1:�I�[�v�����i</value>
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

        /// public propaty name  :  UnitCode
        /// <summary>�P�ʃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P�ʃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UnitCode
        {
            get { return _unitCode; }
            set { _unitCode = value; }
        }

        /// public propaty name  :  UnitName
        /// <summary>�P�ʖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P�ʖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UnitName
        {
            get { return _unitName; }
            set { _unitName = value; }
        }

        /// public propaty name  :  GoodsRateRank
        /// <summary>���i�|�������N�v���p�e�B</summary>
        /// <value>���i�̊|���p�����N</value>
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

        /// public propaty name  :  SuppRateGrpCode
        /// <summary>�d����|���O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����|���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SuppRateGrpCode
        {
            get { return _suppRateGrpCode; }
            set { _suppRateGrpCode = value; }
        }

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>�艿�i�Ŕ��C�����j�v���p�e�B</summary>
        /// <value>�Ŕ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPriceTaxExcFl
        {
            get { return _listPriceTaxExcFl; }
            set { _listPriceTaxExcFl = value; }
        }

        /// public propaty name  :  ListPriceTaxIncFl
        /// <summary>�艿�i�ō��C�����j�v���p�e�B</summary>
        /// <value>�ō���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�i�ō��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPriceTaxIncFl
        {
            get { return _listPriceTaxIncFl; }
            set { _listPriceTaxIncFl = value; }
        }

        /// public propaty name  :  StockRate
        /// <summary>�d�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockRate
        {
            get { return _stockRate; }
            set { _stockRate = value; }
        }

        /// public propaty name  :  RateSectStckUnPrc
        /// <summary>�|���ݒ苒�_�i�d���P���j�v���p�e�B</summary>
        /// <value>0:�S�Аݒ�, ���̑�:���_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���ݒ苒�_�i�d���P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateSectStckUnPrc
        {
            get { return _rateSectStckUnPrc; }
            set { _rateSectStckUnPrc = value; }
        }

        /// public propaty name  :  RateDivStckUnPrc
        /// <summary>�|���ݒ�敪�i�d���P���j�v���p�e�B</summary>
        /// <value>A7,A8,�c</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���ݒ�敪�i�d���P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateDivStckUnPrc
        {
            get { return _rateDivStckUnPrc; }
            set { _rateDivStckUnPrc = value; }
        }

        /// public propaty name  :  UnPrcCalcCdStckUnPrc
        /// <summary>�P���Z�o�敪�i�d���P���j�v���p�e�B</summary>
        /// <value>1:�|��,2:�����t�o��,3:�e����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P���Z�o�敪�i�d���P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UnPrcCalcCdStckUnPrc
        {
            get { return _unPrcCalcCdStckUnPrc; }
            set { _unPrcCalcCdStckUnPrc = value; }
        }

        /// public propaty name  :  PriceCdStckUnPrc
        /// <summary>���i�敪�i�d���P���j�v���p�e�B</summary>
        /// <value>0:�艿,1:�o�^�̔��X���i,�c</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�i�d���P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceCdStckUnPrc
        {
            get { return _priceCdStckUnPrc; }
            set { _priceCdStckUnPrc = value; }
        }

        /// public propaty name  :  StdUnPrcStckUnPrc
        /// <summary>��P���i�d���P���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��P���i�d���P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StdUnPrcStckUnPrc
        {
            get { return _stdUnPrcStckUnPrc; }
            set { _stdUnPrcStckUnPrc = value; }
        }

        /// public propaty name  :  FracProcUnitStcUnPrc
        /// <summary>�[�������P�ʁi�d���P���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�������P�ʁi�d���P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double FracProcUnitStcUnPrc
        {
            get { return _fracProcUnitStcUnPrc; }
            set { _fracProcUnitStcUnPrc = value; }
        }

        /// public propaty name  :  FracProcStckUnPrc
        /// <summary>�[�������i�d���P���j�v���p�e�B</summary>
        /// <value>0:�؏グ,1:�؎̂�,2:�l�̌ܓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�������i�d���P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FracProcStckUnPrc
        {
            get { return _fracProcStckUnPrc; }
            set { _fracProcStckUnPrc = value; }
        }

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>�d���P���i�Ŕ��C�����j�v���p�e�B</summary>
        /// <value>�Ŕ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  StockUnitTaxPriceFl
        /// <summary>�d���P���i�ō��C�����j�v���p�e�B</summary>
        /// <value>�ō���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���i�ō��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockUnitTaxPriceFl
        {
            get { return _stockUnitTaxPriceFl; }
            set { _stockUnitTaxPriceFl = value; }
        }

        /// public propaty name  :  StockUnitChngDiv
        /// <summary>�d���P���ύX�敪�v���p�e�B</summary>
        /// <value>1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���ύX�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockUnitChngDiv
        {
            get { return _stockUnitChngDiv; }
            set { _stockUnitChngDiv = value; }
        }

        /// public propaty name  :  BfStockUnitPriceFl
        /// <summary>�ύX�O�d���P���i�����j�v���p�e�B</summary>
        /// <value>�Ŕ����A�|���Z�o����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ύX�O�d���P���i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double BfStockUnitPriceFl
        {
            get { return _bfStockUnitPriceFl; }
            set { _bfStockUnitPriceFl = value; }
        }

        /// public propaty name  :  RateBLGoodsCode
        /// <summary>BL���i�R�[�h�i�|���j�v���p�e�B</summary>
        /// <value>�|���Z�o���Ɏg�p����BL�R�[�h�i���i�������ʁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�i�|���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RateBLGoodsCode
        {
            get { return _rateBLGoodsCode; }
            set { _rateBLGoodsCode = value; }
        }

        /// public propaty name  :  RateBLGoodsName
        /// <summary>BL���i�R�[�h���́i�|���j�v���p�e�B</summary>
        /// <value>�|���Z�o���Ɏg�p����BL�R�[�h���́i���i�������ʁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i�|���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateBLGoodsName
        {
            get { return _rateBLGoodsName; }
            set { _rateBLGoodsName = value; }
        }

        /// public propaty name  :  BargainCd
        /// <summary>�����敪�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BargainCd
        {
            get { return _bargainCd; }
            set { _bargainCd = value; }
        }

        /// public propaty name  :  BargainNm
        /// <summary>�����敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BargainNm
        {
            get { return _bargainNm; }
            set { _bargainNm = value; }
        }

        /// public propaty name  :  StockCount
        /// <summary>�d�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockCount
        {
            get { return _stockCount; }
            set { _stockCount = value; }
        }

        /// public propaty name  :  StockPriceTaxExc
        /// <summary>�d�����z�i�Ŕ����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockPriceTaxExc
        {
            get { return _stockPriceTaxExc; }
            set { _stockPriceTaxExc = value; }
        }

        /// public propaty name  :  StockPriceTaxInc
        /// <summary>�d�����z�i�ō��݁j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockPriceTaxInc
        {
            get { return _stockPriceTaxInc; }
            set { _stockPriceTaxInc = value; }
        }

        /// public propaty name  :  StockGoodsCd
        /// <summary>�d�����i�敪�v���p�e�B</summary>
        /// <value>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,6:���v����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockGoodsCd
        {
            get { return _stockGoodsCd; }
            set { _stockGoodsCd = value; }
        }

        /// public propaty name  :  StockPriceConsTax
        /// <summary>�d�����z����Ŋz�v���p�e�B</summary>
        /// <value>�d�����z�i�ō��݁j- �d�����z�i�Ŕ����j������Œ����z�����˂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z����Ŋz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockPriceConsTax
        {
            get { return _stockPriceConsTax; }
            set { _stockPriceConsTax = value; }
        }

        /// public propaty name  :  TaxAdjust
        /// <summary>����Œ����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����Œ����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TaxAdjust
        {
            get { return _taxAdjust; }
            set { _taxAdjust = value; }
        }

        /// public propaty name  :  BalanceAdjust
        /// <summary>�c�������z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �c�������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 BalanceAdjust
        {
            get { return _balanceAdjust; }
            set { _balanceAdjust = value; }
        }

        /// public propaty name  :  TaxationCode
        /// <summary>�ېŋ敪�v���p�e�B</summary>
        /// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ېŋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TaxationCode
        {
            get { return _taxationCode; }
            set { _taxationCode = value; }
        }

        /// public propaty name  :  StockDtiSlipNote1
        /// <summary>�d���`�[���ה��l1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[���ה��l1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockDtiSlipNote1
        {
            get { return _stockDtiSlipNote1; }
            set { _stockDtiSlipNote1 = value; }
        }

        /// public propaty name  :  SalesCustomerCode
        /// <summary>�̔���R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCustomerCode
        {
            get { return _salesCustomerCode; }
            set { _salesCustomerCode = value; }
        }

        /// public propaty name  :  SalesCustomerName
        /// <summary>�̔��於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesCustomerName
        {
            get { return _salesCustomerName; }
            set { _salesCustomerName = value; }
        }

        /// public propaty name  :  OrderNumber
        /// <summary>�����ԍ��v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OrderNumber
        {
            get { return _orderNumber; }
            set { _orderNumber = value; }
        }

        /// public propaty name  :  SlipMemo1
        /// <summary>�`�[�����P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�����P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipMemo1
        {
            get { return _slipMemo1; }
            set { _slipMemo1 = value; }
        }

        /// public propaty name  :  SlipMemo2
        /// <summary>�`�[�����Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�����Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipMemo2
        {
            get { return _slipMemo2; }
            set { _slipMemo2 = value; }
        }

        /// public propaty name  :  SlipMemo3
        /// <summary>�`�[�����R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�����R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipMemo3
        {
            get { return _slipMemo3; }
            set { _slipMemo3 = value; }
        }

        /// public propaty name  :  SlipMemo4
        /// <summary>�`�[�����S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�����S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipMemo4
        {
            get { return _slipMemo4; }
            set { _slipMemo4 = value; }
        }

        /// public propaty name  :  SlipMemo5
        /// <summary>�`�[�����T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�����T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipMemo5
        {
            get { return _slipMemo5; }
            set { _slipMemo5 = value; }
        }

        /// public propaty name  :  SlipMemo6
        /// <summary>�`�[�����U�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�����U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipMemo6
        {
            get { return _slipMemo6; }
            set { _slipMemo6 = value; }
        }

        /// public propaty name  :  InsideMemo1
        /// <summary>�Г������P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Г������P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InsideMemo1
        {
            get { return _insideMemo1; }
            set { _insideMemo1 = value; }
        }

        /// public propaty name  :  InsideMemo2
        /// <summary>�Г������Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Г������Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InsideMemo2
        {
            get { return _insideMemo2; }
            set { _insideMemo2 = value; }
        }

        /// public propaty name  :  InsideMemo3
        /// <summary>�Г������R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Г������R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InsideMemo3
        {
            get { return _insideMemo3; }
            set { _insideMemo3 = value; }
        }

        /// public propaty name  :  InsideMemo4
        /// <summary>�Г������S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Г������S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InsideMemo4
        {
            get { return _insideMemo4; }
            set { _insideMemo4 = value; }
        }

        /// public propaty name  :  InsideMemo5
        /// <summary>�Г������T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Г������T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InsideMemo5
        {
            get { return _insideMemo5; }
            set { _insideMemo5 = value; }
        }

        /// public propaty name  :  InsideMemo6
        /// <summary>�Г������U�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Г������U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InsideMemo6
        {
            get { return _insideMemo6; }
            set { _insideMemo6 = value; }
        }

        /// public propaty name  :  StockCheckDivCAddUp
        /// <summary>�d���`�F�b�N�敪�i�����j�v���p�e�B</summary>
        /// <value>0:������,1:�����ρ@�i���׃f�[�^�Ǝd����`�[���ׂ̔�r�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�F�b�N�敪�i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockCheckDivCAddUp
        {
            get { return _stockCheckDivCAddUp; }
            set { _stockCheckDivCAddUp = value; }
        }

        /// public propaty name  :  StockCheckDivDaily
        /// <summary>�d���`�F�b�N�敪�i�����j�v���p�e�B</summary>
        /// <value>0:������,1:�����ρ@�i���׃f�[�^�Ǝd����`�[���ׂ̔�r�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�F�b�N�敪�i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockCheckDivDaily
        {
            get { return _stockCheckDivDaily; }
            set { _stockCheckDivDaily = value; }
        }


        /// <summary>
        /// �d�����׃f�[�^�Q�ƃ��[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StcDtlDataRefWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StcDtlDataRefWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StcDtlDataRefWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>StcDtlDataRefWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   StcDtlDataRefWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class StcDtlDataRefWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StcDtlDataRefWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StcDtlDataRefWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StcDtlDataRefWork || graph is ArrayList || graph is StcDtlDataRefWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(StcDtlDataRefWork).FullName));

            if (graph != null && graph is StcDtlDataRefWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StcDtlDataRefWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StcDtlDataRefWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StcDtlDataRefWork[])graph).Length;
            }
            else if (graph is StcDtlDataRefWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�󒍔ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //AcceptAnOrderNo
            //�d���`��
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //�d���`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //�d���s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //StockRowNo
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���_����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //�ۃR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //MinSectionCode
            //���ʒʔ�
            serInfo.MemberInfo.Add(typeof(Int64)); //CommonSeqNo
            //�d�����גʔ�
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSlipDtlNum
            //�d���`���i���j
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormalSrc
            //�d�����גʔԁi���j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSlipDtlNumSrc
            //�󒍃X�e�[�^�X�i�����j
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatusSync
            //���㖾�גʔԁi�����j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSlipDtlNumSync
            //�d���`�[�敪�i���ׁj
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSlipCdDtl
            //�d���S���҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentCode
            //�d���S���Җ���
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentName
            //�݌ɊǗ��L���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockMngExistCd
            //���i����
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsKindCode
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //���i�敪�O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //LargeGoodsGanreCode
            //���i�敪�O���[�v����
            serInfo.MemberInfo.Add(typeof(string)); //LargeGoodsGanreName
            //���i�敪�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //MediumGoodsGanreCode
            //���i�敪����
            serInfo.MemberInfo.Add(typeof(string)); //MediumGoodsGanreName
            //���i�敪�ڍ׃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //DetailGoodsGanreCode
            //���i�敪�ڍז���
            serInfo.MemberInfo.Add(typeof(string)); //DetailGoodsGanreName
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL���i�R�[�h���́i�S�p�j
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //���Е��ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterpriseGanreCode
            //���Е��ޖ���
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseGanreName
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //�q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //�q�ɒI��
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //�d���݌Ɏ�񂹋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockOrderDivCd
            //�I�[�v�����i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv
            //�P�ʃR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //UnitCode
            //�P�ʖ���
            serInfo.MemberInfo.Add(typeof(string)); //UnitName
            //���i�|�������N
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRateRank
            //���Ӑ�|���O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustRateGrpCode
            //�d����|���O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppRateGrpCode
            //�艿�i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            //�艿�i�ō��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxIncFl
            //�d����
            serInfo.MemberInfo.Add(typeof(Double)); //StockRate
            //�|���ݒ苒�_�i�d���P���j
            serInfo.MemberInfo.Add(typeof(string)); //RateSectStckUnPrc
            //�|���ݒ�敪�i�d���P���j
            serInfo.MemberInfo.Add(typeof(string)); //RateDivStckUnPrc
            //�P���Z�o�敪�i�d���P���j
            serInfo.MemberInfo.Add(typeof(Int32)); //UnPrcCalcCdStckUnPrc
            //���i�敪�i�d���P���j
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceCdStckUnPrc
            //��P���i�d���P���j
            serInfo.MemberInfo.Add(typeof(Double)); //StdUnPrcStckUnPrc
            //�[�������P�ʁi�d���P���j
            serInfo.MemberInfo.Add(typeof(Double)); //FracProcUnitStcUnPrc
            //�[�������i�d���P���j
            serInfo.MemberInfo.Add(typeof(Int32)); //FracProcStckUnPrc
            //�d���P���i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //�d���P���i�ō��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitTaxPriceFl
            //�d���P���ύX�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockUnitChngDiv
            //�ύX�O�d���P���i�����j
            serInfo.MemberInfo.Add(typeof(Double)); //BfStockUnitPriceFl
            //BL���i�R�[�h�i�|���j
            serInfo.MemberInfo.Add(typeof(Int32)); //RateBLGoodsCode
            //BL���i�R�[�h���́i�|���j
            serInfo.MemberInfo.Add(typeof(string)); //RateBLGoodsName
            //�����敪�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BargainCd
            //�����敪����
            serInfo.MemberInfo.Add(typeof(string)); //BargainNm
            //�d����
            serInfo.MemberInfo.Add(typeof(Double)); //StockCount
            //�d�����z�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxExc
            //�d�����z�i�ō��݁j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxInc
            //�d�����i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockGoodsCd
            //�d�����z����Ŋz
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceConsTax
            //����Œ����z
            serInfo.MemberInfo.Add(typeof(Int64)); //TaxAdjust
            //�c�������z
            serInfo.MemberInfo.Add(typeof(Int64)); //BalanceAdjust
            //�ېŋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationCode
            //�d���`�[���ה��l1
            serInfo.MemberInfo.Add(typeof(string)); //StockDtiSlipNote1
            //�̔���R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCustomerCode
            //�̔��於��
            serInfo.MemberInfo.Add(typeof(string)); //SalesCustomerName
            //�����ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //OrderNumber
            //�`�[�����P
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo1
            //�`�[�����Q
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo2
            //�`�[�����R
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo3
            //�`�[�����S
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo4
            //�`�[�����T
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo5
            //�`�[�����U
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo6
            //�Г������P
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo1
            //�Г������Q
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo2
            //�Г������R
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo3
            //�Г������S
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo4
            //�Г������T
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo5
            //�Г������U
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo6
            //�d���`�F�b�N�敪�i�����j
            serInfo.MemberInfo.Add(typeof(Int32)); //StockCheckDivCAddUp
            //�d���`�F�b�N�敪�i�����j
            serInfo.MemberInfo.Add(typeof(Int32)); //StockCheckDivDaily


            serInfo.Serialize(writer, serInfo);
            if (graph is StcDtlDataRefWork)
            {
                StcDtlDataRefWork temp = (StcDtlDataRefWork)graph;

                SetStcDtlDataRefWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StcDtlDataRefWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StcDtlDataRefWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StcDtlDataRefWork temp in lst)
                {
                    SetStcDtlDataRefWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StcDtlDataRefWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 87;

        /// <summary>
        ///  StcDtlDataRefWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StcDtlDataRefWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetStcDtlDataRefWork(System.IO.BinaryWriter writer, StcDtlDataRefWork temp)
        {
            //�󒍔ԍ�
            writer.Write(temp.AcceptAnOrderNo);
            //�d���`��
            writer.Write(temp.SupplierFormal);
            //�d���`�[�ԍ�
            writer.Write(temp.SupplierSlipNo);
            //�d���s�ԍ�
            writer.Write(temp.StockRowNo);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���_����
            writer.Write(temp.SectionGuideNm);
            //����R�[�h
            writer.Write(temp.SubSectionCode);
            //�ۃR�[�h
            writer.Write(temp.MinSectionCode);
            //���ʒʔ�
            writer.Write(temp.CommonSeqNo);
            //�d�����גʔ�
            writer.Write(temp.StockSlipDtlNum);
            //�d���`���i���j
            writer.Write(temp.SupplierFormalSrc);
            //�d�����גʔԁi���j
            writer.Write(temp.StockSlipDtlNumSrc);
            //�󒍃X�e�[�^�X�i�����j
            writer.Write(temp.AcptAnOdrStatusSync);
            //���㖾�גʔԁi�����j
            writer.Write(temp.SalesSlipDtlNumSync);
            //�d���`�[�敪�i���ׁj
            writer.Write(temp.StockSlipCdDtl);
            //�d���S���҃R�[�h
            writer.Write(temp.StockAgentCode);
            //�d���S���Җ���
            writer.Write(temp.StockAgentName);
            //�݌ɊǗ��L���敪
            writer.Write(temp.StockMngExistCd);
            //���i����
            writer.Write(temp.GoodsKindCode);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���[�J�[����
            writer.Write(temp.MakerName);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i����
            writer.Write(temp.GoodsName);
            //���i�敪�O���[�v�R�[�h
            writer.Write(temp.LargeGoodsGanreCode);
            //���i�敪�O���[�v����
            writer.Write(temp.LargeGoodsGanreName);
            //���i�敪�R�[�h
            writer.Write(temp.MediumGoodsGanreCode);
            //���i�敪����
            writer.Write(temp.MediumGoodsGanreName);
            //���i�敪�ڍ׃R�[�h
            writer.Write(temp.DetailGoodsGanreCode);
            //���i�敪�ڍז���
            writer.Write(temp.DetailGoodsGanreName);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //BL���i�R�[�h���́i�S�p�j
            writer.Write(temp.BLGoodsFullName);
            //���Е��ރR�[�h
            writer.Write(temp.EnterpriseGanreCode);
            //���Е��ޖ���
            writer.Write(temp.EnterpriseGanreName);
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //�q�ɖ���
            writer.Write(temp.WarehouseName);
            //�q�ɒI��
            writer.Write(temp.WarehouseShelfNo);
            //�d���݌Ɏ�񂹋敪
            writer.Write(temp.StockOrderDivCd);
            //�I�[�v�����i�敪
            writer.Write(temp.OpenPriceDiv);
            //�P�ʃR�[�h
            writer.Write(temp.UnitCode);
            //�P�ʖ���
            writer.Write(temp.UnitName);
            //���i�|�������N
            writer.Write(temp.GoodsRateRank);
            //���Ӑ�|���O���[�v�R�[�h
            writer.Write(temp.CustRateGrpCode);
            //�d����|���O���[�v�R�[�h
            writer.Write(temp.SuppRateGrpCode);
            //�艿�i�Ŕ��C�����j
            writer.Write(temp.ListPriceTaxExcFl);
            //�艿�i�ō��C�����j
            writer.Write(temp.ListPriceTaxIncFl);
            //�d����
            writer.Write(temp.StockRate);
            //�|���ݒ苒�_�i�d���P���j
            writer.Write(temp.RateSectStckUnPrc);
            //�|���ݒ�敪�i�d���P���j
            writer.Write(temp.RateDivStckUnPrc);
            //�P���Z�o�敪�i�d���P���j
            writer.Write(temp.UnPrcCalcCdStckUnPrc);
            //���i�敪�i�d���P���j
            writer.Write(temp.PriceCdStckUnPrc);
            //��P���i�d���P���j
            writer.Write(temp.StdUnPrcStckUnPrc);
            //�[�������P�ʁi�d���P���j
            writer.Write(temp.FracProcUnitStcUnPrc);
            //�[�������i�d���P���j
            writer.Write(temp.FracProcStckUnPrc);
            //�d���P���i�Ŕ��C�����j
            writer.Write(temp.StockUnitPriceFl);
            //�d���P���i�ō��C�����j
            writer.Write(temp.StockUnitTaxPriceFl);
            //�d���P���ύX�敪
            writer.Write(temp.StockUnitChngDiv);
            //�ύX�O�d���P���i�����j
            writer.Write(temp.BfStockUnitPriceFl);
            //BL���i�R�[�h�i�|���j
            writer.Write(temp.RateBLGoodsCode);
            //BL���i�R�[�h���́i�|���j
            writer.Write(temp.RateBLGoodsName);
            //�����敪�R�[�h
            writer.Write(temp.BargainCd);
            //�����敪����
            writer.Write(temp.BargainNm);
            //�d����
            writer.Write(temp.StockCount);
            //�d�����z�i�Ŕ����j
            writer.Write(temp.StockPriceTaxExc);
            //�d�����z�i�ō��݁j
            writer.Write(temp.StockPriceTaxInc);
            //�d�����i�敪
            writer.Write(temp.StockGoodsCd);
            //�d�����z����Ŋz
            writer.Write(temp.StockPriceConsTax);
            //����Œ����z
            writer.Write(temp.TaxAdjust);
            //�c�������z
            writer.Write(temp.BalanceAdjust);
            //�ېŋ敪
            writer.Write(temp.TaxationCode);
            //�d���`�[���ה��l1
            writer.Write(temp.StockDtiSlipNote1);
            //�̔���R�[�h
            writer.Write(temp.SalesCustomerCode);
            //�̔��於��
            writer.Write(temp.SalesCustomerName);
            //�����ԍ�
            writer.Write(temp.OrderNumber);
            //�`�[�����P
            writer.Write(temp.SlipMemo1);
            //�`�[�����Q
            writer.Write(temp.SlipMemo2);
            //�`�[�����R
            writer.Write(temp.SlipMemo3);
            //�`�[�����S
            writer.Write(temp.SlipMemo4);
            //�`�[�����T
            writer.Write(temp.SlipMemo5);
            //�`�[�����U
            writer.Write(temp.SlipMemo6);
            //�Г������P
            writer.Write(temp.InsideMemo1);
            //�Г������Q
            writer.Write(temp.InsideMemo2);
            //�Г������R
            writer.Write(temp.InsideMemo3);
            //�Г������S
            writer.Write(temp.InsideMemo4);
            //�Г������T
            writer.Write(temp.InsideMemo5);
            //�Г������U
            writer.Write(temp.InsideMemo6);
            //�d���`�F�b�N�敪�i�����j
            writer.Write(temp.StockCheckDivCAddUp);
            //�d���`�F�b�N�敪�i�����j
            writer.Write(temp.StockCheckDivDaily);

        }

        /// <summary>
        ///  StcDtlDataRefWork�C���X�^���X�擾
        /// </summary>
        /// <returns>StcDtlDataRefWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StcDtlDataRefWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private StcDtlDataRefWork GetStcDtlDataRefWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            StcDtlDataRefWork temp = new StcDtlDataRefWork();

            //�󒍔ԍ�
            temp.AcceptAnOrderNo = reader.ReadInt32();
            //�d���`��
            temp.SupplierFormal = reader.ReadInt32();
            //�d���`�[�ԍ�
            temp.SupplierSlipNo = reader.ReadInt32();
            //�d���s�ԍ�
            temp.StockRowNo = reader.ReadInt32();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���_����
            temp.SectionGuideNm = reader.ReadString();
            //����R�[�h
            temp.SubSectionCode = reader.ReadInt32();
            //�ۃR�[�h
            temp.MinSectionCode = reader.ReadInt32();
            //���ʒʔ�
            temp.CommonSeqNo = reader.ReadInt64();
            //�d�����גʔ�
            temp.StockSlipDtlNum = reader.ReadInt64();
            //�d���`���i���j
            temp.SupplierFormalSrc = reader.ReadInt32();
            //�d�����גʔԁi���j
            temp.StockSlipDtlNumSrc = reader.ReadInt64();
            //�󒍃X�e�[�^�X�i�����j
            temp.AcptAnOdrStatusSync = reader.ReadInt32();
            //���㖾�גʔԁi�����j
            temp.SalesSlipDtlNumSync = reader.ReadInt64();
            //�d���`�[�敪�i���ׁj
            temp.StockSlipCdDtl = reader.ReadInt32();
            //�d���S���҃R�[�h
            temp.StockAgentCode = reader.ReadString();
            //�d���S���Җ���
            temp.StockAgentName = reader.ReadString();
            //�݌ɊǗ��L���敪
            temp.StockMngExistCd = reader.ReadInt32();
            //���i����
            temp.GoodsKindCode = reader.ReadInt32();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���[�J�[����
            temp.MakerName = reader.ReadString();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i����
            temp.GoodsName = reader.ReadString();
            //���i�敪�O���[�v�R�[�h
            temp.LargeGoodsGanreCode = reader.ReadString();
            //���i�敪�O���[�v����
            temp.LargeGoodsGanreName = reader.ReadString();
            //���i�敪�R�[�h
            temp.MediumGoodsGanreCode = reader.ReadString();
            //���i�敪����
            temp.MediumGoodsGanreName = reader.ReadString();
            //���i�敪�ڍ׃R�[�h
            temp.DetailGoodsGanreCode = reader.ReadString();
            //���i�敪�ڍז���
            temp.DetailGoodsGanreName = reader.ReadString();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //BL���i�R�[�h���́i�S�p�j
            temp.BLGoodsFullName = reader.ReadString();
            //���Е��ރR�[�h
            temp.EnterpriseGanreCode = reader.ReadInt32();
            //���Е��ޖ���
            temp.EnterpriseGanreName = reader.ReadString();
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //�q�ɖ���
            temp.WarehouseName = reader.ReadString();
            //�q�ɒI��
            temp.WarehouseShelfNo = reader.ReadString();
            //�d���݌Ɏ�񂹋敪
            temp.StockOrderDivCd = reader.ReadInt32();
            //�I�[�v�����i�敪
            temp.OpenPriceDiv = reader.ReadInt32();
            //�P�ʃR�[�h
            temp.UnitCode = reader.ReadInt32();
            //�P�ʖ���
            temp.UnitName = reader.ReadString();
            //���i�|�������N
            temp.GoodsRateRank = reader.ReadString();
            //���Ӑ�|���O���[�v�R�[�h
            temp.CustRateGrpCode = reader.ReadInt32();
            //�d����|���O���[�v�R�[�h
            temp.SuppRateGrpCode = reader.ReadInt32();
            //�艿�i�Ŕ��C�����j
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //�艿�i�ō��C�����j
            temp.ListPriceTaxIncFl = reader.ReadDouble();
            //�d����
            temp.StockRate = reader.ReadDouble();
            //�|���ݒ苒�_�i�d���P���j
            temp.RateSectStckUnPrc = reader.ReadString();
            //�|���ݒ�敪�i�d���P���j
            temp.RateDivStckUnPrc = reader.ReadString();
            //�P���Z�o�敪�i�d���P���j
            temp.UnPrcCalcCdStckUnPrc = reader.ReadInt32();
            //���i�敪�i�d���P���j
            temp.PriceCdStckUnPrc = reader.ReadInt32();
            //��P���i�d���P���j
            temp.StdUnPrcStckUnPrc = reader.ReadDouble();
            //�[�������P�ʁi�d���P���j
            temp.FracProcUnitStcUnPrc = reader.ReadDouble();
            //�[�������i�d���P���j
            temp.FracProcStckUnPrc = reader.ReadInt32();
            //�d���P���i�Ŕ��C�����j
            temp.StockUnitPriceFl = reader.ReadDouble();
            //�d���P���i�ō��C�����j
            temp.StockUnitTaxPriceFl = reader.ReadDouble();
            //�d���P���ύX�敪
            temp.StockUnitChngDiv = reader.ReadInt32();
            //�ύX�O�d���P���i�����j
            temp.BfStockUnitPriceFl = reader.ReadDouble();
            //BL���i�R�[�h�i�|���j
            temp.RateBLGoodsCode = reader.ReadInt32();
            //BL���i�R�[�h���́i�|���j
            temp.RateBLGoodsName = reader.ReadString();
            //�����敪�R�[�h
            temp.BargainCd = reader.ReadInt32();
            //�����敪����
            temp.BargainNm = reader.ReadString();
            //�d����
            temp.StockCount = reader.ReadDouble();
            //�d�����z�i�Ŕ����j
            temp.StockPriceTaxExc = reader.ReadInt64();
            //�d�����z�i�ō��݁j
            temp.StockPriceTaxInc = reader.ReadInt64();
            //�d�����i�敪
            temp.StockGoodsCd = reader.ReadInt32();
            //�d�����z����Ŋz
            temp.StockPriceConsTax = reader.ReadInt64();
            //����Œ����z
            temp.TaxAdjust = reader.ReadInt64();
            //�c�������z
            temp.BalanceAdjust = reader.ReadInt64();
            //�ېŋ敪
            temp.TaxationCode = reader.ReadInt32();
            //�d���`�[���ה��l1
            temp.StockDtiSlipNote1 = reader.ReadString();
            //�̔���R�[�h
            temp.SalesCustomerCode = reader.ReadInt32();
            //�̔��於��
            temp.SalesCustomerName = reader.ReadString();
            //�����ԍ�
            temp.OrderNumber = reader.ReadString();
            //�`�[�����P
            temp.SlipMemo1 = reader.ReadString();
            //�`�[�����Q
            temp.SlipMemo2 = reader.ReadString();
            //�`�[�����R
            temp.SlipMemo3 = reader.ReadString();
            //�`�[�����S
            temp.SlipMemo4 = reader.ReadString();
            //�`�[�����T
            temp.SlipMemo5 = reader.ReadString();
            //�`�[�����U
            temp.SlipMemo6 = reader.ReadString();
            //�Г������P
            temp.InsideMemo1 = reader.ReadString();
            //�Г������Q
            temp.InsideMemo2 = reader.ReadString();
            //�Г������R
            temp.InsideMemo3 = reader.ReadString();
            //�Г������S
            temp.InsideMemo4 = reader.ReadString();
            //�Г������T
            temp.InsideMemo5 = reader.ReadString();
            //�Г������U
            temp.InsideMemo6 = reader.ReadString();
            //�d���`�F�b�N�敪�i�����j
            temp.StockCheckDivCAddUp = reader.ReadInt32();
            //�d���`�F�b�N�敪�i�����j
            temp.StockCheckDivDaily = reader.ReadInt32();


            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>StcDtlDataRefWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StcDtlDataRefWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StcDtlDataRefWork temp = GetStcDtlDataRefWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (StcDtlDataRefWork[])lst.ToArray(typeof(StcDtlDataRefWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
