//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   ���[���O���[�v���̐ݒ�}�X�^                    //
//                      DB����N���X                                    //
//                  :   PMKHN09724G.DLL                                 //
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
    /// RoleGroupNameStDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IRoleGroupNameStDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���RoleGroupNameStDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 30746 ���� ��</br>
    /// <br>Date       : 2013/02/18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationRoleGroupNameStDB
    {
        /// <summary>
        /// RoleGroupNameStDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public MediationRoleGroupNameStDB()
        {
        }

        /// <summary>
        /// IRoleGroupNameStDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IRoleGroupNameStDB�I�u�W�F�N�g</returns>
        public static IRoleGroupNameStDB GetRoleGroupNameStDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IRoleGroupNameStDB)Activator.GetObject(typeof(IRoleGroupNameStDB), string.Format("{0}/MyAppRoleGroupNameSt", wkStr));
        }
    }
}