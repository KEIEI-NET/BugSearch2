using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesReportResultWork
    /// <summary>
    ///                      ���㑬��\�����o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���㑬��\�����o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/29  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesReportResultWork 
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���[�󎚗p</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>����`�[���v�i�Ŕ����j</summary>
        /// <remarks>���㐳�����z�{����l�����z�v�i�Ŕ����j</remarks>
        private Int64 _salesTotalTaxExc;

        /// <summary>����ڕW���z</summary>
        private Int64 _salesTargetMoney;

        /// <summary>�B�����i������j</summary>
        private Double _achievementRateNet;

        /// <summary>�e��</summary>
        private Int64 _grossMargin;

        /// <summary>����ڕW�e���z</summary>
        private Int64 _salesTargetProfit;

        /// <summary>�B�����i�e���j</summary>
        private Double _achievementRateGross;

        /// <summary>�ғ���</summary>
        /// <remarks>YYYMMDD</remarks>
        private Int32 _operationDay;

        // --- ADD chenyk 2014/02/21 ------>>>>>
        /// <summary>���Ԃ��܂񂾌��̉ғ���</summary>
        /// <remarks>YYYMMDD</remarks>
        private Int32 _operationDayInRange;
        // --- ADD chenyk 2014/02/21 ------<<<<<

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

        /// public propaty name  :  SalesTotalTaxExc
        /// <summary>����`�[���v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>���㐳�����z�{����l�����z�v�i�Ŕ����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTotalTaxExc
        {
            get { return _salesTotalTaxExc; }
            set { _salesTotalTaxExc = value; }
        }

        /// public propaty name  :  SalesTargetMoney
        /// <summary>����ڕW���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney
        {
            get { return _salesTargetMoney; }
            set { _salesTargetMoney = value; }
        }

        /// public propaty name  :  AchievementRateNet 
        /// <summary>�B�����i������j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �B�����i������j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AchievementRateNet
        {
            get { return _achievementRateNet; }
            set { _achievementRateNet = value; }
        }

        /// public propaty name  :  GrossMargin
        /// <summary>�e���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 GrossMargin
        {
            get { return _grossMargin; }
            set { _grossMargin = value; }
        }

        /// public propaty name  :  SalesTargetProfit
        /// <summary>����ڕW�e���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit
        {
            get { return _salesTargetProfit; }
            set { _salesTargetProfit = value; }
        }

        /// public propaty name  :  AchievementRateGross
        /// <summary>�B�����i�e���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �B�����i�e���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AchievementRateGross
        {
            get { return _achievementRateGross; }
            set { _achievementRateGross = value; }
        }

        /// public propaty name  :  OperationDay
        /// <summary>�ғ����v���p�e�B</summary>
        /// <value>YYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ғ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OperationDay
        {
            get { return _operationDay; }
            set { _operationDay = value; }
        }

        // --- ADD chenyk 2014/02/21 ------>>>>>
        /// public propaty name  :  OperationDayInRange
        /// <summary>���Ԃ��܂񂾌��̉ғ����v���p�e�B</summary>
        /// <value>YYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ԃ��܂񂾌��̉ғ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OperationDayInRange
        {
            get { return _operationDayInRange; }
            set { _operationDayInRange = value; }
        }
        // --- ADD chenyk 2014/02/21 ------<<<<<

        /// <summary>
        /// ���㑬��\�����o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SalesReportResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesReportResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesReportResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SalesReportResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SalesReportResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SalesReportResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesReportResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalesReportResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalesReportResultWork || graph is ArrayList || graph is SalesReportResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SalesReportResultWork).FullName));

            if (graph != null && graph is SalesReportResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalesReportResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalesReportResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalesReportResultWork[])graph).Length;
            }
            else if (graph is SalesReportResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //����`�[���v�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTotalTaxExc
            //����ڕW���z
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney
            //�B�����i������j
            serInfo.MemberInfo.Add(typeof(double)); //AchievementRateNet 
            //�e��
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossMargin
            //����ڕW�e���z
            serInfo.MemberInfo.Add(typeof(double)); //SalesTargetProfit
            //�B�����i�e���j
            serInfo.MemberInfo.Add(typeof(Int64)); //AchievementRateGross
            //�ғ���
            serInfo.MemberInfo.Add(typeof(Int32)); //OperationDay
            // --- ADD chenyk 2014/02/21 ------>>>>>
            //���Ԃ��܂񂾌��̉ғ���
            serInfo.MemberInfo.Add(typeof(Int32)); //OperationDayInRange
            // --- ADD chenyk 2014/02/21 ------<<<<<


            serInfo.Serialize(writer, serInfo);
            if (graph is SalesReportResultWork)
            {
                SalesReportResultWork temp = (SalesReportResultWork)graph;

                SetSalesReportResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalesReportResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalesReportResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalesReportResultWork temp in lst)
                {
                    SetSalesReportResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalesReportResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        //private const int currentMemberCount = 10; // DEL chenyk 2014/02/21
        private const int currentMemberCount = 11; // ADD chenyk 2014/02/21

        /// <summary>
        ///  SalesReportResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesReportResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSalesReportResultWork(System.IO.BinaryWriter writer, SalesReportResultWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideSnm);
            //����`�[���v�i�Ŕ����j
            writer.Write(temp.SalesTotalTaxExc);
            //����ڕW���z
            writer.Write(temp.SalesTargetMoney);
            //�B�����i������j
            writer.Write(temp.AchievementRateNet);
            //�e��
            writer.Write(temp.GrossMargin);
            //����ڕW�e���z
            writer.Write(temp.SalesTargetProfit);
            //�B�����i�e���j
            writer.Write(temp.AchievementRateGross);
            //�ғ���
            writer.Write(temp.OperationDay);
            // --- ADD chenyk 2014/02/21 ------>>>>>
            //���Ԃ��܂񂾌��̉ғ���
            writer.Write(temp.OperationDayInRange);
            // --- ADD chenyk 2014/02/21 ------<<<<<

        }

        /// <summary>
        ///  SalesReportResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SalesReportResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesReportResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SalesReportResultWork GetSalesReportResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SalesReportResultWork temp = new SalesReportResultWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideSnm = reader.ReadString();
            //����`�[���v�i�Ŕ����j
            temp.SalesTotalTaxExc = reader.ReadInt64();
            //����ڕW���z
            temp.SalesTargetMoney = reader.ReadInt64();
            //�B�����i������j
            temp.AchievementRateNet = reader.ReadDouble();
            //�e��
            temp.GrossMargin = reader.ReadInt64();
            //����ڕW�e���z
            temp.SalesTargetProfit = reader.ReadInt64();
            //�B�����i�e���j
            temp.AchievementRateGross = reader.ReadDouble();
            //�ғ���
            temp.OperationDay = reader.ReadInt32();
            // --- ADD chenyk 2014/02/21 ------>>>>>
            //���Ԃ��܂񂾌��̉ғ���
            temp.OperationDayInRange = reader.ReadInt32();
            // --- ADD chenyk 2014/02/21 ------<<<<<


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
        /// <returns>SalesReportResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesReportResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalesReportResultWork temp = GetSalesReportResultWork(reader, serInfo);
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
                    retValue = (SalesReportResultWork[])lst.ToArray(typeof(SalesReportResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}