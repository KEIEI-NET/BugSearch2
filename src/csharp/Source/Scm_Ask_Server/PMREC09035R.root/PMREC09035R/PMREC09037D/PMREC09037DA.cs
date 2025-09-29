//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���������i�O���[�v�ݒ�}�X�^���o����
// �v���O�����T�v   : ���������i�O���[�v�ݒ�}�X�^���o���ʃf�[�^�p�����[�^
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��������
// �� �� ��  2015/02/23  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RecBgnGrpWork
    /// <summary>
    ///                      ���������i�O���[�v�ݒ�}�X�^���o���ʃ��[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���������i�O���[�v�ݒ�}�X�^���o���ʃ��[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2015/02/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RecBgnGrpWork 
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�⍇������ƃR�[�h</summary>
        private string _inqOriginalEpCd = "";

        /// <summary>�⍇�������_�R�[�h</summary>
        private string _inqOriginalSecCd = "";

        /// <summary>���������i�O���[�v�R�[�h</summary>
        /// <remarks>0:�O���[�v����</remarks>
        private Int16 _brgnGoodsGrpCode;

        /// <summary>�\������</summary>
        private Int32 _displayOrder;

        /// <summary>���������i�O���[�v�^�C�g��</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _brgnGoodsGrpTitle = "";

        /// <summary>���������i�O���[�v�R�����g�^�O</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _brgnGoodsGrpTag = "";

        /// <summary>���������i�O���[�v�R�����g</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _brgnGoodsGrpComment = "";

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

        /// public propaty name  :  BrgnGoodsGrpCode
        /// <summary>���������i�O���[�v�R�[�h</summary>
        /// <value>0:�O���[�v����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������i�O���[�v�R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 BrgnGoodsGrpCode
        {
            get { return _brgnGoodsGrpCode; }
            set { _brgnGoodsGrpCode = value; }
        }

        /// public propaty name  :  DisplayOrder
        /// <summary>�\������</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �\������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }

        /// public propaty name  :  BrgnGoodsGrpTitle
        /// <summary>���������i�O���[�v�^�C�g��</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������i�O���[�v�^�C�g��</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BrgnGoodsGrpTitle
        {
            get { return _brgnGoodsGrpTitle; }
            set { _brgnGoodsGrpTitle = value; }
        }

        /// public propaty name  :  BrgnGoodsGrpTag
        /// <summary>���������i�O���[�v�R�����g�^�O</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������i�O���[�v�R�����g�^�O</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BrgnGoodsGrpTag
        {
            get { return _brgnGoodsGrpTag; }
            set { _brgnGoodsGrpTag = value; }
        }

        /// public propaty name  :  BrgnGoodsGrpComment
        /// <summary>���������i�O���[�v�R�����g</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������i�O���[�v�R�����g</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BrgnGoodsGrpComment
        {
            get { return _brgnGoodsGrpComment; }
            set { _brgnGoodsGrpComment = value; }
        }



        /// <summary>
        /// ���������i�O���[�v�ݒ�}�X�^���o���ʃ��[�N�R���X�g���N�^
        /// </summary>
        /// <returns>RecBgnGrpWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecBgnGrpWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RecBgnGrpWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>RecBgnGrpWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   RecBgnGrpWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class RecBgnGrpWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecBgnGrpWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RecBgnGrpWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RecBgnGrpWork || graph is ArrayList || graph is RecBgnGrpWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(RecBgnGrpWork).FullName));

            if (graph != null && graph is RecBgnGrpWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RecBgnGrpWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RecBgnGrpWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RecBgnGrpWork[])graph).Length;
            }
            else if (graph is RecBgnGrpWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //�⍇������ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalEpCd
            //�⍇�������_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalSecCd
            //���������i�O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int16)); //BrgnGoodsGrpCode
            //�\������
            serInfo.MemberInfo.Add(typeof(Int32)); //DisplayOrder
            //���������i�O���[�v�^�C�g��
            serInfo.MemberInfo.Add(typeof(string)); //BrgnGoodsGrpTitle
            //���������i�O���[�v�R�����g�^�O
            serInfo.MemberInfo.Add(typeof(string)); //BrgnGoodsGrpTag
            //���������i�O���[�v�R�����g
            serInfo.MemberInfo.Add(typeof(string)); //BrgnGoodsGrpComment



            serInfo.Serialize(writer, serInfo);
            if (graph is RecBgnGrpWork)
            {
                RecBgnGrpWork temp = (RecBgnGrpWork)graph;

                SetRecBgnGrpWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RecBgnGrpWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RecBgnGrpWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RecBgnGrpWork temp in lst)
                {
                    SetRecBgnGrpWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RecBgnGrpWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 10;

        /// <summary>
        ///  RecBgnGrpWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecBgnGrpWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetRecBgnGrpWork(System.IO.BinaryWriter writer, RecBgnGrpWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //�_���폜�敪
            writer.Write((Int32)temp.LogicalDeleteCode);
            //�⍇������ƃR�[�h
            writer.Write(temp.InqOriginalEpCd);
            //�⍇�������_�R�[�h
            writer.Write(temp.InqOriginalSecCd);
            //���������i�O���[�v�R�[�h
            writer.Write(temp.BrgnGoodsGrpCode);
            //�\������
            writer.Write((Int32)temp.DisplayOrder);
            //���������i�O���[�v�^�C�g��
            writer.Write(temp.BrgnGoodsGrpTitle);
            //���������i�O���[�v�R�����g�^�O
            writer.Write(temp.BrgnGoodsGrpTag);
            //���������i�O���[�v�R�����g
            writer.Write(temp.BrgnGoodsGrpComment);


        }

        /// <summary>
        ///  RecBgnGrpWork�C���X�^���X�擾
        /// </summary>
        /// <returns>RecBgnGrpWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecBgnGrpWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private RecBgnGrpWork GetRecBgnGrpWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            RecBgnGrpWork temp = new RecBgnGrpWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //�⍇������ƃR�[�h
            temp.InqOriginalEpCd = reader.ReadString();
            //�⍇�������_�R�[�h
            temp.InqOriginalSecCd = reader.ReadString();
            //���������i�O���[�v�R�[�h
            temp.BrgnGoodsGrpCode = reader.ReadInt16();
            //�\������
            temp.DisplayOrder = reader.ReadInt32();
            //���������i�O���[�v�^�C�g��
            temp.BrgnGoodsGrpTitle = reader.ReadString();
            //���������i�O���[�v�R�����g�^�O
            temp.BrgnGoodsGrpTag = reader.ReadString();
            //���������i�O���[�v�R�����g
            temp.BrgnGoodsGrpComment = reader.ReadString();



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
        /// <returns>RecBgnGrpWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecBgnGrpWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RecBgnGrpWork temp = GetRecBgnGrpWork(reader, serInfo);
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
                    retValue = (RecBgnGrpWork[])lst.ToArray(typeof(RecBgnGrpWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
