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
using System.Data;
using PMHND00100S.Common;

namespace PMHND00100S.Socket
{
    /// public class name:   clsNyuSlipList
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
    class clsNyuSlipList
    {
#region "定数"
        // -- ADD 2019/10/16 ------------------------------>>> 
        /// <summary>処理区分　1:在庫一括分</summary>
        private const string CHK_SYORIKBN_OK1 = "1";
        /// <summary>処理区分　2:その他</summary>
        private const string CHK_SYORIKBN_OK2 = "2";
        /// <summary>処理区分　9:全て</summary>
        private const string CHK_SYORIKBN_OK9 = "9";
        // -- ADD 2019/10/16 ------------------------------<<<
#endregion

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
        private string _haccd = null;
        /// <summary>発注先コード                           文字型(6)</summary>
        public string HacCd
        {
            get
            { return _haccd; }
            set
            { _haccd = value; }
        }

        // --- ADD 2019/10/16 ---------->>>>>
        /// <summary>一括受信用リストアイテムクラス</summary>
        public class SearchKeyItem
        {
            public string ProcDiv;
            public string HacCd;
        }

        private List<SearchKeyItem> _searchItemList = null;
        /// <summary>一括受信用リスト                      オブジェクト型</summary>
        public List<SearchKeyItem> SearchItemList
        {
            get
            { return _searchItemList; }
            set
            { _searchItemList = value; }
        }
        // --- ADD 2019/10/16 ----------<<<<<

        private string _setslip = null;
        /// <summary>セットした伝票数                       数値型(4)</summary>
        public string SetSlip
        {
            get
            { return _setslip; }
            set
            { _setslip = value; }
        }

        private string _rtslipno = null;
        /// <summary>伝票番号                               文字型(13)</summary>
        public string RtSlipNo
        {
            get
            { return _rtslipno; }
            set
            { _rtslipno = value; }
        }
        private string _rtremark = null;
        /// <summary>リマーク                               文字型(40)</summary>
        public string RtReMark
        {
            get
            { return _rtremark; }
            set
            { _rtremark = value; }
        }
        private string _rtonlineno = null;
        /// <summary>オンライン番号                         数値型(9)</summary>
        public string RtOnLineNo
        {
            get
            { return _rtonlineno; }
            set
            { _rtonlineno = value; }
        }
        private string _rtuoehacno = null;
        /// <summary>UOE発注番号                            数値型(9)</summary>
        public string RtUoeHacNo
        {
            get
            { return _rtuoehacno; }
            set
            { _rtuoehacno = value; }
        }
        private string _rtnyukokbn = null;
        /// <summary>入庫区分                               数値型(2)</summary>
        public string RtNyukoKbn
        {
            get
            { return _rtnyukokbn; }
            set
            { _rtnyukokbn = value; }
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
        private Int32 _haccdlen = 0;
        /// <summary>発注先コード長                         文字型(6)</summary>
        public Int32 HacCdLen
        {
            get
            { return _haccdlen; }
            set
            { _haccdlen = value; }
        }

        private Int32 _setsliplen = 0;
        /// <summary>セットした伝票数                       数値型(4)</summary>
        public Int32 SetSlipLen
        {
            get
            { return _setsliplen; }
            set
            { _setsliplen = value; }
        }

        private Int32 _rtslipnolen = 0;
        /// <summary>伝票番号                               文字型(13)</summary>
        public Int32 RtSlipNoLen
        {
            get
            { return _rtslipnolen; }
            set
            { _rtslipnolen = value; }
        }
        private Int32 _rtremarklen = 0;
        /// <summary>リマーク長                             文字型(40)</summary>
        public Int32 RtReMarkLen
        {
            get
            { return _rtremarklen; }
            set
            { _rtremarklen = value; }
        }
        private Int32 _rtonlinenolen = 0;
        /// <summary>オンライン番号長                       数値型(9)</summary>
        public Int32 RtOnLineNoLen
        {
            get
            { return _rtonlinenolen; }
            set
            { _rtonlinenolen = value; }
        }
        private Int32 _rtuoehacnolen = 0;
        /// <summary>UOE発注番号長                          数値型(9)</summary>
        public Int32 RtUoeHacNoLen
        {
            get
            { return _rtuoehacnolen; }
            set
            { _rtuoehacnolen = value; }
        }
        private Int32 _rtnyukokbnlen = 0;
        /// <summary>入庫区分長                             数値型(2)</summary>
        public Int32 RtNyukoKbnLen
        {
            get
            { return _rtnyukokbnlen; }
            set
            { _rtnyukokbnlen = value; }
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
        public clsNyuSlipList()
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
            //処理区分（入庫更新）
            ProcDiv = string.Empty;
            ProcDivLen = 2;
            //発注先コード
            HacCd = string.Empty;
            HacCdLen = 6;

            //セットした伝票数
            SetSlip = string.Empty;
            SetSlipLen = 4;

            //伝票番号
            RtSlipNo = String.Empty;
            RtSlipNoLen = 13;
            //リマーク
            RtReMark = String.Empty;
            RtReMarkLen = 40;
            //オンライン番号
            RtOnLineNo = String.Empty;
            RtOnLineNoLen = 9;
            //UOE発注番号
            RtUoeHacNo = String.Empty;
            RtUoeHacNoLen = 9;
            //入庫区分
            RtNyukoKbn = String.Empty;
            RtNyukoKbnLen = 2;

            //処理結果
            RetVal = string.Empty;
            RetValLen = 2;

            // -- ADD 2019/10/16 ------------------------------>>>
            ////電文長
            //DenbunLen = SetSlipLen + SetSlipLen + RtReMarkLen + RtOnLineNoLen + RtUoeHacNoLen + RtNyukoKbnLen;
            DenbunLen = SetSlipLen + SetSlipLen + RtReMarkLen + RtOnLineNoLen + RtUoeHacNoLen + RtNyukoKbnLen + ProcDivLen;
            // -- ADD 2019/10/16 ------------------------------<<<
        }

#endregion

#region "メソッド "
        /// <summary>
        /// 受信データ初期化
        /// </summary>
        /// <remarks></remarks>
        public void IniOutArg()
        {
            //セットした伝票数
            SetSlip = string.Empty;

            //伝票番号
            RtSlipNo = String.Empty;
            //リマーク
            RtReMark = String.Empty;
            //オンライン番号
            RtOnLineNo = String.Empty;
            //UOE発注番号
            RtUoeHacNo = String.Empty;
            //入庫区分
            RtNyukoKbn = String.Empty;

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

            //発注先コード
            StSize = HacCdLen;
            HacCd = Encd.GetString(ArgVal, StPost, StSize);
            StPost += HacCdLen;

            // -- ADD 2019/10/16 ------------------------------>>>
            SearchItemList = new List<SearchKeyItem>();
            if (ProcDiv.Trim() == CHK_SYORIKBN_OK9)
            {
                SearchKeyItem itm = new SearchKeyItem();

                //処理区分
                itm.ProcDiv = CHK_SYORIKBN_OK1;
                //発注先コード
                itm.HacCd = HacCd;

                SearchItemList.Add(itm);

                itm = new SearchKeyItem();

                //処理区分
                itm.ProcDiv = CHK_SYORIKBN_OK2;
                //発注先コード
                itm.HacCd = HacCd;

                SearchItemList.Add(itm);
            }
            else
            {
                SearchKeyItem itm = new SearchKeyItem();

                //処理区分
                itm.ProcDiv = ProcDiv;
                //発注先コード
                itm.HacCd = HacCd;

                SearchItemList.Add(itm);
            }
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
            Int32 intSetSlip;
            string damSetSlip = string.Empty;

            intSetSlip = Int32.Parse(SetSlip.Trim());

            if (((intSetSlip != 0) && (intSetSlip > 0)) || (intSetSlip == -1))
            {
                damSetSlip = clsCommon.FixB(System.Math.Abs(intSetSlip).ToString(), SetSlipLen);
                buf = Encd.GetBytes(damSetSlip);
                // -- ADD 2019/10/16 ------------------------------>>>
                Array.Resize(ref rcvval, rcvval.Length + RtSlipNoLen);
                // -- ADD 2019/10/16 ------------------------------<<<
                Buffer.BlockCopy(buf, 0, rcvval, stpost, SetSlipLen);
                SetSlip = damSetSlip;
                stpost += SetSlipLen;
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

            //リマーク
            string damRtReMark = clsCommon.FixB(RtReMark, RtReMarkLen);
            buf = Encd.GetBytes(damRtReMark);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtReMarkLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtReMarkLen);
            RtReMark = damRtReMark;
            stpost += RtReMarkLen;

            //オンライン番号
            string damRtOnLineNo = clsCommon.FixB(RtOnLineNo, RtOnLineNoLen);
            buf = Encd.GetBytes(damRtOnLineNo);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtOnLineNoLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtOnLineNoLen);
            RtOnLineNo = damRtOnLineNo;
            stpost += RtOnLineNoLen;

            //UOE発注番号
            string damRtUoeHacNo = clsCommon.FixB(RtUoeHacNo, RtUoeHacNoLen);
            buf = Encd.GetBytes(damRtUoeHacNo);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtUoeHacNoLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtUoeHacNoLen);
            RtUoeHacNo = damRtUoeHacNo;
            stpost += RtUoeHacNoLen;

            //入庫区分
            string damRtNyukoKbn = clsCommon.FixB(RtNyukoKbn, RtNyukoKbnLen);
            buf = Encd.GetBytes(damRtNyukoKbn);
            // -- ADD 2019/10/16 ------------------------------>>>
            Array.Resize(ref rcvval, rcvval.Length + RtNyukoKbnLen);
            // -- ADD 2019/10/16 ------------------------------<<<
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtNyukoKbnLen);
            RtNyukoKbn = damRtNyukoKbn;
            stpost += RtNyukoKbnLen;

            // -- ADD 2019/10/16 ------------------------------>>>
            //処理区分
            string damRtProcDiv = clsCommon.FixB(ProcDiv, ProcDivLen);
            buf = Encd.GetBytes(damRtProcDiv);
            Array.Resize(ref rcvval, rcvval.Length + ProcDivLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, ProcDivLen);
            ProcDiv = damRtProcDiv;
            stpost += ProcDivLen;
            // -- ADD 2019/10/16 ------------------------------<<<

            //最終行処理
            if (intSetSlip < 0)
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
