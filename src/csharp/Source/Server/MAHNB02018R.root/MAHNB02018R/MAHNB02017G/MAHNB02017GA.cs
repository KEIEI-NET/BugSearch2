using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// DepsitListWorkDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IDepsitListWorkDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���DepsitListWorkDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 22035 �O�� �O��</br>
    /// <br>Date       : 2007.03.06</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br>           :   2007.11.15  DC.NS �p�ɉ���  ���쏹��</br>
    /// </remarks>
    public class MediationDepsitListWorkDB
    {
        /// <summary>
        /// DepsitListWorkDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.03.06</br>
        /// </remarks>
        public MediationDepsitListWorkDB()
        {
        }
        /// <summary>
        /// IPrtmanageDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IPrtmanageDB�I�u�W�F�N�g</returns>
        public static IDepsitListWorkDB GetDepsitListWorkDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IDepsitListWorkDB)Activator.GetObject(typeof(IDepsitListWorkDB), string.Format("{0}/MyAppDepsitListWork", wkStr));
        }
    }
}
