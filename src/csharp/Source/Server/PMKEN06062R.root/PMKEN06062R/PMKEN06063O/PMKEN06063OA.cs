using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���[�U�[���i���� RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[�U�[���i���� RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.06.10</br>
    /// <br></br>
    /// <br>Update Note: 2009.02.19 20056 ���n ��� MAX�����w��\Search���\�b�h�ǉ�</br>
    /// <br>Update Note: 2009.02.19 20056 ���n ��� MANTIS[0012224] LogicalMode�w���Search���\�b�h�ǉ�</br>
    /// <br>Update Note: 2013/02/08 �c����</br>
    /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/26�z�M��</br>
    /// <br>           : Redmine#34640 ���i�݌Ƀ}�X�^�̎d�l�ύX(#33231�̎c����)</br>
    /// <br>Update Note: K2013/03/18 �c����</br>
    /// <br>�Ǘ��ԍ�   : 10806793-00 2013/04/10�z�M��</br>
    /// <br>           : Redmine#35071 ���i�݌Ƀ}�X�^�E�R�`���i�l�ʑg�ݍ��݁i#34640�c���j</br>
    /// <br>Update Note: 2013/03/18 yangyi</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 20150515�z�M���̑Ή�</br>
    /// <br>           : Redmine#34962 �@�u���i�݌Ɉꊇ�C���v�̃T�[�o�[���׌y���Ή�</br>
    /// <br>Update Note: 2014/02/06 ���� ����q</br>
    /// <br>�Ǘ��ԍ�   : </br>
    /// <br>           : SCM�d�|�ꗗ��10632�Ή�</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IUsrJoinPartsSearchDB
    {
#if SpecChange
        /// <summary>
        /// ���[�U�[���i����[��ցE�����E�Z�b�g]
        /// </summary>
        /// <param name="searchFlg">�����t���O</param>
        /// <param name="searchCond">��������</param>
        /// <param name="usrPartsSubstRetWork">��֌�������</param>	
        /// <param name="usrJoinPartsRetWork">������������</param>
        /// <param name="usrGoodsRetWork">���i��������</param>
        /// <param name="usrSetPartsRetWork">�Z�b�g��������</param>
        /// <param name="usrGoodsPrice">���i���i���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.10</br>
        [MustCustomSerialization]
        int UserGoodsJoinSearch(
            UsrSearchFlg searchFlg,
            object searchCond,
            [CustomSerializationMethodParameterAttribute("PMKEN06064D", "Broadleaf.Application.Remoting.ParamData.UsrPartsSubstRetWork")]
			out ArrayList usrPartsSubstRetWork,
            [CustomSerializationMethodParameterAttribute("PMKEN06064D", "Broadleaf.Application.Remoting.ParamData.UsrJoinPartsRetWork")]
			out ArrayList usrJoinPartsRetWork,
            [CustomSerializationMethodParameterAttribute("PMKEN06064D", "Broadleaf.Application.Remoting.ParamData.UsrGoodsRetWork")]
			out ArrayList usrGoodsRetWork,
            [CustomSerializationMethodParameterAttribute("PMKEN06064D", "Broadleaf.Application.Remoting.ParamData.UsrSetPartsRetWork")]
			out ArrayList usrSetPartsRetWork,
            [CustomSerializationMethodParameterAttribute("PMKEN06064D", "Broadleaf.Application.Remoting.ParamData.UsrGoodsPriceWork")]
            out ArrayList usrGoodsPrice);
#endif
        /// <summary>
        /// ���[�U�[���i����[��ցE�����E�Z�b�g]
        /// </summary>
        /// <param name="retObj"></param>
        /// <param name="searchFlg">�����t���O</param>
        /// <param name="searchType"></param>
        /// <param name="searchCond">��������</param>
        /// <returns></returns>
        [MustCustomSerialization]
        int UserGoodsJoinSearch(
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object retObj,
            UsrSearchFlg searchFlg,
            int searchType, 
            object searchCond);

        // 2009/09/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ���[�U�[���i����[��ցE�����E�Z�b�g]
        /// </summary>
        /// <param name="retObj"></param>
        /// <param name="searchFlg"></param>
        /// <param name="searchType"></param>
        /// <param name="logicalMode"></param>
        /// <param name="searchCond"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int UserGoodsJoinSearch(
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object retObj,
            UsrSearchFlg searchFlg,
            int searchType,
            ConstantManagement.LogicalMode logicalMode,
            object searchCond);
        // 2009/09/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// ���[�U�[���i����[��ցE�����E�Z�b�g]
        /// </summary>
        /// <param name="retObj"></param>
        /// <param name="listSearchFlg"></param>
        /// <param name="listSearchType"></param>
        /// <param name="logicalMode"></param>
        /// <param name="listSearchCond"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int UserGoodsJoinSearch(
            out ArrayList retObj,
            ArrayList listSearchFlg,
            ArrayList listSearchType,
            ConstantManagement.LogicalMode logicalMode,
            ArrayList listSearchCond
            );
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        /// <summary>
        /// ���[�U�[���i���� DB�����[�g�I�u�W�F�N�g
        /// </summary>
        /// <param name="partsNoSearchCondWork">��������[1���F�B�������@ArrayList�F����]</param>
        /// <param name="searchType">0:���S��v/1:�O����v/2:�����v/3:�B��/4:�n�C�t���������S��v/5:[����]����������</param>
        /// <param name="usrGoodsRetWork"></param>
        /// <param name="usrGoodsPrice"></param>
        /// <param name="usrGoodsStock"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int UserGoodsSearch(
            object partsNoSearchCondWork,
            int searchType, 
            [CustomSerializationMethodParameterAttribute("PMKEN06064D", "Broadleaf.Application.Remoting.ParamData.UsrGoodsRetWork")]
			out ArrayList usrGoodsRetWork,
            [CustomSerializationMethodParameterAttribute("MAKHN09176D", "Broadleaf.Application.Remoting.ParamData.GoodsPriceUWork")]
            out ArrayList usrGoodsPrice,
            [CustomSerializationMethodParameterAttribute("MAZAI04136D", "Broadleaf.Application.Remoting.ParamData.StockWork")]
            out ArrayList usrGoodsStock
            );

        // 2009/09/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ���[�U�[���i���� DB�����[�g�I�u�W�F�N�g
        /// </summary>
        /// <param name="partsNoSearchCondWork"></param>
        /// <param name="searchType"></param>
        /// <param name="logicalMode"></param>
        /// <param name="usrGoodsRetWork"></param>
        /// <param name="usrGoodsPrice"></param>
        /// <param name="usrGoodsStock"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int UserGoodsSearch(
            object partsNoSearchCondWork,
            int searchType,
            ConstantManagement.LogicalMode logicalMode,
            [CustomSerializationMethodParameterAttribute("PMKEN06064D", "Broadleaf.Application.Remoting.ParamData.UsrGoodsRetWork")]
			out ArrayList usrGoodsRetWork,
            [CustomSerializationMethodParameterAttribute("MAKHN09176D", "Broadleaf.Application.Remoting.ParamData.GoodsPriceUWork")]
            out ArrayList usrGoodsPrice,
            [CustomSerializationMethodParameterAttribute("MAZAI04136D", "Broadleaf.Application.Remoting.ParamData.StockWork")]
            out ArrayList usrGoodsStock
            );
        // 2009/09/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// ���[�U�[���i���� DB�����[�g�I�u�W�F�N�g
        /// </summary>
        /// <param name="partsNoSearchCondWork"></param>
        /// <param name="searchType"></param>
        /// <param name="logicalMode"></param>
        /// <param name="usrGoodsRetWork"></param>
        /// <param name="usrGoodsPrice"></param>
        /// <param name="usrGoodsStock"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int UserGoodsSearch(
            ArrayList partsNoSearchCondWork,
            ArrayList searchType,
            ConstantManagement.LogicalMode logicalMode,
            [CustomSerializationMethodParameterAttribute("PMKEN06064D", "Broadleaf.Application.Remoting.ParamData.UsrGoodsRetWork")]
			out ArrayList usrGoodsRetWork,
            [CustomSerializationMethodParameterAttribute("MAKHN09176D", "Broadleaf.Application.Remoting.ParamData.GoodsPriceUWork")]
            out ArrayList usrGoodsPrice,
            [CustomSerializationMethodParameterAttribute("MAZAI04136D", "Broadleaf.Application.Remoting.ParamData.StockWork")]
            out ArrayList usrGoodsStock
            );
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

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

        // -- ADD 2011/03/17 ------------------------->>>
        /// <summary>
        /// ���[�U�[���i�}�X�^�Ɖ��i�}�X�^�݂̂��擾���܂��B
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="maxCount">�擾MAX����(���i���)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int UsrGoodsOnlySearch(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object retObj,
            object paraObj,
            int readMode,
            int maxCount,
            ConstantManagement.LogicalMode logicalMode);
        // -- ADD 2011/03/17 -------------------------<<<

        //-------- ADD �c���� 2013/02/08 Redmine#34640 ------->>>>>
        /// <summary>
        /// ���i���ɂ���Đŗ����LIST��߂�܂�
        /// </summary>
        /// <param name="work">���i���</param>
        /// <param name="rateList">�߂胊�X�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i���ɂ���Đŗ����LIST��߂�܂�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2013/02/08</br>
        /// </remarks>
        [MustCustomSerialization]
        int GetRateWorkByGood(
            GoodsUnitDataWork work,
            [CustomSerializationMethodParameterAttribute("DCKHN09166D", "Broadleaf.Application.Remoting.ParamData.RateWork")]
            out ArrayList rateList
            );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parmWork">��������</param>
        /// <param name="readMode">�������[�h�i�O�F�O�ŁG�P�F���Łj</param>
        /// <param name="retObj">��������</param>
        /// <returns></returns>
        [MustCustomSerialization]
        int GetPrevNextGoods(
            GoodsUnitDataWork parmWork,
            int readMode,
            [CustomSerializationMethodParameterAttribute("MAKHN09286D", "Broadleaf.Application.Remoting.ParamData.GoodsUWork")]
			out ArrayList retObj
            );
        //-------- ADD �c���� 2013/02/08 Redmine#34640 -------<<<<<
        //-------- ADD �c���� K2013/03/18 Redmine#35071 ------->>>>>
        /// <summary>
        /// �]�ƈ��Ǘ�����Ǎ����܂�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <param name="unCstChngDiv">���P���C���敪</param>
        /// <param name="stckCntChngDiv">�݌ɐ��C���敪</param>
        /// <returns>STATUS</returns>
        int ReadMng(string enterpriseCode, string employeeCode, out int unCstChngDiv, out int stckCntChngDiv);
        //-------- ADD �c���� K2013/03/18 Redmine#35071 -------<<<<<

        #region [ ���i�\���擾DB RemoteObject�C���^�[�t�F�[�X���瓝���������\�b�h ]
        /// <summary>
        /// ���i�\���擾LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2006.12.06</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object retObj,
            object paraObj,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);

        // 2009.02.19 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ���i�\���擾LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="maxCount">�擾MAX����(���i���)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object retObj,
            object paraObj,
            int readMode,
            int maxCount,
            ConstantManagement.LogicalMode logicalMode);
        // 2009.02.19 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        
        /// <summary>
        /// ���i�\���擾LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2006.12.06</br>
        [MustCustomSerialization]
        int SearchMultiCondition(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object retObj,
            object paraObj,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j����V�K�o�^(���i�}�X�^�ɑ��݂��Ȃ��ꍇ�̂�)
        /// </summary>
        /// <param name="goodsUWork">GoodsUWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j����V�K�o�^(���i�}�X�^�ɑ��݂��Ȃ��ꍇ�̂�)</br>
        /// <br>Programmer : 20081�@�D�c�@�E�l</br>
        /// <br>Date       : 2008.06.12</br>
        [MustCustomSerialization]
        int ReadNewWriteRelation(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object goodsUWork
            );

        #region ���i�n�}�X�^���ꊇ�ŏ�������ׂ̃��\�b�h
        ///// <summary>
        ///// ���i�}�X�^�i���[�U�[�o�^���jLIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        ///// </summary>
        ///// <param name="goodsUWork">��������</param>
        ///// <param name="paragoodsUWork">�����p�����[�^</param>
        ///// <param name="readMode">�����敪</param>
        ///// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : </br>
        ///// <br>Programmer : 21015�@�����@�F��</br>
        ///// <br>Date       : 2007.01.24</br>
        //[MustCustomSerialization]
        //int SearchRelation(
        //    [CustomSerializationMethodParameterAttribute("MAKHN09286D", "Broadleaf.Application.Remoting.ParamData.GoodsUWork")]
        //    out object goodsUWork,
        //    object paragoodsUWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ���i�E���i�E�݌Ɂ^��ց^�����^�Z�b�g�̓o�^�E�X�V���s���܂��B
        /// ��ւȂǂł͌�����2���i�����i�[���邽��
        /// �i���i�E���i�E�݌Ɂj���̂�ArrayList�ɐݒ肵�A���̏��͒���CustomSerializeArrayList��Add����B
        /// </summary>
        /// <param name="goodsUWork">GoodsUWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.24</br>
        [MustCustomSerialization]
        int WriteRelation(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object goodsUWork
            );

        // ----- ADD huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC�� ----- >>>>>
        /// <summary>
        /// ���i�E���i�E�݌Ɂ^��ց^�����^�Z�b�g�̓o�^�E�X�V���s���܂��B
        /// ��ւȂǂł͌�����2���i�����i�[���邽��
        /// �i���i�E���i�E�݌Ɂj���̂�ArrayList�ɐݒ肵�A���̏��͒���CustomSerializeArrayList��Add����B
        /// </summary>
        /// <param name="goodsUWork">GoodsUWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j����o�^�A�X�V���܂�</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2014/01/15</br>
        [MustCustomSerialization]
        int WriteRelationForShipmentCnt(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object goodsUWork
            );

        // ----- ADD huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC�� ----- <<<<<

        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j����_���폜���܂�
        /// </summary>
        /// <param name="goodsUWork">GoodsUWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j����_���폜���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.24</br>
        [MustCustomSerialization]
        int LogicalDeleteRelation(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object goodsUWork
            );

        /// <summary>
        /// �_���폜���i�}�X�^�i���[�U�[�o�^���j���𕜊����܂�
        /// </summary>
        /// <param name="goodsUWork">GoodsUWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜���i�}�X�^�i���[�U�[�o�^���j���𕜊����܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.24</br>
        [MustCustomSerialization]
        int RevivalLogicalDeleteRelation(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object goodsUWork
            );

        /// <summary>
        /// ���i�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="paraobj">���i�}�X�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : ���i�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2006.12.08</br>
        int DeleteRelation(object paraobj);
        #endregion
        #endregion

        // --- ADD yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
        /// <summary>
        /// ���i�\���擾LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y(���i�݌Ɉꊇ�o�^�C���p)
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="maxCount">�擾MAX����(���i���)</param>
        /// <param name="targetDiv">�Ώۋ敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object retObj,
            object paraObj,
            int readMode,
            int maxCount,
            int targetDiv,
            ConstantManagement.LogicalMode logicalMode);
        // --- ADD yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<
    }
}
