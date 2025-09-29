//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R�����h���i�֘A�ݒ�}�X�^�����e���o���ʃ��[�N
// �v���O�����T�v   : ���R�����h���i�֘A�ݒ�}�X�^�����e���o���ʃ��[�N�f�[�^�p�����[�^
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��������
// �� �� ��  2015.01.16  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RecGoodsLkWork
    /// <summary>
    ///                      ���R�����h���i�֘A�ݒ胏�[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���R�����h���i�֘A�ݒ胏�[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2015/1/9</br>
    /// <br>Genarated Date   :   2015/01/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RecGoodsLkWork
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

        /// <summary>�⍇�����ƃR�[�h</summary>
        private string _inqOtherEpCd = "";

        /// <summary>�⍇���拒�_�R�[�h</summary>
        private string _inqOtherSecCd = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>������BL���i�R�[�h</summary>
        private Int32 _recSourceBLGoodsCd;

        /// <summary>������BL���i�R�[�h</summary>
        private Int32 _recDestBLGoodsCd;

        /// <summary>������BL���i����</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _recDestBLGoodsNm = "";

        /// <summary>���i�R�����g</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _goodsComment = "";
        
        //�����p�Ƃ��Ēǉ� >>>>>
        /// <summary>������BL���i�R�[�h(�J�n)</summary>
        private Int32 _recSourceBLGoodsCdSt;
        private Int32 _recSourceBLGoodsCdEd;
        //�����p�Ƃ��Ēǉ� <<<<<

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

        /// public propaty name  :  InqOriginalEpCd
        /// <summary>�⍇������ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇������ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalEpCd
        {
            get { return _inqOriginalEpCd; }
            set { _inqOriginalEpCd = value; }
        }

        /// public propaty name  :  InqOriginalSecCd
        /// <summary>�⍇�������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalSecCd
        {
            get { return _inqOriginalSecCd; }
            set { _inqOriginalSecCd = value; }
        }

        /// public propaty name  :  InqOtherEpCd
        /// <summary>�⍇�����ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�����ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOtherEpCd
        {
            get { return _inqOtherEpCd; }
            set { _inqOtherEpCd = value; }
        }

        /// public propaty name  :  InqOtherSecCd
        /// <summary>�⍇���拒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���拒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOtherSecCd
        {
            get { return _inqOtherSecCd; }
            set { _inqOtherSecCd = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  RecSourceBLGoodsCd
        /// <summary>������BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RecSourceBLGoodsCd
        {
            get { return _recSourceBLGoodsCd; }
            set { _recSourceBLGoodsCd = value; }
        }

        /// public propaty name  :  RecDestBLGoodsCd
        /// <summary>������BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RecDestBLGoodsCd
        {
            get { return _recDestBLGoodsCd; }
            set { _recDestBLGoodsCd = value; }
        }

        /// public propaty name  :  RecDestBLGoodsNm
        /// <summary>������BL���i���̃v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������BL���i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RecDestBLGoodsNm
        {
            get { return _recDestBLGoodsNm; }
            set { _recDestBLGoodsNm = value; }
        }

        /// public propaty name  :  GoodsComment
        /// <summary>���i�R�����g�v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�R�����g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsComment
        {
            get { return _goodsComment; }
            set { _goodsComment = value; }
        }

        //�����p�Ƃ��Ēǉ� >>>>>
        /// public propaty name  :  RecSourceBLGoodsCdSt
        /// <summary>������BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RecSourceBLGoodsCdSt
        {
            get { return _recSourceBLGoodsCdSt; }
            set { _recSourceBLGoodsCdSt = value; }
        }

        /// public propaty name  :  RecSourceBLGoodsCdEd
        /// <summary>������BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RecSourceBLGoodsCdEd
        {
            get { return _recSourceBLGoodsCdEd; }
            set { _recSourceBLGoodsCdEd = value; }
        }
        //�����p�Ƃ��Ēǉ� <<<<<

        /// <summary>
        /// ���R�����h���i�֘A�ݒ胏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>RecGoodsLkWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecGoodsLkWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RecGoodsLkWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>RecGoodsLkWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   RecGoodsLkWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class RecGoodsLkWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecGoodsLkWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RecGoodsLkWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RecGoodsLkWork || graph is ArrayList || graph is RecGoodsLkWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(RecGoodsLkWork).FullName));

            if (graph != null && graph is RecGoodsLkWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RecGoodsLkWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RecGoodsLkWork[])graph).Length;
            }
            else if (graph is RecGoodsLkWork)
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
            //�⍇�����ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
            //�⍇���拒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //������BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //RecSourceBLGoodsCd
            //������BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //RecDestBLGoodsCd
            //������BL���i����
            serInfo.MemberInfo.Add(typeof(string)); //RecDestBLGoodsNm
            //���i�R�����g
            serInfo.MemberInfo.Add(typeof(string)); //GoodsComment


            serInfo.Serialize(writer, serInfo);
            if (graph is RecGoodsLkWork)
            {
                RecGoodsLkWork temp = (RecGoodsLkWork)graph;

                SetRecGoodsLkWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RecGoodsLkWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RecGoodsLkWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RecGoodsLkWork temp in lst)
                {
                    SetRecGoodsLkWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RecGoodsLkWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 12;

        /// <summary>
        ///  RecGoodsLkWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecGoodsLkWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetRecGoodsLkWork(System.IO.BinaryWriter writer, RecGoodsLkWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //�⍇������ƃR�[�h
            writer.Write(temp.InqOriginalEpCd);
            //�⍇�������_�R�[�h
            writer.Write(temp.InqOriginalSecCd);
            //�⍇�����ƃR�[�h
            writer.Write(temp.InqOtherEpCd);
            //�⍇���拒�_�R�[�h
            writer.Write(temp.InqOtherSecCd);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //������BL���i�R�[�h
            writer.Write(temp.RecSourceBLGoodsCd);
            //������BL���i�R�[�h
            writer.Write(temp.RecDestBLGoodsCd);
            //������BL���i����
            writer.Write(temp.RecDestBLGoodsNm);
            //���i�R�����g
            writer.Write(temp.GoodsComment);

        }

        /// <summary>
        ///  RecGoodsLkWork�C���X�^���X�擾
        /// </summary>
        /// <returns>RecGoodsLkWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecGoodsLkWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private RecGoodsLkWork GetRecGoodsLkWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            RecGoodsLkWork temp = new RecGoodsLkWork();

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
            //�⍇�����ƃR�[�h
            temp.InqOtherEpCd = reader.ReadString();
            //�⍇���拒�_�R�[�h
            temp.InqOtherSecCd = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //������BL���i�R�[�h
            temp.RecSourceBLGoodsCd = reader.ReadInt32();
            //������BL���i�R�[�h
            temp.RecDestBLGoodsCd = reader.ReadInt32();
            //������BL���i����
            temp.RecDestBLGoodsNm = reader.ReadString();
            //���i�R�����g
            temp.GoodsComment = reader.ReadString();


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
        /// <returns>RecGoodsLkWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecGoodsLkWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RecGoodsLkWork temp = GetRecGoodsLkWork(reader, serInfo);
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
                    retValue = (RecGoodsLkWork[])lst.ToArray(typeof(RecGoodsLkWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
