//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �񋟃f�[�^�폜����DB����N���X
// �v���O�����T�v   : �񋟃f�[�^�폜����DB�I�u�W�F�N�g���擾���܂�
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/06/16  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// �񋟃f�[�^�폜���� �����[�g�I�u�W�F�N�g����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IOfferDataDeleteDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���RetGoodsReasonReportResultDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.06.16</br>
    /// </remarks>
    public class MediationOfferDataDeleteDB
    {
        /// <summary>
        /// OfferDataDeleteDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.06.16</br>
        /// </remarks>
        public MediationOfferDataDeleteDB()
        {
        }
        /// <summary>
        /// IOfferDataDeleteDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IOfferDataDeleteDB�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : IOfferDataDeleteDB�C���^�[�t�F�[�X���擾����B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.06.16</br>
        /// </remarks>
        public static IOfferDataDeleteDB GetOfferDataDeleteDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);

#if DEBUG
            wkStr = "http://localhost:9002";
#endif

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IOfferDataDeleteDB)Activator.GetObject(typeof(IOfferDataDeleteDB), string.Format("{0}/MyAppOfferDataDelete", wkStr));
        }
    }
}
