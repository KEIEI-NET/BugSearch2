using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// �D�ǐݒ�}�X�^ RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �D�ǐݒ�}�X�^���� RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.14</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>

    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
    public interface IPrimeSettingDB
    {

        /// <summary>
        /// �񋟗D�ǐݒ�LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="PrimeSettingRetWork">�D�ǐݒ茟������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMTKD09023D", "Broadleaf.Application.Remoting.ParamData.PrmSettingWork")]
            out object PrimeSettingRetWork);

        /// <summary>
        /// �񋟗D�ǐݒ���lLIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="PrimeSettingNoteRetWork">�D�ǐݒ���l��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        [MustCustomSerialization]
        int SearchNote(
            [CustomSerializationMethodParameterAttribute("PMTKD09023D", "Broadleaf.Application.Remoting.ParamData.PrmSetNoteWork")]
            out object PrimeSettingNoteRetWork);

        /// <summary>
        /// �񋟗D�ǐݒ�ύX�}�X�^LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="PrimeSettingChgWork">�D�ǐݒ�ύX�}�X�^��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// [MustCustomSerialization]
        int SearchChg(
            [CustomSerializationMethodParameterAttribute("PMTKD09023D", "Broadleaf.Application.Remoting.ParamData.PrmSettingChgWork")]
            out object PrimeSettingChgWork);
    }
}
