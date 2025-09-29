//**************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[�� �`�[�ԍ��ϊ� SlipNoConvertDB����N���X
// �v���O�����T�v   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2018 Broadleaf Co.,Ltd.
//=====================================================================================//
// ����
//-------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  11470153-00 �쐬�S�� : �q��
// �C �� ��  2018/09/07  �C�����e : �V�K�쐬
//-------------------------------------------------------------------------------------//
using System;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SectionConvertDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ISlipNoConvertDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���SectionConvertDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 30175 �q��</br>
    /// <br>Date       : 2018/09/07</br>
    /// </remarks>
    public class MediationSlipNoConvertDB
    {
        // <summary>
        /// SlipNoConvertDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/07</br>
        /// </remarks>
        public MediationSlipNoConvertDB()
        {
            // �����Ȃ�
        }

        /// <summary>
        /// ISlipNoConvertDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ISlipNoConvertDB�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/07</br>
        /// </remarks>
        public static ISlipNoConvertDB GetSlipNoConvertDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            //wkStr = "http://localhost:9001";
            wkStr = "http://localhost:8009";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ISlipNoConvertDB)Activator.GetObject(typeof(ISlipNoConvertDB), string.Format("{0}/MyAppSlipNoConvert", wkStr));
        }
    }
}
