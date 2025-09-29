using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �݌Ɉړ�DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �݌Ɉړ�DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 21015�@�����@�F��</br>
	/// <br>Date       : 2007.01.19</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IStockMoveDB
	{

		/// <summary>
		/// �w�肳�ꂽ�݌Ɉړ�Guid�̍݌Ɉړ���߂��܂�
		/// </summary>
		/// <param name="parabyte">StockMoveWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ�݌Ɉړ�Guid�̍݌Ɉړ���߂��܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.19</br>
		int Read(ref byte[] parabyte , int readMode);

        #region �J�X�^���V���A���C�Y�Ή����\�b�h
		/// <summary>
		/// �݌Ɉړ�LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
		/// </summary>
		/// <param name="stockMoveWork">��������</param>
		/// <param name="parastockMoveWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.19</br>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object stockMoveWork,
			object parastockMoveWork, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// �݌Ɉړ�����o�^�A�X�V���܂�
		/// </summary>
        /// <param name="stockMoveWork">StockMoveWork�I�u�W�F�N�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
		/// <br>Note       : �݌Ɉړ�����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.19</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object stockMoveWork,
            out string retMsg
			);

        /// <summary>
        /// �݌Ɉړ��f�[�^�̓`�[���s�ϋ敪�݂̂��X�V���܂�
        /// </summary>
        /// <param name="objstockMoveWork">StockMoveWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ɉړ��f�[�^�̓`�[���s�ϋ敪�݂̂��X�V���܂�</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2009.03.11</br>
        [MustCustomSerialization]
        int WriteSlipPrintFinishCd(
            [CustomSerializationMethodParameterAttribute("MAZAI04126D", "Broadleaf.Application.Remoting.ParamData.StockMoveWork")]
            ref object objstockMoveWork
            );

		/// <summary>
		/// �݌Ɉړ�����_���폜���܂�
		/// </summary>
		/// <param name="stockMoveWork">StockMoveWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �݌Ɉړ�����_���폜���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.19</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object stockMoveWork
			);

		/// <summary>
		/// �_���폜�݌Ɉړ����𕜊����܂�
		/// </summary>
		/// <param name="stockMoveWork">StockMoveWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜�݌Ɉړ����𕜊����܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.19</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object stockMoveWork
			);

        /// <summary>
        /// �݌Ɉړ�����_���폜���܂�
        /// </summary>
        /// <param name="stockMoveWork">StockMoveWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ɉړ�����_���폜���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.19</br>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object stockMoveWork
            );
        #endregion

	}
}
