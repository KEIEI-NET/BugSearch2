using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.UIData;


namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// ��\����ԃN���X�g��
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��\����ԃN���X�̊g���N���X�ł��B</br>
    /// <br>Programmer : �я���</br>
    /// <br>Date       : 2010.04.26</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2010.04.26 �я��� �V�K�쐬</br>
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
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public ColDisplayStatusExp()
            : base()
        {

        }

        /// <summary>
        /// �R���X�g���N�^
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
        /// ��w�b�_�X�p���L���v���p�e�B
        /// </summary>
        public Int32 LabelSpan
        {
            get { return _labelSpan; }
            set { _labelSpan = value; }
        }
        /// <summary>
        /// �������W�v���p�e�B
        /// </summary>
        public Int32 OriginX
        {
            get { return _originX; }
            set { _originX = value; }
        }
        /// <summary>
        /// �������W�v���p�e�B
        /// </summary>
        public Int32 OriginY
        {
            get { return _originY; }
            set { _originY = value; }
        }
        /// <summary>
        /// ���E�Ɍׂ�Z�����v���p�e�B
        /// </summary>
        public Int32 SpanX
        {
            get { return _spanX; }
            set { _spanX = value; }
        }
        /// <summary>
        /// �㉺�Ɍׂ�Z�����v���p�e�B
        /// </summary>
        public Int32 SpanY
        {
            get { return _spanY; }
            set { _spanY = value; }
        }
        /// <summary>
        /// �s�ړ�����(Row�ɖ��֌W�ɍs�Ԃ��ړ�����ꍇ�̈ړ����KeyName)
        /// </summary>
        public string MoveLineKeyName
        {
            get { return _moveLineKeyName; }
            set { _moveLineKeyName = value; }
        }
        /// <summary>
        /// Enter�L�[���͎��ړ�����(Enter�L�[���͎��Ɉړ������{�ړ�����)
        /// </summary>
        public string MoveEnterKeyName
        {
            get { return _moveEnterKeyName; }
            set { _moveEnterKeyName = value; }
        }
        /// <summary>
        /// �L���ݒ�
        /// </summary>
        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }
        /// <summary>
        /// �\����
        /// </summary>
        public bool EnabledControl
        {
            get { return this._enabledControl; }
            set { this._enabledControl = value; }
        }
        /// <summary>
        /// �ړ���
        /// </summary>
        public bool EnterStopControl
        {
            get { return this._enterStopControl; }
            set { this._enterStopControl = value; }
        }
        #endregion

    }

}

