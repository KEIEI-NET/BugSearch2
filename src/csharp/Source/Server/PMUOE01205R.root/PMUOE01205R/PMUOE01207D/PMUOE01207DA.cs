//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE���ɍX�V�f�[�^�p�����[�^
//                  :   PMUOE01207D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112�@�v�ۓc
// Date             :   2008.10.17
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
    /// public class name:   UOEStockUpdSearchWork
    /// <summary>
    ///                      UOE���ɍX�V���������N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   UOE���ɍX�V���������N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class UOEStockUpdSearchWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        /// <remarks>���O�C�����_�R�[�h��ݒ�</remarks>
        private string _sectionCode = "";

        /// <summary>�����敪</summary>
        /// <remarks>0:�݌Ɉꊇ 1:�݌Ɉꊇ�ȊO</remarks>
        private Int32 _procDiv;

        /// <summary>UOE������R�[�h</summary>
        /// <remarks>��ʏ�̎d����R�[�h��ݒ�</remarks>
        private Int32 _uOESupplierCd;

        /// <summary>�`�[�ԍ�</summary>
        /// <remarks>��ʏ�̔[�i���ԍ���ݒ�</remarks>
        private string _slipNo = "";


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

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>���O�C�����_�R�[�h��ݒ�</value>
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

        /// public propaty name  :  ProcDiv
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value>0:�݌Ɉꊇ 1:�݌Ɉꊇ�ȊO</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ProcDiv
        {
            get { return _procDiv; }
            set { _procDiv = value; }
        }

        /// public propaty name  :  UOESupplierCd
        /// <summary>UOE������R�[�h�v���p�e�B</summary>
        /// <value>��ʏ�̎d����R�[�h��ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESupplierCd
        {
            get { return _uOESupplierCd; }
            set { _uOESupplierCd = value; }
        }

        /// public propaty name  :  SlipNo
        /// <summary>�`�[�ԍ��v���p�e�B</summary>
        /// <value>��ʏ�̔[�i���ԍ���ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipNo
        {
            get { return _slipNo; }
            set { _slipNo = value; }
        }


        /// <summary>
        /// UOE���ɍX�V���������N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>UOEStockUpdSearchWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEStockUpdSearchWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UOEStockUpdSearchWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>UOEStockUpdSearchWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   UOEStockUpdSearchWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class UOEStockUpdSearchWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEStockUpdSearchWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  UOEStockUpdSearchWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is UOEStockUpdSearchWork || graph is ArrayList || graph is UOEStockUpdSearchWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(UOEStockUpdSearchWork).FullName));

            if (graph != null && graph is UOEStockUpdSearchWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.UOEStockUpdSearchWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is UOEStockUpdSearchWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((UOEStockUpdSearchWork[])graph).Length;
            }
            else if (graph is UOEStockUpdSearchWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ProcDiv
            //UOE������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESupplierCd
            //�`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SlipNo


            serInfo.Serialize(writer, serInfo);
            if (graph is UOEStockUpdSearchWork)
            {
                UOEStockUpdSearchWork temp = (UOEStockUpdSearchWork)graph;

                SetUOEStockUpdSearchWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is UOEStockUpdSearchWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((UOEStockUpdSearchWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (UOEStockUpdSearchWork temp in lst)
                {
                    SetUOEStockUpdSearchWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// UOEStockUpdSearchWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 5;

        /// <summary>
        ///  UOEStockUpdSearchWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEStockUpdSearchWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetUOEStockUpdSearchWork(System.IO.BinaryWriter writer, UOEStockUpdSearchWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //�����敪
            writer.Write(temp.ProcDiv);
            //UOE������R�[�h
            writer.Write(temp.UOESupplierCd);
            //�`�[�ԍ�
            writer.Write(temp.SlipNo);

        }

        /// <summary>
        ///  UOEStockUpdSearchWork�C���X�^���X�擾
        /// </summary>
        /// <returns>UOEStockUpdSearchWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEStockUpdSearchWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private UOEStockUpdSearchWork GetUOEStockUpdSearchWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            UOEStockUpdSearchWork temp = new UOEStockUpdSearchWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //�����敪
            temp.ProcDiv = reader.ReadInt32();
            //UOE������R�[�h
            temp.UOESupplierCd = reader.ReadInt32();
            //�`�[�ԍ�
            temp.SlipNo = reader.ReadString();


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
        /// <returns>UOEStockUpdSearchWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEStockUpdSearchWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                UOEStockUpdSearchWork temp = GetUOEStockUpdSearchWork(reader, serInfo);
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
                    retValue = (UOEStockUpdSearchWork[])lst.ToArray(typeof(UOEStockUpdSearchWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
