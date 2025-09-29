//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �d�����׃e�[�u���X�L�[�}�N���X
// �v���O�����T�v   : �d�����׃e�[�u����`���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2008/05/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// �d�����׃e�[�u���X�L�[�}�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �d�����ג��o���ʃe�[�u���X�L�[�}</br>
	/// <br>Programmer : 96186�@���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// </remarks>
	public class StockDetailSchema
	{
		#region Public Members
		/// <summary>�d�����׃e�[�u����</summary>
        public const string CT_SendStockDetailDataTable = "SendStockDetailDataTable";

		#region �J�����������
		public const double defValueDouble = 0;
		public const Int64 defValueInt64 = 0;
		public const Int32 defValueInt32 = 0;
		public const string defValuestring = "";
        public const bool defValueBoolean = true;
		#endregion

		#region �J�������
        /// <summary> �쐬���� </summary>
        public const string ct_Col_CreateDateTime = "CreateDateTime";
        /// <summary> �X�V���� </summary>
        public const string ct_Col_UpdateDateTime = "UpdateDateTime";
        /// <summary> ��ƃR�[�h </summary>
        public const string ct_Col_EnterpriseCode = "EnterpriseCode";
        /// <summary> GUID </summary>
        public const string ct_Col_FileHeaderGuid = "FileHeaderGuid";
        /// <summary> �X�V�]�ƈ��R�[�h </summary>
        public const string ct_Col_UpdEmployeeCode = "UpdEmployeeCode";
        /// <summary> �X�V�A�Z���u��ID1 </summary>
        public const string ct_Col_UpdAssemblyId1 = "UpdAssemblyId1";
        /// <summary> �X�V�A�Z���u��ID2 </summary>
        public const string ct_Col_UpdAssemblyId2 = "UpdAssemblyId2";
        /// <summary> �_���폜�敪 </summary>
        public const string ct_Col_LogicalDeleteCode = "LogicalDeleteCode";
        /// <summary> �󒍔ԍ� </summary>
        public const string ct_Col_AcceptAnOrderNo = "AcceptAnOrderNo";
        /// <summary> �d���`�� </summary>
        public const string ct_Col_SupplierFormal = "SupplierFormal";
        /// <summary> �d���`�[�ԍ� </summary>
        public const string ct_Col_SupplierSlipNo = "SupplierSlipNo";
        /// <summary> �d���s�ԍ� </summary>
        public const string ct_Col_StockRowNo = "StockRowNo";
        /// <summary> ���_�R�[�h </summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary> ����R�[�h </summary>
        public const string ct_Col_SubSectionCode = "SubSectionCode";
        /// <summary> ���ʒʔ� </summary>
        public const string ct_Col_CommonSeqNo = "CommonSeqNo";
        /// <summary> �d�����גʔ� </summary>
        public const string ct_Col_StockSlipDtlNum = "StockSlipDtlNum";
        /// <summary> �d���`���i���j </summary>
        public const string ct_Col_SupplierFormalSrc = "SupplierFormalSrc";
        /// <summary> �d�����גʔԁi���j </summary>
        public const string ct_Col_StockSlipDtlNumSrc = "StockSlipDtlNumSrc";
        /// <summary> �󒍃X�e�[�^�X�i�����j </summary>
        public const string ct_Col_AcptAnOdrStatusSync = "AcptAnOdrStatusSync";
        /// <summary> ���㖾�גʔԁi�����j </summary>
        public const string ct_Col_SalesSlipDtlNumSync = "SalesSlipDtlNumSync";
        /// <summary> �d���`�[�敪�i���ׁj </summary>
        public const string ct_Col_StockSlipCdDtl = "StockSlipCdDtl";
        /// <summary> �d�����͎҃R�[�h </summary>
        public const string ct_Col_StockInputCode = "StockInputCode";
        /// <summary> �d�����͎Җ��� </summary>
        public const string ct_Col_StockInputName = "StockInputName";
        /// <summary> �d���S���҃R�[�h </summary>
        public const string ct_Col_StockAgentCode = "StockAgentCode";
        /// <summary> �d���S���Җ��� </summary>
        public const string ct_Col_StockAgentName = "StockAgentName";
        /// <summary> ���i���� </summary>
        public const string ct_Col_GoodsKindCode = "GoodsKindCode";
        /// <summary> ���i���[�J�[�R�[�h </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> ���[�J�[���� </summary>
        public const string ct_Col_MakerName = "MakerName";
        /// <summary> ���[�J�[�J�i���� </summary>
        public const string ct_Col_MakerKanaName = "MakerKanaName";
        /// <summary> ���[�J�[�J�i���́i�ꎮ�j </summary>
        public const string ct_Col_CmpltMakerKanaName = "CmpltMakerKanaName";
        /// <summary> ���i�ԍ� </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> ���i���� </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> ���i���̃J�i </summary>
        public const string ct_Col_GoodsNameKana = "GoodsNameKana";
        /// <summary> ���i�啪�ރR�[�h </summary>
        public const string ct_Col_GoodsLGroup = "GoodsLGroup";
        /// <summary> ���i�啪�ޖ��� </summary>
        public const string ct_Col_GoodsLGroupName = "GoodsLGroupName";
        /// <summary> ���i�����ރR�[�h </summary>
        public const string ct_Col_GoodsMGroup = "GoodsMGroup";
        /// <summary> ���i�����ޖ��� </summary>
        public const string ct_Col_GoodsMGroupName = "GoodsMGroupName";
        /// <summary> BL�O���[�v�R�[�h </summary>
        public const string ct_Col_BLGroupCode = "BLGroupCode";
        /// <summary> BL�O���[�v�R�[�h���� </summary>
        public const string ct_Col_BLGroupName = "BLGroupName";
        /// <summary> BL���i�R�[�h </summary>
        public const string ct_Col_BLGoodsCode = "BLGoodsCode";
        /// <summary> BL���i�R�[�h���́i�S�p�j </summary>
        public const string ct_Col_BLGoodsFullName = "BLGoodsFullName";
        /// <summary> ���Е��ރR�[�h </summary>
        public const string ct_Col_EnterpriseGanreCode = "EnterpriseGanreCode";
        /// <summary> ���Е��ޖ��� </summary>
        public const string ct_Col_EnterpriseGanreName = "EnterpriseGanreName";
        /// <summary> �q�ɃR�[�h </summary>
        public const string ct_Col_WarehouseCode = "WarehouseCode";
        /// <summary> �q�ɖ��� </summary>
        public const string ct_Col_WarehouseName = "WarehouseName";
        /// <summary> �q�ɒI�� </summary>
        public const string ct_Col_WarehouseShelfNo = "WarehouseShelfNo";
        /// <summary> �d���݌Ɏ�񂹋敪 </summary>
        public const string ct_Col_StockOrderDivCd = "StockOrderDivCd";
        /// <summary> �I�[�v�����i�敪 </summary>
        public const string ct_Col_OpenPriceDiv = "OpenPriceDiv";
        /// <summary> ���i�|�������N </summary>
        public const string ct_Col_GoodsRateRank = "GoodsRateRank";
        /// <summary> ���Ӑ�|���O���[�v�R�[�h </summary>
        public const string ct_Col_CustRateGrpCode = "CustRateGrpCode";
        /// <summary> �d����|���O���[�v�R�[�h </summary>
        public const string ct_Col_SuppRateGrpCode = "SuppRateGrpCode";
        /// <summary> �艿�i�Ŕ��C�����j </summary>
        public const string ct_Col_ListPriceTaxExcFl = "ListPriceTaxExcFl";
        /// <summary> �艿�i�ō��C�����j </summary>
        public const string ct_Col_ListPriceTaxIncFl = "ListPriceTaxIncFl";
        /// <summary> �d���� </summary>
        public const string ct_Col_StockRate = "StockRate";
        /// <summary> �|���ݒ苒�_�i�d���P���j </summary>
        public const string ct_Col_RateSectStckUnPrc = "RateSectStckUnPrc";
        /// <summary> �|���ݒ�敪�i�d���P���j </summary>
        public const string ct_Col_RateDivStckUnPrc = "RateDivStckUnPrc";
        /// <summary> �P���Z�o�敪�i�d���P���j </summary>
        public const string ct_Col_UnPrcCalcCdStckUnPrc = "UnPrcCalcCdStckUnPrc";
        /// <summary> ���i�敪�i�d���P���j </summary>
        public const string ct_Col_PriceCdStckUnPrc = "PriceCdStckUnPrc";
        /// <summary> ��P���i�d���P���j </summary>
        public const string ct_Col_StdUnPrcStckUnPrc = "StdUnPrcStckUnPrc";
        /// <summary> �[�������P�ʁi�d���P���j </summary>
        public const string ct_Col_FracProcUnitStcUnPrc = "FracProcUnitStcUnPrc";
        /// <summary> �[�������i�d���P���j </summary>
        public const string ct_Col_FracProcStckUnPrc = "FracProcStckUnPrc";
        /// <summary> �d���P���i�Ŕ��C�����j </summary>
        public const string ct_Col_StockUnitPriceFl = "StockUnitPriceFl";
        /// <summary> �d���P���i�ō��C�����j </summary>
        public const string ct_Col_StockUnitTaxPriceFl = "StockUnitTaxPriceFl";
        /// <summary> �d���P���ύX�敪 </summary>
        public const string ct_Col_StockUnitChngDiv = "StockUnitChngDiv";
        /// <summary> �ύX�O�d���P���i�����j </summary>
        public const string ct_Col_BfStockUnitPriceFl = "BfStockUnitPriceFl";
        /// <summary> �ύX�O�艿 </summary>
        public const string ct_Col_BfListPrice = "BfListPrice";
        /// <summary> BL���i�R�[�h�i�|���j </summary>
        public const string ct_Col_RateBLGoodsCode = "RateBLGoodsCode";
        /// <summary> BL���i�R�[�h���́i�|���j </summary>
        public const string ct_Col_RateBLGoodsName = "RateBLGoodsName";
        /// <summary> ���i�|���O���[�v�R�[�h�i�|���j </summary>
        public const string ct_Col_RateGoodsRateGrpCd = "RateGoodsRateGrpCd";
        /// <summary> ���i�|���O���[�v���́i�|���j </summary>
        public const string ct_Col_RateGoodsRateGrpNm = "RateGoodsRateGrpNm";
        /// <summary> BL�O���[�v�R�[�h�i�|���j </summary>
        public const string ct_Col_RateBLGroupCode = "RateBLGroupCode";
        /// <summary> BL�O���[�v���́i�|���j </summary>
        public const string ct_Col_RateBLGroupName = "RateBLGroupName";
        /// <summary> �d���� </summary>
        public const string ct_Col_StockCount = "StockCount";
        /// <summary> �������� </summary>
        public const string ct_Col_OrderCnt = "OrderCnt";
        /// <summary> ���������� </summary>
        public const string ct_Col_OrderAdjustCnt = "OrderAdjustCnt";
        /// <summary> �����c�� </summary>
        public const string ct_Col_OrderRemainCnt = "OrderRemainCnt";
        /// <summary> �c���X�V�� </summary>
        public const string ct_Col_RemainCntUpdDate = "RemainCntUpdDate";
        /// <summary> �d�����z�i�Ŕ����j </summary>
        public const string ct_Col_StockPriceTaxExc = "StockPriceTaxExc";
        /// <summary> �d�����z�i�ō��݁j </summary>
        public const string ct_Col_StockPriceTaxInc = "StockPriceTaxInc";
        /// <summary> �d�����i�敪 </summary>
        public const string ct_Col_StockGoodsCd = "StockGoodsCd";
        /// <summary> �d�����z����Ŋz </summary>
        public const string ct_Col_StockPriceConsTax = "StockPriceConsTax";
        /// <summary> �ېŋ敪 </summary>
        public const string ct_Col_TaxationCode = "TaxationCode";
        /// <summary> �d���`�[���ה��l1 </summary>
        public const string ct_Col_StockDtiSlipNote1 = "StockDtiSlipNote1";
        /// <summary> �̔���R�[�h </summary>
        public const string ct_Col_SalesCustomerCode = "SalesCustomerCode";
        /// <summary> �̔��旪�� </summary>
        public const string ct_Col_SalesCustomerSnm = "SalesCustomerSnm";
        /// <summary> �`�[�����P </summary>
        public const string ct_Col_SlipMemo1 = "SlipMemo1";
        /// <summary> �`�[�����Q </summary>
        public const string ct_Col_SlipMemo2 = "SlipMemo2";
        /// <summary> �`�[�����R </summary>
        public const string ct_Col_SlipMemo3 = "SlipMemo3";
        /// <summary> �Г������P </summary>
        public const string ct_Col_InsideMemo1 = "InsideMemo1";
        /// <summary> �Г������Q </summary>
        public const string ct_Col_InsideMemo2 = "InsideMemo2";
        /// <summary> �Г������R </summary>
        public const string ct_Col_InsideMemo3 = "InsideMemo3";
        /// <summary> �d����R�[�h </summary>
        public const string ct_Col_SupplierCd = "SupplierCd";
        /// <summary> �d���旪�� </summary>
        public const string ct_Col_SupplierSnm = "SupplierSnm";
        /// <summary> �[�i��R�[�h </summary>
        public const string ct_Col_AddresseeCode = "AddresseeCode";
        /// <summary> �[�i�於�� </summary>
        public const string ct_Col_AddresseeName = "AddresseeName";
        /// <summary> �����敪 </summary>
        public const string ct_Col_DirectSendingCd = "DirectSendingCd";
        /// <summary> �����ԍ� </summary>
        public const string ct_Col_OrderNumber = "OrderNumber";
        /// <summary> �������@ </summary>
        public const string ct_Col_WayToOrder = "WayToOrder";
        /// <summary> �[�i�����\��� </summary>
        public const string ct_Col_DeliGdsCmpltDueDate = "DeliGdsCmpltDueDate";
        /// <summary> ��]�[�� </summary>
        public const string ct_Col_ExpectDeliveryDate = "ExpectDeliveryDate";
        /// <summary> �����f�[�^�쐬�敪 </summary>
        public const string ct_Col_OrderDataCreateDiv = "OrderDataCreateDiv";
        /// <summary> �����f�[�^�쐬�� </summary>
        public const string ct_Col_OrderDataCreateDate = "OrderDataCreateDate";
        /// <summary> ���������s�ϋ敪 </summary>
        public const string ct_Col_OrderFormIssuedDiv = "OrderFormIssuedDiv";
        /// <summary> �d�������� </summary>
        public const string ct_Col_StockCountDifference = "StockCountDifference";
        /// <summary> ���׊֘A�t��GUID </summary>
        public const string ct_Col_DtlRelationGuid = "DtlRelationGuid";
        #endregion

		#endregion

		#region Constructor
		/// <summary>
		/// �d�����׃e�[�u���X�L�[�}�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �d�����׃e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���܂��B</br>
		/// <br>Programmer : 96186�@���ԗT��</br>
		/// <br>Date       : 2008.05.26</br>
		/// </remarks>
		public StockDetailSchema()
		{
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// �f�[�^�Z�b�g�A�f�[�^�e�[�u���ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 96186 ���ԗT��</br>
		/// <br>Date       : 2006.01.21</br>
		/// </remarks>
        public static void SettingDataSet(ref DataSet ds, string dataTableName)
		{
			// �e�[�u�������݂��邩�ǂ������`�F�b�N
            if ((ds.Tables.Contains(dataTableName)))
			{
				// TODO:�e�[�u�������݂���Ƃ��̓N���A�[����̂�
				// �X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[dataTableName].Clear();
			}
			else
			{
                CreateTable(ref ds, dataTableName);

			}
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// �d�����׍쐬����
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 96186 ���ԗT��</br>
		/// <br>Date       : 2008.05.26</br>
		/// </remarks>
        private static void CreateTable(ref DataSet ds, string dataTableName)
		{
			DataTable dt = null;
			// �X�L�[�}�ݒ�
            ds.Tables.Add(dataTableName);
            dt = ds.Tables[dataTableName];

            // �쐬����
            dt.Columns.Add(ct_Col_CreateDateTime, typeof(DateTime));
            dt.Columns[ct_Col_CreateDateTime].DefaultValue = DateTime.MinValue;
            // �X�V����
            dt.Columns.Add(ct_Col_UpdateDateTime, typeof(DateTime));
            dt.Columns[ct_Col_UpdateDateTime].DefaultValue = DateTime.MinValue;
            // ��ƃR�[�h
            dt.Columns.Add(ct_Col_EnterpriseCode, typeof(string));
            dt.Columns[ct_Col_EnterpriseCode].DefaultValue = defValuestring;
            // GUID
            dt.Columns.Add(ct_Col_FileHeaderGuid, typeof(Guid));
            dt.Columns[ct_Col_FileHeaderGuid].DefaultValue = Guid.Empty;
            // �X�V�]�ƈ��R�[�h
            dt.Columns.Add(ct_Col_UpdEmployeeCode, typeof(string));
            dt.Columns[ct_Col_UpdEmployeeCode].DefaultValue = defValuestring;
            // �X�V�A�Z���u��ID1
            dt.Columns.Add(ct_Col_UpdAssemblyId1, typeof(string));
            dt.Columns[ct_Col_UpdAssemblyId1].DefaultValue = defValuestring;
            // �X�V�A�Z���u��ID2
            dt.Columns.Add(ct_Col_UpdAssemblyId2, typeof(string));
            dt.Columns[ct_Col_UpdAssemblyId2].DefaultValue = defValuestring;
            // �_���폜�敪
            dt.Columns.Add(ct_Col_LogicalDeleteCode, typeof(Int32));
            dt.Columns[ct_Col_LogicalDeleteCode].DefaultValue = defValueInt32;
            // �󒍔ԍ�
            dt.Columns.Add(ct_Col_AcceptAnOrderNo, typeof(Int32));
            dt.Columns[ct_Col_AcceptAnOrderNo].DefaultValue = defValueInt32;
            // �d���`��
            dt.Columns.Add(ct_Col_SupplierFormal, typeof(Int32));
            dt.Columns[ct_Col_SupplierFormal].DefaultValue = defValueInt32;
            // �d���`�[�ԍ�
            dt.Columns.Add(ct_Col_SupplierSlipNo, typeof(Int32));
            dt.Columns[ct_Col_SupplierSlipNo].DefaultValue = defValueInt32;
            // �d���s�ԍ�
            dt.Columns.Add(ct_Col_StockRowNo, typeof(Int32));
            dt.Columns[ct_Col_StockRowNo].DefaultValue = defValueInt32;
            // ���_�R�[�h
            dt.Columns.Add(ct_Col_SectionCode, typeof(string));
            dt.Columns[ct_Col_SectionCode].DefaultValue = defValuestring;
            // ����R�[�h
            dt.Columns.Add(ct_Col_SubSectionCode, typeof(Int32));
            dt.Columns[ct_Col_SubSectionCode].DefaultValue = defValueInt32;
            // ���ʒʔ�
            dt.Columns.Add(ct_Col_CommonSeqNo, typeof(Int64));
            dt.Columns[ct_Col_CommonSeqNo].DefaultValue = defValueInt64;
            // �d�����גʔ�
            dt.Columns.Add(ct_Col_StockSlipDtlNum, typeof(Int64));
            dt.Columns[ct_Col_StockSlipDtlNum].DefaultValue = defValueInt64;
            // �d���`���i���j
            dt.Columns.Add(ct_Col_SupplierFormalSrc, typeof(Int32));
            dt.Columns[ct_Col_SupplierFormalSrc].DefaultValue = defValueInt32;
            // �d�����גʔԁi���j
            dt.Columns.Add(ct_Col_StockSlipDtlNumSrc, typeof(Int64));
            dt.Columns[ct_Col_StockSlipDtlNumSrc].DefaultValue = defValueInt64;
            // �󒍃X�e�[�^�X�i�����j
            dt.Columns.Add(ct_Col_AcptAnOdrStatusSync, typeof(Int32));
            dt.Columns[ct_Col_AcptAnOdrStatusSync].DefaultValue = defValueInt32;
            // ���㖾�גʔԁi�����j
            dt.Columns.Add(ct_Col_SalesSlipDtlNumSync, typeof(Int64));
            dt.Columns[ct_Col_SalesSlipDtlNumSync].DefaultValue = defValueInt64;
            // �d���`�[�敪�i���ׁj
            dt.Columns.Add(ct_Col_StockSlipCdDtl, typeof(Int32));
            dt.Columns[ct_Col_StockSlipCdDtl].DefaultValue = defValueInt32;
            // �d�����͎҃R�[�h
            dt.Columns.Add(ct_Col_StockInputCode, typeof(string));
            dt.Columns[ct_Col_StockInputCode].DefaultValue = defValuestring;
            // �d�����͎Җ���
            dt.Columns.Add(ct_Col_StockInputName, typeof(string));
            dt.Columns[ct_Col_StockInputName].DefaultValue = defValuestring;
            // �d���S���҃R�[�h
            dt.Columns.Add(ct_Col_StockAgentCode, typeof(string));
            dt.Columns[ct_Col_StockAgentCode].DefaultValue = defValuestring;
            // �d���S���Җ���
            dt.Columns.Add(ct_Col_StockAgentName, typeof(string));
            dt.Columns[ct_Col_StockAgentName].DefaultValue = defValuestring;
            // ���i����
            dt.Columns.Add(ct_Col_GoodsKindCode, typeof(Int32));
            dt.Columns[ct_Col_GoodsKindCode].DefaultValue = defValueInt32;
            // ���i���[�J�[�R�[�h
            dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32));
            dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = defValueInt32;
            // ���[�J�[����
            dt.Columns.Add(ct_Col_MakerName, typeof(string));
            dt.Columns[ct_Col_MakerName].DefaultValue = defValuestring;
            // ���[�J�[�J�i����
            dt.Columns.Add(ct_Col_MakerKanaName, typeof(string));
            dt.Columns[ct_Col_MakerKanaName].DefaultValue = defValuestring;
            // ���[�J�[�J�i���́i�ꎮ�j
            dt.Columns.Add(ct_Col_CmpltMakerKanaName, typeof(string));
            dt.Columns[ct_Col_CmpltMakerKanaName].DefaultValue = defValuestring;
            // ���i�ԍ�
            dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
            dt.Columns[ct_Col_GoodsNo].DefaultValue = defValuestring;
            // ���i����
            dt.Columns.Add(ct_Col_GoodsName, typeof(string));
            dt.Columns[ct_Col_GoodsName].DefaultValue = defValuestring;
            // ���i���̃J�i
            dt.Columns.Add(ct_Col_GoodsNameKana, typeof(string));
            dt.Columns[ct_Col_GoodsNameKana].DefaultValue = defValuestring;
            // ���i�啪�ރR�[�h
            dt.Columns.Add(ct_Col_GoodsLGroup, typeof(Int32));
            dt.Columns[ct_Col_GoodsLGroup].DefaultValue = defValueInt32;
            // ���i�啪�ޖ���
            dt.Columns.Add(ct_Col_GoodsLGroupName, typeof(string));
            dt.Columns[ct_Col_GoodsLGroupName].DefaultValue = defValuestring;
            // ���i�����ރR�[�h
            dt.Columns.Add(ct_Col_GoodsMGroup, typeof(Int32));
            dt.Columns[ct_Col_GoodsMGroup].DefaultValue = defValueInt32;
            // ���i�����ޖ���
            dt.Columns.Add(ct_Col_GoodsMGroupName, typeof(string));
            dt.Columns[ct_Col_GoodsMGroupName].DefaultValue = defValuestring;
            // BL�O���[�v�R�[�h
            dt.Columns.Add(ct_Col_BLGroupCode, typeof(Int32));
            dt.Columns[ct_Col_BLGroupCode].DefaultValue = defValueInt32;
            // BL�O���[�v�R�[�h����
            dt.Columns.Add(ct_Col_BLGroupName, typeof(string));
            dt.Columns[ct_Col_BLGroupName].DefaultValue = defValuestring;
            // BL���i�R�[�h
            dt.Columns.Add(ct_Col_BLGoodsCode, typeof(Int32));
            dt.Columns[ct_Col_BLGoodsCode].DefaultValue = defValueInt32;
            // BL���i�R�[�h���́i�S�p�j
            dt.Columns.Add(ct_Col_BLGoodsFullName, typeof(string));
            dt.Columns[ct_Col_BLGoodsFullName].DefaultValue = defValuestring;
            // ���Е��ރR�[�h
            dt.Columns.Add(ct_Col_EnterpriseGanreCode, typeof(Int32));
            dt.Columns[ct_Col_EnterpriseGanreCode].DefaultValue = defValueInt32;
            // ���Е��ޖ���
            dt.Columns.Add(ct_Col_EnterpriseGanreName, typeof(string));
            dt.Columns[ct_Col_EnterpriseGanreName].DefaultValue = defValuestring;
            // �q�ɃR�[�h
            dt.Columns.Add(ct_Col_WarehouseCode, typeof(string));
            dt.Columns[ct_Col_WarehouseCode].DefaultValue = defValuestring;
            // �q�ɖ���
            dt.Columns.Add(ct_Col_WarehouseName, typeof(string));
            dt.Columns[ct_Col_WarehouseName].DefaultValue = defValuestring;
            // �q�ɒI��
            dt.Columns.Add(ct_Col_WarehouseShelfNo, typeof(string));
            dt.Columns[ct_Col_WarehouseShelfNo].DefaultValue = defValuestring;
            // �d���݌Ɏ�񂹋敪
            dt.Columns.Add(ct_Col_StockOrderDivCd, typeof(Int32));
            dt.Columns[ct_Col_StockOrderDivCd].DefaultValue = defValueInt32;
            // �I�[�v�����i�敪
            dt.Columns.Add(ct_Col_OpenPriceDiv, typeof(Int32));
            dt.Columns[ct_Col_OpenPriceDiv].DefaultValue = defValueInt32;
            // ���i�|�������N
            dt.Columns.Add(ct_Col_GoodsRateRank, typeof(string));
            dt.Columns[ct_Col_GoodsRateRank].DefaultValue = defValuestring;
            // ���Ӑ�|���O���[�v�R�[�h
            dt.Columns.Add(ct_Col_CustRateGrpCode, typeof(Int32));
            dt.Columns[ct_Col_CustRateGrpCode].DefaultValue = defValueInt32;
            // �d����|���O���[�v�R�[�h
            dt.Columns.Add(ct_Col_SuppRateGrpCode, typeof(Int32));
            dt.Columns[ct_Col_SuppRateGrpCode].DefaultValue = defValueInt32;
            // �艿�i�Ŕ��C�����j
            dt.Columns.Add(ct_Col_ListPriceTaxExcFl, typeof(Double));
            dt.Columns[ct_Col_ListPriceTaxExcFl].DefaultValue = defValueDouble;
            // �艿�i�ō��C�����j
            dt.Columns.Add(ct_Col_ListPriceTaxIncFl, typeof(Double));
            dt.Columns[ct_Col_ListPriceTaxIncFl].DefaultValue = defValueDouble;
            // �d����
            dt.Columns.Add(ct_Col_StockRate, typeof(Double));
            dt.Columns[ct_Col_StockRate].DefaultValue = defValueDouble;
            // �|���ݒ苒�_�i�d���P���j
            dt.Columns.Add(ct_Col_RateSectStckUnPrc, typeof(string));
            dt.Columns[ct_Col_RateSectStckUnPrc].DefaultValue = defValuestring;
            // �|���ݒ�敪�i�d���P���j
            dt.Columns.Add(ct_Col_RateDivStckUnPrc, typeof(string));
            dt.Columns[ct_Col_RateDivStckUnPrc].DefaultValue = defValuestring;
            // �P���Z�o�敪�i�d���P���j
            dt.Columns.Add(ct_Col_UnPrcCalcCdStckUnPrc, typeof(Int32));
            dt.Columns[ct_Col_UnPrcCalcCdStckUnPrc].DefaultValue = defValueInt32;
            // ���i�敪�i�d���P���j
            dt.Columns.Add(ct_Col_PriceCdStckUnPrc, typeof(Int32));
            dt.Columns[ct_Col_PriceCdStckUnPrc].DefaultValue = defValueInt32;
            // ��P���i�d���P���j
            dt.Columns.Add(ct_Col_StdUnPrcStckUnPrc, typeof(Double));
            dt.Columns[ct_Col_StdUnPrcStckUnPrc].DefaultValue = defValueDouble;
            // �[�������P�ʁi�d���P���j
            dt.Columns.Add(ct_Col_FracProcUnitStcUnPrc, typeof(Double));
            dt.Columns[ct_Col_FracProcUnitStcUnPrc].DefaultValue = defValueDouble;
            // �[�������i�d���P���j
            dt.Columns.Add(ct_Col_FracProcStckUnPrc, typeof(Int32));
            dt.Columns[ct_Col_FracProcStckUnPrc].DefaultValue = defValueInt32;
            // �d���P���i�Ŕ��C�����j
            dt.Columns.Add(ct_Col_StockUnitPriceFl, typeof(Double));
            dt.Columns[ct_Col_StockUnitPriceFl].DefaultValue = defValueDouble;
            // �d���P���i�ō��C�����j
            dt.Columns.Add(ct_Col_StockUnitTaxPriceFl, typeof(Double));
            dt.Columns[ct_Col_StockUnitTaxPriceFl].DefaultValue = defValueDouble;
            // �d���P���ύX�敪
            dt.Columns.Add(ct_Col_StockUnitChngDiv, typeof(Int32));
            dt.Columns[ct_Col_StockUnitChngDiv].DefaultValue = defValueInt32;
            // �ύX�O�d���P���i�����j
            dt.Columns.Add(ct_Col_BfStockUnitPriceFl, typeof(Double));
            dt.Columns[ct_Col_BfStockUnitPriceFl].DefaultValue = defValueDouble;
            // �ύX�O�艿
            dt.Columns.Add(ct_Col_BfListPrice, typeof(Double));
            dt.Columns[ct_Col_BfListPrice].DefaultValue = defValueDouble;
            // BL���i�R�[�h�i�|���j
            dt.Columns.Add(ct_Col_RateBLGoodsCode, typeof(Int32));
            dt.Columns[ct_Col_RateBLGoodsCode].DefaultValue = defValueInt32;
            // BL���i�R�[�h���́i�|���j
            dt.Columns.Add(ct_Col_RateBLGoodsName, typeof(string));
            dt.Columns[ct_Col_RateBLGoodsName].DefaultValue = defValuestring;
            // ���i�|���O���[�v�R�[�h�i�|���j
            dt.Columns.Add(ct_Col_RateGoodsRateGrpCd, typeof(Int32));
            dt.Columns[ct_Col_RateGoodsRateGrpCd].DefaultValue = defValueInt32;
            // ���i�|���O���[�v���́i�|���j
            dt.Columns.Add(ct_Col_RateGoodsRateGrpNm, typeof(string));
            dt.Columns[ct_Col_RateGoodsRateGrpNm].DefaultValue = defValuestring;
            // BL�O���[�v�R�[�h�i�|���j
            dt.Columns.Add(ct_Col_RateBLGroupCode, typeof(Int32));
            dt.Columns[ct_Col_RateBLGroupCode].DefaultValue = defValueInt32;
            // BL�O���[�v���́i�|���j
            dt.Columns.Add(ct_Col_RateBLGroupName, typeof(string));
            dt.Columns[ct_Col_RateBLGroupName].DefaultValue = defValuestring;
            // �d����
            dt.Columns.Add(ct_Col_StockCount, typeof(Double));
            dt.Columns[ct_Col_StockCount].DefaultValue = defValueDouble;
            // ��������
            dt.Columns.Add(ct_Col_OrderCnt, typeof(Double));
            dt.Columns[ct_Col_OrderCnt].DefaultValue = defValueDouble;
            // ����������
            dt.Columns.Add(ct_Col_OrderAdjustCnt, typeof(Double));
            dt.Columns[ct_Col_OrderAdjustCnt].DefaultValue = defValueDouble;
            // �����c��
            dt.Columns.Add(ct_Col_OrderRemainCnt, typeof(Double));
            dt.Columns[ct_Col_OrderRemainCnt].DefaultValue = defValueDouble;
            // �c���X�V��
            dt.Columns.Add(ct_Col_RemainCntUpdDate, typeof(DateTime));
            dt.Columns[ct_Col_RemainCntUpdDate].DefaultValue = DateTime.MinValue;
            // �d�����z�i�Ŕ����j
            dt.Columns.Add(ct_Col_StockPriceTaxExc, typeof(Int64));
            dt.Columns[ct_Col_StockPriceTaxExc].DefaultValue = defValueInt64;
            // �d�����z�i�ō��݁j
            dt.Columns.Add(ct_Col_StockPriceTaxInc, typeof(Int64));
            dt.Columns[ct_Col_StockPriceTaxInc].DefaultValue = defValueInt64;
            // �d�����i�敪
            dt.Columns.Add(ct_Col_StockGoodsCd, typeof(Int32));
            dt.Columns[ct_Col_StockGoodsCd].DefaultValue = defValueInt32;
            // �d�����z����Ŋz
            dt.Columns.Add(ct_Col_StockPriceConsTax, typeof(Int64));
            dt.Columns[ct_Col_StockPriceConsTax].DefaultValue = defValueInt64;
            // �ېŋ敪
            dt.Columns.Add(ct_Col_TaxationCode, typeof(Int32));
            dt.Columns[ct_Col_TaxationCode].DefaultValue = defValueInt32;
            // �d���`�[���ה��l1
            dt.Columns.Add(ct_Col_StockDtiSlipNote1, typeof(string));
            dt.Columns[ct_Col_StockDtiSlipNote1].DefaultValue = defValuestring;
            // �̔���R�[�h
            dt.Columns.Add(ct_Col_SalesCustomerCode, typeof(Int32));
            dt.Columns[ct_Col_SalesCustomerCode].DefaultValue = defValueInt32;
            // �̔��旪��
            dt.Columns.Add(ct_Col_SalesCustomerSnm, typeof(string));
            dt.Columns[ct_Col_SalesCustomerSnm].DefaultValue = defValuestring;
            // �`�[�����P
            dt.Columns.Add(ct_Col_SlipMemo1, typeof(string));
            dt.Columns[ct_Col_SlipMemo1].DefaultValue = defValuestring;
            // �`�[�����Q
            dt.Columns.Add(ct_Col_SlipMemo2, typeof(string));
            dt.Columns[ct_Col_SlipMemo2].DefaultValue = defValuestring;
            // �`�[�����R
            dt.Columns.Add(ct_Col_SlipMemo3, typeof(string));
            dt.Columns[ct_Col_SlipMemo3].DefaultValue = defValuestring;
            // �Г������P
            dt.Columns.Add(ct_Col_InsideMemo1, typeof(string));
            dt.Columns[ct_Col_InsideMemo1].DefaultValue = defValuestring;
            // �Г������Q
            dt.Columns.Add(ct_Col_InsideMemo2, typeof(string));
            dt.Columns[ct_Col_InsideMemo2].DefaultValue = defValuestring;
            // �Г������R
            dt.Columns.Add(ct_Col_InsideMemo3, typeof(string));
            dt.Columns[ct_Col_InsideMemo3].DefaultValue = defValuestring;
            // �d����R�[�h
            dt.Columns.Add(ct_Col_SupplierCd, typeof(Int32));
            dt.Columns[ct_Col_SupplierCd].DefaultValue = defValueInt32;
            // �d���旪��
            dt.Columns.Add(ct_Col_SupplierSnm, typeof(string));
            dt.Columns[ct_Col_SupplierSnm].DefaultValue = defValuestring;
            // �[�i��R�[�h
            dt.Columns.Add(ct_Col_AddresseeCode, typeof(Int32));
            dt.Columns[ct_Col_AddresseeCode].DefaultValue = defValueInt32;
            // �[�i�於��
            dt.Columns.Add(ct_Col_AddresseeName, typeof(string));
            dt.Columns[ct_Col_AddresseeName].DefaultValue = defValuestring;
            // �����敪
            dt.Columns.Add(ct_Col_DirectSendingCd, typeof(Int32));
            dt.Columns[ct_Col_DirectSendingCd].DefaultValue = defValueInt32;
            // �����ԍ�
            dt.Columns.Add(ct_Col_OrderNumber, typeof(string));
            dt.Columns[ct_Col_OrderNumber].DefaultValue = defValuestring;
            // �������@
            dt.Columns.Add(ct_Col_WayToOrder, typeof(Int32));
            dt.Columns[ct_Col_WayToOrder].DefaultValue = defValueInt32;
            // �[�i�����\���
            dt.Columns.Add(ct_Col_DeliGdsCmpltDueDate, typeof(DateTime));
            dt.Columns[ct_Col_DeliGdsCmpltDueDate].DefaultValue = DateTime.MinValue;
            // ��]�[��
            dt.Columns.Add(ct_Col_ExpectDeliveryDate, typeof(DateTime));
            dt.Columns[ct_Col_ExpectDeliveryDate].DefaultValue = DateTime.MinValue;
            // �����f�[�^�쐬�敪
            dt.Columns.Add(ct_Col_OrderDataCreateDiv, typeof(Int32));
            dt.Columns[ct_Col_OrderDataCreateDiv].DefaultValue = defValueInt32;
            // �����f�[�^�쐬��
            dt.Columns.Add(ct_Col_OrderDataCreateDate, typeof(DateTime));
            dt.Columns[ct_Col_OrderDataCreateDate].DefaultValue = DateTime.MinValue;
            // ���������s�ϋ敪
            dt.Columns.Add(ct_Col_OrderFormIssuedDiv, typeof(Int32));
            dt.Columns[ct_Col_OrderFormIssuedDiv].DefaultValue = defValueInt32;
            // �d��������
            dt.Columns.Add(ct_Col_StockCountDifference, typeof(Double));
            dt.Columns[ct_Col_StockCountDifference].DefaultValue = defValueDouble;
            // ���׊֘A�t��GUID
            dt.Columns.Add(ct_Col_DtlRelationGuid, typeof(Guid));
            dt.Columns[ct_Col_DtlRelationGuid].DefaultValue = Guid.Empty;

            // PrimaryKey�̐ݒ�
            dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_SupplierFormal], dt.Columns[ct_Col_StockSlipDtlNum] };
        }
		#endregion
	}
}