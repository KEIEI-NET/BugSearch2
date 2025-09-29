using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesSlipSearchWork
    /// <summary>
    ///                      売上伝票検索条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上伝票検索条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br>Update Note      :   鄧潘ハン Redmine 26538</br>
    /// <br>Date             :   2011/11/11</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesSlipSearchWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>売上伝票区分</summary>
        /// <remarks>0:売上,1:返品</remarks>
        private Int32 _salesSlipCd;

        /// <summary>受注ステータス</summary>
        /// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>売掛区分</summary>
        /// <remarks>0:売掛なし,1:売掛</remarks>
        private Int32 _accRecDivCd;

        /// <summary>売上伝票番号(開始)</summary>
        private string _salesSlipNumSt = "";

        /// <summary>売上伝票番号(終了)</summary>
        private string _salesSlipNumEd = "";

        /// <summary>売上日付(開始)</summary>
        private Int32 _salesDateSt;

        /// <summary>売上日付(終了)</summary>
        private Int32 _salesDateEd;

        /// <summary>伝票検索日付(開始)</summary>
        private Int32 _searchSlipDateSt;

        /// <summary>伝票検索日付(終了)</summary>
        private Int32 _searchSlipDateEd;

        /// <summary>受付従業員コード</summary>
        /// <remarks>受付担当者（受注者）</remarks>
        private string _frontEmployeeCd = "";

        /// <summary>販売従業員コード</summary>
        /// <remarks>計上担当者（担当者）</remarks>
        private string _salesEmployeeCd = "";

        /// <summary>売上入力者コード</summary>
        /// <remarks>入力担当者（発行者）</remarks>
        private string _salesInputCode = "";

        /// <summary>請求先コード</summary>
        private Int32 _claimCode;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>部門コード</summary>
        private Int32 _subSectionCode;

        /// <summary>商品メーカーコード</summary>
        /// <remarks>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>相手先伝票番号</summary>
        /// <remarks>得意先注文番号（仮伝番号）</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>出荷日付(開始)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _shipmentDaySt;

        /// <summary>出荷日付(終了)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _shipmentDayEd;

        /// <summary>見積区分</summary>
        /// <remarks>1:通常見積　2:単価見積　3:検索見積</remarks>
        private Int32 _estimateDivide;

        /// <summary>型式（フル型）</summary>
        /// <remarks>フル型式(44桁用)</remarks>
        private string _fullModel = "";

        /// <summary>型式検索タイプ</summary>
        /// <remarks>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</remarks>
        private Int32 _fullModelSrchTyp;

        //---ADD 2011/11/11 ------------------------->>>>>
        /// <summary>受発注種別</summary>
        /// <remarks>0:PCCforNS　,1:BLﾊﾟｰﾂｵｰﾀﾞｰ</remarks>
        private Int16 _acceptOrOrderKind;

        /// <summary>自動回答種別</summary>
        /// <remarks>0:通常　,1:手動回答　,2:自動回答</remarks>
        private Int32 _autoAnswerDivSCM;

        //---ADD 2011/11/11 -------------------------<<<<<
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

        /// public propaty name  :  SalesSlipCd
        /// <summary>売上伝票区分プロパティ</summary>
        /// <value>0:売上,1:返品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipCd
        {
            get { return _salesSlipCd; }
            set { _salesSlipCd = value; }
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

        /// public propaty name  :  AccRecDivCd
        /// <summary>売掛区分プロパティ</summary>
        /// <value>0:売掛なし,1:売掛</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売掛区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AccRecDivCd
        {
            get { return _accRecDivCd; }
            set { _accRecDivCd = value; }
        }

        /// public propaty name  :  SalesSlipNumSt
        /// <summary>売上伝票番号(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipNumSt
        {
            get { return _salesSlipNumSt; }
            set { _salesSlipNumSt = value; }
        }

        /// public propaty name  :  SalesSlipNumEd
        /// <summary>売上伝票番号(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipNumEd
        {
            get { return _salesSlipNumEd; }
            set { _salesSlipNumEd = value; }
        }

        /// public propaty name  :  SalesDateSt
        /// <summary>売上日付(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesDateSt
        {
            get { return _salesDateSt; }
            set { _salesDateSt = value; }
        }

        /// public propaty name  :  SalesDateEd
        /// <summary>売上日付(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesDateEd
        {
            get { return _salesDateEd; }
            set { _salesDateEd = value; }
        }

        /// public propaty name  :  SearchSlipDateSt
        /// <summary>伝票検索日付(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchSlipDateSt
        {
            get { return _searchSlipDateSt; }
            set { _searchSlipDateSt = value; }
        }

        /// public propaty name  :  SearchSlipDateEd
        /// <summary>伝票検索日付(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchSlipDateEd
        {
            get { return _searchSlipDateEd; }
            set { _searchSlipDateEd = value; }
        }

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>受付従業員コードプロパティ</summary>
        /// <value>受付担当者（受注者）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受付従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrontEmployeeCd
        {
            get { return _frontEmployeeCd; }
            set { _frontEmployeeCd = value; }
        }

        /// public propaty name  :  SalesEmployeeCd
        /// <summary>販売従業員コードプロパティ</summary>
        /// <value>計上担当者（担当者）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesEmployeeCd
        {
            get { return _salesEmployeeCd; }
            set { _salesEmployeeCd = value; }
        }

        /// public propaty name  :  SalesInputCode
        /// <summary>売上入力者コードプロパティ</summary>
        /// <value>入力担当者（発行者）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上入力者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesInputCode
        {
            get { return _salesInputCode; }
            set { _salesInputCode = value; }
        }

        /// public propaty name  :  ClaimCode
        /// <summary>請求先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ClaimCode
        {
            get { return _claimCode; }
            set { _claimCode = value; }
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

        /// public propaty name  :  SubSectionCode
        /// <summary>部門コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部門コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubSectionCode
        {
            get { return _subSectionCode; }
            set { _subSectionCode = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// <value>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>相手先伝票番号プロパティ</summary>
        /// <value>得意先注文番号（仮伝番号）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
        }

        /// public propaty name  :  ShipmentDaySt
        /// <summary>出荷日付(開始)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷日付(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ShipmentDaySt
        {
            get { return _shipmentDaySt; }
            set { _shipmentDaySt = value; }
        }

        /// public propaty name  :  ShipmentDayEd
        /// <summary>出荷日付(終了)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷日付(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ShipmentDayEd
        {
            get { return _shipmentDayEd; }
            set { _shipmentDayEd = value; }
        }

        /// public propaty name  :  EstimateDivide
        /// <summary>見積区分プロパティ</summary>
        /// <value>1:通常見積　2:単価見積　3:検索見積</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EstimateDivide
        {
            get { return _estimateDivide; }
            set { _estimateDivide = value; }
        }

        /// public propaty name  :  FullModel
        /// <summary>型式（フル型）プロパティ</summary>
        /// <value>フル型式(44桁用)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式（フル型）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FullModel
        {
            get { return _fullModel; }
            set { _fullModel = value; }
        }

        /// public propaty name  :  FullModelSrchTyp
        /// <summary>型式検索タイププロパティ</summary>
        /// <value>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式検索タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FullModelSrchTyp
        {
            get { return _fullModelSrchTyp; }
            set { _fullModelSrchTyp = value; }
        }

        //---ADD 2011/11/11 ----------------------->>>>>

        /// public propaty name  :  AcceptOrOrderKindRF
        /// <summary>受発注種別プロパティ</summary>
        /// <value>0:PCCforNS　,1:BLﾊﾟｰﾂｵｰﾀﾞｰ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受発注種別プロパティ</br>
        /// <br>Programer        :   鄧潘ハン</br>
        /// </remarks>
        public Int16 AcceptOrOrderKind
        {
            get { return _acceptOrOrderKind; }
            set { _acceptOrOrderKind = value; }
        }


        /// public propaty name  :  AutoAnswerDivSCM
        /// <summary>自動回答種別プロパティ</summary>
        /// <value>0:通常　,1:手動回答　,2:自動回答</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動回答種別プロパティ</br>
        /// <br>Programer        :   鄧潘ハン</br>
        /// </remarks>
        public Int32 AutoAnswerDivSCM
        {
            get { return _autoAnswerDivSCM; }
            set { _autoAnswerDivSCM = value; }
        }

        //---ADD 2011/11/11 -----------------------<<<<<

        /// <summary>
        /// 売上伝票検索条件ワークコンストラクタ
        /// </summary>
        /// <returns>SalesSlipSearchWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipSearchWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesSlipSearchWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SalesSlipSearchWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SalesSlipSearchWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SalesSlipSearchWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipSearchWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   鄧潘ハン BLﾊﾟｰﾂｵｰﾀﾞｰ在庫確認時の見積伝票対応</br>
        /// <br>Date             :   2011/11/11</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalesSlipSearchWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalesSlipSearchWork || graph is ArrayList || graph is SalesSlipSearchWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SalesSlipSearchWork).FullName));

            if (graph != null && graph is SalesSlipSearchWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalesSlipSearchWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalesSlipSearchWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalesSlipSearchWork[])graph).Length;
            }
            else if (graph is SalesSlipSearchWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //売上伝票区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCd
            //受注ステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //売掛区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AccRecDivCd
            //売上伝票番号(開始)
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNumSt
            //売上伝票番号(終了)
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNumEd
            //売上日付(開始)
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDateSt
            //売上日付(終了)
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDateEd
            //伝票検索日付(開始)
            serInfo.MemberInfo.Add(typeof(Int32)); //SearchSlipDateSt
            //伝票検索日付(終了)
            serInfo.MemberInfo.Add(typeof(Int32)); //SearchSlipDateEd
            //受付従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //FrontEmployeeCd
            //販売従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeCd
            //売上入力者コード
            serInfo.MemberInfo.Add(typeof(string)); //SalesInputCode
            //請求先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //ClaimCode
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //部門コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //相手先伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNum
            //出荷日付(開始)
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmentDaySt
            //出荷日付(終了)
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmentDayEd
            //見積区分
            serInfo.MemberInfo.Add(typeof(Int32)); //EstimateDivide
            //型式（フル型）
            serInfo.MemberInfo.Add(typeof(string)); //FullModel
            //型式検索タイプ
            serInfo.MemberInfo.Add(typeof(Int32)); //FullModelSrchTyp
            //---ADD 2011/11/11 ---------------------->>>>>
            //受発注種別
            serInfo.MemberInfo.Add(typeof(Int16)); //AcceptOrOrderKind
            //自動回答種別
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoAnswerDivSCM
            //---ADD 2011/11/11 ----------------------<<<<<
           
            serInfo.Serialize(writer, serInfo);
            if (graph is SalesSlipSearchWork)
            {
                SalesSlipSearchWork temp = (SalesSlipSearchWork)graph;

                SetSalesSlipSearchWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalesSlipSearchWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalesSlipSearchWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalesSlipSearchWork temp in lst)
                {
                    SetSalesSlipSearchWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalesSlipSearchWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 25; // DEL 2011/11/11
        private const int currentMemberCount = 27; // ADD 2011/11/11
        /// <summary>
        ///  SalesSlipSearchWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipSearchWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   鄧潘ハン BLﾊﾟｰﾂｵｰﾀﾞｰ在庫確認時の見積伝票対応</br>
        /// <br>Date             :   2011/11/11</br>
        /// </remarks>
        private void SetSalesSlipSearchWork(System.IO.BinaryWriter writer, SalesSlipSearchWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //売上伝票区分
            writer.Write(temp.SalesSlipCd);
            //受注ステータス
            writer.Write(temp.AcptAnOdrStatus);
            //売掛区分
            writer.Write(temp.AccRecDivCd);
            //売上伝票番号(開始)
            writer.Write(temp.SalesSlipNumSt);
            //売上伝票番号(終了)
            writer.Write(temp.SalesSlipNumEd);
            //売上日付(開始)
            writer.Write(temp.SalesDateSt);
            //売上日付(終了)
            writer.Write(temp.SalesDateEd);
            //伝票検索日付(開始)
            writer.Write(temp.SearchSlipDateSt);
            //伝票検索日付(終了)
            writer.Write(temp.SearchSlipDateEd);
            //受付従業員コード
            writer.Write(temp.FrontEmployeeCd);
            //販売従業員コード
            writer.Write(temp.SalesEmployeeCd);
            //売上入力者コード
            writer.Write(temp.SalesInputCode);
            //請求先コード
            writer.Write(temp.ClaimCode);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //拠点コード
            writer.Write(temp.SectionCode);
            //部門コード
            writer.Write(temp.SubSectionCode);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //商品番号
            writer.Write(temp.GoodsNo);
            //相手先伝票番号
            writer.Write(temp.PartySaleSlipNum);
            //出荷日付(開始)
            writer.Write(temp.ShipmentDaySt);
            //出荷日付(終了)
            writer.Write(temp.ShipmentDayEd);
            //見積区分
            writer.Write(temp.EstimateDivide);
            //型式（フル型）
            writer.Write(temp.FullModel);
            //型式検索タイプ
            writer.Write(temp.FullModelSrchTyp);
            //---ADD 2011/11/11 ------->>>>>
            //受発注種別
            writer.Write(temp.AcceptOrOrderKind);
            //自動回答種別
            writer.Write(temp.AutoAnswerDivSCM);
            //---ADD 2011/11/11 -------<<<<<
        }

        /// <summary>
        ///  SalesSlipSearchWorkインスタンス取得
        /// </summary>
        /// <returns>SalesSlipSearchWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipSearchWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   鄧潘ハン BLﾊﾟｰﾂｵｰﾀﾞｰ在庫確認時の見積伝票対応</br>
        /// <br>Date             :   2011/11/11</br>
        /// </remarks>
        private SalesSlipSearchWork GetSalesSlipSearchWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SalesSlipSearchWork temp = new SalesSlipSearchWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //売上伝票区分
            temp.SalesSlipCd = reader.ReadInt32();
            //受注ステータス
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //売掛区分
            temp.AccRecDivCd = reader.ReadInt32();
            //売上伝票番号(開始)
            temp.SalesSlipNumSt = reader.ReadString();
            //売上伝票番号(終了)
            temp.SalesSlipNumEd = reader.ReadString();
            //売上日付(開始)
            temp.SalesDateSt = reader.ReadInt32();
            //売上日付(終了)
            temp.SalesDateEd = reader.ReadInt32();
            //伝票検索日付(開始)
            temp.SearchSlipDateSt = reader.ReadInt32();
            //伝票検索日付(終了)
            temp.SearchSlipDateEd = reader.ReadInt32();
            //受付従業員コード
            temp.FrontEmployeeCd = reader.ReadString();
            //販売従業員コード
            temp.SalesEmployeeCd = reader.ReadString();
            //売上入力者コード
            temp.SalesInputCode = reader.ReadString();
            //請求先コード
            temp.ClaimCode = reader.ReadInt32();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //部門コード
            temp.SubSectionCode = reader.ReadInt32();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //相手先伝票番号
            temp.PartySaleSlipNum = reader.ReadString();
            //出荷日付(開始)
            temp.ShipmentDaySt = reader.ReadInt32();
            //出荷日付(終了)
            temp.ShipmentDayEd = reader.ReadInt32();
            //見積区分
            temp.EstimateDivide = reader.ReadInt32();
            //型式（フル型）
            temp.FullModel = reader.ReadString();
            //型式検索タイプ
            temp.FullModelSrchTyp = reader.ReadInt32();

            //---ADD 2011/11/11 ----------->>>>>
            //受発注種別
            temp.AcceptOrOrderKind = reader.ReadInt16();
            //自動回答種別
            temp.AutoAnswerDivSCM = reader.ReadInt32();
            //---ADD 2011/11/11 -----------<<<<<

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
        /// <returns>SalesSlipSearchWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipSearchWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalesSlipSearchWork temp = GetSalesSlipSearchWork(reader, serInfo);
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
                    retValue = (SalesSlipSearchWork[])lst.ToArray(typeof(SalesSlipSearchWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
