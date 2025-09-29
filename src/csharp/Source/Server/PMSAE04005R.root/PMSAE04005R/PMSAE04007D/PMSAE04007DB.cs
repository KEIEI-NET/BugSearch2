//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����f�[�^���M���O
// �v���O�����T�v   : ����f�[�^���M���O�f�[�^�p�����[�^
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��������
// �� �� ��  2013.06.26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SAndESalSndLogListResultWork
    /// <summary>
    /// ����f�[�^���M���O���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����f�[�^���M���O���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2013.06.26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SAndESalSndLogListResultWork : IFileHeader
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

        /// <summary>�������M�敪</summary>
        /// <remarks>0:�蓮,1:����</remarks>
        private Int32 _sAndEAutoSendDiv;

        /// <summary>���M�����i�J�n�j</summary>
        /// <remarks>���M�J�n���ԁi200601011212(������t�{�����j</remarks>
        private Int64 _sendDateTimeStart;

        /// <summary>���M�����i�I���j</summary>
        /// <remarks>���M�������ԁi200601011212(������t�{�����j</remarks>
        private Int64 _sendDateTimeEnd;

        /// <summary>���M�Ώۓ��t�i�J�n�j</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _sendObjDateStart;

        /// <summary>���M�Ώۓ��t�i�I���j</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _sendObjDateEnd;

        /// <summary>���M�Ώۓ��Ӑ�i�J�n�j</summary>
        private Int32 _sendObjCustStart;

        /// <summary>���M�Ώۓ��Ӑ�i�I���j</summary>
        private Int32 _sendObjCustEnd;

        /// <summary>���M�Ώۋ敪</summary>
        /// <remarks>0:�S��,1:�����M,2�F���M��</remarks>
        private Int32 _sendObjDiv;

        /// <summary>���M����</summary>
        /// <remarks>0:���튮��,1�F���s</remarks>
        private Int32 _sendResults;

        /// <summary>���M�G���[���e</summary>
        private string _sendErrorContents = "";

        /// <summary>���M�`�[����</summary>
        /// <remarks>���M�����`�[����</remarks>
        private Int32 _sendSlipCount;

        /// <summary>���M�`�[���א�</summary>
        /// <remarks>���M�����`�[���א��\��</remarks>
        private Int32 _sendSlipDtlCnt;

        /// <summary>���M�`�[���v���z</summary>
        /// <remarks>���M�����`�[�̍��v���z</remarks>
        private Int64 _sendSlipTotalMny;

        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬����</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬����</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V����</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V����</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUID</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ��R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID1</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID2</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�_���폜�敪</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  SAndEAutoSendDiv
        /// <summary>�������M�敪</summary>
        /// <value>0:�蓮,1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������M�敪</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SAndEAutoSendDiv
        {
            get { return _sAndEAutoSendDiv; }
            set { _sAndEAutoSendDiv = value; }
        }

        /// public propaty name  :  SendDateTimeStart
        /// <summary>���M�����i�J�n�j</summary>
        /// <value>���M�J�n���ԁi200601011212(������t�{�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�����i�J�n�j</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SendDateTimeStart
        {
            get { return _sendDateTimeStart; }
            set { _sendDateTimeStart = value; }
        }

        /// public propaty name  :  SendDateTimeEnd
        /// <summary>���M�����i�I���j</summary>
        /// <value>���M�������ԁi200601011212(������t�{�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�����i�I���j</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SendDateTimeEnd
        {
            get { return _sendDateTimeEnd; }
            set { _sendDateTimeEnd = value; }
        }

        /// public propaty name  :  SendObjDateStart
        /// <summary>���M�Ώۓ��t�i�J�n�j</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�Ώۓ��t�i�J�n�j</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SendObjDateStart
        {
            get { return _sendObjDateStart; }
            set { _sendObjDateStart = value; }
        }

        /// public propaty name  :  SendObjDateEnd
        /// <summary>���M�Ώۓ��t�i�I���j</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�Ώۓ��t�i�I���j</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SendObjDateEnd
        {
            get { return _sendObjDateEnd; }
            set { _sendObjDateEnd = value; }
        }

        /// public propaty name  :  SendObjCustStart
        /// <summary>���M�Ώۓ��Ӑ�i�J�n�j</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�Ώۓ��Ӑ�i�J�n�j</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SendObjCustStart
        {
            get { return _sendObjCustStart; }
            set { _sendObjCustStart = value; }
        }

        /// public propaty name  :  SendObjCustEnd
        /// <summary>���M�Ώۓ��Ӑ�i�I���j</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�Ώۓ��Ӑ�i�I���j</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SendObjCustEnd
        {
            get { return _sendObjCustEnd; }
            set { _sendObjCustEnd = value; }
        }

        /// public propaty name  :  SendObjDiv
        /// <summary>���M�Ώۋ敪</summary>
        /// <value>0:�S��,1:�����M,2�F���M��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�Ώۋ敪</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SendObjDiv
        {
            get { return _sendObjDiv; }
            set { _sendObjDiv = value; }
        }

        /// public propaty name  :  SendResults
        /// <summary>���M����</summary>
        /// <value>0:���튮��,1�F���s</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M����</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SendResults
        {
            get { return _sendResults; }
            set { _sendResults = value; }
        }

        /// public propaty name  :  SendErrorContents
        /// <summary>���M�G���[���e</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�G���[���e</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SendErrorContents
        {
            get { return _sendErrorContents; }
            set { _sendErrorContents = value; }
        }

        /// public propaty name  :  SendSlipCount
        /// <summary>���M�`�[����</summary>
        /// <value>���M�����`�[����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�`�[����</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SendSlipCount
        {
            get { return _sendSlipCount; }
            set { _sendSlipCount = value; }
        }

        /// public propaty name  :  SendSlipDtlCnt
        /// <summary>���M�`�[���א�</summary>
        /// <value>���M�����`�[���א��\��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�`�[���א�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SendSlipDtlCnt
        {
            get { return _sendSlipDtlCnt; }
            set { _sendSlipDtlCnt = value; }
        }

        /// public propaty name  :  SendSlipTotalMny
        /// <summary>���M�`�[���v���z</summary>
        /// <value>���M�����`�[�̍��v���z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�`�[���v���z</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SendSlipTotalMny
        {
            get { return _sendSlipTotalMny; }
            set { _sendSlipTotalMny = value; }
        }

        /// <summary>
        /// ����f�[�^���M���O���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SAndESalSndLogListResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SAndESalSndLogListResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SAndESalSndLogListResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SAndESalSndLogListResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SAndESalSndLogListResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SAndESalSndLogListResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SAndESalSndLogListResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SAndESalSndLogListResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SAndESalSndLogListResultWork || graph is ArrayList || graph is SAndESalSndLogListResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SAndESalSndLogListResultWork).FullName));

            if (graph != null && graph is SAndESalSndLogListResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SAndESalSndLogListResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SAndESalSndLogListResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SAndESalSndLogListResultWork[])graph).Length;
            }
            else if (graph is SAndESalSndLogListResultWork)
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
            serInfo.MemberInfo.Add(typeof(byte[])); //FileHeaderGuid
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
            //S&E�������M�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndEAutoSendDiv
            //���M�����i�J�n�j
            serInfo.MemberInfo.Add(typeof(Int64)); //SendDateTimeStart
            //���M�����i�I���j
            serInfo.MemberInfo.Add(typeof(Int64)); //SendDateTimeEnd
            //���M�Ώۓ��t�i�J�n�j
            serInfo.MemberInfo.Add(typeof(Int32)); //SendObjDateStart
            //���M�Ώۓ��t�i�I���j
            serInfo.MemberInfo.Add(typeof(Int32)); //SendObjDateEnd
            //���M�Ώۓ��Ӑ�i�J�n�j
            serInfo.MemberInfo.Add(typeof(Int32)); //SendObjCustStart
            //���M�Ώۓ��Ӑ�i�I���j
            serInfo.MemberInfo.Add(typeof(Int32)); //SendObjCustEnd
            //���M�Ώۋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SendObjDiv
            //���M����
            serInfo.MemberInfo.Add(typeof(Int32)); //SendResults
            //���M�G���[���e
            serInfo.MemberInfo.Add(typeof(string)); //SendErrorContents
            //���M�`�[����
            serInfo.MemberInfo.Add(typeof(Int32)); //SendSlipCount
            //���M�`�[���א�
            serInfo.MemberInfo.Add(typeof(Int32)); //SendSlipDtlCnt
            //���M�`�[���v���z
            serInfo.MemberInfo.Add(typeof(Int64)); //SendSlipTotalMny



            serInfo.Serialize(writer, serInfo);
            if (graph is SAndESalSndLogListResultWork)
            {
                SAndESalSndLogListResultWork temp = (SAndESalSndLogListResultWork)graph;

                SetSAndESalSndLogListResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SAndESalSndLogListResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SAndESalSndLogListResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SAndESalSndLogListResultWork temp in lst)
                {
                    SetSAndESalSndLogListResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SAndESalSndLogListResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 22;

        /// <summary>
        ///  SAndESalSndLogListResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SAndESalSndLogListResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSAndESalSndLogListResultWork(System.IO.BinaryWriter writer, SAndESalSndLogListResultWork temp)
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
            writer.Write((Int32)temp.LogicalDeleteCode);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //S&E�������M�敪
            writer.Write((Int32)temp.SAndEAutoSendDiv);
            //���M�����i�J�n�j
            writer.Write((Int64)temp.SendDateTimeStart);
            //���M�����i�I���j
            writer.Write((Int64)temp.SendDateTimeEnd);
            //���M�Ώۓ��t�i�J�n�j
            writer.Write((Int32)temp.SendObjDateStart);
            //���M�Ώۓ��t�i�I���j
            writer.Write((Int32)temp.SendObjDateEnd);
            //���M�Ώۓ��Ӑ�i�J�n�j
            writer.Write((Int32)temp.SendObjCustStart);
            //���M�Ώۓ��Ӑ�i�I���j
            writer.Write((Int32)temp.SendObjCustEnd);
            //���M�Ώۋ敪
            writer.Write((Int32)temp.SendObjDiv);
            //���M����
            writer.Write((Int32)temp.SendResults);
            //���M�G���[���e
            writer.Write(temp.SendErrorContents);
            //���M�`�[����
            writer.Write((Int32)temp.SendSlipCount);
            //���M�`�[���א�
            writer.Write((Int32)temp.SendSlipDtlCnt);
            //���M�`�[���v���z
            writer.Write((Int64)temp.SendSlipTotalMny);


        }

        /// <summary>
        ///  SAndESalSndLogListResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SAndESalSndLogListResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SAndESalSndLogListResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SAndESalSndLogListResultWork GetSAndESalSndLogListResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SAndESalSndLogListResultWork temp = new SAndESalSndLogListResultWork();

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
            //S&E�������M�敪
            temp.SAndEAutoSendDiv = reader.ReadInt32();
            //���M�����i�J�n�j
            temp.SendDateTimeStart = reader.ReadInt64();
            //���M�����i�I���j
            temp.SendDateTimeEnd = reader.ReadInt64();
            //���M�Ώۓ��t�i�J�n�j
            temp.SendObjDateStart = reader.ReadInt32();
            //���M�Ώۓ��t�i�I���j
            temp.SendObjDateEnd = reader.ReadInt32();
            //���M�Ώۓ��Ӑ�i�J�n�j
            temp.SendObjCustStart = reader.ReadInt32();
            //���M�Ώۓ��Ӑ�i�I���j
            temp.SendObjCustEnd = reader.ReadInt32();
            //���M�Ώۋ敪
            temp.SendObjDiv = reader.ReadInt32();
            //���M����
            temp.SendResults = reader.ReadInt32();
            //���M�G���[���e
            temp.SendErrorContents = reader.ReadString();
            //���M�`�[����
            temp.SendSlipCount = reader.ReadInt32();
            //���M�`�[���א�
            temp.SendSlipDtlCnt = reader.ReadInt32();
            //���M�`�[���v���z
            temp.SendSlipTotalMny = reader.ReadInt64();



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
        /// <returns>SAndESalSndLogListResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SAndESalSndLogListResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SAndESalSndLogListResultWork temp = GetSAndESalSndLogListResultWork(reader, serInfo);
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
                    retValue = (SAndESalSndLogListResultWork[])lst.ToArray(typeof(SAndESalSndLogListResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
