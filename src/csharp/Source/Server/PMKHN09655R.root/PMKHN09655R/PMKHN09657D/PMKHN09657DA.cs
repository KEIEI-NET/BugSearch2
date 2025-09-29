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
// 作 成 日  2011/04/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CampaignTargetWork
    /// <summary>
    ///                      キャンペーン目標設定ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   キャンペーン目標設定ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011/04/27  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CampaignTargetWork : IFileHeader
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

        /// <summary>売上月間目標金額</summary>
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
        /// <summary>売上月間目標金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上月間目標金額プロパティ</br>
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


        /// <summary>
        /// キャンペーン目標設定ワークコンストラクタ
        /// </summary>
        /// <returns>CampaignTargetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignTargetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CampaignTargetWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CampaignTargetWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CampaignTargetWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class CampaignTargetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignTargetWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CampaignTargetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CampaignTargetWork || graph is ArrayList || graph is CampaignTargetWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CampaignTargetWork).FullName));

            if (graph != null && graph is CampaignTargetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CampaignTargetWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CampaignTargetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CampaignTargetWork[])graph).Length;
            }
            else if (graph is CampaignTargetWork)
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
            //目標対比区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TargetContrastCd
            //従業員区分
            serInfo.MemberInfo.Add(typeof(Int32)); //EmployeeDivCd
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //販売エリアコード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //BLグループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //販売区分コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCode
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
            //売上月間目標金額
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


            serInfo.Serialize(writer, serInfo);
            if (graph is CampaignTargetWork)
            {
                CampaignTargetWork temp = (CampaignTargetWork)graph;

                SetCampaignTargetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CampaignTargetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CampaignTargetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CampaignTargetWork temp in lst)
                {
                    SetCampaignTargetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CampaignTargetWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 60;

        /// <summary>
        ///  CampaignTargetWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignTargetWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetCampaignTargetWork(System.IO.BinaryWriter writer, CampaignTargetWork temp)
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
            //目標対比区分
            writer.Write(temp.TargetContrastCd);
            //従業員区分
            writer.Write(temp.EmployeeDivCd);
            //拠点コード
            writer.Write(temp.SectionCode);
            //従業員コード
            writer.Write(temp.EmployeeCode);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //販売エリアコード
            writer.Write(temp.SalesAreaCode);
            //BLグループコード
            writer.Write(temp.BLGroupCode);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //販売区分コード
            writer.Write(temp.SalesCode);
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
            //売上月間目標金額
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

        }

        /// <summary>
        ///  CampaignTargetWorkインスタンス取得
        /// </summary>
        /// <returns>CampaignTargetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignTargetWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private CampaignTargetWork GetCampaignTargetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            CampaignTargetWork temp = new CampaignTargetWork();

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
            //目標対比区分
            temp.TargetContrastCd = reader.ReadInt32();
            //従業員区分
            temp.EmployeeDivCd = reader.ReadInt32();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //従業員コード
            temp.EmployeeCode = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //販売エリアコード
            temp.SalesAreaCode = reader.ReadInt32();
            //BLグループコード
            temp.BLGroupCode = reader.ReadInt32();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //販売区分コード
            temp.SalesCode = reader.ReadInt32();
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
            //売上月間目標金額
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
        /// <returns>CampaignTargetWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignTargetWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CampaignTargetWork temp = GetCampaignTargetWork(reader, serInfo);
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
                    retValue = (CampaignTargetWork[])lst.ToArray(typeof(CampaignTargetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
