using System;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PrimeSetting
    {
        /// <summary>
        /// 
        /// </summary>
        public enum RowStatus : int
        {
            /// <summary>なし</summary>
            None,
            /// <summary>更新</summary>
            Updating,
            /// <summary>削除</summary>
            Deleting
        }
    }
}
