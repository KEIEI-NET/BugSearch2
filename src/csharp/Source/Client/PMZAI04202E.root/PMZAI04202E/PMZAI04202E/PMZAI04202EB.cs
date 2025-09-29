using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   MTtlSalesSlip
    /// <summary>
    ///                      �݌Ƀ}�X�^�I���\���f�[�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �݌Ƀ}�X�^�I���\���f�[�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/11/17</br>
    /// <br>Genarated Date   :   </br>
    /// <br>Update Note      :   2014/03/05 �c����</br>
    /// <br>                 :   Redmine#42247 ����@�\�̒ǉ�</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class InventoryDataDspResult
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�\���^�C�v</summary>
        /// <remarks>0:�ʏ�,1:���ѐ�=0�Ͷ��Ă��Ȃ�,2:�ő�</remarks>
        private Int32 _listTypeDiv;

        /// <summary>�q�ɖ���</summary>
        private string _warehouseName;

        /// <summary>�I���A�C�e����</summary>
        private Int32 _inventoryItemCnt;

        /// <summary>�I�����z</summary>
        private Double _inventoryMony;

        /// <summary>�ő�I�����z</summary>
        private Double _maximuminventoryMony;

        /// <summary>���z</summary>
        private Double _balanceMony;

        //----- ADD 2014/03/05 �c���� Redmine#42247 ---------->>>>>
        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";
        //----- ADD 2014/03/05 �c���� Redmine#42247 ----------<<<<<

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

        /// public propaty name  :  ListTypeDiv
        /// <summary>�\���^�C�v�v���p�e�B</summary>
        /// <value>0:�ʏ�,1:���ѐ�=0�Ͷ��Ă��Ȃ�,2:�ő�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �\���^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ListTypeDiv
        {
            get { return _listTypeDiv; }
            set { _listTypeDiv = value; }
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

        /// public propaty name  :  InventoryItemCnt
        /// <summary>�I���A�C�e�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���A�C�e�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InventoryItemCnt
        {
            get { return _inventoryItemCnt; }
            set { _inventoryItemCnt = value; }
        }

        /// public propaty name  :  InventoryMony
        /// <summary>�I�����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double InventoryMony
        {
            get { return _inventoryMony; }
            set { _inventoryMony = value; }
        }

        /// public propaty name  :  MaximuminventoryMony
        /// <summary>�ō��I�����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ō��I�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MaximuminventoryMony
        {
            get { return _maximuminventoryMony; }
            set { _maximuminventoryMony = value; }
        }

        /// public propaty name  :  BalanceMony
        /// <summary>���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double BalanceMony
        {
            get { return _balanceMony; }
            set { _balanceMony = value; }
        }

        //----- ADD 2014/03/05 �c���� Redmine#42247 ---------->>>>>
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
        //----- ADD 2014/03/05 �c���� Redmine#42247 ----------<<<<<

        /// <summary>
        /// ���㌎���W�v�f�[�^�R���X�g���N�^
        /// </summary>
        /// <returns>ShipmentPartsDspResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipmentPartsDspResult�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public InventoryDataDspResult()
        {
        }

        /// <summary>
        /// �݌Ƀ}�X�^(�I���\��)�f�[�^�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="rsltTtlDivCd">���яW�v�敪(0:���i���v 1:�݌� 2:���� 3:���)</param>
        /// <param name="salesTimes">�����(�o�׉�(���㎞�̂݁j)</param>
        /// <param name="salesMoney">������z(�Ŕ����i�l��,�ԕi�܂܂��j)</param>
        /// <param name="grossProfit">�e�����z</param>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <returns>ShipmentPartsDspResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipmentPartsDspResult�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2014/03/05 �c����</br>
        /// <br>                 :   Redmine#42247 ����@�\�̒ǉ�</br>
        /// </remarks>
        //public InventoryDataDspResult(string enterpriseCode, string warehouseName, Int32 inventoryItemCnt, double inventoryMony, double maximumInventoryMony, double balanceMony) // DEL 2014/03/05 �c���� Redmine#42247
        public InventoryDataDspResult(string enterpriseCode, string warehouseName, Int32 inventoryItemCnt, double inventoryMony, double maximumInventoryMony, double balanceMony, string warehouseCode) // ADD 2014/03/05 �c���� Redmine#42247
        {
            this._enterpriseCode = enterpriseCode;
            this._warehouseName = warehouseName;
            this._inventoryItemCnt = inventoryItemCnt;
            this._inventoryMony = inventoryMony;
            this._maximuminventoryMony = maximumInventoryMony;
            this._balanceMony = balanceMony;
            this._warehouseCode = warehouseCode; // ADD 2014/03/05 �c���� Redmine#42247
        }

        /// <summary>
        /// �f�[�^��������
        /// </summary>
        /// <returns>ShipmentPartsDspResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ShipmentPartsDspResult�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2014/03/05 �c����</br>
        /// <br>                 :   Redmine#42247 ����@�\�̒ǉ�</br>
        /// </remarks>
        public InventoryDataDspResult Clone()
        {
            //return new InventoryDataDspResult(this._enterpriseCode, this._warehouseName, this._inventoryItemCnt, this._inventoryMony, this._maximuminventoryMony, this._balanceMony); // DEL 2014/03/05 �c���� Redmine#42247
            return new InventoryDataDspResult(this._enterpriseCode, this._warehouseName, this._inventoryItemCnt, this._inventoryMony, this._maximuminventoryMony, this._balanceMony, this._warehouseCode); // ADD 2014/03/05 �c���� Redmine#42247
        }

        /// <summary>
        ///�݌Ƀ}�X�^(�I���\��)�f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�InventoryDataDspResult�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InventoryDataDspResult�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2014/03/05 �c����</br>
        /// <br>                 :   Redmine#42247 ����@�\�̒ǉ�</br>
        /// </remarks>
        public bool Equals(InventoryDataDspResult target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this._warehouseName == target.WarehouseName)
                 && (this._inventoryItemCnt == target.InventoryItemCnt)
                 && (this._inventoryMony == target.InventoryMony)
                 && (this._maximuminventoryMony == target.MaximuminventoryMony)
                 && (this._warehouseCode == target.WarehouseCode) // ADD 2014/03/05 �c���� Redmine#42247
                 && (this._balanceMony == target.BalanceMony));
        }

        /// <summary>
        /// �݌Ƀ}�X�^(�I���\��)�f�[�^��r����
        /// </summary>
        /// <param name="ShipmentPartsDspResult">
        ///                    ��r����ShipmentPartsDspResult�N���X�̃C���X�^���X
        /// </param>
        /// <param name="mTtlSalesSlip2">��r����ShipmentPartsDspResult�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipmentPartsDspResult�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2014/03/05 �c����</br>
        /// <br>                 :   Redmine#42247 ����@�\�̒ǉ�</br>
        /// </remarks>
        public static bool Equals(InventoryDataDspResult inventoryData1, InventoryDataDspResult inventoryData2)
        {
            return ((inventoryData1.EnterpriseCode == inventoryData2.EnterpriseCode)
                 && (inventoryData1.WarehouseName == inventoryData2.WarehouseName)
                 && (inventoryData1.InventoryItemCnt == inventoryData2.InventoryItemCnt)
                 && (inventoryData1.InventoryMony == inventoryData2.InventoryMony)
                 && (inventoryData1.MaximuminventoryMony == inventoryData2.MaximuminventoryMony)
                 && (inventoryData1.WarehouseCode == inventoryData2.WarehouseCode) // ADD 2014/03/05 �c���� Redmine#42247
                 && (inventoryData1.BalanceMony == inventoryData2.BalanceMony));
        }
        /// <summary>
        /// �݌Ƀ}�X�^(�I���\��)�f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�ShipmentPartsDspResult�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipmentPartsDspResult�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2014/03/05 �c����</br>
        /// <br>                 :   Redmine#42247 ����@�\�̒ǉ�</br>
        /// </remarks>
        public ArrayList Compare(InventoryDataDspResult target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.WarehouseName != target.WarehouseName) resList.Add("WarehouseName");
            if (this.InventoryItemCnt != target.InventoryItemCnt) resList.Add("InbentoryItemCnt");
            if (this.InventoryMony != target.InventoryMony) resList.Add("InventoryMony");
            if (this.MaximuminventoryMony != target.MaximuminventoryMony) resList.Add("MaximuminventoryMony");
            if (this.BalanceMony != target.BalanceMony) resList.Add("BalanceMony");
            if (this.WarehouseCode != target.WarehouseCode) resList.Add("WarehouseCode"); // ADD 2014/03/05 �c���� Redmine#42247
            return resList;
        }

        /// <summary>
        /// ���㌎���W�v�f�[�^��r����
        /// </summary>
        /// <param name="shipmentPartsDspResult1">��r����ShipmentPartsDspResult�N���X�̃C���X�^���X</param>
        /// <param name="shipmentPartsDspResult2">��r����ShipmentPartsDspResult�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MTtlSalesSlip�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2014/03/05 �c����</br>
        /// <br>                 :   Redmine#42247 ����@�\�̒ǉ�</br>
        /// </remarks>
        public static ArrayList Compare(InventoryDataDspResult InventoryDataDsp1, InventoryDataDspResult InventoryDataDsp2)
        {
            ArrayList resList = new ArrayList();
            if (InventoryDataDsp1.EnterpriseCode != InventoryDataDsp2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (InventoryDataDsp1.WarehouseName != InventoryDataDsp2.WarehouseName) resList.Add("WarehouseName");
            if (InventoryDataDsp1.InventoryItemCnt != InventoryDataDsp2.InventoryItemCnt) resList.Add("InventoryItemCnt");
            if (InventoryDataDsp1.InventoryMony != InventoryDataDsp2.InventoryMony) resList.Add("InventoryMony");
            if (InventoryDataDsp1.MaximuminventoryMony != InventoryDataDsp2.MaximuminventoryMony) resList.Add("MaximuminventoryMony");
            if (InventoryDataDsp1.BalanceMony != InventoryDataDsp2.BalanceMony) resList.Add("BalanceMony");
            if (InventoryDataDsp1.WarehouseCode != InventoryDataDsp2.WarehouseCode) resList.Add("WarehouseCode"); // ADD 2014/03/05 �c���� Redmine#42247

            return resList;
        }
    }
}
