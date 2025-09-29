//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �݌Ƀ}�X�^�R���o�[�g
// �v���O�����T�v   : �݌ɊǗ��S�̐ݒ�̌��݌ɕ\���敪���A�o�׉\�����X�V����B
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2011/08/26  �C�����e : �A��No.1016 �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
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
    /// �݌Ƀ}�X�^�R���o�[�gDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X�͎d����ϊ��c�[��DB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���SupplierDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2011/08/26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationStockConvertDB
    {
        /// <summary>
        /// �݌Ƀ}�X�^�R���o�[�g����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/08/26</br>
        /// </remarks>
        public MediationStockConvertDB()
        {
        }
        /// <summary>
        /// IStockConverDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IStockConverDB�I�u�W�F�N�g</returns>
        public static IStockConvertDB GetStockConvertDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:20020";
# endif

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IStockConvertDB)Activator.GetObject(typeof(IStockConvertDB), string.Format("{0}/MyAppStockConvert", wkStr));
        }
    }
}
