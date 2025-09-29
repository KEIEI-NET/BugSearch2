using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// �����擾�}�X�^�����[�g����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IInitialSearchDB�N���X�I�u�W�F�N�g��߂��܂��B</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2010/04/22</br>
    /// </remarks>
    public class MediationVariousMasterSearchDB
    {
        /// <summary>
        /// InitialSearchDB����N���X�R���X�g���N�^
        /// </summary>
        public MediationVariousMasterSearchDB()
        {
        }

        /// <summary>
        /// IInitialSearchDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IInitialSearchDB�I�u�W�F�N�g</returns>
        public static IVariousMasterSearchDB GetRemoteObject()
        {
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "HTTP://localhost:9001";
#endif
            return (IVariousMasterSearchDB)Activator.GetObject(typeof(IVariousMasterSearchDB), string.Format("{0}/MyAppVariousMasterSearch", wkStr));
        }
    }
}
