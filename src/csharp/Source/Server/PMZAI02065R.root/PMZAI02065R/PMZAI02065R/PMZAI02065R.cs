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
    /// �ϑ��݌ɕ�[����DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ϑ��݌ɕ�[�����̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30350 �N�� ����</br>
    /// <br>Date       : 2008.10.17</br>
    /// <br></br>
    /// <br>Update Note: �ϑ��݌ɕ�[�����̏�Q�C��</br>
    /// <br>             �{�w�C��</br>          
    /// <br>Data: 2010/12/03</br>  
    /// <br>Update Note: 2012/09/06 ������</br>
    /// <br>           : 10801804-00�A2012/09/19�z�M���APM�ێ�Č�Redmine#32179�̑Ή�</br>
    /// <br>           : �@�ϑ��݌ɕ�[�����ɂŘ_���폜���Ă����q�Ƀf�[�^�������ΏۊO�ɉ��C���܂�</br>
    /// <br>             �A��[�����i�������u�������čX�V�v�̋敪��I�����Ď��s���A��[���̍݌Ƀ}�X�^���V�K�쐬�����B</br>
    /// </remarks>
    [Serializable]
    public class TrustStockOrderWorkDB : RemoteDB, ITrustStockOrderWorkDB
    {
        /// <summary>
        /// �ϑ��݌ɕ�[����DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.10.17</br>
        /// </remarks>
        public TrustStockOrderWorkDB()
            :
        base("PMZAI02065", "Broadleaf.Application.Remoting.ParamData.TrustStockResultWork", "WAREHOUSERF") //���N���X�̃R���X�g���N�^
        {
        }

        #region �ϑ��݌ɕ�[����
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̈ϑ��݌ɕ�[������LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="supplierUnmResultWork">��������</param>
        /// <param name="supplierUnmOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̈ϑ��݌ɕ�[������LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.10.17</br>
        public int Search(out object trustStockResultWork, object trustStockOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            trustStockResultWork = null;

            TrustStockOrderCndtnWork _trustStockOrderCndtnWork = trustStockOrderCndtnWork as TrustStockOrderCndtnWork;

            try
            {
                status = SearchProc(out trustStockResultWork, _trustStockOrderCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "TrustStockOrderWork.Search Exception=" + ex.Message);
                trustStockResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̎d���ϑ��݌ɕ�[����LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="supplierUnmResultWork">��������</param>
        /// <param name="_supplierUnmOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̕����ꗗ�\LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.9.18</br>
        /// <br></br>
        private int SearchProc(out object trustStockResultWork, TrustStockOrderCndtnWork _trustStockOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            trustStockResultWork = null;

            ArrayList al = new ArrayList();   //���o����

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();


                status = SearchOrderProc(ref al, ref sqlConnection, _trustStockOrderCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "TrustStockOrderWorkDB.SearchProc Exception=" + ex.Message);
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

            trustStockResultWork = al;

            return status;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_orderListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: 2012/09/06 ������</br>
        /// <br>           : 10801804-00�A2012/09/19�z�M���APM�ێ�Č�Redmine#32179�̑Ή�</br>
        /// <br>           : �A��[�����i�������u�������čX�V�v�̋敪��I�����Ď��s���A��[���̍݌Ƀ}�X�^���V�K�쐬�����B</br>
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, TrustStockOrderCndtnWork _trustStockOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string Rep_GoodsNo;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region Select���쐬
                selectTxt += "SELECT " + Environment.NewLine;
                selectTxt += "	 STO.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "        ,STO.WAREHOUSECODERF AS TRU_WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "        ,WAR.WAREHOUSENAMERF AS TRU_WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "        ,WAR.MAINMNGWAREHOUSECDRF AS REP_WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "        ,CWAR.WAREHOUSENAMERF AS REP_WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "        ,STO.GOODSMAKERCDRF" + Environment.NewLine;
                //selectTxt += "        ,MAK.MAKERSHORTNAMERF" + Environment.NewLine;
                selectTxt += "        ,MAK.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "        ,STO.GOODSNORF" + Environment.NewLine;
                selectTxt += "        ,GOD.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "        ,STO.WAREHOUSESHELFNORF AS TRU_WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "        ,STO.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "        ,STO.SHIPMENTPOSCNTRF AS TRU_SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "        ,(STO.MAXIMUMSTOCKCNTRF - STO.SHIPMENTPOSCNTRF) AS REPLENISHCOUNTRF" + Environment.NewLine;
                selectTxt += "        ,RSTO.WAREHOUSESHELFNORF AS REP_WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "        ,RSTO.SHIPMENTPOSCNTRF AS REP_SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "        ,RSTO.GOODSNORF AS REPGOODSNORF" + Environment.NewLine;
                selectTxt += " FROM WAREHOUSERF AS WAR" + Environment.NewLine;
                selectTxt += "LEFT JOIN STOCKRF AS STO" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "	STO.ENTERPRISECODERF = WAR.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	AND STO.WAREHOUSECODERF = WAR.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN GOODSURF AS GOD" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "	GOD.ENTERPRISECODERF = STO.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	AND GOD.GOODSMAKERCDRF = STO.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "	AND GOD.GOODSNORF = STO.GOODSNORF" + Environment.NewLine;
                selectTxt += "LEFT JOIN MAKERURF MAK" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "	MAK.ENTERPRISECODERF = STO.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	AND MAK.GOODSMAKERCDRF = STO.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "LEFT JOIN STOCKRF AS RSTO" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "  RSTO.ENTERPRISECODERF = WAR.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND RSTO.WAREHOUSECODERF = WAR.MAINMNGWAREHOUSECDRF" + Environment.NewLine;
                selectTxt += "  AND RSTO.GOODSNORF = STO.GOODSNORF" + Environment.NewLine;
                selectTxt += "  AND RSTO.GOODSMAKERCDRF = STO.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  AND RSTO.LOGICALDELETECODERF = 0" + Environment.NewLine;// ADD 2012/09/06 ������ for Redmine#32179 
                selectTxt += "LEFT JOIN WAREHOUSERF AS CWAR" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "  CWAR.ENTERPRISECODERF = RSTO.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND CWAR.WAREHOUSECODERF = RSTO.WAREHOUSECODERF" + Environment.NewLine;
                
                //WHERE���̍쐬
                selectTxt += MakeWhereString(ref sqlCommand, _trustStockOrderCndtnWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                #endregion

                myReader = sqlCommand.ExecuteReader();  
                
                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    TrustStockResultWork wkTrustStockResultWork = new TrustStockResultWork();
                    
                    //�i�[����
                    wkTrustStockResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkTrustStockResultWork.Tru_WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRU_WAREHOUSECODERF"));
                    wkTrustStockResultWork.Tru_WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRU_WAREHOUSENAMERF"));
                    wkTrustStockResultWork.Rep_WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("REP_WAREHOUSECODERF"));
                    wkTrustStockResultWork.Rep_WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("REP_WAREHOUSENAMERF"));
                    wkTrustStockResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    //wkTrustStockResultWork.MakerShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERSHORTNAMERF"));
                    wkTrustStockResultWork.MakerShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    wkTrustStockResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkTrustStockResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkTrustStockResultWork.Tru_WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRU_WAREHOUSESHELFNORF"));
                    wkTrustStockResultWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                    wkTrustStockResultWork.Tru_ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TRU_SHIPMENTPOSCNTRF"));
                    if (_trustStockOrderCndtnWork.ReplenishLackStock == 2)
                    {
                        //wkTrustStockResultWork.ReplenishCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("REP_SHIPMENTPOSCNTRF"));//DEL ������ 2012/09/06 for Redmine#32179
                        //--- ADD ������ 2012/09/06 for Redmine#32179-------->>>>>
                        double repShipmentpOsCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("REP_SHIPMENTPOSCNTRF"));
                        double repPlenishCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("REPLENISHCOUNTRF"));
                        wkTrustStockResultWork.ReplenishCount = repShipmentpOsCnt <= repPlenishCount ? repShipmentpOsCnt : repPlenishCount;
                        //--- ADD ������ 2012/09/06 for Redmine#32179--------<<<<<
                    }
                    else
                    {
                        wkTrustStockResultWork.ReplenishCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("REPLENISHCOUNTRF"));
                    }
                    wkTrustStockResultWork.Rep_WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("REP_WAREHOUSESHELFNORF"));
                    wkTrustStockResultWork.Rep_ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("REP_SHIPMENTPOSCNTRF"));
                    wkTrustStockResultWork.ReplenishNStockCount = wkTrustStockResultWork.Rep_ShipmentPosCnt - wkTrustStockResultWork.ReplenishCount;
                    Rep_GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("REPGOODSNORF"));
                    //if (Rep_GoodsNo == " ")// DEL 2012/09/06 ������ for Redmine#32179 
                    if (string.IsNullOrEmpty(Rep_GoodsNo))// ADD 2012/09/06 ������ for Redmine#32179 
                    {
                        wkTrustStockResultWork.GoodsFlg = 1;
                    }
                    #endregion

                    al.Add(wkTrustStockResultWork);

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
                base.WriteErrorLog(ex, "TrustStockOrderWorkDB.SearchOrderProc Exception=" + ex.Message);
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
        /// <param name="_orderListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Update Note: �ϑ��݌ɕ�[�����̏�Q�C��</br>
        /// <br>             �{�w�C��</br>          
        /// <br>Data: 2010/12/03</br>  
        /// <br>Update Note: 2012/09/06 ������</br>
        /// <br>           : 10801804-00�A2012/09/19�z�M���APM�ێ�Č�Redmine#32179�̑Ή�</br>
        /// <br>           : �@�ϑ��݌ɕ�[�����ɂŘ_���폜���Ă����q�Ƀf�[�^�������ΏۊO�ɉ��C���܂�</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, TrustStockOrderCndtnWork _trustStockOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = "WHERE" + Environment.NewLine;

            // ��Ǒq�ɃR�[�h
            retstring += "WAR.MAINMNGWAREHOUSECDRF != 0" + Environment.NewLine;

            // �ō��݌ɐ� �� �Œ�݌ɐ�
            retstring += " AND STO.MAXIMUMSTOCKCNTRF >= STO.MINIMUMSTOCKCNTRF" + Environment.NewLine;

            // �ō��݌ɐ� �� ���݌ɐ�
            retstring += " AND STO.MAXIMUMSTOCKCNTRF > STO.SHIPMENTPOSCNTRF" + Environment.NewLine;

            // �ō��݌ɐ� = �Œ�݌ɐ� �� 0
            // --- UPD 2010/12/03------ >>>>>>
            // retstring += " AND ((STO.MAXIMUMSTOCKCNTRF != 0) AND (STO.MINIMUMSTOCKCNTRF != 0))" + Environment.NewLine;
            retstring += " AND ((STO.MAXIMUMSTOCKCNTRF != 0) OR (STO.MINIMUMSTOCKCNTRF != 0))" + Environment.NewLine;
            // --- UPD 2010/12/03----- <<<<<<<
            // ��[�� > 0
            //retstring += " AND (RSTO.SHIPMENTPOSCNTRF > 0) AND  ((STO.MAXIMUMSTOCKCNTRF - STO.SHIPMENTPOSCNTRF) > RSTO.SHIPMENTPOSCNTRF)";

            
            // ��ƃR�[�h
            retstring += " AND STO.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_trustStockOrderCndtnWork.EnterpriseCode);
            

            // �q�ɃR�[�h
            if (_trustStockOrderCndtnWork.St_WarehouseCode != "")
            {
                retstring += " AND WAR.WAREHOUSECODERF>=@STWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_trustStockOrderCndtnWork.St_WarehouseCode);
            }
            if (_trustStockOrderCndtnWork.Ed_WarehouseCode != "")
            {
                retstring += " AND WAR.WAREHOUSECODERF<=@EDWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_trustStockOrderCndtnWork.Ed_WarehouseCode);
            }


            // ���[�J�[
            if (_trustStockOrderCndtnWork.St_GoodsMakerCd != 0)
            {
                retstring += " AND STO.GOODSMAKERCDRF>=@STGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_trustStockOrderCndtnWork.St_GoodsMakerCd);
            }
            if (_trustStockOrderCndtnWork.Ed_GoodsMakerCd != 0)
            {
                retstring += " AND STO.GOODSMAKERCDRF<=@EDGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_trustStockOrderCndtnWork.Ed_GoodsMakerCd);
            }


            // �i��
            if (_trustStockOrderCndtnWork.St_GoodsNo != "")
            {
                retstring += " AND GOD.GOODSNORF>=@STGOODSNO" + Environment.NewLine;
                SqlParameter paraStGoodsNo = sqlCommand.Parameters.Add("@STGOODSNO", SqlDbType.NChar);
                paraStGoodsNo.Value = SqlDataMediator.SqlSetString(_trustStockOrderCndtnWork.St_GoodsNo);
            }
            if (_trustStockOrderCndtnWork.Ed_GoodsNo != "")
            {
                retstring += " AND GOD.GOODSNORF<=@EDGOODSNO" + Environment.NewLine;
                SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@EDGOODSNO", SqlDbType.NChar);
                paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_trustStockOrderCndtnWork.Ed_GoodsNo);
            }


            // ��[���݌ɕs����
            if (_trustStockOrderCndtnWork.ReplenishLackStock == 0 && _trustStockOrderCndtnWork.ReplenishNoneGoods !=1)
            {
                retstring += " AND ((RSTO.GOODSNORF IS NOT NULL) AND (RSTO.SHIPMENTPOSCNTRF > (STO.MAXIMUMSTOCKCNTRF - STO.SHIPMENTPOSCNTRF)))";
            }
            else if (_trustStockOrderCndtnWork.ReplenishLackStock == 2)
            {
                //retstring += " AND (RSTO.SHIPMENTPOSCNTRF > 0) AND (RSTO.SHIPMENTPOSCNTRF <= (STO.MAXIMUMSTOCKCNTRF - STO.SHIPMENTPOSCNTRF))";//DEL ������ 2012/09/06 for Redmine#32179
                retstring += " AND (RSTO.SHIPMENTPOSCNTRF > 0)";//ADD ������ 2012/09/06 for Redmine#32179
            }

            // ��[�����i������
            if (_trustStockOrderCndtnWork.ReplenishNoneGoods == 0)
            {
                retstring += " AND (RSTO.GOODSNORF IS NOT NULL)";
            }
            //--- ADD ������ 2012/09/06 for Redmine#32179-------->>>>>
            //�_���폜�敪 = 0
            retstring += " AND WAR.LOGICALDELETECODERF = @FINDLOGICALDELETECODE AND STO.LOGICALDELETECODERF = @FINDLOGICALDELETECODE";
            SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);
            //--- ADD ������ 2012/09/06 for Redmine#32179--------<<<<<

            #endregion
            return retstring;
        }
    }
}
