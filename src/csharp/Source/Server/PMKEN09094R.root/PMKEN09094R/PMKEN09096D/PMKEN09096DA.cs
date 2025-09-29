//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   ���i��փ}�X�^�f�[�^�p�����[�^
//                  :   PMKEN09096D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008�@���� ���n
// Date             :   2008.06.10
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PartsSubstUWork
    /// <summary>
    ///                      ���i��ցi���[�U�[�o�^���j���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i��ցi���[�U�[�o�^���j���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/28</br>
    /// <br>Genarated Date   :   2008/11/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/10  ����</br>
    /// <br>                 :   ���ڒǉ�</br>
    /// <br>                 :   �K�p�I�����i��폜�̕����j</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PartsSubstUWork : IFileHeader
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

        /// <summary>�ϊ������[�J�[�R�[�h</summary>
        private Int32 _chgSrcMakerCd;

        /// <summary>�ϊ������i�ԍ�</summary>
        private string _chgSrcGoodsNo = "";

        /// <summary>�n�C�t�����ϊ������i�ԍ�</summary>
        private string _chgSrcGoodsNoNoneHp = "";

        /// <summary>�ϊ��惁�[�J�[�R�[�h</summary>
        /// <remarks>���i�}�X�^���i���[�J�[�R�[�h</remarks>
        private Int32 _chgDestMakerCd;

        /// <summary>�ϊ��揤�i�ԍ�</summary>
        /// <remarks>���i�}�X�^���i�ԍ�</remarks>
        private string _chgDestGoodsNo = "";

        /// <summary>�n�C�t�����ϊ��揤�i�ԍ�</summary>
        /// <remarks>�ϊ���n�C�t�������i�ԍ�</remarks>
        private string _chgDestGoodsNoNoneHp = "";

        /// <summary>�K�p�J�n��</summary>
        private DateTime _applyStaDate;

        /// <summary>�K�p�I����</summary>
        private DateTime _applyEndDate;

        /// <summary>�ϊ������i����</summary>
        private string _chgSrcGoodsName = "";

        /// <summary>�ϊ��揤�i����</summary>
        private string _chgDestGoodsName = "";

        /// <summary>�ϊ������[�J�[����</summary>
        private string _chgSrcMakerName = "";

        /// <summary>�ϊ��惁�[�J�[����</summary>
        private string _chgDestMakerName = "";


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

        /// public propaty name  :  ChgSrcMakerCd
        /// <summary>�ϊ������[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϊ������[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ChgSrcMakerCd
        {
            get { return _chgSrcMakerCd; }
            set { _chgSrcMakerCd = value; }
        }

        /// public propaty name  :  ChgSrcGoodsNo
        /// <summary>�ϊ������i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϊ������i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChgSrcGoodsNo
        {
            get { return _chgSrcGoodsNo; }
            set { _chgSrcGoodsNo = value; }
        }

        /// public propaty name  :  ChgSrcGoodsNoNoneHp
        /// <summary>�n�C�t�����ϊ������i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n�C�t�����ϊ������i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChgSrcGoodsNoNoneHp
        {
            get { return _chgSrcGoodsNoNoneHp; }
            set { _chgSrcGoodsNoNoneHp = value; }
        }

        /// public propaty name  :  ChgDestMakerCd
        /// <summary>�ϊ��惁�[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>���i�}�X�^���i���[�J�[�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϊ��惁�[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ChgDestMakerCd
        {
            get { return _chgDestMakerCd; }
            set { _chgDestMakerCd = value; }
        }

        /// public propaty name  :  ChgDestGoodsNo
        /// <summary>�ϊ��揤�i�ԍ��v���p�e�B</summary>
        /// <value>���i�}�X�^���i�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϊ��揤�i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChgDestGoodsNo
        {
            get { return _chgDestGoodsNo; }
            set { _chgDestGoodsNo = value; }
        }

        /// public propaty name  :  ChgDestGoodsNoNoneHp
        /// <summary>�n�C�t�����ϊ��揤�i�ԍ��v���p�e�B</summary>
        /// <value>�ϊ���n�C�t�������i�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n�C�t�����ϊ��揤�i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChgDestGoodsNoNoneHp
        {
            get { return _chgDestGoodsNoNoneHp; }
            set { _chgDestGoodsNoNoneHp = value; }
        }

        /// public propaty name  :  ApplyStaDate
        /// <summary>�K�p�J�n���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ApplyStaDate
        {
            get { return _applyStaDate; }
            set { _applyStaDate = value; }
        }

        /// public propaty name  :  ApplyEndDate
        /// <summary>�K�p�I�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�I�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ApplyEndDate
        {
            get { return _applyEndDate; }
            set { _applyEndDate = value; }
        }

        /// public propaty name  :  ChgSrcGoodsName
        /// <summary>�ϊ������i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϊ������i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChgSrcGoodsName
        {
            get { return _chgSrcGoodsName; }
            set { _chgSrcGoodsName = value; }
        }

        /// public propaty name  :  ChgDestGoodsName
        /// <summary>�ϊ��揤�i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϊ��揤�i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChgDestGoodsName
        {
            get { return _chgDestGoodsName; }
            set { _chgDestGoodsName = value; }
        }

        /// public propaty name  :  ChgSrcMakerName
        /// <summary>�ϊ������[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϊ������[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChgSrcMakerName
        {
            get { return _chgSrcMakerName; }
            set { _chgSrcMakerName = value; }
        }

        /// public propaty name  :  ChgDestMakerName
        /// <summary>�ϊ��惁�[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϊ��惁�[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChgDestMakerName
        {
            get { return _chgDestMakerName; }
            set { _chgDestMakerName = value; }
        }


        /// <summary>
        /// ���i��ցi���[�U�[�o�^���j���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PartsSubstUWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsSubstUWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PartsSubstUWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>PartsSubstUWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   PartsSubstUWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class PartsSubstUWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsSubstUWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PartsSubstUWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PartsSubstUWork || graph is ArrayList || graph is PartsSubstUWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PartsSubstUWork).FullName));

            if (graph != null && graph is PartsSubstUWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PartsSubstUWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PartsSubstUWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PartsSubstUWork[])graph).Length;
            }
            else if (graph is PartsSubstUWork)
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
            //�ϊ������[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ChgSrcMakerCd
            //�ϊ������i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //ChgSrcGoodsNo
            //�n�C�t�����ϊ������i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //ChgSrcGoodsNoNoneHp
            //�ϊ��惁�[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ChgDestMakerCd
            //�ϊ��揤�i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //ChgDestGoodsNo
            //�n�C�t�����ϊ��揤�i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //ChgDestGoodsNoNoneHp
            //�K�p�J�n��
            serInfo.MemberInfo.Add(typeof(Int32)); //ApplyStaDate
            //�K�p�I����
            serInfo.MemberInfo.Add(typeof(Int32)); //ApplyEndDate
            //�ϊ������i����
            serInfo.MemberInfo.Add(typeof(string)); //ChgSrcGoodsName
            //�ϊ��揤�i����
            serInfo.MemberInfo.Add(typeof(string)); //ChgDestGoodsName
            //�ϊ������[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //ChgSrcMakerName
            //�ϊ��惁�[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //ChgDestMakerName


            serInfo.Serialize(writer, serInfo);
            if (graph is PartsSubstUWork)
            {
                PartsSubstUWork temp = (PartsSubstUWork)graph;

                SetPartsSubstUWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PartsSubstUWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PartsSubstUWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PartsSubstUWork temp in lst)
                {
                    SetPartsSubstUWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PartsSubstUWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 20;

        /// <summary>
        ///  PartsSubstUWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsSubstUWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetPartsSubstUWork(System.IO.BinaryWriter writer, PartsSubstUWork temp)
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
            //�ϊ������[�J�[�R�[�h
            writer.Write(temp.ChgSrcMakerCd);
            //�ϊ������i�ԍ�
            writer.Write(temp.ChgSrcGoodsNo);
            //�n�C�t�����ϊ������i�ԍ�
            writer.Write(temp.ChgSrcGoodsNoNoneHp);
            //�ϊ��惁�[�J�[�R�[�h
            writer.Write(temp.ChgDestMakerCd);
            //�ϊ��揤�i�ԍ�
            writer.Write(temp.ChgDestGoodsNo);
            //�n�C�t�����ϊ��揤�i�ԍ�
            writer.Write(temp.ChgDestGoodsNoNoneHp);
            //�K�p�J�n��
            writer.Write((Int64)temp.ApplyStaDate.Ticks);
            //�K�p�I����
            writer.Write((Int64)temp.ApplyEndDate.Ticks);
            //�ϊ������i����
            writer.Write(temp.ChgSrcGoodsName);
            //�ϊ��揤�i����
            writer.Write(temp.ChgDestGoodsName);
            //�ϊ������[�J�[����
            writer.Write(temp.ChgSrcMakerName);
            //�ϊ��惁�[�J�[����
            writer.Write(temp.ChgDestMakerName);

        }

        /// <summary>
        ///  PartsSubstUWork�C���X�^���X�擾
        /// </summary>
        /// <returns>PartsSubstUWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsSubstUWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private PartsSubstUWork GetPartsSubstUWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            PartsSubstUWork temp = new PartsSubstUWork();

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
            //�ϊ������[�J�[�R�[�h
            temp.ChgSrcMakerCd = reader.ReadInt32();
            //�ϊ������i�ԍ�
            temp.ChgSrcGoodsNo = reader.ReadString();
            //�n�C�t�����ϊ������i�ԍ�
            temp.ChgSrcGoodsNoNoneHp = reader.ReadString();
            //�ϊ��惁�[�J�[�R�[�h
            temp.ChgDestMakerCd = reader.ReadInt32();
            //�ϊ��揤�i�ԍ�
            temp.ChgDestGoodsNo = reader.ReadString();
            //�n�C�t�����ϊ��揤�i�ԍ�
            temp.ChgDestGoodsNoNoneHp = reader.ReadString();
            //�K�p�J�n��
            temp.ApplyStaDate = new DateTime(reader.ReadInt64());
            //�K�p�I����
            temp.ApplyEndDate = new DateTime(reader.ReadInt64());
            //�ϊ������i����
            temp.ChgSrcGoodsName = reader.ReadString();
            //�ϊ��揤�i����
            temp.ChgDestGoodsName = reader.ReadString();
            //�ϊ������[�J�[����
            temp.ChgSrcMakerName = reader.ReadString();
            //�ϊ��惁�[�J�[����
            temp.ChgDestMakerName = reader.ReadString();


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
        /// <returns>PartsSubstUWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsSubstUWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PartsSubstUWork temp = GetPartsSubstUWork(reader, serInfo);
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
                    retValue = (PartsSubstUWork[])lst.ToArray(typeof(PartsSubstUWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
