using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �t�F���J�Ǘ�DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�F���J�Ǘ�DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 22011�@�������l</br>
	/// <br>Date       : 2008.10.30</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
	public interface IFeliCaMngDB
	{
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̃t�F���J�Ǘ�LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="felicaMngWork">��������</param>
		/// <param name="parafelicaMngWork">�����p�����[�^</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
        [MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("SFCMN03504D", "Broadleaf.Application.Remoting.ParamData.FeliCaMngWork")]
			out object felicaMngWork, 
			object parafelicaMngWork,
			ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// �w�肳�ꂽ�t�F���J�Ǘ�Guid�̃t�F���J�Ǘ���߂��܂�
		/// </summary>
        /// <param name="paraobj">WorkerWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		int Read(ref object paraobj);
        
		/// <summary>
		/// �t�F���J�Ǘ�����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="paraobj">WorkerWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        int Write(
            ref object paraobj ); 

		/// <summary>
		/// �t�F���J�Ǘ����𕨗��폜���܂�
		/// </summary>
        /// <param name="paraobj">WorkerWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        int Delete(object paraobj);

		/// <summary>
		/// �t�F���J�Ǘ�����_���폜���܂�
		/// </summary>
        /// <param name="paraobj">WorkerWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        int LogicalDelete(ref object paraobj);

		/// <summary>
		/// �_���폜�t�F���J�Ǘ����𕜊����܂�
		/// </summary>
        /// <param name="paraobj">WorkerWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        int RevivalLogicalDelete(ref object paraobj);
	}
}
