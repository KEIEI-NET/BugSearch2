using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   ExtrInfo_SalesOrderRemainClear
    /// <summary>
    ///                      発注残クリア抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   発注残クリア抽出条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class ExtrInfo_SalesOrderRemainClear
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>開始倉庫コード</summary>
        private string _st_WarehouseCode = "";

        /// <summary>終了倉庫コード</summary>
        private string _ed_WarehouseCode = "";

        /// <summary>開始仕入先コード</summary>
        private Int32 _st_SupplierCd;

        /// <summary>終了仕入先コード</summary>
        private Int32 _ed_SupplierCd;

        /// <summary>開始メーカーコード</summary>
        private Int32 _st_GoodsMakerCd;

        /// <summary>終了メーカーコード</summary>
        private Int32 _ed_GoodsMakerCd;

        /// <summary>開始BL商品コード</summary>
        private Int32 _st_BLGoodsCode;

        /// <summary>終了BL商品コード</summary>
        private Int32 _ed_BLGoodsCode;

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
        /// <summary>開始メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_GoodsMakerCd
        {
            get { return _st_GoodsMakerCd; }
            set { _st_GoodsMakerCd = value; }
        }

        /// public propaty name  :  Ed_GoodsMakerCd
        /// <summary>終了メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_GoodsMakerCd
        {
            get { return _ed_GoodsMakerCd; }
            set { _ed_GoodsMakerCd = value; }
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
        /// 発注残クリア抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>ExtrInfo_SalesOrderRemainClearクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ExtrInfo_SalesOrderRemainClearクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ExtrInfo_SalesOrderRemainClear()
        {
        }

        /// <summary>
        /// 発注残クリア抽出条件クラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="st_WarehouseCode">開始倉庫コード</param>
        /// <param name="ed_WarehouseCode">終了倉庫コード</param>
        /// <param name="st_SupplierCd">開始仕入先コード</param>
        /// <param name="ed_SupplierCd">終了仕入先コード</param>
        /// <param name="st_GoodsMakerCd">開始メーカーコード</param>
        /// <param name="ed_GoodsMakerCd">終了メーカーコード</param>
        /// <param name="st_BLGoodsCode">開始BL商品コード</param>
        /// <param name="ed_BLGoodsCode">終了BL商品コード</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <returns>ExtrInfo_SalesOrderRemainClearクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ExtrInfo_SalesOrderRemainClearクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ExtrInfo_SalesOrderRemainClear(string enterpriseCode, string st_WarehouseCode, string ed_WarehouseCode, Int32 st_SupplierCd, Int32 ed_SupplierCd, Int32 st_GoodsMakerCd, Int32 ed_GoodsMakerCd, Int32 st_BLGoodsCode, Int32 ed_BLGoodsCode, string enterpriseName)
        {
            this._enterpriseCode = enterpriseCode;
            this._st_WarehouseCode = st_WarehouseCode;
            this._ed_WarehouseCode = ed_WarehouseCode;
            this._st_SupplierCd = st_SupplierCd;
            this._ed_SupplierCd = ed_SupplierCd;
            this._st_GoodsMakerCd = st_GoodsMakerCd;
            this._ed_GoodsMakerCd = ed_GoodsMakerCd;
            this._st_BLGoodsCode = st_BLGoodsCode;
            this._ed_BLGoodsCode = ed_BLGoodsCode;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// 発注残クリア抽出条件クラス複製処理
        /// </summary>
        /// <returns>ExtrInfo_SalesOrderRemainClearクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいExtrInfo_SalesOrderRemainClearクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ExtrInfo_SalesOrderRemainClear Clone()
        {
            return new ExtrInfo_SalesOrderRemainClear(this._enterpriseCode, this._st_WarehouseCode, this._ed_WarehouseCode, this._st_SupplierCd, this._ed_SupplierCd, this._st_GoodsMakerCd, this._ed_GoodsMakerCd, this._st_BLGoodsCode, this._ed_BLGoodsCode, this._enterpriseName);
        }

        /// <summary>
        /// 発注残クリア抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のExtrInfo_SalesOrderRemainClearクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ExtrInfo_SalesOrderRemainClearクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(ExtrInfo_SalesOrderRemainClear target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.St_WarehouseCode == target.St_WarehouseCode)
                 && (this.Ed_WarehouseCode == target.Ed_WarehouseCode)
                 && (this.St_SupplierCd == target.St_SupplierCd)
                 && (this.Ed_SupplierCd == target.Ed_SupplierCd)
                 && (this.St_GoodsMakerCd == target.St_GoodsMakerCd)
                 && (this.Ed_GoodsMakerCd == target.Ed_GoodsMakerCd)
                 && (this.St_BLGoodsCode == target.St_BLGoodsCode)
                 && (this.Ed_BLGoodsCode == target.Ed_BLGoodsCode)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// 発注残クリア抽出条件クラス比較処理
        /// </summary>
        /// <param name="extrInfo_SalesOrderRemainClear1">
        ///                    比較するExtrInfo_SalesOrderRemainClearクラスのインスタンス
        /// </param>
        /// <param name="extrInfo_SalesOrderRemainClear2">比較するExtrInfo_SalesOrderRemainClearクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ExtrInfo_SalesOrderRemainClearクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(ExtrInfo_SalesOrderRemainClear extrInfo_SalesOrderRemainClear1, ExtrInfo_SalesOrderRemainClear extrInfo_SalesOrderRemainClear2)
        {
            return ((extrInfo_SalesOrderRemainClear1.EnterpriseCode == extrInfo_SalesOrderRemainClear2.EnterpriseCode)
                 && (extrInfo_SalesOrderRemainClear1.St_WarehouseCode == extrInfo_SalesOrderRemainClear2.St_WarehouseCode)
                 && (extrInfo_SalesOrderRemainClear1.Ed_WarehouseCode == extrInfo_SalesOrderRemainClear2.Ed_WarehouseCode)
                 && (extrInfo_SalesOrderRemainClear1.St_SupplierCd == extrInfo_SalesOrderRemainClear2.St_SupplierCd)
                 && (extrInfo_SalesOrderRemainClear1.Ed_SupplierCd == extrInfo_SalesOrderRemainClear2.Ed_SupplierCd)
                 && (extrInfo_SalesOrderRemainClear1.St_GoodsMakerCd == extrInfo_SalesOrderRemainClear2.St_GoodsMakerCd)
                 && (extrInfo_SalesOrderRemainClear1.Ed_GoodsMakerCd == extrInfo_SalesOrderRemainClear2.Ed_GoodsMakerCd)
                 && (extrInfo_SalesOrderRemainClear1.St_BLGoodsCode == extrInfo_SalesOrderRemainClear2.St_BLGoodsCode)
                 && (extrInfo_SalesOrderRemainClear1.Ed_BLGoodsCode == extrInfo_SalesOrderRemainClear2.Ed_BLGoodsCode)
                 && (extrInfo_SalesOrderRemainClear1.EnterpriseName == extrInfo_SalesOrderRemainClear2.EnterpriseName));
        }
        /// <summary>
        /// 発注残クリア抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のExtrInfo_SalesOrderRemainClearクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ExtrInfo_SalesOrderRemainClearクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(ExtrInfo_SalesOrderRemainClear target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.St_WarehouseCode != target.St_WarehouseCode) resList.Add("St_WarehouseCode");
            if (this.Ed_WarehouseCode != target.Ed_WarehouseCode) resList.Add("Ed_WarehouseCode");
            if (this.St_SupplierCd != target.St_SupplierCd) resList.Add("St_SupplierCd");
            if (this.Ed_SupplierCd != target.Ed_SupplierCd) resList.Add("Ed_SupplierCd");
            if (this.St_GoodsMakerCd != target.St_GoodsMakerCd) resList.Add("St_GoodsMakerCd");
            if (this.Ed_GoodsMakerCd != target.Ed_GoodsMakerCd) resList.Add("Ed_GoodsMakerCd");
            if (this.St_BLGoodsCode != target.St_BLGoodsCode) resList.Add("St_BLGoodsCode");
            if (this.Ed_BLGoodsCode != target.Ed_BLGoodsCode) resList.Add("Ed_BLGoodsCode");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// 発注残クリア抽出条件クラス比較処理
        /// </summary>
        /// <param name="extrInfo_SalesOrderRemainClear1">比較するExtrInfo_SalesOrderRemainClearクラスのインスタンス</param>
        /// <param name="extrInfo_SalesOrderRemainClear2">比較するExtrInfo_SalesOrderRemainClearクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ExtrInfo_SalesOrderRemainClearクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(ExtrInfo_SalesOrderRemainClear extrInfo_SalesOrderRemainClear1, ExtrInfo_SalesOrderRemainClear extrInfo_SalesOrderRemainClear2)
        {
            ArrayList resList = new ArrayList();
            if (extrInfo_SalesOrderRemainClear1.EnterpriseCode != extrInfo_SalesOrderRemainClear2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (extrInfo_SalesOrderRemainClear1.St_WarehouseCode != extrInfo_SalesOrderRemainClear2.St_WarehouseCode) resList.Add("St_WarehouseCode");
            if (extrInfo_SalesOrderRemainClear1.Ed_WarehouseCode != extrInfo_SalesOrderRemainClear2.Ed_WarehouseCode) resList.Add("Ed_WarehouseCode");
            if (extrInfo_SalesOrderRemainClear1.St_SupplierCd != extrInfo_SalesOrderRemainClear2.St_SupplierCd) resList.Add("St_SupplierCd");
            if (extrInfo_SalesOrderRemainClear1.Ed_SupplierCd != extrInfo_SalesOrderRemainClear2.Ed_SupplierCd) resList.Add("Ed_SupplierCd");
            if (extrInfo_SalesOrderRemainClear1.St_GoodsMakerCd != extrInfo_SalesOrderRemainClear2.St_GoodsMakerCd) resList.Add("St_GoodsMakerCd");
            if (extrInfo_SalesOrderRemainClear1.Ed_GoodsMakerCd != extrInfo_SalesOrderRemainClear2.Ed_GoodsMakerCd) resList.Add("Ed_GoodsMakerCd");
            if (extrInfo_SalesOrderRemainClear1.St_BLGoodsCode != extrInfo_SalesOrderRemainClear2.St_BLGoodsCode) resList.Add("St_BLGoodsCode");
            if (extrInfo_SalesOrderRemainClear1.Ed_BLGoodsCode != extrInfo_SalesOrderRemainClear2.Ed_BLGoodsCode) resList.Add("Ed_BLGoodsCode");
            if (extrInfo_SalesOrderRemainClear1.EnterpriseName != extrInfo_SalesOrderRemainClear2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}
