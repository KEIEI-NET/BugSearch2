//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �݌Ƀ}�X�^
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2010/08/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// �݌Ƀ}�X�^DB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X�͍݌Ƀ}�X�^DB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���SupplierDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2010/08/11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationStockMstDB
    {
        /// <summary>
        /// �݌Ƀ}�X�^����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        public MediationStockMstDB()
        {
        }
        /// <summary>
        /// IStockMstDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <remarks>
        /// <br>Note       : IStockMstDB�C���^�[�t�F�[�X�擾�B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns>IIOWriteMAHNBDB�I�u�W�F�N�g</returns>
        public static IStockMstDB GetStockMstDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:20020";
# endif

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IStockMstDB)Activator.GetObject(typeof(IStockMstDB), string.Format("{0}/MyAppStockMst", wkStr));
        }
    }
}
