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
    /// public class name:   RecGoodsLkOWork
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
    public class RecGoodsLkOWork
    {
        /// <summary>�񋟓��t</summary>
        private Int32 _offerDate;

        /// <summary>������BL���i�R�[�h</summary>
        private Int32 _recSourceBLGoodsCd;

        /// <summary>������BL���i�R�[�h</summary>
        private Int32 _recDestBLGoodsCd;

        /// <summary>���i�R�����g</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _goodsComment = "";


        /// public propaty name  :  OfferDate
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
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

        /// <summary>
        /// ���R�����h���i�֘A�ݒ胏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>RecGoodsLkOWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecGoodsLkOWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RecGoodsLkOWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>RecGoodsLkOWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   RecGoodsLkOWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class RecGoodsLkOWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecGoodsLkOWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RecGoodsLkOWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RecGoodsLkOWork || graph is ArrayList || graph is RecGoodsLkOWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(RecGoodsLkOWork).FullName));

            if (graph != null && graph is RecGoodsLkOWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkOWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RecGoodsLkOWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RecGoodsLkOWork[])graph).Length;
            }
            else if (graph is RecGoodsLkOWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�񋟓��t
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //������BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //RecSourceBLGoodsCd
            //������BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //RecDestBLGoodsCd
            //���i�R�����g
            serInfo.MemberInfo.Add(typeof(string)); //GoodsComment


            serInfo.Serialize(writer, serInfo);
            if (graph is RecGoodsLkOWork)
            {
                RecGoodsLkOWork temp = (RecGoodsLkOWork)graph;

                SetRecGoodsLkOWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RecGoodsLkOWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RecGoodsLkOWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RecGoodsLkOWork temp in lst)
                {
                    SetRecGoodsLkOWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RecGoodsLkOWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 4;

        /// <summary>
        ///  RecGoodsLkOWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecGoodsLkOWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetRecGoodsLkOWork(System.IO.BinaryWriter writer, RecGoodsLkOWork temp)
        {
            //�񋟓��t
            writer.Write(temp.OfferDate);
            //������BL���i�R�[�h
            writer.Write(temp.RecSourceBLGoodsCd);
            //������BL���i�R�[�h
            writer.Write(temp.RecDestBLGoodsCd);
            //���i�R�����g
            writer.Write(temp.GoodsComment);

        }

        /// <summary>
        ///  RecGoodsLkOWork�C���X�^���X�擾
        /// </summary>
        /// <returns>RecGoodsLkOWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecGoodsLkOWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private RecGoodsLkOWork GetRecGoodsLkOWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            RecGoodsLkOWork temp = new RecGoodsLkOWork();

            //�񋟓��t
            temp.OfferDate = reader.ReadInt32();
            //������BL���i�R�[�h
            temp.RecSourceBLGoodsCd = reader.ReadInt32();
            //������BL���i�R�[�h
            temp.RecDestBLGoodsCd = reader.ReadInt32();
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
        /// <returns>RecGoodsLkOWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecGoodsLkOWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RecGoodsLkOWork temp = GetRecGoodsLkOWork(reader, serInfo);
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
                    retValue = (RecGoodsLkOWork[])lst.ToArray(typeof(RecGoodsLkOWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
