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
using System;
using System.Collections.Generic;
using System.Text;
using PMHND00100S.Common;

namespace PMHND00100S.Socket
{
    /// public class name:   clsNyuSyuSlipInsert
    /// <summary>
    ///                      ソケット通信用クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   検品データ登録(先行検品)用クラス</br>
    /// <br>Programmer       :   佐藤　智之</br>
    /// <br>Date             :   2017/08/01</br>
    /// <br></br>
    /// <br></br>
    /// <br>Update Note      :   </br>
    /// <br></br>
    /// </remarks>
    class clsNyuSyuSlipInsert
    {

#region "プロパティ"
        private string _soksyorikbn = null;
        /// <summary>ソケット処理区分                           数値型(4)</summary>
        public string SokSyoriKbn
        {
            get
            { return _soksyorikbn; }
            set
            { _soksyorikbn = value; }
        }

        private string _htname = null;
        /// <summary>コンピュータ名                             文字型(20)</summary>
        public string HtName
        {
            get
            { return _htname; }
            set
            { _htname = value; }
        }
        private string _empcd = null;
        /// <summary>従業員コード                               文字型(9)</summary>
        public string EmpCd
        {
            get
            { return _empcd; }
            set
            { _empcd = value; }
        }
        private string _procdiv = null;
        /// <summary>処理区分                                   数値型(2)</summary>
        public string ProcDiv
        {
            get
            { return _procdiv; }
            set
            { _procdiv = value; }
        }
        private string _makercd = null;
        /// <summary>メーカーコード                             数値型(6)</summary>
        public string MakerCd
        {
            get
            { return _makercd; }
            set
            { _makercd = value; }
        }
        private string _syocd = null;
        /// <summary>商品番号                                   文字型(40)</summary>
        public string SyoCd
        {
            get
            { return _syocd; }
            set
            { _syocd = value; }
        }
        private string _sokocd = null;
        /// <summary>倉庫コード                       　        文字型(4)</summary>
        public string SokoCd
        {
            get
            { return _sokocd; }
            set
            { _sokocd = value; }
        }
        private string _checkstus = null;
        /// <summary>検品ステータス                             数値型(4)</summary>
        public string CheckStus
        {
            get
            { return _checkstus; }
            set
            { _checkstus = value; }
        }
        private string _checkkbn = null;
        /// <summary>検品区分                                   数値型(2)</summary>
        public string CheckKbn
        {
            get
            { return _checkkbn; }
            set
            { _checkkbn = value; }
        }
        private string _checknum = null;
        /// <summary>検品数                                     数値型(11(8.2))</summary>
        public string CheckNum
        {
            get
            { return _checknum; }
            set
            { _checknum = value; }
        }

        private string _retval = null;
        /// <summary>処理結果(ステータス)                       数値型(2)</summary>
        public string RetVal
        {
            get
            { return _retval; }
            set
            { _retval = value; }
        }

        private Int32 _soksyorikbnlen = 0;
        /// <summary>ソケット処理区分長                         数値型(4)</summary>
        public Int32 SokSyoriKbnLen
        {
            get
            { return _soksyorikbnlen; }
            set
            { _soksyorikbnlen = value; }
        }

        private Int32 _htnamelen = 0;
        /// <summary>コンピュータ名長                           文字型(20)</summary>
        public Int32 HtNameLen
        {
            get
            { return _htnamelen; }
            set
            { _htnamelen = value; }
        }
        private Int32 _empcdlen = 0;
        /// <summary>従業員コード長                             文字型(9)</summary>
        public Int32 EmpCdLen
        {
            get
            { return _empcdlen; }
            set
            { _empcdlen = value; }
        }
        private Int32 _procdivlen = 0;
        /// <summary>処理区分長                                 数値型(2)</summary>
        public Int32 ProcDivLen
        {
            get
            { return _procdivlen; }
            set
            { _procdivlen = value; }
        }
        private Int32 _makercdlen = 0;
        /// <summary>メーカーコード長                           数値型(6)</summary>
        public Int32 MakerCdLen
        {
            get
            { return _makercdlen; }
            set
            { _makercdlen = value; }
        }
        private Int32 _syocdlen = 0;
        /// <summary>商品番号長                                 文字型(40)</summary>
        public Int32 SyoCdLen
        {
            get
            { return _syocdlen; }
            set
            { _syocdlen = value; }
        }
        private Int32 _sokocdlen = 0;
        /// <summary>倉庫コード長                     　        文字型(4)</summary>
        public Int32 SokoCdLen
        {
            get
            { return _sokocdlen; }
            set
            { _sokocdlen = value; }
        }
        private Int32 _checkstuslen = 0;
        /// <summary>検品ステータス長                           数値型(4)</summary>
        public Int32 CheckStusLen
        {
            get
            { return _checkstuslen; }
            set
            { _checkstuslen = value; }
        }
        private Int32 _kenpinkbnlen = 0;
        /// <summary>検品区分長                                 数値型(2)</summary>
        public Int32 CheckKbnLen
        {
            get
            { return _kenpinkbnlen; }
            set
            { _kenpinkbnlen = value; }
        }
        private Int32 _kenpinnumlen = 0;
        /// <summary>検品数長                                   数値型(11(8.2))</summary>
        public Int32 CheckNumLen
        {
            get
            { return _kenpinnumlen; }
            set
            { _kenpinnumlen = value; }
        }

        private Int32 _retvallen = 0;
        /// <summary>処理結果(ステータス)長                     数値型(2)</summary>
        public Int32 RetValLen
        {
            get
            { return _retvallen; }
            set
            { _retvallen = value; }
        }
#endregion

#region "コンストラクタ"
        Encoding Encd = System.Text.Encoding.GetEncoding("Shift_JIS");

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks></remarks>
        public clsNyuSyuSlipInsert()
        {
            //ソケット通信処理区分
            SokSyoriKbn = clsBtConst.SCKSYRKBN_INS_SYOHININFO_SU.ToString();
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
            //メーカーコード
            MakerCd = string.Empty;
            MakerCdLen = 6;
            //商品番号
            SyoCd = string.Empty;
            SyoCdLen = 40;
            //倉庫コード
            SokoCd = string.Empty;
            SokoCdLen = 4;
            //検品ステータス
            CheckStus = string.Empty;
            CheckStusLen = 4;
            //検品区分
            CheckKbn = string.Empty;
            CheckKbnLen = 2;
            //検品数
            CheckNum = string.Empty;
            CheckNumLen = 11;

            //処理結果
            RetVal = string.Empty;
            RetValLen = 2;
        }

#endregion

#region "メソッド "
        /// <summary>
        /// 受信データ初期化
        /// </summary>
        /// <remarks></remarks>
        public void IniOutArg()
        {
            RetVal = string.Empty;
        }

        /// <summary>
        /// ハンディからの受信データ取得（HT間通信プログラム用）
        /// </summary>
        /// <param name="ArgVal"></param>
        /// <param name="StPost"></param>
        /// <remarks></remarks>
        public Int32 RelayGetHtInArg(byte[] ArgVal, ref Int32 StPost)
        {
            Int32 StSize = 0;
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

            //処理区分
            StSize = ProcDivLen;
            ProcDiv = Encd.GetString(ArgVal, StPost, StSize);
            StPost += ProcDivLen;

            //メーカーコード
            StSize = MakerCdLen;
            MakerCd = Encd.GetString(ArgVal, StPost, StSize);
            StPost += MakerCdLen;

            //商品番号
            StSize = SyoCdLen;
            SyoCd = Encd.GetString(ArgVal, StPost, StSize);
            StPost += SyoCdLen;

            //倉庫コード
            StSize = SokoCdLen;
            SokoCd = Encd.GetString(ArgVal, StPost, StSize);
            StPost += SokoCdLen;

            //検品ステータス
            StSize = CheckStusLen;
            CheckStus = Encd.GetString(ArgVal, StPost, StSize);
            StPost += CheckStusLen;

            //検品区分
            StSize = CheckKbnLen;
            CheckKbn = Encd.GetString(ArgVal, StPost, StSize);
            StPost += CheckKbnLen;

            //検品数
            StSize = CheckNumLen;
            CheckNum = Encd.GetString(ArgVal, StPost, StSize);
            StPost += CheckNumLen;

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
