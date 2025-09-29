//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i���i�W�J�����G���[�N���X���[�N
// �v���O�����T�v   : ���i���i�W�J�����G���[�N���X���[�N���Ǘ�����
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10703874-00 �쐬�S�� : huangqb
// �� �� ��  K2011/07/14 �쐬���e : �C�X�R�ʑΉ�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CostExpandErrorWork
    /// <summary>
    ///                      ���i���i�W�J�����G���[�N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i���i�W�J�����G���[�N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   K2011/07/14</br>
    /// <br>Genarated Date   :   K2011/07/14  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CostExpandErrorWork
    {
        /// <summary>�i��</summary>
        private string _goodsNo = "";

        /// <summary>���[�J�[</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���b�Z�[�W</summary>
        private string _errorMessage = "";


        /// public propaty name  :  GoodsNo
        /// <summary>�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���[�J�[�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  ErrorMessage
        /// <summary>���b�Z�[�W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���b�Z�[�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }


        /// <summary>
        /// ���i���i�W�J�����G���[�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CostExpandErrorWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CostExpandErrorWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CostExpandErrorWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>CostExpandErrorWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   CostExpandErrorWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class CostExpandErrorWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CostExpandErrorWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CostExpandErrorWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CostExpandErrorWork || graph is ArrayList || graph is CostExpandErrorWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(CostExpandErrorWork).FullName));

            if (graph != null && graph is CostExpandErrorWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CostExpandErrorWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CostExpandErrorWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CostExpandErrorWork[])graph).Length;
            }
            else if (graph is CostExpandErrorWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�i��
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���[�J�[
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���b�Z�[�W
            serInfo.MemberInfo.Add(typeof(string)); //ErrorMessage


            serInfo.Serialize(writer, serInfo);
            if (graph is CostExpandErrorWork)
            {
                CostExpandErrorWork temp = (CostExpandErrorWork)graph;

                SetCostExpandErrorWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CostExpandErrorWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CostExpandErrorWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CostExpandErrorWork temp in lst)
                {
                    SetCostExpandErrorWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CostExpandErrorWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 3;

        /// <summary>
        ///  CostExpandErrorWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CostExpandErrorWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetCostExpandErrorWork(System.IO.BinaryWriter writer, CostExpandErrorWork temp)
        {
            //�i��
            writer.Write(temp.GoodsNo);
            //���[�J�[
            writer.Write(temp.GoodsMakerCd);
            //���b�Z�[�W
            writer.Write(temp.ErrorMessage);

        }

        /// <summary>
        ///  CostExpandErrorWork�C���X�^���X�擾
        /// </summary>
        /// <returns>CostExpandErrorWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CostExpandErrorWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private CostExpandErrorWork GetCostExpandErrorWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            CostExpandErrorWork temp = new CostExpandErrorWork();

            //�i��
            temp.GoodsNo = reader.ReadString();
            //���[�J�[
            temp.GoodsMakerCd = reader.ReadInt32();
            //���b�Z�[�W
            temp.ErrorMessage = reader.ReadString();


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
        /// <returns>CostExpandErrorWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CostExpandErrorWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CostExpandErrorWork temp = GetCostExpandErrorWork(reader, serInfo);
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
                    retValue = (CostExpandErrorWork[])lst.ToArray(typeof(CostExpandErrorWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
