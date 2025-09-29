using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockTransListResultWork
    /// <summary>
    ///                      �d�����ڕ\���o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d�����ڕ\���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/03/06  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockTransListResultWork
    {
        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _stockSectionCd = "";

        /// <summary>���Ж���1</summary>
        private string _companyName1 = "";

        /// <summary>���Ж���2</summary>
        private string _companyName2 = "";

        /// <summary>���_�K�C�h����</summary>
        private string _sectionGuideNm = "";

        /// <summary>����R�[�h</summary>
        private Int32 _subSectionCode;

        /// <summary>���喼��</summary>
        private string _subSectionName = "";

        /// <summary>�ۃR�[�h</summary>
        private Int32 _minSectionCode;

        /// <summary>�ۖ���</summary>
        private string _minSectionName = "";

        /// <summary>�]�ƈ��R�[�h</summary>
        private string _employeeCode = "";

        /// <summary>�]�ƈ�����</summary>
        private string _employeeName = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

        /// <summary>���i�敪�O���[�v�R�[�h</summary>
        /// <remarks>���F���i�啪�ރR�[�h</remarks>
        private string _largeGoodsGanreCode = "";

        /// <summary>���i�敪�O���[�v����</summary>
        /// <remarks>���F���i�啪�ޖ���</remarks>
        private string _largeGoodsGanreName = "";

        /// <summary>���i�敪�R�[�h</summary>
        /// <remarks>���F���i�����ރR�[�h</remarks>
        private string _mediumGoodsGanreCode = "";

        /// <summary>���i�敪����</summary>
        /// <remarks>���F���i�����ޖ���</remarks>
        private string _mediumGoodsGanreName = "";

        /// <summary>���i�敪�ڍ׃R�[�h</summary>
        private string _detailGoodsGanreCode = "";

        /// <summary>���i�敪�ڍז���</summary>
        private string _detailGoodsGanreName = "";

        /// <summary>���Е��ރR�[�h</summary>
        /// <remarks>���i�}�X�^����擾</remarks>
        private Int32 _enterpriseGanreCode;

        /// <summary>���Е��ޖ���</summary>
        /// <remarks>���i�}�X�^����擾</remarks>
        private string _enterpriseGanreName = "";

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL���i�R�[�h���́i�S�p�j</summary>
        private string _bLGoodsFullName = "";

        /// <summary>���i�ԍ�</summary>
        /// <remarks>�i���i�ʂ̏ꍇ�̂݃Z�b�g�j</remarks>
        private string _goodsNo = "";

        /// <summary>���i������</summary>
        /// <remarks>�i���i�ʂ̏ꍇ�̂݃Z�b�g�j</remarks>
        private string _goodsShortName = "";

        /// <summary>���d�����v1</summary>
        /// <remarks>�o�א�</remarks>
        private Double _totalStockCount1;

        /// <summary>���d�����v2</summary>
        /// <remarks>�o�א�</remarks>
        private Double _totalStockCount2;

        /// <summary>���d�����v3</summary>
        /// <remarks>�o�א�</remarks>
        private Double _totalStockCount3;

        /// <summary>���d�����v4</summary>
        /// <remarks>�o�א�</remarks>
        private Double _totalStockCount4;

        /// <summary>���d�����v5</summary>
        /// <remarks>�o�א�</remarks>
        private Double _totalStockCount5;

        /// <summary>���d�����v6</summary>
        /// <remarks>�o�א�</remarks>
        private Double _totalStockCount6;

        /// <summary>���d�����v7</summary>
        /// <remarks>�o�א�</remarks>
        private Double _totalStockCount7;

        /// <summary>���d�����v8</summary>
        /// <remarks>�o�א�</remarks>
        private Double _totalStockCount8;

        /// <summary>���d�����v9</summary>
        /// <remarks>�o�א�</remarks>
        private Double _totalStockCount9;

        /// <summary>���d�����v10</summary>
        /// <remarks>�o�א�</remarks>
        private Double _totalStockCount10;

        /// <summary>���d�����v11</summary>
        /// <remarks>�o�א�</remarks>
        private Double _totalStockCount11;

        /// <summary>���d�����v12</summary>
        /// <remarks>�o�א�</remarks>
        private Double _totalStockCount12;

        /// <summary>���d���`�[���v1�i�Ŕ����j</summary>
        /// <remarks>�d���`�[�̍��v�i�Ŕ����{�l�����݁j</remarks>
        private Int64 _stockTotalTaxExc1;

        /// <summary>���d���`�[���v2�i�Ŕ����j</summary>
        /// <remarks>�d���`�[�̍��v�i�Ŕ����{�l�����݁j</remarks>
        private Int64 _stockTotalTaxExc2;

        /// <summary>���d���`�[���v3�i�Ŕ����j</summary>
        /// <remarks>�d���`�[�̍��v�i�Ŕ����{�l�����݁j</remarks>
        private Int64 _stockTotalTaxExc3;

        /// <summary>���d���`�[���v4�i�Ŕ����j</summary>
        /// <remarks>�d���`�[�̍��v�i�Ŕ����{�l�����݁j</remarks>
        private Int64 _stockTotalTaxExc4;

        /// <summary>���d���`�[���v5�i�Ŕ����j</summary>
        /// <remarks>�d���`�[�̍��v�i�Ŕ����{�l�����݁j</remarks>
        private Int64 _stockTotalTaxExc5;

        /// <summary>���d���`�[���v6�i�Ŕ����j</summary>
        /// <remarks>�d���`�[�̍��v�i�Ŕ����{�l�����݁j</remarks>
        private Int64 _stockTotalTaxExc6;

        /// <summary>���d���`�[���v7�i�Ŕ����j</summary>
        /// <remarks>�d���`�[�̍��v�i�Ŕ����{�l�����݁j</remarks>
        private Int64 _stockTotalTaxExc7;

        /// <summary>���d���`�[���v8�i�Ŕ����j</summary>
        /// <remarks>�d���`�[�̍��v�i�Ŕ����{�l�����݁j</remarks>
        private Int64 _stockTotalTaxExc8;

        /// <summary>���d���`�[���v9�i�Ŕ����j</summary>
        /// <remarks>�d���`�[�̍��v�i�Ŕ����{�l�����݁j</remarks>
        private Int64 _stockTotalTaxExc9;

        /// <summary>���d���`�[���v10�i�Ŕ����j</summary>
        /// <remarks>�d���`�[�̍��v�i�Ŕ����{�l�����݁j</remarks>
        private Int64 _stockTotalTaxExc10;

        /// <summary>���d���`�[���v11�i�Ŕ����j</summary>
        /// <remarks>�d���`�[�̍��v�i�Ŕ����{�l�����݁j</remarks>
        private Int64 _stockTotalTaxExc11;

        /// <summary>���d���`�[���v12�i�Ŕ����j</summary>
        /// <remarks>�d���`�[�̍��v�i�Ŕ����{�l�����݁j</remarks>
        private Int64 _stockTotalTaxExc12;

        /// <summary>���ԕi�z1</summary>
        /// <remarks>�ԕi�z</remarks>
        private Int64 _stockRetGoodsPrice1;

        /// <summary>���ԕi�z2</summary>
        /// <remarks>�ԕi�z</remarks>
        private Int64 _stockRetGoodsPrice2;

        /// <summary>���ԕi�z3</summary>
        /// <remarks>�ԕi�z</remarks>
        private Int64 _stockRetGoodsPrice3;

        /// <summary>���ԕi�z4</summary>
        /// <remarks>�ԕi�z</remarks>
        private Int64 _stockRetGoodsPrice4;

        /// <summary>���ԕi�z5</summary>
        /// <remarks>�ԕi�z</remarks>
        private Int64 _stockRetGoodsPrice5;

        /// <summary>���ԕi�z6</summary>
        /// <remarks>�ԕi�z</remarks>
        private Int64 _stockRetGoodsPrice6;

        /// <summary>���ԕi�z7</summary>
        /// <remarks>�ԕi�z</remarks>
        private Int64 _stockRetGoodsPrice7;

        /// <summary>���ԕi�z8</summary>
        /// <remarks>�ԕi�z</remarks>
        private Int64 _stockRetGoodsPrice8;

        /// <summary>���ԕi�z9</summary>
        /// <remarks>�ԕi�z</remarks>
        private Int64 _stockRetGoodsPrice9;

        /// <summary>���ԕi�z10</summary>
        /// <remarks>�ԕi�z</remarks>
        private Int64 _stockRetGoodsPrice10;

        /// <summary>���ԕi�z11</summary>
        /// <remarks>�ԕi�z</remarks>
        private Int64 _stockRetGoodsPrice11;

        /// <summary>���ԕi�z12</summary>
        /// <remarks>�ԕi�z</remarks>
        private Int64 _stockRetGoodsPrice12;


        /// public propaty name  :  StockSectionCd
        /// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockSectionCd
        {
            get { return _stockSectionCd; }
            set { _stockSectionCd = value; }
        }

        /// public propaty name  :  CompanyName1
        /// <summary>���Ж���1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж���1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyName1
        {
            get { return _companyName1; }
            set { _companyName1 = value; }
        }

        /// public propaty name  :  CompanyName2
        /// <summary>���Ж���2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж���2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyName2
        {
            get { return _companyName2; }
            set { _companyName2 = value; }
        }

        /// public propaty name  :  SectionGuideNm
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  SubSectionCode
        /// <summary>����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SubSectionCode
        {
            get { return _subSectionCode; }
            set { _subSectionCode = value; }
        }

        /// public propaty name  :  SubSectionName
        /// <summary>���喼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���喼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SubSectionName
        {
            get { return _subSectionName; }
            set { _subSectionName = value; }
        }

        /// public propaty name  :  MinSectionCode
        /// <summary>�ۃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ۃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MinSectionCode
        {
            get { return _minSectionCode; }
            set { _minSectionCode = value; }
        }

        /// public propaty name  :  MinSectionName
        /// <summary>�ۖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ۖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MinSectionName
        {
            get { return _minSectionName; }
            set { _minSectionName = value; }
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

        /// public propaty name  :  EmployeeName
        /// <summary>�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
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

        /// public propaty name  :  MakerName
        /// <summary>���[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  LargeGoodsGanreCode
        /// <summary>���i�敪�O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>���F���i�啪�ރR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LargeGoodsGanreCode
        {
            get { return _largeGoodsGanreCode; }
            set { _largeGoodsGanreCode = value; }
        }

        /// public propaty name  :  LargeGoodsGanreName
        /// <summary>���i�敪�O���[�v���̃v���p�e�B</summary>
        /// <value>���F���i�啪�ޖ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�O���[�v���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LargeGoodsGanreName
        {
            get { return _largeGoodsGanreName; }
            set { _largeGoodsGanreName = value; }
        }

        /// public propaty name  :  MediumGoodsGanreCode
        /// <summary>���i�敪�R�[�h�v���p�e�B</summary>
        /// <value>���F���i�����ރR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MediumGoodsGanreCode
        {
            get { return _mediumGoodsGanreCode; }
            set { _mediumGoodsGanreCode = value; }
        }

        /// public propaty name  :  MediumGoodsGanreName
        /// <summary>���i�敪���̃v���p�e�B</summary>
        /// <value>���F���i�����ޖ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MediumGoodsGanreName
        {
            get { return _mediumGoodsGanreName; }
            set { _mediumGoodsGanreName = value; }
        }

        /// public propaty name  :  DetailGoodsGanreCode
        /// <summary>���i�敪�ڍ׃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�ڍ׃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DetailGoodsGanreCode
        {
            get { return _detailGoodsGanreCode; }
            set { _detailGoodsGanreCode = value; }
        }

        /// public propaty name  :  DetailGoodsGanreName
        /// <summary>���i�敪�ڍז��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�ڍז��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DetailGoodsGanreName
        {
            get { return _detailGoodsGanreName; }
            set { _detailGoodsGanreName = value; }
        }

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>���Е��ރR�[�h�v���p�e�B</summary>
        /// <value>���i�}�X�^����擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Е��ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnterpriseGanreCode
        {
            get { return _enterpriseGanreCode; }
            set { _enterpriseGanreCode = value; }
        }

        /// public propaty name  :  EnterpriseGanreName
        /// <summary>���Е��ޖ��̃v���p�e�B</summary>
        /// <value>���i�}�X�^����擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Е��ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseGanreName
        {
            get { return _enterpriseGanreName; }
            set { _enterpriseGanreName = value; }
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

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL���i�R�[�h���́i�S�p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i�S�p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set { _bLGoodsFullName = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>���i�ԍ��v���p�e�B</summary>
        /// <value>�i���i�ʂ̏ꍇ�̂݃Z�b�g�j</value>
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

        /// public propaty name  :  GoodsShortName
        /// <summary>���i�����̃v���p�e�B</summary>
        /// <value>�i���i�ʂ̏ꍇ�̂݃Z�b�g�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsShortName
        {
            get { return _goodsShortName; }
            set { _goodsShortName = value; }
        }

        /// public propaty name  :  TotalStockCount1
        /// <summary>���d�����v1�v���p�e�B</summary>
        /// <value>�o�א�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d�����v1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalStockCount1
        {
            get { return _totalStockCount1; }
            set { _totalStockCount1 = value; }
        }

        /// public propaty name  :  TotalStockCount2
        /// <summary>���d�����v2�v���p�e�B</summary>
        /// <value>�o�א�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d�����v2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalStockCount2
        {
            get { return _totalStockCount2; }
            set { _totalStockCount2 = value; }
        }

        /// public propaty name  :  TotalStockCount3
        /// <summary>���d�����v3�v���p�e�B</summary>
        /// <value>�o�א�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d�����v3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalStockCount3
        {
            get { return _totalStockCount3; }
            set { _totalStockCount3 = value; }
        }

        /// public propaty name  :  TotalStockCount4
        /// <summary>���d�����v4�v���p�e�B</summary>
        /// <value>�o�א�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d�����v4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalStockCount4
        {
            get { return _totalStockCount4; }
            set { _totalStockCount4 = value; }
        }

        /// public propaty name  :  TotalStockCount5
        /// <summary>���d�����v5�v���p�e�B</summary>
        /// <value>�o�א�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d�����v5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalStockCount5
        {
            get { return _totalStockCount5; }
            set { _totalStockCount5 = value; }
        }

        /// public propaty name  :  TotalStockCount6
        /// <summary>���d�����v6�v���p�e�B</summary>
        /// <value>�o�א�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d�����v6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalStockCount6
        {
            get { return _totalStockCount6; }
            set { _totalStockCount6 = value; }
        }

        /// public propaty name  :  TotalStockCount7
        /// <summary>���d�����v7�v���p�e�B</summary>
        /// <value>�o�א�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d�����v7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalStockCount7
        {
            get { return _totalStockCount7; }
            set { _totalStockCount7 = value; }
        }

        /// public propaty name  :  TotalStockCount8
        /// <summary>���d�����v8�v���p�e�B</summary>
        /// <value>�o�א�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d�����v8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalStockCount8
        {
            get { return _totalStockCount8; }
            set { _totalStockCount8 = value; }
        }

        /// public propaty name  :  TotalStockCount9
        /// <summary>���d�����v9�v���p�e�B</summary>
        /// <value>�o�א�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d�����v9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalStockCount9
        {
            get { return _totalStockCount9; }
            set { _totalStockCount9 = value; }
        }

        /// public propaty name  :  TotalStockCount10
        /// <summary>���d�����v10�v���p�e�B</summary>
        /// <value>�o�א�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d�����v10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalStockCount10
        {
            get { return _totalStockCount10; }
            set { _totalStockCount10 = value; }
        }

        /// public propaty name  :  TotalStockCount11
        /// <summary>���d�����v11�v���p�e�B</summary>
        /// <value>�o�א�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d�����v11�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalStockCount11
        {
            get { return _totalStockCount11; }
            set { _totalStockCount11 = value; }
        }

        /// public propaty name  :  TotalStockCount12
        /// <summary>���d�����v12�v���p�e�B</summary>
        /// <value>�o�א�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d�����v12�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalStockCount12
        {
            get { return _totalStockCount12; }
            set { _totalStockCount12 = value; }
        }

        /// public propaty name  :  StockTotalTaxExc1
        /// <summary>���d���`�[���v1�i�Ŕ����j�v���p�e�B</summary>
        /// <value>�d���`�[�̍��v�i�Ŕ����{�l�����݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d���`�[���v1�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTotalTaxExc1
        {
            get { return _stockTotalTaxExc1; }
            set { _stockTotalTaxExc1 = value; }
        }

        /// public propaty name  :  StockTotalTaxExc2
        /// <summary>���d���`�[���v2�i�Ŕ����j�v���p�e�B</summary>
        /// <value>�d���`�[�̍��v�i�Ŕ����{�l�����݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d���`�[���v2�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTotalTaxExc2
        {
            get { return _stockTotalTaxExc2; }
            set { _stockTotalTaxExc2 = value; }
        }

        /// public propaty name  :  StockTotalTaxExc3
        /// <summary>���d���`�[���v3�i�Ŕ����j�v���p�e�B</summary>
        /// <value>�d���`�[�̍��v�i�Ŕ����{�l�����݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d���`�[���v3�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTotalTaxExc3
        {
            get { return _stockTotalTaxExc3; }
            set { _stockTotalTaxExc3 = value; }
        }

        /// public propaty name  :  StockTotalTaxExc4
        /// <summary>���d���`�[���v4�i�Ŕ����j�v���p�e�B</summary>
        /// <value>�d���`�[�̍��v�i�Ŕ����{�l�����݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d���`�[���v4�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTotalTaxExc4
        {
            get { return _stockTotalTaxExc4; }
            set { _stockTotalTaxExc4 = value; }
        }

        /// public propaty name  :  StockTotalTaxExc5
        /// <summary>���d���`�[���v5�i�Ŕ����j�v���p�e�B</summary>
        /// <value>�d���`�[�̍��v�i�Ŕ����{�l�����݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d���`�[���v5�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTotalTaxExc5
        {
            get { return _stockTotalTaxExc5; }
            set { _stockTotalTaxExc5 = value; }
        }

        /// public propaty name  :  StockTotalTaxExc6
        /// <summary>���d���`�[���v6�i�Ŕ����j�v���p�e�B</summary>
        /// <value>�d���`�[�̍��v�i�Ŕ����{�l�����݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d���`�[���v6�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTotalTaxExc6
        {
            get { return _stockTotalTaxExc6; }
            set { _stockTotalTaxExc6 = value; }
        }

        /// public propaty name  :  StockTotalTaxExc7
        /// <summary>���d���`�[���v7�i�Ŕ����j�v���p�e�B</summary>
        /// <value>�d���`�[�̍��v�i�Ŕ����{�l�����݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d���`�[���v7�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTotalTaxExc7
        {
            get { return _stockTotalTaxExc7; }
            set { _stockTotalTaxExc7 = value; }
        }

        /// public propaty name  :  StockTotalTaxExc8
        /// <summary>���d���`�[���v8�i�Ŕ����j�v���p�e�B</summary>
        /// <value>�d���`�[�̍��v�i�Ŕ����{�l�����݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d���`�[���v8�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTotalTaxExc8
        {
            get { return _stockTotalTaxExc8; }
            set { _stockTotalTaxExc8 = value; }
        }

        /// public propaty name  :  StockTotalTaxExc9
        /// <summary>���d���`�[���v9�i�Ŕ����j�v���p�e�B</summary>
        /// <value>�d���`�[�̍��v�i�Ŕ����{�l�����݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d���`�[���v9�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTotalTaxExc9
        {
            get { return _stockTotalTaxExc9; }
            set { _stockTotalTaxExc9 = value; }
        }

        /// public propaty name  :  StockTotalTaxExc10
        /// <summary>���d���`�[���v10�i�Ŕ����j�v���p�e�B</summary>
        /// <value>�d���`�[�̍��v�i�Ŕ����{�l�����݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d���`�[���v10�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTotalTaxExc10
        {
            get { return _stockTotalTaxExc10; }
            set { _stockTotalTaxExc10 = value; }
        }

        /// public propaty name  :  StockTotalTaxExc11
        /// <summary>���d���`�[���v11�i�Ŕ����j�v���p�e�B</summary>
        /// <value>�d���`�[�̍��v�i�Ŕ����{�l�����݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d���`�[���v11�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTotalTaxExc11
        {
            get { return _stockTotalTaxExc11; }
            set { _stockTotalTaxExc11 = value; }
        }

        /// public propaty name  :  StockTotalTaxExc12
        /// <summary>���d���`�[���v12�i�Ŕ����j�v���p�e�B</summary>
        /// <value>�d���`�[�̍��v�i�Ŕ����{�l�����݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d���`�[���v12�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTotalTaxExc12
        {
            get { return _stockTotalTaxExc12; }
            set { _stockTotalTaxExc12 = value; }
        }

        /// public propaty name  :  StockRetGoodsPrice1
        /// <summary>���ԕi�z1�v���p�e�B</summary>
        /// <value>�ԕi�z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ԕi�z1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockRetGoodsPrice1
        {
            get { return _stockRetGoodsPrice1; }
            set { _stockRetGoodsPrice1 = value; }
        }

        /// public propaty name  :  StockRetGoodsPrice2
        /// <summary>���ԕi�z2�v���p�e�B</summary>
        /// <value>�ԕi�z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ԕi�z2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockRetGoodsPrice2
        {
            get { return _stockRetGoodsPrice2; }
            set { _stockRetGoodsPrice2 = value; }
        }

        /// public propaty name  :  StockRetGoodsPrice3
        /// <summary>���ԕi�z3�v���p�e�B</summary>
        /// <value>�ԕi�z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ԕi�z3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockRetGoodsPrice3
        {
            get { return _stockRetGoodsPrice3; }
            set { _stockRetGoodsPrice3 = value; }
        }

        /// public propaty name  :  StockRetGoodsPrice4
        /// <summary>���ԕi�z4�v���p�e�B</summary>
        /// <value>�ԕi�z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ԕi�z4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockRetGoodsPrice4
        {
            get { return _stockRetGoodsPrice4; }
            set { _stockRetGoodsPrice4 = value; }
        }

        /// public propaty name  :  StockRetGoodsPrice5
        /// <summary>���ԕi�z5�v���p�e�B</summary>
        /// <value>�ԕi�z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ԕi�z5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockRetGoodsPrice5
        {
            get { return _stockRetGoodsPrice5; }
            set { _stockRetGoodsPrice5 = value; }
        }

        /// public propaty name  :  StockRetGoodsPrice6
        /// <summary>���ԕi�z6�v���p�e�B</summary>
        /// <value>�ԕi�z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ԕi�z6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockRetGoodsPrice6
        {
            get { return _stockRetGoodsPrice6; }
            set { _stockRetGoodsPrice6 = value; }
        }

        /// public propaty name  :  StockRetGoodsPrice7
        /// <summary>���ԕi�z7�v���p�e�B</summary>
        /// <value>�ԕi�z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ԕi�z7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockRetGoodsPrice7
        {
            get { return _stockRetGoodsPrice7; }
            set { _stockRetGoodsPrice7 = value; }
        }

        /// public propaty name  :  StockRetGoodsPrice8
        /// <summary>���ԕi�z8�v���p�e�B</summary>
        /// <value>�ԕi�z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ԕi�z8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockRetGoodsPrice8
        {
            get { return _stockRetGoodsPrice8; }
            set { _stockRetGoodsPrice8 = value; }
        }

        /// public propaty name  :  StockRetGoodsPrice9
        /// <summary>���ԕi�z9�v���p�e�B</summary>
        /// <value>�ԕi�z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ԕi�z9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockRetGoodsPrice9
        {
            get { return _stockRetGoodsPrice9; }
            set { _stockRetGoodsPrice9 = value; }
        }

        /// public propaty name  :  StockRetGoodsPrice10
        /// <summary>���ԕi�z10�v���p�e�B</summary>
        /// <value>�ԕi�z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ԕi�z10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockRetGoodsPrice10
        {
            get { return _stockRetGoodsPrice10; }
            set { _stockRetGoodsPrice10 = value; }
        }

        /// public propaty name  :  StockRetGoodsPrice11
        /// <summary>���ԕi�z11�v���p�e�B</summary>
        /// <value>�ԕi�z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ԕi�z11�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockRetGoodsPrice11
        {
            get { return _stockRetGoodsPrice11; }
            set { _stockRetGoodsPrice11 = value; }
        }

        /// public propaty name  :  StockRetGoodsPrice12
        /// <summary>���ԕi�z12�v���p�e�B</summary>
        /// <value>�ԕi�z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ԕi�z12�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockRetGoodsPrice12
        {
            get { return _stockRetGoodsPrice12; }
            set { _stockRetGoodsPrice12 = value; }
        }


        /// <summary>
        /// �d�����ڕ\���o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockTransListResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockTransListResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockTransListResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>StockTransListResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   StockTransListResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class StockTransListResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockTransListResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockTransListResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockTransListResultWork || graph is ArrayList || graph is StockTransListResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(StockTransListResultWork).FullName));

            if (graph != null && graph is StockTransListResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockTransListResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockTransListResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockTransListResultWork[])graph).Length;
            }
            else if (graph is StockTransListResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionCd
            //���Ж���1
            serInfo.MemberInfo.Add(typeof(string)); //CompanyName1
            //���Ж���2
            serInfo.MemberInfo.Add(typeof(string)); //CompanyName2
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //���喼��
            serInfo.MemberInfo.Add(typeof(string)); //SubSectionName
            //�ۃR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //MinSectionCode
            //�ۖ���
            serInfo.MemberInfo.Add(typeof(string)); //MinSectionName
            //�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            //�]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeName
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //���i�敪�O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //LargeGoodsGanreCode
            //���i�敪�O���[�v����
            serInfo.MemberInfo.Add(typeof(string)); //LargeGoodsGanreName
            //���i�敪�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //MediumGoodsGanreCode
            //���i�敪����
            serInfo.MemberInfo.Add(typeof(string)); //MediumGoodsGanreName
            //���i�敪�ڍ׃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //DetailGoodsGanreCode
            //���i�敪�ڍז���
            serInfo.MemberInfo.Add(typeof(string)); //DetailGoodsGanreName
            //���Е��ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterpriseGanreCode
            //���Е��ޖ���
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseGanreName
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL���i�R�[�h���́i�S�p�j
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i������
            serInfo.MemberInfo.Add(typeof(string)); //GoodsShortName
            //���d�����v1
            serInfo.MemberInfo.Add(typeof(Double)); //TotalStockCount1
            //���d�����v2
            serInfo.MemberInfo.Add(typeof(Double)); //TotalStockCount2
            //���d�����v3
            serInfo.MemberInfo.Add(typeof(Double)); //TotalStockCount3
            //���d�����v4
            serInfo.MemberInfo.Add(typeof(Double)); //TotalStockCount4
            //���d�����v5
            serInfo.MemberInfo.Add(typeof(Double)); //TotalStockCount5
            //���d�����v6
            serInfo.MemberInfo.Add(typeof(Double)); //TotalStockCount6
            //���d�����v7
            serInfo.MemberInfo.Add(typeof(Double)); //TotalStockCount7
            //���d�����v8
            serInfo.MemberInfo.Add(typeof(Double)); //TotalStockCount8
            //���d�����v9
            serInfo.MemberInfo.Add(typeof(Double)); //TotalStockCount9
            //���d�����v10
            serInfo.MemberInfo.Add(typeof(Double)); //TotalStockCount10
            //���d�����v11
            serInfo.MemberInfo.Add(typeof(Double)); //TotalStockCount11
            //���d�����v12
            serInfo.MemberInfo.Add(typeof(Double)); //TotalStockCount12
            //���d���`�[���v1�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalTaxExc1
            //���d���`�[���v2�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalTaxExc2
            //���d���`�[���v3�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalTaxExc3
            //���d���`�[���v4�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalTaxExc4
            //���d���`�[���v5�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalTaxExc5
            //���d���`�[���v6�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalTaxExc6
            //���d���`�[���v7�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalTaxExc7
            //���d���`�[���v8�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalTaxExc8
            //���d���`�[���v9�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalTaxExc9
            //���d���`�[���v10�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalTaxExc10
            //���d���`�[���v11�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalTaxExc11
            //���d���`�[���v12�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalTaxExc12
            //���ԕi�z1
            serInfo.MemberInfo.Add(typeof(Int64)); //StockRetGoodsPrice1
            //���ԕi�z2
            serInfo.MemberInfo.Add(typeof(Int64)); //StockRetGoodsPrice2
            //���ԕi�z3
            serInfo.MemberInfo.Add(typeof(Int64)); //StockRetGoodsPrice3
            //���ԕi�z4
            serInfo.MemberInfo.Add(typeof(Int64)); //StockRetGoodsPrice4
            //���ԕi�z5
            serInfo.MemberInfo.Add(typeof(Int64)); //StockRetGoodsPrice5
            //���ԕi�z6
            serInfo.MemberInfo.Add(typeof(Int64)); //StockRetGoodsPrice6
            //���ԕi�z7
            serInfo.MemberInfo.Add(typeof(Int64)); //StockRetGoodsPrice7
            //���ԕi�z8
            serInfo.MemberInfo.Add(typeof(Int64)); //StockRetGoodsPrice8
            //���ԕi�z9
            serInfo.MemberInfo.Add(typeof(Int64)); //StockRetGoodsPrice9
            //���ԕi�z10
            serInfo.MemberInfo.Add(typeof(Int64)); //StockRetGoodsPrice10
            //���ԕi�z11
            serInfo.MemberInfo.Add(typeof(Int64)); //StockRetGoodsPrice11
            //���ԕi�z12
            serInfo.MemberInfo.Add(typeof(Int64)); //StockRetGoodsPrice12


            serInfo.Serialize(writer, serInfo);
            if (graph is StockTransListResultWork)
            {
                StockTransListResultWork temp = (StockTransListResultWork)graph;

                SetStockTransListResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockTransListResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockTransListResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockTransListResultWork temp in lst)
                {
                    SetStockTransListResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockTransListResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 62;

        /// <summary>
        ///  StockTransListResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockTransListResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetStockTransListResultWork(System.IO.BinaryWriter writer, StockTransListResultWork temp)
        {
            //�v�㋒�_�R�[�h
            writer.Write(temp.StockSectionCd);
            //���Ж���1
            writer.Write(temp.CompanyName1);
            //���Ж���2
            writer.Write(temp.CompanyName2);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideNm);
            //����R�[�h
            writer.Write(temp.SubSectionCode);
            //���喼��
            writer.Write(temp.SubSectionName);
            //�ۃR�[�h
            writer.Write(temp.MinSectionCode);
            //�ۖ���
            writer.Write(temp.MinSectionName);
            //�]�ƈ��R�[�h
            writer.Write(temp.EmployeeCode);
            //�]�ƈ�����
            writer.Write(temp.EmployeeName);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���[�J�[����
            writer.Write(temp.MakerName);
            //���i�敪�O���[�v�R�[�h
            writer.Write(temp.LargeGoodsGanreCode);
            //���i�敪�O���[�v����
            writer.Write(temp.LargeGoodsGanreName);
            //���i�敪�R�[�h
            writer.Write(temp.MediumGoodsGanreCode);
            //���i�敪����
            writer.Write(temp.MediumGoodsGanreName);
            //���i�敪�ڍ׃R�[�h
            writer.Write(temp.DetailGoodsGanreCode);
            //���i�敪�ڍז���
            writer.Write(temp.DetailGoodsGanreName);
            //���Е��ރR�[�h
            writer.Write(temp.EnterpriseGanreCode);
            //���Е��ޖ���
            writer.Write(temp.EnterpriseGanreName);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //BL���i�R�[�h���́i�S�p�j
            writer.Write(temp.BLGoodsFullName);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i������
            writer.Write(temp.GoodsShortName);
            //���d�����v1
            writer.Write(temp.TotalStockCount1);
            //���d�����v2
            writer.Write(temp.TotalStockCount2);
            //���d�����v3
            writer.Write(temp.TotalStockCount3);
            //���d�����v4
            writer.Write(temp.TotalStockCount4);
            //���d�����v5
            writer.Write(temp.TotalStockCount5);
            //���d�����v6
            writer.Write(temp.TotalStockCount6);
            //���d�����v7
            writer.Write(temp.TotalStockCount7);
            //���d�����v8
            writer.Write(temp.TotalStockCount8);
            //���d�����v9
            writer.Write(temp.TotalStockCount9);
            //���d�����v10
            writer.Write(temp.TotalStockCount10);
            //���d�����v11
            writer.Write(temp.TotalStockCount11);
            //���d�����v12
            writer.Write(temp.TotalStockCount12);
            //���d���`�[���v1�i�Ŕ����j
            writer.Write(temp.StockTotalTaxExc1);
            //���d���`�[���v2�i�Ŕ����j
            writer.Write(temp.StockTotalTaxExc2);
            //���d���`�[���v3�i�Ŕ����j
            writer.Write(temp.StockTotalTaxExc3);
            //���d���`�[���v4�i�Ŕ����j
            writer.Write(temp.StockTotalTaxExc4);
            //���d���`�[���v5�i�Ŕ����j
            writer.Write(temp.StockTotalTaxExc5);
            //���d���`�[���v6�i�Ŕ����j
            writer.Write(temp.StockTotalTaxExc6);
            //���d���`�[���v7�i�Ŕ����j
            writer.Write(temp.StockTotalTaxExc7);
            //���d���`�[���v8�i�Ŕ����j
            writer.Write(temp.StockTotalTaxExc8);
            //���d���`�[���v9�i�Ŕ����j
            writer.Write(temp.StockTotalTaxExc9);
            //���d���`�[���v10�i�Ŕ����j
            writer.Write(temp.StockTotalTaxExc10);
            //���d���`�[���v11�i�Ŕ����j
            writer.Write(temp.StockTotalTaxExc11);
            //���d���`�[���v12�i�Ŕ����j
            writer.Write(temp.StockTotalTaxExc12);
            //���ԕi�z1
            writer.Write(temp.StockRetGoodsPrice1);
            //���ԕi�z2
            writer.Write(temp.StockRetGoodsPrice2);
            //���ԕi�z3
            writer.Write(temp.StockRetGoodsPrice3);
            //���ԕi�z4
            writer.Write(temp.StockRetGoodsPrice4);
            //���ԕi�z5
            writer.Write(temp.StockRetGoodsPrice5);
            //���ԕi�z6
            writer.Write(temp.StockRetGoodsPrice6);
            //���ԕi�z7
            writer.Write(temp.StockRetGoodsPrice7);
            //���ԕi�z8
            writer.Write(temp.StockRetGoodsPrice8);
            //���ԕi�z9
            writer.Write(temp.StockRetGoodsPrice9);
            //���ԕi�z10
            writer.Write(temp.StockRetGoodsPrice10);
            //���ԕi�z11
            writer.Write(temp.StockRetGoodsPrice11);
            //���ԕi�z12
            writer.Write(temp.StockRetGoodsPrice12);

        }

        /// <summary>
        ///  StockTransListResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>StockTransListResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockTransListResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private StockTransListResultWork GetStockTransListResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            StockTransListResultWork temp = new StockTransListResultWork();

            //�v�㋒�_�R�[�h
            temp.StockSectionCd = reader.ReadString();
            //���Ж���1
            temp.CompanyName1 = reader.ReadString();
            //���Ж���2
            temp.CompanyName2 = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideNm = reader.ReadString();
            //����R�[�h
            temp.SubSectionCode = reader.ReadInt32();
            //���喼��
            temp.SubSectionName = reader.ReadString();
            //�ۃR�[�h
            temp.MinSectionCode = reader.ReadInt32();
            //�ۖ���
            temp.MinSectionName = reader.ReadString();
            //�]�ƈ��R�[�h
            temp.EmployeeCode = reader.ReadString();
            //�]�ƈ�����
            temp.EmployeeName = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���[�J�[����
            temp.MakerName = reader.ReadString();
            //���i�敪�O���[�v�R�[�h
            temp.LargeGoodsGanreCode = reader.ReadString();
            //���i�敪�O���[�v����
            temp.LargeGoodsGanreName = reader.ReadString();
            //���i�敪�R�[�h
            temp.MediumGoodsGanreCode = reader.ReadString();
            //���i�敪����
            temp.MediumGoodsGanreName = reader.ReadString();
            //���i�敪�ڍ׃R�[�h
            temp.DetailGoodsGanreCode = reader.ReadString();
            //���i�敪�ڍז���
            temp.DetailGoodsGanreName = reader.ReadString();
            //���Е��ރR�[�h
            temp.EnterpriseGanreCode = reader.ReadInt32();
            //���Е��ޖ���
            temp.EnterpriseGanreName = reader.ReadString();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //BL���i�R�[�h���́i�S�p�j
            temp.BLGoodsFullName = reader.ReadString();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i������
            temp.GoodsShortName = reader.ReadString();
            //���d�����v1
            temp.TotalStockCount1 = reader.ReadDouble();
            //���d�����v2
            temp.TotalStockCount2 = reader.ReadDouble();
            //���d�����v3
            temp.TotalStockCount3 = reader.ReadDouble();
            //���d�����v4
            temp.TotalStockCount4 = reader.ReadDouble();
            //���d�����v5
            temp.TotalStockCount5 = reader.ReadDouble();
            //���d�����v6
            temp.TotalStockCount6 = reader.ReadDouble();
            //���d�����v7
            temp.TotalStockCount7 = reader.ReadDouble();
            //���d�����v8
            temp.TotalStockCount8 = reader.ReadDouble();
            //���d�����v9
            temp.TotalStockCount9 = reader.ReadDouble();
            //���d�����v10
            temp.TotalStockCount10 = reader.ReadDouble();
            //���d�����v11
            temp.TotalStockCount11 = reader.ReadDouble();
            //���d�����v12
            temp.TotalStockCount12 = reader.ReadDouble();
            //���d���`�[���v1�i�Ŕ����j
            temp.StockTotalTaxExc1 = reader.ReadInt64();
            //���d���`�[���v2�i�Ŕ����j
            temp.StockTotalTaxExc2 = reader.ReadInt64();
            //���d���`�[���v3�i�Ŕ����j
            temp.StockTotalTaxExc3 = reader.ReadInt64();
            //���d���`�[���v4�i�Ŕ����j
            temp.StockTotalTaxExc4 = reader.ReadInt64();
            //���d���`�[���v5�i�Ŕ����j
            temp.StockTotalTaxExc5 = reader.ReadInt64();
            //���d���`�[���v6�i�Ŕ����j
            temp.StockTotalTaxExc6 = reader.ReadInt64();
            //���d���`�[���v7�i�Ŕ����j
            temp.StockTotalTaxExc7 = reader.ReadInt64();
            //���d���`�[���v8�i�Ŕ����j
            temp.StockTotalTaxExc8 = reader.ReadInt64();
            //���d���`�[���v9�i�Ŕ����j
            temp.StockTotalTaxExc9 = reader.ReadInt64();
            //���d���`�[���v10�i�Ŕ����j
            temp.StockTotalTaxExc10 = reader.ReadInt64();
            //���d���`�[���v11�i�Ŕ����j
            temp.StockTotalTaxExc11 = reader.ReadInt64();
            //���d���`�[���v12�i�Ŕ����j
            temp.StockTotalTaxExc12 = reader.ReadInt64();
            //���ԕi�z1
            temp.StockRetGoodsPrice1 = reader.ReadInt64();
            //���ԕi�z2
            temp.StockRetGoodsPrice2 = reader.ReadInt64();
            //���ԕi�z3
            temp.StockRetGoodsPrice3 = reader.ReadInt64();
            //���ԕi�z4
            temp.StockRetGoodsPrice4 = reader.ReadInt64();
            //���ԕi�z5
            temp.StockRetGoodsPrice5 = reader.ReadInt64();
            //���ԕi�z6
            temp.StockRetGoodsPrice6 = reader.ReadInt64();
            //���ԕi�z7
            temp.StockRetGoodsPrice7 = reader.ReadInt64();
            //���ԕi�z8
            temp.StockRetGoodsPrice8 = reader.ReadInt64();
            //���ԕi�z9
            temp.StockRetGoodsPrice9 = reader.ReadInt64();
            //���ԕi�z10
            temp.StockRetGoodsPrice10 = reader.ReadInt64();
            //���ԕi�z11
            temp.StockRetGoodsPrice11 = reader.ReadInt64();
            //���ԕi�z12
            temp.StockRetGoodsPrice12 = reader.ReadInt64();


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
        /// <returns>StockTransListResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockTransListResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockTransListResultWork temp = GetStockTransListResultWork(reader, serInfo);
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
                    retValue = (StockTransListResultWork[])lst.ToArray(typeof(StockTransListResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
