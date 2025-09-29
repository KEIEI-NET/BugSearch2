//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   ���ʃ}�X�^�f�[�^�p�����[�^
//                  :   PMKHN09056D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008�@�����@���n
// Date             :   2008.06.11
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
    /// public class name:   PartsPosCodeUWork
    /// <summary>
    ///                      ���ʃR�[�h�i���[�U�[�o�^�j���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���ʃR�[�h�i���[�U�[�o�^�j���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/5/28</br>
    /// <br>Genarated Date   :   2009/06/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/9/12  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   ���_�R�[�h</br>
    /// <br>                 :   ���Ӑ�R�[�h</br>
    /// <br>                 :   ���L�[�ύX</br>
    /// <br>                 :   3,9,12 �� 3,9,10,11,14</br>
    /// <br>Update Note      :   2008/9/17  ����</br>
    /// <br>                 :   ���⑫�C��</br>
    /// <br>                 :   �������ʃR�[�h���̂̕⑫���폜</br>
    /// <br>                 :   �\������0�ABL�R�[�h0�̏ꍇ���ʖ��̂��Z�b�g</br>
    /// <br>Update Note      :   2009/5/26  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   �񋟓��t�A�񋟃f�[�^�敪</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PartsPosCodeUWork : IFileHeader
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
        /// <remarks>�����g�p</remarks>
        private string _sectionCode = "";

        /// <summary>���Ӑ�R�[�h</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private Int32 _customerCode;

        /// <summary>�������ʃR�[�h</summary>
        private Int32 _searchPartsPosCode;

        /// <summary>�������ʃR�[�h����</summary>
        /// <remarks>�\������0�ABL�R�[�h0�̏ꍇ���ʖ��̂��Z�b�g</remarks>
        private string _searchPartsPosName = "";

        /// <summary>�������ʕ\������</summary>
        private Int32 _posDispOrder;

        /// <summary>�����i�R�[�h</summary>
        /// <remarks>�O�̏ꍇ�A���ʖ��̗p���R�[�h</remarks>
        private Int32 _tbsPartsCode;

        /// <summary>�����i�R�[�h�}��</summary>
        /// <remarks>�����g�p���ځi���C�A�E�g�ɂ͓���Ă����j</remarks>
        private Int32 _tbsPartsCdDerivedNo;

        /// <summary>�񋟓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _offerDate;

        /// <summary>�񋟃f�[�^�敪</summary>
        /// <remarks>0:���[�U�f�[�^,1:�񋟃f�[�^</remarks>
        private Int32 _offerDataDiv;


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
        /// <value>�����g�p</value>
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

        /// public propaty name  :  SearchPartsPosCode
        /// <summary>�������ʃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������ʃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchPartsPosCode
        {
            get { return _searchPartsPosCode; }
            set { _searchPartsPosCode = value; }
        }

        /// public propaty name  :  SearchPartsPosName
        /// <summary>�������ʃR�[�h���̃v���p�e�B</summary>
        /// <value>�\������0�ABL�R�[�h0�̏ꍇ���ʖ��̂��Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������ʃR�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchPartsPosName
        {
            get { return _searchPartsPosName; }
            set { _searchPartsPosName = value; }
        }

        /// public propaty name  :  PosDispOrder
        /// <summary>�������ʕ\�����ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������ʕ\�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PosDispOrder
        {
            get { return _posDispOrder; }
            set { _posDispOrder = value; }
        }

        /// public propaty name  :  TbsPartsCode
        /// <summary>�����i�R�[�h�v���p�e�B</summary>
        /// <value>�O�̏ꍇ�A���ʖ��̗p���R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }

        /// public propaty name  :  TbsPartsCdDerivedNo
        /// <summary>�����i�R�[�h�}�ԃv���p�e�B</summary>
        /// <value>�����g�p���ځi���C�A�E�g�ɂ͓���Ă����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����i�R�[�h�}�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TbsPartsCdDerivedNo
        {
            get { return _tbsPartsCdDerivedNo; }
            set { _tbsPartsCdDerivedNo = value; }
        }

        /// public propaty name  :  OfferDate
        /// <summary>�񋟓��t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񋟓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }

        /// public propaty name  :  OfferDataDiv
        /// <summary>�񋟃f�[�^�敪�v���p�e�B</summary>
        /// <value>0:���[�U�f�[�^,1:�񋟃f�[�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񋟃f�[�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OfferDataDiv
        {
            get { return _offerDataDiv; }
            set { _offerDataDiv = value; }
        }


        /// <summary>
        /// ���ʃR�[�h�i���[�U�[�o�^�j���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PartsPosCodeUWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsPosCodeUWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PartsPosCodeUWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>PartsPosCodeUWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   PartsPosCodeUWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class PartsPosCodeUWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsPosCodeUWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PartsPosCodeUWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PartsPosCodeUWork || graph is ArrayList || graph is PartsPosCodeUWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PartsPosCodeUWork).FullName));

            if (graph != null && graph is PartsPosCodeUWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PartsPosCodeUWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PartsPosCodeUWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PartsPosCodeUWork[])graph).Length;
            }
            else if (graph is PartsPosCodeUWork)
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
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //�������ʃR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SearchPartsPosCode
            //�������ʃR�[�h����
            serInfo.MemberInfo.Add(typeof(string)); //SearchPartsPosName
            //�������ʕ\������
            serInfo.MemberInfo.Add(typeof(Int32)); //PosDispOrder
            //�����i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode
            //�����i�R�[�h�}��
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCdDerivedNo
            //�񋟓��t
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //�񋟃f�[�^�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDataDiv


            serInfo.Serialize(writer, serInfo);
            if (graph is PartsPosCodeUWork)
            {
                PartsPosCodeUWork temp = (PartsPosCodeUWork)graph;

                SetPartsPosCodeUWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PartsPosCodeUWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PartsPosCodeUWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PartsPosCodeUWork temp in lst)
                {
                    SetPartsPosCodeUWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PartsPosCodeUWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 17;

        /// <summary>
        ///  PartsPosCodeUWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsPosCodeUWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetPartsPosCodeUWork(System.IO.BinaryWriter writer, PartsPosCodeUWork temp)
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
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //�������ʃR�[�h
            writer.Write(temp.SearchPartsPosCode);
            //�������ʃR�[�h����
            writer.Write(temp.SearchPartsPosName);
            //�������ʕ\������
            writer.Write(temp.PosDispOrder);
            //�����i�R�[�h
            writer.Write(temp.TbsPartsCode);
            //�����i�R�[�h�}��
            writer.Write(temp.TbsPartsCdDerivedNo);
            //�񋟓��t
            writer.Write((Int64)temp.OfferDate.Ticks);
            //�񋟃f�[�^�敪
            writer.Write(temp.OfferDataDiv);

        }

        /// <summary>
        ///  PartsPosCodeUWork�C���X�^���X�擾
        /// </summary>
        /// <returns>PartsPosCodeUWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsPosCodeUWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private PartsPosCodeUWork GetPartsPosCodeUWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            PartsPosCodeUWork temp = new PartsPosCodeUWork();

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
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //�������ʃR�[�h
            temp.SearchPartsPosCode = reader.ReadInt32();
            //�������ʃR�[�h����
            temp.SearchPartsPosName = reader.ReadString();
            //�������ʕ\������
            temp.PosDispOrder = reader.ReadInt32();
            //�����i�R�[�h
            temp.TbsPartsCode = reader.ReadInt32();
            //�����i�R�[�h�}��
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();
            //�񋟓��t
            temp.OfferDate = new DateTime(reader.ReadInt64());
            //�񋟃f�[�^�敪
            temp.OfferDataDiv = reader.ReadInt32();


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
        /// <returns>PartsPosCodeUWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsPosCodeUWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PartsPosCodeUWork temp = GetPartsPosCodeUWork(reader, serInfo);
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
                    retValue = (PartsPosCodeUWork[])lst.ToArray(typeof(PartsPosCodeUWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
