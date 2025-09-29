//********************************************************************//
// System           :   PM.NS                                         //
// Sub System       :                                                 //
// Program name     :   ����A�g�ݒ�DB����N���X                      //
//                  :   PMSCM09073G.DLL                               //
// Name Space       :   Broadleaf.Application.Remoting.Adapter        //
// Programmer       :   gaoy                                          //
// Date             :   2011.07.23                                    //
//--------------------------------------------------------------------//
// Update Note      :                                                 //
//--------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.               //
//********************************************************************//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// PM7RkSettingDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IPM7RkSettingDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���PM7RkSettingDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : gaoy</br>
    /// <br>Date       : 2011.07.25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPM7RkSettingDB
    {
        /// <summary>
        /// BackUpExecutionDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ��������</br>
        /// <br>Date       : 2011.06.22</br>
        /// </remarks>
        public MediationPM7RkSettingDB()
        {
        }

		/// <summary>
        /// IPM7RkSettingDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>IPM7RkSettingDB�I�u�W�F�N�g</returns>
        public static IPM7RkSettingDB GetPM7RkSettingDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IPM7RkSettingDB)Activator.GetObject(typeof(IPM7RkSettingDB), string.Format("{0}/MyAppPM7RkSetting", wkStr));
        }
    }
}
