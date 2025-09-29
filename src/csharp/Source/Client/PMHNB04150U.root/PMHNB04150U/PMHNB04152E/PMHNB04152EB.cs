using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SalesReportResult
    /// <summary>
    ///                      売上速報表示抽出結果クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上速報表示抽出結果クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SalesReportResult
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>拠点ガイド略称</summary>
        /// <remarks>帳票印字用</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>売上伝票合計（税抜き）</summary>
        /// <remarks>売上正価金額＋売上値引金額計（税抜き）</remarks>
        private Int64 _salesTotalTaxExc;

        /// <summary>売上目標金額</summary>
        private Int64 _salesTargetMoney;

        /// <summary>達成率（純売上）</summary>
        private Int32 _achievementRateNet;

        /// <summary>粗利</summary>
        private Int64 _grossMargin;

        /// <summary>売上目標粗利額</summary>
        private Int64 _salesTargetProfit;

        /// <summary>達成率（粗利）</summary>
        private Int32 _achievementRateGross;

        /// <summary>稼働日</summary>
        private Int32 _operationDay;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";


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

        /// public propaty name  :  SalesTotalTaxExc
        /// <summary>売上伝票合計（税抜き）プロパティ</summary>
        /// <value>売上正価金額＋売上値引金額計（税抜き）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票合計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTotalTaxExc
        {
            get { return _salesTotalTaxExc; }
            set { _salesTotalTaxExc = value; }
        }

        /// public propaty name  :  SalesTargetMoney
        /// <summary>売上目標金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney
        {
            get { return _salesTargetMoney; }
            set { _salesTargetMoney = value; }
        }

        /// public propaty name  :  AchievementRateNet 
        /// <summary>達成率（純売上）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   達成率（純売上）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AchievementRateNet
        {
            get { return _achievementRateNet; }
            set { _achievementRateNet = value; }
        }

        /// public propaty name  :  GrossMargin
        /// <summary>粗利プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 GrossMargin
        {
            get { return _grossMargin; }
            set { _grossMargin = value; }
        }

        /// public propaty name  :  SalesTargetProfit
        /// <summary>売上目標粗利額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit
        {
            get { return _salesTargetProfit; }
            set { _salesTargetProfit = value; }
        }

        /// public propaty name  :  AchievementRateGross
        /// <summary>達成率（粗利）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   達成率（粗利）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AchievementRateGross
        {
            get { return _achievementRateGross; }
            set { _achievementRateGross = value; }
        }

        /// public propaty name  :  OperationDay
        /// <summary>稼働日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   稼働日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OperationDay
        {
            get { return _operationDay; }
            set { _operationDay = value; }
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


        /// <summary>
        /// 売上速報表示抽出結果クラスコンストラクタ
        /// </summary>
        /// <returns>SalesReportResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesReportResultクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesReportResult()
        {
        }

        /// <summary>
        /// 売上速報表示抽出結果クラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="sectionGuideSnm">拠点ガイド略称(帳票印字用)</param>
        /// <param name="salesTotalTaxExc">売上伝票合計（税抜き）(売上正価金額＋売上値引金額計（税抜き）)</param>
        /// <param name="salesTargetMoney">売上目標金額</param>
        /// <param name="achievementRateNet ">達成率（純売上）</param>
        /// <param name="grossMargin">粗利</param>
        /// <param name="salesTargetProfit">売上目標粗利額</param>
        /// <param name="achievementRateGross">達成率（粗利）</param>
        /// <param name="operationDay">稼働日</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <returns>SalesReportResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesReportResultクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesReportResult(string enterpriseCode, string sectionCode, string sectionGuideSnm, Int64 salesTotalTaxExc, Int64 salesTargetMoney, Int32 achievementRateNet, Int64 grossMargin, Int64 salesTargetProfit, Int32 achievementRateGross, Int32 operationDay, string enterpriseName)
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._sectionGuideSnm = sectionGuideSnm;
            this._salesTotalTaxExc = salesTotalTaxExc;
            this._salesTargetMoney = salesTargetMoney;
            this._achievementRateNet = achievementRateNet;
            this._grossMargin = grossMargin;
            this._salesTargetProfit = salesTargetProfit;
            this._achievementRateGross = achievementRateGross;
            this._operationDay = operationDay;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// 売上速報表示抽出結果クラス複製処理
        /// </summary>
        /// <returns>SalesReportResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSalesReportResultクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesReportResult Clone()
        {
            return new SalesReportResult(this._enterpriseCode, this._sectionCode, this._sectionGuideSnm, this._salesTotalTaxExc, this._salesTargetMoney, this._achievementRateNet, this._grossMargin, this._salesTargetProfit, this._achievementRateGross, this._operationDay, this._enterpriseName);
        }

        /// <summary>
        /// 売上速報表示抽出結果クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のSalesReportResultクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesReportResultクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SalesReportResult target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SectionGuideSnm == target.SectionGuideSnm)
                 && (this.SalesTotalTaxExc == target.SalesTotalTaxExc)
                 && (this.SalesTargetMoney == target.SalesTargetMoney)
                 && (this.AchievementRateNet == target.AchievementRateNet)
                 && (this.GrossMargin == target.GrossMargin)
                 && (this.SalesTargetProfit == target.SalesTargetProfit)
                 && (this.AchievementRateGross == target.AchievementRateGross)
                 && (this.OperationDay == target.OperationDay)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// 売上速報表示抽出結果クラス比較処理
        /// </summary>
        /// <param name="salesReportResult1">
        ///                    比較するSalesReportResultクラスのインスタンス
        /// </param>
        /// <param name="salesReportResult2">比較するSalesReportResultクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesReportResultクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SalesReportResult salesReportResult1, SalesReportResult salesReportResult2)
        {
            return ((salesReportResult1.EnterpriseCode == salesReportResult2.EnterpriseCode)
                 && (salesReportResult1.SectionCode == salesReportResult2.SectionCode)
                 && (salesReportResult1.SectionGuideSnm == salesReportResult2.SectionGuideSnm)
                 && (salesReportResult1.SalesTotalTaxExc == salesReportResult2.SalesTotalTaxExc)
                 && (salesReportResult1.SalesTargetMoney == salesReportResult2.SalesTargetMoney)
                 && (salesReportResult1.AchievementRateNet == salesReportResult2.AchievementRateNet)
                 && (salesReportResult1.GrossMargin == salesReportResult2.GrossMargin)
                 && (salesReportResult1.SalesTargetProfit == salesReportResult2.SalesTargetProfit)
                 && (salesReportResult1.AchievementRateGross == salesReportResult2.AchievementRateGross)
                 && (salesReportResult1.OperationDay == salesReportResult2.OperationDay)
                 && (salesReportResult1.EnterpriseName == salesReportResult2.EnterpriseName));
        }
        /// <summary>
        /// 売上速報表示抽出結果クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のSalesReportResultクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesReportResultクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SalesReportResult target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SectionGuideSnm != target.SectionGuideSnm) resList.Add("SectionGuideSnm");
            if (this.SalesTotalTaxExc != target.SalesTotalTaxExc) resList.Add("SalesTotalTaxExc");
            if (this.SalesTargetMoney != target.SalesTargetMoney) resList.Add("SalesTargetMoney");
            if (this.AchievementRateNet != target.AchievementRateNet) resList.Add("AchievementRateNet ");
            if (this.GrossMargin != target.GrossMargin) resList.Add("GrossMargin");
            if (this.SalesTargetProfit != target.SalesTargetProfit) resList.Add("SalesTargetProfit");
            if (this.AchievementRateGross != target.AchievementRateGross) resList.Add("AchievementRateGross");
            if (this.OperationDay != target.OperationDay) resList.Add("OperationDay");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// 売上速報表示抽出結果クラス比較処理
        /// </summary>
        /// <param name="salesReportResult1">比較するSalesReportResultクラスのインスタンス</param>
        /// <param name="salesReportResult2">比較するSalesReportResultクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesReportResultクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SalesReportResult salesReportResult1, SalesReportResult salesReportResult2)
        {
            ArrayList resList = new ArrayList();
            if (salesReportResult1.EnterpriseCode != salesReportResult2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (salesReportResult1.SectionCode != salesReportResult2.SectionCode) resList.Add("SectionCode");
            if (salesReportResult1.SectionGuideSnm != salesReportResult2.SectionGuideSnm) resList.Add("SectionGuideSnm");
            if (salesReportResult1.SalesTotalTaxExc != salesReportResult2.SalesTotalTaxExc) resList.Add("SalesTotalTaxExc");
            if (salesReportResult1.SalesTargetMoney != salesReportResult2.SalesTargetMoney) resList.Add("SalesTargetMoney");
            if (salesReportResult1.AchievementRateNet != salesReportResult2.AchievementRateNet) resList.Add("AchievementRateNet ");
            if (salesReportResult1.GrossMargin != salesReportResult2.GrossMargin) resList.Add("GrossMargin");
            if (salesReportResult1.SalesTargetProfit != salesReportResult2.SalesTargetProfit) resList.Add("SalesTargetProfit");
            if (salesReportResult1.AchievementRateGross != salesReportResult2.AchievementRateGross) resList.Add("AchievementRateGross");
            if (salesReportResult1.OperationDay != salesReportResult2.OperationDay) resList.Add("OperationDay");
            if (salesReportResult1.EnterpriseName != salesReportResult2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}
