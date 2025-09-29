//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ送信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2011/07/27  修正内容 : 新規作成
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
	/// public class name:   APRcvDraftDataWork
	/// <summary>
	///                      受取手形データワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   受取手形データワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2008/4/24</br>
	/// <br>Genarated Date   :   2011/07/28  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2008/6/10  杉村</br>
	/// <br>                 :   項目追加</br>
	/// <br>                 :   カラーコード</br>
	/// <br>                 :   カラー名称1</br>
	/// <br>                 :   トリムコード</br>
	/// <br>                 :   トリム名称</br>
	/// <br>Update Note      :   2008/6/30  長内</br>
	/// <br>                 :   項目追加</br>
	/// <br>                 :   装備オブジェクト配列</br>
	/// <br>Update Note      :   2008/7/8  杉村</br>
	/// <br>                 :   項目追加</br>
	/// <br>                 :   原動機型式（エンジン）</br>
	/// <br>Update Note      :   2008/9/19  長内</br>
	/// <br>                 :   項目追加</br>
	/// <br>                 :   メーカー半角名称</br>
	/// <br>                 :   車種半角名称</br>
	/// <br>Update Note      :   2008/12/17  杉村</br>
	/// <br>                 :   項目修正（ＮＵＬＬ許可に変更）</br>
	/// <br>                 :   型式（類別記号）、型式（フル型）</br>
	/// <br>Update Note      :   2009/9/1  長内</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   　車輌追加情報１</br>
	/// <br>                 :   　車輌追加情報２</br>
	/// <br>                 :   　車輌備考</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class APRcvDraftDataWork : IFileHeader
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

		/// <summary>受取手形番号</summary>
		private string _rcvDraftNo = "";

		/// <summary>手形種別</summary>
		/// <remarks>0:手持 1:取立 2:割引 3:譲渡 4:担保 5:不渡 6:支払 7:先付 9:決済</remarks>
		private Int32 _draftKindCd;

		/// <summary>手形区分</summary>
		/// <remarks>0:自振 1:他振　※旧自他振区分</remarks>
		private Int32 _draftDivide;

		/// <summary>入金金額</summary>
		/// <remarks>値引・手数料を除いた額</remarks>
		private Int64 _deposit;

		/// <summary>銀行・支店コード</summary>
		/// <remarks>頭4桁銀行ｺｰﾄﾞ､下3桁支店ｺｰﾄﾞ</remarks>
		private Int32 _bankAndBranchCd;

		/// <summary>銀行・支店名称</summary>
		private string _bankAndBranchNm = "";

		/// <summary>拠点コード</summary>
		private string _sectionCode = "";

		/// <summary>計上拠点コード</summary>
		/// <remarks>※子でも手形ﾃﾞｰﾀが作成可なので必要</remarks>
		private string _addUpSecCode = "";

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;

		/// <summary>得意先名称</summary>
		private string _customerName = "";

		/// <summary>得意先名称2</summary>
		private string _customerName2 = "";

		/// <summary>得意先略称</summary>
		private string _customerSnm = "";

		/// <summary>処理日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _procDate;

		/// <summary>手形振出日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _draftDrawingDate;

		/// <summary>有効期限</summary>
		/// <remarks>YYYYMMDD　※期日、満期日として使用</remarks>
		private Int32 _validityTerm;

		/// <summary>手形決済日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _draftStmntDate;

		/// <summary>伝票摘要1</summary>
		private string _outline1 = "";

		/// <summary>伝票摘要2</summary>
		private string _outline2 = "";

		/// <summary>受注ステータス</summary>
		/// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
		private Int32 _acptAnOdrStatus;

		/// <summary>入金伝票番号</summary>
		private Int32 _depositSlipNo;

		/// <summary>入金行番号</summary>
		/// <remarks>※入金設定金種コードの設定番号をセット</remarks>
		private Int32 _depositRowNo;

		/// <summary>入金日付</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _depositDate;


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
			get { return _createDateTime; }
			set { _createDateTime = value; }
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
			get { return _updateDateTime; }
			set { _updateDateTime = value; }
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
			get { return _enterpriseCode; }
			set { _enterpriseCode = value; }
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
			get { return _fileHeaderGuid; }
			set { _fileHeaderGuid = value; }
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
			get { return _updEmployeeCode; }
			set { _updEmployeeCode = value; }
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
			get { return _updAssemblyId1; }
			set { _updAssemblyId1 = value; }
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
			get { return _updAssemblyId2; }
			set { _updAssemblyId2 = value; }
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
			get { return _logicalDeleteCode; }
			set { _logicalDeleteCode = value; }
		}

		/// public propaty name  :  RcvDraftNo
		/// <summary>受取手形番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受取手形番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RcvDraftNo
		{
			get { return _rcvDraftNo; }
			set { _rcvDraftNo = value; }
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
			get { return _draftDivide; }
			set { _draftDivide = value; }
		}

		/// public propaty name  :  Deposit
		/// <summary>入金金額プロパティ</summary>
		/// <value>値引・手数料を除いた額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 Deposit
		{
			get { return _deposit; }
			set { _deposit = value; }
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

		/// public propaty name  :  SectionCode
		/// <summary>拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SectionCode
		{
			get { return _sectionCode; }
			set { _sectionCode = value; }
		}

		/// public propaty name  :  AddUpSecCode
		/// <summary>計上拠点コードプロパティ</summary>
		/// <value>※子でも手形ﾃﾞｰﾀが作成可なので必要</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpSecCode
		{
			get { return _addUpSecCode; }
			set { _addUpSecCode = value; }
		}

		/// public propaty name  :  CustomerCode
		/// <summary>得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get { return _customerCode; }
			set { _customerCode = value; }
		}

		/// public propaty name  :  CustomerName
		/// <summary>得意先名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CustomerName
		{
			get { return _customerName; }
			set { _customerName = value; }
		}

		/// public propaty name  :  CustomerName2
		/// <summary>得意先名称2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先名称2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CustomerName2
		{
			get { return _customerName2; }
			set { _customerName2 = value; }
		}

		/// public propaty name  :  CustomerSnm
		/// <summary>得意先略称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先略称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CustomerSnm
		{
			get { return _customerSnm; }
			set { _customerSnm = value; }
		}

		/// public propaty name  :  ProcDate
		/// <summary>処理日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   処理日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ProcDate
		{
			get { return _procDate; }
			set { _procDate = value; }
		}

		/// public propaty name  :  DraftDrawingDate
		/// <summary>手形振出日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   手形振出日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DraftDrawingDate
		{
			get { return _draftDrawingDate; }
			set { _draftDrawingDate = value; }
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
			get { return _validityTerm; }
			set { _validityTerm = value; }
		}

		/// public propaty name  :  DraftStmntDate
		/// <summary>手形決済日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   手形決済日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DraftStmntDate
		{
			get { return _draftStmntDate; }
			set { _draftStmntDate = value; }
		}

		/// public propaty name  :  Outline1
		/// <summary>伝票摘要1プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票摘要1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Outline1
		{
			get { return _outline1; }
			set { _outline1 = value; }
		}

		/// public propaty name  :  Outline2
		/// <summary>伝票摘要2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票摘要2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Outline2
		{
			get { return _outline2; }
			set { _outline2 = value; }
		}

		/// public propaty name  :  AcptAnOdrStatus
		/// <summary>受注ステータスプロパティ</summary>
		/// <value>10:見積,20:受注,30:売上,40:出荷</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注ステータスプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcptAnOdrStatus
		{
			get { return _acptAnOdrStatus; }
			set { _acptAnOdrStatus = value; }
		}

		/// public propaty name  :  DepositSlipNo
		/// <summary>入金伝票番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DepositSlipNo
		{
			get { return _depositSlipNo; }
			set { _depositSlipNo = value; }
		}

		/// public propaty name  :  DepositRowNo
		/// <summary>入金行番号プロパティ</summary>
		/// <value>※入金設定金種コードの設定番号をセット</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金行番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DepositRowNo
		{
			get { return _depositRowNo; }
			set { _depositRowNo = value; }
		}

		/// public propaty name  :  DepositDate
		/// <summary>入金日付プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DepositDate
		{
			get { return _depositDate; }
			set { _depositDate = value; }
		}


		/// <summary>
		/// 受取手形データワークコンストラクタ
		/// </summary>
		/// <returns>APRcvDraftDataWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   APRcvDraftDataWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public APRcvDraftDataWork()
		{
		}

	}
	/// <summary>
	///  Ver5.10.1.0用のカスタムシライアライザです。
	/// </summary>
	/// <returns>APRcvDraftDataWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   APRcvDraftDataWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public class APRcvDraftDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate メンバ

		/// <summary>
		///  Ver5.10.1.0用のカスタムシリアライザです
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   APRcvDraftDataWorkクラスのカスタムシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  APRcvDraftDataWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is APRcvDraftDataWork || graph is ArrayList || graph is APRcvDraftDataWork[]))
				throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(APRcvDraftDataWork).FullName));

			if (graph != null && graph is APRcvDraftDataWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.APRcvDraftDataWork");

			//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
			int occurrence = 0;     //一般にゼロの場合もありえます
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is APRcvDraftDataWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((APRcvDraftDataWork[])graph).Length;
			}
			else if (graph is APRcvDraftDataWork)
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
			//受取手形番号
			serInfo.MemberInfo.Add(typeof(string)); //RcvDraftNo
			//手形種別
			serInfo.MemberInfo.Add(typeof(Int32)); //DraftKindCd
			//手形区分
			serInfo.MemberInfo.Add(typeof(Int32)); //DraftDivide
			//入金金額
			serInfo.MemberInfo.Add(typeof(Int64)); //Deposit
			//銀行・支店コード
			serInfo.MemberInfo.Add(typeof(Int32)); //BankAndBranchCd
			//銀行・支店名称
			serInfo.MemberInfo.Add(typeof(string)); //BankAndBranchNm
			//拠点コード
			serInfo.MemberInfo.Add(typeof(string)); //SectionCode
			//計上拠点コード
			serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
			//得意先コード
			serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
			//得意先名称
			serInfo.MemberInfo.Add(typeof(string)); //CustomerName
			//得意先名称2
			serInfo.MemberInfo.Add(typeof(string)); //CustomerName2
			//得意先略称
			serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
			//処理日
			serInfo.MemberInfo.Add(typeof(Int32)); //ProcDate
			//手形振出日
			serInfo.MemberInfo.Add(typeof(Int32)); //DraftDrawingDate
			//有効期限
			serInfo.MemberInfo.Add(typeof(Int32)); //ValidityTerm
			//手形決済日
			serInfo.MemberInfo.Add(typeof(Int32)); //DraftStmntDate
			//伝票摘要1
			serInfo.MemberInfo.Add(typeof(string)); //Outline1
			//伝票摘要2
			serInfo.MemberInfo.Add(typeof(string)); //Outline2
			//受注ステータス
			serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
			//入金伝票番号
			serInfo.MemberInfo.Add(typeof(Int32)); //DepositSlipNo
			//入金行番号
			serInfo.MemberInfo.Add(typeof(Int32)); //DepositRowNo
			//入金日付
			serInfo.MemberInfo.Add(typeof(Int32)); //DepositDate


			serInfo.Serialize(writer, serInfo);
			if (graph is APRcvDraftDataWork)
			{
				APRcvDraftDataWork temp = (APRcvDraftDataWork)graph;

				SetAPRcvDraftDataWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is APRcvDraftDataWork[])
				{
					lst = new ArrayList();
					lst.AddRange((APRcvDraftDataWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (APRcvDraftDataWork temp in lst)
				{
					SetAPRcvDraftDataWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// APRcvDraftDataWorkメンバ数(publicプロパティ数)
		/// </summary>
		private const int currentMemberCount = 30;

		/// <summary>
		///  APRcvDraftDataWorkインスタンス書き込み
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   APRcvDraftDataWorkのインスタンスを書き込み</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private void SetAPRcvDraftDataWork(System.IO.BinaryWriter writer, APRcvDraftDataWork temp)
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
			//受取手形番号
			writer.Write(temp.RcvDraftNo);
			//手形種別
			writer.Write(temp.DraftKindCd);
			//手形区分
			writer.Write(temp.DraftDivide);
			//入金金額
			writer.Write(temp.Deposit);
			//銀行・支店コード
			writer.Write(temp.BankAndBranchCd);
			//銀行・支店名称
			writer.Write(temp.BankAndBranchNm);
			//拠点コード
			writer.Write(temp.SectionCode);
			//計上拠点コード
			writer.Write(temp.AddUpSecCode);
			//得意先コード
			writer.Write(temp.CustomerCode);
			//得意先名称
			writer.Write(temp.CustomerName);
			//得意先名称2
			writer.Write(temp.CustomerName2);
			//得意先略称
			writer.Write(temp.CustomerSnm);
			//処理日
			writer.Write(temp.ProcDate);
			//手形振出日
			writer.Write(temp.DraftDrawingDate);
			//有効期限
			writer.Write(temp.ValidityTerm);
			//手形決済日
			writer.Write(temp.DraftStmntDate);
			//伝票摘要1
			writer.Write(temp.Outline1);
			//伝票摘要2
			writer.Write(temp.Outline2);
			//受注ステータス
			writer.Write(temp.AcptAnOdrStatus);
			//入金伝票番号
			writer.Write(temp.DepositSlipNo);
			//入金行番号
			writer.Write(temp.DepositRowNo);
			//入金日付
			writer.Write(temp.DepositDate);

		}

		/// <summary>
		///  APRcvDraftDataWorkインスタンス取得
		/// </summary>
		/// <returns>APRcvDraftDataWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   APRcvDraftDataWorkのインスタンスを取得します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private APRcvDraftDataWork GetAPRcvDraftDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0なので不要ですが、V5.1.0.1以降では
			// serInfo.MemberInfo.Count < currentMemberCount
			// のケースについての配慮が必要になります。

			APRcvDraftDataWork temp = new APRcvDraftDataWork();

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
			//受取手形番号
			temp.RcvDraftNo = reader.ReadString();
			//手形種別
			temp.DraftKindCd = reader.ReadInt32();
			//手形区分
			temp.DraftDivide = reader.ReadInt32();
			//入金金額
			temp.Deposit = reader.ReadInt64();
			//銀行・支店コード
			temp.BankAndBranchCd = reader.ReadInt32();
			//銀行・支店名称
			temp.BankAndBranchNm = reader.ReadString();
			//拠点コード
			temp.SectionCode = reader.ReadString();
			//計上拠点コード
			temp.AddUpSecCode = reader.ReadString();
			//得意先コード
			temp.CustomerCode = reader.ReadInt32();
			//得意先名称
			temp.CustomerName = reader.ReadString();
			//得意先名称2
			temp.CustomerName2 = reader.ReadString();
			//得意先略称
			temp.CustomerSnm = reader.ReadString();
			//処理日
			temp.ProcDate = reader.ReadInt32();
			//手形振出日
			temp.DraftDrawingDate = reader.ReadInt32();
			//有効期限
			temp.ValidityTerm = reader.ReadInt32();
			//手形決済日
			temp.DraftStmntDate = reader.ReadInt32();
			//伝票摘要1
			temp.Outline1 = reader.ReadString();
			//伝票摘要2
			temp.Outline2 = reader.ReadString();
			//受注ステータス
			temp.AcptAnOdrStatus = reader.ReadInt32();
			//入金伝票番号
			temp.DepositSlipNo = reader.ReadInt32();
			//入金行番号
			temp.DepositRowNo = reader.ReadInt32();
			//入金日付
			temp.DepositDate = reader.ReadInt32();


			//以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
			//データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
			//型情報にしたがって、ストリームから情報を読み出します...といっても
			//読み出して捨てることになります。
			for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
			{
				//byte[],char[]をデシリアライズする直前に、そのlengthが
				//デシリアライズされているケースがある、byte[],char[]の
				//デシリアライズにはlengthが必要なのでint型のデータをデ
				//シリアライズした場合は、この値をこの変数に退避します。
				int optCount = 0;
				object oMemberType = serInfo.MemberInfo[k];
				if (oMemberType is Type)
				{
					Type t = (Type)oMemberType;
					object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
					if (t.Equals(typeof(int)))
					{
						optCount = Convert.ToInt32(oData);
					}
					else
					{
						optCount = 0;
					}
				}
				else if (oMemberType is string)
				{
					Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
					object userData = formatter.Deserialize(reader);  //読み飛ばし
				}
			}
			return temp;
		}

		/// <summary>
		///  Ver5.10.1.0用のカスタムデシリアライザです
		/// </summary>
		/// <returns>APRcvDraftDataWorkクラスのインスタンス(object)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   APRcvDraftDataWorkクラスのカスタムデシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				APRcvDraftDataWork temp = GetAPRcvDraftDataWork(reader, serInfo);
				lst.Add(temp);
			}
			switch (serInfo.RetTypeInfo)
			{
				case 0:
					retValue = lst;
					break;
				case 1:
					retValue = lst[0];
					break;
				case 2:
					retValue = (APRcvDraftDataWork[])lst.ToArray(typeof(APRcvDraftDataWork));
					break;
			}
			return retValue;
		}

		#endregion
	}


}


