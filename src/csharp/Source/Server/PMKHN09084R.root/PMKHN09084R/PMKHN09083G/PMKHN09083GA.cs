//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   ���Ӑ�i�������jDB����N���X
//                  :   PMKHN09083G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   22008 ���� ���n
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
    /// CustDmdSetDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ICustDmdSetDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���CustDmdSetDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2008.06.06</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationCustDmdSetDB
    {
        /// <summary>
        /// CustDmdSetDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.06</br>
        /// </remarks>
        public MediationCustDmdSetDB()
        {

        }

        /// <summary>
        /// ICustDmdSetDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ICustDmdSetDB�I�u�W�F�N�g</returns>
        public static ICustDmdSetDB GetCustDmdSetDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ICustDmdSetDB)Activator.GetObject(typeof(ICustDmdSetDB),string.Format("{0}/MyAppCustDmdSet",wkStr));
        }
    }
}
