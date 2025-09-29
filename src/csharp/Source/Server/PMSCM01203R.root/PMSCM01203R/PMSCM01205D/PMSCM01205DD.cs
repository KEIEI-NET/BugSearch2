using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PM7RkSRHistWork
    /// <summary>
    ///                      PM7�A�g����M�������O�f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   PM7�A�g����M�������O�f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2011/7/12</br>
    /// <br>Genarated Date   :   2011/07/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2011/7/22  �C����</br>
    /// <br>                 :   �����敪��ǉ�����</br>
    /// <br>                 :   ����M�G���[�̏ꍇ�A������o�^���Ȃ����߁A�X�e�[�^�X�A���M�G���[���O�t�@�C�����́A��M�G���[���O�t�@�C�����̂��폜����</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PM7RkSRHistWork : IFileHeader
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

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>PM7�A�g����M����ԍ�</summary>
        private string _pM7RkSRHistNo = "";

        /// <summary>PM7�A�g�����敪</summary>
        /// <remarks>1�F���M�@2�F��M</remarks>
        private Int32 _pM7RkHistCode;

        /// <summary>PM7�A�g�����敪</summary>
        /// <remarks>0�F�蓮�@1�F����</remarks>
        private Int32 _pM7RkAutoCode;

        /// <summary>���M�J�n����</summary>
        /// <remarks>DateTime:���x��100�i�m�b</remarks>
        private Int64 _sndBeginDateTime;

        /// <summary>���M�I������</summary>
        /// <remarks>DateTime:���x��100�i�m�b</remarks>
        private Int64 _sndEndDateTime;

        /// <summary>���M�t�@�C������</summary>
        private string _sndFileNm = "";

        /// <summary>��M�J�n����</summary>
        /// <remarks>DateTime:���x��100�i�m�b</remarks>
        private Int64 _rcvBeginDateTime;

        /// <summary>��M�I������</summary>
        /// <remarks>DateTime:���x��100�i�m�b</remarks>
        private Int64 _rcvEndDateTime;

        /// <summary>��M�t�@�C������</summary>
        private string _rcvFileNm = "";


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

        /// public propaty name  :  PM7RkSRHistNo
        /// <summary>PM7�A�g����M����ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM7�A�g����M����ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PM7RkSRHistNo
        {
            get { return _pM7RkSRHistNo; }
            set { _pM7RkSRHistNo = value; }
        }

        /// public propaty name  :  PM7RkHistCode
        /// <summary>PM7�A�g�����敪�v���p�e�B</summary>
        /// <value>1�F���M�@2�F��M</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM7�A�g�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PM7RkHistCode
        {
            get { return _pM7RkHistCode; }
            set { _pM7RkHistCode = value; }
        }

        /// public propaty name  :  PM7RkAutoCode
        /// <summary>PM7�A�g�����敪�v���p�e�B</summary>
        /// <value>0�F�蓮�@1�F����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM7�A�g�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PM7RkAutoCode
        {
            get { return _pM7RkAutoCode; }
            set { _pM7RkAutoCode = value; }
        }

        /// public propaty name  :  SndBeginDateTime
        /// <summary>���M�J�n�����v���p�e�B</summary>
        /// <value>DateTime:���x��100�i�m�b</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�J�n�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SndBeginDateTime
        {
            get { return _sndBeginDateTime; }
            set { _sndBeginDateTime = value; }
        }

        /// public propaty name  :  SndEndDateTime
        /// <summary>���M�I�������v���p�e�B</summary>
        /// <value>DateTime:���x��100�i�m�b</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�I�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SndEndDateTime
        {
            get { return _sndEndDateTime; }
            set { _sndEndDateTime = value; }
        }

        /// public propaty name  :  SndFileNm
        /// <summary>���M�t�@�C�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�t�@�C�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SndFileNm
        {
            get { return _sndFileNm; }
            set { _sndFileNm = value; }
        }

        /// public propaty name  :  RcvBeginDateTime
        /// <summary>��M�J�n�����v���p�e�B</summary>
        /// <value>DateTime:���x��100�i�m�b</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��M�J�n�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 RcvBeginDateTime
        {
            get { return _rcvBeginDateTime; }
            set { _rcvBeginDateTime = value; }
        }

        /// public propaty name  :  RcvEndDateTime
        /// <summary>��M�I�������v���p�e�B</summary>
        /// <value>DateTime:���x��100�i�m�b</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��M�I�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 RcvEndDateTime
        {
            get { return _rcvEndDateTime; }
            set { _rcvEndDateTime = value; }
        }

        /// public propaty name  :  RcvFileNm
        /// <summary>��M�t�@�C�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��M�t�@�C�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RcvFileNm
        {
            get { return _rcvFileNm; }
            set { _rcvFileNm = value; }
        }


        /// <summary>
        /// PM7�A�g����M�������O�f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PM7RkSRHistWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PM7RkSRHistWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PM7RkSRHistWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>PM7RkSRHistWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   PM7RkSRHistWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class PM7RkSRHistWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PM7RkSRHistWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PM7RkSRHistWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PM7RkSRHistWork || graph is ArrayList || graph is PM7RkSRHistWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PM7RkSRHistWork).FullName));

            if (graph != null && graph is PM7RkSRHistWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PM7RkSRHistWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PM7RkSRHistWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PM7RkSRHistWork[])graph).Length;
            }
            else if (graph is PM7RkSRHistWork)
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
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //PM7�A�g����M����ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //PM7RkSRHistNo
            //PM7�A�g�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PM7RkHistCode
            //PM7�A�g�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PM7RkAutoCode
            //���M�J�n����
            serInfo.MemberInfo.Add(typeof(Int64)); //SndBeginDateTime
            //���M�I������
            serInfo.MemberInfo.Add(typeof(Int64)); //SndEndDateTime
            //���M�t�@�C������
            serInfo.MemberInfo.Add(typeof(string)); //SndFileNm
            //��M�J�n����
            serInfo.MemberInfo.Add(typeof(Int64)); //RcvBeginDateTime
            //��M�I������
            serInfo.MemberInfo.Add(typeof(Int64)); //RcvEndDateTime
            //��M�t�@�C������
            serInfo.MemberInfo.Add(typeof(string)); //RcvFileNm


            serInfo.Serialize(writer, serInfo);
            if (graph is PM7RkSRHistWork)
            {
                PM7RkSRHistWork temp = (PM7RkSRHistWork)graph;

                SetPM7RkSRHistWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PM7RkSRHistWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PM7RkSRHistWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PM7RkSRHistWork temp in lst)
                {
                    SetPM7RkSRHistWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PM7RkSRHistWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 18;

        /// <summary>
        ///  PM7RkSRHistWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PM7RkSRHistWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetPM7RkSRHistWork(System.IO.BinaryWriter writer, PM7RkSRHistWork temp)
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
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //PM7�A�g����M����ԍ�
            writer.Write(temp.PM7RkSRHistNo);
            //PM7�A�g�����敪
            writer.Write(temp.PM7RkHistCode);
            //PM7�A�g�����敪
            writer.Write(temp.PM7RkAutoCode);
            //���M�J�n����
            writer.Write(temp.SndBeginDateTime);
            //���M�I������
            writer.Write(temp.SndEndDateTime);
            //���M�t�@�C������
            writer.Write(temp.SndFileNm);
            //��M�J�n����
            writer.Write(temp.RcvBeginDateTime);
            //��M�I������
            writer.Write(temp.RcvEndDateTime);
            //��M�t�@�C������
            writer.Write(temp.RcvFileNm);

        }

        /// <summary>
        ///  PM7RkSRHistWork�C���X�^���X�擾
        /// </summary>
        /// <returns>PM7RkSRHistWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PM7RkSRHistWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private PM7RkSRHistWork GetPM7RkSRHistWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            PM7RkSRHistWork temp = new PM7RkSRHistWork();

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
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //PM7�A�g����M����ԍ�
            temp.PM7RkSRHistNo = reader.ReadString();
            //PM7�A�g�����敪
            temp.PM7RkHistCode = reader.ReadInt32();
            //PM7�A�g�����敪
            temp.PM7RkAutoCode = reader.ReadInt32();
            //���M�J�n����
            temp.SndBeginDateTime = reader.ReadInt64();
            //���M�I������
            temp.SndEndDateTime = reader.ReadInt64();
            //���M�t�@�C������
            temp.SndFileNm = reader.ReadString();
            //��M�J�n����
            temp.RcvBeginDateTime = reader.ReadInt64();
            //��M�I������
            temp.RcvEndDateTime = reader.ReadInt64();
            //��M�t�@�C������
            temp.RcvFileNm = reader.ReadString();


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
        /// <returns>PM7RkSRHistWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PM7RkSRHistWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PM7RkSRHistWork temp = GetPM7RkSRHistWork(reader, serInfo);
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
                    retValue = (PM7RkSRHistWork[])lst.ToArray(typeof(PM7RkSRHistWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
