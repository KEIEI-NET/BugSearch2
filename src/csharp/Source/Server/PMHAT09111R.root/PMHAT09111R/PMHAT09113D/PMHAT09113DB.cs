//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����_�ݒ菈��
// �v���O�����T�v   : �����_�ݒ菈�����[�N
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/04/28  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   OrderPointStSimulationWork
    /// <summary>
    ///                      �����_�ݒ菈�����[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����_�ݒ菈�����[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2009/04/09</br>
    /// <br>Genarated Date   :   2009/06/06  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/04/10  ����</br>
    /// <br>                 :   ���t�@�C���ԍ��A�t�@�C���h�c�A</br>
    /// <br>                 :   �@���ڂh�c�̍X�V</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class OrderPointStSimulationWork : IFileHeader
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

        /// <summary>���_����</summary>
        private string _sectionName = "";

        /// <summary>�p�^�[���ԍ�</summary>
        private Int32 _patterNo;

        /// <summary>�p�^�[���ԍ��}��</summary>
        /// <remarks>�ő�20�܂ŘA��</remarks>
        private Int32 _patternNoDerivedNo;

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        /// <summary>�q�ɖ���</summary>
        private string _warehouseName = "";

        /// <summary>�q�ɒI��</summary>
        private string _warehouseShelfNo = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���於��</summary>
        private string _supplierNm = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���i���[�J�[����</summary>
        private string _goodsMakerNm = "";

        /// <summary>���i�����ރR�[�h</summary>
        private Int32 _goodsMGroup;

        /// <summary>BL�O���[�v�R�[�h</summary>
        private Int32 _bLGroupCode;

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>�݌ɏo�בΏۊJ�n��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _stckShipMonthSt;

        /// <summary>�݌ɏo�בΏۏI����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _stckShipMonthEd;

        /// <summary>�����K�p�敪</summary>
        /// <remarks>0:����,1:���v</remarks>
        private Int32 _orderApplyDiv;

        /// <summary>�݌ɓo�^��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _stockCreateDate;

        /// <summary>�o�א��͈�(�ȏ�)</summary>
        private Double _shipScopeMore;

        /// <summary>�o�א��͈�(�ȉ�)</summary>
        private Double _shipScopeLess;

        /// <summary>�Œ�݌ɐ�</summary>
        private Double _minimumStockCnt;

        /// <summary>�ō��݌ɐ�</summary>
        private Double _maximumStockCnt;

        /// <summary>�����P��</summary>
        /// <remarks>�������b�g</remarks>
        private Int32 _salesOrderUnit;

        /// <summary>�����_�����X�V�t���O</summary>
        /// <remarks>0:���X�V,1:�X�V��</remarks>
        private Int32 _orderPProcUpdFlg;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>�W�v���@</summary>
        private string _sumMethod = "";

        /// <summary>�����i</summary>
        private Double _oldPrice;

        /// <summary>���݌�</summary>
        private Double _nowPrice;

        /// <summary>���݌ɋ��z</summary>
        private Double _nowStockPrice;

        /// <summary>�ύX�O�Œᐔ</summary>
        private Double _oldMinCnt;

        /// <summary>�ύX�O�ō���</summary>
        private Double _oldMaxCnt;

        /// <summary>�ύX��Œᐔ</summary>
        private Double _newMinCnt;

        /// <summary>�ύX��ō���</summary>
        private Double _newMaxCnt;

        /// <summary>�ύX�O�Œ���z</summary>
        private Double _oldMinPrice;

        /// <summary>�ύX�O�ō����z</summary>
        private Double _oldMaxPrice;

        /// <summary>�ύX��Œ���z</summary>
        private Double _newMinPrice;

        /// <summary>�ύX��ō����z</summary>
        private Double _newMaxPrice;


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

        /// public propaty name  :  SectionName
        /// <summary>���_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

        /// public propaty name  :  PatterNo
        /// <summary>�p�^�[���ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �p�^�[���ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PatterNo
        {
            get { return _patterNo; }
            set { _patterNo = value; }
        }

        /// public propaty name  :  PatternNoDerivedNo
        /// <summary>�p�^�[���ԍ��}�ԃv���p�e�B</summary>
        /// <value>�ő�20�܂ŘA��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �p�^�[���ԍ��}�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PatternNoDerivedNo
        {
            get { return _patternNoDerivedNo; }
            set { _patternNoDerivedNo = value; }
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

        /// public propaty name  :  SupplierNm
        /// <summary>�d���於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierNm
        {
            get { return _supplierNm; }
            set { _supplierNm = value; }
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

        /// public propaty name  :  GoodsMakerNm
        /// <summary>���i���[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsMakerNm
        {
            get { return _goodsMakerNm; }
            set { _goodsMakerNm = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>���i�����ރR�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  StckShipMonthSt
        /// <summary>�݌ɏo�בΏۊJ�n���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɏo�בΏۊJ�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StckShipMonthSt
        {
            get { return _stckShipMonthSt; }
            set { _stckShipMonthSt = value; }
        }

        /// public propaty name  :  StckShipMonthEd
        /// <summary>�݌ɏo�בΏۏI�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɏo�בΏۏI�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StckShipMonthEd
        {
            get { return _stckShipMonthEd; }
            set { _stckShipMonthEd = value; }
        }

        /// public propaty name  :  OrderApplyDiv
        /// <summary>�����K�p�敪�v���p�e�B</summary>
        /// <value>0:����,1:���v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����K�p�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OrderApplyDiv
        {
            get { return _orderApplyDiv; }
            set { _orderApplyDiv = value; }
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

        /// public propaty name  :  ShipScopeMore
        /// <summary>�o�א��͈�(�ȏ�)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א��͈�(�ȏ�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipScopeMore
        {
            get { return _shipScopeMore; }
            set { _shipScopeMore = value; }
        }

        /// public propaty name  :  ShipScopeLess
        /// <summary>�o�א��͈�(�ȉ�)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א��͈�(�ȉ�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipScopeLess
        {
            get { return _shipScopeLess; }
            set { _shipScopeLess = value; }
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

        /// public propaty name  :  SalesOrderUnit
        /// <summary>�����P�ʃv���p�e�B</summary>
        /// <value>�������b�g</value>
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

        /// public propaty name  :  OrderPProcUpdFlg
        /// <summary>�����_�����X�V�t���O�v���p�e�B</summary>
        /// <value>0:���X�V,1:�X�V��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����_�����X�V�t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OrderPProcUpdFlg
        {
            get { return _orderPProcUpdFlg; }
            set { _orderPProcUpdFlg = value; }
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

        /// public propaty name  :  SumMethod
        /// <summary>�W�v���@�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�v���@�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SumMethod
        {
            get { return _sumMethod; }
            set { _sumMethod = value; }
        }

        /// public propaty name  :  OldPrice
        /// <summary>�����i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double OldPrice
        {
            get { return _oldPrice; }
            set { _oldPrice = value; }
        }

        /// public propaty name  :  NowPrice
        /// <summary>���݌Ƀv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���݌Ƀv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double NowPrice
        {
            get { return _nowPrice; }
            set { _nowPrice = value; }
        }

        /// public propaty name  :  NowStockPrice
        /// <summary>���݌ɋ��z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���݌ɋ��z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double NowStockPrice
        {
            get { return _nowStockPrice; }
            set { _nowStockPrice = value; }
        }

        /// public propaty name  :  OldMinCnt
        /// <summary>�ύX�O�Œᐔ�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ύX�O�Œᐔ�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double OldMinCnt
        {
            get { return _oldMinCnt; }
            set { _oldMinCnt = value; }
        }

        /// public propaty name  :  OldMaxCnt
        /// <summary>�ύX�O�ō����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ύX�O�ō����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double OldMaxCnt
        {
            get { return _oldMaxCnt; }
            set { _oldMaxCnt = value; }
        }

        /// public propaty name  :  NewMinCnt
        /// <summary>�ύX��Œᐔ�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ύX��Œᐔ�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double NewMinCnt
        {
            get { return _newMinCnt; }
            set { _newMinCnt = value; }
        }

        /// public propaty name  :  NewMaxCnt
        /// <summary>�ύX��ō����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ύX��ō����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double NewMaxCnt
        {
            get { return _newMaxCnt; }
            set { _newMaxCnt = value; }
        }

        /// public propaty name  :  OldMinPrice
        /// <summary>�ύX�O�Œ���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ύX�O�Œ���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double OldMinPrice
        {
            get { return _oldMinPrice; }
            set { _oldMinPrice = value; }
        }

        /// public propaty name  :  OldMaxPrice
        /// <summary>�ύX�O�ō����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ύX�O�ō����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double OldMaxPrice
        {
            get { return _oldMaxPrice; }
            set { _oldMaxPrice = value; }
        }

        /// public propaty name  :  NewMinPrice
        /// <summary>�ύX��Œ���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ύX��Œ���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double NewMinPrice
        {
            get { return _newMinPrice; }
            set { _newMinPrice = value; }
        }

        /// public propaty name  :  NewMaxPrice
        /// <summary>�ύX��ō����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ύX��ō����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double NewMaxPrice
        {
            get { return _newMaxPrice; }
            set { _newMaxPrice = value; }
        }


        /// <summary>
        /// �����_�ݒ菈�����[�N�R���X�g���N�^
        /// </summary>
        /// <returns>OrderPointStSimulationWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OrderPointStSimulationWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OrderPointStSimulationWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>OrderPointStSimulationWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   OrderPointStSimulationWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class OrderPointStSimulationWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OrderPointStSimulationWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  OrderPointStSimulationWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is OrderPointStSimulationWork || graph is ArrayList || graph is OrderPointStSimulationWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(OrderPointStSimulationWork).FullName));

            if (graph != null && graph is OrderPointStSimulationWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.OrderPointStSimulationWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is OrderPointStSimulationWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((OrderPointStSimulationWork[])graph).Length;
            }
            else if (graph is OrderPointStSimulationWork)
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
            //���_����
            serInfo.MemberInfo.Add(typeof(string)); //SectionName
            //�p�^�[���ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //PatterNo
            //�p�^�[���ԍ��}��
            serInfo.MemberInfo.Add(typeof(Int32)); //PatternNoDerivedNo
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //�q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //�q�ɒI��
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���於��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���i���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMakerNm
            //���i�����ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //BL�O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //�݌ɏo�בΏۊJ�n��
            serInfo.MemberInfo.Add(typeof(Int32)); //StckShipMonthSt
            //�݌ɏo�בΏۏI����
            serInfo.MemberInfo.Add(typeof(Int32)); //StckShipMonthEd
            //�����K�p�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //OrderApplyDiv
            //�݌ɓo�^��
            serInfo.MemberInfo.Add(typeof(Int32)); //StockCreateDate
            //�o�א��͈�(�ȏ�)
            serInfo.MemberInfo.Add(typeof(Double)); //ShipScopeMore
            //�o�א��͈�(�ȉ�)
            serInfo.MemberInfo.Add(typeof(Double)); //ShipScopeLess
            //�Œ�݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //MinimumStockCnt
            //�ō��݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //MaximumStockCnt
            //�����P��
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesOrderUnit
            //�����_�����X�V�t���O
            serInfo.MemberInfo.Add(typeof(Int32)); //OrderPProcUpdFlg
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //�W�v���@
            serInfo.MemberInfo.Add(typeof(string)); //SumMethod
            //�����i
            serInfo.MemberInfo.Add(typeof(Double)); //OldPrice
            //���݌�
            serInfo.MemberInfo.Add(typeof(Double)); //NowPrice
            //���݌ɋ��z
            serInfo.MemberInfo.Add(typeof(Double)); //NowStockPrice
            //�ύX�O�Œᐔ
            serInfo.MemberInfo.Add(typeof(Double)); //OldMinCnt
            //�ύX�O�ō���
            serInfo.MemberInfo.Add(typeof(Double)); //OldMaxCnt
            //�ύX��Œᐔ
            serInfo.MemberInfo.Add(typeof(Double)); //NewMinCnt
            //�ύX��ō���
            serInfo.MemberInfo.Add(typeof(Double)); //NewMaxCnt
            //�ύX�O�Œ���z
            serInfo.MemberInfo.Add(typeof(Double)); //OldMinPrice
            //�ύX�O�ō����z
            serInfo.MemberInfo.Add(typeof(Double)); //OldMaxPrice
            //�ύX��Œ���z
            serInfo.MemberInfo.Add(typeof(Double)); //NewMinPrice
            //�ύX��ō����z
            serInfo.MemberInfo.Add(typeof(Double)); //NewMaxPrice


            serInfo.Serialize(writer, serInfo);
            if (graph is OrderPointStSimulationWork)
            {
                OrderPointStSimulationWork temp = (OrderPointStSimulationWork)graph;

                SetOrderPointStSimulationWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is OrderPointStSimulationWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((OrderPointStSimulationWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (OrderPointStSimulationWork temp in lst)
                {
                    SetOrderPointStSimulationWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// OrderPointStSimulationWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 46;

        /// <summary>
        ///  OrderPointStSimulationWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OrderPointStSimulationWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetOrderPointStSimulationWork(System.IO.BinaryWriter writer, OrderPointStSimulationWork temp)
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
            //���_����
            writer.Write(temp.SectionName);
            //�p�^�[���ԍ�
            writer.Write(temp.PatterNo);
            //�p�^�[���ԍ��}��
            writer.Write(temp.PatternNoDerivedNo);
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //�q�ɖ���
            writer.Write(temp.WarehouseName);
            //�q�ɒI��
            writer.Write(temp.WarehouseShelfNo);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���於��
            writer.Write(temp.SupplierNm);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���i���[�J�[����
            writer.Write(temp.GoodsMakerNm);
            //���i�����ރR�[�h
            writer.Write(temp.GoodsMGroup);
            //BL�O���[�v�R�[�h
            writer.Write(temp.BLGroupCode);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //�݌ɏo�בΏۊJ�n��
            writer.Write(temp.StckShipMonthSt);
            //�݌ɏo�בΏۏI����
            writer.Write(temp.StckShipMonthEd);
            //�����K�p�敪
            writer.Write(temp.OrderApplyDiv);
            //�݌ɓo�^��
            writer.Write((Int64)temp.StockCreateDate.Ticks);
            //�o�א��͈�(�ȏ�)
            writer.Write(temp.ShipScopeMore);
            //�o�א��͈�(�ȉ�)
            writer.Write(temp.ShipScopeLess);
            //�Œ�݌ɐ�
            writer.Write(temp.MinimumStockCnt);
            //�ō��݌ɐ�
            writer.Write(temp.MaximumStockCnt);
            //�����P��
            writer.Write(temp.SalesOrderUnit);
            //�����_�����X�V�t���O
            writer.Write(temp.OrderPProcUpdFlg);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i����
            writer.Write(temp.GoodsName);
            //�W�v���@
            writer.Write(temp.SumMethod);
            //�����i
            writer.Write(temp.OldPrice);
            //���݌�
            writer.Write(temp.NowPrice);
            //���݌ɋ��z
            writer.Write(temp.NowStockPrice);
            //�ύX�O�Œᐔ
            writer.Write(temp.OldMinCnt);
            //�ύX�O�ō���
            writer.Write(temp.OldMaxCnt);
            //�ύX��Œᐔ
            writer.Write(temp.NewMinCnt);
            //�ύX��ō���
            writer.Write(temp.NewMaxCnt);
            //�ύX�O�Œ���z
            writer.Write(temp.OldMinPrice);
            //�ύX�O�ō����z
            writer.Write(temp.OldMaxPrice);
            //�ύX��Œ���z
            writer.Write(temp.NewMinPrice);
            //�ύX��ō����z
            writer.Write(temp.NewMaxPrice);

        }

        /// <summary>
        ///  OrderPointStSimulationWork�C���X�^���X�擾
        /// </summary>
        /// <returns>OrderPointStSimulationWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OrderPointStSimulationWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private OrderPointStSimulationWork GetOrderPointStSimulationWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            OrderPointStSimulationWork temp = new OrderPointStSimulationWork();

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
            //���_����
            temp.SectionName = reader.ReadString();
            //�p�^�[���ԍ�
            temp.PatterNo = reader.ReadInt32();
            //�p�^�[���ԍ��}��
            temp.PatternNoDerivedNo = reader.ReadInt32();
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //�q�ɖ���
            temp.WarehouseName = reader.ReadString();
            //�q�ɒI��
            temp.WarehouseShelfNo = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���於��
            temp.SupplierNm = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���i���[�J�[����
            temp.GoodsMakerNm = reader.ReadString();
            //���i�����ރR�[�h
            temp.GoodsMGroup = reader.ReadInt32();
            //BL�O���[�v�R�[�h
            temp.BLGroupCode = reader.ReadInt32();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //�݌ɏo�בΏۊJ�n��
            temp.StckShipMonthSt = reader.ReadInt32();
            //�݌ɏo�בΏۏI����
            temp.StckShipMonthEd = reader.ReadInt32();
            //�����K�p�敪
            temp.OrderApplyDiv = reader.ReadInt32();
            //�݌ɓo�^��
            temp.StockCreateDate = new DateTime(reader.ReadInt64());
            //�o�א��͈�(�ȏ�)
            temp.ShipScopeMore = reader.ReadDouble();
            //�o�א��͈�(�ȉ�)
            temp.ShipScopeLess = reader.ReadDouble();
            //�Œ�݌ɐ�
            temp.MinimumStockCnt = reader.ReadDouble();
            //�ō��݌ɐ�
            temp.MaximumStockCnt = reader.ReadDouble();
            //�����P��
            temp.SalesOrderUnit = reader.ReadInt32();
            //�����_�����X�V�t���O
            temp.OrderPProcUpdFlg = reader.ReadInt32();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i����
            temp.GoodsName = reader.ReadString();
            //�W�v���@
            temp.SumMethod = reader.ReadString();
            //�����i
            temp.OldPrice = reader.ReadDouble();
            //���݌�
            temp.NowPrice = reader.ReadDouble();
            //���݌ɋ��z
            temp.NowStockPrice = reader.ReadDouble();
            //�ύX�O�Œᐔ
            temp.OldMinCnt = reader.ReadDouble();
            //�ύX�O�ō���
            temp.OldMaxCnt = reader.ReadDouble();
            //�ύX��Œᐔ
            temp.NewMinCnt = reader.ReadDouble();
            //�ύX��ō���
            temp.NewMaxCnt = reader.ReadDouble();
            //�ύX�O�Œ���z
            temp.OldMinPrice = reader.ReadDouble();
            //�ύX�O�ō����z
            temp.OldMaxPrice = reader.ReadDouble();
            //�ύX��Œ���z
            temp.NewMinPrice = reader.ReadDouble();
            //�ύX��ō����z
            temp.NewMaxPrice = reader.ReadDouble();


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
        /// <returns>OrderPointStSimulationWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OrderPointStSimulationWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                OrderPointStSimulationWork temp = GetOrderPointStSimulationWork(reader, serInfo);
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
                    retValue = (OrderPointStSimulationWork[])lst.ToArray(typeof(OrderPointStSimulationWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
