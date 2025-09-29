using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ���i�A���f�[�^�R���o�[�^�[
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���i�֘A�̃f�[�^�R���o�[�g���s���܂��B</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2007.01.24</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2007.08.30</br>
    /// <br>           :�EDC.NS�Ή�</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2008.06.18 20056 ���n ���</br>
    /// <br>           : PM.NS�Ή�(�R�����g����)</br>
    /// </remarks>
	class GoosUnitConverer
	{
		private static GoodsAcs mGoodsAcs = new GoodsAcs();
		private static string mEnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

		/// <summary>
		/// ���i�A���f�[�^���珤�i�f�[�^�擾
		/// </summary>
		/// <param name="goodsUnitData">���i�A���f�[�^</param>
		/// <returns>Goods</returns>
		public static ArrayList ConvertFromGoosUnit(GoodsUnitData goodsUnitData)
		{
			ArrayList dataList = new ArrayList();
			ArrayList goodsList = new ArrayList();

            // ���i�N���X�擾
            goodsList.Add(GoosUnitConverer.GoodsFromGoosUnit(goodsUnitData));

			// ���i�N���X�ǉ�
			if (goodsList.Count > 0)
				dataList.Add(goodsList);

			return dataList; 
		}

		/// <summary>
		/// ���i�A���f�[�^���珤�i�֘A�f�[�^���X�g�擾
		/// </summary>
		/// <param name="goodsUnitDataList">���i�A���f�[�^���X�g</param>
		/// <returns>���i�֘A�f�[�^���X�g</returns>
		public static ArrayList ConvertFromGoosUnit(List<GoodsUnitData> goodsUnitDataList)
		{
			ArrayList dataList = new ArrayList();
			ArrayList goodsList = new ArrayList();

			foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
			{
                // ���i�N���X�擾
                goodsList.Add(GoosUnitConverer.GoodsFromGoosUnit(goodsUnitData));
			}

			// ���i�N���X�ǉ�
			if (goodsList.Count > 0)
				dataList.Add(goodsList);

			return dataList;
		}

        /// <summary>
        /// ���i�A���f�[�^�쐬����
        /// </summary>
        /// <param name="goods">���i�f�[�^�N���X</param>
        /// <returns></returns>
        public static GoodsUnitData MakeGoodsUnitData(Goods goods)
		{
			// ���i�f�[�^���Ȃ��ꍇ�͘A���f�[�^�����Ȃ���Null��Ԃ�
			if (goods == null) return null;

			// ���i���ʃf�[�^�̏��i����ݒ肷��
			GoodsUnitData goodsUnitData = MakeCommonGoodsUnit(goods);

			return goodsUnitData; 
		}

		/// <summary>
		/// ���i�A���f�[�^���珤�i�f�[�^�擾
		/// </summary>
		/// <param name="goodsUnitData">���i�A���f�[�^</param>
		/// <returns>Goods</returns>
		public static Goods GoodsFromGoosUnit(GoodsUnitData goodsUnitData)
		{
			Goods goods = new Goods();

			if (goodsUnitData != null)
			{
                goods.CreateDateTime = goodsUnitData.CreateDateTime; // �쐬����
                goods.UpdateDateTime = goodsUnitData.UpdateDateTime; // �X�V����
                goods.EnterpriseCode = goodsUnitData.EnterpriseCode; // ��ƃR�[�h
                goods.FileHeaderGuid = goodsUnitData.FileHeaderGuid; // GUID
                goods.UpdEmployeeCode = goodsUnitData.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
                goods.UpdAssemblyId1 = goodsUnitData.UpdAssemblyId1; // �X�V�A�Z���u��ID1
                goods.UpdAssemblyId2 = goodsUnitData.UpdAssemblyId2; // �X�V�A�Z���u��ID2
                goods.LogicalDeleteCode = goodsUnitData.LogicalDeleteCode; // �_���폜�敪
                goods.GoodsMakerCd = goodsUnitData.GoodsMakerCd; // ���i���[�J�[�R�[�h
                goods.GoodsNo = goodsUnitData.GoodsNo; // ���i�ԍ�
                goods.GoodsName = goodsUnitData.GoodsName; // ���i����
                goods.GoodsNameKana = goodsUnitData.GoodsNameKana; // ���i���̃J�i
                goods.Jan = goodsUnitData.Jan; // JAN�R�[�h
                goods.BLGoodsCode = goodsUnitData.BLGoodsCode; // BL���i�R�[�h
                goods.DisplayOrder = goodsUnitData.DisplayOrder; // �\������
                goods.GoodsRateRank = goodsUnitData.GoodsRateRank; // ���i�|�������N
                goods.TaxationDivCd = goodsUnitData.TaxationDivCd; // �ېŋ敪
                goods.GoodsNoNoneHyphen = goodsUnitData.GoodsNoNoneHyphen; // �n�C�t�������i�ԍ�
                goods.OfferDate = goodsUnitData.OfferDate; // �񋟓��t
                goods.GoodsKindCode = goodsUnitData.GoodsKindCode; // ���i����
                goods.GoodsNote1 = goodsUnitData.GoodsNote1; // ���i���l�P
                goods.GoodsNote2 = goodsUnitData.GoodsNote2; // ���i���l�Q
                goods.GoodsSpecialNote = goodsUnitData.GoodsSpecialNote; // ���i�K�i�E���L����
                goods.EnterpriseGanreCode = goodsUnitData.EnterpriseGanreCode; // ���Е��ރR�[�h
                goods.UpdateDate = goodsUnitData.UpdateDate; // �X�V�N����
			}

			return goods;
		}

		/// <summary>
		/// ���i�A���f�[�^���ʏ��i�f�[�^�ݒ�
		/// </summary>
		/// <param name="goods">���i�f�[�^</param>
		/// <returns>���i�A���f�[�^</returns>
		private static GoodsUnitData MakeCommonGoodsUnit(Goods goods)
		{
			GoodsUnitData goodsUnitData = new GoodsUnitData();

            goodsUnitData.CreateDateTime = goods.CreateDateTime; // �쐬����
            goodsUnitData.UpdateDateTime = goods.UpdateDateTime; // �X�V����
            goodsUnitData.EnterpriseCode = goods.EnterpriseCode; // ��ƃR�[�h
            goodsUnitData.FileHeaderGuid = goods.FileHeaderGuid; // GUID
            goodsUnitData.UpdEmployeeCode = goods.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            goodsUnitData.UpdAssemblyId1 = goods.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            goodsUnitData.UpdAssemblyId2 = goods.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            goodsUnitData.LogicalDeleteCode = goods.LogicalDeleteCode; // �_���폜�敪
            goodsUnitData.GoodsMakerCd = goods.GoodsMakerCd; // ���i���[�J�[�R�[�h
            goodsUnitData.GoodsNo = goods.GoodsNo; // ���i�ԍ�
            goodsUnitData.GoodsName = goods.GoodsName; // ���i����
            goodsUnitData.GoodsNameKana = goods.GoodsNameKana; // ���i���̃J�i
            goodsUnitData.Jan = goods.Jan; // JAN�R�[�h
            goodsUnitData.BLGoodsCode = goods.BLGoodsCode; // BL���i�R�[�h
            goodsUnitData.DisplayOrder = goods.DisplayOrder; // �\������
            goodsUnitData.GoodsRateRank = goods.GoodsRateRank; // ���i�|�������N
            goodsUnitData.TaxationDivCd = goods.TaxationDivCd; // �ېŋ敪
            goodsUnitData.GoodsNoNoneHyphen = goods.GoodsNoNoneHyphen; // �n�C�t�������i�ԍ�
            goodsUnitData.OfferDate = goods.OfferDate; // �񋟓��t
            goodsUnitData.GoodsKindCode = goods.GoodsKindCode; // ���i����
            goodsUnitData.GoodsNote1 = goods.GoodsNote1; // ���i���l�P
            goodsUnitData.GoodsNote2 = goods.GoodsNote2; // ���i���l�Q
            goodsUnitData.GoodsSpecialNote = goods.GoodsSpecialNote; // ���i�K�i�E���L����
            goodsUnitData.EnterpriseGanreCode = goods.EnterpriseGanreCode; // ���Е��ރR�[�h
            goodsUnitData.UpdateDate = goods.UpdateDate; // �X�V�N����

			return goodsUnitData;
		}
    }
}
