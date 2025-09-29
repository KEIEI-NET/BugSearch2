using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   InventInputSearchCndtnWork
    /// <summary>
    ///                      �I���������o�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �I���������o�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/03/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br>Update Note      : l2011/01/11 liyp </br>
    /// <br>                  �ݏo���̈��������Ȃ��s��̏C��</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class InventInputSearchCndtnWork
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

        /// <summary>�ݏo���o�敪</summary>
        /// <remarks>0:������Ȃ�,1:�������</remarks>
        private Int32 _lendExtraDiv;

        /// <summary>�����v�㒊�o�敪</summary>
        /// <remarks>0:������Ȃ�,1:�������</remarks>
        private Int32 _delayPaymentDiv;

        // -----------ADD 2011/01/11 ------------------>>>>>
        /// <summary>���ʏo�͋敪</summary>
        private Int32 _numOutputDiv;
        /// <summary>�I�ԏo�͋敪</summary>
        /// <remarks>0:�S�ďo��,1:�I�ԂȂ��̂ݏo��,2:�I�ԂȂ��ȊO�o��</remarks>
        private Int32 _warehouseShelfOutputDiv;
        // -----------ADD 2011/01/11 ------------------<<<<<

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

        /// public propaty name  :  LendExtraDiv
        /// <summary>�ݏo���o�敪�v���p�e�B</summary>
        /// <value>0:������Ȃ�,1:�������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ݏo���o�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
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
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DelayPaymentDiv
        {
            get { return _delayPaymentDiv; }
            set { _delayPaymentDiv = value; }
        }

        // -----------ADD 2011/01/11 ------------------>>>>>
        /// public propaty name  :  NumOutputDiv
        /// <summary>���ʏo�͋敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ʏo�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NumOutputDiv
        {
            get { return _numOutputDiv; }
            set { _numOutputDiv = value; }
        }

        /// public propaty name  :  NumOutputDiv
        /// <summary>�I�ԏo�͋敪</summary>
        /// <remarks>0:�S�ďo��,1:�I�ԂȂ��̂ݏo��,2:�I�ԂȂ��ȊO�o��</remarks>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�ԏo�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 WarehouseShelfOutputDiv
        {
            get { return _warehouseShelfOutputDiv; }
            set { _warehouseShelfOutputDiv = value; }
        }
        // -----------ADD 2011/01/11 ------------------<<<<<

        /// <summary>
        /// �I���������o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>InventInputSearchCndtnWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InventInputSearchCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public InventInputSearchCndtnWork()
        {
        }

    }
}
