using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockHistoryDspSearchResultWork
    /// <summary>
    ///                      �݌Ɏ��яƉ�o���ʃ��[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �݌Ɏ��яƉ�o���ʃ��[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/03  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockHistoryDspSearchResultWork 
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�v��N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
        /// <summary>�I��</summary>
        private string _warehouseShelfNo = "";

        /// <summary>BL�R�[�h</summary>
        private Int32 _blGoodsCode;

        /// <summary>�݌ɓo�^��</summary>
        private DateTime _stockCreateDate;

        /// <summary>�ŏI�����</summary>
        private DateTime _lastSalesDate;

        /// <summary>�ŏI�d����</summary>
        private DateTime _lastStockDate;
        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
        /// <summary>���i����</summary>
        private string _goodsName = "";
        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>�����</summary>
        private Int32 _salesTimes;

        /// <summary>���㐔</summary>
        private Double _salesCount;

        /// <summary>������z�i�Ŕ����j</summary>
        private Int64 _salesMoneyTaxExc;

        /// <summary>�d����</summary>
        private Int32 _stockTimes;

        /// <summary>�d����</summary>
        private Double _stockCount;

        /// <summary>�d�����z�i�Ŕ����j</summary>
        private Int64 _stockPriceTaxExc;

        /// <summary>�e�����z</summary>
        private Int64 _grossProfit;

        /// <summary>�ړ����א�</summary>
        private Double _moveArrivalCnt;

        /// <summary>�ړ����׊z</summary>
        private Int64 _moveArrivalPrice;

        /// <summary>�ړ��o�א�</summary>
        private Double _moveShipmentCnt;

        /// <summary>�ړ��o�׊z</summary>
        private Int64 _moveShipmentPrice;

        /// <summary>�����敪</summary>
        /// <remarks>0:������,1:�ߋ���</remarks>
        private Int32 _searchDiv;


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

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  AddUpYearMonth
        /// <summary>�v��N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpYearMonth
        {
            get { return _addUpYearMonth; }
            set { _addUpYearMonth = value; }
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

        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
        /// public propaty name  :  WarehouseShelfNo
        /// <summary>�I�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  BlGoodsCode
        /// <summary>BL�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BlGoodsCode
        {
            get { return _blGoodsCode; }
            set { _blGoodsCode = value; }
        }

        /// public propaty name  :  StockCreateDate
        /// <summary>�݌ɓo�^���v���p�e�B</summary>
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

        /// public propaty name  :  LastSalesDate
        /// <summary>�ŏI������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime LastSalesDate
        {
            get { return _lastSalesDate; }
            set { _lastSalesDate = value; }
        }

        /// public propaty name  :  SastStockDate
        /// <summary>�ŏI�d�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI�d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime LastStockDate
        {
            get { return _lastStockDate; }
            set { _lastStockDate = value; }
        }
        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<

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

        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
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
        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<

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

        /// public propaty name  :  SalesTimes
        /// <summary>����񐔃v���p�e�B</summary>
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

        /// public propaty name  :  SalesCount
        /// <summary>���㐔�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㐔�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesCount
        {
            get { return _salesCount; }
            set { _salesCount = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc
        /// <summary>������z�i�Ŕ����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc
        {
            get { return _salesMoneyTaxExc; }
            set { _salesMoneyTaxExc = value; }
        }

        /// public propaty name  :  StockTimes
        /// <summary>�d���񐔃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���񐔃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockTimes
        {
            get { return _stockTimes; }
            set { _stockTimes = value; }
        }

        /// public propaty name  :  StockCount
        /// <summary>�d�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockCount
        {
            get { return _stockCount; }
            set { _stockCount = value; }
        }

        /// public propaty name  :  StockPriceTaxExc
        /// <summary>�d�����z�i�Ŕ����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockPriceTaxExc
        {
            get { return _stockPriceTaxExc; }
            set { _stockPriceTaxExc = value; }
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

        /// public propaty name  :  MoveArrivalCnt
        /// <summary>�ړ����א��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MoveArrivalCnt
        {
            get { return _moveArrivalCnt; }
            set { _moveArrivalCnt = value; }
        }

        /// public propaty name  :  MoveArrivalPrice
        /// <summary>�ړ����׊z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����׊z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MoveArrivalPrice
        {
            get { return _moveArrivalPrice; }
            set { _moveArrivalPrice = value; }
        }

        /// public propaty name  :  MoveShipmentCnt
        /// <summary>�ړ��o�א��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ��o�א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MoveShipmentCnt
        {
            get { return _moveShipmentCnt; }
            set { _moveShipmentCnt = value; }
        }

        /// public propaty name  :  MoveShipmentPrice
        /// <summary>�ړ��o�׊z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ��o�׊z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MoveShipmentPrice
        {
            get { return _moveShipmentPrice; }
            set { _moveShipmentPrice = value; }
        }

        /// public propaty name  :  SearchDiv
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value>0:������,1:�ߋ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchDiv
        {
            get { return _searchDiv; }
            set { _searchDiv = value; }
        }


        /// <summary>
        /// �݌Ɏ��яƉ�o���ʃ��[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockHistoryDspSearchResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockHistoryDspSearchResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockHistoryDspSearchResultWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>StockHistoryDspSearchResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   StockHistoryDspSearchResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class StockHistoryDspSearchResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockHistoryDspSearchResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockHistoryDspSearchResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockHistoryDspSearchResultWork || graph is ArrayList || graph is StockHistoryDspSearchResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(StockHistoryDspSearchResultWork).FullName));

            if (graph != null && graph is StockHistoryDspSearchResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockHistoryDspSearchResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockHistoryDspSearchResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockHistoryDspSearchResultWork[])graph).Length;
            }
            else if (graph is StockHistoryDspSearchResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //�v��N��
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpYearMonth
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
            //�I��
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //BL�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BlGoodsCode
            //�݌ɓo�^��
            serInfo.MemberInfo.Add(typeof(Int32)); //StockCreateDate
            //�ŏI�����
            serInfo.MemberInfo.Add(typeof(Int32)); //LastSalesDate
            //�ŏI�d����
            serInfo.MemberInfo.Add(typeof(Int32)); //SastStockDate
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //�����
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesTimes
            //���㐔
            serInfo.MemberInfo.Add(typeof(Double)); //SalesCount
            //������z�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //�d����
            serInfo.MemberInfo.Add(typeof(Int32)); //StockTimes
            //�d����
            serInfo.MemberInfo.Add(typeof(Double)); //StockCount
            //�d�����z�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxExc
            //�e�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfit
            //�ړ����א�
            serInfo.MemberInfo.Add(typeof(Double)); //MoveArrivalCnt
            //�ړ����׊z
            serInfo.MemberInfo.Add(typeof(Int64)); //MoveArrivalPrice
            //�ړ��o�א�
            serInfo.MemberInfo.Add(typeof(Double)); //MoveShipmentCnt
            //�ړ��o�׊z
            serInfo.MemberInfo.Add(typeof(Int64)); //MoveShipmentPrice
            //�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SearchDiv


            serInfo.Serialize(writer, serInfo);
            if (graph is StockHistoryDspSearchResultWork)
            {
                StockHistoryDspSearchResultWork temp = (StockHistoryDspSearchResultWork)graph;

                SetStockHistoryDspSearchResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockHistoryDspSearchResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockHistoryDspSearchResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockHistoryDspSearchResultWork temp in lst)
                {
                    SetStockHistoryDspSearchResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockHistoryDspSearchResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 24;

        /// <summary>
        ///  StockHistoryDspSearchResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockHistoryDspSearchResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetStockHistoryDspSearchResultWork(System.IO.BinaryWriter writer, StockHistoryDspSearchResultWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //�v��N��
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
            //�I��
            writer.Write(temp.WarehouseShelfNo);
            //BL�R�[�h
            writer.Write(temp.BlGoodsCode);
            //�݌ɓo�^��
            writer.Write((Int64)temp.StockCreateDate.Ticks);
            //�ŏI�����
            writer.Write((Int64)temp.LastSalesDate.Ticks);
            //�ŏI�d����
            writer.Write((Int64)temp.LastStockDate.Ticks);
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
            //���i����
            writer.Write(temp.GoodsName);
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //�����
            writer.Write(temp.SalesTimes);
            //���㐔
            writer.Write(temp.SalesCount);
            //������z�i�Ŕ����j
            writer.Write(temp.SalesMoneyTaxExc);
            //�d����
            writer.Write(temp.StockTimes);
            //�d����
            writer.Write(temp.StockCount);
            //�d�����z�i�Ŕ����j
            writer.Write(temp.StockPriceTaxExc);
            //�e�����z
            writer.Write(temp.GrossProfit);
            //�ړ����א�
            writer.Write(temp.MoveArrivalCnt);
            //�ړ����׊z
            writer.Write(temp.MoveArrivalPrice);
            //�ړ��o�א�
            writer.Write(temp.MoveShipmentCnt);
            //�ړ��o�׊z
            writer.Write(temp.MoveShipmentPrice);
            //�����敪
            writer.Write(temp.SearchDiv);

        }

        /// <summary>
        ///  StockHistoryDspSearchResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>StockHistoryDspSearchResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockHistoryDspSearchResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private StockHistoryDspSearchResultWork GetStockHistoryDspSearchResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            StockHistoryDspSearchResultWork temp = new StockHistoryDspSearchResultWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //�v��N��
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
            //�I��
            temp.WarehouseShelfNo = reader.ReadString();
            //BL�R�[�h
            temp.BlGoodsCode = reader.ReadInt32();
            //�݌ɓo�^��
            temp.StockCreateDate = new DateTime(reader.ReadInt64());
            //�ŏI�����
            temp.LastSalesDate = new DateTime(reader.ReadInt64());
            //�ŏI�d����
            temp.LastStockDate = new DateTime(reader.ReadInt64());
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
            //���i����
            temp.GoodsName = reader.ReadString();
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //�����
            temp.SalesTimes = reader.ReadInt32();
            //���㐔
            temp.SalesCount = reader.ReadDouble();
            //������z�i�Ŕ����j
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //�d����
            temp.StockTimes = reader.ReadInt32();
            //�d����
            temp.StockCount = reader.ReadDouble();
            //�d�����z�i�Ŕ����j
            temp.StockPriceTaxExc = reader.ReadInt64();
            //�e�����z
            temp.GrossProfit = reader.ReadInt64();
            //�ړ����א�
            temp.MoveArrivalCnt = reader.ReadDouble();
            //�ړ����׊z
            temp.MoveArrivalPrice = reader.ReadInt64();
            //�ړ��o�א�
            temp.MoveShipmentCnt = reader.ReadDouble();
            //�ړ��o�׊z
            temp.MoveShipmentPrice = reader.ReadInt64();
            //�����敪
            temp.SearchDiv = reader.ReadInt32();


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
        /// <returns>StockHistoryDspSearchResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockHistoryDspSearchResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockHistoryDspSearchResultWork temp = GetStockHistoryDspSearchResultWork(reader, serInfo);
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
                    retValue = (StockHistoryDspSearchResultWork[])lst.ToArray(typeof(StockHistoryDspSearchResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
