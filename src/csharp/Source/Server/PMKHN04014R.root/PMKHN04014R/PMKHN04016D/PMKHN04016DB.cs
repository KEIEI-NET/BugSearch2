using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CustomerSearchRetWork
    /// <summary>
    ///                      得意先検索結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   得意先検索結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/05/09  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   更新日時を追加</br>
    /// <br>Programmer       :   23015 森本 大輝</br>
    /// <br>Date             :   2008/09/05</br>
    /// <br>Update Note      :   MANTIS:14721 得意先検索結果の表示項目に自宅FAXと勤務先FAXを追加</br>
    /// <br>Programmer       :   30517 夏野 駿希</br>
    /// <br>Date             :   2009/12/02</br>
    /// <br></br>
    /// <br>Update Note      :   オンライン種別区分 追加</br>
    /// <br>Programmer       :   21024 佐々木 健</br>
    /// <br>Date             :   2010/04/06 </br>
    /// <br></br>
    /// <br>Update Note      :   簡単問合せアカウントグループID 追加</br>
    /// <br>Programmer       :   22008 長内 数馬</br>
    /// <br>Date             :   2010/06/25 </br>
	/// <br></br>
	/// <br>Update Note      :   顧客担当従業員名称 追加</br>
	/// <br>Programmer       :   22024 寺坂 誉志</br>
	/// <br>Date             :   2012.04.10</br>
	/// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustomerSearchRetWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先サブコード</summary>
        private string _customerSubCode = "";

        /// <summary>名称</summary>
        private string _name = "";

        /// <summary>名称２</summary>
        private string _name2 = "";

        /// <summary>カナ</summary>
        private string _kana = "";

        /// <summary>敬称</summary>
        private string _honorificTitle = "";

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>電話番号（検索用下4桁）</summary>
        private string _searchTelNo = "";

        /// <summary>電話番号（自宅）</summary>
        /// <remarks>ハイフンを含めた16桁の番号</remarks>
        private string _homeTelNo = "";

        /// <summary>電話番号（勤務先）</summary>
        private string _officeTelNo = "";

        /// <summary>電話番号（携帯）</summary>
        private string _portableTelNo = "";

        /// <summary>郵便番号</summary>
        private string _postNo = "";

        /// <summary>住所１（都道府県市区郡・町村・字）</summary>
        private string _address1 = "";

        /// <summary>住所３（番地）</summary>
        private string _address3 = "";

        /// <summary>住所４（アパート名称）</summary>
        private string _address4 = "";

        /// <summary>締日</summary>
        /// <remarks>DD</remarks>
        private Int32 _totalDay;

        /// <summary>得意先論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>仕入先区分</summary>
        /// <remarks>0:仕入先以外,1:仕入先</remarks>
        private Int32 _supplierDiv;

        /// <summary>業販先区分</summary>
        /// <remarks>0:業販先以外,1:業販先</remarks>
        private Int32 _acceptWholeSale;

        /// <summary>管理拠点コード</summary>
        private string _mngSectionCode = "";

        // --- ADD 2008/09/05 ---------->>>>>
        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;
        // --- ADD 2008/09/05 ----------<<<<<

        // ADD 2009.02.10 >>>
        /// <summary>得意先伝票番号区分</summary>
        /// <remarks>0:使用しない,1:連番,2:締毎,3:期末</remarks>
        private Int32 _customerSlipNoDiv;
        // ADD 2009.02.10 <<<

        // ADD 2009.06.09 >>>
        /// <summary>得意先企業コード</summary>
        /// <remarks>システム連動可能な場合のみ登録される</remarks>
        private string _customerEpCode = "";

        /// <summary>得意先拠点コード</summary>
        /// <remarks>システム連動可能な場合のみ登録される</remarks>
        private string _customerSecCode = "";
        // ADD 2009.06.09 <<<

        // ADD 2009.06.16 >>>
        /// <summary>顧客担当従業員コード</summary>
        /// <remarks>文字型</remarks>
        private string _customerAgentCd = "";
        // ADD 2009.06.16 <<<

////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
        /// <summary>顧客担当従業員名称</summary>
        /// <remarks>文字型</remarks>
        private string _customerAgentNm = "";
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////

        // 2009/12/02 Add >>>
        /// <summary>FAX番号（携帯）</summary>
        private string _homeFaxNo = "";

        /// <summary>FAX番号（勤務先）</summary>
        private string _officeFaxNo = "";
        // 2009/12/02 Add <<<

        // 2010/04/06 Add >>>
        /// <summary>オンライン種別区分</summary>
        /// <remarks>0:なし 10:SCM、20:TSP.NS、30:TSP.NSインライン、40:TSPメール</remarks>
        private Int32 _onlineKindDiv;
        // 2010/04/06 Add <<<

        // 2010/06/25 Add >>>
        /// <summary>簡単問合せアカウントグループID</summary>
        private string _simplInqAcntAcntGrId = "";
        // 2010/06/25 Add <<<
        

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

        /// public propaty name  :  CustomerSubCode
        /// <summary>得意先サブコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先サブコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSubCode
        {
            get { return _customerSubCode; }
            set { _customerSubCode = value; }
        }

        /// public propaty name  :  Name
        /// <summary>名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// public propaty name  :  Name2
        /// <summary>名称２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   名称２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Name2
        {
            get { return _name2; }
            set { _name2 = value; }
        }

        /// public propaty name  :  Kana
        /// <summary>カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Kana
        {
            get { return _kana; }
            set { _kana = value; }
        }

        /// public propaty name  :  HonorificTitle
        /// <summary>敬称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   敬称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HonorificTitle
        {
            get { return _honorificTitle; }
            set { _honorificTitle = value; }
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

        /// public propaty name  :  SearchTelNo
        /// <summary>電話番号（検索用下4桁）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号（検索用下4桁）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchTelNo
        {
            get { return _searchTelNo; }
            set { _searchTelNo = value; }
        }

        /// public propaty name  :  HomeTelNo
        /// <summary>電話番号（自宅）プロパティ</summary>
        /// <value>ハイフンを含めた16桁の番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号（自宅）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HomeTelNo
        {
            get { return _homeTelNo; }
            set { _homeTelNo = value; }
        }

        /// public propaty name  :  OfficeTelNo
        /// <summary>電話番号（勤務先）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号（勤務先）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OfficeTelNo
        {
            get { return _officeTelNo; }
            set { _officeTelNo = value; }
        }

        /// public propaty name  :  PortableTelNo
        /// <summary>電話番号（携帯）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号（携帯）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PortableTelNo
        {
            get { return _portableTelNo; }
            set { _portableTelNo = value; }
        }

        /// public propaty name  :  PostNo
        /// <summary>郵便番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   郵便番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PostNo
        {
            get { return _postNo; }
            set { _postNo = value; }
        }

        /// public propaty name  :  Address1
        /// <summary>住所１（都道府県市区郡・町村・字）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所１（都道府県市区郡・町村・字）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }

        /// public propaty name  :  Address3
        /// <summary>住所３（番地）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所３（番地）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Address3
        {
            get { return _address3; }
            set { _address3 = value; }
        }

        /// public propaty name  :  Address4
        /// <summary>住所４（アパート名称）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所４（アパート名称）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Address4
        {
            get { return _address4; }
            set { _address4 = value; }
        }

        /// public propaty name  :  TotalDay
        /// <summary>締日プロパティ</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalDay
        {
            get { return _totalDay; }
            set { _totalDay = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>得意先論理削除区分プロパティ</summary>
        /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先論理削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  SupplierDiv
        /// <summary>仕入先区分プロパティ</summary>
        /// <value>0:仕入先以外,1:仕入先</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierDiv
        {
            get { return _supplierDiv; }
            set { _supplierDiv = value; }
        }

        /// public propaty name  :  AcceptWholeSale
        /// <summary>業販先区分プロパティ</summary>
        /// <value>0:業販先以外,1:業販先</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業販先区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcceptWholeSale
        {
            get { return _acceptWholeSale; }
            set { _acceptWholeSale = value; }
        }

        /// public propaty name  :  MngSectionCode
        /// <summary>管理拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   管理拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MngSectionCode
        {
            get { return _mngSectionCode; }
            set { _mngSectionCode = value; }
        }

        // --- ADD 2008/09/05 ---------->>>>>
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
        // --- ADD 2008/09/05 ----------<<<<<

        // ADD 2009.02.10 >>>
        /// public propaty name  :  CustomerSlipNoDiv
        /// <summary>得意先伝票番号区分プロパティ</summary>
        /// <value>0:使用しない,1:連番,2:締毎,3:期末</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先伝票番号区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerSlipNoDiv
        {
            get { return _customerSlipNoDiv; }
            set { _customerSlipNoDiv = value; }
        }
        // ADD 2009.02.10 <<<

        /// public propaty name  :  CustomerEpCode
        /// <summary>得意先企業コードプロパティ</summary>
        /// <value>システム連動可能な場合のみ登録される</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerEpCode
        {
            get { return _customerEpCode; }
            set { _customerEpCode = value; }
        }

        /// public propaty name  :  CustomerSecCode
        /// <summary>得意先拠点コードプロパティ</summary>
        /// <value>システム連動可能な場合のみ登録される</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSecCode
        {
            get { return _customerSecCode; }
            set { _customerSecCode = value; }
        }

        /// public propaty name  :  CustomerAgentCd
        /// <summary>顧客担当従業員コードプロパティ</summary>
        /// <value>文字型</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   顧客担当従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerAgentCd
        {
            get { return _customerAgentCd; }
            set { _customerAgentCd = value; }
        }

////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
        /// public propaty name  :  CustomerAgentNm
        /// <summary>顧客担当従業員名称プロパティ</summary>
        /// <value>文字型</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   顧客担当従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerAgentNm
        {
            get { return _customerAgentNm; }
            set { _customerAgentNm = value; }
        }
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////

        // 2009/12/02 Add >>>
        /// public propaty name  :  HomeFaxNo
        /// <summary>FAX番号（自宅）プロパティ</summary>
        /// <value>ハイフンを含めた16桁の番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FAX番号（自宅）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HomeFaxNo
        {
            get { return _homeFaxNo; }
            set { _homeFaxNo = value; }
        }

        /// public propaty name  :  OfficeFaxNo
        /// <summary>FAX番号（勤務先）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FAX番号（勤務先）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OfficeFaxNo
        {
            get { return _officeFaxNo; }
            set { _officeFaxNo = value; }
        }
         //2009/12/02 Add <<<

        // 2010/04/06 Add >>>
        /// public propaty name  :  OnlineKindDiv
        /// <summary>オンライン種別区分プロパティ</summary>
        /// <value>0:なし 10:SCM、20:TSP.NS、30:TSP.NSインライン、40:TSPメール</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オンライン種別区分プロパティ</br>
        /// <br>Programer        :   21024 佐々木 健</br>
        /// </remarks>
        public Int32 OnlineKindDiv
        {
            get { return _onlineKindDiv; }
            set { _onlineKindDiv = value; }
        }
        // 2010/04/06 Add <<<

        //2010/06/25 Add >>>
        /// public propaty name  :  SimplInqAcntAcntGrId
        /// <summary>簡単問合せアカウントグループID）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   簡単問合せアカウントグループIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SimplInqAcntAcntGrId
        {
            get { return _simplInqAcntAcntGrId; }
            set { _simplInqAcntAcntGrId = value; }
        }
        //2009/06/25 Add <<<

        /// <summary>
        /// 得意先検索結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>CustomerSearchRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerSearchRetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustomerSearchRetWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CustomerSearchRetWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CustomerSearchRetWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class CustomerSearchRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerSearchRetWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CustomerSearchRetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CustomerSearchRetWork || graph is ArrayList || graph is CustomerSearchRetWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CustomerSearchRetWork).FullName));

            if (graph != null && graph is CustomerSearchRetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustomerSearchRetWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CustomerSearchRetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CustomerSearchRetWork[])graph).Length;
            }
            else if (graph is CustomerSearchRetWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先サブコード
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSubCode
            //名称
            serInfo.MemberInfo.Add(typeof(string)); //Name
            //名称２
            serInfo.MemberInfo.Add(typeof(string)); //Name2
            //カナ
            serInfo.MemberInfo.Add(typeof(string)); //Kana
            //敬称
            serInfo.MemberInfo.Add(typeof(string)); //HonorificTitle
            //得意先略称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //電話番号（検索用下4桁）
            serInfo.MemberInfo.Add(typeof(string)); //SearchTelNo
            //電話番号（自宅）
            serInfo.MemberInfo.Add(typeof(string)); //HomeTelNo
            //電話番号（勤務先）
            serInfo.MemberInfo.Add(typeof(string)); //OfficeTelNo
            //電話番号（携帯）
            serInfo.MemberInfo.Add(typeof(string)); //PortableTelNo
            //郵便番号
            serInfo.MemberInfo.Add(typeof(string)); //PostNo
            //住所１（都道府県市区郡・町村・字）
            serInfo.MemberInfo.Add(typeof(string)); //Address1
            //住所３（番地）
            serInfo.MemberInfo.Add(typeof(string)); //Address3
            //住所４（アパート名称）
            serInfo.MemberInfo.Add(typeof(string)); //Address4
            //締日
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalDay
            //得意先論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //仕入先区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierDiv
            //業販先区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AcceptWholeSale
            //管理拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //MngSectionCode
            // --- ADD 2008/09/05 ---------->>>>>
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            // --- ADD 2008/09/05 ----------<<<<<
            // ADD 2009.02.10 >>>
            //得意先伝票番号区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerSlipNoDiv
            // ADD 2009.02.10 <<<
            //得意先企業コード
            serInfo.MemberInfo.Add(typeof(string)); //CustomerEpCode
            //得意先拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSecCode
            //顧客担当従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //CustomerAgentCd
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
            //顧客担当従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerAgentNm
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////

            // 2009/12/02 Add >>>
            //FAX番号（自宅）
            serInfo.MemberInfo.Add(typeof(string)); //HomeFaxNo
            //FAX番号（勤務先）
            serInfo.MemberInfo.Add(typeof(string)); //OfficeFaxNo
            // 2009/12/02 Add <<<

            // 2010/04/06 Add >>>
            serInfo.MemberInfo.Add(typeof(Int32));  //OnlineKindDiv
            // 2010/04/05 Add <<<

            // 2010/06/25 Add >>>
            serInfo.MemberInfo.Add(typeof(string));  //SimplInqAcntAcntGrId
            // 2010/06/25 Add <<<

            serInfo.Serialize(writer, serInfo);
            if (graph is CustomerSearchRetWork)
            {
                CustomerSearchRetWork temp = (CustomerSearchRetWork)graph;

                SetCustomerSearchRetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CustomerSearchRetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CustomerSearchRetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CustomerSearchRetWork temp in lst)
                {
                    SetCustomerSearchRetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CustomerSearchRetWorkメンバ数(publicプロパティ数)
        /// </summary>
		#region 2012.04.10 TERASAKA DEL STA
//        // 2010/06/25 >>>
//        //// 2010/04/06 >>>
//        ////// 2009/12/02 >>>
//        //////private const int currentMemberCount = 26;
//        ////private const int currentMemberCount = 28;
//        ////// 2009/12/02 <<<
//
//        //private const int currentMemberCount = 29;
//        //// 2010/04/06 <<<
//
//        private const int currentMemberCount = 30;
//        // 2010/06/25 <<<
		#endregion
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
        private const int currentMemberCount = 31;
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////
        
        /// <summary>
        ///  CustomerSearchRetWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerSearchRetWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetCustomerSearchRetWork(System.IO.BinaryWriter writer, CustomerSearchRetWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先サブコード
            writer.Write(temp.CustomerSubCode);
            //名称
            writer.Write(temp.Name);
            //名称２
            writer.Write(temp.Name2);
            //カナ
            writer.Write(temp.Kana);
            //敬称
            writer.Write(temp.HonorificTitle);
            //得意先略称
            writer.Write(temp.CustomerSnm);
            //電話番号（検索用下4桁）
            writer.Write(temp.SearchTelNo);
            //電話番号（自宅）
            writer.Write(temp.HomeTelNo);
            //電話番号（勤務先）
            writer.Write(temp.OfficeTelNo);
            //電話番号（携帯）
            writer.Write(temp.PortableTelNo);
            //郵便番号
            writer.Write(temp.PostNo);
            //住所１（都道府県市区郡・町村・字）
            writer.Write(temp.Address1);
            //住所３（番地）
            writer.Write(temp.Address3);
            //住所４（アパート名称）
            writer.Write(temp.Address4);
            //締日
            writer.Write(temp.TotalDay);
            //得意先論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //仕入先区分
            writer.Write(temp.SupplierDiv);
            //業販先区分
            writer.Write(temp.AcceptWholeSale);
            //管理拠点コード
            writer.Write(temp.MngSectionCode);
            // --- ADD 2008/09/05 ---------->>>>>
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            // --- ADD 2008/09/05 ----------<<<<<
            // ADD 2009.02.10 >>>
            //得意先伝票番号区分
            writer.Write(temp.CustomerSlipNoDiv);
            // ADD 2009.02.10 <<<
            //得意先企業コード
            writer.Write(temp.CustomerEpCode);
            //得意先拠点コード
            writer.Write(temp.CustomerSecCode);
            //顧客担当従業員コード
            writer.Write(temp.CustomerAgentCd);
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
            //顧客担当従業員名称
            writer.Write(temp.CustomerAgentNm);
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////

            // 2009/12/02 Add >>>
            //FAX番号（自宅）
            writer.Write(temp.HomeFaxNo);
            //FAX番号（勤務先）
            writer.Write(temp.OfficeFaxNo);
            // 2009/12/02 Add <<<

            // 2010/04/06 Add >>>
            //オンライン種別区分
            writer.Write(temp.OnlineKindDiv);
            // 2010/04/06 Add <<<
            // 2010/06/25 Add >>>
            //簡単問合せアカウントグループID
            writer.Write(temp.SimplInqAcntAcntGrId);
            // 2010/06/25 Add <<<
        }

        /// <summary>
        ///  CustomerSearchRetWorkインスタンス取得
        /// </summary>
        /// <returns>CustomerSearchRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerSearchRetWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private CustomerSearchRetWork GetCustomerSearchRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            CustomerSearchRetWork temp = new CustomerSearchRetWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先サブコード
            temp.CustomerSubCode = reader.ReadString();
            //名称
            temp.Name = reader.ReadString();
            //名称２
            temp.Name2 = reader.ReadString();
            //カナ
            temp.Kana = reader.ReadString();
            //敬称
            temp.HonorificTitle = reader.ReadString();
            //得意先略称
            temp.CustomerSnm = reader.ReadString();
            //電話番号（検索用下4桁）
            temp.SearchTelNo = reader.ReadString();
            //電話番号（自宅）
            temp.HomeTelNo = reader.ReadString();
            //電話番号（勤務先）
            temp.OfficeTelNo = reader.ReadString();
            //電話番号（携帯）
            temp.PortableTelNo = reader.ReadString();
            //郵便番号
            temp.PostNo = reader.ReadString();
            //住所１（都道府県市区郡・町村・字）
            temp.Address1 = reader.ReadString();
            //住所３（番地）
            temp.Address3 = reader.ReadString();
            //住所４（アパート名称）
            temp.Address4 = reader.ReadString();
            //締日
            temp.TotalDay = reader.ReadInt32();
            //得意先論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //仕入先区分
            temp.SupplierDiv = reader.ReadInt32();
            //業販先区分
            temp.AcceptWholeSale = reader.ReadInt32();
            //管理拠点コード
            temp.MngSectionCode = reader.ReadString();
            // --- ADD 2008/09/05 ---------->>>>>
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            // --- ADD 2008/09/05 ----------<<<<<
            // ADD 2009.02.10 >>>
            //得意先伝票番号区分
            temp.CustomerSlipNoDiv = reader.ReadInt32();
            // ADD 2009.02.10 <<<
            //得意先企業コード
            temp.CustomerEpCode = reader.ReadString();
            //得意先拠点コード
            temp.CustomerSecCode = reader.ReadString();
            //顧客担当従業員コード
            temp.CustomerAgentCd = reader.ReadString();
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
            //顧客担当従業員名称
            temp.CustomerAgentNm = reader.ReadString();
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////

            // 2009/12/02 Add >>>
            //FAX番号（自宅）
            temp.HomeFaxNo = reader.ReadString();
            //FAX番号（勤務先）
            temp.OfficeFaxNo = reader.ReadString();
            // 2009/12/02 Add <<<

            // 2010/04/05 Add >>>
            // オンライン種別区分
            temp.OnlineKindDiv = reader.ReadInt32();
            // 2010/04/06 Add <<<
            // 2010/06/25 Add >>>
            // 簡単問合せアカウントグループID
            temp.SimplInqAcntAcntGrId = reader.ReadString();
            // 2010/06/26 Add <<<

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
        /// <returns>CustomerSearchRetWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerSearchRetWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CustomerSearchRetWork temp = GetCustomerSearchRetWork(reader, serInfo);
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
                    retValue = (CustomerSearchRetWork[])lst.ToArray(typeof(CustomerSearchRetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
