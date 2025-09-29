using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;


namespace Broadleaf.Application.Common
{
    /// <summary>
    /// 簡単問合せ接続情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 簡単問合せ接続情報のデータクラスです。</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2010/03/25</br>
    /// </remarks>
    [Serializable]
    public class SimplInqCnectInfo
    {
        #region ■ Constructor
        /// <summary>
        /// 
        /// </summary>
        public SimplInqCnectInfo()
        {

        }
        #endregion

        #region ■ Private Member
        private int _cashRegisterNo;
        private int _customerCode;
        #endregion

        #region ■ Property

        /// <summary>レジ番号（端末番号）</summary>
        public int CashRegisterNo
        {
            get { return _cashRegisterNo; }
            set { _cashRegisterNo = value; }
        }

        /// <summary>得意先コード</summary>
        public int CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }
        #endregion
    }
}
