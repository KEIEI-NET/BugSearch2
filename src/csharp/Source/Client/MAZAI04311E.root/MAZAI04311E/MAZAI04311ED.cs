using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   StockCarEnterCarOutRet
    /// <summary>
    ///                      �݌ɓ��o�ɏƉ�o���ʃN���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �݌ɓ��o�ɏƉ�o���ʃN���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/07/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class StockCarEnterCarOutRet
    {
        /// <summary>�݌ɑ���</summary>
        /// <remarks>�����J�n�N������̑��݌ɐ�</remarks>
        private Double _stockTotal;

        /// <summary>���א�</summary>
        /// <remarks>�󕥊J�n�N��������̑����א�</remarks>
        private Double _arrivalCnt;

        /// <summary>�o�א�</summary>
        /// <remarks>�󕥊J�n�N��������̑��o�א�</remarks>
        private Double _shipmentCnt;

        /// <summary>�c��</summary>
        /// <remarks>�����J�n�N������̑��݌ɐ��{�󕥊J�n�N��������J�n���o�ד��܂ł̑����א��[�󕥊J�n�N��������J�n���o�ד��܂ł̑��o�א�</remarks>
        private Double _remainCount;


        /// public propaty name  :  StockTotal
        /// <summary>�݌ɑ����v���p�e�B</summary>
        /// <value>�����J�n�N������̑��݌ɐ�</value>
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

        /// public propaty name  :  ArrivalCnt
        /// <summary>���א��v���p�e�B</summary>
        /// <value>�󕥊J�n�N��������̑����א�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ArrivalCnt
        {
            get { return _arrivalCnt; }
            set { _arrivalCnt = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>�o�א��v���p�e�B</summary>
        /// <value>�󕥊J�n�N��������̑��o�א�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
        }

        /// public propaty name  :  RemainCount
        /// <summary>�c���v���p�e�B</summary>
        /// <value>�����J�n�N������̑��݌ɐ��{�󕥊J�n�N��������J�n���o�ד��܂ł̑����א��[�󕥊J�n�N��������J�n���o�ד��܂ł̑��o�א�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double RemainCount
        {
            get { return _remainCount; }
            set { _remainCount = value; }
        }


        /// <summary>
        /// �݌ɓ��o�ɏƉ�o���ʃN���X�R���X�g���N�^
        /// </summary>
        /// <returns>StockCarEnterCarOutRet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockCarEnterCarOutRet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockCarEnterCarOutRet()
        {
        }

        /// <summary>
        /// �݌ɓ��o�ɏƉ�o���ʃN���X�R���X�g���N�^
        /// </summary>
        /// <param name="stockTotal">�݌ɑ���(�����J�n�N������̑��݌ɐ�)</param>
        /// <param name="arrivalCnt">���א�(�󕥊J�n�N��������̑����א�)</param>
        /// <param name="shipmentCnt">�o�א�(�󕥊J�n�N��������̑��o�א�)</param>
        /// <param name="remainCount">�c��(�����J�n�N������̑��݌ɐ��{�󕥊J�n�N��������J�n���o�ד��܂ł̑����א��[�󕥊J�n�N��������J�n���o�ד��܂ł̑��o�א�)</param>
        /// <returns>StockCarEnterCarOutRet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockCarEnterCarOutRet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockCarEnterCarOutRet(Double stockTotal, Double arrivalCnt, Double shipmentCnt, Double remainCount)
        {
            this._stockTotal = stockTotal;
            this._arrivalCnt = arrivalCnt;
            this._shipmentCnt = shipmentCnt;
            this._remainCount = remainCount;

        }

        /// <summary>
        /// �݌ɓ��o�ɏƉ�o���ʃN���X��������
        /// </summary>
        /// <returns>StockCarEnterCarOutRet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����StockCarEnterCarOutRet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockCarEnterCarOutRet Clone()
        {
            return new StockCarEnterCarOutRet(this._stockTotal, this._arrivalCnt, this._shipmentCnt, this._remainCount);
        }

        /// <summary>
        /// �݌ɓ��o�ɏƉ�o���ʃN���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�StockCarEnterCarOutRet�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockCarEnterCarOutRet�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(StockCarEnterCarOutRet target)
        {
            return ((this.StockTotal == target.StockTotal)
                 && (this.ArrivalCnt == target.ArrivalCnt)
                 && (this.ShipmentCnt == target.ShipmentCnt)
                 && (this.RemainCount == target.RemainCount));
        }

        /// <summary>
        /// �݌ɓ��o�ɏƉ�o���ʃN���X��r����
        /// </summary>
        /// <param name="stockCarEnterCarOutRet1">
        ///                    ��r����StockCarEnterCarOutRet�N���X�̃C���X�^���X
        /// </param>
        /// <param name="stockCarEnterCarOutRet2">��r����StockCarEnterCarOutRet�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockCarEnterCarOutRet�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(StockCarEnterCarOutRet stockCarEnterCarOutRet1, StockCarEnterCarOutRet stockCarEnterCarOutRet2)
        {
            return ((stockCarEnterCarOutRet1.StockTotal == stockCarEnterCarOutRet2.StockTotal)
                 && (stockCarEnterCarOutRet1.ArrivalCnt == stockCarEnterCarOutRet2.ArrivalCnt)
                 && (stockCarEnterCarOutRet1.ShipmentCnt == stockCarEnterCarOutRet2.ShipmentCnt)
                 && (stockCarEnterCarOutRet1.RemainCount == stockCarEnterCarOutRet2.RemainCount));
        }
        /// <summary>
        /// �݌ɓ��o�ɏƉ�o���ʃN���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�StockCarEnterCarOutRet�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockCarEnterCarOutRet�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(StockCarEnterCarOutRet target)
        {
            ArrayList resList = new ArrayList();
            if (this.StockTotal != target.StockTotal) resList.Add("StockTotal");
            if (this.ArrivalCnt != target.ArrivalCnt) resList.Add("ArrivalCnt");
            if (this.ShipmentCnt != target.ShipmentCnt) resList.Add("ShipmentCnt");
            if (this.RemainCount != target.RemainCount) resList.Add("RemainCount");

            return resList;
        }

        /// <summary>
        /// �݌ɓ��o�ɏƉ�o���ʃN���X��r����
        /// </summary>
        /// <param name="stockCarEnterCarOutRet1">��r����StockCarEnterCarOutRet�N���X�̃C���X�^���X</param>
        /// <param name="stockCarEnterCarOutRet2">��r����StockCarEnterCarOutRet�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockCarEnterCarOutRet�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(StockCarEnterCarOutRet stockCarEnterCarOutRet1, StockCarEnterCarOutRet stockCarEnterCarOutRet2)
        {
            ArrayList resList = new ArrayList();
            if (stockCarEnterCarOutRet1.StockTotal != stockCarEnterCarOutRet2.StockTotal) resList.Add("StockTotal");
            if (stockCarEnterCarOutRet1.ArrivalCnt != stockCarEnterCarOutRet2.ArrivalCnt) resList.Add("ArrivalCnt");
            if (stockCarEnterCarOutRet1.ShipmentCnt != stockCarEnterCarOutRet2.ShipmentCnt) resList.Add("ShipmentCnt");
            if (stockCarEnterCarOutRet1.RemainCount != stockCarEnterCarOutRet2.RemainCount) resList.Add("RemainCount");

            return resList;
        }
    }
}