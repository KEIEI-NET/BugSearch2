//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン目標設定マスタ（印刷）
// プログラム概要   : キャンペーン目標設定マスタで設定した内容を一覧出力し
//                    確認する
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 楊明俊
// 作 成 日  2011/04/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CampTrgtPrintResultWork
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
    public class CampTrgtPrintResultWork 
	{
		/// <summary>更新日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _updateDateTime;

        /// <summary>適用開始日</summary>
        /// <remarks>（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _applyStaDate;

        /// <summary>適用終了日</summary>
        /// <remarks>（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _applyEndDate;

		/// <summary>キャンペーンコード</summary>
		/// <remarks>任意の無重複コードとする（自動付番はしない）</remarks>
		private Int32 _campaignCode;

		/// <summary>キャンペーン名称</summary>
		private string _campaignName = "";

		/// <summary>目標対比区分</summary>
		/// <remarks>10:拠点,22:拠点+従業員,30:拠点+得意先,32:拠点+販売ｴﾘｱ,44:拠点+販売区分,50:拠点+ｸﾞﾙｰﾌﾟｺｰﾄﾞ,60:拠点+BLｺｰﾄﾞ</remarks>
		private Int32 _targetContrastCd;

		/// <summary>従業員区分</summary>
		/// <remarks>10:販売担当者 20:受付担当者 30:入力担当者</remarks>
		private Int32 _employeeDivCd;

		/// <summary>拠点コード</summary>
		private string _sectionCode = "";

		/// <summary>拠点ガイド略称</summary>
		/// <remarks>帳票印字用</remarks>
		private string _sectionGuideSnm = "";

		/// <summary>従業員コード</summary>
		private string _employeeCode = "";

		/// <summary>名称</summary>
		private string _name = "";

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;

		/// <summary>得意先略称</summary>
		private string _customerSnm = "";

		/// <summary>販売エリアコード</summary>
		/// <remarks>地区コード</remarks>
		private Int32 _salesAreaCode;

		/// <summary>販売エリアガイド名称</summary>
		private string _salesAreaName = "";

		/// <summary>BLグループコード</summary>
		/// <remarks>旧グループコード</remarks>
		private Int32 _bLGroupCode;

		/// <summary>BLグループコードカナ名称</summary>
		/// <remarks>半角カナ</remarks>
		private string _bLGroupKanaName = "";

		/// <summary>BL商品コード</summary>
		private Int32 _bLGoodsCode;

		/// <summary>BL商品コード名称（半角）</summary>
		private string _bLGoodsHalfName = "";

		/// <summary>販売区分コード</summary>
		private Int32 _salesCode;

		/// <summary>販売区分ガイド名称</summary>
		private string _salesCodeName = "";

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
		private Int64 _salesTargetCount1;

		/// <summary>売上目標数量2</summary>
		/// <remarks>2月</remarks>
		private Int64 _salesTargetCount2;

		/// <summary>売上目標数量3</summary>
		/// <remarks>3月</remarks>
		private Int64 _salesTargetCount3;

		/// <summary>売上目標数量4</summary>
		/// <remarks>4月</remarks>
		private Int64 _salesTargetCount4;

		/// <summary>売上目標数量5</summary>
		/// <remarks>5月</remarks>
		private Int64 _salesTargetCount5;

		/// <summary>売上目標数量6</summary>
		/// <remarks>6月</remarks>
		private Int64 _salesTargetCount6;

		/// <summary>売上目標数量7</summary>
		/// <remarks>7月</remarks>
		private Int64 _salesTargetCount7;

		/// <summary>売上目標数量8</summary>
		/// <remarks>8月</remarks>
		private Int64 _salesTargetCount8;

		/// <summary>売上目標数量9</summary>
		/// <remarks>9月</remarks>
		private Int64 _salesTargetCount9;

		/// <summary>売上目標数量10</summary>
		/// <remarks>10月</remarks>
		private Int64 _salesTargetCount10;

		/// <summary>売上目標数量11</summary>
		/// <remarks>11月</remarks>
		private Int64 _salesTargetCount11;

		/// <summary>売上目標数量12</summary>
		/// <remarks>12月</remarks>
		private Int64 _salesTargetCount12;

		/// <summary>売上月間目標数量</summary>
		private Int64 _monthlySalesTargetCount;

		/// <summary>売上期間目標数量</summary>
		private Int64 _termSalesTargetCount;


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
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
		}

        /// public propaty name  :  UpdateDateTime
        /// <summary>適用開始日プロパティ</summary>
        /// <value>（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ApplyStaDate
        {
            get { return _applyStaDate; }
            set { _applyStaDate = value; }
        }

        /// public propaty name  :  ApplyEndDate
        /// <summary>適用終了日プロパティ</summary>
        /// <value>（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用終了日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ApplyEndDate
        {
            get { return _applyEndDate; }
            set { _applyEndDate = value; }
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
			get{return _campaignCode;}
			set{_campaignCode = value;}
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
			get{return _campaignName;}
			set{_campaignName = value;}
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
			get{return _targetContrastCd;}
			set{_targetContrastCd = value;}
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
			get{return _employeeDivCd;}
			set{_employeeDivCd = value;}
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
			get{return _sectionCode;}
			set{_sectionCode = value;}
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
			get{return _sectionGuideSnm;}
			set{_sectionGuideSnm = value;}
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
			get{return _employeeCode;}
			set{_employeeCode = value;}
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
			get{return _name;}
			set{_name = value;}
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
			get{return _customerCode;}
			set{_customerCode = value;}
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
			get{return _customerSnm;}
			set{_customerSnm = value;}
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
			get{return _salesAreaCode;}
			set{_salesAreaCode = value;}
		}

		/// public propaty name  :  SalesAreaName
		/// <summary>販売エリアガイド名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売エリアガイド名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesAreaName
		{
			get{return _salesAreaName;}
			set{_salesAreaName = value;}
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
			get{return _bLGroupCode;}
			set{_bLGroupCode = value;}
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
			get{return _bLGroupKanaName;}
			set{_bLGroupKanaName = value;}
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
			get{return _bLGoodsCode;}
			set{_bLGoodsCode = value;}
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
			get{return _bLGoodsHalfName;}
			set{_bLGoodsHalfName = value;}
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
			get{return _salesCode;}
			set{_salesCode = value;}
		}

		/// public propaty name  :  SalesCodeName
		/// <summary>販売区分ガイド名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売区分ガイド名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesCodeName
		{
			get{return _salesCodeName;}
			set{_salesCodeName = value;}
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
			get{return _salesTargetMoney1;}
			set{_salesTargetMoney1 = value;}
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
			get{return _salesTargetMoney2;}
			set{_salesTargetMoney2 = value;}
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
			get{return _salesTargetMoney3;}
			set{_salesTargetMoney3 = value;}
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
			get{return _salesTargetMoney4;}
			set{_salesTargetMoney4 = value;}
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
			get{return _salesTargetMoney5;}
			set{_salesTargetMoney5 = value;}
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
			get{return _salesTargetMoney6;}
			set{_salesTargetMoney6 = value;}
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
			get{return _salesTargetMoney7;}
			set{_salesTargetMoney7 = value;}
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
			get{return _salesTargetMoney8;}
			set{_salesTargetMoney8 = value;}
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
			get{return _salesTargetMoney9;}
			set{_salesTargetMoney9 = value;}
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
			get{return _salesTargetMoney10;}
			set{_salesTargetMoney10 = value;}
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
			get{return _salesTargetMoney11;}
			set{_salesTargetMoney11 = value;}
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
			get{return _salesTargetMoney12;}
			set{_salesTargetMoney12 = value;}
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
			get{return _monthlySalesTarget;}
			set{_monthlySalesTarget = value;}
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
			get{return _termSalesTarget;}
			set{_termSalesTarget = value;}
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
			get{return _salesTargetProfit1;}
			set{_salesTargetProfit1 = value;}
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
			get{return _salesTargetProfit2;}
			set{_salesTargetProfit2 = value;}
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
			get{return _salesTargetProfit3;}
			set{_salesTargetProfit3 = value;}
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
			get{return _salesTargetProfit4;}
			set{_salesTargetProfit4 = value;}
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
			get{return _salesTargetProfit5;}
			set{_salesTargetProfit5 = value;}
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
			get{return _salesTargetProfit6;}
			set{_salesTargetProfit6 = value;}
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
			get{return _salesTargetProfit7;}
			set{_salesTargetProfit7 = value;}
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
			get{return _salesTargetProfit8;}
			set{_salesTargetProfit8 = value;}
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
			get{return _salesTargetProfit9;}
			set{_salesTargetProfit9 = value;}
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
			get{return _salesTargetProfit10;}
			set{_salesTargetProfit10 = value;}
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
			get{return _salesTargetProfit11;}
			set{_salesTargetProfit11 = value;}
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
			get{return _salesTargetProfit12;}
			set{_salesTargetProfit12 = value;}
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
			get{return _monthlySalesTargetProfit;}
			set{_monthlySalesTargetProfit = value;}
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
			get{return _termSalesTargetProfit;}
			set{_termSalesTargetProfit = value;}
		}

		/// public propaty name  :  SalesTargetCount1
		/// <summary>売上目標数量1プロパティ</summary>
		/// <value>1月</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上目標数量1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesTargetCount1
		{
			get{return _salesTargetCount1;}
			set{_salesTargetCount1 = value;}
		}

		/// public propaty name  :  SalesTargetCount2
		/// <summary>売上目標数量2プロパティ</summary>
		/// <value>2月</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上目標数量2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesTargetCount2
		{
			get{return _salesTargetCount2;}
			set{_salesTargetCount2 = value;}
		}

		/// public propaty name  :  SalesTargetCount3
		/// <summary>売上目標数量3プロパティ</summary>
		/// <value>3月</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上目標数量3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesTargetCount3
		{
			get{return _salesTargetCount3;}
			set{_salesTargetCount3 = value;}
		}

		/// public propaty name  :  SalesTargetCount4
		/// <summary>売上目標数量4プロパティ</summary>
		/// <value>4月</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上目標数量4プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesTargetCount4
		{
			get{return _salesTargetCount4;}
			set{_salesTargetCount4 = value;}
		}

		/// public propaty name  :  SalesTargetCount5
		/// <summary>売上目標数量5プロパティ</summary>
		/// <value>5月</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上目標数量5プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesTargetCount5
		{
			get{return _salesTargetCount5;}
			set{_salesTargetCount5 = value;}
		}

		/// public propaty name  :  SalesTargetCount6
		/// <summary>売上目標数量6プロパティ</summary>
		/// <value>6月</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上目標数量6プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesTargetCount6
		{
			get{return _salesTargetCount6;}
			set{_salesTargetCount6 = value;}
		}

		/// public propaty name  :  SalesTargetCount7
		/// <summary>売上目標数量7プロパティ</summary>
		/// <value>7月</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上目標数量7プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesTargetCount7
		{
			get{return _salesTargetCount7;}
			set{_salesTargetCount7 = value;}
		}

		/// public propaty name  :  SalesTargetCount8
		/// <summary>売上目標数量8プロパティ</summary>
		/// <value>8月</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上目標数量8プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesTargetCount8
		{
			get{return _salesTargetCount8;}
			set{_salesTargetCount8 = value;}
		}

		/// public propaty name  :  SalesTargetCount9
		/// <summary>売上目標数量9プロパティ</summary>
		/// <value>9月</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上目標数量9プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesTargetCount9
		{
			get{return _salesTargetCount9;}
			set{_salesTargetCount9 = value;}
		}

		/// public propaty name  :  SalesTargetCount10
		/// <summary>売上目標数量10プロパティ</summary>
		/// <value>10月</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上目標数量10プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesTargetCount10
		{
			get{return _salesTargetCount10;}
			set{_salesTargetCount10 = value;}
		}

		/// public propaty name  :  SalesTargetCount11
		/// <summary>売上目標数量11プロパティ</summary>
		/// <value>11月</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上目標数量11プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesTargetCount11
		{
			get{return _salesTargetCount11;}
			set{_salesTargetCount11 = value;}
		}

		/// public propaty name  :  SalesTargetCount12
		/// <summary>売上目標数量12プロパティ</summary>
		/// <value>12月</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上目標数量12プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesTargetCount12
		{
			get{return _salesTargetCount12;}
			set{_salesTargetCount12 = value;}
		}

		/// public propaty name  :  MonthlySalesTargetCount
		/// <summary>売上月間目標数量プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上月間目標数量プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 MonthlySalesTargetCount
		{
			get{return _monthlySalesTargetCount;}
			set{_monthlySalesTargetCount = value;}
		}

		/// public propaty name  :  TermSalesTargetCount
		/// <summary>売上期間目標数量プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上期間目標数量プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TermSalesTargetCount
		{
			get{return _termSalesTargetCount;}
			set{_termSalesTargetCount = value;}
		}


		/// <summary>
		/// キャンペーン目標設定ワークコンストラクタ
		/// </summary>
		/// <returns>CampTrgtPrintResultWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CampTrgtPrintResultWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public CampTrgtPrintResultWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CampTrgtPrintResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CampTrgtPrintResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class CampTrgtPrintResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampTrgtPrintResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CampTrgtPrintResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CampTrgtPrintResultWork || graph is ArrayList || graph is CampTrgtPrintResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CampTrgtPrintResultWork).FullName));

            if (graph != null && graph is CampTrgtPrintResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CampTrgtPrintResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CampTrgtPrintResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CampTrgtPrintResultWork[])graph).Length;
            }
            else if (graph is CampTrgtPrintResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //適用開始日
            serInfo.MemberInfo.Add(typeof(Int64)); //ApplyStaDate
            //適用終了日
            serInfo.MemberInfo.Add(typeof(Int64)); //ApplyEndDate
            //キャンペーンコード
            serInfo.MemberInfo.Add(typeof(Int32)); //CampaignCode
            //キャンペーン名称
            serInfo.MemberInfo.Add(typeof(string)); //CampaignName
            //目標対比区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TargetContrastCd
            //従業員区分
            serInfo.MemberInfo.Add(typeof(Int32)); //EmployeeDivCd
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点ガイド略称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            //名称
            serInfo.MemberInfo.Add(typeof(string)); //Name
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先略称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //販売エリアコード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //販売エリアガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //SalesAreaName
            //BLグループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //BLグループコードカナ名称
            serInfo.MemberInfo.Add(typeof(string)); //BLGroupKanaName
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL商品コード名称（半角）
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsHalfName
            //販売区分コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCode
            //販売区分ガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //SalesCodeName
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
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetCount1
            //売上目標数量2
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetCount2
            //売上目標数量3
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetCount3
            //売上目標数量4
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetCount4
            //売上目標数量5
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetCount5
            //売上目標数量6
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetCount6
            //売上目標数量7
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetCount7
            //売上目標数量8
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetCount8
            //売上目標数量9
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetCount9
            //売上目標数量10
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetCount10
            //売上目標数量11
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetCount11
            //売上目標数量12
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetCount12
            //売上月間目標数量
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthlySalesTargetCount
            //売上期間目標数量
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesTargetCount


            serInfo.Serialize(writer, serInfo);
            if (graph is CampTrgtPrintResultWork)
            {
                CampTrgtPrintResultWork temp = (CampTrgtPrintResultWork)graph;

                SetCampTrgtPrintResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CampTrgtPrintResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CampTrgtPrintResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CampTrgtPrintResultWork temp in lst)
                {
                    SetCampTrgtPrintResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CampTrgtPrintResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 63;

        /// <summary>
        ///  CampTrgtPrintResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampTrgtPrintResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetCampTrgtPrintResultWork(System.IO.BinaryWriter writer, CampTrgtPrintResultWork temp)
        {
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //適用開始日
            writer.Write((Int64)temp.ApplyStaDate.Ticks);
            //適用終了日
            writer.Write((Int64)temp.ApplyEndDate.Ticks);
            //キャンペーンコード
            writer.Write(temp.CampaignCode);
            //キャンペーン名称
            writer.Write(temp.CampaignName);
            //目標対比区分
            writer.Write(temp.TargetContrastCd);
            //従業員区分
            writer.Write(temp.EmployeeDivCd);
            //拠点コード
            writer.Write(temp.SectionCode);
            //拠点ガイド略称
            writer.Write(temp.SectionGuideSnm);
            //従業員コード
            writer.Write(temp.EmployeeCode);
            //名称
            writer.Write(temp.Name);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先略称
            writer.Write(temp.CustomerSnm);
            //販売エリアコード
            writer.Write(temp.SalesAreaCode);
            //販売エリアガイド名称
            writer.Write(temp.SalesAreaName);
            //BLグループコード
            writer.Write(temp.BLGroupCode);
            //BLグループコードカナ名称
            writer.Write(temp.BLGroupKanaName);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //BL商品コード名称（半角）
            writer.Write(temp.BLGoodsHalfName);
            //販売区分コード
            writer.Write(temp.SalesCode);
            //販売区分ガイド名称
            writer.Write(temp.SalesCodeName);
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

        }

        /// <summary>
        ///  CampTrgtPrintResultWorkインスタンス取得
        /// </summary>
        /// <returns>CampTrgtPrintResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampTrgtPrintResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private CampTrgtPrintResultWork GetCampTrgtPrintResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            CampTrgtPrintResultWork temp = new CampTrgtPrintResultWork();

            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //適用開始日
            temp.ApplyStaDate = new DateTime(reader.ReadInt64());
            //適用終了日
            temp.ApplyEndDate = new DateTime(reader.ReadInt64());
            //キャンペーンコード
            temp.CampaignCode = reader.ReadInt32();
            //キャンペーン名称
            temp.CampaignName = reader.ReadString();
            //目標対比区分
            temp.TargetContrastCd = reader.ReadInt32();
            //従業員区分
            temp.EmployeeDivCd = reader.ReadInt32();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //拠点ガイド略称
            temp.SectionGuideSnm = reader.ReadString();
            //従業員コード
            temp.EmployeeCode = reader.ReadString();
            //名称
            temp.Name = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先略称
            temp.CustomerSnm = reader.ReadString();
            //販売エリアコード
            temp.SalesAreaCode = reader.ReadInt32();
            //販売エリアガイド名称
            temp.SalesAreaName = reader.ReadString();
            //BLグループコード
            temp.BLGroupCode = reader.ReadInt32();
            //BLグループコードカナ名称
            temp.BLGroupKanaName = reader.ReadString();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //BL商品コード名称（半角）
            temp.BLGoodsHalfName = reader.ReadString();
            //販売区分コード
            temp.SalesCode = reader.ReadInt32();
            //販売区分ガイド名称
            temp.SalesCodeName = reader.ReadString();
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
            temp.SalesTargetCount1 = reader.ReadInt64();
            //売上目標数量2
            temp.SalesTargetCount2 = reader.ReadInt64();
            //売上目標数量3
            temp.SalesTargetCount3 = reader.ReadInt64();
            //売上目標数量4
            temp.SalesTargetCount4 = reader.ReadInt64();
            //売上目標数量5
            temp.SalesTargetCount5 = reader.ReadInt64();
            //売上目標数量6
            temp.SalesTargetCount6 = reader.ReadInt64();
            //売上目標数量7
            temp.SalesTargetCount7 = reader.ReadInt64();
            //売上目標数量8
            temp.SalesTargetCount8 = reader.ReadInt64();
            //売上目標数量9
            temp.SalesTargetCount9 = reader.ReadInt64();
            //売上目標数量10
            temp.SalesTargetCount10 = reader.ReadInt64();
            //売上目標数量11
            temp.SalesTargetCount11 = reader.ReadInt64();
            //売上目標数量12
            temp.SalesTargetCount12 = reader.ReadInt64();
            //売上月間目標数量
            temp.MonthlySalesTargetCount = reader.ReadInt64();
            //売上期間目標数量
            temp.TermSalesTargetCount = reader.ReadInt64();


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
        /// <returns>CampTrgtPrintResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampTrgtPrintResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CampTrgtPrintResultWork temp = GetCampTrgtPrintResultWork(reader, serInfo);
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
                    retValue = (CampTrgtPrintResultWork[])lst.ToArray(typeof(CampTrgtPrintResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
