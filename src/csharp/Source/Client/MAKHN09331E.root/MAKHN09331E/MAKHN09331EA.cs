using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   Warehouse
    /// <summary>
    ///                      �q�Ƀ}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �q�Ƀ}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2006/12/22  (CSharp File Generated Date)</br>
    /// -----------------------------------------------------------------------------------
    /// <br>Update Note : �u���Ӑ�v�u��Ǒq�Ɂv�u�݌Ɉꊇ���}�[�N�v�ǉ��A�u�q�ɔ��l2�`5�v�폜</br>
    /// <br>Programmer	: 30414 �E�@�K�j</br>
    /// <br>Date		: 2008/06/04</br>
    /// -----------------------------------------------------------------------------------
    /// </remarks>
    public class Warehouse
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

        /// <summary>�q�ɖ���</summary>
        private string _warehouseName = "";

        /// <summary>�q�ɔ��l</summary>
        private string _warehouseNote1 = "";

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>�q�ɔ��l�Q</summary>
        private string _warehouseNote2 = "";

        /// <summary>�q�ɔ��l�R</summary>
        private string _warehouseNote3 = "";

        /// <summary>�q�ɔ��l�S</summary>
        private string _warehouseNote4 = "";

        /// <summary>�q�ɔ��l�T</summary>
        private string _warehouseNote5 = "";
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>��Ǒq�ɃR�[�h</summary>
        private string _mainMngWarehouseCd = "";

        /// <summary>�݌Ɉꊇ���}�[�N</summary>
        private string _stockBlnktRemark = "";
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

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

        /// public propaty name  :  WarehouseNote1
        /// <summary>�q�ɔ��l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɔ��l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseNote1
        {
            get { return _warehouseNote1; }
            set { _warehouseNote1 = value; }
        }

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  WarehouseNote2
        /// <summary>�q�ɔ��l�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɔ��l�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseNote2
        {
            get { return _warehouseNote2; }
            set { _warehouseNote2 = value; }
        }

        /// public propaty name  :  WarehouseNote3
        /// <summary>�q�ɔ��l�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɔ��l�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseNote3
        {
            get { return _warehouseNote3; }
            set { _warehouseNote3 = value; }
        }

        /// public propaty name  :  WarehouseNote4
        /// <summary>�q�ɔ��l�S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɔ��l�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseNote4
        {
            get { return _warehouseNote4; }
            set { _warehouseNote4 = value; }
        }

        /// public propaty name  :  WarehouseNote5
        /// <summary>�q�ɔ��l�T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɔ��l�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseNote5
        {
            get { return _warehouseNote5; }
            set { _warehouseNote5 = value; }
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

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

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// public property name  :  CustomerCode
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

        /// public property name  :  MainMngWarehouseCd
        /// <summary>��Ǒq�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��Ǒq�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MainMngWarehouseCd
        {
            get { return _mainMngWarehouseCd; }
            set { _mainMngWarehouseCd = value; }
        }

        /// public property name  :  StockBlnktRemark
        /// <summary>�݌Ɉꊇ���}�[�N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɉꊇ���}�[�N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockBlnktRemark
        {
            get { return _stockBlnktRemark; }
            set { _stockBlnktRemark = value; }
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        /// <summary>
        /// �q�Ƀ}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>Warehouse�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Warehouse�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Warehouse()
        {
        }

        /// <summary>
        /// �q�Ƀ}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <param name="warehouseName">�q�ɖ���</param>
        /// <param name="warehouseNote1">�q�ɔ��l</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="mainMngWarehouseCd">��Ǒq�ɃR�[�h</param>
        /// <param name="stockBlnktRemark">�݌Ɉꊇ���}�[�N</param>
        /// <returns>Warehouse�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Warehouse�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        public Warehouse(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, string warehouseCode, string warehouseName, string warehouseNote1, string warehouseNote2, string warehouseNote3, string warehouseNote4, string warehouseNote5, string enterpriseName, string updEmployeeName)
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        public Warehouse(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, string warehouseCode, string warehouseName, string warehouseNote1, string enterpriseName, string updEmployeeName, int customerCode, string mainMngWarehouseCd, string stockBlnktRemark)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._sectionCode = sectionCode;
            this._warehouseCode = warehouseCode;
            this._warehouseName = warehouseName;
            this._warehouseNote1 = warehouseNote1;
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this._warehouseNote2 = warehouseNote2;
            this._warehouseNote3 = warehouseNote3;
            this._warehouseNote4 = warehouseNote4;
            this._warehouseNote5 = warehouseNote5;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            this._customerCode = customerCode;
            this._mainMngWarehouseCd = mainMngWarehouseCd;
            this._stockBlnktRemark = stockBlnktRemark;
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// �q�Ƀ}�X�^��������
        /// </summary>
        /// <returns>Warehouse�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����Warehouse�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Warehouse Clone()
        {
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            return new Warehouse(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._warehouseCode, this._warehouseName, this._warehouseNote1, this._warehouseNote2, this._warehouseNote3, this._warehouseNote4, this._warehouseNote5, this._enterpriseName, this._updEmployeeName);
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            return new Warehouse(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._warehouseCode, this._warehouseName, this._warehouseNote1, this._enterpriseName, this._updEmployeeName, this._customerCode, this._mainMngWarehouseCd, this._stockBlnktRemark);
        }

        /// <summary>
        /// �q�Ƀ}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�Warehouse�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Warehouse�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(Warehouse target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.WarehouseCode == target.WarehouseCode)
                 && (this.WarehouseName == target.WarehouseName)
                 && (this.WarehouseNote1 == target.WarehouseNote1)
                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                && (this.WarehouseNote2 == target.WarehouseNote2)
                && (this.WarehouseNote3 == target.WarehouseNote3)
                && (this.WarehouseNote4 == target.WarehouseNote4)
                && (this.WarehouseNote5 == target.WarehouseNote5)
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
                 && (this.EnterpriseName == target.EnterpriseName)

                 // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.MainMngWarehouseCd == target.MainMngWarehouseCd)
                 && (this.StockBlnktRemark == target.StockBlnktRemark)
                 // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// �q�Ƀ}�X�^��r����
        /// </summary>
        /// <param name="warehouse1">
        ///                    ��r����Warehouse�N���X�̃C���X�^���X
        /// </param>
        /// <param name="warehouse2">��r����Warehouse�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Warehouse�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(Warehouse warehouse1, Warehouse warehouse2)
        {
            return ((warehouse1.CreateDateTime == warehouse2.CreateDateTime)
                 && (warehouse1.UpdateDateTime == warehouse2.UpdateDateTime)
                 && (warehouse1.EnterpriseCode == warehouse2.EnterpriseCode)
                 && (warehouse1.FileHeaderGuid == warehouse2.FileHeaderGuid)
                 && (warehouse1.UpdEmployeeCode == warehouse2.UpdEmployeeCode)
                 && (warehouse1.UpdAssemblyId1 == warehouse2.UpdAssemblyId1)
                 && (warehouse1.UpdAssemblyId2 == warehouse2.UpdAssemblyId2)
                 && (warehouse1.LogicalDeleteCode == warehouse2.LogicalDeleteCode)
                 && (warehouse1.SectionCode == warehouse2.SectionCode)
                 && (warehouse1.WarehouseCode == warehouse2.WarehouseCode)
                 && (warehouse1.WarehouseName == warehouse2.WarehouseName)
                 && (warehouse1.WarehouseNote1 == warehouse2.WarehouseNote1)
                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                && (warehouse1.WarehouseNote2 == warehouse2.WarehouseNote2)
                && (warehouse1.WarehouseNote3 == warehouse2.WarehouseNote3)
                && (warehouse1.WarehouseNote4 == warehouse2.WarehouseNote4)
                && (warehouse1.WarehouseNote5 == warehouse2.WarehouseNote5)
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
                 && (warehouse1.EnterpriseName == warehouse2.EnterpriseName)

                 // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                 && (warehouse1.CustomerCode == warehouse2.CustomerCode)
                 && (warehouse1.MainMngWarehouseCd == warehouse2.MainMngWarehouseCd)
                 && (warehouse1.StockBlnktRemark == warehouse2.StockBlnktRemark)
                 // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

                 && (warehouse1.UpdEmployeeName == warehouse2.UpdEmployeeName));
        }
        /// <summary>
        /// �q�Ƀ}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�Warehouse�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Warehouse�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(Warehouse target)
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
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.WarehouseCode != target.WarehouseCode) resList.Add("WarehouseCode");
            if (this.WarehouseName != target.WarehouseName) resList.Add("WarehouseName");
            if (this.WarehouseNote1 != target.WarehouseNote1) resList.Add("WarehouseNote1");
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            if (this.WarehouseNote2 != target.WarehouseNote2) resList.Add("WarehouseNote2");
            if (this.WarehouseNote3 != target.WarehouseNote3) resList.Add("WarehouseNote3");
            if (this.WarehouseNote4 != target.WarehouseNote4) resList.Add("WarehouseNote4");
            if (this.WarehouseNote5 != target.WarehouseNote5) resList.Add("WarehouseNote5");
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.MainMngWarehouseCd != target.MainMngWarehouseCd) resList.Add("MainMngWarehouseCd");
            if (this.StockBlnktRemark != target.StockBlnktRemark) resList.Add("StockBlnktRemark");
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            return resList;
        }

        /// <summary>
        /// �q�Ƀ}�X�^��r����
        /// </summary>
        /// <param name="warehouse1">��r����Warehouse�N���X�̃C���X�^���X</param>
        /// <param name="warehouse2">��r����Warehouse�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Warehouse�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(Warehouse warehouse1, Warehouse warehouse2)
        {
            ArrayList resList = new ArrayList();
            if (warehouse1.CreateDateTime != warehouse2.CreateDateTime) resList.Add("CreateDateTime");
            if (warehouse1.UpdateDateTime != warehouse2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (warehouse1.EnterpriseCode != warehouse2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (warehouse1.FileHeaderGuid != warehouse2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (warehouse1.UpdEmployeeCode != warehouse2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (warehouse1.UpdAssemblyId1 != warehouse2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (warehouse1.UpdAssemblyId2 != warehouse2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (warehouse1.LogicalDeleteCode != warehouse2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (warehouse1.SectionCode != warehouse2.SectionCode) resList.Add("SectionCode");
            if (warehouse1.WarehouseCode != warehouse2.WarehouseCode) resList.Add("WarehouseCode");
            if (warehouse1.WarehouseName != warehouse2.WarehouseName) resList.Add("WarehouseName");
            if (warehouse1.WarehouseNote1 != warehouse2.WarehouseNote1) resList.Add("WarehouseNote1");
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            if (warehouse1.WarehouseNote2 != warehouse2.WarehouseNote2) resList.Add("WarehouseNote2");
            if (warehouse1.WarehouseNote3 != warehouse2.WarehouseNote3) resList.Add("WarehouseNote3");
            if (warehouse1.WarehouseNote4 != warehouse2.WarehouseNote4) resList.Add("WarehouseNote4");
            if (warehouse1.WarehouseNote5 != warehouse2.WarehouseNote5) resList.Add("WarehouseNote5");
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            if (warehouse1.EnterpriseName != warehouse2.EnterpriseName) resList.Add("EnterpriseName");
            if (warehouse1.UpdEmployeeName != warehouse2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            if (warehouse1.CustomerCode != warehouse2.CustomerCode) resList.Add("CustomerCode");
            if (warehouse1.MainMngWarehouseCd != warehouse2.MainMngWarehouseCd) resList.Add("MainMngWarehouseCd");
            if (warehouse1.StockBlnktRemark != warehouse2.StockBlnktRemark) resList.Add("StockBlnktRemark");
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            return resList;
        }
    }
}
