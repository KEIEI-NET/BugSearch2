using System;
using System.Collections;
//using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Runtime.Remoting.Messaging;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// ���i��񌟍�DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i��񌟍� RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
    public interface IClgPrmPartsInfoSearchDB
    {
        /// <summary>
        /// �񋟕i�Ԍ��� DB�����[�g�I�u�W�F�N�g
        /// </summary>
        /// <param name="partsNoSearchCondList"></param>
        /// <param name="listOfrPartsRet"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int Search(
            ArrayList partsNoSearchCondList,
            [CustomSerializationMethodParameterAttribute("PMTKD06093D", "Broadleaf.Application.Remoting.ParamData.OfrPartsRetWork")]
			out ArrayList listOfrPartsRet,
            [CustomSerializationMethodParameterAttribute("PMTKD06093D", "Broadleaf.Application.Remoting.ParamData.OfrPartsPriceRetWork")]
            out ArrayList listOfrPartsPriceRet
        );

        /// <summary>
        /// �񋟕i�Ԍ������Z�b�g�Ȃ��E�����Ȃ��� DB�����[�g�I�u�W�F�N�g
        /// </summary>
        /// <param name="partsNoSearchCondWork"></param>
        /// <param name="offerPrimePartsRetWork"></param>
        /// <param name="offerPrimePartsPriceRet"></param>
        /// <param name="ptMkrPriceRetWork"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int Search(
            PartsNoSearchCondWork partsNoSearchCondWork,
            [CustomSerializationMethodParameterAttribute("PMTKD06093D", "Broadleaf.Application.Remoting.ParamData.OfrPartsRetWork")]
			out ArrayList offerPrimePartsRetWork,
            [CustomSerializationMethodParameterAttribute("PMTKD06093D", "Broadleaf.Application.Remoting.ParamData.OfrPartsPriceRetWork")]
            out ArrayList offerPrimePartsPriceRet,
            [CustomSerializationMethodParameterAttribute("PMTKD06093D", "Broadleaf.Application.Remoting.ParamData.OfrPartsRetWork")]
			out ArrayList ptMkrPriceRetWork
        );

        /// <summary>
        /// �񋟕i�Ԍ������Z�b�g����E�������聄 DB�����[�g�I�u�W�F�N�g
        /// </summary>
        /// <param name="partsNoSearchCondWork"></param>
        /// <param name="offerPrimePartsRetWork"></param>
        /// <param name="ptMkrPriceRetWork"></param>
        /// <param name="offerJoinPartsRetWork"></param>
        /// <param name="offerSetPartsRetWork"></param>
        /// <param name="opt">�����Ώ� 1:�񋟌�����񌟍��@2:�񋟃Z�b�g��񌟍��@3:��������</param>
        /// <returns></returns>
        [MustCustomSerialization]
        int Search(
            PartsNoSearchCondWork partsNoSearchCondWork,
            [CustomSerializationMethodParameterAttribute("PMTKD06093D", "Broadleaf.Application.Remoting.ParamData.OfrPartsRetWork")]
			out ArrayList offerPrimePartsRetWork,
            [CustomSerializationMethodParameterAttribute("PMTKD06093D", "Broadleaf.Application.Remoting.ParamData.OfrPartsRetWork")]
			out ArrayList ptMkrPriceRetWork,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferJoinPartsRetWork")]
			out ArrayList offerJoinPartsRetWork,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferSetPartsRetWork")]
			out ArrayList offerSetPartsRetWork,
            int opt
        );
    }
}
