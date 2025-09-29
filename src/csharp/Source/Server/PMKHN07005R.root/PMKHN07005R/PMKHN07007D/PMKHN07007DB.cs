using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PostCustomerWork
    /// <summary>
    ///                      ���Ӑ惏�[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���Ӑ惏�[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/18</br>
    /// <br>Genarated Date   :   2009/04/17  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/5/1  ����</br>
    /// <br>                 :   ���Ӑ�|���O���[�v�R�[�h���폜</br>
    /// <br>Update Note      :   2008/6/16  ����</br>
    /// <br>                 :   ���Ӑ�`�[�ԍ��̕⑫�����ύX</br>
    /// <br>                 :   0:�g�p���Ȃ�,1:�g�p����</br>
    /// <br>                 :   �@�@�@��</br>
    /// <br>                 :   0:�g�p���Ȃ�,1:�A��,2:����,3:����</br>
    /// <br>Update Note      :   2008/11/10  ����</br>
    /// <br>                 :   ���⑫�ύX</br>
    /// <br>                 :   QR�R�[�h�󎚋敪</br>
    /// <br>                 :   0:�W�� 1:�󎚂��Ȃ� 2:�󎚂��� 3:�ԕi�܂�</br>
    /// <br>Update Note      :   2008/11/11  ����</br>
    /// <br>                 :   ���⑫�ύX</br>
    /// <br>                 :   0:���Ȃ��@1:����</br>
    /// <br>                 :   ��</br>
    /// <br>                 :   0:�S�̐ݒ�Q�� 1:���Ȃ��@2:����</br>
    /// <br>Update Note      :   2008/12/1  ����</br>
    /// <br>                 :   �� �f�[�^�^�ύX</br>
    /// <br>                 :   ���Ӑ�D��q�ɃR�[�h</br>
    /// <br>                 :   Int32�@�ˁ@nchar 6 12byte</br>
    /// <br>                 :   �W�����敪����</br>
    /// <br>                 :   nvarchar 3 6byte�@�ˁ@nvarchar 4 8byte</br>
    /// <br>Update Note      :   2008/12/19  ����</br>
    /// <br>                 :   �� ���ڒǉ�</br>
    /// <br>                 :   ����`�[���s�敪 </br>
    /// <br>                 :   �o�ד`�[���s�敪 </br>
    /// <br>                 :   �󒍓`�[���s�敪 </br>
    /// <br>                 :   ���Ϗ����s�敪  </br>
    /// <br>                 :   UOE�`�[���s�敪  </br>
    /// <br>Update Note      :   2009/2/6  ����</br>
    /// <br>                 :   ���⑫�C��</br>
    /// <br>                 :   �������</br>
    /// <br>                 :   10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</br>
    /// <br>                 :   ��</br>
    /// <br>                 :   51:����,52:�U��,53:���؎�,54:��`56:���E,58:���̑�</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PostCustomerWork : IFileHeader
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


        /// <summary>�Ǘ����_�R�[�h</summary>
        private string _mngSectionCode = "";

        /// <summary>���Ӑ�R�[�h</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private Int32 _customerCode;

        /// <summary>����</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _name = "";

        /// <summary>����2</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _name2 = "";

        /// <summary>�X�֔ԍ�</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _postNo = "";

        /// <summary>�Z��1�i�s���{���s��S�E�����E���j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _address1 = "";

        /// <summary>�Z��3�i�Ԓn�j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _address3 = "";

        /// <summary>�Z��4�i�A�p�[�g���́j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _address4 = "";

        /// <summary>�d�b�ԍ��i�Ζ���j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _officeTelNo = "";

        /// <summary>�d�b�ԍ��i����j</summary>
        /// <remarks>�n�C�t�����܂߂�16���̔ԍ�</remarks>
        private string _homeTelNo = "";

        /// <summary>FAX�ԍ��i�Ζ���j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _officeFaxNo = "";

        /// <summary>���Ӑ�S����</summary>
        /// <remarks>���Ӑ�i�d����j�̖₢���킹��Ј���</remarks>
        private string _customerAgent = "";


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

        /// public propaty name  :  MngSectionCode
        /// <summary>�Ǘ����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǘ����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MngSectionCode
        {
            get { return _mngSectionCode; }
            set { _mngSectionCode = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
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

        /// public propaty name  :  Name
        /// <summary>���̃v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
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

        /// public propaty name  :  Name2
        /// <summary>����2�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Name2
        {
            get { return _name2; }
            set { _name2 = value; }
        }

        /// public propaty name  :  PostNo
        /// <summary>�X�֔ԍ��v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PostNo
        {
            get { return _postNo; }
            set { _postNo = value; }
        }

        /// public propaty name  :  Address1
        /// <summary>�Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }

        /// public propaty name  :  Address3
        /// <summary>�Z��3�i�Ԓn�j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��3�i�Ԓn�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Address3
        {
            get { return _address3; }
            set { _address3 = value; }
        }

        /// public propaty name  :  Address4
        /// <summary>�Z��4�i�A�p�[�g���́j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��4�i�A�p�[�g���́j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Address4
        {
            get { return _address4; }
            set { _address4 = value; }
        }

        /// public propaty name  :  OfficeTelNo
        /// <summary>�d�b�ԍ��i�Ζ���j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i�Ζ���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OfficeTelNo
        {
            get { return _officeTelNo; }
            set { _officeTelNo = value; }
        }

        /// public propaty name  :  HomeTelNo
        /// <summary>�d�b�ԍ��i����j�v���p�e�B</summary>
        /// <value>�n�C�t�����܂߂�16���̔ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HomeTelNo
        {
            get { return _homeTelNo; }
            set { _homeTelNo = value; }
        }

        /// public propaty name  :  OfficeFaxNo
        /// <summary>FAX�ԍ��i�Ζ���j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FAX�ԍ��i�Ζ���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OfficeFaxNo
        {
            get { return _officeFaxNo; }
            set { _officeFaxNo = value; }
        }

        /// public propaty name  :  CustomerAgent
        /// <summary>���Ӑ�S���҃v���p�e�B</summary>
        /// <value>���Ӑ�i�d����j�̖₢���킹��Ј���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�S���҃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerAgent
        {
            get { return _customerAgent; }
            set { _customerAgent = value; }
        }


        /// <summary>
        /// ���Ӑ惏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PostCustomerWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PostCustomerWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PostCustomerWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>PostCustomerWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   PostCustomerWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class PostCustomerWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PostCustomerWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PostCustomerWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PostCustomerWork || graph is ArrayList || graph is PostCustomerWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PostCustomerWork).FullName));

            if (graph != null && graph is PostCustomerWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PostCustomerWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PostCustomerWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PostCustomerWork[])graph).Length;
            }
            else if (graph is PostCustomerWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�Ǘ����_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //MngSectionCode
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //����
            serInfo.MemberInfo.Add(typeof(string)); //Name
            //����2
            serInfo.MemberInfo.Add(typeof(string)); //Name2
            //�X�֔ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //PostNo
            //�Z��1�i�s���{���s��S�E�����E���j
            serInfo.MemberInfo.Add(typeof(string)); //Address1
            //�Z��3�i�Ԓn�j
            serInfo.MemberInfo.Add(typeof(string)); //Address3
            //�Z��4�i�A�p�[�g���́j
            serInfo.MemberInfo.Add(typeof(string)); //Address4
            //�d�b�ԍ��i�Ζ���j
            serInfo.MemberInfo.Add(typeof(string)); //OfficeTelNo
            //�d�b�ԍ��i����j
            serInfo.MemberInfo.Add(typeof(string)); //HomeTelNo
            //FAX�ԍ��i�Ζ���j
            serInfo.MemberInfo.Add(typeof(string)); //OfficeFaxNo
            //���Ӑ�S����
            serInfo.MemberInfo.Add(typeof(string)); //CustomerAgent


            serInfo.Serialize(writer, serInfo);
            if (graph is PostCustomerWork)
            {
                PostCustomerWork temp = (PostCustomerWork)graph;

                SetPostCustomerWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PostCustomerWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PostCustomerWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PostCustomerWork temp in lst)
                {
                    SetPostCustomerWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PostCustomerWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 12;

        /// <summary>
        ///  PostCustomerWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PostCustomerWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetPostCustomerWork(System.IO.BinaryWriter writer, PostCustomerWork temp)
        {
            //�Ǘ����_�R�[�h
            writer.Write(temp.MngSectionCode);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //����
            writer.Write(temp.Name);
            //����2
            writer.Write(temp.Name2);
            //�X�֔ԍ�
            writer.Write(temp.PostNo);
            //�Z��1�i�s���{���s��S�E�����E���j
            writer.Write(temp.Address1);
            //�Z��3�i�Ԓn�j
            writer.Write(temp.Address3);
            //�Z��4�i�A�p�[�g���́j
            writer.Write(temp.Address4);
            //�d�b�ԍ��i�Ζ���j
            writer.Write(temp.OfficeTelNo);
            //�d�b�ԍ��i����j
            writer.Write(temp.HomeTelNo);
            //FAX�ԍ��i�Ζ���j
            writer.Write(temp.OfficeFaxNo);
            //���Ӑ�S����
            writer.Write(temp.CustomerAgent);

        }

        /// <summary>
        ///  PostCustomerWork�C���X�^���X�擾
        /// </summary>
        /// <returns>PostCustomerWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PostCustomerWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private PostCustomerWork GetPostCustomerWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            PostCustomerWork temp = new PostCustomerWork();

            //�Ǘ����_�R�[�h
            temp.MngSectionCode = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //����
            temp.Name = reader.ReadString();
            //����2
            temp.Name2 = reader.ReadString();
            //�X�֔ԍ�
            temp.PostNo = reader.ReadString();
            //�Z��1�i�s���{���s��S�E�����E���j
            temp.Address1 = reader.ReadString();
            //�Z��3�i�Ԓn�j
            temp.Address3 = reader.ReadString();
            //�Z��4�i�A�p�[�g���́j
            temp.Address4 = reader.ReadString();
            //�d�b�ԍ��i�Ζ���j
            temp.OfficeTelNo = reader.ReadString();
            //�d�b�ԍ��i����j
            temp.HomeTelNo = reader.ReadString();
            //FAX�ԍ��i�Ζ���j
            temp.OfficeFaxNo = reader.ReadString();
            //���Ӑ�S����
            temp.CustomerAgent = reader.ReadString();


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
        /// <returns>PostCustomerWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PostCustomerWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PostCustomerWork temp = GetPostCustomerWork(reader, serInfo);
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
                    retValue = (PostCustomerWork[])lst.ToArray(typeof(PostCustomerWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
