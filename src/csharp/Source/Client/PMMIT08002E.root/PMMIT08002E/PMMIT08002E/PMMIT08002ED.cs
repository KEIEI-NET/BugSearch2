using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 見積書単位補足データ
    /// </summary>
    public class EstFmUnitExtraData
    {
        /// <summary>印刷部数</summary>
        private Int32 _printCount;
        /// <summary>
        /// 印刷部数
        /// </summary>
        public Int32 PrintCount
        {
            get { return _printCount; }
            set { _printCount = value; }
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="printCount"></param>
        public EstFmUnitExtraData()
        {
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="printCount">印刷部数</param>
        public EstFmUnitExtraData( Int32 printCount )
        {
            _printCount = printCount;
        }
    }
}
