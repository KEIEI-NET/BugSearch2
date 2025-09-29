using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesSlipYearContrastResultWork
    /// <summary>
    ///                      ����d���Δ�\(����N��)���o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����d���Δ�\(����N��)���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/18  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesSlipYearContrastResultWork 
    {
        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _addUpSecCode = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���[�󎚗p</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";

        /// <summary>������z(���v)(����)</summary>
        /// <remarks>�Ŕ���</remarks>
        private Int64 _salesMoney;

        /// <summary>������z(�݌�)(����)</summary>
        private Int64 _salesMoneyStock;

        /// <summary>�e�����z(����)</summary>
        private Int64 _grossProfit;

        /// <summary>�ړ��o�׊z(����)</summary>
        private Int64 _moveShipmentPrice;

        /// <summary>�d�����z���v(���v)(����)</summary>
        /// <remarks>�l���܂�</remarks>
        private Int64 _stockTotalPrice;

        /// <summary>�d�����z���v(�݌�)(����)</summary>
        private Int64 _stockTotalPriceStock;

        /// <summary>�ړ����׊z(����)</summary>
        private Int64 _moveArrivalPrice;

        /// <summary>������z(���v)(����)</summary>
        private Int64 _annualSalesMoney;

        /// <summary>������z(�݌�)(����)</summary>
        private Int64 _annualSalesMoneyStock;

        /// <summary>�e�����z(����)</summary>
        private Int64 _annualGrossProfit;

        /// <summary>�ړ��o�׊z(����)</summary>
        private Int64 _annualMoveShipmentPrice;

        /// <summary>�d�����z���v(���v)(����)</summary>
        private Int64 _annualStockTotalPrice;

        /// <summary>�d�����z���v(�݌�)(����)</summary>
        private Int64 _annualStockTotalPriceStock;

        /// <summary>�ړ����׊z(����)</summary>
        private Int64 _annualMoveArrivalPrice;


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
        /// <summary>������z(���v)(����)�v���p�e�B</summary>
        /// <value>�Ŕ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z(���v)(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoney
        {
            get { return _salesMoney; }
            set { _salesMoney = value; }
        }

        /// public propaty name  :  SalesMoneyStock
        /// <summary>������z(�݌�)(����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z(�݌�)(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyStock
        {
            get { return _salesMoneyStock; }
            set { _salesMoneyStock = value; }
        }

        /// public propaty name  :  GrossProfit
        /// <summary>�e�����z(����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�����z(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 GrossProfit
        {
            get { return _grossProfit; }
            set { _grossProfit = value; }
        }

        /// public propaty name  :  MoveShipmentPrice
        /// <summary>�ړ��o�׊z(����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ��o�׊z(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MoveShipmentPrice
        {
            get { return _moveShipmentPrice; }
            set { _moveShipmentPrice = value; }
        }

        /// public propaty name  :  StockTotalPrice
        /// <summary>�d�����z���v(���v)(����)�v���p�e�B</summary>
        /// <value>�l���܂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z���v(���v)(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTotalPrice
        {
            get { return _stockTotalPrice; }
            set { _stockTotalPrice = value; }
        }

        /// public propaty name  :  StockTotalPriceStock
        /// <summary>�d�����z���v(�݌�)(����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z���v(�݌�)(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTotalPriceStock
        {
            get { return _stockTotalPriceStock; }
            set { _stockTotalPriceStock = value; }
        }

        /// public propaty name  :  MoveArrivalPrice
        /// <summary>�ړ����׊z(����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����׊z(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MoveArrivalPrice
        {
            get { return _moveArrivalPrice; }
            set { _moveArrivalPrice = value; }
        }

        /// public propaty name  :  AnnualSalesMoney
        /// <summary>������z(���v)(����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z(���v)(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AnnualSalesMoney
        {
            get { return _annualSalesMoney; }
            set { _annualSalesMoney = value; }
        }

        /// public propaty name  :  AnnualSalesMoneyStock
        /// <summary>������z(�݌�)(����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z(�݌�)(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AnnualSalesMoneyStock
        {
            get { return _annualSalesMoneyStock; }
            set { _annualSalesMoneyStock = value; }
        }

        /// public propaty name  :  AnnualGrossProfit
        /// <summary>�e�����z(����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�����z(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AnnualGrossProfit
        {
            get { return _annualGrossProfit; }
            set { _annualGrossProfit = value; }
        }

        /// public propaty name  :  AnnualMoveShipmentPrice
        /// <summary>�ړ��o�׊z(����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ��o�׊z(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AnnualMoveShipmentPrice
        {
            get { return _annualMoveShipmentPrice; }
            set { _annualMoveShipmentPrice = value; }
        }

        /// public propaty name  :  AnnualStockTotalPrice
        /// <summary>�d�����z���v(���v)(����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z���v(���v)(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AnnualStockTotalPrice
        {
            get { return _annualStockTotalPrice; }
            set { _annualStockTotalPrice = value; }
        }

        /// public propaty name  :  AnnualStockTotalPriceStock
        /// <summary>�d�����z���v(�݌�)(����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z���v(�݌�)(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AnnualStockTotalPriceStock
        {
            get { return _annualStockTotalPriceStock; }
            set { _annualStockTotalPriceStock = value; }
        }

        /// public propaty name  :  AnnualMoveArrivalPrice
        /// <summary>�ړ����׊z(����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����׊z(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AnnualMoveArrivalPrice
        {
            get { return _annualMoveArrivalPrice; }
            set { _annualMoveArrivalPrice = value; }
        }


        /// <summary>
        /// ����d���Δ�\(����N��)���o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SalesSlipYearContrastResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesSlipYearContrastResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesSlipYearContrastResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SalesSlipYearContrastResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SalesSlipYearContrastResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SalesSlipYearContrastResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesSlipYearContrastResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalesSlipYearContrastResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalesSlipYearContrastResultWork || graph is ArrayList || graph is SalesSlipYearContrastResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SalesSlipYearContrastResultWork).FullName));

            if (graph != null && graph is SalesSlipYearContrastResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalesSlipYearContrastResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalesSlipYearContrastResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalesSlipYearContrastResultWork[])graph).Length;
            }
            else if (graph is SalesSlipYearContrastResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //������z(���v)(����)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney
            //������z(�݌�)(����)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyStock
            //�e�����z(����)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfit
            //�ړ��o�׊z(����)
            serInfo.MemberInfo.Add(typeof(Int64)); //MoveShipmentPrice
            //�d�����z���v(���v)(����)
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalPrice
            //�d�����z���v(�݌�)(����)
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalPriceStock
            //�ړ����׊z(����)
            serInfo.MemberInfo.Add(typeof(Int64)); //MoveArrivalPrice
            //������z(���v)(����)
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualSalesMoney
            //������z(�݌�)(����)
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualSalesMoneyStock
            //�e�����z(����)
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualGrossProfit
            //�ړ��o�׊z(����)
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualMoveShipmentPrice
            //�d�����z���v(���v)(����)
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualStockTotalPrice
            //�d�����z���v(�݌�)(����)
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualStockTotalPriceStock
            //�ړ����׊z(����)
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualMoveArrivalPrice


            serInfo.Serialize(writer, serInfo);
            if (graph is SalesSlipYearContrastResultWork)
            {
                SalesSlipYearContrastResultWork temp = (SalesSlipYearContrastResultWork)graph;

                SetSalesSlipYearContrastResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalesSlipYearContrastResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalesSlipYearContrastResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalesSlipYearContrastResultWork temp in lst)
                {
                    SetSalesSlipYearContrastResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalesSlipYearContrastResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 18;

        /// <summary>
        ///  SalesSlipYearContrastResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesSlipYearContrastResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSalesSlipYearContrastResultWork(System.IO.BinaryWriter writer, SalesSlipYearContrastResultWork temp)
        {
            //�v�㋒�_�R�[�h
            writer.Write(temp.AddUpSecCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideSnm);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //������z(���v)(����)
            writer.Write(temp.SalesMoney);
            //������z(�݌�)(����)
            writer.Write(temp.SalesMoneyStock);
            //�e�����z(����)
            writer.Write(temp.GrossProfit);
            //�ړ��o�׊z(����)
            writer.Write(temp.MoveShipmentPrice);
            //�d�����z���v(���v)(����)
            writer.Write(temp.StockTotalPrice);
            //�d�����z���v(�݌�)(����)
            writer.Write(temp.StockTotalPriceStock);
            //�ړ����׊z(����)
            writer.Write(temp.MoveArrivalPrice);
            //������z(���v)(����)
            writer.Write(temp.AnnualSalesMoney);
            //������z(�݌�)(����)
            writer.Write(temp.AnnualSalesMoneyStock);
            //�e�����z(����)
            writer.Write(temp.AnnualGrossProfit);
            //�ړ��o�׊z(����)
            writer.Write(temp.AnnualMoveShipmentPrice);
            //�d�����z���v(���v)(����)
            writer.Write(temp.AnnualStockTotalPrice);
            //�d�����z���v(�݌�)(����)
            writer.Write(temp.AnnualStockTotalPriceStock);
            //�ړ����׊z(����)
            writer.Write(temp.AnnualMoveArrivalPrice);

        }

        /// <summary>
        ///  SalesSlipYearContrastResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SalesSlipYearContrastResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesSlipYearContrastResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SalesSlipYearContrastResultWork GetSalesSlipYearContrastResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SalesSlipYearContrastResultWork temp = new SalesSlipYearContrastResultWork();

            //�v�㋒�_�R�[�h
            temp.AddUpSecCode = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideSnm = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //������z(���v)(����)
            temp.SalesMoney = reader.ReadInt64();
            //������z(�݌�)(����)
            temp.SalesMoneyStock = reader.ReadInt64();
            //�e�����z(����)
            temp.GrossProfit = reader.ReadInt64();
            //�ړ��o�׊z(����)
            temp.MoveShipmentPrice = reader.ReadInt64();
            //�d�����z���v(���v)(����)
            temp.StockTotalPrice = reader.ReadInt64();
            //�d�����z���v(�݌�)(����)
            temp.StockTotalPriceStock = reader.ReadInt64();
            //�ړ����׊z(����)
            temp.MoveArrivalPrice = reader.ReadInt64();
            //������z(���v)(����)
            temp.AnnualSalesMoney = reader.ReadInt64();
            //������z(�݌�)(����)
            temp.AnnualSalesMoneyStock = reader.ReadInt64();
            //�e�����z(����)
            temp.AnnualGrossProfit = reader.ReadInt64();
            //�ړ��o�׊z(����)
            temp.AnnualMoveShipmentPrice = reader.ReadInt64();
            //�d�����z���v(���v)(����)
            temp.AnnualStockTotalPrice = reader.ReadInt64();
            //�d�����z���v(�݌�)(����)
            temp.AnnualStockTotalPriceStock = reader.ReadInt64();
            //�ړ����׊z(����)
            temp.AnnualMoveArrivalPrice = reader.ReadInt64();


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
        /// <returns>SalesSlipYearContrastResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesSlipYearContrastResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalesSlipYearContrastResultWork temp = GetSalesSlipYearContrastResultWork(reader, serInfo);
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
                    retValue = (SalesSlipYearContrastResultWork[])lst.ToArray(typeof(SalesSlipYearContrastResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
