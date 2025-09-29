//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����Y�Ə��i�݌Ƀ}�X�^�ϊ�����
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : �i�N
// �� �� ��  2015/01/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   MeijiGoodsStockWork
    /// <summary>
    ///                      ���i�݌ɕϊ��������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i�݌ɕϊ��������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2015/01/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class MeijiGoodsStockWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���i��</summary>
        private string _oldGoodsNo = "";

        /// <summary>�V�i��</summary>
        private string _newGoodsNo = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�q�ɃR�[�h</summary>
        private string _wareCode = "";

        /// <summary>���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>�G���[���e</summary>
        private string _errorMessage = "";

        /// <summary>���i�J�n��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _priceStartDate;

        /// <summary>���l</summary>
        private string _outNote = "";

        /// <summary>�}�X�^�敪</summary>
        private Int32 _mstDiv;

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

        /// public propaty name  :  OldGoodsNo
        /// <summary>���i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OldGoodsNo
        {
            get { return _oldGoodsNo; }
            set { _oldGoodsNo = value; }
        }

        /// public propaty name  :  NewGoodsNo
        /// <summary>�V�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V�i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string NewGoodsNo
        {
            get { return _newGoodsNo; }
            set { _newGoodsNo = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  WareCode
        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WareCode
        {
            get { return _wareCode; }
            set { _wareCode = value; }
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

        /// public propaty name  :  MstDiv
        /// <summary>�}�X�^�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �}�X�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MstDiv
        {
            get { return _mstDiv; }
            set { _mstDiv = value; }
        }

        /// public propaty name  :  ErrorMessage
        /// <summary>�G���[���e�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���[���e�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        /// public propaty name  :  PriceStartDate
        /// <summary>���i�J�n���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
        }

        /// public propaty name  :  OutNote
        /// <summary>���l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OutNote
        {
            get { return _outNote; }
            set { _outNote = value; }
        }

        /// <summary>
        /// ���i�݌ɕϊ��������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>MeijiGoodsStockWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MeijiGoodsStockWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MeijiGoodsStockWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>MeijiGoodsStockWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   MeijiGoodsStockWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class MeijiGoodsStockWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MeijiGoodsStockWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  MeijiGoodsStockWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is MeijiGoodsStockWork || graph is ArrayList || graph is MeijiGoodsStockWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(MeijiGoodsStockWork).FullName));

            if (graph != null && graph is MeijiGoodsStockWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.MeijiGoodsStockWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is MeijiGoodsStockWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((MeijiGoodsStockWork[])graph).Length;
            }
            else if (graph is MeijiGoodsStockWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //���i��
            serInfo.MemberInfo.Add(typeof(string)); //OldGoodsNo
            //�V�i��
            serInfo.MemberInfo.Add(typeof(string)); //NewGoodsNo
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WareCode
            //���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //�}�X�^�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //MstDiv
            //�G���[���e
            serInfo.MemberInfo.Add(typeof(string)); //ErrorMessage
            //���i�J�n��
            serInfo.MemberInfo.Add(typeof(Int64)); //PriceStartDate
            //���l
            serInfo.MemberInfo.Add(typeof(string)); //OutNote


            serInfo.Serialize(writer, serInfo);
            if (graph is MeijiGoodsStockWork)
            {
                MeijiGoodsStockWork temp = (MeijiGoodsStockWork)graph;

                SetMeijiGoodsStockWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is MeijiGoodsStockWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((MeijiGoodsStockWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (MeijiGoodsStockWork temp in lst)
                {
                    SetMeijiGoodsStockWork(writer, temp);
                }
            }


        }


        /// <summary>
        /// MeijiGoodsStockWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 10;

        /// <summary>
        ///  MeijiGoodsStockWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MeijiGoodsStockWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetMeijiGoodsStockWork(System.IO.BinaryWriter writer, MeijiGoodsStockWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //���i��
            writer.Write(temp.OldGoodsNo);
            //�V�i��
            writer.Write(temp.NewGoodsNo);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //�q�ɃR�[�h
            writer.Write(temp.WareCode);
            //���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //�}�X�^�敪
            writer.Write(temp.MstDiv);
            //�G���[���e
            writer.Write(temp.ErrorMessage);
            //���i�J�n��
            writer.Write((Int64)temp.PriceStartDate.Ticks);
            //���l
            writer.Write(temp.OutNote);

        }

        /// <summary>
        ///  MeijiGoodsStockWork�C���X�^���X�擾
        /// </summary>
        /// <returns>MeijiGoodsStockWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MeijiGoodsStockWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private MeijiGoodsStockWork GetMeijiGoodsStockWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            MeijiGoodsStockWork temp = new MeijiGoodsStockWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //���i��
            temp.OldGoodsNo = reader.ReadString();
            //�V�i��
            temp.NewGoodsNo = reader.ReadString();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //�q�ɃR�[�h
            temp.WareCode = reader.ReadString();
            //���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //�}�X�^�敪
            temp.MstDiv = reader.ReadInt32();
            //�G���[���e
            temp.ErrorMessage = reader.ReadString();
            //���i�J�n��
            temp.PriceStartDate = new DateTime(reader.ReadInt64());
            //���l
            temp.OutNote = reader.ReadString();


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
        /// <returns>MeijiGoodsStockWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MeijiGoodsStockWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                MeijiGoodsStockWork temp = GetMeijiGoodsStockWork(reader, serInfo);
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
                    retValue = (MeijiGoodsStockWork[])lst.ToArray(typeof(MeijiGoodsStockWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }





}
