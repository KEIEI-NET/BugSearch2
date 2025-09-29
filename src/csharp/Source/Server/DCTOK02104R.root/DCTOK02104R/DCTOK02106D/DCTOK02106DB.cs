using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RsltInfo_PrevYearComparisonWork
    /// <summary>
    ///                      �O�N�Δ�\���o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �O�N�Δ�\���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/12/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RsltInfo_PrevYearComparisonWork
    {
        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _addUpSecCode = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���[�󎚗p</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>�S���҃R�[�h</summary>
        /// <remarks>�󒍎҃R�[�h�����˂�</remarks>
        private string _employeeCode = "";

        /// <summary>����</summary>
        /// <remarks>�󒍎Җ��̂����˂�</remarks>
        private string _name = "";

        /// <summary>BL�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL���i�R�[�h���́i���p�j</summary>
        private string _bLGoodsHalfName = "";

        /// <summary>���i�啪�ރR�[�h</summary>
        private Int32 _goodsLGroup;

        /// <summary>���i�啪�ޖ���</summary>
        private string _goodsLGroupName = "";

        /// <summary>���i�����ރR�[�h</summary>
        private Int32 _goodsMGroup;

        /// <summary>���i�����ޖ���</summary>
        private string _goodsMGroupName = "";

        /// <summary>�O���[�v�R�[�h</summary>
        private Int32 _bLGroupCode;

        /// <summary>BL�O���[�v�R�[�h�J�i����</summary>
        /// <remarks>���p�J�i</remarks>
        private string _bLGroupKanaName = "";

        /// <summary>�n��R�[�h</summary>
        private Int32 _salesAreaCode;

        /// <summary>�n�於��</summary>
        private string _salesAreaName = "";

        /// <summary>�Ǝ�R�[�h</summary>
        private Int32 _businessTypeCode;

        /// <summary>�Ǝ햼��</summary>
        private string _businessTypeName = "";

        /// <summary>��</summary>
        private Int32 _addUpMonth;

        /// <summary>����z</summary>
        private Int64 _thisTermSales;

        /// <summary>����z</summary>
        private Int64 _firstTermSales;

        /// <summary>�e���z</summary>
        private Int64 _thisTermGross;

        /// <summary>�e���z</summary>
        private Int64 _firstTermGross;


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

        /// public propaty name  :  EmployeeCode
        /// <summary>�S���҃R�[�h�v���p�e�B</summary>
        /// <value>�󒍎҃R�[�h�����˂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        /// public propaty name  :  Name
        /// <summary>���̃v���p�e�B</summary>
        /// <value>�󒍎Җ��̂����˂�</value>
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

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�v���p�e�B</br>
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
        /// <summary>�O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  BLGroupKanaName
        /// <summary>BL�O���[�v�R�[�h�J�i���̃v���p�e�B</summary>
        /// <value>���p�J�i</value>
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

        /// public propaty name  :  SalesAreaCode
        /// <summary>�n��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  SalesAreaName
        /// <summary>�n�於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n�於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesAreaName
        {
            get { return _salesAreaName; }
            set { _salesAreaName = value; }
        }

        /// public propaty name  :  BusinessTypeCode
        /// <summary>�Ǝ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BusinessTypeCode
        {
            get { return _businessTypeCode; }
            set { _businessTypeCode = value; }
        }

        /// public propaty name  :  BusinessTypeName
        /// <summary>�Ǝ햼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ햼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BusinessTypeName
        {
            get { return _businessTypeName; }
            set { _businessTypeName = value; }
        }

        /// public propaty name  :  AddUpMonth
        /// <summary>���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddUpMonth
        {
            get { return _addUpMonth; }
            set { _addUpMonth = value; }
        }

        /// public propaty name  :  ThisTermSales
        /// <summary>����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTermSales
        {
            get { return _thisTermSales; }
            set { _thisTermSales = value; }
        }

        /// public propaty name  :  FirstTermSales
        /// <summary>����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 FirstTermSales
        {
            get { return _firstTermSales; }
            set { _firstTermSales = value; }
        }

        /// public propaty name  :  ThisTermGross
        /// <summary>�e���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTermGross
        {
            get { return _thisTermGross; }
            set { _thisTermGross = value; }
        }

        /// public propaty name  :  FirstTermGross
        /// <summary>�e���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 FirstTermGross
        {
            get { return _firstTermGross; }
            set { _firstTermGross = value; }
        }


        /// <summary>
        /// �O�N�Δ�\���o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>RsltInfo_PrevYearComparisonWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_PrevYearComparisonWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RsltInfo_PrevYearComparisonWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>RsltInfo_PrevYearComparisonWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   RsltInfo_PrevYearComparisonWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class RsltInfo_PrevYearComparisonWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_PrevYearComparisonWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RsltInfo_PrevYearComparisonWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RsltInfo_PrevYearComparisonWork || graph is ArrayList || graph is RsltInfo_PrevYearComparisonWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(RsltInfo_PrevYearComparisonWork).FullName));

            if (graph != null && graph is RsltInfo_PrevYearComparisonWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RsltInfo_PrevYearComparisonWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RsltInfo_PrevYearComparisonWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RsltInfo_PrevYearComparisonWork[])graph).Length;
            }
            else if (graph is RsltInfo_PrevYearComparisonWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ旪��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //�S���҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            //����
            serInfo.MemberInfo.Add(typeof(string)); //Name
            //BL�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL���i�R�[�h���́i���p�j
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsHalfName
            //���i�啪�ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsLGroup
            //���i�啪�ޖ���
            serInfo.MemberInfo.Add(typeof(string)); //GoodsLGroupName
            //���i�����ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //���i�����ޖ���
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMGroupName
            //�O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //BL�O���[�v�R�[�h�J�i����
            serInfo.MemberInfo.Add(typeof(string)); //BLGroupKanaName
            //�n��R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //�n�於��
            serInfo.MemberInfo.Add(typeof(string)); //SalesAreaName
            //�Ǝ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BusinessTypeCode
            //�Ǝ햼��
            serInfo.MemberInfo.Add(typeof(string)); //BusinessTypeName
            //��
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpMonth
            //����z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTermSales
            //����z
            serInfo.MemberInfo.Add(typeof(Int64)); //FirstTermSales
            //�e���z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTermGross
            //�e���z
            serInfo.MemberInfo.Add(typeof(Int64)); //FirstTermGross


            serInfo.Serialize(writer, serInfo);
            if (graph is RsltInfo_PrevYearComparisonWork)
            {
                RsltInfo_PrevYearComparisonWork temp = (RsltInfo_PrevYearComparisonWork)graph;

                SetRsltInfo_PrevYearComparisonWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RsltInfo_PrevYearComparisonWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RsltInfo_PrevYearComparisonWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RsltInfo_PrevYearComparisonWork temp in lst)
                {
                    SetRsltInfo_PrevYearComparisonWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RsltInfo_PrevYearComparisonWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 23;

        /// <summary>
        ///  RsltInfo_PrevYearComparisonWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_PrevYearComparisonWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetRsltInfo_PrevYearComparisonWork(System.IO.BinaryWriter writer, RsltInfo_PrevYearComparisonWork temp)
        {
            //�v�㋒�_�R�[�h
            writer.Write(temp.AddUpSecCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideSnm);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ旪��
            writer.Write(temp.CustomerSnm);
            //�S���҃R�[�h
            writer.Write(temp.EmployeeCode);
            //����
            writer.Write(temp.Name);
            //BL�R�[�h
            writer.Write(temp.BLGoodsCode);
            //BL���i�R�[�h���́i���p�j
            writer.Write(temp.BLGoodsHalfName);
            //���i�啪�ރR�[�h
            writer.Write(temp.GoodsLGroup);
            //���i�啪�ޖ���
            writer.Write(temp.GoodsLGroupName);
            //���i�����ރR�[�h
            writer.Write(temp.GoodsMGroup);
            //���i�����ޖ���
            writer.Write(temp.GoodsMGroupName);
            //�O���[�v�R�[�h
            writer.Write(temp.BLGroupCode);
            //BL�O���[�v�R�[�h�J�i����
            writer.Write(temp.BLGroupKanaName);
            //�n��R�[�h
            writer.Write(temp.SalesAreaCode);
            //�n�於��
            writer.Write(temp.SalesAreaName);
            //�Ǝ�R�[�h
            writer.Write(temp.BusinessTypeCode);
            //�Ǝ햼��
            writer.Write(temp.BusinessTypeName);
            //��
            writer.Write(temp.AddUpMonth);
            //����z
            writer.Write(temp.ThisTermSales);
            //����z
            writer.Write(temp.FirstTermSales);
            //�e���z
            writer.Write(temp.ThisTermGross);
            //�e���z
            writer.Write(temp.FirstTermGross);

        }

        /// <summary>
        ///  RsltInfo_PrevYearComparisonWork�C���X�^���X�擾
        /// </summary>
        /// <returns>RsltInfo_PrevYearComparisonWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_PrevYearComparisonWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private RsltInfo_PrevYearComparisonWork GetRsltInfo_PrevYearComparisonWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            RsltInfo_PrevYearComparisonWork temp = new RsltInfo_PrevYearComparisonWork();

            //�v�㋒�_�R�[�h
            temp.AddUpSecCode = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideSnm = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ旪��
            temp.CustomerSnm = reader.ReadString();
            //�S���҃R�[�h
            temp.EmployeeCode = reader.ReadString();
            //����
            temp.Name = reader.ReadString();
            //BL�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //BL���i�R�[�h���́i���p�j
            temp.BLGoodsHalfName = reader.ReadString();
            //���i�啪�ރR�[�h
            temp.GoodsLGroup = reader.ReadInt32();
            //���i�啪�ޖ���
            temp.GoodsLGroupName = reader.ReadString();
            //���i�����ރR�[�h
            temp.GoodsMGroup = reader.ReadInt32();
            //���i�����ޖ���
            temp.GoodsMGroupName = reader.ReadString();
            //�O���[�v�R�[�h
            temp.BLGroupCode = reader.ReadInt32();
            //BL�O���[�v�R�[�h�J�i����
            temp.BLGroupKanaName = reader.ReadString();
            //�n��R�[�h
            temp.SalesAreaCode = reader.ReadInt32();
            //�n�於��
            temp.SalesAreaName = reader.ReadString();
            //�Ǝ�R�[�h
            temp.BusinessTypeCode = reader.ReadInt32();
            //�Ǝ햼��
            temp.BusinessTypeName = reader.ReadString();
            //��
            temp.AddUpMonth = reader.ReadInt32();
            //����z
            temp.ThisTermSales = reader.ReadInt64();
            //����z
            temp.FirstTermSales = reader.ReadInt64();
            //�e���z
            temp.ThisTermGross = reader.ReadInt64();
            //�e���z
            temp.FirstTermGross = reader.ReadInt64();


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
        /// <returns>RsltInfo_PrevYearComparisonWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_PrevYearComparisonWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RsltInfo_PrevYearComparisonWork temp = GetRsltInfo_PrevYearComparisonWork(reader, serInfo);
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
                    retValue = (RsltInfo_PrevYearComparisonWork[])lst.ToArray(typeof(RsltInfo_PrevYearComparisonWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
