//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : キャンペーン実績表
// プログラム概要   : キャンペーン実績表抽出結果クラスワーク
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2011/05/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CampaignstRsltListResultWork
    /// <summary>
    ///                      キャンペーン実績表抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   キャンペーン実績表ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011/05/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CampaignstRsltListResultWork : IFileHeader
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

        /// <summary>キャンペーンコード</summary>
        private Int32 _campaignCode;

        /// <summary>キャンペーン名称</summary>
        private string _campaignName = "";

        /// <summary>実績計上拠点コード</summary>
        /// <remarks>実績計上を行う企業内の拠点コード</remarks>
        private string _resultsAddUpSecCd = "";

        /// <summary>管理拠点コード</summary>
        private string _manageSectionCode = "";

        /// <summary>管理拠点略称</summary>
        private string _manageSectionSnm = "";

        /// <summary>拠点ガイド略称</summary>
        /// <remarks>帳票印字用</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>販売従業員コード</summary>
        /// <remarks>計上担当者</remarks>
        private string _salesEmployeeCd = "";

        /// <summary>販売エリアコード</summary>
        /// <remarks>地区別用</remarks>
        private Int32 _salesAreaCode;

        /// <summary>ユーザーガイド名称</summary>
        /// <remarks>地区別用</remarks>
        private string _guideName = "";

        /// <summary>キャンペーン対象区分</summary>
        /// <remarks>0:全得意先 1:対象得意先 2:中止</remarks>
        private Int32 _campaignObjDiv;

        /// <summary>適用開始日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _applyStaDate;

        /// <summary>適用終了日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _applyEndDate;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品名称カナ</summary>
        private string _goodsNameKana = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品コード名称（半角）</summary>
        private string _bLGoodsHalfName = "";

        /// <summary>BLグループコード</summary>
        /// <remarks>旧グループコード</remarks>
        private Int32 _bLGroupCode;

        /// <summary>BLグループコードカナ名称</summary>
        /// <remarks>半角カナ</remarks>
        private string _bLGroupKanaName = "";

        /// <summary>従業員コード</summary>
        private string _employeeCode = "";

        /// <summary>従業員名称</summary>
        private string _employeeName = "";

        /// <summary>対象日付期間出荷数</summary>
        private Double _addUpShipmentCnt;

        /// <summary>対象日付期間売上金額（税抜き）</summary>
        private Int64 _addUpSalesMoneyTaxExc;

        /// <summary>対象日付期間粗利金額</summary>
        private Int64 _addUpSalesProfit;

        /// <summary>キャンペーン期間出荷数</summary>
        private Double _campaignShipmentCnt;

        /// <summary>キャンペーン期間売上金額（税抜き）</summary>
        private Int64 _campaignSalesMoneyTaxExc;

        /// <summary>キャンペーン期間粗利金額</summary>
        private Int64 _campaignSalesProfit;

        /// <summary>月計売上金額（税抜き）１</summary>
        private Int64 _salesMoneyTaxExc1;

        /// <summary>月計売上金額（税抜き）２</summary>
        private Int64 _salesMoneyTaxExc2;

        /// <summary>月計売上金額（税抜き）３</summary>
        private Int64 _salesMoneyTaxExc3;

        /// <summary>月計売上金額（税抜き）４</summary>
        private Int64 _salesMoneyTaxExc4;

        /// <summary>月計売上金額（税抜き）５</summary>
        private Int64 _salesMoneyTaxExc5;

        /// <summary>月計売上金額（税抜き）６</summary>
        private Int64 _salesMoneyTaxExc6;

        /// <summary>月計売上金額（税抜き）７</summary>
        private Int64 _salesMoneyTaxExc7;

        /// <summary>月計売上金額（税抜き）８</summary>
        private Int64 _salesMoneyTaxExc8;

        /// <summary>月計売上金額（税抜き）９</summary>
        private Int64 _salesMoneyTaxExc9;

        /// <summary>月計売上金額（税抜き）１０</summary>
        private Int64 _salesMoneyTaxExc10;

        /// <summary>月計売上金額（税抜き）１１</summary>
        private Int64 _salesMoneyTaxExc11;

        /// <summary>月計売上金額（税抜き）１２</summary>
        private Int64 _salesMoneyTaxExc12;

        /// <summary>月計出荷数１</summary>
        private Double _totalSalesCount1;

        /// <summary>月計出荷数２</summary>
        private Double _totalSalesCount2;

        /// <summary>月計出荷数３</summary>
        private Double _totalSalesCount3;

        /// <summary>月計出荷数４</summary>
        private Double _totalSalesCount4;

        /// <summary>月計出荷数５</summary>
        private Double _totalSalesCount5;

        /// <summary>月計出荷数６</summary>
        private Double _totalSalesCount6;

        /// <summary>月計出荷数７</summary>
        private Double _totalSalesCount7;

        /// <summary>月計出荷数８</summary>
        private Double _totalSalesCount8;

        /// <summary>月計出荷数９</summary>
        private Double _totalSalesCount9;

        /// <summary>月計出荷数１０</summary>
        private Double _totalSalesCount10;

        /// <summary>月計出荷数１１</summary>
        private Double _totalSalesCount11;

        /// <summary>月計出荷数１２</summary>
        private Double _totalSalesCount12;

        /// <summary>月計粗利額１</summary>
        private Int64 _salesProfit1;

        /// <summary>月計粗利額２</summary>
        private Int64 _salesProfit2;

        /// <summary>月計粗利額３</summary>
        private Int64 _salesProfit3;

        /// <summary>月計粗利額４</summary>
        private Int64 _salesProfit4;

        /// <summary>月計粗利額５</summary>
        private Int64 _salesProfit5;

        /// <summary>月計粗利額６</summary>
        private Int64 _salesProfit6;

        /// <summary>月計粗利額７</summary>
        private Int64 _salesProfit7;

        /// <summary>月計粗利額８</summary>
        private Int64 _salesProfit8;

        /// <summary>月計粗利額９</summary>
        private Int64 _salesProfit9;

        /// <summary>月計粗利額１０</summary>
        private Int64 _salesProfit10;

        /// <summary>月計粗利額１１</summary>
        private Int64 _salesProfit11;

        /// <summary>月計粗利額１２</summary>
        private Int64 _salesProfit12;

        /// <summary>目標対比区分</summary>
        /// <remarks>10:拠点,22:拠点+従業員,30:拠点+得意先,32:拠点+販売ｴﾘｱ,44:拠点+販売区分,50:拠点+ｸﾞﾙｰﾌﾟｺｰﾄﾞ,60:拠点+BLｺｰﾄﾞ</remarks>
        private Int32 _targetContrastCd;

        /// <summary>売上目標金額1</summary>
        /// <remarks>1月</remarks>
        private Int64 _salesTargetMoney1;

        /// <summary>売上目標金額2</summary>
        /// <remarks>2月</remarks>
        private Int64 _salesTargetMoney2;

        /// <summary>売上目標金額3</summary>
        /// <remarks>3月</remarks>
        private Int64 _salesTargetMoney3;

        /// <summary>売上目標金額4</summary>
        /// <remarks>4月</remarks>
        private Int64 _salesTargetMoney4;

        /// <summary>売上目標金額5</summary>
        /// <remarks>5月</remarks>
        private Int64 _salesTargetMoney5;

        /// <summary>売上目標金額6</summary>
        /// <remarks>6月</remarks>
        private Int64 _salesTargetMoney6;

        /// <summary>売上目標金額7</summary>
        /// <remarks>7月</remarks>
        private Int64 _salesTargetMoney7;

        /// <summary>売上目標金額8</summary>
        /// <remarks>8月</remarks>
        private Int64 _salesTargetMoney8;

        /// <summary>売上目標金額9</summary>
        /// <remarks>9月</remarks>
        private Int64 _salesTargetMoney9;

        /// <summary>売上目標金額10</summary>
        /// <remarks>10月</remarks>
        private Int64 _salesTargetMoney10;

        /// <summary>売上目標金額11</summary>
        /// <remarks>11月</remarks>
        private Int64 _salesTargetMoney11;

        /// <summary>売上目標金額12</summary>
        /// <remarks>12月</remarks>
        private Int64 _salesTargetMoney12;

        /// <summary>月間売上目標金額</summary>
        private Int64 _monthlySalesTarget;

        /// <summary>売上期間目標金額</summary>
        private Int64 _termSalesTarget;

        /// <summary>売上目標粗利額1</summary>
        /// <remarks>1月</remarks>
        private Int64 _salesTargetProfit1;

        /// <summary>売上目標粗利額2</summary>
        /// <remarks>2月</remarks>
        private Int64 _salesTargetProfit2;

        /// <summary>売上目標粗利額3</summary>
        /// <remarks>3月</remarks>
        private Int64 _salesTargetProfit3;

        /// <summary>売上目標粗利額4</summary>
        /// <remarks>4月</remarks>
        private Int64 _salesTargetProfit4;

        /// <summary>売上目標粗利額5</summary>
        /// <remarks>5月</remarks>
        private Int64 _salesTargetProfit5;

        /// <summary>売上目標粗利額6</summary>
        /// <remarks>6月</remarks>
        private Int64 _salesTargetProfit6;

        /// <summary>売上目標粗利額7</summary>
        /// <remarks>7月</remarks>
        private Int64 _salesTargetProfit7;

        /// <summary>売上目標粗利額8</summary>
        /// <remarks>8月</remarks>
        private Int64 _salesTargetProfit8;

        /// <summary>売上目標粗利額9</summary>
        /// <remarks>9月</remarks>
        private Int64 _salesTargetProfit9;

        /// <summary>売上目標粗利額10</summary>
        /// <remarks>10月</remarks>
        private Int64 _salesTargetProfit10;

        /// <summary>売上目標粗利額11</summary>
        /// <remarks>11月</remarks>
        private Int64 _salesTargetProfit11;

        /// <summary>売上目標粗利額12</summary>
        /// <remarks>12月</remarks>
        private Int64 _salesTargetProfit12;

        /// <summary>売上月間目標粗利額</summary>
        private Int64 _monthlySalesTargetProfit;

        /// <summary>売上期間目標粗利額</summary>
        private Int64 _termSalesTargetProfit;

        /// <summary>売上目標数量1</summary>
        /// <remarks>1月</remarks>
        private Double _salesTargetCount1;

        /// <summary>売上目標数量2</summary>
        /// <remarks>2月</remarks>
        private Double _salesTargetCount2;

        /// <summary>売上目標数量3</summary>
        /// <remarks>3月</remarks>
        private Double _salesTargetCount3;

        /// <summary>売上目標数量4</summary>
        /// <remarks>4月</remarks>
        private Double _salesTargetCount4;

        /// <summary>売上目標数量5</summary>
        /// <remarks>5月</remarks>
        private Double _salesTargetCount5;

        /// <summary>売上目標数量6</summary>
        /// <remarks>6月</remarks>
        private Double _salesTargetCount6;

        /// <summary>売上目標数量7</summary>
        /// <remarks>7月</remarks>
        private Double _salesTargetCount7;

        /// <summary>売上目標数量8</summary>
        /// <remarks>8月</remarks>
        private Double _salesTargetCount8;

        /// <summary>売上目標数量9</summary>
        /// <remarks>9月</remarks>
        private Double _salesTargetCount9;

        /// <summary>売上目標数量10</summary>
        /// <remarks>10月</remarks>
        private Double _salesTargetCount10;

        /// <summary>売上目標数量11</summary>
        /// <remarks>11月</remarks>
        private Double _salesTargetCount11;

        /// <summary>売上目標数量12</summary>
        /// <remarks>12月</remarks>
        private Double _salesTargetCount12;

        /// <summary>売上月間目標数量</summary>
        private Double _monthlySalesTargetCount;

        /// <summary>売上期間目標数量</summary>
        private Double _termSalesTargetCount;


        /// <summary>月間売上目標金額1</summary>
        private Int64 _monthlySalesTarget1;

        /// <summary>売上期間目標金額1</summary>
        private Int64 _termSalesTarget1;

        /// <summary>売上月間目標粗利額1</summary>
        private Int64 _monthlySalesTargetProfit1;

        /// <summary>売上期間目標粗利額1</summary>
        private Int64 _termSalesTargetProfit1;

        /// <summary>売上月間目標数量1</summary>
        private Double _monthlySalesTargetCount1;

        /// <summary>担売上期間目標数量1</summary>
        private Double _termSalesTargetCount1;

        /// <summary>月間売上目標金額2</summary>
        private Int64 _monthlySalesTarget2;

        /// <summary>売上期間目標金額2</summary>
        private Int64 _termSalesTarget2;

        /// <summary>売上月間目標粗利額2</summary>
        private Int64 _monthlySalesTargetProfit2;

        /// <summary>売上期間目標粗利額2</summary>
        private Int64 _termSalesTargetProfit2;

        /// <summary>売上月間目標数量2</summary>
        private Double _monthlySalesTargetCount2;

        /// <summary>売上期間目標数量2</summary>
        private Double _termSalesTargetCount2;

        /// <summary>月間売上目標金額3</summary>
        private Int64 _monthlySalesTarget3;

        /// <summary>売上期間目標金額3</summary>
        private Int64 _termSalesTarget3;

        /// <summary>売上月間目標粗利額3</summary>
        private Int64 _monthlySalesTargetProfit3;

        /// <summary>売上期間目標粗利額3</summary>
        private Int64 _termSalesTargetProfit3;

        /// <summary>売上月間目標数量3</summary>
        private Double _monthlySalesTargetCount3;

        /// <summary>売上上期間目標数量3</summary>
        private Double _termSalesTargetCount3;

        /// <summary>出荷数</summary>
        private Double _shipmentCnt;

        /// <summary>売上金額（税抜き）</summary>
        private Int64 _salesMoneyTaxExc;

        /// <summary>粗利金額</summary>
        private Int64 _salesProfit;

        /// <summary>計上日</summary>
        private DateTime _salesDate;

        /// <summary>売上伝票区分（明細）</summary>
        private Int32 _salesSlipCdDtl;

        /// public propaty name  :  SalesSlipCdDtl
        /// <summary>売上伝票区分（明細）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票区分（明細）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipCdDtl
        {
            get { return _salesSlipCdDtl; }
            set { _salesSlipCdDtl = value; }
        }


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

        /// public propaty name  :  CampaignCode
        /// <summary>キャンペーンコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーンコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CampaignCode
        {
            get { return _campaignCode; }
            set { _campaignCode = value; }
        }

        /// public propaty name  :  CampaignName
        /// <summary>キャンペーン名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーン名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CampaignName
        {
            get { return _campaignName; }
            set { _campaignName = value; }
        }

        /// public propaty name  :  ResultsAddUpSecCd
        /// <summary>実績計上拠点コードプロパティ</summary>
        /// <value>実績計上拠点コードを行う企業内の拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   実績計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ResultsAddUpSecCd
        {
            get { return _resultsAddUpSecCd; }
            set { _resultsAddUpSecCd = value; }
        }

        /// public propaty name  :  ManageSectionCode
        /// <summary>管理拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   管理拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ManageSectionCode
        {
            get { return _manageSectionCode; }
            set { _manageSectionCode = value; }
        }

        /// public propaty name  :  ManageSectionSnm
        /// <summary>管理拠点略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   管理拠点略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ManageSectionSnm
        {
            get { return _manageSectionSnm; }
            set { _manageSectionSnm = value; }
        }

        /// public propaty name  :  SectionGuideSnm
        /// <summary>拠点ガイド略称プロパティ</summary>
        /// <value>帳票印字用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
        }

        /// public propaty name  :  SalesEmployeeCd
        /// <summary>販売従業員コードプロパティ</summary>
        /// <value>計上担当者</value>
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

        /// public propaty name  :  SalesAreaCode
        /// <summary>販売エリアコードプロパティ</summary>
        /// <value>地区別用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリアコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  SalesAreaCode
        /// <summary>ユーザーガイド名称プロパティ</summary>
        /// <value>地区別用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ユーザーガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GuideName
        {
            get { return _guideName; }
            set { _guideName = value; }
        }

        /// public propaty name  :  CampaignObjDiv
        /// <summary>キャンペーン対象区分プロパティ</summary>
        /// <value>0:全得意先 1:対象得意先 2:中止</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーン対象区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CampaignObjDiv
        {
            get { return _campaignObjDiv; }
            set { _campaignObjDiv = value; }
        }

        /// public propaty name  :  ApplyStaDate
        /// <summary>適用開始日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ApplyStaDate
        {
            get { return _applyStaDate; }
            set { _applyStaDate = value; }
        }

        /// public propaty name  :  ApplyEndDate
        /// <summary>適用終了日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用終了日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ApplyEndDate
        {
            get { return _applyEndDate; }
            set { _applyEndDate = value; }
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

        /// public propaty name  :  GoodsNameKana
        /// <summary>商品名称カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
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

        /// public propaty name  :  MakerName
        /// <summary>メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  BLGoodsHalfName
        /// <summary>BL商品コード名称（半角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（半角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsHalfName
        {
            get { return _bLGoodsHalfName; }
            set { _bLGoodsHalfName = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BLグループコードプロパティ</summary>
        /// <value>旧グループコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  BLGroupKanaName
        /// <summary>BLグループコードカナ名称プロパティ</summary>
        /// <value>半角カナ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードカナ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGroupKanaName
        {
            get { return _bLGroupKanaName; }
            set { _bLGroupKanaName = value; }
        }

        /// public propaty name  :  EmployeeCode
        /// <summary>従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        /// public propaty name  :  EmployeeName
        /// <summary>従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }

        /// public propaty name  :  AddUpShipmentCnt
        /// <summary>対象日付期間出荷数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   対象日付期間出荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AddUpShipmentCnt
        {
            get { return _addUpShipmentCnt; }
            set { _addUpShipmentCnt = value; }
        }

        /// public propaty name  :  AddUpSalesMoneyTaxExc
        /// <summary>対象日付期間売上金額（税抜き）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   対象日付期間売上金額（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AddUpSalesMoneyTaxExc
        {
            get { return _addUpSalesMoneyTaxExc; }
            set { _addUpSalesMoneyTaxExc = value; }
        }

        /// public propaty name  :  AddUpSalesProfit
        /// <summary>対象日付期間粗利金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   対象日付期間粗利金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AddUpSalesProfit
        {
            get { return _addUpSalesProfit; }
            set { _addUpSalesProfit = value; }
        }

        /// public propaty name  :  CampaignShipmentCnt
        /// <summary>キャンペーン期間出荷数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーン期間出荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double CampaignShipmentCnt
        {
            get { return _campaignShipmentCnt; }
            set { _campaignShipmentCnt = value; }
        }

        /// public propaty name  :  CampaignSalesMoneyTaxExc
        /// <summary>キャンペーン期間売上金額（税抜き）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーン期間売上金額（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CampaignSalesMoneyTaxExc
        {
            get { return _campaignSalesMoneyTaxExc; }
            set { _campaignSalesMoneyTaxExc = value; }
        }

        /// public propaty name  :  CampaignSalesProfit
        /// <summary>キャンペーン期間粗利金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーン期間粗利金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CampaignSalesProfit
        {
            get { return _campaignSalesProfit; }
            set { _campaignSalesProfit = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc1
        /// <summary>月計売上金額（税抜き）１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計売上金額（税抜き）１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc1
        {
            get { return _salesMoneyTaxExc1; }
            set { _salesMoneyTaxExc1 = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc2
        /// <summary>月計売上金額（税抜き）２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計売上金額（税抜き）２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc2
        {
            get { return _salesMoneyTaxExc2; }
            set { _salesMoneyTaxExc2 = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc3
        /// <summary>月計売上金額（税抜き）３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計売上金額（税抜き）３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc3
        {
            get { return _salesMoneyTaxExc3; }
            set { _salesMoneyTaxExc3 = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc4
        /// <summary>月計売上金額（税抜き）４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計売上金額（税抜き）４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc4
        {
            get { return _salesMoneyTaxExc4; }
            set { _salesMoneyTaxExc4 = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc5
        /// <summary>月計売上金額（税抜き）５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計売上金額（税抜き）５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc5
        {
            get { return _salesMoneyTaxExc5; }
            set { _salesMoneyTaxExc5 = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc6
        /// <summary>月計売上金額（税抜き）６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計売上金額（税抜き）６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc6
        {
            get { return _salesMoneyTaxExc6; }
            set { _salesMoneyTaxExc6 = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc7
        /// <summary>月計売上金額（税抜き）７プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計売上金額（税抜き）７プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc7
        {
            get { return _salesMoneyTaxExc7; }
            set { _salesMoneyTaxExc7 = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc8
        /// <summary>月計売上金額（税抜き）８プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計売上金額（税抜き）８プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc8
        {
            get { return _salesMoneyTaxExc8; }
            set { _salesMoneyTaxExc8 = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc9
        /// <summary>月計売上金額（税抜き）９プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計売上金額（税抜き）９プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc9
        {
            get { return _salesMoneyTaxExc9; }
            set { _salesMoneyTaxExc9 = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc10
        /// <summary>月計売上金額（税抜き）１０プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計売上金額（税抜き）１０プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc10
        {
            get { return _salesMoneyTaxExc10; }
            set { _salesMoneyTaxExc10 = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc11
        /// <summary>月計売上金額（税抜き）１１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計売上金額（税抜き）１１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc11
        {
            get { return _salesMoneyTaxExc11; }
            set { _salesMoneyTaxExc11 = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc12
        /// <summary>月計売上金額（税抜き）１２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計売上金額（税抜き）１２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc12
        {
            get { return _salesMoneyTaxExc12; }
            set { _salesMoneyTaxExc12 = value; }
        }

        /// public propaty name  :  TotalSalesCount1
        /// <summary>月計出荷数１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計出荷数１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalSalesCount1
        {
            get { return _totalSalesCount1; }
            set { _totalSalesCount1 = value; }
        }

        /// public propaty name  :  TotalSalesCount2
        /// <summary>月計出荷数２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計出荷数２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalSalesCount2
        {
            get { return _totalSalesCount2; }
            set { _totalSalesCount2 = value; }
        }

        /// public propaty name  :  TotalSalesCount3
        /// <summary>月計出荷数３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計出荷数３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalSalesCount3
        {
            get { return _totalSalesCount3; }
            set { _totalSalesCount3 = value; }
        }

        /// public propaty name  :  TotalSalesCount4
        /// <summary>月計出荷数４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計出荷数４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalSalesCount4
        {
            get { return _totalSalesCount4; }
            set { _totalSalesCount4 = value; }
        }

        /// public propaty name  :  TotalSalesCount5
        /// <summary>月計出荷数５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計出荷数５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalSalesCount5
        {
            get { return _totalSalesCount5; }
            set { _totalSalesCount5 = value; }
        }

        /// public propaty name  :  TotalSalesCount6
        /// <summary>月計出荷数６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計出荷数６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalSalesCount6
        {
            get { return _totalSalesCount6; }
            set { _totalSalesCount6 = value; }
        }

        /// public propaty name  :  TotalSalesCount7
        /// <summary>月計出荷数７プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計出荷数７プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalSalesCount7
        {
            get { return _totalSalesCount7; }
            set { _totalSalesCount7 = value; }
        }

        /// public propaty name  :  TotalSalesCount8
        /// <summary>月計出荷数８プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計出荷数８プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalSalesCount8
        {
            get { return _totalSalesCount8; }
            set { _totalSalesCount8 = value; }
        }

        /// public propaty name  :  TotalSalesCount9
        /// <summary>月計出荷数９プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計出荷数９プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalSalesCount9
        {
            get { return _totalSalesCount9; }
            set { _totalSalesCount9 = value; }
        }

        /// public propaty name  :  TotalSalesCount10
        /// <summary>月計出荷数１０プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計出荷数１０プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalSalesCount10
        {
            get { return _totalSalesCount10; }
            set { _totalSalesCount10 = value; }
        }

        /// public propaty name  :  TotalSalesCount11
        /// <summary>月計出荷数１１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計出荷数１１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalSalesCount11
        {
            get { return _totalSalesCount11; }
            set { _totalSalesCount11 = value; }
        }

        /// public propaty name  :  TotalSalesCount12
        /// <summary>月計出荷数１２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計出荷数１２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalSalesCount12
        {
            get { return _totalSalesCount12; }
            set { _totalSalesCount12 = value; }
        }

        /// public propaty name  :  SalesProfit1
        /// <summary>月計粗利額１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計粗利額１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesProfit1
        {
            get { return _salesProfit1; }
            set { _salesProfit1 = value; }
        }

        /// public propaty name  :  SalesProfit2
        /// <summary>月計粗利額２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計粗利額２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesProfit2
        {
            get { return _salesProfit2; }
            set { _salesProfit2 = value; }
        }

        /// public propaty name  :  SalesProfit3
        /// <summary>月計粗利額３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計粗利額３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesProfit3
        {
            get { return _salesProfit3; }
            set { _salesProfit3 = value; }
        }

        /// public propaty name  :  SalesProfit4
        /// <summary>月計粗利額４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計粗利額４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesProfit4
        {
            get { return _salesProfit4; }
            set { _salesProfit4 = value; }
        }

        /// public propaty name  :  SalesProfit5
        /// <summary>月計粗利額５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計粗利額５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesProfit5
        {
            get { return _salesProfit5; }
            set { _salesProfit5 = value; }
        }

        /// public propaty name  :  SalesProfit6
        /// <summary>月計粗利額６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計粗利額６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesProfit6
        {
            get { return _salesProfit6; }
            set { _salesProfit6 = value; }
        }

        /// public propaty name  :  SalesProfit7
        /// <summary>月計粗利額７プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計粗利額７プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesProfit7
        {
            get { return _salesProfit7; }
            set { _salesProfit7 = value; }
        }

        /// public propaty name  :  SalesProfit8
        /// <summary>月計粗利額８プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計粗利額８プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesProfit8
        {
            get { return _salesProfit8; }
            set { _salesProfit8 = value; }
        }

        /// public propaty name  :  SalesProfit9
        /// <summary>月計粗利額９プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計粗利額９プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesProfit9
        {
            get { return _salesProfit9; }
            set { _salesProfit9 = value; }
        }

        /// public propaty name  :  SalesProfit10
        /// <summary>月計粗利額１０プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計粗利額１０プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesProfit10
        {
            get { return _salesProfit10; }
            set { _salesProfit10 = value; }
        }

        /// public propaty name  :  SalesProfit11
        /// <summary>月計粗利額１１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計粗利額１１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesProfit11
        {
            get { return _salesProfit11; }
            set { _salesProfit11 = value; }
        }

        /// public propaty name  :  SalesProfit12
        /// <summary>月計粗利額１２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月計粗利額１２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesProfit12
        {
            get { return _salesProfit12; }
            set { _salesProfit12 = value; }
        }

        /// public propaty name  :  TargetContrastCd
        /// <summary>目標対比区分プロパティ</summary>
        /// <value>10:拠点,22:拠点+従業員,30:拠点+得意先,32:拠点+販売ｴﾘｱ,44:拠点+販売区分,50:拠点+ｸﾞﾙｰﾌﾟｺｰﾄﾞ,60:拠点+BLｺｰﾄﾞ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   目標対比区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TargetContrastCd
        {
            get { return _targetContrastCd; }
            set { _targetContrastCd = value; }
        }

        /// public propaty name  :  SalesTargetMoney1
        /// <summary>売上目標金額1プロパティ</summary>
        /// <value>1月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney1
        {
            get { return _salesTargetMoney1; }
            set { _salesTargetMoney1 = value; }
        }

        /// public propaty name  :  SalesTargetMoney2
        /// <summary>売上目標金額2プロパティ</summary>
        /// <value>2月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney2
        {
            get { return _salesTargetMoney2; }
            set { _salesTargetMoney2 = value; }
        }

        /// public propaty name  :  SalesTargetMoney3
        /// <summary>売上目標金額3プロパティ</summary>
        /// <value>3月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney3
        {
            get { return _salesTargetMoney3; }
            set { _salesTargetMoney3 = value; }
        }

        /// public propaty name  :  SalesTargetMoney4
        /// <summary>売上目標金額4プロパティ</summary>
        /// <value>4月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney4
        {
            get { return _salesTargetMoney4; }
            set { _salesTargetMoney4 = value; }
        }

        /// public propaty name  :  SalesTargetMoney5
        /// <summary>売上目標金額5プロパティ</summary>
        /// <value>5月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney5
        {
            get { return _salesTargetMoney5; }
            set { _salesTargetMoney5 = value; }
        }

        /// public propaty name  :  SalesTargetMoney6
        /// <summary>売上目標金額6プロパティ</summary>
        /// <value>6月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney6
        {
            get { return _salesTargetMoney6; }
            set { _salesTargetMoney6 = value; }
        }

        /// public propaty name  :  SalesTargetMoney7
        /// <summary>売上目標金額7プロパティ</summary>
        /// <value>7月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney7
        {
            get { return _salesTargetMoney7; }
            set { _salesTargetMoney7 = value; }
        }

        /// public propaty name  :  SalesTargetMoney8
        /// <summary>売上目標金額8プロパティ</summary>
        /// <value>8月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney8
        {
            get { return _salesTargetMoney8; }
            set { _salesTargetMoney8 = value; }
        }

        /// public propaty name  :  SalesTargetMoney9
        /// <summary>売上目標金額9プロパティ</summary>
        /// <value>9月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney9
        {
            get { return _salesTargetMoney9; }
            set { _salesTargetMoney9 = value; }
        }

        /// public propaty name  :  SalesTargetMoney10
        /// <summary>売上目標金額10プロパティ</summary>
        /// <value>10月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney10
        {
            get { return _salesTargetMoney10; }
            set { _salesTargetMoney10 = value; }
        }

        /// public propaty name  :  SalesTargetMoney11
        /// <summary>売上目標金額11プロパティ</summary>
        /// <value>11月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額11プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney11
        {
            get { return _salesTargetMoney11; }
            set { _salesTargetMoney11 = value; }
        }

        /// public propaty name  :  SalesTargetMoney12
        /// <summary>売上目標金額12プロパティ</summary>
        /// <value>12月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額12プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney12
        {
            get { return _salesTargetMoney12; }
            set { _salesTargetMoney12 = value; }
        }

        /// public propaty name  :  MonthlySalesTarget
        /// <summary>月間売上目標金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月間売上目標金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthlySalesTarget
        {
            get { return _monthlySalesTarget; }
            set { _monthlySalesTarget = value; }
        }

        /// public propaty name  :  TermSalesTarget
        /// <summary>売上期間目標金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上期間目標金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TermSalesTarget
        {
            get { return _termSalesTarget; }
            set { _termSalesTarget = value; }
        }

        /// public propaty name  :  SalesTargetProfit1
        /// <summary>売上目標粗利額1プロパティ</summary>
        /// <value>1月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit1
        {
            get { return _salesTargetProfit1; }
            set { _salesTargetProfit1 = value; }
        }

        /// public propaty name  :  SalesTargetProfit2
        /// <summary>売上目標粗利額2プロパティ</summary>
        /// <value>2月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit2
        {
            get { return _salesTargetProfit2; }
            set { _salesTargetProfit2 = value; }
        }

        /// public propaty name  :  SalesTargetProfit3
        /// <summary>売上目標粗利額3プロパティ</summary>
        /// <value>3月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit3
        {
            get { return _salesTargetProfit3; }
            set { _salesTargetProfit3 = value; }
        }

        /// public propaty name  :  SalesTargetProfit4
        /// <summary>売上目標粗利額4プロパティ</summary>
        /// <value>4月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit4
        {
            get { return _salesTargetProfit4; }
            set { _salesTargetProfit4 = value; }
        }

        /// public propaty name  :  SalesTargetProfit5
        /// <summary>売上目標粗利額5プロパティ</summary>
        /// <value>5月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit5
        {
            get { return _salesTargetProfit5; }
            set { _salesTargetProfit5 = value; }
        }

        /// public propaty name  :  SalesTargetProfit6
        /// <summary>売上目標粗利額6プロパティ</summary>
        /// <value>6月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit6
        {
            get { return _salesTargetProfit6; }
            set { _salesTargetProfit6 = value; }
        }

        /// public propaty name  :  SalesTargetProfit7
        /// <summary>売上目標粗利額7プロパティ</summary>
        /// <value>7月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit7
        {
            get { return _salesTargetProfit7; }
            set { _salesTargetProfit7 = value; }
        }

        /// public propaty name  :  SalesTargetProfit8
        /// <summary>売上目標粗利額8プロパティ</summary>
        /// <value>8月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit8
        {
            get { return _salesTargetProfit8; }
            set { _salesTargetProfit8 = value; }
        }

        /// public propaty name  :  SalesTargetProfit9
        /// <summary>売上目標粗利額9プロパティ</summary>
        /// <value>9月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit9
        {
            get { return _salesTargetProfit9; }
            set { _salesTargetProfit9 = value; }
        }

        /// public propaty name  :  SalesTargetProfit10
        /// <summary>売上目標粗利額10プロパティ</summary>
        /// <value>10月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit10
        {
            get { return _salesTargetProfit10; }
            set { _salesTargetProfit10 = value; }
        }

        /// public propaty name  :  SalesTargetProfit11
        /// <summary>売上目標粗利額11プロパティ</summary>
        /// <value>11月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額11プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit11
        {
            get { return _salesTargetProfit11; }
            set { _salesTargetProfit11 = value; }
        }

        /// public propaty name  :  SalesTargetProfit12
        /// <summary>売上目標粗利額12プロパティ</summary>
        /// <value>12月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額12プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit12
        {
            get { return _salesTargetProfit12; }
            set { _salesTargetProfit12 = value; }
        }

        /// public propaty name  :  MonthlySalesTargetProfit
        /// <summary>売上月間目標粗利額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上月間目標粗利額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthlySalesTargetProfit
        {
            get { return _monthlySalesTargetProfit; }
            set { _monthlySalesTargetProfit = value; }
        }

        /// public propaty name  :  TermSalesTargetProfit
        /// <summary>売上期間目標粗利額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上期間目標粗利額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TermSalesTargetProfit
        {
            get { return _termSalesTargetProfit; }
            set { _termSalesTargetProfit = value; }
        }

        /// public propaty name  :  SalesTargetCount1
        /// <summary>売上目標数量1プロパティ</summary>
        /// <value>1月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標数量1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesTargetCount1
        {
            get { return _salesTargetCount1; }
            set { _salesTargetCount1 = value; }
        }

        /// public propaty name  :  SalesTargetCount2
        /// <summary>売上目標数量2プロパティ</summary>
        /// <value>2月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標数量2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesTargetCount2
        {
            get { return _salesTargetCount2; }
            set { _salesTargetCount2 = value; }
        }

        /// public propaty name  :  SalesTargetCount3
        /// <summary>売上目標数量3プロパティ</summary>
        /// <value>3月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標数量3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesTargetCount3
        {
            get { return _salesTargetCount3; }
            set { _salesTargetCount3 = value; }
        }

        /// public propaty name  :  SalesTargetCount4
        /// <summary>売上目標数量4プロパティ</summary>
        /// <value>4月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標数量4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesTargetCount4
        {
            get { return _salesTargetCount4; }
            set { _salesTargetCount4 = value; }
        }

        /// public propaty name  :  SalesTargetCount5
        /// <summary>売上目標数量5プロパティ</summary>
        /// <value>5月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標数量5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesTargetCount5
        {
            get { return _salesTargetCount5; }
            set { _salesTargetCount5 = value; }
        }

        /// public propaty name  :  SalesTargetCount6
        /// <summary>売上目標数量6プロパティ</summary>
        /// <value>6月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標数量6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesTargetCount6
        {
            get { return _salesTargetCount6; }
            set { _salesTargetCount6 = value; }
        }

        /// public propaty name  :  SalesTargetCount7
        /// <summary>売上目標数量7プロパティ</summary>
        /// <value>7月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標数量7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesTargetCount7
        {
            get { return _salesTargetCount7; }
            set { _salesTargetCount7 = value; }
        }

        /// public propaty name  :  SalesTargetCount8
        /// <summary>売上目標数量8プロパティ</summary>
        /// <value>8月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標数量8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesTargetCount8
        {
            get { return _salesTargetCount8; }
            set { _salesTargetCount8 = value; }
        }

        /// public propaty name  :  SalesTargetCount9
        /// <summary>売上目標数量9プロパティ</summary>
        /// <value>9月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標数量9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesTargetCount9
        {
            get { return _salesTargetCount9; }
            set { _salesTargetCount9 = value; }
        }

        /// public propaty name  :  SalesTargetCount10
        /// <summary>売上目標数量10プロパティ</summary>
        /// <value>10月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標数量10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesTargetCount10
        {
            get { return _salesTargetCount10; }
            set { _salesTargetCount10 = value; }
        }

        /// public propaty name  :  SalesTargetCount11
        /// <summary>売上目標数量11プロパティ</summary>
        /// <value>11月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標数量11プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesTargetCount11
        {
            get { return _salesTargetCount11; }
            set { _salesTargetCount11 = value; }
        }

        /// public propaty name  :  SalesTargetCount12
        /// <summary>売上目標数量12プロパティ</summary>
        /// <value>12月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標数量12プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesTargetCount12
        {
            get { return _salesTargetCount12; }
            set { _salesTargetCount12 = value; }
        }

        /// public propaty name  :  MonthlySalesTargetCount
        /// <summary>売上月間目標数量プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上月間目標数量プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MonthlySalesTargetCount
        {
            get { return _monthlySalesTargetCount; }
            set { _monthlySalesTargetCount = value; }
        }

        /// public propaty name  :  TermSalesTargetCount
        /// <summary>売上期間目標数量プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上期間目標数量プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TermSalesTargetCount
        {
            get { return _termSalesTargetCount; }
            set { _termSalesTargetCount = value; }
        }

        //--------------------------------------------------------------------------------------------------

        /// public propaty name  :  MonthlySalesTarget1
        /// <summary>月間売上目標金額1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月間売上目標金額1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthlySalesTarget1
        {
            get { return _monthlySalesTarget1; }
            set { _monthlySalesTarget1 = value; }
        }

        /// public propaty name  :  TermSalesTarget1
        /// <summary>売上期間目標金額1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上期間目標金額1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TermSalesTarget1
        {
            get { return _termSalesTarget1; }
            set { _termSalesTarget1 = value; }
        }

        /// public propaty name  :  MonthlySalesTargetProfit1
        /// <summary>売上月間目標粗利額1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上月間目標粗利額1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthlySalesTargetProfit1
        {
            get { return _monthlySalesTargetProfit1; }
            set { _monthlySalesTargetProfit1 = value; }
        }
        /// public propaty name  :  TermSalesTargetProfit1
        /// <summary>売上期間目標粗利額1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上期間目標粗利プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TermSalesTargetProfit1
        {
            get { return _termSalesTargetProfit1; }
            set { _termSalesTargetProfit1 = value; }
        }

        /// public propaty name  :  MonthlySalesTargetCount1
        /// <summary>売上月間目標数量1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上月間目標数量1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MonthlySalesTargetCount1
        {
            get { return _monthlySalesTargetCount1; }
            set { _monthlySalesTargetCount1 = value; }
        }
        /// public propaty name  :  TermSalesTargetCount1
        /// <summary>売上期間目標数量1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上期間目標数量1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TermSalesTargetCount1
        {
            get { return _termSalesTargetCount1; }
            set { _termSalesTargetCount1 = value; }
        }

        /// public propaty name  :  MonthlySalesTarget2
        /// <summary>月間売上目標金額2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月間売上目標金額2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthlySalesTarget2
        {
            get { return _monthlySalesTarget2; }
            set { _monthlySalesTarget2 = value; }
        }
        /// public propaty name  :  TermSalesTarget2
        /// <summary>売上期間目標金額2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上期間目標金額2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TermSalesTarget2
        {
            get { return _termSalesTarget2; }
            set { _termSalesTarget2 = value; }
        }

        /// public propaty name  :  MonthlySalesTargetProfit2
        /// <summary>売上月間目標粗利額2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上月間目標粗利額2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthlySalesTargetProfit2
        {
            get { return _monthlySalesTargetProfit2; }
            set { _monthlySalesTargetProfit2 = value; }
        }
        /// public propaty name  :  TermSalesTargetProfit2
        /// <summary>売上期間目標粗利額2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上期間目標粗利額2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TermSalesTargetProfit2
        {
            get { return _termSalesTargetProfit2; }
            set { _termSalesTargetProfit2 = value; }
        }

        /// public propaty name  :  MonthlySalesTargetCount2
        /// <summary>売上月間目標数量2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上月間目標数量2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MonthlySalesTargetCount2
        {
            get { return _monthlySalesTargetCount2; }
            set { _monthlySalesTargetCount2 = value; }
        }
        /// public propaty name  :  TermSalesTargetCount2
        /// <summary>売上期間目標数量2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上期間目標数量2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TermSalesTargetCount2
        {
            get { return _termSalesTargetCount2; }
            set { _termSalesTargetCount2 = value; }
        }
        /// public propaty name  :  MonthlySalesTarget3
        /// <summary>月間小計目標金額3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月間小計目標金額3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthlySalesTarget3
        {
            get { return _monthlySalesTarget3; }
            set { _monthlySalesTarget3 = value; }
        }

        /// public propaty name  :  TermSalesTarget3
        /// <summary>小計期間目標金額3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   小計期間目標金額3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TermSalesTarget3
        {
            get { return _termSalesTarget3; }
            set { _termSalesTarget3 = value; }
        }

        /// public propaty name  :  MonthlySalesTargetProfit3
        /// <summary>小計月間目標粗利額3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   小計月間目標粗利額3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthlySalesTargetProfit3
        {
            get { return _monthlySalesTargetProfit3; }
            set { _monthlySalesTargetProfit3 = value; }
        }
        /// public propaty name  :  TermSalesTargetProfit3
        /// <summary>小計期間目標粗利額3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   小計期間目標粗利プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TermSalesTargetProfit3
        {
            get { return _termSalesTargetProfit3; }
            set { _termSalesTargetProfit3 = value; }
        }

        /// public propaty name  :  MonthlySalesTargetCount3
        /// <summary>小計月間目標数量3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   小計月間目標数量3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MonthlySalesTargetCount3
        {
            get { return _monthlySalesTargetCount3; }
            set { _monthlySalesTargetCount3 = value; }
        }
        /// public propaty name  :  TermSalesTargetCount3
        /// <summary>小計期間目標数量3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   小計期間目標数量3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TermSalesTargetCount3
        {
            get { return _termSalesTargetCount3; }
            set { _termSalesTargetCount3 = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>出荷数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>売上金額（税抜き）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc
        {
            get { return _salesMoneyTaxExc; }
            set { _salesMoneyTaxExc = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>粗利金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesProfit
        {
            get { return _salesProfit; }
            set { _salesProfit = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>計上日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// <summary>
        /// キャンペーン実績表ワークコンストラクタ
        /// </summary>
        /// <returns>CampaignstRsltListResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignstRsltListResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CampaignstRsltListResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CampaignstRsltListResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CampaignstRsltListResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class CampaignstRsltListResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignstRsltListResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CampaignstRsltListResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CampaignstRsltListResultWork || graph is ArrayList || graph is CampaignstRsltListResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CampaignstRsltListResultWork).FullName));

            if (graph != null && graph is CampaignstRsltListResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CampaignstRsltListResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CampaignstRsltListResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CampaignstRsltListResultWork[])graph).Length;
            }
            else if (graph is CampaignstRsltListResultWork)
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
            //キャンペーンコード
            serInfo.MemberInfo.Add(typeof(Int32)); //CampaignCode
            //キャンペーン名称
            serInfo.MemberInfo.Add(typeof(string)); //CampaignName
            //実績計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //ResultsAddUpSecCd
            //管理拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //ManageSectionCode
            //管理拠点略称
            serInfo.MemberInfo.Add(typeof(string)); //ManageSectionSnm
            //拠点ガイド略称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //販売従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeCd
            //販売エリアコード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //ユーザーガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //GuideName
            //キャンペーン対象区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CampaignObjDiv
            //適用開始日
            serInfo.MemberInfo.Add(typeof(Int32)); //ApplyStaDate
            //適用終了日
            serInfo.MemberInfo.Add(typeof(Int32)); //ApplyEndDate
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先略称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称カナ
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL商品コード名称（半角）
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsHalfName
            //BLグループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //BLグループコードカナ名称
            serInfo.MemberInfo.Add(typeof(string)); //BLGroupKanaName
            //従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            //従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeName
            //対象日付期間出荷数
            serInfo.MemberInfo.Add(typeof(Double)); //AddUpShipmentCnt
            //対象日付期間売上金額（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //AddUpSalesMoneyTaxExc
            //対象日付期間粗利金額
            serInfo.MemberInfo.Add(typeof(Int64)); //AddUpSalesProfit
            //キャンペーン期間出荷数
            serInfo.MemberInfo.Add(typeof(Double)); //CampaignShipmentCnt
            //キャンペーン期間売上金額（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //CampaignSalesMoneyTaxExc
            //キャンペーン期間粗利金額
            serInfo.MemberInfo.Add(typeof(Int64)); //CampaignSalesProfit
            //月計売上金額（税抜き）１
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc1
            //月計売上金額（税抜き）２
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc2
            //月計売上金額（税抜き）３
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc3
            //月計売上金額（税抜き）４
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc4
            //月計売上金額（税抜き）５
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc5
            //月計売上金額（税抜き）６
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc6
            //月計売上金額（税抜き）７
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc7
            //月計売上金額（税抜き）８
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc8
            //月計売上金額（税抜き）９
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc9
            //月計売上金額（税抜き）１０
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc10
            //月計売上金額（税抜き）１１
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc11
            //月計売上金額（税抜き）１２
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc12
            //月計出荷数１
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount1
            //月計出荷数２
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount2
            //月計出荷数３
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount3
            //月計出荷数４
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount4
            //月計出荷数５
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount5
            //月計出荷数６
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount6
            //月計出荷数７
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount7
            //月計出荷数８
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount8
            //月計出荷数９
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount9
            //月計出荷数１０
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount10
            //月計出荷数１１
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount11
            //月計出荷数１２
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount12
            //月計粗利額１
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesProfit1
            //月計粗利額２
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesProfit2
            //月計粗利額３
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesProfit3
            //月計粗利額４
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesProfit4
            //月計粗利額５
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesProfit5
            //月計粗利額６
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesProfit6
            //月計粗利額７
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesProfit7
            //月計粗利額８
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesProfit8
            //月計粗利額９
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesProfit9
            //月計粗利額１０
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesProfit10
            //月計粗利額１１
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesProfit11
            //月計粗利額１２
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesProfit12
            //目標対比区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TargetContrastCd
            //売上目標金額1
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney1
            //売上目標金額2
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney2
            //売上目標金額3
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney3
            //売上目標金額4
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney4
            //売上目標金額5
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney5
            //売上目標金額6
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney6
            //売上目標金額7
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney7
            //売上目標金額8
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney8
            //売上目標金額9
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney9
            //売上目標金額10
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney10
            //売上目標金額11
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney11
            //売上目標金額12
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney12
            //月間売上目標金額
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthlySalesTarget
            //売上期間目標金額
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesTarget
            //売上目標粗利額1
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit1
            //売上目標粗利額2
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit2
            //売上目標粗利額3
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit3
            //売上目標粗利額4
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit4
            //売上目標粗利額5
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit5
            //売上目標粗利額6
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit6
            //売上目標粗利額7
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit7
            //売上目標粗利額8
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit8
            //売上目標粗利額9
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit9
            //売上目標粗利額10
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit10
            //売上目標粗利額11
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit11
            //売上目標粗利額12
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit12
            //売上月間目標粗利額
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthlySalesTargetProfit
            //売上期間目標粗利額
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesTargetProfit
            //売上目標数量1
            serInfo.MemberInfo.Add(typeof(Double)); //SalesTargetCount1
            //売上目標数量2
            serInfo.MemberInfo.Add(typeof(Double)); //SalesTargetCount2
            //売上目標数量3
            serInfo.MemberInfo.Add(typeof(Double)); //SalesTargetCount3
            //売上目標数量4
            serInfo.MemberInfo.Add(typeof(Double)); //SalesTargetCount4
            //売上目標数量5
            serInfo.MemberInfo.Add(typeof(Double)); //SalesTargetCount5
            //売上目標数量6
            serInfo.MemberInfo.Add(typeof(Double)); //SalesTargetCount6
            //売上目標数量7
            serInfo.MemberInfo.Add(typeof(Double)); //SalesTargetCount7
            //売上目標数量8
            serInfo.MemberInfo.Add(typeof(Double)); //SalesTargetCount8
            //売上目標数量9
            serInfo.MemberInfo.Add(typeof(Double)); //SalesTargetCount9
            //売上目標数量10
            serInfo.MemberInfo.Add(typeof(Double)); //SalesTargetCount10
            //売上目標数量11
            serInfo.MemberInfo.Add(typeof(Double)); //SalesTargetCount11
            //売上目標数量12
            serInfo.MemberInfo.Add(typeof(Double)); //SalesTargetCount12
            //売上月間目標数量
            serInfo.MemberInfo.Add(typeof(Double)); //MonthlySalesTargetCount
            //売上期間目標数量
            serInfo.MemberInfo.Add(typeof(Double)); //TermSalesTargetCount

            //担当者用月間売上目標金額
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthlySalesTarget1
            //担当者用売上期間目標金額
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesTarget1
            //担当者用売上月間目標粗利額
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthlySalesTargetProfit1
            //担当者用売上期間目標粗利額
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesTargetProfit1
            //担当者用売上月間目標数量
            serInfo.MemberInfo.Add(typeof(Double)); //MonthlySalesTargetCount1
            //担当者用売上期間目標数量
            serInfo.MemberInfo.Add(typeof(Double)); //TermSalesTargetCount1
            //拠点用月間売上目標金額
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthlySalesTarget2
            //拠点用売上期間目標金額
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesTarget2
            //拠点用売上月間目標粗利額
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthlySalesTargetProfit2
            //拠点用売上期間目標粗利額
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesTargetProfit2
            //拠点用売上月間目標数量
            serInfo.MemberInfo.Add(typeof(Double)); //MonthlySalesTargetCount2
            //拠点用売上期間目標数量
            serInfo.MemberInfo.Add(typeof(Double)); //TermSalesTargetCount2
            //小計用月間売上目標金額
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthlySalesTarget3
            //小計用売上期間目標金額
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesTarget3
            //小計用売上月間目標粗利額
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthlySalesTargetProfit3
            //小計用売上期間目標粗利額
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesTargetProfit3
            //小計用売上月間目標数量
            serInfo.MemberInfo.Add(typeof(Double)); //MonthlySalesTargetCount3 _salesSlipCdDtl
            //小計用売上期間目標数量
            serInfo.MemberInfo.Add(typeof(Double)); //TermSalesTargetCount3
            //売上伝票区分（明細）
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCdDtl


            serInfo.Serialize(writer, serInfo);
            if (graph is CampaignstRsltListResultWork)
            {
                CampaignstRsltListResultWork temp = (CampaignstRsltListResultWork)graph;

                SetCampaignstRsltListResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CampaignstRsltListResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CampaignstRsltListResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CampaignstRsltListResultWork temp in lst)
                {
                    SetCampaignstRsltListResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CampaignstRsltListResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 140;

        /// <summary>
        ///  CampaignstRsltListResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignstRsltListResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetCampaignstRsltListResultWork(System.IO.BinaryWriter writer, CampaignstRsltListResultWork temp)
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
            //キャンペーンコード
            writer.Write(temp.CampaignCode);
            //キャンペーン名称
            writer.Write(temp.CampaignName);
            //実績計上拠点コード
            writer.Write(temp.ResultsAddUpSecCd);
            //管理拠点コード
            writer.Write(temp.ManageSectionCode);
            //管理拠点略称
            writer.Write(temp.ManageSectionSnm);
            //拠点ガイド略称
            writer.Write(temp.SectionGuideSnm);
            //販売従業員コード
            writer.Write(temp.SalesEmployeeCd);
            //販売エリアコード
            writer.Write(temp.SalesAreaCode);
            //ユーザーガイド名称
            writer.Write(temp.GuideName);
            //キャンペーン対象区分
            writer.Write(temp.CampaignObjDiv);
            //適用開始日
            writer.Write(temp.ApplyStaDate);
            //適用終了日
            writer.Write(temp.ApplyEndDate);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先略称
            writer.Write(temp.CustomerSnm);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称カナ
            writer.Write(temp.GoodsNameKana);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //メーカー名称
            writer.Write(temp.MakerName);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //BL商品コード名称（半角）
            writer.Write(temp.BLGoodsHalfName);
            //BLグループコード
            writer.Write(temp.BLGroupCode);
            //BLグループコードカナ名称
            writer.Write(temp.BLGroupKanaName);
            //従業員コード
            writer.Write(temp.EmployeeCode);
            //従業員名称
            writer.Write(temp.EmployeeName);
            //対象日付期間出荷数
            writer.Write(temp.AddUpShipmentCnt);
            //対象日付期間売上金額（税抜き）
            writer.Write(temp.AddUpSalesMoneyTaxExc);
            //対象日付期間粗利金額
            writer.Write(temp.AddUpSalesProfit);
            //キャンペーン期間出荷数
            writer.Write(temp.CampaignShipmentCnt);
            //キャンペーン期間売上金額（税抜き）
            writer.Write(temp.CampaignSalesMoneyTaxExc);
            //キャンペーン期間粗利金額
            writer.Write(temp.CampaignSalesProfit);
            //月計売上金額（税抜き）１
            writer.Write(temp.SalesMoneyTaxExc1);
            //月計売上金額（税抜き）２
            writer.Write(temp.SalesMoneyTaxExc2);
            //月計売上金額（税抜き）３
            writer.Write(temp.SalesMoneyTaxExc3);
            //月計売上金額（税抜き）４
            writer.Write(temp.SalesMoneyTaxExc4);
            //月計売上金額（税抜き）５
            writer.Write(temp.SalesMoneyTaxExc5);
            //月計売上金額（税抜き）６
            writer.Write(temp.SalesMoneyTaxExc6);
            //月計売上金額（税抜き）７
            writer.Write(temp.SalesMoneyTaxExc7);
            //月計売上金額（税抜き）８
            writer.Write(temp.SalesMoneyTaxExc8);
            //月計売上金額（税抜き）９
            writer.Write(temp.SalesMoneyTaxExc9);
            //月計売上金額（税抜き）１０
            writer.Write(temp.SalesMoneyTaxExc10);
            //月計売上金額（税抜き）１１
            writer.Write(temp.SalesMoneyTaxExc11);
            //月計売上金額（税抜き）１２
            writer.Write(temp.SalesMoneyTaxExc12);
            //月計出荷数１
            writer.Write(temp.TotalSalesCount1);
            //月計出荷数２
            writer.Write(temp.TotalSalesCount2);
            //月計出荷数３
            writer.Write(temp.TotalSalesCount3);
            //月計出荷数４
            writer.Write(temp.TotalSalesCount4);
            //月計出荷数５
            writer.Write(temp.TotalSalesCount5);
            //月計出荷数６
            writer.Write(temp.TotalSalesCount6);
            //月計出荷数７
            writer.Write(temp.TotalSalesCount7);
            //月計出荷数８
            writer.Write(temp.TotalSalesCount8);
            //月計出荷数９
            writer.Write(temp.TotalSalesCount9);
            //月計出荷数１０
            writer.Write(temp.TotalSalesCount10);
            //月計出荷数１１
            writer.Write(temp.TotalSalesCount11);
            //月計出荷数１２
            writer.Write(temp.TotalSalesCount12);
            //月計粗利額１
            writer.Write(temp.SalesProfit1);
            //月計粗利額２
            writer.Write(temp.SalesProfit2);
            //月計粗利額３
            writer.Write(temp.SalesProfit3);
            //月計粗利額４
            writer.Write(temp.SalesProfit4);
            //月計粗利額５
            writer.Write(temp.SalesProfit5);
            //月計粗利額６
            writer.Write(temp.SalesProfit6);
            //月計粗利額７
            writer.Write(temp.SalesProfit7);
            //月計粗利額８
            writer.Write(temp.SalesProfit8);
            //月計粗利額９
            writer.Write(temp.SalesProfit9);
            //月計粗利額１０
            writer.Write(temp.SalesProfit10);
            //月計粗利額１１
            writer.Write(temp.SalesProfit11);
            //月計粗利額１２
            writer.Write(temp.SalesProfit12);
            //目標対比区分
            writer.Write(temp.TargetContrastCd);
            //売上目標金額1
            writer.Write(temp.SalesTargetMoney1);
            //売上目標金額2
            writer.Write(temp.SalesTargetMoney2);
            //売上目標金額3
            writer.Write(temp.SalesTargetMoney3);
            //売上目標金額4
            writer.Write(temp.SalesTargetMoney4);
            //売上目標金額5
            writer.Write(temp.SalesTargetMoney5);
            //売上目標金額6
            writer.Write(temp.SalesTargetMoney6);
            //売上目標金額7
            writer.Write(temp.SalesTargetMoney7);
            //売上目標金額8
            writer.Write(temp.SalesTargetMoney8);
            //売上目標金額9
            writer.Write(temp.SalesTargetMoney9);
            //売上目標金額10
            writer.Write(temp.SalesTargetMoney10);
            //売上目標金額11
            writer.Write(temp.SalesTargetMoney11);
            //売上目標金額12
            writer.Write(temp.SalesTargetMoney12);
            //月間売上目標金額
            writer.Write(temp.MonthlySalesTarget);
            //売上期間目標金額
            writer.Write(temp.TermSalesTarget);
            //売上目標粗利額1
            writer.Write(temp.SalesTargetProfit1);
            //売上目標粗利額2
            writer.Write(temp.SalesTargetProfit2);
            //売上目標粗利額3
            writer.Write(temp.SalesTargetProfit3);
            //売上目標粗利額4
            writer.Write(temp.SalesTargetProfit4);
            //売上目標粗利額5
            writer.Write(temp.SalesTargetProfit5);
            //売上目標粗利額6
            writer.Write(temp.SalesTargetProfit6);
            //売上目標粗利額7
            writer.Write(temp.SalesTargetProfit7);
            //売上目標粗利額8
            writer.Write(temp.SalesTargetProfit8);
            //売上目標粗利額9
            writer.Write(temp.SalesTargetProfit9);
            //売上目標粗利額10
            writer.Write(temp.SalesTargetProfit10);
            //売上目標粗利額11
            writer.Write(temp.SalesTargetProfit11);
            //売上目標粗利額12
            writer.Write(temp.SalesTargetProfit12);
            //売上月間目標粗利額
            writer.Write(temp.MonthlySalesTargetProfit);
            //売上期間目標粗利額
            writer.Write(temp.TermSalesTargetProfit);
            //売上目標数量1
            writer.Write(temp.SalesTargetCount1);
            //売上目標数量2
            writer.Write(temp.SalesTargetCount2);
            //売上目標数量3
            writer.Write(temp.SalesTargetCount3);
            //売上目標数量4
            writer.Write(temp.SalesTargetCount4);
            //売上目標数量5
            writer.Write(temp.SalesTargetCount5);
            //売上目標数量6
            writer.Write(temp.SalesTargetCount6);
            //売上目標数量7
            writer.Write(temp.SalesTargetCount7);
            //売上目標数量8
            writer.Write(temp.SalesTargetCount8);
            //売上目標数量9
            writer.Write(temp.SalesTargetCount9);
            //売上目標数量10
            writer.Write(temp.SalesTargetCount10);
            //売上目標数量11
            writer.Write(temp.SalesTargetCount11);
            //売上目標数量12
            writer.Write(temp.SalesTargetCount12);
            //売上月間目標数量
            writer.Write(temp.MonthlySalesTargetCount);
            //売上期間目標数量
            writer.Write(temp.TermSalesTargetCount);

            //担当者用月間売上目標金額
            writer.Write(temp.MonthlySalesTarget1);
            //担当者用売上期間目標金額
            writer.Write(temp.TermSalesTarget1);
            //担当者用売上月間目標粗利額
            writer.Write(temp.MonthlySalesTargetProfit1);
            //担当者用売上期間目標粗利額
            writer.Write(temp.TermSalesTargetProfit1);
            //担当者用売上月間目標数量
            writer.Write(temp.MonthlySalesTargetCount1);
            //担当者用売上期間目標数量
            writer.Write(temp.TermSalesTargetCount1);
            //拠点用月間売上目標金額
            writer.Write(temp.MonthlySalesTarget2);
            //拠点用売上期間目標金額
            writer.Write(temp.TermSalesTarget2);
            //拠点用売上月間目標粗利額
            writer.Write(temp.MonthlySalesTargetProfit2);
            //拠点用売上期間目標粗利額
            writer.Write(temp.TermSalesTargetProfit2);
            //拠点用売上月間目標数量
            writer.Write(temp.MonthlySalesTargetCount2);
            //拠点用売上期間目標数量
            writer.Write(temp.TermSalesTargetCount2);
            //小計用月間売上目標金額
            writer.Write(temp.MonthlySalesTarget3);
            //小計用売上期間目標金額
            writer.Write(temp.TermSalesTarget3);
            //小計用売上月間目標粗利額
            writer.Write(temp.MonthlySalesTargetProfit3);
            //小計用売上期間目標粗利額
            writer.Write(temp.TermSalesTargetProfit3);
            //小計用売上月間目標数量
            writer.Write(temp.MonthlySalesTargetCount3);
            //小計用売上期間目標数量
            writer.Write(temp.TermSalesTargetCount3);
            //出荷数
            writer.Write(temp.ShipmentCnt);
            //売上金額（税抜き）
            writer.Write(temp.SalesMoneyTaxExc);
            //粗利金額
            writer.Write(temp.SalesProfit);
            //計上日
            writer.Write((Int64)temp.SalesDate.Ticks);
            //売上伝票区分（明細）
            writer.Write(temp.SalesSlipCdDtl);

        }

        /// <summary>
        ///  CampaignstRsltListResultWorkインスタンス取得
        /// </summary>
        /// <returns>CampaignstRsltListResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignstRsltListResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private CampaignstRsltListResultWork GetCampaignstRsltListResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            CampaignstRsltListResultWork temp = new CampaignstRsltListResultWork();

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
            //キャンペーンコード
            temp.CampaignCode = reader.ReadInt32();
            //キャンペーン名称
            temp.CampaignName = reader.ReadString();
            //実績計上拠点コード
            temp.ResultsAddUpSecCd = reader.ReadString();
            //管理拠点コード
            temp.ManageSectionCode = reader.ReadString();
            //管理拠点略称
            temp.ManageSectionSnm = reader.ReadString();
            //拠点ガイド略称
            temp.SectionGuideSnm = reader.ReadString();
            //販売従業員コード
            temp.SalesEmployeeCd = reader.ReadString();
            //販売エリアコード
            temp.SalesAreaCode = reader.ReadInt32();
            //ユーザーガイド名称
            temp.GuideName = reader.ReadString();
            //キャンペーン対象区分
            temp.CampaignObjDiv = reader.ReadInt32();
            //適用開始日
            temp.ApplyStaDate = reader.ReadInt32();
            //適用終了日
            temp.ApplyEndDate = reader.ReadInt32();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先略称
            temp.CustomerSnm = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称カナ
            temp.GoodsNameKana = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー名称
            temp.MakerName = reader.ReadString();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //BL商品コード名称（半角）
            temp.BLGoodsHalfName = reader.ReadString();
            //BLグループコード
            temp.BLGroupCode = reader.ReadInt32();
            //BLグループコードカナ名称
            temp.BLGroupKanaName = reader.ReadString();
            //従業員コード
            temp.EmployeeCode = reader.ReadString();
            //従業員名称
            temp.EmployeeName = reader.ReadString();
            //対象日付期間出荷数
            temp.AddUpShipmentCnt = reader.ReadDouble();
            //対象日付期間売上金額（税抜き）
            temp.AddUpSalesMoneyTaxExc = reader.ReadInt64();
            //対象日付期間粗利金額
            temp.AddUpSalesProfit = reader.ReadInt64();
            //キャンペーン期間出荷数
            temp.CampaignShipmentCnt = reader.ReadDouble();
            //キャンペーン期間売上金額（税抜き）
            temp.CampaignSalesMoneyTaxExc = reader.ReadInt64();
            //キャンペーン期間粗利金額
            temp.CampaignSalesProfit = reader.ReadInt64();
            //月計売上金額（税抜き）１
            temp.SalesMoneyTaxExc1 = reader.ReadInt64();
            //月計売上金額（税抜き）２
            temp.SalesMoneyTaxExc2 = reader.ReadInt64();
            //月計売上金額（税抜き）３
            temp.SalesMoneyTaxExc3 = reader.ReadInt64();
            //月計売上金額（税抜き）４
            temp.SalesMoneyTaxExc4 = reader.ReadInt64();
            //月計売上金額（税抜き）５
            temp.SalesMoneyTaxExc5 = reader.ReadInt64();
            //月計売上金額（税抜き）６
            temp.SalesMoneyTaxExc6 = reader.ReadInt64();
            //月計売上金額（税抜き）７
            temp.SalesMoneyTaxExc7 = reader.ReadInt64();
            //月計売上金額（税抜き）８
            temp.SalesMoneyTaxExc8 = reader.ReadInt64();
            //月計売上金額（税抜き）９
            temp.SalesMoneyTaxExc9 = reader.ReadInt64();
            //月計売上金額（税抜き）１０
            temp.SalesMoneyTaxExc10 = reader.ReadInt64();
            //月計売上金額（税抜き）１１
            temp.SalesMoneyTaxExc11 = reader.ReadInt64();
            //月計売上金額（税抜き）１２
            temp.SalesMoneyTaxExc12 = reader.ReadInt64();
            //月計出荷数１
            temp.TotalSalesCount1 = reader.ReadDouble();
            //月計出荷数２
            temp.TotalSalesCount2 = reader.ReadDouble();
            //月計出荷数３
            temp.TotalSalesCount3 = reader.ReadDouble();
            //月計出荷数４
            temp.TotalSalesCount4 = reader.ReadDouble();
            //月計出荷数５
            temp.TotalSalesCount5 = reader.ReadDouble();
            //月計出荷数６
            temp.TotalSalesCount6 = reader.ReadDouble();
            //月計出荷数７
            temp.TotalSalesCount7 = reader.ReadDouble();
            //月計出荷数８
            temp.TotalSalesCount8 = reader.ReadDouble();
            //月計出荷数９
            temp.TotalSalesCount9 = reader.ReadDouble();
            //月計出荷数１０
            temp.TotalSalesCount10 = reader.ReadDouble();
            //月計出荷数１１
            temp.TotalSalesCount11 = reader.ReadDouble();
            //月計出荷数１２
            temp.TotalSalesCount12 = reader.ReadDouble();
            //月計粗利額１
            temp.SalesProfit1 = reader.ReadInt64();
            //月計粗利額２
            temp.SalesProfit2 = reader.ReadInt64();
            //月計粗利額３
            temp.SalesProfit3 = reader.ReadInt64();
            //月計粗利額４
            temp.SalesProfit4 = reader.ReadInt64();
            //月計粗利額５
            temp.SalesProfit5 = reader.ReadInt64();
            //月計粗利額６
            temp.SalesProfit6 = reader.ReadInt64();
            //月計粗利額７
            temp.SalesProfit7 = reader.ReadInt64();
            //月計粗利額８
            temp.SalesProfit8 = reader.ReadInt64();
            //月計粗利額９
            temp.SalesProfit9 = reader.ReadInt64();
            //月計粗利額１０
            temp.SalesProfit10 = reader.ReadInt64();
            //月計粗利額１１
            temp.SalesProfit11 = reader.ReadInt64();
            //月計粗利額１２
            temp.SalesProfit12 = reader.ReadInt64();
            //目標対比区分
            temp.TargetContrastCd = reader.ReadInt32();
            //売上目標金額1
            temp.SalesTargetMoney1 = reader.ReadInt64();
            //売上目標金額2
            temp.SalesTargetMoney2 = reader.ReadInt64();
            //売上目標金額3
            temp.SalesTargetMoney3 = reader.ReadInt64();
            //売上目標金額4
            temp.SalesTargetMoney4 = reader.ReadInt64();
            //売上目標金額5
            temp.SalesTargetMoney5 = reader.ReadInt64();
            //売上目標金額6
            temp.SalesTargetMoney6 = reader.ReadInt64();
            //売上目標金額7
            temp.SalesTargetMoney7 = reader.ReadInt64();
            //売上目標金額8
            temp.SalesTargetMoney8 = reader.ReadInt64();
            //売上目標金額9
            temp.SalesTargetMoney9 = reader.ReadInt64();
            //売上目標金額10
            temp.SalesTargetMoney10 = reader.ReadInt64();
            //売上目標金額11
            temp.SalesTargetMoney11 = reader.ReadInt64();
            //売上目標金額12
            temp.SalesTargetMoney12 = reader.ReadInt64();
            //月間売上目標金額
            temp.MonthlySalesTarget = reader.ReadInt64();
            //売上期間目標金額
            temp.TermSalesTarget = reader.ReadInt64();
            //売上目標粗利額1
            temp.SalesTargetProfit1 = reader.ReadInt64();
            //売上目標粗利額2
            temp.SalesTargetProfit2 = reader.ReadInt64();
            //売上目標粗利額3
            temp.SalesTargetProfit3 = reader.ReadInt64();
            //売上目標粗利額4
            temp.SalesTargetProfit4 = reader.ReadInt64();
            //売上目標粗利額5
            temp.SalesTargetProfit5 = reader.ReadInt64();
            //売上目標粗利額6
            temp.SalesTargetProfit6 = reader.ReadInt64();
            //売上目標粗利額7
            temp.SalesTargetProfit7 = reader.ReadInt64();
            //売上目標粗利額8
            temp.SalesTargetProfit8 = reader.ReadInt64();
            //売上目標粗利額9
            temp.SalesTargetProfit9 = reader.ReadInt64();
            //売上目標粗利額10
            temp.SalesTargetProfit10 = reader.ReadInt64();
            //売上目標粗利額11
            temp.SalesTargetProfit11 = reader.ReadInt64();
            //売上目標粗利額12
            temp.SalesTargetProfit12 = reader.ReadInt64();
            //売上月間目標粗利額
            temp.MonthlySalesTargetProfit = reader.ReadInt64();
            //売上期間目標粗利額
            temp.TermSalesTargetProfit = reader.ReadInt64();
            //売上目標数量1
            temp.SalesTargetCount1 = reader.ReadDouble();
            //売上目標数量2
            temp.SalesTargetCount2 = reader.ReadDouble();
            //売上目標数量3
            temp.SalesTargetCount3 = reader.ReadDouble();
            //売上目標数量4
            temp.SalesTargetCount4 = reader.ReadDouble();
            //売上目標数量5
            temp.SalesTargetCount5 = reader.ReadDouble();
            //売上目標数量6
            temp.SalesTargetCount6 = reader.ReadDouble();
            //売上目標数量7
            temp.SalesTargetCount7 = reader.ReadDouble();
            //売上目標数量8
            temp.SalesTargetCount8 = reader.ReadDouble();
            //売上目標数量9
            temp.SalesTargetCount9 = reader.ReadDouble();
            //売上目標数量10
            temp.SalesTargetCount10 = reader.ReadDouble();
            //売上目標数量11
            temp.SalesTargetCount11 = reader.ReadDouble();
            //売上目標数量12
            temp.SalesTargetCount12 = reader.ReadDouble();
            //売上月間目標数量
            temp.MonthlySalesTargetCount = reader.ReadDouble();
            //売上期間目標数量
            temp.TermSalesTargetCount = reader.ReadDouble();

            //担当者用月間売上目標金額
            temp.MonthlySalesTarget1 = reader.ReadInt64();
            //担当者用売上期間目標金額
            temp.TermSalesTarget1 = reader.ReadInt64();
            //担当者用売上月間目標粗利額
            temp.MonthlySalesTargetProfit1 = reader.ReadInt64();
            //担当者用売上期間目標粗利額
            temp.TermSalesTargetProfit1 = reader.ReadInt64();
            //担当者用売上月間目標数量
            temp.MonthlySalesTargetCount1 = reader.ReadDouble();
            //担当者用売上期間目標数量
            temp.TermSalesTargetCount1 = reader.ReadDouble();
            //拠点用月間売上目標金額
            temp.MonthlySalesTarget2 = reader.ReadInt64();
            //拠点用売上期間目標金額
            temp.TermSalesTarget2 = reader.ReadInt64();
            //拠点用売上月間目標粗利額
            temp.MonthlySalesTargetProfit2 = reader.ReadInt64();
            //拠点用売上期間目標粗利額
            temp.TermSalesTargetProfit2 = reader.ReadInt64();
            //拠点用売上月間目標数量
            temp.MonthlySalesTargetCount2 = reader.ReadDouble();
            //拠点用売上期間目標数量
            temp.TermSalesTargetCount2 = reader.ReadDouble();
            //小計用月間売上目標金額
            temp.MonthlySalesTarget3 = reader.ReadInt64();
            //小計用売上期間目標金額
            temp.TermSalesTarget3 = reader.ReadInt64();
            //小計用売上月間目標粗利額
            temp.MonthlySalesTargetProfit3 = reader.ReadInt64();
            //小計用売上期間目標粗利額
            temp.TermSalesTargetProfit3 = reader.ReadInt64();
            //小計用売上月間目標数量
            temp.MonthlySalesTargetCount3 = reader.ReadDouble();
            //小計用売上期間目標数量
            temp.TermSalesTargetCount3 = reader.ReadDouble();
            //出荷数
            temp.ShipmentCnt = reader.ReadDouble();
            //売上金額（税抜き）
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //粗利金額
            temp.SalesProfit = reader.ReadInt64();
            //計上日
            temp.SalesDate = new DateTime(reader.ReadInt64());
            //売上伝票区分（明細）
            temp.SalesSlipCdDtl = reader.ReadInt32();


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
        /// <returns>CampaignstRsltListResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignstRsltListResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CampaignstRsltListResultWork temp = GetCampaignstRsltListResultWork(reader, serInfo);
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
                    retValue = (CampaignstRsltListResultWork[])lst.ToArray(typeof(CampaignstRsltListResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
