using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   InventInputSearchCndtn
    /// <summary>
    ///                      �I���������o�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �I���������o�����N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/09/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br>UpdateNote       :   2011/01/11 ���N�n��</br>
    /// <br>                     �ݏo���̈��������Ȃ��s��̏C��</br>
    /// </remarks>
    public class InventInputSearchCndtn
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�J�n���_�R�[�h</summary>
        private string _st_SectionCode = "";

        /// <summary>�I�����_�R�[�h</summary>
        private string _ed_SectionCode = "";

        /// <summary>�J�n���[�J�[�R�[�h</summary>
        private Int32 _st_MakerCode;

        /// <summary>�I�����[�J�[�R�[�h</summary>
        private Int32 _ed_MakerCode;

        /// <summary>�J�n���i�ԍ�</summary>
        private string _st_GoodsNo = "";

        /// <summary>�I�����i�ԍ�</summary>
        private string _ed_GoodsNo = "";

        /// <summary>�q�Ɏw��敪</summary>
        /// <remarks>0:�͈�,1:�P��</remarks>
        private Int32 _warehouseDiv;

        /// <summary>�J�n�q�ɃR�[�h</summary>
        private string _st_WarehouseCode = "";

        /// <summary>�I���q�ɃR�[�h</summary>
        private string _ed_WarehouseCode = "";

        /// <summary>�q�ɃR�[�h01</summary>
        private string _warehouseCd01 = "";

        /// <summary>�q�ɃR�[�h02</summary>
        private string _warehouseCd02 = "";

        /// <summary>�q�ɃR�[�h03</summary>
        private string _warehouseCd03 = "";

        /// <summary>�q�ɃR�[�h04</summary>
        private string _warehouseCd04 = "";

        /// <summary>�q�ɃR�[�h05</summary>
        private string _warehouseCd05 = "";

        /// <summary>�q�ɃR�[�h06</summary>
        private string _warehouseCd06 = "";

        /// <summary>�q�ɃR�[�h07</summary>
        private string _warehouseCd07 = "";

        /// <summary>�q�ɃR�[�h08</summary>
        private string _warehouseCd08 = "";

        /// <summary>�q�ɃR�[�h09</summary>
        private string _warehouseCd09 = "";

        /// <summary>�q�ɃR�[�h10</summary>
        private string _warehouseCd10 = "";

        /// <summary>�J�n�I��</summary>
        private string _st_WarehouseShelfNo = "";

        /// <summary>�I���I��</summary>
        private string _ed_WarehouseShelfNo = "";

        /// <summary>�J�n���Е��ރR�[�h</summary>
        private Int32 _st_EnterpriseGanreCode;

        /// <summary>�I�����Е��ރR�[�h</summary>
        private Int32 _ed_EnterpriseGanreCode;

        /// <summary>�J�nBL�R�[�h</summary>
        private Int32 _st_BLGoodsCode;

        /// <summary>�I��BL�R�[�h</summary>
        private Int32 _ed_BLGoodsCode;

        /// <summary>�J�n�d����R�[�h</summary>
        private Int32 _st_SupplierCd;

        /// <summary>�I���d����R�[�h</summary>
        private Int32 _ed_SupplierCd;

        /// <summary>�J�n�I�������������t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _st_InventoryPreprDay;

        /// <summary>�I���I�������������t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_InventoryPreprDay;

        /// <summary>�I����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _inventoryDate;

        /// <summary>�J�n�I���ʔ�</summary>
        private Int32 _st_InventorySeqNo;

        /// <summary>�I���I���ʔ�</summary>
        private Int32 _ed_InventorySeqNo;

        /// <summary>�J�n�O���[�v�R�[�h</summary>
        private Int32 _st_BLGroupCode;

        /// <summary>�I���O���[�v�R�[�h</summary>
        private Int32 _ed_BLGroupCode;

        /// <summary>���ٕ����o�敪</summary>
        /// <remarks>0:�S��,1:�������͕��̂�,2:�����͕��̂�,3:���ٕ��̂�</remarks>
        private Int32 _difCntExtraDiv;

        /// <summary>�݌ɐ�0���o�敪</summary>
        /// <remarks>0:���o����,1:���o���Ȃ�</remarks>
        private Int32 _stockCntZeroExtraDiv;

        /// <summary>�I���݌ɐ�0���o�敪</summary>
        /// <remarks>0:���o����,1:���o���Ȃ�</remarks>
        private Int32 _ivtStkCntZeroExtraDiv;

        /// <summary>���[���</summary>
        /// <remarks>0:�I���L���\�A1:�I�����ٕ\�A2:�I���\</remarks>
        private Int32 _selectedPaperKind;

        /// <summary>�o�͎w��敪</summary>
        /// <remarks>0:�S��,1:�I�������͕��̂�,2:���ٕ��̂�,3:�d���I�Ԃ���̂�</remarks>
        private Int32 _outputAppointDiv;

        /// <summary>���o�Ώۓ��t�敪</summary>
        /// <remarks>0:�I������������,1:�I�����{��,2:�I���X�V��</remarks>
        private Int32 _targetDateExtraDiv;

        /// <summary>�݌ɐ��Z�o�t���O</summary>
        /// <remarks>0:�݌ɐ��Z�o���Ȃ�, 1:�݌ɐ��Z�o����</remarks>
        private Int32 _calcStockAmountDiv;

        /// <summary>�݌ɐ��Z�o���t</summary>
        /// <remarks>�݌ɐ��Z�o�t���O=1�̂Ƃ��̍݌ɐ��Z�o���t</remarks>
        private DateTime _calcStockAmountDate;

        /// <summary>�݌ɋ敪</summary>
        /// <remarks>0:�S��,1:����,2:���</remarks>
        private Int32 _stockDiv;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        //---ADD 2011/01/11----------------------->>>>>
        /// <summary>�ݏo���o�敪</summary>
        /// <remarks>0:������Ȃ�,1:�������</remarks>
        private Int32 _lendExtraDiv;

        /// <summary>�����v�㒊�o�敪</summary>
        /// <remarks>0:������Ȃ�,1:�������</remarks>
        private Int32 _delayPaymentDiv;
        //---ADD 2011/01/11-----------------------<<<<<

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

        /// public propaty name  :  St_SectionCode
        /// <summary>�J�n���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_SectionCode
        {
            get { return _st_SectionCode; }
            set { _st_SectionCode = value; }
        }

        /// public propaty name  :  Ed_SectionCode
        /// <summary>�I�����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_SectionCode
        {
            get { return _ed_SectionCode; }
            set { _ed_SectionCode = value; }
        }

        /// public propaty name  :  St_MakerCode
        /// <summary>�J�n���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_MakerCode
        {
            get { return _st_MakerCode; }
            set { _st_MakerCode = value; }
        }

        /// public propaty name  :  Ed_MakerCode
        /// <summary>�I�����[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_MakerCode
        {
            get { return _ed_MakerCode; }
            set { _ed_MakerCode = value; }
        }

        /// public propaty name  :  St_GoodsNo
        /// <summary>�J�n���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_GoodsNo
        {
            get { return _st_GoodsNo; }
            set { _st_GoodsNo = value; }
        }

        /// public propaty name  :  Ed_GoodsNo
        /// <summary>�I�����i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_GoodsNo
        {
            get { return _ed_GoodsNo; }
            set { _ed_GoodsNo = value; }
        }

        /// public propaty name  :  WarehouseDiv
        /// <summary>�q�Ɏw��敪�v���p�e�B</summary>
        /// <value>0:�͈�,1:�P��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�Ɏw��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 WarehouseDiv
        {
            get { return _warehouseDiv; }
            set { _warehouseDiv = value; }
        }

        /// public propaty name  :  St_WarehouseCode
        /// <summary>�J�n�q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_WarehouseCode
        {
            get { return _st_WarehouseCode; }
            set { _st_WarehouseCode = value; }
        }

        /// public propaty name  :  Ed_WarehouseCode
        /// <summary>�I���q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_WarehouseCode
        {
            get { return _ed_WarehouseCode; }
            set { _ed_WarehouseCode = value; }
        }

        /// public propaty name  :  WarehouseCd01
        /// <summary>�q�ɃR�[�h01�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h01�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCd01
        {
            get { return _warehouseCd01; }
            set { _warehouseCd01 = value; }
        }

        /// public propaty name  :  WarehouseCd02
        /// <summary>�q�ɃR�[�h02�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h02�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCd02
        {
            get { return _warehouseCd02; }
            set { _warehouseCd02 = value; }
        }

        /// public propaty name  :  WarehouseCd03
        /// <summary>�q�ɃR�[�h03�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h03�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCd03
        {
            get { return _warehouseCd03; }
            set { _warehouseCd03 = value; }
        }

        /// public propaty name  :  WarehouseCd04
        /// <summary>�q�ɃR�[�h04�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h04�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCd04
        {
            get { return _warehouseCd04; }
            set { _warehouseCd04 = value; }
        }

        /// public propaty name  :  WarehouseCd05
        /// <summary>�q�ɃR�[�h05�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h05�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCd05
        {
            get { return _warehouseCd05; }
            set { _warehouseCd05 = value; }
        }

        /// public propaty name  :  WarehouseCd06
        /// <summary>�q�ɃR�[�h06�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h06�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCd06
        {
            get { return _warehouseCd06; }
            set { _warehouseCd06 = value; }
        }

        /// public propaty name  :  WarehouseCd07
        /// <summary>�q�ɃR�[�h07�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h07�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCd07
        {
            get { return _warehouseCd07; }
            set { _warehouseCd07 = value; }
        }

        /// public propaty name  :  WarehouseCd08
        /// <summary>�q�ɃR�[�h08�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h08�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCd08
        {
            get { return _warehouseCd08; }
            set { _warehouseCd08 = value; }
        }

        /// public propaty name  :  WarehouseCd09
        /// <summary>�q�ɃR�[�h09�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h09�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCd09
        {
            get { return _warehouseCd09; }
            set { _warehouseCd09 = value; }
        }

        /// public propaty name  :  WarehouseCd10
        /// <summary>�q�ɃR�[�h10�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCd10
        {
            get { return _warehouseCd10; }
            set { _warehouseCd10 = value; }
        }

        /// public propaty name  :  St_WarehouseShelfNo
        /// <summary>�J�n�I�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�I�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_WarehouseShelfNo
        {
            get { return _st_WarehouseShelfNo; }
            set { _st_WarehouseShelfNo = value; }
        }

        /// public propaty name  :  Ed_WarehouseShelfNo
        /// <summary>�I���I�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���I�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_WarehouseShelfNo
        {
            get { return _ed_WarehouseShelfNo; }
            set { _ed_WarehouseShelfNo = value; }
        }

        /// public propaty name  :  St_EnterpriseGanreCode
        /// <summary>�J�n���Е��ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���Е��ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_EnterpriseGanreCode
        {
            get { return _st_EnterpriseGanreCode; }
            set { _st_EnterpriseGanreCode = value; }
        }

        /// public propaty name  :  Ed_EnterpriseGanreCode
        /// <summary>�I�����Е��ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Е��ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_EnterpriseGanreCode
        {
            get { return _ed_EnterpriseGanreCode; }
            set { _ed_EnterpriseGanreCode = value; }
        }

        /// public propaty name  :  St_BLGoodsCode
        /// <summary>�J�nBL�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�nBL�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_BLGoodsCode
        {
            get { return _st_BLGoodsCode; }
            set { _st_BLGoodsCode = value; }
        }

        /// public propaty name  :  Ed_BLGoodsCode
        /// <summary>�I��BL�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��BL�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_BLGoodsCode
        {
            get { return _ed_BLGoodsCode; }
            set { _ed_BLGoodsCode = value; }
        }

        /// public propaty name  :  St_SupplierCd
        /// <summary>�J�n�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_SupplierCd
        {
            get { return _st_SupplierCd; }
            set { _st_SupplierCd = value; }
        }

        /// public propaty name  :  Ed_SupplierCd
        /// <summary>�I���d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_SupplierCd
        {
            get { return _ed_SupplierCd; }
            set { _ed_SupplierCd = value; }
        }

        /// public propaty name  :  St_InventoryPreprDay
        /// <summary>�J�n�I�������������t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�I�������������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_InventoryPreprDay
        {
            get { return _st_InventoryPreprDay; }
            set { _st_InventoryPreprDay = value; }
        }

        /// public propaty name  :  Ed_InventoryPreprDay
        /// <summary>�I���I�������������t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���I�������������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Ed_InventoryPreprDay
        {
            get { return _ed_InventoryPreprDay; }
            set { _ed_InventoryPreprDay = value; }
        }

        /// public propaty name  :  InventoryDate
        /// <summary>�I�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
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

        /// public propaty name  :  InventoryDateJpFormal
        /// <summary>�I���� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InventoryDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _inventoryDate); }
            set { }
        }

        /// public propaty name  :  InventoryDateJpInFormal
        /// <summary>�I���� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InventoryDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _inventoryDate); }
            set { }
        }

        /// public propaty name  :  InventoryDateAdFormal
        /// <summary>�I���� ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InventoryDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _inventoryDate); }
            set { }
        }

        /// public propaty name  :  InventoryDateAdInFormal
        /// <summary>�I���� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InventoryDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _inventoryDate); }
            set { }
        }

        /// public propaty name  :  St_InventorySeqNo
        /// <summary>�J�n�I���ʔԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�I���ʔԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_InventorySeqNo
        {
            get { return _st_InventorySeqNo; }
            set { _st_InventorySeqNo = value; }
        }

        /// public propaty name  :  Ed_InventorySeqNo
        /// <summary>�I���I���ʔԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���I���ʔԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_InventorySeqNo
        {
            get { return _ed_InventorySeqNo; }
            set { _ed_InventorySeqNo = value; }
        }

        /// public propaty name  :  St_BLGroupCode
        /// <summary>�J�n�O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_BLGroupCode
        {
            get { return _st_BLGroupCode; }
            set { _st_BLGroupCode = value; }
        }

        /// public propaty name  :  Ed_BLGroupCode
        /// <summary>�I���O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_BLGroupCode
        {
            get { return _ed_BLGroupCode; }
            set { _ed_BLGroupCode = value; }
        }

        /// public propaty name  :  DifCntExtraDiv
        /// <summary>���ٕ����o�敪�v���p�e�B</summary>
        /// <value>0:�S��,1:�������͕��̂�,2:�����͕��̂�,3:���ٕ��̂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ٕ����o�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DifCntExtraDiv
        {
            get { return _difCntExtraDiv; }
            set { _difCntExtraDiv = value; }
        }

        /// public propaty name  :  StockCntZeroExtraDiv
        /// <summary>�݌ɐ�0���o�敪�v���p�e�B</summary>
        /// <value>0:���o����,1:���o���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɐ�0���o�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockCntZeroExtraDiv
        {
            get { return _stockCntZeroExtraDiv; }
            set { _stockCntZeroExtraDiv = value; }
        }

        /// public propaty name  :  IvtStkCntZeroExtraDiv
        /// <summary>�I���݌ɐ�0���o�敪�v���p�e�B</summary>
        /// <value>0:���o����,1:���o���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���݌ɐ�0���o�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 IvtStkCntZeroExtraDiv
        {
            get { return _ivtStkCntZeroExtraDiv; }
            set { _ivtStkCntZeroExtraDiv = value; }
        }

        /// public propaty name  :  SelectedPaperKind
        /// <summary>���[��ʃv���p�e�B</summary>
        /// <value>0:�I���L���\�A1:�I�����ٕ\�A2:�I���\</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SelectedPaperKind
        {
            get { return _selectedPaperKind; }
            set { _selectedPaperKind = value; }
        }

        /// public propaty name  :  OutputAppointDiv
        /// <summary>�o�͎w��敪�v���p�e�B</summary>
        /// <value>0:�S��,1:�I�������͕��̂�,2:���ٕ��̂�,3:�d���I�Ԃ���̂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�͎w��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OutputAppointDiv
        {
            get { return _outputAppointDiv; }
            set { _outputAppointDiv = value; }
        }

        /// public propaty name  :  TargetDateExtraDiv
        /// <summary>���o�Ώۓ��t�敪�v���p�e�B</summary>
        /// <value>0:�I������������,1:�I�����{��,2:�I���X�V��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o�Ώۓ��t�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TargetDateExtraDiv
        {
            get { return _targetDateExtraDiv; }
            set { _targetDateExtraDiv = value; }
        }

        /// public propaty name  :  CalcStockAmountDiv
        /// <summary>�݌ɐ��Z�o�t���O�v���p�e�B</summary>
        /// <value>0:�݌ɐ��Z�o���Ȃ�, 1:�݌ɐ��Z�o����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɐ��Z�o�t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CalcStockAmountDiv
        {
            get { return _calcStockAmountDiv; }
            set { _calcStockAmountDiv = value; }
        }

        /// public propaty name  :  CalcStockAmountDate
        /// <summary>�݌ɐ��Z�o���t�v���p�e�B</summary>
        /// <value>�݌ɐ��Z�o�t���O=1�̂Ƃ��̍݌ɐ��Z�o���t</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɐ��Z�o���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CalcStockAmountDate
        {
            get { return _calcStockAmountDate; }
            set { _calcStockAmountDate = value; }
        }

        /// public propaty name  :  StockDiv
        /// <summary>�݌ɋ敪�v���p�e�B</summary>
        /// <value>0:�S��,1:����,2:���</value>
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

        //---ADD 2011/01/11----------------------->>>>>
        /// public propaty name  :  LendExtraDiv
        /// <summary>�ݏo���o�敪�v���p�e�B</summary>
        /// <value>0:������Ȃ�,1:�������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ݏo���o�敪�v���p�e�B</br>
        /// <br>Programer        :   ���N�n��</br>
        /// <br>UpdateNote       :   2011/01/11 ���N�n�� �ݏo���̈��������Ȃ��s��̏C��</br>
        /// </remarks>
        public Int32 LendExtraDiv
        {
            get { return _lendExtraDiv; }
            set { _lendExtraDiv = value; }
        }

        /// public propaty name  :  DelayPaymentDiv
        /// <summary>�����v�㒊�o�敪�v���p�e�B</summary>
        /// <value>0:������Ȃ�,1:�������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v�㒊�o�敪�v���p�e�B</br>
        /// <br>Programer        :   ���N�n��</br>
        /// <br>UpdateNote       :   2011/01/11  ���N�n�� �ݏo���̈��������Ȃ��s��̏C��</br>
        /// </remarks>
        public Int32 DelayPaymentDiv
        {
            get { return _delayPaymentDiv; }
            set { _delayPaymentDiv = value; }
        }
        //---ADD 2011/01/11-----------------------<<<<<
        /// <summary>
        /// �I���������o�����N���X�R���X�g���N�^
        /// </summary>
        /// <returns>InventInputSearchCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InventInputSearchCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public InventInputSearchCndtn()
        {
        }

        #region �� Private Const
        /// <summary>���� ���t�t�H�[�}�b�g</summary>
        public const string ct_DateFomat = "YYYY/MM/DD";

        /// <summary>���� �S�� �R�[�h</summary>
        public const int ct_All_Code = -1;
        /// <summary>���� �S�� ����</summary>
        public const string ct_All_Name = "�S��";

        // �W�v�^�C�v ------------------------------------------------------------------
        /// <summary>�W�v�^�C�v�敪 �����ԍ���</summary>
        public const string ct_GrossDiv_Product = "�����ԍ���";
        /// <summary>�W�v�^�C�v�敪 ���i��</summary>
        public const string ct_GrossDiv_Goods = "���i��";

        // �\�[�g�� ------------------------------------------------------------------
        /// <summary>�\�[�g�� �����ԍ���</summary>
        public const string ct_SortOrder_Product = "�����ԍ���";
        /// <summary>�\�[�g�� ���i��</summary>
        public const string ct_SortOrder_Goods = "���i��";

        #endregion

        #region �� Public Enum
        #region �� �I�����[�h
        /// <summary> �I�����[�h </summary>
        public enum ViewStyleState
        {
            /// <summary> ���Ԗ� </summary>
            Product = 0,
            /// <summary> ���i�� </summary>
            Goods = 1
        }
        #endregion

        #region �� �\�[�g��
        /// <summary> �\�[�g�� </summary>
        public enum SortOrderState
        {
            /// <summary> �q�Ɂ��I�� </summary>
            ShelfNo = 0,
            /// <summary> �q�Ɂ��d���� </summary>
            Customer = 1,
            /// <summary> �q�Ɂ��a�k�R�[�h </summary>
            BLGoods = 2,
            /// <summary> �q�Ɂ��O���[�v�R�[�h </summary>
            BLGroup = 3,
            /// <summary> �q�Ɂ����[�J�[ </summary>
            Maker = 4,
            /// <summary> �q�Ɂ��d���恨�I�� </summary>
            Cus_ShelfNo = 5,
            /// <summary> �q�Ɂ��d���恨���[�J�[ </summary>
            Cus_Maker = 6
        }
        #endregion

        #region �� �W�v�敪
        /// <summary> �W�v�敪 </summary>
        public enum GrossDivState
        {
            /// <summary> ���� </summary>
            Product = 0,
            /// <summary> ���i�� </summary>
            Goods = 1
        }
        #endregion

        #region �� �V�K�s�敪
        /// <summary> �V�K�s�敪 </summary>
        public enum NewRowState
        {
            /// <summary> �����s </summary>
            Old = 0,
            /// <summary> �V�K�s </summary>
            New = 1
        }
        #endregion

        #region �� �ύX�敪
        /// <summary> �ύX�敪 </summary>
        public enum ChangeFlagState
        {
            /// <summary> �ύX�� </summary>
            NotChange = 0,
            /// <summary> �ύX�L </summary>
            Change = 1
        }
        #endregion

        #region �� �݌Ɉϑ�����敪
        /// <summary> �݌Ɉϑ�����敪 </summary>
        public enum StockDivState
        {
            /// <summary> ���� </summary>
            Company = 0,
            /// <summary> ��� </summary>
            Trust = 1,
            /// <summary> �ϑ�(����) </summary>
            Consignment_Company = 2,
            /// <summary> �ϑ�(���) </summary>
            Consignment_Trust = 3
        }
        #endregion

        #region �� �\���敪
        /// <summary> �ύX�敪 </summary>
        public enum ViewState
        {
            /// <summary> �\�� </summary>
            View = 0,
            /// <summary> ��\�� </summary>
            NotView = 1,
            /// <summary> ���� </summary>
            Both = 2
        }
        #endregion

        #endregion �� Public Enum
    }
}
