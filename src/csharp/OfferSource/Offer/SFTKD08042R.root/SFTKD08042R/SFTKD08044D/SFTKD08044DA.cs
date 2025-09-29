using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   UserGdHdWork
	/// <summary>
	///                      ユーザーガイドマスタ（ヘッダ）ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   ユーザーガイドマスタ（ヘッダ）ワークヘッダファイル</br>
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
	public class UserGdHdWork : IFileHeaderOffer
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

		/// <summary>ユーザーガイド区分名称</summary>
		private string _userGuideDivNm = "";

		/// <summary>マスタ提供区分</summary>
		/// <remarks>0:提供,1:初期提供</remarks>
		private Int32 _masterOfferCd;


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

		/// public propaty name  :  UserGuideDivNm
		/// <summary>ユーザーガイド区分名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ユーザーガイド区分名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UserGuideDivNm
		{
			get{return _userGuideDivNm;}
			set{_userGuideDivNm = value;}
		}

		/// public propaty name  :  MasterOfferCd
		/// <summary>マスタ提供区分プロパティ</summary>
		/// <value>0:提供,1:初期提供</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   マスタ提供区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MasterOfferCd
		{
			get{return _masterOfferCd;}
			set{_masterOfferCd = value;}
		}


		/// <summary>
		/// ユーザーガイドマスタ（ヘッダ）ワークコンストラクタ
		/// </summary>
		/// <returns>UserGdHdWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   UserGdHdWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public UserGdHdWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0用のカスタムシライアライザです。
	/// </summary>
	/// <returns>UserGdHdWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   UserGdHdWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public class UserGdHdWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate メンバ
	
		/// <summary>
		///  Ver5.10.1.0用のカスタムシリアライザです
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   UserGdHdWorkクラスのカスタムシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  UserGdHdWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
			if(  writer == null )
				throw new ArgumentNullException();

			if( graph != null && !( graph is UserGdHdWork || graph is ArrayList || graph is UserGdHdWork[]) )
				throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof(UserGdHdWork).FullName ) );

			if( graph != null && graph is UserGdHdWork )
			{
				Type t = graph.GetType();
				if( !CustomFormatterServices.NeedCustomSerialization( t ) )
					throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.UserGdHdWork" );

			//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
			int occurrence = 0;     //一般にゼロの場合もありえます
			if( graph is ArrayList )
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if( graph is UserGdHdWork[] )
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((UserGdHdWork[])graph).Length;
			}
			else if( graph is UserGdHdWork )
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
			//ユーザーガイド区分名称
			serInfo.MemberInfo.Add( typeof(string) ); //UserGuideDivNm
			//マスタ提供区分
			serInfo.MemberInfo.Add( typeof(Int32) ); //MasterOfferCd

			
			serInfo.Serialize( writer, serInfo );
			if( graph is UserGdHdWork )
			{
				UserGdHdWork temp = (UserGdHdWork)graph;

				SetUserGdHdWork(writer, temp);
			}
			else
			{
				ArrayList lst= null;
				if(graph is UserGdHdWork[])
				{
					lst = new ArrayList();
					lst.AddRange((UserGdHdWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;	
				}

				foreach(UserGdHdWork temp in lst)
				{
					SetUserGdHdWork(writer, temp);
				}

			}

		
		}


		/// <summary>
		/// UserGdHdWorkメンバ数(publicプロパティ数)
		/// </summary>
		private const int currentMemberCount = 6;
		
		/// <summary>
		///  UserGdHdWorkインスタンス書き込み
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   UserGdHdWorkのインスタンスを書き込み</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private void SetUserGdHdWork( System.IO.BinaryWriter writer, UserGdHdWork temp )
		{
			//作成日時
			writer.Write( (Int64)temp.CreateDateTime.Ticks );
			//更新日時
			writer.Write( (Int64)temp.UpdateDateTime.Ticks );
			//論理削除区分
			writer.Write( temp.LogicalDeleteCode );
			//ユーザーガイド区分
			writer.Write( temp.UserGuideDivCd );
			//ユーザーガイド区分名称
			writer.Write( temp.UserGuideDivNm );
			//マスタ提供区分
			writer.Write( temp.MasterOfferCd );

		}

		/// <summary>
		///  UserGdHdWorkインスタンス取得
		/// </summary>
		/// <returns>UserGdHdWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   UserGdHdWorkのインスタンスを取得します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private UserGdHdWork GetUserGdHdWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
		{
			// V5.1.0.0なので不要ですが、V5.1.0.1以降では
			// serInfo.MemberInfo.Count < currentMemberCount
			// のケースについての配慮が必要になります。

			UserGdHdWork temp = new UserGdHdWork();

			//作成日時
			temp.CreateDateTime = new DateTime(reader.ReadInt64());
			//更新日時
			temp.UpdateDateTime = new DateTime(reader.ReadInt64());
			//論理削除区分
			temp.LogicalDeleteCode = reader.ReadInt32();
			//ユーザーガイド区分
			temp.UserGuideDivCd = reader.ReadInt32();
			//ユーザーガイド区分名称
			temp.UserGuideDivNm = reader.ReadString();
			//マスタ提供区分
			temp.MasterOfferCd = reader.ReadInt32();

			
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
		/// <returns>UserGdHdWorkクラスのインスタンス(object)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   UserGdHdWorkクラスのカスタムデシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
			ArrayList lst = new ArrayList();
			for( int cnt = 0 ; cnt < serInfo.Occurrence ; ++cnt )
			{
				UserGdHdWork temp = GetUserGdHdWork( reader, serInfo );
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
					retValue = (UserGdHdWork[])lst.ToArray(typeof(UserGdHdWork));
					break;
			}
			return retValue;
		}

		#endregion
	}

}
