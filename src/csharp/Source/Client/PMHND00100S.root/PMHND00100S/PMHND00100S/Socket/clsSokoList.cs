//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ハンディターミナル
// プログラム概要   : ハンディターミナル　メインプログラム(ソケット通信)
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
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
    /// <br>note             :   倉庫リスト取得用クラス</br>
    /// <br>Programmer       :   白厩  翔也</br>
    /// <br>Date             :   2019/10/16</br>
    /// <br></br>
    /// <br></br>
    /// <br>Update Note      :   </br>
    /// <br></br>
    /// </remarks>
    class clsSokoList
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
        private string _sectioncode = null;
        /// <summary>拠点コード                             文字型(6)</summary>
        public string SectionCode
        {
            get
            {   return _sectioncode; }
            set
            {   _sectioncode = value;    }
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
        private string _rtsokocd = null;
        /// <summary>倉庫コード                             数値型(4</summary>
        public string RtSokoCd
        {
            get
            { return _rtsokocd; }
            set
            { _rtsokocd = value; }
        }
        private string _rtsokonm = null;
        /// <summary>倉庫名                                 文字型(40)</summary>
        public string RtSokoNm
        {
            get
            { return _rtsokonm; }
            set
            { _rtsokonm = value; }
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
        private Int32 _sectioncodelen = 0;
        /// <summary>拠点コード                             文字型(6)</summary>
        public Int32 SectionCodeLen
        {
            get
            {   return _sectioncodelen; }
            set
            {   _sectioncodelen = value;    }
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
        private Int32 _rtsokocdlen = 0;
        /// <summary>倉庫コード長                           数値型(4)</summary>
        public Int32 RtSokoCdLen
        {
            get
            { return _rtsokocdlen; }
            set
            { _rtsokocdlen = value; }
        }
        private Int32 _rtsokonmlen = 0;
        /// <summary>倉庫名長                               文字型(40)</summary>
        public Int32 RtSokoNmLen
        {
            get
            { return _rtsokonmlen; }
            set
            { _rtsokonmlen = value; }
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
        public clsSokoList()
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
            //拠点コード
            SectionCode = string.Empty;
            SectionCodeLen = 6;

            //セットした行数
            SetRow = string.Empty;
            SetRowLen = 4;

            //倉庫コード
            RtSokoCd = String.Empty;
            RtSokoCdLen = 4;
            //倉庫名
            RtSokoNm = String.Empty;
            RtSokoNmLen = 40;

            //処理結果
            RetVal = string.Empty;
            RetValLen = 2;

            //電文長
            DenbunLen = SetRowLen + RtSokoCdLen + RtSokoNmLen;
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
            //倉庫コード
            RtSokoCd = String.Empty;
            //倉庫名
            RtSokoNm = String.Empty;

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
            StSize = SectionCodeLen;
            SectionCode = Encd.GetString(ArgVal, StPost, StSize);
            StPost += SectionCodeLen;

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
                Array.Resize(ref rcvval, rcvval.Length + SetRowLen);
                Buffer.BlockCopy(buf, 0, rcvval, stpost, SetRowLen);
                SetRow = damSetRow;
                stpost += SetRowLen;
            }

            //倉庫コード
            string damRtSokoCd = clsCommon.FixB(RtSokoCd, RtSokoCdLen);
            buf = Encd.GetBytes(damRtSokoCd);
            Array.Resize(ref rcvval, rcvval.Length + RtSokoCdLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtSokoCdLen);
            RtSokoCd = damRtSokoCd;
            stpost += RtSokoCdLen;

            //倉庫名
            string damRtSokoNm = clsCommon.FixB(RtSokoNm, RtSokoNmLen);
            buf = Encd.GetBytes(damRtSokoNm);
            Array.Resize(ref rcvval, rcvval.Length + RtSokoNmLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtSokoNmLen);
            RtSokoNm = damRtSokoNm;
            stpost += RtSokoNmLen;

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
                if (intSetRow < 0)
                {
                    SetRow = damSetRow;
                }

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
