using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   TrimCdRetWork
    /// <summary>
    ///                      トリム抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   トリム抽出結果クラスワークヘッダファイル</br>
	/// <br>Programmer       :   30290</br>
	/// <br>Date             :   2008/06/04</br>
	/// <br>Update Note      :   </br>
    /// </remarks>
    public class TrimCdRetWork
    {
        /// <summary>トリムコード</summary>
        private string _trimCode = "";

        /// <summary>トリム名称</summary>
        private string _trimName = "";

        /// public propaty name  :  TrimCode
        /// <summary>トリムコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   トリムコードプロパティ</br>
        /// </remarks>
        public string TrimCode
        {
            get { return _trimCode; }
            set { _trimCode = value; }
        }

        /// public propaty name  :  TrimName
        /// <summary>トリム名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   トリム名称プロパティ</br>
        /// </remarks>
        public string TrimName
        {
            get { return _trimName; }
            set { _trimName = value; }
        }


        /// <summary>
        /// トリム抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>TrimCdRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TrimCdRetWorkクラスの新しいインスタンスを生成します</br>
        /// </remarks>
        public TrimCdRetWork()
        {
        }

    }
}
