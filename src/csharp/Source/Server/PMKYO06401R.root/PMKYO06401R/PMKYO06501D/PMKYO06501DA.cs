//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   �}�X�^����M���o�E�X�VDB����N���X              //
//                  :   PMKYO06501D.DLL                                 //
// Name Space       :   Broadleaf.Application.Remoting.ParamData        //
// Programmer       :   ������                                          //
// Date             :   2009.04.29                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   DCStockWork
    /// <summary>
    ///                      �݌Ƀ��[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �݌Ƀ��[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/19</br>
    /// <br>Genarated Date   :   2009/04/29  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/7/8  ����</br>
    /// <br>                 :   �o�׉\���̕⑫�C��</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class DCStockWork : IFileHeader
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

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>�d���P���i�Ŕ�,�����j</summary>
        /// <remarks>���݌ɕ]���P��</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>�d���݌ɐ�</summary>
        /// <remarks>��������܂܂Ȃ��݌ɐ��i���Ѝ݌Ɂj</remarks>
        private Double _supplierStock;

        /// <summary>�󒍐�</summary>
        private Double _acpOdrCount;

        /// <summary>M/O������</summary>
        private Double _monthOrderCount;

        /// <summary>������</summary>
        private Double _salesOrderCount;

        /// <summary>�݌ɋ敪</summary>
        /// <remarks>0:����,1:���</remarks>
        private Int32 _stockDiv;

        /// <summary>�ړ����d���݌ɐ�</summary>
        /// <remarks>�݌Ɉړ���A���ړ��悪���ׂ���O�܂ł̊ԂɗL���l������B</remarks>
        private Double _movingSupliStock;

        /// <summary>�o�׉\��</summary>
        /// <remarks>�o�׉\�����d���݌ɐ� �{ ���א��i���v��j�| �o�א��i���v��j�|�󒍐� �| �ړ����d���݌ɐ�</remarks>
        private Double _shipmentPosCnt;

        /// <summary>�݌ɕۗL���z</summary>
        /// <remarks>�l���܂�</remarks>
        private Int64 _stockTotalPrice;

        /// <summary>�ŏI�d���N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _lastStockDate;

        /// <summary>�ŏI�����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _lastSalesDate;

        /// <summary>�ŏI�I���X�V��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _lastInventoryUpdate;

        /// <summary>�Œ�݌ɐ�</summary>
        private Double _minimumStockCnt;

        /// <summary>�ō��݌ɐ�</summary>
        private Double _maximumStockCnt;

        /// <summary>�������</summary>
        private Double _nmlSalOdrCount;

        /// <summary>�����P��</summary>
        /// <remarks>��������P�ʂ̐��ʁi�P�O�A�Q�O�P�ʓ��j</remarks>
        private Int32 _salesOrderUnit;

        /// <summary>�݌ɔ�����R�[�h</summary>
        /// <remarks>�݌ɔ�������ꍇ�̔�����i���i�̔�����Ƃ͕ʊǗ��j</remarks>
        private Int32 _stockSupplierCode;

        /// <summary>�n�C�t�������i�ԍ�</summary>
        private string _goodsNoNoneHyphen = "";

        /// <summary>�q�ɒI��</summary>
        private string _warehouseShelfNo = "";

        /// <summary>�d���I�ԂP</summary>
        private string _duplicationShelfNo1 = "";

        /// <summary>�d���I�ԂQ</summary>
        private string _duplicationShelfNo2 = "";

        /// <summary>���i�Ǘ��敪�P</summary>
        private string _partsManagementDivide1 = "";

        /// <summary>���i�Ǘ��敪�Q</summary>
        private string _partsManagementDivide2 = "";

        /// <summary>�݌ɔ��l�P</summary>
        /// <remarks>�����̎d�����킩����e��ݒ肷��@��j�ԗ��d���ł���ΎԎ햼�@</remarks>
        private string _stockNote1 = "";

        /// <summary>�݌ɔ��l�Q</summary>
        private string _stockNote2 = "";

        /// <summary>�o�א��i���v��j</summary>
        /// <remarks>�ݏo�A�o�ׂƓ���</remarks>
        private Double _shipmentCnt;

        /// <summary>���א��i���v��j</summary>
        /// <remarks>����</remarks>
        private Double _arrivalCnt;

        /// <summary>�݌ɓo�^��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _stockCreateDate;

        /// <summary>�X�V�N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _updateDate;


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

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>�d���P���i�Ŕ�,�����j�v���p�e�B</summary>
        /// <value>���݌ɕ]���P��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���i�Ŕ�,�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  SupplierStock
        /// <summary>�d���݌ɐ��v���p�e�B</summary>
        /// <value>��������܂܂Ȃ��݌ɐ��i���Ѝ݌Ɂj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SupplierStock
        {
            get { return _supplierStock; }
            set { _supplierStock = value; }
        }

        /// public propaty name  :  AcpOdrCount
        /// <summary>�󒍐��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍐��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AcpOdrCount
        {
            get { return _acpOdrCount; }
            set { _acpOdrCount = value; }
        }

        /// public propaty name  :  MonthOrderCount
        /// <summary>M/O�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   M/O�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MonthOrderCount
        {
            get { return _monthOrderCount; }
            set { _monthOrderCount = value; }
        }

        /// public propaty name  :  SalesOrderCount
        /// <summary>�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesOrderCount
        {
            get { return _salesOrderCount; }
            set { _salesOrderCount = value; }
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

        /// public propaty name  :  MovingSupliStock
        /// <summary>�ړ����d���݌ɐ��v���p�e�B</summary>
        /// <value>�݌Ɉړ���A���ړ��悪���ׂ���O�܂ł̊ԂɗL���l������B</value>
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

        /// public propaty name  :  ShipmentPosCnt
        /// <summary>�o�׉\���v���p�e�B</summary>
        /// <value>�o�׉\�����d���݌ɐ� �{ ���א��i���v��j�| �o�א��i���v��j�|�󒍐� �| �ړ����d���݌ɐ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�׉\���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentPosCnt
        {
            get { return _shipmentPosCnt; }
            set { _shipmentPosCnt = value; }
        }

        /// public propaty name  :  StockTotalPrice
        /// <summary>�݌ɕۗL���z�v���p�e�B</summary>
        /// <value>�l���܂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɕۗL���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTotalPrice
        {
            get { return _stockTotalPrice; }
            set { _stockTotalPrice = value; }
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

        /// public propaty name  :  LastSalesDate
        /// <summary>�ŏI������v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime LastSalesDate
        {
            get { return _lastSalesDate; }
            set { _lastSalesDate = value; }
        }

        /// public propaty name  :  LastInventoryUpdate
        /// <summary>�ŏI�I���X�V���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
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

        /// public propaty name  :  MinimumStockCnt
        /// <summary>�Œ�݌ɐ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Œ�݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MinimumStockCnt
        {
            get { return _minimumStockCnt; }
            set { _minimumStockCnt = value; }
        }

        /// public propaty name  :  MaximumStockCnt
        /// <summary>�ō��݌ɐ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ō��݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MaximumStockCnt
        {
            get { return _maximumStockCnt; }
            set { _maximumStockCnt = value; }
        }

        /// public propaty name  :  NmlSalOdrCount
        /// <summary>��������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double NmlSalOdrCount
        {
            get { return _nmlSalOdrCount; }
            set { _nmlSalOdrCount = value; }
        }

        /// public propaty name  :  SalesOrderUnit
        /// <summary>�����P�ʃv���p�e�B</summary>
        /// <value>��������P�ʂ̐��ʁi�P�O�A�Q�O�P�ʓ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����P�ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesOrderUnit
        {
            get { return _salesOrderUnit; }
            set { _salesOrderUnit = value; }
        }

        /// public propaty name  :  StockSupplierCode
        /// <summary>�݌ɔ�����R�[�h�v���p�e�B</summary>
        /// <value>�݌ɔ�������ꍇ�̔�����i���i�̔�����Ƃ͕ʊǗ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɔ�����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockSupplierCode
        {
            get { return _stockSupplierCode; }
            set { _stockSupplierCode = value; }
        }

        /// public propaty name  :  GoodsNoNoneHyphen
        /// <summary>�n�C�t�������i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n�C�t�������i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoNoneHyphen
        {
            get { return _goodsNoNoneHyphen; }
            set { _goodsNoNoneHyphen = value; }
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

        /// public propaty name  :  PartsManagementDivide1
        /// <summary>���i�Ǘ��敪�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�Ǘ��敪�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartsManagementDivide1
        {
            get { return _partsManagementDivide1; }
            set { _partsManagementDivide1 = value; }
        }

        /// public propaty name  :  PartsManagementDivide2
        /// <summary>���i�Ǘ��敪�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�Ǘ��敪�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartsManagementDivide2
        {
            get { return _partsManagementDivide2; }
            set { _partsManagementDivide2 = value; }
        }

        /// public propaty name  :  StockNote1
        /// <summary>�݌ɔ��l�P�v���p�e�B</summary>
        /// <value>�����̎d�����킩����e��ݒ肷��@��j�ԗ��d���ł���ΎԎ햼�@</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɔ��l�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockNote1
        {
            get { return _stockNote1; }
            set { _stockNote1 = value; }
        }

        /// public propaty name  :  StockNote2
        /// <summary>�݌ɔ��l�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɔ��l�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockNote2
        {
            get { return _stockNote2; }
            set { _stockNote2 = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>�o�א��i���v��j�v���p�e�B</summary>
        /// <value>�ݏo�A�o�ׂƓ���</value>
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
        /// <value>����</value>
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

        /// public propaty name  :  StockCreateDate
        /// <summary>�݌ɓo�^���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɓo�^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StockCreateDate
        {
            get { return _stockCreateDate; }
            set { _stockCreateDate = value; }
        }

        /// public propaty name  :  UpdateDate
        /// <summary>�X�V�N�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }


        /// <summary>
        /// �݌Ƀ��[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DCStockWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>StockWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   StockWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class DCStockWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is DCStockWork || graph is ArrayList || graph is DCStockWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(DCStockWork).FullName));

            if (graph != null && graph is DCStockWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is DCStockWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((DCStockWork[])graph).Length;
            }
            else if (graph is DCStockWork)
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
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //�d���P���i�Ŕ�,�����j
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //�d���݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //SupplierStock
            //�󒍐�
            serInfo.MemberInfo.Add(typeof(Double)); //AcpOdrCount
            //M/O������
            serInfo.MemberInfo.Add(typeof(Double)); //MonthOrderCount
            //������
            serInfo.MemberInfo.Add(typeof(Double)); //SalesOrderCount
            //�݌ɋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDiv
            //�ړ����d���݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //MovingSupliStock
            //�o�׉\��
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentPosCnt
            //�݌ɕۗL���z
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalPrice
            //�ŏI�d���N����
            serInfo.MemberInfo.Add(typeof(Int32)); //LastStockDate
            //�ŏI�����
            serInfo.MemberInfo.Add(typeof(Int32)); //LastSalesDate
            //�ŏI�I���X�V��
            serInfo.MemberInfo.Add(typeof(Int32)); //LastInventoryUpdate
            //�Œ�݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //MinimumStockCnt
            //�ō��݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //MaximumStockCnt
            //�������
            serInfo.MemberInfo.Add(typeof(Double)); //NmlSalOdrCount
            //�����P��
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesOrderUnit
            //�݌ɔ�����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSupplierCode
            //�n�C�t�������i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNoNoneHyphen
            //�q�ɒI��
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //�d���I�ԂP
            serInfo.MemberInfo.Add(typeof(string)); //DuplicationShelfNo1
            //�d���I�ԂQ
            serInfo.MemberInfo.Add(typeof(string)); //DuplicationShelfNo2
            //���i�Ǘ��敪�P
            serInfo.MemberInfo.Add(typeof(string)); //PartsManagementDivide1
            //���i�Ǘ��敪�Q
            serInfo.MemberInfo.Add(typeof(string)); //PartsManagementDivide2
            //�݌ɔ��l�P
            serInfo.MemberInfo.Add(typeof(string)); //StockNote1
            //�݌ɔ��l�Q
            serInfo.MemberInfo.Add(typeof(string)); //StockNote2
            //�o�א��i���v��j
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //���א��i���v��j
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt
            //�݌ɓo�^��
            serInfo.MemberInfo.Add(typeof(Int32)); //StockCreateDate
            //�X�V�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDate


            serInfo.Serialize(writer, serInfo);
            if (graph is DCStockWork)
            {
                DCStockWork temp = (DCStockWork)graph;

                SetStockWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is DCStockWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((DCStockWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (DCStockWork temp in lst)
                {
                    SetStockWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 41;

        /// <summary>
        ///  StockWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetStockWork(System.IO.BinaryWriter writer, DCStockWork temp)
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
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //�d���P���i�Ŕ�,�����j
            writer.Write(temp.StockUnitPriceFl);
            //�d���݌ɐ�
            writer.Write(temp.SupplierStock);
            //�󒍐�
            writer.Write(temp.AcpOdrCount);
            //M/O������
            writer.Write(temp.MonthOrderCount);
            //������
            writer.Write(temp.SalesOrderCount);
            //�݌ɋ敪
            writer.Write(temp.StockDiv);
            //�ړ����d���݌ɐ�
            writer.Write(temp.MovingSupliStock);
            //�o�׉\��
            writer.Write(temp.ShipmentPosCnt);
            //�݌ɕۗL���z
            writer.Write(temp.StockTotalPrice);
            //�ŏI�d���N����
            writer.Write((Int64)temp.LastStockDate.Ticks);
            //�ŏI�����
            writer.Write((Int64)temp.LastSalesDate.Ticks);
            //�ŏI�I���X�V��
            writer.Write((Int64)temp.LastInventoryUpdate.Ticks);
            //�Œ�݌ɐ�
            writer.Write(temp.MinimumStockCnt);
            //�ō��݌ɐ�
            writer.Write(temp.MaximumStockCnt);
            //�������
            writer.Write(temp.NmlSalOdrCount);
            //�����P��
            writer.Write(temp.SalesOrderUnit);
            //�݌ɔ�����R�[�h
            writer.Write(temp.StockSupplierCode);
            //�n�C�t�������i�ԍ�
            writer.Write(temp.GoodsNoNoneHyphen);
            //�q�ɒI��
            writer.Write(temp.WarehouseShelfNo);
            //�d���I�ԂP
            writer.Write(temp.DuplicationShelfNo1);
            //�d���I�ԂQ
            writer.Write(temp.DuplicationShelfNo2);
            //���i�Ǘ��敪�P
            writer.Write(temp.PartsManagementDivide1);
            //���i�Ǘ��敪�Q
            writer.Write(temp.PartsManagementDivide2);
            //�݌ɔ��l�P
            writer.Write(temp.StockNote1);
            //�݌ɔ��l�Q
            writer.Write(temp.StockNote2);
            //�o�א��i���v��j
            writer.Write(temp.ShipmentCnt);
            //���א��i���v��j
            writer.Write(temp.ArrivalCnt);
            //�݌ɓo�^��
            writer.Write((Int64)temp.StockCreateDate.Ticks);
            //�X�V�N����
            writer.Write((Int64)temp.UpdateDate.Ticks);

        }

        /// <summary>
        ///  StockWork�C���X�^���X�擾
        /// </summary>
        /// <returns>StockWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private DCStockWork GetStockWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            DCStockWork temp = new DCStockWork();

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
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //�d���P���i�Ŕ�,�����j
            temp.StockUnitPriceFl = reader.ReadDouble();
            //�d���݌ɐ�
            temp.SupplierStock = reader.ReadDouble();
            //�󒍐�
            temp.AcpOdrCount = reader.ReadDouble();
            //M/O������
            temp.MonthOrderCount = reader.ReadDouble();
            //������
            temp.SalesOrderCount = reader.ReadDouble();
            //�݌ɋ敪
            temp.StockDiv = reader.ReadInt32();
            //�ړ����d���݌ɐ�
            temp.MovingSupliStock = reader.ReadDouble();
            //�o�׉\��
            temp.ShipmentPosCnt = reader.ReadDouble();
            //�݌ɕۗL���z
            temp.StockTotalPrice = reader.ReadInt64();
            //�ŏI�d���N����
            temp.LastStockDate = new DateTime(reader.ReadInt64());
            //�ŏI�����
            temp.LastSalesDate = new DateTime(reader.ReadInt64());
            //�ŏI�I���X�V��
            temp.LastInventoryUpdate = new DateTime(reader.ReadInt64());
            //�Œ�݌ɐ�
            temp.MinimumStockCnt = reader.ReadDouble();
            //�ō��݌ɐ�
            temp.MaximumStockCnt = reader.ReadDouble();
            //�������
            temp.NmlSalOdrCount = reader.ReadDouble();
            //�����P��
            temp.SalesOrderUnit = reader.ReadInt32();
            //�݌ɔ�����R�[�h
            temp.StockSupplierCode = reader.ReadInt32();
            //�n�C�t�������i�ԍ�
            temp.GoodsNoNoneHyphen = reader.ReadString();
            //�q�ɒI��
            temp.WarehouseShelfNo = reader.ReadString();
            //�d���I�ԂP
            temp.DuplicationShelfNo1 = reader.ReadString();
            //�d���I�ԂQ
            temp.DuplicationShelfNo2 = reader.ReadString();
            //���i�Ǘ��敪�P
            temp.PartsManagementDivide1 = reader.ReadString();
            //���i�Ǘ��敪�Q
            temp.PartsManagementDivide2 = reader.ReadString();
            //�݌ɔ��l�P
            temp.StockNote1 = reader.ReadString();
            //�݌ɔ��l�Q
            temp.StockNote2 = reader.ReadString();
            //�o�א��i���v��j
            temp.ShipmentCnt = reader.ReadDouble();
            //���א��i���v��j
            temp.ArrivalCnt = reader.ReadDouble();
            //�݌ɓo�^��
            temp.StockCreateDate = new DateTime(reader.ReadInt64());
            //�X�V�N����
            temp.UpdateDate = new DateTime(reader.ReadInt64());


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
        /// <returns>StockWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                DCStockWork temp = GetStockWork(reader, serInfo);
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
                    retValue = (DCStockWork[])lst.ToArray(typeof(DCStockWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
