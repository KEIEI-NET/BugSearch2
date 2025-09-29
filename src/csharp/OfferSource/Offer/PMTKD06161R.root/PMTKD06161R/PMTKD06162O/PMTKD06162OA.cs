using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Runtime.Remoting.Messaging;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// ���i�擾DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�擾 RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 99033�@��{�@�E</br>
    /// <br>Date       : 2005.05.19</br>
    /// <br></br>
    /// <br>Update Note: 2010/04/28  22018 ��� ���b</br>
    /// <br>           : ���R�����I�v�V�����Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2010/06/04  22018 ��� ���b</br>
    /// <br>           : ���ʕ�����</br>
    /// <br>           : �@���R���� 2010/04/28 �̑g��</br>
    /// <br></br>
    /// <br>Update Note: ���i�}�X�^�X�V�����ŃZ���N�g�R�[�h�𖳎����čX�V�����s��̑Ή�</br>
    /// <br>             ���i�}�X�^�X�V�����ȊO��PG�ł���肪�������Ă��邪�A���}���A���i�}�X�^�X�V�����݂̂���</br>
    /// <br>             �Ă΂�郁�\�b�h��V�K�쐬���đΉ��B�ʓr�P�v�Ή����s��</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2015/04/08</br>
    /// <br></br>
    /// <br>Update Note: 2015/04/08�̎b��Ή��ł̃��\�b�h���폜���A�������\�b�h�iGetPrimePartsInfProc�j�ɑ΂��āA</br>
    /// <br>             �����Ή����s���B</br>
    /// <br>             ���i�}�X�^�X�V�����ŃZ���N�g�R�[�h�𖳎����čX�V�����s��Ή�</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2015/04/10</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
    public interface IOfferPartsInfo
    {

        /// <summary>
        /// �������i�擾���\�b�h
        /// </summary>
        /// <param name="InPara">�p�����[�^</param>
        /// <param name="RetInf">���i���߂�</param>
        /// <param name="ColorWork">�J���[���߂�</param>
        /// <param name="TrimWork">�g�������߂�</param>
        /// <param name="EquipWork">�������߂�</param>
        /// <param name="prtSubstWork">���i��֏��߂�</param>
        /// <param name="partsModelLnkWork">���i�[�^�������N���߂�</param>
        /// <param name="RetCnt">RetInf�̌�</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 99033�@��{�@�E</br>
        /// <br>Date       : 2005.04.14</br>
        /// <br>Date       : 2007.03.27 iwa partsModelLnkWork�ǉ�</br>
        [MustCustomSerialization]
        int GetPartsInf(GetPartsInfPara InPara,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object RetInf,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object ColorWork,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object TrimWork,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object EquipWork,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object prtSubstWork,
            out List<PartsModelLnkWork> partsModelLnkWork, out long RetCnt);

        // --- ADD m.suzuki 2010/04/28 ---------->>>>>
        /// <summary>
        /// �������i�擾���\�b�h
        /// </summary>
        /// <param name="InPara">�p�����[�^</param>
        /// <param name="RetInf">���i���߂�</param>
        /// <param name="ColorWork">�J���[���߂�</param>
        /// <param name="TrimWork">�g�������߂�</param>
        /// <param name="EquipWork">�������߂�</param>
        /// <param name="prtSubstWork">���i��֏��߂�</param>
        /// <param name="partsModelLnkWork">���i�[�^�������N���߂�</param>
        /// <param name="RetInfFreeSearch">���i���߂�i���R�����p�j</param>
        /// <param name="prtSubstWorkFreeSearch">���i��֏��߂�i���R�����p�j</param>
        /// <param name="retPrimParts"></param>
        /// <param name="retPrimPrice"></param>
        /// <param name="retPrimSet"></param>
        /// <param name="retPrimSetPrice"></param>
        /// <param name="RetCnt">RetInf�̌�</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 22018�@��� ���b</br>
        /// <br>Date       : 2010/04/27</br>
        [MustCustomSerialization]
        int GetPartsInf( GetPartsInfPara InPara,
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
                ref object RetInf,
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
                ref object ColorWork,
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
                ref object TrimWork,
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
                ref object EquipWork,
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
                ref object prtSubstWork,
            out List<PartsModelLnkWork> partsModelLnkWork,
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
                ref object RetInfFreeSearch,
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
                ref object prtSubstWorkFreeSearch,
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
                ref object retPrimParts,
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
                ref object retPrimPrice,
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
                ref object retPrimSet,
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
                ref object retPrimSetPrice,
            out long RetCnt );

        // ADD 2014/05/13 PM-SCM���x���� �t�F�[�Y�Q��16.�����i�������ǑΉ� ---------------------------------->>>>>
        /// <summary>
        /// �������i�擾���\�b�h
        /// </summary>
        /// <param name="InParaList">�p�����[�^</param>
        /// <param name="RetInf">���i���߂�</param>
        /// <param name="ColorWork">�J���[���߂�</param>
        /// <param name="TrimWork">�g�������߂�</param>
        /// <param name="EquipWork">�������߂�</param>
        /// <param name="prtSubstWork">���i��֏��߂�</param>
        /// <param name="partsModelLnkWork">���i�[�^�������N���߂�</param>
        /// <param name="RetInfFreeSearch">���i���߂�i���R�����p�j</param>
        /// <param name="prtSubstWorkFreeSearch">���i��֏��߂�i���R�����p�j</param>
        /// <param name="retPrimParts"></param>
        /// <param name="retPrimPrice"></param>
        /// <param name="retPrimSet"></param>
        /// <param name="retPrimSetPrice"></param>
        /// <param name="RetCnt">RetInf�̌�</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        [MustCustomSerialization]
        int GetPartsInf(ArrayList InParaList,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object RetInf,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object ColorWork,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object TrimWork,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object EquipWork,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object prtSubstWork,
            out List<PartsModelLnkWork> partsModelLnkWork,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object RetInfFreeSearch,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object prtSubstWorkFreeSearch,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object retPrimParts,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object retPrimPrice,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object retPrimSet,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object retPrimSetPrice,
            out long RetCnt);
        // ADD 2014/05/13 PM-SCM���x���� �t�F�[�Y�Q��16.�����i�������ǑΉ� ----------------------------------<<<<<

        // ���x���P�e�X�g -------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �������i�擾���\�b�h
        /// </summary>
        /// <param name="InPara">�p�����[�^</param>
        /// <param name="RetInf">���i���߂�</param>
        /// <param name="ColorWork">�J���[���߂�</param>
        /// <param name="TrimWork">�g�������߂�</param>
        /// <param name="EquipWork">�������߂�</param>
        /// <param name="prtSubstWork">���i��֏��߂�</param>
        /// <param name="partsModelLnkWork">���i�[�^�������N���߂�</param>
        /// <param name="RetInfFreeSearch">���i���߂�i���R�����p�j</param>
        /// <param name="prtSubstWorkFreeSearch">���i��֏��߂�i���R�����p�j</param>
        /// <param name="retPrimParts"></param>
        /// <param name="retPrimPrice"></param>
        /// <param name="retPrimSet"></param>
        /// <param name="retPrimSetPrice"></param>
        /// <param name="RetCnt">RetInf�̌�</param>
        /// <param name="obFoundAutoAnsItemStList"></param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int GetPartsInfYYYY(GetPartsInfPara InPara,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object RetInf,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object ColorWork,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object TrimWork,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object EquipWork,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object prtSubstWork,
            out List<PartsModelLnkWork> partsModelLnkWork,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object RetInfFreeSearch,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object prtSubstWorkFreeSearch,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object retPrimParts,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object retPrimPrice,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object retPrimSet,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object retPrimSetPrice,
            out long RetCnt,
            List<object> obFoundAutoAnsItemStList
            );
        // ���x���P�e�X�g --------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        
        /// <summary>
        /// SearchTbsCodeInfoProc
        /// </summary>
        /// <param name="FullModelFixedNos"></param>
        /// <param name="blCode"></param>
        /// <param name="PartsNameWorks"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int SearchTbsCodeInfo(
            int[] FullModelFixedNos,
            int blCode,
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
            ref object PartsNameWorks );
        // --- ADD m.suzuki 2010/04/28 ----------<<<<<

        // ADD 2014/05/13 PM-SCM���x���� �t�F�[�Y�Q��13.�t���^���Œ�ԍ�����̂a�k�R�[�h�����񐔉��ǑΉ� ---------------------------------->>>>>
        /// <summary>
        /// SearchTbsCodeInfoProc
        /// </summary>
        /// <param name="FullModelFixedNos"></param>
        /// <param name="paraList"></param>
        /// <param name="PartsNameWorks"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int SearchTbsCodeInfo(
            int[] FullModelFixedNos,
            ArrayList paraList,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object PartsNameWorks);
        // ADD 2014/05/13 PM-SCM���x���� �t�F�[�Y�Q��13.�t���^���Œ�ԍ�����̂a�k�R�[�h�����񐔉��ǑΉ� ----------------------------------<<<<<

        /// <summary>
        /// SearchTbsCodeInfoProc
        /// </summary>
        /// <param name="FullModelFixedNos"></param>
        /// <param name="PartsNameWorks"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int SearchTbsCodeInfo(int[] FullModelFixedNos,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object PartsNameWorks);

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

        /// <summary>
        /// �D�ǂ��珃������
        /// </summary>
        /// <param name="makerCd">�D�ǃ��[�J�R�[�h</param>
        /// <param name="partsNo">�D�Ǖi��(�n�C�t���t)</param>
        /// <param name="RetInf">�������i���X�g</param>
        /// <returns></returns>
        int GetGenuineParts(int makerCd, string partsNo,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                out object RetInf);

        /// <summary>
        /// �i�ԕ�����������
        /// </summary>
        /// <param name="lstSrchCond">�������X�g</param>
        /// <param name="lstRst">�������i��񃊃X�g</param>
        /// <param name="lstRstPrm">�D�Ǖ��i��񃊃X�g</param>
        /// <param name="lstPrmPrice">�D�ǉ��i���X�g</param>
        /// <returns></returns>
        int GetOfrPartsInf(ArrayList lstSrchCond,
            [CustomSerializationMethodParameterAttribute("PMTKD06163D", "Broadleaf.Application.Remoting.ParamData.RetPartsInf")]
            out ArrayList lstRst,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferJoinPartsRetWork")]
            out ArrayList lstRstPrm,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferJoinPriceRetWork")]
            out ArrayList lstPrmPrice);

        // DEL osanai 2015/04/10------------------------------------>>>>>
        #region [2015/04/10 �b��Ή��Ń��\�b�h�폜]
        //// -- ADD osanai 2015/04/08 ------------------------------------------->>>
        ////���L���\�b�h�́A���i�}�X�^�X�V�����p�̎b�胁�\�b�h�̂��߁A�P�v�Ή����ɍ폜����B

        ///// <summary>
        ///// �i�ԕ�����������
        ///// </summary>
        ///// <param name="lstSrchCond">�������X�g</param>
        ///// <param name="lstRst">�������i��񃊃X�g</param>
        ///// <param name="lstRstPrm">�D�Ǖ��i��񃊃X�g</param>
        ///// <param name="lstPrmPrice">�D�ǉ��i���X�g</param>
        ///// <returns></returns>
        //int GetOfrPartsInfGoodsUpdateOnly(ArrayList lstSrchCond,
        //    [CustomSerializationMethodParameterAttribute("PMTKD06163D", "Broadleaf.Application.Remoting.ParamData.RetPartsInf")]
        //    out ArrayList lstRst,
        //    [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferJoinPartsRetWork")]
        //    out ArrayList lstRstPrm,
        //    [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferJoinPriceRetWork")]
        //    out ArrayList lstPrmPrice);
        //// -- ADD osanai 2015/04/08 -------------------------------------------<<<
        #endregion
        // DEL osanai 2015/04/10------------------------------------<<<<<

        /// <summary>
        /// ���i�ꊇ�o�^�p���\�b�h
        /// </summary>
        /// <param name="InPara">�p�����[�^</param>
        /// <param name="RetInf">���i���߂�</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2009.01.16</br>
        [MustCustomSerialization]
        int SearchParts(PrtsSrchCndWork InPara,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object RetInf);

#if NoUse
		/// <summary>
		/// �w�肳�ꂽ���i�R�[�h�ɑ΂��ĕ��i�����擾���܂��B
		/// </summary>
		/// <param name="InPara">���i�擾�p�����[�^</param>
		/// <param name="RetCnt">�擾����</param>		
		/// <param name="RetInf">���i��������</param>		
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 99033�@��{�@�E</br>
		/// <br>Date       : 2005.04.14</br>
		[MustCustomSerialization]
		int GetPartsInf(GetPartsInfPara InPara  , ref object RetInf ,ref object EquipWork ,out long RetCnt);
		
		/// <summary>
		/// �w�肳�ꂽ�p�����[�^�ŕ��i���ꊇ�擾���܂�
		/// </summary>
		/// <param name="InPara">�����p�����[�^</param>
		/// <param name="RetInf">�擾������Ə��</param>		
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 99033�@��{�@�E</br>
		/// <br>Date       : 2005.04.14</br>
		[MustCustomSerialization]
        int SeachPartsInf(SerchPartsInfPara InPara, [CustomSerializationMethodParameterAttribute("PMTKD06163D", "Broadleaf.Application.Remoting.ParamData.RetPartsInf")]ref object RetInf, [CustomSerializationMethodParameterAttribute("SFTKD00434D", "Broadleaf.Application.Remoting.ParamData.PartsColorWork")]ref object ColorWork, [CustomSerializationMethodParameterAttribute("SFTKD00434D", "Broadleaf.Application.Remoting.ParamData.PartsTrimWork")]ref object TrimWork, [CustomSerializationMethodParameterAttribute("SFTKD00434D", "Broadleaf.Application.Remoting.ParamData.PartsEquipWork")]ref object EquipWork, out long RetCnt);		

		/// <summary>
		/// �Ԍ��،^�������[�h���܂��B
		/// </summary>
		/// <param name="InPara">�p�����[�^</param>
		/// <param name="CarInspectCertModel">�Ԍ��،^��</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 99033�@��{�@�E</br>
		/// <br>Date       : 2005.04.14</br>
		int GetCarInspectCertModel(GetCarInspectCertModelPara InPara ,ref string CarInspectCertModel );
#endif

    }
}
