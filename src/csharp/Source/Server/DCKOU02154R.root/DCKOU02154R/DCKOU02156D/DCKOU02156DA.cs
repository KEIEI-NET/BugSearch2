using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockDayTotalDataWork
    /// <summary>
    ///                      �d�����v�݌v�\�f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d�����v�݌v�\�f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/09/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockDayTotalDataWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�d�����_�R�[�h</summary>
        private string _stockSectionCd = "";

        /// <summary>�d�����_����</summary>
        private string _stockSectionNm = "";

        /// <summary>�d����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _stockDate;

        /// <summary>�d���S���҃R�[�h</summary>
        private string _stockAgentCode = "";

        /// <summary>�d���S���Җ���</summary>
        private string _stockAgentName = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���於��</summary>
        private string _supplierNm1 = "";

        /// <summary>�d���於��2</summary>
        private string _supplierNm2 = "";

        /// <summary>�d���z���v</summary>
        /// <remarks>�d�����z(�ō�)�̓��v</remarks>
        private Int64 _stockTtlPrice;

        /// <summary>�ԕi�z���v</summary>
        private Int64 _retGoodsTtlPrice;

        /// <summary>�l���z���v</summary>
        private Int64 _discountTtlPrice;

        /// <summary>���d���z���v</summary>
        private Int64 _pureStockTtlPrice;


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

        /// public propaty name  :  StockSectionCd
        /// <summary>�d�����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockSectionCd
        {
            get { return _stockSectionCd; }
            set { _stockSectionCd = value; }
        }

        /// public propaty name  :  StockSectionNm
        /// <summary>�d�����_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockSectionNm
        {
            get { return _stockSectionNm; }
            set { _stockSectionNm = value; }
        }

        /// public propaty name  :  StockDate
        /// <summary>�d�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StockDate
        {
            get { return _stockDate; }
            set { _stockDate = value; }
        }

        /// public propaty name  :  StockAgentCode
        /// <summary>�d���S���҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAgentCode
        {
            get { return _stockAgentCode; }
            set { _stockAgentCode = value; }
        }

        /// public propaty name  :  StockAgentName
        /// <summary>�d���S���Җ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���S���Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAgentName
        {
            get { return _stockAgentName; }
            set { _stockAgentName = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierNm1
        /// <summary>�d���於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierNm1
        {
            get { return _supplierNm1; }
            set { _supplierNm1 = value; }
        }

        /// public propaty name  :  SupplierNm2
        /// <summary>�d���於��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierNm2
        {
            get { return _supplierNm2; }
            set { _supplierNm2 = value; }
        }

        /// public propaty name  :  StockTtlPrice
        /// <summary>�d���z���v�v���p�e�B</summary>
        /// <value>�d�����z(�ō�)�̓��v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���z���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTtlPrice
        {
            get { return _stockTtlPrice; }
            set { _stockTtlPrice = value; }
        }

        /// public propaty name  :  RetGoodsTtlPrice
        /// <summary>�ԕi�z���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�z���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 RetGoodsTtlPrice
        {
            get { return _retGoodsTtlPrice; }
            set { _retGoodsTtlPrice = value; }
        }

        /// public propaty name  :  DiscountTtlPrice
        /// <summary>�l���z���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l���z���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DiscountTtlPrice
        {
            get { return _discountTtlPrice; }
            set { _discountTtlPrice = value; }
        }

        /// public propaty name  :  PureStockTtlPrice
        /// <summary>���d���z���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d���z���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 PureStockTtlPrice
        {
            get { return _pureStockTtlPrice; }
            set { _pureStockTtlPrice = value; }
        }

        /// <summary>
        /// �d�����v�݌v�\�f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockDayTotalDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockDayTotalDataWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockDayTotalDataWork()
        {
        }
    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>StockDayTotalDataWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   StockDayTotalDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class StockDayTotalDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockDayTotalDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockDayTotalDataWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockDayTotalDataWork || graph is ArrayList || graph is StockDayTotalDataWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(StockDayTotalDataWork).FullName));

            if (graph != null && graph is StockDayTotalDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockDayTotalDataWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockDayTotalDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockDayTotalDataWork[])graph).Length;
            }
            else if (graph is StockDayTotalDataWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //�d�����_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionCd
            //�d�����_����
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionNm
            //�d����
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDate
            //�d���S���҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentCode
            //�d���S���Җ���
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentName
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���於��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm1
            //�d���於��2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm2
            //�d���z���v
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPrice
            //�ԕi�z���v
            serInfo.MemberInfo.Add(typeof(Int64)); //RetGoodsTtlPrice
            //�l���z���v
            serInfo.MemberInfo.Add(typeof(Int64)); //DiscountTtlPrice
            //���d���z���v
            serInfo.MemberInfo.Add(typeof(Int64)); //PureStockTtlPrice


            serInfo.Serialize(writer, serInfo);
            if (graph is StockDayTotalDataWork)
            {
                StockDayTotalDataWork temp = (StockDayTotalDataWork)graph;

                SetStockDayTotalDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockDayTotalDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockDayTotalDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockDayTotalDataWork temp in lst)
                {
                    SetStockDayTotalDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockDayTotalDataWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 13;

        /// <summary>
        ///  StockDayTotalDataWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockDayTotalDataWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetStockDayTotalDataWork(System.IO.BinaryWriter writer, StockDayTotalDataWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //�d�����_�R�[�h
            writer.Write(temp.StockSectionCd);
            //�d�����_����
            writer.Write(temp.StockSectionNm);
            //�d����
            writer.Write((Int64)temp.StockDate.Ticks);
            //�d���S���҃R�[�h
            writer.Write(temp.StockAgentCode);
            //�d���S���Җ���
            writer.Write(temp.StockAgentName);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���於��
            writer.Write(temp.SupplierNm1);
            //�d���於��2
            writer.Write(temp.SupplierNm2);
            //�d���z���v
            writer.Write(temp.StockTtlPrice);
            //�ԕi�z���v
            writer.Write(temp.RetGoodsTtlPrice);
            //�l���z���v
            writer.Write(temp.DiscountTtlPrice);
            //���d���z���v
            writer.Write(temp.PureStockTtlPrice);

        }

        /// <summary>
        ///  StockDayTotalDataWork�C���X�^���X�擾
        /// </summary>
        /// <returns>StockDayTotalDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockDayTotalDataWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private StockDayTotalDataWork GetStockDayTotalDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            StockDayTotalDataWork temp = new StockDayTotalDataWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //�d�����_�R�[�h
            temp.StockSectionCd = reader.ReadString();
            //�d�����_����
            temp.StockSectionNm = reader.ReadString();
            //�d����
            temp.StockDate = new DateTime(reader.ReadInt64());
            //�d���S���҃R�[�h
            temp.StockAgentCode = reader.ReadString();
            //�d���S���Җ���
            temp.StockAgentName = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���於��
            temp.SupplierNm1 = reader.ReadString();
            //�d���於��2
            temp.SupplierNm2 = reader.ReadString();
            //�d���z���v
            temp.StockTtlPrice = reader.ReadInt64();
            //�ԕi�z���v
            temp.RetGoodsTtlPrice = reader.ReadInt64();
            //�l���z���v
            temp.DiscountTtlPrice = reader.ReadInt64();
            //���d���z���v
            temp.PureStockTtlPrice = reader.ReadInt64();


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
        /// <returns>StockDayTotalDataWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockDayTotalDataWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockDayTotalDataWork temp = GetStockDayTotalDataWork(reader, serInfo);
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
                    retValue = (StockDayTotalDataWork[])lst.ToArray(typeof(StockDayTotalDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
