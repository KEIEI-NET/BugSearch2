using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �d�_�i�ڐݒ�}�X�^DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �d�_�i�ڐݒ�}�X�^DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 30350�@�N��@����</br>
	/// <br>Date       : 2009.04.28</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IImportantPrtStDB
	{
		/// <summary>
        /// �w�肳�ꂽ�d�_�i�ڐݒ�}�X�^Guid�̏d�_�i�ڐݒ�}�X�^��߂��܂�
		/// </summary>
		/// <param name="parabyte">StockMngTtlStWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�d�_�i�ڐݒ�}�X�^Guid�̏d�_�i�ڐݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.28</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
        /// �d�_�i�ڐݒ�}�X�^���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">StockMngTtlStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : �d�_�i�ڐݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.28</br>
		int Delete(byte[] parabyte);

		#region �J�X�^���V���A���C�Y�Ή����\�b�h
		/// <summary>
        /// �d�_�i�ڐݒ�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
		/// </summary>
        /// <param name="importantPrtStWork">��������</param>
        /// <param name="paraimportantPrtStWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.28</br>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09557D", "Broadleaf.Application.Remoting.ParamData.ImportantPrtStWork")]
			out object importantPrtStWork,
           object paraimportantPrtStWork, int readMode, ConstantManagement.LogicalMode logicalMode);

		/// <summary>
        /// �d�_�i�ڐݒ�}�X�^����o�^�A�X�V���܂�
		/// </summary>
        /// <param name="importantPrtStWork">StockMngTtlStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : �d�_�i�ڐݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.28</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09557D", "Broadleaf.Application.Remoting.ParamData.ImportantPrtStWork")]
			ref object importantPrtStWork
			);

		/// <summary>
        /// �d�_�i�ڐݒ�}�X�^����_���폜���܂�
		/// </summary>
        /// <param name="importantPrtStWork">StockMngTtlStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : �d�_�i�ڐݒ�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.28</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09557D", "Broadleaf.Application.Remoting.ParamData.ImportantPrtStWork")]
			ref object importantPrtStWork
			);

		/// <summary>
        /// �_���폜�d�_�i�ڐݒ�}�X�^���𕜊����܂�
		/// </summary>
        /// <param name="importantPrtStWork">StockMngTtlStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�d�_�i�ڐݒ�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.28</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09557D", "Broadleaf.Application.Remoting.ParamData.ImportantPrtStWork")]
			ref object importantPrtStWork
			);
		#endregion
	}
}
