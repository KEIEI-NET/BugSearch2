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

namespace Broadleaf.Application.UIData
{
    /// public class name:   CampaignTargetSet
    /// <summary>
    ///                      キャンペーン目標設定マスタ（印刷）結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   キャンペーン目標設定マスタ（印刷）結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011/04/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class CampaignTargetSet 
    {
        /// <summary>キャンペーンコード</summary>
        private string _campaignCode = "";

        /// <summary>キャンペーンコード名称</summary>
        /// <remarks>帳票印字用</remarks>
        private string _campaignCodeName = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>拠点ガイド略称</summary>
        /// <remarks>帳票印字用</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>ＢＬコード</summary>
        private Int32 _blGoodsCode;

        /// <summary>ＢＬコード名称</summary>
        private string _blGoodsCodeName = "";

        /// <summary>担当者コード</summary>
        private string _salesEmployeeCd = "";

        /// <summary>担当者名称</summary>
        private string _salesEmployeeNm = "";

        /// <summary>受注者コード</summary>
        private string _frontEmployeeCd = "";

        /// <summary>受注者名称</summary>
        private string _frontEmployeeNm = "";

        /// <summary>発行者コード</summary>
        private string _salesInputCode = "";

        /// <summary>発行者名称</summary>
        private string _salesInputName = "";

        /// <summary>販売区分コード</summary>
        private Int32 _salesCode;

        /// <summary>販売区分名称</summary>
        private string _salesCodeName = "";

        /// <summary>BLグループコード</summary>
        private Int32 _blGroupCode;

        /// <summary>BLグループコード名称</summary>
        private string _blGroupCodeName = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>販売エリアコード</summary>
        private Int32 _salesAreaCode;

        /// <summary>販売エリア名称</summary>
        private string _salesAreaCodeName = "";

        /// <summary>売上月間目標金額</summary>
        private Int64 _monthlySalesTarget;

        /// <summary>売上期間目標金額</summary>
        private Int64 _termSalesTarget;

        /// <summary>売上目標金額１</summary>
        private Int64 _salesTargetMoney1;

        /// <summary>売上目標金額２</summary>
        private Int64 _salesTargetMoney2;

        /// <summary>売上目標金額３</summary>
        private Int64 _salesTargetMoney3;

        /// <summary>売上目標金額４</summary>
        private Int64 _salesTargetMoney4;

        /// <summary>売上目標金額５</summary>
        private Int64 _salesTargetMoney5;

        /// <summary>売上目標金額６</summary>
        private Int64 _salesTargetMoney6;

        /// <summary>売上目標金額７</summary>
        private Int64 _salesTargetMoney7;

        /// <summary>売上目標金額８</summary>
        private Int64 _salesTargetMoney8;

        /// <summary>売上目標金額９</summary>
        private Int64 _salesTargetMoney9;

        /// <summary>売上目標金額１０</summary>
        private Int64 _salesTargetMoney10;

        /// <summary>売上目標金額１１</summary>
        private Int64 _salesTargetMoney11;

        /// <summary>売上目標金額１２</summary>
        private Int64 _salesTargetMoney12;

        /// <summary>売上月間目標粗利額</summary>
        private Int64 _monthlySalesTargetProfit;

        /// <summary>売上期間目標粗利額</summary>
        private Int64 _termSalesTargetProfit;

        /// <summary>売上目標粗利額１</summary>
        private Int64 _salesTargetProfit1;

        /// <summary>売上目標粗利額２</summary>
        private Int64 _salesTargetProfit2;

        /// <summary>売上目標粗利額３</summary>
        private Int64 _salesTargetProfit3;

        /// <summary>売上目標粗利額４</summary>
        private Int64 _salesTargetProfit4;

        /// <summary>売上目標粗利額５</summary>
        private Int64 _salesTargetProfit5;

        /// <summary>売上目標粗利額６</summary>
        private Int64 _salesTargetProfit6;

        /// <summary>売上目標粗利額７</summary>
        private Int64 _salesTargetProfit7;

        /// <summary>売上目標粗利額８</summary>
        private Int64 _salesTargetProfit8;

        /// <summary>売上目標粗利額９</summary>
        private Int64 _salesTargetProfit9;

        /// <summary>売上目標粗利額１０</summary>
        private Int64 _salesTargetProfit10;

        /// <summary>売上目標粗利額１１</summary>
        private Int64 _salesTargetProfit11;

        /// <summary>売上目標粗利額１２</summary>
        private Int64 _salesTargetProfit12;

        /// <summary>売上月間目標数量</summary>
        private Int64 _monthlySalesTargetCount;

        /// <summary>売上期間目標数量</summary>
        private Int64 _termSalesTargetCount;

        /// <summary>売上目標粗利額１</summary>
        private Int64 _salesTargetCount1;

        /// <summary>売上目標粗利額２</summary>
        private Int64 _salesTargetCount2;

        /// <summary>売上目標粗利額３</summary>
        private Int64 _salesTargetCount3;

        /// <summary>売上目標粗利額４</summary>
        private Int64 _salesTargetCount4;

        /// <summary>売上目標粗利額５</summary>
        private Int64 _salesTargetCount5;

        /// <summary>売上目標粗利額６</summary>
        private Int64 _salesTargetCount6;

        /// <summary>売上目標粗利額７</summary>
        private Int64 _salesTargetCount7;

        /// <summary>売上目標粗利額８</summary>
        private Int64 _salesTargetCount8;

        /// <summary>売上目標粗利額９</summary>
        private Int64 _salesTargetCount9;

        /// <summary>売上目標粗利額１０</summary>
        private Int64 _salesTargetCount10;

        /// <summary>売上目標粗利額１１</summary>
        private Int64 _salesTargetCount11;

        /// <summary>売上目標粗利額１２</summary>
        private Int64 _salesTargetCount12;

        /// <summary>開始年月</summary>
        private Int32 _targetDivideCodeSt;

        /// <summary>適用開始日</summary>
        /// <remarks>（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _applyStaDate;

        /// <summary>適用終了日</summary>
        /// <remarks>（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _applyEndDate;


        /// public propaty name  :  CampaignCode
        /// <summary>キャンペーンコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーンコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CampaignCode
        {
            get { return _campaignCode; }
            set { _campaignCode = value; }
        }

        /// public propaty name  :  SectionGuideSnm
        /// <summary>キャンペーンコード名称プロパティ</summary>
        /// <value>帳票印字用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーンコード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CampaignCodeName
        {
            get { return _campaignCodeName; }
            set { _campaignCodeName = value; }
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

        /// public propaty name  :  SubSectionCode
        /// <summary>ＢＬコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＢＬコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BlGoodsCode
        {
            get { return _blGoodsCode; }
            set { _blGoodsCode = value; }
        }

        /// public propaty name  :  SubSectionName
        /// <summary>ＢＬコード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＢＬコード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BlGoodsCodeName
        {
            get { return _blGoodsCodeName; }
            set { _blGoodsCodeName = value; }
        }

        /// public propaty name  :  SalesEmployeeCd
        /// <summary>担当者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesEmployeeCd
        {
            get { return _salesEmployeeCd; }
            set { _salesEmployeeCd = value; }
        }

        /// public propaty name  :  SalesEmployeeNm
        /// <summary>担当者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   担当者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesEmployeeNm
        {
            get { return _salesEmployeeNm; }
            set { _salesEmployeeNm = value; }
        }

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>受注者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrontEmployeeCd
        {
            get { return _frontEmployeeCd; }
            set { _frontEmployeeCd = value; }
        }

        /// public propaty name  :  FrontEmployeeNm
        /// <summary>受注者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrontEmployeeNm
        {
            get { return _frontEmployeeNm; }
            set { _frontEmployeeNm = value; }
        }

        /// public propaty name  :  SalesInputCode
        /// <summary>発行者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発行者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesInputCode
        {
            get { return _salesInputCode; }
            set { _salesInputCode = value; }
        }

        /// public propaty name  :  SalesInputName
        /// <summary>発行者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発行者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesInputName
        {
            get { return _salesInputName; }
            set { _salesInputName = value; }
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

        /// public propaty name  :  SalesCodeName
        /// <summary>販売区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesCodeName
        {
            get { return _salesCodeName; }
            set { _salesCodeName = value; }
        }

        /// public propaty name  :  BlGroupCode
        /// <summary>BLグループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BlGroupCode
        {
            get { return _blGroupCode; }
            set { _blGroupCode = value; }
        }

        /// public propaty name  :  BlGroupCodeName
        /// <summary>BLグループコード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BlGroupCodeName
        {
            get { return _blGroupCodeName; }
            set { _blGroupCodeName = value; }
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

        /// public propaty name  :  SalesAreaCode
        /// <summary>販売エリアコードプロパティ</summary>
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

        /// public propaty name  :  SalesAreaCodeName
        /// <summary>販売エリア名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリア名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesAreaCodeName
        {
            get { return _salesAreaCodeName; }
            set { _salesAreaCodeName = value; }
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

        /// public propaty name  :  SalesTargetMoney1
        /// <summary>売上目標金額１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney1
        {
            get { return _salesTargetMoney1; }
            set { _salesTargetMoney1 = value; }
        }

        /// public propaty name  :  SalesTargetMoney2
        /// <summary>売上目標金額２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney2
        {
            get { return _salesTargetMoney2; }
            set { _salesTargetMoney2 = value; }
        }

        /// public propaty name  :  SalesTargetMoney3
        /// <summary>売上目標金額３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney3
        {
            get { return _salesTargetMoney3; }
            set { _salesTargetMoney3 = value; }
        }

        /// public propaty name  :  SalesTargetMoney4
        /// <summary>売上目標金額４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney4
        {
            get { return _salesTargetMoney4; }
            set { _salesTargetMoney4 = value; }
        }

        /// public propaty name  :  SalesTargetMoney5
        /// <summary>売上目標金額５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney5
        {
            get { return _salesTargetMoney5; }
            set { _salesTargetMoney5 = value; }
        }

        /// public propaty name  :  SalesTargetMoney6
        /// <summary>売上目標金額６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney6
        {
            get { return _salesTargetMoney6; }
            set { _salesTargetMoney6 = value; }
        }

        /// public propaty name  :  SalesTargetMoney7
        /// <summary>売上目標金額７プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額７プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney7
        {
            get { return _salesTargetMoney7; }
            set { _salesTargetMoney7 = value; }
        }

        /// public propaty name  :  SalesTargetMoney8
        /// <summary>売上目標金額８プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額８プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney8
        {
            get { return _salesTargetMoney8; }
            set { _salesTargetMoney8 = value; }
        }

        /// public propaty name  :  SalesTargetMoney9
        /// <summary>売上目標金額９プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額９プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney9
        {
            get { return _salesTargetMoney9; }
            set { _salesTargetMoney9 = value; }
        }

        /// public propaty name  :  SalesTargetMoney10
        /// <summary>売上目標金額１０プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額１０プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney10
        {
            get { return _salesTargetMoney10; }
            set { _salesTargetMoney10 = value; }
        }

        /// public propaty name  :  SalesTargetMoney11
        /// <summary>売上目標金額１１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額１１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney11
        {
            get { return _salesTargetMoney11; }
            set { _salesTargetMoney11 = value; }
        }

        /// public propaty name  :  SalesTargetMoney12
        /// <summary>売上目標金額１２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額１２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney12
        {
            get { return _salesTargetMoney12; }
            set { _salesTargetMoney12 = value; }
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

        /// public propaty name  :  SalesTargetProfit1
        /// <summary>売上目標粗利額１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit1
        {
            get { return _salesTargetProfit1; }
            set { _salesTargetProfit1 = value; }
        }

        /// public propaty name  :  SalesTargetProfit2
        /// <summary>売上目標粗利額２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit2
        {
            get { return _salesTargetProfit2; }
            set { _salesTargetProfit2 = value; }
        }

        /// public propaty name  :  SalesTargetProfit3
        /// <summary>売上目標粗利額３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit3
        {
            get { return _salesTargetProfit3; }
            set { _salesTargetProfit3 = value; }
        }

        /// public propaty name  :  SalesTargetProfit4
        /// <summary>売上目標粗利額４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit4
        {
            get { return _salesTargetProfit4; }
            set { _salesTargetProfit4 = value; }
        }

        /// public propaty name  :  SalesTargetProfit5
        /// <summary>売上目標粗利額５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit5
        {
            get { return _salesTargetProfit5; }
            set { _salesTargetProfit5 = value; }
        }

        /// public propaty name  :  SalesTargetProfit6
        /// <summary>売上目標粗利額６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit6
        {
            get { return _salesTargetProfit6; }
            set { _salesTargetProfit6 = value; }
        }

        /// public propaty name  :  SalesTargetProfit7
        /// <summary>売上目標粗利額７プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額７プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit7
        {
            get { return _salesTargetProfit7; }
            set { _salesTargetProfit7 = value; }
        }

        /// public propaty name  :  SalesTargetProfit8
        /// <summary>売上目標粗利額８プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額８プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit8
        {
            get { return _salesTargetProfit8; }
            set { _salesTargetProfit8 = value; }
        }

        /// public propaty name  :  SalesTargetProfit9
        /// <summary>売上目標粗利額９プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額９プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit9
        {
            get { return _salesTargetProfit9; }
            set { _salesTargetProfit9 = value; }
        }

        /// public propaty name  :  SalesTargetProfit10
        /// <summary>売上目標粗利額１０プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額１０プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit10
        {
            get { return _salesTargetProfit10; }
            set { _salesTargetProfit10 = value; }
        }

        /// public propaty name  :  SalesTargetProfit11
        /// <summary>売上目標粗利額１１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額１１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit11
        {
            get { return _salesTargetProfit11; }
            set { _salesTargetProfit11 = value; }
        }

        /// public propaty name  :  SalesTargetProfit12
        /// <summary>売上目標粗利額１２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額１２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit12
        {
            get { return _salesTargetProfit12; }
            set { _salesTargetProfit12 = value; }
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
        public Int64 TermSalesTargetCount
        {
            get { return _termSalesTargetCount; }
            set { _termSalesTargetCount = value; }
        }

        /// public propaty name  :  SalesTargetCount1
        /// <summary>売上目標数量１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標数量１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetCount1
        {
            get { return _salesTargetCount1; }
            set { _salesTargetCount1 = value; }
        }

        /// public propaty name  :  SalesTargetCount2
        /// <summary>売上目標数量２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標数量２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetCount2
        {
            get { return _salesTargetCount2; }
            set { _salesTargetCount2 = value; }
        }

        /// public propaty name  :  SalesTargetCount3
        /// <summary>売上目標数量３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標数量３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetCount3
        {
            get { return _salesTargetCount3; }
            set { _salesTargetCount3 = value; }
        }

        /// public propaty name  :  SalesTargetCount4
        /// <summary>売上目標数量４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標数量４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetCount4
        {
            get { return _salesTargetCount4; }
            set { _salesTargetCount4 = value; }
        }

        /// public propaty name  :  SalesTargetCount5
        /// <summary>売上目標数量５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標数量５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetCount5
        {
            get { return _salesTargetCount5; }
            set { _salesTargetCount5 = value; }
        }

        /// public propaty name  :  SalesTargetCount6
        /// <summary>売上目標数量６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標数量６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetCount6
        {
            get { return _salesTargetCount6; }
            set { _salesTargetCount6 = value; }
        }

        /// public propaty name  :  SalesTargetCount7
        /// <summary>売上目標数量７プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標数量７プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetCount7
        {
            get { return _salesTargetCount7; }
            set { _salesTargetCount7 = value; }
        }

        /// public propaty name  :  SalesTargetCount8
        /// <summary>売上目標数量８プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標数量８プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetCount8
        {
            get { return _salesTargetCount8; }
            set { _salesTargetCount8 = value; }
        }

        /// public propaty name  :  SalesTargetCount9
        /// <summary>売上目標数量９プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標数量９プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetCount9
        {
            get { return _salesTargetCount9; }
            set { _salesTargetCount9 = value; }
        }

        /// public propaty name  :  SalesTargetCount10
        /// <summary>売上目標数量１０プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標数量１０プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetCount10
        {
            get { return _salesTargetCount10; }
            set { _salesTargetCount10 = value; }
        }

        /// public propaty name  :  SalesTargetCount11
        /// <summary>売上目標数量１１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標数量１１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetCount11
        {
            get { return _salesTargetCount11; }
            set { _salesTargetCount11 = value; }
        }

        /// public propaty name  :  SalesTargetCount12
        /// <summary>売上目標数量１２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標数量１２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetCount12
        {
            get { return _salesTargetCount12; }
            set { _salesTargetCount12 = value; }
        }

        /// public propaty name  :  TargetDivideCodeSt
        /// <summary>開始年月プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TargetDivideCodeSt
        {
            get { return _targetDivideCodeSt; }
            set { _targetDivideCodeSt = value; }
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


        /// <summary>
        /// キャンペーン目標設定（印刷）データクラス複製処理
        /// </summary>
        /// <returns>SalesTargetSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSalesTargetSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CampaignTargetSet Clone()
        {
            return new CampaignTargetSet(this._campaignCode, this._campaignCodeName, this._sectionCode, this._sectionGuideSnm, this._blGoodsCode, this._blGoodsCodeName, this._salesEmployeeCd, this._salesEmployeeNm, this._frontEmployeeCd, this._frontEmployeeNm, this._salesInputCode, this._salesInputName, this._salesCode, this._salesCodeName, this._blGroupCode, this._blGroupCodeName, this._customerCode, this._customerSnm, this._salesAreaCode, this._salesAreaCodeName, this._monthlySalesTarget, this._termSalesTarget, this._salesTargetMoney1, this._salesTargetMoney2, this._salesTargetMoney3, this._salesTargetMoney4, this._salesTargetMoney5, this._salesTargetMoney6, this._salesTargetMoney7, this._salesTargetMoney8, this._salesTargetMoney9, this._salesTargetMoney10, this._salesTargetMoney11, this._salesTargetMoney12, this._monthlySalesTargetProfit, this._termSalesTargetProfit, this._salesTargetProfit1, this._salesTargetProfit2, this._salesTargetProfit3, this._salesTargetProfit4, this._salesTargetProfit5, this._salesTargetProfit6, this._salesTargetProfit7, this._salesTargetProfit8, this._salesTargetProfit9, this._salesTargetProfit10, this._salesTargetProfit11, this._salesTargetProfit12, this._monthlySalesTargetCount, this._termSalesTargetCount, this._salesTargetCount1, this._salesTargetCount2, this._salesTargetCount3, this._salesTargetCount4, this._salesTargetCount5, this._salesTargetCount6, this._salesTargetCount7, this._salesTargetCount8, this._salesTargetCount9, this._salesTargetCount10, this._salesTargetCount11, this._salesTargetCount12, this._targetDivideCodeSt, this._applyStaDate, this._applyEndDate);
        }

        /// <summary>
        /// キャンペーン目標設定（印刷）データクラスワークコンストラクタ
		/// </summary>
        /// <returns>SalesTargetSetクラスのインスタンス</returns>
		/// <remarks>
        /// <br>Note　　　　　　 :   SalesTargetSetクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CampaignTargetSet()
		{
		}

        /// <summary>
        /// キャンペーン目標設定（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <param name="CampaignCode"></param>
        /// <param name="CampaignCodeName"></param>
        /// <param name="SectionCode"></param>
        /// <param name="SectionGuideSnm"></param>
        /// <param name="BlGoodsCode"></param>
        /// <param name="BlGoodsCodeName"></param>
        /// <param name="SalesEmployeeCd"></param>
        /// <param name="SalesEmployeeNm"></param>
        /// <param name="FrontEmployeeCd"></param>
        /// <param name="FrontEmployeeNm"></param>
        /// <param name="SalesInputCode"></param>
        /// <param name="SalesInputName"></param>
        /// <param name="SalesCode"></param>
        /// <param name="SalesCodeName"></param>
        /// <param name="BlGroupCode"></param>
        /// <param name="BlGroupCodeName"></param>
        /// <param name="CustomerCode"></param>
        /// <param name="CustomerSnm"></param>
        /// <param name="SalesAreaCode"></param>
        /// <param name="SalesAreaCodeName"></param>
        /// <param name="MonthlySalesTarget"></param>
        /// <param name="TermSalesTarget"></param>
        /// <param name="SalesTargetMoney1"></param>
        /// <param name="SalesTargetMoney2"></param>
        /// <param name="SalesTargetMoney3"></param>
        /// <param name="SalesTargetMoney4"></param>
        /// <param name="SalesTargetMoney5"></param>
        /// <param name="SalesTargetMoney6"></param>
        /// <param name="SalesTargetMoney7"></param>
        /// <param name="SalesTargetMoney8"></param>
        /// <param name="SalesTargetMoney9"></param>
        /// <param name="SalesTargetMoney10"></param>
        /// <param name="SalesTargetMoney11"></param>
        /// <param name="SalesTargetMoney12"></param>
        /// <param name="MonthlySalesTargetProfit"></param>
        /// <param name="TermSalesTargetProfit"></param>
        /// <param name="SalesTargetProfit1"></param>
        /// <param name="SalesTargetProfit2"></param>
        /// <param name="SalesTargetProfit3"></param>
        /// <param name="SalesTargetProfit4"></param>
        /// <param name="SalesTargetProfit5"></param>
        /// <param name="SalesTargetProfit6"></param>
        /// <param name="SalesTargetProfit7"></param>
        /// <param name="SalesTargetProfit8"></param>
        /// <param name="SalesTargetProfit9"></param>
        /// <param name="SalesTargetProfit10"></param>
        /// <param name="SalesTargetProfit11"></param>
        /// <param name="SalesTargetProfit12"></param>
        /// <param name="MonthlySalesTargetCount"></param>
        /// <param name="TermSalesTargetCount"></param>
        /// <param name="SalesTargetCount1"></param>
        /// <param name="SalesTargetCount2"></param>
        /// <param name="SalesTargetCount3"></param>
        /// <param name="SalesTargetCount4"></param>
        /// <param name="SalesTargetCount5"></param>
        /// <param name="SalesTargetCount6"></param>
        /// <param name="SalesTargetCount7"></param>
        /// <param name="SalesTargetCount8"></param>
        /// <param name="SalesTargetCount9"></param>
        /// <param name="SalesTargetCount10"></param>
        /// <param name="SalesTargetCount11"></param>
        /// <param name="SalesTargetCount12"></param>
        /// <param name="TargetDivideCodeSt"></param>
        /// <param name="ApplyStaDate"></param>
        /// <param name="ApplyEndDate"></param>
        public CampaignTargetSet(string CampaignCode, string CampaignCodeName, string SectionCode, string SectionGuideSnm, Int32 BlGoodsCode, string BlGoodsCodeName, string SalesEmployeeCd, string SalesEmployeeNm, string FrontEmployeeCd, string FrontEmployeeNm, string SalesInputCode, string SalesInputName, Int32 SalesCode, string SalesCodeName, Int32 BlGroupCode, string BlGroupCodeName, Int32 CustomerCode, string CustomerSnm, Int32 SalesAreaCode, string SalesAreaCodeName, Int64 MonthlySalesTarget, Int64 TermSalesTarget, Int64 SalesTargetMoney1, Int64 SalesTargetMoney2, Int64 SalesTargetMoney3, Int64 SalesTargetMoney4, Int64 SalesTargetMoney5, Int64 SalesTargetMoney6, Int64 SalesTargetMoney7, Int64 SalesTargetMoney8, Int64 SalesTargetMoney9, Int64 SalesTargetMoney10, Int64 SalesTargetMoney11, Int64 SalesTargetMoney12, Int64 MonthlySalesTargetProfit, Int64 TermSalesTargetProfit, Int64 SalesTargetProfit1, Int64 SalesTargetProfit2, Int64 SalesTargetProfit3, Int64 SalesTargetProfit4, Int64 SalesTargetProfit5, Int64 SalesTargetProfit6, Int64 SalesTargetProfit7, Int64 SalesTargetProfit8, Int64 SalesTargetProfit9, Int64 SalesTargetProfit10, Int64 SalesTargetProfit11, Int64 SalesTargetProfit12, Int64 MonthlySalesTargetCount, Int64 TermSalesTargetCount, Int64 SalesTargetCount1, Int64 SalesTargetCount2, Int64 SalesTargetCount3, Int64 SalesTargetCount4, Int64 SalesTargetCount5, Int64 SalesTargetCount6, Int64 SalesTargetCount7, Int64 SalesTargetCount8, Int64 SalesTargetCount9, Int64 SalesTargetCount10, Int64 SalesTargetCount11, Int64 SalesTargetCount12, Int32 TargetDivideCodeSt, DateTime ApplyStaDate, DateTime ApplyEndDate)
        {
            this._campaignCode = CampaignCode;
            this._campaignCodeName = CampaignCodeName;
            this._sectionCode = SectionCode;
            this._sectionGuideSnm = SectionGuideSnm;
            this._blGoodsCode = BlGoodsCode;
            this._blGoodsCodeName = BlGoodsCodeName;
            this._salesEmployeeCd = SalesEmployeeCd;
            this._salesEmployeeNm = SalesEmployeeNm;
            this._frontEmployeeCd = FrontEmployeeCd;
            this._frontEmployeeNm = FrontEmployeeNm;
            this._salesInputCode = SalesInputCode;
            this._salesInputName = SalesInputName;
            this._salesCode = SalesCode;
            this._salesCodeName = SalesCodeName;
            this._blGroupCode = BlGroupCode;
            this._blGroupCodeName = BlGroupCodeName;
            this._customerCode = CustomerCode;
            this._customerSnm = CustomerSnm;
            this._salesAreaCode = SalesAreaCode;
            this._salesAreaCodeName = SalesAreaCodeName;
            this._monthlySalesTarget = MonthlySalesTarget;
            this._termSalesTarget = TermSalesTarget;
            this._salesTargetMoney1 = SalesTargetMoney1;
            this._salesTargetMoney2 = SalesTargetMoney2;
            this._salesTargetMoney3 = SalesTargetMoney3;
            this._salesTargetMoney4 = SalesTargetMoney4;
            this._salesTargetMoney5 = SalesTargetMoney5;
            this._salesTargetMoney6 = SalesTargetMoney6;
            this._salesTargetMoney7 = SalesTargetMoney7;
            this._salesTargetMoney8 = SalesTargetMoney8;
            this._salesTargetMoney9 = SalesTargetMoney9;
            this._salesTargetMoney10 = SalesTargetMoney10;
            this._salesTargetMoney11 = SalesTargetMoney11;
            this._salesTargetMoney12 = SalesTargetMoney12;
            this._monthlySalesTargetProfit = MonthlySalesTargetProfit;
            this._termSalesTargetProfit = TermSalesTargetProfit;
            this._salesTargetProfit1 = SalesTargetProfit1;
            this._salesTargetProfit2 = SalesTargetProfit2;
            this._salesTargetProfit3 = SalesTargetProfit3;
            this._salesTargetProfit4 = SalesTargetProfit4;
            this._salesTargetProfit5 = SalesTargetProfit5;
            this._salesTargetProfit6 = SalesTargetProfit6;
            this._salesTargetProfit7 = SalesTargetProfit7;
            this._salesTargetProfit8 = SalesTargetProfit8;
            this._salesTargetProfit9 = SalesTargetProfit9;
            this._salesTargetProfit10 = SalesTargetProfit10;
            this._salesTargetProfit11 = SalesTargetProfit11;
            this._salesTargetProfit12 = SalesTargetProfit12;
            this._monthlySalesTargetCount = MonthlySalesTargetCount;
            this._termSalesTargetCount = TermSalesTargetCount;
            this._salesTargetCount1 = SalesTargetCount1;
            this._salesTargetCount2 = SalesTargetCount2;
            this._salesTargetCount3 = SalesTargetCount3;
            this._salesTargetCount4 = SalesTargetCount4;
            this._salesTargetCount5 = SalesTargetCount5;
            this._salesTargetCount6 = SalesTargetCount6;
            this._salesTargetCount7 = SalesTargetCount7;
            this._salesTargetCount8 = SalesTargetCount8;
            this._salesTargetCount9 = SalesTargetCount9;
            this._salesTargetCount10 = SalesTargetCount10;
            this._salesTargetCount11 = SalesTargetCount11;
            this._salesTargetCount12 = SalesTargetCount12;
            this._targetDivideCodeSt = TargetDivideCodeSt;
            this._applyStaDate = ApplyStaDate;
            this._applyEndDate = ApplyEndDate;
        }
    }
}
