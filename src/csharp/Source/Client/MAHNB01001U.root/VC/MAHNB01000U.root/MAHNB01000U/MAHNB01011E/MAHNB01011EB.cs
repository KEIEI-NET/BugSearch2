using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SalesDetail
    /// <summary>
    ///                      ���㖾�׃f�[�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���㖾�׃f�[�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2008/10/21  (CSharp File Generated Date)</br>
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
    /// <br>Update Note      :   2008/10/20  ���n</br>
    /// <br>                 :   ������f�[�^���C�A�E�g�ɑ΂��A�ȉ��̍��ڒǉ�</br>
    /// <br>                 :   ���ʃL�[</br>
    /// <br>                 :   �ԗ���񋤒ʃL�[</br>
    /// <br>                 :   �o�א������l�A�o�א������l(�ύX�`�F�b�N�p)</br>
    /// <br>                 :   �󒍐������l�A�󒍐������l(�ύX�`�F�b�N�p)</br>
    /// <br>                 :   ����P��(�ō�)�����l�A����P��(�Ŕ�)�����l</br>
    /// <br>                 :   ���P��(�ō�)�����l�A���P��(�Ŕ�)�����l</br>
    /// <br>Update Note      :   2009/10/19 ���M</br>
    /// <br>                     PM.NS-3-A�EPM.NS�ێ�˗��A</br>
    /// <br>                     �W�����i�I��L���敪��ǉ�</br>
    /// <br>Update Note      :   2010/02/26 ���n ��� </br>
    /// <br>                     SCM�Ή�</br>
    /// <br>Update Note      :   2010/04/06 ���M</br>
    /// <br>                     EditStatus��ǉ�</br>
    /// <br>Update Note      :   2011/07/18 ���R</br>
    /// <br>                     �����񓚋敪��ǉ�</br>
    /// <br>Update Note      :   2011/08/10 ����</br>
    /// <br>                     �����񓚋敪(SCM)�A�󔭒���ʁA�⍇���ԍ��A�⍇���s�ԍ���ǉ�</br>                     
    /// <br>Update Note      : �@2012/01/16 30517 �Ė� �x��</br>
    /// <br>                   �@SCM���ǁE���L�����Ή�</br>
    /// <br>Update Note: 2012/05/02 20056 ���n ���</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��Q�Ή�</br>
    /// <br>             ���ǁF�ݏo�d���������͑Ή�</br>
    /// <br>Update Note: 2012/06/15 �g�� �F��</br>
    /// <br>             ��Q�Ή� ��90</br>
    /// <br>             SCM��Q��171�C�����̃o�O�Ή��B</br>
    /// <br>Update Note: 2012/06/19 ���� ����q</br>
    /// <br>             ��Q�Ή� ��104</br>
    /// <br>             �V�X�e���e�X�g��Q��90�C�����̃o�O�Ή��B</br>
    /// </remarks>
    public class SalesDetail
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
        private DateTime _salesDate;

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
        private DateTime _deliGdsCmpltDueDate;

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
        private DateTime _remainCntUpdDate;

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

        // --- ADD 2009/10/19 ---------->>>>>
        /// <summary>����p�i�ԗL���敪</summary>
        private Int32 _selectedGoodsNoDiv;
        // --- ADD 2009/10/19 ----------<<<<<

        /// <summary>����p�i��</summary>
        private string _prtGoodsNo = "";

        /// <summary>����p���[�J�[�R�[�h</summary>
        private Int32 _prtMakerCode;

        /// <summary>����p���[�J�[����</summary>
        private string _prtMakerName = "";

        /// <summary>���ʃL�[</summary>
        private Guid _dtlRelationGuid;

        /// <summary>�ԗ���񋤒ʃL�[</summary>
        private Guid _carRelationGuid;

        /// <summary>�o�א������l</summary>
        private Double _shipmentCntDefault;

        /// <summary>�o�א������l�i�ύX�`�F�b�N�p�j</summary>
        /// <remarks>�V�K:��������(�o�א�),�C��:�o�א�</remarks>
        private Double _shipmentCntDefForChk;

        /// <summary>�󒍐������l</summary>
        private Double _acceptAnOrderCntDefault;

        /// <summary>�󒍐������l�i�ύX�`�F�b�N�p�j</summary>
        /// <remarks>�V�K:��������(�o�א�),�C��:�o�א�(�󒍃f�[�^)</remarks>
        private Double _acceptAnOrderCntDefForChk;

        /// <summary>����P���i�ō��C�����j�����l</summary>
        private Double _salesUnPrcTaxIncFlDefault;

        /// <summary>����P���i�Ŕ��C�����j�����l</summary>
        private Double _salesUnPrcTaxExcFlDefault;

        /// <summary>�����P���i�ō��j�����l</summary>
        private Double _salesUnitCostTaxIncDefault;

        /// <summary>�����P���i�Ŕ��j�����l</summary>
        private Double _salesUnitCostTacExcDefault;

        //>>>2010/02/26
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

        /// <summary>���i�Ǘ��ԍ�</summary>
        /// <remarks>PS�Ǘ��ԍ�</remarks>
        private Int32 _goodsMngNo;

        /// <summary>�⍇���s�ԍ�</summary>
        private Int32 _inqRowNumber;

        /// <summary>�⍇���s�ԍ��}��</summary>
        private Int32 _inqRowNumDerivedNo;
        //<<<2010/02/26

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>BL���i�R�[�h����</summary>
        private string _bLGoodsName = "";

        // --- ADD 2010/04/06 ---------->>>>>
        /// <summary>�s���</summary>
        private int _editStatus;

        /// <summary>�s���</summary>
        private int _rowStatus;

        /// <summary>���z����͋敪</summary>
        private int _salesMoneyInputDiv;

        /// <summary>�o�א�(�\���p)</summary>
        private double _shipmentCntDisplay;

        /// <summary>���݌ɐ�(�\���p)</summary>
        private double _supplierStockDisplay;

        /// <summary>�W�����i(�\���p)</summary>
        private double _listPriceDisplay;

        /// <summary>�d����</summary>
        private DateTime _stockDate;

        /// <summary>BO</summary>
        private string _boCode;

        /// <summary>������</summary>
        private int _supplierCdForOrder;

        /// <summary>�����於��</summary>
        private string _supplierSnmForOrder;

        /// <summary>�[�i�敪</summary>
        private string _deliveredGoodsDivNm;

        /// <summary>�g�[�i�敪</summary>
        private string _followDeliGoodsDivNm;

        /// <summary>�w�苒�_</summary>
        private string _uOEResvdSectionNm;

        /// <summary>�[�i�敪</summary>
        private string _uOEDeliGoodsDiv;

        /// <summary>�g�[�i�敪</summary>
        private string _followDeliGoodsDiv;

        /// <summary>�w�苒�_</summary>
        private string _uOEResvdSection;

        /// <summary>�d���`�[�ԍ�</summary>
        private string _partySalesSlipNum;

        /// <summary>���i�������</summary>
        private int _searchPartsModeState;
        // --- ADD 2009/04/06 ----------<<<<<

        // 2012/01/16 Add >>>
        /// <summary>���L����</summary>
        private string _goodsSpecialNote = string.Empty;
        // 2012/01/16 Add <<<

        //>>>2012/05/02
        /// <summary>�ݏo�����d����</summary>
        private Int32 _rentSyncSupplier = 0;
        /// <summary>�ݏo�����d����</summary>
        private DateTime _rentSyncStockDate = DateTime.MinValue;
        /// <summary>�ݏo�����d���`�[�ԍ�</summary>
        private string _rentSyncSupSlipNo = string.Empty;
        //<<<2012/05/02

        // ---------------------- ADD START 2011/07/18 ���R ----------------->>>>>
        /// <summary>�����񓚋敪(SCM)</summary>
        /// <remarks>0:�ʏ�(PCC�A�g�Ȃ�)�A1:�蓮�񓚁A2:������</remarks>
        private Int32 _autoAnswerDivSCM;

        /// public propaty name  :  AutoAnswerDivSCM
        /// <summary>�����񓚋敪(SCM)�v���p�e�B</summary>
        /// <value>1:�ʏ�(PCC�A�g�Ȃ�)�A2:�蓮�񓚁A3:������</value>
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
        // ---------------------- ADD END   2011.02.09 ���R -----------------<<<<<

        // 2012/06/15 ADD T.Yoshioka 90 ---------------->>>>>>>>>>>>>>>>>>>>>>>>> 
        /// <summary>�������i���[�J�[�R�[�h</summary>
        private Int32 _pureGoodsMakerCd;
        /// <summary>�������i���[�J�[�R�[�h</summary>
        public Int32 PureGoodsMakerCd
        {
            get { return _pureGoodsMakerCd; }
            set { _pureGoodsMakerCd = value; }
        }

        /// <summary>�񓚏������i�ԍ�</summary>
        // UPD 2012/06/19 C.Yugami 104 ----------------->>>>>
        //private string _ansPureGoodsNo;
        private string _ansPureGoodsNo = string.Empty;
        // UPD 2012/06/19 C.Yugami 104 -----------------<<<<<
        /// <summary>�񓚏������i�ԍ�</summary>
        public string AnsPureGoodsNo
        {
            get { return _ansPureGoodsNo; }
            set { _ansPureGoodsNo = value; }
        }
        // 2012/06/15 ADD T.Yoshioka 90 ----------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        
        // --- ADD 2011/08/08 ---------->>>>>
        /// <summary>�󔭒����</summary>
        private Int16 _acceptOrOrderKind;

        /// <summary>�⍇���ԍ�</summary>
        private Int64 _inquiryNumber;
        // --- ADD 2011/08/08 ----------<<<<<        


        // ----ADD 2013/01/24 ���N�n�� REDMINE#34605---- >>>>>
        /// <summary>�W�����i�I���敪</summary>
        /// <remarks>0:�D��,1:����,2:������(1:N),,3:������(1:1)</remarks>
        private Int32 _priceSelectDiv;
        // ----ADD 2013/01/24 ���N�n�� REDMINE#34605---- <<<<<

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

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>�쐬���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>�쐬���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>�쐬���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>�쐬���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
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

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>�X�V���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>�X�V���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>�X�V���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>�X�V���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
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
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// public propaty name  :  SalesDateJpFormal
        /// <summary>������t �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _salesDate); }
            set { }
        }

        /// public propaty name  :  SalesDateJpInFormal
        /// <summary>������t �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _salesDate); }
            set { }
        }

        /// public propaty name  :  SalesDateAdFormal
        /// <summary>������t ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _salesDate); }
            set { }
        }

        /// public propaty name  :  SalesDateAdInFormal
        /// <summary>������t ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _salesDate); }
            set { }
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
        public DateTime DeliGdsCmpltDueDate
        {
            get { return _deliGdsCmpltDueDate; }
            set { _deliGdsCmpltDueDate = value; }
        }

        /// public propaty name  :  DeliGdsCmpltDueDateJpFormal
        /// <summary>�[�i�����\��� �a��v���p�e�B</summary>
        /// <value>�q��[��(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�����\��� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DeliGdsCmpltDueDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _deliGdsCmpltDueDate); }
            set { }
        }

        /// public propaty name  :  DeliGdsCmpltDueDateJpInFormal
        /// <summary>�[�i�����\��� �a��(��)�v���p�e�B</summary>
        /// <value>�q��[��(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�����\��� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DeliGdsCmpltDueDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _deliGdsCmpltDueDate); }
            set { }
        }

        /// public propaty name  :  DeliGdsCmpltDueDateAdFormal
        /// <summary>�[�i�����\��� ����v���p�e�B</summary>
        /// <value>�q��[��(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�����\��� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DeliGdsCmpltDueDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _deliGdsCmpltDueDate); }
            set { }
        }

        /// public propaty name  :  DeliGdsCmpltDueDateAdInFormal
        /// <summary>�[�i�����\��� ����(��)�v���p�e�B</summary>
        /// <value>�q��[��(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�����\��� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DeliGdsCmpltDueDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _deliGdsCmpltDueDate); }
            set { }
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
        public DateTime RemainCntUpdDate
        {
            get { return _remainCntUpdDate; }
            set { _remainCntUpdDate = value; }
        }

        /// public propaty name  :  RemainCntUpdDateJpFormal
        /// <summary>�c���X�V�� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �c���X�V�� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RemainCntUpdDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _remainCntUpdDate); }
            set { }
        }

        /// public propaty name  :  RemainCntUpdDateJpInFormal
        /// <summary>�c���X�V�� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �c���X�V�� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RemainCntUpdDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _remainCntUpdDate); }
            set { }
        }

        /// public propaty name  :  RemainCntUpdDateAdFormal
        /// <summary>�c���X�V�� ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �c���X�V�� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RemainCntUpdDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _remainCntUpdDate); }
            set { }
        }

        /// public propaty name  :  RemainCntUpdDateAdInFormal
        /// <summary>�c���X�V�� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �c���X�V�� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RemainCntUpdDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _remainCntUpdDate); }
            set { }
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
        /// <value>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,10:���|�p����Œ���(����),11:���E,12:���E(����)</value>
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

        // --- ADD 2009/10/19 ---------->>>>>
        /// public propaty name  :  SelectedGoodsNoDiv
        /// <summary>����p�i�ԗL���敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����p�i�ԗL���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SelectedGoodsNoDiv
        {
            get { return _selectedGoodsNoDiv; }
            set { _selectedGoodsNoDiv = value; }
        }
        // --- ADD 2009/10/19 ----------<<<<<

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

        /// public propaty name  :  DtlRelationGuid
        /// <summary>���ʃL�[�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ʃL�[�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid DtlRelationGuid
        {
            get { return _dtlRelationGuid; }
            set { _dtlRelationGuid = value; }
        }

        /// public propaty name  :  CarRelationGuid
        /// <summary>�ԗ���񋤒ʃL�[�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ���񋤒ʃL�[�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid CarRelationGuid
        {
            get { return _carRelationGuid; }
            set { _carRelationGuid = value; }
        }

        /// public propaty name  :  ShipmentCntDefault
        /// <summary>�o�א������l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א������l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCntDefault
        {
            get { return _shipmentCntDefault; }
            set { _shipmentCntDefault = value; }
        }

        /// public propaty name  :  ShipmentCntDefForChk
        /// <summary>�o�א������l�i�ύX�`�F�b�N�p�j�v���p�e�B</summary>
        /// <value>�V�K:��������(�o�א�),�C��:�o�א�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א������l�i�ύX�`�F�b�N�p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCntDefForChk
        {
            get { return _shipmentCntDefForChk; }
            set { _shipmentCntDefForChk = value; }
        }

        /// public propaty name  :  AcceptAnOrderCntDefault
        /// <summary>�󒍐������l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍐������l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AcceptAnOrderCntDefault
        {
            get { return _acceptAnOrderCntDefault; }
            set { _acceptAnOrderCntDefault = value; }
        }

        /// public propaty name  :  AcceptAnOrderCntDefForChk
        /// <summary>�󒍐������l�i�ύX�`�F�b�N�p�j�v���p�e�B</summary>
        /// <value>�V�K:��������(�o�א�),�C��:�o�א�(�󒍃f�[�^)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍐������l�i�ύX�`�F�b�N�p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AcceptAnOrderCntDefForChk
        {
            get { return _acceptAnOrderCntDefForChk; }
            set { _acceptAnOrderCntDefForChk = value; }
        }

        /// public propaty name  :  SalesUnPrcTaxIncFlDefault
        /// <summary>����P���i�ō��C�����j�����l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����P���i�ō��C�����j�����l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnPrcTaxIncFlDefault
        {
            get { return _salesUnPrcTaxIncFlDefault; }
            set { _salesUnPrcTaxIncFlDefault = value; }
        }

        /// public propaty name  :  SalesUnPrcTaxExcFlDefault
        /// <summary>����P���i�Ŕ��C�����j�����l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����P���i�Ŕ��C�����j�����l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnPrcTaxExcFlDefault
        {
            get { return _salesUnPrcTaxExcFlDefault; }
            set { _salesUnPrcTaxExcFlDefault = value; }
        }

        /// public propaty name  :  SalesUnitCostTaxIncDefault
        /// <summary>�����P���i�ō��j�����l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����P���i�ō��j�����l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnitCostTaxIncDefault
        {
            get { return _salesUnitCostTaxIncDefault; }
            set { _salesUnitCostTaxIncDefault = value; }
        }

        /// public propaty name  :  SalesUnitCostTacExcDefault
        /// <summary>�����P���i�Ŕ��j�����l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����P���i�Ŕ��j�����l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnitCostTacExcDefault
        {
            get { return _salesUnitCostTacExcDefault; }
            set { _salesUnitCostTacExcDefault = value; }
        }

        //>>>2010/02/26
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

        /// public propaty name  :  GoodsMngNo
        /// <summary>���i�Ǘ��ԍ��v���p�e�B</summary>
        /// <value>PS�Ǘ��ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�Ǘ��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMngNo
        {
            get { return _goodsMngNo; }
            set { _goodsMngNo = value; }
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

        /// public propaty name  :  InqRowNumDerivedNo
        /// <summary>�⍇���s�ԍ��}�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���s�ԍ��}�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InqRowNumDerivedNo
        {
            get { return _inqRowNumDerivedNo; }
            set { _inqRowNumDerivedNo = value; }
        }
        //<<<2010/02/26

        /// public propaty name  :  EnterpriseName
        /// <summary>��Ɩ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��Ɩ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  UpdEmployeeName
        /// <summary>�X�V�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
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

        // --- ADD 2010/04/06 ---------->>>>>
        /// public propaty name  :  EditStatus
        /// <summary>�s��ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �s��ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int EditStatus
        {
            get { return _editStatus; }
            set { _editStatus = value; }
        }

        /// public propaty name  :  RowStatus
        /// <summary>�s��ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �s��ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int RowStatus
        {
            get { return _rowStatus; }
            set { _rowStatus = value; }
        }

        /// public propaty name  :  SalesMoneyInputDiv
        /// <summary>���z����͋敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���z����͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int SalesMoneyInputDiv
        {
            get { return _salesMoneyInputDiv; }
            set { _salesMoneyInputDiv = value; }
        }

        /// public propaty name  :  ShipmentCntDisplay
        /// <summary>�o�א�(�\���p)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א�(�\���p)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public double ShipmentCntDisplay
        {
            get { return _shipmentCntDisplay; }
            set { _shipmentCntDisplay = value; }
        }

        /// public propaty name  :  SupplierStockDisplay
        /// <summary>���݌ɐ�(�\���p)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���݌ɐ�(�\���p)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public double SupplierStockDisplay
        {
            get { return _supplierStockDisplay; }
            set { _supplierStockDisplay = value; }
        }

        /// public propaty name  :  ListPriceDisplay
        /// <summary>�W�����i(�\���p)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����i(�\���p)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public double ListPriceDisplay
        {
            get { return _listPriceDisplay; }
            set { _listPriceDisplay = value; }
        }

        /// public propaty name  :  StockDate
        /// <summary>�d�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StockDate
        {
            get { return _stockDate; }
            set { _stockDate = value; }
        }

        /// public propaty name  :  BoCode
        /// <summary>BO�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BoCode
        {
            get { return _boCode; }
            set { _boCode = value; }
        }

        /// public propaty name  :  SupplierCdForOrder
        /// <summary>������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int SupplierCdForOrder
        {
            get { return _supplierCdForOrder; }
            set { _supplierCdForOrder = value; }
        }

        /// public propaty name  :  SupplierSnmForOrder
        /// <summary>�����於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSnmForOrder
        {
            get { return _supplierSnmForOrder; }
            set { _supplierSnmForOrder = value; }
        }

        /// public propaty name  :  DeliveredGoodsDivNm
        /// <summary>�[�i�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DeliveredGoodsDivNm
        {
            get { return _deliveredGoodsDivNm; }
            set { _deliveredGoodsDivNm = value; }
        }

        /// public propaty name  :  FollowDeliGoodsDivNm
        /// <summary>�g�[�i�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �g�[�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FollowDeliGoodsDivNm
        {
            get { return _followDeliGoodsDivNm; }
            set { _followDeliGoodsDivNm = value; }
        }

        /// public propaty name  :  UOEResvdSectionNm
        /// <summary>�w�苒�_�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �w�苒�_�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEResvdSectionNm
        {
            get { return _uOEResvdSectionNm; }
            set { _uOEResvdSectionNm = value; }
        }

        /// public propaty name  :  UOEDeliGoodsDiv
        /// <summary>�[�i�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEDeliGoodsDiv
        {
            get { return _uOEDeliGoodsDiv; }
            set { _uOEDeliGoodsDiv = value; }
        }

        /// public propaty name  :  FollowDeliGoodsDivNm
        /// <summary>�g�[�i�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �g�[�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FollowDeliGoodsDiv
        {
            get { return _followDeliGoodsDiv; }
            set { _followDeliGoodsDiv = value; }
        }

        /// public propaty name  :  UOEResvdSectionNm
        /// <summary>�w�苒�_�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �w�苒�_�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEResvdSection
        {
            get { return _uOEResvdSection; }
            set { _uOEResvdSection = value; }
        }

        /// public propaty name  :  PartySalesSlipNum
        /// <summary>�d���`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartySalesSlipNum
        {
            get { return _partySalesSlipNum; }
            set { _partySalesSlipNum = value; }
        }

        /// public propaty name  :  SearchPartsModeState
        /// <summary>���i������ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i������ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int SearchPartsModeState
        {
            get { return _searchPartsModeState; }
            set { _searchPartsModeState = value; }
        }

        // --- ADD 2009/04/06 ----------<<<<<

        // --- ADD 2011/08/08 ---------->>>>>
        /// public propaty name  :  AcceptOrOrderKind
        /// <summary>�󔭒���ʃv���p�e�B</summary>
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

        // --- ADD 2011/08/08 ----------<<<<<

        // 2012/01/16 Add >>>
        /// public propaty name  :  GoodsSpecialNote
        /// <summary>���L����</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���L�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsSpecialNote
        {
            get { return _goodsSpecialNote; }
            set { _goodsSpecialNote = value; }
        }
        // 2012/01/16 Add <<<

        //>>>2012/05/02
        /// <summary>
        /// �ݏo�����d����
        /// </summary>
        public Int32 RentSyncSupplier
        {
            get { return _rentSyncSupplier; }
            set { _rentSyncSupplier = value; }
        }
        /// <summary>
        /// �ݏo�����d����
        /// </summary>
        public DateTime RentSyncStockDate
        {
            get { return _rentSyncStockDate; }
            set { _rentSyncStockDate = value; }
        }
        /// <summary>
        /// �ݏo�����d���`�[�ԍ�
        /// </summary>
        public string RentSyncSupSlipNo
        {
            get { return _rentSyncSupSlipNo; }
            set { _rentSyncSupSlipNo = value; }
        }
        //<<<2012/05/02

        // ----ADD 2013/01/24 ���N�n�� REDMINE#34605---- >>>>>
        /// public propaty name  :  PriceSelectDiv
        /// <summary>�W�����i�I���敪�v���p�e�B</summary>
        /// <value>0:�D��,1:����,2:������(1:N),,3:������(1:1)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����i�I���敪�v���p�e�B</br>
        /// <br>Programer        :   ���N�n��</br>
        /// </remarks>
        public Int32 PriceSelectDiv
        {
            get { return _priceSelectDiv; }
            set { _priceSelectDiv = value; }
        }
        // ----ADD 2013/01/24 ���N�n�� REDMINE#34605---- <<<<<

        /// <summary>
        /// ���㖾�׃f�[�^�R���X�g���N�^
        /// </summary>
        /// <returns>SalesDetail�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesDetail�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesDetail()
        {
        }

        /// <summary>
        /// ���㖾�׃f�[�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="acceptAnOrderNo">�󒍔ԍ�</param>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X(10:����,20:��,30:����,40:�o��,70:�w����,80:�N���[��,99:�ꎞ�ۊ�  )</param>
        /// <param name="salesSlipNum">����`�[�ԍ�(���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B)</param>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="salesRowDerivNo">����s�ԍ��}��(�������ς̑Δ�Ŏg�p����)</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="subSectionCode">����R�[�h</param>
        /// <param name="salesDate">������t(YYYYMMDD)</param>
        /// <param name="commonSeqNo">���ʒʔ�</param>
        /// <param name="salesSlipDtlNum">���㖾�גʔ�</param>
        /// <param name="acptAnOdrStatusSrc">�󒍃X�e�[�^�X�i���j(10:����,20:��,30:����,40:�o��)</param>
        /// <param name="salesSlipDtlNumSrc">���㖾�גʔԁi���j(�v�㎞�̌��f�[�^���גʔԂ��Z�b�g)</param>
        /// <param name="supplierFormalSync">�d���`���i�����j(0:�d��,1:����)</param>
        /// <param name="stockSlipDtlNumSync">�d�����גʔԁi�����j(�����v�㎞�̎d�����גʔԂ��Z�b�g)</param>
        /// <param name="salesSlipCdDtl">����`�[�敪�i���ׁj(0:����,1:�ԕi,2:�l��,3:����,4:���v,5:���)</param>
        /// <param name="deliGdsCmpltDueDate">�[�i�����\���(�q��[��(YYYYMMDD))</param>
        /// <param name="goodsKindCode">���i����(0:���� 1:�D��)</param>
        /// <param name="goodsSearchDivCd">���i�����敪(0:BL���� 1:�i�� 2:�����)</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h(�߯���ޖ���հ�ް�o�^�͈͂��قȂ�)</param>
        /// <param name="makerName">���[�J�[����</param>
        /// <param name="makerKanaName">���[�J�[�J�i����</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="goodsName">���i����</param>
        /// <param name="goodsNameKana">���i���̃J�i</param>
        /// <param name="goodsLGroup">���i�啪�ރR�[�h(���啪�ށi���[�U�[�K�C�h�j)</param>
        /// <param name="goodsLGroupName">���i�啪�ޖ���</param>
        /// <param name="goodsMGroup">���i�����ރR�[�h(�������ރR�[�h)</param>
        /// <param name="goodsMGroupName">���i�����ޖ���</param>
        /// <param name="bLGroupCode">BL�O���[�v�R�[�h(���O���[�v�R�[�h)</param>
        /// <param name="bLGroupName">BL�O���[�v�R�[�h����</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
        /// <param name="bLGoodsFullName">BL���i�R�[�h���́i�S�p�j</param>
        /// <param name="enterpriseGanreCode">���Е��ރR�[�h</param>
        /// <param name="enterpriseGanreName">���Е��ޖ���</param>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <param name="warehouseName">�q�ɖ���</param>
        /// <param name="warehouseShelfNo">�q�ɒI��</param>
        /// <param name="salesOrderDivCd">����݌Ɏ�񂹋敪(0:��񂹁C1:�݌�)</param>
        /// <param name="openPriceDiv">�I�[�v�����i�敪(0:�ʏ�^1:�I�[�v�����i)</param>
        /// <param name="goodsRateRank">���i�|�������N(���i�̊|���p�����N)</param>
        /// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h</param>
        /// <param name="listPriceRate">�艿��</param>
        /// <param name="rateSectPriceUnPrc">�|���ݒ苒�_�i�艿�j(0:�S�Аݒ�, ���̑�:���_�R�[�h)</param>
        /// <param name="rateDivLPrice">�|���ݒ�敪�i�艿�j(A1,A2,�c)</param>
        /// <param name="unPrcCalcCdLPrice">�P���Z�o�敪�i�艿�j(1:�|��,2:�����t�o��,3:�e����)</param>
        /// <param name="priceCdLPrice">���i�敪�i�艿�j(0:�艿,1:�o�^�̔��X���i,�c 9:���[�U�[�艿)</param>
        /// <param name="stdUnPrcLPrice">��P���i�艿�j</param>
        /// <param name="fracProcUnitLPrice">�[�������P�ʁi�艿�j</param>
        /// <param name="fracProcLPrice">�[�������i�艿�j(1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ)</param>
        /// <param name="listPriceTaxIncFl">�艿�i�ō��C�����j(�Ŕ���)</param>
        /// <param name="listPriceTaxExcFl">�艿�i�Ŕ��C�����j(�ō���)</param>
        /// <param name="listPriceChngCd">�艿�ύX�敪(0:�ύX�Ȃ�,1:�ύX����@�i�艿����́j)</param>
        /// <param name="salesRate">������</param>
        /// <param name="rateSectSalUnPrc">�|���ݒ苒�_�i����P���j(0:�S�Аݒ�, ���̑�:���_�R�[�h)</param>
        /// <param name="rateDivSalUnPrc">�|���ݒ�敪�i����P���j(A1,A2,�c)</param>
        /// <param name="unPrcCalcCdSalUnPrc">�P���Z�o�敪�i����P���j(1:�|��,2:�����t�o��,3:�e����)</param>
        /// <param name="priceCdSalUnPrc">���i�敪�i����P���j(0:�艿,1:�o�^�̔��X���i,�c)</param>
        /// <param name="stdUnPrcSalUnPrc">��P���i����P���j</param>
        /// <param name="fracProcUnitSalUnPrc">�[�������P�ʁi����P���j</param>
        /// <param name="fracProcSalUnPrc">�[�������i����P���j(1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ)</param>
        /// <param name="salesUnPrcTaxIncFl">����P���i�ō��C�����j</param>
        /// <param name="salesUnPrcTaxExcFl">����P���i�Ŕ��C�����j</param>
        /// <param name="salesUnPrcChngCd">����P���ύX�敪(0:�ύX�Ȃ�,1:�ύX����@�i����P������́j)</param>
        /// <param name="costRate">������</param>
        /// <param name="rateSectCstUnPrc">�|���ݒ苒�_�i�����P���j(0:�S�Аݒ�, ���̑�:���_�R�[�h)</param>
        /// <param name="rateDivUnCst">�|���ݒ�敪�i�����P���j(A7,A8,�c)</param>
        /// <param name="unPrcCalcCdUnCst">�P���Z�o�敪�i�����P���j(1:�|��,2:�����t�o��,3:�e����)</param>
        /// <param name="priceCdUnCst">���i�敪�i�����P���j(0:�艿,1:�o�^�̔��X���i,�c)</param>
        /// <param name="stdUnPrcUnCst">��P���i�����P���j</param>
        /// <param name="fracProcUnitUnCst">�[�������P�ʁi�����P���j</param>
        /// <param name="fracProcUnCst">�[�������i�����P���j(1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ)</param>
        /// <param name="salesUnitCost">�����P��</param>
        /// <param name="salesUnitCostChngDiv">�����P���ύX�敪(0:�ύX�Ȃ�,1:�ύX����@�i�����P������́j)</param>
        /// <param name="rateBLGoodsCode">BL���i�R�[�h�i�|���j(�|���Z�o���Ɏg�p����BL�R�[�h�i���i�������ʁj)</param>
        /// <param name="rateBLGoodsName">BL���i�R�[�h���́i�|���j(�|���Z�o���Ɏg�p����BL�R�[�h���́i���i�������ʁj)</param>
        /// <param name="rateGoodsRateGrpCd">���i�|���O���[�v�R�[�h�i�|���j(�|���Z�o���Ɏg�p�������i�|���R�[�h�i���i�������ʁj)</param>
        /// <param name="rateGoodsRateGrpNm">���i�|���O���[�v���́i�|���j(�|���Z�o���Ɏg�p�������i�|�����́i���i�������ʁj)</param>
        /// <param name="rateBLGroupCode">BL�O���[�v�R�[�h�i�|���j(�|���Z�o���Ɏg�p����BL�O���[�v�R�[�h�i���i�������ʁj)</param>
        /// <param name="rateBLGroupName">BL�O���[�v���́i�|���j(�|���Z�o���Ɏg�p����BL�O���[�v���́i���i�������ʁj)</param>
        /// <param name="prtBLGoodsCode">BL���i�R�[�h�i����j(�|���Z�o���Ɏg�p����BL�R�[�h�i���i�������ʁj)</param>
        /// <param name="prtBLGoodsName">BL���i�R�[�h���́i����j(�|���Z�o���Ɏg�p����BL�R�[�h���́i���i�������ʁj)</param>
        /// <param name="salesCode">�̔��敪�R�[�h</param>
        /// <param name="salesCdNm">�̔��敪����</param>
        /// <param name="workManHour">��ƍH��</param>
        /// <param name="shipmentCnt">�o�א�</param>
        /// <param name="acceptAnOrderCnt">�󒍐���(��,�o�ׂŎg�p)</param>
        /// <param name="acptAnOdrAdjustCnt">�󒍒�����(���݂̎󒍐��́u�󒍐��ʁ{�󒍒������v�ŎZ�o)</param>
        /// <param name="acptAnOdrRemainCnt">�󒍎c��(�󒍐��ʁ{�󒍒������|�o�א�)</param>
        /// <param name="remainCntUpdDate">�c���X�V��(YYYYMMDD)</param>
        /// <param name="salesMoneyTaxInc">������z�i�ō��݁j</param>
        /// <param name="salesMoneyTaxExc">������z�i�Ŕ����j</param>
        /// <param name="cost">����</param>
        /// <param name="grsProfitChkDiv">�e���`�F�b�N�敪(0:����,1:��������,2:���v�̏グ�߂�)</param>
        /// <param name="salesGoodsCd">���㏤�i�敪(0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,10:���|�p����Œ���(����),11:���E,12:���E(����))</param>
        /// <param name="salesPriceConsTax">������z����Ŋz(������z�i�ō��݁j- ������z�i�Ŕ����j������Œ����z�����˂�)</param>
        /// <param name="taxationDivCd">�ېŋ敪(0:�ې�,1:��ې�,2:�ېŁi���Łj)</param>
        /// <param name="partySlipNumDtl">�����`�[�ԍ��i���ׁj(���Ӑ撍���ԍ��i���`No�j)</param>
        /// <param name="dtlNote">���ה��l</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="supplierSnm">�d���旪��</param>
        /// <param name="orderNumber">�����ԍ�</param>
        /// <param name="wayToOrder">�������@(0:����������,1:FAX���M,2:�I�����C������,4:�����ώ���o�^)</param>
        /// <param name="slipMemo1">�`�[�����P</param>
        /// <param name="slipMemo2">�`�[�����Q</param>
        /// <param name="slipMemo3">�`�[�����R</param>
        /// <param name="insideMemo1">�Г������P</param>
        /// <param name="insideMemo2">�Г������Q</param>
        /// <param name="insideMemo3">�Г������R</param>
        /// <param name="bfListPrice">�ύX�O�艿(�Ŕ����A�|���Z�o����)</param>
        /// <param name="bfSalesUnitPrice">�ύX�O����(�Ŕ����A�|���Z�o����)</param>
        /// <param name="bfUnitCost">�ύX�O����(�Ŕ����A�|���Z�o����)</param>
        /// <param name="cmpltSalesRowNo">�ꎮ���הԍ�(0:�ꎮ�Ȃ��@1�`�ꎮ�A��)</param>
        /// <param name="cmpltGoodsMakerCd">���[�J�[�R�[�h�i�ꎮ�j</param>
        /// <param name="cmpltMakerName">���[�J�[���́i�ꎮ�j</param>
        /// <param name="cmpltMakerKanaName">���[�J�[�J�i���́i�ꎮ�j</param>
        /// <param name="cmpltGoodsName">���i���́i�ꎮ�j</param>
        /// <param name="cmpltShipmentCnt">���ʁi�ꎮ�j</param>
        /// <param name="cmpltSalesUnPrcFl">����P���i�ꎮ�j(������z�i�ꎮ�̍��v�j/ ����  ��������R�ʎl�̌ܓ�)</param>
        /// <param name="cmpltSalesMoney">������z�i�ꎮ�j(������z�i�Ŕ����j�̓���ꎮ���ׂ̍��v)</param>
        /// <param name="cmpltSalesUnitCost">�����P���i�ꎮ�j(�������z�i�ꎮ�̍��v�j/ ����  ��������R�ʎl�̌ܓ�)</param>
        /// <param name="cmpltCost">�������z�i�ꎮ�j(�����̓���ꎮ���ׂ̍��v)</param>
        /// <param name="cmpltPartySalSlNum">�����`�[�ԍ��i�ꎮ�j(���Ӑ撍���ԍ�)</param>
        /// <param name="cmpltNote">�ꎮ���l</param>
        /// <param name="selectedGoodsNoDiv">����p�i�ԗL���敪</param>
        /// <param name="prtGoodsNo">����p�i��</param>
        /// <param name="prtMakerCode">����p���[�J�[�R�[�h</param>
        /// <param name="prtMakerName">����p���[�J�[����</param>
        /// <param name="dtlRelationGuid">���ʃL�[</param>
        /// <param name="carRelationGuid">�ԗ���񋤒ʃL�[</param>
        /// <param name="shipmentCntDefault">�o�א������l</param>
        /// <param name="shipmentCntDefForChk">�o�א������l�i�ύX�`�F�b�N�p�j(�V�K:��������(�o�א�),�C��:�o�א�)</param>
        /// <param name="acceptAnOrderCntDefault">�󒍐������l</param>
        /// <param name="acceptAnOrderCntDefForChk">�󒍐������l�i�ύX�`�F�b�N�p�j(�V�K:��������(�o�א�),�C��:�o�א�(�󒍃f�[�^))</param>
        /// <param name="salesUnPrcTaxIncFlDefault">����P���i�ō��C�����j�����l</param>
        /// <param name="salesUnPrcTaxExcFlDefault">����P���i�Ŕ��C�����j�����l</param>
        /// <param name="salesUnitCostTaxIncDefault">�����P���i�ō��j�����l</param>
        /// <param name="salesUnitCostTacExcDefault">�����P���i�Ŕ��j�����l</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="bLGoodsName">BL���i�R�[�h����</param>
        /// <param name="editStatus">�s���</param> //ADD 2010/04/06
        /// <param name="rowStatus">�s���</param> //ADD 2010/04/06
        /// <param name="salesMoneyInputDiv">���z����͋敪</param> //ADD 2010/04/06
        /// <param name="shipmentCntDisplay">�o�א�(�\���p)</param> //ADD 2010/04/06
        /// <param name="supplierStockDisplay">���݌ɐ�(�\���p)</param> //ADD 2010/04/06
        /// <param name="listPriceDisplay">�W�����i(�\���p)</param> //ADD 2010/04/06
        /// <param name="stockDate">�d����</param> //ADD 2010/04/06
        /// <param name="boCode">BO</param> //ADD 2010/04/06
        /// <param name="supplierCdForOrder">������</param> //ADD 2010/04/06
        /// <param name="supplierSnmForOrder">�����於��</param> //ADD 2010/04/06
        /// <returns>SalesDetail�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesDetail�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        //>>>2010/02/26
        //public SalesDetail(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acceptAnOrderNo, Int32 acptAnOdrStatus, string salesSlipNum, Int32 salesRowNo, Int32 salesRowDerivNo, string sectionCode, Int32 subSectionCode, DateTime salesDate, Int64 commonSeqNo, Int64 salesSlipDtlNum, Int32 acptAnOdrStatusSrc, Int64 salesSlipDtlNumSrc, Int32 supplierFormalSync, Int64 stockSlipDtlNumSync, Int32 salesSlipCdDtl, DateTime deliGdsCmpltDueDate, Int32 goodsKindCode, Int32 goodsSearchDivCd, Int32 goodsMakerCd, string makerName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, Int32 bLGoodsCode, string bLGoodsFullName, Int32 enterpriseGanreCode, string enterpriseGanreName, string warehouseCode, string warehouseName, string warehouseShelfNo, Int32 salesOrderDivCd, Int32 openPriceDiv, string goodsRateRank, Int32 custRateGrpCode, Double listPriceRate, string rateSectPriceUnPrc, string rateDivLPrice, Int32 unPrcCalcCdLPrice, Int32 priceCdLPrice, Double stdUnPrcLPrice, Double fracProcUnitLPrice, Int32 fracProcLPrice, Double listPriceTaxIncFl, Double listPriceTaxExcFl, Int32 listPriceChngCd, Double salesRate, string rateSectSalUnPrc, string rateDivSalUnPrc, Int32 unPrcCalcCdSalUnPrc, Int32 priceCdSalUnPrc, Double stdUnPrcSalUnPrc, Double fracProcUnitSalUnPrc, Int32 fracProcSalUnPrc, Double salesUnPrcTaxIncFl, Double salesUnPrcTaxExcFl, Int32 salesUnPrcChngCd, Double costRate, string rateSectCstUnPrc, string rateDivUnCst, Int32 unPrcCalcCdUnCst, Int32 priceCdUnCst, Double stdUnPrcUnCst, Double fracProcUnitUnCst, Int32 fracProcUnCst, Double salesUnitCost, Int32 salesUnitCostChngDiv, Int32 rateBLGoodsCode, string rateBLGoodsName, Int32 rateGoodsRateGrpCd, string rateGoodsRateGrpNm, Int32 rateBLGroupCode, string rateBLGroupName, Int32 prtBLGoodsCode, string prtBLGoodsName, Int32 salesCode, string salesCdNm, Double workManHour, Double shipmentCnt, Double acceptAnOrderCnt, Double acptAnOdrAdjustCnt, Double acptAnOdrRemainCnt, DateTime remainCntUpdDate, Int64 salesMoneyTaxInc, Int64 salesMoneyTaxExc, Int64 cost, Int32 grsProfitChkDiv, Int32 salesGoodsCd, Int64 salesPriceConsTax, Int32 taxationDivCd, string partySlipNumDtl, string dtlNote, Int32 supplierCd, string supplierSnm, string orderNumber, Int32 wayToOrder, string slipMemo1, string slipMemo2, string slipMemo3, string insideMemo1, string insideMemo2, string insideMemo3, Double bfListPrice, Double bfSalesUnitPrice, Double bfUnitCost, Int32 cmpltSalesRowNo, Int32 cmpltGoodsMakerCd, string cmpltMakerName, string cmpltMakerKanaName, string cmpltGoodsName, Double cmpltShipmentCnt, Double cmpltSalesUnPrcFl, Int64 cmpltSalesMoney, Double cmpltSalesUnitCost, Int64 cmpltCost, string cmpltPartySalSlNum, string cmpltNote, Int32 selectedGoodsNoDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Guid dtlRelationGuid, Guid carRelationGuid, Double shipmentCntDefault, Double shipmentCntDefForChk, Double acceptAnOrderCntDefault, Double acceptAnOrderCntDefForChk, Double salesUnPrcTaxIncFlDefault, Double salesUnPrcTaxExcFlDefault, Double salesUnitCostTaxIncDefault, Double salesUnitCostTacExcDefault, string enterpriseName, string updEmployeeName, string bLGoodsName, int editStatus, int rowStatus, int salesMoneyInputDiv, double shipmentCntDisplay, double supplierStockDisplay, double listPriceDisplay, DateTime stockDate, string boCode, int supplierCdForOrder, string supplierSnmForOrder)
        //public SalesDetail(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acceptAnOrderNo, Int32 acptAnOdrStatus, string salesSlipNum, Int32 salesRowNo, Int32 salesRowDerivNo, string sectionCode, Int32 subSectionCode, DateTime salesDate, Int64 commonSeqNo, Int64 salesSlipDtlNum, Int32 acptAnOdrStatusSrc, Int64 salesSlipDtlNumSrc, Int32 supplierFormalSync, Int64 stockSlipDtlNumSync, Int32 salesSlipCdDtl, DateTime deliGdsCmpltDueDate, Int32 goodsKindCode, Int32 goodsSearchDivCd, Int32 goodsMakerCd, string makerName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, Int32 bLGoodsCode, string bLGoodsFullName, Int32 enterpriseGanreCode, string enterpriseGanreName, string warehouseCode, string warehouseName, string warehouseShelfNo, Int32 salesOrderDivCd, Int32 openPriceDiv, string goodsRateRank, Int32 custRateGrpCode, Double listPriceRate, string rateSectPriceUnPrc, string rateDivLPrice, Int32 unPrcCalcCdLPrice, Int32 priceCdLPrice, Double stdUnPrcLPrice, Double fracProcUnitLPrice, Int32 fracProcLPrice, Double listPriceTaxIncFl, Double listPriceTaxExcFl, Int32 listPriceChngCd, Double salesRate, string rateSectSalUnPrc, string rateDivSalUnPrc, Int32 unPrcCalcCdSalUnPrc, Int32 priceCdSalUnPrc, Double stdUnPrcSalUnPrc, Double fracProcUnitSalUnPrc, Int32 fracProcSalUnPrc, Double salesUnPrcTaxIncFl, Double salesUnPrcTaxExcFl, Int32 salesUnPrcChngCd, Double costRate, string rateSectCstUnPrc, string rateDivUnCst, Int32 unPrcCalcCdUnCst, Int32 priceCdUnCst, Double stdUnPrcUnCst, Double fracProcUnitUnCst, Int32 fracProcUnCst, Double salesUnitCost, Int32 salesUnitCostChngDiv, Int32 rateBLGoodsCode, string rateBLGoodsName, Int32 rateGoodsRateGrpCd, string rateGoodsRateGrpNm, Int32 rateBLGroupCode, string rateBLGroupName, Int32 prtBLGoodsCode, string prtBLGoodsName, Int32 salesCode, string salesCdNm, Double workManHour, Double shipmentCnt, Double acceptAnOrderCnt, Double acptAnOdrAdjustCnt, Double acptAnOdrRemainCnt, DateTime remainCntUpdDate, Int64 salesMoneyTaxInc, Int64 salesMoneyTaxExc, Int64 cost, Int32 grsProfitChkDiv, Int32 salesGoodsCd, Int64 salesPriceConsTax, Int32 taxationDivCd, string partySlipNumDtl, string dtlNote, Int32 supplierCd, string supplierSnm, string orderNumber, Int32 wayToOrder, string slipMemo1, string slipMemo2, string slipMemo3, string insideMemo1, string insideMemo2, string insideMemo3, Double bfListPrice, Double bfSalesUnitPrice, Double bfUnitCost, Int32 cmpltSalesRowNo, Int32 cmpltGoodsMakerCd, string cmpltMakerName, string cmpltMakerKanaName, string cmpltGoodsName, Double cmpltShipmentCnt, Double cmpltSalesUnPrcFl, Int64 cmpltSalesMoney, Double cmpltSalesUnitCost, Int64 cmpltCost, string cmpltPartySalSlNum, string cmpltNote, Int32 selectedGoodsNoDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Guid dtlRelationGuid, Guid carRelationGuid, Double shipmentCntDefault, Double shipmentCntDefForChk, Double acceptAnOrderCntDefault, Double acceptAnOrderCntDefForChk, Double salesUnPrcTaxIncFlDefault, Double salesUnPrcTaxExcFlDefault, Double salesUnitCostTaxIncDefault, Double salesUnitCostTacExcDefault, Int32 campaignCode, string campaignName, Int32 goodsDivCd, string answerDelivDate, Int32 recycleDiv, string recycleDivNm, Int32 wayToAcptOdr, Int32 goodsMngNo, Int32 inqRowNumber, Int32 inqRowNumDerivedNo, string enterpriseName, string updEmployeeName, string bLGoodsName, int editStatus, int rowStatus, int salesMoneyInputDiv, double shipmentCntDisplay, double supplierStockDisplay, double listPriceDisplay, DateTime stockDate, string boCode, int supplierCdForOrder, string supplierSnmForOrder)// del 2011/07/18 ���R
        // 2012/01/16 Add >>>
        //public SalesDetail(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acceptAnOrderNo, Int32 acptAnOdrStatus, string salesSlipNum, Int32 salesRowNo, Int32 salesRowDerivNo, string sectionCode, Int32 subSectionCode, DateTime salesDate, Int64 commonSeqNo, Int64 salesSlipDtlNum, Int32 acptAnOdrStatusSrc, Int64 salesSlipDtlNumSrc, Int32 supplierFormalSync, Int64 stockSlipDtlNumSync, Int32 salesSlipCdDtl, DateTime deliGdsCmpltDueDate, Int32 goodsKindCode, Int32 goodsSearchDivCd, Int32 goodsMakerCd, string makerName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, Int32 bLGoodsCode, string bLGoodsFullName, Int32 enterpriseGanreCode, string enterpriseGanreName, string warehouseCode, string warehouseName, string warehouseShelfNo, Int32 salesOrderDivCd, Int32 openPriceDiv, string goodsRateRank, Int32 custRateGrpCode, Double listPriceRate, string rateSectPriceUnPrc, string rateDivLPrice, Int32 unPrcCalcCdLPrice, Int32 priceCdLPrice, Double stdUnPrcLPrice, Double fracProcUnitLPrice, Int32 fracProcLPrice, Double listPriceTaxIncFl, Double listPriceTaxExcFl, Int32 listPriceChngCd, Double salesRate, string rateSectSalUnPrc, string rateDivSalUnPrc, Int32 unPrcCalcCdSalUnPrc, Int32 priceCdSalUnPrc, Double stdUnPrcSalUnPrc, Double fracProcUnitSalUnPrc, Int32 fracProcSalUnPrc, Double salesUnPrcTaxIncFl, Double salesUnPrcTaxExcFl, Int32 salesUnPrcChngCd, Double costRate, string rateSectCstUnPrc, string rateDivUnCst, Int32 unPrcCalcCdUnCst, Int32 priceCdUnCst, Double stdUnPrcUnCst, Double fracProcUnitUnCst, Int32 fracProcUnCst, Double salesUnitCost, Int32 salesUnitCostChngDiv, Int32 rateBLGoodsCode, string rateBLGoodsName, Int32 rateGoodsRateGrpCd, string rateGoodsRateGrpNm, Int32 rateBLGroupCode, string rateBLGroupName, Int32 prtBLGoodsCode, string prtBLGoodsName, Int32 salesCode, string salesCdNm, Double workManHour, Double shipmentCnt, Double acceptAnOrderCnt, Double acptAnOdrAdjustCnt, Double acptAnOdrRemainCnt, DateTime remainCntUpdDate, Int64 salesMoneyTaxInc, Int64 salesMoneyTaxExc, Int64 cost, Int32 grsProfitChkDiv, Int32 salesGoodsCd, Int64 salesPriceConsTax, Int32 taxationDivCd, string partySlipNumDtl, string dtlNote, Int32 supplierCd, string supplierSnm, string orderNumber, Int32 wayToOrder, string slipMemo1, string slipMemo2, string slipMemo3, string insideMemo1, string insideMemo2, string insideMemo3, Double bfListPrice, Double bfSalesUnitPrice, Double bfUnitCost, Int32 cmpltSalesRowNo, Int32 cmpltGoodsMakerCd, string cmpltMakerName, string cmpltMakerKanaName, string cmpltGoodsName, Double cmpltShipmentCnt, Double cmpltSalesUnPrcFl, Int64 cmpltSalesMoney, Double cmpltSalesUnitCost, Int64 cmpltCost, string cmpltPartySalSlNum, string cmpltNote, Int32 selectedGoodsNoDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Guid dtlRelationGuid, Guid carRelationGuid, Double shipmentCntDefault, Double shipmentCntDefForChk, Double acceptAnOrderCntDefault, Double acceptAnOrderCntDefForChk, Double salesUnPrcTaxIncFlDefault, Double salesUnPrcTaxExcFlDefault, Double salesUnitCostTaxIncDefault, Double salesUnitCostTacExcDefault, Int32 campaignCode, string campaignName, Int32 goodsDivCd, string answerDelivDate, Int32 recycleDiv, string recycleDivNm, Int32 wayToAcptOdr, Int32 goodsMngNo, Int32 inqRowNumber, Int32 inqRowNumDerivedNo, string enterpriseName, string updEmployeeName, string bLGoodsName, int editStatus, int rowStatus, int salesMoneyInputDiv, double shipmentCntDisplay, double supplierStockDisplay, double listPriceDisplay, DateTime stockDate, string boCode, int supplierCdForOrder, string supplierSnmForOrder, int autoAnswerDivSCM, Int16 acceptOrOrderKind, Int64 inquiryNumber)// add 2011/07/18 ���R
        //>>>2012/05/02
        //public SalesDetail(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acceptAnOrderNo, Int32 acptAnOdrStatus, string salesSlipNum, Int32 salesRowNo, Int32 salesRowDerivNo, string sectionCode, Int32 subSectionCode, DateTime salesDate, Int64 commonSeqNo, Int64 salesSlipDtlNum, Int32 acptAnOdrStatusSrc, Int64 salesSlipDtlNumSrc, Int32 supplierFormalSync, Int64 stockSlipDtlNumSync, Int32 salesSlipCdDtl, DateTime deliGdsCmpltDueDate, Int32 goodsKindCode, Int32 goodsSearchDivCd, Int32 goodsMakerCd, string makerName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, Int32 bLGoodsCode, string bLGoodsFullName, Int32 enterpriseGanreCode, string enterpriseGanreName, string warehouseCode, string warehouseName, string warehouseShelfNo, Int32 salesOrderDivCd, Int32 openPriceDiv, string goodsRateRank, Int32 custRateGrpCode, Double listPriceRate, string rateSectPriceUnPrc, string rateDivLPrice, Int32 unPrcCalcCdLPrice, Int32 priceCdLPrice, Double stdUnPrcLPrice, Double fracProcUnitLPrice, Int32 fracProcLPrice, Double listPriceTaxIncFl, Double listPriceTaxExcFl, Int32 listPriceChngCd, Double salesRate, string rateSectSalUnPrc, string rateDivSalUnPrc, Int32 unPrcCalcCdSalUnPrc, Int32 priceCdSalUnPrc, Double stdUnPrcSalUnPrc, Double fracProcUnitSalUnPrc, Int32 fracProcSalUnPrc, Double salesUnPrcTaxIncFl, Double salesUnPrcTaxExcFl, Int32 salesUnPrcChngCd, Double costRate, string rateSectCstUnPrc, string rateDivUnCst, Int32 unPrcCalcCdUnCst, Int32 priceCdUnCst, Double stdUnPrcUnCst, Double fracProcUnitUnCst, Int32 fracProcUnCst, Double salesUnitCost, Int32 salesUnitCostChngDiv, Int32 rateBLGoodsCode, string rateBLGoodsName, Int32 rateGoodsRateGrpCd, string rateGoodsRateGrpNm, Int32 rateBLGroupCode, string rateBLGroupName, Int32 prtBLGoodsCode, string prtBLGoodsName, Int32 salesCode, string salesCdNm, Double workManHour, Double shipmentCnt, Double acceptAnOrderCnt, Double acptAnOdrAdjustCnt, Double acptAnOdrRemainCnt, DateTime remainCntUpdDate, Int64 salesMoneyTaxInc, Int64 salesMoneyTaxExc, Int64 cost, Int32 grsProfitChkDiv, Int32 salesGoodsCd, Int64 salesPriceConsTax, Int32 taxationDivCd, string partySlipNumDtl, string dtlNote, Int32 supplierCd, string supplierSnm, string orderNumber, Int32 wayToOrder, string slipMemo1, string slipMemo2, string slipMemo3, string insideMemo1, string insideMemo2, string insideMemo3, Double bfListPrice, Double bfSalesUnitPrice, Double bfUnitCost, Int32 cmpltSalesRowNo, Int32 cmpltGoodsMakerCd, string cmpltMakerName, string cmpltMakerKanaName, string cmpltGoodsName, Double cmpltShipmentCnt, Double cmpltSalesUnPrcFl, Int64 cmpltSalesMoney, Double cmpltSalesUnitCost, Int64 cmpltCost, string cmpltPartySalSlNum, string cmpltNote, Int32 selectedGoodsNoDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Guid dtlRelationGuid, Guid carRelationGuid, Double shipmentCntDefault, Double shipmentCntDefForChk, Double acceptAnOrderCntDefault, Double acceptAnOrderCntDefForChk, Double salesUnPrcTaxIncFlDefault, Double salesUnPrcTaxExcFlDefault, Double salesUnitCostTaxIncDefault, Double salesUnitCostTacExcDefault, Int32 campaignCode, string campaignName, Int32 goodsDivCd, string answerDelivDate, Int32 recycleDiv, string recycleDivNm, Int32 wayToAcptOdr, Int32 goodsMngNo, Int32 inqRowNumber, Int32 inqRowNumDerivedNo, string enterpriseName, string updEmployeeName, string bLGoodsName, int editStatus, int rowStatus, int salesMoneyInputDiv, double shipmentCntDisplay, double supplierStockDisplay, double listPriceDisplay, DateTime stockDate, string boCode, int supplierCdForOrder, string supplierSnmForOrder, int autoAnswerDivSCM, Int16 acceptOrOrderKind, Int64 inquiryNumber, string goodsSpecialNote)
        //public SalesDetail(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acceptAnOrderNo, Int32 acptAnOdrStatus, string salesSlipNum, Int32 salesRowNo, Int32 salesRowDerivNo, string sectionCode, Int32 subSectionCode, DateTime salesDate, Int64 commonSeqNo, Int64 salesSlipDtlNum, Int32 acptAnOdrStatusSrc, Int64 salesSlipDtlNumSrc, Int32 supplierFormalSync, Int64 stockSlipDtlNumSync, Int32 salesSlipCdDtl, DateTime deliGdsCmpltDueDate, Int32 goodsKindCode, Int32 goodsSearchDivCd, Int32 goodsMakerCd, string makerName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, Int32 bLGoodsCode, string bLGoodsFullName, Int32 enterpriseGanreCode, string enterpriseGanreName, string warehouseCode, string warehouseName, string warehouseShelfNo, Int32 salesOrderDivCd, Int32 openPriceDiv, string goodsRateRank, Int32 custRateGrpCode, Double listPriceRate, string rateSectPriceUnPrc, string rateDivLPrice, Int32 unPrcCalcCdLPrice, Int32 priceCdLPrice, Double stdUnPrcLPrice, Double fracProcUnitLPrice, Int32 fracProcLPrice, Double listPriceTaxIncFl, Double listPriceTaxExcFl, Int32 listPriceChngCd, Double salesRate, string rateSectSalUnPrc, string rateDivSalUnPrc, Int32 unPrcCalcCdSalUnPrc, Int32 priceCdSalUnPrc, Double stdUnPrcSalUnPrc, Double fracProcUnitSalUnPrc, Int32 fracProcSalUnPrc, Double salesUnPrcTaxIncFl, Double salesUnPrcTaxExcFl, Int32 salesUnPrcChngCd, Double costRate, string rateSectCstUnPrc, string rateDivUnCst, Int32 unPrcCalcCdUnCst, Int32 priceCdUnCst, Double stdUnPrcUnCst, Double fracProcUnitUnCst, Int32 fracProcUnCst, Double salesUnitCost, Int32 salesUnitCostChngDiv, Int32 rateBLGoodsCode, string rateBLGoodsName, Int32 rateGoodsRateGrpCd, string rateGoodsRateGrpNm, Int32 rateBLGroupCode, string rateBLGroupName, Int32 prtBLGoodsCode, string prtBLGoodsName, Int32 salesCode, string salesCdNm, Double workManHour, Double shipmentCnt, Double acceptAnOrderCnt, Double acptAnOdrAdjustCnt, Double acptAnOdrRemainCnt, DateTime remainCntUpdDate, Int64 salesMoneyTaxInc, Int64 salesMoneyTaxExc, Int64 cost, Int32 grsProfitChkDiv, Int32 salesGoodsCd, Int64 salesPriceConsTax, Int32 taxationDivCd, string partySlipNumDtl, string dtlNote, Int32 supplierCd, string supplierSnm, string orderNumber, Int32 wayToOrder, string slipMemo1, string slipMemo2, string slipMemo3, string insideMemo1, string insideMemo2, string insideMemo3, Double bfListPrice, Double bfSalesUnitPrice, Double bfUnitCost, Int32 cmpltSalesRowNo, Int32 cmpltGoodsMakerCd, string cmpltMakerName, string cmpltMakerKanaName, string cmpltGoodsName, Double cmpltShipmentCnt, Double cmpltSalesUnPrcFl, Int64 cmpltSalesMoney, Double cmpltSalesUnitCost, Int64 cmpltCost, string cmpltPartySalSlNum, string cmpltNote, Int32 selectedGoodsNoDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Guid dtlRelationGuid, Guid carRelationGuid, Double shipmentCntDefault, Double shipmentCntDefForChk, Double acceptAnOrderCntDefault, Double acceptAnOrderCntDefForChk, Double salesUnPrcTaxIncFlDefault, Double salesUnPrcTaxExcFlDefault, Double salesUnitCostTaxIncDefault, Double salesUnitCostTacExcDefault, Int32 campaignCode, string campaignName, Int32 goodsDivCd, string answerDelivDate, Int32 recycleDiv, string recycleDivNm, Int32 wayToAcptOdr, Int32 goodsMngNo, Int32 inqRowNumber, Int32 inqRowNumDerivedNo, string enterpriseName, string updEmployeeName, string bLGoodsName, int editStatus, int rowStatus, int salesMoneyInputDiv, double shipmentCntDisplay, double supplierStockDisplay, double listPriceDisplay, DateTime stockDate, string boCode, int supplierCdForOrder, string supplierSnmForOrder, int autoAnswerDivSCM, Int16 acceptOrOrderKind, Int64 inquiryNumber, string goodsSpecialNote, Int32 rentSyncSupplier, DateTime rentSyncStockDate, string rentSyncSupSlipNo)// DEL 2013/01/24 ���N�n�� REDMINE#34605
        public SalesDetail(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acceptAnOrderNo, Int32 acptAnOdrStatus, string salesSlipNum, Int32 salesRowNo, Int32 salesRowDerivNo, string sectionCode, Int32 subSectionCode, DateTime salesDate, Int64 commonSeqNo, Int64 salesSlipDtlNum, Int32 acptAnOdrStatusSrc, Int64 salesSlipDtlNumSrc, Int32 supplierFormalSync, Int64 stockSlipDtlNumSync, Int32 salesSlipCdDtl, DateTime deliGdsCmpltDueDate, Int32 goodsKindCode, Int32 goodsSearchDivCd, Int32 goodsMakerCd, string makerName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, Int32 bLGoodsCode, string bLGoodsFullName, Int32 enterpriseGanreCode, string enterpriseGanreName, string warehouseCode, string warehouseName, string warehouseShelfNo, Int32 salesOrderDivCd, Int32 openPriceDiv, string goodsRateRank, Int32 custRateGrpCode, Double listPriceRate, string rateSectPriceUnPrc, string rateDivLPrice, Int32 unPrcCalcCdLPrice, Int32 priceCdLPrice, Double stdUnPrcLPrice, Double fracProcUnitLPrice, Int32 fracProcLPrice, Double listPriceTaxIncFl, Double listPriceTaxExcFl, Int32 listPriceChngCd, Double salesRate, string rateSectSalUnPrc, string rateDivSalUnPrc, Int32 unPrcCalcCdSalUnPrc, Int32 priceCdSalUnPrc, Double stdUnPrcSalUnPrc, Double fracProcUnitSalUnPrc, Int32 fracProcSalUnPrc, Double salesUnPrcTaxIncFl, Double salesUnPrcTaxExcFl, Int32 salesUnPrcChngCd, Double costRate, string rateSectCstUnPrc, string rateDivUnCst, Int32 unPrcCalcCdUnCst, Int32 priceCdUnCst, Double stdUnPrcUnCst, Double fracProcUnitUnCst, Int32 fracProcUnCst, Double salesUnitCost, Int32 salesUnitCostChngDiv, Int32 rateBLGoodsCode, string rateBLGoodsName, Int32 rateGoodsRateGrpCd, string rateGoodsRateGrpNm, Int32 rateBLGroupCode, string rateBLGroupName, Int32 prtBLGoodsCode, string prtBLGoodsName, Int32 salesCode, string salesCdNm, Double workManHour, Double shipmentCnt, Double acceptAnOrderCnt, Double acptAnOdrAdjustCnt, Double acptAnOdrRemainCnt, DateTime remainCntUpdDate, Int64 salesMoneyTaxInc, Int64 salesMoneyTaxExc, Int64 cost, Int32 grsProfitChkDiv, Int32 salesGoodsCd, Int64 salesPriceConsTax, Int32 taxationDivCd, string partySlipNumDtl, string dtlNote, Int32 supplierCd, string supplierSnm, string orderNumber, Int32 wayToOrder, string slipMemo1, string slipMemo2, string slipMemo3, string insideMemo1, string insideMemo2, string insideMemo3, Double bfListPrice, Double bfSalesUnitPrice, Double bfUnitCost, Int32 cmpltSalesRowNo, Int32 cmpltGoodsMakerCd, string cmpltMakerName, string cmpltMakerKanaName, string cmpltGoodsName, Double cmpltShipmentCnt, Double cmpltSalesUnPrcFl, Int64 cmpltSalesMoney, Double cmpltSalesUnitCost, Int64 cmpltCost, string cmpltPartySalSlNum, string cmpltNote, Int32 selectedGoodsNoDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Guid dtlRelationGuid, Guid carRelationGuid, Double shipmentCntDefault, Double shipmentCntDefForChk, Double acceptAnOrderCntDefault, Double acceptAnOrderCntDefForChk, Double salesUnPrcTaxIncFlDefault, Double salesUnPrcTaxExcFlDefault, Double salesUnitCostTaxIncDefault, Double salesUnitCostTacExcDefault, Int32 campaignCode, string campaignName, Int32 goodsDivCd, string answerDelivDate, Int32 recycleDiv, string recycleDivNm, Int32 wayToAcptOdr, Int32 goodsMngNo, Int32 inqRowNumber, Int32 inqRowNumDerivedNo, string enterpriseName, string updEmployeeName, string bLGoodsName, int editStatus, int rowStatus, int salesMoneyInputDiv, double shipmentCntDisplay, double supplierStockDisplay, double listPriceDisplay, DateTime stockDate, string boCode, int supplierCdForOrder, string supplierSnmForOrder, int autoAnswerDivSCM, Int16 acceptOrOrderKind, Int64 inquiryNumber, string goodsSpecialNote, Int32 rentSyncSupplier, DateTime rentSyncStockDate, string rentSyncSupSlipNo, Int32 priceSelectDiv)// ADD 2013/01/24 ���N�n�� REDMINE#34605
        //<<<2012/05/02
        // 2012/01/16 Add <<<
        //<<<2010/02/26
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._acceptAnOrderNo = acceptAnOrderNo;
            this._acptAnOdrStatus = acptAnOdrStatus;
            this._salesSlipNum = salesSlipNum;
            this._salesRowNo = salesRowNo;
            this._salesRowDerivNo = salesRowDerivNo;
            this._sectionCode = sectionCode;
            this._subSectionCode = subSectionCode;
            this.SalesDate = salesDate;
            this._commonSeqNo = commonSeqNo;
            this._salesSlipDtlNum = salesSlipDtlNum;
            this._acptAnOdrStatusSrc = acptAnOdrStatusSrc;
            this._salesSlipDtlNumSrc = salesSlipDtlNumSrc;
            this._supplierFormalSync = supplierFormalSync;
            this._stockSlipDtlNumSync = stockSlipDtlNumSync;
            this._salesSlipCdDtl = salesSlipCdDtl;
            this.DeliGdsCmpltDueDate = deliGdsCmpltDueDate;
            this._goodsKindCode = goodsKindCode;
            this._goodsSearchDivCd = goodsSearchDivCd;
            this._goodsMakerCd = goodsMakerCd;
            this._makerName = makerName;
            this._makerKanaName = makerKanaName;
            this._goodsNo = goodsNo;
            this._goodsName = goodsName;
            this._goodsNameKana = goodsNameKana;
            this._goodsLGroup = goodsLGroup;
            this._goodsLGroupName = goodsLGroupName;
            this._goodsMGroup = goodsMGroup;
            this._goodsMGroupName = goodsMGroupName;
            this._bLGroupCode = bLGroupCode;
            this._bLGroupName = bLGroupName;
            this._bLGoodsCode = bLGoodsCode;
            this._bLGoodsFullName = bLGoodsFullName;
            this._enterpriseGanreCode = enterpriseGanreCode;
            this._enterpriseGanreName = enterpriseGanreName;
            this._warehouseCode = warehouseCode;
            this._warehouseName = warehouseName;
            this._warehouseShelfNo = warehouseShelfNo;
            this._salesOrderDivCd = salesOrderDivCd;
            this._openPriceDiv = openPriceDiv;
            this._goodsRateRank = goodsRateRank;
            this._custRateGrpCode = custRateGrpCode;
            this._listPriceRate = listPriceRate;
            this._rateSectPriceUnPrc = rateSectPriceUnPrc;
            this._rateDivLPrice = rateDivLPrice;
            this._unPrcCalcCdLPrice = unPrcCalcCdLPrice;
            this._priceCdLPrice = priceCdLPrice;
            this._stdUnPrcLPrice = stdUnPrcLPrice;
            this._fracProcUnitLPrice = fracProcUnitLPrice;
            this._fracProcLPrice = fracProcLPrice;
            this._listPriceTaxIncFl = listPriceTaxIncFl;
            this._listPriceTaxExcFl = listPriceTaxExcFl;
            this._listPriceChngCd = listPriceChngCd;
            this._salesRate = salesRate;
            this._rateSectSalUnPrc = rateSectSalUnPrc;
            this._rateDivSalUnPrc = rateDivSalUnPrc;
            this._unPrcCalcCdSalUnPrc = unPrcCalcCdSalUnPrc;
            this._priceCdSalUnPrc = priceCdSalUnPrc;
            this._stdUnPrcSalUnPrc = stdUnPrcSalUnPrc;
            this._fracProcUnitSalUnPrc = fracProcUnitSalUnPrc;
            this._fracProcSalUnPrc = fracProcSalUnPrc;
            this._salesUnPrcTaxIncFl = salesUnPrcTaxIncFl;
            this._salesUnPrcTaxExcFl = salesUnPrcTaxExcFl;
            this._salesUnPrcChngCd = salesUnPrcChngCd;
            this._costRate = costRate;
            this._rateSectCstUnPrc = rateSectCstUnPrc;
            this._rateDivUnCst = rateDivUnCst;
            this._unPrcCalcCdUnCst = unPrcCalcCdUnCst;
            this._priceCdUnCst = priceCdUnCst;
            this._stdUnPrcUnCst = stdUnPrcUnCst;
            this._fracProcUnitUnCst = fracProcUnitUnCst;
            this._fracProcUnCst = fracProcUnCst;
            this._salesUnitCost = salesUnitCost;
            this._salesUnitCostChngDiv = salesUnitCostChngDiv;
            this._rateBLGoodsCode = rateBLGoodsCode;
            this._rateBLGoodsName = rateBLGoodsName;
            this._rateGoodsRateGrpCd = rateGoodsRateGrpCd;
            this._rateGoodsRateGrpNm = rateGoodsRateGrpNm;
            this._rateBLGroupCode = rateBLGroupCode;
            this._rateBLGroupName = rateBLGroupName;
            this._prtBLGoodsCode = prtBLGoodsCode;
            this._prtBLGoodsName = prtBLGoodsName;
            this._salesCode = salesCode;
            this._salesCdNm = salesCdNm;
            this._workManHour = workManHour;
            this._shipmentCnt = shipmentCnt;
            this._acceptAnOrderCnt = acceptAnOrderCnt;
            this._acptAnOdrAdjustCnt = acptAnOdrAdjustCnt;
            this._acptAnOdrRemainCnt = acptAnOdrRemainCnt;
            this.RemainCntUpdDate = remainCntUpdDate;
            this._salesMoneyTaxInc = salesMoneyTaxInc;
            this._salesMoneyTaxExc = salesMoneyTaxExc;
            this._cost = cost;
            this._grsProfitChkDiv = grsProfitChkDiv;
            this._salesGoodsCd = salesGoodsCd;
            this._salesPriceConsTax = salesPriceConsTax;
            this._taxationDivCd = taxationDivCd;
            this._partySlipNumDtl = partySlipNumDtl;
            this._dtlNote = dtlNote;
            this._supplierCd = supplierCd;
            this._supplierSnm = supplierSnm;
            this._orderNumber = orderNumber;
            this._wayToOrder = wayToOrder;
            this._slipMemo1 = slipMemo1;
            this._slipMemo2 = slipMemo2;
            this._slipMemo3 = slipMemo3;
            this._insideMemo1 = insideMemo1;
            this._insideMemo2 = insideMemo2;
            this._insideMemo3 = insideMemo3;
            this._bfListPrice = bfListPrice;
            this._bfSalesUnitPrice = bfSalesUnitPrice;
            this._bfUnitCost = bfUnitCost;
            this._cmpltSalesRowNo = cmpltSalesRowNo;
            this._cmpltGoodsMakerCd = cmpltGoodsMakerCd;
            this._cmpltMakerName = cmpltMakerName;
            this._cmpltMakerKanaName = cmpltMakerKanaName;
            this._cmpltGoodsName = cmpltGoodsName;
            this._cmpltShipmentCnt = cmpltShipmentCnt;
            this._cmpltSalesUnPrcFl = cmpltSalesUnPrcFl;
            this._cmpltSalesMoney = cmpltSalesMoney;
            this._cmpltSalesUnitCost = cmpltSalesUnitCost;
            this._cmpltCost = cmpltCost;
            this._cmpltPartySalSlNum = cmpltPartySalSlNum;
            this._cmpltNote = cmpltNote;
            // --- ADD 2009/10/19 ---------->>>>>
            this._selectedGoodsNoDiv = selectedGoodsNoDiv;
            // --- ADD 2009/10/19 ----------<<<<<
            this._prtGoodsNo = prtGoodsNo;
            this._prtMakerCode = prtMakerCode;
            this._prtMakerName = prtMakerName;
            this._dtlRelationGuid = dtlRelationGuid;
            this._carRelationGuid = carRelationGuid;
            this._shipmentCntDefault = shipmentCntDefault;
            this._shipmentCntDefForChk = shipmentCntDefForChk;
            this._acceptAnOrderCntDefault = acceptAnOrderCntDefault;
            this._acceptAnOrderCntDefForChk = acceptAnOrderCntDefForChk;
            this._salesUnPrcTaxIncFlDefault = salesUnPrcTaxIncFlDefault;
            this._salesUnPrcTaxExcFlDefault = salesUnPrcTaxExcFlDefault;
            this._salesUnitCostTaxIncDefault = salesUnitCostTaxIncDefault;
            this._salesUnitCostTacExcDefault = salesUnitCostTacExcDefault;
            //<<<2010/02/26
            this._campaignCode = campaignCode;
            this._campaignName = campaignName;
            this._goodsDivCd = goodsDivCd;
            this._answerDelivDate = answerDelivDate;
            this._recycleDiv = recycleDiv;
            this._recycleDivNm = recycleDivNm;
            this._wayToAcptOdr = wayToAcptOdr;
            this._goodsMngNo = goodsMngNo;
            this._inqRowNumber = inqRowNumber;
            this._inqRowNumDerivedNo = inqRowNumDerivedNo;
            //<<<2010/02/26
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._bLGoodsName = bLGoodsName;
            this._editStatus = editStatus;//ADD 2010/04/06
            this._rowStatus = rowStatus;//ADD 2010/04/06
            this._salesMoneyInputDiv = salesMoneyInputDiv;//ADD 2010/04/06
            this._shipmentCntDisplay = shipmentCntDisplay;//ADD 2010/04/06
            this._supplierStockDisplay = supplierStockDisplay;//ADD 2010/04/06
            this._listPriceDisplay = listPriceDisplay;//ADD 2010/04/06
            this._stockDate = stockDate;//ADD 2010/04/06

            this._boCode = boCode;//ADD 2010/04/06
            this._supplierCdForOrder = supplierCdForOrder;//ADD 2010/04/06
            this._supplierSnmForOrder = supplierSnmForOrder;//ADD 2010/04/06
            // --- ADD 2011/08/08 ---------->>>>>
            this._autoAnswerDivSCM = autoAnswerDivSCM;
            this._acceptOrOrderKind = acceptOrOrderKind;
            this._inquiryNumber = inquiryNumber;
            // --- ADD 2011/08/08 ----------<<<<<
            // 2012/01/16 Add >>>
            this._goodsSpecialNote = goodsSpecialNote;
            // 2012/01/16 Add <<<
            //>>>2012/05/02
            this._rentSyncSupplier = rentSyncSupplier;
            this._rentSyncStockDate = rentSyncStockDate;
            this._rentSyncSupSlipNo = rentSyncSupSlipNo;
            //<<<2012/05/02
            this._priceSelectDiv = priceSelectDiv;// ADD 2013/01/24 ���N�n�� REDMINE#34605
        }

        /// <summary>
        /// ���㖾�׃f�[�^��������
        /// </summary>
        /// <returns>SalesDetail�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SalesDetail�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesDetail Clone()
        {
            //>>>2010/02/26
            //return new SalesDetail(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acceptAnOrderNo, this._acptAnOdrStatus, this._salesSlipNum, this._salesRowNo, this._salesRowDerivNo, this._sectionCode, this._subSectionCode, this._salesDate, this._commonSeqNo, this._salesSlipDtlNum, this._acptAnOdrStatusSrc, this._salesSlipDtlNumSrc, this._supplierFormalSync, this._stockSlipDtlNumSync, this._salesSlipCdDtl, this._deliGdsCmpltDueDate, this._goodsKindCode, this._goodsSearchDivCd, this._goodsMakerCd, this._makerName, this._makerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._bLGoodsCode, this._bLGoodsFullName, this._enterpriseGanreCode, this._enterpriseGanreName, this._warehouseCode, this._warehouseName, this._warehouseShelfNo, this._salesOrderDivCd, this._openPriceDiv, this._goodsRateRank, this._custRateGrpCode, this._listPriceRate, this._rateSectPriceUnPrc, this._rateDivLPrice, this._unPrcCalcCdLPrice, this._priceCdLPrice, this._stdUnPrcLPrice, this._fracProcUnitLPrice, this._fracProcLPrice, this._listPriceTaxIncFl, this._listPriceTaxExcFl, this._listPriceChngCd, this._salesRate, this._rateSectSalUnPrc, this._rateDivSalUnPrc, this._unPrcCalcCdSalUnPrc, this._priceCdSalUnPrc, this._stdUnPrcSalUnPrc, this._fracProcUnitSalUnPrc, this._fracProcSalUnPrc, this._salesUnPrcTaxIncFl, this._salesUnPrcTaxExcFl, this._salesUnPrcChngCd, this._costRate, this._rateSectCstUnPrc, this._rateDivUnCst, this._unPrcCalcCdUnCst, this._priceCdUnCst, this._stdUnPrcUnCst, this._fracProcUnitUnCst, this._fracProcUnCst, this._salesUnitCost, this._salesUnitCostChngDiv, this._rateBLGoodsCode, this._rateBLGoodsName, this._rateGoodsRateGrpCd, this._rateGoodsRateGrpNm, this._rateBLGroupCode, this._rateBLGroupName, this._prtBLGoodsCode, this._prtBLGoodsName, this._salesCode, this._salesCdNm, this._workManHour, this._shipmentCnt, this._acceptAnOrderCnt, this._acptAnOdrAdjustCnt, this._acptAnOdrRemainCnt, this._remainCntUpdDate, this._salesMoneyTaxInc, this._salesMoneyTaxExc, this._cost, this._grsProfitChkDiv, this._salesGoodsCd, this._salesPriceConsTax, this._taxationDivCd, this._partySlipNumDtl, this._dtlNote, this._supplierCd, this._supplierSnm, this._orderNumber, this._wayToOrder, this._slipMemo1, this._slipMemo2, this._slipMemo3, this._insideMemo1, this._insideMemo2, this._insideMemo3, this._bfListPrice, this._bfSalesUnitPrice, this._bfUnitCost, this._cmpltSalesRowNo, this._cmpltGoodsMakerCd, this._cmpltMakerName, this._cmpltMakerKanaName, this._cmpltGoodsName, this._cmpltShipmentCnt, this._cmpltSalesUnPrcFl, this._cmpltSalesMoney, this._cmpltSalesUnitCost, this._cmpltCost, this._cmpltPartySalSlNum, this._cmpltNote, this._selectedGoodsNoDiv, this._prtGoodsNo, this._prtMakerCode, this._prtMakerName, this._dtlRelationGuid, this._carRelationGuid, this._shipmentCntDefault, this._shipmentCntDefForChk, this._acceptAnOrderCntDefault, this._acceptAnOrderCntDefForChk, this._salesUnPrcTaxIncFlDefault, this._salesUnPrcTaxExcFlDefault, this._salesUnitCostTaxIncDefault, this._salesUnitCostTacExcDefault, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._editStatus, this._rowStatus, this._salesMoneyInputDiv, this._shipmentCntDisplay, this._supplierStockDisplay, this._listPriceDisplay, this._stockDate, this._boCode, this._supplierCdForOrder, this._supplierSnmForOrder);
            //return new SalesDetail(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acceptAnOrderNo, this._acptAnOdrStatus, this._salesSlipNum, this._salesRowNo, this._salesRowDerivNo, this._sectionCode, this._subSectionCode, this._salesDate, this._commonSeqNo, this._salesSlipDtlNum, this._acptAnOdrStatusSrc, this._salesSlipDtlNumSrc, this._supplierFormalSync, this._stockSlipDtlNumSync, this._salesSlipCdDtl, this._deliGdsCmpltDueDate, this._goodsKindCode, this._goodsSearchDivCd, this._goodsMakerCd, this._makerName, this._makerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._bLGoodsCode, this._bLGoodsFullName, this._enterpriseGanreCode, this._enterpriseGanreName, this._warehouseCode, this._warehouseName, this._warehouseShelfNo, this._salesOrderDivCd, this._openPriceDiv, this._goodsRateRank, this._custRateGrpCode, this._listPriceRate, this._rateSectPriceUnPrc, this._rateDivLPrice, this._unPrcCalcCdLPrice, this._priceCdLPrice, this._stdUnPrcLPrice, this._fracProcUnitLPrice, this._fracProcLPrice, this._listPriceTaxIncFl, this._listPriceTaxExcFl, this._listPriceChngCd, this._salesRate, this._rateSectSalUnPrc, this._rateDivSalUnPrc, this._unPrcCalcCdSalUnPrc, this._priceCdSalUnPrc, this._stdUnPrcSalUnPrc, this._fracProcUnitSalUnPrc, this._fracProcSalUnPrc, this._salesUnPrcTaxIncFl, this._salesUnPrcTaxExcFl, this._salesUnPrcChngCd, this._costRate, this._rateSectCstUnPrc, this._rateDivUnCst, this._unPrcCalcCdUnCst, this._priceCdUnCst, this._stdUnPrcUnCst, this._fracProcUnitUnCst, this._fracProcUnCst, this._salesUnitCost, this._salesUnitCostChngDiv, this._rateBLGoodsCode, this._rateBLGoodsName, this._rateGoodsRateGrpCd, this._rateGoodsRateGrpNm, this._rateBLGroupCode, this._rateBLGroupName, this._prtBLGoodsCode, this._prtBLGoodsName, this._salesCode, this._salesCdNm, this._workManHour, this._shipmentCnt, this._acceptAnOrderCnt, this._acptAnOdrAdjustCnt, this._acptAnOdrRemainCnt, this._remainCntUpdDate, this._salesMoneyTaxInc, this._salesMoneyTaxExc, this._cost, this._grsProfitChkDiv, this._salesGoodsCd, this._salesPriceConsTax, this._taxationDivCd, this._partySlipNumDtl, this._dtlNote, this._supplierCd, this._supplierSnm, this._orderNumber, this._wayToOrder, this._slipMemo1, this._slipMemo2, this._slipMemo3, this._insideMemo1, this._insideMemo2, this._insideMemo3, this._bfListPrice, this._bfSalesUnitPrice, this._bfUnitCost, this._cmpltSalesRowNo, this._cmpltGoodsMakerCd, this._cmpltMakerName, this._cmpltMakerKanaName, this._cmpltGoodsName, this._cmpltShipmentCnt, this._cmpltSalesUnPrcFl, this._cmpltSalesMoney, this._cmpltSalesUnitCost, this._cmpltCost, this._cmpltPartySalSlNum, this._cmpltNote, this._selectedGoodsNoDiv, this._prtGoodsNo, this._prtMakerCode, this._prtMakerName, this._dtlRelationGuid, this._carRelationGuid, this._shipmentCntDefault, this._shipmentCntDefForChk, this._acceptAnOrderCntDefault, this._acceptAnOrderCntDefForChk, this._salesUnPrcTaxIncFlDefault, this._salesUnPrcTaxExcFlDefault, this._salesUnitCostTaxIncDefault, this._salesUnitCostTacExcDefault, this._campaignCode, this._campaignName, this._goodsDivCd, this._answerDelivDate, this._recycleDiv, this._recycleDivNm, this._wayToAcptOdr, this._goodsMngNo, this._inqRowNumber, this._inqRowNumDerivedNo, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._editStatus, this._rowStatus, this._salesMoneyInputDiv, this._shipmentCntDisplay, this._supplierStockDisplay, this._listPriceDisplay, this._stockDate, this._boCode, this._supplierCdForOrder, this._supplierSnmForOrder);// del 2011/07/18 ���R
            //<<<2010/02/26
            // 2012/01/16 Add >>>
            //return new SalesDetail(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acceptAnOrderNo, this._acptAnOdrStatus, this._salesSlipNum, this._salesRowNo, this._salesRowDerivNo, this._sectionCode, this._subSectionCode, this._salesDate, this._commonSeqNo, this._salesSlipDtlNum, this._acptAnOdrStatusSrc, this._salesSlipDtlNumSrc, this._supplierFormalSync, this._stockSlipDtlNumSync, this._salesSlipCdDtl, this._deliGdsCmpltDueDate, this._goodsKindCode, this._goodsSearchDivCd, this._goodsMakerCd, this._makerName, this._makerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._bLGoodsCode, this._bLGoodsFullName, this._enterpriseGanreCode, this._enterpriseGanreName, this._warehouseCode, this._warehouseName, this._warehouseShelfNo, this._salesOrderDivCd, this._openPriceDiv, this._goodsRateRank, this._custRateGrpCode, this._listPriceRate, this._rateSectPriceUnPrc, this._rateDivLPrice, this._unPrcCalcCdLPrice, this._priceCdLPrice, this._stdUnPrcLPrice, this._fracProcUnitLPrice, this._fracProcLPrice, this._listPriceTaxIncFl, this._listPriceTaxExcFl, this._listPriceChngCd, this._salesRate, this._rateSectSalUnPrc, this._rateDivSalUnPrc, this._unPrcCalcCdSalUnPrc, this._priceCdSalUnPrc, this._stdUnPrcSalUnPrc, this._fracProcUnitSalUnPrc, this._fracProcSalUnPrc, this._salesUnPrcTaxIncFl, this._salesUnPrcTaxExcFl, this._salesUnPrcChngCd, this._costRate, this._rateSectCstUnPrc, this._rateDivUnCst, this._unPrcCalcCdUnCst, this._priceCdUnCst, this._stdUnPrcUnCst, this._fracProcUnitUnCst, this._fracProcUnCst, this._salesUnitCost, this._salesUnitCostChngDiv, this._rateBLGoodsCode, this._rateBLGoodsName, this._rateGoodsRateGrpCd, this._rateGoodsRateGrpNm, this._rateBLGroupCode, this._rateBLGroupName, this._prtBLGoodsCode, this._prtBLGoodsName, this._salesCode, this._salesCdNm, this._workManHour, this._shipmentCnt, this._acceptAnOrderCnt, this._acptAnOdrAdjustCnt, this._acptAnOdrRemainCnt, this._remainCntUpdDate, this._salesMoneyTaxInc, this._salesMoneyTaxExc, this._cost, this._grsProfitChkDiv, this._salesGoodsCd, this._salesPriceConsTax, this._taxationDivCd, this._partySlipNumDtl, this._dtlNote, this._supplierCd, this._supplierSnm, this._orderNumber, this._wayToOrder, this._slipMemo1, this._slipMemo2, this._slipMemo3, this._insideMemo1, this._insideMemo2, this._insideMemo3, this._bfListPrice, this._bfSalesUnitPrice, this._bfUnitCost, this._cmpltSalesRowNo, this._cmpltGoodsMakerCd, this._cmpltMakerName, this._cmpltMakerKanaName, this._cmpltGoodsName, this._cmpltShipmentCnt, this._cmpltSalesUnPrcFl, this._cmpltSalesMoney, this._cmpltSalesUnitCost, this._cmpltCost, this._cmpltPartySalSlNum, this._cmpltNote, this._selectedGoodsNoDiv, this._prtGoodsNo, this._prtMakerCode, this._prtMakerName, this._dtlRelationGuid, this._carRelationGuid, this._shipmentCntDefault, this._shipmentCntDefForChk, this._acceptAnOrderCntDefault, this._acceptAnOrderCntDefForChk, this._salesUnPrcTaxIncFlDefault, this._salesUnPrcTaxExcFlDefault, this._salesUnitCostTaxIncDefault, this._salesUnitCostTacExcDefault, this._campaignCode, this._campaignName, this._goodsDivCd, this._answerDelivDate, this._recycleDiv, this._recycleDivNm, this._wayToAcptOdr, this._goodsMngNo, this._inqRowNumber, this._inqRowNumDerivedNo, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._editStatus, this._rowStatus, this._salesMoneyInputDiv, this._shipmentCntDisplay, this._supplierStockDisplay, this._listPriceDisplay, this._stockDate, this._boCode, this._supplierCdForOrder, this._supplierSnmForOrder, this._autoAnswerDivSCM, this._acceptOrOrderKind, this._inquiryNumber);// add 2011/07/18 ���R
            //>>>2012/05/02
            //return new SalesDetail(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acceptAnOrderNo, this._acptAnOdrStatus, this._salesSlipNum, this._salesRowNo, this._salesRowDerivNo, this._sectionCode, this._subSectionCode, this._salesDate, this._commonSeqNo, this._salesSlipDtlNum, this._acptAnOdrStatusSrc, this._salesSlipDtlNumSrc, this._supplierFormalSync, this._stockSlipDtlNumSync, this._salesSlipCdDtl, this._deliGdsCmpltDueDate, this._goodsKindCode, this._goodsSearchDivCd, this._goodsMakerCd, this._makerName, this._makerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._bLGoodsCode, this._bLGoodsFullName, this._enterpriseGanreCode, this._enterpriseGanreName, this._warehouseCode, this._warehouseName, this._warehouseShelfNo, this._salesOrderDivCd, this._openPriceDiv, this._goodsRateRank, this._custRateGrpCode, this._listPriceRate, this._rateSectPriceUnPrc, this._rateDivLPrice, this._unPrcCalcCdLPrice, this._priceCdLPrice, this._stdUnPrcLPrice, this._fracProcUnitLPrice, this._fracProcLPrice, this._listPriceTaxIncFl, this._listPriceTaxExcFl, this._listPriceChngCd, this._salesRate, this._rateSectSalUnPrc, this._rateDivSalUnPrc, this._unPrcCalcCdSalUnPrc, this._priceCdSalUnPrc, this._stdUnPrcSalUnPrc, this._fracProcUnitSalUnPrc, this._fracProcSalUnPrc, this._salesUnPrcTaxIncFl, this._salesUnPrcTaxExcFl, this._salesUnPrcChngCd, this._costRate, this._rateSectCstUnPrc, this._rateDivUnCst, this._unPrcCalcCdUnCst, this._priceCdUnCst, this._stdUnPrcUnCst, this._fracProcUnitUnCst, this._fracProcUnCst, this._salesUnitCost, this._salesUnitCostChngDiv, this._rateBLGoodsCode, this._rateBLGoodsName, this._rateGoodsRateGrpCd, this._rateGoodsRateGrpNm, this._rateBLGroupCode, this._rateBLGroupName, this._prtBLGoodsCode, this._prtBLGoodsName, this._salesCode, this._salesCdNm, this._workManHour, this._shipmentCnt, this._acceptAnOrderCnt, this._acptAnOdrAdjustCnt, this._acptAnOdrRemainCnt, this._remainCntUpdDate, this._salesMoneyTaxInc, this._salesMoneyTaxExc, this._cost, this._grsProfitChkDiv, this._salesGoodsCd, this._salesPriceConsTax, this._taxationDivCd, this._partySlipNumDtl, this._dtlNote, this._supplierCd, this._supplierSnm, this._orderNumber, this._wayToOrder, this._slipMemo1, this._slipMemo2, this._slipMemo3, this._insideMemo1, this._insideMemo2, this._insideMemo3, this._bfListPrice, this._bfSalesUnitPrice, this._bfUnitCost, this._cmpltSalesRowNo, this._cmpltGoodsMakerCd, this._cmpltMakerName, this._cmpltMakerKanaName, this._cmpltGoodsName, this._cmpltShipmentCnt, this._cmpltSalesUnPrcFl, this._cmpltSalesMoney, this._cmpltSalesUnitCost, this._cmpltCost, this._cmpltPartySalSlNum, this._cmpltNote, this._selectedGoodsNoDiv, this._prtGoodsNo, this._prtMakerCode, this._prtMakerName, this._dtlRelationGuid, this._carRelationGuid, this._shipmentCntDefault, this._shipmentCntDefForChk, this._acceptAnOrderCntDefault, this._acceptAnOrderCntDefForChk, this._salesUnPrcTaxIncFlDefault, this._salesUnPrcTaxExcFlDefault, this._salesUnitCostTaxIncDefault, this._salesUnitCostTacExcDefault, this._campaignCode, this._campaignName, this._goodsDivCd, this._answerDelivDate, this._recycleDiv, this._recycleDivNm, this._wayToAcptOdr, this._goodsMngNo, this._inqRowNumber, this._inqRowNumDerivedNo, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._editStatus, this._rowStatus, this._salesMoneyInputDiv, this._shipmentCntDisplay, this._supplierStockDisplay, this._listPriceDisplay, this._stockDate, this._boCode, this._supplierCdForOrder, this._supplierSnmForOrder, this._autoAnswerDivSCM, this._acceptOrOrderKind, this._inquiryNumber, this._goodsSpecialNote);
            //return new SalesDetail(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acceptAnOrderNo, this._acptAnOdrStatus, this._salesSlipNum, this._salesRowNo, this._salesRowDerivNo, this._sectionCode, this._subSectionCode, this._salesDate, this._commonSeqNo, this._salesSlipDtlNum, this._acptAnOdrStatusSrc, this._salesSlipDtlNumSrc, this._supplierFormalSync, this._stockSlipDtlNumSync, this._salesSlipCdDtl, this._deliGdsCmpltDueDate, this._goodsKindCode, this._goodsSearchDivCd, this._goodsMakerCd, this._makerName, this._makerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._bLGoodsCode, this._bLGoodsFullName, this._enterpriseGanreCode, this._enterpriseGanreName, this._warehouseCode, this._warehouseName, this._warehouseShelfNo, this._salesOrderDivCd, this._openPriceDiv, this._goodsRateRank, this._custRateGrpCode, this._listPriceRate, this._rateSectPriceUnPrc, this._rateDivLPrice, this._unPrcCalcCdLPrice, this._priceCdLPrice, this._stdUnPrcLPrice, this._fracProcUnitLPrice, this._fracProcLPrice, this._listPriceTaxIncFl, this._listPriceTaxExcFl, this._listPriceChngCd, this._salesRate, this._rateSectSalUnPrc, this._rateDivSalUnPrc, this._unPrcCalcCdSalUnPrc, this._priceCdSalUnPrc, this._stdUnPrcSalUnPrc, this._fracProcUnitSalUnPrc, this._fracProcSalUnPrc, this._salesUnPrcTaxIncFl, this._salesUnPrcTaxExcFl, this._salesUnPrcChngCd, this._costRate, this._rateSectCstUnPrc, this._rateDivUnCst, this._unPrcCalcCdUnCst, this._priceCdUnCst, this._stdUnPrcUnCst, this._fracProcUnitUnCst, this._fracProcUnCst, this._salesUnitCost, this._salesUnitCostChngDiv, this._rateBLGoodsCode, this._rateBLGoodsName, this._rateGoodsRateGrpCd, this._rateGoodsRateGrpNm, this._rateBLGroupCode, this._rateBLGroupName, this._prtBLGoodsCode, this._prtBLGoodsName, this._salesCode, this._salesCdNm, this._workManHour, this._shipmentCnt, this._acceptAnOrderCnt, this._acptAnOdrAdjustCnt, this._acptAnOdrRemainCnt, this._remainCntUpdDate, this._salesMoneyTaxInc, this._salesMoneyTaxExc, this._cost, this._grsProfitChkDiv, this._salesGoodsCd, this._salesPriceConsTax, this._taxationDivCd, this._partySlipNumDtl, this._dtlNote, this._supplierCd, this._supplierSnm, this._orderNumber, this._wayToOrder, this._slipMemo1, this._slipMemo2, this._slipMemo3, this._insideMemo1, this._insideMemo2, this._insideMemo3, this._bfListPrice, this._bfSalesUnitPrice, this._bfUnitCost, this._cmpltSalesRowNo, this._cmpltGoodsMakerCd, this._cmpltMakerName, this._cmpltMakerKanaName, this._cmpltGoodsName, this._cmpltShipmentCnt, this._cmpltSalesUnPrcFl, this._cmpltSalesMoney, this._cmpltSalesUnitCost, this._cmpltCost, this._cmpltPartySalSlNum, this._cmpltNote, this._selectedGoodsNoDiv, this._prtGoodsNo, this._prtMakerCode, this._prtMakerName, this._dtlRelationGuid, this._carRelationGuid, this._shipmentCntDefault, this._shipmentCntDefForChk, this._acceptAnOrderCntDefault, this._acceptAnOrderCntDefForChk, this._salesUnPrcTaxIncFlDefault, this._salesUnPrcTaxExcFlDefault, this._salesUnitCostTaxIncDefault, this._salesUnitCostTacExcDefault, this._campaignCode, this._campaignName, this._goodsDivCd, this._answerDelivDate, this._recycleDiv, this._recycleDivNm, this._wayToAcptOdr, this._goodsMngNo, this._inqRowNumber, this._inqRowNumDerivedNo, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._editStatus, this._rowStatus, this._salesMoneyInputDiv, this._shipmentCntDisplay, this._supplierStockDisplay, this._listPriceDisplay, this._stockDate, this._boCode, this._supplierCdForOrder, this._supplierSnmForOrder, this._autoAnswerDivSCM, this._acceptOrOrderKind, this._inquiryNumber, this._goodsSpecialNote, this._rentSyncSupplier, this._rentSyncStockDate, this._rentSyncSupSlipNo);// DEL 2013/01/24 ���N�n�� REDMINE#34605
            return new SalesDetail(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acceptAnOrderNo, this._acptAnOdrStatus, this._salesSlipNum, this._salesRowNo, this._salesRowDerivNo, this._sectionCode, this._subSectionCode, this._salesDate, this._commonSeqNo, this._salesSlipDtlNum, this._acptAnOdrStatusSrc, this._salesSlipDtlNumSrc, this._supplierFormalSync, this._stockSlipDtlNumSync, this._salesSlipCdDtl, this._deliGdsCmpltDueDate, this._goodsKindCode, this._goodsSearchDivCd, this._goodsMakerCd, this._makerName, this._makerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._bLGoodsCode, this._bLGoodsFullName, this._enterpriseGanreCode, this._enterpriseGanreName, this._warehouseCode, this._warehouseName, this._warehouseShelfNo, this._salesOrderDivCd, this._openPriceDiv, this._goodsRateRank, this._custRateGrpCode, this._listPriceRate, this._rateSectPriceUnPrc, this._rateDivLPrice, this._unPrcCalcCdLPrice, this._priceCdLPrice, this._stdUnPrcLPrice, this._fracProcUnitLPrice, this._fracProcLPrice, this._listPriceTaxIncFl, this._listPriceTaxExcFl, this._listPriceChngCd, this._salesRate, this._rateSectSalUnPrc, this._rateDivSalUnPrc, this._unPrcCalcCdSalUnPrc, this._priceCdSalUnPrc, this._stdUnPrcSalUnPrc, this._fracProcUnitSalUnPrc, this._fracProcSalUnPrc, this._salesUnPrcTaxIncFl, this._salesUnPrcTaxExcFl, this._salesUnPrcChngCd, this._costRate, this._rateSectCstUnPrc, this._rateDivUnCst, this._unPrcCalcCdUnCst, this._priceCdUnCst, this._stdUnPrcUnCst, this._fracProcUnitUnCst, this._fracProcUnCst, this._salesUnitCost, this._salesUnitCostChngDiv, this._rateBLGoodsCode, this._rateBLGoodsName, this._rateGoodsRateGrpCd, this._rateGoodsRateGrpNm, this._rateBLGroupCode, this._rateBLGroupName, this._prtBLGoodsCode, this._prtBLGoodsName, this._salesCode, this._salesCdNm, this._workManHour, this._shipmentCnt, this._acceptAnOrderCnt, this._acptAnOdrAdjustCnt, this._acptAnOdrRemainCnt, this._remainCntUpdDate, this._salesMoneyTaxInc, this._salesMoneyTaxExc, this._cost, this._grsProfitChkDiv, this._salesGoodsCd, this._salesPriceConsTax, this._taxationDivCd, this._partySlipNumDtl, this._dtlNote, this._supplierCd, this._supplierSnm, this._orderNumber, this._wayToOrder, this._slipMemo1, this._slipMemo2, this._slipMemo3, this._insideMemo1, this._insideMemo2, this._insideMemo3, this._bfListPrice, this._bfSalesUnitPrice, this._bfUnitCost, this._cmpltSalesRowNo, this._cmpltGoodsMakerCd, this._cmpltMakerName, this._cmpltMakerKanaName, this._cmpltGoodsName, this._cmpltShipmentCnt, this._cmpltSalesUnPrcFl, this._cmpltSalesMoney, this._cmpltSalesUnitCost, this._cmpltCost, this._cmpltPartySalSlNum, this._cmpltNote, this._selectedGoodsNoDiv, this._prtGoodsNo, this._prtMakerCode, this._prtMakerName, this._dtlRelationGuid, this._carRelationGuid, this._shipmentCntDefault, this._shipmentCntDefForChk, this._acceptAnOrderCntDefault, this._acceptAnOrderCntDefForChk, this._salesUnPrcTaxIncFlDefault, this._salesUnPrcTaxExcFlDefault, this._salesUnitCostTaxIncDefault, this._salesUnitCostTacExcDefault, this._campaignCode, this._campaignName, this._goodsDivCd, this._answerDelivDate, this._recycleDiv, this._recycleDivNm, this._wayToAcptOdr, this._goodsMngNo, this._inqRowNumber, this._inqRowNumDerivedNo, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._editStatus, this._rowStatus, this._salesMoneyInputDiv, this._shipmentCntDisplay, this._supplierStockDisplay, this._listPriceDisplay, this._stockDate, this._boCode, this._supplierCdForOrder, this._supplierSnmForOrder, this._autoAnswerDivSCM, this._acceptOrOrderKind, this._inquiryNumber, this._goodsSpecialNote, this._rentSyncSupplier, this._rentSyncStockDate, this._rentSyncSupSlipNo, this._priceSelectDiv);// ADD 2013/01/24 ���N�n�� REDMINE#34605
            //<<<2012/05/02
            // 2012/01/16 Add <<<
        }

        /// <summary>
        /// ���㖾�׃f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SalesDetail�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesDetail�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(SalesDetail target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.AcceptAnOrderNo == target.AcceptAnOrderNo)
                 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
                 && (this.SalesSlipNum == target.SalesSlipNum)
                 && (this.SalesRowNo == target.SalesRowNo)
                 && (this.SalesRowDerivNo == target.SalesRowDerivNo)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SubSectionCode == target.SubSectionCode)
                 && (this.SalesDate == target.SalesDate)
                 && (this.CommonSeqNo == target.CommonSeqNo)
                 && (this.SalesSlipDtlNum == target.SalesSlipDtlNum)
                 && (this.AcptAnOdrStatusSrc == target.AcptAnOdrStatusSrc)
                 && (this.SalesSlipDtlNumSrc == target.SalesSlipDtlNumSrc)
                 && (this.SupplierFormalSync == target.SupplierFormalSync)
                 && (this.StockSlipDtlNumSync == target.StockSlipDtlNumSync)
                 && (this.SalesSlipCdDtl == target.SalesSlipCdDtl)
                 && (this.DeliGdsCmpltDueDate == target.DeliGdsCmpltDueDate)
                 && (this.GoodsKindCode == target.GoodsKindCode)
                 && (this.GoodsSearchDivCd == target.GoodsSearchDivCd)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.MakerName == target.MakerName)
                 && (this.MakerKanaName == target.MakerKanaName)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsName == target.GoodsName)
                 && (this.GoodsNameKana == target.GoodsNameKana)
                 && (this.GoodsLGroup == target.GoodsLGroup)
                 && (this.GoodsLGroupName == target.GoodsLGroupName)
                 && (this.GoodsMGroup == target.GoodsMGroup)
                 && (this.GoodsMGroupName == target.GoodsMGroupName)
                 && (this.BLGroupCode == target.BLGroupCode)
                 && (this.BLGroupName == target.BLGroupName)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.BLGoodsFullName == target.BLGoodsFullName)
                 && (this.EnterpriseGanreCode == target.EnterpriseGanreCode)
                 && (this.EnterpriseGanreName == target.EnterpriseGanreName)
                 && (this.WarehouseCode == target.WarehouseCode)
                 && (this.WarehouseName == target.WarehouseName)
                 && (this.WarehouseShelfNo == target.WarehouseShelfNo)
                 && (this.SalesOrderDivCd == target.SalesOrderDivCd)
                 && (this.OpenPriceDiv == target.OpenPriceDiv)
                 && (this.GoodsRateRank == target.GoodsRateRank)
                 && (this.CustRateGrpCode == target.CustRateGrpCode)
                 && (this.ListPriceRate == target.ListPriceRate)
                 && (this.RateSectPriceUnPrc == target.RateSectPriceUnPrc)
                 && (this.RateDivLPrice == target.RateDivLPrice)
                 && (this.UnPrcCalcCdLPrice == target.UnPrcCalcCdLPrice)
                 && (this.PriceCdLPrice == target.PriceCdLPrice)
                 && (this.StdUnPrcLPrice == target.StdUnPrcLPrice)
                 && (this.FracProcUnitLPrice == target.FracProcUnitLPrice)
                 && (this.FracProcLPrice == target.FracProcLPrice)
                 && (this.ListPriceTaxIncFl == target.ListPriceTaxIncFl)
                 && (this.ListPriceTaxExcFl == target.ListPriceTaxExcFl)
                 && (this.ListPriceChngCd == target.ListPriceChngCd)
                 && (this.SalesRate == target.SalesRate)
                 && (this.RateSectSalUnPrc == target.RateSectSalUnPrc)
                 && (this.RateDivSalUnPrc == target.RateDivSalUnPrc)
                 && (this.UnPrcCalcCdSalUnPrc == target.UnPrcCalcCdSalUnPrc)
                 && (this.PriceCdSalUnPrc == target.PriceCdSalUnPrc)
                 && (this.StdUnPrcSalUnPrc == target.StdUnPrcSalUnPrc)
                 && (this.FracProcUnitSalUnPrc == target.FracProcUnitSalUnPrc)
                 && (this.FracProcSalUnPrc == target.FracProcSalUnPrc)
                 && (this.SalesUnPrcTaxIncFl == target.SalesUnPrcTaxIncFl)
                 && (this.SalesUnPrcTaxExcFl == target.SalesUnPrcTaxExcFl)
                 && (this.SalesUnPrcChngCd == target.SalesUnPrcChngCd)
                 && (this.CostRate == target.CostRate)
                 && (this.RateSectCstUnPrc == target.RateSectCstUnPrc)
                 && (this.RateDivUnCst == target.RateDivUnCst)
                 && (this.UnPrcCalcCdUnCst == target.UnPrcCalcCdUnCst)
                 && (this.PriceCdUnCst == target.PriceCdUnCst)
                 && (this.StdUnPrcUnCst == target.StdUnPrcUnCst)
                 && (this.FracProcUnitUnCst == target.FracProcUnitUnCst)
                 && (this.FracProcUnCst == target.FracProcUnCst)
                 && (this.SalesUnitCost == target.SalesUnitCost)
                 && (this.SalesUnitCostChngDiv == target.SalesUnitCostChngDiv)
                 && (this.RateBLGoodsCode == target.RateBLGoodsCode)
                 && (this.RateBLGoodsName == target.RateBLGoodsName)
                 && (this.RateGoodsRateGrpCd == target.RateGoodsRateGrpCd)
                 && (this.RateGoodsRateGrpNm == target.RateGoodsRateGrpNm)
                 && (this.RateBLGroupCode == target.RateBLGroupCode)
                 && (this.RateBLGroupName == target.RateBLGroupName)
                 && (this.PrtBLGoodsCode == target.PrtBLGoodsCode)
                 && (this.PrtBLGoodsName == target.PrtBLGoodsName)
                 && (this.SalesCode == target.SalesCode)
                 && (this.SalesCdNm == target.SalesCdNm)
                 && (this.WorkManHour == target.WorkManHour)
                 && (this.ShipmentCnt == target.ShipmentCnt)
                 && (this.AcceptAnOrderCnt == target.AcceptAnOrderCnt)
                 && (this.AcptAnOdrAdjustCnt == target.AcptAnOdrAdjustCnt)
                 && (this.AcptAnOdrRemainCnt == target.AcptAnOdrRemainCnt)
                 && (this.RemainCntUpdDate == target.RemainCntUpdDate)
                 && (this.SalesMoneyTaxInc == target.SalesMoneyTaxInc)
                 && (this.SalesMoneyTaxExc == target.SalesMoneyTaxExc)
                 && (this.Cost == target.Cost)
                 && (this.GrsProfitChkDiv == target.GrsProfitChkDiv)
                 && (this.SalesGoodsCd == target.SalesGoodsCd)
                 && (this.SalesPriceConsTax == target.SalesPriceConsTax)
                 && (this.TaxationDivCd == target.TaxationDivCd)
                 && (this.PartySlipNumDtl == target.PartySlipNumDtl)
                 && (this.DtlNote == target.DtlNote)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.SupplierSnm == target.SupplierSnm)
                 && (this.OrderNumber == target.OrderNumber)
                 && (this.WayToOrder == target.WayToOrder)
                 && (this.SlipMemo1 == target.SlipMemo1)
                 && (this.SlipMemo2 == target.SlipMemo2)
                 && (this.SlipMemo3 == target.SlipMemo3)
                 && (this.InsideMemo1 == target.InsideMemo1)
                 && (this.InsideMemo2 == target.InsideMemo2)
                 && (this.InsideMemo3 == target.InsideMemo3)
                 && (this.BfListPrice == target.BfListPrice)
                 && (this.BfSalesUnitPrice == target.BfSalesUnitPrice)
                 && (this.BfUnitCost == target.BfUnitCost)
                 && (this.CmpltSalesRowNo == target.CmpltSalesRowNo)
                 && (this.CmpltGoodsMakerCd == target.CmpltGoodsMakerCd)
                 && (this.CmpltMakerName == target.CmpltMakerName)
                 && (this.CmpltMakerKanaName == target.CmpltMakerKanaName)
                 && (this.CmpltGoodsName == target.CmpltGoodsName)
                 && (this.CmpltShipmentCnt == target.CmpltShipmentCnt)
                 && (this.CmpltSalesUnPrcFl == target.CmpltSalesUnPrcFl)
                 && (this.CmpltSalesMoney == target.CmpltSalesMoney)
                 && (this.CmpltSalesUnitCost == target.CmpltSalesUnitCost)
                 && (this.CmpltCost == target.CmpltCost)
                 && (this.CmpltPartySalSlNum == target.CmpltPartySalSlNum)
                 && (this.CmpltNote == target.CmpltNote)
                 // --- ADD 2009/10/19 ---------->>>>>
                 && (this.SelectedGoodsNoDiv == target.SelectedGoodsNoDiv)
                 // --- ADD 2009/10/19 ----------<<<<<
                 && (this.PrtGoodsNo == target.PrtGoodsNo)
                 && (this.PrtMakerCode == target.PrtMakerCode)
                 && (this.PrtMakerName == target.PrtMakerName)
                 && (this.DtlRelationGuid == target.DtlRelationGuid)
                 && (this.CarRelationGuid == target.CarRelationGuid)
                 && (this.ShipmentCntDefault == target.ShipmentCntDefault)
                 && (this.ShipmentCntDefForChk == target.ShipmentCntDefForChk)
                 && (this.AcceptAnOrderCntDefault == target.AcceptAnOrderCntDefault)
                 && (this.AcceptAnOrderCntDefForChk == target.AcceptAnOrderCntDefForChk)
                 && (this.SalesUnPrcTaxIncFlDefault == target.SalesUnPrcTaxIncFlDefault)
                 && (this.SalesUnPrcTaxExcFlDefault == target.SalesUnPrcTaxExcFlDefault)
                 && (this.SalesUnitCostTaxIncDefault == target.SalesUnitCostTaxIncDefault)
                 && (this.SalesUnitCostTacExcDefault == target.SalesUnitCostTacExcDefault)
                //>>>2010/02/26
                 && (this.CampaignCode == target.CampaignCode)
                 && (this.CampaignName == target.CampaignName)
                 && (this.GoodsDivCd == target.GoodsDivCd)
                 && (this.AnswerDelivDate == target.AnswerDelivDate)
                 && (this.RecycleDiv == target.RecycleDiv)
                 && (this.RecycleDivNm == target.RecycleDivNm)
                 && (this.WayToAcptOdr == target.WayToAcptOdr)
                 && (this.GoodsMngNo == target.GoodsMngNo)
                 && (this.InqRowNumber == target.InqRowNumber)
                 && (this.InqRowNumDerivedNo == target.InqRowNumDerivedNo)
                //<<<2010/02/26
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.BLGoodsName == target.BLGoodsName)
                 && (this.EditStatus == target.EditStatus)//ADD 2010/04/06
                 && (this.RowStatus == target.RowStatus)//ADD 2010/04/06
                 && (this.SalesMoneyInputDiv == target.SalesMoneyInputDiv)//ADD 2010/04/06
                 && (this.ShipmentCntDisplay == target.ShipmentCntDisplay)//ADD 2010/04/06
                 && (this.SupplierStockDisplay == target.SupplierStockDisplay)//ADD 2010/04/06
                 && (this.StockDate == target.StockDate)//ADD 2010/04/06
                 && (this.BoCode == target.BoCode)//ADD 2010/04/06
                 && (this.SupplierCdForOrder == target.SupplierCdForOrder)//ADD 2010/04/06
                 && (this.SupplierSnmForOrder == target.SupplierSnmForOrder)//ADD 2010/04/06
                 && (this.AutoAnswerDivSCM == target.AutoAnswerDivSCM)//ADD 2011/07/18 ���R
                 //>>>2012/05/02
                 && (this.RentSyncStockDate == target.RentSyncStockDate)
                 && (this.RentSyncSupplier == target.RentSyncSupplier)
                 && (this.RentSyncSupSlipNo == target.RentSyncSupSlipNo)
                 //<<<2012/05/02
                 && (this.ListPriceDisplay == target.ListPriceDisplay)//ADD 2010/04/06
                 && (this.PriceSelectDiv == target.PriceSelectDiv));// ADD 2013/01/24 ���N�n�� REDMINE#34605
        }

        /// <summary>
        /// ���㖾�׃f�[�^��r����
        /// </summary>
        /// <param name="salesDetail1">
        ///                    ��r����SalesDetail�N���X�̃C���X�^���X
        /// </param>
        /// <param name="salesDetail2">��r����SalesDetail�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesDetail�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(SalesDetail salesDetail1, SalesDetail salesDetail2)
        {
            return ((salesDetail1.CreateDateTime == salesDetail2.CreateDateTime)
                 && (salesDetail1.UpdateDateTime == salesDetail2.UpdateDateTime)
                 && (salesDetail1.EnterpriseCode == salesDetail2.EnterpriseCode)
                 && (salesDetail1.FileHeaderGuid == salesDetail2.FileHeaderGuid)
                 && (salesDetail1.UpdEmployeeCode == salesDetail2.UpdEmployeeCode)
                 && (salesDetail1.UpdAssemblyId1 == salesDetail2.UpdAssemblyId1)
                 && (salesDetail1.UpdAssemblyId2 == salesDetail2.UpdAssemblyId2)
                 && (salesDetail1.LogicalDeleteCode == salesDetail2.LogicalDeleteCode)
                 && (salesDetail1.AcceptAnOrderNo == salesDetail2.AcceptAnOrderNo)
                 && (salesDetail1.AcptAnOdrStatus == salesDetail2.AcptAnOdrStatus)
                 && (salesDetail1.SalesSlipNum == salesDetail2.SalesSlipNum)
                 && (salesDetail1.SalesRowNo == salesDetail2.SalesRowNo)
                 && (salesDetail1.SalesRowDerivNo == salesDetail2.SalesRowDerivNo)
                 && (salesDetail1.SectionCode == salesDetail2.SectionCode)
                 && (salesDetail1.SubSectionCode == salesDetail2.SubSectionCode)
                 && (salesDetail1.SalesDate == salesDetail2.SalesDate)
                 && (salesDetail1.CommonSeqNo == salesDetail2.CommonSeqNo)
                 && (salesDetail1.SalesSlipDtlNum == salesDetail2.SalesSlipDtlNum)
                 && (salesDetail1.AcptAnOdrStatusSrc == salesDetail2.AcptAnOdrStatusSrc)
                 && (salesDetail1.SalesSlipDtlNumSrc == salesDetail2.SalesSlipDtlNumSrc)
                 && (salesDetail1.SupplierFormalSync == salesDetail2.SupplierFormalSync)
                 && (salesDetail1.StockSlipDtlNumSync == salesDetail2.StockSlipDtlNumSync)
                 && (salesDetail1.SalesSlipCdDtl == salesDetail2.SalesSlipCdDtl)
                 && (salesDetail1.DeliGdsCmpltDueDate == salesDetail2.DeliGdsCmpltDueDate)
                 && (salesDetail1.GoodsKindCode == salesDetail2.GoodsKindCode)
                 && (salesDetail1.GoodsSearchDivCd == salesDetail2.GoodsSearchDivCd)
                 && (salesDetail1.GoodsMakerCd == salesDetail2.GoodsMakerCd)
                 && (salesDetail1.MakerName == salesDetail2.MakerName)
                 && (salesDetail1.MakerKanaName == salesDetail2.MakerKanaName)
                 && (salesDetail1.GoodsNo == salesDetail2.GoodsNo)
                 && (salesDetail1.GoodsName == salesDetail2.GoodsName)
                 && (salesDetail1.GoodsNameKana == salesDetail2.GoodsNameKana)
                 && (salesDetail1.GoodsLGroup == salesDetail2.GoodsLGroup)
                 && (salesDetail1.GoodsLGroupName == salesDetail2.GoodsLGroupName)
                 && (salesDetail1.GoodsMGroup == salesDetail2.GoodsMGroup)
                 && (salesDetail1.GoodsMGroupName == salesDetail2.GoodsMGroupName)
                 && (salesDetail1.BLGroupCode == salesDetail2.BLGroupCode)
                 && (salesDetail1.BLGroupName == salesDetail2.BLGroupName)
                 && (salesDetail1.BLGoodsCode == salesDetail2.BLGoodsCode)
                 && (salesDetail1.BLGoodsFullName == salesDetail2.BLGoodsFullName)
                 && (salesDetail1.EnterpriseGanreCode == salesDetail2.EnterpriseGanreCode)
                 && (salesDetail1.EnterpriseGanreName == salesDetail2.EnterpriseGanreName)
                 && (salesDetail1.WarehouseCode == salesDetail2.WarehouseCode)
                 && (salesDetail1.WarehouseName == salesDetail2.WarehouseName)
                 && (salesDetail1.WarehouseShelfNo == salesDetail2.WarehouseShelfNo)
                 && (salesDetail1.SalesOrderDivCd == salesDetail2.SalesOrderDivCd)
                 && (salesDetail1.OpenPriceDiv == salesDetail2.OpenPriceDiv)
                 && (salesDetail1.GoodsRateRank == salesDetail2.GoodsRateRank)
                 && (salesDetail1.CustRateGrpCode == salesDetail2.CustRateGrpCode)
                 && (salesDetail1.ListPriceRate == salesDetail2.ListPriceRate)
                 && (salesDetail1.RateSectPriceUnPrc == salesDetail2.RateSectPriceUnPrc)
                 && (salesDetail1.RateDivLPrice == salesDetail2.RateDivLPrice)
                 && (salesDetail1.UnPrcCalcCdLPrice == salesDetail2.UnPrcCalcCdLPrice)
                 && (salesDetail1.PriceCdLPrice == salesDetail2.PriceCdLPrice)
                 && (salesDetail1.StdUnPrcLPrice == salesDetail2.StdUnPrcLPrice)
                 && (salesDetail1.FracProcUnitLPrice == salesDetail2.FracProcUnitLPrice)
                 && (salesDetail1.FracProcLPrice == salesDetail2.FracProcLPrice)
                 && (salesDetail1.ListPriceTaxIncFl == salesDetail2.ListPriceTaxIncFl)
                 && (salesDetail1.ListPriceTaxExcFl == salesDetail2.ListPriceTaxExcFl)
                 && (salesDetail1.ListPriceChngCd == salesDetail2.ListPriceChngCd)
                 && (salesDetail1.SalesRate == salesDetail2.SalesRate)
                 && (salesDetail1.RateSectSalUnPrc == salesDetail2.RateSectSalUnPrc)
                 && (salesDetail1.RateDivSalUnPrc == salesDetail2.RateDivSalUnPrc)
                 && (salesDetail1.UnPrcCalcCdSalUnPrc == salesDetail2.UnPrcCalcCdSalUnPrc)
                 && (salesDetail1.PriceCdSalUnPrc == salesDetail2.PriceCdSalUnPrc)
                 && (salesDetail1.StdUnPrcSalUnPrc == salesDetail2.StdUnPrcSalUnPrc)
                 && (salesDetail1.FracProcUnitSalUnPrc == salesDetail2.FracProcUnitSalUnPrc)
                 && (salesDetail1.FracProcSalUnPrc == salesDetail2.FracProcSalUnPrc)
                 && (salesDetail1.SalesUnPrcTaxIncFl == salesDetail2.SalesUnPrcTaxIncFl)
                 && (salesDetail1.SalesUnPrcTaxExcFl == salesDetail2.SalesUnPrcTaxExcFl)
                 && (salesDetail1.SalesUnPrcChngCd == salesDetail2.SalesUnPrcChngCd)
                 && (salesDetail1.CostRate == salesDetail2.CostRate)
                 && (salesDetail1.RateSectCstUnPrc == salesDetail2.RateSectCstUnPrc)
                 && (salesDetail1.RateDivUnCst == salesDetail2.RateDivUnCst)
                 && (salesDetail1.UnPrcCalcCdUnCst == salesDetail2.UnPrcCalcCdUnCst)
                 && (salesDetail1.PriceCdUnCst == salesDetail2.PriceCdUnCst)
                 && (salesDetail1.StdUnPrcUnCst == salesDetail2.StdUnPrcUnCst)
                 && (salesDetail1.FracProcUnitUnCst == salesDetail2.FracProcUnitUnCst)
                 && (salesDetail1.FracProcUnCst == salesDetail2.FracProcUnCst)
                 && (salesDetail1.SalesUnitCost == salesDetail2.SalesUnitCost)
                 && (salesDetail1.SalesUnitCostChngDiv == salesDetail2.SalesUnitCostChngDiv)
                 && (salesDetail1.RateBLGoodsCode == salesDetail2.RateBLGoodsCode)
                 && (salesDetail1.RateBLGoodsName == salesDetail2.RateBLGoodsName)
                 && (salesDetail1.RateGoodsRateGrpCd == salesDetail2.RateGoodsRateGrpCd)
                 && (salesDetail1.RateGoodsRateGrpNm == salesDetail2.RateGoodsRateGrpNm)
                 && (salesDetail1.RateBLGroupCode == salesDetail2.RateBLGroupCode)
                 && (salesDetail1.RateBLGroupName == salesDetail2.RateBLGroupName)
                 && (salesDetail1.PrtBLGoodsCode == salesDetail2.PrtBLGoodsCode)
                 && (salesDetail1.PrtBLGoodsName == salesDetail2.PrtBLGoodsName)
                 && (salesDetail1.SalesCode == salesDetail2.SalesCode)
                 && (salesDetail1.SalesCdNm == salesDetail2.SalesCdNm)
                 && (salesDetail1.WorkManHour == salesDetail2.WorkManHour)
                 && (salesDetail1.ShipmentCnt == salesDetail2.ShipmentCnt)
                 && (salesDetail1.AcceptAnOrderCnt == salesDetail2.AcceptAnOrderCnt)
                 && (salesDetail1.AcptAnOdrAdjustCnt == salesDetail2.AcptAnOdrAdjustCnt)
                 && (salesDetail1.AcptAnOdrRemainCnt == salesDetail2.AcptAnOdrRemainCnt)
                 && (salesDetail1.RemainCntUpdDate == salesDetail2.RemainCntUpdDate)
                 && (salesDetail1.SalesMoneyTaxInc == salesDetail2.SalesMoneyTaxInc)
                 && (salesDetail1.SalesMoneyTaxExc == salesDetail2.SalesMoneyTaxExc)
                 && (salesDetail1.Cost == salesDetail2.Cost)
                 && (salesDetail1.GrsProfitChkDiv == salesDetail2.GrsProfitChkDiv)
                 && (salesDetail1.SalesGoodsCd == salesDetail2.SalesGoodsCd)
                 && (salesDetail1.SalesPriceConsTax == salesDetail2.SalesPriceConsTax)
                 && (salesDetail1.TaxationDivCd == salesDetail2.TaxationDivCd)
                 && (salesDetail1.PartySlipNumDtl == salesDetail2.PartySlipNumDtl)
                 && (salesDetail1.DtlNote == salesDetail2.DtlNote)
                 && (salesDetail1.SupplierCd == salesDetail2.SupplierCd)
                 && (salesDetail1.SupplierSnm == salesDetail2.SupplierSnm)
                 && (salesDetail1.OrderNumber == salesDetail2.OrderNumber)
                 && (salesDetail1.WayToOrder == salesDetail2.WayToOrder)
                 && (salesDetail1.SlipMemo1 == salesDetail2.SlipMemo1)
                 && (salesDetail1.SlipMemo2 == salesDetail2.SlipMemo2)
                 && (salesDetail1.SlipMemo3 == salesDetail2.SlipMemo3)
                 && (salesDetail1.InsideMemo1 == salesDetail2.InsideMemo1)
                 && (salesDetail1.InsideMemo2 == salesDetail2.InsideMemo2)
                 && (salesDetail1.InsideMemo3 == salesDetail2.InsideMemo3)
                 && (salesDetail1.BfListPrice == salesDetail2.BfListPrice)
                 && (salesDetail1.BfSalesUnitPrice == salesDetail2.BfSalesUnitPrice)
                 && (salesDetail1.BfUnitCost == salesDetail2.BfUnitCost)
                 && (salesDetail1.CmpltSalesRowNo == salesDetail2.CmpltSalesRowNo)
                 && (salesDetail1.CmpltGoodsMakerCd == salesDetail2.CmpltGoodsMakerCd)
                 && (salesDetail1.CmpltMakerName == salesDetail2.CmpltMakerName)
                 && (salesDetail1.CmpltMakerKanaName == salesDetail2.CmpltMakerKanaName)
                 && (salesDetail1.CmpltGoodsName == salesDetail2.CmpltGoodsName)
                 && (salesDetail1.CmpltShipmentCnt == salesDetail2.CmpltShipmentCnt)
                 && (salesDetail1.CmpltSalesUnPrcFl == salesDetail2.CmpltSalesUnPrcFl)
                 && (salesDetail1.CmpltSalesMoney == salesDetail2.CmpltSalesMoney)
                 && (salesDetail1.CmpltSalesUnitCost == salesDetail2.CmpltSalesUnitCost)
                 && (salesDetail1.CmpltCost == salesDetail2.CmpltCost)
                 && (salesDetail1.CmpltPartySalSlNum == salesDetail2.CmpltPartySalSlNum)
                 && (salesDetail1.CmpltNote == salesDetail2.CmpltNote)
                 && (salesDetail1.SelectedGoodsNoDiv == salesDetail2.SelectedGoodsNoDiv)
                 && (salesDetail1.PrtGoodsNo == salesDetail2.PrtGoodsNo)
                 && (salesDetail1.PrtMakerCode == salesDetail2.PrtMakerCode)
                 && (salesDetail1.PrtMakerName == salesDetail2.PrtMakerName)
                 && (salesDetail1.DtlRelationGuid == salesDetail2.DtlRelationGuid)
                 && (salesDetail1.CarRelationGuid == salesDetail2.CarRelationGuid)
                 && (salesDetail1.ShipmentCntDefault == salesDetail2.ShipmentCntDefault)
                 && (salesDetail1.ShipmentCntDefForChk == salesDetail2.ShipmentCntDefForChk)
                 && (salesDetail1.AcceptAnOrderCntDefault == salesDetail2.AcceptAnOrderCntDefault)
                 && (salesDetail1.AcceptAnOrderCntDefForChk == salesDetail2.AcceptAnOrderCntDefForChk)
                 && (salesDetail1.SalesUnPrcTaxIncFlDefault == salesDetail2.SalesUnPrcTaxIncFlDefault)
                 && (salesDetail1.SalesUnPrcTaxExcFlDefault == salesDetail2.SalesUnPrcTaxExcFlDefault)
                 && (salesDetail1.SalesUnitCostTaxIncDefault == salesDetail2.SalesUnitCostTaxIncDefault)
                 && (salesDetail1.SalesUnitCostTacExcDefault == salesDetail2.SalesUnitCostTacExcDefault)
                //>>>2010/02/26
                 && (salesDetail1.CampaignCode == salesDetail2.CampaignCode)
                 && (salesDetail1.CampaignName == salesDetail2.CampaignName)
                 && (salesDetail1.GoodsDivCd == salesDetail2.GoodsDivCd)
                 && (salesDetail1.AnswerDelivDate == salesDetail2.AnswerDelivDate)
                 && (salesDetail1.RecycleDiv == salesDetail2.RecycleDiv)
                 && (salesDetail1.RecycleDivNm == salesDetail2.RecycleDivNm)
                 && (salesDetail1.WayToAcptOdr == salesDetail2.WayToAcptOdr)
                 && (salesDetail1.GoodsMngNo == salesDetail2.GoodsMngNo)
                 && (salesDetail1.InqRowNumber == salesDetail2.InqRowNumber)
                 && (salesDetail1.InqRowNumDerivedNo == salesDetail2.InqRowNumDerivedNo)
                //<<<2010/02/26
                 && (salesDetail1.EnterpriseName == salesDetail2.EnterpriseName)
                 && (salesDetail1.UpdEmployeeName == salesDetail2.UpdEmployeeName)
                 && (salesDetail1.BLGoodsName == salesDetail2.BLGoodsName)
                 && (salesDetail1.EditStatus == salesDetail2.EditStatus)// ADD 2010/04/06
                 && (salesDetail1.RowStatus == salesDetail2.RowStatus)// ADD 2010/04/06 
                 && (salesDetail1.SalesMoneyInputDiv == salesDetail2.SalesMoneyInputDiv)// ADD 2010/04/06
                 && (salesDetail1.ShipmentCntDisplay == salesDetail2.ShipmentCntDisplay)// ADD 2010/04/06
                 && (salesDetail1.SupplierStockDisplay == salesDetail2.SupplierStockDisplay)// ADD 2010/04/06
                 && (salesDetail1.StockDate == salesDetail2.StockDate)// ADD 2010/04/06
                 && (salesDetail1.BoCode == salesDetail2.BoCode)// ADD 2010/04/06
                 && (salesDetail1.SupplierCdForOrder == salesDetail2.SupplierCdForOrder)// ADD 2010/04/06
                 && (salesDetail1.SupplierSnmForOrder == salesDetail2.SupplierSnmForOrder)// ADD 2010/04/06
                 && (salesDetail1.AutoAnswerDivSCM == salesDetail2.AutoAnswerDivSCM)// ADD 2011/07/18 ���R
                 //>>>2012/05/02
                 && (salesDetail1.RentSyncStockDate == salesDetail2.RentSyncStockDate)
                 && (salesDetail1.RentSyncSupplier == salesDetail2.RentSyncSupplier)
                 && (salesDetail1.RentSyncSupSlipNo == salesDetail2.RentSyncSupSlipNo)
                //<<<2012/05/02
                 && (salesDetail1.ListPriceDisplay == salesDetail2.ListPriceDisplay)// ADD 2010/04/06
                 && (salesDetail1.PriceSelectDiv == salesDetail2.PriceSelectDiv));// ADD 2013/01/24 ���N�n�� REDMINE#34605
        }
        /// <summary>
        /// ���㖾�׃f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SalesDetail�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesDetail�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(SalesDetail target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.AcceptAnOrderNo != target.AcceptAnOrderNo) resList.Add("AcceptAnOrderNo");
            if (this.AcptAnOdrStatus != target.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (this.SalesSlipNum != target.SalesSlipNum) resList.Add("SalesSlipNum");
            if (this.SalesRowNo != target.SalesRowNo) resList.Add("SalesRowNo");
            if (this.SalesRowDerivNo != target.SalesRowDerivNo) resList.Add("SalesRowDerivNo");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SubSectionCode != target.SubSectionCode) resList.Add("SubSectionCode");
            if (this.SalesDate != target.SalesDate) resList.Add("SalesDate");
            if (this.CommonSeqNo != target.CommonSeqNo) resList.Add("CommonSeqNo");
            if (this.SalesSlipDtlNum != target.SalesSlipDtlNum) resList.Add("SalesSlipDtlNum");
            if (this.AcptAnOdrStatusSrc != target.AcptAnOdrStatusSrc) resList.Add("AcptAnOdrStatusSrc");
            if (this.SalesSlipDtlNumSrc != target.SalesSlipDtlNumSrc) resList.Add("SalesSlipDtlNumSrc");
            if (this.SupplierFormalSync != target.SupplierFormalSync) resList.Add("SupplierFormalSync");
            if (this.StockSlipDtlNumSync != target.StockSlipDtlNumSync) resList.Add("StockSlipDtlNumSync");
            if (this.SalesSlipCdDtl != target.SalesSlipCdDtl) resList.Add("SalesSlipCdDtl");
            if (this.DeliGdsCmpltDueDate != target.DeliGdsCmpltDueDate) resList.Add("DeliGdsCmpltDueDate");
            if (this.GoodsKindCode != target.GoodsKindCode) resList.Add("GoodsKindCode");
            if (this.GoodsSearchDivCd != target.GoodsSearchDivCd) resList.Add("GoodsSearchDivCd");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.MakerKanaName != target.MakerKanaName) resList.Add("MakerKanaName");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.GoodsNameKana != target.GoodsNameKana) resList.Add("GoodsNameKana");
            if (this.GoodsLGroup != target.GoodsLGroup) resList.Add("GoodsLGroup");
            if (this.GoodsLGroupName != target.GoodsLGroupName) resList.Add("GoodsLGroupName");
            if (this.GoodsMGroup != target.GoodsMGroup) resList.Add("GoodsMGroup");
            if (this.GoodsMGroupName != target.GoodsMGroupName) resList.Add("GoodsMGroupName");
            if (this.BLGroupCode != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.BLGroupName != target.BLGroupName) resList.Add("BLGroupName");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.BLGoodsFullName != target.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (this.EnterpriseGanreCode != target.EnterpriseGanreCode) resList.Add("EnterpriseGanreCode");
            if (this.EnterpriseGanreName != target.EnterpriseGanreName) resList.Add("EnterpriseGanreName");
            if (this.WarehouseCode != target.WarehouseCode) resList.Add("WarehouseCode");
            if (this.WarehouseName != target.WarehouseName) resList.Add("WarehouseName");
            if (this.WarehouseShelfNo != target.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (this.SalesOrderDivCd != target.SalesOrderDivCd) resList.Add("SalesOrderDivCd");
            if (this.OpenPriceDiv != target.OpenPriceDiv) resList.Add("OpenPriceDiv");
            if (this.GoodsRateRank != target.GoodsRateRank) resList.Add("GoodsRateRank");
            if (this.CustRateGrpCode != target.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (this.ListPriceRate != target.ListPriceRate) resList.Add("ListPriceRate");
            if (this.RateSectPriceUnPrc != target.RateSectPriceUnPrc) resList.Add("RateSectPriceUnPrc");
            if (this.RateDivLPrice != target.RateDivLPrice) resList.Add("RateDivLPrice");
            if (this.UnPrcCalcCdLPrice != target.UnPrcCalcCdLPrice) resList.Add("UnPrcCalcCdLPrice");
            if (this.PriceCdLPrice != target.PriceCdLPrice) resList.Add("PriceCdLPrice");
            if (this.StdUnPrcLPrice != target.StdUnPrcLPrice) resList.Add("StdUnPrcLPrice");
            if (this.FracProcUnitLPrice != target.FracProcUnitLPrice) resList.Add("FracProcUnitLPrice");
            if (this.FracProcLPrice != target.FracProcLPrice) resList.Add("FracProcLPrice");
            if (this.ListPriceTaxIncFl != target.ListPriceTaxIncFl) resList.Add("ListPriceTaxIncFl");
            if (this.ListPriceTaxExcFl != target.ListPriceTaxExcFl) resList.Add("ListPriceTaxExcFl");
            if (this.ListPriceChngCd != target.ListPriceChngCd) resList.Add("ListPriceChngCd");
            if (this.SalesRate != target.SalesRate) resList.Add("SalesRate");
            if (this.RateSectSalUnPrc != target.RateSectSalUnPrc) resList.Add("RateSectSalUnPrc");
            if (this.RateDivSalUnPrc != target.RateDivSalUnPrc) resList.Add("RateDivSalUnPrc");
            if (this.UnPrcCalcCdSalUnPrc != target.UnPrcCalcCdSalUnPrc) resList.Add("UnPrcCalcCdSalUnPrc");
            if (this.PriceCdSalUnPrc != target.PriceCdSalUnPrc) resList.Add("PriceCdSalUnPrc");
            if (this.StdUnPrcSalUnPrc != target.StdUnPrcSalUnPrc) resList.Add("StdUnPrcSalUnPrc");
            if (this.FracProcUnitSalUnPrc != target.FracProcUnitSalUnPrc) resList.Add("FracProcUnitSalUnPrc");
            if (this.FracProcSalUnPrc != target.FracProcSalUnPrc) resList.Add("FracProcSalUnPrc");
            if (this.SalesUnPrcTaxIncFl != target.SalesUnPrcTaxIncFl) resList.Add("SalesUnPrcTaxIncFl");
            if (this.SalesUnPrcTaxExcFl != target.SalesUnPrcTaxExcFl) resList.Add("SalesUnPrcTaxExcFl");
            if (this.SalesUnPrcChngCd != target.SalesUnPrcChngCd) resList.Add("SalesUnPrcChngCd");
            if (this.CostRate != target.CostRate) resList.Add("CostRate");
            if (this.RateSectCstUnPrc != target.RateSectCstUnPrc) resList.Add("RateSectCstUnPrc");
            if (this.RateDivUnCst != target.RateDivUnCst) resList.Add("RateDivUnCst");
            if (this.UnPrcCalcCdUnCst != target.UnPrcCalcCdUnCst) resList.Add("UnPrcCalcCdUnCst");
            if (this.PriceCdUnCst != target.PriceCdUnCst) resList.Add("PriceCdUnCst");
            if (this.StdUnPrcUnCst != target.StdUnPrcUnCst) resList.Add("StdUnPrcUnCst");
            if (this.FracProcUnitUnCst != target.FracProcUnitUnCst) resList.Add("FracProcUnitUnCst");
            if (this.FracProcUnCst != target.FracProcUnCst) resList.Add("FracProcUnCst");
            if (this.SalesUnitCost != target.SalesUnitCost) resList.Add("SalesUnitCost");
            if (this.SalesUnitCostChngDiv != target.SalesUnitCostChngDiv) resList.Add("SalesUnitCostChngDiv");
            if (this.RateBLGoodsCode != target.RateBLGoodsCode) resList.Add("RateBLGoodsCode");
            if (this.RateBLGoodsName != target.RateBLGoodsName) resList.Add("RateBLGoodsName");
            if (this.RateGoodsRateGrpCd != target.RateGoodsRateGrpCd) resList.Add("RateGoodsRateGrpCd");
            if (this.RateGoodsRateGrpNm != target.RateGoodsRateGrpNm) resList.Add("RateGoodsRateGrpNm");
            if (this.RateBLGroupCode != target.RateBLGroupCode) resList.Add("RateBLGroupCode");
            if (this.RateBLGroupName != target.RateBLGroupName) resList.Add("RateBLGroupName");
            if (this.PrtBLGoodsCode != target.PrtBLGoodsCode) resList.Add("PrtBLGoodsCode");
            if (this.PrtBLGoodsName != target.PrtBLGoodsName) resList.Add("PrtBLGoodsName");
            if (this.SalesCode != target.SalesCode) resList.Add("SalesCode");
            if (this.SalesCdNm != target.SalesCdNm) resList.Add("SalesCdNm");
            if (this.WorkManHour != target.WorkManHour) resList.Add("WorkManHour");
            if (this.ShipmentCnt != target.ShipmentCnt) resList.Add("ShipmentCnt");
            if (this.AcceptAnOrderCnt != target.AcceptAnOrderCnt) resList.Add("AcceptAnOrderCnt");
            if (this.AcptAnOdrAdjustCnt != target.AcptAnOdrAdjustCnt) resList.Add("AcptAnOdrAdjustCnt");
            if (this.AcptAnOdrRemainCnt != target.AcptAnOdrRemainCnt) resList.Add("AcptAnOdrRemainCnt");
            if (this.RemainCntUpdDate != target.RemainCntUpdDate) resList.Add("RemainCntUpdDate");
            if (this.SalesMoneyTaxInc != target.SalesMoneyTaxInc) resList.Add("SalesMoneyTaxInc");
            if (this.SalesMoneyTaxExc != target.SalesMoneyTaxExc) resList.Add("SalesMoneyTaxExc");
            if (this.Cost != target.Cost) resList.Add("Cost");
            if (this.GrsProfitChkDiv != target.GrsProfitChkDiv) resList.Add("GrsProfitChkDiv");
            if (this.SalesGoodsCd != target.SalesGoodsCd) resList.Add("SalesGoodsCd");
            if (this.SalesPriceConsTax != target.SalesPriceConsTax) resList.Add("SalesPriceConsTax");
            if (this.TaxationDivCd != target.TaxationDivCd) resList.Add("TaxationDivCd");
            if (this.PartySlipNumDtl != target.PartySlipNumDtl) resList.Add("PartySlipNumDtl");
            if (this.DtlNote != target.DtlNote) resList.Add("DtlNote");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.SupplierSnm != target.SupplierSnm) resList.Add("SupplierSnm");
            if (this.OrderNumber != target.OrderNumber) resList.Add("OrderNumber");
            if (this.WayToOrder != target.WayToOrder) resList.Add("WayToOrder");
            if (this.SlipMemo1 != target.SlipMemo1) resList.Add("SlipMemo1");
            if (this.SlipMemo2 != target.SlipMemo2) resList.Add("SlipMemo2");
            if (this.SlipMemo3 != target.SlipMemo3) resList.Add("SlipMemo3");
            if (this.InsideMemo1 != target.InsideMemo1) resList.Add("InsideMemo1");
            if (this.InsideMemo2 != target.InsideMemo2) resList.Add("InsideMemo2");
            if (this.InsideMemo3 != target.InsideMemo3) resList.Add("InsideMemo3");
            if (this.BfListPrice != target.BfListPrice) resList.Add("BfListPrice");
            if (this.BfSalesUnitPrice != target.BfSalesUnitPrice) resList.Add("BfSalesUnitPrice");
            if (this.BfUnitCost != target.BfUnitCost) resList.Add("BfUnitCost");
            if (this.CmpltSalesRowNo != target.CmpltSalesRowNo) resList.Add("CmpltSalesRowNo");
            if (this.CmpltGoodsMakerCd != target.CmpltGoodsMakerCd) resList.Add("CmpltGoodsMakerCd");
            if (this.CmpltMakerName != target.CmpltMakerName) resList.Add("CmpltMakerName");
            if (this.CmpltMakerKanaName != target.CmpltMakerKanaName) resList.Add("CmpltMakerKanaName");
            if (this.CmpltGoodsName != target.CmpltGoodsName) resList.Add("CmpltGoodsName");
            if (this.CmpltShipmentCnt != target.CmpltShipmentCnt) resList.Add("CmpltShipmentCnt");
            if (this.CmpltSalesUnPrcFl != target.CmpltSalesUnPrcFl) resList.Add("CmpltSalesUnPrcFl");
            if (this.CmpltSalesMoney != target.CmpltSalesMoney) resList.Add("CmpltSalesMoney");
            if (this.CmpltSalesUnitCost != target.CmpltSalesUnitCost) resList.Add("CmpltSalesUnitCost");
            if (this.CmpltCost != target.CmpltCost) resList.Add("CmpltCost");
            if (this.CmpltPartySalSlNum != target.CmpltPartySalSlNum) resList.Add("CmpltPartySalSlNum");
            if (this.CmpltNote != target.CmpltNote) resList.Add("CmpltNote");
            if (this.SelectedGoodsNoDiv != target.SelectedGoodsNoDiv) resList.Add("SelectedGoodsNoDiv");
            if (this.PrtGoodsNo != target.PrtGoodsNo) resList.Add("PrtGoodsNo");
            if (this.PrtMakerCode != target.PrtMakerCode) resList.Add("PrtMakerCode");
            if (this.PrtMakerName != target.PrtMakerName) resList.Add("PrtMakerName");
            if (this.DtlRelationGuid != target.DtlRelationGuid) resList.Add("DtlRelationGuid");
            if (this.CarRelationGuid != target.CarRelationGuid) resList.Add("CarRelationGuid");
            if (this.ShipmentCntDefault != target.ShipmentCntDefault) resList.Add("ShipmentCntDefault");
            if (this.ShipmentCntDefForChk != target.ShipmentCntDefForChk) resList.Add("ShipmentCntDefForChk");
            if (this.AcceptAnOrderCntDefault != target.AcceptAnOrderCntDefault) resList.Add("AcceptAnOrderCntDefault");
            if (this.AcceptAnOrderCntDefForChk != target.AcceptAnOrderCntDefForChk) resList.Add("AcceptAnOrderCntDefForChk");
            if (this.SalesUnPrcTaxIncFlDefault != target.SalesUnPrcTaxIncFlDefault) resList.Add("SalesUnPrcTaxIncFlDefault");
            if (this.SalesUnPrcTaxExcFlDefault != target.SalesUnPrcTaxExcFlDefault) resList.Add("SalesUnPrcTaxExcFlDefault");
            if (this.SalesUnitCostTaxIncDefault != target.SalesUnitCostTaxIncDefault) resList.Add("SalesUnitCostTaxIncDefault");
            if (this.SalesUnitCostTacExcDefault != target.SalesUnitCostTacExcDefault) resList.Add("SalesUnitCostTacExcDefault");
            //>>>2010/02/26
            if (this.CampaignCode != target.CampaignCode) resList.Add("CampaignCode");
            if (this.CampaignName != target.CampaignName) resList.Add("CampaignName");
            if (this.GoodsDivCd != target.GoodsDivCd) resList.Add("GoodsDivCd");
            if (this.AnswerDelivDate != target.AnswerDelivDate) resList.Add("AnswerDelivDate");
            if (this.RecycleDiv != target.RecycleDiv) resList.Add("RecycleDiv");
            if (this.RecycleDivNm != target.RecycleDivNm) resList.Add("RecycleDivNm");
            if (this.WayToAcptOdr != target.WayToAcptOdr) resList.Add("WayToAcptOdr");
            if (this.GoodsMngNo != target.GoodsMngNo) resList.Add("GoodsMngNo");
            if (this.InqRowNumber != target.InqRowNumber) resList.Add("InqRowNumber");
            if (this.InqRowNumDerivedNo != target.InqRowNumDerivedNo) resList.Add("InqRowNumDerivedNo");
            //<<<2010/02/26
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");
            if (this.EditStatus != target.EditStatus) resList.Add("EditStatus"); //ADD 2010/04/06 
            if (this.RowStatus != target.RowStatus) resList.Add("RowStatus"); //ADD 2010/04/06 
            if (this.SalesMoneyInputDiv != target.SalesMoneyInputDiv) resList.Add("SalesMoneyInputDiv"); //ADD 2010/04/06
            if (this.ShipmentCntDisplay != target.ShipmentCntDisplay) resList.Add("ShipmentCntDisplay"); //ADD 2010/04/06 
            if (this.SupplierStockDisplay != target.SupplierStockDisplay) resList.Add("SupplierStockDisplay"); //ADD 2010/04/06 
            if (this.ListPriceDisplay != target.ListPriceDisplay) resList.Add("ListPriceDisplay"); //ADD 2010/04/06 
            if (this.StockDate != target.StockDate) resList.Add("StockDate"); //ADD 2010/04/06 
            if (this.BoCode != target.BoCode) resList.Add("BoCode"); //ADD 2010/04/06 
            if (this.SupplierCdForOrder != target.SupplierCdForOrder) resList.Add("SupplierCdForOrder"); //ADD 2010/04/06 
            if (this.SupplierSnmForOrder != target.SupplierSnmForOrder) resList.Add("SupplierSnmForOrder"); //ADD 2010/04/06 
            if (this.AutoAnswerDivSCM != target.AutoAnswerDivSCM) resList.Add("AutoAnswerDivSCM"); //ADD 2011/07/18 ���R
            //>>>2012/05/02
            if (this.RentSyncStockDate != target.RentSyncStockDate) resList.Add("RentSyncStockDate");
            if (this.RentSyncSupplier != target.RentSyncSupplier) resList.Add("RentSyncSupplier");
            if (this.RentSyncSupSlipNo != target.RentSyncSupSlipNo) resList.Add("RentSyncSupSlipNo");
            //<<<2012/05/02
            if (this.PriceSelectDiv != target.PriceSelectDiv) resList.Add("PriceSelectDiv");// ADD 2013/01/24 ���N�n�� REDMINE#34605

            return resList;
        }

        /// <summary>
        /// ���㖾�׃f�[�^��r����
        /// </summary>
        /// <param name="salesDetail1">��r����SalesDetail�N���X�̃C���X�^���X</param>
        /// <param name="salesDetail2">��r����SalesDetail�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesDetail�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(SalesDetail salesDetail1, SalesDetail salesDetail2)
        {
            ArrayList resList = new ArrayList();
            if (salesDetail1.CreateDateTime != salesDetail2.CreateDateTime) resList.Add("CreateDateTime");
            if (salesDetail1.UpdateDateTime != salesDetail2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (salesDetail1.EnterpriseCode != salesDetail2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (salesDetail1.FileHeaderGuid != salesDetail2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (salesDetail1.UpdEmployeeCode != salesDetail2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (salesDetail1.UpdAssemblyId1 != salesDetail2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (salesDetail1.UpdAssemblyId2 != salesDetail2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (salesDetail1.LogicalDeleteCode != salesDetail2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (salesDetail1.AcceptAnOrderNo != salesDetail2.AcceptAnOrderNo) resList.Add("AcceptAnOrderNo");
            if (salesDetail1.AcptAnOdrStatus != salesDetail2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (salesDetail1.SalesSlipNum != salesDetail2.SalesSlipNum) resList.Add("SalesSlipNum");
            if (salesDetail1.SalesRowNo != salesDetail2.SalesRowNo) resList.Add("SalesRowNo");
            if (salesDetail1.SalesRowDerivNo != salesDetail2.SalesRowDerivNo) resList.Add("SalesRowDerivNo");
            if (salesDetail1.SectionCode != salesDetail2.SectionCode) resList.Add("SectionCode");
            if (salesDetail1.SubSectionCode != salesDetail2.SubSectionCode) resList.Add("SubSectionCode");
            if (salesDetail1.SalesDate != salesDetail2.SalesDate) resList.Add("SalesDate");
            if (salesDetail1.CommonSeqNo != salesDetail2.CommonSeqNo) resList.Add("CommonSeqNo");
            if (salesDetail1.SalesSlipDtlNum != salesDetail2.SalesSlipDtlNum) resList.Add("SalesSlipDtlNum");
            if (salesDetail1.AcptAnOdrStatusSrc != salesDetail2.AcptAnOdrStatusSrc) resList.Add("AcptAnOdrStatusSrc");
            if (salesDetail1.SalesSlipDtlNumSrc != salesDetail2.SalesSlipDtlNumSrc) resList.Add("SalesSlipDtlNumSrc");
            if (salesDetail1.SupplierFormalSync != salesDetail2.SupplierFormalSync) resList.Add("SupplierFormalSync");
            if (salesDetail1.StockSlipDtlNumSync != salesDetail2.StockSlipDtlNumSync) resList.Add("StockSlipDtlNumSync");
            if (salesDetail1.SalesSlipCdDtl != salesDetail2.SalesSlipCdDtl) resList.Add("SalesSlipCdDtl");
            if (salesDetail1.DeliGdsCmpltDueDate != salesDetail2.DeliGdsCmpltDueDate) resList.Add("DeliGdsCmpltDueDate");
            if (salesDetail1.GoodsKindCode != salesDetail2.GoodsKindCode) resList.Add("GoodsKindCode");
            if (salesDetail1.GoodsSearchDivCd != salesDetail2.GoodsSearchDivCd) resList.Add("GoodsSearchDivCd");
            if (salesDetail1.GoodsMakerCd != salesDetail2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (salesDetail1.MakerName != salesDetail2.MakerName) resList.Add("MakerName");
            if (salesDetail1.MakerKanaName != salesDetail2.MakerKanaName) resList.Add("MakerKanaName");
            if (salesDetail1.GoodsNo != salesDetail2.GoodsNo) resList.Add("GoodsNo");
            if (salesDetail1.GoodsName != salesDetail2.GoodsName) resList.Add("GoodsName");
            if (salesDetail1.GoodsNameKana != salesDetail2.GoodsNameKana) resList.Add("GoodsNameKana");
            if (salesDetail1.GoodsLGroup != salesDetail2.GoodsLGroup) resList.Add("GoodsLGroup");
            if (salesDetail1.GoodsLGroupName != salesDetail2.GoodsLGroupName) resList.Add("GoodsLGroupName");
            if (salesDetail1.GoodsMGroup != salesDetail2.GoodsMGroup) resList.Add("GoodsMGroup");
            if (salesDetail1.GoodsMGroupName != salesDetail2.GoodsMGroupName) resList.Add("GoodsMGroupName");
            if (salesDetail1.BLGroupCode != salesDetail2.BLGroupCode) resList.Add("BLGroupCode");
            if (salesDetail1.BLGroupName != salesDetail2.BLGroupName) resList.Add("BLGroupName");
            if (salesDetail1.BLGoodsCode != salesDetail2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (salesDetail1.BLGoodsFullName != salesDetail2.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (salesDetail1.EnterpriseGanreCode != salesDetail2.EnterpriseGanreCode) resList.Add("EnterpriseGanreCode");
            if (salesDetail1.EnterpriseGanreName != salesDetail2.EnterpriseGanreName) resList.Add("EnterpriseGanreName");
            if (salesDetail1.WarehouseCode != salesDetail2.WarehouseCode) resList.Add("WarehouseCode");
            if (salesDetail1.WarehouseName != salesDetail2.WarehouseName) resList.Add("WarehouseName");
            if (salesDetail1.WarehouseShelfNo != salesDetail2.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (salesDetail1.SalesOrderDivCd != salesDetail2.SalesOrderDivCd) resList.Add("SalesOrderDivCd");
            if (salesDetail1.OpenPriceDiv != salesDetail2.OpenPriceDiv) resList.Add("OpenPriceDiv");
            if (salesDetail1.GoodsRateRank != salesDetail2.GoodsRateRank) resList.Add("GoodsRateRank");
            if (salesDetail1.CustRateGrpCode != salesDetail2.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (salesDetail1.ListPriceRate != salesDetail2.ListPriceRate) resList.Add("ListPriceRate");
            if (salesDetail1.RateSectPriceUnPrc != salesDetail2.RateSectPriceUnPrc) resList.Add("RateSectPriceUnPrc");
            if (salesDetail1.RateDivLPrice != salesDetail2.RateDivLPrice) resList.Add("RateDivLPrice");
            if (salesDetail1.UnPrcCalcCdLPrice != salesDetail2.UnPrcCalcCdLPrice) resList.Add("UnPrcCalcCdLPrice");
            if (salesDetail1.PriceCdLPrice != salesDetail2.PriceCdLPrice) resList.Add("PriceCdLPrice");
            if (salesDetail1.StdUnPrcLPrice != salesDetail2.StdUnPrcLPrice) resList.Add("StdUnPrcLPrice");
            if (salesDetail1.FracProcUnitLPrice != salesDetail2.FracProcUnitLPrice) resList.Add("FracProcUnitLPrice");
            if (salesDetail1.FracProcLPrice != salesDetail2.FracProcLPrice) resList.Add("FracProcLPrice");
            if (salesDetail1.ListPriceTaxIncFl != salesDetail2.ListPriceTaxIncFl) resList.Add("ListPriceTaxIncFl");
            if (salesDetail1.ListPriceTaxExcFl != salesDetail2.ListPriceTaxExcFl) resList.Add("ListPriceTaxExcFl");
            if (salesDetail1.ListPriceChngCd != salesDetail2.ListPriceChngCd) resList.Add("ListPriceChngCd");
            if (salesDetail1.SalesRate != salesDetail2.SalesRate) resList.Add("SalesRate");
            if (salesDetail1.RateSectSalUnPrc != salesDetail2.RateSectSalUnPrc) resList.Add("RateSectSalUnPrc");
            if (salesDetail1.RateDivSalUnPrc != salesDetail2.RateDivSalUnPrc) resList.Add("RateDivSalUnPrc");
            if (salesDetail1.UnPrcCalcCdSalUnPrc != salesDetail2.UnPrcCalcCdSalUnPrc) resList.Add("UnPrcCalcCdSalUnPrc");
            if (salesDetail1.PriceCdSalUnPrc != salesDetail2.PriceCdSalUnPrc) resList.Add("PriceCdSalUnPrc");
            if (salesDetail1.StdUnPrcSalUnPrc != salesDetail2.StdUnPrcSalUnPrc) resList.Add("StdUnPrcSalUnPrc");
            if (salesDetail1.FracProcUnitSalUnPrc != salesDetail2.FracProcUnitSalUnPrc) resList.Add("FracProcUnitSalUnPrc");
            if (salesDetail1.FracProcSalUnPrc != salesDetail2.FracProcSalUnPrc) resList.Add("FracProcSalUnPrc");
            if (salesDetail1.SalesUnPrcTaxIncFl != salesDetail2.SalesUnPrcTaxIncFl) resList.Add("SalesUnPrcTaxIncFl");
            if (salesDetail1.SalesUnPrcTaxExcFl != salesDetail2.SalesUnPrcTaxExcFl) resList.Add("SalesUnPrcTaxExcFl");
            if (salesDetail1.SalesUnPrcChngCd != salesDetail2.SalesUnPrcChngCd) resList.Add("SalesUnPrcChngCd");
            if (salesDetail1.CostRate != salesDetail2.CostRate) resList.Add("CostRate");
            if (salesDetail1.RateSectCstUnPrc != salesDetail2.RateSectCstUnPrc) resList.Add("RateSectCstUnPrc");
            if (salesDetail1.RateDivUnCst != salesDetail2.RateDivUnCst) resList.Add("RateDivUnCst");
            if (salesDetail1.UnPrcCalcCdUnCst != salesDetail2.UnPrcCalcCdUnCst) resList.Add("UnPrcCalcCdUnCst");
            if (salesDetail1.PriceCdUnCst != salesDetail2.PriceCdUnCst) resList.Add("PriceCdUnCst");
            if (salesDetail1.StdUnPrcUnCst != salesDetail2.StdUnPrcUnCst) resList.Add("StdUnPrcUnCst");
            if (salesDetail1.FracProcUnitUnCst != salesDetail2.FracProcUnitUnCst) resList.Add("FracProcUnitUnCst");
            if (salesDetail1.FracProcUnCst != salesDetail2.FracProcUnCst) resList.Add("FracProcUnCst");
            if (salesDetail1.SalesUnitCost != salesDetail2.SalesUnitCost) resList.Add("SalesUnitCost");
            if (salesDetail1.SalesUnitCostChngDiv != salesDetail2.SalesUnitCostChngDiv) resList.Add("SalesUnitCostChngDiv");
            if (salesDetail1.RateBLGoodsCode != salesDetail2.RateBLGoodsCode) resList.Add("RateBLGoodsCode");
            if (salesDetail1.RateBLGoodsName != salesDetail2.RateBLGoodsName) resList.Add("RateBLGoodsName");
            if (salesDetail1.RateGoodsRateGrpCd != salesDetail2.RateGoodsRateGrpCd) resList.Add("RateGoodsRateGrpCd");
            if (salesDetail1.RateGoodsRateGrpNm != salesDetail2.RateGoodsRateGrpNm) resList.Add("RateGoodsRateGrpNm");
            if (salesDetail1.RateBLGroupCode != salesDetail2.RateBLGroupCode) resList.Add("RateBLGroupCode");
            if (salesDetail1.RateBLGroupName != salesDetail2.RateBLGroupName) resList.Add("RateBLGroupName");
            if (salesDetail1.PrtBLGoodsCode != salesDetail2.PrtBLGoodsCode) resList.Add("PrtBLGoodsCode");
            if (salesDetail1.PrtBLGoodsName != salesDetail2.PrtBLGoodsName) resList.Add("PrtBLGoodsName");
            if (salesDetail1.SalesCode != salesDetail2.SalesCode) resList.Add("SalesCode");
            if (salesDetail1.SalesCdNm != salesDetail2.SalesCdNm) resList.Add("SalesCdNm");
            if (salesDetail1.WorkManHour != salesDetail2.WorkManHour) resList.Add("WorkManHour");
            if (salesDetail1.ShipmentCnt != salesDetail2.ShipmentCnt) resList.Add("ShipmentCnt");
            if (salesDetail1.AcceptAnOrderCnt != salesDetail2.AcceptAnOrderCnt) resList.Add("AcceptAnOrderCnt");
            if (salesDetail1.AcptAnOdrAdjustCnt != salesDetail2.AcptAnOdrAdjustCnt) resList.Add("AcptAnOdrAdjustCnt");
            if (salesDetail1.AcptAnOdrRemainCnt != salesDetail2.AcptAnOdrRemainCnt) resList.Add("AcptAnOdrRemainCnt");
            if (salesDetail1.RemainCntUpdDate != salesDetail2.RemainCntUpdDate) resList.Add("RemainCntUpdDate");
            if (salesDetail1.SalesMoneyTaxInc != salesDetail2.SalesMoneyTaxInc) resList.Add("SalesMoneyTaxInc");
            if (salesDetail1.SalesMoneyTaxExc != salesDetail2.SalesMoneyTaxExc) resList.Add("SalesMoneyTaxExc");
            if (salesDetail1.Cost != salesDetail2.Cost) resList.Add("Cost");
            if (salesDetail1.GrsProfitChkDiv != salesDetail2.GrsProfitChkDiv) resList.Add("GrsProfitChkDiv");
            if (salesDetail1.SalesGoodsCd != salesDetail2.SalesGoodsCd) resList.Add("SalesGoodsCd");
            if (salesDetail1.SalesPriceConsTax != salesDetail2.SalesPriceConsTax) resList.Add("SalesPriceConsTax");
            if (salesDetail1.TaxationDivCd != salesDetail2.TaxationDivCd) resList.Add("TaxationDivCd");
            if (salesDetail1.PartySlipNumDtl != salesDetail2.PartySlipNumDtl) resList.Add("PartySlipNumDtl");
            if (salesDetail1.DtlNote != salesDetail2.DtlNote) resList.Add("DtlNote");
            if (salesDetail1.SupplierCd != salesDetail2.SupplierCd) resList.Add("SupplierCd");
            if (salesDetail1.SupplierSnm != salesDetail2.SupplierSnm) resList.Add("SupplierSnm");
            if (salesDetail1.OrderNumber != salesDetail2.OrderNumber) resList.Add("OrderNumber");
            if (salesDetail1.WayToOrder != salesDetail2.WayToOrder) resList.Add("WayToOrder");
            if (salesDetail1.SlipMemo1 != salesDetail2.SlipMemo1) resList.Add("SlipMemo1");
            if (salesDetail1.SlipMemo2 != salesDetail2.SlipMemo2) resList.Add("SlipMemo2");
            if (salesDetail1.SlipMemo3 != salesDetail2.SlipMemo3) resList.Add("SlipMemo3");
            if (salesDetail1.InsideMemo1 != salesDetail2.InsideMemo1) resList.Add("InsideMemo1");
            if (salesDetail1.InsideMemo2 != salesDetail2.InsideMemo2) resList.Add("InsideMemo2");
            if (salesDetail1.InsideMemo3 != salesDetail2.InsideMemo3) resList.Add("InsideMemo3");
            if (salesDetail1.BfListPrice != salesDetail2.BfListPrice) resList.Add("BfListPrice");
            if (salesDetail1.BfSalesUnitPrice != salesDetail2.BfSalesUnitPrice) resList.Add("BfSalesUnitPrice");
            if (salesDetail1.BfUnitCost != salesDetail2.BfUnitCost) resList.Add("BfUnitCost");
            if (salesDetail1.CmpltSalesRowNo != salesDetail2.CmpltSalesRowNo) resList.Add("CmpltSalesRowNo");
            if (salesDetail1.CmpltGoodsMakerCd != salesDetail2.CmpltGoodsMakerCd) resList.Add("CmpltGoodsMakerCd");
            if (salesDetail1.CmpltMakerName != salesDetail2.CmpltMakerName) resList.Add("CmpltMakerName");
            if (salesDetail1.CmpltMakerKanaName != salesDetail2.CmpltMakerKanaName) resList.Add("CmpltMakerKanaName");
            if (salesDetail1.CmpltGoodsName != salesDetail2.CmpltGoodsName) resList.Add("CmpltGoodsName");
            if (salesDetail1.CmpltShipmentCnt != salesDetail2.CmpltShipmentCnt) resList.Add("CmpltShipmentCnt");
            if (salesDetail1.CmpltSalesUnPrcFl != salesDetail2.CmpltSalesUnPrcFl) resList.Add("CmpltSalesUnPrcFl");
            if (salesDetail1.CmpltSalesMoney != salesDetail2.CmpltSalesMoney) resList.Add("CmpltSalesMoney");
            if (salesDetail1.CmpltSalesUnitCost != salesDetail2.CmpltSalesUnitCost) resList.Add("CmpltSalesUnitCost");
            if (salesDetail1.CmpltCost != salesDetail2.CmpltCost) resList.Add("CmpltCost");
            if (salesDetail1.CmpltPartySalSlNum != salesDetail2.CmpltPartySalSlNum) resList.Add("CmpltPartySalSlNum");
            if (salesDetail1.CmpltNote != salesDetail2.CmpltNote) resList.Add("CmpltNote");
            if (salesDetail1.SelectedGoodsNoDiv != salesDetail2.SelectedGoodsNoDiv) resList.Add("SelectedGoodsNoDiv");
            if (salesDetail1.PrtGoodsNo != salesDetail2.PrtGoodsNo) resList.Add("PrtGoodsNo");
            if (salesDetail1.PrtMakerCode != salesDetail2.PrtMakerCode) resList.Add("PrtMakerCode");
            if (salesDetail1.PrtMakerName != salesDetail2.PrtMakerName) resList.Add("PrtMakerName");
            if (salesDetail1.DtlRelationGuid != salesDetail2.DtlRelationGuid) resList.Add("DtlRelationGuid");
            if (salesDetail1.CarRelationGuid != salesDetail2.CarRelationGuid) resList.Add("CarRelationGuid");
            if (salesDetail1.ShipmentCntDefault != salesDetail2.ShipmentCntDefault) resList.Add("ShipmentCntDefault");
            if (salesDetail1.ShipmentCntDefForChk != salesDetail2.ShipmentCntDefForChk) resList.Add("ShipmentCntDefForChk");
            if (salesDetail1.AcceptAnOrderCntDefault != salesDetail2.AcceptAnOrderCntDefault) resList.Add("AcceptAnOrderCntDefault");
            if (salesDetail1.AcceptAnOrderCntDefForChk != salesDetail2.AcceptAnOrderCntDefForChk) resList.Add("AcceptAnOrderCntDefForChk");
            if (salesDetail1.SalesUnPrcTaxIncFlDefault != salesDetail2.SalesUnPrcTaxIncFlDefault) resList.Add("SalesUnPrcTaxIncFlDefault");
            if (salesDetail1.SalesUnPrcTaxExcFlDefault != salesDetail2.SalesUnPrcTaxExcFlDefault) resList.Add("SalesUnPrcTaxExcFlDefault");
            if (salesDetail1.SalesUnitCostTaxIncDefault != salesDetail2.SalesUnitCostTaxIncDefault) resList.Add("SalesUnitCostTaxIncDefault");
            if (salesDetail1.SalesUnitCostTacExcDefault != salesDetail2.SalesUnitCostTacExcDefault) resList.Add("SalesUnitCostTacExcDefault");
            //>>>2010/02/26
            if (salesDetail1.CampaignCode != salesDetail2.CampaignCode) resList.Add("CampaignCode");
            if (salesDetail1.CampaignName != salesDetail2.CampaignName) resList.Add("CampaignName");
            if (salesDetail1.GoodsDivCd != salesDetail2.GoodsDivCd) resList.Add("GoodsDivCd");
            if (salesDetail1.AnswerDelivDate != salesDetail2.AnswerDelivDate) resList.Add("AnswerDelivDate");
            if (salesDetail1.RecycleDiv != salesDetail2.RecycleDiv) resList.Add("RecycleDiv");
            if (salesDetail1.RecycleDivNm != salesDetail2.RecycleDivNm) resList.Add("RecycleDivNm");
            if (salesDetail1.WayToAcptOdr != salesDetail2.WayToAcptOdr) resList.Add("WayToAcptOdr");
            if (salesDetail1.GoodsMngNo != salesDetail2.GoodsMngNo) resList.Add("GoodsMngNo");
            if (salesDetail1.InqRowNumber != salesDetail2.InqRowNumber) resList.Add("InqRowNumber");
            if (salesDetail1.InqRowNumDerivedNo != salesDetail2.InqRowNumDerivedNo) resList.Add("InqRowNumDerivedNo");
            //<<<2010/02/26
            if (salesDetail1.EnterpriseName != salesDetail2.EnterpriseName) resList.Add("EnterpriseName");
            if (salesDetail1.UpdEmployeeName != salesDetail2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (salesDetail1.BLGoodsName != salesDetail2.BLGoodsName) resList.Add("BLGoodsName");
            if (salesDetail1.EditStatus != salesDetail2.EditStatus) resList.Add("EditStatus"); //ADD 2010/04/06
            if (salesDetail1.RowStatus != salesDetail2.RowStatus) resList.Add("RowStatus"); //ADD 2010/04/06
            if (salesDetail1.SalesMoneyInputDiv != salesDetail2.SalesMoneyInputDiv) resList.Add("SalesMoneyInputDiv"); //ADD 2010/04/06
            if (salesDetail1.ShipmentCntDisplay != salesDetail2.ShipmentCntDisplay) resList.Add("ShipmentCntDisplay"); //ADD 2010/04/06 
            if (salesDetail1.SupplierStockDisplay != salesDetail2.SupplierStockDisplay) resList.Add("SupplierStockDisplay"); //ADD 2010/04/06 
            if (salesDetail1.ListPriceDisplay != salesDetail2.ListPriceDisplay) resList.Add("ListPriceDisplay"); //ADD 2010/04/06 
            if (salesDetail1.StockDate != salesDetail2.StockDate) resList.Add("StockDate"); //ADD 2010/04/06 
            if (salesDetail1.BoCode != salesDetail2.BoCode) resList.Add("BoCode"); //ADD 2010/04/06 
            if (salesDetail1.SupplierCdForOrder != salesDetail2.SupplierCdForOrder) resList.Add("SupplierCdForOrder"); //ADD 2010/04/06 
            if (salesDetail1.SupplierSnmForOrder != salesDetail2.SupplierSnmForOrder) resList.Add("SupplierSnmForOrder"); //ADD 2010/04/06 
            if (salesDetail1.AutoAnswerDivSCM != salesDetail2.AutoAnswerDivSCM) resList.Add("AutoAnswerDivSCM"); //ADD 2011/07/18 ���R
            //>>>2012/05/02
            if (salesDetail1.RentSyncStockDate != salesDetail2.RentSyncStockDate) resList.Add("RentSyncStockDate");
            if (salesDetail1.RentSyncSupplier != salesDetail2.RentSyncSupplier) resList.Add("RentSyncSupplier");
            if (salesDetail1.RentSyncSupSlipNo != salesDetail2.RentSyncSupSlipNo) resList.Add("RentSyncSupSlipNo");
            //<<<2012/05/02
            if (salesDetail1.PriceSelectDiv != salesDetail2.PriceSelectDiv) resList.Add("PriceSelectDiv");// ADD 2013/01/24 ���N�n�� REDMINE#34605
            return resList;
        }

        /// <summary>
        /// ���㖾�׃f�[�^��r�N���X(����`�[�ԍ�(����)�A����s�ԍ�(����)�A����s�ԍ��}��(����))
        /// </summary>
        public class SalesDetailComparer : Comparer<SalesDetail>
        {
            /// <summary>
            /// ��r����
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public override int Compare(SalesDetail x, SalesDetail y)
            {
                int result = x.SalesSlipNum.CompareTo(y.SalesSlipNum);
                if (result != 0) return result;

                result = x.SalesRowNo.CompareTo(y.SalesRowNo);
                if (result != 0) return result;

                result = x.SalesRowDerivNo.CompareTo(y.SalesRowDerivNo);
                return result;
            }
        }
	}
}
