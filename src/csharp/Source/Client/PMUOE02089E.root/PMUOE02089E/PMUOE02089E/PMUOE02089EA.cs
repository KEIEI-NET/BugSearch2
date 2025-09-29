using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �������M�G���[���X�g�e�[�u���X�L�[�}��`�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������M�G���[���X�g�e�[�u���X�L�[�}�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date       : 2008.12.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class SupplierSendErResult
    {

        /// <summary> �e�[�u������ </summary>
        public const string Col_Tbl_Result_SupplierSendEr = "Tbl_Result_SupplierSendEr";

        /// <summary> �쐬���� </summary>
        public const string Col_CreateDateTime = "CreateDateTime";

        /// <summary> �X�V���� </summary>
        public const string Col_UpdateDateTime = "UpdateDateTime";

        /// <summary> ��ƃR�[�h </summary>
        public const string Col_EnterpriseCode = "EnterpriseCode";

        /// <summary> GUID </summary>
        public const string Col_FileHeaderGuid = "FileHeaderGuid";

        /// <summary> �X�V�]�ƈ��R�[�h </summary>
        public const string Col_UpdEmployeeCode = "UpdEmployeeCode";

        /// <summary> �X�V�A�Z���u��ID1 </summary>
        public const string Col_UpdAssemblyId1 = "UpdAssemblyId1";

        /// <summary> �X�V�A�Z���u��ID2 </summary>
        public const string Col_UpdAssemblyId2 = "UpdAssemblyId2";

        /// <summary> �_���폜�敪 </summary>
        public const string Col_LogicalDeleteCode = "LogicalDeleteCode";

        /// <summary> �V�X�e���敪 </summary>
        public const string Col_SystemDivCd = "SystemDivCd";

        /// <summary> UOE�����ԍ� </summary>
        public const string Col_UOESalesOrderNo = "UOESalesOrderNo";

        /// <summary> UOE�����s�ԍ� </summary>
        public const string Col_UOESalesOrderRowNo = "UOESalesOrderRowNo";

        /// <summary> ���M�[���ԍ� </summary>
        public const string Col_SendTerminalNo = "SendTerminalNo";

        /// <summary> UOE������R�[�h </summary>
        public const string Col_UOESupplierCd = "UOESupplierCd";

        /// <summary> UOE�����於�� </summary>
        public const string Col_UOESupplierName = "UOESupplierName";

        /// <summary> �ʐM�A�Z���u��ID </summary>
        public const string Col_CommAssemblyId = "CommAssemblyId";

        /// <summary> �ʐM�A�Z���u��ID </summary>
        public const string Col_OnlineNo = "OnlineNo";

        /// <summary> �I�����C���s�ԍ� </summary>
        public const string Col_OnlineRowNo = "OnlineRowNo";

        /// <summary> ������t </summary>
        public const string Col_SalesDate = "SalesDate";

        /// <summary> ���͓� </summary>
        public const string Col_InputDay = "InputDay";

        /// <summary> �f�[�^�X�V���� </summary>
        public const string Col_DataUpdateDateTime = "DataUpdateDateTime";

        /// <summary> UOE��� </summary>
        public const string Col_UOEKind = "UOEKind";

        /// <summary> ����`�[�ԍ� </summary>
        public const string Col_SalesSlipNum = "SalesSlipNum";

        /// <summary> �󒍃X�e�[�^�X </summary>
        public const string Col_AcptAnOdrStatus = "AcptAnOdrStatus";

        /// <summary> ���㖾�גʔ� </summary>
        public const string Col_SalesSlipDtlNum = "SalesSlipDtlNum";

        /// <summary> ���_�R�[�h </summary>
        public const string Col_SectionCode = "SectionCode";

        /// <summary> ���_�K�C�h���� </summary>
        public const string Col_SectionGuideSnm = "SectionGuideSnm";

        /// <summary> ����R�[�h </summary>
        public const string Col_SubSectionCode = "SubSectionCode";

        /// <summary> ���Ӑ�R�[�h </summary>
        public const string Col_CustomerCode = "CustomerCode";

        /// <summary> ���Ӑ旪�� </summary>
        public const string Col_CustomerSnm = "CustomerSnm";

        /// <summary> ���W�ԍ� </summary>
        public const string Col_CashRegisterNo = "CashRegisterNo";

        /// <summary> ���ʒʔ� </summary>
        public const string Col_CommonSeqNo = "CommonSeqNo";

        /// <summary> �d���`�� </summary>
        public const string Col_SupplierFormal = "SupplierFormal";

        /// <summary> �d���`�[�ԍ� </summary>
        public const string Col_SupplierSlipNo = "SupplierSlipNo";

        /// <summary> �d�����גʔ� </summary>
        public const string Col_StockSlipDtlNum = "StockSlipDtlNum";

        /// <summary> BO�敪 </summary>
        public const string Col_BoCode = "BoCode";

        /// <summary> UOE�[�i�敪 </summary>
        public const string Col_UOEDeliGoodsDiv = "UOEDeliGoodsDiv";

        /// <summary> �[�i�敪���� </summary>
        public const string Col_DeliveredGoodsDivNm = "DeliveredGoodsDivNm";

        /// <summary> �t�H���[�[�i�敪 </summary>
        public const string Col_FollowDeliGoodsDiv = "FollowDeliGoodsDiv";

        /// <summary> �t�H���[�[�i�敪���� </summary>
        public const string Col_FollowDeliGoodsDivNm = "FollowDeliGoodsDivNm";

        /// <summary> UOE�w�苒�_ </summary>
        public const string Col_UOEResvdSection = "UOEResvdSection";

        /// <summary> UOE�w�苒�_���� </summary>
        public const string Col_UOEResvdSectionNm = "UOEResvdSectionNm";

        /// <summary> �]�ƈ��R�[�h </summary>
        public const string Col_EmployeeCode = "EmployeeCode";

        /// <summary> �]�ƈ����� </summary>
        public const string Col_EmployeeName = "EmployeeName";

        /// <summary> ���i���[�J�[�R�[�h </summary>
        public const string Col_GoodsMakerCd = "GoodsMakerCd";

        /// <summary> ���[�J�[���� </summary>
        public const string Col_MakerName = "MakerName";

        /// <summary> ���i�ԍ� </summary>
        public const string Col_GoodsNo = "GoodsNo";

        /// <summary> �n�C�t�������i�ԍ� </summary>
        public const string Col_GoodsNoNoneHyphen = "GoodsNoNoneHyphen";

        /// <summary> ���i���� </summary>
        public const string Col_GoodsName = "GoodsName";

        /// <summary> �q�ɃR�[�h </summary>
        public const string Col_WarehouseCode = "WarehouseCode";

        /// <summary> �q�ɖ��� </summary>
        public const string Col_WarehouseName = "WarehouseName";

        /// <summary> �q�ɒI�� </summary>
        public const string Col_WarehouseShelfNo = "WarehouseShelfNo";

        /// <summary> �󒍐��� </summary>
        public const string Col_AcceptAnOrderCnt = "AcceptAnOrderCnt";

        /// <summary> �艿�i�����j </summary>
        public const string Col_ListPrice = "ListPrice";

        /// <summary> �����P�� </summary>
        public const string Col_SalesUnitCost = "SalesUnitCost";

        /// <summary> �d����R�[�h </summary>
        public const string Col_SupplierCd = "SupplierCd";

        /// <summary> �d���旪�� </summary>
        public const string Col_SupplierSnm = "SupplierSnm";

        /// <summary> �t�n�d���}�[�N�P </summary>
        public const string Col_UoeRemark1 = "UoeRemark1";

        /// <summary> �t�n�d���}�[�N�Q </summary>
        public const string Col_UoeRemark2 = "UoeRemark2";

        /// <summary> ��M���t </summary>
        public const string Col_ReceiveDate = "ReceiveDate";

        /// <summary> ��M���� </summary>
        public const string Col_ReceiveTime = "ReceiveTime";

        /// <summary> �񓚃��[�J�[�R�[�h </summary>
        public const string Col_AnswerMakerCd = "AnswerMakerCd";

        /// <summary> �񓚕i�� </summary>
        public const string Col_AnswerPartsNo = "AnswerPartsNo";

        /// <summary> �񓚕i�� </summary>
        public const string Col_AnswerPartsName = "AnswerPartsName";

        /// <summary> ��֕i�� </summary>
        public const string Col_SubstPartsNo = "SubstPartsNo";

        /// <summary> UOE���_�o�ɐ� </summary>
        public const string Col_UOESectOutGoodsCnt = "UOESectOutGoodsCnt";

        /// <summary> BO�o�ɐ�1 </summary>
        public const string Col_BOShipmentCnt1 = "BOShipmentCnt1";

        /// <summary> BO�o�ɐ�2 </summary>
        public const string Col_BOShipmentCnt2 = "BOShipmentCnt2";

        /// <summary> BO�o�ɐ�3 </summary>
        public const string Col_BOShipmentCnt3 = "BOShipmentCnt3";

        /// <summary> ���[�J�[�t�H���[�� </summary>
        public const string Col_MakerFollowCnt = "MakerFollowCnt";

        /// <summary> ���o�ɐ� </summary>
        public const string Col_NonShipmentCnt = "NonShipmentCnt";

        /// <summary> UOE���_�݌ɐ� </summary>
        public const string Col_UOESectStockCnt = "UOESectStockCnt";

        /// <summary> BO�݌ɐ�1 </summary>
        public const string Col_BOStockCount1 = "BOStockCount1";

        /// <summary> BO�݌ɐ�2 </summary>
        public const string Col_BOStockCount2 = "BOStockCount2";

        /// <summary> BO�݌ɐ�3 </summary>
        public const string Col_BOStockCount3 = "BOStockCount3";

        /// <summary> UOE���_�`�[�ԍ� </summary>
        public const string Col_UOESectionSlipNo = "UOESectionSlipNo";

        /// <summary> BO�`�[�ԍ��P </summary>
        public const string Col_BOSlipNo1 = "BOSlipNo1";

        /// <summary> BO�`�[�ԍ��Q </summary>
        public const string Col_BOSlipNo2 = "BOSlipNo2";

        /// <summary> BO�`�[�ԍ��R </summary>
        public const string Col_BOSlipNo3 = "BOSlipNo3";

        /// <summary> EO������ </summary>
        public const string Col_EOAlwcCount = "EOAlwcCount";

        /// <summary> BO�Ǘ��ԍ� </summary>
        public const string Col_BOManagementNo = "BOManagementNo";

        /// <summary> �񓚒艿 </summary>
        public const string Col_AnswerListPrice = "AnswerListPrice";

        /// <summary> �񓚌����P�� </summary>
        public const string Col_AnswerSalesUnitCost = "AnswerSalesUnitCost";

        /// <summary> UOE��փ}�[�N </summary>
        public const string Col_UOESubstMark = "UOESubstMark";

        /// <summary> UOE�݌Ƀ}�[�N </summary>
        public const string Col_UOEStockMark = "UOEStockMark";

        /// <summary> �w�ʃR�[�h </summary>
        public const string Col_PartsLayerCd = "PartsLayerCd";

        /// <summary> UOE�o�׋��_�R�[�h�P�i�}�c�_�j </summary>
        public const string Col_MazdaUOEShipSectCd1 = "MazdaUOEShipSectCd1";

        /// <summary> UOE�o�׋��_�R�[�h�Q�i�}�c�_�j </summary>
        public const string Col_MazdaUOEShipSectCd2 = "MazdaUOEShipSectCd2";

        /// <summary> UOE�o�׋��_�R�[�h�R�i�}�c�_�j </summary>
        public const string Col_MazdaUOEShipSectCd3 = "MazdaUOEShipSectCd3";

        /// <summary> UOE���_�R�[�h�P�i�}�c�_�j </summary>
        public const string Col_MazdaUOESectCd1 = "MazdaUOESectCd1";

        /// <summary> UOE���_�R�[�h�Q�i�}�c�_�j </summary>
        public const string Col_MazdaUOESectCd2 = "MazdaUOESectCd2";

        /// <summary> UOE���_�R�[�h�R�i�}�c�_�j </summary>
        public const string Col_MazdaUOESectCd3 = "MazdaUOESectCd3";

        /// <summary> UOE���_�R�[�h�S�i�}�c�_�j </summary>
        public const string Col_MazdaUOESectCd4 = "MazdaUOESectCd4";

        /// <summary> UOE���_�R�[�h�T�i�}�c�_�j </summary>
        public const string Col_MazdaUOESectCd5 = "MazdaUOESectCd5";

        /// <summary> UOE���_�R�[�h�U�i�}�c�_�j </summary>
        public const string Col_MazdaUOESectCd6 = "MazdaUOESectCd6";

        /// <summary> UOE���_�R�[�h�V�i�}�c�_�j </summary>
        public const string Col_MazdaUOESectCd7 = "MazdaUOESectCd7";

        /// <summary> UOE�݌ɐ��P�i�}�c�_�j </summary>
        public const string Col_MazdaUOEStockCnt1 = "MazdaUOEStockCnt1";

        /// <summary> UOE�݌ɐ��Q�i�}�c�_�j </summary>
        public const string Col_MazdaUOEStockCnt2 = "MazdaUOEStockCnt2";

        /// <summary> UOE�݌ɐ��R�i�}�c�_�j </summary>
        public const string Col_MazdaUOEStockCnt3 = "MazdaUOEStockCnt3";

        /// <summary> UOE�݌ɐ��S�i�}�c�_�j </summary>
        public const string Col_MazdaUOEStockCnt4 = "MazdaUOEStockCnt4";

        /// <summary> UOE�݌ɐ��T�i�}�c�_�j </summary>
        public const string Col_MazdaUOEStockCnt5 = "MazdaUOEStockCnt5";

        /// <summary> UOE�݌ɐ��U�i�}�c�_�j </summary>
        public const string Col_MazdaUOEStockCnt6 = "MazdaUOEStockCnt6";

        /// <summary> UOE�݌ɐ��V�i�}�c�_�j </summary>
        public const string Col_MazdaUOEStockCnt7 = "MazdaUOEStockCnt7";

        /// <summary> UOE���R�[�h </summary>
        public const string Col_UOEDistributionCd = "UOEDistributionCd";

        /// <summary> UOE���R�[�h </summary>
        public const string Col_UOEOtherCd = "UOEOtherCd";

        /// <summary> UOE�g�l�R�[�h </summary>
        public const string Col_UOEHMCd = "UOEHMCd";

        /// <summary> �a�n�� </summary>
        public const string Col_BOCount = "BOCount";

        /// <summary> UOE�}�[�N�R�[�h </summary>
        public const string Col_UOEMarkCode = "UOEMarkCode";

        /// <summary> �o�׌� </summary>
        public const string Col_SourceShipment = "SourceShipment";

        /// <summary> �A�C�e���R�[�h </summary>
        public const string Col_ItemCode = "ItemCode";

        /// <summary> UOE�`�F�b�N�R�[�h </summary>
        public const string Col_UOECheckCode = "UOECheckCode";

        /// <summary> �w�b�h�G���[���b�Z�[�W </summary>
        public const string Col_HeadErrorMassage = "HeadErrorMassage";

        /// <summary> ���C���G���[���b�Z�[�W </summary>
        public const string Col_LineErrorMassage = "LineErrorMassage";

        /// <summary> �f�[�^���M�敪 </summary>
        public const string Col_DataSendCode = "DataSendCode";

        /// <summary> �f�[�^�����敪 </summary>
        public const string Col_DataRecoverDiv = "DataRecoverDiv";

        /// <summary> ���ɍX�V�敪�i���_�j </summary>
        public const string Col_EnterUpdDivSec = "EnterUpdDivSec";

        /// <summary> ���ɍX�V�敪�iBO1�j </summary>
        public const string Col_EnterUpdDivBO1 = "EnterUpdDivBO1";

        /// <summary> ���ɍX�V�敪�iBO2�j </summary>
        public const string Col_EnterUpdDivBO2 = "EnterUpdDivBO2";

        /// <summary> ���ɍX�V�敪�iBO3�j </summary>
        public const string Col_EnterUpdDivBO3 = "EnterUpdDivBO3";

        /// <summary> ���ɍX�V�敪�iҰ���j </summary>
        public const string Col_EnterUpdDivMaker = "EnterUpdDivMaker";

        /// <summary> ���ɍX�V�敪�iEO�j </summary>
        public const string Col_EnterUpdDivEO = "EnterUpdDivEO";

        // ����p
        /// <summary> ��M���t(����p) </summary>
        public const string Col_ReceiveDate_Print = "ReceiveDate_Print";

        /// <summary> �V�X�e���敪(����p) </summary>
        public const string Col_SystemDivCd_Print = "SystemDivCd_Print";

        /// <summary>
        /// �������M�G���[���X�g�e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �������M�G���[���X�g�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
		/// <br>Programmer : 30413 ����</br>
		/// <br>Date       : 2008.12.10</br>
		/// </remarks>
        public SupplierSendErResult()
		{
		}

        /// <summary>
		/// DataSet�e�[�u���X�L�[�}�ݒ�
		/// </summary>
		/// <param name="ds">�ݒ�Ώۃf�[�^�Z�b�g</param>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.12.10</br>
        /// </remarks>
        static public void CreateDataTableResultSupplierSendEr(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (ds.Tables.Contains(Col_Tbl_Result_SupplierSendEr))
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[Col_Tbl_Result_SupplierSendEr].Clear();
            }
            else
            {
                // �X�L�[�}�ݒ�
                ds.Tables.Add(Col_Tbl_Result_SupplierSendEr);

                DataTable dt = ds.Tables[Col_Tbl_Result_SupplierSendEr];

                string defValuestring = "";
                Int32 defValueInt32 = 0;
                Int64 defValueInt64 = 0;
                double defValueDouble = 0.0;

                dt.Columns.Add(Col_CreateDateTime, typeof(DateTime));               // �쐬����
                dt.Columns[Col_CreateDateTime].DefaultValue = DateTime.MinValue;

                dt.Columns.Add(Col_UpdateDateTime, typeof(DateTime));               // �X�V����
                dt.Columns[Col_UpdateDateTime].DefaultValue = DateTime.MinValue;

                dt.Columns.Add(Col_EnterpriseCode, typeof(string));                 // ��ƃR�[�h
                dt.Columns[Col_EnterpriseCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_FileHeaderGuid, typeof(Guid));                   // GUID
                dt.Columns[Col_FileHeaderGuid].DefaultValue = Guid.Empty;

                dt.Columns.Add(Col_UpdEmployeeCode, typeof(string));                // �X�V�]�ƈ��R�[�h
                dt.Columns[Col_UpdEmployeeCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UpdAssemblyId1, typeof(string));                 // �X�V�A�Z���u��ID1
                dt.Columns[Col_UpdAssemblyId1].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UpdAssemblyId2, typeof(string));                 // �X�V�A�Z���u��ID2
                dt.Columns[Col_UpdAssemblyId2].DefaultValue = defValuestring;

                dt.Columns.Add(Col_LogicalDeleteCode, typeof(Int32));               // �_���폜�敪
                dt.Columns[Col_LogicalDeleteCode].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_SystemDivCd, typeof(Int32));                     // �V�X�e���敪
                dt.Columns[Col_SystemDivCd].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_UOESalesOrderNo, typeof(Int32));                 // UOE�����ԍ�
                dt.Columns[Col_UOESalesOrderNo].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_UOESalesOrderRowNo, typeof(Int32));              // UOE�����s�ԍ�
                dt.Columns[Col_UOESalesOrderRowNo].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_SendTerminalNo, typeof(Int32));                  // ���M�[���ԍ�
                dt.Columns[Col_SendTerminalNo].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_UOESupplierCd, typeof(Int32));                   // UOE������R�[�h
                dt.Columns[Col_UOESupplierCd].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_UOESupplierName, typeof(string));                // UOE�����於��
                dt.Columns[Col_UOESupplierName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_CommAssemblyId, typeof(string));                 // �ʐM�A�Z���u��ID
                dt.Columns[Col_CommAssemblyId].DefaultValue = defValuestring;

                dt.Columns.Add(Col_OnlineNo, typeof(Int32));                        // �ʐM�A�Z���u��ID
                dt.Columns[Col_OnlineNo].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_OnlineRowNo, typeof(Int32));                     // �I�����C���s�ԍ�
                dt.Columns[Col_OnlineRowNo].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_SalesDate, typeof(DateTime));                    // ������t
                dt.Columns[Col_SalesDate].DefaultValue = DateTime.MinValue;

                dt.Columns.Add(Col_InputDay, typeof(DateTime));                     // ���͓�
                dt.Columns[Col_InputDay].DefaultValue = DateTime.MinValue;

                dt.Columns.Add(Col_DataUpdateDateTime, typeof(DateTime));           // �f�[�^�X�V����
                dt.Columns[Col_DataUpdateDateTime].DefaultValue = DateTime.MinValue;

                dt.Columns.Add(Col_UOEKind, typeof(Int32));                         // UOE���
                dt.Columns[Col_UOEKind].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_SalesSlipNum, typeof(string));                   // ����`�[�ԍ�
                dt.Columns[Col_SalesSlipNum].DefaultValue = defValuestring;

                dt.Columns.Add(Col_AcptAnOdrStatus, typeof(Int32));                 // �󒍃X�e�[�^�X
                dt.Columns[Col_AcptAnOdrStatus].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_SalesSlipDtlNum, typeof(Int64));                 // ���㖾�גʔ�
                dt.Columns[Col_SalesSlipDtlNum].DefaultValue = defValueInt64;

                dt.Columns.Add(Col_SectionCode, typeof(string));                    // ���_�R�[�h
                dt.Columns[Col_SectionCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SectionGuideSnm, typeof(string));                // ���_�K�C�h����
                dt.Columns[Col_SectionGuideSnm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SubSectionCode, typeof(Int32));                  // ����R�[�h
                dt.Columns[Col_SubSectionCode].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_CustomerCode, typeof(Int32));                    // ���Ӑ�R�[�h
                dt.Columns[Col_CustomerCode].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_CustomerSnm, typeof(string));                    // ���Ӑ旪��
                dt.Columns[Col_CustomerSnm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_CashRegisterNo, typeof(Int32));                  // ���W�ԍ�
                dt.Columns[Col_CashRegisterNo].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_CommonSeqNo, typeof(Int64));                     // ���ʒʔ�
                dt.Columns[Col_CommonSeqNo].DefaultValue = defValueInt64;

                dt.Columns.Add(Col_SupplierFormal, typeof(Int32));                  // �d���`��
                dt.Columns[Col_SupplierFormal].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_SupplierSlipNo, typeof(Int32));                  // �d���`�[�ԍ�
                dt.Columns[Col_SupplierSlipNo].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_StockSlipDtlNum, typeof(Int64));                 // �d�����גʔ�
                dt.Columns[Col_StockSlipDtlNum].DefaultValue = defValueInt64;

                dt.Columns.Add(Col_BoCode, typeof(string));                         // BO�敪
                dt.Columns[Col_BoCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UOEDeliGoodsDiv, typeof(string));                // UOE�[�i�敪
                dt.Columns[Col_UOEDeliGoodsDiv].DefaultValue = defValuestring;

                dt.Columns.Add(Col_DeliveredGoodsDivNm, typeof(string));            // �[�i�敪����
                dt.Columns[Col_DeliveredGoodsDivNm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_FollowDeliGoodsDiv, typeof(string));             // �t�H���[�[�i�敪
                dt.Columns[Col_FollowDeliGoodsDiv].DefaultValue = defValuestring;

                dt.Columns.Add(Col_FollowDeliGoodsDivNm, typeof(string));           // �t�H���[�[�i�敪����
                dt.Columns[Col_FollowDeliGoodsDivNm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UOEResvdSection, typeof(string));                // UOE�w�苒�_
                dt.Columns[Col_UOEResvdSection].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UOEResvdSectionNm, typeof(string));              // UOE�w�苒�_����
                dt.Columns[Col_UOEResvdSectionNm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_EmployeeCode, typeof(string));                   // �]�ƈ��R�[�h
                dt.Columns[Col_EmployeeCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_EmployeeName, typeof(string));                   // �]�ƈ�����
                dt.Columns[Col_EmployeeName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsMakerCd, typeof(Int32));                    // ���i���[�J�[�R�[�h
                dt.Columns[Col_GoodsMakerCd].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_MakerName, typeof(string));                      // ���[�J�[����
                dt.Columns[Col_MakerName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsNo, typeof(string));                        // ���i�ԍ�
                dt.Columns[Col_GoodsNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsNoNoneHyphen, typeof(string));              // �n�C�t�������i�ԍ�
                dt.Columns[Col_GoodsNoNoneHyphen].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsName, typeof(string));                      // ���i����
                dt.Columns[Col_GoodsName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_WarehouseCode, typeof(string));                  // �q�ɃR�[�h
                dt.Columns[Col_WarehouseCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_WarehouseName, typeof(string));                  // �q�ɖ���
                dt.Columns[Col_WarehouseName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_WarehouseShelfNo, typeof(string));               // �q�ɒI��
                dt.Columns[Col_WarehouseShelfNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_AcceptAnOrderCnt, typeof(Double));               // �󒍐���
                dt.Columns[Col_AcceptAnOrderCnt].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_ListPrice, typeof(Double));                      // �艿�i�����j
                dt.Columns[Col_ListPrice].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_SalesUnitCost, typeof(Double));                  // �����P��
                dt.Columns[Col_SalesUnitCost].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_SupplierCd, typeof(Int32));                      // �d����R�[�h
                dt.Columns[Col_SupplierCd].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_SupplierSnm, typeof(string));                    // �d���旪��
                dt.Columns[Col_SupplierSnm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UoeRemark1, typeof(string));                     // �t�n�d���}�[�N�P
                dt.Columns[Col_UoeRemark1].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UoeRemark2, typeof(string));                     // �t�n�d���}�[�N�Q
                dt.Columns[Col_UoeRemark2].DefaultValue = defValuestring;

                dt.Columns.Add(Col_ReceiveDate, typeof(DateTime));                  // ��M���t
                dt.Columns[Col_ReceiveDate].DefaultValue = DateTime.MinValue;

                dt.Columns.Add(Col_ReceiveTime, typeof(Int32));                     // ��M����
                dt.Columns[Col_ReceiveTime].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_AnswerMakerCd, typeof(Int32));                   // �񓚃��[�J�[�R�[�h
                dt.Columns[Col_AnswerMakerCd].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_AnswerPartsNo, typeof(string));                  // �񓚕i��
                dt.Columns[Col_AnswerPartsNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_AnswerPartsName, typeof(string));                // �񓚕i��
                dt.Columns[Col_AnswerPartsName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SubstPartsNo, typeof(string));                   // ��֕i��
                dt.Columns[Col_SubstPartsNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UOESectOutGoodsCnt, typeof(Int32));              // UOE���_�o�ɐ�
                dt.Columns[Col_UOESectOutGoodsCnt].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BOShipmentCnt1, typeof(Int32));                  // BO�o�ɐ�1
                dt.Columns[Col_BOShipmentCnt1].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BOShipmentCnt2, typeof(Int32));                  // BO�o�ɐ�2
                dt.Columns[Col_BOShipmentCnt2].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BOShipmentCnt3, typeof(Int32));                  // BO�o�ɐ�3
                dt.Columns[Col_BOShipmentCnt3].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_MakerFollowCnt, typeof(Int32));                  // ���[�J�[�t�H���[��
                dt.Columns[Col_MakerFollowCnt].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_NonShipmentCnt, typeof(Int32));                  // ���o�ɐ�
                dt.Columns[Col_NonShipmentCnt].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_UOESectStockCnt, typeof(Int32));                 // UOE���_�݌ɐ�
                dt.Columns[Col_UOESectStockCnt].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BOStockCount1, typeof(Int32));                   // BO�݌ɐ�1
                dt.Columns[Col_BOStockCount1].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BOStockCount2, typeof(Int32));                   // BO�݌ɐ�2
                dt.Columns[Col_BOStockCount2].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BOStockCount3, typeof(Int32));                   // BO�݌ɐ�3
                dt.Columns[Col_BOStockCount3].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_UOESectionSlipNo, typeof(string));               // UOE���_�`�[�ԍ�
                dt.Columns[Col_UOESectionSlipNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_BOSlipNo1, typeof(string));                      // BO�`�[�ԍ��P
                dt.Columns[Col_BOSlipNo1].DefaultValue = defValuestring;

                dt.Columns.Add(Col_BOSlipNo2, typeof(string));                      // BO�`�[�ԍ��Q
                dt.Columns[Col_BOSlipNo2].DefaultValue = defValuestring;

                dt.Columns.Add(Col_BOSlipNo3, typeof(string));                      // BO�`�[�ԍ��R
                dt.Columns[Col_BOSlipNo3].DefaultValue = defValuestring;

                dt.Columns.Add(Col_EOAlwcCount, typeof(Int32));                     // EO������
                dt.Columns[Col_EOAlwcCount].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BOManagementNo, typeof(string));                 // BO�Ǘ��ԍ�
                dt.Columns[Col_BOManagementNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_AnswerListPrice, typeof(Double));                // �񓚒艿
                dt.Columns[Col_AnswerListPrice].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_AnswerSalesUnitCost, typeof(Double));            // �񓚌����P��
                dt.Columns[Col_AnswerSalesUnitCost].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_UOESubstMark, typeof(string));                   // UOE��փ}�[�N
                dt.Columns[Col_UOESubstMark].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UOEStockMark, typeof(string));                   // UOE�݌Ƀ}�[�N
                dt.Columns[Col_UOEStockMark].DefaultValue = defValuestring;

                dt.Columns.Add(Col_PartsLayerCd, typeof(string));                   // �w�ʃR�[�h
                dt.Columns[Col_PartsLayerCd].DefaultValue = defValuestring;

                dt.Columns.Add(Col_MazdaUOEShipSectCd1, typeof(string));            // UOE�o�׋��_�R�[�h�P�i�}�c�_�j
                dt.Columns[Col_MazdaUOEShipSectCd1].DefaultValue = defValuestring;

                dt.Columns.Add(Col_MazdaUOEShipSectCd2, typeof(string));            // UOE�o�׋��_�R�[�h�Q�i�}�c�_�j
                dt.Columns[Col_MazdaUOEShipSectCd2].DefaultValue = defValuestring;

                dt.Columns.Add(Col_MazdaUOEShipSectCd3, typeof(string));            // UOE�o�׋��_�R�[�h�R�i�}�c�_�j
                dt.Columns[Col_MazdaUOEShipSectCd3].DefaultValue = defValuestring;

                dt.Columns.Add(Col_MazdaUOESectCd1, typeof(string));                // UOE���_�R�[�h�P�i�}�c�_�j
                dt.Columns[Col_MazdaUOESectCd1].DefaultValue = defValuestring;

                dt.Columns.Add(Col_MazdaUOESectCd2, typeof(string));                // UOE���_�R�[�h�Q�i�}�c�_�j
                dt.Columns[Col_MazdaUOESectCd2].DefaultValue = defValuestring;

                dt.Columns.Add(Col_MazdaUOESectCd3, typeof(string));                // UOE���_�R�[�h�R�i�}�c�_�j
                dt.Columns[Col_MazdaUOESectCd3].DefaultValue = defValuestring;

                dt.Columns.Add(Col_MazdaUOESectCd4, typeof(string));                // UOE���_�R�[�h�S�i�}�c�_�j
                dt.Columns[Col_MazdaUOESectCd4].DefaultValue = defValuestring;

                dt.Columns.Add(Col_MazdaUOESectCd5, typeof(string));                // UOE���_�R�[�h�T�i�}�c�_�j
                dt.Columns[Col_MazdaUOESectCd5].DefaultValue = defValuestring;

                dt.Columns.Add(Col_MazdaUOESectCd6, typeof(string));                // UOE���_�R�[�h�U�i�}�c�_�j
                dt.Columns[Col_MazdaUOESectCd6].DefaultValue = defValuestring;

                dt.Columns.Add(Col_MazdaUOESectCd7, typeof(string));                // UOE���_�R�[�h�V�i�}�c�_�j
                dt.Columns[Col_MazdaUOESectCd7].DefaultValue = defValuestring;

                dt.Columns.Add(Col_MazdaUOEStockCnt1, typeof(Int32));               // UOE�݌ɐ��P�i�}�c�_�j
                dt.Columns[Col_MazdaUOEStockCnt1].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_MazdaUOEStockCnt2, typeof(Int32));               // UOE�݌ɐ��Q�i�}�c�_�j
                dt.Columns[Col_MazdaUOEStockCnt2].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_MazdaUOEStockCnt3, typeof(Int32));               // UOE�݌ɐ��R�i�}�c�_�j
                dt.Columns[Col_MazdaUOEStockCnt3].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_MazdaUOEStockCnt4, typeof(Int32));               // UOE�݌ɐ��S�i�}�c�_�j
                dt.Columns[Col_MazdaUOEStockCnt4].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_MazdaUOEStockCnt5, typeof(Int32));               // UOE�݌ɐ��T�i�}�c�_�j
                dt.Columns[Col_MazdaUOEStockCnt5].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_MazdaUOEStockCnt6, typeof(Int32));               // UOE�݌ɐ��U�i�}�c�_�j
                dt.Columns[Col_MazdaUOEStockCnt6].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_MazdaUOEStockCnt7, typeof(Int32));               // UOE�݌ɐ��V�i�}�c�_�j
                dt.Columns[Col_MazdaUOEStockCnt7].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_UOEDistributionCd, typeof(string));              // UOE���R�[�h
                dt.Columns[Col_UOEDistributionCd].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UOEOtherCd, typeof(string));                     // UOE���R�[�h
                dt.Columns[Col_UOEOtherCd].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UOEHMCd, typeof(string));                        // UOE�g�l�R�[�h
                dt.Columns[Col_UOEHMCd].DefaultValue = defValuestring;

                dt.Columns.Add(Col_BOCount, typeof(Int32));                         // �a�n��
                dt.Columns[Col_BOCount].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_UOEMarkCode, typeof(string));                    // UOE�}�[�N�R�[�h
                dt.Columns[Col_UOEMarkCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SourceShipment, typeof(string));                 // �o�׌�
                dt.Columns[Col_SourceShipment].DefaultValue = defValuestring;

                dt.Columns.Add(Col_ItemCode, typeof(string));                       // �A�C�e���R�[�h
                dt.Columns[Col_ItemCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UOECheckCode, typeof(string));                   // UOE�`�F�b�N�R�[�h
                dt.Columns[Col_UOECheckCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_HeadErrorMassage, typeof(string));               // �w�b�h�G���[���b�Z�[�W
                dt.Columns[Col_HeadErrorMassage].DefaultValue = defValuestring;

                dt.Columns.Add(Col_LineErrorMassage, typeof(string));               // ���C���G���[���b�Z�[�W
                dt.Columns[Col_LineErrorMassage].DefaultValue = defValuestring;

                dt.Columns.Add(Col_DataSendCode, typeof(Int32));                    // �f�[�^���M�敪
                dt.Columns[Col_DataSendCode].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_DataRecoverDiv, typeof(Int32));                  // �f�[�^�����敪
                dt.Columns[Col_DataRecoverDiv].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_EnterUpdDivSec, typeof(Int32));                  // ���ɍX�V�敪�i���_�j
                dt.Columns[Col_EnterUpdDivSec].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_EnterUpdDivBO1, typeof(Int32));                  // ���ɍX�V�敪�iBO1�j
                dt.Columns[Col_EnterUpdDivBO1].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_EnterUpdDivBO2, typeof(Int32));                  // ���ɍX�V�敪�iBO2�j
                dt.Columns[Col_EnterUpdDivBO2].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_EnterUpdDivBO3, typeof(Int32));                  // ���ɍX�V�敪�iBO3�j
                dt.Columns[Col_EnterUpdDivBO3].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_EnterUpdDivMaker, typeof(Int32));                // ���ɍX�V�敪�iҰ���j
                dt.Columns[Col_EnterUpdDivMaker].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_EnterUpdDivEO, typeof(Int32));                   // ���ɍX�V�敪�iEO�j
                dt.Columns[Col_EnterUpdDivEO].DefaultValue = defValueInt32;

                // ����p
                dt.Columns.Add(Col_ReceiveDate_Print, typeof(string));              // ��M���t(����p)
                dt.Columns[Col_ReceiveDate_Print].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SystemDivCd_Print, typeof(string));              // �V�X�e���敪(����p)
                dt.Columns[Col_SystemDivCd_Print].DefaultValue = defValuestring;

            }
        }
    }
}
