//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �݌Ɏd������
// �v���O�����T�v   : �݌Ɏd�����͂Ŏg�p����f�[�^�̎擾�E�X�V���s���B
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �n糋M�T
// �� �� ��  2007/05/18  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ��`
// �C �� ��  2008/03/14  �C�����e : ���i�R�[�h�����ύX15����40��0
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �E �K�j
// �C �� ��  2008/07/24  �C�����e : Partsman�p�ɕύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���n ���
// �C �� ��  2009/02/19  �C�����e : ���i�����̎擾�l�`�w������3200���Ƃ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/05/26  �C�����e : �s��Ή�[13376]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �C �� ��  2009/06/17  �C�����e : �s��Ή�[13515]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/06/23  �C�����e : �s��Ή�[13602]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �C �� ��  2009/11/16  �C�����e : �݌ɓo�^�@�\�̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��r��
// �C �� ��  2009/12/16  �C�����e : PM.NS-5
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�W�����i�A���P���A�d�����A�d���㐔��
//                                  �f�B�t�H���g�̉��C
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �C �� ��  2010/07/14  �C�����e : Mantis.15812�@���i�݌Ƀ}�X�^�Ăяo�����̃p�����[�^�̕ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : 杍^
// �C �� ��  2011/07/25  �C�����e : �A��No.16 �|���ݒ�Ɋւ��āA00�S�Ћ��� �� ���_�̊|���̗D�揇�ʂ̓������iWAN�^�p�j�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : ����
// �C �� ��  2011/12/13  �C�����e : redmine#26816 �C���Ăяo�����ɂ͓���i�ԑI���E�B���h�E�͕\�����Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370074-00 �쐬�S�� : 杍^
// �C �� ��  2017/08/11  �C�����e : �n���f�B�^�[�~�i���݌Ɏd���o�^�̑Ή�
//----------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
	/// <summary>    
	/// ���ԍ݌Ƀ}�X�^�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���ԍ݌Ƀ}�X�^�̃A�N�Z�X�N���X�ł��B</br>
	/// <br>Programmer : 19077 �n糋M�T</br>
	/// <br>Date       : 2007.05.18</br>
    /// <br>Update Note: 2008.03.14 980035 ���� ��`</br>
    /// <br>			 �E���i�R�[�h�����ύX15����40��0</br>
    /// <br>Update Note: 2008/07/24 30414 �E �K�j</br>
    /// <br>			 �EPartsman�p�ɕύX</br>
    /// <br>Update Note: 2009.02.19 20056 ���n ���</br>
    /// <br>			 �E���i�����̎擾�l�`�w������3200���Ƃ���</br>
    /// <br>Update Note: 2009/05/26       �Ɠc �M�u</br>
    /// <br>			 �E�s��Ή�[13376]</br>
    /// <br>Update Note: 2009/06/23       �Ɠc �M�u</br>
    /// <br>			 �E�s��Ή�[13602]</br>
    /// <br>Update Note: 2009/11/16       �H�� �b�D</br>
    /// <br>			 �E�݌ɓo�^�@�\�̒ǉ�</br>
    /// <br>Update Note: 2011/07/25 杍^ �A��No.16 �|���ݒ�Ɋւ��āA00�S�Ћ��� �� ���_�̊|���̗D�揇�ʂ̓������iWAN�^�p�j�̑Ή�</br>
    /// <br>Update Note: 2011/12/13 ���� redmine#26816 �C���Ăяo�����ɂ͓���i�ԑI���E�B���h�E�͕\�����Ȃ�</br>
    /// <br>Update Note: 2017/08/11 杍^  </br>
    /// <br>�Ǘ��ԍ�   : 11370074-00</br>
    /// <br>             �n���f�B�^�[�~�i���݌Ɏd���o�^�̑Ή�</br> 
    /// </remarks>
	public partial class AdjustStockAcs
	{
        //==================================================================
        //  �p�u���b�N�񋓌^
        //==================================================================
        #region �p�u���b�N�񋓌^
        #endregion

        /// <summary>
        /// �A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�A�N�Z�X�N���X �C���X�^���X</returns>
        public static AdjustStockAcs GetInstance()
        {
            if (myInstance == null)
            {
                myInstance = new AdjustStockAcs();
            }

            return myInstance;
        }

        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        public int edtiMode;
        public DateTime editDate;
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/

        //==================================================================
		//  �p�u���b�N�萔
		//==================================================================
		#region �p�u���b�N�萔
        // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
        #region DEL 2008/07/24
        ///// <summary>�݌ɒ������׃e�[�u����</summary>
        //public const string ctTBL_AdjustStock = "AdjustStockDtlTbl";
        ///// <summary>�쐬����</summary>
        //public const string ctCOL_CreateDateTime = "CreateDateTime";
        ///// <summary>�X�V����</summary>
        //public const string ctCOL_UpdateDateTime = "UpdateDateTime";
        ///// <summary>��ƃR�[�h</summary>
        //public const string ctCOL_EnterpriseCode = "EnterpriseCode";
        ///// <summary>GUID</summary>
        //public const string ctCOL_FileHeaderGuid = "FileHeaderGuid";
        ///// <summary>�X�V�]�ƈ��R�[�h</summary>
        //public const string ctCOL_UpdEmployeeCode = "UpdEmployeeCode";
        ///// <summary>�X�V�A�Z���u��ID1</summary>
        //public const string ctCOL_UpdAssemblyId1 = "UpdAssemblyId1";
        ///// <summary>�X�V�A�Z���u��ID2</summary>
        //public const string ctCOL_UpdAssemblyId2 = "UpdAssemblyId2";
        ///// <summary>�_���폜�敪</summary>
        //public const string ctCOL_LogicalDeleteCode = "LogicalDeleteCode";
        ///// <summary>���_�R�[�h</summary>
        //public const string ctCOL_SectionCode = "SectionCode";
        //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        /////// <summary>���[�J�[�R�[�h</summary>
        ////public const string ctCOL_MakerCode = "MakerCode";
        /////// <summary>���i�R�[�h</summary>
        ////public const string ctCOL_GoodsCode = "GoodsCode";
        ///// <summary>���[�J�[�R�[�h</summary>
        //public const string ctCOL_GoodsMakerCd = "GoodsMakerCd";
        ///// <summary>���i�R�[�h</summary>
        //public const string ctCOL_GoodsNo = "GoodsNo";
        //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        ///// <summary>���i����</summary>
        //public const string ctCOL_GoodsName = "GoodsName";
        //// 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>�����ԍ�</summary>
        ////public const string ctCOL_ProductNumber = "ProductNumber";
        /////// <summary>���ԍ݌Ƀ}�X�^GUID</summary>
        ////public const string ctCOL_ProductStockGuid = "ProductStockGuid";
        //// 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>�݌ɋ敪</summary>
        //public const string ctCOL_StockDiv = "StockDiv";
        ///// <summary>�q�ɃR�[�h</summary>
        //public const string ctCOL_WarehouseCode = "WarehouseCode";
        ///// <summary>�q�ɖ���</summary>
        //public const string ctCOL_WarehouseName = "WarehouseName";
        //// 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>���Ǝ҃R�[�h</summary>
        ////public const string ctCOL_CarrierEpCode = "CarrierEpCode";
        /////// <summary>���ƎҖ���</summary>
        ////public const string ctCOL_CarrierEpName = "CarreirEpName";
        //// 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>���Ӑ�R�[�h</summary>
        //public const string ctCOL_CustomerCode = "CustomerCode";
        ///// <summary>���Ӑ於��</summary>
        //public const string ctCOL_CustomerName = "CustomerName";
        ///// <summary>���Ӑ於��2</summary>
        //public const string ctCOL_CustomerName2 = "CustomerName2";
        ///// <summary>�d����</summary>
        //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        ////public const string ctCOL_StockDate = "StockDate";
        //public const string ctCOL_LastStockDate = "LastStockDate";
        //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        ///// <summary>���ד�</summary>
        //public const string ctCOL_ArrivalGoodsDay = "ArrivalGoodsDay";
        ///// <summary>�d���P��</summary>
        //public const string ctCOL_StockUnitPrice = "StockUnitPrice";
        ///// <summary>�ύX�O�d���P��</summary>
        //public const string ctCOL_BfStockUnitPrice = "BfStockUnitPrice";
        ///// <summary>�d�����z</summary>
        //public const string ctCOL_StockPrice = "StockPrice";        
        ///// <summary>�d�����z����Ŋz</summary>
        //public const string ctCOL_StockPriceConsTax = "StockPriceConsTax";
        ///// <summary>�d���O�őΏۊz</summary>
        //public const string ctCOL_ItdedStckOutTax = "ItdedStckOutTax";        
        ///// <summary>�d�����őΏۊz</summary>
        //public const string ctCOL_ItdedStckInTax = "ItdedStckInTax";
        ///// <summary>�d����ېőΏۊz</summary>
        //public const string ctCOL_ItdedStckTaxFree = "ItdedStckTaxFree";
        ///// <summary>�d���O�Ŋz</summary>
        //public const string ctCOL_StckOuterTax = "StckOuterTax";
        ///// <summary>�d�����Ŋz</summary>
        //public const string ctCOL_StckInnerTax = "StckInnerTax";
        ///// <summary>�ېŋ敪</summary>
        //public const string ctCOL_TaxationCode = "TaxationCode";
        //// 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>�݌ɏ��</summary>
        ////public const string ctCOL_StockState = "StockState";
        /////// <summary>�ړ����</summary>
        ////public const string ctCOL_MoveStatus = "MoveStatus";
        /////// <sammary>���i���</sammary>
        ////public const string ctCOL_GoodsCodeStatus = "GoodsCodeStatus";
        /////// <sammary>�C���O���i���</sammary>
        ////public const string ctCOL_BfGoodsCodeStatus = "BfGoodsCodeStatus";
        /////// <summary>���i�d�b�ԍ�1</summary>
        ////public const string ctCOL_StockTelNo1 = "StockTelNo1";
        /////// <summary>���i�d�b�ԍ�2</summary>
        ////public const string ctCOL_StockTelNo2 = "StockTelNo2";
        /////// <summary>�����敪</summary>
        ////public const string ctCOL_RomDiv = "RomDiv";
        /////// <summary>�@��R�[�h</summary>
        ////public const string ctCOL_CellphoneModelCode = "CellphoneModelCode";
        /////// <summary>�@�햼��</summary>
        ////public const string ctCOL_CellphoneModelName = "CellphoneModelName";
        /////// <summary>�L�����A�R�[�h</summary>
        ////public const string ctCOL_CarrierCode = "CarrierCode";
        /////// <summary>�L�����A����</summary>
        ////public const string ctCOL_CarrierName = "CarrierName";
        //// 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>���[�J�[����</summary>
        //public const string ctCOL_MakerName = "MakerName";
        //// 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>�n���F�R�[�h</summary>
        ////public const string ctCOL_SystematicColorCd = "SystematicColorCd";
        /////// <summary>�n���F����</summary>
        ////public const string ctCOL_SystematicColorNm = "SystematicColorNm";
        //// 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>���i�啪�ރR�[�h</summary>
        //public const string ctCOL_LargeGoodsGanreCode = "LargeGoodsGanreCode";
        ///// <summary>���i�����ރR�[�h</summary>
        //public const string ctCOL_MediumGoodsGanreCode = "MediumGoodsGanreCode";
        //// 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>�o�א擾�Ӑ�R�[�h</summary>
        ////public const string ctCOL_ShipCustomerCode = "ShipCustomerCode";
        /////// <summary>�o�א擾�Ӑ於��</summary>
        ////public const string ctCOL_ShipCustomerName = "ShipCustomerName";
        /////// <summary>�o�א擾�Ӑ於��2</summary>
        ////public const string ctCOL_ShipCustomerName2 = "ShipCustomerName2";
        //// 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>�s��</summary>        
        //public const string ctCOL_RowNum = "RowNum";
        //// 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>�ύX�O�d�b�ԍ�</summary>
        ////public const string ctCOL_BfStockTelNo1 = "BfStockTelNo1";
        //// 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>���݌ɐ�(�d���݌ɐ�)</summary>
        //public const string ctCOL_SupplierStock = "SupplierStock";
        ///// <summary>������</summary>
        //public const string ctCOL_AdjustCount = "AdjustCount";
        ///// <summary>�������z</summary>
        //public const string ctCOL_AdjustPrice = "AdjustPrice";
        //// 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>�C���O����</summary>
        ////public const string ctCOL_BfProductNumber = "BfProductNumber";
        //// 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>���i�K�C�h</summary>
        //public const string ctCOL_GoodsGuide = "GoodsGuide";        
        ///// <summary>���ה���</summary>
        //public const string ctCOL_RowType = "RowType";
        ///// <summary>����݌ɐ�</summary>
        //public const string ctCOL_TrustCount = "TrustCount";
        //// 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>���ԊǗ��敪</summary>
        ////public const string ctCOL_PrdNumMngDiv = "PrdNumMngDiv";
        //// 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
        //// 2007.10.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
        ///// <summary>���i�敪�ڍ׃R�[�h</summary>
        //public const string ctCOL_DetailGoodsGanreCode = "DetailGoodsGanreCode";
        ///// <summary>�a�k���i�R�[�h</summary>
        //public const string ctCOL_BLGoodsCode = "BLGoodsCode";
        ///// <summary>�q�ɒI��</summary>
        //public const string ctCOL_WarehouseShelfNo = "WarehouseShelfNo";
        ///// <summary>�C���O�q�ɒI��</summary>
        //public const string ctCOL_BfWarehouseShelfNo = "BfWarehouseShelfNo";
        //// 2007.10.11 �ǉ� <<<<<<<<<<<<<<<<<<<<
        //// 2008.01.17 �ǉ� >>>>>>>>>>>>>>>>>>>>
        ///// <summary>���ה��l</summary>
        //public const string ctCOL_DtlNote = "DtlNote";
        //// 2008.01.17 �ǉ� <<<<<<<<<<<<<<<<<<<<
        //// 2008.02.15 �C�� >>>>>>>>>>>>>>>>>>>>
        ///// <summary>�艿�i�����j</summary>
        //public const string ctCOL_ListPriceFl = "ListPriceFl";
        //// 2008.02.15 �C�� <<<<<<<<<<<<<<<<<<<<
        ///// <summary>�������׍s��</summary>
        //public static readonly int ctCOUNT_RowInit = 50;
        ///// <summary>���׍ő�s��</summary>
        //public static readonly int ctCOUNT_RowMax = 999;
        ///// <summary>���׍s�ǉ��P�ʍs��</summary>
        //public static readonly int ctCOUNT_RowAdd = 1;
        //private const int ctMode_StockAdjust = 0;
        //// 2008.01.17 �C�� >>>>>>>>>>>>>>>>>>>>
        ////private const int ctMode_TrustAdjust = 1;
        ////// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        //////private const int ctMode_ProductReEdit = 2;
        //////private const int ctMode_GoodsCodeStatus = 3;
        //////private const int ctMode_UnitPriceReEdit = 4;
        ////private const int ctMode_UnitPriceReEdit = 2;
        ////private const int ctMode_ShelfNoReEdit = 3;
        ////// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        //private const int ctMode_UnitPriceReEdit = 1;
        //private const int ctMode_ShelfNoReEdit = 2;
        //// 2008.01.17 �C�� <<<<<<<<<<<<<<<<<<<<
        #endregion DEL 2008/07/24

        /// <summary>�݌ɒ������׃e�[�u����</summary>
        public const string ctTBL_AdjustStock = "AdjustStockDtlTbl";
        /// <summary>�쐬����</summary>
        public const string ctCOL_CreateDateTime = "CreateDateTime";
        /// <summary>�X�V����</summary>
        public const string ctCOL_UpdateDateTime = "UpdateDateTime";
        /// <summary>��ƃR�[�h</summary>
        public const string ctCOL_EnterpriseCode = "EnterpriseCode";
        /// <summary>GUID</summary>
        public const string ctCOL_FileHeaderGuid = "FileHeaderGuid";
        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        public const string ctCOL_UpdEmployeeCode = "UpdEmployeeCode";
        /// <summary>�X�V�A�Z���u��ID1</summary>
        public const string ctCOL_UpdAssemblyId1 = "UpdAssemblyId1";
        /// <summary>�X�V�A�Z���u��ID2</summary>
        public const string ctCOL_UpdAssemblyId2 = "UpdAssemblyId2";
        /// <summary>�_���폜�敪</summary>
        public const string ctCOL_LogicalDeleteCode = "LogicalDeleteCode";
        /// <summary>���_�R�[�h</summary>
        public const string ctCOL_SectionCode = "SectionCode";
        /// <summary>�s��</summary>        
        public const string ctCOL_RowNum = "RowNum";
        /// <summary>�������t</summary>
        public const string ctCOL_AdjustDate = "AdjustDate";
        /// <summary>���͓��t</summary>
        public const string ctCOL_InputDay = "InputDay";
        /// <summary>���[�J�[�R�[�h</summary>
        public const string ctCOL_GoodsMakerCd = "GoodsMakerCd";
        /// <summary>�i��</summary>
        public const string ctCOL_GoodsNo = "GoodsNo";
        /// <summary>�i��</summary>
        public const string ctCOL_GoodsName = "GoodsName";
        /// <summary>���P��</summary>
        public const string ctCOL_StockUnitPrice = "StockUnitPrice";
        /// <summary>�ύX�O���P��</summary>
        public const string ctCOL_BfStockUnitPrice = "BfStockUnitPrice";
        /// <summary>�݌ɐ�(�d���݌ɐ�)</summary>
        public const string ctCOL_SupplierStock = "SupplierStock";
        /// <summary>�ύX�O�݌ɐ�(�d���݌ɐ�)</summary>
        public const string ctCOL_BfSupplierStock = "BfSupplierStock";
        /// <summary>���ה��l</summary>
        public const string ctCOL_DtlNote = "DtlNote";
        /// <summary>�q�ɃR�[�h</summary>
        public const string ctCOL_WarehouseCode = "WarehouseCode";
        /// <summary>�a�k���i�R�[�h</summary>
        public const string ctCOL_BLGoodsCode = "BLGoodsCode";
        /// <summary>�q�ɒI��</summary>
        public const string ctCOL_WarehouseShelfNo = "WarehouseShelfNo";
        /// <summary>�W�����i</summary>
        public const string ctCOL_ListPriceFl = "ListPriceFl";
        /// <summary>�d����</summary>
        public const string ctCOL_SupplierCd = "SupplierCd";
        /// <summary>�d����(�����P��)</summary>
        public const string ctCOL_SalesOrderUnit = "SalesOrderUnit";
        /// <summary>�ύX�O�d����(�����P��)</summary>
        public const string ctCOL_BfSalesOrderUnit = "BfSalesOrderUnit";
        /// <summary>�d���㐔</summary>
        public const string ctCOL_AfSalesOrderUnit = "AfSalesOrderUnit";
        /// <summary>�����c</summary>
        public const string ctCOL_SalesOrderCount = "SalesOrderCount";
        /// <summary>�d���`��(��)</summary>
        public const string ctCOL_SupplierFormalSrc = "SupplierFormalSrc";
        /// <summary>�d�����גʔ�(��)</summary>
        public const string ctCOL_StockSlipDtlNumSrc = "StockSlipDtlNumSrc";
        /// <summary>�݌ɒ����`�[�ԍ�</summary>
        public const string ctCOL_StockAdjustSlipNo = "StockAdjustSlipNo";
        /// <summary>�݌Ƀ}�X�^</summary>
        public const string ctCOL_Stock = "Stock";
        /// <summary>�݌ɒ����f�[�^</summary>
        public const string ctCOL_StockAdjust = "StockAdjust";
        /// <summary>�݌ɒ������׃f�[�^</summary>
        public const string ctCOL_StockAdjustDtl = "StockAdjustDtl";
        /// <summary>���i�}�X�^</summary>
        public const string ctCOL_GoodsPrice = "GoodsPrice";
        /// <summary>�d�����z</summary>
        public const string ctCOL_StockPriceTaxExc = "StockPriceTaxExc";
        /// <summary>�I�[�v�����i�敪</summary>
        public const string ctCOL_OpenPriceDiv = "OpenPriceDiv";
        /// <summary>�d���旪��</summary>
        public const string ctCOL_SupplierSnm = "SupplierSnm";

        /// <summary>�������׍s��</summary>
        public static readonly int ctCOUNT_RowInit = 50;
        /// <summary>���׍ő�s��</summary>
        public static readonly int ctCOUNT_RowMax = 999;
        /// <summary>���׍s�ǉ��P�ʍs��</summary>
        public static readonly int ctCOUNT_RowAdd = 1;
        // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
        #endregion

		//==================================================================
		//  �p�u���b�N�C�x���g
		//==================================================================
		#region �p�u���b�N�C�x���g
		/// <summary>�d���`�[��񂪕ύX���ꂽ�ꍇ�ɔ������܂��B</summary>
		public static event EventHandler SlipChanged
		{
			add { lock (syncRoot) { _slipChanged += value; } }
			remove { lock (syncRoot) { _slipChanged -= value; } }
		}

		/// <summary>���׃e�[�u���s���ύX���ꂽ�ꍇ�ɔ������܂��B</summary>
		public static event DataRowChangeEventHandler SlipDtlRowChanged
		{
			add { lock (syncRoot) { _mainProductStock.RowChanged += value; } }
			remove { lock (syncRoot) { _mainProductStock.RowChanged -= value; } }
		}

		/// <summary>���ׂ��ǉ�����钼�O�ɔ������܂��B</summary>
		public static event EventHandler<SlipDtlRowChangingEventArgs> SlipDtlRowAdding
		{
			add { lock (syncRoot) { _slipDtlRowAdding += value; } }
			remove { lock (syncRoot) { _slipDtlRowAdding -= value; } }
		}

		/// <summary>���ׂ��ǉ����ꂽ�ꍇ�ɔ������܂��B</summary>
		public static event EventHandler<SlipDtlRowChangedEventArgs> SlipDtlRowAdded
		{
			add { lock (syncRoot) { _slipDtlRowAdded += value; } }
			remove { lock (syncRoot) { _slipDtlRowAdded -= value; } }
		}

		/// <summary>���ׂ��폜����钼�O�ɔ������܂��B</summary>
		public static event EventHandler<SlipDtlRowChangingEventArgs> SlipDtlRowRemoving
		{
			add { lock (syncRoot) { _slipDtlRowRemoving += value; } }
			remove { lock (syncRoot) { _slipDtlRowRemoving -= value; } }
		}

		/// <summary>���ׂ��ύX���ꂽ�ꍇ�ɔ������܂��B</summary>
		public static event EventHandler<SlipDtlRowChangedEventArgs> SlipDtlRowRemoved
		{
			add { lock (syncRoot) { _slipDtlRowRemoved += value; } }
			remove { lock (syncRoot) { _slipDtlRowRemoved -= value; } }
		}

		/// <summary>���ח񂪕ύX����钼�O�ɔ������܂��B</summary>
		public static event EventHandler<SlipDtlColChangingEventArgs> SlipDtlColChanging
		{
			add { lock (syncRoot) { _slipDtlColChanging += value; } }
			remove { lock (syncRoot) { _slipDtlColChanging -= value; } }
		}

		/// <summary>���ח񂪕ύX���ꂽ�ꍇ�ɔ������܂��B</summary>
		public static event EventHandler<SlipDtlColChangedEventArgs> SlipDtlColChanged
		{
			add { lock (syncRoot) { _slipDtlColChanged += value; } }
			remove { lock (syncRoot) { _slipDtlColChanged -= value; } }
		}

        /// <summary>�f�[�^�ύX�㔭���C�x���g</summary>
        // 2008.02.15 �폜 >>>>>>>>>>>>>>>>>>>>
        //public event EventHandler DataChanged;
        // 2008.02.15 �폜 <<<<<<<<<<<<<<<<<<<<

		#endregion

		//==================================================================
		//  �v���C�x�[�g�ϐ�
		//==================================================================
		#region �v���C�x�[�g�ϐ�
		/// <summary>�X�^�e�B�b�N�C���X�^���X</summary>
		private static AdjustStockAcs myInstance = null;

        private IStockAdjustDB _iStockAdjustDB = null; 

		/// <summary>�C���X�^���X����</summary>
		private static int instanceCnt = 0;
		/// <summary>���b�N�I�u�W�F�N�g</summary>
		private static object syncRoot = new Object();
		/// <summary>���׏��ύX�C�x���g����J�E���^</summary>
		private static int slipDtlChangeEventCounter = 0;

		//--------------------------------------------------------
		//  �݌Ɋ֘A
		//--------------------------------------------------------
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>		
        /// <summary>�݌ɏ��o�b�t�@(Main Static Memory)</summary>
		private static Stock mainStock = null;

        /// <summary>�݌ɏ��o�b�t�@(Original Static Memory)</summary>
        /// <remarks>�Ǎ����̏���ێ�(�ύX�`�F�b�N/����Ɏg�p)</remarks>
        private static Stock orgnPtSuplSlip = null;

        private static ArrayList _stockList = new ArrayList();
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/

		/// <summary>���ԏ��o�b�t�@(Main Static Memory)</summary>
		private static DataTable _mainProductStock = null;

        // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
        ///// <remarks>�`�[�Ǎ����̏���ێ�(�ύX�`�F�b�N/����Ɏg�p)</remarks>
		//private static List<ProductStock> orgnAdjustStockDtl = null;
        // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
        /// <summary>���׃f�[�^�r���[(�L�����̂�)</summary>
		private static DataView _mainProductStockView = null;
		/// <summary>���׃f�[�^�r���[(�S�f�[�^)</summary>
		private static DataView mainAdjustStockDtlFullView = null;
		/// <summary>���׃f�[�^�r���[(����͏���Ŋz�����p)</summary>
		private static DataView adjustSuplSlipDtlPriceView = null;

        // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>�R�s�y�p�d���`�[���׃N���b�v�{�[�h</summary>
		//private static List<ProductStock> suplSlipDtlClipboard = null;
        // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<

		/// <summary>�ő喾�׍s��</summary>
        //private static int maxRowCnt = ctCOUNT_RowInit;  // DEL 2009/12/16
        public static int maxRowCnt = ctCOUNT_RowInit;     // ADD 2009/12/16

        private bool _isDataCanged = false;


        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        private StockProcMoneyAcs _stockProcMoneyAcs;   // �P���Z�o�N���X�A�N�Z�X�N���X
        private TaxRateSetAcs _taxRateSetAcs;           // �ŗ��ݒ�}�X�^�A�N�Z�X�N���X
        private SearchStockAcs _searchStockAcs;         // �݌Ƀ}�X�^�A�N�Z�X�N���X
        private GoodsAcs _goodsAcs;                     // ���i�}�X�^�A�N�Z�X�N���X
        private BLGoodsCdAcs _blGoodsCdAcs;             // BL���i�R�[�h�}�X�^�A�N�Z�X�N���X
        private WarehouseAcs _warehouseAcs;             // �q�Ƀ}�X�^�A�N�Z�X�N���X
        private SecInfoAcs _secInfoAcs;                 // ���_���}�X�^�A�N�Z�X�N���X
        private EmployeeAcs _employeeAcs;               // �]�ƈ��}�X�^�A�N�Z�X�N���X
        private MakerAcs _makerAcs;                     // ���[�J�[�}�X�^�A�N�Z�X�N���X
        private StockMngTtlStAcs _stockMngTtlStAcs;
        private SupplierAcs _supplierAcs;

        private StockMngTtlSt _stockMngTtlSt;
        private UnitPriceCalculation _unitPriceCalculation;
        private TaxRateSet _taxRateSet;

        private CompanyInfAcs _companyInfAcs;                // ADD 2011/07/25
        private CompanyInf _companyInf = null;  // ���Џ�� // ADD 2011/07/25

        private Dictionary<int, Supplier> _supplierDic;
        private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdUMntDic;
        private Dictionary<string, Warehouse> _warehouseDic;
        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<string, Employee> _employeeDic;
        private Dictionary<int, MakerUMnt> _makerDic;
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

		#endregion

        // ------ ADD 2017/08/11 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
        #region ���萔�i�n���f�B�^�[�~�i���p�j
        /// <summary>���[�J�[�t�H�[�}�b�g</summary>
        private const string GoodsMakerCdFormat = "0000";
        /// <summary>BL���i�R�[�h�t�H�[�}�b�g</summary>
        private const string BLGoodsCodeFormat = "00000";
        /// <summary>������R�[�h�t�H�[�}�b�g</summary>
        private const string SupplierCdFormat = "000000";

        /// <summary>�n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j���[�N�v���O����ID</summary>
        private const string AssemblyIdPmhnd01114d = "PMHND01114D";
        /// <summary>�n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j���[�N�v���O����ID�̃N���X��</summary>
        private const string AssemblyIdPmhnd01114dClassName = "Broadleaf.Application.Remoting.ParamData.HandyNonUOEInspectParamWork";

        /// <summary>�d�����גʔ�</summary>
        private const string StockSlipDtlNum = "StockSlipDtlNum";
        /// <summary>���i��</summary>
        private const string InspectCnt = "InspectCnt";
        #endregion

        #region ���v���C�x�[�g�ϐ��i�n���f�B�^�[�~�i���p�j
        /// <summary>���ԏ��o�b�t�@</summary>
        private DataTable MainProductStock = null;
        #endregion
        // ------ ADD 2017/08/11 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<

        //==================================================================
		//  �v���C�x�[�g�f���Q�[�g�ϐ�
		//==================================================================
		#region �v���C�x�[�g�f���Q�[�g�ϐ�
		// �񋟃C�x���g�p
		/// <summary>�d���`�[�ύX�C�x���g�p�f���Q�[�g</summary>
		private static EventHandler _slipChanged = null;
		/// <summary>�d���`�[���׍s�ǉ��O�C�x���g�p�f���Q�[�g</summary>
		private static EventHandler<SlipDtlRowChangingEventArgs> _slipDtlRowAdding = null;
		/// <summary>�d���`�[���׍s�ǉ���C�x���g�p�f���Q�[�g</summary>
		private static EventHandler<SlipDtlRowChangedEventArgs> _slipDtlRowAdded = null;
		/// <summary>�d���`�[���׍s�폜�O�C�x���g�p�f���Q�[�g</summary>
		private static EventHandler<SlipDtlRowChangingEventArgs> _slipDtlRowRemoving = null;
		/// <summary>�d���`�[���׍s�폜��C�x���g�p�f���Q�[�g</summary>
		private static EventHandler<SlipDtlRowChangedEventArgs> _slipDtlRowRemoved = null;
		/// <summary>�d���`�[���ח�ύX�O�C�x���g�p�f���Q�[�g</summary>
		private static EventHandler<SlipDtlColChangingEventArgs> _slipDtlColChanging = null;
		/// <summary>�d���`�[���ח�ύX��C�x���g�p�f���Q�[�g</summary>
		private static EventHandler<SlipDtlColChangedEventArgs> _slipDtlColChanged = null;

		// ���������C�x���g�p
		/// <summary>���׏��ύX�C�x���g�n���h���f���Q�[�g�ϐ�</summary>
		private static DataColumnChangeEventHandler _slipDtlChanging = null;
		/// <summary>���׏��ύX�C�x���g�n���h���f���Q�[�g�ϐ�</summary>
		private static DataColumnChangeEventHandler _slipDtlChanged = null;
		#endregion

		//==================================================================
		//  �R���X�g���N�^
		//==================================================================
		#region �R���X�g���N�^
		/// <summary>
		/// �ÓI�R���X�g���N�^
		/// </summary>
		static AdjustStockAcs()
		{
			// Static�ϐ�������
			instanceCnt = 0;

			// �f�[�^�e�[�u���쐬
			CreateProductStockTable();
		}

		/// <summary>
		/// �f�t�H���g�R���X�g���N�^
		/// </summary>
        /// <br>Update Note: 2011/07/25 杍^ �A��No.16 �|���ݒ�Ɋւ��āA00�S�Ћ��� �� ���_�̊|���̗D�揇�ʂ̓������iWAN�^�p�j�̑Ή�</br>
		public AdjustStockAcs()
		{
            try
            {
                if (this._iStockAdjustDB == null)
                {
                    // �����[�g�I�u�W�F�N�g�擾
                    this._iStockAdjustDB = (IStockAdjustDB)MediationStockAdjustDB.GetStockAdjustDB();
                }
            }
            catch (Exception)
            {
                this._iStockAdjustDB = null;
            }

			// ����C���X�^���X�����̂ݎ��s
			if (instanceCnt++ == 0)
			{
				// �������g
				myInstance = new AdjustStockAcs();

                // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //ProductStockWorkToDataRow(null);
                // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
            }

            // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
            this._stockProcMoneyAcs = new StockProcMoneyAcs();
            this._taxRateSetAcs = new TaxRateSetAcs();
            this._goodsAcs = new GoodsAcs();
            this._searchStockAcs = new SearchStockAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._warehouseAcs = new WarehouseAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._employeeAcs = new EmployeeAcs();
            this._makerAcs = new MakerAcs();
            this._stockMngTtlStAcs = new StockMngTtlStAcs();
            this._supplierAcs = new SupplierAcs();

            this._companyInfAcs = new CompanyInfAcs();  // 2011/07/25
            this._companyInf = new CompanyInf(); // 2011/07/25
            
            this._unitPriceCalculation = new UnitPriceCalculation();

            string errMsg;
            this._goodsAcs.SearchInitial(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, out errMsg);

            ReadStockMngTtlSt();
            ReadInitData();         // �P���Z�o�N���X�����f�[�^�Ǎ�
            ReadTaxRate();          // �ŗ��ݒ�}�X�^�Ǎ�
            ReadBLGoodsCdUMnt();    // BL���i�R�[�h�}�X�^�Ǎ�
            ReadWarehouse();        // �q�Ƀ}�X�^�Ǎ�
            ReadSecInfoSet();       // ���_���ݒ�}�X�^�Ǎ�
            ReadEmployee();         // �]�ƈ��}�X�^�Ǎ�
            ReadMakerUMnt();        // ���[�J�[�}�X�^�Ǎ�
            ReadSupplier();
            ReadCompanyInf();  //  �|���D��敪�ɒǉ�   //  ADD 2011/07/25
            // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<
        }
		#endregion

        #region BL���i�R�[�h�}�X�^�Ǎ�
        /// <summary>
        /// BL���i�R�[�h�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : BL���i�R�[�h�}�X�^��Ǎ��A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public void ReadBLGoodsCdUMnt()
        {
            this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();

            ArrayList retList;
            int status = this._blGoodsCdAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            if (status == 0)
            {
                foreach (BLGoodsCdUMnt blGoodsCdUMnt in retList)
                {
                    if (blGoodsCdUMnt.LogicalDeleteCode == 0)
                    {
                        this._blGoodsCdUMntDic.Add(blGoodsCdUMnt.BLGoodsCode, blGoodsCdUMnt);
                    }
                }
            }
        }
        #endregion BL���i�R�[�h�}�X�^�Ǎ�

        #region �q�Ƀ}�X�^�Ǎ�
        /// <summary>
        /// �q�Ƀ}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �q�Ƀ}�X�^��Ǎ��A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public void ReadWarehouse()
        {
            this._warehouseDic = new Dictionary<string, Warehouse>();

            try
            {
                ArrayList retList;
                int status = this._warehouseAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (Warehouse warehouse in retList)
                    {
                        if (warehouse.LogicalDeleteCode == 0)
                        {
                            this._warehouseDic.Add(warehouse.WarehouseCode.Trim().PadLeft(4, '0'), warehouse);
                        }
                    }
                }
            }
            catch
            {
            }
        }
        #endregion �q�Ƀ}�X�^�Ǎ�

        #region ���_���ݒ�}�X�^�Ǎ�
        /// <summary>
        /// ���_���ݒ�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_���ݒ�}�X�^��Ǎ��A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            this._secInfoAcs.ResetSectionInfo();

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.LogicalDeleteCode == 0)
                    {
                        this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                    }
                }
            }
            catch
            {
            }
        }
        #endregion ���_���ݒ�}�X�^�Ǎ�

        #region �]�ƈ��}�X�^�Ǎ�
        /// <summary>
        /// �]�ƈ��}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �]�ƈ��}�X�^��Ǎ��A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public void ReadEmployee()
        {
            this._employeeDic = new Dictionary<string, Employee>();

            try
            {
                ArrayList retList;
                ArrayList retList2;
                int status = this._employeeAcs.SearchAll(out retList, out retList2, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (Employee employee in retList)
                    {
                        if (employee.LogicalDeleteCode == 0)
                        {
                            // ---ADD 2009/05/26 �s��Ή�[13376] --------------------------------------->>>>>
                            // �Ǘ��҃f�[�^�͏���
                            if ((employee.UserAdminFlag == 1) || (employee.UserAdminFlag == 2))
                            {
                                continue;
                            }
                            // ���ł�Add����Ă�����̂͏���
                            if (this._employeeDic.ContainsKey(employee.EmployeeCode.Trim().PadLeft(4, '0')))
                            {
                                continue;
                            }
                            // ---ADD 2009/05/26 �s��Ή�[13376] ---------------------------------------<<<<<

                            this._employeeDic.Add(employee.EmployeeCode.Trim().PadLeft(4, '0'), employee);
                        }
                    }
                }
            }
            catch
            {
            }
        }
        #endregion �]�ƈ��}�X�^�Ǎ�

        #region ���[�J�[�}�X�^�Ǎ�
        /// <summary>
        /// ���[�J�[�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�J�[�}�X�^��Ǎ��A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public void ReadMakerUMnt()
        {
            this._makerDic = new Dictionary<int, MakerUMnt>();

            try
            {
                ArrayList retList;
                int status = this._makerAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        if (makerUMnt.LogicalDeleteCode == 0)
                        {
                            this._makerDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                        }
                    }
                }
            }
            catch
            {
            }
        }
        #endregion ���[�J�[�}�X�^�Ǎ�

        public void ReadSupplier()
        {
            this._supplierDic = new Dictionary<int, Supplier>();

            try
            {
                ArrayList retList;
                int status = this._supplierAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (Supplier supplier in retList)
                    {
                        if (supplier.LogicalDeleteCode == 0)
                        {
                            this._supplierDic.Add(supplier.SupplierCd, supplier);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        //  -------- ADD 2011/07/25 ---- >>>> 
        public void ReadCompanyInf()
        {
            this._companyInfAcs.Read(out this._companyInf, LoginInfoAcquisition.EnterpriseCode);

            // �|���D��敪
            if (this._companyInf != null)
            {
                this._unitPriceCalculation.RatePriorityDiv = this._companyInf.RatePriorityDiv;
            }
        }
        //  -------- ADD 2011/07/25 ---- <<<<


        #region BL���i�R�[�h���̎擾
        /// <summary>
        /// BL���i�R�[�h���̎擾����
        /// </summary>
        /// <param name="blGoodsCode">BL���i�R�[�h</param>
        /// <returns>BL���i�R�[�h����</returns>
        private string GetBLGoodsName(int blGoodsCode)
        {
            string blGoodsName = "";

            if (this._blGoodsCdUMntDic.ContainsKey(blGoodsCode) == true)
            {
                blGoodsName = this._blGoodsCdUMntDic[blGoodsCode].BLGoodsFullName.Trim();
            }

            return blGoodsName;
        }
        #endregion BL���i�R�[�h���̎擾

        #region �q�ɖ��̎擾
        /// <summary>
        /// �q�ɖ��̎擾����
        /// </summary>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <returns>�q�ɖ���</returns>
        /// <remarks>
        /// <br>Note       : �q�ɖ��̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public string GetWarehouseName(string warehouseCode)
        {
            string warehouseName = "";

            if (this._warehouseDic.ContainsKey(warehouseCode.Trim().PadLeft(4, '0')))
            {
                warehouseName = this._warehouseDic[warehouseCode.Trim().PadLeft(4, '0')].WarehouseName.Trim();
            }

            return warehouseName;
        }
        #endregion �q�ɖ��̎擾

        #region ���_���̎擾
        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            if (this._secInfoSetDic.ContainsKey(sectionCode.Trim().PadLeft(2, '0')))
            {
                sectionName = this._secInfoSetDic[sectionCode.Trim().PadLeft(2, '0')].SectionGuideNm.Trim();
            }

            return sectionName;
        }
        #endregion ���_���̎擾

        #region �]�ƈ����̎擾
        /// <summary>
        /// �]�ƈ����̎擾����
        /// </summary>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <returns>�]�ƈ�����</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ����̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public string GetEmployeeName(string employeeCode)
        {
            string employeeName = "";

            if (this._employeeDic.ContainsKey(employeeCode.Trim().PadLeft(4, '0')))
            {
                employeeName = this._employeeDic[employeeCode.Trim().PadLeft(4, '0')].Name.Trim();
            }

            return employeeName;
        }
        #endregion �]�ƈ����̎擾

        #region ���[�J�[���̎擾
        /// <summary>
        /// ���[�J�[���̎擾����
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns>���[�J�[����</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[���̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public string GetMakerName(int makerCode)
        {
            string makerName = "";

            if (this._makerDic.ContainsKey(makerCode))
            {
                makerName = this._makerDic[makerCode].MakerName.Trim();
            }

            return makerName;
        }
        #endregion ���[�J�[���̎擾

        private string GetSupplierSnm(int supplierCd)
        {
            if (this._supplierDic.ContainsKey(supplierCd))
            {
                return (this._supplierDic[supplierCd].SupplierSnm.Trim());
            }
            else
            {
                return "";
            }
        }
        //==================================================================
		//  �p�u���b�N�v���p�e�B
		//==================================================================
		#region �p�u���b�N�v���p�e�B
        public bool IsDataChanged
        {
            get
            {
                return this._isDataCanged;
            }
            set
            {
                this._isDataCanged = value;
/*
                if (this.DataChanged != null)
                {
                    this.DataChanged(this, new EventArgs());
                }
 */ 
            }
        }
		public static DataTable ProductStockDataTable
		{
			get { return _mainProductStock; }
		}

		/// <summary>�`�[����DataView(�_�~�[�s���܂�)</summary>
		public static DataView AdjustStockView
		{
			get
			{
				return mainAdjustStockDtlFullView;
			}
		}

		/// <summary>�`�[���׌���</summary>
		public static int SlipDtlCount
		{
			get
			{
				if (_mainProductStock != null)
				{
					return _mainProductStockView.Count;
				}
				else
				{
					return 0;
				}
			}
		}

        // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>�\��t���p�f�[�^�L��</summary>
		//public static bool HasClipboardData
		//{
		//	get
		//	{
		//		return ((suplSlipDtlClipboard != null) && (suplSlipDtlClipboard.Count > 0));
		//	}
		//}
        // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<

		#endregion

        #region 2007.10.11 �폜
        //==================================================================
		//  �p�u���b�N���\�b�h
		//==================================================================
		#region �p�u���b�N���\�b�h
        //// 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// �V�K�`�[���׏����l�N���X�擾
        ///// </summary>
		///// <returns>�V�K�`�[�N���X</returns>
		//public static ProductStock GetNewSlipDtl()
		//{
		//	ProductStock retData = new ProductStock();
        //	retData.LogicalDeleteCode = 0;
        //
        //	return retData;
        //}
        // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<

		#endregion
        #endregion 2007.10.11 �폜

        //==================================================================
		//  �v���C�x�[�g���\�b�h
		//==================================================================
		#region �v���C�x�[�g���\�b�h
		//--------------------------------------------------------
		//  Main Static Memory I/O
		//--------------------------------------------------------
		#region Main Static Memory I/O

        #region DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// (MainStaticMemory)����������
		/// </summary>
		/// <param name="mode">�R�s�[���[�h[0:����, 1:���A���̂�]</param>
		private  void InitializeSlipProc(int mode)
		{
			// ��ƃR�[�h
            mainStock.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// ���ԍ݌Ƀf�[�^����
			//ProductStockWorkToDataRow(null);
            // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �P���Z�o�N���X�����f�[�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// Note       : �P���Z�o�N���X�ɕK�v�ȏ����f�[�^��ǂݍ��݂܂��B<br />
        /// Programer  : 30414 �E �K�j<br />
        /// Date       : 2008/07/24<br />
        /// </remarks>
        public void ReadInitData()
        {
            List<StockProcMoney> stockProcMoneyList = new List<StockProcMoney>();
            ArrayList retStockProcMoneyList;

            int status = this._stockProcMoneyAcs.Search(out retStockProcMoneyList, LoginInfoAcquisition.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (StockProcMoney stockProcMoney in retStockProcMoneyList)
                {
                    stockProcMoneyList.Add(stockProcMoney.Clone());
                }
            }

            this._unitPriceCalculation.CacheStockProcMoneyList(stockProcMoneyList);
        }

        /// <summary>
        /// ���P���擾����
        /// </summary>
        /// <param name="stock">�݌Ƀ}�X�^</param>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <returns>���P��</returns>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�A���i�A���f�[�^��茴�P�����擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private Double GetStockUnitPrice(Stock stock, GoodsUnitData goodsUnitData)
        {
            Double stockUnitPrice = 0;

            // ���i�A���f�[�^����P���Z�o���ʃI�u�W�F�N�g���擾
            UnitPriceCalcRet unitPriceCalcRet = GetUnitPriceCalcRet(goodsUnitData);

            // �P���Z�o���ʃI�u�W�F�N�g��茴�P���擾
            stockUnitPrice = unitPriceCalcRet.UnitPriceTaxExcFl;

            return stockUnitPrice;
        }

        /// <summary>
        /// �P���Z�o���ʃI�u�W�F�N�g�擾����
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <returns>�P���Z�o���ʃI�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : ���i�A���f�[�^���P���Z�o���ʃI�u�W�F�N�g���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private UnitPriceCalcRet GetUnitPriceCalcRet(GoodsUnitData goodsUnitData)
        {
            // �P���Z�o�p�����[�^�ݒ�
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
            unitPriceCalcParam.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();    // ���_�R�[�h
            unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                               // ���i���[�J�[�R�[�h
            unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                                         // ���i�ԍ�
            unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                             // ���i�|�������N
            unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsMGroup;                            // ���i�|���O���[�v�R�[�h
            unitPriceCalcParam.BLGroupCode = goodsUnitData.BLGroupCode;                                 // BL�O���[�v�R�[�h
            unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                                 // BL���i�R�[�h
            unitPriceCalcParam.SupplierCd = goodsUnitData.SupplierCd;                                   // �d����R�[�h
            unitPriceCalcParam.PriceApplyDate = GetDate();                                              // ���i�K�p��
            unitPriceCalcParam.CountFl = 1;                                                             // ����
            unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                             // �ېŋ敪
            unitPriceCalcParam.TaxRate = TaxRateSetAcs.GetTaxRate(this._taxRateSet, GetDate());         // �ŗ�
            unitPriceCalcParam.StockCnsTaxFrcProcCd = goodsUnitData.StockCnsTaxFrcProcCd;               // �d������Œ[�������R�[�h
            unitPriceCalcParam.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd;                 // �d���P���[�������R�[�h

            List<UnitPriceCalcRet> unitPriceCalcRetList;
            this._unitPriceCalculation.CalculateUnitCost(unitPriceCalcParam, goodsUnitData, out unitPriceCalcRetList);

            foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
            {
                if (unitPriceCalcRetWk.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                {
                    return unitPriceCalcRetWk;
                }
            }

            return new UnitPriceCalcRet();
        }

        /// <summary>
        /// �ŗ��ݒ�}�X�^�擾����
        /// </summary>
        /// <remarks>
        /// Note       : �ŗ��ݒ�}�X�^���擾���܂��B<br />
        /// Programer  : 30414 �E �K�j<br />
        /// Date       : 2008/07/24<br />
        /// </remarks>
        public void ReadTaxRate()
        {
            int status;

            try
            {
                // �ŗ��ݒ�}�X�^�擾(�ŗ��R�[�h=0�Œ�)
                status = this._taxRateSetAcs.Read(out this._taxRateSet, LoginInfoAcquisition.EnterpriseCode, 0);
            }
            catch
            {
                this._taxRateSet = new TaxRateSet();
            }
        }

        /// <summary>
        /// ���i�A���f�[�^���X�g�擾����
        /// </summary>
        /// <param name="stockList">�݌Ƀ}�X�^���X�g</param>
        /// <param name="flag">�`�[�ԍ��Ō������邩�ǂ����𔻒f����p�̃t���O</param>
        /// <returns>���i�A���f�[�^���X�g</returns>
        /// <remarks>
        /// Note       : �݌Ƀ}�X�^���X�g��菤�i�A���f�[�^���X�g���擾���܂��B<br />
        /// Programer  : 30414 �E �K�j<br />
        /// Date       : 2008/07/24<br />
        /// </remarks>
        private List<GoodsUnitData> GetGoodsUnitDataList(List<Stock> stockList, params bool[] flag)//add 2011/12/13 ���� Redmine #26816
        //private List<GoodsUnitData> GetGoodsUnitDataList(List<Stock> stockList)//del 2011/12/13 ���� Redmine #26816
        {
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();

            if ((stockList == null) || (stockList.Count == 0))
            {
                return goodsUnitDataList;
            }

            int status;
            string errMsg;
            List<GoodsUnitData> retGoodsUnitDataList;

            foreach (Stock stock in stockList)
            {
                GoodsUnitData goodsUnitData = new GoodsUnitData();

                // ���i�A���f�[�^���������ݒ�
                GoodsCndtn goodsCndtn;
                SetGoodsCndtn(out goodsCndtn, stock.EnterpriseCode, stock.GoodsMakerCd, stock.GoodsNo, GetStockSectionCode());

                try
                {
                    // ���i����
                    status = GetGoodsUnitDataList(goodsCndtn, out retGoodsUnitDataList, out errMsg, flag);//add 2011/12/13 ���� Redmine #26816
                    //status = GetGoodsUnitDataList(goodsCndtn, out retGoodsUnitDataList, out errMsg);//del 2011/12/13 ���� Redmine #26816
                    if (status == 0)
                    {
                        goodsUnitData = retGoodsUnitDataList[0];
                    }
                    else
                    {
                        goodsUnitData = new GoodsUnitData();
                    }
                }
                catch
                {
                    goodsUnitData = new GoodsUnitData();
                }

                goodsUnitDataList.Add(goodsUnitData);
            }

            return goodsUnitDataList;
        }

        /// <summary>
        /// ���i�A���f�[�^���X�g�擾����
        /// </summary>
        /// <param name="goodsCndtn">���i�A���f�[�^��������</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^���X�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <param name="flag">�`�[�ԍ��Ō������邩�ǂ����𔻒f����p�̃t���O</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// Note       : ���i�A���f�[�^���X�g���擾���܂��B<br />
        /// Programer  : 30414 �E �K�j<br />
        /// Date       : 2008/07/24<br />
        /// </remarks>
        public int GetGoodsUnitDataList(GoodsCndtn goodsCndtn, out List<GoodsUnitData> goodsUnitDataList, out string errMsg, params bool[] flag)//add 2011/12/13 ���� Redmine #26816
        //public int GetGoodsUnitDataList(GoodsCndtn goodsCndtn, out List<GoodsUnitData> goodsUnitDataList, out string errMsg)//del 2011/12/13 ���� Redmine #26816
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            errMsg = "";
            goodsUnitDataList = new List<GoodsUnitData>();

            try
            {
                // 2009.02.19 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //status = this._goodsAcs.SearchGoods(goodsCndtn, out goodsUnitDataList, out errMsg);
                status = this._goodsAcs.SearchGoods(goodsCndtn, 3200, out goodsUnitDataList, out errMsg, flag);//add 2011/12/13 ���� Redmine #26816
                //status = this._goodsAcs.SearchGoods(goodsCndtn, 3200, out goodsUnitDataList, out errMsg);//del 2011/12/13 ���� Redmine #26816
                // 2009.02.19 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                if (status == 0)
                {
                    if ((goodsUnitDataList == null) || (goodsUnitDataList.Count == 0))
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        errMsg = "���i���̎擾�Ɏ��s���܂����B";
                        goodsUnitDataList = new List<GoodsUnitData>();

                        return (status);
                    }

                    if ((goodsUnitDataList[0].StockList == null) || (goodsUnitDataList[0].StockList.Count == 0))
                    {
                        // DEL 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ---------->>>>>
                        //status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        //errMsg = "�I���������i�͍݌ɏ��ɓo�^����Ă��܂���B";
                        // DEL 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ----------<<<<<
                        // ADD 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ---------->>>>>
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        errMsg = "�I���������i�͍݌ɓo�^����Ă��܂���B";
                        // ADD 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ----------<<<<<
                        // DEL 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ---------->>>>>
                        // MEMO:�݌ɂȂ����ł��������ʂ����������Ȃ�
                        //goodsUnitDataList = new List<GoodsUnitData>();
                        // DEL 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ----------<<<<<

                        return (status);
                    }
                }
                else if (status == -1)
                {
                    // --- ADD m.suzuki 2010/01/14 ---------->>>>>
                    // ����i�ԑI���E�B���h�E�ŃL�����Z�������Ƃ�
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                    errMsg = "";
                    goodsUnitDataList = new List<GoodsUnitData>();
                    // --- ADD m.suzuki 2010/01/14 ----------<<<<<
                }
                else
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    // DEL 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ---------->>>>>
                    //errMsg = "���͂����i�Ԃ͍݌ɏ��ɓo�^����Ă��܂���B";
                    // DEL 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ----------<<<<<
                    errMsg = "�I���������i�͏��i�o�^����Ă��܂���B";  // ADD 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ�
                    goodsUnitDataList = new List<GoodsUnitData>();

                    return (status);
                }
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMsg = "���i���̎擾�Ɏ��s���܂����B";
                goodsUnitDataList = new List<GoodsUnitData>();
            }

            return (status);
        }

        // 2010/07/14 Add >>>
        /// <summary>
        /// ���i�A���f�[�^���X�g�擾����
        /// </summary>
        /// <param name="goodsCndtn">���i�A���f�[�^��������</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^���X�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// Note       : ���i�A���f�[�^���X�g���擾���܂��B<br />
        /// Programer  : 30517 �Ė� �x��<br />
        /// Date       : 2010/07/14<br />
        /// </remarks>
        public int GetGoodsUnitDataList(GoodsCndtn goodsCndtn, out List<GoodsUnitData> goodsUnitDataList, out string errMsg, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            errMsg = "";
            goodsUnitDataList = new List<GoodsUnitData>();

            try
            {
                // 2009.02.19 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //status = this._goodsAcs.SearchGoods(goodsCndtn, out goodsUnitDataList, out errMsg);
                status = this._goodsAcs.Search(goodsCndtn, logicalMode, out goodsUnitDataList, out errMsg);
                // 2009.02.19 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                if (status == 0)
                {
                    if ((goodsUnitDataList == null) || (goodsUnitDataList.Count == 0))
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        errMsg = "���i���̎擾�Ɏ��s���܂����B";
                        goodsUnitDataList = new List<GoodsUnitData>();

                        return (status);
                    }

                    if ((goodsUnitDataList[0].StockList == null) || (goodsUnitDataList[0].StockList.Count == 0))
                    {
                        // DEL 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ---------->>>>>
                        //status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        //errMsg = "�I���������i�͍݌ɏ��ɓo�^����Ă��܂���B";
                        // DEL 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ----------<<<<<
                        // ADD 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ---------->>>>>
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        errMsg = "�I���������i�͍݌ɓo�^����Ă��܂���B";
                        // ADD 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ----------<<<<<
                        // DEL 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ---------->>>>>
                        // MEMO:�݌ɂȂ����ł��������ʂ����������Ȃ�
                        //goodsUnitDataList = new List<GoodsUnitData>();
                        // DEL 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ----------<<<<<

                        return (status);
                    }
                }
                else if (status == -1)
                {
                    // --- ADD m.suzuki 2010/01/14 ---------->>>>>
                    // ����i�ԑI���E�B���h�E�ŃL�����Z�������Ƃ�
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                    errMsg = "";
                    goodsUnitDataList = new List<GoodsUnitData>();
                    // --- ADD m.suzuki 2010/01/14 ----------<<<<<
                }
                else
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    // DEL 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ---------->>>>>
                    //errMsg = "���͂����i�Ԃ͍݌ɏ��ɓo�^����Ă��܂���B";
                    // DEL 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ----------<<<<<
                    errMsg = "�I���������i�͏��i�o�^����Ă��܂���B";  // ADD 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ�
                    goodsUnitDataList = new List<GoodsUnitData>();

                    return (status);
                }
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMsg = "���i���̎擾�Ɏ��s���܂����B";
                goodsUnitDataList = new List<GoodsUnitData>();
            }

            return (status);
        }
        // 2010/07/14 Add <<<

        /// <summary>
        /// �����^�C�v�擾����
        /// </summary>
        /// <param name="inputCode">���͂��ꂽ�R�[�h</param>
        /// <param name="searchCode">�����p�R�[�h�i*�������j</param>
        /// <returns>0:���S��v���� 1:�O����v���� 2:�����v���� 3:�B������ 4:�n�C�t���������S��v</returns>
        /// <remarks>
        /// Note       : ���i�����^�C�v���擾���܂��B<br />
        /// Programer  : 30414 �E �K�j<br />
        /// Date       : 2008/07/24<br />
        /// </remarks>
        public int GetSearchType(string inputCode, out string searchCode)
        {
            searchCode = inputCode;
            if (String.IsNullOrEmpty(inputCode)) return 0;

            if (inputCode.Contains("*"))
            {
                searchCode = inputCode.Replace("*", "");
                string firstString = inputCode.Substring(0, 1);
                string lastString = inputCode.Substring(inputCode.Length - 1, 1);

                if (lastString == "*")
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                // *�����݂��Ȃ�
                if (searchCode.Contains("-") == true)
                {
                    // �n�C�t���܂�
                    return 0;
                }
                else
                {
                    // �n�C�t���܂܂Ȃ�
                    return 4;
                }
            }
        }

        /// <summary>
        /// ���i�A���f�[�^���������ݒ菈��
        /// </summary>
        /// <param name="goodsCndtn">���i�A���f�[�^��������</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <remarks>
        /// Note       : ���i�A���f�[�^����������ݒ肵�܂��B<br />
        /// Programer  : 30414 �E �K�j<br />
        /// Date       : 2008/07/24<br />
        /// </remarks>
        public void SetGoodsCndtn(out GoodsCndtn goodsCndtn, string enterpriseCode, int makerCode, string goodsNo, string sectionCode)
        {
            string searchCode;

            goodsCndtn = new GoodsCndtn();
            goodsCndtn.EnterpriseCode = enterpriseCode;                         // ��ƃR�[�h
            goodsCndtn.GoodsMakerCd = makerCode;                                // ���[�J�[�R�[�h
            goodsCndtn.GoodsNoSrchTyp = GetSearchType(goodsNo, out searchCode); // ���i�ԍ������敪
            goodsCndtn.GoodsNo = searchCode;                                    // �i��
            goodsCndtn.GoodsKindCode = 9;                                       // ���i����(�S��)
            goodsCndtn.SectionCode = sectionCode;                               // ���_�R�[�h
        }

        /// <summary>
        /// �݌Ƀ}�X�^�擾����
        /// </summary>
        /// <param name="stockAdjustDtlList">�݌ɒ����f�[�^���X�g</param>
        /// <returns>�݌Ƀ}�X�^���X�g</returns>
        /// <remarks>
        /// Note       : �݌ɒ������׃f�[�^���X�g���݌Ƀ}�X�^���X�g���擾���܂��B<br />
        /// Programer  : 30414 �E �K�j<br />
        /// Date       : 2008/07/24<br />
        /// </remarks>
        private List<Stock> GetStockList(StockAdjust stockAdjust, List<StockAdjustDtl> stockAdjustDtlList)
        {
            List<Stock> stockList = new List<Stock>();

            string errMsg;
            int status;
            bool stockFlg = false;

            try
            {
                List<Stock> retList;
                StockSearchPara stockSearchPara;

                // �݌ɒ������׃f�[�^�̐������݌Ƀ}�X�^���擾���܂�
                foreach (StockAdjustDtl stockAdjustDtl in stockAdjustDtlList)
                {
                    stockFlg = false;

                    stockSearchPara = new StockSearchPara();
                    stockSearchPara.EnterpriseCode = stockAdjustDtl.EnterpriseCode;
                    //stockSearchPara.SectionCode = stockAdjust.StockSectionCd;
                    stockSearchPara.GoodsMakerCd = stockAdjustDtl.GoodsMakerCd;
                    stockSearchPara.GoodsNo = stockAdjustDtl.GoodsNo.Trim();
                    stockSearchPara.WarehouseCode = stockAdjustDtl.WarehouseCode;

                    // �݌Ƀ}�X�^����
                    status = this._searchStockAcs.Search(stockSearchPara, out retList, out errMsg);
                    if (status == 0)
                    {
                        foreach (Stock stock in retList)
                        {
                            stockList.Add(stock);
                            stockFlg = true;
                            break;
                        }

                        if (!stockFlg)
                        {
                            stockList.Add(new Stock());
                        }
                    }
                    else
                    {
                        stockList.Add(new Stock());
                    }
                }
            }
            catch
            {
                stockList = new List<Stock>();
            }

            return stockList;
        }

        /// <summary>
        /// �݌Ƀ}�X�^�擾����
        /// </summary>
        /// <param name="orderListResultWorkList">�����c�Ɖ���[�g���o���ʃ��X�g</param>
        /// <returns>�݌Ƀ}�X�^���X�g</returns>
        /// <remarks>
        /// Note       : �����c�Ɖ���[�g���o���ʃ��X�g���݌Ƀ}�X�^���X�g���擾���܂��B<br />
        /// Programer  : 30414 �E �K�j<br />
        /// Date       : 2008/07/24<br />
        /// </remarks>
        private List<Stock> GetStockList(List<OrderListResultWork> orderListResultWorkList)
        {
            List<Stock> stockList = new List<Stock>();

            string errMsg;
            int status;
            bool stockFlg = false;

            try
            {
                List<Stock> retList;
                StockSearchPara stockSearchPara;

                // �݌ɒ������׃f�[�^�̐������݌Ƀ}�X�^���擾���܂�
                foreach (OrderListResultWork orderListResultWork in orderListResultWorkList)
                {
                    stockFlg = false;

                    stockSearchPara = new StockSearchPara();
                    stockSearchPara.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                    stockSearchPara.SectionCode = orderListResultWork.SectionCode;
                    stockSearchPara.GoodsMakerCd = orderListResultWork.GoodsMakerCd;
                    stockSearchPara.GoodsNo = orderListResultWork.GoodsNo.Trim();
                    stockSearchPara.WarehouseCode = orderListResultWork.WarehouseCode;

                    // �݌Ƀ}�X�^����
                    status = this._searchStockAcs.Search(stockSearchPara, out retList, out errMsg);
                    if (status == 0)
                    {
                        foreach (Stock stock in retList)
                        {
                            stockList.Add(stock);
                            stockFlg = true;
                            break;
                        }

                        if (!stockFlg)
                        {
                            stockList.Add(new Stock());
                        }
                    }
                    else
                    {
                        stockList.Add(new Stock());
                    }
                }
            }
            catch
            {
                stockList = new List<Stock>();
            }

            return stockList;
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        #region 2007.10.11 �폜
        // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
		///// �`�[���׃f�[�^�ǉ��E�}���E�X�V�O����
		///// </summary>
		///// <param name="data">�Ώۖ��׃f�[�^</param>
		///// <param name="isUpdate">T:�X�V, F:�ǉ��E�}��</param>
		//private static void PreprocessSlipDtlInfoProc(ref ProductStock data, bool isUpdate)
		//{
		//	// �_���폜����Ă����Ȃ�����
		//	if (data.LogicalDeleteCode == 0)
		//	{
		//		if (isUpdate)
		//		{
		//			// �d�����ו�GUID�����ݒ�̏ꍇ
		//			if (data.ProductStockGuid == Guid.Empty)
		//			{
		//				// �d�����ו�GUID��ݒ�
		//				data.ProductStockGuid = Guid.NewGuid();
		//			}
		//		}
		//		else
		//		{
		//			// �d�����ו�GUID��ݒ�
		//			data.ProductStockGuid = Guid.NewGuid();
		//		}
		//	}
		//}
        // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
        #endregion 2007.10.11 �폜

        #region DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// �s�t�B���^�[���`����
		/// </summary>
		/// <param name="rowFilter">�s�t�B���^�[������</param>
		/// <returns>���`��̍s�t�B���^�[������</returns>
		private static string FormRowFilter(string rowFilter)
		{
			string retFilter = rowFilter.Trim();

			// �t�B���^�[�̐ݒ�(�_���폜�s��ΏۊO�Ƃ���)
			if (retFilter.Length == 0)
			{
				retFilter = string.Format("{0} = 0", ctCOL_LogicalDeleteCode);
			}
			else
			{
				retFilter = string.Format("({0}) AND {1} = 0", retFilter, ctCOL_LogicalDeleteCode);
			}

			return retFilter;
		}
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        /// <summary>
        /// ���׍s����������
        /// </summary>
        public static int IncrementProductStock()
        {
            return IncrementSlipDtl();
        }

        /// <summary>
        /// ���׏���������
        /// </summary>
        public static int RepaintProductStock()
        {
            string msg;
            return CreateDummySlipDtl(out msg);
        }

		/// <summary>
		/// ���׍s����������
		/// </summary>
		/// <returns>0:����, �ȊO:���s</returns>
		private static int IncrementSlipDtl()
		{
			int wkCnt = maxRowCnt + ctCOUNT_RowAdd;
			if (wkCnt > ctCOUNT_RowMax)
			{
				if (ctCOUNT_RowMax - maxRowCnt > 0)
				{
					maxRowCnt = ctCOUNT_RowMax;
				}
				else
				{
					return (int)ConstantManagement.MethodResult.ctFNC_WARNING;
				}
			}
			else
			{
				maxRowCnt = wkCnt;
			}

			string msg;
			return CreateDummySlipDtl(out msg);       
        }

        #region DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �������ʔ��f����
        /// </summary>        
        public int ShowSelectData(out string retMessage)
        {
            int status = 0;
            retMessage = "";
            return status;
        }
        
        public int DbRowCount()
        {
            return _mainProductStockView.Count;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// DB�f�[�^�Ǎ�����
        /// </summary>
        /// <param name="stockAdjustSlipNo">�݌ɒ����`�[�ԍ�</param>
        /// <param name="stockAdjust">�݌ɒ����f�[�^</param>
        /// <param name="stockAdjustDtlList">�݌ɒ������׃f�[�^�̃��X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// Note       : �݌ɒ����`�[�ԍ����݌ɒ����f�[�^�ƍ݌ɒ������׃f�[�^���X�g���擾���܂��B<br />
        /// Programer  : 30414 �E �K�j<br />
        /// Date       : 2008/07/24<br />
        /// </remarks>
        public int ReadDBData(int stockAdjustSlipNo, out StockAdjust stockAdjust, out List<StockAdjustDtl> stockAdjustDtlList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            stockAdjust = new StockAdjust();
            stockAdjustDtlList = new List<StockAdjustDtl>();

            ArrayList retList = new ArrayList();
            ArrayList retListDtl = new ArrayList();

            try
            {
                status = this._iStockAdjustDB.SearchSlipAndDtl(LoginInfoAcquisition.EnterpriseCode, stockAdjustSlipNo, ref retList, ref retListDtl);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            stockAdjust = CopyToStockAdjustFromStockAdjustWork((StockAdjustWork)retList[0]);

                            foreach (StockAdjustDtlWork stockAdjustDtlWork in retListDtl)
                            {
                                stockAdjustDtlList.Add(CopyToStockAdjustDtlFromStockAdjustDtlWork(stockAdjustDtlWork));
                            }
                            break;
                        }
                    default:
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                            stockAdjust = new StockAdjust();
                            stockAdjustDtlList = new List<StockAdjustDtl>();
                            break;
                        }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                stockAdjust = new StockAdjust();
                stockAdjustDtlList = new List<StockAdjustDtl>();
            }

            return (status);
        }

        /// <summary>
        /// DB�o�^����
        /// </summary>
        /// <param name="stockAdjustSlipNo">�݌ɒ����`�[�ԍ�</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <param name="priceUpdateFlg">���i�}�X�^�X�V�t���O(True:�X�V�@False:��X�V)</param>
        /// <param name="orderListResultFlg">�����c�����C���t���O(True:�C���@Fales:��C��)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �݌ɒ����f�[�^��o�^���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public int SaveDBData(out int stockAdjustSlipNo, out string retMessage, out bool isNew, bool priceUpdateFlg, bool orderListResultFlg)
        {
            isNew = true;

            CustomSerializeArrayList registList = new CustomSerializeArrayList();

            ArrayList stockAdjustWorkList = new ArrayList();
            ArrayList stockAdjustDtlWorkList = new ArrayList();
            ArrayList goodsPriceWorkList = new ArrayList();

            StockAdjust stockAdjust;
            StockAdjustDtl stockAdjustDtl;
            GoodsPrice goodsPrice;

            // �ۑ��p�f�[�^
            // DEL 2009/06/17 ------>>>
            //Dictionary<string, DataRow> saveStokRowDic = new Dictionary<string, DataRow>();
            //int makerCode;
            //string goodsNo;
            //string key;
            
            //for (int index = 0; index < _mainProductStock.Rows.Count; index++)
            //{
            //    if ((_mainProductStock.Rows[index][ctCOL_FileHeaderGuid] == DBNull.Value) ||
            //        ((Guid)_mainProductStock.Rows[index][ctCOL_FileHeaderGuid] == Guid.Empty))
            //    {
            //        continue;
            //    }

            //    // Key�쐬
            //    makerCode = StringObjToInt(_mainProductStock.Rows[index][ctCOL_GoodsMakerCd]);
            //    goodsNo = (string)_mainProductStock.Rows[index][ctCOL_GoodsNo];
            //    key = makerCode.ToString("0000") + goodsNo.Trim();

            //    if (saveStokRowDic.ContainsKey(key))
            //    {
            //        // ����i�Ԃ����݂���ꍇ�́A�d���������Z
            //        saveStokRowDic[key][ctCOL_SalesOrderUnit] = (double)saveStokRowDic[key][ctCOL_SalesOrderUnit] +
            //                                                    (double)_mainProductStock.Rows[index][ctCOL_SalesOrderUnit];
            //        saveStokRowDic[key][ctCOL_BfStockUnitPrice] = (double)_mainProductStock.Rows[index][ctCOL_BfStockUnitPrice];
            //        saveStokRowDic[key][ctCOL_StockUnitPrice] = (double)_mainProductStock.Rows[index][ctCOL_StockUnitPrice];
            //        saveStokRowDic[key][ctCOL_ListPriceFl] = (double)_mainProductStock.Rows[index][ctCOL_ListPriceFl];
            //    }
            //    else
            //    {
            //        // �ۑ��p�f�[�^�ɒǉ�
            //        saveStokRowDic.Add(key, _mainProductStock.Rows[index]);
            //    }
            //}
            // DEL 2009/06/17 ------<<<

            // ADD 2009/06/17 ------>>>
            Dictionary<int, DataRow> saveStokRowDic = new Dictionary<int, DataRow>();
            
            for (int index = 0; index < _mainProductStock.Rows.Count; index++)
            {
                if ((_mainProductStock.Rows[index][ctCOL_FileHeaderGuid] == DBNull.Value) ||
                    ((Guid)_mainProductStock.Rows[index][ctCOL_FileHeaderGuid] == Guid.Empty))
                {
                    continue;
                }

                if (!saveStokRowDic.ContainsKey(index))
                {
                    // �ۑ��p�f�[�^�ɒǉ�
                    saveStokRowDic.Add(index, _mainProductStock.Rows[index]);
                }
            }
            // ADD 2009/06/17 ------<<<
            
            int count = 0;
            foreach (DataRow dataRow in saveStokRowDic.Values)
            {
                // �ύX�O�̍݌ɒ����f�[�^���擾
                stockAdjust = (StockAdjust)dataRow[ctCOL_StockAdjust];

                // �ύX�O�̍݌ɒ������׃f�[�^���擾
                stockAdjustDtl = (StockAdjustDtl)dataRow[ctCOL_StockAdjustDtl];

                // ��ʏ��𔽉f
                GetScreenInfo(ref stockAdjust, ref stockAdjustDtl, dataRow, orderListResultFlg);

                if (stockAdjust.FileHeaderGuid == Guid.Empty)
                {
                    isNew = true;
                }
                else
                {
                    isNew = false;
                }

                // �݌ɒ����f�[�^�͂P���R�[�h�����쐬
                if (count == 0)
                {
                    // �݌ɒ����f�[�^�ǉ�
                    stockAdjustWorkList.Add(CopyToStockAdjustWorkFromStockAdjust(stockAdjust));
                }

                // �݌ɒ������׃f�[�^�ǉ�
                stockAdjustDtlWorkList.Add(CopyToStockAdjustDtlWorkFromStockAdjustDtl(stockAdjustDtl));

                if (priceUpdateFlg == true)
                {
                    // �X�V�Ώۂ̉��i�}�X�^���擾
                    if (dataRow[ctCOL_GoodsPrice] == DBNull.Value)
                    {
                        goodsPrice = new GoodsPrice();
                        goodsPrice.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                        goodsPrice.PriceStartDate = GetDate();
                        goodsPrice.GoodsMakerCd = StringObjToInt(dataRow[ctCOL_GoodsMakerCd]);
                        goodsPrice.GoodsNo = (string)dataRow[ctCOL_GoodsNo];
                    }
                    else
                    {
                        goodsPrice = (GoodsPrice)dataRow[ctCOL_GoodsPrice];
                    }
                    goodsPrice.ListPrice = (double)dataRow[ctCOL_ListPriceFl]; ;          // �艿
                    goodsPrice.SalesUnitCost = (double)dataRow[ctCOL_StockUnitPrice];     // ����

                    // ���i�}�X�^�ǉ�
                    goodsPriceWorkList.Add(CopyToGoodsPriceUWorkFromGoodsPrice(goodsPrice));
                }

                count++;
            }

            registList.Add(stockAdjustWorkList);
            registList.Add(stockAdjustDtlWorkList);

            if (priceUpdateFlg == true)
            {
                registList.Add(goodsPriceWorkList);
            }
            
            object paraObj = registList;

            // �o�^����
            int status;
            stockAdjustSlipNo = 0;
            retMessage = "";

            try
            {
                status = this._iStockAdjustDB.Write(ref paraObj, out retMessage);
                if (status == 0)
                {
                    CustomSerializeArrayList retList = (CustomSerializeArrayList)paraObj;
                    stockAdjustWorkList = (ArrayList)retList[0];
                    StockAdjustWork stockAdjustWork = (StockAdjustWork)stockAdjustWorkList[0];
                    
                    // �݌ɒ����`�[�ԍ��擾
                    stockAdjustSlipNo = stockAdjustWork.StockAdjustSlipNo;
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// DB�폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �݌ɒ����f�[�^���폜���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public int DeleteDBData(out int slipNo)
        {
            slipNo = 0;

            CustomSerializeArrayList deleteList = new CustomSerializeArrayList();

            ArrayList stockAdjustWorkList = new ArrayList();
            ArrayList stockAdjustDtlWorkList = new ArrayList();

            StockAdjust stockAdjust;
            StockAdjustDtl stockAdjustDtl;

            // �ۑ��p�f�[�^
            Dictionary<string, DataRow> deleteStokRowDic = new Dictionary<string, DataRow>();

            for (int index = 0; index < _mainProductStock.Rows.Count; index++)
            {
                if ((_mainProductStock.Rows[index][ctCOL_FileHeaderGuid] == DBNull.Value) ||
                    ((Guid)_mainProductStock.Rows[index][ctCOL_FileHeaderGuid] == Guid.Empty))
                {
                    continue;
                }

                // �ύX�O�̍݌ɒ����f�[�^���擾
                stockAdjust = (StockAdjust)_mainProductStock.Rows[index][ctCOL_StockAdjust];
                slipNo = stockAdjust.StockAdjustSlipNo;

                // �ύX�O�̍݌ɒ������׃f�[�^���擾
                stockAdjustDtl = (StockAdjustDtl)_mainProductStock.Rows[index][ctCOL_StockAdjustDtl];

                // �݌ɒ����f�[�^�͂P���R�[�h�����쐬
                if (index == 0)
                {
                    // �݌ɒ����f�[�^�ǉ�
                    stockAdjustWorkList.Add(CopyToStockAdjustWorkFromStockAdjust(stockAdjust));
                }

                // �݌ɒ������׃f�[�^�ǉ�
                stockAdjustDtlWorkList.Add(CopyToStockAdjustDtlWorkFromStockAdjustDtl(stockAdjustDtl));
            }

            deleteList.Add(stockAdjustWorkList);
            deleteList.Add(stockAdjustDtlWorkList);

            object paraObj = deleteList;
            string errMsg;

            // �o�^����
            int status;

            try
            {
                status = this._iStockAdjustDB.Delete(ref paraObj, out errMsg);
            }
            catch
            {
                status = -1;
            }

            return (status);
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/24 Partsman�p�ɕύX
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// DB�o�^����
        /// </summary>
        /// <param name="retMessage"></param>
        public int SaveDBData(out string retMessage, int mode, string setMsg, DateTime adjustDate)
        {
            CustomSerializeArrayList registList = new CustomSerializeArrayList();

            // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //���ԍ݌Ɏ擾
            //ArrayList productArray = this.GetCurrentProductStock(mode);
            ////�݌�
            //ArrayList stockArray = this.GetCurrentStock(mode,productArray);
            //�݌�
            ArrayList stockArray = this.GetCurrentStock(mode);
            // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<

            registList.Add(stockArray);

            // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
            ////���ԍ݌�
            //if ((mode != ctMode_StockAdjust) &&(mode != ctMode_TrustAdjust) && (mode != ctMode_ProductReEdit))
            //{
            //    if (productArray.Count > 0)
            //    {
            //        registList.Add(productArray);
            //    }
            //}
            //else
            //{
            //    if (productArray.Count > 0)
            //    {
            //        //�݌ɂ̂݁E���ԒP�ʓ���q����
            //        registList.Add(productArray);
            //    }
            //}
            // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
            //����
            ArrayList stockAdjustArray = this.GetStockAdjust(mode, adjustDate, setMsg);
            registList.Add(stockAdjustArray);
            //��������
            ArrayList stockAdjustDtlArray = this.GetStockAdjustDtl(mode);
            registList.Add(stockAdjustDtlArray);
            object setObj = (object)registList;

            int status = 0;
            // �o�^
            status = this._iStockAdjustDB.Write(ref setObj, out retMessage);

            return status;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman�p�ɕύX

        /// <summary>
        /// DB�o�^�p���N���A(GRID�N���A)
        /// </summary>
        public void DBDataClear()
        {
            _mainProductStock.Clear();
        }

        /*
                /// <summary>
                /// �o�^�p�݌Ƀf�[�^�擾����
                /// </summary>
                private ArrayList GetCurrentStock(int mode,ArrayList productList)
                {
                    ArrayList retList = new ArrayList();
                    ArrayList chkList = new ArrayList();
            
                    //�݌Ƀf�[�^���Z�b�g
                    foreach(Stock stockRet in _stockList)
                    {
                        //���Ԃɑ��݂��邩�`�F�b�N���A�]�v�ȍ݌ɂ��폜
                        retList.Add(CopyToStockWorkFromStock(stockRet, mode));
                    }

                    return retList;
                }
        */

        #region DEL 2008/07/24 Partsman�p�ɕύX
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        //private ArrayList GetCurrentStock(int mode, ArrayList productList)
        private ArrayList GetCurrentStock(int mode)
        // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        {
            ArrayList retList = new ArrayList();
            ArrayList chkList = new ArrayList();

            //�݌Ƀf�[�^���Z�b�g
            // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //foreach (StockEachWarehouse stockRet in _stockList)
            foreach (StockExpansion stockRet in _stockList)
            // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            {
                retList.Add(CopyToStockWorkFromStock(stockRet, mode));
            }
            return retList;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman�p�ɕύX

        #region DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �݌ɑ��݃`�F�b�N
        /// </summary>
        private bool ChkStockExist(Stock stock,ArrayList productList)
        {
            bool result = false;
            result = true;

            return result;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #region 2007.10.11 �폜
        // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// �o�^�p���ԍ݌Ƀf�[�^�擾����
        ///// </summary>
        //private ArrayList GetCurrentProductStock(int mode)
        //{
        //    ArrayList retList = new ArrayList();
        //    if ((mode == ctMode_StockAdjust) || (mode == ctMode_TrustAdjust))
        //    {
        //        //�݌ɒ���
        //	    for (int i = 0; i < _mainProductStockView.Count; i++)
		//	    {
        //            if (_mainProductStockView[i].Row[ctCOL_AdjustCount] == DBNull.Value)
        //            {
        //                continue;
        //            }
        //            if ((double)_mainProductStockView[i].Row[ctCOL_AdjustCount] == 0)
        //            {
        //                continue;
        //            }
        //            // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
        //            //// ���ԃ}�X�^�̂ݏ�����
        //            //if ((Int32)_mainProductStockView[i].Row[ctCOL_RowType] == 1)
        //            //{
        //            //    // �擾�f�[�^��WORK�փZ�b�g(GRID��DATASET��WORK)
        //            //    retList.Add(CopyToProductWorkFromProductStock(DataRowToProductStock(_mainProductStockView[i].Row,mode)));
        //            //}
        //            // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
        //        }
        //    }
        //    else if (mode == ctMode_UnitPriceReEdit)
        //    {
        //        //��������
        //        for (int i = 0; i < _mainProductStockView.Count; i++)
        //        {
        //            // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
        //            //if ((Int32)_mainProductStockView[i].Row[ctCOL_RowType] == 1)
        //            //{
        //            //    // �擾�f�[�^��WORK�փZ�b�g(GRID��DATASET��WORK)
        //            //    retList.Add(CopyToProductWorkFromProductStock(DataRowToProductStock(_mainProductStockView[i].Row, mode)));
        //            //}
        //            // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
        //        }
        //    }
        //    else if (mode == ctMode_ProductReEdit || mode == ctMode_GoodsCodeStatus)
        //    {
        //        //���ԕύX or �s�Ǖi(�K�����ԒP��)
        //        for (int i = 0; i < _mainProductStockView.Count; i++)
        //        {
        //            if (_mainProductStockView[i].Row[ctCOL_ProductNumber] == System.DBNull.Value)
        //            {
        //                continue;
        //            }
        //
        //            // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
        //            //// ���ԃ}�X�^�̂ݏ�����
        //            //if ((Int32)_mainProductStockView[i].Row[ctCOL_RowType] == 1)
        //            //{
        //            //    // �擾�f�[�^��WORK�փZ�b�g(GRID��DATASET��WORK)
        //            //    retList.Add(CopyToProductWorkFromProductStock(DataRowToProductStock(_mainProductStockView[i].Row, mode)));
        //            //}
        //            // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
        //        }
        //    }
        //    return retList;
        //}
        // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region DEL 2008/07/24 Partsman�p�ɕύX
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �o�^�p�݌ɒ����f�[�^�擾����
        /// </summary>
        private ArrayList GetStockAdjust(int mode, DateTime adjustdate, string setMsg)
        {
            ArrayList retList = new ArrayList();
            // 2008.03.28 �C�� >>>>>>>>>>>>>>>>>>>>
            //retList.Add(CopyToStockAdjustWorkFromStockAdjust(DataRowToStockAdjust(_mainProductStockView[0].Row, mode, setMsg)));
            if (_mainProductStockView.Count > 0)
            {
                retList.Add(CopyToStockAdjustWorkFromStockAdjust(DataRowToStockAdjust(_mainProductStockView[0].Row, mode, setMsg)));
            }
            else
            {
                _mainProductStockView = new DataView(_mainProductStock);
                //_mainProductStockView.RowFilter = ctCOL_LogicalDeleteCode + " = 0";
                _mainProductStockView.RowFilter = ctCOL_RowNum + " = 1";
                retList.Add(CopyToStockAdjustWorkFromStockAdjust(DataRowToStockAdjust(_mainProductStockView[0].Row, mode, setMsg)));
            }
            // 2008.03.28 �C�� <<<<<<<<<<<<<<<<<<<<
            return retList;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman�p�ɕύX

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ��ʏ��擾����
        /// </summary>
        /// <param name="stockAdjust">�݌ɒ����f�[�^</param>
        /// <param name="stockAdjustDtl">�݌ɒ������׃f�[�^</param>
        /// <param name="dataRow">�Ώۍs</param>
        /// <param name="orderListResultFlg">�����c�����C���t���O</param>
        /// <remarks>
        /// <br>Note       : ��ʏ����擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void GetScreenInfo(ref StockAdjust stockAdjust, ref StockAdjustDtl stockAdjustDtl, DataRow dataRow, bool orderListResultFlg)
        {
            //------------------------------------------------------------
            // �݌ɒ����f�[�^
            //------------------------------------------------------------
            // ��ƃR�[�h
            stockAdjust.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // ���_�R�[�h
            stockAdjust.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            // �݌ɒ����`�[�ԍ�
            stockAdjust.StockAdjustSlipNo = (dataRow[ctCOL_StockAdjustSlipNo] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockAdjustSlipNo] : 0;
            // �󕥌��`�[�敪(�݌Ɏd��)
            stockAdjust.AcPaySlipCd = 13;
            // �󕥌�����敪(�݌ɐ�����)
            if (orderListResultFlg == true)
            {
                stockAdjust.AcPayTransCd = 10;
            }
            else
            {
                stockAdjust.AcPayTransCd = 30;
            }
            // �������t
            stockAdjust.AdjustDate = GetDate();
            // ���͓��t
            stockAdjust.InputDay = DateTime.Today;
            // �d�����_�R�[�h
            stockAdjust.StockSectionCd = GetStockSectionCode();
            // �d�����_����
            stockAdjust.StockSectionNm = GetSectionName(stockAdjust.StockSectionCd);
            // �d�����͎҃R�[�h
            stockAdjust.StockInputCode = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
            // �d�����͎Җ���
            stockAdjust.StockInputName = LoginInfoAcquisition.Employee.Name.Trim();
            if (stockAdjust.StockInputName.Length > 16)
            {
                stockAdjust.StockInputName = stockAdjust.StockInputName.Substring(0, 16);
            }
            // �d���S���҃R�[�h
            stockAdjust.StockAgentCode = GetInputAgentCode();
            // �d���S���Җ���
            stockAdjust.StockAgentName = GetEmployeeName(stockAdjust.StockAgentCode);
            if (stockAdjust.StockAgentName.Length > 16)
            {
                stockAdjust.StockAgentName = stockAdjust.StockAgentName.Substring(0, 16);
            }
            // �d�����z���v
            stockAdjust.StockSubttlPrice = GetSubttlPrice();
            // �`�[���l
            stockAdjust.SlipNote = GetSlipNote();

            //------------------------------------------------------------
            // �݌ɒ������׃f�[�^
            //------------------------------------------------------------
            // ��ƃR�[�h
            stockAdjustDtl.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // ���_�R�[�h
            stockAdjustDtl.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            // �݌ɒ����`�[�ԍ�
            stockAdjustDtl.StockAdjustSlipNo = (dataRow[ctCOL_StockAdjustSlipNo] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockAdjustSlipNo] : 0;
            // �݌ɒ����s�ԍ�
            stockAdjustDtl.StockAdjustRowNo = (Int32)dataRow[ctCOL_RowNum];
            // �d���`��(�d��)
            stockAdjustDtl.SupplierFormalSrc = (dataRow[ctCOL_SupplierFormalSrc] != DBNull.Value) ? (Int32)dataRow[ctCOL_SupplierFormalSrc] : 0;
            // �d�����גʔ�
            stockAdjustDtl.StockSlipDtlNumSrc = (dataRow[ctCOL_StockSlipDtlNumSrc] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockSlipDtlNumSrc] : 0;
            // �󕥌��`�[�敪(�݌Ɏd��)
            stockAdjustDtl.AcPaySlipCd = 13;
            // �󕥌�����敪(�݌ɒ�����)
            if (orderListResultFlg == true)
            {
                stockAdjustDtl.AcPayTransCd = 10;
            }
            else
            {
                stockAdjustDtl.AcPayTransCd = 30;
            }
            // �������t
            stockAdjustDtl.AdjustDate = GetDate();
            // ���͓��t
            stockAdjustDtl.InputDay = DateTime.Today;
            // ���[�J�[�R�[�h
            stockAdjustDtl.GoodsMakerCd = StringObjToInt(dataRow[ctCOL_GoodsMakerCd]);
            // ���[�J�[����
            stockAdjustDtl.MakerName = GetMakerName(stockAdjustDtl.GoodsMakerCd);
            // �i��
            stockAdjustDtl.GoodsNo = (dataRow[ctCOL_GoodsNo] != DBNull.Value) ? (string)dataRow[ctCOL_GoodsNo] : "";
            // �i��
            stockAdjustDtl.GoodsName = (dataRow[ctCOL_GoodsName] != DBNull.Value) ? (string)dataRow[ctCOL_GoodsName] : "";
            // �d���P��
            stockAdjustDtl.StockUnitPriceFl = (dataRow[ctCOL_StockUnitPrice] != DBNull.Value) ? (Double)dataRow[ctCOL_StockUnitPrice] : 0;
            // �ύX�O�d���P��
            stockAdjustDtl.BfStockUnitPriceFl = (dataRow[ctCOL_BfStockUnitPrice] != DBNull.Value) ? (Double)dataRow[ctCOL_BfStockUnitPrice] : 0;
            // ������(�d�������Z�b�g)
            stockAdjustDtl.AdjustCount = (double)dataRow[ctCOL_SalesOrderUnit];
            // ���ה��l
            stockAdjustDtl.DtlNote = (dataRow[ctCOL_DtlNote] != DBNull.Value) ? (string)dataRow[ctCOL_DtlNote] : "";
            // �q�ɃR�[�h
            stockAdjustDtl.WarehouseCode = (dataRow[ctCOL_WarehouseCode] != DBNull.Value) ? (string)dataRow[ctCOL_WarehouseCode] : "";
            // �q�ɖ���
            stockAdjustDtl.WarehouseName = GetWarehouseName(stockAdjustDtl.WarehouseCode);
            // BL���i�R�[�h
            stockAdjustDtl.BLGoodsCode = StringObjToInt(dataRow[ctCOL_BLGoodsCode]);
            // BL���i����
            stockAdjustDtl.BLGoodsFullName = GetBLGoodsName(stockAdjustDtl.BLGoodsCode);
            // �q�ɒI��
            stockAdjustDtl.WarehouseShelfNo = (dataRow[ctCOL_WarehouseShelfNo] != DBNull.Value) ? (string)dataRow[ctCOL_WarehouseShelfNo] : "";
            // �艿
            stockAdjustDtl.ListPriceFl = (dataRow[ctCOL_ListPriceFl] != DBNull.Value) ? (Double)dataRow[ctCOL_ListPriceFl] : 0;
            
            // �I�[�v�����i�敪
            stockAdjustDtl.OpenPriceDiv = (dataRow[ctCOL_OpenPriceDiv] != DBNull.Value) ? (Int32)dataRow[ctCOL_OpenPriceDiv] : 0;

            // �d�����z
            if ((dataRow[ctCOL_StockUnitPrice] == DBNull.Value) || ((double)dataRow[ctCOL_StockUnitPrice] == 0) ||
                (dataRow[ctCOL_SalesOrderUnit] == DBNull.Value) || ((double)dataRow[ctCOL_SalesOrderUnit] == 0))
            {
                stockAdjustDtl.StockPriceTaxExc = 0;
            }
            // ---ADD 2009/06/23 �s��Ή�[13602] ---------------------------------------------->>>>>
            //�V�K�o�^�̏ꍇ
            else if (stockAdjust.FileHeaderGuid == Guid.Empty)
            {
                stockAdjustDtl.StockPriceTaxExc = GetStockPriceTaxExc((double)dataRow[ctCOL_StockUnitPrice], (double)dataRow[ctCOL_SalesOrderUnit]);
            }
            // ---ADD 2009/06/23 �s��Ή�[13602] ----------------------------------------------<<<<<
            else
            {
                if (((double)dataRow[ctCOL_StockUnitPrice] != (double)dataRow[ctCOL_BfStockUnitPrice]) ||
                    ((double)dataRow[ctCOL_SalesOrderUnit] != (double)dataRow[ctCOL_BfSalesOrderUnit]))
                {
                    stockAdjustDtl.StockPriceTaxExc = GetStockPriceTaxExc((double)dataRow[ctCOL_StockUnitPrice], (double)dataRow[ctCOL_SalesOrderUnit]);
                }
                else
                {
                    stockAdjustDtl.StockPriceTaxExc = (long)dataRow[ctCOL_StockPriceTaxExc];
                }
            }

            // �d����
            stockAdjustDtl.SupplierCd = (dataRow[ctCOL_SupplierCd] != DBNull.Value) ? int.Parse((string)dataRow[ctCOL_SupplierCd]) : 0;
            // �d���旪��
            stockAdjustDtl.SupplierSnm = (dataRow[ctCOL_SupplierSnm] != DBNull.Value) ? (string)dataRow[ctCOL_SupplierSnm] : "";
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(�݌ɒ����f�[�^���݌ɒ����f�[�^���[�N)
        /// </summary>
        /// <param name="stockAdjust">�݌ɒ����f�[�^</param>
        /// <returns>�݌ɒ����f�[�^���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : �݌ɒ����f�[�^���݌ɒ����f�[�^���[�N�N���X�ɃR�s�[���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private StockAdjustWork CopyToStockAdjustWorkFromStockAdjust(StockAdjust stockAdjust)
        {
            StockAdjustWork stockAdjustWork = new StockAdjustWork();

            stockAdjustWork.CreateDateTime = stockAdjust.CreateDateTime;                // �쐬����
            stockAdjustWork.UpdateDateTime = stockAdjust.UpdateDateTime;                // �X�V����
            stockAdjustWork.EnterpriseCode = stockAdjust.EnterpriseCode;                // ��ƃR�[�h
            stockAdjustWork.FileHeaderGuid = stockAdjust.FileHeaderGuid;                // GUID
            stockAdjustWork.UpdEmployeeCode = stockAdjust.UpdEmployeeCode;              // �X�V�]�ƈ��R�[�h
            stockAdjustWork.UpdAssemblyId1 = stockAdjust.UpdAssemblyId1;                // �X�V����Ԃ�ID1
            stockAdjustWork.UpdAssemblyId2 = stockAdjust.UpdAssemblyId2;                // �X�V�A�Z���u��ID2
            stockAdjustWork.LogicalDeleteCode = stockAdjust.LogicalDeleteCode;          // �_���폜�敪
            stockAdjustWork.SectionCode = stockAdjust.SectionCode;                      // ���_�R�[�h
            stockAdjustWork.SectionGuideNm = GetSectionName(stockAdjust.SectionCode);  // ���_����
            stockAdjustWork.StockAdjustSlipNo = stockAdjust.StockAdjustSlipNo;          // �݌ɒ����`�[�ԍ�
            stockAdjustWork.AcPaySlipCd = stockAdjust.AcPaySlipCd;                      // �󕥌��`�[�敪
            stockAdjustWork.AcPayTransCd = stockAdjust.AcPayTransCd;                    // �󕥌�����敪
            stockAdjustWork.AdjustDate = stockAdjust.AdjustDate;                        // �������t
            stockAdjustWork.InputDay = stockAdjust.InputDay;                            // ���͓��t
            stockAdjustWork.StockSectionCd = stockAdjust.StockSectionCd;                // �d�����_�R�[�h
            stockAdjustWork.StockSectionGuideNm = GetSectionName(stockAdjust.StockSectionCd);   // �d�����_����
            stockAdjustWork.StockInputCode = stockAdjust.StockInputCode;                // �d�����͎҃R�[�h
            stockAdjustWork.StockInputName = GetEmployeeName(stockAdjust.StockInputCode);       // �d�����͎Җ���
            if (stockAdjustWork.StockInputName.Length > 16)
            {
                stockAdjustWork.StockInputName = stockAdjustWork.StockInputName.Substring(0, 16);
            }
            stockAdjustWork.StockAgentCode = stockAdjust.StockAgentCode;                // �d���S���҃R�[�h
            stockAdjustWork.StockAgentName = GetEmployeeName(stockAdjust.StockAgentCode);       // �d���S���Җ���
            if (stockAdjustWork.StockAgentName.Length > 16)
            {
                stockAdjustWork.StockAgentName = stockAdjustWork.StockAgentName.Substring(0, 16);
            }
            stockAdjustWork.StockSubttlPrice = stockAdjust.StockSubttlPrice;            // �d�����z���v
            stockAdjustWork.SlipNote = stockAdjust.SlipNote;                            // �`�[���l

            return stockAdjustWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(�݌ɒ������׃f�[�^���݌ɒ������׃f�[�^���[�N)
        /// </summary>
        /// <param name="stockAdjustDtl">�݌ɒ������׃f�[�^</param>
        /// <returns>�݌ɒ������׃f�[�^���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : �݌ɒ������׃f�[�^���݌ɒ������׃f�[�^���[�N�N���X�ɃR�s�[���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private StockAdjustDtlWork CopyToStockAdjustDtlWorkFromStockAdjustDtl(StockAdjustDtl stockAdjustDtl)
        {
            StockAdjustDtlWork stockAdjustDtlWork = new StockAdjustDtlWork();

            stockAdjustDtlWork.CreateDateTime = stockAdjustDtl.CreateDateTime;                  // �쐬����
            stockAdjustDtlWork.UpdateDateTime = stockAdjustDtl.UpdateDateTime;                  // �X�V����
            stockAdjustDtlWork.EnterpriseCode = stockAdjustDtl.EnterpriseCode;                  // ��ƃR�[�h
            stockAdjustDtlWork.FileHeaderGuid = stockAdjustDtl.FileHeaderGuid;                  // GUID
            stockAdjustDtlWork.UpdEmployeeCode = stockAdjustDtl.UpdEmployeeCode;                // �X�V�]�ƈ��R�[�h
            stockAdjustDtlWork.UpdAssemblyId1 = stockAdjustDtl.UpdAssemblyId1;                  // �X�V�A�Z���u��ID1
            stockAdjustDtlWork.UpdAssemblyId2 = stockAdjustDtl.UpdAssemblyId2;                  // �X�V�A�Z���u��ID2
            stockAdjustDtlWork.LogicalDeleteCode = stockAdjustDtl.LogicalDeleteCode;            // �_���폜�敪
            stockAdjustDtlWork.SectionCode = stockAdjustDtl.SectionCode;                        // ���_�R�[�h
            stockAdjustDtlWork.SectionGuideNm = GetSectionName(stockAdjustDtl.SectionCode);     // ���_����
            stockAdjustDtlWork.StockAdjustSlipNo = stockAdjustDtl.StockAdjustSlipNo;            // �݌ɒ����`�[�ԍ�
            stockAdjustDtlWork.StockAdjustRowNo = stockAdjustDtl.StockAdjustRowNo;              // �݌ɒ����s�ԍ�
            stockAdjustDtlWork.SupplierFormalSrc = stockAdjustDtl.SupplierFormalSrc;            // �d���`��(��)
            stockAdjustDtlWork.StockSlipDtlNumSrc = stockAdjustDtl.StockSlipDtlNumSrc;          // �d�����גʔ�(��)
            stockAdjustDtlWork.AcPaySlipCd = stockAdjustDtl.AcPaySlipCd;                        // �󕥌��`�[�敪
            stockAdjustDtlWork.AcPayTransCd = stockAdjustDtl.AcPayTransCd;                      // �󕥌�����敪
            stockAdjustDtlWork.AdjustDate = stockAdjustDtl.AdjustDate;                          // �������t
            stockAdjustDtlWork.InputDay = stockAdjustDtl.InputDay;                              // ���͓��t
            stockAdjustDtlWork.GoodsMakerCd = stockAdjustDtl.GoodsMakerCd;                      // ���[�J�[�R�[�h
            stockAdjustDtlWork.MakerName = stockAdjustDtl.MakerName;                            // ���[�J�[����s
            stockAdjustDtlWork.GoodsNo = stockAdjustDtl.GoodsNo;                                // �i��
            stockAdjustDtlWork.GoodsName = stockAdjustDtl.GoodsName;                            // �i��
            stockAdjustDtlWork.StockUnitPriceFl = stockAdjustDtl.StockUnitPriceFl;              // �d���P��
            stockAdjustDtlWork.BfStockUnitPriceFl = stockAdjustDtl.BfStockUnitPriceFl;          // �ύX�O�d���P��
            stockAdjustDtlWork.AdjustCount = stockAdjustDtl.AdjustCount;                        // ������
            stockAdjustDtlWork.DtlNote = stockAdjustDtl.DtlNote;                                // ���ה��l
            stockAdjustDtlWork.WarehouseCode = stockAdjustDtl.WarehouseCode;                    // �q�ɃR�[�h
            stockAdjustDtlWork.WarehouseName = stockAdjustDtl.WarehouseName;                    // �q�ɖ���
            stockAdjustDtlWork.BLGoodsCode = stockAdjustDtl.BLGoodsCode;                        // BL���i�R�[�h
            stockAdjustDtlWork.BLGoodsFullName = stockAdjustDtl.BLGoodsFullName;                // BL���i����
            stockAdjustDtlWork.WarehouseShelfNo = stockAdjustDtl.WarehouseShelfNo;              // �q�ɒI��
            stockAdjustDtlWork.ListPriceFl = stockAdjustDtl.ListPriceFl;                        // �艿
            stockAdjustDtlWork.OpenPriceDiv = stockAdjustDtl.OpenPriceDiv;                      // �I�[�v�����i�敪
            stockAdjustDtlWork.StockPriceTaxExc = stockAdjustDtl.StockPriceTaxExc;              // �d�����z
            stockAdjustDtlWork.SupplierCd = stockAdjustDtl.SupplierCd;                          // �d����R�[�h
            stockAdjustDtlWork.SupplierSnm = stockAdjustDtl.SupplierSnm;                        // �d���旪��
            
            return stockAdjustDtlWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(���i�}�X�^�����i�}�X�^���[�N)
        /// </summary>
        /// <param name="goodsPrice">���i�}�X�^</param>
        /// <returns>���i�}�X�^���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^�����i�}�X�^���[�N�N���X�ɃR�s�[���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private GoodsPriceUWork CopyToGoodsPriceUWorkFromGoodsPrice(GoodsPrice goodsPrice)
        {
            GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();

            goodsPriceUWork.CreateDateTime = goodsPrice.CreateDateTime;         // �쐬����
            goodsPriceUWork.UpdateDateTime = goodsPrice.UpdateDateTime;         // �X�V����
            goodsPriceUWork.EnterpriseCode = goodsPrice.EnterpriseCode;         // ��ƃR�[�h
            goodsPriceUWork.FileHeaderGuid = goodsPrice.FileHeaderGuid;         // GUID
            goodsPriceUWork.UpdEmployeeCode = goodsPrice.UpdEmployeeCode;       // �X�V�]�ƈ��R�[�h
            goodsPriceUWork.UpdAssemblyId1 = goodsPrice.UpdAssemblyId1;         // �X�V�A�Z���u��ID1
            goodsPriceUWork.UpdAssemblyId2 = goodsPrice.UpdAssemblyId2;         // �X�V�A�Z���u��ID2
            goodsPriceUWork.LogicalDeleteCode = goodsPrice.LogicalDeleteCode;   // �_���폜�敪
            goodsPriceUWork.GoodsMakerCd = goodsPrice.GoodsMakerCd;             // ���[�J�[�R�[�h
            goodsPriceUWork.GoodsNo = goodsPrice.GoodsNo;                       // �i��
            goodsPriceUWork.PriceStartDate = goodsPrice.PriceStartDate;         // ���i�J�n��
            goodsPriceUWork.ListPrice = goodsPrice.ListPrice;                   // �艿
            goodsPriceUWork.SalesUnitCost = goodsPrice.SalesUnitCost;           // ����
            goodsPriceUWork.StockRate = goodsPrice.StockRate;                   // �d����
            goodsPriceUWork.OpenPriceDiv = goodsPrice.OpenPriceDiv;             // �I�[�v�����i�敪
            goodsPriceUWork.OfferDate = goodsPrice.OfferDate;                   // �񋟓��t
            goodsPriceUWork.UpdateDate = goodsPrice.UpdateDate;                 // �X�V�N����

            return goodsPriceUWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(�݌ɒ����f�[�^���[�N���݌ɒ����f�[�^)
        /// </summary>
        /// <param name="stockAdjustWork">�݌ɒ����f�[�^���[�N�N���X</param>
        /// <returns>�݌ɒ����f�[�^</returns>
        /// <remarks>
        /// <br>Note       : �݌ɒ����f�[�^���[�N���݌ɒ����f�[�^�N���X�ɃR�s�[���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private StockAdjust CopyToStockAdjustFromStockAdjustWork(StockAdjustWork stockAdjustWork)
        {
            StockAdjust stockAdjust = new StockAdjust();

            stockAdjust.CreateDateTime = stockAdjustWork.CreateDateTime;        // �쐬����
            stockAdjust.UpdateDateTime = stockAdjustWork.UpdateDateTime;        // �X�V����
            stockAdjust.EnterpriseCode = stockAdjustWork.EnterpriseCode;        // ��ƃR�[�h
            stockAdjust.FileHeaderGuid = stockAdjustWork.FileHeaderGuid;        // GUID
            stockAdjust.UpdEmployeeCode = stockAdjustWork.UpdEmployeeCode;      // �X�V�]�ƈ��R�[�h
            stockAdjust.UpdAssemblyId1 = stockAdjustWork.UpdAssemblyId1;        // �X�V�A�Z���u��ID1
            stockAdjust.UpdAssemblyId2 = stockAdjustWork.UpdAssemblyId2;        // �X�V�A�Z���u��ID2
            stockAdjust.LogicalDeleteCode = stockAdjustWork.LogicalDeleteCode;  // �_���폜�敪
            stockAdjust.SectionCode = stockAdjustWork.SectionCode;              // ���_�R�[�h
            stockAdjust.StockAdjustSlipNo = stockAdjustWork.StockAdjustSlipNo;  // �݌ɒ����`�[�ԍ�
            stockAdjust.AcPaySlipCd = stockAdjustWork.AcPaySlipCd;              // �󕥌��`�[�敪
            stockAdjust.AcPayTransCd = stockAdjustWork.AcPayTransCd;            // �󕥌�����敪
            stockAdjust.AdjustDate = stockAdjustWork.AdjustDate;                // �������t
            stockAdjust.InputDay = stockAdjustWork.InputDay;                    // ���͓��t
            stockAdjust.StockSectionCd = stockAdjustWork.StockSectionCd;        // �d�����_�R�[�h
            stockAdjust.StockSectionNm = stockAdjustWork.StockSectionGuideNm;   // �d�����_����
            stockAdjust.StockInputCode = stockAdjustWork.StockInputCode;        // �d�����͎҃R�[�h
            stockAdjust.StockInputName = stockAdjustWork.StockInputName;        // �d�����͎Җ���
            stockAdjust.StockAgentCode = stockAdjustWork.StockAgentCode;        // �d���S���҃R�[�h
            stockAdjust.StockAgentName = stockAdjustWork.StockAgentName;        // �d���S���Җ���
            stockAdjust.StockSubttlPrice = stockAdjustWork.StockSubttlPrice;    // �d�����z���v
            stockAdjust.SlipNote = stockAdjustWork.SlipNote;                    // �`�[���l

            return stockAdjust;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(�݌ɒ������׃f�[�^���[�N���݌ɒ������׃f�[�^)
        /// </summary>
        /// <param name="stockAdjustDtlWork">�݌ɒ������׃f�[�^���[�N�N���X</param>
        /// <returns>�݌ɒ������׃f�[�^</returns>
        /// <remarks>
        /// <br>Note       : �݌ɒ������׃f�[�^���[�N���݌ɒ������׃f�[�^�N���X�ɃR�s�[���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private StockAdjustDtl CopyToStockAdjustDtlFromStockAdjustDtlWork(StockAdjustDtlWork stockAdjustDtlWork)
        {
            StockAdjustDtl stockAdjustDtl = new StockAdjustDtl();

            stockAdjustDtl.CreateDateTime = stockAdjustDtlWork.CreateDateTime;          // �쐬����
            stockAdjustDtl.UpdateDateTime = stockAdjustDtlWork.UpdateDateTime;          // �X�V����
            stockAdjustDtl.EnterpriseCode = stockAdjustDtlWork.EnterpriseCode;          // ��ƃR�[�h
            stockAdjustDtl.FileHeaderGuid = stockAdjustDtlWork.FileHeaderGuid;          // GUID
            stockAdjustDtl.UpdEmployeeCode = stockAdjustDtlWork.UpdEmployeeCode;        // �X�V�]�ƈ��R�[�h
            stockAdjustDtl.UpdAssemblyId1 = stockAdjustDtlWork.UpdAssemblyId1;          // �X�V�A�Z���u��ID1
            stockAdjustDtl.UpdAssemblyId2 = stockAdjustDtlWork.UpdAssemblyId2;          // �X�V�A�Z���u��ID2
            stockAdjustDtl.LogicalDeleteCode = stockAdjustDtlWork.LogicalDeleteCode;    // �_���폜�敪
            stockAdjustDtl.SectionCode = stockAdjustDtlWork.SectionCode;                // ���_�R�[�h
            stockAdjustDtl.StockAdjustSlipNo = stockAdjustDtlWork.StockAdjustSlipNo;    // �݌ɒ����`�[�ԍ�
            stockAdjustDtl.StockAdjustRowNo = stockAdjustDtlWork.StockAdjustRowNo;      // �݌ɒ����s�ԍ�
            stockAdjustDtl.SupplierFormalSrc = stockAdjustDtlWork.SupplierFormalSrc;    // �d���`��(��)
            stockAdjustDtl.StockSlipDtlNumSrc = stockAdjustDtlWork.StockSlipDtlNumSrc;  // �d�����גʔ�(��)
            stockAdjustDtl.AcPaySlipCd = stockAdjustDtlWork.AcPaySlipCd;                // �󕥌��`�[�敪
            stockAdjustDtl.AcPayTransCd = stockAdjustDtlWork.AcPayTransCd;              // �󕥌�����敪
            stockAdjustDtl.AdjustDate = stockAdjustDtlWork.AdjustDate;                  // �������t
            stockAdjustDtl.InputDay = stockAdjustDtlWork.InputDay;                      // ���͓��t
            stockAdjustDtl.GoodsMakerCd = stockAdjustDtlWork.GoodsMakerCd;              // ���[�J�[�R�[�h
            stockAdjustDtl.MakerName = stockAdjustDtlWork.MakerName;                    // ���[�J�[����
            stockAdjustDtl.GoodsNo = stockAdjustDtlWork.GoodsNo;                        // �i��
            stockAdjustDtl.GoodsName = stockAdjustDtlWork.GoodsName;                    // �i��
            stockAdjustDtl.StockUnitPriceFl = stockAdjustDtlWork.StockUnitPriceFl;      // �d���P��
            stockAdjustDtl.BfStockUnitPriceFl = stockAdjustDtlWork.BfStockUnitPriceFl;  // �ύX�O�d���P��
            stockAdjustDtl.AdjustCount = stockAdjustDtlWork.AdjustCount;                // ������
            stockAdjustDtl.DtlNote = stockAdjustDtlWork.DtlNote;                        // ���ה��l
            stockAdjustDtl.WarehouseCode = stockAdjustDtlWork.WarehouseCode;            // �q�ɃR�[�h
            stockAdjustDtl.WarehouseName = stockAdjustDtlWork.WarehouseName;            // �q�ɖ���
            stockAdjustDtl.BLGoodsCode = stockAdjustDtlWork.BLGoodsCode;                // BL���i�R�[�h
            stockAdjustDtl.BLGoodsFullName = stockAdjustDtlWork.BLGoodsFullName;        // BL���i�R�[�h����(�S�p)
            stockAdjustDtl.WarehouseShelfNo = stockAdjustDtlWork.WarehouseShelfNo;      // �q�ɒI��
            stockAdjustDtl.ListPriceFl = stockAdjustDtlWork.ListPriceFl;                // �艿
            stockAdjustDtl.OpenPriceDiv = stockAdjustDtlWork.OpenPriceDiv;              // �I�[�v�����i�敪
            stockAdjustDtl.StockPriceTaxExc = stockAdjustDtlWork.StockPriceTaxExc;      // �d�����z

            return stockAdjustDtl;
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/24 Partsman�p�ɕύX
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �o�^�p�݌ɒ������׃f�[�^�擾����
        /// </summary>
        private ArrayList GetStockAdjustDtl(int mode)
        {
            ArrayList retList = new ArrayList();
            string warehouseCode = "";
            string warehouseName = "";
            for (int i = 0; i < _mainProductStockView.Count; i++)
            {
                warehouseCode = (_mainProductStockView[i].Row[ctCOL_WarehouseCode] != DBNull.Value) ? (string)_mainProductStockView[i].Row[ctCOL_WarehouseCode] : "";
                warehouseName = (_mainProductStockView[i].Row[ctCOL_WarehouseName] != DBNull.Value) ? (string)_mainProductStockView[i].Row[ctCOL_WarehouseName] : "";

                retList.Add(CopyToStockAdjustDtlWorkFromStockAdjustDtl(DataRowToStockAdjustDtl(_mainProductStockView[i].Row, mode, i), warehouseCode, warehouseName, mode));
            }
            return retList;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman�p�ɕύX

        #endregion

        #region DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		//--------------------------------------------------------
		//  �d���Ǘ��A�N�Z�X�N���X�C�x���g�n���h���֘A
		//--------------------------------------------------------
		#region �d���Ǘ��A�N�Z�X�N���X�C�x���g�n���h���֘A
		/// <summary>
		/// �d���Ǘ��A�N�Z�X�N���X�������C�x���g�n���h��
		/// </summary>
		/// <param name="sender">�C�x���g�����I�u�W�F�N�g</param>
		/// <param name="mode">�R�s�[���[�h[0:����, 1:���A���̂�]</param>
		private  void InfoInitStockMngEvent(object sender, int mode)
		{
			// �d���`�[Static����������
			InitializeSlipProc(mode);
		}

		/// <summary>
		/// �d���Ǘ��A�N�Z�X�N���X�Ǎ��C�x���g�n���h��
		/// </summary>
		/// <param name="sender">�C�x���g�����I�u�W�F�N�g</param>
		/// <param name="stockMngList">�Ǎ��݃f�[�^�R���N�V����</param>
		private  void InfoReadStockMngEvent(object sender, CustomSerializeArrayList stockMngList)
		{
			// Static���N���A
			mainStock = null;
			_mainProductStock.Clear();

			// CustomSerializeArrayList���f�[�^�擾
			foreach (object wkObj in stockMngList)
			{
				// �d���`�[�f�[�^
				if (wkObj is StockWork)
				{
					mainStock = CopyToStockDataFromStockWork(wkObj as StockWork);
					continue;
				}

				// �d���`�[���׃f�[�^
				if (wkObj is ArrayList)
				{
					ArrayList wkList = wkObj as ArrayList;

                    // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
                    //if ((wkList.Count > 0) && (wkList[0] is ProductStockWork))
					//{
					//	ProductStockWorkToDataRow(wkList);
					//	continue;
					//}
                    // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
                }

				// �d����E�x��������擾
				if (wkObj is CustSuppliWork)
				{
				}
			}

		}

		/// <summary>
		/// �d���Ǘ��A�N�Z�X�N���X�Q�ƐV�K�`�[�쐬�C�x���g�n���h��
		/// </summary>
		/// <param name="sender">�C�x���g�����I�u�W�F�N�g</param>
		/// <param name="mode">�R�s�[���[�h[0:����, 1:���A���̂�]</param>
		private static void InfoCopyNewStockMngEvent(object sender, int mode)
		{
			// �d���`�[�f�[�^�𒲐�
			// �w�b�_����
			mainStock.CreateDateTime = DateTime.MinValue;			// �쐬����
			mainStock.UpdateDateTime = DateTime.MinValue;			// �X�V����
			mainStock.FileHeaderGuid = Guid.Empty;					// Guid
			mainStock.UpdEmployeeCode = "";						// �X�V�]�ƈ��R�[�h
			mainStock.UpdAssemblyId1 = "";							// �X�V�A�Z���u��ID1
			mainStock.UpdAssemblyId2 = "";							// �X�V�A�Z���u��ID2
			mainStock.LogicalDeleteCode = 0;						// �_���폜�敪
			// ��ƃR�[�h
            mainStock.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
		}

		/// <summary>
		/// �d���Ǘ��A�N�Z�X�N���X�V�K���Ӑ�C�x���g�n���h��
		/// </summary>
		/// <param name="sender">�C�x���g�����I�u�W�F�N�g</param>
		/// <param name="workData">�Ǎ��ݓ��Ӑ�f�[�^</param>
		private static void InfoNewEntryStockMngEvent(object sender, CustomSerializeArrayList workData)
		{
		}

		/// <summary>
		/// �d���Ǘ��A�N�Z�X�N���X�X�V�`�F�b�N�C�x���g�n���h��
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="compareResult">��r����(0:�ύX����, 1:�ύX�L��)</param>
		/// <remarks>
		/// <br>Note       : �d���`�[���ɕύX�������������`�F�b�N���܂��B</br>
		/// </remarks>
		private static void InfoCompareMemoryStockMngEvent(object sender, ref int compareResult)
		{
			// ���̃N���X�ŕύX�����̏ꍇ�̂�
			if (compareResult == 0)
			{
				// �d���`�[�A�N�Z�X�N���X���ł̔�r���ʂ�߂�
				compareResult = (CompareStaticMemory()) ? 0 : 1;
			}
		}

		/// <summary>
		/// �d���Ǘ��A�N�Z�X�N���X�f�[�^�ϊ��C�x���g�n���h��
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="workData">�ϊ������[�N�f�[�^���X�g</param>
		/// <param name="retUidataLst">�ϊ���UI�f�[�^���X�g</param>
		/// <param name="status">�X�e�[�^�X</param>
		/// <remarks>
		/// <br>Note       : ���[�N�f�[�^����UI�f�[�^�ɕϊ����܂��B</br>
		/// </remarks>
		private static void InfoChangeWorkToUidataStockMngEvent(object sender, CustomSerializeArrayList workData, ref ArrayList retUidataLst, out int status)
		{
			status = 0;

			// CustomSerializeArrayList���f�[�^�擾
			foreach (object wkObj in workData)
			{
				// �d���`�[�f�[�^
				if (wkObj is StockWork)
				{
					retUidataLst.Add(CopyToStockDataFromStockWork(wkObj as StockWork));
					continue;
				}

				// �d���`�[���׃f�[�^
				if (wkObj is ArrayList)
				{
					ArrayList wkList = wkObj as ArrayList;

                    // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
                    //if ((wkList.Count > 0) && (wkList[0] is ProductStockWork))
					//{
					//	retUidataLst.Add(CopyToDtlDataFromDtlWork(wkList));
					//}
                    // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
                }
			}
		}
		#endregion

		//--------------------------------------------------------
		//  Static�f�[�^�ύX�C�x���g�n���h��
		//--------------------------------------------------------
		#region Static�f�[�^�ύX�C�x���g�n���h��
		/// <summary>
		/// �s�C���f�b�N�X�擾����
		/// </summary>
		/// <param name="dataRow">�C���f�b�N�X�擾�f�[�^�s</param>
		/// <returns>�s�C���f�b�N�X</returns>
		private static int GetRowIndex(DataRow dataRow)
		{
			for (int i = 0; i < _mainProductStockView.Count; i++)
			{
				if (_mainProductStockView[i].Row == dataRow)
				{
					return i;
				}
			}

			return -1;
		}
		#endregion
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        
        #endregion

        //--------------------------------------------------------
		//  ��������
		//--------------------------------------------------------
		#region ��������

        #region DEL 2008/07/24 Partsman�p�ɕύX
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �_�~�[�̖���(��s)���쐬����B
		/// </summary>
		/// <param name="msg">�G���[���b�Z�[�W</param>
		/// <returns>0:����, 5:���s</returns>
		private static int CreateDummySlipDtl(out string msg)
		{
			msg = "";
			if (_mainProductStockView != null)
			{
				int dispOrder = mainAdjustStockDtlFullView.Count;

				while (mainAdjustStockDtlFullView.Count < maxRowCnt)
				{
					// �ύX�C�x���g����
					DeactivateDtlChangeEventHandler();
					try
					{
                        // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
						//ProductStock data = new ProductStock();
                        StockExpansion data = new StockExpansion();
                        // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                        // �_���폜=1
						data.LogicalDeleteCode = 1;
						// Guid��ݒ肷��
						data.FileHeaderGuid = Guid.Empty;
                        // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
                        //data.ProductStockGuid = Guid.Empty;
                        //data.GoodsCodeStatus = -1;
                        // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
                        // ���׎�� = ���I��
						//data.StockDetailKind = (int)ConstantManagement_SF_AP.DetailKindCode.None;
                        
						// �s�ǉ�
                        // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                        //_mainProductStock.Rows.Add(ProductStockToDataRow(data));
                        _mainProductStock.Rows.Add(StockToDataRow(data, null));
                        // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                    }
					finally
					{
						// �ύX�C�x���g�L��
						ActivateDtlChangeEventHandler();
					}
				}

				return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			}
			else
			{
				msg = "���׏�񂪏���������Ă��܂���(�_�~�[���׍쐬)";
				return (int)ConstantManagement.MethodResult.ctFNC_WARNING;
			}
		}
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman�p�ɕύX

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �_�~�[�̖���(��s)���쐬����B
        /// </summary>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <returns>0:����, 5:���s</returns>
        /// <remarks>
        /// <br>Note       : �_�~�[�̖��׍s���쐬���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private static int CreateDummySlipDtl(out string msg)
        {
            msg = "";
            if (_mainProductStockView != null)
            {
                int dispOrder = mainAdjustStockDtlFullView.Count;

                while (mainAdjustStockDtlFullView.Count < maxRowCnt)
                {
                    // �ύX�C�x���g����
                    DeactivateDtlChangeEventHandler();
                    try
                    {
                        Stock data = new Stock();
                        // �_���폜=1
                        data.LogicalDeleteCode = 1;
                        // Guid��ݒ肷��
                        data.FileHeaderGuid = Guid.Empty;

                        // �s�ǉ�
                        _mainProductStock.Rows.Add(StockToDataRow(data, null));
                    }
                    finally
                    {
                        // �ύX�C�x���g�L��
                        ActivateDtlChangeEventHandler();
                    }
                }

                return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            else
            {
                msg = "���׏�񂪏���������Ă��܂���(�_�~�[���׍쐬)";
                return (int)ConstantManagement.MethodResult.ctFNC_WARNING;
            }
        }

        /// <summary>
        /// �s�ǉ�����
        /// </summary>
        /// <remarks>
        /// Note       : �P�s�����s�ǉ����܂��B<br />
        /// Programer  : 30414 �E �K�j<br />
        /// Date       : 2008/07/24<br />
        /// </remarks>
        public static void AddNewRow()
        {
            Stock data = new Stock();
            // �_���폜=1
            data.LogicalDeleteCode = 1;
            // Guid��ݒ肷��
            data.FileHeaderGuid = Guid.Empty;

            // �s�ǉ�
            _mainProductStock.Rows.Add(StockToDataRow(data, null));
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �`�[���(MainStaticMemory)�ύX�`�F�b�N����
		/// </summary>
		/// <returns>T:�ύX����, F:�ύX�L��</returns>
		private static bool CompareStaticMemory()
		{
			try
			{
				// �d���`�[����r�H
                // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                //if ((mainStock.Equals(orgnPtSuplSlip) != true) ||
				//	(_mainProductStockView.Count != orgnAdjustStockDtl.Count))
                if (mainStock.Equals(orgnPtSuplSlip) != true)
                // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                {
					return false;
				}

				// �d���`�[���׏���r
				for (int i = 0; i < _mainProductStockView.Count; i++)
				{
				}
			}
			catch
			{
				return false;
			}

			return true;
		}
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        /// <summary>
		/// ���׏��(MainStaticMemory)�ύX�C�x���g�n���h���L��������
		/// </summary>
		private static void ActivateDtlChangeEventHandler()
		{
			lock (syncRoot)
			{
				if (slipDtlChangeEventCounter++ == 0)
				{
					// �n���h���o�^
					_mainProductStock.ColumnChanging += _slipDtlChanging;
					_mainProductStock.ColumnChanged += _slipDtlChanged;
				}
			}
		}

		/// <summary>
		/// ���׏��(MainStaticMemory)�ύX�C�x���g�n���h������������
		/// </summary>
		private static void DeactivateDtlChangeEventHandler()
		{
			lock (syncRoot)
			{
				if (--slipDtlChangeEventCounter == 0)
				{
					// �n���h���폜
					_mainProductStock.ColumnChanging -= _slipDtlChanging;
					_mainProductStock.ColumnChanged -= _slipDtlChanged;
				}
			}
        }

        #region DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �񋟃C�x���g�ʒm����
		/// </summary>
		/// <param name="handler">�񋟃C�x���g���f���Q�[�g</param>
		/// <param name="sender">�C�x���g�����I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private static void CallEventHandler(EventHandler handler, object sender, EventArgs e)
		{
			// �f���Q�[�g�ɓo�^���\�b�h�L��H
			if (handler != null)
			{
				// �o�^���R�[������
				foreach (Delegate wkMethod in handler.GetInvocationList())
				{
					if (wkMethod != null)
					{
						try
						{
							if (sender == null)
								((EventHandler)wkMethod)(myInstance, e);
							else
								((EventHandler)wkMethod)(sender, e);
						}
						catch
						{
							// ���\�b�h�R�[�������s�����ꍇ�͍폜
							handler -= (EventHandler)wkMethod;
						}
					}
				}
			}
		}
        
        /// <summary>
		/// �񋟃C�x���g�ʒm����
		/// </summary>
		/// <param name="handler">�񋟃C�x���g���f���Q�[�g</param>
		/// <param name="sender">�C�x���g�����I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private static void CallEventHandler<Args>(EventHandler<Args> handler, object sender, Args e) where Args : EventArgs
		{
			// �f���Q�[�g�ɓo�^���\�b�h�L��H
			if (handler != null)
			{
				// �o�^���R�[������
				foreach (Delegate wkMethod in handler.GetInvocationList())
				{
					if (wkMethod != null)
					{
						try
						{
							if (sender == null)
								((EventHandler<Args>)wkMethod)(myInstance, e);
							else
								((EventHandler<Args>)wkMethod)(sender, e);
						}
						catch
						{
							// ���\�b�h�R�[�������s�����ꍇ�͍폜
							handler -= (EventHandler<Args>)wkMethod;
						}
					}
				}
			}
		}
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �f�[�^�e�[�u���쐬����
		/// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�e�[�u�����쐬���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
		private static void CreateProductStockTable()
		{
            _mainProductStock = new DataTable(ctTBL_AdjustStock);

            // No
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_RowNum, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_RowNum].Caption = "No";
            // �i��
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_GoodsNo, typeof(String)));
            _mainProductStock.Columns[ctCOL_GoodsNo].Caption = "�i��";
            // �i��
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_GoodsName, typeof(String)));
            _mainProductStock.Columns[ctCOL_GoodsName].Caption = "�i��";
            // �a�k�R�[�h
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_BLGoodsCode, typeof(String)));
            _mainProductStock.Columns[ctCOL_BLGoodsCode].Caption = "BL����";
            // ���[�J�[
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_GoodsMakerCd, typeof(String)));
            _mainProductStock.Columns[ctCOL_GoodsMakerCd].Caption = "���[�J�[";
            // �d����
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_SupplierCd, typeof(String)));
            _mainProductStock.Columns[ctCOL_SupplierCd].Caption = "�d����";
            // �W�����i
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_ListPriceFl, typeof(Double)));
            _mainProductStock.Columns[ctCOL_ListPriceFl].Caption = "�W�����i";
            // ���P��
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_StockUnitPrice, typeof(Double)));
            _mainProductStock.Columns[ctCOL_StockUnitPrice].Caption = "���P��";
            // �d����
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_SalesOrderUnit, typeof(Double)));
            _mainProductStock.Columns[ctCOL_SalesOrderUnit].Caption = "�d����";
            // �ύX�O�d����
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_BfSalesOrderUnit, typeof(Double)));
            _mainProductStock.Columns[ctCOL_BfSalesOrderUnit].Caption = "�ύX�O�d����";
            // �d���㐔
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_AfSalesOrderUnit, typeof(Double)));
            _mainProductStock.Columns[ctCOL_AfSalesOrderUnit].Caption = "�d���㐔";
            // �q�ɒI��
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_WarehouseShelfNo, typeof(String)));
            _mainProductStock.Columns[ctCOL_WarehouseShelfNo].Caption = "�I��";
            // �����c
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_SalesOrderCount, typeof(String)));
            _mainProductStock.Columns[ctCOL_SalesOrderCount].Caption = "�����c";
            // �݌ɐ�(�d���݌ɐ�)
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_SupplierStock, typeof(Double)));
            _mainProductStock.Columns[ctCOL_SupplierStock].Caption = "�݌ɐ�";
            // ���ה��l
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_DtlNote, typeof(String)));
            _mainProductStock.Columns[ctCOL_DtlNote].Caption = "���ה��l";
            // �쐬����
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_CreateDateTime, typeof(DateTime)));
            _mainProductStock.Columns[ctCOL_CreateDateTime].Caption = "�쐬����";
            // �X�V����
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_UpdateDateTime, typeof(DateTime)));
            _mainProductStock.Columns[ctCOL_UpdateDateTime].Caption = "�X�V����";
            // ��ƃR�[�h
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_EnterpriseCode, typeof(String)));
            _mainProductStock.Columns[ctCOL_EnterpriseCode].Caption = "��ƃR�[�h";
            _mainProductStock.Columns[ctCOL_EnterpriseCode].MaxLength = 16;
            // GUID
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_FileHeaderGuid, typeof(Guid)));
            _mainProductStock.Columns[ctCOL_FileHeaderGuid].Caption = "GUID";
            // �X�V�]�ƈ��R�[�h
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_UpdEmployeeCode, typeof(String)));
            _mainProductStock.Columns[ctCOL_UpdEmployeeCode].Caption = "�X�V�]�ƈ��R�[�h";
            _mainProductStock.Columns[ctCOL_UpdEmployeeCode].MaxLength = 9;
            // �X�V�A�Z���u��ID1
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_UpdAssemblyId1, typeof(String)));
            _mainProductStock.Columns[ctCOL_UpdAssemblyId1].Caption = "�X�V�A�Z���u��ID1";
            _mainProductStock.Columns[ctCOL_UpdAssemblyId1].MaxLength = 30;
            // �X�V�A�Z���u��ID2
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_UpdAssemblyId2, typeof(String)));
            _mainProductStock.Columns[ctCOL_UpdAssemblyId2].Caption = "�X�V�A�Z���u��ID2";
            _mainProductStock.Columns[ctCOL_UpdAssemblyId1].MaxLength = 30;
            // �_����폜�敪
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_LogicalDeleteCode, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_LogicalDeleteCode].Caption = "�_����폜�敪";
            // ���_�R�[�h
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_SectionCode, typeof(String)));
            _mainProductStock.Columns[ctCOL_SectionCode].Caption = "���_�R�[�h";
            _mainProductStock.Columns[ctCOL_SectionCode].MaxLength = 6;
            // �C���O���P��
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_BfStockUnitPrice, typeof(Double)));
            _mainProductStock.Columns[ctCOL_BfStockUnitPrice].Caption = "�C���O���P��";
            // �ύX�O�݌ɐ�(�d���݌ɐ�)
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_BfSupplierStock, typeof(Double)));
            _mainProductStock.Columns[ctCOL_BfSupplierStock].Caption = "�C���O�݌ɐ�";
            // �q�ɃR�[�h
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_WarehouseCode, typeof(String)));
            _mainProductStock.Columns[ctCOL_WarehouseCode].Caption = "�q�ɃR�[�h";
            _mainProductStock.Columns[ctCOL_WarehouseCode].MaxLength = 6;
            // �������t
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_AdjustDate, typeof(DateTime)));
            _mainProductStock.Columns[ctCOL_AdjustDate].Caption = "�������t";
            // ���͓��t
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_InputDay, typeof(DateTime)));
            _mainProductStock.Columns[ctCOL_InputDay].Caption = "���͓��t";
            // �d���`��(��)
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_SupplierFormalSrc, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_SupplierFormalSrc].Caption = "�d���`��(��)";
            // �d�����גʔ�(��)
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_StockSlipDtlNumSrc, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_StockSlipDtlNumSrc].Caption = "�d�����גʔ�(��)";
            // �݌ɒ����`�[�ԍ�
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_StockAdjustSlipNo, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_StockAdjustSlipNo].Caption = "�݌ɒ����`�[�ԍ�";
            // �݌Ƀ}�X�^
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_Stock, typeof(Stock)));
            _mainProductStock.Columns[ctCOL_Stock].Caption = "�݌Ƀ}�X�^";
            // �݌ɒ����f�[�^
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_StockAdjust, typeof(StockAdjust)));
            _mainProductStock.Columns[ctCOL_StockAdjust].Caption = "�݌ɒ����f�[�^";
            // �݌ɒ������׃f�[�^
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_StockAdjustDtl, typeof(StockAdjustDtl)));
            _mainProductStock.Columns[ctCOL_StockAdjustDtl].Caption = "�݌ɒ������׃f�[�^";
            // ���i�}�X�^
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_GoodsPrice, typeof(GoodsPrice)));
            _mainProductStock.Columns[ctCOL_GoodsPrice].Caption = "���i�}�X�^";
            // �d�����z
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_StockPriceTaxExc, typeof(Int64)));
            _mainProductStock.Columns[ctCOL_StockPriceTaxExc].Caption = "�d�����z";
            // �I�[�v�����i�敪
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_OpenPriceDiv, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_OpenPriceDiv].Caption = "�I�[�v�����i�敪";
            // �d���旪��
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_SupplierSnm, typeof(string)));
            _mainProductStock.Columns[ctCOL_SupplierSnm].Caption = "�d���旪��";

			// �f�[�^�r���[
			_mainProductStockView = new DataView(_mainProductStock);
			_mainProductStockView.RowFilter = ctCOL_LogicalDeleteCode + " = 0";
			_mainProductStockView.Sort = ctCOL_RowNum;
			
            mainAdjustStockDtlFullView = new DataView(_mainProductStock);
            mainAdjustStockDtlFullView.Sort = ctCOL_RowNum;

			adjustSuplSlipDtlPriceView = new DataView(_mainProductStock);
            adjustSuplSlipDtlPriceView.Sort = ctCOL_RowNum;

			// �C�x���g�n���h���o�^
			ActivateDtlChangeEventHandler();
			slipDtlChangeEventCounter = 1;		// 1:�C�x���g�L�����
		}
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

		#endregion

        #region DEL 2008/07/24 Partsman�p�ɕύX
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �f�[�^�e�[�u���쐬����
        /// </summary>
        private static void CreateProductStockTable()
        {
            _mainProductStock = new DataTable(ctTBL_AdjustStock);

            // �s�ԍ�
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_RowNum, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_RowNum].Caption = "No";

            // �쐬����
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_CreateDateTime, typeof(DateTime)));
            _mainProductStock.Columns[ctCOL_CreateDateTime].Caption = "�쐬����";
            // �X�V����
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_UpdateDateTime, typeof(DateTime)));
            _mainProductStock.Columns[ctCOL_UpdateDateTime].Caption = "�X�V����";
            // ��ƃR�[�h
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_EnterpriseCode, typeof(String)));
            _mainProductStock.Columns[ctCOL_EnterpriseCode].Caption = "��ƃR�[�h";
            _mainProductStock.Columns[ctCOL_EnterpriseCode].MaxLength = 16;
            // GUID
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_FileHeaderGuid, typeof(Guid)));
            _mainProductStock.Columns[ctCOL_FileHeaderGuid].Caption = "GUID";
            // �X�V�]�ƈ��R�[�h
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_UpdEmployeeCode, typeof(String)));
            _mainProductStock.Columns[ctCOL_UpdEmployeeCode].Caption = "�X�V�]�ƈ��R�[�h";
            _mainProductStock.Columns[ctCOL_UpdEmployeeCode].MaxLength = 9;
            // �X�V�A�Z���u��ID1
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_UpdAssemblyId1, typeof(String)));
            _mainProductStock.Columns[ctCOL_UpdAssemblyId1].Caption = "�X�V�A�Z���u��ID1";
            _mainProductStock.Columns[ctCOL_UpdAssemblyId1].MaxLength = 30;
            // �X�V�A�Z���u��ID2
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_UpdAssemblyId2, typeof(String)));
            _mainProductStock.Columns[ctCOL_UpdAssemblyId2].Caption = "�X�V�A�Z���u��ID2";
            _mainProductStock.Columns[ctCOL_UpdAssemblyId1].MaxLength = 30;
            // �_����폜�敪
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_LogicalDeleteCode, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_LogicalDeleteCode].Caption = "�_����폜�敪";
            // ���_�R�[�h
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_SectionCode, typeof(String)));
            _mainProductStock.Columns[ctCOL_SectionCode].Caption = "���_�R�[�h";
            _mainProductStock.Columns[ctCOL_SectionCode].MaxLength = 6;
            // ���[�J�[�R�[�h
            // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_MakerCode, typeof(Int32)));
            //_mainProductStock.Columns[ctCOL_MakerCode].Caption = "���[�J�[�R�[�h";
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_GoodsMakerCd, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_GoodsMakerCd].Caption = "���[�J�[�R�[�h";
            // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            // ���i�R�[�h
            // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_GoodsCode, typeof(String)));
            //_mainProductStock.Columns[ctCOL_GoodsCode].Caption = "���i�R�[�h";
            //_mainProductStock.Columns[ctCOL_GoodsCode].MaxLength = 15;
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_GoodsNo, typeof(String)));
            _mainProductStock.Columns[ctCOL_GoodsNo].Caption = "���i�R�[�h";
            // 2008.03.14 �C�� >>>>>>>>>>>>>>>>>>>>
            //_mainProductStock.Columns[ctCOL_GoodsNo].MaxLength = 15;
            _mainProductStock.Columns[ctCOL_GoodsNo].MaxLength = 40;
            // 2008.03.14 �C�� <<<<<<<<<<<<<<<<<<<<
            // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            // ���i����
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_GoodsName, typeof(String)));
            _mainProductStock.Columns[ctCOL_GoodsName].Caption = "���i����";
            _mainProductStock.Columns[ctCOL_GoodsName].MaxLength = 40;
            // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �����ԍ�
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_ProductNumber, typeof(String)));
            //_mainProductStock.Columns[ctCOL_ProductNumber].Caption = "�����ԍ�";
            //_mainProductStock.Columns[ctCOL_ProductNumber].MaxLength = 20;
            //// �����݌Ƀ}�X�^GUID
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_ProductStockGuid, typeof(Guid)));
            //_mainProductStock.Columns[ctCOL_ProductStockGuid].Caption = "�����݌Ƀ}�X�^GUID";
            // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
            // �݌ɋ敪
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_StockDiv, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_StockDiv].Caption = "�݌ɋ敪";
            // �q�ɃR�[�h
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_WarehouseCode, typeof(String)));
            _mainProductStock.Columns[ctCOL_WarehouseCode].Caption = "�q�ɃR�[�h";
            _mainProductStock.Columns[ctCOL_WarehouseCode].MaxLength = 6;
            // �q�ɖ���
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_WarehouseName, typeof(String)));
            _mainProductStock.Columns[ctCOL_WarehouseName].Caption = "�q�ɖ���";
            _mainProductStock.Columns[ctCOL_WarehouseName].MaxLength = 20;
            // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// ���Ǝ҃R�[�h
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_CarrierEpCode, typeof(Int32)));
            //_mainProductStock.Columns[ctCOL_CarrierEpCode].Caption = "���Ǝ҃R�[�h";            
            //// ���ƎҖ���
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_CarrierEpName, typeof(String)));
            //_mainProductStock.Columns[ctCOL_CarrierEpName].Caption = "���ƎҖ���";
            //_mainProductStock.Columns[ctCOL_CarrierEpName].MaxLength = 20;
            // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
            // ���Ӑ�R�[�h
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_CustomerCode, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_CustomerCode].Caption = "���Ӑ�R�[�h";
            // ���Ӑ於��
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_CustomerName, typeof(String)));
            _mainProductStock.Columns[ctCOL_CustomerName].Caption = "���Ӑ於��";
            _mainProductStock.Columns[ctCOL_CustomerName].MaxLength = 40;
            // ���Ӑ於��2
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_CustomerName2, typeof(String)));
            _mainProductStock.Columns[ctCOL_CustomerName2].Caption = "���Ӑ於��2";
            _mainProductStock.Columns[ctCOL_CustomerName2].MaxLength = 40;
            // �d����
            // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_StockDate, typeof(DateTime)));
            //_mainProductStock.Columns[ctCOL_StockDate].Caption = "�d����";
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_LastStockDate, typeof(DateTime)));
            _mainProductStock.Columns[ctCOL_LastStockDate].Caption = "�d����";
            // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            // ���ד�
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_ArrivalGoodsDay, typeof(DateTime)));
            _mainProductStock.Columns[ctCOL_ArrivalGoodsDay].Caption = "���ד�";
            // 2008.01.17 �C�� >>>>>>>>>>>>>>>>>>>>
            //// �d���P��
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_StockUnitPrice, typeof(Int64)));
            //_mainProductStock.Columns[ctCOL_StockUnitPrice].Caption = "�d���P��";
            //// �C���O�d���P��
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_BfStockUnitPrice, typeof(Int64)));
            //_mainProductStock.Columns[ctCOL_BfStockUnitPrice].Caption = "�C���O�d���P��";
            // �d���P��
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_StockUnitPrice, typeof(Double)));
            _mainProductStock.Columns[ctCOL_StockUnitPrice].Caption = "�d���P��";
            // �C���O�d���P��
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_BfStockUnitPrice, typeof(Double)));
            _mainProductStock.Columns[ctCOL_BfStockUnitPrice].Caption = "�C���O�d���P��";
            // 2008.01.17 �C�� <<<<<<<<<<<<<<<<<<<<
            // �d�����z
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_StockPrice, typeof(Int64)));
            _mainProductStock.Columns[ctCOL_StockPrice].Caption = "�d�����z";
            // �d�����z����Ŋz
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_StockPriceConsTax, typeof(Int64)));
            _mainProductStock.Columns[ctCOL_StockPriceConsTax].Caption = "�d�����z����Ŋz";
            // �d���O�őΏۊz
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_ItdedStckOutTax, typeof(Int64)));
            _mainProductStock.Columns[ctCOL_ItdedStckOutTax].Caption = "�d���O�őΏۊz";
            // �d�����őΏۊz
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_ItdedStckInTax, typeof(Int64)));
            _mainProductStock.Columns[ctCOL_ItdedStckInTax].Caption = "�d�����őΏۊz";
            // �d����ېőΏۊz
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_ItdedStckTaxFree, typeof(Int64)));
            _mainProductStock.Columns[ctCOL_ItdedStckTaxFree].Caption = "�d����ېőΏۊz";
            // �d���O�Ŋz
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_StckOuterTax, typeof(Int64)));
            _mainProductStock.Columns[ctCOL_StckOuterTax].Caption = "�d���O�Ŋz";
            // �d�����Ŋz
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_StckInnerTax, typeof(Int64)));
            _mainProductStock.Columns[ctCOL_StckInnerTax].Caption = "�d�����Ŋz";
            // �ېŋ敪
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_TaxationCode, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_TaxationCode].Caption = "�ېŋ敪";
            // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �݌ɏ��
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_StockState, typeof(Int32)));
            //_mainProductStock.Columns[ctCOL_StockState].Caption = "�݌ɏ��";
            //// �ړ����
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_MoveStatus, typeof(Int32)));
            //_mainProductStock.Columns[ctCOL_MoveStatus].Caption = "�ړ����";
            //// ���i���
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_GoodsCodeStatus, typeof(Int32)));
            //_mainProductStock.Columns[ctCOL_GoodsCodeStatus].Caption = "���i���";
            //// �C���O���i���
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_BfGoodsCodeStatus, typeof(Int32)));
            //_mainProductStock.Columns[ctCOL_BfGoodsCodeStatus].Caption = "�C���O���i���";
            //// ���i�d�b�ԍ�1
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_StockTelNo1, typeof(String)));
            //_mainProductStock.Columns[ctCOL_StockTelNo1].Caption = "���i�d�b�ԍ�1";
            //_mainProductStock.Columns[ctCOL_StockTelNo1].MaxLength = 20;
            //// ���i�d�b�ԍ�2
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_StockTelNo2, typeof(String)));
            //_mainProductStock.Columns[ctCOL_StockTelNo2].Caption = "���i�d�b�ԍ�2";
            //_mainProductStock.Columns[ctCOL_StockTelNo2].MaxLength = 20;
            //// �����敪
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_RomDiv, typeof(Int32)));
            //_mainProductStock.Columns[ctCOL_RomDiv].Caption = "�����敪";            
            //// �@��R�[�h
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_CellphoneModelCode, typeof(String)));
            //_mainProductStock.Columns[ctCOL_CellphoneModelCode].Caption = "�@��R�[�h";
            //_mainProductStock.Columns[ctCOL_CellphoneModelCode].MaxLength = 20;
            //// �@�햼��
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_CellphoneModelName, typeof(String)));
            //_mainProductStock.Columns[ctCOL_CellphoneModelName].Caption = "�@�햼��";
            //_mainProductStock.Columns[ctCOL_CellphoneModelName].MaxLength = 40;
            //// �L�����A�R�[�h
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_CarrierCode, typeof(Int32)));
            //_mainProductStock.Columns[ctCOL_CarrierCode].Caption = "�L�����A�R�[�h";            
            //// �L�����A����
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_CarrierName, typeof(String)));
            //_mainProductStock.Columns[ctCOL_CarrierName].Caption = "�L�����A����";
            //_mainProductStock.Columns[ctCOL_CarrierName].MaxLength = 20;
            // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
            // ���[�J�[����
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_MakerName, typeof(String)));
            _mainProductStock.Columns[ctCOL_MakerName].Caption = "���[�J�[����";
            _mainProductStock.Columns[ctCOL_MakerName].MaxLength = 30;
            // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �n���F�R�[�h
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_SystematicColorCd, typeof(Int32)));
            //_mainProductStock.Columns[ctCOL_SystematicColorCd].Caption = "�n���F�R�[�h";            
            //// �n���F����
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_SystematicColorNm, typeof(String)));
            //_mainProductStock.Columns[ctCOL_SystematicColorNm].Caption = "�n���F����";
            //_mainProductStock.Columns[ctCOL_SystematicColorNm].MaxLength = 20;
            // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
            // ���i�啪�ރR�[�h
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_LargeGoodsGanreCode, typeof(String)));
            _mainProductStock.Columns[ctCOL_LargeGoodsGanreCode].Caption = "���i�啪�ރR�[�h";
            // ���i�����ރR�[�h
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_MediumGoodsGanreCode, typeof(String)));
            _mainProductStock.Columns[ctCOL_MediumGoodsGanreCode].Caption = "���i�����ރR�[�h";
            // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �o�א擾�Ӑ�R�[�h
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_ShipCustomerCode, typeof(Int32)));
            //_mainProductStock.Columns[ctCOL_ShipCustomerCode].Caption = "�o�א擾�Ӑ�R�[�h";            
            //// �o�א擾�Ӑ於��
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_ShipCustomerName, typeof(String)));
            //_mainProductStock.Columns[ctCOL_ShipCustomerName].Caption = "�o�א擾�Ӑ於��";
            //_mainProductStock.Columns[ctCOL_ShipCustomerName].MaxLength = 30;
            //// �o�א擾�Ӑ於��2
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_ShipCustomerName2, typeof(String)));
            //_mainProductStock.Columns[ctCOL_ShipCustomerName2].Caption = "�o�א擾�Ӑ於��2";
            //_mainProductStock.Columns[ctCOL_ShipCustomerName2].MaxLength = 30;
            // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
            // 2007.10.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
            // ���i�敪�ڍ׃R�[�h
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_DetailGoodsGanreCode, typeof(String)));
            _mainProductStock.Columns[ctCOL_DetailGoodsGanreCode].Caption = "���i�敪�ڍ׃R�[�h";
            // �a�k���i�R�[�h
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_BLGoodsCode, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_BLGoodsCode].Caption = "�a�k�R�[�h";
            // �q�ɒI��
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_WarehouseShelfNo, typeof(String)));
            _mainProductStock.Columns[ctCOL_WarehouseShelfNo].Caption = "�I��";
            _mainProductStock.Columns[ctCOL_WarehouseShelfNo].MaxLength = 8;
            // �C���O�q�ɒI��
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_BfWarehouseShelfNo, typeof(String)));
            _mainProductStock.Columns[ctCOL_BfWarehouseShelfNo].Caption = "�C���O�I��";
            // 2007.10.11 �ǉ� <<<<<<<<<<<<<<<<<<<<

            // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
            ////���ԊǗ��敪
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_PrdNumMngDiv, typeof(Int32)));
            //_mainProductStock.Columns[ctCOL_PrdNumMngDiv].Caption = "���ԊǗ��敪";
            // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<

            // �d���݌ɐ�
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_SupplierStock, typeof(Double)));
            _mainProductStock.Columns[ctCOL_SupplierStock].Caption = "�d���݌ɐ�";

            // ����݌ɐ�
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_TrustCount, typeof(Double)));
            _mainProductStock.Columns[ctCOL_TrustCount].Caption = "����݌ɐ�";

            // �������z
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_AdjustPrice, typeof(Int64)));
            _mainProductStock.Columns[ctCOL_AdjustPrice].Caption = "�������z";

            // ������
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_AdjustCount, typeof(Double)));
            _mainProductStock.Columns[ctCOL_AdjustCount].Caption = "������";

            // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �C���O����
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_BfProductNumber, typeof(string)));
            //_mainProductStock.Columns[ctCOL_BfProductNumber].Caption = "�C���O����";
            //_mainProductStock.Columns[ctCOL_ShipCustomerName2].MaxLength = 20;
            // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<

            // 2008.01.17 �ǉ� >>>>>>>>>>>>>>>>>>>>
            /// <summary>���ה��l</summary>
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_DtlNote, typeof(String)));
            _mainProductStock.Columns[ctCOL_DtlNote].Caption = "���ה��l";
            _mainProductStock.Columns[ctCOL_DtlNote].MaxLength = 40;
            // 2008.01.17 �ǉ� <<<<<<<<<<<<<<<<<<<<

            // 2008.02.15 �C�� >>>>>>>>>>>>>>>>>>>>
            /// <summary>�艿�i�����j</summary>
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_ListPriceFl, typeof(Double)));
            _mainProductStock.Columns[ctCOL_ListPriceFl].Caption = "�艿";
            // 2008.02.15 �C�� <<<<<<<<<<<<<<<<<<<<

            // ���i�K�C�h
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_GoodsGuide, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_GoodsGuide].Caption = "";

            // ���׃^�C�v
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_RowType, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_RowType].Caption = "���׃^�C�v";

            // �f�[�^�r���[
            _mainProductStockView = new DataView(_mainProductStock);
            _mainProductStockView.RowFilter = ctCOL_LogicalDeleteCode + " = 0";
            _mainProductStockView.Sort = ctCOL_RowNum;

            mainAdjustStockDtlFullView = new DataView(_mainProductStock);
            mainAdjustStockDtlFullView.Sort = ctCOL_RowNum;

            adjustSuplSlipDtlPriceView = new DataView(_mainProductStock);
            adjustSuplSlipDtlPriceView.Sort = ctCOL_RowNum;

            // �C�x���g�n���h���o�^
            ActivateDtlChangeEventHandler();
            slipDtlChangeEventCounter = 1;		// 1:�C�x���g�L�����
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman�p�ɕύX

        // ------ ADD 2017/08/11 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
        #region ���n���f�B�^�[�~�i���݌Ɏd���o�^�̑Ή�
        /// <summary>
        /// �R���X�g���N�^�i�n���f�B�^�[�~�i���p�j
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="status">�������X�e�[�^�X�u0�F����  0�ȊO�F���s�v</param>
        /// <remarks>
        /// <br>Note       : �N���X�̐V�����C���X�^���X�����������܂��B�i�n���f�B�^�[�~�i���p�j</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public AdjustStockAcs(string enterpriseCode, string sectionCode, out int status)
        {
            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // �f�[�^�e�[�u���쐬
                CreateProductStockTableForHandy();

                this._stockProcMoneyAcs = new StockProcMoneyAcs();
                this._taxRateSetAcs = new TaxRateSetAcs();
                this._goodsAcs = new GoodsAcs();
                this._searchStockAcs = new SearchStockAcs();
                this._blGoodsCdAcs = new BLGoodsCdAcs();
                this._warehouseAcs = new WarehouseAcs();
                this._secInfoAcs = new SecInfoAcs();
                this._employeeAcs = new EmployeeAcs();
                this._makerAcs = new MakerAcs();
                this._stockMngTtlStAcs = new StockMngTtlStAcs();
                this._supplierAcs = new SupplierAcs();

                this._companyInfAcs = new CompanyInfAcs();
                this._companyInf = new CompanyInf();

                this._unitPriceCalculation = new UnitPriceCalculation();

                string errMsg;
                status = this._goodsAcs.SearchInitial(enterpriseCode, sectionCode, out errMsg);

                // ���i�A�N�Z�X���������s�ꍇ
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return;
                }

                // �}�X�^�f�[�^���擾���܂��B
                ReadStockMngTtlSt();
                ReadInitData();         // �P���Z�o�N���X�����f�[�^�Ǎ�
                ReadTaxRate();          // �ŗ��ݒ�}�X�^�Ǎ�
                ReadBLGoodsCdUMnt();    // BL���i�R�[�h�}�X�^�Ǎ�
                ReadWarehouse();        // �q�Ƀ}�X�^�Ǎ�
                ReadSecInfoSet();       // ���_���ݒ�}�X�^�Ǎ�
                ReadEmployee();         // �]�ƈ��}�X�^�Ǎ�
                ReadMakerUMnt();        // ���[�J�[�}�X�^�Ǎ�
                ReadSupplier();
                ReadCompanyInf();  //  �|���D��敪�ɒǉ� 
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR; 
            }
            
        }

        /// <summary>
        /// �f�[�^�e�[�u���쐬�����i�n���f�B�^�[�~�i���p�j
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�e�[�u�����쐬���܂��B�i�n���f�B�^�[�~�i���p�j</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private void CreateProductStockTableForHandy()
        {
            MainProductStock = new DataTable(ctTBL_AdjustStock);

            // No
            MainProductStock.Columns.Add(new DataColumn(ctCOL_RowNum, typeof(Int32)));
            MainProductStock.Columns[ctCOL_RowNum].Caption = "No";
            // �i��
            MainProductStock.Columns.Add(new DataColumn(ctCOL_GoodsNo, typeof(String)));
            MainProductStock.Columns[ctCOL_GoodsNo].Caption = "�i��";
            // �i��
            MainProductStock.Columns.Add(new DataColumn(ctCOL_GoodsName, typeof(String)));
            MainProductStock.Columns[ctCOL_GoodsName].Caption = "�i��";
            // �a�k�R�[�h
            MainProductStock.Columns.Add(new DataColumn(ctCOL_BLGoodsCode, typeof(String)));
            MainProductStock.Columns[ctCOL_BLGoodsCode].Caption = "BL����";
            // ���[�J�[
            MainProductStock.Columns.Add(new DataColumn(ctCOL_GoodsMakerCd, typeof(String)));
            MainProductStock.Columns[ctCOL_GoodsMakerCd].Caption = "���[�J�[";
            // �d����
            MainProductStock.Columns.Add(new DataColumn(ctCOL_SupplierCd, typeof(String)));
            MainProductStock.Columns[ctCOL_SupplierCd].Caption = "�d����";
            // �W�����i
            MainProductStock.Columns.Add(new DataColumn(ctCOL_ListPriceFl, typeof(Double)));
            MainProductStock.Columns[ctCOL_ListPriceFl].Caption = "�W�����i";
            // ���P��
            MainProductStock.Columns.Add(new DataColumn(ctCOL_StockUnitPrice, typeof(Double)));
            MainProductStock.Columns[ctCOL_StockUnitPrice].Caption = "���P��";
            // �d����
            MainProductStock.Columns.Add(new DataColumn(ctCOL_SalesOrderUnit, typeof(Double)));
            MainProductStock.Columns[ctCOL_SalesOrderUnit].Caption = "�d����";
            // �ύX�O�d����
            MainProductStock.Columns.Add(new DataColumn(ctCOL_BfSalesOrderUnit, typeof(Double)));
            MainProductStock.Columns[ctCOL_BfSalesOrderUnit].Caption = "�ύX�O�d����";
            // �d���㐔
            MainProductStock.Columns.Add(new DataColumn(ctCOL_AfSalesOrderUnit, typeof(Double)));
            MainProductStock.Columns[ctCOL_AfSalesOrderUnit].Caption = "�d���㐔";
            // �q�ɒI��
            MainProductStock.Columns.Add(new DataColumn(ctCOL_WarehouseShelfNo, typeof(String)));
            MainProductStock.Columns[ctCOL_WarehouseShelfNo].Caption = "�I��";
            // �����c
            MainProductStock.Columns.Add(new DataColumn(ctCOL_SalesOrderCount, typeof(String)));
            MainProductStock.Columns[ctCOL_SalesOrderCount].Caption = "�����c";
            // �݌ɐ�(�d���݌ɐ�)
            MainProductStock.Columns.Add(new DataColumn(ctCOL_SupplierStock, typeof(Double)));
            MainProductStock.Columns[ctCOL_SupplierStock].Caption = "�݌ɐ�";
            // ���ה��l
            MainProductStock.Columns.Add(new DataColumn(ctCOL_DtlNote, typeof(String)));
            MainProductStock.Columns[ctCOL_DtlNote].Caption = "���ה��l";
            // �쐬����
            MainProductStock.Columns.Add(new DataColumn(ctCOL_CreateDateTime, typeof(DateTime)));
            MainProductStock.Columns[ctCOL_CreateDateTime].Caption = "�쐬����";
            // �X�V����
            MainProductStock.Columns.Add(new DataColumn(ctCOL_UpdateDateTime, typeof(DateTime)));
            MainProductStock.Columns[ctCOL_UpdateDateTime].Caption = "�X�V����";
            // ��ƃR�[�h
            MainProductStock.Columns.Add(new DataColumn(ctCOL_EnterpriseCode, typeof(String)));
            MainProductStock.Columns[ctCOL_EnterpriseCode].Caption = "��ƃR�[�h";
            MainProductStock.Columns[ctCOL_EnterpriseCode].MaxLength = 16;
            // GUID
            MainProductStock.Columns.Add(new DataColumn(ctCOL_FileHeaderGuid, typeof(Guid)));
            MainProductStock.Columns[ctCOL_FileHeaderGuid].Caption = "GUID";
            // �X�V�]�ƈ��R�[�h
            MainProductStock.Columns.Add(new DataColumn(ctCOL_UpdEmployeeCode, typeof(String)));
            MainProductStock.Columns[ctCOL_UpdEmployeeCode].Caption = "�X�V�]�ƈ��R�[�h";
            MainProductStock.Columns[ctCOL_UpdEmployeeCode].MaxLength = 9;
            // �X�V�A�Z���u��ID1
            MainProductStock.Columns.Add(new DataColumn(ctCOL_UpdAssemblyId1, typeof(String)));
            MainProductStock.Columns[ctCOL_UpdAssemblyId1].Caption = "�X�V�A�Z���u��ID1";
            MainProductStock.Columns[ctCOL_UpdAssemblyId1].MaxLength = 30;
            // �X�V�A�Z���u��ID2
            MainProductStock.Columns.Add(new DataColumn(ctCOL_UpdAssemblyId2, typeof(String)));
            MainProductStock.Columns[ctCOL_UpdAssemblyId2].Caption = "�X�V�A�Z���u��ID2";
            MainProductStock.Columns[ctCOL_UpdAssemblyId1].MaxLength = 30;
            // �_����폜�敪
            MainProductStock.Columns.Add(new DataColumn(ctCOL_LogicalDeleteCode, typeof(Int32)));
            MainProductStock.Columns[ctCOL_LogicalDeleteCode].Caption = "�_����폜�敪";
            // ���_�R�[�h
            MainProductStock.Columns.Add(new DataColumn(ctCOL_SectionCode, typeof(String)));
            MainProductStock.Columns[ctCOL_SectionCode].Caption = "���_�R�[�h";
            MainProductStock.Columns[ctCOL_SectionCode].MaxLength = 6;
            // �C���O���P��
            MainProductStock.Columns.Add(new DataColumn(ctCOL_BfStockUnitPrice, typeof(Double)));
            MainProductStock.Columns[ctCOL_BfStockUnitPrice].Caption = "�C���O���P��";
            // �ύX�O�݌ɐ�(�d���݌ɐ�)
            MainProductStock.Columns.Add(new DataColumn(ctCOL_BfSupplierStock, typeof(Double)));
            MainProductStock.Columns[ctCOL_BfSupplierStock].Caption = "�C���O�݌ɐ�";
            // �q�ɃR�[�h
            MainProductStock.Columns.Add(new DataColumn(ctCOL_WarehouseCode, typeof(String)));
            MainProductStock.Columns[ctCOL_WarehouseCode].Caption = "�q�ɃR�[�h";
            MainProductStock.Columns[ctCOL_WarehouseCode].MaxLength = 6;
            // �������t
            MainProductStock.Columns.Add(new DataColumn(ctCOL_AdjustDate, typeof(DateTime)));
            MainProductStock.Columns[ctCOL_AdjustDate].Caption = "�������t";
            // ���͓��t
            MainProductStock.Columns.Add(new DataColumn(ctCOL_InputDay, typeof(DateTime)));
            MainProductStock.Columns[ctCOL_InputDay].Caption = "���͓��t";
            // �d���`��(��)
            MainProductStock.Columns.Add(new DataColumn(ctCOL_SupplierFormalSrc, typeof(Int32)));
            MainProductStock.Columns[ctCOL_SupplierFormalSrc].Caption = "�d���`��(��)";
            // �d�����גʔ�(��)
            MainProductStock.Columns.Add(new DataColumn(ctCOL_StockSlipDtlNumSrc, typeof(Int32)));
            MainProductStock.Columns[ctCOL_StockSlipDtlNumSrc].Caption = "�d�����גʔ�(��)";
            // �݌ɒ����`�[�ԍ�
            MainProductStock.Columns.Add(new DataColumn(ctCOL_StockAdjustSlipNo, typeof(Int32)));
            MainProductStock.Columns[ctCOL_StockAdjustSlipNo].Caption = "�݌ɒ����`�[�ԍ�";
            // �݌Ƀ}�X�^
            MainProductStock.Columns.Add(new DataColumn(ctCOL_Stock, typeof(Stock)));
            MainProductStock.Columns[ctCOL_Stock].Caption = "�݌Ƀ}�X�^";
            // �݌ɒ����f�[�^
            MainProductStock.Columns.Add(new DataColumn(ctCOL_StockAdjust, typeof(StockAdjust)));
            MainProductStock.Columns[ctCOL_StockAdjust].Caption = "�݌ɒ����f�[�^";
            // �݌ɒ������׃f�[�^
            MainProductStock.Columns.Add(new DataColumn(ctCOL_StockAdjustDtl, typeof(StockAdjustDtl)));
            MainProductStock.Columns[ctCOL_StockAdjustDtl].Caption = "�݌ɒ������׃f�[�^";
            // ���i�}�X�^
            MainProductStock.Columns.Add(new DataColumn(ctCOL_GoodsPrice, typeof(GoodsPrice)));
            MainProductStock.Columns[ctCOL_GoodsPrice].Caption = "���i�}�X�^";
            // �d�����z
            MainProductStock.Columns.Add(new DataColumn(ctCOL_StockPriceTaxExc, typeof(Int64)));
            MainProductStock.Columns[ctCOL_StockPriceTaxExc].Caption = "�d�����z";
            // �I�[�v�����i�敪
            MainProductStock.Columns.Add(new DataColumn(ctCOL_OpenPriceDiv, typeof(Int32)));
            MainProductStock.Columns[ctCOL_OpenPriceDiv].Caption = "�I�[�v�����i�敪";
            // �d���旪��
            MainProductStock.Columns.Add(new DataColumn(ctCOL_SupplierSnm, typeof(string)));
            MainProductStock.Columns[ctCOL_SupplierSnm].Caption = "�d���旪��";
        }

        /// <summary>
        /// ���ԏ��̕␳�i�n���f�B�^�[�~�i���p�j
        /// </summary>
        /// <param name="inspectDataAddList">���i�o�^�f�[�^</param>
        /// <returns>�␳�X�e�[�^�X�u0�F����  0�ȊO�F���s�v</returns>
        /// <remarks>
        /// <br>Note       : ���ԏ��̎d�����A�d���㐔��␳���܂��B�i�n���f�B�^�[�~�i���p�j</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int SetInspectDataForHandy(ArrayList inspectDataAddList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // ���i�o�^�f�[�^���Ȃ��ꍇ
                if (inspectDataAddList == null || inspectDataAddList.Count == 0)
                {
                    return status;
                }

                string errMessage = string.Empty;
                object searchObj = LoadAssembly(AssemblyIdPmhnd01114d, AssemblyIdPmhnd01114dClassName, out errMessage);
                // ���i�o�^�����I�u�W�F�N�g���Ȃ��ꍇ
                if (searchObj == null)
                {
                    return status;
                }

                // ���i�o�^���[�N�^�C�v���擾���܂��B
                Type searchType = searchObj.GetType();

                for (int i = 0; i < inspectDataAddList.Count; i++)
                {
                    // �d�����גʔ�
                    long stockSlipDtlNum = (long)searchType.GetProperty(StockSlipDtlNum).GetValue(inspectDataAddList[i], null);
                    // ���i��
                    double inspectCnt = (double)searchType.GetProperty(InspectCnt).GetValue(inspectDataAddList[i], null);
                    // ����.�d�����גʔԂɂ��A�ϐ�_mainProductStock�̎d�����גʔԁi���j�ƈ�v���郌�R�[�h���������܂��B
                    string filter = string.Format("{0}={1}",
                                MainProductStock.Columns[ctCOL_StockSlipDtlNumSrc], stockSlipDtlNum);

                    DataRow[] gridDataRow =
                        (DataRow[])MainProductStock.Select(filter);

                    if (gridDataRow.Length > 0)
                    {
                        // �d����
                        gridDataRow[0][ctCOL_SalesOrderUnit] = inspectCnt;
                        // �d���㐔�͍݌ɐ�+�d�����ˍ݌ɐ�+����.���i���֕ύX���܂��B
                        gridDataRow[0][ctCOL_AfSalesOrderUnit] = inspectCnt + (double)gridDataRow[0][ctCOL_SupplierStock];
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// DB�o�^�p�f�[�^�I�u�W�F�N�g�̎擾�����i�n���f�B�^�[�~�i���p�j
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="paraObj">�o�^�p�f�[�^�I�u�W�F�N�g</param>
        /// <returns>�擾���ʃX�e�[�^�X�u0�F����  0�ȊO�F���s�v</returns>
        /// <remarks>
        /// <br>Note       : DB�o�^�p�f�[�^�I�u�W�F�N�g���擾���܂��B�i�n���f�B�^�[�~�i���p�j</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int GetSaveDBDataForHandy(string employeeCode, string sectionCode, out object paraObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            paraObj = null;

            try
            {
                CustomSerializeArrayList registList = new CustomSerializeArrayList();

                ArrayList stockAdjustWorkList = new ArrayList();
                ArrayList stockAdjustDtlWorkList = new ArrayList();

                StockAdjust stockAdjust;
                StockAdjustDtl stockAdjustDtl;

                Dictionary<int, DataRow> saveStokRowDic = new Dictionary<int, DataRow>();

                for (int index = 0; index < MainProductStock.Rows.Count; index++)
                {
                    if ((MainProductStock.Rows[index][ctCOL_FileHeaderGuid] == DBNull.Value) ||
                        ((Guid)MainProductStock.Rows[index][ctCOL_FileHeaderGuid] == Guid.Empty))
                    {
                        continue;
                    }

                    if (!saveStokRowDic.ContainsKey(index))
                    {
                        // �ۑ��p�f�[�^�ɒǉ�
                        saveStokRowDic.Add(index, MainProductStock.Rows[index]);
                    }
                }

                int count = 0;
                foreach (DataRow dataRow in saveStokRowDic.Values)
                {
                    // �ύX�O�̍݌ɒ����f�[�^���擾
                    stockAdjust = (StockAdjust)dataRow[ctCOL_StockAdjust];

                    // �ύX�O�̍݌ɒ������׃f�[�^���擾
                    stockAdjustDtl = (StockAdjustDtl)dataRow[ctCOL_StockAdjustDtl];

                    // ��ʏ��𔽉f
                    this.GetScreenInfoForHandy(sectionCode, employeeCode, ref stockAdjust, ref stockAdjustDtl, dataRow);

                    // �݌ɒ����f�[�^�͂P���R�[�h�����쐬
                    if (count == 0)
                    {
                        // �݌ɒ����f�[�^�ǉ�
                        stockAdjustWorkList.Add(CopyToStockAdjustWorkFromStockAdjust(stockAdjust));
                    }

                    // �݌ɒ������׃f�[�^�ǉ�
                    stockAdjustDtlWorkList.Add(CopyToStockAdjustDtlWorkFromStockAdjustDtl(stockAdjustDtl));
                    count++;
                }

                registList.Add(stockAdjustWorkList);
                registList.Add(stockAdjustDtlWorkList);

                paraObj = (object)registList;
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// ��ʏ��擾�����i�n���f�B�^�[�~�i���p�j
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="stockAdjust">�݌ɒ����f�[�^</param>
        /// <param name="stockAdjustDtl">�݌ɒ������׃f�[�^</param>
        /// <param name="dataRow">�Ώۍs</param>
        /// <remarks>
        /// <br>Note       : ��ʏ����擾���܂��B�i�n���f�B�^�[�~�i���p�j</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private void GetScreenInfoForHandy(string employeeCode, string sectionCode, ref StockAdjust stockAdjust, ref StockAdjustDtl stockAdjustDtl, DataRow dataRow)
        {
            //------------------------------------------------------------
            // �݌ɒ����f�[�^
            //------------------------------------------------------------
            // ��ƃR�[�h
            stockAdjust.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // ���_�R�[�h
            stockAdjust.SectionCode = sectionCode;
            // �݌ɒ����`�[�ԍ�
            stockAdjust.StockAdjustSlipNo = (dataRow[ctCOL_StockAdjustSlipNo] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockAdjustSlipNo] : 0;
            // �󕥌��`�[�敪(�݌Ɏd��)
            stockAdjust.AcPaySlipCd = 13;
            // �󕥌�����敪(�݌ɐ�����)
            stockAdjust.AcPayTransCd = 10;
            // �������t
            stockAdjust.AdjustDate = DateTime.Today;
            // ���͓��t
            stockAdjust.InputDay = DateTime.Today;
            // �d�����_�R�[�h
            stockAdjust.StockSectionCd = sectionCode;
            // �d�����_����
            stockAdjust.StockSectionNm = GetSectionName(sectionCode);
            // �d�����͎҃R�[�h
            stockAdjust.StockInputCode = employeeCode;
            // �d�����͎Җ���
            stockAdjust.StockInputName = GetEmployeeName(stockAdjust.StockInputCode);
            if (stockAdjust.StockInputName.Length > 16)
            {
                stockAdjust.StockInputName = stockAdjust.StockInputName.Substring(0, 16);
            }
            // �d���S���҃R�[�h
            stockAdjust.StockAgentCode = employeeCode;
            // �d���S���Җ���
            stockAdjust.StockAgentName = GetEmployeeName(stockAdjust.StockAgentCode);
            if (stockAdjust.StockAgentName.Length > 16)
            {
                stockAdjust.StockAgentName = stockAdjust.StockAgentName.Substring(0, 16);
            }
            // �d�����z���v
            stockAdjust.StockSubttlPrice = GetTotalPriceForHandy();
            // �`�[���l
            stockAdjust.SlipNote = string.Empty;

            //------------------------------------------------------------
            // �݌ɒ������׃f�[�^
            //------------------------------------------------------------
            // ��ƃR�[�h
            stockAdjustDtl.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // ���_�R�[�h
            stockAdjustDtl.SectionCode = sectionCode;
            // �݌ɒ����`�[�ԍ�
            stockAdjustDtl.StockAdjustSlipNo = (dataRow[ctCOL_StockAdjustSlipNo] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockAdjustSlipNo] : 0;
            // �݌ɒ����s�ԍ�
            stockAdjustDtl.StockAdjustRowNo = (Int32)dataRow[ctCOL_RowNum];
            // �d���`��(�d��)
            stockAdjustDtl.SupplierFormalSrc = (dataRow[ctCOL_SupplierFormalSrc] != DBNull.Value) ? (Int32)dataRow[ctCOL_SupplierFormalSrc] : 0;
            // �d�����גʔ�
            stockAdjustDtl.StockSlipDtlNumSrc = (dataRow[ctCOL_StockSlipDtlNumSrc] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockSlipDtlNumSrc] : 0;
            // �󕥌��`�[�敪(�݌Ɏd��)
            stockAdjustDtl.AcPaySlipCd = 13;
            // �󕥌�����敪(�݌ɒ�����)
            stockAdjustDtl.AcPayTransCd = 10;
            // �������t
            stockAdjustDtl.AdjustDate = DateTime.Today;
            // ���͓��t
            stockAdjustDtl.InputDay = DateTime.Today;
            // ���[�J�[�R�[�h
            stockAdjustDtl.GoodsMakerCd = StringObjToInt(dataRow[ctCOL_GoodsMakerCd]);
            // ���[�J�[����
            stockAdjustDtl.MakerName = GetMakerName(stockAdjustDtl.GoodsMakerCd);
            // �i��
            stockAdjustDtl.GoodsNo = (dataRow[ctCOL_GoodsNo] != DBNull.Value) ? (string)dataRow[ctCOL_GoodsNo] : "";
            // �i��
            stockAdjustDtl.GoodsName = (dataRow[ctCOL_GoodsName] != DBNull.Value) ? (string)dataRow[ctCOL_GoodsName] : "";
            // �d���P��
            stockAdjustDtl.StockUnitPriceFl = (dataRow[ctCOL_StockUnitPrice] != DBNull.Value) ? (Double)dataRow[ctCOL_StockUnitPrice] : 0;
            // �ύX�O�d���P��
            stockAdjustDtl.BfStockUnitPriceFl = (dataRow[ctCOL_BfStockUnitPrice] != DBNull.Value) ? (Double)dataRow[ctCOL_BfStockUnitPrice] : 0;
            // ������(�d�������Z�b�g)
            stockAdjustDtl.AdjustCount = (double)dataRow[ctCOL_SalesOrderUnit];
            // ���ה��l
            stockAdjustDtl.DtlNote = (dataRow[ctCOL_DtlNote] != DBNull.Value) ? (string)dataRow[ctCOL_DtlNote] : "";
            // �q�ɃR�[�h
            stockAdjustDtl.WarehouseCode = (dataRow[ctCOL_WarehouseCode] != DBNull.Value) ? (string)dataRow[ctCOL_WarehouseCode] : "";
            // �q�ɖ���
            stockAdjustDtl.WarehouseName = GetWarehouseName(stockAdjustDtl.WarehouseCode);
            // BL���i�R�[�h
            stockAdjustDtl.BLGoodsCode = StringObjToInt(dataRow[ctCOL_BLGoodsCode]);
            // BL���i����
            stockAdjustDtl.BLGoodsFullName = GetBLGoodsName(stockAdjustDtl.BLGoodsCode);
            // �q�ɒI��
            stockAdjustDtl.WarehouseShelfNo = (dataRow[ctCOL_WarehouseShelfNo] != DBNull.Value) ? (string)dataRow[ctCOL_WarehouseShelfNo] : "";
            // �艿
            stockAdjustDtl.ListPriceFl = (dataRow[ctCOL_ListPriceFl] != DBNull.Value) ? (Double)dataRow[ctCOL_ListPriceFl] : 0;

            // �I�[�v�����i�敪
            stockAdjustDtl.OpenPriceDiv = (dataRow[ctCOL_OpenPriceDiv] != DBNull.Value) ? (Int32)dataRow[ctCOL_OpenPriceDiv] : 0;

            // �d�����z
            if ((dataRow[ctCOL_StockUnitPrice] == DBNull.Value) || ((double)dataRow[ctCOL_StockUnitPrice] == 0) ||
                (dataRow[ctCOL_SalesOrderUnit] == DBNull.Value) || ((double)dataRow[ctCOL_SalesOrderUnit] == 0))
            {
                stockAdjustDtl.StockPriceTaxExc = 0;
            }

            //�V�K�o�^�̏ꍇ
            else if (stockAdjust.FileHeaderGuid == Guid.Empty)
            {
                stockAdjustDtl.StockPriceTaxExc = GetStockPriceTaxExc((double)dataRow[ctCOL_StockUnitPrice], (double)dataRow[ctCOL_SalesOrderUnit]);
            }
            else
            {
                if (((double)dataRow[ctCOL_StockUnitPrice] != (double)dataRow[ctCOL_BfStockUnitPrice]) ||
                    ((double)dataRow[ctCOL_SalesOrderUnit] != (double)dataRow[ctCOL_BfSalesOrderUnit]))
                {
                    stockAdjustDtl.StockPriceTaxExc = GetStockPriceTaxExc((double)dataRow[ctCOL_StockUnitPrice], (double)dataRow[ctCOL_SalesOrderUnit]);
                }
                else
                {
                    stockAdjustDtl.StockPriceTaxExc = (long)dataRow[ctCOL_StockPriceTaxExc];
                }
            }

            // �d����
            stockAdjustDtl.SupplierCd = (dataRow[ctCOL_SupplierCd] != DBNull.Value) ? int.Parse((string)dataRow[ctCOL_SupplierCd]) : 0;
            // �d���旪��
            stockAdjustDtl.SupplierSnm = (dataRow[ctCOL_SupplierSnm] != DBNull.Value) ? (string)dataRow[ctCOL_SupplierSnm] : "";
        }

        /// <summary>
        /// �����c�Ɖ���[�g���o���ʃO���b�h�\�������i�n���f�B�^�[�~�i���p�j
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="orderListResultWorkList">�����c�Ɖ���[�g���o���ʃ��X�g</param>
        /// <returns>�擾���ʃX�e�[�^�X�u0�F����  0�ȊO�F���s�v</returns>
        /// <remarks>
        /// <br>Note       : �����c�Ɖ���[�g���o���ʂ��O���b�h�֔��f���܂��B(�����c�Ɖ����Ɏg�p���܂�)�i�n���f�B�^�[�~�i���p�j</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int OrderListResultWorkToGridForHandy(string sectionCode, List<OrderListResultWork> orderListResultWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR; 

            try
            {
                if ((orderListResultWorkList == null) || (orderListResultWorkList.Count == 0))
                {
                    return status;
                }

                // �����c�Ɖ���[�g���o���ʃ��X�g�ɑΉ�����݌Ƀ}�X�^���X�g���擾
                List<Stock> stockList = GetStockList(orderListResultWorkList);

                // �݌Ƀ}�X�^���X�g�ɑΉ����鏤�i�A���f�[�^���X�g���擾
                List<GoodsUnitData> goodsUnitDataList = GetGoodsUnitDataListForHandy(sectionCode, stockList, true);

                DataRow newRow = null;
                for (int index = 0; index < stockList.Count; index++)
                {
                    newRow = MainProductStock.NewRow();

                    // �݌ɏ�񔽉f
                    StockChangeRowGrsForHandy(index + 1, ref newRow, stockList[index], goodsUnitDataList[index], orderListResultWorkList[index]);

                    MainProductStock.Rows.Add(newRow);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL; 
            }
            catch
            {
                // �����Ȃ��B
            }
            return status;
        }

        /// <summary>
        /// �݌ɏ�񔽉f�����i�n���f�B�^�[�~�i���p�j
        /// </summary>
        /// <param name="rowNum">�s�ԍ�</param>
        /// <param name="newRow">�V�K�s</param>
        /// <param name="stock">�݌Ƀ}�X�^���</param>
        /// <param name="goodsUnitData">���i�A���f�[�^���</param>
        /// <param name="orderListResultWork">�����f�[�^���</param>
        /// <remarks>
        /// <br>Note       : �݌ɏ��𔽉f���܂��B�i�n���f�B�^�[�~�i���p�j</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private void StockChangeRowGrsForHandy(int rowNum, ref DataRow newRow, Stock stock, GoodsUnitData goodsUnitData, OrderListResultWork orderListResultWork)
        {
            this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData);

            newRow[ctCOL_RowNum] = rowNum;

            newRow[ctCOL_CreateDateTime] = orderListResultWork.OrderDataCreateDate;
            newRow[ctCOL_UpdateDateTime] = stock.UpdateDateTime;
            newRow[ctCOL_EnterpriseCode] = stock.EnterpriseCode;
            newRow[ctCOL_FileHeaderGuid] = Guid.NewGuid();
            newRow[ctCOL_UpdEmployeeCode] = stock.UpdEmployeeCode;
            newRow[ctCOL_UpdAssemblyId1] = stock.UpdAssemblyId1;
            newRow[ctCOL_UpdAssemblyId2] = stock.UpdAssemblyId2;
            newRow[ctCOL_LogicalDeleteCode] = stock.LogicalDeleteCode;
            newRow[ctCOL_SectionCode] = stock.SectionCode;                          // ���_�R�[�h

            // �݌ɒ����s�ԍ�

            // ���[�J�[�R�[�h
            if (orderListResultWork.GoodsMakerCd == 0)
            {
                newRow[ctCOL_GoodsMakerCd] = "";
            }
            else
            {
                newRow[ctCOL_GoodsMakerCd] = orderListResultWork.GoodsMakerCd.ToString(GoodsMakerCdFormat);
            }
            newRow[ctCOL_GoodsNo] = orderListResultWork.GoodsNo;                            // �i��
            newRow[ctCOL_GoodsName] = orderListResultWork.GoodsName;                        // �i��
            newRow[ctCOL_StockUnitPrice] = orderListResultWork.StockUnitPriceFl;            // ���P��
            newRow[ctCOL_BfStockUnitPrice] = orderListResultWork.StockUnitPriceFl;          // �ύX�O���P��
            newRow[ctCOL_WarehouseCode] = orderListResultWork.WarehouseCode;                // �q�ɃR�[�h
            // BL���i�R�[�h
            if (orderListResultWork.BLGoodsCode == 0)
            {
                newRow[ctCOL_BLGoodsCode] = "";
            }
            else
            {
                newRow[ctCOL_BLGoodsCode] = orderListResultWork.BLGoodsCode.ToString(BLGoodsCodeFormat);
            }
            newRow[ctCOL_WarehouseShelfNo] = stock.WarehouseShelfNo;                        // �q�ɒI��
            newRow[ctCOL_ListPriceFl] = orderListResultWork.ListPriceTaxExcFl;              // �W�����i
            newRow[ctCOL_OpenPriceDiv] = 0;                                                 // �I�[�v�����i�敪
            // �d����
            if (orderListResultWork.SupplierCd == 0)
            {
                newRow[ctCOL_SupplierCd] = DBNull.Value;
                newRow[ctCOL_SupplierSnm] = "";
            }
            else
            {
                newRow[ctCOL_SupplierCd] = orderListResultWork.SupplierCd.ToString(SupplierCdFormat);
                newRow[ctCOL_SupplierSnm] = GetSupplierSnm(orderListResultWork.SupplierCd);
            }
            newRow[ctCOL_SalesOrderUnit] = orderListResultWork.OrderRemainCnt;                      // �d����
            newRow[ctCOL_BfSalesOrderUnit] = orderListResultWork.OrderRemainCnt;                      // �d����
            newRow[ctCOL_SupplierStock] = stock.ShipmentPosCnt;                                     // �݌ɐ�
            newRow[ctCOL_BfSupplierStock] = stock.ShipmentPosCnt;                                     // �ύX�O�݌ɐ�
            newRow[ctCOL_AfSalesOrderUnit] = orderListResultWork.OrderRemainCnt + stock.ShipmentPosCnt; // �d���㐔
            newRow[ctCOL_SalesOrderCount] = stock.SalesOrderCount;                                  // �����c

            // �d�����z
            newRow[ctCOL_StockPriceTaxExc] = 0;

            newRow[ctCOL_Stock] = stock.Clone();                                                    // �݌Ƀ}�X�^
            newRow[ctCOL_StockAdjust] = new StockAdjust();                                        // �݌ɒ����f�[�^
            newRow[ctCOL_StockAdjustDtl] = new StockAdjustDtl();                                  // �݌ɒ������׃f�[�^

            GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Today, goodsUnitData.GoodsPriceList);
            newRow[ctCOL_GoodsPrice] = goodsPrice;                                                  // ���i�}�X�^

            newRow[ctCOL_SupplierFormalSrc] = orderListResultWork.SupplierFormal;                   // �d���`��
            newRow[ctCOL_StockSlipDtlNumSrc] = orderListResultWork.StockSlipDtlNum;                 // �d�����גʔ�
            newRow[ctCOL_DtlNote] = orderListResultWork.StockDtiSlipNote1.Trim();                   // ���ה��l
        }

        /// <summary>
        /// ���i�A���f�[�^���X�g�擾�����i�n���f�B�^�[�~�i���p�j
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="stockList">�݌Ƀ}�X�^���X�g</param>
        /// <param name="flag">�`�[�ԍ��Ō������邩�ǂ����𔻒f����p�̃t���O</param>
        /// <returns>���i�A���f�[�^���X�g</returns>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^���X�g��菤�i�A���f�[�^���X�g���擾���܂��B�i�n���f�B�^�[�~�i���p�j</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private List<GoodsUnitData> GetGoodsUnitDataListForHandy(string sectionCode, List<Stock> stockList, params bool[] flag)
        {
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();

            if ((stockList == null) || (stockList.Count == 0))
            {
                return goodsUnitDataList;
            }

            int status;
            string errMsg;
            List<GoodsUnitData> retGoodsUnitDataList;

            foreach (Stock stock in stockList)
            {
                GoodsUnitData goodsUnitData = new GoodsUnitData();

                // ���i�A���f�[�^���������ݒ�
                GoodsCndtn goodsCndtn;
                SetGoodsCndtn(out goodsCndtn, stock.EnterpriseCode, stock.GoodsMakerCd, stock.GoodsNo, sectionCode);

                try
                {
                    // ���i����
                    status = GetGoodsUnitDataList(goodsCndtn, out retGoodsUnitDataList, out errMsg, flag);
                    if (status == 0)
                    {
                        goodsUnitData = retGoodsUnitDataList[0];
                    }
                    else
                    {
                        goodsUnitData = new GoodsUnitData();
                    }
                }
                catch
                {
                    goodsUnitData = new GoodsUnitData();
                }

                goodsUnitDataList.Add(goodsUnitData);
            }

            return goodsUnitDataList;
        }

        /// <summary>
        /// ���v���z�擾�����i�n���f�B�^�[�~�i���p�j
        /// </summary>
        /// <returns>���v���z</returns>
        /// <remarks>
        /// <br>Note       : ���v���z���擾���܂��B�i�n���f�B�^�[�~�i���p�j</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public Int64 GetTotalPriceForHandy()
        {
            Int64 totalPrice = 0;
            double dblTotalPrice = 0;

            // (�P���~�d����)�̍��v�����߂܂�
            for (int i = 0; i < MainProductStock.Rows.Count; i++)
            {
                if (MainProductStock.Rows[i][ctCOL_StockUnitPrice] == DBNull.Value)
                {
                    continue;
                }
                if (MainProductStock.Rows[i][ctCOL_StockUnitPrice].ToString().Trim() == "")
                {
                    continue;
                }
                if (MainProductStock.Rows[i][ctCOL_SalesOrderUnit] == DBNull.Value)
                {
                    continue;
                }
                if (MainProductStock.Rows[i][ctCOL_SalesOrderUnit].ToString().Trim() == "")
                {
                    continue;
                }

                dblTotalPrice = (double)MainProductStock.Rows[i][ctCOL_StockUnitPrice] *
                                (double)MainProductStock.Rows[i][ctCOL_SalesOrderUnit];

                if ((dblTotalPrice % 1) != 0)
                {
                    switch (_stockMngTtlSt.FractionProcCd)
                    {
                        case 1:
                            {
                                // �؂�̂�
                                totalPrice += (long)(dblTotalPrice / 1);
                                break;
                            }
                        case 2:
                            {
                                // �l�̌ܓ�
                                if (dblTotalPrice >= 0)
                                {
                                    totalPrice += (long)((dblTotalPrice + 0.5) / 1);
                                }
                                else
                                {
                                    totalPrice += (long)((dblTotalPrice - 0.5) / 1);
                                }
                                break;
                            }
                        case 3:
                            {
                                // �؂�グ
                                if (dblTotalPrice % 1 == 0)
                                {
                                    totalPrice += (long)(dblTotalPrice);
                                }
                                else
                                {
                                    if (dblTotalPrice >= 0)
                                    {
                                        totalPrice += (long)((dblTotalPrice + 1) / 1);
                                    }
                                    else
                                    {
                                        totalPrice += (long)((dblTotalPrice - 1) / 1);
                                    }
                                }
                                break;
                            }
                    }
                }
                else
                {
                    totalPrice += (long)dblTotalPrice;
                }
            }

            return totalPrice;
        }

        /// <summary>
        /// �A�Z���u���C���X�^���X��
        /// </summary>
        /// <param name="asmname">�A�Z���u������</param>
        /// <param name="classname">�N���X����</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <returns>�C���X�^���X�����ꂽ�N���X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private object LoadAssembly(string asmname, string classname, out string errMessage)
        {
            object obj = null;
            errMessage = string.Empty;

            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
                Type objType = asm.GetType(classname);
                // �C���X�^���X�^�C�v������ꍇ�A�C���X�^���X�I�u�W�F�N�g�𐶐����܂��B
                if (objType != null)
                {
                    obj = Activator.CreateInstance(objType);
                }
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
            }
            return obj;
        }
        #endregion
        // ------ ADD 2017/08/11 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<
    }
}
