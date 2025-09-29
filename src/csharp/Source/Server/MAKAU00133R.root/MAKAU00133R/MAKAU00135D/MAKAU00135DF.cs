using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   MTtlSumCompWork
    /// <summary>
    ///                      �����W�v��ƊǗ��e�[�u�����[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����W�v��ƊǗ��e�[�u�����[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2006/12/04</br>
    /// <br>Genarated Date   :   2008/02/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2006/12/04  �����@����</br>
    /// <br>                 :   �e�[�u�����̂�C�Ӌ��_�͈͐ݒ�}�X�^</br>
    /// <br>                 :   (VolSecAbtRF)����W�v���_�O���[�v</br>
    /// <br>                 :   �}�X�^(SumGrpRF)�ɕύX�B</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class MTtlSumCompWork
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�Ώۃp�b�P�[�W</summary>
        private string _packageName = "";

        /// <summary>�W�v���[�h</summary>
        /// <remarks>0�F�W�v�A�P�F�������W�v</remarks>
        private Int32 _summarizeMode;

        /// <summary>�W�v�Ώ۔N�����i�J�n�j</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _summarizeStaYeMon;

        /// <summary>�W�v�Ώ۔N�����i�I���j</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _summarizeEndYeMon;

        /// <summary>�v��N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>�X�P�W���[������</summary>
        /// <remarks>�W�v���s���iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _scheduleDateTime;

        /// <summary>�W�v������</summary>
        /// <remarks>�W�v������</remarks>
        private DateTime _isSummarized;

        /// <summary>DWH�W�v������</summary>
        /// <remarks>�c�v�g�W�v�������i�ް����ʳ��p�W�v�Ɏd�l����j</remarks>
        private DateTime _isDwhSummarized;


        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�_���폜�敪�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

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

        /// public propaty name  :  PackageName
        /// <summary>�Ώۃp�b�P�[�W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ώۃp�b�P�[�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PackageName
        {
            get { return _packageName; }
            set { _packageName = value; }
        }

        /// public propaty name  :  SummarizeMode
        /// <summary>�W�v���[�h�v���p�e�B</summary>
        /// <value>0�F�W�v�A�P�F�������W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�v���[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SummarizeMode
        {
            get { return _summarizeMode; }
            set { _summarizeMode = value; }
        }

        /// public propaty name  :  SummarizeStaYeMon
        /// <summary>�W�v�Ώ۔N�����i�J�n�j�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�v�Ώ۔N�����i�J�n�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SummarizeStaYeMon
        {
            get { return _summarizeStaYeMon; }
            set { _summarizeStaYeMon = value; }
        }

        /// public propaty name  :  SummarizeEndYeMon
        /// <summary>�W�v�Ώ۔N�����i�I���j�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�v�Ώ۔N�����i�I���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SummarizeEndYeMon
        {
            get { return _summarizeEndYeMon; }
            set { _summarizeEndYeMon = value; }
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

        /// public propaty name  :  ScheduleDateTime
        /// <summary>�X�P�W���[�������v���p�e�B</summary>
        /// <value>�W�v���s���iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�P�W���[�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ScheduleDateTime
        {
            get { return _scheduleDateTime; }
            set { _scheduleDateTime = value; }
        }

        /// public propaty name  :  IsSummarized
        /// <summary>�W�v�������v���p�e�B</summary>
        /// <value>�W�v������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�v�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime IsSummarized
        {
            get { return _isSummarized; }
            set { _isSummarized = value; }
        }

        /// public propaty name  :  IsDwhSummarized
        /// <summary>DWH�W�v�������v���p�e�B</summary>
        /// <value>�c�v�g�W�v�������i�ް����ʳ��p�W�v�Ɏd�l����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   DWH�W�v�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime IsDwhSummarized
        {
            get { return _isDwhSummarized; }
            set { _isDwhSummarized = value; }
        }


        /// <summary>
        /// �����W�v��ƊǗ��e�[�u�����[�N�R���X�g���N�^
        /// </summary>
        /// <returns>MTtlSumCompWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MTtlSumCompWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MTtlSumCompWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>MTtlSumCompWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   MTtlSumCompWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class MTtlSumCompWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MTtlSumCompWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  MTtlSumCompWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is MTtlSumCompWork || graph is ArrayList || graph is MTtlSumCompWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(MTtlSumCompWork).FullName));

            if (graph != null && graph is MTtlSumCompWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.MTtlSumCompWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is MTtlSumCompWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((MTtlSumCompWork[])graph).Length;
            }
            else if (graph is MTtlSumCompWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //�Ώۃp�b�P�[�W
            serInfo.MemberInfo.Add(typeof(string)); //PackageName
            //�W�v���[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SummarizeMode
            //�W�v�Ώ۔N�����i�J�n�j
            serInfo.MemberInfo.Add(typeof(Int32)); //SummarizeStaYeMon
            //�W�v�Ώ۔N�����i�I���j
            serInfo.MemberInfo.Add(typeof(Int32)); //SummarizeEndYeMon
            //�v��N��
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //�X�P�W���[������
            serInfo.MemberInfo.Add(typeof(Int64)); //ScheduleDateTime
            //�W�v������
            serInfo.MemberInfo.Add(typeof(Int32)); //IsSummarized
            //DWH�W�v������
            serInfo.MemberInfo.Add(typeof(Int32)); //IsDwhSummarized


            serInfo.Serialize(writer, serInfo);
            if (graph is MTtlSumCompWork)
            {
                MTtlSumCompWork temp = (MTtlSumCompWork)graph;

                SetMTtlSumCompWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is MTtlSumCompWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((MTtlSumCompWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (MTtlSumCompWork temp in lst)
                {
                    SetMTtlSumCompWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// MTtlSumCompWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 12;

        /// <summary>
        ///  MTtlSumCompWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MTtlSumCompWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetMTtlSumCompWork(System.IO.BinaryWriter writer, MTtlSumCompWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //�Ώۃp�b�P�[�W
            writer.Write(temp.PackageName);
            //�W�v���[�h
            writer.Write(temp.SummarizeMode);
            //�W�v�Ώ۔N�����i�J�n�j
            writer.Write((Int64)temp.SummarizeStaYeMon.Ticks);
            //�W�v�Ώ۔N�����i�I���j
            writer.Write((Int64)temp.SummarizeEndYeMon.Ticks);
            //�v��N��
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //�X�P�W���[������
            writer.Write((Int64)temp.ScheduleDateTime.Ticks);
            //�W�v������
            writer.Write((Int64)temp.IsSummarized.Ticks);
            //DWH�W�v������
            writer.Write((Int64)temp.IsDwhSummarized.Ticks);

        }

        /// <summary>
        ///  MTtlSumCompWork�C���X�^���X�擾
        /// </summary>
        /// <returns>MTtlSumCompWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MTtlSumCompWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private MTtlSumCompWork GetMTtlSumCompWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            MTtlSumCompWork temp = new MTtlSumCompWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //�Ώۃp�b�P�[�W
            temp.PackageName = reader.ReadString();
            //�W�v���[�h
            temp.SummarizeMode = reader.ReadInt32();
            //�W�v�Ώ۔N�����i�J�n�j
            temp.SummarizeStaYeMon = new DateTime(reader.ReadInt64());
            //�W�v�Ώ۔N�����i�I���j
            temp.SummarizeEndYeMon = new DateTime(reader.ReadInt64());
            //�v��N��
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //�X�P�W���[������
            temp.ScheduleDateTime = new DateTime(reader.ReadInt64());
            //�W�v������
            temp.IsSummarized = new DateTime(reader.ReadInt64());
            //DWH�W�v������
            temp.IsDwhSummarized = new DateTime(reader.ReadInt64());


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
        /// <returns>MTtlSumCompWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MTtlSumCompWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                MTtlSumCompWork temp = GetMTtlSumCompWork(reader, serInfo);
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
                    retValue = (MTtlSumCompWork[])lst.ToArray(typeof(MTtlSumCompWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
