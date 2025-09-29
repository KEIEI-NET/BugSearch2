using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// GoodsPriceUDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IGoodsPriceUDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>            ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���GoodsPriceUDB��</br>
    /// <br>            �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 18322  �ؑ� ����</br>
    /// <br>Date       : 2007.04.18</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: DC.NS�Ή�</br>
    /// <br>Programmer : 21024�@���X�؁@��</br>
    /// <br>Date       : 2007.08.13</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// </remarks>
    public class MediationGoodsPriceUDB
    {
        /// <summary>
        /// GoodsPriceUDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 18322  �ؑ� ����</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        public MediationGoodsPriceUDB()
        {
        }
        /// <summary>
        /// IPrtmanageDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IGoodsPriceUDB�I�u�W�F�N�g</returns>
        public static IGoodsPriceUDB GetGoodsPriceUDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IGoodsPriceUDB)Activator.GetObject(typeof(IGoodsPriceUDB),string.Format("{0}/MyAppGoodsPriceU",wkStr));
        }
    }
}
