using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �݌ɊǗ��S�̐ݒ�}�X�^DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 20036�@�ē��@�떾</br>
	/// <br>Date       : 2007.03.02</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IStockMngTtlStDB
	{

		/// <summary>
		/// �w�肳�ꂽ�݌ɊǗ��S�̐ݒ�}�X�^Guid�̍݌ɊǗ��S�̐ݒ�}�X�^��߂��܂�
		/// </summary>
		/// <param name="parabyte">StockMngTtlStWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ�݌ɊǗ��S�̐ݒ�}�X�^Guid�̍݌ɊǗ��S�̐ݒ�}�X�^��߂��܂�</br>
		/// <br>Programmer : 20036�@�ē��@�떾</br>
		/// <br>Date       : 2007.03.02</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// �݌ɊǗ��S�̐ݒ�}�X�^���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">StockMngTtlStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^���𕨗��폜���܂�</br>
		/// <br>Programmer : 20036�@�ē��@�떾</br>
		/// <br>Date       : 2007.03.02</br>
		int Delete(byte[] parabyte);

		#region �J�X�^���V���A���C�Y�Ή����\�b�h
		/// <summary>
		/// �݌ɊǗ��S�̐ݒ�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
		/// </summary>
		/// <param name="stockmngttlstWork">��������</param>
		/// <param name="parastockmngttlstWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 20036�@�ē��@�떾</br>
		/// <br>Date       : 2007.03.02</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("MAZAI09116D","Broadleaf.Application.Remoting.ParamData.StockMngTtlStWork")]
			out object stockmngttlstWork,
			object parastockmngttlstWork, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// �݌ɊǗ��S�̐ݒ�}�X�^����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="stockmngttlstWork">StockMngTtlStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 20036�@�ē��@�떾</br>
		/// <br>Date       : 2007.03.02</br>
        [MustCustomSerialization]
        int Write(
			[CustomSerializationMethodParameterAttribute("MAZAI09116D","Broadleaf.Application.Remoting.ParamData.StockMngTtlStWork")]
			ref object stockmngttlstWork
			);

		/// <summary>
		/// �݌ɊǗ��S�̐ݒ�}�X�^����_���폜���܂�
		/// </summary>
		/// <param name="stockmngttlstWork">StockMngTtlStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^����_���폜���܂�</br>
		/// <br>Programmer : 20036�@�ē��@�떾</br>
		/// <br>Date       : 2007.03.02</br>
        [MustCustomSerialization]
        int LogicalDelete(
			[CustomSerializationMethodParameterAttribute("MAZAI09116D","Broadleaf.Application.Remoting.ParamData.StockMngTtlStWork")]
			ref object stockmngttlstWork
			);

		/// <summary>
		/// �_���폜�݌ɊǗ��S�̐ݒ�}�X�^���𕜊����܂�
		/// </summary>
		/// <param name="stockmngttlstWork">StockMngTtlStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜�݌ɊǗ��S�̐ݒ�}�X�^���𕜊����܂�</br>
		/// <br>Programmer : 20036�@�ē��@�떾</br>
		/// <br>Date       : 2007.03.02</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
			[CustomSerializationMethodParameterAttribute("MAZAI09116D","Broadleaf.Application.Remoting.ParamData.StockMngTtlStWork")]
			ref object stockmngttlstWork
			);
		#endregion
	}
}
