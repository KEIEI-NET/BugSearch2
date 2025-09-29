//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �݌Ɉړ����[�N�N���X
//                  :   PMKYO07253D.DLL
// Name Space       :   Broadleaf.Application.Remoting.ParamData
// Programmer       :   ������
// Date             :   2011.08.10
//----------------------------------------------------------------------
// Update Note      :   2011.08.26 ���仁@#24037�@DateTime�ϊ���O�Ή�
//----------------------------------------------------------------------
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   APStockMoveInfoConverter
    /// <summary>
    /// �݌Ɉړ���񃏁[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �݌Ɉړ���񃏁[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   12/11</br>
    /// <br>Genarated Date   :   2011/08/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class APStockMoveInfoConverter
    {
        /// <summary>
        /// ��M�����݌Ɉړ����狒�_���̍݌Ɉړ��ɃR���o�[�^�[
        /// </summary>
        /// <param name="apStockMoveWork"></param>
        /// <returns></returns>
        public StockMoveWork GetSecStockMoveWork(APStockMoveWork apStockMoveWork)
        {
            StockMoveWork secStockMoveWork = new StockMoveWork();

            secStockMoveWork.CreateDateTime = apStockMoveWork.CreateDateTime;
            secStockMoveWork.UpdateDateTime = apStockMoveWork.UpdateDateTime;
            secStockMoveWork.EnterpriseCode = apStockMoveWork.EnterpriseCode;
            secStockMoveWork.FileHeaderGuid = apStockMoveWork.FileHeaderGuid;
            secStockMoveWork.UpdEmployeeCode = apStockMoveWork.UpdEmployeeCode;
            secStockMoveWork.UpdAssemblyId1 = apStockMoveWork.UpdAssemblyId1;
            secStockMoveWork.UpdAssemblyId2 = apStockMoveWork.UpdAssemblyId2;
            secStockMoveWork.LogicalDeleteCode = apStockMoveWork.LogicalDeleteCode;
            secStockMoveWork.StockMoveFormal = apStockMoveWork.StockMoveFormal;
            secStockMoveWork.StockMoveSlipNo = apStockMoveWork.StockMoveSlipNo;
            secStockMoveWork.StockMoveRowNo = apStockMoveWork.StockMoveRowNo;
            secStockMoveWork.UpdateSecCd = apStockMoveWork.UpdateSecCd;
            secStockMoveWork.BfSectionCode = apStockMoveWork.BfSectionCode;
            secStockMoveWork.BfSectionGuideSnm = apStockMoveWork.BfSectionGuideSnm;
            secStockMoveWork.BfEnterWarehCode = apStockMoveWork.BfEnterWarehCode;
            secStockMoveWork.BfEnterWarehName = apStockMoveWork.BfEnterWarehName;
            secStockMoveWork.AfSectionCode = apStockMoveWork.AfSectionCode;
            secStockMoveWork.AfSectionGuideSnm = apStockMoveWork.AfSectionGuideSnm;
            secStockMoveWork.AfEnterWarehCode = apStockMoveWork.AfEnterWarehCode;
            secStockMoveWork.AfEnterWarehName = apStockMoveWork.AfEnterWarehName;
            secStockMoveWork.ShipmentScdlDay = GetDateTime(apStockMoveWork.ShipmentScdlDay);
            secStockMoveWork.ShipmentFixDay = GetDateTime(apStockMoveWork.ShipmentFixDay);
            secStockMoveWork.ArrivalGoodsDay = GetDateTime(apStockMoveWork.ArrivalGoodsDay);
            secStockMoveWork.InputDay = GetDateTime(apStockMoveWork.InputDay);
            secStockMoveWork.MoveStatus = apStockMoveWork.MoveStatus;
            secStockMoveWork.StockMvEmpCode = apStockMoveWork.StockMvEmpCode;
            secStockMoveWork.StockMvEmpName = apStockMoveWork.StockMvEmpName;
            secStockMoveWork.ShipAgentCd = apStockMoveWork.ShipAgentCd;
            secStockMoveWork.ShipAgentNm = apStockMoveWork.ShipAgentNm;
            secStockMoveWork.ReceiveAgentCd = apStockMoveWork.ReceiveAgentCd;
            secStockMoveWork.ReceiveAgentNm = apStockMoveWork.ReceiveAgentNm;
            secStockMoveWork.SupplierCd = apStockMoveWork.SupplierCd;
            secStockMoveWork.SupplierSnm = apStockMoveWork.SupplierSnm;
            secStockMoveWork.GoodsMakerCd = apStockMoveWork.GoodsMakerCd;
            secStockMoveWork.MakerName = apStockMoveWork.MakerName;
            secStockMoveWork.GoodsNo = apStockMoveWork.GoodsNo;
            secStockMoveWork.GoodsName = apStockMoveWork.GoodsName;
            secStockMoveWork.GoodsNameKana = apStockMoveWork.GoodsNameKana;
            secStockMoveWork.StockDiv = apStockMoveWork.StockDiv;
            secStockMoveWork.StockUnitPriceFl = apStockMoveWork.StockUnitPriceFl;
            secStockMoveWork.TaxationDivCd = apStockMoveWork.TaxationDivCd;
            secStockMoveWork.MoveCount = apStockMoveWork.MoveCount;
            secStockMoveWork.BfShelfNo = apStockMoveWork.BfShelfNo;
            secStockMoveWork.AfShelfNo = apStockMoveWork.AfShelfNo;
            secStockMoveWork.BLGoodsCode = apStockMoveWork.BLGoodsCode;
            secStockMoveWork.BLGoodsFullName = apStockMoveWork.BLGoodsFullName;
            secStockMoveWork.ListPriceFl = apStockMoveWork.ListPriceFl;
            secStockMoveWork.Outline = apStockMoveWork.Outline;
            secStockMoveWork.WarehouseNote1 = apStockMoveWork.WarehouseNote1;
            secStockMoveWork.SlipPrintFinishCd = apStockMoveWork.SlipPrintFinishCd;
            secStockMoveWork.StockMovePrice = apStockMoveWork.StockMovePrice;

            return secStockMoveWork;
        }

        /// <summary>
        /// String����DateTime�ɕϊ�
        /// </summary>
        /// <param name="yyyyMMdd">�����Ώ�</param>
        /// <returns>���ԑΏ�</returns>
        private DateTime GetDateTime(int yyyyMMdd)
        {
            DateTime dt = new DateTime();
            if (yyyyMMdd > 0)
            {
				// DEL 2011.08.26
				//dt = new DateTime(yyyyMMdd / 10000, (yyyyMMdd / 100) % 100, yyyyMMdd % 100);
				// ADD 2011.08.26 -------- >>>>>
				try
				{
					dt = new DateTime(yyyyMMdd / 10000, (yyyyMMdd / 100) % 100, yyyyMMdd % 100);
				}
				catch
				{
					dt = DateTime.MinValue;
				}
				// ADD 2011.08.26 -------- <<<<<
            }

            return dt;
        }
    }
}
