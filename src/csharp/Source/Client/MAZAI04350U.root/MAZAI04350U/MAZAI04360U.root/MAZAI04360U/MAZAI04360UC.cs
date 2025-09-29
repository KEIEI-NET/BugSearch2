using System;
using System.Collections;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �݌ɒ������ח�\���󋵃N���X
	/// </summary>
	internal class PtAdjustStockDtlDisplayStatus
	{
		//====================================================================================================
		//  �v���C�x�[�g�萔
		//====================================================================================================
		#region �v���C�x�[�g�萔
		/// <summary>
		/// �N���XID(TEMP�ۑ��p)
		/// </summary>
		private const string CT_CLASSID = "MAZAI04360UC";

        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// KEYLIST(TEMP�ۑ��p)
		/// </summary>
		private const string CT_KEYLIST = "StockAdjustDtlStatus";
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        
        #region �񏇒�`�萔
        // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
        #region DEL 2008/07/24
        ///// <summary>�s�ԍ�</summary>
        //public const int ctINDX_RowNum = 0;
        ///// <summary>���i�R�[�h</summary>
        //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        ////public const int ctINDX_GoodsCode = ctINDX_RowNum + 1;
        //public const int ctINDX_GoodsNo = ctINDX_RowNum + 1;
        //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        ///// <summary>���i�K�C�h</summary>
        //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        ////public const int ctINDX_GoodsGuide = ctINDX_GoodsCode + 1;
        //public const int ctINDX_GoodsGuide = ctINDX_GoodsNo + 1;
        //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        ///// <summary>���i��</summary>
        //public const int ctINDX_GoodsName = ctINDX_GoodsGuide + 1;
        //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        /////// <summary>�q�ɃR�[�h</summary>
        ////public const int ctINDX_WarehouseCode = ctINDX_GoodsName + 1;
        ///// <summary>���[�J�[�R�[�h</summary>
        //public const int ctINDX_GoodsMakerCd = ctINDX_GoodsName + 1;
        ///// <summary>���[�J�[����</summary>
        //public const int ctINDX_MakerName = ctINDX_GoodsMakerCd + 1;
        ///// <summary>�d���於��</summary>
        //public const int ctINDX_CustomerName = ctINDX_MakerName + 1;
        ///// <summary>�a�k���i�R�[�h</summary>
        //public const int ctINDX_BLGoodsCode = ctINDX_CustomerName + 1;
        ///// <summary>�q�ɃR�[�h</summary>
        //public const int ctINDX_WarehouseCode = ctINDX_BLGoodsCode + 1;
        //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        ///// <summary>�q�ɖ���</summary>
        //public const int ctINDX_WarehouseName = ctINDX_WarehouseCode + 1;
        //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        /////// <summary>�����ԍ�</summary>
        ////public const int ctINDX_ProductNumber = ctINDX_WarehouseName + 1;
        /////// <summary>�g�єԍ�</summary>
        ////public const int ctINDX_StockTelNo1 = ctINDX_ProductNumber + 1;
        /////// <summary>�C���O����</summary>
        ////public const int ctINDX_BfProductNumber = ctINDX_StockTelNo1+ 1;
        /////// <summary>���i���</summary>
        ////public const int ctINDX_GoodsCodeStatus = ctINDX_BfProductNumber + 1;
        /////// <summary>�݌ɐ�(�d���݌ɐ�)</summary>
        ////public const int ctINDX_SupplierStock = ctINDX_GoodsCodeStatus + 1;
        ///// <summary>�I��</summary>
        //public const int ctINDX_WarehouseShelfNo = ctINDX_WarehouseName + 1;
        ///// <summary>�C���O�I��</summary>
        //public const int ctINDX_BfWarehouseShelfNo = ctINDX_WarehouseShelfNo + 1;
        ///// <summary>�݌ɐ�(�d���݌ɐ�)</summary>
        //public const int ctINDX_SupplierStock = ctINDX_BfWarehouseShelfNo + 1;
        //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        ///// <summary>�݌ɐ�(�d���݌ɐ�)</summary>
        //public const int ctINDX_TrustCount = ctINDX_SupplierStock + 1;
        ///// <summary>������</summary>
        //public const int ctINDX_AdjustCount = ctINDX_TrustCount + 1;
        ///// <summary>�d���P��</summary>
        //public const int ctINDX_StockUnitPrice = ctINDX_AdjustCount + 1;
        ///// <summary>�C���O�����P��</summary>
        //public const int ctINDX_BfStockUnitPrice = ctINDX_StockUnitPrice + 1;
        //// 2008.01.17 �C�� >>>>>>>>>>>>>>>>>>>>
        ///// <summary>�������z</summary>
        ////public const int ctINDX_AdjustPrice = ctINDX_StockUnitPrice + 1;
        //public const int ctINDX_AdjustPrice = ctINDX_BfStockUnitPrice + 1;
        //// 2008.01.17 �C�� <<<<<<<<<<<<<<<<<<<<
        //// 2008.01.17 �ǉ� >>>>>>>>>>>>>>>>>>>>
        ///// <summary>���ה��l</summary>
        //public const int ctINDX_DtlNote = ctINDX_AdjustPrice + 1;
        //// 2008.01.17 �ǉ� <<<<<<<<<<<<<<<<<<<<
        //// 2008.02.15 �ǉ� >>>>>>>>>>>>>>>>>>>>
        ///// <summary>�艿�i�����j</summary>
        //public const int ctINDX_ListPriceFl = ctINDX_DtlNote + 1;
        //// 2008.02.15 �ǉ� <<<<<<<<<<<<<<<<<<<<
        #endregion DEL 2008/07/24

        /// <summary>No</summary>
        public const int ctINDX_RowNum = 0;
        /// <summary>�i��</summary>
        public const int ctINDX_GoodsNo = ctINDX_RowNum + 1;
        /// <summary>�i��</summary>
        public const int ctINDX_GoodsName = ctINDX_GoodsNo + 1;
        /// <summary>�a�k���i�R�[�h</summary>
        public const int ctINDX_BLGoodsCode = ctINDX_GoodsName + 1;
        /// <summary>���[�J�[</summary>
        public const int ctINDX_GoodsMakerCd = ctINDX_BLGoodsCode + 1;
        /// <summary>�d����</summary>
        public const int ctINDX_SupplierCd = ctINDX_GoodsMakerCd + 1;
        /// <summary>�W�����i</summary>
        public const int ctINDX_ListPriceFl = ctINDX_SupplierCd + 1;
        /// <summary>���P��</summary>
        public const int ctINDX_StockUnitPrice = ctINDX_ListPriceFl + 1;
        /// <summary>�d����</summary>
        public const int ctINDX_SalesOrderUnit = ctINDX_StockUnitPrice + 1;
        /// <summary>�d���㐔</summary>
        public const int ctINDX_AfSalesOrderUnit = ctINDX_SalesOrderUnit + 1;
        /// <summary>�I��</summary>
        public const int ctINDX_WarehouseShelfNo = ctINDX_AfSalesOrderUnit + 1;
        /// <summary>�����c</summary>
        public const int ctINDX_SalesOrderCount = ctINDX_WarehouseShelfNo + 1;
        /// <summary>�݌ɐ�(�d���݌ɐ�)</summary>
        public const int ctINDX_SupplierStock = ctINDX_SalesOrderCount + 1;
        /// <summary>���ה��l</summary>
        public const int ctINDX_DtlNote = ctINDX_SupplierStock + 1;
        
        // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
        #endregion

		#region �񖼒�`�萔
        // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
        #region DEL 2008/07/24
        ///// <summary>�s�ԍ�</summary>
        //public const string ctCOL_RowNum = "RowNum";
        ///// <summary>���i�R�[�h</summary>
        //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        ////public const string ctCOL_GoodsCode = "GoodsCode";
        //public const string ctCOL_GoodsNo = "GoodsNo";
        //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        ///// <summary>���i�K�C�h</summary>
        //public const string ctCOL_GoodsGuide = "GoodsGuide";
        ///// <summary>���i��</summary>
        //public const string ctCOL_GoodsName = "GoodsName";
        //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        ///// <summary>���[�J�[�R�[�h</summary>
        //public const string ctCOL_GoodsMakerCd = "GoodsMakerCd";
        ///// <summary>���[�J�[����</summary>
        //public const string ctCOL_MakerName = "MakerName";
        ///// <summary>�d���於��</summary>
        //public const string ctCOL_CustomerName = "CustomerName";
        ///// <summary>�a�k���i�R�[�h</summary>
        //public const string ctCOL_BLGoodsCode = "BLGoodsCode";
        //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        ///// <summary>�q�ɃR�[�h</summary>
        //public const string ctCOL_WarehouseCode = "WarehouseCode";
        ///// <summary>�q�ɖ���</summary>
        //public const string ctCOL_WarehouseName = "WarehouseName";
        ////// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        /////// <summary>�����ԍ�</summary>
        ////public const string ctCOL_ProductNumber = "ProductNumber";
        /////// <summary>�g�єԍ�</summary>
        ////public const string ctCOL_StockTelNo1 = "StockTelNo1";
        /////// <summary>�C���O����</summary>
        ////public const string ctCOL_BfProductNumber = "BfProductNumber";
        /////// <summary>���i���</summary>
        ////public const string ctCOL_GoodsCodeStatus = "GoodsCodeStatus";
        ///// <summary>�I��</summary>
        //public const string ctCOL_WarehouseShelfNo = "WarehouseShelfNo";
        ///// <summary>�C���O�I��</summary>
        //public const string ctCOL_BfWarehouseShelfNo = "BfWarehouseShelfNo";
        //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        ///// <summary>�݌ɐ�(�d���݌ɐ�)</summary>
        //public const string ctCOL_SupplierStock = "SupplierStock";
        ///// <summary>�����</summary>
        //public const string ctCOL_TrustCount = "TrustCount";
        ///// <summary>������</summary>
        //public const string ctCOL_AdjustCount = "AdjustCount";
        ///// <summary>�d���P��</summary>
        //public const string ctCOL_StockUnitPrice = "StockUnitPrice";
        ///// <summray>�C���O�d���P��</summray>
        //public const string ctCOL_BfStockUnitPrice = "BfStockUnitPrice";
        ///// <summary>�������z</summary>
        //public const string ctCOL_AdjustPrice = "AdjustPrice";
        //// 2008.01.17 �ǉ� >>>>>>>>>>>>>>>>>>>>
        ///// <summary>���ה��l</summary>
        //public const string ctCOL_DtlNote = "DtlNote";
        //// 2008.01.17 �ǉ� <<<<<<<<<<<<<<<<<<<<
        //// 2008.02.15 �ǉ� >>>>>>>>>>>>>>>>>>>>
        ///// <summary>�艿�i�����j</summary>
        //public const string ctCOL_ListPriceFl = "ListPriceFl";
        //// 2008.02.15 �ǉ� <<<<<<<<<<<<<<<<<<<<
        #endregion DEL 2008/07/24

        /// <summary>No</summary>
        public const string ctCOL_RowNum = "RowNum";
        /// <summary>�i��</summary>
        public const string ctCOL_GoodsNo = "GoodsNo";
        /// <summary>�i��</summary>
        public const string ctCOL_GoodsName = "GoodsName";
        /// <summary>�a�k���i�R�[�h</summary>
        public const string ctCOL_BLGoodsCode = "BLGoodsCode";
        /// <summary>���[�J�[</summary>
        public const string ctCOL_GoodsMakerCd = "GoodsMakerCd";
        /// <summary>�d����</summary>
        public const string ctCOL_SupplierCd = "SupplierCd";
        /// <summary>�W�����i</summary>
        public const string ctCOL_ListPriceFl = "ListPriceFl";
        /// <summary>���P��</summary>
        public const string ctCOL_StockUnitPrice = "StockUnitPrice";
        /// <summary>�d����</summary>
        public const string ctCOL_SalesOrderUnit = "SalesOrderUnit";
        /// <summary>�d���㐔</summary>
        public const string ctCOL_AfSalesOrderUnit = "AfSalesOrderUnit";
        /// <summary>�I��</summary>
        public const string ctCOL_WarehouseShelfNo = "WarehouseShelfNo";
        /// <summary>�����c</summary>
        public const string ctCOL_SalesOrderCount = "SalesOrderCount";
        /// <summary>�݌ɐ�(�d���݌ɐ�)</summary>
        public const string ctCOL_SupplierStock = "SupplierStock";
        /// <summary>���ה��l</summary>
        public const string ctCOL_DtlNote = "DtlNote";
        // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<

		/// <summary>�����T�C�Y</summary>
		private const string ctCOL_FontSize = "FontSize";
		/// <summary>���ŊO�ŗ��\��</summary>
		private const string ctCOL_TaxDisplay = "TaxDisplay";
		#endregion

		#region �񏉊��l�e�[�u��
		/// <summary>
		/// ���ח�\���X�e�[�^�X�̏����l
		/// </summary>
		private AdjustStockDtlDisplayStatus[] CT_DEFAULTSTATUS = new AdjustStockDtlDisplayStatus[]
			{
                // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
                #region DEL 2008/07/24
                //new AdjustStockDtlDisplayStatus(ctCOL_RowNum,ctINDX_RowNum,50,true),
                //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                ////new AdjustStockDtlDisplayStatus(ctCOL_GoodsCode,ctINDX_GoodsCode, 180, true),	// ���i�R�[�h
                //new AdjustStockDtlDisplayStatus(ctCOL_GoodsNo,ctINDX_GoodsNo, 180, true),	// ���i�R�[�h
                //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                //new AdjustStockDtlDisplayStatus(ctCOL_GoodsGuide,ctINDX_GoodsGuide,30,true),    // ���i�K�C�h
                //new AdjustStockDtlDisplayStatus(ctCOL_GoodsName,ctINDX_GoodsName, 180, true),	// ���i����
                //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                //new AdjustStockDtlDisplayStatus(ctCOL_GoodsMakerCd, ctINDX_GoodsMakerCd, 120, true),    // ���[�J�[�R�[�h
                //new AdjustStockDtlDisplayStatus(ctCOL_MakerName, ctINDX_MakerName, 120, true),  // ���[�J�[����
                //new AdjustStockDtlDisplayStatus(ctCOL_CustomerName, ctINDX_CustomerName, 100, false),    // �d���於��
                //new AdjustStockDtlDisplayStatus(ctCOL_BLGoodsCode, ctINDX_BLGoodsCode, 100, true),  // �a�k���i�R�[�h
                //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                //new AdjustStockDtlDisplayStatus(ctCOL_WarehouseCode,ctINDX_WarehouseCode,100,true), //�q�ɃR�[�h
                //new AdjustStockDtlDisplayStatus(ctCOL_WarehouseName,ctINDX_WarehouseName,100,true), //�q�ɖ���
                //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                ////new AdjustStockDtlDisplayStatus(ctCOL_ProductNumber, ctINDX_ProductNumber, 160, true),	// �����ԍ�
                ////new AdjustStockDtlDisplayStatus(ctCOL_StockTelNo1, ctINDX_StockTelNo1, 120, true),	// �g�єԍ�
                ////new AdjustStockDtlDisplayStatus(ctCOL_BfProductNumber,ctINDX_BfProductNumber,120,false),    //�ύX�O����
                ////new AdjustStockDtlDisplayStatus(ctCOL_GoodsCodeStatus,ctINDX_GoodsCodeStatus,50,false) ,//���i���
                //new AdjustStockDtlDisplayStatus(ctCOL_WarehouseShelfNo, ctINDX_WarehouseShelfNo, 100, true),    // �I��
                //new AdjustStockDtlDisplayStatus(ctCOL_BfWarehouseShelfNo, ctINDX_BfWarehouseShelfNo, 100, true),    // �C���O�I��
                //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                //new AdjustStockDtlDisplayStatus(ctCOL_SupplierStock, ctINDX_SupplierStock, 80, true),	// �d���݌ɐ�
                //new AdjustStockDtlDisplayStatus(ctCOL_TrustCount, ctINDX_SupplierStock, 80, true),	// ����݌ɐ�
                //new AdjustStockDtlDisplayStatus(ctCOL_AdjustCount, ctINDX_AdjustCount, 80, true),	// ������
                //new AdjustStockDtlDisplayStatus(ctCOL_StockUnitPrice, ctINDX_StockUnitPrice, 80, true), // �d���P��
                //new AdjustStockDtlDisplayStatus(ctCOL_BfStockUnitPrice, ctINDX_BfStockUnitPrice, 80, true), // �C���O�d���P��                
                //new AdjustStockDtlDisplayStatus(ctCOL_AdjustPrice, ctINDX_AdjustPrice, 80, true),   // �������z
                //// 2008.01.17 �ǉ� >>>>>>>>>>>>>>>>>>>>
                //new AdjustStockDtlDisplayStatus(ctCOL_DtlNote, ctINDX_DtlNote, 280, true),  // ���ה��l
                //// 2008.01.17 �ǉ� <<<<<<<<<<<<<<<<<<<<
                //// 2008.02.15 �ǉ� >>>>>>>>>>>>>>>>>>>>
                //new AdjustStockDtlDisplayStatus(ctCOL_ListPriceFl, ctINDX_ListPriceFl, 80, false),  // �艿�i�����j
                //// 2008.02.15 �ǉ� <<<<<<<<<<<<<<<<<<<<
                #endregion DEL 2008/07/24

                new AdjustStockDtlDisplayStatus(ctCOL_RowNum,ctINDX_RowNum,50,true),                            // No
				new AdjustStockDtlDisplayStatus(ctCOL_GoodsNo,ctINDX_GoodsNo, 180, true),	                    // �i��
				new AdjustStockDtlDisplayStatus(ctCOL_GoodsName,ctINDX_GoodsName, 180, true),	                // �i��
                new AdjustStockDtlDisplayStatus(ctCOL_BLGoodsCode, ctINDX_BLGoodsCode, 100, true),              // �a�k�R�[�h
                new AdjustStockDtlDisplayStatus(ctCOL_GoodsMakerCd, ctINDX_GoodsMakerCd, 100, true),            // ���[�J�[
                new AdjustStockDtlDisplayStatus(ctCOL_SupplierCd, ctINDX_SupplierCd, 100, true),                // �d����
                new AdjustStockDtlDisplayStatus(ctCOL_ListPriceFl, ctINDX_ListPriceFl, 135, true),               // �W�����i
				new AdjustStockDtlDisplayStatus(ctCOL_StockUnitPrice, ctINDX_StockUnitPrice, 130, true),         // ���P��
				new AdjustStockDtlDisplayStatus(ctCOL_SalesOrderUnit, ctINDX_SalesOrderUnit, 125, true),         // �d����
				new AdjustStockDtlDisplayStatus(ctCOL_AfSalesOrderUnit, ctINDX_AfSalesOrderUnit, 125, true),     // �d���㐔
                new AdjustStockDtlDisplayStatus(ctCOL_WarehouseShelfNo, ctINDX_WarehouseShelfNo, 100, true),    // �I��
                new AdjustStockDtlDisplayStatus(ctCOL_SalesOrderCount, ctINDX_SalesOrderCount, 100, true),      // �����c
				new AdjustStockDtlDisplayStatus(ctCOL_SupplierStock, ctINDX_SupplierStock, 100, true),	        // �݌ɐ�(�d���݌ɐ�)
				new AdjustStockDtlDisplayStatus(ctCOL_DtlNote, ctINDX_DtlNote, 280, true),                      // ���ה��l
                // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
			};
        /// <summary>
        /// ���ח�\���X�e�[�^�X�̕ύX�l
        /// </summary>
        private AdjustStockDtlDisplayStatus[] CT_CHANGESTATUS = new AdjustStockDtlDisplayStatus[]
			{
                // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
                #region DEL 2008/07/24
                //new AdjustStockDtlDisplayStatus(ctCOL_RowNum,ctINDX_RowNum,50,true),
                //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                ////new AdjustStockDtlDisplayStatus(ctCOL_GoodsCode,ctINDX_GoodsCode, 180, true),	// ���i�R�[�h
                //new AdjustStockDtlDisplayStatus(ctCOL_GoodsNo,ctINDX_GoodsNo, 180, true),	// ���i�R�[�h
                //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                //new AdjustStockDtlDisplayStatus(ctCOL_GoodsGuide,ctINDX_GoodsGuide,30,true),    // ���i�K�C�h
                //new AdjustStockDtlDisplayStatus(ctCOL_GoodsName,ctINDX_GoodsName, 180, true),	// ���i����
                //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                //new AdjustStockDtlDisplayStatus(ctCOL_GoodsMakerCd, ctINDX_GoodsMakerCd, 120, true),    // ���[�J�[�R�[�h
                //new AdjustStockDtlDisplayStatus(ctCOL_MakerName, ctINDX_MakerName, 120, true),  // ���[�J�[����
                //new AdjustStockDtlDisplayStatus(ctCOL_CustomerName, ctINDX_CustomerName, 100, false),    // �d���於��
                //new AdjustStockDtlDisplayStatus(ctCOL_BLGoodsCode, ctINDX_BLGoodsCode, 100, true),  // �a�k���i�R�[�h
                //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                //new AdjustStockDtlDisplayStatus(ctCOL_WarehouseCode,ctINDX_WarehouseCode,100,true), //�q�ɃR�[�h
                //new AdjustStockDtlDisplayStatus(ctCOL_WarehouseName,ctINDX_WarehouseName,100,true), //�q�ɖ���
                //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                ////new AdjustStockDtlDisplayStatus(ctCOL_ProductNumber, ctINDX_ProductNumber, 160, true),	// �����ԍ�
                ////new AdjustStockDtlDisplayStatus(ctCOL_StockTelNo1, ctINDX_StockTelNo1, 120, false),	// �g�єԍ�
                ////new AdjustStockDtlDisplayStatus(ctCOL_BfProductNumber,ctINDX_BfProductNumber,120,true), //�ύX�O����
                ////new AdjustStockDtlDisplayStatus(ctCOL_GoodsCodeStatus,ctINDX_GoodsCodeStatus,50,false),//���i���
                //new AdjustStockDtlDisplayStatus(ctCOL_WarehouseShelfNo, ctINDX_WarehouseShelfNo, 80, true),    // �I��
                //new AdjustStockDtlDisplayStatus(ctCOL_BfWarehouseShelfNo, ctINDX_BfWarehouseShelfNo, 80, true),    // �C���O�I��
                //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                //new AdjustStockDtlDisplayStatus(ctCOL_SupplierStock, ctINDX_SupplierStock, 80, true),	// �d���݌ɐ�
                //new AdjustStockDtlDisplayStatus(ctCOL_TrustCount, ctINDX_SupplierStock, 80, true),	// ����݌ɐ�
                //new AdjustStockDtlDisplayStatus(ctCOL_AdjustCount, ctINDX_AdjustCount, 80, true),	// ������
                //new AdjustStockDtlDisplayStatus(ctCOL_StockUnitPrice, ctINDX_StockUnitPrice, 80, true), // �d���P��
                //new AdjustStockDtlDisplayStatus(ctCOL_BfStockUnitPrice, ctINDX_BfStockUnitPrice, 80, true), // �d���P��
                //new AdjustStockDtlDisplayStatus(ctCOL_AdjustPrice, ctINDX_AdjustPrice, 80, true),   // �������z
                //// 2008.01.17 �ǉ� >>>>>>>>>>>>>>>>>>>>
                //new AdjustStockDtlDisplayStatus(ctCOL_DtlNote, ctINDX_DtlNote, 280, true),  // ���ה��l
                //// 2008.01.17 �ǉ� <<<<<<<<<<<<<<<<<<<<
                //// 2008.02.15 �ǉ� >>>>>>>>>>>>>>>>>>>>
                //new AdjustStockDtlDisplayStatus(ctCOL_ListPriceFl, ctINDX_ListPriceFl, 80, false),  // �艿�i�����j
                //// 2008.02.15 �ǉ� <<<<<<<<<<<<<<<<<<<<
                #endregion DEL 2008/07/24

                new AdjustStockDtlDisplayStatus(ctCOL_RowNum,ctINDX_RowNum,50,true),                            // No
				new AdjustStockDtlDisplayStatus(ctCOL_GoodsNo,ctINDX_GoodsNo, 180, true),	                    // �i��
				new AdjustStockDtlDisplayStatus(ctCOL_GoodsName,ctINDX_GoodsName, 180, true),	                // �i��
                new AdjustStockDtlDisplayStatus(ctCOL_BLGoodsCode, ctINDX_BLGoodsCode, 100, true),              // �a�k�R�[�h
                new AdjustStockDtlDisplayStatus(ctCOL_GoodsMakerCd, ctINDX_GoodsMakerCd, 100, true),            // ���[�J�[
                new AdjustStockDtlDisplayStatus(ctCOL_SupplierCd, ctINDX_SupplierCd, 100, true),                // �d����
                new AdjustStockDtlDisplayStatus(ctCOL_ListPriceFl, ctINDX_ListPriceFl, 135, true),               // �W�����i
				new AdjustStockDtlDisplayStatus(ctCOL_StockUnitPrice, ctINDX_StockUnitPrice, 130, true),         // ���P��
				new AdjustStockDtlDisplayStatus(ctCOL_SalesOrderUnit, ctINDX_SalesOrderUnit, 125, true),         // �d����
				new AdjustStockDtlDisplayStatus(ctCOL_AfSalesOrderUnit, ctINDX_AfSalesOrderUnit, 125, true),     // �d���㐔
                new AdjustStockDtlDisplayStatus(ctCOL_WarehouseShelfNo, ctINDX_WarehouseShelfNo, 100, true),     // �I��
                new AdjustStockDtlDisplayStatus(ctCOL_SalesOrderCount, ctINDX_SalesOrderCount, 100, true),       // �����c
				new AdjustStockDtlDisplayStatus(ctCOL_SupplierStock, ctINDX_SupplierStock, 100, true),	        // �݌ɐ�(�d���݌ɐ�)
				new AdjustStockDtlDisplayStatus(ctCOL_DtlNote, ctINDX_DtlNote, 280, true),                      // ���ה��l
                // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
			};

		#endregion
		#endregion

		//====================================================================================================
		//  �v���C�x�[�g�ϐ��錾
		//====================================================================================================
		#region �v���C�x�[�g�ϐ�
		/// <summary>
		/// �d�����ח�X�e�[�^�X
		/// </summary>
		private ArrayList mDetailStatus;
		/// <summary>
		/// �t�H���g�T�C�Y
		/// </summary>
		private int _fontSize = 11;
		/// <summary>
		/// ���ŊO�ŗ��\��
		/// </summary>
		private bool _dispBothTaxway = false;
		#endregion

		//====================================================================================================
		//  �R���X�g���N�^
		//====================================================================================================
		#region �R���X�g���N�^
		/// <summary>
		/// �d�����ח�\���󋵃N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �d�����ח�\���󋵃N���X�̃C���X�^���X���쐬���A���������܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public PtAdjustStockDtlDisplayStatus()
		{
			mDetailStatus = new ArrayList();

            // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
            #region DEL 2008/07/24
            //InitializeStatus(ctCOL_RowNum);
            //// ���i�R�[�h
            //InitializeStatus(ctCOL_GoodsName);
            //// ���i����
            //InitializeStatus(ctCOL_GoodsName);
            //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //// ���[�J�[�R�[�h
            //InitializeStatus(ctCOL_GoodsMakerCd);
            //// ���[�J�[����
            //InitializeStatus(ctCOL_MakerName);
            //// �d���於��
            //InitializeStatus(ctCOL_CustomerName);
            //// �a�k���i�R�[�h
            //InitializeStatus(ctCOL_BLGoodsCode);
            //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            //// �q�ɃR�[�h
            //InitializeStatus(ctCOL_WarehouseCode);
            //// �q�ɖ���
            //InitializeStatus(ctCOL_WarehouseName);
            //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            ////// �����ԍ�
            ////InitializeStatus(ctCOL_ProductNumber);
            ////// �g�єԍ�
            ////InitializeStatus(ctCOL_StockTelNo1);
            ////// �C���O����
            ////InitializeStatus(ctCOL_BfProductNumber);
            ////// ���i���
            ////InitializeStatus(ctCOL_GoodsCodeStatus);
            //// �I��
            //InitializeStatus(ctCOL_WarehouseShelfNo);
            //// �C���O�I��
            //InitializeStatus(ctCOL_BfWarehouseShelfNo);
            //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            //// �d���݌ɐ�
            //InitializeStatus(ctCOL_SupplierStock);
            //// ����݌ɐ�
            //InitializeStatus(ctCOL_TrustCount);
            //// ������
            //InitializeStatus(ctCOL_AdjustCount);
            //// �d���P��
            //InitializeStatus(ctCOL_StockUnitPrice);
            //// �C���O�d���P��
            //InitializeStatus(ctCOL_BfStockUnitPrice);
            //// �������z
            //InitializeStatus(ctCOL_AdjustPrice);
            //// 2008.01.17 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //// ���ה��l
            //InitializeStatus(ctCOL_DtlNote);
            //// 2008.01.17 �ǉ� <<<<<<<<<<<<<<<<<<<<
            //// 2008.02.15 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //// �艿�i�����j
            //InitializeStatus(ctCOL_ListPriceFl);
            //// 2008.02.15 �ǉ� <<<<<<<<<<<<<<<<<<<<
            #endregion DEL 2008/07/24

            // No
            InitializeStatus(ctCOL_RowNum);
            // �i��
            InitializeStatus(ctCOL_GoodsName);
            // �i��
            InitializeStatus(ctCOL_GoodsName);
            // �a�k���i�R�[�h
            InitializeStatus(ctCOL_BLGoodsCode);
            // ���[�J�[�R�[�h
            InitializeStatus(ctCOL_GoodsMakerCd);
            // �d����
            InitializeStatus(ctCOL_SupplierCd);
            // �W�����i
            InitializeStatus(ctCOL_ListPriceFl);
            // ���P��
            InitializeStatus(ctCOL_StockUnitPrice);
            // �d����
            InitializeStatus(ctCOL_SalesOrderUnit);
            // �d���㐔
            InitializeStatus(ctCOL_AfSalesOrderUnit);
            // �I��
            InitializeStatus(ctCOL_WarehouseShelfNo);
            // �����c
            InitializeStatus(ctCOL_SalesOrderCount);
            // �݌ɐ�(�d���݌ɐ�)
            InitializeStatus(ctCOL_SupplierStock);
            // ���ה��l
            InitializeStatus(ctCOL_DtlNote);
            
            // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
        }
		#endregion

		//====================================================================================================
		//  �p�u���b�N�v���p�e�B
		//====================================================================================================
		#region �p�u���b�N�v���p�e�B
		#region [�\���ʒu]�v���p�e�B
        // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
        #region DEL 2008/07/24
        ///// <summary>
        ///// [�\���ʒu]�s�ԍ�
        ///// </summary>
        //public int Order_RowNum
        //{
        //    get { return GetVisiblePosition(ctCOL_RowNum); }
        //    set { SetVisiblePosition(ctCOL_RowNum, value); }
        //}
        ///// <summary>
        ///// [�\���ʒu]���i�R�[�h
        ///// </summary>
        //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        ////public int Order_GoodsCode
        ////{
        ////	get { return GetVisiblePosition(ctCOL_GoodsCode); }
        ////	set { SetVisiblePosition(ctCOL_GoodsCode, value); }
        ////}
        //public int Order_GoodsNo
        //{
        //    get { return GetVisiblePosition(ctCOL_GoodsNo); }
        //    set { SetVisiblePosition(ctCOL_GoodsNo, value); }
        //}
        //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        ///// <summary>
        ///// [�\���ʒu]���i�K�C�h
        ///// </summary>
        //public int Order_GoodsGuide
        //{
        //    get { return GetVisiblePosition(ctCOL_GoodsGuide); }
        //    set { SetVisiblePosition(ctCOL_GoodsGuide, value); }
        //}
        ///// <summary>
        ///// [�\���ʒu]���i����
        ///// </summary>
        //public int Order_GoodsName
        //{
        //    get { return GetVisiblePosition(ctCOL_GoodsName); }
        //    set { SetVisiblePosition(ctCOL_GoodsName, value); }
        //}
        //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// [�\���ʒu]���[�J�[�R�[�h
        ///// </summary>
        //public int Order_GoodsMakerCd
        //{
        //    get { return GetVisiblePosition(ctCOL_GoodsMakerCd); }
        //    set { SetVisiblePosition(ctCOL_GoodsMakerCd, value); }
        //}
        ///// <summary>
        ///// [�\���ʒu]���[�J�[����
        ///// </summary>
        //public int Order_MakerName
        //{
        //    get { return GetVisiblePosition(ctCOL_MakerName); }
        //    set { SetVisiblePosition(ctCOL_MakerName, value); }
        //}
        ///// <summary>
        ///// [�\���ʒu]�d���於��
        ///// </summary>
        //public int Order_CustomerName
        //{
        //    get { return GetVisiblePosition(ctCOL_CustomerName); }
        //    set { SetVisiblePosition(ctCOL_CustomerName, value); }
        //}
        ///// <summary>
        ///// [�\���ʒu]�a�k���i�R�[�h
        ///// </summary>
        //public int Order_BLGoodsCode
        //{
        //    get { return GetVisiblePosition(ctCOL_BLGoodsCode); }
        //    set { SetVisiblePosition(ctCOL_BLGoodsCode, value); }
        //}
        //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        ///// <summary>
        ///// [�\���ʒu]�q�ɃR�[�h
        ///// </summary>
        //public int Order_WarehouseCode
        //{
        //    get { return GetVisiblePosition(ctCOL_WarehouseCode); }
        //    set { SetVisiblePosition(ctCOL_WarehouseCode, value); }
        //}
        ///// <summary>
        ///// [�\���ʒu]�q�ɖ���
        ///// </summary>
        //public int Order_WarehouseName
        //{
        //    get { return GetVisiblePosition(ctCOL_WarehouseName); }
        //    set { SetVisiblePosition(ctCOL_WarehouseName, value); }
        //}
        //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        /////// <summary>
        /////// [�\���ʒu]�����ԍ�
        /////// </summary>
        ////public int Order_ProductNumber
        ////{
        ////	get { return GetVisiblePosition(ctCOL_ProductNumber); }
        ////	set { SetVisiblePosition(ctCOL_ProductNumber, value); }
        ////}
        /////// <summary>
        /////// [�\���ʒu]�g�єԍ�
        /////// </summary>
        ////public int Order_StockTelNo1
        ////{
        ////	get { return GetVisiblePosition(ctCOL_StockTelNo1); }
        ////	set { SetVisiblePosition(ctCOL_StockTelNo1, value); }
        ////}
        /////// <summary>
        /////// [�\���ʒu]�C���O����
        ////public int Order_BfProductNumber
        ////{
        ////    get { return GetVisiblePosition(ctCOL_BfProductNumber); }
        ////    set { SetVisiblePosition(ctCOL_BfProductNumber, value); }
        ////}
        /////// <summary>
        /////// [�\���ʒu]���i���
        /////// </summary>
        ////public int Order_GoodsCodeStatus
        ////{
        ////    get { return GetVisiblePosition(ctCOL_GoodsCodeStatus); }
        ////    set { SetVisiblePosition(ctCOL_GoodsCodeStatus, value); }
        ////}
        ///// <summary>
        ///// [�\���ʒu]�I��
        ///// </summary>
        //public int Order_WarehouseShelfNo
        //{
        //    get { return GetVisiblePosition(ctCOL_WarehouseShelfNo); }
        //    set { SetVisiblePosition(ctCOL_WarehouseShelfNo, value); }
        //}
        ///// <summary>
        ///// [�\���ʒu]�C���O�I��
        ///// </summary>
        //public int Order_BfWarehouseShelfNo
        //{
        //    get { return GetVisiblePosition(ctCOL_BfWarehouseShelfNo); }
        //    set { SetVisiblePosition(ctCOL_BfWarehouseShelfNo, value); }
        //}
        //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        ///// <summary>
        ///// [�\���ʒu]�d���݌ɐ�
        ///// </summary>
        //public int Order_SupplierStock
        //{
        //    get { return GetVisiblePosition(ctCOL_SupplierStock); }
        //    set { SetVisiblePosition(ctCOL_SupplierStock, value); }
        //}
        ///// <summary>
        ///// [�\���ʒu]����݌ɐ�
        ///// </summary>
        //public int Order_TrustCount
        //{
        //    get { return GetVisiblePosition(ctCOL_TrustCount); }
        //    set { SetVisiblePosition(ctCOL_TrustCount, value); }
        //}
        ///// <summary>
        ///// [�\���ʒu]������
        ///// </summary>
        //public int Order_AdjustCount
        //{
        //    get { return GetVisiblePosition(ctCOL_AdjustCount); }
        //    set { SetVisiblePosition(ctCOL_AdjustCount, value); }
        //}
        ///// <summary>
        ///// [�\���ʒu]�d���P��
        ///// </summary>
        //public int Order_StockUnitPrice
        //{
        //    get { return GetVisiblePosition(ctCOL_StockUnitPrice); }
        //    set { SetVisiblePosition(ctCOL_StockUnitPrice, value); }
        //}
        ///// <summary>
        ///// [�\���ʒu]�C���O�d���P��
        ///// </summary>
        //public int Order_BfStockUnitPrice
        //{
        //    get { return GetVisiblePosition(ctCOL_BfStockUnitPrice); }
        //    set { SetVisiblePosition(ctCOL_BfStockUnitPrice, value); }
        //}
        ///// <summary>
        ///// [�\���ʒu]�������z
        ///// </summary>
        //public int Order_AdjustPrice
        //{
        //    get { return GetVisiblePosition(ctCOL_AdjustPrice); }
        //    set { SetVisiblePosition(ctCOL_AdjustPrice, value); }
        //}
        //// 2008.01.17 �ǉ� >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// [�\���ʒu]���ה��l
        ///// </summary>
        //public int Order_DtlNote
        //{
        //    get { return GetVisiblePosition(ctCOL_DtlNote); }
        //    set { SetVisiblePosition(ctCOL_DtlNote, value); }
        //}
        //// 2008.01.17 �ǉ� <<<<<<<<<<<<<<<<<<<<
        //// 2008.02.15 �ǉ� >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// [�\���ʒu]�艿�i�����j
        ///// </summary>
        //public int Order_ListPriceFl
        //{
        //    get { return GetVisiblePosition(ctCOL_ListPriceFl); }
        //    set { SetVisiblePosition(ctCOL_ListPriceFl, value); }
        //}
        //// 2008.02.15 �ǉ� <<<<<<<<<<<<<<<<<<<<
        #endregion DEL 2008/07/24

        /// <summary>
        /// [�\���ʒu]No
        /// </summary>
        public int Order_RowNum
        {
            get { return GetVisiblePosition(ctCOL_RowNum); }
            set { SetVisiblePosition(ctCOL_RowNum, value); }
        }
        /// <summary>
        /// [�\���ʒu]�i��
        /// </summary>
        public int Order_GoodsNo
        {
            get { return GetVisiblePosition(ctCOL_GoodsNo); }
            set { SetVisiblePosition(ctCOL_GoodsNo, value); }
        }
        /// <summary>
        /// [�\���ʒu]�i��
        /// </summary>
        public int Order_GoodsName
        {
            get { return GetVisiblePosition(ctCOL_GoodsName); }
            set { SetVisiblePosition(ctCOL_GoodsName, value); }
        }
        /// <summary>
        /// [�\���ʒu]�a�k�R�[�h
        /// </summary>
        public int Order_BLGoodsCode
        {
            get { return GetVisiblePosition(ctCOL_BLGoodsCode); }
            set { SetVisiblePosition(ctCOL_BLGoodsCode, value); }
        }
        /// <summary>
        /// [�\���ʒu]���[�J�[
        /// </summary>
        public int Order_GoodsMakerCd
        {
            get { return GetVisiblePosition(ctCOL_GoodsMakerCd); }
            set { SetVisiblePosition(ctCOL_GoodsMakerCd, value); }
        }
        /// <summary>
        /// [�\���ʒu]�d����
        /// </summary>
        public int Order_SupplierCd
        {
            get { return GetVisiblePosition(ctCOL_SupplierCd); }
            set { SetVisiblePosition(ctCOL_SupplierCd, value); }
        }
        /// <summary>
        /// [�\���ʒu]�W�����i
        /// </summary>
        public int Order_ListPriceFl
        {
            get { return GetVisiblePosition(ctCOL_ListPriceFl); }
            set { SetVisiblePosition(ctCOL_ListPriceFl, value); }
        }
        /// <summary>
        /// [�\���ʒu]���P��
        /// </summary>
        public int Order_StockUnitPrice
        {
            get { return GetVisiblePosition(ctCOL_StockUnitPrice); }
            set { SetVisiblePosition(ctCOL_StockUnitPrice, value); }
        }
        /// <summary>
        /// [�\���ʒu]�d����
        /// </summary>
        public int Order_SalesOrderUnit
        {
            get { return GetVisiblePosition(ctCOL_SalesOrderUnit); }
            set { SetVisiblePosition(ctCOL_SalesOrderUnit, value); }
        }
        /// <summary>
        /// [�\���ʒu]�d���㐔
        /// </summary>
        public int Order_AfSalesOrderUnit
        {
            get { return GetVisiblePosition(ctCOL_AfSalesOrderUnit); }
            set { SetVisiblePosition(ctCOL_AfSalesOrderUnit, value); }
        }
        /// <summary>
        /// [�\���ʒu]�I��
        /// </summary>
        public int Order_WarehouseShelfNo
        {
            get { return GetVisiblePosition(ctCOL_WarehouseShelfNo); }
            set { SetVisiblePosition(ctCOL_WarehouseShelfNo, value); }
        }
        /// <summary>
        /// [�\���ʒu]�����c
        /// </summary>
        public int Order_SalesOrderCount
        {
            get { return GetVisiblePosition(ctCOL_SalesOrderCount); }
            set { SetVisiblePosition(ctCOL_SalesOrderCount, value); }
        }
        /// <summary>
        /// [�\���ʒu]�݌ɐ�(�d���݌ɐ�)
        /// </summary>
        public int Order_SupplierStock
        {
            get { return GetVisiblePosition(ctCOL_SupplierStock); }
            set { SetVisiblePosition(ctCOL_SupplierStock, value); }
        }
        /// <summary>
        /// [�\���ʒu]���ה��l
        /// </summary>
        public int Order_DtlNote
        {
            get { return GetVisiblePosition(ctCOL_DtlNote); }
            set { SetVisiblePosition(ctCOL_DtlNote, value); }
        }
        // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
        #endregion

		#region [�\��]�v���p�e�B
        // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
        #region DEL 2008/07/24
        ///// <summary>
        ///// [�\��]�s�ԍ�
        ///// </summary>
        //public bool Visible_RowNum
        //{
        //    get { return GetVisible(ctCOL_RowNum); }
        //    set { SetVisible(ctCOL_RowNum, value); }
        //}
        ///// <summary>
        ///// [�\��]���i�R�[�h
        ///// </summary>
        //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        ////public bool Visible_GoodsCode
        ////{
        ////	get { return GetVisible(ctCOL_GoodsCode); }
        ////	set { SetVisible(ctCOL_GoodsCode, value); }
        ////}
        //public bool Visible_GoodsNo
        //{
        //    get { return GetVisible(ctCOL_GoodsNo); }
        //    set { SetVisible(ctCOL_GoodsNo, value); }
        //}
        //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        ///// <summary>
        ///// [�\��]���i�K�C�h
        ///// </summary>
        //public bool Visible_GoodsGuide
        //{
        //    get { return GetVisible(ctCOL_GoodsGuide); }
        //    set { SetVisible(ctCOL_GoodsGuide, value); }
        //}
        ///// <summary>
        ///// [�\��]���i����
        ///// </summary>
        //public bool Visible_GoodsName
        //{
        //    get { return GetVisible(ctCOL_GoodsName); }
        //    set { SetVisible(ctCOL_GoodsName, value); }
        //}
        //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// [�\��]���[�J�[�R�[�h
        ///// </summary>
        //public bool Visible_GoodsMakerCd
        //{
        //    get { return GetVisible(ctCOL_GoodsMakerCd); }
        //    set { SetVisible(ctCOL_GoodsMakerCd, value); }
        //}
        ///// <summary>
        ///// [�\��]���[�J�[����
        ///// </summary>
        //public bool Visible_MakerName
        //{
        //    get { return GetVisible(ctCOL_MakerName); }
        //    set { SetVisible(ctCOL_MakerName, value); }
        //}
        ///// <summary>
        ///// [�\��]�d���於��
        ///// </summary>
        //public bool Visible_CustomerName
        //{
        //    get { return GetVisible(ctCOL_CustomerName); }
        //    set { SetVisible(ctCOL_CustomerName, value); }
        //}
        ///// <summary>
        ///// [�\��]�a�k���i�R�[�h
        ///// </summary>
        //public bool Visible_BLGoodsCode
        //{
        //    get { return GetVisible(ctCOL_BLGoodsCode); }
        //    set { SetVisible(ctCOL_BLGoodsCode, value); }
        //}
        //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        ///// <summary>
        ///// [�\��]�q�ɃR�[�h
        ///// </summary>
        //public bool Visible_WarehouseCode
        //{
        //    get { return GetVisible(ctCOL_WarehouseCode); }
        //    set { SetVisible(ctCOL_WarehouseCode, value); }
        //}
        ///// <summary>
        ///// [�\��]�q�ɖ���
        ///// </summary>
        //public bool Visible_WarehouseName
        //{
        //    get { return GetVisible(ctCOL_WarehouseName); }
        //    set { SetVisible(ctCOL_WarehouseName, value); }
        //}
        //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        /////// <summary>
        /////// [�\��]�����ԍ�
        /////// </summary>
        ////public bool Visible_ProductNumber
        ////{
        ////	get { return GetVisible(ctCOL_ProductNumber); }
        ////	set { SetVisible(ctCOL_ProductNumber, value); }
        ////}
        /////// <summary>
        /////// [�\��]�g�єԍ�
        /////// </summary>
        ////public bool Visible_StockTelNo1
        ////{
        ////	get { return GetVisible(ctCOL_StockTelNo1); }
        ////	set { SetVisible(ctCOL_StockTelNo1, value); }
        ////}
        /////// <summary>
        /////// [�\��]�C���O����
        /////// </summary>
        ////public bool Visible_BfProductNumber
        ////{
        ////    get { return GetVisible(ctCOL_BfProductNumber); }
        ////    set { SetVisible(ctCOL_BfProductNumber, value); }
        ////}
        /////// <summary>
        /////// [�\��]���i���
        /////// </summary>
        ////public bool Visible_GoodsCodeStatus
        ////{
        ////    get { return GetVisible(ctCOL_GoodsCodeStatus); }
        ////    set { SetVisible(ctCOL_GoodsCodeStatus, value); }
        ////}
        ///// <summary>
        ///// [�\��]�I��
        ///// </summary>
        //public bool Visible_WarehouseShelfNo
        //{
        //    get { return GetVisible(ctCOL_WarehouseShelfNo); }
        //    set { SetVisible(ctCOL_WarehouseShelfNo, value); }
        //}
        ///// <summary>
        ///// [�\��]�C���O�I��
        ///// </summary>
        //public bool Visible_BfWarehouseShelfNo
        //{
        //    get { return GetVisible(ctCOL_BfWarehouseShelfNo); }
        //    set { SetVisible(ctCOL_BfWarehouseShelfNo, value); }
        //}
        //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        ///// <summary>
        ///// [�\��]�d���݌ɐ�
        ///// </summary>
        //public bool Visible_SupplierStock
        //{
        //    get { return GetVisible(ctCOL_SupplierStock); }
        //    set { SetVisible(ctCOL_SupplierStock, value); }
        //}
        ///// <summary>
        ///// [�\��]����݌ɐ�
        ///// </summary>
        //public bool Visible_TrustCount
        //{
        //    get { return GetVisible(ctCOL_TrustCount); }
        //    set { SetVisible(ctCOL_TrustCount, value); }
        //}
        ///// <summary>
        ///// [�\��]������
        ///// </summary>
        //public bool Visible_AdjustCount
        //{
        //    get { return GetVisible(ctCOL_AdjustCount); }
        //    set { SetVisible(ctCOL_AdjustCount, value); }
        //}
        ///// <summary>
        ///// [�\��]�d���P��
        ///// </summary>
        //public bool Visible_StockUnitPrice
        //{
        //    get { return GetVisible(ctCOL_StockUnitPrice); }
        //    set { SetVisible(ctCOL_StockUnitPrice, value); }
        //}
        ///// <summary>
        ///// [�\��]�C���O�d���P��
        ///// </summary>
        //public bool Visible_BfStockUnitPrice
        //{
        //    get { return GetVisible(ctCOL_BfStockUnitPrice); }
        //    set { SetVisible(ctCOL_BfStockUnitPrice, value); }
        //}
        ///// <summary>
        ///// [�\��]�������z
        ///// </summary>
        //public bool Visible_AdjustPrice
        //{
        //    get { return GetVisible(ctCOL_AdjustPrice); }
        //    set { SetVisible(ctCOL_AdjustPrice, value); }
        //}
        //// 2008.01.17 �ǉ� >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// [�\��]���ה��l
        ///// </summary>
        //public bool Visible_DtlNote
        //{
        //    get { return GetVisible(ctCOL_DtlNote); }
        //    set { SetVisible(ctCOL_DtlNote, value); }
        //}
        //// 2008.01.17 �ǉ� <<<<<<<<<<<<<<<<<<<<
        //// 2008.02.15 �ǉ� >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// [�\��]�艿�i�����j
        ///// </summary>
        //public bool Visible_ListPriceFl
        //{
        //    get { return GetVisible(ctCOL_ListPriceFl); }
        //    set { SetVisible(ctCOL_ListPriceFl, value); }
        //}
        //// 2008.02.15 �ǉ� <<<<<<<<<<<<<<<<<<<<
        #endregion DEL 2008/07/24

        /// <summary>
        /// [�\��]No
        /// </summary>
        public bool Visible_RowNum
        {
            get { return GetVisible(ctCOL_RowNum); }
            set { SetVisible(ctCOL_RowNum, value); }
        }
        /// <summary>
        /// [�\��]�i��
        /// </summary>
        public bool Visible_GoodsNo
        {
            get { return GetVisible(ctCOL_GoodsNo); }
            set { SetVisible(ctCOL_GoodsNo, value); }
        }
        /// <summary>
        /// [�\��]�i��
        /// </summary>
        public bool Visible_GoodsName
        {
            get { return GetVisible(ctCOL_GoodsName); }
            set { SetVisible(ctCOL_GoodsName, value); }
        }
        /// <summary>
        /// [�\��]�a�k�R�[�h
        /// </summary>
        public bool Visible_BLGoodsCode
        {
            get { return GetVisible(ctCOL_BLGoodsCode); }
            set { SetVisible(ctCOL_BLGoodsCode, value); }
        }
        /// <summary>
        /// [�\��]���[�J�[
        /// </summary>
        public bool Visible_GoodsMakerCd
        {
            get { return GetVisible(ctCOL_GoodsMakerCd); }
            set { SetVisible(ctCOL_GoodsMakerCd, value); }
        }
        /// <summary>
        /// [�\��]�d����
        /// </summary>
        public bool Visible_SupplierCd
        {
            get { return GetVisible(ctCOL_SupplierCd); }
            set { SetVisible(ctCOL_SupplierCd, value); }
        }
        /// <summary>
        /// [�\��]�W�����i
        /// </summary>
        public bool Visible_ListPriceFl
        {
            get { return GetVisible(ctCOL_ListPriceFl); }
            set { SetVisible(ctCOL_ListPriceFl, value); }
        }
        /// <summary>
        /// [�\��]���P��
        /// </summary>
        public bool Visible_StockUnitPrice
        {
            get { return GetVisible(ctCOL_StockUnitPrice); }
            set { SetVisible(ctCOL_StockUnitPrice, value); }
        }
        /// <summary>
        /// [�\��]�d����
        /// </summary>
        public bool Visible_SalesOrderUnit
        {
            get { return GetVisible(ctCOL_SalesOrderUnit); }
            set { SetVisible(ctCOL_SalesOrderUnit, value); }
        }
        /// <summary>
        /// [�\��]�d���㐔
        /// </summary>
        public bool Visible_AfSalesOrderUnit
        {
            get { return GetVisible(ctCOL_AfSalesOrderUnit); }
            set { SetVisible(ctCOL_AfSalesOrderUnit, value); }
        }
        /// <summary>
        /// [�\��]�I��
        /// </summary>
        public bool Visible_WarehouseShelfNo
        {
            get { return GetVisible(ctCOL_WarehouseShelfNo); }
            set { SetVisible(ctCOL_WarehouseShelfNo, value); }
        }
        /// <summary>
        /// [�\��]�����c
        /// </summary>
        public bool Visible_SalesOrderCount
        {
            get { return GetVisible(ctCOL_SalesOrderCount); }
            set { SetVisible(ctCOL_SalesOrderCount, value); }
        }
        /// <summary>
        /// [�\��]�݌ɐ�(�d���݌ɐ�)
        /// </summary>
        public bool Visible_SupplierStock
        {
            get { return GetVisible(ctCOL_SupplierStock); }
            set { SetVisible(ctCOL_SupplierStock, value); }
        }
        /// <summary>
        /// [�\��]���ה��l
        /// </summary>
        public bool Visible_DtlNote
        {
            get { return GetVisible(ctCOL_DtlNote); }
            set { SetVisible(ctCOL_DtlNote, value); }
        }
        // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
        #endregion

		#region [��]�v���p�e�B
        // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
        #region DEL 2008/07/24
        ///// <summary>
        ///// [��]�s�ԍ�
        ///// </summary>
        //public int Width_RowNum
        //{
        //    get { return GetWidth(ctCOL_RowNum); }
        //    set { SetWidth(ctCOL_RowNum, value); }
        //}
        ///// <summary>
        ///// [��]���i�R�[�h
        ///// </summary>
        //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        ////public int Width_GoodsCode
        ////{
        ////	get { return GetWidth(ctCOL_GoodsCode); }
        ////	set { SetWidth(ctCOL_GoodsCode, value); }
        ////}
        //public int Width_GoodsNo
        //{
        //    get { return GetWidth(ctCOL_GoodsNo); }
        //    set { SetWidth(ctCOL_GoodsNo, value); }
        //}
        //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        ///// <summary>
        ///// [��]���i�K�C�h
        ///// </summary>
        //public int Width_GoodsGuide
        //{
        //    get { return GetWidth(ctCOL_GoodsGuide); }
        //    set { SetWidth(ctCOL_GoodsGuide, value); }
        //}
        ///// <summary>
        ///// [��]���i����
        ///// </summary>
        //public int Width_GoodsName
        //{
        //    get { return GetWidth(ctCOL_GoodsName); }
        //    set { SetWidth(ctCOL_GoodsName, value); }
        //}
        //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// [��]���[�J�[�R�[�h
        ///// </summary>
        //public int Width_GoodsMakerCd
        //{
        //    get { return GetWidth(ctCOL_GoodsMakerCd); }
        //    set { SetWidth(ctCOL_GoodsMakerCd, value); }
        //}
        ///// <summary>
        ///// [��]���[�J�[����
        ///// </summary>
        //public int Width_MakerName
        //{
        //    get { return GetWidth(ctCOL_MakerName); }
        //    set { SetWidth(ctCOL_MakerName, value); }
        //}
        ///// <summary>
        ///// [��]�d���於��
        ///// </summary>
        //public int Width_CustomerName
        //{
        //    get { return GetWidth(ctCOL_CustomerName); }
        //    set { SetWidth(ctCOL_CustomerName, value); }
        //}
        ///// <summary>
        ///// [��]�a�k���i�R�[�h
        ///// </summary>
        //public int Width_BLGoodsCode
        //{
        //    get { return GetWidth(ctCOL_BLGoodsCode); }
        //    set { SetWidth(ctCOL_BLGoodsCode, value); }
        //}
        //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        ///// <summary>
        ///// [��]�q�ɃR�[�h
        ///// </summary>
        //public int Width_WarehouseCode
        //{
        //    get { return GetWidth(ctCOL_WarehouseCode); }
        //    set { SetWidth(ctCOL_WarehouseCode, value); }
        //}
        ///// <summary>
        ///// [��]�q�ɖ���
        ///// </summary>
        //public int Width_WarehouseName
        //{
        //    get { return GetWidth(ctCOL_WarehouseName); }
        //    set { SetWidth(ctCOL_WarehouseName, value); }
        //}
        //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        /////// <summary>
        /////// [��]�����ԍ�
        /////// </summary>
        ////public int Width_ProductNumber
        ////{
        ////	get { return GetWidth(ctCOL_ProductNumber); }
        ////	set { SetWidth(ctCOL_ProductNumber, value); }
        ////}
        /////// <summary>
        /////// [��]�g�єԍ�
        /////// </summary>
        ////public int Width_StockTelNo1
        ////{
        ////	get { return GetWidth(ctCOL_StockTelNo1); }
        ////	set { SetWidth(ctCOL_StockTelNo1, value); }
        ////}
        /////// <summary>
        /////// [��]�C���O����
        /////// </summary>
        ////public int Width_BfProductNumber
        ////{
        ////    get { return GetWidth(ctCOL_BfProductNumber); }
        ////    set { SetWidth(ctCOL_BfProductNumber, value); }
        ////}
        /////// <summary>
        /////// [��]���i���
        /////// </summary>
        ////public int Width_GoodsCodeStatus
        ////{
        ////    get { return GetWidth(ctCOL_GoodsCodeStatus); }
        ////    set { SetWidth(ctCOL_GoodsCodeStatus, value); }
        ////}
        ///// <summary>
        ///// [��]�I��
        ///// </summary>
        //public int Width_WarehouseShelfNo
        //{
        //    get { return GetWidth(ctCOL_WarehouseShelfNo); }
        //    set { SetWidth(ctCOL_WarehouseShelfNo, value); }
        //}
        ///// <summary>
        ///// [��]�C���O�I��
        ///// </summary>
        //public int Width_BfWarehouseShelfNo
        //{
        //    get { return GetWidth(ctCOL_BfWarehouseShelfNo); }
        //    set { SetWidth(ctCOL_BfWarehouseShelfNo, value); }
        //}
        //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        ///// <summary>
        ///// [��]�d���݌ɐ�
        ///// </summary>
        //public int Width_SupplierStock
        //{
        //    get { return GetWidth(ctCOL_SupplierStock); }
        //    set { SetWidth(ctCOL_SupplierStock, value); }
        //}
        ///// <summary>
        ///// [��]����݌ɐ�
        ///// </summary>
        //public int Width_TrustCount
        //{
        //    get { return GetWidth(ctCOL_TrustCount); }
        //    set { SetWidth(ctCOL_TrustCount, value); }
        //}
        ///// <summary>
        ///// [��]������
        ///// </summary>
        //public int Width_AdjustCount
        //{
        //    get { return GetWidth(ctCOL_AdjustCount); }
        //    set { SetWidth(ctCOL_AdjustCount, value); }
        //}
        ///// <summary>
        ///// [��]�d���P��
        ///// </summary>
        //public int Width_StockUnitPrice
        //{
        //    get { return GetWidth(ctCOL_StockUnitPrice); }
        //    set { SetWidth(ctCOL_StockUnitPrice, value); }
        //}
        ///// <summary>
        ///// [��]�C���O�d���P��
        ///// </summary>
        //public int Width_BfStockUnitPrice
        //{
        //    get { return GetWidth(ctCOL_BfStockUnitPrice); }
        //    set { SetWidth(ctCOL_BfStockUnitPrice, value); }
        //}
        ///// <summary>
        ///// [��]�������z
        ///// </summary>
        //public int Width_AdjustPrice
        //{
        //    get { return GetWidth(ctCOL_AdjustPrice); }
        //    set { SetWidth(ctCOL_AdjustPrice, value); }
        //}
        ///// <summary>
        //// 2008.01.17 �ǉ� >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// [��]���ה��l
        ///// </summary>
        //public int Width_DtlNote
        //{
        //    get { return GetWidth(ctCOL_DtlNote); }
        //    set { SetWidth(ctCOL_DtlNote, value); }
        //}
        //// 2008.01.17 �ǉ� <<<<<<<<<<<<<<<<<<<<
        //// 2008.02.15 �ǉ� >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// [��]�艿�i�����j
        ///// </summary>
        //public int Width_ListPriceFl
        //{
        //    get { return GetWidth(ctCOL_ListPriceFl); }
        //    set { SetWidth(ctCOL_ListPriceFl, value); }
        //}
        //// 2008.02.15 �ǉ� <<<<<<<<<<<<<<<<<<<<
        #endregion DEL 2008/07/24

        /// <summary>
        /// [��]No
        /// </summary>
        public int Width_RowNum
        {
            get { return GetWidth(ctCOL_RowNum); }
            set { SetWidth(ctCOL_RowNum, value); }
        }
        /// <summary>
        /// [��]�i��
        /// </summary>
        public int Width_GoodsNo
        {
            get { return GetWidth(ctCOL_GoodsNo); }
            set { SetWidth(ctCOL_GoodsNo, value); }
        }
        /// <summary>
        /// [��]�i��
        /// </summary>
        public int Width_GoodsName
        {
            get { return GetWidth(ctCOL_GoodsName); }
            set { SetWidth(ctCOL_GoodsName, value); }
        }
        /// <summary>
        /// [��]�a�k�R�[�h
        /// </summary>
        public int Width_BLGoodsCode
        {
            get { return GetWidth(ctCOL_BLGoodsCode); }
            set { SetWidth(ctCOL_BLGoodsCode, value); }
        }
        /// <summary>
        /// [��]���[�J�[
        /// </summary>
        public int Width_GoodsMakerCd
        {
            get { return GetWidth(ctCOL_GoodsMakerCd); }
            set { SetWidth(ctCOL_GoodsMakerCd, value); }
        }
        /// <summary>
        /// [��]�d����
        /// </summary>
        public int Width_SupplierCd
        {
            get { return GetWidth(ctCOL_SupplierCd); }
            set { SetWidth(ctCOL_SupplierCd, value); }
        }
        /// <summary>
        /// [��]�W�����i
        /// </summary>
        public int Width_ListPriceFl
        {
            get { return GetWidth(ctCOL_ListPriceFl); }
            set { SetWidth(ctCOL_ListPriceFl, value); }
        }
        /// <summary>
        /// [��]���P��
        /// </summary>
        public int Width_StockUnitPrice
        {
            get { return GetWidth(ctCOL_StockUnitPrice); }
            set { SetWidth(ctCOL_StockUnitPrice, value); }
        }
        /// <summary>
        /// [��]�d����
        /// </summary>
        public int Width_SalesOrderUnit
        {
            get { return GetWidth(ctCOL_SalesOrderUnit); }
            set { SetWidth(ctCOL_SalesOrderUnit, value); }
        }
        /// <summary>
        /// [��]�d���㐔
        /// </summary>
        public int Width_AfSalesOrderUnit
        {
            get { return GetWidth(ctCOL_AfSalesOrderUnit); }
            set { SetWidth(ctCOL_AfSalesOrderUnit, value); }
        }
        /// <summary>
        /// [��]�I��
        /// </summary>
        public int Width_WarehouseShelfNo
        {
            get { return GetWidth(ctCOL_WarehouseShelfNo); }
            set { SetWidth(ctCOL_WarehouseShelfNo, value); }
        }
        /// <summary>
        /// [��]�����c
        /// </summary>
        public int Width_SalesOrderCount
        {
            get { return GetWidth(ctCOL_SalesOrderCount); }
            set { SetWidth(ctCOL_SalesOrderCount, value); }
        }
        /// <summary>
        /// [��]�݌ɐ�(�d���݌ɐ�)
        /// </summary>
        public int Width_SupplierStock
        {
            get { return GetWidth(ctCOL_SupplierStock); }
            set { SetWidth(ctCOL_SupplierStock, value); }
        }
        /// <summary>
        /// <summary>
        /// [��]���ה��l
        /// </summary>
        public int Width_DtlNote
        {
            get { return GetWidth(ctCOL_DtlNote); }
            set { SetWidth(ctCOL_DtlNote, value); }
        }
        // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
        #endregion

		/// <summary>
		/// �t�H���g�T�C�Y
		/// </summary>
		public int FontSize
		{
			get { return _fontSize; }
			set { _fontSize = value; }
		}

		/// <summary>
		/// ���ŊO�ŗ��\��
		/// </summary>
		public bool DispBothTaxway
		{
			get { return _dispBothTaxway; }
			set { _dispBothTaxway = value; }
		}
		#endregion

		//====================================================================================================
		//  �p�u���b�N���\�b�h
		//====================================================================================================
		#region �p�u���b�N���\�b�h
		/// <summary>
		/// ���ח�\���X�e�[�^�X�f�[�^���������ݒ肵�Ă��邩���`�F�b�N
		/// </summary>
		/// <returns>true=����,false=�ُ�</returns>
		/// <remarks>
		/// <br>Note       : ���ח�\���X�e�[�^�X������ɐݒ肵�Ă��邩���`�F�b�N���܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public Boolean CheckDisplayStatus()
		{
			AdjustStockDtlDisplayStatus _temp;

            // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
            #region DEL 2008/07/24
            //_temp = SearchDisplayStatus(ctCOL_RowNum);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// ���i�R�[�h
            //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            ////_temp = SearchDisplayStatus(ctCOL_GoodsCode);
            //_temp = SearchDisplayStatus(ctCOL_GoodsNo);
            //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// ���i�K�C�h
            //_temp = SearchDisplayStatus(ctCOL_GoodsGuide);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// ���i����
            //_temp = SearchDisplayStatus(ctCOL_GoodsName);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //// ���[�J�[�R�[�h
            //_temp = SearchDisplayStatus(ctCOL_GoodsMakerCd);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// ���[�J�[����
            //_temp = SearchDisplayStatus(ctCOL_MakerName);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// �d���於��
            //_temp = SearchDisplayStatus(ctCOL_CustomerName);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// �a�k���i�R�[�h
            //_temp = SearchDisplayStatus(ctCOL_BLGoodsCode);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            //// �q�ɃR�[�h
            //_temp = SearchDisplayStatus(ctCOL_WarehouseCode);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// �q�ɖ���
            //_temp = SearchDisplayStatus(ctCOL_WarehouseName);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            ////// �����ԍ�
            ////_temp = SearchDisplayStatus(ctCOL_ProductNumber);
            ////if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// �g�єԍ�
            ////_temp = SearchDisplayStatus(ctCOL_StockTelNo1);
            ////if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            ////// �C���O����
            ////_temp = SearchDisplayStatus(ctCOL_BfProductNumber);            
            ////if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            ////// ���i���
            ////_temp = SearchDisplayStatus(ctCOL_GoodsCodeStatus);
            ////if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// �I��
            //_temp = SearchDisplayStatus(ctCOL_WarehouseShelfNo);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// �C���O�I��
            //_temp = SearchDisplayStatus(ctCOL_BfWarehouseShelfNo);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            //// �d���݌ɐ�
            //_temp = SearchDisplayStatus(ctCOL_SupplierStock);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// ����݌ɐ�
            //_temp = SearchDisplayStatus(ctCOL_TrustCount);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// ������
            //_temp = SearchDisplayStatus(ctCOL_AdjustCount);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// �d���P��
            //_temp = SearchDisplayStatus(ctCOL_StockUnitPrice);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// �C���O�d���P��
            //_temp = SearchDisplayStatus(ctCOL_BfStockUnitPrice);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// �������z
            //_temp = SearchDisplayStatus(ctCOL_AdjustPrice);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// 2008.01.17 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //// ���ה��l
            //_temp = SearchDisplayStatus(ctCOL_DtlNote);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// 2008.01.17 �ǉ� <<<<<<<<<<<<<<<<<<<<
            //// 2008.02.15 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //// �艿�i�����j
            //_temp = SearchDisplayStatus(ctCOL_ListPriceFl);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// 2008.02.15 �ǉ� <<<<<<<<<<<<<<<<<<<<
            #endregion DEL 2008/07/24

            string[] colKey = new string[14];
            colKey[0] = ctCOL_RowNum;               // No
            colKey[1] = ctCOL_GoodsNo;              // �i��
            colKey[2] = ctCOL_GoodsName;            // �i��
            colKey[3] = ctCOL_BLGoodsCode;          // �a�k�R�[�h
            colKey[4] = ctCOL_GoodsMakerCd;         // ���[�J�[
            colKey[5] = ctCOL_SupplierCd;           // �d����
            colKey[6] = ctCOL_ListPriceFl;          // �W�����i
            colKey[7] = ctCOL_StockUnitPrice;       // ���P��
            colKey[8] = ctCOL_SalesOrderUnit;       // �d����
            colKey[9] = ctCOL_AfSalesOrderUnit;    // �d���㐔
            colKey[10] = ctCOL_WarehouseShelfNo;    // �I��
            colKey[11] = ctCOL_SalesOrderCount;     // �����c
            colKey[12] = ctCOL_SupplierStock;       // �݌ɐ�(�d���݌ɐ�)
            colKey[13] = ctCOL_DtlNote;             // ���ה��l

            for (int index = 0; index < colKey.Length; index++)
            {
                _temp = SearchDisplayStatus(colKey[index]);
                if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            }
            // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
            return true;
		}

		/// <summary>
		/// ���ו\���X�e�[�^�X�f�[�^�������l�ɐݒ肷��B
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ו\���X�e�[�^�X��������Ԃɂ���B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public void SetDefaultValue()
		{
			AdjustStockDtlDisplayStatus _temp;

            // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
            #region DEL 2008/07/24
            ////�s�ԍ�
            //_temp = SearchDisplayStatus(ctCOL_RowNum); if (_temp == null) _temp = InitializeStatus(ctCOL_RowNum);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_RowNum].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_RowNum].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_RowNum].Visible;            
            //// ���i�R�[�h
            //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            ////_temp = SearchDisplayStatus(ctCOL_GoodsCode); if (_temp == null) _temp = InitializeStatus(ctCOL_GoodsCode);
            ////_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_GoodsCode].VisiblePosition;
            ////_temp.Width = CT_DEFAULTSTATUS[ctINDX_GoodsCode].Width;
            ////_temp.Visible = CT_DEFAULTSTATUS[ctINDX_GoodsCode].Visible;
            //_temp = SearchDisplayStatus(ctCOL_GoodsNo); if (_temp == null) _temp = InitializeStatus(ctCOL_GoodsNo);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_GoodsNo].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_GoodsNo].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_GoodsNo].Visible;
            //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            //// ���i�K�C�h
            //_temp = SearchDisplayStatus(ctCOL_GoodsGuide); if (_temp == null) _temp = InitializeStatus(ctCOL_GoodsGuide);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_GoodsGuide].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_GoodsGuide].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_GoodsGuide].Visible;
            //// ���i����
            //_temp = SearchDisplayStatus(ctCOL_GoodsName); if (_temp == null) _temp = InitializeStatus(ctCOL_GoodsName);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_GoodsName].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_GoodsName].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_GoodsName].Visible;
            //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //// ���[�J�[�R�[�h
            //_temp = SearchDisplayStatus(ctCOL_GoodsMakerCd); if (_temp == null) _temp = InitializeStatus(ctCOL_GoodsMakerCd);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_GoodsMakerCd].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_GoodsMakerCd].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_GoodsMakerCd].Visible;
            //// ���[�J�[����
            //_temp = SearchDisplayStatus(ctCOL_MakerName); if (_temp == null) _temp = InitializeStatus(ctCOL_MakerName);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_MakerName].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_MakerName].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_MakerName].Visible;
            //// �d���於��
            //_temp = SearchDisplayStatus(ctCOL_CustomerName); if (_temp == null) _temp = InitializeStatus(ctCOL_CustomerName);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_CustomerName].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_CustomerName].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_CustomerName].Visible;
            //// �a�k���i�R�[�h
            //_temp = SearchDisplayStatus(ctCOL_BLGoodsCode); if (_temp == null) _temp = InitializeStatus(ctCOL_BLGoodsCode);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_BLGoodsCode].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_BLGoodsCode].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_BLGoodsCode].Visible;
            //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            //// �q�ɃR�[�h
            //_temp = SearchDisplayStatus(ctCOL_WarehouseCode); if (_temp == null) _temp = InitializeStatus(ctCOL_WarehouseCode);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_WarehouseCode].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_WarehouseCode].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_WarehouseCode].Visible;
            //// �q�ɖ���
            //_temp = SearchDisplayStatus(ctCOL_WarehouseName); if (_temp == null) _temp = InitializeStatus(ctCOL_WarehouseName);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_WarehouseName].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_WarehouseName].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_WarehouseName].Visible;
            //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            ////// �����ԍ�
            ////_temp = SearchDisplayStatus(ctCOL_ProductNumber); if (_temp == null) _temp = InitializeStatus(ctCOL_ProductNumber);
            ////_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_ProductNumber].VisiblePosition;
            ////_temp.Width = CT_DEFAULTSTATUS[ctINDX_ProductNumber].Width;
            ////_temp.Visible = CT_DEFAULTSTATUS[ctINDX_ProductNumber].Visible;
            ////// �g�єԍ�
            ////_temp = SearchDisplayStatus(ctCOL_StockTelNo1); if (_temp == null) _temp = InitializeStatus(ctCOL_StockTelNo1);
            ////_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_StockTelNo1].VisiblePosition;
            ////_temp.Width = CT_DEFAULTSTATUS[ctINDX_StockTelNo1].Width;
            ////_temp.Visible = CT_DEFAULTSTATUS[ctINDX_StockTelNo1].Visible;
            ////// �C���O����
            ////_temp = SearchDisplayStatus(ctCOL_BfProductNumber); if (_temp == null) _temp = InitializeStatus(ctCOL_BfProductNumber);
            ////_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_BfProductNumber].VisiblePosition;
            ////_temp.Width = CT_DEFAULTSTATUS[ctINDX_BfProductNumber].Width;
            ////_temp.Visible = CT_DEFAULTSTATUS[ctINDX_BfProductNumber].Visible;
            ////// ���i���
            ////_temp = SearchDisplayStatus(ctCOL_GoodsCodeStatus); if (_temp == null) _temp = InitializeStatus(ctCOL_GoodsCodeStatus);
            ////_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_GoodsCodeStatus].VisiblePosition;
            ////_temp.Width = CT_DEFAULTSTATUS[ctINDX_GoodsCodeStatus].Width;
            ////_temp.Visible = CT_DEFAULTSTATUS[ctINDX_GoodsCodeStatus].Visible;
            //// �I��
            //_temp = SearchDisplayStatus(ctCOL_WarehouseShelfNo); if (_temp == null) _temp = InitializeStatus(ctCOL_WarehouseShelfNo);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_WarehouseShelfNo].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_WarehouseShelfNo].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_WarehouseShelfNo].Visible;
            //// �C���O�I��
            //_temp = SearchDisplayStatus(ctCOL_BfWarehouseShelfNo); if (_temp == null) _temp = InitializeStatus(ctCOL_BfWarehouseShelfNo);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_BfWarehouseShelfNo].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_BfWarehouseShelfNo].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_BfWarehouseShelfNo].Visible;
            //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            //// �d���݌ɐ�
            //_temp = SearchDisplayStatus(ctCOL_SupplierStock); if (_temp == null) _temp = InitializeStatus(ctCOL_SupplierStock);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_SupplierStock].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_SupplierStock].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_SupplierStock].Visible;
            //// ����݌ɐ�
            //_temp = SearchDisplayStatus(ctCOL_TrustCount); if (_temp == null) _temp = InitializeStatus(ctCOL_TrustCount);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_TrustCount].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_TrustCount].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_TrustCount].Visible;
            //// ������
            //_temp = SearchDisplayStatus(ctCOL_AdjustCount); if (_temp == null) _temp = InitializeStatus(ctCOL_AdjustCount);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_AdjustCount].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_AdjustCount].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_AdjustCount].Visible;
            //// �d���P��
            //_temp = SearchDisplayStatus(ctCOL_StockUnitPrice); if (_temp == null) _temp = InitializeStatus(ctCOL_StockUnitPrice);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_StockUnitPrice].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_StockUnitPrice].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_StockUnitPrice].Visible;
            //// �C���O�d���P��
            //_temp = SearchDisplayStatus(ctCOL_BfStockUnitPrice); if (_temp == null) _temp = InitializeStatus(ctCOL_BfStockUnitPrice);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_BfStockUnitPrice].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_BfStockUnitPrice].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_BfStockUnitPrice].Visible;
            //// �������z
            //_temp = SearchDisplayStatus(ctCOL_AdjustPrice); if (_temp == null) _temp = InitializeStatus(ctCOL_AdjustPrice);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_AdjustPrice].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_AdjustPrice].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_AdjustPrice].Visible;
            //// 2008.01.17 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //// ���ה��l
            //_temp = SearchDisplayStatus(ctCOL_DtlNote); if (_temp == null) _temp = InitializeStatus(ctCOL_DtlNote);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_DtlNote].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_DtlNote].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_DtlNote].Visible;
            //// 2008.01.17 �ǉ� <<<<<<<<<<<<<<<<<<<<
            //// 2008.02.15 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //// �艿�i�����j
            //_temp = SearchDisplayStatus(ctCOL_ListPriceFl); if (_temp == null) _temp = InitializeStatus(ctCOL_ListPriceFl);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_ListPriceFl].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_ListPriceFl].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_ListPriceFl].Visible;
            //// 2008.02.15 �ǉ� <<<<<<<<<<<<<<<<<<<<
            #endregion DEL 2008/07/24

            string[] colKey = new string[14];
            colKey[0] = ctCOL_RowNum;               // No
            colKey[1] = ctCOL_GoodsNo;              // �i��
            colKey[2] = ctCOL_GoodsName;            // �i��
            colKey[3] = ctCOL_BLGoodsCode;          // �a�k�R�[�h
            colKey[4] = ctCOL_GoodsMakerCd;         // ���[�J�[
            colKey[5] = ctCOL_SupplierCd;           // �d����
            colKey[6] = ctCOL_ListPriceFl;          // �W�����i
            colKey[7] = ctCOL_StockUnitPrice;       // ���P��
            colKey[8] = ctCOL_SalesOrderUnit;       // �d����
            colKey[9] = ctCOL_AfSalesOrderUnit;    // �d���㐔
            colKey[10] = ctCOL_WarehouseShelfNo;    // �I��
            colKey[11] = ctCOL_SalesOrderCount;     // �����c
            colKey[12] = ctCOL_SupplierStock;       // �݌ɐ�(�d���݌ɐ�)
            colKey[13] = ctCOL_DtlNote;             // ���ה��l

            int[] colIndex = new int[14];
            colIndex[0] = ctINDX_RowNum;            // No
            colIndex[1] = ctINDX_GoodsNo;           // �i��
            colIndex[2] = ctINDX_GoodsName;         // �i��
            colIndex[3] = ctINDX_BLGoodsCode;       // �a�k�R�[�h
            colIndex[4] = ctINDX_GoodsMakerCd;      // ���[�J�[
            colIndex[5] = ctINDX_SupplierCd;        // �d����
            colIndex[6] = ctINDX_ListPriceFl;       // �W�����i
            colIndex[7] = ctINDX_StockUnitPrice;    // ���P��
            colIndex[8] = ctINDX_SalesOrderUnit;    // �d����
            colIndex[9] = ctINDX_AfSalesOrderUnit; // �d���㐔
            colIndex[10] = ctINDX_WarehouseShelfNo; // �I��
            colIndex[11] = ctINDX_SalesOrderCount;  // �����c
            colIndex[12] = ctINDX_SupplierStock;    // �݌ɐ�(�d���݌ɐ�)
            colIndex[13] = ctINDX_DtlNote;          // ���ה��l

            for (int index = 0; index < colKey.Length; index++)
            {
                _temp = SearchDisplayStatus(colKey[index]); if (_temp == null) _temp = InitializeStatus(colKey[index]);
                _temp.VisiblePosition = CT_DEFAULTSTATUS[colIndex[index]].VisiblePosition;
                _temp.Width = CT_DEFAULTSTATUS[colIndex[index]].Width;
                _temp.Visible = CT_DEFAULTSTATUS[colIndex[index]].Visible;
            }
            // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
            
            // �t�H���g�T�C�Y
			_fontSize = 11;
        }

        #region 2007.10.11 �폜
        // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// ���ו\���X�e�[�^�X�f�[�^�𐻔Ԓ����ɐݒ肷��B
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : ���ו\���X�e�[�^�X�𐻔Ԓ����ɂ���B</br>
        ///// <br>Programer  : 19077 �n糋M�T</br>
        ///// <br>Date       : 2007.03.26</br>
        ///// </remarks>
        //public void SetProductValue()
        //{
        //    AdjustStockDtlDisplayStatus _temp;
        //    _temp = ChangeStatus(ctCOL_StockTelNo1);
        //    _temp.Visible = false;
        //    // �C���O����
        //    //_temp = SearchDisplayStatus(ctCOL_BfProductNumber); 
        //    _temp = ChangeStatus(ctCOL_BfProductNumber);
        //    _temp.Visible = true;
        //}
        // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
        #endregion 2007.10.11 �폜

        #region DEL 2008/07/24 Partsman�p�ɕύX
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        // 2007.10.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ���ו\���X�e�[�^�X�f�[�^��I�Ԓ����ɐݒ肷��B
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ו\���X�e�[�^�X��I�Ԓ����ɂ���B</br>
        /// <br>Programer  : 980035 �����`</br>
        /// <br>Date       : 2007.10.11</br>
        /// </remarks>
        public void SetShelfNoValue()
        {
            AdjustStockDtlDisplayStatus _temp;
            // �I��
            _temp = ChangeStatus(ctCOL_WarehouseShelfNo);
            _temp.Visible = true;

            // �C���O�I��
            _temp = ChangeStatus(ctCOL_BfWarehouseShelfNo);
            _temp.Visible = true;
        }
        // 2007.10.11 �ǉ� <<<<<<<<<<<<<<<<<<<<

        // 2008.02.15 �ǉ� >>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ���ו\���X�e�[�^�X�f�[�^��ʏ�\���i�������z�\���j�ɐݒ肷��B
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ו\���X�e�[�^�X��ʏ�\���i�������z�\���j�ɂ���B</br>
        /// <br>Programer  : 980035 �����`</br>
        /// <br>Date       : 2008.02.15</br>
        /// </remarks>
        public void SetAdjustPriceValue()
        {
            AdjustStockDtlDisplayStatus _temp;
            // �������z
            _temp = ChangeStatus(ctCOL_AdjustPrice);
            _temp.Visible = true;
        }
        // 2008.02.15 �ǉ� <<<<<<<<<<<<<<<<<<<<
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman�p�ɕύX

        /// <summary>
		/// �N���X�f�[�^���V���A���C�Y����B
		/// </summary>
		/// <param name="_filename">�o�͂���t�@�C������</param>
		/// <remarks>
		/// <br>Note       : ���ח�X�e�[�^�X�����V���A���C�Y����</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public void SerializeData(string _filename)
		{
			try
			{
				// �V���A���C�Y����O�ɁA�t�H���g�T�C�Y��ǉ����Ă���
				AdjustStockDtlDisplayStatus _temp = SearchDisplayStatus(ctCOL_FontSize);

				// �܂������ێ����X�g�̒��ɂȂ�(�ԈႢ�Ȃ��Ȃ��͂��ł��I�I�I)
				if (_temp == null)
				{
					_temp = new AdjustStockDtlDisplayStatus(ctCOL_FontSize, 9999, 11, false);
					mDetailStatus.Add(_temp);
				}

				// �t�H���g�T�C�Y�𕝂ɓ����
				_temp.Width = _fontSize;

				// �V���A���C�Y����O�ɁA���ŊO�ŗ��\����ǉ����Ă���
				_temp = SearchDisplayStatus(ctCOL_TaxDisplay);

				// �܂������ێ����X�g�̒��ɂȂ�(�ԈႢ�Ȃ��Ȃ��͂��ł��I�I�I)
				if (_temp == null)
				{
					_temp = new AdjustStockDtlDisplayStatus(ctCOL_TaxDisplay, 9999, 0, false);
					mDetailStatus.Add(_temp);
				}

				// ���ŊO�ŗ��\����Visible�ɓ����
				_temp.Visible = _dispBothTaxway;

				// �ێ����Ă�������o�C�g�z��ɕϊ�����
				AdjustStockDtlDisplayStatus[] dtlStat = (AdjustStockDtlDisplayStatus[])mDetailStatus.ToArray(typeof(AdjustStockDtlDisplayStatus));

				Broadleaf.Application.Common.UserSettingController.ByteSerializeUserSetting(dtlStat, ConstantManagement_ClientDirectory.UISettings_GridInfo + "\\" + _filename);
			}
			catch
			{
				// �����Ȃ��Ƃ���B
			}
		}

		/// <summary>
		/// �N���X�f�[�^���f�V���A���C�Y����B
		/// </summary>
		/// <param name="_filename">�擾����t�@�C������</param>
		/// <remarks>
		/// <br>Note       : ���ח�X�e�[�^�X�����f�V���A���C�Y����</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public void DeserializeData(string _filename)
		{
			try
			{
				// �ݒ�f�[�^��READ����
				AdjustStockDtlDisplayStatus[] dtl = Broadleaf.Application.Common.UserSettingController.ByteDeserializeUserSetting<AdjustStockDtlDisplayStatus[]>(ConstantManagement_ClientDirectory.UISettings_GridInfo + "\\" + _filename);

				// �f�[�^���������ꍇ
				if (dtl != null)
				{
					// ��U���X�g���폜
					mDetailStatus.Clear();

					foreach (AdjustStockDtlDisplayStatus wk in dtl)
					{
						mDetailStatus.Add(wk.Clone());
					}
				}

				// �f�V���A���C�Y�����Ƃ��ɁA�t�H���g�f�[�^�E���ŊO�ŗ��\���͎擾�ナ�X�g����͍폜����
				// (Grid�̗�ł͂Ȃ��̂ł��̂܂܂���Ɩ��׉�ʂ��C������K�v�����邽��)
				if (mDetailStatus != null)
				{
					int[] delIndex = new int[] { -1, -1 };
					int ix = 0;

					foreach (AdjustStockDtlDisplayStatus _st in mDetailStatus)
					{
						// �t�H���g�T�C�Y
						if (_st.ColName == ctCOL_FontSize)
						{
							_fontSize = _st.Width;
							delIndex[0] = ix;
						}
						// ���ŊO�ŗ��\��
						else if (_st.ColName == ctCOL_TaxDisplay)
						{
							_dispBothTaxway = _st.Visible;
							delIndex[1] = ix;
						}

						if ((delIndex[0] != -1) && (delIndex[1] != -1)) break;
						ix++;
					}

					// ���X�g���폜(��납��)
					Array.Sort(delIndex);
					for (int i = delIndex.Length -1; i >= 0; i--)
					{
						if (delIndex[i] != -1)
						{
							mDetailStatus.RemoveAt(delIndex[i]);
						}
					}
				}
			}
			catch
			{
				// �����Ȃ��Ƃ���B
			}
		}

		/// <summary>
		/// �\�����ɕ��ёւ���ꂽ�J�������̃��X�g���擾���܂��B
		/// </summary>
		/// <returns>�\�����̃J�������̃��X�g</returns>
		/// <remarks>
		/// <br>Note       : ���ח�\���X�e�[�^�X��\�����ɕ��ёւ��A���̃J�������̃��X�g���擾���܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public ArrayList GetVisiblePositionList()
		{
			mDetailStatus.Sort(new VisibleCompare());

			ArrayList _retList = new ArrayList();
			for (int i = 0; i < mDetailStatus.Count; i++)
			{
				_retList.Add(((AdjustStockDtlDisplayStatus)mDetailStatus[i]).ColName);
			}
			return _retList;
		}

		/// <summary>
		/// ���ו\����X�e�[�^�X��r
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ו\�����\�����ɕ��ёւ��܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		internal class VisibleCompare : System.Collections.IComparer
		{
			#region IComparer �����o
			/// <summary>
			/// ���ёւ�������
			/// </summary>
			/// <param name="x">����r�I�u�W�F�N�g</param>
			/// <param name="y">����r�I�u�W�F�N�g</param>
			/// <returns>0����:������,0:������,0����:x����</returns>
			/// <remarks>
			/// <br>Note       : �I�u�W�F�N�g���m���r���܂��B</br>
			/// <br>Programer  : 19077 �n糋M�T</br>
			/// <br>Date       : 2007.03.26</br>
			/// </remarks>
			public int Compare(object x, object y)
			{
				if ((x is AdjustStockDtlDisplayStatus) && (y is AdjustStockDtlDisplayStatus))
				{
					return ((AdjustStockDtlDisplayStatus)x).VisiblePosition - ((AdjustStockDtlDisplayStatus)y).VisiblePosition;
				}

				return 0;
			}

			#endregion
		}
		#endregion

		//====================================================================================================
		//  �v���C�x�[�g���\�b�h
		//====================================================================================================
		#region �v���C�x�[�g���\�b�h
		/// <summary>
		/// ���ח�\���X�e�[�^�X����
		/// </summary>
		/// <param name="_key">�J��������</param>
		/// <returns>�����������ח�\���X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ���ח�\���X�e�[�^�X���������܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private AdjustStockDtlDisplayStatus SearchDisplayStatus(string _key)
		{
			if (mDetailStatus != null)
			{
				foreach (AdjustStockDtlDisplayStatus _st in mDetailStatus)
				{
					if (_st.ColName == _key)
					{
						return _st;
					}
				}
			}
			return null;
		}

		/// <summary>
		/// �w�肳�ꂽ���ח�̕\���󋵃X�e�[�^�X�����������܂��B
		/// </summary>
		/// <param name="_key">�����������</param>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ���ו\����̕\���󋵃X�e�[�^�X�����������܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private AdjustStockDtlDisplayStatus InitializeStatus(string _key)
		{
			int _index = -1;

            // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
            #region DEL 2008/07/24
            //if (_key == ctCOL_RowNum) { _index = ctINDX_RowNum; }
            //// ���i�R�[�h
            //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            ////else if (_key == ctCOL_GoodsCode) { _index = ctINDX_GoodsCode; }
            //else if (_key == ctCOL_GoodsNo) { _index = ctINDX_GoodsNo; }
            //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            //// ���i�K�C�h
            //else if (_key == ctCOL_GoodsGuide) { _index = ctINDX_GoodsGuide; }
            //// ���i����
            //else if (_key == ctCOL_GoodsName) { _index = ctINDX_GoodsName; }
            //// 2007.10.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //// �q�ɒI��
            //else if (_key == ctCOL_WarehouseShelfNo) { _index = ctINDX_WarehouseShelfNo; }
            //// �C���O�q�ɒI��
            //else if (_key == ctCOL_BfWarehouseShelfNo) { _index = ctINDX_BfWarehouseShelfNo; }
            //// 2007.10.11 �ǉ� <<<<<<<<<<<<<<<<<<<<
            //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            ////// �����ԍ�
            ////else if (_key == ctCOL_ProductNumber) { _index = ctINDX_ProductNumber; }
            ////// �g�єԍ�
            ////else if (_key == ctCOL_StockTelNo1) { _index = ctINDX_StockTelNo1; }
            ////// �C���O����
            ////else if (_key == ctCOL_BfProductNumber) { _index = ctINDX_BfProductNumber; }
            ////// ���i���
            ////else if (_key == ctCOL_GoodsCodeStatus) { _index = ctINDX_GoodsCodeStatus; }
            //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            //// �d���݌ɐ�
            //else if (_key == ctCOL_SupplierStock) { _index = ctINDX_SupplierStock; }
            //// ����݌ɐ�
            //else if (_key == ctCOL_TrustCount) { _index = ctINDX_TrustCount; }
            //// ������
            //else if (_key == ctCOL_AdjustCount) { _index = ctINDX_AdjustCount; }
            //// �d���P��
            //else if (_key == ctCOL_StockUnitPrice) { _index = ctINDX_StockUnitPrice; }
            //// �C���O�d���P��
            //else if (_key == ctCOL_BfStockUnitPrice) { _index = ctINDX_BfStockUnitPrice; }
            //// �������z
            //else if (_key == ctCOL_AdjustPrice) { _index = ctINDX_AdjustPrice; }
            //// 2008.01.17 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //// ���ה��l
            //else if (_key == ctCOL_DtlNote) { _index = ctINDX_DtlNote; }
            //// 2008.01.17 �ǉ� <<<<<<<<<<<<<<<<<<<<
            //// 2008.02.15 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //// �艿�i�����j
            //else if (_key == ctCOL_ListPriceFl) { _index = ctINDX_ListPriceFl; }
            //// 2008.02.15 �ǉ� <<<<<<<<<<<<<<<<<<<<
            #endregion DEL 2008/07/24

            if (_key == ctCOL_RowNum) { _index = ctINDX_RowNum; }                               // No
            else if (_key == ctCOL_GoodsNo) { _index = ctINDX_GoodsNo; }                        // �i��
            else if (_key == ctCOL_GoodsName) { _index = ctINDX_GoodsName; }                    // �i��
            else if (_key == ctCOL_BLGoodsCode) { _index = ctINDX_BLGoodsCode; }                // BL�R�[�h
            else if (_key == ctCOL_GoodsMakerCd) { _index = ctINDX_GoodsMakerCd; }              // ���[�J�[
            else if (_key == ctCOL_SupplierCd) { _index = ctINDX_SupplierCd; }                  // �d����
            else if (_key == ctCOL_ListPriceFl) { _index = ctINDX_ListPriceFl; }                // �W�����i
            else if (_key == ctCOL_StockUnitPrice) { _index = ctINDX_StockUnitPrice; }          // ���P��
            else if (_key == ctCOL_SalesOrderUnit) { _index = ctINDX_SalesOrderUnit; }          // �d����
            else if (_key == ctCOL_AfSalesOrderUnit) { _index = ctINDX_AfSalesOrderUnit; }      // �d���㐔
            else if (_key == ctCOL_WarehouseShelfNo) { _index = ctINDX_WarehouseShelfNo; }      // �I��
            else if (_key == ctCOL_SalesOrderCount) { _index = ctINDX_SalesOrderCount; }        // �����c
            else if (_key == ctCOL_SupplierStock) { _index = ctINDX_SupplierStock; }            // �݌ɐ�(�d���݌ɐ�)
            else if (_key == ctCOL_DtlNote) { _index = ctINDX_DtlNote; }                        // ���ה��l
            // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<

			int _width = 0;
			Boolean _visible = false;

			if (_index != -1)
			{
				_width = CT_DEFAULTSTATUS[_index].Width;
				_visible = CT_DEFAULTSTATUS[_index].Visible;
                _visible = CT_CHANGESTATUS[_index].Visible;
			}

			AdjustStockDtlDisplayStatus _temp = SearchDisplayStatus(_key);
			if (_temp == null)
			{
				_temp = new AdjustStockDtlDisplayStatus(_key, -1, _width, _visible);
				mDetailStatus.Add(_temp);
			}
			else
			{
				_temp.Width = _width;
				_temp.Visible = _visible;
				_temp.VisiblePosition = -1;                

			}
			return _temp;
		}

        /// <summary>
        /// �w�肳�ꂽ���ח�̕\���󋵃X�e�[�^�X��ύX���܂��B
        /// </summary>
        /// <param name="_key">�ύX�����</param>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ���ו\����̕\���󋵃X�e�[�^�X��ύX���܂��B</br>
        /// <br>Programer  : 19077 �n糋M�T</br>
        /// <br>Date       : 2007.03.26</br>
        /// </remarks>
        private AdjustStockDtlDisplayStatus ChangeStatus(string _key)
        {
            int _index = -1;

            // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
            #region DEL 2008/07/24
            //if (_key == ctCOL_RowNum) { _index = ctINDX_RowNum; }
            //// ���i�R�[�h
            //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            ////else if (_key == ctCOL_GoodsCode) { _index = ctINDX_GoodsCode; }
            //else if (_key == ctCOL_GoodsNo) { _index = ctINDX_GoodsNo; }
            //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            //// ���i����
            //else if (_key == ctCOL_GoodsName) { _index = ctINDX_GoodsName; }
            //// 2007.10.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //// �q�ɒI��
            //else if (_key == ctCOL_WarehouseShelfNo) { _index = ctINDX_WarehouseShelfNo; }
            //// �C���O�q�ɒI��
            //else if (_key == ctCOL_BfWarehouseShelfNo) { _index = ctINDX_BfWarehouseShelfNo; }
            //// 2007.10.11 �ǉ� <<<<<<<<<<<<<<<<<<<<
            //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            ////// �����ԍ�
            ////else if (_key == ctCOL_ProductNumber) { _index = ctINDX_ProductNumber; }
            ////// �g�єԍ�
            ////else if (_key == ctCOL_StockTelNo1) { _index = ctINDX_StockTelNo1; }
            ////// �C���O����
            ////else if (_key == ctCOL_BfProductNumber) { _index = ctINDX_BfProductNumber; }
            ////// ���i���
            ////else if (_key == ctCOL_GoodsCodeStatus) { _index = ctINDX_GoodsCodeStatus; }
            //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            //// �d���݌ɐ�
            //else if (_key == ctCOL_SupplierStock) { _index = ctINDX_SupplierStock; }
            //// ����݌ɐ�
            //else if (_key == ctCOL_TrustCount) { _index = ctINDX_TrustCount; }
            //// ������
            //else if (_key == ctCOL_AdjustCount) { _index = ctINDX_AdjustCount; }
            //// �d���P��
            //else if (_key == ctCOL_StockUnitPrice) { _index = ctINDX_StockUnitPrice; }
            //// �C���O�d���P��
            //else if (_key == ctCOL_BfStockUnitPrice) { _index = ctINDX_BfStockUnitPrice; }
            //// �������z
            //else if (_key == ctCOL_AdjustPrice) { _index = ctINDX_AdjustPrice; }
            //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //// �C���O����
            ////else if (_key == ctCOL_BfProductNumber) { _index = ctINDX_BfProductNumber; }
            //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            //// 2008.01.17 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //// ���ה��l
            //else if (_key == ctCOL_DtlNote) { _index = ctINDX_DtlNote; }
            //// 2008.01.17 �ǉ� <<<<<<<<<<<<<<<<<<<<
            //// 2008.02.15 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //// �艿�i�����j
            //else if (_key == ctCOL_ListPriceFl) { _index = ctINDX_ListPriceFl; }
            //// 2008.02.15 �ǉ� <<<<<<<<<<<<<<<<<<<<
            #endregion DEL 2008/07/24

            if (_key == ctCOL_RowNum) { _index = ctINDX_RowNum; }                               // No
            else if (_key == ctCOL_GoodsNo) { _index = ctINDX_GoodsNo; }                        // �i��
            else if (_key == ctCOL_GoodsName) { _index = ctINDX_GoodsName; }                    // �i��
            else if (_key == ctCOL_BLGoodsCode) { _index = ctINDX_BLGoodsCode; }                // BL�R�[�h
            else if (_key == ctCOL_GoodsMakerCd) { _index = ctINDX_GoodsMakerCd; }              // ���[�J�[
            else if (_key == ctCOL_SupplierCd) { _index = ctINDX_SupplierCd; }                  // �d����
            else if (_key == ctCOL_ListPriceFl) { _index = ctINDX_ListPriceFl; }                // �W�����i
            else if (_key == ctCOL_StockUnitPrice) { _index = ctINDX_StockUnitPrice; }          // ���P��
            else if (_key == ctCOL_SalesOrderUnit) { _index = ctINDX_SalesOrderUnit; }          // �d����
            else if (_key == ctCOL_AfSalesOrderUnit) { _index = ctINDX_AfSalesOrderUnit; }      // �d���㐔
            else if (_key == ctCOL_WarehouseShelfNo) { _index = ctINDX_WarehouseShelfNo; }      // �I��
            else if (_key == ctCOL_SalesOrderCount) { _index = ctINDX_SalesOrderCount; }        // �����c
            else if (_key == ctCOL_SupplierStock) { _index = ctINDX_SupplierStock; }            // �݌ɐ�(�d���݌ɐ�)
            else if (_key == ctCOL_DtlNote) { _index = ctINDX_DtlNote; }                        // ���ה��l
            // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<

            int _width = 0;
            Boolean _visible = false;

            if (_index != -1)
            {
                _width = CT_DEFAULTSTATUS[_index].Width;
                _visible = CT_DEFAULTSTATUS[_index].Visible;
            }

            AdjustStockDtlDisplayStatus _temp = SearchDisplayStatus(_key);
            if (_temp == null)
            {
                _temp = new AdjustStockDtlDisplayStatus(_key, -1, _width, _visible);
                mDetailStatus.Add(_temp);
            }
            else
            {
                _temp.Width = _width;
                _temp.Visible = _visible;
                _temp.VisiblePosition = -1;
            }
            return _temp;
        }


		/// <summary>
		/// �w�肳�ꂽ��̕\���X�e�[�^�X���擾����B
		/// </summary>
		/// <param name="_key">�Ώۗ�L�[</param>
		/// <returns>true=�\��,false=��\��</returns>
		/// <remarks>
		/// <br>Note       : ��̕\���X�e�[�^�X�擾</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private Boolean GetVisible(string _key)
		{
			AdjustStockDtlDisplayStatus _temp = SearchDisplayStatus(_key);

			// ����������Ă��Ȃ��H
			if (_temp == null)
			{
				// �X�e�[�^�X������������B
				_temp = InitializeStatus(_key);
			}
			// �w�肳�ꂽ�l��߂��B
			return _temp.Visible;
		}

		/// <summary>
		/// �w�肳�ꂽ��̕\���X�e�[�^�X��ݒ肷��B
		/// </summary>
		/// <param name="_key">�Ώۗ�L�[</param>
		/// <param name="_value">true=�\��,false=��\��</param>
		/// <remarks>
		/// <br>Note       : ��̕\���X�e�[�^�X�ݒ�</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void SetVisible(string _key, Boolean _value)
		{
			AdjustStockDtlDisplayStatus _temp = SearchDisplayStatus(_key);
			// ����������Ă��Ȃ��H
			if (_temp == null)
			{
				// �X�e�[�^�X������������B
				_temp = InitializeStatus(_key);
			}
			// �w�肳�ꂽ�l��ݒ肷��B
			_temp.Visible = _value;
		}

		/// <summary>
		/// �w�肳�ꂽ��̗񕝂��擾����B
		/// </summary>
		/// <param name="_key">�Ώۗ�L�[</param>
		/// <returns>�擾������</returns>
		/// <remarks>
		/// <br>Note       : ��̗񕝎擾</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private int GetWidth(string _key)
		{
			AdjustStockDtlDisplayStatus _temp = SearchDisplayStatus(_key);
			// ����������Ă��Ȃ��H
			if (_temp == null)
			{
				// �X�e�[�^�X������������B
				_temp = InitializeStatus(_key);
			}
			// �w�肳�ꂽ�l��߂��B
			return _temp.Width;
		}

		/// <summary>
		/// �w�肳�ꂽ��̗񕝂�ݒ肷��B
		/// </summary>
		/// <param name="_key">�Ώۗ�L�[</param>
		/// <param name="_width">��</param>
		/// <remarks>
		/// <br>Note       : ��̗񕝐ݒ�</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void SetWidth(string _key, int _width)
		{
			AdjustStockDtlDisplayStatus _temp = SearchDisplayStatus(_key);
			// ����������Ă��Ȃ��H
			if (_temp == null)
			{
				// �X�e�[�^�X������������B
				_temp = InitializeStatus(_key);
			}
			// �w�肳�ꂽ�l��ݒ肷��B
			_temp.Width = _width;
		}

		/// <summary>
		/// �w�肳�ꂽ��̕\���ʒu���擾����B
		/// </summary>
		/// <param name="_key">�Ώۗ�L�[</param>
		/// <returns>�擾������ʒu</returns>
		/// <remarks>
		/// <br>Note       : ��̗�ʒu�擾</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private int GetVisiblePosition(string _key)
		{
			AdjustStockDtlDisplayStatus _temp = SearchDisplayStatus(_key);
			// ����������Ă��Ȃ��H
			if (_temp == null)
			{
				// �X�e�[�^�X������������B
				_temp = InitializeStatus(_key);
			}
			// �w�肳�ꂽ�l��߂��B
			return _temp.VisiblePosition;
		}

		/// <summary>
		/// �w�肳�ꂽ��̕\���ʒu��ݒ肷��B
		/// </summary>
		/// <param name="_key">�Ώۗ�L�[</param>
		/// <param name="_position">�\���ʒu</param>
		/// <remarks>
		/// <br>Note       : ��̕\���ʒu�ݒ�</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void SetVisiblePosition(string _key, int _position)
		{
			AdjustStockDtlDisplayStatus _temp = SearchDisplayStatus(_key);
			// ����������Ă��Ȃ��H
			if (_temp == null)
			{
				// �X�e�[�^�X������������B
				_temp = InitializeStatus(_key);
			}
			// �w�肳�ꂽ�l��ݒ肷��B
			_temp.VisiblePosition = _position;
		}
		#endregion
	}

	/// <summary>
	/// ���ו\���󋵃N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �`�[���ׂ̕\���󋵂������N���X</br>
	/// <br>Programer  : 19077 �n糋M�T</br>
	/// <br>Date       : 2007.03.26</br>
	/// </remarks>
	[Serializable]
	public class AdjustStockDtlDisplayStatus : ICloneable
	{
		#region �R���X�g���N�^
		/// <summary>
		/// ���ו\���󋵃N���X�R���X�g���N�^
		/// </summary>
		public AdjustStockDtlDisplayStatus()
		{ }

		/// <summary>
		/// ���ו\���󋵃N���X�R���X�g���N�^
		/// </summary>
		/// <param name="_colName">�J��������</param>
		/// <param name="_position">�\���ʒu</param>
		/// <param name="_width">��</param>
		/// <param name="_visible">�\���^��\��</param>
		/// <remarks>
		/// <br>Note       : ���ו\���󋵃N���X�̃C���X�^���X���쐬���A���������܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public AdjustStockDtlDisplayStatus(string _colName, int _position, int _width, Boolean _visible)
		{
			mColName = _colName;
			mOrder = _position;
			mWidth = _width;
			mVisible = _visible;
		}
		#endregion

		#region	�v���C�x�[�g�ϐ�
		/// <summary>
		/// �\���ʒu
		/// </summary>
		private int mOrder = -1;
		/// <summary>
		/// ��
		/// </summary>
		private int mWidth = -1;
		/// <summary>
		/// �\��/��\��
		/// </summary>
		private Boolean mVisible = false;
		/// <summary>
		/// �J��������
		/// </summary>
		private string mColName = "";
		#endregion

		#region �p�u���b�N�v���p�e�B
		/// <summary>
		/// �\���ʒu
		/// </summary>
		public int VisiblePosition
		{
			get { return this.mOrder; }
			set { this.mOrder = value; }
		}
		/// <summary>
		/// ��
		/// </summary>
		public int Width
		{
			get { return this.mWidth; }
			set { this.mWidth = value; }
		}
		/// <summary>
		/// �\���^��\��
		/// </summary>
		public Boolean Visible
		{
			get { return this.mVisible; }
			set { this.mVisible = value; }
		}
		/// <summary>
		/// �J��������
		/// </summary>
		public string ColName
		{
			get { return this.mColName; }
			set { this.mColName = value; }
		}
		#endregion

		#region ICloneable �����o
		/// <summary>
		/// �{�N���X�̃R�s�[����
		/// </summary>
		/// <returns>���̃N���X�̃N���[��</returns>
		/// <remarks>
		/// <br>Note       : �N���X�̃N���[������</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public object Clone()
		{
			return new AdjustStockDtlDisplayStatus(this.mColName, this.mOrder, this.mWidth, this.mVisible); ;
		}
		#endregion
	}
}
