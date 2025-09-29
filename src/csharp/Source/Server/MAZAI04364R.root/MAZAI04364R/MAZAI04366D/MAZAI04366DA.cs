using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

//拠点ガイド名称、仕入拠点ガイド名称を忘れずに追加すること！！

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// ＰＭ用受払伝票区分
    /// </summary>
    /// <remarks>
    /// <br>Note       : ＰＭで不足している受払伝票区分です</br>
    /// <br>Programmer : 22008　長内　数馬</br>
    /// <br>Date       : 2009.01.21</br>
    /// <br></br>
    /// </remarks>
    public enum ct_AcPaySlipCd_PM
    {
        /// <summary>組立</summary>
        assemble = 60, 
        /// <summary>分解</summary>
        separate = 61, 
        /// <summary>補充入庫</summary>
        replacement = 70, 
        /// <summary>補充出庫</summary>
        replaceShip = 71, 
    }


	/// public class name:   StockAdjustWork
	/// <summary>
	///                      在庫調整データワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   在庫調整データワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2008/3/25</br>
	/// <br>Genarated Date   :   2008/08/25  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2008/6/20  長内</br>
	/// <br>                 :   受払元伝票区分,受払元取引区分の補足に</br>
	/// <br>                 :   「42:マスタメンテ」追加</br>
	/// <br>Update Note      :   2008/6/30  杉村</br>
	/// <br>                 :   受払元取引区分の補足の</br>
	/// <br>                 :   「42:マスタメンテ」削除</br>
	/// <br>Update Note      :   2008/8/22  長内</br>
	/// <br>                 :   ○項目削除</br>
	/// <br>                 :   　入力担当者コード</br>
	/// <br>                 :   　入力担当者名称</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   　仕入拠点コード</br>
	/// <br>                 :   　仕入入力者コード</br>
	/// <br>                 :   　仕入入力者名称</br>
	/// <br>                 :   　仕入担当者コード</br>
	/// <br>                 :   　仕入担当者名称</br>
	/// <br>                 :   　仕入金額小計</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class StockAdjustWork : IFileHeader
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

        /// <summary>拠点ガイド名称</summary>
        private string _sectionGuideNm = "";
        
        /// <summary>在庫調整伝票番号</summary>
		private Int32 _stockAdjustSlipNo;

		/// <summary>受払元伝票区分</summary>
		/// <remarks>10:仕入,11:受託,12:受計上,13:在庫仕入,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,42:マスタメンテ,50:棚卸</remarks>
		private Int32 _acPaySlipCd;

		/// <summary>受払元取引区分</summary>
		/// <remarks>10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消</remarks>
		private Int32 _acPayTransCd;

		/// <summary>調整日付</summary>
		private DateTime _adjustDate;

		/// <summary>入力日付</summary>
		private DateTime _inputDay;

        /// <summary>仕入拠点コード</summary>
        private string _stockSectionCd = "";
 
        /// <summary>仕入拠点ガイド名称</summary>
        private string _stockSectionGuideNm = "";

		/// <summary>仕入入力者コード</summary>
		private string _stockInputCode = "";

		/// <summary>仕入入力者名称</summary>
		private string _stockInputName = "";

		/// <summary>仕入担当者コード</summary>
		private string _stockAgentCode = "";

		/// <summary>仕入担当者名称</summary>
		private string _stockAgentName = "";

		/// <summary>仕入金額小計</summary>
		private Int64 _stockSubttlPrice;

		/// <summary>伝票備考</summary>
		private string _slipNote = "";


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

        /// public propaty name  :  SectionGuideNm
        /// <summary>拠点ガイド名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }
        
        /// public propaty name  :  StockAdjustSlipNo
		/// <summary>在庫調整伝票番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫調整伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockAdjustSlipNo
		{
			get{return _stockAdjustSlipNo;}
			set{_stockAdjustSlipNo = value;}
		}

		/// public propaty name  :  AcPaySlipCd
		/// <summary>受払元伝票区分プロパティ</summary>
		/// <value>10:仕入,11:受託,12:受計上,13:在庫仕入,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,42:マスタメンテ,50:棚卸</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受払元伝票区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcPaySlipCd
		{
			get{return _acPaySlipCd;}
			set{_acPaySlipCd = value;}
		}

		/// public propaty name  :  AcPayTransCd
		/// <summary>受払元取引区分プロパティ</summary>
		/// <value>10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受払元取引区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcPayTransCd
		{
			get{return _acPayTransCd;}
			set{_acPayTransCd = value;}
		}

		/// public propaty name  :  AdjustDate
		/// <summary>調整日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   調整日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AdjustDate
		{
			get{return _adjustDate;}
			set{_adjustDate = value;}
		}

		/// public propaty name  :  InputDay
		/// <summary>入力日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime InputDay
		{
			get{return _inputDay;}
			set{_inputDay = value;}
		}

		/// public propaty name  :  StockSectionCd
		/// <summary>仕入拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockSectionCd
		{
			get{return _stockSectionCd;}
			set{_stockSectionCd = value;}
		}

        /// public propaty name  :  StockSectionGuideNm
        /// <summary>仕入拠点ガイド名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockSectionGuideNm
        {
            get { return _stockSectionGuideNm; }
            set { _stockSectionGuideNm = value; }
        }
        
        /// public propaty name  :  StockInputCode
		/// <summary>仕入入力者コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入入力者コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockInputCode
		{
			get{return _stockInputCode;}
			set{_stockInputCode = value;}
		}

		/// public propaty name  :  StockInputName
		/// <summary>仕入入力者名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入入力者名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockInputName
		{
			get{return _stockInputName;}
			set{_stockInputName = value;}
		}

		/// public propaty name  :  StockAgentCode
		/// <summary>仕入担当者コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入担当者コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockAgentCode
		{
			get{return _stockAgentCode;}
			set{_stockAgentCode = value;}
		}

		/// public propaty name  :  StockAgentName
		/// <summary>仕入担当者名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入担当者名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockAgentName
		{
			get{return _stockAgentName;}
			set{_stockAgentName = value;}
		}

		/// public propaty name  :  StockSubttlPrice
		/// <summary>仕入金額小計プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入金額小計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockSubttlPrice
		{
			get{return _stockSubttlPrice;}
			set{_stockSubttlPrice = value;}
		}

		/// public propaty name  :  SlipNote
		/// <summary>伝票備考プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票備考プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SlipNote
		{
			get{return _slipNote;}
			set{_slipNote = value;}
		}


		/// <summary>
		/// 在庫調整データワークコンストラクタ
		/// </summary>
		/// <returns>StockAdjustWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockAdjustWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockAdjustWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StockAdjustWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StockAdjustWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class StockAdjustWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
	    #region ICustomSerializationSurrogate メンバ
    	
	    /// <summary>
	    ///  Ver5.10.1.0用のカスタムシリアライザです
	    /// </summary>
	    /// <remarks>
	    /// <br>Note　　　　　　 :   StockAdjustWorkクラスのカスタムシリアライザを定義します</br>
	    /// <br>Programer        :   自動生成</br>
	    /// </remarks>
	    public void Serialize(System.IO.BinaryWriter writer, object graph)
	    {
		    // TODO:  StockAdjustWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
		    if(  writer == null )
			    throw new ArgumentNullException();

		    if( graph != null && !( graph is StockAdjustWork || graph is ArrayList || graph is StockAdjustWork[]) )
			    throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof(StockAdjustWork).FullName ) );

		    if( graph != null && graph is StockAdjustWork )
		    {
			    Type t = graph.GetType();
			    if( !CustomFormatterServices.NeedCustomSerialization( t ) )
				    throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
		    }

		    //SerializationTypeInfo
		    Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockAdjustWork" );

		    //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
		    int occurrence = 0;     //一般にゼロの場合もありえます
		    if( graph is ArrayList )
		    {
			    serInfo.RetTypeInfo = 0;
			    occurrence = ((ArrayList)graph).Count;
		    }else if( graph is StockAdjustWork[] )
		    {
			    serInfo.RetTypeInfo = 2;
			    occurrence = ((StockAdjustWork[])graph).Length;
		    }
		    else if( graph is StockAdjustWork )
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
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点ガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //在庫調整伝票番号
		    serInfo.MemberInfo.Add( typeof(Int32) ); //StockAdjustSlipNo
		    //受払元伝票区分
		    serInfo.MemberInfo.Add( typeof(Int32) ); //AcPaySlipCd
		    //受払元取引区分
		    serInfo.MemberInfo.Add( typeof(Int32) ); //AcPayTransCd
		    //調整日付
		    serInfo.MemberInfo.Add( typeof(Int32) ); //AdjustDate
		    //入力日付
		    serInfo.MemberInfo.Add( typeof(Int32) ); //InputDay
            //仕入拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionCd
            //仕入拠点ガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionGuideNm
            //仕入入力者コード
		    serInfo.MemberInfo.Add( typeof(string) ); //StockInputCode
		    //仕入入力者名称
		    serInfo.MemberInfo.Add( typeof(string) ); //StockInputName
		    //仕入担当者コード
		    serInfo.MemberInfo.Add( typeof(string) ); //StockAgentCode
		    //仕入担当者名称
		    serInfo.MemberInfo.Add( typeof(string) ); //StockAgentName
		    //仕入金額小計
		    serInfo.MemberInfo.Add( typeof(Int64) ); //StockSubttlPrice
		    //伝票備考
		    serInfo.MemberInfo.Add( typeof(string) ); //SlipNote

    			
		    serInfo.Serialize( writer, serInfo );
		    if( graph is StockAdjustWork )
		    {
			    StockAdjustWork temp = (StockAdjustWork)graph;

			    SetStockAdjustWork(writer, temp);
		    }
		    else
		    {
			    ArrayList lst= null;
			    if(graph is StockAdjustWork[])
			    {
				    lst = new ArrayList();
				    lst.AddRange((StockAdjustWork[])graph);
			    }
			    else
			    {
				    lst = (ArrayList)graph;	
			    }

			    foreach(StockAdjustWork temp in lst)
			    {
				    SetStockAdjustWork(writer, temp);
			    }

		    }

    		
	    }


	    /// <summary>
	    /// StockAdjustWorkメンバ数(publicプロパティ数)
	    /// </summary>
	    private const int currentMemberCount = 23;
    		
	    /// <summary>
	    ///  StockAdjustWorkインスタンス書き込み
	    /// </summary>
	    /// <remarks>
	    /// <br>Note　　　　　　 :   StockAdjustWorkのインスタンスを書き込み</br>
	    /// <br>Programer        :   自動生成</br>
	    /// </remarks>
	    private void SetStockAdjustWork( System.IO.BinaryWriter writer, StockAdjustWork temp )
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
            writer.Write(temp.SectionCode);
            //拠点ガイド名称
            writer.Write(temp.SectionGuideNm);
            //在庫調整伝票番号
		    writer.Write( temp.StockAdjustSlipNo );
		    //受払元伝票区分
		    writer.Write( temp.AcPaySlipCd );
		    //受払元取引区分
		    writer.Write( temp.AcPayTransCd );
		    //調整日付
		    writer.Write( (Int64)temp.AdjustDate.Ticks );
		    //入力日付
		    writer.Write( (Int64)temp.InputDay.Ticks );
            //仕入拠点コード
            writer.Write(temp.StockSectionCd);
            //仕入拠点ガイド名称
            writer.Write(temp.StockSectionGuideNm);
            //仕入入力者コード
		    writer.Write( temp.StockInputCode );
		    //仕入入力者名称
		    writer.Write( temp.StockInputName );
		    //仕入担当者コード
		    writer.Write( temp.StockAgentCode );
		    //仕入担当者名称
		    writer.Write( temp.StockAgentName );
		    //仕入金額小計
		    writer.Write( temp.StockSubttlPrice );
		    //伝票備考
		    writer.Write( temp.SlipNote );

	    }

	    /// <summary>
	    ///  StockAdjustWorkインスタンス取得
	    /// </summary>
	    /// <returns>StockAdjustWorkクラスのインスタンス</returns>
	    /// <remarks>
	    /// <br>Note　　　　　　 :   StockAdjustWorkのインスタンスを取得します</br>
	    /// <br>Programer        :   自動生成</br>
	    /// </remarks>
	    private StockAdjustWork GetStockAdjustWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
	    {
		    // V5.1.0.0なので不要ですが、V5.1.0.1以降では
		    // serInfo.MemberInfo.Count < currentMemberCount
		    // のケースについての配慮が必要になります。

		    StockAdjustWork temp = new StockAdjustWork();

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
            //拠点ガイド名称
            temp.SectionGuideNm = reader.ReadString();
            //在庫調整伝票番号
		    temp.StockAdjustSlipNo = reader.ReadInt32();
		    //受払元伝票区分
		    temp.AcPaySlipCd = reader.ReadInt32();
		    //受払元取引区分
		    temp.AcPayTransCd = reader.ReadInt32();
		    //調整日付
		    temp.AdjustDate = new DateTime(reader.ReadInt64());
		    //入力日付
		    temp.InputDay = new DateTime(reader.ReadInt64());
            //仕入拠点コード
            temp.StockSectionCd = reader.ReadString();
            //仕入拠点ガイド名称
            temp.StockSectionGuideNm = reader.ReadString();
            //仕入入力者コード
		    temp.StockInputCode = reader.ReadString();
		    //仕入入力者名称
		    temp.StockInputName = reader.ReadString();
		    //仕入担当者コード
		    temp.StockAgentCode = reader.ReadString();
		    //仕入担当者名称
		    temp.StockAgentName = reader.ReadString();
		    //仕入金額小計
		    temp.StockSubttlPrice = reader.ReadInt64();
		    //伝票備考
		    temp.SlipNote = reader.ReadString();

    			
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
	    /// <returns>StockAdjustWorkクラスのインスタンス(object)</returns>
	    /// <remarks>
	    /// <br>Note　　　　　　 :   StockAdjustWorkクラスのカスタムデシリアライザを定義します</br>
	    /// <br>Programer        :   自動生成</br>
	    /// </remarks>
	    public object Deserialize(System.IO.BinaryReader reader)
	    {
		    object retValue = null;
		    Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
		    ArrayList lst = new ArrayList();
		    for( int cnt = 0 ; cnt < serInfo.Occurrence ; ++cnt )
		    {
			    StockAdjustWork temp = GetStockAdjustWork( reader, serInfo );
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
				    retValue = (StockAdjustWork[])lst.ToArray(typeof(StockAdjustWork));
				    break;
		    }
		    return retValue;
	    }

	    #endregion
    }

}
