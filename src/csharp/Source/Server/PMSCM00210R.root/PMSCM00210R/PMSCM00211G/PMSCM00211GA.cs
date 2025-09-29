//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �������s�Ǘ� DB����N���X
//                  :   PMSCM00211G.DLL
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
    /// �������s�Ǘ� DB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ISynchExecuteMngDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���JoinPartsUDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2014/08/01</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSynchExecuteMngDB
    {
        /// <summary>
        /// �������s�Ǘ� DB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public MediationSynchExecuteMngDB()
        {

        }

        /// <summary>
        /// ISynchExecuteMngDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ISynchExecuteMngDB�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : ISynchExecuteMngDB�C���^�[�t�F�[�X���擾����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public static ISynchExecuteMngDB GetSynchExecuteMngDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:8008";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ISynchExecuteMngDB)Activator.GetObject(typeof(ISynchExecuteMngDB), string.Format("{0}/MyAppSynchExecuteMng", wkStr));
        }
    }
}
