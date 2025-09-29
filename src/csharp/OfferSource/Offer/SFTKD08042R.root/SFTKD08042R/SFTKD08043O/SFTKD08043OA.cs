using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
	
namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���[�U�[�K�C�hDB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���[�U�[�K�C�hDB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 21015�@�����@�F��</br>
	/// <br>Date       : 2005.03.24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
	public interface IUserGdBdDB
	{
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�h���LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		int SearchCnt(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);
		
		/// <summary>
		/// ���[�U�[�K�C�h���LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		[MustCustomSerialization]
		int SearchHeader(
			[CustomSerializationMethodParameterAttribute("SFTKD08044D","Broadleaf.Application.Remoting.ParamData.UserGdHdWork")]
			out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// ���[�U�[�K�C�h���LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		[MustCustomSerialization]
		int SearchBody(
			[CustomSerializationMethodParameterAttribute("SFTKD08044D","Broadleaf.Application.Remoting.ParamData.UserGdBdWork")]
			out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// �w�肳�ꂽGuideDivCode�̃��[�U�[�K�C�h���LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		[MustCustomSerialization]
		int SearchGuideDivCode(
			[CustomSerializationMethodParameterAttribute("SFTKD08044D","Broadleaf.Application.Remoting.ParamData.UserGdBdWork")]
			out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode);
		
		/// <summary>
		/// �w�肳�ꂽ���[�U�[�K�C�hGuid�̃��[�U�[�K�C�h����߂��܂�
		/// </summary>
		/// <param name="parabyte">OcrDefSetWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ���[�U�[�K�C�hGuid�̃��[�U�[�K�C�h��߂��܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		int Read(ref byte[] parabyte , int readMode);
	}
}
