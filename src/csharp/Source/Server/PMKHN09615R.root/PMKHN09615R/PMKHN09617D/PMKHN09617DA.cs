using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CampaignPrcPrStWork
    /// <summary>
    ///                      �L�����y�[�������D��ݒ胏�[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �L�����y�[�������D��ݒ胏�[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011/04/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CampaignPrcPrStWork : IFileHeader
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
        /// <remarks>00�͑S��</remarks>
        private string _sectionCode = "";

        /// <summary>�D��ݒ�R�[�h�P</summary>
        /// <remarks>0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪</remarks>
        private Int32 _prioritySettingCd1;

        /// <summary>�D��ݒ�R�[�h�Q</summary>
        /// <remarks>0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪</remarks>
        private Int32 _prioritySettingCd2;

        /// <summary>�D��ݒ�R�[�h�R</summary>
        /// <remarks>0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪</remarks>
        private Int32 _prioritySettingCd3;

        /// <summary>�D��ݒ�R�[�h�S</summary>
        /// <remarks>0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪</remarks>
        private Int32 _prioritySettingCd4;

        /// <summary>�D��ݒ�R�[�h�T</summary>
        /// <remarks>0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪</remarks>
        private Int32 _prioritySettingCd5;

        /// <summary>�D��ݒ�R�[�h�U</summary>
        /// <remarks>0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪</remarks>
        private Int32 _prioritySettingCd6;


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
        /// <value>00�͑S��</value>
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

        /// public propaty name  :  PrioritySettingCd1
        /// <summary>�D��ݒ�R�[�h�P�v���p�e�B</summary>
        /// <value>0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ�R�[�h�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrioritySettingCd1
        {
            get { return _prioritySettingCd1; }
            set { _prioritySettingCd1 = value; }
        }

        /// public propaty name  :  PrioritySettingCd2
        /// <summary>�D��ݒ�R�[�h�Q�v���p�e�B</summary>
        /// <value>0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ�R�[�h�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrioritySettingCd2
        {
            get { return _prioritySettingCd2; }
            set { _prioritySettingCd2 = value; }
        }

        /// public propaty name  :  PrioritySettingCd3
        /// <summary>�D��ݒ�R�[�h�R�v���p�e�B</summary>
        /// <value>0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ�R�[�h�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrioritySettingCd3
        {
            get { return _prioritySettingCd3; }
            set { _prioritySettingCd3 = value; }
        }

        /// public propaty name  :  PrioritySettingCd4
        /// <summary>�D��ݒ�R�[�h�S�v���p�e�B</summary>
        /// <value>0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ�R�[�h�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrioritySettingCd4
        {
            get { return _prioritySettingCd4; }
            set { _prioritySettingCd4 = value; }
        }

        /// public propaty name  :  PrioritySettingCd5
        /// <summary>�D��ݒ�R�[�h�T�v���p�e�B</summary>
        /// <value>0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ�R�[�h�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrioritySettingCd5
        {
            get { return _prioritySettingCd5; }
            set { _prioritySettingCd5 = value; }
        }

        /// public propaty name  :  PrioritySettingCd6
        /// <summary>�D��ݒ�R�[�h�U�v���p�e�B</summary>
        /// <value>0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ�R�[�h�U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrioritySettingCd6
        {
            get { return _prioritySettingCd6; }
            set { _prioritySettingCd6 = value; }
        }


        /// <summary>
        /// �L�����y�[�������D��ݒ胏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CampaignPrcPrStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignPrcPrStWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CampaignPrcPrStWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>CampaignPrcPrStWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   CampaignPrcPrStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class CampaignPrcPrStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignPrcPrStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CampaignPrcPrStWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CampaignPrcPrStWork || graph is ArrayList || graph is CampaignPrcPrStWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(CampaignPrcPrStWork).FullName));

            if (graph != null && graph is CampaignPrcPrStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CampaignPrcPrStWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CampaignPrcPrStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CampaignPrcPrStWork[])graph).Length;
            }
            else if (graph is CampaignPrcPrStWork)
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
            //�D��ݒ�R�[�h�P
            serInfo.MemberInfo.Add(typeof(Int32)); //PrioritySettingCd1
            //�D��ݒ�R�[�h�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //PrioritySettingCd2
            //�D��ݒ�R�[�h�R
            serInfo.MemberInfo.Add(typeof(Int32)); //PrioritySettingCd3
            //�D��ݒ�R�[�h�S
            serInfo.MemberInfo.Add(typeof(Int32)); //PrioritySettingCd4
            //�D��ݒ�R�[�h�T
            serInfo.MemberInfo.Add(typeof(Int32)); //PrioritySettingCd5
            //�D��ݒ�R�[�h�U
            serInfo.MemberInfo.Add(typeof(Int32)); //PrioritySettingCd6


            serInfo.Serialize(writer, serInfo);
            if (graph is CampaignPrcPrStWork)
            {
                CampaignPrcPrStWork temp = (CampaignPrcPrStWork)graph;

                SetCampaignPrcPrStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CampaignPrcPrStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CampaignPrcPrStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CampaignPrcPrStWork temp in lst)
                {
                    SetCampaignPrcPrStWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CampaignPrcPrStWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 15;

        /// <summary>
        ///  CampaignPrcPrStWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignPrcPrStWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetCampaignPrcPrStWork(System.IO.BinaryWriter writer, CampaignPrcPrStWork temp)
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
            //�D��ݒ�R�[�h�P
            writer.Write(temp.PrioritySettingCd1);
            //�D��ݒ�R�[�h�Q
            writer.Write(temp.PrioritySettingCd2);
            //�D��ݒ�R�[�h�R
            writer.Write(temp.PrioritySettingCd3);
            //�D��ݒ�R�[�h�S
            writer.Write(temp.PrioritySettingCd4);
            //�D��ݒ�R�[�h�T
            writer.Write(temp.PrioritySettingCd5);
            //�D��ݒ�R�[�h�U
            writer.Write(temp.PrioritySettingCd6);

        }

        /// <summary>
        ///  CampaignPrcPrStWork�C���X�^���X�擾
        /// </summary>
        /// <returns>CampaignPrcPrStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignPrcPrStWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private CampaignPrcPrStWork GetCampaignPrcPrStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            CampaignPrcPrStWork temp = new CampaignPrcPrStWork();

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
            //�D��ݒ�R�[�h�P
            temp.PrioritySettingCd1 = reader.ReadInt32();
            //�D��ݒ�R�[�h�Q
            temp.PrioritySettingCd2 = reader.ReadInt32();
            //�D��ݒ�R�[�h�R
            temp.PrioritySettingCd3 = reader.ReadInt32();
            //�D��ݒ�R�[�h�S
            temp.PrioritySettingCd4 = reader.ReadInt32();
            //�D��ݒ�R�[�h�T
            temp.PrioritySettingCd5 = reader.ReadInt32();
            //�D��ݒ�R�[�h�U
            temp.PrioritySettingCd6 = reader.ReadInt32();


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
        /// <returns>CampaignPrcPrStWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignPrcPrStWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CampaignPrcPrStWork temp = GetCampaignPrcPrStWork(reader, serInfo);
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
                    retValue = (CampaignPrcPrStWork[])lst.ToArray(typeof(CampaignPrcPrStWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
