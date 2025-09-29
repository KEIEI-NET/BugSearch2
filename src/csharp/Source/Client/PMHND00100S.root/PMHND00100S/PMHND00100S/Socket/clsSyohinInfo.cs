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
// 修 正 日  2019/10/16  修正内容 : ６次対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using PMHND00100S.Common;

namespace PMHND00100S.Socket
{
    /// public class name:   clsSyohinInfo
    /// <summary>
    ///                      ソケット通信用クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品情報取得用クラス</br>
    /// <br>Programmer       :   佐藤　智之</br>
    /// <br>Date             :   2017/07/01</br>
    /// <br></br>
    /// <br></br>
    /// <br>Update Note      :   </br>
    /// <br></br>
    /// </remarks>
    class clsSyohinInfo
    {

#region "プロパティ"
        private string _soksyorikbn = null;
        /// <summary>ソケット処理区分               数値型(4)</summary>
        public string SokSyoriKbn
        {
            get
            { return _soksyorikbn; }
            set
            { _soksyorikbn = value; }
        }
        private string _empcd = null;
        /// <summary>従業員コード                   文字型(9)</summary>
        public string EmpCd
        {
            get
            { return _empcd; }
            set
            { _empcd = value; }
        }
        private string _htname = null;
        /// <summary>コンピュータ名                 文字型(20)</summary>
        public string HtName
        {
            get
            { return _htname; }
            set
            { _htname = value; }
        }
        private string _sokocd = null;
        /// <summary>倉庫コード                     文字型(4)</summary>
        public string SokoCd
        {
            get
            { return _sokocd; }
            set
            { _sokocd = value; }
        }
        private string _barcode = null;
        /// <summary>商品バーコード                 文字型(128)</summary>
        public string Barcode
        {
            get
            { return _barcode; }
            set
            { _barcode = value; }
        }

        private string _makercd = null;
        /// <summary>メーカーコード                 数値型(6)</summary>
        public string MakerCd
        {
            get
            { return _makercd; }
            set
            { _makercd = value; }
        }
        private string _makernm = null;
        /// <summary>メーカー名                     文字型(20)</summary>
        public string MakerNm
        {
            get
            { return _makernm; }
            set
            { _makernm = value; }
        }
        private string _syonm = null;
        /// <summary>商品名                         文字型(40)</summary>
        public string SyoNm
        {
            get
            { return _syonm; }
            set
            { _syonm = value; }
        }
        private string _syocd = null;
        /// <summary>商品番号                       文字型(40)</summary>
        public string SyoCd
        {
            get
            { return _syocd; }
            set
            { _syocd = value; }
        }
        private string _tanano = null;
        /// <summary>棚番                           文字型(8)</summary>
        public string TanaNo
        {
            get
            { return _tanano; }
            set
            { _tanano = value; }
        }
        private string _rtsokocd = null;
        /// <summary>倉庫コード                     文字型(4)</summary>
        public string RtSokoCd
        {
            get
            { return _rtsokocd; }
            set
            { _rtsokocd = value; }
        }
        private string _sokonm = null;
        /// <summary>倉庫名称                       文字型(20)</summary>
        public string SokoNm
        {
            get
            { return _sokonm; }
            set
            { _sokonm = value; }
        }
        private string _zaikonum = null;
        /// <summary>在庫数                         数値型(11(8.2))</summary>
        public string ZaikoNum
        {
            get
            { return _zaikonum; }
            set
            { _zaikonum = value; }
        }
        private string _lasturi = null;
        /// <summary>最終売上日                     数値型(8)</summary>
        public string LastUri
        {
            get
            { return _lasturi; }
            set
            { _lasturi = value; }
        }
        private string _lastsir = null;
        /// <summary>最終仕入日                     数値型(8)</summary>
        public string LastSir
        {
            get
            { return _lastsir; }
            set
            { _lastsir = value; }
        }

        private string _retval = null;
        /// <summary>処理結果(ステータス)           数値型(2)</summary>
        public string RetVal
        {
            get
            { return _retval; }
            set
            { _retval = value; }
        }
        // -- ADD 2019/10/16 ------------------------------>>>
        private string _setrow = null;
        /// <summary>セットした行数                         数値型(4)</summary>
        public string SetRow
        {
            get
            { return _setrow; }
            set
            { _setrow = value; }
        }
        // -- ADD 2019/10/16 ------------------------------<<<
        private Int32 _soksyorikbnlen = 0;
        /// <summary>ソケット処理区分長             数値型(4)</summary>
        public Int32 SokSyoriKbnLen
        {
            get
            { return _soksyorikbnlen; }
            set
            { _soksyorikbnlen = value; }
        }
        private Int32 _htnamelen = 0;
        /// <summary>コンピュータ名長               文字型(20)</summary>
        public Int32 HtNameLen
        {
            get
            { return _htnamelen; }
            set
            { _htnamelen = value; }
        }
        private Int32 _empcdlen = 0;
        /// <summary>従業員コード長             文字型(9)</summary>
        public Int32 EmpCdLen
        {
            get
            { return _empcdlen; }
            set
            { _empcdlen = value; }
        }
        private Int32 _sokocdlen = 0;
        /// <summary>倉庫コード長                   文字型(4)</summary>
        public Int32 SokoCdLen
        {
            get
            { return _sokocdlen; }
            set
            { _sokocdlen = value; }
        }
        private Int32 _barcodelen = 0;
        /// <summary>商品バーコード長               文字型(128)</summary>
        public Int32 BarcodeLen
        {
            get
            { return _barcodelen; }
            set
            { _barcodelen = value; }
        }

        private Int32 _makercdlen = 0;
        /// <summary>メーカーコード長               数値型(6)</summary>
        public Int32 MakerCdLen
        {
            get
            { return _makercdlen; }
            set
            { _makercdlen = value; }
        }
        private Int32 _makernmlen = 0;
        /// <summary>メーカー名長                   文字型(20)</summary>
        public Int32 MakerNmLen
        {
            get
            { return _makernmlen; }
            set
            { _makernmlen = value; }
        }
        private Int32 _syonmlen = 0;
        /// <summary>商品名長                       文字型(40)</summary>
        public Int32 SyoNmLen
        {
            get
            { return _syonmlen; }
            set
            { _syonmlen = value; }
        }
        private Int32 _syocdlen = 0;
        /// <summary>商品番号長                     文字型(40)</summary>
        public Int32 SyoCdLen
        {
            get
            { return _syocdlen; }
            set
            { _syocdlen = value; }
        }
        private Int32 _tananolen = 0;
        /// <summary>棚番長                         文字型(8)</summary>
        public Int32 TanaNoLen
        {
            get
            { return _tananolen; }
            set
            { _tananolen = value; }
        }
        private Int32 _rtsokocdlen = 0;
        /// <summary>倉庫コード長                   文字型(4)</summary>
        public Int32 RtSokoCdLen
        {
            get
            { return _rtsokocdlen; }
            set
            { _rtsokocdlen = value; }
        }
        private Int32 _sokonmlen = 0;
        /// <summary>倉庫名称長                     文字型(20)</summary>
        public Int32 SokoNmLen
        {
            get
            { return _sokonmlen; }
            set
            { _sokonmlen = value; }
        }
        private Int32 _zaikonumlen = 0;
        /// <summary>在庫数長                       数値型(11(8.2))</summary>
        public Int32 ZaikoNumLen
        {
            get
            { return _zaikonumlen; }
            set
            { _zaikonumlen = value; }
        }
        private Int32 _lasturilen = 0;
        /// <summary>最終売上日長                   数値型(8)</summary>
        public Int32 LastUriLen
        {
            get
            { return _lasturilen; }
            set
            { _lasturilen = value; }
        }
        private Int32 _lastsirlen = 0;
        /// <summary>最終仕入日長                   数値型(8)</summary>
        public Int32 LastSirLen
        {
            get
            { return _lastsirlen; }
            set
            { _lastsirlen = value; }
        }

        private Int32 _retvallen = 0;
        /// <summary>処理結果(ステータス)長         数値型(2)</summary>
        public Int32 RetValLen
        {
            get
            { return _retvallen; }
            set
            { _retvallen = value; }
        }
        // -- ADD 2019/10/16 ------------------------------>>>
        private Int32 _setrowlen = 0;
        /// <summary>セットした行数長                       数値型(4)</summary>
        public Int32 SetRowLen
        {
            get
            { return _setrowlen; }
            set
            { _setrowlen = value; }
        }
        // -- ADD 2019/10/16 ------------------------------<<<

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
        public clsSyohinInfo()
        {
            //ソケット通信処理区分
            SokSyoriKbn = clsBtConst.SCKSYRKBN_GET_SYOHININFO.ToString();
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
            //商品バーコード
            Barcode = string.Empty;
            BarcodeLen = 128;

            //処理結果
            RetVal = string.Empty;
            RetValLen = 2;

            // -- ADD 2019/10/16 ------------------------------>>>
            //セットした行数
            SetRow = string.Empty;
            SetRowLen = 4;
            // -- ADD 2019/10/16 ------------------------------<<<

            //メーカーコード
            MakerCd = string.Empty;
            MakerCdLen = 6;
            //メーカー名
            MakerNm = string.Empty;
            MakerNmLen = 20;
            //商品番号
            SyoCd = string.Empty;
            SyoCdLen = 40;
            //商品名
            SyoNm = string.Empty;
            SyoNmLen = 40;
            //棚番
            TanaNo = string.Empty;
            TanaNoLen = 8;
            //倉庫コード
            RtSokoCd = string.Empty;
            RtSokoCdLen = 4;
            //倉庫名称
            SokoNm = string.Empty;
            SokoNmLen = 20;
            //在庫数
            ZaikoNum = string.Empty;
            ZaikoNumLen = 11;
            //最終売上日
            LastUri = string.Empty;
            LastUriLen = 8;
            //最終仕入日
            LastSir = string.Empty;
            LastSirLen = 8;

            //電文長
            DenbunLen = MakerCdLen + MakerNmLen + SyoCdLen + SyoNmLen + TanaNoLen + RtSokoCdLen + SokoNmLen;
            DenbunLen += ZaikoNumLen + LastUriLen + LastSirLen;
        }

#endregion

#region "メソッド "
        /// <summary>
        /// 受信データ初期化
        /// </summary>
        /// <remarks></remarks>
        public void IniOutArg()
        {
            // -- ADD 2019/10/16 ------------------------------>>>
            //セットした行数
            SetRow = string.Empty;
            // -- ADD 2019/10/16 ------------------------------<<<

            //メーカーコード
            MakerCd = string.Empty;
            //メーカー名
            MakerNm = string.Empty;
            //商品番号
            SyoCd = string.Empty;
            //商品名
            SyoNm = string.Empty;
            //棚番
            TanaNo = string.Empty;
            //倉庫コード
            RtSokoCd = string.Empty;
            //倉庫名
            SokoNm = string.Empty;
            //在庫数
            ZaikoNum = string.Empty;
            //最終売上日
            LastUri = string.Empty;
            //最終仕入日
            LastSir = string.Empty;
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

            //商品バーコード
            StSize = BarcodeLen;
            Barcode = Encd.GetString(ArgVal, StPost, StSize);

            // -- ADD 2019/10/16 ------------------------------>>>
            StPost += BarcodeLen;

            //商品番号
            StSize = SyoCdLen;
            SyoCd = Encd.GetString(ArgVal, StPost, StSize);
            StPost += SyoCdLen;
            // -- ADD 2019/10/16 ------------------------------<<<

            return 0;
        }

        /// <summary>
        /// 受信データ取得（HT間通信プログラム用）
        /// </summary>
        /// <remarks>ハンディプログラムでの受信バッファにあわせて5000Byte以下である必要があります</remarks>
        // -- UPD 2019/10/16 ------------------------------>>>
        //public byte[] RelayGetOutArg()
        public void RelayGetOutArg(ref byte[] rcvval, ref Int32 stpost)
        // -- UPD 2019/10/16 ------------------------------<<<
        {
            // -- DEL 2019/10/16 ------------------------------>>>
            //byte[] rcvval = new byte[] { };
            // -- DEL 2019/10/16 ------------------------------<<<
            byte[] buf = null;
            // -- DEL 2019/10/16 ------------------------------>>>
            //Int32 stpost = 0;
            // -- DEL 2019/10/16 ------------------------------<<<

            // -- ADD 2019/10/16 ------------------------------>>>
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
            // -- ADD 2019/10/16 ------------------------------<<<

            //メーカーコード
            string damMakerCd = clsCommon.FixB(MakerCd, MakerCdLen);
            buf = Encd.GetBytes(damMakerCd);
            // -- UPD 2019/10/16 ------------------------------>>>
            //stpost = 0;
            //Array.Resize(ref rcvval, MakerCdLen);
            Array.Resize(ref rcvval, rcvval.Length + MakerCdLen);
            // -- UPD 2019/10/16 ------------------------------>>>
            Buffer.BlockCopy(buf, 0, rcvval, stpost, MakerCdLen);
            MakerCd = damMakerCd;

            //メーカー名
            string damMakerNm = clsCommon.FixB(MakerNm, MakerNmLen);
            buf = Encd.GetBytes(damMakerNm);
            stpost += MakerCdLen;
            Array.Resize(ref rcvval, rcvval.Length + MakerNmLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, MakerNmLen);
            MakerNm = damMakerNm;

            //商品番号
            string damSyoCd = clsCommon.FixB(SyoCd, SyoCdLen);
            buf = Encd.GetBytes(damSyoCd);
            stpost += MakerNmLen;
            Array.Resize(ref rcvval, rcvval.Length + SyoCdLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, SyoCdLen);
            SyoCd = damSyoCd;

            //商品名
            string damSyoNm = clsCommon.FixB(SyoNm, SyoNmLen);
            buf = Encd.GetBytes(damSyoNm);
            stpost += SyoCdLen;
            Array.Resize(ref rcvval, rcvval.Length + SyoNmLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, SyoNmLen);
            SyoNm = damSyoNm;

            //棚番
            string damTanaNo = clsCommon.FixB(TanaNo, TanaNoLen);
            buf = Encd.GetBytes(damTanaNo);
            stpost += SyoNmLen;
            Array.Resize(ref rcvval, rcvval.Length + TanaNoLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, TanaNoLen);
            TanaNo = damTanaNo;

            //倉庫コード
            string damRtSokoCd = clsCommon.FixB(RtSokoCd, RtSokoCdLen);
            buf = Encd.GetBytes(damRtSokoCd);
            stpost += TanaNoLen;
            Array.Resize(ref rcvval, rcvval.Length + RtSokoCdLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RtSokoCdLen);
            RtSokoCd = damRtSokoCd;

            //倉庫名
            string damSokoNm = clsCommon.FixB(SokoNm, SokoNmLen);
            buf = Encd.GetBytes(damSokoNm);
            stpost += RtSokoCdLen;
            Array.Resize(ref rcvval, rcvval.Length + SokoNmLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, SokoNmLen);
            SokoNm = damSokoNm;

            //在庫数
            string damZaikoNum = clsCommon.FixB(ZaikoNum, ZaikoNumLen);
            buf = Encd.GetBytes(damZaikoNum);
            stpost += SokoNmLen;
            Array.Resize(ref rcvval, rcvval.Length + ZaikoNumLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, ZaikoNumLen);
            ZaikoNum = damZaikoNum;

            //最終売上日
            string damLastUri = clsCommon.FixB(LastUri, LastUriLen);
            buf = Encd.GetBytes(damLastUri);
            stpost += ZaikoNumLen;
            Array.Resize(ref rcvval, rcvval.Length + LastUriLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, LastUriLen);
            LastUri = damLastUri;

            //最終仕入日
            string damLastSir = clsCommon.FixB(LastSir, LastSirLen);
            buf = Encd.GetBytes(damLastSir);
            stpost += LastUriLen;
            Array.Resize(ref rcvval, rcvval.Length + LastSirLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, LastSirLen);
            LastSir = damLastSir;
            // -- ADD 2019/10/16 ------------------------------>>>
            stpost += LastSirLen;
            // -- ADD 2019/10/16 ------------------------------<<<

            // -- UPD 2019/10/16 ------------------------------>>>
            ////処理結果
            //string damRetVal = RetVal.ToString().PadLeft(2, '0');
            //buf = Encd.GetBytes(damRetVal);
            //stpost += LastUriLen;
            //Array.Resize(ref rcvval, rcvval.Length + RetValLen);
            //Buffer.BlockCopy(buf, 0, rcvval, stpost, RetValLen);
            //RetVal = damRetVal;

            //buf = Encd.GetBytes(clsBtConst.HT_MSG_CRLF);
            //stpost += RetValLen;
            //Array.Resize(ref rcvval, rcvval.Length + clsBtConst.HT_MSG_CRLF_LEN);
            //Buffer.BlockCopy(buf, 0, rcvval, stpost, clsBtConst.HT_MSG_CRLF_LEN);
            //最終行処理
            if (intSetRow < 0)
            {
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
                stpost += clsBtConst.HT_MSG_CRLF_LEN;
            }
            // -- UPD 2019/10/16 ------------------------------>>>

            // -- DEL 2019/10/16 ------------------------------>>>
            //return rcvval;
            // -- DEL 2019/10/16 ------------------------------<<<
        }

#endregion

#region "関数"

#endregion

    }
}
