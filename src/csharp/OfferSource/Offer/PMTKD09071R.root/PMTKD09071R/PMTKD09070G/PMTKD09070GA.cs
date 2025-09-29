//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �Ԏ햼�̃}�X�^DB����N���X
//                  :   PMTKD09070G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   30290
// Date             :   2008.06.10
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// ModelNameDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IModelNameDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���ModelNameDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.06.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationModelNameDB
    {
        /// <summary>
        /// ModelNameDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.10</br>
        /// </remarks>
        public MediationModelNameDB()
        {

        }

        /// <summary>
        /// IModelNameDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IModelNameDB�I�u�W�F�N�g</returns>
        public static IModelNameDB GetModelNameDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
#if DEBUG
            wkStr = "http://localhost:9002";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IModelNameDB)Activator.GetObject(typeof(IModelNameDB), string.Format("{0}/MyAppModelName", wkStr));
        }
    }
}
