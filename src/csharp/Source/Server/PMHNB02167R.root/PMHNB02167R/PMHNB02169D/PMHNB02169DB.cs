using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesHistAnalyzeResultWork
    /// <summary>
    ///                      ������e���͕\���o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ������e���͕\���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/05  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesHistAnalyzeResultWork 
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        private string _secCode = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���[�󎚗p</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>�̔��]�ƈ��R�[�h</summary>
        /// <remarks>�v��S���ҁi�S���ҁj</remarks>
        private string _salesEmployeeCd = "";

        /// <summary>�̔��]�ƈ�����</summary>
        private string _salesEmployeeNm = "";

        /// <summary>�̔��G���A�R�[�h</summary>
        /// <remarks>�n��R�[�h</remarks>
        private Int32 _salesAreaCode;

        /// <summary>�̔��G���A����</summary>
        private string _salesAreaName = "";

        /// <summary>������z(���v���)</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂ށj</remarks>
        private Int64 _salesMoneyOrder;

        /// <summary>������z(���v�݌�)</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂ށj</remarks>
        private Int64 _salesMoneyStock;

        /// <summary>������z(���v����)</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂ށj</remarks>
        private Int64 _salesMoneyGenuine;

        /// <summary>������z(���v�D��)</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂ށj</remarks>
        private Int64 _salesMoneyPrm;

        /// <summary>������z(���v�O��)</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂ށj</remarks>
        private Int64 _salesMoneyOutside;

        /// <summary>������z(���v���̑�)</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂ށj</remarks>
        private Int64 _salesMoneyOther;

        /// <summary>�e�����z(���v���)</summary>
        private Int64 _grossProfitOrder;

        /// <summary>�e�����z(���v�݌�)</summary>
        private Int64 _grossProfitStock;

        /// <summary>�e�����z(���v����)</summary>
        private Int64 _grossProfitGenuine;

        /// <summary>�e�����z(���v�D��)</summary>
        private Int64 _grossProfitPrm;

        /// <summary>�e�����z(���v�O��)</summary>
        private Int64 _grossProfitOutside;

        /// <summary>�e�����z(���v���̑�)</summary>
        private Int64 _grossProfitOther;

        /// <summary>������z(�݌v���)</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂ށj</remarks>
        private Int64 _monthSalesMoneyOrder;

        /// <summary>������z(�݌v�݌�)</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂ށj</remarks>
        private Int64 _monthSalesMoneyStock;

        /// <summary>������z(�݌v����)</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂ށj</remarks>
        private Int64 _monthSalesMoneyGenuine;

        /// <summary>������z(�݌v�D��)</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂ށj</remarks>
        private Int64 _monthSalesMoneyPrm;

        /// <summary>������z(�݌v�O��)</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂ށj</remarks>
        private Int64 _monthSalesMoneyOutside;

        /// <summary>������z(�݌v���̑�)</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂ށj</remarks>
        private Int64 _monthSalesMoneyOther;

        /// <summary>�e�����z(�݌v���)</summary>
        private Int64 _monthGrossProfitOrder;

        /// <summary>�e�����z(�݌v�݌�)</summary>
        private Int64 _monthGrossProfitStock;

        /// <summary>�e�����z(�݌v����)</summary>
        private Int64 _monthGrossProfitGenuine;

        /// <summary>�e�����z(�݌v�D��)</summary>
        private Int64 _monthGrossProfitPrm;

        /// <summary>�e�����z(�݌v�O��)</summary>
        private Int64 _monthGrossProfitOutside;

        /// <summary>�e�����z(�݌v���̑�)</summary>
        private Int64 _monthGrossProfitOther;


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

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  CustomerSnm
        /// <summary>���Ӑ旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  SalesEmployeeCd
        /// <summary>�̔��]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�v��S���ҁi�S���ҁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesEmployeeCd
        {
            get { return _salesEmployeeCd; }
            set { _salesEmployeeCd = value; }
        }

        /// public propaty name  :  SalesEmployeeNm
        /// <summary>�̔��]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesEmployeeNm
        {
            get { return _salesEmployeeNm; }
            set { _salesEmployeeNm = value; }
        }

        /// public propaty name  :  SalesAreaCode
        /// <summary>�̔��G���A�R�[�h�v���p�e�B</summary>
        /// <value>�n��R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  SalesAreaName
        /// <summary>�̔��G���A���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesAreaName
        {
            get { return _salesAreaName; }
            set { _salesAreaName = value; }
        }

        /// public propaty name  :  SalesMoneyOrder
        /// <summary>������z(���v���)�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂ށj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z(���v���)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyOrder
        {
            get { return _salesMoneyOrder; }
            set { _salesMoneyOrder = value; }
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

        /// public propaty name  :  SalesMoneyGenuine
        /// <summary>������z(���v����)�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂ށj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z(���v����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyGenuine
        {
            get { return _salesMoneyGenuine; }
            set { _salesMoneyGenuine = value; }
        }

        /// public propaty name  :  SalesMoneyPrm
        /// <summary>������z(���v�D��)�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂ށj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z(���v�D��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyPrm
        {
            get { return _salesMoneyPrm; }
            set { _salesMoneyPrm = value; }
        }

        /// public propaty name  :  SalesMoneyOutside
        /// <summary>������z(���v�O��)�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂ށj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z(���v�O��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyOutside
        {
            get { return _salesMoneyOutside; }
            set { _salesMoneyOutside = value; }
        }

        /// public propaty name  :  SalesMoneyOther
        /// <summary>������z(���v���̑�)�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂ށj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z(���v���̑�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyOther
        {
            get { return _salesMoneyOther; }
            set { _salesMoneyOther = value; }
        }

        /// public propaty name  :  GrossProfitOrder
        /// <summary>�e�����z(���v���)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�����z(���v���)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 GrossProfitOrder
        {
            get { return _grossProfitOrder; }
            set { _grossProfitOrder = value; }
        }

        /// public propaty name  :  GrossProfitStock
        /// <summary>�e�����z(���v�݌�)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�����z(���v�݌�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 GrossProfitStock
        {
            get { return _grossProfitStock; }
            set { _grossProfitStock = value; }
        }

        /// public propaty name  :  GrossProfitGenuine
        /// <summary>�e�����z(���v����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�����z(���v����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 GrossProfitGenuine
        {
            get { return _grossProfitGenuine; }
            set { _grossProfitGenuine = value; }
        }

        /// public propaty name  :  GrossProfitPrm
        /// <summary>�e�����z(���v�D��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�����z(���v�D��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 GrossProfitPrm
        {
            get { return _grossProfitPrm; }
            set { _grossProfitPrm = value; }
        }

        /// public propaty name  :  GrossProfitOutside
        /// <summary>�e�����z(���v�O��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�����z(���v�O��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 GrossProfitOutside
        {
            get { return _grossProfitOutside; }
            set { _grossProfitOutside = value; }
        }

        /// public propaty name  :  GrossProfitOther
        /// <summary>�e�����z(���v���̑�)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�����z(���v���̑�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 GrossProfitOther
        {
            get { return _grossProfitOther; }
            set { _grossProfitOther = value; }
        }

        /// public propaty name  :  MonthSalesMoneyOrder
        /// <summary>������z(�݌v���)�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂ށj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z(�݌v���)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthSalesMoneyOrder
        {
            get { return _monthSalesMoneyOrder; }
            set { _monthSalesMoneyOrder = value; }
        }

        /// public propaty name  :  MonthSalesMoneyStock
        /// <summary>������z(�݌v�݌�)�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂ށj</value>
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

        /// public propaty name  :  MonthSalesMoneyGenuine
        /// <summary>������z(�݌v����)�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂ށj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z(�݌v����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthSalesMoneyGenuine
        {
            get { return _monthSalesMoneyGenuine; }
            set { _monthSalesMoneyGenuine = value; }
        }

        /// public propaty name  :  MonthSalesMoneyPrm
        /// <summary>������z(�݌v�D��)�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂ށj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z(�݌v�D��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthSalesMoneyPrm
        {
            get { return _monthSalesMoneyPrm; }
            set { _monthSalesMoneyPrm = value; }
        }

        /// public propaty name  :  MonthSalesMoneyOutside
        /// <summary>������z(�݌v�O��)�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂ށj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z(�݌v�O��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthSalesMoneyOutside
        {
            get { return _monthSalesMoneyOutside; }
            set { _monthSalesMoneyOutside = value; }
        }

        /// public propaty name  :  MonthSalesMoneyOther
        /// <summary>������z(�݌v���̑�)�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂ށj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z(�݌v���̑�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthSalesMoneyOther
        {
            get { return _monthSalesMoneyOther; }
            set { _monthSalesMoneyOther = value; }
        }

        /// public propaty name  :  MonthGrossProfitOrder
        /// <summary>�e�����z(�݌v���)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�����z(�݌v���)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthGrossProfitOrder
        {
            get { return _monthGrossProfitOrder; }
            set { _monthGrossProfitOrder = value; }
        }

        /// public propaty name  :  MonthGrossProfitStock
        /// <summary>�e�����z(�݌v�݌�)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�����z(�݌v�݌�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthGrossProfitStock
        {
            get { return _monthGrossProfitStock; }
            set { _monthGrossProfitStock = value; }
        }

        /// public propaty name  :  MonthGrossProfitGenuine
        /// <summary>�e�����z(�݌v����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�����z(�݌v����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthGrossProfitGenuine
        {
            get { return _monthGrossProfitGenuine; }
            set { _monthGrossProfitGenuine = value; }
        }

        /// public propaty name  :  MonthGrossProfitPrm
        /// <summary>�e�����z(�݌v�D��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�����z(�݌v�D��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthGrossProfitPrm
        {
            get { return _monthGrossProfitPrm; }
            set { _monthGrossProfitPrm = value; }
        }

        /// public propaty name  :  MonthGrossProfitOutside
        /// <summary>�e�����z(�݌v�O��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�����z(�݌v�O��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthGrossProfitOutside
        {
            get { return _monthGrossProfitOutside; }
            set { _monthGrossProfitOutside = value; }
        }

        /// public propaty name  :  MonthGrossProfitOther
        /// <summary>�e�����z(�݌v���̑�)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�����z(�݌v���̑�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthGrossProfitOther
        {
            get { return _monthGrossProfitOther; }
            set { _monthGrossProfitOther = value; }
        }


        /// <summary>
        /// ������e���͕\���o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SalesHistAnalyzeResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesHistAnalyzeResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesHistAnalyzeResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SalesHistAnalyzeResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SalesHistAnalyzeResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SalesHistAnalyzeResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesHistAnalyzeResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalesHistAnalyzeResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalesHistAnalyzeResultWork || graph is ArrayList || graph is SalesHistAnalyzeResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SalesHistAnalyzeResultWork).FullName));

            if (graph != null && graph is SalesHistAnalyzeResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalesHistAnalyzeResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalesHistAnalyzeResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalesHistAnalyzeResultWork[])graph).Length;
            }
            else if (graph is SalesHistAnalyzeResultWork)
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
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ旪��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //�̔��]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeCd
            //�̔��]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeNm
            //�̔��G���A�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //�̔��G���A����
            serInfo.MemberInfo.Add(typeof(string)); //SalesAreaName
            //������z(���v���)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyOrder
            //������z(���v�݌�)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyStock
            //������z(���v����)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyGenuine
            //������z(���v�D��)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyPrm
            //������z(���v�O��)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyOutside
            //������z(���v���̑�)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyOther
            //�e�����z(���v���)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfitOrder
            //�e�����z(���v�݌�)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfitStock
            //�e�����z(���v����)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfitGenuine
            //�e�����z(���v�D��)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfitPrm
            //�e�����z(���v�O��)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfitOutside
            //�e�����z(���v���̑�)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfitOther
            //������z(�݌v���)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesMoneyOrder
            //������z(�݌v�݌�)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesMoneyStock
            //������z(�݌v����)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesMoneyGenuine
            //������z(�݌v�D��)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesMoneyPrm
            //������z(�݌v�O��)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesMoneyOutside
            //������z(�݌v���̑�)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesMoneyOther
            //�e�����z(�݌v���)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthGrossProfitOrder
            //�e�����z(�݌v�݌�)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthGrossProfitStock
            //�e�����z(�݌v����)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthGrossProfitGenuine
            //�e�����z(�݌v�D��)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthGrossProfitPrm
            //�e�����z(�݌v�O��)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthGrossProfitOutside
            //�e�����z(�݌v���̑�)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthGrossProfitOther


            serInfo.Serialize(writer, serInfo);
            if (graph is SalesHistAnalyzeResultWork)
            {
                SalesHistAnalyzeResultWork temp = (SalesHistAnalyzeResultWork)graph;

                SetSalesHistAnalyzeResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalesHistAnalyzeResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalesHistAnalyzeResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalesHistAnalyzeResultWork temp in lst)
                {
                    SetSalesHistAnalyzeResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalesHistAnalyzeResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 33;

        /// <summary>
        ///  SalesHistAnalyzeResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesHistAnalyzeResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSalesHistAnalyzeResultWork(System.IO.BinaryWriter writer, SalesHistAnalyzeResultWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //���_�R�[�h
            writer.Write(temp.SecCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideSnm);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ旪��
            writer.Write(temp.CustomerSnm);
            //�̔��]�ƈ��R�[�h
            writer.Write(temp.SalesEmployeeCd);
            //�̔��]�ƈ�����
            writer.Write(temp.SalesEmployeeNm);
            //�̔��G���A�R�[�h
            writer.Write(temp.SalesAreaCode);
            //�̔��G���A����
            writer.Write(temp.SalesAreaName);
            //������z(���v���)
            writer.Write(temp.SalesMoneyOrder);
            //������z(���v�݌�)
            writer.Write(temp.SalesMoneyStock);
            //������z(���v����)
            writer.Write(temp.SalesMoneyGenuine);
            //������z(���v�D��)
            writer.Write(temp.SalesMoneyPrm);
            //������z(���v�O��)
            writer.Write(temp.SalesMoneyOutside);
            //������z(���v���̑�)
            writer.Write(temp.SalesMoneyOther);
            //�e�����z(���v���)
            writer.Write(temp.GrossProfitOrder);
            //�e�����z(���v�݌�)
            writer.Write(temp.GrossProfitStock);
            //�e�����z(���v����)
            writer.Write(temp.GrossProfitGenuine);
            //�e�����z(���v�D��)
            writer.Write(temp.GrossProfitPrm);
            //�e�����z(���v�O��)
            writer.Write(temp.GrossProfitOutside);
            //�e�����z(���v���̑�)
            writer.Write(temp.GrossProfitOther);
            //������z(�݌v���)
            writer.Write(temp.MonthSalesMoneyOrder);
            //������z(�݌v�݌�)
            writer.Write(temp.MonthSalesMoneyStock);
            //������z(�݌v����)
            writer.Write(temp.MonthSalesMoneyGenuine);
            //������z(�݌v�D��)
            writer.Write(temp.MonthSalesMoneyPrm);
            //������z(�݌v�O��)
            writer.Write(temp.MonthSalesMoneyOutside);
            //������z(�݌v���̑�)
            writer.Write(temp.MonthSalesMoneyOther);
            //�e�����z(�݌v���)
            writer.Write(temp.MonthGrossProfitOrder);
            //�e�����z(�݌v�݌�)
            writer.Write(temp.MonthGrossProfitStock);
            //�e�����z(�݌v����)
            writer.Write(temp.MonthGrossProfitGenuine);
            //�e�����z(�݌v�D��)
            writer.Write(temp.MonthGrossProfitPrm);
            //�e�����z(�݌v�O��)
            writer.Write(temp.MonthGrossProfitOutside);
            //�e�����z(�݌v���̑�)
            writer.Write(temp.MonthGrossProfitOther);

        }

        /// <summary>
        ///  SalesHistAnalyzeResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SalesHistAnalyzeResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesHistAnalyzeResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SalesHistAnalyzeResultWork GetSalesHistAnalyzeResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SalesHistAnalyzeResultWork temp = new SalesHistAnalyzeResultWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //���_�R�[�h
            temp.SecCode = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideSnm = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ旪��
            temp.CustomerSnm = reader.ReadString();
            //�̔��]�ƈ��R�[�h
            temp.SalesEmployeeCd = reader.ReadString();
            //�̔��]�ƈ�����
            temp.SalesEmployeeNm = reader.ReadString();
            //�̔��G���A�R�[�h
            temp.SalesAreaCode = reader.ReadInt32();
            //�̔��G���A����
            temp.SalesAreaName = reader.ReadString();
            //������z(���v���)
            temp.SalesMoneyOrder = reader.ReadInt64();
            //������z(���v�݌�)
            temp.SalesMoneyStock = reader.ReadInt64();
            //������z(���v����)
            temp.SalesMoneyGenuine = reader.ReadInt64();
            //������z(���v�D��)
            temp.SalesMoneyPrm = reader.ReadInt64();
            //������z(���v�O��)
            temp.SalesMoneyOutside = reader.ReadInt64();
            //������z(���v���̑�)
            temp.SalesMoneyOther = reader.ReadInt64();
            //�e�����z(���v���)
            temp.GrossProfitOrder = reader.ReadInt64();
            //�e�����z(���v�݌�)
            temp.GrossProfitStock = reader.ReadInt64();
            //�e�����z(���v����)
            temp.GrossProfitGenuine = reader.ReadInt64();
            //�e�����z(���v�D��)
            temp.GrossProfitPrm = reader.ReadInt64();
            //�e�����z(���v�O��)
            temp.GrossProfitOutside = reader.ReadInt64();
            //�e�����z(���v���̑�)
            temp.GrossProfitOther = reader.ReadInt64();
            //������z(�݌v���)
            temp.MonthSalesMoneyOrder = reader.ReadInt64();
            //������z(�݌v�݌�)
            temp.MonthSalesMoneyStock = reader.ReadInt64();
            //������z(�݌v����)
            temp.MonthSalesMoneyGenuine = reader.ReadInt64();
            //������z(�݌v�D��)
            temp.MonthSalesMoneyPrm = reader.ReadInt64();
            //������z(�݌v�O��)
            temp.MonthSalesMoneyOutside = reader.ReadInt64();
            //������z(�݌v���̑�)
            temp.MonthSalesMoneyOther = reader.ReadInt64();
            //�e�����z(�݌v���)
            temp.MonthGrossProfitOrder = reader.ReadInt64();
            //�e�����z(�݌v�݌�)
            temp.MonthGrossProfitStock = reader.ReadInt64();
            //�e�����z(�݌v����)
            temp.MonthGrossProfitGenuine = reader.ReadInt64();
            //�e�����z(�݌v�D��)
            temp.MonthGrossProfitPrm = reader.ReadInt64();
            //�e�����z(�݌v�O��)
            temp.MonthGrossProfitOutside = reader.ReadInt64();
            //�e�����z(�݌v���̑�)
            temp.MonthGrossProfitOther = reader.ReadInt64();


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
        /// <returns>SalesHistAnalyzeResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesHistAnalyzeResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalesHistAnalyzeResultWork temp = GetSalesHistAnalyzeResultWork(reader, serInfo);
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
                    retValue = (SalesHistAnalyzeResultWork[])lst.ToArray(typeof(SalesHistAnalyzeResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
