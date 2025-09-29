using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   GoodsUGoodsPriceUWork
    /// <summary>
    ///                      ���i�E���i���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i�E���i���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/19</br>
    /// <br>Genarated Date   :   2012/06/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/9/5  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   �@�񋟋敪</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class GoodsUGoodsPriceUWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private string _goodsMakerCd = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>���i���̃J�i</summary>
        private string _goodsNameKana = "";

        /// <summary>JAN�R�[�h</summary>
        /// <remarks>�W���^�C�v13���܂��͒Z�k�^�C�v8����JAN�R�[�h</remarks>
        private string _jan = "";

        /// <summary>BL���i�R�[�h</summary>
        private string _bLGoodsCode = "";

        /// <summary>���i�敪�R�[�h</summary>
        private string _enterpriseGanreCode = "";

        /// <summary>�w��</summary>
        /// <remarks>nchar 6 ����C��</remarks>
        private string _goodsRateRank = "";

        /// <summary>���i����</summary>
        /// <remarks>0:�����@1:���̑�</remarks>
        private string _goodsKindCode = "";

        /// <summary>�ېŋ敪</summary>
        /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
        private string _taxationDivCd = "";

        /// <summary>���i���l�P</summary>
        private string _goodsNote1 = "";

        /// <summary>���i���l�Q</summary>
        private string _goodsNote2 = "";

        /// <summary>���i�K�i�E���L����</summary>
        private string _goodsSpecialNote = "";

        /// <summary>���i�J�n�N�����P</summary>
        /// <remarks>YYYYMMDD</remarks>
        private string _priceStartDate1 = "";

        /// <summary>���i�P</summary>
        private string _listPrice1 = "";

        /// <summary>�I�[�v�����i�敪�P</summary>
        /// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
        private string _openPriceDiv1 = "";

        /// <summary>�d�����P</summary>
        private string _stockRate1 = "";

        /// <summary>���P���P</summary>
        /// <remarks>�d���P�� �� ���㌴���œ���</remarks>
        private string _salesUnitCost1 = "";

        /// <summary>���i�J�n�N�����Q</summary>
        /// <remarks>YYYYMMDD</remarks>
        private string _priceStartDate2 = "";

        /// <summary>���i�Q</summary>
        private string _listPrice2 = "";

        /// <summary>�I�[�v�����i�敪�Q</summary>
        /// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
        private string _openPriceDiv2 = "";

        /// <summary>�d�����Q</summary>
        private string _stockRate2 = "";

        /// <summary>���P���Q</summary>
        /// <remarks>�d���P�� �� ���㌴���œ���</remarks>
        private string _salesUnitCost2 = "";

        /// <summary>���i�J�n�N�����R</summary>
        /// <remarks>YYYYMMDD</remarks>
        private string _priceStartDate3 = "";

        /// <summary>���i�R</summary>
        private string _listPrice3 = "";

        /// <summary>�I�[�v�����i�敪�R</summary>
        /// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
        private string _openPriceDiv3 = "";

        /// <summary>�d�����R</summary>
        private string _stockRate3 = "";

        /// <summary>���P���R</summary>
        /// <remarks>�d���P�� �� ���㌴���œ���</remarks>
        private string _salesUnitCost3 = "";

        /// <summary>���i�J�n�N�����S</summary>
        /// <remarks>YYYYMMDD</remarks>
        private string _priceStartDate4 = "";

        /// <summary>���i�S</summary>
        private string _listPrice4 = "";

        /// <summary>�I�[�v�����i�敪�S</summary>
        /// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
        private string _openPriceDiv4 = "";

        /// <summary>�d�����S</summary>
        private string _stockRate4 = "";

        /// <summary>���P���S</summary>
        /// <remarks>�d���P�� �� ���㌴���œ���</remarks>
        private string _salesUnitCost4 = "";

        /// <summary>���i�J�n�N�����S</summary>
        /// <remarks>YYYYMMDD</remarks>
        private string _priceStartDate5 = "";

        /// <summary>���i�S</summary>
        private string _listPrice5 = "";

        /// <summary>�I�[�v�����i�敪�S</summary>
        /// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
        private string _openPriceDiv5 = "";

        /// <summary>�d�����S</summary>
        private string _stockRate5 = "";

        /// <summary>���P���S</summary>
        /// <remarks>�d���P�� �� ���㌴���œ���</remarks>
        private string _salesUnitCost5 = "";

        /// <summary>�G���[���O</summary>
        private string _errorMsg = "";

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

        /// public propaty name  :  GoodsNo
        /// <summary>���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>���i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  GoodsNameKana
        /// <summary>���i���̃J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
        }

        /// public propaty name  :  Jan
        /// <summary>JAN�R�[�h�v���p�e�B</summary>
        /// <value>�W���^�C�v13���܂��͒Z�k�^�C�v8����JAN�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   JAN�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Jan
        {
            get { return _jan; }
            set { _jan = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>���i�敪�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseGanreCode
        {
            get { return _enterpriseGanreCode; }
            set { _enterpriseGanreCode = value; }
        }

        /// public propaty name  :  GoodsRateRank
        /// <summary>�w�ʃv���p�e�B</summary>
        /// <value>nchar 6 ����C��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �w�ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsRateRank
        {
            get { return _goodsRateRank; }
            set { _goodsRateRank = value; }
        }

        /// public propaty name  :  GoodsKindCode
        /// <summary>���i�����v���p�e�B</summary>
        /// <value>0:�����@1:���̑�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsKindCode
        {
            get { return _goodsKindCode; }
            set { _goodsKindCode = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>�ېŋ敪�v���p�e�B</summary>
        /// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ېŋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TaxationDivCd
        {
            get { return _taxationDivCd; }
            set { _taxationDivCd = value; }
        }

        /// public propaty name  :  GoodsNote1
        /// <summary>���i���l�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���l�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNote1
        {
            get { return _goodsNote1; }
            set { _goodsNote1 = value; }
        }

        /// public propaty name  :  GoodsNote2
        /// <summary>���i���l�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���l�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNote2
        {
            get { return _goodsNote2; }
            set { _goodsNote2 = value; }
        }

        /// public propaty name  :  GoodsSpecialNote
        /// <summary>���i�K�i�E���L�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�K�i�E���L�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsSpecialNote
        {
            get { return _goodsSpecialNote; }
            set { _goodsSpecialNote = value; }
        }

        /// public propaty name  :  PriceStartDate1
        /// <summary>���i�J�n�N�����P�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�J�n�N�����P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriceStartDate1
        {
            get { return _priceStartDate1; }
            set { _priceStartDate1 = value; }
        }

        /// public propaty name  :  ListPrice1
        /// <summary>���i�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ListPrice1
        {
            get { return _listPrice1; }
            set { _listPrice1 = value; }
        }

        /// public propaty name  :  OpenPriceDiv1
        /// <summary>�I�[�v�����i�敪�P�v���p�e�B</summary>
        /// <value>0:�ʏ�^1:�I�[�v�����i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�[�v�����i�敪�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OpenPriceDiv1
        {
            get { return _openPriceDiv1; }
            set { _openPriceDiv1 = value; }
        }

        /// public propaty name  :  StockRate1
        /// <summary>�d�����P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockRate1
        {
            get { return _stockRate1; }
            set { _stockRate1 = value; }
        }

        /// public propaty name  :  SalesUnitCost1
        /// <summary>���P���P�v���p�e�B</summary>
        /// <value>�d���P�� �� ���㌴���œ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���P���P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesUnitCost1
        {
            get { return _salesUnitCost1; }
            set { _salesUnitCost1 = value; }
        }

        /// public propaty name  :  PriceStartDate2
        /// <summary>���i�J�n�N�����Q�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�J�n�N�����Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriceStartDate2
        {
            get { return _priceStartDate2; }
            set { _priceStartDate2 = value; }
        }

        /// public propaty name  :  ListPrice2
        /// <summary>���i�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ListPrice2
        {
            get { return _listPrice2; }
            set { _listPrice2 = value; }
        }

        /// public propaty name  :  OpenPriceDiv2
        /// <summary>�I�[�v�����i�敪�Q�v���p�e�B</summary>
        /// <value>0:�ʏ�^1:�I�[�v�����i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�[�v�����i�敪�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OpenPriceDiv2
        {
            get { return _openPriceDiv2; }
            set { _openPriceDiv2 = value; }
        }

        /// public propaty name  :  StockRate2
        /// <summary>�d�����Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockRate2
        {
            get { return _stockRate2; }
            set { _stockRate2 = value; }
        }

        /// public propaty name  :  SalesUnitCost2
        /// <summary>���P���Q�v���p�e�B</summary>
        /// <value>�d���P�� �� ���㌴���œ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���P���Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesUnitCost2
        {
            get { return _salesUnitCost2; }
            set { _salesUnitCost2 = value; }
        }

        /// public propaty name  :  PriceStartDate3
        /// <summary>���i�J�n�N�����R�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�J�n�N�����R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriceStartDate3
        {
            get { return _priceStartDate3; }
            set { _priceStartDate3 = value; }
        }

        /// public propaty name  :  ListPrice3
        /// <summary>���i�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ListPrice3
        {
            get { return _listPrice3; }
            set { _listPrice3 = value; }
        }

        /// public propaty name  :  OpenPriceDiv3
        /// <summary>�I�[�v�����i�敪�R�v���p�e�B</summary>
        /// <value>0:�ʏ�^1:�I�[�v�����i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�[�v�����i�敪�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OpenPriceDiv3
        {
            get { return _openPriceDiv3; }
            set { _openPriceDiv3 = value; }
        }

        /// public propaty name  :  StockRate3
        /// <summary>�d�����R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockRate3
        {
            get { return _stockRate3; }
            set { _stockRate3 = value; }
        }

        /// public propaty name  :  SalesUnitCost3
        /// <summary>���P���R�v���p�e�B</summary>
        /// <value>�d���P�� �� ���㌴���œ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���P���R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesUnitCost3
        {
            get { return _salesUnitCost3; }
            set { _salesUnitCost3 = value; }
        }

        /// public propaty name  :  PriceStartDate4
        /// <summary>���i�J�n�N�����S�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�J�n�N�����S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriceStartDate4
        {
            get { return _priceStartDate4; }
            set { _priceStartDate4 = value; }
        }

        /// public propaty name  :  ListPrice4
        /// <summary>���i�S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ListPrice4
        {
            get { return _listPrice4; }
            set { _listPrice4 = value; }
        }

        /// public propaty name  :  OpenPriceDiv4
        /// <summary>�I�[�v�����i�敪�S�v���p�e�B</summary>
        /// <value>0:�ʏ�^1:�I�[�v�����i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�[�v�����i�敪�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OpenPriceDiv4
        {
            get { return _openPriceDiv4; }
            set { _openPriceDiv4 = value; }
        }

        /// public propaty name  :  StockRate4
        /// <summary>�d�����S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockRate4
        {
            get { return _stockRate4; }
            set { _stockRate4 = value; }
        }

        /// public propaty name  :  SalesUnitCost4
        /// <summary>���P���S�v���p�e�B</summary>
        /// <value>�d���P�� �� ���㌴���œ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���P���S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesUnitCost4
        {
            get { return _salesUnitCost4; }
            set { _salesUnitCost4 = value; }
        }

        /// public propaty name  :  PriceStartDate5
        /// <summary>���i�J�n�N�����S�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�J�n�N�����S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriceStartDate5
        {
            get { return _priceStartDate5; }
            set { _priceStartDate5 = value; }
        }

        /// public propaty name  :  ListPrice5
        /// <summary>���i�S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ListPrice5
        {
            get { return _listPrice5; }
            set { _listPrice5 = value; }
        }

        /// public propaty name  :  OpenPriceDiv5
        /// <summary>�I�[�v�����i�敪�S�v���p�e�B</summary>
        /// <value>0:�ʏ�^1:�I�[�v�����i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�[�v�����i�敪�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OpenPriceDiv5
        {
            get { return _openPriceDiv5; }
            set { _openPriceDiv5 = value; }
        }

        /// public propaty name  :  StockRate5
        /// <summary>�d�����S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockRate5
        {
            get { return _stockRate5; }
            set { _stockRate5 = value; }
        }

        /// public propaty name  :  SalesUnitCost5
        /// <summary>���P���S�v���p�e�B</summary>
        /// <value>�d���P�� �� ���㌴���œ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���P���S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesUnitCost5
        {
            get { return _salesUnitCost5; }
            set { _salesUnitCost5 = value; }
        }

        /// public propaty name  :  ErrorMsg
        /// <summary>�G���[���O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���[���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ErrorMsg
        {
            get { return _errorMsg; }
            set { _errorMsg = value; }
        }

        /// <summary>
        /// ���i�E���i���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>GoodsUGoodsPriceUWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsUGoodsPriceUWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsUGoodsPriceUWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>GoodsUGoodsPriceUWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   GoodsUGoodsPriceUWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class GoodsUGoodsPriceUWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsUGoodsPriceUWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  GoodsUGoodsPriceUWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is GoodsUGoodsPriceUWork || graph is ArrayList || graph is GoodsUGoodsPriceUWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(GoodsUGoodsPriceUWork).FullName));

            if (graph != null && graph is GoodsUGoodsPriceUWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.GoodsUGoodsPriceUWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is GoodsUGoodsPriceUWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((GoodsUGoodsPriceUWork[])graph).Length;
            }
            else if (graph is GoodsUGoodsPriceUWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMakerCd
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //���i���̃J�i
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //JAN�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //Jan
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsCode
            //���i�敪�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseGanreCode
            //�w��
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRateRank
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsKindCode
            //�ېŋ敪
            serInfo.MemberInfo.Add(typeof(string)); //TaxationDivCd
            //���i���l�P
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNote1
            //���i���l�Q
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNote2
            //���i�K�i�E���L����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsSpecialNote
            //���i�J�n�N�����P
            serInfo.MemberInfo.Add(typeof(string)); //PriceStartDate1
            //���i�P
            serInfo.MemberInfo.Add(typeof(string)); //ListPrice1
            //�I�[�v�����i�敪�P
            serInfo.MemberInfo.Add(typeof(string)); //OpenPriceDiv1
            //�d�����P
            serInfo.MemberInfo.Add(typeof(string)); //StockRate1
            //���P���P
            serInfo.MemberInfo.Add(typeof(string)); //SalesUnitCost1
            //���i�J�n�N�����Q
            serInfo.MemberInfo.Add(typeof(string)); //PriceStartDate2
            //���i�Q
            serInfo.MemberInfo.Add(typeof(string)); //ListPrice2
            //�I�[�v�����i�敪�Q
            serInfo.MemberInfo.Add(typeof(string)); //OpenPriceDiv2
            //�d�����Q
            serInfo.MemberInfo.Add(typeof(string)); //StockRate2
            //���P���Q
            serInfo.MemberInfo.Add(typeof(string)); //SalesUnitCost2
            //���i�J�n�N�����R
            serInfo.MemberInfo.Add(typeof(string)); //PriceStartDate3
            //���i�R
            serInfo.MemberInfo.Add(typeof(string)); //ListPrice3
            //�I�[�v�����i�敪�R
            serInfo.MemberInfo.Add(typeof(string)); //OpenPriceDiv3
            //�d�����R
            serInfo.MemberInfo.Add(typeof(string)); //StockRate3
            //���P���R
            serInfo.MemberInfo.Add(typeof(string)); //SalesUnitCost3
            //���i�J�n�N�����S
            serInfo.MemberInfo.Add(typeof(string)); //PriceStartDate4
            //���i�S
            serInfo.MemberInfo.Add(typeof(string)); //ListPrice4
            //�I�[�v�����i�敪�S
            serInfo.MemberInfo.Add(typeof(string)); //OpenPriceDiv4
            //�d�����S
            serInfo.MemberInfo.Add(typeof(string)); //StockRate4
            //���P���S
            serInfo.MemberInfo.Add(typeof(string)); //SalesUnitCost4
            //���i�J�n�N�����S
            serInfo.MemberInfo.Add(typeof(string)); //PriceStartDate5
            //���i�S
            serInfo.MemberInfo.Add(typeof(string)); //ListPrice5
            //�I�[�v�����i�敪�S
            serInfo.MemberInfo.Add(typeof(string)); //OpenPriceDiv5
            //�d�����S
            serInfo.MemberInfo.Add(typeof(string)); //StockRate5
            //���P���S
            serInfo.MemberInfo.Add(typeof(string)); //SalesUnitCost5
            //�G���[���O
            serInfo.MemberInfo.Add(typeof(string)); //ErrorMsg


            serInfo.Serialize(writer, serInfo);
            if (graph is GoodsUGoodsPriceUWork)
            {
                GoodsUGoodsPriceUWork temp = (GoodsUGoodsPriceUWork)graph;

                SetGoodsUGoodsPriceUWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is GoodsUGoodsPriceUWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((GoodsUGoodsPriceUWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (GoodsUGoodsPriceUWork temp in lst)
                {
                    SetGoodsUGoodsPriceUWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// GoodsUGoodsPriceUWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 40;

        /// <summary>
        ///  GoodsUGoodsPriceUWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsUGoodsPriceUWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetGoodsUGoodsPriceUWork(System.IO.BinaryWriter writer, GoodsUGoodsPriceUWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���i����
            writer.Write(temp.GoodsName);
            //���i���̃J�i
            writer.Write(temp.GoodsNameKana);
            //JAN�R�[�h
            writer.Write(temp.Jan);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //���i�敪�R�[�h
            writer.Write(temp.EnterpriseGanreCode);
            //�w��
            writer.Write(temp.GoodsRateRank);
            //���i����
            writer.Write(temp.GoodsKindCode);
            //�ېŋ敪
            writer.Write(temp.TaxationDivCd);
            //���i���l�P
            writer.Write(temp.GoodsNote1);
            //���i���l�Q
            writer.Write(temp.GoodsNote2);
            //���i�K�i�E���L����
            writer.Write(temp.GoodsSpecialNote);
            //���i�J�n�N�����P
            writer.Write(temp.PriceStartDate1);
            //���i�P
            writer.Write(temp.ListPrice1);
            //�I�[�v�����i�敪�P
            writer.Write(temp.OpenPriceDiv1);
            //�d�����P
            writer.Write(temp.StockRate1);
            //���P���P
            writer.Write(temp.SalesUnitCost1);
            //���i�J�n�N�����Q
            writer.Write(temp.PriceStartDate2);
            //���i�Q
            writer.Write(temp.ListPrice2);
            //�I�[�v�����i�敪�Q
            writer.Write(temp.OpenPriceDiv2);
            //�d�����Q
            writer.Write(temp.StockRate2);
            //���P���Q
            writer.Write(temp.SalesUnitCost2);
            //���i�J�n�N�����R
            writer.Write(temp.PriceStartDate3);
            //���i�R
            writer.Write(temp.ListPrice3);
            //�I�[�v�����i�敪�R
            writer.Write(temp.OpenPriceDiv3);
            //�d�����R
            writer.Write(temp.StockRate3);
            //���P���R
            writer.Write(temp.SalesUnitCost3);
            //���i�J�n�N�����S
            writer.Write(temp.PriceStartDate4);
            //���i�S
            writer.Write(temp.ListPrice4);
            //�I�[�v�����i�敪�S
            writer.Write(temp.OpenPriceDiv4);
            //�d�����S
            writer.Write(temp.StockRate4);
            //���P���S
            writer.Write(temp.SalesUnitCost4);
            //���i�J�n�N�����S
            writer.Write(temp.PriceStartDate5);
            //���i�S
            writer.Write(temp.ListPrice5);
            //�I�[�v�����i�敪�S
            writer.Write(temp.OpenPriceDiv5);
            //�d�����S
            writer.Write(temp.StockRate5);
            //���P���S
            writer.Write(temp.SalesUnitCost5);
            //�G���[���O
            writer.Write(temp.ErrorMsg);

        }

        /// <summary>
        ///  GoodsUGoodsPriceUWork�C���X�^���X�擾
        /// </summary>
        /// <returns>GoodsUGoodsPriceUWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsUGoodsPriceUWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private GoodsUGoodsPriceUWork GetGoodsUGoodsPriceUWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            GoodsUGoodsPriceUWork temp = new GoodsUGoodsPriceUWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadString();
            //���i����
            temp.GoodsName = reader.ReadString();
            //���i���̃J�i
            temp.GoodsNameKana = reader.ReadString();
            //JAN�R�[�h
            temp.Jan = reader.ReadString();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadString();
            //���i�敪�R�[�h
            temp.EnterpriseGanreCode = reader.ReadString();
            //�w��
            temp.GoodsRateRank = reader.ReadString();
            //���i����
            temp.GoodsKindCode = reader.ReadString();
            //�ېŋ敪
            temp.TaxationDivCd = reader.ReadString();
            //���i���l�P
            temp.GoodsNote1 = reader.ReadString();
            //���i���l�Q
            temp.GoodsNote2 = reader.ReadString();
            //���i�K�i�E���L����
            temp.GoodsSpecialNote = reader.ReadString();
            //���i�J�n�N�����P
            temp.PriceStartDate1 = reader.ReadString();
            //���i�P
            temp.ListPrice1 = reader.ReadString();
            //�I�[�v�����i�敪�P
            temp.OpenPriceDiv1 = reader.ReadString();
            //�d�����P
            temp.StockRate1 = reader.ReadString();
            //���P���P
            temp.SalesUnitCost1 = reader.ReadString();
            //���i�J�n�N�����Q
            temp.PriceStartDate2 = reader.ReadString();
            //���i�Q
            temp.ListPrice2 = reader.ReadString();
            //�I�[�v�����i�敪�Q
            temp.OpenPriceDiv2 = reader.ReadString();
            //�d�����Q
            temp.StockRate2 = reader.ReadString();
            //���P���Q
            temp.SalesUnitCost2 = reader.ReadString();
            //���i�J�n�N�����R
            temp.PriceStartDate3 = reader.ReadString();
            //���i�R
            temp.ListPrice3 = reader.ReadString();
            //�I�[�v�����i�敪�R
            temp.OpenPriceDiv3 = reader.ReadString();
            //�d�����R
            temp.StockRate3 = reader.ReadString();
            //���P���R
            temp.SalesUnitCost3 = reader.ReadString();
            //���i�J�n�N�����S
            temp.PriceStartDate4 = reader.ReadString();
            //���i�S
            temp.ListPrice4 = reader.ReadString();
            //�I�[�v�����i�敪�S
            temp.OpenPriceDiv4 = reader.ReadString();
            //�d�����S
            temp.StockRate4 = reader.ReadString();
            //���P���S
            temp.SalesUnitCost4 = reader.ReadString();
            //���i�J�n�N�����S
            temp.PriceStartDate5 = reader.ReadString();
            //���i�S
            temp.ListPrice5 = reader.ReadString();
            //�I�[�v�����i�敪�S
            temp.OpenPriceDiv5 = reader.ReadString();
            //�d�����S
            temp.StockRate5 = reader.ReadString();
            //���P���S
            temp.SalesUnitCost5 = reader.ReadString();
            //�G���[���O
            temp.ErrorMsg = reader.ReadString();


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
        /// <returns>GoodsUGoodsPriceUWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsUGoodsPriceUWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                GoodsUGoodsPriceUWork temp = GetGoodsUGoodsPriceUWork(reader, serInfo);
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
                    retValue = (GoodsUGoodsPriceUWork[])lst.ToArray(typeof(GoodsUGoodsPriceUWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
