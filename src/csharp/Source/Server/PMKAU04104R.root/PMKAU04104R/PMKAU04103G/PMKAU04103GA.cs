using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// UpdHisDspDB ����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IUpdHisDspDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���UpdHisDspDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 20081</br>
    /// <br>Date       : 2008.08.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationUpdHisDspDB
    {
        /// <summary>
        /// UpdHisDspDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.11</br>
        /// </remarks>
        public MediationUpdHisDspDB()
        {
        }
        /// <summary>
        /// IUpdHisDspDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IUpdHisDspDB�I�u�W�F�N�g</returns>
        public static IUpdHisDspDB GetUpdHisDspDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IUpdHisDspDB)Activator.GetObject(typeof(IUpdHisDspDB), string.Format("{0}/MyAppUpdHisDsp", wkStr));
        }
    }
}
