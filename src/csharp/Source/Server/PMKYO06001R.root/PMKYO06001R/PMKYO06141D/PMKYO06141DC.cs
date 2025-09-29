//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   マスタ送受信抽出・更新DB仲介クラス              //
//                  :   PMKYO06141D.DLL                                 //
// Name Space       :   Broadleaf.Application.Remoting.ParamData        //
// Programmer       :   呉元嘯                                          //
// Date             :   2009.04.28                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   APCustSlipMngWork
	/// <summary>
	///                      得意先（伝票管理）ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   得意先（伝票管理）ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2008/3/26</br>
	/// <br>Genarated Date   :   2009/04/28  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2009/1/28  長内</br>
	/// <br>                 :   ○伝票種別補足説明追加</br>
	/// <br>                 :   120:受注伝票,130:見積伝票,140:貸出伝票</br>
	/// <br>                 :   ,150:在庫移動伝票,160:UOE伝票</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class APCustSlipMngWork : IFileHeader
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

		/// <summary>データ入力システム</summary>
		/// <remarks>0:共通,1:整備,2:鈑金,3:車販</remarks>
		private Int32 _dataInputSystem;

		/// <summary>伝票印刷種別</summary>
		/// <remarks>10:見積書,20:指示書（注文書）,21:承り書,30:納品書 40:返品伝票,100:ワークシート,110:ボディ寸法図,120:受注伝票,130:見積伝票,140:貸出伝票,150:在庫移動伝票,160:UOE伝票</remarks>
		private Int32 _slipPrtKind;

		/// <summary>拠点コード</summary>
		/// <remarks>0の場合は自社設定又は得意先設定</remarks>
		private string _sectionCode = "";

		/// <summary>得意先コード</summary>
		/// <remarks>0の場合は自社設定又は拠点設定</remarks>
		private Int32 _customerCode;

		/// <summary>伝票印刷設定用帳票ID</summary>
		/// <remarks>伝票印刷設定用</remarks>
		private string _slipPrtSetPaperId = "";


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

		/// public propaty name  :  SlipPrtKind
		/// <summary>伝票印刷種別プロパティ</summary>
		/// <value>10:見積書,20:指示書（注文書）,21:承り書,30:納品書 40:返品伝票,100:ワークシート,110:ボディ寸法図,120:受注伝票,130:見積伝票,140:貸出伝票,150:在庫移動伝票,160:UOE伝票</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票印刷種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipPrtKind
		{
			get{return _slipPrtKind;}
			set{_slipPrtKind = value;}
		}

		/// public propaty name  :  SectionCode
		/// <summary>拠点コードプロパティ</summary>
		/// <value>0の場合は自社設定又は得意先設定</value>
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

		/// public propaty name  :  CustomerCode
		/// <summary>得意先コードプロパティ</summary>
		/// <value>0の場合は自社設定又は拠点設定</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get{return _customerCode;}
			set{_customerCode = value;}
		}

		/// public propaty name  :  SlipPrtSetPaperId
		/// <summary>伝票印刷設定用帳票IDプロパティ</summary>
		/// <value>伝票印刷設定用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票印刷設定用帳票IDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SlipPrtSetPaperId
		{
			get{return _slipPrtSetPaperId;}
			set{_slipPrtSetPaperId = value;}
		}


		/// <summary>
		/// 得意先（伝票管理）ワークコンストラクタ
		/// </summary>
		/// <returns>CustSlipMngWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustSlipMngWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public APCustSlipMngWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CustSlipMngWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CustSlipMngWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class APCustSlipMngWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
	#region ICustomSerializationSurrogate メンバ
	
	/// <summary>
	///  Ver5.10.1.0用のカスタムシリアライザです
	/// </summary>
	/// <remarks>
	/// <br>Note　　　　　　 :   CustSlipMngWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public void Serialize(System.IO.BinaryWriter writer, object graph)
	{
		// TODO:  CustSlipMngWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
		if(  writer == null )
			throw new ArgumentNullException();

		if( graph != null && !( graph is APCustSlipMngWork || graph is ArrayList || graph is APCustSlipMngWork[]) )
			throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof(APCustSlipMngWork).FullName ) );

		if( graph != null && graph is APCustSlipMngWork )
		{
			Type t = graph.GetType();
			if( !CustomFormatterServices.NeedCustomSerialization( t ) )
				throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
		}

		//SerializationTypeInfo
		Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustSlipMngWork" );

		//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
		int occurrence = 0;     //一般にゼロの場合もありえます
		if( graph is ArrayList )
		{
			serInfo.RetTypeInfo = 0;
			occurrence = ((ArrayList)graph).Count;
		}else if( graph is APCustSlipMngWork[] )
		{
			serInfo.RetTypeInfo = 2;
			occurrence = ((APCustSlipMngWork[])graph).Length;
		}
		else if( graph is APCustSlipMngWork )
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
		//データ入力システム
		serInfo.MemberInfo.Add( typeof(Int32) ); //DataInputSystem
		//伝票印刷種別
		serInfo.MemberInfo.Add( typeof(Int32) ); //SlipPrtKind
		//拠点コード
		serInfo.MemberInfo.Add( typeof(string) ); //SectionCode
		//得意先コード
		serInfo.MemberInfo.Add( typeof(Int32) ); //CustomerCode
		//伝票印刷設定用帳票ID
		serInfo.MemberInfo.Add( typeof(string) ); //SlipPrtSetPaperId

			
		serInfo.Serialize( writer, serInfo );
		if( graph is APCustSlipMngWork )
		{
			APCustSlipMngWork temp = (APCustSlipMngWork)graph;

			SetCustSlipMngWork(writer, temp);
		}
		else
		{
			ArrayList lst= null;
			if(graph is APCustSlipMngWork[])
			{
				lst = new ArrayList();
				lst.AddRange((APCustSlipMngWork[])graph);
			}
			else
			{
				lst = (ArrayList)graph;	
			}

			foreach(APCustSlipMngWork temp in lst)
			{
				SetCustSlipMngWork(writer, temp);
			}

		}

		
	}


	/// <summary>
	/// CustSlipMngWorkメンバ数(publicプロパティ数)
	/// </summary>
	private const int currentMemberCount = 13;
		
	/// <summary>
	///  CustSlipMngWorkインスタンス書き込み
	/// </summary>
	/// <remarks>
	/// <br>Note　　　　　　 :   CustSlipMngWorkのインスタンスを書き込み</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	private void SetCustSlipMngWork( System.IO.BinaryWriter writer, APCustSlipMngWork temp )
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
		//データ入力システム
		writer.Write( temp.DataInputSystem );
		//伝票印刷種別
		writer.Write( temp.SlipPrtKind );
		//拠点コード
		writer.Write( temp.SectionCode );
		//得意先コード
		writer.Write( temp.CustomerCode );
		//伝票印刷設定用帳票ID
		writer.Write( temp.SlipPrtSetPaperId );

	}

	/// <summary>
	///  CustSlipMngWorkインスタンス取得
	/// </summary>
	/// <returns>CustSlipMngWorkクラスのインスタンス</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   CustSlipMngWorkのインスタンスを取得します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	private APCustSlipMngWork GetCustSlipMngWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
	{
		// V5.1.0.0なので不要ですが、V5.1.0.1以降では
		// serInfo.MemberInfo.Count < currentMemberCount
		// のケースについての配慮が必要になります。

		APCustSlipMngWork temp = new APCustSlipMngWork();

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
		//データ入力システム
		temp.DataInputSystem = reader.ReadInt32();
		//伝票印刷種別
		temp.SlipPrtKind = reader.ReadInt32();
		//拠点コード
		temp.SectionCode = reader.ReadString();
		//得意先コード
		temp.CustomerCode = reader.ReadInt32();
		//伝票印刷設定用帳票ID
		temp.SlipPrtSetPaperId = reader.ReadString();

			
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
	/// <returns>CustSlipMngWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   CustSlipMngWorkクラスのカスタムデシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public object Deserialize(System.IO.BinaryReader reader)
	{
		object retValue = null;
		Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
		ArrayList lst = new ArrayList();
		for( int cnt = 0 ; cnt < serInfo.Occurrence ; ++cnt )
		{
			APCustSlipMngWork temp = GetCustSlipMngWork( reader, serInfo );
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
				retValue = (APCustSlipMngWork[])lst.ToArray(typeof(APCustSlipMngWork));
				break;
		}
		return retValue;
	}

	#endregion
}
}

