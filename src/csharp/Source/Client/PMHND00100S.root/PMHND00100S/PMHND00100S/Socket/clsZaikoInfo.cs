//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : PMNS-HTT通信サービス
// プログラム概要   : PMNS-HTT間の通信を行うサービスプログラムです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 佐藤　智之
// 作 成 日  2017/07/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PMHND00100S.Common;

namespace PMHND00100S.Socket
{
    /// public class name:   clsZaikoInfo
    /// <summary>
    ///                      ソケット通信用クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫情報取得(通常)用クラス</br>
    /// <br>Programmer       :   佐藤　智之</br>
    /// <br>Date             :   2017/07/01</br>
    /// <br></br>
    /// <br></br>
    /// <br>Update Note      :   </br>
    /// <br></br>
    /// </remarks>
    class clsZaikoInfo
    {

#region "プロパティ"
        private string _soksyorikbn = null;
        /// <summary>ソケット処理区分           数値型(4)</summary>
        public string SokSyoriKbn
        {
            get
            { return _soksyorikbn; }
            set
            { _soksyorikbn = value; }
        }

        private string _htname = null;
        /// <summary>コンピュータ名             文字型(20)</summary>
        public string HtName
        {
            get
            { return _htname; }
            set
            { _htname = value; }
        }
        private string _empcd = null;
        /// <summary>従業員コード               文字型(9)</summary>
        public string EmpCd
        {
            get
            { return _empcd; }
            set
            { _empcd = value; }
        }
        private string _syorikbn = null;
        /// <summary>処理区分                   数値型(2)</summary>
        public string SyoriKbn
        {
            get
            { return _syorikbn; }
            set
            { _syorikbn = value; }
        }
        private string _sokocd = null;
        /// <summary>倉庫コード                 文字型(4)</summary>
        public string SokoCd
        {
            get
            { return _sokocd; }
            set
            { _sokocd = value; }
        }
        private string _barcode = null;
        /// <summary>商品バーコード             文字型(128)</summary>
        public string Barcode
        {
            get
            { return _barcode; }
            set
            { _barcode = value; }
        }
        private string _makercd = null;
        /// <summary>メーカーコード             数値型(6)</summary>
        public string MakerCd
        {
            get
            { return _makercd; }
            set
            { _makercd = value; }
        }
        private string _syocd = null;
        /// <summary>商品番号                   文字型(40)</summary>
        public string SyoCd
        {
            get
            { return _syocd; }
            set
            { _syocd = value; }
        }
        private string _tanano = null;
        /// <summary>棚番                       文字型(8)</summary>
        public string TanaNo
        {
            get
            { return _tanano; }
            set
            { _tanano = value; }
        }

        private string _rtmakercd = null;
        /// <summary>メーカーコード             数値型(6)</summary>
        public string RtMakerCd
        {
            get
            { return _rtmakercd; }
            set
            { _rtmakercd = value; }
        }
        private string _rtmakernm = null;
        /// <summary>メーカー名                 文字型(20)</summary>
        public string RtMakerNm
        {
            get
            { return _rtmakernm; }
            set
            { _rtmakernm = value; }
        }
        private string _rtsyocd = null;
        /// <summary>商品番号                   文字型(40)</summary>
        public string RtSyoCd
        {
            get
            { return _rtsyocd; }
            set
            { _rtsyocd = value; }
        }
        private string _rtsyonm = null;
        /// <summary>商品名                     文字型(40)</summary>
        public string RtSyoNm
        {
            get
            { return _rtsyonm; }
            set
            { _rtsyonm = value; }
        }
        private string _rttanano = null;
        /// <summary>棚番                       文字型(8)</summary>
        public string RtTanaNo
        {
            get
            { return _rttanano; }
            set
            { _rttanano = value; }
        }
        private string _rtsokocd = null;
        /// <summary>倉庫コード                 文字型(4)</summary>
        public string RtSokoCd
        {
            get
            { return _rtsokocd; }
            set
            { _rtsokocd = value; }
        }
        private string _rtsokonm = null;
        /// <summary>倉庫名称                   文字型(20)</summary>
        public string RtSokoNm
        {
            get
            { return _rtsokonm; }
            set
            { _rtsokonm = value; }
        }
        private string _rtzaikonum = null;
        /// <summary>在庫数                     数値型(11(8.2))</summary>
        public string RtZaikoNum
        {
            get
            { return _rtzaikonum; }
            set
            { _rtzaikonum = value; }
        }
        private string _rtlasturi = null;
        /// <summary>最終売上日                 数値型(8)</summary>
        public string RtLastUri
        {
            get
            { return _rtlasturi; }
            set
            { _rtlasturi = value; }
        }
        private string _rtlastsir = null;
        /// <summary>最終仕入日                 数値型(8)</summary>
        public string RtLastSir
        {
            get
            { return _rtlastsir; }
            set
            { _rtlastsir = value; }
        }

        private string _retval = null;
        /// <summary>処理結果(ステータス)       数値型(2)</summary>
        public string RetVal
        {
            get
            { return _retval; }
            set
            { _retval = value; }
        }

        private Int32 _soksyorikbnlen = 0;
        /// <summary>ソケット処理区分長         数値型(4)</summary>
        public Int32 SokSyoriKbnLen
        {
            get
            { return _soksyorikbnlen; }
            set
            { _soksyorikbnlen = value; }
        }

        private Int32 _htnamelen = 0;
        /// <summary>コンピュータ名長           文字型(20)</summary>
        public Int32 HtNameLen
        {
            get
            { return _htnamelen; }
            set
            { _htnamelen = value; }
        }
        private Int32 _empcdlen = 0;
        /// <summary>従業員コード長             文字型(9)</summary>
        public Int32 EmpCdLen
        {
            get
            { return _empcdlen; }
            set
            { _empcdlen = value; }
        }
        private Int32 _syorikbnlen = 0;
        /// <summary>処理区分長                 数値型(2)</summary>
        public Int32 SyoriKbnLen
        {
            get
            { return _syorikbnlen; }
            set
            { _syorikbnlen = value; }
        }
        private Int32 _sokocdlen = 0;
        /// <summary>倉庫コード長               文字型(4)</summary>
        public Int32 SokoCdLen
        {
            get
            { return _sokocdlen; }
            set
            { _sokocdlen = value; }
        }
        private Int32 _barcodelen = 0;
        /// <summary>商品バーコード長           文字型(128)</summary>
        public Int32 BarcodeLen
        {
            get
            { return _barcodelen; }
            set
            { _barcodelen = value; }
        }
        private Int32 _makercdlen = 0;
        /// <summary>メーカーコード長           数値型(6)</summary>
        public Int32 MakerCdLen
        {
            get
            { return _makercdlen; }
            set
            { _makercdlen = value; }
        }
        private Int32 _syocdlen = 0;
        /// <summary>商品番号長                 文字型(40)</summary>
        public Int32 SyoCdLen
        {
            get
            { return _syocdlen; }
            set
            { _syocdlen = value; }
        }
        private Int32 _tananolen = 0;
        /// <summary>棚番長                     文字型(8)</summary>
        public Int32 TanaNoLen
        {
            get
            { return _tananolen; }
            set
            { _tananolen = value; }
        }


        private Int32 _rtmakercdlen = 0;
        /// <summary>メーカーコード長           数値型(6)</summary>
        public Int32 RtMakerCdLen
        {
            get
            { return _rtmakercdlen; }
            set
            { _rtmakercdlen = value; }
        }
        private Int32 _rtmakernmlen = 0;
        /// <summary>メーカー名長               文字型(20)</summary>
        public Int32 RtMakerNmLen
        {
            get
            { return _rtmakernmlen; }
            set
            { _rtmakernmlen = value; }
        }
        private Int32 _rtsyocdlen = 0;
        /// <summary>商品番号長                 文字型(40)</summary>
        public Int32 RtSyoCdLen
        {
            get
            { return _rtsyocdlen; }
            set
            { _rtsyocdlen = value; }
        }
        private Int32 _rtsyonmlen = 0;
        /// <summary>商品名長                   文字型(40)</summary>
        public Int32 RtSyoNmLen
        {
            get
            { return _rtsyonmlen; }
            set
            { _rtsyonmlen = value; }
        }
        private Int32 _rttananolen = 0;
        /// <summary>棚番長                     文字型(8)</summary>
        public Int32 RtTanaNoLen
        {
            get
            { return _rttananolen; }
            set
            { _rttananolen = value; }
        }
        private Int32 _rtsokocdlen = 0;
        /// <summary>倉庫コード長               文字型(4)</summary>
        public Int32 RtSokoCdLen
        {
            get
            { return _rtsokocdlen; }
            set
            { _rtsokocdlen = value; }
        }
        private Int32 _rtsokonmlen = 0;
        /// <summary>倉庫名称長                 文字型(20)</summary>
        public Int32 RtSokoNmLen
        {
            get
            { return _rtsokonmlen; }
            set
            { _rtsokonmlen = value; }
        }
        private Int32 _rtzaikonumlen = 0;
        /// <summary>在庫数長                   数値型(11(8.2))</summary>
        public Int32 RtZaikoNumLen
        {
            get
            { return _rtzaikonumlen; }
            set
            { _rtzaikonumlen = value; }
        }
        private Int32 _rtlasturilen = 0;
        /// <summary>最終売上日長               数値型(8)</summary>
        public Int32 RtLastUriLen
        {
            get
            { return _rtlasturilen; }
            set
            { _rtlasturilen = value; }
        }
        private Int32 _rtlastsirlen = 0;
        /// <summary>最終仕入日長               数値型(8)</summary>
        public Int32 RtLastSirLen
        {
            get
            { return _rtlastsirlen; }
            set
            { _rtlastsirlen = value; }
        }

        private Int32 _retvallen = 0;
        /// <summary>処理結果(ステータス)長     数値型(2)</summary>
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
        public clsZaikoInfo()
        {
            //ソケット通信処理
            SokSyoriKbn = clsBtConst.SCKSYRKBN_GET_ZAIKOINFO.ToString();
            SokSyoriKbnLen = 4;

            //コンピューター名
            HtName = string.Empty;
            HtNameLen = 20;
            //従業員コード
            EmpCd = string.Empty;
            EmpCdLen = 9;
            //処理区分
            SyoriKbn = string.Empty;
            SyoriKbnLen = 2;
            //倉庫コード
            SokoCd = string.Empty;
            SokoCdLen = 4;
            //商品バーコード
            Barcode = string.Empty;
            BarcodeLen = 128;
            //メーカーコード
            MakerCd = string.Empty;
            MakerCdLen = 6;
            //商品番号
            SyoCd = string.Empty;
            SyoCdLen = 40;
            //棚番
            TanaNo = string.Empty;
            TanaNoLen = 8;

            //処理結果
            RetVal = string.Empty;
            RetValLen = 2;

            //メーカーコード
            RtMakerCd = string.Empty;
            RtMakerCdLen = 6;
            //メーカー名
            RtMakerNm = string.Empty;
            RtMakerNmLen = 20;
            //商品番号
            RtSyoCd = string.Empty;
            RtSyoCdLen = 40;
            //商品名
            RtSyoNm = string.Empty;
            RtSyoNmLen = 40;
            //棚番
            RtTanaNo = string.Empty;
            RtTanaNoLen = 8;
            //倉庫コード
            RtSokoCd = string.Empty;
            RtSokoCdLen = 4;
            //倉庫名
            RtSokoNm = string.Empty;
            RtSokoNmLen = 20;
            //在庫数
            RtZaikoNum = string.Empty;
            RtZaikoNumLen = 11;
            //最終売上日
            RtLastUri = string.Empty;
            RtLastUriLen = 8;
            //最終仕入日
            RtLastSir = string.Empty;
            RtLastSirLen = 8;

            //電文長
            DenbunLen = RtMakerCdLen + RtMakerNmLen + RtSyoCdLen + RtSyoNmLen + RtTanaNoLen;
            DenbunLen += RtSokoCdLen + RtSokoNmLen + RtZaikoNumLen + RtLastUriLen + RtLastSirLen;
        }

#endregion

#region "メソッド "
        /// <summary>
        /// 受信データ初期化
        /// </summary>
        /// <remarks></remarks>
        public void IniOutArg()
        {
            //メーカーコード
            RtMakerCd = string.Empty;
            //メーカー名
            RtMakerNm = string.Empty;
            //商品番号
            RtSyoCd = string.Empty;
            //商品名
            RtSyoNm = string.Empty;
            //棚番
            RtTanaNo = string.Empty;
            //倉庫コード
            RtSokoCd = string.Empty;
            //倉庫名
            RtSokoNm = string.Empty;
            //在庫数
            RtZaikoNum = string.Empty;
            //最終売上日
            RtLastUri = string.Empty;
            //最終仕入日
            RtLastSir = string.Empty;

            //処理結果
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

            //処理区分
            StSize = SyoriKbnLen;
            SyoriKbn = Encd.GetString(ArgVal, StPost, StSize);
            StPost += SyoriKbnLen;

            //倉庫コード
            StSize = SokoCdLen;
            SokoCd = Encd.GetString(ArgVal, StPost, StSize);
            StPost += SokoCdLen;

            //商品バーコード
            StSize = BarcodeLen;
            Barcode = Encd.GetString(ArgVal, StPost, StSize);
            StPost += BarcodeLen;

            //メーカーコード
            StSize = MakerCdLen;
            MakerCd = Encd.GetString(ArgVal, StPost, StSize);
            StPost += MakerCdLen;

            //商品番号
            StSize = SyoCdLen;
            SyoCd = Encd.GetString(ArgVal, StPost, StSize);
            StPost += SyoCdLen;

            //棚番
            StSize = TanaNoLen;
            TanaNo = Encd.GetString(ArgVal, StPost, StSize);

            return 0;
        }

        /// <summary>
        /// 受信データ取得（HT間通信プログラム用）
        /// </summary>
        /// <remarks>ハンディプログラムでの受信バッファにあわせて5000Byte以下である必要があります</remarks>
        public byte[] RelayGetOutArg()
        {
            byte[] rcvval = new byte[] { };
            byte[] buf = null;
            Int32 stpost = 0;

            //メーカーコード
            string damRtMakerCd = clsCommon.FixB(RtMakerCd, RtMakerCdLen);
            buf = Encd.GetBytes(damRtMakerCd);
            stpost = 0;
            Array.Resize(ref rcvval, RtMakerCdLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtMakerCdLen);
            RtMakerCd = damRtMakerCd;

            //メーカー名
            string damRtMakerNm = clsCommon.FixB(RtMakerNm, RtMakerNmLen);
            buf = Encd.GetBytes(damRtMakerNm);
            stpost += RtMakerCdLen;
            Array.Resize(ref rcvval, rcvval.Length + RtMakerNmLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtMakerNmLen);
            RtMakerNm = damRtMakerNm;

            //商品番号
            string damRtSyoCd = clsCommon.FixB(RtSyoCd, RtSyoCdLen);
            buf = Encd.GetBytes(damRtSyoCd);
            stpost += RtMakerNmLen;
            Array.Resize(ref rcvval, rcvval.Length + RtSyoCdLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtSyoCdLen);
            RtSyoCd = damRtSyoCd;

            //商品名
            string damRtSyoNm = clsCommon.FixB(RtSyoNm, RtSyoNmLen);
            buf = Encd.GetBytes(damRtSyoNm);
            stpost += RtSyoCdLen;
            Array.Resize(ref rcvval, rcvval.Length + RtSyoNmLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtSyoNmLen);
            RtSyoNm = damRtSyoNm;

            //棚番
            string damRtTanaNo = clsCommon.FixB(RtTanaNo, RtTanaNoLen);
            buf = Encd.GetBytes(damRtTanaNo);
            stpost += RtSyoNmLen;
            Array.Resize(ref rcvval, rcvval.Length + RtTanaNoLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtTanaNoLen);
            RtTanaNo = damRtTanaNo;

            //倉庫コード
            string damRtSokoCd = clsCommon.FixB(RtSokoCd, RtSokoCdLen);
            buf = Encd.GetBytes(damRtSokoCd);
            stpost += RtTanaNoLen;
            Array.Resize(ref rcvval, rcvval.Length + RtSokoCdLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtSokoCdLen);
            RtSokoCd = damRtSokoCd;

            //倉庫名
            string damRtSokoNm = clsCommon.FixB(RtSokoNm, RtSokoNmLen);
            buf = Encd.GetBytes(damRtSokoNm);
            stpost += RtSokoCdLen;
            Array.Resize(ref rcvval, rcvval.Length + RtSokoNmLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtSokoNmLen);
            RtSokoNm = damRtSokoNm;

            //在庫数
            string damRtZaikoNum = clsCommon.FixB(RtZaikoNum, RtZaikoNumLen);
            buf = Encd.GetBytes(damRtZaikoNum);
            stpost += RtSokoNmLen;
            Array.Resize(ref rcvval, rcvval.Length + RtZaikoNumLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtZaikoNumLen);
            RtZaikoNum = damRtZaikoNum;

            //最終売上日
            string damRtLastUri = clsCommon.FixB(RtLastUri, RtLastUriLen);
            buf = Encd.GetBytes(damRtLastUri);
            stpost += RtZaikoNumLen;
            Array.Resize(ref rcvval, rcvval.Length + RtLastUriLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtLastUriLen);
            RtLastUri = damRtLastUri;

            //最終仕入日
            string damRtLastSir = clsCommon.FixB(RtLastSir, RtLastSirLen);
            buf = Encd.GetBytes(damRtLastSir);
            stpost += RtLastUriLen;
            Array.Resize(ref rcvval, rcvval.Length + RtLastSirLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtLastSirLen);
            RtLastSir = damRtLastSir;

            //処理結果
            string damRetVal = RetVal.ToString().PadLeft(2, '0');
            buf = Encd.GetBytes(damRetVal);
            stpost += RtLastSirLen;
            Array.Resize(ref rcvval, rcvval.Length + RetValLen);
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
