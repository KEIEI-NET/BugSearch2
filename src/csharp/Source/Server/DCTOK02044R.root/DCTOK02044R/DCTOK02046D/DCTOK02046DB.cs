using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalStcCompReportResultWork
    /// <summary>
    ///                      ����d���Δ�\(���񌎕�)���o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����d���Δ�\(���񌎕�)���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalStcCompReportResultWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        private string _secCode = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���[�󎚗p</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";

        /// <summary>������z(���v���)</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂ށj</remarks>
        private Int64 _salesMoney;

        /// <summary>������z(���v�݌�)</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂ށj</remarks>
        private Int64 _salesMoneyStock;

        /// <summary>�������z�v(���v)</summary>
        private Int64 _totalCost;

        /// <summary>�ړ���(���v����)</summary>
        private Double _moveCountSales;

        /// <summary>�d���P���i���v����j</summary>
        /// <remarks>�݌Ɉړ�����݌ɂ̎d�����i�����Z�b�g</remarks>
        private Double _stockUnitPriceFlSales;

        /// <summary>�ړ����z(���v����)</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂ށj</remarks>
        private Int64 _stockMovePriceSales;

        /// <summary>�d�����z(���v���)</summary>
        private Int64 _stockPriceTaxExc;

        /// <summary>�d�����z(���v�݌�)</summary>
        private Int64 _stockPriceTaxExcStock;

        /// <summary>�ړ���(���v�d��)</summary>
        private Double _moveCountSalesSlip;

        /// <summary>�d���P���i���v�d���j</summary>
        /// <remarks>�݌Ɉړ�����݌ɂ̎d�����i�����Z�b�g</remarks>
        private Double _stockUnitPriceFlSalesSlip;

        /// <summary>�ړ����z(���v�d��)</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂ށj</remarks>
        private Int64 _stockMovePriceSlip;

        /// <summary>������z(�݌v���)</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂ށj</remarks>
        private Int64 _monthSalesMoney;

        /// <summary>������z(�݌v�݌�)</summary>
        private Int64 _monthSalesMoneyStock;

        /// <summary>�������z�v(�݌v)</summary>
        private Int64 _monthTotalCost;

        /// <summary>�ړ���(�݌v����)</summary>
        /// <remarks>�݌Ɉړ�����݌ɂ̎d�����i�����Z�b�g</remarks>
        private Double _monthMoveCountSales;

        /// <summary>�d���P���i�݌v����j</summary>
        private Double _monthStockUnitPriceFlSales;

        /// <summary>�ړ����z(�݌v����)</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂ށj</remarks>
        private Int64 _monthStockMovePriceSales;

        /// <summary>�d�����z(�݌v���)</summary>
        private Int64 _monthStockPriceTaxExc;

        /// <summary>�d�����z(�݌v�݌�)</summary>
        private Int64 _monthStockPriceTaxExcStock;

        /// <summary>�ړ���(�݌v�d��)</summary>
        /// <remarks>�݌Ɉړ�����݌ɂ̎d�����i�����Z�b�g</remarks>
        private Double _monthMoveCountSalesSlip;

        /// <summary>�d���P���i�݌v�d���j</summary>
        private Double _monthStockUnitPriceFlSalesSlip;

        /// <summary>�ړ����z(�݌v�d��)</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂ށj</remarks>
        private Int64 _monthStockMovePriceSlip;


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

        /// public propaty name  :  SecCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SecCode
        {
            get { return _secCode; }
            set { _secCode = value; }
        }

        /// public propaty name  :  SectionGuideSnm
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// <value>���[�󎚗p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>�d���旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  SalesMoney
        /// <summary>������z(���v���)�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂ށj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z(���v���)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoney
        {
            get { return _salesMoney; }
            set { _salesMoney = value; }
        }

        /// public propaty name  :  SalesMoneyStock
        /// <summary>������z(���v�݌�)�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂ށj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z(���v�݌�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyStock
        {
            get { return _salesMoneyStock; }
            set { _salesMoneyStock = value; }
        }

        /// public propaty name  :  TotalCost
        /// <summary>�������z�v(���v)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z�v(���v)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalCost
        {
            get { return _totalCost; }
            set { _totalCost = value; }
        }

        /// public propaty name  :  MoveCountSales
        /// <summary>�ړ���(���v����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ���(���v����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MoveCountSales
        {
            get { return _moveCountSales; }
            set { _moveCountSales = value; }
        }

        /// public propaty name  :  StockUnitPriceFlSales
        /// <summary>�d���P���i���v����j�v���p�e�B</summary>
        /// <value>�݌Ɉړ�����݌ɂ̎d�����i�����Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���i���v����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockUnitPriceFlSales
        {
            get { return _stockUnitPriceFlSales; }
            set { _stockUnitPriceFlSales = value; }
        }

        /// public propaty name  :  StockMovePriceSales
        /// <summary>�ړ����z(���v����)�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂ށj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����z(���v����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockMovePriceSales
        {
            get { return _stockMovePriceSales; }
            set { _stockMovePriceSales = value; }
        }

        /// public propaty name  :  StockPriceTaxExc
        /// <summary>�d�����z(���v���)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z(���v���)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockPriceTaxExc
        {
            get { return _stockPriceTaxExc; }
            set { _stockPriceTaxExc = value; }
        }

        /// public propaty name  :  StockPriceTaxExcStock
        /// <summary>�d�����z(���v�݌�)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z(���v�݌�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockPriceTaxExcStock
        {
            get { return _stockPriceTaxExcStock; }
            set { _stockPriceTaxExcStock = value; }
        }

        /// public propaty name  :  MoveCountSalesSlip
        /// <summary>�ړ���(���v�d��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ���(���v�d��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MoveCountSalesSlip
        {
            get { return _moveCountSalesSlip; }
            set { _moveCountSalesSlip = value; }
        }

        /// public propaty name  :  StockUnitPriceFlSalesSlip
        /// <summary>�d���P���i���v�d���j�v���p�e�B</summary>
        /// <value>�݌Ɉړ�����݌ɂ̎d�����i�����Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���i���v�d���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockUnitPriceFlSalesSlip
        {
            get { return _stockUnitPriceFlSalesSlip; }
            set { _stockUnitPriceFlSalesSlip = value; }
        }

        /// public propaty name  :  StockMovePriceSlip
        /// <summary>�ړ����z(���v�d��)�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂ށj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����z(���v�d��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockMovePriceSlip
        {
            get { return _stockMovePriceSlip; }
            set { _stockMovePriceSlip = value; }
        }

        /// public propaty name  :  MonthSalesMoney
        /// <summary>������z(�݌v���)�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂ށj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z(�݌v���)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthSalesMoney
        {
            get { return _monthSalesMoney; }
            set { _monthSalesMoney = value; }
        }

        /// public propaty name  :  MonthSalesMoneyStock
        /// <summary>������z(�݌v�݌�)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z(�݌v�݌�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthSalesMoneyStock
        {
            get { return _monthSalesMoneyStock; }
            set { _monthSalesMoneyStock = value; }
        }

        /// public propaty name  :  MonthTotalCost
        /// <summary>�������z�v(�݌v)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z�v(�݌v)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthTotalCost
        {
            get { return _monthTotalCost; }
            set { _monthTotalCost = value; }
        }

        /// public propaty name  :  MonthMoveCountSales
        /// <summary>�ړ���(�݌v����)�v���p�e�B</summary>
        /// <value>�݌Ɉړ�����݌ɂ̎d�����i�����Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ���(�݌v����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MonthMoveCountSales
        {
            get { return _monthMoveCountSales; }
            set { _monthMoveCountSales = value; }
        }

        /// public propaty name  :  MonthStockUnitPriceFlSales
        /// <summary>�d���P���i�݌v����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���i�݌v����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MonthStockUnitPriceFlSales
        {
            get { return _monthStockUnitPriceFlSales; }
            set { _monthStockUnitPriceFlSales = value; }
        }

        /// public propaty name  :  MonthStockMovePriceSales
        /// <summary>�ړ����z(�݌v����)�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂ށj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����z(�݌v����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthStockMovePriceSales
        {
            get { return _monthStockMovePriceSales; }
            set { _monthStockMovePriceSales = value; }
        }

        /// public propaty name  :  MonthStockPriceTaxExc
        /// <summary>�d�����z(�݌v���)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z(�݌v���)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthStockPriceTaxExc
        {
            get { return _monthStockPriceTaxExc; }
            set { _monthStockPriceTaxExc = value; }
        }

        /// public propaty name  :  MonthStockPriceTaxExcStock
        /// <summary>�d�����z(�݌v�݌�)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z(�݌v�݌�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthStockPriceTaxExcStock
        {
            get { return _monthStockPriceTaxExcStock; }
            set { _monthStockPriceTaxExcStock = value; }
        }

        /// public propaty name  :  MonthMoveCountSalesSlip
        /// <summary>�ړ���(�݌v�d��)�v���p�e�B</summary>
        /// <value>�݌Ɉړ�����݌ɂ̎d�����i�����Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ���(�݌v�d��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MonthMoveCountSalesSlip
        {
            get { return _monthMoveCountSalesSlip; }
            set { _monthMoveCountSalesSlip = value; }
        }

        /// public propaty name  :  MonthStockUnitPriceFlSalesSlip
        /// <summary>�d���P���i�݌v�d���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���i�݌v�d���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MonthStockUnitPriceFlSalesSlip
        {
            get { return _monthStockUnitPriceFlSalesSlip; }
            set { _monthStockUnitPriceFlSalesSlip = value; }
        }

        /// public propaty name  :  MonthStockMovePriceSlip
        /// <summary>�ړ����z(�݌v�d��)�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂ށj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����z(�݌v�d��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthStockMovePriceSlip
        {
            get { return _monthStockMovePriceSlip; }
            set { _monthStockMovePriceSlip = value; }
        }


        /// <summary>
        /// ����d���Δ�\(���񌎕�)���o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SalStcCompReportResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalStcCompReportResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalStcCompReportResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SalStcCompReportResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SalStcCompReportResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SalStcCompReportResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalStcCompReportResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalStcCompReportResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalStcCompReportResultWork || graph is ArrayList || graph is SalStcCompReportResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SalStcCompReportResultWork).FullName));

            if (graph != null && graph is SalStcCompReportResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalStcCompReportResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalStcCompReportResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalStcCompReportResultWork[])graph).Length;
            }
            else if (graph is SalStcCompReportResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SecCode
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //������z(���v���)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney
            //������z(���v�݌�)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyStock
            //�������z�v(���v)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalCost
            //�ړ���(���v����)
            serInfo.MemberInfo.Add(typeof(Double)); //MoveCountSales
            //�d���P���i���v����j
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFlSales
            //�ړ����z(���v����)
            serInfo.MemberInfo.Add(typeof(Int64)); //StockMovePriceSales
            //�d�����z(���v���)
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxExc
            //�d�����z(���v�݌�)
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxExcStock
            //�ړ���(���v�d��)
            serInfo.MemberInfo.Add(typeof(Double)); //MoveCountSalesSlip
            //�d���P���i���v�d���j
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFlSalesSlip
            //�ړ����z(���v�d��)
            serInfo.MemberInfo.Add(typeof(Int64)); //StockMovePriceSlip
            //������z(�݌v���)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesMoney
            //������z(�݌v�݌�)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesMoneyStock
            //�������z�v(�݌v)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthTotalCost
            //�ړ���(�݌v����)
            serInfo.MemberInfo.Add(typeof(Double)); //MonthMoveCountSales
            //�d���P���i�݌v����j
            serInfo.MemberInfo.Add(typeof(Double)); //MonthStockUnitPriceFlSales
            //�ړ����z(�݌v����)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthStockMovePriceSales
            //�d�����z(�݌v���)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthStockPriceTaxExc
            //�d�����z(�݌v�݌�)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthStockPriceTaxExcStock
            //�ړ���(�݌v�d��)
            serInfo.MemberInfo.Add(typeof(Double)); //MonthMoveCountSalesSlip
            //�d���P���i�݌v�d���j
            serInfo.MemberInfo.Add(typeof(Double)); //MonthStockUnitPriceFlSalesSlip
            //�ړ����z(�݌v�d��)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthStockMovePriceSlip


            serInfo.Serialize(writer, serInfo);
            if (graph is SalStcCompReportResultWork)
            {
                SalStcCompReportResultWork temp = (SalStcCompReportResultWork)graph;

                SetSalStcCompReportResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalStcCompReportResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalStcCompReportResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalStcCompReportResultWork temp in lst)
                {
                    SetSalStcCompReportResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalStcCompReportResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 27;

        /// <summary>
        ///  SalStcCompReportResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalStcCompReportResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSalStcCompReportResultWork(System.IO.BinaryWriter writer, SalStcCompReportResultWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //���_�R�[�h
            writer.Write(temp.SecCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideSnm);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //������z(���v���)
            writer.Write(temp.SalesMoney);
            //������z(���v�݌�)
            writer.Write(temp.SalesMoneyStock);
            //�������z�v(���v)
            writer.Write(temp.TotalCost);
            //�ړ���(���v����)
            writer.Write(temp.MoveCountSales);
            //�d���P���i���v����j
            writer.Write(temp.StockUnitPriceFlSales);
            //�ړ����z(���v����)
            writer.Write(temp.StockMovePriceSales);
            //�d�����z(���v���)
            writer.Write(temp.StockPriceTaxExc);
            //�d�����z(���v�݌�)
            writer.Write(temp.StockPriceTaxExcStock);
            //�ړ���(���v�d��)
            writer.Write(temp.MoveCountSalesSlip);
            //�d���P���i���v�d���j
            writer.Write(temp.StockUnitPriceFlSalesSlip);
            //�ړ����z(���v�d��)
            writer.Write(temp.StockMovePriceSlip);
            //������z(�݌v���)
            writer.Write(temp.MonthSalesMoney);
            //������z(�݌v�݌�)
            writer.Write(temp.MonthSalesMoneyStock);
            //�������z�v(�݌v)
            writer.Write(temp.MonthTotalCost);
            //�ړ���(�݌v����)
            writer.Write(temp.MonthMoveCountSales);
            //�d���P���i�݌v����j
            writer.Write(temp.MonthStockUnitPriceFlSales);
            //�ړ����z(�݌v����)
            writer.Write(temp.MonthStockMovePriceSales);
            //�d�����z(�݌v���)
            writer.Write(temp.MonthStockPriceTaxExc);
            //�d�����z(�݌v�݌�)
            writer.Write(temp.MonthStockPriceTaxExcStock);
            //�ړ���(�݌v�d��)
            writer.Write(temp.MonthMoveCountSalesSlip);
            //�d���P���i�݌v�d���j
            writer.Write(temp.MonthStockUnitPriceFlSalesSlip);
            //�ړ����z(�݌v�d��)
            writer.Write(temp.MonthStockMovePriceSlip);

        }

        /// <summary>
        ///  SalStcCompReportResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SalStcCompReportResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalStcCompReportResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SalStcCompReportResultWork GetSalStcCompReportResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SalStcCompReportResultWork temp = new SalStcCompReportResultWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //���_�R�[�h
            temp.SecCode = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideSnm = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //������z(���v���)
            temp.SalesMoney = reader.ReadInt64();
            //������z(���v�݌�)
            temp.SalesMoneyStock = reader.ReadInt64();
            //�������z�v(���v)
            temp.TotalCost = reader.ReadInt64();
            //�ړ���(���v����)
            temp.MoveCountSales = reader.ReadDouble();
            //�d���P���i���v����j
            temp.StockUnitPriceFlSales = reader.ReadDouble();
            //�ړ����z(���v����)
            temp.StockMovePriceSales = reader.ReadInt64();
            //�d�����z(���v���)
            temp.StockPriceTaxExc = reader.ReadInt64();
            //�d�����z(���v�݌�)
            temp.StockPriceTaxExcStock = reader.ReadInt64();
            //�ړ���(���v�d��)
            temp.MoveCountSalesSlip = reader.ReadDouble();
            //�d���P���i���v�d���j
            temp.StockUnitPriceFlSalesSlip = reader.ReadDouble();
            //�ړ����z(���v�d��)
            temp.StockMovePriceSlip = reader.ReadInt64();
            //������z(�݌v���)
            temp.MonthSalesMoney = reader.ReadInt64();
            //������z(�݌v�݌�)
            temp.MonthSalesMoneyStock = reader.ReadInt64();
            //�������z�v(�݌v)
            temp.MonthTotalCost = reader.ReadInt64();
            //�ړ���(�݌v����)
            temp.MonthMoveCountSales = reader.ReadDouble();
            //�d���P���i�݌v����j
            temp.MonthStockUnitPriceFlSales = reader.ReadDouble();
            //�ړ����z(�݌v����)
            temp.MonthStockMovePriceSales = reader.ReadInt64();
            //�d�����z(�݌v���)
            temp.MonthStockPriceTaxExc = reader.ReadInt64();
            //�d�����z(�݌v�݌�)
            temp.MonthStockPriceTaxExcStock = reader.ReadInt64();
            //�ړ���(�݌v�d��)
            temp.MonthMoveCountSalesSlip = reader.ReadDouble();
            //�d���P���i�݌v�d���j
            temp.MonthStockUnitPriceFlSalesSlip = reader.ReadDouble();
            //�ړ����z(�݌v�d��)
            temp.MonthStockMovePriceSlip = reader.ReadInt64();


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
        /// <returns>SalStcCompReportResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalStcCompReportResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalStcCompReportResultWork temp = GetSalStcCompReportResultWork(reader, serInfo);
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
                    retValue = (SalStcCompReportResultWork[])lst.ToArray(typeof(SalStcCompReportResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
