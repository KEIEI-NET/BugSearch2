using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   NoElmntMngWork
	/// <summary>
	///                      番号要素管理ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   番号要素管理ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2005/9/3</br>
	/// <br>Genarated Date   :   2005/09/03  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class NoElmntMngWork : IFileHeader
	{
		/// <summary>作成日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _createDateTime;

		/// <summary>更新日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _updateDateTime;

		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>GUID</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private Guid _fileHeaderGuid;

		/// <summary>更新従業員コード</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private string _updEmployeeCode = "";

		/// <summary>更新アセンブリID1</summary>
		/// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
		private string _updAssemblyId1 = "";

		/// <summary>更新アセンブリID2</summary>
		/// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
		private string _updAssemblyId2 = "";

		/// <summary>論理削除区分</summary>
		/// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>番号要素コード</summary>
		/// <remarks>0固定</remarks>
		private Int32 _noElementCode;

		/// <summary>番号要素年</summary>
		/// <remarks>YYYY</remarks>
		private Int32 _noElementYear;

		/// <summary>番号要素月</summary>
		/// <remarks>MM</remarks>
		private Int32 _noElementMonth;


		/// public propaty name  :  CreateDateTime
		/// <summary>作成日時プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime CreateDateTime
		{
			get{return _createDateTime;}
			set{_createDateTime = value;}
		}

		/// public propaty name  :  UpdateDateTime
		/// <summary>更新日時プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime UpdateDateTime
		{
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
		}

		/// public propaty name  :  EnterpriseCode
		/// <summary>企業コードプロパティ</summary>
		/// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterpriseCode
		{
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  FileHeaderGuid
		/// <summary>GUIDプロパティ</summary>
		/// <value>共通ファイルヘッダ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   GUIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Guid FileHeaderGuid
		{
			get{return _fileHeaderGuid;}
			set{_fileHeaderGuid = value;}
		}

		/// public propaty name  :  UpdEmployeeCode
		/// <summary>更新従業員コードプロパティ</summary>
		/// <value>共通ファイルヘッダ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdEmployeeCode
		{
			get{return _updEmployeeCode;}
			set{_updEmployeeCode = value;}
		}

		/// public propaty name  :  UpdAssemblyId1
		/// <summary>更新アセンブリID1プロパティ</summary>
		/// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新アセンブリID1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdAssemblyId1
		{
			get{return _updAssemblyId1;}
			set{_updAssemblyId1 = value;}
		}

		/// public propaty name  :  UpdAssemblyId2
		/// <summary>更新アセンブリID2プロパティ</summary>
		/// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新アセンブリID2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdAssemblyId2
		{
			get{return _updAssemblyId2;}
			set{_updAssemblyId2 = value;}
		}

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>論理削除区分プロパティ</summary>
		/// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   論理削除区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 LogicalDeleteCode
		{
			get{return _logicalDeleteCode;}
			set{_logicalDeleteCode = value;}
		}

		/// public propaty name  :  NoElementCode
		/// <summary>番号要素コードプロパティ</summary>
		/// <value>0固定</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   番号要素コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NoElementCode
		{
			get{return _noElementCode;}
			set{_noElementCode = value;}
		}

		/// public propaty name  :  NoElementYear
		/// <summary>番号要素年プロパティ</summary>
		/// <value>YYYY</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   番号要素年プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NoElementYear
		{
			get{return _noElementYear;}
			set{_noElementYear = value;}
		}

		/// public propaty name  :  NoElementMonth
		/// <summary>番号要素月プロパティ</summary>
		/// <value>MM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   番号要素月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NoElementMonth
		{
			get{return _noElementMonth;}
			set{_noElementMonth = value;}
		}


		/// <summary>
		/// 番号要素管理ワークコンストラクタ
		/// </summary>
		/// <returns>NoElmntMngWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoElmntMngWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public NoElmntMngWork()
		{
		}

	}
	/// <summary>
	///  Ver5.10.1.0用のカスタムシライアライザです。
	/// </summary>
	/// <returns>NoElmntMngWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   NoElmntMngWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public class NoElmntMngWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate メンバ
	
		/// <summary>
		///  Ver5.10.1.0用のカスタムシリアライザです
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoElmntMngWorkクラスのカスタムシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  NoElmntMngWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
			if(  writer == null )
				throw new ArgumentNullException();

			if( graph != null && !( graph is NoElmntMngWork || graph is ArrayList || graph is NoElmntMngWork[]) )
				throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof(NoElmntMngWork).FullName ) );

			if( graph != null && graph is NoElmntMngWork )
			{
				Type t = graph.GetType();
				if( !CustomFormatterServices.NeedCustomSerialization( t ) )
					throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.NoElmntMngWork" );

			//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
			int occurrence = 0;     //一般にゼロの場合もありえます
			if( graph is ArrayList )
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if( graph is NoElmntMngWork[] )
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((NoElmntMngWork[])graph).Length;
			}
			else if( graph is NoElmntMngWork )
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //繰り返し数	

			//作成日時
			serInfo.MemberInfo.Add( typeof(Int64) ); //CreateDateTime
			//更新日時
			serInfo.MemberInfo.Add( typeof(Int64) ); //UpdateDateTime
			//企業コード
			serInfo.MemberInfo.Add( typeof(string) ); //EnterpriseCode
			//GUID
			serInfo.MemberInfo.Add( typeof(byte[]) );  //FileHeaderGuid
			//更新従業員コード
			serInfo.MemberInfo.Add( typeof(string) ); //UpdEmployeeCode
			//更新アセンブリID1
			serInfo.MemberInfo.Add( typeof(string) ); //UpdAssemblyId1
			//更新アセンブリID2
			serInfo.MemberInfo.Add( typeof(string) ); //UpdAssemblyId2
			//論理削除区分
			serInfo.MemberInfo.Add( typeof(Int32) ); //LogicalDeleteCode
			//番号要素コード
			serInfo.MemberInfo.Add( typeof(Int32) ); //NoElementCode
			//番号要素年
			serInfo.MemberInfo.Add( typeof(Int32) ); //NoElementYear
			//番号要素月
			serInfo.MemberInfo.Add( typeof(Int32) ); //NoElementMonth

			
			serInfo.Serialize( writer, serInfo );
			if( graph is NoElmntMngWork )
			{
				NoElmntMngWork temp = (NoElmntMngWork)graph;

				SetNoElmntMngWork(writer, temp);
			}
			else
			{
				ArrayList lst= null;
				if(graph is NoElmntMngWork[])
				{
					lst = new ArrayList();
					lst.AddRange((NoElmntMngWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;	
				}

				foreach(NoElmntMngWork temp in lst)
				{
					SetNoElmntMngWork(writer, temp);
				}

			}

		
		}


		/// <summary>
		/// NoElmntMngWorkメンバ数(publicプロパティ数)
		/// </summary>
		private const int currentMemberCount = 11;
		
		/// <summary>
		///  NoElmntMngWorkインスタンス書き込み
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoElmntMngWorkのインスタンスを書き込み</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private void SetNoElmntMngWork( System.IO.BinaryWriter writer, NoElmntMngWork temp )
		{
			//作成日時
			writer.Write( (Int64)temp.CreateDateTime.Ticks );
			//更新日時
			writer.Write( (Int64)temp.UpdateDateTime.Ticks );
			//企業コード
			writer.Write( temp.EnterpriseCode );
			//GUID
			byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
			writer.Write( fileHeaderGuidArray.Length );
			writer.Write( temp.FileHeaderGuid.ToByteArray() );
			//更新従業員コード
			writer.Write( temp.UpdEmployeeCode );
			//更新アセンブリID1
			writer.Write( temp.UpdAssemblyId1 );
			//更新アセンブリID2
			writer.Write( temp.UpdAssemblyId2 );
			//論理削除区分
			writer.Write( temp.LogicalDeleteCode );
			//番号要素コード
			writer.Write( temp.NoElementCode );
			//番号要素年
			writer.Write( temp.NoElementYear );
			//番号要素月
			writer.Write( temp.NoElementMonth );

		}

		/// <summary>
		///  NoElmntMngWorkインスタンス取得
		/// </summary>
		/// <returns>NoElmntMngWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoElmntMngWorkのインスタンスを取得します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private NoElmntMngWork GetNoElmntMngWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
		{
			// V5.1.0.0なので不要ですが、V5.1.0.1以降では
			// serInfo.MemberInfo.Count < currentMemberCount
			// のケースについての配慮が必要になります。

			NoElmntMngWork temp = new NoElmntMngWork();

			//作成日時
			temp.CreateDateTime = new DateTime(reader.ReadInt64());
			//更新日時
			temp.UpdateDateTime = new DateTime(reader.ReadInt64());
			//企業コード
			temp.EnterpriseCode = reader.ReadString();
			//GUID
			int lenOfFileHeaderGuidArray = reader.ReadInt32();
			byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
			temp.FileHeaderGuid = new Guid( fileHeaderGuidArray );
			//更新従業員コード
			temp.UpdEmployeeCode = reader.ReadString();
			//更新アセンブリID1
			temp.UpdAssemblyId1 = reader.ReadString();
			//更新アセンブリID2
			temp.UpdAssemblyId2 = reader.ReadString();
			//論理削除区分
			temp.LogicalDeleteCode = reader.ReadInt32();
			//番号要素コード
			temp.NoElementCode = reader.ReadInt32();
			//番号要素年
			temp.NoElementYear = reader.ReadInt32();
			//番号要素月
			temp.NoElementMonth = reader.ReadInt32();

			
			//以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
			//データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
			//型情報にしたがって、ストリームから情報を読み出します...といっても
			//読み出して捨てることになります。
			for( int k = currentMemberCount ; k < serInfo.MemberInfo.Count ; ++k )
			{
				//byte[],char[]をデシリアライズする直前に、そのlengthが
				//デシリアライズされているケースがある、byte[],char[]の
				//デシリアライズにはlengthが必要なのでint型のデータをデ
				//シリアライズした場合は、この値をこの変数に退避します。
				int optCount = 0;   
				object oMemberType = serInfo.MemberInfo[k];
				if( oMemberType is Type )
				{
					Type t = (Type)oMemberType;
					object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
					if( t.Equals( typeof(int) ) )
					{
						optCount = Convert.ToInt32(oData);
					}
					else
					{
						optCount = 0;
					}
				}
				else if( oMemberType is string )
				{
					Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
					object userData = formatter.Deserialize( reader );  //読み飛ばし
				}
			}
			return temp;
		}

		/// <summary>
		///  Ver5.10.1.0用のカスタムデシリアライザです
		/// </summary>
		/// <returns>NoElmntMngWorkクラスのインスタンス(object)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoElmntMngWorkクラスのカスタムデシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
			ArrayList lst = new ArrayList();
			for( int cnt = 0 ; cnt < serInfo.Occurrence ; ++cnt )
			{
				NoElmntMngWork temp = GetNoElmntMngWork( reader, serInfo );
				lst.Add( temp );
			}
			switch(serInfo.RetTypeInfo)
			{
				case 0:
					retValue = lst;
					break;
				case 1:
					retValue = lst[0];
					break;
				case 2:
					retValue = (NoElmntMngWork[])lst.ToArray(typeof(NoElmntMngWork));
					break;
			}
			return retValue;
		}

		#endregion
	}
}
