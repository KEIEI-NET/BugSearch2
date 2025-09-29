using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���Ж��̐ݒ�DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���Ж��̐ݒ�DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 22027�@���{�@����</br>
	/// <br>Date       : 2005.09.08</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface ICompanyNmDB
	{
		/// <summary>
		/// ���Ж��̐ݒ�LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 22027�@���{�@����</br>
		/// <br>Date       : 2005.09.08</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("SFUKN09026D","Broadleaf.Application.Remoting.ParamData.CompanyNmWork")]
			out object retobj,
			object paraobj,
			int readMode,ConstantManagement.LogicalMode logicalMode);
					
		/// <summary>
		/// �w�肳�ꂽ���Ж��̐ݒ�Guid�̎��Ж��̐ݒ��߂��܂�
		/// </summary>
		/// <param name="parabyte">CompanyNmWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ���Ж��̐ݒ�Guid�̎��Ж��̐ݒ��߂��܂�</br>
		/// <br>Programmer : 22027�@���{�@����</br>
		/// <br>Date       : 2005.09.08</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// ���Ж��̐ݒ����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">CompanyNmWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���Ж��̐ݒ����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 22027�@���{�@����</br>
		/// <br>Date       : 2005.09.08</br>
		int Write(ref byte[] parabyte);

		/// <summary>
		/// ���Ж��̐ݒ���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">CompanyNmWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���Ж��̐ݒ���𕨗��폜���܂�</br>
		/// <br>Programmer : 22027�@���{�@����</br>
		/// <br>Date       : 2005.09.08</br>
		int Delete(byte[] parabyte);

		/// <summary>
		/// ���Ж��̐ݒ����_���폜���܂�
		/// </summary>
		/// <param name="parabyte">CompanyNmWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���Ж��̐ݒ����_���폜���܂�</br>
		/// <br>Programmer : 22027�@���{�@����</br>
		/// <br>Date       : 2005.09.08</br>
		int LogicalDelete(ref byte[] parabyte);

		/// <summary>
		/// �_���폜���Ж��̐ݒ���𕜊����܂�
		/// </summary>
		/// <param name="parabyte">CompanyNmWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜���Ж��̐ݒ���𕜊����܂�</br>
		/// <br>Programmer : 22027�@���{�@����</br>
		/// <br>Date       : 2005.09.08</br>
		int RevivalLogicalDelete(ref byte[] parabyte);
	}
}
