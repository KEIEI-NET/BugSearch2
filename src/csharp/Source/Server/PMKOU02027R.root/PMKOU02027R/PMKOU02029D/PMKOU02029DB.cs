using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SlipHistAnalyzeResultWork
    /// <summary>
    ///                      �d�����͕\���o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d�����͕\���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SlipHistAnalyzeResultWork
    {
        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _addUpSecCode = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���[�󎚗p</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";

        /// <summary>�d�����z���v(����)</summary>
        private Int64 _totalPrice;

        /// <summary>�d���ԕi�z(����)</summary>
        private Int64 _retGoodsPrice;

        /// <summary>�d���l���v(����)</summary>
        private Int64 _totalDiscount;

        /// <summary>�d�����z���v(�����݌�)</summary>
        private Int64 _totalPriceStock;

        /// <summary>�d�����z���v(�������v)</summary>
        private Int64 _totalPriceTotal;

        /// <summary>�d�����z���v(����)</summary>
        private Int64 _annualTotalPrice;

        /// <summary>�d���ԕi�z(����)</summary>
        private Int64 _annualRetGoodsPrice;

        /// <summary>�d���l���v(����)</summary>
        private Int64 _annualTotalDiscount;

        /// <summary>�d�����z���v(�����݌�)</summary>
        private Int64 _annualTotalPriceStock;

        /// <summary>�d�����z���v(�������v)</summary>
        private Int64 _annualTotalPriceTotal;


        /// public propaty name  :  AddUpSecCode
        /// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
        }

        /// public propaty name  :  SectionGuideSnm
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// <value>���[�󎚗p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
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

        /// public propaty name  :  SupplierSnm
        /// <summary>�d���旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  TotalPrice
        /// <summary>�d�����z���v(����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z���v(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }

        /// public propaty name  :  RetGoodsPrice
        /// <summary>�d���ԕi�z(����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���ԕi�z(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 RetGoodsPrice
        {
            get { return _retGoodsPrice; }
            set { _retGoodsPrice = value; }
        }

        /// public propaty name  :  TotalDiscount
        /// <summary>�d���l���v(����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���l���v(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalDiscount
        {
            get { return _totalDiscount; }
            set { _totalDiscount = value; }
        }

        /// public propaty name  :  TotalPriceStock
        /// <summary>�d�����z���v(�����݌�)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z���v(�����݌�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalPriceStock
        {
            get { return _totalPriceStock; }
            set { _totalPriceStock = value; }
        }

        /// public propaty name  :  TotalPriceTotal
        /// <summary>�d�����z���v(�������v)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z���v(�������v)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalPriceTotal
        {
            get { return _totalPriceTotal; }
            set { _totalPriceTotal = value; }
        }

        /// public propaty name  :  AnnualTotalPrice
        /// <summary>�d�����z���v(����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z���v(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AnnualTotalPrice
        {
            get { return _annualTotalPrice; }
            set { _annualTotalPrice = value; }
        }

        /// public propaty name  :  AnnualRetGoodsPrice
        /// <summary>�d���ԕi�z(����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���ԕi�z(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AnnualRetGoodsPrice
        {
            get { return _annualRetGoodsPrice; }
            set { _annualRetGoodsPrice = value; }
        }

        /// public propaty name  :  AnnualTotalDiscount
        /// <summary>�d���l���v(����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���l���v(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AnnualTotalDiscount
        {
            get { return _annualTotalDiscount; }
            set { _annualTotalDiscount = value; }
        }

        /// public propaty name  :  AnnualTotalPriceStock
        /// <summary>�d�����z���v(�����݌�)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z���v(�����݌�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AnnualTotalPriceStock
        {
            get { return _annualTotalPriceStock; }
            set { _annualTotalPriceStock = value; }
        }

        /// public propaty name  :  AnnualTotalPriceTotal
        /// <summary>�d�����z���v(�������v)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z���v(�������v)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AnnualTotalPriceTotal
        {
            get { return _annualTotalPriceTotal; }
            set { _annualTotalPriceTotal = value; }
        }


        /// <summary>
        /// �d�����͕\���o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SlipHistAnalyzeResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipHistAnalyzeResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SlipHistAnalyzeResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SlipHistAnalyzeResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SlipHistAnalyzeResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SlipHistAnalyzeResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipHistAnalyzeResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SlipHistAnalyzeResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SlipHistAnalyzeResultWork || graph is ArrayList || graph is SlipHistAnalyzeResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SlipHistAnalyzeResultWork).FullName));

            if (graph != null && graph is SlipHistAnalyzeResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SlipHistAnalyzeResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SlipHistAnalyzeResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SlipHistAnalyzeResultWork[])graph).Length;
            }
            else if (graph is SlipHistAnalyzeResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //�d�����z���v(����)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPrice
            //�d���ԕi�z(����)
            serInfo.MemberInfo.Add(typeof(Int64)); //RetGoodsPrice
            //�d���l���v(����)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalDiscount
            //�d�����z���v(�����݌�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPriceStock
            //�d�����z���v(�������v)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPriceTotal
            //�d�����z���v(����)
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualTotalPrice
            //�d���ԕi�z(����)
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualRetGoodsPrice
            //�d���l���v(����)
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualTotalDiscount
            //�d�����z���v(�����݌�)
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualTotalPriceStock
            //�d�����z���v(�������v)
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualTotalPriceTotal


            serInfo.Serialize(writer, serInfo);
            if (graph is SlipHistAnalyzeResultWork)
            {
                SlipHistAnalyzeResultWork temp = (SlipHistAnalyzeResultWork)graph;

                SetSlipHistAnalyzeResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SlipHistAnalyzeResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SlipHistAnalyzeResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SlipHistAnalyzeResultWork temp in lst)
                {
                    SetSlipHistAnalyzeResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SlipHistAnalyzeResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 14;

        /// <summary>
        ///  SlipHistAnalyzeResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipHistAnalyzeResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSlipHistAnalyzeResultWork(System.IO.BinaryWriter writer, SlipHistAnalyzeResultWork temp)
        {
            //�v�㋒�_�R�[�h
            writer.Write(temp.AddUpSecCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideSnm);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //�d�����z���v(����)
            writer.Write(temp.TotalPrice);
            //�d���ԕi�z(����)
            writer.Write(temp.RetGoodsPrice);
            //�d���l���v(����)
            writer.Write(temp.TotalDiscount);
            //�d�����z���v(�����݌�)
            writer.Write(temp.TotalPriceStock);
            //�d�����z���v(�������v)
            writer.Write(temp.TotalPriceTotal);
            //�d�����z���v(����)
            writer.Write(temp.AnnualTotalPrice);
            //�d���ԕi�z(����)
            writer.Write(temp.AnnualRetGoodsPrice);
            //�d���l���v(����)
            writer.Write(temp.AnnualTotalDiscount);
            //�d�����z���v(�����݌�)
            writer.Write(temp.AnnualTotalPriceStock);
            //�d�����z���v(�������v)
            writer.Write(temp.AnnualTotalPriceTotal);

        }

        /// <summary>
        ///  SlipHistAnalyzeResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SlipHistAnalyzeResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipHistAnalyzeResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SlipHistAnalyzeResultWork GetSlipHistAnalyzeResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SlipHistAnalyzeResultWork temp = new SlipHistAnalyzeResultWork();

            //�v�㋒�_�R�[�h
            temp.AddUpSecCode = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideSnm = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //�d�����z���v(����)
            temp.TotalPrice = reader.ReadInt64();
            //�d���ԕi�z(����)
            temp.RetGoodsPrice = reader.ReadInt64();
            //�d���l���v(����)
            temp.TotalDiscount = reader.ReadInt64();
            //�d�����z���v(�����݌�)
            temp.TotalPriceStock = reader.ReadInt64();
            //�d�����z���v(�������v)
            temp.TotalPriceTotal = reader.ReadInt64();
            //�d�����z���v(����)
            temp.AnnualTotalPrice = reader.ReadInt64();
            //�d���ԕi�z(����)
            temp.AnnualRetGoodsPrice = reader.ReadInt64();
            //�d���l���v(����)
            temp.AnnualTotalDiscount = reader.ReadInt64();
            //�d�����z���v(�����݌�)
            temp.AnnualTotalPriceStock = reader.ReadInt64();
            //�d�����z���v(�������v)
            temp.AnnualTotalPriceTotal = reader.ReadInt64();


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
        /// <returns>SlipHistAnalyzeResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipHistAnalyzeResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SlipHistAnalyzeResultWork temp = GetSlipHistAnalyzeResultWork(reader, serInfo);
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
                    retValue = (SlipHistAnalyzeResultWork[])lst.ToArray(typeof(SlipHistAnalyzeResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
