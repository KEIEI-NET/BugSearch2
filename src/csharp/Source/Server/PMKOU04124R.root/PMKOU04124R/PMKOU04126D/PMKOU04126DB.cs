using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SuppYearResultSuppResultWork
    /// <summary>
    ///                      �d���N�Ԏ��яƉ�(���яƉ�)���o���ʃN���X���[�N���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d���N�Ԏ��яƉ�(���яƉ�)���o���ʃN���X���[�N���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SuppYearResultSuppResultWork
    {
        /// <summary>�v��N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>�d�����z�i�Ŕ����j(�݌�)</summary>
        private Int64 _st_StockPriceTaxExc;

        /// <summary>�d���ԕi�z(�݌�)</summary>
        private Int64 _st_StockRetGoodsPrice;

        /// <summary>�d���l���v(�݌�)</summary>
        private Int64 _st_StockTotalDiscount;

        /// <summary>�d�����z����Ŋz�i�݌Ɂj</summary>
        private Int64 _st_StockPriceConsTax;

        /// <summary>�d�����z�i�Ŕ����j(���)</summary>
        private Int64 _or_StockPriceTaxExc;

        /// <summary>�d���ԕi�z(���)</summary>
        private Int64 _or_StockRetGoodsPrice;

        /// <summary>�d���l���v(���)</summary>
        private Int64 _or_StockTotalDiscount;

        /// <summary>�d�����z����Ŋz�i�݌Ɂj</summary>
        private Int64 _or_StockPriceConsTax;

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>���_�R�[�h</summary>
        private string _stockSectionCd;

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>���_����</summary>
        private string _sectionGuideNm;

        /// <summary>�d���於��</summary>
        private string _supplierNm;
        // --- ADD 2010/07/20--------------------------------<<<<<


        /// public propaty name  :  AddUpYearMonth
        /// <summary>�v��N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpYearMonth
        {
            get { return _addUpYearMonth; }
            set { _addUpYearMonth = value; }
        }

        /// public propaty name  :  St_StockPriceTaxExc
        /// <summary>�d�����z�i�Ŕ����j(�݌�)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z�i�Ŕ����j(�݌�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 St_StockPriceTaxExc
        {
            get { return _st_StockPriceTaxExc; }
            set { _st_StockPriceTaxExc = value; }
        }

        /// public propaty name  :  St_StockRetGoodsPrice
        /// <summary>�d���ԕi�z(�݌�)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���ԕi�z(�݌�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 St_StockRetGoodsPrice
        {
            get { return _st_StockRetGoodsPrice; }
            set { _st_StockRetGoodsPrice = value; }
        }

        /// public propaty name  :  St_StockTotalDiscount
        /// <summary>�d���l���v(�݌�)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���l���v(�݌�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 St_StockTotalDiscount
        {
            get { return _st_StockTotalDiscount; }
            set { _st_StockTotalDiscount = value; }
        }

        /// public propaty name  :  St_StockPriceConsTax
        /// <summary>�d�����z����Ŋz�i�݌Ɂj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z����Ŋz�i�݌Ɂj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 St_StockPriceConsTax
        {
            get { return _st_StockPriceConsTax; }
            set { _st_StockPriceConsTax = value; }
        }

        /// public propaty name  :  Or_StockPriceTaxExc
        /// <summary>�d�����z�i�Ŕ����j(���)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z�i�Ŕ����j(���)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Or_StockPriceTaxExc
        {
            get { return _or_StockPriceTaxExc; }
            set { _or_StockPriceTaxExc = value; }
        }

        /// public propaty name  :  Or_StockRetGoodsPrice
        /// <summary>�d���ԕi�z(���)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���ԕi�z(���)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Or_StockRetGoodsPrice
        {
            get { return _or_StockRetGoodsPrice; }
            set { _or_StockRetGoodsPrice = value; }
        }

        /// public propaty name  :  Or_StockTotalDiscount
        /// <summary>�d���l���v(���)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���l���v(���)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Or_StockTotalDiscount
        {
            get { return _or_StockTotalDiscount; }
            set { _or_StockTotalDiscount = value; }
        }

        /// public propaty name  :  Or_StockPriceConsTax
        /// <summary>�d�����z����Ŋz�i�݌Ɂj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z����Ŋz�i�݌Ɂj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Or_StockPriceConsTax
        {
            get { return _or_StockPriceConsTax; }
            set { _or_StockPriceConsTax = value; }
        }

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// public propaty name  :  StockSectionCd
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockSectionCd
        {
            get { return _stockSectionCd; }
            set { _stockSectionCd = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SectionGuideNm
        /// <summary>���_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  SectionGuideNm
        /// <summary>�d���於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierNm
        {
            get { return _supplierNm; }
            set { _supplierNm = value; }
        }
        // --- ADD 2010/07/20--------------------------------<<<<<

        /// <summary>
        /// �d���N�Ԏ��яƉ�(���яƉ�)���o���ʃN���X���[�N���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SuppYearResultSuppResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppYearResultSuppResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SuppYearResultSuppResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SuppYearResultSuppResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SuppYearResultSuppResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SuppYearResultSuppResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppYearResultSuppResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SuppYearResultSuppResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SuppYearResultSuppResultWork || graph is ArrayList || graph is SuppYearResultSuppResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SuppYearResultSuppResultWork).FullName));

            if (graph != null && graph is SuppYearResultSuppResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SuppYearResultSuppResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SuppYearResultSuppResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SuppYearResultSuppResultWork[])graph).Length;
            }
            else if (graph is SuppYearResultSuppResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�v��N��
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpYearMonth
            //�d�����z�i�Ŕ����j(�݌�)
            serInfo.MemberInfo.Add(typeof(Int64)); //St_StockPriceTaxExc
            //�d���ԕi�z(�݌�)
            serInfo.MemberInfo.Add(typeof(Int64)); //St_StockRetGoodsPrice
            //�d���l���v(�݌�)
            serInfo.MemberInfo.Add(typeof(Int64)); //St_StockTotalDiscount
            //�d�����z����Ŋz�i�݌Ɂj
            serInfo.MemberInfo.Add(typeof(Int64)); //St_StockPriceConsTax
            //�d�����z�i�Ŕ����j(���)
            serInfo.MemberInfo.Add(typeof(Int64)); //Or_StockPriceTaxExc
            //�d���ԕi�z(���)
            serInfo.MemberInfo.Add(typeof(Int64)); //Or_StockRetGoodsPrice
            //�d���l���v(���)
            serInfo.MemberInfo.Add(typeof(Int64)); //Or_StockTotalDiscount
            //�d�����z����Ŋz�i�݌Ɂj
            serInfo.MemberInfo.Add(typeof(Int64)); //Or_StockPriceConsTax

            // --- ADD 2010/07/20-------------------------------->>>>>
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(String)); //StockSectionCd
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //���_����
            serInfo.MemberInfo.Add(typeof(String)); //SectionGuideNm
            //�d���於��
            serInfo.MemberInfo.Add(typeof(String)); //SupplierNm
            // --- ADD 2010/07/20--------------------------------<<<<<


            serInfo.Serialize(writer, serInfo);
            if (graph is SuppYearResultSuppResultWork)
            {
                SuppYearResultSuppResultWork temp = (SuppYearResultSuppResultWork)graph;

                SetSuppYearResultSuppResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SuppYearResultSuppResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SuppYearResultSuppResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SuppYearResultSuppResultWork temp in lst)
                {
                    SetSuppYearResultSuppResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SuppYearResultSuppResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        // private const int currentMemberCount = 9; // DEL 2010/07/20
        private const int currentMemberCount = 13; // ADD 2010/07/20

        /// <summary>
        ///  SuppYearResultSuppResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppYearResultSuppResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSuppYearResultSuppResultWork(System.IO.BinaryWriter writer, SuppYearResultSuppResultWork temp)
        {
            //�v��N��
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //�d�����z�i�Ŕ����j(�݌�)
            writer.Write(temp.St_StockPriceTaxExc);
            //�d���ԕi�z(�݌�)
            writer.Write(temp.St_StockRetGoodsPrice);
            //�d���l���v(�݌�)
            writer.Write(temp.St_StockTotalDiscount);
            //�d�����z����Ŋz�i�݌Ɂj
            writer.Write(temp.St_StockPriceConsTax);
            //�d�����z�i�Ŕ����j(���)
            writer.Write(temp.Or_StockPriceTaxExc);
            //�d���ԕi�z(���)
            writer.Write(temp.Or_StockRetGoodsPrice);
            //�d���l���v(���)
            writer.Write(temp.Or_StockTotalDiscount);
            //�d�����z����Ŋz�i�݌Ɂj
            writer.Write(temp.Or_StockPriceConsTax);

            // --- ADD 2010/07/20-------------------------------->>>>>
            //���_�R�[�h
            writer.Write(temp.StockSectionCd);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //���_����
            writer.Write(temp.SectionGuideNm);
            //�d���於��
            writer.Write(temp.SupplierNm);
            // --- ADD 2010/07/20--------------------------------<<<<<

        }

        /// <summary>
        ///  SuppYearResultSuppResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SuppYearResultSuppResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppYearResultSuppResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SuppYearResultSuppResultWork GetSuppYearResultSuppResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SuppYearResultSuppResultWork temp = new SuppYearResultSuppResultWork();

            //�v��N��
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //�d�����z�i�Ŕ����j(�݌�)
            temp.St_StockPriceTaxExc = reader.ReadInt64();
            //�d���ԕi�z(�݌�)
            temp.St_StockRetGoodsPrice = reader.ReadInt64();
            //�d���l���v(�݌�)
            temp.St_StockTotalDiscount = reader.ReadInt64();
            //�d�����z����Ŋz�i�݌Ɂj
            temp.St_StockPriceConsTax = reader.ReadInt64();
            //�d�����z�i�Ŕ����j(���)
            temp.Or_StockPriceTaxExc = reader.ReadInt64();
            //�d���ԕi�z(���)
            temp.Or_StockRetGoodsPrice = reader.ReadInt64();
            //�d���l���v(���)
            temp.Or_StockTotalDiscount = reader.ReadInt64();
            //�d�����z����Ŋz�i�݌Ɂj
            temp.Or_StockPriceConsTax = reader.ReadInt64();

            // --- ADD 2010/07/20-------------------------------->>>>>
            //���_�R�[�h
            temp.StockSectionCd = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //���_����
            temp.SectionGuideNm = reader.ReadString();
            //�d���於��
            temp.SupplierNm = reader.ReadString();
            // --- ADD 2010/07/20--------------------------------<<<<<


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
        /// <returns>SuppYearResultSuppResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppYearResultSuppResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SuppYearResultSuppResultWork temp = GetSuppYearResultSuppResultWork(reader, serInfo);
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
                    retValue = (SuppYearResultSuppResultWork[])lst.ToArray(typeof(SuppYearResultSuppResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
