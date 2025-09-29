using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockManagementListCndtnWork
    /// <summary>
    ///                      在庫管理表抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫管理表抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/09/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockManagementListCndtnWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>開始年月度</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _st_AddUpYearMonth;

        /// <summary>終了年月度</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _ed_AddUpYearMonth;

        /// <summary>拠点コード</summary>
        /// <remarks>（配列）</remarks>
        private string[] _sectionCodes;

        /// <summary>開始倉庫コード</summary>
        private string _st_WarehouseCode = "";

        /// <summary>終了倉庫コード</summary>
        private string _ed_WarehouseCode = "";

        /// <summary>開始商品メーカーコード</summary>
        private Int32 _st_GoodsMakerCd;

        /// <summary>終了商品メーカーコード</summary>
        private Int32 _ed_GoodsMakerCd;

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
        private Int32 _st_EnterpriseGanreCode;

        /// <summary>終了自社分類コード</summary>
        private Int32 _ed_EnterpriseGanreCode;

        /// <summary>開始ＢＬ商品コード</summary>
        private Int32 _st_BLGoodsCode;

        /// <summary>終了ＢＬ商品コード</summary>
        private Int32 _ed_BLGoodsCode;

        /// <summary>期首月以後累計区分</summary>
        /// <remarks>0:累計印字しない, 1:累計印字する (累計=期首月からの累積合計)</remarks>
        private Int32 _accumulatePrintDiv;


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

        /// public propaty name  :  St_AddUpYearMonth
        /// <summary>開始年月度プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始年月度プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_AddUpYearMonth
        {
            get { return _st_AddUpYearMonth; }
            set { _st_AddUpYearMonth = value; }
        }

        /// public propaty name  :  Ed_AddUpYearMonth
        /// <summary>終了年月度プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了年月度プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_AddUpYearMonth
        {
            get { return _ed_AddUpYearMonth; }
            set { _ed_AddUpYearMonth = value; }
        }

        /// public propaty name  :  SectionCodes
        /// <summary>拠点コードプロパティ</summary>
        /// <value>（配列）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
        }

        /// public propaty name  :  St_WarehouseCode
        /// <summary>開始倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_WarehouseCode
        {
            get { return _st_WarehouseCode; }
            set { _st_WarehouseCode = value; }
        }

        /// public propaty name  :  Ed_WarehouseCode
        /// <summary>終了倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_WarehouseCode
        {
            get { return _ed_WarehouseCode; }
            set { _ed_WarehouseCode = value; }
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

        /// public propaty name  :  St_BLGoodsCode
        /// <summary>開始ＢＬ商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始ＢＬ商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_BLGoodsCode
        {
            get { return _st_BLGoodsCode; }
            set { _st_BLGoodsCode = value; }
        }

        /// public propaty name  :  Ed_BLGoodsCode
        /// <summary>終了ＢＬ商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了ＢＬ商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_BLGoodsCode
        {
            get { return _ed_BLGoodsCode; }
            set { _ed_BLGoodsCode = value; }
        }

        /// public propaty name  :  AccumulatePrintDiv
        /// <summary>期首月以後累計区分プロパティ</summary>
        /// <value>0:累計印字しない, 1:累計印字する (累計=期首月からの累積合計)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   期首月以後累計区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AccumulatePrintDiv
        {
            get { return _accumulatePrintDiv; }
            set { _accumulatePrintDiv = value; }
        }


        /// <summary>
        /// 在庫管理表抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>StockManagementListCndtnWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockManagementListCndtnWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockManagementListCndtnWork()
        {
        }

    }
}




