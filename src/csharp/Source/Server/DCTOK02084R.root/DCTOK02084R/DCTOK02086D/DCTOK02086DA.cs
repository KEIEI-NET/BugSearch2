using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockTransListCndtnWork
    /// <summary>
    ///                      仕入推移表抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入推移表抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/11/30  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockTransListCndtnWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点別集計区分</summary>
        /// <remarks>0:全社集計／1:拠点別集計</remarks>
        private Int32 _groupBySectionDiv;

        /// <summary>帳票集計区分</summary>
        /// <remarks>（予備項目）0:商品別／1:仕入先別／2:担当者別</remarks>
        private Int32 _printSelectDiv;

        /// <summary>計上拠点コード（複数指定）</summary>
        /// <remarks>（※配列）</remarks>
        private string[] _addUpSecCodes;

        /// <summary>開始当期月</summary>
        /// <remarks>YYYYMM　当期計　算出範囲開始</remarks>
        private Int32 _st_ThisYearMonth;

        /// <summary>終了当期月</summary>
        /// <remarks>YYYYMM　当期計　算出範囲終了</remarks>
        private Int32 _ed_ThisYearMonth;

        /// <summary>集計単位</summary>
        /// <remarks>0:商品コード  1:BLコード  2:自社分類コード  3:商品区分詳細コード  4:詳細区分コード  5:商品区分グループコード  6:メーカーコード</remarks>
        private Int32 _summaryUnit;

        /// <summary>在庫取寄区分</summary>
        /// <remarks>0:合計 1:在庫 2:取寄</remarks>
        private Int32 _stockOrderDiv;

        /// <summary>開始部門コード</summary>
        private Int32 _st_SubSectionCode;

        /// <summary>終了部門コード</summary>
        private Int32 _ed_SubSectionCode;

        /// <summary>開始課コード</summary>
        private Int32 _st_MinSectionCode;

        /// <summary>終了課コード</summary>
        private Int32 _ed_MinSectionCode;

        /// <summary>開始従業員コード</summary>
        private string _st_EmployeeCode = "";

        /// <summary>終了従業員コード</summary>
        private string _ed_EmployeeCode = "";

        /// <summary>開始仕入先コード</summary>
        private Int32 _st_SupplierCd;

        /// <summary>終了仕入先コード</summary>
        private Int32 _ed_SupplierCd;

        /// <summary>開始商品メーカーコード</summary>
        private Int32 _st_GoodsMakerCd;

        /// <summary>終了商品メーカーコード</summary>
        private Int32 _ed_GoodsMakerCd;

        /// <summary>開始商品番号</summary>
        private string _st_GoodsNo = "";

        /// <summary>終了商品番号</summary>
        private string _ed_GoodsNo = "";

        /// <summary>開始BL商品コード</summary>
        private Int32 _st_BLGoodsCode;

        /// <summary>終了BL商品コード</summary>
        private Int32 _ed_BLGoodsCode;

        /// <summary>開始商品区分グループコード</summary>
        private string _st_LargeGoodsGanreCode = "";

        /// <summary>終了商品区分グループコード</summary>
        private string _ed_LargeGoodsGanreCode = "";

        /// <summary>開始商品区分コード</summary>
        private string _st_MediumGoodsGanreCode = "";

        /// <summary>終了商品区分コード</summary>
        private string _ed_MediumGoodsGanreCode = "";

        /// <summary>開始商品区分詳細コード</summary>
        private string _st_DetailGoodsGanreCode = "";

        /// <summary>終了商品区分詳細コード</summary>
        private string _ed_DetailGoodsGanreCode = "";

        /// <summary>開始自社分類コード</summary>
        /// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _st_EnterpriseGanreCode;

        /// <summary>終了自社分類コード</summary>
        /// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _ed_EnterpriseGanreCode;

        /// <summary>開始出荷数</summary>
        private Double _st_TotalStockCount;

        /// <summary>終了出荷数</summary>
        private Double _ed_TotalStockCount;


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

        /// public propaty name  :  GroupBySectionDiv
        /// <summary>拠点別集計区分プロパティ</summary>
        /// <value>0:全社集計／1:拠点別集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点別集計区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GroupBySectionDiv
        {
            get { return _groupBySectionDiv; }
            set { _groupBySectionDiv = value; }
        }

        /// public propaty name  :  PrintSelectDiv
        /// <summary>帳票集計区分プロパティ</summary>
        /// <value>（予備項目）0:商品別／1:仕入先別／2:担当者別</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   帳票集計区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintSelectDiv
        {
            get { return _printSelectDiv; }
            set { _printSelectDiv = value; }
        }

        /// public propaty name  :  AddUpSecCodes
        /// <summary>計上拠点コード（複数指定）プロパティ</summary>
        /// <value>（※配列）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上拠点コード（複数指定）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] AddUpSecCodes
        {
            get { return _addUpSecCodes; }
            set { _addUpSecCodes = value; }
        }

        /// public propaty name  :  St_ThisYearMonth
        /// <summary>開始当期月プロパティ</summary>
        /// <value>YYYYMM　当期計　算出範囲開始</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始当期月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_ThisYearMonth
        {
            get { return _st_ThisYearMonth; }
            set { _st_ThisYearMonth = value; }
        }

        /// public propaty name  :  Ed_ThisYearMonth
        /// <summary>終了当期月プロパティ</summary>
        /// <value>YYYYMM　当期計　算出範囲終了</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了当期月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_ThisYearMonth
        {
            get { return _ed_ThisYearMonth; }
            set { _ed_ThisYearMonth = value; }
        }

        /// public propaty name  :  SummaryUnit
        /// <summary>集計単位プロパティ</summary>
        /// <value>0:商品コード  1:BLコード  2:自社分類コード  3:商品区分詳細コード  4:詳細区分コード  5:商品区分グループコード  6:メーカーコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集計単位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SummaryUnit
        {
            get { return _summaryUnit; }
            set { _summaryUnit = value; }
        }

        /// public propaty name  :  StockOrderDiv
        /// <summary>在庫取寄区分プロパティ</summary>
        /// <value>0:合計 1:在庫 2:取寄</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫取寄区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockOrderDiv
        {
            get { return _stockOrderDiv; }
            set { _stockOrderDiv = value; }
        }

        /// public propaty name  :  St_SubSectionCode
        /// <summary>開始部門コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始部門コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_SubSectionCode
        {
            get { return _st_SubSectionCode; }
            set { _st_SubSectionCode = value; }
        }

        /// public propaty name  :  Ed_SubSectionCode
        /// <summary>終了部門コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了部門コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_SubSectionCode
        {
            get { return _ed_SubSectionCode; }
            set { _ed_SubSectionCode = value; }
        }

        /// public propaty name  :  St_MinSectionCode
        /// <summary>開始課コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始課コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_MinSectionCode
        {
            get { return _st_MinSectionCode; }
            set { _st_MinSectionCode = value; }
        }

        /// public propaty name  :  Ed_MinSectionCode
        /// <summary>終了課コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了課コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_MinSectionCode
        {
            get { return _ed_MinSectionCode; }
            set { _ed_MinSectionCode = value; }
        }

        /// public propaty name  :  St_EmployeeCode
        /// <summary>開始従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_EmployeeCode
        {
            get { return _st_EmployeeCode; }
            set { _st_EmployeeCode = value; }
        }

        /// public propaty name  :  Ed_EmployeeCode
        /// <summary>終了従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_EmployeeCode
        {
            get { return _ed_EmployeeCode; }
            set { _ed_EmployeeCode = value; }
        }

        /// public propaty name  :  St_SupplierCd
        /// <summary>開始仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_SupplierCd
        {
            get { return _st_SupplierCd; }
            set { _st_SupplierCd = value; }
        }

        /// public propaty name  :  Ed_SupplierCd
        /// <summary>終了仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_SupplierCd
        {
            get { return _ed_SupplierCd; }
            set { _ed_SupplierCd = value; }
        }

        /// public propaty name  :  St_GoodsMakerCd
        /// <summary>開始商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_GoodsMakerCd
        {
            get { return _st_GoodsMakerCd; }
            set { _st_GoodsMakerCd = value; }
        }

        /// public propaty name  :  Ed_GoodsMakerCd
        /// <summary>終了商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_GoodsMakerCd
        {
            get { return _ed_GoodsMakerCd; }
            set { _ed_GoodsMakerCd = value; }
        }

        /// public propaty name  :  St_GoodsNo
        /// <summary>開始商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_GoodsNo
        {
            get { return _st_GoodsNo; }
            set { _st_GoodsNo = value; }
        }

        /// public propaty name  :  Ed_GoodsNo
        /// <summary>終了商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_GoodsNo
        {
            get { return _ed_GoodsNo; }
            set { _ed_GoodsNo = value; }
        }

        /// public propaty name  :  St_BLGoodsCode
        /// <summary>開始BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_BLGoodsCode
        {
            get { return _st_BLGoodsCode; }
            set { _st_BLGoodsCode = value; }
        }

        /// public propaty name  :  Ed_BLGoodsCode
        /// <summary>終了BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_BLGoodsCode
        {
            get { return _ed_BLGoodsCode; }
            set { _ed_BLGoodsCode = value; }
        }

        /// public propaty name  :  St_LargeGoodsGanreCode
        /// <summary>開始商品区分グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品区分グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_LargeGoodsGanreCode
        {
            get { return _st_LargeGoodsGanreCode; }
            set { _st_LargeGoodsGanreCode = value; }
        }

        /// public propaty name  :  Ed_LargeGoodsGanreCode
        /// <summary>終了商品区分グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品区分グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_LargeGoodsGanreCode
        {
            get { return _ed_LargeGoodsGanreCode; }
            set { _ed_LargeGoodsGanreCode = value; }
        }

        /// public propaty name  :  St_MediumGoodsGanreCode
        /// <summary>開始商品区分コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_MediumGoodsGanreCode
        {
            get { return _st_MediumGoodsGanreCode; }
            set { _st_MediumGoodsGanreCode = value; }
        }

        /// public propaty name  :  Ed_MediumGoodsGanreCode
        /// <summary>終了商品区分コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_MediumGoodsGanreCode
        {
            get { return _ed_MediumGoodsGanreCode; }
            set { _ed_MediumGoodsGanreCode = value; }
        }

        /// public propaty name  :  St_DetailGoodsGanreCode
        /// <summary>開始商品区分詳細コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品区分詳細コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_DetailGoodsGanreCode
        {
            get { return _st_DetailGoodsGanreCode; }
            set { _st_DetailGoodsGanreCode = value; }
        }

        /// public propaty name  :  Ed_DetailGoodsGanreCode
        /// <summary>終了商品区分詳細コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品区分詳細コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_DetailGoodsGanreCode
        {
            get { return _ed_DetailGoodsGanreCode; }
            set { _ed_DetailGoodsGanreCode = value; }
        }

        /// public propaty name  :  St_EnterpriseGanreCode
        /// <summary>開始自社分類コードプロパティ</summary>
        /// <value>1～899:提供分, 900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始自社分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_EnterpriseGanreCode
        {
            get { return _st_EnterpriseGanreCode; }
            set { _st_EnterpriseGanreCode = value; }
        }

        /// public propaty name  :  Ed_EnterpriseGanreCode
        /// <summary>終了自社分類コードプロパティ</summary>
        /// <value>1～899:提供分, 900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了自社分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_EnterpriseGanreCode
        {
            get { return _ed_EnterpriseGanreCode; }
            set { _ed_EnterpriseGanreCode = value; }
        }

        /// public propaty name  :  St_TotalStockCount
        /// <summary>開始出荷数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始出荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double St_TotalStockCount
        {
            get { return _st_TotalStockCount; }
            set { _st_TotalStockCount = value; }
        }

        /// public propaty name  :  Ed_TotalStockCount
        /// <summary>終了出荷数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了出荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double Ed_TotalStockCount
        {
            get { return _ed_TotalStockCount; }
            set { _ed_TotalStockCount = value; }
        }


        /// <summary>
        /// 仕入推移表抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>StockTransListCndtnWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockTransListCndtnWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockTransListCndtnWork()
        {
        }

    }
}
