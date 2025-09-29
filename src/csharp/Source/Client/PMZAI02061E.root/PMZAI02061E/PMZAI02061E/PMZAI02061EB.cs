using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   TrustStockResult
    /// <summary>
    ///                      委託在庫補充処理抽出結果クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   委託在庫補充処理抽出結果クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class TrustStockResult
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>倉庫コード(委託)</summary>
        /// <remarks>倉庫マスタ</remarks>
        private string _tru_WarehouseCode = "";

        /// <summary>倉庫名称(委託)</summary>
        private string _tru_WarehouseName = "";

        /// <summary>倉庫コード(補充元)</summary>
        /// <remarks>在庫マスタ </remarks>
        private string _rep_WarehouseCode = "";

        /// <summary>倉庫名称(補充元)</summary>
        private string _rep_WarehouseName = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー略称</summary>
        private string _makerShortName = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>倉庫棚番(委託)</summary>
        private string _tru_WarehouseShelfNo = "";

        /// <summary>最高在庫数</summary>
        private Double _maximumStockCnt;

        /// <summary>出荷可能数(委託)</summary>
        /// <remarks>出荷可能数＝仕入在庫数 ＋ 入荷数（未計上）－ 出荷数（未計上）－受注数 － 移動中仕入在庫数</remarks>
        private Double _tru_ShipmentPosCnt;

        /// <summary>補充数</summary>
        /// <remarks>委託倉庫最高数－委託倉庫現在庫数</remarks>
        private Double _replenishCount;

        /// <summary>補充後現在個数</summary>
        /// <remarks>出荷可能数－補充数</remarks>
        private Double _replenishNStockCount;

        /// <summary>倉庫棚番(補充元)</summary>
        private string _rep_WarehouseShelfNo = "";

        /// <summary>出荷可能数(補充元)</summary>
        /// <remarks>出荷可能数＝仕入在庫数 ＋ 入荷数（未計上）－ 出荷数（未計上）－受注数 － 移動中仕入在庫数</remarks>
        private Double _rep_ShipmentPosCnt;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>商品存在フラグ</summary>
        /// <remarks>0:登録済  1:未登録</remarks>
        private Int32 _goodsFlg;


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

        /// public propaty name  :  Tru_WarehouseCode
        /// <summary>倉庫コード(委託)プロパティ</summary>
        /// <value>倉庫マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード(委託)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Tru_WarehouseCode
        {
            get { return _tru_WarehouseCode; }
            set { _tru_WarehouseCode = value; }
        }

        /// public propaty name  :  Tru_WarehouseName
        /// <summary>倉庫名称(委託)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名称(委託)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Tru_WarehouseName
        {
            get { return _tru_WarehouseName; }
            set { _tru_WarehouseName = value; }
        }

        /// public propaty name  :  Rep_WarehouseCode
        /// <summary>倉庫コード(補充元)プロパティ</summary>
        /// <value>在庫マスタ </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード(補充元)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Rep_WarehouseCode
        {
            get { return _rep_WarehouseCode; }
            set { _rep_WarehouseCode = value; }
        }

        /// public propaty name  :  Rep_WarehouseName
        /// <summary>倉庫名称(補充元)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名称(補充元)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Rep_WarehouseName
        {
            get { return _rep_WarehouseName; }
            set { _rep_WarehouseName = value; }
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

        /// public propaty name  :  MakerShortName
        /// <summary>メーカー略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerShortName
        {
            get { return _makerShortName; }
            set { _makerShortName = value; }
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

        /// public propaty name  :  GoodsName
        /// <summary>商品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  Tru_WarehouseShelfNo
        /// <summary>倉庫棚番(委託)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫棚番(委託)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Tru_WarehouseShelfNo
        {
            get { return _tru_WarehouseShelfNo; }
            set { _tru_WarehouseShelfNo = value; }
        }

        /// public propaty name  :  MaximumStockCnt
        /// <summary>最高在庫数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最高在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MaximumStockCnt
        {
            get { return _maximumStockCnt; }
            set { _maximumStockCnt = value; }
        }

        /// public propaty name  :  Tru_ShipmentPosCnt
        /// <summary>出荷可能数(委託)プロパティ</summary>
        /// <value>出荷可能数＝仕入在庫数 ＋ 入荷数（未計上）－ 出荷数（未計上）－受注数 － 移動中仕入在庫数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷可能数(委託)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double Tru_ShipmentPosCnt
        {
            get { return _tru_ShipmentPosCnt; }
            set { _tru_ShipmentPosCnt = value; }
        }

        /// public propaty name  :  ReplenishCount
        /// <summary>補充数プロパティ</summary>
        /// <value>委託倉庫最高数－委託倉庫現在庫数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   補充数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ReplenishCount
        {
            get { return _replenishCount; }
            set { _replenishCount = value; }
        }

        /// public propaty name  :  ReplenishNStockCount
        /// <summary>補充後現在個数プロパティ</summary>
        /// <value>出荷可能数－補充数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   補充後現在個数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ReplenishNStockCount
        {
            get { return _replenishNStockCount; }
            set { _replenishNStockCount = value; }
        }

        /// public propaty name  :  Rep_WarehouseShelfNo
        /// <summary>倉庫棚番(補充元)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫棚番(補充元)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Rep_WarehouseShelfNo
        {
            get { return _rep_WarehouseShelfNo; }
            set { _rep_WarehouseShelfNo = value; }
        }

        /// public propaty name  :  Rep_ShipmentPosCnt
        /// <summary>出荷可能数(補充元)プロパティ</summary>
        /// <value>出荷可能数＝仕入在庫数 ＋ 入荷数（未計上）－ 出荷数（未計上）－受注数 － 移動中仕入在庫数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷可能数(補充元)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double Rep_ShipmentPosCnt
        {
            get { return _rep_ShipmentPosCnt; }
            set { _rep_ShipmentPosCnt = value; }
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

        /// public propaty name  :  GoodsFlg
        /// <summary>商品存在フラグプロパティ</summary>
        /// <value>0:登録済  1:未登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品存在フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsFlg
        {
            get { return _goodsFlg; }
            set { _goodsFlg = value; }
        }


        /// <summary>
        /// 委託在庫補充処理抽出結果クラスコンストラクタ
        /// </summary>
        /// <returns>TrustStockResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TrustStockResultクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TrustStockResult()
        {
        }

        /// <summary>
        /// 委託在庫補充処理抽出結果クラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="tru_WarehouseCode">倉庫コード(委託)(倉庫マスタ)</param>
        /// <param name="tru_WarehouseName">倉庫名称(委託)</param>
        /// <param name="rep_WarehouseCode">倉庫コード(補充元)(在庫マスタ )</param>
        /// <param name="rep_WarehouseName">倉庫名称(補充元)</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="makerShortName">メーカー略称</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="goodsName">商品名称</param>
        /// <param name="tru_WarehouseShelfNo">倉庫棚番(委託)</param>
        /// <param name="maximumStockCnt">最高在庫数</param>
        /// <param name="tru_ShipmentPosCnt">出荷可能数(委託)(出荷可能数＝仕入在庫数 ＋ 入荷数（未計上）－ 出荷数（未計上）－受注数 － 移動中仕入在庫数)</param>
        /// <param name="replenishCount">補充数(委託倉庫最高数－委託倉庫現在庫数)</param>
        /// <param name="replenishNStockCount">補充後現在個数(出荷可能数－補充数)</param>
        /// <param name="rep_WarehouseShelfNo">倉庫棚番(補充元)</param>
        /// <param name="rep_ShipmentPosCnt">出荷可能数(補充元)(出荷可能数＝仕入在庫数 ＋ 入荷数（未計上）－ 出荷数（未計上）－受注数 － 移動中仕入在庫数)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="goodsFlg">商品存在フラグ</param>
        /// <returns>TrustStockResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TrustStockResultクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TrustStockResult(string enterpriseCode, string tru_WarehouseCode, string tru_WarehouseName, string rep_WarehouseCode, string rep_WarehouseName, Int32 goodsMakerCd, string makerShortName, string goodsNo, string goodsName, string tru_WarehouseShelfNo, Double maximumStockCnt, Double tru_ShipmentPosCnt, Double replenishCount, Double replenishNStockCount, string rep_WarehouseShelfNo, Double rep_ShipmentPosCnt, string enterpriseName, Int32 goodsFlg)
        {
            this._enterpriseCode = enterpriseCode;
            this._tru_WarehouseCode = tru_WarehouseCode;
            this._tru_WarehouseName = tru_WarehouseName;
            this._rep_WarehouseCode = rep_WarehouseCode;
            this._rep_WarehouseName = rep_WarehouseName;
            this._goodsMakerCd = goodsMakerCd;
            this._makerShortName = makerShortName;
            this._goodsNo = goodsNo;
            this._goodsName = goodsName;
            this._tru_WarehouseShelfNo = tru_WarehouseShelfNo;
            this._maximumStockCnt = maximumStockCnt;
            this._tru_ShipmentPosCnt = tru_ShipmentPosCnt;
            this._replenishCount = replenishCount;
            this._replenishNStockCount = replenishNStockCount;
            this._rep_WarehouseShelfNo = rep_WarehouseShelfNo;
            this._rep_ShipmentPosCnt = rep_ShipmentPosCnt;
            this._enterpriseName = enterpriseName;
            this._goodsFlg = goodsFlg;
        }

        /// <summary>
        /// 委託在庫補充処理抽出結果クラス複製処理
        /// </summary>
        /// <returns>TrustStockResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいTrustStockResultクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TrustStockResult Clone()
        {
            return new TrustStockResult(this._enterpriseCode, this._tru_WarehouseCode, this._tru_WarehouseName, this._rep_WarehouseCode, this._rep_WarehouseName, this._goodsMakerCd, this._makerShortName, this._goodsNo, this._goodsName, this._tru_WarehouseShelfNo, this._maximumStockCnt, this._tru_ShipmentPosCnt, this._replenishCount, this._replenishNStockCount, this._rep_WarehouseShelfNo, this._rep_ShipmentPosCnt, this._enterpriseName, this._goodsFlg);
        }

        /// <summary>
        /// 委託在庫補充処理抽出結果クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のTrustStockResultクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TrustStockResultクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(TrustStockResult target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.Tru_WarehouseCode == target.Tru_WarehouseCode)
                 && (this.Tru_WarehouseName == target.Tru_WarehouseName)
                 && (this.Rep_WarehouseCode == target.Rep_WarehouseCode)
                 && (this.Rep_WarehouseName == target.Rep_WarehouseName)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.MakerShortName == target.MakerShortName)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsName == target.GoodsName)
                 && (this.Tru_WarehouseShelfNo == target.Tru_WarehouseShelfNo)
                 && (this.MaximumStockCnt == target.MaximumStockCnt)
                 && (this.Tru_ShipmentPosCnt == target.Tru_ShipmentPosCnt)
                 && (this.ReplenishCount == target.ReplenishCount)
                 && (this.ReplenishNStockCount == target.ReplenishNStockCount)
                 && (this.Rep_WarehouseShelfNo == target.Rep_WarehouseShelfNo)
                 && (this.Rep_ShipmentPosCnt == target.Rep_ShipmentPosCnt)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.GoodsFlg == target.GoodsFlg));
        }

        /// <summary>
        /// 委託在庫補充処理抽出結果クラス比較処理
        /// </summary>
        /// <param name="trustStockResult1">
        ///                    比較するTrustStockResultクラスのインスタンス
        /// </param>
        /// <param name="trustStockResult2">比較するTrustStockResultクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TrustStockResultクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(TrustStockResult trustStockResult1, TrustStockResult trustStockResult2)
        {
            return ((trustStockResult1.EnterpriseCode == trustStockResult2.EnterpriseCode)
                 && (trustStockResult1.Tru_WarehouseCode == trustStockResult2.Tru_WarehouseCode)
                 && (trustStockResult1.Tru_WarehouseName == trustStockResult2.Tru_WarehouseName)
                 && (trustStockResult1.Rep_WarehouseCode == trustStockResult2.Rep_WarehouseCode)
                 && (trustStockResult1.Rep_WarehouseName == trustStockResult2.Rep_WarehouseName)
                 && (trustStockResult1.GoodsMakerCd == trustStockResult2.GoodsMakerCd)
                 && (trustStockResult1.MakerShortName == trustStockResult2.MakerShortName)
                 && (trustStockResult1.GoodsNo == trustStockResult2.GoodsNo)
                 && (trustStockResult1.GoodsName == trustStockResult2.GoodsName)
                 && (trustStockResult1.Tru_WarehouseShelfNo == trustStockResult2.Tru_WarehouseShelfNo)
                 && (trustStockResult1.MaximumStockCnt == trustStockResult2.MaximumStockCnt)
                 && (trustStockResult1.Tru_ShipmentPosCnt == trustStockResult2.Tru_ShipmentPosCnt)
                 && (trustStockResult1.ReplenishCount == trustStockResult2.ReplenishCount)
                 && (trustStockResult1.ReplenishNStockCount == trustStockResult2.ReplenishNStockCount)
                 && (trustStockResult1.Rep_WarehouseShelfNo == trustStockResult2.Rep_WarehouseShelfNo)
                 && (trustStockResult1.Rep_ShipmentPosCnt == trustStockResult2.Rep_ShipmentPosCnt)
                 && (trustStockResult1.EnterpriseName == trustStockResult2.EnterpriseName)
                 && (trustStockResult1.GoodsFlg == trustStockResult2.GoodsFlg));
        }
        /// <summary>
        /// 委託在庫補充処理抽出結果クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のTrustStockResultクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TrustStockResultクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(TrustStockResult target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.Tru_WarehouseCode != target.Tru_WarehouseCode) resList.Add("Tru_WarehouseCode");
            if (this.Tru_WarehouseName != target.Tru_WarehouseName) resList.Add("Tru_WarehouseName");
            if (this.Rep_WarehouseCode != target.Rep_WarehouseCode) resList.Add("Rep_WarehouseCode");
            if (this.Rep_WarehouseName != target.Rep_WarehouseName) resList.Add("Rep_WarehouseName");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.MakerShortName != target.MakerShortName) resList.Add("MakerShortName");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.Tru_WarehouseShelfNo != target.Tru_WarehouseShelfNo) resList.Add("Tru_WarehouseShelfNo");
            if (this.MaximumStockCnt != target.MaximumStockCnt) resList.Add("MaximumStockCnt");
            if (this.Tru_ShipmentPosCnt != target.Tru_ShipmentPosCnt) resList.Add("Tru_ShipmentPosCnt");
            if (this.ReplenishCount != target.ReplenishCount) resList.Add("ReplenishCount");
            if (this.ReplenishNStockCount != target.ReplenishNStockCount) resList.Add("ReplenishNStockCount");
            if (this.Rep_WarehouseShelfNo != target.Rep_WarehouseShelfNo) resList.Add("Rep_WarehouseShelfNo");
            if (this.Rep_ShipmentPosCnt != target.Rep_ShipmentPosCnt) resList.Add("Rep_ShipmentPosCnt");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.GoodsFlg != target.GoodsFlg) resList.Add("GoodsFlg");

            return resList;
        }

        /// <summary>
        /// 委託在庫補充処理抽出結果クラス比較処理
        /// </summary>
        /// <param name="trustStockResult1">比較するTrustStockResultクラスのインスタンス</param>
        /// <param name="trustStockResult2">比較するTrustStockResultクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TrustStockResultクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(TrustStockResult trustStockResult1, TrustStockResult trustStockResult2)
        {
            ArrayList resList = new ArrayList();
            if (trustStockResult1.EnterpriseCode != trustStockResult2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (trustStockResult1.Tru_WarehouseCode != trustStockResult2.Tru_WarehouseCode) resList.Add("Tru_WarehouseCode");
            if (trustStockResult1.Tru_WarehouseName != trustStockResult2.Tru_WarehouseName) resList.Add("Tru_WarehouseName");
            if (trustStockResult1.Rep_WarehouseCode != trustStockResult2.Rep_WarehouseCode) resList.Add("Rep_WarehouseCode");
            if (trustStockResult1.Rep_WarehouseName != trustStockResult2.Rep_WarehouseName) resList.Add("Rep_WarehouseName");
            if (trustStockResult1.GoodsMakerCd != trustStockResult2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (trustStockResult1.MakerShortName != trustStockResult2.MakerShortName) resList.Add("MakerShortName");
            if (trustStockResult1.GoodsNo != trustStockResult2.GoodsNo) resList.Add("GoodsNo");
            if (trustStockResult1.GoodsName != trustStockResult2.GoodsName) resList.Add("GoodsName");
            if (trustStockResult1.Tru_WarehouseShelfNo != trustStockResult2.Tru_WarehouseShelfNo) resList.Add("Tru_WarehouseShelfNo");
            if (trustStockResult1.MaximumStockCnt != trustStockResult2.MaximumStockCnt) resList.Add("MaximumStockCnt");
            if (trustStockResult1.Tru_ShipmentPosCnt != trustStockResult2.Tru_ShipmentPosCnt) resList.Add("Tru_ShipmentPosCnt");
            if (trustStockResult1.ReplenishCount != trustStockResult2.ReplenishCount) resList.Add("ReplenishCount");
            if (trustStockResult1.ReplenishNStockCount != trustStockResult2.ReplenishNStockCount) resList.Add("ReplenishNStockCount");
            if (trustStockResult1.Rep_WarehouseShelfNo != trustStockResult2.Rep_WarehouseShelfNo) resList.Add("Rep_WarehouseShelfNo");
            if (trustStockResult1.Rep_ShipmentPosCnt != trustStockResult2.Rep_ShipmentPosCnt) resList.Add("Rep_ShipmentPosCnt");
            if (trustStockResult1.EnterpriseName != trustStockResult2.EnterpriseName) resList.Add("EnterpriseName");
            if (trustStockResult1.GoodsFlg != trustStockResult2.GoodsFlg) resList.Add("GoodsFlg");

            return resList;
        }
    }
}
