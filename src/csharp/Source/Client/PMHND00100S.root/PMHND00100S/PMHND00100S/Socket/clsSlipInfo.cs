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
// 管理番号  11570136-00 作成担当 : 白厩  翔也
// 修 正 日  2019/10/24  修正内容 : ６次対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PMHND00100S.Common;

namespace PMHND00100S.Socket
{
    /// public class name:   clsSlipInfo
    /// <summary>
    ///                      ソケット通信用クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   伝票情報取得用クラス</br>
    /// <br>Programmer       :   佐藤　智之</br>
    /// <br>Date             :   2017/07/01</br>
    /// <br></br>
    /// <br></br>
    /// <br>Update Note      :   </br>
    /// <br></br>
    /// </remarks>
    class clsSlipInfo
    {

#region "プロパティ"
        private string _soksyorikbn = null;
        /// <summary>ソケット処理区分          数値型(4)</summary>
        public string SokSyoriKbn
        {
            get
            { return _soksyorikbn; }
            set
            { _soksyorikbn = value; }
        }

        private string _htname = null;
        /// <summary>コンピュータ名            文字型(20)</summary>
        public string HtName
        {
            get
            { return _htname; }
            set
            { _htname = value; }
        }
        private string _empcd = null;
        /// <summary>従業員コード              文字型(9)</summary>
        public string EmpCd
        {
            get
            { return _empcd; }
            set
            { _empcd = value; }
        }
        private string _procdiv = null;
        /// <summary>処理区分                   数値型(2)</summary>
        public string ProcDiv
        {
            get
            { return _procdiv; }
            set
            { _procdiv = value; }
        }
        private string _slipno = null;
        /// <summary>伝票番号                   文字型(9)</summary>
        public string SlipNo
        {
            get
            { return _slipno; }
            set
            { _slipno = value; }
        }

        private string _tokuinm = null;
        /// <summary>得意先略称                 文字型(40)</summary>
        public string TokuiNm
        {
            get
            { return _tokuinm; }
            set
            { _tokuinm = value; }
        }

        private string _setrow = null;
        /// <summary>セットした行数             数値型(4)</summary>
        public string SetRow
        {
            get
            { return _setrow; }
            set
            { _setrow = value; }
        }

        private string _sktrtslipno = null;
        /// <summary>伝票番号                   文字型(9)</summary>
        public string SktRtSlipNo
        {
            get
            { return _sktrtslipno; }
            set
            { _sktrtslipno = value; }
        }
        private string _sktrtsliprow = null;
        /// <summary>行番号                     数値型(4)</summary>
        public string SktRTSlipRow
        {
            get
            { return _sktrtsliprow; }
            set
            { _sktrtsliprow = value; }
        }
        private string _stkmakercd = null;
        /// <summary>メーカーコード             数値型(6)</summary>
        public string SktMekerCd
        {
            get
            { return _stkmakercd; }
            set
            { _stkmakercd = value; }
        }
        private string _sktshoucd = null;
        /// <summary>商品番号                   文字型(40)</summary>
        public string SktShouCd
        {
            get
            { return _sktshoucd; }
            set
            { _sktshoucd = value; }
        }
        private string _sktshounm = null;
        /// <summary>品名カナ                   文字型(100)</summary>
        public string SktShouNm
        {
            get
            { return _sktshounm; }
            set
            { _sktshounm = value; }
        }
        private string _sktshukonum = null;
        /// <summary>出荷数                     数値型(10(7.2))</summary>
        public string SktShukoNum
        {
            get
            { return _sktshukonum; }
            set
            { _sktshukonum = value; }
        }
        private string _skttanano = null;
        /// <summary>棚番                       文字型(8)</summary>
        public string SktTanaNo
        {
            get
            { return _skttanano; }
            set
            { _skttanano = value; }
        }
        private string _sktsokocd = null;
        /// <summary>倉庫コード                 文字型(4)</summary>
        public string SktSokoCd
        {
            get
            { return _sktsokocd; }
            set
            { _sktsokocd = value; }
        }
        private string _sktutorikbn = null;
        /// <summary>売上在庫取寄せ区分         数値型(2)</summary>
        public string SktUToriKbn
        {
            get
            { return _sktutorikbn; }
            set
            { _sktutorikbn = value; }
        }
        private string _skttokshoucd = null;
        /// <summary>相手先商品コード(JAN等)    文字型(128)</summary>
        public string SktTokShouCd
        {
            get
            { return _skttokshoucd; }
            set
            { _skttokshoucd = value; }
        }
        private string _sktcheckstus = null;
        /// <summary>検品ステータス             数値型(4)</summary>
        public string SktCheckStus
        {
            get
            { return _sktcheckstus; }
            set
            { _sktcheckstus = value; }
        }
        private string _sktchecknum = null;
        /// <summary>検品数                     数値型(10(7.2))</summary>
        public string SktCheckNum
        {
            get
            { return _sktchecknum; }
            set
            { _sktchecknum = value; }
        }
        private string _sktcheckkbn = null;
        /// <summary>検品区分                   数値型(2)</summary>
        public string SktCheckKbn
        {
            get
            { return _sktcheckkbn; }
            set
            { _sktcheckkbn = value; }
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
        /// <summary>ソケット処理区分長        数値型(4)</summary>
        public Int32 SokSyoriKbnLen
        {
            get
            { return _soksyorikbnlen; }
            set
            { _soksyorikbnlen = value; }
        }

        private Int32 _htnamelen = 0;
        /// <summary>コンピュータ名長          文字型(20)</summary>
        public Int32 HtNameLen
        {
            get
            { return _htnamelen; }
            set
            { _htnamelen = value; }
        }
        private Int32 _empcdlen = 0;
        /// <summary>従業員コード長            文字型(9)</summary>
        public Int32 EmpCdLen
        {
            get
            { return _empcdlen; }
            set
            { _empcdlen = value; }
        }
        private Int32 _procdivlen = 0;
        /// <summary>処理区分長                 数値型(2)</summary>
        public Int32 ProcDivLen
        {
            get
            { return _procdivlen; }
            set
            { _procdivlen = value; }
        }
        private Int32 _slipnolen = 0;
        /// <summary>伝票番号長                 文字型(9)</summary>
        public Int32 SlipNoLen
        {
            get
            { return _slipnolen; }
            set
            { _slipnolen = value; }
        }

        private Int32 _tokuinmlen = 0;
        /// <summary>得意先略称長               文字型(40)</summary>
        public Int32 TokuiNmLen
        {
            get
            { return _tokuinmlen; }
            set
            { _tokuinmlen = value; }
        }

        private Int32 _setrowlen = 0;
        /// <summary>セットした行数長           数値型(4)</summary>
        public Int32 SetRowLen
        {
            get
            { return _setrowlen; }
            set
            { _setrowlen = value; }
        }

        private Int32 _sktrtslipnolen = 0;
        /// <summary>伝票番号長                 文字型(9)</summary>
        public Int32 SktRtSlipNoLen
        {
            get
            { return _sktrtslipnolen; }
            set
            { _sktrtslipnolen = value; }
        }
        private Int32 _sktrTsliprowlen = 0;
        /// <summary>行番号長                   数値型(4)</summary>
        public Int32 SktRTSlipRowLen
        {
            get
            { return _sktrTsliprowlen; }
            set
            { _sktrTsliprowlen = value; }
        }
        private Int32 _sktmekercdlen = 0;
        /// <summary>メーカーコード長           数値型(6)</summary>
        public Int32 SktMekerCdLen
        {
            get
            { return _sktmekercdlen; }
            set
            { _sktmekercdlen = value; }
        }
        private Int32 _sktshoucdlen = 0;
        /// <summary>商品番号長                 文字型(40)</summary>
        public Int32 SktShouCdLen
        {
            get
            { return _sktshoucdlen; }
            set
            { _sktshoucdlen = value; }
        }
        private Int32 _sktshounmlen = 0;
        /// <summary>品名カナ長                 文字型(100)</summary>
        public Int32 SktShouNmLen
        {
            get
            { return _sktshounmlen; }
            set
            { _sktshounmlen = value; }
        }
        private Int32 _sktdhukonumlen = 0;
        /// <summary>出荷数長                   数値型(10(7.2))</summary>
        public Int32 SktShukoNumLen
        {
            get
            { return _sktdhukonumlen; }
            set
            { _sktdhukonumlen = value; }
        }
        private Int32 _skttananolen = 0;
        /// <summary>棚番長                     文字型(8)</summary>
        public Int32 SktTanaNoLen
        {
            get
            { return _skttananolen; }
            set
            { _skttananolen = value; }
        }
        private Int32 _sktsokocdlen = 0;
        /// <summary>倉庫コード長               文字型(4)</summary>
        public Int32 SktSokoCdLen
        {
            get
            { return _sktsokocdlen; }
            set
            { _sktsokocdlen = value; }
        }
        private Int32 _sktutorikbnlen = 0;
        /// <summary>売上在庫取寄せ区分長       数値型(2)</summary>
        public Int32 SktUToriKbnLen
        {
            get
            { return _sktutorikbnlen; }
            set
            { _sktutorikbnlen = value; }
        }
        private Int32 _skttokshoucdlen = 0;
        /// <summary>相手先商品コード(JAN等)長  文字型(128)</summary>
        public Int32 SktTokShouCdLen
        {
            get
            { return _skttokshoucdlen; }
            set
            { _skttokshoucdlen = value; }
        }
        private Int32 _sktcheckstuslen = 0;
        /// <summary>検品ステータス長           数値型(4)</summary>
        public Int32 SktCheckStusLen
        {
            get
            { return _sktcheckstuslen; }
            set
            { _sktcheckstuslen = value; }
        }
        private Int32 _sktchecknumlen = 0;
        /// <summary>検品数長                   数値型(10(7.2))</summary>
        public Int32 SktCheckNumLen
        {
            get
            { return _sktchecknumlen; }
            set
            { _sktchecknumlen = value; }
        }
        private Int32 _sktcheckkbnlen = 0;
        /// <summary>検品区分長                 数値型(2)</summary>
        public Int32 SktCheckKbnLen
        {
            get
            { return _sktcheckkbnlen; }
            set
            { _sktcheckkbnlen = value; }
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
        public clsSlipInfo()
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

            //得意先略称
            TokuiNm = string.Empty;
            TokuiNmLen = 40;
            //本処理でセットした行数
            SetRow = string.Empty;
            SetRowLen = 4;

            //伝票番号
            SktRtSlipNo = String.Empty;
            SktRtSlipNoLen = 9;
            //行番号
            SktRTSlipRow = String.Empty;
            SktRTSlipRowLen = 4;
            //メーカーコード
            SktMekerCd = String.Empty;
            SktMekerCdLen = 6;
            //商品番号
            SktShouCd = String.Empty;
            SktShouCdLen = 40;
            //品名カナ
            SktShouNm = String.Empty;
            SktShouNmLen = 100;
            //出庫数
            SktShukoNum = String.Empty;
            SktShukoNumLen = 10;
            //棚番
            SktTanaNo = String.Empty;
            SktTanaNoLen = 8;
            //倉庫コード
            SktSokoCd = String.Empty;
            SktSokoCdLen = 4;
            //売上在庫取寄せ区分
            SktUToriKbn = String.Empty;
            SktUToriKbnLen = 2;
            //相手先商品コード
            SktTokShouCd = String.Empty;
            SktTokShouCdLen = 128;
            //検品ステータス
            SktCheckStus = String.Empty;
            SktCheckStusLen = 4;
            //検品数
            SktCheckNum = String.Empty;
            SktCheckNumLen = 10;
            //検品区分
            SktCheckKbn = String.Empty;
            SktCheckKbnLen = 2;

            //処理結果
            RetVal = string.Empty;
            RetValLen = 2;

            //電文長
            DenbunLen = TokuiNmLen + SetRowLen + SktRtSlipNoLen + SktRTSlipRowLen + SktMekerCdLen + SktShouCdLen + SktShouNmLen;
            DenbunLen += SktShukoNumLen + SktTanaNoLen + SktSokoCdLen + SktUToriKbnLen + SktTokShouCdLen ;
            DenbunLen += SktCheckStusLen +SktCheckNumLen + SktCheckKbnLen;
        }

#endregion

#region "メソッド "
        /// <summary>
        /// 受信データ初期化
        /// </summary>
        /// <remarks></remarks>
        public void IniOutArg()
        {
            //得意先略称
            TokuiNm = string.Empty;

            //セットした行数
            SetRow = string.Empty;

            //伝票番号
            SktRtSlipNo = String.Empty;
            //行番号
            SktRTSlipRow = String.Empty;
            //メーカーコード
            SktMekerCd = String.Empty;
            //商品番号
            SktShouCd = String.Empty;
            //商品名
            SktShouNm = String.Empty;
            //出庫数
            SktShukoNum = String.Empty;
            //棚番
            SktTanaNo = String.Empty;
            //倉庫コード
            SktSokoCd = String.Empty;
            //売上在庫取寄せ区分
            SktUToriKbn = String.Empty;
            //相手先商品コード
            SktTokShouCd = String.Empty;
            //検品ステータス
            SktCheckStus = String.Empty;
            //検品数
            SktCheckNum = String.Empty;
            //検品区分
            SktCheckKbn = String.Empty;

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
            string damTokuiNm = clsCommon.FixB(TokuiNm, TokuiNmLen);

            //得意先略称
            if ((damTokuiNm.Trim() != string.Empty) || (intSetRow == -1))
            {
                buf = Encd.GetBytes(damTokuiNm);
                // -- ADD 2019/10/24 ------------------------------>>>
                Array.Resize(ref rcvval, rcvval.Length + TokuiNmLen);
                // -- ADD 2019/10/24 ------------------------------<<<
                Buffer.BlockCopy(buf, 0, rcvval, stpost, TokuiNmLen);
                TokuiNm = damTokuiNm;
                stpost += TokuiNmLen;

                damSetRow = clsCommon.FixB(System.Math.Abs(intSetRow).ToString(), SetRowLen);
                buf = Encd.GetBytes(damSetRow);
                // -- ADD 2019/10/24 ------------------------------>>>
                Array.Resize(ref rcvval, rcvval.Length + SetRowLen);
                // -- ADD 2019/10/24 ------------------------------<<<
                Buffer.BlockCopy(buf, 0, rcvval, stpost, SetRowLen);
                if (intSetRow > 0)
                {
                    SetRow = damSetRow;
                }
                // １行しか無い時は、SetRowへのセットはRetVal判定時に行う
                stpost += SetRowLen;
            }

            //伝票番号
            string damSktRtSlipNo = clsCommon.FixB(SktRtSlipNo, SktRtSlipNoLen);
            buf = Encd.GetBytes(damSktRtSlipNo);
            // -- ADD 2019/10/24 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + SktRtSlipNoLen);
            // -- ADD 2019/10/24 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, SktRtSlipNoLen);
            SktRtSlipNo = damSktRtSlipNo;
            stpost += SktRtSlipNoLen;

            //行番号
            string damSktRTSlipRow = clsCommon.FixB(SktRTSlipRow, SktRTSlipRowLen);
            buf = Encd.GetBytes(damSktRTSlipRow);
            // -- ADD 2019/10/24 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + SktRTSlipRowLen);
            // -- ADD 2019/10/24 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, SktRTSlipRowLen);
            SktRTSlipRow = damSktRTSlipRow;
            stpost += SktRTSlipRowLen;

            //メーカーコード
            string damSktMekerCd = clsCommon.FixB(SktMekerCd, SktMekerCdLen);
            buf = Encd.GetBytes(damSktMekerCd);
            // -- ADD 2019/10/24 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + SktMekerCdLen);
            // -- ADD 2019/10/24 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, SktMekerCdLen);
            SktMekerCd = damSktMekerCd;
            stpost += SktMekerCdLen;

            //商品番号
            string damSktShouCd = clsCommon.FixB(SktShouCd, SktShouCdLen);
            buf = Encd.GetBytes(damSktShouCd);
            // -- ADD 2019/10/24 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + SktShouCdLen);
            // -- ADD 2019/10/24 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, SktShouCdLen);
            SktShouCd = damSktShouCd;
            stpost += SktShouCdLen;

            //品名カナ
            string damSktShouNm = clsCommon.FixB(SktShouNm, SktShouNmLen);
            buf = Encd.GetBytes(damSktShouNm);
            // -- ADD 2019/10/24 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + SktShouNmLen);
            // -- ADD 2019/10/24 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, SktShouNmLen);
            SktShouNm = damSktShouNm;
            stpost += SktShouNmLen;

            //出庫数
            string damSktShukoNum = clsCommon.FixB(SktShukoNum, SktShukoNumLen);
            buf = Encd.GetBytes(damSktShukoNum);
            // -- ADD 2019/10/24 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + SktShukoNumLen);
            // -- ADD 2019/10/24 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, SktShukoNumLen);
            SktShukoNum = damSktShukoNum;
            stpost += SktShukoNumLen;

            //棚番
            string damSktTanaNo = clsCommon.FixB(SktTanaNo, SktTanaNoLen);
            buf = Encd.GetBytes(damSktTanaNo);
            // -- ADD 2019/10/24 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + SktTanaNoLen);
            // -- ADD 2019/10/24 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, SktTanaNoLen);
            SktTanaNo = damSktTanaNo;
            stpost += SktTanaNoLen;

            //倉庫コード
            string damSktSokoCd = clsCommon.FixB(SktSokoCd, SktSokoCdLen);
            buf = Encd.GetBytes(damSktSokoCd);
            // -- ADD 2019/10/24 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + SktSokoCdLen);
            // -- ADD 2019/10/24 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, SktSokoCdLen);
            SktSokoCd = damSktSokoCd;
            stpost += SktSokoCdLen;

            //売上在庫取寄せ区分
            string damSktUToriKbn = clsCommon.FixB(SktUToriKbn, SktUToriKbnLen);
            buf = Encd.GetBytes(damSktUToriKbn);
            // -- ADD 2019/10/24 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + SktUToriKbnLen);
            // -- ADD 2019/10/24 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, SktUToriKbnLen);
            SktUToriKbn = damSktUToriKbn;
            stpost += SktUToriKbnLen;

            //相手先商品コード
            string damSktTokShouCd = clsCommon.FixB(SktTokShouCd, SktTokShouCdLen);
            buf = Encd.GetBytes(damSktTokShouCd);
            // -- ADD 2019/10/24 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + SktTokShouCdLen);
            // -- ADD 2019/10/24 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, SktTokShouCdLen);
            SktTokShouCd = damSktTokShouCd;
            stpost += SktTokShouCdLen;

            //検品ステータス
            string damSktCheckStus = clsCommon.FixB(SktCheckStus, SktCheckStusLen);
            buf = Encd.GetBytes(damSktCheckStus);
            // -- ADD 2019/10/24 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + SktCheckStusLen);
            // -- ADD 2019/10/24 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, SktCheckStusLen);
            SktCheckStus = damSktCheckStus;
            stpost += SktCheckStusLen;

            //検品数
            string damSktCheckNum = clsCommon.FixB(SktCheckNum, SktCheckNumLen);
            buf = Encd.GetBytes(damSktCheckNum);
            // -- ADD 2019/10/24 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + SktCheckNumLen);
            // -- ADD 2019/10/24 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, SktCheckNumLen);
            SktCheckNum = damSktCheckNum;
            stpost += SktCheckNumLen;

            //検品区分
            string damSktCheckKbn = clsCommon.FixB(SktCheckKbn, SktCheckKbnLen);
            buf = Encd.GetBytes(damSktCheckKbn);
            // -- ADD 2019/10/24 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + SktCheckKbnLen);
            // -- ADD 2019/10/24 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, SktCheckKbnLen);
            SktCheckKbn = damSktCheckKbn;
            stpost += SktCheckKbnLen;

            //最終行処理
            if (intSetRow < 0)
            {
                //検品区分
                string damRetVal = RetVal.ToString().PadLeft(2, '0');
                buf = Encd.GetBytes(damRetVal);
                // -- ADD 2019/10/24 ------------------------------>>>
                Array.Resize(ref rcvval, rcvval.Length + RetValLen);
                // -- ADD 2019/10/24 ------------------------------<<<
                Buffer.BlockCopy(buf, 0, rcvval, stpost, RetValLen);
                RetVal = damRetVal;
                if (intSetRow < 0)
                {
                    SetRow = damSetRow;
                }
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
