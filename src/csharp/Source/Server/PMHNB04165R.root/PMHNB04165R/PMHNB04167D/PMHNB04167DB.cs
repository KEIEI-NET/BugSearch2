using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{

    /// public class name:   EmployeeResultsListResultWork
    /// <summary>
    ///                      �S���ҕʎ��яƉ�f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �S���ҕʎ��яƉ�f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/28</br>
    /// <br>Genarated Date   :   2009/04/27  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/9  ����</br>
    /// <br>                 :   ���X�y���~�X�C��</br>
    /// <br>                 :   ����l����ېőΏۊz���v</br>
    /// <br>                 :   ���㐳�����z</br>
    /// <br>                 :   ������z����Ŋz�i�O�Łj</br>
    /// <br>Update Note      :   2008/7/29  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   ���Ӑ�`�[�ԍ�</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class EmployeeResultsListResultWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�]�ƈ��R�[�h</summary>
        private string _employeeCode = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�]�ƈ�����</summary>
        private string _employeeName = "";

        /// <summary>���`�̔���`�[���v�i�Ŕ����j</summary>
        /// <remarks>���`�̔���`�[���v�i�Ŕ����j</remarks>
        private Int64 _backSalesTotalTaxExc;

        /// <summary>�ԕi�`�[�̔���`�[���v�i�Ŕ����j</summary>
        /// <remarks>�ԕi�`�[�̔���`�[���v�i�Ŕ����j</remarks>
        private Int64 _retGoodSalesTotalTaxExc;

        /// <summary>���`�̔���l�����z�v�i�Ŕ����j</summary>
        /// <remarks>���`�̔���l�����z�v�i�Ŕ����j</remarks>
        private Int64 _backSalesDisTtlTaxExc;

        /// <summary>����ڕW���z</summary>
        private Int64 _salesTargetMoney;

        /// <summary>�������z�v</summary>
        private Int64 _totalCost;

        /// <summary>�`�[����</summary>
        private Int32 _slipNumCount;

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

        /// public propaty name  :  EmployeeCode
        /// <summary>�]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
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

        /// public propaty name  :  EmployeeName
        /// <summary>�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }

        /// public propaty name  :  BackSalesTotalTaxExc
        /// <summary>���`�̔���`�[���v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>���`�̔���`�[���v�i�Ŕ����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���`�̔���`�[���v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 BackSalesTotalTaxExc
        {
            get { return _backSalesTotalTaxExc; }
            set { _backSalesTotalTaxExc = value; }
        }

        /// public propaty name  :  RetGoodSalesTotalTaxExc
        /// <summary>�ԕi�`�[�̔���`�[���v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>�ԕi�`�[�̔���`�[���v�i�Ŕ����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�`�[�̔���`�[���v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 RetGoodSalesTotalTaxExc
        {
            get { return _retGoodSalesTotalTaxExc; }
            set { _retGoodSalesTotalTaxExc = value; }
        }

        /// public propaty name  :  BackSalesDisTtlTaxExc
        /// <summary>���`�̔���l�����z�v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>���`�̔���l�����z�v�i�Ŕ����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���`�̔���l�����z�v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 BackSalesDisTtlTaxExc
        {
            get { return _backSalesDisTtlTaxExc; }
            set { _backSalesDisTtlTaxExc = value; }
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

        /// public propaty name  :  TotalCost
        /// <summary>�������z�v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalCost
        {
            get { return _totalCost; }
            set { _totalCost = value; }
        }

        /// public propaty name  :  SlipNumCount
        /// <summary>�`�[�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipNumCount
        {
            get { return _slipNumCount; }
            set { _slipNumCount = value; }
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
        /// �S���ҕʎ��яƉ�f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>EmployeeResultsListResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EmployeeResultsListResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public EmployeeResultsListResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>EmployeeResultsListResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   EmployeeResultsListResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class EmployeeResultsListResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EmployeeResultsListResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  EmployeeResultsListResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is EmployeeResultsListResultWork || graph is ArrayList || graph is EmployeeResultsListResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(EmployeeResultsListResultWork).FullName));

            if (graph != null && graph is EmployeeResultsListResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.EmployeeResultsListResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is EmployeeResultsListResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((EmployeeResultsListResultWork[])graph).Length;
            }
            else if (graph is EmployeeResultsListResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //�]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeName
            //���`�̔���`�[���v�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //BackSalesTotalTaxExc
            //�ԕi�`�[�̔���`�[���v�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //RetGoodSalesTotalTaxExc
            //���`�̔���l�����z�v�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //BackSalesDisTtlTaxExc
            //����ڕW���z
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney
            //�������z�v
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalCost
            //�`�[����
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipNumCount
            //�e�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfit


            serInfo.Serialize(writer, serInfo);
            if (graph is EmployeeResultsListResultWork)
            {
                EmployeeResultsListResultWork temp = (EmployeeResultsListResultWork)graph;

                SetEmployeeResultsListResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is EmployeeResultsListResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((EmployeeResultsListResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (EmployeeResultsListResultWork temp in lst)
                {
                    SetEmployeeResultsListResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// EmployeeResultsListResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 11;

        /// <summary>
        ///  EmployeeResultsListResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EmployeeResultsListResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetEmployeeResultsListResultWork(System.IO.BinaryWriter writer, EmployeeResultsListResultWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //�]�ƈ��R�[�h
            writer.Write(temp.EmployeeCode);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //�]�ƈ�����
            writer.Write(temp.EmployeeName);
            //���`�̔���`�[���v�i�Ŕ����j
            writer.Write(temp.BackSalesTotalTaxExc);
            //�ԕi�`�[�̔���`�[���v�i�Ŕ����j
            writer.Write(temp.RetGoodSalesTotalTaxExc);
            //���`�̔���l�����z�v�i�Ŕ����j
            writer.Write(temp.BackSalesDisTtlTaxExc);
            //����ڕW���z
            writer.Write(temp.SalesTargetMoney);
            //�������z�v
            writer.Write(temp.TotalCost);
            //�`�[����
            writer.Write(temp.SlipNumCount);
            //�e�����z
            writer.Write(temp.GrossProfit);

        }

        /// <summary>
        ///  EmployeeResultsListResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>EmployeeResultsListResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EmployeeResultsListResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private EmployeeResultsListResultWork GetEmployeeResultsListResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            EmployeeResultsListResultWork temp = new EmployeeResultsListResultWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //�]�ƈ��R�[�h
            temp.EmployeeCode = reader.ReadString();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //�]�ƈ�����
            temp.EmployeeName = reader.ReadString();
            //���`�̔���`�[���v�i�Ŕ����j
            temp.BackSalesTotalTaxExc = reader.ReadInt64();
            //�ԕi�`�[�̔���`�[���v�i�Ŕ����j
            temp.RetGoodSalesTotalTaxExc = reader.ReadInt64();
            //���`�̔���l�����z�v�i�Ŕ����j
            temp.BackSalesDisTtlTaxExc = reader.ReadInt64();
            //����ڕW���z
            temp.SalesTargetMoney = reader.ReadInt64();
            //�������z�v
            temp.TotalCost = reader.ReadInt64();
            //�`�[����
            temp.SlipNumCount = reader.ReadInt32();
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
        /// <returns>EmployeeResultsListResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EmployeeResultsListResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                EmployeeResultsListResultWork temp = GetEmployeeResultsListResultWork(reader, serInfo);
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
                    retValue = (EmployeeResultsListResultWork[])lst.ToArray(typeof(EmployeeResultsListResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }




}
