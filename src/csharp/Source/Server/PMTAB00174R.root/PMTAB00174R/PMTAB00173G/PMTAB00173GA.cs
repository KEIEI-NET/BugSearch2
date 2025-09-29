//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �󒍃}�X�^(�ԗ�)DB����N���X
// �v���O�����T�v   : �󒍃}�X�^(�ԗ�)DB����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : huangt
// �� �� ��  2013/05/30  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// IPmTabAcpOdrCarDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IPmTabAcpOdrCarDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���PmTabAcpOdrCarDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : huangt</br>
    /// <br>Date       : 2013/05/30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPmTabAcpOdrCarDB
    {
        /// <summary>
        /// PmTabAcpOdrCarDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        /// </remarks>
        public MediationPmTabAcpOdrCarDB()
        {

        }

        /// <summary>
        /// IPmTabAcpOdrCarDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IPmTabAcpOdrCarDB�I�u�W�F�N�g</returns>
        public static IPmTabAcpOdrCarDB GetPmTabAcpOdrCarDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IPmTabAcpOdrCarDB)Activator.GetObject(typeof(IPmTabAcpOdrCarDB), string.Format("{0}/MyAppPmTabAcpOdrCar", wkStr));
        }
    }
}
