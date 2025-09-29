using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections.Generic;

using ar = DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using Broadleaf.Library.Resources;
//using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using System.Drawing;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 自由帳票(売上伝票)個別対応用印刷クラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 自由帳票（売上伝票）の個別対応用の印刷ドキュメントを作成します。</br>
    /// <br>               パッケージ処理用のダミーファイルの為、内部は空です。</br>
    /// <br>Programmer   : 30517 夏野 駿希</br>
    /// <br>Date         : 2010/08/25</br>
    /// <br></br>
    /// </remarks>
    public class PMHNB08001PCA
    {
        #region PrivateMember

        // 2010/08/25 Add >>>
        // 個別処理を行うか判断
        // true:個別処理を行う　false:個別処理を行わない
        private static bool _customizeFlg = false;
        // 2010/08/25 Add <<<


        #endregion

        #region Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMHNB08001PCA()
        {
        }
        #endregion

        // 2010/08/25 Add >>>
        /// <summary>
        /// 個別処理を行うか判断
        /// true:個別処理を行う　false:個別処理を行わない
        /// </summary>
        public static bool CustomizeFlg
        {
            get { return _customizeFlg; }
        }
        // 2010/08/25 Add <<<
        
    }


}
