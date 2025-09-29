//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �����󋵊m�F DB����N���X
//                  :   PMSCM04113G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   �c����
// Date             :   2014/08/01
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// �����󋵊m�F DB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ISynchConfirmDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���JoinPartsUDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2014/08/01</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSynchConfirmDB
    {
        /// <summary>
        /// �����󋵊m�F DB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public MediationSynchConfirmDB()
        {

        }

        /// <summary>
        /// ISynchConfirmDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ISynchConfirmDB�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : ISynchConfirmDB�C���^�[�t�F�[�X���擾����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public static ISynchConfirmDB GetSynchConfirmDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ISynchConfirmDB)Activator.GetObject(typeof(ISynchConfirmDB), string.Format("{0}/MyAppSynchConfirm", wkStr));
        }
    }
}
