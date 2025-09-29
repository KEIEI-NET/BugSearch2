using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;



namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �S�̍��ڕ\������DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �S�̍��ڕ\������DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 90027�@�����@��</br>
	/// <br>Date       : 2006.08.28</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IAlItmDspNmDB
	{

		#region �J�X�^���V���A���C�Y

		/// <summary>
		/// �S�̍��ڕ\������LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		int Search(
			[CustomSerializationMethodParameterAttribute("SFCMN09166D","Broadleaf.Application.Remoting.ParamData.AlItmDspNmWork")]
			out object retobj,
			object paraobj,
			int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\�����̂�߂��܂�
		/// </summary>
		/// <param name="alItmDspNmWork">AlItmDspNmWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\�����̂�߂��܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		[MustCustomSerialization]
		int Read(
			[CustomSerializationMethodParameterAttribute("SFCMN09166D","Broadleaf.Application.Remoting.ParamData.AlItmDspNmWork")]
			ref object alItmDspNmWork,
			int readMode
			);
			
		#endregion


		/// <summary>
		/// �S�̍��ڕ\������LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="parabyte">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		int Search(out byte[] retbyte, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// �w�肳�ꂽ�S�̍��ڕ\������Guid�̑S�̍��ڕ\�����̂�߂��܂�
		/// </summary>
		/// <param name="parabyte">AlItmDspNmWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ�S�̍��ڕ\������Guid�̑S�̍��ڕ\�����̂�߂��܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// �S�̍��ڕ\�����̏���o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">AlItmDspNmWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �S�̍��ڕ\�����̏���o�^�A�X�V���܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		int Write(ref byte[] parabyte);

		/// <summary>
		/// �S�̍��ڕ\�����̏��𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">AlItmDspNmWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �S�̍��ڕ\�����̏��𕨗��폜���܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		int Delete(byte[] parabyte);

		/// <summary>
		/// �S�̍��ڕ\�����̏���_���폜���܂�
		/// </summary>
		/// <param name="parabyte">AlItmDspNmWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �S�̍��ڕ\�����̏���_���폜���܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		int LogicalDelete(ref byte[] parabyte);

		/// <summary>
		/// �_���폜�S�̍��ڕ\�����̏��𕜊����܂�
		/// </summary>
		/// <param name="parabyte">AlItmDspNmWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜�S�̍��ڕ\�����̏��𕜊����܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		int RevivalLogicalDelete(ref byte[] parabyte);






        /// <summary>
		/// �S�̍��ڕ\������LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		int Search(
			[CustomSerializationMethodParameterAttribute("SFCMN09166D","Broadleaf.Application.Remoting.ParamData.AlItmDspNmWork")]
			out object retobj,
			object paraobj,
			int readMode,ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection);

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\�����̂�߂��܂�
		/// </summary>
		/// <param name="alItmDspNmWork">AlItmDspNmWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\�����̂�߂��܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		[MustCustomSerialization]
		int Read(
			[CustomSerializationMethodParameterAttribute("SFCMN09166D","Broadleaf.Application.Remoting.ParamData.AlItmDspNmWork")]
			ref object alItmDspNmWork,
			int readMode,
            ref SqlConnection sqlConnection);

		/// <summary>
		/// �S�̍��ڕ\������LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="parabyte">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		int Search(out byte[] retbyte, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode,ref SqlConnection sqlConnection);

		/// <summary>
		/// �w�肳�ꂽ�S�̍��ڕ\������Guid�̑S�̍��ڕ\�����̂�߂��܂�
		/// </summary>
		/// <param name="parabyte">AlItmDspNmWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ�S�̍��ڕ\������Guid�̑S�̍��ڕ\�����̂�߂��܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		int Read(ref byte[] parabyte , int readMode ,ref SqlConnection sqlConnection);






    }
}
