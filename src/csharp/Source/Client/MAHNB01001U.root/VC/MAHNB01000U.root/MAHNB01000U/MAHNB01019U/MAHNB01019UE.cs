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
    /// �w�b�_�[���t�H�[�J�X�ړ��ݒ胊�X�g�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �w�b�_�[���̃t�H�[�J�X�ړ����Ǘ����郊�X�g�N���X�ł��B</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2007.11.06</br>
    /// <br></br>
    /// </remarks>
    public class HeaderFocusConstructionList
    {
        public List<HeaderFocusConstruction> headerFocusConstruction = new List<HeaderFocusConstruction>();
    }
    
    /// <summary>
    /// �w�b�_�[���t�H�[�J�X�ړ��ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �w�b�_�[���̃t�H�[�J�X�ړ����Ǘ�����N���X�ł��B</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2007.11.06</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2009.06.17 21024 ���X�� �� MANTIS[0013490] �R���X�g���N�^�̒ǉ�</br>
    /// </remarks>
    [Serializable]
    public class HeaderFocusConstruction
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private string _key;
        private string _caption;
        private bool _enterStop;
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// �w�b�_�[���t�H�[�J�X�ړ��ݒ�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �w�b�_�[���t�H�[�J�X�ړ��ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 20056 ���n ���</br>
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
        /// �w�b�_�[���t�H�[�J�X�ړ��ݒ�N���X
        /// </summary>
        /// <param name="key">�L�[</param>
        /// <param name="caption">�L���v�V����</param>
        /// <param name="enterStop">�ړ��L��</param>
        /// <remarks>
        /// <br>Note       : �w�b�_�[���t�H�[�J�X�ړ��ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
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
        // �v���p�e�B
        // ===================================================================================== //
        # region Properties
        /// <summary>�L�[</summary>
        public string Key
        {
            get { return this._key; }
            set { this._key = value; }
        }
        /// <summary>���ڕ\������</summary>
        public string Caption
        {
            get { return this._caption; }
            set { this._caption = value; }
        }
        /// <summary>�ړ��L��</summary>
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
    /// �t�b�^���t�H�[�J�X�ړ��ݒ胊�X�g�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �t�b�^���̃t�H�[�J�X�ړ����Ǘ����郊�X�g�N���X�ł��B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2009.12.23</br>
    /// <br></br>
    /// </remarks>
    public class FooterFocusConstructionList
    {
        public List<FooterFocusConstruction> footerFocusConstruction = new List<FooterFocusConstruction>();
    }

    /// <summary>
    /// �t�b�^���t�H�[�J�X�ړ��ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �t�b�^���̃t�H�[�J�X�ړ����Ǘ�����N���X�ł��B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2009.12.23</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class FooterFocusConstruction
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private string _key;
        private string _caption;
        private bool _enterStop;
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// �t�b�^���t�H�[�J�X�ړ��ݒ�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t�b�^���t�H�[�J�X�ړ��ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.12.23</br>
        /// </remarks>
        public FooterFocusConstruction()
        {
            this._key = string.Empty;
            this._caption = string.Empty;
            this._enterStop = true;
        }

        /// <summary>
        /// �t�b�^���t�H�[�J�X�ړ��ݒ�N���X
        /// </summary>
        /// <param name="key">�L�[</param>
        /// <param name="caption">�L���v�V����</param>
        /// <param name="enterStop">�ړ��L��</param>
        /// <remarks>
        /// <br>Note       : �t�b�^���t�H�[�J�X�ړ��ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���M</br>
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
        // �v���p�e�B
        // ===================================================================================== //
        # region Properties
        /// <summary>�L�[</summary>
        public string Key
        {
            get { return this._key; }
            set { this._key = value; }
        }
        /// <summary>���ڕ\������</summary>
        public string Caption
        {
            get { return this._caption; }
            set { this._caption = value; }
        }
        /// <summary>�ړ��L��</summary>
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
    /// �t�b�^���t�H�[�J�X�ړ��ݒ胊�X�g�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �t�b�^���̃t�H�[�J�X�ړ����Ǘ����郊�X�g�N���X�ł��B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2009.12.23</br>
    /// <br></br>
    /// </remarks>
    public class FunctionConstructionList
    {
        public List<FunctionConstruction> functionConstruction = new List<FunctionConstruction>();
    }

    /// <summary>
    /// �t�b�^���t�H�[�J�X�ړ��ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �t�b�^���̃t�H�[�J�X�ړ����Ǘ�����N���X�ł��B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2009.12.23</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class FunctionConstruction
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private string _key;
        private string _caption;
        private bool _checked;
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// �t�b�^���t�H�[�J�X�ړ��ݒ�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t�b�^���t�H�[�J�X�ړ��ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.12.23</br>
        /// </remarks>
        public FunctionConstruction()
        {
            this._key = string.Empty;
            this._caption = string.Empty;
            this._checked = true;
        }

        /// <summary>
        /// �t�b�^���t�H�[�J�X�ړ��ݒ�N���X
        /// </summary>
        /// <param name="key">�L�[</param>
        /// <param name="caption">�L���v�V����</param>
        /// <param name="enterStop">�ړ��L��</param>
        /// <remarks>
        /// <br>Note       : �t�b�^���t�H�[�J�X�ړ��ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���M</br>
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
        // �v���p�e�B
        // ===================================================================================== //
        # region Properties
        /// <summary>�L�[</summary>
        public string Key
        {
            get { return this._key; }
            set { this._key = value; }
        }
        /// <summary>���ڕ\������</summary>
        public string Caption
        {
            get { return this._caption; }
            set { this._caption = value; }
        }
        /// <summary>�ړ��L��</summary>
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
    /// �t�b�^���t�H�[�J�X�ړ��ݒ胊�X�g�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �t�b�^���̃t�H�[�J�X�ړ����Ǘ����郊�X�g�N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2010/08/13</br>
    /// <br></br>
    /// </remarks>
    public class FunctionDetailConstructionList
    {
        public List<FunctionDetailConstruction> functionDetailConstruction = new List<FunctionDetailConstruction>();
    }

    /// <summary>
    /// �t�b�^���t�H�[�J�X�ړ��ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �t�b�^���̃t�H�[�J�X�ړ����Ǘ�����N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2010/08/13</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class FunctionDetailConstruction
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private string _key;
        private string _caption;
        private bool _checked;
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// �t�b�^���t�H�[�J�X�ړ��ݒ�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t�b�^���t�H�[�J�X�ړ��ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/13</br>
        /// </remarks>
        public FunctionDetailConstruction()
        {
            this._key = string.Empty;
            this._caption = string.Empty;
            this._checked = true;
        }

        /// <summary>
        /// �t�b�^���t�H�[�J�X�ړ��ݒ�N���X
        /// </summary>
        /// <param name="key">�L�[</param>
        /// <param name="caption">�L���v�V����</param>
        /// <param name="enterStop">�ړ��L��</param>
        /// <remarks>
        /// <br>Note       : �t�b�^���t�H�[�J�X�ړ��ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 杍^</br>
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
        // �v���p�e�B
        // ===================================================================================== //
        # region Properties
        /// <summary>�L�[</summary>
        public string Key
        {
            get { return this._key; }
            set { this._key = value; }
        }
        /// <summary>���ڕ\������</summary>
        public string Caption
        {
            get { return this._caption; }
            set { this._caption = value; }
        }
        /// <summary>�ړ��L��</summary>
        public bool Checked
        {
            get { return this._checked; }
            set { this._checked = value; }
        }
        # endregion
    }
    // --- ADD 2010/08/13 ----------<<<<<
}
