//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d�����f�[�^�e�[�u���X�L�[�}�N���X
// �v���O�����T�v   : �t�n�d�����f�[�^�e�[�u����`���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : �Ɠc �M�u
// �� �� ��  2008/12/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �t�n�d�����f�[�^�e�[�u���X�L�[�}�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �t�n�d�������o���ʃe�[�u���X�L�[�}</br>
    /// <br>Programmer : �Ɠc �M�u</br>
    /// <br>Date       : 2008/12/01</br>
    /// </remarks>
    public class UOEOrderDtlSchema
    {
        #region Public Members
        /// <summary>�t�n�d�����f�[�^�e�[�u����</summary>
        public const string CT_SendUOEOrderDtlDataTable = "SendUOEOrderDtlDataTable";

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
        /// <summary> UOE���_�o�ɐ� </summary>
        public const string ct_Col_UOESectOutGoodsCnt = "UOESectOutGoodsCnt";
        /// <summary> BO�o�ɐ�1 </summary>
        public const string ct_Col_BOShipmentCnt1 = "BOShipmentCnt1";
        /// <summary> BO�o�ɐ�2 </summary>
        public const string ct_Col_BOShipmentCnt2 = "BOShipmentCnt2";
        /// <summary> BO�o�ɐ�3 </summary>
        public const string ct_Col_BOShipmentCnt3 = "BOShipmentCnt3";
        /// <summary> ���[�J�[�t�H���[�� </summary>
        public const string ct_Col_MakerFollowCnt = "MakerFollowCnt";
        /// <summary> ���o�ɐ� </summary>
        public const string ct_Col_NonShipmentCnt = "NonShipmentCnt";
        /// <summary> UOE���_�݌ɐ� </summary>
        public const string ct_Col_UOESectStockCnt = "UOESectStockCnt";
        /// <summary> BO�݌ɐ�1 </summary>
        public const string ct_Col_BOStockCount1 = "BOStockCount1";
        /// <summary> BO�݌ɐ�2 </summary>
        public const string ct_Col_BOStockCount2 = "BOStockCount2";
        /// <summary> BO�݌ɐ�3 </summary>
        public const string ct_Col_BOStockCount3 = "BOStockCount3";
        /// <summary> UOE���_�`�[�ԍ� </summary>
        public const string ct_Col_UOESectionSlipNo = "UOESectionSlipNo";
        /// <summary> BO�`�[�ԍ��P </summary>
        public const string ct_Col_BOSlipNo1 = "BOSlipNo1";
        /// <summary> BO�`�[�ԍ��Q </summary>
        public const string ct_Col_BOSlipNo2 = "BOSlipNo2";
        /// <summary> BO�`�[�ԍ��R </summary>
        public const string ct_Col_BOSlipNo3 = "BOSlipNo3";
        /// <summary> EO������ </summary>
        public const string ct_Col_EOAlwcCount = "EOAlwcCount";
        /// <summary> BO�Ǘ��ԍ� </summary>
        public const string ct_Col_BOManagementNo = "BOManagementNo";
        /// <summary> �񓚒艿 </summary>
        public const string ct_Col_AnswerListPrice = "AnswerListPrice";
        /// <summary> �񓚌����P�� </summary>
        public const string ct_Col_AnswerSalesUnitCost = "AnswerSalesUnitCost";
        /// <summary> UOE��փ}�[�N </summary>
        public const string ct_Col_UOESubstMark = "UOESubstMark";
        /// <summary> UOE�݌Ƀ}�[�N </summary>
        public const string ct_Col_UOEStockMark = "UOEStockMark";
        /// <summary> �w�ʃR�[�h </summary>
        public const string ct_Col_PartsLayerCd = "PartsLayerCd";
        /// <summary> UOE�o�׋��_�R�[�h�P�i�}�c�_�j </summary>
        public const string ct_Col_MazdaUOEShipSectCd1 = "MazdaUOEShipSectCd1";
        /// <summary> UOE�o�׋��_�R�[�h�Q�i�}�c�_�j </summary>
        public const string ct_Col_MazdaUOEShipSectCd2 = "MazdaUOEShipSectCd2";
        /// <summary> UOE�o�׋��_�R�[�h�R�i�}�c�_�j </summary>
        public const string ct_Col_MazdaUOEShipSectCd3 = "MazdaUOEShipSectCd3";
        /// <summary> UOE���_�R�[�h�P�i�}�c�_�j </summary>
        public const string ct_Col_MazdaUOESectCd1 = "MazdaUOESectCd1";
        /// <summary> UOE���_�R�[�h�Q�i�}�c�_�j </summary>
        public const string ct_Col_MazdaUOESectCd2 = "MazdaUOESectCd2";
        /// <summary> UOE���_�R�[�h�R�i�}�c�_�j </summary>
        public const string ct_Col_MazdaUOESectCd3 = "MazdaUOESectCd3";
        /// <summary> UOE���_�R�[�h�S�i�}�c�_�j </summary>
        public const string ct_Col_MazdaUOESectCd4 = "MazdaUOESectCd4";
        /// <summary> UOE���_�R�[�h�T�i�}�c�_�j </summary>
        public const string ct_Col_MazdaUOESectCd5 = "MazdaUOESectCd5";
        /// <summary> UOE���_�R�[�h�U�i�}�c�_�j </summary>
        public const string ct_Col_MazdaUOESectCd6 = "MazdaUOESectCd6";
        /// <summary> UOE���_�R�[�h�V�i�}�c�_�j </summary>
        public const string ct_Col_MazdaUOESectCd7 = "MazdaUOESectCd7";
        /// <summary> UOE�݌ɐ��P�i�}�c�_�j </summary>
        public const string ct_Col_MazdaUOEStockCnt1 = "MazdaUOEStockCnt1";
        /// <summary> UOE�݌ɐ��Q�i�}�c�_�j </summary>
        public const string ct_Col_MazdaUOEStockCnt2 = "MazdaUOEStockCnt2";
        /// <summary> UOE�݌ɐ��R�i�}�c�_�j </summary>
        public const string ct_Col_MazdaUOEStockCnt3 = "MazdaUOEStockCnt3";
        /// <summary> UOE�݌ɐ��S�i�}�c�_�j </summary>
        public const string ct_Col_MazdaUOEStockCnt4 = "MazdaUOEStockCnt4";
        /// <summary> UOE�݌ɐ��T�i�}�c�_�j </summary>
        public const string ct_Col_MazdaUOEStockCnt5 = "MazdaUOEStockCnt5";
        /// <summary> UOE�݌ɐ��U�i�}�c�_�j </summary>
        public const string ct_Col_MazdaUOEStockCnt6 = "MazdaUOEStockCnt6";
        /// <summary> UOE�݌ɐ��V�i�}�c�_�j </summary>
        public const string ct_Col_MazdaUOEStockCnt7 = "MazdaUOEStockCnt7";
        /// <summary> UOE���R�[�h </summary>
        public const string ct_Col_UOEDistributionCd = "UOEDistributionCd";
        /// <summary> UOE���R�[�h </summary>
        public const string ct_Col_UOEOtherCd = "UOEOtherCd";
        /// <summary> UOE�g�l�R�[�h </summary>
        public const string ct_Col_UOEHMCd = "UOEHMCd";
        /// <summary> �a�n�� </summary>
        public const string ct_Col_BOCount = "BOCount";
        /// <summary> UOE�}�[�N�R�[�h </summary>
        public const string ct_Col_UOEMarkCode = "UOEMarkCode";
        /// <summary> �o�׌� </summary>
        public const string ct_Col_SourceShipment = "SourceShipment";
        /// <summary> �A�C�e���R�[�h </summary>
        public const string ct_Col_ItemCode = "ItemCode";
        /// <summary> UOE�`�F�b�N�R�[�h </summary>
        public const string ct_Col_UOECheckCode = "UOECheckCode";
        /// <summary> �w�b�h�G���[���b�Z�[�W </summary>
        public const string ct_Col_HeadErrorMassage = "HeadErrorMassage";
        /// <summary> ���C���G���[���b�Z�[�W </summary>
        public const string ct_Col_LineErrorMassage = "LineErrorMassage";
        /// <summary> �f�[�^���M�敪 </summary>
        public const string ct_Col_DataSendCode = "DataSendCode";
        /// <summary> �f�[�^�����敪 </summary>
        public const string ct_Col_DataRecoverDiv = "DataRecoverDiv";
        /// <summary> ���ɍX�V�敪�i���_�j </summary>
        public const string ct_Col_EnterUpdDivSec = "EnterUpdDivSec";
        /// <summary> ���ɍX�V�敪�iBO1�j </summary>
        public const string ct_Col_EnterUpdDivBO1 = "EnterUpdDivBO1";
        /// <summary> ���ɍX�V�敪�iBO2�j </summary>
        public const string ct_Col_EnterUpdDivBO2 = "EnterUpdDivBO2";
        /// <summary> ���ɍX�V�敪�iBO3�j </summary>
        public const string ct_Col_EnterUpdDivBO3 = "EnterUpdDivBO3";
        /// <summary> ���ɍX�V�敪�iҰ���j </summary>
        public const string ct_Col_EnterUpdDivMaker = "EnterUpdDivMaker";
        /// <summary> ���ɍX�V�敪�iEO�j </summary>
        public const string ct_Col_EnterUpdDivEO = "EnterUpdDivEO";
        /// <summary> ���׊֘A�t��GUID </summary>
        public const string ct_Col_DtlRelationGuid = "DtlRelationGuid";
        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// �t�n�d�����f�[�^�e�[�u���X�L�[�}�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t�n�d�����f�[�^�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/12/01</br>
        /// </remarks>
        public UOEOrderDtlSchema()
        {
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// �f�[�^�Z�b�g�A�f�[�^�e�[�u���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/12/01</br>
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
        /// �t�n�d�����쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/12/01</br>
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
            // UOE���_�o�ɐ�
            dt.Columns.Add(ct_Col_UOESectOutGoodsCnt, typeof(Int32));
            dt.Columns[ct_Col_UOESectOutGoodsCnt].DefaultValue = defValueInt32;
            // BO�o�ɐ�1
            dt.Columns.Add(ct_Col_BOShipmentCnt1, typeof(Int32));
            dt.Columns[ct_Col_BOShipmentCnt1].DefaultValue = defValueInt32;
            // BO�o�ɐ�2
            dt.Columns.Add(ct_Col_BOShipmentCnt2, typeof(Int32));
            dt.Columns[ct_Col_BOShipmentCnt2].DefaultValue = defValueInt32;
            // BO�o�ɐ�3
            dt.Columns.Add(ct_Col_BOShipmentCnt3, typeof(Int32));
            dt.Columns[ct_Col_BOShipmentCnt3].DefaultValue = defValueInt32;
            // ���[�J�[�t�H���[��
            dt.Columns.Add(ct_Col_MakerFollowCnt, typeof(Int32));
            dt.Columns[ct_Col_MakerFollowCnt].DefaultValue = defValueInt32;
            // ���o�ɐ�
            dt.Columns.Add(ct_Col_NonShipmentCnt, typeof(Int32));
            dt.Columns[ct_Col_NonShipmentCnt].DefaultValue = defValueInt32;
            // UOE���_�݌ɐ�
            dt.Columns.Add(ct_Col_UOESectStockCnt, typeof(Int32));
            dt.Columns[ct_Col_UOESectStockCnt].DefaultValue = defValueInt32;
            // BO�݌ɐ�1
            dt.Columns.Add(ct_Col_BOStockCount1, typeof(Int32));
            dt.Columns[ct_Col_BOStockCount1].DefaultValue = defValueInt32;
            // BO�݌ɐ�2
            dt.Columns.Add(ct_Col_BOStockCount2, typeof(Int32));
            dt.Columns[ct_Col_BOStockCount2].DefaultValue = defValueInt32;
            // BO�݌ɐ�3
            dt.Columns.Add(ct_Col_BOStockCount3, typeof(Int32));
            dt.Columns[ct_Col_BOStockCount3].DefaultValue = defValueInt32;
            // UOE���_�`�[�ԍ�
            dt.Columns.Add(ct_Col_UOESectionSlipNo, typeof(string));
            dt.Columns[ct_Col_UOESectionSlipNo].DefaultValue = defValuestring;
            // BO�`�[�ԍ��P
            dt.Columns.Add(ct_Col_BOSlipNo1, typeof(string));
            dt.Columns[ct_Col_BOSlipNo1].DefaultValue = defValuestring;
            // BO�`�[�ԍ��Q
            dt.Columns.Add(ct_Col_BOSlipNo2, typeof(string));
            dt.Columns[ct_Col_BOSlipNo2].DefaultValue = defValuestring;
            // BO�`�[�ԍ��R
            dt.Columns.Add(ct_Col_BOSlipNo3, typeof(string));
            dt.Columns[ct_Col_BOSlipNo3].DefaultValue = defValuestring;
            // EO������
            dt.Columns.Add(ct_Col_EOAlwcCount, typeof(Int32));
            dt.Columns[ct_Col_EOAlwcCount].DefaultValue = defValueInt32;
            // BO�Ǘ��ԍ�
            dt.Columns.Add(ct_Col_BOManagementNo, typeof(string));
            dt.Columns[ct_Col_BOManagementNo].DefaultValue = defValuestring;
            // �񓚒艿
            dt.Columns.Add(ct_Col_AnswerListPrice, typeof(Double));
            dt.Columns[ct_Col_AnswerListPrice].DefaultValue = defValueDouble;
            // �񓚌����P��
            dt.Columns.Add(ct_Col_AnswerSalesUnitCost, typeof(Double));
            dt.Columns[ct_Col_AnswerSalesUnitCost].DefaultValue = defValueDouble;
            // UOE��փ}�[�N
            dt.Columns.Add(ct_Col_UOESubstMark, typeof(string));
            dt.Columns[ct_Col_UOESubstMark].DefaultValue = defValuestring;
            // UOE�݌Ƀ}�[�N
            dt.Columns.Add(ct_Col_UOEStockMark, typeof(string));
            dt.Columns[ct_Col_UOEStockMark].DefaultValue = defValuestring;
            // �w�ʃR�[�h
            dt.Columns.Add(ct_Col_PartsLayerCd, typeof(string));
            dt.Columns[ct_Col_PartsLayerCd].DefaultValue = defValuestring;
            // UOE�o�׋��_�R�[�h�P�i�}�c�_�j
            dt.Columns.Add(ct_Col_MazdaUOEShipSectCd1, typeof(string));
            dt.Columns[ct_Col_MazdaUOEShipSectCd1].DefaultValue = defValuestring;
            // UOE�o�׋��_�R�[�h�Q�i�}�c�_�j
            dt.Columns.Add(ct_Col_MazdaUOEShipSectCd2, typeof(string));
            dt.Columns[ct_Col_MazdaUOEShipSectCd2].DefaultValue = defValuestring;
            // UOE�o�׋��_�R�[�h�R�i�}�c�_�j
            dt.Columns.Add(ct_Col_MazdaUOEShipSectCd3, typeof(string));
            dt.Columns[ct_Col_MazdaUOEShipSectCd3].DefaultValue = defValuestring;
            // UOE���_�R�[�h�P�i�}�c�_�j
            dt.Columns.Add(ct_Col_MazdaUOESectCd1, typeof(string));
            dt.Columns[ct_Col_MazdaUOESectCd1].DefaultValue = defValuestring;
            // UOE���_�R�[�h�Q�i�}�c�_�j
            dt.Columns.Add(ct_Col_MazdaUOESectCd2, typeof(string));
            dt.Columns[ct_Col_MazdaUOESectCd2].DefaultValue = defValuestring;
            // UOE���_�R�[�h�R�i�}�c�_�j
            dt.Columns.Add(ct_Col_MazdaUOESectCd3, typeof(string));
            dt.Columns[ct_Col_MazdaUOESectCd3].DefaultValue = defValuestring;
            // UOE���_�R�[�h�S�i�}�c�_�j
            dt.Columns.Add(ct_Col_MazdaUOESectCd4, typeof(string));
            dt.Columns[ct_Col_MazdaUOESectCd4].DefaultValue = defValuestring;
            // UOE���_�R�[�h�T�i�}�c�_�j
            dt.Columns.Add(ct_Col_MazdaUOESectCd5, typeof(string));
            dt.Columns[ct_Col_MazdaUOESectCd5].DefaultValue = defValuestring;
            // UOE���_�R�[�h�U�i�}�c�_�j
            dt.Columns.Add(ct_Col_MazdaUOESectCd6, typeof(string));
            dt.Columns[ct_Col_MazdaUOESectCd6].DefaultValue = defValuestring;
            // UOE���_�R�[�h�V�i�}�c�_�j
            dt.Columns.Add(ct_Col_MazdaUOESectCd7, typeof(string));
            dt.Columns[ct_Col_MazdaUOESectCd7].DefaultValue = defValuestring;
            // UOE�݌ɐ��P�i�}�c�_�j
            dt.Columns.Add(ct_Col_MazdaUOEStockCnt1, typeof(Int32));
            dt.Columns[ct_Col_MazdaUOEStockCnt1].DefaultValue = defValueInt32;
            // UOE�݌ɐ��Q�i�}�c�_�j
            dt.Columns.Add(ct_Col_MazdaUOEStockCnt2, typeof(Int32));
            dt.Columns[ct_Col_MazdaUOEStockCnt2].DefaultValue = defValueInt32;
            // UOE�݌ɐ��R�i�}�c�_�j
            dt.Columns.Add(ct_Col_MazdaUOEStockCnt3, typeof(Int32));
            dt.Columns[ct_Col_MazdaUOEStockCnt3].DefaultValue = defValueInt32;
            // UOE�݌ɐ��S�i�}�c�_�j
            dt.Columns.Add(ct_Col_MazdaUOEStockCnt4, typeof(Int32));
            dt.Columns[ct_Col_MazdaUOEStockCnt4].DefaultValue = defValueInt32;
            // UOE�݌ɐ��T�i�}�c�_�j
            dt.Columns.Add(ct_Col_MazdaUOEStockCnt5, typeof(Int32));
            dt.Columns[ct_Col_MazdaUOEStockCnt5].DefaultValue = defValueInt32;
            // UOE�݌ɐ��U�i�}�c�_�j
            dt.Columns.Add(ct_Col_MazdaUOEStockCnt6, typeof(Int32));
            dt.Columns[ct_Col_MazdaUOEStockCnt6].DefaultValue = defValueInt32;
            // UOE�݌ɐ��V�i�}�c�_�j
            dt.Columns.Add(ct_Col_MazdaUOEStockCnt7, typeof(Int32));
            dt.Columns[ct_Col_MazdaUOEStockCnt7].DefaultValue = defValueInt32;
            // UOE���R�[�h
            dt.Columns.Add(ct_Col_UOEDistributionCd, typeof(string));
            dt.Columns[ct_Col_UOEDistributionCd].DefaultValue = defValuestring;
            // UOE���R�[�h
            dt.Columns.Add(ct_Col_UOEOtherCd, typeof(string));
            dt.Columns[ct_Col_UOEOtherCd].DefaultValue = defValuestring;
            // UOE�g�l�R�[�h
            dt.Columns.Add(ct_Col_UOEHMCd, typeof(string));
            dt.Columns[ct_Col_UOEHMCd].DefaultValue = defValuestring;
            // �a�n��
            dt.Columns.Add(ct_Col_BOCount, typeof(Int32));
            dt.Columns[ct_Col_BOCount].DefaultValue = defValueInt32;
            // UOE�}�[�N�R�[�h
            dt.Columns.Add(ct_Col_UOEMarkCode, typeof(string));
            dt.Columns[ct_Col_UOEMarkCode].DefaultValue = defValuestring;
            // �o�׌�
            dt.Columns.Add(ct_Col_SourceShipment, typeof(string));
            dt.Columns[ct_Col_SourceShipment].DefaultValue = defValuestring;
            // �A�C�e���R�[�h
            dt.Columns.Add(ct_Col_ItemCode, typeof(string));
            dt.Columns[ct_Col_ItemCode].DefaultValue = defValuestring;
            // UOE�`�F�b�N�R�[�h
            dt.Columns.Add(ct_Col_UOECheckCode, typeof(string));
            dt.Columns[ct_Col_UOECheckCode].DefaultValue = defValuestring;
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
            // ���ɍX�V�敪�i���_�j
            dt.Columns.Add(ct_Col_EnterUpdDivSec, typeof(Int32));
            dt.Columns[ct_Col_EnterUpdDivSec].DefaultValue = defValueInt32;
            // ���ɍX�V�敪�iBO1�j
            dt.Columns.Add(ct_Col_EnterUpdDivBO1, typeof(Int32));
            dt.Columns[ct_Col_EnterUpdDivBO1].DefaultValue = defValueInt32;
            // ���ɍX�V�敪�iBO2�j
            dt.Columns.Add(ct_Col_EnterUpdDivBO2, typeof(Int32));
            dt.Columns[ct_Col_EnterUpdDivBO2].DefaultValue = defValueInt32;
            // ���ɍX�V�敪�iBO3�j
            dt.Columns.Add(ct_Col_EnterUpdDivBO3, typeof(Int32));
            dt.Columns[ct_Col_EnterUpdDivBO3].DefaultValue = defValueInt32;
            // ���ɍX�V�敪�iҰ���j
            dt.Columns.Add(ct_Col_EnterUpdDivMaker, typeof(Int32));
            dt.Columns[ct_Col_EnterUpdDivMaker].DefaultValue = defValueInt32;
            // ���ɍX�V�敪�iEO�j
            dt.Columns.Add(ct_Col_EnterUpdDivEO, typeof(Int32));
            dt.Columns[ct_Col_EnterUpdDivEO].DefaultValue = defValueInt32;
            // ���׊֘A�t��GUID
            dt.Columns.Add(ct_Col_DtlRelationGuid, typeof(Guid));
            dt.Columns[ct_Col_DtlRelationGuid].DefaultValue = Guid.Empty;

            // PrimaryKey�̐ݒ�
            dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_OnlineNo], dt.Columns[ct_Col_OnlineRowNo] };
        }
        #endregion
    }
}