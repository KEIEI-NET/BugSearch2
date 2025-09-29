using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   InventDataPreWork
	/// <summary>
	///                      �I���f�[�^�i�������������j���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �I���f�[�^�i�������������j���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2007/4/2</br>
	/// <br>Genarated Date   :   2007/09/25  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class InventDataPreWork : IFileHeader
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
        /// <remarks>�����_���Z�b�g</remarks>
        private string _sectionCode = "";

        /// <summary>�I�������������t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _inventoryPreprDay;

        /// <summary>�I��������������</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _inventoryPreprTim;

        /// <summary>�I�������敪</summary>
        /// <remarks>���P</remarks>
        private Int32 _inventoryProcDiv;

        /// <summary>�q�ɃR�[�h�J�n</summary>
        private string _warehouseCodeSt = "";

        /// <summary>�q�ɃR�[�h�I��</summary>
        private string _warehouseCodeEd = "";

        // -------ADD 2011/01/30------->>>>>
        /// <summary>�Ǘ����_�J�n</summary>
        private string _mngSectionCodeSt = "";

        /// <summary>�Ǘ����_�I��</summary>
        private string _mngSectionCodeEd = "";
        // -------ADD 2011/01/30------->>>>>

        /// <summary>�I�ԊJ�n</summary>
        private string _shelfNoSt = "";

        /// <summary>�I�ԏI��</summary>
        private string _shelfNoEd = "";

        /// <summary>�d����R�[�h�J�n</summary>
        /// <remarks>���d����R�[�h�Ƃ��Ďg�p</remarks>
        private Int32 _startSupplierCode;

        /// <summary>�d����R�[�h�I��</summary>
        /// <remarks>���d����R�[�h�Ƃ��Ďg�p</remarks>
        private Int32 _endSupplierCode;

        /// <summary>�a�k���i�R�[�h�J�n</summary>
        private Int32 _bLGoodsCodeSt;

        /// <summary>�a�k���i�R�[�h�I��</summary>
        private Int32 _bLGoodsCodeEd;

        /// <summary>���i���[�J�[�R�[�h�J�n</summary>
        /// <remarks>�߯���ޖ���հ�ް�o�^�͈͂��قȂ�</remarks>
        private Int32 _goodsMakerCdSt;

        /// <summary>���i���[�J�[�R�[�h�I��</summary>
        /// <remarks>�߯���ޖ���հ�ް�o�^�͈͂��قȂ�</remarks>
        private Int32 _goodsMakerCdEd;

        /// <summary>BL�O���[�v�R�[�h�J�n</summary>
        private Int32 _bLGroupCodeSt;

        /// <summary>BL�O���[�v�R�[�h�I��</summary>
        private Int32 _bLGroupCodeEd;

        /// <summary>����݌ɒ��o�敪</summary>
        /// <remarks>0:���o����,1:���o���Ȃ�</remarks>
        private Int32 _trtStkExtraDiv;

        /// <summary>�ϑ��i���Ёj�݌ɒ��o�敪</summary>
        /// <remarks>0:���o����,1:���o���Ȃ�</remarks>
        private Int32 _entCmpStkExtraDiv;

        /// <summary>�ŏI�I���X�V���J�n</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ltInventoryUpdateSt;

        /// <summary>�ŏI�I���X�V���I��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ltInventoryUpdateEd;

        /// <summary>�I��q�ɃR�[�h�P</summary>
        private string _selWarehouseCode1 = "";

        /// <summary>�I��q�ɃR�[�h�Q</summary>
        private string _selWarehouseCode2 = "";

        /// <summary>�I��q�ɃR�[�h�R</summary>
        private string _selWarehouseCode3 = "";

        /// <summary>�I��q�ɃR�[�h�S</summary>
        private string _selWarehouseCode4 = "";

        /// <summary>�I��q�ɃR�[�h�T</summary>
        private string _selWarehouseCode5 = "";

        /// <summary>�I��q�ɃR�[�h�U</summary>
        private string _selWarehouseCode6 = "";

        /// <summary>�I��q�ɃR�[�h�V</summary>
        private string _selWarehouseCode7 = "";

        /// <summary>�I��q�ɃR�[�h�W</summary>
        private string _selWarehouseCode8 = "";

        /// <summary>�I��q�ɃR�[�h�X</summary>
        private string _selWarehouseCode9 = "";

        /// <summary>�I��q�ɃR�[�h�P�O</summary>
        private string _selWarehouseCode10 = "";

        /// <summary>�I�����{��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _inventoryDate;


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
        /// <value>�����_���Z�b�g</value>
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

        /// public propaty name  :  InventoryPreprDay
        /// <summary>�I�������������t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
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
        /// <value>HHMMSS</value>
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

        /// public propaty name  :  InventoryProcDiv
        /// <summary>�I�������敪�v���p�e�B</summary>
        /// <value>���P</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InventoryProcDiv
        {
            get { return _inventoryProcDiv; }
            set { _inventoryProcDiv = value; }
        }

        /// public propaty name  :  WarehouseCodeSt
        /// <summary>�q�ɃR�[�h�J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h�J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCodeSt
        {
            get { return _warehouseCodeSt; }
            set { _warehouseCodeSt = value; }
        }

        /// public propaty name  :  WarehouseCodeEd
        /// <summary>�q�ɃR�[�h�I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCodeEd
        {
            get { return _warehouseCodeEd; }
            set { _warehouseCodeEd = value; }
        }

        // -------ADD 2011/01/30------->>>>>
        /// public propaty name  :  MngSectionCodeSt
        /// <summary>�Ǘ����_�J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǘ����_�J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MngSectionCodeSt
        {
            get { return _mngSectionCodeSt; }
            set { _mngSectionCodeSt = value; }
        }

        /// public propaty name  :  MngSectionCodeEd
        /// <summary>�Ǘ����_�I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǘ����_�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MngSectionCodeEd
        {
            get { return _mngSectionCodeEd; }
            set { _mngSectionCodeEd = value; }
        }
        // -------ADD 2011/01/30------->>>>>

        /// public propaty name  :  ShelfNoSt
        /// <summary>�I�ԊJ�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�ԊJ�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShelfNoSt
        {
            get { return _shelfNoSt; }
            set { _shelfNoSt = value; }
        }

        /// public propaty name  :  ShelfNoEd
        /// <summary>�I�ԏI���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�ԏI���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShelfNoEd
        {
            get { return _shelfNoEd; }
            set { _shelfNoEd = value; }
        }

        /// public propaty name  :  StartSupplierCode
        /// <summary>�d����R�[�h�J�n�v���p�e�B</summary>
        /// <value>���d����R�[�h�Ƃ��Ďg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StartSupplierCode
        {
            get { return _startSupplierCode; }
            set { _startSupplierCode = value; }
        }

        /// public propaty name  :  EndSupplierCode
        /// <summary>�d����R�[�h�I���v���p�e�B</summary>
        /// <value>���d����R�[�h�Ƃ��Ďg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EndSupplierCode
        {
            get { return _endSupplierCode; }
            set { _endSupplierCode = value; }
        }

        /// public propaty name  :  BLGoodsCodeSt
        /// <summary>�a�k���i�R�[�h�J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �a�k���i�R�[�h�J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCodeSt
        {
            get { return _bLGoodsCodeSt; }
            set { _bLGoodsCodeSt = value; }
        }

        /// public propaty name  :  BLGoodsCodeEd
        /// <summary>�a�k���i�R�[�h�I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �a�k���i�R�[�h�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCodeEd
        {
            get { return _bLGoodsCodeEd; }
            set { _bLGoodsCodeEd = value; }
        }

        /// public propaty name  :  GoodsMakerCdSt
        /// <summary>���i���[�J�[�R�[�h�J�n�v���p�e�B</summary>
        /// <value>�߯���ޖ���հ�ް�o�^�͈͂��قȂ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCdSt
        {
            get { return _goodsMakerCdSt; }
            set { _goodsMakerCdSt = value; }
        }

        /// public propaty name  :  GoodsMakerCdEd
        /// <summary>���i���[�J�[�R�[�h�I���v���p�e�B</summary>
        /// <value>�߯���ޖ���հ�ް�o�^�͈͂��قȂ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCdEd
        {
            get { return _goodsMakerCdEd; }
            set { _goodsMakerCdEd = value; }
        }

        /// public propaty name  :  BLGroupCodeSt
        /// <summary>BL�O���[�v�R�[�h�J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h�J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGroupCodeSt
        {
            get { return _bLGroupCodeSt; }
            set { _bLGroupCodeSt = value; }
        }

        /// public propaty name  :  BLGroupCodeEd
        /// <summary>BL�O���[�v�R�[�h�I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGroupCodeEd
        {
            get { return _bLGroupCodeEd; }
            set { _bLGroupCodeEd = value; }
        }

        /// public propaty name  :  TrtStkExtraDiv
        /// <summary>����݌ɒ��o�敪�v���p�e�B</summary>
        /// <value>0:���o����,1:���o���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����݌ɒ��o�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TrtStkExtraDiv
        {
            get { return _trtStkExtraDiv; }
            set { _trtStkExtraDiv = value; }
        }

        /// public propaty name  :  EntCmpStkExtraDiv
        /// <summary>�ϑ��i���Ёj�݌ɒ��o�敪�v���p�e�B</summary>
        /// <value>0:���o����,1:���o���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϑ��i���Ёj�݌ɒ��o�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EntCmpStkExtraDiv
        {
            get { return _entCmpStkExtraDiv; }
            set { _entCmpStkExtraDiv = value; }
        }

        /// public propaty name  :  LtInventoryUpdateSt
        /// <summary>�ŏI�I���X�V���J�n�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI�I���X�V���J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime LtInventoryUpdateSt
        {
            get { return _ltInventoryUpdateSt; }
            set { _ltInventoryUpdateSt = value; }
        }

        /// public propaty name  :  LtInventoryUpdateEd
        /// <summary>�ŏI�I���X�V���I���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI�I���X�V���I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime LtInventoryUpdateEd
        {
            get { return _ltInventoryUpdateEd; }
            set { _ltInventoryUpdateEd = value; }
        }

        /// public propaty name  :  SelWarehouseCode1
        /// <summary>�I��q�ɃR�[�h�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��q�ɃR�[�h�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SelWarehouseCode1
        {
            get { return _selWarehouseCode1; }
            set { _selWarehouseCode1 = value; }
        }

        /// public propaty name  :  SelWarehouseCode2
        /// <summary>�I��q�ɃR�[�h�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��q�ɃR�[�h�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SelWarehouseCode2
        {
            get { return _selWarehouseCode2; }
            set { _selWarehouseCode2 = value; }
        }

        /// public propaty name  :  SelWarehouseCode3
        /// <summary>�I��q�ɃR�[�h�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��q�ɃR�[�h�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SelWarehouseCode3
        {
            get { return _selWarehouseCode3; }
            set { _selWarehouseCode3 = value; }
        }

        /// public propaty name  :  SelWarehouseCode4
        /// <summary>�I��q�ɃR�[�h�S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��q�ɃR�[�h�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SelWarehouseCode4
        {
            get { return _selWarehouseCode4; }
            set { _selWarehouseCode4 = value; }
        }

        /// public propaty name  :  SelWarehouseCode5
        /// <summary>�I��q�ɃR�[�h�T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��q�ɃR�[�h�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SelWarehouseCode5
        {
            get { return _selWarehouseCode5; }
            set { _selWarehouseCode5 = value; }
        }

        /// public propaty name  :  SelWarehouseCode6
        /// <summary>�I��q�ɃR�[�h�U�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��q�ɃR�[�h�U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SelWarehouseCode6
        {
            get { return _selWarehouseCode6; }
            set { _selWarehouseCode6 = value; }
        }

        /// public propaty name  :  SelWarehouseCode7
        /// <summary>�I��q�ɃR�[�h�V�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��q�ɃR�[�h�V�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SelWarehouseCode7
        {
            get { return _selWarehouseCode7; }
            set { _selWarehouseCode7 = value; }
        }

        /// public propaty name  :  SelWarehouseCode8
        /// <summary>�I��q�ɃR�[�h�W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��q�ɃR�[�h�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SelWarehouseCode8
        {
            get { return _selWarehouseCode8; }
            set { _selWarehouseCode8 = value; }
        }

        /// public propaty name  :  SelWarehouseCode9
        /// <summary>�I��q�ɃR�[�h�X�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��q�ɃR�[�h�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SelWarehouseCode9
        {
            get { return _selWarehouseCode9; }
            set { _selWarehouseCode9 = value; }
        }

        /// public propaty name  :  SelWarehouseCode10
        /// <summary>�I��q�ɃR�[�h�P�O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��q�ɃR�[�h�P�O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SelWarehouseCode10
        {
            get { return _selWarehouseCode10; }
            set { _selWarehouseCode10 = value; }
        }

        /// public propaty name  :  InventoryDate
        /// <summary>�I�����{���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����{���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime InventoryDate
        {
            get { return _inventoryDate; }
            set { _inventoryDate = value; }
        }


        /// <summary>
        /// �I���f�[�^�i�������������j���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>InventDataPreWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InventDataPreWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public InventDataPreWork()
        {
        }

    }

/// <summary>
///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
/// </summary>
/// <returns>InventDataPreWork�N���X�̃C���X�^���X(object)</returns>
/// <remarks>
/// <br>Note�@�@�@�@�@�@ :   InventDataPreWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
/// <br>Programer        :   ��������</br>
/// </remarks>
public class InventDataPreWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
{
    #region ICustomSerializationSurrogate �����o

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
    /// </summary>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   InventDataPreWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public void Serialize(System.IO.BinaryWriter writer, object graph)
    {
        // TODO:  InventDataPreWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
        if (writer == null)
            throw new ArgumentNullException();

        if (graph != null && !(graph is InventDataPreWork || graph is ArrayList || graph is InventDataPreWork[]))
            throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(InventDataPreWork).FullName));

        if (graph != null && graph is InventDataPreWork)
        {
            Type t = graph.GetType();
            if (!CustomFormatterServices.NeedCustomSerialization(t))
                throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
        }

        //SerializationTypeInfo
        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.InventDataPreWork");

        //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
        int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
        if (graph is ArrayList)
        {
            serInfo.RetTypeInfo = 0;
            occurrence = ((ArrayList)graph).Count;
        }
        else if (graph is InventDataPreWork[])
        {
            serInfo.RetTypeInfo = 2;
            occurrence = ((InventDataPreWork[])graph).Length;
        }
        else if (graph is InventDataPreWork)
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
        //�I�������������t
        serInfo.MemberInfo.Add(typeof(Int32)); //InventoryPreprDay
        //�I��������������
        serInfo.MemberInfo.Add(typeof(Int32)); //InventoryPreprTim
        //�I�������敪
        serInfo.MemberInfo.Add(typeof(Int32)); //InventoryProcDiv
        //�q�ɃR�[�h�J�n
        serInfo.MemberInfo.Add(typeof(string)); //WarehouseCodeSt
        //�q�ɃR�[�h�I��
        serInfo.MemberInfo.Add(typeof(string)); //WarehouseCodeEd
        // -------ADD 2011/01/30------->>>>>
        //�Ǘ����_�J�n
        serInfo.MemberInfo.Add(typeof(string)); //MngSectionCodeSt
        //�Ǘ����_�I��
        serInfo.MemberInfo.Add(typeof(string)); //MngSectionCodeEd
        // -------ADD 2011/01/30-------<<<<<
        //�I�ԊJ�n
        serInfo.MemberInfo.Add(typeof(string)); //ShelfNoSt
        //�I�ԏI��
        serInfo.MemberInfo.Add(typeof(string)); //ShelfNoEd
        //�d����R�[�h�J�n
        serInfo.MemberInfo.Add(typeof(Int32)); //StartSupplierCode
        //�d����R�[�h�I��
        serInfo.MemberInfo.Add(typeof(Int32)); //EndSupplierCode
        //�a�k���i�R�[�h�J�n
        serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCodeSt
        //�a�k���i�R�[�h�I��
        serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCodeEd
        //���i���[�J�[�R�[�h�J�n
        serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCdSt
        //���i���[�J�[�R�[�h�I��
        serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCdEd
        //BL�O���[�v�R�[�h�J�n
        serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCodeSt
        //BL�O���[�v�R�[�h�I��
        serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCodeEd
        //����݌ɒ��o�敪
        serInfo.MemberInfo.Add(typeof(Int32)); //TrtStkExtraDiv
        //�ϑ��i���Ёj�݌ɒ��o�敪
        serInfo.MemberInfo.Add(typeof(Int32)); //EntCmpStkExtraDiv
        //�ŏI�I���X�V���J�n
        serInfo.MemberInfo.Add(typeof(Int32)); //LtInventoryUpdateSt
        //�ŏI�I���X�V���I��
        serInfo.MemberInfo.Add(typeof(Int32)); //LtInventoryUpdateEd
        //�I��q�ɃR�[�h�P
        serInfo.MemberInfo.Add(typeof(string)); //SelWarehouseCode1
        //�I��q�ɃR�[�h�Q
        serInfo.MemberInfo.Add(typeof(string)); //SelWarehouseCode2
        //�I��q�ɃR�[�h�R
        serInfo.MemberInfo.Add(typeof(string)); //SelWarehouseCode3
        //�I��q�ɃR�[�h�S
        serInfo.MemberInfo.Add(typeof(string)); //SelWarehouseCode4
        //�I��q�ɃR�[�h�T
        serInfo.MemberInfo.Add(typeof(string)); //SelWarehouseCode5
        //�I��q�ɃR�[�h�U
        serInfo.MemberInfo.Add(typeof(string)); //SelWarehouseCode6
        //�I��q�ɃR�[�h�V
        serInfo.MemberInfo.Add(typeof(string)); //SelWarehouseCode7
        //�I��q�ɃR�[�h�W
        serInfo.MemberInfo.Add(typeof(string)); //SelWarehouseCode8
        //�I��q�ɃR�[�h�X
        serInfo.MemberInfo.Add(typeof(string)); //SelWarehouseCode9
        //�I��q�ɃR�[�h�P�O
        serInfo.MemberInfo.Add(typeof(string)); //SelWarehouseCode10
        //�I�����{��
        serInfo.MemberInfo.Add(typeof(Int32)); //InventoryDate


        serInfo.Serialize(writer, serInfo);
        if (graph is InventDataPreWork)
        {
            InventDataPreWork temp = (InventDataPreWork)graph;

            SetInventDataPreWork(writer, temp);
        }
        else
        {
            ArrayList lst = null;
            if (graph is InventDataPreWork[])
            {
                lst = new ArrayList();
                lst.AddRange((InventDataPreWork[])graph);
            }
            else
            {
                lst = (ArrayList)graph;
            }

            foreach (InventDataPreWork temp in lst)
            {
                SetInventDataPreWork(writer, temp);
            }

        }


    }


    /// <summary>
    /// InventDataPreWork�����o��(public�v���p�e�B��)
    /// </summary>
    //private const int currentMemberCount = 39;// DEL 2011/01/30
    private const int currentMemberCount = 41;// ADD 2011/01/30

    /// <summary>
    ///  InventDataPreWork�C���X�^���X��������
    /// </summary>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   InventDataPreWork�̃C���X�^���X����������</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    private void SetInventDataPreWork(System.IO.BinaryWriter writer, InventDataPreWork temp)
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
        //�I�������������t
        writer.Write((Int64)temp.InventoryPreprDay.Ticks);
        //�I��������������
        writer.Write(temp.InventoryPreprTim);
        //�I�������敪
        writer.Write(temp.InventoryProcDiv);
        //�q�ɃR�[�h�J�n
        writer.Write(temp.WarehouseCodeSt);
        //�q�ɃR�[�h�I��
        writer.Write(temp.WarehouseCodeEd);
        // -------ADD 2011/01/30------->>>>>
        //�Ǘ����_�J�n
        writer.Write(temp.MngSectionCodeSt);
        //�Ǘ����_�I��
        writer.Write(temp.MngSectionCodeEd);
        // -------ADD 2011/01/30-------<<<<<
        //�I�ԊJ�n
        writer.Write(temp.ShelfNoSt);
        //�I�ԏI��
        writer.Write(temp.ShelfNoEd);
        //�d����R�[�h�J�n
        writer.Write(temp.StartSupplierCode);
        //�d����R�[�h�I��
        writer.Write(temp.EndSupplierCode);
        //�a�k���i�R�[�h�J�n
        writer.Write(temp.BLGoodsCodeSt);
        //�a�k���i�R�[�h�I��
        writer.Write(temp.BLGoodsCodeEd);
        //���i���[�J�[�R�[�h�J�n
        writer.Write(temp.GoodsMakerCdSt);
        //���i���[�J�[�R�[�h�I��
        writer.Write(temp.GoodsMakerCdEd);
        //BL�O���[�v�R�[�h�J�n
        writer.Write(temp.BLGroupCodeSt);
        //BL�O���[�v�R�[�h�I��
        writer.Write(temp.BLGroupCodeEd);
        //����݌ɒ��o�敪
        writer.Write(temp.TrtStkExtraDiv);
        //�ϑ��i���Ёj�݌ɒ��o�敪
        writer.Write(temp.EntCmpStkExtraDiv);
        //�ŏI�I���X�V���J�n
        writer.Write((Int64)temp.LtInventoryUpdateSt.Ticks);
        //�ŏI�I���X�V���I��
        writer.Write((Int64)temp.LtInventoryUpdateEd.Ticks);
        //�I��q�ɃR�[�h�P
        writer.Write(temp.SelWarehouseCode1);
        //�I��q�ɃR�[�h�Q
        writer.Write(temp.SelWarehouseCode2);
        //�I��q�ɃR�[�h�R
        writer.Write(temp.SelWarehouseCode3);
        //�I��q�ɃR�[�h�S
        writer.Write(temp.SelWarehouseCode4);
        //�I��q�ɃR�[�h�T
        writer.Write(temp.SelWarehouseCode5);
        //�I��q�ɃR�[�h�U
        writer.Write(temp.SelWarehouseCode6);
        //�I��q�ɃR�[�h�V
        writer.Write(temp.SelWarehouseCode7);
        //�I��q�ɃR�[�h�W
        writer.Write(temp.SelWarehouseCode8);
        //�I��q�ɃR�[�h�X
        writer.Write(temp.SelWarehouseCode9);
        //�I��q�ɃR�[�h�P�O
        writer.Write(temp.SelWarehouseCode10);
        //�I�����{��
        writer.Write((Int64)temp.InventoryDate.Ticks);

    }

    /// <summary>
    ///  InventDataPreWork�C���X�^���X�擾
    /// </summary>
    /// <returns>InventDataPreWork�N���X�̃C���X�^���X</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   InventDataPreWork�̃C���X�^���X���擾���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    private InventDataPreWork GetInventDataPreWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
    {
        // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
        // serInfo.MemberInfo.Count < currentMemberCount
        // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

        InventDataPreWork temp = new InventDataPreWork();

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
        //�I�������������t
        temp.InventoryPreprDay = new DateTime(reader.ReadInt64());
        //�I��������������
        temp.InventoryPreprTim = reader.ReadInt32();
        //�I�������敪
        temp.InventoryProcDiv = reader.ReadInt32();
        //�q�ɃR�[�h�J�n
        temp.WarehouseCodeSt = reader.ReadString();
        //�q�ɃR�[�h�I��
        temp.WarehouseCodeEd = reader.ReadString();
        // -------ADD 2011/01/30------->>>>>
        //�Ǘ����_�J�n
        temp.MngSectionCodeSt = reader.ReadString();
        //�Ǘ����_�I��
        temp.MngSectionCodeEd = reader.ReadString();
        // -------ADD 2011/01/30-------<<<<<
        //�I�ԊJ�n
        temp.ShelfNoSt = reader.ReadString();
        //�I�ԏI��
        temp.ShelfNoEd = reader.ReadString();
        //�d����R�[�h�J�n
        temp.StartSupplierCode = reader.ReadInt32();
        //�d����R�[�h�I��
        temp.EndSupplierCode = reader.ReadInt32();
        //�a�k���i�R�[�h�J�n
        temp.BLGoodsCodeSt = reader.ReadInt32();
        //�a�k���i�R�[�h�I��
        temp.BLGoodsCodeEd = reader.ReadInt32();
        //���i���[�J�[�R�[�h�J�n
        temp.GoodsMakerCdSt = reader.ReadInt32();
        //���i���[�J�[�R�[�h�I��
        temp.GoodsMakerCdEd = reader.ReadInt32();
        //BL�O���[�v�R�[�h�J�n
        temp.BLGroupCodeSt = reader.ReadInt32();
        //BL�O���[�v�R�[�h�I��
        temp.BLGroupCodeEd = reader.ReadInt32();
        //����݌ɒ��o�敪
        temp.TrtStkExtraDiv = reader.ReadInt32();
        //�ϑ��i���Ёj�݌ɒ��o�敪
        temp.EntCmpStkExtraDiv = reader.ReadInt32();
        //�ŏI�I���X�V���J�n
        temp.LtInventoryUpdateSt = new DateTime(reader.ReadInt64());
        //�ŏI�I���X�V���I��
        temp.LtInventoryUpdateEd = new DateTime(reader.ReadInt64());
        //�I��q�ɃR�[�h�P
        temp.SelWarehouseCode1 = reader.ReadString();
        //�I��q�ɃR�[�h�Q
        temp.SelWarehouseCode2 = reader.ReadString();
        //�I��q�ɃR�[�h�R
        temp.SelWarehouseCode3 = reader.ReadString();
        //�I��q�ɃR�[�h�S
        temp.SelWarehouseCode4 = reader.ReadString();
        //�I��q�ɃR�[�h�T
        temp.SelWarehouseCode5 = reader.ReadString();
        //�I��q�ɃR�[�h�U
        temp.SelWarehouseCode6 = reader.ReadString();
        //�I��q�ɃR�[�h�V
        temp.SelWarehouseCode7 = reader.ReadString();
        //�I��q�ɃR�[�h�W
        temp.SelWarehouseCode8 = reader.ReadString();
        //�I��q�ɃR�[�h�X
        temp.SelWarehouseCode9 = reader.ReadString();
        //�I��q�ɃR�[�h�P�O
        temp.SelWarehouseCode10 = reader.ReadString();
        //�I�����{��
        temp.InventoryDate = new DateTime(reader.ReadInt64());


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
    /// <returns>InventDataPreWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   InventDataPreWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public object Deserialize(System.IO.BinaryReader reader)
    {
        object retValue = null;
        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
        ArrayList lst = new ArrayList();
        for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
        {
            InventDataPreWork temp = GetInventDataPreWork(reader, serInfo);
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
                retValue = (InventDataPreWork[])lst.ToArray(typeof(InventDataPreWork));
                break;
        }
        return retValue;
    }

    #endregion
}
}
