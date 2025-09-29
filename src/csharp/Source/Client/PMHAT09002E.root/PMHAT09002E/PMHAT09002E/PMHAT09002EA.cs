//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����_�ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : �����_�ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/03/31  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   OrderPointSt
    /// <summary>
    ///                      �����_�ݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����_�ݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2009/04/09</br>
    /// <br>Genarated Date   :   2009/04/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/04/10  ����</br>
    /// <br>                 :   ���t�@�C���ԍ��A�t�@�C���h�c�A</br>
    /// <br>                 :   �@���ڂh�c�̍X�V</br>
    /// </remarks>
    public class OrderPointSt
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

        /// <summary>�p�^�[���ԍ�</summary>
        private Int32 _patterNo;

        /// <summary>�p�^�[���ԍ��}��</summary>
        /// <remarks>�ő�20�܂ŘA��</remarks>
        private Int32 _patternNoDerivedNo;

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

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
        private Int32 _stockCreateDate;

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

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";


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
        public Int32 StockCreateDate
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


        /// <summary>
        /// �����_�ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>OrderPointSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OrderPointSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OrderPointSt()
        {
        }

        /// <summary>
        /// �����_�ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="patterNo">�p�^�[���ԍ�</param>
        /// <param name="patternNoDerivedNo">�p�^�[���ԍ��}��(�ő�20�܂ŘA��)</param>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="goodsMGroup">���i�����ރR�[�h</param>
        /// <param name="bLGroupCode">BL�O���[�v�R�[�h</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
        /// <param name="stckShipMonthSt">�݌ɏo�בΏۊJ�n��(YYYYMMDD)</param>
        /// <param name="stckShipMonthEd">�݌ɏo�בΏۏI����(YYYYMMDD)</param>
        /// <param name="orderApplyDiv">�����K�p�敪(0:����,1:���v)</param>
        /// <param name="stockCreateDate">�݌ɓo�^��(YYYYMMDD)</param>
        /// <param name="shipScopeMore">�o�א��͈�(�ȏ�)</param>
        /// <param name="shipScopeLess">�o�א��͈�(�ȉ�)</param>
        /// <param name="minimumStockCnt">�Œ�݌ɐ�</param>
        /// <param name="maximumStockCnt">�ō��݌ɐ�</param>
        /// <param name="salesOrderUnit">�����P��(�������b�g)</param>
        /// <param name="orderPProcUpdFlg">�����_�����X�V�t���O(0:���X�V,1:�X�V��)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <returns>OrderPointSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OrderPointSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OrderPointSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 patterNo, Int32 patternNoDerivedNo, string warehouseCode, Int32 supplierCd, Int32 goodsMakerCd, Int32 goodsMGroup, Int32 bLGroupCode, Int32 bLGoodsCode, Int32 stckShipMonthSt, Int32 stckShipMonthEd, Int32 orderApplyDiv, Int32 stockCreateDate, Double shipScopeMore, Double shipScopeLess, Double minimumStockCnt, Double maximumStockCnt, Int32 salesOrderUnit, Int32 orderPProcUpdFlg, string enterpriseName, string updEmployeeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._patterNo = patterNo;
            this._patternNoDerivedNo = patternNoDerivedNo;
            this._warehouseCode = warehouseCode;
            this._supplierCd = supplierCd;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsMGroup = goodsMGroup;
            this._bLGroupCode = bLGroupCode;
            this._bLGoodsCode = bLGoodsCode;
            this._stckShipMonthSt = stckShipMonthSt;
            this._stckShipMonthEd = stckShipMonthEd;
            this._orderApplyDiv = orderApplyDiv;
            this._stockCreateDate = stockCreateDate;
            this._shipScopeMore = shipScopeMore;
            this._shipScopeLess = shipScopeLess;
            this._minimumStockCnt = minimumStockCnt;
            this._maximumStockCnt = maximumStockCnt;
            this._salesOrderUnit = salesOrderUnit;
            this._orderPProcUpdFlg = orderPProcUpdFlg;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// �����_�ݒ�}�X�^��������
        /// </summary>
        /// <returns>OrderPointSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����OrderPointSt�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OrderPointSt Clone()
        {
            return new OrderPointSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._patterNo, this._patternNoDerivedNo, this._warehouseCode, this._supplierCd, this._goodsMakerCd, this._goodsMGroup, this._bLGroupCode, this._bLGoodsCode, this._stckShipMonthSt, this._stckShipMonthEd, this._orderApplyDiv, this._stockCreateDate, this._shipScopeMore, this._shipScopeLess, this._minimumStockCnt, this._maximumStockCnt, this._salesOrderUnit, this._orderPProcUpdFlg, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// �����_�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�OrderPointSt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OrderPointSt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(OrderPointSt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 //&& (this.PatterNo == target.PatterNo)
                 && (this.PatternNoDerivedNo == target.PatternNoDerivedNo)
                 && (this.WarehouseCode == target.WarehouseCode)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.GoodsMGroup == target.GoodsMGroup)
                 && (this.BLGroupCode == target.BLGroupCode)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.StckShipMonthSt == target.StckShipMonthSt)
                 && (this.StckShipMonthEd == target.StckShipMonthEd)
                 && (this.OrderApplyDiv == target.OrderApplyDiv)
                 && (this.StockCreateDate == target.StockCreateDate)
                 && (this.ShipScopeMore == target.ShipScopeMore)
                 && (this.ShipScopeLess == target.ShipScopeLess)
                 && (this.MinimumStockCnt == target.MinimumStockCnt)
                 && (this.MaximumStockCnt == target.MaximumStockCnt)
                 && (this.SalesOrderUnit == target.SalesOrderUnit)
                 && (this.OrderPProcUpdFlg == target.OrderPProcUpdFlg)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// �����_�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="orderPointSt1">
        ///                    ��r����OrderPointSt�N���X�̃C���X�^���X
        /// </param>
        /// <param name="orderPointSt2">��r����OrderPointSt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OrderPointSt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(OrderPointSt orderPointSt1, OrderPointSt orderPointSt2)
        {
            return ((orderPointSt1.CreateDateTime == orderPointSt2.CreateDateTime)
                 && (orderPointSt1.UpdateDateTime == orderPointSt2.UpdateDateTime)
                 && (orderPointSt1.EnterpriseCode == orderPointSt2.EnterpriseCode)
                 && (orderPointSt1.FileHeaderGuid == orderPointSt2.FileHeaderGuid)
                 && (orderPointSt1.UpdEmployeeCode == orderPointSt2.UpdEmployeeCode)
                 && (orderPointSt1.UpdAssemblyId1 == orderPointSt2.UpdAssemblyId1)
                 && (orderPointSt1.UpdAssemblyId2 == orderPointSt2.UpdAssemblyId2)
                 && (orderPointSt1.LogicalDeleteCode == orderPointSt2.LogicalDeleteCode)
                 //&& (orderPointSt1.PatterNo == orderPointSt2.PatterNo)
                 && (orderPointSt1.PatternNoDerivedNo == orderPointSt2.PatternNoDerivedNo)
                 && (orderPointSt1.WarehouseCode == orderPointSt2.WarehouseCode)
                 && (orderPointSt1.SupplierCd == orderPointSt2.SupplierCd)
                 && (orderPointSt1.GoodsMakerCd == orderPointSt2.GoodsMakerCd)
                 && (orderPointSt1.GoodsMGroup == orderPointSt2.GoodsMGroup)
                 && (orderPointSt1.BLGroupCode == orderPointSt2.BLGroupCode)
                 && (orderPointSt1.BLGoodsCode == orderPointSt2.BLGoodsCode)
                 && (orderPointSt1.StckShipMonthSt == orderPointSt2.StckShipMonthSt)
                 && (orderPointSt1.StckShipMonthEd == orderPointSt2.StckShipMonthEd)
                 && (orderPointSt1.OrderApplyDiv == orderPointSt2.OrderApplyDiv)
                 && (orderPointSt1.StockCreateDate == orderPointSt2.StockCreateDate)
                 && (orderPointSt1.ShipScopeMore == orderPointSt2.ShipScopeMore)
                 && (orderPointSt1.ShipScopeLess == orderPointSt2.ShipScopeLess)
                 && (orderPointSt1.MinimumStockCnt == orderPointSt2.MinimumStockCnt)
                 && (orderPointSt1.MaximumStockCnt == orderPointSt2.MaximumStockCnt)
                 && (orderPointSt1.SalesOrderUnit == orderPointSt2.SalesOrderUnit)
                 && (orderPointSt1.OrderPProcUpdFlg == orderPointSt2.OrderPProcUpdFlg)
                 && (orderPointSt1.EnterpriseName == orderPointSt2.EnterpriseName)
                 && (orderPointSt1.UpdEmployeeName == orderPointSt2.UpdEmployeeName));
        }
        /// <summary>
        /// �����_�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�OrderPointSt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OrderPointSt�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(OrderPointSt target)
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
            if (this.PatterNo != target.PatterNo) resList.Add("PatterNo");
            if (this.PatternNoDerivedNo != target.PatternNoDerivedNo) resList.Add("PatternNoDerivedNo");
            if (this.WarehouseCode != target.WarehouseCode) resList.Add("WarehouseCode");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsMGroup != target.GoodsMGroup) resList.Add("GoodsMGroup");
            if (this.BLGroupCode != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.StckShipMonthSt != target.StckShipMonthSt) resList.Add("StckShipMonthSt");
            if (this.StckShipMonthEd != target.StckShipMonthEd) resList.Add("StckShipMonthEd");
            if (this.OrderApplyDiv != target.OrderApplyDiv) resList.Add("OrderApplyDiv");
            if (this.StockCreateDate != target.StockCreateDate) resList.Add("StockCreateDate");
            if (this.ShipScopeMore != target.ShipScopeMore) resList.Add("ShipScopeMore");
            if (this.ShipScopeLess != target.ShipScopeLess) resList.Add("ShipScopeLess");
            if (this.MinimumStockCnt != target.MinimumStockCnt) resList.Add("MinimumStockCnt");
            if (this.MaximumStockCnt != target.MaximumStockCnt) resList.Add("MaximumStockCnt");
            if (this.SalesOrderUnit != target.SalesOrderUnit) resList.Add("SalesOrderUnit");
            if (this.OrderPProcUpdFlg != target.OrderPProcUpdFlg) resList.Add("OrderPProcUpdFlg");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// �����_�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="orderPointSt1">��r����OrderPointSt�N���X�̃C���X�^���X</param>
        /// <param name="orderPointSt2">��r����OrderPointSt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OrderPointSt�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(OrderPointSt orderPointSt1, OrderPointSt orderPointSt2)
        {
            ArrayList resList = new ArrayList();
            if (orderPointSt1.CreateDateTime != orderPointSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (orderPointSt1.UpdateDateTime != orderPointSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (orderPointSt1.EnterpriseCode != orderPointSt2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (orderPointSt1.FileHeaderGuid != orderPointSt2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (orderPointSt1.UpdEmployeeCode != orderPointSt2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (orderPointSt1.UpdAssemblyId1 != orderPointSt2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (orderPointSt1.UpdAssemblyId2 != orderPointSt2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (orderPointSt1.LogicalDeleteCode != orderPointSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (orderPointSt1.PatterNo != orderPointSt2.PatterNo) resList.Add("PatterNo");
            if (orderPointSt1.PatternNoDerivedNo != orderPointSt2.PatternNoDerivedNo) resList.Add("PatternNoDerivedNo");
            if (orderPointSt1.WarehouseCode != orderPointSt2.WarehouseCode) resList.Add("WarehouseCode");
            if (orderPointSt1.SupplierCd != orderPointSt2.SupplierCd) resList.Add("SupplierCd");
            if (orderPointSt1.GoodsMakerCd != orderPointSt2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (orderPointSt1.GoodsMGroup != orderPointSt2.GoodsMGroup) resList.Add("GoodsMGroup");
            if (orderPointSt1.BLGroupCode != orderPointSt2.BLGroupCode) resList.Add("BLGroupCode");
            if (orderPointSt1.BLGoodsCode != orderPointSt2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (orderPointSt1.StckShipMonthSt != orderPointSt2.StckShipMonthSt) resList.Add("StckShipMonthSt");
            if (orderPointSt1.StckShipMonthEd != orderPointSt2.StckShipMonthEd) resList.Add("StckShipMonthEd");
            if (orderPointSt1.OrderApplyDiv != orderPointSt2.OrderApplyDiv) resList.Add("OrderApplyDiv");
            if (orderPointSt1.StockCreateDate != orderPointSt2.StockCreateDate) resList.Add("StockCreateDate");
            if (orderPointSt1.ShipScopeMore != orderPointSt2.ShipScopeMore) resList.Add("ShipScopeMore");
            if (orderPointSt1.ShipScopeLess != orderPointSt2.ShipScopeLess) resList.Add("ShipScopeLess");
            if (orderPointSt1.MinimumStockCnt != orderPointSt2.MinimumStockCnt) resList.Add("MinimumStockCnt");
            if (orderPointSt1.MaximumStockCnt != orderPointSt2.MaximumStockCnt) resList.Add("MaximumStockCnt");
            if (orderPointSt1.SalesOrderUnit != orderPointSt2.SalesOrderUnit) resList.Add("SalesOrderUnit");
            if (orderPointSt1.OrderPProcUpdFlg != orderPointSt2.OrderPProcUpdFlg) resList.Add("OrderPProcUpdFlg");
            if (orderPointSt1.EnterpriseName != orderPointSt2.EnterpriseName) resList.Add("EnterpriseName");
            if (orderPointSt1.UpdEmployeeName != orderPointSt2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
