//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����A�g�e�L�X�g�o��
// �v���O�����T�v   : ����A�g�e�L�X�g�o�͒��[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 11570219-00      �쐬�S�� : �c����
// �� �� �� 2019/12/02       �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Diagnostics;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SalesCprtWorkDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ISalesCprtWorkDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���SalesCprtWorkDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2019/12/02</br>
    /// <br></br>
    /// </remarks>
    public class MediationSalesCprtResultDB
    {
        /// <summary>
        /// SalesCprtWorkDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        public MediationSalesCprtResultDB()
        {
        }
        /// <summary>
        /// ISalesCprtWorkDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ISalesCprtWorkDB�I�u�W�F�N�g</returns>
        public static ISalesCprtWorkDB GetSalesCprtWorkDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            
            // �f�o�b�O�p
#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ISalesCprtWorkDB)Activator.GetObject(typeof(ISalesCprtWorkDB), string.Format("{0}/MyAppISalesCprt", wkStr));
        }
    }
}
