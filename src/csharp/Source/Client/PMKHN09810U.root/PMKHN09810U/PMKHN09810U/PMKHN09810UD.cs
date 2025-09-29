//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率マスタインポート・エクスポートフレームクラス
// プログラム概要   : インポート・エクスポートを行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  ********-** 作成担当 : FSI菅原 庸平
// 作 成 日  2013/06/12  修正内容 : サポートツール対応、新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
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
    /// <br>Programmer : FSI菅原 庸平</br>
    /// <br>Date       : 2013/06/12</br>
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
