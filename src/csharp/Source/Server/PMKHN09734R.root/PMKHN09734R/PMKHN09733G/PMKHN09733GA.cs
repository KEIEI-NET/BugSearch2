//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   ���[���O���[�v�����ݒ�}�X�^                    //
//                      DB����N���X                                    //
//                  :   PMKHN09733G.DLL                                 //
// Name Space       :   Broadleaf.Application.Remoting.Adapter          //
// Programmer       :   30746 ���� ��                                   //
// Date             :   2013/02/18                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                 Copyright(C) 2008 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// RoleGroupAuthDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IRoleGroupAuthDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���RoleGroupAuthDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 30746 ���� ��</br>
    /// <br>Date       : 2013/02/18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationRoleGroupAuthDB
    {
        /// <summary>
        /// RoleGroupAuthDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public MediationRoleGroupAuthDB()
        {
        }

        /// <summary>
        /// IRoleGroupAuthDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IRoleGroupAuthDB�I�u�W�F�N�g</returns>
        public static IRoleGroupAuthDB GetRoleGroupAuthDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IRoleGroupAuthDB)Activator.GetObject(typeof(IRoleGroupAuthDB), string.Format("{0}/MyAppRoleGroupAuth", wkStr));
        }
    }
}