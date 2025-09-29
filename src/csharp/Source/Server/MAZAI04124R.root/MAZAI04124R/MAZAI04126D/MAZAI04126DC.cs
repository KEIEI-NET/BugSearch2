using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockMoveSlipSearchCondWork
    /// <summary>
    ///                      在庫移動伝票検索条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫移動伝票検索条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/01/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br>Update Note      :   2012/05/22 wangf </br>
    /// <br>　　　　         :   10801804-00、06/27配信分、Redmine#29881 在庫移動入力抽出条件に日付を指定しても反映されないの対応</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockMoveSlipSearchCondWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>在庫移動伝票番号</summary>
        private Int32 _stockMoveSlipNo;

        /// <summary>在庫移動入力従業員コード</summary>
        /// <remarks>在庫移動伝票を入力する従業員コードをセット</remarks>
        private string _stockMvEmpCode = "";

        /// <summary>出荷担当従業員コード</summary>
        /// <remarks>出荷確定処理を行う従業員コードをセット</remarks>
        private string _shipAgentCd = "";

        /// <summary>引取担当従業員コード</summary>
        /// <remarks>在庫の入荷側の従業員コードをセット</remarks>
        private string _receiveAgentCd = "";

        /// <summary>出荷予定開始日</summary>
        /// <remarks>在庫移動処理（出荷側）を行った時にセット</remarks>
        private DateTime _shipmentScdlStDay;

        /// <summary>出荷予定終了日</summary>
        /// <remarks>在庫移動処理（出荷側）を行った時にセット</remarks>
        private DateTime _shipmentScdlEdDay;

        /// <summary>出荷確定開始日</summary>
        /// <remarks>出荷確定処理（出荷側）を行った時にセット</remarks>
        private DateTime _shipmentFixStDay;

        /// <summary>出荷確定終了日</summary>
        /// <remarks>出荷確定処理（出荷側）を行った時にセット</remarks>
        private DateTime _shipmentFixEdDay;

        /// <summary>入荷開始日</summary>
        private DateTime _arrivalGoodsStDay;

        /// <summary>入荷終了日</summary>
        private DateTime _arrivalGoodsEdDay;

        /// <summary>移動元拠点コード</summary>
        private string _bfSectionCode = "";

        /// <summary>移動元倉庫コード</summary>
        private string _bfEnterWarehCode = "";

        /// <summary>移動先拠点コード</summary>
        private string _afSectionCode = "";

        /// <summary>移動先倉庫コード</summary>
        private string _afEnterWarehCode = "";

        /// <summary>移動状態</summary>
        /// <remarks>0:移動対象外、1:未出荷状態、2:移動中、9:入荷済</remarks>
        private Int32[] _moveStatus;

        /// <summary>在庫移動確定区分</summary>
        /// <remarks>1：入荷確定あり、２：入荷確定なし </remarks>
        private Int32 _stockMoveFixCode;

        /// <summary>伝票区分</summary>
        /// <remarks>1:出庫伝票、2：入庫伝票</remarks>
        private Int32 _slipDiv;

        // ------------ADD START wangf 2012/05/22 FOR Redmine#29881--------->>>>
        /// <summary>呼出元機能区分</summary>
        /// <remarks>1:在庫移動入力検索ガイド、2：他の場合</remarks>
        private Int32 _callerFunction;
        // ------------ADD END wangf 2012/05/22 FOR Redmine#29881---------<<<<<

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

        /// public propaty name  :  StockMoveSlipNo
        /// <summary>在庫移動伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫移動伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockMoveSlipNo
        {
            get { return _stockMoveSlipNo; }
            set { _stockMoveSlipNo = value; }
        }

        /// public propaty name  :  StockMvEmpCode
        /// <summary>在庫移動入力従業員コードプロパティ</summary>
        /// <value>在庫移動伝票を入力する従業員コードをセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫移動入力従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockMvEmpCode
        {
            get { return _stockMvEmpCode; }
            set { _stockMvEmpCode = value; }
        }

        /// public propaty name  :  ShipAgentCd
        /// <summary>出荷担当従業員コードプロパティ</summary>
        /// <value>出荷確定処理を行う従業員コードをセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷担当従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ShipAgentCd
        {
            get { return _shipAgentCd; }
            set { _shipAgentCd = value; }
        }

        /// public propaty name  :  ReceiveAgentCd
        /// <summary>引取担当従業員コードプロパティ</summary>
        /// <value>在庫の入荷側の従業員コードをセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   引取担当従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ReceiveAgentCd
        {
            get { return _receiveAgentCd; }
            set { _receiveAgentCd = value; }
        }

        /// public propaty name  :  ShipmentScdlStDay
        /// <summary>出荷予定開始日プロパティ</summary>
        /// <value>在庫移動処理（出荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷予定開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ShipmentScdlStDay
        {
            get { return _shipmentScdlStDay; }
            set { _shipmentScdlStDay = value; }
        }

        /// public propaty name  :  ShipmentScdlEdDay
        /// <summary>出荷予定終了日プロパティ</summary>
        /// <value>在庫移動処理（出荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷予定終了日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ShipmentScdlEdDay
        {
            get { return _shipmentScdlEdDay; }
            set { _shipmentScdlEdDay = value; }
        }

        /// public propaty name  :  ShipmentFixStDay
        /// <summary>出荷確定開始日プロパティ</summary>
        /// <value>出荷確定処理（出荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷確定開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ShipmentFixStDay
        {
            get { return _shipmentFixStDay; }
            set { _shipmentFixStDay = value; }
        }

        /// public propaty name  :  ShipmentFixEdDay
        /// <summary>出荷確定終了日プロパティ</summary>
        /// <value>出荷確定処理（出荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷確定終了日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ShipmentFixEdDay
        {
            get { return _shipmentFixEdDay; }
            set { _shipmentFixEdDay = value; }
        }

        /// public propaty name  :  ArrivalGoodsStDay
        /// <summary>入荷開始日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入荷開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ArrivalGoodsStDay
        {
            get { return _arrivalGoodsStDay; }
            set { _arrivalGoodsStDay = value; }
        }

        /// public propaty name  :  ArrivalGoodsEdDay
        /// <summary>入荷終了日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入荷終了日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ArrivalGoodsEdDay
        {
            get { return _arrivalGoodsEdDay; }
            set { _arrivalGoodsEdDay = value; }
        }

        /// public propaty name  :  BfSectionCode
        /// <summary>移動元拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動元拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BfSectionCode
        {
            get { return _bfSectionCode; }
            set { _bfSectionCode = value; }
        }

        /// public propaty name  :  BfEnterWarehCode
        /// <summary>移動元倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動元倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BfEnterWarehCode
        {
            get { return _bfEnterWarehCode; }
            set { _bfEnterWarehCode = value; }
        }

        /// public propaty name  :  AfSectionCode
        /// <summary>移動先拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動先拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfSectionCode
        {
            get { return _afSectionCode; }
            set { _afSectionCode = value; }
        }

        /// public propaty name  :  AfEnterWarehCode
        /// <summary>移動先倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動先倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfEnterWarehCode
        {
            get { return _afEnterWarehCode; }
            set { _afEnterWarehCode = value; }
        }

        /// public propaty name  :  MoveStatus
        /// <summary>移動状態プロパティ</summary>
        /// <value>0:移動対象外、1:未出荷状態、2:移動中、9:入荷済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動状態プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32[] MoveStatus
        {
            get { return _moveStatus; }
            set { _moveStatus = value; }
        }

        /// public propaty name  :  StockMoveFixCode
        /// <summary>在庫移動確定区分プロパティ</summary>
        /// <value>1：入荷確定あり、２：入荷確定なし </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫移動確定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockMoveFixCode
        {
            get { return _stockMoveFixCode; }
            set { _stockMoveFixCode = value; }
        }

        /// public propaty name  :  StockMoveFormal
        /// <summary>伝票区分プロパティ</summary>
        /// <value>1:出庫伝票、2：入庫伝票</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipDiv
        {
            get { return _slipDiv; }
            set { _slipDiv = value; }
        }

        // ------------ADD START wangf 2012/05/22 FOR Redmine#29881--------->>>>
        /// public propaty name  :  CallerFunction
        /// <summary>呼出元機能区分プロパティ</summary>
        /// <value>1:在庫移動入力検索ガイド、2：他の場合</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   呼出元機能区分プロパティ</br>
        /// <br>Programer        :   wangf</br>
        /// </remarks>
        public Int32 CallerFunction
        {
            get { return _callerFunction; }
            set { _callerFunction = value; }
        }
        // ------------ADD END wangf 2012/05/22 FOR Redmine#29881---------<<<<<

        /// <summary>
        /// 在庫移動伝票検索条件ワークコンストラクタ
        /// </summary>
        /// <returns>StockMoveSlipSearchCondWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMoveSlipSearchCondWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockMoveSlipSearchCondWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StockMoveSlipSearchCondWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StockMoveSlipSearchCondWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class StockMoveSlipSearchCondWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMoveSlipSearchCondWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2012/05/22 wangf </br>
        /// <br>                 :   10801804-00、06/27配信分、Redmine#29881 在庫移動入力抽出条件に日付を指定しても反映されないの対応</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockMoveSlipSearchCondWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockMoveSlipSearchCondWork || graph is ArrayList || graph is StockMoveSlipSearchCondWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(StockMoveSlipSearchCondWork).FullName));

            if (graph != null && graph is StockMoveSlipSearchCondWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockMoveSlipSearchCondWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockMoveSlipSearchCondWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockMoveSlipSearchCondWork[])graph).Length;
            }
            else if (graph is StockMoveSlipSearchCondWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //在庫移動伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //StockMoveSlipNo
            //在庫移動入力従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //StockMvEmpCode
            //出荷担当従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //ShipAgentCd
            //引取担当従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //ReceiveAgentCd
            //出荷予定開始日
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmentScdlStDay
            //出荷予定終了日
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmentScdlEdDay
            //出荷確定開始日
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmentFixStDay
            //出荷確定終了日
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmentFixEdDay
            //入荷開始日
            serInfo.MemberInfo.Add(typeof(Int32)); //ArrivalGoodsStDay
            //入荷終了日
            serInfo.MemberInfo.Add(typeof(Int32)); //ArrivalGoodsEdDay
            //移動元拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //BfSectionCode
            //移動元倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //BfEnterWarehCode
            //移動先拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AfSectionCode
            //移動先倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //AfEnterWarehCode
            ////移動状態
            //serInfo.MemberInfo.Add(typeof(Int32[])); //MoveStatus
            //在庫移動確定区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockMoveFixCode
            //伝票区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipDiv
            // ------------ADD START wangf 2012/05/22 FOR Redmine#29881--------->>>>
            //呼出元機能区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CallerFunction
            // ------------ADD END wangf 2012/05/22 FOR Redmine#29881---------<<<<<


            serInfo.Serialize(writer, serInfo);
            if (graph is StockMoveSlipSearchCondWork)
            {
                StockMoveSlipSearchCondWork temp = (StockMoveSlipSearchCondWork)graph;

                SetStockMoveSlipSearchCondWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockMoveSlipSearchCondWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockMoveSlipSearchCondWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockMoveSlipSearchCondWork temp in lst)
                {
                    SetStockMoveSlipSearchCondWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockMoveSlipSearchCondWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 18; // DEL wangf 2012/05/22 FOR Redmine#29881
        private const int currentMemberCount = 19; // ADD wangf 2012/05/22 FOR Redmine#29881

        /// <summary>
        ///  StockMoveSlipSearchCondWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMoveSlipSearchCondWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2012/05/22 wangf </br>
        /// <br>                 :   10801804-00、06/27配信分、Redmine#29881 在庫移動入力抽出条件に日付を指定しても反映されないの対応</br>
        /// </remarks>
        private void SetStockMoveSlipSearchCondWork(System.IO.BinaryWriter writer, StockMoveSlipSearchCondWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //拠点コード
            writer.Write(temp.SectionCode);
            //在庫移動伝票番号
            writer.Write(temp.StockMoveSlipNo);
            //在庫移動入力従業員コード
            writer.Write(temp.StockMvEmpCode);
            //出荷担当従業員コード
            writer.Write(temp.ShipAgentCd);
            //引取担当従業員コード
            writer.Write(temp.ReceiveAgentCd);
            //出荷予定開始日
            writer.Write((Int64)temp.ShipmentScdlStDay.Ticks);
            //出荷予定終了日
            writer.Write((Int64)temp.ShipmentScdlEdDay.Ticks);
            //出荷確定開始日
            writer.Write((Int64)temp.ShipmentFixStDay.Ticks);
            //出荷確定終了日
            writer.Write((Int64)temp.ShipmentFixEdDay.Ticks);
            //入荷開始日
            writer.Write((Int64)temp.ArrivalGoodsStDay.Ticks);
            //入荷終了日
            writer.Write((Int64)temp.ArrivalGoodsEdDay.Ticks);
            //移動元拠点コード
            writer.Write(temp.BfSectionCode);
            //移動元倉庫コード
            writer.Write(temp.BfEnterWarehCode);
            //移動先拠点コード
            writer.Write(temp.AfSectionCode);
            //移動先倉庫コード
            writer.Write(temp.AfEnterWarehCode);
            ////移動状態
            //writer.Write(temp.MoveStatus);
            //在庫移動確定区分
            writer.Write(temp.StockMoveFixCode);
            //伝票区分
            writer.Write(temp.SlipDiv);
            // ------------ADD START wangf 2012/05/22 FOR Redmine#29881--------->>>>
            //呼出元機能区分
            writer.Write(temp.CallerFunction);
            // ------------ADD END wangf 2012/05/22 FOR Redmine#29881---------<<<<<

        }

        /// <summary>
        ///  StockMoveSlipSearchCondWorkインスタンス取得
        /// </summary>
        /// <returns>StockMoveSlipSearchCondWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMoveSlipSearchCondWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2012/05/22 wangf </br>
        /// <br>                 :   10801804-00、06/27配信分、Redmine#29881 在庫移動入力抽出条件に日付を指定しても反映されないの対応</br>
        /// </remarks>
        private StockMoveSlipSearchCondWork GetStockMoveSlipSearchCondWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            StockMoveSlipSearchCondWork temp = new StockMoveSlipSearchCondWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //在庫移動伝票番号
            temp.StockMoveSlipNo = reader.ReadInt32();
            //在庫移動入力従業員コード
            temp.StockMvEmpCode = reader.ReadString();
            //出荷担当従業員コード
            temp.ShipAgentCd = reader.ReadString();
            //引取担当従業員コード
            temp.ReceiveAgentCd = reader.ReadString();
            //出荷予定開始日
            temp.ShipmentScdlStDay = new DateTime(reader.ReadInt64());
            //出荷予定終了日
            temp.ShipmentScdlEdDay = new DateTime(reader.ReadInt64());
            //出荷確定開始日
            temp.ShipmentFixStDay = new DateTime(reader.ReadInt64());
            //出荷確定終了日
            temp.ShipmentFixEdDay = new DateTime(reader.ReadInt64());
            //入荷開始日
            temp.ArrivalGoodsStDay = new DateTime(reader.ReadInt64());
            //入荷終了日
            temp.ArrivalGoodsEdDay = new DateTime(reader.ReadInt64());
            //移動元拠点コード
            temp.BfSectionCode = reader.ReadString();
            //移動元倉庫コード
            temp.BfEnterWarehCode = reader.ReadString();
            //移動先拠点コード
            temp.AfSectionCode = reader.ReadString();
            //移動先倉庫コード
            temp.AfEnterWarehCode = reader.ReadString();
            ////移動状態
            //temp.MoveStatus = reader.ReadInt32();
            //在庫移動確定区分
            temp.StockMoveFixCode = reader.ReadInt32();
            //伝票区分
            temp.SlipDiv = reader.ReadInt32();
            // ------------ADD START wangf 2012/05/22 FOR Redmine#29881--------->>>>
            //呼出元機能区分
            temp.CallerFunction = reader.ReadInt32();
            // ------------ADD END wangf 2012/05/22 FOR Redmine#29881---------<<<<<


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
        /// <returns>StockMoveSlipSearchCondWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMoveSlipSearchCondWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockMoveSlipSearchCondWork temp = GetStockMoveSlipSearchCondWork(reader, serInfo);
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
                    retValue = (StockMoveSlipSearchCondWork[])lst.ToArray(typeof(StockMoveSlipSearchCondWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
