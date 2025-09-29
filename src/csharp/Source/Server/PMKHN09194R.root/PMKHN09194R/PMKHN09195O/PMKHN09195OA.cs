//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^
// �v���O�����T�v   : �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^�@DBRemoteObject�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// �Ǘ��ԍ�  11500865-00  �쐬�S�� : 杍^
// �� �� ��  2019/09/02   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2019/09/02</br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IEmpScSalesTargetDB
    {
        #region
        /// <summary>
		/// �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">EmpSalesTargetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <remarks>
		/// <br>Note       : �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
		int Delete(byte[] parabyte);

		/// <summary>
		/// �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
		/// </summary>
		/// <param name="empsalestargetWork">��������</param>
		/// <param name="paraempsalestargetWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
        /// <remarks>
		/// <br>Note       : </br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09196D", "Broadleaf.Application.Remoting.ParamData.EmpScSalesTargetWork")]
			out object empsalestargetWork,
			object paraempsalestargetWork, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^����o�^�A�X�V���܂�
		/// </summary>
        /// <param name="empsalestargetWork">�]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <remarks>
		/// <br>Note       : �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09196D", "Broadleaf.Application.Remoting.ParamData.EmpScSalesTargetWork")]
			ref object empsalestargetWork
			);

		/// <summary>
		/// �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^����_���폜���܂�
		/// </summary>
        /// <param name="empsalestargetWork">�]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <remarks>
		/// <br>Note       : �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09196D", "Broadleaf.Application.Remoting.ParamData.EmpScSalesTargetWork")]
			ref object empsalestargetWork
			);

		/// <summary>
		/// �_���폜�]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���𕜊����܂�
		/// </summary>
        /// <param name="empsalestargetWork">�]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <remarks>
		/// <br>Note       : �_���폜�]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09196D", "Broadleaf.Application.Remoting.ParamData.EmpScSalesTargetWork")]
			ref object empsalestargetWork
			);

        /// <summary>
        /// �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^�����X�V���܂�
        /// </summary>
        /// <param name="empsalestargetWork">�]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^���I�u�W�F�N�g(write�p)</param>
        /// <param name="parabyte">EmpSalesTargetWork�I�u�W�F�N�g(delete�p)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�}�X�^�����X�V���܂�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        [MustCustomSerialization]
        int WriteProc(
            [CustomSerializationMethodParameterAttribute("PMKHN09196D", "Broadleaf.Application.Remoting.ParamData.EmpScSalesTargetWork")]
            ref object empsalestargetWork,
            byte[] parabyte
            );
        #endregion
	}
}
