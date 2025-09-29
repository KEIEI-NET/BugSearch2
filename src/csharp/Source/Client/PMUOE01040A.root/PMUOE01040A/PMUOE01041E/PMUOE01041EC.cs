//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d����M�i�m�k�i�݌Ɂj�f�[�^�e�[�u���X�L�[�}�N���X
// �v���O�����T�v   : �t�n�d����M�i�m�k�i�݌Ɂj�f�[�^�e�[�u����`���s��
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
	/// �t�n�d����M�i�m�k�i�݌Ɂj�f�[�^�e�[�u���X�L�[�}�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d����M�i�m�k�i�݌Ɂj���o���ʃe�[�u���X�L�[�}</br>
	/// <br>Programmer : 96186�@���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// </remarks>
	public class StockSndRcvJnlSchema
	{
		#region Public Members
		/// <summary>�t�n�d����M�i�m�k�i�݌Ɂj�f�[�^�e�[�u����</summary>
		public const string CT_StockSndRcvJnlDataTable = "StockSndRcvJnlDataTable";

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
        /// <summary> ��֕i�ԁi�Z���^�[�j </summary>
        public const string ct_Col_CenterSubstPartsNo = "CenterSubstPartsNo";
        /// <summary> �񓚒艿 </summary>
        public const string ct_Col_AnswerListPrice = "AnswerListPrice";
        /// <summary> �񓚌����P�� </summary>
        public const string ct_Col_AnswerSalesUnitCost = "AnswerSalesUnitCost";
        /// <summary> ���i�`���i </summary>
        public const string ct_Col_GoodsAPrice = "GoodsAPrice";
        /// <summary> UOE���~�R�[�h </summary>
        public const string ct_Col_UOEStopCd = "UOEStopCd";
        /// <summary> UOE��փR�[�h </summary>
        public const string ct_Col_UOESubstCode = "UOESubstCode";
        /// <summary> UOE�[���R�[�h </summary>
        public const string ct_Col_UOEDelivDateCd = "UOEDelivDateCd";
        /// <summary> �w�ʃR�[�h </summary>
        public const string ct_Col_PartsLayerCd = "PartsLayerCd";
        /// <summary> �̔��X�d���P�� </summary>
        public const string ct_Col_ShopStUnitPrice = "ShopStUnitPrice";
        /// <summary> UOE���_�R�[�h�P </summary>
        public const string ct_Col_UOESectionCode1 = "UOESectionCode1";
        /// <summary> UOE���_�R�[�h�Q </summary>
        public const string ct_Col_UOESectionCode2 = "UOESectionCode2";
        /// <summary> UOE���_�R�[�h�R </summary>
        public const string ct_Col_UOESectionCode3 = "UOESectionCode3";
        /// <summary> UOE���_�R�[�h�S </summary>
        public const string ct_Col_UOESectionCode4 = "UOESectionCode4";
        /// <summary> UOE���_�R�[�h�T </summary>
        public const string ct_Col_UOESectionCode5 = "UOESectionCode5";
        /// <summary> UOE���_�R�[�h�U </summary>
        public const string ct_Col_UOESectionCode6 = "UOESectionCode6";
        /// <summary> UOE���_�R�[�h�V </summary>
        public const string ct_Col_UOESectionCode7 = "UOESectionCode7";
        /// <summary> UOE���_�R�[�h�W </summary>
        public const string ct_Col_UOESectionCode8 = "UOESectionCode8";
        /// <summary> �{���݌� </summary>
        public const string ct_Col_HeadQtrsStock = "HeadQtrsStock";
        /// <summary> UOE���_�݌ɐ��P </summary>
        public const string ct_Col_UOESectionStock1 = "UOESectionStock1";
        /// <summary> UOE���_�݌ɐ��Q </summary>
        public const string ct_Col_UOESectionStock2 = "UOESectionStock2";
        /// <summary> UOE���_�݌ɐ��R </summary>
        public const string ct_Col_UOESectionStock3 = "UOESectionStock3";
        /// <summary> UOE���_�݌ɐ��S </summary>
        public const string ct_Col_UOESectionStock4 = "UOESectionStock4";
        /// <summary> UOE���_�݌ɐ��T </summary>
        public const string ct_Col_UOESectionStock5 = "UOESectionStock5";
        /// <summary> UOE���_�݌ɐ��U </summary>
        public const string ct_Col_UOESectionStock6 = "UOESectionStock6";
        /// <summary> UOE���_�݌ɐ��V </summary>
        public const string ct_Col_UOESectionStock7 = "UOESectionStock7";
        /// <summary> UOE���_�݌ɐ��W </summary>
        public const string ct_Col_UOESectionStock8 = "UOESectionStock8";
        /// <summary> UOE���_�݌ɐ��X </summary>
        public const string ct_Col_UOESectionStock9 = "UOESectionStock9";
        /// <summary> UOE���_�݌ɐ��P�O </summary>
        public const string ct_Col_UOESectionStock10 = "UOESectionStock10";
        /// <summary> UOE���_�݌ɐ��P�P </summary>
        public const string ct_Col_UOESectionStock11 = "UOESectionStock11";
        /// <summary> UOE���_�݌ɐ��P�Q </summary>
        public const string ct_Col_UOESectionStock12 = "UOESectionStock12";
        /// <summary> UOE���_�݌ɐ��P�R </summary>
        public const string ct_Col_UOESectionStock13 = "UOESectionStock13";
        /// <summary> UOE���_�݌ɐ��P�S </summary>
        public const string ct_Col_UOESectionStock14 = "UOESectionStock14";
        /// <summary> UOE���_�݌ɐ��P�T </summary>
        public const string ct_Col_UOESectionStock15 = "UOESectionStock15";
        /// <summary> UOE���_�݌ɐ��P�U </summary>
        public const string ct_Col_UOESectionStock16 = "UOESectionStock16";
        /// <summary> UOE���_�݌ɐ��P�V </summary>
        public const string ct_Col_UOESectionStock17 = "UOESectionStock17";
        /// <summary> UOE���_�݌ɐ��P�W </summary>
        public const string ct_Col_UOESectionStock18 = "UOESectionStock18";
        /// <summary> UOE���_�݌ɐ��P�X </summary>
        public const string ct_Col_UOESectionStock19 = "UOESectionStock19";
        /// <summary> UOE���_�݌ɐ��Q�O </summary>
        public const string ct_Col_UOESectionStock20 = "UOESectionStock20";
        /// <summary> UOE���_�݌ɐ��Q�P </summary>
        public const string ct_Col_UOESectionStock21 = "UOESectionStock21";
        /// <summary> UOE���_�݌ɐ��Q�Q </summary>
        public const string ct_Col_UOESectionStock22 = "UOESectionStock22";
        /// <summary> UOE���_�݌ɐ��Q�R </summary>
        public const string ct_Col_UOESectionStock23 = "UOESectionStock23";
        /// <summary> UOE���_�݌ɐ��Q�S </summary>
        public const string ct_Col_UOESectionStock24 = "UOESectionStock24";
        /// <summary> UOE���_�݌ɐ��Q�T </summary>
        public const string ct_Col_UOESectionStock25 = "UOESectionStock25";
        /// <summary> UOE���_�݌ɐ��Q�U </summary>
        public const string ct_Col_UOESectionStock26 = "UOESectionStock26";
        /// <summary> UOE���_�݌ɐ��Q�V </summary>
        public const string ct_Col_UOESectionStock27 = "UOESectionStock27";
        /// <summary> UOE���_�݌ɐ��Q�W </summary>
        public const string ct_Col_UOESectionStock28 = "UOESectionStock28";
        /// <summary> UOE���_�݌ɐ��Q�X </summary>
        public const string ct_Col_UOESectionStock29 = "UOESectionStock29";
        /// <summary> UOE���_�݌ɐ��R�O </summary>
        public const string ct_Col_UOESectionStock30 = "UOESectionStock30";
        /// <summary> UOE���_�݌ɐ��R�P </summary>
        public const string ct_Col_UOESectionStock31 = "UOESectionStock31";
        /// <summary> UOE���_�݌ɐ��R�Q </summary>
        public const string ct_Col_UOESectionStock32 = "UOESectionStock32";
        /// <summary> UOE���_�݌ɐ��R�R </summary>
        public const string ct_Col_UOESectionStock33 = "UOESectionStock33";
        /// <summary> UOE���_�݌ɐ��R�S </summary>
        public const string ct_Col_UOESectionStock34 = "UOESectionStock34";
        /// <summary> UOE���_�݌ɐ��R�T </summary>
        public const string ct_Col_UOESectionStock35 = "UOESectionStock35";
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
		/// �t�n�d����M�i�m�k�i�݌Ɂj�f�[�^�e�[�u���X�L�[�}�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �t�n�d����M�i�m�k�i�݌Ɂj�f�[�^�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���܂��B</br>
		/// <br>Programmer : 96186�@���ԗT��</br>
		/// <br>Date       : 2008.05.26</br>
		/// </remarks>
		public StockSndRcvJnlSchema()
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
			if ((ds.Tables.Contains(CT_StockSndRcvJnlDataTable)))
			{
				// TODO:�e�[�u�������݂���Ƃ��̓N���A�[����̂�
				// �X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
				ds.Tables[CT_StockSndRcvJnlDataTable].Clear();
			}
			else
			{
				CreateTable(ref ds);

			}
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// �t�n�d����M�i�m�k�i�݌Ɂj�쐬����
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
			ds.Tables.Add(CT_StockSndRcvJnlDataTable);
			dt = ds.Tables[CT_StockSndRcvJnlDataTable];

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
            // ��֕i�ԁi�Z���^�[�j
            dt.Columns.Add(ct_Col_CenterSubstPartsNo, typeof(string));
            dt.Columns[ct_Col_CenterSubstPartsNo].DefaultValue = defValuestring;
            // �񓚒艿
            dt.Columns.Add(ct_Col_AnswerListPrice, typeof(Double));
            dt.Columns[ct_Col_AnswerListPrice].DefaultValue = defValueDouble;
            // �񓚌����P��
            dt.Columns.Add(ct_Col_AnswerSalesUnitCost, typeof(Double));
            dt.Columns[ct_Col_AnswerSalesUnitCost].DefaultValue = defValueDouble;
            // ���i�`���i
            dt.Columns.Add(ct_Col_GoodsAPrice, typeof(Double));
            dt.Columns[ct_Col_GoodsAPrice].DefaultValue = defValueDouble;
            // UOE���~�R�[�h
            dt.Columns.Add(ct_Col_UOEStopCd, typeof(string));
            dt.Columns[ct_Col_UOEStopCd].DefaultValue = defValuestring;
            // UOE��փR�[�h
            dt.Columns.Add(ct_Col_UOESubstCode, typeof(string));
            dt.Columns[ct_Col_UOESubstCode].DefaultValue = defValuestring;
            // UOE�[���R�[�h
            dt.Columns.Add(ct_Col_UOEDelivDateCd, typeof(string));
            dt.Columns[ct_Col_UOEDelivDateCd].DefaultValue = defValuestring;
            // �w�ʃR�[�h
            dt.Columns.Add(ct_Col_PartsLayerCd, typeof(string));
            dt.Columns[ct_Col_PartsLayerCd].DefaultValue = defValuestring;
            // �̔��X�d���P��
            dt.Columns.Add(ct_Col_ShopStUnitPrice, typeof(Double));
            dt.Columns[ct_Col_ShopStUnitPrice].DefaultValue = defValueDouble;
            // UOE���_�R�[�h�P
            dt.Columns.Add(ct_Col_UOESectionCode1, typeof(string));
            dt.Columns[ct_Col_UOESectionCode1].DefaultValue = defValuestring;
            // UOE���_�R�[�h�Q
            dt.Columns.Add(ct_Col_UOESectionCode2, typeof(string));
            dt.Columns[ct_Col_UOESectionCode2].DefaultValue = defValuestring;
            // UOE���_�R�[�h�R
            dt.Columns.Add(ct_Col_UOESectionCode3, typeof(string));
            dt.Columns[ct_Col_UOESectionCode3].DefaultValue = defValuestring;
            // UOE���_�R�[�h�S
            dt.Columns.Add(ct_Col_UOESectionCode4, typeof(string));
            dt.Columns[ct_Col_UOESectionCode4].DefaultValue = defValuestring;
            // UOE���_�R�[�h�T
            dt.Columns.Add(ct_Col_UOESectionCode5, typeof(string));
            dt.Columns[ct_Col_UOESectionCode5].DefaultValue = defValuestring;
            // UOE���_�R�[�h�U
            dt.Columns.Add(ct_Col_UOESectionCode6, typeof(string));
            dt.Columns[ct_Col_UOESectionCode6].DefaultValue = defValuestring;
            // UOE���_�R�[�h�V
            dt.Columns.Add(ct_Col_UOESectionCode7, typeof(string));
            dt.Columns[ct_Col_UOESectionCode7].DefaultValue = defValuestring;
            // UOE���_�R�[�h�W
            dt.Columns.Add(ct_Col_UOESectionCode8, typeof(string));
            dt.Columns[ct_Col_UOESectionCode8].DefaultValue = defValuestring;
            // �{���݌�
            dt.Columns.Add(ct_Col_HeadQtrsStock, typeof(string));
            dt.Columns[ct_Col_HeadQtrsStock].DefaultValue = defValuestring;
            // UOE���_�݌ɐ��P
            dt.Columns.Add(ct_Col_UOESectionStock1, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock1].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��Q
            dt.Columns.Add(ct_Col_UOESectionStock2, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock2].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��R
            dt.Columns.Add(ct_Col_UOESectionStock3, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock3].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��S
            dt.Columns.Add(ct_Col_UOESectionStock4, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock4].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��T
            dt.Columns.Add(ct_Col_UOESectionStock5, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock5].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��U
            dt.Columns.Add(ct_Col_UOESectionStock6, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock6].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��V
            dt.Columns.Add(ct_Col_UOESectionStock7, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock7].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��W
            dt.Columns.Add(ct_Col_UOESectionStock8, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock8].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��X
            dt.Columns.Add(ct_Col_UOESectionStock9, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock9].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��P�O
            dt.Columns.Add(ct_Col_UOESectionStock10, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock10].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��P�P
            dt.Columns.Add(ct_Col_UOESectionStock11, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock11].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��P�Q
            dt.Columns.Add(ct_Col_UOESectionStock12, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock12].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��P�R
            dt.Columns.Add(ct_Col_UOESectionStock13, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock13].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��P�S
            dt.Columns.Add(ct_Col_UOESectionStock14, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock14].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��P�T
            dt.Columns.Add(ct_Col_UOESectionStock15, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock15].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��P�U
            dt.Columns.Add(ct_Col_UOESectionStock16, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock16].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��P�V
            dt.Columns.Add(ct_Col_UOESectionStock17, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock17].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��P�W
            dt.Columns.Add(ct_Col_UOESectionStock18, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock18].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��P�X
            dt.Columns.Add(ct_Col_UOESectionStock19, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock19].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��Q�O
            dt.Columns.Add(ct_Col_UOESectionStock20, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock20].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��Q�P
            dt.Columns.Add(ct_Col_UOESectionStock21, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock21].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��Q�Q
            dt.Columns.Add(ct_Col_UOESectionStock22, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock22].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��Q�R
            dt.Columns.Add(ct_Col_UOESectionStock23, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock23].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��Q�S
            dt.Columns.Add(ct_Col_UOESectionStock24, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock24].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��Q�T
            dt.Columns.Add(ct_Col_UOESectionStock25, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock25].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��Q�U
            dt.Columns.Add(ct_Col_UOESectionStock26, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock26].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��Q�V
            dt.Columns.Add(ct_Col_UOESectionStock27, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock27].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��Q�W
            dt.Columns.Add(ct_Col_UOESectionStock28, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock28].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��Q�X
            dt.Columns.Add(ct_Col_UOESectionStock29, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock29].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��R�O
            dt.Columns.Add(ct_Col_UOESectionStock30, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock30].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��R�P
            dt.Columns.Add(ct_Col_UOESectionStock31, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock31].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��R�Q
            dt.Columns.Add(ct_Col_UOESectionStock32, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock32].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��R�R
            dt.Columns.Add(ct_Col_UOESectionStock33, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock33].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��R�S
            dt.Columns.Add(ct_Col_UOESectionStock34, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock34].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ��R�T
            dt.Columns.Add(ct_Col_UOESectionStock35, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock35].DefaultValue = defValueInt32;
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