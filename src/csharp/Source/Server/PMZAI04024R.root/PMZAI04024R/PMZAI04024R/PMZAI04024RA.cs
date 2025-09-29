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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �݌ɑg���E��������  �����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌ɑg���E���������̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 23015 �X�{ ��P</br>
    /// <br>Date       : 2008.10.06</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class StckAssemOvhulDB : RemoteDB, IStckAssemOvhulDB
    {
        /// <summary>
        /// �݌ɑg���E��������  �����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.10.06</br>
        /// </remarks>
        public StckAssemOvhulDB()
            :
            base("PMZAI04026D", "Broadleaf.Application.Remoting.ParamData.StckAssemOvhulRstWork", "GOODSSETRF")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɑg���E��������LIST��߂��܂�
        /// </summary>
        /// <param name="paraStckAssemOvhulRstWork">��������</param>
        /// <param name="paraStckAssemOvhulReqWork">��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɑg���E��������LIST��߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.10.06</br>
        public int Search(out object paraStckAssemOvhulRstWork, object paraStckAssemOvhulReqWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            paraStckAssemOvhulRstWork = null;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchStckAssemOvhul(out paraStckAssemOvhulRstWork, paraStckAssemOvhulReqWork, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StckAssemOvhulDB.Search");
                paraStckAssemOvhulRstWork = new ArrayList();
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

        #region [SearchStckAssemOvhul]
        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɑg���E��������LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="paraStckAssemOvhulRstWork">��������</param>
        /// <param name="paraStckAssemOvhulReqWork">��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɑg���E��������LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.10.06</br>
        public int SearchStckAssemOvhul(out object paraStckAssemOvhulRstWork, object paraStckAssemOvhulReqWork, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            StckAssemOvhulReqWork stckAssemOvhulReqWork = null;

            ArrayList stckAssemOvhulReqWorkList = paraStckAssemOvhulReqWork as ArrayList;
            ArrayList stckAssemOvhulRstWorkList = new ArrayList();

            if (stckAssemOvhulReqWorkList == null)
            {
                stckAssemOvhulReqWork = paraStckAssemOvhulReqWork as StckAssemOvhulReqWork;
            }
            else
            {
                if (stckAssemOvhulReqWorkList.Count > 0)
                    stckAssemOvhulReqWork = stckAssemOvhulReqWorkList[0] as StckAssemOvhulReqWork;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                //�������s
                status = SearchProc(ref stckAssemOvhulRstWorkList, stckAssemOvhulReqWork, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StckAssemOvhulDB.SearchStckAssemOvhul Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            paraStckAssemOvhulRstWork = stckAssemOvhulRstWorkList;

            return status;
        }
        #endregion  //[SearchStckAssemOvhul]

        #region [SearchProc]
        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɑg���E��������LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stckAssemOvhulRstWorkList">��������</param>
        /// <param name="stckAssemOvhulReqWork">��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɑg���E��������LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.10.06</br>
        private int SearchProc(ref ArrayList stckAssemOvhulRstWorkList, StckAssemOvhulReqWork stckAssemOvhulReqWork, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // �Ώۃe�[�u��
                // GOODSSETRF   GOODSS ���i�Z�b�g�}�X�^
                // STOCKRF      STOCKP �݌Ƀ}�X�^ ���e���i���
                // STOCKRF      STOCKS �݌Ƀ}�X�^ ���q���i���
                // SECINFOSETRF SECINF ���_���ݒ�}�X�^
                // WAREHOUSERF  WARHUS �q�Ƀ}�X�^
                // MAKERURF     MAKERU ���[�J�[�}�X�^(���[�U�[)
                // GOODSURF     GOODSUP ���i�}�X�^(���[�U�[) ���e���i���
                // GOODSURF     GOODSUS ���i�}�X�^(���[�U�[) ���q���i���

                #region [Select���쐬]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  STOCKP.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " ,STOCKP.GOODSNORF" + Environment.NewLine;
                selectTxt += "  AS PARENTGOODSNO" + Environment.NewLine;
                selectTxt += " ,GOODSUP.GOODSNAMEKANARF" + Environment.NewLine;
                selectTxt += "  AS PARENTGOODSNAMEKANA" + Environment.NewLine;
                selectTxt += " ,GOODSS.PARENTGOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " ,MAKERU.MAKERSHORTNAMERF" + Environment.NewLine;
                selectTxt += "  AS PARENTMAKERSHORTNAME" + Environment.NewLine;
                selectTxt += " ,STOCKP.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  AS PARENTWAREHOUSECODE" + Environment.NewLine;
                selectTxt += " ,WARHUS.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "  AS PARENTWAREHOUSENAME" + Environment.NewLine;
                selectTxt += " ,STOCKP.SUPPLIERSTOCKRF" + Environment.NewLine;
                selectTxt += "  AS PARENTSUPPLIERSTOCK" + Environment.NewLine;
                selectTxt += " ,STOCKP.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  AS PARENTMAXIMUMSTOCKCNT" + Environment.NewLine;
                selectTxt += " ,STOCKP.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  AS PARENTMINIMUMSTOCKCNT" + Environment.NewLine;
                selectTxt += " ,GOODSS.DISPLAYORDERRF" + Environment.NewLine;
                selectTxt += " ,GOODSS.SUBGOODSNORF" + Environment.NewLine;
                selectTxt += " ,GOODSUS.GOODSNAMEKANARF" + Environment.NewLine;
                selectTxt += "  AS SUBGOODSNAMEKANA" + Environment.NewLine;
                selectTxt += " ,GOODSS.SUBGOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " ,GOODSS.CNTFLRF" + Environment.NewLine;
                selectTxt += " ,GOODSUS.OFFERDATADIVRF" + Environment.NewLine;
                selectTxt += " ,STOCKS.SUPPLIERSTOCKRF" + Environment.NewLine;
                selectTxt += "  AS SUBSUPPLIERSTOCK" + Environment.NewLine;
                selectTxt += " ,SECINF.SECTWAREHOUSECD1RF" + Environment.NewLine;
                selectTxt += " ,SECINF.SECTWAREHOUSECD2RF" + Environment.NewLine;
                selectTxt += " ,SECINF.SECTWAREHOUSECD3RF" + Environment.NewLine;
                selectTxt += " FROM GOODSSETRF AS GOODSS" + Environment.NewLine;

                #region [JOIN]
                //�݌Ƀ}�X�^ ���e���i���
                selectTxt += " LEFT JOIN STOCKRF STOCKP" + Environment.NewLine;
                selectTxt += " ON  STOCKP.ENTERPRISECODERF=GOODSS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCKP.GOODSMAKERCDRF=GOODSS.PARENTGOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND STOCKP.GOODSNORF=GOODSS.PARENTGOODSNORF" + Environment.NewLine;

                //���_���ݒ�}�X�^
                selectTxt += " LEFT JOIN SECINFOSETRF SECINF" + Environment.NewLine;
                selectTxt += " ON  SECINF.ENTERPRISECODERF=STOCKP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SECINF.SECTIONCODERF=STOCKP.SECTIONCODERF" + Environment.NewLine;

                //�q�Ƀ}�X�^
                selectTxt += " LEFT JOIN WAREHOUSERF WARHUS" + Environment.NewLine;
                selectTxt += " ON  WARHUS.ENTERPRISECODERF=STOCKP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND WARHUS.WAREHOUSECODERF=STOCKP.WAREHOUSECODERF" + Environment.NewLine;

                //�݌Ƀ}�X�^ ���q���i���
                selectTxt += " LEFT JOIN STOCKRF STOCKS" + Environment.NewLine;
                selectTxt += " ON  STOCKS.ENTERPRISECODERF=GOODSS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCKS.GOODSMAKERCDRF=GOODSS.SUBGOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND STOCKS.GOODSNORF=GOODSS.SUBGOODSNORF" + Environment.NewLine;

                //MAKERU ���[�J�[�}�X�^(���[�U�[)
                selectTxt += " LEFT JOIN MAKERURF MAKERU" + Environment.NewLine;
                selectTxt += " ON  MAKERU.ENTERPRISECODERF=GOODSS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND MAKERU.GOODSMAKERCDRF=GOODSS.PARENTGOODSMAKERCDRF" + Environment.NewLine;

                //���i�}�X�^(���[�U�[) ���e���i���
                selectTxt += " LEFT JOIN GOODSURF GOODSUP" + Environment.NewLine;
                selectTxt += " ON  GOODSUP.ENTERPRISECODERF=GOODSS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GOODSUP.GOODSMAKERCDRF=GOODSS.PARENTGOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND GOODSUP.GOODSNORF=GOODSS.PARENTGOODSNORF" + Environment.NewLine;

                //���i�}�X�^(���[�U�[) ���q���i���
                selectTxt += " LEFT JOIN GOODSURF GOODSUS" + Environment.NewLine;
                selectTxt += " ON  GOODSUS.ENTERPRISECODERF=GOODSS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GOODSUS.GOODSMAKERCDRF=GOODSS.SUBGOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND GOODSUS.GOODSNORF=GOODSS.SUBGOODSNORF" + Environment.NewLine;
                #endregion  //[JOIN]

                #region [WHERE]
                selectTxt += " WHERE" + Environment.NewLine;

                //��ƃR�[�h
                selectTxt += " GOODSS.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stckAssemOvhulReqWork.EnterpriseCode);

                //�_���폜�敪
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    selectTxt += " AND STOCKP.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    selectTxt += " AND STOCKP.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }

                //���_�R�[�h
                if (stckAssemOvhulReqWork.SectionCode != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in stckAssemOvhulReqWork.SectionCode)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }
                    if (sectionCodestr != "")
                    {
                        selectTxt += " AND STOCKP.SECTIONCODERF IN (" + sectionCodestr + ") ";
                    }
                    selectTxt += Environment.NewLine;
                }

                //���i�ԍ�
                if (stckAssemOvhulReqWork.GoodsNo != "")
                {
                    selectTxt += " AND GOODSS.PARENTGOODSNORF LIKE @FINDPARENTGOODSNO";
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDPARENTGOODSNO", SqlDbType.NVarChar);
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(stckAssemOvhulReqWork.GoodsNo + "%");
                }

                //���_�q�ɃR�[�h
                selectTxt += " AND (" + Environment.NewLine;
                selectTxt += "         STOCKP.WAREHOUSECODERF=SECINF.SECTWAREHOUSECD1RF" + Environment.NewLine;
                selectTxt += "      OR STOCKP.WAREHOUSECODERF=SECINF.SECTWAREHOUSECD2RF" + Environment.NewLine;
                selectTxt += "      OR STOCKP.WAREHOUSECODERF=SECINF.SECTWAREHOUSECD3RF" + Environment.NewLine;
                selectTxt += "     )" + Environment.NewLine;
                #endregion  //[WHERE]

                #endregion  //[Select���쐬]

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    stckAssemOvhulRstWorkList.Add(CopyToStckAssemOvhulRstWorkFromReader(ref myReader, stckAssemOvhulReqWork));
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
                base.WriteErrorLog(ex, "StckAssemOvhulDB.SearchProc Exception=" + ex.Message);
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
            }

            return status;
        }
        #endregion //[SearchProc]

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� StckAssemOvhulRstWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="stckAssemOvhulReqWork">��������</param>
        /// <returns>StckAssemOvhulRstWork</returns>
        /// <remarks>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.10.06</br>
        /// </remarks>
        private StckAssemOvhulRstWork CopyToStckAssemOvhulRstWorkFromReader(ref SqlDataReader myReader, StckAssemOvhulReqWork stckAssemOvhulReqWork)
        {
            StckAssemOvhulRstWork ResultWork = new StckAssemOvhulRstWork();

            #region �N���X�֊i�[
            ResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            ResultWork.ParentGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARENTGOODSNO"));
            ResultWork.ParentGoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARENTGOODSNAMEKANA"));
            ResultWork.ParentGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARENTGOODSMAKERCDRF"));
            ResultWork.ParentMakerShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARENTMAKERSHORTNAME"));
            ResultWork.ParentWarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARENTWAREHOUSECODE"));
            ResultWork.ParentWarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARENTWAREHOUSENAME"));
            ResultWork.ParentSupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARENTSUPPLIERSTOCK"));
            ResultWork.ParentMaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARENTMAXIMUMSTOCKCNT"));
            ResultWork.ParentMinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARENTMINIMUMSTOCKCNT"));
            ResultWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
            ResultWork.SubGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBGOODSNORF"));
            ResultWork.SubGoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBGOODSNAMEKANA"));
            ResultWork.SubGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBGOODSMAKERCDRF"));
            ResultWork.CntFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CNTFLRF"));
            ResultWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));
            ResultWork.SubSupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUBSUPPLIERSTOCK"));
            ResultWork.SectWarehouseCd1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD1RF"));
            ResultWork.SectWarehouseCd2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD2RF"));
            ResultWork.SectWarehouseCd3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD3RF"));
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
        /// <br>Date       : 2008.10.06</br>
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
