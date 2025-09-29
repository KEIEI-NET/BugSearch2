using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   InventoryDataWork
    /// <summary>
    ///                      �I���f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �I���f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2007/7/18</br>
    /// <br>Genarated Date   :   2008/03/06  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/2/25  ����</br>
    /// <br>                 :   ���L���ڂ̒ǉ�</br>
    /// <br>                 :   �I�����C�݌ɑ����i���{���j�C�ߕs���X�V�敪</br>
    /// <br>                 :   ���L���ڂ̕⑫�����C��</br>
    /// <br>                 :   �I���݌ɐ��F�u���͐��v���u�I�����v�ɕύX</br>
    /// <br>                 :   �I���ߕs�����F�u�I���݌ɐ��|���{�����됔�v�ŎZ�o����</br>
    /// <br>                 :   �I�������������t�F�I�����������������������t���Z�b�g</br>
    /// <br>                 :   �I���������������F�I���������������������������Z�b�g</br>
    /// <br>                 :   �I�����{���F�u�I�����v���u�I�����{�����Z�b�g�v�ɕύX</br>
    /// <br>Update Note      :   2009/11/30 ���M �ێ�˗��B�Ή�</br>
    /// <br>                     �ړ����d���݌ɐ��A�o�א��i���v��j�A���א��i���v��j��ǉ�</br>
    /// <br>Update Note      : 2012/06/08 yangyi</br>
    /// <br>�Ǘ��ԍ�         : 10801804-00 2012/06/27�z�M��</br>
    /// <br>                 Redmine#30282 ��1002 �I�����������̉��ǂ̑Ή�</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class InventoryDataWork : IFileHeader
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

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�I���ʔ�</summary>
        private Int32 _inventorySeqNo;

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>�q�ɒI��</summary>
        private string _warehouseShelfNo = "";

        /// <summary>�d���I�ԂP</summary>
        private string _duplicationShelfNo1 = "";

        /// <summary>�d���I�ԂQ</summary>
        private string _duplicationShelfNo2 = "";

        /// <summary>���i�啪�ރR�[�h</summary>
        /// <remarks>���啪�ށi���[�U�[�K�C�h�j</remarks>
        private Int32 _goodsLGroup;

        /// <summary>���i�����ރR�[�h</summary>
        /// <remarks>�������ށi�}�X�^�L�j</remarks>
        private Int32 _goodsMGroup;

        /// <summary>BL�O���[�v�R�[�h</summary>
        /// <remarks>���O���[�v�R�[�h</remarks>
        private Int32 _bLGroupCode;

        /// <summary>���Е��ރR�[�h</summary>
        private Int32 _enterpriseGanreCode;

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>�d����R�[�h</summary>
        /// <remarks>�d�����s�����d����R�[�h���Z�b�g</remarks>
        private Int32 _supplierCd;

        /// <summary>JAN�R�[�h</summary>
        /// <remarks>�W���^�C�v13���܂��͒Z�k�^�C�v8����JAN�R�[�h</remarks>
        private string _jan = "";

        /// <summary>�d���P��(����)</summary>
        /// <remarks>�Ŕ��� </remarks>
        private Double _stockUnitPriceFl;

        /// <summary>�ύX�O�d���P���i�����j</summary>
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

        /// <summary>�o�א擾�Ӑ�R�[�h</summary>
        /// <remarks>�ϑ��E���؂莞�̓��Ӑ�R�[�h</remarks>
        private Int32 _shipCustomerCode;

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

        /// <summary>�I����</summary>
        /// <remarks>�I�������Z�b�g</remarks>
        private DateTime _inventoryDate;

        /// <summary>�݌ɑ����i���{���j</summary>
        /// <remarks>�I�����{���ŎZ�o�����݌ɐ����Z�b�g</remarks>
        private Double _stockTotalExec;

        /// <summary>�ߕs���X�V�敪</summary>
        /// <remarks>0:���X�V�@1:�X�V</remarks>
        private Int32 _toleranceUpdateCd;

        /// <summary>�����p�v�Z����</summary>
        private Double _adjstCalcCost;

        // --- ADD 2009/11/30 ---------->>>>>
        /// <summary>�ړ����d���݌ɐ�</summary>
        private Double _movingSupliStock;

        /// <summary>�o�א��i���v��j</summary>
        private Double _shipmentCnt;

        /// <summary>���א��i���v��j</summary>
        private Double _arrivalCnt;
        // --- ADD 2009/11/30 ----------<<<<<

        //-----ADD 2011/01/11 ----->>>>>
        /// <summary>�艿�i�����j</summary>
        private Double _listPriceFl;

        /// <summary>�����O�̏��i�ԍ�</summary>
        private string _goodsNoSrc = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";
        //-----ADD 2011/01/11 -----<<<<<

        //-----ADD 2012/06/08----->>>>>
        /// <summary>�J�n�Ǘ����_�R�[�h</summary>
        private string _sectionCodeSt = "";

        /// <summary>�I���Ǘ����_�R�[�h</summary>
        private string _sectionCodeEd = "";
        //-----ADD 2012/06/08-----<<<<<

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
        /// <summary>�d���I�ԂP�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���I�ԂP�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DuplicationShelfNo1
        {
            get { return _duplicationShelfNo1; }
            set { _duplicationShelfNo1 = value; }
        }

        /// public propaty name  :  DuplicationShelfNo2
        /// <summary>�d���I�ԂQ�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���I�ԂQ�v���p�e�B</br>
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

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// <value>�d�����s�����d����R�[�h���Z�b�g</value>
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
        /// <summary>JAN�R�[�h�v���p�e�B</summary>
        /// <value>�W���^�C�v13���܂��͒Z�k�^�C�v8����JAN�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   JAN�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Jan
        {
            get { return _jan; }
            set { _jan = value; }
        }

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>�d���P��(����)�v���p�e�B</summary>
        /// <value>�Ŕ��� </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P��(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  BfStockUnitPriceFl
        /// <summary>�ύX�O�d���P���i�����j�v���p�e�B</summary>
        /// <value>�����l�͏����������������̎d���P��</value>
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

        /// public propaty name  :  AdjstCalcCost
        /// <summary>�����p�v�Z�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����p�v�Z�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AdjstCalcCost
        {
            get { return _adjstCalcCost; }
            set { _adjstCalcCost = value; }
        }

        // --- ADD 2009/11/30 ---------->>>>>
        /// public propaty name  :  MovingSupliStock
        /// <summary>�ړ����d���݌ɐ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����d���݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MovingSupliStock
        {
            get { return _movingSupliStock; }
            set { _movingSupliStock = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>�o�א��i���v��j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א��i���v��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
        }

        /// public propaty name  :  ArrivalCnt
        /// <summary>���א��i���v��j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���א��i���v��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ArrivalCnt
        {
            get { return _arrivalCnt; }
            set { _arrivalCnt = value; }
        }
        // --- ADD 2009/11/30 ----------<<<<<

        //-----ADD 2011/01/11 ----->>>>>
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
        //-----ADD 2011/01/11 -----<<<<<

        //-----ADD 2012/06/08----->>>>>
        /// public propaty name  :  SectionCodeSt
        /// <summary>�J�n�Ǘ����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�Ǘ����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCodeSt
        {
            get { return _sectionCodeSt; }
            set { _sectionCodeSt = value; }
        }

        /// public propaty name  :  SectionCodeEd
        /// <summary>�I���Ǘ����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���Ǘ����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCodeEd
        {
            get { return _sectionCodeEd; }
            set { _sectionCodeEd = value; }
        }
        //-----ADD 2012/06/08-----<<<<<

        /// <summary>
        /// �I���f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>InventoryDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InventoryDataWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public InventoryDataWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>InventoryDataWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   InventoryDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class InventoryDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InventoryDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  InventoryDataWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is InventoryDataWork || graph is ArrayList || graph is InventoryDataWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(InventoryDataWork).FullName));

            if (graph != null && graph is InventoryDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.InventoryDataWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is InventoryDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((InventoryDataWork[])graph).Length;
            }
            else if (graph is InventoryDataWork)
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
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //�I���ʔ�
            serInfo.MemberInfo.Add(typeof(Int32)); //InventorySeqNo
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //�q�ɒI��
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //�d���I�ԂP
            serInfo.MemberInfo.Add(typeof(string)); //DuplicationShelfNo1
            //�d���I�ԂQ
            serInfo.MemberInfo.Add(typeof(string)); //DuplicationShelfNo2
            //���i�啪�ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsLGroup
            //���i�����ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //BL�O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //���Е��ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterpriseGanreCode
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //JAN�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //Jan
            //�d���P��(����)
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //�ύX�O�d���P���i�����j
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
            //�I����
            serInfo.MemberInfo.Add(typeof(Int32)); //InventoryDate
            //�݌ɑ����i���{���j
            serInfo.MemberInfo.Add(typeof(Double)); //StockTotalExec
            //�ߕs���X�V�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ToleranceUpdateCd
            //�����p�v�Z����
            serInfo.MemberInfo.Add(typeof(Double)); //AdjstCalcCost
            // --- ADD 2009/11/30 ---------->>>>>
            //�ړ����d���݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //MovingSupliStock
            //�o�א��i���v��j
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //���א��i���v��j
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt
            // --- ADD 2009/11/30 ----------<<<<<
            //-----ADD 2011/01/11 ----->>>>>
            //�艿�i�����j
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceFl
            //�����O�̏��i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNoSrc
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName

            //-----ADD 2011/01/11 -----<<<<<
            //-----ADD 2012/06/08 ----->>>>>
            serInfo.MemberInfo.Add(typeof(string));  //sectionCodeSt
            serInfo.MemberInfo.Add(typeof(string));  //sectionCodeEd
            //-----ADD 2012/06/08 -----<<<<<
            serInfo.Serialize(writer, serInfo);
            if (graph is InventoryDataWork)
            {
                InventoryDataWork temp = (InventoryDataWork)graph;

                SetInventoryDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is InventoryDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((InventoryDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (InventoryDataWork temp in lst)
                {
                    SetInventoryDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// InventoryDataWork�����o��(public�v���p�e�B��)
        /// </summary>
        //private const int currentMemberCount = 47;//DEL 2011/01/11
        //private const int currentMemberCount = 50;//ADD 2011/01/11 //DEL 2012/06/08
        private const int currentMemberCount = 52;//ADD 2011/01/11
        /// <summary>
        ///  InventoryDataWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InventoryDataWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetInventoryDataWork(System.IO.BinaryWriter writer, InventoryDataWork temp)
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
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //�I���ʔ�
            writer.Write(temp.InventorySeqNo);
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //�q�ɒI��
            writer.Write(temp.WarehouseShelfNo);
            //�d���I�ԂP
            writer.Write(temp.DuplicationShelfNo1);
            //�d���I�ԂQ
            writer.Write(temp.DuplicationShelfNo2);
            //���i�啪�ރR�[�h
            writer.Write(temp.GoodsLGroup);
            //���i�����ރR�[�h
            writer.Write(temp.GoodsMGroup);
            //BL�O���[�v�R�[�h
            writer.Write(temp.BLGroupCode);
            //���Е��ރR�[�h
            writer.Write(temp.EnterpriseGanreCode);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //JAN�R�[�h
            writer.Write(temp.Jan);
            //�d���P��(����)
            writer.Write(temp.StockUnitPriceFl);
            //�ύX�O�d���P���i�����j
            writer.Write(temp.BfStockUnitPriceFl);
            //�d���P���ύX�t���O
            writer.Write(temp.StkUnitPriceChgFlg);
            //�݌ɋ敪
            writer.Write(temp.StockDiv);
            //�ŏI�d���N����
            writer.Write((Int64)temp.LastStockDate.Ticks);
            //�݌ɑ���
            writer.Write(temp.StockTotal);
            //�o�א擾�Ӑ�R�[�h
            writer.Write(temp.ShipCustomerCode);
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
            //�I����
            writer.Write((Int64)temp.InventoryDate.Ticks);
            //�݌ɑ����i���{���j
            writer.Write(temp.StockTotalExec);
            //�ߕs���X�V�敪
            writer.Write(temp.ToleranceUpdateCd);
            //�����p�v�Z����
            writer.Write(temp.AdjstCalcCost);
            // --- ADD 2009/11/30 ---------->>>>>
            //�ړ����d���݌ɐ�
            writer.Write(temp.MovingSupliStock);
            //�o�א��i���v��j
            writer.Write(temp.ShipmentCnt);
            //���א��i���v��j
            writer.Write(temp.ArrivalCnt);
            // --- ADD 2009/11/30 ----------<<<<<
            //-----ADD 2011/01/11 ----->>>>>
            //�艿�i�����j
            writer.Write(temp.ListPriceFl);
            //�����O�̏��i�ԍ�
            writer.Write(temp.GoodsNoSrc);
            //���i����
            writer.Write(temp.GoodsName);
            //-----ADD 2011/01/11 -----<<<<<
            //-----ADD 2012/06/08 ----->>>>>
            //�J�n�Ǘ����_�R�[�h
            writer.Write(temp.SectionCodeSt);
            //�I���Ǘ����_�R�[�h
            writer.Write(temp.SectionCodeEd);
            //-----ADD 2012/06/08 -----<<<<<
        }

        /// <summary>
        ///  InventoryDataWork�C���X�^���X�擾
        /// </summary>
        /// <returns>InventoryDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InventoryDataWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private InventoryDataWork GetInventoryDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            InventoryDataWork temp = new InventoryDataWork();

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
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //�I���ʔ�
            temp.InventorySeqNo = reader.ReadInt32();
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //�q�ɒI��
            temp.WarehouseShelfNo = reader.ReadString();
            //�d���I�ԂP
            temp.DuplicationShelfNo1 = reader.ReadString();
            //�d���I�ԂQ
            temp.DuplicationShelfNo2 = reader.ReadString();
            //���i�啪�ރR�[�h
            temp.GoodsLGroup = reader.ReadInt32();
            //���i�����ރR�[�h
            temp.GoodsMGroup = reader.ReadInt32();
            //BL�O���[�v�R�[�h
            temp.BLGroupCode = reader.ReadInt32();
            //���Е��ރR�[�h
            temp.EnterpriseGanreCode = reader.ReadInt32();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //JAN�R�[�h
            temp.Jan = reader.ReadString();
            //�d���P��(����)
            temp.StockUnitPriceFl = reader.ReadDouble();
            //�ύX�O�d���P���i�����j
            temp.BfStockUnitPriceFl = reader.ReadDouble();
            //�d���P���ύX�t���O
            temp.StkUnitPriceChgFlg = reader.ReadInt32();
            //�݌ɋ敪
            temp.StockDiv = reader.ReadInt32();
            //�ŏI�d���N����
            temp.LastStockDate = new DateTime(reader.ReadInt64());
            //�݌ɑ���
            temp.StockTotal = reader.ReadDouble();
            //�o�א擾�Ӑ�R�[�h
            temp.ShipCustomerCode = reader.ReadInt32();
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
            //�I����
            temp.InventoryDate = new DateTime(reader.ReadInt64());
            //�݌ɑ����i���{���j
            temp.StockTotalExec = reader.ReadDouble();
            //�ߕs���X�V�敪
            temp.ToleranceUpdateCd = reader.ReadInt32();
            //�����p�v�Z����
            temp.AdjstCalcCost = reader.ReadDouble();
            // --- ADD 2009/11/30 ---------->>>>>
            //�ړ����d���݌ɐ�
            temp.MovingSupliStock = reader.ReadDouble();
            //�o�א��i���v��j
            temp.ShipmentCnt = reader.ReadDouble();
            //���א��i���v��j
            temp.ArrivalCnt = reader.ReadDouble();
            // --- ADD 2009/11/30 ----------<<<<<
            //-----ADD 2011/01/11 ----->>>>>
            //�艿�i�����j
            temp.ListPriceFl = reader.ReadDouble();
            //���i�ԍ�
            temp.GoodsNoSrc = reader.ReadString();
            //���i����
            temp.GoodsName = reader.ReadString();
            //-----ADD 2011/01/11 -----<<<<<
            //-----ADD 2012/06/08 ----->>>>>
            //�J�n�Ǘ����_�R�[�h
            temp.SectionCodeSt = reader.ReadString();
            //�I���Ǘ����_�R�[�h
            temp.SectionCodeEd = reader.ReadString(); 
            //-----ADD 2012/06/08 -----<<<<<

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
        /// <returns>InventoryDataWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InventoryDataWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                InventoryDataWork temp = GetInventoryDataWork(reader, serInfo);
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
                    retValue = (InventoryDataWork[])lst.ToArray(typeof(InventoryDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
