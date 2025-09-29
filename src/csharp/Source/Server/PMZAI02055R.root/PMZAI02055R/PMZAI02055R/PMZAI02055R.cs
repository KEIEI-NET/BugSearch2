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
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �݌ɊŔ��DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌ɊŔ�����f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer :
    /// 30350 �N�� ����</br>
    /// <br>Date       : 2008.10.10</br>
    /// <br></br>
    /// <br>Update Note:</br>
    /// </remarks>
    [Serializable]
    public class StockSignOrderWorkDB : RemoteDB, IStockSignOrderWorkDB
    {
        /// <summary>
        /// �݌ɊŔ��DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.10.10</br>
        /// </remarks>
        public StockSignOrderWorkDB()
            :
        base("PMZAI02057D", "Broadleaf.Application.Remoting.ParamData.StockSignResultWork", "StockRF") //���N���X�̃R���X�g���N�^
        {
        }

        GoodsPriceUDB goodsPriceUDB = new GoodsPriceUDB();
        
        #region �݌ɊŔ��
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̍݌ɊŔ����LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="stockSignResultWork">��������</param>
        /// <param name="stockSignOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔��s�m�F�ꗗ�\LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.10.10</br>
        public int Search(out object stockSignResultWork, object stockSignOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            stockSignResultWork = null;

            StockSignOrderCndtnWork _stockSignOrderCndtnWork = stockSignOrderCndtnWork as StockSignOrderCndtnWork;

            try
            {
                status = SearchProc(out stockSignResultWork, _stockSignOrderCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockSignOrderWork.Search Exception=" + ex.Message);
                stockSignResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̍݌ɊŔ����LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="stockSignResultWork">��������</param>
        /// <param name="_stockSignOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̍݌ɊŔ����LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.10.10</br>
        /// <br></br>
        /// <br>Update Note: 2007.10.15 ���� DC.NS�p�ɏC��</br>
        private int SearchProc(out object stockSignResultWork, StockSignOrderCndtnWork _stockSignOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            stockSignResultWork = null;

            ArrayList al = new ArrayList();   //���o����

            try
            {
                // ���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                // SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = SearchOrderProc(ref al, ref sqlConnection, _stockSignOrderCndtnWork,readMode, logicalMode);
            }
            catch (SqlException ex)
            {
                // ���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockSignOrderWorkDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            stockSignResultWork = al;

            return status;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_stockSignOrderCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, StockSignOrderCndtnWork _stockSignOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region Select���쐬
                selectTxt += "SELECT " + Environment.NewLine;
                selectTxt += "	 STO.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	      ,STO.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "        ,STO.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "        ,STO.GOODSNORF" + Environment.NewLine;
                selectTxt += "        ,STO.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "        ,GOD.GOODSNAMEKANARF" + Environment.NewLine;
                selectTxt += "        ,STO.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "        ,STO.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "        ,STO.STOCKCREATEDATERF" + Environment.NewLine;
                selectTxt += "        ,STO.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "        ,STO.SUPPLIERSTOCKRF" + Environment.NewLine;
                selectTxt += " FROM STOCKRF AS STO" + Environment.NewLine;
                selectTxt += "LEFT JOIN  GOODSURF AS GOD" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "	    GOD.ENTERPRISECODERF=STO.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND GOD.GOODSNORF=STO.GOODSNORF" + Environment.NewLine;
                selectTxt += "  AND	GOD.GOODSMAKERCDRF=STO.GOODSMAKERCDRF" + Environment.NewLine;

                // WHERE���̍쐬
                selectTxt += MakeWhereString(ref sqlCommand, _stockSignOrderCndtnWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                #endregion

               myReader = sqlCommand.ExecuteReader(); 
                
                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    StockSignResultWork wkstockSignResultWork = new StockSignResultWork();
                    // �i�[����
                 
                    wkstockSignResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkstockSignResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wkstockSignResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    wkstockSignResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkstockSignResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkstockSignResultWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                    wkstockSignResultWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
                    wkstockSignResultWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                    wkstockSignResultWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
                    wkstockSignResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkstockSignResultWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
                    #endregion

                    GoodsPriceUWork paraGoodsPriceUWork = new GoodsPriceUWork();
                    
                    object goodsPriceUWork;
                    paraGoodsPriceUWork.EnterpriseCode = wkstockSignResultWork.EnterpriseCode;
                    paraGoodsPriceUWork.GoodsNo = wkstockSignResultWork.GoodsNo;
                    paraGoodsPriceUWork.GoodsMakerCd = wkstockSignResultWork.GoodsMakerCd;

                    //if (!myReader.IsClosed) myReader.Close();
                    status = goodsPriceUDB.Search(out goodsPriceUWork, paraGoodsPriceUWork, readMode, logicalMode);

                    ArrayList goodsPriceUWorkList = goodsPriceUWork as ArrayList;
                    DateTime today = DateTime.Now;
                    for (int i = 0; i < goodsPriceUWorkList.Count; i++)
                    {
                        GoodsPriceUWork work = goodsPriceUWorkList[i] as GoodsPriceUWork;

                        if (work.PriceStartDate < today)
                        {
                            wkstockSignResultWork.ListPrice = work.ListPrice;
                        }
                        else
                        {
                            break;
                        }
                    }

                    al.Add(wkstockSignResultWork);
                    
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                // ���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "publicationConfResultWorkDB.SearchOrderProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_stockSignOrderCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockSignOrderCndtnWork _stockSignOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = "WHERE" + Environment.NewLine;

            // ��ƃR�[�h
            retstring += " STO.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_stockSignOrderCndtnWork.EnterpriseCode);

            // �_���폜�敪
            retstring += " AND STO.LOGICALDELETECODERF = 0" + Environment.NewLine;

            // ���_�R�[�h
            if (_stockSignOrderCndtnWork.SectionCodes != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _stockSignOrderCndtnWork.SectionCodes)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }
                if (sectionCodestr != "")
                {
                    retstring += " AND STO.SECTIONCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            // �q�ɃR�[�h
            if (_stockSignOrderCndtnWork.St_WarehouseCode != "")
            {
                retstring += " AND STO.WAREHOUSECODERF>=@STWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockSignOrderCndtnWork.St_WarehouseCode);
            }
            if (_stockSignOrderCndtnWork.Ed_WarehouseCode != "")
            {
                retstring += " AND STO.WAREHOUSECODERF<=@EDWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockSignOrderCndtnWork.Ed_WarehouseCode);
            }

            // ���[�J�[�R�[�h
            if (_stockSignOrderCndtnWork.St_GoodsMakerCd != 0)
            {
                retstring += " AND STO.GOODSMAKERCDRF>=@STGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockSignOrderCndtnWork.St_GoodsMakerCd);
            }
            if (_stockSignOrderCndtnWork.Ed_GoodsMakerCd != 9999)
            {
                retstring += " AND STO.GOODSMAKERCDRF<=@EDGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockSignOrderCndtnWork.Ed_GoodsMakerCd);
            }

            // �q�ɒI��
            if (_stockSignOrderCndtnWork.St_WarehouseShelfNo != "")
            {
                retstring += " AND STO.WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNO" + Environment.NewLine;
                SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNO", SqlDbType.NVarChar);
                paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_stockSignOrderCndtnWork.St_WarehouseShelfNo);
            }
            if (_stockSignOrderCndtnWork.Ed_WarehouseShelfNo != "")
            {
                if (_stockSignOrderCndtnWork.St_WarehouseShelfNo != "")
                {
                    retstring += " AND STO.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO" + Environment.NewLine;
                }
                else
                {
                    retstring += " AND (STO.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO OR STO.WAREHOUSESHELFNORF IS NULL)" + Environment.NewLine;
                }
                SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NChar);
                paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_stockSignOrderCndtnWork.Ed_WarehouseShelfNo);
            }

            // �i��
            if (_stockSignOrderCndtnWork.St_GoodsNo != "")
            {
                retstring += " AND STO.GOODSNORF>=@STGOODSNO" + Environment.NewLine;
                SqlParameter paraStGoodsNo = sqlCommand.Parameters.Add("@STGOODSNO", SqlDbType.NVarChar);
                paraStGoodsNo.Value = SqlDataMediator.SqlSetString(_stockSignOrderCndtnWork.St_GoodsNo);
            }
            if (_stockSignOrderCndtnWork.Ed_GoodsNo != "")
            {
                retstring += " AND STO.GOODSNORF<=@EDGOODSNO" + Environment.NewLine;
                SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@EDGOODSNO", SqlDbType.NVarChar);
                paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockSignOrderCndtnWork.Ed_GoodsNo);
            }

            // �����
            if (_stockSignOrderCndtnWork.PrintType == 1)
            {
                retstring += " AND STO.SUPPLIERSTOCKRF > 0" + Environment.NewLine;
            }
            #endregion
            return retstring;
        }
    }
}

