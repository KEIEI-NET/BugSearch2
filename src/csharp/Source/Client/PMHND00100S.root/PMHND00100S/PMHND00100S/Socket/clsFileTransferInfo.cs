//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ハンディターミナル
// プログラム概要   : ハンディターミナル　メインプログラム(ソケット通信)
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11575094-00 作成担当 : 岸　傑
// 作 成 日  2019/06/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using PMHND00100S.Common;

namespace PMHND00100S.Socket
{
    class clsFileTransferInfo
    {
        /// <summary>ソケット処理区分                     数値型(4)</summary>
        private string _soksyorikbn = null;
        public string SokSyoriKbn 
        {
            get
            { return _soksyorikbn; }
            set
            { _soksyorikbn = value; }
        }
        /// <summary>コンピュータ名                       文字型(20)</summary>
        private string _htname = null;
        public string HtName
        {
            get
            { return _htname; }
            set
            { _htname = value; }
        }
        /// <summary>従業員コード                         文字型(9)</summary>
        private string _empcd = null;
        public string EmpCd
        {
            get
            { return _empcd; }
            set
            { _empcd = value; }
        }
        /// <summary>ファイル名                           文字型(64)</summary>
        private string _filename = null;
        public string FileName
        {
            get
            { return _filename; }
            set
            { _filename = value; }
        }
        /// <summary>ファイルサイズ                       数値型(5)</summary>
        private string _filesize = null;
        public string FileSize
        {
            get
            { return _filesize; }
            set
            { _filesize = value; }
        }
        /// <summary>ファイルデータ                       バイナリ型(32768)</summary>
        private string _filedata = null;
        public string FileData
        {
            get
            { return _filedata; }
            set
            { _filedata = value; }
        }
        /// <summary>ソケット処理区分                     数値型(4)</summary>
        private int _soksyorikbnlen = 0;
        public int SokSyoriKbnLen
        {
            get
            { return _soksyorikbnlen; }
            set
            { _soksyorikbnlen = value; }
        }
        /// <summary>コンピュータ名                       文字型(20)</summary>
        private int _htnamelen = 0;
        public int HtNameLen
        {
            get
            { return _htnamelen; }
            set
            { _htnamelen = value; }
        }
        /// <summary>従業員コード                         文字型(9)</summary>
        private int _empcdlen = 0;
        public int EmpCdLen
        {
            get
            { return _empcdlen; }
            set
            { _empcdlen = value; }
        }
        /// <summary>ファイル名                           文字型(64)</summary>
        private int _filenamelen = 0;
        public int FileNameLen
        {
            get
            { return _filenamelen; }
            set
            { _filenamelen = value; }
        }
        /// <summary>ファイルサイズ                       数値型(5)</summary>
        private int _filesizelen = 0;
        public int FileSizeLen
        {
            get
            { return _filesizelen; }
            set
            { _filesizelen = value; }
        }
        /// <summary>ファイルデータ                      バイナリ型(32768)</summary>
        private int _filedatalen = 0;
        public int FileDataLen
        {
            get
            { return _filedatalen; }
            set
            { _filedatalen = value; }
        }

        /// <summary>処理結果(ステータス)                 数値型(2)</summary>
        private string _retval = null;
        public string RetVal
        {
            get
            { return _retval; }
            set
            { _retval = value; }
        }
        /// <summary>処理結果(ステータス)長               数値型(2)</summary>
        private Int32 _retvallen = 0;
        public Int32 RetValLen
        {
            get
            { return _retvallen; }
            set
            { _retvallen = value; }
        }

        Encoding Encd = System.Text.Encoding.GetEncoding("Shift_JIS");

        public clsFileTransferInfo()
        {
            SokSyoriKbn = clsBtConst.SCKSYRKBN_FILE_TRANSFER.ToString();
            SokSyoriKbnLen = 4;

            HtName = string.Empty;
            HtNameLen = 20;

            EmpCd = string.Empty;
            EmpCdLen = 9;

            FileName = string.Empty;
            FileNameLen = 64;

            FileSize = string.Empty;
            FileSizeLen = 5;

            FileData = null;
            FileDataLen = 43000;

            RetVal = string.Empty;
            RetValLen = 2;
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

            //ファイル名
            StSize = FileNameLen;
            FileName = Encd.GetString(ArgVal, StPost, StSize);
            StPost += FileNameLen;

            //ファイルサイズ
            StSize = FileSizeLen;
            FileSize = Encd.GetString(ArgVal, StPost, StSize);
            StPost += FileSizeLen;

            //ファイルデータ
            int result = 0;
            if (int.TryParse(FileSize, out result))
            {
                StSize = result;
                FileData = Encd.GetString(ArgVal, StPost, StSize);
                StPost += result;
            }

            return 0;
        }

        /// <summary>
        /// 受信データ取得（HT間通信プログラム用）
        /// </summary>
        /// <remarks></remarks>
        public byte[] RelayGetOutArg()
        {
            byte[] rcvval = new byte[] { };
            byte[] buf = null;
            Int32 stpost = 0;

            //処理結果
            string damRetVal = RetVal.ToString().PadLeft(2, '0');
            buf = Encd.GetBytes(damRetVal);
            stpost += 0;
            Array.Resize(ref rcvval, rcvval.Length + RetValLen);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, RetValLen);
            RetVal = damRetVal;

            buf = Encd.GetBytes(clsBtConst.HT_MSG_CRLF);
            stpost += RetValLen;
            Array.Resize(ref rcvval, rcvval.Length + clsBtConst.HT_MSG_CRLF_LEN);
            Buffer.BlockCopy(buf, 0, rcvval, stpost, clsBtConst.HT_MSG_CRLF_LEN);

            return rcvval;
        }


    }
}
