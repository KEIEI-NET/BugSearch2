using System;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using System.Runtime.Remoting.Messaging;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �D�Ǖ��i���擾 RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �D�Ǖ��i��񌟍� RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: 2014/05/09�@�g��</br>
    /// <br>           : ���x���P�t�F�[�Y�Q��11,��12 �i���^�C�~���O�ύX</br>
    /// <br></br>
    /// <br>Update Note: 2014/06/12�@30744 ���� ����q</br>
    /// <br>           : ���x���P�t�F�[�Y�Q��Q�Ή�</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]
    public interface IPrimePartsInfo
    {
        /// <summary>
        /// �D�Ǖi�Ԍ��� DB�����[�g�I�u�W�F�N�g
        /// </summary>
        /// <param name="InPara"></param>
        /// <param name="inRetInf"></param>
        /// <param name="inPrimePrice"></param>
        /// <param name="inRetSetParts"></param>
        /// <param name="SetPrice"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int GetPartsInf(
            GetPrimePartsInfPara InPara,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferJoinPartsRetWork")]
            out ArrayList inRetInf,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferJoinPriceRetWork")]
            out ArrayList inPrimePrice,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferSetPartsRetWork")]
            out ArrayList inRetSetParts,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferJoinPriceRetWork")]
            out ArrayList SetPrice);

        /// <summary>
        /// �����i�ԁ���������[BL����]
        /// </summary>
        /// <param name="priceDate"></param>
        /// <param name="substFlg">��փt���O[true:����/false:���Ȃ�]</param>
        /// <param name="carMakerCd">�����i�������p�ԃ��[�J�[�R�[�h[0�̏ꍇ�͌����i�������Ȃ�]</param>
        /// <param name="inPara">�����p�����[�^</param>		
        /// <param name="inRetInf">���i���</param>
        /// <param name="inPrimePrice"></param>
        /// <param name="inRetSetParts"></param>
        /// <param name="SetPrice"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int GetPartsInfByCtlgPtNo(
            bool substFlg,
            int carMakerCd,
            ArrayList inPara,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferJoinPartsRetWork")]
            out ArrayList inRetInf,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferJoinPriceRetWork")]
            out ArrayList inPrimePrice,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferSetPartsRetWork")]
            out ArrayList inRetSetParts,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferJoinPriceRetWork")]
            out ArrayList SetPrice);

        // DEL 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi ----->>>>>
        //// // ADD 2014/05/09 ���x���P�t�F�[�Y�Q��11,��12 �g��  -------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// �����񓚐�p �e��v���p�e�B �L���b�V������
        ///// </summary>
        ///// <param name="obAutoAnsItemStList">�����񓚕i�ڐݒ�}�X�^���X�g</param>
        ///// <param name="obPrmSettingList">�D��ݒ�}�X�^���X�g</param>
        ///// <param name="sectionCodeWk">���_�R�[�h</param>
        ///// <param name="customerCodeWk">���Ӑ�R�[�h</param>
        ///// <returns></returns>
        //void CacheAutoAnswer(
        //    string sectionCodeWk,
        //    int customerCodeWk,
        //    System.Collections.Generic.List<object> obAutoAnsItemStList,
        //    System.Collections.Generic.List<object> obPrmSettingList
        //    );
        //
        ///// <summary>
        ///// �����񓚐�p �e��v���p�e�B �L���b�V���N���A
        ///// </summary>
        ///// <returns></returns>
        //void CacheClearAutoAnswer();
        //// // ADD 2014/05/09 ���x���P�t�F�[�Y�Q��11,��12 �g��  --------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        // DEL 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi -----<<<<<

        // ADD 2014/05/13 PM-SCM���x���� �t�F�[�Y�Q��17.�D�Ǖi�������ǑΉ� ---------------------------------->>>>>
        /// <summary>
        /// �����񓚐�p �����i�ԁ���������[BL����]
        /// </summary>
        /// <param name="substFlg">��փt���O[true:����/false:���Ȃ�]</param>
        /// <param name="carMakerCd">�����i�������p�ԃ��[�J�[�R�[�h[0�̏ꍇ�͌����i�������Ȃ�]</param>
        /// <param name="inPara">�����p�����[�^</param>		
        /// <param name="inRetInf">���i���</param>
        /// <param name="inPrimePrice"></param>
        /// <param name="inRetSetParts"></param>
        /// <param name="SetPrice"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int GetPartsInfByCtlgPtNoAutoAnswer(
            // DEL 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi -----<<<<<
            string sectionCodeWk, 
            int customerCodeWk,
            System.Collections.Generic.List<object> obAutoAnsItemStList,
            System.Collections.Generic.List<object> obPrmSettingList,
            // DEL 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi -----<<<<<
            bool substFlg,
            int carMakerCd,
            ArrayList inPara,
            // UPD 2014/06/12 PM-SCM���x���� �t�F�[�Y�Q ��Q�Ή� ---------------------------->>>>>
            //out ArrayList inRetInf,
            //out ArrayList inPrimePrice,
            //out ArrayList inRetSetParts,
            //out ArrayList SetPrice);
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object inRetInf,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object inPrimePrice,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object inRetSetParts,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object SetPrice);
        // UPD 2014/06/12 PM-SCM���x���� �t�F�[�Y�Q ��Q�Ή� ----------------------------<<<<<
        // ADD 2014/05/13 PM-SCM���x���� �t�F�[�Y�Q��17.�D�Ǖi�������ǑΉ� ----------------------------------<<<<<

        /// <summary>
        /// �i���擾(�S�p)
        /// </summary>
        /// <param name="makerCd">���[�J�R�[�h</param>
        /// <param name="partsNo">�n�C�t���t�i��</param>
        /// <param name="name">�i��</param>
        /// <returns></returns>
        int GetPartsName(int makerCd, string partsNo, out string name);

        /// <summary>
        /// �i���擾(���p)
        /// </summary>
        /// <param name="makerCd">���[�J�R�[�h</param>
        /// <param name="partsNo">�n�C�t���t�i��</param>
        /// <param name="name">�i��</param>
        /// <returns></returns>
        int GetPartsNameKana(int makerCd, string partsNo, out string name);

#if Kill0618
        /// <summary>
        /// �D�ǁE�Z�b�g��֌���
        /// </summary>
        /// <param name="inPara">�����������X�g</param>
        /// <param name="retSubstParts">��֕��i���X�g</param>
        /// <param name="retSubstPrice">��֕��i���i���X�g</param>
        /// <returns></returns>
        [MustCustomSerialization]
        int GetJoinSubst(
            ArrayList inPara,
            [CustomSerializationMethodParameterAttribute("SFTKD00434D", "Broadleaf.Application.Remoting.ParamData.PartsSubstWork")]
            out ArrayList retSubstParts,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferJoinPriceRetWork")]
            out ArrayList retSubstPrice
            );
#endif
    }
}
