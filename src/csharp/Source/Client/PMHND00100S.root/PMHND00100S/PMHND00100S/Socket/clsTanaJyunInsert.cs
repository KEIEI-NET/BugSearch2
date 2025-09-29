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
    /// public class name:   clsTanaJyunInsert
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
    class clsTanaJyunInsert
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
        private string _sokocd = null;
        /// <summary>倉庫コード                             数値型(4)</summary>
        public string SokoCd
        {
            get
            { return _sokocd; }
            set
            { _sokocd = value; }
        }
        private string _makercd = null;
        /// <summary>メーカーコード                         数値型(6)</summary>
        public string MakerCd
        {
            get
            { return _makercd; }
            set
            { _makercd = value; }
        }
        private string _syocd = null;
        /// <summary>商品番号                               文字型(40)</summary>
        public string SyoCd
        {
            get
            { return _syocd; }
            set
            { _syocd = value; }
        }
        private string _tanano = null;
        /// <summary>棚番                                   文字型(8)</summary>
        public string TanaNo
        {
            get
            { return _tanano; }
            set
            { _tanano = value; }
        }
        private string _tananum = null;
        /// <summary>棚卸数                                 数値型(11(8.2))</summary>
        public string TanaNum
        {
            get
            { return _tananum; }
            set
            { _tananum = value; }
        }
        private string _tanaseq = null;
        /// <summary>循環棚卸通番                           数値型(9)</summary>
        public string TanaSeq
        {
            get
            { return _tanaseq; }
            set
            { _tanaseq = value; }
        }
        private string _biko = null;
        /// <summary>備考                                   文字型(40)</summary>
        public string Biko
        {
            get
            { return _biko; }
            set
            { _biko = value; }
        }
        private string _firstflg = null;
        /// <summary>初回フラグ                             数値型(1))</summary>
        public string FirstFlg
        {
            get
            { return _firstflg; }
            set
            { _firstflg = value; }
        }

        private string _rttanaseq = null;
        /// <summary>棚卸通番                               数値型(9)</summary>
        public string RtTanaSeq
        {
            get
            { return _rttanaseq; }
            set
            { _rttanaseq = value; }
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
        /// <summary>ソケット処理区分                       数値型(4)</summary>
        public Int32 SokSyoriKbnLen
        {
            get
            { return _soksyorikbnlen; }
            set
            { _soksyorikbnlen = value; }
        }

        private Int32 _htnamelen = 0;
        /// <summary>コンピュータ名                         文字型(20)</summary>
        public Int32 HtNameLen
        {
            get
            { return _htnamelen; }
            set
            { _htnamelen = value; }
        }
        private Int32 _empcdlen = 0;
        /// <summary>従業員コード                           文字型(9)</summary>
        public Int32 EmpCdLen
        {
            get
            { return _empcdlen; }
            set
            { _empcdlen = value; }
        }
        private Int32 _sokocdlen = 0;
        /// <summary>倉庫コード                             数値型(4)</summary>
        public Int32 SokoCdLen
        {
            get
            { return _sokocdlen; }
            set
            { _sokocdlen = value; }
        }
        private Int32 _makercdlen = 0;
        /// <summary>メーカーコード                         数値型(6)</summary>
        public Int32 MakerCdLen
        {
            get
            { return _makercdlen; }
            set
            { _makercdlen = value; }
        }
        private Int32 _syocdlen = 0;
        /// <summary>商品番号                               文字型(40)</summary>
        public Int32 SyoCdLen
        {
            get
            { return _syocdlen; }
            set
            { _syocdlen = value; }
        }
        private Int32 _tananolen = 0;
        /// <summary>棚番                                   文字型(8)</summary>
        public Int32 TanaNoLen
        {
            get
            { return _tananolen; }
            set
            { _tananolen = value; }
        }
        private Int32 _tananumlen = 0;
        /// <summary>棚卸数                                 数値型(11(8.2))</summary>
        public Int32 TanaNumLen
        {
            get
            { return _tananumlen; }
            set
            { _tananumlen = value; }
        }
        private Int32 _tanaseqlen = 0;
        /// <summary>循環棚卸通番                           数値型(9)</summary>
        public Int32 TanaSeqLen
        {
            get
            { return _tanaseqlen; }
            set
            { _tanaseqlen = value; }
        }
        private Int32 _bikolen = 0;
        /// <summary>備考                                   文字型(40)</summary>
        public Int32 BikoLen
        {
            get
            { return _bikolen; }
            set
            { _bikolen = value; }
        }
        private Int32 _firstflglen = 0;
        /// <summary>初回フラグ                             数値型(1))</summary>
        public Int32 FirstFlgLen
        {
            get
            { return _firstflglen; }
            set
            { _firstflglen = value; }
        }

        private Int32 _rttanaseqlen = 0;
        /// <summary>棚卸通番                               数値型(9)</summary>
        public Int32 RtTanaSeqLen
        {
            get
            { return _rttanaseqlen; }
            set
            { _rttanaseqlen = value; }
        }
        private Int32 _retvallen = 0;
        /// <summary>処理結果(ステータス)                   数値型(2)</summary>
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
        public clsTanaJyunInsert()
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
            //倉庫コード
            SokoCd = string.Empty;
            SokoCdLen = 4;
            //メーカーコード
            MakerCd = string.Empty;
            MakerCdLen = 6;
            //商品番号
            SyoCd = string.Empty;
            SyoCdLen = 40;
            //棚番
            TanaNo = string.Empty;
            TanaNoLen = 8;
            //棚卸数
            TanaNum = string.Empty;
            TanaNumLen = 11;
            //棚卸連番
            TanaSeq = string.Empty;
            TanaSeqLen = 9;
            //備考
            Biko = string.Empty;
            BikoLen = 40;
            //初回フラグ
            FirstFlg = string.Empty;
            FirstFlgLen = 1;

            //棚卸通番
            RtTanaSeq = string.Empty;
            RtTanaSeqLen = 9;
            //処理結果
            RetVal = string.Empty;
            RetValLen = 2;

            //電文長
            DenbunLen = HtNameLen + EmpCdLen + SokoCdLen + MakerCdLen + SyoCdLen + SyoCdLen;
            DenbunLen += TanaNoLen + TanaNumLen + TanaSeqLen + BikoLen + FirstFlgLen;
        }

#endregion

#region "メソッド "
        /// <summary>
        /// 受信データ初期化
        /// </summary>
        /// <remarks></remarks>
        public void IniOutArg()
        {
            //棚卸通番
            RtTanaSeq = string.Empty;

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
            Int32 StSize = 0;
            Int32 StPost = 0;
            StPost = 0;

            //ソケット処理区分
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

            //倉庫コード
            StSize = SokoCdLen;
            SokoCd = Encd.GetString(ArgVal, StPost, StSize);
            StPost += SokoCdLen;

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
            StPost += TanaNoLen;

            //棚卸数
            StSize = TanaNumLen;
            TanaNum = Encd.GetString(ArgVal, StPost, StSize);
            StPost += TanaNumLen;

            //棚卸連番
            StSize = TanaSeqLen;
            TanaSeq = Encd.GetString(ArgVal, StPost, StSize);
            StPost += TanaSeqLen;

            //備考
            StSize = BikoLen;
            Biko = Encd.GetString(ArgVal, StPost, StSize);
            StPost += BikoLen;

            //初回フラグ
            StSize = FirstFlgLen;
            FirstFlg = Encd.GetString(ArgVal, StPost, StSize);
            StPost += FirstFlgLen;

            return 0;
        }

        /// <summary>
        /// 受信データ取得（HT間通信プログラム用）
        /// </summary>
        /// <param name="rcvval"></param>
        /// <param name="stpost"></param>
        /// <remarks>ハンディプログラムでの受信バッファにあわせて5000Byte以下である必要があります</remarks>
        public void RelayGetOutArg(ref byte[] rcvval, ref Int32 stpost)
        {
            byte[] buf = null;

            //棚卸通番
            string damRtTanaSeq = clsCommon.FixB(RtTanaSeq, RtTanaSeqLen);
            buf = Encd.GetBytes(damRtTanaSeq);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtTanaSeqLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtTanaSeqLen);
            RtTanaSeq = damRtTanaSeq;
            stpost += RtTanaSeqLen;

            //処理結果
            string damRetVal = RetVal.ToString().PadLeft(2, '0');
            buf = Encd.GetBytes(damRetVal);
            Array.Resize(ref rcvval, rcvval.Length + RetValLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RetValLen);
            RetVal = damRetVal;

            buf = Encd.GetBytes(clsBtConst.HT_MSG_CRLF);
            stpost += RetValLen;
            Array.Resize(ref rcvval, rcvval.Length + clsBtConst.HT_MSG_CRLF_LEN);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, clsBtConst.HT_MSG_CRLF_LEN);

            return;
        }
#endregion

#region "関数"

#endregion

    }
}
