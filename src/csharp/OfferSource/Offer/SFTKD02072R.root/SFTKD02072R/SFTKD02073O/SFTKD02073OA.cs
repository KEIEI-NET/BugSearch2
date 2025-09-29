using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���i���[�J�[���̐ݒ�i�񋟁jDB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���i���[�J�[���̐ݒ�i�񋟁jDB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 22027�@���{�@����</br>
	/// <br>Date       : 2006.06.08</br>
	/// <br></br>
	/// <br>Update Note: 30290 2008/06/03</br>
    /// <br>             �e�[�u�����C�A�E�g�ύX�ɂ��C��</br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]
	public interface IPMakerNmDB
	{
		/// <summary>
		/// ���i���[�J�[���̐ݒ�i�񋟁jLIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 22027�@���{�@����</br>
		/// <br>Date       : 2006.06.08</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("SFTKD02074D","Broadleaf.Application.Remoting.ParamData.PMakerNmWork")]
			out object retobj,
            int readMode);
					
		/// <summary>
		/// �w�肳�ꂽ���i���[�J�[���̐ݒ�i�񋟁jGuid�̕��i���[�J�[���̐ݒ�i�񋟁j��߂��܂�
		/// </summary>
		/// <param name="parabyte">PMakerNmWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ���i���[�J�[���̐ݒ�i�񋟁jGuid�̕��i���[�J�[���̐ݒ�i�񋟁j��߂��܂�</br>
		/// <br>Programmer : 22027�@���{�@����</br>
		/// <br>Date       : 2006.06.08</br>
		int Read(ref byte[] parabyte , int readMode);
	}
}
