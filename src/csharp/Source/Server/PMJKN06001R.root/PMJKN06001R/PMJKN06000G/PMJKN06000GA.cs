using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// FreeSearchModelSearch����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IFreeSearchModelSearch�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���FreeSearchModelSearchDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 99033�@��{�@�E</br>
    /// <br>Date       : 2005.04.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationFreeSearchModelSearchDB
    {
        /// <summary>
        /// FreeSearchModelSearch����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.02.15</br>
        /// </remarks>
        public MediationFreeSearchModelSearchDB()
        {

        }

        /// <summary>
        /// IFreeSearchModelSearch�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ICarModelSearch�I�u�W�F�N�g</returns>
        public static IFreeSearchModelSearchDB GetRemoteObject()
        {
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "HTTP://localhost:9012";
#endif
            return (IFreeSearchModelSearchDB)Activator.GetObject( typeof( IFreeSearchModelSearchDB ), string.Format( "{0}/MyAppFreeSearchModelSearch", wkStr ) );
        }
    }
}
