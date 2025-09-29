using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// フォーカス設定表示項目構造体
    /// </summary>
    /// <remarks>
    /// <br>Note       : フォーカス設定項目を制御します。</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2007.10.29</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.10.29 20056 對馬 大輔 新規作成</br>
    /// </remarks>
    internal struct DisplayTableInfo
    {
        private string _key;
        private string _caption;
        private bool _enabled;
        private bool _enterStop;
        private bool _enabledControl;
        private bool _enterStopControl;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="caption"></param>
        /// <param name="enterStop"></param>
        public DisplayTableInfo(string keyName, string caption, bool enabled, bool enterStop, bool enabledControl, bool enterStopControl)
        {
            _key = keyName;
            _caption = caption;
            _enabled = enabled;
            _enterStop = enterStop;
            _enabledControl = enabledControl;
            _enterStopControl = enterStopControl;
        }

        /// <summary>キープロパティ</summary>
        public string KeyName
        {
            get { return this._key; }
            set { this._key = value; }
        }
        /// <summary>名称プロパティ</summary>
        public string Caption
        {
            get { return this._caption; }
            set { this._caption = value; }
        }
        /// <summary>表示有無</summary>
        public bool Enabled
        {
            get { return this._enabled; }
            set { this._enabled = value; }
        }
        /// <summary>移動有無</summary>
        public bool EnterStop
        {
            get { return this._enterStop; }
            set { this._enterStop = value; }
        }
        /// <summary>表示可否</summary>
        public bool EnabledControl
        {
            get { return this._enabledControl; }
            set { this._enabledControl = value; }
        }
        /// <summary>移動可否</summary>
        public bool EnterStopControl
        {
            get { return this._enterStopControl; }
            set { this._enterStopControl = value; }
        }

    }
}
