//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �D�ǃf�[�^�폜����
// �v���O�����T�v   : �D�ǃf�[�^�폜����
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00 �쐬�S�� : ���X��
// �� �� ��  2011/07/15  �C�����e : �A��No.2 �V�K�쐬                      
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
//****************************************************************************//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// MonthlyTtlStockUpdDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��MediationYuuRyouDataDelDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���MediationYuuRyouDataDelDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer	: ���X��</br>
    /// <br>Date		: 2011/07/13</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationYuuRyouDataDelDB
    {
        /// <summary>
        /// MediationYuuRyouDataDelDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.12.12</br>
        /// </remarks>
        public MediationYuuRyouDataDelDB()
        {

        }

        /// <summary>
        /// IYuuRyouDataDelDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IYuuRyouDataDelDB�I�u�W�F�N�g</returns>
        public static IYuuRyouDataDelDB GetYuuRyouDataDelDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IYuuRyouDataDelDB)Activator.GetObject(typeof(IYuuRyouDataDelDB), string.Format("{0}/MyAppYuuRyouDataDel", wkStr));
        }
    }
}
