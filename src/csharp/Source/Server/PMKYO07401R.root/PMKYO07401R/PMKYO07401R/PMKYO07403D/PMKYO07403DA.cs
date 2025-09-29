//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/07/21  修正内容 : SCM対応‐拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : dingjx
// 修 正 日  2011/11/01  修正内容 : Redmine#26228 拠点管理改良／伝票日付による抽出対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2011/11/30  修正内容 : Redmine#8293 拠点管理／伝票日付日付抽出改良
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 姚学剛
// 修 正 日  2012/07/24  修正内容 : 拠点管理DCログ時間追加改良
//----------------------------------------------------------------------------//
// 管理番号  11600006-00 作成担当 : 譚洪
// 修 正 日  2020/09/25  修正内容 : PMKOBETSU-3877の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ReceiveDataWork
    /// <summary>
    ///                      受信データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   受信データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/04/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br>Update Note : 2012/07/24 姚学剛 </br>
    /// <br>            : 10801804-00、Redmine#31026 拠点管理ＤＣログ時間追加改良</br>
    /// <br>Update Note      : 2020/09/25 譚洪</br>
    /// <br>管理番号         : 11600006-00</br>
    /// <br>                 : PMKOBETSU-3877の対応</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class DCReceiveDataWork
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

        /// <summary>終了日付時間TICKS</summary>
        private Int64 _endDateTimeTicks;

		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
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

		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

        //  ADD dingjx  2011/11/01  ----------------------------->>>>>>
        /// <summary>種別</summary>
        /// <remarks>0:データ　1:マスタ</remarks>
        private Int32 _kind;

        /// <summary>送受信ログ抽出条件区分</summary>
        /// <remarks>0:差分,1:伝票日付</remarks>
        private Int32 _sndLogExtraCondDiv;

        // ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026-------->>>>>
        /// <summary>送受信履歴ログ送信番号</summary>
        private Int32 _sndRcvHisConsNo;

        /// <summary>送信先企業コード</summary>
        private string _sendDestEpCode = "";

        /// <summary>送信先拠点コード</summary>
        private string _sendDestSecCode = "";

        /// <summary>送受信状態</summary>
        /// <remarks>0:成功,1:失敗</remarks>
        private Int32 _sndRcvCondition;

        /// <summary>仮受信区分</summary>
        /// <remarks >1:受信,2:仮受信</remarks>
        private Int32 _tempReceiveDiv;

        /// <summary>送受信エラー内容</summary>
        private string _sndRcvErrContents = "";

        /// <summary>送受信ファイルＩＤ</summary>
        private string _sndRcvFileID = "";
        // ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026---------<<<<<

        // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
        /// <summary>受注データ受信区分</summary>
        /// <remarks>0:送信なし 1:送信あり</remarks>
        private Int32 _acptAnOdrRecvDiv;

        /// <summary>貸出データ受信区分</summary>
        /// <remarks>0:送信なし 1:送信あり</remarks>
        private Int32 _shipmentRecvDiv;

        /// <summary>見積データ受信区分</summary>
        /// <remarks>0:送信なし 1:送信あり</remarks>
        private Int32 _estimateRecvDiv;
        // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------<<<<<

        /// <summary>
        /// 種別
        /// </summary>
        public Int32 Kind
        {
            get { return _kind; }
            set { _kind = value; }
        }

        /// <summary>
        /// 送受信ログ抽出条件区分
        /// </summary>
        public Int32 SndLogExtraCondDiv
        {
            get { return _sndLogExtraCondDiv; }
            set { _sndLogExtraCondDiv = value; }
        }
        //  ADD dingjx  2011/11/01  -----------------------------<<<<<<

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

        /// public propaty name  :  EndDateTimeTicks
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

		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
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
		/// <summary>売上要否フラグ</summary>
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
		/// <summary>売上明細要否フラグ</summary>
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
		/// <summary>受注マスタ（車両）要否フラグ</summary>
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
		/// <summary>受注マスタ要否フラグ</summary>
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
		/// <summary>売上履歴要否フラグ</summary>
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
		/// <summary>売上履歴明細要否フラグ</summary>
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
		/// <summary>入金要否フラグ</summary>
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
		/// <summary>入金明細要否フラグ</summary>
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
		/// <summary>仕入要否フラグ</summary>
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
		/// <summary>仕入明細要否フラグ</summary>
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
		/// <summary>仕入履歴要否フラグ</summary>
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
		/// <summary>仕入履歴明細要否フラグ</summary>
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
		/// <summary>支払伝票要否フラグ</summary>
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
		/// <summary>支払明細要否フラグ</summary>
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

		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

        // ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026-------->>>>>
        /// public propaty name  :  SndRcvHisConsNo
        /// <summary>送受信履歴ログ送信番号</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送受信履歴ログ送信番号パティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SndRcvHisConsNo
        {
            get { return _sndRcvHisConsNo; }
            set { _sndRcvHisConsNo = value; }
        }

        /// public propaty name  :  SendDestEpCode
        /// <summary>送信先企業コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信先企業コードパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SendDestEpCode
        {
            get { return _sendDestEpCode; }
            set { _sendDestEpCode = value; }
        }

        /// public propaty name  :  SendDestSecCode
        /// <summary>送信先拠点コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信先拠点コードパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SendDestSecCode
        {
            get { return _sendDestSecCode; }
            set { _sendDestSecCode = value; }
        }

        /// public propaty name  :  SndRcvCondition
        /// <summary>送受信状態</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送受信状態パティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SndRcvCondition
        {
            get { return _sndRcvCondition; }
            set { _sndRcvCondition = value; }
        }

        /// public propaty name  :  TempReceiveDiv
        /// <summary>仮受信区分</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仮受信区分パティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TempReceiveDiv
        {
            get { return _tempReceiveDiv; }
            set { _tempReceiveDiv = value; }
        }

        /// public propaty name  :  SndRcvErrContents
        /// <summary>送受信エラー内容</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送受信エラー内容パティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SndRcvErrContents
        {
            get { return _sndRcvErrContents; }
            set { _sndRcvErrContents = value; }
        }

        /// public propaty name  :  SndRcvFileID
        /// <summary>送受信ファイルＩＤ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送受信ファイルＩＤパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SndRcvFileID
        {
            get { return _sndRcvFileID; }
            set { _sndRcvFileID = value; }
        }
        // ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026---------<<<<<

        // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
        /// public propaty name  :  AcptAnOdrRecvDiv
        /// <summary>受注データ受信区分プロパティ</summary>
        /// <value>0:送信なし 1:送信あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注データ受信区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptAnOdrRecvDiv
        {
            get { return _acptAnOdrRecvDiv; }
            set { _acptAnOdrRecvDiv = value; }
        }

        /// public propaty name  :  ShipmentRecvDiv
        /// <summary>貸出データ受信区分プロパティ</summary>
        /// <value>0:送信なし 1:送信あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   貸出データ受信区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ShipmentRecvDiv
        {
            get { return _shipmentRecvDiv; }
            set { _shipmentRecvDiv = value; }
        }

        /// public propaty name  :  EstimateRecvDiv
        /// <summary>見積データ受信区分プロパティ</summary>
        /// <value>0:送信なし 1:送信あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積データ受信区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EstimateRecvDiv
        {
            get { return _estimateRecvDiv; }
            set { _estimateRecvDiv = value; }
        }
        // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------<<<<<

        /// <summary>
        /// 受信データワークコンストラクタ
        /// </summary>
        /// <returns>ReceiveDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ReceiveDataWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DCReceiveDataWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>ReceiveDataWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   ReceiveDataWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class DCReceiveDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   ReceiveDataWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note : 2012/07/24 姚学剛 </br>
        /// <br>            : 10801804-00、Redmine#31026 拠点管理ＤＣログ時間追加改良</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  ReceiveDataWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is DCReceiveDataWork || graph is ArrayList || graph is DCReceiveDataWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(DCReceiveDataWork).FullName));

            if (graph != null && graph is DCReceiveDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.DCReceiveDataWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is DCReceiveDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((DCReceiveDataWork[])graph).Length;
            }
            else if (graph is DCReceiveDataWork)
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
			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
			//拠点コード
			serInfo.MemberInfo.Add(typeof(string)); //PmSectionCode
			//売上要否フラグ
			serInfo.MemberInfo.Add(typeof(Boolean)); // DoSalesSlipFlg
			//売上明細要否フラグ
			serInfo.MemberInfo.Add(typeof(Boolean)); // DoSalesDetailFlg
			//受注マスタ（車両）要否フラグ
			serInfo.MemberInfo.Add(typeof(Boolean)); // DoAcceptOdrCarFlg
			//受注マスタ要否フラグ
			serInfo.MemberInfo.Add(typeof(Boolean)); // DoAcceptOdrFlg
			//売上履歴要否フラグ
			serInfo.MemberInfo.Add(typeof(Boolean)); // DoSalesHistoryFlg
			//売上履歴明細要否フラグ
			serInfo.MemberInfo.Add(typeof(Boolean)); // DoSalesHistDtlFlg
			//入金要否フラグ
			serInfo.MemberInfo.Add(typeof(Boolean)); // DoDepsitMainFlg
			//入金明細要否フラグ
			serInfo.MemberInfo.Add(typeof(Boolean)); // DoDepsitDtlFlg
			//仕入要否フラグ
			serInfo.MemberInfo.Add(typeof(Boolean)); // DoStockSlipFlg
			//仕入明細要否フラグ
			serInfo.MemberInfo.Add(typeof(Boolean)); // DoStockDetailFlg
			//仕入履歴要否フラグ
			serInfo.MemberInfo.Add(typeof(Boolean)); // DoStockSlipHistFlg
			//仕入履歴明細要否フラグ
			serInfo.MemberInfo.Add(typeof(Boolean)); // DoStockSlHistDtlFlg
			//支払伝票要否フラグ
			serInfo.MemberInfo.Add(typeof(Boolean)); // DoPaymentSlpFlg
			//支払明細要否フラグ
			serInfo.MemberInfo.Add(typeof(Boolean)); // DoPaymentDtlFlg		
			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

            // ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026-------->>>>>
            //送受信履歴ログ送信番号
            serInfo.MemberInfo.Add(typeof(Int32));  // SndRcvHisConsNo
            //送信先企業コード
            serInfo.MemberInfo.Add(typeof(string));  // SendDestEpCode
            //送信先拠点コード
            serInfo.MemberInfo.Add(typeof(string));  // SendDestSecCode
            //送受信状態
            serInfo.MemberInfo.Add(typeof(Int32));  // SndRcvCondition
            //仮受信区分
            serInfo.MemberInfo.Add(typeof(Int32));  // TempReceiveDiv
            //送受信エラー内容
            serInfo.MemberInfo.Add(typeof(string)); // SndRcvErrContents
            //送受信ファイルＩＤ
            serInfo.MemberInfo.Add(typeof(string)); // SndRcvFileID
            // ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026---------<<<<<

            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
            //受注データ受信区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrRecvDiv
            //貸出データ受信区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmentRecvDiv
            //見積データ受信区分
            serInfo.MemberInfo.Add(typeof(Int32)); //EstimateRecvDiv
            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is DCReceiveDataWork)
            {
                DCReceiveDataWork temp = (DCReceiveDataWork)graph;

                SetReceiveDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is DCReceiveDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((DCReceiveDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (DCReceiveDataWork temp in lst)
                {
                    SetReceiveDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// ReceiveDataWorkメンバ数(publicプロパティ数)
        /// <br>Update Note : 2012/07/24 姚学剛 </br>
        /// <br>            : 10801804-00、Redmine#31026 拠点管理ＤＣログ時間追加改良</br>
        /// </summary>
        //private const int currentMemberCount = 18;
        //private const int currentMemberCount = 20;    // DEL 2012/07/24 姚学剛
        // --- UPD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
        //private const int currentMemberCount = 27;  // ADD 2012/07/24 姚学剛
        private const int currentMemberCount = 30;
        // --- UPD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------<<<<<
        /// <summary>
        ///  ReceiveDataWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   ReceiveDataWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note : 2012/07/24 姚学剛 </br>
        /// <br>            : 10801804-00、Redmine#31026 拠点管理ＤＣログ時間追加改良</br>
        /// </remarks>
        private void SetReceiveDataWork(System.IO.BinaryWriter writer, DCReceiveDataWork temp)
        {
            //PM企業コード
            writer.Write(temp.PmEnterpriseCode);
            //開始日付時間
            writer.Write(temp.StartDateTime);
            //終了日付時間
            writer.Write(temp.EndDateTime);
            //シンク実行日付時間
            writer.Write(temp.SyncExecDate);
            //終了日付時間
            writer.Write(temp.EndDateTimeTicks);
			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
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
			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

            // ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026-------->>>>>
            //送受信履歴ログ送信番号
            writer.Write(temp.SndRcvHisConsNo);
            //送信先企業コード
            writer.Write(temp.SendDestEpCode);
            //送信先拠点コード
            writer.Write(temp.SendDestSecCode);
            //送受信状態
            writer.Write(temp.SndRcvCondition);
            //仮受信区分
            writer.Write(temp.TempReceiveDiv);
            //送受信エラー内容
            writer.Write(temp.SndRcvErrContents);
            //送受信ファイルＩＤ
            writer.Write(temp.SndRcvFileID);
            // ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026---------<<<<<
            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
            //受注データ受信区分
            writer.Write(temp.AcptAnOdrRecvDiv);
            //貸出データ受信区分
            writer.Write(temp.ShipmentRecvDiv);
            //見積データ受信区分
            writer.Write(temp.EstimateRecvDiv);
            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------<<<<<
        }

        /// <summary>
        ///  ReceiveDataWorkインスタンス取得
        /// </summary>
        /// <returns>ReceiveDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ReceiveDataWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note : 2012/07/24 姚学剛 </br>
        /// <br>            : 10801804-00、Redmine#31026 拠点管理ＤＣログ時間追加改良</br>
        /// </remarks>
        private DCReceiveDataWork GetReceiveDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            DCReceiveDataWork temp = new DCReceiveDataWork();

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
			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
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
			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

            // ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026-------->>>>>
            //送受信履歴ログ送信番号
            temp.SndRcvHisConsNo = reader.ReadInt32();
            //送信先企業コード
            temp.SendDestEpCode = reader.ReadString();
            //送信先拠点コード
            temp.SendDestSecCode = reader.ReadString();
            //送受信状態
            temp.SndRcvCondition = reader.ReadInt32();
            //仮受信区分
            temp.TempReceiveDiv = reader.ReadInt32();
            //送受信エラー内容
            temp.SndRcvErrContents = reader.ReadString();
            //送受信ファイルＩＤ
            temp.SndRcvFileID = reader.ReadString();
            // ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026---------<<<<<

            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
            //受注データ受信区分
            temp.AcptAnOdrRecvDiv = reader.ReadInt32();
            //貸出データ受信区分
            temp.ShipmentRecvDiv = reader.ReadInt32();
            //見積データ受信区分
            temp.EstimateRecvDiv = reader.ReadInt32();
            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------<<<<<

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
        /// <returns>ReceiveDataWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ReceiveDataWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                DCReceiveDataWork temp = GetReceiveDataWork(reader, serInfo);
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
                    retValue = (DCReceiveDataWork[])lst.ToArray(typeof(DCReceiveDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
