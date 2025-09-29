using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// VersionChkWorkDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : DB,AP�o�[�W�������擾���܂�</br>
    /// <br>Programmer : 30350 �N�� ����</br>
    /// <br>Date       : 2009.01.23</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationVersionChkWorkDB
    {
        /// <summary>
        /// MediationVersionChkWorkDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2009.01.23</br>
        /// </remarks>
        public MediationVersionChkWorkDB()
        {
        }
        /// <summary>
        /// IVersionChkWorkDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IVersionChkWorkDB�I�u�W�F�N�g</returns>
        public static IVersionChkWorkDB GetVersionChkWorkDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IVersionChkWorkDB)Activator.GetObject(typeof(IVersionChkWorkDB), string.Format("{0}/MyAppVersionChkWork", wkStr));
        }
    }
}
