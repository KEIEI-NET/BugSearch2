using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �t�H�[�J�X�ݒ�\�����ڍ\����
    /// </summary>
    /// <remarks>
    /// <br>Note       : �t�H�[�J�X�ݒ荀�ڂ𐧌䂵�܂��B</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2007.10.29</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.10.29 20056 ���n ��� �V�K�쐬</br>
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
        /// �R���X�g���N�^
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

        /// <summary>�L�[�v���p�e�B</summary>
        public string KeyName
        {
            get { return this._key; }
            set { this._key = value; }
        }
        /// <summary>���̃v���p�e�B</summary>
        public string Caption
        {
            get { return this._caption; }
            set { this._caption = value; }
        }
        /// <summary>�\���L��</summary>
        public bool Enabled
        {
            get { return this._enabled; }
            set { this._enabled = value; }
        }
        /// <summary>�ړ��L��</summary>
        public bool EnterStop
        {
            get { return this._enterStop; }
            set { this._enterStop = value; }
        }
        /// <summary>�\����</summary>
        public bool EnabledControl
        {
            get { return this._enabledControl; }
            set { this._enabledControl = value; }
        }
        /// <summary>�ړ���</summary>
        public bool EnterStopControl
        {
            get { return this._enterStopControl; }
            set { this._enterStopControl = value; }
        }

    }
}
