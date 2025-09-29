//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �������i�}�X�^DB����N���X
//                  :   PMKHN09043G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   22008�@���� ���n
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
    /// IsolIslandPrcDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IIsolIslandPrcDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���IsolIslandPrcDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 22008�@���� ���n</br>
    /// <br>Date       : 2008.06.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationIsolIslandPrcDB
    {
        /// <summary>
        /// IsolIslandPrcDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        /// </remarks>
        public MediationIsolIslandPrcDB()
        {

        }

        /// <summary>
        /// IIsolIslandPrcDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IIsolIslandPrcDB�I�u�W�F�N�g</returns>
        public static IIsolIslandPrcDB GetIsolIslandPrcDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IIsolIslandPrcDB)Activator.GetObject(typeof(IIsolIslandPrcDB),string.Format("{0}/MyAppIsolIslandPrc",wkStr));
        }
    }
}
