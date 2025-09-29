//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �I���}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : �I���}�X�^�i�G�N�X�|�[�g�j���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2009/05/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �C �� ��  2009/06/26  �C�����e : PVCS277 �I���ߕs���X�V
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �I���}�X�^�i�G�N�X�|�[�g�j�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �I���}�X�^�i�G�N�X�|�[�g�j�C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2009.05.12</br>
    /// </remarks>
    public class InventoryExportAcs
    {
        #region �� Private Member
        private const string PRINTSET_TABLE = "InventoryExp";
        private IInventInputSearchDB _iInventInputSearchDB;
        #endregion

        # region ��Constracter
        /// <summary>
        /// �I���}�X�^�i�G�N�X�|�[�g�j�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I���}�X�^�i�G�N�X�|�[�g�j�A�N�Z�X�N���X�B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public InventoryExportAcs()
        {
            _iInventInputSearchDB = (IInventInputSearchDB)MediationInventInputSearchDB.GetInventInputSearchDB();
        }
        #endregion

        #region �� �I���}�X�^��񌟍�
        /// <summary>
        /// �I���}�X�^�f�[�^�擾����
        /// </summary>
        /// <param name="condition">��������</param>
        /// <param name="dataTable">�����f�[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �I���}�X�^�f�[�^�擾�������s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public int Search(InventoryExportWork condition, out DataTable dataTable)
        {
            string message = "";
            int status = 0;
            dataTable = new DataTable(PRINTSET_TABLE);
            // DataTable��Columns��ǉ�����
            CreateDataTable(ref dataTable);
            // ����������ݒ�
            InventInputSearchCndtnWork iisCndtnWork = new InventInputSearchCndtnWork();
            iisCndtnWork.EnterpriseCode = condition.EnterpriseCode;
            iisCndtnWork.St_InventorySeqNo = condition.InventorySeqNoSt;
            iisCndtnWork.Ed_InventorySeqNo = condition.InventorySeqNoEd;
            // ADD 2009/06/26 --->>>
            // �I���ߕs���X�V
            iisCndtnWork.SelectedPaperKind = -1;
            // ADD 2009/06/19 ---<<<

            // �I���f�[�^�擾
            object retObj = null;
            try
            {
                status = _iInventInputSearchDB.Search(out retObj, (object)iisCndtnWork, 1, ConstantManagement.LogicalMode.GetData0);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                status = 1000;
            }
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ConverToDataSetCustomerInf((ArrayList)retObj, ref dataTable);
            }
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            return status;
        }
        #endregion

        #region �� Private Methods

        /// <summary>
        /// DataTable��Columns��ǉ�����
        /// </summary>
        /// <param name="dataTable">����DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTable��Columns��ǉ�����B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable.Columns.Add("InventorySeqNoRF", typeof(Int32));           // �I���ʔ�
            dataTable.Columns.Add("WarehouseCodeRF", typeof(string));           //  �q�ɃR�[�h
            dataTable.Columns.Add("GoodsNoRF", typeof(string));                 // �i��
            dataTable.Columns.Add("GoodsMakerCdRF", typeof(string));             //  ���[�J�[
            dataTable.Columns.Add("SectionCodeRF", typeof(string));             // �Ǘ����_
            dataTable.Columns.Add("SupplierCdRF", typeof(string));               //  �d����
            dataTable.Columns.Add("GoodsLGroupRF", typeof(string));              // ���i�啪��
            dataTable.Columns.Add("GoodsMGroupRF", typeof(string));              //  ���i������
            dataTable.Columns.Add("BLGroupCodeRF", typeof(string));              // �O���[�v�R�[�h
            dataTable.Columns.Add("BLGoodsCodeRF", typeof(string));              //  BL���i�R�[�h
            dataTable.Columns.Add("InventoryDayRF", typeof(string));            // �I�����{��
            dataTable.Columns.Add("InventoryDateRF", typeof(string));           //  �I����
            dataTable.Columns.Add("InventoryStockCntRF", typeof(string));       // �I����
            dataTable.Columns.Add("WarehouseShelfNoRF", typeof(string));        //  �I��
            dataTable.Columns.Add("DuplicationShelfNo1RF", typeof(string));     // �d���I�ԂP
            dataTable.Columns.Add("DuplicationShelfNo2RF", typeof(string));     //  �d���I�ԂQ
            dataTable.Columns.Add("BfStockUnitPriceFlRF", typeof(string));      // �ύX�O�݌ɒP��
            dataTable.Columns.Add("StockTotalRF", typeof(string));              //  ���݌ɐ�
            dataTable.Columns.Add("StockMashinePriceRF", typeof(string));       // ���݌Ɋz
            dataTable.Columns.Add("StockUnitPriceFlRF", typeof(string));        // �݌ɒP��
            dataTable.Columns.Add("InventoryStockPriceRF", typeof(long));       //  �I�����z
            dataTable.Columns.Add("InventoryTolerancCntRF", typeof(string));    //  �ߕs����
            dataTable.Columns.Add("InventoryTlrncPriceRF", typeof(long));       // �ߕs���z
            dataTable.Columns.Add("StockDivRF", typeof(Int32));                 //  �݌ɋ敪
        }

        /// <summary>
        /// �������ʂ�ConvertToDataTable
        /// </summary>
        /// <param name="inventoryList">��������</param>
        /// <param name="dataTable">����</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataTable�ɍs���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void ConverToDataSetCustomerInf(ArrayList inventoryList, ref DataTable dataTable)
        {
            foreach (ArrayList retArray in inventoryList)
            {
                foreach (InventoryDataUpdateWork retWork in retArray)
                {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow["InventorySeqNoRF"] = retWork.InventorySeqNo;
                    dataRow["WarehouseCodeRF"] = AppendStrZero(retWork.WarehouseCode, 4);
                    dataRow["GoodsNoRF"] = GetSubString(retWork.GoodsNo, 24);
                    dataRow["GoodsMakerCdRF"] = AppendZero(retWork.GoodsMakerCd.ToString(), 4);

                    dataRow["SectionCodeRF"] = AppendStrZero(retWork.SectionCode, 2);
                    dataRow["SupplierCdRF"] = AppendZero(retWork.SupplierCd.ToString(), 6);

                    dataRow["GoodsLGroupRF"] = AppendZero(retWork.GoodsLGroup.ToString(), 4);
                    dataRow["GoodsMGroupRF"] = AppendZero(retWork.GoodsMGroup.ToString(), 4);
                    dataRow["BLGroupCodeRF"] = AppendZero(retWork.BLGroupCode.ToString(), 5);

                    dataRow["BLGoodsCodeRF"] = AppendZero(retWork.BLGoodsCode.ToString(), 5);

                    if (retWork.InventoryDay == DateTime.MinValue)
                    {
                        dataRow["InventoryDayRF"] = string.Empty;
                    }
                    else
                    {
                        dataRow["InventoryDayRF"] = TDateTime.DateTimeToLongDate("YYYYMMDD", retWork.InventoryDay).ToString();
                    }
                    if (retWork.InventoryDate == DateTime.MinValue)
                    {
                        dataRow["InventoryDateRF"] = string.Empty;
                    }
                    else
                    {
                        dataRow["InventoryDateRF"] = TDateTime.DateTimeToLongDate("YYYYMMDD", retWork.InventoryDate).ToString();
                    }
                    dataRow["InventoryStockCntRF"] = retWork.InventoryStockCnt.ToString("##0.00");
                    dataRow["WarehouseShelfNoRF"] = GetSubString(retWork.WarehouseShelfNo, 8);

                    dataRow["DuplicationShelfNo1RF"] = GetSubString(retWork.DuplicationShelfNo1, 8);
                    dataRow["DuplicationShelfNo2RF"] = GetSubString(retWork.DuplicationShelfNo2, 8);

                    dataRow["BfStockUnitPriceFlRF"] = retWork.BfStockUnitPriceFl.ToString("##0.00");
                    dataRow["StockTotalRF"] = retWork.StockTotal.ToString("##0.00");

                    dataRow["StockMashinePriceRF"] = retWork.StockMashinePrice;
                    dataRow["StockUnitPriceFlRF"] = retWork.StockUnitPriceFl.ToString("##0.00");
                    dataRow["InventoryStockPriceRF"] = retWork.InventoryStockPrice;

                    dataRow["InventoryTolerancCntRF"] = retWork.InventoryTolerancCnt.ToString("##0.00");
                    dataRow["InventoryTlrncPriceRF"] = retWork.InventoryTlrncPrice;
                    dataRow["StockDivRF"] = retWork.StockDiv;
                    dataTable.Rows.Add(dataRow);

                }
            }
        }

        /// <summary>
        /// AppendZero
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="maxSize">��</param>
        /// <remarks>
        /// <br>Note       : AppendZero�s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string AppendZero(string bfString, int maxSize)
        {
            bfString = bfString.Trim();

            StringBuilder tempBuild = new StringBuilder();
            if (bfString != "0")
            {
                if (!String.IsNullOrEmpty(bfString.Trim()) && !bfString.Trim().Equals("0"))
                {
                    for (int i = bfString.Length; i < maxSize; i++)
                    {
                        tempBuild.Append("0");
                    }
                    tempBuild.Append(bfString);
                }
            }
            else
            {
                tempBuild.Append("0");
            }
            return tempBuild.ToString().Trim();
        }

        /// <summary>
        /// GetSubString
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="length">��</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataSet�ɍs���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string GetSubString(string bfString, int length)
        {
            string afString = "";
            if (bfString.Length > length)
            {
                afString = bfString.Substring(0, length);
            }
            else
            {
                afString = bfString;
            }
            return afString.Trim();
        }

        /// <summary>
        /// AppendZero
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="maxSize">��</param>
        /// <remarks>
        /// <br>Note       : AppendZero�s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string AppendStrZero(string bfString, int maxSize)
        {
            StringBuilder tempBuild = new StringBuilder();
            if (String.IsNullOrEmpty(bfString.Trim()) || bfString.Trim().Length == 0)
            {
                for (int i = 0; i < maxSize; i++)
                {
                    tempBuild.Append("0");
                }
            }
            else
            {
                for (int i = bfString.Length; i < maxSize; i++)
                {
                    tempBuild.Append("0");
                }
                tempBuild.Append(bfString);
            }
            return tempBuild.ToString().Trim();
        }
        #endregion
    }
}
