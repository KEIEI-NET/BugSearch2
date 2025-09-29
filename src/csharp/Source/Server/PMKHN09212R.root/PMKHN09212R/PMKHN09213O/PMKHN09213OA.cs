using System;
using System.Collections;
using Broadleaf.Library.Resources;
using System.Runtime.Remoting.Messaging;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// ���[�U�[�}�[�W����DB�����[�g�I�u�W�F�N�g�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[�U�[�}�[�W����DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.09.08</br>
    /// <br></br>
    /// <br>Update Note: 2010/05/24 ��r��</br>
    /// <br>             PM.NS1009</br>
    /// <br>             ���i���������폜</br>
    /// <br>Update Note: 2014/08/21 songg </br>
    /// <br>�Ǘ��ԍ�   : 11070149-00  PM.NS�@PM7����E�v�][��X�e]�Ή��FPM.NS���x���P</br>
    /// <br>           : Redmine#35573 </br>
    /// <br>           : �u�񋟃f�[�^�X�V�v�Ń������ᔽ���������邽�߁A�����Ƒ΍�����肢���܂��i��1923�j</br>
    /// <br>Update Note: 2021/07/20 3H ���r</br>
    /// <br>�Ǘ��ԍ�   : 11770032-00 ��s�z�M�}�[�W�Ή�</br>
    /// <br>           : �u�񋟃f�[�^�X�V�����v�@�\���V���A���C�Y��Q�Ή�</br>
    /// <br>Update Note: 2025/08/11 �c������</br>
    /// <br>�Ǘ��ԍ�   : 12170169-00</br>
    /// <br>           : �񋟃f�[�^�̒񋟓��t�������̓��t�ɂȂ��Ă���s��̋~�ϑΉ�</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IOfferMerge
    {
        /// <summary>
        /// �}�[�W�Ώۂ̃��[�U�[DB�f�[�^���擾����B
        /// </summary>
        /// <param name="cond"></param>
        /// <param name="lstPMaker"></param>
        /// <param name="retList"></param>
        /// <returns></returns>
        /// <br>Update Note : 2021/07/20 3H ���r</br>
        /// <br>�Ǘ��ԍ�    : 11770032-00 ��s�z�M�}�[�W�Ή�</br>
        /// <br>            :�u�񋟃f�[�^�X�V�����v�@�\���V���A���C�Y��Q�Ή�</br>
        [MustCustomSerialization]// ADD 2021/07/20 3H ���r �u�񋟃f�[�^�X�V�����v�@�\���V���A���C�Y��Q�Ή�
        int GetMergeObject(
            MergeObjectCond cond,
            ArrayList lstPMaker,
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retList);

        /// <summary>
        /// �f�[�^��n���A�}�[�W�������s���B
        /// </summary>
        /// <param name="updateDataDiv">�X�V�f�[�^�敪(0:�t�h�@1:����)[�����L�^�p]</param>
        /// <param name="offerDate">�񋟓��t[�����L�^�p]</param>
        /// <param name="lstData"></param>
        /// <returns></returns>
        int WriteMergeData(
            int updateDataDiv,
            int offerDate,
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            object lstData);

        /// <summary>
        /// ���i��������
        /// </summary>
        /// <param name="st">���i�����ݒ�</param>
        /// <param name="lst">���i���������p�f�[�^���X�g</param>
        /// <param name="retList">�������ʂ̃��X�g</param>
        /// <returns></returns>
        int DoPriceRevision(
            PriceMergeSt st, 
            CustomSerializeArrayList lst,
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retList
            );

        /// <summary>
        /// ���i���������擾
        /// </summary>
        /// <param name="cond">�����擾����</param>
        /// <param name="retList">���i���������f�[�^���X�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns></returns>
        /// <br>Update Note : 2021/07/20 3H ���r</br>
        /// <br>�Ǘ��ԍ�    : 11770032-00 ��s�z�M�}�[�W�Ή�</br>
        /// <br>            :�u�񋟃f�[�^�X�V�����v�@�\���V���A���C�Y��Q�Ή�</br>
        [MustCustomSerialization]// ADD 2021/07/20 3H ���r �u�񋟃f�[�^�X�V�����v�@�\���V���A���C�Y��Q�Ή�
        int GetUpdateHistory(
            PriUpdHistCondWork cond,
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retList, 
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ���i���������̍ŐV�񋟓��t�擾
        /// </summary>
        /// <param name="offerDate">�ŐV�񋟓��t</param>
        /// <returns></returns>
        int GetLastOfferDate(out int offerDate);


        /// <summary>
        /// �}�[�W�����{���i��������
        /// </summary>
        /// <param name="offerDate">�ŐV�񋟓��t</param>
        /// <param name="upDateDiv">�X�V�敪</param>
        /// <param name="st">���i�����ݒ�</param>
        /// <param name="lst">���i���������p�f�[�^���X�g</param>
        /// <param name="retList">���i�����������ʃ��X�g</param>
        /// <param name="lstData">�}�[�W�������X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h���X�g</param>
        /// <param name="currentVersion">�񋟃o�[�W����</param>
        /// <param name="PrmSetList">�񋟗D�ǐݒ�ؽ�</param>
        /// <param name="NameChgFlg">�D�ǖ��̍X�V�׸�</param>
        /// <param name="allUpdateCount">�D�ǐݒ�X�V����</param>
        /// <param name="partsPsDate">���ʃ}�X�^�񋟓��t</param>
        /// <param name="updateMasterObj">��ʃ`�F�b�N�t���O</param>
        /// <returns></returns>
        /// <br>Update Note : 2021/07/20 3H ���r</br>
        /// <br>�Ǘ��ԍ�    : 11770032-00 ��s�z�M�}�[�W�Ή�</br>
        /// <br>            :�u�񋟃f�[�^�X�V�����v�@�\���V���A���C�Y��Q�Ή�</br>
        [MustCustomSerialization]// ADD 2021/07/20 3H ���r �u�񋟃f�[�^�X�V�����v�@�\���V���A���C�Y��Q�Ή�
        int WriteManual(int upDateDiv, int offerDate, PriceMergeSt st, CustomSerializeArrayList lst,
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retList,
            //[CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]// DEL 2021/07/20 3H ���r �u�񋟃f�[�^�X�V�����v�@�\���V���A���C�Y��Q�Ή�
            object lstData,
            CustomSerializeArrayList PrmSetList,
            string enterpriseCode,
            string currentVersion,
            bool NameChgFlg,
            ref int allUpdateCount,
            object updateMasterObj,
            int partsPsDate);


        /// <summary>
        /// �}�[�W�`�F�b�N
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="MergeResultData">����</param>
        /// <param name="currentVersion">�񋟃o�[�W����</param>
        /// <returns></returns>
        int MergeChk(string enterpriseCode,
            out int MergeResultData,
            string currentVersion);



        /// <summary>
        /// ���i���������̍ŐV�񋟓��t�擾
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="LatestList">����</param>
        /// <returns></returns>
        /// <br>Update Note : 2021/07/20 3H ���r</br>
        /// <br>�Ǘ��ԍ�    : 11770032-00 ��s�z�M�}�[�W�Ή�</br>
        /// <br>            :�u�񋟃f�[�^�X�V�����v�@�\���V���A���C�Y��Q�Ή�</br>
        [MustCustomSerialization]// ADD 2021/07/20 3H ���r �u�񋟃f�[�^�X�V�����v�@�\���V���A���C�Y��Q�Ή�
        int GetLatestHistory(string enterpriseCode,
            //[CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]// DEL 2021/07/20 3H ���r �u�񋟃f�[�^�X�V�����v�@�\���V���A���C�Y��Q�Ή�
            [CustomSerializationMethodParameter("PMKHN09214D", "Broadleaf.Application.Remoting.ParamData.PriUpdTblUpdHisWork")]// ADD 2021/07/20 3H ���r �u�񋟃f�[�^�X�V�����v�@�\���V���A���C�Y��Q�Ή�
            out object LatestList);


        // ADD 2025/08/11 �c������ ----->>>>> 
        /// <summary>
        /// ���i���������̑S�񋟓��t�擾
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="currentDate">�����p�񋟃f�[�^���t</param>
        /// <param name="tableID">�񋟃f�[�^�e�[�u��ID</param>
        /// <param name="AllList">����</param>
        /// <returns></returns>
        [MustCustomSerialization]
        int GetOtherHistories(string enterpriseCode, string currentDate, string tableID,
            [CustomSerializationMethodParameter("PMKHN09214D", "Broadleaf.Application.Remoting.ParamData.PriUpdTblUpdHisWork")]
            out object AllList);
        // ADD 2025/08/11 �c������ -----<<<<< 


        // 2010/04/23 >>>
        ///// <summary>
        ///// ���[�U�[���i�A���̍ŐV�񋟓��t�擾
        ///// </summary>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="MakerCd">���[�J�[�R�[�h</param>
        ///// <param name="retList">����</param>
        ///// <returns></returns>
        //int UsrJoinPartsSearch(string enterpriseCode, int MakerCd,
        //    [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
        //    out ArrayList retList);

        /// <summary>
        /// ���[�U�[���i�����i���i�E���i�E�D�ǐݒ�j
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="makerCd">���[�J�[�R�[�h</param>
        /// <param name="goodsNoList">�����������X�g</param>
        /// <param name="retObj">����</param>
        /// <returns></returns>
        /// <br>Update Note : 2021/07/20 3H ���r</br>
        /// <br>�Ǘ��ԍ�    : 11770032-00 ��s�z�M�}�[�W�Ή�</br>
        /// <br>            :�u�񋟃f�[�^�X�V�����v�@�\���V���A���C�Y��Q�Ή�</br>
        [MustCustomSerialization]// ADD 2021/07/20 3H ���r �u�񋟃f�[�^�X�V�����v�@�\���V���A���C�Y��Q�Ή�
        int UsrPartsSearch(
            string enterpriseCode,
            string sectionCode,
            int makerCd,
            ArrayList goodsNoList, // ADD BY songg 2014/08/21 FOR Redmine#35573 �u�񋟃f�[�^�X�V�v�Ń������ᔽ��������Q�Ή�
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out  object retObj);
        // 2010/04/23 <<<

        // --- ADD 2010/05/24 ---------->>>>>
        /// <summary>
        /// ���i���������폜
        /// </summary>
        /// <param name="historyList">���i�����X�V�����i�[����</param>
        /// <remarks>
        /// <br>Note       : �폜������ǉ�����</br>
        /// <br>Programmer : ��r��</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        int DeleteHistory(ArrayList historyList);
        // --- ADD 2010/05/24 -----------<<<<<

    }
}
