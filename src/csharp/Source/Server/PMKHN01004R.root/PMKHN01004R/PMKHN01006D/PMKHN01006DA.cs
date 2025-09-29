//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データクリア処理
// プログラム概要   : データクリア処理ワーク
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/06/16  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   DataClearWork
	/// <summary>
	///                      データクリアワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   データクリアワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2008/06/18</br>
	/// <br>Genarated Date   :   2009/06/18  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class DataClearWork
	{
		/// <summary>テーブルID</summary>
		private string _tableId = "";

		/// <summary>テーブル名</summary>
		private string _tableNm = "";

		/// <summary>チェックかどうか</summary>
		private bool _isChecked;

		/// <summary>処理コード</summary>
		private Int32 _clearCode;

		/// <summary>処理フィールド</summary>
		private string _fileId = "";

		/// <summary>処理結果</summary>
		private string _result = "";


		/// public propaty name  :  TableId
		/// <summary>テーブルIDプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   テーブルIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TableId
		{
			get{return _tableId;}
			set{_tableId = value;}
		}

		/// public propaty name  :  TableNm
		/// <summary>テーブル名プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   テーブル名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TableNm
		{
			get{return _tableNm;}
			set{_tableNm = value;}
		}

		/// public propaty name  :  IsChecked
		/// <summary>チェックかどうかプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   チェックかどうかプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool IsChecked
		{
			get{return _isChecked;}
			set{_isChecked = value;}
		}

		/// public propaty name  :  ClearCode
		/// <summary>処理コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   処理コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ClearCode
		{
			get{return _clearCode;}
			set{_clearCode = value;}
		}

		/// public propaty name  :  FileId
		/// <summary>処理フィールドプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   処理フィールドプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string FileId
		{
			get{return _fileId;}
			set{_fileId = value;}
		}

        /// public propaty name  :  Result
		/// <summary>処理結果プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   処理結果プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public string Result
		{
            get { return _result; }
            set { _result = value; }
		}

		/// <summary>
		/// データクリアワークコンストラクタ
		/// </summary>
		/// <returns>DataClearWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   DataClearWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DataClearWork()
		{
		}
	}

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>DataClearWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   DataClearWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class DataClearWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   DataClearWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  DataClearWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is DataClearWork || graph is ArrayList || graph is DataClearWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(DataClearWork).FullName));

            if (graph != null && graph is DataClearWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.DataClearWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is DataClearWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((DataClearWork[])graph).Length;
            }
            else if (graph is DataClearWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //テーブルID
            serInfo.MemberInfo.Add(typeof(string)); //TableId
            //テーブル名
            serInfo.MemberInfo.Add(typeof(string)); //TableNm
            //チェックかどうか
            serInfo.MemberInfo.Add(typeof(bool));   //IsChecked
            //処理コード
            serInfo.MemberInfo.Add(typeof(Int32)); //ClearCode
            //処理フィールド
            serInfo.MemberInfo.Add(typeof(string)); //FileId
            //処理結果
            serInfo.MemberInfo.Add(typeof(string)); //Result


            serInfo.Serialize(writer, serInfo);
            if (graph is DataClearWork)
            {
                DataClearWork temp = (DataClearWork)graph;

                SetDataClearWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is DataClearWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((DataClearWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (DataClearWork temp in lst)
                {
                    SetDataClearWork(writer, temp);
                }

            }


        }

        /// <summary>
        /// DataClearWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 6;

        /// <summary>
        ///  DataClearWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   DataClearWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetDataClearWork(System.IO.BinaryWriter writer, DataClearWork temp)
        {
            //テーブルID
            writer.Write(temp.TableId);
            //テーブル名
            writer.Write(temp.TableNm);
            //チェックかどうか
            writer.Write(temp.IsChecked);
            //処理コード
            writer.Write(temp.ClearCode);
            //処理フィールド
            writer.Write(temp.FileId);
            //処理結果
            writer.Write(temp.Result);

        }

        /// <summary>
        ///  DataClearWorkインスタンス取得
        /// </summary>
        /// <returns>DataClearWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DataClearWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private DataClearWork GetDataClearWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            DataClearWork temp = new DataClearWork();

            //テーブルID
            temp.TableId = reader.ReadString();
            //テーブル名
            temp.TableNm = reader.ReadString();
            //チェックかどうか
            temp.IsChecked = reader.ReadBoolean();
            //処理コード
            temp.ClearCode = reader.ReadInt32();
            //処理フィールド
            temp.FileId = reader.ReadString();
            //処理結果
            temp.Result = reader.ReadString();


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
        /// <returns>DataClearWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DataClearWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                DataClearWork temp = GetDataClearWork(reader, serInfo);
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
                    retValue = (DataClearWork[])lst.ToArray(typeof(DataClearWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
