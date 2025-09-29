//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   TBO�����}�X�^(���[�U�[�o�^)�f�[�^�p�����[�^
//                  :   PMKEN09116D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 ���� ���n
// Date             :   2008.11.17
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
    /// public class name:   TBOSearchUWork
    /// <summary>
    ///                      TBO�����i���[�U�[�o�^�j���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   TBO�����i���[�U�[�o�^�j���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2006/12/6</br>
    /// <br>Genarated Date   :   2008/11/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/4/25  ����</br>
    /// <br>                 :   ���Ł�PM.NS�Ή�</br>
    /// <br>Update Note      :   2008/10/17  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   BL���i�R�[�h</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TBOSearchUWork : IFileHeader
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

        /// <summary>BL���i�R�[�h</summary>
        /// <remarks>��:1�`9999 ���[�U�[:10000�`</remarks>
        private Int32 _bLGoodsCode;

        /// <summary>��������</summary>
        /// <remarks>��j1001�F�o�b�e��</remarks>
        private Int32 _equipGenreCode;

        /// <summary>��������</summary>
        /// <remarks>��j100D26L�i�o�b�e���K�i�j</remarks>
        private string _equipName = "";

        /// <summary>�ԗ������\������</summary>
        /// <remarks>4,5,6,7,8������̌������������݂���ꍇ�̘A��</remarks>
        private Int32 _carInfoJoinDispOrder;

        /// <summary>�����惁�[�J�[�R�[�h</summary>
        private Int32 _joinDestMakerCd;

        /// <summary>������i��(�|�t���i��)</summary>
        /// <remarks>�n�C�t���t��</remarks>
        private string _joinDestPartsNo = "";

        /// <summary>�����p�s�x</summary>
        private Double _joinQty;

        /// <summary>�����K�i�E���L����</summary>
        private string _equipSpecialNote = "";

        /// <summary>�����惁�[�J�[����</summary>
        private string _joinDestMakerName = "";

        /// <summary>������i��</summary>
        private string _joinDestGoodsName = "";


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

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
        /// <value>��:1�`9999 ���[�U�[:10000�`</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  EquipGenreCode
        /// <summary>�������ރv���p�e�B</summary>
        /// <value>��j1001�F�o�b�e��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EquipGenreCode
        {
            get { return _equipGenreCode; }
            set { _equipGenreCode = value; }
        }

        /// public propaty name  :  EquipName
        /// <summary>�������̃v���p�e�B</summary>
        /// <value>��j100D26L�i�o�b�e���K�i�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EquipName
        {
            get { return _equipName; }
            set { _equipName = value; }
        }

        /// public propaty name  :  CarInfoJoinDispOrder
        /// <summary>�ԗ������\�����ʃv���p�e�B</summary>
        /// <value>4,5,6,7,8������̌������������݂���ꍇ�̘A��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ������\�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarInfoJoinDispOrder
        {
            get { return _carInfoJoinDispOrder; }
            set { _carInfoJoinDispOrder = value; }
        }

        /// public propaty name  :  JoinDestMakerCd
        /// <summary>�����惁�[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����惁�[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 JoinDestMakerCd
        {
            get { return _joinDestMakerCd; }
            set { _joinDestMakerCd = value; }
        }

        /// public propaty name  :  JoinDestPartsNo
        /// <summary>������i��(�|�t���i��)�v���p�e�B</summary>
        /// <value>�n�C�t���t��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������i��(�|�t���i��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string JoinDestPartsNo
        {
            get { return _joinDestPartsNo; }
            set { _joinDestPartsNo = value; }
        }

        /// public propaty name  :  JoinQty
        /// <summary>�����p�s�x�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����p�s�x�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double JoinQty
        {
            get { return _joinQty; }
            set { _joinQty = value; }
        }

        /// public propaty name  :  EquipSpecialNote
        /// <summary>�����K�i�E���L�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����K�i�E���L�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EquipSpecialNote
        {
            get { return _equipSpecialNote; }
            set { _equipSpecialNote = value; }
        }

        /// public propaty name  :  JoinDestMakerName
        /// <summary>�����惁�[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����惁�[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string JoinDestMakerName
        {
            get { return _joinDestMakerName; }
            set { _joinDestMakerName = value; }
        }

        /// public propaty name  :  JoinDestGoodsName
        /// <summary>������i���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������i���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string JoinDestGoodsName
        {
            get { return _joinDestGoodsName; }
            set { _joinDestGoodsName = value; }
        }


        /// <summary>
        /// TBO�����i���[�U�[�o�^�j���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>TBOSearchUWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBOSearchUWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public TBOSearchUWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>TBOSearchUWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   TBOSearchUWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class TBOSearchUWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBOSearchUWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  TBOSearchUWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is TBOSearchUWork || graph is ArrayList || graph is TBOSearchUWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(TBOSearchUWork).FullName));

            if (graph != null && graph is TBOSearchUWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.TBOSearchUWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is TBOSearchUWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((TBOSearchUWork[])graph).Length;
            }
            else if (graph is TBOSearchUWork)
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
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //��������
            serInfo.MemberInfo.Add(typeof(Int32)); //EquipGenreCode
            //��������
            serInfo.MemberInfo.Add(typeof(string)); //EquipName
            //�ԗ������\������
            serInfo.MemberInfo.Add(typeof(Int32)); //CarInfoJoinDispOrder
            //�����惁�[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //JoinDestMakerCd
            //������i��(�|�t���i��)
            serInfo.MemberInfo.Add(typeof(string)); //JoinDestPartsNo
            //�����p�s�x
            serInfo.MemberInfo.Add(typeof(Double)); //JoinQty
            //�����K�i�E���L����
            serInfo.MemberInfo.Add(typeof(string)); //EquipSpecialNote
            //�����惁�[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //JoinDestMakerName
            //������i��
            serInfo.MemberInfo.Add(typeof(string)); //JoinDestGoodsName


            serInfo.Serialize(writer, serInfo);
            if (graph is TBOSearchUWork)
            {
                TBOSearchUWork temp = (TBOSearchUWork)graph;

                SetTBOSearchUWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is TBOSearchUWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((TBOSearchUWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (TBOSearchUWork temp in lst)
                {
                    SetTBOSearchUWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// TBOSearchUWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 18;

        /// <summary>
        ///  TBOSearchUWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBOSearchUWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetTBOSearchUWork(System.IO.BinaryWriter writer, TBOSearchUWork temp)
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
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //��������
            writer.Write(temp.EquipGenreCode);
            //��������
            writer.Write(temp.EquipName);
            //�ԗ������\������
            writer.Write(temp.CarInfoJoinDispOrder);
            //�����惁�[�J�[�R�[�h
            writer.Write(temp.JoinDestMakerCd);
            //������i��(�|�t���i��)
            writer.Write(temp.JoinDestPartsNo);
            //�����p�s�x
            writer.Write(temp.JoinQty);
            //�����K�i�E���L����
            writer.Write(temp.EquipSpecialNote);
            //�����惁�[�J�[����
            writer.Write(temp.JoinDestMakerName);
            //������i��
            writer.Write(temp.JoinDestGoodsName);

        }

        /// <summary>
        ///  TBOSearchUWork�C���X�^���X�擾
        /// </summary>
        /// <returns>TBOSearchUWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBOSearchUWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private TBOSearchUWork GetTBOSearchUWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            TBOSearchUWork temp = new TBOSearchUWork();

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
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //��������
            temp.EquipGenreCode = reader.ReadInt32();
            //��������
            temp.EquipName = reader.ReadString();
            //�ԗ������\������
            temp.CarInfoJoinDispOrder = reader.ReadInt32();
            //�����惁�[�J�[�R�[�h
            temp.JoinDestMakerCd = reader.ReadInt32();
            //������i��(�|�t���i��)
            temp.JoinDestPartsNo = reader.ReadString();
            //�����p�s�x
            temp.JoinQty = reader.ReadDouble();
            //�����K�i�E���L����
            temp.EquipSpecialNote = reader.ReadString();
            //�����惁�[�J�[����
            temp.JoinDestMakerName = reader.ReadString();
            //������i��
            temp.JoinDestGoodsName = reader.ReadString();


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
        /// <returns>TBOSearchUWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBOSearchUWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                TBOSearchUWork temp = GetTBOSearchUWork(reader, serInfo);
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
                    retValue = (TBOSearchUWork[])lst.ToArray(typeof(TBOSearchUWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
