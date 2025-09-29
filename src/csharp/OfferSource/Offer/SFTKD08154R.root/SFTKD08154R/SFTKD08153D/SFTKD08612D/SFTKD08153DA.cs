using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   FPprSchmCvWork
	/// <summary>
	///                      自由帳票スキーマコンバートワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   自由帳票スキーマコンバートワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2007/03/15</br>
	/// <br>Genarated Date   :   2007/12/25  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class FPprSchmCvWork : IFileHeaderOffer
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

		/// <summary>自由帳票スキーマグループコード</summary>
		private Int32 _freePrtPprSchmGrpCd;

		/// <summary>自由帳票スキーマコード</summary>
		private Int32 _freePrtPprSchemaCd;

		/// <summary>自由帳票項目コード</summary>
		/// <remarks>1～100:ActiveReport用,101～:.NS用</remarks>
		private Int32 _freePrtPaperItemCd;

		/// <summary>アクティブレポートクラスID</summary>
		/// <remarks>アクティブレポートコントロールのクラスID</remarks>
		private string _activeReportClassId = "";

		/// <summary>アクティブレポートコントロール名称</summary>
		/// <remarks>アクティブレポートコントロールのNameプロパティ</remarks>
		private string _activeReportCtrlNm = "";

		/// <summary>カンマ編集有無</summary>
		/// <remarks>0:なし,1:"#,###",2:"#,##0",3:"0.0",4:"0.00",5:"\#,##0",6:"\#,##0-"</remarks>
		private Int32 _commaEditExistCd;

		/// <summary>印字ページ制御区分</summary>
		/// <remarks>0:全ページ,1:1ページ目のみ,2:最終ページのみ</remarks>
		private Int32 _printPageCtrlDivCd;

		/// <summary>出力ファイル名</summary>
		/// <remarks>フォームファイルID or フォーマットファイルID</remarks>
		private string _outputFormFileName = "";

		/// <summary>出力ファイルクラスID</summary>
		private string _outputFileClassId = "";

		/// <summary>初期値用自由帳票項目コード</summary>
		/// <remarks>DataFieldの特殊コンバート用</remarks>
		private Int32 _initKitFreePprItemCd;


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

		/// public propaty name  :  FreePrtPprSchmGrpCd
		/// <summary>自由帳票スキーマグループコードプロパティ</summary>
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

		/// public propaty name  :  FreePrtPprSchemaCd
		/// <summary>自由帳票スキーマコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自由帳票スキーマコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FreePrtPprSchemaCd
		{
			get{return _freePrtPprSchemaCd;}
			set{_freePrtPprSchemaCd = value;}
		}

		/// public propaty name  :  FreePrtPaperItemCd
		/// <summary>自由帳票項目コードプロパティ</summary>
		/// <value>1～100:ActiveReport用,101～:.NS用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自由帳票項目コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FreePrtPaperItemCd
		{
			get{return _freePrtPaperItemCd;}
			set{_freePrtPaperItemCd = value;}
		}

		/// public propaty name  :  ActiveReportClassId
		/// <summary>アクティブレポートクラスIDプロパティ</summary>
		/// <value>アクティブレポートコントロールのクラスID</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   アクティブレポートクラスIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ActiveReportClassId
		{
			get{return _activeReportClassId;}
			set{_activeReportClassId = value;}
		}

		/// public propaty name  :  ActiveReportCtrlNm
		/// <summary>アクティブレポートコントロール名称プロパティ</summary>
		/// <value>アクティブレポートコントロールのNameプロパティ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   アクティブレポートコントロール名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ActiveReportCtrlNm
		{
			get{return _activeReportCtrlNm;}
			set{_activeReportCtrlNm = value;}
		}

		/// public propaty name  :  CommaEditExistCd
		/// <summary>カンマ編集有無プロパティ</summary>
		/// <value>0:なし,1:"#,###",2:"#,##0",3:"0.0",4:"0.00",5:"\#,##0",6:"\#,##0-"</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   カンマ編集有無プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CommaEditExistCd
		{
			get{return _commaEditExistCd;}
			set{_commaEditExistCd = value;}
		}

		/// public propaty name  :  PrintPageCtrlDivCd
		/// <summary>印字ページ制御区分プロパティ</summary>
		/// <value>0:全ページ,1:1ページ目のみ,2:最終ページのみ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印字ページ制御区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrintPageCtrlDivCd
		{
			get{return _printPageCtrlDivCd;}
			set{_printPageCtrlDivCd = value;}
		}

		/// public propaty name  :  OutputFormFileName
		/// <summary>出力ファイル名プロパティ</summary>
		/// <value>フォームファイルID or フォーマットファイルID</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力ファイル名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OutputFormFileName
		{
			get{return _outputFormFileName;}
			set{_outputFormFileName = value;}
		}

		/// public propaty name  :  OutputFileClassId
		/// <summary>出力ファイルクラスIDプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力ファイルクラスIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OutputFileClassId
		{
			get{return _outputFileClassId;}
			set{_outputFileClassId = value;}
		}

		/// public propaty name  :  InitKitFreePprItemCd
		/// <summary>初期値用自由帳票項目コードプロパティ</summary>
		/// <value>DataFieldの特殊コンバート用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   初期値用自由帳票項目コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InitKitFreePprItemCd
		{
			get{return _initKitFreePprItemCd;}
			set{_initKitFreePprItemCd = value;}
		}


		/// <summary>
		/// 自由帳票スキーマコンバートワークコンストラクタ
		/// </summary>
		/// <returns>FPprSchmCvWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FPprSchmCvWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public FPprSchmCvWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0用のカスタムシライアライザです。
	/// </summary>
	/// <returns>FPprSchmCvWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   FPprSchmCvWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public class FPprSchmCvWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate メンバ
		
		/// <summary>
		///  Ver5.10.1.0用のカスタムシリアライザです
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   FPprSchmCvWorkクラスのカスタムシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  FPprSchmCvWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
			if(  writer == null )
				throw new ArgumentNullException();

			if( graph != null && !( graph is FPprSchmCvWork || graph is ArrayList || graph is FPprSchmCvWork[]) )
				throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof(FPprSchmCvWork).FullName ) );

			if( graph != null && graph is FPprSchmCvWork )
			{
				Type t = graph.GetType();
				if( !CustomFormatterServices.NeedCustomSerialization( t ) )
					throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.FPprSchmCvWork" );

			//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
			int occurrence = 0;     //一般にゼロの場合もありえます
			if( graph is ArrayList )
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}else if( graph is FPprSchmCvWork[] )
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((FPprSchmCvWork[])graph).Length;
			}
			else if( graph is FPprSchmCvWork )
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
			//自由帳票スキーマグループコード
			serInfo.MemberInfo.Add( typeof(Int32) ); //FreePrtPprSchmGrpCd
			//自由帳票スキーマコード
			serInfo.MemberInfo.Add( typeof(Int32) ); //FreePrtPprSchemaCd
			//自由帳票項目コード
			serInfo.MemberInfo.Add( typeof(Int32) ); //FreePrtPaperItemCd
			//アクティブレポートクラスID
			serInfo.MemberInfo.Add( typeof(string) ); //ActiveReportClassId
			//アクティブレポートコントロール名称
			serInfo.MemberInfo.Add( typeof(string) ); //ActiveReportCtrlNm
			//カンマ編集有無
			serInfo.MemberInfo.Add( typeof(Int32) ); //CommaEditExistCd
			//印字ページ制御区分
			serInfo.MemberInfo.Add( typeof(Int32) ); //PrintPageCtrlDivCd
			//出力ファイル名
			serInfo.MemberInfo.Add( typeof(string) ); //OutputFormFileName
			//出力ファイルクラスID
			serInfo.MemberInfo.Add( typeof(string) ); //OutputFileClassId
			//初期値用自由帳票項目コード
			serInfo.MemberInfo.Add( typeof(Int32) ); //InitKitFreePprItemCd

				
			serInfo.Serialize( writer, serInfo );
			if( graph is FPprSchmCvWork )
			{
				FPprSchmCvWork temp = (FPprSchmCvWork)graph;

				SetFPprSchmCvWork(writer, temp);
			}
			else
			{
				ArrayList lst= null;
				if(graph is FPprSchmCvWork[])
				{
					lst = new ArrayList();
					lst.AddRange((FPprSchmCvWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;	
				}

				foreach(FPprSchmCvWork temp in lst)
				{
					SetFPprSchmCvWork(writer, temp);
				}

			}

			
		}


		/// <summary>
		/// FPprSchmCvWorkメンバ数(publicプロパティ数)
		/// </summary>
		private const int currentMemberCount = 13;
			
		/// <summary>
		///  FPprSchmCvWorkインスタンス書き込み
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   FPprSchmCvWorkのインスタンスを書き込み</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private void SetFPprSchmCvWork( System.IO.BinaryWriter writer, FPprSchmCvWork temp )
		{
			//作成日時
			writer.Write( (Int64)temp.CreateDateTime.Ticks );
			//更新日時
			writer.Write( (Int64)temp.UpdateDateTime.Ticks );
			//論理削除区分
			writer.Write( temp.LogicalDeleteCode );
			//自由帳票スキーマグループコード
			writer.Write( temp.FreePrtPprSchmGrpCd );
			//自由帳票スキーマコード
			writer.Write( temp.FreePrtPprSchemaCd );
			//自由帳票項目コード
			writer.Write( temp.FreePrtPaperItemCd );
			//アクティブレポートクラスID
			writer.Write( temp.ActiveReportClassId );
			//アクティブレポートコントロール名称
			writer.Write( temp.ActiveReportCtrlNm );
			//カンマ編集有無
			writer.Write( temp.CommaEditExistCd );
			//印字ページ制御区分
			writer.Write( temp.PrintPageCtrlDivCd );
			//出力ファイル名
			writer.Write( temp.OutputFormFileName );
			//出力ファイルクラスID
			writer.Write( temp.OutputFileClassId );
			//初期値用自由帳票項目コード
			writer.Write( temp.InitKitFreePprItemCd );

		}

		/// <summary>
		///  FPprSchmCvWorkインスタンス取得
		/// </summary>
		/// <returns>FPprSchmCvWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FPprSchmCvWorkのインスタンスを取得します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private FPprSchmCvWork GetFPprSchmCvWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
		{
			// V5.1.0.0なので不要ですが、V5.1.0.1以降では
			// serInfo.MemberInfo.Count < currentMemberCount
			// のケースについての配慮が必要になります。

			FPprSchmCvWork temp = new FPprSchmCvWork();

			//作成日時
			temp.CreateDateTime = new DateTime(reader.ReadInt64());
			//更新日時
			temp.UpdateDateTime = new DateTime(reader.ReadInt64());
			//論理削除区分
			temp.LogicalDeleteCode = reader.ReadInt32();
			//自由帳票スキーマグループコード
			temp.FreePrtPprSchmGrpCd = reader.ReadInt32();
			//自由帳票スキーマコード
			temp.FreePrtPprSchemaCd = reader.ReadInt32();
			//自由帳票項目コード
			temp.FreePrtPaperItemCd = reader.ReadInt32();
			//アクティブレポートクラスID
			temp.ActiveReportClassId = reader.ReadString();
			//アクティブレポートコントロール名称
			temp.ActiveReportCtrlNm = reader.ReadString();
			//カンマ編集有無
			temp.CommaEditExistCd = reader.ReadInt32();
			//印字ページ制御区分
			temp.PrintPageCtrlDivCd = reader.ReadInt32();
			//出力ファイル名
			temp.OutputFormFileName = reader.ReadString();
			//出力ファイルクラスID
			temp.OutputFileClassId = reader.ReadString();
			//初期値用自由帳票項目コード
			temp.InitKitFreePprItemCd = reader.ReadInt32();

				
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
		/// <returns>FPprSchmCvWorkクラスのインスタンス(object)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FPprSchmCvWorkクラスのカスタムデシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
			ArrayList lst = new ArrayList();
			for( int cnt = 0 ; cnt < serInfo.Occurrence ; ++cnt )
			{
				FPprSchmCvWork temp = GetFPprSchmCvWork( reader, serInfo );
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
					retValue = (FPprSchmCvWork[])lst.ToArray(typeof(FPprSchmCvWork));
					break;
			}
			return retValue;
		}

		#endregion
	}

}
