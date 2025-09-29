//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d����M�i�m�k�i���ρj�f�[�^�e�[�u���X�L�[�}�N���X
// �v���O�����T�v   : �t�n�d����M�i�m�k�i���ρj�f�[�^�e�[�u����`���s��
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
	/// �t�n�d����M�i�m�k�i���ρj�f�[�^�e�[�u���X�L�[�}�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d����M�i�m�k�i���ρj���o���ʃe�[�u���X�L�[�}</br>
	/// <br>Programmer : 96186�@���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// </remarks>
	public class EstmtSndRcvJnlSchema
	{
		#region Public Members
		/// <summary>�t�n�d����M�i�m�k�i���ρj�f�[�^�e�[�u����</summary>
		public const string CT_EstmtSndRcvJnlDataTable = "EstmtSndRcvJnlDataTable";

		#region �J�����������
		public const double defValueDouble = 0;
		public const Int64 defValueInt64 = 0;
		public const Int32 defValueInt32 = 0;
		public const string defValuestring = "";
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
        /// <summary> �V�X�e���敪 </summary>
        public const string ct_Col_SystemDivCd = "SystemDivCd";
        /// <summary> UOE�����ԍ� </summary>
        public const string ct_Col_UOESalesOrderNo = "UOESalesOrderNo";
        /// <summary> UOE�����s�ԍ� </summary>
        public const string ct_Col_UOESalesOrderRowNo = "UOESalesOrderRowNo";
        /// <summary> ���M�[���ԍ� </summary>
        public const string ct_Col_SendTerminalNo = "SendTerminalNo";
        /// <summary> UOE������R�[�h </summary>
        public const string ct_Col_UOESupplierCd = "UOESupplierCd";
        /// <summary> UOE�����於�� </summary>
        public const string ct_Col_UOESupplierName = "UOESupplierName";
        /// <summary> �ʐM�A�Z���u��ID </summary>
        public const string ct_Col_CommAssemblyId = "CommAssemblyId";
        /// <summary> �I�����C���ԍ� </summary>
        public const string ct_Col_OnlineNo = "OnlineNo";
        /// <summary> �I�����C���s�ԍ� </summary>
        public const string ct_Col_OnlineRowNo = "OnlineRowNo";
        /// <summary> ������t </summary>
        public const string ct_Col_SalesDate = "SalesDate";
        /// <summary> ���͓� </summary>
        public const string ct_Col_InputDay = "InputDay";
        /// <summary> �f�[�^�X�V���� </summary>
        public const string ct_Col_DataUpdateDateTime = "DataUpdateDateTime";
        /// <summary> UOE��� </summary>
        public const string ct_Col_UOEKind = "UOEKind";
        /// <summary> ����`�[�ԍ� </summary>
        public const string ct_Col_SalesSlipNum = "SalesSlipNum";
        /// <summary> �󒍃X�e�[�^�X </summary>
        public const string ct_Col_AcptAnOdrStatus = "AcptAnOdrStatus";
        /// <summary> ���㖾�גʔ� </summary>
        public const string ct_Col_SalesSlipDtlNum = "SalesSlipDtlNum";
        /// <summary> ���_�R�[�h </summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary> ����R�[�h </summary>
        public const string ct_Col_SubSectionCode = "SubSectionCode";
        /// <summary> ���Ӑ�R�[�h </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> ���Ӑ旪�� </summary>
        public const string ct_Col_CustomerSnm = "CustomerSnm";
        /// <summary> ���W�ԍ� </summary>
        public const string ct_Col_CashRegisterNo = "CashRegisterNo";
        /// <summary> ���ʒʔ� </summary>
        public const string ct_Col_CommonSeqNo = "CommonSeqNo";
        /// <summary> �d���`�� </summary>
        public const string ct_Col_SupplierFormal = "SupplierFormal";
        /// <summary> �d���`�[�ԍ� </summary>
        public const string ct_Col_SupplierSlipNo = "SupplierSlipNo";
        /// <summary> �d�����גʔ� </summary>
        public const string ct_Col_StockSlipDtlNum = "StockSlipDtlNum";
        /// <summary> BO�敪 </summary>
        public const string ct_Col_BoCode = "BoCode";
        /// <summary> �[�i�敪 </summary>
        public const string ct_Col_UOEDeliGoodsDiv = "UOEDeliGoodsDiv";
        /// <summary> �[�i�敪���� </summary>
        public const string ct_Col_DeliveredGoodsDivNm = "DeliveredGoodsDivNm";
        /// <summary> �t�H���[�[�i�敪 </summary>
        public const string ct_Col_FollowDeliGoodsDiv = "FollowDeliGoodsDiv";
        /// <summary> �t�H���[�[�i�敪���� </summary>
        public const string ct_Col_FollowDeliGoodsDivNm = "FollowDeliGoodsDivNm";
        /// <summary> UOE�w�苒�_ </summary>
        public const string ct_Col_UOEResvdSection = "UOEResvdSection";
        /// <summary> UOE�w�苒�_���� </summary>
        public const string ct_Col_UOEResvdSectionNm = "UOEResvdSectionNm";
        /// <summary> �]�ƈ��R�[�h </summary>
        public const string ct_Col_EmployeeCode = "EmployeeCode";
        /// <summary> �]�ƈ����� </summary>
        public const string ct_Col_EmployeeName = "EmployeeName";
        /// <summary> ���i���[�J�[�R�[�h </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> ���[�J�[���� </summary>
        public const string ct_Col_MakerName = "MakerName";
        /// <summary> ���i�ԍ� </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> �n�C�t�������i�ԍ� </summary>
        public const string ct_Col_GoodsNoNoneHyphen = "GoodsNoNoneHyphen";
        /// <summary> ���i���� </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> �q�ɃR�[�h </summary>
        public const string ct_Col_WarehouseCode = "WarehouseCode";
        /// <summary> �q�ɖ��� </summary>
        public const string ct_Col_WarehouseName = "WarehouseName";
        /// <summary> �q�ɒI�� </summary>
        public const string ct_Col_WarehouseShelfNo = "WarehouseShelfNo";
        /// <summary> �󒍐��� </summary>
        public const string ct_Col_AcceptAnOrderCnt = "AcceptAnOrderCnt";
        /// <summary> �艿�i�����j </summary>
        public const string ct_Col_ListPrice = "ListPrice";
        /// <summary> �����P�� </summary>
        public const string ct_Col_SalesUnitCost = "SalesUnitCost";
        /// <summary> �d����R�[�h </summary>
        public const string ct_Col_SupplierCd = "SupplierCd";
        /// <summary> �d���旪�� </summary>
        public const string ct_Col_SupplierSnm = "SupplierSnm";
        /// <summary> �t�n�d���}�[�N�P </summary>
        public const string ct_Col_UoeRemark1 = "UoeRemark1";
        /// <summary> �t�n�d���}�[�N�Q </summary>
        public const string ct_Col_UoeRemark2 = "UoeRemark2";
        /// <summary> ���σ��[�g </summary>
        public const string ct_Col_EstimateRate = "EstimateRate";
        /// <summary> �I���R�[�h </summary>
        public const string ct_Col_SelectCode = "SelectCode";
        /// <summary> ��M���t </summary>
        public const string ct_Col_ReceiveDate = "ReceiveDate";
        /// <summary> ��M���� </summary>
        public const string ct_Col_ReceiveTime = "ReceiveTime";
        /// <summary> �񓚃��[�J�[�R�[�h </summary>
        public const string ct_Col_AnswerMakerCd = "AnswerMakerCd";
        /// <summary> �񓚕i�� </summary>
        public const string ct_Col_AnswerPartsNo = "AnswerPartsNo";
        /// <summary> �񓚕i�� </summary>
        public const string ct_Col_AnswerPartsName = "AnswerPartsName";
        /// <summary> ��֕i�� </summary>
        public const string ct_Col_SubstPartsNo = "SubstPartsNo";
        /// <summary> �񓚒艿 </summary>
        public const string ct_Col_AnswerListPrice = "AnswerListPrice";
        /// <summary> ����P���i�Ŕ��C�����j </summary>
        public const string ct_Col_SalesUnPrcTaxExcFl = "SalesUnPrcTaxExcFl";
        /// <summary> �{���݌� </summary>
        public const string ct_Col_HeadQtrsStock = "HeadQtrsStock";
        /// <summary> ���_�݌� </summary>
        public const string ct_Col_BranchStock = "BranchStock";
        /// <summary> �x�X�݌� </summary>
        public const string ct_Col_SectionStock = "SectionStock";
        /// <summary> UOE���_�R�[�h�P </summary>
        public const string ct_Col_UOESectionCode1 = "UOESectionCode1";
        /// <summary> UOE���_�R�[�h�Q </summary>
        public const string ct_Col_UOESectionCode2 = "UOESectionCode2";
        /// <summary> UOE���_�R�[�h�R </summary>
        public const string ct_Col_UOESectionCode3 = "UOESectionCode3";
        /// <summary> UOE���_�݌ɐ��P </summary>
        public const string ct_Col_UOESectionStock1 = "UOESectionStock1";
        /// <summary> UOE���_�݌ɐ��Q </summary>
        public const string ct_Col_UOESectionStock2 = "UOESectionStock2";
        /// <summary> UOE���_�݌ɐ��R </summary>
        public const string ct_Col_UOESectionStock3 = "UOESectionStock3";
        /// <summary> UOE�[���R�[�h </summary>
        public const string ct_Col_UOEDelivDateCd = "UOEDelivDateCd";
        /// <summary> UOE��փR�[�h </summary>
        public const string ct_Col_UOESubstCode = "UOESubstCode";
        /// <summary> UOE���i�R�[�h </summary>
        public const string ct_Col_UOEPriceCode = "UOEPriceCode";
        /// <summary> �񓚌����P�� </summary>
        public const string ct_Col_AnswerSalesUnitCost = "AnswerSalesUnitCost";
        /// <summary> �w�ʃR�[�h </summary>
        public const string ct_Col_PartsLayerCd = "PartsLayerCd";
        /// <summary> �w�b�h�G���[���b�Z�[�W </summary>
        public const string ct_Col_HeadErrorMassage = "HeadErrorMassage";
        /// <summary> ���C���G���[���b�Z�[�W </summary>
        public const string ct_Col_LineErrorMassage = "LineErrorMassage";
        /// <summary> �f�[�^���M�敪 </summary>
        public const string ct_Col_DataSendCode = "DataSendCode";
        /// <summary> �f�[�^�����敪 </summary>
        public const string ct_Col_DataRecoverDiv = "DataRecoverDiv";
        #endregion

		#endregion

		#region Constructor
		/// <summary>
		/// �t�n�d����M�i�m�k�i���ρj�f�[�^�e�[�u���X�L�[�}�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �t�n�d����M�i�m�k�i���ρj�f�[�^�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���܂��B</br>
		/// <br>Programmer : 96186�@���ԗT��</br>
		/// <br>Date       : 2008.05.26</br>
		/// </remarks>
		public EstmtSndRcvJnlSchema()
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
		public static void SettingDataSet(ref DataSet ds)
		{
			// �e�[�u�������݂��邩�ǂ������`�F�b�N
			if ((ds.Tables.Contains(CT_EstmtSndRcvJnlDataTable)))
			{
				// TODO:�e�[�u�������݂���Ƃ��̓N���A�[����̂�
				// �X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
				ds.Tables[CT_EstmtSndRcvJnlDataTable].Clear();
			}
			else
			{
				CreateTable(ref ds);

			}
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// �t�n�d����M�i�m�k�i���ρj�쐬����
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 96186 ���ԗT��</br>
		/// <br>Date       : 2008.05.26</br>
		/// </remarks>
		private static void CreateTable(ref DataSet ds)
		{
			DataTable dt = null;
			// �X�L�[�}�ݒ�
			ds.Tables.Add(CT_EstmtSndRcvJnlDataTable);
			dt = ds.Tables[CT_EstmtSndRcvJnlDataTable];

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
            // �V�X�e���敪
            dt.Columns.Add(ct_Col_SystemDivCd, typeof(Int32));
            dt.Columns[ct_Col_SystemDivCd].DefaultValue = defValueInt32;
            // UOE�����ԍ�
            dt.Columns.Add(ct_Col_UOESalesOrderNo, typeof(Int32));
            dt.Columns[ct_Col_UOESalesOrderNo].DefaultValue = defValueInt32;
            // UOE�����s�ԍ�
            dt.Columns.Add(ct_Col_UOESalesOrderRowNo, typeof(Int32));
            dt.Columns[ct_Col_UOESalesOrderRowNo].DefaultValue = defValueInt32;
            // ���M�[���ԍ�
            dt.Columns.Add(ct_Col_SendTerminalNo, typeof(Int32));
            dt.Columns[ct_Col_SendTerminalNo].DefaultValue = defValueInt32;
            // UOE������R�[�h
            dt.Columns.Add(ct_Col_UOESupplierCd, typeof(Int32));
            dt.Columns[ct_Col_UOESupplierCd].DefaultValue = defValueInt32;
            // UOE�����於��
            dt.Columns.Add(ct_Col_UOESupplierName, typeof(string));
            dt.Columns[ct_Col_UOESupplierName].DefaultValue = defValuestring;
            // �ʐM�A�Z���u��ID
            dt.Columns.Add(ct_Col_CommAssemblyId, typeof(string));
            dt.Columns[ct_Col_CommAssemblyId].DefaultValue = defValuestring;
            // �I�����C���ԍ�
            dt.Columns.Add(ct_Col_OnlineNo, typeof(Int32));
            dt.Columns[ct_Col_OnlineNo].DefaultValue = defValueInt32;
            // �I�����C���s�ԍ�
            dt.Columns.Add(ct_Col_OnlineRowNo, typeof(Int32));
            dt.Columns[ct_Col_OnlineRowNo].DefaultValue = defValueInt32;
            // ������t
            dt.Columns.Add(ct_Col_SalesDate, typeof(DateTime));
            dt.Columns[ct_Col_SalesDate].DefaultValue = DateTime.MinValue;
            // ���͓�
            dt.Columns.Add(ct_Col_InputDay, typeof(DateTime));
            dt.Columns[ct_Col_InputDay].DefaultValue = DateTime.MinValue;
            // �f�[�^�X�V����
            dt.Columns.Add(ct_Col_DataUpdateDateTime, typeof(DateTime));
            dt.Columns[ct_Col_DataUpdateDateTime].DefaultValue = DateTime.MinValue;
            // UOE���
            dt.Columns.Add(ct_Col_UOEKind, typeof(Int32));
            dt.Columns[ct_Col_UOEKind].DefaultValue = defValueInt32;
            // ����`�[�ԍ�
            dt.Columns.Add(ct_Col_SalesSlipNum, typeof(string));
            dt.Columns[ct_Col_SalesSlipNum].DefaultValue = defValuestring;
            // �󒍃X�e�[�^�X
            dt.Columns.Add(ct_Col_AcptAnOdrStatus, typeof(Int32));
            dt.Columns[ct_Col_AcptAnOdrStatus].DefaultValue = defValueInt32;
            // ���㖾�גʔ�
            dt.Columns.Add(ct_Col_SalesSlipDtlNum, typeof(Int64));
            dt.Columns[ct_Col_SalesSlipDtlNum].DefaultValue = defValueInt64;
            // ���_�R�[�h
            dt.Columns.Add(ct_Col_SectionCode, typeof(string));
            dt.Columns[ct_Col_SectionCode].DefaultValue = defValuestring;
            // ����R�[�h
            dt.Columns.Add(ct_Col_SubSectionCode, typeof(Int32));
            dt.Columns[ct_Col_SubSectionCode].DefaultValue = defValueInt32;
            // ���Ӑ�R�[�h
            dt.Columns.Add(ct_Col_CustomerCode, typeof(Int32));
            dt.Columns[ct_Col_CustomerCode].DefaultValue = defValueInt32;
            // ���Ӑ旪��
            dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));
            dt.Columns[ct_Col_CustomerSnm].DefaultValue = defValuestring;
            // ���W�ԍ�
            dt.Columns.Add(ct_Col_CashRegisterNo, typeof(Int32));
            dt.Columns[ct_Col_CashRegisterNo].DefaultValue = defValueInt32;
            // ���ʒʔ�
            dt.Columns.Add(ct_Col_CommonSeqNo, typeof(Int64));
            dt.Columns[ct_Col_CommonSeqNo].DefaultValue = defValueInt64;
            // �d���`��
            dt.Columns.Add(ct_Col_SupplierFormal, typeof(Int32));
            dt.Columns[ct_Col_SupplierFormal].DefaultValue = defValueInt32;
            // �d���`�[�ԍ�
            dt.Columns.Add(ct_Col_SupplierSlipNo, typeof(Int32));
            dt.Columns[ct_Col_SupplierSlipNo].DefaultValue = defValueInt32;
            // �d�����גʔ�
            dt.Columns.Add(ct_Col_StockSlipDtlNum, typeof(Int64));
            dt.Columns[ct_Col_StockSlipDtlNum].DefaultValue = defValueInt64;
            // BO�敪
            dt.Columns.Add(ct_Col_BoCode, typeof(string));
            dt.Columns[ct_Col_BoCode].DefaultValue = defValuestring;
            // �[�i�敪
            dt.Columns.Add(ct_Col_UOEDeliGoodsDiv, typeof(string));
            dt.Columns[ct_Col_UOEDeliGoodsDiv].DefaultValue = defValuestring;
            // �[�i�敪����
            dt.Columns.Add(ct_Col_DeliveredGoodsDivNm, typeof(string));
            dt.Columns[ct_Col_DeliveredGoodsDivNm].DefaultValue = defValuestring;
            // �t�H���[�[�i�敪
            dt.Columns.Add(ct_Col_FollowDeliGoodsDiv, typeof(string));
            dt.Columns[ct_Col_FollowDeliGoodsDiv].DefaultValue = defValuestring;
            // �t�H���[�[�i�敪����
            dt.Columns.Add(ct_Col_FollowDeliGoodsDivNm, typeof(string));
            dt.Columns[ct_Col_FollowDeliGoodsDivNm].DefaultValue = defValuestring;
            // UOE�w�苒�_
            dt.Columns.Add(ct_Col_UOEResvdSection, typeof(string));
            dt.Columns[ct_Col_UOEResvdSection].DefaultValue = defValuestring;
            // UOE�w�苒�_����
            dt.Columns.Add(ct_Col_UOEResvdSectionNm, typeof(string));
            dt.Columns[ct_Col_UOEResvdSectionNm].DefaultValue = defValuestring;
            // �]�ƈ��R�[�h
            dt.Columns.Add(ct_Col_EmployeeCode, typeof(string));
            dt.Columns[ct_Col_EmployeeCode].DefaultValue = defValuestring;
            // �]�ƈ�����
            dt.Columns.Add(ct_Col_EmployeeName, typeof(string));
            dt.Columns[ct_Col_EmployeeName].DefaultValue = defValuestring;
            // ���i���[�J�[�R�[�h
            dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32));
            dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = defValueInt32;
            // ���[�J�[����
            dt.Columns.Add(ct_Col_MakerName, typeof(string));
            dt.Columns[ct_Col_MakerName].DefaultValue = defValuestring;
            // ���i�ԍ�
            dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
            dt.Columns[ct_Col_GoodsNo].DefaultValue = defValuestring;
            // �n�C�t�������i�ԍ�
            dt.Columns.Add(ct_Col_GoodsNoNoneHyphen, typeof(string));
            dt.Columns[ct_Col_GoodsNoNoneHyphen].DefaultValue = defValuestring;
            // ���i����
            dt.Columns.Add(ct_Col_GoodsName, typeof(string));
            dt.Columns[ct_Col_GoodsName].DefaultValue = defValuestring;
            // �q�ɃR�[�h
            dt.Columns.Add(ct_Col_WarehouseCode, typeof(string));
            dt.Columns[ct_Col_WarehouseCode].DefaultValue = defValuestring;
            // �q�ɖ���
            dt.Columns.Add(ct_Col_WarehouseName, typeof(string));
            dt.Columns[ct_Col_WarehouseName].DefaultValue = defValuestring;
            // �q�ɒI��
            dt.Columns.Add(ct_Col_WarehouseShelfNo, typeof(string));
            dt.Columns[ct_Col_WarehouseShelfNo].DefaultValue = defValuestring;
            // �󒍐���
            dt.Columns.Add(ct_Col_AcceptAnOrderCnt, typeof(Double));
            dt.Columns[ct_Col_AcceptAnOrderCnt].DefaultValue = defValueDouble;
            // �艿�i�����j
            dt.Columns.Add(ct_Col_ListPrice, typeof(Double));
            dt.Columns[ct_Col_ListPrice].DefaultValue = defValueDouble;
            // �����P��
            dt.Columns.Add(ct_Col_SalesUnitCost, typeof(Double));
            dt.Columns[ct_Col_SalesUnitCost].DefaultValue = defValueDouble;
            // �d����R�[�h
            dt.Columns.Add(ct_Col_SupplierCd, typeof(Int32));
            dt.Columns[ct_Col_SupplierCd].DefaultValue = defValueInt32;
            // �d���旪��
            dt.Columns.Add(ct_Col_SupplierSnm, typeof(string));
            dt.Columns[ct_Col_SupplierSnm].DefaultValue = defValuestring;
            // �t�n�d���}�[�N�P
            dt.Columns.Add(ct_Col_UoeRemark1, typeof(string));
            dt.Columns[ct_Col_UoeRemark1].DefaultValue = defValuestring;
            // �t�n�d���}�[�N�Q
            dt.Columns.Add(ct_Col_UoeRemark2, typeof(string));
            dt.Columns[ct_Col_UoeRemark2].DefaultValue = defValuestring;
            // ���σ��[�g
            dt.Columns.Add(ct_Col_EstimateRate, typeof(string));
            dt.Columns[ct_Col_EstimateRate].DefaultValue = defValuestring;
            // �I���R�[�h
            dt.Columns.Add(ct_Col_SelectCode, typeof(string));
            dt.Columns[ct_Col_SelectCode].DefaultValue = defValuestring;
            // ��M���t
            dt.Columns.Add(ct_Col_ReceiveDate, typeof(DateTime));
            dt.Columns[ct_Col_ReceiveDate].DefaultValue = DateTime.MinValue;
            // ��M����
            dt.Columns.Add(ct_Col_ReceiveTime, typeof(Int32));
            dt.Columns[ct_Col_ReceiveTime].DefaultValue = defValueInt32;
            // �񓚃��[�J�[�R�[�h
            dt.Columns.Add(ct_Col_AnswerMakerCd, typeof(Int32));
            dt.Columns[ct_Col_AnswerMakerCd].DefaultValue = defValueInt32;
            // �񓚕i��
            dt.Columns.Add(ct_Col_AnswerPartsNo, typeof(string));
            dt.Columns[ct_Col_AnswerPartsNo].DefaultValue = defValuestring;
            // �񓚕i��
            dt.Columns.Add(ct_Col_AnswerPartsName, typeof(string));
            dt.Columns[ct_Col_AnswerPartsName].DefaultValue = defValuestring;
            // ��֕i��
            dt.Columns.Add(ct_Col_SubstPartsNo, typeof(string));
            dt.Columns[ct_Col_SubstPartsNo].DefaultValue = defValuestring;
            // �񓚒艿
            dt.Columns.Add(ct_Col_AnswerListPrice, typeof(Double));
            dt.Columns[ct_Col_AnswerListPrice].DefaultValue = defValueDouble;
            // ����P���i�Ŕ��C�����j
            dt.Columns.Add(ct_Col_SalesUnPrcTaxExcFl, typeof(Double));
            dt.Columns[ct_Col_SalesUnPrcTaxExcFl].DefaultValue = defValueDouble;
            // �{���݌�
            dt.Columns.Add(ct_Col_HeadQtrsStock, typeof(string));
            dt.Columns[ct_Col_HeadQtrsStock].DefaultValue = defValuestring;
            // ���_�݌�
            dt.Columns.Add(ct_Col_BranchStock, typeof(string));
            dt.Columns[ct_Col_BranchStock].DefaultValue = defValuestring;
            // �x�X�݌�
            dt.Columns.Add(ct_Col_SectionStock, typeof(string));
            dt.Columns[ct_Col_SectionStock].DefaultValue = defValuestring;
            // UOE���_�R�[�h�P
            dt.Columns.Add(ct_Col_UOESectionCode1, typeof(string));
            dt.Columns[ct_Col_UOESectionCode1].DefaultValue = defValuestring;
            // UOE���_�R�[�h�Q
            dt.Columns.Add(ct_Col_UOESectionCode2, typeof(string));
            dt.Columns[ct_Col_UOESectionCode2].DefaultValue = defValuestring;
            // UOE���_�R�[�h�R
            dt.Columns.Add(ct_Col_UOESectionCode3, typeof(string));
            dt.Columns[ct_Col_UOESectionCode3].DefaultValue = defValuestring;
            // UOE���_�݌ɐ��P
            dt.Columns.Add(ct_Col_UOESectionStock1, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock1].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��Q
            dt.Columns.Add(ct_Col_UOESectionStock2, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock2].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��R
            dt.Columns.Add(ct_Col_UOESectionStock3, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock3].DefaultValue = defValueInt32;
            // UOE�[���R�[�h
            dt.Columns.Add(ct_Col_UOEDelivDateCd, typeof(string));
            dt.Columns[ct_Col_UOEDelivDateCd].DefaultValue = defValuestring;
            // UOE��փR�[�h
            dt.Columns.Add(ct_Col_UOESubstCode, typeof(string));
            dt.Columns[ct_Col_UOESubstCode].DefaultValue = defValuestring;
            // UOE���i�R�[�h
            dt.Columns.Add(ct_Col_UOEPriceCode, typeof(string));
            dt.Columns[ct_Col_UOEPriceCode].DefaultValue = defValuestring;
            // �񓚌����P��
            dt.Columns.Add(ct_Col_AnswerSalesUnitCost, typeof(Double));
            dt.Columns[ct_Col_AnswerSalesUnitCost].DefaultValue = defValueDouble;
            // �w�ʃR�[�h
            dt.Columns.Add(ct_Col_PartsLayerCd, typeof(string));
            dt.Columns[ct_Col_PartsLayerCd].DefaultValue = defValuestring;
            // �w�b�h�G���[���b�Z�[�W
            dt.Columns.Add(ct_Col_HeadErrorMassage, typeof(string));
            dt.Columns[ct_Col_HeadErrorMassage].DefaultValue = defValuestring;
            // ���C���G���[���b�Z�[�W
            dt.Columns.Add(ct_Col_LineErrorMassage, typeof(string));
            dt.Columns[ct_Col_LineErrorMassage].DefaultValue = defValuestring;
            // �f�[�^���M�敪
            dt.Columns.Add(ct_Col_DataSendCode, typeof(Int32));
            dt.Columns[ct_Col_DataSendCode].DefaultValue = defValueInt32;
            // �f�[�^�����敪
            dt.Columns.Add(ct_Col_DataRecoverDiv, typeof(Int32));
            dt.Columns[ct_Col_DataRecoverDiv].DefaultValue = defValueInt32;

			dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_EnterpriseCode], dt.Columns[ct_Col_UOESupplierCd], dt.Columns[ct_Col_UOESalesOrderNo], dt.Columns[ct_Col_UOESalesOrderRowNo] };

		}
		#endregion
	}
}