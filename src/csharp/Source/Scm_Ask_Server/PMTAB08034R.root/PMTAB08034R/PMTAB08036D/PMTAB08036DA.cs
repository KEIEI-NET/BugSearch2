//**********************************************************************
// System           : PM.NS
// Sub System       :
// Program name     : PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^���[�N
//                  : PMTAB08036D.DLL
// Name Space       : Broadleaf.Application.Remoting.ParamData
// Programmer       : 30746 ���� ��
// Date             : 2014/09/26
//----------------------------------------------------------------------
// Update Note      :
// Programmer       :
// Date             :
//----------------------------------------------------------------------
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PmtGeneralSrRstWork
    /// <summary>
    ///                      PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2014/09/26</br>
    /// <br>Genarated Date   :   2014/09/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br>                 :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PmtGeneralSrRstWork : IFileHeader
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

        /// <summary>�������_�R�[�h</summary>
        private string _searchSectionCode = "";

        /// <summary>�Ɩ��Z�b�V����ID</summary>
        private string _businessSessionId = "";

        /// <summary>�f�[�^�敪</summary>
        private Int32 _linkDataCode;

        /// <summary>PMTAB���׎���GUID</summary>
        private string _pmTabDtlDiscGuid = "";

        /// <summary>PMTAB�����s�ԍ�</summary>
        private Int32 _pmTabSearchRowNum;

        /// <summary>�f�[�^�폜�\���</summary>
        private Int32 _DataDeleteDate;

        /// <summary>�̔��]�ƈ��R�[�h</summary>
        private string _salesEmployeeCd = "";

        /// <summary>�̔��]�ƈ�����</summary>
        private string _salesEmployeeNm = "";

        /// <summary>��t�]�ƈ��R�[�h</summary>
        private string _frontEmployeeCd = "";

        /// <summary>��t�]�ƈ�����</summary>
        private string _frontEmployeeNm = "";

        /// <summary>������͎҃R�[�h</summary>
        private string _salesInputCode = "";

        /// <summary>������͎Җ���</summary>
        private string _salesInputName = "";


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



        /// public propaty name  :  SearchSectionCode
        /// <summary>�������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchSectionCode
        {
            get { return _searchSectionCode; }
            set { _searchSectionCode = value; }
        }

        /// public propaty name  :  BusinessSessionId
        /// <summary>�Ɩ��Z�b�V����ID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ɩ��Z�b�V����ID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BusinessSessionId
        {
            get { return _businessSessionId; }
            set { _businessSessionId = value; }
        }

        /// public propaty name  :  LinkDataCode
        /// <summary>�f�[�^�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LinkDataCode
        {
            get { return _linkDataCode; }
            set { _linkDataCode = value; }
        }

        /// public propaty name  :  PmTabDtlDiscGuid
        /// <summary>PMTAB���׎���GUID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PMTAB���׎���GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PmTabDtlDiscGuid
        {
            get { return _pmTabDtlDiscGuid; }
            set { _pmTabDtlDiscGuid = value; }
        }

        /// public propaty name  :  PmTabSearchRowNum
        /// <summary>PMTAB�����s�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PMTAB�����s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PmTabSearchRowNum
        {
            get { return _pmTabSearchRowNum; }
            set { _pmTabSearchRowNum = value; }
        }

        /// public propaty name  :  DataDeleteDate
        /// <summary>�f�[�^�폜�\����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^�폜�\����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DataDeleteDate
        {
            get { return _DataDeleteDate; }
            set { _DataDeleteDate = value; }
        }

        /// public propaty name  :  SalesEmployeeCd
        /// <summary>�̔��]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesEmployeeCd
        {
            get { return _salesEmployeeCd; }
            set { _salesEmployeeCd = value; }
        }

        /// public propaty name  :  SalesEmployeeNm
        /// <summary>�̔��]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesEmployeeNm
        {
            get { return _salesEmployeeNm; }
            set { _salesEmployeeNm = value; }
        }

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>��t�]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��t�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrontEmployeeCd
        {
            get { return _frontEmployeeCd; }
            set { _frontEmployeeCd = value; }
        }

        /// public propaty name  :  FrontEmployeeNm
        /// <summary>��t�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��t�]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrontEmployeeNm
        {
            get { return _frontEmployeeNm; }
            set { _frontEmployeeNm = value; }
        }

        /// public propaty name  :  SalesInputCode
        /// <summary>������͎҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������͎҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesInputCode
        {
            get { return _salesInputCode; }
            set { _salesInputCode = value; }
        }

        /// public propaty name  :  SalesInputName
        /// <summary>������͎Җ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������͎Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesInputName
        {
            get { return _salesInputName; }
            set { _salesInputName = value; }
        }

        /// <summary>
        /// PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PmtGeneralSrRstWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PmtGeneralSrRstWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PmtGeneralSrRstWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>PmtGeneralSrRstWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   PmtGeneralSrRstWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class PmtGeneralSrRstWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PmtGeneralSrRstWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PmtGeneralSrRstWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PmtGeneralSrRstWork || graph is ArrayList || graph is PmtGeneralSrRstWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PmtGeneralSrRstWork).FullName));

            if (graph != null && graph is PmtGeneralSrRstWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PmtGeneralSrRstWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PmtGeneralSrRstWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PmtGeneralSrRstWork[])graph).Length;
            }
            else if (graph is PmtGeneralSrRstWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64));  //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64));  //UpdateDateTime
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[])); //FileHeaderGuid
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //�X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32));  //LogicalDeleteCode
            //�������_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SearchSectionCode
            //�Ɩ��Z�b�V����ID
            serInfo.MemberInfo.Add(typeof(string)); //BusinessSessionId
            //�f�[�^�敪
            serInfo.MemberInfo.Add(typeof(Int32));  //LinkDataCode
            //PMTAB���׎���GUID
            serInfo.MemberInfo.Add(typeof(string)); //PmTabDtlDiscGuid
            //PMTAB�����s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32));  //PmTabSearchRowNum
            //�f�[�^�폜�\���
            serInfo.MemberInfo.Add(typeof(Int32));  //DataDeleteDate
            //�̔��]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeCd
            //�̔��]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeNm
            //��t�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //FrontEmployeeCd
            //��t�]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //FrontEmployeeNm
            //������͎҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SalesInputCode
            //������͎Җ���
            serInfo.MemberInfo.Add(typeof(string)); //SalesInputName

            serInfo.Serialize(writer, serInfo);
            if (graph is PmtGeneralSrRstWork)
            {
                PmtGeneralSrRstWork temp = (PmtGeneralSrRstWork)graph;

                SetPmtGeneralSrRstWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PmtGeneralSrRstWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PmtGeneralSrRstWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PmtGeneralSrRstWork temp in lst)
                {
                    SetPmtGeneralSrRstWork(writer, temp);
                }

            }

        }


        /// <summary>
        /// PmtGeneralSrRstWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 20;

        /// <summary>
        ///  PmtGeneralSrRstWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PmtGeneralSrRstWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetPmtGeneralSrRstWork(System.IO.BinaryWriter writer, PmtGeneralSrRstWork temp)
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
            //�������_�R�[�h
            writer.Write(temp.SearchSectionCode);
            //�Ɩ��Z�b�V����ID
            writer.Write(temp.BusinessSessionId);
            //�f�[�^�敪
            writer.Write(temp.LinkDataCode);
            //PMTAB���׎���GUID
            writer.Write(temp.PmTabDtlDiscGuid);
            //PMTAB�����s�ԍ�
            writer.Write(temp.PmTabSearchRowNum);
            //�f�[�^�폜�\���
            writer.Write(temp.DataDeleteDate);
            //�̔��]�ƈ��R�[�h
            writer.Write(temp.SalesEmployeeCd);
            //�̔��]�ƈ�����
            writer.Write(temp.SalesEmployeeNm);
            //��t�]�ƈ��R�[�h
            writer.Write(temp.FrontEmployeeCd);
            //��t�]�ƈ�����
            writer.Write(temp.FrontEmployeeNm);
            //������͎҃R�[�h
            writer.Write(temp.SalesInputCode);
            //������͎Җ���
            writer.Write(temp.SalesInputName);

        }

        /// <summary>
        ///  PmtGeneralSrRstWork�C���X�^���X�擾
        /// </summary>
        /// <returns>PmtGeneralSrRstWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PmtGeneralSrRstWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private PmtGeneralSrRstWork GetPmtGeneralSrRstWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            PmtGeneralSrRstWork temp = new PmtGeneralSrRstWork();

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
            //�������_�R�[�h
            temp.SearchSectionCode = reader.ReadString();
            //�Ɩ��Z�b�V����ID
            temp.BusinessSessionId = reader.ReadString();
            //�f�[�^�敪
            temp.LinkDataCode = reader.ReadInt32();
            //PMTAB���׎���GUID
            temp.PmTabDtlDiscGuid = reader.ReadString();
            //PMTAB�����s�ԍ�
            temp.PmTabSearchRowNum = reader.ReadInt32();
            //�f�[�^�폜�\���
            temp.DataDeleteDate = reader.ReadInt32();
            //�̔��]�ƈ��R�[�h
            temp.SalesEmployeeCd = reader.ReadString();
            //�̔��]�ƈ�����
            temp.SalesEmployeeNm = reader.ReadString();
            //��t�]�ƈ��R�[�h
            temp.FrontEmployeeCd = reader.ReadString();
            //��t�]�ƈ�����
            temp.FrontEmployeeNm = reader.ReadString();
            //������͎҃R�[�h
            temp.SalesInputCode = reader.ReadString();
            //������͎Җ���
            temp.SalesInputName = reader.ReadString();


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
        /// <returns>PmtGeneralSrRstWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PmtGeneralSrRstWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PmtGeneralSrRstWork temp = GetPmtGeneralSrRstWork(reader, serInfo);
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
                    retValue = (PmtGeneralSrRstWork[])lst.ToArray(typeof(PmtGeneralSrRstWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}