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
// 作 成 日  2017/08/01  修正内容 : 新規作成
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
    /// public class name:   clsIdoSlipInfo
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
    class clsIdoSlipInfo
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
        /// <summary>伝票番号                               文字型(9)</summary>
        public string SlipNo
        {
            get
            { return _slipno; }
            set
            { _slipno = value; }
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

        private string _rtslipno = null;
        /// <summary>伝票番号                               文字型(9)</summary>
        public string RtSlipNo
        {
            get
            { return _rtslipno; }
            set
            { _rtslipno = value; }
        }
        private string _rtsliprow = null;
        /// <summary>行番号                                 数値型(4)</summary>
        public string RtSlipRow
        {
            get
            { return _rtsliprow; }
            set
            { _rtsliprow = value; }
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
        private string _rttyoseisu = null;
        /// <summary>調整数                                 数値型(11(8.2))</summary>
        public string RtTyoseiSu
        {
            get
            { return _rttyoseisu; }
            set
            { _rttyoseisu = value; }
        }
        private string _rtfrsokocd = null;
        /// <summary>移動元倉庫コード                       文字型(4)</summary>
        public string RtFrSokoCd
        {
            get
            { return _rtfrsokocd; }
            set
            { _rtfrsokocd = value; }
        }
        private string _rtfrsokonm = null;
        /// <summary>移動元倉庫名称                       　文字型(40)</summary>
        public string RtFrSokoNm
        {
            get
            { return _rtfrsokonm; }
            set
            { _rtfrsokonm = value; }
        }
        private string _rttosokocd = null;
        /// <summary>移動先倉庫コード                       文字型(4)</summary>
        public string RtToSokoCd
        {
            get
            { return _rttosokocd; }
            set
            { _rttosokocd = value; }
        }
        private string _rttosokonm = null;
        /// <summary>移動先倉庫名称                       　文字型(40)</summary>
        public string RtToSokoNm
        {
            get
            { return _rttosokonm; }
            set
            { _rttosokonm = value; }
        }
        private string _rtfrtanano = null;
        /// <summary>移動元棚番                             文字型(8)</summary>
        public string RtFrTanaNo
        {
            get
            { return _rtfrtanano; }
            set
            { _rtfrtanano = value; }
        }
        private string _rttotanano = null;
        /// <summary>移動先棚番                             文字型(8)</summary>
        public string RtToTanaNo
        {
            get
            { return _rttotanano; }
            set
            { _rttotanano = value; }
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
        private string _rtcheckstus = null;
        /// <summary>検品ステータス                         数値型(4)</summary>
        public string RtCheckStus
        {
            get
            { return _rtcheckstus; }
            set
            { _rtcheckstus = value; }
        }
        private string _rtcheckkbn = null;
        /// <summary>検品区分                               数値型(2)</summary>
        public string RtCheckKbn
        {
            get
            { return _rtcheckkbn; }
            set
            { _rtcheckkbn = value; }
        }
        private string _rtchecknum = null;
        /// <summary>検品数                                 数値型(11(8.2))</summary>
        public string RtCheckNum
        {
            get
            { return _rtchecknum; }
            set
            { _rtchecknum = value; }
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
        /// <summary>伝票番号長                             文字型(9)</summary>
        public Int32 SlipNoLen
        {
            get
            { return _slipnolen; }
            set
            { _slipnolen = value; }
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

        private Int32 _rtslipnolen = 0;
        /// <summary>伝票番号                               文字型(9)</summary>
        public Int32 RtSlipNoLen
        {
            get
            { return _rtslipnolen; }
            set
            { _rtslipnolen = value; }
        }
        private Int32 _rtsliprowlen = 0;
        /// <summary>行番号                                 数値型(4)</summary>
        public Int32 RtSlipRowLen
        {
            get
            { return _rtsliprowlen; }
            set
            { _rtsliprowlen = value; }
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
        private Int32 _rttyoseisulen = 0;
        /// <summary>調整数                                 数値型(11(8.2))</summary>
        public Int32 RtTyoseiSuLen
        {
            get
            { return _rttyoseisulen; }
            set
            { _rttyoseisulen = value; }
        }
        private Int32 _rtfrsokocdlen = 0;
        /// <summary>移動元倉庫コード                       文字型(4)</summary>
        public Int32 RtFrSokoCdLen
        {
            get
            { return _rtfrsokocdlen; }
            set
            { _rtfrsokocdlen = value; }
        }
        private Int32 _rtfrsokonmlen = 0;
        /// <summary>移動元倉庫名称                       　文字型(40)</summary>
        public Int32 RtFrSokoNmLen
        {
            get
            { return _rtfrsokonmlen; }
            set
            { _rtfrsokonmlen = value; }
        }
        private Int32 _rttosokocdlen = 0;
        /// <summary>移動先倉庫コード                       文字型(4)</summary>
        public Int32 RtToSokoCdLen
        {
            get
            { return _rttosokocdlen; }
            set
            { _rttosokocdlen = value; }
        }
        private Int32 _rttosokonmlen = 0;
        /// <summary>移動先倉庫名称                       　文字型(40)</summary>
        public Int32 RtToSokoNmLen
        {
            get
            { return _rttosokonmlen; }
            set
            { _rttosokonmlen = value; }
        }
        private Int32 _rtfrtananolen = 0;
        /// <summary>移動元棚番                             文字型(8)</summary>
        public Int32 RtFrTanaNoLen
        {
            get
            { return _rtfrtananolen; }
            set
            { _rtfrtananolen = value; }
        }
        private Int32 _rttotananolen = 0;
        /// <summary>移動先棚番                             文字型(8)</summary>
        public Int32 RtToTanaNoLen
        {
            get
            { return _rttotananolen; }
            set
            { _rttotananolen = value; }
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
        private Int32 _rtcheckstuslen = 0;
        /// <summary>検品ステータス                         数値型(4)</summary>
        public Int32 RtCheckStusLen
        {
            get
            { return _rtcheckstuslen; }
            set
            { _rtcheckstuslen = value; }
        }
        private Int32 _rtcheckkbnlen = 0;
        /// <summary>検品区分                               数値型(2)</summary>
        public Int32 RtCheckKbnLen
        {
            get
            { return _rtcheckkbnlen; }
            set
            { _rtcheckkbnlen = value; }
        }
        private Int32 _rtchecknumlen = 0;
        /// <summary>検品数                                 数値型(11(8.2))</summary>
        public Int32 RtCheckNumLen
        {
            get
            { return _rtchecknumlen; }
            set
            { _rtchecknumlen = value; }
        }

        private Int32 _retvallen = 0;
        /// <summary>処理結果(ステータス)長    数値型(2)</summary>
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
        public clsIdoSlipInfo()
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
            //伝票番号
            SlipNo = string.Empty;
            SlipNoLen = 9;

            //セットした行数
            SetRow = string.Empty;
            SetRowLen = 4;

            //伝票番号
            RtSlipNo = String.Empty;
            RtSlipNoLen = 9;
            //行番号
            RtSlipRow = String.Empty;
            RtSlipRowLen = 4;
            //メーカーコード
            RtMakerCd = String.Empty;
            RtMakerCdLen = 6;
            //商品番号
            RtSyoCd = String.Empty;
            RtSyoCdLen = 40;
            //商品名称
            RtSyoNm = String.Empty;
            RtSyoNmLen = 100;
            //調整数
            RtTyoseiSu = String.Empty;
            RtTyoseiSuLen = 11;
            //移動元倉庫コード
            RtFrSokoCd = String.Empty;
            RtFrSokoCdLen = 4;
            //移動元倉庫名称
            RtFrSokoNm = String.Empty;
            RtFrSokoNmLen = 40;
            //移動先倉庫コード
            RtToSokoCd = String.Empty;
            RtToSokoCdLen = 4;
            //移動先倉庫名称
            RtToSokoNm = String.Empty;
            RtToSokoNmLen = 40;
            //移動元棚番
            RtFrTanaNo = String.Empty;
            RtFrTanaNoLen = 8;
            //移動先棚番
            RtToTanaNo = String.Empty;
            RtToTanaNoLen = 8;
            //商品バーコード
            RtBarCode = String.Empty;
            RtBarCodeLen = 128;
            //検品ステータス
            RtCheckStus = String.Empty;
            RtCheckStusLen = 4;
            //検品区分
            RtCheckKbn = String.Empty;
            RtCheckKbnLen = 2;
            //検品数
            RtCheckNum = String.Empty;
            RtCheckNumLen = 11;

            //処理結果
            RetVal = string.Empty;
            RetValLen = 2;

            //電文長
            DenbunLen = SetRowLen + RtSlipNoLen + RtSlipRowLen + RtMakerCdLen + RtSyoCdLen + RtSyoNmLen;
            DenbunLen += RtTyoseiSuLen + RtFrSokoCdLen + RtFrSokoNmLen + RtToSokoCdLen + RtToSokoNmLen;
            DenbunLen += RtFrTanaNoLen + RtToTanaNoLen + RtBarCodeLen + RtCheckStusLen + RtCheckKbnLen + RtCheckNumLen;
        }

#endregion

#region "メソッド "
        /// <summary>
        /// 受信データ初期化
        /// </summary>
        /// <remarks></remarks>
        public void IniOutArg()
        {
            //セットした行数
            SetRow = string.Empty;

            //伝票番号
            RtSlipNo = String.Empty;
            //行番号
            RtSlipRow = String.Empty;
            //メーカーコード
            RtMakerCd = String.Empty;
            //商品番号
            RtSyoCd = String.Empty;
            //商品名称
            RtSyoNm = String.Empty;
            //調整数
            RtTyoseiSu = String.Empty;
            //移動元倉庫コード
            RtFrSokoCd = String.Empty;
            //移動元倉庫名称
            RtFrSokoNm = String.Empty;
            //移動先倉庫コード
            RtToSokoCd = String.Empty;
            //移動先倉庫名称
            RtToSokoNm = String.Empty;
            //移動元棚番
            RtFrTanaNo = String.Empty;
            //移動先棚番
            RtToTanaNo = String.Empty;
            //商品バーコード
            RtBarCode = String.Empty;
            //検品ステータス
            RtCheckStus = String.Empty;
            //検品区分
            RtCheckKbn = String.Empty;
            //検品数
            RtCheckNum = String.Empty;

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

            //伝票番号
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
                damSetRow = clsCommon.FixB(System.Math.Abs(intSetRow).ToString(), SetRowLen);
                buf = Encd.GetBytes(damSetRow);
                // -- ADD 2019/10/16 ------------------------------>>>
                Array.Resize(ref rcvval, rcvval.Length + SetRowLen);
                // -- ADD 2019/10/16 ------------------------------<<<
                Buffer.BlockCopy(buf, 0, rcvval, stpost, SetRowLen);
                SetRow = damSetRow;
                stpost += SetRowLen;
            }

            //伝票番号
            string damRtSlipNo = clsCommon.FixB(RtSlipNo, RtSlipNoLen);
            buf = Encd.GetBytes(damRtSlipNo);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtSlipNoLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtSlipNoLen);
            RtSlipNo = damRtSlipNo;
            stpost += RtSlipNoLen;

            //行番号
            string damRtSlipRow = clsCommon.FixB(RtSlipRow, RtSlipRowLen);
            buf = Encd.GetBytes(damRtSlipRow);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtSlipRowLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtSlipRowLen);
            RtSlipRow = damRtSlipRow;
            stpost += RtSlipRowLen;

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

            //調整数
            string damRtTyoseiSu = clsCommon.FixB(RtTyoseiSu, RtTyoseiSuLen);
            buf = Encd.GetBytes(damRtTyoseiSu);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtTyoseiSuLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtTyoseiSuLen);
            RtTyoseiSu = damRtTyoseiSu;
            stpost += RtTyoseiSuLen;

            //移動元倉庫コード
            string damRtFrSokoCd = clsCommon.FixB(RtFrSokoCd, RtFrSokoCdLen);
            buf = Encd.GetBytes(damRtFrSokoCd);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtFrSokoCdLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtFrSokoCdLen);
            RtFrSokoCd = damRtFrSokoCd;
            stpost += RtFrSokoCdLen;

            //移動元倉庫名称
            string damRtFrSokoNm = clsCommon.FixB(RtFrSokoNm, RtFrSokoNmLen);
            buf = Encd.GetBytes(damRtFrSokoNm);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtFrSokoNmLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtFrSokoNmLen);
            RtFrSokoNm = damRtFrSokoNm;
            stpost += RtFrSokoNmLen;

            //移動先倉庫コード
            string damRtToSokoCd = clsCommon.FixB(RtToSokoCd, RtToSokoCdLen);
            buf = Encd.GetBytes(damRtToSokoCd);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtToSokoCdLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtToSokoCdLen);
            RtToSokoCd = damRtToSokoCd;
            stpost += RtToSokoCdLen;

            //移動先倉庫名称
            string damRtToSokoNm = clsCommon.FixB(RtToSokoNm, RtToSokoNmLen);
            buf = Encd.GetBytes(damRtToSokoNm);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtToSokoNmLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtToSokoNmLen);
            RtToSokoNm = damRtToSokoNm;
            stpost += RtToSokoNmLen;

            //移動元棚番
            string damRtFrTanaNo = clsCommon.FixB(RtFrTanaNo, RtFrTanaNoLen);
            buf = Encd.GetBytes(damRtFrTanaNo);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtFrTanaNoLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtFrTanaNoLen);
            RtFrTanaNo = damRtFrTanaNo;
            stpost += RtFrTanaNoLen;

            //移動先棚番
            string damRtToTanaNo = clsCommon.FixB(RtToTanaNo, RtToTanaNoLen);
            buf = Encd.GetBytes(damRtToTanaNo);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtToTanaNoLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtToTanaNoLen);
            RtToTanaNo = damRtToTanaNo;
            stpost += RtToTanaNoLen;

            //商品バーコード
            string damRtBarCode = clsCommon.FixB(RtBarCode, RtBarCodeLen);
            buf = Encd.GetBytes(damRtBarCode);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtBarCodeLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtBarCodeLen);
            RtBarCode = damRtBarCode;
            stpost += RtBarCodeLen;

            //検品ステータス
            string damRtCheckStus = clsCommon.FixB(RtCheckStus, RtCheckStusLen);
            buf = Encd.GetBytes(damRtCheckStus);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtCheckStusLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtCheckStusLen);
            RtCheckStus = damRtCheckStus;
            stpost += RtCheckStusLen;

            //検品区分
            string damRtCheckKbn = clsCommon.FixB(RtCheckKbn, RtCheckKbnLen);
            buf = Encd.GetBytes(damRtCheckKbn);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtCheckKbnLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtCheckKbnLen);
            RtCheckKbn = damRtCheckKbn;
            stpost += RtCheckKbnLen;

            //検品数
            string damRtCheckNum = clsCommon.FixB(RtCheckNum, RtCheckNumLen);
            buf = Encd.GetBytes(damRtCheckNum);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtCheckNumLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtCheckNumLen);
            RtCheckNum = damRtCheckNum;
            stpost += RtCheckNumLen;

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
