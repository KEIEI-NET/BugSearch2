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
    /// �݌ɒ����m�F�\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌ɒ����m�F�\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22035 �O�� �O��</br>
    /// <br>Date       : 2007.03.17</br>
    /// <br></br>
    /// <br>UpdateNote : 2007.10.02 ���� DC.NS�p�ɏC��</br>
	/// <br></br>
	/// <br>Update Note: 2008.03.26 ���X�� ��</br>
	/// <br>           : ���i�R�[�h�̍i�荞�݂��C��</br>
    /// <br></br>
    /// <br>Update Note: 2008.06.30 20081</br>
    /// <br>           : �o�l.�m�r�p�ɕύX</br>
    /// <br></br>
    /// <br>UpdateNote : 2010/05/10 ���� ���x�`���[�j���O</br>
    /// <br>Update Note: 2011.11.15 ���|��</br>
    /// <br>           : redmine#26559</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class StockAdjustWorkDB : RemoteDB, IStockAdjustWorkDB
    {
        /// <summary>
        /// �݌ɒ����m�F�\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.03.17</br>
        /// </remarks>
        public StockAdjustWorkDB()
            :
        base("MAZAI02056D", "Broadleaf.Application.Remoting.ParamData.StockAdjustResultWork", "STOCKADJUSTDTLRF") //���N���X�̃R���X�g���N�^
        {
        }

        #region Search
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̍݌ɒ����m�F�\LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="stockAdjustResultWork">��������</param>
        /// <param name="stockAdjustCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎���c�ꗗ�\LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.03.17</br>
        public int Search(out object stockAdjustResultWork, object stockAdjustCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            stockAdjustResultWork = null;

            StockAdjustCndtnWork _stockAdjustCndtnWork = stockAdjustCndtnWork as StockAdjustCndtnWork;

            try
            {
                status = SearchProc(out stockAdjustResultWork, _stockAdjustCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockAdjustWorkDB.Search Exception=" + ex.Message);
                stockAdjustResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̍݌ɒ����m�F�\LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="stockAdjustResultWork">��������</param>
        /// <param name="_stockAdjustCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎���c�ꗗ�\LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.03.17</br>
        private int SearchProc(out object stockAdjustResultWork, StockAdjustCndtnWork _stockAdjustCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            stockAdjustResultWork = null;

            ArrayList al = new ArrayList();   //���o����

            //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return status;

            //SQL������
            sqlConnection = new SqlConnection(connectionText);
            sqlConnection.Open();

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                // �Ώۃe�[�u��
                // STOCKADJUSTRF    SAJ   �݌ɒ����f�[�^
                // STOCKADJUSTDTLRF SAD   �݌ɒ������׃f�[�^
                // SECINFOSETRF     SIS   ���_���ݒ�}�X�^

                string selectTxt = "";

                #region Select���쐬
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "     SAJ.STOCKSECTIONCDRF" + Environment.NewLine;
                selectTxt += "    ,SIS.SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "    ,SAD.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "    ,SAD.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "    ,SAD.ACPAYSLIPCDRF" + Environment.NewLine;
                selectTxt += "    ,SAD.ACPAYTRANSCDRF" + Environment.NewLine;
                selectTxt += "    ,SAD.ADJUSTDATERF" + Environment.NewLine;
                selectTxt += "    ,SAD.STOCKADJUSTSLIPNORF" + Environment.NewLine;
                selectTxt += "    ,SAD.STOCKADJUSTROWNORF" + Environment.NewLine;
                selectTxt += "    ,SAD.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "    ,SAD.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "    ,SAD.GOODSNORF" + Environment.NewLine;
                selectTxt += "    ,SAD.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "    ,SAJ.INPUTDAYRF" + Environment.NewLine;
                // ----- DEL 2011/11/15 xupz---------->>>>>
                //selectTxt += "    ,SAJ.STOCKINPUTCODERF" + Environment.NewLine; //�d�����͎҃R�[�h
                //selectTxt += "    ,SAJ.STOCKINPUTNAMERF" + Environment.NewLine; //�d�����͎Җ���
                // ----- DEL 2011/11/15 xupz----------<<<<<
                // ----- ADD 2011/11/15 xupz---------->>>>>
                selectTxt += "    ,SAJ.STOCKAGENTCODERF" + Environment.NewLine; //�d���S���҃R�[�h
                selectTxt += "    ,SAJ.STOCKAGENTNAMERF" + Environment.NewLine; //�d���S���Җ���
                // ----- ADD 2011/11/15 xupz----------<<<<<
                selectTxt += "    ,SAD.ADJUSTCOUNTRF" + Environment.NewLine;
                selectTxt += "    ,SAD.LISTPRICEFLRF" + Environment.NewLine;
                selectTxt += "    ,SAD.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "    ,SAD.BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "    ,SAD.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "    ,SAD.DTLNOTERF" + Environment.NewLine;
                selectTxt += "    ,SAJ.SLIPNOTERF" + Environment.NewLine;
                selectTxt += "    ,SAD.OPENPRICEDIVRF" + Environment.NewLine;
                selectTxt += "    ,SAD.STOCKPRICETAXEXCRF" + Environment.NewLine;
                selectTxt += " FROM STOCKADJUSTRF AS SAJ" + Environment.NewLine;

                //�݌ɒ������׃f�[�^����
                selectTxt += " LEFT JOIN STOCKADJUSTDTLRF SAD ON SAD.ENTERPRISECODERF=SAJ.ENTERPRISECODERF AND SAD.STOCKADJUSTSLIPNORF=SAJ.STOCKADJUSTSLIPNORF" + Environment.NewLine;
                //���_���ݒ茋��
                selectTxt += " LEFT JOIN SECINFOSETRF SIS ON SIS.ENTERPRISECODERF=SAD.ENTERPRISECODERF AND SIS.SECTIONCODERF=SAJ.STOCKSECTIONCDRF" + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                //WHERE���̍쐬
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, _stockAdjustCndtnWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    StockAdjustResultWork wkStockAdjustResultWork = new StockAdjustResultWork();

                    //�݌Ɏԗ����o�ɊǗ��}�X�^���ʎ擾���e�i�[
                    wkStockAdjustResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
                    wkStockAdjustResultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    wkStockAdjustResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wkStockAdjustResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    wkStockAdjustResultWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
                    wkStockAdjustResultWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));
                    wkStockAdjustResultWork.AdjustDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADJUSTDATERF"));
                    wkStockAdjustResultWork.StockAdjustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTSLIPNORF"));
                    wkStockAdjustResultWork.StockAdjustRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTROWNORF"));
                    wkStockAdjustResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkStockAdjustResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    wkStockAdjustResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkStockAdjustResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkStockAdjustResultWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
                    // ----- DEL 2011/11/15 xupz---------->>>>>
                    //wkStockAdjustResultWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF")); //�d�����͎҃R�[�h
                    //wkStockAdjustResultWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF")); //�d�����͎Җ���
                    // ----- DEL 2011/11/15 xupz----------<<<<<
                    // ----- ADD 2011/11/15 xupz---------->>>>>
                    wkStockAdjustResultWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF")); //�d���S���҃R�[�h
                    wkStockAdjustResultWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF")); //�d���S���Җ���
                    // ----- ADD 2011/11/15 xupz----------<<<<<
                    wkStockAdjustResultWork.AdjustCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ADJUSTCOUNTRF"));
                    wkStockAdjustResultWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICEFLRF"));
                    wkStockAdjustResultWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    wkStockAdjustResultWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));
                    wkStockAdjustResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    wkStockAdjustResultWork.DtlNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DTLNOTERF"));
                    wkStockAdjustResultWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
                    wkStockAdjustResultWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    wkStockAdjustResultWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
                    #endregion

                    al.Add(wkStockAdjustResultWork);

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
                base.WriteErrorLog(ex, "StockAdjustWorkDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            stockAdjustResultWork = al;

            return status;
        }
        #endregion

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_stockAdjustCndtnWork">���������i�[�N���X</param>
        /// <param name="_productNumberOutPutDiv">���Ԓ��o�敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockAdjustCndtnWork _stockAdjustCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = "WHERE" + Environment.NewLine;

            //��ƃR�[�h
            // -- UPD 2010/05/10 ------------------------------------->>>
            //retstring += " SAD.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            retstring += " SAJ.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            // -- UPD 2010/05/10 -------------------------------------<<<
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(_stockAdjustCndtnWork.EnterpriseCode);

            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                // -- UPD 2010/05/10 ------------------------------------->>>
                //retstring += " AND SAD.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                retstring += " AND SAJ.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                // -- UPD 2010/05/10 -------------------------------------<<<
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                // -- UPD 2010/05/10 ------------------------------------->>>
                //retstring += " AND SAD.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                retstring += " AND SAJ.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                // -- UPD 2010/05/10 -------------------------------------<<<
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //���_�R�[�h    ���z��ŕ����w�肳���
            if (_stockAdjustCndtnWork.SectionCodes != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _stockAdjustCndtnWork.SectionCodes)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }

                if (sectionCodestr != "")
                {
                    retstring += " AND SAJ.STOCKSECTIONCDRF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //�q�ɃR�[�h�ݒ�
            if (_stockAdjustCndtnWork.St_WarehouseCode != "")
            {
                retstring += " AND SAD.WAREHOUSECODERF>=@STWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockAdjustCndtnWork.St_WarehouseCode);
            }
            if (_stockAdjustCndtnWork.Ed_WarehouseCode != "")
            {
                retstring += " AND SAD.WAREHOUSECODERF<=@EDWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockAdjustCndtnWork.Ed_WarehouseCode);
            }

            //�󕥌��`�[�敪    ���z��ŕ����w�肳���
            if (_stockAdjustCndtnWork.AcPaySlipCds != null)
            {
                string acPaySlipCd = "";
                foreach (Int32 code in _stockAdjustCndtnWork.AcPaySlipCds)
                {
                    if (acPaySlipCd != "")
                    {
                        acPaySlipCd += ",";
                    }
                    acPaySlipCd += code;
                }

                if (acPaySlipCd != "")
                {
                    // -- UPD 2010/05/10 ------------------------------------->>>
                    //retstring += " AND SAD.ACPAYSLIPCDRF IN (" + acPaySlipCd + ") ";
                    retstring += " AND SAJ.ACPAYSLIPCDRF IN (" + acPaySlipCd + ") ";
                    // -- UPD 2010/05/10 -------------------------------------<<<
                }
                retstring += Environment.NewLine;
            }


            //�󕥌�����敪
            if (_stockAdjustCndtnWork.AcPayTransCd != -1)
            {
                retstring += " AND SAD.ACPAYTRANSCDRF=@ACPAYTRANSCD" + Environment.NewLine;
                SqlParameter paraAcPayTransCd = sqlCommand.Parameters.Add("@ACPAYTRANSCD", SqlDbType.Int);
                paraAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(_stockAdjustCndtnWork.AcPayTransCd);
            }

            //�������t
            if (_stockAdjustCndtnWork.St_AdjustDate != DateTime.MinValue)
            {
                int startymd = TDateTime.DateTimeToLongDate(_stockAdjustCndtnWork.St_AdjustDate);
                retstring += " AND SAJ.ADJUSTDATERF >= " + startymd.ToString() + Environment.NewLine;
            }
            if (_stockAdjustCndtnWork.Ed_AdjustDate != DateTime.MinValue)
            {
                if (_stockAdjustCndtnWork.St_AdjustDate == DateTime.MinValue)
                {
                    retstring += " AND (SAJ.ADJUSTDATERF IS NULL OR";
                }
                else
                {
                    retstring += " AND";
                }

                int endymd = TDateTime.DateTimeToLongDate(_stockAdjustCndtnWork.Ed_AdjustDate);
                retstring += " SAJ.ADJUSTDATERF <= " + endymd.ToString();

                if (_stockAdjustCndtnWork.St_AdjustDate == DateTime.MinValue)
                {
                    retstring += " ) ";
                }
                retstring += Environment.NewLine;
            }

            // 2008.06.30 del start ------------------------------------------------>>
            ////�݌ɒ����`�[�ԍ�
            //if (_stockAdjustCndtnWork.St_StockAdjustSlipNo != 0)
            //{
            //    retstring += " AND SAD.STOCKADJUSTSLIPNORF>=@STSTOCKADJUSTSLIPNO" + Environment.NewLine;
            //    SqlParameter paraStStockAdjustSlipNo = sqlCommand.Parameters.Add("@STSTOCKADJUSTSLIPNO", SqlDbType.Int);
            //    paraStStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(_stockAdjustCndtnWork.St_StockAdjustSlipNo);
            //}
            //if (_stockAdjustCndtnWork.Ed_StockAdjustSlipNo != 999999999)
            //{
            //    retstring += " AND SAD.STOCKADJUSTSLIPNORF<=@EDSTOCKADJUSTSLIPNO" + Environment.NewLine;
            //    SqlParameter paraEdStockAdjustSlipNo = sqlCommand.Parameters.Add("@EDSTOCKADJUSTSLIPNO", SqlDbType.Int);
            //    paraEdStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(_stockAdjustCndtnWork.Ed_StockAdjustSlipNo);
            //}

            ////���[�J�[�R�[�h
            //if (_stockAdjustCndtnWork.St_GoodsMakerCd != 0)
            //{
            //    retstring += " AND SAD.GOODSMAKERCDRF>=@STGOODSMAKERCD" + Environment.NewLine;
            //    SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
            //    paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockAdjustCndtnWork.St_GoodsMakerCd);
            //}
            //if (_stockAdjustCndtnWork.Ed_GoodsMakerCd != 999999)
            //{
            //    retstring += " AND SAD.GOODSMAKERCDRF<=@EDGOODSMAKERCD" + Environment.NewLine;
            //    SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
            //    paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockAdjustCndtnWork.Ed_GoodsMakerCd);
            //}

            ////���i�ԍ�
            //if (_stockAdjustCndtnWork.St_GoodsNo != "")
            //{
            //    retstring += " AND SAD.GOODSNORF>=@STGOODSNO" + Environment.NewLine;
            //    SqlParameter paraStGoodsCode = sqlCommand.Parameters.Add("@STGOODSNO", SqlDbType.NVarChar);
            //    paraStGoodsCode.Value = SqlDataMediator.SqlSetString(_stockAdjustCndtnWork.St_GoodsNo);
            //}
            //if (_stockAdjustCndtnWork.Ed_GoodsNo != "")
            //{
            //    retstring += " AND (SAD.GOODSNORF<=@EDGOODSNO OR SAD.GOODSNORF LIKE @EDGOODSNO)" + Environment.NewLine;
            //    SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@EDGOODSNO", SqlDbType.NVarChar);
            //    // 2008.03.26 >>
            //    //paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockAdjustCndtnWork.Ed_GoodsNo + "%");
            //    paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockAdjustCndtnWork.Ed_GoodsNo);
            //    // 2008.03.26 <<
            //}
            // 2008.06.30 del end --------------------------------------------------<<

            // 2008.06.30 add start ------------------------------------------------>>
            // ���͓�
            if (_stockAdjustCndtnWork.St_InputDay != DateTime.MinValue)
            {
                int startInymd = TDateTime.DateTimeToLongDate(_stockAdjustCndtnWork.St_InputDay);
                retstring += " AND SAJ.INPUTDAYRF >= " + startInymd.ToString() + Environment.NewLine;
            }
            if (_stockAdjustCndtnWork.Ed_InputDay != DateTime.MinValue)
            {
                if (_stockAdjustCndtnWork.St_InputDay == DateTime.MinValue)
                {
                    retstring += " AND (SAJ.INPUTDAYRF IS NULL OR";
                }   
                else
                {
                    retstring += " AND";
                }

                int endInymd = TDateTime.DateTimeToLongDate(_stockAdjustCndtnWork.Ed_InputDay);
                retstring += " SAJ.INPUTDAYRF <= " + endInymd.ToString();

                if (_stockAdjustCndtnWork.St_InputDay == DateTime.MinValue)
                {
                    retstring += ") ";
                }
                retstring += Environment.NewLine;
            }
            // 2008.06.30 add end --------------------------------------------------<<

            // ----- DEL 2011/11/15 xupz---------->>>>>
            //�d�����͎҃R�[�h
            //if (_stockAdjustCndtnWork.St_InputAgenCd != "")
            //{
            //    retstring += " AND SAJ.STOCKINPUTCODERF>=@STINPUTAGENCD" + Environment.NewLine;
            //    SqlParameter paraStInputAgenCd = sqlCommand.Parameters.Add("@STINPUTAGENCD", SqlDbType.NVarChar);
            //    paraStInputAgenCd.Value = SqlDataMediator.SqlSetString(_stockAdjustCndtnWork.St_InputAgenCd);
            //}
            //if (_stockAdjustCndtnWork.Ed_InputAgenCd != "")
            //{
            //    if (_stockAdjustCndtnWork.St_InputAgenCd == "")
            //    {
            //        retstring += " AND (SAJ.STOCKINPUTCODERF IS NULL OR";
            //    }
            //    else
            //    {
            //        retstring += " AND (";
            //    }

            //    retstring += " SAJ.STOCKINPUTCODERF<=@EDINPUTAGENCD)" + Environment.NewLine;
            //    SqlParameter paraEdInputAgenCd = sqlCommand.Parameters.Add("@EDINPUTAGENCD", SqlDbType.NVarChar);
            //    paraEdInputAgenCd.Value = SqlDataMediator.SqlSetString(_stockAdjustCndtnWork.Ed_InputAgenCd);
            //}
            // ----- DEL 2011/11/15 xupz----------<<<<<

            // ----- ADD 2011/11/15 xupz---------->>>>>
            //�d���S���҃R�[�h
            if (_stockAdjustCndtnWork.St_InputAgenCd != "")
            {
                retstring += " AND SAJ.STOCKAGENTCODERF>=@STINPUTAGENCD" + Environment.NewLine;
                SqlParameter paraStInputAgenCd = sqlCommand.Parameters.Add("@STINPUTAGENCD", SqlDbType.NVarChar);
                paraStInputAgenCd.Value = SqlDataMediator.SqlSetString(_stockAdjustCndtnWork.St_InputAgenCd);
            }
            if (_stockAdjustCndtnWork.Ed_InputAgenCd != "")
            {
                if (_stockAdjustCndtnWork.St_InputAgenCd == "")
                {
                    retstring += " AND (SAJ.STOCKAGENTCODERF IS NULL OR";
                }
                else
                {
                    retstring += " AND (";
                }

                retstring += " SAJ.STOCKAGENTCODERF<=@EDINPUTAGENCD)" + Environment.NewLine;
                SqlParameter paraEdInputAgenCd = sqlCommand.Parameters.Add("@EDINPUTAGENCD", SqlDbType.NVarChar);
                paraEdInputAgenCd.Value = SqlDataMediator.SqlSetString(_stockAdjustCndtnWork.Ed_InputAgenCd);
            }
            // ----- ADD 2011/11/15 xupz----------<<<<<

            ////�݌ɋ敪
            //if (_stockAdjustCndtnWork.StockDiv != -1)
            //{
            //    retstring += " AND SAD.STOCKDIVRF=@STOCKDIV" + Environment.NewLine;
            //    SqlParameter paraStockDiv = sqlCommand.Parameters.Add("@STOCKDIV", SqlDbType.Int);
            //    paraStockDiv.Value = SqlDataMediator.SqlSetInt32(_stockAdjustCndtnWork.StockDiv);
            //}

            #endregion
            return retstring;
        }
    }
}
