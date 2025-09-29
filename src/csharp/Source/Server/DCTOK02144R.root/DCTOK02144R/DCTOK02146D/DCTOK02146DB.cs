using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesTransListResultWork
    /// <summary>
    ///                      ���㐄�ڕ\���o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���㐄�ڕ\���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/14  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesTransListResultWork
    {
        /// <summary>���_�R�[�h</summary>
        /// <remarks>�v�㋒�_�R�[�h</remarks>
        private string _addUpSecCode = "";

        /// <summary>���_����</summary>
        /// <remarks>���Ж���1</remarks>
        private string _companyName1 = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        private string _makerShortName = "";

        /// <summary>���i�啪�ރR�[�h</summary>
        private Int32 _goodsLGroup;

        /// <summary>���i�啪�ޖ���</summary>
        private string _goodsLGroupName = "";

        /// <summary>���i�����ރR�[�h</summary>
        private Int32 _goodsMGroup;

        /// <summary>���i�����ޖ���</summary>
        private string _goodsMGroupName = "";

        /// <summary>BL�O���[�v�R�[�h</summary>
        private Int32 _bLGroupCode;

        /// <summary>BL�O���[�v�R�[�h�J�i����</summary>
        private string _bLGroupKanaName = "";

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL���i�R�[�h���́i���p�j</summary>
        private string _bLGoodsHalfName = "";

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i����</summary>
        /// <remarks>���i���̃J�i</remarks>
        private string _goodsNameKana = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCode;

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";

        /// <summary>�]�ƈ��R�[�h</summary>
        private string _employeeCode = "";

        /// <summary>�]�ƈ�����</summary>
        private string _name = "";

        /// <summary>������z1</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂܂��j</remarks>
        private Int64 _salesMoney1;

        /// <summary>������z2</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂܂��j</remarks>
        private Int64 _salesMoney2;

        /// <summary>������z3</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂܂��j</remarks>
        private Int64 _salesMoney3;

        /// <summary>������z4</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂܂��j</remarks>
        private Int64 _salesMoney4;

        /// <summary>������z5</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂܂��j</remarks>
        private Int64 _salesMoney5;

        /// <summary>������z6</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂܂��j</remarks>
        private Int64 _salesMoney6;

        /// <summary>������z7</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂܂��j</remarks>
        private Int64 _salesMoney7;

        /// <summary>������z8</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂܂��j</remarks>
        private Int64 _salesMoney8;

        /// <summary>������z9</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂܂��j</remarks>
        private Int64 _salesMoney9;

        /// <summary>������z10</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂܂��j</remarks>
        private Int64 _salesMoney10;

        /// <summary>������z11</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂܂��j</remarks>
        private Int64 _salesMoney11;

        /// <summary>������z12</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂܂��j</remarks>
        private Int64 _salesMoney12;

        /// <summary>���㐔�v1</summary>
        /// <remarks>�o�א�(�ԕi�͌��Z)</remarks>
        private Double _totalSalesCount1;

        /// <summary>���㐔�v2</summary>
        /// <remarks>�o�א�(�ԕi�͌��Z)</remarks>
        private Double _totalSalesCount2;

        /// <summary>���㐔�v3</summary>
        /// <remarks>�o�א�(�ԕi�͌��Z)</remarks>
        private Double _totalSalesCount3;

        /// <summary>���㐔�v4</summary>
        /// <remarks>�o�א�(�ԕi�͌��Z)</remarks>
        private Double _totalSalesCount4;

        /// <summary>���㐔�v5</summary>
        /// <remarks>�o�א�(�ԕi�͌��Z)</remarks>
        private Double _totalSalesCount5;

        /// <summary>���㐔�v6</summary>
        /// <remarks>�o�א�(�ԕi�͌��Z)</remarks>
        private Double _totalSalesCount6;

        /// <summary>���㐔�v7</summary>
        /// <remarks>�o�א�(�ԕi�͌��Z)</remarks>
        private Double _totalSalesCount7;

        /// <summary>���㐔�v8</summary>
        /// <remarks>�o�א�(�ԕi�͌��Z)</remarks>
        private Double _totalSalesCount8;

        /// <summary>���㐔�v9</summary>
        /// <remarks>�o�א�(�ԕi�͌��Z)</remarks>
        private Double _totalSalesCount9;

        /// <summary>���㐔�v10</summary>
        /// <remarks>�o�א�(�ԕi�͌��Z)</remarks>
        private Double _totalSalesCount10;

        /// <summary>���㐔�v11</summary>
        /// <remarks>�o�א�(�ԕi�͌��Z)</remarks>
        private Double _totalSalesCount11;

        /// <summary>���㐔�v12</summary>
        /// <remarks>�o�א�(�ԕi�͌��Z)</remarks>
        private Double _totalSalesCount12;


        /// public propaty name  :  AddUpSecCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>�v�㋒�_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
        }

        /// public propaty name  :  CompanyName1
        /// <summary>���_���̃v���p�e�B</summary>
        /// <value>���Ж���1</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyName1
        {
            get { return _companyName1; }
            set { _companyName1 = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  MakerShortName
        /// <summary>���[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerShortName
        {
            get { return _makerShortName; }
            set { _makerShortName = value; }
        }

        /// public propaty name  :  GoodsLGroup
        /// <summary>���i�啪�ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�啪�ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsLGroup
        {
            get { return _goodsLGroup; }
            set { _goodsLGroup = value; }
        }

        /// public propaty name  :  GoodsLGroupName
        /// <summary>���i�啪�ޖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�啪�ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsLGroupName
        {
            get { return _goodsLGroupName; }
            set { _goodsLGroupName = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>���i�����ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  GoodsMGroupName
        /// <summary>���i�����ޖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsMGroupName
        {
            get { return _goodsMGroupName; }
            set { _goodsMGroupName = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BL�O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  BLGroupKanaName
        /// <summary>BL�O���[�v�R�[�h�J�i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h�J�i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGroupKanaName
        {
            get { return _bLGroupKanaName; }
            set { _bLGroupKanaName = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  BLGoodsHalfName
        /// <summary>BL���i�R�[�h���́i���p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i���p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsHalfName
        {
            get { return _bLGoodsHalfName; }
            set { _bLGoodsHalfName = value; }
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

        /// public propaty name  :  GoodsNameKana
        /// <summary>���i���̃v���p�e�B</summary>
        /// <value>���i���̃J�i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
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

        /// public propaty name  :  SupplierCode
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCode
        {
            get { return _supplierCode; }
            set { _supplierCode = value; }
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

        /// public propaty name  :  EmployeeCode
        /// <summary>�]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        /// public propaty name  :  Name
        /// <summary>�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// public propaty name  :  SalesMoney1
        /// <summary>������z1�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoney1
        {
            get { return _salesMoney1; }
            set { _salesMoney1 = value; }
        }

        /// public propaty name  :  SalesMoney2
        /// <summary>������z2�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoney2
        {
            get { return _salesMoney2; }
            set { _salesMoney2 = value; }
        }

        /// public propaty name  :  SalesMoney3
        /// <summary>������z3�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoney3
        {
            get { return _salesMoney3; }
            set { _salesMoney3 = value; }
        }

        /// public propaty name  :  SalesMoney4
        /// <summary>������z4�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoney4
        {
            get { return _salesMoney4; }
            set { _salesMoney4 = value; }
        }

        /// public propaty name  :  SalesMoney5
        /// <summary>������z5�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoney5
        {
            get { return _salesMoney5; }
            set { _salesMoney5 = value; }
        }

        /// public propaty name  :  SalesMoney6
        /// <summary>������z6�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoney6
        {
            get { return _salesMoney6; }
            set { _salesMoney6 = value; }
        }

        /// public propaty name  :  SalesMoney7
        /// <summary>������z7�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoney7
        {
            get { return _salesMoney7; }
            set { _salesMoney7 = value; }
        }

        /// public propaty name  :  SalesMoney8
        /// <summary>������z8�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoney8
        {
            get { return _salesMoney8; }
            set { _salesMoney8 = value; }
        }

        /// public propaty name  :  SalesMoney9
        /// <summary>������z9�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoney9
        {
            get { return _salesMoney9; }
            set { _salesMoney9 = value; }
        }

        /// public propaty name  :  SalesMoney10
        /// <summary>������z10�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoney10
        {
            get { return _salesMoney10; }
            set { _salesMoney10 = value; }
        }

        /// public propaty name  :  SalesMoney11
        /// <summary>������z11�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z11�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoney11
        {
            get { return _salesMoney11; }
            set { _salesMoney11 = value; }
        }

        /// public propaty name  :  SalesMoney12
        /// <summary>������z12�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z12�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoney12
        {
            get { return _salesMoney12; }
            set { _salesMoney12 = value; }
        }

        /// public propaty name  :  TotalSalesCount1
        /// <summary>���㐔�v1�v���p�e�B</summary>
        /// <value>�o�א�(�ԕi�͌��Z)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㐔�v1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalSalesCount1
        {
            get { return _totalSalesCount1; }
            set { _totalSalesCount1 = value; }
        }

        /// public propaty name  :  TotalSalesCount2
        /// <summary>���㐔�v2�v���p�e�B</summary>
        /// <value>�o�א�(�ԕi�͌��Z)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㐔�v2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalSalesCount2
        {
            get { return _totalSalesCount2; }
            set { _totalSalesCount2 = value; }
        }

        /// public propaty name  :  TotalSalesCount3
        /// <summary>���㐔�v3�v���p�e�B</summary>
        /// <value>�o�א�(�ԕi�͌��Z)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㐔�v3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalSalesCount3
        {
            get { return _totalSalesCount3; }
            set { _totalSalesCount3 = value; }
        }

        /// public propaty name  :  TotalSalesCount4
        /// <summary>���㐔�v4�v���p�e�B</summary>
        /// <value>�o�א�(�ԕi�͌��Z)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㐔�v4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalSalesCount4
        {
            get { return _totalSalesCount4; }
            set { _totalSalesCount4 = value; }
        }

        /// public propaty name  :  TotalSalesCount5
        /// <summary>���㐔�v5�v���p�e�B</summary>
        /// <value>�o�א�(�ԕi�͌��Z)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㐔�v5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalSalesCount5
        {
            get { return _totalSalesCount5; }
            set { _totalSalesCount5 = value; }
        }

        /// public propaty name  :  TotalSalesCount6
        /// <summary>���㐔�v6�v���p�e�B</summary>
        /// <value>�o�א�(�ԕi�͌��Z)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㐔�v6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalSalesCount6
        {
            get { return _totalSalesCount6; }
            set { _totalSalesCount6 = value; }
        }

        /// public propaty name  :  TotalSalesCount7
        /// <summary>���㐔�v7�v���p�e�B</summary>
        /// <value>�o�א�(�ԕi�͌��Z)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㐔�v7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalSalesCount7
        {
            get { return _totalSalesCount7; }
            set { _totalSalesCount7 = value; }
        }

        /// public propaty name  :  TotalSalesCount8
        /// <summary>���㐔�v8�v���p�e�B</summary>
        /// <value>�o�א�(�ԕi�͌��Z)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㐔�v8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalSalesCount8
        {
            get { return _totalSalesCount8; }
            set { _totalSalesCount8 = value; }
        }

        /// public propaty name  :  TotalSalesCount9
        /// <summary>���㐔�v9�v���p�e�B</summary>
        /// <value>�o�א�(�ԕi�͌��Z)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㐔�v9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalSalesCount9
        {
            get { return _totalSalesCount9; }
            set { _totalSalesCount9 = value; }
        }

        /// public propaty name  :  TotalSalesCount10
        /// <summary>���㐔�v10�v���p�e�B</summary>
        /// <value>�o�א�(�ԕi�͌��Z)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㐔�v10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalSalesCount10
        {
            get { return _totalSalesCount10; }
            set { _totalSalesCount10 = value; }
        }

        /// public propaty name  :  TotalSalesCount11
        /// <summary>���㐔�v11�v���p�e�B</summary>
        /// <value>�o�א�(�ԕi�͌��Z)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㐔�v11�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalSalesCount11
        {
            get { return _totalSalesCount11; }
            set { _totalSalesCount11 = value; }
        }

        /// public propaty name  :  TotalSalesCount12
        /// <summary>���㐔�v12�v���p�e�B</summary>
        /// <value>�o�א�(�ԕi�͌��Z)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㐔�v12�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalSalesCount12
        {
            get { return _totalSalesCount12; }
            set { _totalSalesCount12 = value; }
        }


        /// <summary>
        /// ���㐄�ڕ\���o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SalesTransListResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesTransListResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesTransListResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SalesTransListResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SalesTransListResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SalesTransListResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesTransListResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalesTransListResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalesTransListResultWork || graph is ArrayList || graph is SalesTransListResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SalesTransListResultWork).FullName));

            if (graph != null && graph is SalesTransListResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalesTransListResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalesTransListResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalesTransListResultWork[])graph).Length;
            }
            else if (graph is SalesTransListResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //���_����
            serInfo.MemberInfo.Add(typeof(string)); //CompanyName1
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerShortName
            //���i�啪�ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsLGroup
            //���i�啪�ޖ���
            serInfo.MemberInfo.Add(typeof(string)); //GoodsLGroupName
            //���i�����ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //���i�����ޖ���
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMGroupName
            //BL�O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //BL�O���[�v�R�[�h�J�i����
            serInfo.MemberInfo.Add(typeof(string)); //BLGroupKanaName
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL���i�R�[�h���́i���p�j
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsHalfName
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ旪��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCode
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            //�]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //Name
            //������z1
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney1
            //������z2
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney2
            //������z3
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney3
            //������z4
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney4
            //������z5
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney5
            //������z6
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney6
            //������z7
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney7
            //������z8
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney8
            //������z9
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney9
            //������z10
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney10
            //������z11
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney11
            //������z12
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney12
            //���㐔�v1
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount1
            //���㐔�v2
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount2
            //���㐔�v3
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount3
            //���㐔�v4
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount4
            //���㐔�v5
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount5
            //���㐔�v6
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount6
            //���㐔�v7
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount7
            //���㐔�v8
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount8
            //���㐔�v9
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount9
            //���㐔�v10
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount10
            //���㐔�v11
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount11
            //���㐔�v12
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount12


            serInfo.Serialize(writer, serInfo);
            if (graph is SalesTransListResultWork)
            {
                SalesTransListResultWork temp = (SalesTransListResultWork)graph;

                SetSalesTransListResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalesTransListResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalesTransListResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalesTransListResultWork temp in lst)
                {
                    SetSalesTransListResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalesTransListResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 44;

        /// <summary>
        ///  SalesTransListResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesTransListResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSalesTransListResultWork(System.IO.BinaryWriter writer, SalesTransListResultWork temp)
        {
            //���_�R�[�h
            writer.Write(temp.AddUpSecCode);
            //���_����
            writer.Write(temp.CompanyName1);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���[�J�[����
            writer.Write(temp.MakerShortName);
            //���i�啪�ރR�[�h
            writer.Write(temp.GoodsLGroup);
            //���i�啪�ޖ���
            writer.Write(temp.GoodsLGroupName);
            //���i�����ރR�[�h
            writer.Write(temp.GoodsMGroup);
            //���i�����ޖ���
            writer.Write(temp.GoodsMGroupName);
            //BL�O���[�v�R�[�h
            writer.Write(temp.BLGroupCode);
            //BL�O���[�v�R�[�h�J�i����
            writer.Write(temp.BLGroupKanaName);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //BL���i�R�[�h���́i���p�j
            writer.Write(temp.BLGoodsHalfName);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i����
            writer.Write(temp.GoodsNameKana);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ旪��
            writer.Write(temp.CustomerSnm);
            //�d����R�[�h
            writer.Write(temp.SupplierCode);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //�]�ƈ��R�[�h
            writer.Write(temp.EmployeeCode);
            //�]�ƈ�����
            writer.Write(temp.Name);
            //������z1
            writer.Write(temp.SalesMoney1);
            //������z2
            writer.Write(temp.SalesMoney2);
            //������z3
            writer.Write(temp.SalesMoney3);
            //������z4
            writer.Write(temp.SalesMoney4);
            //������z5
            writer.Write(temp.SalesMoney5);
            //������z6
            writer.Write(temp.SalesMoney6);
            //������z7
            writer.Write(temp.SalesMoney7);
            //������z8
            writer.Write(temp.SalesMoney8);
            //������z9
            writer.Write(temp.SalesMoney9);
            //������z10
            writer.Write(temp.SalesMoney10);
            //������z11
            writer.Write(temp.SalesMoney11);
            //������z12
            writer.Write(temp.SalesMoney12);
            //���㐔�v1
            writer.Write(temp.TotalSalesCount1);
            //���㐔�v2
            writer.Write(temp.TotalSalesCount2);
            //���㐔�v3
            writer.Write(temp.TotalSalesCount3);
            //���㐔�v4
            writer.Write(temp.TotalSalesCount4);
            //���㐔�v5
            writer.Write(temp.TotalSalesCount5);
            //���㐔�v6
            writer.Write(temp.TotalSalesCount6);
            //���㐔�v7
            writer.Write(temp.TotalSalesCount7);
            //���㐔�v8
            writer.Write(temp.TotalSalesCount8);
            //���㐔�v9
            writer.Write(temp.TotalSalesCount9);
            //���㐔�v10
            writer.Write(temp.TotalSalesCount10);
            //���㐔�v11
            writer.Write(temp.TotalSalesCount11);
            //���㐔�v12
            writer.Write(temp.TotalSalesCount12);

        }

        /// <summary>
        ///  SalesTransListResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SalesTransListResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesTransListResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SalesTransListResultWork GetSalesTransListResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SalesTransListResultWork temp = new SalesTransListResultWork();

            //���_�R�[�h
            temp.AddUpSecCode = reader.ReadString();
            //���_����
            temp.CompanyName1 = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���[�J�[����
            temp.MakerShortName = reader.ReadString();
            //���i�啪�ރR�[�h
            temp.GoodsLGroup = reader.ReadInt32();
            //���i�啪�ޖ���
            temp.GoodsLGroupName = reader.ReadString();
            //���i�����ރR�[�h
            temp.GoodsMGroup = reader.ReadInt32();
            //���i�����ޖ���
            temp.GoodsMGroupName = reader.ReadString();
            //BL�O���[�v�R�[�h
            temp.BLGroupCode = reader.ReadInt32();
            //BL�O���[�v�R�[�h�J�i����
            temp.BLGroupKanaName = reader.ReadString();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //BL���i�R�[�h���́i���p�j
            temp.BLGoodsHalfName = reader.ReadString();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i����
            temp.GoodsNameKana = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ旪��
            temp.CustomerSnm = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCode = reader.ReadInt32();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //�]�ƈ��R�[�h
            temp.EmployeeCode = reader.ReadString();
            //�]�ƈ�����
            temp.Name = reader.ReadString();
            //������z1
            temp.SalesMoney1 = reader.ReadInt64();
            //������z2
            temp.SalesMoney2 = reader.ReadInt64();
            //������z3
            temp.SalesMoney3 = reader.ReadInt64();
            //������z4
            temp.SalesMoney4 = reader.ReadInt64();
            //������z5
            temp.SalesMoney5 = reader.ReadInt64();
            //������z6
            temp.SalesMoney6 = reader.ReadInt64();
            //������z7
            temp.SalesMoney7 = reader.ReadInt64();
            //������z8
            temp.SalesMoney8 = reader.ReadInt64();
            //������z9
            temp.SalesMoney9 = reader.ReadInt64();
            //������z10
            temp.SalesMoney10 = reader.ReadInt64();
            //������z11
            temp.SalesMoney11 = reader.ReadInt64();
            //������z12
            temp.SalesMoney12 = reader.ReadInt64();
            //���㐔�v1
            temp.TotalSalesCount1 = reader.ReadDouble();
            //���㐔�v2
            temp.TotalSalesCount2 = reader.ReadDouble();
            //���㐔�v3
            temp.TotalSalesCount3 = reader.ReadDouble();
            //���㐔�v4
            temp.TotalSalesCount4 = reader.ReadDouble();
            //���㐔�v5
            temp.TotalSalesCount5 = reader.ReadDouble();
            //���㐔�v6
            temp.TotalSalesCount6 = reader.ReadDouble();
            //���㐔�v7
            temp.TotalSalesCount7 = reader.ReadDouble();
            //���㐔�v8
            temp.TotalSalesCount8 = reader.ReadDouble();
            //���㐔�v9
            temp.TotalSalesCount9 = reader.ReadDouble();
            //���㐔�v10
            temp.TotalSalesCount10 = reader.ReadDouble();
            //���㐔�v11
            temp.TotalSalesCount11 = reader.ReadDouble();
            //���㐔�v12
            temp.TotalSalesCount12 = reader.ReadDouble();


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
        /// <returns>SalesTransListResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesTransListResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalesTransListResultWork temp = GetSalesTransListResultWork(reader, serInfo);
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
                    retValue = (SalesTransListResultWork[])lst.ToArray(typeof(SalesTransListResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
