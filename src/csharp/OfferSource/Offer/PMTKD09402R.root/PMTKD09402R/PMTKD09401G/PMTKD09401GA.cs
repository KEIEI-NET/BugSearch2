//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �D�Ǖ��i�o�[�R�[�h��񒊏o�����[�g
// �v���O�����T�v   : �D�Ǖ��i�o�[�R�[�h��񒊏oDB����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370074-00  �쐬�S�� : 30757 ���X�؋M�p
// �� �� ��  2017/09/20   �C�����e : �n���f�B�^�[�~�i���񎟑Ή��i�V�K�쐬�j
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// �D�Ǖ��i�o�[�R�[�h��񒊏oDB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̃N���X��IOfferPrmPartsBrcdInfo�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���OfferPrmPartsBrcdInfoDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 30757 ���X�؁@�M�p</br>
    /// <br>Date       : 2017/09/20</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationOfferPrmPartsWidthBrcdInfo
	{
		/// <summary>
        /// �D�Ǖ��i�o�[�R�[�h��񒊏oDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 30757 ���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        public MediationOfferPrmPartsWidthBrcdInfo()
		{
			
		}
		
		/// <summary>
        /// �D�Ǖ��i�o�[�R�[�h��񒊏o�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <remarks>
        /// <br>Note       : OfferAP�v���L�V�T�[�r�X���D�Ǖ��i�o�[�R�[�h��񒊏o�C���^�[�t�F�[�X�^�̃I�u�W�F�N�g���擾����</br>
        /// <br>Programmer : 30757 ���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        /// <returns>�D�Ǖ��i�o�[�R�[�h��񒊏o�C���^�[�t�F�[�X�^�I�u�W�F�N�g</returns>
        public static IOfferPrmPartsBrcdInfo GetOfferPrmPartsWidthBrcdInfo()
        {
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
#if DEBUG
            wkStr = "HTTP://localhost:9012";
#endif
            return (IOfferPrmPartsBrcdInfo)Activator.GetObject( typeof( IOfferPrmPartsBrcdInfo ), string.Format( "{0}/MyAppOfferPrmPartsWidthBrcdInfo", wkStr ) );
        }

	}
}
