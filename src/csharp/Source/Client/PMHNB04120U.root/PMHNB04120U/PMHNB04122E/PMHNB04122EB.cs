using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CustomInqResult
    /// <summary>
    ///                      ���Ӑ�ߔN�x���яƉ�o���ʃN���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���Ӑ�ߔN�x���яƉ�o���ʃN���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/18  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CustomInqResult
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _addUpSecCode = "";

        /// <summary>���Ӑ�R�[�h</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private Int32 _customerCode;

        /// <summary>������z</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂܂��j</remarks>
        private Int64 _salesMoney;

        /// <summary>�ԕi�z</summary>
        private Int64 _salesRetGoodsPrice;

        /// <summary>�l�����z</summary>
        private Int64 _discountPrice;

        /// <summary>�e�����z</summary>
        private Int64 _grossProfit;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�v�㋒�_����</summary>
        private string _addUpSecName = "";


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

        /// public propaty name  :  AddUpSecCode
        /// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
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

        /// public propaty name  :  SalesRetGoodsPrice
        /// <summary>�ԕi�z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesRetGoodsPrice
        {
            get { return _salesRetGoodsPrice; }
            set { _salesRetGoodsPrice = value; }
        }

        /// public propaty name  :  DiscountPrice
        /// <summary>�l�����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DiscountPrice
        {
            get { return _discountPrice; }
            set { _discountPrice = value; }
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

        /// public propaty name  :  AddUpSecName
        /// <summary>�v�㋒�_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�㋒�_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpSecName
        {
            get { return _addUpSecName; }
            set { _addUpSecName = value; }
        }


        /// <summary>
        /// ���Ӑ�ߔN�x���яƉ�o���ʃN���X�R���X�g���N�^
        /// </summary>
        /// <returns>CustomInqResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomInqResult�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustomInqResult()
        {
        }

        /// <summary>
        /// ���Ӑ�ߔN�x���яƉ�o���ʃN���X�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="addUpSecCode">�v�㋒�_�R�[�h(�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h)</param>
        /// <param name="customerCode">���Ӑ�R�[�h(�[����̏ꍇ�̎g�p�\����)</param>
        /// <param name="salesMoney">������z(�Ŕ����i�l��,�ԕi�܂܂��j)</param>
        /// <param name="salesRetGoodsPrice">�ԕi�z</param>
        /// <param name="discountPrice">�l�����z</param>
        /// <param name="grossProfit">�e�����z</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="addUpSecName">�v�㋒�_����</param>
        /// <returns>CustomInqResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomInqResult�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustomInqResult(string enterpriseCode, string addUpSecCode, Int32 customerCode, Int64 salesMoney, Int64 salesRetGoodsPrice, Int64 discountPrice, Int64 grossProfit, string enterpriseName, string addUpSecName)
        {
            this._enterpriseCode = enterpriseCode;
            this._addUpSecCode = addUpSecCode;
            this._customerCode = customerCode;
            this._salesMoney = salesMoney;
            this._salesRetGoodsPrice = salesRetGoodsPrice;
            this._discountPrice = discountPrice;
            this._grossProfit = grossProfit;
            this._enterpriseName = enterpriseName;
            this._addUpSecName = addUpSecName;

        }

        /// <summary>
        /// ���Ӑ�ߔN�x���яƉ�o���ʃN���X��������
        /// </summary>
        /// <returns>CustomInqResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CustomInqResult�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustomInqResult Clone()
        {
            return new CustomInqResult(this._enterpriseCode, this._addUpSecCode, this._customerCode, this._salesMoney, this._salesRetGoodsPrice, this._discountPrice, this._grossProfit, this._enterpriseName, this._addUpSecName);
        }

        /// <summary>
        /// ���Ӑ�ߔN�x���яƉ�o���ʃN���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CustomInqResult�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomInqResult�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(CustomInqResult target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.AddUpSecCode == target.AddUpSecCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.SalesMoney == target.SalesMoney)
                 && (this.SalesRetGoodsPrice == target.SalesRetGoodsPrice)
                 && (this.DiscountPrice == target.DiscountPrice)
                 && (this.GrossProfit == target.GrossProfit)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.AddUpSecName == target.AddUpSecName));
        }

        /// <summary>
        /// ���Ӑ�ߔN�x���яƉ�o���ʃN���X��r����
        /// </summary>
        /// <param name="customInqResult1">
        ///                    ��r����CustomInqResult�N���X�̃C���X�^���X
        /// </param>
        /// <param name="customInqResult2">��r����CustomInqResult�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomInqResult�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(CustomInqResult customInqResult1, CustomInqResult customInqResult2)
        {
            return ((customInqResult1.EnterpriseCode == customInqResult2.EnterpriseCode)
                 && (customInqResult1.AddUpSecCode == customInqResult2.AddUpSecCode)
                 && (customInqResult1.CustomerCode == customInqResult2.CustomerCode)
                 && (customInqResult1.SalesMoney == customInqResult2.SalesMoney)
                 && (customInqResult1.SalesRetGoodsPrice == customInqResult2.SalesRetGoodsPrice)
                 && (customInqResult1.DiscountPrice == customInqResult2.DiscountPrice)
                 && (customInqResult1.GrossProfit == customInqResult2.GrossProfit)
                 && (customInqResult1.EnterpriseName == customInqResult2.EnterpriseName)
                 && (customInqResult1.AddUpSecName == customInqResult2.AddUpSecName));
        }
        /// <summary>
        /// ���Ӑ�ߔN�x���яƉ�o���ʃN���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CustomInqResult�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomInqResult�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(CustomInqResult target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.AddUpSecCode != target.AddUpSecCode) resList.Add("AddUpSecCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.SalesMoney != target.SalesMoney) resList.Add("SalesMoney");
            if (this.SalesRetGoodsPrice != target.SalesRetGoodsPrice) resList.Add("SalesRetGoodsPrice");
            if (this.DiscountPrice != target.DiscountPrice) resList.Add("DiscountPrice");
            if (this.GrossProfit != target.GrossProfit) resList.Add("GrossProfit");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.AddUpSecName != target.AddUpSecName) resList.Add("AddUpSecName");

            return resList;
        }

        /// <summary>
        /// ���Ӑ�ߔN�x���яƉ�o���ʃN���X��r����
        /// </summary>
        /// <param name="customInqResult1">��r����CustomInqResult�N���X�̃C���X�^���X</param>
        /// <param name="customInqResult2">��r����CustomInqResult�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomInqResult�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(CustomInqResult customInqResult1, CustomInqResult customInqResult2)
        {
            ArrayList resList = new ArrayList();
            if (customInqResult1.EnterpriseCode != customInqResult2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (customInqResult1.AddUpSecCode != customInqResult2.AddUpSecCode) resList.Add("AddUpSecCode");
            if (customInqResult1.CustomerCode != customInqResult2.CustomerCode) resList.Add("CustomerCode");
            if (customInqResult1.SalesMoney != customInqResult2.SalesMoney) resList.Add("SalesMoney");
            if (customInqResult1.SalesRetGoodsPrice != customInqResult2.SalesRetGoodsPrice) resList.Add("SalesRetGoodsPrice");
            if (customInqResult1.DiscountPrice != customInqResult2.DiscountPrice) resList.Add("DiscountPrice");
            if (customInqResult1.GrossProfit != customInqResult2.GrossProfit) resList.Add("GrossProfit");
            if (customInqResult1.EnterpriseName != customInqResult2.EnterpriseName) resList.Add("EnterpriseName");
            if (customInqResult1.AddUpSecName != customInqResult2.AddUpSecName) resList.Add("AddUpSecName");

            return resList;
        }
    }
}
