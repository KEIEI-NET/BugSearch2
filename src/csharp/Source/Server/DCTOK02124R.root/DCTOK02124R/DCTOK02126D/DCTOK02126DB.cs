using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesRsltListResultWork
    /// <summary>
    ///                      ������ѕ\���o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ������ѕ\���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/14  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesRsltListResultWork
    {
        /// <summary>���_�R�[�h</summary>
        /// <remarks>�v�㋒�_�R�[�h</remarks>
        private string _addUpSecCode = "";

        /// <summary>���_����</summary>
        /// <remarks>���_�K�C�h����</remarks>
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

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        /// <summary>�q�ɖ���</summary>
        private string _warehouseName = "";

        /// <summary>�����o�א�</summary>
        /// <remarks>���㐔�v</remarks>
        private Double _monthTotalSalesCount;

        /// <summary>��������z</summary>
        private Int64 _monthSalesMoney;

        /// <summary>�����ԕi�z</summary>
        private Int64 _monthSalesRetGoodsPrice;

        /// <summary>�����l���z</summary>
        private Int64 _monthDiscountPrice;

        /// <summary>�����e���z</summary>
        private Int64 _monthGrossProfit;

        /// <summary>�����o�א�</summary>
        private Double _annualTotalSalesCount;

        /// <summary>��������z</summary>
        private Int64 _annualSalesMoney;

        /// <summary>�����ԕi�z</summary>
        private Int64 _annualSalesRetGoodsPrice;

        /// <summary>�����l���z</summary>
        private Int64 _annualDiscountPrice;

        /// <summary>�����e���z</summary>
        private Int64 _annualGrossProfit;


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
        /// <value>���_�K�C�h����</value>
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

        /// public propaty name  :  MonthTotalSalesCount
        /// <summary>�����o�א��v���p�e�B</summary>
        /// <value>���㐔�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����o�א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MonthTotalSalesCount
        {
            get { return _monthTotalSalesCount; }
            set { _monthTotalSalesCount = value; }
        }

        /// public propaty name  :  MonthSalesMoney
        /// <summary>��������z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthSalesMoney
        {
            get { return _monthSalesMoney; }
            set { _monthSalesMoney = value; }
        }

        /// public propaty name  :  MonthSalesRetGoodsPrice
        /// <summary>�����ԕi�z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ԕi�z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthSalesRetGoodsPrice
        {
            get { return _monthSalesRetGoodsPrice; }
            set { _monthSalesRetGoodsPrice = value; }
        }

        /// public propaty name  :  MonthDiscountPrice
        /// <summary>�����l���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����l���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthDiscountPrice
        {
            get { return _monthDiscountPrice; }
            set { _monthDiscountPrice = value; }
        }

        /// public propaty name  :  MonthGrossProfit
        /// <summary>�����e���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����e���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthGrossProfit
        {
            get { return _monthGrossProfit; }
            set { _monthGrossProfit = value; }
        }

        /// public propaty name  :  AnnualTotalSalesCount
        /// <summary>�����o�א��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����o�א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AnnualTotalSalesCount
        {
            get { return _annualTotalSalesCount; }
            set { _annualTotalSalesCount = value; }
        }

        /// public propaty name  :  AnnualSalesMoney
        /// <summary>��������z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AnnualSalesMoney
        {
            get { return _annualSalesMoney; }
            set { _annualSalesMoney = value; }
        }

        /// public propaty name  :  AnnualSalesRetGoodsPrice
        /// <summary>�����ԕi�z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ԕi�z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AnnualSalesRetGoodsPrice
        {
            get { return _annualSalesRetGoodsPrice; }
            set { _annualSalesRetGoodsPrice = value; }
        }

        /// public propaty name  :  AnnualDiscountPrice
        /// <summary>�����l���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����l���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AnnualDiscountPrice
        {
            get { return _annualDiscountPrice; }
            set { _annualDiscountPrice = value; }
        }

        /// public propaty name  :  AnnualGrossProfit
        /// <summary>�����e���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����e���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AnnualGrossProfit
        {
            get { return _annualGrossProfit; }
            set { _annualGrossProfit = value; }
        }


        /// <summary>
        /// ������ѕ\���o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SalesRsltListResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesRsltListResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesRsltListResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SalesRsltListResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SalesRsltListResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SalesRsltListResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesRsltListResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalesRsltListResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalesRsltListResultWork || graph is ArrayList || graph is SalesRsltListResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SalesRsltListResultWork).FullName));

            if (graph != null && graph is SalesRsltListResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalesRsltListResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalesRsltListResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalesRsltListResultWork[])graph).Length;
            }
            else if (graph is SalesRsltListResultWork)
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
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //�q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //�����o�א�
            serInfo.MemberInfo.Add(typeof(Double)); //MonthTotalSalesCount
            //��������z
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesMoney
            //�����ԕi�z
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesRetGoodsPrice
            //�����l���z
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthDiscountPrice
            //�����e���z
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthGrossProfit
            //�����o�א�
            serInfo.MemberInfo.Add(typeof(Double)); //AnnualTotalSalesCount
            //��������z
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualSalesMoney
            //�����ԕi�z
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualSalesRetGoodsPrice
            //�����l���z
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualDiscountPrice
            //�����e���z
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualGrossProfit


            serInfo.Serialize(writer, serInfo);
            if (graph is SalesRsltListResultWork)
            {
                SalesRsltListResultWork temp = (SalesRsltListResultWork)graph;

                SetSalesRsltListResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalesRsltListResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalesRsltListResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalesRsltListResultWork temp in lst)
                {
                    SetSalesRsltListResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalesRsltListResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 32;

        /// <summary>
        ///  SalesRsltListResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesRsltListResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSalesRsltListResultWork(System.IO.BinaryWriter writer, SalesRsltListResultWork temp)
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
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //�q�ɖ���
            writer.Write(temp.WarehouseName);
            //�����o�א�
            writer.Write(temp.MonthTotalSalesCount);
            //��������z
            writer.Write(temp.MonthSalesMoney);
            //�����ԕi�z
            writer.Write(temp.MonthSalesRetGoodsPrice);
            //�����l���z
            writer.Write(temp.MonthDiscountPrice);
            //�����e���z
            writer.Write(temp.MonthGrossProfit);
            //�����o�א�
            writer.Write(temp.AnnualTotalSalesCount);
            //��������z
            writer.Write(temp.AnnualSalesMoney);
            //�����ԕi�z
            writer.Write(temp.AnnualSalesRetGoodsPrice);
            //�����l���z
            writer.Write(temp.AnnualDiscountPrice);
            //�����e���z
            writer.Write(temp.AnnualGrossProfit);

        }

        /// <summary>
        ///  SalesRsltListResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SalesRsltListResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesRsltListResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SalesRsltListResultWork GetSalesRsltListResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SalesRsltListResultWork temp = new SalesRsltListResultWork();

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
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //�q�ɖ���
            temp.WarehouseName = reader.ReadString();
            //�����o�א�
            temp.MonthTotalSalesCount = reader.ReadDouble();
            //��������z
            temp.MonthSalesMoney = reader.ReadInt64();
            //�����ԕi�z
            temp.MonthSalesRetGoodsPrice = reader.ReadInt64();
            //�����l���z
            temp.MonthDiscountPrice = reader.ReadInt64();
            //�����e���z
            temp.MonthGrossProfit = reader.ReadInt64();
            //�����o�א�
            temp.AnnualTotalSalesCount = reader.ReadDouble();
            //��������z
            temp.AnnualSalesMoney = reader.ReadInt64();
            //�����ԕi�z
            temp.AnnualSalesRetGoodsPrice = reader.ReadInt64();
            //�����l���z
            temp.AnnualDiscountPrice = reader.ReadInt64();
            //�����e���z
            temp.AnnualGrossProfit = reader.ReadInt64();


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
        /// <returns>SalesRsltListResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesRsltListResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalesRsltListResultWork temp = GetSalesRsltListResultWork(reader, serInfo);
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
                    retValue = (SalesRsltListResultWork[])lst.ToArray(typeof(SalesRsltListResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
