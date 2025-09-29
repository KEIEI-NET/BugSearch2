using System;
using System.Collections;
using Broadleaf.Library.Resources;
using System.Runtime.Remoting.Messaging;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// �񋟎��q��񌋍�����[TBO�����}�X�^]DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �񋟎��q��񌋍����� RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
    public interface ITBOSearchInfDB
    {
        /// <summary>
        /// �w�肳�ꂽ�p�����[�^�Œ񋟎��q��񌋍������擾���܂�
        /// </summary>
        /// <param name="tBOSearchCondWork">�����p�����[�^</param>
        /// <param name="tBOSearchRetWork">�擾�������</param>
        /// <param name="tBOSearchPriceRetWork"></param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.05.15</br>
        [MustCustomSerialization]
        int Search(
            TBOSearchCondWork tBOSearchCondWork,
            [CustomSerializationMethodParameterAttribute("PMTKD06074D", "Broadleaf.Application.Remoting.ParamData.TBOSearchRetWork")]
			out ArrayList tBOSearchRetWork,
            [CustomSerializationMethodParameterAttribute("PMTKD06074D", "Broadleaf.Application.Remoting.ParamData.TBOSearchPriceRetWork")]
            out ArrayList tBOSearchPriceRetWork);

    }
}
