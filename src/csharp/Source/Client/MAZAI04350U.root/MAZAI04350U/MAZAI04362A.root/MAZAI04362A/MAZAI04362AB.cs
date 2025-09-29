//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �݌Ɏd������
// �v���O�����T�v   : �݌Ɏd�����̓A�N�Z�X�N���X�ł��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 19077 �n糋M�T
// �� �� ��  2007/03/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 980035 ���� ��`
// �C �� ��  2007/10/11  �C�����e : DC.NS�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 980035 ���� ��`
// �C �� ��  2008/03/28  �C�����e : �s��Ή��iDC.NS�Ή��j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30414 �E �K�j
// �C �� ��  2008/07/24  �C�����e : Partsman�p�ɕύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/06/03  �C�����e : �s��Ή�[13427]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �C �� ��  2009/11/16  �C�����e : �݌ɓo�^�@�\�̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��r��
// �C �� ��  2009/12/16  �C�����e : PM.NS-5
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�W�����i�A���P���A�d�����A�d���㐔��
//                                  �f�B�t�H���g�̉��C
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2010/12/20  �C�����e : ��Q���ǑΉ�x��
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�����܂������Ŕ�݌ɕi��I�������ꍇ�ɁA�i�Ԃ��\�����s���ɂȂ�s��̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/12/13  �C�����e : redmine#26816 �C���Ăяo�����ɂ͓���i�ԑI���E�B���h�E�͕\�����Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/12/16  �C�����e : redmine#26816 �C���Ăяo�����ɂ͓���i�ԑI���E�B���h�E�͕\�����Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : zhangy3
// �C �� ��  2013/01/04  �C�����e : 2013/03/13�z�M�� redmine#33845 �݌ɕi�d������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��ؑn
// �C �� ��  2021/10/12  �C�����e : PJMIT-1477 PM.NS �݌Ɏd�����͉�ʂɂĕi�Ԃ�ύX���Ă��o�^�ł��Ă��܂�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �݌ɒ����A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �݌ɒ����A�N�Z�X�N���X�ł��B</br>
	/// <br>Programmer : 19077 �n糋M�T</br>
	/// <br>Date       : 2007.03.26</br>
    /// <br>Update Note: 2007.10.11 980035 ���� ��`</br>
    /// <br>			 �EDC.NS�Ή�</br>
    /// <br>Update Note: 2008.03.28 980035 ���� ��`</br>
    /// <br>			 �E�s��Ή��iDC.NS�Ή��j</br>
    /// <br>Update Note: 2008/07/24 30414 �E �K�j</br>
    /// <br>             �EPartsman�p�ɕύX</br>
    /// <br>Update Note: 2009/06/03       �Ɠc �M�u</br>
    /// <br>             �E�s��Ή�[13427]</br>
    /// <br>Update Note: 2009/11/16       �H�� �b�D</br>
    /// <br>             �E�݌ɓo�^�@�\�̒ǉ�</br>
    /// <br>Update Note: 2010/12/20 ������</br>
    /// <br>               ��Q���ǑΉ�x��</br>
    /// <br>               �����܂������Ŕ�݌ɕi��I�������ꍇ�ɁA�i�Ԃ��\�����s���ɂȂ�s��̏C���B</br>
    /// <br>Update Note: 2011/12/13 ����</br>
    /// <br>               redmine#26816 �C���Ăяo�����ɂ͓���i�ԑI���E�B���h�E�͕\�����Ȃ�</br>
    /// <br>Update Note: 2013/01/04 zhangy3</br>
    /// <br>�Ǘ��ԍ�   : 10806793-00�@2013/03/13�z�M��</br>�@
    /// <br>           : Redmine#33845 �݌ɕi�d������</br>
    /// </remarks>
	public partial class AdjustStockAcs
	{
		#region �f���Q�[�g�ݒ�
        // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
        //// �f���Q�[�g�C�x���g
        //public static event GetStockSectionCodeEventHandler GetStockSectionCode; //���_
        //public static event GetDateEventHandler GetDate;       //���t
        //public static event GetStockPointWayEventHandler GetStockPointWay; //�݌ɕ]�����@
        //public static event GetEditModeEventHandler GetEditMode; //�ҏW���[�h
        //public static event GetFractionProcCdEventHandler GetFractionProcCd; //�[�������敪
        //public static event GetInputAgentEventHandler GetInputAgent;
        //public static event GetSubttlPriceEventHandler GetSubttlPrice;
        //public static event GetBlGoodsNameEventHandler GetBlGoodsName;
        
        ////�f���Q�[�g����
        //public delegate Employee GetInputAgentEventHandler();
        //public delegate string GetStockSectionCodeEventHandler();
        //public delegate DateTime GetDateEventHandler();
        //public delegate int GetStockPointWayEventHandler();
        //public delegate int GetEditModeEventHandler();
        //public delegate int GetFractionProcCdEventHandler();
        //public delegate Int64 GetSubttlPriceEventHandler();
        //public delegate string GetBlGoodsNameEventHandler(int blGoodsCode);

        // �f���Q�[�g�C�x���g
        public static event GetStockSectionCodeEventHandler GetStockSectionCode;    // �d�����_�R�[�h�擾
        public static event GetDateEventHandler GetDate;                            // �쐬���擾
        public static event GetInputAgentCodeEventHandler GetInputAgentCode;        // �S���҃R�[�h�擾
        public static event GetSubttlPriceEventHandler GetSubttlPrice;              // �d�����z�v�擾
        public static event GetSlipNoteEventHandler GetSlipNote;                    // �`�[���l�擾

        //�f���Q�[�g����
        public delegate string GetInputAgentCodeEventHandler();
        public delegate string GetStockSectionCodeEventHandler();
        public delegate DateTime GetDateEventHandler();
        public delegate Int64 GetSubttlPriceEventHandler();
        public delegate string GetSlipNoteEventHandler();
        // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<

        #endregion

        #region �p�u���b�N

        #region 2008.02.15 �폜
        // 2008.02.15 �폜 >>>>>>>>>>>>>>>>>>>>
        //public void StockToList(List<Stock> souceList)
        //{
        //    StockToDataList(souceList);
        //}
        // 2008.02.15 �폜 <<<<<<<<<<<<<<<<<<<<
        #endregion 2008.02.15 �폜

        #region DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        //public void StockToListGrs(List<StockEachWarehouse> souceList)
        public void StockToListGrs(List<StockExpansion> souceList)
        // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        {
            StockTodataListGrs(souceList);
        }
        
        /// <summary>
        /// �݌ɏ�ԃN���A
        /// </summary>
        public void StockDataClear()
        {
            _stockList.Clear();
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        /// <summary>
        /// �s�N���A
        /// </summary>
        public void ClrRowData(int targetRow)
        {
            ClrGridRow(targetRow);
        }

        // 2008.01.17 �ǉ� >>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �s�폜
        /// </summary>
        public void DelRowData(int targetRow)
        {
            DelGridRow(targetRow);
        }
        // 2008.01.17 �ǉ� <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region �v���C�x�[�g

        /// <summary>
        /// �s�N���A
        /// </summary>
        private void ClrGridRow(int targetRow)
        {
            for (int i = 0; i < _mainProductStock.Columns.Count; i++)
            {
                _mainProductStock.Rows[targetRow][i] = DBNull.Value;
            }
            _mainProductStock.Rows[targetRow][ctCOL_RowNum] = targetRow + 1;
        }

        // 2008.01.17 �ǉ� >>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �s�폜
        /// </summary>
        private void DelGridRow(int targetRow)
        {
            string msg;

            // �s�폜����
            ClrGridRow(targetRow);
            _mainProductStock.Rows[targetRow].Delete();

            // �s�ԍ��Đݒ�
            for (int i = targetRow; i < _mainProductStock.Rows.Count; i++)
            {
                _mainProductStock.Rows[i][ctCOL_RowNum] = i + 1;
            }

            // ��s�ǉ�
            CreateDummySlipDtl(out msg);
        }
        // 2008.01.17 �ǉ� <<<<<<<<<<<<<<<<<<<<

        #region 2008.03.28 �폜
        // 2008.03.28 �폜 >>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �d�����݃`�F�b�N
        /// </summary>
        //private static bool ChkExistStock(Stock chkTgt)
        //{
        //    bool result = false;

        //    if (_stockList == null)
        //    {
        //        return false;
        //    }

        //    ChkStock chkStock = new ChkStock();

        //    chkStock.EnterPriseCode = chkTgt.EnterpriseCode;
        //    chkStock.SectionCode = chkTgt.SectionCode;
        //    // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        //    //chkStock.MakerCode = chkTgt.MakerCode;
        //    //chkStock.GoodsCode = chkTgt.GoodsCode;
        //    chkStock.GoodsMakerCd = chkTgt.GoodsMakerCd;
        //    chkStock.GoodsNo = chkTgt.GoodsNo;
        //    // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<

        //    // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        //    //foreach (StockEachWarehouse chkStockTgt in _stockList)
        //    foreach (StockExpansion chkStockTgt in _stockList)
        //    // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        //    {
        //        if ((chkStockTgt.EnterpriseCode == chkStock.EnterPriseCode)
        //            && (chkStockTgt.SectionCode == chkStock.SectionCode)
        //            // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        //            //&& (chkStockTgt.MakerCode == chkStock.MakerCode)
        //            //&& (chkStockTgt.GoodsCode == chkStock.GoodsCode))
        //            && (chkStockTgt.GoodsMakerCd == chkStock.GoodsMakerCd)
        //            && (chkStockTgt.GoodsNo == chkStock.GoodsNo))
        //            // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        //        {
        //            result = true;
        //        }
        //    }
        //    return result;
        //}
        // 2008.03.28 �폜 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        //private static bool ChkExistStockGrs(StockEachWarehouse chkTgt)
        private static bool ChkExistStockGrs(StockExpansion chkTgt)
        // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        {
            bool result = false;
            if (_stockList == null)
            {
                return false;
            }
            ChkStock chkStock = new ChkStock();

            chkStock.EnterPriseCode = chkTgt.EnterpriseCode;
            chkStock.SectionCode = chkTgt.SectionCode;
            // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //chkStock.MakerCode = chkTgt.MakerCode;
            //chkStock.GoodsCode = chkTgt.GoodsCode;
            chkStock.GoodsMakerCd = chkTgt.GoodsMakerCd;
            chkStock.GoodsNo = chkTgt.GoodsNo;
            // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            // 2008.03.28 �ǉ� >>>>>>>>>>>>>>>>>>>>
            chkStock.WarehouseCode = chkStock.WarehouseCode;
            // 2008.03.28 �ǉ� <<<<<<<<<<<<<<<<<<<<

            // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //foreach (StockEachWarehouse chkStockTgt in _stockList)
            foreach (StockExpansion chkStockTgt in _stockList)
            // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            {
                // 2008.03.28 �C�� >>>>>>>>>>>>>>>>>>>>
                //if ((chkStockTgt.EnterpriseCode == chkStock.EnterPriseCode)
                //    && (chkStockTgt.SectionCode == chkStock.SectionCode)
                //    // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                //    //&& (chkStockTgt.MakerCode == chkStock.MakerCode)
                //    //&& (chkStockTgt.GoodsCode == chkStock.GoodsCode))
                //    && (chkStockTgt.GoodsMakerCd == chkStock.GoodsMakerCd)
                //    && (chkStockTgt.GoodsNo == chkStock.GoodsNo))
                //    // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                if ((chkStockTgt.EnterpriseCode   == chkStock.EnterPriseCode)
                    && (chkStockTgt.SectionCode   == chkStock.SectionCode)
                    && (chkStockTgt.GoodsMakerCd  == chkStock.GoodsMakerCd)
                    && (chkStockTgt.GoodsNo       == chkStock.GoodsNo)
                    && (chkStockTgt.WarehouseCode == chkStock.GoodsNo))
                // 2008.03.28 �C�� <<<<<<<<<<<<<<<<<<<<
                {
                    return true;
                }
            }
            return result;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #region 2008.02.15 �폜
        // 2008.02.15 �폜 >>>>>>>>>>>>>>>>>>>>
        //private static void StockToDataList(List<Stock> souceList)
        //{
        //    // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        //    //StockEachWarehouse stockEachWarehouse = new StockEachWarehouse();
        //    ////�d�����݃`�F�b�N
        //    //foreach (Stock stockRet in souceList)
        //    //{
        //    //    if (ChkExistStock(stockRet) != true)
        //    //    {
        //    //        stockEachWarehouse = StockToEachStock(stockRet);
        //    //        _stockList.Add(stockEachWarehouse);
        //    //    }
        //    //}
        //    StockExpansion stockExpansion = new StockExpansion();
        //    //�d�����݃`�F�b�N
        //    foreach (Stock stockRet in souceList)
        //    {
        //        if (ChkExistStock(stockRet) != true)
        //        {
        //            stockExpansion = StockToEachStock(stockRet);
        //            _stockList.Add(stockExpansion);
        //        }
        //    }
        //    // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        //}
        // 2008.02.15 �폜 <<<<<<<<<<<<<<<<<<<<
        #endregion 2008.02.15 �폜

        #region DEL 2008/07/24 Partsman�p�ɕύX
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        //private static void StockTodataListGrs(List<StockEachWarehouse> souceList)
        //{
        //    foreach (StockEachWarehouse stockEachWarehouseRet in souceList)
        //    {
        //        if (ChkExistStockGrs(stockEachWarehouseRet) != true)
        //        {
        //            _stockList.Add(stockEachWarehouseRet);
        //        }
        //    }
        //}
        //private static StockEachWarehouse StockToEachStock(Stock stock)
        //{
        //    StockEachWarehouse stockEachWarehouse = new StockEachWarehouse();
        //    stockEachWarehouse.AcpOdrCount = stock.AcpOdrCount;
        //    stockEachWarehouse.AllowStockCnt = stock.AllowStockCnt;
        //    stockEachWarehouse.CarrierCode = stock.CarrierCode;
        //    stockEachWarehouse.CarrierName = stock.CarrierName;
        //    stockEachWarehouse.CellphoneModelCode = stock.CellphoneModelCode;
        //    stockEachWarehouse.CellphoneModelName = stock.CellphoneModelName;
        //    stockEachWarehouse.CreateDateTime = stock.CreateDateTime;
        //    stockEachWarehouse.CreateDateTimeAdFormal = stock.CreateDateTimeAdFormal;
        //    stockEachWarehouse.CreateDateTimeAdInFormal = stock.CreateDateTimeAdInFormal;
        //    stockEachWarehouse.CreateDateTimeJpFormal = stock.CreateDateTimeJpFormal;
        //    stockEachWarehouse.CreateDateTimeJpInFormal = stock.CreateDateTimeJpInFormal;
        //    stockEachWarehouse.EnterpriseCode = stock.EnterpriseCode;
        //    stockEachWarehouse.EnterpriseName = stock.EnterpriseName;
        //    stockEachWarehouse.EntrustCnt = stock.EntrustCnt;
        //    stockEachWarehouse.FileHeaderGuid = stock.FileHeaderGuid;
        //    stockEachWarehouse.GoodsCode = stock.GoodsCode;
        //    stockEachWarehouse.GoodsName = stock.GoodsName;
        //    stockEachWarehouse.LargeGoodsGanreCode = stock.LargeGoodsGanreCode;
        //    stockEachWarehouse.LargeGoodsGanreName = stock.LargeGoodsGanreName;
        //    stockEachWarehouse.LastInventoryUpdate = stock.LastInventoryUpdate;
        //    stockEachWarehouse.LastInventoryUpdateAdFormal = stock.LastInventoryUpdateAdFormal;
        //    stockEachWarehouse.LastInventoryUpdateAdInFormal = stock.LastInventoryUpdateAdInFormal;
        //    stockEachWarehouse.LastInventoryUpdateJpFormal = stock.LastInventoryUpdateJpFormal;
        //    stockEachWarehouse.LastInventoryUpdateJpInFormal = stock.LastInventoryUpdateJpInFormal;
        //    stockEachWarehouse.LastSalesDate = stock.LastSalesDate;
        //    stockEachWarehouse.LastSalesDateAdFormal = stock.LastSalesDateAdFormal;
        //    stockEachWarehouse.LastSalesDateAdInFormal = stock.LastSalesDateAdInFormal;
        //    stockEachWarehouse.LastSalesDateJpFormal = stock.LastSalesDateJpFormal;
        //    stockEachWarehouse.LastSalesDateJpInFormal = stock.LastSalesDateJpInFormal;
        //    stockEachWarehouse.LastStockDate = stock.LastStockDate;
        //    stockEachWarehouse.LastStockDateAdFormal = stock.LastStockDateAdFormal;
        //    stockEachWarehouse.LastStockDateAdInFormal = stock.LastStockDateAdInFormal;
        //    stockEachWarehouse.LastStockDateJpFormal = stock.LastStockDateJpFormal;
        //    stockEachWarehouse.LastStockDateJpInFormal = stock.LastStockDateJpInFormal;
        //    stockEachWarehouse.LogicalDeleteCode = stock.LogicalDeleteCode;
        //    stockEachWarehouse.MakerCode = stock.MakerCode;
        //    stockEachWarehouse.MakerName = stock.MakerName;
        //    stockEachWarehouse.MaximumStockCnt = stock.MaximumStockCnt;
        //    stockEachWarehouse.MediumGoodsGanreCode = stock.MediumGoodsGanreCode;
        //    stockEachWarehouse.MediumGoodsGanreName = stock.MediumGoodsGanreName;
        //    stockEachWarehouse.MinimumStockCnt = stock.MinimumStockCnt;
        //    stockEachWarehouse.MovingSupliStock = stock.MovingSupliStock;
        //    stockEachWarehouse.MovingTrustStock = stock.MovingTrustStock;
        //    stockEachWarehouse.NmlSalOdrCount = stock.NmlSalOdrCount;
        //    stockEachWarehouse.PrdNumMngDiv = stock.PrdNumMngDiv;
        //    stockEachWarehouse.ReservedCount = stock.ReservedCount;
        //    stockEachWarehouse.SalesOrderCount = stock.SalesOrderCount;
        //    stockEachWarehouse.SalOdrLot = stock.SalOdrLot;
        //    stockEachWarehouse.SectionCode = stock.SectionCode;
        //    stockEachWarehouse.ShipmentPosCnt = stock.ShipmentPosCnt;
        //    stockEachWarehouse.SoldCnt = stock.SoldCnt;
        //    stockEachWarehouse.StockTotalPrice = stock.StockTotalPrice;
        //    stockEachWarehouse.StockUnitPrice = stock.StockUnitPrice;
        //    stockEachWarehouse.SupplierStock = stock.SupplierStock;
        //    stockEachWarehouse.SystematicColorCd = stock.SystematicColorCd;
        //    stockEachWarehouse.SystematicColorNm = stock.SystematicColorNm;
        //    stockEachWarehouse.TrustCount = stock.TrustCount;
        //    stockEachWarehouse.TrustEntrustCnt = stock.TrustEntrustCnt;
        //    stockEachWarehouse.UpdAssemblyId1 = stock.UpdAssemblyId1;
        //    stockEachWarehouse.UpdAssemblyId2 = stock.UpdAssemblyId2;
        //    stockEachWarehouse.UpdateDateTime = stock.UpdateDateTime;
        //    stockEachWarehouse.UpdateDateTimeAdFormal = stock.UpdateDateTimeAdFormal;
        //    stockEachWarehouse.UpdateDateTimeAdInFormal = stock.UpdateDateTimeAdInFormal;
        //    stockEachWarehouse.UpdateDateTimeJpFormal = stock.UpdateDateTimeJpFormal;
        //    stockEachWarehouse.UpdateDateTimeJpInFormal = stock.UpdateDateTimeJpInFormal;
        //    stockEachWarehouse.UpdEmployeeCode = stock.UpdEmployeeCode;
        //    stockEachWarehouse.UpdEmployeeName = stock.UpdEmployeeName;
        //    stockEachWarehouse.WarehouseCode = "";
        //    stockEachWarehouse.WarehouseName = "";
        //
        //    return stockEachWarehouse;
        //}
        private static void StockTodataListGrs(List<StockExpansion> souceList)
        {
            foreach (StockExpansion stockExpansionRet in souceList)
            {
                if (ChkExistStockGrs(stockExpansionRet) != true)
                {
                    _stockList.Add(stockExpansionRet);
                }
            }
        }
        private static StockExpansion StockToEachStock(Stock stock)
        {
            StockExpansion stockExpansion = new StockExpansion();
            stockExpansion.AcpOdrCount = stock.AcpOdrCount;
            stockExpansion.CreateDateTime = stock.CreateDateTime;
            stockExpansion.CreateDateTimeAdFormal = stock.CreateDateTimeAdFormal;
            stockExpansion.CreateDateTimeAdInFormal = stock.CreateDateTimeAdInFormal;
            stockExpansion.CreateDateTimeJpFormal = stock.CreateDateTimeJpFormal;
            stockExpansion.CreateDateTimeJpInFormal = stock.CreateDateTimeJpInFormal;
            stockExpansion.EnterpriseCode = stock.EnterpriseCode;
            stockExpansion.EnterpriseName = stock.EnterpriseName;
            stockExpansion.EntrustCnt = stock.EntrustCnt;
            stockExpansion.FileHeaderGuid = stock.FileHeaderGuid;
            stockExpansion.GoodsNo = stock.GoodsNo;
            stockExpansion.GoodsName = stock.GoodsName;
            stockExpansion.LastInventoryUpdate = stock.LastInventoryUpdate;
            stockExpansion.LastInventoryUpdateAdFormal = stock.LastInventoryUpdateAdFormal;
            stockExpansion.LastInventoryUpdateAdInFormal = stock.LastInventoryUpdateAdInFormal;
            stockExpansion.LastInventoryUpdateJpFormal = stock.LastInventoryUpdateJpFormal;
            stockExpansion.LastInventoryUpdateJpInFormal = stock.LastInventoryUpdateJpInFormal;
            stockExpansion.LastSalesDate = stock.LastSalesDate;
            stockExpansion.LastSalesDateAdFormal = stock.LastSalesDateAdFormal;
            stockExpansion.LastSalesDateAdInFormal = stock.LastSalesDateAdInFormal;
            stockExpansion.LastSalesDateJpFormal = stock.LastSalesDateJpFormal;
            stockExpansion.LastSalesDateJpInFormal = stock.LastSalesDateJpInFormal;
            stockExpansion.LastStockDate = stock.LastStockDate;
            stockExpansion.LastStockDateAdFormal = stock.LastStockDateAdFormal;
            stockExpansion.LastStockDateAdInFormal = stock.LastStockDateAdInFormal;
            stockExpansion.LastStockDateJpFormal = stock.LastStockDateJpFormal;
            stockExpansion.LastStockDateJpInFormal = stock.LastStockDateJpInFormal;
            stockExpansion.LogicalDeleteCode = stock.LogicalDeleteCode;
            stockExpansion.GoodsMakerCd = stock.GoodsMakerCd;
            stockExpansion.MakerName = stock.MakerName;
            stockExpansion.MaximumStockCnt = stock.MaximumStockCnt;
            stockExpansion.MinimumStockCnt = stock.MinimumStockCnt;
            stockExpansion.MovingSupliStock = stock.MovingSupliStock;
            stockExpansion.MovingTrustStock = stock.MovingTrustStock;
            stockExpansion.NmlSalOdrCount = stock.NmlSalOdrCount;
            stockExpansion.SalesOrderCount = stock.SalesOrderCount;
            stockExpansion.SalesOrderUnit = stock.SalesOrderUnit;
            stockExpansion.SectionCode = stock.SectionCode;
            stockExpansion.ShipmentPosCnt = stock.ShipmentPosCnt;
            stockExpansion.SoldCnt = stock.SoldCnt;
            stockExpansion.StockTotalPrice = stock.StockTotalPrice;
            stockExpansion.StockUnitPriceFl = stock.StockUnitPriceFl;
            stockExpansion.SupplierStock = stock.SupplierStock;
            stockExpansion.TrustCount = stock.TrustCount;
            stockExpansion.UpdAssemblyId1 = stock.UpdAssemblyId1;
            stockExpansion.UpdAssemblyId2 = stock.UpdAssemblyId2;
            stockExpansion.UpdateDateTime = stock.UpdateDateTime;
            stockExpansion.UpdateDateTimeAdFormal = stock.UpdateDateTimeAdFormal;
            stockExpansion.UpdateDateTimeAdInFormal = stock.UpdateDateTimeAdInFormal;
            stockExpansion.UpdateDateTimeJpFormal = stock.UpdateDateTimeJpFormal;
            stockExpansion.UpdateDateTimeJpInFormal = stock.UpdateDateTimeJpInFormal;
            stockExpansion.UpdEmployeeCode = stock.UpdEmployeeCode;
            stockExpansion.UpdEmployeeName = stock.UpdEmployeeName;
            stockExpansion.WarehouseCode = stock.WarehouseCode;
            stockExpansion.WarehouseName = stock.WarehouseName;
            stockExpansion.WarehouseShelfNo = stock.WarehouseShelfNo;

//            stockExpansion.LargeGoodsGanreCode = stock.LargeGoodsGanreCode;
//            stockExpansion.LargeGoodsGanreName = stock.LargeGoodsGanreName;
//            stockExpansion.MediumGoodsGanreCode = stock.MediumGoodsGanreCode;
//            stockExpansion.MediumGoodsGanreName = stock.MediumGoodsGanreName;
//            stockExpansion.DetailGoodsGanreCode = stock.DetailGoodsGanreCode;
//            stockExpansion.DetailGoodsGanreName = stock.DetailGoodsGanreName;
//            stockExpansion.BLGoodsCode = stock.BLGoodsCode;

            return stockExpansion;
        }
        // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman�p�ɕύX

        #endregion

        //--------------------------------------------------------
		//  �e��ϊ�����
		//--------------------------------------------------------
        #region 2007.10.11 �폜
        // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
        #region �݌ɒ����f�[�^�ϊ�����(UI�f�[�^��StaticTable)
        /*
        public void ProductStockToGrid(List<ProductStock> souceList)
        {
            ProductStockToDataTable(souceList);
        }                
        public void ProductStockToGrid(List<ProductStock> souceList,List<Stock> stockList, int insRow,int mode)
        {
            ProductStockToDataTable(souceList,stockList, insRow,mode);
        }
        public void ProductStockToGridGrs(List<ProductStock> souceList, List<StockEachWarehouse> stockList, int insRow, int mode)
        {
            ProductStockToDataTableGrs(souceList, stockList, insRow, mode);
        }
		/// <summary>
		/// �݌ɒ����f�[�^�ϊ�����(UI�f�[�^��StaticTable)
		/// </summary>
		/// <param name="souceList"></param>
		private static void ProductStockToDataTable(List<ProductStock> souceList)
		{
			// �ύX�C�x���g����
			DeactivateDtlChangeEventHandler();

			try
			{
				if (souceList != null)
				{                    
					// ���ԍ݌Ƀf�[�^���f�[�^�s���쐬����
					foreach (ProductStock wkDtl in souceList)
					{
						// DataRow��DataTable�֐ݒ肷��
						_mainProductStock.Rows.Add(ProductStockToDataRow(wkDtl));
					}
				}

				// �������׍s���̌���
				maxRowCnt = ctCOUNT_RowInit;
				while (maxRowCnt < _mainProductStock.Rows.Count)
				{
					maxRowCnt += ctCOUNT_RowAdd;
				}

				// ���׍ő�s���ɖ����Ȃ����𐶐�����
				string msg;
				CreateDummySlipDtl(out msg);
			}
			finally
			{
				// �ύX�C�x���g�L��
				ActivateDtlChangeEventHandler();
			}
		}

        /// <summary>
        /// DataTable�֔��f
        /// </summary>
        /// <param name="souceList"></param>
        /// <param name="stockList"></param>
        /// <param name="insRow"></param>
        /// <param name="mode"></param>
        private void ProductStockToDataTableGrs(List<ProductStock> souceList, List<StockEachWarehouse> stockList, int insRow, int mode)
        {
            DeactivateDtlChangeEventHandler();
            int lastRowNo = 0;
            try
            {
                if (souceList != null)
                {
                    DataRow newRow = null;
                    foreach (ProductStock wkDTL in souceList)
                    {
                        if (insRow >= 0)
                        {
                            newRow = _mainProductStock.Rows[insRow];
                        }
                        else if (insRow < 0 || (newRow[ctCOL_ProductNumber].ToString().Trim() == ""))
                        {
                            //�󔒍s�ɖ��ߍ��݂Ȃ̂ŁA�O���ɋ󔒍s������΋l�߂�B
                            for (int i = 0; i < _mainProductStock.Rows.Count; i++)
                            {

                                if ((_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] == DBNull.Value) ||
                                    ((Guid)_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] == Guid.Empty))
                                {
                                    newRow = _mainProductStock.Rows[i];
                                    lastRowNo++;
                                    break;
                                }
                            }
                        }

                        ProductStockChangeRowGrs(ref newRow, stockList, wkDTL, mode);
                        newRow.AcceptChanges();
                        if (lastRowNo == _mainProductStock.Rows.Count)
                        {
                            IncrementProductStock();
                        }
                    }
                }
            }
            finally
            {
                ActivateDtlChangeEventHandler();
            }
        }
        /// <summary>
        /// ���ԍ݌Ƀf�[�^�ϊ�����(1���u����)
        /// </summary>
        private void ProductStockToDataTable(List<ProductStock> souceList,List<Stock> stockList, int insRow,int mode)
        {
            DeactivateDtlChangeEventHandler();
            int lastRowNo = 0;
            try
            {

                if (souceList != null)
                {
                    DataRow newRow = null;
                    foreach (ProductStock wkDTL in souceList)
                    {
                        if (insRow >= 0)
                        {
                            newRow = _mainProductStock.Rows[insRow];
                        }
                        else if (insRow < 0 || (newRow[ctCOL_ProductNumber].ToString().Trim() == ""))
                        {
                            //�󔒍s�ɖ��ߍ��݂Ȃ̂ŁA�O���ɋ󔒍s������΋l�߂�B
                            for (int i = 0; i < _mainProductStock.Rows.Count; i++)
                            {

                                if ((_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] == DBNull.Value) ||
                                    ((Guid)_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] == Guid.Empty))
                                {
                                    newRow = _mainProductStock.Rows[i];
                                    lastRowNo++;
                                    break;
                                }
                            }
                        }

                        ProductStockChangeRow(ref newRow,stockList, wkDTL,mode);
                        newRow.AcceptChanges();
                        if (lastRowNo == _mainProductStock.Rows.Count)
                        {
                            IncrementProductStock();
                        }
                    }
                }
            }
            finally
            {
                ActivateDtlChangeEventHandler();
            }
        }
        /// <summary>
        /// Grid�X�V
        /// </summary>
        private void ProductStockChangeRow(ref DataRow newRow,List<Stock> stockList, ProductStock wkDTL,int mode)
        {
            newRow[ctCOL_CreateDateTime] = wkDTL.CreateDateTime;
            newRow[ctCOL_UpdateDateTime] = wkDTL.UpdateDateTime;
            newRow[ctCOL_EnterpriseCode] = wkDTL.EnterpriseCode;
            newRow[ctCOL_FileHeaderGuid] = wkDTL.FileHeaderGuid;
            newRow[ctCOL_UpdEmployeeCode] = wkDTL.UpdEmployeeCode;
            newRow[ctCOL_UpdAssemblyId1] = wkDTL.UpdAssemblyId1;
            newRow[ctCOL_UpdAssemblyId2] = wkDTL.UpdAssemblyId2;
            newRow[ctCOL_LogicalDeleteCode] = wkDTL.LogicalDeleteCode;
            newRow[ctCOL_SectionCode] = wkDTL.SectionCode;
            newRow[ctCOL_MakerCode] = wkDTL.MakerCode;
            newRow[ctCOL_GoodsCode] = wkDTL.GoodsCode;
            newRow[ctCOL_GoodsName] = wkDTL.GoodsName;
            newRow[ctCOL_ProductNumber] = wkDTL.ProductNumber.Trim();
            newRow[ctCOL_BfProductNumber] = wkDTL.ProductNumber;
            newRow[ctCOL_ProductStockGuid] = wkDTL.ProductStockGuid;
            newRow[ctCOL_WarehouseCode] = wkDTL.WarehouseCode;
            newRow[ctCOL_WarehouseName] = wkDTL.WarehouseName;
            newRow[ctCOL_StockDiv] = wkDTL.StockDiv;
            newRow[ctCOL_CarrierEpCode] = wkDTL.CarrierEpCode;
            newRow[ctCOL_CarrierEpName] = wkDTL.CarrierEpName;
            newRow[ctCOL_CustomerCode] = wkDTL.CustomerCode;
            newRow[ctCOL_CustomerName] = wkDTL.CustomerName;
            newRow[ctCOL_CustomerName2] = wkDTL.CustomerName2;
            newRow[ctCOL_StockDate] = wkDTL.StockDate;
            newRow[ctCOL_ArrivalGoodsDay] = wkDTL.ArrivalGoodsDay;

            int stockPointWay = GetStockPointWay();
            Int64 setPrice = 0;
            if ((stockPointWay == (int)ConstantManagement_Mobile.ct_StockPointWay.Average) ||
                (stockPointWay == (int)ConstantManagement_Mobile.ct_StockPointWay.Last))
            {
                //�ړ����ϖ@=>�݌Ƀ}�X�^�̎d���P�����S�̐ݒ�(�݌Ƀ}�X�^�Q��)
                Stock chkStock = new Stock();
                //�݌ɏ��ďo                
                string goodsCode = (string)newRow[ctCOL_GoodsCode];
                if (!String.IsNullOrEmpty(goodsCode))
                {
                    GetStockInf(out chkStock, goodsCode, (Int32)newRow[ctCOL_MakerCode], mode);
                    if (wkDTL.StockDiv != 1)
                    {
                        setPrice = chkStock.StockUnitPrice;
                        newRow[ctCOL_StockUnitPrice] = setPrice;
                    }
                    else
                    {
                        newRow[ctCOL_StockUnitPrice] = 0;
                    }
                }
            }
            else
            {
                if (wkDTL.StockDiv != 1)
                {
                    setPrice = wkDTL.StockUnitPrice;
                    newRow[ctCOL_StockUnitPrice] = setPrice;
                }
                else
                {
                    newRow[ctCOL_StockUnitPrice] = 0;
                }

            }

            newRow[ctCOL_BfStockUnitPrice] = setPrice;
            newRow[ctCOL_TaxationCode] = wkDTL.TaxationCode;
            newRow[ctCOL_StockState] = wkDTL.StockState;
            newRow[ctCOL_MoveStatus] = wkDTL.MoveStatus;
            newRow[ctCOL_GoodsCodeStatus] = wkDTL.GoodsCodeStatus;
            newRow[ctCOL_GoodsCodeStatus] = wkDTL.GoodsCodeStatus;
            newRow[ctCOL_StockTelNo1] = wkDTL.StockTelNo1.ToString().Trim();
            newRow[ctCOL_StockTelNo2] = wkDTL.StockTelNo2.ToString().Trim();
            newRow[ctCOL_RomDiv] = wkDTL.RomDiv;
            newRow[ctCOL_CellphoneModelCode] = wkDTL.CellphoneModelCode;
            newRow[ctCOL_CellphoneModelName] = wkDTL.CellphoneModelName;
            newRow[ctCOL_CarrierCode] = wkDTL.CarrierCode;
            newRow[ctCOL_CarrierName] = wkDTL.CarrierName;
            newRow[ctCOL_MakerName] = wkDTL.MakerName;
            newRow[ctCOL_SystematicColorCd] = wkDTL.SystematicColorCd;
            newRow[ctCOL_SystematicColorNm] = wkDTL.SystematicColorNm;
            newRow[ctCOL_LargeGoodsGanreCode] = wkDTL.LargeGoodsGanreCode;
            newRow[ctCOL_MediumGoodsGanreCode] = wkDTL.MediumGoodsGanreCode;
            newRow[ctCOL_ShipCustomerCode] = wkDTL.ShipCustomerCode;
            newRow[ctCOL_ShipCustomerName] = wkDTL.ShipCustomerName;
            newRow[ctCOL_ShipCustomerName2] = wkDTL.ShipCustomerName2;
            if (mode == ctMode_StockAdjust)
            {                
                newRow[ctCOL_AdjustCount] = -1;
                newRow[ctCOL_AdjustPrice] = setPrice * -1;                
            }
            else if (mode == ctMode_TrustAdjust)
            {
                newRow[ctCOL_AdjustCount] = -1;
                newRow[ctCOL_AdjustPrice] = setPrice * -1;                
            }
            else
            {
                if (wkDTL.StockDiv == 0)
                {
                    newRow[ctCOL_SupplierStock] = 1;
                }
                else if (wkDTL.StockDiv == 1)
                {
                    newRow[ctCOL_TrustCount] = 1;
                }
                newRow[ctCOL_AdjustCount] = 0;
            }

            if (mode == ctMode_StockAdjust)
            {
                newRow[ctCOL_SupplierStock] = 1; //���ԒP�ʂ͕K��1            
                newRow[ctCOL_TrustCount] = 0;
            }
            else if (mode == ctMode_TrustAdjust)
            {
                newRow[ctCOL_SupplierStock] = 0;
                newRow[ctCOL_TrustCount] = 1; //����݌�
            }

            //�@���ԊǗ��敪���Z�b�g
            foreach (Stock stock in stockList)
            {
                if ((stock.MakerCode == wkDTL.MakerCode) &&
                    (stock.GoodsCode == wkDTL.GoodsCode))
                {
                    newRow[ctCOL_PrdNumMngDiv] = stock.PrdNumMngDiv;
                    break;
                }                    
            }

            newRow[ctCOL_RowType] = 1; //���ԒP�ʂ͕K��1

        }

        private void ProductStockChangeRowGrs(ref DataRow newRow, List<StockEachWarehouse> stockList, ProductStock wkDTL, int mode)
        {
            newRow[ctCOL_CreateDateTime] = wkDTL.CreateDateTime;
            newRow[ctCOL_UpdateDateTime] = wkDTL.UpdateDateTime;
            newRow[ctCOL_EnterpriseCode] = wkDTL.EnterpriseCode;
            newRow[ctCOL_FileHeaderGuid] = wkDTL.FileHeaderGuid;
            newRow[ctCOL_UpdEmployeeCode] = wkDTL.UpdEmployeeCode;
            newRow[ctCOL_UpdAssemblyId1] = wkDTL.UpdAssemblyId1;
            newRow[ctCOL_UpdAssemblyId2] = wkDTL.UpdAssemblyId2;
            newRow[ctCOL_LogicalDeleteCode] = wkDTL.LogicalDeleteCode;
            newRow[ctCOL_SectionCode] = wkDTL.SectionCode;
            newRow[ctCOL_MakerCode] = wkDTL.MakerCode;
            newRow[ctCOL_GoodsCode] = wkDTL.GoodsCode;
            newRow[ctCOL_GoodsName] = wkDTL.GoodsName;
            newRow[ctCOL_ProductNumber] = wkDTL.ProductNumber.Trim();
            newRow[ctCOL_BfProductNumber] = wkDTL.ProductNumber;
            newRow[ctCOL_ProductStockGuid] = wkDTL.ProductStockGuid;
            newRow[ctCOL_WarehouseCode] = wkDTL.WarehouseCode;
            newRow[ctCOL_WarehouseName] = wkDTL.WarehouseName;
            newRow[ctCOL_StockDiv] = wkDTL.StockDiv;
            newRow[ctCOL_CarrierEpCode] = wkDTL.CarrierEpCode;
            newRow[ctCOL_CarrierEpName] = wkDTL.CarrierEpName;
            newRow[ctCOL_CustomerCode] = wkDTL.CustomerCode;
            newRow[ctCOL_CustomerName] = wkDTL.CustomerName;
            newRow[ctCOL_CustomerName2] = wkDTL.CustomerName2;
            newRow[ctCOL_StockDate] = wkDTL.StockDate;
            newRow[ctCOL_ArrivalGoodsDay] = wkDTL.ArrivalGoodsDay;

            int stockPointWay = GetStockPointWay();
            Int64 setPrice = 0;
            if ((stockPointWay == (int)ConstantManagement_Mobile.ct_StockPointWay.Average) ||
                (stockPointWay == (int)ConstantManagement_Mobile.ct_StockPointWay.Last))
            {
                //�ړ����ϖ@=>�݌Ƀ}�X�^�̎d���P�����S�̐ݒ�(�݌Ƀ}�X�^�Q��)
                Stock chkStock = new Stock();
                //�݌ɏ��ďo                
                string goodsCode = (string)newRow[ctCOL_GoodsCode];
                if (!String.IsNullOrEmpty(goodsCode))
                {
                    GetStockInf(out chkStock, goodsCode, (Int32)newRow[ctCOL_MakerCode], mode);
                    if (wkDTL.StockDiv != 1)
                    {
                        setPrice = chkStock.StockUnitPrice;
                        newRow[ctCOL_StockUnitPrice] = setPrice;
                    }
                    else
                    {
                        newRow[ctCOL_StockUnitPrice] = 0;
                    }
                }
            }
            else
            {
                if (wkDTL.StockDiv != 1)
                {
                    setPrice = wkDTL.StockUnitPrice;
                    newRow[ctCOL_StockUnitPrice] = setPrice;
                }
                else
                {
                    newRow[ctCOL_StockUnitPrice] = 0;
                }

            }

            newRow[ctCOL_BfStockUnitPrice] = setPrice;
            newRow[ctCOL_TaxationCode] = wkDTL.TaxationCode;
            newRow[ctCOL_StockState] = wkDTL.StockState;
            newRow[ctCOL_MoveStatus] = wkDTL.MoveStatus;
            newRow[ctCOL_GoodsCodeStatus] = wkDTL.GoodsCodeStatus;
            newRow[ctCOL_GoodsCodeStatus] = wkDTL.GoodsCodeStatus;
            newRow[ctCOL_StockTelNo1] = wkDTL.StockTelNo1.ToString().Trim();
            newRow[ctCOL_StockTelNo2] = wkDTL.StockTelNo2.ToString().Trim();
            newRow[ctCOL_RomDiv] = wkDTL.RomDiv;
            newRow[ctCOL_CellphoneModelCode] = wkDTL.CellphoneModelCode;
            newRow[ctCOL_CellphoneModelName] = wkDTL.CellphoneModelName;
            newRow[ctCOL_CarrierCode] = wkDTL.CarrierCode;
            newRow[ctCOL_CarrierName] = wkDTL.CarrierName;
            newRow[ctCOL_MakerName] = wkDTL.MakerName;
            newRow[ctCOL_SystematicColorCd] = wkDTL.SystematicColorCd;
            newRow[ctCOL_SystematicColorNm] = wkDTL.SystematicColorNm;
            newRow[ctCOL_LargeGoodsGanreCode] = wkDTL.LargeGoodsGanreCode;
            newRow[ctCOL_MediumGoodsGanreCode] = wkDTL.MediumGoodsGanreCode;
            newRow[ctCOL_ShipCustomerCode] = wkDTL.ShipCustomerCode;
            newRow[ctCOL_ShipCustomerName] = wkDTL.ShipCustomerName;
            newRow[ctCOL_ShipCustomerName2] = wkDTL.ShipCustomerName2;
            if (mode == ctMode_StockAdjust)
            {
                newRow[ctCOL_AdjustCount] = -1;
                newRow[ctCOL_AdjustPrice] = setPrice * -1;
            }
            else if (mode == ctMode_TrustAdjust)
            {
                newRow[ctCOL_AdjustCount] = -1;
                newRow[ctCOL_AdjustPrice] = setPrice * -1;
            }
            else
            {
                if (wkDTL.StockDiv == 0)
                {
                    newRow[ctCOL_SupplierStock] = 1;
                }
                else if (wkDTL.StockDiv == 1)
                {
                    newRow[ctCOL_TrustCount] = 1;
                }
                newRow[ctCOL_AdjustCount] = 0;
            }

            if (mode == ctMode_StockAdjust)
            {
                newRow[ctCOL_SupplierStock] = 1; //���ԒP�ʂ͕K��1            
                newRow[ctCOL_TrustCount] = 0;
            }
            else if (mode == ctMode_TrustAdjust)
            {
                newRow[ctCOL_SupplierStock] = 0;
                newRow[ctCOL_TrustCount] = 1; //����݌�
            }

            //�@���ԊǗ��敪���Z�b�g
            foreach (StockEachWarehouse stock in stockList)
            {
                if ((stock.MakerCode == wkDTL.MakerCode) &&
                    (stock.GoodsCode == wkDTL.GoodsCode))
                {
                    newRow[ctCOL_PrdNumMngDiv] = stock.PrdNumMngDiv;
                    break;
                }
            }

            newRow[ctCOL_RowType] = 1; //���ԒP�ʂ͕K��1

        }
        */
        // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
        #endregion
        #endregion

        #region DEL 2008/07/24 Partsman�p�ɕύX
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ����CELL�̒��g��ύX
        /// </summary>
        /// <param name="cellname"></param>
        /// <param name="RowNo"></param>
        /// <param name="setCount"></param>
        public void ProductStockChangeCell(string cellname, int RowNo,double setCount)
        {
            ProductStockChangeAtCell(cellname, RowNo,setCount);
        }
        private void ProductStockChangeAtCell(string cellname, int RowNo,double setCount)
        {
            DataRow nowRow = _mainProductStock.Rows[RowNo];
            nowRow[cellname] = setCount;

            
            ProductStockCalcTotal(RowNo);
        }
        
        /// <summary>
        /// ���v���z�v�Z
        /// </summary>
        /// <param name="RowNo"></param>
        private void ProductStockCalcTotal(int RowNo)
        {            
            DataRow targetRow = _mainProductStock.Rows[RowNo];
            // 2008.01.17 �C�� >>>>>>>>>>>>>>>>>>>>
            //double setPrice = (double)targetRow[ctCOL_AdjustCount]
            //                * (Int64)targetRow[ctCOL_StockUnitPrice];
            double setPrice = (double)targetRow[ctCOL_AdjustCount]
                            * (double)targetRow[ctCOL_StockUnitPrice];
            // 2008.01.17 �C�� <<<<<<<<<<<<<<<<<<<<
            targetRow[ctCOL_AdjustPrice] = setPrice;
        }
        public Int64 ProductStockChangeTotalPrice()
        {
            Int64 totalPrice = 0;
            DataRow targetRow = null;
            for (int i = 0; i < _mainProductStock.Rows.Count; i++)
            {                
                targetRow = _mainProductStock.Rows[i];

                if (targetRow[ctCOL_AdjustPrice] == System.DBNull.Value)
                {
                    continue;
                }
                if (targetRow[ctCOL_AdjustPrice].ToString().Trim() == "")
                {
                    continue;
                }
                totalPrice = totalPrice + (Int64)targetRow[ctCOL_AdjustPrice];                    

            }
            return totalPrice;
        }
        /// <summary>
        /// ���v���v�Z
        /// </summary>
        /// <returns></returns>
        public double ProductStockChangeTotalCount()
        {
            double totalCount = 0;
            DataRow targetRow = null;
            for (int i = 0; i < _mainProductStock.Rows.Count; i++)
            {
                targetRow = _mainProductStock.Rows[i];

                if ((targetRow[ctCOL_AdjustCount] != null) && (targetRow[ctCOL_AdjustCount].ToString().Trim() != ""))
                {
                    string a1 = targetRow[ctCOL_AdjustCount].ToString();
                    totalCount = totalCount + (double)targetRow[ctCOL_AdjustCount];
                }
            }
            return totalCount;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman�p�ɕύX

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        public void ReadStockMngTtlSt()
        {
            ArrayList retList;

            int statusMngTtlSt = _stockMngTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            if (statusMngTtlSt == 0)
            {
                foreach (StockMngTtlSt stockMngTtlSt in retList)
                {
                    if ((stockMngTtlSt.LogicalDeleteCode == 0) && (stockMngTtlSt.SectionCode.Trim() == "00"))
                    {
                        _stockMngTtlSt = stockMngTtlSt;
                        break;
                    }
                }
            }
            else
            {
                _stockMngTtlSt = new StockMngTtlSt();
            }
        }

        public bool CheckSameGoodsUnitData(int makerCode, string goodsNo)
        {
            for (int i = 0; i < _mainProductStock.Rows.Count; i++)
            {
                if (_mainProductStock.Rows[i][ctCOL_GoodsMakerCd] == DBNull.Value)
                {
                    continue;
                }
                if (_mainProductStock.Rows[i][ctCOL_GoodsMakerCd].ToString().Trim() == "")
                {
                    continue;
                }
                if (_mainProductStock.Rows[i][ctCOL_GoodsNo] == DBNull.Value)
                {
                    continue;
                }
                if (_mainProductStock.Rows[i][ctCOL_GoodsNo].ToString().Trim() == "")
                {
                    continue;
                }

                int colMakerCd = int.Parse((string)_mainProductStock.Rows[i][ctCOL_GoodsMakerCd]);
                string colGoodsNo = (string)_mainProductStock.Rows[i][ctCOL_GoodsNo];

                if ((colMakerCd == makerCode) && (colGoodsNo == goodsNo))
                {
                    return (true);
                }
            }

            return (false);
        }

        /// <summary>
        /// ���v���z�擾����
        /// </summary>
        /// <returns>���v���z</returns>
        /// <remarks>
        /// <br>Note       : ���v���z���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public Int64 GetTotalPrice()
        {
            Int64 totalPrice = 0;
            double dblTotalPrice = 0;

            // (�P���~�d����)�̍��v�����߂܂�
            for (int i = 0; i < _mainProductStock.Rows.Count; i++)
            {
                if (_mainProductStock.Rows[i][ctCOL_StockUnitPrice] == DBNull.Value)
                {
                    continue;
                }
                if (_mainProductStock.Rows[i][ctCOL_StockUnitPrice].ToString().Trim() == "")
                {
                    continue;
                }
                if (_mainProductStock.Rows[i][ctCOL_SalesOrderUnit] == DBNull.Value)
                {
                    continue;
                }
                if (_mainProductStock.Rows[i][ctCOL_SalesOrderUnit].ToString().Trim() == "")
                {
                    continue;
                }

                dblTotalPrice = (double)_mainProductStock.Rows[i][ctCOL_StockUnitPrice] * 
                                (double)_mainProductStock.Rows[i][ctCOL_SalesOrderUnit];

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

                //totalPrice += (Int64)((double)_mainProductStock.Rows[i][ctCOL_StockUnitPrice] * 
                //               (double)_mainProductStock.Rows[i][ctCOL_SalesOrderUnit]);
            }

            return totalPrice;
        }

        public Int64 GetTotalStockPriceTaxExc()
        {
            double dblTotalPrice = 0;

            // (�P���~�d����)�̍��v�����߂܂�
            for (int i = 0; i < _mainProductStock.Rows.Count; i++)
            {
                if (_mainProductStock.Rows[i][ctCOL_StockPriceTaxExc] == DBNull.Value)
                {
                    continue;
                }
                if (_mainProductStock.Rows[i][ctCOL_StockPriceTaxExc].ToString().Trim() == "")
                {
                    continue;
                }

                dblTotalPrice += (long)_mainProductStock.Rows[i][ctCOL_StockPriceTaxExc];
            }

            return (Int64)dblTotalPrice;
        }

        public Int64 GetStockPriceTaxExc(double stockUnitPrice, double salesOrderUnit)
        {
            Int64 totalPrice = 0;
            double dblTotalPrice = 0;

            dblTotalPrice = stockUnitPrice * salesOrderUnit;

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

            return totalPrice;

        }

        /// <summary>
        /// ���v���擾����
        /// </summary>
        /// <returns>���v��</returns>
        /// <remarks>
        /// <br>Note       : ���v�����擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public double GetTotalCount()
        {
            double totalCount = 0;

            // �d�����̍��v�����߂܂�
            for (int i = 0; i < _mainProductStock.Rows.Count; i++)
            {
                if (_mainProductStock.Rows[i][ctCOL_SalesOrderUnit] == DBNull.Value)
                {
                    continue;
                }
                if (_mainProductStock.Rows[i][ctCOL_SalesOrderUnit].ToString().Trim() == "")
                {
                    continue;
                }

                totalCount += (double)_mainProductStock.Rows[i][ctCOL_SalesOrderUnit];
            }

            return totalCount;
        }

        /// <summary>
        /// ���i�A���f�[�^�O���b�h�\������
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="insertRowIndex">�s�C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���i�A���f�[�^���O���b�h�֔��f���܂��B(�O���b�h�ŕi�ԓ��͌�Ɏg�p���܂�)</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// <br>Update Note: 2010/12/20 ������</br>
        /// <br>               ��Q���ǑΉ�x��</br>
        /// <br>               �����܂������Ŕ�݌ɕi��I�������ꍇ�ɁA�i�Ԃ��\�����s���ɂȂ�s��̏C���B</br>
        /// <br>Update Note: 2013/01/04 zhangy3</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00�@2013/03/13�z�M��</br>�@
        /// <br>           : Redmine#33845 �݌ɕi�d������</br>
        /// <br>Update Note: 2021/10/12 ��ؑn</br>
        /// <br>           : PJMIT-1477 PM.NS �݌Ɏd�����͉�ʂɂĕi�Ԃ�ύX���Ă��o�^�ł��Ă��܂�</br>
        /// </remarks>
        public int GoodsUnitDataToGrid(GoodsUnitData goodsUnitData, string warehouseCode, string sectionCode, int insertRowIndex)
        {
            // ���׏��(MainStaticMemory)�ύX�C�x���g�n���h��������
            DeactivateDtlChangeEventHandler();

            try
            {
                bool stockFlg = false;

                Stock stock = new Stock();

                // DEL 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ---------->>>>>
                //if (goodsUnitData.StockList != null)
                // DEL 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ----------<<<<<
                if (goodsUnitData.StockList != null && goodsUnitData.StockList.Count > 0)   // ADD 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ�
                {
                    // �݌Ƀ��X�g�̒�����q�ɃR�[�h����v������̂��擾
                    foreach (Stock stockwk in goodsUnitData.StockList)
                    {
                        //if ((stockwk.WarehouseCode.Trim().PadLeft(4, '0') == warehouseCode.Trim().PadLeft(4, '0')) &&
                        //    (stockwk.SectionCode.Trim().PadLeft(2, '0') == sectionCode.Trim().PadLeft(2, '0')))
                        // 2010/07/14 >>>
                        //if (stockwk.WarehouseCode.Trim().PadLeft(4, '0') == warehouseCode.Trim().PadLeft(4, '0'))
                        if (stockwk.WarehouseCode.Trim().PadLeft(4, '0') == warehouseCode.Trim().PadLeft(4, '0') &&
                            stockwk.LogicalDeleteCode == 0)
                        // 2010/07/14 <<<
                        {
                            stock = stockwk;
                            stockFlg = true;
                            break;
                        }
                    }
                    // --- Add Start zhangy3 2013/01/04 For Redmine#33845 ----->>>>>
                    if (goodsUnitData.OfferKubun == 4)
                    {
                        stockFlg = true;
                    }
                    // --- Add End   zhangy3 2013/01/04 For Redmine#33845 -----<<<<<
                    // �݌ɏ��i�̑q�ɂ��s��v
                    if (!stockFlg)
                    {
                        // DEL 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ---------->>>>>
                        // return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        // DEL 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ----------<<<<<
                        // 2010/07/14 Add >>>
                        DataRow newRowWk = _mainProductStock.Rows[insertRowIndex];

                        // ���[�J�[�R�[�h
                        if (goodsUnitData.GoodsMakerCd == 0)
                        {
                            newRowWk[ctCOL_GoodsMakerCd] = "";
                        }
                        else
                        {
                            newRowWk[ctCOL_GoodsMakerCd] = goodsUnitData.GoodsMakerCd.ToString("0000");
                        }
                        newRowWk[ctCOL_GoodsNo] = goodsUnitData.GoodsNo;�@// ADD 2010/12/20
                        // 2010/07/14 Add <<<
                        return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;    // ADD 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ�
                    }
                }
                // ADD 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ---------->>>>>
                // MEMO:���i�͑��݂��邪�A�݌ɂ��Ȃ��ꍇ
                else
                {
                    // ADD 2021/10/12 ----------------------->>>>>
                    //�O�ɓ��͂����f�[�^���c���Ă���ꍇ�A�\�����s���ɂȂ邽�߁A��x�s�����폜
                    ClrRowData(insertRowIndex);
                    // ADD 2021/10/12 -----------------------<<<<<

                    // --- ADD m.suzuki 2010/01/14 ---------->>>>>
                    DataRow newRowWk = _mainProductStock.Rows[insertRowIndex];

                    // ���[�J�[�R�[�h
                    if ( goodsUnitData.GoodsMakerCd == 0 )
                    {
                        newRowWk[ctCOL_GoodsMakerCd] = "";
                    }
                    else
                    {
                        newRowWk[ctCOL_GoodsMakerCd] = goodsUnitData.GoodsMakerCd.ToString( "0000" );
                    }
                    // --- ADD m.suzuki 2010/01/14 ----------<<<<<

                    newRowWk[ctCOL_GoodsNo] = goodsUnitData.GoodsNo;�@// ADD 2010/12/20

                    stockFlg = false;
                    return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }
                // ADD 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ----------<<<<<

                DataRow newRow = _mainProductStock.Rows[insertRowIndex];

                // �݌ɏ�񔽉f
                stock.SalesOrderUnit = 1;   // �d�����̏����l��1�ɐݒ�
                StockChangeRowGrs(ref newRow, stock, goodsUnitData);
            }
            finally
            {
                // ���׏��(MainStaticMemory)�ύX�C�x���g�n���h���L����
                ActivateDtlChangeEventHandler();
            }

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        /// �݌Ƀ��X�g�O���b�h�\������
        /// </summary>
        /// <param name="stockList">�݌Ƀ��X�g</param>
        /// <remarks>
        /// <br>Note       : �݌Ƀ��X�g���O���b�h�֔��f���܂��B(�݌Ɍ�����Ɏg�p���܂�)</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public void StockListToGrid(List<Stock> stockList)
        {
            // ���׏��(MainStaticMemory)�ύX�C�x���g�n���h��������
            DeactivateDtlChangeEventHandler();

            try
            {
                if ((stockList == null) || (stockList.Count == 0))
                {
                    return;
                }

                // �݌Ƀ}�X�^���X�g�ɑΉ����鏤�i�A���f�[�^���X�g���擾
                List<GoodsUnitData> goodsUnitDataList = GetGoodsUnitDataList(stockList);

                List<int> deleteIndex = new List<int>();

                // ���ɓ��͍ς݂̃f�[�^��ޔ����܂�
                List<object[]> dataRowList = new List<object[]>();
                for (int index = 0; index < _mainProductStock.Rows.Count; index++)
                {
                    if ((_mainProductStock.Rows[index][ctCOL_GoodsNo] != DBNull.Value) &&
                        (((String)_mainProductStock.Rows[index][ctCOL_GoodsNo]).Trim() != ""))
                    {
                        dataRowList.Add(_mainProductStock.Rows[index].ItemArray);

                        // �폜�Ώۍs�C���f�b�N�X�擾
                        deleteIndex.Add(index);
                    }
                }

                for (int index = deleteIndex.Count - 1; index >= 0; index--)
                {
                    // �Ώۍs�폜
                    DelGridRow(deleteIndex[index]);
                }

                // �ޔ������f�[�^���O���b�h�ɔ��f���܂�
                for (int index = 0; index < dataRowList.Count; index++)
                {
                    _mainProductStock.Rows[index].ItemArray = dataRowList[index];
                    _mainProductStock.Rows[index][ctCOL_RowNum] = index + 1;
                }

                // �f�[�^�̑}���J�n�C���f�b�N�X���擾
                int insertIndex = 0;
                for (int index = 0; index < _mainProductStock.Rows.Count; index++)
                {
                    if ((_mainProductStock.Rows[index][ctCOL_GoodsNo] == DBNull.Value) ||
                        (((String)_mainProductStock.Rows[index][ctCOL_GoodsNo]).Trim() == ""))
                    {
                        insertIndex = index;
                        break;
                    }
                }

                Stock stock = new Stock();
                DataRow newRow = null;
                for (int index = 0; index < stockList.Count; index++)
                {
                    stock = stockList[index];
                    newRow = _mainProductStock.Rows[insertIndex];

                    // �݌ɏ�񔽉f
                    StockChangeRowGrs(ref newRow, stock, goodsUnitDataList[index]);

                    if (insertIndex >= _mainProductStock.Rows.Count - 1)
                    {
                        // ���׍s������
                        IncrementProductStock();
                    }

                    insertIndex++;
                }
            }
            finally
            {
                // ���׏��(MainStaticMemory)�ύX�C�x���g�n���h���L����
                ActivateDtlChangeEventHandler();
            }
        }

        /// <summary>
        /// �݌ɒ����`�[�O���b�h�\������
        /// </summary>
        /// <param name="stockAdjust">�݌ɒ����f�[�^</param>
        /// <param name="stockAdjustDtlList">�݌ɒ������׃f�[�^���X�g</param>
        /// <param name="flag">�`�[�ԍ��Ō������邩�ǂ����𔻒f����p�̃t���O</param>
        /// <remarks>
        /// <br>Note       : �݌ɒ����`�[���O���b�h�֔��f���܂��B(�݌Ɏd���`�[������Ɏg�p���܂�)</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public void StockAdjustDtlListToGrid(StockAdjust stockAdjust, List<StockAdjustDtl> stockAdjustDtlList, params bool[] flag)//add 2011/12/13 ���� Redmine #26816
        //public void StockAdjustDtlListToGrid(StockAdjust stockAdjust, List<StockAdjustDtl> stockAdjustDtlList)//del 2011/12/13 ���� Redmine #26816
        {
            // ���׏��(MainStaticMemory)�ύX�C�x���g�n���h��������
            DeactivateDtlChangeEventHandler();

            try
            {
                for (int index = 0; index < _mainProductStock.Rows.Count; index++)
                {
                    // �s�N���A
                    ClrGridRow(index);
                }

                if ((stockAdjustDtlList == null) || (stockAdjustDtlList.Count == 0))
                {
                    return;
                }

                // �݌ɒ������׃f�[�^���X�g�ɑΉ�����݌Ƀ}�X�^���X�g���擾
                List<Stock> stockList = GetStockList(stockAdjust, stockAdjustDtlList);

                // �݌Ƀ}�X�^���X�g�ɑΉ����鏤�i�A���f�[�^���X�g���擾
                List<GoodsUnitData> goodsUnitDataList = GetGoodsUnitDataList(stockList, flag);//add 2011/12/13 ���� Redmine #26816
                //List<GoodsUnitData> goodsUnitDataList = GetGoodsUnitDataList(stockList);//del 2011/12/13 ���� Redmine #26816

                DataRow newRow = null;
                for (int index = 0; index < stockList.Count; index++)
                {
                    newRow = _mainProductStock.Rows[index];

                    // ---ADD 2009/06/03 �s��Ή�[13427] ----------->>>>>
                    //���L���ڂɊւ��Ă͍݌ɒ����f�[�^����\��
                    goodsUnitDataList[index].GoodsNo = stockAdjustDtlList[index].GoodsNo;               //�i��
                    goodsUnitDataList[index].GoodsName = stockAdjustDtlList[index].GoodsName;           //�i��
                    goodsUnitDataList[index].BLGoodsCode = stockAdjustDtlList[index].BLGoodsCode;       //�a�k�R�[�h
                    goodsUnitDataList[index].GoodsMakerCd = stockAdjustDtlList[index].GoodsMakerCd;     //���[�J�[�R�[�h
                    goodsUnitDataList[index].SupplierCd = stockAdjustDtlList[index].SupplierCd;         //�d����R�[�h
                    goodsUnitDataList[index].SupplierSnm = stockAdjustDtlList[index].SupplierSnm;       //�d���於��
                    stockList[index].WarehouseShelfNo = stockAdjustDtlList[index].WarehouseShelfNo;     //�I��
                    // ---ADD 2009/06/03 �s��Ή�[13427] -----------<<<<<

                    // �݌ɏ�񔽉f
                    StockChangeRowGrs(ref newRow, stockList[index], stockAdjust, stockAdjustDtlList[index],  goodsUnitDataList[index]);

                    if (index >= _mainProductStock.Rows.Count - 1)
                    {
                        // ���׍s������
                        IncrementProductStock();
                    }
                }

                // �Ώۍs�ȊO�폜
                for (int index = _mainProductStock.Rows.Count - 1; index >= stockList.Count; index--)
                {
                    _mainProductStock.Rows[index].Delete();
                }
            }
            finally
            {
                // ���׏��(MainStaticMemory)�ύX�C�x���g�n���h���L����
                ActivateDtlChangeEventHandler();
            }
        }

        /// <summary>
        /// �����c�Ɖ���[�g���o���ʃO���b�h�\������
        /// </summary>
        /// <param name="orderListResultWorkList">�����c�Ɖ���[�g���o���ʃ��X�g</param>
        /// <remarks>
        /// <br>Note       : �����c�Ɖ���[�g���o���ʂ��O���b�h�֔��f���܂��B(�����c�Ɖ����Ɏg�p���܂�)</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public void OrderListResultWorkToGrid(List<OrderListResultWork> orderListResultWorkList)
        {
            // ���׏��(MainStaticMemory)�ύX�C�x���g�n���h��������
            DeactivateDtlChangeEventHandler();

            try
            {
                for (int index = 0; index < _mainProductStock.Rows.Count; index++)
                {
                    // �s�N���A
                    ClrGridRow(index);
                }

                if ((orderListResultWorkList == null) || (orderListResultWorkList.Count == 0))
                {
                    return;
                }

                // �����c�Ɖ���[�g���o���ʃ��X�g�ɑΉ�����݌Ƀ}�X�^���X�g���擾
                List<Stock> stockList = GetStockList(orderListResultWorkList);

                // �݌Ƀ}�X�^���X�g�ɑΉ����鏤�i�A���f�[�^���X�g���擾
                List<GoodsUnitData> goodsUnitDataList = GetGoodsUnitDataList(stockList, true);//add 2011/12/16 ���� Redmine #26816
                //List<GoodsUnitData> goodsUnitDataList = GetGoodsUnitDataList(stockList);//del 2011/12/16 ���� Redmine #26816
                DataRow newRow = null;
                for (int index = 0; index < stockList.Count; index++)
                {
                    newRow = _mainProductStock.Rows[index];

                    // �݌ɏ�񔽉f
                    StockChangeRowGrs(ref newRow, stockList[index], goodsUnitDataList[index], orderListResultWorkList[index]);

                    if (index >= _mainProductStock.Rows.Count - 1)
                    {
                        // ���׍s������
                        IncrementProductStock();
                    }
                }

                // �Ώۍs�ȊO�폜
                for (int index = _mainProductStock.Rows.Count - 1; index >= stockList.Count; index--)
                {
                    _mainProductStock.Rows[index].Delete();
                }
            }
            finally
            {
                // ���׏��(MainStaticMemory)�ύX�C�x���g�n���h���L����
                ActivateDtlChangeEventHandler();
            }
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/24 Partsman�p�ɕύX
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// DataTable�֔��f
        /// </summary>
        /// <param name="souceList"></param>
        /// <param name="insRow"></param>
        // 2008.02.15 �폜 >>>>>>>>>>>>>>>>>>>>
        #region 2008.02.15 �폜
        //public void StockToGrid(List<Stock> souceList,int insRow)
        //{
        //    StockToDataTable(souceList, insRow);           
        //}
        #endregion
        // 2008.02.15 �폜 <<<<<<<<<<<<<<<<<<<<
        // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        //public void StockToGridGrs(List<StockEachWarehouse> souceList, int insRow)
        public void StockToGridGrs(List<StockExpansion> souceList, int insRow)
        // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        {
            StockToDataTableGrs(souceList, insRow);
        }
        // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        //private void StockToDataTableGrs(List<StockEachWarehouse> souceList, int insRow)
        private void StockToDataTableGrs(List<StockExpansion> souceList, int insRow)
        // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        {
            DeactivateDtlChangeEventHandler();
            int lastRowNo = 0;
            try
            {
                if (souceList != null)
                {
                    DataRow newRow = null;
                    // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                    //foreach (StockEachWarehouse wkDTL in souceList)
                    foreach (StockExpansion wkDTL in souceList)
                    // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                    {
                        if (insRow >= 0)
                        {
                            newRow = _mainProductStock.Rows[insRow];
                        }
                        else if (insRow < 0)
                        {
                            //�󔒍s�ɖ��ߍ��݂Ȃ̂ŁA�O���ɋ󔒍s������΋l�߂�B
                            for (int i = 0; i < _mainProductStock.Rows.Count; i++)
                            {
                                //                                if ((System.Guid)_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] == Guid.Empty)
                                object oo = _mainProductStock.Rows[i][ctCOL_FileHeaderGuid];
                                if ((_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] == DBNull.Value) ||
                                    ((Guid)_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] == Guid.Empty))
                                {
                                    newRow = _mainProductStock.Rows[i];
                                    lastRowNo++;
                                    break;
                                }
                            }
                        }
                        StockChangeRowGrs(ref newRow, wkDTL);
                        //StockChangeRow(ref newRow, wkDTL);
                        if (lastRowNo == _mainProductStock.Rows.Count)
                        {
                            IncrementProductStock();
                        }

                    }
                }
            }
            finally
            {
                ActivateDtlChangeEventHandler();
            }
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman�p�ɕύX

        #region 2008.02.15 �폜
        // 2008.02.15 �폜 >>>>>>>>>>>>>>>>>>>>
        //private void StockToDataTable(List<Stock> souceList, int insRow)
        //{
        //    DeactivateDtlChangeEventHandler();
        //    int lastRowNo = 0;
        //    try
        //    {

        //        if (souceList != null)
        //        {
        //            DataRow newRow = null;
        //            foreach (Stock wkDTL in souceList)
        //            {
        //                if (insRow >= 0)
        //                {
        //                    newRow = _mainProductStock.Rows[insRow];
        //                }
        //                else if (insRow < 0)
        //                {
        //                    //�󔒍s�ɖ��ߍ��݂Ȃ̂ŁA�O���ɋ󔒍s������΋l�߂�B
        //                    for (int i = 0; i < _mainProductStock.Rows.Count; i++)
        //                    {
        //                        //if ((System.Guid)_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] == Guid.Empty)
        //                        object oo = _mainProductStock.Rows[i][ctCOL_FileHeaderGuid];
        //                        if ((_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] == DBNull.Value) ||
        //                            ((Guid)_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] == Guid.Empty))
        //                        {
        //                            newRow = _mainProductStock.Rows[i];
        //                            lastRowNo++;
        //                            break;
        //                        }
        //                    }
        //                }

        //                StockChangeRow(ref newRow, wkDTL);
        //                if (lastRowNo == _mainProductStock.Rows.Count)
        //                {
        //                    IncrementProductStock();
        //                }

        //            }
        //        }
        //    }
        //    finally
        //    {
        //        ActivateDtlChangeEventHandler();
        //    }
        //}
        // 2008.02.15 �폜 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region 2008.02.15 �폜
        // 2008.02.15 �폜 >>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �݌ɏ�񔽉f(GRID)
        /// </summary>
        /// <param name="newRow"></param>
        /// <param name="wkDTL"></param>
        //private void StockChangeRow(ref DataRow newRow, Stock wkDTL)        
        //{
        //    newRow[ctCOL_CreateDateTime] = wkDTL.CreateDateTime;
        //    newRow[ctCOL_UpdateDateTime] = wkDTL.UpdateDateTime;
        //    newRow[ctCOL_EnterpriseCode] = wkDTL.EnterpriseCode;
        //    newRow[ctCOL_FileHeaderGuid] = wkDTL.FileHeaderGuid;
        //    newRow[ctCOL_UpdEmployeeCode] = wkDTL.UpdEmployeeCode;
        //    newRow[ctCOL_UpdAssemblyId1] = wkDTL.UpdAssemblyId1;
        //    newRow[ctCOL_UpdAssemblyId2] = wkDTL.UpdAssemblyId2;
        //    newRow[ctCOL_LogicalDeleteCode] = wkDTL.LogicalDeleteCode;
        //    newRow[ctCOL_SectionCode] = wkDTL.SectionCode;
        //    // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        //    //newRow[ctCOL_MakerCode] = wkDTL.MakerCode;
        //    //newRow[ctCOL_GoodsCode] = wkDTL.GoodsCode;
        //    newRow[ctCOL_GoodsMakerCd] = wkDTL.GoodsMakerCd;
        //    newRow[ctCOL_GoodsNo] = wkDTL.GoodsNo;
        //    // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        //    newRow[ctCOL_GoodsName] = wkDTL.GoodsName;

        //    newRow[ctCOL_WarehouseCode] = "";
        //    newRow[ctCOL_WarehouseName] = "";

        //    // 2008.02.15 �C�� >>>>>>>>>>>>>>>>>>>>
        //    //if (GetEditMode() == 1)
        //    //{
        //    //    //��������͒P���O
        //    //    newRow[ctCOL_StockUnitPrice] = 0;
        //    //    newRow[ctCOL_BfStockUnitPrice] = 0;
        //    //}
        //    //else
        //    //{
        //    //    // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        //    //    //newRow[ctCOL_StockUnitPrice] = wkDTL.StockUnitPrice;
        //    //    //newRow[ctCOL_BfStockUnitPrice] = wkDTL.StockUnitPrice;
        //    //    newRow[ctCOL_StockUnitPrice] = wkDTL.StockUnitPriceFl;
        //    //    newRow[ctCOL_BfStockUnitPrice] = wkDTL.StockUnitPriceFl;
        //    //    // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        //    //}
        //    newRow[ctCOL_StockUnitPrice] = wkDTL.StockUnitPriceFl;
        //    newRow[ctCOL_BfStockUnitPrice] = wkDTL.StockUnitPriceFl;
        //    // 2008.02.15 �C�� <<<<<<<<<<<<<<<<<<<<
        //    // �d���݌ɐ� = �d���݌ɐ� - �d���ϑ� - �ړ��d��
        //    newRow[ctCOL_SupplierStock] = wkDTL.SupplierStock - wkDTL.EntrustCnt - wkDTL.MovingSupliStock;
        //    // ����݌ɐ� = ����݌ɐ� - ����ϑ� - �ړ����
        //    // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        //    //newRow[ctCOL_TrustCount] = wkDTL.TrustCount - wkDTL.TrustEntrustCnt - wkDTL.MovingTrustStock;
        //    newRow[ctCOL_TrustCount] = wkDTL.TrustCount - wkDTL.TrustCount - wkDTL.MovingTrustStock;
        //    // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<

        //    // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        //    //newRow[ctCOL_CellphoneModelCode] = wkDTL.CellphoneModelCode;
        //    //newRow[ctCOL_CellphoneModelName] = wkDTL.CellphoneModelName;
        //    //newRow[ctCOL_CarrierCode] = wkDTL.CarrierCode;
        //    //newRow[ctCOL_CarrierName] = wkDTL.CarrierName;
        //    //newRow[ctCOL_MakerName] = wkDTL.MakerName;
        //    //newRow[ctCOL_SystematicColorCd] = wkDTL.SystematicColorCd;
        //    //newRow[ctCOL_SystematicColorNm] = wkDTL.SystematicColorNm;
        //    //newRow[ctCOL_LargeGoodsGanreCode] = wkDTL.LargeGoodsGanreCode;
        //    //newRow[ctCOL_MediumGoodsGanreCode] = wkDTL.MediumGoodsGanreCode;
        //    //newRow[ctCOL_PrdNumMngDiv] = wkDTL.PrdNumMngDiv;

        //    newRow[ctCOL_MakerName] = wkDTL.MakerName;
        //    //newRow[ctCOL_LargeGoodsGanreCode] = wkDTL.LargeGoodsGanreCode;
        //    //newRow[ctCOL_MediumGoodsGanreCode] = wkDTL.MediumGoodsGanreCode;
        //    //newRow[ctCOL_DetailGoodsGanreCode] = wkDTL.DetailGoodsGanreCode;
        //    //newRow[ctCOL_BLGoodsCode] = wkDTL.BLGoodsCode;

        //    newRow[ctCOL_WarehouseShelfNo] = wkDTL.WarehouseShelfNo;
        //    newRow[ctCOL_BfWarehouseShelfNo] = wkDTL.WarehouseShelfNo;
        //    // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        //    // 2008.02.15 �C�� >>>>>>>>>>>>>>>>>>>>
        //    //if (GetEditMode() == 1)
        //    //{
        //    //    newRow[ctCOL_StockDiv] = 1;
        //    //}
        //    //else
        //    //{
        //    //    newRow[ctCOL_StockDiv] = 0;
        //    //}
        //    newRow[ctCOL_StockDiv] = 0;
        //    // 2008.02.15 �C�� <<<<<<<<<<<<<<<<<<<<
        //    newRow[ctCOL_RowType] = 0; //�݌ɂ͕K��0
        //}
        // 2008.02.15 �폜 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region DEL 2008/07/24 Partsman�p�ɕύX
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        //private void StockChangeRowGrs(ref DataRow newRow, StockEachWarehouse wkDTL)
        private void StockChangeRowGrs(ref DataRow newRow, StockExpansion wkDTL)
        // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        {
            newRow[ctCOL_CreateDateTime] = wkDTL.CreateDateTime;
            newRow[ctCOL_UpdateDateTime] = wkDTL.UpdateDateTime;
            newRow[ctCOL_EnterpriseCode] = wkDTL.EnterpriseCode;
            newRow[ctCOL_FileHeaderGuid] = wkDTL.FileHeaderGuid;
            newRow[ctCOL_UpdEmployeeCode] = wkDTL.UpdEmployeeCode;
            newRow[ctCOL_UpdAssemblyId1] = wkDTL.UpdAssemblyId1;
            newRow[ctCOL_UpdAssemblyId2] = wkDTL.UpdAssemblyId2;
            newRow[ctCOL_LogicalDeleteCode] = wkDTL.LogicalDeleteCode;
            newRow[ctCOL_SectionCode] = wkDTL.SectionCode;
            // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //newRow[ctCOL_MakerCode] = wkDTL.MakerCode;
            //newRow[ctCOL_GoodsCode] = wkDTL.GoodsCode;
            newRow[ctCOL_GoodsMakerCd] = wkDTL.GoodsMakerCd;
            newRow[ctCOL_GoodsNo] = wkDTL.GoodsNo;
            // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            newRow[ctCOL_GoodsName] = wkDTL.GoodsName;


            newRow[ctCOL_WarehouseCode] = wkDTL.WarehouseCode;
            newRow[ctCOL_WarehouseName] = wkDTL.WarehouseName;

            // 2008.02.15 �C�� >>>>>>>>>>>>>>>>>>>>
            //if (GetEditMode() == 1)
            //{
            //    //��������͒P���O
            //    newRow[ctCOL_StockUnitPrice] = 0;
            //    newRow[ctCOL_BfStockUnitPrice] = 0;
            //}
            //else
            //{
            //    // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //    //newRow[ctCOL_StockUnitPrice] = wkDTL.StockUnitPrice;
            //    //newRow[ctCOL_BfStockUnitPrice] = wkDTL.StockUnitPrice;
            //    newRow[ctCOL_StockUnitPrice] = wkDTL.StockUnitPriceFl;
            //    newRow[ctCOL_BfStockUnitPrice] = wkDTL.StockUnitPriceFl;
            //    // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            //}
            newRow[ctCOL_StockUnitPrice] = wkDTL.StockUnitPriceFl;
            newRow[ctCOL_BfStockUnitPrice] = wkDTL.StockUnitPriceFl;
            // 2008.02.15 �C�� <<<<<<<<<<<<<<<<<<<<
            // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //// �d���݌ɐ� = �d���݌ɐ� - �d���ϑ� - �ړ��d��
            //newRow[ctCOL_SupplierStock] = wkDTL.SupplierStock - wkDTL.EntrustCnt - wkDTL.MovingSupliStock;
            //// ����݌ɐ� = ����݌ɐ� - ����ϑ� - �ړ����
            //newRow[ctCOL_TrustCount] = wkDTL.TrustCount - wkDTL.TrustEntrustCnt - wkDTL.MovingTrustStock;
            // �d���݌ɐ� = �d���݌ɐ� - �d���ϑ� - �ړ��d��
            newRow[ctCOL_SupplierStock] = wkDTL.SupplierStock - wkDTL.EntrustCnt - wkDTL.MovingSupliStock;
            // ����݌ɐ� = ����݌ɐ� - �ړ����
            newRow[ctCOL_TrustCount] = wkDTL.TrustCount - wkDTL.MovingTrustStock;
            // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<

            // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //newRow[ctCOL_CellphoneModelCode] = wkDTL.CellphoneModelCode;
            //newRow[ctCOL_CellphoneModelName] = wkDTL.CellphoneModelName;
            //newRow[ctCOL_CarrierCode] = wkDTL.CarrierCode;
            //newRow[ctCOL_CarrierName] = wkDTL.CarrierName;
            //newRow[ctCOL_MakerName] = wkDTL.MakerName;
            //newRow[ctCOL_SystematicColorCd] = wkDTL.SystematicColorCd;
            //newRow[ctCOL_SystematicColorNm] = wkDTL.SystematicColorNm;
            //newRow[ctCOL_LargeGoodsGanreCode] = wkDTL.LargeGoodsGanreCode;
            //newRow[ctCOL_MediumGoodsGanreCode] = wkDTL.MediumGoodsGanreCode;
            //newRow[ctCOL_PrdNumMngDiv] = wkDTL.PrdNumMngDiv;

            newRow[ctCOL_MakerName] = wkDTL.MakerName;
            newRow[ctCOL_LargeGoodsGanreCode] = wkDTL.LargeGoodsGanreCode;
            newRow[ctCOL_MediumGoodsGanreCode] = wkDTL.MediumGoodsGanreCode;
            newRow[ctCOL_DetailGoodsGanreCode] = wkDTL.DetailGoodsGanreCode;
            newRow[ctCOL_WarehouseShelfNo] = wkDTL.WarehouseShelfNo;
            newRow[ctCOL_BfWarehouseShelfNo] = wkDTL.WarehouseShelfNo;
            newRow[ctCOL_BLGoodsCode] = wkDTL.BLGoodsCode;
            // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            // 2008.02.15 �C�� >>>>>>>>>>>>>>>>>>>>
            //if (GetEditMode() == 1)
            //{
            //    newRow[ctCOL_StockDiv] = 1;
            //}
            //else
            //{
            //    newRow[ctCOL_StockDiv] = 0;
            //}
            newRow[ctCOL_StockDiv] = 0;
            // 2008.02.15 �C�� <<<<<<<<<<<<<<<<<<<<
            newRow[ctCOL_RowType] = 0; //�݌ɂ͕K��0
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman�p�ɕύX

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �݌ɏ�񔽉f����
        /// </summary>
        /// <param name="newRow">�V�K�s</param>
        /// <param name="stock">�݌Ƀ}�X�^</param>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <remarks>
        /// <br>Note       : �݌ɏ��𔽉f���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void StockChangeRowGrs(ref DataRow newRow, Stock stock, GoodsUnitData goodsUnitData)
        {
            StockAdjust stockAdjust = new StockAdjust();
            StockAdjustDtl stockAdjustDtl = new StockAdjustDtl();

            // �݌ɏ�񔽉f
            StockChangeRowGrs(ref newRow, stock, stockAdjust, stockAdjustDtl, goodsUnitData);
        }

        /// <summary>
        /// �݌ɏ�񔽉f����
        /// </summary>
        /// <param name="newRow">�V�K�s</param>
        /// <param name="stock">�݌Ƀ}�X�^</param>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <remarks>
        /// <br>Note       : �݌ɏ��𔽉f���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void StockChangeRowGrs(ref DataRow newRow, Stock stock, StockAdjust stockAdjust, StockAdjustDtl stockAdjustDtl, GoodsUnitData goodsUnitData)
        {
            this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData);

            newRow[ctCOL_CreateDateTime] = stock.CreateDateTime;
            newRow[ctCOL_UpdateDateTime] = stock.UpdateDateTime;
            newRow[ctCOL_EnterpriseCode] = stock.EnterpriseCode;
            newRow[ctCOL_FileHeaderGuid] = stock.FileHeaderGuid;
            newRow[ctCOL_UpdEmployeeCode] = stock.UpdEmployeeCode;
            newRow[ctCOL_UpdAssemblyId1] = stock.UpdAssemblyId1;
            newRow[ctCOL_UpdAssemblyId2] = stock.UpdAssemblyId2;
            newRow[ctCOL_LogicalDeleteCode] = stock.LogicalDeleteCode;
            newRow[ctCOL_SectionCode] = stock.SectionCode;                          // ���_�R�[�h

            // �݌ɒ����`�[�ԍ�
            newRow[ctCOL_StockAdjustSlipNo] = stockAdjust.StockAdjustSlipNo;
            // �݌ɒ����s�ԍ�

            // ���[�J�[�R�[�h
            if (goodsUnitData.GoodsMakerCd == 0)
            {
                newRow[ctCOL_GoodsMakerCd] = "";
            }
            else
            {
                newRow[ctCOL_GoodsMakerCd] = goodsUnitData.GoodsMakerCd.ToString("0000");
            }
            newRow[ctCOL_GoodsNo] = goodsUnitData.GoodsNo;                          // �i��
            newRow[ctCOL_GoodsName] = goodsUnitData.GoodsName;                      // �i��
            if (stockAdjustDtl.AdjustCount == 0)
            {
                newRow[ctCOL_StockUnitPrice] = GetStockUnitPrice(stock, goodsUnitData); // ���P��(�P���擾���W���[�����擾)
                newRow[ctCOL_BfStockUnitPrice] = newRow[ctCOL_StockUnitPrice];          // �ύX�O���P��(�P���擾���W���[�����擾)
            }
            else
            {
                newRow[ctCOL_StockUnitPrice] = stockAdjustDtl.StockUnitPriceFl;         // ���P��
                newRow[ctCOL_BfStockUnitPrice] = stockAdjustDtl.StockUnitPriceFl;          // �ύX�O���P��
            }
            newRow[ctCOL_WarehouseCode] = stock.WarehouseCode;                      // �q�ɃR�[�h
            // BL���i�R�[�h
            if (goodsUnitData.BLGoodsCode == 0)
            {
                newRow[ctCOL_BLGoodsCode] = "";
            }
            else
            {
                newRow[ctCOL_BLGoodsCode] = goodsUnitData.BLGoodsCode.ToString("00000");                  
            }
            newRow[ctCOL_WarehouseShelfNo] = stock.WarehouseShelfNo;                // �q�ɒI��

            // �W�����i(���i�}�X�^���擾)
            // �I�[�v�����i�敪
            GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(GetDate(), goodsUnitData.GoodsPriceList);
            if (stockAdjustDtl.AdjustCount == 0)
            {
                if (goodsPrice == null)
                {
                    newRow[ctCOL_ListPriceFl] = 0;
                    newRow[ctCOL_OpenPriceDiv] = 0;
                }
                else
                {
                    newRow[ctCOL_ListPriceFl] = goodsPrice.ListPrice;
                    newRow[ctCOL_OpenPriceDiv] = goodsPrice.OpenPriceDiv;
                }
            }
            else
            {
                newRow[ctCOL_ListPriceFl] = stockAdjustDtl.ListPriceFl;
                newRow[ctCOL_OpenPriceDiv] = stockAdjustDtl.OpenPriceDiv;
            }

            // �d����
            if (goodsUnitData.SupplierCd == 0)
            {
                newRow[ctCOL_SupplierCd] = DBNull.Value;
                newRow[ctCOL_SupplierSnm] = "";
            }
            else
            {
                newRow[ctCOL_SupplierCd] = goodsUnitData.SupplierCd.ToString("000000");
                newRow[ctCOL_SupplierSnm] = goodsUnitData.SupplierSnm.Trim();
                stockAdjustDtl.SupplierCd = goodsUnitData.SupplierCd;
                stockAdjustDtl.SupplierSnm = goodsUnitData.SupplierSnm.Trim();
            }
            
            // �d����
            if (stockAdjustDtl.AdjustCount == 0)
            {
                newRow[ctCOL_SalesOrderUnit] = stock.SalesOrderUnit;
                newRow[ctCOL_BfSalesOrderUnit] = stock.SalesOrderUnit;                                
            }
            else
            {
                newRow[ctCOL_SalesOrderUnit] = stockAdjustDtl.AdjustCount;
                newRow[ctCOL_BfSalesOrderUnit] = stockAdjustDtl.AdjustCount;                          
            }
            //newRow[ctCOL_SupplierStock] = stock.ShipmentPosCnt;                                     // �d���݌ɐ�
            newRow[ctCOL_SupplierStock] = stock.ShipmentPosCnt - stockAdjustDtl.AdjustCount;                                     // �d���݌ɐ�
            //newRow[ctCOL_BfSupplierStock] = stock.ShipmentPosCnt;                                     // �ύX�O�d���݌ɐ�
            newRow[ctCOL_BfSupplierStock] = stock.ShipmentPosCnt - stockAdjustDtl.AdjustCount;                                     // �ύX�O�d���݌ɐ�
            //newRow[ctCOL_AfSalesOrderUnit] = stock.SalesOrderUnit + stock.ShipmentPosCnt;           // �d���㐔
            newRow[ctCOL_AfSalesOrderUnit] = stock.ShipmentPosCnt;           // �d���㐔
            newRow[ctCOL_SalesOrderCount] = stock.SalesOrderCount;                                  // �����c

            // �d�����z
            newRow[ctCOL_StockPriceTaxExc] = stockAdjustDtl.StockPriceTaxExc;

            newRow[ctCOL_Stock] = stock.Clone();                                                    // �݌Ƀ}�X�^
            newRow[ctCOL_StockAdjust] = stockAdjust.Clone();                                        // �݌ɒ����f�[�^
            newRow[ctCOL_StockAdjustDtl] = stockAdjustDtl.Clone();                                  // �݌ɒ������׃f�[�^
            newRow[ctCOL_GoodsPrice] = goodsPrice;                                                  // ���i�}�X�^
            newRow[ctCOL_DtlNote] = stockAdjustDtl.DtlNote.Trim();                                  // ���ה��l

            // �d���`��
            newRow[ctCOL_SupplierFormalSrc] = stockAdjustDtl.SupplierFormalSrc;
            // �d�����גʔ�
            newRow[ctCOL_StockSlipDtlNumSrc] = stockAdjustDtl.StockSlipDtlNumSrc;
        }

        /// <summary>
        /// �݌ɏ�񔽉f����
        /// </summary>
        /// <param name="newRow">�V�K�s</param>
        /// <param name="stock">�݌Ƀ}�X�^</param>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <remarks>
        /// <br>Note       : �݌ɏ��𔽉f���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void StockChangeRowGrs(ref DataRow newRow, Stock stock, GoodsUnitData goodsUnitData, OrderListResultWork orderListResultWork)
        {
            this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData);

            newRow[ctCOL_CreateDateTime] = orderListResultWork.OrderDataCreateDate;
            newRow[ctCOL_UpdateDateTime] = stock.UpdateDateTime;
            newRow[ctCOL_EnterpriseCode] = stock.EnterpriseCode;
            newRow[ctCOL_FileHeaderGuid] = Guid.NewGuid();
            newRow[ctCOL_UpdEmployeeCode] = stock.UpdEmployeeCode;
            newRow[ctCOL_UpdAssemblyId1] = stock.UpdAssemblyId1;
            newRow[ctCOL_UpdAssemblyId2] = stock.UpdAssemblyId2;
            newRow[ctCOL_LogicalDeleteCode] = stock.LogicalDeleteCode;
            newRow[ctCOL_SectionCode] = stock.SectionCode;                          // ���_�R�[�h

            //// �݌ɒ����`�[�ԍ�
            //newRow[ctCOL_StockAdjustSlipNo] = stockAdjust.StockAdjustSlipNo;
            // �݌ɒ����s�ԍ�

            // ���[�J�[�R�[�h
            if (orderListResultWork.GoodsMakerCd == 0)
            {
                newRow[ctCOL_GoodsMakerCd] = "";
            }
            else
            {
                newRow[ctCOL_GoodsMakerCd] = orderListResultWork.GoodsMakerCd.ToString("0000");
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
                newRow[ctCOL_BLGoodsCode] = orderListResultWork.BLGoodsCode.ToString("00000");                    
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
                newRow[ctCOL_SupplierCd] = orderListResultWork.SupplierCd.ToString("000000");
                newRow[ctCOL_SupplierSnm] = GetSupplierSnm(orderListResultWork.SupplierCd);
            }
            newRow[ctCOL_SalesOrderUnit] = orderListResultWork.OrderRemainCnt;                      // �d����
            newRow[ctCOL_BfSalesOrderUnit] = orderListResultWork.OrderRemainCnt;                      // �d����
            newRow[ctCOL_SupplierStock] = stock.ShipmentPosCnt;                                     // �݌ɐ�
            newRow[ctCOL_BfSupplierStock] = stock.ShipmentPosCnt;                                     // �ύX�O�݌ɐ�
            newRow[ctCOL_AfSalesOrderUnit] = orderListResultWork.OrderRemainCnt + stock.ShipmentPosCnt; // �d���㐔
            newRow[ctCOL_SalesOrderCount] = stock.SalesOrderCount;                                  // �����c
            //newRow[ctCOL_SalesOrderCount] = orderListResultWork.OrderRemainCnt;                     // �����c

            // �d�����z
            newRow[ctCOL_StockPriceTaxExc] = 0;

            newRow[ctCOL_Stock] = stock.Clone();                                                    // �݌Ƀ}�X�^
            newRow[ctCOL_StockAdjust] = new StockAdjust();                                        // �݌ɒ����f�[�^
            newRow[ctCOL_StockAdjustDtl] = new StockAdjustDtl();                                  // �݌ɒ������׃f�[�^

            GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(GetDate(), goodsUnitData.GoodsPriceList);
            newRow[ctCOL_GoodsPrice] = goodsPrice;                                                  // ���i�}�X�^

            newRow[ctCOL_SupplierFormalSrc] = orderListResultWork.SupplierFormal;                   // �d���`��
            newRow[ctCOL_StockSlipDtlNumSrc] = orderListResultWork.StockSlipDtlNum;                 // �d�����גʔ�
            newRow[ctCOL_DtlNote] = orderListResultWork.StockDtiSlipNote1.Trim();                   // ���ה��l
        }

        public int StringObjToInt(object strTarget)
        {
            if ((strTarget == DBNull.Value) || (strTarget == null) || (((string)strTarget).Trim() == ""))
            {
                return 0;
            }

            return int.Parse((string)strTarget);
        }

        public string StringObjToString(object strTarget)
        {
            if ((strTarget == DBNull.Value) || (strTarget == null) || (((string)strTarget).Trim() == ""))
            {
                return "";
            }

            return ((string)strTarget).Trim();
        }

        /// <summary>
        /// �d���㐔�ݒ菈��
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <remarks>
        /// <br>Note       : �d���㐔��ݒ肵�܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public void SetAfSalesOrderUnit(int makerCode, string goodsNo)
        {
            // �d����
            double salesOrderUnit = 0;
            double supplierStock = 0;
            double bfSupplierStock = 0;

            bool firstFlg = true;

            for (int index = 0; index < _mainProductStock.Rows.Count; index++)
            {
                if ((_mainProductStock.Rows[index][ctCOL_FileHeaderGuid] == DBNull.Value) ||
                    ((Guid)_mainProductStock.Rows[index][ctCOL_FileHeaderGuid] == Guid.Empty))
                {
                    continue;
                }

                // ����̍݌ɏ�񂪑��݂���ꍇ
                if ((makerCode == StringObjToInt(_mainProductStock.Rows[index][ctCOL_GoodsMakerCd])) &&
                    (goodsNo == (string)_mainProductStock.Rows[index][ctCOL_GoodsNo]) &&
                    (_mainProductStock.Rows[index][ctCOL_SalesOrderUnit] != DBNull.Value))
                {
                    if (firstFlg == true)
                    {
                        firstFlg = false;

                        // �ύX�O�݌ɐ��擾
                        if (_mainProductStock.Rows[index][ctCOL_BfSupplierStock] != DBNull.Value)
                        {
                            bfSupplierStock = (double)_mainProductStock.Rows[index][ctCOL_BfSupplierStock];
                        }

                        // ����̍݌ɏ��̍݌ɐ���ݒ�
                        _mainProductStock.Rows[index][ctCOL_SupplierStock] = bfSupplierStock;
                    }
                    else
                    {
                        // ����̍݌ɏ��̍݌ɐ���ݒ�
                        _mainProductStock.Rows[index][ctCOL_SupplierStock] = salesOrderUnit + supplierStock;
                    }

                    // �d�����擾
                    salesOrderUnit = (double)_mainProductStock.Rows[index][ctCOL_SalesOrderUnit];

                    // �݌ɐ��擾
                    if (_mainProductStock.Rows[index][ctCOL_SupplierStock] != DBNull.Value)
                    {
                        supplierStock = (double)_mainProductStock.Rows[index][ctCOL_SupplierStock];
                    }

                    // ����̍݌ɏ��̎d���㐔��ݒ�
                    _mainProductStock.Rows[index][ctCOL_AfSalesOrderUnit] = salesOrderUnit + supplierStock;
                }
            }
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        #region 2007.10.11 �폜
        // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
        #region ���ԍ݌Ƀf�[�^�ϊ�����(���[�N��StaticTable)
        /*
		/// <summary>
		/// ���ԍ݌Ƀf�[�^�ϊ�����(���[�N��StaticTable)
		/// </summary>
		/// <param name="sauceList"></param>
		private static void ProductStockWorkToDataRow(ArrayList sauceList)
		{
			// �ύX�C�x���g����
			DeactivateDtlChangeEventHandler();

			try
			{
				// ���݂̃f�[�^�s���N���A����
				_mainProductStock.Rows.Clear();

				if (sauceList != null)
				{
					// ���ԍ݌Ƀ��[�N���f�[�^�s���쐬����
					foreach (ProductStockWork wkDtl in sauceList)
					{
						// DataRow��DataTable�֐ݒ肷��
						_mainProductStock.Rows.Add(SlipDtlWorkToDataRow(wkDtl));
					}
				}

				// �������׍s���̌���
				maxRowCnt = ctCOUNT_RowInit;
				while (maxRowCnt < _mainProductStock.Rows.Count)
				{
					maxRowCnt += ctCOUNT_RowAdd;
				}

				// ���׍ő�s���ɖ����Ȃ����𐶐�����
				string msg;
				CreateDummySlipDtl(out msg);
			}
			finally
			{
				// �ύX�C�x���g�L��
				ActivateDtlChangeEventHandler();
			}
		}
        */
        #endregion
        // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region 2007.10.11 �폜
        // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
        #region ���ԍ݌Ƀf�[�^�ϊ�����(UI�f�[�^��DataRow)
        /*
		/// <summary>
		/// ���ԍ݌Ƀf�[�^�ϊ�����(UI�f�[�^��DataRow)
		/// </summary>
		/// <param name="productStock"></param>
		private static DataRow ProductStockToDataRow(ProductStock productStock)
		{
			return ProductStockToDataRow(productStock, null);
		}

		/// <summary>
		/// ���ԍ݌Ƀf�[�^�ϊ�����(UI�f�[�^��DataRow)[DataRow�w���]
		/// </summary>
		/// <param name="productStock"></param>
		/// <param name="dataRow"></param>
		private static DataRow ProductStockToDataRow(ProductStock productStock, DataRow dataRow)
		{
			if (dataRow == null) dataRow = _mainProductStock.NewRow();

			try
			{
				// �_����폜�敪
				if ((dataRow[ctCOL_LogicalDeleteCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_LogicalDeleteCode] != productStock.LogicalDeleteCode))
					dataRow[ctCOL_LogicalDeleteCode] = productStock.LogicalDeleteCode;
				dataRow.EndEdit();

				// �쐬����
				if ((dataRow[ctCOL_CreateDateTime] == DBNull.Value) || ((DateTime)dataRow[ctCOL_CreateDateTime] != productStock.CreateDateTime))
					dataRow[ctCOL_CreateDateTime] = productStock.CreateDateTime;
				// �X�V����
				if ((dataRow[ctCOL_UpdateDateTime] == DBNull.Value) || ((DateTime)dataRow[ctCOL_UpdateDateTime] != productStock.UpdateDateTime))
					dataRow[ctCOL_UpdateDateTime] = productStock.UpdateDateTime;
				// ��ƃR�[�h
				if ((dataRow[ctCOL_EnterpriseCode] == DBNull.Value) || ((string)dataRow[ctCOL_EnterpriseCode] != productStock.EnterpriseCode))
					dataRow[ctCOL_EnterpriseCode] = productStock.EnterpriseCode;
				// GUID
				if ((dataRow[ctCOL_FileHeaderGuid] == DBNull.Value) || ((Guid)dataRow[ctCOL_FileHeaderGuid] != productStock.FileHeaderGuid))
					dataRow[ctCOL_FileHeaderGuid] = productStock.FileHeaderGuid;
				// �X�V�]�ƈ��R�[�h
				if ((dataRow[ctCOL_UpdEmployeeCode] == DBNull.Value) || ((string)dataRow[ctCOL_UpdEmployeeCode] != productStock.UpdEmployeeCode))
					dataRow[ctCOL_UpdEmployeeCode] = productStock.UpdEmployeeCode;
				// �X�V�A�Z���u��ID1
				if ((dataRow[ctCOL_UpdAssemblyId1] == DBNull.Value) || ((string)dataRow[ctCOL_UpdAssemblyId1] != productStock.UpdAssemblyId1))
					dataRow[ctCOL_UpdAssemblyId1] = productStock.UpdAssemblyId1;
				// �X�V�A�Z���u��ID2
				if ((dataRow[ctCOL_UpdAssemblyId2] == DBNull.Value) || ((string)dataRow[ctCOL_UpdAssemblyId2] != productStock.UpdAssemblyId2))
					dataRow[ctCOL_UpdAssemblyId2] = productStock.UpdAssemblyId2;
                // �_���폜�敪
                if ((dataRow[ctCOL_LogicalDeleteCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_LogicalDeleteCode] != productStock.LogicalDeleteCode))
                    dataRow[ctCOL_LogicalDeleteCode] = productStock.LogicalDeleteCode;
                // ���_�R�[�h
                if ((dataRow[ctCOL_SectionCode] == DBNull.Value) || ((string)dataRow[ctCOL_SectionCode] != productStock.SectionCode))
                    dataRow[ctCOL_SectionCode] = productStock.SectionCode;
                // ���[�J�[�R�[�h
                if ((dataRow[ctCOL_MakerCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_MakerCode] != productStock.MakerCode))
                    dataRow[ctCOL_MakerCode] = productStock.MakerCode;
                // ���i�R�[�h
                if ((dataRow[ctCOL_GoodsCode] == DBNull.Value) || ((string)dataRow[ctCOL_GoodsCode] != productStock.GoodsCode))
                    dataRow[ctCOL_GoodsCode] = productStock.GoodsCode;
                // ���i����
                if ((dataRow[ctCOL_GoodsName] == DBNull.Value) || ((string)dataRow[ctCOL_GoodsName] != productStock.GoodsName))
                    dataRow[ctCOL_GoodsName] = productStock.GoodsName;
                // �����ԍ�
                if ((dataRow[ctCOL_ProductNumber] == DBNull.Value) || ((string)dataRow[ctCOL_ProductNumber] != productStock.ProductNumber))
                    dataRow[ctCOL_ProductNumber] = productStock.ProductNumber;
                // ���ԍ݌Ƀ}�X�^GUID
                if ((dataRow[ctCOL_ProductStockGuid] == DBNull.Value) || ((Guid)dataRow[ctCOL_ProductStockGuid] != productStock.ProductStockGuid))
                    dataRow[ctCOL_ProductStockGuid] = productStock.ProductStockGuid;
                // �݌ɋ敪
                if ((dataRow[ctCOL_StockDiv] == DBNull.Value) || ((Int32)dataRow[ctCOL_StockDiv] != productStock.StockDiv))
                    dataRow[ctCOL_StockDiv] = productStock.StockDiv;
                // �q�ɃR�[�h
                if ((dataRow[ctCOL_WarehouseCode] == DBNull.Value) || ((string)dataRow[ctCOL_WarehouseCode] != productStock.WarehouseCode))
                    dataRow[ctCOL_WarehouseCode] = productStock.WarehouseCode;
                // �q�ɖ���
                if ((dataRow[ctCOL_WarehouseName] == DBNull.Value) || ((string)dataRow[ctCOL_WarehouseName] != productStock.WarehouseName))
                    dataRow[ctCOL_WarehouseName] = productStock.WarehouseName;
                // ���Ǝ҃R�[�h
                if ((dataRow[ctCOL_CarrierEpCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_CarrierEpCode] != productStock.CarrierEpCode))
                    dataRow[ctCOL_CarrierEpCode] = productStock.CarrierEpCode;
                // ���ƎҖ���
                if ((dataRow[ctCOL_CarrierEpName] == DBNull.Value) || ((string)dataRow[ctCOL_CarrierEpName] != productStock.CarrierEpName))
                    dataRow[ctCOL_CarrierEpName] = productStock.CarrierEpName;
                // ���Ӑ�R�[�h
                if ((dataRow[ctCOL_CustomerCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_CustomerCode] != productStock.CustomerCode))
                    dataRow[ctCOL_CustomerCode] = productStock.CustomerCode;
                // ���Ӑ於��
                if ((dataRow[ctCOL_CustomerName] == DBNull.Value) || ((string)dataRow[ctCOL_CustomerName] != productStock.CustomerName))
                    dataRow[ctCOL_CustomerName] = productStock.CustomerName;
                // ���Ӑ於��2
                if ((dataRow[ctCOL_CustomerName2] == DBNull.Value) || ((string)dataRow[ctCOL_CustomerName2] != productStock.CustomerName2))
                    dataRow[ctCOL_CustomerName2] = productStock.CustomerName2;
                // �d����
                if ((dataRow[ctCOL_StockDate] == DBNull.Value) || ((DateTime)dataRow[ctCOL_StockDate] != productStock.StockDate))
                    dataRow[ctCOL_StockDate] = productStock.StockDate;
                // ���ד�
                if ((dataRow[ctCOL_ArrivalGoodsDay] == DBNull.Value) || ((DateTime)dataRow[ctCOL_ArrivalGoodsDay] != productStock.ArrivalGoodsDay))
                    dataRow[ctCOL_ArrivalGoodsDay] = productStock.ArrivalGoodsDay;
                int stockPointWay = GetStockPointWay();
                if ((stockPointWay == (int)ConstantManagement_Mobile.ct_StockPointWay.Average) ||
                    (stockPointWay == (int)ConstantManagement_Mobile.ct_StockPointWay.Last))
                {
                    //�ړ����ϖ@=>�݌Ƀ}�X�^�̎d���P�����S�̐ݒ�(�݌Ƀ}�X�^�Q��)
                    Stock chkStock = new Stock();
                    //�݌ɏ��ďo
                    int mode = GetEditMode();
                    string goodsCode = (string)dataRow[ctCOL_GoodsCode];
                    if (!String.IsNullOrEmpty(goodsCode))
                    {
                        GetStockInf(out chkStock, goodsCode, (Int32)dataRow[ctCOL_MakerCode], mode);
                    }
                    
                    dataRow[ctCOL_StockUnitPrice] = chkStock.StockUnitPrice;
                }
                else
                {
                    // �d���P��
                    if ((dataRow[ctCOL_StockUnitPrice] == DBNull.Value) || ((Int64)dataRow[ctCOL_StockUnitPrice] != productStock.StockUnitPrice))
                        dataRow[ctCOL_StockUnitPrice] = productStock.StockUnitPrice;
                }

                // �ېŋ敪
                if ((dataRow[ctCOL_TaxationCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_TaxationCode] != productStock.TaxationCode))
                    dataRow[ctCOL_TaxationCode] = productStock.TaxationCode;
                // �݌ɏ��
                if ((dataRow[ctCOL_StockState] == DBNull.Value) || ((Int32)dataRow[ctCOL_StockState] != productStock.StockState))
                    dataRow[ctCOL_StockState] = productStock.StockState;
                // �ړ����
                if ((dataRow[ctCOL_MoveStatus] == DBNull.Value) || ((Int32)dataRow[ctCOL_MoveStatus] != productStock.MoveStatus))
                    dataRow[ctCOL_MoveStatus] = productStock.MoveStatus;
                // ���i���
                if ((dataRow[ctCOL_GoodsCodeStatus] == DBNull.Value) || ((Int32)dataRow[ctCOL_GoodsCodeStatus] != productStock.GoodsCodeStatus))
                    dataRow[ctCOL_GoodsCodeStatus] = productStock.GoodsCodeStatus;
                // �C���O���i���
                if ((dataRow[ctCOL_BfGoodsCodeStatus] == DBNull.Value) || ((Int32)dataRow[ctCOL_BfGoodsCodeStatus] != productStock.GoodsCodeStatus))
                    dataRow[ctCOL_BfGoodsCodeStatus] = productStock.GoodsCodeStatus;
                // ���i�d�b�ԍ�1
                if ((dataRow[ctCOL_StockTelNo1] == DBNull.Value) || ((string)dataRow[ctCOL_StockTelNo1] != productStock.StockTelNo1))
                    dataRow[ctCOL_StockTelNo1] = productStock.StockTelNo1;
                // ���i�d�b�ԍ�2
                if ((dataRow[ctCOL_StockTelNo2] == DBNull.Value) || ((string)dataRow[ctCOL_StockTelNo2] != productStock.StockTelNo2))
                    dataRow[ctCOL_StockTelNo2] = productStock.StockTelNo2;
                // �����敪
                if ((dataRow[ctCOL_RomDiv] == DBNull.Value) || ((Int32)dataRow[ctCOL_RomDiv] != productStock.RomDiv))
                    dataRow[ctCOL_RomDiv] = productStock.RomDiv;
                // �@��R�[�h
                if ((dataRow[ctCOL_CellphoneModelCode] == DBNull.Value) || ((string)dataRow[ctCOL_CellphoneModelCode] != productStock.CellphoneModelCode))
                    dataRow[ctCOL_CellphoneModelCode] = productStock.CellphoneModelCode;
                // �@�햼��
                if ((dataRow[ctCOL_CellphoneModelName] == DBNull.Value) || ((string)dataRow[ctCOL_CellphoneModelName] != productStock.CellphoneModelName))
                    dataRow[ctCOL_CellphoneModelName] = productStock.CellphoneModelName;
                // �L�����A�R�[�h
                if ((dataRow[ctCOL_CarrierCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_CarrierCode] != productStock.CarrierCode))
                    dataRow[ctCOL_CarrierCode] = productStock.CarrierCode;
                // �L�����A����
                if ((dataRow[ctCOL_CarrierName] == DBNull.Value) || ((string)dataRow[ctCOL_CarrierName] != productStock.CarrierName))
                    dataRow[ctCOL_CarrierName] = productStock.CarrierName;
                // ���[�J�[����
                if ((dataRow[ctCOL_MakerName] == DBNull.Value) || ((string)dataRow[ctCOL_MakerName] != productStock.MakerName))
                    dataRow[ctCOL_MakerName] = productStock.MakerName;
                // �n���F�R�[�h
                if ((dataRow[ctCOL_SystematicColorCd] == DBNull.Value) || ((Int32)dataRow[ctCOL_SystematicColorCd] != productStock.SystematicColorCd))
                    dataRow[ctCOL_SystematicColorCd] = productStock.SystematicColorCd;
                // �n���F����
                if ((dataRow[ctCOL_SystematicColorNm] == DBNull.Value) || ((string)dataRow[ctCOL_SystematicColorNm] != productStock.SystematicColorNm))
                    dataRow[ctCOL_SystematicColorNm] = productStock.SystematicColorNm;
                // ���i�啪�ރR�[�h
                if ((dataRow[ctCOL_LargeGoodsGanreCode] == DBNull.Value) || ((string)dataRow[ctCOL_LargeGoodsGanreCode] != productStock.LargeGoodsGanreCode))
                    dataRow[ctCOL_LargeGoodsGanreCode] = productStock.LargeGoodsGanreCode;
                // ���i�����ރR�[�h
                if ((dataRow[ctCOL_MediumGoodsGanreCode] == DBNull.Value) || ((string)dataRow[ctCOL_MediumGoodsGanreCode] != productStock.MediumGoodsGanreCode))
                    dataRow[ctCOL_MediumGoodsGanreCode] = productStock.MediumGoodsGanreCode;
                // �o�א擾�Ӑ�R�[�h
                if ((dataRow[ctCOL_ShipCustomerCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_ShipCustomerCode] != productStock.ShipCustomerCode))
                    dataRow[ctCOL_ShipCustomerCode] = productStock.ShipCustomerCode;
                // �o�א擾�Ӑ於��
                if ((dataRow[ctCOL_ShipCustomerName] == DBNull.Value) || ((string)dataRow[ctCOL_ShipCustomerName] != productStock.ShipCustomerName))
                    dataRow[ctCOL_ShipCustomerName] = productStock.ShipCustomerName;
                // �o�א擾�Ӑ於��2
                if ((dataRow[ctCOL_ShipCustomerName2] == DBNull.Value) || ((string)dataRow[ctCOL_ShipCustomerName2] != productStock.ShipCustomerName2))
                    dataRow[ctCOL_ShipCustomerName2] = productStock.ShipCustomerName2;

                // �sNo�t��
                if (dataRow[ctCOL_RowNum] == DBNull.Value)
                    dataRow[ctCOL_RowNum] = mainAdjustStockDtlFullView.Count + 1;


				// �ҏW���s�ɔ��f
				dataRow.EndEdit();
			}
			finally
			{
			}

			return dataRow;
		}
        */
        #endregion
        // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region 2007.10.11 �폜
        // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
        #region ���ԍ݌Ƀf�[�^�ϊ�����(���[�N��DataRow)
        /*
        /// <summary>
		/// ���ԍ݌Ƀf�[�^�ϊ�����(���[�N��DataRow)
		/// </summary>
		/// <param name="productStockWork"></param>
		private static DataRow SlipDtlWorkToDataRow(ProductStockWork productStockWork)
		{
			return SlipDtlWorkToDataRow(productStockWork, null);
		}

		/// <summary>
		/// ���ԍ݌Ƀf�[�^�ϊ�����(���[�N��DataRow)[DataRow�w���]
		/// </summary>
		/// <param name="productStockWork"></param>
		/// <param name="dataRow"></param>
		private static DataRow SlipDtlWorkToDataRow(ProductStockWork productStockWork, DataRow dataRow)
		{
			if (dataRow == null) dataRow = _mainProductStock.NewRow();

			try
			{
				// �쐬����
				if ((dataRow[ctCOL_CreateDateTime] == DBNull.Value) || ((DateTime)dataRow[ctCOL_CreateDateTime] != productStockWork.CreateDateTime))
					dataRow[ctCOL_CreateDateTime] = productStockWork.CreateDateTime;
				// �X�V����
				if ((dataRow[ctCOL_UpdateDateTime] == DBNull.Value) || ((DateTime)dataRow[ctCOL_UpdateDateTime] != productStockWork.UpdateDateTime))
					dataRow[ctCOL_UpdateDateTime] = productStockWork.UpdateDateTime;
				// ��ƃR�[�h
				if ((dataRow[ctCOL_EnterpriseCode] == DBNull.Value) || ((string)dataRow[ctCOL_EnterpriseCode] != productStockWork.EnterpriseCode))
					dataRow[ctCOL_EnterpriseCode] = productStockWork.EnterpriseCode;
				// GUID
				if ((dataRow[ctCOL_FileHeaderGuid] == DBNull.Value) || ((Guid)dataRow[ctCOL_FileHeaderGuid] != productStockWork.FileHeaderGuid))
					dataRow[ctCOL_FileHeaderGuid] = productStockWork.FileHeaderGuid;
				// �X�V�]�ƈ��R�[�h
				if ((dataRow[ctCOL_UpdEmployeeCode] == DBNull.Value) || ((string)dataRow[ctCOL_UpdEmployeeCode] != productStockWork.UpdEmployeeCode))
					dataRow[ctCOL_UpdEmployeeCode] = productStockWork.UpdEmployeeCode;
				// �X�V�A�Z���u��ID1
				if ((dataRow[ctCOL_UpdAssemblyId1] == DBNull.Value) || ((string)dataRow[ctCOL_UpdAssemblyId1] != productStockWork.UpdAssemblyId1))
					dataRow[ctCOL_UpdAssemblyId1] = productStockWork.UpdAssemblyId1;
				// �X�V�A�Z���u��ID2
				if ((dataRow[ctCOL_UpdAssemblyId2] == DBNull.Value) || ((string)dataRow[ctCOL_UpdAssemblyId2] != productStockWork.UpdAssemblyId2))
					dataRow[ctCOL_UpdAssemblyId2] = productStockWork.UpdAssemblyId2;
				// �_����폜�敪
				if ((dataRow[ctCOL_LogicalDeleteCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_LogicalDeleteCode] != productStockWork.LogicalDeleteCode))
					dataRow[ctCOL_LogicalDeleteCode] = productStockWork.LogicalDeleteCode;
                // ���_�R�[�h
                if ((dataRow[ctCOL_SectionCode] == DBNull.Value) || ((string)dataRow[ctCOL_SectionCode] != productStockWork.SectionCode))
                    dataRow[ctCOL_SectionCode] = productStockWork.SectionCode;
                // ���[�J�[�R�[�h
                if ((dataRow[ctCOL_MakerCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_MakerCode] != productStockWork.MakerCode))
                    dataRow[ctCOL_MakerCode] = productStockWork.MakerCode;
                // ���i�R�[�h
                if ((dataRow[ctCOL_GoodsCode] == DBNull.Value) || ((string)dataRow[ctCOL_GoodsCode] != productStockWork.GoodsCode))
                    dataRow[ctCOL_GoodsCode] = productStockWork.GoodsCode;
                // ���i����
                if ((dataRow[ctCOL_GoodsName] == DBNull.Value) || ((string)dataRow[ctCOL_GoodsName] != productStockWork.GoodsName))
                    dataRow[ctCOL_GoodsName] = productStockWork.GoodsName;
                // �����ԍ�
                if ((dataRow[ctCOL_ProductNumber] == DBNull.Value) || ((string)dataRow[ctCOL_ProductNumber] != productStockWork.ProductNumber))
                    dataRow[ctCOL_ProductNumber] = productStockWork.ProductNumber;
                // ���ԍ݌Ƀ}�X�^GUID
                if ((dataRow[ctCOL_ProductStockGuid] == DBNull.Value) || ((Guid)dataRow[ctCOL_ProductStockGuid] != productStockWork.ProductStockGuid))
                    dataRow[ctCOL_ProductStockGuid] = productStockWork.ProductStockGuid;
                // �݌ɋ敪
                if ((dataRow[ctCOL_StockDiv] == DBNull.Value) || ((Int32)dataRow[ctCOL_StockDiv] != productStockWork.StockDiv))
                    dataRow[ctCOL_StockDiv] = productStockWork.StockDiv;
                // �q�ɃR�[�h
                if ((dataRow[ctCOL_WarehouseCode] == DBNull.Value) || ((string)dataRow[ctCOL_WarehouseCode] != productStockWork.WarehouseCode))
                    dataRow[ctCOL_WarehouseCode] = productStockWork.WarehouseCode;
                // �q�ɖ���
                if ((dataRow[ctCOL_WarehouseName] == DBNull.Value) || ((string)dataRow[ctCOL_WarehouseName] != productStockWork.WarehouseName))
                    dataRow[ctCOL_WarehouseName] = productStockWork.WarehouseName;
                // ���Ǝ҃R�[�h
                if ((dataRow[ctCOL_CarrierEpCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_CarrierEpCode] != productStockWork.CarrierEpCode))
                    dataRow[ctCOL_CarrierEpCode] = productStockWork.CarrierEpCode;
                // ���ƎҖ���
                if ((dataRow[ctCOL_CarrierEpName] == DBNull.Value) || ((string)dataRow[ctCOL_CarrierEpName] != productStockWork.CarrierEpName))
                    dataRow[ctCOL_CarrierEpName] = productStockWork.CarrierEpName;
                // ���Ӑ�R�[�h
                if ((dataRow[ctCOL_CustomerCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_CustomerCode] != productStockWork.CustomerCode))
                    dataRow[ctCOL_CustomerCode] = productStockWork.CustomerCode;
                // ���Ӑ於��
                if ((dataRow[ctCOL_CustomerName] == DBNull.Value) || ((string)dataRow[ctCOL_CustomerName] != productStockWork.CustomerName))
                    dataRow[ctCOL_CustomerName] = productStockWork.CustomerName;
                // ���Ӑ於��2
                if ((dataRow[ctCOL_CustomerName2] == DBNull.Value) || ((string)dataRow[ctCOL_CustomerName2] != productStockWork.CustomerName2))
                    dataRow[ctCOL_CustomerName2] = productStockWork.CustomerName2;
                // �d����
                if ((dataRow[ctCOL_StockDate] == DBNull.Value) || ((DateTime)dataRow[ctCOL_StockDate] != productStockWork.StockDate))
                    dataRow[ctCOL_StockDate] = productStockWork.StockDate;
                // ���ד�
                if ((dataRow[ctCOL_ArrivalGoodsDay] == DBNull.Value) || ((DateTime)dataRow[ctCOL_ArrivalGoodsDay] != productStockWork.ArrivalGoodsDay))
                    dataRow[ctCOL_ArrivalGoodsDay] = productStockWork.ArrivalGoodsDay;
                // �d���P��
                if ((dataRow[ctCOL_StockUnitPrice] == DBNull.Value) || ((Int64)dataRow[ctCOL_StockUnitPrice] != productStockWork.StockUnitPrice))
                    dataRow[ctCOL_StockUnitPrice] = productStockWork.StockUnitPrice;
                // �ېŋ敪
                if ((dataRow[ctCOL_TaxationCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_TaxationCode] != productStockWork.TaxationCode))
                    dataRow[ctCOL_TaxationCode] = productStockWork.TaxationCode;
                // �݌ɏ��
                if ((dataRow[ctCOL_StockState] == DBNull.Value) || ((Int32)dataRow[ctCOL_StockState] != productStockWork.StockState))
                    dataRow[ctCOL_StockState] = productStockWork.StockState;
                // �ړ����
                if ((dataRow[ctCOL_MoveStatus] == DBNull.Value) || ((Int32)dataRow[ctCOL_MoveStatus] != productStockWork.MoveStatus))
                    dataRow[ctCOL_MoveStatus] = productStockWork.MoveStatus;
                // ���i���
                if ((dataRow[ctCOL_GoodsCodeStatus] == DBNull.Value) || ((Int32)dataRow[ctCOL_GoodsCodeStatus] != productStockWork.GoodsCodeStatus))
                    dataRow[ctCOL_GoodsCodeStatus] = productStockWork.GoodsCodeStatus;
                // �C���O���i���
                if ((dataRow[ctCOL_GoodsCodeStatus] == DBNull.Value) || ((Int32)dataRow[ctCOL_GoodsCodeStatus] != productStockWork.GoodsCodeStatus))
                    dataRow[ctCOL_BfGoodsCodeStatus] = productStockWork.GoodsCodeStatus;
                // ���i�d�b�ԍ�1
                if ((dataRow[ctCOL_StockTelNo1] == DBNull.Value) || ((string)dataRow[ctCOL_StockTelNo1] != productStockWork.StockTelNo1))
                    dataRow[ctCOL_StockTelNo1] = productStockWork.StockTelNo1;
                // ���i�d�b�ԍ�2
                if ((dataRow[ctCOL_StockTelNo2] == DBNull.Value) || ((string)dataRow[ctCOL_StockTelNo2] != productStockWork.StockTelNo2))
                    dataRow[ctCOL_StockTelNo2] = productStockWork.StockTelNo2;
                // �����敪
                if ((dataRow[ctCOL_RomDiv] == DBNull.Value) || ((Int32)dataRow[ctCOL_RomDiv] != productStockWork.RomDiv))
                    dataRow[ctCOL_RomDiv] = productStockWork.RomDiv;
                // �@��R�[�h
                if ((dataRow[ctCOL_CellphoneModelCode] == DBNull.Value) || ((string)dataRow[ctCOL_CellphoneModelCode] != productStockWork.CellphoneModelCode))
                    dataRow[ctCOL_CellphoneModelCode] = productStockWork.CellphoneModelCode;
                // �@�햼��
                if ((dataRow[ctCOL_CellphoneModelName] == DBNull.Value) || ((string)dataRow[ctCOL_CellphoneModelName] != productStockWork.CellphoneModelName))
                    dataRow[ctCOL_CellphoneModelName] = productStockWork.CellphoneModelName;
                // �L�����A�R�[�h
                if ((dataRow[ctCOL_CarrierCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_CarrierCode] != productStockWork.CarrierCode))
                    dataRow[ctCOL_CarrierCode] = productStockWork.CarrierCode;
                // �L�����A����
                if ((dataRow[ctCOL_CarrierName] == DBNull.Value) || ((string)dataRow[ctCOL_CarrierName] != productStockWork.CarrierName))
                    dataRow[ctCOL_CarrierName] = productStockWork.CarrierName;
                // ���[�J�[����
                if ((dataRow[ctCOL_MakerName] == DBNull.Value) || ((string)dataRow[ctCOL_MakerName] != productStockWork.MakerName))
                    dataRow[ctCOL_MakerName] = productStockWork.MakerName;
                // �n���F�R�[�h
                if ((dataRow[ctCOL_SystematicColorCd] == DBNull.Value) || ((Int32)dataRow[ctCOL_SystematicColorCd] != productStockWork.SystematicColorCd))
                    dataRow[ctCOL_SystematicColorCd] = productStockWork.SystematicColorCd;
                // �n���F����
                if ((dataRow[ctCOL_SystematicColorNm] == DBNull.Value) || ((string)dataRow[ctCOL_SystematicColorNm] != productStockWork.SystematicColorNm))
                    dataRow[ctCOL_SystematicColorNm] = productStockWork.SystematicColorNm;
                // ���i�啪�ރR�[�h
                if ((dataRow[ctCOL_LargeGoodsGanreCode] == DBNull.Value) || ((string)dataRow[ctCOL_LargeGoodsGanreCode] != productStockWork.LargeGoodsGanreCode))
                    dataRow[ctCOL_LargeGoodsGanreCode] = productStockWork.LargeGoodsGanreCode;
                // ���i�����ރR�[�h
                if ((dataRow[ctCOL_MediumGoodsGanreCode] == DBNull.Value) || ((string)dataRow[ctCOL_MediumGoodsGanreCode] != productStockWork.MediumGoodsGanreCode))
                    dataRow[ctCOL_MediumGoodsGanreCode] = productStockWork.MediumGoodsGanreCode;
                // �o�א擾�Ӑ�R�[�h
                if ((dataRow[ctCOL_ShipCustomerCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_ShipCustomerCode] != productStockWork.ShipCustomerCode))
                    dataRow[ctCOL_ShipCustomerCode] = productStockWork.ShipCustomerCode;
                // �o�א擾�Ӑ於��
                if ((dataRow[ctCOL_ShipCustomerName] == DBNull.Value) || ((string)dataRow[ctCOL_ShipCustomerName] != productStockWork.ShipCustomerName))
                    dataRow[ctCOL_ShipCustomerName] = productStockWork.ShipCustomerName;
                // �o�א擾�Ӑ於��2
                if ((dataRow[ctCOL_ShipCustomerName2] == DBNull.Value) || ((string)dataRow[ctCOL_ShipCustomerName2] != productStockWork.ShipCustomerName2))
                    dataRow[ctCOL_ShipCustomerName2] = productStockWork.ShipCustomerName2;
            }
			finally
			{
			}

			return dataRow;
		}
        */
        #endregion
        // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region DEL 2008/07/24 Partsman�p�ɕύX
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        // 2007.10.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �݌Ƀf�[�^�ϊ�����(UI�f�[�^��DataRow)[DataRow�w���]
        /// </summary>
        /// <param name="productStock"></param>
        /// <param name="dataRow"></param>
        private static DataRow StockToDataRow(StockExpansion stockExpansion, DataRow dataRow)
        {
            if (dataRow == null) dataRow = _mainProductStock.NewRow();

            try
            {
                // �_����폜�敪
                if ((dataRow[ctCOL_LogicalDeleteCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_LogicalDeleteCode] != stockExpansion.LogicalDeleteCode))
                    dataRow[ctCOL_LogicalDeleteCode] = stockExpansion.LogicalDeleteCode;
                dataRow.EndEdit();

                // �쐬����
                if ((dataRow[ctCOL_CreateDateTime] == DBNull.Value) || ((DateTime)dataRow[ctCOL_CreateDateTime] != stockExpansion.CreateDateTime))
                    dataRow[ctCOL_CreateDateTime] = stockExpansion.CreateDateTime;
                // �X�V����
                if ((dataRow[ctCOL_UpdateDateTime] == DBNull.Value) || ((DateTime)dataRow[ctCOL_UpdateDateTime] != stockExpansion.UpdateDateTime))
                    dataRow[ctCOL_UpdateDateTime] = stockExpansion.UpdateDateTime;
                // ��ƃR�[�h
                if ((dataRow[ctCOL_EnterpriseCode] == DBNull.Value) || ((string)dataRow[ctCOL_EnterpriseCode] != stockExpansion.EnterpriseCode))
                    dataRow[ctCOL_EnterpriseCode] = stockExpansion.EnterpriseCode;
                // GUID
                if ((dataRow[ctCOL_FileHeaderGuid] == DBNull.Value) || ((Guid)dataRow[ctCOL_FileHeaderGuid] != stockExpansion.FileHeaderGuid))
                    dataRow[ctCOL_FileHeaderGuid] = stockExpansion.FileHeaderGuid;
                // �X�V�]�ƈ��R�[�h
                if ((dataRow[ctCOL_UpdEmployeeCode] == DBNull.Value) || ((string)dataRow[ctCOL_UpdEmployeeCode] != stockExpansion.UpdEmployeeCode))
                    dataRow[ctCOL_UpdEmployeeCode] = stockExpansion.UpdEmployeeCode;
                // �X�V�A�Z���u��ID1
                if ((dataRow[ctCOL_UpdAssemblyId1] == DBNull.Value) || ((string)dataRow[ctCOL_UpdAssemblyId1] != stockExpansion.UpdAssemblyId1))
                    dataRow[ctCOL_UpdAssemblyId1] = stockExpansion.UpdAssemblyId1;
                // �X�V�A�Z���u��ID2
                if ((dataRow[ctCOL_UpdAssemblyId2] == DBNull.Value) || ((string)dataRow[ctCOL_UpdAssemblyId2] != stockExpansion.UpdAssemblyId2))
                    dataRow[ctCOL_UpdAssemblyId2] = stockExpansion.UpdAssemblyId2;
                // �_���폜�敪
                if ((dataRow[ctCOL_LogicalDeleteCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_LogicalDeleteCode] != stockExpansion.LogicalDeleteCode))
                    dataRow[ctCOL_LogicalDeleteCode] = stockExpansion.LogicalDeleteCode;
                // ���_�R�[�h
                if ((dataRow[ctCOL_SectionCode] == DBNull.Value) || ((string)dataRow[ctCOL_SectionCode] != stockExpansion.SectionCode))
                    dataRow[ctCOL_SectionCode] = stockExpansion.SectionCode;
                // ���[�J�[�R�[�h
                //if ((dataRow[ctCOL_GoodsMakerCd] == DBNull.Value) || ((Int32)dataRow[ctCOL_GoodsMakerCd] != stockExpansion.GoodsMakerCd))
                //    dataRow[ctCOL_GoodsMakerCd] = stockExpansion.GoodsMakerCd;
                // ���i�R�[�h
                if ((dataRow[ctCOL_GoodsNo] == DBNull.Value) || ((string)dataRow[ctCOL_GoodsNo] != stockExpansion.GoodsNo))
                    dataRow[ctCOL_GoodsNo] = stockExpansion.GoodsNo;
                // ���i����
                if ((dataRow[ctCOL_GoodsName] == DBNull.Value) || ((string)dataRow[ctCOL_GoodsName] != stockExpansion.GoodsName))
                    dataRow[ctCOL_GoodsName] = stockExpansion.GoodsName;
                // �q�ɃR�[�h
                if ((dataRow[ctCOL_WarehouseCode] == DBNull.Value) || ((string)dataRow[ctCOL_WarehouseCode] != stockExpansion.WarehouseCode))
                    dataRow[ctCOL_WarehouseCode] = stockExpansion.WarehouseCode;
                // �q�ɖ���
                if ((dataRow[ctCOL_WarehouseName] == DBNull.Value) || ((string)dataRow[ctCOL_WarehouseName] != stockExpansion.WarehouseName))
                    dataRow[ctCOL_WarehouseName] = stockExpansion.WarehouseName;
//                // �d����R�[�h
//                if ((dataRow[ctCOL_CustomerCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_CustomerCode] != stockExpansion.CustomerCode))
//                    dataRow[ctCOL_CustomerCode] = stockExpansion.CustomerCode;
//                // �d���於��
//                if ((dataRow[ctCOL_CustomerName] == DBNull.Value) || ((string)dataRow[ctCOL_CustomerName] != stockExpansion.CustomerName))
//                    dataRow[ctCOL_CustomerName] = stockExpansion.CustomerName;
//                // �d���於��2
//                if ((dataRow[ctCOL_CustomerName2] == DBNull.Value) || ((string)dataRow[ctCOL_CustomerName2] != stockExpansion.CustomerName2))
//                    dataRow[ctCOL_CustomerName2] = stockExpansion.CustomerName2;
                // �d����
                if ((dataRow[ctCOL_LastStockDate] == DBNull.Value) || ((DateTime)dataRow[ctCOL_LastStockDate] != stockExpansion.LastStockDate))
                    dataRow[ctCOL_LastStockDate] = stockExpansion.LastStockDate;

                int stockPointWay = GetStockPointWay();
                if ((stockPointWay == (int)ConstantManagement_Mobile.ct_StockPointWay.Average) ||
                    (stockPointWay == (int)ConstantManagement_Mobile.ct_StockPointWay.Last))
                {
                    //�ړ����ϖ@=>�݌Ƀ}�X�^�̎d���P�����S�̐ݒ�(�݌Ƀ}�X�^�Q��)
                    StockExpansion chkStock = new StockExpansion();
                    //�݌ɏ��ďo
                    int mode = GetEditMode();
                    string goodsNo = (string)dataRow[ctCOL_GoodsNo];
                    if (!String.IsNullOrEmpty(goodsNo))
                    {
                        GetStockInf(out chkStock, goodsNo, (Int32)dataRow[ctCOL_GoodsMakerCd], (string)dataRow[ctCOL_WarehouseCode], mode);
                    }

                    dataRow[ctCOL_StockUnitPrice] = chkStock.StockUnitPriceFl;
                }
                else
                {
                    // �d���P��
                    // 2008.01.17 �C�� >>>>>>>>>>>>>>>>>>>>
                    //if ((dataRow[ctCOL_StockUnitPrice] == DBNull.Value) || ((Int64)dataRow[ctCOL_StockUnitPrice] != stockExpansion.StockUnitPriceFl))
                    //    dataRow[ctCOL_StockUnitPrice] = stockExpansion.StockUnitPriceFl;
                    if ((dataRow[ctCOL_StockUnitPrice] == DBNull.Value) || ((Double)dataRow[ctCOL_StockUnitPrice] != stockExpansion.StockUnitPriceFl))
                        dataRow[ctCOL_StockUnitPrice] = stockExpansion.StockUnitPriceFl;
                    // 2008.01.17 �C�� <<<<<<<<<<<<<<<<<<<<
                }

                // ���[�J�[����
                if ((dataRow[ctCOL_MakerName] == DBNull.Value) || ((string)dataRow[ctCOL_MakerName] != stockExpansion.MakerName))
                    dataRow[ctCOL_MakerName] = stockExpansion.MakerName;
                // ���i�敪�O���[�v�R�[�h
                if ((dataRow[ctCOL_LargeGoodsGanreCode] == DBNull.Value) || ((string)dataRow[ctCOL_LargeGoodsGanreCode] != stockExpansion.LargeGoodsGanreCode))
                    dataRow[ctCOL_LargeGoodsGanreCode] = stockExpansion.LargeGoodsGanreCode;
                // ���i�敪�R�[�h
                if ((dataRow[ctCOL_MediumGoodsGanreCode] == DBNull.Value) || ((string)dataRow[ctCOL_MediumGoodsGanreCode] != stockExpansion.MediumGoodsGanreCode))
                    dataRow[ctCOL_MediumGoodsGanreCode] = stockExpansion.MediumGoodsGanreCode;
                // ���i�敪�ڍ׃R�[�h
                if ((dataRow[ctCOL_DetailGoodsGanreCode] == DBNull.Value) || ((string)dataRow[ctCOL_DetailGoodsGanreCode] != stockExpansion.DetailGoodsGanreCode))
                    dataRow[ctCOL_DetailGoodsGanreCode] = stockExpansion.DetailGoodsGanreCode;
                // �a�k���i�R�[�h
                //if ((dataRow[ctCOL_BLGoodsCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_BLGoodsCode] != stockExpansion.BLGoodsCode))
                //    dataRow[ctCOL_BLGoodsCode] = stockExpansion.BLGoodsCode;
                // �q�ɒI��
                if ((dataRow[ctCOL_WarehouseShelfNo] == DBNull.Value) || ((string)dataRow[ctCOL_WarehouseShelfNo] != stockExpansion.WarehouseShelfNo))
                    dataRow[ctCOL_WarehouseShelfNo] = stockExpansion.WarehouseShelfNo;

                // �sNo�t��
                if (dataRow[ctCOL_RowNum] == DBNull.Value)
                    dataRow[ctCOL_RowNum] = mainAdjustStockDtlFullView.Count + 1;


                // �ҏW���s�ɔ��f
                dataRow.EndEdit();
            }
            finally
            {
            }

            return dataRow;
        }
        // 2007.10.11 �ǉ� <<<<<<<<<<<<<<<<<<<<
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman�p�ɕύX

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �݌Ƀf�[�^�ϊ�����(UI�f�[�^��DataRow)[DataRow�w���]
        /// </summary>
        /// <param name="stock">�݌Ƀ}�X�^</param>
        /// <param name="dataRow">�f�[�^�s</param>
        /// <returns>DataRow</returns>
        /// <remarks>
        /// <br>Note       : �݌Ƀf�[�^��DataRow�ɕϊ����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// <br>Update Note: 2009/12/16 ��r��</br>
        /// <br>             PM.NS-5</br>
        /// <br>             �X�y�[�X��0�A����0.00�̏C��</br>
        /// </remarks>
        private static DataRow StockToDataRow(Stock stock, DataRow dataRow)
        {
            if (dataRow == null) dataRow = _mainProductStock.NewRow();

            try
            {
                // �_����폜�敪
                if ((dataRow[ctCOL_LogicalDeleteCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_LogicalDeleteCode] != stock.LogicalDeleteCode))
                    dataRow[ctCOL_LogicalDeleteCode] = stock.LogicalDeleteCode;
                
                dataRow.EndEdit();

                // �쐬����
                if ((dataRow[ctCOL_CreateDateTime] == DBNull.Value) || ((DateTime)dataRow[ctCOL_CreateDateTime] != stock.CreateDateTime))
                    dataRow[ctCOL_CreateDateTime] = stock.CreateDateTime;
                // �X�V����
                if ((dataRow[ctCOL_UpdateDateTime] == DBNull.Value) || ((DateTime)dataRow[ctCOL_UpdateDateTime] != stock.UpdateDateTime))
                    dataRow[ctCOL_UpdateDateTime] = stock.UpdateDateTime;
                // ��ƃR�[�h
                if ((dataRow[ctCOL_EnterpriseCode] == DBNull.Value) || ((string)dataRow[ctCOL_EnterpriseCode] != stock.EnterpriseCode))
                    dataRow[ctCOL_EnterpriseCode] = stock.EnterpriseCode;
                // GUID
                if ((dataRow[ctCOL_FileHeaderGuid] == DBNull.Value) || ((Guid)dataRow[ctCOL_FileHeaderGuid] != stock.FileHeaderGuid))
                    dataRow[ctCOL_FileHeaderGuid] = stock.FileHeaderGuid;
                // �X�V�]�ƈ��R�[�h
                if ((dataRow[ctCOL_UpdEmployeeCode] == DBNull.Value) || ((string)dataRow[ctCOL_UpdEmployeeCode] != stock.UpdEmployeeCode))
                    dataRow[ctCOL_UpdEmployeeCode] = stock.UpdEmployeeCode;
                // �X�V�A�Z���u��ID1
                if ((dataRow[ctCOL_UpdAssemblyId1] == DBNull.Value) || ((string)dataRow[ctCOL_UpdAssemblyId1] != stock.UpdAssemblyId1))
                    dataRow[ctCOL_UpdAssemblyId1] = stock.UpdAssemblyId1;
                // �X�V�A�Z���u��ID2
                if ((dataRow[ctCOL_UpdAssemblyId2] == DBNull.Value) || ((string)dataRow[ctCOL_UpdAssemblyId2] != stock.UpdAssemblyId2))
                    dataRow[ctCOL_UpdAssemblyId2] = stock.UpdAssemblyId2;
                // �_���폜�敪
                if ((dataRow[ctCOL_LogicalDeleteCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_LogicalDeleteCode] != stock.LogicalDeleteCode))
                    dataRow[ctCOL_LogicalDeleteCode] = stock.LogicalDeleteCode;
                // ���_�R�[�h
                if ((dataRow[ctCOL_SectionCode] == DBNull.Value) || ((string)dataRow[ctCOL_SectionCode] != stock.SectionCode))
                    dataRow[ctCOL_SectionCode] = stock.SectionCode;
                // �sNo�t��
                if (dataRow[ctCOL_RowNum] == DBNull.Value)
                    dataRow[ctCOL_RowNum] = mainAdjustStockDtlFullView.Count + 1;
                // �i��
                if ((dataRow[ctCOL_GoodsNo] == DBNull.Value) || ((string)dataRow[ctCOL_GoodsNo] != stock.GoodsNo))
                    dataRow[ctCOL_GoodsNo] = stock.GoodsNo;
                // �i��
                if ((dataRow[ctCOL_GoodsName] == DBNull.Value) || ((string)dataRow[ctCOL_GoodsName] != stock.GoodsName))
                    dataRow[ctCOL_GoodsName] = stock.GoodsName;
                // BL�R�[�h
                
                //// ���[�J�[�R�[�h
                //if ((dataRow[ctCOL_GoodsMakerCd] == DBNull.Value) || ((Int32)dataRow[ctCOL_GoodsMakerCd] != stock.GoodsMakerCd))
                //    dataRow[ctCOL_GoodsMakerCd] = stock.GoodsMakerCd;
                // �d����

                // �W�����i

                // --- DEL 2009/12/16 ---------->>>>>
                //�X�y�[�X�ł͂Ȃ�0�A����0.00��\������悤�ɏC������
                // ���P��
                //dataRow[ctCOL_StockUnitPrice] = stock.StockUnitPriceFl;

                // �d����
                //if ((dataRow[ctCOL_SalesOrderUnit] == DBNull.Value) || ((Double)dataRow[ctCOL_SalesOrderUnit] != stock.SalesOrderUnit))
                //dataRow[ctCOL_SalesOrderUnit] = stock.SalesOrderUnit;
                // �d���㐔
                //if ((dataRow[ctCOL_AfSalesOrderUnit] == DBNull.Value) || ((Double)dataRow[ctCOL_AfSalesOrderUnit] != ((Double)stock.SalesOrderUnit + stock.ShipmentPosCnt)))
                //dataRow[ctCOL_AfSalesOrderUnit] = stock.SalesOrderUnit;
                //--- DEL 2009/12/16 ----------<<<<<
                // �q�ɒI��
                if ((dataRow[ctCOL_WarehouseShelfNo] == DBNull.Value) || ((string)dataRow[ctCOL_WarehouseShelfNo] != stock.WarehouseShelfNo))
                    dataRow[ctCOL_WarehouseShelfNo] = stock.WarehouseShelfNo;
                //// �����c
                //if ((dataRow[ctCOL_SalesOrderCount] == DBNull.Value) || ((Double)dataRow[ctCOL_SalesOrderCount] != stock.SalesOrderCount))
                //    dataRow[ctCOL_SalesOrderCount] = stock.SalesOrderCount;
                //// �݌ɐ�
                //if ((dataRow[ctCOL_SupplierStock] == DBNull.Value) || ((Double)dataRow[ctCOL_SupplierStock] != stock.ShipmentPosCnt))
                //    dataRow[ctCOL_SupplierStock] = stock.ShipmentPosCnt;
                // �ύX�O�݌ɐ�
                if ((dataRow[ctCOL_BfSupplierStock] == DBNull.Value) || ((Double)dataRow[ctCOL_BfSupplierStock] != stock.ShipmentPosCnt))
                    dataRow[ctCOL_BfSupplierStock] = stock.ShipmentPosCnt;
                // �q�ɃR�[�h
                if ((dataRow[ctCOL_WarehouseCode] == DBNull.Value) || ((string)dataRow[ctCOL_WarehouseCode] != stock.WarehouseCode))
                    dataRow[ctCOL_WarehouseCode] = stock.WarehouseCode;
                // ���ה��l

                // �ҏW���s�ɔ��f
                dataRow.EndEdit();
            }
            finally
            {
            }

            return dataRow;
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        #region �݌Ƀf�[�^�ϊ�����(DataRow��StockWork)
        /// <summary>
        /// ���ԍ݌Ƀf�[�^�ϊ�����(DataRow��Stock)
        /// </summary>
        /// <br>Note       : �݌ɏ��(KEY�����̂�)�쐬</br>/// 
        /// <param name="dataRow"></param>
        /// <returns></returns>
        private static Stock DataRowToStock(DataRow dataRow)
        {
            Stock stock = new Stock();
            // ��ƃR�[�h
            stock.EnterpriseCode = (dataRow[ctCOL_EnterpriseCode] != DBNull.Value) ? (string)dataRow[ctCOL_EnterpriseCode] : "";
            // ���_�R�[�h
            stock.SectionCode = (dataRow[ctCOL_SectionCode] != DBNull.Value) ? (string)dataRow[ctCOL_SectionCode] : "";
            // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //// ���[�J�[�R�[�h
            //stock.MakerCode = (dataRow[ctCOL_MakerCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_MakerCode] : 0;
            //// ���i�R�[�h
            //stock.GoodsCode = (dataRow[ctCOL_GoodsCode] != DBNull.Value) ? (string)dataRow[ctCOL_GoodsCode] : "";
            // ���[�J�[�R�[�h
            stock.GoodsMakerCd = (dataRow[ctCOL_GoodsMakerCd] != DBNull.Value) ? (Int32)dataRow[ctCOL_GoodsMakerCd] : 0;
            // ���i�R�[�h
            stock.GoodsNo = (dataRow[ctCOL_GoodsNo] != DBNull.Value) ? (string)dataRow[ctCOL_GoodsNo] : "";
            // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            return stock;
        }
        #endregion
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #region 2007.10.11 �폜
        // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
        #region ���ԍ݌Ƀf�[�^�ϊ�
        /*
        /// <summary>
		/// ���ԍ݌Ƀf�[�^�ϊ�
		/// </summary>
		/// <param name="dataRow"></param>
		/// <returns></returns>
		private static ProductStock DataRowToProductStock(DataRow dataRow,int mode)
		{
			ProductStock productStock = new ProductStock();

			// �쐬����
			productStock.CreateDateTime = (dataRow[ctCOL_CreateDateTime] != DBNull.Value) ? (DateTime)dataRow[ctCOL_CreateDateTime] : DateTime.MinValue;
			// �X�V����
			productStock.UpdateDateTime = (dataRow[ctCOL_UpdateDateTime] != DBNull.Value) ? (DateTime)dataRow[ctCOL_UpdateDateTime] : DateTime.MinValue;
			// ��ƃR�[�h
			productStock.EnterpriseCode = (dataRow[ctCOL_EnterpriseCode] != DBNull.Value) ? (string)dataRow[ctCOL_EnterpriseCode] : "";
			// GUID
			productStock.FileHeaderGuid = (dataRow[ctCOL_FileHeaderGuid] != DBNull.Value) ? (Guid)dataRow[ctCOL_FileHeaderGuid] : Guid.Empty;
			// �X�V�]�ƈ��R�[�h
			productStock.UpdEmployeeCode = (dataRow[ctCOL_UpdEmployeeCode] != DBNull.Value) ? (string)dataRow[ctCOL_UpdEmployeeCode] : "";
			// �X�V�A�Z���u��ID1
			productStock.UpdAssemblyId1 = (dataRow[ctCOL_UpdAssemblyId1] != DBNull.Value) ? (string)dataRow[ctCOL_UpdAssemblyId1] : "";
			// �X�V�A�Z���u��ID2
			productStock.UpdAssemblyId2 = (dataRow[ctCOL_UpdAssemblyId2] != DBNull.Value) ? (string)dataRow[ctCOL_UpdAssemblyId2] : "";
			// �_���폜�敪
			productStock.LogicalDeleteCode = (dataRow[ctCOL_LogicalDeleteCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_LogicalDeleteCode] : 0;
            // ���_�R�[�h
            productStock.SectionCode = (dataRow[ctCOL_SectionCode] != DBNull.Value) ? (string)dataRow[ctCOL_SectionCode] : "";
            // ���[�J�[�R�[�h
            productStock.MakerCode = (dataRow[ctCOL_MakerCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_MakerCode] : 0;
            // ���i�R�[�h
            productStock.GoodsCode = (dataRow[ctCOL_GoodsCode] != DBNull.Value) ? (string)dataRow[ctCOL_GoodsCode] : "";
            // ���i����
            productStock.GoodsName = (dataRow[ctCOL_GoodsName] != DBNull.Value) ? (string)dataRow[ctCOL_GoodsName] : "";
            // �����ԍ�
            productStock.ProductNumber = (dataRow[ctCOL_ProductNumber] != DBNull.Value) ? (string)dataRow[ctCOL_ProductNumber] : "";
            // �����ԍ��}�X�^GUID
            productStock.ProductStockGuid = (dataRow[ctCOL_ProductStockGuid] != DBNull.Value) ? (Guid)dataRow[ctCOL_ProductStockGuid] : Guid.Empty;
            // �݌ɋ敪
            productStock.StockDiv = (dataRow[ctCOL_StockDiv] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockDiv] : 0;
            // �q�ɃR�[�h
            productStock.WarehouseCode = (dataRow[ctCOL_WarehouseCode] != DBNull.Value) ? (string)dataRow[ctCOL_WarehouseCode] : "";
            // �q�ɖ���
            productStock.WarehouseName = (dataRow[ctCOL_WarehouseName] != DBNull.Value) ? (string)dataRow[ctCOL_WarehouseName] : "";
            // ���Ǝ҃R�[�h
            productStock.CarrierEpCode = (dataRow[ctCOL_CarrierEpCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_CarrierEpCode] : 0;
            // ���ƎҖ���
            productStock.CarrierEpName = (dataRow[ctCOL_CarrierEpName] != DBNull.Value) ? (string)dataRow[ctCOL_CarrierEpName] : "";
            // ���Ӑ�R�[�h
            productStock.CustomerCode = (dataRow[ctCOL_CustomerCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_CustomerCode] : 0;
            // ���Ӑ於��
            productStock.CustomerName = (dataRow[ctCOL_CustomerName] != DBNull.Value) ? (string)dataRow[ctCOL_CustomerName] : "";
            // ���Ӑ於��2
            productStock.CustomerName2 = (dataRow[ctCOL_CustomerName2] != DBNull.Value) ? (string)dataRow[ctCOL_CustomerName2] : "";
            // �d����
            productStock.StockDate = (dataRow[ctCOL_StockDate] != DBNull.Value) ? (DateTime)dataRow[ctCOL_StockDate] : DateTime.MinValue;
            // ���ד�
            productStock.ArrivalGoodsDay = (dataRow[ctCOL_ArrivalGoodsDay] != DBNull.Value) ? (DateTime)dataRow[ctCOL_ArrivalGoodsDay] : DateTime.MinValue;
            // �d���P��
            // �݌ɕ]�����@�ɂ���ĕς���(����݌ɂ͂Ȃ�)
            if (productStock.StockDiv == 0)
            {
                int pointWay = GetStockPointWay();

                if (pointWay == 1)
                {
                    //�ŏI�d���@
                    productStock.StockUnitPrice = (dataRow[ctCOL_StockUnitPrice] != DBNull.Value) ? (Int64)dataRow[ctCOL_StockUnitPrice] : 0;
                }
                else if (pointWay == 3)
                {
                    //�ʒP���@
                    productStock.StockUnitPrice = (dataRow[ctCOL_StockUnitPrice] != DBNull.Value) ? (Int64)dataRow[ctCOL_StockUnitPrice] : 0;
                }
                else if (pointWay == 2)
                {
                    //�ړ����ϖ@
                    //�ύX�ł��Ȃ�!                    
                    productStock.StockUnitPrice = (dataRow[ctCOL_StockUnitPrice] != DBNull.Value) ? (Int64)dataRow[ctCOL_StockUnitPrice] : 0;
                }
            }
            else
            {
                productStock.StockUnitPrice = (dataRow[ctCOL_StockUnitPrice] != DBNull.Value) ? (Int64)dataRow[ctCOL_StockUnitPrice] : 0;
            }
            // �ېŋ敪
            productStock.TaxationCode = (dataRow[ctCOL_TaxationCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_TaxationCode] : 0;
            // �݌ɏ��
            if ((mode != ctMode_StockAdjust) && (mode != ctMode_TrustAdjust))
            {
                productStock.StockState = (dataRow[ctCOL_StockState] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockState] : 0;
            }
            else
            {
                productStock.StockState = 81;//����
            }
            // �ړ����
            productStock.MoveStatus = (dataRow[ctCOL_MoveStatus] != DBNull.Value) ? (Int32)dataRow[ctCOL_MoveStatus] : 0;
            // ���i���
            if (mode != ctMode_GoodsCodeStatus)
            {
                productStock.GoodsCodeStatus = (dataRow[ctCOL_GoodsCodeStatus] != DBNull.Value) ? (Int32)dataRow[ctCOL_GoodsCodeStatus] : 0;
            }
            else
            {
                productStock.GoodsCodeStatus = (dataRow[ctCOL_GoodsCodeStatus] != DBNull.Value) ? (Int32)dataRow[ctCOL_GoodsCodeStatus] : 0;
            }
            // ���i�d�b�ԍ�1
            productStock.StockTelNo1 = (dataRow[ctCOL_StockTelNo1] != DBNull.Value) ? (string)dataRow[ctCOL_StockTelNo1] : "";
            // ���i�d�b�ԍ�2
            productStock.StockTelNo2 = (dataRow[ctCOL_StockTelNo2] != DBNull.Value) ? (string)dataRow[ctCOL_StockTelNo2] : "";
            // �����敪
            productStock.RomDiv = (dataRow[ctCOL_RomDiv] != DBNull.Value) ? (Int32)dataRow[ctCOL_RomDiv] : 0;
            // �@��R�[�h
            productStock.CellphoneModelCode = (dataRow[ctCOL_CellphoneModelCode] != DBNull.Value) ? (string)dataRow[ctCOL_CellphoneModelCode] : "";
            // �@�햼��
            productStock.CellphoneModelName = (dataRow[ctCOL_CellphoneModelName] != DBNull.Value) ? (string)dataRow[ctCOL_CellphoneModelName] : "";
            // �L�����A�R�[�h
            productStock.CarrierCode = (dataRow[ctCOL_CarrierCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_CarrierCode] : 0;
            // �L�����A����
            productStock.CarrierName = (dataRow[ctCOL_CarrierName] != DBNull.Value) ? (string)dataRow[ctCOL_CarrierName] : "";
            // ���[�J�[����
            productStock.MakerName = (dataRow[ctCOL_MakerName] != DBNull.Value) ? (string)dataRow[ctCOL_MakerName] : "";
            // �n���F�R�[�h
            productStock.SystematicColorCd = (dataRow[ctCOL_SystematicColorCd] != DBNull.Value) ? (Int32)dataRow[ctCOL_SystematicColorCd] : 0;
            // �n���F����
            productStock.SystematicColorNm = (dataRow[ctCOL_SystematicColorNm] != DBNull.Value) ? (string)dataRow[ctCOL_SystematicColorNm] : "";
            // ���i�啪�ރR�[�h
            productStock.LargeGoodsGanreCode = (dataRow[ctCOL_LargeGoodsGanreCode] != DBNull.Value) ? (string)dataRow[ctCOL_LargeGoodsGanreCode] : "";
            // ���i�����ރR�[�h
            productStock.MediumGoodsGanreCode = (dataRow[ctCOL_MediumGoodsGanreCode] != DBNull.Value) ? (string)dataRow[ctCOL_MediumGoodsGanreCode] : "";
            // �o�א擾�Ӑ�R�[�h
            productStock.ShipCustomerCode= (dataRow[ctCOL_ShipCustomerCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_ShipCustomerCode] : 0;
            // �o�א擾�Ӑ於��
            productStock.ShipCustomerName = (dataRow[ctCOL_ShipCustomerName] != DBNull.Value) ? (string)dataRow[ctCOL_ShipCustomerName] : "";
            // �o�א擾�Ӑ於��2
            productStock.ShipCustomerName2 = (dataRow[ctCOL_ShipCustomerName2] != DBNull.Value) ? (string)dataRow[ctCOL_ShipCustomerName2] : "";

            return productStock;
		}
        */
		#endregion
        // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region DEL 2008/07/24 Partsman�p�ɕύX
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �݌ɒ����f�[�^�ϊ�
        /// </summary>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        private static StockAdjust DataRowToStockAdjust(DataRow dataRow, int mode, string setMsg)
        {
            StockAdjust stockAdjust = new StockAdjust();

            // �쐬����            
            stockAdjust.CreateDateTime = (dataRow[ctCOL_CreateDateTime] != DBNull.Value) ? (DateTime)dataRow[ctCOL_CreateDateTime] : DateTime.MinValue;
            // �X�V����

            stockAdjust.UpdateDateTime = DateTime.Now;
            // ��ƃR�[�h
            stockAdjust.EnterpriseCode = (dataRow[ctCOL_EnterpriseCode] != DBNull.Value) ? (string)dataRow[ctCOL_EnterpriseCode] : "";
            // GUID

            // �X�V�]�ƈ��R�[�h
            stockAdjust.UpdEmployeeCode = (dataRow[ctCOL_UpdEmployeeCode] != DBNull.Value) ? (string)dataRow[ctCOL_UpdEmployeeCode] : "";
            // �X�V�A�Z���u��ID1
            stockAdjust.UpdAssemblyId1 = (dataRow[ctCOL_UpdAssemblyId1] != DBNull.Value) ? (string)dataRow[ctCOL_UpdAssemblyId1] : "";
            // �X�V�A�Z���u��ID2
            stockAdjust.UpdAssemblyId2 = (dataRow[ctCOL_UpdAssemblyId2] != DBNull.Value) ? (string)dataRow[ctCOL_UpdAssemblyId2] : "";
            // �_���폜�敪
            stockAdjust.LogicalDeleteCode = (dataRow[ctCOL_LogicalDeleteCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_LogicalDeleteCode] : 0;
            // ���_�R�[�h
            stockAdjust.SectionCode = GetSection();
            // �݌ɒ����`�[�ԍ�
            // �󕥌��`�[�敪
            stockAdjust.AcPaySlipCd = 40;// ����
            // �󕥌�����敪
            int setCd = 0;
            switch (mode)
            {
                case ctMode_StockAdjust://����
                    // 2008.01.17 �폜 >>>>>>>>>>>>>>>>>>>>
                    //case ctMode_TrustAdjust:
                    // 2008.01.17 �폜 <<<<<<<<<<<<<<<<<<<<
                    {
                        setCd = 30;
                        break;
                    }
                // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                //case ctMode_ProductReEdit://����
                //    {
                //        setCd = 32;
                //        break;
                //    }
                // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                case ctMode_UnitPriceReEdit://��������
                    {
                        setCd = 31;
                        break;
                    }
                // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                //case ctMode_GoodsCodeStatus://�s�Ǖi
                //    {
                //        setCd = 33;
                //        break;
                //    }
                // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                // 2007.10.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
                case ctMode_ShelfNoReEdit://�I��
                    {
                        setCd = 40;
                        break;
                    }
                // 2007.10.11 �ǉ� <<<<<<<<<<<<<<<<<<<<
            }
            stockAdjust.AcPayTransCd = setCd;
            // �������t
            stockAdjust.AdjustDate = GetDate();
            // ���͒S���҃R�[�h
            stockAdjust.InputAgenCd = LoginInfoAcquisition.Employee.EmployeeCode;
            stockAdjust.InputAgenCd = GetInputAgent().EmployeeCode;
            // ���͒S���Җ���
            stockAdjust.InputAgenNm = LoginInfoAcquisition.Employee.Name;
            stockAdjust.InputAgenNm = GetInputAgent().Name;
            // �`�[���l
            stockAdjust.SlipNote = setMsg;

            return stockAdjust;
        }

        /// <summary>
        /// �݌ɒ������׃f�[�^�ϊ�
        /// </summary>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        private static StockAdjustDtl DataRowToStockAdjustDtl(DataRow dataRow, int mode, int rowCnt)
        {
            StockAdjustDtl stockAdjustDtl = new StockAdjustDtl();

            // �쐬����
            stockAdjustDtl.CreateDateTime = (dataRow[ctCOL_CreateDateTime] != DBNull.Value) ? (DateTime)dataRow[ctCOL_CreateDateTime] : DateTime.MinValue;
            // �X�V����
            stockAdjustDtl.UpdateDateTime = (dataRow[ctCOL_UpdateDateTime] != DBNull.Value) ? (DateTime)dataRow[ctCOL_UpdateDateTime] : DateTime.MinValue;
            // ��ƃR�[�h
            stockAdjustDtl.EnterpriseCode = (dataRow[ctCOL_EnterpriseCode] != DBNull.Value) ? (string)dataRow[ctCOL_EnterpriseCode] : "";
            // GUID
            stockAdjustDtl.FileHeaderGuid = (dataRow[ctCOL_FileHeaderGuid] != DBNull.Value) ? (Guid)dataRow[ctCOL_FileHeaderGuid] : Guid.Empty;
            // �X�V�]�ƈ��R�[�h
            stockAdjustDtl.UpdEmployeeCode = (dataRow[ctCOL_UpdEmployeeCode] != DBNull.Value) ? (string)dataRow[ctCOL_UpdEmployeeCode] : "";
            // �X�V�A�Z���u��ID1
            stockAdjustDtl.UpdAssemblyId1 = (dataRow[ctCOL_UpdAssemblyId1] != DBNull.Value) ? (string)dataRow[ctCOL_UpdAssemblyId1] : "";
            // �X�V�A�Z���u��ID2
            stockAdjustDtl.UpdAssemblyId2 = (dataRow[ctCOL_UpdAssemblyId2] != DBNull.Value) ? (string)dataRow[ctCOL_UpdAssemblyId2] : "";
            // �_���폜�敪
            stockAdjustDtl.LogicalDeleteCode = (dataRow[ctCOL_LogicalDeleteCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_LogicalDeleteCode] : 0;
            // ���_�R�[�h
            stockAdjustDtl.SectionCode = GetSection();
            // �݌ɒ����`�[�ԍ�
            stockAdjustDtl.StockAdjustSlipNo = 0;
            // �݌ɒ����s�ԍ�
            stockAdjustDtl.StockAdjustRowNo = rowCnt;
            // �󕥌��`�[�敪
            stockAdjustDtl.AcPaySlipCd = 40;
            // �󕥌�����敪
            switch (mode)
            {
                case ctMode_StockAdjust:
                    {
                        //�d������
                        stockAdjustDtl.AcPayTransCd = 30;
                        break;
                    }
                // 2008.01.17 �폜 >>>>>>>>>>>>>>>>>>>>
                //case ctMode_TrustAdjust:
                //    {
                //        //�������
                //        stockAdjustDtl.AcPayTransCd = 30;
                //        break;
                //    }
                // 2008.01.17 �폜 <<<<<<<<<<<<<<<<<<<<

                // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                //case ctMode_ProductReEdit:
                //    {
                //        //���Ԓ���
                //        stockAdjustDtl.AcPayTransCd = 32;
                //        break;
                //    }
                // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                case ctMode_UnitPriceReEdit:
                    {
                        //��������
                        stockAdjustDtl.AcPayTransCd = 31;
                        break;
                    }
                // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                //case ctMode_GoodsCodeStatus:
                //    {
                //        //�s�Ǖi
                //        stockAdjustDtl.AcPayTransCd = 33;
                //        break;
                //    }
                // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                // 2007.10.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
                case ctMode_ShelfNoReEdit:
                    {
                        //�I��
                        stockAdjustDtl.AcPayTransCd = 40;
                        break;
                    }
                // 2007.10.11 �ǉ� <<<<<<<<<<<<<<<<<<<<
            }

            // �������t
            stockAdjustDtl.AdjustDate = GetDate();
            // ���[�J�[�R�[�h
            // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //stockAdjustDtl.MakerCode = (dataRow[ctCOL_MakerCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_MakerCode] : 0;
            stockAdjustDtl.GoodsMakerCd = (dataRow[ctCOL_GoodsMakerCd] != DBNull.Value) ? (Int32)dataRow[ctCOL_GoodsMakerCd] : 0;
            // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            // ���[�J�[����
            stockAdjustDtl.MakerName = (dataRow[ctCOL_MakerName] != DBNull.Value) ? (string)dataRow[ctCOL_MakerName] : "";
            // ���i�R�[�h
            // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //stockAdjustDtl.GoodsCode = (dataRow[ctCOL_GoodsCode] != DBNull.Value) ? (string)dataRow[ctCOL_GoodsCode] : "";
            stockAdjustDtl.GoodsNo = (dataRow[ctCOL_GoodsNo] != DBNull.Value) ? (string)dataRow[ctCOL_GoodsNo] : "";
            // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            // ���i����
            stockAdjustDtl.GoodsName = (dataRow[ctCOL_GoodsName] != DBNull.Value) ? (string)dataRow[ctCOL_GoodsName] : "";
            // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// ���ԊǗ��敪                        
            //stockAdjustDtl.PrdNumMngDiv = (dataRow[ctCOL_PrdNumMngDiv] != DBNull.Value) ? (Int32)dataRow[ctCOL_PrdNumMngDiv] : 0 ;�@//�݌Ƀ}�X�^�̐��ԊǗ��敪�ɏ]��
            //// �����ԍ�
            //stockAdjustDtl.ProductNumber = (dataRow[ctCOL_ProductNumber] != DBNull.Value) ? (string)dataRow[ctCOL_ProductNumber] : "";
            //// �ύX�O�����ԍ�            
            //stockAdjustDtl.BfProductNumber = (dataRow[ctCOL_BfProductNumber] != DBNull.Value) ? (string)dataRow[ctCOL_BfProductNumber] : "";
            // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
            // 2008.01.17 �C�� >>>>>>>>>>>>>>>>>>>>
            //if (mode != ctMode_TrustAdjust)
            //{
            //    // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //    //// �d���P�� �� �C���P��(�����������̂�)
            //    //stockAdjustDtl.StockUnitPrice = (dataRow[ctCOL_StockUnitPrice] != DBNull.Value) ? (Int64)dataRow[ctCOL_StockUnitPrice] : 0;
            //    //// �ύX�O�d���P��
            //    //stockAdjustDtl.BfStockUnitPrice = (dataRow[ctCOL_BfStockUnitPrice] != DBNull.Value) ? (Int64)dataRow[ctCOL_BfStockUnitPrice] : 0;
            //    // �d���P�� �� �C���P��(�����������̂�)
            //    stockAdjustDtl.StockUnitPriceFl = (dataRow[ctCOL_StockUnitPrice] != DBNull.Value) ? (Int64)dataRow[ctCOL_StockUnitPrice] : 0;
            //    // �ύX�O�d���P��
            //    stockAdjustDtl.BfStockUnitPriceFl = (dataRow[ctCOL_BfStockUnitPrice] != DBNull.Value) ? (Int64)dataRow[ctCOL_BfStockUnitPrice] : 0;
            //    // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            //}
            // �d���P�� �� �C���P��(�����������̂�)
            stockAdjustDtl.StockUnitPriceFl = (dataRow[ctCOL_StockUnitPrice] != DBNull.Value) ? (Double)dataRow[ctCOL_StockUnitPrice] : 0;
            // �ύX�O�d���P��
            stockAdjustDtl.BfStockUnitPriceFl = (dataRow[ctCOL_BfStockUnitPrice] != DBNull.Value) ? (Double)dataRow[ctCOL_BfStockUnitPrice] : 0;
            // 2008.01.17 �C�� <<<<<<<<<<<<<<<<<<<<
            // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// ���i�d�b�ԍ�1
            //stockAdjustDtl.StockTelNo1 = (dataRow[ctCOL_StockTelNo1] != DBNull.Value) ? (string)dataRow[ctCOL_StockTelNo1] : "";
            //// �ύX�O���i�d�b�ԍ�1 �ύX�Ȃ�
            //
            //// ���i�d�b�ԍ�2
            //stockAdjustDtl.StockTelNo2 = (dataRow[ctCOL_StockTelNo2] != DBNull.Value) ? (string)dataRow[ctCOL_StockTelNo2] : "";
            //// �ύX�O���i�`�[�ԍ�2 �ύX�Ȃ�
            // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<

            // �d���݌ɐ�
            if (mode == ctMode_StockAdjust)
            {
                if (dataRow[ctCOL_AdjustCount] != DBNull.Value)
                {
                    stockAdjustDtl.SupplierStock = (dataRow[ctCOL_SupplierStock] != DBNull.Value) ?
                                                   (double)dataRow[ctCOL_SupplierStock] + (double)dataRow[ctCOL_AdjustCount] : 0;
                    stockAdjustDtl.TrustCount = (dataRow[ctCOL_TrustCount]) != DBNull.Value ? (double)dataRow[ctCOL_TrustCount] : 0;
                }
                else
                {
                    stockAdjustDtl.SupplierStock = (dataRow[ctCOL_SupplierStock] != DBNull.Value) ?
                                                   (double)dataRow[ctCOL_SupplierStock] : 0;
                    stockAdjustDtl.TrustCount = (dataRow[ctCOL_TrustCount]) != DBNull.Value ? (double)dataRow[ctCOL_TrustCount] : 0;
                }

                // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //// �݌ɏ��
                //stockAdjustDtl.StockState = (int)ConstantManagement_Mobile.ct_StockState.Deletion;
                // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<

                // �݌ɋ敪
                stockAdjustDtl.StockDiv = (int)ConstantManagement_Mobile.ct_StockDiv.Company;
            }
            // 2008.01.17 �폜 >>>>>>>>>>>>>>>>>>>>
            //else if (mode == ctMode_TrustAdjust)
            //{
            //    if (dataRow[ctCOL_AdjustCount] != DBNull.Value)
            //    {
            //        //����������
            //        stockAdjustDtl.SupplierStock = (dataRow[ctCOL_SupplierStock] != DBNull.Value) ? (double)dataRow[ctCOL_SupplierStock] : 0;
            //        stockAdjustDtl.TrustCount = (dataRow[ctCOL_TrustCount] != DBNull.Value) ?
            //            (double)dataRow[ctCOL_TrustCount] + (double)dataRow[ctCOL_AdjustCount] : 0;
            //    }
            //    else
            //    {
            //        stockAdjustDtl.SupplierStock = (dataRow[ctCOL_SupplierStock] != DBNull.Value) ?
            //                                       (double)dataRow[ctCOL_SupplierStock] : 0;
            //        stockAdjustDtl.TrustCount = (dataRow[ctCOL_TrustCount]) != DBNull.Value ? (double)dataRow[ctCOL_TrustCount] : 0;
            //    }
            //    // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //    //// �݌ɏ��
            //    //stockAdjustDtl.StockState = (int)ConstantManagement_Mobile.ct_StockState.Deletion;
            //    // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<

            //    // �݌ɋ敪
            //    stockAdjustDtl.StockDiv = (int)ConstantManagement_Mobile.ct_StockDiv.Trust;

            //}
            // 2008.01.17 �폜 <<<<<<<<<<<<<<<<<<<<
            else if (mode == ctMode_UnitPriceReEdit) //��������
            {
                if (dataRow[ctCOL_AdjustCount] != DBNull.Value)
                {
                    stockAdjustDtl.TrustCount = (dataRow[ctCOL_TrustCount] != DBNull.Value) ?
                                                   (double)dataRow[ctCOL_TrustCount] + (double)dataRow[ctCOL_AdjustCount] : 0;
                    stockAdjustDtl.SupplierStock = (dataRow[ctCOL_SupplierStock]) != DBNull.Value ? (double)dataRow[ctCOL_SupplierStock] : 0;
                }
                else
                {
                    stockAdjustDtl.TrustCount = (dataRow[ctCOL_TrustCount] != DBNull.Value) ?
                                                   (double)dataRow[ctCOL_TrustCount] : 0;
                    stockAdjustDtl.SupplierStock = (dataRow[ctCOL_SupplierStock]) != DBNull.Value ? (double)dataRow[ctCOL_SupplierStock] : 0;
                }
                // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //// �݌ɏ��
                //stockAdjustDtl.StockState = (dataRow[ctCOL_StockState] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockState] : 0;
                // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<

                // �݌ɋ敪 (����͌��������ł��Ȃ�)
                stockAdjustDtl.StockDiv = (dataRow[ctCOL_StockDiv] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockDiv] : 0;

            }
            else
            {
                stockAdjustDtl.SupplierStock = (dataRow[ctCOL_SupplierStock]) != DBNull.Value ? (double)dataRow[ctCOL_SupplierStock] : 0;
                stockAdjustDtl.TrustCount = (dataRow[ctCOL_TrustCount]) != DBNull.Value ? (double)dataRow[ctCOL_TrustCount] : 0;
                // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //// �݌ɏ��
                //stockAdjustDtl.StockState = (dataRow[ctCOL_StockState] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockState] : 0;
                // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<

                // �݌ɋ敪
                stockAdjustDtl.StockDiv = (dataRow[ctCOL_StockDiv] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockDiv] : 0;
            }

            // ������
            stockAdjustDtl.AdjustCount = (dataRow[ctCOL_AdjustCount] != DBNull.Value) ? (double)dataRow[ctCOL_AdjustCount] : 0;
            // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �ύX�O�݌ɏ��
            //stockAdjustDtl.BfStockState = (dataRow[ctCOL_StockState] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockState] : 0;
            //// ���i���
            //stockAdjustDtl.GoodsCodeStatus = (dataRow[ctCOL_GoodsCodeStatus] != DBNull.Value) ? (Int32)dataRow[ctCOL_GoodsCodeStatus] : 0;
            //// �����ԍ��}�X�^GUID
            //stockAdjustDtl.ProductStockGuid = (dataRow[ctCOL_ProductStockGuid] != DBNull.Value) ? (Guid)dataRow[ctCOL_ProductStockGuid] : Guid.Empty;
            // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
            // ���ה��l
            // 2008.01.17 �ǉ� >>>>>>>>>>>>>>>>>>>>
            stockAdjustDtl.DtlNote = (dataRow[ctCOL_DtlNote] != DBNull.Value) ? (string)dataRow[ctCOL_DtlNote] : "";
            // 2008.01.17 �ǉ� <<<<<<<<<<<<<<<<<<<<

            // 2007.10.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
            // �q�ɃR�[�h
            stockAdjustDtl.WarehouseCode = (dataRow[ctCOL_WarehouseCode] != DBNull.Value) ? (string)dataRow[ctCOL_WarehouseCode] : "";
            // �q�ɖ���
            stockAdjustDtl.WarehouseName = (dataRow[ctCOL_WarehouseName] != DBNull.Value) ? (string)dataRow[ctCOL_WarehouseName] : "";
            // �q�ɒI��
            stockAdjustDtl.WarehouseShelfNo = (dataRow[ctCOL_WarehouseShelfNo] != DBNull.Value) ? (string)dataRow[ctCOL_WarehouseShelfNo] : "";
            // �a�k���i�R�[�h
            stockAdjustDtl.BLGoodsCode = (dataRow[ctCOL_BLGoodsCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_BLGoodsCode] : 0;
            // 2007.10.11 �ǉ� <<<<<<<<<<<<<<<<<<<<

            // 2008.02.15 �ǉ� >>>>>>>>>>>>>>>>>>>>
            // �艿
            stockAdjustDtl.ListPriceFl = GetGoodsListPrice(stockAdjustDtl.EnterpriseCode, stockAdjustDtl.GoodsMakerCd, stockAdjustDtl.GoodsNo, stockAdjustDtl.AdjustDate);
            // 2008.02.15 �ǉ� <<<<<<<<<<<<<<<<<<<<

            return stockAdjustDtl;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman�p�ɕύX

        #region 2007.10.11 �폜
        // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
        #region ���ԍ݌Ƀf�[�^�ϊ�����(DataRow�����[�N)
        /*
		/// <summary>
		/// ���ԍ݌Ƀf�[�^�ϊ�����(DataRow�����[�N)
		/// </summary>
		/// <param name="dataRow"></param>
		/// <returns></returns>
		private static ProductStockWork DataRowToSlipDtlWork(DataRow dataRow)
		{
			ProductStockWork productStockWork = new ProductStockWork();

			// �쐬����
			productStockWork.CreateDateTime = (dataRow[ctCOL_CreateDateTime] != DBNull.Value) ? (DateTime)dataRow[ctCOL_CreateDateTime] : DateTime.MinValue;
			// �X�V����
			productStockWork.UpdateDateTime = (dataRow[ctCOL_UpdateDateTime] != DBNull.Value) ? (DateTime)dataRow[ctCOL_UpdateDateTime] : DateTime.MinValue;
			// ��ƃR�[�h
			productStockWork.EnterpriseCode = (dataRow[ctCOL_EnterpriseCode] != DBNull.Value) ? (string)dataRow[ctCOL_EnterpriseCode] : "";
			// GUID
			productStockWork.FileHeaderGuid = (dataRow[ctCOL_FileHeaderGuid] != DBNull.Value) ? (Guid)dataRow[ctCOL_FileHeaderGuid] : Guid.Empty;
			// �X�V�]�ƈ��R�[�h
			productStockWork.UpdEmployeeCode = (dataRow[ctCOL_UpdEmployeeCode] != DBNull.Value) ? (string)dataRow[ctCOL_UpdEmployeeCode] : "";
			// �X�V�A�Z���u��ID1
			productStockWork.UpdAssemblyId1 = (dataRow[ctCOL_UpdAssemblyId1] != DBNull.Value) ? (string)dataRow[ctCOL_UpdAssemblyId1] : "";
			// �X�V�A�Z���u��ID2
			productStockWork.UpdAssemblyId2 = (dataRow[ctCOL_UpdAssemblyId2] != DBNull.Value) ? (string)dataRow[ctCOL_UpdAssemblyId2] : "";
			// �_���폜�敪
			productStockWork.LogicalDeleteCode = (dataRow[ctCOL_LogicalDeleteCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_LogicalDeleteCode] : 0;
            // ���_�R�[�h
            productStockWork.SectionCode = (dataRow[ctCOL_SectionCode] != DBNull.Value) ? (string)dataRow[ctCOL_SectionCode] : "";
            // ���[�J�[�R�[�h
            productStockWork.MakerCode = (dataRow[ctCOL_MakerCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_MakerCode] : 0;
            // ���i�R�[�h
            productStockWork.GoodsCode = (dataRow[ctCOL_GoodsCode] != DBNull.Value) ? (string)dataRow[ctCOL_GoodsCode] : "";
            // ���i����
            productStockWork.GoodsName = (dataRow[ctCOL_GoodsName] != DBNull.Value) ? (string)dataRow[ctCOL_GoodsName] : "";
            // �����ԍ�
            productStockWork.ProductNumber = (dataRow[ctCOL_ProductNumber] != DBNull.Value) ? (string)dataRow[ctCOL_ProductNumber] : "";
            // �����ԍ��}�X�^GUID
            productStockWork.ProductStockGuid = (dataRow[ctCOL_ProductStockGuid] != DBNull.Value) ? (Guid)dataRow[ctCOL_ProductNumber] : Guid.Empty;
            // �݌ɋ敪
            productStockWork.StockDiv = (dataRow[ctCOL_StockDiv] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockDiv] : 0;
            // �q�ɃR�[�h
            productStockWork.WarehouseCode = (dataRow[ctCOL_WarehouseCode] != DBNull.Value) ? (string)dataRow[ctCOL_WarehouseCode] : "";
            // �q�ɖ���
            productStockWork.WarehouseName = (dataRow[ctCOL_WarehouseName] != DBNull.Value) ? (string)dataRow[ctCOL_WarehouseName] : "";
            // ���Ǝ҃R�[�h
            productStockWork.CarrierEpCode = (dataRow[ctCOL_CarrierEpCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_CarrierEpCode] : 0;
            // ���ƎҖ���
            productStockWork.CarrierEpName = (dataRow[ctCOL_CarrierEpName] != DBNull.Value) ? (string)dataRow[ctCOL_CarrierEpName] : "";
            // ���Ӑ�R�[�h
            productStockWork.CustomerCode = (dataRow[ctCOL_CustomerCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_CustomerCode] : 0;
            // ���Ӑ於��
            productStockWork.CustomerName = (dataRow[ctCOL_CustomerName] != DBNull.Value) ? (string)dataRow[ctCOL_CustomerName] : "";
            // ���Ӑ於��2
            productStockWork.CustomerName2 = (dataRow[ctCOL_CustomerName2] != DBNull.Value) ? (string)dataRow[ctCOL_CustomerName2] : "";
            // �d����
            productStockWork.StockDate = (dataRow[ctCOL_StockDate] != DBNull.Value) ? (DateTime)dataRow[ctCOL_StockDate] : DateTime.MinValue;
            // ���ד�
            productStockWork.ArrivalGoodsDay = (dataRow[ctCOL_ArrivalGoodsDay] != DBNull.Value) ? (DateTime)dataRow[ctCOL_ArrivalGoodsDay] : DateTime.MinValue;
            // �d���P��
            productStockWork.StockUnitPrice = (dataRow[ctCOL_StockUnitPrice] != DBNull.Value) ? (Int64)dataRow[ctCOL_StockUnitPrice] : 0;
            // �ېŋ敪
            productStockWork.TaxationCode = (dataRow[ctCOL_TaxationCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_TaxationCode] : 0;
            // �݌ɏ��
            productStockWork.StockState = (dataRow[ctCOL_StockState] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockState] : 0;
            // �ړ����
            productStockWork.MoveStatus = (dataRow[ctCOL_MoveStatus] != DBNull.Value) ? (Int32)dataRow[ctCOL_MoveStatus] : 0;
            // ���i���
            productStockWork.GoodsCodeStatus = (dataRow[ctCOL_GoodsCodeStatus] != DBNull.Value) ? (Int32)dataRow[ctCOL_GoodsCodeStatus] : 0;
            // ���i�d�b�ԍ�1
            productStockWork.StockTelNo1 = (dataRow[ctCOL_StockTelNo1] != DBNull.Value) ? (string)dataRow[ctCOL_StockTelNo1] : "";
            // ���i�d�b�ԍ�2
            productStockWork.StockTelNo2 = (dataRow[ctCOL_StockTelNo2] != DBNull.Value) ? (string)dataRow[ctCOL_StockTelNo2] : "";
            // �����敪
            productStockWork.RomDiv = (dataRow[ctCOL_RomDiv] != DBNull.Value) ? (Int32)dataRow[ctCOL_RomDiv] : 0;
            // �@��R�[�h
            productStockWork.CellphoneModelCode = (dataRow[ctCOL_CellphoneModelCode] != DBNull.Value) ? (string)dataRow[ctCOL_CellphoneModelCode] : "";
            // �@�햼��
            productStockWork.CellphoneModelName = (dataRow[ctCOL_CellphoneModelName] != DBNull.Value) ? (string)dataRow[ctCOL_CellphoneModelName] : "";
            // �L�����A�R�[�h
            productStockWork.CarrierCode = (dataRow[ctCOL_CarrierCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_CarrierCode] : 0;
            // �L�����A����
            productStockWork.CarrierName = (dataRow[ctCOL_CarrierName] != DBNull.Value) ? (string)dataRow[ctCOL_CarrierName] : "";
            // ���[�J�[����
            productStockWork.MakerName = (dataRow[ctCOL_MakerName] != DBNull.Value) ? (string)dataRow[ctCOL_MakerName] : "";
            // �n���F�R�[�h
            productStockWork.SystematicColorCd = (dataRow[ctCOL_SystematicColorCd] != DBNull.Value) ? (Int32)dataRow[ctCOL_SystematicColorCd] : 0;
            // �n���F����
            productStockWork.SystematicColorNm = (dataRow[ctCOL_SystematicColorNm] != DBNull.Value) ? (string)dataRow[ctCOL_SystematicColorNm] : "";
            // ���i�啪�ރR�[�h
            productStockWork.LargeGoodsGanreCode = (dataRow[ctCOL_LargeGoodsGanreCode] != DBNull.Value) ? (string)dataRow[ctCOL_LargeGoodsGanreCode] : "";
            // ���i�����ރR�[�h
            productStockWork.MediumGoodsGanreCode = (dataRow[ctCOL_MediumGoodsGanreCode] != DBNull.Value) ? (string)dataRow[ctCOL_MediumGoodsGanreCode] : "";
            // �o�א擾�Ӑ�R�[�h
            productStockWork.ShipCustomerCode = (dataRow[ctCOL_ShipCustomerCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_ShipCustomerCode] : 0;
            // �o�א擾�Ӑ於��
            productStockWork.ShipCustomerName = (dataRow[ctCOL_ShipCustomerName] != DBNull.Value) ? (string)dataRow[ctCOL_ShipCustomerName] : "";
            // �o�א擾�Ӑ於��2
            productStockWork.ShipCustomerName2 = (dataRow[ctCOL_ShipCustomerName2] != DBNull.Value) ? (string)dataRow[ctCOL_ShipCustomerName2] : "";
			return productStockWork;
		}
        */
		#endregion
        // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region DEL 2008/07/24 Partsman�p�ɕύX
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �݌Ƀf�[�^�ϊ�����(���[�N��UI�f�[�^)
        /// </summary>
        /// <param name="ptSuplSlipWork"></param>
        private static Stock CopyToStockDataFromStockWork(StockWork stockWork)
        {
            // �݌Ƀf�[�^�N���X��錾
            Stock stock = null;

            // �݌Ƀ��[�N�I�u�W�F�N�g�����݂��邩�H
            if (stockWork != null)
            {
                // �݌Ƀf�[�^�N���X���C���X�^���X��
                stock = new Stock();

                stock.CreateDateTime = stockWork.CreateDateTime;
                stock.UpdateDateTime = stockWork.UpdateDateTime;
                stock.EnterpriseCode = stockWork.EnterpriseCode;
                stock.FileHeaderGuid = stockWork.FileHeaderGuid;
                stock.UpdEmployeeCode = stockWork.UpdEmployeeCode;
                stock.UpdAssemblyId1 = stockWork.UpdAssemblyId1;
                stock.UpdAssemblyId2 = stockWork.UpdAssemblyId2;
                stock.LogicalDeleteCode = stockWork.LogicalDeleteCode;

                stock.LogicalDeleteCode = stockWork.LogicalDeleteCode;
                stock.SectionCode = stockWork.SectionCode;
                // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                //stock.MakerCode = stockWork.MakerCode;
                //stock.GoodsCode = stockWork.GoodsCode;
                stock.GoodsMakerCd = stockWork.GoodsMakerCd;
                stock.GoodsNo = stockWork.GoodsNo;
                // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                stock.GoodsName = stockWork.GoodsName;
                // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                //stock.StockUnitPrice = stockWork.StockUnitPrice;
                //stock.CellphoneModelCode = stockWork.CellphoneModelCode;
                //stock.CellphoneModelName = stockWork.CellphoneModelName;
                //stock.CarrierCode = stockWork.CarrierCode;
                //stock.CarrierName = stockWork.CarrierName;
                //stock.MakerName = stockWork.MakerName;
                //stock.SystematicColorCd = stockWork.SystematicColorCd;
                //stock.SystematicColorNm = stockWork.SystematicColorNm;
                //stock.LargeGoodsGanreCode = stockWork.LargeGoodsGanreCode;
                //stock.MediumGoodsGanreCode = stockWork.MediumGoodsGanreCode;

                stock.StockUnitPriceFl = stockWork.StockUnitPriceFl;
                stock.MakerName = stockWork.MakerName;
                //                stock.LargeGoodsGanreCode = stockWork.LargeGoodsGanreCode;
                //                stock.MediumGoodsGanreCode = stockWork.MediumGoodsGanreCode;
                // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            }

            return stock;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman�p�ɕύX

        #region DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        #region �݌Ƀf�[�^�ϊ�����(UI�f�[�^�����[�N)
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// �݌Ƀf�[�^�ϊ�����(UI�f�[�^�����[�N)
		/// </summary>
		/// <param name="productStock"></param>
		/// <returns></returns>
        // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        //private StockWork CopyToStockWorkFromStock(StockEachWarehouse stock,int mode)
        private StockWork CopyToStockWorkFromStock(StockExpansion stock, int mode)
        // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        {
			// �݌Ƀ��[�N�N���X��錾
			StockWork stockWork = null;

			// �݌Ƀf�[�^�I�u�W�F�N�g�����݂��邩�H
			if (stock != null)
			{
				// �݌Ƀf�[�^�N���X���C���X�^���X��
				stockWork = new StockWork();

                stockWork.CreateDateTime = stock.CreateDateTime;
                stockWork.UpdateDateTime = stock.UpdateDateTime;                
                stockWork.EnterpriseCode = stock.EnterpriseCode;
                stockWork.FileHeaderGuid = stock.FileHeaderGuid;
                stockWork.UpdEmployeeCode = stock.UpdEmployeeCode;
                stockWork.UpdAssemblyId1 = stock.UpdAssemblyId1;
                stockWork.UpdAssemblyId2 = stock.UpdAssemblyId2;
                stockWork.LogicalDeleteCode = stock.LogicalDeleteCode;
                stockWork.SectionCode = stock.SectionCode;
                // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                //stockWork.MakerCode = stock.MakerCode;
                //stockWork.GoodsCode = stock.GoodsCode;
                stockWork.GoodsMakerCd = stock.GoodsMakerCd;
                stockWork.GoodsNo = stock.GoodsNo;
                // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                stockWork.GoodsName = stock.GoodsName;

                // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                //�����E�������z�𔽉f
                //��ʂ���AGUID���Q�Ƃ��Ē������E�������z������
                double setCount = stock.SupplierStock;
                double setTrust = stock.TrustCount;
                double setEnable = stock.ShipmentPosCnt;
                // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<

                // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                //Int64 setPrice;
                double setPrice;
                // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                Int64 setMinusPrice = 0;
                Int64 setBfPrice = 0;
                if ((GetStockPointWay() == 3) && ((mode == ctMode_StockAdjust) || (mode == ctMode_UnitPriceReEdit)))
                {
                    // �ʒP���@�̍݌ɒ���/���������̎����z���W�v����B
                     setPrice = 0;
                     setMinusPrice = 0;
                }
                else
                {
                    // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                    //setPrice = stock.StockUnitPrice;
                    setPrice = stock.StockUnitPriceFl;
                    // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                }

                for (int i = 0; i < _mainProductStock.Rows.Count; i++)
                {
                    if (_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] == DBNull.Value)
                    {
                        continue;
                    }
                    if (((System.Guid)_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] == null) || (System.Guid)_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] ==(Guid.Empty))
                    {
                        continue;
                    }

                    // ���i�O���X����Guid��v
                    // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
                    //if (stock.FileHeaderGuid == (System.Guid)_mainProductStock.Rows[i][ctCOL_FileHeaderGuid])
                    //{
                    // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<

                        // 2008.01.17 �C�� >>>>>>>>>>>>>>>>>>>>
                        //if ((mode == ctMode_StockAdjust) || (mode == ctMode_TrustAdjust))
                        if (mode == ctMode_StockAdjust)
                        // 2008.01.17 �C�� <<<<<<<<<<<<<<<<<<<<
                        {
                            if (_mainProductStock.Rows[i][ctCOL_AdjustCount] != DBNull.Value)
                            {
                                if (mode == ctMode_StockAdjust)
                                {
                                    // 2008.01.17 �C�� >>>>>>>>>>>>>>>>>>>>
                                    //setCount = setCount + (double)_mainProductStock.Rows[i][ctCOL_AdjustCount];
                                    //setEnable = setEnable + (double)_mainProductStock.Rows[i][ctCOL_AdjustCount];
                                    setCount = (double)_mainProductStock.Rows[i][ctCOL_AdjustCount];
                                    setEnable = setEnable + (double)_mainProductStock.Rows[i][ctCOL_AdjustCount];
                                    // 2008.01.17 �C�� <<<<<<<<<<<<<<<<<<<<
                                }
                                // 2008.01.17 �폜 >>>>>>>>>>>>>>>>>>>>
                                //else if (mode == ctMode_TrustAdjust)
                                //{
                                //    setTrust = setTrust + (double)_mainProductStock.Rows[i][ctCOL_AdjustCount];
                                //    setEnable = setEnable + (double)_mainProductStock.Rows[i][ctCOL_AdjustCount];
                                //}
                                // 2008.01.17 �폜 <<<<<<<<<<<<<<<<<<<<
                            }
                            else
                            {
                                //�l�������Ă��Ȃ�=�ύX���Ȃ�
                                setCount = stock.SupplierStock;
                                setTrust = stock.TrustCount;
                                setEnable = stock.SupplierStock;
                            }
                        }

                        //�d���P��
                        // 2008.01.17 �C�� >>>>>>>>>>>>>>>>>>>>
                        //setPrice = (Int64)_mainProductStock.Rows[i][ctCOL_StockUnitPrice];
                        setPrice = (Double)_mainProductStock.Rows[i][ctCOL_StockUnitPrice];
                        // 2008.01.17 �C�� <<<<<<<<<<<<<<<<<<<<

                    // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
                    //}
                    //else
                    //// ���ԒP��
                    //{
                    //    if ((mode == ctMode_StockAdjust) || (mode == ctMode_TrustAdjust))
                    //    {
                    //        if (_mainProductStock.Rows[i][ctCOL_AdjustCount] != DBNull.Value)
                    //        {
                    //            if (mode == ctMode_StockAdjust)
                    //            {
                    //                setCount = setCount + (double)_mainProductStock.Rows[i][ctCOL_AdjustCount];
                    //                setEnable = setEnable + (double)_mainProductStock.Rows[i][ctCOL_AdjustCount];
                    //            }
                    //            else if (mode == ctMode_TrustAdjust)
                    //            {
                    //                setTrust = setTrust + (double)_mainProductStock.Rows[i][ctCOL_AdjustCount];
                    //                setEnable = setEnable + (double)_mainProductStock.Rows[i][ctCOL_AdjustCount];
                    //            }
                    //        }
                    //        else
                    //        {
                    //            //�l�������Ă��Ȃ�=�ύX���Ȃ�
                    //            setCount = stock.SupplierStock;
                    //            setTrust = stock.TrustCount;
                    //            setEnable = stock.SupplierStock;
                    //        }
                    //    }
                    //    //�ʒP���@�Ŏd������/��������(���ԒP��)�͌��Z������z���W�v
                    //    if ((GetStockPointWay() == 3) && ((mode == ctMode_StockAdjust)||(mode == ctMode_UnitPriceReEdit)))
                    //    {
                    //        if ((stock.GoodsCode == (string)_mainProductStock.Rows[i][ctCOL_GoodsCode]) &&
                    //            (stock.MakerCode == (int)_mainProductStock.Rows[i][ctCOL_MakerCode]))
                    //        {
                    //            setPrice = setPrice + (Int64)_mainProductStock.Rows[i][ctCOL_StockUnitPrice];
                    //            setMinusPrice = setMinusPrice + (Int64)_mainProductStock.Rows[i][ctCOL_StockUnitPrice];
                    //            setBfPrice = setBfPrice + (Int64)_mainProductStock.Rows[i][ctCOL_BfStockUnitPrice];
                    //        }
                    //    }
                    //    else
                    //    {
                    //        if ((stock.GoodsCode == (string)_mainProductStock.Rows[i][ctCOL_GoodsCode]) &&
                    //            (stock.MakerCode == (int)_mainProductStock.Rows[i][ctCOL_MakerCode]))
                    //        {
                    //            //�d���P��
                    //            setPrice = (Int64)_mainProductStock.Rows[i][ctCOL_StockUnitPrice];
                    //        }
                    //    }
                    //}
                    // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
                }
                
                stockWork.SupplierStock = setCount; //�d���݌ɐ�
                stockWork.TrustCount = setTrust;�@�@//����݌ɐ��@

                //------------------------------
                // �݌ɑ��z�v�Z / �d���P���ݒ�
                //------------------------------
                #region
                if ((mode == ctMode_StockAdjust) || (mode == ctMode_UnitPriceReEdit))//�݌ɒ����������͌��������̂�
                {
                    // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                    //Stock chkStock = new Stock();
                    ////�݌ɏ��ďo
                    //GetStockInf(out chkStock, stock.GoodsCode, stock.MakerCode, mode);
                    StockExpansion chkStock = new StockExpansion();
                    //�݌ɏ��ďo
                    GetStockInf(out chkStock, stock.GoodsNo, stock.GoodsMakerCd, stock.WarehouseCode, mode);
                    // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<

                    double totalPrice = 0;

                    if (GetStockPointWay() == 1)
                    //----------------
                    // �ŏI�d���@
                    //----------------
                    {                        
                        //--- �d���P�� ---//
                        if ((chkStock.LastStockDate <= GetDate()) && (mode == ctMode_UnitPriceReEdit))
                        {                            
                            // �P���ύX����
                            // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                            //stockWork.StockUnitPrice = setPrice;
                            stockWork.StockUnitPriceFl = setPrice;
                            // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                        }
                        else
                        {
                            // �P���ύX����
                            // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                            //stockWork.StockUnitPrice = chkStock.StockUnitPrice;
                            stockWork.StockUnitPriceFl = chkStock.StockUnitPriceFl;
                            // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                        }

                        //--- ���z ---//
                        
                        // �ŏI�d���@���A�݌ɑ��z=�d���P��*�݌ɐ�(������)
                        // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                        //totalPrice = (stockWork.StockUnitPrice * stockWork.SupplierStock);
                        totalPrice = (stockWork.StockUnitPriceFl * stockWork.SupplierStock);
                        // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                        stockWork.StockTotalPrice = (long)totalPrice;
                    }
                    else if (GetStockPointWay() == 3)
                    //--------------
                    // �ʒP���@
                    //--------------
                    {
                        if (mode == ctMode_UnitPriceReEdit)
                        //��������
                        {                                                
                            //--- ���z ---//
                            double tgtPrice = chkStock.StockTotalPrice;//���̑��z
                            totalPrice = tgtPrice - (setBfPrice - setMinusPrice);//���̑��ۗL�z-���z��(���ԒP�ʂ̑��v)

                            stockWork.StockTotalPrice = (long)totalPrice; //�V�݌ɑ��z
                            
                            //--- �d���P�� ---//
                            if ((totalPrice != 0) && (stockWork.SupplierStock != 0))
                            {
                                // �P�� = (�V�݌ɑ��z) / �����㐔��
                                double calcRslt = totalPrice / stockWork.SupplierStock;
                                if (calcRslt != 0)
                                {
                                    // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                                    //stockWork.StockUnitPrice = (Int64)CalculateConsTax.Fraction(calcRslt, GetFractionProcCd());
                                    stockWork.StockUnitPriceFl = (Int64)CalculateConsTax.Fraction(calcRslt, GetFractionProcCd());
                                    // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                                }
                                else
                                {
                                    // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                                    //stockWork.StockUnitPrice = 0;
                                    stockWork.StockUnitPriceFl = 0;
                                    // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                                }
                            }
                            else
                            {
                                // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                                //stockWork.StockUnitPrice = 0;
                                stockWork.StockUnitPriceFl = 0;
                                // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                            }                            
                        }
                        else if (mode == ctMode_StockAdjust)
                        // �d���݌ɒ���
                        {
                            //--- �݌ɑ��z ---//
                            double tgtPrice = chkStock.StockTotalPrice;
                            totalPrice = tgtPrice - setMinusPrice;
                            stockWork.StockTotalPrice = (long)totalPrice;

                            //--- �d���P�� ---//
                            if ((totalPrice != 0) && (stockWork.SupplierStock) != 0)
                            {
                                double calcRslt = totalPrice / stockWork.SupplierStock;
                                if (calcRslt != 0)
                                {
                                    // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                                    //stockWork.StockUnitPrice = (Int64)CalculateConsTax.Fraction(calcRslt, GetFractionProcCd());
                                    stockWork.StockUnitPriceFl = (Int64)CalculateConsTax.Fraction(calcRslt, GetFractionProcCd());
                                    // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                                }
                            }
                            else
                            {
                                // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                                //stockWork.StockUnitPrice = 0;
                                stockWork.StockUnitPriceFl = 0;
                                // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                            }                        
                        }
                    }
                    else if (GetStockPointWay() == 2)
                    //---------------
                    // �ړ����ϖ@
                    //---------------
                    {   
                        // �ۗL���z�ɕύX��������
                        double stockCount = 0;

                        if (mode == ctMode_StockAdjust) //�݌ɒ���
                        {
                            //--- ���z ---//
                            // ������= ���݂̎d���݌ɐ� - �����㐔�� 
                            stockCount = chkStock.SupplierStock - setCount;

                            // �ړ����ϖ@ �݌ɑ��z = ���݂̍݌ɑ��z - (�d���P�� * ������)
                            // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                            //totalPrice = chkStock.StockTotalPrice - (chkStock.StockUnitPrice * stockCount);
                            totalPrice = chkStock.StockTotalPrice - (chkStock.StockUnitPriceFl * stockCount);
                            // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                            stockWork.StockTotalPrice = (long)totalPrice;

                            //--- �d�����z ---//�@�ύX�Ȃ�
                            // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                            //stockWork.StockUnitPrice = chkStock.StockUnitPrice;
                            stockWork.StockUnitPriceFl = chkStock.StockUnitPriceFl;
                            // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                        }
                        else if (mode == ctMode_UnitPriceReEdit) // ��������
                        {
                            //--- ���z ---//
                            // ���������������z�̏W�v�𑍌v����}�C�i�X = �C���㑍�v
                            totalPrice = chkStock.StockTotalPrice - setMinusPrice;
                            stockWork.StockTotalPrice = (long)totalPrice;

                            //--- �d���P�� ---//
                            if ((totalPrice != 0) && (stockWork.SupplierStock != 0)) //���v/��
                            {
                                double calcRslt = totalPrice / chkStock.SupplierStock; //�C���㑍�v / �d���݌ɐ� = �P��
                                // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                                //stockWork.StockUnitPrice = (Int64)CalculateConsTax.Fraction(calcRslt, GetFractionProcCd());
                                stockWork.StockUnitPriceFl = (Int64)CalculateConsTax.Fraction(calcRslt, GetFractionProcCd());
                                // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                            }
                            else
                            {
                                totalPrice = 0;
                                // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                                //stockWork.StockUnitPrice = 0;
                                stockWork.StockUnitPriceFl = 0;
                                // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                            }
                        }
                    }
                }
                else
                {
                    // �݌ɒ����E���������ȊO�͌��̒l
                    // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                    //stockWork.StockUnitPrice = stock.StockUnitPrice;
                    stockWork.StockUnitPriceFl = stock.StockUnitPriceFl;
                    // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                    stockWork.StockTotalPrice = stock.StockTotalPrice;
                }
                #endregion

                // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //stockWork.ReservedCount = stock.ReservedCount;
                //stockWork.AllowStockCnt = stock.AllowStockCnt;
                // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
                stockWork.AcpOdrCount = stock.AcpOdrCount;
                stockWork.SalesOrderCount = stock.SalesOrderCount;
                stockWork.EntrustCnt = stock.EntrustCnt;
                stockWork.SoldCnt = stock.SoldCnt;
                stockWork.MovingSupliStock = stock.MovingSupliStock;
                stockWork.MovingTrustStock = stock.MovingTrustStock;
                
                stockWork.ShipmentPosCnt = setEnable;//��������SET

                // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //stockWork.PrdNumMngDiv = stock.PrdNumMngDiv;
                // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
                stockWork.LastStockDate = stock.LastStockDate;
                stockWork.LastSalesDate = stock.LastSalesDate;
                stockWork.LastInventoryUpdate = stock.LastInventoryUpdate;
                // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //stockWork.CellphoneModelCode = stock.CellphoneModelCode;
                //stockWork.CellphoneModelName = stock.CellphoneModelName;
                //stockWork.CarrierCode = stock.CarrierCode;
                //stockWork.CarrierName = stock.CarrierName;
                // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
                stockWork.MakerName = stock.MakerName;
                // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //stockWork.SystematicColorCd = stock.SystematicColorCd;
                //stockWork.SystematicColorNm = stock.SystematicColorNm;
                // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
                stockWork.LargeGoodsGanreCode = stock.LargeGoodsGanreCode;
                stockWork.MediumGoodsGanreCode = stock.MediumGoodsGanreCode;
                stockWork.MinimumStockCnt = stock.MinimumStockCnt;
                stockWork.MaximumStockCnt = stock.MaximumStockCnt;
                stockWork.NmlSalOdrCount = stock.NmlSalOdrCount;
                // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //stockWork.SalOdrLot = stock.SalOdrLot;
                // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<

                // 2007.10.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
                stockWork.SalesOrderUnit = stock.SalesOrderUnit;

                stockWork.WarehouseCode = stock.WarehouseCode;
                stockWork.WarehouseName = stock.WarehouseName;
                stockWork.GoodsNoNoneHyphen = stock.GoodsNoNoneHyphen;
                stockWork.StockAssessmentRate = stock.StockAssessmentRate;

                //�I�Ԓ���
                stockWork.WarehouseShelfNo = stock.WarehouseShelfNo;
                if (mode == ctMode_ShelfNoReEdit)
                {
                    for (int i = 0; i < _mainProductStock.Rows.Count; i++)
                    {
                        if (_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] == DBNull.Value) continue;
                        if ((System.Guid)_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] == (System.Guid)stock.FileHeaderGuid)
                        {
                            // 2008.03.28 �C�� >>>>>>>>>>>>>>>>>>>>
                            //stockWork.WarehouseShelfNo = (string)_mainProductStock.Rows[i][ctCOL_WarehouseShelfNo];
                            if ((_mainProductStock.Rows[i][ctCOL_WarehouseShelfNo] == null) ||
                                ((string)_mainProductStock.Rows[i][ctCOL_WarehouseShelfNo].ToString().Trim() == string.Empty))
                            {
                                stockWork.WarehouseShelfNo = string.Empty;
                            }
                            else
                            {
                                stockWork.WarehouseShelfNo = (string)_mainProductStock.Rows[i][ctCOL_WarehouseShelfNo];
                            }
                            // 2008.03.28 �C�� <<<<<<<<<<<<<<<<<<<<
                        }
                    }
                }
                stockWork.DuplicationShelfNo1 = stock.DuplicationShelfNo1;
                stockWork.DuplicationShelfNo2 = stock.DuplicationShelfNo2;
                stockWork.PartsManagementDivide1 = stock.PartsManagementDivide1;
                stockWork.PartsManagementDivide2 = stock.PartsManagementDivide2;
                stockWork.StockNote1 = stock.StockNote1;
                stockWork.StockNote2 = stock.StockNote2;
                stockWork.ShipmentCnt = stock.ShipmentCnt;
                stockWork.ArrivalCnt = stock.ArrivalCnt;
                stockWork.StockCreateDate = stock.StockCreateDate;

                stockWork.LargeGoodsGanreName = stock.LargeGoodsGanreName;
                stockWork.MediumGoodsGanreName = stock.MediumGoodsGanreName;
                stockWork.DetailGoodsGanreCode = stock.DetailGoodsGanreCode;
                stockWork.DetailGoodsGanreName = stock.DetailGoodsGanreName;
                stockWork.BLGoodsCode = stock.BLGoodsCode;
                stockWork.BLGoodsFullName = stock.BLGoodsFullName;
//                stockWork.GoodsShortName = stock.GoodsShortName;
//                stockWork.GoodsNameKana = stock.GoodsNameKana;
                stockWork.EnterpriseGanreCode = stock.EnterpriseGanreCode;
                stockWork.EnterpriseGanreName = stock.EnterpriseGanreName;
//                stockWork.Jan = stock.Jan;
                // 2007.10.11 �ǉ� <<<<<<<<<<<<<<<<<<<<
            }

            return stockWork;
		}

        // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        //private static void GetStockInf(out Stock chkStock, string goodsCode, int makerCode, int mode)
        private static void GetStockInf(out StockExpansion chkStock, string goodsNo, int makerCode, string warehouseCode, int mode)
        // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        {
            // ���i�����K�C�h��ʂ̃C���X�^���X�𐶐�
            SearchStockAcs searchStochAch = new SearchStockAcs();
            
            // ���i�����K�C�h���������f�[�^
            StockSearchPara stockSearchPara = new StockSearchPara();
            stockSearchPara.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            stockSearchPara.SectionCode = GetSection();
            // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
            #region 2007.10.11 �폜
            //// �݌ɏ��                    
            //if (mode == 0)
            //{
            //    // 0:�݌�,10:�����,20:�ϑ���,30:����,50:����v���,60:�\��,70:�ԕi,80:���o,81:����
            //    int[] stockState = { (int)ConstantManagement_Mobile.ct_StockState.SupplierStock,
            //                 (int)ConstantManagement_Mobile.ct_StockState.Reserving,
            //                 (int)ConstantManagement_Mobile.ct_StockState.PullingOut};
            //    stockSearchPara.StockState = stockState;
            //}
            //else if (mode == 1)
            //{
            //    // 0:�݌�,10:�����,20:�ϑ���,30:����,50:����v���,60:�\��,70:�ԕi,80:���o,81:����
            //    int[] stockState = { (int)ConstantManagement_Mobile.ct_StockState.Entrusting,
            //                 (int)ConstantManagement_Mobile.ct_StockState.Reserving,
            //                 (int)ConstantManagement_Mobile.ct_StockState.PullingOut};
            //    stockSearchPara.StockState = stockState;
            //}
            //else
            //{
            //    int[] stockState = { (int)ConstantManagement_Mobile.ct_StockState.SupplierStock,
            //                 (int)ConstantManagement_Mobile.ct_StockState.Entrusting,
            //                 (int)ConstantManagement_Mobile.ct_StockState.Reserving,
            //                 (int)ConstantManagement_Mobile.ct_StockState.PullingOut};
            //    stockSearchPara.StockState = stockState;
            //}
            //// �ړ����
            //// 0:�ړ��ΏۊO,1:���o�׏��,2:�ړ���,9:���׍�
            //int[] moveStatus = { 0 };
            //stockSearchPara.MoveStatus = moveStatus;
            #endregion
            // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<

            // �[���݌ɕ\��(0:�\������ 1:�\�����Ȃ�)
            // 2008.03.21 �C�� >>>>>>>>>>>>>>>>>>>>
            //stockSearchPara.ZeroStckDsp = 1;
            stockSearchPara.ZeroStckDsp = 0;
            // 2008.03.21 �C�� <<<<<<<<<<<<<<<<<<<<

            // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //stockSearchPara.GoodsCodeSrchTyp = 0; //���S��v�̂�
            stockSearchPara.GoodsNoSrchTyp = 0; //���S��v�̂�
            // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //if (mode == ctMode_ProductReEdit)
            //{
            //    //                    stockSearchPara.ProductNumberSrchDivCd = 1; //���Ԃ���̂݌���
            //}
            // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
            // ���i�R�[�h
            // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //stockSearchPara.GoodsCode = goodsCode;
            //stockSearchPara.MakerCode = makerCode;
            stockSearchPara.GoodsNo = goodsNo;
            stockSearchPara.GoodsMakerCd = makerCode;
            stockSearchPara.WarehouseCode = warehouseCode;
            // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<

            // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //List<Stock> stockSearchRetList = new List<Stock>();
            //List<ProductStock> productStockSearchRetList = new List<ProductStock>();
            List<StockExpansion> stockSearchRetList = new List<StockExpansion>();
            // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            string msg = "";

            // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //int st = searchStochAch.Search(stockSearchPara, out stockSearchRetList, out productStockSearchRetList, out msg);
            int st = searchStochAch.Search(stockSearchPara, out stockSearchRetList, out msg);
            // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<

            if (stockSearchRetList.Count > 1)
            {
                chkStock = null;
                return;
            }
            else if (stockSearchRetList.Count == 0)
            {
                chkStock = null;
                return;
            }
            chkStock = stockSearchRetList[0];
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion
        #endregion DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #region 2007.10.11 �폜
        // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
        #region ���ԍ݌Ƀf�[�^�ϊ�����(UI�f�[�^�����[�N)
        /*
        /// <summary>
        /// ���ԍ݌Ƀf�[�^�ϊ�����(UI�f�[�^�����[�N)
        /// </summary>
        /// <param name="productStock"></param>
        /// <returns></returns>
        private static ProductStockWork CopyToProductWorkFromProductStock(ProductStock productStock)
        {
            // ���ԍ݌Ƀ��[�N�N���X�錾
            ProductStockWork ptProductStockWork = null;

            // ���ԍ݌ɃI�u�W�F�N�g�����݂��邩�H
            if (productStock != null)
            {
                // ���ԍ݌Ƀf�[�^�N���X���C���X�^���X��
                ptProductStockWork = new ProductStockWork();
                ptProductStockWork.CreateDateTime = productStock.CreateDateTime;
                ptProductStockWork.UpdateDateTime = productStock.UpdateDateTime;
                ptProductStockWork.EnterpriseCode = productStock.EnterpriseCode;
                ptProductStockWork.FileHeaderGuid = productStock.FileHeaderGuid;
                ptProductStockWork.UpdEmployeeCode = productStock.UpdEmployeeCode;
                ptProductStockWork.UpdAssemblyId1 = productStock.UpdAssemblyId1;
                ptProductStockWork.UpdAssemblyId2 = productStock.UpdAssemblyId2;
                ptProductStockWork.LogicalDeleteCode = productStock.LogicalDeleteCode;

                ptProductStockWork.SectionCode = productStock.SectionCode;
                ptProductStockWork.MakerCode = productStock.MakerCode;
                ptProductStockWork.GoodsCode = productStock.GoodsCode;
                ptProductStockWork.GoodsName = productStock.GoodsName;
                ptProductStockWork.ProductNumber = productStock.ProductNumber;
                ptProductStockWork.ProductStockGuid = productStock.ProductStockGuid;
                ptProductStockWork.StockDiv = productStock.StockDiv;
                ptProductStockWork.WarehouseCode = productStock.WarehouseCode;
                ptProductStockWork.WarehouseName = productStock.WarehouseName;
                ptProductStockWork.CarrierEpCode = productStock.CarrierEpCode;
                ptProductStockWork.CarrierEpName = productStock.CarrierEpName;
                ptProductStockWork.CustomerCode = productStock.CustomerCode;
                ptProductStockWork.CustomerName = productStock.CustomerName;
                ptProductStockWork.CustomerName2 = productStock.CustomerName2;
                ptProductStockWork.StockDate = productStock.StockDate;
                ptProductStockWork.ArrivalGoodsDay = productStock.ArrivalGoodsDay;
                ptProductStockWork.StockUnitPrice = productStock.StockUnitPrice;
                ptProductStockWork.TaxationCode = productStock.TaxationCode;
                ptProductStockWork.StockState = productStock.StockState;
                ptProductStockWork.MoveStatus = productStock.MoveStatus;
                ptProductStockWork.GoodsCodeStatus = productStock.GoodsCodeStatus;
                ptProductStockWork.StockTelNo1 = productStock.StockTelNo1;
                ptProductStockWork.StockTelNo2 = productStock.StockTelNo2;
                ptProductStockWork.RomDiv = productStock.RomDiv;
                ptProductStockWork.CellphoneModelCode = productStock.CellphoneModelCode;
                ptProductStockWork.CellphoneModelName = productStock.CellphoneModelName;
                ptProductStockWork.CarrierCode = productStock.CarrierCode;
                ptProductStockWork.CarrierName = productStock.CarrierName;
                ptProductStockWork.MakerName = productStock.MakerName;
                ptProductStockWork.SystematicColorCd = productStock.SystematicColorCd;
                ptProductStockWork.SystematicColorNm = productStock.SystematicColorNm;
                ptProductStockWork.LargeGoodsGanreCode = productStock.LargeGoodsGanreCode;
                ptProductStockWork.MediumGoodsGanreCode = productStock.MediumGoodsGanreCode;
                ptProductStockWork.ShipCustomerCode = productStock.ShipCustomerCode;
                ptProductStockWork.ShipCustomerName = productStock.ShipCustomerName;
                ptProductStockWork.ShipCustomerName2 = productStock.ShipCustomerName2;                                
            }            

            return ptProductStockWork;
        }
        */
        #endregion
        // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        #region �݌ɒ����f�[�^�ϊ�����(UI�f�[�^�����[�N)
        /// <summary>
        /// �݌ɒ����f�[�^�ϊ�����(UI�f�[�^�����[�N)
        /// </summary>
        /// <param name="productStock"></param>
        /// <returns></returns>
        private static StockAdjustWork CopyToStockAdjustWorkFromStockAdjust(StockAdjust stockAdjust)
        {
            // �݌ɒ������[�N�N���X�錾
            StockAdjustWork ptStockAdjustWork = null;

            // �݌ɒ����I�u�W�F�N�g�����݂��邩�H
            if (stockAdjust != null)
            {
                // �݌ɒ����f�[�^�N���X���C���X�^���X��
                ptStockAdjustWork = new StockAdjustWork();

                ptStockAdjustWork.EnterpriseCode = stockAdjust.EnterpriseCode;      // ��ƃR�[�h
                ptStockAdjustWork.SectionCode = stockAdjust.SectionCode;            // ���_�R�[�h
                ptStockAdjustWork.AcPaySlipCd = stockAdjust.AcPaySlipCd;            // �󕥌��`�[�敪
                ptStockAdjustWork.AcPayTransCd = stockAdjust.AcPayTransCd;          // �󕥌�����敪
                ptStockAdjustWork.AdjustDate = stockAdjust.AdjustDate;              // �������t
                ptStockAdjustWork.InputAgenCd = stockAdjust.InputAgenCd;
                ptStockAdjustWork.InputAgenNm = stockAdjust.InputAgenNm;
                ptStockAdjustWork.UpdEmployeeCode = stockAdjust.UpdEmployeeCode;    // �X�V�]�ƈ��R�[�h
                ptStockAdjustWork.SlipNote = stockAdjust.SlipNote;                  // �`�[���l
            }

            return ptStockAdjustWork;
        }
        #endregion

        /// <summary>
        /// �݌ɒ������׃f�[�^�ϊ�����(UI�f�[�^�����[�N)
        /// </summary>
        /// <param name="productStock"></param>
        /// <returns></returns>
        //        private static StockAdjustDtlWork CopyToStockAdjustDtlWorkFromStockAdjustDtl(StockAdjustDtl stockAdjustDtl,string warehouseCode,string warehouseName,int mode)
        private static EachWarehouseStockAdjustDtlWork CopyToStockAdjustDtlWorkFromStockAdjustDtl(StockAdjustDtl stockAdjustDtl, string warehouseCode, string warehouseName, int mode)
        {
            // �݌ɒ������׃��[�N�N���X�錾
            //            StockAdjustDtlWork ptStockAdjustDtlWork = new StockAdjustDtlWork();
            EachWarehouseStockAdjustDtlWork ptStockAdjustDtlWork = new EachWarehouseStockAdjustDtlWork();

            // �݌ɒ������׃I�u�W�F�N�g�����݂��邩�H
            if (stockAdjustDtl != null)
            {
                ptStockAdjustDtlWork.EnterpriseCode = stockAdjustDtl.EnterpriseCode;
                ptStockAdjustDtlWork.SectionCode = stockAdjustDtl.SectionCode;
                ptStockAdjustDtlWork.StockAdjustSlipNo = stockAdjustDtl.StockAdjustSlipNo;
                ptStockAdjustDtlWork.StockAdjustRowNo = stockAdjustDtl.StockAdjustRowNo;
                ptStockAdjustDtlWork.AcPaySlipCd = stockAdjustDtl.AcPaySlipCd;
                ptStockAdjustDtlWork.AcPayTransCd = stockAdjustDtl.AcPayTransCd;
                ptStockAdjustDtlWork.AdjustDate = stockAdjustDtl.AdjustDate;
                // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                //ptStockAdjustDtlWork.MakerCode = stockAdjustDtl.MakerCode;
                ptStockAdjustDtlWork.GoodsMakerCd = stockAdjustDtl.GoodsMakerCd;
                // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                ptStockAdjustDtlWork.MakerName = stockAdjustDtl.MakerName;
                // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                //ptStockAdjustDtlWork.GoodsCode = stockAdjustDtl.GoodsCode;
                ptStockAdjustDtlWork.GoodsNo = stockAdjustDtl.GoodsNo;
                // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                ptStockAdjustDtlWork.GoodsName = stockAdjustDtl.GoodsName;
                // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
                //ptStockAdjustDtlWork.PrdNumMngDiv = stockAdjustDtl.PrdNumMngDiv;
                //ptStockAdjustDtlWork.ProductNumber = stockAdjustDtl.ProductNumber;
                //ptStockAdjustDtlWork.BfProductNumber = stockAdjustDtl.BfProductNumber; //�ύX�O
                //ptStockAdjustDtlWork.StockUnitPrice = stockAdjustDtl.StockUnitPrice;
                //ptStockAdjustDtlWork.BfStockUnitPrice = stockAdjustDtl.BfStockUnitPrice;
                //ptStockAdjustDtlWork.StockTelNo1 = stockAdjustDtl.StockTelNo1;
                //ptStockAdjustDtlWork.BfStockTelNo1 = stockAdjustDtl.BfStockTelNo1;
                //ptStockAdjustDtlWork.StockTelNo2 = stockAdjustDtl.StockTelNo2;
                //ptStockAdjustDtlWork.BfStockTelNo2 = stockAdjustDtl.BfStockTelNo2;
                ptStockAdjustDtlWork.StockUnitPriceFl = stockAdjustDtl.StockUnitPriceFl;
                ptStockAdjustDtlWork.BfStockUnitPriceFl = stockAdjustDtl.BfStockUnitPriceFl;
                // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
                ptStockAdjustDtlWork.SupplierStock = stockAdjustDtl.SupplierStock;
                ptStockAdjustDtlWork.TrustCount = stockAdjustDtl.TrustCount;
                ptStockAdjustDtlWork.UpdEmployeeCode = stockAdjustDtl.UpdEmployeeCode;
                // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //// �������ϊ� ���Ȃ畉��
                //if (stockAdjustDtl.AdjustCount > 0)
                //{
                //    stockAdjustDtl.AdjustCount = stockAdjustDtl.AdjustCount * -1;
                //}
                // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
                ptStockAdjustDtlWork.AdjustCount = stockAdjustDtl.AdjustCount;
                // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //ptStockAdjustDtlWork.StockState = stockAdjustDtl.StockState;
                // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
                ptStockAdjustDtlWork.BfStockState = stockAdjustDtl.BfStockState;
                ptStockAdjustDtlWork.StockDiv = stockAdjustDtl.StockDiv;
                // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //ptStockAdjustDtlWork.GoodsCodeStatus = stockAdjustDtl.GoodsCodeStatus;
                //ptStockAdjustDtlWork.ProductStockGuid = stockAdjustDtl.ProductStockGuid;
                // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
                ptStockAdjustDtlWork.DtlNote = stockAdjustDtl.DtlNote;

                // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //if (((mode == ctMode_StockAdjust) || (mode == ctMode_TrustAdjust) || (mode == ctMode_UnitPriceReEdit)) &&
                //    (stockAdjustDtl.ProductStockGuid == Guid.Empty))
                //{
                //    ptStockAdjustDtlWork.AutoProductStockDrawingDiv = 1; //��������
                //}
                //else
                //{
                //    ptStockAdjustDtlWork.AutoProductStockDrawingDiv = 0; //��������                    
                //}
                // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<

                //�q�� takahiro                                
                ptStockAdjustDtlWork.WarehouseCode = warehouseCode;
                ptStockAdjustDtlWork.WarehouseName = warehouseName;
                // 2008.01.17 �폜 >>>>>>>>>>>>>>>>>>>>
                //ptStockAdjustDtlWork.DtlNote = warehouseName;
                // 2008.01.17 �폜 <<<<<<<<<<<<<<<<<<<<

                // 2007.10.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
                ptStockAdjustDtlWork.BLGoodsCode = stockAdjustDtl.BLGoodsCode;
                ptStockAdjustDtlWork.BLGoodsCdDerivedNo = stockAdjustDtl.BLGoodsCdDerivedNo;
                ptStockAdjustDtlWork.WarehouseShelfNo = stockAdjustDtl.WarehouseShelfNo;
                ptStockAdjustDtlWork.ListPriceFl = stockAdjustDtl.ListPriceFl;
                // 2007.10.11 �ǉ� <<<<<<<<<<<<<<<<<<<<
            }
            return ptStockAdjustDtlWork;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #region 2007.10.11 �폜
        // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
		#region ���ԍ݌Ƀf�[�^�ϊ�����(���[�N��UI�f�[�^)
        /*
		/// <summary>
		/// ���ԍ݌Ƀf�[�^�ϊ�����(���[�N��UI�f�[�^)[ArrayList��]
		/// </summary>
		/// <param name="sauceList"></param>
		private static ArrayList CopyToDtlDataFromDtlWork(ArrayList sauceList)
		{
			ArrayList retList = null;

			if (sauceList != null)
			{
				// UI�f�[�^���X�g����
				retList = new ArrayList();

				// ���[�N���X�g���UI�f�[�^���X�g���쐬
				foreach (ProductStockWork wkObj in sauceList)
				{
					// 1�N���X�ÂR�s�[���s��
					retList.Add(CopyToDtlDataFromDtlWork(wkObj));
				}
			}

			return retList;
		}

		/// <summary>
		/// ���ԍ݌Ƀf�[�^�ϊ�����(���[�N��UI�f�[�^)
		/// </summary>
		/// <param name="productStockWork"></param>
		private static ProductStock CopyToDtlDataFromDtlWork(ProductStockWork productStockWork)
		{
			ProductStock productStock = null;

			if (productStockWork != null)
			{
				// UI�f�[�^�N���X���C���X�^���X��
				productStock = new ProductStock();

				// �e���ڂ����[�N���R�s�[(��������)
				productStock.CreateDateTime = productStockWork.CreateDateTime;
				productStock.UpdateDateTime = productStockWork.UpdateDateTime;
				productStock.EnterpriseCode = productStockWork.EnterpriseCode;
				productStock.FileHeaderGuid = productStockWork.FileHeaderGuid;
				productStock.UpdEmployeeCode = productStockWork.UpdEmployeeCode;
				productStock.UpdAssemblyId1 = productStockWork.UpdAssemblyId1;
				productStock.UpdAssemblyId2 = productStockWork.UpdAssemblyId2;
				productStock.LogicalDeleteCode = productStockWork.LogicalDeleteCode;
				productStock.SectionCode = productStockWork.SectionCode;
				productStock.MakerCode = productStockWork.MakerCode;
				productStock.GoodsCode = productStockWork.GoodsCode;
				productStock.GoodsName = productStockWork.GoodsName;
				productStock.ProductNumber = productStockWork.ProductNumber;
				productStock.ProductStockGuid = productStockWork.ProductStockGuid;
				productStock.StockDiv = productStockWork.StockDiv;
				productStock.WarehouseCode = productStockWork.WarehouseCode;
				productStock.WarehouseName = productStockWork.WarehouseName;
				productStock.CarrierEpCode = productStockWork.CarrierEpCode;
				productStock.CarrierEpName = productStockWork.CarrierEpName;
				productStock.CustomerCode = productStockWork.CustomerCode;
				productStock.CustomerName = productStockWork.CustomerName;
				productStock.CustomerName2 = productStockWork.CustomerName2;
				productStock.StockDate = productStockWork.StockDate;
				productStock.ArrivalGoodsDay = productStockWork.ArrivalGoodsDay;
				productStock.StockUnitPrice = productStockWork.StockUnitPrice;
				productStock.TaxationCode = productStockWork.TaxationCode;
				productStock.StockState = productStockWork.StockState;
				productStock.MoveStatus = productStockWork.MoveStatus;
				productStock.GoodsCodeStatus = productStockWork.GoodsCodeStatus;
				productStock.StockTelNo1 = productStockWork.StockTelNo1;
                productStock.StockTelNo2 = productStockWork.StockTelNo2;
                productStock.RomDiv = productStockWork.RomDiv;
                productStock.CellphoneModelCode = productStockWork.CellphoneModelCode;
                productStock.CellphoneModelName = productStockWork.CellphoneModelName;
                productStock.CarrierCode = productStockWork.CarrierCode;
                productStock.CarrierName = productStockWork.CarrierName;
                productStock.MakerName = productStockWork.MakerName;
                productStock.SystematicColorCd = productStockWork.SystematicColorCd;
                productStock.SystematicColorNm = productStockWork.SystematicColorNm;
                productStock.LargeGoodsGanreCode = productStockWork.LargeGoodsGanreCode;
                productStock.MediumGoodsGanreCode = productStockWork.MediumGoodsGanreCode;
                productStock.ShipCustomerCode = productStockWork.ShipCustomerCode;
                productStock.ShipCustomerName = productStockWork.ShipCustomerName;
                productStock.ShipCustomerName2 = productStockWork.ShipCustomerName2;
                productStock.SectionCode = productStockWork.SectionCode;
                productStock.MakerCode = productStockWork.MakerCode;
                productStock.GoodsCode = productStockWork.GoodsCode;
                productStock.GoodsName = productStockWork.GoodsName;
                productStock.ProductNumber = productStockWork.ProductNumber;
                productStock.ProductStockGuid = productStockWork.ProductStockGuid;
                productStock.StockDiv = productStockWork.StockDiv;
                productStock.WarehouseCode = productStockWork.WarehouseCode;
                productStock.WarehouseName = productStockWork.WarehouseName;
                productStock.CarrierEpCode = productStockWork.CarrierEpCode;
                productStock.CarrierEpName = productStockWork.CarrierEpName;
                productStock.CustomerCode = productStockWork.CustomerCode;
                productStock.CustomerName = productStockWork.CustomerName;
                productStock.CustomerName2 = productStockWork.CustomerName2;
                productStock.StockDate = productStockWork.StockDate;
                productStock.ArrivalGoodsDay = productStockWork.ArrivalGoodsDay;
                productStock.StockUnitPrice = productStockWork.StockUnitPrice;
                productStock.TaxationCode = productStockWork.TaxationCode;
                productStock.StockState = productStockWork.StockState;
                productStock.MoveStatus = productStockWork.MoveStatus;
                productStock.GoodsCodeStatus = productStockWork.GoodsCodeStatus;
                productStock.StockTelNo1 = productStockWork.StockTelNo1;
                productStock.StockTelNo2 = productStockWork.StockTelNo2;
                productStock.RomDiv = productStockWork.RomDiv;
                productStock.CellphoneModelCode = productStockWork.CellphoneModelCode;
                productStock.CellphoneModelName = productStockWork.CellphoneModelName;
                productStock.CarrierCode = productStockWork.CarrierCode;
                productStock.CarrierName = productStockWork.CarrierName;
                productStock.MakerName = productStockWork.MakerName;
                productStock.SystematicColorCd = productStockWork.SystematicColorCd;
                productStock.SystematicColorNm = productStockWork.SystematicColorNm;
                productStock.LargeGoodsGanreCode = productStockWork.LargeGoodsGanreCode;
                productStock.MediumGoodsGanreCode = productStockWork.MediumGoodsGanreCode;
                productStock.ShipCustomerCode = productStockWork.ShipCustomerCode;
                productStock.ShipCustomerName = productStockWork.ShipCustomerName;
                productStock.ShipCustomerName2 = productStockWork.ShipCustomerName2;
                
			}


			return productStock;
		}
        */
		#endregion
        // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region 2007.10.11 �폜
        // 2007.10.11 �폜 >>>>>>>>>>>>>>>>>>>>
        #region ���׃f�[�^�ϊ�����(UI�f�[�^�����[�N)
        /*
		/// <summary>
		/// ���׃f�[�^�ϊ�����(UI�f�[�^�����[�N)[ArrayList��]
		/// </summary>
		/// <param name="sauceList"></param>
		private static ArrayList CopyToDtlWorkFromDtlData(ArrayList sauceList)
		{
			ArrayList retList = null;

			if (sauceList != null)
			{
				// ���[�N���X�g����
				retList = new ArrayList();

				// UI�f�[�^���X�g��胏�[�N���X�g���쐬
				foreach (ProductStock wkObj in sauceList)
				{
					// 1�N���X�ÂR�s�[���s��
					retList.Add(CopyToDtlWorkFromDtlData(wkObj));
				}
			}

			return retList;
		}

		/// <summary>
		/// ���ԍ݌Ƀf�[�^�ϊ�����(UI�f�[�^�����[�N)
		/// </summary>
		/// <param name="productStock"></param>
		private static ProductStockWork CopyToDtlWorkFromDtlData(ProductStock productStock)
		{
			ProductStockWork productStockWork = null;

			if (productStock != null)
			{
				// ���[�N�N���X���C���X�^���X��
				productStockWork = new ProductStockWork();

				// �e���ڂ�UI�f�[�^���R�s�[(��������)
				productStockWork.CreateDateTime = productStock.CreateDateTime;
				productStockWork.UpdateDateTime = productStock.UpdateDateTime;
				productStockWork.EnterpriseCode = productStock.EnterpriseCode;
				productStockWork.FileHeaderGuid = productStock.FileHeaderGuid;
				productStockWork.UpdEmployeeCode = productStock.UpdEmployeeCode;
				productStockWork.UpdAssemblyId1 = productStock.UpdAssemblyId1;
				productStockWork.UpdAssemblyId2 = productStock.UpdAssemblyId2;
				productStockWork.LogicalDeleteCode = productStock.LogicalDeleteCode;


            }

			return productStockWork;
		}
        */
		#endregion
        // 2007.10.11 �폜 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region DEL 2008/07/24 Partsman�p�ɕύX
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        // 2008.02.15 �ǉ� >>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ���i�����i�艿�擾�����j
        /// </summary>
        /// <param name="setStockExpansion"></param>
        //private double GetGoodsListPrice(StockAdjustDtl stockAdjustDtl)
        private static double GetGoodsListPrice(string enterpriseCode, int goodsMakerCd, string goodsNo, DateTime adjustDate)
        {
            double goodsListPriceFl = 0.00;

            // ���i����
            GoodsPriceUAcs goodsPriceUAcs = new GoodsPriceUAcs();
            GoodsPriceU goodsPriceU;
            //int ret = goodsPriceUAcs.Read(out goodsPriceU, stockAdjustDtl.EnterpriseCode, stockAdjustDtl.GoodsMakerCd, stockAdjustDtl.GoodsNo);
            int ret = goodsPriceUAcs.Read(out goodsPriceU, enterpriseCode, goodsMakerCd, goodsNo);
            if ((ret == 0) && (goodsPriceU != null) && (goodsPriceU.LogicalDeleteCode == 0))
            {
                //if (stockAdjustDtl.AdjustDate < goodsPriceU.NewPriceStartDate)
                if (adjustDate < goodsPriceU.NewPriceStartDate)
                {
                    goodsListPriceFl = goodsPriceU.OldPrice;
                }
                else
                {
                    goodsListPriceFl = goodsPriceU.NewPrice;
                }
            }

            return goodsListPriceFl;
        }
        // 2008.02.15 �ǉ� <<<<<<<<<<<<<<<<<<<<
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman�p�ɕύX
    }
}
