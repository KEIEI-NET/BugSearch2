using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockSlipReadWork
    /// <summary>
    ///                      �d���f�[�^�Ǎ��p�����[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d���f�[�^�Ǎ��p�����[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/01/29  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockSlipReadWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�d���`�[�ԍ�</summary>
        private Int32 _supplierSlipNo;

        /// <summary>�d���`��</summary>
        /// <remarks>0:����(�d��),1:���</remarks>
        private Int32 _supplierFormal;

        /// <summary>�d���`�[�敪</summary>
        /// <remarks>10:�d��,20:�ԕi</remarks>
        private Int32 _supplierSlipCd;

        /// <summary>�ԓ`�敪</summary>
        /// <remarks>0:���`,1:�ԓ`,2:����</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>�d�����i�敪</summary>
        /// <remarks>0:���i,1:���i�O,2:����Œ���,3:�c������</remarks>
        private Int32 _stockGoodsCd;

        /// <summary>�d���S���҃R�[�h</summary>
        private string _stockAgentCode = "";

        /// <summary>�����`�[�ԍ�</summary>
        /// <remarks>�d����`�[�ԍ��Ɏg�p����</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>�d�����_�R�[�h</summary>
        private string _stockSectionCd = "";

        /// <summary>���Ǝ҃R�[�h(�J�n)</summary>
        private Int32 _carrierEpCodeStart;

        /// <summary>���Ǝ҃R�[�h(�I��)</summary>
        private Int32 _carrierEpCodeEnd;

        /// <summary>���Ӑ�R�[�h(�J�n)</summary>
        private Int32 _customerCodeStart;

        /// <summary>���Ӑ�R�[�h(�I��)</summary>
        private Int32 _customerCodeEnd;

        /// <summary>�q�ɃR�[�h(�J�n)</summary>
        private string _warehouseCodeStart = "";

        /// <summary>�q�ɃR�[�h(�I��)</summary>
        private string _warehouseCodeEnd = "";

        /// <summary>�d����(�J�n)</summary>
        private DateTime _stockDateStart;

        /// <summary>�d����(�I��)</summary>
        private DateTime _stockDateEnd;

        /// <summary>�d���v����t(�J�n)</summary>
        /// <remarks>�d���v���</remarks>
        private DateTime _stockAddUpADateStart;

        /// <summary>�d���v����t(�I��)</summary>
        /// <remarks>�d���v���</remarks>
        private DateTime _stockAddUpADateEnd;

        /// <summary>���i�R�[�h</summary>
        private string _goodsCode = "";

        /// <summary>���i�d�b�ԍ�1(�J�n)</summary>
        private string _stockTelNo1Start = "";

        /// <summary>���i�d�b�ԍ�1(�I��)</summary>
        private string _stockTelNo1End = "";

        /// <summary>�����ԍ�1(�J�n)</summary>
        private string _productNumber1Start = "";

        /// <summary>�����ԍ�1(�I��)</summary>
        private string _productNumber1End = "";


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

        /// public propaty name  :  SupplierSlipNo
        /// <summary>�d���`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  SupplierFormal
        /// <summary>�d���`���v���p�e�B</summary>
        /// <value>0:����(�d��),1:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierFormal
        {
            get { return _supplierFormal; }
            set { _supplierFormal = value; }
        }

        /// public propaty name  :  SupplierSlipCd
        /// <summary>�d���`�[�敪�v���p�e�B</summary>
        /// <value>10:�d��,20:�ԕi</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierSlipCd
        {
            get { return _supplierSlipCd; }
            set { _supplierSlipCd = value; }
        }

        /// public propaty name  :  DebitNoteDiv
        /// <summary>�ԓ`�敪�v���p�e�B</summary>
        /// <value>0:���`,1:�ԓ`,2:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԓ`�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        /// public propaty name  :  StockGoodsCd
        /// <summary>�d�����i�敪�v���p�e�B</summary>
        /// <value>0:���i,1:���i�O,2:����Œ���,3:�c������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockGoodsCd
        {
            get { return _stockGoodsCd; }
            set { _stockGoodsCd = value; }
        }

        /// public propaty name  :  StockAgentCode
        /// <summary>�d���S���҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAgentCode
        {
            get { return _stockAgentCode; }
            set { _stockAgentCode = value; }
        }

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>�����`�[�ԍ��v���p�e�B</summary>
        /// <value>�d����`�[�ԍ��Ɏg�p����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
        }

        /// public propaty name  :  StockSectionCd
        /// <summary>�d�����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockSectionCd
        {
            get { return _stockSectionCd; }
            set { _stockSectionCd = value; }
        }

        /// public propaty name  :  CarrierEpCodeStart
        /// <summary>���Ǝ҃R�[�h(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ǝ҃R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarrierEpCodeStart
        {
            get { return _carrierEpCodeStart; }
            set { _carrierEpCodeStart = value; }
        }

        /// public propaty name  :  CarrierEpCodeEnd
        /// <summary>���Ǝ҃R�[�h(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ǝ҃R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarrierEpCodeEnd
        {
            get { return _carrierEpCodeEnd; }
            set { _carrierEpCodeEnd = value; }
        }

        /// public propaty name  :  CustomerCodeStart
        /// <summary>���Ӑ�R�[�h(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCodeStart
        {
            get { return _customerCodeStart; }
            set { _customerCodeStart = value; }
        }

        /// public propaty name  :  CustomerCodeEnd
        /// <summary>���Ӑ�R�[�h(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCodeEnd
        {
            get { return _customerCodeEnd; }
            set { _customerCodeEnd = value; }
        }

        /// public propaty name  :  WarehouseCodeStart
        /// <summary>�q�ɃR�[�h(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCodeStart
        {
            get { return _warehouseCodeStart; }
            set { _warehouseCodeStart = value; }
        }

        /// public propaty name  :  WarehouseCodeEnd
        /// <summary>�q�ɃR�[�h(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCodeEnd
        {
            get { return _warehouseCodeEnd; }
            set { _warehouseCodeEnd = value; }
        }

        /// public propaty name  :  StockDateStart
        /// <summary>�d����(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StockDateStart
        {
            get { return _stockDateStart; }
            set { _stockDateStart = value; }
        }

        /// public propaty name  :  StockDateEnd
        /// <summary>�d����(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StockDateEnd
        {
            get { return _stockDateEnd; }
            set { _stockDateEnd = value; }
        }

        /// public propaty name  :  StockAddUpADateStart
        /// <summary>�d���v����t(�J�n)�v���p�e�B</summary>
        /// <value>�d���v���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���v����t(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StockAddUpADateStart
        {
            get { return _stockAddUpADateStart; }
            set { _stockAddUpADateStart = value; }
        }

        /// public propaty name  :  StockAddUpADateEnd
        /// <summary>�d���v����t(�I��)�v���p�e�B</summary>
        /// <value>�d���v���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���v����t(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StockAddUpADateEnd
        {
            get { return _stockAddUpADateEnd; }
            set { _stockAddUpADateEnd = value; }
        }

        /// public propaty name  :  GoodsCode
        /// <summary>���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsCode
        {
            get { return _goodsCode; }
            set { _goodsCode = value; }
        }

        /// public propaty name  :  StockTelNo1Start
        /// <summary>���i�d�b�ԍ�1(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�d�b�ԍ�1(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockTelNo1Start
        {
            get { return _stockTelNo1Start; }
            set { _stockTelNo1Start = value; }
        }

        /// public propaty name  :  StockTelNo1End
        /// <summary>���i�d�b�ԍ�1(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�d�b�ԍ�1(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockTelNo1End
        {
            get { return _stockTelNo1End; }
            set { _stockTelNo1End = value; }
        }

        /// public propaty name  :  ProductNumber1Start
        /// <summary>�����ԍ�1(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ԍ�1(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ProductNumber1Start
        {
            get { return _productNumber1Start; }
            set { _productNumber1Start = value; }
        }

        /// public propaty name  :  ProductNumber1End
        /// <summary>�����ԍ�1(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ԍ�1(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ProductNumber1End
        {
            get { return _productNumber1End; }
            set { _productNumber1End = value; }
        }


        /// <summary>
        /// �`�[���������p�����[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockSlipReadWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockSlipReadWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockSlipReadWork()
        {
        }

    }

#if false

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>StockSlipReadWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   StockSlipReadWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class StockSlipReadWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockSlipReadWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockSlipReadWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockSlipReadWork || graph is ArrayList || graph is StockSlipReadWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(StockSlipReadWork).FullName));

            if (graph != null && graph is StockSlipReadWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockSlipReadWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockSlipReadWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockSlipReadWork[])graph).Length;
            }
            else if (graph is StockSlipReadWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //�d���`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //�d���`��
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //�d���`�[�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipCd
            //�ԓ`�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
            //�d�����i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockGoodsCd
            //�d���S���҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentCode
            //�����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNum
            //�d�����_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionCd
            //���Ǝ҃R�[�h(�J�n)
            serInfo.MemberInfo.Add(typeof(Int32)); //CarrierEpCodeStart
            //���Ǝ҃R�[�h(�I��)
            serInfo.MemberInfo.Add(typeof(Int32)); //CarrierEpCodeEnd
            //���Ӑ�R�[�h(�J�n)
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCodeStart
            //���Ӑ�R�[�h(�I��)
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCodeEnd
            //�q�ɃR�[�h(�J�n)
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCodeStart
            //�q�ɃR�[�h(�I��)
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCodeEnd
            //�d����(�J�n)
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDateStart
            //�d����(�I��)
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDateEnd
            //�d���v����t(�J�n)
            serInfo.MemberInfo.Add(typeof(Int32)); //StockAddUpADateStart
            //�d���v����t(�I��)
            serInfo.MemberInfo.Add(typeof(Int32)); //StockAddUpADateEnd
            //���i�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //GoodsCode
            //���i�d�b�ԍ�1(�J�n)
            serInfo.MemberInfo.Add(typeof(string)); //StockTelNo1Start
            //���i�d�b�ԍ�1(�I��)
            serInfo.MemberInfo.Add(typeof(string)); //StockTelNo1End
            //�����ԍ�1(�J�n)
            serInfo.MemberInfo.Add(typeof(string)); //ProductNumber1Start
            //�����ԍ�1(�I��)
            serInfo.MemberInfo.Add(typeof(string)); //ProductNumber1End


            serInfo.Serialize(writer, serInfo);
            if (graph is StockSlipReadWork)
            {
                StockSlipReadWork temp = (StockSlipReadWork)graph;

                SetStockSlipReadWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockSlipReadWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockSlipReadWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockSlipReadWork temp in lst)
                {
                    SetStockSlipReadWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockSlipReadWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 24;

        /// <summary>
        ///  StockSlipReadWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockSlipReadWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetStockSlipReadWork(System.IO.BinaryWriter writer, StockSlipReadWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //�d���`�[�ԍ�
            writer.Write(temp.SupplierSlipNo);
            //�d���`��
            writer.Write(temp.SupplierFormal);
            //�d���`�[�敪
            writer.Write(temp.SupplierSlipCd);
            //�ԓ`�敪
            writer.Write(temp.DebitNoteDiv);
            //�d�����i�敪
            writer.Write(temp.StockGoodsCd);
            //�d���S���҃R�[�h
            writer.Write(temp.StockAgentCode);
            //�����`�[�ԍ�
            writer.Write(temp.PartySaleSlipNum);
            //�d�����_�R�[�h
            writer.Write(temp.StockSectionCd);
            //���Ǝ҃R�[�h(�J�n)
            writer.Write(temp.CarrierEpCodeStart);
            //���Ǝ҃R�[�h(�I��)
            writer.Write(temp.CarrierEpCodeEnd);
            //���Ӑ�R�[�h(�J�n)
            writer.Write(temp.CustomerCodeStart);
            //���Ӑ�R�[�h(�I��)
            writer.Write(temp.CustomerCodeEnd);
            //�q�ɃR�[�h(�J�n)
            writer.Write(temp.WarehouseCodeStart);
            //�q�ɃR�[�h(�I��)
            writer.Write(temp.WarehouseCodeEnd);
            //�d����(�J�n)
            writer.Write((Int64)temp.StockDateStart.Ticks);
            //�d����(�I��)
            writer.Write((Int64)temp.StockDateEnd.Ticks);
            //�d���v����t(�J�n)
            writer.Write((Int64)temp.StockAddUpADateStart.Ticks);
            //�d���v����t(�I��)
            writer.Write((Int64)temp.StockAddUpADateEnd.Ticks);
            //���i�R�[�h
            writer.Write(temp.GoodsCode);
            //���i�d�b�ԍ�1(�J�n)
            writer.Write(temp.StockTelNo1Start);
            //���i�d�b�ԍ�1(�I��)
            writer.Write(temp.StockTelNo1End);
            //�����ԍ�1(�J�n)
            writer.Write(temp.ProductNumber1Start);
            //�����ԍ�1(�I��)
            writer.Write(temp.ProductNumber1End);

        }

        /// <summary>
        ///  StockSlipReadWork�C���X�^���X�擾
        /// </summary>
        /// <returns>StockSlipReadWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockSlipReadWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private StockSlipReadWork GetStockSlipReadWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            StockSlipReadWork temp = new StockSlipReadWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //�d���`�[�ԍ�
            temp.SupplierSlipNo = reader.ReadInt32();
            //�d���`��
            temp.SupplierFormal = reader.ReadInt32();
            //�d���`�[�敪
            temp.SupplierSlipCd = reader.ReadInt32();
            //�ԓ`�敪
            temp.DebitNoteDiv = reader.ReadInt32();
            //�d�����i�敪
            temp.StockGoodsCd = reader.ReadInt32();
            //�d���S���҃R�[�h
            temp.StockAgentCode = reader.ReadString();
            //�����`�[�ԍ�
            temp.PartySaleSlipNum = reader.ReadString();
            //�d�����_�R�[�h
            temp.StockSectionCd = reader.ReadString();
            //���Ǝ҃R�[�h(�J�n)
            temp.CarrierEpCodeStart = reader.ReadInt32();
            //���Ǝ҃R�[�h(�I��)
            temp.CarrierEpCodeEnd = reader.ReadInt32();
            //���Ӑ�R�[�h(�J�n)
            temp.CustomerCodeStart = reader.ReadInt32();
            //���Ӑ�R�[�h(�I��)
            temp.CustomerCodeEnd = reader.ReadInt32();
            //�q�ɃR�[�h(�J�n)
            temp.WarehouseCodeStart = reader.ReadString();
            //�q�ɃR�[�h(�I��)
            temp.WarehouseCodeEnd = reader.ReadString();
            //�d����(�J�n)
            temp.StockDateStart = new DateTime(reader.ReadInt64());
            //�d����(�I��)
            temp.StockDateEnd = new DateTime(reader.ReadInt64());
            //�d���v����t(�J�n)
            temp.StockAddUpADateStart = new DateTime(reader.ReadInt64());
            //�d���v����t(�I��)
            temp.StockAddUpADateEnd = new DateTime(reader.ReadInt64());
            //���i�R�[�h
            temp.GoodsCode = reader.ReadString();
            //���i�d�b�ԍ�1(�J�n)
            temp.StockTelNo1Start = reader.ReadString();
            //���i�d�b�ԍ�1(�I��)
            temp.StockTelNo1End = reader.ReadString();
            //�����ԍ�1(�J�n)
            temp.ProductNumber1Start = reader.ReadString();
            //�����ԍ�1(�I��)
            temp.ProductNumber1End = reader.ReadString();


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
        /// <returns>StockSlipReadWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockSlipReadWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockSlipReadWork temp = GetStockSlipReadWork(reader, serInfo);
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
                    retValue = (StockSlipReadWork[])lst.ToArray(typeof(StockSlipReadWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

#endif
}
