using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesDetailWork
    /// <summary>
    ///                      ���㖾�׃f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���㖾�׃f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2011/08/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/9  ����</br>
    /// <br>                 :   ���X�y���~�X�C��</br>
    /// <br>                 :   �̔��敪�R�[�h</br>
    /// <br>                 :   �̔��敪����</br>
    /// <br>                 :   ������z����Ŋz</br>
    /// <br>Update Note      :   2008/6/23  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   ���i���̃J�i</br>
    /// <br>                 :   ���[�J�[�J�i����</br>
    /// <br>                 :   ���[�J�[�J�i���́i�ꎮ�j</br>
    /// <br>Update Note      :   2008/7/31  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   ����p�i��</br>
    /// <br>                 :   ����p���[�J�[�R�[�h</br>
    /// <br>                 :   ����p���[�J�[����</br>
    /// <br>Update Note      :   2008/9/9  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   ���i�|���O���[�v�R�[�h�i�|���j</br>
    /// <br>                 :   ���i�|���O���[�v���́i�|���j</br>
    /// <br>                 :   BL�O���[�v�R�[�h�i�|���j</br>
    /// <br>                 :   BL�O���[�v���́i�|���j</br>
    /// <br>Update Note      :   2009/5/20  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   �L�����y�[���R�[�h</br>
    /// <br>                 :   �L�����y�[������</br>
    /// <br>                 :   ���i���</br>
    /// <br>                 :   �񓚔[��</br>
    /// <br>                 :   ���T�C�N���敪</br>
    /// <br>                 :   ���T�C�N���敪����</br>
    /// <br>                 :   �󒍕��@</br>
    /// <br>Update Note      :   2009/5/29  ����</br>
    /// <br>                 :   �������ύX</br>
    /// <br>                 :   �񓚔[�� 20��10</br>
    /// <br>Update Note      :   2011/4/22  ����</br>
    /// <br>                 :   �C���f�b�N�X�̋L�ڂ�ǉ�</br>
    /// <br>Update Note      :   2011/7/12  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   �����񓚋敪(SCM)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesDetailWork : IFileHeader
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _updEmployeeCode = "";

        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�󒍔ԍ�</summary>
        private Int32 _acceptAnOrderNo;

        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>10:����,20:��,30:����,40:�o��,70:�w����,80:�N���[��,99:�ꎞ�ۊ�  </remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>����`�[�ԍ�</summary>
        /// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
        private string _salesSlipNum = "";

        /// <summary>����s�ԍ�</summary>
        private Int32 _salesRowNo;

        /// <summary>����s�ԍ��}��</summary>
        /// <remarks>�������ς̑Δ�Ŏg�p����</remarks>
        private Int32 _salesRowDerivNo;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>����R�[�h</summary>
        private Int32 _subSectionCode;

        /// <summary>������t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _salesDate;

        /// <summary>���ʒʔ�</summary>
        private Int64 _commonSeqNo;

        /// <summary>���㖾�גʔ�</summary>
        private Int64 _salesSlipDtlNum;

        /// <summary>�󒍃X�e�[�^�X�i���j</summary>
        /// <remarks>10:����,20:��,30:����,40:�o��</remarks>
        private Int32 _acptAnOdrStatusSrc;

        /// <summary>���㖾�גʔԁi���j</summary>
        /// <remarks>�v�㎞�̌��f�[�^���גʔԂ��Z�b�g</remarks>
        private Int64 _salesSlipDtlNumSrc;

        /// <summary>�d���`���i�����j</summary>
        /// <remarks>0:�d��,1:����</remarks>
        private Int32 _supplierFormalSync;

        /// <summary>�d�����גʔԁi�����j</summary>
        /// <remarks>�����v�㎞�̎d�����גʔԂ��Z�b�g</remarks>
        private Int64 _stockSlipDtlNumSync;

        /// <summary>����`�[�敪�i���ׁj</summary>
        /// <remarks>0:����,1:�ԕi,2:�l��,3:����,4:���v,5:���</remarks>
        private Int32 _salesSlipCdDtl;

        /// <summary>�[�i�����\���</summary>
        /// <remarks>�q��[��(YYYYMMDD)</remarks>
        private Int32 _deliGdsCmpltDueDate;

        /// <summary>���i����</summary>
        /// <remarks>0:���� 1:�D��</remarks>
        private Int32 _goodsKindCode;

        /// <summary>���i�����敪</summary>
        /// <remarks>0:BL���� 1:�i�� 2:�����</remarks>
        private Int32 _goodsSearchDivCd;

        /// <summary>���i���[�J�[�R�[�h</summary>
        /// <remarks>�߯���ޖ���հ�ް�o�^�͈͂��قȂ�</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

        /// <summary>���[�J�[�J�i����</summary>
        private string _makerKanaName = "";

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>���i���̃J�i</summary>
        private string _goodsNameKana = "";

        /// <summary>���i�啪�ރR�[�h</summary>
        /// <remarks>���啪�ށi���[�U�[�K�C�h�j</remarks>
        private Int32 _goodsLGroup;

        /// <summary>���i�啪�ޖ���</summary>
        private string _goodsLGroupName = "";

        /// <summary>���i�����ރR�[�h</summary>
        /// <remarks>�������ރR�[�h</remarks>
        private Int32 _goodsMGroup;

        /// <summary>���i�����ޖ���</summary>
        private string _goodsMGroupName = "";

        /// <summary>BL�O���[�v�R�[�h</summary>
        /// <remarks>���O���[�v�R�[�h</remarks>
        private Int32 _bLGroupCode;

        /// <summary>BL�O���[�v�R�[�h����</summary>
        private string _bLGroupName = "";

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

        /// <summary>����݌Ɏ�񂹋敪</summary>
        /// <remarks>0:��񂹁C1:�݌�</remarks>
        private Int32 _salesOrderDivCd;

        /// <summary>�I�[�v�����i�敪</summary>
        /// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
        private Int32 _openPriceDiv;

        /// <summary>���i�|�������N</summary>
        /// <remarks>���i�̊|���p�����N</remarks>
        private string _goodsRateRank = "";

        /// <summary>���Ӑ�|���O���[�v�R�[�h</summary>
        private Int32 _custRateGrpCode;

        /// <summary>�艿��</summary>
        private Double _listPriceRate;

        /// <summary>�|���ݒ苒�_�i�艿�j</summary>
        /// <remarks>0:�S�Аݒ�, ���̑�:���_�R�[�h</remarks>
        private string _rateSectPriceUnPrc = "";

        /// <summary>�|���ݒ�敪�i�艿�j</summary>
        /// <remarks>A1,A2,�c</remarks>
        private string _rateDivLPrice = "";

        /// <summary>�P���Z�o�敪�i�艿�j</summary>
        /// <remarks>1:�|��,2:�����t�o��,3:�e����</remarks>
        private Int32 _unPrcCalcCdLPrice;

        /// <summary>���i�敪�i�艿�j</summary>
        /// <remarks>0:�艿,1:�o�^�̔��X���i,�c 9:���[�U�[�艿</remarks>
        private Int32 _priceCdLPrice;

        /// <summary>��P���i�艿�j</summary>
        private Double _stdUnPrcLPrice;

        /// <summary>�[�������P�ʁi�艿�j</summary>
        private Double _fracProcUnitLPrice;

        /// <summary>�[�������i�艿�j</summary>
        /// <remarks>1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ</remarks>
        private Int32 _fracProcLPrice;

        /// <summary>�艿�i�ō��C�����j</summary>
        /// <remarks>�Ŕ���</remarks>
        private Double _listPriceTaxIncFl;

        /// <summary>�艿�i�Ŕ��C�����j</summary>
        /// <remarks>�ō���</remarks>
        private Double _listPriceTaxExcFl;

        /// <summary>�艿�ύX�敪</summary>
        /// <remarks>0:�ύX�Ȃ�,1:�ύX����@�i�艿����́j</remarks>
        private Int32 _listPriceChngCd;

        /// <summary>������</summary>
        private Double _salesRate;

        /// <summary>�|���ݒ苒�_�i����P���j</summary>
        /// <remarks>0:�S�Аݒ�, ���̑�:���_�R�[�h</remarks>
        private string _rateSectSalUnPrc = "";

        /// <summary>�|���ݒ�敪�i����P���j</summary>
        /// <remarks>A1,A2,�c</remarks>
        private string _rateDivSalUnPrc = "";

        /// <summary>�P���Z�o�敪�i����P���j</summary>
        /// <remarks>1:�|��,2:�����t�o��,3:�e����</remarks>
        private Int32 _unPrcCalcCdSalUnPrc;

        /// <summary>���i�敪�i����P���j</summary>
        /// <remarks>0:�艿,1:�o�^�̔��X���i,�c</remarks>
        private Int32 _priceCdSalUnPrc;

        /// <summary>��P���i����P���j</summary>
        private Double _stdUnPrcSalUnPrc;

        /// <summary>�[�������P�ʁi����P���j</summary>
        private Double _fracProcUnitSalUnPrc;

        /// <summary>�[�������i����P���j</summary>
        /// <remarks>1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ</remarks>
        private Int32 _fracProcSalUnPrc;

        /// <summary>����P���i�ō��C�����j</summary>
        private Double _salesUnPrcTaxIncFl;

        /// <summary>����P���i�Ŕ��C�����j</summary>
        private Double _salesUnPrcTaxExcFl;

        /// <summary>����P���ύX�敪</summary>
        /// <remarks>0:�ύX�Ȃ�,1:�ύX����@�i����P������́j</remarks>
        private Int32 _salesUnPrcChngCd;

        /// <summary>������</summary>
        private Double _costRate;

        /// <summary>�|���ݒ苒�_�i�����P���j</summary>
        /// <remarks>0:�S�Аݒ�, ���̑�:���_�R�[�h</remarks>
        private string _rateSectCstUnPrc = "";

        /// <summary>�|���ݒ�敪�i�����P���j</summary>
        /// <remarks>A7,A8,�c</remarks>
        private string _rateDivUnCst = "";

        /// <summary>�P���Z�o�敪�i�����P���j</summary>
        /// <remarks>1:�|��,2:�����t�o��,3:�e����</remarks>
        private Int32 _unPrcCalcCdUnCst;

        /// <summary>���i�敪�i�����P���j</summary>
        /// <remarks>0:�艿,1:�o�^�̔��X���i,�c</remarks>
        private Int32 _priceCdUnCst;

        /// <summary>��P���i�����P���j</summary>
        private Double _stdUnPrcUnCst;

        /// <summary>�[�������P�ʁi�����P���j</summary>
        private Double _fracProcUnitUnCst;

        /// <summary>�[�������i�����P���j</summary>
        /// <remarks>1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ</remarks>
        private Int32 _fracProcUnCst;

        /// <summary>�����P��</summary>
        private Double _salesUnitCost;

        /// <summary>�����P���ύX�敪</summary>
        /// <remarks>0:�ύX�Ȃ�,1:�ύX����@�i�����P������́j</remarks>
        private Int32 _salesUnitCostChngDiv;

        /// <summary>BL���i�R�[�h�i�|���j</summary>
        /// <remarks>�|���Z�o���Ɏg�p����BL�R�[�h�i���i�������ʁj</remarks>
        private Int32 _rateBLGoodsCode;

        /// <summary>BL���i�R�[�h���́i�|���j</summary>
        /// <remarks>�|���Z�o���Ɏg�p����BL�R�[�h���́i���i�������ʁj</remarks>
        private string _rateBLGoodsName = "";

        /// <summary>���i�|���O���[�v�R�[�h�i�|���j</summary>
        /// <remarks>�|���Z�o���Ɏg�p�������i�|���R�[�h�i���i�������ʁj</remarks>
        private Int32 _rateGoodsRateGrpCd;

        /// <summary>���i�|���O���[�v���́i�|���j</summary>
        /// <remarks>�|���Z�o���Ɏg�p�������i�|�����́i���i�������ʁj</remarks>
        private string _rateGoodsRateGrpNm = "";

        /// <summary>BL�O���[�v�R�[�h�i�|���j</summary>
        /// <remarks>�|���Z�o���Ɏg�p����BL�O���[�v�R�[�h�i���i�������ʁj</remarks>
        private Int32 _rateBLGroupCode;

        /// <summary>BL�O���[�v���́i�|���j</summary>
        /// <remarks>�|���Z�o���Ɏg�p����BL�O���[�v���́i���i�������ʁj</remarks>
        private string _rateBLGroupName = "";

        /// <summary>BL���i�R�[�h�i����j</summary>
        /// <remarks>�|���Z�o���Ɏg�p����BL�R�[�h�i���i�������ʁj</remarks>
        private Int32 _prtBLGoodsCode;

        /// <summary>BL���i�R�[�h���́i����j</summary>
        /// <remarks>�|���Z�o���Ɏg�p����BL�R�[�h���́i���i�������ʁj</remarks>
        private string _prtBLGoodsName = "";

        /// <summary>�̔��敪�R�[�h</summary>
        private Int32 _salesCode;

        /// <summary>�̔��敪����</summary>
        private string _salesCdNm = "";

        /// <summary>��ƍH��</summary>
        private Double _workManHour;

        /// <summary>�o�א�</summary>
        private Double _shipmentCnt;

        /// <summary>�󒍐���</summary>
        /// <remarks>��,�o�ׂŎg�p</remarks>
        private Double _acceptAnOrderCnt;

        /// <summary>�󒍒�����</summary>
        /// <remarks>���݂̎󒍐��́u�󒍐��ʁ{�󒍒������v�ŎZ�o</remarks>
        private Double _acptAnOdrAdjustCnt;

        /// <summary>�󒍎c��</summary>
        /// <remarks>�󒍐��ʁ{�󒍒������|�o�א�</remarks>
        private Double _acptAnOdrRemainCnt;

        /// <summary>�c���X�V��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _remainCntUpdDate;

        /// <summary>������z�i�ō��݁j</summary>
        private Int64 _salesMoneyTaxInc;

        /// <summary>������z�i�Ŕ����j</summary>
        private Int64 _salesMoneyTaxExc;

        /// <summary>����</summary>
        private Int64 _cost;

        /// <summary>�e���`�F�b�N�敪</summary>
        /// <remarks>0:����,1:��������,2:���v�̏グ�߂�</remarks>
        private Int32 _grsProfitChkDiv;

        /// <summary>���㏤�i�敪</summary>
        /// <remarks>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,10:���|�p����Œ���(����),11:���E,12:���E(����)</remarks>
        private Int32 _salesGoodsCd;

        /// <summary>������z����Ŋz</summary>
        /// <remarks>������z�i�ō��݁j- ������z�i�Ŕ����j������Œ����z�����˂�</remarks>
        private Int64 _salesPriceConsTax;

        /// <summary>�ېŋ敪</summary>
        /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
        private Int32 _taxationDivCd;

        /// <summary>�����`�[�ԍ��i���ׁj</summary>
        /// <remarks>���Ӑ撍���ԍ��i���`No�j</remarks>
        private string _partySlipNumDtl = "";

        /// <summary>���ה��l</summary>
        private string _dtlNote = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";

        /// <summary>�����ԍ�</summary>
        private string _orderNumber = "";

        /// <summary>�������@</summary>
        /// <remarks>0:����������,1:FAX���M,2:�I�����C������,4:�����ώ���o�^</remarks>
        private Int32 _wayToOrder;

        /// <summary>�`�[�����P</summary>
        private string _slipMemo1 = "";

        /// <summary>�`�[�����Q</summary>
        private string _slipMemo2 = "";

        /// <summary>�`�[�����R</summary>
        private string _slipMemo3 = "";

        /// <summary>�Г������P</summary>
        private string _insideMemo1 = "";

        /// <summary>�Г������Q</summary>
        private string _insideMemo2 = "";

        /// <summary>�Г������R</summary>
        private string _insideMemo3 = "";

        /// <summary>�ύX�O�艿</summary>
        /// <remarks>�Ŕ����A�|���Z�o����</remarks>
        private Double _bfListPrice;

        /// <summary>�ύX�O����</summary>
        /// <remarks>�Ŕ����A�|���Z�o����</remarks>
        private Double _bfSalesUnitPrice;

        /// <summary>�ύX�O����</summary>
        /// <remarks>�Ŕ����A�|���Z�o����</remarks>
        private Double _bfUnitCost;

        /// <summary>�ꎮ���הԍ�</summary>
        /// <remarks>0:�ꎮ�Ȃ��@1�`�ꎮ�A��</remarks>
        private Int32 _cmpltSalesRowNo;

        /// <summary>���[�J�[�R�[�h�i�ꎮ�j</summary>
        private Int32 _cmpltGoodsMakerCd;

        /// <summary>���[�J�[���́i�ꎮ�j</summary>
        private string _cmpltMakerName = "";

        /// <summary>���[�J�[�J�i���́i�ꎮ�j</summary>
        private string _cmpltMakerKanaName = "";

        /// <summary>���i���́i�ꎮ�j</summary>
        private string _cmpltGoodsName = "";

        /// <summary>���ʁi�ꎮ�j</summary>
        private Double _cmpltShipmentCnt;

        /// <summary>����P���i�ꎮ�j</summary>
        /// <remarks>������z�i�ꎮ�̍��v�j/ ����  ��������R�ʎl�̌ܓ�</remarks>
        private Double _cmpltSalesUnPrcFl;

        /// <summary>������z�i�ꎮ�j</summary>
        /// <remarks>������z�i�Ŕ����j�̓���ꎮ���ׂ̍��v</remarks>
        private Int64 _cmpltSalesMoney;

        /// <summary>�����P���i�ꎮ�j</summary>
        /// <remarks>�������z�i�ꎮ�̍��v�j/ ����  ��������R�ʎl�̌ܓ�</remarks>
        private Double _cmpltSalesUnitCost;

        /// <summary>�������z�i�ꎮ�j</summary>
        /// <remarks>�����̓���ꎮ���ׂ̍��v</remarks>
        private Int64 _cmpltCost;

        /// <summary>�����`�[�ԍ��i�ꎮ�j</summary>
        /// <remarks>���Ӑ撍���ԍ�</remarks>
        private string _cmpltPartySalSlNum = "";

        /// <summary>�ꎮ���l</summary>
        private string _cmpltNote = "";

        /// <summary>����p�i��</summary>
        private string _prtGoodsNo = "";

        /// <summary>����p���[�J�[�R�[�h</summary>
        private Int32 _prtMakerCode;

        /// <summary>����p���[�J�[����</summary>
        private string _prtMakerName = "";

        /// <summary>�L�����y�[���R�[�h</summary>
        /// <remarks>���_�ƘA���ŃL�[�ƂȂ�̂Œ��Ӂi�Ǘ����_�R�[�h�j</remarks>
        private Int32 _campaignCode;

        /// <summary>�L�����y�[������</summary>
        private string _campaignName = "";

        /// <summary>���i���</summary>
        /// <remarks>0:�������i 1:�D�Ǖ��i 2:���r���h 3:���� 4:���ϑ���</remarks>
        private Int32 _goodsDivCd;

        /// <summary>�񓚔[��</summary>
        private string _answerDelivDate = "";

        /// <summary>���T�C�N���敪</summary>
        /// <remarks>RC�̃}�X�^����</remarks>
        private Int32 _recycleDiv;

        /// <summary>���T�C�N���敪����</summary>
        /// <remarks>RC�̃}�X�^����</remarks>
        private string _recycleDivNm = "";

        /// <summary>�󒍕��@</summary>
        /// <remarks>0:�ʏ�,1:�I�����C���iSCM�j</remarks>
        private Int32 _wayToAcptOdr;

        /// <summary>�����񓚋敪(SCM)</summary>
        /// <remarks>0:�ʏ�(PCC�A�g�Ȃ�)�A1:�蓮�񓚁A2:������</remarks>
        private Int32 _autoAnswerDivSCM;

        /// <summary>�d����</summary>
        /// <remarks>����d���������͂̎d�����t</remarks>
        private Int32 _stokDate;

        /// <summary>�󔭒����</summary>
        /// <remarks>0:�ʏ�,1:PCC-UOE</remarks>
        private Int16 _acceptOrOrderKind;

        /// <summary>�⍇���ԍ�</summary>
        private Int64 _inquiryNumber;

        /// <summary>�⍇���s�ԍ�</summary>
        private Int32 _inqRowNumber;


        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

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

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUID�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�_���폜�敪�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

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

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>10:����,20:��,30:����,40:�o��,70:�w����,80:�N���[��,99:�ꎞ�ۊ�  </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>����`�[�ԍ��v���p�e�B</summary>
        /// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  SalesRowNo
        /// <summary>����s�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesRowNo
        {
            get { return _salesRowNo; }
            set { _salesRowNo = value; }
        }

        /// public propaty name  :  SalesRowDerivNo
        /// <summary>����s�ԍ��}�ԃv���p�e�B</summary>
        /// <value>�������ς̑Δ�Ŏg�p����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����s�ԍ��}�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesRowDerivNo
        {
            get { return _salesRowDerivNo; }
            set { _salesRowDerivNo = value; }
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

        /// public propaty name  :  SalesDate
        /// <summary>������t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
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

        /// public propaty name  :  SalesSlipDtlNum
        /// <summary>���㖾�גʔԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㖾�גʔԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesSlipDtlNum
        {
            get { return _salesSlipDtlNum; }
            set { _salesSlipDtlNum = value; }
        }

        /// public propaty name  :  AcptAnOdrStatusSrc
        /// <summary>�󒍃X�e�[�^�X�i���j�v���p�e�B</summary>
        /// <value>10:����,20:��,30:����,40:�o��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X�i���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptAnOdrStatusSrc
        {
            get { return _acptAnOdrStatusSrc; }
            set { _acptAnOdrStatusSrc = value; }
        }

        /// public propaty name  :  SalesSlipDtlNumSrc
        /// <summary>���㖾�גʔԁi���j�v���p�e�B</summary>
        /// <value>�v�㎞�̌��f�[�^���גʔԂ��Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㖾�גʔԁi���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesSlipDtlNumSrc
        {
            get { return _salesSlipDtlNumSrc; }
            set { _salesSlipDtlNumSrc = value; }
        }

        /// public propaty name  :  SupplierFormalSync
        /// <summary>�d���`���i�����j�v���p�e�B</summary>
        /// <value>0:�d��,1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`���i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierFormalSync
        {
            get { return _supplierFormalSync; }
            set { _supplierFormalSync = value; }
        }

        /// public propaty name  :  StockSlipDtlNumSync
        /// <summary>�d�����גʔԁi�����j�v���p�e�B</summary>
        /// <value>�����v�㎞�̎d�����גʔԂ��Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����גʔԁi�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockSlipDtlNumSync
        {
            get { return _stockSlipDtlNumSync; }
            set { _stockSlipDtlNumSync = value; }
        }

        /// public propaty name  :  SalesSlipCdDtl
        /// <summary>����`�[�敪�i���ׁj�v���p�e�B</summary>
        /// <value>0:����,1:�ԕi,2:�l��,3:����,4:���v,5:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�敪�i���ׁj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesSlipCdDtl
        {
            get { return _salesSlipCdDtl; }
            set { _salesSlipCdDtl = value; }
        }

        /// public propaty name  :  DeliGdsCmpltDueDate
        /// <summary>�[�i�����\����v���p�e�B</summary>
        /// <value>�q��[��(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�����\����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DeliGdsCmpltDueDate
        {
            get { return _deliGdsCmpltDueDate; }
            set { _deliGdsCmpltDueDate = value; }
        }

        /// public propaty name  :  GoodsKindCode
        /// <summary>���i�����v���p�e�B</summary>
        /// <value>0:���� 1:�D��</value>
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

        /// public propaty name  :  GoodsSearchDivCd
        /// <summary>���i�����敪�v���p�e�B</summary>
        /// <value>0:BL���� 1:�i�� 2:�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsSearchDivCd
        {
            get { return _goodsSearchDivCd; }
            set { _goodsSearchDivCd = value; }
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

        /// public propaty name  :  MakerKanaName
        /// <summary>���[�J�[�J�i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�J�i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerKanaName
        {
            get { return _makerKanaName; }
            set { _makerKanaName = value; }
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

        /// public propaty name  :  GoodsNameKana
        /// <summary>���i���̃J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
        }

        /// public propaty name  :  GoodsLGroup
        /// <summary>���i�啪�ރR�[�h�v���p�e�B</summary>
        /// <value>���啪�ށi���[�U�[�K�C�h�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�啪�ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsLGroup
        {
            get { return _goodsLGroup; }
            set { _goodsLGroup = value; }
        }

        /// public propaty name  :  GoodsLGroupName
        /// <summary>���i�啪�ޖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�啪�ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsLGroupName
        {
            get { return _goodsLGroupName; }
            set { _goodsLGroupName = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>���i�����ރR�[�h�v���p�e�B</summary>
        /// <value>�������ރR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  GoodsMGroupName
        /// <summary>���i�����ޖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsMGroupName
        {
            get { return _goodsMGroupName; }
            set { _goodsMGroupName = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BL�O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>���O���[�v�R�[�h</value>
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

        /// public propaty name  :  BLGroupName
        /// <summary>BL�O���[�v�R�[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGroupName
        {
            get { return _bLGroupName; }
            set { _bLGroupName = value; }
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

        /// public propaty name  :  SalesOrderDivCd
        /// <summary>����݌Ɏ�񂹋敪�v���p�e�B</summary>
        /// <value>0:��񂹁C1:�݌�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����݌Ɏ�񂹋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesOrderDivCd
        {
            get { return _salesOrderDivCd; }
            set { _salesOrderDivCd = value; }
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

        /// public propaty name  :  ListPriceRate
        /// <summary>�艿���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPriceRate
        {
            get { return _listPriceRate; }
            set { _listPriceRate = value; }
        }

        /// public propaty name  :  RateSectPriceUnPrc
        /// <summary>�|���ݒ苒�_�i�艿�j�v���p�e�B</summary>
        /// <value>0:�S�Аݒ�, ���̑�:���_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���ݒ苒�_�i�艿�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateSectPriceUnPrc
        {
            get { return _rateSectPriceUnPrc; }
            set { _rateSectPriceUnPrc = value; }
        }

        /// public propaty name  :  RateDivLPrice
        /// <summary>�|���ݒ�敪�i�艿�j�v���p�e�B</summary>
        /// <value>A1,A2,�c</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���ݒ�敪�i�艿�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateDivLPrice
        {
            get { return _rateDivLPrice; }
            set { _rateDivLPrice = value; }
        }

        /// public propaty name  :  UnPrcCalcCdLPrice
        /// <summary>�P���Z�o�敪�i�艿�j�v���p�e�B</summary>
        /// <value>1:�|��,2:�����t�o��,3:�e����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P���Z�o�敪�i�艿�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UnPrcCalcCdLPrice
        {
            get { return _unPrcCalcCdLPrice; }
            set { _unPrcCalcCdLPrice = value; }
        }

        /// public propaty name  :  PriceCdLPrice
        /// <summary>���i�敪�i�艿�j�v���p�e�B</summary>
        /// <value>0:�艿,1:�o�^�̔��X���i,�c 9:���[�U�[�艿</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�i�艿�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceCdLPrice
        {
            get { return _priceCdLPrice; }
            set { _priceCdLPrice = value; }
        }

        /// public propaty name  :  StdUnPrcLPrice
        /// <summary>��P���i�艿�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��P���i�艿�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StdUnPrcLPrice
        {
            get { return _stdUnPrcLPrice; }
            set { _stdUnPrcLPrice = value; }
        }

        /// public propaty name  :  FracProcUnitLPrice
        /// <summary>�[�������P�ʁi�艿�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�������P�ʁi�艿�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double FracProcUnitLPrice
        {
            get { return _fracProcUnitLPrice; }
            set { _fracProcUnitLPrice = value; }
        }

        /// public propaty name  :  FracProcLPrice
        /// <summary>�[�������i�艿�j�v���p�e�B</summary>
        /// <value>1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�������i�艿�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FracProcLPrice
        {
            get { return _fracProcLPrice; }
            set { _fracProcLPrice = value; }
        }

        /// public propaty name  :  ListPriceTaxIncFl
        /// <summary>�艿�i�ō��C�����j�v���p�e�B</summary>
        /// <value>�Ŕ���</value>
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

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>�艿�i�Ŕ��C�����j�v���p�e�B</summary>
        /// <value>�ō���</value>
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

        /// public propaty name  :  ListPriceChngCd
        /// <summary>�艿�ύX�敪�v���p�e�B</summary>
        /// <value>0:�ύX�Ȃ�,1:�ύX����@�i�艿����́j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�ύX�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ListPriceChngCd
        {
            get { return _listPriceChngCd; }
            set { _listPriceChngCd = value; }
        }

        /// public propaty name  :  SalesRate
        /// <summary>�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesRate
        {
            get { return _salesRate; }
            set { _salesRate = value; }
        }

        /// public propaty name  :  RateSectSalUnPrc
        /// <summary>�|���ݒ苒�_�i����P���j�v���p�e�B</summary>
        /// <value>0:�S�Аݒ�, ���̑�:���_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���ݒ苒�_�i����P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateSectSalUnPrc
        {
            get { return _rateSectSalUnPrc; }
            set { _rateSectSalUnPrc = value; }
        }

        /// public propaty name  :  RateDivSalUnPrc
        /// <summary>�|���ݒ�敪�i����P���j�v���p�e�B</summary>
        /// <value>A1,A2,�c</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���ݒ�敪�i����P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateDivSalUnPrc
        {
            get { return _rateDivSalUnPrc; }
            set { _rateDivSalUnPrc = value; }
        }

        /// public propaty name  :  UnPrcCalcCdSalUnPrc
        /// <summary>�P���Z�o�敪�i����P���j�v���p�e�B</summary>
        /// <value>1:�|��,2:�����t�o��,3:�e����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P���Z�o�敪�i����P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UnPrcCalcCdSalUnPrc
        {
            get { return _unPrcCalcCdSalUnPrc; }
            set { _unPrcCalcCdSalUnPrc = value; }
        }

        /// public propaty name  :  PriceCdSalUnPrc
        /// <summary>���i�敪�i����P���j�v���p�e�B</summary>
        /// <value>0:�艿,1:�o�^�̔��X���i,�c</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�i����P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceCdSalUnPrc
        {
            get { return _priceCdSalUnPrc; }
            set { _priceCdSalUnPrc = value; }
        }

        /// public propaty name  :  StdUnPrcSalUnPrc
        /// <summary>��P���i����P���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��P���i����P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StdUnPrcSalUnPrc
        {
            get { return _stdUnPrcSalUnPrc; }
            set { _stdUnPrcSalUnPrc = value; }
        }

        /// public propaty name  :  FracProcUnitSalUnPrc
        /// <summary>�[�������P�ʁi����P���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�������P�ʁi����P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double FracProcUnitSalUnPrc
        {
            get { return _fracProcUnitSalUnPrc; }
            set { _fracProcUnitSalUnPrc = value; }
        }

        /// public propaty name  :  FracProcSalUnPrc
        /// <summary>�[�������i����P���j�v���p�e�B</summary>
        /// <value>1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�������i����P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FracProcSalUnPrc
        {
            get { return _fracProcSalUnPrc; }
            set { _fracProcSalUnPrc = value; }
        }

        /// public propaty name  :  SalesUnPrcTaxIncFl
        /// <summary>����P���i�ō��C�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����P���i�ō��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnPrcTaxIncFl
        {
            get { return _salesUnPrcTaxIncFl; }
            set { _salesUnPrcTaxIncFl = value; }
        }

        /// public propaty name  :  SalesUnPrcTaxExcFl
        /// <summary>����P���i�Ŕ��C�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����P���i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnPrcTaxExcFl
        {
            get { return _salesUnPrcTaxExcFl; }
            set { _salesUnPrcTaxExcFl = value; }
        }

        /// public propaty name  :  SalesUnPrcChngCd
        /// <summary>����P���ύX�敪�v���p�e�B</summary>
        /// <value>0:�ύX�Ȃ�,1:�ύX����@�i����P������́j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����P���ύX�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesUnPrcChngCd
        {
            get { return _salesUnPrcChngCd; }
            set { _salesUnPrcChngCd = value; }
        }

        /// public propaty name  :  CostRate
        /// <summary>�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double CostRate
        {
            get { return _costRate; }
            set { _costRate = value; }
        }

        /// public propaty name  :  RateSectCstUnPrc
        /// <summary>�|���ݒ苒�_�i�����P���j�v���p�e�B</summary>
        /// <value>0:�S�Аݒ�, ���̑�:���_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���ݒ苒�_�i�����P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateSectCstUnPrc
        {
            get { return _rateSectCstUnPrc; }
            set { _rateSectCstUnPrc = value; }
        }

        /// public propaty name  :  RateDivUnCst
        /// <summary>�|���ݒ�敪�i�����P���j�v���p�e�B</summary>
        /// <value>A7,A8,�c</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���ݒ�敪�i�����P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateDivUnCst
        {
            get { return _rateDivUnCst; }
            set { _rateDivUnCst = value; }
        }

        /// public propaty name  :  UnPrcCalcCdUnCst
        /// <summary>�P���Z�o�敪�i�����P���j�v���p�e�B</summary>
        /// <value>1:�|��,2:�����t�o��,3:�e����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P���Z�o�敪�i�����P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UnPrcCalcCdUnCst
        {
            get { return _unPrcCalcCdUnCst; }
            set { _unPrcCalcCdUnCst = value; }
        }

        /// public propaty name  :  PriceCdUnCst
        /// <summary>���i�敪�i�����P���j�v���p�e�B</summary>
        /// <value>0:�艿,1:�o�^�̔��X���i,�c</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�i�����P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceCdUnCst
        {
            get { return _priceCdUnCst; }
            set { _priceCdUnCst = value; }
        }

        /// public propaty name  :  StdUnPrcUnCst
        /// <summary>��P���i�����P���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��P���i�����P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StdUnPrcUnCst
        {
            get { return _stdUnPrcUnCst; }
            set { _stdUnPrcUnCst = value; }
        }

        /// public propaty name  :  FracProcUnitUnCst
        /// <summary>�[�������P�ʁi�����P���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�������P�ʁi�����P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double FracProcUnitUnCst
        {
            get { return _fracProcUnitUnCst; }
            set { _fracProcUnitUnCst = value; }
        }

        /// public propaty name  :  FracProcUnCst
        /// <summary>�[�������i�����P���j�v���p�e�B</summary>
        /// <value>1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�������i�����P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FracProcUnCst
        {
            get { return _fracProcUnCst; }
            set { _fracProcUnCst = value; }
        }

        /// public propaty name  :  SalesUnitCost
        /// <summary>�����P���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
        }

        /// public propaty name  :  SalesUnitCostChngDiv
        /// <summary>�����P���ύX�敪�v���p�e�B</summary>
        /// <value>0:�ύX�Ȃ�,1:�ύX����@�i�����P������́j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����P���ύX�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesUnitCostChngDiv
        {
            get { return _salesUnitCostChngDiv; }
            set { _salesUnitCostChngDiv = value; }
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

        /// public propaty name  :  RateGoodsRateGrpCd
        /// <summary>���i�|���O���[�v�R�[�h�i�|���j�v���p�e�B</summary>
        /// <value>�|���Z�o���Ɏg�p�������i�|���R�[�h�i���i�������ʁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|���O���[�v�R�[�h�i�|���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RateGoodsRateGrpCd
        {
            get { return _rateGoodsRateGrpCd; }
            set { _rateGoodsRateGrpCd = value; }
        }

        /// public propaty name  :  RateGoodsRateGrpNm
        /// <summary>���i�|���O���[�v���́i�|���j�v���p�e�B</summary>
        /// <value>�|���Z�o���Ɏg�p�������i�|�����́i���i�������ʁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|���O���[�v���́i�|���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateGoodsRateGrpNm
        {
            get { return _rateGoodsRateGrpNm; }
            set { _rateGoodsRateGrpNm = value; }
        }

        /// public propaty name  :  RateBLGroupCode
        /// <summary>BL�O���[�v�R�[�h�i�|���j�v���p�e�B</summary>
        /// <value>�|���Z�o���Ɏg�p����BL�O���[�v�R�[�h�i���i�������ʁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h�i�|���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RateBLGroupCode
        {
            get { return _rateBLGroupCode; }
            set { _rateBLGroupCode = value; }
        }

        /// public propaty name  :  RateBLGroupName
        /// <summary>BL�O���[�v���́i�|���j�v���p�e�B</summary>
        /// <value>�|���Z�o���Ɏg�p����BL�O���[�v���́i���i�������ʁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v���́i�|���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateBLGroupName
        {
            get { return _rateBLGroupName; }
            set { _rateBLGroupName = value; }
        }

        /// public propaty name  :  PrtBLGoodsCode
        /// <summary>BL���i�R�[�h�i����j�v���p�e�B</summary>
        /// <value>�|���Z�o���Ɏg�p����BL�R�[�h�i���i�������ʁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�i����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrtBLGoodsCode
        {
            get { return _prtBLGoodsCode; }
            set { _prtBLGoodsCode = value; }
        }

        /// public propaty name  :  PrtBLGoodsName
        /// <summary>BL���i�R�[�h���́i����j�v���p�e�B</summary>
        /// <value>�|���Z�o���Ɏg�p����BL�R�[�h���́i���i�������ʁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrtBLGoodsName
        {
            get { return _prtBLGoodsName; }
            set { _prtBLGoodsName = value; }
        }

        /// public propaty name  :  SalesCode
        /// <summary>�̔��敪�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCode
        {
            get { return _salesCode; }
            set { _salesCode = value; }
        }

        /// public propaty name  :  SalesCdNm
        /// <summary>�̔��敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesCdNm
        {
            get { return _salesCdNm; }
            set { _salesCdNm = value; }
        }

        /// public propaty name  :  WorkManHour
        /// <summary>��ƍH���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƍH���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double WorkManHour
        {
            get { return _workManHour; }
            set { _workManHour = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>�o�א��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
        }

        /// public propaty name  :  AcceptAnOrderCnt
        /// <summary>�󒍐��ʃv���p�e�B</summary>
        /// <value>��,�o�ׂŎg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍐��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AcceptAnOrderCnt
        {
            get { return _acceptAnOrderCnt; }
            set { _acceptAnOrderCnt = value; }
        }

        /// public propaty name  :  AcptAnOdrAdjustCnt
        /// <summary>�󒍒������v���p�e�B</summary>
        /// <value>���݂̎󒍐��́u�󒍐��ʁ{�󒍒������v�ŎZ�o</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍒������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AcptAnOdrAdjustCnt
        {
            get { return _acptAnOdrAdjustCnt; }
            set { _acptAnOdrAdjustCnt = value; }
        }

        /// public propaty name  :  AcptAnOdrRemainCnt
        /// <summary>�󒍎c���v���p�e�B</summary>
        /// <value>�󒍐��ʁ{�󒍒������|�o�א�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍎c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AcptAnOdrRemainCnt
        {
            get { return _acptAnOdrRemainCnt; }
            set { _acptAnOdrRemainCnt = value; }
        }

        /// public propaty name  :  RemainCntUpdDate
        /// <summary>�c���X�V���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �c���X�V���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RemainCntUpdDate
        {
            get { return _remainCntUpdDate; }
            set { _remainCntUpdDate = value; }
        }

        /// public propaty name  :  SalesMoneyTaxInc
        /// <summary>������z�i�ō��݁j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyTaxInc
        {
            get { return _salesMoneyTaxInc; }
            set { _salesMoneyTaxInc = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc
        /// <summary>������z�i�Ŕ����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc
        {
            get { return _salesMoneyTaxExc; }
            set { _salesMoneyTaxExc = value; }
        }

        /// public propaty name  :  Cost
        /// <summary>�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        /// public propaty name  :  GrsProfitChkDiv
        /// <summary>�e���`�F�b�N�敪�v���p�e�B</summary>
        /// <value>0:����,1:��������,2:���v�̏グ�߂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���`�F�b�N�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GrsProfitChkDiv
        {
            get { return _grsProfitChkDiv; }
            set { _grsProfitChkDiv = value; }
        }

        /// public propaty name  :  SalesGoodsCd
        /// <summary>���㏤�i�敪�v���p�e�B</summary>
        /// <value>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,
        ///5:���|�p�c������,10:���|�p����Œ���(����),11:���E,12:���E(����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㏤�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesGoodsCd
        {
            get { return _salesGoodsCd; }
            set { _salesGoodsCd = value; }
        }

        /// public propaty name  :  SalesPriceConsTax
        /// <summary>������z����Ŋz�v���p�e�B</summary>
        /// <value>������z�i�ō��݁j- ������z�i�Ŕ����j������Œ����z�����˂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z����Ŋz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesPriceConsTax
        {
            get { return _salesPriceConsTax; }
            set { _salesPriceConsTax = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>�ېŋ敪�v���p�e�B</summary>
        /// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
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

        /// public propaty name  :  PartySlipNumDtl
        /// <summary>�����`�[�ԍ��i���ׁj�v���p�e�B</summary>
        /// <value>���Ӑ撍���ԍ��i���`No�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�ԍ��i���ׁj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartySlipNumDtl
        {
            get { return _partySlipNumDtl; }
            set { _partySlipNumDtl = value; }
        }

        /// public propaty name  :  DtlNote
        /// <summary>���ה��l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ה��l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DtlNote
        {
            get { return _dtlNote; }
            set { _dtlNote = value; }
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

        /// public propaty name  :  SupplierSnm
        /// <summary>�d���旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  OrderNumber
        /// <summary>�����ԍ��v���p�e�B</summary>
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

        /// public propaty name  :  WayToOrder
        /// <summary>�������@�v���p�e�B</summary>
        /// <value>0:����������,1:FAX���M,2:�I�����C������,4:�����ώ���o�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������@�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 WayToOrder
        {
            get { return _wayToOrder; }
            set { _wayToOrder = value; }
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

        /// public propaty name  :  BfListPrice
        /// <summary>�ύX�O�艿�v���p�e�B</summary>
        /// <value>�Ŕ����A�|���Z�o����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ύX�O�艿�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double BfListPrice
        {
            get { return _bfListPrice; }
            set { _bfListPrice = value; }
        }

        /// public propaty name  :  BfSalesUnitPrice
        /// <summary>�ύX�O�����v���p�e�B</summary>
        /// <value>�Ŕ����A�|���Z�o����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ύX�O�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double BfSalesUnitPrice
        {
            get { return _bfSalesUnitPrice; }
            set { _bfSalesUnitPrice = value; }
        }

        /// public propaty name  :  BfUnitCost
        /// <summary>�ύX�O�����v���p�e�B</summary>
        /// <value>�Ŕ����A�|���Z�o����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ύX�O�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double BfUnitCost
        {
            get { return _bfUnitCost; }
            set { _bfUnitCost = value; }
        }

        /// public propaty name  :  CmpltSalesRowNo
        /// <summary>�ꎮ���הԍ��v���p�e�B</summary>
        /// <value>0:�ꎮ�Ȃ��@1�`�ꎮ�A��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ꎮ���הԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CmpltSalesRowNo
        {
            get { return _cmpltSalesRowNo; }
            set { _cmpltSalesRowNo = value; }
        }

        /// public propaty name  :  CmpltGoodsMakerCd
        /// <summary>���[�J�[�R�[�h�i�ꎮ�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�R�[�h�i�ꎮ�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CmpltGoodsMakerCd
        {
            get { return _cmpltGoodsMakerCd; }
            set { _cmpltGoodsMakerCd = value; }
        }

        /// public propaty name  :  CmpltMakerName
        /// <summary>���[�J�[���́i�ꎮ�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���́i�ꎮ�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CmpltMakerName
        {
            get { return _cmpltMakerName; }
            set { _cmpltMakerName = value; }
        }

        /// public propaty name  :  CmpltMakerKanaName
        /// <summary>���[�J�[�J�i���́i�ꎮ�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�J�i���́i�ꎮ�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CmpltMakerKanaName
        {
            get { return _cmpltMakerKanaName; }
            set { _cmpltMakerKanaName = value; }
        }

        /// public propaty name  :  CmpltGoodsName
        /// <summary>���i���́i�ꎮ�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���́i�ꎮ�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CmpltGoodsName
        {
            get { return _cmpltGoodsName; }
            set { _cmpltGoodsName = value; }
        }

        /// public propaty name  :  CmpltShipmentCnt
        /// <summary>���ʁi�ꎮ�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ʁi�ꎮ�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double CmpltShipmentCnt
        {
            get { return _cmpltShipmentCnt; }
            set { _cmpltShipmentCnt = value; }
        }

        /// public propaty name  :  CmpltSalesUnPrcFl
        /// <summary>����P���i�ꎮ�j�v���p�e�B</summary>
        /// <value>������z�i�ꎮ�̍��v�j/ ����  ��������R�ʎl�̌ܓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����P���i�ꎮ�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double CmpltSalesUnPrcFl
        {
            get { return _cmpltSalesUnPrcFl; }
            set { _cmpltSalesUnPrcFl = value; }
        }

        /// public propaty name  :  CmpltSalesMoney
        /// <summary>������z�i�ꎮ�j�v���p�e�B</summary>
        /// <value>������z�i�Ŕ����j�̓���ꎮ���ׂ̍��v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�i�ꎮ�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CmpltSalesMoney
        {
            get { return _cmpltSalesMoney; }
            set { _cmpltSalesMoney = value; }
        }

        /// public propaty name  :  CmpltSalesUnitCost
        /// <summary>�����P���i�ꎮ�j�v���p�e�B</summary>
        /// <value>�������z�i�ꎮ�̍��v�j/ ����  ��������R�ʎl�̌ܓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����P���i�ꎮ�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double CmpltSalesUnitCost
        {
            get { return _cmpltSalesUnitCost; }
            set { _cmpltSalesUnitCost = value; }
        }

        /// public propaty name  :  CmpltCost
        /// <summary>�������z�i�ꎮ�j�v���p�e�B</summary>
        /// <value>�����̓���ꎮ���ׂ̍��v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z�i�ꎮ�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CmpltCost
        {
            get { return _cmpltCost; }
            set { _cmpltCost = value; }
        }

        /// public propaty name  :  CmpltPartySalSlNum
        /// <summary>�����`�[�ԍ��i�ꎮ�j�v���p�e�B</summary>
        /// <value>���Ӑ撍���ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�ԍ��i�ꎮ�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CmpltPartySalSlNum
        {
            get { return _cmpltPartySalSlNum; }
            set { _cmpltPartySalSlNum = value; }
        }

        /// public propaty name  :  CmpltNote
        /// <summary>�ꎮ���l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ꎮ���l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CmpltNote
        {
            get { return _cmpltNote; }
            set { _cmpltNote = value; }
        }

        /// public propaty name  :  PrtGoodsNo
        /// <summary>����p�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����p�i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrtGoodsNo
        {
            get { return _prtGoodsNo; }
            set { _prtGoodsNo = value; }
        }

        /// public propaty name  :  PrtMakerCode
        /// <summary>����p���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����p���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrtMakerCode
        {
            get { return _prtMakerCode; }
            set { _prtMakerCode = value; }
        }

        /// public propaty name  :  PrtMakerName
        /// <summary>����p���[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����p���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrtMakerName
        {
            get { return _prtMakerName; }
            set { _prtMakerName = value; }
        }

        /// public propaty name  :  CampaignCode
        /// <summary>�L�����y�[���R�[�h�v���p�e�B</summary>
        /// <value>���_�ƘA���ŃL�[�ƂȂ�̂Œ��Ӂi�Ǘ����_�R�[�h�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CampaignCode
        {
            get { return _campaignCode; }
            set { _campaignCode = value; }
        }

        /// public propaty name  :  CampaignName
        /// <summary>�L�����y�[�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CampaignName
        {
            get { return _campaignName; }
            set { _campaignName = value; }
        }

        /// public propaty name  :  GoodsDivCd
        /// <summary>���i��ʃv���p�e�B</summary>
        /// <value>0:�������i 1:�D�Ǖ��i 2:���r���h 3:���� 4:���ϑ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsDivCd
        {
            get { return _goodsDivCd; }
            set { _goodsDivCd = value; }
        }

        /// public propaty name  :  AnswerDelivDate
        /// <summary>�񓚔[���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnswerDelivDate
        {
            get { return _answerDelivDate; }
            set { _answerDelivDate = value; }
        }

        /// public propaty name  :  RecycleDiv
        /// <summary>���T�C�N���敪�v���p�e�B</summary>
        /// <value>RC�̃}�X�^����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���T�C�N���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RecycleDiv
        {
            get { return _recycleDiv; }
            set { _recycleDiv = value; }
        }

        /// public propaty name  :  RecycleDivNm
        /// <summary>���T�C�N���敪���̃v���p�e�B</summary>
        /// <value>RC�̃}�X�^����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���T�C�N���敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RecycleDivNm
        {
            get { return _recycleDivNm; }
            set { _recycleDivNm = value; }
        }

        /// public propaty name  :  WayToAcptOdr
        /// <summary>�󒍕��@�v���p�e�B</summary>
        /// <value>0:�ʏ�,1:�I�����C���iSCM�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍕��@�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 WayToAcptOdr
        {
            get { return _wayToAcptOdr; }
            set { _wayToAcptOdr = value; }
        }

        /// public propaty name  :  AutoAnswerDivSCM
        /// <summary>�����񓚋敪(SCM)�v���p�e�B</summary>
        /// <value>0:�ʏ�(PCC�A�g�Ȃ�)�A1:�蓮�񓚁A2:������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����񓚋敪(SCM)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoAnswerDivSCM
        {
            get { return _autoAnswerDivSCM; }
            set { _autoAnswerDivSCM = value; }
        }

        /// public propaty name  :  StokDate
        /// <summary>�d�����v���p�e�B</summary>
        /// <value>����d���������͂̎d�����t</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StokDate
        {
            get { return _stokDate; }
            set { _stokDate = value; }
        }


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
            get { return _acceptOrOrderKind; }
            set { _acceptOrOrderKind = value; }
        }

        /// public propaty name  :  InquiryNumber
        /// <summary>�⍇���ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 InquiryNumber
        {
            get { return _inquiryNumber; }
            set { _inquiryNumber = value; }
        }

        /// public propaty name  :  InqRowNumber
        /// <summary>�⍇���s�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InqRowNumber
        {
            get { return _inqRowNumber; }
            set { _inqRowNumber = value; }
        }

        /// <summary>
        /// ���㖾�׃f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SalesDetailWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesDetailWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesDetailWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SalesDetailWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SalesDetailWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SalesDetailWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesDetailWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalesDetailWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalesDetailWork || graph is ArrayList || graph is SalesDetailWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SalesDetailWork).FullName));

            if (graph != null && graph is SalesDetailWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalesDetailWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalesDetailWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalesDetailWork[])graph).Length;
            }
            else if (graph is SalesDetailWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //�X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //�󒍔ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //AcceptAnOrderNo
            //�󒍃X�e�[�^�X
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //����s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowNo
            //����s�ԍ��}��
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowDerivNo
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //������t
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //���ʒʔ�
            serInfo.MemberInfo.Add(typeof(Int64)); //CommonSeqNo
            //���㖾�גʔ�
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSlipDtlNum
            //�󒍃X�e�[�^�X�i���j
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatusSrc
            //���㖾�גʔԁi���j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSlipDtlNumSrc
            //�d���`���i�����j
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormalSync
            //�d�����גʔԁi�����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSlipDtlNumSync
            //����`�[�敪�i���ׁj
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCdDtl
            //�[�i�����\���
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliGdsCmpltDueDate
            //���i����
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsKindCode
            //���i�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsSearchDivCd
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //���[�J�[�J�i����
            serInfo.MemberInfo.Add(typeof(string)); //MakerKanaName
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //���i���̃J�i
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //���i�啪�ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsLGroup
            //���i�啪�ޖ���
            serInfo.MemberInfo.Add(typeof(string)); //GoodsLGroupName
            //���i�����ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //���i�����ޖ���
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMGroupName
            //BL�O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //BL�O���[�v�R�[�h����
            serInfo.MemberInfo.Add(typeof(string)); //BLGroupName
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
            //����݌Ɏ�񂹋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesOrderDivCd
            //�I�[�v�����i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv
            //���i�|�������N
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRateRank
            //���Ӑ�|���O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustRateGrpCode
            //�艿��
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceRate
            //�|���ݒ苒�_�i�艿�j
            serInfo.MemberInfo.Add(typeof(string)); //RateSectPriceUnPrc
            //�|���ݒ�敪�i�艿�j
            serInfo.MemberInfo.Add(typeof(string)); //RateDivLPrice
            //�P���Z�o�敪�i�艿�j
            serInfo.MemberInfo.Add(typeof(Int32)); //UnPrcCalcCdLPrice
            //���i�敪�i�艿�j
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceCdLPrice
            //��P���i�艿�j
            serInfo.MemberInfo.Add(typeof(Double)); //StdUnPrcLPrice
            //�[�������P�ʁi�艿�j
            serInfo.MemberInfo.Add(typeof(Double)); //FracProcUnitLPrice
            //�[�������i�艿�j
            serInfo.MemberInfo.Add(typeof(Int32)); //FracProcLPrice
            //�艿�i�ō��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxIncFl
            //�艿�i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            //�艿�ύX�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ListPriceChngCd
            //������
            serInfo.MemberInfo.Add(typeof(Double)); //SalesRate
            //�|���ݒ苒�_�i����P���j
            serInfo.MemberInfo.Add(typeof(string)); //RateSectSalUnPrc
            //�|���ݒ�敪�i����P���j
            serInfo.MemberInfo.Add(typeof(string)); //RateDivSalUnPrc
            //�P���Z�o�敪�i����P���j
            serInfo.MemberInfo.Add(typeof(Int32)); //UnPrcCalcCdSalUnPrc
            //���i�敪�i����P���j
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceCdSalUnPrc
            //��P���i����P���j
            serInfo.MemberInfo.Add(typeof(Double)); //StdUnPrcSalUnPrc
            //�[�������P�ʁi����P���j
            serInfo.MemberInfo.Add(typeof(Double)); //FracProcUnitSalUnPrc
            //�[�������i����P���j
            serInfo.MemberInfo.Add(typeof(Int32)); //FracProcSalUnPrc
            //����P���i�ō��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxIncFl
            //����P���i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxExcFl
            //����P���ύX�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesUnPrcChngCd
            //������
            serInfo.MemberInfo.Add(typeof(Double)); //CostRate
            //�|���ݒ苒�_�i�����P���j
            serInfo.MemberInfo.Add(typeof(string)); //RateSectCstUnPrc
            //�|���ݒ�敪�i�����P���j
            serInfo.MemberInfo.Add(typeof(string)); //RateDivUnCst
            //�P���Z�o�敪�i�����P���j
            serInfo.MemberInfo.Add(typeof(Int32)); //UnPrcCalcCdUnCst
            //���i�敪�i�����P���j
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceCdUnCst
            //��P���i�����P���j
            serInfo.MemberInfo.Add(typeof(Double)); //StdUnPrcUnCst
            //�[�������P�ʁi�����P���j
            serInfo.MemberInfo.Add(typeof(Double)); //FracProcUnitUnCst
            //�[�������i�����P���j
            serInfo.MemberInfo.Add(typeof(Int32)); //FracProcUnCst
            //�����P��
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost
            //�����P���ύX�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesUnitCostChngDiv
            //BL���i�R�[�h�i�|���j
            serInfo.MemberInfo.Add(typeof(Int32)); //RateBLGoodsCode
            //BL���i�R�[�h���́i�|���j
            serInfo.MemberInfo.Add(typeof(string)); //RateBLGoodsName
            //���i�|���O���[�v�R�[�h�i�|���j
            serInfo.MemberInfo.Add(typeof(Int32)); //RateGoodsRateGrpCd
            //���i�|���O���[�v���́i�|���j
            serInfo.MemberInfo.Add(typeof(string)); //RateGoodsRateGrpNm
            //BL�O���[�v�R�[�h�i�|���j
            serInfo.MemberInfo.Add(typeof(Int32)); //RateBLGroupCode
            //BL�O���[�v���́i�|���j
            serInfo.MemberInfo.Add(typeof(string)); //RateBLGroupName
            //BL���i�R�[�h�i����j
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtBLGoodsCode
            //BL���i�R�[�h���́i����j
            serInfo.MemberInfo.Add(typeof(string)); //PrtBLGoodsName
            //�̔��敪�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCode
            //�̔��敪����
            serInfo.MemberInfo.Add(typeof(string)); //SalesCdNm
            //��ƍH��
            serInfo.MemberInfo.Add(typeof(Double)); //WorkManHour
            //�o�א�
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //�󒍐���
            serInfo.MemberInfo.Add(typeof(Double)); //AcceptAnOrderCnt
            //�󒍒�����
            serInfo.MemberInfo.Add(typeof(Double)); //AcptAnOdrAdjustCnt
            //�󒍎c��
            serInfo.MemberInfo.Add(typeof(Double)); //AcptAnOdrRemainCnt
            //�c���X�V��
            serInfo.MemberInfo.Add(typeof(Int32)); //RemainCntUpdDate
            //������z�i�ō��݁j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxInc
            //������z�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //����
            serInfo.MemberInfo.Add(typeof(Int64)); //Cost
            //�e���`�F�b�N�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //GrsProfitChkDiv
            //���㏤�i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesGoodsCd
            //������z����Ŋz
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesPriceConsTax
            //�ېŋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationDivCd
            //�����`�[�ԍ��i���ׁj
            serInfo.MemberInfo.Add(typeof(string)); //PartySlipNumDtl
            //���ה��l
            serInfo.MemberInfo.Add(typeof(string)); //DtlNote
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //�����ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //OrderNumber
            //�������@
            serInfo.MemberInfo.Add(typeof(Int32)); //WayToOrder
            //�`�[�����P
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo1
            //�`�[�����Q
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo2
            //�`�[�����R
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo3
            //�Г������P
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo1
            //�Г������Q
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo2
            //�Г������R
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo3
            //�ύX�O�艿
            serInfo.MemberInfo.Add(typeof(Double)); //BfListPrice
            //�ύX�O����
            serInfo.MemberInfo.Add(typeof(Double)); //BfSalesUnitPrice
            //�ύX�O����
            serInfo.MemberInfo.Add(typeof(Double)); //BfUnitCost
            //�ꎮ���הԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //CmpltSalesRowNo
            //���[�J�[�R�[�h�i�ꎮ�j
            serInfo.MemberInfo.Add(typeof(Int32)); //CmpltGoodsMakerCd
            //���[�J�[���́i�ꎮ�j
            serInfo.MemberInfo.Add(typeof(string)); //CmpltMakerName
            //���[�J�[�J�i���́i�ꎮ�j
            serInfo.MemberInfo.Add(typeof(string)); //CmpltMakerKanaName
            //���i���́i�ꎮ�j
            serInfo.MemberInfo.Add(typeof(string)); //CmpltGoodsName
            //���ʁi�ꎮ�j
            serInfo.MemberInfo.Add(typeof(Double)); //CmpltShipmentCnt
            //����P���i�ꎮ�j
            serInfo.MemberInfo.Add(typeof(Double)); //CmpltSalesUnPrcFl
            //������z�i�ꎮ�j
            serInfo.MemberInfo.Add(typeof(Int64)); //CmpltSalesMoney
            //�����P���i�ꎮ�j
            serInfo.MemberInfo.Add(typeof(Double)); //CmpltSalesUnitCost
            //�������z�i�ꎮ�j
            serInfo.MemberInfo.Add(typeof(Int64)); //CmpltCost
            //�����`�[�ԍ��i�ꎮ�j
            serInfo.MemberInfo.Add(typeof(string)); //CmpltPartySalSlNum
            //�ꎮ���l
            serInfo.MemberInfo.Add(typeof(string)); //CmpltNote
            //����p�i��
            serInfo.MemberInfo.Add(typeof(string)); //PrtGoodsNo
            //����p���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtMakerCode
            //����p���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //PrtMakerName
            //�L�����y�[���R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CampaignCode
            //�L�����y�[������
            serInfo.MemberInfo.Add(typeof(string)); //CampaignName
            //���i���
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsDivCd
            //�񓚔[��
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate
            //���T�C�N���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //RecycleDiv
            //���T�C�N���敪����
            serInfo.MemberInfo.Add(typeof(string)); //RecycleDivNm
            //�󒍕��@
            serInfo.MemberInfo.Add(typeof(Int32)); //WayToAcptOdr
            //�����񓚋敪(SCM)
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoAnswerDivSCM
            //�d����
            serInfo.MemberInfo.Add(typeof(Int32)); //StokDate
            //�󔭒����
            serInfo.MemberInfo.Add(typeof(Int16)); //AcceptOrOrderKind
            //�⍇���ԍ�
            serInfo.MemberInfo.Add(typeof(Int64)); //InquiryNumber
            //�⍇���s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //InqRowNumber


            serInfo.Serialize(writer, serInfo);
            if (graph is SalesDetailWork)
            {
                SalesDetailWork temp = (SalesDetailWork)graph;

                SetSalesDetailWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalesDetailWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalesDetailWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalesDetailWork temp in lst)
                {
                    SetSalesDetailWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalesDetailWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 146;

        /// <summary>
        ///  SalesDetailWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesDetailWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSalesDetailWork(System.IO.BinaryWriter writer, SalesDetailWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //�X�V�]�ƈ��R�[�h
            writer.Write(temp.UpdEmployeeCode);
            //�X�V�A�Z���u��ID1
            writer.Write(temp.UpdAssemblyId1);
            //�X�V�A�Z���u��ID2
            writer.Write(temp.UpdAssemblyId2);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //�󒍔ԍ�
            writer.Write(temp.AcceptAnOrderNo);
            //�󒍃X�e�[�^�X
            writer.Write(temp.AcptAnOdrStatus);
            //����`�[�ԍ�
            writer.Write(temp.SalesSlipNum);
            //����s�ԍ�
            writer.Write(temp.SalesRowNo);
            //����s�ԍ��}��
            writer.Write(temp.SalesRowDerivNo);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //����R�[�h
            writer.Write(temp.SubSectionCode);
            //������t
            writer.Write(temp.SalesDate);
            //���ʒʔ�
            writer.Write(temp.CommonSeqNo);
            //���㖾�גʔ�
            writer.Write(temp.SalesSlipDtlNum);
            //�󒍃X�e�[�^�X�i���j
            writer.Write(temp.AcptAnOdrStatusSrc);
            //���㖾�גʔԁi���j
            writer.Write(temp.SalesSlipDtlNumSrc);
            //�d���`���i�����j
            writer.Write(temp.SupplierFormalSync);
            //�d�����גʔԁi�����j
            writer.Write(temp.StockSlipDtlNumSync);
            //����`�[�敪�i���ׁj
            writer.Write(temp.SalesSlipCdDtl);
            //�[�i�����\���
            writer.Write(temp.DeliGdsCmpltDueDate);
            //���i����
            writer.Write(temp.GoodsKindCode);
            //���i�����敪
            writer.Write(temp.GoodsSearchDivCd);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���[�J�[����
            writer.Write(temp.MakerName);
            //���[�J�[�J�i����
            writer.Write(temp.MakerKanaName);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i����
            writer.Write(temp.GoodsName);
            //���i���̃J�i
            writer.Write(temp.GoodsNameKana);
            //���i�啪�ރR�[�h
            writer.Write(temp.GoodsLGroup);
            //���i�啪�ޖ���
            writer.Write(temp.GoodsLGroupName);
            //���i�����ރR�[�h
            writer.Write(temp.GoodsMGroup);
            //���i�����ޖ���
            writer.Write(temp.GoodsMGroupName);
            //BL�O���[�v�R�[�h
            writer.Write(temp.BLGroupCode);
            //BL�O���[�v�R�[�h����
            writer.Write(temp.BLGroupName);
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
            //����݌Ɏ�񂹋敪
            writer.Write(temp.SalesOrderDivCd);
            //�I�[�v�����i�敪
            writer.Write(temp.OpenPriceDiv);
            //���i�|�������N
            writer.Write(temp.GoodsRateRank);
            //���Ӑ�|���O���[�v�R�[�h
            writer.Write(temp.CustRateGrpCode);
            //�艿��
            writer.Write(temp.ListPriceRate);
            //�|���ݒ苒�_�i�艿�j
            writer.Write(temp.RateSectPriceUnPrc);
            //�|���ݒ�敪�i�艿�j
            writer.Write(temp.RateDivLPrice);
            //�P���Z�o�敪�i�艿�j
            writer.Write(temp.UnPrcCalcCdLPrice);
            //���i�敪�i�艿�j
            writer.Write(temp.PriceCdLPrice);
            //��P���i�艿�j
            writer.Write(temp.StdUnPrcLPrice);
            //�[�������P�ʁi�艿�j
            writer.Write(temp.FracProcUnitLPrice);
            //�[�������i�艿�j
            writer.Write(temp.FracProcLPrice);
            //�艿�i�ō��C�����j
            writer.Write(temp.ListPriceTaxIncFl);
            //�艿�i�Ŕ��C�����j
            writer.Write(temp.ListPriceTaxExcFl);
            //�艿�ύX�敪
            writer.Write(temp.ListPriceChngCd);
            //������
            writer.Write(temp.SalesRate);
            //�|���ݒ苒�_�i����P���j
            writer.Write(temp.RateSectSalUnPrc);
            //�|���ݒ�敪�i����P���j
            writer.Write(temp.RateDivSalUnPrc);
            //�P���Z�o�敪�i����P���j
            writer.Write(temp.UnPrcCalcCdSalUnPrc);
            //���i�敪�i����P���j
            writer.Write(temp.PriceCdSalUnPrc);
            //��P���i����P���j
            writer.Write(temp.StdUnPrcSalUnPrc);
            //�[�������P�ʁi����P���j
            writer.Write(temp.FracProcUnitSalUnPrc);
            //�[�������i����P���j
            writer.Write(temp.FracProcSalUnPrc);
            //����P���i�ō��C�����j
            writer.Write(temp.SalesUnPrcTaxIncFl);
            //����P���i�Ŕ��C�����j
            writer.Write(temp.SalesUnPrcTaxExcFl);
            //����P���ύX�敪
            writer.Write(temp.SalesUnPrcChngCd);
            //������
            writer.Write(temp.CostRate);
            //�|���ݒ苒�_�i�����P���j
            writer.Write(temp.RateSectCstUnPrc);
            //�|���ݒ�敪�i�����P���j
            writer.Write(temp.RateDivUnCst);
            //�P���Z�o�敪�i�����P���j
            writer.Write(temp.UnPrcCalcCdUnCst);
            //���i�敪�i�����P���j
            writer.Write(temp.PriceCdUnCst);
            //��P���i�����P���j
            writer.Write(temp.StdUnPrcUnCst);
            //�[�������P�ʁi�����P���j
            writer.Write(temp.FracProcUnitUnCst);
            //�[�������i�����P���j
            writer.Write(temp.FracProcUnCst);
            //�����P��
            writer.Write(temp.SalesUnitCost);
            //�����P���ύX�敪
            writer.Write(temp.SalesUnitCostChngDiv);
            //BL���i�R�[�h�i�|���j
            writer.Write(temp.RateBLGoodsCode);
            //BL���i�R�[�h���́i�|���j
            writer.Write(temp.RateBLGoodsName);
            //���i�|���O���[�v�R�[�h�i�|���j
            writer.Write(temp.RateGoodsRateGrpCd);
            //���i�|���O���[�v���́i�|���j
            writer.Write(temp.RateGoodsRateGrpNm);
            //BL�O���[�v�R�[�h�i�|���j
            writer.Write(temp.RateBLGroupCode);
            //BL�O���[�v���́i�|���j
            writer.Write(temp.RateBLGroupName);
            //BL���i�R�[�h�i����j
            writer.Write(temp.PrtBLGoodsCode);
            //BL���i�R�[�h���́i����j
            writer.Write(temp.PrtBLGoodsName);
            //�̔��敪�R�[�h
            writer.Write(temp.SalesCode);
            //�̔��敪����
            writer.Write(temp.SalesCdNm);
            //��ƍH��
            writer.Write(temp.WorkManHour);
            //�o�א�
            writer.Write(temp.ShipmentCnt);
            //�󒍐���
            writer.Write(temp.AcceptAnOrderCnt);
            //�󒍒�����
            writer.Write(temp.AcptAnOdrAdjustCnt);
            //�󒍎c��
            writer.Write(temp.AcptAnOdrRemainCnt);
            //�c���X�V��
            writer.Write(temp.RemainCntUpdDate);
            //������z�i�ō��݁j
            writer.Write(temp.SalesMoneyTaxInc);
            //������z�i�Ŕ����j
            writer.Write(temp.SalesMoneyTaxExc);
            //����
            writer.Write(temp.Cost);
            //�e���`�F�b�N�敪
            writer.Write(temp.GrsProfitChkDiv);
            //���㏤�i�敪
            writer.Write(temp.SalesGoodsCd);
            //������z����Ŋz
            writer.Write(temp.SalesPriceConsTax);
            //�ېŋ敪
            writer.Write(temp.TaxationDivCd);
            //�����`�[�ԍ��i���ׁj
            writer.Write(temp.PartySlipNumDtl);
            //���ה��l
            writer.Write(temp.DtlNote);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //�����ԍ�
            writer.Write(temp.OrderNumber);
            //�������@
            writer.Write(temp.WayToOrder);
            //�`�[�����P
            writer.Write(temp.SlipMemo1);
            //�`�[�����Q
            writer.Write(temp.SlipMemo2);
            //�`�[�����R
            writer.Write(temp.SlipMemo3);
            //�Г������P
            writer.Write(temp.InsideMemo1);
            //�Г������Q
            writer.Write(temp.InsideMemo2);
            //�Г������R
            writer.Write(temp.InsideMemo3);
            //�ύX�O�艿
            writer.Write(temp.BfListPrice);
            //�ύX�O����
            writer.Write(temp.BfSalesUnitPrice);
            //�ύX�O����
            writer.Write(temp.BfUnitCost);
            //�ꎮ���הԍ�
            writer.Write(temp.CmpltSalesRowNo);
            //���[�J�[�R�[�h�i�ꎮ�j
            writer.Write(temp.CmpltGoodsMakerCd);
            //���[�J�[���́i�ꎮ�j
            writer.Write(temp.CmpltMakerName);
            //���[�J�[�J�i���́i�ꎮ�j
            writer.Write(temp.CmpltMakerKanaName);
            //���i���́i�ꎮ�j
            writer.Write(temp.CmpltGoodsName);
            //���ʁi�ꎮ�j
            writer.Write(temp.CmpltShipmentCnt);
            //����P���i�ꎮ�j
            writer.Write(temp.CmpltSalesUnPrcFl);
            //������z�i�ꎮ�j
            writer.Write(temp.CmpltSalesMoney);
            //�����P���i�ꎮ�j
            writer.Write(temp.CmpltSalesUnitCost);
            //�������z�i�ꎮ�j
            writer.Write(temp.CmpltCost);
            //�����`�[�ԍ��i�ꎮ�j
            writer.Write(temp.CmpltPartySalSlNum);
            //�ꎮ���l
            writer.Write(temp.CmpltNote);
            //����p�i��
            writer.Write(temp.PrtGoodsNo);
            //����p���[�J�[�R�[�h
            writer.Write(temp.PrtMakerCode);
            //����p���[�J�[����
            writer.Write(temp.PrtMakerName);
            //�L�����y�[���R�[�h
            writer.Write(temp.CampaignCode);
            //�L�����y�[������
            writer.Write(temp.CampaignName);
            //���i���
            writer.Write(temp.GoodsDivCd);
            //�񓚔[��
            writer.Write(temp.AnswerDelivDate);
            //���T�C�N���敪
            writer.Write(temp.RecycleDiv);
            //���T�C�N���敪����
            writer.Write(temp.RecycleDivNm);
            //�󒍕��@
            writer.Write(temp.WayToAcptOdr);
            //�����񓚋敪(SCM)
            writer.Write(temp.AutoAnswerDivSCM);
            //�d����
            writer.Write(temp.StokDate);
            //�󔭒����
            writer.Write(temp.AcceptOrOrderKind);
            //�⍇���ԍ�
            writer.Write(temp.InquiryNumber);
            //�⍇���s�ԍ�
            writer.Write(temp.InqRowNumber);

        }

        /// <summary>
        ///  SalesDetailWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SalesDetailWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesDetailWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SalesDetailWork GetSalesDetailWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SalesDetailWork temp = new SalesDetailWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //�X�V�]�ƈ��R�[�h
            temp.UpdEmployeeCode = reader.ReadString();
            //�X�V�A�Z���u��ID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //�X�V�A�Z���u��ID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //�󒍔ԍ�
            temp.AcceptAnOrderNo = reader.ReadInt32();
            //�󒍃X�e�[�^�X
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //����`�[�ԍ�
            temp.SalesSlipNum = reader.ReadString();
            //����s�ԍ�
            temp.SalesRowNo = reader.ReadInt32();
            //����s�ԍ��}��
            temp.SalesRowDerivNo = reader.ReadInt32();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //����R�[�h
            temp.SubSectionCode = reader.ReadInt32();
            //������t
            temp.SalesDate = reader.ReadInt32();
            //���ʒʔ�
            temp.CommonSeqNo = reader.ReadInt64();
            //���㖾�גʔ�
            temp.SalesSlipDtlNum = reader.ReadInt64();
            //�󒍃X�e�[�^�X�i���j
            temp.AcptAnOdrStatusSrc = reader.ReadInt32();
            //���㖾�גʔԁi���j
            temp.SalesSlipDtlNumSrc = reader.ReadInt64();
            //�d���`���i�����j
            temp.SupplierFormalSync = reader.ReadInt32();
            //�d�����גʔԁi�����j
            temp.StockSlipDtlNumSync = reader.ReadInt64();
            //����`�[�敪�i���ׁj
            temp.SalesSlipCdDtl = reader.ReadInt32();
            //�[�i�����\���
            temp.DeliGdsCmpltDueDate = reader.ReadInt32();
            //���i����
            temp.GoodsKindCode = reader.ReadInt32();
            //���i�����敪
            temp.GoodsSearchDivCd = reader.ReadInt32();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���[�J�[����
            temp.MakerName = reader.ReadString();
            //���[�J�[�J�i����
            temp.MakerKanaName = reader.ReadString();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i����
            temp.GoodsName = reader.ReadString();
            //���i���̃J�i
            temp.GoodsNameKana = reader.ReadString();
            //���i�啪�ރR�[�h
            temp.GoodsLGroup = reader.ReadInt32();
            //���i�啪�ޖ���
            temp.GoodsLGroupName = reader.ReadString();
            //���i�����ރR�[�h
            temp.GoodsMGroup = reader.ReadInt32();
            //���i�����ޖ���
            temp.GoodsMGroupName = reader.ReadString();
            //BL�O���[�v�R�[�h
            temp.BLGroupCode = reader.ReadInt32();
            //BL�O���[�v�R�[�h����
            temp.BLGroupName = reader.ReadString();
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
            //����݌Ɏ�񂹋敪
            temp.SalesOrderDivCd = reader.ReadInt32();
            //�I�[�v�����i�敪
            temp.OpenPriceDiv = reader.ReadInt32();
            //���i�|�������N
            temp.GoodsRateRank = reader.ReadString();
            //���Ӑ�|���O���[�v�R�[�h
            temp.CustRateGrpCode = reader.ReadInt32();
            //�艿��
            temp.ListPriceRate = reader.ReadDouble();
            //�|���ݒ苒�_�i�艿�j
            temp.RateSectPriceUnPrc = reader.ReadString();
            //�|���ݒ�敪�i�艿�j
            temp.RateDivLPrice = reader.ReadString();
            //�P���Z�o�敪�i�艿�j
            temp.UnPrcCalcCdLPrice = reader.ReadInt32();
            //���i�敪�i�艿�j
            temp.PriceCdLPrice = reader.ReadInt32();
            //��P���i�艿�j
            temp.StdUnPrcLPrice = reader.ReadDouble();
            //�[�������P�ʁi�艿�j
            temp.FracProcUnitLPrice = reader.ReadDouble();
            //�[�������i�艿�j
            temp.FracProcLPrice = reader.ReadInt32();
            //�艿�i�ō��C�����j
            temp.ListPriceTaxIncFl = reader.ReadDouble();
            //�艿�i�Ŕ��C�����j
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //�艿�ύX�敪
            temp.ListPriceChngCd = reader.ReadInt32();
            //������
            temp.SalesRate = reader.ReadDouble();
            //�|���ݒ苒�_�i����P���j
            temp.RateSectSalUnPrc = reader.ReadString();
            //�|���ݒ�敪�i����P���j
            temp.RateDivSalUnPrc = reader.ReadString();
            //�P���Z�o�敪�i����P���j
            temp.UnPrcCalcCdSalUnPrc = reader.ReadInt32();
            //���i�敪�i����P���j
            temp.PriceCdSalUnPrc = reader.ReadInt32();
            //��P���i����P���j
            temp.StdUnPrcSalUnPrc = reader.ReadDouble();
            //�[�������P�ʁi����P���j
            temp.FracProcUnitSalUnPrc = reader.ReadDouble();
            //�[�������i����P���j
            temp.FracProcSalUnPrc = reader.ReadInt32();
            //����P���i�ō��C�����j
            temp.SalesUnPrcTaxIncFl = reader.ReadDouble();
            //����P���i�Ŕ��C�����j
            temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
            //����P���ύX�敪
            temp.SalesUnPrcChngCd = reader.ReadInt32();
            //������
            temp.CostRate = reader.ReadDouble();
            //�|���ݒ苒�_�i�����P���j
            temp.RateSectCstUnPrc = reader.ReadString();
            //�|���ݒ�敪�i�����P���j
            temp.RateDivUnCst = reader.ReadString();
            //�P���Z�o�敪�i�����P���j
            temp.UnPrcCalcCdUnCst = reader.ReadInt32();
            //���i�敪�i�����P���j
            temp.PriceCdUnCst = reader.ReadInt32();
            //��P���i�����P���j
            temp.StdUnPrcUnCst = reader.ReadDouble();
            //�[�������P�ʁi�����P���j
            temp.FracProcUnitUnCst = reader.ReadDouble();
            //�[�������i�����P���j
            temp.FracProcUnCst = reader.ReadInt32();
            //�����P��
            temp.SalesUnitCost = reader.ReadDouble();
            //�����P���ύX�敪
            temp.SalesUnitCostChngDiv = reader.ReadInt32();
            //BL���i�R�[�h�i�|���j
            temp.RateBLGoodsCode = reader.ReadInt32();
            //BL���i�R�[�h���́i�|���j
            temp.RateBLGoodsName = reader.ReadString();
            //���i�|���O���[�v�R�[�h�i�|���j
            temp.RateGoodsRateGrpCd = reader.ReadInt32();
            //���i�|���O���[�v���́i�|���j
            temp.RateGoodsRateGrpNm = reader.ReadString();
            //BL�O���[�v�R�[�h�i�|���j
            temp.RateBLGroupCode = reader.ReadInt32();
            //BL�O���[�v���́i�|���j
            temp.RateBLGroupName = reader.ReadString();
            //BL���i�R�[�h�i����j
            temp.PrtBLGoodsCode = reader.ReadInt32();
            //BL���i�R�[�h���́i����j
            temp.PrtBLGoodsName = reader.ReadString();
            //�̔��敪�R�[�h
            temp.SalesCode = reader.ReadInt32();
            //�̔��敪����
            temp.SalesCdNm = reader.ReadString();
            //��ƍH��
            temp.WorkManHour = reader.ReadDouble();
            //�o�א�
            temp.ShipmentCnt = reader.ReadDouble();
            //�󒍐���
            temp.AcceptAnOrderCnt = reader.ReadDouble();
            //�󒍒�����
            temp.AcptAnOdrAdjustCnt = reader.ReadDouble();
            //�󒍎c��
            temp.AcptAnOdrRemainCnt = reader.ReadDouble();
            //�c���X�V��
            temp.RemainCntUpdDate = reader.ReadInt32();
            //������z�i�ō��݁j
            temp.SalesMoneyTaxInc = reader.ReadInt64();
            //������z�i�Ŕ����j
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //����
            temp.Cost = reader.ReadInt64();
            //�e���`�F�b�N�敪
            temp.GrsProfitChkDiv = reader.ReadInt32();
            //���㏤�i�敪
            temp.SalesGoodsCd = reader.ReadInt32();
            //������z����Ŋz
            temp.SalesPriceConsTax = reader.ReadInt64();
            //�ېŋ敪
            temp.TaxationDivCd = reader.ReadInt32();
            //�����`�[�ԍ��i���ׁj
            temp.PartySlipNumDtl = reader.ReadString();
            //���ה��l
            temp.DtlNote = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //�����ԍ�
            temp.OrderNumber = reader.ReadString();
            //�������@
            temp.WayToOrder = reader.ReadInt32();
            //�`�[�����P
            temp.SlipMemo1 = reader.ReadString();
            //�`�[�����Q
            temp.SlipMemo2 = reader.ReadString();
            //�`�[�����R
            temp.SlipMemo3 = reader.ReadString();
            //�Г������P
            temp.InsideMemo1 = reader.ReadString();
            //�Г������Q
            temp.InsideMemo2 = reader.ReadString();
            //�Г������R
            temp.InsideMemo3 = reader.ReadString();
            //�ύX�O�艿
            temp.BfListPrice = reader.ReadDouble();
            //�ύX�O����
            temp.BfSalesUnitPrice = reader.ReadDouble();
            //�ύX�O����
            temp.BfUnitCost = reader.ReadDouble();
            //�ꎮ���הԍ�
            temp.CmpltSalesRowNo = reader.ReadInt32();
            //���[�J�[�R�[�h�i�ꎮ�j
            temp.CmpltGoodsMakerCd = reader.ReadInt32();
            //���[�J�[���́i�ꎮ�j
            temp.CmpltMakerName = reader.ReadString();
            //���[�J�[�J�i���́i�ꎮ�j
            temp.CmpltMakerKanaName = reader.ReadString();
            //���i���́i�ꎮ�j
            temp.CmpltGoodsName = reader.ReadString();
            //���ʁi�ꎮ�j
            temp.CmpltShipmentCnt = reader.ReadDouble();
            //����P���i�ꎮ�j
            temp.CmpltSalesUnPrcFl = reader.ReadDouble();
            //������z�i�ꎮ�j
            temp.CmpltSalesMoney = reader.ReadInt64();
            //�����P���i�ꎮ�j
            temp.CmpltSalesUnitCost = reader.ReadDouble();
            //�������z�i�ꎮ�j
            temp.CmpltCost = reader.ReadInt64();
            //�����`�[�ԍ��i�ꎮ�j
            temp.CmpltPartySalSlNum = reader.ReadString();
            //�ꎮ���l
            temp.CmpltNote = reader.ReadString();
            //����p�i��
            temp.PrtGoodsNo = reader.ReadString();
            //����p���[�J�[�R�[�h
            temp.PrtMakerCode = reader.ReadInt32();
            //����p���[�J�[����
            temp.PrtMakerName = reader.ReadString();
            //�L�����y�[���R�[�h
            temp.CampaignCode = reader.ReadInt32();
            //�L�����y�[������
            temp.CampaignName = reader.ReadString();
            //���i���
            temp.GoodsDivCd = reader.ReadInt32();
            //�񓚔[��
            temp.AnswerDelivDate = reader.ReadString();
            //���T�C�N���敪
            temp.RecycleDiv = reader.ReadInt32();
            //���T�C�N���敪����
            temp.RecycleDivNm = reader.ReadString();
            //�󒍕��@
            temp.WayToAcptOdr = reader.ReadInt32();
            //�����񓚋敪(SCM)
            temp.AutoAnswerDivSCM = reader.ReadInt32();
            //�d����
            temp.StokDate = reader.ReadInt32();
            //�󔭒����
            temp.AcceptOrOrderKind = reader.ReadInt16();
            //�⍇���ԍ�
            temp.InquiryNumber = reader.ReadInt64();
            //�⍇���s�ԍ�
            temp.InqRowNumber = reader.ReadInt32();


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
        /// <returns>SalesDetailWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesDetailWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalesDetailWork temp = GetSalesDetailWork(reader, serInfo);
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
                    retValue = (SalesDetailWork[])lst.ToArray(typeof(SalesDetailWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
