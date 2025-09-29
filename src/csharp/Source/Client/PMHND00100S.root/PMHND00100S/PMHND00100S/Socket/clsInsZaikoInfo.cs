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
    /// public class name:   clsInsZaikoInfo
    /// <summary>
    ///                      ソケット通信用クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   メーカーリスト取得用クラス</br>
    /// <br>Programmer       :   白厩　翔也</br>
    /// <br>Date             :   2020/04/01</br>
    /// <br></br>
    /// <br></br>
    /// <br>Update Note      :   </br>
    /// <br></br>
    /// </remarks>
    class clsInsZaikoInfo
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

        private string _barcodeinfo = null;
        //バーコード情報
        public string BarCodeInfo
        {
            get
            { return _barcodeinfo; }
            set
            { _barcodeinfo = value; }
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



        private string _rtmakergoodssearchhisno = null;
        //パターン検索履歴通番
        public string RtMakerGoodsSearchHisNo
        {
            get
            { return _rtmakergoodssearchhisno; }
            set
            { _rtmakergoodssearchhisno = value; }
        }

        private string _setgoodscount = null;
        //セットした商品数
        public string SetGoodsCount
        {
            get
            { return _setgoodscount; }
            set
            { _setgoodscount = value; }
        }

        private string _rtsuppliercd = null;
        //仕入先コード
        public string RtSupplierCd
        {
            get
            { return _rtsuppliercd; }
            set
            { _rtsuppliercd = value; }
        }

        private string _rtsuppliersnm = null;
        //仕入先名称
        public string RtSupplierSnm
        {
            get
            { return _rtsuppliersnm; }
            set
            { _rtsuppliersnm = value; }
        }

        private string _rtgoodsmakercd = null;
        //メーカーコード
        public string RtGoodsMakerCd
        {
            get
            { return _rtgoodsmakercd; }
            set
            { _rtgoodsmakercd = value; }
        }

        private string _rtmakershortname = null;
        //メーカーコード略称
        public string RtMakerShortName
        {
            get
            { return _rtmakershortname; }
            set
            { _rtmakershortname = value; }
        }

        private string _rtgoodsno = null;
        //商品番号
        public string RtGoodsNo
        {
            get
            { return _rtgoodsno; }
            set
            { _rtgoodsno = value; }
        }

        private string _rtgoodsname = null;
        //商品名称
        public string RtGoodsName
        {
            get
            { return _rtgoodsname; }
            set
            { _rtgoodsname = value; }
        }

        private string _setstockcount = null;
        //セットした在庫数
        public string SetStockCount
        {
            get
            { return _setstockcount; }
            set
            { _setstockcount = value; }
        }

        private string _rtwarehousecode = null;
        //倉庫コード
        public string RtWarehouseCode
        {
            get
            { return _rtwarehousecode; }
            set
            { _rtwarehousecode = value; }
        }

        private string _rtwarehouseshelfno = null;
        //倉庫棚番
        public string RtWarehouseShelfNo
        {
            get
            { return _rtwarehouseshelfno; }
            set
            { _rtwarehouseshelfno = value; }
        }

        private string _rtshipmentposcnt = null;
        //出荷可能数
        public string RtShipmentPosCnt
        {
            get
            { return _rtshipmentposcnt; }
            set
            { _rtshipmentposcnt = value; }
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

        private Int32 _barcodeinfolen = 0;
        //バーコード情報
        public Int32 BarCodeInfoLen
        {
            get
            { return _barcodeinfolen; }
            set
            { _barcodeinfolen = value; }
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

        private Int32 _rtmakergoodssearchhisnolen = 0;
        //パターン検索履歴通番
        public Int32 RtMakerGoodsSearchHisNoLen
        {
            get
            { return _rtmakergoodssearchhisnolen; }
            set
            { _rtmakergoodssearchhisnolen = value; }
        }

        private Int32 _setgoodscountlen = 0;
        //セットした商品数
        public Int32 SetGoodsCountLen
        {
            get
            { return _setgoodscountlen; }
            set
            { _setgoodscountlen = value; }
        }

        private Int32 _rtsuppliercdlen = 0;
        //仕入先コード
        public Int32 RtSupplierCdLen
        {
            get
            { return _rtsuppliercdlen; }
            set
            { _rtsuppliercdlen = value; }
        }

        private Int32 _rtsuppliersnmlen = 0;
        //仕入先名称
        public Int32 RtSupplierSnmLen
        {
            get
            { return _rtsuppliersnmlen; }
            set
            { _rtsuppliersnmlen = value; }
        }

        private Int32 _rtgoodsmakercdlen = 0;
        //メーカーコード
        public Int32 RtGoodsMakerCdLen
        {
            get
            { return _rtgoodsmakercdlen; }
            set
            { _rtgoodsmakercdlen = value; }
        }

        private Int32 _rtmakershortnamelen = 0;
        //メーカーコード略称
        public Int32 RtMakerShortNameLen
        {
            get
            { return _rtmakershortnamelen; }
            set
            { _rtmakershortnamelen = value; }
        }

        private Int32 _rtgoodsnolen = 0;
        //商品番号
        public Int32 RtGoodsNoLen
        {
            get
            { return _rtgoodsnolen; }
            set
            { _rtgoodsnolen = value; }
        }

        private Int32 _rtgoodsnamelen = 0;
        //商品名称
        public Int32 RtGoodsNameLen
        {
            get
            { return _rtgoodsnamelen; }
            set
            { _rtgoodsnamelen = value; }
        }

        private Int32 _setstockcountlen = 0;
        //セットした在庫数
        public Int32 SetStockCountLen
        {
            get
            { return _setstockcountlen; }
            set
            { _setstockcountlen = value; }
        }

        private Int32 _rtwarehousecodelen = 0;
        //倉庫コード
        public Int32 RtWarehouseCodeLen
        {
            get
            { return _rtwarehousecodelen; }
            set
            { _rtwarehousecodelen = value; }
        }

        private Int32 _rtwarehouseshelfnolen = 0;
        //倉庫棚番
        public Int32 RtWarehouseShelfNoLen
        {
            get
            { return _rtwarehouseshelfnolen; }
            set
            { _rtwarehouseshelfnolen = value; }
        }

        private Int32 _rtshipmentposcntlen = 0;
        //出荷可能数
        public Int32 RtShipmentPosCntLen
        {
            get
            { return _rtshipmentposcntlen; }
            set
            { _rtshipmentposcntlen = value; }
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
        public clsInsZaikoInfo()
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
            //バーコード情報
            BarCodeInfo = string.Empty;
            BarCodeInfoLen = 255;
            //商品番号
            GoodsNo = string.Empty;
            GoodsNoLen = 40;

            //パターン検索履歴通番
            RtMakerGoodsSearchHisNo = string.Empty;
            RtMakerGoodsSearchHisNoLen = 8;
            //セットした商品数
            SetGoodsCount = string.Empty;
            SetGoodsCountLen = 3;
            //仕入先コード
            RtSupplierCd = string.Empty;
            RtSupplierCdLen = 9;
            //仕入先名称
            RtSupplierSnm = string.Empty;
            RtSupplierSnmLen = 20;
            //メーカーコード
            RtGoodsMakerCd = string.Empty;
            RtGoodsMakerCdLen = 6;
            //メーカーコード略称
            RtMakerShortName = string.Empty;
            RtMakerShortNameLen = 10;
            //商品番号
            RtGoodsNo = string.Empty;
            RtGoodsNoLen = 40;
            //商品名称
            RtGoodsName = string.Empty;
            RtGoodsNameLen = 100;
            //セットした在庫数
            SetStockCount = string.Empty;
            SetStockCountLen = 3;
            //倉庫コード
            RtWarehouseCode = string.Empty;
            RtWarehouseCodeLen = 6;
            //倉庫棚番
            RtWarehouseShelfNo = string.Empty;
            RtWarehouseShelfNoLen = 8;
            //出荷可能数
            RtShipmentPosCnt = string.Empty;
            RtShipmentPosCntLen = 11;
            //処理結果(ステータス)
            RetVal = string.Empty;
            RetValLen = 2;

            //電文長
            DenbunLen = RtMakerGoodsSearchHisNoLen + SetGoodsCountLen + RtSupplierCdLen + RtSupplierSnmLen + 
                        RtGoodsMakerCdLen + RtMakerShortNameLen + RtGoodsNoLen + RtGoodsNameLen + SetStockCountLen + 
                        RtWarehouseCodeLen + RtWarehouseShelfNoLen + RtShipmentPosCntLen + RetValLen;
        }
#endregion

#region "メソッド"

        /// <summary>
        /// 受信データ初期化
        /// </summary>
        /// <remarks></remarks>
        public void IniOutArg()
        {
            //パターン検索履歴通番
            RtMakerGoodsSearchHisNo = string.Empty;
            //セットした商品数
            SetGoodsCount = string.Empty;
            //仕入先コード
            RtSupplierCd = string.Empty;
            //仕入先名称
            RtSupplierSnm = string.Empty;
            //メーカーコード
            RtGoodsMakerCd = string.Empty;
            //メーカーコード略称
            RtMakerShortName = string.Empty;
            //商品番号
            RtGoodsNo = string.Empty;
            //商品名称
            RtGoodsName = string.Empty;
            //セットした在庫数
            SetStockCount = string.Empty;
            //倉庫コード
            RtWarehouseCode = string.Empty;
            //倉庫棚番
            RtWarehouseShelfNo = string.Empty;
            //出荷可能数
            RtShipmentPosCnt = string.Empty;
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

            //バーコード情報
            StSize = BarCodeInfoLen;
            BarCodeInfo = Encd.GetString(ArgVal, StPost, StSize);
            StPost += BarCodeInfoLen;

            //商品番号
            StSize = GoodsNoLen;
            GoodsNo = Encd.GetString(ArgVal, StPost, StSize);
            StPost += GoodsNoLen;

            return 0;
        }

        /// <summary>
        /// 受信データ取得（HT間通信プログラム用）
        /// ヘッダー情報
        /// </summary>
        /// <param name="rcvval"></param>
        /// <param name="stpost"></param>
        /// <remarks></remarks>
        public void RelayGetOutArgHeader(ref byte[] rcvval, ref Int32 stpost)
        {
            byte[] buf = null;
            Int32 intSetRow;
            string damSetRow = string.Empty;

            intSetRow = Int32.Parse(SetGoodsCount.Trim());

            //パターン検索履歴通番
            string damRtMakerGoodsSearchHisNo = clsCommon.FixB(RtMakerGoodsSearchHisNo, RtMakerGoodsSearchHisNoLen);
            buf = Encd.GetBytes(damRtMakerGoodsSearchHisNo);
            Array.Resize(ref rcvval, rcvval.Length + RtMakerGoodsSearchHisNoLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtMakerGoodsSearchHisNoLen);
            RtMakerGoodsSearchHisNo = damRtMakerGoodsSearchHisNo;
            stpost += RtMakerGoodsSearchHisNoLen;

            //セットした商品数
            damSetRow = clsCommon.FixB(System.Math.Abs(intSetRow).ToString(), SetGoodsCountLen);
            buf = Encd.GetBytes(damSetRow);
            Array.Resize(ref rcvval, rcvval.Length + SetGoodsCountLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, SetGoodsCountLen);
            SetGoodsCount = damSetRow;
            stpost += SetGoodsCountLen;
        }

        /// <summary>
        /// 受信データ取得（HT間通信プログラム用）
        /// 商品情報
        /// </summary>
        /// <param name="rcvval"></param>
        /// <param name="stpost"></param>
        /// <remarks></remarks>
        public void RelayGetOutArgGoodsInfo(ref byte[] rcvval, ref Int32 stpost)
        {
            byte[] buf = null;
            Int32 intSetStockRow;
            intSetStockRow = Int32.Parse(SetStockCount.Trim());

            //仕入先コード
            string damRtSupplierCd = clsCommon.FixB(RtSupplierCd, RtSupplierCdLen);
            buf = Encd.GetBytes(damRtSupplierCd);
            Array.Resize(ref rcvval, rcvval.Length + RtSupplierCdLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtSupplierCdLen);
            RtSupplierCd = damRtSupplierCd;
            stpost += RtSupplierCdLen;

            //仕入先名称
            string damRtSupplierSnm = clsCommon.FixB(RtSupplierSnm, RtSupplierSnmLen);
            buf = Encd.GetBytes(damRtSupplierSnm);
            Array.Resize(ref rcvval, rcvval.Length + RtSupplierSnmLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtSupplierSnmLen);
            RtSupplierSnm = damRtSupplierSnm;
            stpost += RtSupplierSnmLen;

            //メーカーコード
            string damRtGoodsMakerCd = clsCommon.FixB(RtGoodsMakerCd, RtGoodsMakerCdLen);
            buf = Encd.GetBytes(damRtGoodsMakerCd);
            Array.Resize(ref rcvval, rcvval.Length + RtGoodsMakerCdLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtGoodsMakerCdLen);
            RtGoodsMakerCd = damRtGoodsMakerCd;
            stpost += RtGoodsMakerCdLen;

            //メーカーコード略称
            string damRtMakerShortName = clsCommon.FixB(RtMakerShortName, RtMakerShortNameLen);
            buf = Encd.GetBytes(damRtMakerShortName);
            Array.Resize(ref rcvval, rcvval.Length + RtMakerShortNameLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtMakerShortNameLen);
            RtMakerShortName = damRtMakerShortName;
            stpost += RtMakerShortNameLen;

            //商品番号
            string damRtGoodsNo = clsCommon.FixB(RtGoodsNo, RtGoodsNoLen);
            buf = Encd.GetBytes(damRtGoodsNo);
            Array.Resize(ref rcvval, rcvval.Length + RtGoodsNoLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtGoodsNoLen);
            RtGoodsNo = damRtGoodsNo;
            stpost += RtGoodsNoLen;

            //商品名称
            string damRtGoodsName = clsCommon.FixB(RtGoodsName, RtGoodsNameLen);
            buf = Encd.GetBytes(damRtGoodsName);
            Array.Resize(ref rcvval, rcvval.Length + RtGoodsNameLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtGoodsNameLen);
            RtGoodsName = damRtGoodsName;
            stpost += RtGoodsNameLen;

            //セットした在庫数
            string damSetStockRow = clsCommon.FixB(System.Math.Abs(intSetStockRow).ToString(), SetStockCountLen);
            buf = Encd.GetBytes(damSetStockRow);
            Array.Resize(ref rcvval, rcvval.Length + SetStockCountLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, SetStockCountLen);
            SetStockCount = damSetStockRow;
            stpost += SetStockCountLen;
        }

        /// <summary>
        /// 受信データ取得（HT間通信プログラム用）
        /// 在庫情報
        /// </summary>
        /// <param name="rcvval"></param>
        /// <param name="stpost"></param>
        /// <remarks></remarks>
        public void RelayGetOutArgStock(ref byte[] rcvval, ref Int32 stpost)
        {
            byte[] buf = null;

            //倉庫コード
            string damRtWarehouseCode = clsCommon.FixB(RtWarehouseCode, RtWarehouseCodeLen);
            buf = Encd.GetBytes(damRtWarehouseCode);
            Array.Resize(ref rcvval, rcvval.Length + RtWarehouseCodeLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtWarehouseCodeLen);
            RtWarehouseCode = damRtWarehouseCode;
            stpost += RtWarehouseCodeLen;

            //倉庫棚番
            string damRtWarehouseShelfNo = clsCommon.FixB(RtWarehouseShelfNo, RtWarehouseShelfNoLen);
            buf = Encd.GetBytes(damRtWarehouseShelfNo);
            Array.Resize(ref rcvval, rcvval.Length + RtWarehouseShelfNoLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtWarehouseShelfNoLen);
            RtWarehouseShelfNo = damRtWarehouseShelfNo;
            stpost += RtWarehouseShelfNoLen;

            //出荷可能数
            string damRtShipmentPosCnt = clsCommon.FixB(RtShipmentPosCnt, RtShipmentPosCntLen);
            buf = Encd.GetBytes(damRtShipmentPosCnt);
            Array.Resize(ref rcvval, rcvval.Length + RtShipmentPosCntLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtShipmentPosCntLen);
            RtShipmentPosCnt = damRtShipmentPosCnt;
            stpost += RtShipmentPosCntLen;
        }

        /// <summary>
        /// 受信データ取得（HT間通信プログラム用）
        /// フッター情報
        /// </summary>
        /// <param name="rcvval"></param>
        /// <param name="stpost"></param>
        /// <remarks></remarks>
        public void RelayGetOutArgFooter(ref byte[] rcvval, ref Int32 stpost)
        {
            byte[] buf = null;

            //処理結果
            string damRetVal = RetVal.ToString().PadLeft(2, '0');
            buf = Encd.GetBytes(damRetVal);
            Array.Resize(ref rcvval, rcvval.Length + RetValLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RetValLen);
            RetVal = damRetVal;
            stpost += RetValLen;

            buf = Encd.GetBytes(clsBtConst.HT_MSG_CRLF);
            Array.Resize(ref rcvval, rcvval.Length + clsBtConst.HT_MSG_CRLF_LEN);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, clsBtConst.HT_MSG_CRLF_LEN);
            stpost += clsBtConst.HT_MSG_CRLF_LEN;
        }

#endregion

#region "関数"

#endregion

    }
}
