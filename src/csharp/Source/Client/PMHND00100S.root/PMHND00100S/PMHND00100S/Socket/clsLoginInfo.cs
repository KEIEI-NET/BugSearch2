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
// 管理番号  11370074-00 作成担当 : 佐藤　智之
// 修 正 日  2017/08/01  修正内容 : ２次開発
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
    /// public class name:   clsLoginInfo
    /// <summary>
    ///                      ソケット通信用クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   ログイン情報取得用クラス</br>
    /// <br>Programmer       :   佐藤　智之</br>
    /// <br>Date             :   2017/07/01</br>
    /// <br></br>
    /// <br></br>
    /// <br>Update Note      :   2017/08/01  佐藤　智之</br>
    /// <br>                 :   ２次開発</br>
    /// <br></br>
    /// </remarks>
    class clsLoginInfo
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
            {   return _htname;}
            set
            {   _htname = value;    }
        }
        private string _loginid = null;
        /// <summary>ログインID                文字型(24)</summary>
        public string LoginId
        {
            get
            {   return _loginid;    }
            set
            {   _loginid = value;   }
        }

        private string _basecd = null;
        /// <summary>所属拠点コード            文字型(6)</summary>
        public string BaseCd
        {
            get
            {   return _basecd; }
            set
            {   _basecd = value;    }
        }
        private string _basename = null;
        /// <summary>所属拠点名                文字型(12)</summary>
        public string BaseName
        {
            get
            {   return _basename;   }
            set
            {   _basename = value;  }
        }
        private string _empcd = null;
        /// <summary>従業員コード              文字型(9)</summary>
        public string EmpCd
        {
            get
            {   return _empcd;  }
            set
            {   _empcd = value; }
        }
        private string _empname = null;
        /// <summary>名称                      文字型(60)</summary>
        public string EmpName
        {
            get
            {   return _empname;    }
            set
            {   _empname = value;   }
        }
        private string _retdate = null;
        /// <summary>退職日                    数値型(8)</summary>
        public string RetDate
        {
            get
            {   return _retdate;    }
            set
            {   _retdate = value;   }
        }
        private string _entdate = null;
        /// <summary>入社日                    数値型(8)</summary>
        public string EntDate
        {
            get
            {   return _entdate;    }
            set
            {   _entdate = value;   }
        }
        private string _autlv1 = null;
        /// <summary>権限レベル1               数値型(3)</summary>
        public string AutLv1
        {
            get
            {   return _autlv1;     }
            set
            {   _autlv1 = value;    }
        }
        private string _autlv2 = null;
        /// <summary>権限レベル2               数値型(3)</summary>
        public string AutLv2
        {
            get
            {   return _autlv2;     }
            set
            {   _autlv2 = value;    }
        }
        private string _ksokocd = null;
        /// <summary>拠点倉庫コード1           文字型(4)</summary>
        public string KSokoCd
        {
            get
            { return _ksokocd; }
            set
            { _ksokocd = value; }
        }

        // -- ADD 2017/08/01 ------------------------------>>>
        private string _shiireop = null;
        /// <summary>ハンディOP(仕入)          数値型(1)</summary>
        public string ShiireOP
        {
            get
            { return _shiireop; }
            set
            { _shiireop = value; }
        }
        private string _syanaiop = null;
        /// <summary>ハンディOP(社内)　　      数値型(1)</summary>
        public string SyanaiOP
        {
            get
            { return _syanaiop; }
            set
            { _syanaiop = value; }
        }
        private string _shiireshiharaiop = null;
        /// <summary>仕入支払管理オプション    数値型(1)</summary>
        public string ShiireShiharaiOP
        {
            get
            { return _shiireshiharaiop; }
            set
            { _shiireshiharaiop = value; }
        }
        private string _rolltanaoroshi = null;
        /// <summary>ロール(循環棚卸)          数値型(1)</summary>
        public string RollTanaOroshi
        {
            get
            { return _rolltanaoroshi; }
            set
            { _rolltanaoroshi = value; }
        }
        // -- ADD 2017/08/01 ------------------------------<<<

        // -- ADD 2020/04/01 ------------------------------>>>
        private string _zaikotourokuop = null;
        /// <summary>ハンディOP（在庫登録）    数値型(1)</summary>
        public string ZaikoTourokuOP
        {
            get
            { return _zaikotourokuop; }
            set
            { _zaikotourokuop = value; }
        }
        // -- ADD 2020/04/01 ------------------------------<<<

        private string _retval = null;
        /// <summary>処理結果(ステータス)      数値型(2)</summary>
        public string RetVal
        {
            get
            {   return _retval;     }
            set
            {   _retval = value;    }
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
        private Int32 _loginidlen = 0;
        /// <summary>ログインID長              文字型(24)</summary>
        public Int32 LoginIdLen
        {
            get
            { return _loginidlen; }
            set
            { _loginidlen = value; }
        }

        private Int32 _basecdlen = 0;
        /// <summary>所属拠点コード長          文字型(6)</summary>
        public Int32 BaseCdLen
        {
            get
            { return _basecdlen; }
            set
            { _basecdlen = value; }
        }
        private Int32 _basenamelen = 0;
        /// <summary>所属拠点名長              文字型(12)</summary>
        public Int32 BaseNameLen
        {
            get
            { return _basenamelen; }
            set
            { _basenamelen = value; }
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
        private Int32 _empnamelen = 0;
        /// <summary>名称長                    文字型(60)</summary>
        public Int32 EmpNameLen
        {
            get
            { return _empnamelen; }
            set
            { _empnamelen = value; }
        }
        private Int32 _retdatelen = 0;
        /// <summary>退職日長                  数値型(8)</summary>
        public Int32 RetDateLen
        {
            get
            { return _retdatelen; }
            set
            { _retdatelen = value; }
        }
        private Int32 _entdatelen = 0;
        /// <summary>入社日長                  数値型(8)</summary>
        public Int32 EntDateLen
        {
            get
            { return _entdatelen; }
            set
            { _entdatelen = value; }
        }
        private Int32 _autlv1len = 0;
        /// <summary>権限レベル1長             数値型(3)</summary>
        public Int32 AutLv1Len
        {
            get
            { return _autlv1len; }
            set
            { _autlv1len = value; }
        }
        private Int32 _autlv2len = 0;
        /// <summary>権限レベル2長             数値型(3)</summary>
        public Int32 AutLv2Len
        {
            get
            { return _autlv2len; }
            set
            { _autlv2len = value; }
        }
        private Int32 _ksokocdlen = 0;
        /// <summary>拠点倉庫コード1長         文字型(4)</summary>
        public Int32 KSokoCdLen
        {
            get
            { return _ksokocdlen; }
            set
            { _ksokocdlen = value; }
        }
        // -- ADD 2017/08/01 ------------------------------>>>
        private Int32 _shiireoplen = 0;
        /// <summary>ハンディOP(仕入)長        数値型(1)</summary>
        public Int32 ShiireOPLen
        {
            get
            { return _shiireoplen; }
            set
            { _shiireoplen = value; }
        }
        private Int32 _syanaioplen = 0;
        /// <summary>ハンディOP(社内)長　      数値型(1)</summary>
        public Int32 SyanaiOPLen
        {
            get
            { return _syanaioplen; }
            set
            { _syanaioplen = value; }
        }
        private Int32 _shiireshiharaioplen = 0;
        /// <summary>仕入支払管理オプション長  数値型(1)</summary>
        public Int32 ShiireShiharaiOPLen
        {
            get
            { return _shiireshiharaioplen; }
            set
            { _shiireshiharaioplen = value; }
        }
        private Int32 _rolltanaoroshilen = 0;
        /// <summary>ロール(循環棚卸)長        数値型(1)</summary>
        public Int32 RollTanaOroshiLen
        {
            get
            { return _rolltanaoroshilen; }
            set
            { _rolltanaoroshilen = value; }
        }
        // -- ADD 2017/08/01 ------------------------------<<<

        // -- ADD 2020/04/01 ------------------------------>>>
        private Int32 _zaikotourokuoplen = 0;
        /// <summary>ハンディOP(在庫登録)長　  数値型(1)</summary>
        public Int32 ZaikoTourokuOPLen
        {
            get
            { return _zaikotourokuoplen; }
            set
            { _zaikotourokuoplen = value; }
        }
        // -- ADD 2020/04/01 ------------------------------<<<

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
        public clsLoginInfo()
        {
            //ソケット通信処理区分
            SokSyoriKbn = clsBtConst.SCKSYRKBN_GET_LOGININFO.ToString();
            SokSyoriKbnLen = 4;
            //コンピューター名
            HtName = string.Empty;
            HtNameLen = 20;
            //ログインＩＤ
            LoginId = string.Empty;
            LoginIdLen = 24;

            //所属拠点コード
            BaseCd = string.Empty;
            BaseCdLen = 6;
            //所属拠点名
            BaseName = string.Empty;
            BaseNameLen = 12;
            //従業員コード
            EmpCd = string.Empty;
            EmpCdLen = 9;
            //従業員名
            EmpName = string.Empty;
            EmpNameLen = 60;
            //退職日
            RetDate = string.Empty;
            RetDateLen = 8;
            //入社日
            EntDate = string.Empty;
            EntDateLen = 8;
            //権限レベル1
            AutLv1 = string.Empty;
            AutLv1Len = 3;
            //権限レベル2
            AutLv2 = string.Empty;
            AutLv2Len = 3;
            //拠点倉庫コード
            KSokoCd = string.Empty;
            KSokoCdLen = 4;

            // -- ADD 2017/08/01 ------------------------------>>>
            //ハンディOP(仕入)
            ShiireOP = string.Empty;
            ShiireOPLen = 1;
            //ハンディOP(社内)
            SyanaiOP = string.Empty;
            SyanaiOPLen = 1;
            //仕入支払管理オプション
            ShiireShiharaiOP = string.Empty;
            ShiireShiharaiOPLen = 1;
            //ロール(循環棚卸)
            RollTanaOroshi = string.Empty;
            RollTanaOroshiLen = 1;
            // -- ADD 2017/08/01 ------------------------------<<<

            // -- ADD 2020/04/01 ------------------------------>>>
            //ハンディOP(在庫登録)
            ZaikoTourokuOP = string.Empty;
            ZaikoTourokuOPLen = 1;
            // -- ADD 2020/04/01 ------------------------------<<<

            //処理結果
            RetVal = string.Empty;
            RetValLen = 2;

            //電文長
            DenbunLen = BaseCdLen + BaseNameLen + EmpCdLen + EmpNameLen + RetDateLen + EntDateLen + AutLv1Len + AutLv2Len + KSokoCdLen;
        }

#endregion

#region "メソッド "
        /// <summary>
        /// 受信データ初期化
        /// </summary>
        /// <remarks></remarks>
        public void IniOutArg()
        {
            //所属拠点コード
            BaseCd = string.Empty;
            //所属拠点名
            BaseName = string.Empty;
            //従業員コード
            EmpCd = string.Empty;
            //従業員名
            EmpName = string.Empty;
            //退職日
            RetDate = string.Empty;
            //入社日
            EntDate = string.Empty;
            //権限レベル1
            AutLv1 = string.Empty;
            //権限レベル2
            AutLv2 = string.Empty;
            //拠点倉庫コード
            KSokoCd = string.Empty;

            // -- ADD 2017/08/01 ------------------------------>>>
            //ハンディOP(仕入)
            ShiireOP = string.Empty;
            //ハンディOP(社内)
            SyanaiOP = string.Empty;
            //仕入支払管理オプション
            ShiireShiharaiOP = string.Empty;
            //ロール(循環棚卸)
            RollTanaOroshi = string.Empty;
            // -- ADD 2017/08/01 ------------------------------<<<

            // -- ADD 2020/04/01 ------------------------------>>>
            ZaikoTourokuOP = string.Empty;
            // -- ADD 2020/04/01 ------------------------------<<<

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

            //ログインＩＤ
            StSize = LoginIdLen;
            LoginId = Encd.GetString(ArgVal, StPost, StSize);

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

            //所属拠点コード
            string damBaseCd = clsCommon.FixB(BaseCd, BaseCdLen);
            buf = Encd.GetBytes(damBaseCd);
            stpost = 0;
            Array.Resize(ref rcvval, BaseCdLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, BaseCdLen);
            BaseCd = damBaseCd;

            //所属拠点名
            string damBaseName = clsCommon.FixB(BaseName, BaseNameLen);
            buf = Encd.GetBytes(damBaseName);
            stpost += BaseCdLen;
            Array.Resize(ref rcvval, rcvval.Length + BaseNameLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, BaseNameLen);
            BaseName = damBaseName;

            //従業員コード
            string damEmpCd = clsCommon.FixB(EmpCd, EmpCdLen);
            buf = Encd.GetBytes(damEmpCd);
            stpost += BaseNameLen;
            Array.Resize(ref rcvval, rcvval.Length + EmpCdLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, EmpCdLen);
            EmpCd = damEmpCd;

            //従業員名
            string damEmpName = clsCommon.FixB(EmpName, EmpNameLen);
            buf = Encd.GetBytes(damEmpName);
            stpost += EmpCdLen;
            Array.Resize(ref rcvval, rcvval.Length + EmpNameLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, EmpNameLen);
            EmpName = damEmpName;

            //退職日
            string damRetDate = clsCommon.FixB(RetDate, RetDateLen);
            buf = Encd.GetBytes(damRetDate);
            stpost += EmpNameLen;
            Array.Resize(ref rcvval, rcvval.Length + RetDateLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RetDateLen);
            RetDate = damRetDate;

            //入社日
            string damEntDate = clsCommon.FixB(EntDate, EntDateLen);
            buf = Encd.GetBytes(damEntDate);
            stpost += RetDateLen;
            Array.Resize(ref rcvval, rcvval.Length + EntDateLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, EntDateLen);
            EntDate = damEntDate;

            //権限レベル1
            string damAutLv1 = clsCommon.FixB(AutLv1, AutLv1Len);
            buf = Encd.GetBytes(damAutLv1);
            stpost += EntDateLen;
            Array.Resize(ref rcvval, rcvval.Length + AutLv1Len);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, AutLv1Len);
            AutLv1 = damAutLv1;

            //権限レベル2
            string damAutLv2 = clsCommon.FixB(AutLv2, AutLv2Len);
            buf = Encd.GetBytes(damAutLv2);
            stpost += AutLv1Len;
            Array.Resize(ref rcvval, rcvval.Length + AutLv2Len);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, AutLv2Len);
            AutLv2 = damAutLv2;

            //拠点倉庫コード
            string damKSokoCd = clsCommon.FixB(KSokoCd, KSokoCdLen);
            buf = Encd.GetBytes(damKSokoCd);
            stpost += AutLv2Len;
            Array.Resize(ref rcvval, rcvval.Length + KSokoCdLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, KSokoCdLen);
            KSokoCd = damKSokoCd;

            // -- ADD 2017/08/01 ------------------------------>>>
            //ハンディOP(仕入)
            string damShiireOP = clsCommon.FixB(ShiireOP, ShiireOPLen);
            buf = Encd.GetBytes(damShiireOP);
            stpost += KSokoCdLen;
            Array.Resize(ref rcvval, rcvval.Length + ShiireOPLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, ShiireOPLen);
            ShiireOP = damShiireOP;

            //ハンディOP(社内)
            string damSyanaiOP = clsCommon.FixB(SyanaiOP, SyanaiOPLen);
            buf = Encd.GetBytes(damSyanaiOP);
            stpost += ShiireOPLen;
            Array.Resize(ref rcvval, rcvval.Length + SyanaiOPLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, SyanaiOPLen);
            SyanaiOP = damSyanaiOP;

            //仕入支払管理オプション
            string damShiireShiharaiOP = clsCommon.FixB(ShiireShiharaiOP, ShiireShiharaiOPLen);
            buf = Encd.GetBytes(damShiireShiharaiOP);
            stpost += SyanaiOPLen;
            Array.Resize(ref rcvval, rcvval.Length + ShiireShiharaiOPLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, ShiireShiharaiOPLen);
            ShiireShiharaiOP = damShiireShiharaiOP;

            //ロール(循環棚卸)
            string damRollTanaOroshi = clsCommon.FixB(RollTanaOroshi, RollTanaOroshiLen);
            buf = Encd.GetBytes(damRollTanaOroshi);
            stpost += ShiireShiharaiOPLen;
            Array.Resize(ref rcvval, rcvval.Length + RollTanaOroshiLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RollTanaOroshiLen);
            RollTanaOroshi = damRollTanaOroshi;
            // -- ADD 2017/08/01 ------------------------------<<<

            // -- ADD 2020/04/01 ------------------------------>>>
            //ハンディOP(在庫登録)
            string damZaikoTourokuOP = clsCommon.FixB(ZaikoTourokuOP, ZaikoTourokuOPLen);
            buf = Encd.GetBytes(damZaikoTourokuOP);
            stpost += RollTanaOroshiLen;
            Array.Resize(ref rcvval, rcvval.Length + ZaikoTourokuOPLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, ZaikoTourokuOPLen);
            ZaikoTourokuOP = damZaikoTourokuOP;
            // -- ADD 2020/04/01 ------------------------------<<<

            //処理結果
            string damRetVal = RetVal.ToString().PadLeft(2, '0');
            buf = Encd.GetBytes(damRetVal);
            // -- UPD 2017/08/01 ------------------------------>>>
            //stpost += KSokoCdLen;

            // -- UPD 2020/04/01 ------------------------------>>>
            //stpost += RollTanaOroshiLen;
            stpost += ZaikoTourokuOPLen;
            // -- UPD 2020/04/01 ------------------------------<<<
            // -- UPD 2017/08/01 ------------------------------<<<
            Array.Resize(ref rcvval, rcvval.Length + RetValLen);
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
