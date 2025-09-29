using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;

// �W�F�l���b�N�ɑ΂���ʖ���`
using SlipDtlColumnStateList =
	System.Collections.Generic.Dictionary<string, Broadleaf.Windows.Forms.ControlSlipDtlColumnState.AdjustStockColumnState>;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �`�[���ח��ԊǗ��N���X
	/// </summary>
	internal class ControlSlipDtlColumnState
	{
		#region Private Members
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>�ʏ���͗��ԃ��X�g</summary>
		private static Dictionary<int, SlipDtlColumnStateList> normalInputList = null;
		/// <summary>�݌ɃI�v�V�������͗��ԃ��X�g</summary>
		private static Dictionary<int, SlipDtlColumnStateList> stockOptionInputList = null;
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        private static SlipDtlColumnStateList _slipDtlColumnStateList;
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        //GRID���ڕҏW�`��
		private const int ctKEY_None = 0;					// �d����������
        // 2008.01.17 �C�� >>>>>>>>>>>>>>>>>>>>
        //private const int ctKEY_Trust = 1;
        //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        ////private const int ctKEY_Product = 2;       			// ���ԕύX
        ////private const int ctKEY_ErrorGoods = 3;				// �s�Ǖi
        ////private const int ctKEY_Stock_PriceExc = 4;			// ��������
        //private const int ctKEY_Stock_PriceExc = 2;			// ��������
        //private const int ctKEY_ShelfNo = 3;				// �I�ԕύX
        //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        private const int ctKEY_Stock_PriceExc = 1;			// ��������
        private const int ctKEY_ShelfNo = 2;				// �I�ԕύX
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        // 2008.01.17 �C�� <<<<<<<<<<<<<<<<<<<<

		#endregion

		#region Constructor
		/// <summary>
		/// �X�^�e�B�b�N�R���X�g���N�^
		/// </summary>
		static ControlSlipDtlColumnState()
		{
			// �ʏ���͎���ԃ��X�g�쐬
			CreateNormalList();

            /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
			// �݌ɃI�v�V��������ԃ��X�g�쐬
			CreateStockOptionList();
               --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        }

		/// <summary>
		/// �f�t�H���g�R���X�g���N�^
		/// </summary>
		private ControlSlipDtlColumnState()
		{
		}
		#endregion

		#region Public Methods

        /// <summary>
        /// ���ԃ��X�g�擾����[�s�ԍ��w���]
        /// </summary>
        /// <param name="rowIndex">�s�C���f�b�N�X</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���ԃ��X�g���擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public static SlipDtlColumnStateList GetSlipDtlColumnState(int rowIndex)
        {
            return GetProductStockColumnStateListProc(AdjustStockAcs.AdjustStockView[rowIndex].Row);
        }

        /// <summary>
        /// ���ԃ��X�g�擾����[�f�[�^�s�w���]
        /// </summary>
        /// <param name="dataRow">�f�[�^��</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���ԃ��X�g���擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public static SlipDtlColumnStateList GetSlipDtlColumnState(DataRow dataRow)
        {
            return GetProductStockColumnStateListProc(dataRow);
        }

        #region DEL 2008/07/24 Partsman�p�ɕύX
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// ���ԃ��X�g�擾����[�s�ԍ��w���]
		/// </summary>
		/// <param name="rowIndex"></param>
		/// <returns></returns>
		public static SlipDtlColumnStateList GetSlipDtlColumnState(int rowIndex,int mode)
		{
			return GetProductStockColumnStateListProc(AdjustStockAcs.AdjustStockView[rowIndex].Row,mode);
		}


		/// <summary>
		/// ���ԃ��X�g�擾����[�f�[�^�s�w���]
		/// </summary>
		/// <param name="dataRow"></param>
		/// <returns></returns>
		public static SlipDtlColumnStateList GetSlipDtlColumnState(DataRow dataRow,int mode)
		{
			return GetProductStockColumnStateListProc(dataRow,mode);
		}
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman�p�ɕύX

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// ���ԃ��X�g�擾����
        /// </summary>
        /// <param name="srcRow">�f�[�^��</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���ԃ��X�g���擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private static SlipDtlColumnStateList GetProductStockColumnStateListProc(DataRow srcRow)
        {
            return _slipDtlColumnStateList;
        }

        #region DEL 2008/07/24 Partsman�p�ɕύX
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// ���ԃ��X�g�擾����
		/// </summary>
		/// <returns></returns>
		private static SlipDtlColumnStateList GetProductStockColumnStateListProc(DataRow srcRow,int mode)
		{
//			SlipDtlColumnStateList retList = normalInputList[ctKEY_None];
			SlipDtlColumnStateList retList = normalInputList[mode];

  //          SlipDtlColumnStateList retList = normalInputList[selectMode];
            
			return retList;
        }
        
        /// <summary>
        /// �ʏ���͗��ԃ��X�g�쐬����
        /// </summary>
        private static void CreateNormalList()
        {
            normalInputList = new Dictionary<int, Dictionary<string, AdjustStockColumnState>>();
            SlipDtlColumnStateList wkDic;

            //-- �݌ɒ��� --//���i�R�[�h�E�K�C�h�E������			ReadOnly, Enable, Visible
            #region
            wkDic = new SlipDtlColumnStateList();
            wkDic.Add(
                AdjustStockAcs.ctCOL_RowNum,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_RowNum, false, false, true, Color.Black)); // No
            wkDic.Add(
                // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                //AdjustStockAcs.ctCOL_GoodsCode,
                //new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsCode, false, true, true, Color.Black)); // ���i�R�[�h
                AdjustStockAcs.ctCOL_GoodsNo,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsNo, false, true, true, Color.Black)); // ���i�R�[�h
            // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            wkDic.Add(
                AdjustStockAcs.ctCOL_GoodsGuide,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsGuide, false, true, true, Color.Black)); //���i�K�C�h
            wkDic.Add(
                AdjustStockAcs.ctCOL_GoodsName,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsName, false, false, true, Color.Black)); // ���i����
            // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            wkDic.Add(
                AdjustStockAcs.ctCOL_GoodsMakerCd,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsMakerCd, false, false, true, Color.Black)); // ���[�J�[�R�[�h
            wkDic.Add(
                AdjustStockAcs.ctCOL_MakerName,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_MakerName, false, false, true, Color.Black)); // ���[�J�[����
            wkDic.Add(
                AdjustStockAcs.ctCOL_BLGoodsCode,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_BLGoodsCode, false, false, true, Color.Black)); // �a�k���i�R�[�h
            // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            wkDic.Add(
                AdjustStockAcs.ctCOL_WarehouseCode,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseCode, false, false, true, Color.Black)); //�q�ɃR�[�h
            wkDic.Add(
                AdjustStockAcs.ctCOL_WarehouseName,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseName, false, false, true, Color.Black));
            // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //wkDic.Add(
            //	AdjustStockAcs.ctCOL_ProductNumber,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_ProductNumber, false, false, true, Color.Black)); // ����
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_BfProductNumber,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_BfProductNumber, false, false, false, Color.Black)); //�ύX�O����
            //wkDic.Add(
            //	AdjustStockAcs.ctCOL_StockTelNo1,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_StockTelNo1, false, false, true, Color.Black)); // �g�єԍ�
            wkDic.Add(
                AdjustStockAcs.ctCOL_WarehouseShelfNo,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseShelfNo, false, false, true, Color.Black)); //�I��
            wkDic.Add(
                AdjustStockAcs.ctCOL_BfWarehouseShelfNo,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_BfWarehouseShelfNo, false, false, false, Color.Black)); //�C���O�I��
            // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            wkDic.Add(
                AdjustStockAcs.ctCOL_SupplierStock,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_SupplierStock, false, false, true, Color.Black)); // �݌ɐ�
            wkDic.Add(
                AdjustStockAcs.ctCOL_TrustCount,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_TrustCount, false, false, true, Color.Black)); // �����
            wkDic.Add(
                AdjustStockAcs.ctCOL_AdjustCount,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_AdjustCount, false, true, true, Color.Black)); // ������
            // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_GoodsCodeStatus,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsCodeStatus, false, false, false, Color.Black)); // �݌ɏ��
            // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
            wkDic.Add(
                AdjustStockAcs.ctCOL_StockUnitPrice,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_StockUnitPrice, false, false, true, Color.Black)); // �d���P��
            wkDic.Add(
                AdjustStockAcs.ctCOL_AdjustPrice,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_AdjustPrice, false, false, true, Color.Black)); // �������z
            // 2008.01.17 �ǉ� >>>>>>>>>>>>>>>>>>>>
            wkDic.Add(
                AdjustStockAcs.ctCOL_DtlNote,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_DtlNote, false, true, true, Color.Black)); // ���ה��l
            // 2008.01.17 �ǉ� <<<<<<<<<<<<<<<<<<<<
            // 2008.02.15 �C�� >>>>>>>>>>>>>>>>>>>>
            wkDic.Add(
                AdjustStockAcs.ctCOL_ListPriceFl,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_ListPriceFl, false, false, false, Color.Black)); // �艿�i�����j
            // 2008.02.15 �C�� <<<<<<<<<<<<<<<<<<<<
            normalInputList.Add(ctKEY_None, wkDic);
            #endregion

            // 2008.01.17 �폜 >>>>>>>>>>>>>>>>>>>>
            #region �������
            //wkDic = new SlipDtlColumnStateList();
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_RowNum,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_RowNum, false, false, true, Color.Black)); // No
            //wkDic.Add(
            //    // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //    //AdjustStockAcs.ctCOL_GoodsCode,
            //    //new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsCode, false, true, true, Color.Black)); // ���i�R�[�h
            //    AdjustStockAcs.ctCOL_GoodsNo,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsNo, false, true, true, Color.Black)); // ���i�R�[�h
            //    // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_GoodsGuide,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsGuide, false, true, true, Color.Black)); //���i�K�C�h
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_GoodsName,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsName, false, false, true, Color.Black)); // ���i����
            //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_GoodsMakerCd,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsMakerCd, false, false, true, Color.Black)); // ���[�J�[�R�[�h
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_MakerName,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_MakerName, false, false, true, Color.Black)); // ���[�J�[����
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_CustomerName,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_CustomerName, false, false, false, Color.Black)); // �d���於��
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_BLGoodsCode,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_BLGoodsCode, false, false, true, Color.Black)); // �a�k���i�R�[�h
            //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_WarehouseCode,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseCode, false, false, true, Color.Black)); //�q�ɃR�[�h
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_WarehouseName,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseName, false, false, true, Color.Black)); //�q�ɖ���
            //// 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            ////wkDic.Add(
            ////    AdjustStockAcs.ctCOL_ProductNumber,
            ////    new AdjustStockColumnState(AdjustStockAcs.ctCOL_ProductNumber, false, false, true, Color.Black)); // ����
            ////wkDic.Add(
            ////    AdjustStockAcs.ctCOL_BfProductNumber,
            ////    new AdjustStockColumnState(AdjustStockAcs.ctCOL_BfProductNumber, false, false, false, Color.Black)); //�ύX�O����
            ////wkDic.Add(
            ////    AdjustStockAcs.ctCOL_StockTelNo1,
            ////    new AdjustStockColumnState(AdjustStockAcs.ctCOL_StockTelNo1, false, false, true, Color.Black)); // �g�єԍ�
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_WarehouseShelfNo,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseShelfNo, false, false, true, Color.Black)); //�I��
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_BfWarehouseShelfNo,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_BfWarehouseShelfNo, false, false, false, Color.Black)); //�C���O�I��
            //// 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_SupplierStock,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_SupplierStock, false, false, true, Color.Black)); // �݌ɐ�
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_TrustCount,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_TrustCount, false, false, true, Color.Black)); // �����
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_AdjustCount,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_AdjustCount, false, true, true, Color.Black)); // ������
            //// 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
            ////wkDic.Add(
            ////    AdjustStockAcs.ctCOL_GoodsCodeStatus,
            ////    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsCodeStatus, false, false, false, Color.Black)); // �݌ɏ��
            //// 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_StockUnitPrice,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_StockUnitPrice, false, false, true, Color.Black)); // �d���P��
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_AdjustPrice,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_AdjustPrice, false, false, true, Color.Black)); // �������z
            //normalInputList.Add(ctKEY_Trust, wkDic);
            #endregion
            // 2008.01.17 �폜 <<<<<<<<<<<<<<<<<<<<


            //--���ԕύX--// ���i�R�[�h�E���i�K�C�h�E�����ԍ�
            // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
            #region ���ԕύX
            //wkDic = new SlipDtlColumnStateList();
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_RowNum,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_RowNum, false, false, true, Color.Black));	// No
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_GoodsCode,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsCode, false, true, true, Color.Black));	// ���i�R�[�h
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_GoodsGuide,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsGuide, false, true, true, Color.Black)); //���i�K�C�h
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_GoodsName,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsName, false, false, true, Color.Black));		// ���i����
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_ProductNumber,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_ProductNumber, false, true, true, Color.Black));	// ����
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_WarehouseCode,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseCode, false, false, true, Color.Black));
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_WarehouseName,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseName, false, false, true, Color.Black));
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_BfProductNumber,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_BfProductNumber, false, false, false, Color.Black));//�ύX�O����
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_StockTelNo1,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_StockTelNo1, false, false, true, Color.Black));			// �g�єԍ�
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_SupplierStock,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_SupplierStock, false, false, true, Color.Black));				// �݌ɐ�
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_TrustCount,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_TrustCount, false, false, true, Color.Black));          // �����
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_AdjustCount,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_AdjustCount, false, false, true, Color.Black));			// ������
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_GoodsCodeStatus,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsCodeStatus, false, false, false, Color.Black));         // �݌ɏ��
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_StockUnitPrice,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_StockUnitPrice, false, false, true, Color.Black));		// �d���P��
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_AdjustPrice,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_AdjustPrice, false, false, true, Color.Black));			// �������z
            //normalInputList.Add(ctKEY_Product, wkDic);
            #endregion
            // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<

            //--�s�Ǖi--// ���i�R�[�h�E���i�K�C�h�E���i���
            // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
            #region �s�Ǖi
            //wkDic = new SlipDtlColumnStateList();
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_RowNum,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_RowNum, false, false, true, Color.Black));	// No
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_GoodsCode,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsCode, false, true, true, Color.Black));	// ���i�R�[�h
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_GoodsGuide,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsGuide, false, true, true, Color.Black)); //���i�K�C�h
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_GoodsName,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsName, false, false, true, Color.Black));		// ���i����
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_WarehouseCode,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseCode, false, false, true, Color.Black));
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_WarehouseName,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseName, false, false, true, Color.Black));
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_ProductNumber,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_ProductNumber, false, false, true, Color.Black));	// ����
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_BfProductNumber,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_BfProductNumber, false, false, false, Color.Black));//�ύX�O����
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_StockTelNo1,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_StockTelNo1, false, false, true, Color.Black));			// �g�єԍ�
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_SupplierStock,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_SupplierStock, false, false, true, Color.Black));				// �݌ɐ�
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_TrustCount,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_TrustCount, false, false, true, Color.Black));          // �����
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_AdjustCount,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_AdjustCount, false, false, true, Color.Black));			// ������
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_GoodsCodeStatus,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsCodeStatus, false, true, true, Color.Black));         // �݌ɏ��
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_StockUnitPrice,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_StockUnitPrice, false, false, true, Color.Black));		// �d���P��
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_AdjustPrice,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_AdjustPrice, false, false, true, Color.Black));			// �������z
            //normalInputList.Add(ctKEY_ErrorGoods, wkDic);
            #endregion
            // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<

            //--��������--// ���i�R�[�h�E���i�K�C�h�E�d���P��
            #region ��������
            wkDic = new SlipDtlColumnStateList();
            wkDic.Add(
                AdjustStockAcs.ctCOL_RowNum,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_RowNum, false, false, true, Color.Black)); // No
            wkDic.Add(
                // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                //AdjustStockAcs.ctCOL_GoodsCode,
                //new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsCode, false, true, true, Color.Black)); // ���i�R�[�h
                AdjustStockAcs.ctCOL_GoodsNo,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsNo, false, true, true, Color.Black)); // ���i�R�[�h
            // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            wkDic.Add(
                AdjustStockAcs.ctCOL_GoodsGuide,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsGuide, false, true, true, Color.Black)); //���i�K�C�h
            wkDic.Add(
                AdjustStockAcs.ctCOL_GoodsName,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsName, false, false, true, Color.Black)); // ���i����
            // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            wkDic.Add(
                AdjustStockAcs.ctCOL_GoodsMakerCd,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsMakerCd, false, false, true, Color.Black)); // ���[�J�[�R�[�h
            wkDic.Add(
                AdjustStockAcs.ctCOL_MakerName,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_MakerName, false, false, true, Color.Black)); // ���[�J�[����
            wkDic.Add(
                AdjustStockAcs.ctCOL_BLGoodsCode,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_BLGoodsCode, false, false, true, Color.Black)); // �a�k���i�R�[�h
            // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            wkDic.Add(
                AdjustStockAcs.ctCOL_WarehouseCode,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseCode, false, false, false, Color.Black));
            wkDic.Add(
                AdjustStockAcs.ctCOL_WarehouseName,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseName, false, false, true, Color.Black));
            // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_ProductNumber,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_ProductNumber, false, false, true, Color.Black));	// ����
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_BfProductNumber,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_BfProductNumber, false, false, false, Color.Black)); //�ύX�O����
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_StockTelNo1,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_StockTelNo1, false, false, true, Color.Black)); // �g�єԍ�
            wkDic.Add(
                AdjustStockAcs.ctCOL_WarehouseShelfNo,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseShelfNo, false, false, true, Color.Black)); //�I��
            wkDic.Add(
                AdjustStockAcs.ctCOL_BfWarehouseShelfNo,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_BfWarehouseShelfNo, false, false, false, Color.Black)); //�C���O�I��
            // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            wkDic.Add(
                AdjustStockAcs.ctCOL_SupplierStock,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_SupplierStock, false, false, true, Color.Black)); // �݌ɐ�
            wkDic.Add(
                AdjustStockAcs.ctCOL_TrustCount,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_TrustCount, false, false, true, Color.Black)); // �����
            wkDic.Add(
                AdjustStockAcs.ctCOL_AdjustCount,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_AdjustCount, false, false, true, Color.Black));	// ������
            // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_GoodsCodeStatus,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsCodeStatus, false, false, false, Color.Black)); // �݌ɏ��
            // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
            wkDic.Add(
                AdjustStockAcs.ctCOL_StockUnitPrice,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_StockUnitPrice, false, true, true, Color.Black)); // �d���P��
            wkDic.Add(
                AdjustStockAcs.ctCOL_AdjustPrice,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_AdjustPrice, false, false, true, Color.Black)); // �������z
            // 2008.01.17 �ǉ� >>>>>>>>>>>>>>>>>>>>
            wkDic.Add(
                AdjustStockAcs.ctCOL_DtlNote,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_DtlNote, false, true, true, Color.Black)); // ���ה��l
            // 2008.01.17 �ǉ� <<<<<<<<<<<<<<<<<<<<
            // 2008.02.15 �C�� >>>>>>>>>>>>>>>>>>>>
            wkDic.Add(
                AdjustStockAcs.ctCOL_ListPriceFl,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_ListPriceFl, false, false, false, Color.Black)); // �艿�i�����j
            // 2008.02.15 �C�� <<<<<<<<<<<<<<<<<<<<
            normalInputList.Add(ctKEY_Stock_PriceExc, wkDic);
            #endregion

            // 2007.10.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //--�I�ԕύX--// ���i�R�[�h�E���i�K�C�h�E�I��
            #region �I�ԕύX
            wkDic = new SlipDtlColumnStateList();
            wkDic.Add(
                AdjustStockAcs.ctCOL_RowNum,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_RowNum, false, false, true, Color.Black)); // No
            wkDic.Add(
                AdjustStockAcs.ctCOL_GoodsNo,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsNo, false, true, true, Color.Black)); // ���i�R�[�h
            wkDic.Add(
                AdjustStockAcs.ctCOL_GoodsGuide,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsGuide, false, true, true, Color.Black)); // ���i�K�C�h
            wkDic.Add(
                AdjustStockAcs.ctCOL_GoodsName,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsName, false, false, true, Color.Black)); // ���i����

            wkDic.Add(
                AdjustStockAcs.ctCOL_GoodsMakerCd,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsMakerCd, false, false, true, Color.Black)); // ���[�J�[�R�[�h
            wkDic.Add(
                AdjustStockAcs.ctCOL_MakerName,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_MakerName, false, false, true, Color.Black)); // ���[�J�[����
            wkDic.Add(
                AdjustStockAcs.ctCOL_BLGoodsCode,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_BLGoodsCode, false, false, true, Color.Black)); // �a�k���i�R�[�h

            wkDic.Add(
                AdjustStockAcs.ctCOL_WarehouseCode,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseCode, false, false, true, Color.Black)); //�q�ɃR�[�h
            wkDic.Add(
                AdjustStockAcs.ctCOL_WarehouseName,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseName, false, false, true, Color.Black)); //�q�ɖ���

            wkDic.Add(
                AdjustStockAcs.ctCOL_WarehouseShelfNo,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseShelfNo, false, true, true, Color.Black)); //�I��
            wkDic.Add(
                AdjustStockAcs.ctCOL_BfWarehouseShelfNo,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_BfWarehouseShelfNo, false, false, true, Color.Black)); //�C���O�I��

            wkDic.Add(
                AdjustStockAcs.ctCOL_SupplierStock,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_SupplierStock, false, false, true, Color.Black)); // �݌ɐ�
            wkDic.Add(
                AdjustStockAcs.ctCOL_TrustCount,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_TrustCount, false, false, true, Color.Black)); // �����
            wkDic.Add(
                AdjustStockAcs.ctCOL_AdjustCount,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_AdjustCount, false, false, true, Color.Black));	// ������
            wkDic.Add(
                AdjustStockAcs.ctCOL_StockUnitPrice,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_StockUnitPrice, false, false, true, Color.Black)); // �d���P��
            wkDic.Add(
                AdjustStockAcs.ctCOL_AdjustPrice,
                // 2008.02.15 �C�� >>>>>>>>>>>>>>>>>>>>
                //new AdjustStockColumnState(AdjustStockAcs.ctCOL_AdjustPrice, false, false, true, Color.Black));	// �������z
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_AdjustPrice, false, false, false, Color.Black));	// �������z
            // 2008.02.15 �C�� <<<<<<<<<<<<<<<<<<<<
            // 2008.01.17 �ǉ� >>>>>>>>>>>>>>>>>>>>
            wkDic.Add(
                AdjustStockAcs.ctCOL_DtlNote,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_DtlNote, false, true, true, Color.Black)); // ���ה��l
            // 2008.01.17 �ǉ� <<<<<<<<<<<<<<<<<<<<
            // 2008.02.15 �C�� >>>>>>>>>>>>>>>>>>>>
            wkDic.Add(
                AdjustStockAcs.ctCOL_ListPriceFl,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_ListPriceFl, false, false, false, Color.Black)); // �艿�i�����j
            // 2008.02.15 �C�� <<<<<<<<<<<<<<<<<<<<
            normalInputList.Add(ctKEY_ShelfNo, wkDic);
            #endregion
            // 2007.10.11 �ǉ� <<<<<<<<<<<<<<<<<<<<
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman�p�ɕύX

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// �ʏ���͗��ԃ��X�g�쐬����
		/// </summary>
        /// <remarks>
        /// <br>Note       : �ʏ���͗��ԃ��X�g���쐬���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private static void CreateNormalList()
        {
            _slipDtlColumnStateList = new SlipDtlColumnStateList();

            // No
            _slipDtlColumnStateList.Add(AdjustStockAcs.ctCOL_RowNum,
                                        new AdjustStockColumnState(AdjustStockAcs.ctCOL_RowNum, false, false, true, Color.Black)); 
            // �i��
            _slipDtlColumnStateList.Add(AdjustStockAcs.ctCOL_GoodsNo,
                                        new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsNo, false, true, true, Color.Black));
            // �i��
            _slipDtlColumnStateList.Add(AdjustStockAcs.ctCOL_GoodsName,
                                        new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsName, false, false, true, Color.Black));
            // BL�R�[�h
            _slipDtlColumnStateList.Add(AdjustStockAcs.ctCOL_BLGoodsCode,
                                        new AdjustStockColumnState(AdjustStockAcs.ctCOL_BLGoodsCode, false, false, true, Color.Black));
            // ���[�J�[
            _slipDtlColumnStateList.Add(AdjustStockAcs.ctCOL_GoodsMakerCd,
                                        new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsMakerCd, false, false, true, Color.Black));
            // �d����
            _slipDtlColumnStateList.Add(AdjustStockAcs.ctCOL_SupplierCd,
                                        new AdjustStockColumnState(AdjustStockAcs.ctCOL_SupplierCd, false, false, true, Color.Black));
            // �W�����i
            _slipDtlColumnStateList.Add(AdjustStockAcs.ctCOL_ListPriceFl,
                                        new AdjustStockColumnState(AdjustStockAcs.ctCOL_ListPriceFl, false, true, true, Color.Black));
            // ���P��
            _slipDtlColumnStateList.Add(AdjustStockAcs.ctCOL_StockUnitPrice,
                                        new AdjustStockColumnState(AdjustStockAcs.ctCOL_StockUnitPrice, false, true, true, Color.Black));
            // �d����
            _slipDtlColumnStateList.Add(AdjustStockAcs.ctCOL_SalesOrderUnit,
                                        new AdjustStockColumnState(AdjustStockAcs.ctCOL_SalesOrderUnit, false, true, true, Color.Black));
            // �d���㐔
            _slipDtlColumnStateList.Add(AdjustStockAcs.ctCOL_AfSalesOrderUnit,
                                        new AdjustStockColumnState(AdjustStockAcs.ctCOL_AfSalesOrderUnit, false, false, true, Color.Black));
            // �I��
            _slipDtlColumnStateList.Add(AdjustStockAcs.ctCOL_WarehouseShelfNo,
                                        new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseShelfNo, false, false, true, Color.Black));
            // �����c
            _slipDtlColumnStateList.Add(AdjustStockAcs.ctCOL_SalesOrderCount,
                                        new AdjustStockColumnState(AdjustStockAcs.ctCOL_SalesOrderCount, false, false, true, Color.Black));
            // �݌ɐ�
            _slipDtlColumnStateList.Add(AdjustStockAcs.ctCOL_SupplierStock,
                                        new AdjustStockColumnState(AdjustStockAcs.ctCOL_SupplierStock, false, false, true, Color.Black));
            // ���ה��l
            _slipDtlColumnStateList.Add(AdjustStockAcs.ctCOL_DtlNote,
                                        new AdjustStockColumnState(AdjustStockAcs.ctCOL_DtlNote, false, true, true, Color.Black));
            
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �݌ɃI�v�V�������͗��ԃ��X�g�쐬����
		/// </summary>
		private static void CreateStockOptionList()
		{
			// ������
            stockOptionInputList = new Dictionary<int, Dictionary<string, AdjustStockColumnState>>();
			SlipDtlColumnStateList wkDic;
            wkDic = new Dictionary<string, AdjustStockColumnState>();
			stockOptionInputList.Add((int)ConstantManagement_SF_AP.DetailKindCode.None, wkDic);
		}
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #endregion

        #region InnerClass
        /// <summary>
		/// �`�[���ח��ԃN���X
		/// </summary>
		public class AdjustStockColumnState
		{
			/// <summary>
			/// �J��������
			/// </summary>
			private string _columnName = null;
			/// <summary>
			/// �Q�Ə��
			/// </summary>
			private bool _readOnly = false;
			/// <summary>
			/// �L�����
			/// </summary>
			private bool _enable = false;
			/// <summary>
			/// �\�����
			/// </summary>
			private bool _visible = false;
			/// <summary>
			/// �����F
			/// </summary>
			private Color _foreColor;

			/// <summary>
			/// �`�[���ח��ԃN���X�̃R���X�g���N�^
			/// </summary>
			/// <param name="columnName">�J��������</param>
			/// <param name="readOnly">�ǎ��p���(true=�ǎ��p,false=�ʏ�)</param>
			/// <param name="enabled">�L���������(true=�L��,false=����)</param>
			/// <param name="visible">�\����\���ݒ�</param>
			/// <param name="foreColor">�����F</param>
            public AdjustStockColumnState(string columnName, bool readOnly, bool enabled, bool visible, Color foreColor)
			{
				this._columnName = columnName;
				this._readOnly = readOnly;
				this._enable = enabled;
				this._visible = visible;
				this._foreColor = foreColor;
			}
			/// <summary>
			/// �J�������̃v���p�e�B
			/// </summary>
			public string ColumnName
			{
				get { return this._columnName; }
			}
			/// <summary>
			/// �ǎ��p�v���p�e�B
			/// </summary>
			/// <value>true=�ǎ��p,false=�ʏ�</value>
			public bool ReadOnly
			{
				get { return this._readOnly; }
			}
			/// <summary>
			/// �L�������v���p�e�B
			/// </summary>
			/// <value>true=�L��,false=����</value>
			public bool Enabled
			{
				get { return this._enable; }
			}
			/// <summary>
			/// �\���v���p�e�B
			/// </summary>
			/// <value>true=�\����,false=�\���s��</value>
			public bool Visible
			{
				get { return this._visible; }
			}
			/// <summary>
			/// �����F�v���p�e�B
			/// </summary>
			public Color ForeColor
			{
				get { return this._foreColor; }
			}
		}
		#endregion
	}
}
