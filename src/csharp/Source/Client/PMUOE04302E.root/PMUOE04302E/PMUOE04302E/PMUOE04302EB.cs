using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   MTtlSalesSlip
    /// <summary>
    ///                      DSP���O�f�[�^�Ɖ�f�[�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   DSP���O�f�[�^�Ɖ�f�[�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/11/17</br>
    /// <br>Genarated Date   :   </br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class DspRogDataResult
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���t</summary>
        /// <remarks>YYYY/MM/DD HH:MM:SS</remarks>
        private DateTime _date;

        /// <summary>�[���ԍ�</summary>
        private string _terminalNo;

        /// <summary>������</summary>
        private Int32�@_uOESupplierCd;

        /// <summary>�敪</summary>
        private Int32 _dspDiv;

        /// <summary>�v���O����ID</summary>
        private string _dspPGID;

        /// <summary>�X�e�[�^�X</summary>
        private Int32 _dspStatus;

        /// <summary>���b�Z�[�W</summary>
        private string _dspMessage;



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

        /// public propaty name  :  Date
        /// <summary>�\���^�C�v�v���p�e�B</summary>
        /// <value>YYYY/MM/DD HH:MM:SS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �\���^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        /// public propaty name  :  TerminalNo
        /// <summary>�[���ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[���ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TerminalNo
        {
            get { return _terminalNo; }
            set { _terminalNo = value; }
        }

        /// public propaty name  :  UOESupplierCd
        /// <summary>������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESupplierCd
        {
            get { return _uOESupplierCd; }
            set { _uOESupplierCd = value; }
        }

        /// public propaty name  :  DspDiv
        /// <summary>�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DspDiv
        {
            get { return _dspDiv; }
            set { _dspDiv = value; }
        }

        /// public propaty name  :  DspPGID
        /// <summary>�v���O����ID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v���O����ID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DspPGID
        {
            get { return _dspPGID; }
            set { _dspPGID = value; }
        }

        /// public propaty name  :  DspStatus
        /// <summary>�X�e�[�^�X�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DspStatus
        {
            get { return _dspStatus; }
            set { _dspStatus = value; }
        }

        /// public propaty name  :  DspMessage
        /// <summary>���b�Z�[�W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���b�Z�[�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DspMessage
        {
            get { return _dspMessage; }
            set { _dspMessage = value; }
        }

        /// <summary>
        /// ���엚�����O�f�[�^�R���X�g���N�^
        /// </summary>
        /// <returns>ShipmentPartsDspResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipmentPartsDspResult�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DspRogDataResult()
        {
        }

        /// <summary>
        /// DSP���O�f�[�^�Ɖ�f�[�^�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="rsltTtlDivCd">���яW�v�敪(0:���i���v 1:�݌� 2:���� 3:���)</param>
        /// <param name="salesTimes">�����(�o�׉�(���㎞�̂݁j)</param>
        /// <param name="salesMoney">������z(�Ŕ����i�l��,�ԕi�܂܂��j)</param>
        /// <param name="grossProfit">�e�����z</param>
        /// <returns>ShipmentPartsDspResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipmentPartsDspResult�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DspRogDataResult(string enterpriseCode, DateTime date, string terminalNo, Int32 uOESupplierCd, Int32 dspDiv, string dspPGID, Int32 dspStatus, string dspMessage)
        {
            this._enterpriseCode = enterpriseCode;
            this._date = date;
            this._terminalNo = terminalNo;
            this._uOESupplierCd = uOESupplierCd;
            this._dspDiv = dspDiv;
            this._dspPGID = dspPGID;
            this._dspStatus = dspStatus;
            this._dspMessage = dspMessage;
        }

        /// <summary>
        /// �f�[�^��������
        /// </summary>
        /// <returns>DspRogDataResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����DspRogDataResult�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DspRogDataResult Clone()
        {
            return new DspRogDataResult(this._enterpriseCode, this._date, this._terminalNo, this._uOESupplierCd, this._dspDiv, this._dspPGID, this._dspStatus, this._dspMessage);
        }

        /// <summary>
        ///DSP���O�f�[�^�Ɖ�f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�InventoryDataDspResult�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InventoryDataDspResult�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(DspRogDataResult target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.Date == target.Date)
                 && (this.TerminalNo == target.TerminalNo)
                 && (this.UOESupplierCd == target.UOESupplierCd)
                 && (this.DspDiv == target.DspDiv)
                 && (this.DspPGID == target.DspPGID)
                 && (this.DspStatus == target.DspStatus)
                 && (this.DspMessage == target.DspMessage));
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
        /// </remarks>
        public static bool Equals(DspRogDataResult inventoryData1, DspRogDataResult inventoryData2)
        {
            return ((inventoryData1.EnterpriseCode == inventoryData2.EnterpriseCode)
                 && (inventoryData1.Date == inventoryData2.Date)
                 && (inventoryData1.TerminalNo == inventoryData2.TerminalNo)
                 && (inventoryData1.UOESupplierCd == inventoryData2.UOESupplierCd)
                 && (inventoryData1.DspDiv == inventoryData2.DspDiv)
                 && (inventoryData1.DspPGID == inventoryData2.DspPGID)
                 && (inventoryData1.DspStatus == inventoryData2.DspStatus)
                 && (inventoryData1.DspMessage == inventoryData2.DspMessage));
        }
        /// <summary>
        /// DSP���O�f�[�^�Ɖ�f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�ShipmentPartsDspResult�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipmentPartsDspResult�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(DspRogDataResult target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.Date != target.Date) resList.Add("Date");
            if (this.TerminalNo != target.TerminalNo) resList.Add("TerminalNo");
            if (this.UOESupplierCd != target.UOESupplierCd) resList.Add("UOESupplierCd");
            if (this.DspDiv != target.DspDiv) resList.Add("DspDiv");
            if (this.DspPGID != target.DspPGID) resList.Add("DspPGID");
            if (this.DspStatus != target.DspStatus) resList.Add("DspStatus");
            if (this.DspMessage != target.DspMessage) resList.Add("DspMessage");
            return resList;
        }

        /// <summary>
        /// ���엚�����O�f�[�^��r����
        /// </summary>
        /// <param name="shipmentPartsDspResult1">��r����ShipmentPartsDspResult�N���X�̃C���X�^���X</param>
        /// <param name="shipmentPartsDspResult2">��r����ShipmentPartsDspResult�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MTtlSalesSlip�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(DspRogDataResult InventoryDataDsp1, DspRogDataResult InventoryDataDsp2)
        {
            ArrayList resList = new ArrayList();
            if (InventoryDataDsp1.EnterpriseCode != InventoryDataDsp2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (InventoryDataDsp1.Date != InventoryDataDsp2.Date) resList.Add("Date");
            if (InventoryDataDsp1.TerminalNo != InventoryDataDsp2.TerminalNo) resList.Add("TerminalNo");
            if (InventoryDataDsp1.UOESupplierCd != InventoryDataDsp2.UOESupplierCd) resList.Add("UOESupplierCd");
            if (InventoryDataDsp1.DspDiv != InventoryDataDsp2.DspDiv) resList.Add("DspDiv");
            if (InventoryDataDsp1.DspPGID != InventoryDataDsp2.DspPGID) resList.Add("DspPGID");
            if (InventoryDataDsp1.DspStatus != InventoryDataDsp2.DspStatus) resList.Add("DspStatus");
            if (InventoryDataDsp1.DspMessage != InventoryDataDsp2.DspMessage) resList.Add("DspMessage");

            return resList;
        }
    }
}
