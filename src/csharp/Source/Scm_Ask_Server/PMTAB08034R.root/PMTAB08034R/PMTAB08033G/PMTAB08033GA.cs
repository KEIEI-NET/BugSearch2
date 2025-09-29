//**********************************************************************
// System           : PM.NS
// Sub System       :
// Program name     : PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^ RemoteObject����N���X
//                  : PMTAB08033G.DLL
// Name Space       : Broadleaf.Application.Remoting
// Programmer       : 30746 ���� ��
// Date             : 2014/09/26
//----------------------------------------------------------------------
//                  (c)Copyright  2014 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// PmtGeneralSrRstDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IPmtGeneralSrRstDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���PmtGeneralSrRstDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 30746 ���� ��</br>
    /// <br>Date       : 2014/09/26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPmtGeneralSrRstDB
    {
        /// <summary>
        /// PmtGeneralSrRstDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2014/09/26</br>  
        /// </remarks>
        public MediationPmtGeneralSrRstDB()
        {
        }
        /// <summary>
        /// IPmtGeneralSrRstDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IPmtGeneralSrRstDB�I�u�W�F�N�g</returns>
        public static IPmtGeneralSrRstDB GetPmtGeneralSrRstDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP);

#if DEBUG
            wkStr = "http://localhost:9014";
#endif

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IPmtGeneralSrRstDB)Activator.GetObject(typeof(IPmtGeneralSrRstDB), string.Format("{0}/MyAppPmtGeneralSrRst", wkStr));
        }
    }
}
