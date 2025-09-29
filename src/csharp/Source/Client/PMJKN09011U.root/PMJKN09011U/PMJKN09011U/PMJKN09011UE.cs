using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.UIData;


namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// 列表示状態クラス拡張
    /// </summary>
    /// <remarks>
    /// <br>Note       : 列表示状態クラスの拡張クラスです。</br>
    /// <br>Programmer : 肖緒徳</br>
    /// <br>Date       : 2010.04.26</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2010.04.26 肖緒徳 新規作成</br>
    /// </remarks>
    [Serializable]
    public class ColDisplayStatusExp : ColDisplayStatus
    {

        #region Private Members
        private Int32 _labelSpan = 0;
        private Int32 _originX = 0;
        private Int32 _originY = 0;
        private Int32 _spanX = 0;
        private Int32 _spanY = 0;
        private string _moveLineKeyName = "";
        private string _moveEnterKeyName = "";
        private bool _enabled = true;
        private bool _enabledControl = true;
        private bool _enterStopControl = true;

        #endregion

        #region Constructor
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public ColDisplayStatusExp()
            : base()
        {

        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="key"></param>
        /// <param name="visiblePosition"></param>
        /// <param name="headerFixed"></param>
        /// <param name="width"></param>
        /// <param name="labelSpan"></param>
        /// <param name="originX"></param>
        /// <param name="originY"></param>
        /// <param name="spanX"></param>
        /// <param name="spanY"></param>
        /// <param name="moveLineKeyName"></param>
        /// <param name="moveEnterKeyName"></param>
        /// <param name="enabled"></param>
        /// <param name="enabledControl"></param>
        /// <param name="enterStopControl"></param>
        public ColDisplayStatusExp(string key, Int32 visiblePosition, bool headerFixed, Int32 width, Int32 labelSpan, Int32 originX, Int32 originY, Int32 spanX, Int32 spanY, string moveLineKeyName, string moveEnterKeyName, bool enabled, bool enabledControl, bool enterStopControl)
            : base(key, visiblePosition, headerFixed, width)
        {
            _labelSpan = labelSpan;
            _originX = originX;
            _originY = originY;
            _spanX = spanX;
            _spanY = spanY;
            _moveLineKeyName = moveLineKeyName;
            _moveEnterKeyName = moveEnterKeyName;
            _enabled = enabled;
            _enabledControl = enabledControl;
            _enterStopControl = enterStopControl;
        }
        #endregion

        #region Property
        /// <summary>
        /// 列ヘッダスパン有効プロパティ
        /// </summary>
        public Int32 LabelSpan
        {
            get { return _labelSpan; }
            set { _labelSpan = value; }
        }
        /// <summary>
        /// 水平座標プロパティ
        /// </summary>
        public Int32 OriginX
        {
            get { return _originX; }
            set { _originX = value; }
        }
        /// <summary>
        /// 垂直座標プロパティ
        /// </summary>
        public Int32 OriginY
        {
            get { return _originY; }
            set { _originY = value; }
        }
        /// <summary>
        /// 左右に跨るセル数プロパティ
        /// </summary>
        public Int32 SpanX
        {
            get { return _spanX; }
            set { _spanX = value; }
        }
        /// <summary>
        /// 上下に跨るセル数プロパティ
        /// </summary>
        public Int32 SpanY
        {
            get { return _spanY; }
            set { _spanY = value; }
        }
        /// <summary>
        /// 行移動項目(Rowに無関係に行間を移動する場合の移動先のKeyName)
        /// </summary>
        public string MoveLineKeyName
        {
            get { return _moveLineKeyName; }
            set { _moveLineKeyName = value; }
        }
        /// <summary>
        /// Enterキー入力時移動項目(Enterキー入力時に移動する基本移動項目)
        /// </summary>
        public string MoveEnterKeyName
        {
            get { return _moveEnterKeyName; }
            set { _moveEnterKeyName = value; }
        }
        /// <summary>
        /// 有効設定
        /// </summary>
        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }
        /// <summary>
        /// 表示可否
        /// </summary>
        public bool EnabledControl
        {
            get { return this._enabledControl; }
            set { this._enabledControl = value; }
        }
        /// <summary>
        /// 移動可否
        /// </summary>
        public bool EnterStopControl
        {
            get { return this._enterStopControl; }
            set { this._enterStopControl = value; }
        }
        #endregion

    }

}

