//****************************************************************************//
// �V�X�e��         : �v�����^�ݒ�}�X�^�i�T�[�o�p�j
// �v���O��������   : �v�����^�ݒ�}�X�^�i�T�[�o�p�j�R���g���[��
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/09/16  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Data;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �T�[�o�\���ݒ�R���g���[���C���^�[�t�F�[�X
    /// </summary>
    public interface IServerConfigurationController
    {
        /// <summary>
        /// ��ƃR�[�h���擾���܂��B
        /// </summary>
        string EnterpriseCode { get; }

        /// <summary>
        /// ���_�R�[�h���擾���܂��B
        /// </summary>
        string SectionCode { get; }

        /// <summary>
        /// DB���擾���܂��B
        /// </summary>
        DataSet DBModel { get; }

        /// <summary>
        /// �f�t�H���g�r���[���擾���܂��B
        /// </summary>
        DataView DefaultView { get; }

        /// <summary>
        /// ���[�h���܂��B
        /// </summary>
        void Load();

        /// <summary>
        /// ���R�[�h�������݂܂��B
        /// </summary>
        void WriteRecord();

        /// <summary>
        /// ���R�[�h��_���폜���܂��B
        /// </summary>
        void DeleteRecord();

        /// <summary>
        /// ���R�[�h�𕜊������܂��B
        /// </summary>
        void ReviveRecord();

        /// <summary>
        /// ���R�[�h�𕨗��폜���܂��B
        /// </summary>
        void DestroyRecord();

        /// <summary>
        /// �C���|�[�g���܂��B
        /// </summary>
        void Import();

        /// <summary>�\�����X�V����C�x���g</summary>
        event UpdateViewEventHandler UpdatingView;
    }

    #region <�\���X�V�C�x���g��`>

    /// <summary>
    /// �\���X�V�C�x���g�n���h��
    /// </summary>
    /// <param name="sender">�C�x���g�\�[�X</param>
    /// <param name="e">�C�x���g�p�����[�^</param>
    public delegate void UpdateViewEventHandler(
        object sender,
        UpdateViewEventArgs e
    );

    /// <summary>
    /// �\���X�V�C�x���g�p�����[�^�N���X
    /// </summary>
    public sealed class UpdateViewEventArgs : EventArgs
    {
        #region <���ƂȂ����C�x���g�̃p�����[�^>

        /// <summary>���ƂȂ����C�x���g�̃p�����[�^</summary>
        private readonly EventArgs _innerEventArgs;
        /// <summary>���ƂȂ����C�x���g�̃p�����[�^���擾���܂��B</summary>
        public EventArgs InnerEventArgs { get { return _innerEventArgs; } }

        #endregion // </���ƂȂ����C�x���g�̃p�����[�^>

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public UpdateViewEventArgs() : this(new EventArgs()) { }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="innerEventArgs">���ƂȂ����C�x���g�̃p�����[�^</param>
        public UpdateViewEventArgs(EventArgs innerEventArgs) : base()
        {
            _innerEventArgs = innerEventArgs;
        }

        #endregion // </Constructor>
    }

    #endregion // </�\���X�V�C�x���g��`>
}
