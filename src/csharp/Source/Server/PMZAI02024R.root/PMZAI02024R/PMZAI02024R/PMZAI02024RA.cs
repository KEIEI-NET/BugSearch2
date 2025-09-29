using System;
using System.Collections;
using System.Collections.Generic;
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
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �݌Ƀ}�X�^�ꗗ�\���DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ƀ}�X�^�ꗗ�\����̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 20081</br>
    /// <br>Date       : 2008.08.20</br>
    /// <br></br>
    /// <br>Update Note: �o�͍��ڂ����[�J�[���̂��烁�[�J�[���̂ɕύX</br>
    /// <br>Programmer : 22008 ����</br>
    /// <br>Date       : 2009/06/01</br>
    /// <br>Update Note: 2012/05/29 zhangy3 </br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 2012/06/27�z�M��</br>
    /// <br>             Redmine#30029 �݌Ƀ}�X�^�ꗗ��� ����������ł̈���s�</br>
    /// <br></br>
    /// <br>Update Note: �d�a�d�΍�</br>
    /// <br>Programmer : 32653 ���J �M�m</br>
    /// <br>Date       : 2020/06/17</br>
    /// </remarks>
    [Serializable]
    public class StockMasterTblDB : RemoteDB, IStockMasterTblDB
    {
        /// <summary>
        /// �݌Ƀ}�X�^�ꗗ�\���DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.20</br>
        /// </remarks>
        public StockMasterTblDB()
            :
            base("PMZAI02026D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_StockMasterTblWork", "STOCKMASTERTBLRF")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ƀ}�X�^�ꗗ�\����f�[�^��߂��܂�
        /// </summary>
        /// <param name="rsltInfo_StockMasterTblWork">��������</param>
        /// <param name="extrInfo_StockMasterTblWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ƀ}�X�^�ꗗ�\����f�[�^��߂��܂�</br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.20</br>
        public int Search(out object rsltInfo_StockMasterTblWork, object extrInfo_StockMasterTblWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            rsltInfo_StockMasterTblWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchStockMasterTbl(out rsltInfo_StockMasterTblWork, extrInfo_StockMasterTblWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMasterTblDB.Search");
                rsltInfo_StockMasterTblWork = new ArrayList();
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

        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ƀ}�X�^�ꗗ�\����f�[�^��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objRsltInfo_StockMasterTblWork">��������</param>
        /// <param name="objExtrInfo_StockMasterTblWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ƀ}�X�^�ꗗ�\����f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.20</br>
        private int SearchStockMasterTbl(out object objRsltInfo_StockMasterTblWork, object objExtrInfo_StockMasterTblWork, ref SqlConnection sqlConnection)
        {
            ExtrInfo_StockMasterTblWork paramWork = null;

            ArrayList paramWorkList = objExtrInfo_StockMasterTblWork as ArrayList;

            if (paramWorkList == null)
            {
                paramWork = objExtrInfo_StockMasterTblWork as ExtrInfo_StockMasterTblWork;
            }
            else
            {
                if (paramWorkList.Count > 0)
                    paramWork = paramWorkList[0] as ExtrInfo_StockMasterTblWork;
            }

            ArrayList rsltInfo_StockMasterTblWork = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            // �݌Ƀ}�X�^�ꗗ�\����f�[�^���擾
            status = SearchStockMasterTblProc(out rsltInfo_StockMasterTblWork, paramWork, ref sqlConnection);

            objRsltInfo_StockMasterTblWork = rsltInfo_StockMasterTblWork;
            return status;

        }
        #endregion  //Search

        #region [SearchStockMasterTblProc]
        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ƀ}�X�^�ꗗ�\����f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="rsltInfo_StockMasterTblWorkList">��������</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ƀ}�X�^�ꗗ�\����f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.20</br>
        /// <br>Update Note: 2012/05/29 zhangy3 </br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2012/06/27�z�M��</br>
        /// <br>             Redmine#30029 �݌Ƀ}�X�^�ꗗ��� ����������ł̈���s�</br>
        /// <br></br>
        /// <br>Update Note: �d�a�d�΍�</br>
        /// <br>Programmer : 32653 ���J �M�m</br>
        /// <br>Date       : 2020/06/17 </br>
        private int SearchStockMasterTblProc(out ArrayList rsltInfo_StockMasterTblWorkList, ExtrInfo_StockMasterTblWork paramWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            string sqlText = string.Empty;

            // --- ADD START ���J 2020/06/17 ---------->>>>>
            // �ϊ����Ăяo��
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // �ϊ���񏉊���
            convertDoubleRelease.ReleaseInitLib();
            // --- ADD END   ���J 2020/06/17 ----------<<<<<

            try
            {
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   STOCK.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                sqlText += "  ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,STOCK.GOODSNORF" + Environment.NewLine;
                sqlText += "  ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;
                sqlText += "  ,STOCK.SUPPLIERSTOCKRF" + Environment.NewLine;
                sqlText += "  ,STOCK.ACPODRCOUNTRF" + Environment.NewLine;
                sqlText += "  ,STOCK.MONTHORDERCOUNTRF" + Environment.NewLine;
                sqlText += "  ,STOCK.SALESORDERCOUNTRF" + Environment.NewLine;
                sqlText += "  ,STOCK.STOCKDIVRF" + Environment.NewLine;
                sqlText += "  ,STOCK.MOVINGSUPLISTOCKRF" + Environment.NewLine;
                sqlText += "  ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                sqlText += "  ,STOCK.STOCKTOTALPRICERF" + Environment.NewLine;
                sqlText += "  ,STOCK.LASTSTOCKDATERF" + Environment.NewLine;
                sqlText += "  ,STOCK.LASTSALESDATERF" + Environment.NewLine;
                sqlText += "  ,STOCK.LASTINVENTORYUPDATERF" + Environment.NewLine;
                sqlText += "  ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                sqlText += "  ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                sqlText += "  ,STOCK.NMLSALODRCOUNTRF" + Environment.NewLine;
                sqlText += "  ,STOCK.SALESORDERUNITRF" + Environment.NewLine;
                sqlText += "  ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                sqlText += "  ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                sqlText += "  ,STOCK.DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                sqlText += "  ,STOCK.DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                sqlText += "  ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                sqlText += "  ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                sqlText += "  ,STOCK.STOCKNOTE1RF" + Environment.NewLine;
                sqlText += "  ,STOCK.STOCKNOTE2RF" + Environment.NewLine;
                sqlText += "  ,STOCK.SHIPMENTCNTRF" + Environment.NewLine;
                sqlText += "  ,STOCK.ARRIVALCNTRF" + Environment.NewLine;
                sqlText += "  ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                sqlText += "  ,STOCK.UPDATEDATERF" + Environment.NewLine;
                sqlText += "  ,SECINFO.SECTIONGUIDESNMRF" + Environment.NewLine;
                sqlText += "  ,WAREHOUSE.WAREHOUSENAMERF" + Environment.NewLine;
                // 2009/06/01 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //sqlText += "  ,MAKER.MAKERSHORTNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKER.MAKERNAMERF" + Environment.NewLine;
                // 2009/06/01 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                sqlText += "  ,SUPPLIER.SUPPLIERSNMRF AS STOCKSUPPLIERSNMRF" + Environment.NewLine;
                sqlText += "  ,GOODS.GOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,GOODS.BLGOODSCODERF" + Environment.NewLine;
                sqlText += "  ,BLGO.BLGOODSHALFNAMERF" + Environment.NewLine;
                sqlText += "  ,GROU.GOODSLGROUPRF" + Environment.NewLine;
                sqlText += "  ,GROU.GOODSMGROUPRF" + Environment.NewLine;
                sqlText += "  ,GROU.BLGROUPCODERF" + Environment.NewLine;
                sqlText += "  ,GROU.BLGROUPKANANAMERF" + Environment.NewLine;
                sqlText += "  ,GOODSL.GUIDENAMERF AS GOODSLGROUPNAMERF" + Environment.NewLine;
                sqlText += "  ,GOODSM.GOODSMGROUPNAMERF" + Environment.NewLine;
                sqlText += "  ,GOODSMNG.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "  ,SUPPLIER2.SUPPLIERSNMRF" + Environment.NewLine;
                sqlText += "  ,GOODSPRICE.LISTPRICERF" + Environment.NewLine;
                sqlText += "  ,GOODSPRICE.SALESUNITCOSTRF" + Environment.NewLine;
                //sqlText += " FROM STOCKRF STOCK" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                sqlText += " FROM STOCKRF STOCK WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029

                //sqlText += " LEFT JOIN SECINFOSETRF SECINFO ON STOCK.ENTERPRISECODERF=SECINFO.ENTERPRISECODERF" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                sqlText += " LEFT JOIN SECINFOSETRF SECINFO WITH (READUNCOMMITTED) ON STOCK.ENTERPRISECODERF=SECINFO.ENTERPRISECODERF" + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                sqlText += " AND STOCK.SECTIONCODERF=SECINFO.SECTIONCODERF " + Environment.NewLine;

                //sqlText += " LEFT JOIN WAREHOUSERF WAREHOUSE ON STOCK.ENTERPRISECODERF=WAREHOUSE.ENTERPRISECODERF" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                sqlText += " LEFT JOIN WAREHOUSERF WAREHOUSE WITH (READUNCOMMITTED) ON STOCK.ENTERPRISECODERF=WAREHOUSE.ENTERPRISECODERF" + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                sqlText += " AND STOCK.WAREHOUSECODERF=WAREHOUSE.WAREHOUSECODERF" + Environment.NewLine;

                //sqlText += " LEFT JOIN MAKERURF MAKER ON STOCK.ENTERPRISECODERF=MAKER.ENTERPRISECODERF" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                sqlText += " LEFT JOIN MAKERURF MAKER  WITH (READUNCOMMITTED) ON STOCK.ENTERPRISECODERF=MAKER.ENTERPRISECODERF" + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                sqlText += " AND MAKER.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += " AND STOCK.GOODSMAKERCDRF=MAKER.GOODSMAKERCDRF" + Environment.NewLine;

                //sqlText += " LEFT JOIN SUPPLIERRF SUPPLIER ON STOCK.ENTERPRISECODERF=SUPPLIER.ENTERPRISECODERF" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                sqlText += " LEFT JOIN SUPPLIERRF SUPPLIER WITH (READUNCOMMITTED) ON STOCK.ENTERPRISECODERF=SUPPLIER.ENTERPRISECODERF" + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                sqlText += " AND STOCK.STOCKSUPPLIERCODERF=SUPPLIER.SUPPLIERCDRF" + Environment.NewLine;

                //sqlText += " LEFT JOIN GOODSURF GOODS ON STOCK.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                sqlText += " LEFT JOIN GOODSURF GOODS WITH (READUNCOMMITTED) ON STOCK.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                sqlText += " AND STOCK.GOODSMAKERCDRF=GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND STOCK.GOODSNORF=GOODS.GOODSNORF" + Environment.NewLine;

                //sqlText += "LEFT JOIN BLGOODSCDURF AS BLGO" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                sqlText += "LEFT JOIN BLGOODSCDURF AS BLGO WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                sqlText += " ON" + Environment.NewLine;
                sqlText += "      BLGO.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  AND BLGO.BLGOODSCODERF=GOODS.BLGOODSCODERF" + Environment.NewLine;

                //sqlText += "LEFT JOIN BLGROUPURF AS GROU" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                sqlText += "LEFT JOIN BLGROUPURF AS GROU WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                sqlText += " ON" + Environment.NewLine;
                sqlText += "      GROU.ENTERPRISECODERF=BLGO.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  AND GROU.BLGROUPCODERF=BLGO.BLGROUPCODERF" + Environment.NewLine;

                //sqlText += "LEFT JOIN USERGDBDURF AS GOODSL" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                sqlText += "LEFT JOIN USERGDBDURF AS GOODSL WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                sqlText += " ON" + Environment.NewLine;
                sqlText += "      GOODSL.ENTERPRISECODERF=GROU.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  AND GOODSL.USERGUIDEDIVCDRF=70" + Environment.NewLine;
                sqlText += "  AND GOODSL.GUIDECODERF=GROU.GOODSLGROUPRF" + Environment.NewLine;

                //sqlText += "LEFT JOIN GOODSGROUPURF AS GOODSM" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                sqlText += "LEFT JOIN GOODSGROUPURF AS GOODSM WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                sqlText += " ON" + Environment.NewLine;
                sqlText += "      GOODSM.ENTERPRISECODERF=GROU.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  AND GOODSM.GOODSMGROUPRF=GROU.GOODSMGROUPRF" + Environment.NewLine;

                //sqlText += "LEFT JOIN GOODSMNGRF AS GOODSMNG" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                sqlText += "LEFT JOIN GOODSMNGRF AS GOODSMNG WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                sqlText += " ON" + Environment.NewLine;
                sqlText += "      GOODSMNG.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND  GOODSMNG.SECTIONCODERF=STOCK.SECTIONCODERF " + Environment.NewLine;
                sqlText += " AND  GOODSMNG.GOODSMAKERCDRF=STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND  GOODSMNG.GOODSNORF=STOCK.GOODSNORF" + Environment.NewLine;

                //sqlText += " LEFT JOIN SUPPLIERRF SUPPLIER2 ON GOODSMNG.ENTERPRISECODERF=SUPPLIER2.ENTERPRISECODERF" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                sqlText += " LEFT JOIN SUPPLIERRF SUPPLIER2 WITH (READUNCOMMITTED)  ON GOODSMNG.ENTERPRISECODERF=SUPPLIER2.ENTERPRISECODERF" + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                sqlText += " AND GOODSMNG.SUPPLIERCDRF=SUPPLIER2.SUPPLIERCDRF" + Environment.NewLine;

                //sqlText += " LEFT JOIN GOODSPRICEURF GOODSPRICE ON STOCK.ENTERPRISECODERF=GOODSPRICE.ENTERPRISECODERF" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                sqlText += " LEFT JOIN GOODSPRICEURF GOODSPRICE WITH (READUNCOMMITTED) ON STOCK.ENTERPRISECODERF=GOODSPRICE.ENTERPRISECODERF" + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                sqlText += " AND STOCK.GOODSMAKERCDRF=GOODSPRICE.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND STOCK.GOODSNORF=GOODSPRICE.GOODSNORF" + Environment.NewLine;
                sqlText += " AND GOODSPRICE.PRICESTARTDATERF=@NOWDATE" + Environment.NewLine;

                //���i�J�n��
                SqlParameter paraNowDate = sqlCommand.Parameters.Add("@NOWDATE", SqlDbType.Int);
                paraNowDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(DateTime.Now);

                sqlCommand.CommandText = sqlText;

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, paramWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    // --- UPD START ���J 2020/06/17 ---------->>>>>
                    //al.Add(CopyToStockMasterTblWorkFromReader(ref myReader, paramWork));
                    al.Add(CopyToStockMasterTblWorkFromReader(ref myReader, paramWork, convertDoubleRelease));
                    // --- UPD END   ���J 2020/06/17 ----------<<<<<

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                // --- ADD START ���J 2020/06/17 ---------->>>>>
                // ���
                convertDoubleRelease.Dispose();
                // --- ADD END   ���J 2020/06/17 ----------<<<<<
            }

            rsltInfo_StockMasterTblWorkList = al;

            return status;
        }
        #endregion  //SearchStockMasterTblProc

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="extrInfo_StockMasterTblWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.06.06</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, ExtrInfo_StockMasterTblWork extrInfo_StockMasterTblWork)
        {
            StringBuilder retString = new StringBuilder();
            retString.Append("WHERE ");

            retString.Append("STOCK.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_StockMasterTblWork.EnterpriseCode);

            //�_���폜�敪
            retString.Append("AND STOCK.LOGICALDELETECODERF=0 ");

            //�J�n�q�ɃR�[�h
            if (extrInfo_StockMasterTblWork.St_WarehouseCode != "")
            {
                retString.Append("AND STOCK.WAREHOUSECODERF>=@STWAREHOUSECODE ");
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(extrInfo_StockMasterTblWork.St_WarehouseCode);
            }

            //�I���q�ɃR�[�h
            if (extrInfo_StockMasterTblWork.Ed_WarehouseCode != "")
            {
                retString.Append("AND STOCK.WAREHOUSECODERF<=@EDWAREHOUSECODE ");
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(extrInfo_StockMasterTblWork.Ed_WarehouseCode);
            }

            //�J�n�q�ɒI��
            if (extrInfo_StockMasterTblWork.St_WarehouseShelfNo != "")
            {
                retString.Append("AND STOCK.WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNO ");
                SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNO", SqlDbType.NVarChar);
                paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(extrInfo_StockMasterTblWork.St_WarehouseShelfNo);
            }

            //�I���q�ɒI��
            if (extrInfo_StockMasterTblWork.Ed_WarehouseShelfNo != "")
            {
                retString.Append("AND STOCK.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO  ");
                SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(extrInfo_StockMasterTblWork.Ed_WarehouseShelfNo);
            }

            //�J�n�d����R�[�h
            if (extrInfo_StockMasterTblWork.St_SupplierCd != 0)
            {
                retString.Append("AND STOCK.STOCKSUPPLIERCODERF>=@STSUPPLIERCD ");
                SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@STSUPPLIERCD", SqlDbType.Int);
                paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(extrInfo_StockMasterTblWork.St_SupplierCd);
            }

            //�I���d����R�[�h
            if (extrInfo_StockMasterTblWork.Ed_SupplierCd != 0)
            {
                retString.Append("AND STOCK.STOCKSUPPLIERCODERF<=@EDSUPPLIERCD ");
                SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@EDSUPPLIERCD", SqlDbType.Int);
                paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(extrInfo_StockMasterTblWork.Ed_SupplierCd);
            }

            //�J�n���[�J�[�R�[�h
            if (extrInfo_StockMasterTblWork.St_GoodsMakerCd != 0)
            {
                retString.Append("AND STOCK.GOODSMAKERCDRF>=@STGOODSMAKERCD ");
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(extrInfo_StockMasterTblWork.St_GoodsMakerCd);
            }

            //�I�����[�J�[�R�[�h
            if (extrInfo_StockMasterTblWork.Ed_GoodsMakerCd != 0)
            {
                retString.Append("AND STOCK.GOODSMAKERCDRF<=@EDGOODSMAKERCD ");
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(extrInfo_StockMasterTblWork.Ed_GoodsMakerCd);
            }

            //�J�nBL���i�R�[�h
            if (extrInfo_StockMasterTblWork.St_BLGoodsCode != 0)
            {
                retString.Append("AND GOODS.BLGOODSCODERF>=@STBLGOODSCODE ");
                SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@STBLGOODSCODE", SqlDbType.Int);
                paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_StockMasterTblWork.St_BLGoodsCode);
            }
        
            //�I��BL���i�R�[�h
            if (extrInfo_StockMasterTblWork.Ed_BLGoodsCode != 0)
            {
                if (extrInfo_StockMasterTblWork.St_BLGoodsCode != 0)
                {
                    retString.Append("AND GOODS.BLGOODSCODERF<=@EDBLGOODSCODE ");
                }
                else
                {
                    retString.Append("AND (GOODS.BLGOODSCODERF IS NULL OR GOODS.BLGOODSCODERF<=@EDBLGOODSCODE) ");
                }

                SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@EDBLGOODSCODE", SqlDbType.Int);
                paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_StockMasterTblWork.Ed_BLGoodsCode);
            }

            //�J�n���i�ԍ�
            if (extrInfo_StockMasterTblWork.St_GoodsNo != "")
            {
                retString.Append("AND STOCK.GOODSNORF>=@STGOODSNO ");
                SqlParameter paraStGoodsCd = sqlCommand.Parameters.Add("@STGOODSNO", SqlDbType.NVarChar);
                paraStGoodsCd.Value = SqlDataMediator.SqlSetString(extrInfo_StockMasterTblWork.St_GoodsNo);
            }
        
            //�I�����i�ԍ�
            if (extrInfo_StockMasterTblWork.Ed_GoodsNo != "")
            {
                retString.Append("AND STOCK.GOODSNORF<=@EDGOODSNO ");
                SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@EDGOODSNO", SqlDbType.NVarChar);
                paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(extrInfo_StockMasterTblWork.Ed_GoodsNo);
            }

            //�O���[�v�R�[�h�ݒ�
            if (extrInfo_StockMasterTblWork.St_BLGroupCode != 0)
            {
                retString.Append(" AND BLGO.BLGROUPCODERF>=@STBLGROUPCODE " + Environment.NewLine);
                SqlParameter paraStBLGroupCode = sqlCommand.Parameters.Add("@STBLGROUPCODE", SqlDbType.Int);
                paraStBLGroupCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_StockMasterTblWork.St_BLGroupCode);
            }
            if (extrInfo_StockMasterTblWork.Ed_BLGroupCode != 0)
            {
                if (extrInfo_StockMasterTblWork.St_BLGroupCode != 0)
                {
                    retString.Append(" AND BLGO.BLGROUPCODERF<=@EDBLGROUPCODE" + Environment.NewLine);
                }
                else
                {
                    retString.Append(" AND (BLGO.BLGROUPCODERF IS NULL OR BLGO.BLGROUPCODERF<=@EDBLGROUPCODE)" + Environment.NewLine);
                }

                SqlParameter paraEdBLGroupCode = sqlCommand.Parameters.Add("@EDBLGROUPCODE", SqlDbType.Int);
                paraEdBLGroupCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_StockMasterTblWork.Ed_BLGroupCode);
            }

            //���i�啪��
            if (extrInfo_StockMasterTblWork.St_GoodsLGroup != 0)
            {
                retString.Append(" AND GROU.GOODSLGROUPRF>=@STGOODSLGROUP" + Environment.NewLine);
                SqlParameter paraStGoodsLGroup = sqlCommand.Parameters.Add("@STGOODSLGROUP", SqlDbType.Int);
                paraStGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(extrInfo_StockMasterTblWork.St_GoodsLGroup);
            }
            if (extrInfo_StockMasterTblWork.Ed_GoodsLGroup != 0)
            {
                if (extrInfo_StockMasterTblWork.St_GoodsLGroup != 0)
                {
                    retString.Append(" AND GROU.GOODSLGROUPRF<=@EDGOODSLGROUP" + Environment.NewLine);
                }
                else
                {
                    retString.Append(" AND (GROU.GOODSLGROUPRF IS NULL OR GROU.GOODSLGROUPRF<=@EDGOODSLGROUP)" + Environment.NewLine);
                }


                SqlParameter paraEdGoodsLGroup = sqlCommand.Parameters.Add("@EDGOODSLGROUP", SqlDbType.Int);
                paraEdGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(extrInfo_StockMasterTblWork.Ed_GoodsLGroup);
            }

            //���i������
            if (extrInfo_StockMasterTblWork.St_GoodsMGroup != 0)
            {
                retString.Append(" AND GROU.GOODSMGROUPRF>=@STGOODSMGROUP" + Environment.NewLine);
                SqlParameter paraStGoodsMGroup = sqlCommand.Parameters.Add("@STGOODSMGROUP", SqlDbType.Int);
                paraStGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(extrInfo_StockMasterTblWork.St_GoodsMGroup);
            }
            if (extrInfo_StockMasterTblWork.Ed_GoodsMGroup != 0)
            {
                if (extrInfo_StockMasterTblWork.St_GoodsMGroup != 0)
                {
                    retString.Append(" AND GROU.GOODSMGROUPRF<=@EDGOODSMGROUP" + Environment.NewLine);
                }
                else
                {
                    retString.Append(" AND (GROU.GOODSMGROUPRF IS NULL OR GROU.GOODSMGROUPRF<=@EDGOODSMGROUP)" + Environment.NewLine);
                }

                SqlParameter paraEdGoodsMGroup = sqlCommand.Parameters.Add("@EDGOODSMGROUP", SqlDbType.Int);
                paraEdGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(extrInfo_StockMasterTblWork.Ed_GoodsMGroup);
            }


            return retString.ToString();
        }
        # endregion

        /// <summary>
        /// �N���X�i�[���� Reader �� UOEGuideNameWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <returns>UOEGuideNameWork �I�u�W�F�N�g</returns>
        /// <param name="convertDoubleRelease">���l�ϊ�����</param>
        /// <remarks>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.06.06</br>
        /// <br></br>
        /// <br>Update Note: �d�a�d�΍�</br>
        /// <br>Programmer : 32653 ���J �M�m</br>
        /// <br>Date       : 2020/06/17</br>
        /// </remarks>
        // --- UPD START ���J 2020/06/17 ---------->>>>>
        //private RsltInfo_StockMasterTblWork CopyToStockMasterTblWorkFromReader(ref SqlDataReader myReader, ExtrInfo_StockMasterTblWork paramWork)
        private RsltInfo_StockMasterTblWork CopyToStockMasterTblWorkFromReader(ref SqlDataReader myReader, ExtrInfo_StockMasterTblWork paramWork, ConvertDoubleRelease convertDoubleRelease)
        // --- UPD END   ���J 2020/06/17 ----------<<<<<
        {
            RsltInfo_StockMasterTblWork rsltInfo_StockMasterTblWork = new RsltInfo_StockMasterTblWork();

            if (myReader != null)
            {
                # region �N���X�֊i�[
                rsltInfo_StockMasterTblWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                rsltInfo_StockMasterTblWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                rsltInfo_StockMasterTblWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                rsltInfo_StockMasterTblWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                rsltInfo_StockMasterTblWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                rsltInfo_StockMasterTblWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
                rsltInfo_StockMasterTblWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF"));
                rsltInfo_StockMasterTblWork.MonthOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHORDERCOUNTRF"));
                rsltInfo_StockMasterTblWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
                rsltInfo_StockMasterTblWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
                rsltInfo_StockMasterTblWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF"));
                rsltInfo_StockMasterTblWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                rsltInfo_StockMasterTblWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
                rsltInfo_StockMasterTblWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
                rsltInfo_StockMasterTblWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSALESDATERF"));
                rsltInfo_StockMasterTblWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
                rsltInfo_StockMasterTblWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
                rsltInfo_StockMasterTblWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                rsltInfo_StockMasterTblWork.NmlSalOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NMLSALODRCOUNTRF"));
                rsltInfo_StockMasterTblWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
                rsltInfo_StockMasterTblWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSUPPLIERCODERF"));
                rsltInfo_StockMasterTblWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                rsltInfo_StockMasterTblWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
                rsltInfo_StockMasterTblWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
                rsltInfo_StockMasterTblWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
                rsltInfo_StockMasterTblWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
                rsltInfo_StockMasterTblWork.StockNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE1RF"));
                rsltInfo_StockMasterTblWork.StockNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE2RF"));
                rsltInfo_StockMasterTblWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                rsltInfo_StockMasterTblWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
                rsltInfo_StockMasterTblWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
                rsltInfo_StockMasterTblWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
                rsltInfo_StockMasterTblWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                rsltInfo_StockMasterTblWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                rsltInfo_StockMasterTblWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                rsltInfo_StockMasterTblWork.StockSupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSUPPLIERSNMRF"));
                rsltInfo_StockMasterTblWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                rsltInfo_StockMasterTblWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                rsltInfo_StockMasterTblWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
                rsltInfo_StockMasterTblWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
                rsltInfo_StockMasterTblWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                rsltInfo_StockMasterTblWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                rsltInfo_StockMasterTblWork.BLGroupKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPKANANAMERF"));
                rsltInfo_StockMasterTblWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAMERF"));
                rsltInfo_StockMasterTblWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
                rsltInfo_StockMasterTblWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                rsltInfo_StockMasterTblWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));

                // --- UPD START ���J 2020/06/17 ---------->>>>>
                //rsltInfo_StockMasterTblWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
                convertDoubleRelease.EnterpriseCode = paramWork.EnterpriseCode;
                convertDoubleRelease.GoodsMakerCd = rsltInfo_StockMasterTblWork.GoodsMakerCd;
                convertDoubleRelease.GoodsNo = rsltInfo_StockMasterTblWork.GoodsNo;
                convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));

                // �ϊ��������s
                convertDoubleRelease.ReleaseProc();

                rsltInfo_StockMasterTblWork.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                // --- UPD END   ���J 2020/06/17 ----------<<<<<

                rsltInfo_StockMasterTblWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                # endregion
            }

            return rsltInfo_StockMasterTblWork;
        }

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.20</br>
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
        #endregion  //�R�l�N�V������������
    }

}
