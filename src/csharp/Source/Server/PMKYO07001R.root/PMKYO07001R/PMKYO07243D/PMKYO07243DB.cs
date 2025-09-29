//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �݌ɒ������[�N�N���X
//                  :   PMKYO07243D.DLL
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
    /// public class name:   APStockAdjustInfoConverter
    /// <summary>
    /// �݌ɒ�����񃏁[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �݌ɒ�����񃏁[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   12/11</br>
    /// <br>Genarated Date   :   2011/08/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class APStockAdjustInfoConverter
    {
        /// <summary>
        /// ��M�����݌ɒ������狒�_���̍݌ɒ����ɃR���o�[�^�[
        /// </summary>
        /// <param name="apStockAdjustWork"></param>
        /// <returns></returns>
        public StockAdjustWork GetSecStockAdjustWork(APStockAdjustWork apStockAdjustWork)
        {
            StockAdjustWork secStockAdjustWork = new StockAdjustWork();

            secStockAdjustWork.CreateDateTime = apStockAdjustWork.CreateDateTime;
            secStockAdjustWork.UpdateDateTime = apStockAdjustWork.UpdateDateTime;
            secStockAdjustWork.EnterpriseCode = apStockAdjustWork.EnterpriseCode;
            secStockAdjustWork.FileHeaderGuid = apStockAdjustWork.FileHeaderGuid;
            secStockAdjustWork.UpdEmployeeCode = apStockAdjustWork.UpdEmployeeCode;
            secStockAdjustWork.UpdAssemblyId1 = apStockAdjustWork.UpdAssemblyId1;
            secStockAdjustWork.UpdAssemblyId2 = apStockAdjustWork.UpdAssemblyId2;
            secStockAdjustWork.LogicalDeleteCode = apStockAdjustWork.LogicalDeleteCode;
            secStockAdjustWork.SectionCode = apStockAdjustWork.SectionCode;
            secStockAdjustWork.StockAdjustSlipNo = apStockAdjustWork.StockAdjustSlipNo;
            secStockAdjustWork.AcPaySlipCd = apStockAdjustWork.AcPaySlipCd;
            secStockAdjustWork.AcPayTransCd = apStockAdjustWork.AcPayTransCd;

            secStockAdjustWork.AdjustDate = GetDateTime(apStockAdjustWork.AdjustDate);
            secStockAdjustWork.InputDay = GetDateTime(apStockAdjustWork.InputDay);
            secStockAdjustWork.StockSectionCd = apStockAdjustWork.StockSectionCd;
            secStockAdjustWork.StockInputCode = apStockAdjustWork.StockInputCode;
            secStockAdjustWork.StockInputName = apStockAdjustWork.StockInputName;
            secStockAdjustWork.StockAgentCode = apStockAdjustWork.StockAgentCode;
            secStockAdjustWork.StockAgentName = apStockAdjustWork.StockAgentName;
            secStockAdjustWork.StockSubttlPrice = apStockAdjustWork.StockSubttlPrice;
            secStockAdjustWork.SlipNote = apStockAdjustWork.SlipNote;


            return secStockAdjustWork;
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

        /// <summary>
        /// ��M�����݌ɒ������ד`�[���狒�_���̍݌ɒ������ׂɃR���o�[�^�[
        /// </summary>
        /// <param name="apStockAdjustDtlWork"></param>
        /// <returns></returns>
        public StockAdjustDtlWork GetSecStockAdjustDtlWork(APStockAdjustDtlWork apStockAdjustDtlWork)
        {
            StockAdjustDtlWork secStockAdjustDtlWork = new StockAdjustDtlWork();

            secStockAdjustDtlWork.CreateDateTime = apStockAdjustDtlWork.CreateDateTime;
            secStockAdjustDtlWork.UpdateDateTime = apStockAdjustDtlWork.UpdateDateTime;
            secStockAdjustDtlWork.EnterpriseCode = apStockAdjustDtlWork.EnterpriseCode;
            secStockAdjustDtlWork.FileHeaderGuid = apStockAdjustDtlWork.FileHeaderGuid;
            secStockAdjustDtlWork.UpdEmployeeCode = apStockAdjustDtlWork.UpdEmployeeCode;
            secStockAdjustDtlWork.UpdAssemblyId1 = apStockAdjustDtlWork.UpdAssemblyId1;
            secStockAdjustDtlWork.UpdAssemblyId2 = apStockAdjustDtlWork.UpdAssemblyId2;
            secStockAdjustDtlWork.LogicalDeleteCode = apStockAdjustDtlWork.LogicalDeleteCode;
            secStockAdjustDtlWork.SectionCode = apStockAdjustDtlWork.SectionCode;
            secStockAdjustDtlWork.StockAdjustSlipNo = apStockAdjustDtlWork.StockAdjustSlipNo;
            secStockAdjustDtlWork.StockAdjustRowNo = apStockAdjustDtlWork.StockAdjustRowNo;
            secStockAdjustDtlWork.SupplierFormalSrc = apStockAdjustDtlWork.SupplierFormalSrc;
            secStockAdjustDtlWork.StockSlipDtlNumSrc = apStockAdjustDtlWork.StockSlipDtlNumSrc;
            secStockAdjustDtlWork.AcPaySlipCd = apStockAdjustDtlWork.AcPaySlipCd;
            secStockAdjustDtlWork.AcPayTransCd = apStockAdjustDtlWork.AcPayTransCd;
            secStockAdjustDtlWork.AdjustDate = GetDateTime(apStockAdjustDtlWork.AdjustDate);
            secStockAdjustDtlWork.InputDay = GetDateTime(apStockAdjustDtlWork.InputDay);
            secStockAdjustDtlWork.GoodsMakerCd = apStockAdjustDtlWork.GoodsMakerCd;
            secStockAdjustDtlWork.MakerName = apStockAdjustDtlWork.MakerName;
            secStockAdjustDtlWork.GoodsNo = apStockAdjustDtlWork.GoodsNo;
            secStockAdjustDtlWork.GoodsName = apStockAdjustDtlWork.GoodsName;
            secStockAdjustDtlWork.StockUnitPriceFl = apStockAdjustDtlWork.StockUnitPriceFl;
            secStockAdjustDtlWork.BfStockUnitPriceFl = apStockAdjustDtlWork.BfStockUnitPriceFl;
            secStockAdjustDtlWork.AdjustCount = apStockAdjustDtlWork.AdjustCount;
            secStockAdjustDtlWork.DtlNote = apStockAdjustDtlWork.DtlNote;
            secStockAdjustDtlWork.WarehouseCode = apStockAdjustDtlWork.WarehouseCode;
            secStockAdjustDtlWork.WarehouseName = apStockAdjustDtlWork.WarehouseName;
            secStockAdjustDtlWork.BLGoodsCode = apStockAdjustDtlWork.BLGoodsCode;
            secStockAdjustDtlWork.BLGoodsFullName = apStockAdjustDtlWork.BLGoodsFullName;
            secStockAdjustDtlWork.WarehouseShelfNo = apStockAdjustDtlWork.WarehouseShelfNo;
            secStockAdjustDtlWork.ListPriceFl = apStockAdjustDtlWork.ListPriceFl;
            secStockAdjustDtlWork.OpenPriceDiv = apStockAdjustDtlWork.OpenPriceDiv;
            secStockAdjustDtlWork.StockPriceTaxExc = apStockAdjustDtlWork.StockPriceTaxExc;

            return secStockAdjustDtlWork;
        }
    }
}
