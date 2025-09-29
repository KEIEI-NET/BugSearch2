using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ShipmentPartsDspResultWork
    /// <summary>
    ///                      �o�ו��i�Ɖ�o���ʃ��[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �o�ו��i�Ɖ�o���ʃ��[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/03  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ShipmentPartsDspResultWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���яW�v�敪</summary>
        /// <remarks>0:���i���v 1:�݌� 2:���� 3:���</remarks>
        private Int32 _rsltTtlDivCd;

        /// <summary>�����</summary>
        /// <remarks>�o�׉�(���㎞�̂݁j</remarks>
        private Int32 _salesTimes;

        /// <summary>������z</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂܂��j</remarks>
        private Int64 _salesMoney;

        /// <summary>�e�����z</summary>
        private Int64 _grossProfit;


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

        /// public propaty name  :  RsltTtlDivCd
        /// <summary>���яW�v�敪�v���p�e�B</summary>
        /// <value>0:���i���v 1:�݌� 2:���� 3:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���яW�v�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RsltTtlDivCd
        {
            get { return _rsltTtlDivCd; }
            set { _rsltTtlDivCd = value; }
        }

        /// public propaty name  :  SalesTimes
        /// <summary>����񐔃v���p�e�B</summary>
        /// <value>�o�׉�(���㎞�̂݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����񐔃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesTimes
        {
            get { return _salesTimes; }
            set { _salesTimes = value; }
        }

        /// public propaty name  :  SalesMoney
        /// <summary>������z�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoney
        {
            get { return _salesMoney; }
            set { _salesMoney = value; }
        }

        /// public propaty name  :  GrossProfit
        /// <summary>�e�����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 GrossProfit
        {
            get { return _grossProfit; }
            set { _grossProfit = value; }
        }


        /// <summary>
        /// �o�ו��i�Ɖ�o���ʃ��[�N�R���X�g���N�^
        /// </summary>
        /// <returns>ShipmentPartsDspResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipmentPartsDspResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ShipmentPartsDspResultWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>ShipmentPartsDspResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   ShipmentPartsDspResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class ShipmentPartsDspResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipmentPartsDspResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  ShipmentPartsDspResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is ShipmentPartsDspResultWork || graph is ArrayList || graph is ShipmentPartsDspResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(ShipmentPartsDspResultWork).FullName));

            if (graph != null && graph is ShipmentPartsDspResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.ShipmentPartsDspResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is ShipmentPartsDspResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((ShipmentPartsDspResultWork[])graph).Length;
            }
            else if (graph is ShipmentPartsDspResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //���яW�v�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //RsltTtlDivCd
            //�����
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesTimes
            //������z
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney
            //�e�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfit


            serInfo.Serialize(writer, serInfo);
            if (graph is ShipmentPartsDspResultWork)
            {
                ShipmentPartsDspResultWork temp = (ShipmentPartsDspResultWork)graph;

                SetShipmentPartsDspResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is ShipmentPartsDspResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((ShipmentPartsDspResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (ShipmentPartsDspResultWork temp in lst)
                {
                    SetShipmentPartsDspResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// ShipmentPartsDspResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 5;

        /// <summary>
        ///  ShipmentPartsDspResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipmentPartsDspResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetShipmentPartsDspResultWork(System.IO.BinaryWriter writer, ShipmentPartsDspResultWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //���яW�v�敪
            writer.Write(temp.RsltTtlDivCd);
            //�����
            writer.Write(temp.SalesTimes);
            //������z
            writer.Write(temp.SalesMoney);
            //�e�����z
            writer.Write(temp.GrossProfit);

        }

        /// <summary>
        ///  ShipmentPartsDspResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>ShipmentPartsDspResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipmentPartsDspResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private ShipmentPartsDspResultWork GetShipmentPartsDspResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            ShipmentPartsDspResultWork temp = new ShipmentPartsDspResultWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //���яW�v�敪
            temp.RsltTtlDivCd = reader.ReadInt32();
            //�����
            temp.SalesTimes = reader.ReadInt32();
            //������z
            temp.SalesMoney = reader.ReadInt64();
            //�e�����z
            temp.GrossProfit = reader.ReadInt64();


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
        /// <returns>ShipmentPartsDspResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipmentPartsDspResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                ShipmentPartsDspResultWork temp = GetShipmentPartsDspResultWork(reader, serInfo);
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
                    retValue = (ShipmentPartsDspResultWork[])lst.ToArray(typeof(ShipmentPartsDspResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
