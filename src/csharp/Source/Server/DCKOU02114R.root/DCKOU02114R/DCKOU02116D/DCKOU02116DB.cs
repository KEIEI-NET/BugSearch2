using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockDayMonthReportDataWork
    /// <summary>
    ///                       �d�����񌎕�f�[�^���[�N���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :    �d�����񌎕�f�[�^���[�N���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/08/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/09/08 ���̕�</br>
    /// <br>                     PM.NS-2-B�E�o�l�D�m�r�ێ�˗��@</br>
    /// <br>                     �ߋ����\���Ή�</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockDayMonthReportDataWork
    {
        /// <summary>���_�R�[�h</summary>
        /// <remarks>�����ݖ��g�p</remarks>
        private string _sectionCode = "";

        /// <summary>�d���v�㋒�_�R�[�h</summary>
        /// <remarks>�����^ �d���v��Ώۂ̋��_�R�[�h(���_����̎x���v�㋒�_�̂���)</remarks>
        private string _stockAddUpSectionCd = "";

        /// <summary>���_�K�C�h����</summary>
        private string _sectionGuideNm = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";

        /// <summary>�d���`�[�敪�i���ׁj</summary>
        /// <remarks>0:�d��,1:�ԕi,2:�l��</remarks>
        private Int32 _stockSlipCdDtl;

        /// <summary>�d���݌Ɏ�񂹋敪</summary>
        /// <remarks>0:���,1:�݌�</remarks>
        private Int32 _stockOrderDivCd;

        /// <summary>���v�d�����z</summary>
        /// <remarks>�d�����z�i�Ŕ����j</remarks>
        private Int64 _dayStockPriceTaxExc;

        /// <summary>�݌v�d�����z</summary>
        /// <remarks>�d�����z�i�Ŕ����j</remarks>
        private Int64 _monthStockPriceTaxExc;

        // --- ADD 2009/09/08 ---------->>>>>
        /// <summary>�d����,����,���ׂŎg�p</summary>
        /// <remarks>�d����</remarks>
        private Int32 _stockCount;
        // --- ADD 2009/09/08 ----------<<<<<

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>�����ݖ��g�p</value>
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

        /// public propaty name  :  StockAddUpSectionCd
        /// <summary>�d���v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>�����^ �d���v��Ώۂ̋��_�R�[�h(���_����̎x���v�㋒�_�̂���)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���v�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAddUpSectionCd
        {
            get { return _stockAddUpSectionCd; }
            set { _stockAddUpSectionCd = value; }
        }

        /// public propaty name  :  SectionGuideNm
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
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

        /// public propaty name  :  StockSlipCdDtl
        /// <summary>�d���`�[�敪�i���ׁj�v���p�e�B</summary>
        /// <value>0:�d��,1:�ԕi,2:�l��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�敪�i���ׁj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockSlipCdDtl
        {
            get { return _stockSlipCdDtl; }
            set { _stockSlipCdDtl = value; }
        }

        /// public propaty name  :  StockOrderDivCd
        /// <summary>�d���݌Ɏ�񂹋敪�v���p�e�B</summary>
        /// <value>0:���,1:�݌�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���݌Ɏ�񂹋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockOrderDivCd
        {
            get { return _stockOrderDivCd; }
            set { _stockOrderDivCd = value; }
        }

        /// public propaty name  :  DayStockPriceTaxExc
        /// <summary>���v�d�����z�v���p�e�B</summary>
        /// <value>�d�����z�i�Ŕ����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�d�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DayStockPriceTaxExc
        {
            get { return _dayStockPriceTaxExc; }
            set { _dayStockPriceTaxExc = value; }
        }

        /// public propaty name  :  MonthStockPriceTaxExc
        /// <summary>�݌v�d�����z�v���p�e�B</summary>
        /// <value>�d�����z�i�Ŕ����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌v�d�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthStockPriceTaxExc
        {
            get { return _monthStockPriceTaxExc; }
            set { _monthStockPriceTaxExc = value; }
        }


        // --- ADD 2009/09/08 ---------->>>>>
        /// public propaty name  :  OrderCnt
        /// <summary>�d����,����,���ׂŎg�p</summary>
        /// <value>�d����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����</br>
        /// <br>Programer        :   KOIHEI ADD 2009/09/07</br>
        /// </remarks>
        public Int32 StockCount
        {
            get { return _stockCount; }
            set { _stockCount = value; }
        }
        // --- ADD 2009/09/08 ----------<<<<<

        /// <summary>
        ///  �d�����񌎕�f�[�^���[�N���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockDayMonthReportDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockDayMonthReportDataWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockDayMonthReportDataWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>StockDayMonthReportDataWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   StockDayMonthReportDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class StockDayMonthReportDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockDayMonthReportDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockDayMonthReportDataWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockDayMonthReportDataWork || graph is ArrayList || graph is StockDayMonthReportDataWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(StockDayMonthReportDataWork).FullName));

            if (graph != null && graph is StockDayMonthReportDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockDayMonthReportDataWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockDayMonthReportDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockDayMonthReportDataWork[])graph).Length;
            }
            else if (graph is StockDayMonthReportDataWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //�d���v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockAddUpSectionCd
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //�d���`�[�敪�i���ׁj
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSlipCdDtl
            //�d���݌Ɏ�񂹋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockOrderDivCd
            //���v�d�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //DayStockPriceTaxExc
            //�݌v�d�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthStockPriceTaxExc
            // --- ADD 2009/09/08 ---------->>>>> 
            //�d����
            serInfo.MemberInfo.Add(typeof(Double)); //OrderCnt
            // --- ADD 2009/09/08 ----------<<<<<


            serInfo.Serialize(writer, serInfo);
            if (graph is StockDayMonthReportDataWork)
            {
                StockDayMonthReportDataWork temp = (StockDayMonthReportDataWork)graph;

                SetStockDayMonthReportDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockDayMonthReportDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockDayMonthReportDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockDayMonthReportDataWork temp in lst)
                {
                    SetStockDayMonthReportDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockDayMonthReportDataWork�����o��(public�v���p�e�B��)
        /// </summary>
        // --- UPD 2009/09/08 ---------->>>>> 
        //private const int currentMemberCount = 9;
        //�d����
        private const int currentMemberCount = 10;
        // --- UPD 2009/09/08 ----------<<<<<

        /// <summary>
        ///  StockDayMonthReportDataWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockDayMonthReportDataWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note  : 2009/09/08 ���̕� �ߋ����\���Ή�</br>
        /// </remarks>
        private void SetStockDayMonthReportDataWork(System.IO.BinaryWriter writer, StockDayMonthReportDataWork temp)
        {
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //�d���v�㋒�_�R�[�h
            writer.Write(temp.StockAddUpSectionCd);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideNm);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //�d���`�[�敪�i���ׁj
            writer.Write(temp.StockSlipCdDtl);
            //�d���݌Ɏ�񂹋敪
            writer.Write(temp.StockOrderDivCd);
            //���v�d�����z
            writer.Write(temp.DayStockPriceTaxExc);
            //�݌v�d�����z
            writer.Write(temp.MonthStockPriceTaxExc);
            //�d����
            writer.Write(temp.StockCount); // ADD 2009/09/08

        }

        /// <summary>
        ///  StockDayMonthReportDataWork�C���X�^���X�擾
        /// </summary>
        /// <returns>StockDayMonthReportDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockDayMonthReportDataWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note  : 2009/09/08 ���̕� �ߋ����\���Ή�</br>
        /// </remarks>
        private StockDayMonthReportDataWork GetStockDayMonthReportDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            StockDayMonthReportDataWork temp = new StockDayMonthReportDataWork();

            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //�d���v�㋒�_�R�[�h
            temp.StockAddUpSectionCd = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideNm = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //�d���`�[�敪�i���ׁj
            temp.StockSlipCdDtl = reader.ReadInt32();
            //�d���݌Ɏ�񂹋敪
            temp.StockOrderDivCd = reader.ReadInt32();
            //���v�d�����z
            temp.DayStockPriceTaxExc = reader.ReadInt64();
            //�݌v�d�����z
            temp.MonthStockPriceTaxExc = reader.ReadInt64();
            //�d����
            temp.StockCount = reader.ReadInt32(); // ADD 2009/09/08


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
        /// <returns>StockDayMonthReportDataWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockDayMonthReportDataWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockDayMonthReportDataWork temp = GetStockDayMonthReportDataWork(reader, serInfo);
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
                    retValue = (StockDayMonthReportDataWork[])lst.ToArray(typeof(StockDayMonthReportDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
