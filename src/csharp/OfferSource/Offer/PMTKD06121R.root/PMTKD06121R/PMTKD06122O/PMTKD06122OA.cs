using System;
using System.Collections;
using Broadleaf.Library.Resources;
using System.Windows.Forms;
using System.Runtime.Remoting.Messaging;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// �񋟎��q��񌋍�����DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �񋟎��q��񌋍����� RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 96186�@���ԁ@�T��</br>
    /// <br>Date       : 2007.03.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
    public interface IColTrmEquInfDB
    {
        /// <summary>
        /// �J���[�E�g�����E��������߂��܂�
        /// </summary>
        /// <param name="colorCdRetWork"></param>
        /// <param name="trimCdRetWork"></param>
        /// <param name="cEqpDefDspRetWork"></param>
        /// <param name="colTrmEquSearchCondWork"></param>
        /// <returns></returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 96186�@���ԁ@�T��</br>
        /// <br>Date       : 2007.03.05</br>
        [MustCustomSerialization]
        int SearchColTrmEquInf(
            [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.ColorCdRetWork")]
			out object colorCdRetWork,
            [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.TrimCdRetWork")]
			out object trimCdRetWork,
            [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CEqpDefDspRetWork")]
			out object cEqpDefDspRetWork,
            ref object colTrmEquSearchCondWork
        );
    }
}
