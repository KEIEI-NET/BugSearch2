//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �n���f�B�^�[�~�i���ϑ��݌ɕ�[�̑q�ɏ�񌟍����ʃ��[�N
// �v���O�����T�v   : �n���f�B�^�[�~�i���ϑ��݌ɕ�[�̑q�ɏ�񌟍����ʃ��[�N�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370074-00 �쐬�S�� : 杍^
// �� �� ��  2017/08/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ConsStockRepWarehouseRetWork
    /// <summary>
    ///                      �ϑ��݌ɕ�[�̑q�ɏ��擾���ʃ��[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �ϑ��݌ɕ�[�̑q�ɏ��擾���ʃ��[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2017/08/11</br>
    /// <br>Genarated Date   :   2017/08/11  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ConsStockRepWarehouseRetWork
    {
        /// <summary>�ϑ��q�ɃR�[�h</summary>
        private string _consignWarehouseCode = "";

        /// <summary>�ϑ��q�ɖ���</summary>
        private string _consignWarehouseName = "";

        /// <summary>��ǌ��q�ɃR�[�h</summary>
        /// <remarks>�ϑ��̏ꍇ�ɍ݌ɕ�[���s�����̑q��</remarks>
        private string _mainMngWarehouseCd = "";

        /// <summary>��ǌ��q�ɖ���</summary>
        private string _mainMngWarehouseName = "";


        /// public propaty name  :  ConsignWarehouseCode
        /// <summary>�ϑ��q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϑ��q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ConsignWarehouseCode
        {
            get { return _consignWarehouseCode; }
            set { _consignWarehouseCode = value; }
        }

        /// public propaty name  :  ConsignWarehouseName
        /// <summary>�ϑ��q�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϑ��q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ConsignWarehouseName
        {
            get { return _consignWarehouseName; }
            set { _consignWarehouseName = value; }
        }

        /// public propaty name  :  MainMngWarehouseCd
        /// <summary>��ǌ��q�ɃR�[�h�v���p�e�B</summary>
        /// <value>�ϑ��̏ꍇ�ɍ݌ɕ�[���s�����̑q��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ǌ��q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MainMngWarehouseCd
        {
            get { return _mainMngWarehouseCd; }
            set { _mainMngWarehouseCd = value; }
        }

        /// public propaty name  :  MainMngWarehouseName
        /// <summary>��ǌ��q�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ǌ��q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MainMngWarehouseName
        {
            get { return _mainMngWarehouseName; }
            set { _mainMngWarehouseName = value; }
        }


        /// <summary>
        /// �ϑ��݌ɕ�[�̑q�ɏ��擾���ʃ��[�N�R���X�g���N�^
        /// </summary>
        /// <returns>ConsStockRepWarehouseRetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ConsStockRepWarehouseRetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ConsStockRepWarehouseRetWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł��B
    /// </summary>
    /// <returns>ConsStockRepWarehouseRetWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   ConsStockRepWarehouseRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class ConsStockRepWarehouseRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ConsStockRepWarehouseRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  ConsStockRepWarehouseRetWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is ConsStockRepWarehouseRetWork || graph is ArrayList || graph is ConsStockRepWarehouseRetWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(ConsStockRepWarehouseRetWork).FullName));

            if (graph != null && graph is ConsStockRepWarehouseRetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.ConsStockRepWarehouseRetWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is ConsStockRepWarehouseRetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((ConsStockRepWarehouseRetWork[])graph).Length;
            }
            else if (graph is ConsStockRepWarehouseRetWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�ϑ��q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //ConsignWarehouseCode
            //�ϑ��q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //ConsignWarehouseName
            //��ǌ��q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //MainMngWarehouseCd
            //��ǌ��q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //MainMngWarehouseName


            serInfo.Serialize(writer, serInfo);
            if (graph is ConsStockRepWarehouseRetWork)
            {
                ConsStockRepWarehouseRetWork temp = (ConsStockRepWarehouseRetWork)graph;

                SetConsStockRepWarehouseRetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is ConsStockRepWarehouseRetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((ConsStockRepWarehouseRetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (ConsStockRepWarehouseRetWork temp in lst)
                {
                    SetConsStockRepWarehouseRetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// ConsStockRepWarehouseRetWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 4;

        /// <summary>
        ///  ConsStockRepWarehouseRetWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ConsStockRepWarehouseRetWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetConsStockRepWarehouseRetWork(System.IO.BinaryWriter writer, ConsStockRepWarehouseRetWork temp)
        {
            //�ϑ��q�ɃR�[�h
            writer.Write(temp.ConsignWarehouseCode);
            //�ϑ��q�ɖ���
            writer.Write(temp.ConsignWarehouseName);
            //��ǌ��q�ɃR�[�h
            writer.Write(temp.MainMngWarehouseCd);
            //��ǌ��q�ɖ���
            writer.Write(temp.MainMngWarehouseName);

        }

        /// <summary>
        ///  ConsStockRepWarehouseRetWork�C���X�^���X�擾
        /// </summary>
        /// <returns>ConsStockRepWarehouseRetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ConsStockRepWarehouseRetWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private ConsStockRepWarehouseRetWork GetConsStockRepWarehouseRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            ConsStockRepWarehouseRetWork temp = new ConsStockRepWarehouseRetWork();

            //�ϑ��q�ɃR�[�h
            temp.ConsignWarehouseCode = reader.ReadString();
            //�ϑ��q�ɖ���
            temp.ConsignWarehouseName = reader.ReadString();
            //��ǌ��q�ɃR�[�h
            temp.MainMngWarehouseCd = reader.ReadString();
            //��ǌ��q�ɖ���
            temp.MainMngWarehouseName = reader.ReadString();


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
        /// <returns>ConsStockRepWarehouseRetWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ConsStockRepWarehouseRetWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                ConsStockRepWarehouseRetWork temp = GetConsStockRepWarehouseRetWork(reader, serInfo);
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
                    retValue = (ConsStockRepWarehouseRetWork[])lst.ToArray(typeof(ConsStockRepWarehouseRetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
