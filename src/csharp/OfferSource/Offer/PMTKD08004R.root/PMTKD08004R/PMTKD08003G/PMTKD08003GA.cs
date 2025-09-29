using System;
using System.Text;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// FrePSalesSlipOfferDB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note		: ���̃N���X��IFrePSalesSlipOfferDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			  ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���FrePSalesSlipOfferDB��</br>
	/// <br>			  �C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer	: 22018 ��� ���b</br>
	/// <br>Date		: 2007.05.07</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationFrePSalesSlipOfferDB
	{
		/// <summary>
        /// FrePSalesSlipOfferDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.05.07</br>
		/// </remarks>
        public MediationFrePSalesSlipOfferDB()
		{
		}

		/// <summary>
        /// IFrePSalesSlipOfferDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IPrtItemSetDB�I�u�W�F�N�g</returns>
		/// <remarks>
		/// <br>Note       : �����[�g�I�u�W�F�N�g�擾�p�̃v���L�V���쐬���܂��B</br>
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.05.07</br>
		/// </remarks>
        public static IFrePSalesSlipOfferDB GetFrePSalesSlipOfferDB()
		{
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain( ConstantManagement_SF_PRO.ServerCode_OfferAP );
# if DEBUG
            wkStr = "http://localhost:9002";
# endif
            return (IFrePSalesSlipOfferDB)Activator.GetObject( typeof( IFrePSalesSlipOfferDB ), string.Format( "{0}/MyAppFrePSalesSlipOffer", wkStr ) );
        }
	}
}
