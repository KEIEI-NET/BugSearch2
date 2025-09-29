using System;
using System.Collections;

//using Broadleaf.Library.Data;  // DEL caohh 2011/08/17
using Broadleaf.Library.Runtime.Serialization;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   FrePSalesSlipWork
    /// <summary>
    ///                      自由帳票見積書補足データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   自由帳票見積書補足データワークヘッダファイル</br>
    /// <br>Programmer       :   22018 鈴木正臣</br>
    /// <br>Date             :   2008/10/03</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FrePEstFmParaWork
    {
        /// <summary>企業コード</summary>
        private string _enterpriseCode;
        /// <summary>拠点コード</summary>
        private string _sectionCode;
        /// <summary>
        /// 企業コード
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        /// <summary>
        /// 拠点コード
        /// </summary>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FrePEstFmParaWork()
        {
        }
    }

}
