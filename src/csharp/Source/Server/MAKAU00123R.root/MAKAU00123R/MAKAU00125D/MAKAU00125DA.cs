using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CustDmdPrcWork
    /// <summary>
    ///                      得意先請求金額ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   得意先請求金額ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成(追加項目が多数あるので、再生成時は気をつけて下さい)</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2008/06/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustDmdPrcWork : IFileHeader
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

        /// <summary>計上拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>請求先コード</summary>
        /// <remarks>請求先親コード</remarks>
        private Int32 _claimCode;

        /// <summary>請求先名称</summary>
        private string _claimName = "";

        /// <summary>請求先名称2</summary>
        private string _claimName2 = "";

        /// <summary>請求先略称</summary>
        private string _claimSnm = "";

        /// <summary>実績拠点コード</summary>
        /// <remarks>実績集計の対象となっている拠点コード</remarks>
        private string _resultsSectCd = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先名称</summary>
        private string _customerName = "";

        /// <summary>得意先名称2</summary>
        private string _customerName2 = "";

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>計上年月日</summary>
        /// <remarks>YYYYMMDD 請求締を行なった日（相手先基準）</remarks>
        private DateTime _addUpDate;

        /// <summary>計上年月</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>前回請求金額</summary>
        private Int64 _lastTimeDemand;

        /// <summary>今回手数料額（通常入金）</summary>
        private Int64 _thisTimeFeeDmdNrml;

        /// <summary>今回値引額（通常入金）</summary>
        private Int64 _thisTimeDisDmdNrml;

        /// <summary>今回入金金額（通常入金）</summary>
        /// <remarks>入金額の合計金額</remarks>
        private Int64 _thisTimeDmdNrml;

        /// <summary>今回繰越残高（請求計）</summary>
        /// <remarks>今回繰越残高＝前回請求額－今回入金額合計（通常）</remarks>
        private Int64 _thisTimeTtlBlcDmd;

        /// <summary>相殺後今回売上金額</summary>
        /// <remarks>相殺結果　「相殺後：***」の値が請求金額となる</remarks>
        private Int64 _ofsThisTimeSales;

        /// <summary>相殺後今回売上消費税</summary>
        /// <remarks>相殺結果</remarks>
        private Int64 _ofsThisSalesTax;

        /// <summary>相殺後外税対象額</summary>
        /// <remarks>相殺用：外税額（税抜き）の集計</remarks>
        private Int64 _itdedOffsetOutTax;

        /// <summary>相殺後内税対象額</summary>
        /// <remarks>相殺用：内税額（税抜き）の集計</remarks>
        private Int64 _itdedOffsetInTax;

        /// <summary>相殺後非課税対象額</summary>
        /// <remarks>相殺用：非課税額の集計</remarks>
        private Int64 _itdedOffsetTaxFree;

        /// <summary>相殺後外税消費税</summary>
        /// <remarks>相殺用：外税消費税の集計　（請求転嫁時は、課税対象額から算出）</remarks>
        private Int64 _offsetOutTax;

        /// <summary>相殺後内税消費税</summary>
        /// <remarks>相殺用：内税消費税の集計</remarks>
        private Int64 _offsetInTax;

        /// <summary>今回売上金額</summary>
        /// <remarks>掛売：値引、返品を含まない税抜きの売上金額</remarks>
        private Int64 _thisTimeSales;

        /// <summary>今回売上消費税</summary>
        private Int64 _thisSalesTax;

        /// <summary>売上外税対象額</summary>
        /// <remarks>請求用：外税額（税抜き）の集計</remarks>
        private Int64 _itdedSalesOutTax;

        /// <summary>売上内税対象額</summary>
        /// <remarks>請求用：内税額（税抜き）の集計</remarks>
        private Int64 _itdedSalesInTax;

        /// <summary>売上非課税対象額</summary>
        /// <remarks>請求用：非課税額の集計</remarks>
        private Int64 _itdedSalesTaxFree;

        /// <summary>売上外税額</summary>
        /// <remarks>請求用：外税消費税の集計　（請求転嫁時は、課税対象額から算出）</remarks>
        private Int64 _salesOutTax;

        /// <summary>売上内税額</summary>
        /// <remarks>掛売：内税商品売上の内税消費税額（返品、値引含まず）</remarks>
        private Int64 _salesInTax;

        /// <summary>今回売上返品金額</summary>
        /// <remarks>掛売：値引を含まない税抜きの売上返品金額</remarks>
        private Int64 _thisSalesPricRgds;

        /// <summary>今回売上返品消費税</summary>
        /// <remarks>今回売上返品消費税＝返品外税額合計＋返品内税額合計</remarks>
        private Int64 _thisSalesPrcTaxRgds;

        /// <summary>返品外税対象額合計</summary>
        private Int64 _ttlItdedRetOutTax;

        /// <summary>返品内税対象額合計</summary>
        private Int64 _ttlItdedRetInTax;

        /// <summary>返品非課税対象額合計</summary>
        private Int64 _ttlItdedRetTaxFree;

        /// <summary>返品外税額合計</summary>
        private Int64 _ttlRetOuterTax;

        /// <summary>返品内税額合計</summary>
        /// <remarks>掛売：内税商品返品の内税消費税額（値引含まず）</remarks>
        private Int64 _ttlRetInnerTax;

        /// <summary>今回売上値引金額</summary>
        /// <remarks>掛売：税抜きの売上値引金額</remarks>
        private Int64 _thisSalesPricDis;

        /// <summary>今回売上値引消費税</summary>
        /// <remarks>今回売上値引消費税＝値引外税額合計＋値引内税額合計</remarks>
        private Int64 _thisSalesPrcTaxDis;

        /// <summary>値引外税対象額合計</summary>
        private Int64 _ttlItdedDisOutTax;

        /// <summary>値引内税対象額合計</summary>
        private Int64 _ttlItdedDisInTax;

        /// <summary>値引非課税対象額合計</summary>
        private Int64 _ttlItdedDisTaxFree;

        /// <summary>値引外税額合計</summary>
        private Int64 _ttlDisOuterTax;

        /// <summary>値引内税額合計</summary>
        /// <remarks>掛売：内税商品返品の内税消費税額</remarks>
        private Int64 _ttlDisInnerTax;

        /// <summary>消費税調整額</summary>
        private Int64 _taxAdjust;

        /// <summary>残高調整額</summary>
        private Int64 _balanceAdjust;

        /// <summary>計算後請求金額</summary>
        /// <remarks>今回請求金額</remarks>
        private Int64 _afCalDemandPrice;

        /// <summary>受注2回前残高（請求計）</summary>
        private Int64 _acpOdrTtl2TmBfBlDmd;

        /// <summary>受注3回前残高（請求計）</summary>
        private Int64 _acpOdrTtl3TmBfBlDmd;

        /// <summary>締次更新実行年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _cAddUpUpdExecDate;

        /// <summary>締次更新開始年月日</summary>
        /// <remarks>"YYYYMMDD"  締次更新対象となる開始年月日</remarks>
        private DateTime _startCAddUpUpdDate;

        /// <summary>前回締次更新年月日</summary>
        /// <remarks>"YYYYMMDD"  前回締次更新対象となった年月日</remarks>
        private DateTime _lastCAddUpUpdDate;

        /// <summary>売上伝票枚数</summary>
        /// <remarks>掛売の伝票枚数</remarks>
        private Int32 _salesSlipCount;

        /// <summary>請求書発行日</summary>
        /// <remarks>"YYYYMMDD"  請求書を発行した年月日</remarks>
        private DateTime _billPrintDate;

        /// <summary>入金予定日</summary>
        private DateTime _expectedDepositDate;

        /// <summary>回収条件</summary>
        /// <remarks>10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他</remarks>
        private Int32 _collectCond;

        /// <summary>消費税転嫁方式</summary>
        /// <remarks>消費税転嫁区分設定マスタを参照 0:伝票単位1:明細単位2:請求時一括</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>消費税率</summary>
        /// <remarks>請求転嫁消費税を算出する場合に使用</remarks>
        private Double _consTaxRate;

        /// <summary>端数処理区分</summary>
        private Int32 _fractionProcCd;

        // 2008.06.19 add start ----------------------------->>
        /// <summary>得意先締日</summary>
        /// <remarks>追加パラメータ</remarks>
        private Int32 _customerTotalDay;

        /// <summary>相殺後外税消費税（伝票）</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _offsetOutTaxSlip;

        /// <summary>相殺後外税消費税（請求）</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _offsetOutTaxDmd;

        /// <summary>売上外税対象額（伝票）</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _itdedSalesOutTaxSlip;

        /// <summary>売上外税対象額（請求）</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _itdedSalesOutTaxDmd;

        /// <summary>売上内税対象額（伝票）</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _itdedSalesInTaxSlip;

        /// <summary>売上内税対象額（請求）</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _itdedSalesInTaxDmd;

        /// <summary>売上外税額（伝票）</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _salesOutTaxSlip;

        /// <summary>売上外税額（請求）</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _salesOutTaxDmd;

        /// <summary>返品外税対象額（伝票）</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _itdedRetOutTaxSlip;

        /// <summary>返品外税対象額（請求）</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _itdedRetOutTaxDmd;

        /// <summary>返品内税対象額（伝票）</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _itdedRetInTaxSlip;

        /// <summary>返品内税対象額（請求）</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _itdedRetInTaxDmd;

        /// <summary>返品外税消費税（伝票）</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _RetOutTaxSlip;

        /// <summary>返品外税消費税（請求）</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _RetOutTaxDmd;

        /// <summary>消費税調整額</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _taxAdust;

        /// <summary>総額表示方法区分</summary>
        /// <remarks>追加　0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
        private Int32 _totalAmountDispWayCd;

        /// <summary>総額表示方法参照区分</summary>
        /// <remarks>追加　0:全体設定参照 1:得意先参照</remarks>
        private Int32 _totalAmntDspWayRef;

        /// <summary>更新ステータス</summary>
        /// <remarks>追加パラメータ</remarks>
        private Int32 _updateStatus;

        /// <summary>管理拠点コード</summary>
        /// <remarks>追加パラメータ</remarks>
        private string _mngSectionCode = "";

        /// <summary>業販先区分</summary>
        /// <remarks>追加パラメータ 0:業販先以外,1:業販先,2:納入先</remarks>
        private Int32 _acceptWholeSale;

        /// <summary>得意先伝票番号区分</summary>
        /// <remarks>追加パラメータ 0:使用しない,1:連番,2:締毎,3:期末</remarks>
        private Int32 _customerSlipNoDiv;
        // 2008.06.19 add end -------------------------------<<

        // ADD 2009/06/18 >>>
        /// <summary>請求処理通番</summary>
        private Int32 _billNo;
        // ADD 2009/06/18 <<<

        // --- ADD m.suzuki 2010/07/21 ---------->>>>>
        /// <summary>抽出開始日（得意先電子元帳の残高合計用）</summary>
        /// <remarks>※抽出条件専用項目です。テーブルレイアウトには存在しない項目です。</remarks>
        private DateTime _extractStartDate;
        // --- ADD m.suzuki 2010/07/21 ----------<<<<<


        //----- ADD 2013/08/08 汪権来 Redmine#35552 速度改善 ------------------->>>>>
        /// <summary>端数処理単位</summary>
        /// <remarks>端数処理単位</remarks>
        private double _fractionProcUnit;

        /// <summary>請求転嫁(親)</summary>
        /// <remarks>請求転嫁(親)</remarks>
        private double _salesouttax_s;

        /// <summary>請求転嫁(親)消費税</summary>
        /// <remarks>請求転嫁(親)消費税</remarks>
        private double _retsalesouttax_s;

        /// <summary>請求転嫁(親)消費税</summary>
        /// <remarks>請求転嫁(親)消費税</remarks>
        private double _dissaleouttax_s;

        /// <summary>伝票転嫁消費税</summary>
        /// <remarks>伝票転嫁消費税</remarks>
        private Int64 _salesouttax_d;

        /// <summary>伝票転嫁消費税</summary>
        /// <remarks>伝票転嫁消費税</remarks>
        private Int64 _retsalesouttax_d;

        /// <summary>伝票転嫁消費税</summary>
        /// <remarks>伝票転嫁消費税</remarks>
        private Int64 _dissaleouttax_d;

        /// <summary>明細転嫁消費税</summary>
        /// <remarks>明細転嫁消費税</remarks>
        private Int64 _salesouttax_m;

        /// <summary>明細転嫁消費税</summary>
        /// <remarks>明細転嫁消費税</remarks>
        private Int64 _retsalesouttax_m;

        /// <summary>明細転嫁消費税</summary>
        /// <remarks>明細転嫁消費税</remarks>
        private Int64 _dissaleouttax_m;

        /// <summary>集金月区分コード</summary>
        /// <remarks>集金月区分コード</remarks>
        private Int32 _collectmoneycode;

        /// <summary>集金日</summary>
        /// <remarks>集金日</remarks>
        private Int32 _collectmoneyday;

        /// <summary>請求転嫁(子)</summary>
        /// <remarks>請求転嫁(子)</remarks>
        private double _dissalesouttax_s;

        /// <summary>請求転嫁(親)</summary>
        /// <remarks>請求転嫁(親)</remarks>
        private double _salesouttax_s2;

        /// <summary>請求転嫁(親)</summary>
        /// <remarks>請求転嫁(親)</remarks>
        private double _retsalesouttax_s2;

        /// <summary>請求転嫁(親)</summary>
        /// <remarks>請求転嫁(親)</remarks>
        private double _dissalesouttax_s2;

        /// <summary>伝票転嫁</summary>
        /// <remarks>伝票転嫁</remarks>
        private Int64 _dissalesouttax_d;

        /// <summary>明細転嫁</summary>
        /// <remarks>明細転嫁</remarks>
        private Int64 _dissalesouttax_m;
        //----- ADD 2013/08/08 汪権来 Redmine#35552 速度改善 -------------------<<<<<
        
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

        /// public propaty name  :  ClaimCode
        /// <summary>請求先コードプロパティ</summary>
        /// <value>請求先親コード</value>
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

        /// public propaty name  :  ClaimName
        /// <summary>請求先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClaimName
        {
            get { return _claimName; }
            set { _claimName = value; }
        }

        /// public propaty name  :  ClaimName2
        /// <summary>請求先名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClaimName2
        {
            get { return _claimName2; }
            set { _claimName2 = value; }
        }

        /// public propaty name  :  ClaimSnm
        /// <summary>請求先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClaimSnm
        {
            get { return _claimSnm; }
            set { _claimSnm = value; }
        }

        /// public propaty name  :  ResultsSectCd
        /// <summary>実績拠点コードプロパティ</summary>
        /// <value>実績集計の対象となっている拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   実績拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ResultsSectCd
        {
            get { return _resultsSectCd; }
            set { _resultsSectCd = value; }
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

        /// public propaty name  :  AddUpDate
        /// <summary>計上年月日プロパティ</summary>
        /// <value>YYYYMMDD 請求締を行なった日（相手先基準）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpDate
        {
            get { return _addUpDate; }
            set { _addUpDate = value; }
        }

        /// public propaty name  :  AddUpYearMonth
        /// <summary>計上年月プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpYearMonth
        {
            get { return _addUpYearMonth; }
            set { _addUpYearMonth = value; }
        }

        /// public propaty name  :  LastTimeDemand
        /// <summary>前回請求金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回請求金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 LastTimeDemand
        {
            get { return _lastTimeDemand; }
            set { _lastTimeDemand = value; }
        }

        /// public propaty name  :  ThisTimeFeeDmdNrml
        /// <summary>今回手数料額（通常入金）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回手数料額（通常入金）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeFeeDmdNrml
        {
            get { return _thisTimeFeeDmdNrml; }
            set { _thisTimeFeeDmdNrml = value; }
        }

        /// public propaty name  :  ThisTimeDisDmdNrml
        /// <summary>今回値引額（通常入金）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回値引額（通常入金）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeDisDmdNrml
        {
            get { return _thisTimeDisDmdNrml; }
            set { _thisTimeDisDmdNrml = value; }
        }

        /// public propaty name  :  ThisTimeDmdNrml
        /// <summary>今回入金金額（通常入金）プロパティ</summary>
        /// <value>入金額の合計金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回入金金額（通常入金）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeDmdNrml
        {
            get { return _thisTimeDmdNrml; }
            set { _thisTimeDmdNrml = value; }
        }

        /// public propaty name  :  ThisTimeTtlBlcDmd
        /// <summary>今回繰越残高（請求計）プロパティ</summary>
        /// <value>今回繰越残高＝前回請求額－今回入金額合計（通常）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回繰越残高（請求計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeTtlBlcDmd
        {
            get { return _thisTimeTtlBlcDmd; }
            set { _thisTimeTtlBlcDmd = value; }
        }

        /// public propaty name  :  OfsThisTimeSales
        /// <summary>相殺後今回売上金額プロパティ</summary>
        /// <value>相殺結果　「相殺後：***」の値が請求金額となる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺後今回売上金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 OfsThisTimeSales
        {
            get { return _ofsThisTimeSales; }
            set { _ofsThisTimeSales = value; }
        }

        /// public propaty name  :  OfsThisSalesTax
        /// <summary>相殺後今回売上消費税プロパティ</summary>
        /// <value>相殺結果</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺後今回売上消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 OfsThisSalesTax
        {
            get { return _ofsThisSalesTax; }
            set { _ofsThisSalesTax = value; }
        }

        /// public propaty name  :  ItdedOffsetOutTax
        /// <summary>相殺後外税対象額プロパティ</summary>
        /// <value>相殺用：外税額（税抜き）の集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺後外税対象額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ItdedOffsetOutTax
        {
            get { return _itdedOffsetOutTax; }
            set { _itdedOffsetOutTax = value; }
        }

        /// public propaty name  :  ItdedOffsetInTax
        /// <summary>相殺後内税対象額プロパティ</summary>
        /// <value>相殺用：内税額（税抜き）の集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺後内税対象額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ItdedOffsetInTax
        {
            get { return _itdedOffsetInTax; }
            set { _itdedOffsetInTax = value; }
        }

        /// public propaty name  :  ItdedOffsetTaxFree
        /// <summary>相殺後非課税対象額プロパティ</summary>
        /// <value>相殺用：非課税額の集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺後非課税対象額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ItdedOffsetTaxFree
        {
            get { return _itdedOffsetTaxFree; }
            set { _itdedOffsetTaxFree = value; }
        }

        /// public propaty name  :  OffsetOutTax
        /// <summary>相殺後外税消費税プロパティ</summary>
        /// <value>相殺用：外税消費税の集計　（請求転嫁時は、課税対象額から算出）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺後外税消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 OffsetOutTax
        {
            get { return _offsetOutTax; }
            set { _offsetOutTax = value; }
        }

        /// public propaty name  :  OffsetInTax
        /// <summary>相殺後内税消費税プロパティ</summary>
        /// <value>相殺用：内税消費税の集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺後内税消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 OffsetInTax
        {
            get { return _offsetInTax; }
            set { _offsetInTax = value; }
        }

        /// public propaty name  :  ThisTimeSales
        /// <summary>今回売上金額プロパティ</summary>
        /// <value>掛売：値引、返品を含まない税抜きの売上金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回売上金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeSales
        {
            get { return _thisTimeSales; }
            set { _thisTimeSales = value; }
        }

        /// public propaty name  :  ThisSalesTax
        /// <summary>今回売上消費税プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回売上消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisSalesTax
        {
            get { return _thisSalesTax; }
            set { _thisSalesTax = value; }
        }

        /// public propaty name  :  ItdedSalesOutTax
        /// <summary>売上外税対象額プロパティ</summary>
        /// <value>請求用：外税額（税抜き）の集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上外税対象額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ItdedSalesOutTax
        {
            get { return _itdedSalesOutTax; }
            set { _itdedSalesOutTax = value; }
        }

        /// public propaty name  :  ItdedSalesInTax
        /// <summary>売上内税対象額プロパティ</summary>
        /// <value>請求用：内税額（税抜き）の集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上内税対象額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ItdedSalesInTax
        {
            get { return _itdedSalesInTax; }
            set { _itdedSalesInTax = value; }
        }

        /// public propaty name  :  ItdedSalesTaxFree
        /// <summary>売上非課税対象額プロパティ</summary>
        /// <value>請求用：非課税額の集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上非課税対象額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ItdedSalesTaxFree
        {
            get { return _itdedSalesTaxFree; }
            set { _itdedSalesTaxFree = value; }
        }

        /// public propaty name  :  SalesOutTax
        /// <summary>売上外税額プロパティ</summary>
        /// <value>請求用：外税消費税の集計　（請求転嫁時は、課税対象額から算出）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上外税額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesOutTax
        {
            get { return _salesOutTax; }
            set { _salesOutTax = value; }
        }

        /// public propaty name  :  SalesInTax
        /// <summary>売上内税額プロパティ</summary>
        /// <value>掛売：内税商品売上の内税消費税額（返品、値引含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上内税額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesInTax
        {
            get { return _salesInTax; }
            set { _salesInTax = value; }
        }

        /// public propaty name  :  ThisSalesPricRgds
        /// <summary>今回売上返品金額プロパティ</summary>
        /// <value>掛売：値引を含まない税抜きの売上返品金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回売上返品金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisSalesPricRgds
        {
            get { return _thisSalesPricRgds; }
            set { _thisSalesPricRgds = value; }
        }

        /// public propaty name  :  ThisSalesPrcTaxRgds
        /// <summary>今回売上返品消費税プロパティ</summary>
        /// <value>今回売上返品消費税＝返品外税額合計＋返品内税額合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回売上返品消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisSalesPrcTaxRgds
        {
            get { return _thisSalesPrcTaxRgds; }
            set { _thisSalesPrcTaxRgds = value; }
        }

        /// public propaty name  :  TtlItdedRetOutTax
        /// <summary>返品外税対象額合計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品外税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlItdedRetOutTax
        {
            get { return _ttlItdedRetOutTax; }
            set { _ttlItdedRetOutTax = value; }
        }

        /// public propaty name  :  TtlItdedRetInTax
        /// <summary>返品内税対象額合計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品内税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlItdedRetInTax
        {
            get { return _ttlItdedRetInTax; }
            set { _ttlItdedRetInTax = value; }
        }

        /// public propaty name  :  TtlItdedRetTaxFree
        /// <summary>返品非課税対象額合計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品非課税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlItdedRetTaxFree
        {
            get { return _ttlItdedRetTaxFree; }
            set { _ttlItdedRetTaxFree = value; }
        }

        /// public propaty name  :  TtlRetOuterTax
        /// <summary>返品外税額合計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品外税額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlRetOuterTax
        {
            get { return _ttlRetOuterTax; }
            set { _ttlRetOuterTax = value; }
        }

        /// public propaty name  :  TtlRetInnerTax
        /// <summary>返品内税額合計プロパティ</summary>
        /// <value>掛売：内税商品返品の内税消費税額（値引含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品内税額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlRetInnerTax
        {
            get { return _ttlRetInnerTax; }
            set { _ttlRetInnerTax = value; }
        }

        /// public propaty name  :  ThisSalesPricDis
        /// <summary>今回売上値引金額プロパティ</summary>
        /// <value>掛売：税抜きの売上値引金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回売上値引金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisSalesPricDis
        {
            get { return _thisSalesPricDis; }
            set { _thisSalesPricDis = value; }
        }

        /// public propaty name  :  ThisSalesPrcTaxDis
        /// <summary>今回売上値引消費税プロパティ</summary>
        /// <value>今回売上値引消費税＝値引外税額合計＋値引内税額合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回売上値引消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisSalesPrcTaxDis
        {
            get { return _thisSalesPrcTaxDis; }
            set { _thisSalesPrcTaxDis = value; }
        }

        /// public propaty name  :  TtlItdedDisOutTax
        /// <summary>値引外税対象額合計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引外税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlItdedDisOutTax
        {
            get { return _ttlItdedDisOutTax; }
            set { _ttlItdedDisOutTax = value; }
        }

        /// public propaty name  :  TtlItdedDisInTax
        /// <summary>値引内税対象額合計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引内税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlItdedDisInTax
        {
            get { return _ttlItdedDisInTax; }
            set { _ttlItdedDisInTax = value; }
        }

        /// public propaty name  :  TtlItdedDisTaxFree
        /// <summary>値引非課税対象額合計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引非課税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlItdedDisTaxFree
        {
            get { return _ttlItdedDisTaxFree; }
            set { _ttlItdedDisTaxFree = value; }
        }

        /// public propaty name  :  TtlDisOuterTax
        /// <summary>値引外税額合計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引外税額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlDisOuterTax
        {
            get { return _ttlDisOuterTax; }
            set { _ttlDisOuterTax = value; }
        }

        /// public propaty name  :  TtlDisInnerTax
        /// <summary>値引内税額合計プロパティ</summary>
        /// <value>掛売：内税商品返品の内税消費税額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引内税額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlDisInnerTax
        {
            get { return _ttlDisInnerTax; }
            set { _ttlDisInnerTax = value; }
        }

        /// public propaty name  :  TaxAdjust
        /// <summary>消費税調整額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税調整額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TaxAdjust
        {
            get { return _taxAdjust; }
            set { _taxAdjust = value; }
        }

        /// public propaty name  :  BalanceAdjust
        /// <summary>残高調整額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   残高調整額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 BalanceAdjust
        {
            get { return _balanceAdjust; }
            set { _balanceAdjust = value; }
        }

        /// public propaty name  :  AfCalDemandPrice
        /// <summary>計算後請求金額プロパティ</summary>
        /// <value>今回請求金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計算後請求金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AfCalDemandPrice
        {
            get { return _afCalDemandPrice; }
            set { _afCalDemandPrice = value; }
        }

        /// public propaty name  :  AcpOdrTtl2TmBfBlDmd
        /// <summary>受注2回前残高（請求計）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注2回前残高（請求計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AcpOdrTtl2TmBfBlDmd
        {
            get { return _acpOdrTtl2TmBfBlDmd; }
            set { _acpOdrTtl2TmBfBlDmd = value; }
        }

        /// public propaty name  :  AcpOdrTtl3TmBfBlDmd
        /// <summary>受注3回前残高（請求計）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注3回前残高（請求計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AcpOdrTtl3TmBfBlDmd
        {
            get { return _acpOdrTtl3TmBfBlDmd; }
            set { _acpOdrTtl3TmBfBlDmd = value; }
        }

        /// public propaty name  :  CAddUpUpdExecDate
        /// <summary>締次更新実行年月日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新実行年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CAddUpUpdExecDate
        {
            get { return _cAddUpUpdExecDate; }
            set { _cAddUpUpdExecDate = value; }
        }

        /// public propaty name  :  StartCAddUpUpdDate
        /// <summary>締次更新開始年月日プロパティ</summary>
        /// <value>"YYYYMMDD"  締次更新対象となる開始年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新開始年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StartCAddUpUpdDate
        {
            get { return _startCAddUpUpdDate; }
            set { _startCAddUpUpdDate = value; }
        }

        /// public propaty name  :  LastCAddUpUpdDate
        /// <summary>前回締次更新年月日プロパティ</summary>
        /// <value>"YYYYMMDD"  前回締次更新対象となった年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回締次更新年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime LastCAddUpUpdDate
        {
            get { return _lastCAddUpUpdDate; }
            set { _lastCAddUpUpdDate = value; }
        }

        /// public propaty name  :  SalesSlipCount
        /// <summary>売上伝票枚数プロパティ</summary>
        /// <value>掛売の伝票枚数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票枚数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipCount
        {
            get { return _salesSlipCount; }
            set { _salesSlipCount = value; }
        }

        /// public propaty name  :  BillPrintDate
        /// <summary>請求書発行日プロパティ</summary>
        /// <value>"YYYYMMDD"  請求書を発行した年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書発行日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime BillPrintDate
        {
            get { return _billPrintDate; }
            set { _billPrintDate = value; }
        }

        /// public propaty name  :  ExpectedDepositDate
        /// <summary>入金予定日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金予定日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ExpectedDepositDate
        {
            get { return _expectedDepositDate; }
            set { _expectedDepositDate = value; }
        }

        /// public propaty name  :  CollectCond
        /// <summary>回収条件プロパティ</summary>
        /// <value>10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回収条件プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CollectCond
        {
            get { return _collectCond; }
            set { _collectCond = value; }
        }

        /// public propaty name  :  ConsTaxLayMethod
        /// <summary>消費税転嫁方式プロパティ</summary>
        /// <value>消費税転嫁区分設定マスタを参照 0:伝票単位1:明細単位2:請求時一括</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税転嫁方式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ConsTaxLayMethod
        {
            get { return _consTaxLayMethod; }
            set { _consTaxLayMethod = value; }
        }

        /// public propaty name  :  ConsTaxRate
        /// <summary>消費税率プロパティ</summary>
        /// <value>請求転嫁消費税を算出する場合に使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ConsTaxRate
        {
            get { return _consTaxRate; }
            set { _consTaxRate = value; }
        }

        /// public propaty name  :  FractionProcCd
        /// <summary>端数処理区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端数処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FractionProcCd
        {
            get { return _fractionProcCd; }
            set { _fractionProcCd = value; }
        }

        // 2008.06.19 add start ----------------------------------------->>
        /// public propaty name  :  CustomerTotalDay
        /// <summary>得意先締日プロパティ</summary>
        /// <value>追加パラメータ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerTotalDay
        {
            get { return _customerTotalDay; }
            set { _customerTotalDay = value; }
        }

        /// public propaty name  :  OffsetOutTaxSlip
        /// <summary>相殺後外税消費税（伝票）プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺後外税消費税（伝票）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 OffsetOutTaxSlip
        {
            get { return _offsetOutTaxSlip; }
            set { _offsetOutTaxSlip = value; }
        }

        /// public propaty name  :  OffsetOutTaxDmd
        /// <summary>相殺後外税消費税（請求）プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺後外税消費税（請求）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 OffsetOutTaxDmd
        {
            get { return _offsetOutTaxDmd; }
            set { _offsetOutTaxDmd = value; }
        }

        /// public propaty name  :  ItdedSalesOutTaxSlip
        /// <summary>売上外税対象額（伝票）プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上外税対象額（伝票）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ItdedSalesOutTaxSlip
        {
            get { return _itdedSalesOutTaxSlip; }
            set { _itdedSalesOutTaxSlip = value; }
        }

        /// public propaty name  :  ItdedSalesOutTaxDmd
        /// <summary>売上外税対象額（請求）プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上外税対象額（請求）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ItdedSalesOutTaxDmd
        {
            get { return _itdedSalesOutTaxDmd; }
            set { _itdedSalesOutTaxDmd = value; }
        }

        /// public propaty name  :  ItdedSalesInTaxSlip
        /// <summary>売上内税対象額（伝票）プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上内税対象額（伝票）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ItdedSalesInTaxSlip
        {
            get { return _itdedSalesInTaxSlip; }
            set { _itdedSalesInTaxSlip = value; }
        }

        /// public propaty name  :  ItdedSalesInTaxDmd
        /// <summary>売上内税対象額（請求）プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上内税対象額（請求）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ItdedSalesInTaxDmd
        {
            get { return _itdedSalesInTaxDmd; }
            set { _itdedSalesInTaxDmd = value; }
        }

        /// public propaty name  :  SalesOutTaxSlip
        /// <summary>売上外税額（伝票）プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上外税額（伝票）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesOutTaxSlip
        {
            get { return _salesOutTaxSlip; }
            set { _salesOutTaxSlip = value; }
        }

        /// public propaty name  :  SalesOutTaxDmd
        /// <summary>売上外税額（請求）プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上外税額（請求）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesOutTaxDmd
        {
            get { return _salesOutTaxDmd; }
            set { _salesOutTaxDmd = value; }
        }

        /// public propaty name  :  ItdedRetOutTaxSlip
        /// <summary>返品外税対象額（伝票）プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品外税対象額（伝票）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ItdedRetOutTaxSlip
        {
            get { return _itdedRetOutTaxSlip; }
            set { _itdedRetOutTaxSlip = value; }
        }

        /// public propaty name  :  ItdedRetOutTaxDmd
        /// <summary>返品外税対象額（請求）プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品外税対象額（請求）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ItdedRetOutTaxDmd
        {
            get { return _itdedRetOutTaxDmd; }
            set { _itdedRetOutTaxDmd = value; }
        }

        /// public propaty name  :  ItdedRetInTaxSlip
        /// <summary>返品内税対象額（伝票）プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品内税対象額（伝票）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ItdedRetInTaxSlip
        {
            get { return _itdedRetInTaxSlip; }
            set { _itdedRetInTaxSlip = value; }
        }

        /// public propaty name  :  ItdedRetInTaxDmd
        /// <summary>返品内税対象額（請求）プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品内税対象額（請求）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ItdedRetInTaxDmd
        {
            get { return _itdedRetInTaxDmd; }
            set { _itdedRetInTaxDmd = value; }
        }

        /// public propaty name  :  RetOutTaxSlip
        /// <summary>返品外税消費税（伝票）プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品外税消費税（伝票）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 RetOutTaxSlip
        {
            get { return _RetOutTaxSlip; }
            set { _RetOutTaxSlip = value; }
        }

        /// public propaty name  :  RetOutTaxDmd
        /// <summary>返品外税消費税（請求）プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品外税消費税（請求）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 RetOutTaxDmd
        {
            get { return _RetOutTaxDmd; }
            set { _RetOutTaxDmd = value; }
        }

        /// public propaty name  :  TaxAdust
        /// <summary>消費税調整額プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税調整額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TaxAdust
        {
            get { return _taxAdust; }
            set { _taxAdust = value; }
        }

        /// public propaty name  :  TotalAmountDispWayCd
        /// <summary>総額表示方法区分プロパティ</summary>
        /// <value>追加　0:総額表示しない（税抜き）,1:総額表示する（税込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総額表示方法区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalAmountDispWayCd
        {
            get { return _totalAmountDispWayCd; }
            set { _totalAmountDispWayCd = value; }
        }

        /// public propaty name  :  TotalAmntDspWayRef
        /// <summary>総額表示方法参照区分プロパティ</summary>
        /// <value>追加　0:全体設定参照 1:得意先参照</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総額表示方法参照区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalAmntDspWayRef
        {
            get { return _totalAmntDspWayRef; }
            set { _totalAmntDspWayRef = value; }
        }

        /// public propaty name  :  UpdateStatus
        /// <summary>更新ステータスプロパティ</summary>
        /// <value>追加パラメータ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UpdateStatus
        {
            get { return _updateStatus; }
            set { _updateStatus = value; }
        }

        /// public propaty name  :  MngSectionCode
        /// <summary>管理拠点コードプロパティ</summary>
        /// <value>追加パラメータ</value>
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

        /// public propaty name  :  AcceptWholeSale
        /// <summary>業販先区分プロパティ</summary>
        /// <value>追加パラメータ 0:業販先以外,1:業販先,2:納入先</value>
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

        /// public propaty name  :  CustomerSlipNoDiv
        /// <summary>得意先伝票番号区分プロパティ</summary>
        /// <value>追加パラメータ 0:使用しない,1:連番,2:締毎,3:期末</value>
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
        // 2008.06.19 add end -------------------------------------------<<

        // ADD 2009/06/18 >>>
        /// public propaty name  :  BillNo
        /// <summary>請求処理通番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求処理通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BillNo
        {
            get { return _billNo; }
            set { _billNo = value; }
        }
        // ADD 2009/06/18 <<<

        // --- ADD m.suzuki 2010/07/21 ---------->>>>>
        /// public propaty name  :  ExtractStartDate
        /// <summary>抽出開始日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   抽出開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ExtractStartDate
        {
            get { return _extractStartDate; }
            set { _extractStartDate = value; }
        }
        // --- ADD m.suzuki 2010/07/21 ----------<<<<<
        //----- ADD 2013/08/08 汪権来 Redmine#35552 速度改善 ------------------->>>>>
        /// public propaty name  :  FractionProcUnit
        /// <summary>端数処理単位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端数処理単位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double FractionProcUnit
        {
            get { return _fractionProcUnit; }
            set { _fractionProcUnit = value; }
        }

        /// public propaty name  :  Salesouttax_s
        /// <summary>請求転嫁(親)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求転嫁(親)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double Salesouttax_s
        {
            get { return _salesouttax_s; }
            set { _salesouttax_s = value; }
        }

        /// public propaty name  :  Retsalesouttax_s
        /// <summary>請求転嫁(親)消費税プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求転嫁(親)消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double Retsalesouttax_s
        {
            get { return _retsalesouttax_s; }
            set { _retsalesouttax_s = value; }
        }

        /// public propaty name  :  Dissaleouttax_s
        /// <summary>請求転嫁(親)消費税プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求転嫁(親)消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double Dissaleouttax_s
        {
            get { return _dissaleouttax_s; }
            set { _dissaleouttax_s = value; }
        }

        /// public propaty name  :  Salesouttax_d
        /// <summary>伝票転嫁消費税プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票転嫁消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Salesouttax_d
        {
            get { return _salesouttax_d; }
            set { _salesouttax_d = value; }
        }

        /// public propaty name  :  Retsalesouttax_d
        /// <summary>伝票転嫁消費税プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票転嫁消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Retsalesouttax_d
        {
            get { return _retsalesouttax_d; }
            set { _retsalesouttax_d = value; }
        }

        /// public propaty name  :  Dissaleouttax_d
        /// <summary>伝票転嫁消費税プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票転嫁消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Dissaleouttax_d
        {
            get { return _dissaleouttax_d; }
            set { _dissaleouttax_d = value; }
        }

        /// public propaty name  :  Salesouttax_m
        /// <summary>明細転嫁消費税プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細転嫁消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Salesouttax_m
        {
            get { return _salesouttax_m; }
            set { _salesouttax_m = value; }
        }

        /// public propaty name  :  Retsalesouttax_m
        /// <summary>明細転嫁消費税プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細転嫁消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Retsalesouttax_m
        {
            get { return _retsalesouttax_m; }
            set { _retsalesouttax_m = value; }
        }

        /// public propaty name  :  Dissaleouttax_m
        /// <summary>明細転嫁消費税プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細転嫁消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Dissaleouttax_m
        {
            get { return _dissaleouttax_m; }
            set { _dissaleouttax_m = value; }
        }

        /// public propaty name  :  Collectmoneycode
        /// <summary>集金月区分コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金月区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Collectmoneycode
        {
            get { return _collectmoneycode; }
            set { _collectmoneycode = value; }
        }

        /// public propaty name  :  Collectmoneyday
        /// <summary>集金日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Collectmoneyday
        {
            get { return _collectmoneyday; }
            set { _collectmoneyday = value; }
        }
        /// public propaty name  :  Dissalesouttax_s
        /// <summary>請求転嫁(子)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求転嫁(子)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double Dissalesouttax_s
        {
            get { return _dissalesouttax_s; }
            set { _dissalesouttax_s = value; }
        }

        /// public propaty name  :  Salesouttax_s2
        /// <summary>請求転嫁(親)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求転嫁(親)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double Salesouttax_s2
        {
            get { return _salesouttax_s2; }
            set { _salesouttax_s2 = value; }
        }

        /// public propaty name  :  Retsalesouttax_s2
        /// <summary>請求転嫁(親)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求転嫁(親)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double Retsalesouttax_s2
        {
            get { return _retsalesouttax_s2; }
            set { _retsalesouttax_s2 = value; }
        }

        /// public propaty name  :  Dissalesouttax_s2
        /// <summary>請求転嫁(親)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求転嫁(親)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double Dissalesouttax_s2
        {
            get { return _dissalesouttax_s2; }
            set { _dissalesouttax_s2 = value; }
        }

        /// public propaty name  :  Dissalesouttax_d
        /// <summary>伝票転嫁プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票転嫁プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Dissalesouttax_d
        {
            get { return _dissalesouttax_d; }
            set { _dissalesouttax_d = value; }
        }

        /// public propaty name  :  Dissalesouttax_m
        /// <summary>明細転嫁プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細転嫁プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Dissalesouttax_m
        {
            get { return _dissalesouttax_m; }
            set { _dissalesouttax_m = value; }
        }

        //----- ADD 2013/08/08 汪権来 Redmine#35552 速度改善 -------------------<<<<<
        /// <summary>
        /// 得意先請求金額ワークコンストラクタ
        /// </summary>
        /// <returns>CustDmdPrcWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustDmdPrcWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustDmdPrcWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CustDmdPrcWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CustDmdPrcWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class CustDmdPrcWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustDmdPrcWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CustDmdPrcWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CustDmdPrcWork || graph is ArrayList || graph is CustDmdPrcWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CustDmdPrcWork).FullName));

            if (graph != null && graph is CustDmdPrcWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustDmdPrcWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CustDmdPrcWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CustDmdPrcWork[])graph).Length;
            }
            else if (graph is CustDmdPrcWork)
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
            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //請求先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //ClaimCode
            //請求先名称
            serInfo.MemberInfo.Add(typeof(string)); //ClaimName
            //請求先名称2
            serInfo.MemberInfo.Add(typeof(string)); //ClaimName2
            //請求先略称
            serInfo.MemberInfo.Add(typeof(string)); //ClaimSnm
            //実績拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //ResultsSectCd
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先名称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
            //得意先名称2
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName2
            //得意先略称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //計上年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpDate
            //計上年月
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpYearMonth
            //前回請求金額
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeDemand
            //今回手数料額（通常入金）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeFeeDmdNrml
            //今回値引額（通常入金）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDisDmdNrml
            //今回入金金額（通常入金）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDmdNrml
            //今回繰越残高（請求計）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeTtlBlcDmd
            //相殺後今回売上金額
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisTimeSales
            //相殺後今回売上消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisSalesTax
            //相殺後外税対象額
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedOffsetOutTax
            //相殺後内税対象額
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedOffsetInTax
            //相殺後非課税対象額
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedOffsetTaxFree
            //相殺後外税消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //OffsetOutTax
            //相殺後内税消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //OffsetInTax
            //今回売上金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeSales
            //今回売上消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesTax
            //売上外税対象額
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedSalesOutTax
            //売上内税対象額
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedSalesInTax
            //売上非課税対象額
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedSalesTaxFree
            //売上外税額
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesOutTax
            //売上内税額
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesInTax
            //今回売上返品金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPricRgds
            //今回売上返品消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPrcTaxRgds
            //返品外税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedRetOutTax
            //返品内税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedRetInTax
            //返品非課税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedRetTaxFree
            //返品外税額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlRetOuterTax
            //返品内税額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlRetInnerTax
            //今回売上値引金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPricDis
            //今回売上値引消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPrcTaxDis
            //値引外税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedDisOutTax
            //値引内税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedDisInTax
            //値引非課税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedDisTaxFree
            //値引外税額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlDisOuterTax
            //値引内税額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlDisInnerTax
            //消費税調整額
            serInfo.MemberInfo.Add(typeof(Int64)); //TaxAdjust
            //残高調整額
            serInfo.MemberInfo.Add(typeof(Int64)); //BalanceAdjust
            //計算後請求金額
            serInfo.MemberInfo.Add(typeof(Int64)); //AfCalDemandPrice
            //受注2回前残高（請求計）
            serInfo.MemberInfo.Add(typeof(Int64)); //AcpOdrTtl2TmBfBlDmd
            //受注3回前残高（請求計）
            serInfo.MemberInfo.Add(typeof(Int64)); //AcpOdrTtl3TmBfBlDmd
            //締次更新実行年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //CAddUpUpdExecDate
            //締次更新開始年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //StartCAddUpUpdDate
            //前回締次更新年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //LastCAddUpUpdDate
            //売上伝票枚数
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCount
            //請求書発行日
            serInfo.MemberInfo.Add(typeof(Int32)); //BillPrintDate
            //入金予定日
            serInfo.MemberInfo.Add(typeof(Int32)); //ExpectedDepositDate
            //回収条件
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectCond
            //消費税転嫁方式
            serInfo.MemberInfo.Add(typeof(Int32)); //ConsTaxLayMethod
            //消費税率
            serInfo.MemberInfo.Add(typeof(Double)); //ConsTaxRate
            //端数処理区分
            serInfo.MemberInfo.Add(typeof(Int32)); //FractionProcCd
            // ADD 2009/06/18 >>>
            //請求処理通番
            serInfo.MemberInfo.Add(typeof(Int32)); //BillNo
            // ADD 2009/06/18 <<<
            // --- ADD m.suzuki 2010/07/21 ---------->>>>>
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ExtractStartDate
            // --- ADD m.suzuki 2010/07/21 ----------<<<<<
            //----- ADD 2013/08/08 汪権来 Redmine#35552 速度改善 ------------------->>>>>
            serInfo.MemberInfo.Add(typeof(Double)); //FractionProcUnit
            serInfo.MemberInfo.Add(typeof(Double)); //Salesouttax_s
            serInfo.MemberInfo.Add(typeof(Double)); //Retsalesouttax_s
            serInfo.MemberInfo.Add(typeof(Double)); //Dissaleouttax_s
            serInfo.MemberInfo.Add(typeof(Int64)); //Salesouttax_d
            serInfo.MemberInfo.Add(typeof(Int64)); //Retsalesouttax_d
            serInfo.MemberInfo.Add(typeof(Int64)); //Dissaleouttax_d
            serInfo.MemberInfo.Add(typeof(Int64)); //Salesouttax_m
            serInfo.MemberInfo.Add(typeof(Int64)); //Retsalesouttax_m
            serInfo.MemberInfo.Add(typeof(Int64)); //Dissaleouttax_m
            serInfo.MemberInfo.Add(typeof(Int32)); //Collectmoneycode
            serInfo.MemberInfo.Add(typeof(Int32)); //Collectmoneyday
            serInfo.MemberInfo.Add(typeof(Double)); //Dissalesouttax_s
            serInfo.MemberInfo.Add(typeof(Double)); //Salesouttax_s2
            serInfo.MemberInfo.Add(typeof(Double)); //Retsalesouttax_s2
            serInfo.MemberInfo.Add(typeof(Double)); //Dissalesouttax_s2
            serInfo.MemberInfo.Add(typeof(Int64)); //Dissalesouttax_d
            serInfo.MemberInfo.Add(typeof(Int64)); //Dissalesouttax_m
            //----- ADD 2013/08/08 汪権来 Redmine#35552 速度改善 -------------------<<<<<
            serInfo.Serialize(writer, serInfo);
            if (graph is CustDmdPrcWork)
            {
                CustDmdPrcWork temp = (CustDmdPrcWork)graph;

                SetCustDmdPrcWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CustDmdPrcWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CustDmdPrcWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CustDmdPrcWork temp in lst)
                {
                    SetCustDmdPrcWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CustDmdPrcWorkメンバ数(publicプロパティ数)
        /// </summary>
        // --- UPD m.suzuki 2010/07/21 ---------->>>>>
        //private const int currentMemberCount = 69;
        //private const int currentMemberCount = 70;//DEL 2013/08/08 汪権来 Redmine#35552 速度改善
        // --- UPD m.suzuki 2010/07/21 ----------<<<<<
        private const int currentMemberCount = 88;//ADD 2013/08/08 汪権来 Redmine#35552 速度改善 
        /// <summary>
        ///  CustDmdPrcWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustDmdPrcWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetCustDmdPrcWork(System.IO.BinaryWriter writer, CustDmdPrcWork temp)
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
            //計上拠点コード
            writer.Write(temp.AddUpSecCode);
            //請求先コード
            writer.Write(temp.ClaimCode);
            //請求先名称
            writer.Write(temp.ClaimName);
            //請求先名称2
            writer.Write(temp.ClaimName2);
            //請求先略称
            writer.Write(temp.ClaimSnm);
            //実績拠点コード
            writer.Write(temp.ResultsSectCd);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先名称
            writer.Write(temp.CustomerName);
            //得意先名称2
            writer.Write(temp.CustomerName2);
            //得意先略称
            writer.Write(temp.CustomerSnm);
            //計上年月日
            writer.Write((Int64)temp.AddUpDate.Ticks);
            //計上年月
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //前回請求金額
            writer.Write(temp.LastTimeDemand);
            //今回手数料額（通常入金）
            writer.Write(temp.ThisTimeFeeDmdNrml);
            //今回値引額（通常入金）
            writer.Write(temp.ThisTimeDisDmdNrml);
            //今回入金金額（通常入金）
            writer.Write(temp.ThisTimeDmdNrml);
            //今回繰越残高（請求計）
            writer.Write(temp.ThisTimeTtlBlcDmd);
            //相殺後今回売上金額
            writer.Write(temp.OfsThisTimeSales);
            //相殺後今回売上消費税
            writer.Write(temp.OfsThisSalesTax);
            //相殺後外税対象額
            writer.Write(temp.ItdedOffsetOutTax);
            //相殺後内税対象額
            writer.Write(temp.ItdedOffsetInTax);
            //相殺後非課税対象額
            writer.Write(temp.ItdedOffsetTaxFree);
            //相殺後外税消費税
            writer.Write(temp.OffsetOutTax);
            //相殺後内税消費税
            writer.Write(temp.OffsetInTax);
            //今回売上金額
            writer.Write(temp.ThisTimeSales);
            //今回売上消費税
            writer.Write(temp.ThisSalesTax);
            //売上外税対象額
            writer.Write(temp.ItdedSalesOutTax);
            //売上内税対象額
            writer.Write(temp.ItdedSalesInTax);
            //売上非課税対象額
            writer.Write(temp.ItdedSalesTaxFree);
            //売上外税額
            writer.Write(temp.SalesOutTax);
            //売上内税額
            writer.Write(temp.SalesInTax);
            //今回売上返品金額
            writer.Write(temp.ThisSalesPricRgds);
            //今回売上返品消費税
            writer.Write(temp.ThisSalesPrcTaxRgds);
            //返品外税対象額合計
            writer.Write(temp.TtlItdedRetOutTax);
            //返品内税対象額合計
            writer.Write(temp.TtlItdedRetInTax);
            //返品非課税対象額合計
            writer.Write(temp.TtlItdedRetTaxFree);
            //返品外税額合計
            writer.Write(temp.TtlRetOuterTax);
            //返品内税額合計
            writer.Write(temp.TtlRetInnerTax);
            //今回売上値引金額
            writer.Write(temp.ThisSalesPricDis);
            //今回売上値引消費税
            writer.Write(temp.ThisSalesPrcTaxDis);
            //値引外税対象額合計
            writer.Write(temp.TtlItdedDisOutTax);
            //値引内税対象額合計
            writer.Write(temp.TtlItdedDisInTax);
            //値引非課税対象額合計
            writer.Write(temp.TtlItdedDisTaxFree);
            //値引外税額合計
            writer.Write(temp.TtlDisOuterTax);
            //値引内税額合計
            writer.Write(temp.TtlDisInnerTax);
            //消費税調整額
            writer.Write(temp.TaxAdjust);
            //残高調整額
            writer.Write(temp.BalanceAdjust);
            //計算後請求金額
            writer.Write(temp.AfCalDemandPrice);
            //受注2回前残高（請求計）
            writer.Write(temp.AcpOdrTtl2TmBfBlDmd);
            //受注3回前残高（請求計）
            writer.Write(temp.AcpOdrTtl3TmBfBlDmd);
            //締次更新実行年月日
            writer.Write((Int64)temp.CAddUpUpdExecDate.Ticks);
            //締次更新開始年月日
            writer.Write((Int64)temp.StartCAddUpUpdDate.Ticks);
            //前回締次更新年月日
            writer.Write((Int64)temp.LastCAddUpUpdDate.Ticks);
            //売上伝票枚数
            writer.Write(temp.SalesSlipCount);
            //請求書発行日
            writer.Write((Int64)temp.BillPrintDate.Ticks);
            //入金予定日
            writer.Write((Int64)temp.ExpectedDepositDate.Ticks);
            //回収条件
            writer.Write(temp.CollectCond);
            //消費税転嫁方式
            writer.Write(temp.ConsTaxLayMethod);
            //消費税率
            writer.Write(temp.ConsTaxRate);
            //端数処理区分
            writer.Write(temp.FractionProcCd);
            // ADD 2009/06/18 >>>
            //請求処理通番
            writer.Write(temp.BillNo);
            // ADD 2009/06/18 <<<
            // --- ADD m.suzuki 2010/07/21 ---------->>>>>
            //抽出開始日
            writer.Write( (Int64)temp.ExtractStartDate.Ticks );
            // --- ADD m.suzuki 2010/07/21 ----------<<<<<
            //----- ADD 2013/08/08 汪権来 Redmine#35552 速度改善 ------------------->>>>>
            writer.Write(temp.FractionProcUnit);
            writer.Write(temp.Salesouttax_s);
            writer.Write(temp.Retsalesouttax_s);
            writer.Write(temp.Dissaleouttax_s);
            writer.Write((Int64)temp.Salesouttax_d);
            writer.Write((Int64)temp.Retsalesouttax_d);
            writer.Write((Int64)temp.Dissaleouttax_d);
            writer.Write((Int64)temp.Salesouttax_m);
            writer.Write((Int64)temp.Retsalesouttax_m);
            writer.Write((Int64)temp.Dissaleouttax_m);
            writer.Write(temp.Collectmoneycode);
            writer.Write(temp.Collectmoneyday);
            writer.Write(temp.Dissalesouttax_s);
            writer.Write(temp.Salesouttax_s2);
            writer.Write(temp.Retsalesouttax_s2);
            writer.Write(temp.Dissalesouttax_s2);
            writer.Write((Int64)temp.Dissalesouttax_d);
            writer.Write((Int64)temp.Dissalesouttax_m);
            //----- ADD 2013/08/08 汪権来 Redmine#35552 速度改善 -------------------<<<<<
            
        }

        /// <summary>
        ///  CustDmdPrcWorkインスタンス取得
        /// </summary>
        /// <returns>CustDmdPrcWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustDmdPrcWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private CustDmdPrcWork GetCustDmdPrcWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            CustDmdPrcWork temp = new CustDmdPrcWork();

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
            //計上拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //請求先コード
            temp.ClaimCode = reader.ReadInt32();
            //請求先名称
            temp.ClaimName = reader.ReadString();
            //請求先名称2
            temp.ClaimName2 = reader.ReadString();
            //請求先略称
            temp.ClaimSnm = reader.ReadString();
            //実績拠点コード
            temp.ResultsSectCd = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先名称
            temp.CustomerName = reader.ReadString();
            //得意先名称2
            temp.CustomerName2 = reader.ReadString();
            //得意先略称
            temp.CustomerSnm = reader.ReadString();
            //計上年月日
            temp.AddUpDate = new DateTime(reader.ReadInt64());
            //計上年月
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //前回請求金額
            temp.LastTimeDemand = reader.ReadInt64();
            //今回手数料額（通常入金）
            temp.ThisTimeFeeDmdNrml = reader.ReadInt64();
            //今回値引額（通常入金）
            temp.ThisTimeDisDmdNrml = reader.ReadInt64();
            //今回入金金額（通常入金）
            temp.ThisTimeDmdNrml = reader.ReadInt64();
            //今回繰越残高（請求計）
            temp.ThisTimeTtlBlcDmd = reader.ReadInt64();
            //相殺後今回売上金額
            temp.OfsThisTimeSales = reader.ReadInt64();
            //相殺後今回売上消費税
            temp.OfsThisSalesTax = reader.ReadInt64();
            //相殺後外税対象額
            temp.ItdedOffsetOutTax = reader.ReadInt64();
            //相殺後内税対象額
            temp.ItdedOffsetInTax = reader.ReadInt64();
            //相殺後非課税対象額
            temp.ItdedOffsetTaxFree = reader.ReadInt64();
            //相殺後外税消費税
            temp.OffsetOutTax = reader.ReadInt64();
            //相殺後内税消費税
            temp.OffsetInTax = reader.ReadInt64();
            //今回売上金額
            temp.ThisTimeSales = reader.ReadInt64();
            //今回売上消費税
            temp.ThisSalesTax = reader.ReadInt64();
            //売上外税対象額
            temp.ItdedSalesOutTax = reader.ReadInt64();
            //売上内税対象額
            temp.ItdedSalesInTax = reader.ReadInt64();
            //売上非課税対象額
            temp.ItdedSalesTaxFree = reader.ReadInt64();
            //売上外税額
            temp.SalesOutTax = reader.ReadInt64();
            //売上内税額
            temp.SalesInTax = reader.ReadInt64();
            //今回売上返品金額
            temp.ThisSalesPricRgds = reader.ReadInt64();
            //今回売上返品消費税
            temp.ThisSalesPrcTaxRgds = reader.ReadInt64();
            //返品外税対象額合計
            temp.TtlItdedRetOutTax = reader.ReadInt64();
            //返品内税対象額合計
            temp.TtlItdedRetInTax = reader.ReadInt64();
            //返品非課税対象額合計
            temp.TtlItdedRetTaxFree = reader.ReadInt64();
            //返品外税額合計
            temp.TtlRetOuterTax = reader.ReadInt64();
            //返品内税額合計
            temp.TtlRetInnerTax = reader.ReadInt64();
            //今回売上値引金額
            temp.ThisSalesPricDis = reader.ReadInt64();
            //今回売上値引消費税
            temp.ThisSalesPrcTaxDis = reader.ReadInt64();
            //値引外税対象額合計
            temp.TtlItdedDisOutTax = reader.ReadInt64();
            //値引内税対象額合計
            temp.TtlItdedDisInTax = reader.ReadInt64();
            //値引非課税対象額合計
            temp.TtlItdedDisTaxFree = reader.ReadInt64();
            //値引外税額合計
            temp.TtlDisOuterTax = reader.ReadInt64();
            //値引内税額合計
            temp.TtlDisInnerTax = reader.ReadInt64();
            //消費税調整額
            temp.TaxAdjust = reader.ReadInt64();
            //残高調整額
            temp.BalanceAdjust = reader.ReadInt64();
            //計算後請求金額
            temp.AfCalDemandPrice = reader.ReadInt64();
            //受注2回前残高（請求計）
            temp.AcpOdrTtl2TmBfBlDmd = reader.ReadInt64();
            //受注3回前残高（請求計）
            temp.AcpOdrTtl3TmBfBlDmd = reader.ReadInt64();
            //締次更新実行年月日
            temp.CAddUpUpdExecDate = new DateTime(reader.ReadInt64());
            //締次更新開始年月日
            temp.StartCAddUpUpdDate = new DateTime(reader.ReadInt64());
            //前回締次更新年月日
            temp.LastCAddUpUpdDate = new DateTime(reader.ReadInt64());
            //売上伝票枚数
            temp.SalesSlipCount = reader.ReadInt32();
            //請求書発行日
            temp.BillPrintDate = new DateTime(reader.ReadInt64());
            //入金予定日
            temp.ExpectedDepositDate = new DateTime(reader.ReadInt64());
            //回収条件
            temp.CollectCond = reader.ReadInt32();
            //消費税転嫁方式
            temp.ConsTaxLayMethod = reader.ReadInt32();
            //消費税率
            temp.ConsTaxRate = reader.ReadDouble();
            //端数処理区分
            temp.FractionProcCd = reader.ReadInt32();
            // ADD 2009/06/18 >>>
            //請求処理通番
            temp.BillNo = reader.ReadInt32();
            // ADD 2009/06/18 <<<
            // --- ADD m.suzuki 2010/07/21 ---------->>>>>
            //抽出開始日
            temp.ExtractStartDate = new DateTime( reader.ReadInt64() );
            // --- ADD m.suzuki 2010/07/21 ----------<<<<<
            //----- ADD 2013/08/08 汪権来 Redmine#35552 速度改善 ------------------->>>>>
            temp.FractionProcUnit = reader.ReadDouble();
            temp.Salesouttax_s = reader.ReadDouble();
            temp.Retsalesouttax_s = reader.ReadDouble();
            temp.Dissaleouttax_s = reader.ReadDouble();
            temp.Salesouttax_d = reader.ReadInt64();
            temp.Retsalesouttax_d = reader.ReadInt64();
            temp.Dissaleouttax_d = reader.ReadInt64();
            temp.Salesouttax_m = reader.ReadInt64();
            temp.Retsalesouttax_m = reader.ReadInt64();
            temp.Dissaleouttax_m = reader.ReadInt64();
            temp.Collectmoneycode = reader.ReadInt32();
            temp.Collectmoneyday = reader.ReadInt32();
            temp.Dissalesouttax_s = reader.ReadDouble();
            temp.Salesouttax_s2 = reader.ReadDouble();
            temp.Retsalesouttax_s2 = reader.ReadDouble();
            temp.Dissalesouttax_s2 = reader.ReadDouble();
            temp.Dissalesouttax_d = reader.ReadInt64();
            temp.Dissalesouttax_m = reader.ReadInt64();
            //----- ADD 2013/08/08 汪権来 Redmine#35552 速度改善 -------------------<<<<<
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
        /// <returns>CustDmdPrcWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustDmdPrcWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CustDmdPrcWork temp = GetCustDmdPrcWork(reader, serInfo);
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
                    retValue = (CustDmdPrcWork[])lst.ToArray(typeof(CustDmdPrcWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
