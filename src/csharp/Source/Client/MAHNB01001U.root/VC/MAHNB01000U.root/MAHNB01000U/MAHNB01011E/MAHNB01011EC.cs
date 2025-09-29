using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �ړ�����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���ו��̃t�H�[�J�X�ړ������Ǘ�����N���X�ł��B</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2007.11.06</br>
    /// <br></br>
    /// </remarks>
    public class EnterMoveValue
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private string _key;
        private bool _enabled;
        private bool _enabledControl;
        private bool _enterStopControl;
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// �ړ�����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ړ�����N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 20056 ���n ���</br>
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
        // �v���p�e�B
        // ===================================================================================== //
        # region Properties
        /// <summary>�L�[</summary>
        public string Key
        {
            get { return this._key; }
            set { this._key = value; }
        }
        /// <summary>�\���L��</summary>
        public bool Enabled
        {
            get { return this._enabled; }
            set { this._enabled = value; }
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
        # endregion
    }
}
