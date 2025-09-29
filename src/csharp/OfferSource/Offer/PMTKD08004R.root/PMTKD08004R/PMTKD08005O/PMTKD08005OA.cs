using System;
using System.Text;
using System.Collections.Generic;

using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���R���[(����`�[)��DBRemoteObject�C���^�[�t�F�[�X	
	/// </summary>
	/// <remarks>
	/// <br>Note         : ���R���[(����`�[)�� RemoteObject Interface�ł��B</br>
	/// <br>Programmer   : 22018 ��� ���b</br>
	/// <br>Date         : 2008.06.06</br>
	/// <br></br>
	/// <br>Update Note	: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
	public interface IFrePSalesSlipOfferDB
	{
		/// <summary>
		/// ���R���[���ڐݒ�}�X�^�擾����
		/// </summary>
        /// <param name="frePSalesSlipOfferWork">�񋟌������[�N���X�g</param>
        /// <param name="msgDiv"></param>
        /// <param name="errMsg"></param>
		/// <returns>�X�e�[�^�X</returns>
		/// <br>Note         : �w�肳�ꂽ�񋟃f�[�^�z����擾���܂��B</br>
		/// <br>Programmer   : 22018 ��� ���b</br>
		/// <br>Date         : 2008.06.06</br>
        [MustCustomSerialization]
        int SearchFrePSalesSlipOffer(
            ref object frePSalesSlipOfferWork,
            out bool msgDiv,
            out string errMsg
            );
	}
}
