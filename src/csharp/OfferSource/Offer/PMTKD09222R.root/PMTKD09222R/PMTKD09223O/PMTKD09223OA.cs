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
    /// �񋟃}�[�W�Ώی���DBRemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �񋟃}�[�W�Ώی���RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.09.08</br>
    /// <br></br>
    /// <br>Update Note: 11370006-00 �n���f�B�^�[�~�i���Ή�</br>
    /// <br>             �o�[�R�[�h�}�X�^�X�V�ǉ��Ή�</br>
    /// <br>Programmer : �e�c ���V</br>
    /// <br>Date       : 2017/08/01</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]
    public interface IMergeDataGet
    {
        /// <summary>
        /// �񋟂̃}�[�W�f�[�^�擾
        /// </summary>
        /// <param name="offerDate">�擾����񋟃f�[�^�̒񋟓��t</param>
        /// <param name="cond">�擾����</param>
        /// <param name="retList">�擾���ʂ̃��X�g�iCustomSerializeArrayList�j</param>
        /// <param name="bigCarOfferDiv">��^�敪</param>
        /// <param name="searchPartsType">�����^�C�v</param>
        /// <returns>��������</returns>
        [MustCustomSerialization]
        int GetMergeData(int offerDate,
            MergeInfoGetCond cond,
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retList,
            int searchPartsType,
            int bigCarOfferDiv
            );

        /// <summary>
        /// �񋟂̕��i���擾
        /// </summary>
        /// <param name="offerDate">�擾����񋟃f�[�^�̒񋟓��t</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">(�������i,�D�Ǖ��i�p)�i��</param>
        /// <param name="goodsPriceNo">(�D�ǉ��i�p)�i��</param>
        /// <param name="retList">�擾���ʂ̃��X�g�iCustomSerializeArrayList�j</param>
        /// <returns>��������</returns>
        [MustCustomSerialization]
        int GetGoodsInfo(int offerDate,
            int makerCode,
            string goodsNo,
            string goodsPriceNo,
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retList);

        /// <summary>
        /// ���i�����̍ŐV�񋟓��t�擾
        /// </summary>
        /// <param name="blDate">BL�R�[�h</param>
        /// <param name="goodsMDate">������</param>
        /// <param name="groupDate">BL�O���[�v</param>
        /// <param name="makerDate">���i���[�J�[</param>
        /// <param name="modelNmDate">�Ԏ�</param>
        /// <param name="partsPosDate">����</param>
        /// <param name="ptmkpriceDate">���i���i</param>
        /// <param name="primPartsDate">�D�ǉ��i</param>
        /// <param name="prmSetChgDate">�D�ǐݒ�ύX</param>
        /// <param name="prmSetDate">�D��</param>
        /// <param name="offerDateList">�񋟓��t���X�g</param>
        /// <param name="bigCarOfferDiv">��^�敪</param>
        /// <param name="searchPartsType">�����^�C�v</param>
        /// <returns></returns>
        //[MustCustomSerialization]
        int GetOfferDate(int blDate, int groupDate, int goodsMDate, int modelNmDate, int makerDate, int partsPosDate,
            int ptmkpriceDate, int primPartsDate, int prmSetDate, int prmSetChgDate, int searchPartsType, int bigCarOfferDiv,
            //[CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object offerDateList);


        /// <summary>
        /// ���i�����p�X�V���[�J�[�擾
        /// </summary>
        /// <param name="offerDate">�񋟓��t</param>
        /// <param name="makerObj">���[�J�[���X�g</param>
        /// <returns></returns>
        int GetMakerInfo(int offerDate,
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object makerObj);

        // -- DEL 2010/06/14 ---------------------------->>>
        ///// <summary>
        ///// ���i�����p�X�V���[�J�[�擾
        ///// </summary>
        ///// <param name="instalOfferDate">�C���X�g�[�����t�擾</param>
        ///// <returns></returns>
        //int GetInstalDate(ref DateTime instalOfferDate);
        // -- DEL 2010/06/14 ----------------------------<<<


        // --- ADD 2017/08/01 Y.Wakita ---------->>>>>
        /// <summary>
        /// ���i�����̍ŐV�񋟓��t�擾
        /// </summary>
        /// <param name="blDate">BL�R�[�h</param>
        /// <param name="goodsMDate">������</param>
        /// <param name="groupDate">BL�O���[�v</param>
        /// <param name="makerDate">���i���[�J�[</param>
        /// <param name="modelNmDate">�Ԏ�</param>
        /// <param name="partsPosDate">����</param>
        /// <param name="ptmkpriceDate">���i���i</param>
        /// <param name="primPartsDate">�D�ǉ��i</param>
        /// <param name="prmSetChgDate">�D�ǐݒ�ύX</param>
        /// <param name="prmSetDate">�D��</param>
        /// <param name="goodsBarcodeRevnDate">�D�Ǖ��i�o�[�R�[�h</param>
        /// <param name="offerDateList">�񋟓��t���X�g</param>
        /// <param name="bigCarOfferDiv">��^�敪</param>
        /// <param name="searchPartsType">�����^�C�v</param>
        /// <returns></returns>
        //[MustCustomSerialization]
        int GetOfferDate(int blDate, int groupDate, int goodsMDate, int modelNmDate, int makerDate, int partsPosDate,
            int ptmkpriceDate, int primPartsDate, int prmSetDate, int prmSetChgDate, int goodsBarcodeRevnDate, int searchPartsType, int bigCarOfferDiv,
            out object offerDateList);

        /// <summary>
        /// �o�[�R�[�h�����p�X�V���[�J�[�擾
        /// </summary>
        /// <param name="offerDate">�񋟓��t</param>
        /// <param name="partsMakerObj">���i���[�J�[���X�g</param>
        /// <returns></returns>
        int GetPartsMakerInfo(int offerDate,
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object partsMakerObj);

        /// <summary>
        /// �񋟂̕��i���擾
        /// </summary>
        /// <param name="offerDate">�擾����񋟃f�[�^�̒񋟓��t</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="retList">�擾���ʂ̃��X�g�iCustomSerializeArrayList�j</param>
        /// <returns>��������</returns>
        [MustCustomSerialization]
        int GetPrmPrtBrcdInfo(int offerDate,
            int makerCode,
            string goodsNo,
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retList);
        // --- ADD 2017/08/01 Y.Wakita ----------<<<<<


    }
}
