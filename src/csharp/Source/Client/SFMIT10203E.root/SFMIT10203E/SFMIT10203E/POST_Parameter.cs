using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ��ď��i�o�^POST�p�����[�^
    /// </summary>
    public class ProposeGoods_MAIN
    {
        public ProposeGoods[] goods;
    }

    /// public class name:   ProposeGoods
	/// <summary>
	///                      ��ď��i�N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   ��ď��i�N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2016/5/24</br>
	/// <br>Genarated Date   :   2016/06/03  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2016/6/2  �����m</br>
	/// <br>                 :   �݌ɐ�</br>
	/// <br>                 :   BL���i�R�[�h</br>
	/// <br>                 :   BL���i�R�[�h�}��</br>
	/// <br>                 :   ��ǉ�</br>
	/// </remarks>
    public class ProposeGoods
    {
        /// <summary>UUID</summary>
        public string uuid = "";

        /// <summary>�쐬����</summary>
        public long insDtTime;

        /// <summary>�X�V����</summary>
        public long updDtTime;

        /// <summary>�쐬�A�J�E���gID</summary>
        public Int32 insAccountId;

        /// <summary>�X�V�A�J�E���gID</summary>
        public Int32 updAccountId;

        /// <summary>�_���폜�敪</summary>
        public Int32 logicalDelDiv;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        public string enterpriseCode = "";

        /// <summary>��Ɩ���</summary>
        public string enterpriseName = "";

        /// <summary>���_�R�[�h</summary>
        public string sectionCode = "";

        /// <summary>���_����</summary>
        public string sectionName = "";

        /// <summary>��ď��iID</summary>
        public long proposeGoodsId;

        /// <summary>��ď��i����</summary>
        public string proposeGoodsName = "";

        /// <summary>���i�J�e�S���[ID</summary>
        public long goodsCategoryId;

        /// <summary>BL�R�[�h</summary>
        public Int32 blCode;

        /// <summary>BL�R�[�h�}��</summary>
        public Int32 blCodeBranche;

        /// <summary>�i��</summary>
        public string partsNumber = "";

        /// <summary>PM���[�J�[�R�[�h</summary>
        public Int32 pmMakerCode;

        /// <summary>���[�J�[����</summary>
        public string makerName = "";

        /// <summary>�摜ID</summary>
        public long imageId;

        /// <summary>������</summary>
        public string releaseDate = "";

        /// <summary>�݌ɏ��</summary>
        public Int32 stockState;

        /// <summary>���i����</summary>
        public string goodsNote = "";

        /// <summary>���iPR</summary>
        public string goodsPr = "";

        /// <summary>��]�������i</summary>
        public long suggestPrice;

        /// <summary>�X�����i</summary>
        public long shopPrice;

        /// <summary>���l</summary>
        public long tradePrice;

        /// <summary>�d������</summary>
        public long purchaseCost;

        /// <summary>�������߃t���O</summary>
        public bool recommendFlag;

        /// <summary>���я�</summary>
        public Int32 sortNo;

        /// <summary>���J�t���O</summary>
        public bool releaseFlag;

        /// <summary>PM�X�V����</summary>
        public long pmUpdDtTime;

        // �蓮�ǉ���

        /// <summary>�摜ID</summary>
        public Image image_Data;

        /// <summary>�t���������X�g</summary>
        public AttendRepair[] attendRepairList;

        /// <summary>���i�^�O���X�g</summary>
        public GoodsTag[] goodsTagList;

        /// <summary>�ʐݒ�</summary>
        public ProposeDistGoodsSetting[] proposeDistGoodsSetting;


        /// <summary>���J�J�n��</summary>
        public string shopSaleBeginDate = "";

        /// <summary>���J�I����</summary>
        public string shopSaleEndDate = "";


        /// <summary>
        /// ��ď��i�N���X�R���X�g���N�^
        /// </summary>
        /// <returns>ProposeGoods�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ProposeGoods�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ProposeGoods()
        {
        }

        /// <summary>
        /// ��ď��i�N���X�R���X�g���N�^
        /// </summary>
        /// <param name="uuid">UUID</param>
        /// <param name="insDtTime">�쐬����</param>
        /// <param name="updDtTime">�X�V����</param>
        /// <param name="insAccountId">�쐬�A�J�E���gID</param>
        /// <param name="updAccountId">�X�V�A�J�E���gID</param>
        /// <param name="logicalDelDiv">�_���폜�敪</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="sectionName">���_����</param>
        /// <param name="proposeGoodsId">��ď��iID</param>
        /// <param name="proposeGoodsName">��ď��i����</param>
        /// <param name="goodsCategoryId">���i�J�e�S���[ID</param>
        /// <param name="blCode">BL�R�[�h</param>
        /// <param name="blCodeBranche">BL�R�[�h�}��</param>
        /// <param name="partsNumber">�i��</param>
        /// <param name="pmMakerCode">PM���[�J�[�R�[�h</param>
        /// <param name="makerName">���[�J�[����</param>
        /// <param name="imageId">�摜ID</param>
        /// <param name="releaseDate">������</param>
        /// <param name="stockState">�݌ɏ��</param>
        /// <param name="goodsNote">���i����</param>
        /// <param name="goodsPr">���iPR</param>
        /// <param name="suggestPrice">��]�������i</param>
        /// <param name="shopPrice">�X�����i</param>
        /// <param name="tradePrice">���l</param>
        /// <param name="purchaseCost">�d������</param>
        /// <param name="recommendFlag">�������߃t���O</param>
        /// <param name="sortNo">���я�</param>
        /// <param name="releaseFlag">���J�t���O</param>
        /// <param name="pmUpdDtTime">PM�X�V����</param>
        /// 
        /// <returns>ProposeGoods�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ProposeGoods�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ProposeGoods(string uuid, long insDtTime, long updDtTime, Int32 insAccountId, Int32 updAccountId, Int32 logicalDelDiv, string enterpriseCode, string enterpriseName, string sectionCode, string sectionName, 
            long proposeGoodsId, string proposeGoodsName, long goodsCategoryId, Int32 blCode, Int32 blCodeBranche, string partsNumber, Int32 pmMakerCode, string makerName, long imageId, string releaseDate, 
            Int32 stockState, string goodsNote, string goodsPr, long suggestPrice, 
            long shopPrice, long tradePrice, long purchaseCost, bool recommendFlag, 
            Int32 sortNo, bool releaseFlag, long pmUpdDtTime, Image image_Data,
            string shopSaleBeginDate, string shopSaleEndDate,
            AttendRepair[] attendRepairList, GoodsTag[] goodsTagList, ProposeDistGoodsSetting[] proposeDistGoodsSetting)
        {
            this.uuid = uuid;
            this.insDtTime = insDtTime;
            this.updDtTime = updDtTime;
            this.insAccountId = insAccountId;
            this.updAccountId = updAccountId;
            this.logicalDelDiv = logicalDelDiv;
            this.enterpriseCode = enterpriseCode;
            this.enterpriseName = enterpriseName;
            this.sectionCode = sectionCode;
            this.sectionName = sectionName;
            this.proposeGoodsId = proposeGoodsId;
            this.proposeGoodsName = proposeGoodsName;
            this.goodsCategoryId = goodsCategoryId;
            this.blCode = blCode;
            this.blCodeBranche = blCodeBranche;
            this.partsNumber = partsNumber;
            this.pmMakerCode = pmMakerCode;
            this.makerName = makerName;
            this.imageId = imageId;
            this.releaseDate = releaseDate;
            this.stockState = stockState;
            this.goodsNote = goodsNote;
            this.goodsPr = goodsPr;
            this.suggestPrice = suggestPrice;
            this.shopPrice = shopPrice;
            this.tradePrice = tradePrice;
            this.purchaseCost = purchaseCost;
            this.recommendFlag = recommendFlag;
            this.sortNo = sortNo;
            this.releaseFlag = releaseFlag;
            this.pmUpdDtTime = pmUpdDtTime;
            this.shopSaleBeginDate = shopSaleBeginDate;
            this.shopSaleEndDate = shopSaleEndDate;
            this.image_Data = image_Data;
            this.attendRepairList = attendRepairList;
            this.goodsTagList = goodsTagList;
            this.proposeDistGoodsSetting = proposeDistGoodsSetting;
        }

        /// <summary>
        /// ��ď��i�N���X��������
        /// </summary>
        /// <returns>ProposeGoods�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ProposeGoods�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ProposeGoods Clone()
        {
            return new ProposeGoods(this.uuid, this.insDtTime, this.updDtTime, this.insAccountId, this.updAccountId, this.logicalDelDiv, this.enterpriseCode, this.enterpriseName, this.sectionCode, this.sectionName, this.proposeGoodsId, this.proposeGoodsName, this.goodsCategoryId, this.blCode, this.blCodeBranche, this.partsNumber, this.pmMakerCode, this.makerName, this.imageId, this.releaseDate, this.stockState, this.goodsNote, this.goodsPr, this.suggestPrice, this.shopPrice, this.tradePrice, this.purchaseCost, this.recommendFlag, this.sortNo, this.releaseFlag, this.pmUpdDtTime,
                this.image_Data, this.shopSaleBeginDate, this.shopSaleEndDate, this.attendRepairList, this.goodsTagList, this.proposeDistGoodsSetting);
        }


        /// <summary>
        /// ��ď��i�N���X��r����
        /// </summary>
        /// <param name="proposeGoods1">
        ///                    ��r����ProposeGoods�N���X�̃C���X�^���X
        /// </param>
        /// <param name="proposeGoods2">��r����ProposeGoods�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ProposeGoods�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(ProposeGoods proposeGoods1, ProposeGoods proposeGoods2)
        {
            // �摜�A�z�񃁃��o�[�͑ΏۊO�Ȃ̂Œ���

            return ((proposeGoods1.uuid == proposeGoods2.uuid)
                 && (proposeGoods1.insDtTime == proposeGoods2.insDtTime)
                 && (proposeGoods1.updDtTime == proposeGoods2.updDtTime)
                 && (proposeGoods1.insAccountId == proposeGoods2.insAccountId)
                 && (proposeGoods1.updAccountId == proposeGoods2.updAccountId)
                 && (proposeGoods1.logicalDelDiv == proposeGoods2.logicalDelDiv)
                 && (proposeGoods1.enterpriseCode == proposeGoods2.enterpriseCode)
                 && (proposeGoods1.enterpriseName == proposeGoods2.enterpriseName)
                 && (proposeGoods1.sectionCode == proposeGoods2.sectionCode)
                 && (proposeGoods1.sectionName == proposeGoods2.sectionName)
                 && (proposeGoods1.proposeGoodsId == proposeGoods2.proposeGoodsId)
                 && (proposeGoods1.proposeGoodsName == proposeGoods2.proposeGoodsName)
                 && (proposeGoods1.goodsCategoryId == proposeGoods2.goodsCategoryId)
                 && (proposeGoods1.blCode == proposeGoods2.blCode)
                 && (proposeGoods1.blCodeBranche == proposeGoods2.blCodeBranche)
                 && (proposeGoods1.partsNumber == proposeGoods2.partsNumber)
                 && (proposeGoods1.pmMakerCode == proposeGoods2.pmMakerCode)
                 && (proposeGoods1.makerName == proposeGoods2.makerName)
                 && (proposeGoods1.imageId == proposeGoods2.imageId)
                 && (proposeGoods1.releaseDate == proposeGoods2.releaseDate)
                 && (proposeGoods1.stockState == proposeGoods2.stockState)
                 && (proposeGoods1.goodsNote == proposeGoods2.goodsNote)
                 && (proposeGoods1.goodsPr == proposeGoods2.goodsPr)
                 && (proposeGoods1.suggestPrice == proposeGoods2.suggestPrice)
                 && (proposeGoods1.shopPrice == proposeGoods2.shopPrice)
                 && (proposeGoods1.tradePrice == proposeGoods2.tradePrice)
                 && (proposeGoods1.purchaseCost == proposeGoods2.purchaseCost)
                 && (proposeGoods1.recommendFlag == proposeGoods2.recommendFlag)
                 && (proposeGoods1.sortNo == proposeGoods2.sortNo)
                 && (proposeGoods1.releaseFlag == proposeGoods2.releaseFlag)
                 && (proposeGoods1.shopSaleBeginDate == proposeGoods2.shopSaleBeginDate)
                 && (proposeGoods1.shopSaleEndDate == proposeGoods2.shopSaleEndDate)
                 && (proposeGoods1.pmUpdDtTime == proposeGoods2.pmUpdDtTime));
        }
    }


    /// <summary>
    /// �t������
    /// </summary>
    public class AttendRepair
    {
        /// <summary>UUID</summary>
        public string uuid;

        /// <summary>�쐬��</summary>
        public long insDtTime;

        /// <summary>�X�V��</summary>
        public long updDtTime;

        /// <summary>�A�J�E���gID</summary>
        public int insAccountId;

        /// <summary>�X�V�A�J�E���gID</summary>
        public int updAccountId;

        /// <summary>�_���폜�敪</summary>
        public int logicalDelDiv;

        /// <summary>��ƃR�[�h</summary>
        public string enterpriseCode;

        /// <summary>���_�R�[�h</summary>
        public string sectionCode;
       
        /// <summary>��ĕt������ID �T���Q�[�g�L�[</summary>
        public long proposeAttendRepairId;

        /// <summary>�t������ID</summary>
        public long attendRepairId;

        /// <summary>�t����������</summary>
        public string repairName;

        /// <summary>�t���������z</summary>
        public long repairPrice;

        /// <summary>��ď��iID</summary>
        public long proposeGoodsId;

        /// <summary>�\����</summary>
        public int sortNo;

        /// <summary>�f�[�^�^�C�v(�����A���i�H)</summary>
        public int dataType;

        /// <summary>���z�^�C�v(�P���A���z�H)</summary>
        public int priceType;

        /// <summary>
        /// �t�������R���X�g���N�^
        /// </summary>
        public AttendRepair()
        {

        }

        /// <summary>
        /// �t�������R���X�g���N�^
        /// </summary>
        /// <param name="uuid"></param>
        /// <param name="insDtTime"></param>
        /// <param name="updDtTime"></param>
        /// <param name="insAccountId"></param>
        /// <param name="updAccountId"></param>
        /// <param name="logicalDelDiv"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <param name="proposeAttendRepairId"></param>
        /// <param name="attendRepairId"></param>
        /// <param name="repairName"></param>
        /// <param name="repairPrice"></param>
        /// <param name="proposeGoodsId"></param>
        /// <param name="sortNo"></param>
        /// <param name="dataType"></param>
        /// <param name="priceType"></param>
        public AttendRepair(string uuid, long insDtTime, long updDtTime, int insAccountId, int updAccountId, int logicalDelDiv, string enterpriseCode, string sectionCode,
                            long proposeAttendRepairId, long attendRepairId, string repairName, long repairPrice, long proposeGoodsId, int sortNo, int dataType, int priceType)
        {
            this.uuid = uuid;
            this.insDtTime = insDtTime;
            this.updDtTime = updDtTime;
            this.insAccountId = insAccountId;
            this.updAccountId = updAccountId;
            this.logicalDelDiv = logicalDelDiv;
            this.enterpriseCode = enterpriseCode;
            this.sectionCode = sectionCode;
            this.proposeAttendRepairId = proposeAttendRepairId;
            this.attendRepairId = attendRepairId;
            this.repairName = repairName;
            this.repairPrice = repairPrice;
            this.proposeGoodsId = proposeGoodsId;
            this.sortNo = sortNo;
            this.dataType = dataType;
            this.priceType = priceType;
        }

        /// <summary>
        /// �t��������������
        /// </summary>
        /// <returns>GoodsTag�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����GoodsTag�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public AttendRepair Clone()
        {
            return new AttendRepair(this.uuid, this.insDtTime, this.updDtTime, this.insAccountId, this.updAccountId, this.logicalDelDiv, this.enterpriseCode, this.sectionCode,
                       this.proposeAttendRepairId, this.attendRepairId, this.repairName, this.repairPrice, this.proposeGoodsId, this.sortNo, this.dataType, this.priceType);
        }
    }

    /// <summary>
    /// ���i�^�O
    /// </summary>
    public class GoodsTag
    {
        /// <summary>UUID</summary>
        public string uuid;

        /// <summary>�쐬��</summary>
        public long insDtTime;

        /// <summary>�X�V��</summary>
        public long updDtTime;

        /// <summary>�A�J�E���gID</summary>
        public int insAccountId;

        /// <summary>�X�V�A�J�E���gID</summary>
        public int updAccountId;

        /// <summary>�_���폜�敪</summary>
        public int logicalDelDiv;

        /// <summary>��ƃR�[�h</summary>
        public string enterpriseCode;

        /// <summary>���_�R�[�h</summary>
        public string sectionCode;

        /// <summary>��ď��iID</summary>
        public long proposeGoodsId;

        /// <summary>���i�^�OID�i�T���Q�[�g�j</summary>
        public long goodsTagId;

        /// <summary>���i�^�O</summary>
        public string tag;

        /// <summary>���i�^�O�ԍ��i1�`10�j</summary>
        public int tagNo;


        /// <summary>
        /// ���i�^�O�N���X�R���X�g���N�^
        /// </summary>
        public GoodsTag()
        {

        }

        /// <summary>
        /// ���i�^�O�N���X�R���X�g���N�^
        /// </summary>
        public GoodsTag(string uuid, long insDtTime, long updDtTime, int insAccountId, int updAccountId, int logicalDelDiv, string enterpriseCode, string sectionCode, long proposeGoodsId, long goodsTagId, string tag, int tagNo)
        {
            this.uuid = uuid;
            this.insDtTime = insDtTime;
            this.updDtTime = updDtTime;
            this.insAccountId = insAccountId;
            this.updAccountId = updAccountId;
            this.logicalDelDiv = logicalDelDiv;
            this.enterpriseCode = enterpriseCode;
            this.sectionCode = sectionCode;
            this.proposeGoodsId = proposeGoodsId;
            this.goodsTagId = goodsTagId;
            this.tag = tag;
            this.tagNo = tagNo;
        }

        /// <summary>
        /// ���i�^�O��������
        /// </summary>
        /// <returns>ProposeGoods�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ProposeGoods�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsTag Clone()
        {
            return new GoodsTag(this.uuid, this.insDtTime, this.updDtTime, this.insAccountId, this.updAccountId, this.logicalDelDiv, this.enterpriseCode, this.sectionCode, this.proposeGoodsId, this.goodsTagId, this.tag, this.tagNo);
        }
    }

    /// <summary>
    /// �ʐݒ� 
    /// </summary>
    public class ProposeDistGoodsSetting
    {
        /// <summary>��ƃR�[�h</summary>
        public string enterpriseCode;

        /// <summary>���_�R�[�h</summary>
        public string sectionCode;

        /// <summary>�A�J�E���gID</summary>
        public int insAccountId;

        /// <summary>�X�V�A�J�E���gID</summary>
        public int updAccountId;

        /// <summary>�쐬��</summary>
        public long insDtTime;

        /// <summary>�X�V��</summary>
        public long updDtTime;

        /// <summary>�_���폜�敪</summary>
        public int logicalDelDiv;

        /// <summary>��ď��iID</summary>
        public long proposeGoodsId;

        /// <summary>�ʐݒ��ƃR�[�h</summary>
        public string proposeDistEnterpriseCode;

        /// <summary>�ʐݒ苒�_�R�[�h</summary>
        public string proposeDistSectionCode;

        /// <summary>�ʐݒ�ID(�T���Q�[�g�L�[)</summary>
        public long proposeDistGoodsSettingId;

        /// <summary>��]�������i</summary>
        public long suggestPrice;

        /// <summary>�X�����i</summary>
        public long shopPrice;

        /// <summary>���l</summary>
        public long tradePrice;

        /// <summary>�d������</summary>
        public Double purchaseCost;

        /// <summary>UUID</summary>
        public string uuid;
    }

    /// <summary>
    /// �V����� 
    /// </summary>
    public class News
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        public string enterpriseCode = "";

        /// <summary>��Ɩ���</summary>
        public string enterpriseName = "";

        /// <summary>���_�R�[�h</summary>
        public string sectionCode = "";

        /// <summary>���_����</summary>
        public string sectionName = "";

        /// <summary>���i�J�e�S���[ID</summary>
        public long goodsCategoryId;

        /// <summary>�^�C�g��</summary>
        public string newsTitle;

        /// <summary>�{��</summary>
        public string newsContent;

        /// <summary>��ē���</summary>
        public string proposeDate;

        /// <summary>��Đ��񃊃X�g</summary>
        public ProposeStore[] proposeStoreList;
    }
 
    /// <summary>
    /// ��Đ���
    /// </summary>
    public class ProposeStore
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        public string enterpriseCode = "";

        /// <summary>��Ɩ���</summary>
        public string enterpriseName = "";

        /// <summary>���_�R�[�h</summary>
        public string sectionCode = "";

        /// <summary>���_����</summary>
        public string sectionName = "";

    }

    /// <summary>
    /// ��Đ���
    /// </summary>
    public class DestSetting_MAIN
    {
        public DestSetting[] destSettings;
    }

    /// <summary>
    /// ��Đ���
    /// </summary>
    public class DestSetting
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        public string enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        public string sectionCode;

        /// <summary>�A�J�E���gID</summary>
        public int insAccountId;

        /// <summary>�X�V�A�J�E���gID</summary>
        public int updAccountId;

        /// <summary>�쐬��</summary>
        public long insDtTime;

        /// <summary>�X�V��</summary>
        public long updDtTime;

        /// <summary>�_���폜�敪</summary>
        public int logicalDelDiv;

        /// <summary>���J���ID</summary>
        public long proposeDestId;

        /// <summary>���J���ƃR�[�h</summary>
        public string proposeDestEnterpriseCode = "";

        /// <summary>���J���Ɩ���</summary>
        public string proposeDestEnterpriseName = "";

        /// <summary>���J�拒�_�R�[�h</summary>
        public string proposeDestSectionCode;

        /// <summary>���J�拒�_����</summary>
        public string proposeDestSectionName = "";

        /// <summary>���i�J�e�S���[ID</summary>
        public long goodsCategoryId;

    }
}
