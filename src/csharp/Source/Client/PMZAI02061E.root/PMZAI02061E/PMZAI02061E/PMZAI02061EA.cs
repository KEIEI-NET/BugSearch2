using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   TrustStockOrderCndtn
    /// <summary>
    ///                      委託在庫補充処理抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   委託在庫補充処理抽出条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class TrustStockOrderCndtn
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>倉庫コード(開始)</summary>
        private string _st_WarehouseCode = "";

        /// <summary>倉庫コード(終了)</summary>
        private string _ed_WarehouseCode = "";

        /// <summary>商品メーカーコード(開始)</summary>
        private Int32 _st_GoodsMakerCd;

        /// <summary>商品メーカーコード(終了)</summary>
        private Int32 _ed_GoodsMakerCd;

        /// <summary>商品番号(開始)</summary>
        private string _st_GoodsNo = "";

        /// <summary>商品番号(終了)</summary>
        private string _ed_GoodsNo = "";

        /// <summary>補充元在庫不足時</summary>
        /// <remarks>0:未更新 1:無視して更新 2:ゼロまで更新</remarks>
        private Int32 _replenishLackStock;

        /// <summary>補充元商品無し時</summary>
        /// <remarks>0:未更新 1:無視して更新</remarks>
        private Int32 _replenishNoneGoods;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>補充更新</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _stockUpdate;

        /// <summary>一覧表印刷</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _printAll;

        /// <summary>改頁</summary>
        /// <remarks>0:しない 1:メーカー</remarks>
        private Int32 _newPage;


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
        /// <summary>倉庫コード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_WarehouseCode
        {
            get { return _st_WarehouseCode; }
            set { _st_WarehouseCode = value; }
        }

        /// public propaty name  :  Ed_WarehouseCode
        /// <summary>倉庫コード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_WarehouseCode
        {
            get { return _ed_WarehouseCode; }
            set { _ed_WarehouseCode = value; }
        }

        /// public propaty name  :  St_GoodsMakerCd
        /// <summary>商品メーカーコード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_GoodsMakerCd
        {
            get { return _st_GoodsMakerCd; }
            set { _st_GoodsMakerCd = value; }
        }

        /// public propaty name  :  Ed_GoodsMakerCd
        /// <summary>商品メーカーコード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_GoodsMakerCd
        {
            get { return _ed_GoodsMakerCd; }
            set { _ed_GoodsMakerCd = value; }
        }

        /// public propaty name  :  St_GoodsNo
        /// <summary>商品番号(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_GoodsNo
        {
            get { return _st_GoodsNo; }
            set { _st_GoodsNo = value; }
        }

        /// public propaty name  :  Ed_GoodsNo
        /// <summary>商品番号(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_GoodsNo
        {
            get { return _ed_GoodsNo; }
            set { _ed_GoodsNo = value; }
        }

        /// public propaty name  :  ReplenishLackStock
        /// <summary>補充元在庫不足時プロパティ</summary>
        /// <value>0:未更新 1:無視して更新 2:ゼロまで更新</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   補充元在庫不足時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ReplenishLackStock
        {
            get { return _replenishLackStock; }
            set { _replenishLackStock = value; }
        }

        /// public propaty name  :  ReplenishNoneGoods
        /// <summary>補充元商品無し時プロパティ</summary>
        /// <value>0:未更新 1:無視して更新</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   補充元商品無し時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ReplenishNoneGoods
        {
            get { return _replenishNoneGoods; }
            set { _replenishNoneGoods = value; }
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

        /// public propaty name  :  StockUpdate
        /// <summary>補充更新プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   補充更新プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockUpdate
        {
            get { return _stockUpdate; }
            set { _stockUpdate = value; }
        }

        /// public propaty name  :  PrintAll
        /// <summary>一覧表印刷プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   一覧表印刷プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintAll
        {
            get { return _printAll; }
            set { _printAll = value; }
        }

        /// public propaty name  :  NewPage
        /// <summary>改頁プロパティ</summary>
        /// <value>0:しない 1:メーカー</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改頁プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NewPage
        {
            get { return _newPage; }
            set { _newPage = value; }
        }

        /// <summary>
        /// 委託在庫補充処理抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>TrustStockOrderCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TrustStockOrderCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TrustStockOrderCndtn()
        {
        }

        /// <summary>
        /// 委託在庫補充処理抽出条件クラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="st_WarehouseCode">倉庫コード(開始)</param>
        /// <param name="ed_WarehouseCode">倉庫コード(終了)</param>
        /// <param name="st_GoodsMakerCd">商品メーカーコード(開始)</param>
        /// <param name="ed_GoodsMakerCd">商品メーカーコード(終了)</param>
        /// <param name="st_GoodsNo">商品番号(開始)</param>
        /// <param name="ed_GoodsNo">商品番号(終了)</param>
        /// <param name="replenishLackStock">補充元在庫不足時(0:未更新 1:無視して更新 2:ゼロまで更新)</param>
        /// <param name="replenishNoneGoods">補充元商品無し時(0:未更新 1:無視して更新)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="stockUpdate">補充更新</param>
        /// <param name="printAll">一覧表印刷</param>
        /// <param name="newPage">改頁</param>
        /// <returns>TrustStockOrderCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TrustStockOrderCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TrustStockOrderCndtn(string enterpriseCode, string st_WarehouseCode, string ed_WarehouseCode, Int32 st_GoodsMakerCd, Int32 ed_GoodsMakerCd, string st_GoodsNo, string ed_GoodsNo, Int32 replenishLackStock, Int32 replenishNoneGoods, string enterpriseName, Int32 stockUpdate, Int32 printAll, Int32 newPage)
        {
            this._enterpriseCode = enterpriseCode;
            this._st_WarehouseCode = st_WarehouseCode;
            this._ed_WarehouseCode = ed_WarehouseCode;
            this._st_GoodsMakerCd = st_GoodsMakerCd;
            this._ed_GoodsMakerCd = ed_GoodsMakerCd;
            this._st_GoodsNo = st_GoodsNo;
            this._ed_GoodsNo = ed_GoodsNo;
            this._replenishLackStock = replenishLackStock;
            this._replenishNoneGoods = replenishNoneGoods;
            this._enterpriseName = enterpriseName;
            this._stockUpdate = stockUpdate;
            this._printAll = printAll;
            this._newPage = newPage;
        }

        /// <summary>
        /// 委託在庫補充処理抽出条件クラス複製処理
        /// </summary>
        /// <returns>TrustStockOrderCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいTrustStockOrderCndtnクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TrustStockOrderCndtn Clone()
        {
            return new TrustStockOrderCndtn(this._enterpriseCode, this._st_WarehouseCode, this._ed_WarehouseCode, this._st_GoodsMakerCd, this._ed_GoodsMakerCd, this._st_GoodsNo, this._ed_GoodsNo, this._replenishLackStock, this._replenishNoneGoods, this._enterpriseName, this._stockUpdate, this._printAll, this._newPage);
        }

        /// <summary>
        /// 委託在庫補充処理抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のTrustStockOrderCndtnクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TrustStockOrderCndtnクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(TrustStockOrderCndtn target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.St_WarehouseCode == target.St_WarehouseCode)
                 && (this.Ed_WarehouseCode == target.Ed_WarehouseCode)
                 && (this.St_GoodsMakerCd == target.St_GoodsMakerCd)
                 && (this.Ed_GoodsMakerCd == target.Ed_GoodsMakerCd)
                 && (this.St_GoodsNo == target.St_GoodsNo)
                 && (this.Ed_GoodsNo == target.Ed_GoodsNo)
                 && (this.ReplenishLackStock == target.ReplenishLackStock)
                 && (this.ReplenishNoneGoods == target.ReplenishNoneGoods)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.StockUpdate == target.StockUpdate)
                 && (this.PrintAll == target.PrintAll)
                 && (this.NewPage == target.NewPage));
        }

        /// <summary>
        /// 委託在庫補充処理抽出条件クラス比較処理
        /// </summary>
        /// <param name="trustStockOrderCndtn1">
        ///                    比較するTrustStockOrderCndtnクラスのインスタンス
        /// </param>
        /// <param name="trustStockOrderCndtn2">比較するTrustStockOrderCndtnクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TrustStockOrderCndtnクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(TrustStockOrderCndtn trustStockOrderCndtn1, TrustStockOrderCndtn trustStockOrderCndtn2)
        {
            return ((trustStockOrderCndtn1.EnterpriseCode == trustStockOrderCndtn2.EnterpriseCode)
                 && (trustStockOrderCndtn1.St_WarehouseCode == trustStockOrderCndtn2.St_WarehouseCode)
                 && (trustStockOrderCndtn1.Ed_WarehouseCode == trustStockOrderCndtn2.Ed_WarehouseCode)
                 && (trustStockOrderCndtn1.St_GoodsMakerCd == trustStockOrderCndtn2.St_GoodsMakerCd)
                 && (trustStockOrderCndtn1.Ed_GoodsMakerCd == trustStockOrderCndtn2.Ed_GoodsMakerCd)
                 && (trustStockOrderCndtn1.St_GoodsNo == trustStockOrderCndtn2.St_GoodsNo)
                 && (trustStockOrderCndtn1.Ed_GoodsNo == trustStockOrderCndtn2.Ed_GoodsNo)
                 && (trustStockOrderCndtn1.ReplenishLackStock == trustStockOrderCndtn2.ReplenishLackStock)
                 && (trustStockOrderCndtn1.ReplenishNoneGoods == trustStockOrderCndtn2.ReplenishNoneGoods)
                 && (trustStockOrderCndtn1.EnterpriseName == trustStockOrderCndtn2.EnterpriseName)
                 && (trustStockOrderCndtn1.StockUpdate == trustStockOrderCndtn2.StockUpdate)
                 && (trustStockOrderCndtn1.PrintAll == trustStockOrderCndtn2.PrintAll)
                 && (trustStockOrderCndtn1.NewPage == trustStockOrderCndtn2.NewPage));
        }
        /// <summary>
        /// 委託在庫補充処理抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のTrustStockOrderCndtnクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TrustStockOrderCndtnクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(TrustStockOrderCndtn target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.St_WarehouseCode != target.St_WarehouseCode) resList.Add("St_WarehouseCode");
            if (this.Ed_WarehouseCode != target.Ed_WarehouseCode) resList.Add("Ed_WarehouseCode");
            if (this.St_GoodsMakerCd != target.St_GoodsMakerCd) resList.Add("St_GoodsMakerCd");
            if (this.Ed_GoodsMakerCd != target.Ed_GoodsMakerCd) resList.Add("Ed_GoodsMakerCd");
            if (this.St_GoodsNo != target.St_GoodsNo) resList.Add("St_GoodsNo");
            if (this.Ed_GoodsNo != target.Ed_GoodsNo) resList.Add("Ed_GoodsNo");
            if (this.ReplenishLackStock != target.ReplenishLackStock) resList.Add("ReplenishLackStock");
            if (this.ReplenishNoneGoods != target.ReplenishNoneGoods) resList.Add("ReplenishNoneGoods");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.StockUpdate != target.StockUpdate) resList.Add("StockUpdate");
            if (this.PrintAll != target.PrintAll) resList.Add("PrintAll");
            if (this.NewPage != target.NewPage) resList.Add("NewPage");

            return resList;
        }

        /// <summary>
        /// 委託在庫補充処理抽出条件クラス比較処理
        /// </summary>
        /// <param name="trustStockOrderCndtn1">比較するTrustStockOrderCndtnクラスのインスタンス</param>
        /// <param name="trustStockOrderCndtn2">比較するTrustStockOrderCndtnクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TrustStockOrderCndtnクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(TrustStockOrderCndtn trustStockOrderCndtn1, TrustStockOrderCndtn trustStockOrderCndtn2)
        {
            ArrayList resList = new ArrayList();
            if (trustStockOrderCndtn1.EnterpriseCode != trustStockOrderCndtn2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (trustStockOrderCndtn1.St_WarehouseCode != trustStockOrderCndtn2.St_WarehouseCode) resList.Add("St_WarehouseCode");
            if (trustStockOrderCndtn1.Ed_WarehouseCode != trustStockOrderCndtn2.Ed_WarehouseCode) resList.Add("Ed_WarehouseCode");
            if (trustStockOrderCndtn1.St_GoodsMakerCd != trustStockOrderCndtn2.St_GoodsMakerCd) resList.Add("St_GoodsMakerCd");
            if (trustStockOrderCndtn1.Ed_GoodsMakerCd != trustStockOrderCndtn2.Ed_GoodsMakerCd) resList.Add("Ed_GoodsMakerCd");
            if (trustStockOrderCndtn1.St_GoodsNo != trustStockOrderCndtn2.St_GoodsNo) resList.Add("St_GoodsNo");
            if (trustStockOrderCndtn1.Ed_GoodsNo != trustStockOrderCndtn2.Ed_GoodsNo) resList.Add("Ed_GoodsNo");
            if (trustStockOrderCndtn1.ReplenishLackStock != trustStockOrderCndtn2.ReplenishLackStock) resList.Add("ReplenishLackStock");
            if (trustStockOrderCndtn1.ReplenishNoneGoods != trustStockOrderCndtn2.ReplenishNoneGoods) resList.Add("ReplenishNoneGoods");
            if (trustStockOrderCndtn1.EnterpriseName != trustStockOrderCndtn2.EnterpriseName) resList.Add("EnterpriseName");
            if (trustStockOrderCndtn1.StockUpdate != trustStockOrderCndtn2.StockUpdate) resList.Add("StockUpdate");
            if (trustStockOrderCndtn1.PrintAll != trustStockOrderCndtn2.PrintAll) resList.Add("PrintAll");
            if (trustStockOrderCndtn1.NewPage != trustStockOrderCndtn2.NewPage) resList.Add("NewPage");

            return resList;
        }
    }
}
