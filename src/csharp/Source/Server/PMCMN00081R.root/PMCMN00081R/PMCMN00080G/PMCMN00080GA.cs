using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// DB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note         : ���̃N���X��IDepsitListWorkDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>               ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ��ڃ����[�g�I�u�W�F�N�g��</br>
    /// <br>               �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer   : �e�c ���V</br>
    /// <br>Date         : 2015/09/24</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationLSMLogCheckDB
    {
        /// <summary>
        /// DB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/09/24</br>
        /// </remarks>
        public MediationLSMLogCheckDB()
        {
        }
        /// <summary>
        /// DB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>DB�I�u�W�F�N�g</returns>
        public static ILSMLogCheckDB GetLSMLogCheckDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain( ConstantManagement_SF_PRO.ServerCode_UserAP );
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ILSMLogCheckDB)Activator.GetObject(typeof(ILSMLogCheckDB), string.Format("{0}/MyAppLSMLogCheck", wkStr));
        }
    }
}
