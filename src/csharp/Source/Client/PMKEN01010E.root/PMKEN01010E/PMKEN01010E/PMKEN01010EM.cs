using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   ColorCdRetWork
    /// <summary>
    ///                      カラー抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   カラー抽出結果クラスワークヘッダファイル</br>
	/// <br>Programmer       :   30290</br>
	/// <br>Date             :   2008/06/04</br>
	/// <br>Update Note      :   </br>
    /// </remarks>
    public class ColorCdRetWork
    {
        /// <summary>カラーコード</summary>
        /// <remarks>カタログの色コード</remarks>
        private string _colorCode = "";

        /// <summary>カラーコード重複時枝番</summary>
        private Int32 _colorCdDupDerivedNo;

        /// <summary>カラー名称1</summary>
        /// <remarks>画面表示用正式名称</remarks>
        private string _colorName = "";

        /// public propaty name  :  ColorCode
        /// <summary>カラーコードプロパティ</summary>
        /// <value>カタログの色コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カラーコードプロパティ</br>
        /// </remarks>
        public string ColorCode
        {
            get { return _colorCode; }
            set { _colorCode = value; }
        }

        /// public propaty name  :  ColorCdDupDerivedNo
        /// <summary>カラーコード重複時枝番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カラーコード重複時枝番プロパティ</br>
        /// </remarks>
        public Int32 ColorCdDupDerivedNo
        {
            get { return _colorCdDupDerivedNo; }
            set { _colorCdDupDerivedNo = value; }
        }

        /// public propaty name  :  ColorName
        /// <summary>カラー名称プロパティ</summary>
        /// <value>画面表示用正式名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カラー名称プロパティ</br>
        /// </remarks>
        public string ColorName
        {
            get { return _colorName; }
            set { _colorName = value; }
        }


        /// <summary>
        /// カラー抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>ColorCdRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ColorCdRetWorkクラスの新しいインスタンスを生成します</br>
        /// </remarks>
        public ColorCdRetWork()
        {
        }

    }
}
