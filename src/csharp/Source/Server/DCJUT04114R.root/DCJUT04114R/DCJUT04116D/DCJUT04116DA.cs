using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   AcptAnOdrRemainRefCndtnWork
    /// <summary>
    ///                      受注残照会抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   受注残照会抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/07/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class AcptAnOdrRemainRefCndtnWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>請求先コード</summary>
        private Int32 _claimCode;

        /// <summary>受注状況区分</summary>
        /// <remarks>0:全て／1:計上済み分／2:未計上分</remarks>
        private Int32 _acpOdrStateDiv;

        /// <summary>型式</summary>
        /// <remarks>(あいまい検索)</remarks>
        private string _fullModel = "";

        /// <summary>伝票検索日付（開始）</summary>
        /// <remarks>入力日</remarks>
        private DateTime _st_SearchSlipDate;

        /// <summary>伝票検索日付（終了）</summary>
        /// <remarks>入力日</remarks>
        private DateTime _ed_SearchSlipDate;

        /// <summary>売上日付(開始)</summary>
        /// <remarks>受注日</remarks>
        private DateTime _st_SalesDate;

        /// <summary>売上日付(終了)</summary>
        /// <remarks>受注日</remarks>
        private DateTime _ed_SalesDate;

        /// <summary>売上伝票番号（開始）</summary>
        private string _st_SalesSlipNum = "";

        /// <summary>売上伝票番号（終了）</summary>
        private string _ed_SalesSlipNum = "";

        /// <summary>売上入力者コード</summary>
        /// <remarks>入力担当者</remarks>
        private string _salesInputCode = "";

        /// <summary>受付従業員コード</summary>
        /// <remarks>受注担当者</remarks>
        private string _frontEmployeeCd = "";

        /// <summary>販売従業員コード</summary>
        /// <remarks>売上担当者</remarks>
        private string _salesEmployeeCd = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>品番</summary>
        private string _goodsNo = "";

        /// <summary>品名</summary>
        private string _goodsName = "";

        /// <summary>品名検索タイプ</summary>
        /// <remarks>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</remarks>
        private Int32 _goodsNameSrchTyp;

        /// <summary>品番検索タイプ</summary>
        /// <remarks>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</remarks>
        private Int32 _goodsNoSrchTyp;

        /// <summary>型式検索タイプ</summary>
        /// <remarks>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</remarks>
        private Int32 _fullModelSrchTyp;

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

        /// public propaty name  :  AcpOdrStateDiv
        /// <summary>受注状況区分プロパティ</summary>
        /// <value>0:全て／1:計上済み分／2:未計上分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注状況区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcpOdrStateDiv
        {
            get { return _acpOdrStateDiv; }
            set { _acpOdrStateDiv = value; }
        }

        /// public propaty name  :  FullModel
        /// <summary>型式プロパティ</summary>
        /// <value>(あいまい検索)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FullModel
        {
            get { return _fullModel; }
            set { _fullModel = value; }
        }

        /// public propaty name  :  St_SearchSlipDate
        /// <summary>伝票検索日付（開始）プロパティ</summary>
        /// <value>入力日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_SearchSlipDate
        {
            get { return _st_SearchSlipDate; }
            set { _st_SearchSlipDate = value; }
        }

        /// public propaty name  :  Ed_SearchSlipDate
        /// <summary>伝票検索日付（終了）プロパティ</summary>
        /// <value>入力日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_SearchSlipDate
        {
            get { return _ed_SearchSlipDate; }
            set { _ed_SearchSlipDate = value; }
        }

        /// public propaty name  :  St_SalesDate
        /// <summary>売上日付(開始)プロパティ</summary>
        /// <value>受注日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_SalesDate
        {
            get { return _st_SalesDate; }
            set { _st_SalesDate = value; }
        }

        /// public propaty name  :  Ed_SalesDate
        /// <summary>売上日付(終了)プロパティ</summary>
        /// <value>受注日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_SalesDate
        {
            get { return _ed_SalesDate; }
            set { _ed_SalesDate = value; }
        }

        /// public propaty name  :  St_SalesSlipNum
        /// <summary>売上伝票番号（開始）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_SalesSlipNum
        {
            get { return _st_SalesSlipNum; }
            set { _st_SalesSlipNum = value; }
        }

        /// public propaty name  :  Ed_SalesSlipNum
        /// <summary>売上伝票番号（終了）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_SalesSlipNum
        {
            get { return _ed_SalesSlipNum; }
            set { _ed_SalesSlipNum = value; }
        }

        /// public propaty name  :  SalesInputCode
        /// <summary>売上入力者コードプロパティ</summary>
        /// <value>入力担当者</value>
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

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>受付従業員コードプロパティ</summary>
        /// <value>受注担当者</value>
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
        /// <value>売上担当者</value>
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

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
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
        /// <summary>品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>品名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  GoodsNameSrchTyp
        /// <summary>品名検索タイププロパティ</summary>
        /// <value>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品名検索タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsNameSrchTyp
        {
            get { return _goodsNameSrchTyp; }
            set { _goodsNameSrchTyp = value; }
        }

        /// public propaty name  :  GoodsNoSrchTyp
        /// <summary>品番検索タイププロパティ</summary>
        /// <value>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番検索タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsNoSrchTyp
        {
            get { return _goodsNoSrchTyp; }
            set { _goodsNoSrchTyp = value; }
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

        /// <summary>
        /// 受注残照会抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>AcptAnOdrRemainRefCndtnWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcptAnOdrRemainRefCndtnWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AcptAnOdrRemainRefCndtnWork()
        {
        }

    }

}
