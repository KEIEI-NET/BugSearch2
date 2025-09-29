using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Runtime.Remoting.Messaging;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// �D��BL�R�[�h�������擾DBRemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �D��BL�R�[�h�������擾�C���^�[�t�F�[�X�N���X�ł��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]
    public interface IOfferPrimeBlSearchDB
    {
        /// <summary>
        /// �w�肳�ꂽ�p�����[�^�ŗD��BL���������܂�
        /// </summary>
        /// <param name="offerPrimeBlSearchCondWork">�����p�����[�^</param>
        /// <param name="offerPrimeSearchRetWork">�擾�������</param>	
        /// <param name="offerPrimePriceRetWork"></param>
        /// <param name="offerPrimeBlSearchSetPartsRetWork"></param>
        /// <param name="offerSetPartPrice"></param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int Search(
            OfferPrimeBlSearchCondWork offerPrimeBlSearchCondWork,
            [CustomSerializationMethodParameterAttribute("PMTKD06034D", "Broadleaf.Application.Remoting.ParamData.OfferPrimeSearchRetWork")]
			out ArrayList offerPrimeSearchRetWork,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferJoinPriceRetWork")]
            out ArrayList offerPrimePriceRetWork,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferSetPartsRetWork")]
            out ArrayList offerPrimeBlSearchSetPartsRetWork,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferJoinPriceRetWork")]
            out ArrayList offerSetPartPrice);

        // �s�v
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="searchSetPartsCondWork"></param>
        ///// <param name="offerPrimeBlSearchSetPartsRetWork"></param>
        ///// <returns></returns>
        //[MustCustomSerialization]
        //int Search(
        //    ArrayList searchSetPartsCondWork,
        //    [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferSetPartsRetWork")]
        //    out ArrayList offerPrimeBlSearchSetPartsRetWork);

    }
}
