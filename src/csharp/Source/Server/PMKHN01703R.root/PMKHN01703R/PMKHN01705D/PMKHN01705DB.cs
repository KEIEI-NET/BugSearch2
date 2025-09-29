//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 明治産業品番変換一括処理結果
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 陳永康
// 作 成 日  2015/01/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : 陳永康
// 作 成 日  2015/02/27   修正内容 : Redmine#44209 優良設定マスタ変換処理の機能追加
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   GoodsChangeResultWork
    /// <summary>
    ///                      変換処理結果ワークワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   変換処理結果ワークワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/28</br>
    /// <br>Genarated Date   :   2015/01/26  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class GoodsChangeResultWork
    {
        /// <summary>ログファイル使用フラグ</summary>
        private Int32 _logCSVOpen;

        /// <summary>エラーファイル使用フラグ</summary>
        private Int32 _errLogCSVOpen;

        /// <summary>読込件数(品番変換マスタ)</summary>
        private Int32 _readCntGoodsChgMst;

        /// <summary>更新件数(品番変換マスタ)</summary>
        private Int32 _loadCntGoodsChgMst;

        /// <summary>エラー件数(品番変換マスタ)</summary>
        private Int32 _errCntGoodsChgMst;

        /// <summary>ファイルステータス(品番変換マスタ)</summary>
        private Int32 _mstStatusErrCSV;

        /// <summary>エラーメッセージ(品番変換マスタ)</summary>
        private string _errMsg = "";

        /// <summary>読込件数(商品在庫マスタ)</summary>
        private Int32 _readCntGoodsAll;

        /// <summary>更新件数(商品在庫マスタ)</summary>
        private Int32 _loadCntGoodsAll;

        /// <summary>エラー件数(商品在庫マスタ)</summary>
        private Int32 _errCntGoodsAll;

        /// <summary>エラー件数(商品マスタ)</summary>
        private Int32 _errorCntGoods;

        /// <summary>エラー件数(価格マスタ)</summary>
        private Int32 _errorCntPrice;

        /// <summary>エラー件数(在庫マスタ)</summary>
        private Int32 _errorCntStock;

        /// <summary>ファイルステータス(商品マスタ)</summary>
        private Int32 _goodsStatusErrCSV;

        /// <summary>ファイルステータス(価格マスタ)</summary>
        private Int32 _priceStatusErrCSV;

        /// <summary>ファイルステータス(在庫マスタ)</summary>
        private Int32 _stockStatusErrCSV;

        /// <summary>読込件数(商品管理情報マスタ)</summary>
        private Int32 _readCntMng;

        /// <summary>更新件数(商品管理情報マスタ)</summary>
        private Int32 _loadCntMng;

        /// <summary>エラー件数(商品管理情報マスタ)</summary>
        private Int32 _errorCntMng;

        /// <summary>ファイルステータス(商品管理情報マスタ)</summary>
        private Int32 _mngStatusErrCSV;

        /// <summary>読込件数(掛率マスタ)</summary>
        private Int32 _readCntRate;

        /// <summary>更新件数(掛率マスタ)</summary>
        private Int32 _loadCntRate;

        /// <summary>エラー件数(掛率マスタ)</summary>
        private Int32 _errorCntRate;

        /// <summary>ファイルステータス(掛率マスタ)</summary>
        private Int32 _rateStatusErrCSV;

        /// <summary>読込件数(結合マスタ)</summary>
        private Int32 _readCntJoin;

        /// <summary>更新件数(結合マスタ)</summary>
        private Int32 _loadCntJoin;

        /// <summary>エラー件数(結合マスタ)</summary>
        private Int32 _errorCntJoin;

        /// <summary>ファイルステータス(結合マスタ)</summary>
        private Int32 _joinStatusErrCSV;

        /// <summary>読込件数(代替マスタ)</summary>
        private Int32 _readCntParts;

        /// <summary>更新件数(代替マスタ)</summary>
        private Int32 _loadCntParts;

        /// <summary>エラー件数(代替マスタ)</summary>
        private Int32 _errCntParts;

        /// <summary>ファイルステータス(代替マスタ)</summary>
        private Int32 _partsStatusErrCSV;

        /// <summary>読込件数(セットマスタ)</summary>
        private Int32 _readCntSet;

        /// <summary>更新件数(セットマスタ)</summary>
        private Int32 _loadCntSet;

        /// <summary>エラー件数(セットマスタ)</summary>
        private Int32 _errCntSet;

        /// <summary>ファイルステータス(セットマスタ)</summary>
        private Int32 _setStatusErrCSV;

        //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加----->>>>>
        /// <summary>読込件数(優良設定マスタ)</summary>
        private Int32 _readCntPrm;

        /// <summary>更新件数(優良設定マスタ)</summary>
        private Int32 _loadCntPrm;

        /// <summary>エラー件数(優良設定マスタ)</summary>
        private Int32 _errCntPrm;

        /// <summary>ファイルステータス(優良設定マスタ)</summary>
        private Int32 _prmStatusErrCSV;
        //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加-----<<<<<

        /// <summary>読込件数(貸出変換処理)</summary>
        private Int32 _readCntShipment;

        /// <summary>更新件数(貸出変換処理)</summary>
        private Int32 _loadCntShipment;

        /// <summary>エラー件数(貸出変換処理)</summary>
        private Int32 _errCntShipment;

        /// <summary>ファイルステータス(貸出変換処理)</summary>
        private Int32 _shipmentStatusErrCSV;


        /// public propaty name  :  LogCSVOpen
        /// <summary>ログファイル使用フラグプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログファイル使用フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogCSVOpen
        {
            get { return _logCSVOpen; }
            set { _logCSVOpen = value; }
        }

        /// public propaty name  :  ErrLogCSVOpen
        /// <summary>エラーファイル使用フラグプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラーファイル使用フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ErrLogCSVOpen
        {
            get { return _errLogCSVOpen; }
            set { _errLogCSVOpen = value; }
        }

        /// public propaty name  :  ReadCntGoodsChgMst
        /// <summary>読込件数(品番変換マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   読込件数(品番変換マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ReadCntGoodsChgMst
        {
            get { return _readCntGoodsChgMst; }
            set { _readCntGoodsChgMst = value; }
        }

        /// public propaty name  :  LoadCntGoodsChgMst
        /// <summary>更新件数(品番変換マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新件数(品番変換マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LoadCntGoodsChgMst
        {
            get { return _loadCntGoodsChgMst; }
            set { _loadCntGoodsChgMst = value; }
        }

        /// public propaty name  :  ErrCntGoodsChgMst
        /// <summary>エラー件数(品番変換マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラー件数(品番変換マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ErrCntGoodsChgMst
        {
            get { return _errCntGoodsChgMst; }
            set { _errCntGoodsChgMst = value; }
        }

        /// public propaty name  :  MstStatusErrCSV
        /// <summary>ファイルステータス(品番変換マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ファイルステータス(品番変換マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MstStatusErrCSV
        {
            get { return _mstStatusErrCSV; }
            set { _mstStatusErrCSV = value; }
        }

        /// public propaty name  :  ErrMsg
        /// <summary>エラーメッセージ(品番変換マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラーメッセージ(品番変換マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ErrMsg
        {
            get { return _errMsg; }
            set { _errMsg = value; }
        }

        /// public propaty name  :  ReadCntGoodsAll
        /// <summary>読込件数(商品在庫マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   読込件数(商品在庫マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ReadCntGoodsAll
        {
            get { return _readCntGoodsAll; }
            set { _readCntGoodsAll = value; }
        }

        /// public propaty name  :  LoadCntGoodsAll
        /// <summary>更新件数(商品在庫マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新件数(商品在庫マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LoadCntGoodsAll
        {
            get { return _loadCntGoodsAll; }
            set { _loadCntGoodsAll = value; }
        }

        /// public propaty name  :  ErrCntGoodsAll
        /// <summary>エラー件数(商品在庫マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラー件数(商品在庫マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ErrCntGoodsAll
        {
            get { return _errCntGoodsAll; }
            set { _errCntGoodsAll = value; }
        }

        /// public propaty name  :  ErrorCntGoods
        /// <summary>エラー件数(商品マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラー件数(商品マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ErrorCntGoods
        {
            get { return _errorCntGoods; }
            set { _errorCntGoods = value; }
        }

        /// public propaty name  :  ErrorCntPrice
        /// <summary>エラー件数(価格マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラー件数(価格マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ErrorCntPrice
        {
            get { return _errorCntPrice; }
            set { _errorCntPrice = value; }
        }

        /// public propaty name  :  ErrorCntStockout
        /// <summary>エラー件数(在庫マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラー件数(在庫マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ErrorCntStock
        {
            get { return _errorCntStock; }
            set { _errorCntStock = value; }
        }

        /// public propaty name  :  GoodsStatusErrCSV
        /// <summary>ファイルステータス(商品マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ファイルステータス(商品マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsStatusErrCSV
        {
            get { return _goodsStatusErrCSV; }
            set { _goodsStatusErrCSV = value; }
        }

        /// public propaty name  :  PriceStatusErrCSV
        /// <summary>ファイルステータス(価格マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ファイルステータス(価格マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceStatusErrCSV
        {
            get { return _priceStatusErrCSV; }
            set { _priceStatusErrCSV = value; }
        }

        /// public propaty name  :  StockStatusErrCSV
        /// <summary>ファイルステータス(在庫マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ファイルステータス(在庫マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockStatusErrCSV
        {
            get { return _stockStatusErrCSV; }
            set { _stockStatusErrCSV = value; }
        }

        /// public propaty name  :  ReadCntMng
        /// <summary>読込件数(商品管理情報マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   読込件数(商品管理情報マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ReadCntMng
        {
            get { return _readCntMng; }
            set { _readCntMng = value; }
        }

        /// public propaty name  :  LoadCntMng
        /// <summary>更新件数(商品管理情報マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新件数(商品管理情報マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LoadCntMng
        {
            get { return _loadCntMng; }
            set { _loadCntMng = value; }
        }

        /// public propaty name  :  ErrorCntMng
        /// <summary>エラー件数(商品管理情報マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラー件数(商品管理情報マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ErrorCntMng
        {
            get { return _errorCntMng; }
            set { _errorCntMng = value; }
        }

        /// public propaty name  :  MngStatusErrCSV
        /// <summary>ファイルステータス(商品管理情報マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ファイルステータス(商品管理情報マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MngStatusErrCSV
        {
            get { return _mngStatusErrCSV; }
            set { _mngStatusErrCSV = value; }
        }

        /// public propaty name  :  ReadCntRate
        /// <summary>読込件数(掛率マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   読込件数(掛率マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ReadCntRate
        {
            get { return _readCntRate; }
            set { _readCntRate = value; }
        }

        /// public propaty name  :  LoadCntRate
        /// <summary>更新件数(掛率マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新件数(掛率マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LoadCntRate
        {
            get { return _loadCntRate; }
            set { _loadCntRate = value; }
        }

        /// public propaty name  :  ErrorCntRate
        /// <summary>エラー件数(掛率マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラー件数(掛率マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ErrorCntRate
        {
            get { return _errorCntRate; }
            set { _errorCntRate = value; }
        }

        /// public propaty name  :  RateStatusErrCSV
        /// <summary>ファイルステータス(掛率マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ファイルステータス(掛率マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RateStatusErrCSV
        {
            get { return _rateStatusErrCSV; }
            set { _rateStatusErrCSV = value; }
        }

        /// public propaty name  :  ReadCntJoin
        /// <summary>読込件数(結合マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   読込件数(結合マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ReadCntJoin
        {
            get { return _readCntJoin; }
            set { _readCntJoin = value; }
        }

        /// public propaty name  :  LoadCntJoin
        /// <summary>更新件数(結合マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新件数(結合マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LoadCntJoin
        {
            get { return _loadCntJoin; }
            set { _loadCntJoin = value; }
        }

        /// public propaty name  :  ErrorCntJoin
        /// <summary>エラー件数(結合マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラー件数(結合マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ErrorCntJoin
        {
            get { return _errorCntJoin; }
            set { _errorCntJoin = value; }
        }

        /// public propaty name  :  JoinStatusErrCSV
        /// <summary>ファイルステータス(結合マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ファイルステータス(結合マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinStatusErrCSV
        {
            get { return _joinStatusErrCSV; }
            set { _joinStatusErrCSV = value; }
        }

        /// public propaty name  :  ReadCntParts
        /// <summary>読込件数(代替マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   読込件数(代替マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ReadCntParts
        {
            get { return _readCntParts; }
            set { _readCntParts = value; }
        }

        /// public propaty name  :  LoadCntParts
        /// <summary>更新件数(代替マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新件数(代替マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LoadCntParts
        {
            get { return _loadCntParts; }
            set { _loadCntParts = value; }
        }

        /// public propaty name  :  ErrCntParts
        /// <summary>エラー件数(代替マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラー件数(代替マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ErrCntParts
        {
            get { return _errCntParts; }
            set { _errCntParts = value; }
        }

        /// public propaty name  :  PartsStatusErrCSV
        /// <summary>ファイルステータス(代替マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ファイルステータス(代替マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsStatusErrCSV
        {
            get { return _partsStatusErrCSV; }
            set { _partsStatusErrCSV = value; }
        }

        /// public propaty name  :  ReadCntSet
        /// <summary>読込件数(セットマスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   読込件数(セットマスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ReadCntSet
        {
            get { return _readCntSet; }
            set { _readCntSet = value; }
        }

        /// public propaty name  :  LoadCntSet
        /// <summary>更新件数(セットマスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新件数(セットマスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LoadCntSet
        {
            get { return _loadCntSet; }
            set { _loadCntSet = value; }
        }

        /// public propaty name  :  ErrCntSet
        /// <summary>エラー件数(セットマスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラー件数(セットマスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ErrCntSet
        {
            get { return _errCntSet; }
            set { _errCntSet = value; }
        }

        /// public propaty name  :  SetStatusErrCSV
        /// <summary>ファイルステータス(セットマスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ファイルステータス(セットマスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SetStatusErrCSV
        {
            get { return _setStatusErrCSV; }
            set { _setStatusErrCSV = value; }
        }

        //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加----->>>>>
        /// public propaty name  :  ReadCntPrm
        /// <summary>読込件数(優良設定マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   読込件数(優良設定マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ReadCntPrm
        {
            get { return _readCntPrm; }
            set { _readCntPrm = value; }
        }

        /// public propaty name  :  LoadCntPrm
        /// <summary>更新件数(優良設定マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新件数(優良設定マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LoadCntPrm
        {
            get { return _loadCntPrm; }
            set { _loadCntPrm = value; }
        }

        /// public propaty name  :  ErrCntPrm
        /// <summary>エラー件数(優良設定マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラー件数(優良設定マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ErrCntPrm
        {
            get { return _errCntPrm; }
            set { _errCntPrm = value; }
        }

        /// public propaty name  :  PrmStatusErrCSV
        /// <summary>ファイルステータス(優良設定マスタ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ファイルステータス(優良設定マスタ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrmStatusErrCSV
        {
            get { return _prmStatusErrCSV; }
            set { _prmStatusErrCSV = value; }
        }
        //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加-----<<<<<

        /// public propaty name  :  ReadCntShipment
        /// <summary>読込件数(貸出変換処理)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   読込件数(貸出変換処理)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ReadCntShipment
        {
            get { return _readCntShipment; }
            set { _readCntShipment = value; }
        }

        /// public propaty name  :  LoadCntShipment
        /// <summary>更新件数(貸出変換処理)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新件数(貸出変換処理)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LoadCntShipment
        {
            get { return _loadCntShipment; }
            set { _loadCntShipment = value; }
        }

        /// public propaty name  :  ErrCntShipment
        /// <summary>エラー件数(貸出変換処理)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラー件数(貸出変換処理)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ErrCntShipment
        {
            get { return _errCntShipment; }
            set { _errCntShipment = value; }
        }

        /// public propaty name  :  ShipmentStatusErrCSV
        /// <summary>ファイルステータス(貸出変換処理)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ファイルステータス(貸出変換処理)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ShipmentStatusErrCSV
        {
            get { return _shipmentStatusErrCSV; }
            set { _shipmentStatusErrCSV = value; }
        }



        /// <summary>
        /// 変換処理結果ワークワークコンストラクタ
        /// </summary>
        /// <returns>GoodsChangeResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsChangeResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsChangeResultWork()
        {
        }

    }
}
