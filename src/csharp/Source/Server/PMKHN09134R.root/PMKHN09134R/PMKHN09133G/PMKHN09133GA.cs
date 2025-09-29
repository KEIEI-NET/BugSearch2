using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// �I�y���[�V�����ݒ�DB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IOperationStDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���OperationStDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 20081 �D�c �E�l</br>
    /// <br>Date       : 2008.06.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationOperationStDB
    {
        /// <summary>
        /// OperationStDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        /// </remarks>
        public MediationOperationStDB()
        {

        }

        /// <summary>
        /// IOperationStDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IOperationStDB�I�u�W�F�N�g</returns>
        public static IOperationStDB GetOperationStDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IOperationStDB)Activator.GetObject(typeof(IOperationStDB), string.Format("{0}/MyAppOperationSt", wkStr));
        }
    }
}
