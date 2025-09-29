//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   抽出・更新DB仲介クラス
//                  :   PMKYO07003D.DLL
// Name Space       :   Broadleaf.Application.Remoting.ParamData
// Programmer       :   張莉莉
// Date             :   2011.07.28
//----------------------------------------------------------------------
// Update Note      :　 Redmine#26228　拠点管理改良／伝票日付による抽出対応
// Programmer       :   許培珠
// Date             :   2011/11/01
//----------------------------------------------------------------------
// Update Note      :　 Redmine#8293　拠点管理改良／伝票日付による抽出対応
// Programmer       :   譚洪
// Date             :   2011/11/30
//----------------------------------------------------------------------
// Update Note      :　 管理番号:10900690-00 2013/3/13配信分の緊急対応
//                      Redmine#34588 拠点管理改良／送信確認画面の追加仕様の変更対応
// Programmer       :   zhlj
// Date             :   2013/02/07
//----------------------------------------------------------------------
// 管理番号  11600006-00 作成担当 : 譚洪
// 修 正 日  2020/09/25  修正内容 : PMKOBETSU-3877の対応
//----------------------------------------------------------------------
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;


namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   APSendDataWork
	/// <summary>
	///                      送信データワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   送信データワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2011/07/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      : 2020/09/25 譚洪</br>
    /// <br>管理番号         : 11600006-00</br>
    /// <br>                 : PMKOBETSU-3877の対応</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class APSendDataWork 
	{
		/// <summary>PM企業コード</summary>
		/// <remarks>部品商の企業コード</remarks>
		private string _pmEnterpriseCode = "";

		/// <summary>開始日付時間</summary>
		private Int64 _startDateTime;

		/// <summary>終了日付時間</summary>
		private Int64 _endDateTime;

        /// <summary>シンク実行日付時間</summary>
        private Int64 _syncExecDate;

        /// <summary>終了日付時間</summary>
        private Int64 _endDateTimeTicks;

		/// <summary>拠点コード</summary>
		private string _pmSectionCode = "";

		/// <summary>売上要否フラグ</summary>
		private Boolean _doSalesSlipFlg;

		/// <summary>売上明細要否フラグ</summary>
		private Boolean _doSalesDetailFlg;

		/// <summary>受注マスタ（車両）要否フラグ</summary>
		private Boolean _doAcceptOdrCarFlg;

		/// <summary>受注マスタ要否フラグ</summary>
		private Boolean _doAcceptOdrFlg;

		/// <summary>売上履歴要否フラグ</summary>
		private Boolean _doSalesHistoryFlg;

		/// <summary>売上履歴明細要否フラグ</summary>
		private Boolean _doSalesHistDtlFlg;

		/// <summary>入金要否フラグ</summary>
		private Boolean _doDepsitMainFlg;

		/// <summary>入金明細要否フラグ</summary>
		private Boolean _doDepsitDtlFlg;

		/// <summary>仕入要否フラグ</summary>
		private Boolean _doStockSlipFlg;

		/// <summary>仕入明細要否フラグ</summary>
		private Boolean _doStockDetailFlg;

		/// <summary>仕入履歴要否フラグ</summary>
		private Boolean _doStockSlipHistFlg;

		/// <summary>仕入履歴明細要否フラグ</summary>
		private Boolean _doStockSlHistDtlFlg;

		/// <summary>支払伝票要否フラグ</summary>
		private Boolean _doPaymentSlpFlg;

		/// <summary>支払明細要否フラグ</summary>
		private Boolean _doPaymentDtlFlg;

        // ----- ADD 2011/11/01 xupz---------->>>>>
        /// <summary>データ送信抽出条件区分(0:差分;1:伝票日付)</summary>
        private Int32 _sndMesExtraCondDiv;
        // ----- ADD 2011/11/01 xupz----------<<<<<

        // ----- ADD 2013/02/07 zhlj For Redmine#34588 ---------->>>>>
        /// <summary>送信番号生成区分(0:生成する;1:生成しない)</summary>
        private Int32 _sndNoCreateDiv;
        // ----- ADD 2013/02/07 zhlj For Redmine#34588 ----------<<<<<

        // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
        /// <summary>受注データ送信区分</summary>
        /// <remarks>0:送信なし 1:送信あり</remarks>
        private Int32 _acptAnOdrSendDiv;

        /// <summary>貸出データ送信区分</summary>
        /// <remarks>0:送信なし 1:送信あり</remarks>
        private Int32 _shipmentSendDiv;

        /// <summary>見積データ送信区分</summary>
        /// <remarks>0:送信なし 1:送信あり</remarks>
        private Int32 _estimateSendDiv;
        // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------<<<<<

		/// public propaty name  :  PmEnterpriseCode
		/// <summary>PM企業コードプロパティ</summary>
		/// <value>部品商の企業コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PmEnterpriseCode
		{
			get { return _pmEnterpriseCode; }
			set { _pmEnterpriseCode = value; }
		}

		/// public propaty name  :  StartDateTime
		/// <summary>開始日付時間プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始日付時間プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StartDateTime
		{
			get { return _startDateTime; }
			set { _startDateTime = value; }
		}

		/// public propaty name  :  EndDateTime
		/// <summary>終了日付時間プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了日付時間プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 EndDateTime
		{
			get { return _endDateTime; }
			set { _endDateTime = value; }
		}

        /// public propaty name  :  SyncExecDate
        /// <summary>シンク実行日付時間プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   シンク実行日付時間プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SyncExecDate
        {
            get { return _syncExecDate; }
            set { _syncExecDate = value; }
        }

        /// public propaty name  :  EndDateTime
        /// <summary>終了日付時間プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了日付時間プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 EndDateTimeTicks
        {
            get { return _endDateTimeTicks; }
            set { _endDateTimeTicks = value; }
        }

		/// public propaty name  :  PmSectionCode
		/// <summary>拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PmSectionCode
		{
			get { return _pmSectionCode; }
			set { _pmSectionCode = value; }
		}

		/// public propaty name  :  DoSalesSlipFlg
		/// <summary>売上要否フラグプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上要否フラグプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Boolean DoSalesSlipFlg
		{
			get { return _doSalesSlipFlg; }
			set { _doSalesSlipFlg = value; }
		}

		/// public propaty name  :  DoSalesDetailFlg
		/// <summary>売上明細要否フラグプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上明細要否フラグプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Boolean DoSalesDetailFlg
		{
			get { return _doSalesDetailFlg; }
			set { _doSalesDetailFlg = value; }
		}

		/// public propaty name  :  DoAcceptOdrCarFlg
		/// <summary>受注マスタ（車両）要否フラグプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注マスタ（車両）要否フラグプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Boolean DoAcceptOdrCarFlg
		{
			get { return _doAcceptOdrCarFlg; }
			set { _doAcceptOdrCarFlg = value; }
		}

		/// public propaty name  :  DoAcceptOdrFlg
		/// <summary>受注マスタ要否フラグプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注マスタ要否フラグプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Boolean DoAcceptOdrFlg
		{
			get { return _doAcceptOdrFlg; }
			set { _doAcceptOdrFlg = value; }
		}

		/// public propaty name  :  DoSalesHistoryFlg
		/// <summary>売上履歴要否フラグプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上履歴要否フラグプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Boolean DoSalesHistoryFlg
		{
			get { return _doSalesHistoryFlg; }
			set { _doSalesHistoryFlg = value; }
		}

		/// public propaty name  :  DoSalesHistDtlFlg
		/// <summary>売上履歴明細要否フラグプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上履歴明細要否フラグプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Boolean DoSalesHistDtlFlg
		{
			get { return _doSalesHistDtlFlg; }
			set { _doSalesHistDtlFlg = value; }
		}

		/// public propaty name  :  DoDepsitMainFlg
		/// <summary>入金要否フラグプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金要否フラグプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Boolean DoDepsitMainFlg
		{
			get { return _doDepsitMainFlg; }
			set { _doDepsitMainFlg = value; }
		}

		/// public propaty name  :  DoDepsitDtlFlg
		/// <summary>入金明細要否フラグプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金明細要否フラグプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Boolean DoDepsitDtlFlg
		{
			get { return _doDepsitDtlFlg; }
			set { _doDepsitDtlFlg = value; }
		}

		/// public propaty name  :  DoStockSlipFlg
		/// <summary>仕入要否フラグプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入要否フラグプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Boolean DoStockSlipFlg
		{
			get { return _doStockSlipFlg; }
			set { _doStockSlipFlg = value; }
		}

		/// public propaty name  :  DoStockDetailFlg
		/// <summary>仕入明細要否フラグプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入明細要否フラグプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Boolean DoStockDetailFlg
		{
			get { return _doStockDetailFlg; }
			set { _doStockDetailFlg = value; }
		}

		/// public propaty name  :  DoStockSlipHistFlg
		/// <summary>仕入履歴要否フラグプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入履歴要否フラグプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Boolean DoStockSlipHistFlg
		{
			get { return _doStockSlipHistFlg; }
			set { _doStockSlipHistFlg = value; }
		}

		/// public propaty name  :  DoStockSlHistDtlFlg
		/// <summary>仕入履歴明細要否フラグプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入履歴明細要否フラグプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Boolean DoStockSlHistDtlFlg
		{
			get { return _doStockSlHistDtlFlg; }
			set { _doStockSlHistDtlFlg = value; }
		}

		/// public propaty name  :  DoPaymentSlpFlg
		/// <summary>支払伝票要否フラグプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払伝票要否フラグプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Boolean DoPaymentSlpFlg
		{
			get { return _doPaymentSlpFlg; }
			set { _doPaymentSlpFlg = value; }
		}

		/// public propaty name  :  DoPaymentDtlFlg
		/// <summary>支払明細要否フラグプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払明細要否フラグプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Boolean DoPaymentDtlFlg
		{
			get { return _doPaymentDtlFlg; }
			set { _doPaymentDtlFlg = value; }
		}

        // ----- ADD 2011/11/01 xupz---------->>>>>
        /// public propaty name  :  SndMesExtraCondDiv;
        /// <summary>データ送信抽出条件区分</summary>
        /// <value>0:差分;　1:伝票日付</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ送信抽出条件区分</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SndMesExtraCondDiv
        {
            get { return _sndMesExtraCondDiv; }
            set { _sndMesExtraCondDiv = value; }
        }
        // ----- ADD 2011/11/01 xupz----------<<<<<

        // ----- ADD 2013/02/07 zhlj For Redmine#34588 ---------->>>>>
        /// public propaty name  :  SndNoCreateDiv
        /// <summary>送信番号生成区分</summary>
        /// <value>0:生成する;1:生成しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ送信抽出条件区分</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SndNoCreateDiv
        {
            get { return _sndNoCreateDiv; }
            set { _sndNoCreateDiv = value; }
        }
        // ----- ADD 2013/02/07 zhlj For Redmine#34588 ----------<<<<<

        // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
        /// public propaty name  :  AcptAnOdrSendDiv
        /// <summary>受注データ送信区分プロパティ</summary>
        /// <value>0:送信なし 1:送信あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注データ送信区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptAnOdrSendDiv
        {
            get { return _acptAnOdrSendDiv; }
            set { _acptAnOdrSendDiv = value; }
        }

        /// public propaty name  :  ShipmentSendDiv
        /// <summary>貸出データ送信区分プロパティ</summary>
        /// <value>0:送信なし 1:送信あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   貸出データ送信区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ShipmentSendDiv
        {
            get { return _shipmentSendDiv; }
            set { _shipmentSendDiv = value; }
        }

        /// public propaty name  :  EstimateSendDiv
        /// <summary>見積データ送信区分プロパティ</summary>
        /// <value>0:送信なし 1:送信あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積データ送信区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EstimateSendDiv
        {
            get { return _estimateSendDiv; }
            set { _estimateSendDiv = value; }
        }
        // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------<<<<<

		/// <summary>
		/// 送信データワークコンストラクタ
		/// </summary>
		/// <returns>APSendDataWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   APSendDataWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public APSendDataWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0用のカスタムシライアライザです。
	/// </summary>
	/// <returns>APSendDataWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   APSendDataWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public class APSendDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate メンバ

		/// <summary>
		///  Ver5.10.1.0用のカスタムシリアライザです
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   APSendDataWorkクラスのカスタムシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  APSendDataWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is APSendDataWork || graph is ArrayList || graph is APSendDataWork[]))
				throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(APSendDataWork).FullName));

			if (graph != null && graph is APSendDataWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.APSendDataWork");

			//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
			int occurrence = 0;     //一般にゼロの場合もありえます
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is APSendDataWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((APSendDataWork[])graph).Length;
			}
			else if (graph is APSendDataWork)
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //繰り返し数	

			//PM企業コード
			serInfo.MemberInfo.Add(typeof(string)); //PmEnterpriseCode
			//開始日付時間
			serInfo.MemberInfo.Add(typeof(Int64)); //StartDateTime
			//終了日付時間
			serInfo.MemberInfo.Add(typeof(Int64)); //EndDateTime
            //シンク実行日付時間
            serInfo.MemberInfo.Add(typeof(Int64)); //SyncExecDate
            //終了日付時間
            serInfo.MemberInfo.Add(typeof(Int64)); //EndDateTimeTicks
			//拠点コード
			serInfo.MemberInfo.Add(typeof(string)); //PmSectionCode
			//売上要否フラグ
			serInfo.MemberInfo.Add(typeof(Boolean)); //DoSalesSlipFlg
			//売上明細要否フラグ
			serInfo.MemberInfo.Add(typeof(Boolean)); //DoSalesDetailFlg
			//受注マスタ（車両）要否フラグ
			serInfo.MemberInfo.Add(typeof(Boolean)); //DoAcceptOdrCarFlg
			//受注マスタ要否フラグ
			serInfo.MemberInfo.Add(typeof(Boolean)); //DoAcceptOdrFlg
			//売上履歴要否フラグ
			serInfo.MemberInfo.Add(typeof(Boolean)); //DoSalesHistoryFlg
			//売上履歴明細要否フラグ
			serInfo.MemberInfo.Add(typeof(Boolean)); //DoSalesHistDtlFlg
			//入金要否フラグ
			serInfo.MemberInfo.Add(typeof(Boolean)); //DoDepsitMainFlg
			//入金明細要否フラグ
			serInfo.MemberInfo.Add(typeof(Boolean)); //DoDepsitDtlFlg
			//仕入要否フラグ
			serInfo.MemberInfo.Add(typeof(Boolean)); //DoStockSlipFlg
			//仕入明細要否フラグ
			serInfo.MemberInfo.Add(typeof(Boolean)); //DoStockDetailFlg
			//仕入履歴要否フラグ
			serInfo.MemberInfo.Add(typeof(Boolean)); //DoStockSlipHistFlg
			//仕入履歴明細要否フラグ
			serInfo.MemberInfo.Add(typeof(Boolean)); //DoStockSlHistDtlFlg
			//支払伝票要否フラグ
			serInfo.MemberInfo.Add(typeof(Boolean)); //DoPaymentSlpFlg
			//支払明細要否フラグ
			serInfo.MemberInfo.Add(typeof(Boolean)); //DoPaymentDtlFlg
            // ----- ADD 2011/11/01 xupz---------->>>>>
            //データ送信抽出条件区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SndMesExtraCondDiv
            // ----- ADD 2011/11/01 xupz----------<<<<<
            // ----- ADD 2013/02/07 zhlj For Redmine#34588 ---------->>>>>
            //送信番号生成区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SndNoCreateDiv
            // ----- ADD 2013/02/07 zhlj For Redmine#34588 ----------<<<<<

            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
            //受注データ送信区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrSendDiv
            //貸出データ送信区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmentSendDiv
            //見積データ送信区分
            serInfo.MemberInfo.Add(typeof(Int32)); //EstimateSendDiv
            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------<<<<<

			serInfo.Serialize(writer, serInfo);
			if (graph is APSendDataWork)
			{
				APSendDataWork temp = (APSendDataWork)graph;

				SetAPSendDataWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is APSendDataWork[])
				{
					lst = new ArrayList();
					lst.AddRange((APSendDataWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (APSendDataWork temp in lst)
				{
					SetAPSendDataWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// APSendDataWorkメンバ数(publicプロパティ数)
		/// </summary>
		//private const int currentMemberCount = 18;
        //private const int currentMemberCount = 19;
        //private const int currentMemberCount = 20;// DEL zhlj 2013/02/07 For Redmine#34588
        // --- UPD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
        //private const int currentMemberCount = 21;// ADD zhlj 2013/02/07 For Redmine#34588
        private const int currentMemberCount = 24;
        // --- UPD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------<<<<<

		/// <summary>
		///  APSendDataWorkインスタンス書き込み
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   APSendDataWorkのインスタンスを書き込み</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private void SetAPSendDataWork(System.IO.BinaryWriter writer, APSendDataWork temp)
		{
			//PM企業コード
			writer.Write(temp.PmEnterpriseCode);
			//開始日付時間
			writer.Write(temp.StartDateTime);
			//終了日付時間
			writer.Write(temp.EndDateTime);
            //終了日付時間
            writer.Write(temp.EndDateTimeTicks);
            //シンク実行日付時間
            writer.Write(temp.SyncExecDate);
			//拠点コード
			writer.Write(temp.PmSectionCode);
			//売上要否フラグ
			writer.Write(temp.DoSalesSlipFlg);
			//売上明細要否フラグ
			writer.Write(temp.DoSalesDetailFlg);
			//受注マスタ（車両）要否フラグ
			writer.Write(temp.DoAcceptOdrCarFlg);
			//受注マスタ要否フラグ
			writer.Write(temp.DoAcceptOdrFlg);
			//売上履歴要否フラグ
			writer.Write(temp.DoSalesHistoryFlg);
			//売上履歴明細要否フラグ
			writer.Write(temp.DoSalesHistDtlFlg);
			//入金要否フラグ
			writer.Write(temp.DoDepsitMainFlg);
			//入金明細要否フラグ
			writer.Write(temp.DoDepsitDtlFlg);
			//仕入要否フラグ
			writer.Write(temp.DoStockSlipFlg);
			//仕入明細要否フラグ
			writer.Write(temp.DoStockDetailFlg);
			//仕入履歴要否フラグ
			writer.Write(temp.DoStockSlipHistFlg);
			//仕入履歴明細要否フラグ
			writer.Write(temp.DoStockSlHistDtlFlg);
			//支払伝票要否フラグ
			writer.Write(temp.DoPaymentSlpFlg);
			//支払明細要否フラグ
			writer.Write(temp.DoPaymentDtlFlg);
            // ----- ADD 2011/11/01 xupz---------->>>>>
            //データ送信抽出条件区分
            writer.Write(temp.SndMesExtraCondDiv);
            // ----- ADD 2011/11/01 xupz----------<<<<<
            // ----- ADD 2013/02/07 zhlj For Redmine#34588 ---------->>>>>
            //送信番号生成区分
            writer.Write(temp.SndNoCreateDiv);
            // ----- ADD 2013/02/07 zhlj For Redmine#34588 ----------<<<<<
            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
            //受注データ送信区分
            writer.Write(temp.AcptAnOdrSendDiv);
            //貸出データ送信区分
            writer.Write(temp.ShipmentSendDiv);
            //見積データ送信区分
            writer.Write(temp.EstimateSendDiv);
            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------<<<<<

		}

		/// <summary>
		///  APSendDataWorkインスタンス取得
		/// </summary>
		/// <returns>APSendDataWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   APSendDataWorkのインスタンスを取得します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private APSendDataWork GetAPSendDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
	{
		// V5.1.0.0なので不要ですが、V5.1.0.1以降では
		// serInfo.MemberInfo.Count < currentMemberCount
		// のケースについての配慮が必要になります。

		APSendDataWork temp = new APSendDataWork();

		//PM企業コード
		temp.PmEnterpriseCode = reader.ReadString();
		//開始日付時間
		temp.StartDateTime = reader.ReadInt64();
		//終了日付時間
		temp.EndDateTime = reader.ReadInt64();
        //シンク実行日付時間
        temp.SyncExecDate = reader.ReadInt64();
        //終了日付時間
        temp.EndDateTimeTicks = reader.ReadInt64();
		//拠点コード
		temp.PmSectionCode = reader.ReadString();
		//売上要否フラグ
		temp.DoSalesSlipFlg = reader.ReadBoolean();
		//売上明細要否フラグ
		temp.DoSalesDetailFlg = reader.ReadBoolean();
		//受注マスタ（車両）要否フラグ
		temp.DoAcceptOdrCarFlg = reader.ReadBoolean();
		//受注マスタ要否フラグ
		temp.DoAcceptOdrFlg = reader.ReadBoolean();
		//売上履歴要否フラグ
		temp.DoSalesHistoryFlg = reader.ReadBoolean();
		//売上履歴明細要否フラグ
		temp.DoSalesHistDtlFlg = reader.ReadBoolean();
		//入金要否フラグ
		temp.DoDepsitMainFlg = reader.ReadBoolean();
		//入金明細要否フラグ
		temp.DoDepsitDtlFlg = reader.ReadBoolean();
		//仕入要否フラグ
		temp.DoStockSlipFlg = reader.ReadBoolean();
		//仕入明細要否フラグ
		temp.DoStockDetailFlg = reader.ReadBoolean();
		//仕入履歴要否フラグ
		temp.DoStockSlipHistFlg = reader.ReadBoolean();
		//仕入履歴明細要否フラグ
		temp.DoStockSlHistDtlFlg = reader.ReadBoolean();
		//支払伝票要否フラグ
		temp.DoPaymentSlpFlg = reader.ReadBoolean();
		//支払明細要否フラグ
		temp.DoPaymentDtlFlg = reader.ReadBoolean();
        // ----- ADD 2011/11/01 xupz---------->>>>>
        //データ送信抽出条件区分
        temp.SndMesExtraCondDiv = reader.ReadInt32();
        // ----- ADD 2011/11/01 xupz----------<<<<<
        // ----- ADD 2013/02/07 zhlj For Redmine#34588 ---------->>>>>
        //送信番号生成区分
        temp.SndNoCreateDiv = reader.ReadInt32();
        // ----- ADD 2013/02/07 zhlj For Redmine#34588 ----------<<<<<

        // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
        //受注データ送信区分
        temp.AcptAnOdrSendDiv = reader.ReadInt32();
        //貸出データ送信区分
        temp.ShipmentSendDiv = reader.ReadInt32();
        //見積データ送信区分
        temp.EstimateSendDiv = reader.ReadInt32();
        // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------<<<<<
			
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
		/// <returns>APSendDataWorkクラスのインスタンス(object)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   APSendDataWorkクラスのカスタムデシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				APSendDataWork temp = GetAPSendDataWork(reader, serInfo);
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
					retValue = (APSendDataWork[])lst.ToArray(typeof(APSendDataWork));
					break;
			}
			return retValue;
		}

		#endregion
	}


}

