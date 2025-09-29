using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// �d����d�q���� DB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ISuppPrtPprWorkDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���SuppPrtPprWorkDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 23015 �X�{ ��P</br>
    /// <br>Date       : 2008.08.18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSuppPrtPprWorkDB
    {
        /// <summary>
        /// �d����d�q���� DB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.18</br>
        /// </remarks>
        public MediationSuppPrtPprWorkDB()
        {
        }

        /// <summary>
        /// ISuppPrtPprWorkDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ISuppPrtPprWorkDB�I�u�W�F�N�g</returns>
        public static ISuppPrtPprWorkDB GetSuppPrtPprWorkDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ISuppPrtPprWorkDB)Activator.GetObject(typeof(ISuppPrtPprWorkDB), string.Format("{0}/MyAppSuppPrtPprWork", wkStr));
        }
    }
}
