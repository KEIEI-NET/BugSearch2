using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockCarEnterCarOutRetWork
    /// <summary>
    ///                      �݌ɓ��o�ɏƉ�o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �݌ɓ��o�ɏƉ�o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/07/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockCarEnterCarOutRetWork
    {
        /// <summary>�݌ɑ���</summary>
        /// <remarks>�����J�n�N������̑��݌ɐ�</remarks>
        private Double _stockTotal;

        /// <summary>���א�</summary>
        /// <remarks>�󕥊J�n�N��������̑����א�</remarks>
        private Double _arrivalCnt;

        /// <summary>�o�א�</summary>
        /// <remarks>�󕥊J�n�N��������̑��o�א�</remarks>
        private Double _shipmentCnt;

        /// <summary>�c��</summary>
        /// <remarks>�����J�n�N������̑��݌ɐ��{�󕥊J�n�N��������J�n���o�ד��܂ł̑����א��[�󕥊J�n�N��������J�n���o�ד��܂ł̑��o�א�</remarks>
        private Double _remainCount;


        /// public propaty name  :  StockTotal
        /// <summary>�݌ɑ����v���p�e�B</summary>
        /// <value>�����J�n�N������̑��݌ɐ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɑ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockTotal
        {
            get { return _stockTotal; }
            set { _stockTotal = value; }
        }

        /// public propaty name  :  ArrivalCnt
        /// <summary>���א��v���p�e�B</summary>
        /// <value>�󕥊J�n�N��������̑����א�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ArrivalCnt
        {
            get { return _arrivalCnt; }
            set { _arrivalCnt = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>�o�א��v���p�e�B</summary>
        /// <value>�󕥊J�n�N��������̑��o�א�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
        }

        /// public propaty name  :  RemainCount
        /// <summary>�c���v���p�e�B</summary>
        /// <value>�����J�n�N������̑��݌ɐ��{�󕥊J�n�N��������J�n���o�ד��܂ł̑����א��[�󕥊J�n�N��������J�n���o�ד��܂ł̑��o�א�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double RemainCount
        {
            get { return _remainCount; }
            set { _remainCount = value; }
        }


        /// <summary>
        /// �݌ɓ��o�ɏƉ�o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockCarEnterCarOutRetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockCarEnterCarOutRetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockCarEnterCarOutRetWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>StockCarEnterCarOutRetWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   StockCarEnterCarOutRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class StockCarEnterCarOutRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockCarEnterCarOutRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockCarEnterCarOutRetWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockCarEnterCarOutRetWork || graph is ArrayList || graph is StockCarEnterCarOutRetWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(StockCarEnterCarOutRetWork).FullName));

            if (graph != null && graph is StockCarEnterCarOutRetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockCarEnterCarOutRetWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockCarEnterCarOutRetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockCarEnterCarOutRetWork[])graph).Length;
            }
            else if (graph is StockCarEnterCarOutRetWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�݌ɑ���
            serInfo.MemberInfo.Add(typeof(Double)); //StockTotal
            //���א�
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt
            //�o�א�
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //�c��
            serInfo.MemberInfo.Add(typeof(Double)); //RemainCount


            serInfo.Serialize(writer, serInfo);
            if (graph is StockCarEnterCarOutRetWork)
            {
                StockCarEnterCarOutRetWork temp = (StockCarEnterCarOutRetWork)graph;

                SetStockCarEnterCarOutRetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockCarEnterCarOutRetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockCarEnterCarOutRetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockCarEnterCarOutRetWork temp in lst)
                {
                    SetStockCarEnterCarOutRetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockCarEnterCarOutRetWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 4;

        /// <summary>
        ///  StockCarEnterCarOutRetWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockCarEnterCarOutRetWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetStockCarEnterCarOutRetWork(System.IO.BinaryWriter writer, StockCarEnterCarOutRetWork temp)
        {
            //�݌ɑ���
            writer.Write(temp.StockTotal);
            //���א�
            writer.Write(temp.ArrivalCnt);
            //�o�א�
            writer.Write(temp.ShipmentCnt);
            //�c��
            writer.Write(temp.RemainCount);

        }

        /// <summary>
        ///  StockCarEnterCarOutRetWork�C���X�^���X�擾
        /// </summary>
        /// <returns>StockCarEnterCarOutRetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockCarEnterCarOutRetWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private StockCarEnterCarOutRetWork GetStockCarEnterCarOutRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            StockCarEnterCarOutRetWork temp = new StockCarEnterCarOutRetWork();

            //�݌ɑ���
            temp.StockTotal = reader.ReadDouble();
            //���א�
            temp.ArrivalCnt = reader.ReadDouble();
            //�o�א�
            temp.ShipmentCnt = reader.ReadDouble();
            //�c��
            temp.RemainCount = reader.ReadDouble();


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
        /// <returns>StockCarEnterCarOutRetWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockCarEnterCarOutRetWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockCarEnterCarOutRetWork temp = GetStockCarEnterCarOutRetWork(reader, serInfo);
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
                    retValue = (StockCarEnterCarOutRetWork[])lst.ToArray(typeof(StockCarEnterCarOutRetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }



}
