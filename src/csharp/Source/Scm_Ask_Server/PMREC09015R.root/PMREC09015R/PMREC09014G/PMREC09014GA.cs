//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R�����h���i�֘A�ݒ�}�X�^�����e
// �v���O�����T�v   : ���R�����h���i�֘A�ݒ�}�X�^�����eDB����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��������
// �� �� ��  2015.01.16  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// RecGoodsLkDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IRecGoodsLkDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���RecGoodsLkDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ��������</br>
    /// <br>Date       : 2015.01.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationRecGoodsLkDB
    {
        /// <summary>
        /// RecGoodsLkDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ��������</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public MediationRecGoodsLkDB()
        {
        }

		/// <summary>
        /// IRecGoodsLkDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>IRecGoodsLkDB�I�u�W�F�N�g</returns>
        public static IRecGoodsLkDB GetRecGoodsLkDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IRecGoodsLkDB)Activator.GetObject(typeof(IRecGoodsLkDB), string.Format("{0}/MyAppRecGoodsLk", wkStr));
        }
    }
}
