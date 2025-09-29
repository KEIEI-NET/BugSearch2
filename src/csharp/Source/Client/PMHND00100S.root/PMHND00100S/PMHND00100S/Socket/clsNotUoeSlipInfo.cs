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
using PMHND00100S.Common;

namespace PMHND00100S.Socket
{
    /// public class name:   clsNotUoeSlipInfo
    /// <summary>
    ///                      ソケット通信用クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   検品データ取得用クラス</br>
    /// <br>Programmer       :   佐藤　智之</br>
    /// <br>Date             :   2017/08/01</br>
    /// <br></br>
    /// <br></br>
    /// <br>Update Note      :   </br>
    /// <br></br>
    /// </remarks>
    class clsNotUoeSlipInfo
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
        private string _slipno = null;
        /// <summary>仕入SEQ番号                            数値型(9)</summary>
        public string SlipNo
        {
            get
            { return _slipno; }
            set
            { _slipno = value; }
        }

        private string _rtsirnm = null;
        /// <summary>仕入先略称                             文字型(20)</summary>
        public string RtSirNm
        {
            get
            { return _rtsirnm; }
            set
            { _rtsirnm = value; }
        }

        private string _setrow = null;
        /// <summary>セットした行数                         数値型(4)</summary>
        public string SetRow
        {
            get
            { return _setrow; }
            set
            { _setrow = value; }
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
        private string _rtsokocd = null;
        /// <summary>倉庫コード                             文字型(4)</summary>
        public string RtSokoCd
        {
            get
            { return _rtsokocd; }
            set
            { _rtsokocd = value; }
        }
        private string _rttanano = null;
        /// <summary>倉庫棚番                               文字型(8)</summary>
        public string RtTanaNo
        {
            get
            { return _rttanano; }
            set
            { _rttanano = value; }
        }
        private string _rtbarcode = null;
        /// <summary>商品バーコード                         文字型(128)</summary>
        public string RtBarCode
        {
            get
            { return _rtbarcode; }
            set
            { _rtbarcode = value; }
        }
        private string _rtnyunum = null;
        /// <summary>入荷数                                 数値型(11(8.2))</summary>
        public string RtNyuNum
        {
            get
            { return _rtnyunum; }
            set
            { _rtnyunum = value; }
        }
        private string _rtsirrowseq = null;
        /// <summary>仕入明細通番                           数値型(12)</summary>
        public string RtSirRowSeq
        {
            get
            { return _rtsirrowseq; }
            set
            { _rtsirrowseq = value; }
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
        private Int32 _slipnolen = 0;
        /// <summary>仕入SEQ番号長                          数値型(9)</summary>
        public Int32 SlipNoLen
        {
            get
            { return _slipnolen; }
            set
            { _slipnolen = value; }
        }

        private Int32 _rtsirnmlen = 0;
        /// <summary>仕入先略称                             文字型(20)</summary>
        public Int32 RtSirNmLen
        {
            get
            { return _rtsirnmlen; }
            set
            { _rtsirnmlen = value; }
        }

        private Int32 _setrowlen = 0;
        /// <summary>セットした行数長                       数値型(4)</summary>
        public Int32 SetRowLen
        {
            get
            { return _setrowlen; }
            set
            { _setrowlen = value; }
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
        private Int32 _rtsokocdlen = 0;
        /// <summary>倉庫コード長                           文字型(4)</summary>
        public Int32 RtSokoCdLen
        {
            get
            { return _rtsokocdlen; }
            set
            { _rtsokocdlen = value; }
        }
        private Int32 _rttananolen = 0;
        /// <summary>倉庫棚番長                             文字型(8)</summary>
        public Int32 RtTanaNoLen
        {
            get
            { return _rttananolen; }
            set
            { _rttananolen = value; }
        }
        private Int32 _rtbarcodelen = 0;
        /// <summary>商品バーコード                         文字型(128)</summary>
        public Int32 RtBarCodeLen
        {
            get
            { return _rtbarcodelen; }
            set
            { _rtbarcodelen = value; }
        }
        private Int32 _rtnyunumlen = 0;
        /// <summary>入荷数長                               数値型(11(8.2))</summary>
        public Int32 RtNyuNumLen
        {
            get
            { return _rtnyunumlen; }
            set
            { _rtnyunumlen = value; }
        }
        private Int32 _rtsirrowseqlen = 0;
        /// <summary>仕入明細通番長                         数値型(12)</summary>
        public Int32 RtSirRowSeqLen
        {
            get
            { return _rtsirrowseqlen; }
            set
            { _rtsirrowseqlen = value; }
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
        public clsNotUoeSlipInfo()
        {
            //ソケット通信処理区分
            SokSyoriKbn = string.Empty;
            SokSyoriKbnLen = 4;

            //コンピューター名
            HtName = string.Empty;
            HtNameLen = 20;
            //従業員コード
            EmpCd = string.Empty;
            EmpCdLen = 9;
            //処理区分
            ProcDiv = string.Empty;
            ProcDivLen = 2;
            //仕入SEQ番号
            SlipNo = string.Empty;
            SlipNoLen = 9;

            //仕入先略称
            RtSirNm = string.Empty;
            RtSirNmLen = 20;

            //セットした行数
            SetRow = string.Empty;
            SetRowLen = 4;

            //メーカーコード
            RtMakerCd = String.Empty;
            RtMakerCdLen = 6;
            //商品番号
            RtSyoCd = String.Empty;
            RtSyoCdLen = 40;
            //商品名
            RtSyoNm = String.Empty;
            RtSyoNmLen = 100;
            //倉庫コード
            RtSokoCd = String.Empty;
            RtSokoCdLen = 4;
            //倉庫棚番
            RtTanaNo = String.Empty;
            RtTanaNoLen = 8;
            //商品バーコード
            RtBarCode = String.Empty;
            RtBarCodeLen = 128;
            //入荷数
            RtNyuNum = String.Empty;
            RtNyuNumLen = 11;
            //仕入明細通番
            RtSirRowSeq = String.Empty;
            RtSirRowSeqLen = 12;

            //処理結果
            RetVal = string.Empty;
            RetValLen = 2;

            //電文長
            DenbunLen = SetRowLen + RtMakerCdLen + RtSyoCdLen + RtSyoNmLen;
            DenbunLen += RtSokoCdLen + RtTanaNoLen + RtBarCodeLen + RtNyuNumLen + RtSirRowSeqLen;
        }

#endregion

#region "メソッド "
        /// <summary>
        /// 受信データ初期化
        /// </summary>
        /// <remarks></remarks>
        public void IniOutArg()
        {
            //仕入先略称
            RtSirNm = string.Empty;

            //セットした行数
            SetRow = string.Empty;

            //メーカーコード
            RtMakerCd = String.Empty;
            //商品番号
            RtSyoCd = String.Empty;
            //商品名
            RtSyoNm = String.Empty;
            //倉庫コード
            RtSokoCd = String.Empty;
            //倉庫棚番
            RtTanaNo = String.Empty;
            //商品バーコード
            RtBarCode = String.Empty;
            //入荷数
            RtNyuNum = String.Empty;
            //仕入明細通番
            RtSirRowSeq = String.Empty;

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

            //仕入SEQ番号
            StSize = SlipNoLen;
            SlipNo = Encd.GetString(ArgVal, StPost, StSize);
            StPost += SlipNoLen;

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
            Int32 intSetRow;
            string damSetRow = string.Empty;

            intSetRow = Int32.Parse(SetRow.Trim());

            if (((intSetRow != 0) && (intSetRow > 0)) || (intSetRow == -1))
            {
                //仕入先略称
                string damRtSirNm = clsCommon.FixB(RtSirNm, RtSirNmLen);
                buf = Encd.GetBytes(damRtSirNm);
                // -- ADD 2019/10/16 ------------------------------>>>
                Array.Resize(ref rcvval, rcvval.Length + RtSirNmLen);
                // -- ADD 2019/10/16 ------------------------------<<<
                Buffer.BlockCopy(buf, 0, rcvval, stpost, RtSirNmLen);
                RtSirNm = damRtSirNm;
                stpost += RtSirNmLen;

                damSetRow = clsCommon.FixB(System.Math.Abs(intSetRow).ToString(), SetRowLen);
                buf = Encd.GetBytes(damSetRow);
                // -- ADD 2019/10/16 ------------------------------>>>
                Array.Resize(ref rcvval, rcvval.Length + SetRowLen);
                // -- ADD 2019/10/16 ------------------------------<<<
                Buffer.BlockCopy(buf, 0, rcvval, stpost, SetRowLen);
                SetRow = damSetRow;
                stpost += SetRowLen;
            }

            //メーカーコード
            string damRtMakerCd = clsCommon.FixB(RtMakerCd, RtMakerCdLen);
            buf = Encd.GetBytes(damRtMakerCd);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtMakerCdLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtMakerCdLen);
            RtMakerCd = damRtMakerCd;
            stpost += RtMakerCdLen;

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

            //倉庫コード
            string damRtSokoCd = clsCommon.FixB(RtSokoCd, RtSokoCdLen);
            buf = Encd.GetBytes(damRtSokoCd);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtSokoCdLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtSokoCdLen);
            RtSokoCd = damRtSokoCd;
            stpost += RtSokoCdLen;

            //倉庫棚番
            string damRtTanaNo = clsCommon.FixB(RtTanaNo, RtTanaNoLen);
            buf = Encd.GetBytes(damRtTanaNo);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtTanaNoLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtTanaNoLen);
            RtTanaNo = damRtTanaNo;
            stpost += RtTanaNoLen;

            //商品バーコード
            string damRtBarCode = clsCommon.FixB(RtBarCode, RtBarCodeLen);
            buf = Encd.GetBytes(damRtBarCode);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtBarCodeLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtBarCodeLen);
            RtBarCode = damRtBarCode;
            stpost += RtBarCodeLen;

            //入荷数
            string damRtNyuNum = clsCommon.FixB(RtNyuNum, RtNyuNumLen);
            buf = Encd.GetBytes(damRtNyuNum);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtNyuNumLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtNyuNumLen);
            RtNyuNum = damRtNyuNum;
            stpost += RtNyuNumLen;

            //仕入明細通番
            string damRtSirRowSeq = clsCommon.FixB(RtSirRowSeq, RtSirRowSeqLen);
            buf = Encd.GetBytes(damRtSirRowSeq);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtSirRowSeqLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtSirRowSeqLen);
            RtSirRowSeq = damRtSirRowSeq;
            stpost += RtSirRowSeqLen;

            //最終行処理
            if (intSetRow < 0)
            {
                //処理結果
                string damRetVal = RetVal.ToString().PadLeft(2, '0');
                buf = Encd.GetBytes(damRetVal);
                // -- ADD 2019/10/16 ------------------------------>>>
                Array.Resize(ref rcvval, rcvval.Length + RetValLen);
                // -- ADD 2019/10/16 ------------------------------<<<
                Buffer.BlockCopy(buf, 0, rcvval, stpost, RetValLen);
                RetVal = damRetVal;
                stpost += RetValLen;

                buf = Encd.GetBytes(clsBtConst.HT_MSG_CRLF);
                Array.Resize(ref rcvval, rcvval.Length + clsBtConst.HT_MSG_CRLF_LEN);
                Buffer.BlockCopy(buf, 0, rcvval, stpost, clsBtConst.HT_MSG_CRLF_LEN);
                stpost += clsBtConst.HT_MSG_CRLF_LEN;
            }
        }

#endregion

#region "関数"

#endregion

    }
}
