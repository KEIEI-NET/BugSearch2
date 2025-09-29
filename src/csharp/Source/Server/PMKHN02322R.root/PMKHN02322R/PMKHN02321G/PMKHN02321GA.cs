//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �e�L�X�g�o�͑��샍�O�o�^����DB����N���X
// �v���O�����T�v   : �e�L�X�g�o�͑��샍�O�o�^����
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570163-00  �쐬�S�� : �c����
// �� �� ��  2019/08/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// TextOutPutOprtnHisLogDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ITextOutPutOprtnHisLogDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���TextOutPutOprtnHisLogDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2019/08/12</br>
    /// </remarks>
    public class MediationTextOutPutOprtnHisLogDB
    {
        /// <summary>
        /// DataCopyDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/08/12</br>
        /// </remarks>
        public MediationTextOutPutOprtnHisLogDB()
        {

        }

        /// <summary>
        /// ITextOutPutOprtnHisLogDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ITextOutPutOprtnHisLogDB�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : ITextOutPutOprtnHisLogDB�C���^�[�t�F�[�X�擾�������s��</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/08/12</br>
        /// </remarks>
        public static ITextOutPutOprtnHisLogDB GetDataCopyDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ITextOutPutOprtnHisLogDB)Activator.GetObject(typeof(ITextOutPutOprtnHisLogDB), string.Format("{0}/MyAppTextOutPutOprtnHisLog", wkStr));
        }
    }
}
