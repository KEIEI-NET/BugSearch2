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
using System.Diagnostics;

using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �T�[�o�\���ݒ�R���g���[���N���X
    /// </summary>
    /// <typeparam name="TDataSet">�f�[�^�Z�b�g�̌^</typeparam>
    public abstract class ServerConfiguratorController<TDataSet> : IServerConfigurationController
        where TDataSet : DataSet, new()
    {
        #region <IServerConfigurationController �����o>

        /// <summary>��ƃR�[�h</summary>
        private readonly string _enterpriseCode;
        /// <summary>��ƃR�[�h���擾���܂��B</summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
        }

        /// <summary>
        /// ���_�R�[�h���擾���܂��B
        /// </summary>
        public string SectionCode
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// DB���擾���܂��B
        /// </summary>
        public DataSet DBModel
        {
            get { return DBEntity; }
        }

        /// <summary>
        /// �f�t�H���g�r���[���擾���܂��B
        /// </summary>
        public DataView DefaultView
        {
            get
            {
                if (DBEntity == null)
                {
                    return new TDataSet().Tables[0].DefaultView;
                }
                return DBEntity.Tables[0].DefaultView;
            }
        }

        /// <summary>
        /// ���[�h���܂��B
        /// </summary>
        public void Load()
        {
            _dbEntity = LoadOwnDB();
        }

        /// <summary>
        /// ���R�[�h��}�����܂��B
        /// </summary>
        public void WriteRecord()
        {
            WriteSelectedRecord();
        }

        /// <summary>
        /// ���R�[�h��_���폜���܂��B
        /// </summary>
        public void DeleteRecord()
        {
            DeleteSelectedRecord();
        }

        /// <summary>
        /// ���R�[�h�𕜊������܂��B
        /// </summary>
        public void ReviveRecord()
        {
            ReviveSelectedRecord();
        }

        /// <summary>
        /// ���R�[�h�𕨗��폜���܂��B
        /// </summary>
        public void DestroyRecord()
        {
            DestroySelectedRecord();
        }

        /// <summary>
        /// �C���|�[�g���܂��B
        /// </summary>
        public void Import()
        {
            _dbEntity = ImportOtherDB();
        }

        /// <summary>�\�����X�V����C�x���g</summary>
        public event UpdateViewEventHandler UpdatingView;

        #endregion // </IServerConfigurationController �����o>

        /// <summary>
        /// ���ʃR�[�h�񋓌^
        /// </summary>
        protected enum ResultCode : int
        {
            /// <summary>����</summary>
            Normal = 0
        }

        #region <DB�̎���>

        /// <summary>DB</summary>
        private TDataSet _dbEntity;
        /// <summary>DB���擾���܂��B</summary>
        public TDataSet DBEntity
        {
            get
            {
                if (_dbEntity == null)
                {
                    InitializeDB();
                }
                return _dbEntity;
            }
        }

        /// <summary>
        /// DB�����������܂��B
        /// </summary>
        private void InitializeDB()
        {
            Load();
        }

        #endregion // <DB�̎���>

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        protected ServerConfiguratorController()
        {
            _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            UpdatingView += new UpdateViewEventHandler(OnUpdateView);
        }

        #endregion // </Constructor>

        /// <summary>
        /// ���g��DB���烍�[�h���܂��B
        /// </summary>
        /// <returns>�f�[�^�Z�b�g</returns>
        protected abstract TDataSet LoadOwnDB();

        /// <summary>
        /// �I�����Ă��郌�R�[�h�������݂܂��B
        /// </summary>
        protected abstract void WriteSelectedRecord();

        /// <summary>
        /// �I�����Ă��郌�R�[�h��_���폜���܂��B
        /// </summary>
        protected abstract void DeleteSelectedRecord();

        /// <summary>
        /// �I�����Ă��郌�R�[�h�𕜊������܂��B
        /// </summary>
        protected abstract void ReviveSelectedRecord();

        /// <summary>
        /// �I�����Ă��郌�R�[�h�𕨗��폜���܂��B
        /// </summary>
        protected abstract void DestroySelectedRecord();

        /// <summary>
        /// ����DB����C���|�[�g���܂��B
        /// </summary>
        /// <returns>�f�[�^�Z�b�g</returns>
        protected abstract TDataSet ImportOtherDB();

        #region <�\���X�V>

        /// <summary>
        /// �\�����X�V����C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        protected virtual void OnUpdateView(
            object sender,
            UpdateViewEventArgs e
        )
        {
            Debug.WriteLine("�f�t�H���g�\���X�V����");
        }

        /// <summary>
        /// �\���X�V�C�x���g�𔭐������܂��B
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        protected void RaiseUpdateViewEvent(
            object sender,
            UpdateViewEventArgs e
        )
        {
            UpdatingView(sender, e);
        }

        #endregion // </�\���X�V>
    }
}
