using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   MTtlSalesSlip
    /// <summary>
    ///                      ���㌎���W�v�f�[�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���㌎���W�v�f�[�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/4/24</br>
    /// <br>Genarated Date   :   2008/11/07  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/7/31  ����</br>
    /// <br>                 :   �����ڒǉ��i�L�[�ǉ��j</br>
    /// <br>                 :   �̔��敪�R�[�h</br>
    /// </remarks>
    public class ShipmentPartsDspResult
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���яW�v�敪</summary>
        /// <remarks>0:���i���v 1:�݌� 2:���� 3:���</remarks>
        private Int32 _rsltTtlDivCd;

        /// <summary>�����</summary>
        /// <remarks>�o�׉�(���㎞�̂݁j</remarks>
        private Int32 _salesTimes;

        /// <summary>������z</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂܂��j</remarks>
        private Int64 _salesMoney;

        /// <summary>�e�����z</summary>
        private Int64 _grossProfit;

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

        /// public propaty name  :  RsltTtlDivCd
        /// <summary>���яW�v�敪�v���p�e�B</summary>
        /// <value>0:���i���v 1:�݌� 2:���� 3:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���яW�v�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RsltTtlDivCd
        {
            get { return _rsltTtlDivCd; }
            set { _rsltTtlDivCd = value; }
        }

        /// public propaty name  :  SalesTimes
        /// <summary>����񐔃v���p�e�B</summary>
        /// <value>�o�׉�(���㎞�̂݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����񐔃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesTimes
        {
            get { return _salesTimes; }
            set { _salesTimes = value; }
        }

        /// public propaty name  :  SalesMoney
        /// <summary>������z�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoney
        {
            get { return _salesMoney; }
            set { _salesMoney = value; }
        }

        /// public propaty name  :  GrossProfit
        /// <summary>�e�����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 GrossProfit
        {
            get { return _grossProfit; }
            set { _grossProfit = value; }
        }

        /// <summary>
        /// ���㌎���W�v�f�[�^�R���X�g���N�^
        /// </summary>
        /// <returns>ShipmentPartsDspResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipmentPartsDspResult�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ShipmentPartsDspResult()
        {
        }

        /// <summary>
        /// ���㌎���W�v�f�[�^�R���X�g���N�^
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
        public ShipmentPartsDspResult(string enterpriseCode, Int32 rsltTtlDivCd, Int32 salesTimes, Int64 salesMoney, Int64 grossProfit)
        {
            this._enterpriseCode = enterpriseCode;
            this._rsltTtlDivCd = rsltTtlDivCd;
            this._salesTimes = salesTimes;
            this._salesMoney = salesMoney;
            this._grossProfit = grossProfit;
        }

        /// <summary>
        /// ���㌎���W�v�f�[�^��������
        /// </summary>
        /// <returns>ShipmentPartsDspResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ShipmentPartsDspResult�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ShipmentPartsDspResult Clone()
        {
            return new ShipmentPartsDspResult(this._enterpriseCode, this._rsltTtlDivCd, this._salesTimes, this._salesMoney, this._grossProfit);
        }

        /// <summary>
        /// ���㌎���W�v�f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�ShipmentPartsDspResult�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipmentPartsDspResult�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(ShipmentPartsDspResult target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.RsltTtlDivCd == target.RsltTtlDivCd)
                 && (this.SalesTimes == target.SalesTimes)
                 && (this.SalesMoney == target.SalesMoney)
                 && (this.GrossProfit == target.GrossProfit));
        }

        /// <summary>
        /// ���㌎���W�v�f�[�^��r����
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
        public static bool Equals(ShipmentPartsDspResult mTtlSalesSlip1, ShipmentPartsDspResult mTtlSalesSlip2)
        {
            return ((mTtlSalesSlip1.EnterpriseCode == mTtlSalesSlip2.EnterpriseCode)
                 && (mTtlSalesSlip1.RsltTtlDivCd == mTtlSalesSlip2.RsltTtlDivCd)
                 && (mTtlSalesSlip1.SalesTimes == mTtlSalesSlip2.SalesTimes)
                 && (mTtlSalesSlip1.SalesMoney == mTtlSalesSlip2.SalesMoney)
                 && (mTtlSalesSlip1.GrossProfit == mTtlSalesSlip2.GrossProfit));
        }
        /// <summary>
        /// ���㌎���W�v�f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�ShipmentPartsDspResult�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipmentPartsDspResult�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(ShipmentPartsDspResult target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.RsltTtlDivCd != target.RsltTtlDivCd) resList.Add("RsltTtlDivCd");
            if (this.SalesTimes != target.SalesTimes) resList.Add("SalesTimes");
            if (this.SalesMoney != target.SalesMoney) resList.Add("SalesMoney");
            if (this.GrossProfit != target.GrossProfit) resList.Add("GrossProfit");

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
        /// </remarks>
        public static ArrayList Compare(ShipmentPartsDspResult shipmentPartsDspResult1, ShipmentPartsDspResult shipmentPartsDspResult2)
        {
            ArrayList resList = new ArrayList();
            if (shipmentPartsDspResult1.EnterpriseCode != shipmentPartsDspResult2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (shipmentPartsDspResult1.RsltTtlDivCd != shipmentPartsDspResult2.RsltTtlDivCd) resList.Add("RsltTtlDivCd");
            if (shipmentPartsDspResult1.SalesTimes != shipmentPartsDspResult2.SalesTimes) resList.Add("SalesTimes");
            if (shipmentPartsDspResult1.SalesMoney != shipmentPartsDspResult2.SalesMoney) resList.Add("SalesMoney");
            if (shipmentPartsDspResult1.GrossProfit != shipmentPartsDspResult2.GrossProfit) resList.Add("GrossProfit");

            return resList;
        }
    }
}
