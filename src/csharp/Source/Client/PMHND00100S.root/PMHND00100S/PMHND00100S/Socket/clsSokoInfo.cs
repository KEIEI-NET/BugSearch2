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
    /// public class name:   clsSokoInfo
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
    class clsSokoInfo
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
        /// <summary>倉庫コード                             数値型(4</summary>
        public string SokoCd
        {
            get
            { return _sokocd; }
            set
            { _sokocd = value; }
        }

        private string _rtitksokocd = null;
        /// <summary>委託倉庫コード                         文字型(4)</summary>
        public string RtItkSokoCd
        {
            get
            { return _rtitksokocd; }
            set
            { _rtitksokocd = value; }
        }
        private string _rtitksokonm = null;
        /// <summary>委託倉庫名                             文字型(40)</summary>
        public string RtItkSokoNm
        {
            get
            { return _rtitksokonm; }
            set
            { _rtitksokonm = value; }
        }
        private string _rtskmsokocd = null;
        /// <summary>主管元倉庫コード                       文字型(4)</summary>
        public string RtSkmSokoCd
        {
            get
            { return _rtskmsokocd; }
            set
            { _rtskmsokocd = value; }
        }
        private string _rtskmsokonm = null;
        /// <summary>主管元倉庫名                           文字型(40)</summary>
        public string RtSkmSokoNm
        {
            get
            { return _rtskmsokonm; }
            set
            { _rtskmsokonm = value; }
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
        private Int32 _sokocdlen = 0;
        /// <summary>倉庫コード長                           数値型(4)</summary>
        public Int32 SokoCdLen
        {
            get
            { return _sokocdlen; }
            set
            { _sokocdlen = value; }
        }

        private Int32 _rtitksokocdlen = 0;
        /// <summary>委託倉庫コード長                       文字型(4)</summary>
        public Int32 RtItkSokoCdLen
        {
            get
            { return _rtitksokocdlen; }
            set
            { _rtitksokocdlen = value; }
        }
        private Int32 _rtitksokonmlen = 0;
        /// <summary>委託倉庫名長                           文字型(40)</summary>
        public Int32 RtItkSokoNmLen
        {
            get
            { return _rtitksokonmlen; }
            set
            { _rtitksokonmlen = value; }
        }
        private Int32 _rtskmsokocdlen = 0;
        /// <summary>主管元倉庫コード長                     文字型(4)</summary>
        public Int32 RtSkmSokoCdLen
        {
            get
            { return _rtskmsokocdlen; }
            set
            { _rtskmsokocdlen = value; }
        }
        private Int32 _rtskmsokonmlen = 0;
        /// <summary>主管元倉庫名長                         文字型(40)</summary>
        public Int32 RtSkmSokoNmLen
        {
            get
            { return _rtskmsokonmlen; }
            set
            { _rtskmsokonmlen = value; }
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
        public clsSokoInfo()
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

            //委託倉庫コード
            RtItkSokoCd = String.Empty;
            RtItkSokoCdLen = 4;
            //委託倉庫名
            RtItkSokoNm = String.Empty;
            RtItkSokoNmLen = 40;
            //主管元倉庫コード
            RtSkmSokoCd = String.Empty;
            RtSkmSokoCdLen = 4;
            //主管元倉庫名
            RtSkmSokoNm = String.Empty;
            RtSkmSokoNmLen = 40;

            //処理結果
            RetVal = string.Empty;
            RetValLen = 2;

            //電文長
            DenbunLen = RtItkSokoCdLen + RtItkSokoNmLen + RtSkmSokoCdLen + RtSkmSokoNmLen;
        }

#endregion

#region "メソッド "
        /// <summary>
        /// 受信データ初期化
        /// </summary>
        /// <remarks></remarks>
        public void IniOutArg()
        {
            //委託倉庫コード
            RtItkSokoCd = String.Empty;
            //委託倉庫名
            RtItkSokoNm = String.Empty;
            //主管元倉庫コード
            RtSkmSokoCd = String.Empty;
            //主管元倉庫名
            RtSkmSokoNm = String.Empty;

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

            //倉庫コード
            StSize = SokoCdLen;
            SokoCd = Encd.GetString(ArgVal, StPost, StSize);
            StPost += SokoCdLen;

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

            //委託倉庫コード
            string damRtItkSokoCd = clsCommon.FixB(RtItkSokoCd, RtItkSokoCdLen);
            buf = Encd.GetBytes(damRtItkSokoCd);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtItkSokoCdLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtItkSokoCdLen);
            RtItkSokoCd = damRtItkSokoCd;
            stpost += RtItkSokoCdLen;

            //委託倉庫名
            string damRtItkSokoNm = clsCommon.FixB(RtItkSokoNm, RtItkSokoNmLen);
            buf = Encd.GetBytes(damRtItkSokoNm);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtItkSokoNmLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtItkSokoNmLen);
            RtItkSokoNm = damRtItkSokoNm;
            stpost += RtItkSokoNmLen;

            //主管元倉庫コード
            string damRtSkmSokoCd = clsCommon.FixB(RtSkmSokoCd, RtSkmSokoCdLen);
            buf = Encd.GetBytes(damRtSkmSokoCd);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtSkmSokoCdLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtSkmSokoCdLen);
            RtSkmSokoCd = damRtSkmSokoCd;
            stpost += RtSkmSokoCdLen;

            //主管元倉庫名
            string damRtSkmSokoNm = clsCommon.FixB(RtSkmSokoNm, RtSkmSokoNmLen);
            buf = Encd.GetBytes(damRtSkmSokoNm);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtSkmSokoNmLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtSkmSokoNmLen);
            RtSkmSokoNm = damRtSkmSokoNm;
            stpost += RtSkmSokoNmLen;

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

#endregion

#region "関数"

#endregion

    }
}
