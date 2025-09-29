//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �\���敪�}�X�^�i����j
// �v���O�����T�v   : �\���敪�}�X�^�i����j�f�[�^�p�����[�^ 
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �L�w��
// �� �� ��  2012/06/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PriceSelectSetResultWork
    /// <summary>
    ///                      �\���敪�}�X�^�i����j�����������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �\���敪�}�X�^�i����j�����������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2012/06/11  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PriceSelectSetResultWork
    {
        # region �� private field

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ於</summary>
        private string _customerSnm = "";

        /// <summary>���Ӑ�|���O���[�v�R�[�h</summary>
        private Int32 _bLGroupCode;

        /// <summary>���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[��</summary>
        private string _goodsMakerSnm;

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL���i�R�[�h���́i���p�j</summary>
        private string _bLGoodsHalfName = "";

        /// <summary>�\���敪</summary>
        private Int32 _priceSelectDiv;

        /// <summary>�_���폜�敪</summary>
        private Int32 _logicalDeleteCode;

        /// <summary>�W�����i�I��ݒ�p�^�[��</summary>
        private Int32 _priceSelectPtn;
        # endregion  �� private field

        # region �� public propaty
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

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ於�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>���Ӑ�|���O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�|���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  GoodsMakerSnm
        /// <summary>���[�J�[���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsMakerSnm
        {
            get { return _goodsMakerSnm; }
            set { _goodsMakerSnm = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  BLGoodsHalfName
        /// <summary>BL���i�R�[�h���́i���p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i���p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsHalfName
        {
            get { return _bLGoodsHalfName; }
            set { _bLGoodsHalfName = value; }
        }

        /// public propaty name  :  PriceSelectDiv
        /// <summary>�\���敪</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceSelectDiv
        {
            get { return _priceSelectDiv; }
            set { _priceSelectDiv = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�_���폜�敪</summary>
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

        /// public propaty name  :  PriceSelectPtn
        /// <summary>�W�����i�I��ݒ�p�^�[��</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����i�I��ݒ�p�^�[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceSelectPtn
        {
            get { return _priceSelectPtn; }
            set { _priceSelectPtn = value; }
        }
        # endregion �� public propaty
    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>PriceSelectSetResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   PriceSelectSetResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class PriceSelectSetResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PriceSelectSetResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PriceSelectSetResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PriceSelectSetResultWork || graph is ArrayList || graph is PriceSelectSetResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PriceSelectSetResultWork).FullName));

            if (graph != null && graph is PriceSelectSetResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PriceSelectSetResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PriceSelectSetResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PriceSelectSetResultWork[])graph).Length;
            }
            else if (graph is PriceSelectSetResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }
            //�J��Ԃ���	
            serInfo.Occurrence = occurrence;

            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64));
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32));
            //���Ӑ於
            serInfo.MemberInfo.Add(typeof(string));
            //���Ӑ�|���O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32));
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32));
            //���i���[�J�[��
            serInfo.MemberInfo.Add(typeof(string));
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32));
            //BL���i��
            serInfo.MemberInfo.Add(typeof(string));
            //�W�����i�I���敪
            serInfo.MemberInfo.Add(typeof(Int32));
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32));
            //�W�����i�I��ݒ�p�^�[��
            serInfo.MemberInfo.Add(typeof(Int32));

            serInfo.Serialize(writer, serInfo);
            if (graph is PriceSelectSetResultWork)
            {
                PriceSelectSetResultWork temp = (PriceSelectSetResultWork)graph;

                SetPriceSelectSetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PriceSelectSetResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PriceSelectSetResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PriceSelectSetResultWork temp in lst)
                {
                    SetPriceSelectSetWork(writer, temp);
                }

            }


        }

        /// <summary>
        /// PriceSelectSetResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 11;

        /// <summary>
        ///  PriceSelectSetResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PriceSelectSetResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetPriceSelectSetWork(System.IO.BinaryWriter writer, PriceSelectSetResultWork temp)
        {

            // �X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);

            // ���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);

            // ���Ӑ於
            writer.Write(temp.CustomerSnm);

            // ���Ӑ�|���O���[�v�R�[�h
            writer.Write(temp.BLGroupCode);

            // ���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);

            // ���i���[�J�[��
            writer.Write(temp.GoodsMakerSnm);

            // BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);

            // BL���i��
            writer.Write(temp.BLGoodsHalfName);

            // �W�����i�I���敪
            writer.Write(temp.PriceSelectDiv);

            // �_���폜�敪
            writer.Write(temp.LogicalDeleteCode);

            // �W�����i�I��ݒ�p�^�[��
            writer.Write(temp.PriceSelectPtn);
        }

        /// <summary>
        ///  PriceSelectSetResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>PriceSelectSetResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PriceSelectSetResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private PriceSelectSetResultWork GetPriceSelectSetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            PriceSelectSetResultWork temp = new PriceSelectSetResultWork();

            // �X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());

            // ���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();

            // ���Ӑ於
            temp.CustomerSnm = reader.ReadString();

            // ���Ӑ�|���O���[�v�R�[�h
            temp.BLGroupCode = reader.ReadInt32();

            // ���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();

            // ���i���[�J�[��
            temp.GoodsMakerSnm = reader.ReadString();

            // BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();

            // BL���i��
            temp.BLGoodsHalfName = reader.ReadString();

            // �W�����i�I���敪
            temp.PriceSelectDiv = reader.ReadInt32();

            // �_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();

            // �W�����i�I��ݒ�p�^�[��
            temp.PriceSelectPtn = reader.ReadInt32();


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
        /// <returns>PriceSelectSetResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PriceSelectSetResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PriceSelectSetResultWork temp = GetPriceSelectSetWork(reader, serInfo);
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
                    retValue = (PriceSelectSetResultWork[])lst.ToArray(typeof(PriceSelectSetResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
