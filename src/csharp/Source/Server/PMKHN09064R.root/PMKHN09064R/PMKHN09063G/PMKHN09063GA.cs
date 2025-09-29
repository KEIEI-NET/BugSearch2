//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   BL�O���[�v�}�X�^DB����N���X
//                  :   PMKHN09063G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   22008 ���� ���n
// Date             :   2008.06.05
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
    /// BLGroupUDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IBLGroupUDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���BLGroupUDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2008.06.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationBLGroupUDB
    {
        /// <summary>
        /// BLGroupUDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        /// </remarks>
        public MediationBLGroupUDB()
        {

        }

        /// <summary>
        /// IBLGroupUDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IBLGroupUDB�I�u�W�F�N�g</returns>
        public static IBLGroupUDB GetBLGroupUDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IBLGroupUDB)Activator.GetObject(typeof(IBLGroupUDB),string.Format("{0}/MyAppBLGroupU",wkStr));
        }
    }
}
