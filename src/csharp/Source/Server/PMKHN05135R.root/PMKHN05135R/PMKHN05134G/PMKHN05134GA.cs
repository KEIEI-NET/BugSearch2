//**************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@���_�R�[�h�ϊ�SectionConvertDB����N���X
// �v���O�����T�v   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//=====================================================================================//
// ����
//-------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2017/12/15  �C�����e : �V�K�쐬
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
    /// <br>Note       : ���̃N���X��ISectionConvertDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���SectionConvertDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2017/12/15</br>
    /// </remarks>
    public class MediationSectionConvertDB
    {
        // <summary>
        /// SectionConvertDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        public MediationSectionConvertDB()
        {
            // �����Ȃ�
        }

        /// <summary>
        /// ISectionConvertDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ISectionConvertDB�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        public static ISectionConvertDB GetSectionConvertDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            //wkStr = "http://localhost:9001";
            wkStr = "http://localhost:8009";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ISectionConvertDB)Activator.GetObject(typeof(ISectionConvertDB), string.Format("{0}/MyAppSectionConvert", wkStr));
        }
    }
}
