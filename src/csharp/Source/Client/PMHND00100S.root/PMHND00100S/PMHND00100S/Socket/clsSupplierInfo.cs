//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ハンディターミナル
// プログラム概要   : ハンディターミナル　メインプログラム(ソケット通信)
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570249-00 作成担当 : 白厩　翔也
// 修 正 日  2020/04/01  修正内容 : ハンディ仕入れ時在庫登録対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using PMHND00100S.Common;

namespace PMHND00100S.Socket
{
    /// public class name:   clsSupplierInfo
    /// <summary>
    ///                      ソケット通信用クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入先情報取得用クラス</br>
    /// <br>Programmer       :   </br>
    /// <br>Date             :   2020/04/01</br>
    /// <br></br>
    /// <br></br>
    /// <br>Update Note      :   </br>
    /// <br></br>
    /// </remarks>
    class clsSupplierInfo
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
        private string _suppliercd = null;
        /// <summary>仕入先コード                         　数値型(9)</summary>
        public string SupplierCd
        {
            get
            { return _suppliercd; }
            set
            { _suppliercd = value; }
        }

        private string _rtsuppliercd = null;
        /// <summary>仕入先コード                         　数値型(9)</summary>
        public string RtSupplierCd
        {
            get
            { return _rtsuppliercd; }
            set
            { _rtsuppliercd = value; }
        }
        private string _rtsuppliersnm = null;
        /// <summary>仕入先コード略称                     　文字型(20)</summary>
        public string RtSupplierSnm
        {
            get
            { return _rtsuppliersnm; }
            set
            { _rtsuppliersnm = value; }
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
        private Int32 _suppliercdlen = 0;
        /// <summary>仕入先コード長                       　数値型(9)</summary>
        public Int32 SupplierCdLen
        {
            get
            { return _suppliercdlen; }
            set
            { _suppliercdlen = value; }
        }

        private Int32 _rtsuppliercdlen = 0;
        /// <summary>仕入先コード長                       　数値型(9)</summary>
        public Int32 RtSupplierCdLen
        {
            get
            { return _rtsuppliercdlen; }
            set
            { _rtsuppliercdlen = value; }
        }
        private Int32 _rtsuppliersnmlen = 0;
        /// <summary>仕入先コード略称長                   　文字型(20)</summary>
        public Int32 RtSupplierSnmLen
        {
            get
            { return _rtsuppliersnmlen; }
            set
            { _rtsuppliersnmlen = value; }
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
        public clsSupplierInfo()
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
            //仕入先コード
            SupplierCd = String.Empty;
            SupplierCdLen = 9;

            //仕入先コード
            RtSupplierCd = String.Empty;
            RtSupplierCdLen = 9;
            //仕入先コード略称
            RtSupplierSnm = String.Empty;
            RtSupplierSnmLen = 20;

            //処理結果
            RetVal = string.Empty;
            RetValLen = 2;

            //電文長
            DenbunLen = RtSupplierCdLen + RtSupplierSnmLen;
        }
#endregion

#region "メソッド "

        /// <summary>
        /// 受信データ初期化
        /// </summary>
        /// <remarks></remarks>
        public void IniOutArg()
        {
            //仕入先コード
            RtSupplierCd = String.Empty;
            //仕入先コード略称
            RtSupplierSnm = String.Empty;

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

            //仕入先コード
            StSize = SupplierCdLen;
            SupplierCd = Encd.GetString(ArgVal, StPost, StSize);
            StPost += SupplierCdLen;

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

            //仕入先コード
            string damRtSupplierCd = clsCommon.FixB(RtSupplierCd, RtSupplierCdLen);
            buf = Encd.GetBytes(damRtSupplierCd);
            Array.Resize(ref rcvval, rcvval.Length + RtSupplierCdLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtSupplierCdLen);
            RtSupplierCd = damRtSupplierCd;
            stpost += RtSupplierCdLen;

            //仕入先コード略称
            string damRtSupplierSnm = clsCommon.FixB(RtSupplierSnm, RtSupplierSnmLen);
            buf = Encd.GetBytes(damRtSupplierSnm);
            Array.Resize(ref rcvval, rcvval.Length + RtSupplierSnmLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtSupplierSnmLen);
            RtSupplierSnm = damRtSupplierSnm;
            stpost += RtSupplierSnmLen;

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

#endregion

#region "関数"

#endregion

    }
}
