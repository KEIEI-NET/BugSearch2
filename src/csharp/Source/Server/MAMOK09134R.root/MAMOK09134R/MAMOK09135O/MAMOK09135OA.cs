using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���i�ʔ���ڕW�ݒ�}�X�^DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 20036�@�ē��@�떾</br>
	/// <br>Date       : 2007.04.16</br>
    /// <br></br>
    /// <br>Update Note: 2010/12/20 ������</br>
    /// <br>             ��Q���ǑΉ��P�Q��</br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IGcdSalesTargetDB
	{

		/// <summary>
		/// �w�肳�ꂽ���i�ʔ���ڕW�ݒ�}�X�^Guid�̏��i�ʔ���ڕW�ݒ�}�X�^��߂��܂�
		/// </summary>
		/// <param name="parabyte">GcdSalesTargetWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ���i�ʔ���ڕW�ݒ�}�X�^Guid�̏��i�ʔ���ڕW�ݒ�}�X�^��߂��܂�</br>
		/// <br>Programmer : 20036�@�ē��@�떾</br>
		/// <br>Date       : 2007.04.16</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// ���i�ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">GcdSalesTargetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�</br>
		/// <br>Programmer : 20036�@�ē��@�떾</br>
		/// <br>Date       : 2007.04.16</br>
		int Delete(byte[] parabyte);

		#region �J�X�^���V���A���C�Y�Ή����\�b�h
		/// <summary>
		/// ���i�ʔ���ڕW�ݒ�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
		/// </summary>
		/// <param name="gcdsalestargetWork">��������</param>
		/// <param name="paragcdsalestargetWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 20036�@�ē��@�떾</br>
		/// <br>Date       : 2007.04.16</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("MAMOK09136D","Broadleaf.Application.Remoting.ParamData.GcdSalesTargetWork")]
			out object gcdsalestargetWork,
			object paragcdsalestargetWork, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// ���i�ʔ���ڕW�ݒ�}�X�^����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="gcdsalestargetWork">GcdSalesTargetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 20036�@�ē��@�떾</br>
		/// <br>Date       : 2007.04.16</br>
        [MustCustomSerialization]
        int Write(
			[CustomSerializationMethodParameterAttribute("MAMOK09136D","Broadleaf.Application.Remoting.ParamData.GcdSalesTargetWork")]
			ref object gcdsalestargetWork
			);

		/// <summary>
		/// ���i�ʔ���ڕW�ݒ�}�X�^����_���폜���܂�
		/// </summary>
		/// <param name="gcdsalestargetWork">GcdSalesTargetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^����_���폜���܂�</br>
		/// <br>Programmer : 20036�@�ē��@�떾</br>
		/// <br>Date       : 2007.04.16</br>
        [MustCustomSerialization]
        int LogicalDelete(
			[CustomSerializationMethodParameterAttribute("MAMOK09136D","Broadleaf.Application.Remoting.ParamData.GcdSalesTargetWork")]
			ref object gcdsalestargetWork
			);

		/// <summary>
		/// �_���폜���i�ʔ���ڕW�ݒ�}�X�^���𕜊����܂�
		/// </summary>
		/// <param name="gcdsalestargetWork">GcdSalesTargetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜���i�ʔ���ڕW�ݒ�}�X�^���𕜊����܂�</br>
		/// <br>Programmer : 20036�@�ē��@�떾</br>
		/// <br>Date       : 2007.04.16</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
			[CustomSerializationMethodParameterAttribute("MAMOK09136D","Broadleaf.Application.Remoting.ParamData.GcdSalesTargetWork")]
			ref object gcdsalestargetWork
			);
		#endregion

        // ---ADD 2010/12/20--------->>>>>
        #region [WriteProc]
        /// <summary>
        /// ���i�ʔ���ڕW�ݒ�}�X�^�����X�V���܂�
        /// </summary>
        /// <param name="gcdsalestargetWork">GcdSalesTargetWork�I�u�W�F�N�g(write�p)</param>
        /// <param name="parabyte">GcdSalesTargetWork�I�u�W�F�N�g(delete�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^�����X�V���܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/12/20</br>
        [MustCustomSerialization]
        int WriteProc(
            [CustomSerializationMethodParameterAttribute("MAMOK09136D", "Broadleaf.Application.Remoting.ParamData.GcdSalesTargetWork")]
            ref object gcdsalestargetWork,
            byte[] parabyte
            );
        #endregion
        // ---ADD 2010/12/20---------<<<<<
	}
}
