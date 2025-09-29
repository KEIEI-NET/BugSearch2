//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : DC 入金引当マスタ抽出・更新処理　データパラメータ
// プログラム概要   : なし
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
	/// public class name:   DCDepositAlwWork
	/// <summary>
	///                      入金引当ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   入金引当ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2008/4/2</br>
	/// <br>Genarated Date   :   2011/07/28  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2008/7/2  長内</br>
	/// <br>                 :   ○項目削除</br>
	/// <br>                 :   　入金金種コード</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class DCDepositAlwWork : IFileHeader
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

		/// <summary>入金入力拠点コード</summary>
		/// <remarks>入金入力した拠点コード</remarks>
		private string _inputDepositSecCd = "";

		/// <summary>計上拠点コード</summary>
		/// <remarks>集計の対象となっている拠点コード</remarks>
		private string _addUpSecCode = "";

		/// <summary>受注ステータス</summary>
		/// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
		private Int32 _acptAnOdrStatus;

		/// <summary>売上伝票番号</summary>
		/// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
		private string _salesSlipNum = "";

		/// <summary>消込み日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _reconcileDate;

		/// <summary>消込み計上日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _reconcileAddUpDate;

		/// <summary>入金伝票番号</summary>
		private Int32 _depositSlipNo;

		/// <summary>入金引当額</summary>
		private Int64 _depositAllowance;

		/// <summary>入金担当者コード</summary>
		private string _depositAgentCode = "";

		/// <summary>入金担当者名称</summary>
		private string _depositAgentNm = "";

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;

		/// <summary>得意先名称</summary>
		private string _customerName = "";

		/// <summary>得意先名称2</summary>
		private string _customerName2 = "";

		/// <summary>赤伝相殺区分</summary>
		/// <remarks>0:黒,1:赤,2:相殺済み黒</remarks>
		private Int32 _debitNoteOffSetCd;


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

		/// public propaty name  :  InputDepositSecCd
		/// <summary>入金入力拠点コードプロパティ</summary>
		/// <value>入金入力した拠点コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金入力拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InputDepositSecCd
		{
			get { return _inputDepositSecCd; }
			set { _inputDepositSecCd = value; }
		}

		/// public propaty name  :  AddUpSecCode
		/// <summary>計上拠点コードプロパティ</summary>
		/// <value>集計の対象となっている拠点コード</value>
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

		/// public propaty name  :  SalesSlipNum
		/// <summary>売上伝票番号プロパティ</summary>
		/// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesSlipNum
		{
			get { return _salesSlipNum; }
			set { _salesSlipNum = value; }
		}

		/// public propaty name  :  ReconcileDate
		/// <summary>消込み日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   消込み日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ReconcileDate
		{
			get { return _reconcileDate; }
			set { _reconcileDate = value; }
		}

		/// public propaty name  :  ReconcileAddUpDate
		/// <summary>消込み計上日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   消込み計上日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ReconcileAddUpDate
		{
			get { return _reconcileAddUpDate; }
			set { _reconcileAddUpDate = value; }
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

		/// public propaty name  :  DepositAllowance
		/// <summary>入金引当額プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金引当額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 DepositAllowance
		{
			get { return _depositAllowance; }
			set { _depositAllowance = value; }
		}

		/// public propaty name  :  DepositAgentCode
		/// <summary>入金担当者コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金担当者コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DepositAgentCode
		{
			get { return _depositAgentCode; }
			set { _depositAgentCode = value; }
		}

		/// public propaty name  :  DepositAgentNm
		/// <summary>入金担当者名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金担当者名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DepositAgentNm
		{
			get { return _depositAgentNm; }
			set { _depositAgentNm = value; }
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

		/// public propaty name  :  DebitNoteOffSetCd
		/// <summary>赤伝相殺区分プロパティ</summary>
		/// <value>0:黒,1:赤,2:相殺済み黒</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   赤伝相殺区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DebitNoteOffSetCd
		{
			get { return _debitNoteOffSetCd; }
			set { _debitNoteOffSetCd = value; }
		}


		/// <summary>
		/// 入金引当ワークコンストラクタ
		/// </summary>
		/// <returns>DCDepositAlwWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   DCDepositAlwWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DCDepositAlwWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0用のカスタムシライアライザです。
	/// </summary>
	/// <returns>DCDepositAlwWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   DCDepositAlwWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public class DCDepositAlwWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate メンバ

		/// <summary>
		///  Ver5.10.1.0用のカスタムシリアライザです
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   DCDepositAlwWorkクラスのカスタムシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  DCDepositAlwWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is DCDepositAlwWork || graph is ArrayList || graph is DCDepositAlwWork[]))
				throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(DCDepositAlwWork).FullName));

			if (graph != null && graph is DCDepositAlwWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.DCDepositAlwWork");

			//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
			int occurrence = 0;     //一般にゼロの場合もありえます
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is DCDepositAlwWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((DCDepositAlwWork[])graph).Length;
			}
			else if (graph is DCDepositAlwWork)
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
			//入金入力拠点コード
			serInfo.MemberInfo.Add(typeof(string)); //InputDepositSecCd
			//計上拠点コード
			serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
			//受注ステータス
			serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
			//売上伝票番号
			serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
			//消込み日
			serInfo.MemberInfo.Add(typeof(Int32)); //ReconcileDate
			//消込み計上日
			serInfo.MemberInfo.Add(typeof(Int32)); //ReconcileAddUpDate
			//入金伝票番号
			serInfo.MemberInfo.Add(typeof(Int32)); //DepositSlipNo
			//入金引当額
			serInfo.MemberInfo.Add(typeof(Int64)); //DepositAllowance
			//入金担当者コード
			serInfo.MemberInfo.Add(typeof(string)); //DepositAgentCode
			//入金担当者名称
			serInfo.MemberInfo.Add(typeof(string)); //DepositAgentNm
			//得意先コード
			serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
			//得意先名称
			serInfo.MemberInfo.Add(typeof(string)); //CustomerName
			//得意先名称2
			serInfo.MemberInfo.Add(typeof(string)); //CustomerName2
			//赤伝相殺区分
			serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteOffSetCd


			serInfo.Serialize(writer, serInfo);
			if (graph is DCDepositAlwWork)
			{
				DCDepositAlwWork temp = (DCDepositAlwWork)graph;

				SetDCDepositAlwWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is DCDepositAlwWork[])
				{
					lst = new ArrayList();
					lst.AddRange((DCDepositAlwWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (DCDepositAlwWork temp in lst)
				{
					SetDCDepositAlwWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// DCDepositAlwWorkメンバ数(publicプロパティ数)
		/// </summary>
		private const int currentMemberCount = 22;

		/// <summary>
		///  DCDepositAlwWorkインスタンス書き込み
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   DCDepositAlwWorkのインスタンスを書き込み</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private void SetDCDepositAlwWork(System.IO.BinaryWriter writer, DCDepositAlwWork temp)
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
			//入金入力拠点コード
			writer.Write(temp.InputDepositSecCd);
			//計上拠点コード
			writer.Write(temp.AddUpSecCode);
			//受注ステータス
			writer.Write(temp.AcptAnOdrStatus);
			//売上伝票番号
			writer.Write(temp.SalesSlipNum);
			//消込み日
			writer.Write(temp.ReconcileDate);
			//消込み計上日
			writer.Write(temp.ReconcileAddUpDate);
			//入金伝票番号
			writer.Write(temp.DepositSlipNo);
			//入金引当額
			writer.Write(temp.DepositAllowance);
			//入金担当者コード
			writer.Write(temp.DepositAgentCode);
			//入金担当者名称
			writer.Write(temp.DepositAgentNm);
			//得意先コード
			writer.Write(temp.CustomerCode);
			//得意先名称
			writer.Write(temp.CustomerName);
			//得意先名称2
			writer.Write(temp.CustomerName2);
			//赤伝相殺区分
			writer.Write(temp.DebitNoteOffSetCd);

		}

		/// <summary>
		///  DCDepositAlwWorkインスタンス取得
		/// </summary>
		/// <returns>DCDepositAlwWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   DCDepositAlwWorkのインスタンスを取得します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private DCDepositAlwWork GetDCDepositAlwWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0なので不要ですが、V5.1.0.1以降では
			// serInfo.MemberInfo.Count < currentMemberCount
			// のケースについての配慮が必要になります。

			DCDepositAlwWork temp = new DCDepositAlwWork();

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
			//入金入力拠点コード
			temp.InputDepositSecCd = reader.ReadString();
			//計上拠点コード
			temp.AddUpSecCode = reader.ReadString();
			//受注ステータス
			temp.AcptAnOdrStatus = reader.ReadInt32();
			//売上伝票番号
			temp.SalesSlipNum = reader.ReadString();
			//消込み日
			temp.ReconcileDate = reader.ReadInt32();
			//消込み計上日
			temp.ReconcileAddUpDate = reader.ReadInt32();
			//入金伝票番号
			temp.DepositSlipNo = reader.ReadInt32();
			//入金引当額
			temp.DepositAllowance = reader.ReadInt64();
			//入金担当者コード
			temp.DepositAgentCode = reader.ReadString();
			//入金担当者名称
			temp.DepositAgentNm = reader.ReadString();
			//得意先コード
			temp.CustomerCode = reader.ReadInt32();
			//得意先名称
			temp.CustomerName = reader.ReadString();
			//得意先名称2
			temp.CustomerName2 = reader.ReadString();
			//赤伝相殺区分
			temp.DebitNoteOffSetCd = reader.ReadInt32();


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
		/// <returns>DCDepositAlwWorkクラスのインスタンス(object)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   DCDepositAlwWorkクラスのカスタムデシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				DCDepositAlwWork temp = GetDCDepositAlwWork(reader, serInfo);
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
					retValue = (DCDepositAlwWork[])lst.ToArray(typeof(DCDepositAlwWork));
					break;
			}
			return retValue;
		}

		#endregion
	}


}


