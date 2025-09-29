using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   FPSortInitWork
	/// <summary>
	///                      自由帳票ソート順位初期値ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   自由帳票ソート順位初期値ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   柏原頼人</br>
	/// <br>Genarated Date   :   2007/10/11  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class FPSortInitWork : IFileHeaderOffer
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

		/// <summary>自由帳票項目グループコード</summary>
		private Int32 _freePrtPprItemGrpCd;

		/// <summary>自由帳票スキーマグループコード</summary>
		/// <remarks>※0は新規作成用</remarks>
		private Int32 _freePrtPprSchmGrpCd;

		/// <summary>ソート順位コード</summary>
		private Int32 _sortingOrderCode;

		/// <summary>ソート順位</summary>
		/// <remarks>※１</remarks>
		private Int32 _sortingOrder;

		/// <summary>自由帳票項目名称</summary>
		private string _freePrtPaperItemNm = "";

		/// <summary>DD名称</summary>
		/// <remarks>小文字で登録</remarks>
		private string _dDName = "";

		/// <summary>ファイル名称</summary>
		/// <remarks>DBのテーブルID</remarks>
		private string _fileNm = "";

		/// <summary>昇順降順区分</summary>
		/// <remarks>0:なし,1:昇順,2:降順</remarks>
		private Int32 _sortingOrderDivCd;


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

		/// public propaty name  :  FreePrtPprItemGrpCd
		/// <summary>自由帳票項目グループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自由帳票項目グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FreePrtPprItemGrpCd
		{
			get{return _freePrtPprItemGrpCd;}
			set{_freePrtPprItemGrpCd = value;}
		}

		/// public propaty name  :  FreePrtPprSchmGrpCd
		/// <summary>自由帳票スキーマグループコードプロパティ</summary>
		/// <value>※0は新規作成用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自由帳票スキーマグループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FreePrtPprSchmGrpCd
		{
			get{return _freePrtPprSchmGrpCd;}
			set{_freePrtPprSchmGrpCd = value;}
		}

		/// public propaty name  :  SortingOrderCode
		/// <summary>ソート順位コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ソート順位コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SortingOrderCode
		{
			get{return _sortingOrderCode;}
			set{_sortingOrderCode = value;}
		}

		/// public propaty name  :  SortingOrder
		/// <summary>ソート順位プロパティ</summary>
		/// <value>※１</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ソート順位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SortingOrder
		{
			get{return _sortingOrder;}
			set{_sortingOrder = value;}
		}

		/// public propaty name  :  FreePrtPaperItemNm
		/// <summary>自由帳票項目名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自由帳票項目名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string FreePrtPaperItemNm
		{
			get{return _freePrtPaperItemNm;}
			set{_freePrtPaperItemNm = value;}
		}

		/// public propaty name  :  DDName
		/// <summary>DD名称プロパティ</summary>
		/// <value>小文字で登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   DD名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DDName
		{
			get{return _dDName;}
			set{_dDName = value;}
		}

		/// public propaty name  :  FileNm
		/// <summary>ファイル名称プロパティ</summary>
		/// <value>DBのテーブルID</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ファイル名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string FileNm
		{
			get{return _fileNm;}
			set{_fileNm = value;}
		}

		/// public propaty name  :  SortingOrderDivCd
		/// <summary>昇順降順区分プロパティ</summary>
		/// <value>0:なし,1:昇順,2:降順</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   昇順降順区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SortingOrderDivCd
		{
			get{return _sortingOrderDivCd;}
			set{_sortingOrderDivCd = value;}
		}


		/// <summary>
		/// 自由帳票ソート順位初期値ワークコンストラクタ
		/// </summary>
		/// <returns>FPSortInitWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FPSortInitWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public FPSortInitWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0用のカスタムシライアライザです。
	/// </summary>
	/// <returns>FPSortInitWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   FPSortInitWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public class FPSortInitWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate メンバ
		
		/// <summary>
		///  Ver5.10.1.0用のカスタムシリアライザです
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   FPSortInitWorkクラスのカスタムシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  FPSortInitWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
			if(  writer == null )
				throw new ArgumentNullException();

			if( graph != null && !( graph is FPSortInitWork || graph is ArrayList || graph is FPSortInitWork[]) )
				throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof(FPSortInitWork).FullName ) );

			if( graph != null && graph is FPSortInitWork )
			{
				Type t = graph.GetType();
				if( !CustomFormatterServices.NeedCustomSerialization( t ) )
					throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.FPSortInitWork" );

			//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
			int occurrence = 0;     //一般にゼロの場合もありえます
			if( graph is ArrayList )
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}else if( graph is FPSortInitWork[] )
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((FPSortInitWork[])graph).Length;
			}
			else if( graph is FPSortInitWork )
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
			//自由帳票項目グループコード
			serInfo.MemberInfo.Add( typeof(Int32) ); //FreePrtPprItemGrpCd
			//自由帳票スキーマグループコード
			serInfo.MemberInfo.Add( typeof(Int32) ); //FreePrtPprSchmGrpCd
			//ソート順位コード
			serInfo.MemberInfo.Add( typeof(Int32) ); //SortingOrderCode
			//ソート順位
			serInfo.MemberInfo.Add( typeof(Int32) ); //SortingOrder
			//自由帳票項目名称
			serInfo.MemberInfo.Add( typeof(string) ); //FreePrtPaperItemNm
			//DD名称
			serInfo.MemberInfo.Add( typeof(string) ); //DDName
			//ファイル名称
			serInfo.MemberInfo.Add( typeof(string) ); //FileNm
			//昇順降順区分
			serInfo.MemberInfo.Add( typeof(Int32) ); //SortingOrderDivCd

				
			serInfo.Serialize( writer, serInfo );
			if( graph is FPSortInitWork )
			{
				FPSortInitWork temp = (FPSortInitWork)graph;

				SetFPSortInitWork(writer, temp);
			}
			else
			{
				ArrayList lst= null;
				if(graph is FPSortInitWork[])
				{
					lst = new ArrayList();
					lst.AddRange((FPSortInitWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;	
				}

				foreach(FPSortInitWork temp in lst)
				{
					SetFPSortInitWork(writer, temp);
				}

			}

			
		}


		/// <summary>
		/// FPSortInitWorkメンバ数(publicプロパティ数)
		/// </summary>
		private const int currentMemberCount = 11;
			
		/// <summary>
		///  FPSortInitWorkインスタンス書き込み
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   FPSortInitWorkのインスタンスを書き込み</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private void SetFPSortInitWork( System.IO.BinaryWriter writer, FPSortInitWork temp )
		{
			//作成日時
			writer.Write( (Int64)temp.CreateDateTime.Ticks );
			//更新日時
			writer.Write( (Int64)temp.UpdateDateTime.Ticks );
			//論理削除区分
			writer.Write( temp.LogicalDeleteCode );
			//自由帳票項目グループコード
			writer.Write( temp.FreePrtPprItemGrpCd );
			//自由帳票スキーマグループコード
			writer.Write( temp.FreePrtPprSchmGrpCd );
			//ソート順位コード
			writer.Write( temp.SortingOrderCode );
			//ソート順位
			writer.Write( temp.SortingOrder );
			//自由帳票項目名称
			writer.Write( temp.FreePrtPaperItemNm );
			//DD名称
			writer.Write( temp.DDName );
			//ファイル名称
			writer.Write( temp.FileNm );
			//昇順降順区分
			writer.Write( temp.SortingOrderDivCd );

		}

		/// <summary>
		///  FPSortInitWorkインスタンス取得
		/// </summary>
		/// <returns>FPSortInitWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FPSortInitWorkのインスタンスを取得します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private FPSortInitWork GetFPSortInitWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
		{
			// V5.1.0.0なので不要ですが、V5.1.0.1以降では
			// serInfo.MemberInfo.Count < currentMemberCount
			// のケースについての配慮が必要になります。

			FPSortInitWork temp = new FPSortInitWork();

			//作成日時
			temp.CreateDateTime = new DateTime(reader.ReadInt64());
			//更新日時
			temp.UpdateDateTime = new DateTime(reader.ReadInt64());
			//論理削除区分
			temp.LogicalDeleteCode = reader.ReadInt32();
			//自由帳票項目グループコード
			temp.FreePrtPprItemGrpCd = reader.ReadInt32();
			//自由帳票スキーマグループコード
			temp.FreePrtPprSchmGrpCd = reader.ReadInt32();
			//ソート順位コード
			temp.SortingOrderCode = reader.ReadInt32();
			//ソート順位
			temp.SortingOrder = reader.ReadInt32();
			//自由帳票項目名称
			temp.FreePrtPaperItemNm = reader.ReadString();
			//DD名称
			temp.DDName = reader.ReadString();
			//ファイル名称
			temp.FileNm = reader.ReadString();
			//昇順降順区分
			temp.SortingOrderDivCd = reader.ReadInt32();

				
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
		/// <returns>FPSortInitWorkクラスのインスタンス(object)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FPSortInitWorkクラスのカスタムデシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
			ArrayList lst = new ArrayList();
			for( int cnt = 0 ; cnt < serInfo.Occurrence ; ++cnt )
			{
				FPSortInitWork temp = GetFPSortInitWork( reader, serInfo );
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
					retValue = (FPSortInitWork[])lst.ToArray(typeof(FPSortInitWork));
					break;
			}
			return retValue;
		}

		#endregion
	}
}
