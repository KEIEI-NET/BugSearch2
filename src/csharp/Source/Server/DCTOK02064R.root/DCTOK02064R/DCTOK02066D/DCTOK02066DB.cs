using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RsltInfo_ShipGoodsAnalyzeWork
    /// <summary>
    ///                      �o�׏��i���͕\���o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �o�׏��i���͕\���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/09/29  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RsltInfo_ShipGoodsAnalyzeWork
    {
        /// <summary>���_�R�[�h</summary>
        /// <remarks>�v�㋒�_�R�[�h</remarks>
        private string _addUpSecCode = "";

        /// <summary>���_����</summary>
        /// <remarks>���_�K�C�h����</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        private string _makerShortName = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";

        /// <summary>�i��</summary>
        /// <remarks>���i���̃J�i</remarks>
        private string _goodsNameKana = "";

        /// <summary>�i��</summary>
        /// <remarks>���i�ԍ�</remarks>
        private string _goodsNo = "";

        /// <summary>�݌ɓo�^��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _stockCreateDate;

        /// <summary>���݌�</summary>
        /// <remarks>�o�׉\��</remarks>
        private Double _shipmentPosCnt;

        /// <summary>�Œᐔ</summary>
        /// <remarks>�Œ�݌ɐ�</remarks>
        private Double _minimumStockCnt;

        /// <summary>�ō���</summary>
        /// <remarks>�ō��݌ɐ�</remarks>
        private Double _maximumStockCnt;

        /// <summary>���㐔�v(���v)</summary>
        /// <remarks>���яW�v�敪���h���v�h�̔��㐔�v</remarks>
        private Double _totalCount;

        /// <summary>���㐔�v(�݌�)</summary>
        /// <remarks>���яW�v�敪���h�݌Ɂh�̔��㐔�v</remarks>
        private Double _stockCount;

        /// <summary>���㐔�v(���)</summary>
        /// <remarks>���яW�v�敪���h���h�̔��㐔�v</remarks>
        private Double _orderCount;

        /// <summary>����(���v)</summary>
        /// <remarks>������z(���v)</remarks>
        private Int64 _salesMoney;

        /// <summary>�e���z(���v)</summary>
        /// <remarks>�e�����z(���v)</remarks>
        private Int64 _grossProfit;

        /// <summary>�ԕi�z(���v)</summary>
        private Int64 _salesRetGoodsPrice;

        /// <summary>�l�����z(���v)</summary>
        private Int64 _discountPrice;

        /// <summary>����(�݌�)</summary>
        /// <remarks>������z(�݌�)</remarks>
        private Int64 _stockSalesMoney;

        /// <summary>�e���z(�݌�)</summary>
        /// <remarks>�e�����z(�݌�)</remarks>
        private Int64 _stockGrossProfit;

        /// <summary>�ԕi�z(�݌�)</summary>
        private Int64 _stockSalesRetGoodsPrice;

        /// <summary>�l�����z(�݌�)</summary>
        private Int64 _stockDiscountPrice;


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

        /// public propaty name  :  SectionGuideSnm
        /// <summary>���_���̃v���p�e�B</summary>
        /// <value>���_�K�C�h����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
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

        /// public propaty name  :  GoodsNameKana
        /// <summary>�i���v���p�e�B</summary>
        /// <value>���i���̃J�i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>�i�ԃv���p�e�B</summary>
        /// <value>���i�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  StockCreateDate
        /// <summary>�݌ɓo�^���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɓo�^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StockCreateDate
        {
            get { return _stockCreateDate; }
            set { _stockCreateDate = value; }
        }

        /// public propaty name  :  ShipmentPosCnt
        /// <summary>���݌Ƀv���p�e�B</summary>
        /// <value>�o�׉\��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���݌Ƀv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentPosCnt
        {
            get { return _shipmentPosCnt; }
            set { _shipmentPosCnt = value; }
        }

        /// public propaty name  :  MinimumStockCnt
        /// <summary>�Œᐔ�v���p�e�B</summary>
        /// <value>�Œ�݌ɐ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Œᐔ�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MinimumStockCnt
        {
            get { return _minimumStockCnt; }
            set { _minimumStockCnt = value; }
        }

        /// public propaty name  :  MaximumStockCnt
        /// <summary>�ō����v���p�e�B</summary>
        /// <value>�ō��݌ɐ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ō����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MaximumStockCnt
        {
            get { return _maximumStockCnt; }
            set { _maximumStockCnt = value; }
        }

        /// public propaty name  :  TotalCount
        /// <summary>���㐔�v(���v)�v���p�e�B</summary>
        /// <value>���яW�v�敪���h���v�h�̔��㐔�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㐔�v(���v)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalCount
        {
            get { return _totalCount; }
            set { _totalCount = value; }
        }

        /// public propaty name  :  StockCount
        /// <summary>���㐔�v(�݌�)�v���p�e�B</summary>
        /// <value>���яW�v�敪���h�݌Ɂh�̔��㐔�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㐔�v(�݌�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockCount
        {
            get { return _stockCount; }
            set { _stockCount = value; }
        }

        /// public propaty name  :  OrderCount
        /// <summary>���㐔�v(���)�v���p�e�B</summary>
        /// <value>���яW�v�敪���h���h�̔��㐔�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㐔�v(���)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double OrderCount
        {
            get { return _orderCount; }
            set { _orderCount = value; }
        }

        /// public propaty name  :  SalesMoney
        /// <summary>����(���v)�v���p�e�B</summary>
        /// <value>������z(���v)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����(���v)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoney
        {
            get { return _salesMoney; }
            set { _salesMoney = value; }
        }

        /// public propaty name  :  GrossProfit
        /// <summary>�e���z(���v)�v���p�e�B</summary>
        /// <value>�e�����z(���v)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���z(���v)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 GrossProfit
        {
            get { return _grossProfit; }
            set { _grossProfit = value; }
        }

        /// public propaty name  :  SalesRetGoodsPrice
        /// <summary>�ԕi�z(���v)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�z(���v)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesRetGoodsPrice
        {
            get { return _salesRetGoodsPrice; }
            set { _salesRetGoodsPrice = value; }
        }

        /// public propaty name  :  DiscountPrice
        /// <summary>�l�����z(���v)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l�����z(���v)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DiscountPrice
        {
            get { return _discountPrice; }
            set { _discountPrice = value; }
        }

        /// public propaty name  :  StockSalesMoney
        /// <summary>����(�݌�)�v���p�e�B</summary>
        /// <value>������z(�݌�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����(�݌�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockSalesMoney
        {
            get { return _stockSalesMoney; }
            set { _stockSalesMoney = value; }
        }

        /// public propaty name  :  StockGrossProfit
        /// <summary>�e���z(�݌�)�v���p�e�B</summary>
        /// <value>�e�����z(�݌�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���z(�݌�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockGrossProfit
        {
            get { return _stockGrossProfit; }
            set { _stockGrossProfit = value; }
        }

        /// public propaty name  :  StockSalesRetGoodsPrice
        /// <summary>�ԕi�z(�݌�)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�z(�݌�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockSalesRetGoodsPrice
        {
            get { return _stockSalesRetGoodsPrice; }
            set { _stockSalesRetGoodsPrice = value; }
        }

        /// public propaty name  :  StockDiscountPrice
        /// <summary>�l�����z(�݌�)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l�����z(�݌�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockDiscountPrice
        {
            get { return _stockDiscountPrice; }
            set { _stockDiscountPrice = value; }
        }


        /// <summary>
        /// �o�׏��i���͕\���o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>RsltInfo_ShipGoodsAnalyzeWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_ShipGoodsAnalyzeWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RsltInfo_ShipGoodsAnalyzeWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>RsltInfo_ShipGoodsAnalyzeWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   RsltInfo_ShipGoodsAnalyzeWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class RsltInfo_ShipGoodsAnalyzeWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_ShipGoodsAnalyzeWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RsltInfo_ShipGoodsAnalyzeWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RsltInfo_ShipGoodsAnalyzeWork || graph is ArrayList || graph is RsltInfo_ShipGoodsAnalyzeWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(RsltInfo_ShipGoodsAnalyzeWork).FullName));

            if (graph != null && graph is RsltInfo_ShipGoodsAnalyzeWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RsltInfo_ShipGoodsAnalyzeWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RsltInfo_ShipGoodsAnalyzeWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RsltInfo_ShipGoodsAnalyzeWork[])graph).Length;
            }
            else if (graph is RsltInfo_ShipGoodsAnalyzeWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //���_����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerShortName
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //�i��
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //�i��
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //�݌ɓo�^��
            serInfo.MemberInfo.Add(typeof(Int32)); //StockCreateDate
            //���݌�
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentPosCnt
            //�Œᐔ
            serInfo.MemberInfo.Add(typeof(Double)); //MinimumStockCnt
            //�ō���
            serInfo.MemberInfo.Add(typeof(Double)); //MaximumStockCnt
            //���㐔�v(���v)
            serInfo.MemberInfo.Add(typeof(Double)); //TotalCount
            //���㐔�v(�݌�)
            serInfo.MemberInfo.Add(typeof(Double)); //StockCount
            //���㐔�v(���)
            serInfo.MemberInfo.Add(typeof(Double)); //OrderCount
            //����(���v)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney
            //�e���z(���v)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfit
            //�ԕi�z(���v)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesRetGoodsPrice
            //�l�����z(���v)
            serInfo.MemberInfo.Add(typeof(Int64)); //DiscountPrice
            //����(�݌�)
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSalesMoney
            //�e���z(�݌�)
            serInfo.MemberInfo.Add(typeof(Int64)); //StockGrossProfit
            //�ԕi�z(�݌�)
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSalesRetGoodsPrice
            //�l�����z(�݌�)
            serInfo.MemberInfo.Add(typeof(Int64)); //StockDiscountPrice


            serInfo.Serialize(writer, serInfo);
            if (graph is RsltInfo_ShipGoodsAnalyzeWork)
            {
                RsltInfo_ShipGoodsAnalyzeWork temp = (RsltInfo_ShipGoodsAnalyzeWork)graph;

                SetRsltInfo_ShipGoodsAnalyzeWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RsltInfo_ShipGoodsAnalyzeWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RsltInfo_ShipGoodsAnalyzeWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RsltInfo_ShipGoodsAnalyzeWork temp in lst)
                {
                    SetRsltInfo_ShipGoodsAnalyzeWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RsltInfo_ShipGoodsAnalyzeWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 23;

        /// <summary>
        ///  RsltInfo_ShipGoodsAnalyzeWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_ShipGoodsAnalyzeWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetRsltInfo_ShipGoodsAnalyzeWork(System.IO.BinaryWriter writer, RsltInfo_ShipGoodsAnalyzeWork temp)
        {
            //���_�R�[�h
            writer.Write(temp.AddUpSecCode);
            //���_����
            writer.Write(temp.SectionGuideSnm);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���[�J�[����
            writer.Write(temp.MakerShortName);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //�i��
            writer.Write(temp.GoodsNameKana);
            //�i��
            writer.Write(temp.GoodsNo);
            //�݌ɓo�^��
            writer.Write((Int64)temp.StockCreateDate.Ticks);
            //���݌�
            writer.Write(temp.ShipmentPosCnt);
            //�Œᐔ
            writer.Write(temp.MinimumStockCnt);
            //�ō���
            writer.Write(temp.MaximumStockCnt);
            //���㐔�v(���v)
            writer.Write(temp.TotalCount);
            //���㐔�v(�݌�)
            writer.Write(temp.StockCount);
            //���㐔�v(���)
            writer.Write(temp.OrderCount);
            //����(���v)
            writer.Write(temp.SalesMoney);
            //�e���z(���v)
            writer.Write(temp.GrossProfit);
            //�ԕi�z(���v)
            writer.Write(temp.SalesRetGoodsPrice);
            //�l�����z(���v)
            writer.Write(temp.DiscountPrice);
            //����(�݌�)
            writer.Write(temp.StockSalesMoney);
            //�e���z(�݌�)
            writer.Write(temp.StockGrossProfit);
            //�ԕi�z(�݌�)
            writer.Write(temp.StockSalesRetGoodsPrice);
            //�l�����z(�݌�)
            writer.Write(temp.StockDiscountPrice);

        }

        /// <summary>
        ///  RsltInfo_ShipGoodsAnalyzeWork�C���X�^���X�擾
        /// </summary>
        /// <returns>RsltInfo_ShipGoodsAnalyzeWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_ShipGoodsAnalyzeWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private RsltInfo_ShipGoodsAnalyzeWork GetRsltInfo_ShipGoodsAnalyzeWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            RsltInfo_ShipGoodsAnalyzeWork temp = new RsltInfo_ShipGoodsAnalyzeWork();

            //���_�R�[�h
            temp.AddUpSecCode = reader.ReadString();
            //���_����
            temp.SectionGuideSnm = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���[�J�[����
            temp.MakerShortName = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //�i��
            temp.GoodsNameKana = reader.ReadString();
            //�i��
            temp.GoodsNo = reader.ReadString();
            //�݌ɓo�^��
            temp.StockCreateDate = new DateTime(reader.ReadInt64());
            //���݌�
            temp.ShipmentPosCnt = reader.ReadDouble();
            //�Œᐔ
            temp.MinimumStockCnt = reader.ReadDouble();
            //�ō���
            temp.MaximumStockCnt = reader.ReadDouble();
            //���㐔�v(���v)
            temp.TotalCount = reader.ReadDouble();
            //���㐔�v(�݌�)
            temp.StockCount = reader.ReadDouble();
            //���㐔�v(���)
            temp.OrderCount = reader.ReadDouble();
            //����(���v)
            temp.SalesMoney = reader.ReadInt64();
            //�e���z(���v)
            temp.GrossProfit = reader.ReadInt64();
            //�ԕi�z(���v)
            temp.SalesRetGoodsPrice = reader.ReadInt64();
            //�l�����z(���v)
            temp.DiscountPrice = reader.ReadInt64();
            //����(�݌�)
            temp.StockSalesMoney = reader.ReadInt64();
            //�e���z(�݌�)
            temp.StockGrossProfit = reader.ReadInt64();
            //�ԕi�z(�݌�)
            temp.StockSalesRetGoodsPrice = reader.ReadInt64();
            //�l�����z(�݌�)
            temp.StockDiscountPrice = reader.ReadInt64();


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
        /// <returns>RsltInfo_ShipGoodsAnalyzeWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_ShipGoodsAnalyzeWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RsltInfo_ShipGoodsAnalyzeWork temp = GetRsltInfo_ShipGoodsAnalyzeWork(reader, serInfo);
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
                    retValue = (RsltInfo_ShipGoodsAnalyzeWork[])lst.ToArray(typeof(RsltInfo_ShipGoodsAnalyzeWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
