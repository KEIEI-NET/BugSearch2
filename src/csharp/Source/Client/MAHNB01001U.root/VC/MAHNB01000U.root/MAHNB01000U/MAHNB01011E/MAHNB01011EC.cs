using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 移動先情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 明細部のフォーカス移動情報を管理するクラスです。</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2007.11.06</br>
    /// <br></br>
    /// </remarks>
    public class EnterMoveValue
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private string _key;
        private bool _enabled;
        private bool _enabledControl;
        private bool _enterStopControl;
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// 移動先情報クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 移動先情報クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 20056 對馬 大輔</br>
        /// <br>Date       : 2007.11.06</br>
        /// </remarks>
        public EnterMoveValue()
        {
            this._key = string.Empty;
            this._enabled = true;
            this._enabledControl = true;
            this._enterStopControl = true;

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
        /// <summary>表示有無</summary>
        public bool Enabled
        {
            get { return this._enabled; }
            set { this._enabled = value; }
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
        # endregion
    }
}
