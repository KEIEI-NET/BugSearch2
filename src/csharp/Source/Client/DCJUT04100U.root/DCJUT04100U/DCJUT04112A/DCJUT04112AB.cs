using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   AcptAnOdrRemainRefCndtn
    /// <summary>
    ///                      受注残照会抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   受注残照会抽出条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/08/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class AcptAnOdrRemainRefCndtn
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
        private Int32 _st_SearchSlipDate;

        /// <summary>伝票検索日付（終了）</summary>
        /// <remarks>入力日</remarks>
        private Int32 _ed_SearchSlipDate;

        /// <summary>売上日付(開始)</summary>
        /// <remarks>受注日</remarks>
        private Int32 _st_SalesDate;

        /// <summary>売上日付(終了)</summary>
        /// <remarks>受注日</remarks>
        private Int32 _ed_SalesDate;

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

        /// <summary>品番曖昧検索</summary>
        private Int32 _goodsNoSrchTyp;

        /// <summary>品名</summary>
        /// <remarks>(あいまい検索)</remarks>
        private string _goodsName = "";

        /// <summary>商品名称曖昧検索フラグ</summary>
        private Int32 _goodsNmVagueSrch;

        /// <summary>型式曖昧検索</summary>
        private Int32 _fullModelSrchTyp;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>販売従業員名称</summary>
        private string _salesEmployeeNm = "";


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

        /// public propaty name  :  FullModelSrchTyp
        /// <summary>型式曖昧検索プロパティ</summary>
        /// <value>(あいまい検索)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式曖昧検索プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FullModelSrchTyp
        {
            get { return _fullModelSrchTyp; }
            set { _fullModelSrchTyp = value; }
        }

        /// public propaty name  :  St_SearchSlipDate
        /// <summary>伝票検索日付（開始）プロパティ</summary>
        /// <value>入力日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_SearchSlipDate
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
        public Int32 Ed_SearchSlipDate
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
        public Int32 St_SalesDate
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
        public Int32 Ed_SalesDate
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

        /// public propaty name  :  GoodsNoSrchTyp
        /// <summary>品番曖昧検索</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番曖昧検索</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsNoSrchTyp
        {
            get { return _goodsNoSrchTyp; }
            set { _goodsNoSrchTyp = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>品名プロパティ</summary>
        /// <value>(あいまい検索)</value>
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

        /// public propaty name  :  GoodsNmVagueSrch
        /// <summary>商品名称曖昧検索フラグプロパティ</summary>
        /// <value>True:曖昧検索　False:通常検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称曖昧検索フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsNmVagueSrch
        {
            get { return _goodsNmVagueSrch; }
            set { _goodsNmVagueSrch = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  SalesEmployeeNm
        /// <summary>販売従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesEmployeeNm
        {
            get { return _salesEmployeeNm; }
            set { _salesEmployeeNm = value; }
        }


        /// <summary>
        /// 受注残照会抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>AcptAnOdrRemainRefCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcptAnOdrRemainRefCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AcptAnOdrRemainRefCndtn()
        {
        }

        /// <summary>
        /// 受注残照会抽出条件クラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="claimCode">請求先コード</param>
        /// <param name="acpOdrStateDiv">受注状況区分(0:全て／1:計上済み分／2:未計上分)</param>
        /// <param name="fullModel">型式((あいまい検索))</param>
        /// <param name="st_SearchSlipDate">伝票検索日付（開始）(入力日)</param>
        /// <param name="ed_SearchSlipDate">伝票検索日付（終了）(入力日)</param>
        /// <param name="st_SalesDate">売上日付(開始)(受注日)</param>
        /// <param name="ed_SalesDate">売上日付(終了)(受注日)</param>
        /// <param name="st_SalesSlipNum">売上伝票番号（開始）</param>
        /// <param name="ed_SalesSlipNum">売上伝票番号（終了）</param>
        /// <param name="salesInputCode">売上入力者コード(入力担当者)</param>
        /// <param name="frontEmployeeCd">受付従業員コード(受注担当者)</param>
        /// <param name="salesEmployeeCd">販売従業員コード(売上担当者)</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="goodsNoSrchTyp">品番曖昧検索</param>
        /// <param name="goodsName">品名((あいまい検索))</param>
        /// <param name="goodsNmVagueSrch">商品名称曖昧検索フラグ</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="salesEmployeeNm">販売従業員名称</param>
        /// <param name="fullModelSrchTyp">型式曖昧検索フラグ</param>
        /// <returns>AcptAnOdrRemainRefCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcptAnOdrRemainRefCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AcptAnOdrRemainRefCndtn(string enterpriseCode, string sectionCode, Int32 customerCode, Int32 claimCode, Int32 acpOdrStateDiv, string fullModel, Int32 st_SearchSlipDate, Int32 ed_SearchSlipDate, Int32 st_SalesDate, Int32 ed_SalesDate, string st_SalesSlipNum, string ed_SalesSlipNum, string salesInputCode, string frontEmployeeCd, string salesEmployeeCd, Int32 goodsMakerCd, string goodsNo, Int32 goodsNoSrchTyp, string goodsName, Int32 goodsNmVagueSrch, string enterpriseName, string salesEmployeeNm, Int32 fullModelSrchTyp)
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._customerCode = customerCode;
            this._claimCode = claimCode;
            this._acpOdrStateDiv = acpOdrStateDiv;
            this._fullModel = fullModel;
            this._st_SearchSlipDate = st_SearchSlipDate;
            this._ed_SearchSlipDate = ed_SearchSlipDate;
            this._st_SalesDate = st_SalesDate;
            this._ed_SalesDate = ed_SalesDate;
            this._st_SalesSlipNum = st_SalesSlipNum;
            this._ed_SalesSlipNum = ed_SalesSlipNum;
            this._salesInputCode = salesInputCode;
            this._frontEmployeeCd = frontEmployeeCd;
            this._salesEmployeeCd = salesEmployeeCd;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsNo = goodsNo;
            this._goodsNoSrchTyp = goodsNoSrchTyp;
            this._goodsName = goodsName;
            this._goodsNmVagueSrch = goodsNmVagueSrch;
            this._enterpriseName = enterpriseName;
            this._salesEmployeeNm = salesEmployeeNm;
            this._fullModelSrchTyp = fullModelSrchTyp;

        }

        /// <summary>
        /// 受注残照会抽出条件クラス複製処理
        /// </summary>
        /// <returns>AcptAnOdrRemainRefCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいAcptAnOdrRemainRefCndtnクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AcptAnOdrRemainRefCndtn Clone()
        {
            return new AcptAnOdrRemainRefCndtn(this._enterpriseCode, this._sectionCode, this._customerCode, this._claimCode, this._acpOdrStateDiv, this._fullModel, this._st_SearchSlipDate, this._ed_SearchSlipDate, this._st_SalesDate, this._ed_SalesDate, this._st_SalesSlipNum, this._ed_SalesSlipNum, this._salesInputCode, this._frontEmployeeCd, this._salesEmployeeCd, this._goodsMakerCd, this._goodsNo, this._goodsNoSrchTyp, this._goodsName, this._goodsNmVagueSrch, this._enterpriseName, this._salesEmployeeNm, this._fullModelSrchTyp);
        }

        /// <summary>
        /// 受注残照会抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のAcptAnOdrRemainRefCndtnクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcptAnOdrRemainRefCndtnクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(AcptAnOdrRemainRefCndtn target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.ClaimCode == target.ClaimCode)
                 && (this.AcpOdrStateDiv == target.AcpOdrStateDiv)
                 && (this.FullModel == target.FullModel)
                 && (this.St_SearchSlipDate == target.St_SearchSlipDate)
                 && (this.Ed_SearchSlipDate == target.Ed_SearchSlipDate)
                 && (this.St_SalesDate == target.St_SalesDate)
                 && (this.Ed_SalesDate == target.Ed_SalesDate)
                 && (this.St_SalesSlipNum == target.St_SalesSlipNum)
                 && (this.Ed_SalesSlipNum == target.Ed_SalesSlipNum)
                 && (this.SalesInputCode == target.SalesInputCode)
                 && (this.FrontEmployeeCd == target.FrontEmployeeCd)
                 && (this.SalesEmployeeCd == target.SalesEmployeeCd)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsNoSrchTyp == target.GoodsNoSrchTyp)
                 && (this.GoodsName == target.GoodsName)
                 && (this.GoodsNmVagueSrch == target.GoodsNmVagueSrch)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.SalesEmployeeNm == target.SalesEmployeeNm)
                 && (this.FullModelSrchTyp == target.FullModelSrchTyp));
        }

        /// <summary>
        /// 受注残照会抽出条件クラス比較処理
        /// </summary>
        /// <param name="acptAnOdrRemainRefCndtn1">
        ///                    比較するAcptAnOdrRemainRefCndtnクラスのインスタンス
        /// </param>
        /// <param name="acptAnOdrRemainRefCndtn2">比較するAcptAnOdrRemainRefCndtnクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcptAnOdrRemainRefCndtnクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(AcptAnOdrRemainRefCndtn acptAnOdrRemainRefCndtn1, AcptAnOdrRemainRefCndtn acptAnOdrRemainRefCndtn2)
        {
            return ((acptAnOdrRemainRefCndtn1.EnterpriseCode == acptAnOdrRemainRefCndtn2.EnterpriseCode)
                 && (acptAnOdrRemainRefCndtn1.SectionCode == acptAnOdrRemainRefCndtn2.SectionCode)
                 && (acptAnOdrRemainRefCndtn1.CustomerCode == acptAnOdrRemainRefCndtn2.CustomerCode)
                 && (acptAnOdrRemainRefCndtn1.ClaimCode == acptAnOdrRemainRefCndtn2.ClaimCode)
                 && (acptAnOdrRemainRefCndtn1.AcpOdrStateDiv == acptAnOdrRemainRefCndtn2.AcpOdrStateDiv)
                 && (acptAnOdrRemainRefCndtn1.FullModel == acptAnOdrRemainRefCndtn2.FullModel)
                 && (acptAnOdrRemainRefCndtn1.St_SearchSlipDate == acptAnOdrRemainRefCndtn2.St_SearchSlipDate)
                 && (acptAnOdrRemainRefCndtn1.Ed_SearchSlipDate == acptAnOdrRemainRefCndtn2.Ed_SearchSlipDate)
                 && (acptAnOdrRemainRefCndtn1.St_SalesDate == acptAnOdrRemainRefCndtn2.St_SalesDate)
                 && (acptAnOdrRemainRefCndtn1.Ed_SalesDate == acptAnOdrRemainRefCndtn2.Ed_SalesDate)
                 && (acptAnOdrRemainRefCndtn1.St_SalesSlipNum == acptAnOdrRemainRefCndtn2.St_SalesSlipNum)
                 && (acptAnOdrRemainRefCndtn1.Ed_SalesSlipNum == acptAnOdrRemainRefCndtn2.Ed_SalesSlipNum)
                 && (acptAnOdrRemainRefCndtn1.SalesInputCode == acptAnOdrRemainRefCndtn2.SalesInputCode)
                 && (acptAnOdrRemainRefCndtn1.FrontEmployeeCd == acptAnOdrRemainRefCndtn2.FrontEmployeeCd)
                 && (acptAnOdrRemainRefCndtn1.SalesEmployeeCd == acptAnOdrRemainRefCndtn2.SalesEmployeeCd)
                 && (acptAnOdrRemainRefCndtn1.GoodsMakerCd == acptAnOdrRemainRefCndtn2.GoodsMakerCd)
                 && (acptAnOdrRemainRefCndtn1.GoodsNo == acptAnOdrRemainRefCndtn2.GoodsNo)
                 && (acptAnOdrRemainRefCndtn1.GoodsNoSrchTyp == acptAnOdrRemainRefCndtn2.GoodsNoSrchTyp)
                 && (acptAnOdrRemainRefCndtn1.GoodsName == acptAnOdrRemainRefCndtn2.GoodsName)
                 && (acptAnOdrRemainRefCndtn1.GoodsNmVagueSrch == acptAnOdrRemainRefCndtn2.GoodsNmVagueSrch)
                 && (acptAnOdrRemainRefCndtn1.EnterpriseName == acptAnOdrRemainRefCndtn2.EnterpriseName)
                 && (acptAnOdrRemainRefCndtn1.SalesEmployeeNm == acptAnOdrRemainRefCndtn2.SalesEmployeeNm)
                 && (acptAnOdrRemainRefCndtn1.FullModelSrchTyp == acptAnOdrRemainRefCndtn2.FullModelSrchTyp));
        }
        /// <summary>
        /// 受注残照会抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のAcptAnOdrRemainRefCndtnクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcptAnOdrRemainRefCndtnクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(AcptAnOdrRemainRefCndtn target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.ClaimCode != target.ClaimCode) resList.Add("ClaimCode");
            if (this.AcpOdrStateDiv != target.AcpOdrStateDiv) resList.Add("AcpOdrStateDiv");
            if (this.FullModel != target.FullModel) resList.Add("FullModel");
            if (this.St_SearchSlipDate != target.St_SearchSlipDate) resList.Add("St_SearchSlipDate");
            if (this.Ed_SearchSlipDate != target.Ed_SearchSlipDate) resList.Add("Ed_SearchSlipDate");
            if (this.St_SalesDate != target.St_SalesDate) resList.Add("St_SalesDate");
            if (this.Ed_SalesDate != target.Ed_SalesDate) resList.Add("Ed_SalesDate");
            if (this.St_SalesSlipNum != target.St_SalesSlipNum) resList.Add("St_SalesSlipNum");
            if (this.Ed_SalesSlipNum != target.Ed_SalesSlipNum) resList.Add("Ed_SalesSlipNum");
            if (this.SalesInputCode != target.SalesInputCode) resList.Add("SalesInputCode");
            if (this.FrontEmployeeCd != target.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (this.SalesEmployeeCd != target.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsNoSrchTyp != target.GoodsNoSrchTyp) resList.Add("GoodsNoSrchTyp");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.GoodsNmVagueSrch != target.GoodsNmVagueSrch) resList.Add("GoodsNmVagueSrch");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.SalesEmployeeNm != target.SalesEmployeeNm) resList.Add("SalesEmployeeNm");
            if (this.FullModelSrchTyp != target.FullModelSrchTyp) resList.Add("FullModelSrchTyp");

            return resList;
        }

        /// <summary>
        /// 受注残照会抽出条件クラス比較処理
        /// </summary>
        /// <param name="acptAnOdrRemainRefCndtn1">比較するAcptAnOdrRemainRefCndtnクラスのインスタンス</param>
        /// <param name="acptAnOdrRemainRefCndtn2">比較するAcptAnOdrRemainRefCndtnクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcptAnOdrRemainRefCndtnクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(AcptAnOdrRemainRefCndtn acptAnOdrRemainRefCndtn1, AcptAnOdrRemainRefCndtn acptAnOdrRemainRefCndtn2)
        {
            ArrayList resList = new ArrayList();
            if (acptAnOdrRemainRefCndtn1.EnterpriseCode != acptAnOdrRemainRefCndtn2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (acptAnOdrRemainRefCndtn1.SectionCode != acptAnOdrRemainRefCndtn2.SectionCode) resList.Add("SectionCode");
            if (acptAnOdrRemainRefCndtn1.CustomerCode != acptAnOdrRemainRefCndtn2.CustomerCode) resList.Add("CustomerCode");
            if (acptAnOdrRemainRefCndtn1.ClaimCode != acptAnOdrRemainRefCndtn2.ClaimCode) resList.Add("ClaimCode");
            if (acptAnOdrRemainRefCndtn1.AcpOdrStateDiv != acptAnOdrRemainRefCndtn2.AcpOdrStateDiv) resList.Add("AcpOdrStateDiv");
            if (acptAnOdrRemainRefCndtn1.FullModel != acptAnOdrRemainRefCndtn2.FullModel) resList.Add("FullModel");
            if (acptAnOdrRemainRefCndtn1.St_SearchSlipDate != acptAnOdrRemainRefCndtn2.St_SearchSlipDate) resList.Add("St_SearchSlipDate");
            if (acptAnOdrRemainRefCndtn1.Ed_SearchSlipDate != acptAnOdrRemainRefCndtn2.Ed_SearchSlipDate) resList.Add("Ed_SearchSlipDate");
            if (acptAnOdrRemainRefCndtn1.St_SalesDate != acptAnOdrRemainRefCndtn2.St_SalesDate) resList.Add("St_SalesDate");
            if (acptAnOdrRemainRefCndtn1.Ed_SalesDate != acptAnOdrRemainRefCndtn2.Ed_SalesDate) resList.Add("Ed_SalesDate");
            if (acptAnOdrRemainRefCndtn1.St_SalesSlipNum != acptAnOdrRemainRefCndtn2.St_SalesSlipNum) resList.Add("St_SalesSlipNum");
            if (acptAnOdrRemainRefCndtn1.Ed_SalesSlipNum != acptAnOdrRemainRefCndtn2.Ed_SalesSlipNum) resList.Add("Ed_SalesSlipNum");
            if (acptAnOdrRemainRefCndtn1.SalesInputCode != acptAnOdrRemainRefCndtn2.SalesInputCode) resList.Add("SalesInputCode");
            if (acptAnOdrRemainRefCndtn1.FrontEmployeeCd != acptAnOdrRemainRefCndtn2.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (acptAnOdrRemainRefCndtn1.SalesEmployeeCd != acptAnOdrRemainRefCndtn2.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (acptAnOdrRemainRefCndtn1.GoodsMakerCd != acptAnOdrRemainRefCndtn2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (acptAnOdrRemainRefCndtn1.GoodsNo != acptAnOdrRemainRefCndtn2.GoodsNo) resList.Add("GoodsNo");
            if (acptAnOdrRemainRefCndtn1.GoodsNoSrchTyp != acptAnOdrRemainRefCndtn2.GoodsNoSrchTyp) resList.Add("GoodsNoSrchTyp");
            if (acptAnOdrRemainRefCndtn1.GoodsName != acptAnOdrRemainRefCndtn2.GoodsName) resList.Add("GoodsName");
            if (acptAnOdrRemainRefCndtn1.GoodsNmVagueSrch != acptAnOdrRemainRefCndtn2.GoodsNmVagueSrch) resList.Add("GoodsNmVagueSrch");
            if (acptAnOdrRemainRefCndtn1.EnterpriseName != acptAnOdrRemainRefCndtn2.EnterpriseName) resList.Add("EnterpriseName");
            if (acptAnOdrRemainRefCndtn1.SalesEmployeeNm != acptAnOdrRemainRefCndtn2.SalesEmployeeNm) resList.Add("SalesEmployeeNm");
            if (acptAnOdrRemainRefCndtn1.FullModelSrchTyp != acptAnOdrRemainRefCndtn2.FullModelSrchTyp) resList.Add("FullModelSrchTyp");

            return resList;
        }
    }
}
