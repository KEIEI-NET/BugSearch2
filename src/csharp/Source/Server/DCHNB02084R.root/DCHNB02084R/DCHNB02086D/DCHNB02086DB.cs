using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesMonthYearReportResultWork
    /// <summary>
    ///                      ���㌎��N�񒊏o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���㌎��N�񒊏o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/09/08  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesMonthYearReportResultWork
    {
        /// <summary>�R�[�h</summary>
        /// <remarks>XXX�R�[�h(�S����/�󒍎�/���s��/�n��/�Ǝ�/�̔��敪)</remarks>
        private string _code = "";

        /// <summary>����</summary>
        /// <remarks>XXX����(�S����/�󒍎�/���s��/�n��/�Ǝ�/�̔��敪)</remarks>
        private string _name = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���_����</summary>
        /// <remarks>���_�K�C�h����</remarks>
        private string _companyName1 = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ於��</summary>
        /// <remarks>���Ӑ旪��</remarks>
        private string _customerSnm = "";

        /// <summary>����������z</summary>
        private Int64 _monthSalesMoney;

        /// <summary>�����ԕi�z</summary>
        private Int64 _monthSalesRetGoodsPrice;

        /// <summary>�����l�����z</summary>
        private Int64 _monthDiscountPrice;

        /// <summary>��������ڕW���z</summary>
        private Int64 _monthSalesTargetMoney;

        /// <summary>�����e�����z</summary>
        private Int64 _monthGrossProfit;

        /// <summary>��������ڕW�e���z</summary>
        private Int64 _monthSalesTargetProfit;

        /// <summary>����������z</summary>
        private Int64 _annualSalesMoney;

        /// <summary>�����ԕi�z</summary>
        private Int64 _annualSalesRetGoodsPrice;

        /// <summary>�����l�����z</summary>
        private Int64 _annualDiscountPrice;

        /// <summary>��������ڕW���z</summary>
        private Int64 _annualSalesTargetMoney;

        /// <summary>�����e�����z</summary>
        private Int64 _annualGrossProfit;

        /// <summary>��������ڕW�e���z</summary>
        private Int64 _annualSalesTargetProfit;


        /// public propaty name  :  Code
        /// <summary>�R�[�h�v���p�e�B</summary>
        /// <value>XXX�R�[�h(�S����/�󒍎�/���s��/�n��/�Ǝ�/�̔��敪)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        /// public propaty name  :  Name
        /// <summary>���̃v���p�e�B</summary>
        /// <value>XXX����(�S����/�󒍎�/���s��/�n��/�Ǝ�/�̔��敪)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
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
        /// <summary>���Ӑ於�̃v���p�e�B</summary>
        /// <value>���Ӑ旪��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  MonthSalesMoney
        /// <summary>����������z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����������z�v���p�e�B</br>
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
        /// <summary>�����l�����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����l�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthDiscountPrice
        {
            get { return _monthDiscountPrice; }
            set { _monthDiscountPrice = value; }
        }

        /// public propaty name  :  MonthSalesTargetMoney
        /// <summary>��������ڕW���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������ڕW���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthSalesTargetMoney
        {
            get { return _monthSalesTargetMoney; }
            set { _monthSalesTargetMoney = value; }
        }

        /// public propaty name  :  MonthGrossProfit
        /// <summary>�����e�����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����e�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthGrossProfit
        {
            get { return _monthGrossProfit; }
            set { _monthGrossProfit = value; }
        }

        /// public propaty name  :  MonthSalesTargetProfit
        /// <summary>��������ڕW�e���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������ڕW�e���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthSalesTargetProfit
        {
            get { return _monthSalesTargetProfit; }
            set { _monthSalesTargetProfit = value; }
        }

        /// public propaty name  :  AnnualSalesMoney
        /// <summary>����������z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����������z�v���p�e�B</br>
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
        /// <summary>�����l�����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����l�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AnnualDiscountPrice
        {
            get { return _annualDiscountPrice; }
            set { _annualDiscountPrice = value; }
        }

        /// public propaty name  :  AnnualSalesTargetMoney
        /// <summary>��������ڕW���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������ڕW���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AnnualSalesTargetMoney
        {
            get { return _annualSalesTargetMoney; }
            set { _annualSalesTargetMoney = value; }
        }

        /// public propaty name  :  AnnualGrossProfit
        /// <summary>�����e�����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����e�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AnnualGrossProfit
        {
            get { return _annualGrossProfit; }
            set { _annualGrossProfit = value; }
        }

        /// public propaty name  :  AnnualSalesTargetProfit
        /// <summary>��������ڕW�e���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������ڕW�e���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AnnualSalesTargetProfit
        {
            get { return _annualSalesTargetProfit; }
            set { _annualSalesTargetProfit = value; }
        }


        /// <summary>
        /// ���㌎��N�񒊏o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SalesMonthYearReportResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesMonthYearReportResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesMonthYearReportResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SalesMonthYearReportResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SalesMonthYearReportResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SalesMonthYearReportResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesMonthYearReportResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalesMonthYearReportResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalesMonthYearReportResultWork || graph is ArrayList || graph is SalesMonthYearReportResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SalesMonthYearReportResultWork).FullName));

            if (graph != null && graph is SalesMonthYearReportResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalesMonthYearReportResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalesMonthYearReportResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalesMonthYearReportResultWork[])graph).Length;
            }
            else if (graph is SalesMonthYearReportResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //Code
            //����
            serInfo.MemberInfo.Add(typeof(string)); //Name
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���_����
            serInfo.MemberInfo.Add(typeof(string)); //CompanyName1
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ於��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //����������z
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesMoney
            //�����ԕi�z
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesRetGoodsPrice
            //�����l�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthDiscountPrice
            //��������ڕW���z
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesTargetMoney
            //�����e�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthGrossProfit
            //��������ڕW�e���z
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesTargetProfit
            //����������z
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualSalesMoney
            //�����ԕi�z
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualSalesRetGoodsPrice
            //�����l�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualDiscountPrice
            //��������ڕW���z
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualSalesTargetMoney
            //�����e�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualGrossProfit
            //��������ڕW�e���z
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualSalesTargetProfit


            serInfo.Serialize(writer, serInfo);
            if (graph is SalesMonthYearReportResultWork)
            {
                SalesMonthYearReportResultWork temp = (SalesMonthYearReportResultWork)graph;

                SetSalesMonthYearReportResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalesMonthYearReportResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalesMonthYearReportResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalesMonthYearReportResultWork temp in lst)
                {
                    SetSalesMonthYearReportResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalesMonthYearReportResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 18;

        /// <summary>
        ///  SalesMonthYearReportResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesMonthYearReportResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSalesMonthYearReportResultWork(System.IO.BinaryWriter writer, SalesMonthYearReportResultWork temp)
        {
            //�R�[�h
            writer.Write(temp.Code);
            //����
            writer.Write(temp.Name);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���_����
            writer.Write(temp.CompanyName1);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ於��
            writer.Write(temp.CustomerSnm);
            //����������z
            writer.Write(temp.MonthSalesMoney);
            //�����ԕi�z
            writer.Write(temp.MonthSalesRetGoodsPrice);
            //�����l�����z
            writer.Write(temp.MonthDiscountPrice);
            //��������ڕW���z
            writer.Write(temp.MonthSalesTargetMoney);
            //�����e�����z
            writer.Write(temp.MonthGrossProfit);
            //��������ڕW�e���z
            writer.Write(temp.MonthSalesTargetProfit);
            //����������z
            writer.Write(temp.AnnualSalesMoney);
            //�����ԕi�z
            writer.Write(temp.AnnualSalesRetGoodsPrice);
            //�����l�����z
            writer.Write(temp.AnnualDiscountPrice);
            //��������ڕW���z
            writer.Write(temp.AnnualSalesTargetMoney);
            //�����e�����z
            writer.Write(temp.AnnualGrossProfit);
            //��������ڕW�e���z
            writer.Write(temp.AnnualSalesTargetProfit);

        }

        /// <summary>
        ///  SalesMonthYearReportResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SalesMonthYearReportResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesMonthYearReportResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SalesMonthYearReportResultWork GetSalesMonthYearReportResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SalesMonthYearReportResultWork temp = new SalesMonthYearReportResultWork();

            //�R�[�h
            temp.Code = reader.ReadString();
            //����
            temp.Name = reader.ReadString();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���_����
            temp.CompanyName1 = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ於��
            temp.CustomerSnm = reader.ReadString();
            //����������z
            temp.MonthSalesMoney = reader.ReadInt64();
            //�����ԕi�z
            temp.MonthSalesRetGoodsPrice = reader.ReadInt64();
            //�����l�����z
            temp.MonthDiscountPrice = reader.ReadInt64();
            //��������ڕW���z
            temp.MonthSalesTargetMoney = reader.ReadInt64();
            //�����e�����z
            temp.MonthGrossProfit = reader.ReadInt64();
            //��������ڕW�e���z
            temp.MonthSalesTargetProfit = reader.ReadInt64();
            //����������z
            temp.AnnualSalesMoney = reader.ReadInt64();
            //�����ԕi�z
            temp.AnnualSalesRetGoodsPrice = reader.ReadInt64();
            //�����l�����z
            temp.AnnualDiscountPrice = reader.ReadInt64();
            //��������ڕW���z
            temp.AnnualSalesTargetMoney = reader.ReadInt64();
            //�����e�����z
            temp.AnnualGrossProfit = reader.ReadInt64();
            //��������ڕW�e���z
            temp.AnnualSalesTargetProfit = reader.ReadInt64();


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
        /// <returns>SalesMonthYearReportResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesMonthYearReportResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalesMonthYearReportResultWork temp = GetSalesMonthYearReportResultWork(reader, serInfo);
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
                    retValue = (SalesMonthYearReportResultWork[])lst.ToArray(typeof(SalesMonthYearReportResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
