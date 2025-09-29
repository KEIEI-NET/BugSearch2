using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SuppRsltUpdDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ISuppRsltUpdDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���SuppRsltUpdDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 20036�@�ē��@�떾</br>
    /// <br>Date       : 2007.04.25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSuppRsltUpdDB
    {
        /// <summary>
        /// CustRsltUpdDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.25</br>
        /// </remarks>
        public MediationSuppRsltUpdDB()
        {
        }
        /// <summary>
        /// ISuppRsltUpdDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ISuppRsltUpdDB�I�u�W�F�N�g</returns>
        public static ISuppRsltUpdDB GetSuppRsltUpdDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ISuppRsltUpdDB)Activator.GetObject(typeof(ISuppRsltUpdDB), string.Format("{0}/MyAppSuppRsltUpd", wkStr));
        }
    }
}
