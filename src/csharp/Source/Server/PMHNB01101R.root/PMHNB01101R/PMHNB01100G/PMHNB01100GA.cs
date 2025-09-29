//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   ���㌎���W�v�f�[�^�X�VDB����N���X
//                  :   PMHNB01100G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   21112�@�v�ۓc�@��
// Date             :   2008.05.19
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
    /// MonthlyTtlSalesUpdDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IMonthlyTtlSalesUpdDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���MonthlyTtlSalesUpdDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 21112�@�v�ۓc�@��</br>
    /// <br>Date       : 2008.05.19</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationMonthlyTtlSalesUpdDB
    {
        /// <summary>
        /// MonthlyTtlSalesUpdDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2008.05.19</br>
        /// </remarks>
        public MediationMonthlyTtlSalesUpdDB()
        {

        }

        /// <summary>
        /// IMonthlyTtlSalesUpdDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IMonthlyTtlSalesUpdDB�I�u�W�F�N�g</returns>
        public static IMonthlyTtlSalesUpdDB GetMonthlyTtlSalesUpdDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IMonthlyTtlSalesUpdDB)Activator.GetObject(typeof(IMonthlyTtlSalesUpdDB),string.Format("{0}/MyAppMonthlyTtlSalesUpd",wkStr));
        }
    }
}
