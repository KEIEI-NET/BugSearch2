//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ハンディターミナル
// プログラム概要   : ハンディターミナル　メインプログラム(ソケット通信)
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 佐藤　智之
// 作 成 日  2017/08/01  修正内容 : ２次開発
//----------------------------------------------------------------------------//
// 管理番号  11570136-00 作成担当 : 白厩  翔也
// 修 正 日  2019/10/16  修正内容 : ６次対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PMHND00100S.Common;

namespace PMHND00100S.Socket
{
    /// public class name:   clsNyuSyuSlipInfo
    /// <summary>
    ///                      ソケット通信用クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   検品対象情報取得用クラス</br>
    /// <br>Programmer       :   佐藤　智之</br>
    /// <br>Date             :   2017/08/01</br>
    /// <br></br>
    /// <br></br>
    /// <br>Update Note      :   </br>
    /// <br></br>
    /// </remarks>
    class clsNyuSyuSlipInfo
    {

#region "プロパティ"
        private string _soksyorikbn = null;
        /// <summary>ソケット処理区分                       数値型(4)</summary>
        public string SokSyoriKbn
        {
            get
            { return _soksyorikbn; }
            set
            { _soksyorikbn = value; }
        }

        private string _htname = null;
        /// <summary>コンピュータ名                         文字型(20)</summary>
        public string HtName
        {
            get
            { return _htname; }
            set
            { _htname = value; }
        }
        private string _empcd = null;
        /// <summary>従業員コード                           文字型(9)</summary>
        public string EmpCd
        {
            get
            { return _empcd; }
            set
            { _empcd = value; }
        }
        private string _procdiv = null;
        /// <summary>処理区分                               数値型(2)</summary>
        public string ProcDiv
        {
            get
            { return _procdiv; }
            set
            { _procdiv = value; }
        }
        private string _sokocd = null;
        /// <summary>倉庫コード                       　    文字型(4)</summary>
        public string SokoCd
        {
            get
            { return _sokocd; }
            set
            { _sokocd = value; }
        }
        private string _barcode = null;
        /// <summary>商品バーコード                         文字型(128)</summary>
        public string BarCode
        {
            get
            { return _barcode; }
            set
            { _barcode = value; }
        }

        private string _rtmakercd = null;
        /// <summary>メーカーコード                         数値型(6)</summary>
        public string RtMakerCd
        {
            get
            { return _rtmakercd; }
            set
            { _rtmakercd = value; }
        }
        private string _rtmakernm = null;
        /// <summary>メーカー名                             文字型(20)</summary>
        public string RtMakerNm
        {
            get
            { return _rtmakernm; }
            set
            { _rtmakernm = value; }
        }
        private string _rtsyocd = null;
        /// <summary>商品番号                               文字型(40)</summary>
        public string RtSyoCd
        {
            get
            { return _rtsyocd; }
            set
            { _rtsyocd = value; }
        }
        private string _rtsyonm = null;
        /// <summary>商品名称                               文字型(100)</summary>
        public string RtSyoNm
        {
            get
            { return _rtsyonm; }
            set
            { _rtsyonm = value; }
        }
        private string _rttanano = null;
        /// <summary>棚番                                   文字型(8)</summary>
        public string RtTanaNo
        {
            get
            { return _rttanano; }
            set
            { _rttanano = value; }
        }
        private string _rthacnm = null;
        /// <summary>発注先名                               文字型(60)</summary>
        public string RtHacNm
        {
            get
            { return _rthacnm; }
            set
            { _rthacnm = value; }
        }
        private string _rtsirnm = null;
        /// <summary>仕入先名                               文字型(60)</summary>
        public string RtSirNm
        {
            get
            { return _rtsirnm; }
            set
            { _rtsirnm = value; }
        }

        private string _retval = null;
        /// <summary>処理結果(ステータス)                   数値型(2)</summary>
        public string RetVal
        {
            get
            { return _retval; }
            set
            { _retval = value; }
        }
        // -- ADD 2019/10/16 ------------------------------>>>
        private string _setrow = null;
        /// <summary>セットした行数                         数値型(4)</summary>
        public string SetRow
        {
            get
            { return _setrow; }
            set
            { _setrow = value; }
        }
        // -- ADD 2019/10/16 ------------------------------<<<

        private Int32 _soksyorikbnlen = 0;
        /// <summary>ソケット処理区分長                     数値型(4)</summary>
        public Int32 SokSyoriKbnLen
        {
            get
            { return _soksyorikbnlen; }
            set
            { _soksyorikbnlen = value; }
        }

        private Int32 _htnamelen = 0;
        /// <summary>コンピュータ名長                       文字型(20)</summary>
        public Int32 HtNameLen
        {
            get
            { return _htnamelen; }
            set
            { _htnamelen = value; }
        }
        private Int32 _empcdlen = 0;
        /// <summary>従業員コード長                         文字型(9)</summary>
        public Int32 EmpCdLen
        {
            get
            { return _empcdlen; }
            set
            { _empcdlen = value; }
        }
        private Int32 _procdivlen = 0;
        /// <summary>処理区分長                             数値型(2)</summary>
        public Int32 ProcDivLen
        {
            get
            { return _procdivlen; }
            set
            { _procdivlen = value; }
        }
        private Int32 _sokocdlen = 0;
        /// <summary>倉庫コード長                     　    文字型(4)</summary>
        public Int32 SokoCdLen
        {
            get
            { return _sokocdlen; }
            set
            { _sokocdlen = value; }
        }
        private Int32 _barcodelen = 0;
        /// <summary>商品バーコード                         文字型(128)</summary>
        public Int32 BarCodeLen
        {
            get
            { return _barcodelen; }
            set
            { _barcodelen = value; }
        }

        private Int32 _rtmakercdlen = 0;
        /// <summary>メーカーコード                         数値型(6)</summary>
        public Int32 RtMakerCdLen
        {
            get
            { return _rtmakercdlen; }
            set
            { _rtmakercdlen = value; }
        }
        private Int32 _rtmakernmlen = 0;
        /// <summary>メーカー名長                           文字型(20)</summary>
        public Int32 RtMakerNmLen
        {
            get
            { return _rtmakernmlen; }
            set
            { _rtmakernmlen = value; }
        }
        private Int32 _rtsyocdlen = 0;
        /// <summary>商品番号                               文字型(40)</summary>
        public Int32 RtSyoCdLen
        {
            get
            { return _rtsyocdlen; }
            set
            { _rtsyocdlen = value; }
        }
        private Int32 _rtsyonmlen = 0;
        /// <summary>商品名称                               文字型(100)</summary>
        public Int32 RtSyoNmLen
        {
            get
            { return _rtsyonmlen; }
            set
            { _rtsyonmlen = value; }
        }
        private Int32 _rttananolen = 0;
        /// <summary>棚番長                                 文字型(8)</summary>
        public Int32 RtTanaNoLen
        {
            get
            { return _rttananolen; }
            set
            { _rttananolen = value; }
        }
        private Int32 _rthacnmlen = 0;
        /// <summary>発注先名長                             文字型(60)</summary>
        public Int32 RtHacNmLen
        {
            get
            { return _rthacnmlen; }
            set
            { _rthacnmlen = value; }
        }
        private Int32 _rtsirnmlen = 0;
        /// <summary>仕入先名長                             文字型(60)</summary>
        public Int32 RtSirNmLen
        {
            get
            { return _rtsirnmlen; }
            set
            { _rtsirnmlen = value; }
        }

        private Int32 _retvallen = 0;
        /// <summary>処理結果(ステータス)長                 数値型(2)</summary>
        public Int32 RetValLen
        {
            get
            { return _retvallen; }
            set
            { _retvallen = value; }
        }
        // -- ADD 2019/10/16 ------------------------------>>>
        private Int32 _setrowlen = 0;
        /// <summary>セットした行数長                       数値型(4)</summary>
        public Int32 SetRowLen
        {
            get
            { return _setrowlen; }
            set
            { _setrowlen = value; }
        }
        // -- ADD 2019/10/16 ------------------------------<<<

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
        public clsNyuSyuSlipInfo()
        {
            //ソケット通信処理区分
            SokSyoriKbn = clsBtConst.SCKSYRKBN_GET_SYOHININFO.ToString();
            SokSyoriKbnLen = 4;

            //コンピューター名
            HtName = string.Empty;
            HtNameLen = 20;
            //従業員コード
            EmpCd = string.Empty;
            EmpCdLen = 9;
            //処理区分
            ProcDiv= string.Empty;
            ProcDivLen = 2;
            //倉庫コード
            SokoCd = string.Empty;
            SokoCdLen = 4;
            //商品バーコード
            BarCode = string.Empty;
            BarCodeLen = 128;

            //処理結果
            RetVal = string.Empty;
            RetValLen = 2;

            // -- ADD 2019/10/16 ------------------------------>>>
            //セットした行数
            SetRow = string.Empty;
            SetRowLen = 4;
            // -- ADD 2019/10/16 ------------------------------<<<

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
            RtSyoNmLen = 100;
            //棚番
            RtTanaNo = string.Empty;
            RtTanaNoLen = 8;
            //発注先名
            RtHacNm = string.Empty;
            RtHacNmLen = 60;
            //仕入先名
            RtSirNm = string.Empty;
            RtSirNmLen = 60;

            //電文長
            DenbunLen = RtMakerCdLen + RtMakerNmLen + RtSyoCdLen + RtSyoNmLen;
            DenbunLen += RtTanaNoLen + RtHacNmLen + RtSirNmLen;
        }

#endregion

#region "メソッド "
        /// <summary>
        /// 受信データ初期化
        /// </summary>
        /// <remarks></remarks>
        public void IniOutArg()
        {
            // -- ADD 2019/10/16 ------------------------------>>>
            //セットした行数
            SetRow = string.Empty;
            // -- ADD 2019/10/16 ------------------------------<<<
            //メーカーコード
            RtMakerCd = string.Empty;
            //メーカー名
            RtMakerNm = string.Empty;
            //商品番号
            RtSyoCd = string.Empty;
            //商品
            RtSyoNm = string.Empty;
            //棚番
            RtTanaNo = string.Empty;
            //発注先名
            RtHacNm = string.Empty;
            //仕入先名
            RtSirNm = string.Empty;

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
            StSize = ProcDivLen;
            ProcDiv = Encd.GetString(ArgVal, StPost, StSize);
            StPost += ProcDivLen;

            //倉庫コード
            StSize = SokoCdLen;
            SokoCd = Encd.GetString(ArgVal, StPost, StSize);
            StPost += SokoCdLen;

            //商品バーコード
            StSize = BarCodeLen;
            BarCode = Encd.GetString(ArgVal, StPost, StSize);
            StPost += BarCodeLen;

            // -- ADD 2019/10/16 ------------------------------>>>
            //商品番号
            StSize = RtSyoCdLen;
            RtSyoCd = Encd.GetString(ArgVal, StPost, StSize);
            StPost += RtSyoCdLen;
            // -- ADD 2019/10/16 ------------------------------<<<

            return 0;
        }

        /// <summary>
        /// 受信データ取得（HT間通信プログラム用）
        /// </summary>
        /// <param name="rcvval"></param>
        /// <param name="stpost"></param>
        /// <remarks></remarks>
        public void RelayGetOutArg(ref byte[] rcvval, ref Int32 stpost)
        {
            byte[] buf = null;
            string damSetRow = string.Empty;

            // -- ADD 2019/10/16 ------------------------------>>>
            Int32 intSetRow;

            intSetRow = Int32.Parse(SetRow.Trim());

            if (((intSetRow != 0) && (intSetRow > 0)) || (intSetRow == -1))
            {
                damSetRow = clsCommon.FixB(System.Math.Abs(intSetRow).ToString(), SetRowLen);
                buf = Encd.GetBytes(damSetRow);
                Array.Resize(ref rcvval, rcvval.Length + SetRowLen);
                Buffer.BlockCopy(buf, 0, rcvval, stpost, SetRowLen);
                SetRow = damSetRow;
                stpost += SetRowLen;
            }
            // -- ADD 2019/10/16 ------------------------------<<<

            //メーカーコード
            string damRtMakerCd = clsCommon.FixB(RtMakerCd, RtMakerCdLen);
            buf = Encd.GetBytes(damRtMakerCd);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtMakerCdLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtMakerCdLen);
            RtMakerCd = damRtMakerCd;
            stpost += RtMakerCdLen;

            //メーカー名
            string damRtMakerNm = clsCommon.FixB(RtMakerNm, RtMakerNmLen);
            buf = Encd.GetBytes(damRtMakerNm);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtMakerNmLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtMakerNmLen);
            RtMakerNm = damRtMakerNm;
            stpost += RtMakerNmLen;

            //商品番号
            string damRtSyoCd = clsCommon.FixB(RtSyoCd, RtSyoCdLen);
            buf = Encd.GetBytes(damRtSyoCd);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtSyoCdLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtSyoCdLen);
            RtSyoCd = damRtSyoCd;
            stpost += RtSyoCdLen;

            //商品名称
            string damRtSyoNm = clsCommon.FixB(RtSyoNm, RtSyoNmLen);
            buf = Encd.GetBytes(damRtSyoNm);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtSyoNmLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtSyoNmLen);
            RtSyoNm = damRtSyoNm;
            stpost += RtSyoNmLen;

            //棚番
            string damRtTanaNo = clsCommon.FixB(RtTanaNo, RtTanaNoLen);
            buf = Encd.GetBytes(damRtTanaNo);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtTanaNoLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtTanaNoLen);
            RtTanaNo = damRtTanaNo;
            stpost += RtTanaNoLen;

            //発注先名
            string damRtHacNm = clsCommon.FixB(RtHacNm, RtHacNmLen);
            buf = Encd.GetBytes(damRtHacNm);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtHacNmLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtHacNmLen);
            RtHacNm = damRtHacNm;
            stpost += RtHacNmLen;

            //仕入先名
            string damRtSirNm = clsCommon.FixB(RtSirNm, RtSirNmLen);
            buf = Encd.GetBytes(damRtSirNm);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtSirNmLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtSirNmLen);
            RtSirNm = damRtSirNm;
            stpost += RtSirNmLen;

            // -- UPD 2019/10/16 ------------------------------>>>
            ////処理結果
            //string damRetVal = RetVal.ToString().PadLeft(2, '0');
            //buf = Encd.GetBytes(damRetVal);
            //// -- ADD 2019/10/16 ------------------------------>>>
            //Array.Resize(ref rcvval, rcvval.Length + RetValLen);
            //// -- ADD 2019/10/16 ------------------------------<<<
            //Buffer.BlockCopy(buf, 0, rcvval, stpost, RetValLen);
            //RetVal = damRetVal;
            //stpost += RetValLen;

            //buf = Encd.GetBytes(clsBtConst.HT_MSG_CRLF);
            //Array.Resize(ref rcvval, rcvval.Length + clsBtConst.HT_MSG_CRLF_LEN);
            //Buffer.BlockCopy(buf, 0, rcvval, stpost, clsBtConst.HT_MSG_CRLF_LEN);
            //stpost += clsBtConst.HT_MSG_CRLF_LEN;
            //最終行処理
            if (intSetRow < 0)
            {
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
            // -- UPD 2019/10/16 ------------------------------<<<
        }

#endregion

#region "関数"

#endregion

    }
}
