//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : キャンペーン目標設定マスタ
// プログラム概要   : キャンペーン目標設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 徐佳
// 作 成 日  2011/04/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CampaignTarget
    /// <summary>
    ///                      キャンペーン目標設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   キャンペーン目標設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011/04/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CampaignTarget
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
        /// <remarks>任意の無重複コードとする（自動付番はしない）</remarks>
        private Int32 _campaignCode;

        /// <summary>目標対比区分</summary>
        /// <remarks>10:拠点,22:拠点+従業員,30:拠点+得意先,32:拠点+販売ｴﾘｱ,44:拠点+販売区分,50:拠点+ｸﾞﾙｰﾌﾟｺｰﾄﾞ,60:拠点+BLｺｰﾄﾞ</remarks>
        private Int32 _targetContrastCd;

        /// <summary>従業員区分</summary>
        /// <remarks>10:販売担当者 20:受付担当者 30:入力担当者</remarks>
        private Int32 _employeeDivCd;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>従業員コード</summary>
        private string _employeeCode = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>販売エリアコード</summary>
        /// <remarks>地区コード</remarks>
        private Int32 _salesAreaCode;

        /// <summary>BLグループコード</summary>
        /// <remarks>旧グループコード</remarks>
        private Int32 _bLGroupCode;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>販売区分コード</summary>
        private Int32 _salesCode;

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

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";


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

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>作成日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>作成日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>作成日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>作成日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
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

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>更新日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>更新日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>更新日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>更新日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
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
        /// <value>任意の無重複コードとする（自動付番はしない）</value>
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

        /// public propaty name  :  EmployeeDivCd
        /// <summary>従業員区分プロパティ</summary>
        /// <value>10:販売担当者 20:受付担当者 30:入力担当者</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EmployeeDivCd
        {
            get { return _employeeDivCd; }
            set { _employeeDivCd = value; }
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

        /// public propaty name  :  SalesAreaCode
        /// <summary>販売エリアコードプロパティ</summary>
        /// <value>地区コード</value>
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

        /// public propaty name  :  SalesCode
        /// <summary>販売区分コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCode
        {
            get { return _salesCode; }
            set { _salesCode = value; }
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

        /// public propaty name  :  UpdEmployeeName
        /// <summary>更新従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }


        /// <summary>
        /// キャンペーン目標設定マスタコンストラクタ
        /// </summary>
        /// <returns>CampaignTargetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignTargetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CampaignTarget()
        {
        }

        /// <summary>
        /// キャンペーン目標設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="campaignCode">キャンペーンコード(任意の無重複コードとする（自動付番はしない）)</param>
        /// <param name="targetContrastCd">目標対比区分(10:拠点,22:拠点+従業員,30:拠点+得意先,32:拠点+販売ｴﾘｱ,44:拠点+販売区分,50:拠点+ｸﾞﾙｰﾌﾟｺｰﾄﾞ,60:拠点+BLｺｰﾄﾞ)</param>
        /// <param name="employeeDivCd">従業員区分(10:販売担当者 20:受付担当者 30:入力担当者)</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="salesAreaCode">販売エリアコード(地区コード)</param>
        /// <param name="bLGroupCode">BLグループコード(旧グループコード)</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="salesCode">販売区分コード</param>
        /// <param name="salesTargetMoney1">売上目標金額1(1月)</param>
        /// <param name="salesTargetMoney2">売上目標金額2(2月)</param>
        /// <param name="salesTargetMoney3">売上目標金額3(3月)</param>
        /// <param name="salesTargetMoney4">売上目標金額4(4月)</param>
        /// <param name="salesTargetMoney5">売上目標金額5(5月)</param>
        /// <param name="salesTargetMoney6">売上目標金額6(6月)</param>
        /// <param name="salesTargetMoney7">売上目標金額7(7月)</param>
        /// <param name="salesTargetMoney8">売上目標金額8(8月)</param>
        /// <param name="salesTargetMoney9">売上目標金額9(9月)</param>
        /// <param name="salesTargetMoney10">売上目標金額10(10月)</param>
        /// <param name="salesTargetMoney11">売上目標金額11(11月)</param>
        /// <param name="salesTargetMoney12">売上目標金額12(12月)</param>
        /// <param name="monthlySalesTarget">月間売上目標金額</param>
        /// <param name="termSalesTarget">売上期間目標金額</param>
        /// <param name="salesTargetProfit1">売上目標粗利額1(1月)</param>
        /// <param name="salesTargetProfit2">売上目標粗利額2(2月)</param>
        /// <param name="salesTargetProfit3">売上目標粗利額3(3月)</param>
        /// <param name="salesTargetProfit4">売上目標粗利額4(4月)</param>
        /// <param name="salesTargetProfit5">売上目標粗利額5(5月)</param>
        /// <param name="salesTargetProfit6">売上目標粗利額6(6月)</param>
        /// <param name="salesTargetProfit7">売上目標粗利額7(7月)</param>
        /// <param name="salesTargetProfit8">売上目標粗利額8(8月)</param>
        /// <param name="salesTargetProfit9">売上目標粗利額9(9月)</param>
        /// <param name="salesTargetProfit10">売上目標粗利額10(10月)</param>
        /// <param name="salesTargetProfit11">売上目標粗利額11(11月)</param>
        /// <param name="salesTargetProfit12">売上目標粗利額12(12月)</param>
        /// <param name="monthlySalesTargetProfit">売上月間目標粗利額</param>
        /// <param name="termSalesTargetProfit">売上期間目標粗利額</param>
        /// <param name="salesTargetCount1">売上目標数量1(1月)</param>
        /// <param name="salesTargetCount2">売上目標数量2(2月)</param>
        /// <param name="salesTargetCount3">売上目標数量3(3月)</param>
        /// <param name="salesTargetCount4">売上目標数量4(4月)</param>
        /// <param name="salesTargetCount5">売上目標数量5(5月)</param>
        /// <param name="salesTargetCount6">売上目標数量6(6月)</param>
        /// <param name="salesTargetCount7">売上目標数量7(7月)</param>
        /// <param name="salesTargetCount8">売上目標数量8(8月)</param>
        /// <param name="salesTargetCount9">売上目標数量9(9月)</param>
        /// <param name="salesTargetCount10">売上目標数量10(10月)</param>
        /// <param name="salesTargetCount11">売上目標数量11(11月)</param>
        /// <param name="salesTargetCount12">売上目標数量12(12月)</param>
        /// <param name="monthlySalesTargetCount">売上月間目標数量</param>
        /// <param name="termSalesTargetCount">売上期間目標数量</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>CampaignTargetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignTargetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CampaignTarget(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 campaignCode, Int32 targetContrastCd, Int32 employeeDivCd, string sectionCode, string employeeCode, Int32 customerCode, Int32 salesAreaCode, Int32 bLGroupCode, Int32 bLGoodsCode, Int32 salesCode, Int64 salesTargetMoney1, Int64 salesTargetMoney2, Int64 salesTargetMoney3, Int64 salesTargetMoney4, Int64 salesTargetMoney5, Int64 salesTargetMoney6, Int64 salesTargetMoney7, Int64 salesTargetMoney8, Int64 salesTargetMoney9, Int64 salesTargetMoney10, Int64 salesTargetMoney11, Int64 salesTargetMoney12, Int64 monthlySalesTarget, Int64 termSalesTarget, Int64 salesTargetProfit1, Int64 salesTargetProfit2, Int64 salesTargetProfit3, Int64 salesTargetProfit4, Int64 salesTargetProfit5, Int64 salesTargetProfit6, Int64 salesTargetProfit7, Int64 salesTargetProfit8, Int64 salesTargetProfit9, Int64 salesTargetProfit10, Int64 salesTargetProfit11, Int64 salesTargetProfit12, Int64 monthlySalesTargetProfit, Int64 termSalesTargetProfit, Double salesTargetCount1, Double salesTargetCount2, Double salesTargetCount3, Double salesTargetCount4, Double salesTargetCount5, Double salesTargetCount6, Double salesTargetCount7, Double salesTargetCount8, Double salesTargetCount9, Double salesTargetCount10, Double salesTargetCount11, Double salesTargetCount12, Double monthlySalesTargetCount, Double termSalesTargetCount, string enterpriseName, string updEmployeeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._campaignCode = campaignCode;
            this._targetContrastCd = targetContrastCd;
            this._employeeDivCd = employeeDivCd;
            this._sectionCode = sectionCode;
            this._employeeCode = employeeCode;
            this._customerCode = customerCode;
            this._salesAreaCode = salesAreaCode;
            this._bLGroupCode = bLGroupCode;
            this._bLGoodsCode = bLGoodsCode;
            this._salesCode = salesCode;
            this._salesTargetMoney1 = salesTargetMoney1;
            this._salesTargetMoney2 = salesTargetMoney2;
            this._salesTargetMoney3 = salesTargetMoney3;
            this._salesTargetMoney4 = salesTargetMoney4;
            this._salesTargetMoney5 = salesTargetMoney5;
            this._salesTargetMoney6 = salesTargetMoney6;
            this._salesTargetMoney7 = salesTargetMoney7;
            this._salesTargetMoney8 = salesTargetMoney8;
            this._salesTargetMoney9 = salesTargetMoney9;
            this._salesTargetMoney10 = salesTargetMoney10;
            this._salesTargetMoney11 = salesTargetMoney11;
            this._salesTargetMoney12 = salesTargetMoney12;
            this._monthlySalesTarget = monthlySalesTarget;
            this._termSalesTarget = termSalesTarget;
            this._salesTargetProfit1 = salesTargetProfit1;
            this._salesTargetProfit2 = salesTargetProfit2;
            this._salesTargetProfit3 = salesTargetProfit3;
            this._salesTargetProfit4 = salesTargetProfit4;
            this._salesTargetProfit5 = salesTargetProfit5;
            this._salesTargetProfit6 = salesTargetProfit6;
            this._salesTargetProfit7 = salesTargetProfit7;
            this._salesTargetProfit8 = salesTargetProfit8;
            this._salesTargetProfit9 = salesTargetProfit9;
            this._salesTargetProfit10 = salesTargetProfit10;
            this._salesTargetProfit11 = salesTargetProfit11;
            this._salesTargetProfit12 = salesTargetProfit12;
            this._monthlySalesTargetProfit = monthlySalesTargetProfit;
            this._termSalesTargetProfit = termSalesTargetProfit;
            this._salesTargetCount1 = salesTargetCount1;
            this._salesTargetCount2 = salesTargetCount2;
            this._salesTargetCount3 = salesTargetCount3;
            this._salesTargetCount4 = salesTargetCount4;
            this._salesTargetCount5 = salesTargetCount5;
            this._salesTargetCount6 = salesTargetCount6;
            this._salesTargetCount7 = salesTargetCount7;
            this._salesTargetCount8 = salesTargetCount8;
            this._salesTargetCount9 = salesTargetCount9;
            this._salesTargetCount10 = salesTargetCount10;
            this._salesTargetCount11 = salesTargetCount11;
            this._salesTargetCount12 = salesTargetCount12;
            this._monthlySalesTargetCount = monthlySalesTargetCount;
            this._termSalesTargetCount = termSalesTargetCount;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// キャンペーン目標設定マスタ複製処理
        /// </summary>
        /// <returns>CampaignTargetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいCampaignTargetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CampaignTarget Clone()
        {
            return new CampaignTarget(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._campaignCode, this._targetContrastCd, this._employeeDivCd, this._sectionCode, this._employeeCode, this._customerCode, this._salesAreaCode, this._bLGroupCode, this._bLGoodsCode, this._salesCode, this._salesTargetMoney1, this._salesTargetMoney2, this._salesTargetMoney3, this._salesTargetMoney4, this._salesTargetMoney5, this._salesTargetMoney6, this._salesTargetMoney7, this._salesTargetMoney8, this._salesTargetMoney9, this._salesTargetMoney10, this._salesTargetMoney11, this._salesTargetMoney12, this._monthlySalesTarget, this._termSalesTarget, this._salesTargetProfit1, this._salesTargetProfit2, this._salesTargetProfit3, this._salesTargetProfit4, this._salesTargetProfit5, this._salesTargetProfit6, this._salesTargetProfit7, this._salesTargetProfit8, this._salesTargetProfit9, this._salesTargetProfit10, this._salesTargetProfit11, this._salesTargetProfit12, this._monthlySalesTargetProfit, this._termSalesTargetProfit, this._salesTargetCount1, this._salesTargetCount2, this._salesTargetCount3, this._salesTargetCount4, this._salesTargetCount5, this._salesTargetCount6, this._salesTargetCount7, this._salesTargetCount8, this._salesTargetCount9, this._salesTargetCount10, this._salesTargetCount11, this._salesTargetCount12, this._monthlySalesTargetCount, this._termSalesTargetCount, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// キャンペーン目標設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のCampaignTargetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignTargetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(CampaignTarget target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.CampaignCode == target.CampaignCode)
                 && (this.TargetContrastCd == target.TargetContrastCd)
                 && (this.EmployeeDivCd == target.EmployeeDivCd)
                 && (this.SectionCode == target.SectionCode)
                 && (this.EmployeeCode == target.EmployeeCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.SalesAreaCode == target.SalesAreaCode)
                 && (this.BLGroupCode == target.BLGroupCode)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.SalesCode == target.SalesCode)
                 && (this.SalesTargetMoney1 == target.SalesTargetMoney1)
                 && (this.SalesTargetMoney2 == target.SalesTargetMoney2)
                 && (this.SalesTargetMoney3 == target.SalesTargetMoney3)
                 && (this.SalesTargetMoney4 == target.SalesTargetMoney4)
                 && (this.SalesTargetMoney5 == target.SalesTargetMoney5)
                 && (this.SalesTargetMoney6 == target.SalesTargetMoney6)
                 && (this.SalesTargetMoney7 == target.SalesTargetMoney7)
                 && (this.SalesTargetMoney8 == target.SalesTargetMoney8)
                 && (this.SalesTargetMoney9 == target.SalesTargetMoney9)
                 && (this.SalesTargetMoney10 == target.SalesTargetMoney10)
                 && (this.SalesTargetMoney11 == target.SalesTargetMoney11)
                 && (this.SalesTargetMoney12 == target.SalesTargetMoney12)
                 && (this.MonthlySalesTarget == target.MonthlySalesTarget)
                 && (this.TermSalesTarget == target.TermSalesTarget)
                 && (this.SalesTargetProfit1 == target.SalesTargetProfit1)
                 && (this.SalesTargetProfit2 == target.SalesTargetProfit2)
                 && (this.SalesTargetProfit3 == target.SalesTargetProfit3)
                 && (this.SalesTargetProfit4 == target.SalesTargetProfit4)
                 && (this.SalesTargetProfit5 == target.SalesTargetProfit5)
                 && (this.SalesTargetProfit6 == target.SalesTargetProfit6)
                 && (this.SalesTargetProfit7 == target.SalesTargetProfit7)
                 && (this.SalesTargetProfit8 == target.SalesTargetProfit8)
                 && (this.SalesTargetProfit9 == target.SalesTargetProfit9)
                 && (this.SalesTargetProfit10 == target.SalesTargetProfit10)
                 && (this.SalesTargetProfit11 == target.SalesTargetProfit11)
                 && (this.SalesTargetProfit12 == target.SalesTargetProfit12)
                 && (this.MonthlySalesTargetProfit == target.MonthlySalesTargetProfit)
                 && (this.TermSalesTargetProfit == target.TermSalesTargetProfit)
                 && (this.SalesTargetCount1 == target.SalesTargetCount1)
                 && (this.SalesTargetCount2 == target.SalesTargetCount2)
                 && (this.SalesTargetCount3 == target.SalesTargetCount3)
                 && (this.SalesTargetCount4 == target.SalesTargetCount4)
                 && (this.SalesTargetCount5 == target.SalesTargetCount5)
                 && (this.SalesTargetCount6 == target.SalesTargetCount6)
                 && (this.SalesTargetCount7 == target.SalesTargetCount7)
                 && (this.SalesTargetCount8 == target.SalesTargetCount8)
                 && (this.SalesTargetCount9 == target.SalesTargetCount9)
                 && (this.SalesTargetCount10 == target.SalesTargetCount10)
                 && (this.SalesTargetCount11 == target.SalesTargetCount11)
                 && (this.SalesTargetCount12 == target.SalesTargetCount12)
                 && (this.MonthlySalesTargetCount == target.MonthlySalesTargetCount)
                 && (this.TermSalesTargetCount == target.TermSalesTargetCount)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// キャンペーン目標設定マスタ比較処理
        /// </summary>
        /// <param name="campaignTarget1">
        ///                    比較するCampaignTargetクラスのインスタンス
        /// </param>
        /// <param name="campaignTarget2">比較するCampaignTargetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignTargetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(CampaignTarget campaignTarget1, CampaignTarget campaignTarget2)
        {
            return ((campaignTarget1.CreateDateTime == campaignTarget2.CreateDateTime)
                 && (campaignTarget1.UpdateDateTime == campaignTarget2.UpdateDateTime)
                 && (campaignTarget1.EnterpriseCode == campaignTarget2.EnterpriseCode)
                 && (campaignTarget1.FileHeaderGuid == campaignTarget2.FileHeaderGuid)
                 && (campaignTarget1.UpdEmployeeCode == campaignTarget2.UpdEmployeeCode)
                 && (campaignTarget1.UpdAssemblyId1 == campaignTarget2.UpdAssemblyId1)
                 && (campaignTarget1.UpdAssemblyId2 == campaignTarget2.UpdAssemblyId2)
                 && (campaignTarget1.LogicalDeleteCode == campaignTarget2.LogicalDeleteCode)
                 && (campaignTarget1.CampaignCode == campaignTarget2.CampaignCode)
                 && (campaignTarget1.TargetContrastCd == campaignTarget2.TargetContrastCd)
                 && (campaignTarget1.EmployeeDivCd == campaignTarget2.EmployeeDivCd)
                 && (campaignTarget1.SectionCode == campaignTarget2.SectionCode)
                 && (campaignTarget1.EmployeeCode == campaignTarget2.EmployeeCode)
                 && (campaignTarget1.CustomerCode == campaignTarget2.CustomerCode)
                 && (campaignTarget1.SalesAreaCode == campaignTarget2.SalesAreaCode)
                 && (campaignTarget1.BLGroupCode == campaignTarget2.BLGroupCode)
                 && (campaignTarget1.BLGoodsCode == campaignTarget2.BLGoodsCode)
                 && (campaignTarget1.SalesCode == campaignTarget2.SalesCode)
                 && (campaignTarget1.SalesTargetMoney1 == campaignTarget2.SalesTargetMoney1)
                 && (campaignTarget1.SalesTargetMoney2 == campaignTarget2.SalesTargetMoney2)
                 && (campaignTarget1.SalesTargetMoney3 == campaignTarget2.SalesTargetMoney3)
                 && (campaignTarget1.SalesTargetMoney4 == campaignTarget2.SalesTargetMoney4)
                 && (campaignTarget1.SalesTargetMoney5 == campaignTarget2.SalesTargetMoney5)
                 && (campaignTarget1.SalesTargetMoney6 == campaignTarget2.SalesTargetMoney6)
                 && (campaignTarget1.SalesTargetMoney7 == campaignTarget2.SalesTargetMoney7)
                 && (campaignTarget1.SalesTargetMoney8 == campaignTarget2.SalesTargetMoney8)
                 && (campaignTarget1.SalesTargetMoney9 == campaignTarget2.SalesTargetMoney9)
                 && (campaignTarget1.SalesTargetMoney10 == campaignTarget2.SalesTargetMoney10)
                 && (campaignTarget1.SalesTargetMoney11 == campaignTarget2.SalesTargetMoney11)
                 && (campaignTarget1.SalesTargetMoney12 == campaignTarget2.SalesTargetMoney12)
                 && (campaignTarget1.MonthlySalesTarget == campaignTarget2.MonthlySalesTarget)
                 && (campaignTarget1.TermSalesTarget == campaignTarget2.TermSalesTarget)
                 && (campaignTarget1.SalesTargetProfit1 == campaignTarget2.SalesTargetProfit1)
                 && (campaignTarget1.SalesTargetProfit2 == campaignTarget2.SalesTargetProfit2)
                 && (campaignTarget1.SalesTargetProfit3 == campaignTarget2.SalesTargetProfit3)
                 && (campaignTarget1.SalesTargetProfit4 == campaignTarget2.SalesTargetProfit4)
                 && (campaignTarget1.SalesTargetProfit5 == campaignTarget2.SalesTargetProfit5)
                 && (campaignTarget1.SalesTargetProfit6 == campaignTarget2.SalesTargetProfit6)
                 && (campaignTarget1.SalesTargetProfit7 == campaignTarget2.SalesTargetProfit7)
                 && (campaignTarget1.SalesTargetProfit8 == campaignTarget2.SalesTargetProfit8)
                 && (campaignTarget1.SalesTargetProfit9 == campaignTarget2.SalesTargetProfit9)
                 && (campaignTarget1.SalesTargetProfit10 == campaignTarget2.SalesTargetProfit10)
                 && (campaignTarget1.SalesTargetProfit11 == campaignTarget2.SalesTargetProfit11)
                 && (campaignTarget1.SalesTargetProfit12 == campaignTarget2.SalesTargetProfit12)
                 && (campaignTarget1.MonthlySalesTargetProfit == campaignTarget2.MonthlySalesTargetProfit)
                 && (campaignTarget1.TermSalesTargetProfit == campaignTarget2.TermSalesTargetProfit)
                 && (campaignTarget1.SalesTargetCount1 == campaignTarget2.SalesTargetCount1)
                 && (campaignTarget1.SalesTargetCount2 == campaignTarget2.SalesTargetCount2)
                 && (campaignTarget1.SalesTargetCount3 == campaignTarget2.SalesTargetCount3)
                 && (campaignTarget1.SalesTargetCount4 == campaignTarget2.SalesTargetCount4)
                 && (campaignTarget1.SalesTargetCount5 == campaignTarget2.SalesTargetCount5)
                 && (campaignTarget1.SalesTargetCount6 == campaignTarget2.SalesTargetCount6)
                 && (campaignTarget1.SalesTargetCount7 == campaignTarget2.SalesTargetCount7)
                 && (campaignTarget1.SalesTargetCount8 == campaignTarget2.SalesTargetCount8)
                 && (campaignTarget1.SalesTargetCount9 == campaignTarget2.SalesTargetCount9)
                 && (campaignTarget1.SalesTargetCount10 == campaignTarget2.SalesTargetCount10)
                 && (campaignTarget1.SalesTargetCount11 == campaignTarget2.SalesTargetCount11)
                 && (campaignTarget1.SalesTargetCount12 == campaignTarget2.SalesTargetCount12)
                 && (campaignTarget1.MonthlySalesTargetCount == campaignTarget2.MonthlySalesTargetCount)
                 && (campaignTarget1.TermSalesTargetCount == campaignTarget2.TermSalesTargetCount)
                 && (campaignTarget1.EnterpriseName == campaignTarget2.EnterpriseName)
                 && (campaignTarget1.UpdEmployeeName == campaignTarget2.UpdEmployeeName));
        }
        /// <summary>
        /// キャンペーン目標設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のCampaignTargetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignTargetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(CampaignTarget target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.CampaignCode != target.CampaignCode) resList.Add("CampaignCode");
            if (this.TargetContrastCd != target.TargetContrastCd) resList.Add("TargetContrastCd");
            if (this.EmployeeDivCd != target.EmployeeDivCd) resList.Add("EmployeeDivCd");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.EmployeeCode != target.EmployeeCode) resList.Add("EmployeeCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.SalesAreaCode != target.SalesAreaCode) resList.Add("SalesAreaCode");
            if (this.BLGroupCode != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.SalesCode != target.SalesCode) resList.Add("SalesCode");
            if (this.SalesTargetMoney1 != target.SalesTargetMoney1) resList.Add("SalesTargetMoney1");
            if (this.SalesTargetMoney2 != target.SalesTargetMoney2) resList.Add("SalesTargetMoney2");
            if (this.SalesTargetMoney3 != target.SalesTargetMoney3) resList.Add("SalesTargetMoney3");
            if (this.SalesTargetMoney4 != target.SalesTargetMoney4) resList.Add("SalesTargetMoney4");
            if (this.SalesTargetMoney5 != target.SalesTargetMoney5) resList.Add("SalesTargetMoney5");
            if (this.SalesTargetMoney6 != target.SalesTargetMoney6) resList.Add("SalesTargetMoney6");
            if (this.SalesTargetMoney7 != target.SalesTargetMoney7) resList.Add("SalesTargetMoney7");
            if (this.SalesTargetMoney8 != target.SalesTargetMoney8) resList.Add("SalesTargetMoney8");
            if (this.SalesTargetMoney9 != target.SalesTargetMoney9) resList.Add("SalesTargetMoney9");
            if (this.SalesTargetMoney10 != target.SalesTargetMoney10) resList.Add("SalesTargetMoney10");
            if (this.SalesTargetMoney11 != target.SalesTargetMoney11) resList.Add("SalesTargetMoney11");
            if (this.SalesTargetMoney12 != target.SalesTargetMoney12) resList.Add("SalesTargetMoney12");
            if (this.MonthlySalesTarget != target.MonthlySalesTarget) resList.Add("MonthlySalesTarget");
            if (this.TermSalesTarget != target.TermSalesTarget) resList.Add("TermSalesTarget");
            if (this.SalesTargetProfit1 != target.SalesTargetProfit1) resList.Add("SalesTargetProfit1");
            if (this.SalesTargetProfit2 != target.SalesTargetProfit2) resList.Add("SalesTargetProfit2");
            if (this.SalesTargetProfit3 != target.SalesTargetProfit3) resList.Add("SalesTargetProfit3");
            if (this.SalesTargetProfit4 != target.SalesTargetProfit4) resList.Add("SalesTargetProfit4");
            if (this.SalesTargetProfit5 != target.SalesTargetProfit5) resList.Add("SalesTargetProfit5");
            if (this.SalesTargetProfit6 != target.SalesTargetProfit6) resList.Add("SalesTargetProfit6");
            if (this.SalesTargetProfit7 != target.SalesTargetProfit7) resList.Add("SalesTargetProfit7");
            if (this.SalesTargetProfit8 != target.SalesTargetProfit8) resList.Add("SalesTargetProfit8");
            if (this.SalesTargetProfit9 != target.SalesTargetProfit9) resList.Add("SalesTargetProfit9");
            if (this.SalesTargetProfit10 != target.SalesTargetProfit10) resList.Add("SalesTargetProfit10");
            if (this.SalesTargetProfit11 != target.SalesTargetProfit11) resList.Add("SalesTargetProfit11");
            if (this.SalesTargetProfit12 != target.SalesTargetProfit12) resList.Add("SalesTargetProfit12");
            if (this.MonthlySalesTargetProfit != target.MonthlySalesTargetProfit) resList.Add("MonthlySalesTargetProfit");
            if (this.TermSalesTargetProfit != target.TermSalesTargetProfit) resList.Add("TermSalesTargetProfit");
            if (this.SalesTargetCount1 != target.SalesTargetCount1) resList.Add("SalesTargetCount1");
            if (this.SalesTargetCount2 != target.SalesTargetCount2) resList.Add("SalesTargetCount2");
            if (this.SalesTargetCount3 != target.SalesTargetCount3) resList.Add("SalesTargetCount3");
            if (this.SalesTargetCount4 != target.SalesTargetCount4) resList.Add("SalesTargetCount4");
            if (this.SalesTargetCount5 != target.SalesTargetCount5) resList.Add("SalesTargetCount5");
            if (this.SalesTargetCount6 != target.SalesTargetCount6) resList.Add("SalesTargetCount6");
            if (this.SalesTargetCount7 != target.SalesTargetCount7) resList.Add("SalesTargetCount7");
            if (this.SalesTargetCount8 != target.SalesTargetCount8) resList.Add("SalesTargetCount8");
            if (this.SalesTargetCount9 != target.SalesTargetCount9) resList.Add("SalesTargetCount9");
            if (this.SalesTargetCount10 != target.SalesTargetCount10) resList.Add("SalesTargetCount10");
            if (this.SalesTargetCount11 != target.SalesTargetCount11) resList.Add("SalesTargetCount11");
            if (this.SalesTargetCount12 != target.SalesTargetCount12) resList.Add("SalesTargetCount12");
            if (this.MonthlySalesTargetCount != target.MonthlySalesTargetCount) resList.Add("MonthlySalesTargetCount");
            if (this.TermSalesTargetCount != target.TermSalesTargetCount) resList.Add("TermSalesTargetCount");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// キャンペーン目標設定マスタ比較処理
        /// </summary>
        /// <param name="campaignTarget1">比較するCampaignTargetクラスのインスタンス</param>
        /// <param name="campaignTarget2">比較するCampaignTargetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignTargetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(CampaignTarget campaignTarget1, CampaignTarget campaignTarget2)
        {
            ArrayList resList = new ArrayList();
            if (campaignTarget1.CreateDateTime != campaignTarget2.CreateDateTime) resList.Add("CreateDateTime");
            if (campaignTarget1.UpdateDateTime != campaignTarget2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (campaignTarget1.EnterpriseCode != campaignTarget2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (campaignTarget1.FileHeaderGuid != campaignTarget2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (campaignTarget1.UpdEmployeeCode != campaignTarget2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (campaignTarget1.UpdAssemblyId1 != campaignTarget2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (campaignTarget1.UpdAssemblyId2 != campaignTarget2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (campaignTarget1.LogicalDeleteCode != campaignTarget2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (campaignTarget1.CampaignCode != campaignTarget2.CampaignCode) resList.Add("CampaignCode");
            if (campaignTarget1.TargetContrastCd != campaignTarget2.TargetContrastCd) resList.Add("TargetContrastCd");
            if (campaignTarget1.EmployeeDivCd != campaignTarget2.EmployeeDivCd) resList.Add("EmployeeDivCd");
            if (campaignTarget1.SectionCode != campaignTarget2.SectionCode) resList.Add("SectionCode");
            if (campaignTarget1.EmployeeCode != campaignTarget2.EmployeeCode) resList.Add("EmployeeCode");
            if (campaignTarget1.CustomerCode != campaignTarget2.CustomerCode) resList.Add("CustomerCode");
            if (campaignTarget1.SalesAreaCode != campaignTarget2.SalesAreaCode) resList.Add("SalesAreaCode");
            if (campaignTarget1.BLGroupCode != campaignTarget2.BLGroupCode) resList.Add("BLGroupCode");
            if (campaignTarget1.BLGoodsCode != campaignTarget2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (campaignTarget1.SalesCode != campaignTarget2.SalesCode) resList.Add("SalesCode");
            if (campaignTarget1.SalesTargetMoney1 != campaignTarget2.SalesTargetMoney1) resList.Add("SalesTargetMoney1");
            if (campaignTarget1.SalesTargetMoney2 != campaignTarget2.SalesTargetMoney2) resList.Add("SalesTargetMoney2");
            if (campaignTarget1.SalesTargetMoney3 != campaignTarget2.SalesTargetMoney3) resList.Add("SalesTargetMoney3");
            if (campaignTarget1.SalesTargetMoney4 != campaignTarget2.SalesTargetMoney4) resList.Add("SalesTargetMoney4");
            if (campaignTarget1.SalesTargetMoney5 != campaignTarget2.SalesTargetMoney5) resList.Add("SalesTargetMoney5");
            if (campaignTarget1.SalesTargetMoney6 != campaignTarget2.SalesTargetMoney6) resList.Add("SalesTargetMoney6");
            if (campaignTarget1.SalesTargetMoney7 != campaignTarget2.SalesTargetMoney7) resList.Add("SalesTargetMoney7");
            if (campaignTarget1.SalesTargetMoney8 != campaignTarget2.SalesTargetMoney8) resList.Add("SalesTargetMoney8");
            if (campaignTarget1.SalesTargetMoney9 != campaignTarget2.SalesTargetMoney9) resList.Add("SalesTargetMoney9");
            if (campaignTarget1.SalesTargetMoney10 != campaignTarget2.SalesTargetMoney10) resList.Add("SalesTargetMoney10");
            if (campaignTarget1.SalesTargetMoney11 != campaignTarget2.SalesTargetMoney11) resList.Add("SalesTargetMoney11");
            if (campaignTarget1.SalesTargetMoney12 != campaignTarget2.SalesTargetMoney12) resList.Add("SalesTargetMoney12");
            if (campaignTarget1.MonthlySalesTarget != campaignTarget2.MonthlySalesTarget) resList.Add("MonthlySalesTarget");
            if (campaignTarget1.TermSalesTarget != campaignTarget2.TermSalesTarget) resList.Add("TermSalesTarget");
            if (campaignTarget1.SalesTargetProfit1 != campaignTarget2.SalesTargetProfit1) resList.Add("SalesTargetProfit1");
            if (campaignTarget1.SalesTargetProfit2 != campaignTarget2.SalesTargetProfit2) resList.Add("SalesTargetProfit2");
            if (campaignTarget1.SalesTargetProfit3 != campaignTarget2.SalesTargetProfit3) resList.Add("SalesTargetProfit3");
            if (campaignTarget1.SalesTargetProfit4 != campaignTarget2.SalesTargetProfit4) resList.Add("SalesTargetProfit4");
            if (campaignTarget1.SalesTargetProfit5 != campaignTarget2.SalesTargetProfit5) resList.Add("SalesTargetProfit5");
            if (campaignTarget1.SalesTargetProfit6 != campaignTarget2.SalesTargetProfit6) resList.Add("SalesTargetProfit6");
            if (campaignTarget1.SalesTargetProfit7 != campaignTarget2.SalesTargetProfit7) resList.Add("SalesTargetProfit7");
            if (campaignTarget1.SalesTargetProfit8 != campaignTarget2.SalesTargetProfit8) resList.Add("SalesTargetProfit8");
            if (campaignTarget1.SalesTargetProfit9 != campaignTarget2.SalesTargetProfit9) resList.Add("SalesTargetProfit9");
            if (campaignTarget1.SalesTargetProfit10 != campaignTarget2.SalesTargetProfit10) resList.Add("SalesTargetProfit10");
            if (campaignTarget1.SalesTargetProfit11 != campaignTarget2.SalesTargetProfit11) resList.Add("SalesTargetProfit11");
            if (campaignTarget1.SalesTargetProfit12 != campaignTarget2.SalesTargetProfit12) resList.Add("SalesTargetProfit12");
            if (campaignTarget1.MonthlySalesTargetProfit != campaignTarget2.MonthlySalesTargetProfit) resList.Add("MonthlySalesTargetProfit");
            if (campaignTarget1.TermSalesTargetProfit != campaignTarget2.TermSalesTargetProfit) resList.Add("TermSalesTargetProfit");
            if (campaignTarget1.SalesTargetCount1 != campaignTarget2.SalesTargetCount1) resList.Add("SalesTargetCount1");
            if (campaignTarget1.SalesTargetCount2 != campaignTarget2.SalesTargetCount2) resList.Add("SalesTargetCount2");
            if (campaignTarget1.SalesTargetCount3 != campaignTarget2.SalesTargetCount3) resList.Add("SalesTargetCount3");
            if (campaignTarget1.SalesTargetCount4 != campaignTarget2.SalesTargetCount4) resList.Add("SalesTargetCount4");
            if (campaignTarget1.SalesTargetCount5 != campaignTarget2.SalesTargetCount5) resList.Add("SalesTargetCount5");
            if (campaignTarget1.SalesTargetCount6 != campaignTarget2.SalesTargetCount6) resList.Add("SalesTargetCount6");
            if (campaignTarget1.SalesTargetCount7 != campaignTarget2.SalesTargetCount7) resList.Add("SalesTargetCount7");
            if (campaignTarget1.SalesTargetCount8 != campaignTarget2.SalesTargetCount8) resList.Add("SalesTargetCount8");
            if (campaignTarget1.SalesTargetCount9 != campaignTarget2.SalesTargetCount9) resList.Add("SalesTargetCount9");
            if (campaignTarget1.SalesTargetCount10 != campaignTarget2.SalesTargetCount10) resList.Add("SalesTargetCount10");
            if (campaignTarget1.SalesTargetCount11 != campaignTarget2.SalesTargetCount11) resList.Add("SalesTargetCount11");
            if (campaignTarget1.SalesTargetCount12 != campaignTarget2.SalesTargetCount12) resList.Add("SalesTargetCount12");
            if (campaignTarget1.MonthlySalesTargetCount != campaignTarget2.MonthlySalesTargetCount) resList.Add("MonthlySalesTargetCount");
            if (campaignTarget1.TermSalesTargetCount != campaignTarget2.TermSalesTargetCount) resList.Add("TermSalesTargetCount");
            if (campaignTarget1.EnterpriseName != campaignTarget2.EnterpriseName) resList.Add("EnterpriseName");
            if (campaignTarget1.UpdEmployeeName != campaignTarget2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
