//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d���s�����m�F�\
// �v���O�����T�v   : �d���s�����m�F�\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/04/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ����
// �C �� ��  2013/01/09  �C�����e : 2013/03/13�z�M�� Redmine #33989 �S���҃R�[�h�̃G���[�`�F�b�N�̍ہA�l���l�߂̈����ŃR�[�h��r���đΉ�����
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Data.SqlClient;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using System.Data;
using System.IO;

namespace Broadleaf.Application.Remoting
{


    /// <summary>
    /// �d���s�����m�F�\�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���s�����m�F�\�����[�g�I�u�W�F�N�g�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���痈</br>
    /// <br>Date       : 2009.04.10</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class StockSalesInfoTableDB : RemoteDB, IStockSalesInfoTableDB
    {

        #region [Const]
        /// <summary>�G���[�t���O </summary>
        const string stockOnleFlgConst = "2";
        /// <summary>�G���[�t���O </summary>
        const string errFlgConst = "1";
        /// <summary>���� �t���O </summary>
        const string normalFlgConst = "0";
        /// <summary>���� ���t�t�H�[�}�b�g yyyyMMdd </summary>
        public const string ct_DateFomat = "yyyyMMdd";
        /// <summary>���� ���t�t�H�[�}�b�g yyyy/MM/dd</summary>
        public const string ct_DateFomatWithLine = "yyyy/MM/dd";
        /// <summary>���� -1</summary>
        public const int ct_UnderZeroFlgConst = -1;
        #endregion

        #region [Constructor]
        /// <summary>
        /// �d���s�����m�F�\�ꗗ�\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d���s�����m�F�\�����[�g�I�u�W�F�N�g���s���܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.10</br>
        /// </remarks>
        public StockSalesInfoTableDB()
            :
            base("PMKOU02049D", "Broadleaf.Application.Remoting.ParamData.StockSalesInfoWork", "StockSalesInfoTableDB")
        {
        }
        #endregion

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̎d���s�����m�F�\�ꗗ�\���LIST��߂��܂�
        /// </summary>
        /// <param name="stockSalesInfoWork">��������</param>
        /// <param name="paraStockSalesInfoCndWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎d���s�����m�F�\�ꗗ�\���LIST��߂��܂����Ƃ��s���܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.10</br>
        public int Search(out object stockSalesInfoWork, object paraStockSalesInfoCndWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            stockSalesInfoWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (null == sqlConnection)
                {
                    return status;
                }
                sqlConnection.Open();

                return SearchStockSalesInfoProc(out stockSalesInfoWork, paraStockSalesInfoCndWork, ref sqlConnection);
            }
            catch (SqlException exSql)
            {
                base.WriteErrorLog(exSql, "StockSalesInfoTableDB.Search");
                stockSalesInfoWork = new ArrayList();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockSalesInfoTableDB.Search");
                stockSalesInfoWork = new ArrayList();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// �w�肳�ꂽ�����̎d���s�����m�F�\�ꗗ�\���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objStockSalesInfoWork">��������</param>
        /// <param name="paraStockSalesInfoCndWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎d���s�����m�F�\�ꗗ�\���LIST��߂��܂�����(�O�������SqlConnection���g�p)���s���܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.10</br>
        public int SearchStockSalesInfoProc(out object objStockSalesInfoWork, object paraStockSalesInfoCndWork, ref SqlConnection sqlConnection)
        {

            ArrayList stockSalesInfoWorkList = null;
            StockSalesInfoMainCndtnWork stockSalesInfoMainCndtnWork = paraStockSalesInfoCndWork as StockSalesInfoMainCndtnWork;
            int status = SearchStockSalesInfoProc(out stockSalesInfoWorkList, stockSalesInfoMainCndtnWork, ref sqlConnection);
            objStockSalesInfoWork = stockSalesInfoWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̎d���s�����m�F�\�ꗗ�\���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockSalesInfoWorkList">��������</param>
        /// <param name="stockSalesInfoMainCndtnWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎d���s�����m�F�\�ꗗ�\���LIST��߂��܂�����(�O�������SqlConnection���g�p)���s���܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.10</br>
        /// <br>Update Note : 2013/01/09 ����</br>
        /// <br>�Ǘ��ԍ�    : 10801804-00 2013/03/13�z�M��</br>
        /// <br>              redmine#33989�̑Ή�</br>
        private int SearchStockSalesInfoProc(out ArrayList stockSalesInfoWorkList, StockSalesInfoMainCndtnWork stockSalesInfoMainCndtnWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            StringBuilder selectTxt = new StringBuilder(string.Empty);

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);


                selectTxt.Append("SELECT ");
                //�d��������
                selectTxt.Append("  STOCKSALES.ENTERPRISECODE AS ENTERPRISECODE,  ");
                selectTxt.Append("  STOCKSALES.SECTIONCODE AS SECTIONCODE,  ");
                selectTxt.Append("  STOCKSALES.INPUTDAY AS INPUTDAY,  ");
                selectTxt.Append("  STOCKSALES.STOCKDATE AS STOCKDATE,  ");
                selectTxt.Append("  STOCKSALES.SUPPLIERCD AS SUPPLIERCD,  ");
                selectTxt.Append("  STOCKSALES.SUPPLIERSNM AS SUPPLIERSNM,  ");
                selectTxt.Append("  STOCKSALES.STOCKAGENTCODE AS STOCKAGENTCODE,  ");
                selectTxt.Append("  STOCKSALES.BLGOODSCODE AS BLGOODSCODE,  ");
                selectTxt.Append("  STOCKSALES.BLGROUPCODE AS BLGROUPCODE,  ");
                selectTxt.Append("  STOCKSALES.WAREHOUSECODE AS WAREHOUSECODE,  ");
                selectTxt.Append("  STOCKSALES.SUPPLIERSLIPNO AS SUPPLIERSLIPNO,  ");
                selectTxt.Append("  STOCKSALES.STOCKROWNO AS STOCKROWNO,  ");
                selectTxt.Append("  STOCKSALES.STOCKCOUNT AS STOCKCOUNT,  ");
                selectTxt.Append("  STOCKSALES.STOCKUNITPRICEFL AS STOCKUNITPRICEFL,  ");
                selectTxt.Append("  STOCKSALES.CUSTOMERCODE AS CUSTOMERCODE,  ");
                selectTxt.Append("  STOCKSALES.PARTYSLIPNUMDTL AS PARTYSLIPNUMDTL,  ");
                selectTxt.Append("  STOCKSALES.SALESSLIPNUM AS SALESSLIPNUM,  ");
                selectTxt.Append("  STOCKSALES.SHIPMENTCNT AS SHIPMENTCNT,  ");
                selectTxt.Append("  STOCKSALES.SALESUNITCOST AS SALESUNITCOST,  ");
                selectTxt.Append("  STOCKSALES.PARTYSALESLIPNUM AS PARTYSALESLIPNUM,  ");

                selectTxt.Append("  STOCKSALES.ACPTANODRSTATUS AS ACPTANODRSTATUS,  ");
                selectTxt.Append("  STOCKSALES.ACPTANODRSTATUSSYNC AS ACPTANODRSTATUSSYNC,  ");
                selectTxt.Append("  STOCKSALES.SUPPLIERFORMALSRC AS SUPPLIERFORMALSRC,  ");
                selectTxt.Append("  STOCKSALES.SUPPLIERFORMALSYNC AS SUPPLIERFORMALSYNC,  ");
                selectTxt.Append("  STOCKSALES.SALESSLIPDTLNUMSYNC AS SALESSLIPDTLNUMSYNC,  ");
                selectTxt.Append("  STOCKSALES.STOCKSLIPDTLNUMSYNC AS STOCKSLIPDTLNUMSYNC,  ");
                //���_�}�X�^���
                selectTxt.Append("  SEC.SECTIONCODERF,   ");
                selectTxt.Append("  SEC.LOGICALDELETECODERF  AS SECTIONCODELOGICALDELETECODERF,  ");
                selectTxt.Append("  SEC.SECTIONGUIDESNMRF AS SECTIONGUIDESNM,  ");

                //���Ӑ�}�X�^���
                selectTxt.Append("  CUST.CUSTOMERCODERF,  ");
                selectTxt.Append("  CUST.LOGICALDELETECODERF AS CUSTOMERCODELOGICALDELETECODERF,  ");

                //�]�ƈ��}�X�^���
                selectTxt.Append("  EMP.EMPLOYEECODERF,  ");
                selectTxt.Append("  EMP.LOGICALDELETECODERF AS EMPLOYEECODELOGICALDELETECODERF,  ");

                //BL���i�}�X�^���
                selectTxt.Append("  BLGOODSCD.BLGOODSCODERF,  ");
                selectTxt.Append("  BLGOODSCD.LOGICALDELETECODERF AS BLGOODSCODELOGICALDELETECODERF,  ");

                //BL�O���[�v�}�X�^���
                selectTxt.Append("  BLGROUP.BLGROUPCODERF,  ");
                selectTxt.Append("  BLGROUP.LOGICALDELETECODERF AS BLGROUPCODELOGICALDELETECODERF,  ");

                //�q�Ƀ}�X�^���
                selectTxt.Append("  WH.WAREHOUSECODERF,  ");
                selectTxt.Append("  WH.LOGICALDELETECODERF AS WAREHOUSECODELOGICALDELETECODERF,  ");

                //�d����}�X�^���
                selectTxt.Append("  SUPPLIER.SUPPLIERCDRF,  ");
                selectTxt.Append("  SUPPLIER.LOGICALDELETECODERF AS SUPPLIERCDLOGICALDELETECODERF ");

                selectTxt.Append(" FROM ");
                //�d��������
                selectTxt.Append("  (  SELECT ");
                selectTxt.Append("  STOCK.ENTERPRISECODE AS ENTERPRISECODE,  ");
                selectTxt.Append("  STOCK.SUPPLIERFORMALSRC AS SUPPLIERFORMALSRC,  ");
                selectTxt.Append("  STOCK.SECTIONCODE AS SECTIONCODE,  ");
                selectTxt.Append("  STOCK.INPUTDAY AS INPUTDAY,  ");
                //selectTxt.Append("  CAST( STOCK.STOCKDATE  AS NVARCHAR) AS STOCKDATE,  ");
                selectTxt.Append("  STOCK.STOCKDATE AS STOCKDATE,  ");
                selectTxt.Append("  STOCK.SUPPLIERCD AS SUPPLIERCD,  ");
                selectTxt.Append("  STOCK.SUPPLIERSNM AS SUPPLIERSNM,  ");
                selectTxt.Append("  STOCK.STOCKAGENTCODE AS STOCKAGENTCODE,  ");
                selectTxt.Append("  STOCK.BLGOODSCODE AS BLGOODSCODE,  ");
                selectTxt.Append("  STOCK.BLGROUPCODE AS BLGROUPCODE,  ");
                selectTxt.Append("  STOCK.WAREHOUSECODE AS WAREHOUSECODE,  ");
                selectTxt.Append("  STOCK.SUPPLIERSLIPNO AS SUPPLIERSLIPNO,  ");
                selectTxt.Append("  STOCK.STOCKROWNO AS STOCKROWNO,  ");
                selectTxt.Append("  STOCK.STOCKCOUNT AS STOCKCOUNT,  ");
                selectTxt.Append("  STOCK.ACPTANODRSTATUSSYNC AS ACPTANODRSTATUSSYNC,  ");
                selectTxt.Append("  STOCK.SALESSLIPDTLNUMSYNC AS SALESSLIPDTLNUMSYNC,  ");
                selectTxt.Append("  STOCK.PARTYSALESLIPNUM AS PARTYSALESLIPNUM,  ");
                selectTxt.Append("  STOCK.SUPPLIERFORMAL AS SUPPLIERFORMAL,  ");
                selectTxt.Append("  STOCK.STOCKUNITPRICEFL AS STOCKUNITPRICEFL,  ");
                selectTxt.Append("  SALES.CUSTOMERCODE AS CUSTOMERCODE,  ");
                selectTxt.Append("  SALES.PARTYSLIPNUMDTL AS PARTYSLIPNUMDTL,  ");
                selectTxt.Append("  SALES.SHIPMENTCNT AS SHIPMENTCNT,  ");
                selectTxt.Append("  SALES.SALESUNITCOST AS SALESUNITCOST,  ");
                selectTxt.Append("  SALES.ACPTANODRSTATUS AS ACPTANODRSTATUS,  ");
                selectTxt.Append("  SALES.SUPPLIERFORMALSYNC AS SUPPLIERFORMALSYNC,  ");
                selectTxt.Append("  SALES.STOCKSLIPDTLNUMSYNC AS STOCKSLIPDTLNUMSYNC,  ");
                selectTxt.Append("  SALES.SALESSLIPNUM AS SALESSLIPNUM  ");
                selectTxt.Append("FROM  ");
                //�d���f�[�^�Ǝd�����׃f�[�^
                selectTxt.Append("(SELECT ");
                selectTxt.Append("  STKDL.SUPPLIERFORMALSRCRF AS SUPPLIERFORMALSRC,  ");
                //selectTxt.Append("  STKDL.ACPTANODRSTATUSSYNCRF AS ACPTANODRSTATUSSYNC,  ");
                selectTxt.Append("  STKDL.STOCKSLIPDTLNUMRF AS STOCKSLIPDTLNUM,  ");
                selectTxt.Append("  STKDL.SUPPLIERFORMALRF AS SUPPLIERFORMAL,  ");
                selectTxt.Append("  STKDL.ENTERPRISECODERF AS ENTERPRISECODE,  ");
                selectTxt.Append("  STKDL.LOGICALDELETECODERF AS LOGICALDELETECODE,  ");
                selectTxt.Append("  STKSP.STOCKSECTIONCDRF AS SECTIONCODE,  ");
                selectTxt.Append("  STKSP.INPUTDAYRF AS INPUTDAY,  ");
                selectTxt.Append("  STKSP.STOCKADDUPADATERF AS STOCKDATE,  ");
                selectTxt.Append("  STKSP.SUPPLIERCDRF AS SUPPLIERCD,  ");
                selectTxt.Append("  STKSP.SUPPLIERSNMRF AS SUPPLIERSNM,  ");
                selectTxt.Append("  STKSP.STOCKAGENTCODERF AS STOCKAGENTCODE,  ");
                selectTxt.Append("  STKSP.PARTYSALESLIPNUMRF AS PARTYSALESLIPNUM,  ");
                selectTxt.Append("  STKDL.BLGOODSCODERF AS BLGOODSCODE,  ");
                selectTxt.Append("  STKDL.BLGROUPCODERF AS BLGROUPCODE,  ");
                selectTxt.Append("  STKDL.WAREHOUSECODERF AS WAREHOUSECODE,  ");
                selectTxt.Append("  STKDL.SUPPLIERSLIPNORF AS SUPPLIERSLIPNO,  ");
                selectTxt.Append("  STKDL.STOCKCOUNTRF AS STOCKCOUNT,  ");
                selectTxt.Append("  STKDL.STOCKUNITPRICEFLRF AS STOCKUNITPRICEFL,  ");
                selectTxt.Append("  STKDL.ACPTANODRSTATUSSYNCRF AS ACPTANODRSTATUSSYNC,  ");
                selectTxt.Append("  STKDL.SALESSLIPDTLNUMSYNCRF AS SALESSLIPDTLNUMSYNC,  ");

                selectTxt.Append("  STKDL.STOCKROWNORF AS STOCKROWNO  ");
                selectTxt.Append("FROM STOCKSLIPRF AS STKSP ");
                selectTxt.Append("INNER JOIN STOCKDETAILRF AS STKDL ");
                selectTxt.Append("ON");
                selectTxt.Append("     STKSP.ENTERPRISECODERF=STKDL.ENTERPRISECODERF ");
                selectTxt.Append(" AND STKSP.SUPPLIERFORMALRF=STKDL.SUPPLIERFORMALRF ");
                selectTxt.Append(" AND STKSP.SUPPLIERSLIPNORF=STKDL.SUPPLIERSLIPNORF ");
                selectTxt.Append(" AND STKSP.SUPPLIERSLIPNORF=STKDL.SUPPLIERSLIPNORF ");
                selectTxt.Append(" AND STKDL.SUPPLIERFORMALRF = 0 ");
                //selectTxt.Append(" AND STKDL.SALESSLIPDTLNUMSYNCRF > 0 ");
                //selectTxt.Append(" AND STKDL.ACPTANODRSTATUSSYNCRF = 30 ");
                selectTxt.Append(" AND STKSP.LOGICALDELETECODERF=STKDL.LOGICALDELETECODERF ");
                selectTxt.Append(" AND STKSP.LOGICALDELETECODERF=0 ");
                selectTxt.Append(" ) AS STOCK ");
                selectTxt.Append("LEFT JOIN ");
                selectTxt.Append("(SELECT ");
                //����f�[�^�Ɣ��㖾�׃f�[�^
                selectTxt.Append("  SALSP.ENTERPRISECODERF AS ENTERPRISECODE,  ");
                selectTxt.Append("  SALSP.LOGICALDELETECODERF AS LOGICALDELETECODE,  ");
                selectTxt.Append("  SALDL.SUPPLIERFORMALSYNCRF AS SUPPLIERFORMALSYNC,  ");
                selectTxt.Append("  SALDL.STOCKSLIPDTLNUMSYNCRF AS STOCKSLIPDTLNUMSYNC,  ");
                selectTxt.Append("  SALSP.CUSTOMERCODERF AS CUSTOMERCODE,  ");
                selectTxt.Append("  SALDL.PARTYSLIPNUMDTLRF AS PARTYSLIPNUMDTL,  ");
                selectTxt.Append("  SALDL.SHIPMENTCNTRF AS SHIPMENTCNT,  ");
                selectTxt.Append("  SALDL.SALESUNITCOSTRF AS SALESUNITCOST,  ");
                selectTxt.Append("  SALDL.SALESSLIPDTLNUMRF AS SALESSLIPDTLNUM,  ");
                selectTxt.Append("  SALDL.ACPTANODRSTATUSRF AS ACPTANODRSTATUS,  ");
                selectTxt.Append("  SALDL.SALESSLIPNUMRF AS SALESSLIPNUM  ");
                selectTxt.Append("FROM SALESSLIPRF AS SALSP ");
                selectTxt.Append("INNER JOIN SALESDETAILRF AS SALDL ");
                selectTxt.Append("ON");
                selectTxt.Append("     SALSP.ENTERPRISECODERF=SALDL.ENTERPRISECODERF ");
                selectTxt.Append(" AND SALSP.ACPTANODRSTATUSRF=SALDL.ACPTANODRSTATUSRF ");
                selectTxt.Append(" AND SALSP.SALESSLIPNUMRF=SALDL.SALESSLIPNUMRF ");
                selectTxt.Append(" AND SALSP.LOGICALDELETECODERF=SALDL.LOGICALDELETECODERF ");
                selectTxt.Append(" AND SALSP.LOGICALDELETECODERF=0 ");
                selectTxt.Append(" ) AS SALES ");
                selectTxt.Append("ON");

                //selectTxt.Append("     STOCK.SUPPLIERFORMAL=SALES.SUPPLIERFORMALSYNC ");
                //SUPPLIERFORMALSRCRF   
                //selectTxt.Append("     STOCK.SUPPLIERFORMALSRC = 0 ");
                selectTxt.Append("     STOCK.SUPPLIERFORMAL = 0 ");
                selectTxt.Append(" AND STOCK.ACPTANODRSTATUSSYNC = 30 ");
                selectTxt.Append(" AND STOCK.SALESSLIPDTLNUMSYNC > 0 ");
                //selectTxt.Append(" AND STOCK.ACPTANODRSTATUSSYNC = 30 ");
                //ACPTANODRSTATUSSYNC   AcptAnOdrStatusRF
                selectTxt.Append(" AND STOCK.ACPTANODRSTATUSSYNC = SALES.ACPTANODRSTATUS ");
                //SUPPLIERFORMALSRC         SupplierFormalSyncRF
                //selectTxt.Append(" AND STOCK.SUPPLIERFORMALSRC = SALES.SUPPLIERFORMALSYNC ");
                //SalesSlipDtlNumSyncRF     StockSlipDtlNumSyncRF    SalesSlipDtlNumRF
                //selectTxt.Append(" AND STOCK.SALESSLIPDTLNUMSYNC = SALES.STOCKSLIPDTLNUMSYNC ");
                selectTxt.Append(" AND STOCK.SALESSLIPDTLNUMSYNC = SALES.SALESSLIPDTLNUM ");
                //selectTxt.Append(" AND STOCK.STOCKSLIPDTLNUM=SALES.STOCKSLIPDTLNUMSYNC ");
                //selectTxt.Append(" AND STOCK.ACPTANODRSTATUSSYNC = 30 ");
                selectTxt.Append(" AND STOCK.ENTERPRISECODE=SALES.ENTERPRISECODE ");
                selectTxt.Append(" AND STOCK.LOGICALDELETECODE=SALES.LOGICALDELETECODE ");
                //selectTxt.Append(" AND SALES.ACPTANODRSTATUSRF = 30 ");
                selectTxt.Append(MakeWhereString(ref sqlCommand, stockSalesInfoMainCndtnWork));
                selectTxt.Append(" ) AS  STOCKSALES");

                //���_���ݒ�}�X�^ SecInfoSetRF
                selectTxt.Append(" LEFT JOIN ");
                selectTxt.Append(" SECINFOSETRF AS SEC ");
                selectTxt.Append("ON");
                selectTxt.Append("     STOCKSALES.SECTIONCODE=SEC.SECTIONCODERF ");
                selectTxt.Append(" AND STOCKSALES.ENTERPRISECODE=SEC.ENTERPRISECODERF ");

                //���Ӑ�}�X�^  CustomerRF
                selectTxt.Append(" LEFT JOIN ");
                selectTxt.Append(" CUSTOMERRF AS CUST ");
                selectTxt.Append("ON");
                selectTxt.Append("     STOCKSALES.CUSTOMERCODE=CUST.CUSTOMERCODERF ");
                selectTxt.Append(" AND STOCKSALES.ENTERPRISECODE=CUST.ENTERPRISECODERF ");

                //�]�ƈ��}�X�^  EmployeeRF
                selectTxt.Append(" LEFT JOIN ");
                selectTxt.Append(" EMPLOYEERF AS EMP ");
                selectTxt.Append("ON");
                //selectTxt.Append("     STOCKSALES.STOCKAGENTCODE=EMP.EMPLOYEECODERF ");// DEL 2013/01/09 Redmine #33989 ����
                selectTxt.Append("     RIGHT('0000'+ RTRIM(STOCKSALES.STOCKAGENTCODE),4) = EMP.EMPLOYEECODERF ");//�@ADD 2013/01/09 Redmine #33989 ����
                selectTxt.Append(" AND STOCKSALES.ENTERPRISECODE=EMP.ENTERPRISECODERF ");

                //�a�k���i�R�[�h�}�X�^(���[�U�[)
                selectTxt.Append(" LEFT JOIN ");
                selectTxt.Append(" BLGOODSCDURF AS BLGOODSCD ");
                selectTxt.Append("ON");
                selectTxt.Append("     STOCKSALES.BLGOODSCODE=BLGOODSCD.BLGOODSCODERF ");
                selectTxt.Append(" AND STOCKSALES.ENTERPRISECODE=BLGOODSCD.ENTERPRISECODERF ");

                //BL�O���[�v�}�X�^�i���[�U�[�o�^���j BLGroupURF
                selectTxt.Append(" LEFT JOIN ");
                selectTxt.Append(" BLGROUPURF AS BLGROUP ");
                selectTxt.Append("ON");
                selectTxt.Append("     STOCKSALES.BLGROUPCODE=BLGROUP.BLGROUPCODERF ");
                selectTxt.Append(" AND STOCKSALES.ENTERPRISECODE=BLGROUP.ENTERPRISECODERF ");

                // �q�Ƀ}�X�^   WarehouseRF
                selectTxt.Append(" LEFT JOIN ");
                selectTxt.Append(" WAREHOUSERF AS WH ");
                selectTxt.Append("ON");
                selectTxt.Append("     STOCKSALES.WAREHOUSECODE=WH.WAREHOUSECODERF ");
                selectTxt.Append(" AND STOCKSALES.ENTERPRISECODE=WH.ENTERPRISECODERF ");

                //�d����}�X�^ SupplierRF
                selectTxt.Append(" LEFT JOIN ");
                selectTxt.Append(" SUPPLIERRF AS SUPPLIER ");
                selectTxt.Append("ON");
                selectTxt.Append("     STOCKSALES.SUPPLIERCD=SUPPLIER.SUPPLIERCDRF ");
                selectTxt.Append(" AND STOCKSALES.ENTERPRISECODE=SUPPLIER.ENTERPRISECODERF ");

                selectTxt.Append(" WHERE ");
                //���_���ݒ�}�X�^ SecInfoSetRF
                selectTxt.Append("  SEC.SECTIONCODERF IS NULL  ");
                selectTxt.Append("  OR  (  SEC.LOGICALDELETECODERF=1 AND  SEC.SECTIONCODERF IS NOT NULL ) ");
                //���Ӑ�}�X�^  CustomerRF
                selectTxt.Append("  OR CUST.CUSTOMERCODERF IS NULL  ");
                selectTxt.Append("  OR  (  CUST.LOGICALDELETECODERF=1 AND  CUST.CUSTOMERCODERF IS NOT NULL ) ");
                //�]�ƈ��}�X�^  EmployeeRF
                selectTxt.Append("  OR EMP.EMPLOYEECODERF IS NULL  ");
                selectTxt.Append("  OR  (  EMP.LOGICALDELETECODERF=1 AND  EMP.EMPLOYEECODERF IS NOT NULL ) ");
                //�a�k���i�R�[�h�}�X�^(���[�U�[)
                selectTxt.Append("  OR BLGOODSCD.BLGOODSCODERF IS NULL  ");
                selectTxt.Append("  OR  (  BLGOODSCD.LOGICALDELETECODERF=1 AND  BLGOODSCD.BLGOODSCODERF IS NOT NULL ) ");
                //BL�O���[�v�}�X�^�i���[�U�[�o�^���j
                selectTxt.Append("  OR BLGROUP.BLGROUPCODERF IS NULL  ");
                selectTxt.Append("  OR  (  BLGROUP.LOGICALDELETECODERF=1 AND  BLGROUP.BLGROUPCODERF IS NOT NULL ) ");
                //�q�Ƀ}�X�^
                selectTxt.Append("  OR WH.WAREHOUSECODERF IS NULL  ");
                selectTxt.Append("  OR  (  WH.LOGICALDELETECODERF=1 AND  WH.WAREHOUSECODERF IS NOT NULL ) ");
                //�d����}�X�^
                selectTxt.Append("  OR SUPPLIER.SUPPLIERCDRF IS NULL  ");
                selectTxt.Append("  OR  (  SUPPLIER.LOGICALDELETECODERF=1 AND  SUPPLIER.SUPPLIERCDRF IS NOT NULL ) ");

                selectTxt.Append(" ORDER BY STOCKSALES.SECTIONCODE , STOCKSALES.SUPPLIERCD , STOCKSALES.STOCKDATE ,STOCKSALES.INPUTDAY ,STOCKSALES.PARTYSALESLIPNUM ,STOCKSALES.SUPPLIERSLIPNO ,STOCKSALES.STOCKROWNO  ");

                sqlCommand.CommandText = selectTxt.ToString();

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToStockSalesInfoWorkFromReader(ref myReader));

                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                }
            }

            stockSalesInfoWorkList = al;

            return status;
        }
        #endregion

        #region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="stockSalesInfoMainCndtnWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.10</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockSalesInfoMainCndtnWork stockSalesInfoMainCndtnWork)
        {

            string retstring = "WHERE ";

            //��ƃR�[�h
            if (!string.IsNullOrEmpty(stockSalesInfoMainCndtnWork.EnterpriseCode))
            {
                retstring += "STOCK.ENTERPRISECODE=@FINDENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockSalesInfoMainCndtnWork.EnterpriseCode);
            }

            //retstring += "AND (SALES.ENTERPRISECODE IS NULL OR STOCK.ENTERPRISECODE=SALES.ENTERPRISECODE ) ";

            //�_���폜�敪
            retstring += " AND  STOCK.LOGICALDELETECODE=0 ";
            //retstring += " AND  (SALES.LOGICALDELETECODE IS NULL OR STOCK.LOGICALDELETECODE=SALES.LOGICALDELETECODE ) ";



            //���_�R�[�h
            if (stockSalesInfoMainCndtnWork.CollectAddupSecCodeList != null)
            {
                string sectionString = "";
                foreach (string sectionCode in stockSalesInfoMainCndtnWork.CollectAddupSecCodeList)
                {
                    if (!string.Empty.Equals(sectionCode))
                    {
                        if (!string.Empty.Equals(sectionString))
                        {
                            sectionString += ",";
                        }
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (!string.Empty.Equals(sectionString))
                {
                    //���_�R�[�h
                    retstring += "AND STOCK.SECTIONCODE IN (" + sectionString + ") ";
                }
            }


            //�d����
            //if (stockSalesInfoMainCndtnWork.YearMonth != DateTime.MinValue)
            //{
            //    int year = stockSalesInfoMainCndtnWork.YearMonth.Year;
            //    int month = stockSalesInfoMainCndtnWork.YearMonth.Month;
            //    if (month < 10)
            //    {
            //        retstring += "AND STOCK.STOCKDATE LIKE  " + "'" + year + "0" + month + "%" + "'";
            //    }
            //    else
            //    {
            //        retstring += "AND STOCK.STOCKDATE LIKE  " + "'" + year + month + "%" + "'";
            //    }
            //}

            //�d����
            if (stockSalesInfoMainCndtnWork.PrevTotalDay != DateTime.MinValue)
            {
                retstring += "AND STOCK.STOCKDATE>=@FINDPARAPREVTOTALDAY ";
                SqlParameter paraPrevTotalDay = sqlCommand.Parameters.Add("@FINDPARAPREVTOTALDAY", SqlDbType.Int);
                //paraPrevTotalDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSalesInfoMainCndtnWork.PrevTotalDay.AddDays(1.0));
                paraPrevTotalDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSalesInfoMainCndtnWork.PrevTotalDay);
            }

            if (stockSalesInfoMainCndtnWork.CurrentTotalDay != DateTime.MinValue)
            {
                retstring += "AND STOCK.STOCKDATE<=@FINDPARACURRENTTOTALDAY ";
                SqlParameter paraCurrentTotalDay = sqlCommand.Parameters.Add("@FINDPARACURRENTTOTALDAY", SqlDbType.Int);
                paraCurrentTotalDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSalesInfoMainCndtnWork.CurrentTotalDay);
            }

            return retstring;
        }



        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� RsltInfo_DispatchInstsWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>wkStockSalesInfoWork</returns>
        /// <remarks>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.10</br>
        /// </remarks>
        private StockSalesInfoWork CopyToStockSalesInfoWorkFromReader(ref SqlDataReader myReader)
        {
            StockSalesInfoWork wkStockSalesInfoWork = new StockSalesInfoWork();


            #region �N���X�֊i�[
            //���_�R�[�h�w�b�_�w�b�_
            wkStockSalesInfoWork.SectionCodeHeader = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODE"));


            //���_����
            wkStockSalesInfoWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNM"));

            //�d����R�[�h		Int32 SupplierCdRF �w�b�_
            wkStockSalesInfoWork.SupplierCdHeader = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCD"));

            //�d���旪��		nvarchar		SupplierSnmRF
            wkStockSalesInfoWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNM"));


            //���͓�		Int32		InputDayRF
            wkStockSalesInfoWork.InputDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INPUTDAY"));
            //�d����		Int32	StockDateRF
            wkStockSalesInfoWork.StockDate = Convert.ToDateTime(DateTime.ParseExact(SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDATE")).ToString(), ct_DateFomat, null).ToString(ct_DateFomatWithLine));



            //�����`�[�ԍ��i���ׁj		nvarchar		PartySlipNumDtlRF
            wkStockSalesInfoWork.PartySlipNumDtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUM"));

            //�d���`�[�ԍ�		Int32	SupplierSlipNoRF
            wkStockSalesInfoWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNO"));

            //�d���s�ԍ�		Int32		StockRowNoRF
            wkStockSalesInfoWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNO"));


            //����`�[�ԍ�		nchar		SalesSlipNumRF
            string tempSalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUM"));
            wkStockSalesInfoWork.SalesSlipNum = tempSalesSlipNum;

            //�}�X�^�̃`�b�N
            //���_�R�[�h
            string tmpSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            int tmpSectionCodeDelete = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SECTIONCODELOGICALDELETECODERF"));
            if ((string.IsNullOrEmpty(tmpSectionCode)) || ((!(string.IsNullOrEmpty(tmpSectionCode))) && (tmpSectionCodeDelete == 1)))
            {
                wkStockSalesInfoWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODE"));
            }

            //�S����
            string tmpEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
            int tmpEmployeeCodeDelete = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EMPLOYEECODELOGICALDELETECODERF"));
            if ((string.IsNullOrEmpty(tmpEmployeeCode)) || ((!(string.IsNullOrEmpty(tmpEmployeeCode))) && (tmpEmployeeCodeDelete == 1)))
            {
                //�d���S���҃R�[�h		nchar		StockAgentCodeRF
                wkStockSalesInfoWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODE"));
            }

            //�d����}�X�^
            int tmpSupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            int tmpSupplierCdDelete = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDLOGICALDELETECODERF"));
            if ((tmpSupplierCd <= 0) || ((tmpSupplierCd > 0) && (tmpSupplierCdDelete == 1)))
            {
                //�d����R�[�h		Int32 SupplierCdRF �w�b�_
                wkStockSalesInfoWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCD"));
            }
            else
            {
                wkStockSalesInfoWork.SupplierCd = ct_UnderZeroFlgConst;
            }


            //BL���i�}�X�^
            int tmpBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            int blGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODE"));
            int tmpBLGoodsCodeDelete = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODELOGICALDELETECODERF"));
            if (((tmpBLGoodsCode >= 0) && (blGoodsCode >= 0) && (tmpBLGoodsCode != blGoodsCode))
                || ((tmpBLGoodsCode > 0) && (tmpBLGoodsCodeDelete == 1)))
            {
                //BL���i�R�[�h		Int32		BLGoodsCodeRF
                wkStockSalesInfoWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODE"));
            }
            else
            {
                wkStockSalesInfoWork.BLGoodsCode = ct_UnderZeroFlgConst;
            }

            //BL�O���[�v�}�X�^
            int tmpBLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            int blGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODE"));
            int tmpBLGroupCodeDelete = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODELOGICALDELETECODERF"));
            if (((tmpBLGroupCode >= 0) && (blGroupCode >= 0) && (tmpBLGroupCode != blGroupCode))
                || ((tmpBLGroupCode > 0) && (tmpBLGroupCodeDelete == 1)))
            {
                //BL�O���[�v�R�[�h		Int32	BLGroupCodeRF
                wkStockSalesInfoWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODE"));
            }
            else
            {
                wkStockSalesInfoWork.BLGroupCode = ct_UnderZeroFlgConst;
            }

            //�q�Ƀ}�X�^
            string tmpWarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            string warehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODE"));
            int tmpWarehouseCodeDelete = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WAREHOUSECODELOGICALDELETECODERF"));
            //if (((!(string.IsNullOrEmpty(tmpWarehouseCode)))
            //    && (!(string.IsNullOrEmpty(warehouseCode)))
            //    && ((!("0".Equals(warehouseCode.TrimEnd())))))
            //    || 
            if (((string.IsNullOrEmpty(tmpWarehouseCode))
            && (!string.IsNullOrEmpty(warehouseCode))
            && ((!("0".Equals(warehouseCode.TrimEnd())))))
            || ((!(string.IsNullOrEmpty(tmpWarehouseCode))) && (tmpWarehouseCodeDelete == 1)))
            {
                //�q�ɃR�[�h		nchar		WarehouseCodeRF
                wkStockSalesInfoWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODE"));
            }

            //���Ӑ�}�X�^
            //int tmpCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            //int tmpCustomerCodeDelete = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODELOGICALDELETECODERF"));
            //if ((tmpCustomerCode <= 0) || ((tmpCustomerCode > 0) && (tmpCustomerCodeDelete == 1)))
            //{
            //���Ӑ�R�[�h		Int32		CustomerCodeRF
            wkStockSalesInfoWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODE"));
            //}
            //else
            //{
            //    wkStockSalesInfoWork.CustomerCode = ct_UnderZeroFlgConst;
            //}

            //���㑶�݃`�F�b�N
            Int32 AcptAnOdrStatusSync = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSSYNC"));
            Int64 SalesSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMSYNC"));
            if (AcptAnOdrStatusSync == 30 && SalesSlipDtlNumSync != 0)
            {
                if (!string.IsNullOrEmpty(tempSalesSlipNum))
                {
                    wkStockSalesInfoWork.ExistFlg = normalFlgConst;
                }
                else
                {
                    wkStockSalesInfoWork.ExistFlg = errFlgConst;
                }
            }
            else 
            {
                wkStockSalesInfoWork.ExistFlg = stockOnleFlgConst;
            }

            //����
            double salesCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNT"));
            double stockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNT"));
            if (salesCount != stockCount)
            {
                wkStockSalesInfoWork.CountFlg = errFlgConst;
            }
            else
            {
                wkStockSalesInfoWork.CountFlg = normalFlgConst;
            }

            //����
            double salesPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOST"));
            double stockPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFL"));
            if (salesPrice != stockPrice)
            {
                wkStockSalesInfoWork.PriceFlg = errFlgConst;
            }
            else
            {
                wkStockSalesInfoWork.PriceFlg = normalFlgConst;
            }


            #endregion �N���X�֊i�[
            return wkStockSalesInfoWork;
        }


        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.10</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (string.IsNullOrEmpty(connectionText))
            {
                return null;
            }

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}
