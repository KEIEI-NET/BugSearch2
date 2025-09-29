//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE ���Аݒ�}�X�^DB����N���X
//                  :   PMUOE09043G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   20081 �D�c �E�l
// Date             :   2008.06.06
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
    /// UOESettingDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IUOESettingDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���UOESettingDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 20081 �D�c �E�l</br>
    /// <br>Date       : 2008.06.06</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationUOESettingDB
    {
        /// <summary>
        /// UOESettingDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        /// </remarks>
        public MediationUOESettingDB()
        {

        }

        /// <summary>
        /// IUOESettingDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IUOESettingDB�I�u�W�F�N�g</returns>
        public static IUOESettingDB GetUOESettingDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IUOESettingDB)Activator.GetObject(typeof(IUOESettingDB),string.Format("{0}/MyAppUOESetting",wkStr));
        }
    }
}
