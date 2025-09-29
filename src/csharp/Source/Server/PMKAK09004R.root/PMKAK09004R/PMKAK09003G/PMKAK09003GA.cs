//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �d����}�X�^�i�����ݒ�jDB����N���X
//                  :   PMKAK09003G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   FSI�֓� �a�G
// Date             :   2012/08/29
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SumSuppStDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ISumSuppStDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���SumSuppStDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : FSI�֓� �a�G</br>
    /// <br>Date       : 2012/08/29</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSumSuppStDB
    {
        /// <summary>
        /// SumSuppStDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/29</br>
        /// </remarks>
        public MediationSumSuppStDB()
        {

        }

        /// <summary>
        /// ISumSuppStDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ISumSuppStDB�I�u�W�F�N�g</returns>
        public static ISumSuppStDB GetSumSuppStDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ISumSuppStDB)Activator.GetObject(typeof(ISumSuppStDB),string.Format("{0}/MyAppSumSuppSt",wkStr));
        }
    }
}
