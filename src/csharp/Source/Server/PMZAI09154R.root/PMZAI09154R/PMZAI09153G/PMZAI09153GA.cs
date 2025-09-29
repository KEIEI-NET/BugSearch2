//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �݌ɗ������݌ɐ��ݒ�DB����N���X
//                  :   PMZAI09153G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   �����
// Date             :   2009/12/24
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// MonthlyTtlStockUpdDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IMonthlyTtlStockUpdDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���MonthlyTtlStockUpdDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.12.12</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationStockHistoryUpdateDB
    {
        /// <summary>
        /// StockHistoryUpdateDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        public MediationStockHistoryUpdateDB()
        {

        }

        /// <summary>
        /// IStockHistoryUpdateDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IStockHistoryUpdateDB�I�u�W�F�N�g</returns>
        public static IStockHistoryUpdateDB GetStockHistoryUpdateDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IStockHistoryUpdateDB)Activator.GetObject(typeof(IStockHistoryUpdateDB), string.Format("{0}/MyAppStockHistoryUpdate", wkStr));
        }
    }
}
