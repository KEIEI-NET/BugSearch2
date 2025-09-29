//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F�݌Ƀ}�X�^�ꗗ���
// �v���O�����T�v   �F�݌Ƀ}�X�^�ꗗ�̈�����s��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/01/13     �C�����e�F�V�K�쐬
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/04/20     �C�����e�FMantis�y12127�z���x�A�b�v�Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F�Ɠc
// �C����    2009/06/02     �C�����e�F�s��Ή�[13368]
// ---------------------------------------------------------------------//

using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �݌Ƀ}�X�^�ꗗ��� �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ƀ}�X�^�ꗗ�̈�����s���B</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date       : 2009/01/13</br>
    /// <br></br>
    /// <br>UpdateNote : 2009/04/20 30413 �����@�@�@ Mantis�y12127�z���x�A�b�v�Ή�</br>
    /// <br>           : 2009/06/02 �@�@�@�Ɠc �M�u�@�s��Ή�[13368]</br>
    /// </remarks>
    public class PMZAI02029AB
    {
        # region [DataSet�Ɋi�[����e�[�u���̖���]
        /// <summary>�݌Ƀ}�X�^�ꗗ�e�[�u��</summary>
        public const string CT_Tbl_StockList = "StockList";
        # endregion

        # region [private const]
        private const string ct_DateFormat = "YYYY/MM/DD";
        private const string ct_TimeFormat = "HH:MM";
        # endregion

        # region [�f�[�^�e�[�u������]
        /// <summary>
        /// �f�[�^�e�[�u�����������i���������X�g�e�[�u���X�L�[�}��`�j
        /// </summary>
        /// <returns></returns>
        public static DataTable CreateBillListTable()
        {
            DataTable table = new DataTable( CT_Tbl_StockList );

            // ������
            table.Columns.Add(new DataColumn("STOCKRF.SECTIONCODERF", typeof(String)));             // ���_�R�[�h
            table.Columns.Add(new DataColumn("STOCKRF.WAREHOUSECODERF", typeof(String)));           // �q�ɃR�[�h
            table.Columns.Add(new DataColumn("STOCKRF.GOODSMAKERCDRF", typeof(Int32)));             // ���i���[�J�[�R�[�h
            table.Columns.Add(new DataColumn("STOCKRF.GOODSNORF", typeof(String)));                 // ���i�ԍ�
            table.Columns.Add(new DataColumn("STOCKRF.STOCKUNITPRICEFLRF", typeof(Double)));        // �d���P���i�Ŕ�,�����j
            table.Columns.Add(new DataColumn("STOCKRF.SUPPLIERSTOCKRF", typeof(Double)));           // �d���݌ɐ�
            table.Columns.Add(new DataColumn("STOCKRF.ACPODRCOUNTRF", typeof(Double)));             // �󒍐�
            table.Columns.Add(new DataColumn("STOCKRF.MONTHORDERCOUNTRF", typeof(Double)));         // M/O������
            table.Columns.Add(new DataColumn("STOCKRF.SALESORDERCOUNTRF", typeof(Double)));         // ������
            table.Columns.Add(new DataColumn("STOCKRF.STOCKDIVRF", typeof(String)));                // �݌ɋ敪
            table.Columns.Add(new DataColumn("STOCKRF.MOVINGSUPLISTOCKRF", typeof(Double)));        // �ړ����d���݌ɐ�
            table.Columns.Add(new DataColumn("STOCKRF.SHIPMENTPOSCNTRF", typeof(Double)));          // �o�׉\��
            table.Columns.Add(new DataColumn("STOCKRF.STOCKTOTALPRICERF", typeof(Int64)));          // �݌ɕۗL���z
            table.Columns.Add(new DataColumn("STOCKRF.LASTSTOCKDATERF", typeof(String)));           // �ŏI�d���N����
            table.Columns.Add(new DataColumn("STOCKRF.LASTSALESDATERF", typeof(String)));           // �ŏI�����
            table.Columns.Add(new DataColumn("STOCKRF.LASTINVENTORYUPDATERF", typeof(String)));     // �ŏI�I���X�V��
            table.Columns.Add(new DataColumn("STOCKRF.MINIMUMSTOCKCNTRF", typeof(Double)));         // �Œ�݌ɐ�
            table.Columns.Add(new DataColumn("STOCKRF.MAXIMUMSTOCKCNTRF", typeof(Double)));         // �ō��݌ɐ�
            table.Columns.Add(new DataColumn("STOCKRF.NMLSALODRCOUNTRF", typeof(Double)));          // �������
            table.Columns.Add(new DataColumn("STOCKRF.SALESORDERUNITRF", typeof(Int32)));           // �����P��
            table.Columns.Add(new DataColumn("STOCKRF.STOCKSUPPLIERCODERF", typeof(Int32)));        // �݌ɔ�����R�[�h
            table.Columns.Add(new DataColumn("STOCKRF.WAREHOUSESHELFNORF", typeof(String)));        // �q�ɒI��
            table.Columns.Add(new DataColumn("STOCKRF.DUPLICATIONSHELFNO1RF", typeof(String)));     // �d���I�ԂP
            table.Columns.Add(new DataColumn("STOCKRF.DUPLICATIONSHELFNO2RF", typeof(String)));     // �d���I�ԂQ
            table.Columns.Add(new DataColumn("STOCKRF.PARTSMANAGEMENTDIVIDE1RF", typeof(String)));  // ���i�Ǘ��敪�P
            table.Columns.Add(new DataColumn("STOCKRF.PARTSMANAGEMENTDIVIDE2RF", typeof(String)));  // ���i�Ǘ��敪�Q
            table.Columns.Add(new DataColumn("STOCKRF.STOCKNOTE1RF", typeof(String)));              // �݌ɔ��l�P
            table.Columns.Add(new DataColumn("STOCKRF.STOCKNOTE2RF", typeof(String)));              // �݌ɔ��l�Q
            table.Columns.Add(new DataColumn("STOCKRF.SHIPMENTCNTRF", typeof(Double)));             // �o�א��i���v��j
            table.Columns.Add(new DataColumn("STOCKRF.ARRIVALCNTRF", typeof(Double)));              // ���א��i���v��j
            table.Columns.Add(new DataColumn("STOCKRF.STOCKCREATEDATERF", typeof(String)));         // �݌ɓo�^��
            table.Columns.Add(new DataColumn("STOCKRF.UPDATEDATERF", typeof(String)));              // �X�V�N����
            table.Columns.Add(new DataColumn("STOCKRF.SECTIONGUIDESNMRF", typeof(String)));         // ���_�K�C�h����
            table.Columns.Add(new DataColumn("STOCKRF.WAREHOUSENAMERF", typeof(String)));           // �q�ɖ���
            table.Columns.Add(new DataColumn("STOCKRF.MAKERSHORTNAMERF", typeof(String)));          // ���[�J�[����
            table.Columns.Add(new DataColumn("STOCKRF.STOCKSUPPLIERSNMRF", typeof(String)));        // �݌ɔ����於��
            table.Columns.Add(new DataColumn("STOCKRF.GOODSNAMERF", typeof(String)));               // ���i����
            table.Columns.Add(new DataColumn("STOCKRF.BLGOODSCODERF", typeof(Int32)));              // BL���i�R�[�h
            table.Columns.Add(new DataColumn("STOCKRF.BLGOODSHALFNAMERF", typeof(String)));         // BL���i�R�[�h���́i���p�j
            table.Columns.Add(new DataColumn("STOCKRF.GOODSLGROUPRF", typeof(Int32)));              // ���i�啪�ރR�[�h
            table.Columns.Add(new DataColumn("STOCKRF.GOODSMGROUPRF", typeof(Int32)));              // ���i�����ރR�[�h
            table.Columns.Add(new DataColumn("STOCKRF.BLGROUPCODERF", typeof(Int32)));              // BL�O���[�v�R�[�h
            table.Columns.Add(new DataColumn("STOCKRF.BLGROUPKANANAMERF", typeof(String)));         // BL�O���[�v�R�[�h�J�i����
            table.Columns.Add(new DataColumn("STOCKRF.GOODSLGROUPNAMERF", typeof(String)));         // ���i�啪�ޖ���
            table.Columns.Add(new DataColumn("STOCKRF.GOODSMGROUPNAMERF", typeof(String)));         // ���i�����ޖ���
            table.Columns.Add(new DataColumn("STOCKRF.SUPPLIERCDRF", typeof(Int32)));               // �d����R�[�h
            table.Columns.Add(new DataColumn("STOCKRF.SUPPLIERSNMRF", typeof(String)));             // �d���旪��
            table.Columns.Add(new DataColumn("STOCKRF.LISTPRICERF", typeof(Double)));               // �艿�i�����j
            table.Columns.Add(new DataColumn("STOCKRF.SALESUNITCOSTRF", typeof(Double)));           // �����P��
            table.Columns.Add(new DataColumn("STOCKRF.COSTUNPRCRATEMARKRF", typeof(String)));       // �����P���|���}�[�N
            table.Columns.Add(new DataColumn("STOCKRF.PRINTDATERF", typeof(String)));               // �쐬��
            table.Columns.Add(new DataColumn("STOCKRF.PRINTTIMERF", typeof(String)));               // �쐬����
            table.Columns.Add(new DataColumn("STOCKRF.PRINTPAGERF", typeof(Int32)));                // �y�[�W��
            table.Columns.Add(new DataColumn("STOCKRF.PRINTRANGERF", typeof(String)));              // ���o�͈�

            return table;
        }
        # endregion

        # region [�f�[�^�ڍs�iDataClass��DataTable�j]
        /// <summary>
        /// �f�[�^�ڍs�����i�݌Ƀ}�X�^�ꗗ�@�S���R�s�[�j
        /// </summary>
        /// <param name="table"></param>
        /// <param name="paraWork"></param>
        /// <param name="printBillList"></param>
        /// <param name="regNo"></param>
        /// <param name="sectionCode"></param>
        public static void CopyToBillListTable(ref DataTable table, ExtrInfo_StockMasterTbl paraWork, ArrayList printList, int regNo, string sectionCode, Dictionary<string, string> costUnPrcRateMarkDic)
        {
            string enterpriseCode = paraWork.EnterpriseCode;

            // ���ݓ��t�������擾
            DateTime nowDate = DateTime.Now;
            string printDate = TDateTime.DateTimeToString(ct_DateFormat, nowDate);
            string printTime = TDateTime.DateTimeToString(ct_TimeFormat, nowDate);
            
            // �q�ɂ̃O���[�v�T�v���X�Ή�
            string cmpWareCode = string.Empty;

            // �݌Ƀ}�X�^�ꗗ�W�J
            for (int index = 0; index < printList.Count; index++)
            {
                DataRow row = table.NewRow();

                //--------------------------------------------------------
                // ������̊i�[
                //--------------------------------------------------------
                
                // �����̃^�C�~���O�ł͊��S�ɂ͓W�J�����A�f�[�^�N���X�̂܂܈��(P)�ɓn���܂��B
                //   ���ёւ���A�󔒍s����A�T�v���X����ȂǁA
                //   ����ɕK�v�Ȏc��̏����͂��ׂĈ��(P)�ɔC���܂��B

                RsltInfo_StockMasterTblWork rsltInfo_StockMasterTblWork = null;
                rsltInfo_StockMasterTblWork = (RsltInfo_StockMasterTblWork)printList[index];

                // ������
                row["STOCKRF.SECTIONCODERF"] = rsltInfo_StockMasterTblWork.SectionCode;                         // ���_�R�[�h
                row["STOCKRF.WAREHOUSECODERF"] = rsltInfo_StockMasterTblWork.WarehouseCode;                     // �q�ɃR�[�h
                row["STOCKRF.GOODSMAKERCDRF"] = rsltInfo_StockMasterTblWork.GoodsMakerCd;                       // ���i���[�J�[�R�[�h
                row["STOCKRF.GOODSNORF"] = rsltInfo_StockMasterTblWork.GoodsNo;                                 // �i��
                row["STOCKRF.STOCKUNITPRICEFLRF"] = rsltInfo_StockMasterTblWork.StockUnitPriceFl;               // �d���P���i�Ŕ�,�����j
                row["STOCKRF.SUPPLIERSTOCKRF"] = rsltInfo_StockMasterTblWork.SupplierStock;                     // �d���݌ɐ�
                row["STOCKRF.ACPODRCOUNTRF"] = rsltInfo_StockMasterTblWork.AcpOdrCount;                         // �󒍐�
                row["STOCKRF.MONTHORDERCOUNTRF"] = rsltInfo_StockMasterTblWork.MonthOrderCount;                 // M/O������
                row["STOCKRF.SALESORDERCOUNTRF"] = rsltInfo_StockMasterTblWork.SalesOrderCount;                 // ������
                row["STOCKRF.MOVINGSUPLISTOCKRF"] = rsltInfo_StockMasterTblWork.MovingSupliStock;               // �ړ����d���݌ɐ�
                row["STOCKRF.SHIPMENTPOSCNTRF"] = rsltInfo_StockMasterTblWork.ShipmentPosCnt;                   // �o�׉\��
                row["STOCKRF.STOCKTOTALPRICERF"] = rsltInfo_StockMasterTblWork.StockTotalPrice;                 // �݌ɕۗL���z
                row["STOCKRF.MINIMUMSTOCKCNTRF"] = rsltInfo_StockMasterTblWork.MinimumStockCnt;                 // �Œ�݌ɐ�
                row["STOCKRF.MAXIMUMSTOCKCNTRF"] = rsltInfo_StockMasterTblWork.MaximumStockCnt;                 // �ō��݌ɐ�
                row["STOCKRF.NMLSALODRCOUNTRF"] = rsltInfo_StockMasterTblWork.NmlSalOdrCount;                   // �������
                row["STOCKRF.SALESORDERUNITRF"] = rsltInfo_StockMasterTblWork.SalesOrderUnit;                   // �����P��
                row["STOCKRF.STOCKSUPPLIERCODERF"] = rsltInfo_StockMasterTblWork.StockSupplierCode;             // �݌ɔ�����R�[�h
                row["STOCKRF.WAREHOUSESHELFNORF"] = rsltInfo_StockMasterTblWork.WarehouseShelfNo;               // �q�ɒI��
                row["STOCKRF.DUPLICATIONSHELFNO1RF"] = rsltInfo_StockMasterTblWork.DuplicationShelfNo1;         // �d���I�ԂP
                row["STOCKRF.DUPLICATIONSHELFNO2RF"] = rsltInfo_StockMasterTblWork.DuplicationShelfNo2;         // �d���I�ԂQ
                row["STOCKRF.PARTSMANAGEMENTDIVIDE1RF"] = rsltInfo_StockMasterTblWork.PartsManagementDivide1;   // ���i�Ǘ��敪�P
                row["STOCKRF.PARTSMANAGEMENTDIVIDE2RF"] = rsltInfo_StockMasterTblWork.PartsManagementDivide2;   // ���i�Ǘ��敪�Q
                row["STOCKRF.STOCKNOTE1RF"] = rsltInfo_StockMasterTblWork.StockNote1;                           // �݌ɔ��l�P
                row["STOCKRF.STOCKNOTE2RF"] = rsltInfo_StockMasterTblWork.StockNote2;                           // �݌ɔ��l�Q
                row["STOCKRF.SHIPMENTCNTRF"] = rsltInfo_StockMasterTblWork.ShipmentCnt;                         // �o�א��i���v��j
                row["STOCKRF.ARRIVALCNTRF"] = rsltInfo_StockMasterTblWork.ArrivalCnt;                           // ���א��i���v��j
                row["STOCKRF.SECTIONGUIDESNMRF"] = rsltInfo_StockMasterTblWork.SectionGuideSnm;                 // ���_�K�C�h����
                row["STOCKRF.WAREHOUSENAMERF"] = rsltInfo_StockMasterTblWork.WarehouseName;                     // �q�ɖ���
                //row["STOCKRF.MAKERSHORTNAMERF"] = rsltInfo_StockMasterTblWork.MakerShortName;                   // ���[�J�[����       //DEL 2009/06/02 �s��Ή�[13368]
                row["STOCKRF.MAKERSHORTNAMERF"] = rsltInfo_StockMasterTblWork.MakerName;                        // ���[�J�[����         //ADD 2009/06/02 �s��Ή�[13368]
                row["STOCKRF.STOCKSUPPLIERSNMRF"] = rsltInfo_StockMasterTblWork.StockSupplierSnm;               // �݌ɔ����於��
                row["STOCKRF.GOODSNAMERF"] = rsltInfo_StockMasterTblWork.GoodsName;                             // ���i����
                row["STOCKRF.BLGOODSCODERF"] = rsltInfo_StockMasterTblWork.BLGoodsCode;                         // BL���i�R�[�h
                row["STOCKRF.BLGOODSHALFNAMERF"] = rsltInfo_StockMasterTblWork.BLGoodsHalfName;                 // BL���i�R�[�h���́i���p�j
                row["STOCKRF.GOODSLGROUPRF"] = rsltInfo_StockMasterTblWork.GoodsLGroup;                         // ���i�啪�ރR�[�h
                row["STOCKRF.GOODSMGROUPRF"] = rsltInfo_StockMasterTblWork.GoodsMGroup;                         // ���i�����ރR�[�h
                row["STOCKRF.BLGROUPCODERF"] = rsltInfo_StockMasterTblWork.BLGroupCode;                         // BL�O���[�v�R�[�h
                row["STOCKRF.BLGROUPKANANAMERF"] = rsltInfo_StockMasterTblWork.BLGroupKanaName;                 // BL�O���[�v�R�[�h�J�i����
                row["STOCKRF.GOODSLGROUPNAMERF"] = rsltInfo_StockMasterTblWork.GoodsLGroupName;                 // ���i�啪�ޖ���
                row["STOCKRF.GOODSMGROUPNAMERF"] = rsltInfo_StockMasterTblWork.GoodsMGroupName;                 // ���i�����ޖ���
                row["STOCKRF.SUPPLIERCDRF"] = rsltInfo_StockMasterTblWork.SupplierCd;                           // �d����R�[�h
                row["STOCKRF.SUPPLIERSNMRF"] = rsltInfo_StockMasterTblWork.SupplierSnm;                         // �d���旪��
                row["STOCKRF.LISTPRICERF"] = rsltInfo_StockMasterTblWork.ListPrice;                             // �艿�i�����j
                row["STOCKRF.SALESUNITCOSTRF"] = rsltInfo_StockMasterTblWork.SalesUnitCost;                     // �����P��
                row["STOCKRF.PRINTDATERF"] = printDate;                                                         // �쐬��
                row["STOCKRF.PRINTTIMERF"] = printTime;                                                         // �쐬����
                //row["STOCKRF.PRINTRANGERF"] = extarCondition;                                                   // ���o�͈�

                // ���ݒ莞 ��󎚃R�[�h
                # region [���ݒ�]
                if (IsZero(rsltInfo_StockMasterTblWork.SectionCode)) row["STOCKRF.SECTIONCODERF"] = DBNull.Value;               // ���_�R�[�h
                if (IsZero(rsltInfo_StockMasterTblWork.WarehouseCode)) row["STOCKRF.WAREHOUSECODERF"] = DBNull.Value;           // �q�ɃR�[�h
                if (IsZero(rsltInfo_StockMasterTblWork.GoodsMakerCd)) row["STOCKRF.GOODSMAKERCDRF"] = DBNull.Value;             // ���[�J�[�R�[�h
                if (IsZero(rsltInfo_StockMasterTblWork.StockSupplierCode)) row["STOCKRF.STOCKSUPPLIERCODERF"] = DBNull.Value;   // �݌ɔ�����R�[�h
                if (IsZero(rsltInfo_StockMasterTblWork.BLGoodsCode)) row["STOCKRF.BLGOODSCODERF"] = DBNull.Value;               // BL���i�R�[�h
                if (IsZero(rsltInfo_StockMasterTblWork.GoodsLGroup)) row["STOCKRF.GOODSLGROUPRF"] = DBNull.Value;               // ���i�啪�ރR�[�h
                if (IsZero(rsltInfo_StockMasterTblWork.GoodsMGroup)) row["STOCKRF.GOODSMGROUPRF"] = DBNull.Value;               // ���i�����ރR�[�h
                if (IsZero(rsltInfo_StockMasterTblWork.BLGroupCode)) row["STOCKRF.BLGROUPCODERF"] = DBNull.Value;               // BL�O���[�v�R�[�h
                if (IsZero(rsltInfo_StockMasterTblWork.SupplierCd)) row["STOCKRF.SUPPLIERCDRF"] = DBNull.Value;                 // �d����R�[�h
                # endregion

                // ���t�t�H�[�}�b�g�ύX
                row["STOCKRF.LASTSTOCKDATERF"] = TDateTime.DateTimeToString(ct_DateFormat, rsltInfo_StockMasterTblWork.LastStockDate);                  // �ŏI�d���N����
                row["STOCKRF.LASTSALESDATERF"] = TDateTime.DateTimeToString(ct_DateFormat, rsltInfo_StockMasterTblWork.LastSalesDate);                  // �ŏI�����
                row["STOCKRF.LASTINVENTORYUPDATERF"] = TDateTime.DateTimeToString(ct_DateFormat, rsltInfo_StockMasterTblWork.LastInventoryUpdate);      // �ŏI�I���X�V��
                row["STOCKRF.STOCKCREATEDATERF"] = TDateTime.DateTimeToString(ct_DateFormat, rsltInfo_StockMasterTblWork.StockCreateDate);              // �݌ɓo�^��
                row["STOCKRF.UPDATEDATERF"] = TDateTime.DateTimeToString(ct_DateFormat, rsltInfo_StockMasterTblWork.UpdateDate);                        // �X�V�N����
                
                // �敪�ݒ�
                if (rsltInfo_StockMasterTblWork.StockDiv == 0)
                {
                    // ����
                    row["STOCKRF.STOCKDIVRF"] = "����";                                                         // �݌ɋ敪
                }
                else
                {
                    // ���
                    row["STOCKRF.STOCKDIVRF"] = "���";                                                         // �݌ɋ敪
                }

                // �����P���|���}�[�N
                string key = CreateKey(rsltInfo_StockMasterTblWork);
                if (costUnPrcRateMarkDic.ContainsKey(key))
                {
                    row["STOCKRF.COSTUNPRCRATEMARKRF"] = costUnPrcRateMarkDic[key];
                }
                else
                {
                    row["STOCKRF.COSTUNPRCRATEMARKRF"] = "";
                }

                // �s�ǉ�
                table.Rows.Add( row );
            }
        }
        # endregion

        #region �����P���|���}�[�N�p�L�[�쐬
        /// <summary>
        /// �����P���|���}�[�N�̃L���b�V���p�L�[�쐬
        /// </summary>
        /// <param name="rsltInfo_StockMasterTblWork">���o����</param>
        /// <returns>key</returns>
        /// <remarks>
        /// <br>Note       : �����P���|���}�[�N�̃L���b�V���p�̃L�[���쐬���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.03.09</br>
        /// </remarks>
        public static string CreateKey(RsltInfo_StockMasterTblWork rsltInfo_StockMasterTblWork)
        {
            // ���_�{�q�Ɂ{���[�J�[�R�[�h�{�i��
            string key = rsltInfo_StockMasterTblWork.SectionCode.TrimEnd() + "-"
                       + rsltInfo_StockMasterTblWork.WarehouseCode.TrimEnd() + "-"
                       + rsltInfo_StockMasterTblWork.GoodsMakerCd.ToString("d04") + "-"
                       + rsltInfo_StockMasterTblWork.GoodsNo;
            return key;
        }
        #endregion

        # region [�f�[�^�[������]
        /// <summary>
        /// ������R�[�h�̃[������
        /// </summary>
        /// <param name="textValue"></param>
        /// <returns></returns>
        private static bool IsZero(string textValue)
        {
            if (textValue == null || textValue.Trim() == string.Empty) return true;

            try
            {
                return (Int32.Parse(textValue) == 0);
            }
            catch
            {
                return true;
            }
        }
        /// <summary>
        /// ���l�R�[�h�̃[������
        /// </summary>
        /// <param name="intValue"></param>
        /// <returns></returns>
        private static bool IsZero(int intValue)
        {
            return (intValue == 0);
        }
        # endregion
    }
}
