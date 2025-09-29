using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SuplierPayUpdateWork
    /// <summary>
    ///                      �d����x�����z�X�V�p�����[�^�N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d����x�����z�X�V�p�����[�^�N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/04/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SuplierPayUpdateWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _addUpSecCode = "";

        /// <summary>�d�������</summary>
        /// <remarks>DD</remarks>
        private Int32 _supplierTotalDay;

        /// <summary>�d����R�[�h1</summary>
        private Int32 _supplierCd1;

        /// <summary>�d����1����</summary>
        private Int32 _supplier1TotalDay;

        /// <summary>�d����R�[�h2</summary>
        private Int32 _supplierCd2;

        /// <summary>�d����2����</summary>
        private Int32 _supplier2TotalDay;

        /// <summary>�d����R�[�h3</summary>
        private Int32 _supplierCd3;

        /// <summary>�d����3����</summary>
        private Int32 _supplier3TotalDay;

        /// <summary>�d����R�[�h4</summary>
        private Int32 _supplierCd4;

        /// <summary>�d����4����</summary>
        private Int32 _supplier4TotalDay;

        /// <summary>�d����R�[�h5</summary>
        private Int32 _supplierCd5;

        /// <summary>�d����5����</summary>
        private Int32 _supplier5TotalDay;

        /// <summary>�d����R�[�h6</summary>
        private Int32 _supplierCd6;

        /// <summary>�d����6����</summary>
        private Int32 _supplier6TotalDay;

        /// <summary>�d����R�[�h7</summary>
        private Int32 _supplierCd7;

        /// <summary>�d����7����</summary>
        private Int32 _supplier7TotalDay;

        /// <summary>�d����R�[�h8</summary>
        private Int32 _supplierCd8;

        /// <summary>�d����8����</summary>
        private Int32 _supplier8TotalDay;

        /// <summary>�d����R�[�h9</summary>
        private Int32 _supplierCd9;

        /// <summary>�d����9����</summary>
        private Int32 _supplier9TotalDay;

        /// <summary>�d����R�[�h10</summary>
        private Int32 _supplierCd10;

        /// <summary>�d����10����</summary>
        private Int32 _supplier10TotalDay;

        /// <summary>�v��N����</summary>
        /// <remarks>YYYYMMDD�@�x�������s������</remarks>
        private DateTime _addUpDate;

        /// <summary>�v��N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>�X�V�Ώۃt���O</summary>
        /// <remarks>1:�S���Ӑ�Ώ�,2:�ʓ��Ӑ�w��,3:�ʓ��Ӑ揜�O</remarks>
        private Int32 _updObjectFlag;

        /// <summary>�������e�t���O</summary>
        /// <remarks>1:�����X�V����,2:�x������</remarks>
        private Int32 _procCntntsFlag;


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

        /// public propaty name  :  CustomerTotalDay
        /// <summary>�d��������v���p�e�B</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d��������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierTotalDay
        {
            get { return _supplierTotalDay; }
            set { _supplierTotalDay = value; }
        }

        /// public propaty name  :  SupplierCd1
        /// <summary>�d����R�[�h1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd1
        {
            get { return _supplierCd1; }
            set { _supplierCd1 = value; }
        }

        /// public propaty name  :  Supplier1TotalDay
        /// <summary>�d����1�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����1�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Supplier1TotalDay
        {
            get { return _supplier1TotalDay; }
            set { _supplier1TotalDay = value; }
        }

        /// public propaty name  :  SupplierCd2
        /// <summary>�d����R�[�h2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd2
        {
            get { return _supplierCd2; }
            set { _supplierCd2 = value; }
        }

        /// public propaty name  :  Supplier2TotalDay
        /// <summary>�d����2�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����2�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Supplier2TotalDay
        {
            get { return _supplier2TotalDay; }
            set { _supplier2TotalDay = value; }
        }

        /// public propaty name  :  SupplierCd3
        /// <summary>�d����R�[�h3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd3
        {
            get { return _supplierCd3; }
            set { _supplierCd3 = value; }
        }

        /// public propaty name  :  Supplier3TotalDay
        /// <summary>�d����3�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����3�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Supplier3TotalDay
        {
            get { return _supplier3TotalDay; }
            set { _supplier3TotalDay = value; }
        }

        /// public propaty name  :  SupplierCd4
        /// <summary>�d����R�[�h4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd4
        {
            get { return _supplierCd4; }
            set { _supplierCd4 = value; }
        }

        /// public propaty name  :  Supplier4TotalDay
        /// <summary>�d����4�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����4�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Supplier4TotalDay
        {
            get { return _supplier4TotalDay; }
            set { _supplier4TotalDay = value; }
        }

        /// public propaty name  :  SupplierCd5
        /// <summary>�d����R�[�h5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd5
        {
            get { return _supplierCd5; }
            set { _supplierCd5 = value; }
        }

        /// public propaty name  :  Supplier5TotalDay
        /// <summary>�d����5�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����5�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Supplier5TotalDay
        {
            get { return _supplier5TotalDay; }
            set { _supplier5TotalDay = value; }
        }

        /// public propaty name  :  SupplierCd6
        /// <summary>�d���R�[�h6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd6
        {
            get { return _supplierCd6; }
            set { _supplierCd6 = value; }
        }

        /// public propaty name  :  Supplier6TotalDay
        /// <summary>�d����6�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����6�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Supplier6TotalDay
        {
            get { return _supplier6TotalDay; }
            set { _supplier6TotalDay = value; }
        }

        /// public propaty name  :  SupplierCd7
        /// <summary>�d����R�[�h7�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd7
        {
            get { return _supplierCd7; }
            set { _supplierCd7 = value; }
        }

        /// public propaty name  :  Supplier7TotalDay
        /// <summary>�d����7�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����7�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Supplier7TotalDay
        {
            get { return _supplier7TotalDay; }
            set { _supplier7TotalDay = value; }
        }

        /// public propaty name  :  SupplierCd8
        /// <summary>�d����R�[�h8�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd8
        {
            get { return _supplierCd8; }
            set { _supplierCd8 = value; }
        }

        /// public propaty name  :  Supplier8TotalDay
        /// <summary>�d����8�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����8�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Supplier8TotalDay
        {
            get { return _supplier8TotalDay; }
            set { _supplier8TotalDay = value; }
        }

        /// public propaty name  :  SupplierCd9
        /// <summary>�d����R�[�h9�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd9
        {
            get { return _supplierCd9; }
            set { _supplierCd9 = value; }
        }

        /// public propaty name  :  Supplier9TotalDay
        /// <summary>�d����9�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����9�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Supplier9TotalDay
        {
            get { return _supplier9TotalDay; }
            set { _supplier9TotalDay = value; }
        }

        /// public propaty name  :  SupplierCd10
        /// <summary>�d����R�[�h10�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd10
        {
            get { return _supplierCd10; }
            set { _supplierCd10 = value; }
        }

        /// public propaty name  :  Supplier10TotalDay
        /// <summary>�d����10�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����10�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Supplier10TotalDay
        {
            get { return _supplier10TotalDay; }
            set { _supplier10TotalDay = value; }
        }

        /// public propaty name  :  AddUpDate
        /// <summary>�v��N�����v���p�e�B</summary>
        /// <value>YYYYMMDD�@�x�������s������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpDate
        {
            get { return _addUpDate; }
            set { _addUpDate = value; }
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

        /// public propaty name  :  UpdObjectFlag
        /// <summary>�X�V�Ώۃt���O�v���p�e�B</summary>
        /// <value>1:�S���Ӑ�Ώ�,2:�ʓ��Ӑ�w��,3:�ʓ��Ӑ揜�O</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�Ώۃt���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UpdObjectFlag
        {
            get { return _updObjectFlag; }
            set { _updObjectFlag = value; }
        }

        /// public propaty name  :  ProcCntntsFlag
        /// <summary>�������e�t���O�v���p�e�B</summary>
        /// <value>1:�����X�V����,2:�x������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������e�t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ProcCntntsFlag
        {
            get { return _procCntntsFlag; }
            set { _procCntntsFlag = value; }
        }


        /// <summary>
        /// �d����x�����z�X�V�p�����[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SuplierPayUpdateWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuplierPayUpdateWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SuplierPayUpdateWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SuplierPayUpdateWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SuplierPayUpdateWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SuplierPayUpdateWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuplierPayUpdateWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SuplierPayUpdateWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SuplierPayUpdateWork || graph is ArrayList || graph is SuplierPayUpdateWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SuplierPayUpdateWork).FullName));

            if (graph != null && graph is SuplierPayUpdateWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SuplierPayUpdateWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SuplierPayUpdateWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SuplierPayUpdateWork[])graph).Length;
            }
            else if (graph is SuplierPayUpdateWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //�d�������
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierTotalDay
            //�d����R�[�h1
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd1
            //�d����1����
            serInfo.MemberInfo.Add(typeof(Int32)); //Supplier1TotalDay
            //�d����R�[�h2
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd2
            //�d����2����
            serInfo.MemberInfo.Add(typeof(Int32)); //Supplier2TotalDay
            //�d����R�[�h3
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd3
            //�d����3����
            serInfo.MemberInfo.Add(typeof(Int32)); //Supplier3TotalDay
            //�d����R�[�h4
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd4
            //�d����4����
            serInfo.MemberInfo.Add(typeof(Int32)); //Supplier4TotalDay
            //�d����R�[�h5
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd5
            //�d����5����
            serInfo.MemberInfo.Add(typeof(Int32)); //Supplier5TotalDay
            //�d����R�[�h6
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd6
            //�d����6����
            serInfo.MemberInfo.Add(typeof(Int32)); //Supplier6TotalDay
            //�d����R�[�h7
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd7
            //�d����7����
            serInfo.MemberInfo.Add(typeof(Int32)); //Supplier7TotalDay
            //�d����R�[�h8
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd8
            //�d����8����
            serInfo.MemberInfo.Add(typeof(Int32)); //Supplier8TotalDay
            //�d����R�[�h9
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd9
            //�d����9����
            serInfo.MemberInfo.Add(typeof(Int32)); //Supplier9TotalDay
            //�d����R�[�h10
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd10
            //�d����10����
            serInfo.MemberInfo.Add(typeof(Int32)); //Supplier10TotalDay
            //�v��N����
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpDate
            //�v��N��
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpYearMonth
            //�X�V�Ώۃt���O
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdObjectFlag
            //�������e�t���O
            serInfo.MemberInfo.Add(typeof(Int32)); //ProcCntntsFlag


            serInfo.Serialize(writer, serInfo);
            if (graph is SuplierPayUpdateWork)
            {
                SuplierPayUpdateWork temp = (SuplierPayUpdateWork)graph;

                SetSuplierPayUpdateWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SuplierPayUpdateWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SuplierPayUpdateWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SuplierPayUpdateWork temp in lst)
                {
                    SetSuplierPayUpdateWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SuplierPayUpdateWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 27;

        /// <summary>
        ///  SuplierPayUpdateWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuplierPayUpdateWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSuplierPayUpdateWork(System.IO.BinaryWriter writer, SuplierPayUpdateWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //�v�㋒�_�R�[�h
            writer.Write(temp.AddUpSecCode);
            //�d�������
            writer.Write(temp.SupplierTotalDay);
            //�d����R�[�h1
            writer.Write(temp.SupplierCd1);
            //�d����1����
            writer.Write(temp.Supplier1TotalDay);
            //�d����R�[�h2
            writer.Write(temp.SupplierCd2);
            //�d����2����
            writer.Write(temp.Supplier2TotalDay);
            //�d����R�[�h3
            writer.Write(temp.SupplierCd3);
            //�d����3����
            writer.Write(temp.Supplier3TotalDay);
            //�d����R�[�h4
            writer.Write(temp.SupplierCd4);
            //�d����4����
            writer.Write(temp.Supplier4TotalDay);
            //�d����R�[�h5
            writer.Write(temp.SupplierCd5);
            //�d����5����
            writer.Write(temp.Supplier5TotalDay);
            //�d����R�[�h6
            writer.Write(temp.SupplierCd6);
            //�d����6����
            writer.Write(temp.Supplier6TotalDay);
            //�d����R�[�h7
            writer.Write(temp.SupplierCd7);
            //�d����7����
            writer.Write(temp.Supplier7TotalDay);
            //�d����R�[�h8
            writer.Write(temp.SupplierCd8);
            //�d����8����
            writer.Write(temp.Supplier8TotalDay);
            //�d����R�[�h9
            writer.Write(temp.SupplierCd9);
            //�d����9����
            writer.Write(temp.Supplier9TotalDay);
            //�d����R�[�h10
            writer.Write(temp.SupplierCd10);
            //�d����10����
            writer.Write(temp.Supplier10TotalDay);
            //�v��N����
            writer.Write((Int64)temp.AddUpDate.Ticks);
            //�v��N��
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //�X�V�Ώۃt���O
            writer.Write(temp.UpdObjectFlag);
            //�������e�t���O
            writer.Write(temp.ProcCntntsFlag);

        }

        /// <summary>
        ///  SuplierPayUpdateWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SuplierPayUpdateWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuplierPayUpdateWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SuplierPayUpdateWork GetSuplierPayUpdateWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SuplierPayUpdateWork temp = new SuplierPayUpdateWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //�v�㋒�_�R�[�h
            temp.AddUpSecCode = reader.ReadString();
            //�d�������
            temp.SupplierTotalDay = reader.ReadInt32();
            //�d����R�[�h1
            temp.SupplierCd1 = reader.ReadInt32();
            //�d����1����
            temp.Supplier1TotalDay = reader.ReadInt32();
            //�d����R�[�h2
            temp.SupplierCd2 = reader.ReadInt32();
            //�d����2����
            temp.Supplier2TotalDay = reader.ReadInt32();
            //�d����R�[�h3
            temp.SupplierCd3 = reader.ReadInt32();
            //�d����3����
            temp.Supplier3TotalDay = reader.ReadInt32();
            //�d����R�[�h4
            temp.SupplierCd4 = reader.ReadInt32();
            //�d����4����
            temp.Supplier4TotalDay = reader.ReadInt32();
            //�d����R�[�h5
            temp.SupplierCd5 = reader.ReadInt32();
            //�d����5����
            temp.Supplier5TotalDay = reader.ReadInt32();
            //�d����R�[�h6
            temp.SupplierCd6 = reader.ReadInt32();
            //�d����6����
            temp.Supplier6TotalDay = reader.ReadInt32();
            //�d����R�[�h7
            temp.SupplierCd7 = reader.ReadInt32();
            //�d����7����
            temp.Supplier7TotalDay = reader.ReadInt32();
            //�d����R�[�h8
            temp.SupplierCd8 = reader.ReadInt32();
            //�d����8����
            temp.Supplier8TotalDay = reader.ReadInt32();
            //�d����R�[�h9
            temp.SupplierCd9 = reader.ReadInt32();
            //�d����9����
            temp.Supplier9TotalDay = reader.ReadInt32();
            //�d����R�[�h10
            temp.SupplierCd10 = reader.ReadInt32();
            //�d����10����
            temp.Supplier10TotalDay = reader.ReadInt32();
            //�v��N����
            temp.AddUpDate = new DateTime(reader.ReadInt64());
            //�v��N��
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //�X�V�Ώۃt���O
            temp.UpdObjectFlag = reader.ReadInt32();
            //�������e�t���O
            temp.ProcCntntsFlag = reader.ReadInt32();


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
        /// <returns>SuplierPayUpdateWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuplierPayUpdateWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SuplierPayUpdateWork temp = GetSuplierPayUpdateWork(reader, serInfo);
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
                    retValue = (SuplierPayUpdateWork[])lst.ToArray(typeof(SuplierPayUpdateWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
