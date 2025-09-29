using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   EnvFullBackupInfWork
    /// <summary>
    ///                      全体バックアップ情報ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   全体バックアップ情報ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2020/06/15</br>
    /// <br>管理番号         :   11670219-00</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class EnvFullBackupInfWork
    {
        /// <summary>バックアップ対象のDB名</summary>
        /// <remarks>DB名</remarks>
        private string _databaseName = "";

        /// <summary>バックアップ物理ファイル名</summary>
        /// <remarks>USER_DBのPATH</remarks>
        private string _physicalDeviceName = "";

        /// <summary>バックアップ開始時間</summary>
        /// <remarks>DateTime:精度は100ナノ秒</remarks>
        private DateTime _backupStartDate;

        /// <summary>バックアップ終了時間</summary> 
        /// <remarks>DateTime:精度は100ナノ秒</remarks>
        private DateTime _backupFinishDate;

        /// <summary>バックアップセットのサイズ</summary>
        /// <remarks>バイト</remarks>
        private Double _backupSize;

        /// <summary>バックアップの種類</summary>
        /// <remarks>D：データベース、I：データベースの差分</remarks>
        private string _backupType;

        /// <summary>バックアップ操作をしているサーバ名</summary>
        /// <remarks>バックアップ操作端末</remarks>
        private string _serverName;

        /// <summary>SQL Serverを実行しているコンピュータ名</summary>
        /// <remarks>SQL Serverを実行端末</remarks>
        private string _machineName;

        /// public propaty name  :  DatabaseName
        /// <summary>バックアップ対象のDB名プロパティ</summary>
        /// <value>バックアップ対象のDB名</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   バックアップ対象のDB名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DatabaseName
        {
            get { return _databaseName; }
            set { _databaseName = value; }
        }

        /// public propaty name  :  PhysicalDeviceName
        /// <summary>バックアップ物理ファイル名プロパティ</summary>
        /// <value>USER_DBのPATH</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   バックアップ物理ファイル名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PhysicalDeviceName
        {
            get { return _physicalDeviceName; }
            set { _physicalDeviceName = value; }
        }

        /// public propaty name  :  BackupStartDate
        /// <summary>バックアップ開始時間プロパティ</summary>
        /// <value>DateTime:精度は100ナノ秒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   バックアップ開始時間プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime BackupStartDate
        {
            get { return _backupStartDate; }
            set { _backupStartDate = value; }
        }

        /// public propaty name  :  BackupFinishDate
        /// <summary>バックアップ終了時間プロパティ</summary>
        /// <value>DateTime:精度は100ナノ秒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   バックアップ終了時間プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime BackupFinishDate
        {
            get { return _backupFinishDate; }
            set { _backupFinishDate = value; }
        }

        /// public propaty name  :  BackupSize
        /// <summary>バックアップセットのサイズ</summary>
        /// <value>バイト</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   バックアップセットのサイズプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double BackupSize
        {
            get { return _backupSize; }
            set { _backupSize = value; }
        }

        /// public propaty name  :  BackupType
        /// <summary>バックアップの種類プロパティ</summary>
        /// <value>D：データベース、I：データベースの差分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   バックアップの種類プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BackupType
        {
            get { return _backupType; }
            set { _backupType = value; }
        }

        /// public propaty name  :  ServerName
        /// <summary>バックアップ操作をしているサーバ名プロパティ</summary>
        /// <value>バックアップ操作をしているサーバ名</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   バックアップ操作をしているサーバ名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ServerName
        {
            get { return _serverName; }
            set { _serverName = value; }
        }

        /// public propaty name  :  MachineName
        /// <summary>SQL Serverを実行コンピュータ名プロパティ</summary>
        /// <value>SQL Serverを実行しているコンピュータ名</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SQL Serverを実行しているコンピュータ名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MachineName
        {
            get { return _machineName; }
            set { _machineName = value; }
        }

        /// <summary>
        /// 全体バックアップ情報コンストラクタ
        /// </summary>
        /// <returns>EnvFullBackupInfWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EnvFullBackupInfWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public EnvFullBackupInfWork()
        {
        }

        /// <summary>
        /// 全体バックアップ情報ワークコンストラクタ
		/// </summary>
		/// <param name="databaseName">バックアップ対象のDB名(DB名)</param>
		/// <param name="physicalDeviceName">バックアップ物理ファイル名(USER_DBのPATH)</param>
		/// <param name="backupStartDate">バックアップ開始時間(DateTime:精度は100ナノ秒)</param>
		/// <param name="backupFinishDate">バックアップ終了時間(DateTime:精度は100ナノ秒)</param>
		/// <param name="backupSize">バックアップセットのサイズ(バイト)</param>
		/// <param name="backupType">バックアップの種類(D：データベース、I：データベースの差分)</param>
		/// <param name="serverName">バックアップ操作をしているサーバ名(バックアップ操作端末)</param>
		/// <param name="machineName">SQL Serverを実行しているコンピュータ名(SQL Serverを実行端末)</param>
        /// <returns>EnvFullBackupInfクラスのインスタンス</returns>
		/// <remarks>
        /// <br>Note　　　　　　 :   EnvFullBackupInfWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
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
        /// 全体バックアップ情報
        /// </summary>
        /// <returns>EnvFullBackupInfクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいEnvFullBackupInfクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public EnvFullBackupInfWork Clone()
        {
            return new EnvFullBackupInfWork(this._databaseName, this._physicalDeviceName, this._backupStartDate, this._backupFinishDate, this._backupSize, this._backupType, this._serverName, this._machineName);
        }

    }


    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>EnvFullBackupInfWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   EnvFullBackupInfWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class EnvFullBackupInfWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   EnvFullBackupInfWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  EnvFullBackupInfWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is EnvFullBackupInfWork || graph is ArrayList || graph is EnvFullBackupInfWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(EnvFullBackupInfWork).FullName));

            if (graph != null && graph is EnvFullBackupInfWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.EnvFullBackupInfWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
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

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //バックアップ対象のDB名
            serInfo.MemberInfo.Add(typeof(string)); //DatabaseName
            //バックアップ物理ファイル名
            serInfo.MemberInfo.Add(typeof(string)); //PhysicalDeviceName
            //バックアップ開始時間
            serInfo.MemberInfo.Add(typeof(Int64)); //BackupStartDate
            //バックアップ終了時間
            serInfo.MemberInfo.Add(typeof(Int64));  //BackupFinishDate
            //バックアップセットのサイズ
            serInfo.MemberInfo.Add(typeof(Double)); //BackupSize
            //バックアップの種類
            serInfo.MemberInfo.Add(typeof(Int32)); //BackupType
            //バックアップ操作をしているサーバ名
            serInfo.MemberInfo.Add(typeof(string)); //ServerName
            //SQL Serverを実行しているコンピュータ名
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
        /// EnvFullBackupInfWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 8;

        /// <summary>
        ///  EnvFullBackupInfWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   EnvFullBackupInfWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetEnvFullBackupInfWork(System.IO.BinaryWriter writer, EnvFullBackupInfWork temp)
        {
            //バックアップ対象のDB名(DB名)
            writer.Write(temp.DatabaseName);
            //バックアップ物理ファイル名
            writer.Write(temp.PhysicalDeviceName);
            //バックアップ開始時間
            writer.Write((Int64)temp.BackupStartDate.Ticks);
            //バックアップ終了時間
            writer.Write((Int64)temp.BackupFinishDate.Ticks);
            //バックアップセットのサイズ
            writer.Write(temp.BackupSize);
            //バックアップの種類
            writer.Write(temp.BackupType);
            //バックアップ操作をしているサーバ名
            writer.Write(temp.ServerName);
            //SQL Serverを実行しているコンピュータ名
            writer.Write(temp.MachineName);
        }

        /// <summary>
        ///  EnvFullBackupInfWorkインスタンス取得
        /// </summary>
        /// <returns>EnvFullBackupInfWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EnvFullBackupInfWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private EnvFullBackupInfWork GetEnvFullBackupInfWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            EnvFullBackupInfWork temp = new EnvFullBackupInfWork();

            //バックアップ対象のDB名(DB名)
            temp.DatabaseName = reader.ReadString();
            //バックアップ物理ファイル名
            temp.PhysicalDeviceName = reader.ReadString();
            //バックアップ開始時間
            temp.BackupStartDate = new DateTime(reader.ReadInt64());
            //バックアップ終了時間
            temp.BackupFinishDate = new DateTime(reader.ReadInt64());
            //バックアップセットのサイズ
            temp.BackupSize = reader.ReadDouble();
            //バックアップの種類
            temp.BackupType = reader.ReadString();
            //バックアップ操作をしているサーバ名
            temp.ServerName = reader.ReadString();
            //バックアップ操作をしているサーバ名
            temp.MachineName = reader.ReadString();

            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
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
                    object userData = formatter.Deserialize(reader);  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>EnvFullBackupInfWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EnvFullBackupInfWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
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

