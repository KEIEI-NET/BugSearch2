using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   EnvFullBackupInfWork
    /// <summary>
    ///                      �S�̃o�b�N�A�b�v��񃏁[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �S�̃o�b�N�A�b�v���w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2020/06/15</br>
    /// <br>�Ǘ��ԍ�         :   11670219-00</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class EnvFullBackupInfWork
    {
        /// <summary>�o�b�N�A�b�v�Ώۂ�DB��</summary>
        /// <remarks>DB��</remarks>
        private string _databaseName = "";

        /// <summary>�o�b�N�A�b�v�����t�@�C����</summary>
        /// <remarks>USER_DB��PATH</remarks>
        private string _physicalDeviceName = "";

        /// <summary>�o�b�N�A�b�v�J�n����</summary>
        /// <remarks>DateTime:���x��100�i�m�b</remarks>
        private DateTime _backupStartDate;

        /// <summary>�o�b�N�A�b�v�I������</summary> 
        /// <remarks>DateTime:���x��100�i�m�b</remarks>
        private DateTime _backupFinishDate;

        /// <summary>�o�b�N�A�b�v�Z�b�g�̃T�C�Y</summary>
        /// <remarks>�o�C�g</remarks>
        private Double _backupSize;

        /// <summary>�o�b�N�A�b�v�̎��</summary>
        /// <remarks>D�F�f�[�^�x�[�X�AI�F�f�[�^�x�[�X�̍���</remarks>
        private string _backupType;

        /// <summary>�o�b�N�A�b�v��������Ă���T�[�o��</summary>
        /// <remarks>�o�b�N�A�b�v����[��</remarks>
        private string _serverName;

        /// <summary>SQL Server�����s���Ă���R���s���[�^��</summary>
        /// <remarks>SQL Server�����s�[��</remarks>
        private string _machineName;

        /// public propaty name  :  DatabaseName
        /// <summary>�o�b�N�A�b�v�Ώۂ�DB���v���p�e�B</summary>
        /// <value>�o�b�N�A�b�v�Ώۂ�DB��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�b�N�A�b�v�Ώۂ�DB���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DatabaseName
        {
            get { return _databaseName; }
            set { _databaseName = value; }
        }

        /// public propaty name  :  PhysicalDeviceName
        /// <summary>�o�b�N�A�b�v�����t�@�C�����v���p�e�B</summary>
        /// <value>USER_DB��PATH</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�b�N�A�b�v�����t�@�C�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PhysicalDeviceName
        {
            get { return _physicalDeviceName; }
            set { _physicalDeviceName = value; }
        }

        /// public propaty name  :  BackupStartDate
        /// <summary>�o�b�N�A�b�v�J�n���ԃv���p�e�B</summary>
        /// <value>DateTime:���x��100�i�m�b</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�b�N�A�b�v�J�n���ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime BackupStartDate
        {
            get { return _backupStartDate; }
            set { _backupStartDate = value; }
        }

        /// public propaty name  :  BackupFinishDate
        /// <summary>�o�b�N�A�b�v�I�����ԃv���p�e�B</summary>
        /// <value>DateTime:���x��100�i�m�b</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�b�N�A�b�v�I�����ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime BackupFinishDate
        {
            get { return _backupFinishDate; }
            set { _backupFinishDate = value; }
        }

        /// public propaty name  :  BackupSize
        /// <summary>�o�b�N�A�b�v�Z�b�g�̃T�C�Y</summary>
        /// <value>�o�C�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�b�N�A�b�v�Z�b�g�̃T�C�Y�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double BackupSize
        {
            get { return _backupSize; }
            set { _backupSize = value; }
        }

        /// public propaty name  :  BackupType
        /// <summary>�o�b�N�A�b�v�̎�ރv���p�e�B</summary>
        /// <value>D�F�f�[�^�x�[�X�AI�F�f�[�^�x�[�X�̍���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�b�N�A�b�v�̎�ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BackupType
        {
            get { return _backupType; }
            set { _backupType = value; }
        }

        /// public propaty name  :  ServerName
        /// <summary>�o�b�N�A�b�v��������Ă���T�[�o���v���p�e�B</summary>
        /// <value>�o�b�N�A�b�v��������Ă���T�[�o��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�b�N�A�b�v��������Ă���T�[�o���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ServerName
        {
            get { return _serverName; }
            set { _serverName = value; }
        }

        /// public propaty name  :  MachineName
        /// <summary>SQL Server�����s�R���s���[�^���v���p�e�B</summary>
        /// <value>SQL Server�����s���Ă���R���s���[�^��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SQL Server�����s���Ă���R���s���[�^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MachineName
        {
            get { return _machineName; }
            set { _machineName = value; }
        }

        /// <summary>
        /// �S�̃o�b�N�A�b�v���R���X�g���N�^
        /// </summary>
        /// <returns>EnvFullBackupInfWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EnvFullBackupInfWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public EnvFullBackupInfWork()
        {
        }

        /// <summary>
        /// �S�̃o�b�N�A�b�v��񃏁[�N�R���X�g���N�^
		/// </summary>
		/// <param name="databaseName">�o�b�N�A�b�v�Ώۂ�DB��(DB��)</param>
		/// <param name="physicalDeviceName">�o�b�N�A�b�v�����t�@�C����(USER_DB��PATH)</param>
		/// <param name="backupStartDate">�o�b�N�A�b�v�J�n����(DateTime:���x��100�i�m�b)</param>
		/// <param name="backupFinishDate">�o�b�N�A�b�v�I������(DateTime:���x��100�i�m�b)</param>
		/// <param name="backupSize">�o�b�N�A�b�v�Z�b�g�̃T�C�Y(�o�C�g)</param>
		/// <param name="backupType">�o�b�N�A�b�v�̎��(D�F�f�[�^�x�[�X�AI�F�f�[�^�x�[�X�̍���)</param>
		/// <param name="serverName">�o�b�N�A�b�v��������Ă���T�[�o��(�o�b�N�A�b�v����[��)</param>
		/// <param name="machineName">SQL Server�����s���Ă���R���s���[�^��(SQL Server�����s�[��)</param>
        /// <returns>EnvFullBackupInf�N���X�̃C���X�^���X</returns>
		/// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EnvFullBackupInfWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
        /// </remarks>
        public EnvFullBackupInfWork(string databaseName, string physicalDeviceName, DateTime backupStartDate, DateTime backupFinishDate, Double backupSize, string backupType, string serverName, string machineName)
		{
			this._databaseName = databaseName;
			this._physicalDeviceName = physicalDeviceName;
			this.BackupStartDate = backupStartDate;
			this.BackupFinishDate = backupFinishDate;
			this._backupSize = backupSize;
			this._backupType = backupType;
			this._serverName = serverName;
			this._machineName = machineName;
		}

        /// <summary>
        /// �S�̃o�b�N�A�b�v���
        /// </summary>
        /// <returns>EnvFullBackupInf�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����EnvFullBackupInf�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public EnvFullBackupInfWork Clone()
        {
            return new EnvFullBackupInfWork(this._databaseName, this._physicalDeviceName, this._backupStartDate, this._backupFinishDate, this._backupSize, this._backupType, this._serverName, this._machineName);
        }

    }


    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>EnvFullBackupInfWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   EnvFullBackupInfWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class EnvFullBackupInfWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EnvFullBackupInfWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  EnvFullBackupInfWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is EnvFullBackupInfWork || graph is ArrayList || graph is EnvFullBackupInfWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(EnvFullBackupInfWork).FullName));

            if (graph != null && graph is EnvFullBackupInfWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.EnvFullBackupInfWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is EnvFullBackupInfWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((EnvFullBackupInfWork[])graph).Length;
            }
            else if (graph is EnvFullBackupInfWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�o�b�N�A�b�v�Ώۂ�DB��
            serInfo.MemberInfo.Add(typeof(string)); //DatabaseName
            //�o�b�N�A�b�v�����t�@�C����
            serInfo.MemberInfo.Add(typeof(string)); //PhysicalDeviceName
            //�o�b�N�A�b�v�J�n����
            serInfo.MemberInfo.Add(typeof(Int64)); //BackupStartDate
            //�o�b�N�A�b�v�I������
            serInfo.MemberInfo.Add(typeof(Int64));  //BackupFinishDate
            //�o�b�N�A�b�v�Z�b�g�̃T�C�Y
            serInfo.MemberInfo.Add(typeof(Double)); //BackupSize
            //�o�b�N�A�b�v�̎��
            serInfo.MemberInfo.Add(typeof(Int32)); //BackupType
            //�o�b�N�A�b�v��������Ă���T�[�o��
            serInfo.MemberInfo.Add(typeof(string)); //ServerName
            //SQL Server�����s���Ă���R���s���[�^��
            serInfo.MemberInfo.Add(typeof(string)); //MachineName

            serInfo.Serialize(writer, serInfo);
            if (graph is EnvFullBackupInfWork)
            {
                EnvFullBackupInfWork temp = (EnvFullBackupInfWork)graph;

                SetEnvFullBackupInfWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is EnvFullBackupInfWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((EnvFullBackupInfWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (EnvFullBackupInfWork temp in lst)
                {
                    SetEnvFullBackupInfWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// EnvFullBackupInfWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 8;

        /// <summary>
        ///  EnvFullBackupInfWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EnvFullBackupInfWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetEnvFullBackupInfWork(System.IO.BinaryWriter writer, EnvFullBackupInfWork temp)
        {
            //�o�b�N�A�b�v�Ώۂ�DB��(DB��)
            writer.Write(temp.DatabaseName);
            //�o�b�N�A�b�v�����t�@�C����
            writer.Write(temp.PhysicalDeviceName);
            //�o�b�N�A�b�v�J�n����
            writer.Write((Int64)temp.BackupStartDate.Ticks);
            //�o�b�N�A�b�v�I������
            writer.Write((Int64)temp.BackupFinishDate.Ticks);
            //�o�b�N�A�b�v�Z�b�g�̃T�C�Y
            writer.Write(temp.BackupSize);
            //�o�b�N�A�b�v�̎��
            writer.Write(temp.BackupType);
            //�o�b�N�A�b�v��������Ă���T�[�o��
            writer.Write(temp.ServerName);
            //SQL Server�����s���Ă���R���s���[�^��
            writer.Write(temp.MachineName);
        }

        /// <summary>
        ///  EnvFullBackupInfWork�C���X�^���X�擾
        /// </summary>
        /// <returns>EnvFullBackupInfWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EnvFullBackupInfWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private EnvFullBackupInfWork GetEnvFullBackupInfWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            EnvFullBackupInfWork temp = new EnvFullBackupInfWork();

            //�o�b�N�A�b�v�Ώۂ�DB��(DB��)
            temp.DatabaseName = reader.ReadString();
            //�o�b�N�A�b�v�����t�@�C����
            temp.PhysicalDeviceName = reader.ReadString();
            //�o�b�N�A�b�v�J�n����
            temp.BackupStartDate = new DateTime(reader.ReadInt64());
            //�o�b�N�A�b�v�I������
            temp.BackupFinishDate = new DateTime(reader.ReadInt64());
            //�o�b�N�A�b�v�Z�b�g�̃T�C�Y
            temp.BackupSize = reader.ReadDouble();
            //�o�b�N�A�b�v�̎��
            temp.BackupType = reader.ReadString();
            //�o�b�N�A�b�v��������Ă���T�[�o��
            temp.ServerName = reader.ReadString();
            //�o�b�N�A�b�v��������Ă���T�[�o��
            temp.MachineName = reader.ReadString();

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
        /// <returns>EnvFullBackupInfWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EnvFullBackupInfWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                EnvFullBackupInfWork temp = GetEnvFullBackupInfWork(reader, serInfo);
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
                    retValue = (EnvFullBackupInfWork[])lst.ToArray(typeof(EnvFullBackupInfWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

