using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   MonthlyAddUpStatusWork
    /// <summary>
    ///                      �����X�V�L���p�����[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����X�V�L���p�����[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/04/05  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class MonthlyAddUpStatusWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _addUpSecCode = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>�����`�[�����i�ʏ�����j</summary>
        private Int32 _dmdNrmlSlipCnt;

        /// <summary>�����`�[�����i�a����j</summary>
        private Int32 _dmdDepoSlipCnt;

        /// <summary>����`�[����</summary>
        private Int32 _salesSlipCnt;

        /// <summary>�x���C���Z���e�B�u����</summary>
        private Int32 _incDstrbtCnt;

        /// <summary>�x���`�[�����i�ʏ�x���j</summary>
        private Int32 _payNrmlSlipCnt;

        /// <summary>�d���`�[����</summary>
        private Int32 _supplierSlipCnt;

        /// <summary>�ԕi�`�[����</summary>
        private Int32 _retGoodsSlipCnt;

        /// <summary>�X�V�X�e�[�^�X</summary>
        /// <remarks>0:�X�V,1:���X�V</remarks>
        private Int32 _updateStatus;

        /// <summary>�v��N����</summary>
        /// <remarks>YYYYMMDD ���В����s�Ȃ������i���В��ߊ�j</remarks>
        private DateTime _addUpDate;

        /// <summary>�v��N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>�����X�V���s�N����</summary>
        /// <remarks>YYYYMMDD�@�����X�V���s�N����</remarks>
        private DateTime _monthAddUpExpDate;


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

        /// public propaty name  :  ResultsAddUpSecCd
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

        /// public propaty name  :  SupplierCd
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  DmdNrmlSlipCnt
        /// <summary>�����`�[�����i�ʏ�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�����i�ʏ�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DmdNrmlSlipCnt
        {
            get { return _dmdNrmlSlipCnt; }
            set { _dmdNrmlSlipCnt = value; }
        }

        /// public propaty name  :  DmdDepoSlipCnt
        /// <summary>�����`�[�����i�a����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�����i�a����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DmdDepoSlipCnt
        {
            get { return _dmdDepoSlipCnt; }
            set { _dmdDepoSlipCnt = value; }
        }

        /// public propaty name  :  SalesSlipCnt
        /// <summary>����`�[�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesSlipCnt
        {
            get { return _salesSlipCnt; }
            set { _salesSlipCnt = value; }
        }

        /// public propaty name  :  IncDstrbtCnt
        /// <summary>�x���C���Z���e�B�u�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���C���Z���e�B�u�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 IncDstrbtCnt
        {
            get { return _incDstrbtCnt; }
            set { _incDstrbtCnt = value; }
        }

        /// public propaty name  :  PayNrmlSlipCnt
        /// <summary>�x���`�[�����i�ʏ�x���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���`�[�����i�ʏ�x���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayNrmlSlipCnt
        {
            get { return _payNrmlSlipCnt; }
            set { _payNrmlSlipCnt = value; }
        }

        /// public propaty name  :  SupplierSlipCnt
        /// <summary>�d���`�[�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierSlipCnt
        {
            get { return _supplierSlipCnt; }
            set { _supplierSlipCnt = value; }
        }

        /// public propaty name  :  RetGoodsSlipCnt
        /// <summary>�ԕi�`�[�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�`�[�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RetGoodsSlipCnt
        {
            get { return _retGoodsSlipCnt; }
            set { _retGoodsSlipCnt = value; }
        }

        /// public propaty name  :  UpdateStatus
        /// <summary>�X�V�X�e�[�^�X�v���p�e�B</summary>
        /// <value>0:�X�V,1:���X�V</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UpdateStatus
        {
            get { return _updateStatus; }
            set { _updateStatus = value; }
        }

        /// public propaty name  :  AddUpDate
        /// <summary>�v��N�����v���p�e�B</summary>
        /// <value>YYYYMMDD ���В����s�Ȃ������i���В��ߊ�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpDate
        {
            get { return _addUpDate; }
            set { _addUpDate = value; }
        }

        /// public propaty name  :  SalesDate
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

        /// public propaty name  :  MonthAddUpExpDate
        /// <summary>�����X�V���s�N�����v���p�e�B</summary>
        /// <value>YYYYMMDD�@�����X�V���s�N����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V���s�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime MonthAddUpExpDate
        {
            get { return _monthAddUpExpDate; }
            set { _monthAddUpExpDate = value; }
        }


        /// <summary>
        /// �����X�V�L���p�����[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>MonthlyAddUpStatusWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MonthlyAddUpStatusWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MonthlyAddUpStatusWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>MonthlyAddUpStatusWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   MonthlyAddUpStatusWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class MonthlyAddUpStatusWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MonthlyAddUpStatusWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  MonthlyAddUpStatusWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is MonthlyAddUpStatusWork || graph is ArrayList || graph is MonthlyAddUpStatusWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(MonthlyAddUpStatusWork).FullName));

            if (graph != null && graph is MonthlyAddUpStatusWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.MonthlyAddUpStatusWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is MonthlyAddUpStatusWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((MonthlyAddUpStatusWork[])graph).Length;
            }
            else if (graph is MonthlyAddUpStatusWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //ResultsAddUpSecCd
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�����`�[�����i�ʏ�����j
            serInfo.MemberInfo.Add(typeof(Int32)); //DmdNrmlSlipCnt
            //�����`�[�����i�a����j
            serInfo.MemberInfo.Add(typeof(Int32)); //DmdDepoSlipCnt
            //����`�[����
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCnt
            //�x���C���Z���e�B�u����
            serInfo.MemberInfo.Add(typeof(Int32)); //IncDstrbtCnt
            //�x���`�[�����i�ʏ�x���j
            serInfo.MemberInfo.Add(typeof(Int32)); //PayNrmlSlipCnt
            //�d���`�[����
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipCnt
            //�ԕi�`�[����
            serInfo.MemberInfo.Add(typeof(Int32)); //RetGoodsSlipCnt
            //�X�V�X�e�[�^�X
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateStatus
            //�v��N����
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpDate
            //�v��N��
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //�����X�V���s�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //MonthAddUpExpDate


            serInfo.Serialize(writer, serInfo);
            if (graph is MonthlyAddUpStatusWork)
            {
                MonthlyAddUpStatusWork temp = (MonthlyAddUpStatusWork)graph;

                SetMonthlyAddUpStatusWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is MonthlyAddUpStatusWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((MonthlyAddUpStatusWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (MonthlyAddUpStatusWork temp in lst)
                {
                    SetMonthlyAddUpStatusWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// MonthlyAddUpStatusWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 14;

        /// <summary>
        ///  MonthlyAddUpStatusWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MonthlyAddUpStatusWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetMonthlyAddUpStatusWork(System.IO.BinaryWriter writer, MonthlyAddUpStatusWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //�v�㋒�_�R�[�h
            writer.Write(temp.AddUpSecCode);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //�����`�[�����i�ʏ�����j
            writer.Write(temp.DmdNrmlSlipCnt);
            //�����`�[�����i�a����j
            writer.Write(temp.DmdDepoSlipCnt);
            //����`�[����
            writer.Write(temp.SalesSlipCnt);
            //�x���C���Z���e�B�u����
            writer.Write(temp.IncDstrbtCnt);
            //�x���`�[�����i�ʏ�x���j
            writer.Write(temp.PayNrmlSlipCnt);
            //�d���`�[����
            writer.Write(temp.SupplierSlipCnt);
            //�ԕi�`�[����
            writer.Write(temp.RetGoodsSlipCnt);
            //�X�V�X�e�[�^�X
            writer.Write(temp.UpdateStatus);
            //�v��N����
            writer.Write((Int64)temp.AddUpDate.Ticks);
            //�v��N��
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //�����X�V���s�N����
            writer.Write((Int64)temp.MonthAddUpExpDate.Ticks);

        }

        /// <summary>
        ///  MonthlyAddUpStatusWork�C���X�^���X�擾
        /// </summary>
        /// <returns>MonthlyAddUpStatusWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MonthlyAddUpStatusWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private MonthlyAddUpStatusWork GetMonthlyAddUpStatusWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            MonthlyAddUpStatusWork temp = new MonthlyAddUpStatusWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //�v�㋒�_�R�[�h
            temp.AddUpSecCode = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //�����`�[�����i�ʏ�����j
            temp.DmdNrmlSlipCnt = reader.ReadInt32();
            //�����`�[�����i�a����j
            temp.DmdDepoSlipCnt = reader.ReadInt32();
            //����`�[����
            temp.SalesSlipCnt = reader.ReadInt32();
            //�x���C���Z���e�B�u����
            temp.IncDstrbtCnt = reader.ReadInt32();
            //�x���`�[�����i�ʏ�x���j
            temp.PayNrmlSlipCnt = reader.ReadInt32();
            //�d���`�[����
            temp.SupplierSlipCnt = reader.ReadInt32();
            //�ԕi�`�[����
            temp.RetGoodsSlipCnt = reader.ReadInt32();
            //�X�V�X�e�[�^�X
            temp.UpdateStatus = reader.ReadInt32();
            //�v��N����
            temp.AddUpDate = new DateTime(reader.ReadInt64());
            //�v��N��
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //�����X�V���s�N����
            temp.MonthAddUpExpDate = new DateTime(reader.ReadInt64());


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
        /// <returns>MonthlyAddUpStatusWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MonthlyAddUpStatusWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                MonthlyAddUpStatusWork temp = GetMonthlyAddUpStatusWork(reader, serInfo);
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
                    retValue = (MonthlyAddUpStatusWork[])lst.ToArray(typeof(MonthlyAddUpStatusWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
