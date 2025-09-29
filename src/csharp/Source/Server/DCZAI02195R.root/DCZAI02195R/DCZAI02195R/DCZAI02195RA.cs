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
using Broadleaf.Application.Common;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �݌ɉߏ�ꗗ�\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌ɉߏ�ꗗ�\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2007.11.07</br>
	/// <br></br>
	/// <br>Update Note: 2008.03.26 ���X�� ��</br>
	/// <br>           : ���i�R�[�h�̍i�荞�݂��C��</br>
    /// <br>Update Note: 2008.07.14 �X�{ ��P</br>
    /// <br>           : PM.NS�Ή�</br>
    /// <br>Update Note: 2009.04.23 ���� ���n</br>
    /// <br>           : MANTIS�Ή�</br>
    /// <br>Update Note: 2009.05.28 ���� ���n</br>
    /// <br>           : MANTIS�Ή� 12777</br>
    /// <br>Update Note: 2011/03/16 ���� ���n</br>
    /// <br>           : ���x�`���[�j���O ���A���W�v���̎g�p���\�b�h��ύX</br>
    /// <br>Update Note: 2012/12/19 gezh</br>
    /// <br>           : 2013/01/16�z�M���@Redmine#33976 �d����ʉߏ�݌Ɉꗗ�\�̏C��</br>
    /// </remarks>
    [Serializable]
    public class StockOverListWorkDB : RemoteDB, IStockOverListWorkDB
    {
        /// <summary>
        /// �݌ɉߏ�ꗗ�\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.07</br>
        /// </remarks>
        public StockOverListWorkDB()
            :
        base("DCZAI02193D", "Broadleaf.Application.Remoting.ParamData.StockOverListResultWork", "STOCKRF") //���N���X�̃R���X�g���N�^
        {
        }

        #region Search
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̍݌ɉߏ�ꗗ�\LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="stockOverListResultWork">��������</param>
        /// <param name="stockOverListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̍݌ɉߏ�ꗗ�\LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.07</br>
        public int Search(out object stockOverListResultWork, object stockOverListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            stockOverListResultWork = null;

            StockOverListCndtnWork _stockOverListCndtnWork = stockOverListCndtnWork as StockOverListCndtnWork;

            try
            {
                status = SearchProc(out stockOverListResultWork, _stockOverListCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockOverListWorkDB.Search Exception=" + ex.Message);
                stockOverListResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̍݌ɉߏ�ꗗ�\LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="stockOverListResultWork">��������</param>
        /// <param name="_stockOverListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̍݌ɉߏ�ꗗ�\LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.07</br>
        /// <br>Update Note: 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.14</br>
        private int SearchProc(out object stockOverListResultWork, StockOverListCndtnWork _stockOverListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            stockOverListResultWork = null;
            ArrayList al = new ArrayList();   //���o����

            //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return status;

            //SQL������
            sqlConnection = new SqlConnection(connectionText);
            sqlConnection.Open();

            ArrayList stockOverList = new ArrayList();
            ArrayList retstockOverList = new ArrayList();
            Dictionary<string, StockHistoryWork> stockHisDic = new Dictionary<string, StockHistoryWork>();


            try
            {
                //�݌Ƀ}�X�^�擾&�����ςݍ݌ɗ����̎擾
                status = SearchStockProc(ref stockOverList, _stockOverListCndtnWork, readMode, logicalMode, ref sqlConnection);

                //�݌Ƀ}�X�^�����񂪎擾�o���Ȃ��ꍇ��
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;

                //���o�׎w��L��̏ꍇ�̂݁A�������������̃��A���W�v���o�׉񐔂��擾����
                if (_stockOverListCndtnWork.NoShipmentDiv != 0)
                {
                    //���A���W�v�Ώۍ݌ɗ������擾
                    status = SearchStockHistory(ref stockHisDic, _stockOverListCndtnWork, ref sqlConnection);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;

                    //�݌ɗ����̃��A���W�v���ʂ����ʃ��X�g�Ɋi�[
                    CopyToStockOverListResultWorkFromStockHistoryWork(ref stockOverList, stockHisDic);
                }

                //�ߏ�݌ɁA���o�׎w��̏ꍇ�̔���
                foreach (StockOverListResultWork retWork in stockOverList)
                {
                    //�ߏ�݌ɂ��A���邢�͎w�茎�����o�ׂ̏ꍇ�ɒ��o�ΏۂƂ���
                    if ( (retWork.MaximumStockCnt < retWork.ShipmentPosCnt) ||
                         ((_stockOverListCndtnWork.NoShipmentDiv != 0) && (retWork.SalesTimes <= 0))
                        )
                    {
                        retstockOverList.Add(retWork);
                    }
                }
                
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockOverListWorkDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlConnection = null;
                }
            }

            stockOverListResultWork = retstockOverList;

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̍݌ɉߏ�ꗗ�\LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retStockOverList">��������</param>
        /// <param name="_stockOverListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̍݌ɉߏ�ꗗ�\LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2009.04.23</br>
        private int SearchStockProc(ref ArrayList retStockOverList, StockOverListCndtnWork _stockOverListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {

                string selectTxt = "";
                sqlCommand = new SqlCommand("", sqlConnection);

                #region Select���쐬
                //���ʎ擾
                //�݌Ƀ}�X�^�擾����
                selectTxt += "SELECT" + Environment.NewLine;
                //selectTxt += "�@STOCK.SECTIONCODERF" + Environment.NewLine;
                //selectTxt += " ,SECI.SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "  STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += " ,WAH.WAREHOUSENAMERF" + Environment.NewLine;
                //selectTxt += " ,GDSM.SUPPLIERCDRF" + Environment.NewLine;
                //selectTxt += " ,SUP.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += " ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                selectTxt += " ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                selectTxt += " ,GDSU.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += " ,STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += " ,GDSU.GOODSNAMERF" + Environment.NewLine;
                selectTxt += " ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += " ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += " ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += " ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += " ,STOCK.SALESORDERCOUNTRF" + Environment.NewLine;
                selectTxt += " ,STOCK.SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += " ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += " ,STOCK.LASTSTOCKDATERF" + Environment.NewLine;

                if (_stockOverListCndtnWork.NoShipmentDiv != 0)
                {
                    selectTxt += " ,HISSUB.SALESTIMES" + Environment.NewLine;
                }
                
                // -- UPD 2011/03/16 --------------------->>>
                //selectTxt += " FROM STOCKRF AS STOCK" + Environment.NewLine;
                selectTxt += " FROM STOCKRF AS STOCK WITH (READUNCOMMITTED)" + Environment.NewLine;
                // -- UPD 2011/03/16 ---------------------<<<
                ////���_���ݒ�}�X�^
                //selectTxt += " LEFT JOIN SECINFOSETRF SECI" + Environment.NewLine;
                //selectTxt += " ON  SECI.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += " AND SECI.SECTIONCODERF = STOCK.SECTIONCODERF" + Environment.NewLine;
                ////���i�Ǘ����}�X�^
                //selectTxt += " LEFT JOIN GOODSMNGRF GDSM" + Environment.NewLine;
                //selectTxt += " ON  GDSM.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += " AND GDSM.SECTIONCODERF = STOCK.SECTIONCODERF" + Environment.NewLine;
                //selectTxt += " AND GDSM.GOODSMAKERCDRF = STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                //selectTxt += " AND GDSM.GOODSNORF = STOCK.GOODSNORF" + Environment.NewLine;
                //�q�Ƀ}�X�^
                // -- UPD 2011/03/16 -------------------------->>>
                //selectTxt += " LEFT JOIN WAREHOUSERF WAH" + Environment.NewLine;
                selectTxt += " LEFT JOIN WAREHOUSERF WAH WITH (READUNCOMMITTED)" + Environment.NewLine;
                // -- UPD 2011/03/16 --------------------------<<<
                selectTxt += " ON  WAH.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND WAH.WAREHOUSECODERF = STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += " AND WAH.LOGICALDELETECODERF = 0" + Environment.NewLine;
                ////�d����}�X�^
                //selectTxt += " LEFT JOIN SUPPLIERRF SUP" + Environment.NewLine;
                //selectTxt += " ON  SUP.ENTERPRISECODERF = GDSM.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += " AND SUP.SUPPLIERCDRF = GDSM.SUPPLIERCDRF" + Environment.NewLine;
                //���i�}�X�^
                // -- UPD 2011/03/16 -------------------------->>>
                //selectTxt += " LEFT JOIN GOODSURF GDSU" + Environment.NewLine;
                selectTxt += " LEFT JOIN GOODSURF GDSU WITH (READUNCOMMITTED)" + Environment.NewLine;
                // -- UPD 2011/03/16 --------------------------<<<
                selectTxt += " ON  GDSU.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GDSU.GOODSMAKERCDRF = STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND GDSU.GOODSNORF = STOCK.GOODSNORF" + Environment.NewLine;

                //���o�׎w�蔻�f
                if (_stockOverListCndtnWork.NoShipmentDiv != 0)
                {
                    //�݌ɗ����f�[�^
                    selectTxt += "LEFT JOIN" + Environment.NewLine;
                    selectTxt += "(" + Environment.NewLine;
                    selectTxt += "SELECT" + Environment.NewLine;
                    selectTxt += "  HIS.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += " ,HIS.WAREHOUSECODERF" + Environment.NewLine;
                    //selectTxt += " ,HIS.SECTIONCODERF" + Environment.NewLine;
                    selectTxt += " ,HIS.GOODSNORF" + Environment.NewLine;
                    selectTxt += " ,HIS.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += " ,SUM(HIS.SALESTIMESRF) AS SALESTIMES" + Environment.NewLine;
                    // -- UPD 2011/03/16 -------------------------->>>
                    //selectTxt += "FROM STOCKHISTORYRF AS HIS" + Environment.NewLine;
                    selectTxt += "FROM STOCKHISTORYRF AS HIS WITH (READUNCOMMITTED)" + Environment.NewLine;
                    // -- UPD 2011/03/16 --------------------------<<<
                    selectTxt += MakeWhereStringHIS(ref sqlCommand, _stockOverListCndtnWork, logicalMode);
                    selectTxt += "GROUP BY" + Environment.NewLine;
                    selectTxt += "  HIS.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += " ,HIS.WAREHOUSECODERF" + Environment.NewLine;
                    //selectTxt += " ,HIS.SECTIONCODERF" + Environment.NewLine;
                    selectTxt += " ,HIS.GOODSNORF" + Environment.NewLine;
                    selectTxt += " ,HIS.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += ") AS HISSUB" + Environment.NewLine;
                    selectTxt += "ON" + Environment.NewLine;
                    selectTxt += "     HISSUB.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                    //selectTxt += " AND HISSUB.SECTIONCODERF=STOCK.SECTIONCODERF" + Environment.NewLine;
                    selectTxt += " AND HISSUB.WAREHOUSECODERF=STOCK.WAREHOUSECODERF" + Environment.NewLine;
                    selectTxt += " AND HISSUB.GOODSMAKERCDRF=STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += " AND HISSUB.GOODSNORF=STOCK.GOODSNORF" + Environment.NewLine;
                }

                #endregion

                sqlCommand.CommandText = selectTxt;

                //WHERE���̍쐬
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, _stockOverListCndtnWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    StockOverListResultWork wkStockOverListResultWork = new StockOverListResultWork();

                    //�i�[����
                    //wkStockOverListResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    //wkStockOverListResultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    wkStockOverListResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wkStockOverListResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    //wkStockOverListResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    //wkStockOverListResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    wkStockOverListResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkStockOverListResultWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
                    wkStockOverListResultWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
                    wkStockOverListResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    wkStockOverListResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkStockOverListResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkStockOverListResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    wkStockOverListResultWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
                    wkStockOverListResultWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                    wkStockOverListResultWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                    wkStockOverListResultWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
                    wkStockOverListResultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    wkStockOverListResultWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    wkStockOverListResultWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
                    if (_stockOverListCndtnWork.NoShipmentDiv != 0)
                    {
                        wkStockOverListResultWork.SalesTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMES"));
                    }

                    #endregion

                    retStockOverList.Add(wkStockOverListResultWork);

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
                base.WriteErrorLog(ex, "StockOverListWorkDB.SearchStockProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                    myReader = null;
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                    sqlCommand = null;
                }
            }

            return status;
        }


        /// <summary>
        /// �݌ɗ������A���W�v����
        /// </summary>
        /// <param name="retStockHisDic">��������</param>
        /// <param name="_stockOverListCndtnWork">�����p�����[�^</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̍݌ɉߏ�ꗗ�\LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2009.04.23</br>
        private int SearchStockHistory(ref Dictionary<string,StockHistoryWork> retStockHisDic, StockOverListCndtnWork _stockOverListCndtnWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            try
            {
                //�ŏI�������N�����擾
                DateTime lastStockHisYm = GetLastStockHisYm(_stockOverListCndtnWork.EnterpriseCode, ref sqlConnection);

                DateTime st_Ym = DateTime.MinValue;

                if (lastStockHisYm == DateTime.MinValue)
                {
                    //��x���������������Ă��Ȃ��ꍇ
                    st_Ym = _stockOverListCndtnWork.St_AddUpYearMonth;
                }
                else
                {
                    //�����ς݂̗�����SearchStockProc���Ŏ擾���Ă��邽�߁A����ȍ~�����A���W�v�ΏۂƂ���B
                    st_Ym = lastStockHisYm.AddMonths(1);
                    
                    // 2009/05/29 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 
                    //���A���W�v�Ώی�������ʎw��J�n���̕����傫���ꍇ�́A��ʎw��J�n�������A���W�v�J�n���Ƃ���
                    if (st_Ym.Year * 100 + st_Ym.Month < _stockOverListCndtnWork.St_AddUpYearMonth.Year * 100 + _stockOverListCndtnWork.St_AddUpYearMonth.Month)
                    {
                        st_Ym = _stockOverListCndtnWork.St_AddUpYearMonth;
                    }
                    // 2009/05/29 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                }

                //���t�擾���i�p�ɓ��t���P���ύX
                st_Ym = new DateTime(st_Ym.Year, st_Ym.Month, 1);

                DateTime ed_Ym = _stockOverListCndtnWork.Ed_AddUpYearMonth;

                //�������W�v�̑Ώۊ���
                Int32 monthRange = ((ed_Ym.Year) - (st_Ym.Year)) * 12 + (ed_Ym.Month) - (st_Ym.Month) + 1;

                ArrayList companyInfList = new ArrayList();
                CompanyInfWork companyInfWork = new CompanyInfWork();

                //���Џ��ǂݍ���
                CompanyInfDB companyInfDB = new CompanyInfDB();
                companyInfWork.EnterpriseCode = _stockOverListCndtnWork.EnterpriseCode;
                status = companyInfDB.Search(out companyInfList, companyInfWork, ref sqlConnection);
                companyInfWork = companyInfList[0] as CompanyInfWork;


                MonthlyAddUpDB monthlyAddUpDB = new MonthlyAddUpDB();

                //���A���W�v�̑Ώۊ��Ԃ�����ꍇ
                if (monthRange > 0)
                {
                    for (int i = 0; i < monthRange; i++)
                    {
                        //���Џ����A�Ώ۔N���̊J�n�I�������擾
                        DateTime monthStart = DateTime.MinValue;
                        DateTime monthEnd = DateTime.MinValue;

                        FinYearTableGenerator finYearTableGenerator = new FinYearTableGenerator(companyInfWork);
                        finYearTableGenerator.GetDaysFromMonth(st_Ym, out monthStart, out monthEnd);

                        //���A���W�v���\�b�h�Ăяo��
                        MonthlyAddUpWork monthlyAddUpWork = new MonthlyAddUpWork(); //�����W�v���\�b�h�p�p�����[�^
                        monthlyAddUpWork.EnterpriseCode = _stockOverListCndtnWork.EnterpriseCode;
                        // 2009/05/28 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        //monthlyAddUpWork.AddUpDateSt = monthStart;    //�����J�n���t���Z�b�g
                        monthlyAddUpWork.AddUpDateSt = monthStart.AddDays(-1);    //�����J�n���t���Z�b�g
                        // 2009/05/28 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        monthlyAddUpWork.AddUpDateEd = monthEnd;
                        monthlyAddUpWork.AddUpDate = monthEnd;        //�����I�����t���Z�b�g
                        monthlyAddUpWork.LstMonAddUpProcDay = st_Ym.AddMonths(-1);  //�O�񗚗��擾�p�ɑO�����Z�b�g
                        monthlyAddUpWork.AddUpYearMonth = st_Ym;

                        List<StockHistoryWork> stockHistoryWorkList = new List<StockHistoryWork>();
                        // -- UPD 2011/03/16 ---------------------------------->>>
                        //string retMsg = null;
                        //bool msgDiv = true;

                        //status = monthlyAddUpDB.MakeStockHistoryParameters(ref monthlyAddUpWork, ref stockHistoryWorkList, out msgDiv, out retMsg, ref sqlConnection);
                        status = GetSalesTimesProc(ref stockHistoryWorkList, monthlyAddUpWork, _stockOverListCndtnWork, ref sqlConnection);
                        // -- UPD 2011/03/16 ----------------------------------<<<
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //���ʂ��i�[
                            foreach (StockHistoryWork sthisWork in stockHistoryWorkList)
                            {
                                string keyString = sthisWork.WarehouseCode.Trim() + sthisWork.GoodsNo + sthisWork.GoodsMakerCd.ToString("0000");

                                if (retStockHisDic.ContainsKey(keyString))
                                {
                                    //���ɑ��݂����ꍇ�͉��Z
                                    (retStockHisDic[keyString] as StockHistoryWork).SalesTimes += sthisWork.SalesTimes;
                                }
                                else
                                {
                                    //���݂��Ȃ������ꍇ�͒ǉ�
                                    retStockHisDic.Add(keyString,sthisWork);
                                }
                            }

                        }
                        else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                         (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                        {
                            //NOT_FOUND,EOF�̏ꍇ�͎���
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        else
                        {
                            //�擾���s
                            // -- UPD 2011/03/16 ----------------->>>
                            ////throw new Exception("�݌ɗ����W�v���W���[������̎擾�Ɏ��s�B");
                            return status;
                            // -- UPD 2011/03/16 -----------------<<<
                        }

                        st_Ym = st_Ym.AddMonths(1);

                    }
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockOverListWorkDB.SearchStockHistory Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        #endregion


        /// <summary>
        /// ���ʃ��X�g��������
        /// </summary>
        /// <param name="retStockOverList">�݌Ƀ��X�g</param>
        /// <param name="stockHisDic">���A���W�v���݌ɗ������X�g</param>
        /// <returns>RsltInfo_PrevYearComparisonWork</returns>
        /// <remarks>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2009.04.23</br>
        /// <br></br>
        /// </remarks>
        private void CopyToStockOverListResultWorkFromStockHistoryWork(ref ArrayList retStockOverList, Dictionary<string,StockHistoryWork> stockHisDic)
        {
            foreach (StockOverListResultWork retWork in retStockOverList)
            {
                string keyString = retWork.WarehouseCode.Trim() + retWork.GoodsNo + retWork.GoodsMakerCd.ToString("0000");

                if (stockHisDic.ContainsKey(keyString))
                {
                    //���A���W�v���ʂɊY�������ꍇ�́A����񐔂����Z
                    retWork.SalesTimes += (stockHisDic[keyString] as StockHistoryWork).SalesTimes;
                }
            }

        }

        /// <summary>
        /// �ŏI�̍݌ɗ������R�[�h�N����߂��܂�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ŏI�̍݌ɗ������R�[�h�N����߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2009.04.23</br>
        /// <br></br>
        private DateTime GetLastStockHisYm(string enterpriseCode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            DateTime retYm = DateTime.MinValue;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {

                string selectTxt = "";

                selectTxt += "SELECT " + Environment.NewLine;
                selectTxt += "  MAX(STOCKHIS.ADDUPYEARMONTHRF) AS ADDUPYEARMONTHRF" + Environment.NewLine;
                // -- UPD 2011/03/16 --------------------------->>>
                //selectTxt += " FROM STOCKHISTORYRF AS STOCKHIS" + Environment.NewLine;
                selectTxt += " FROM STOCKHISTORYRF AS STOCKHIS WITH (READUNCOMMITTED)" + Environment.NewLine;
                // -- UPD 2011/03/16 ---------------------------<<<
                selectTxt += "WHERE" + Environment.NewLine;
                selectTxt += " STOCKHIS.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    //�ŏI�v��N�����擾
                    retYm = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
                }

                //�擾�o���Ȃ��ꍇ������Ƃ���
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockListWorkDB.GetLastStockHisYm Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();

                myReader = null;
            }
            return retYm;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_stockOverListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Update Note: 2012/12/19 gezh</br>
        /// <br>           : 2013/01/16�z�M���@Redmine#33976 �d����ʉߏ�݌Ɉꗗ�\�̏C��</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockOverListCndtnWork _stockOverListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = " WHERE ";

            //��ƃR�[�h
            retstring += " STOCK.ENTERPRISECODERF=@ENTERPRISECODE";
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.EnterpriseCode);

            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND STOCK.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND STOCK.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            ////���_�R�[�h    ���z��ŕ����w�肳���
            //if (_stockOverListCndtnWork.SectionCodes != null)
            //{
            //    string sectionCodestr = "";
            //    foreach (string seccdstr in _stockOverListCndtnWork.SectionCodes)
            //    {
            //        if (sectionCodestr != "")
            //        {
            //            sectionCodestr += ",";
            //        }
            //        sectionCodestr += "'" + seccdstr + "'";
            //    }

            //    if (sectionCodestr != "")
            //    {
            //        retstring += " AND STOCK.SECTIONCODERF IN (" + sectionCodestr + ") ";
            //    }
            //}

            //�݌ɓo�^���ݒ�
            if (_stockOverListCndtnWork.StockCreateDate != DateTime.MinValue)
            {
                int startymdStockCreateDate = TDateTime.DateTimeToLongDate(_stockOverListCndtnWork.StockCreateDate);
                if (_stockOverListCndtnWork.StockCreateDateDiv == 0)
                {
                    //retstring += " AND STOCK.STOCKCREATEDATERF <= " + startymdStockCreateDate.ToString();  // DEL gezh 2012/12/19 for Redmine#33976
                    retstring += " AND ISNULL(STOCK.STOCKCREATEDATERF,0) <= " + startymdStockCreateDate.ToString();  // ADD gezh 2012/12/19 for Redmine#33976
                }
                else
                {
                    retstring += " AND STOCK.STOCKCREATEDATERF >= " + startymdStockCreateDate.ToString();
                }
            }

            //�q�ɃR�[�h�ݒ�
            if (_stockOverListCndtnWork.St_WarehouseCode != "")
            {
                retstring += " AND STOCK.WAREHOUSECODERF>=@STWAREHOUSECODE";
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.St_WarehouseCode);
            }
            if (_stockOverListCndtnWork.Ed_WarehouseCode != "")
            {
                retstring += " AND STOCK.WAREHOUSECODERF<=@EDWAREHOUSECODE";
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.Ed_WarehouseCode);
            }

            ////�d����R�[�h�ݒ�
            //if (_stockOverListCndtnWork.St_SupplierCd != 0)
            //{
            //    retstring += " AND SUP.SUPPLIERCDRF>=@STSTOCKSUPPLIERCODE";
            //    SqlParameter paraStStockSupplierCode = sqlCommand.Parameters.Add("@STSTOCKSUPPLIERCODE", SqlDbType.Int);
            //    paraStStockSupplierCode.Value = SqlDataMediator.SqlSetInt32(_stockOverListCndtnWork.St_SupplierCd);
            //}
            //if (_stockOverListCndtnWork.Ed_SupplierCd != 999999)
            //{
            //    retstring += " AND SUP.SUPPLIERCDRF<=@EDSTOCKSUPPLIERCODERF";
            //    SqlParameter paraEdStockSupplierCode = sqlCommand.Parameters.Add("@EDSTOCKSUPPLIERCODERF", SqlDbType.Int);
            //    paraEdStockSupplierCode.Value = SqlDataMediator.SqlSetInt32(_stockOverListCndtnWork.Ed_SupplierCd);
            //}

            //���[�J�[�R�[�h�ݒ�
            if (_stockOverListCndtnWork.St_GoodsMakerCd != 0)
            {
                retstring += " AND STOCK.GOODSMAKERCDRF>=@STGOODSMAKERCD";
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockOverListCndtnWork.St_GoodsMakerCd);
            }
            if (_stockOverListCndtnWork.Ed_GoodsMakerCd != 9999)
            {
                retstring += " AND STOCK.GOODSMAKERCDRF<=@EDGOODSMAKERCD";
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockOverListCndtnWork.Ed_GoodsMakerCd);
            }

            //�I�Ԑݒ�
            if (_stockOverListCndtnWork.St_WarehouseShelfNo != "")
            {
                retstring += " AND STOCK.WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNO";
                SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNO", SqlDbType.NVarChar);
                paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.St_WarehouseShelfNo);
            }
            if (_stockOverListCndtnWork.Ed_WarehouseShelfNo != "")
            {
                if (_stockOverListCndtnWork.St_WarehouseShelfNo != "")
                {
                    retstring += " AND STOCK.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO";
                }
                else
                {
                    retstring += " AND (STOCK.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO OR STOCK.WAREHOUSESHELFNORF IS NULL)";
                }

                SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.Ed_WarehouseShelfNo + "%");
            }

            //���i�ԍ��ݒ�
            if (_stockOverListCndtnWork.St_GoodsNo != "")
            {
                retstring += " AND STOCK.GOODSNORF>=@STGOODSNO";
                SqlParameter paraStGoodsNo = sqlCommand.Parameters.Add("@STGOODSNO", SqlDbType.NVarChar);
                paraStGoodsNo.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.St_GoodsNo);
            }
            if (_stockOverListCndtnWork.Ed_GoodsNo != "")
            {
                retstring += " AND STOCK.GOODSNORF<=@EDGOODSNO";
                SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@EDGOODSNO", SqlDbType.NVarChar);
				paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.Ed_GoodsNo);
			}

            //���i�敪�ݒ�
            if (_stockOverListCndtnWork.St_EnterpriseGanreCode != 0)
            {
                retstring += " AND GDSU.ENTERPRISEGANRECODERF>=@STENTERPRISEGANRECODE";
                SqlParameter paraStEnterpriseGanreCode = sqlCommand.Parameters.Add("@STENTERPRISEGANRECODE", SqlDbType.Int);
                paraStEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(_stockOverListCndtnWork.St_EnterpriseGanreCode);
            }
            if (_stockOverListCndtnWork.Ed_EnterpriseGanreCode != 9999)
            {
                retstring += " AND GDSU.ENTERPRISEGANRECODERF<=@EDENTERPRISEGANRECODE";
                SqlParameter paraEdEnterpriseGanreCode = sqlCommand.Parameters.Add("@EDENTERPRISEGANRECODE", SqlDbType.Int);
                paraEdEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(_stockOverListCndtnWork.Ed_EnterpriseGanreCode);
            }

            //BL���i�R�[�h�ݒ�
            if (_stockOverListCndtnWork.St_BLGoodsCode != 0)
            {
                retstring += " AND GDSU.BLGOODSCODERF>=@STBLGOODSCODERF";
                SqlParameter paraStEnterpriseGanreCode = sqlCommand.Parameters.Add("@STBLGOODSCODERF", SqlDbType.Int);
                paraStEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(_stockOverListCndtnWork.St_BLGoodsCode);
            }
            if (_stockOverListCndtnWork.Ed_BLGoodsCode != 99999)
            {
                retstring += " AND GDSU.BLGOODSCODERF<=@EDBLGOODSCODERF";
                SqlParameter paraEdEnterpriseGanreCode = sqlCommand.Parameters.Add("@EDBLGOODSCODERF", SqlDbType.Int);
                paraEdEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(_stockOverListCndtnWork.Ed_BLGoodsCode);
            }

            //���i�Ǘ��敪�P  ���z��ŕ����w�肳���
            if (_stockOverListCndtnWork.PartsManagementDivide1 != null)
            {
                string Divied1 = "";
                foreach (string Divide1str in _stockOverListCndtnWork.PartsManagementDivide1)
                {
                    if (Divied1 != "")
                    {
                        Divied1 += ",";
                    }
                    Divied1 += "'" + Divide1str + "'";
                }

                if (Divied1 != "")
                {
                    retstring += " AND STOCK.PARTSMANAGEMENTDIVIDE1RF IN (" + Divied1 + ") ";
                }
            }

            //���i�Ǘ��敪�Q  ���z��ŕ����w�肳���
            if (_stockOverListCndtnWork.PartsManagementDivide2 != null)
            {
                string Divied2 = "";
                foreach (string Divide2str in _stockOverListCndtnWork.PartsManagementDivide2)
                {
                    if (Divied2 != "")
                    {
                        Divied2 += ",";
                    }
                    Divied2 += "'" + Divide2str + "'";
                }

                if (Divied2 != "")
                {
                    retstring += " AND STOCK.PARTSMANAGEMENTDIVIDE2RF IN (" + Divied2 + ") ";
                }
            }

            ////�ߏ�݌ɔ��f(�ō��݌ɐ����o�׉\��)
            //retstring += " AND STOCK.MAXIMUMSTOCKCNTRF<STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;

            ////���o�׍݌ɔ��f
            //if (_stockOverListCndtnWork.NoShipmentDiv != 0)
            //{
            //    retstring += " AND (HISSUB.SALESTIMES<=0 OR HISSUB.SALESTIMES IS NULL)" + Environment.NewLine;
            //}

            #endregion
            return retstring;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_stockOverListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereStringHIS(ref SqlCommand sqlCommand, StockOverListCndtnWork _stockOverListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = " WHERE ";

            //��ƃR�[�h
            retstring += " HIS.ENTERPRISECODERF=@@ENTERPRISECODE";
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.EnterpriseCode);

            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND HIS.LOGICALDELETECODERF=@@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND HIS.LOGICALDELETECODERF<@@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            ////���_�R�[�h    ���z��ŕ����w�肳���
            //if (_stockOverListCndtnWork.SectionCodes != null)
            //{
            //    string sectionCodestr = "";
            //    foreach (string seccdstr in _stockOverListCndtnWork.SectionCodes)
            //    {
            //        if (sectionCodestr != "")
            //        {
            //            sectionCodestr += ",";
            //        }
            //        sectionCodestr += "'" + seccdstr + "'";
            //    }

            //    if (sectionCodestr != "")
            //    {
            //        retstring += " AND HIS.SECTIONCODERF IN (" + sectionCodestr + ") ";
            //    }
            //}

            //�q�ɃR�[�h�ݒ�
            if (_stockOverListCndtnWork.St_WarehouseCode != "")
            {
                retstring += " AND HIS.WAREHOUSECODERF>=@@STWAREHOUSECODE";
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.St_WarehouseCode);
            }
            if (_stockOverListCndtnWork.Ed_WarehouseCode != "")
            {
                retstring += " AND HIS.WAREHOUSECODERF<=@@EDWAREHOUSECODE";
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.Ed_WarehouseCode);
            }

            //���[�J�[�R�[�h�ݒ�
            if (_stockOverListCndtnWork.St_GoodsMakerCd != 0)
            {
                retstring += " AND HIS.GOODSMAKERCDRF>=@@STGOODSMAKERCD";
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@@STGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockOverListCndtnWork.St_GoodsMakerCd);
            }
            if (_stockOverListCndtnWork.Ed_GoodsMakerCd != 9999)
            {
                retstring += " AND HIS.GOODSMAKERCDRF<=@@EDGOODSMAKERCD";
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@@EDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockOverListCndtnWork.Ed_GoodsMakerCd);
            }

            //���i�ԍ��ݒ�
            if (_stockOverListCndtnWork.St_GoodsNo != "")
            {
                retstring += " AND HIS.GOODSNORF>=@@STGOODSNO";
                SqlParameter paraStGoodsNo = sqlCommand.Parameters.Add("@@STGOODSNO", SqlDbType.NVarChar);
                paraStGoodsNo.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.St_GoodsNo);
            }
            if (_stockOverListCndtnWork.Ed_GoodsNo != "")
            {
                retstring += " AND HIS.GOODSNORF<=@@EDGOODSNO";
                SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@@EDGOODSNO", SqlDbType.NVarChar);

				// 2008.03.26 >>
                //paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.Ed_GoodsNo + "%");
				paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.Ed_GoodsNo);
				// 2008.03.26 <<
			}

            //�N���x�ݒ�
            if (_stockOverListCndtnWork.St_AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND HIS.ADDUPYEARMONTHRF>=@STADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
                paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_stockOverListCndtnWork.St_AddUpYearMonth);
            }
            if (_stockOverListCndtnWork.Ed_AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND HIS.ADDUPYEARMONTHRF<=@EDADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);
                paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_stockOverListCndtnWork.Ed_AddUpYearMonth);
            }
            
            #endregion
            return retstring;
        }

        // -- ADD 2011/03/16 ------------------------------>>>
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̍݌ɉߏ�ꗗ�\LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retStockOverList">��������</param>
        /// <param name="_stockOverListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̍݌ɉߏ�ꗗ�\LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2009.04.23</br>
        private int GetSalesTimesProc(ref List<StockHistoryWork> retStockHistoryList, MonthlyAddUpWork monthlyAddUpWork, StockOverListCndtnWork _stockOverListCndtnWork,  ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {

                string selectTxt = "";
                sqlCommand = new SqlCommand("", sqlConnection);

                #region Select���쐬
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "    STPAYCNT.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "    STPAYCNT.WAREHOUSECODERF," + Environment.NewLine;
                selectTxt += "    STPAYCNT.GOODSMAKERCDRF," + Environment.NewLine;
                selectTxt += "    STPAYCNT.GOODSNORF," + Environment.NewLine;
                selectTxt += "    SUM(CASE WHEN ((STPAYCNT.ACPAYSLIPCDRF=20 AND STPAYCNT.ACPAYTRANSCDRF=10) AND DELSLIPNUM IS NULL) THEN 1 ELSE 0 END) AS SALESTIMESRF--�����" + Environment.NewLine;
                selectTxt += "   FROM  " + Environment.NewLine;
                selectTxt += "   (" + Environment.NewLine;
                selectTxt += "      SELECT " + Environment.NewLine;
                selectTxt += "       STOCKACPAYHIST.LOGICALDELETECODERF," + Environment.NewLine;
                selectTxt += "       STOCKACPAYHIST.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "       STOCKACPAYHIST.WAREHOUSECODERF," + Environment.NewLine;
                selectTxt += "       STOCKACPAYHIST.GOODSMAKERCDRF," + Environment.NewLine;
                selectTxt += "       STOCKACPAYHIST.GOODSNORF," + Environment.NewLine;
                selectTxt += "       STOCKACPAYHIST.ACPAYSLIPNUMRF, --�`�[�ԍ�" + Environment.NewLine;
                selectTxt += "       STOCKACPAYHIST.ACPAYSLIPCDRF,  --�󕥌��`�[�敪" + Environment.NewLine;
                selectTxt += "       STOCKACPAYHIST.ACPAYTRANSCDRF,  --�󕥌�����敪" + Environment.NewLine;
                selectTxt += "       DELSTOCKACPAYHIST.ACPAYSLIPNUMRF AS DELSLIPNUM --�`�[�ԍ�" + Environment.NewLine;
                selectTxt += "      FROM" + Environment.NewLine;
                selectTxt += "       STOCKACPAYHISTRF AS STOCKACPAYHIST WITH (READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += "     LEFT JOIN" + Environment.NewLine;
                selectTxt += "      (" + Environment.NewLine;
                selectTxt += "        SELECT" + Environment.NewLine;
                selectTxt += "         LOGICALDELETECODERF," + Environment.NewLine;
                selectTxt += "         ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "         WAREHOUSECODERF," + Environment.NewLine;
                selectTxt += "         GOODSMAKERCDRF," + Environment.NewLine;
                selectTxt += "         GOODSNORF," + Environment.NewLine;
                selectTxt += "         ACPAYSLIPNUMRF --�󕥌��`�[�ԍ�" + Environment.NewLine;
                selectTxt += "        FROM" + Environment.NewLine;
                selectTxt += "         STOCKACPAYHISTRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += "        WHERE" + Environment.NewLine;
                selectTxt += "            ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
                selectTxt += "        AND LOGICALDELETECODERF=0 " + Environment.NewLine;
                selectTxt += "        AND ACPAYTRANSCDRF = 21 " + Environment.NewLine;
                selectTxt += "      ) AS DELSTOCKACPAYHIST" + Environment.NewLine;
                selectTxt += "       ON  STOCKACPAYHIST.ENTERPRISECODERF = DELSTOCKACPAYHIST.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "       AND STOCKACPAYHIST.WAREHOUSECODERF = DELSTOCKACPAYHIST.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "       AND STOCKACPAYHIST.GOODSMAKERCDRF = DELSTOCKACPAYHIST.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "       AND STOCKACPAYHIST.GOODSNORF = DELSTOCKACPAYHIST.GOODSNORF" + Environment.NewLine;
                selectTxt += "       AND STOCKACPAYHIST.ACPAYSLIPNUMRF = DELSTOCKACPAYHIST.ACPAYSLIPNUMRF          " + Environment.NewLine;
                selectTxt += "      WHERE STOCKACPAYHIST.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "       AND STOCKACPAYHIST.LOGICALDELETECODERF=0" + Environment.NewLine;
                selectTxt += "     AND( ( CASE WHEN STOCKACPAYHIST.ADDUPADATERF IS NULL THEN STOCKACPAYHIST.IOGOODSDAYRF ELSE STOCKACPAYHIST.ADDUPADATERF END ) >@FINDADDUPDATEST  AND (CASE WHEN STOCKACPAYHIST.ADDUPADATERF IS NULL THEN STOCKACPAYHIST.IOGOODSDAYRF ELSE STOCKACPAYHIST.ADDUPADATERF END )<=@FINDADDUPDATEED)" + Environment.NewLine;
                selectTxt += "   ) AS STPAYCNT" + Environment.NewLine;

                //WHERE���̍쐬
                selectTxt += MakeWhereStringSalesTime(ref sqlCommand, monthlyAddUpWork, _stockOverListCndtnWork);

                selectTxt += "   GROUP BY" + Environment.NewLine;
                selectTxt += "    STPAYCNT.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "    STPAYCNT.WAREHOUSECODERF," + Environment.NewLine;
                selectTxt += "    STPAYCNT.GOODSMAKERCDRF," + Environment.NewLine;
                selectTxt += "    STPAYCNT.GOODSNORF" + Environment.NewLine;

                sqlCommand.CommandText = selectTxt;
                #endregion



                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    StockHistoryWork stockhisWork = new StockHistoryWork();

                    //�i�[����
                    stockhisWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    stockhisWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    stockhisWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    stockhisWork.SalesTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMESRF"));

                    #endregion

                    retStockHistoryList.Add(stockhisWork);

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
                base.WriteErrorLog(ex, "StockOverListWorkDB.GetSalesTimesProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                    myReader = null;
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                    sqlCommand = null;
                }
            }

            return status;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_stockOverListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereStringSalesTime(ref SqlCommand sqlCommand, MonthlyAddUpWork monthlyAddUpWork, StockOverListCndtnWork _stockOverListCndtnWork)
        {
            #region WHERE���쐬
            string retstring = " WHERE " + Environment.NewLine;

            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaAddUpDateSt = sqlCommand.Parameters.Add("@FINDADDUPDATEST", SqlDbType.Int);
            SqlParameter findParaAddUpDateEd = sqlCommand.Parameters.Add("@FINDADDUPDATEED", SqlDbType.Int);

            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(monthlyAddUpWork.EnterpriseCode);
            findParaAddUpDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(monthlyAddUpWork.AddUpDateSt);
            findParaAddUpDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(monthlyAddUpWork.AddUpDate);

            //��ƃR�[�h
            retstring += " STPAYCNT.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

            //�q�ɃR�[�h�ݒ�
            if (_stockOverListCndtnWork.St_WarehouseCode != "")
            {
                retstring += " AND STPAYCNT.WAREHOUSECODERF>=@STWAREHOUSECODE";
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.St_WarehouseCode);
            }
            if (_stockOverListCndtnWork.Ed_WarehouseCode != "")
            {
                retstring += " AND STPAYCNT.WAREHOUSECODERF<=@EDWAREHOUSECODE";
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.Ed_WarehouseCode);
            }

            //���[�J�[�R�[�h�ݒ�
            if (_stockOverListCndtnWork.St_GoodsMakerCd != 0)
            {
                retstring += " AND STPAYCNT.GOODSMAKERCDRF>=@STGOODSMAKERCD";
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockOverListCndtnWork.St_GoodsMakerCd);
            }
            if (_stockOverListCndtnWork.Ed_GoodsMakerCd != 9999)
            {
                retstring += " AND STPAYCNT.GOODSMAKERCDRF<=@EDGOODSMAKERCD";
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockOverListCndtnWork.Ed_GoodsMakerCd);
            }

            //���i�ԍ��ݒ�
            if (_stockOverListCndtnWork.St_GoodsNo != "")
            {
                retstring += " AND STPAYCNT.GOODSNORF>=@STGOODSNO";
                SqlParameter paraStGoodsNo = sqlCommand.Parameters.Add("@STGOODSNO", SqlDbType.NVarChar);
                paraStGoodsNo.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.St_GoodsNo);
            }
            if (_stockOverListCndtnWork.Ed_GoodsNo != "")
            {
                retstring += " AND STPAYCNT.GOODSNORF<=@EDGOODSNO";
                SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@EDGOODSNO", SqlDbType.NVarChar);
                paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.Ed_GoodsNo);
            }
            #endregion
            return retstring;
        }
        // -- ADD 2011/03/16 ------------------------------<<<

    }

}
