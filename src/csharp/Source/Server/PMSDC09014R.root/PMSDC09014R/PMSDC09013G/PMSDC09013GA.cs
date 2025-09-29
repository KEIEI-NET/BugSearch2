//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ڑ�����}�X�^�����e�i���X
// �v���O�����T�v   : �ڑ�����}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10901034-00 �쐬�S�� : �c����
// �� �� ��  2019/12/03  �C�����e : �V�K�쐬
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
    /// ConnectInfoPrcPrStDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IConnectInfoPrcPrStDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���ConnectInfoPrcPrStDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : lyc</br>
    /// <br>Date       : 2019/12/03</br>
    /// <br>�Ǘ��ԍ�   : 10901034-00</br>
    /// <br></br>
    /// </remarks>
    public class MediationSalCprtConnectInfoPrcPrStDB 
    {
        /// <summary>
        /// IConnectInfoPrcPrStDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        public MediationSalCprtConnectInfoPrcPrStDB()
        {
        }
        /// <summary>
        /// IConnectInfoPrcPrStDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ISlipPrtSetDB�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : IConnectInfoPrcPrStDB�C���^�[�t�F�[�X�擾</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 10901034-00</br>
        /// <br></br>
        /// <br></br>
        /// </remarks>
        public static ISalCprtConnectInfoPrcPrStDB GetSalCprtConnectInfoPrcPrStDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ISalCprtConnectInfoPrcPrStDB)Activator.GetObject(typeof(ISalCprtConnectInfoPrcPrStDB), string.Format("{0}/MyAppSalCprtConnectInfoPrcPrSt", wkStr));
        }
    }
}
