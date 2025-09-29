using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���엚�����O�f�[�^DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���엚�����O�f�[�^DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 23015 �X�{ ��P</br>
	/// <br>Date       : 2008.07.24</br>
	/// <br></br>
    /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IOprtnHisLogDB
	{
        /// <summary>
        /// ���엚�����O�f�[�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="oprtnHisLogWork">��������</param>
        /// <param name="oprtnHisLogSrchWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("MACMN00116D", "Broadleaf.Application.Remoting.ParamData.OprtnHisLogWork")]
			ref object oprtnHisLogWork,
            object oprtnHisLogSrchWork,
            int readMode,
            ConstantManagement.LogicalMode logicalMode
            );

        /// <summary>
        /// ���엚�����O�f�[�^LIST(UOE��)��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="oprtnHisLogWork">��������</param>
        /// <param name="oprationLogOrderWorkWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.12.03</br>
        [MustCustomSerialization]
        int SearchUOE(
            [CustomSerializationMethodParameterAttribute("MACMN00116D", "Broadleaf.Application.Remoting.ParamData.OprtnHisLogWork")]
			ref object oprtnHisLogWork,
            object oprationLogOrderWork,
            int readMode,
            ConstantManagement.LogicalMode logicalMode
            );

		/// <summary>
		/// �w�肳�ꂽ���엚�����O�f�[�^Guid�̑��엚�����O�f�[�^��߂��܂�
		/// </summary>
        /// <param name="oprtnHisLogWork">oprtnHisLogWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ���엚�����O�f�[�^Guid�̑��엚�����O�f�[�^��߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("MACMN00116D", "Broadleaf.Application.Remoting.ParamData.OprtnHisLogWork")]
			ref object oprtnHisLogWork,
            int readMode
            );

        /// <summary>
        /// ���엚�����O�f�[�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="oprtnHisLogWork">OprtnHisLogWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���엚�����O�f�[�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("MACMN00116D", "Broadleaf.Application.Remoting.ParamData.OprtnHisLogWork")]
			ref object oprtnHisLogWork
            );

		/// <summary>
		/// ���엚�����O�f�[�^���𕨗��폜���܂�
		/// </summary>
        /// <param name="oprtnHisLogWork">OprtnHisLogWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���엚�����O�f�[�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("MACMN00116D", "Broadleaf.Application.Remoting.ParamData.OprtnHisLogWork")]
            object oprtnHisLogWork
            );

        /// <summary>
        /// ���엚�����O�f�[�^���(UOE��)�𕨗��폜���܂�
        /// </summary>
        /// <param name="oprtnHisLogWork">OprtnHisLogWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���엚�����O�f�[�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.12.02</br>
        int DeleteUOE(object oprationLogOrderWork
            );

        /// <summary>
		/// ���엚�����O�f�[�^����_���폜���܂�
		/// </summary>
		/// <param name="oprtnHisLogWork">OprtnHisLogWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���엚�����O�f�[�^����_���폜���܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        [MustCustomSerialization]
        int LogicalDelete(
			[CustomSerializationMethodParameterAttribute("MACMN00116D","Broadleaf.Application.Remoting.ParamData.OprtnHisLogWork")]
			ref object oprtnHisLogWork
			);

		/// <summary>
		/// �_���폜���엚�����O�f�[�^���𕜊����܂�
		/// </summary>
		/// <param name="oprtnHisLogWork">OprtnHisLogWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜���엚�����O�f�[�^���𕜊����܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
			[CustomSerializationMethodParameterAttribute("MACMN00116D","Broadleaf.Application.Remoting.ParamData.OprtnHisLogWork")]
			ref object oprtnHisLogWork
			);
	}
}
