using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   FPprSchmGrWork
	/// <summary>
	///                      自由帳票スキーマグループワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   自由帳票スキーマグループワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2007/03/15</br>
	/// <br>Genarated Date   :   2007/12/26  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   橋本　裕毅  2007/08/22</br>
	/// <br>                 :   DM使用区分を追加</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class FPprSchmGrWork : IFileHeaderOffer
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

		/// <summary>出力ファイル名</summary>
		/// <remarks>フォームファイルID or フォーマットファイルID</remarks>
		private string _outputFormFileName = "";

		/// <summary>出力ファイルクラスID</summary>
		private string _outputFileClassId = "";

		/// <summary>自由帳票項目グループコード</summary>
		private Int32 _freePrtPprItemGrpCd;

		/// <summary>出力名称</summary>
		/// <remarks>ガイド等に表示する名称</remarks>
		private string _displayName = "";

		/// <summary>データ入力システム</summary>
		/// <remarks>0:共通,1:整備,2:鈑金,3:車販</remarks>
		private Int32 _dataInputSystem;

		/// <summary>帳票区分コード</summary>
		/// <remarks>1:日次帳票,2:月次帳票,3:年次帳票,4:随時帳票</remarks>
		private Int32 _printPaperDivCd;

		/// <summary>帳票使用区分</summary>
		/// <remarks>1:帳票,2:伝票,3:DM一覧表,4:DMはがき</remarks>
		private Int32 _printPaperUseDivcd;

		/// <summary>特殊コンバート使用区分</summary>
		/// <remarks>0:無,1:特種マクロコンバート有,2:フォントのみ</remarks>
		private Int32 _specialConvtUseDivCd;

		/// <summary>オプションコード</summary>
		/// <remarks>ｼｽﾃﾑ上のｵﾌﾟｼｮﾝｺｰﾄﾞ</remarks>
		private string _optionCode = "";

		/// <summary>改頁行数</summary>
		private Int32 _formFeedLineCount;

		/// <summary>改行文字数</summary>
		/// <remarks>※伝票で作業・部品名称の改行文字数</remarks>
		private Int32 _crCharCnt;

		/// <summary>上余白</summary>
		/// <remarks>cmで指定。マイナス入力不可。有効桁数は小数点第１位まで（例0.8)</remarks>
		private Double _topMargin;

		/// <summary>左余白</summary>
		/// <remarks>cmで指定。マイナス入力不可。有効桁数は小数点第１位まで（例0.8)</remarks>
		private Double _leftMargin;

		/// <summary>右余白</summary>
		private Double _rightMargin;

		/// <summary>下余白</summary>
		private Double _bottomMargin;


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

		/// public propaty name  :  DisplayName
		/// <summary>出力名称プロパティ</summary>
		/// <value>ガイド等に表示する名称</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DisplayName
		{
			get{return _displayName;}
			set{_displayName = value;}
		}

		/// public propaty name  :  DataInputSystem
		/// <summary>データ入力システムプロパティ</summary>
		/// <value>0:共通,1:整備,2:鈑金,3:車販</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   データ入力システムプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DataInputSystem
		{
			get{return _dataInputSystem;}
			set{_dataInputSystem = value;}
		}

		/// public propaty name  :  PrintPaperDivCd
		/// <summary>帳票区分コードプロパティ</summary>
		/// <value>1:日次帳票,2:月次帳票,3:年次帳票,4:随時帳票</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   帳票区分コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrintPaperDivCd
		{
			get{return _printPaperDivCd;}
			set{_printPaperDivCd = value;}
		}

		/// public propaty name  :  PrintPaperUseDivcd
		/// <summary>帳票使用区分プロパティ</summary>
		/// <value>1:帳票,2:伝票,3:DM一覧表,4:DMはがき</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   帳票使用区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrintPaperUseDivcd
		{
			get{return _printPaperUseDivcd;}
			set{_printPaperUseDivcd = value;}
		}

		/// public propaty name  :  SpecialConvtUseDivCd
		/// <summary>特殊コンバート使用区分プロパティ</summary>
		/// <value>0:無,1:特種マクロコンバート有,2:フォントのみ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   特殊コンバート使用区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SpecialConvtUseDivCd
		{
			get{return _specialConvtUseDivCd;}
			set{_specialConvtUseDivCd = value;}
		}

		/// public propaty name  :  OptionCode
		/// <summary>オプションコードプロパティ</summary>
		/// <value>ｼｽﾃﾑ上のｵﾌﾟｼｮﾝｺｰﾄﾞ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   オプションコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OptionCode
		{
			get{return _optionCode;}
			set{_optionCode = value;}
		}

		/// public propaty name  :  FormFeedLineCount
		/// <summary>改頁行数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   改頁行数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FormFeedLineCount
		{
			get{return _formFeedLineCount;}
			set{_formFeedLineCount = value;}
		}

		/// public propaty name  :  CrCharCnt
		/// <summary>改行文字数プロパティ</summary>
		/// <value>※伝票で作業・部品名称の改行文字数</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   改行文字数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CrCharCnt
		{
			get{return _crCharCnt;}
			set{_crCharCnt = value;}
		}

		/// public propaty name  :  TopMargin
		/// <summary>上余白プロパティ</summary>
		/// <value>cmで指定。マイナス入力不可。有効桁数は小数点第１位まで（例0.8)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   上余白プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double TopMargin
		{
			get{return _topMargin;}
			set{_topMargin = value;}
		}

		/// public propaty name  :  LeftMargin
		/// <summary>左余白プロパティ</summary>
		/// <value>cmで指定。マイナス入力不可。有効桁数は小数点第１位まで（例0.8)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   左余白プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double LeftMargin
		{
			get{return _leftMargin;}
			set{_leftMargin = value;}
		}

		/// public propaty name  :  RightMargin
		/// <summary>右余白プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   右余白プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double RightMargin
		{
			get{return _rightMargin;}
			set{_rightMargin = value;}
		}

		/// public propaty name  :  BottomMargin
		/// <summary>下余白プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   下余白プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double BottomMargin
		{
			get{return _bottomMargin;}
			set{_bottomMargin = value;}
		}


		/// <summary>
		/// 自由帳票スキーマグループワークコンストラクタ
		/// </summary>
		/// <returns>FPprSchmGrWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FPprSchmGrWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public FPprSchmGrWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0用のカスタムシライアライザです。
	/// </summary>
	/// <returns>FPprSchmGrWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   FPprSchmGrWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public class FPprSchmGrWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate メンバ
		
		/// <summary>
		///  Ver5.10.1.0用のカスタムシリアライザです
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   FPprSchmGrWorkクラスのカスタムシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  FPprSchmGrWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
			if(  writer == null )
				throw new ArgumentNullException();

			if( graph != null && !( graph is FPprSchmGrWork || graph is ArrayList || graph is FPprSchmGrWork[]) )
				throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof(FPprSchmGrWork).FullName ) );

			if( graph != null && graph is FPprSchmGrWork )
			{
				Type t = graph.GetType();
				if( !CustomFormatterServices.NeedCustomSerialization( t ) )
					throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.FPprSchmGrWork" );

			//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
			int occurrence = 0;     //一般にゼロの場合もありえます
			if( graph is ArrayList )
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}else if( graph is FPprSchmGrWork[] )
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((FPprSchmGrWork[])graph).Length;
			}
			else if( graph is FPprSchmGrWork )
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
			//出力ファイル名
			serInfo.MemberInfo.Add( typeof(string) ); //OutputFormFileName
			//出力ファイルクラスID
			serInfo.MemberInfo.Add( typeof(string) ); //OutputFileClassId
			//自由帳票項目グループコード
			serInfo.MemberInfo.Add( typeof(Int32) ); //FreePrtPprItemGrpCd
			//出力名称
			serInfo.MemberInfo.Add( typeof(string) ); //DisplayName
			//データ入力システム
			serInfo.MemberInfo.Add( typeof(Int32) ); //DataInputSystem
			//帳票区分コード
			serInfo.MemberInfo.Add( typeof(Int32) ); //PrintPaperDivCd
			//帳票使用区分
			serInfo.MemberInfo.Add( typeof(Int32) ); //PrintPaperUseDivcd
			//特殊コンバート使用区分
			serInfo.MemberInfo.Add( typeof(Int32) ); //SpecialConvtUseDivCd
			//オプションコード
			serInfo.MemberInfo.Add( typeof(string) ); //OptionCode
			//改頁行数
			serInfo.MemberInfo.Add( typeof(Int32) ); //FormFeedLineCount
			//改行文字数
			serInfo.MemberInfo.Add( typeof(Int32) ); //CrCharCnt
			//上余白
			serInfo.MemberInfo.Add( typeof(Double) ); //TopMargin
			//左余白
			serInfo.MemberInfo.Add( typeof(Double) ); //LeftMargin
			//右余白
			serInfo.MemberInfo.Add( typeof(Double) ); //RightMargin
			//下余白
			serInfo.MemberInfo.Add( typeof(Double) ); //BottomMargin

				
			serInfo.Serialize( writer, serInfo );
			if( graph is FPprSchmGrWork )
			{
				FPprSchmGrWork temp = (FPprSchmGrWork)graph;

				SetFPprSchmGrWork(writer, temp);
			}
			else
			{
				ArrayList lst= null;
				if(graph is FPprSchmGrWork[])
				{
					lst = new ArrayList();
					lst.AddRange((FPprSchmGrWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;	
				}

				foreach(FPprSchmGrWork temp in lst)
				{
					SetFPprSchmGrWork(writer, temp);
				}

			}

			
		}


		/// <summary>
		/// FPprSchmGrWorkメンバ数(publicプロパティ数)
		/// </summary>
		private const int currentMemberCount = 19;
			
		/// <summary>
		///  FPprSchmGrWorkインスタンス書き込み
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   FPprSchmGrWorkのインスタンスを書き込み</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private void SetFPprSchmGrWork( System.IO.BinaryWriter writer, FPprSchmGrWork temp )
		{
			//作成日時
			writer.Write( (Int64)temp.CreateDateTime.Ticks );
			//更新日時
			writer.Write( (Int64)temp.UpdateDateTime.Ticks );
			//論理削除区分
			writer.Write( temp.LogicalDeleteCode );
			//自由帳票スキーマグループコード
			writer.Write( temp.FreePrtPprSchmGrpCd );
			//出力ファイル名
			writer.Write( temp.OutputFormFileName );
			//出力ファイルクラスID
			writer.Write( temp.OutputFileClassId );
			//自由帳票項目グループコード
			writer.Write( temp.FreePrtPprItemGrpCd );
			//出力名称
			writer.Write( temp.DisplayName );
			//データ入力システム
			writer.Write( temp.DataInputSystem );
			//帳票区分コード
			writer.Write( temp.PrintPaperDivCd );
			//帳票使用区分
			writer.Write( temp.PrintPaperUseDivcd );
			//特殊コンバート使用区分
			writer.Write( temp.SpecialConvtUseDivCd );
			//オプションコード
			writer.Write( temp.OptionCode );
			//改頁行数
			writer.Write( temp.FormFeedLineCount );
			//改行文字数
			writer.Write( temp.CrCharCnt );
			//上余白
			writer.Write( temp.TopMargin );
			//左余白
			writer.Write( temp.LeftMargin );
			//右余白
			writer.Write( temp.RightMargin );
			//下余白
			writer.Write( temp.BottomMargin );

		}

		/// <summary>
		///  FPprSchmGrWorkインスタンス取得
		/// </summary>
		/// <returns>FPprSchmGrWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FPprSchmGrWorkのインスタンスを取得します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private FPprSchmGrWork GetFPprSchmGrWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
		{
			// V5.1.0.0なので不要ですが、V5.1.0.1以降では
			// serInfo.MemberInfo.Count < currentMemberCount
			// のケースについての配慮が必要になります。

			FPprSchmGrWork temp = new FPprSchmGrWork();

			//作成日時
			temp.CreateDateTime = new DateTime(reader.ReadInt64());
			//更新日時
			temp.UpdateDateTime = new DateTime(reader.ReadInt64());
			//論理削除区分
			temp.LogicalDeleteCode = reader.ReadInt32();
			//自由帳票スキーマグループコード
			temp.FreePrtPprSchmGrpCd = reader.ReadInt32();
			//出力ファイル名
			temp.OutputFormFileName = reader.ReadString();
			//出力ファイルクラスID
			temp.OutputFileClassId = reader.ReadString();
			//自由帳票項目グループコード
			temp.FreePrtPprItemGrpCd = reader.ReadInt32();
			//出力名称
			temp.DisplayName = reader.ReadString();
			//データ入力システム
			temp.DataInputSystem = reader.ReadInt32();
			//帳票区分コード
			temp.PrintPaperDivCd = reader.ReadInt32();
			//帳票使用区分
			temp.PrintPaperUseDivcd = reader.ReadInt32();
			//特殊コンバート使用区分
			temp.SpecialConvtUseDivCd = reader.ReadInt32();
			//オプションコード
			temp.OptionCode = reader.ReadString();
			//改頁行数
			temp.FormFeedLineCount = reader.ReadInt32();
			//改行文字数
			temp.CrCharCnt = reader.ReadInt32();
			//上余白
			temp.TopMargin = reader.ReadDouble();
			//左余白
			temp.LeftMargin = reader.ReadDouble();
			//右余白
			temp.RightMargin = reader.ReadDouble();
			//下余白
			temp.BottomMargin = reader.ReadDouble();

				
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
		/// <returns>FPprSchmGrWorkクラスのインスタンス(object)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FPprSchmGrWorkクラスのカスタムデシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
			ArrayList lst = new ArrayList();
			for( int cnt = 0 ; cnt < serInfo.Occurrence ; ++cnt )
			{
				FPprSchmGrWork temp = GetFPprSchmGrWork( reader, serInfo );
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
					retValue = (FPprSchmGrWork[])lst.ToArray(typeof(FPprSchmGrWork));
					break;
			}
			return retValue;
		}

		#endregion
	}
}
