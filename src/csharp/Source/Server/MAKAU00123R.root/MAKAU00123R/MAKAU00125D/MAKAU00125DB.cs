using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CustDmdPrcUpdateWork
    /// <summary>
    ///                      ���Ӑ搿�����z�X�V�p�����[�^�N���X���[�N���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���Ӑ搿�����z�X�V�p�����[�^�N���X���[�N���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/07/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustDmdPrcUpdateWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h,�S�ЁF""�܂���Null</remarks>
        private string _addUpSecCode = "";

        /// <summary>���Ӑ�R�[�h1</summary>
        private Int32 _customerCode1;

        /// <summary>���Ӑ�1����</summary>
        private Int32 _customer1TotalDay;

        /// <summary>���Ӑ�R�[�h2</summary>
        private Int32 _customerCode2;

        /// <summary>���Ӑ�2����</summary>
        private Int32 _customer2TotalDay;

        /// <summary>���Ӑ�R�[�h3</summary>
        private Int32 _customerCode3;

        /// <summary>���Ӑ�3����</summary>
        private Int32 _customer3TotalDay;

        /// <summary>���Ӑ�R�[�h4</summary>
        private Int32 _customerCode4;

        /// <summary>���Ӑ�4����</summary>
        private Int32 _customer4TotalDay;

        /// <summary>���Ӑ�R�[�h5</summary>
        private Int32 _customerCode5;

        /// <summary>���Ӑ�5����</summary>
        private Int32 _customer5TotalDay;

        /// <summary>���Ӑ�R�[�h6</summary>
        private Int32 _customerCode6;

        /// <summary>���Ӑ�6����</summary>
        private Int32 _customer6TotalDay;

        /// <summary>���Ӑ�R�[�h7</summary>
        private Int32 _customerCode7;

        /// <summary>���Ӑ�7����</summary>
        private Int32 _customer7TotalDay;

        /// <summary>���Ӑ�R�[�h8</summary>
        private Int32 _customerCode8;

        /// <summary>���Ӑ�8����</summary>
        private Int32 _customer8TotalDay;

        /// <summary>���Ӑ�R�[�h9</summary>
        private Int32 _customerCode9;

        /// <summary>���Ӑ�9����</summary>
        private Int32 _customer9TotalDay;

        /// <summary>���Ӑ�R�[�h10</summary>
        private Int32 _customerCode10;

        /// <summary>���Ӑ�10����</summary>
        private Int32 _customer10TotalDay;

        /// <summary>�v��N����</summary>
        /// <remarks>YYYYMMDD�@���������s������</remarks>
        private DateTime _addUpDate;

        /// <summary>�v��N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>�X�V�Ώۃt���O</summary>
        /// <remarks>1:�S���Ӑ�Ώ�,2:�ʓ��Ӑ�w��,3:�ʓ��Ӑ揜�O</remarks>
        private Int32 _updObjectFlag;

        /// <summary>�������e�t���O</summary>
        /// <remarks>1:�����X�V����,2:�����</remarks>
        private Int32 _procCntntsFlag;

        /// <summary>�Ώے���</summary>
        private Int32 _objTotalDay;

        /// <summary>�����X�V�敪</summary>
        /// <remarks>0:�����ȊO,1:����</remarks>
        private Int32 _termLastDiv;

        /// <summary>���Ӑ����</summary>
        /// <remarks>DD</remarks>
        private Int32 _customerTotalDay;


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
        /// <value>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h,�S�ЁF""�܂���Null</value>
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

        /// public propaty name  :  CustomerCode1
        /// <summary>���Ӑ�R�[�h1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode1
        {
            get { return _customerCode1; }
            set { _customerCode1 = value; }
        }

        /// public propaty name  :  Customer1TotalDay
        /// <summary>���Ӑ�1�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�1�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Customer1TotalDay
        {
            get { return _customer1TotalDay; }
            set { _customer1TotalDay = value; }
        }

        /// public propaty name  :  CustomerCode2
        /// <summary>���Ӑ�R�[�h2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode2
        {
            get { return _customerCode2; }
            set { _customerCode2 = value; }
        }

        /// public propaty name  :  Customer2TotalDay
        /// <summary>���Ӑ�2�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�2�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Customer2TotalDay
        {
            get { return _customer2TotalDay; }
            set { _customer2TotalDay = value; }
        }

        /// public propaty name  :  CustomerCode3
        /// <summary>���Ӑ�R�[�h3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode3
        {
            get { return _customerCode3; }
            set { _customerCode3 = value; }
        }

        /// public propaty name  :  Customer3TotalDay
        /// <summary>���Ӑ�3�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�3�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Customer3TotalDay
        {
            get { return _customer3TotalDay; }
            set { _customer3TotalDay = value; }
        }

        /// public propaty name  :  CustomerCode4
        /// <summary>���Ӑ�R�[�h4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode4
        {
            get { return _customerCode4; }
            set { _customerCode4 = value; }
        }

        /// public propaty name  :  Customer4TotalDay
        /// <summary>���Ӑ�4�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�4�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Customer4TotalDay
        {
            get { return _customer4TotalDay; }
            set { _customer4TotalDay = value; }
        }

        /// public propaty name  :  CustomerCode5
        /// <summary>���Ӑ�R�[�h5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode5
        {
            get { return _customerCode5; }
            set { _customerCode5 = value; }
        }

        /// public propaty name  :  Customer5TotalDay
        /// <summary>���Ӑ�5�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�5�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Customer5TotalDay
        {
            get { return _customer5TotalDay; }
            set { _customer5TotalDay = value; }
        }

        /// public propaty name  :  CustomerCode6
        /// <summary>���Ӑ�R�[�h6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode6
        {
            get { return _customerCode6; }
            set { _customerCode6 = value; }
        }

        /// public propaty name  :  Customer6TotalDay
        /// <summary>���Ӑ�6�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�6�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Customer6TotalDay
        {
            get { return _customer6TotalDay; }
            set { _customer6TotalDay = value; }
        }

        /// public propaty name  :  CustomerCode7
        /// <summary>���Ӑ�R�[�h7�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode7
        {
            get { return _customerCode7; }
            set { _customerCode7 = value; }
        }

        /// public propaty name  :  Customer7TotalDay
        /// <summary>���Ӑ�7�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�7�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Customer7TotalDay
        {
            get { return _customer7TotalDay; }
            set { _customer7TotalDay = value; }
        }

        /// public propaty name  :  CustomerCode8
        /// <summary>���Ӑ�R�[�h8�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode8
        {
            get { return _customerCode8; }
            set { _customerCode8 = value; }
        }

        /// public propaty name  :  Customer8TotalDay
        /// <summary>���Ӑ�8�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�8�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Customer8TotalDay
        {
            get { return _customer8TotalDay; }
            set { _customer8TotalDay = value; }
        }

        /// public propaty name  :  CustomerCode9
        /// <summary>���Ӑ�R�[�h9�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode9
        {
            get { return _customerCode9; }
            set { _customerCode9 = value; }
        }

        /// public propaty name  :  Customer9TotalDay
        /// <summary>���Ӑ�9�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�9�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Customer9TotalDay
        {
            get { return _customer9TotalDay; }
            set { _customer9TotalDay = value; }
        }

        /// public propaty name  :  CustomerCode10
        /// <summary>���Ӑ�R�[�h10�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode10
        {
            get { return _customerCode10; }
            set { _customerCode10 = value; }
        }

        /// public propaty name  :  Customer10TotalDay
        /// <summary>���Ӑ�10�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�10�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Customer10TotalDay
        {
            get { return _customer10TotalDay; }
            set { _customer10TotalDay = value; }
        }

        /// public propaty name  :  AddUpDate
        /// <summary>�v��N�����v���p�e�B</summary>
        /// <value>YYYYMMDD�@���������s������</value>
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
        /// <value>1:�����X�V����,2:�����</value>
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

        /// public propaty name  :  ObjTotalDay
        /// <summary>�Ώے����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ώے����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ObjTotalDay
        {
            get { return _objTotalDay; }
            set { _objTotalDay = value; }
        }

        /// public propaty name  :  TermLastDiv
        /// <summary>�����X�V�敪�v���p�e�B</summary>
        /// <value>0:�����ȊO,1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TermLastDiv
        {
            get { return _termLastDiv; }
            set { _termLastDiv = value; }
        }

        /// public propaty name  :  CustomerTotalDay
        /// <summary>���Ӑ�����v���p�e�B</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerTotalDay
        {
            get { return _customerTotalDay; }
            set { _customerTotalDay = value; }
        }


        /// <summary>
        /// ���Ӑ搿�����z�X�V�p�����[�^�N���X���[�N���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CustDmdPrcUpdateWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustDmdPrcUpdateWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustDmdPrcUpdateWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>CustDmdPrcUpdateWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   CustDmdPrcUpdateWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class CustDmdPrcUpdateWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustDmdPrcUpdateWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CustDmdPrcUpdateWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CustDmdPrcUpdateWork || graph is ArrayList || graph is CustDmdPrcUpdateWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(CustDmdPrcUpdateWork).FullName));

            if (graph != null && graph is CustDmdPrcUpdateWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustDmdPrcUpdateWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CustDmdPrcUpdateWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CustDmdPrcUpdateWork[])graph).Length;
            }
            else if (graph is CustDmdPrcUpdateWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //���Ӑ�R�[�h1
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode1
            //���Ӑ�1����
            serInfo.MemberInfo.Add(typeof(Int32)); //Customer1TotalDay
            //���Ӑ�R�[�h2
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode2
            //���Ӑ�2����
            serInfo.MemberInfo.Add(typeof(Int32)); //Customer2TotalDay
            //���Ӑ�R�[�h3
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode3
            //���Ӑ�3����
            serInfo.MemberInfo.Add(typeof(Int32)); //Customer3TotalDay
            //���Ӑ�R�[�h4
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode4
            //���Ӑ�4����
            serInfo.MemberInfo.Add(typeof(Int32)); //Customer4TotalDay
            //���Ӑ�R�[�h5
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode5
            //���Ӑ�5����
            serInfo.MemberInfo.Add(typeof(Int32)); //Customer5TotalDay
            //���Ӑ�R�[�h6
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode6
            //���Ӑ�6����
            serInfo.MemberInfo.Add(typeof(Int32)); //Customer6TotalDay
            //���Ӑ�R�[�h7
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode7
            //���Ӑ�7����
            serInfo.MemberInfo.Add(typeof(Int32)); //Customer7TotalDay
            //���Ӑ�R�[�h8
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode8
            //���Ӑ�8����
            serInfo.MemberInfo.Add(typeof(Int32)); //Customer8TotalDay
            //���Ӑ�R�[�h9
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode9
            //���Ӑ�9����
            serInfo.MemberInfo.Add(typeof(Int32)); //Customer9TotalDay
            //���Ӑ�R�[�h10
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode10
            //���Ӑ�10����
            serInfo.MemberInfo.Add(typeof(Int32)); //Customer10TotalDay
            //�v��N����
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpDate
            //�v��N��
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpYearMonth
            //�X�V�Ώۃt���O
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdObjectFlag
            //�������e�t���O
            serInfo.MemberInfo.Add(typeof(Int32)); //ProcCntntsFlag
            //�Ώے���
            serInfo.MemberInfo.Add(typeof(Int32)); //ObjTotalDay
            //�����X�V�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TermLastDiv
            //���Ӑ����
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerTotalDay


            serInfo.Serialize(writer, serInfo);
            if (graph is CustDmdPrcUpdateWork)
            {
                CustDmdPrcUpdateWork temp = (CustDmdPrcUpdateWork)graph;

                SetCustDmdPrcUpdateWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CustDmdPrcUpdateWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CustDmdPrcUpdateWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CustDmdPrcUpdateWork temp in lst)
                {
                    SetCustDmdPrcUpdateWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CustDmdPrcUpdateWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 29;

        /// <summary>
        ///  CustDmdPrcUpdateWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustDmdPrcUpdateWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetCustDmdPrcUpdateWork(System.IO.BinaryWriter writer, CustDmdPrcUpdateWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //�v�㋒�_�R�[�h
            writer.Write(temp.AddUpSecCode);
            //���Ӑ�R�[�h1
            writer.Write(temp.CustomerCode1);
            //���Ӑ�1����
            writer.Write(temp.Customer1TotalDay);
            //���Ӑ�R�[�h2
            writer.Write(temp.CustomerCode2);
            //���Ӑ�2����
            writer.Write(temp.Customer2TotalDay);
            //���Ӑ�R�[�h3
            writer.Write(temp.CustomerCode3);
            //���Ӑ�3����
            writer.Write(temp.Customer3TotalDay);
            //���Ӑ�R�[�h4
            writer.Write(temp.CustomerCode4);
            //���Ӑ�4����
            writer.Write(temp.Customer4TotalDay);
            //���Ӑ�R�[�h5
            writer.Write(temp.CustomerCode5);
            //���Ӑ�5����
            writer.Write(temp.Customer5TotalDay);
            //���Ӑ�R�[�h6
            writer.Write(temp.CustomerCode6);
            //���Ӑ�6����
            writer.Write(temp.Customer6TotalDay);
            //���Ӑ�R�[�h7
            writer.Write(temp.CustomerCode7);
            //���Ӑ�7����
            writer.Write(temp.Customer7TotalDay);
            //���Ӑ�R�[�h8
            writer.Write(temp.CustomerCode8);
            //���Ӑ�8����
            writer.Write(temp.Customer8TotalDay);
            //���Ӑ�R�[�h9
            writer.Write(temp.CustomerCode9);
            //���Ӑ�9����
            writer.Write(temp.Customer9TotalDay);
            //���Ӑ�R�[�h10
            writer.Write(temp.CustomerCode10);
            //���Ӑ�10����
            writer.Write(temp.Customer10TotalDay);
            //�v��N����
            writer.Write((Int64)temp.AddUpDate.Ticks);
            //�v��N��
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //�X�V�Ώۃt���O
            writer.Write(temp.UpdObjectFlag);
            //�������e�t���O
            writer.Write(temp.ProcCntntsFlag);
            //�Ώے���
            writer.Write(temp.ObjTotalDay);
            //�����X�V�敪
            writer.Write(temp.TermLastDiv);
            //���Ӑ����
            writer.Write(temp.CustomerTotalDay);

        }

        /// <summary>
        ///  CustDmdPrcUpdateWork�C���X�^���X�擾
        /// </summary>
        /// <returns>CustDmdPrcUpdateWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustDmdPrcUpdateWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private CustDmdPrcUpdateWork GetCustDmdPrcUpdateWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            CustDmdPrcUpdateWork temp = new CustDmdPrcUpdateWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //�v�㋒�_�R�[�h
            temp.AddUpSecCode = reader.ReadString();
            //���Ӑ�R�[�h1
            temp.CustomerCode1 = reader.ReadInt32();
            //���Ӑ�1����
            temp.Customer1TotalDay = reader.ReadInt32();
            //���Ӑ�R�[�h2
            temp.CustomerCode2 = reader.ReadInt32();
            //���Ӑ�2����
            temp.Customer2TotalDay = reader.ReadInt32();
            //���Ӑ�R�[�h3
            temp.CustomerCode3 = reader.ReadInt32();
            //���Ӑ�3����
            temp.Customer3TotalDay = reader.ReadInt32();
            //���Ӑ�R�[�h4
            temp.CustomerCode4 = reader.ReadInt32();
            //���Ӑ�4����
            temp.Customer4TotalDay = reader.ReadInt32();
            //���Ӑ�R�[�h5
            temp.CustomerCode5 = reader.ReadInt32();
            //���Ӑ�5����
            temp.Customer5TotalDay = reader.ReadInt32();
            //���Ӑ�R�[�h6
            temp.CustomerCode6 = reader.ReadInt32();
            //���Ӑ�6����
            temp.Customer6TotalDay = reader.ReadInt32();
            //���Ӑ�R�[�h7
            temp.CustomerCode7 = reader.ReadInt32();
            //���Ӑ�7����
            temp.Customer7TotalDay = reader.ReadInt32();
            //���Ӑ�R�[�h8
            temp.CustomerCode8 = reader.ReadInt32();
            //���Ӑ�8����
            temp.Customer8TotalDay = reader.ReadInt32();
            //���Ӑ�R�[�h9
            temp.CustomerCode9 = reader.ReadInt32();
            //���Ӑ�9����
            temp.Customer9TotalDay = reader.ReadInt32();
            //���Ӑ�R�[�h10
            temp.CustomerCode10 = reader.ReadInt32();
            //���Ӑ�10����
            temp.Customer10TotalDay = reader.ReadInt32();
            //�v��N����
            temp.AddUpDate = new DateTime(reader.ReadInt64());
            //�v��N��
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //�X�V�Ώۃt���O
            temp.UpdObjectFlag = reader.ReadInt32();
            //�������e�t���O
            temp.ProcCntntsFlag = reader.ReadInt32();
            //�Ώے���
            temp.ObjTotalDay = reader.ReadInt32();
            //�����X�V�敪
            temp.TermLastDiv = reader.ReadInt32();
            //���Ӑ����
            temp.CustomerTotalDay = reader.ReadInt32();


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
        /// <returns>CustDmdPrcUpdateWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustDmdPrcUpdateWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CustDmdPrcUpdateWork temp = GetCustDmdPrcUpdateWork(reader, serInfo);
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
                    retValue = (CustDmdPrcUpdateWork[])lst.ToArray(typeof(CustDmdPrcUpdateWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
