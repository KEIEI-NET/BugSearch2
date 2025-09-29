using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// CarModelSearch����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ICompanyInfDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���CompanyInfDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 99033�@��{�@�E</br>
    /// <br>Date       : 2005.04.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationCarModelSearchDB
    {
        /// <summary>
        /// CompanyInfDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.02.15</br>
        /// </remarks>
        public MediationCarModelSearchDB()
        {

        }

        /// <summary>
        /// ICarModelSearch�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ICarModelSearch�I�u�W�F�N�g</returns>
        public static ICarModelSearchDB GetRemoteObject()
        {
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
#if DEBUG
            wkStr = "HTTP://localhost:9518";
#endif
            return (ICarModelSearchDB)Activator.GetObject(typeof(ICarModelSearchDB), string.Format("{0}/MyAppCarModelSearch", wkStr));
        }
    }
}
