using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// インポート対象項目設定のコントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : インポート設定にて設定内容をコントロールするクラスです。</br>
    /// <br>Programmer : 30517 夏野 駿希</br>
    /// <br>Date       : 2010/03/31</br>
    /// </remarks>
    [Serializable]
    public class SetUpControlInfo
    {
        #region プライベートメンバ
        private string _fileName;
        private string _itemName;
        private int _itemId;
        private int _updateDiv = 0;
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SetUpControlInfo()
        {
        }
        #endregion

        #region プロパティ
        /// <summary>ファイル名</summary>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// <summary>項目名</summary>
        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }

        /// <summary>項目ID</summary>
        public int ItemId
        {
            get { return _itemId; }
            set { _itemId = value; }
        }

        /// <summary>項目更新区分</summary>
        public int UpdateDiv
        {
            get { return _updateDiv; }
            set { _updateDiv = value; }
        }
        #endregion
    }
}
