using System;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// コンバートバージョン管理部品
    /// </summary>
    /// <remarks>
    /// <br>Note       : 数値変換処理のバージョン情報を保持するクラスです。</br>
    /// <br>Programmer : </br>
    /// <br>Date       : 2020/06/15</br>
    /// </remarks>
    public class ConvertVersionManager
    { 
        #region 定数

        /// <summary>
        /// バージョン情報
        /// </summary>
        private const int _convertVersionAsm = (int)ConvertVersion.CT_CONVERT_VERSION_1;

        #endregion // 定数

        #region 列挙体

        /// <summary>
        /// 変換バージョン
        /// </summary>
        public enum ConvertVersion
        {
            CT_CONVERT_VERSION_NONE = 0,
            CT_CONVERT_VERSION_1 = 1,
            CT_CONVERT_VERSION_2 = 2,
            CT_CONVERT_VERSION_3 = 3
        }

        #endregion // 列挙体

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ConvertVersionManager()
        {
        }

        #endregion // コンストラクタ

        #region プロパティ

        /// <summary>
        /// バージョン情報
        /// </summary>
        public int ConvertVersionAsm
        {
            get { return _convertVersionAsm; }
        }

        #endregion


    }
}
