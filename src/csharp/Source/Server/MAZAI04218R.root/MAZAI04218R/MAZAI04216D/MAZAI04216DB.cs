using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   InventInputSearchResultWork
    /// <summary>
    ///                      �I���������o���ʃ��[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �I���������o���ʃ��[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/03/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/12/25 ������ Redmine#1994�Ή�</br>
    /// <br>Update Note      :   2010/03/02 ������ �W�����i��ǉ�����</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class InventInputSearchResultWork
    {
        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���_�K�C�h����</summary>
        private string _sectionGuideNm = "";

        /// <summary>�I���ʔ�</summary>
        private Int32 _inventorySeqNo;

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        /// <summary>�q�ɖ���</summary>
        private string _warehouseName = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        // --------ADD 2009/12/25--------->>>>>
        /// <summary>�����O�̏��i�ԍ�</summary>
        private string _goodsNoSrc = "";
        // --------ADD 2009/12/25---------<<<<<
        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>�q�ɒI��</summary>
        private string _warehouseShelfNo = "";

        /// <summary>�d���I��1</summary>
        private string _duplicationShelfNo1 = "";

        /// <summary>�d���I��2</summary>
        private string _duplicationShelfNo2 = "";

        /// <summary>���i�啪�ރR�[�h</summary>
        /// <remarks>���啪�ށi���[�U�[�K�C�h�j</remarks>
        private Int32 _goodsLGroup;

        /// <summary>���i�啪�ރR�[�h����</summary>
        private string _goodsLGroupName = "";

        /// <summary>���i�����ރR�[�h</summary>
        /// <remarks>�������ށi�}�X�^�L�j</remarks>
        private Int32 _goodsMGroup;

        /// <summary>���i�����ރR�[�h����</summary>
        private string _goodsMGroupName = "";

        /// <summary>BL�O���[�v�R�[�h</summary>
        /// <remarks>���O���[�v�R�[�h</remarks>
        private Int32 _bLGroupCode;

        /// <summary>BL�O���[�v�R�[�h����</summary>
        private string _bLGroupName = "";

        /// <summary>���Е��ރR�[�h</summary>
        private Int32 _enterpriseGanreCode;

        /// <summary>���Е��ޖ���</summary>
        private string _enterpriseGanreName = "";

        /// <summary>�a�k���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>�a�k���i�R�[�h�}��</summary>
        private Int32 _bLGoodsCdDerivedNo;

        /// <summary>�a�k���i����</summary>
        private string _bLGoodsName = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�i�`�m�R�[�h</summary>
        /// <remarks>�W���^�C�v13���܂��͒Z�k�^�C�v8����JAN�R�[�h</remarks>
        private string _jan = "";

        /// <summary>�d���P��</summary>
        /// <remarks>�Ŕ��� ���I���]���P��</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>�ύX�O�d���P��</summary>
        /// <remarks>�����l�͏����������������̎d���P��</remarks>
        private Double _bfStockUnitPriceFl;

        /// <summary>�d���P���ύX�t���O</summary>
        /// <remarks>0:����,1:�L��</remarks>
        private Int32 _stkUnitPriceChgFlg;

        /// <summary>�݌ɋ敪</summary>
        /// <remarks>0:����,1:���</remarks>
        private Int32 _stockDiv;

        /// <summary>�ŏI�d���N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _lastStockDate;

        /// <summary>�݌ɑ���</summary>
        /// <remarks>���됔</remarks>
        private Double _stockTotal;

        // --- ADD 2009/12/23 ---------->>>>>
        /// <summary>�o�א�</summary>
        /// <remarks>�o�א�</remarks>
        private Double _shipmentCnt;
        // --- ADD 2009/12/23 ----------<<<<<

        /// <summary>�o�א擾�Ӑ�R�[�h</summary>
        /// <remarks>�ϑ��E���؂莞�̓��Ӑ�R�[�h</remarks>
        private Int32 _shipCustomerCode;

        /// <summary>�o�א擾�Ӑ於��</summary>
        /// <remarks>�ϑ��E���؂莞�̓��Ӑ於��</remarks>
        private string _shipCustomerName = "";

        /// <summary>�o�ד��Ӑ於��2</summary>
        /// <remarks>�ϑ��E���؂莞�̓��Ӑ於��2</remarks>
        private string _shipCustomerName2 = "";

        /// <summary>�I���݌ɐ�</summary>
        /// <remarks>�I����</remarks>
        private Double _inventoryStockCnt;

        /// <summary>�I���ߕs����</summary>
        /// <remarks>�u�I���݌ɐ��|���{�����됔�v�ŎZ�o����</remarks>
        private Double _inventoryTolerancCnt;

        /// <summary>�I�������������t</summary>
        /// <remarks>�I�����������������������t���Z�b�g</remarks>
        private DateTime _inventoryPreprDay;

        /// <summary>�I��������������</summary>
        /// <remarks>�I���������������������������Z�b�g</remarks>
        private Int32 _inventoryPreprTim;

        /// <summary>�I�����{��</summary>
        /// <remarks>�I�����{�����Z�b�g</remarks>
        private DateTime _inventoryDay;

        /// <summary>�ŏI�I���X�V��</summary>
        private DateTime _lastInventoryUpdate;

        /// <summary>�I���V�K�ǉ��敪</summary>
        /// <remarks>0:�����쐬(��������),1:�V�K�쐬(�}�X�����j</remarks>
        private Int32 _inventoryNewDiv;

        /// <summary>�}�V���݌Ɋz</summary>
        /// <remarks>���݌ɑ����~�d���P��</remarks>
        private Int64 _stockMashinePrice;

        /// <summary>�I���݌Ɋz</summary>
        /// <remarks>���I���݌ɐ��~�d���P��</remarks>
        private Int64 _inventoryStockPrice;

        /// <summary>�I���ߕs�����z</summary>
        /// <remarks>���I���ߕs�����~�d���P��</remarks>
        private Int64 _inventoryTlrncPrice;

        /// <summary>�艿�i�����j</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Double _listPriceFl;

        /// <summary>�I����</summary>
        /// <remarks>�I�������Z�b�g</remarks>
        private DateTime _inventoryDate;

        /// <summary>�݌ɑ����i���{���j</summary>
        /// <remarks>�I�����{���ŎZ�o�����݌ɐ����Z�b�g</remarks>
        private Double _stockTotalExec;

        /// <summary>�ߕs���X�V�敪</summary>
        /// <remarks>0:���X�V�@1:�X�V</remarks>
        private Int32 _toleranceUpdateCd;

        /// <summary>�Z�o�݌ɐ�</summary>
        /// <remarks>�݌ɐ��Z�o���t�ɉ�����݌ɐ�</remarks>
        private Double _stockAmount;

        // --- ADD 2010/03/02 ---------->>>>>
        /// <summary>�W�����i</summary>
        /// <remarks>�W�����i</remarks>
        private Double _listPrice;
        // --- ADD 2010/03/02 ----------<<<<<


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
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  InventorySeqNo
        /// <summary>�I���ʔԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���ʔԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InventorySeqNo
        {
            get { return _inventorySeqNo; }
            set { _inventorySeqNo = value; }
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

        // ----------ADD 2009/12/25------------>>>>>
        /// public propaty name  :  GoodsNoSrc
        /// <summary>���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoSrc
        {
            get { return _goodsNoSrc; }
            set { _goodsNoSrc = value; }
        }
        // ----------ADD 2009/12/25------------<<<<<

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

        /// public propaty name  :  DuplicationShelfNo1
        /// <summary>�d���I��1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���I��1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DuplicationShelfNo1
        {
            get { return _duplicationShelfNo1; }
            set { _duplicationShelfNo1 = value; }
        }

        /// public propaty name  :  DuplicationShelfNo2
        /// <summary>�d���I��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���I��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DuplicationShelfNo2
        {
            get { return _duplicationShelfNo2; }
            set { _duplicationShelfNo2 = value; }
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
        /// <summary>���i�啪�ރR�[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�啪�ރR�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsLGroupName
        {
            get { return _goodsLGroupName; }
            set { _goodsLGroupName = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>���i�����ރR�[�h�v���p�e�B</summary>
        /// <value>�������ށi�}�X�^�L�j</value>
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
        /// <summary>���i�����ރR�[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރR�[�h���̃v���p�e�B</br>
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

        /// public propaty name  :  BLGoodsCode
        /// <summary>�a�k���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �a�k���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  BLGoodsCdDerivedNo
        /// <summary>�a�k���i�R�[�h�}�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �a�k���i�R�[�h�}�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCdDerivedNo
        {
            get { return _bLGoodsCdDerivedNo; }
            set { _bLGoodsCdDerivedNo = value; }
        }

        /// public propaty name  :  BLGoodsName
        /// <summary>�a�k���i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �a�k���i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsName
        {
            get { return _bLGoodsName; }
            set { _bLGoodsName = value; }
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

        /// public propaty name  :  Jan
        /// <summary>�i�`�m�R�[�h�v���p�e�B</summary>
        /// <value>�W���^�C�v13���܂��͒Z�k�^�C�v8����JAN�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�`�m�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Jan
        {
            get { return _jan; }
            set { _jan = value; }
        }

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>�d���P���v���p�e�B</summary>
        /// <value>�Ŕ��� ���I���]���P��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  BfStockUnitPriceFl
        /// <summary>�ύX�O�d���P���v���p�e�B</summary>
        /// <value>�����l�͏����������������̎d���P��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ύX�O�d���P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double BfStockUnitPriceFl
        {
            get { return _bfStockUnitPriceFl; }
            set { _bfStockUnitPriceFl = value; }
        }

        /// public propaty name  :  StkUnitPriceChgFlg
        /// <summary>�d���P���ύX�t���O�v���p�e�B</summary>
        /// <value>0:����,1:�L��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���ύX�t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StkUnitPriceChgFlg
        {
            get { return _stkUnitPriceChgFlg; }
            set { _stkUnitPriceChgFlg = value; }
        }

        /// public propaty name  :  StockDiv
        /// <summary>�݌ɋ敪�v���p�e�B</summary>
        /// <value>0:����,1:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockDiv
        {
            get { return _stockDiv; }
            set { _stockDiv = value; }
        }

        /// public propaty name  :  LastStockDate
        /// <summary>�ŏI�d���N�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI�d���N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime LastStockDate
        {
            get { return _lastStockDate; }
            set { _lastStockDate = value; }
        }

        /// public propaty name  :  StockTotal
        /// <summary>�݌ɑ����v���p�e�B</summary>
        /// <value>���됔</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɑ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockTotal
        {
            get { return _stockTotal; }
            set { _stockTotal = value; }
        }

        // --- ADD 2009/12/23 ---------->>>>>
        /// public propaty name  :  ShipmentCnt
        /// <summary>�o�א��v���p�e�B</summary>
        /// <value>�o�א�</value>
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
        // --- ADD 2009/12/23 ----------<<<<<

        /// public propaty name  :  ShipCustomerCode
        /// <summary>�o�א擾�Ӑ�R�[�h�v���p�e�B</summary>
        /// <value>�ϑ��E���؂莞�̓��Ӑ�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א擾�Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ShipCustomerCode
        {
            get { return _shipCustomerCode; }
            set { _shipCustomerCode = value; }
        }

        /// public propaty name  :  ShipCustomerName
        /// <summary>�o�א擾�Ӑ於�̃v���p�e�B</summary>
        /// <value>�ϑ��E���؂莞�̓��Ӑ於��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א擾�Ӑ於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShipCustomerName
        {
            get { return _shipCustomerName; }
            set { _shipCustomerName = value; }
        }

        /// public propaty name  :  ShipCustomerName2
        /// <summary>�o�ד��Ӑ於��2�v���p�e�B</summary>
        /// <value>�ϑ��E���؂莞�̓��Ӑ於��2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��Ӑ於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShipCustomerName2
        {
            get { return _shipCustomerName2; }
            set { _shipCustomerName2 = value; }
        }

        /// public propaty name  :  InventoryStockCnt
        /// <summary>�I���݌ɐ��v���p�e�B</summary>
        /// <value>�I����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double InventoryStockCnt
        {
            get { return _inventoryStockCnt; }
            set { _inventoryStockCnt = value; }
        }

        /// public propaty name  :  InventoryTolerancCnt
        /// <summary>�I���ߕs�����v���p�e�B</summary>
        /// <value>�u�I���݌ɐ��|���{�����됔�v�ŎZ�o����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���ߕs�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double InventoryTolerancCnt
        {
            get { return _inventoryTolerancCnt; }
            set { _inventoryTolerancCnt = value; }
        }

        /// public propaty name  :  InventoryPreprDay
        /// <summary>�I�������������t�v���p�e�B</summary>
        /// <value>�I�����������������������t���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�������������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime InventoryPreprDay
        {
            get { return _inventoryPreprDay; }
            set { _inventoryPreprDay = value; }
        }

        /// public propaty name  :  InventoryPreprTim
        /// <summary>�I�������������ԃv���p�e�B</summary>
        /// <value>�I���������������������������Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�������������ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InventoryPreprTim
        {
            get { return _inventoryPreprTim; }
            set { _inventoryPreprTim = value; }
        }

        /// public propaty name  :  InventoryDay
        /// <summary>�I�����{���v���p�e�B</summary>
        /// <value>�I�����{�����Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����{���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime InventoryDay
        {
            get { return _inventoryDay; }
            set { _inventoryDay = value; }
        }

        /// public propaty name  :  LastInventoryUpdate
        /// <summary>�ŏI�I���X�V���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI�I���X�V���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime LastInventoryUpdate
        {
            get { return _lastInventoryUpdate; }
            set { _lastInventoryUpdate = value; }
        }

        /// public propaty name  :  InventoryNewDiv
        /// <summary>�I���V�K�ǉ��敪�v���p�e�B</summary>
        /// <value>0:�����쐬(��������),1:�V�K�쐬(�}�X�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���V�K�ǉ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InventoryNewDiv
        {
            get { return _inventoryNewDiv; }
            set { _inventoryNewDiv = value; }
        }

        /// public propaty name  :  StockMashinePrice
        /// <summary>�}�V���݌Ɋz�v���p�e�B</summary>
        /// <value>���݌ɑ����~�d���P��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �}�V���݌Ɋz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockMashinePrice
        {
            get { return _stockMashinePrice; }
            set { _stockMashinePrice = value; }
        }

        /// public propaty name  :  InventoryStockPrice
        /// <summary>�I���݌Ɋz�v���p�e�B</summary>
        /// <value>���I���݌ɐ��~�d���P��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���݌Ɋz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 InventoryStockPrice
        {
            get { return _inventoryStockPrice; }
            set { _inventoryStockPrice = value; }
        }

        /// public propaty name  :  InventoryTlrncPrice
        /// <summary>�I���ߕs�����z�v���p�e�B</summary>
        /// <value>���I���ߕs�����~�d���P��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���ߕs�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 InventoryTlrncPrice
        {
            get { return _inventoryTlrncPrice; }
            set { _inventoryTlrncPrice = value; }
        }

        /// public propaty name  :  ListPriceFl
        /// <summary>�艿�i�����j�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPriceFl
        {
            get { return _listPriceFl; }
            set { _listPriceFl = value; }
        }

        /// public propaty name  :  InventoryDate
        /// <summary>�I�����v���p�e�B</summary>
        /// <value>�I�������Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime InventoryDate
        {
            get { return _inventoryDate; }
            set { _inventoryDate = value; }
        }

        /// public propaty name  :  StockTotalExec
        /// <summary>�݌ɑ����i���{���j�v���p�e�B</summary>
        /// <value>�I�����{���ŎZ�o�����݌ɐ����Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɑ����i���{���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockTotalExec
        {
            get { return _stockTotalExec; }
            set { _stockTotalExec = value; }
        }

        /// public propaty name  :  ToleranceUpdateCd
        /// <summary>�ߕs���X�V�敪�v���p�e�B</summary>
        /// <value>0:���X�V�@1:�X�V</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ߕs���X�V�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ToleranceUpdateCd
        {
            get { return _toleranceUpdateCd; }
            set { _toleranceUpdateCd = value; }
        }

        /// public propaty name  :  StockAmount
        /// <summary>�Z�o�݌ɐ��v���p�e�B</summary>
        /// <value>�݌ɐ��Z�o���t�ɉ�����݌ɐ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�o�݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockAmount
        {
            get { return _stockAmount; }
            set { _stockAmount = value; }
        }

        // --- ADD 2010/03/02 ---------->>>>>
        /// public propaty name  :  ListPrice
        /// <summary>�W�����i�v���p�e�B</summary>
        /// <value>�W�����i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }
        // --- ADD 2010/03/02 ----------<<<<<


        /// <summary>
        /// �I�����������[�g���o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>InventInputSearchResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InventInputSearchResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public InventInputSearchResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>InventInputSearchResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   InventInputSearchResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class InventInputSearchResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InventInputSearchResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  InventInputSearchResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is InventInputSearchResultWork || graph is ArrayList || graph is InventInputSearchResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(InventInputSearchResultWork).FullName));

            if (graph != null && graph is InventInputSearchResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.InventInputSearchResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is InventInputSearchResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((InventInputSearchResultWork[])graph).Length;
            }
            else if (graph is InventInputSearchResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //�I���ʔ�
            serInfo.MemberInfo.Add(typeof(Int32)); //InventorySeqNo
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //�q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            // ------------ADD 2009/12/25----------->>>>>
            //�����O�̏��i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNoSrc
            // ------------ADD 2009/12/25-----------<<<<<
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //�q�ɒI��
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //�d���I��1
            serInfo.MemberInfo.Add(typeof(string)); //DuplicationShelfNo1
            //�d���I��2
            serInfo.MemberInfo.Add(typeof(string)); //DuplicationShelfNo2
            //���i�啪�ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsLGroup
            //���i�啪�ރR�[�h����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsLGroupName
            //���i�����ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //���i�����ރR�[�h����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMGroupName
            //BL�O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //BL�O���[�v�R�[�h����
            serInfo.MemberInfo.Add(typeof(string)); //BLGroupName
            //���Е��ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterpriseGanreCode
            //���Е��ޖ���
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseGanreName
            //�a�k���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //�a�k���i�R�[�h�}��
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCdDerivedNo
            //�a�k���i����
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsName
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�i�`�m�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //Jan
            //�d���P��
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //�ύX�O�d���P��
            serInfo.MemberInfo.Add(typeof(Double)); //BfStockUnitPriceFl
            //�d���P���ύX�t���O
            serInfo.MemberInfo.Add(typeof(Int32)); //StkUnitPriceChgFlg
            //�݌ɋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDiv
            //�ŏI�d���N����
            serInfo.MemberInfo.Add(typeof(Int32)); //LastStockDate
            //�݌ɑ���
            serInfo.MemberInfo.Add(typeof(Double)); //StockTotal
            //�o�א擾�Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipCustomerCode
            //�o�א擾�Ӑ於��
            serInfo.MemberInfo.Add(typeof(string)); //ShipCustomerName
            //�o�ד��Ӑ於��2
            serInfo.MemberInfo.Add(typeof(string)); //ShipCustomerName2
            //�I���݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //InventoryStockCnt
            //�I���ߕs����
            serInfo.MemberInfo.Add(typeof(Double)); //InventoryTolerancCnt
            //�I�������������t
            serInfo.MemberInfo.Add(typeof(Int32)); //InventoryPreprDay
            //�I��������������
            serInfo.MemberInfo.Add(typeof(Int32)); //InventoryPreprTim
            //�I�����{��
            serInfo.MemberInfo.Add(typeof(Int32)); //InventoryDay
            //�ŏI�I���X�V��
            serInfo.MemberInfo.Add(typeof(Int32)); //LastInventoryUpdate
            //�I���V�K�ǉ��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //InventoryNewDiv
            //�}�V���݌Ɋz
            serInfo.MemberInfo.Add(typeof(Int64)); //StockMashinePrice
            //�I���݌Ɋz
            serInfo.MemberInfo.Add(typeof(Int64)); //InventoryStockPrice
            //�I���ߕs�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //InventoryTlrncPrice
            //�艿�i�����j
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceFl
            //�I����
            serInfo.MemberInfo.Add(typeof(Int32)); //InventoryDate
            //�݌ɑ����i���{���j
            serInfo.MemberInfo.Add(typeof(Double)); //StockTotalExec
            //�ߕs���X�V�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ToleranceUpdateCd
            //�Z�o�݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //StockAmount
            // --- ADD 2010/03/02 ---------->>>>>
            //�W�����i
            serInfo.MemberInfo.Add(typeof(Double)); //ListPrice
            // --- ADD 2010/03/02 ----------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is InventInputSearchResultWork)
            {
                InventInputSearchResultWork temp = (InventInputSearchResultWork)graph;

                SetInventInputSearchResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is InventInputSearchResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((InventInputSearchResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (InventInputSearchResultWork temp in lst)
                {
                    SetInventInputSearchResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// InventInputSearchResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        //private const int currentMemberCount = 50;// DEL 2010/03/02
        private const int currentMemberCount = 51;// ADD 2010/03/02

        /// <summary>
        ///  InventInputSearchResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InventInputSearchResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetInventInputSearchResultWork(System.IO.BinaryWriter writer, InventInputSearchResultWork temp)
        {
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideNm);
            //�I���ʔ�
            writer.Write(temp.InventorySeqNo);
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //�q�ɖ���
            writer.Write(temp.WarehouseName);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���[�J�[����
            writer.Write(temp.MakerName);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            // -----------ADD 2009/12/25------------>>>>>
            //�����O�̏��i�ԍ�
            writer.Write(temp.GoodsNoSrc);
            // -----------ADD 2009/12/25------------<<<<<
            //���i����
            writer.Write(temp.GoodsName);
            //�q�ɒI��
            writer.Write(temp.WarehouseShelfNo);
            //�d���I��1
            writer.Write(temp.DuplicationShelfNo1);
            //�d���I��2
            writer.Write(temp.DuplicationShelfNo2);
            //���i�啪�ރR�[�h
            writer.Write(temp.GoodsLGroup);
            //���i�啪�ރR�[�h����
            writer.Write(temp.GoodsLGroupName);
            //���i�����ރR�[�h
            writer.Write(temp.GoodsMGroup);
            //���i�����ރR�[�h����
            writer.Write(temp.GoodsMGroupName);
            //BL�O���[�v�R�[�h
            writer.Write(temp.BLGroupCode);
            //BL�O���[�v�R�[�h����
            writer.Write(temp.BLGroupName);
            //���Е��ރR�[�h
            writer.Write(temp.EnterpriseGanreCode);
            //���Е��ޖ���
            writer.Write(temp.EnterpriseGanreName);
            //�a�k���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //�a�k���i�R�[�h�}��
            writer.Write(temp.BLGoodsCdDerivedNo);
            //�a�k���i����
            writer.Write(temp.BLGoodsName);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�i�`�m�R�[�h
            writer.Write(temp.Jan);
            //�d���P��
            writer.Write(temp.StockUnitPriceFl);
            //�ύX�O�d���P��
            writer.Write(temp.BfStockUnitPriceFl);
            //�d���P���ύX�t���O
            writer.Write(temp.StkUnitPriceChgFlg);
            //�݌ɋ敪
            writer.Write(temp.StockDiv);
            //�ŏI�d���N����
            writer.Write((Int64)temp.LastStockDate.Ticks);
            //�݌ɑ���
            writer.Write(temp.StockTotal);
            // --- ADD 2009/12/23 ---------->>>>>
            //�o�א�
            writer.Write(temp.ShipmentCnt);
            // --- ADD 2009/12/23 ----------<<<<<
            //�o�א擾�Ӑ�R�[�h
            writer.Write(temp.ShipCustomerCode);
            //�o�א擾�Ӑ於��
            writer.Write(temp.ShipCustomerName);
            //�o�ד��Ӑ於��2
            writer.Write(temp.ShipCustomerName2);
            //�I���݌ɐ�
            writer.Write(temp.InventoryStockCnt);
            //�I���ߕs����
            writer.Write(temp.InventoryTolerancCnt);
            //�I�������������t
            writer.Write((Int64)temp.InventoryPreprDay.Ticks);
            //�I��������������
            writer.Write(temp.InventoryPreprTim);
            //�I�����{��
            writer.Write((Int64)temp.InventoryDay.Ticks);
            //�ŏI�I���X�V��
            writer.Write((Int64)temp.LastInventoryUpdate.Ticks);
            //�I���V�K�ǉ��敪
            writer.Write(temp.InventoryNewDiv);
            //�}�V���݌Ɋz
            writer.Write(temp.StockMashinePrice);
            //�I���݌Ɋz
            writer.Write(temp.InventoryStockPrice);
            //�I���ߕs�����z
            writer.Write(temp.InventoryTlrncPrice);
            //�艿�i�����j
            writer.Write(temp.ListPriceFl);
            //�I����
            writer.Write((Int64)temp.InventoryDate.Ticks);
            //�݌ɑ����i���{���j
            writer.Write(temp.StockTotalExec);
            //�ߕs���X�V�敪
            writer.Write(temp.ToleranceUpdateCd);
            //�Z�o�݌ɐ�
            writer.Write(temp.StockAmount);
            // --- ADD 2010/03/02 ---------->>>>>
            //�W�����i
            writer.Write(temp.ListPrice);
            // --- ADD 2010/03/02 ----------<<<<<

        }

        /// <summary>
        ///  InventInputSearchResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>InventInputSearchResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InventInputSearchResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private InventInputSearchResultWork GetInventInputSearchResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            InventInputSearchResultWork temp = new InventInputSearchResultWork();

            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideNm = reader.ReadString();
            //�I���ʔ�
            temp.InventorySeqNo = reader.ReadInt32();
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //�q�ɖ���
            temp.WarehouseName = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���[�J�[����
            temp.MakerName = reader.ReadString();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            // ----------ADD 2009/12/25----------->>>>>
            //���i�ԍ�
            temp.GoodsNoSrc = reader.ReadString();
            // ----------ADD 2009/12/25-----------<<<<<
            //���i����
            temp.GoodsName = reader.ReadString();
            //�q�ɒI��
            temp.WarehouseShelfNo = reader.ReadString();
            //�d���I��1
            temp.DuplicationShelfNo1 = reader.ReadString();
            //�d���I��2
            temp.DuplicationShelfNo2 = reader.ReadString();
            //���i�啪�ރR�[�h
            temp.GoodsLGroup = reader.ReadInt32();
            //���i�啪�ރR�[�h����
            temp.GoodsLGroupName = reader.ReadString();
            //���i�����ރR�[�h
            temp.GoodsMGroup = reader.ReadInt32();
            //���i�����ރR�[�h����
            temp.GoodsMGroupName = reader.ReadString();
            //BL�O���[�v�R�[�h
            temp.BLGroupCode = reader.ReadInt32();
            //BL�O���[�v�R�[�h����
            temp.BLGroupName = reader.ReadString();
            //���Е��ރR�[�h
            temp.EnterpriseGanreCode = reader.ReadInt32();
            //���Е��ޖ���
            temp.EnterpriseGanreName = reader.ReadString();
            //�a�k���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //�a�k���i�R�[�h�}��
            temp.BLGoodsCdDerivedNo = reader.ReadInt32();
            //�a�k���i����
            temp.BLGoodsName = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�i�`�m�R�[�h
            temp.Jan = reader.ReadString();
            //�d���P��
            temp.StockUnitPriceFl = reader.ReadDouble();
            //�ύX�O�d���P��
            temp.BfStockUnitPriceFl = reader.ReadDouble();
            //�d���P���ύX�t���O
            temp.StkUnitPriceChgFlg = reader.ReadInt32();
            //�݌ɋ敪
            temp.StockDiv = reader.ReadInt32();
            //�ŏI�d���N����
            temp.LastStockDate = new DateTime(reader.ReadInt64());
            //�݌ɑ���
            temp.StockTotal = reader.ReadDouble();
            // --- ADD 2009/12/23 ---------->>>>>
            //�o�א�
            temp.ShipmentCnt = reader.ReadDouble();
            // --- ADD 2009/12/23 ----------<<<<<
            //�o�א擾�Ӑ�R�[�h
            temp.ShipCustomerCode = reader.ReadInt32();
            //�o�א擾�Ӑ於��
            temp.ShipCustomerName = reader.ReadString();
            //�o�ד��Ӑ於��2
            temp.ShipCustomerName2 = reader.ReadString();
            //�I���݌ɐ�
            temp.InventoryStockCnt = reader.ReadDouble();
            //�I���ߕs����
            temp.InventoryTolerancCnt = reader.ReadDouble();
            //�I�������������t
            temp.InventoryPreprDay = new DateTime(reader.ReadInt64());
            //�I��������������
            temp.InventoryPreprTim = reader.ReadInt32();
            //�I�����{��
            temp.InventoryDay = new DateTime(reader.ReadInt64());
            //�ŏI�I���X�V��
            temp.LastInventoryUpdate = new DateTime(reader.ReadInt64());
            //�I���V�K�ǉ��敪
            temp.InventoryNewDiv = reader.ReadInt32();
            //�}�V���݌Ɋz
            temp.StockMashinePrice = reader.ReadInt64();
            //�I���݌Ɋz
            temp.InventoryStockPrice = reader.ReadInt64();
            //�I���ߕs�����z
            temp.InventoryTlrncPrice = reader.ReadInt64();
            //�艿�i�����j
            temp.ListPriceFl = reader.ReadDouble();
            //�I����
            temp.InventoryDate = new DateTime(reader.ReadInt64());
            //�݌ɑ����i���{���j
            temp.StockTotalExec = reader.ReadDouble();
            //�ߕs���X�V�敪
            temp.ToleranceUpdateCd = reader.ReadInt32();
            //�Z�o�݌ɐ�
            temp.StockAmount = reader.ReadDouble();
            // --- ADD 2010/03/02 ---------->>>>>
            //�W�����i
            temp.ListPrice = reader.ReadDouble();
            // --- ADD 2010/03/02 ----------<<<<<


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
        /// <returns>InventInputSearchResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InventInputSearchResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                InventInputSearchResultWork temp = GetInventInputSearchResultWork(reader, serInfo);
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
                    retValue = (InventInputSearchResultWork[])lst.ToArray(typeof(InventInputSearchResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
