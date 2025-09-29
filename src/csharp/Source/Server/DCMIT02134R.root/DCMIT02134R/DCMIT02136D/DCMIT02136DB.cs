using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockMonthYearReportResultWork
    /// <summary>
    ///                      �d������N�񒊏o���ʃ��[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d������N�񒊏o���ʃ��[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/11/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockMonthYearReportResultWork
    {
        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���_�K�C�h����</summary>
        private string _sectionGuideNm = "";

        /// <summary>�]�ƈ��R�[�h</summary>
        private string _employeeCode = "";

        /// <summary>�]�ƈ�����</summary>
        private string _employeeName = "";

        /// <summary>����R�[�h</summary>
        private Int32 _subSectionCode;

        /// <summary>���喼��</summary>
        private string _subSectionName = "";

        /// <summary>�ۃR�[�h</summary>
        private Int32 _minSectionCode;

        /// <summary>�ۖ���</summary>
        private string _minSectionName = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

        /// <summary>���Ԏd�����v</summary>
        private Double _monthTotalStockCount;

        /// <summary>���Ԏd�����z���v</summary>
        private Int64 _monthStockTotalPrice;

        /// <summary>���Ԏd���ԕi�z</summary>
        private Int64 _monthStockRetGoodsPrice;

        /// <summary>���Ԏd���l���v</summary>
        private Int64 _monthStockTotalDiscount;

        /// <summary>�N�Ԏd�����v</summary>
        private Double _annualTotalStockCount;

        /// <summary>�N�Ԏd�����z���v</summary>
        private Int64 _annualStockTotalPrice;

        /// <summary>�N�Ԏd���ԕi�z</summary>
        private Int64 _annualStockRetGoodsPrice;

        /// <summary>�N�Ԏd���l���v</summary>
        private Int64 _annualStockTotalDiscount;


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

        /// public propaty name  :  MonthTotalStockCount
        /// <summary>���Ԏd�����v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ԏd�����v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MonthTotalStockCount
        {
            get { return _monthTotalStockCount; }
            set { _monthTotalStockCount = value; }
        }

        /// public propaty name  :  MonthStockTotalPrice
        /// <summary>���Ԏd�����z���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ԏd�����z���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthStockTotalPrice
        {
            get { return _monthStockTotalPrice; }
            set { _monthStockTotalPrice = value; }
        }

        /// public propaty name  :  MonthStockRetGoodsPrice
        /// <summary>���Ԏd���ԕi�z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ԏd���ԕi�z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthStockRetGoodsPrice
        {
            get { return _monthStockRetGoodsPrice; }
            set { _monthStockRetGoodsPrice = value; }
        }

        /// public propaty name  :  MonthStockTotalDiscount
        /// <summary>���Ԏd���l���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ԏd���l���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthStockTotalDiscount
        {
            get { return _monthStockTotalDiscount; }
            set { _monthStockTotalDiscount = value; }
        }

        /// public propaty name  :  AnnualTotalStockCount
        /// <summary>�N�Ԏd�����v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �N�Ԏd�����v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AnnualTotalStockCount
        {
            get { return _annualTotalStockCount; }
            set { _annualTotalStockCount = value; }
        }

        /// public propaty name  :  AnnualStockTotalPrice
        /// <summary>�N�Ԏd�����z���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �N�Ԏd�����z���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AnnualStockTotalPrice
        {
            get { return _annualStockTotalPrice; }
            set { _annualStockTotalPrice = value; }
        }

        /// public propaty name  :  AnnualStockRetGoodsPrice
        /// <summary>�N�Ԏd���ԕi�z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �N�Ԏd���ԕi�z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AnnualStockRetGoodsPrice
        {
            get { return _annualStockRetGoodsPrice; }
            set { _annualStockRetGoodsPrice = value; }
        }

        /// public propaty name  :  AnnualStockTotalDiscount
        /// <summary>�N�Ԏd���l���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �N�Ԏd���l���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AnnualStockTotalDiscount
        {
            get { return _annualStockTotalDiscount; }
            set { _annualStockTotalDiscount = value; }
        }


        /// <summary>
        /// �d������N�񒊏o���ʃ��[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockMonthYearReportResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMonthYearReportResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockMonthYearReportResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>StockMonthYearReportResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   StockMonthYearReportResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class StockMonthYearReportResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMonthYearReportResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockMonthYearReportResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockMonthYearReportResultWork || graph is ArrayList || graph is StockMonthYearReportResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(StockMonthYearReportResultWork).FullName));

            if (graph != null && graph is StockMonthYearReportResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockMonthYearReportResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockMonthYearReportResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockMonthYearReportResultWork[])graph).Length;
            }
            else if (graph is StockMonthYearReportResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            //�]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeName
            //����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //���喼��
            serInfo.MemberInfo.Add(typeof(string)); //SubSectionName
            //�ۃR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //MinSectionCode
            //�ۖ���
            serInfo.MemberInfo.Add(typeof(string)); //MinSectionName
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //���Ԏd�����v
            serInfo.MemberInfo.Add(typeof(Double)); //MonthTotalStockCount
            //���Ԏd�����z���v
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthStockTotalPrice
            //���Ԏd���ԕi�z
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthStockRetGoodsPrice
            //���Ԏd���l���v
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthStockTotalDiscount
            //�N�Ԏd�����v
            serInfo.MemberInfo.Add(typeof(Double)); //AnnualTotalStockCount
            //�N�Ԏd�����z���v
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualStockTotalPrice
            //�N�Ԏd���ԕi�z
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualStockRetGoodsPrice
            //�N�Ԏd���l���v
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualStockTotalDiscount


            serInfo.Serialize(writer, serInfo);
            if (graph is StockMonthYearReportResultWork)
            {
                StockMonthYearReportResultWork temp = (StockMonthYearReportResultWork)graph;

                SetStockMonthYearReportResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockMonthYearReportResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockMonthYearReportResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockMonthYearReportResultWork temp in lst)
                {
                    SetStockMonthYearReportResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockMonthYearReportResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 20;

        /// <summary>
        ///  StockMonthYearReportResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMonthYearReportResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetStockMonthYearReportResultWork(System.IO.BinaryWriter writer, StockMonthYearReportResultWork temp)
        {
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideNm);
            //�]�ƈ��R�[�h
            writer.Write(temp.EmployeeCode);
            //�]�ƈ�����
            writer.Write(temp.EmployeeName);
            //����R�[�h
            writer.Write(temp.SubSectionCode);
            //���喼��
            writer.Write(temp.SubSectionName);
            //�ۃR�[�h
            writer.Write(temp.MinSectionCode);
            //�ۖ���
            writer.Write(temp.MinSectionName);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���[�J�[����
            writer.Write(temp.MakerName);
            //���Ԏd�����v
            writer.Write(temp.MonthTotalStockCount);
            //���Ԏd�����z���v
            writer.Write(temp.MonthStockTotalPrice);
            //���Ԏd���ԕi�z
            writer.Write(temp.MonthStockRetGoodsPrice);
            //���Ԏd���l���v
            writer.Write(temp.MonthStockTotalDiscount);
            //�N�Ԏd�����v
            writer.Write(temp.AnnualTotalStockCount);
            //�N�Ԏd�����z���v
            writer.Write(temp.AnnualStockTotalPrice);
            //�N�Ԏd���ԕi�z
            writer.Write(temp.AnnualStockRetGoodsPrice);
            //�N�Ԏd���l���v
            writer.Write(temp.AnnualStockTotalDiscount);

        }

        /// <summary>
        ///  StockMonthYearReportResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>StockMonthYearReportResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMonthYearReportResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private StockMonthYearReportResultWork GetStockMonthYearReportResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            StockMonthYearReportResultWork temp = new StockMonthYearReportResultWork();

            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideNm = reader.ReadString();
            //�]�ƈ��R�[�h
            temp.EmployeeCode = reader.ReadString();
            //�]�ƈ�����
            temp.EmployeeName = reader.ReadString();
            //����R�[�h
            temp.SubSectionCode = reader.ReadInt32();
            //���喼��
            temp.SubSectionName = reader.ReadString();
            //�ۃR�[�h
            temp.MinSectionCode = reader.ReadInt32();
            //�ۖ���
            temp.MinSectionName = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���[�J�[����
            temp.MakerName = reader.ReadString();
            //���Ԏd�����v
            temp.MonthTotalStockCount = reader.ReadDouble();
            //���Ԏd�����z���v
            temp.MonthStockTotalPrice = reader.ReadInt64();
            //���Ԏd���ԕi�z
            temp.MonthStockRetGoodsPrice = reader.ReadInt64();
            //���Ԏd���l���v
            temp.MonthStockTotalDiscount = reader.ReadInt64();
            //�N�Ԏd�����v
            temp.AnnualTotalStockCount = reader.ReadDouble();
            //�N�Ԏd�����z���v
            temp.AnnualStockTotalPrice = reader.ReadInt64();
            //�N�Ԏd���ԕi�z
            temp.AnnualStockRetGoodsPrice = reader.ReadInt64();
            //�N�Ԏd���l���v
            temp.AnnualStockTotalDiscount = reader.ReadInt64();


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
        /// <returns>StockMonthYearReportResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMonthYearReportResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockMonthYearReportResultWork temp = GetStockMonthYearReportResultWork(reader, serInfo);
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
                    retValue = (StockMonthYearReportResultWork[])lst.ToArray(typeof(StockMonthYearReportResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
