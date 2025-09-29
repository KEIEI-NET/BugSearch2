using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;



namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   DepositStWork
    /// <summary>
    ///                      �����ݒ胏�[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����ݒ胏�[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2008/06/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class DepositStWork : IFileHeader
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _updEmployeeCode = "";

        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�����ݒ�Ǘ��R�[�h</summary>
        /// <remarks>��ɂO�Œ�</remarks>
        private Int32 _depositStMngCd;

        /// <summary>���������\����ʔԍ�</summary>
        /// <remarks>1:�����^,2:�󒍎w��^</remarks>
        private Int32 _depositInitDspNo;

        /// <summary>�����I������R�[�h</summary>
        /// <remarks>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</remarks>
        private Int32 _initSelMoneyKindCd;

        /// <summary>�����ݒ����R�[�h1</summary>
        private Int32 _depositStKindCd1;

        /// <summary>�����ݒ����R�[�h2</summary>
        private Int32 _depositStKindCd2;

        /// <summary>�����ݒ����R�[�h3</summary>
        private Int32 _depositStKindCd3;

        /// <summary>�����ݒ����R�[�h4</summary>
        private Int32 _depositStKindCd4;

        /// <summary>�����ݒ����R�[�h5</summary>
        private Int32 _depositStKindCd5;

        /// <summary>�����ݒ����R�[�h6</summary>
        private Int32 _depositStKindCd6;

        /// <summary>�����ݒ����R�[�h7</summary>
        private Int32 _depositStKindCd7;

        /// <summary>�����ݒ����R�[�h8</summary>
        private Int32 _depositStKindCd8;

        /// <summary>�����ݒ����R�[�h9</summary>
        private Int32 _depositStKindCd9;

        /// <summary>�����ݒ����R�[�h10</summary>
        private Int32 _depositStKindCd10;

        /// <summary>�����ϓ����`�[�ďo�敪</summary>
        /// <remarks>0:�����ς݂ł��Ăяo���A1:���z�����ς݂͌Ăяo���Ȃ�</remarks>
        private Int32 _alwcDepoCallMonthsCd;


        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

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

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUID�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�_���폜�敪�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  DepositStMngCd
        /// <summary>�����ݒ�Ǘ��R�[�h�v���p�e�B</summary>
        /// <value>��ɂO�Œ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ�Ǘ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositStMngCd
        {
            get { return _depositStMngCd; }
            set { _depositStMngCd = value; }
        }

        /// public propaty name  :  DepositInitDspNo
        /// <summary>���������\����ʔԍ��v���p�e�B</summary>
        /// <value>1:�����^,2:�󒍎w��^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������\����ʔԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositInitDspNo
        {
            get { return _depositInitDspNo; }
            set { _depositInitDspNo = value; }
        }

        /// public propaty name  :  InitSelMoneyKindCd
        /// <summary>�����I������R�[�h�v���p�e�B</summary>
        /// <value>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����I������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InitSelMoneyKindCd
        {
            get { return _initSelMoneyKindCd; }
            set { _initSelMoneyKindCd = value; }
        }

        /// public propaty name  :  DepositStKindCd1
        /// <summary>�����ݒ����R�[�h1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositStKindCd1
        {
            get { return _depositStKindCd1; }
            set { _depositStKindCd1 = value; }
        }

        /// public propaty name  :  DepositStKindCd2
        /// <summary>�����ݒ����R�[�h2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositStKindCd2
        {
            get { return _depositStKindCd2; }
            set { _depositStKindCd2 = value; }
        }

        /// public propaty name  :  DepositStKindCd3
        /// <summary>�����ݒ����R�[�h3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositStKindCd3
        {
            get { return _depositStKindCd3; }
            set { _depositStKindCd3 = value; }
        }

        /// public propaty name  :  DepositStKindCd4
        /// <summary>�����ݒ����R�[�h4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositStKindCd4
        {
            get { return _depositStKindCd4; }
            set { _depositStKindCd4 = value; }
        }

        /// public propaty name  :  DepositStKindCd5
        /// <summary>�����ݒ����R�[�h5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositStKindCd5
        {
            get { return _depositStKindCd5; }
            set { _depositStKindCd5 = value; }
        }

        /// public propaty name  :  DepositStKindCd6
        /// <summary>�����ݒ����R�[�h6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositStKindCd6
        {
            get { return _depositStKindCd6; }
            set { _depositStKindCd6 = value; }
        }

        /// public propaty name  :  DepositStKindCd7
        /// <summary>�����ݒ����R�[�h7�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositStKindCd7
        {
            get { return _depositStKindCd7; }
            set { _depositStKindCd7 = value; }
        }

        /// public propaty name  :  DepositStKindCd8
        /// <summary>�����ݒ����R�[�h8�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositStKindCd8
        {
            get { return _depositStKindCd8; }
            set { _depositStKindCd8 = value; }
        }

        /// public propaty name  :  DepositStKindCd9
        /// <summary>�����ݒ����R�[�h9�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositStKindCd9
        {
            get { return _depositStKindCd9; }
            set { _depositStKindCd9 = value; }
        }

        /// public propaty name  :  DepositStKindCd10
        /// <summary>�����ݒ����R�[�h10�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositStKindCd10
        {
            get { return _depositStKindCd10; }
            set { _depositStKindCd10 = value; }
        }

        /// public propaty name  :  AlwcDepoCallMonthsCd
        /// <summary>�����ϓ����`�[�ďo�敪�v���p�e�B</summary>
        /// <value>0:�����ς݂ł��Ăяo���A1:���z�����ς݂͌Ăяo���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ϓ����`�[�ďo�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AlwcDepoCallMonthsCd
        {
            get { return _alwcDepoCallMonthsCd; }
            set { _alwcDepoCallMonthsCd = value; }
        }


        /// <summary>
        /// �����ݒ胏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>DepositStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DepositStWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DepositStWork()
        {
        }

    }


    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>DepositStWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   DepositStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class DepositStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DepositStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  DepositStWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is DepositStWork || graph is ArrayList || graph is DepositStWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(DepositStWork).FullName));

            if (graph != null && graph is DepositStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.DepositStWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is DepositStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((DepositStWork[])graph).Length;
            }
            else if (graph is DepositStWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //�X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //�����ݒ�Ǘ��R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositStMngCd
            //���������\����ʔԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositInitDspNo
            //�����I������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //InitSelMoneyKindCd
            //�����ݒ����R�[�h1
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositStKindCd1
            //�����ݒ����R�[�h2
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositStKindCd2
            //�����ݒ����R�[�h3
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositStKindCd3
            //�����ݒ����R�[�h4
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositStKindCd4
            //�����ݒ����R�[�h5
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositStKindCd5
            //�����ݒ����R�[�h6
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositStKindCd6
            //�����ݒ����R�[�h7
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositStKindCd7
            //�����ݒ����R�[�h8
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositStKindCd8
            //�����ݒ����R�[�h9
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositStKindCd9
            //�����ݒ����R�[�h10
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositStKindCd10
            //�����ϓ����`�[�ďo�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AlwcDepoCallMonthsCd


            serInfo.Serialize(writer, serInfo);
            if (graph is DepositStWork)
            {
                DepositStWork temp = (DepositStWork)graph;

                SetDepositStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is DepositStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((DepositStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (DepositStWork temp in lst)
                {
                    SetDepositStWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// DepositStWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 22;

        /// <summary>
        ///  DepositStWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DepositStWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetDepositStWork(System.IO.BinaryWriter writer, DepositStWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //�X�V�]�ƈ��R�[�h
            writer.Write(temp.UpdEmployeeCode);
            //�X�V�A�Z���u��ID1
            writer.Write(temp.UpdAssemblyId1);
            //�X�V�A�Z���u��ID2
            writer.Write(temp.UpdAssemblyId2);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //�����ݒ�Ǘ��R�[�h
            writer.Write(temp.DepositStMngCd);
            //���������\����ʔԍ�
            writer.Write(temp.DepositInitDspNo);
            //�����I������R�[�h
            writer.Write(temp.InitSelMoneyKindCd);
            //�����ݒ����R�[�h1
            writer.Write(temp.DepositStKindCd1);
            //�����ݒ����R�[�h2
            writer.Write(temp.DepositStKindCd2);
            //�����ݒ����R�[�h3
            writer.Write(temp.DepositStKindCd3);
            //�����ݒ����R�[�h4
            writer.Write(temp.DepositStKindCd4);
            //�����ݒ����R�[�h5
            writer.Write(temp.DepositStKindCd5);
            //�����ݒ����R�[�h6
            writer.Write(temp.DepositStKindCd6);
            //�����ݒ����R�[�h7
            writer.Write(temp.DepositStKindCd7);
            //�����ݒ����R�[�h8
            writer.Write(temp.DepositStKindCd8);
            //�����ݒ����R�[�h9
            writer.Write(temp.DepositStKindCd9);
            //�����ݒ����R�[�h10
            writer.Write(temp.DepositStKindCd10);
            //�����ϓ����`�[�ďo�敪
            writer.Write(temp.AlwcDepoCallMonthsCd);

        }

        /// <summary>
        ///  DepositStWork�C���X�^���X�擾
        /// </summary>
        /// <returns>DepositStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DepositStWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private DepositStWork GetDepositStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            DepositStWork temp = new DepositStWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //�X�V�]�ƈ��R�[�h
            temp.UpdEmployeeCode = reader.ReadString();
            //�X�V�A�Z���u��ID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //�X�V�A�Z���u��ID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //�����ݒ�Ǘ��R�[�h
            temp.DepositStMngCd = reader.ReadInt32();
            //���������\����ʔԍ�
            temp.DepositInitDspNo = reader.ReadInt32();
            //�����I������R�[�h
            temp.InitSelMoneyKindCd = reader.ReadInt32();
            //�����ݒ����R�[�h1
            temp.DepositStKindCd1 = reader.ReadInt32();
            //�����ݒ����R�[�h2
            temp.DepositStKindCd2 = reader.ReadInt32();
            //�����ݒ����R�[�h3
            temp.DepositStKindCd3 = reader.ReadInt32();
            //�����ݒ����R�[�h4
            temp.DepositStKindCd4 = reader.ReadInt32();
            //�����ݒ����R�[�h5
            temp.DepositStKindCd5 = reader.ReadInt32();
            //�����ݒ����R�[�h6
            temp.DepositStKindCd6 = reader.ReadInt32();
            //�����ݒ����R�[�h7
            temp.DepositStKindCd7 = reader.ReadInt32();
            //�����ݒ����R�[�h8
            temp.DepositStKindCd8 = reader.ReadInt32();
            //�����ݒ����R�[�h9
            temp.DepositStKindCd9 = reader.ReadInt32();
            //�����ݒ����R�[�h10
            temp.DepositStKindCd10 = reader.ReadInt32();
            //�����ϓ����`�[�ďo�敪
            temp.AlwcDepoCallMonthsCd = reader.ReadInt32();


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
        /// <returns>DepositStWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DepositStWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                DepositStWork temp = GetDepositStWork(reader, serInfo);
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
                    retValue = (DepositStWork[])lst.ToArray(typeof(DepositStWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
