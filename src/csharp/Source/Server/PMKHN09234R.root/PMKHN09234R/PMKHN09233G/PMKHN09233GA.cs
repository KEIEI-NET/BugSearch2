using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// BLCodeGuideDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IBLCodeGuideDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���BLCodeGuideDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 23015�@�X�{ ��P</br>
    /// <br>Date       : 2008.09.26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationBLCodeGuideDB
    {
        /// <summary>
        /// BLCodeGuideDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 23015�@�X�{ ��P</br>
        /// <br>Date       : 2008.09.26</br>
        /// </remarks>
        public MediationBLCodeGuideDB()
        {

        }

        /// <summary>
        /// IBLCodeGuideDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IBLCodeGuideDB�I�u�W�F�N�g</returns>
        public static IBLCodeGuideDB GetBLCodeGuideDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IBLCodeGuideDB)Activator.GetObject(typeof(IBLCodeGuideDB), string.Format("{0}/MyAppBLCodeGuide", wkStr));
        }
    }
}