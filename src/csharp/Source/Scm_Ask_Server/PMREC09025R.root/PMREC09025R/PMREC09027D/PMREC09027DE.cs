//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���������iPM���j���[�N
// �v���O�����T�v   : ���������iPM���j���[�N�f�[�^�p�����[�^
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
    /// public class name:   RecBgnGdsPMSearchParaWork
    /// <summary>
    ///                      ���������iPM���j���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���������iPM���j���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2015/02/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RecBgnGdsPMSearchParaWork 
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>�⍇�����ƃR�[�h</summary>
        private string _inqOtherEpCd = "";

        /// <summary>�⍇���拒�_�R�[�h</summary>
        private string _inqOtherSecCd = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���[�J�[�i�J�n�j</summary>
        private Int32 _goodsMakerCdSt;

        /// <summary>���[�J�[�i�I���j</summary>
        private Int32 _goodsMakerCdEd;

        /// <summary>�K�p���J�n���i�J�n�j</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _applyDateSt;

        /// <summary>�K�p���J�n���i�I���j</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _applyDateEd;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>�폜�w��敪</summary>
        private Int32 _deleteFlag;

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

        /// public propaty name  :  customerCode
        /// <summary>���Ӑ�R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 customerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  goodsMakerCdSt
        /// <summary>���[�J�[�i�J�n�j</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�i�J�n�j</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 goodsMakerCdSt
        {
            get { return _goodsMakerCdSt; }
            set { _goodsMakerCdSt = value; }
        }

        /// public propaty name  :  goodsMakerCdEd
        /// <summary>���[�J�[�i�I���j</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�i�I���j</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 goodsMakerCdEd
        {
            get { return _goodsMakerCdEd; }
            set { _goodsMakerCdEd = value; }
        }

        /// public propaty name  :  applyDateSt
        /// <summary>�K�p���J�n���i�J�n�j</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p���J�n���i�J�n�j</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 applyDateSt
        {
            get { return _applyDateSt; }
            set { _applyDateSt = value; }
        }

        /// public propaty name  :  applyDateEd
        /// <summary>�K�p���J�n���i�I���j</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p���J�n���i�I���j</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 applyDateEd
        {
            get { return _applyDateEd; }
            set { _applyDateEd = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>���i�ԍ�</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  deleteFlag
        /// <summary>�폜�w��敪</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �폜�w��敪</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 deleteFlag
        {
            get { return _deleteFlag; }
            set { _deleteFlag = value; }
        }



        /// <summary>
        /// ���������iPM���j���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>RecBgnGdsPMSearchParaWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecBgnGdsPMSearchParaWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RecBgnGdsPMSearchParaWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>RecBgnGdsPMSearchParaWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   RecBgnGdsPMSearchParaWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class RecBgnGdsPMSearchParaWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecBgnGdsPMSearchParaWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RecBgnGdsPMSearchParaWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RecBgnGdsPMSearchParaWork || graph is ArrayList || graph is RecBgnGdsPMSearchParaWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(RecBgnGdsPMSearchParaWork).FullName));

            if (graph != null && graph is RecBgnGdsPMSearchParaWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsPMSearchParaWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RecBgnGdsPMSearchParaWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RecBgnGdsPMSearchParaWork[])graph).Length;
            }
            else if (graph is RecBgnGdsPMSearchParaWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //�⍇�����ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
            //�⍇���拒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //customerCode
            //���[�J�[�i�J�n�j
            serInfo.MemberInfo.Add(typeof(Int32)); //goodsMakerCdSt
            //���[�J�[�i�I���j
            serInfo.MemberInfo.Add(typeof(Int32)); //goodsMakerCdEd
            //�K�p���J�n���i�J�n�j
            serInfo.MemberInfo.Add(typeof(Int32)); //applyDateSt
            //�K�p���J�n���i�I���j
            serInfo.MemberInfo.Add(typeof(Int32)); //applyDateEd
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //�폜�w��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //deleteFlag



            serInfo.Serialize(writer, serInfo);
            if (graph is RecBgnGdsPMSearchParaWork)
            {
                RecBgnGdsPMSearchParaWork temp = (RecBgnGdsPMSearchParaWork)graph;

                SetRecBgnGdsPMSearchParaWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RecBgnGdsPMSearchParaWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RecBgnGdsPMSearchParaWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RecBgnGdsPMSearchParaWork temp in lst)
                {
                    SetRecBgnGdsPMSearchParaWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RecBgnGdsPMSearchParaWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 11;

        /// <summary>
        ///  RecBgnGdsPMSearchParaWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecBgnGdsPMSearchParaWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetRecBgnGdsPMSearchParaWork(System.IO.BinaryWriter writer, RecBgnGdsPMSearchParaWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //�⍇�����ƃR�[�h
            writer.Write(temp.InqOtherEpCd);
            //�⍇���拒�_�R�[�h
            writer.Write(temp.InqOtherSecCd);
            //���Ӑ�R�[�h
            writer.Write((Int32)temp.customerCode);
            //���[�J�[�i�J�n�j
            writer.Write((Int32)temp.goodsMakerCdSt);
            //���[�J�[�i�I���j
            writer.Write((Int32)temp.goodsMakerCdEd);
            //�K�p���J�n���i�J�n�j
            writer.Write((Int32)temp.applyDateSt);
            //�K�p���J�n���i�I���j
            writer.Write((Int32)temp.applyDateEd);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //�폜�w��敪
            writer.Write((Int32)temp.deleteFlag);


        }

        /// <summary>
        ///  RecBgnGdsPMSearchParaWork�C���X�^���X�擾
        /// </summary>
        /// <returns>RecBgnGdsPMSearchParaWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecBgnGdsPMSearchParaWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private RecBgnGdsPMSearchParaWork GetRecBgnGdsPMSearchParaWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            RecBgnGdsPMSearchParaWork temp = new RecBgnGdsPMSearchParaWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //�⍇�����ƃR�[�h
            temp.InqOtherEpCd = reader.ReadString();
            //�⍇���拒�_�R�[�h
            temp.InqOtherSecCd = reader.ReadString();
            //���Ӑ�R�[�h
            temp.customerCode = reader.ReadInt32();
            //���[�J�[�i�J�n�j
            temp.goodsMakerCdSt = reader.ReadInt32();
            //���[�J�[�i�I���j
            temp.goodsMakerCdEd = reader.ReadInt32();
            //�K�p���J�n���i�J�n�j
            temp.applyDateSt = reader.ReadInt32();
            //�K�p���J�n���i�I���j
            temp.applyDateEd = reader.ReadInt32();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //�폜�w��敪
            temp.deleteFlag = reader.ReadInt32();



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
        /// <returns>RecBgnGdsPMSearchParaWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecBgnGdsPMSearchParaWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RecBgnGdsPMSearchParaWork temp = GetRecBgnGdsPMSearchParaWork(reader, serInfo);
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
                    retValue = (RecBgnGdsPMSearchParaWork[])lst.ToArray(typeof(RecBgnGdsPMSearchParaWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
