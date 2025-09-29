using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    # region [LogData]
    /// <summary>
    /// 内部的にログ出力予定の内容情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 内部的にログ出力予定の内容情報クラスです。</br>
    /// <br>Programmer : 曹文傑</br>
    /// <br>Date       : 2011/02/11</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class LogData
    {
        /// <summary>日時</summary>
        private Int64 _sysDateTime;
        /// <summary>ログ番号</summary>
        private Byte _logNo;
        /// <summary>売上伝票番号</summary>
        private Int32 _salesSlipNo;
        /// <summary>受注ステータス</summary>
        private Byte _acptAnOdrStatus;

        /// <summary>
        /// 日時
        /// </summary>
        public Int64 SysDateTime
        {
            get { return _sysDateTime; }
            set { _sysDateTime = value; }
        }
        /// <summary>
        /// ログ番号
        /// </summary>
        public Byte LogNo
        {
            get { return _logNo; }
            set { _logNo = value; }
        }
        /// <summary>
        /// 売上伝票番号
        /// </summary>
        public Int32 SalesSlipNo
        {
            get { return _salesSlipNo; }
            set { _salesSlipNo = value; }
        }
        /// <summary>
        /// 受注ステータス
        /// </summary>
        public Byte AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public LogData()
        {
        }
    }
    # endregion

}
