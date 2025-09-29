using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SCM�󔭒� DB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IGetPMEmployeeDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���GetPMEmployeeDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 22011 Kashihara</br>
    /// <br>Date       : 2013.06.06</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationGetPMEmployeeDB
    {
        /// <summary>
        /// GetPMEmployeeDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 22011 Kashihara</br>
        /// <br>Date       : 2013.06.06</br>
        /// </remarks>
        public MediationGetPMEmployeeDB()
        {
        }

        /// <summary>
        /// IPMEmployeeDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IPMEmployeeDB�I�u�W�F�N�g</returns>
        public static IPMEmployeeDB GetPMEmployeeDB()
        {
            // USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP);
#if DEBUG
            wkStr = "http://localhost:8009";            
#endif
            // AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IPMEmployeeDB)Activator.GetObject(typeof(IPMEmployeeDB), string.Format("{0}/MyAppPMEmployee", wkStr));
        }

    }
}
