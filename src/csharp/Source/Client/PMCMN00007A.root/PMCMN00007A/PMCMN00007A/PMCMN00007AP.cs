//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �}�X�^�����e�i���X
// �v���O�����T�v   : �}�X�^�����e�i���X�̐���S�ʂ��s���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �C �� ��  2008/09/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���쌠���ɉ������{�^������p�C���^�[�t�F�[�X
    /// </summary>
    public interface IOperationAuthorityControllable
    {
        /// <summary>
        /// ���쌠���̐ݒ�ɏ]���āA�R���g���[���𐧌䂷��I�u�W�F�N�g�ɃA�N�Z�X���܂��B
        /// </summary>
        OperationAuthorityController OperationController
        {
            get;
            set;
        }
    }

    #region <����/>

    /// <summary>
    /// ���쌠���ɉ������{�^������p�C���^�[�t�F�[�X�̎����N���X
    /// </summary>
    /// <typeparam name="TOperationAuthorityController">���쌠���̐���N���X</typeparam>
    public sealed class OperationAuthorityControllableImpl<TOperationAuthorityController>
        : IOperationAuthorityControllable
        where TOperationAuthorityController : OperationAuthorityController
    {
        #region <IOperationAuthorityControllable �����o/>

        /// <see cref="IOperationAuthorityControllable"/>
        public OperationAuthorityController OperationController
        {
            get { return _operationController; }
            set { _operationController = value; }
        }

        #endregion  // <IOperationAuthorityControllable �����o/>

        /// <summary>���쌠���̐���I�u�W�F�N�g</summary>
        private OperationAuthorityController _operationController;
        /// <summary>
        /// ���쌠���̐���I�u�W�F�N�g���擾���܂��B�i<c>TOperationAuthorityController</c>�Ń_�E���L���X�g�j
        /// </summary>
        /// <value>���쌠���̐���I�u�W�F�N�g�i<c>TOperationAuthorityController</c>�Ń_�E���L���X�g�j</value>
        /// <exception cref="InvalidCastException">���쌠���̐���I�u�W�F�N�g�̌^�������Ă��܂���B</exception>
        public TOperationAuthorityController MyOpeCtrl
        {
            get { return (TOperationAuthorityController)_operationController; }
        }

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public OperationAuthorityControllableImpl() { }
    }

    #endregion  // <����/>

    #region <�R���N�V����/>

    /// <summary>
    /// ���쌠���̐���I�u�W�F�N�g�̃}�b�v�N���X
    /// </summary>
    /// <remarks>�L�[�F�v���O����ID�܂��̓A�Z���u��ID</remarks>
    /// <typeparam name="TOperationAuthorityController">���쌠���̐���N���X</typeparam>
    public sealed class OperationAuthorityControllableMap<TOperationAuthorityController>
        : Dictionary<
            string,
            OperationAuthorityControllableImpl<TOperationAuthorityController>
        >
        where TOperationAuthorityController : OperationAuthorityController
    {
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public OperationAuthorityControllableMap() : base() { }

        /// <summary>
        /// ����I�u�W�F�N�g��ǉ����܂��B
        /// </summary>
        /// <param name="assemblyId">�A�Z���u��ID�܂��̓v���O����ID</param>
        /// <returns>�ǉ���������I�u�W�F�N�g</returns>
        public IOperationAuthorityControllable AddController(string assemblyId)
        {
            if (!base.ContainsKey(assemblyId))
            {
                base.Add(assemblyId, new OperationAuthorityControllableImpl<TOperationAuthorityController>());
            }
            return base[assemblyId];
        }
    }

    #endregion  // <�R���N�V����/>

    #region <�t�H�[��/>

    /// <summary>
    /// ���쌠���̐���I�u�W�F�N�g�����t�H�[��
    /// </summary>
    /// <typeparam name="TOperationAuthorityController">���쌠���̐���N���X</typeparam>
    public class OperationAuthorityControllableForm<TOperationAuthorityController>
        : System.Windows.Forms.Form,
        IOperationAuthorityControllable
        where TOperationAuthorityController : OperationAuthorityController
    {
        #region <IOperationAuthorityControllable �����o/>

        /// <see cref="IOperationAuthorityControllable"/>
        public OperationAuthorityController OperationController
        {
            get { return _operationController; }
            set { _operationController = value; }
        }

        #endregion  // <IOperationAuthorityControllable �����o/>

        /// <summary>���쌠���̐���I�u�W�F�N�g</summary>
        private OperationAuthorityController _operationController;
        /// <summary>
        /// ���쌠���̐���I�u�W�F�N�g���擾���܂��B
        /// </summary>
        /// <value>���쌠���̐���I�u�W�F�N�g</value>
        /// <exception cref="InvalidCastException">���쌠���̐���I�u�W�F�N�g�̌^�������Ă��܂���B</exception>
        protected TOperationAuthorityController MyOpeCtrl
        {
            get { return (TOperationAuthorityController)_operationController; }
        }

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        protected OperationAuthorityControllableForm() : base() { }
    }

    #endregion  // <�t�H�[��/>
}
