//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d���摍���}�X�^�ꗗ�\���o���ʃN���X���[�N
// �v���O�����T�v   : �d���摍���}�X�^�ꗗ�\���o���ʃN���X���[�N�w�b�_�t�@�C��
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI�����@�v
// �� �� ��  2012/09/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SumSuppStPrintResultWork
    /// <summary>
    ///                      �d���摍���ꗗ�\ ���o���ʃ��[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d���摍���ꗗ�\ ���o���ʃ��[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2012/09/07  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SumSuppStPrintResultWork
    {
        /// <summary>�������_�R�[�h</summary>
        private string _sumSectionCd = "";

        /// <summary>�����d����R�[�h</summary>
        private Int32 _sumSupplierCd;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCode;


        /// public propaty name  :  SumSectionCd
        /// <summary>�������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SumSectionCd
        {
            get { return _sumSectionCd; }
            set { _sumSectionCd = value; }
        }

        /// public propaty name  :  SumSupplierCd
        /// <summary>�����d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SumSupplierCd
        {
            get { return _sumSupplierCd; }
            set { _sumSupplierCd = value; }
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

        /// public propaty name  :  SupplierCode
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCode
        {
            get { return _supplierCode; }
            set { _supplierCode = value; }
        }


        /// <summary>
        /// �d���摍���ꗗ�\ ���o���ʃ��[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SumSuppStPrintResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SumSuppStPrintResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SumSuppStPrintResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SumSuppStPrintResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SumSuppStPrintResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SumSuppStPrintResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SumSuppStPrintResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SumSuppStPrintResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SumSuppStPrintResultWork || graph is ArrayList || graph is SumSuppStPrintResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SumSuppStPrintResultWork).FullName));

            if (graph != null && graph is SumSuppStPrintResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SumSuppStPrintResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SumSuppStPrintResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SumSuppStPrintResultWork[])graph).Length;
            }
            else if (graph is SumSuppStPrintResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�������_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SumSectionCd
            //�����d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SumSupplierCd
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCode


            serInfo.Serialize(writer, serInfo);
            if (graph is SumSuppStPrintResultWork)
            {
                SumSuppStPrintResultWork temp = (SumSuppStPrintResultWork)graph;

                SetSumSuppStPrintResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SumSuppStPrintResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SumSuppStPrintResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SumSuppStPrintResultWork temp in lst)
                {
                    SetSumSuppStPrintResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SumSuppStPrintResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 4;

        /// <summary>
        ///  SumSuppStPrintResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SumSuppStPrintResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSumSuppStPrintResultWork(System.IO.BinaryWriter writer, SumSuppStPrintResultWork temp)
        {
            //�������_�R�[�h
            writer.Write(temp.SumSectionCd);
            //�����d����R�[�h
            writer.Write(temp.SumSupplierCd);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //�d����R�[�h
            writer.Write(temp.SupplierCode);

        }

        /// <summary>
        ///  SumSuppStPrintResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SumSuppStPrintResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SumSuppStPrintResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SumSuppStPrintResultWork GetSumSuppStPrintResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SumSuppStPrintResultWork temp = new SumSuppStPrintResultWork();

            //�������_�R�[�h
            temp.SumSectionCd = reader.ReadString();
            //�����d����R�[�h
            temp.SumSupplierCd = reader.ReadInt32();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCode = reader.ReadInt32();


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
        /// <returns>SumSuppStPrintResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SumSuppStPrintResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SumSuppStPrintResultWork temp = GetSumSuppStPrintResultWork(reader, serInfo);
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
                    retValue = (SumSuppStPrintResultWork[])lst.ToArray(typeof(SumSuppStPrintResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }



}
