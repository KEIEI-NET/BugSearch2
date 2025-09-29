//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ハンディターミナル
// プログラム概要   : ハンディターミナル　メインプログラム(ソケット通信)
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570249-00 作成担当 : 三浦
// 修 正 日  2020/04/01  修正内容 : ハンディ仕入れ時在庫登録対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using PMHND00100S.Common;

namespace PMHND00100S.Socket
{
    /// public class name:   clsMakerList
    /// <summary>
    ///                      ソケット通信用クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   メーカーリスト取得用クラス</br>
    /// <br>Programmer       :   三浦</br>
    /// <br>Date             :   2020/04/01</br>
    /// <br></br>
    /// <br></br>
    /// <br>Update Note      :   </br>
    /// <br></br>
    /// </remarks>
    class clsMakerList
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

        private string _setmakercount = null;
        /// <summary>セットしたメーカー数                   数値型(3)</summary>
        public string SetMakerCount
        {
            get
            { return _setmakercount; }
            set
            { _setmakercount = value; }
        }

        private string _rtgoodsmakercd = null;
        /// <summary>メーカーコード                         数値型(6)</summary>
        public string RtGoodsMakerCd
        {
            get
            { return _rtgoodsmakercd; }
            set
            { _rtgoodsmakercd = value; }
        }
        private string _rtmakershortname = null;
        /// <summary>メーカーコード略称                     文字型(10)</summary>
        public string RtMakerShortName
        {
            get
            { return _rtmakershortname; }
            set
            { _rtmakershortname = value; }
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

        private Int32 _setmakercountlen = 0;
        /// <summary>セットしたメーカー数長                 数値型(3)</summary>
        public Int32 SetMakerCountLen
        {
            get
            { return _setmakercountlen; }
            set
            { _setmakercountlen = value; }
        }

        private Int32 _rtgoodsmakercdlen = 0;
        /// <summary>メーカーコード長                       数値型(6)</summary>
        public Int32 RtGoodsMakerCdLen
        {
            get
            { return _rtgoodsmakercdlen; }
            set
            { _rtgoodsmakercdlen = value; }
        }
        private Int32 _rtmakershortnamelen = 0;
        /// <summary>メーカーコード略称長                   文字型(10)</summary>
        public Int32 RtMakerShortNameLen
        {
            get
            { return _rtmakershortnamelen; }
            set
            { _rtmakershortnamelen = value; }
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
        public clsMakerList()
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

            //セットしたメーカー数
            SetMakerCount = string.Empty;
            SetMakerCountLen = 3;

            //メーカーコード
            RtGoodsMakerCd = String.Empty;
            RtGoodsMakerCdLen = 6;
            //メーカーコード略称
            RtMakerShortName = String.Empty;
            RtMakerShortNameLen = 10;

            //処理結果
            RetVal = string.Empty;
            RetValLen = 2;

            //電文長
            DenbunLen = SetMakerCountLen + RtGoodsMakerCdLen + RtMakerShortNameLen;
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
            SetMakerCount = string.Empty;

            //メーカーコード
            RtGoodsMakerCd = String.Empty;
            //メーカーコード略称
            RtMakerShortName = String.Empty;

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

            intSetRow = Int32.Parse(SetMakerCount.Trim());

            if (((intSetRow != 0) && (intSetRow > 0)) || (intSetRow == -1))
            {
                damSetRow = clsCommon.FixB(System.Math.Abs(intSetRow).ToString(), SetMakerCountLen);
                buf = Encd.GetBytes(damSetRow);
                Array.Resize(ref rcvval, rcvval.Length + SetMakerCountLen);
                Buffer.BlockCopy(buf, 0, rcvval, stpost, SetMakerCountLen);
                SetMakerCount = damSetRow;
                stpost += SetMakerCountLen;
            }

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
        }

#endregion

#region "関数"

#endregion

    }
}
