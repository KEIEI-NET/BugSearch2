//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PCC�i�ڐݒ�}�X�^�����e������o���ʃ��[�N
// �v���O�����T�v   : PCC�i�ڐݒ�}�X�^�����e������o���ʃ��[�N�f�[�^�p�����[�^
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��������
// �� �� ��  2011.07.20  �C�����e : �V�K�쐬
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
    /// public class name:   PccItemStWork
    /// <summary>
    ///                      PCC�i�ڐݒ�}�X�^�����e������o���ʃ��[�N���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   PCC�i�ڐݒ�}�X�^�����e������o���ʃ��[�N���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011.07.20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PccItemStWork : IFileHeader
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

        /// <summary>�⍇������ƃR�[�h</summary>
        private string _inqOriginalEpCd = "";

        /// <summary>�⍇�������_�R�[�h</summary>
        private string _inqOriginalSecCd = "";

        /// <summary>�⍇�����ƃR�[�h</summary>
        private string _inqOtherEpCd = "";

        /// <summary>�⍇���拒�_�R�[�h</summary>
        private string _inqOtherSecCd = "";

        /// <summary>PCC���ЃR�[�h</summary>
        /// <remarks>PM�̓��Ӑ�R�[�h</remarks>
        private Int32 _pccCompanyCode;

        /// <summary>�i�ڃO���[�v�R�[�h</summary>
        /// <remarks>1�`5�̎g�p��z��</remarks>
        private Int32 _itemGroupCode;

        /// <summary>�i�ڕ\���ʒu1</summary>
        /// <remarks>��(X)�����̈ʒu 0�`Z</remarks>
        private Int32 _itemDspPos1;

        /// <summary>�i�ڕ\���ʒu2</summary>
        /// <remarks>�c(Y)�����̈ʒu 0�`</remarks>
        private Int32 _itemDspPos2;

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>�i��QTY</summary>
        private Int32 _itemQty;

        /// <summary>�i�ڑI���敪</summary>
        /// <remarks>0:OFF 1:�I����޳�\��</remarks>
        private Int32 _itemSelectDiv;

        /// <summary>�X�V�敪</summary>
        /// <remarks>0:�V�K 1:�X�V 2:�폜</remarks>
        private Int32 _updateFlag;

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

        /// public propaty name  :  InqOriginalEpCd
        /// <summary>�⍇������ƃR�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇������ƃR�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalEpCd
        {
            get { return _inqOriginalEpCd; }
            set { _inqOriginalEpCd = value; }
        }

        /// public propaty name  :  InqOriginalSecCd
        /// <summary>�⍇�������_�R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�������_�R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalSecCd
        {
            get { return _inqOriginalSecCd; }
            set { _inqOriginalSecCd = value; }
        }

        /// public propaty name  :  InqOtherEpCd
        /// <summary>�⍇�����ƃR�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�����ƃR�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOtherEpCd
        {
            get { return _inqOtherEpCd; }
            set { _inqOtherEpCd = value; }
        }

        /// public propaty name  :  InqOtherSecCd
        /// <summary>�⍇���拒�_�R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���拒�_�R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOtherSecCd
        {
            get { return _inqOtherSecCd; }
            set { _inqOtherSecCd = value; }
        }

        /// public propaty name  :  PccCompanyCode
        /// <summary>PCC���ЃR�[�h</summary>
        /// <value>PM�̓��Ӑ�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC���ЃR�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PccCompanyCode
        {
            get { return _pccCompanyCode; }
            set { _pccCompanyCode = value; }
        }

        /// public propaty name  :  ItemGroupCode
        /// <summary>�i�ڃO���[�v�R�[�h</summary>
        /// <value>1�`5�̎g�p��z��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڃO���[�v�R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ItemGroupCode
        {
            get { return _itemGroupCode; }
            set { _itemGroupCode = value; }
        }

        /// public propaty name  :  ItemDspPos1
        /// <summary>�i�ڕ\���ʒu1</summary>
        /// <value>��(X)�����̈ʒu 0�`Z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڕ\���ʒu1</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ItemDspPos1
        {
            get { return _itemDspPos1; }
            set { _itemDspPos1 = value; }
        }

        /// public propaty name  :  ItemDspPos2
        /// <summary>�i�ڕ\���ʒu2</summary>
        /// <value>�c(Y)�����̈ʒu 0�`</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڕ\���ʒu2</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ItemDspPos2
        {
            get { return _itemDspPos2; }
            set { _itemDspPos2 = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL���i�R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  ItemQty
        /// <summary>�i��QTY</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i��QTY</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ItemQty
        {
            get { return _itemQty; }
            set { _itemQty = value; }
        }

        /// public propaty name  :  ItemSelectDiv
        /// <summary>�i�ڑI���敪</summary>
        /// <value>0:OFF 1:�I����޳�\��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڑI���敪</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ItemSelectDiv
        {
            get { return _itemSelectDiv; }
            set { _itemSelectDiv = value; }
        }

        /// public propaty name  :  UpdateFlag
        /// <summary>�X�V�敪</summary>
        /// <value>0:�V�K 1:�X�V 2:�폜</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�敪</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UpdateFlag
        {
            get { return _updateFlag; }
            set { _updateFlag = value; }
        }



        /// <summary>
        /// PCC�i�ڐݒ�}�X�^�����e������o���ʃ��[�N���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PccItemStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccItemStWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PccItemStWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>PccItemStWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   PccItemStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class PccItemStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccItemStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PccItemStWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PccItemStWork || graph is ArrayList || graph is PccItemStWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PccItemStWork).FullName));

            if (graph != null && graph is PccItemStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PccItemStWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PccItemStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PccItemStWork[])graph).Length;
            }
            else if (graph is PccItemStWork)
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
            //�⍇������ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalEpCd
            //�⍇�������_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalSecCd
            //�⍇�����ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
            //�⍇���拒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
            //PCC���ЃR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PccCompanyCode
            //�i�ڃO���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ItemGroupCode
            //�i�ڕ\���ʒu1
            serInfo.MemberInfo.Add(typeof(Int32)); //ItemDspPos1
            //�i�ڕ\���ʒu2
            serInfo.MemberInfo.Add(typeof(Int32)); //ItemDspPos2
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //�i��QTY
            serInfo.MemberInfo.Add(typeof(Int32)); //ItemQty
            //�i�ڑI���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ItemSelectDiv
            //�X�V�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateFlag



            serInfo.Serialize(writer, serInfo);
            if (graph is PccItemStWork)
            {
                PccItemStWork temp = (PccItemStWork)graph;

                SetPccItemStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PccItemStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PccItemStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PccItemStWork temp in lst)
                {
                    SetPccItemStWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PccItemStWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 20;

        /// <summary>
        ///  PccItemStWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccItemStWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetPccItemStWork(System.IO.BinaryWriter writer, PccItemStWork temp)
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
            //�⍇������ƃR�[�h
            writer.Write(temp.InqOriginalEpCd.Trim());	//@@@@20230303
            //�⍇�������_�R�[�h
            writer.Write(temp.InqOriginalSecCd);
            //�⍇�����ƃR�[�h
            writer.Write(temp.InqOtherEpCd);
            //�⍇���拒�_�R�[�h
            writer.Write(temp.InqOtherSecCd);
            //PCC���ЃR�[�h
            writer.Write((Int32)temp.PccCompanyCode);
            //�i�ڃO���[�v�R�[�h
            writer.Write((Int32)temp.ItemGroupCode);
            //�i�ڕ\���ʒu1
            writer.Write((Int32)temp.ItemDspPos1);
            //�i�ڕ\���ʒu2
            writer.Write((Int32)temp.ItemDspPos2);
            //BL���i�R�[�h
            writer.Write((Int32)temp.BLGoodsCode);
            //�i��QTY
            writer.Write((Int32)temp.ItemQty);
            //�i�ڑI���敪
            writer.Write((Int32)temp.ItemSelectDiv);
            //�X�V�敪
            writer.Write((Int32)temp.UpdateFlag);


        }

        /// <summary>
        ///  PccItemStWork�C���X�^���X�擾
        /// </summary>
        /// <returns>PccItemStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccItemStWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private PccItemStWork GetPccItemStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            PccItemStWork temp = new PccItemStWork();

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
            //�⍇������ƃR�[�h
            temp.InqOriginalEpCd = reader.ReadString().Trim();//@@@@20230303
            //�⍇�������_�R�[�h
            temp.InqOriginalSecCd = reader.ReadString();
            //�⍇�����ƃR�[�h
            temp.InqOtherEpCd = reader.ReadString();
            //�⍇���拒�_�R�[�h
            temp.InqOtherSecCd = reader.ReadString();
            //PCC���ЃR�[�h
            temp.PccCompanyCode = reader.ReadInt32();
            //�i�ڃO���[�v�R�[�h
            temp.ItemGroupCode = reader.ReadInt32();
            //�i�ڕ\���ʒu1
            temp.ItemDspPos1 = reader.ReadInt32();
            //�i�ڕ\���ʒu2
            temp.ItemDspPos2 = reader.ReadInt32();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //�i��QTY
            temp.ItemQty = reader.ReadInt32();
            //�i�ڑI���敪
            temp.ItemSelectDiv = reader.ReadInt32();
            //�X�V�敪
            temp.UpdateFlag = reader.ReadInt32();



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
        /// <returns>PccItemStWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccItemStWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PccItemStWork temp = GetPccItemStWork(reader, serInfo);
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
                    retValue = (PccItemStWork[])lst.ToArray(typeof(PccItemStWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
