using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    [Serializable]
    /// <summary>
    /// ヘッダー部フォーカス移動設定リストクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ヘッダー部のフォーカス移動を管理するリストクラスです。</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2007.11.06</br>
    /// <br></br>
    /// </remarks>
    public class HeaderFocusConstructionList
    {
        public List<HeaderFocusConstruction> headerFocusConstruction = new List<HeaderFocusConstruction>();
    }
    
    /// <summary>
    /// ヘッダー部フォーカス移動設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ヘッダー部のフォーカス移動を管理するクラスです。</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2007.11.06</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2009.06.17 21024 佐々木 健 MANTIS[0013490] コンストラクタの追加</br>
    /// </remarks>
    [Serializable]
    public class HeaderFocusConstruction
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private string _key;
        private string _caption;
        private bool _enterStop;
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// ヘッダー部フォーカス移動設定クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : ヘッダー部フォーカス移動設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 20056 對馬 大輔</br>
        /// <br>Date       : 2007.11.06</br>
        /// </remarks>
        public HeaderFocusConstruction()
        {
            this._key = string.Empty;
            this._caption = string.Empty;
            this._enterStop = true;
        }

        // 2009.06.17 Add >>>

        /// <summary>
        /// ヘッダー部フォーカス移動設定クラス
        /// </summary>
        /// <param name="key">キー</param>
        /// <param name="caption">キャプション</param>
        /// <param name="enterStop">移動有無</param>
        /// <remarks>
        /// <br>Note       : ヘッダー部フォーカス移動設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2009.06.17</br>
        /// </remarks>
        public HeaderFocusConstruction(string key, string caption, bool enterStop)
        {
            this._key = key;
            this._caption = caption;
            this._enterStop = enterStop;
        }
        // 2009.06.17 Add <<<
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region Properties
        /// <summary>キー</summary>
        public string Key
        {
            get { return this._key; }
            set { this._key = value; }
        }
        /// <summary>項目表示名称</summary>
        public string Caption
        {
            get { return this._caption; }
            set { this._caption = value; }
        }
        /// <summary>移動有無</summary>
        public bool EnterStop
        {
            get { return this._enterStop; }
            set { this._enterStop = value; }
        }
        # endregion
    }

    // --- ADD 2009/12/23 ---------->>>>>
    [Serializable]
    /// <summary>
    /// フッタ部フォーカス移動設定リストクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : フッタ部のフォーカス移動を管理するリストクラスです。</br>
    /// <br>Programmer : 張凱</br>
    /// <br>Date       : 2009.12.23</br>
    /// <br></br>
    /// </remarks>
    public class FooterFocusConstructionList
    {
        public List<FooterFocusConstruction> footerFocusConstruction = new List<FooterFocusConstruction>();
    }

    /// <summary>
    /// フッタ部フォーカス移動設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : フッタ部のフォーカス移動を管理するクラスです。</br>
    /// <br>Programmer : 張凱</br>
    /// <br>Date       : 2009.12.23</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class FooterFocusConstruction
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private string _key;
        private string _caption;
        private bool _enterStop;
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// フッタ部フォーカス移動設定クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : フッタ部フォーカス移動設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.12.23</br>
        /// </remarks>
        public FooterFocusConstruction()
        {
            this._key = string.Empty;
            this._caption = string.Empty;
            this._enterStop = true;
        }

        /// <summary>
        /// フッタ部フォーカス移動設定クラス
        /// </summary>
        /// <param name="key">キー</param>
        /// <param name="caption">キャプション</param>
        /// <param name="enterStop">移動有無</param>
        /// <remarks>
        /// <br>Note       : フッタ部フォーカス移動設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.12.23</br>
        /// </remarks>
        public FooterFocusConstruction(string key, string caption, bool enterStop)
        {
            this._key = key;
            this._caption = caption;
            this._enterStop = enterStop;
        }
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region Properties
        /// <summary>キー</summary>
        public string Key
        {
            get { return this._key; }
            set { this._key = value; }
        }
        /// <summary>項目表示名称</summary>
        public string Caption
        {
            get { return this._caption; }
            set { this._caption = value; }
        }
        /// <summary>移動有無</summary>
        public bool EnterStop
        {
            get { return this._enterStop; }
            set { this._enterStop = value; }
        }
        # endregion
    }
    // --- ADD 2009/12/23 ----------<<<<<

    // --- ADD 2010/07/06 ---------->>>>>
    [Serializable]
    /// <summary>
    /// フッタ部フォーカス移動設定リストクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : フッタ部のフォーカス移動を管理するリストクラスです。</br>
    /// <br>Programmer : 張凱</br>
    /// <br>Date       : 2009.12.23</br>
    /// <br></br>
    /// </remarks>
    public class FunctionConstructionList
    {
        public List<FunctionConstruction> functionConstruction = new List<FunctionConstruction>();
    }

    /// <summary>
    /// フッタ部フォーカス移動設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : フッタ部のフォーカス移動を管理するクラスです。</br>
    /// <br>Programmer : 張凱</br>
    /// <br>Date       : 2009.12.23</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class FunctionConstruction
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private string _key;
        private string _caption;
        private bool _checked;
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// フッタ部フォーカス移動設定クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : フッタ部フォーカス移動設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.12.23</br>
        /// </remarks>
        public FunctionConstruction()
        {
            this._key = string.Empty;
            this._caption = string.Empty;
            this._checked = true;
        }

        /// <summary>
        /// フッタ部フォーカス移動設定クラス
        /// </summary>
        /// <param name="key">キー</param>
        /// <param name="caption">キャプション</param>
        /// <param name="enterStop">移動有無</param>
        /// <remarks>
        /// <br>Note       : フッタ部フォーカス移動設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.12.23</br>
        /// </remarks>
        public FunctionConstruction(string key, string caption, bool checkedValue)
        {
            this._key = key;
            this._caption = caption;
            this._checked = checkedValue;
        }
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region Properties
        /// <summary>キー</summary>
        public string Key
        {
            get { return this._key; }
            set { this._key = value; }
        }
        /// <summary>項目表示名称</summary>
        public string Caption
        {
            get { return this._caption; }
            set { this._caption = value; }
        }
        /// <summary>移動有無</summary>
        public bool Checked
        {
            get { return this._checked; }
            set { this._checked = value; }
        }
        # endregion
    }
    // --- ADD 2010/07/06 ----------<<<<<

    // --- ADD 2010/08/13 ---------->>>>>
    [Serializable]
    /// <summary>
    /// フッタ部フォーカス移動設定リストクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : フッタ部のフォーカス移動を管理するリストクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2010/08/13</br>
    /// <br></br>
    /// </remarks>
    public class FunctionDetailConstructionList
    {
        public List<FunctionDetailConstruction> functionDetailConstruction = new List<FunctionDetailConstruction>();
    }

    /// <summary>
    /// フッタ部フォーカス移動設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : フッタ部のフォーカス移動を管理するクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2010/08/13</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class FunctionDetailConstruction
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private string _key;
        private string _caption;
        private bool _checked;
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// フッタ部フォーカス移動設定クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : フッタ部フォーカス移動設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/13</br>
        /// </remarks>
        public FunctionDetailConstruction()
        {
            this._key = string.Empty;
            this._caption = string.Empty;
            this._checked = true;
        }

        /// <summary>
        /// フッタ部フォーカス移動設定クラス
        /// </summary>
        /// <param name="key">キー</param>
        /// <param name="caption">キャプション</param>
        /// <param name="enterStop">移動有無</param>
        /// <remarks>
        /// <br>Note       : フッタ部フォーカス移動設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/13</br>
        /// </remarks>
        public FunctionDetailConstruction(string key, string caption, bool checkedValue)
        {
            this._key = key;
            this._caption = caption;
            this._checked = checkedValue;
        }
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region Properties
        /// <summary>キー</summary>
        public string Key
        {
            get { return this._key; }
            set { this._key = value; }
        }
        /// <summary>項目表示名称</summary>
        public string Caption
        {
            get { return this._caption; }
            set { this._caption = value; }
        }
        /// <summary>移動有無</summary>
        public bool Checked
        {
            get { return this._checked; }
            set { this._checked = value; }
        }
        # endregion
    }
    // --- ADD 2010/08/13 ----------<<<<<
}
