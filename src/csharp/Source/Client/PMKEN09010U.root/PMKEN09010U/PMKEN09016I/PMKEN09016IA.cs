using System;
using System.Text;

namespace Broadleaf.Application.Common
{
    # region Delegate
    /// <summary>�^�u�؂�ւ��C�x���g�p�f���Q�[�g</summary>
    public delegate void MainTabChangeEventHandler(object sender, int TabIndex);
    /// <summary>���C���t���[���ʒm�C�x���g�p�f���Q�[�g</summary>
    public delegate void FrameNotifyEventHandler(object sender, int TabIndex, string key);
    # endregion

    #region �@���ʃC���^�[�t�F�[�X
    /// <summary>
    ///  �@���ʃC���^�[�t�F�[�X
    /// </summary>
    public interface IPrimeSettingController
    {
        object objPrimeSettingController { get; set;}
        void MainTabIndexChange(object sender, int TabIndex);
        void FrameNotifyEvent(object sender, int TabIndex, string key);
    }
    #endregion

    // ADD 2008/10/29 �s��Ή�[6962] �d�l�ύX ---------->>>>>
    /// <summary>
    /// �ۑ��\�����肷��C���^�[�t�F�[�X
    /// </summary>
    public interface IPrimeSettingCheckable
    {
        /// <summary>
        /// �ۑ��\�����肵�܂��B
        /// </summary>
        /// <param name="errorMessage">�G���[���b�Z�[�W</param>
        /// <returns>
        /// <c>true</c> :�ۑ��\<br/>
        /// <c>false</c>:�ۑ��s�\
        /// </returns>
        bool CanSave(out string errorMessage);
    }

    #region <�D�ǐݒ�p���l/>

    /// <summary>
    /// �D�ǐݒ�p���l�̒l���ω������Ƃ��̃C�x���g�p�����[�^�N���X
    /// </summary>
    public sealed class NoteChangedEventArgs : EventArgs
    {
        #region <�����ރR�[�h/>

        /// <summary>�����ރR�[�h</summary>
        private readonly int _middleCode;
        /// <summary>
        /// �����ރR�[�h���擾���܂��B
        /// </summary>
        /// <value>�����ރR�[�h</value>
        public int MiddleCode
        {
            get { return _middleCode; }
        }

        #endregion  // <�����ރR�[�h/>

        #region <BL�R�[�h/>

        /// <summary>BL�R�[�h</summary>
        private readonly int _blCode;
        /// <summary>
        /// BL�R�[�h���擾���܂��B
        /// </summary>
        /// <value>BL�R�[�h</value>
        public int BLCode
        {
            get { return _blCode; }
        }

        #endregion  // <BL�R�[�h/>

        #region <���[�J�[�R�[�h/>

        /// <summary>���[�J�[�R�[�h</summary>
        private readonly int _makerCode;
        /// <summary>
        /// ���[�J�[�R�[�h���擾���܂��B
        /// </summary>
        /// <value>���[�J�[�R�[�h</value>
        public int MakerCode
        {
            get { return _makerCode; }
        }

        #endregion  // <���[�J�[�R�[�h/>

        #region <�D�ǐݒ�p���l/>

        /// <summary>�D�ǐݒ�p���l�̃e�L�X�g</summary>
        private readonly string _noteText;
        /// <summary>
        /// �D�ǐݒ�p���l�̃e�L�X�g���擾���܂��B
        /// </summary>
        /// <value>�D�ǐݒ�p���l�̃e�L�X�g</value>
        public string NoteText
        {
            get { return _noteText; }
        }

        #endregion  // <�D�ǐݒ�p���l/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="middleCode">�����ރR�[�h</param>
        /// <param name="blCode">BL�R�[�h</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="noteText">�D�ǐݒ�p���l�̃e�L�X�g</param>
        public NoteChangedEventArgs(
            int middleCode,
            int blCode,
            int makerCode,
            string noteText
        )
        {
            _middleCode = middleCode;
            _blCode     = blCode;
            _makerCode  = makerCode;
            _noteText   = noteText;
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// ������ɕϊ����܂��B
        /// </summary>
        /// <returns>���[�J�[�F0000/�����ށF0000/BL�F0000</returns>
        public override string ToString()
        {
            const string SEPARATOR = "/";

            StringBuilder ret = new StringBuilder();

            ret.Append("���[�J�[:").Append(MakerCode.ToString("0000"));
            ret.Append(SEPARATOR);
            ret.Append("������:").Append(MiddleCode.ToString("0000"));
            ret.Append(SEPARATOR);
            ret.Append("BL:").Append(BLCode.ToString("0000"));

            return ret.ToString();
        }
    }

    /// <summary>
    /// �D�ǐݒ�p���l�̒l���ω������Ƃ��̃C�x���g�n���h��
    /// </summary>
    /// <param name="sender">�C�x���g�\�[�X</param>
    /// <param name="e">�C�x���g�p�����[�^</param>
    public delegate void NoteChangedEventHandler(
        object sender,
        NoteChangedEventArgs e
    );

    /// <summary>
    /// �D�ǐݒ�p���l�̊Ǘ��C���^�[�t�F�[�X
    /// </summary>
    public interface IPrimeSettingNoteChanger
    {
        /// <summary>�D�ǐݒ�p���l���ω������Ƃ��̃C�x���g</summary>
        event NoteChangedEventHandler NoteChanged;
    }

    /// <summary>
    /// �D�ǐݒ�p���l�̒l���ω������Ƃ��̃C�x���g�n���h���C���^�[�t�F�[�X
    /// </summary>
    public interface IPrimeSettingNoteChangedEventHandler
    {
        /// <summary>
        /// �D�ǐݒ�p���l�̒l���ω������Ƃ��̃C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        void PrimeSettingNoteChanged(
            object sender,
            NoteChangedEventArgs e
        );
    }

    #endregion  // <�D�ǐݒ�p���l/>
    // ADD 2008/10/29 �s��Ή�[6962] �d�l�ύX ----------<<<<<
}