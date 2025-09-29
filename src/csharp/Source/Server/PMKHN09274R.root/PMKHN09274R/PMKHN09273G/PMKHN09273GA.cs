//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ꊇ���A���X�V
// �v���O�����T�v   : �ꊇ���A���X�VDB����N���X�B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/12/24  �C�����e : �V�K�쐬
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
    /// �ꊇ���A���X�VDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X�͈ꊇ���A���X�VDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���SupplierDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2009/12/24</br>
    /// </remarks>
    public class AllRealUpdToolDB
    {
        /// <summary>
        /// �ꊇ���A���X�V����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        public AllRealUpdToolDB()
        {
        }
        /// <summary>
        /// ISupplierChangeProcDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ISupplierChangeProcDB�I�u�W�F�N�g</returns>
        public static IAllRealUpdToolDB GetAllRealUpdToolDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
# endif

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IAllRealUpdToolDB)Activator.GetObject(typeof(IAllRealUpdToolDB), string.Format("{0}/MyAppAllRealUpdTool", wkStr));
        }
    }
}
