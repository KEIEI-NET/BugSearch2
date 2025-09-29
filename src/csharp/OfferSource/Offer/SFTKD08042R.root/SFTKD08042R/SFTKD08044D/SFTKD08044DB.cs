using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   UserGdBdWork
	/// <summary>
	///                      ユーザーガイドマスタ（ボディ）ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   ユーザーガイドマスタ（ボディ）ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2005/03/30</br>
	/// <br>Genarated Date   :   2006/04/13  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2006/4/7  水野　剛史</br>
	/// <br>                 :   共通ファイルヘッダ変更（項目削除）</br>
	/// <br>                 :   ・企業コード</br>
	/// <br>                 :   ・GUID</br>
	/// <br>                 :   ・更新従業員コード</br>
	/// <br>                 :   ・更新アセンブリID1</br>
	/// <br>                 :   ・更新アセンブリID2</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class UserGdBdWork : IFileHeaderOffer
	{
		/// <summary>作成日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _createDateTime;

		/// <summary>更新日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _updateDateTime;

		/// <summary>論理削除区分</summary>
		/// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>ユーザーガイド区分</summary>
		/// <remarks>1:料金ランク,2:DM区分,3:入庫促進DM･･･つづきあり</remarks>
		private Int32 _userGuideDivCd;

		/// <summary>ガイドコード</summary>
		private Int32 _guideCode;

		/// <summary>ガイド名称</summary>
		private string _guideName = "";

		/// <summary>ガイドタイプ</summary>
		private Int32 _guideType;


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

		/// public propaty name  :  UserGuideDivCd
		/// <summary>ユーザーガイド区分プロパティ</summary>
		/// <value>1:料金ランク,2:DM区分,3:入庫促進DM･･･つづきあり</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ユーザーガイド区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UserGuideDivCd
		{
			get{return _userGuideDivCd;}
			set{_userGuideDivCd = value;}
		}

		/// public propaty name  :  GuideCode
		/// <summary>ガイドコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ガイドコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GuideCode
		{
			get{return _guideCode;}
			set{_guideCode = value;}
		}

		/// public propaty name  :  GuideName
		/// <summary>ガイド名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ガイド名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GuideName
		{
			get{return _guideName;}
			set{_guideName = value;}
		}

		/// public propaty name  :  GuideType
		/// <summary>ガイドタイププロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ガイドタイププロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GuideType
		{
			get{return _guideType;}
			set{_guideType = value;}
		}


		/// <summary>
		/// ユーザーガイドマスタ（ボディ）ワークコンストラクタ
		/// </summary>
		/// <returns>UserGdBdWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   UserGdBdWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public UserGdBdWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0用のカスタムシライアライザです。
	/// </summary>
	/// <returns>UserGdBdWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   UserGdBdWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public class UserGdBdWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate メンバ
	
		/// <summary>
		///  Ver5.10.1.0用のカスタムシリアライザです
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   UserGdBdWorkクラスのカスタムシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  UserGdBdWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
			if(  writer == null )
				throw new ArgumentNullException();

			if( graph != null && !( graph is UserGdBdWork || graph is ArrayList || graph is UserGdBdWork[]) )
				throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof(UserGdBdWork).FullName ) );

			if( graph != null && graph is UserGdBdWork )
			{
				Type t = graph.GetType();
				if( !CustomFormatterServices.NeedCustomSerialization( t ) )
					throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.UserGdBdWork" );

			//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
			int occurrence = 0;     //一般にゼロの場合もありえます
			if( graph is ArrayList )
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if( graph is UserGdBdWork[] )
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((UserGdBdWork[])graph).Length;
			}
			else if( graph is UserGdBdWork )
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //繰り返し数	

			//作成日時
			serInfo.MemberInfo.Add( typeof(Int64) ); //CreateDateTime
			//更新日時
			serInfo.MemberInfo.Add( typeof(Int64) ); //UpdateDateTime
			//論理削除区分
			serInfo.MemberInfo.Add( typeof(Int32) ); //LogicalDeleteCode
			//ユーザーガイド区分
			serInfo.MemberInfo.Add( typeof(Int32) ); //UserGuideDivCd
			//ガイドコード
			serInfo.MemberInfo.Add( typeof(Int32) ); //GuideCode
			//ガイド名称
			serInfo.MemberInfo.Add( typeof(string) ); //GuideName
			//ガイドタイプ
			serInfo.MemberInfo.Add( typeof(Int32) ); //GuideType

			
			serInfo.Serialize( writer, serInfo );
			if( graph is UserGdBdWork )
			{
				UserGdBdWork temp = (UserGdBdWork)graph;

				SetUserGdBdWork(writer, temp);
			}
			else
			{
				ArrayList lst= null;
				if(graph is UserGdBdWork[])
				{
					lst = new ArrayList();
					lst.AddRange((UserGdBdWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;	
				}

				foreach(UserGdBdWork temp in lst)
				{
					SetUserGdBdWork(writer, temp);
				}

			}

		
		}


		/// <summary>
		/// UserGdBdWorkメンバ数(publicプロパティ数)
		/// </summary>
		private const int currentMemberCount = 7;
		
		/// <summary>
		///  UserGdBdWorkインスタンス書き込み
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   UserGdBdWorkのインスタンスを書き込み</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private void SetUserGdBdWork( System.IO.BinaryWriter writer, UserGdBdWork temp )
		{
			//作成日時
			writer.Write( (Int64)temp.CreateDateTime.Ticks );
			//更新日時
			writer.Write( (Int64)temp.UpdateDateTime.Ticks );
			//論理削除区分
			writer.Write( temp.LogicalDeleteCode );
			//ユーザーガイド区分
			writer.Write( temp.UserGuideDivCd );
			//ガイドコード
			writer.Write( temp.GuideCode );
			//ガイド名称
			writer.Write( temp.GuideName );
			//ガイドタイプ
			writer.Write( temp.GuideType );

		}

		/// <summary>
		///  UserGdBdWorkインスタンス取得
		/// </summary>
		/// <returns>UserGdBdWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   UserGdBdWorkのインスタンスを取得します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private UserGdBdWork GetUserGdBdWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
		{
			// V5.1.0.0なので不要ですが、V5.1.0.1以降では
			// serInfo.MemberInfo.Count < currentMemberCount
			// のケースについての配慮が必要になります。

			UserGdBdWork temp = new UserGdBdWork();

			//作成日時
			temp.CreateDateTime = new DateTime(reader.ReadInt64());
			//更新日時
			temp.UpdateDateTime = new DateTime(reader.ReadInt64());
			//論理削除区分
			temp.LogicalDeleteCode = reader.ReadInt32();
			//ユーザーガイド区分
			temp.UserGuideDivCd = reader.ReadInt32();
			//ガイドコード
			temp.GuideCode = reader.ReadInt32();
			//ガイド名称
			temp.GuideName = reader.ReadString();
			//ガイドタイプ
			temp.GuideType = reader.ReadInt32();

			
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
		/// <returns>UserGdBdWorkクラスのインスタンス(object)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   UserGdBdWorkクラスのカスタムデシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
			ArrayList lst = new ArrayList();
			for( int cnt = 0 ; cnt < serInfo.Occurrence ; ++cnt )
			{
				UserGdBdWork temp = GetUserGdBdWork( reader, serInfo );
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
					retValue = (UserGdBdWork[])lst.ToArray(typeof(UserGdBdWork));
					break;
			}
			return retValue;
		}

		#endregion
	}

}
