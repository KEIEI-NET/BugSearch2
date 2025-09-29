using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �|���}�X�^���  �����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �|���}�X�^����̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 23015 �X�{ ��P</br>
    /// <br>Date       : 2008.10.01</br>
    /// <br></br>
    /// <br>Update Note: 2011/07/22 ����� NS���[�U�[���Ǘv�]�ꗗ�̘A��898�̑Ή�</br>
    /// <br>             ���[�U�[���i�w���ǉ�����</br>
    /// <br></br>
    /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2020/06/18</br>
    /// </remarks>
    [Serializable]
    public class RatePrtDB : RemoteDB, IRatePrtDB
    {
        /// <summary>
        /// �|���}�X�^���  �����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.10.01</br>
        /// <br></br>
        /// <br>Update Note: �i�ԞB�������ǉ� </br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.30</br>
        /// </remarks>
        public RatePrtDB()
            :
            base("PMKHN02018D", "Broadleaf.Application.Remoting.ParamData.RatePrtRstWork", "RATERF")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̊|���}�X�^LIST��߂��܂�
        /// </summary>
        /// <param name="paraRatePrtRstWork">��������</param>
        /// <param name="paraRatePrtReqWork">��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̊|���}�X�^LIST��߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.10.01</br>
        public int Search(out object paraRatePrtRstWork, object paraRatePrtReqWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            paraRatePrtRstWork = null;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchRatePrt(out paraRatePrtRstWork, paraRatePrtReqWork, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RatePrtDB.Search");
                paraRatePrtRstWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        #endregion  //[Search]

        #region [SearchRatePrt]
        /// <summary>
        /// �w�肳�ꂽ�����̊|���}�X�^LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="paraRatePrtRstWork">��������</param>
        /// <param name="paraRatePrtReqWork">��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̊|���}�X�^LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.10.01</br>
        public int SearchRatePrt(out object paraRatePrtRstWork, object paraRatePrtReqWork, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            RatePrtReqWork ratePrtReqWork = null;

            ArrayList ratePrtReqWorkList = paraRatePrtReqWork as ArrayList;
            ArrayList ratePrtRstWorkList = new ArrayList();

            if (ratePrtReqWorkList == null)
            {
                ratePrtReqWork = paraRatePrtReqWork as RatePrtReqWork;
            }
            else
            {
                if (ratePrtReqWorkList.Count > 0)
                    ratePrtReqWork = ratePrtReqWorkList[0] as RatePrtReqWork;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                //�������s
                status = SearchProc(ref ratePrtRstWorkList, ratePrtReqWork, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RatePrtDB.SearchRatePrt Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            paraRatePrtRstWork = ratePrtRstWorkList;

            return status;
        }
        #endregion  //[SearchRatePrt]

        #region [SearchProc]
        /// <summary>
        /// �w�肳�ꂽ�����̊|���}�X�^LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="ratePrtRstWorkList">��������</param>
        /// <param name="ratePrtReqWork">��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̊|���}�X�^LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.10.01</br>
        /// <br>Update Note : 2011/07/22 ����� NS���[�U�[���Ǘv�]�ꗗ�̘A��898�̑Ή�</br>
        /// <br>              ���[�U�[���i�w���ǉ�����</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/06/18</br>
        /// </remarks>
        private int SearchProc(ref ArrayList ratePrtRstWorkList, RatePrtReqWork ratePrtReqWork, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
            // �ϊ����Ăяo��
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // �ϊ���񏉊���
            convertDoubleRelease.ReleaseInitLib();
            // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // �Ώۃe�[�u��
                // RATERF       RATE �|���}�X�^
                // SECINFOSETRF SCIF ���_���ݒ�}�X�^
                // CUSTOMERRF   CSTM ���Ӑ�}�X�^
                // SUPPLIERRF   SPLR �d����}�X�^
                // MAKERURF     MKER ���[�J�[�}�X�^(���[�U�[)
                // BLGROUPURF   BLGR BL�O���[�v�}�X�^(���[�U�[)
                // BLGOODSCDURF BLGS BL���i�R�[�h�}�X�^(���[�U�[)
                // GOODSURF     GODS ���i�}�X�^(���[�U�[)

                #region [Select���쐬]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   RATE.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,SCIF.SECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "  ,RATE.RATESETTINGDIVIDERF" + Environment.NewLine;
                selectTxt += "  ,RATE.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,RATE.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "  ,CSTM.CUSTOMERSNMRF" + Environment.NewLine;
                selectTxt += "  ,RATE.CUSTRATEGRPCODERF" + Environment.NewLine;
                selectTxt += "  ,RATE.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "  ,SPLR.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += "  ,RATE.GOODSMAKERCDRF" + Environment.NewLine;
                //selectTxt += "  ,MKER.MAKERSHORTNAMERF" + Environment.NewLine;
                selectTxt += "  ,MKER.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "  ,RATE.GOODSRATERANKRF" + Environment.NewLine;
                selectTxt += "  ,RATE.GOODSRATEGRPCODERF" + Environment.NewLine;
                selectTxt += "  ,RATE.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "  ,BLGR.BLGROUPKANANAMERF" + Environment.NewLine;
                selectTxt += "  ,RATE.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,BLGS.BLGOODSHALFNAMERF" + Environment.NewLine;
                selectTxt += "  ,RATE.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,GODS.GOODSNAMEKANARF" + Environment.NewLine;
                selectTxt += "  ,RATE.LOTCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,(CASE WHEN RATE.UNITPRICEKINDRF=1 THEN RATE.RATEVALRF ELSE 0.0 END) AS SALRATEVAL" + Environment.NewLine;
                selectTxt += "  ,(CASE WHEN RATE.UNITPRICEKINDRF=1 THEN RATE.PRICEFLRF ELSE 0.0 END) AS SALPRICEFL" + Environment.NewLine;
                selectTxt += "  ,(CASE WHEN RATE.UNITPRICEKINDRF=1 THEN RATE.UPRATERF ELSE 0.0 END) AS SALUPRATE" + Environment.NewLine;
                selectTxt += "  ,(CASE WHEN RATE.UNITPRICEKINDRF=1 THEN RATE.GRSPROFITSECURERATERF ELSE 0.0 END) AS GRSPROFITSECURERATE" + Environment.NewLine;
                selectTxt += "  ,(CASE WHEN RATE.UNITPRICEKINDRF=2 THEN RATE.RATEVALRF ELSE 0.0 END) AS CSTRATEVAL" + Environment.NewLine;
                selectTxt += "  ,(CASE WHEN RATE.UNITPRICEKINDRF=2 THEN RATE.PRICEFLRF ELSE 0.0 END) AS CSTPRICEFL" + Environment.NewLine;
                selectTxt += "  ,(CASE WHEN RATE.UNITPRICEKINDRF=3 THEN RATE.PRICEFLRF ELSE 0.0 END) AS PRCPRICEFL" + Environment.NewLine;
                selectTxt += "  ,(CASE WHEN RATE.UNITPRICEKINDRF=3 THEN RATE.UPRATERF ELSE 0.0 END) AS PRCUPRATE" + Environment.NewLine;
                selectTxt += "  ,RATE.UNPRCFRACPROCUNITRF" + Environment.NewLine;
                selectTxt += "  ,RATE.UNPRCFRACPROCDIVRF" + Environment.NewLine;
                selectTxt += "  ,RATE.UNITPRICEKINDRF" + Environment.NewLine;
                // --- ADD 2011/07/22 ---------->>>>>
                if (ratePrtReqWork.UnitPriceKind == 3 && ratePrtReqWork.RateMngGoodsCdKind == 0)
                {
                    selectTxt += "  ,GODSPRICE.LISTPRICERF AS PRICE" + Environment.NewLine;
                }
                // --- ADD 22011/07/22  ----------<<<<<
                //FROM
                selectTxt += " FROM RATERF AS RATE" + Environment.NewLine;
                //JOIN
                //���_���ݒ�}�X�^
                selectTxt += " LEFT JOIN SECINFOSETRF SCIF" + Environment.NewLine;
                selectTxt += " ON  SCIF.ENTERPRISECODERF=RATE.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SCIF.SECTIONCODERF=RATE.SECTIONCODERF" + Environment.NewLine;
                //���Ӑ�}�X�^
                selectTxt += " LEFT JOIN CUSTOMERRF CSTM" + Environment.NewLine;
                selectTxt += " ON  CSTM.ENTERPRISECODERF=RATE.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND CSTM.CUSTOMERCODERF=RATE.CUSTOMERCODERF" + Environment.NewLine;
                //�d����}�X�^
                selectTxt += " LEFT JOIN SUPPLIERRF SPLR" + Environment.NewLine;
                selectTxt += " ON  SPLR.ENTERPRISECODERF=RATE.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SPLR.SUPPLIERCDRF=RATE.SUPPLIERCDRF" + Environment.NewLine;
                //���[�J�[�}�X�^(���[�U�[)
                selectTxt += " LEFT JOIN MAKERURF MKER" + Environment.NewLine;
                selectTxt += " ON  MKER.ENTERPRISECODERF=RATE.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND MKER.GOODSMAKERCDRF=RATE.GOODSMAKERCDRF" + Environment.NewLine;
                //BL�O���[�v�}�X�^(���[�U�[)
                selectTxt += " LEFT JOIN BLGROUPURF BLGR" + Environment.NewLine;
                selectTxt += " ON  BLGR.ENTERPRISECODERF=RATE.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND BLGR.BLGROUPCODERF=RATE.BLGROUPCODERF" + Environment.NewLine;
                //BL���i�R�[�h�}�X�^(���[�U�[)
                selectTxt += " LEFT JOIN BLGOODSCDURF BLGS" + Environment.NewLine;
                selectTxt += " ON  BLGS.ENTERPRISECODERF=RATE.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND BLGS.BLGOODSCODERF=RATE.BLGOODSCODERF" + Environment.NewLine;
                //���i�}�X�^(���[�U�[)
                selectTxt += " LEFT JOIN GOODSURF GODS" + Environment.NewLine;
                selectTxt += " ON  GODS.ENTERPRISECODERF=RATE.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GODS.GOODSMAKERCDRF=RATE.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND GODS.GOODSNORF=RATE.GOODSNORF" + Environment.NewLine;
                // --- ADD 2011/07/22 ---------->>>>>
                if (ratePrtReqWork.UnitPriceKind == 3 && ratePrtReqWork.RateMngGoodsCdKind == 0)
                {
                    //���i�}�X�^�i���[�U�[�j
                    selectTxt += " LEFT JOIN GOODSPRICEURF GODSPRICE" + Environment.NewLine;
                    selectTxt += " ON  GODSPRICE.ENTERPRISECODERF=RATE.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += " AND GODSPRICE.GOODSMAKERCDRF=RATE.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += " AND GODSPRICE.GOODSNORF=RATE.GOODSNORF" + Environment.NewLine;
                }
                // --- ADD 22011/07/22  ----------<<<<<

                //WHERE
                selectTxt += MakeWhereString(ref sqlCommand, ratePrtReqWork, logicalMode);
                #endregion  //[Select���쐬]

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                    // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
                    //ratePrtRstWorkList.Add(CopyToRatePrtRstWorkFromReader(ref myReader, ratePrtReqWork));
                        ratePrtRstWorkList.Add(CopyToRatePrtRstWorkFromReader(ref myReader, ratePrtReqWork, convertDoubleRelease));
                    // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RatePrtDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
                // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
                // ���
                convertDoubleRelease.Dispose();
                // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
            }

            return status;
        }
        #endregion //[SearchProc]

        #region [WHERE�吶������]
        /// <summary>
        /// WHERE�吶������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="ratePrtReqWork">��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns></returns>
        /// <br>Note       : WHERE�吶������</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.10.01</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, RatePrtReqWork ratePrtReqWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = "";
            retstring += " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " RATE.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(ratePrtReqWork.EnterpriseCode);

            //�_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND RATE.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND RATE.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //���_�R�[�h
            if (ratePrtReqWork.SectionCode != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in ratePrtReqWork.SectionCode)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }
                if (sectionCodestr != "")
                {
                    retstring += " AND RATE.SECTIONCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //�P�����
            if (ratePrtReqWork.UnitPriceKind != 0)
            {
                retstring += " AND RATE.UNITPRICEKINDRF=@FINDUNITPRICEKIND" + Environment.NewLine;
                SqlParameter paraUnitPriceKind = sqlCommand.Parameters.Add("@FINDUNITPRICEKIND", SqlDbType.Int);
                paraUnitPriceKind.Value = SqlDataMediator.SqlSetInt32(ratePrtReqWork.UnitPriceKind);
            }

            //�ݒ���@
            if (ratePrtReqWork.RateMngGoodsCdKind != 0)
                retstring += " AND RATE.RATEMNGGOODSCDRF<>'A'" + Environment.NewLine;
            else
                retstring += " AND RATE.RATEMNGGOODSCDRF='A'" + Environment.NewLine;

            //�|���ݒ�敪
            if (ratePrtReqWork.RateSettingDivideSt != "")
            {
                retstring += " AND RATE.RATESETTINGDIVIDERF>=@RATESETTINGDIVIDEST" + Environment.NewLine;
                SqlParameter paraRateSettingDivideSt = sqlCommand.Parameters.Add("@RATESETTINGDIVIDEST", SqlDbType.NChar);
                paraRateSettingDivideSt.Value = SqlDataMediator.SqlSetString(ratePrtReqWork.RateSettingDivideSt);
            }
            if (ratePrtReqWork.RateSettingDivideEd != "")
            {
                retstring += " AND RATE.RATESETTINGDIVIDERF<=@RATESETTINGDIVIDEED" + Environment.NewLine;
                SqlParameter paraRateSettingDivideEd = sqlCommand.Parameters.Add("@RATESETTINGDIVIDEED", SqlDbType.NChar);
                paraRateSettingDivideEd.Value = SqlDataMediator.SqlSetString(ratePrtReqWork.RateSettingDivideEd);
            }

            //���Ӑ�R�[�h
            if (ratePrtReqWork.CustomerCodeSt != 0)
            {
                retstring += " AND RATE.CUSTOMERCODERF>=@CUSTOMERCODEST" + Environment.NewLine;
                SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@CUSTOMERCODEST", SqlDbType.Int);
                paraCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(ratePrtReqWork.CustomerCodeSt);
            }
            if (ratePrtReqWork.CustomerCodeEd != 99999999)
            {
                retstring += " AND RATE.CUSTOMERCODERF<=@CUSTOMERCODEED" + Environment.NewLine;
                SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@CUSTOMERCODEED", SqlDbType.Int);
                paraCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(ratePrtReqWork.CustomerCodeEd);
            }

            //���Ӑ�|���O���[�v�R�[�h
            if (ratePrtReqWork.CustRateGrpCodeSt != 0)
            {
                retstring += " AND RATE.CUSTRATEGRPCODERF>=@CUSTRATEGRPCODEST" + Environment.NewLine;
                SqlParameter paraCustRateGrpCodeSt = sqlCommand.Parameters.Add("@CUSTRATEGRPCODEST", SqlDbType.Int);
                paraCustRateGrpCodeSt.Value = SqlDataMediator.SqlSetInt32(ratePrtReqWork.CustRateGrpCodeSt);
            }
            if (ratePrtReqWork.CustRateGrpCodeEd != 9999)
            {
                retstring += " AND RATE.CUSTRATEGRPCODERF<=@CUSTRATEGRPCODE" + Environment.NewLine;
                SqlParameter paraCustRateGrpCodeEd = sqlCommand.Parameters.Add("@CUSTRATEGRPCODE", SqlDbType.Int);
                paraCustRateGrpCodeEd.Value = SqlDataMediator.SqlSetInt32(ratePrtReqWork.CustRateGrpCodeEd);
            }

            //�d����R�[�h
            if (ratePrtReqWork.SupplierCdSt != 0)
            {
                retstring += " AND RATE.SUPPLIERCDRF>=@SUPPLIERCDST" + Environment.NewLine;
                SqlParameter paraSupplierCdSt = sqlCommand.Parameters.Add("@SUPPLIERCDST", SqlDbType.Int);
                paraSupplierCdSt.Value = SqlDataMediator.SqlSetInt32(ratePrtReqWork.SupplierCdSt);
            }
            if (ratePrtReqWork.SupplierCdEd != 999999)
            {
                retstring += " AND RATE.SUPPLIERCDRF<=@SUPPLIERCDED" + Environment.NewLine;
                SqlParameter paraSupplierCdEd = sqlCommand.Parameters.Add("@SUPPLIERCDED", SqlDbType.Int);
                paraSupplierCdEd.Value = SqlDataMediator.SqlSetInt32(ratePrtReqWork.SupplierCdEd);
            }

            //���i���[�J�[�R�[�h
            if (ratePrtReqWork.GoodsMakerCdSt != 0)
            {
                retstring += " AND RATE.GOODSMAKERCDRF>=@GOODSMAKERCDST" + Environment.NewLine;
                SqlParameter paraGoodsMakerCdSt = sqlCommand.Parameters.Add("@GOODSMAKERCDST", SqlDbType.Int);
                paraGoodsMakerCdSt.Value = SqlDataMediator.SqlSetInt32(ratePrtReqWork.GoodsMakerCdSt);
            }
            if (ratePrtReqWork.GoodsMakerCdEd != 9999)
            {
                retstring += " AND RATE.GOODSMAKERCDRF<=@GOODSMAKERCDED" + Environment.NewLine;
                SqlParameter paraGoodsMakerCdEd = sqlCommand.Parameters.Add("@GOODSMAKERCDED", SqlDbType.Int);
                paraGoodsMakerCdEd.Value = SqlDataMediator.SqlSetInt32(ratePrtReqWork.GoodsMakerCdEd);
            }

            //���i�|�������N
            if (ratePrtReqWork.GoodsRateRankSt != "")
            {
                retstring += " AND RATE.GOODSRATERANKRF>=@GOODSRATERANKST" + Environment.NewLine;
                SqlParameter paraGoodsRateRankSt = sqlCommand.Parameters.Add("@GOODSRATERANKST", SqlDbType.NChar);
                paraGoodsRateRankSt.Value = SqlDataMediator.SqlSetString(ratePrtReqWork.GoodsRateRankSt);
            }
            if (ratePrtReqWork.GoodsRateRankEd != "")
            {
                retstring += " AND RATE.GOODSRATERANKRF<=@GOODSRATERANKED" + Environment.NewLine;
                SqlParameter paraGoodsRateRankEd = sqlCommand.Parameters.Add("@GOODSRATERANKED", SqlDbType.NChar);
                paraGoodsRateRankEd.Value = SqlDataMediator.SqlSetString(ratePrtReqWork.GoodsRateRankEd);
            }

            //���i�|���O���[�v�R�[�h
            if (ratePrtReqWork.GoodsRateGrpCodeSt != 0)
            {
                retstring += " AND RATE.GOODSRATEGRPCODERF>=@GOODSRATEGRPCODEST" + Environment.NewLine;
                SqlParameter paraGoodsRateGrpCodeSt = sqlCommand.Parameters.Add("@GOODSRATEGRPCODEST", SqlDbType.Int);
                paraGoodsRateGrpCodeSt.Value = SqlDataMediator.SqlSetInt32(ratePrtReqWork.GoodsRateGrpCodeSt);
            }
            if (ratePrtReqWork.GoodsRateGrpCodeEd != 9999)
            {
                retstring += " AND RATE.GOODSRATEGRPCODERF<=@GOODSRATEGRPCODEED" + Environment.NewLine;
                SqlParameter paraGoodsRateGrpCodeEd = sqlCommand.Parameters.Add("@GOODSRATEGRPCODEED", SqlDbType.Int);
                paraGoodsRateGrpCodeEd.Value = SqlDataMediator.SqlSetInt32(ratePrtReqWork.GoodsRateGrpCodeEd);
            }

            //BL�O���[�v�R�[�h
            if (ratePrtReqWork.BLGroupCodeSt != 0)
            {
                retstring += " AND RATE.BLGROUPCODERF>=@BLGROUPCODEST" + Environment.NewLine;
                SqlParameter paraBLGroupCodeSt = sqlCommand.Parameters.Add("@BLGROUPCODEST", SqlDbType.Int);
                paraBLGroupCodeSt.Value = SqlDataMediator.SqlSetInt32(ratePrtReqWork.BLGroupCodeSt);
            }
            if (ratePrtReqWork.BLGroupCodeEd != 99999)
            {
                retstring += " AND RATE.BLGROUPCODERF<=@BLGROUPCODEED" + Environment.NewLine;
                SqlParameter paraBLGroupCodeEd = sqlCommand.Parameters.Add("@BLGROUPCODEED", SqlDbType.Int);
                paraBLGroupCodeEd.Value = SqlDataMediator.SqlSetInt32(ratePrtReqWork.BLGroupCodeEd);
            }

            //BL���i�R�[�h
            if (ratePrtReqWork.BLGoodsCodeSt != 0)
            {
                retstring += " AND RATE.BLGOODSCODERF>=@BLGOODSCODEST" + Environment.NewLine;
                SqlParameter paraBLGoodsCodeSt = sqlCommand.Parameters.Add("@BLGOODSCODEST", SqlDbType.Int);
                paraBLGoodsCodeSt.Value = SqlDataMediator.SqlSetInt32(ratePrtReqWork.BLGoodsCodeSt);
            }
            if (ratePrtReqWork.BLGoodsCodeEd != 99999)
            {
                retstring += " AND RATE.BLGOODSCODERF<=@BLGOODSCODEED" + Environment.NewLine;
                SqlParameter paraBLGoodsCodeEd = sqlCommand.Parameters.Add("@BLGOODSCODEED", SqlDbType.Int);
                paraBLGoodsCodeEd.Value = SqlDataMediator.SqlSetInt32(ratePrtReqWork.BLGoodsCodeEd);
            }

            //���i�ԍ�
            if (ratePrtReqWork.GoodsNoSt != "")
            {
                // ADD 2008.10.30 >>>
                if (ratePrtReqWork.GoodsNoSt.LastIndexOf("*") >= 0)
                {
                    String[] GoodsNoSt = ratePrtReqWork.GoodsNoSt.Split(new Char[] { '*' });

                    retstring += " AND ( RATE.GOODSNORF>=@GOODSNOST OR RATE.GOODSNORF LIKE @GOODSNOST )" + Environment.NewLine;
                    SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@GOODSNOST", SqlDbType.NVarChar);
                    paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(GoodsNoSt[0] + "%");

                }
                else
                {
                // ADD 2008.10.30 <<<    
                    retstring += " AND RATE.GOODSNORF>=@GOODSNOST" + Environment.NewLine;
                    SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@GOODSNOST", SqlDbType.NVarChar);
                    paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(ratePrtReqWork.GoodsNoSt);
                } // ADD 2008.10.30 
            }
            if (ratePrtReqWork.GoodsNoEd != "")
            {
                // ADD 2008.10.30 >>>
                if (ratePrtReqWork.GoodsNoEd.LastIndexOf("*") >= 0)
                {
                    String[] GoodsNoEd = ratePrtReqWork.GoodsNoEd.Split(new Char[] {'*'});

                    retstring += " AND (RATE.GOODSNORF<=@GOODSNOED OR RATE.GOODSNORF LIKE @GOODSNOED )" + Environment.NewLine;
                    SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@GOODSNOED", SqlDbType.NVarChar);
                    paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(GoodsNoEd[0] + "%");
                }
                else
                {
                // ADD 2008.10.30 <<<
                    retstring += " AND RATE.GOODSNORF<=@GOODSNOED" + Environment.NewLine;
                    SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@GOODSNOED", SqlDbType.NVarChar);
                    paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(ratePrtReqWork.GoodsNoEd);

                } // ADD 2008.10.30 
            }

            // --- ADD 2011/07/22 ---------->>>>>
            if (ratePrtReqWork.UnitPriceKind == 3 && ratePrtReqWork.RateMngGoodsCdKind == 0)
            {
                retstring += " AND (GODSPRICE.ENTERPRISECODERF IS NULL OR GODSPRICE.PRICESTARTDATERF = (SELECT MAX(PRICESTARTDATERF) FROM GOODSPRICEURF GOODSPRICEU_B WHERE GOODSPRICEU_B.ENTERPRISECODERF=RATE.ENTERPRISECODERF AND GOODSPRICEU_B.GOODSMAKERCDRF=RATE.GOODSMAKERCDRF AND GOODSPRICEU_B.GOODSNORF=RATE.GOODSNORF AND GOODSPRICEU_B.PRICESTARTDATERF <= @DATE))" + Environment.NewLine;
                SqlParameter paraGoodsDate = sqlCommand.Parameters.Add("@DATE", SqlDbType.Int);
                paraGoodsDate.Value = SqlDataMediator.SqlSetInt32(Int32.Parse(DateTime.Today.ToString("yyyyMMdd")));
            }
            // --- ADD 22011/07/22  ----------<<<<<
            #endregion  //WHERE���쐬

            return retstring;
        }
        #endregion  //[WHERE�吶������]

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� RatePrtRstWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="ratePrtReqWork">��������</param>
        /// <param name="convertDoubleRelease">���l�ϊ�����</param>
        /// <returns>RatePrtRstWork</returns>
        /// <remarks>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.10.01</br>
        /// <br></br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/06/18</br>
        /// </remarks>
        // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
        //private RatePrtRstWork CopyToRatePrtRstWorkFromReader(ref SqlDataReader myReader, RatePrtReqWork ratePrtReqWork)
        private RatePrtRstWork CopyToRatePrtRstWorkFromReader(ref SqlDataReader myReader, RatePrtReqWork ratePrtReqWork, ConvertDoubleRelease convertDoubleRelease)
        // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
        {
            RatePrtRstWork ResultWork = new RatePrtRstWork();

            #region �N���X�֊i�[
            ResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            ResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            ResultWork.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESETTINGDIVIDERF"));
            ResultWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            ResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            ResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            ResultWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
            ResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            ResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            ResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            //ResultWork.MakerShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERSHORTNAMERF"));
            ResultWork.MakerShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            ResultWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            ResultWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));
            ResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            ResultWork.BLGroupKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPKANANAMERF"));
            ResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            ResultWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
            ResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            ResultWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            ResultWork.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LOTCOUNTRF"));
            ResultWork.SalRateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALRATEVAL"));
            ResultWork.SalPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALPRICEFL"));
            ResultWork.SalUpRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALUPRATE"));
            ResultWork.GrsProfitSecureRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GRSPROFITSECURERATE"));
            ResultWork.CstRateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CSTRATEVAL"));
            ResultWork.CstPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CSTPRICEFL"));
            ResultWork.PrcPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRCPRICEFL"));
            // --- ADD 2011/07/22 ---------->>>>>
            if (ratePrtReqWork.UnitPriceKind == 3 && ratePrtReqWork.RateMngGoodsCdKind == 0)
            {
                // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
                //ResultWork.Price = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICE"));
                convertDoubleRelease.EnterpriseCode = ratePrtReqWork.EnterpriseCode;
                convertDoubleRelease.GoodsMakerCd = ResultWork.GoodsMakerCd;
                convertDoubleRelease.GoodsNo = ResultWork.GoodsNo;
                convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICE"));

                // �ϊ��������s
                convertDoubleRelease.ReleaseProc();

                ResultWork.Price = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
            }
            // --- ADD 22011/07/22  ----------<<<<<
            ResultWork.PrcUpRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRCUPRATE"));
            ResultWork.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UNPRCFRACPROCUNITRF"));
            ResultWork.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCFRACPROCDIVRF"));
            ResultWork.UnitPriceKind = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITPRICEKINDRF"));
            #endregion  //�N���X�֊i�[

            return ResultWork;
        }
        #endregion  //[�N���X�i�[����]

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.10.01</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion  //[�R�l�N�V������������]
    }
}
