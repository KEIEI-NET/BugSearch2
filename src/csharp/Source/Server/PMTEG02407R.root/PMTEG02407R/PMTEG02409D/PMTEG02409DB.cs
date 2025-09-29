//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形月別予定表抽出条件クラスワーク
// プログラム概要   : 手形月別予定表抽出条件クラスワークヘッダファイル
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 姜凱
// 作 成 日  2010/05/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   TegataTsukibetsuYoteListReportResultWork
	/// <summary>
	///                      受取・支払手形データワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   受取・支払手形データワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2008/4/24</br>
	/// <br>Genarated Date   :   2010/04/22  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class TegataTsukibetsuYoteListReportResultWork : IFileHeader
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

		/// <summary>手形種別</summary>
		/// <remarks>0:手持 1:取立 2:割引 3:譲渡 4:担保 5:不渡 6:支払 7:先付 9:決済</remarks>
		private Int32 _draftKindCd;

		/// <summary>手形区分</summary>
		/// <remarks>0:自振 1:他振　※旧自他振区分</remarks>
		private Int32 _draftDivide;

		/// <summary>入金金額/支払金額</summary>
		/// <remarks>値引・手数料を除いた額</remarks>
		private Int64 _deposit;

		/// <summary>銀行・支店コード</summary>
		/// <remarks>頭4桁銀行ｺｰﾄﾞ､下3桁支店ｺｰﾄﾞ</remarks>
		private Int32 _bankAndBranchCd;

		/// <summary>銀行・支店名称</summary>
		private string _bankAndBranchNm = "";

		/// <summary>有効期限</summary>
		/// <remarks>YYYYMMDD　※期日、満期日として使用</remarks>
		private Int32 _validityTerm;

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

		/// public propaty name  :  DraftKindCd
		/// <summary>手形種別プロパティ</summary>
		/// <value>0:手持 1:取立 2:割引 3:譲渡 4:担保 5:不渡 6:支払 7:先付 9:決済</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   手形種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DraftKindCd
		{
			get { return _draftKindCd; }
			set { _draftKindCd = value; }
		}

		/// public propaty name  :  DraftDivide
		/// <summary>手形区分プロパティ</summary>
		/// <value>0:自振 1:他振　※旧自他振区分</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   手形区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DraftDivide
		{
			get{return _draftDivide;}
			set{_draftDivide = value;}
		}

		/// public propaty name  :  Deposit
		/// <summary>入金金額/支払金額プロパティ</summary>
		/// <value>値引・手数料を除いた額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金金額/支払金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 Deposit
		{
			get{return _deposit;}
			set{_deposit = value;}
		}

		/// public propaty name  :  BankAndBranchCd
		/// <summary>銀行・支店コードプロパティ</summary>
		/// <value>頭4桁銀行ｺｰﾄﾞ､下3桁支店ｺｰﾄﾞ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   銀行・支店コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BankAndBranchCd
		{
			get { return _bankAndBranchCd; }
			set { _bankAndBranchCd = value; }
		}

		/// public propaty name  :  BankAndBranchNm
		/// <summary>銀行・支店名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   銀行・支店名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BankAndBranchNm
		{
			get { return _bankAndBranchNm; }
			set { _bankAndBranchNm = value; }
		}

		/// public propaty name  :  ValidityTerm
		/// <summary>有効期限プロパティ</summary>
		/// <value>YYYYMMDD　※期日、満期日として使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   有効期限プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ValidityTerm
		{
			get{return _validityTerm;}
			set{_validityTerm = value;}
		}

		/// <summary>
		/// 受取・支払手形データワークコンストラクタ
		/// </summary>
		/// <returns>TegataTsukibetsuYoteListReportResultWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   TegataTsukibetsuYoteListReportResultWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public TegataTsukibetsuYoteListReportResultWork()
		{
		}

	}
	
	/// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>TegataTsukibetsuYoteListReportResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   TegataTsukibetsuYoteListReportResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class TegataTsukibetsuYoteListReportResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
	    #region ICustomSerializationSurrogate メンバ
    	
	    /// <summary>
	    ///  Ver5.10.1.0用のカスタムシリアライザです
	    /// </summary>
	    /// <remarks>
	    /// <br>Note　　　　　　 :   TegataTsukibetsuYoteListReportResultWorkクラスのカスタムシリアライザを定義します</br>
	    /// <br>Programer        :   自動生成</br>
	    /// </remarks>
	    public void Serialize(System.IO.BinaryWriter writer, object graph)
	    {
		    // TODO:  TegataTsukibetsuYoteListReportResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
		    if(  writer == null )
			    throw new ArgumentNullException();

		    if( graph != null && !( graph is TegataTsukibetsuYoteListReportResultWork || graph is ArrayList || graph is TegataTsukibetsuYoteListReportResultWork[]) )
			    throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof(TegataTsukibetsuYoteListReportResultWork).FullName ) );

		    if( graph != null && graph is TegataTsukibetsuYoteListReportResultWork )
		    {
			    Type t = graph.GetType();
			    if( !CustomFormatterServices.NeedCustomSerialization( t ) )
				    throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
		    }

		    //SerializationTypeInfo
		    Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.TegataTsukibetsuYoteListReportResultWork" );

		    //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
		    int occurrence = 0;     //一般にゼロの場合もありえます
		    if( graph is ArrayList )
		    {
			    serInfo.RetTypeInfo = 0;
			    occurrence = ((ArrayList)graph).Count;
		    }else if( graph is TegataTsukibetsuYoteListReportResultWork[] )
		    {
			    serInfo.RetTypeInfo = 2;
			    occurrence = ((TegataTsukibetsuYoteListReportResultWork[])graph).Length;
		    }
		    else if( graph is TegataTsukibetsuYoteListReportResultWork )
		    {
			    serInfo.RetTypeInfo = 1;
			    occurrence = 1;
		    }

		    serInfo.Occurrence = occurrence;		 //繰り返し数	

			//作成日時
			serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
			//更新日時
			serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
			//企業コード
			serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
			//GUID
			serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
			//更新従業員コード
			serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
			//更新アセンブリID1
			serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
			//更新アセンブリID2
			serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
			//論理削除区分
			serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
			//手形種別
			serInfo.MemberInfo.Add(typeof(Int32)); //DraftKindCd
			//手形区分
			serInfo.MemberInfo.Add(typeof(Int32)); //DraftDivide
			//入金金額/支払金額
			serInfo.MemberInfo.Add(typeof(Int64)); //Deposit
			//銀行・支店コード
			serInfo.MemberInfo.Add(typeof(Int32)); //BankAndBranchCd
			//銀行・支店名称
			serInfo.MemberInfo.Add(typeof(string)); //BankAndBranchNm
			//有効期限
			serInfo.MemberInfo.Add(typeof(Int32)); //ValidityTerm

    			
		    serInfo.Serialize( writer, serInfo );
		    if( graph is TegataTsukibetsuYoteListReportResultWork )
		    {
			    TegataTsukibetsuYoteListReportResultWork temp = (TegataTsukibetsuYoteListReportResultWork)graph;

			    SetTegataTsukibetsuYoteListReportResultWork(writer, temp);
		    }
		    else
		    {
			    ArrayList lst= null;
			    if(graph is TegataTsukibetsuYoteListReportResultWork[])
			    {
				    lst = new ArrayList();
				    lst.AddRange((TegataTsukibetsuYoteListReportResultWork[])graph);
			    }
			    else
			    {
				    lst = (ArrayList)graph;	
			    }

			    foreach(TegataTsukibetsuYoteListReportResultWork temp in lst)
			    {
				    SetTegataTsukibetsuYoteListReportResultWork(writer, temp);
			    }

		    }

    		
	    }


	    /// <summary>
	    /// TegataTsukibetsuYoteListReportResultWorkメンバ数(publicプロパティ数)
	    /// </summary>
	    private const int currentMemberCount = 14;
    		
	    /// <summary>
	    ///  TegataTsukibetsuYoteListReportResultWorkインスタンス書き込み
	    /// </summary>
	    /// <remarks>
	    /// <br>Note　　　　　　 :   TegataTsukibetsuYoteListReportResultWorkのインスタンスを書き込み</br>
	    /// <br>Programer        :   自動生成</br>
	    /// </remarks>
	    private void SetTegataTsukibetsuYoteListReportResultWork( System.IO.BinaryWriter writer, TegataTsukibetsuYoteListReportResultWork temp )
	    {
			//作成日時
			writer.Write((Int64)temp.CreateDateTime.Ticks);
			//更新日時
			writer.Write((Int64)temp.UpdateDateTime.Ticks);
			//企業コード
			writer.Write(temp.EnterpriseCode);
			//GUID
			byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
			writer.Write(fileHeaderGuidArray.Length);
			writer.Write(temp.FileHeaderGuid.ToByteArray());
			//更新従業員コード
			writer.Write(temp.UpdEmployeeCode);
			//更新アセンブリID1
			writer.Write(temp.UpdAssemblyId1);
			//更新アセンブリID2
			writer.Write(temp.UpdAssemblyId2);
			//論理削除区分
			writer.Write(temp.LogicalDeleteCode);
			//手形種別
			writer.Write(temp.DraftKindCd);
			//手形区分
			writer.Write(temp.DraftDivide);
			//入金金額/支払金額
			writer.Write(temp.Deposit);
			//銀行・支店コード
			writer.Write(temp.BankAndBranchCd);
			//銀行・支店名称
			writer.Write(temp.BankAndBranchNm);
			//有効期限
			writer.Write(temp.ValidityTerm);

	    }

	    /// <summary>
	    ///  TegataTsukibetsuYoteListReportResultWorkインスタンス取得
	    /// </summary>
	    /// <returns>TegataTsukibetsuYoteListReportResultWorkクラスのインスタンス</returns>
	    /// <remarks>
	    /// <br>Note　　　　　　 :   TegataTsukibetsuYoteListReportResultWorkのインスタンスを取得します</br>
	    /// <br>Programer        :   自動生成</br>
	    /// </remarks>
	    private TegataTsukibetsuYoteListReportResultWork GetTegataTsukibetsuYoteListReportResultWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
	    {
		    // V5.1.0.0なので不要ですが、V5.1.0.1以降では
		    // serInfo.MemberInfo.Count < currentMemberCount
		    // のケースについての配慮が必要になります。

		    TegataTsukibetsuYoteListReportResultWork temp = new TegataTsukibetsuYoteListReportResultWork();

			//作成日時
			temp.CreateDateTime = new DateTime(reader.ReadInt64());
			//更新日時
			temp.UpdateDateTime = new DateTime(reader.ReadInt64());
			//企業コード
			temp.EnterpriseCode = reader.ReadString();
			//GUID
			int lenOfFileHeaderGuidArray = reader.ReadInt32();
			byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
			temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
			//更新従業員コード
			temp.UpdEmployeeCode = reader.ReadString();
			//更新アセンブリID1
			temp.UpdAssemblyId1 = reader.ReadString();
			//更新アセンブリID2
			temp.UpdAssemblyId2 = reader.ReadString();
			//論理削除区分
			temp.LogicalDeleteCode = reader.ReadInt32();
			//手形種別
			temp.DraftKindCd = reader.ReadInt32();
			//手形区分
			temp.DraftDivide = reader.ReadInt32();
			//入金金額/支払金額
			temp.Deposit = reader.ReadInt64();
			//銀行・支店コード
			temp.BankAndBranchCd = reader.ReadInt32();
			//銀行・支店名称
			temp.BankAndBranchNm = reader.ReadString();
			//有効期限
			temp.ValidityTerm = reader.ReadInt32();

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
	    /// <returns>TegataTsukibetsuYoteListReportResultWorkクラスのインスタンス(object)</returns>
	    /// <remarks>
	    /// <br>Note　　　　　　 :   TegataTsukibetsuYoteListReportResultWorkクラスのカスタムデシリアライザを定義します</br>
	    /// <br>Programer        :   自動生成</br>
	    /// </remarks>
	    public object Deserialize(System.IO.BinaryReader reader)
	    {
		    object retValue = null;
		    Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
		    ArrayList lst = new ArrayList();
		    for( int cnt = 0 ; cnt < serInfo.Occurrence ; ++cnt )
		    {
			    TegataTsukibetsuYoteListReportResultWork temp = GetTegataTsukibetsuYoteListReportResultWork( reader, serInfo );
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
				    retValue = (TegataTsukibetsuYoteListReportResultWork[])lst.ToArray(typeof(TegataTsukibetsuYoteListReportResultWork));
				    break;
		    }
		    return retValue;
	    }

	    #endregion
    }

}
