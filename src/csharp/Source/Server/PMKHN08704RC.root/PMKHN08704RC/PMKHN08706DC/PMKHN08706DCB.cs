//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i���i�W�J���������N���X���[�N
// �v���O�����T�v   : ���i���i�W�J���������N���X���[�N���Ǘ�����
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
    /// public class name:   CostExpandProcessNumWork
    /// <summary>
    ///                      ���i���i�W�J���������N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i���i�W�J���������N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   K2011/07/14</br>
    /// <br>Genarated Date   :   K2011/07/14  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CostExpandProcessNumWork
    {
        /// <summary>�a�f���i�i�g���^�j</summary>
        private Int64 _toyotaBProcessNum;

        /// <summary>�����i�g���^�j</summary>
        private Int64 _toyotaProcessNum;

        /// <summary>�a�f���i�i�^�N�e�B�j</summary>
        private Int64 _takuthiBProcessNum;

        /// <summary>�����i�^�N�e�B�j</summary>
        private Int64 _takuthiProcessNum;

        /// <summary>�����i���Y�j</summary>
        private Int64 _nissanProcessNum;

        /// <summary>�����i�s�b�g���[�N�j</summary>
        private Int64 _bittowaakuProcessNum;


        /// public propaty name  :  ToyotaBProcessNum
        /// <summary>�a�f���i�i�g���^�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �a�f���i�i�g���^�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ToyotaBProcessNum
        {
            get { return _toyotaBProcessNum; }
            set { _toyotaBProcessNum = value; }
        }

        /// public propaty name  :  ToyotaProcessNum
        /// <summary>�����i�g���^�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����i�g���^�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ToyotaProcessNum
        {
            get { return _toyotaProcessNum; }
            set { _toyotaProcessNum = value; }
        }

        /// public propaty name  :  TakuthiBProcessNum
        /// <summary>�a�f���i�i�^�N�e�B�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �a�f���i�i�^�N�e�B�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TakuthiBProcessNum
        {
            get { return _takuthiBProcessNum; }
            set { _takuthiBProcessNum = value; }
        }

        /// public propaty name  :  TakuthiProcessNum
        /// <summary>�����i�^�N�e�B�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����i�^�N�e�B�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TakuthiProcessNum
        {
            get { return _takuthiProcessNum; }
            set { _takuthiProcessNum = value; }
        }

        /// public propaty name  :  NissanProcessNum
        /// <summary>�����i���Y�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����i���Y�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 NissanProcessNum
        {
            get { return _nissanProcessNum; }
            set { _nissanProcessNum = value; }
        }

        /// public propaty name  :  BittowaakuProcessNum
        /// <summary>�����i�s�b�g���[�N�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����i�s�b�g���[�N�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 BittowaakuProcessNum
        {
            get { return _bittowaakuProcessNum; }
            set { _bittowaakuProcessNum = value; }
        }


        /// <summary>
        /// ���i���i�W�J���������N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CostExpandProcessNumWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CostExpandProcessNumWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CostExpandProcessNumWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>CostExpandProcessNumWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   CostExpandProcessNumWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class CostExpandProcessNumWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CostExpandProcessNumWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CostExpandProcessNumWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CostExpandProcessNumWork || graph is ArrayList || graph is CostExpandProcessNumWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(CostExpandProcessNumWork).FullName));

            if (graph != null && graph is CostExpandProcessNumWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CostExpandProcessNumWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CostExpandProcessNumWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CostExpandProcessNumWork[])graph).Length;
            }
            else if (graph is CostExpandProcessNumWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�a�f���i�i�g���^�j
            serInfo.MemberInfo.Add(typeof(Int64)); //ToyotaBProcessNum
            //�����i�g���^�j
            serInfo.MemberInfo.Add(typeof(Int64)); //ToyotaProcessNum
            //�a�f���i�i�^�N�e�B�j
            serInfo.MemberInfo.Add(typeof(Int64)); //TakuthiBProcessNum
            //�����i�^�N�e�B�j
            serInfo.MemberInfo.Add(typeof(Int64)); //TakuthiProcessNum
            //�����i���Y�j
            serInfo.MemberInfo.Add(typeof(Int64)); //NissanProcessNum
            //�����i�s�b�g���[�N�j
            serInfo.MemberInfo.Add(typeof(Int64)); //BittowaakuProcessNum


            serInfo.Serialize(writer, serInfo);
            if (graph is CostExpandProcessNumWork)
            {
                CostExpandProcessNumWork temp = (CostExpandProcessNumWork)graph;

                SetCostExpandProcessNumWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CostExpandProcessNumWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CostExpandProcessNumWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CostExpandProcessNumWork temp in lst)
                {
                    SetCostExpandProcessNumWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CostExpandProcessNumWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 6;

        /// <summary>
        ///  CostExpandProcessNumWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CostExpandProcessNumWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetCostExpandProcessNumWork(System.IO.BinaryWriter writer, CostExpandProcessNumWork temp)
        {
            //�a�f���i�i�g���^�j
            writer.Write(temp.ToyotaBProcessNum);
            //�����i�g���^�j
            writer.Write(temp.ToyotaProcessNum);
            //�a�f���i�i�^�N�e�B�j
            writer.Write(temp.TakuthiBProcessNum);
            //�����i�^�N�e�B�j
            writer.Write(temp.TakuthiProcessNum);
            //�����i���Y�j
            writer.Write(temp.NissanProcessNum);
            //�����i�s�b�g���[�N�j
            writer.Write(temp.BittowaakuProcessNum);

        }

        /// <summary>
        ///  CostExpandProcessNumWork�C���X�^���X�擾
        /// </summary>
        /// <returns>CostExpandProcessNumWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CostExpandProcessNumWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private CostExpandProcessNumWork GetCostExpandProcessNumWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            CostExpandProcessNumWork temp = new CostExpandProcessNumWork();

            //�a�f���i�i�g���^�j
            temp.ToyotaBProcessNum = reader.ReadInt64();
            //�����i�g���^�j
            temp.ToyotaProcessNum = reader.ReadInt64();
            //�a�f���i�i�^�N�e�B�j
            temp.TakuthiBProcessNum = reader.ReadInt64();
            //�����i�^�N�e�B�j
            temp.TakuthiProcessNum = reader.ReadInt64();
            //�����i���Y�j
            temp.NissanProcessNum = reader.ReadInt64();
            //�����i�s�b�g���[�N�j
            temp.BittowaakuProcessNum = reader.ReadInt64();


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
        /// <returns>CostExpandProcessNumWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CostExpandProcessNumWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CostExpandProcessNumWork temp = GetCostExpandProcessNumWork(reader, serInfo);
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
                    retValue = (CostExpandProcessNumWork[])lst.ToArray(typeof(CostExpandProcessNumWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
