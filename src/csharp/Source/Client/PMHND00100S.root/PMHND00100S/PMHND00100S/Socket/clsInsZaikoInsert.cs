//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ハンディターミナル
// プログラム概要   : ハンディターミナル　メインプログラム(ソケット通信)
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570249-00 作成担当 : 白厩　翔也
// 修 正 日  2020/04/01  修正内容 : ハンディ仕入れ時在庫登録対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using PMHND00100S.Common;

namespace PMHND00100S.Socket
{
    /// public class name:   clsInsZaikoInsert
    /// <summary>
    ///                      ソケット通信用クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品在庫登録確定用クラス</br>
    /// <br>Programmer       :   白厩　翔也</br>
    /// <br>Date             :   2020/04/01</br>
    /// <br></br>
    /// <br></br>
    /// <br>Update Note      :   </br>
    /// <br></br>
    /// </remarks>
    class clsInsZaikoInsert
    {

#region "プロパティ"
        private string _soksyorikbn = null;
        //ソケット通信処理区分
        public string SokSyoriKbn
        {
            get
            { return _soksyorikbn; }
            set
            { _soksyorikbn = value; }
        }

        private string _htname = null;
        //コンピュータ名
        public string HtName
        {
            get
            { return _htname; }
            set
            { _htname = value; }
        }

        private string _empcd = null;
        //従業員コード
        public string EmpCd
        {
            get
            { return _empcd; }
            set
            { _empcd = value; }
        }

        private string _goodsmakercd = null;
        //メーカーコード
        public string GoodsMakerCd
        {
            get
            { return _goodsmakercd; }
            set
            { _goodsmakercd = value; }
        }

        private string _goodsno = null;
        //商品番号
        public string GoodsNo
        {
            get
            { return _goodsno; }
            set
            { _goodsno = value; }
        }

        private string _warehousecode = null;
        //倉庫コード
        public string WarehouseCode
        {
            get
            { return _warehousecode; }
            set
            { _warehousecode = value; }
        }

        private string _warehouseshelfno = null;
        //倉庫棚番
        public string WarehouseShelfNo
        {
            get
            { return _warehouseshelfno; }
            set
            { _warehouseshelfno = value; }
        }

        private string _suppliercd = null;
        //仕入先コード
        public string SupplierCd
        {
            get
            { return _suppliercd; }
            set
            { _suppliercd = value; }
        }

        private string _stockcount = null;
        //入庫数
        public string StockCount
        {
            get
            { return _stockcount; }
            set
            { _stockcount = value; }
        }

        private string _goodskindcoderf = null;
        //商品属性
        public string GoodsKindCodeRF
        {
            get
            { return _goodskindcoderf; }
            set
            { _goodskindcoderf = value; }
        }

        private string _taxationdivcdrf = null;
        //課税区分
        public string TaxationDivCdRF
        {
            get
            { return _taxationdivcdrf; }
            set
            { _taxationdivcdrf = value; }
        }

        private string _stockdivrf = null;
        //在庫区分
        public string StockDivRF
        {
            get
            { return _stockdivrf; }
            set
            { _stockdivrf = value; }
        }

        private string _makergoodssearchhisno = null;
        //パターン検索履歴通番
        public string MakerGoodsSearchHisNo
        {
            get
            { return _makergoodssearchhisno; }
            set
            { _makergoodssearchhisno = value; }
        }

        private string _retval = null;
        //処理結果(ステータス)
        public string RetVal
        {
            get
            { return _retval; }
            set
            { _retval = value; }
        }

        private Int32 _soksyorikbnlen = 0;
        //ソケット通信処理区分
        public Int32 SokSyoriKbnLen
        {
            get
            { return _soksyorikbnlen; }
            set
            { _soksyorikbnlen = value; }
        }

        private Int32 _htnamelen = 0;
        //コンピュータ名
        public Int32 HtNameLen
        {
            get
            { return _htnamelen; }
            set
            { _htnamelen = value; }
        }

        private Int32 _empcdlen = 0;
        //従業員コード
        public Int32 EmpCdLen
        {
            get
            { return _empcdlen; }
            set
            { _empcdlen = value; }
        }

        private Int32 _goodsmakercdlen = 0;
        //メーカーコード
        public Int32 GoodsMakerCdLen
        {
            get
            { return _goodsmakercdlen; }
            set
            { _goodsmakercdlen = value; }
        }

        private Int32 _goodsnolen = 0;
        //商品番号
        public Int32 GoodsNoLen
        {
            get
            { return _goodsnolen; }
            set
            { _goodsnolen = value; }
        }

        private Int32 _warehousecodelen = 0;
        //倉庫コード
        public Int32 WarehouseCodeLen
        {
            get
            { return _warehousecodelen; }
            set
            { _warehousecodelen = value; }
        }

        private Int32 _warehouseshelfnolen = 0;
        //倉庫棚番
        public Int32 WarehouseShelfNoLen
        {
            get
            { return _warehouseshelfnolen; }
            set
            { _warehouseshelfnolen = value; }
        }

        private Int32 _suppliercdlen = 0;
        //仕入先コード
        public Int32 SupplierCdLen
        {
            get
            { return _suppliercdlen; }
            set
            { _suppliercdlen = value; }
        }

        private Int32 _stockcountlen = 0;
        //入荷数
        public Int32 StockCountLen
        {
            get
            { return _stockcountlen; }
            set
            { _stockcountlen = value; }
        }

        private Int32 _goodskindcoderflen = 0;
        //商品属性
        public Int32 GoodsKindCodeRFLen
        {
            get
            { return _goodskindcoderflen; }
            set
            { _goodskindcoderflen = value; }
        }

        private Int32 _taxationdivcdrflen = 0;
        //課税区分
        public Int32 TaxationDivCdRFLen
        {
            get
            { return _taxationdivcdrflen; }
            set
            { _taxationdivcdrflen = value; }
        }

        private Int32 _stockdivrflen = 0;
        //在庫区分
        public Int32 StockDivRFLen
        {
            get
            { return _stockdivrflen; }
            set
            { _stockdivrflen = value; }
        }

        private Int32 _makergoodssearchhisnolen = 0;
        //パターン検索履歴通番
        public Int32 MakerGoodsSearchHisNoLen
        {
            get
            { return _makergoodssearchhisnolen; }
            set
            { _makergoodssearchhisnolen = value; }
        }

        private Int32 _retvallen = 0;
        //処理結果(ステータス)
        public Int32 RetValLen
        {
            get
            { return _retvallen; }
            set
            { _retvallen = value; }
        }

        private Int32 _denbunlen = 0;
        /// <summary>電文長</summary>
        public Int32 DenbunLen
        {
            get
            { return _denbunlen; }
            set
            { _denbunlen = value; }
        }
#endregion

#region "コンストラクタ"
        Encoding Encd = System.Text.Encoding.GetEncoding("Shift_JIS");

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks></remarks>
        public clsInsZaikoInsert()
        {
            //ソケット通信処理区分
            SokSyoriKbn = string.Empty;
            SokSyoriKbnLen = 4;

            //コンピュータ名
            HtName = string.Empty;
            HtNameLen = 20;
            //従業員コード
            EmpCd = string.Empty;
            EmpCdLen = 9;
            //メーカーコード
            GoodsMakerCd = string.Empty;
            GoodsMakerCdLen = 6;
            //商品番号
            GoodsNo = string.Empty;
            GoodsNoLen = 40;
            //倉庫コード
            WarehouseCode = string.Empty;
            WarehouseCodeLen = 6;
            //倉庫棚番
            WarehouseShelfNo = string.Empty;
            WarehouseShelfNoLen = 8;
            //仕入先コード
            SupplierCd = string.Empty;
            SupplierCdLen = 9;
            //入庫数
            StockCount = string.Empty;
            StockCountLen = 6;
            //商品属性
            GoodsKindCodeRF = string.Empty;
            GoodsKindCodeRFLen = 3;
            //課税区分
            TaxationDivCdRF = string.Empty;
            TaxationDivCdRFLen = 3;
            //在庫区分
            StockDivRF = string.Empty;
            StockDivRFLen = 3;
            //パターン検索履歴通番
            MakerGoodsSearchHisNo = string.Empty;
            MakerGoodsSearchHisNoLen = 8;
            //処理結果(ステータス)
            RetVal = string.Empty;
            RetValLen = 2;

            //電文長
            DenbunLen = SokSyoriKbnLen + HtNameLen + EmpCdLen + GoodsMakerCdLen + GoodsNoLen +
                        WarehouseCodeLen + WarehouseShelfNoLen + SupplierCdLen + StockCountLen +
                        GoodsKindCodeRFLen + TaxationDivCdRFLen + StockDivRFLen + MakerGoodsSearchHisNoLen + RetValLen;
        }
#endregion

#region "メソッド"

        /// <summary>
        /// 受信データ初期化
        /// </summary>
        /// <remarks></remarks>
        public void IniOutArg()
        {
            //処理結果(ステータス)
            RetVal = string.Empty;
        }

        /// <summary>
        /// ハンディからの受信データ取得（HT間通信プログラム用）
        /// </summary>
        /// <param name="ArgVal"></param>
        /// <remarks></remarks>
        public Int32 RelayGetHtInArg(byte[] ArgVal)
        {
            Int32 StPost = 0;
            Int32 StSize = 0;

            StPost = 0;

            //ソケット通信処理区分
            StSize = SokSyoriKbnLen;
            SokSyoriKbn = Encd.GetString(ArgVal, StPost, StSize);
            StPost += SokSyoriKbnLen;

            //コンピューター名
            StSize = HtNameLen;
            HtName = Encd.GetString(ArgVal, StPost, StSize);
            StPost += HtNameLen;

            //従業員コード
            StSize = EmpCdLen;
            EmpCd = Encd.GetString(ArgVal, StPost, StSize);
            StPost += EmpCdLen;

            //メーカーコード
            StSize = GoodsMakerCdLen;
            GoodsMakerCd = Encd.GetString(ArgVal, StPost, StSize);
            StPost += GoodsMakerCdLen;

            //商品番号
            StSize = GoodsNoLen;
            GoodsNo = Encd.GetString(ArgVal, StPost, StSize);
            StPost += GoodsNoLen;

            //倉庫コード
            StSize = WarehouseCodeLen;
            WarehouseCode = Encd.GetString(ArgVal, StPost, StSize);
            StPost += WarehouseCodeLen;

            //倉庫棚番
            StSize = WarehouseShelfNoLen;
            WarehouseShelfNo = Encd.GetString(ArgVal, StPost, StSize);
            StPost += WarehouseShelfNoLen;

            //仕入先コード
            StSize = SupplierCdLen;
            SupplierCd = Encd.GetString(ArgVal, StPost, StSize);
            StPost += SupplierCdLen;

            //入庫数
            StSize = StockCountLen;
            StockCount = Encd.GetString(ArgVal, StPost, StSize);
            StPost += StockCountLen;

            //商品属性
            StSize = GoodsKindCodeRFLen;
            GoodsKindCodeRF = Encd.GetString(ArgVal, StPost, StSize);
            StPost += GoodsKindCodeRFLen;

            //課税区分
            StSize = TaxationDivCdRFLen;
            TaxationDivCdRF = Encd.GetString(ArgVal, StPost, StSize);
            StPost += TaxationDivCdRFLen;

            //在庫区分
            StSize = StockDivRFLen;
            StockDivRF = Encd.GetString(ArgVal, StPost, StSize);
            StPost += StockDivRFLen;

            //パターン検索履歴通番
            StSize = MakerGoodsSearchHisNoLen;
            MakerGoodsSearchHisNo = Encd.GetString(ArgVal, StPost, StSize);
            StPost += MakerGoodsSearchHisNoLen;
            return 0;
        }

        /// <summary>
        /// 受信データ取得（HT間通信プログラム用）
        /// </summary>
        public byte[] RelayGetOutArg()
        {
            byte[] rcvval = new byte[] { };
            byte[] buf = null;
            Int32 stpost = 0;

            //処理結果
            string damRetVal = RetVal.ToString().PadLeft(2, '0');
            buf = Encd.GetBytes(damRetVal);
            stpost = 0;
            Array.Resize(ref rcvval, RetValLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RetValLen);
            RetVal = damRetVal;

            buf = Encd.GetBytes(clsBtConst.HT_MSG_CRLF);
            stpost += RetValLen;
            Array.Resize(ref rcvval, rcvval.Length + clsBtConst.HT_MSG_CRLF_LEN);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, clsBtConst.HT_MSG_CRLF_LEN);

            return rcvval;
        }

#endregion

#region "関数"

#endregion

    }
}
