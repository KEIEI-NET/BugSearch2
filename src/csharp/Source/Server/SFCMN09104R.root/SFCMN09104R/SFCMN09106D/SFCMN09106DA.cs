using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   NoMngSetWork
	/// <summary>
	///                      番号管理設定ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   番号管理設定ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2005/8/30</br>
	/// <br>Genarated Date   :   2005/09/03  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class NoMngSetWork : IFileHeader
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

		/// <summary>拠点コード</summary>
		private string _sectionCode = "";

		/// <summary>番号コード</summary>
		/// <remarks>1:顧客ｺｰﾄﾞ,2:車両管理番号,･･･つづきあり(項目詳細)</remarks>
		private Int32 _noCode;

		/// <summary>番号現在値</summary>
		/// <remarks>番号現在値または論理削除ﾚｺｰﾄﾞ件数(項目詳細)</remarks>
		private Int64 _noPresentVal;

		/// <summary>設定開始番号</summary>
		private Int64 _settingStartNo;

		/// <summary>設定終了番号</summary>
		private Int64 _settingEndNo;

		/// <summary>番号増減幅</summary>
		private Int32 _noIncDecWidth;


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

		/// public propaty name  :  SectionCode
		/// <summary>拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

		/// public propaty name  :  NoCode
		/// <summary>番号コードプロパティ</summary>
		/// <value>1:顧客ｺｰﾄﾞ,2:車両管理番号,･･･つづきあり(項目詳細)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   番号コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NoCode
		{
			get{return _noCode;}
			set{_noCode = value;}
		}

		/// public propaty name  :  NoPresentVal
		/// <summary>番号現在値プロパティ</summary>
		/// <value>番号現在値または論理削除ﾚｺｰﾄﾞ件数(項目詳細)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   番号現在値プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 NoPresentVal
		{
			get{return _noPresentVal;}
			set{_noPresentVal = value;}
		}

		/// public propaty name  :  SettingStartNo
		/// <summary>設定開始番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   設定開始番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SettingStartNo
		{
			get{return _settingStartNo;}
			set{_settingStartNo = value;}
		}

		/// public propaty name  :  SettingEndNo
		/// <summary>設定終了番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   設定終了番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SettingEndNo
		{
			get{return _settingEndNo;}
			set{_settingEndNo = value;}
		}

		/// public propaty name  :  NoIncDecWidth
		/// <summary>番号増減幅プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   番号増減幅プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NoIncDecWidth
		{
			get{return _noIncDecWidth;}
			set{_noIncDecWidth = value;}
		}


		/// <summary>
		/// 番号管理設定ワークコンストラクタ
		/// </summary>
		/// <returns>NoMngSetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoMngSetWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public NoMngSetWork()
		{
		}

	}
	/// <summary>
	///  Ver5.10.1.0用のカスタムシライアライザです。
	/// </summary>
	/// <returns>NoMngSetWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   NoMngSetWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public class NoMngSetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate メンバ
	
		/// <summary>
		///  Ver5.10.1.0用のカスタムシリアライザです
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoMngSetWorkクラスのカスタムシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  NoMngSetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
			if(  writer == null )
				throw new ArgumentNullException();

			if( graph != null && !( graph is NoMngSetWork || graph is ArrayList || graph is NoMngSetWork[]) )
				throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof(NoMngSetWork).FullName ) );

			if( graph != null && graph is NoMngSetWork )
			{
				Type t = graph.GetType();
				if( !CustomFormatterServices.NeedCustomSerialization( t ) )
					throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.NoMngSetWork" );

			//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
			int occurrence = 0;     //一般にゼロの場合もありえます
			if( graph is ArrayList )
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if( graph is NoMngSetWork[] )
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((NoMngSetWork[])graph).Length;
			}
			else if( graph is NoMngSetWork )
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
			//拠点コード
			serInfo.MemberInfo.Add( typeof(string) ); //SectionCode
			//番号コード
			serInfo.MemberInfo.Add( typeof(Int32) ); //NoCode
			//番号現在値
			serInfo.MemberInfo.Add( typeof(Int64) ); //NoPresentVal
			//設定開始番号
			serInfo.MemberInfo.Add( typeof(Int64) ); //SettingStartNo
			//設定終了番号
			serInfo.MemberInfo.Add( typeof(Int64) ); //SettingEndNo
			//番号増減幅
			serInfo.MemberInfo.Add( typeof(Int32) ); //NoIncDecWidth

			
			serInfo.Serialize( writer, serInfo );
			if( graph is NoMngSetWork )
			{
				NoMngSetWork temp = (NoMngSetWork)graph;

				SetNoMngSetWork(writer, temp);
			}
			else
			{
				ArrayList lst= null;
				if(graph is NoMngSetWork[])
				{
					lst = new ArrayList();
					lst.AddRange((NoMngSetWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;	
				}

				foreach(NoMngSetWork temp in lst)
				{
					SetNoMngSetWork(writer, temp);
				}

			}

		
		}


		/// <summary>
		/// NoMngSetWorkメンバ数(publicプロパティ数)
		/// </summary>
		private const int currentMemberCount = 14;
		
		/// <summary>
		///  NoMngSetWorkインスタンス書き込み
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoMngSetWorkのインスタンスを書き込み</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private void SetNoMngSetWork( System.IO.BinaryWriter writer, NoMngSetWork temp )
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
			//拠点コード
			writer.Write( temp.SectionCode );
			//番号コード
			writer.Write( temp.NoCode );
			//番号現在値
			writer.Write( temp.NoPresentVal );
			//設定開始番号
			writer.Write( temp.SettingStartNo );
			//設定終了番号
			writer.Write( temp.SettingEndNo );
			//番号増減幅
			writer.Write( temp.NoIncDecWidth );

		}

		/// <summary>
		///  NoMngSetWorkインスタンス取得
		/// </summary>
		/// <returns>NoMngSetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoMngSetWorkのインスタンスを取得します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private NoMngSetWork GetNoMngSetWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
		{
			// V5.1.0.0なので不要ですが、V5.1.0.1以降では
			// serInfo.MemberInfo.Count < currentMemberCount
			// のケースについての配慮が必要になります。

			NoMngSetWork temp = new NoMngSetWork();

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
			//拠点コード
			temp.SectionCode = reader.ReadString();
			//番号コード
			temp.NoCode = reader.ReadInt32();
			//番号現在値
			temp.NoPresentVal = reader.ReadInt64();
			//設定開始番号
			temp.SettingStartNo = reader.ReadInt64();
			//設定終了番号
			temp.SettingEndNo = reader.ReadInt64();
			//番号増減幅
			temp.NoIncDecWidth = reader.ReadInt32();

			
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
		/// <returns>NoMngSetWorkクラスのインスタンス(object)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoMngSetWorkクラスのカスタムデシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
			ArrayList lst = new ArrayList();
			for( int cnt = 0 ; cnt < serInfo.Occurrence ; ++cnt )
			{
				NoMngSetWork temp = GetNoMngSetWork( reader, serInfo );
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
					retValue = (NoMngSetWork[])lst.ToArray(typeof(NoMngSetWork));
					break;
			}
			return retValue;
		}

		#endregion
	}

}
