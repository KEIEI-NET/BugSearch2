//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d����}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : �d����}�X�^�i�G�N�X�|�[�g�j���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2009/05/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �d����}�X�^�i�G�N�X�|�[�g�j�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d����}�X�^�i�G�N�X�|�[�g�j�C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2009.05.12</br>
    /// </remarks>
    public class SupplierExportAcs
    {
        #region �� Private Member
        private const string PRINTSET_TABLE = "SupplierExp";
        #endregion

        # region ��Constracter
        /// <summary>
        /// �d����}�X�^�i�G�N�X�|�[�g�j�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d����}�X�^�i�G�N�X�|�[�g�j�A�N�Z�X�N���X�B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public SupplierExportAcs()
        {
        }
        # endregion

        #region �� �d����}�X�^��񌟍�
        /// <summary>
        /// �d����}�X�^�f�[�^�擾����
        /// </summary>
        /// <param name="condition">��������</param>
        /// <param name="dataTable">�����f�[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �d����}�X�^�f�[�^�擾�������s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public int Search(SupplierExportWork condition, out DataTable dataTable)
        {
            int status = 0;
            ArrayList retList = null;
            dataTable = new DataTable(PRINTSET_TABLE);
            // DataTable��Columns��ǉ�����
            CreateDataTable(ref dataTable);
            // �d����A�N�Z�X�N���X
            SupplierAcs supplierAcs = new SupplierAcs();
            // ����
            status = supplierAcs.Search(out retList, condition.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �������ʂ�ConvertToDataTable
                ConverToDataSetSupplierInf(retList, condition, ref dataTable);
            }
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            return status;
        }
        # endregion

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
            dataTable.Columns.Add("SupplierCdRF", typeof(string));      //  �d����R�[�h
            dataTable.Columns.Add("SupplierNm1RF", typeof(string));	        //  �d���於1
            dataTable.Columns.Add("SupplierNm2RF", typeof(string));	    //  �d���於2
            dataTable.Columns.Add("SupplierSnmRF", typeof(string));	    //  �d���旪��
            dataTable.Columns.Add("SupplierKanaRF", typeof(string));	    //  �d����J�i
            dataTable.Columns.Add("SuppHonorificTitleRF", typeof(string));	    //  �d����h��
            dataTable.Columns.Add("OrderHonorificTtlRF", typeof(string));	    //  �������h��
            dataTable.Columns.Add("MngSectionCodeRF", typeof(string));           //  �Ǘ����_�R�[�h
            dataTable.Columns.Add("StockAgentCodeRF", typeof(string));	    //  �d���S���҃R�[�h
            dataTable.Columns.Add("PureCodeRF", typeof(Int32));	    //  �����敪

            dataTable.Columns.Add("SupplierAttributeDivRF", typeof(Int32));	    //  �d���摮���敪
            dataTable.Columns.Add("BusinessTypeCodeRF", typeof(string));	    //  �Ǝ�R�[�h
            dataTable.Columns.Add("SalesAreaCodeRF", typeof(string));	    //  �̔��G���A�R�[�h
            dataTable.Columns.Add("PaymentSectionCodeRF", typeof(string));	        //  �x�����_�R�[�h
            dataTable.Columns.Add("PayeeCodeRF", typeof(string));	    //  �x����R�[�h
            dataTable.Columns.Add("PaymentTotalDayRF", typeof(string));	    //  �x������
            dataTable.Columns.Add("PaymentMonthCodeRF", typeof(Int32));	    //  �x�����敪�R�[�h
            dataTable.Columns.Add("PaymentDayRF", typeof(string));	    //  �x����
            dataTable.Columns.Add("PaymentCondRF", typeof(string));	    //  �x������
            dataTable.Columns.Add("PaymentSightRF", typeof(string));	    //  �x���T�C�g

            dataTable.Columns.Add("NTimeCalcStDateRF", typeof(string));	    //  ���񊨒�J�n��
            dataTable.Columns.Add("SuppCTaxLayRefCdRF", typeof(Int32));	    //  �d�������œ]�ŕ����Q�Ƌ敪
            dataTable.Columns.Add("SuppCTaxLayCdRF", typeof(Int32));	    //  �d�������œ]�ŕ����R�[�h
            dataTable.Columns.Add("StockUnPrcFrcProcCdRF", typeof(Int32));	        //  �d���P���[�������R�[�h
            dataTable.Columns.Add("StockMoneyFrcProcCdRF", typeof(Int32));	        //  �d�����z�[�������R�[�h
            dataTable.Columns.Add("StockCnsTaxFrcProcCdRF", typeof(Int32));	    //  �d������Œ[�������R�[�h
            dataTable.Columns.Add("SupplierPostNoRF", typeof(string));	    //  �d����X�֔ԍ�
            dataTable.Columns.Add("SupplierAddr1RF", typeof(string));	        //  �d����Z��1�i�s���{���s��S�E�����E���j
            dataTable.Columns.Add("SupplierAddr3RF", typeof(string));	        //  �d����Z��3�i�Ԓn�j
            dataTable.Columns.Add("SupplierAddr4RF", typeof(string));	    //  �d����Z��4�i�A�p�[�g���́j

            dataTable.Columns.Add("SupplierTelNoRF", typeof(string));	    //  �d����d�b�ԍ�
            dataTable.Columns.Add("SupplierTelNo1RF", typeof(string));	    //  �d����d�b�ԍ�1
            dataTable.Columns.Add("SupplierTelNo2RF", typeof(string));	    //  �d����d�b�ԍ�2
            dataTable.Columns.Add("SupplierNote1RF", typeof(string));	    //  �d������l1
            dataTable.Columns.Add("SupplierNote2RF", typeof(string));	    //  �d������l2
            dataTable.Columns.Add("SupplierNote3RF", typeof(string));	    //  �d������l3
            dataTable.Columns.Add("SupplierNote4RF", typeof(string));	    //  �d������l4
        }

        /// <summary>
        /// �������ʂ�ConvertToDataTable
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="postcardEnvelopeDMWork">��������</param>
        /// <param name="dataTable">����</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataTable�ɍs���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void ConverToDataSetSupplierInf(ArrayList retList, SupplierExportWork supplierExportWork, ref DataTable dataTable)
        {
            foreach (Supplier supplier in retList)
            {
                int checkstatus = DataCheck(supplier, supplierExportWork);
                if (checkstatus == 0)
                {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow["SupplierCdRF"] = AppendZero(supplier.SupplierCd.ToString(), 6);
                    dataRow["SupplierNm1RF"] = GetSubString(supplier.SupplierNm1, 30);
                    dataRow["SupplierNm2RF"] = GetSubString(supplier.SupplierNm2, 30);
                    dataRow["SupplierSnmRF"] = GetSubString(supplier.SupplierSnm, 20);
                    dataRow["SupplierKanaRF"] = GetSubString(supplier.SupplierKana, 30);
                    dataRow["SuppHonorificTitleRF"] = GetSubString(supplier.SuppHonorificTitle, 4);
                    dataRow["OrderHonorificTtlRF"] = GetSubString(supplier.OrderHonorificTtl, 4);
                    dataRow["MngSectionCodeRF"] = AppendStrZero(supplier.MngSectionCode, 2);
                    dataRow["StockAgentCodeRF"] = supplier.StockAgentCode.Trim();
                    dataRow["PureCodeRF"] = supplier.PureCode;

                    dataRow["SupplierAttributeDivRF"] = supplier.SupplierAttributeDiv;

                    dataRow["BusinessTypeCodeRF"] = AppendZero(supplier.BusinessTypeCode.ToString(), 4);
                    dataRow["SalesAreaCodeRF"] = AppendZero(supplier.SalesAreaCode.ToString(), 4);
                    dataRow["PaymentSectionCodeRF"] = AppendStrZero(supplier.PaymentSectionCode, 2);
                    dataRow["PayeeCodeRF"] = AppendZero(supplier.PayeeCode.ToString(), 6);
                    if (supplier.PaymentTotalDay == 0)
                    {
                        dataRow["PaymentTotalDayRF"] = DBNull.Value;
                    }
                    else
                    {
                        dataRow["PaymentTotalDayRF"] = supplier.PaymentTotalDay.ToString();
                    }
                    
                    dataRow["PaymentMonthCodeRF"] = supplier.PaymentMonthCode;
                    if (supplier.PaymentDay == 0)
                    {
                        dataRow["PaymentDayRF"] = DBNull.Value;
                    }
                    else
                    {
                        dataRow["PaymentDayRF"] = supplier.PaymentDay.ToString();
                    }
                    dataRow["PaymentCondRF"] = GetSubString(supplier.PaymentCond.ToString(), 2);
                    dataRow["PaymentSightRF"] = GetSubString(supplier.PaymentSight.ToString(), 3);
                    if (supplier.NTimeCalcStDate == 0)
                    {
                        dataRow["NTimeCalcStDateRF"] = DBNull.Value;
                    }
                    else
                    {
                        dataRow["NTimeCalcStDateRF"] = supplier.NTimeCalcStDate.ToString();
                    }
                    dataRow["SuppCTaxLayRefCdRF"] = supplier.SuppCTaxLayRefCd;
                    dataRow["SuppCTaxLayCdRF"] = supplier.SuppCTaxLayCd;
                    dataRow["StockUnPrcFrcProcCdRF"] = supplier.StockUnPrcFrcProcCd;
                    dataRow["StockMoneyFrcProcCdRF"] = supplier.StockMoneyFrcProcCd;
                    dataRow["StockCnsTaxFrcProcCdRF"] = supplier.StockCnsTaxFrcProcCd;

                    dataRow["SupplierPostNoRF"] = GetSubString(supplier.SupplierPostNo, 10);
                    dataRow["SupplierAddr1RF"] = GetSubString(supplier.SupplierAddr1, 30);
                    dataRow["SupplierAddr3RF"] = GetSubString(supplier.SupplierAddr3, 22);
                    dataRow["SupplierAddr4RF"] = GetSubString(supplier.SupplierAddr4, 30);
                    dataRow["SupplierTelNoRF"] = GetSubString(supplier.SupplierTelNo, 16);
                    dataRow["SupplierTelNo1RF"] = GetSubString(supplier.SupplierTelNo1, 16);
                    dataRow["SupplierTelNo2RF"] = GetSubString(supplier.SupplierTelNo2, 16);
                    dataRow["SupplierNote1RF"] = GetSubString(supplier.SupplierNote1, 20);
                    dataRow["SupplierNote2RF"] = GetSubString(supplier.SupplierNote2, 20);
                    dataRow["SupplierNote3RF"] = GetSubString(supplier.SupplierNote3, 20);
                    dataRow["SupplierNote4RF"] = GetSubString(supplier.SupplierNote4, 20);
                    dataTable.Rows.Add(dataRow);
                }
            }
        }

        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="supplier">�d����f�[�^</param>
        /// <param name="postcardEnvelopeDMWork">��������</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���o�������s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private int DataCheck(Supplier supplier, SupplierExportWork supplierExportWork)
        {
            int status = 0;
            // �d����R�[�h
            if (supplier.LogicalDeleteCode != 0)
            {
                status = -1;
                return status;
            }
            int stSupplierCd = supplierExportWork.SupplierCdSt;
            int edSupplierCd = supplierExportWork.SupplierCdEd;

            if (stSupplierCd != 0 && supplier.SupplierCd < stSupplierCd)
            {
                status = -1;
                return status;

            }
            if (edSupplierCd != 0 && supplier.SupplierCd > edSupplierCd)
            {
                status = -1;
                return status;

            }
            // ���_�R�[�h
            if (String.IsNullOrEmpty(supplier.MngSectionCode))
            {
                status = -1;
                return status;
            }
            else
            {
                int supplierSectionCd = System.Convert.ToInt32(supplier.MngSectionCode.Trim());
                if (!String.IsNullOrEmpty(supplierExportWork.SectionCdSt.Trim()) && supplierSectionCd < Int32.Parse(supplierExportWork.SectionCdSt.Trim()))
                {
                    status = -1;
                    return status;
                }
                if (!String.IsNullOrEmpty(supplierExportWork.SectionCdEd.Trim()) && supplierSectionCd > Int32.Parse(supplierExportWork.SectionCdEd.Trim()))
                {
                    status = -1;
                    return status;
                }
            }
            return status;
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
            bfString = bfString.Trim();
            string afString = "";
            if (bfString.Trim().Length > length)
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
        # endregion

    }
}
