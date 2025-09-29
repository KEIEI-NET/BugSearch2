using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 画面入力条件保持クラス
    /// </summary>
    public class ExtractInfo
    {
        # region ■ Private Field

        /// <summary>企業コード</summary>
        private string _enterpriseCode;
        /// <summary>ログイン拠点コード</summary>
        private string _sectionCode;
        /// <summary>ログイン拠点ガイド名称</summary>
        private string _sectionGuidNm;

        /// <summary>表示区分</summary>
        private DisplayDivState _displayDiv;
        /// <summary>対象区分</summary>
        private TargetDivState _targetDiv;
        /// <summary>出力指定</summary>
        private OutputDivState _outputDiv;

        /// <summary>商品メーカーコード</summary>
        private int _goodsMakerCd;
        /// <summary>メーカー名称</summary>
        private string _makerName;
        /// <summary>商品中分類</summary>
        private int _goodsMGroup;
        /// <summary>商品中分類名</summary>
        private string _goodsMGroupName;
        /// <summary>倉庫コード</summary>
        private string _warehouseCode;
        /// <summary>倉庫名称</summary>
        private string _warehouseName;
        /// <summary>品番</summary>
        private string _goodsNo;
        /// <summary>品名</summary>
        private string _goodsName;
        /// <summary>ＢＬコード</summary>
        private int _blGoodsCode;
        /// <summary>ＢＬコード名</summary>
        private string _blGoodsName;
        /// <summary>管理拠点コード</summary>
        private string _addUpSectionCode;
        /// <summary>管理拠点ガイド名称</summary>
        private string _addUpSectionGuidNm;
        /// <summary>入力担当者コード</summary>
        private string _stockAgentCode;
        /// <summary>入力担当者名称</summary>
        private string _stockAgentName;

        /// <summary>削除済みデータ表示ボタン状態</summary>
        private bool _deleteIndication;

        // --- ADD yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
        /// <summary>最大出力件数</summary>
        private int  _maxCount;
        // --- ADD yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<

        # endregion ■ Private Field

        # region ■ Public Propaty
        /// <summary>
        /// 企業コードプロパティ
        /// </summary>
        public string EnterpriseCode
        {
            get { return this._enterpriseCode; }
            set { this._enterpriseCode = value; }
        }
        /// <summary>
        /// 拠点コードプロパティ
        /// </summary>
        public string SectionCode
        {
            get { return this._sectionCode; }
            set { this._sectionCode = value; }
        }
        /// <summary>
        /// 拠点ガイド名称プロパティ
        /// </summary>
        public string SectionGuidNm
        {
            get { return this._sectionGuidNm; }
            set { this._sectionGuidNm = value; }
        }

        /// <summary>
        /// 表示区分プロパティ
        /// </summary>
        public DisplayDivState DisplayDiv
        {
            get { return this._displayDiv; }
            set { this._displayDiv = value; }
        }
        /// <summary>
        /// 対象区分プロパティ
        /// </summary>
        public TargetDivState TargetDiv
        {
            get { return this._targetDiv; }
            set { this._targetDiv = value; }
        }
        /// <summary>
        /// 出力指定プロパティ
        /// </summary>
        public OutputDivState OutputDiv
        {
            get { return this._outputDiv; }
            set { this._outputDiv = value; }
        }

        /// <summary>
        /// 商品メーカーコードプロパティ
        /// </summary>
        public int GoodsMakerCd
        {
            get { return this._goodsMakerCd; }
            set { this._goodsMakerCd = value; }
        }
        /// <summary>
        /// メーカー名称プロパティ
        /// </summary>
        public string MakerName
        {
            get { return this._makerName; }
            set { this._makerName = value; }
        }
        /// <summary>
        /// 商品中分類コードプロパティ
        /// </summary>
        public int GoodsMGroup
        {
            get { return this._goodsMGroup; }
            set { this._goodsMGroup = value; }
        }
        /// <summary>
        /// 商品中分類名称プロパティ
        /// </summary>
        public string GoodsMGroupName
        {
            get { return this._goodsMGroupName; }
            set { this._goodsMGroupName = value; }
        }
        /// <summary>
        /// 倉庫コードプロパティ
        /// </summary>
        public string WarehouseCode
        {
            get { return this._warehouseCode; }
            set { this._warehouseCode = value; }
        }
        /// <summary>
        /// 倉庫名称プロパティ
        /// </summary>
        public string WarehouseName
        {
            get { return this._warehouseName; }
            set { this._warehouseName = value; }
        }
        /// <summary>
        /// 品番プロパティ
        /// </summary>
        public string GoodsNo
        {
            get { return this._goodsNo; }
            set { this._goodsNo = value; }
        }
        /// <summary>
        /// 品名プロパティ
        /// </summary>
        public string GoodsName
        {
            get { return this._goodsName; }
            set { this._goodsName = value; }
        }
        /// <summary>
        /// BLコードプロパティ
        /// </summary>
        public int BLGoodsCode
        {
            get { return this._blGoodsCode; }
            set { this._blGoodsCode = value; }
        }
        /// <summary>
        /// BLコード名称プロパティ
        /// </summary>
        public string BLGoodsName
        {
            get { return this._blGoodsName; }
            set { this._blGoodsName = value; }
        }
        /// <summary>
        /// 管理拠点コードプロパティ
        /// </summary>
        public string AddUpSectionCode
        {
            get { return this._addUpSectionCode; }
            set { this._addUpSectionCode = value; }
        }
        /// <summary>
        /// 管理拠点名称プロパティ
        /// </summary>
        public string AddUpSectionGuidNm
        {
            get { return this._addUpSectionGuidNm; }
            set { this._addUpSectionGuidNm = value; }
        }
        /// <summary>
        /// 入力担当者コードプロパティ
        /// </summary>
        public string StockAgentCode
        {
            get { return this._stockAgentCode; }
            set { this._stockAgentCode = value; }
        }
        /// <summary>
        /// 入力担当者名称プロパティ
        /// </summary>
        public string StockAgentName
        {
            get { return this._stockAgentName; }
            set { this._stockAgentName = value; }
        }

        /// <summary>
        /// 削除済みデータ表示ボタン状態
        /// </summary>
        public bool DeleteIndication
        {
            get { return this._deleteIndication; }
            set { this._deleteIndication = value; }
        }

        // --- ADD yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
        /// <summary>
        /// 最大出力件数
        /// </summary>
        public int MaxCount
        {
            get { return this._maxCount; }
            set { this._maxCount = value; }
        }
        // --- ADD yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<
        
        # endregion ■ Public Propaty

        #region ■コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ExtractInfo()
        {
        }
        #endregion

        #region ■列挙体

        /// <summary>
        /// 表示区分　列挙体
        /// </summary>
        public enum DisplayDivState
        {
            /// <summary>新規登録</summary>
            New = 0,
            /// <summary>修正登録</summary>
            Update = 1,
        }

        /// <summary>
        /// 対象区分 列挙体
        /// </summary>
        public enum TargetDivState
        {
            /// <summary>商品</summary>
            Goods = 0,
            /// <summary>商品-在庫</summary>
            GoodsStock = 1,
            /// <summary>在庫-商品</summary>
            StockGoods = 2,
            /// <summary>在庫</summary>
            Stock = 3,
        }

        /// <summary>
        /// 出力指定　列挙体
        /// </summary>
        public enum OutputDivState
        {
            /// <summary>全て</summary>
            All = 0,
            /// <summary>ユーザ価格設定分</summary>
            UserPrice = 1,
            /// <summary>原価設定分</summary>
            CostPrice = 2,
        }
        #endregion
    }
}
