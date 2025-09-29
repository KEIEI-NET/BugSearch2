//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �o�i�ꊇ�X�V
// �v���O��������   : �o�i�ꊇ�X�V ����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11270001-00   �쐬�S�� : �v��
// �� �� �� : 2016/01/22    �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Diagnostics;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// PartsMaxStockUpdDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : ���̃N���X��IPartsMaxStockUpdDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>    ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���IPartsMaxStockUpdDB��</br>
    /// <br>    �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer  : �v��</br>
    /// <br>Date        : 2016/01/22</br>
    /// <br></br>
    /// </remarks>
    public class MediationPartsMaxStockUpdDB
    {
        /// <summary>
        /// PartsMaxStockUpdDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer  : �v��</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks>
        public MediationPartsMaxStockUpdDB()
        {
        }

        /// <summary>
        /// IPartsMaxStockUpdDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IPartsMaxStockUpdDB�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note        : IPartsMaxStockUpdDB�C���^�[�t�F�[�X�擾�B</br>
        /// <br>Programmer  : �v��</br>
        /// <br>Date        : 2016/01/22</br>
        /// <br></br>
        /// </remarks>
        public static IPartsMaxStockUpdDB GetPartsMaxStockUpdDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
# if DEBUG
            wkStr = "http://localhost:9001";
# endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IPartsMaxStockUpdDB)Activator.GetObject(typeof(IPartsMaxStockUpdDB), string.Format("{0}/MyAppPartsMaxStockUpd", wkStr));
        }
    }
}
