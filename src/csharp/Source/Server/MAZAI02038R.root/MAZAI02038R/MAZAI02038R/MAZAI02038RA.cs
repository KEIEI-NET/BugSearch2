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
    /// �݌ɁE�q�Ɉړ��m�F�\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌ɁE�q�Ɉړ��m�F�\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22035 �O�� �O��</br>
    /// <br>Date       : 2007.03.14</br>
    /// <br></br>
    /// <br>Update Note: 2007.09.11 ���� DC.NS�p�ɏC��</br>
	/// <br></br>
	/// <br>Update Note: 2008.03.26 ���X�� ��</br>
	/// <br>           : ���i�R�[�h�̍i�荞�݂��C��</br>
    /// <br></br>
    /// <br>Update Note: 2008.07.07 20081</br>
    /// <br>           : �o�l.�m�r�p�ɕύX</br>
    /// <br>Update Note: 2012/11/06 �e�c ���V</br>
    /// <br>           : �d�l�ύX�Ή��i�o�ɒǉ��j</br>
    /// <br>Update Note: 2013/01/05 cheq</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 2013/03/13�z�M��</br>
    /// <br>             Redmine#33828 ���s�^�C�v�ɂ��Ă̑Ή�</br>
    /// </remarks>
    [Serializable]
    public class StockMoveListWorkDB : RemoteDB, IStockMoveListWorkDB
    {
        /// <summary>
        /// �݌ɁE�q�Ɉړ��m�F�\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.03.14</br>
        /// </remarks>
        public StockMoveListWorkDB()
            :
        base("MAZAI02036D", "Broadleaf.Application.Remoting.ParamData.StockMoveListResultWork", "STOCKMOVERF") //���N���X�̃R���X�g���N�^
        {
        }

        #region �݌Ɉړ��m�F�\����
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̍݌Ɉړ��m�F�\LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="stockMoveListResultWork">��������</param>
        /// <param name="stockMoveListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̍݌Ɉړ��m�F�\LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.03.14</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.11 ���� DC.NS�p�ɏC��</br>
        public int SearchStock(out object stockMoveListResultWork, object stockMoveListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            stockMoveListResultWork = null;

            StockMoveListCndtnWork _stockMoveListCndtnWork = stockMoveListCndtnWork as StockMoveListCndtnWork;

            try
            {
                status = SearchStockProc(out stockMoveListResultWork, _stockMoveListCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMoveListWorkDB.SearchStock Exception=" + ex.Message);
                stockMoveListResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̍݌Ɉړ��m�F�\LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="stockMoveListResultWork">��������</param>
        /// <param name="_stockMoveListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̍݌Ɉړ��m�F�\LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.03.14</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.11 ���� DC.NS�p�ɏC��</br>
        private int SearchStockProc(out object stockMoveListResultWork, StockMoveListCndtnWork _stockMoveListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //SqlEncryptInfo sqlEncryptInfo = null;

            stockMoveListResultWork = null;

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

                ////���Í������i��������
                //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF"});
                ////�Í����L�[OPEN�iSQLException�̉\���L��j
                //sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                status = SearchNonGrossAction(ref al, ref sqlConnection, _stockMoveListCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMoveListWorkDB.SearchStockProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    //�Í����L�[�N���[�Y
                    //if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            stockMoveListResultWork = al;

            return status;
        }
        #endregion

        #region �q�Ɉړ��m�F�\����
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̑q�Ɉړ��m�F�\LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="stockMoveListResultWork">��������</param>
        /// <param name="stockMoveListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̑q�Ɉړ��m�F�\LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.03.14</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.11 ���� DC.NS�p�ɏC��</br>
        public int SearchEnterWareh(out object stockMoveListResultWork, object stockMoveListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            stockMoveListResultWork = null;

            StockMoveListCndtnWork _stockMoveListCndtnWork = stockMoveListCndtnWork as StockMoveListCndtnWork;

            try
            {
                status = SearchEnterWarehProc(out stockMoveListResultWork, _stockMoveListCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMoveListWorkDB.SearchEnterWareh Exception=" + ex.Message);
                stockMoveListResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̑q�Ɉړ��m�F�\LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="stockMoveListResultWork">�������ʁi�����j</param>
        /// <param name="depsitAlwcListResultWork">�������ʁi�����j</param>
        /// <param name="_stockMoveListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̑q�Ɉړ��m�F�\LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.03.14</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.11 ���� DC.NS�p�ɏC��</br>
        private int SearchEnterWarehProc(out object stockMoveListResultWork, StockMoveListCndtnWork _stockMoveListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //SqlEncryptInfo sqlEncryptInfo = null;

            stockMoveListResultWork = null;

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

                //���Í������i��������
                //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF" });
                //�Í����L�[OPEN�iSQLException�̉\���L��j
                //sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                status = SearchNonGrossAction(ref al, ref sqlConnection, _stockMoveListCndtnWork, logicalMode);
            
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMoveListWorkDB.SearchEnterWarehProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    //�Í����L�[�N���[�Y
                    //if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            stockMoveListResultWork = al;

            return status;
        }
        #endregion

        #region ���ԃf�[�^�擾����
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_stockMoveListCndtnWork">���������i�[�N���X</param>
        /// <param name="_productNumberOutPutDiv">���Ԓ��o�敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        private int SearchNonGrossAction(ref ArrayList al, ref SqlConnection sqlConnection, StockMoveListCndtnWork _stockMoveListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string SelectDm = "";

                #region Select���쐬
                SelectDm += "SELECT" + Environment.NewLine; 
                SelectDm += "     STM.BFSECTIONCODERF" + Environment.NewLine;
                SelectDm += "    ,STM.BFSECTIONGUIDESNMRF" + Environment.NewLine;
                SelectDm += "    ,STM.BFENTERWAREHCODERF" + Environment.NewLine;
                SelectDm += "    ,STM.BFENTERWAREHNAMERF" + Environment.NewLine;
                SelectDm += "    ,STM.BFSHELFNORF" + Environment.NewLine;
                SelectDm += "    ,STM.SHIPMENTSCDLDAYRF" + Environment.NewLine;
                SelectDm += "    ,STM.SHIPMENTFIXDAYRF" + Environment.NewLine;
                SelectDm += "    ,STM.ARRIVALGOODSDAYRF" + Environment.NewLine;
                SelectDm += "    ,STM.STOCKMOVESLIPNORF" + Environment.NewLine;
                SelectDm += "    ,STM.STOCKMOVEROWNORF" + Environment.NewLine;
                SelectDm += "    ,STM.AFSECTIONCODERF" + Environment.NewLine;
                SelectDm += "    ,STM.AFSECTIONGUIDESNMRF" + Environment.NewLine;
                SelectDm += "    ,STM.AFENTERWAREHCODERF" + Environment.NewLine;
                SelectDm += "    ,STM.AFENTERWAREHNAMERF" + Environment.NewLine;
                SelectDm += "    ,STM.AFSHELFNORF" + Environment.NewLine;
                SelectDm += "    ,STM.GOODSNORF" + Environment.NewLine;
                SelectDm += "    ,STM.GOODSNAMERF" + Environment.NewLine;
                SelectDm += "    ,STM.LISTPRICEFLRF" + Environment.NewLine;
                SelectDm += "    ,STM.STOCKUNITPRICEFLRF" + Environment.NewLine;
                SelectDm += "    ,STM.MOVECOUNTRF" + Environment.NewLine;
                SelectDm += "    ,STM.INPUTDAYRF" + Environment.NewLine;
                SelectDm += "    ,STM.GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += "    ,STM.MAKERNAMERF" + Environment.NewLine;
                SelectDm += "    ,STM.BLGOODSCODERF" + Environment.NewLine;
                SelectDm += "    ,STM.BLGOODSFULLNAMERF" + Environment.NewLine;
                SelectDm += "    ,STM.GOODSNAMEKANARF" + Environment.NewLine;
                SelectDm += "    ,STM.SUPPLIERCDRF" + Environment.NewLine;
                SelectDm += "    ,STM.SUPPLIERSNMRF" + Environment.NewLine;
                SelectDm += "    ,STM.WAREHOUSENOTE1RF" + Environment.NewLine;
                //SelectDm += "    ,STM.WAREHOUSENOTE2RF" + Environment.NewLine;  //2008.10.07 DEL
                SelectDm += "    ,STM.OUTLINERF" + Environment.NewLine;
                SelectDm += "    ,STM.TAXATIONDIVCDRF" + Environment.NewLine;
                SelectDm += "    ,STM.SLIPPRINTFINISHCDRF" + Environment.NewLine;
                SelectDm += "    ,STM.STOCKMOVEPRICERF" + Environment.NewLine;
                SelectDm += "    ,STM.STOCKMOVEFORMALRF" + Environment.NewLine;
                SelectDm += " FROM STOCKMOVERF AS STM" + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(SelectDm, sqlConnection);

                //WHERE���̍쐬
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, _stockMoveListCndtnWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    StockMoveListResultWork wkStockMoveListResultWork = new StockMoveListResultWork();

                    //�݌Ɉړ��f�[�^�i�[����
                    wkStockMoveListResultWork.BfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONCODERF"));
                    wkStockMoveListResultWork.BfSectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONGUIDESNMRF"));
                    wkStockMoveListResultWork.BfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHCODERF"));
                    wkStockMoveListResultWork.BfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHNAMERF"));
                    wkStockMoveListResultWork.BfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSHELFNORF"));
                    wkStockMoveListResultWork.ShipmentScdlDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTSCDLDAYRF"));
                    wkStockMoveListResultWork.ShipmentFixDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTFIXDAYRF"));
                    wkStockMoveListResultWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
                    wkStockMoveListResultWork.StockMoveSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVESLIPNORF"));
                    wkStockMoveListResultWork.StockMoveRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEROWNORF"));
                    wkStockMoveListResultWork.AfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONCODERF"));
                    wkStockMoveListResultWork.AfSectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONGUIDESNMRF"));
                    wkStockMoveListResultWork.AfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHCODERF"));
                    wkStockMoveListResultWork.AfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHNAMERF"));
                    wkStockMoveListResultWork.AfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSHELFNORF"));
                    wkStockMoveListResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkStockMoveListResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkStockMoveListResultWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICEFLRF"));
                    wkStockMoveListResultWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    wkStockMoveListResultWork.MoveCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVECOUNTRF"));
                    wkStockMoveListResultWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
                    wkStockMoveListResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkStockMoveListResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    wkStockMoveListResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    wkStockMoveListResultWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                    wkStockMoveListResultWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                    wkStockMoveListResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    wkStockMoveListResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    wkStockMoveListResultWork.WarehouseNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENOTE1RF"));
                    //wkStockMoveListResultWork.WarehouseNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENOTE2RF"));  //2008.10.07 DEL
                    wkStockMoveListResultWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                    wkStockMoveListResultWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
                    wkStockMoveListResultWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));
                    wkStockMoveListResultWork.StockMovePrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKMOVEPRICERF"));
                    wkStockMoveListResultWork.StockMoveFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEFORMALRF"));

                    /*
                    if (wkStockMoveListResultWork.StockDiv == 0)
                    {
                        wkStockMoveListResultWork.MovingSupliStock = 1;
                    }
                    else
                    {
                        wkStockMoveListResultWork.MovingTrustStock = 1;
                    }

                    wkStockMoveListResultWork.MovingTotalStock = 1;
                    */ 
                    #endregion

                    al.Add(wkStockMoveListResultWork);

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
                base.WriteErrorLog(ex, "StockMoveListWorkDB.SearchNonGrossAction Exception=" + ex.Message);
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
        /// <param name="_stockMoveListCndtnWork">���������i�[�N���X</param>
        /// <param name="_productNumberOutPutDiv">���Ԓ��o�敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <remarks>
        /// <br>Update Note : 2013/01/05 cheq</br>
        /// <br>�Ǘ��ԍ�    : 2013/03/13�z�M��</br>
        /// <br>              Redmine#33828 ���s�^�C�v�ɂ��Ă̑Ή�</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockMoveListCndtnWork _stockMoveListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = "WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " STM.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.EnterpriseCode);

            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND STM.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine; 
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND STM.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            // 2008.07.07 del start ------------------------------------------->> 
            ////�݌Ɉړ��`�[�ԍ��ݒ�
            //if (_stockMoveListCndtnWork.St_StockMoveSlipNo != 0)
            //{
            //    retstring += " AND STM.STOCKMOVESLIPNORF>=@STSTOCKMOVESLIPNO" + Environment.NewLine;
            //    SqlParameter paraStStockMoveSlipNo = sqlCommand.Parameters.Add("@STSTOCKMOVESLIPNO", SqlDbType.Int);
            //    paraStStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(_stockMoveListCndtnWork.St_StockMoveSlipNo);
            //}
            //if (_stockMoveListCndtnWork.Ed_StockMoveSlipNo != 999999999)
            //{
            //    retstring += " AND STM.STOCKMOVESLIPNORF<=@EDSTOCKMOVESLIPNO" + Environment.NewLine;
            //    SqlParameter paraEdStockMoveSlipNo = sqlCommand.Parameters.Add("@EDSTOCKMOVESLIPNO", SqlDbType.Int);
            //    paraEdStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(_stockMoveListCndtnWork.Ed_StockMoveSlipNo);
            //}
            ////���[�J�[�R�[�h�ݒ�
            //if (_stockMoveListCndtnWork.St_GoodsMakerCd != 0)
            //{
            //    retstring += " AND STM.GOODSMAKERCDRF>=@STGOODSMAKERCD" + Environment.NewLine;
            //    SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
            //    paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockMoveListCndtnWork.St_GoodsMakerCd);
            //}
            //if (_stockMoveListCndtnWork.Ed_GoodsMakerCd != 999999)
            //{
            //    retstring += " AND STM.GOODSMAKERCDRF<=@EDGOODSMAKERCD" + Environment.NewLine;
            //    SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
            //    paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockMoveListCndtnWork.Ed_GoodsMakerCd);
            //}
            ////���i�ԍ��ݒ�
            //if (_stockMoveListCndtnWork.St_GoodsNo != "")
            //{
            //    retstring += " AND STM.GOODSNORF>=@STGOODSNO" + Environment.NewLine;
            //    SqlParameter paraStGoodsCd = sqlCommand.Parameters.Add("@STGOODSNO", SqlDbType.NVarChar);
            //    paraStGoodsCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.St_GoodsNo);
            //}
            //if (_stockMoveListCndtnWork.Ed_GoodsNo != "")
            //{
            //    retstring += " AND (STM.GOODSNORF<=@EDGOODSNO OR STM.GOODSNORF LIKE @EDGOODSNO)" + Environment.NewLine;
            //    SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@EDGOODSNO", SqlDbType.NVarChar);
            //    // 2008.03.26 >>
            //    //paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_GoodsNo + "%");
            //    paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_GoodsNo);
            //    // 2008.03.26 <<
            //}
            // 2008.07.07 del end ---------------------------------------------<<

            // 2008.07.07 add start ------------------------------------------->>
            //�J�n���͓��t
            if (_stockMoveListCndtnWork.St_CreateDate != DateTime.MinValue)
            {
                retstring += " AND STM.INPUTDAYRF >= @STINPUTDAY" + Environment.NewLine;
                SqlParameter paraStInputDay = sqlCommand.Parameters.Add("@STINPUTDAY", SqlDbType.Int);
                paraStInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_stockMoveListCndtnWork.St_CreateDate);

            }
            //�I�����͓��t
            if (_stockMoveListCndtnWork.Ed_CreateDate != DateTime.MinValue)
            {
                if (_stockMoveListCndtnWork.St_CreateDate == DateTime.MinValue)
                {
                    retstring += " AND (STM.INPUTDAYRF IS NULL OR";
                }
                else
                {
                    retstring += " AND (";
                }

                retstring += " STM.INPUTDAYRF <= @EDINPUTDAY)" + Environment.NewLine;
                SqlParameter paraEdInputDay = sqlCommand.Parameters.Add("@EDINPUTDAY", SqlDbType.Int);
                paraEdInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_stockMoveListCndtnWork.Ed_CreateDate);
            }

            /*
            //�ړ����
            retstring += " AND STM.MOVESTATUSRF IN (";
            //���s�^�C�v �u�o�Ɂv���u�S�āv�̏ꍇ
            if (_stockMoveListCndtnWork.PrintType == 0 || _stockMoveListCndtnWork.PrintType == -1)
            {
                retstring += "1,2";
            }
            //���s�^�C�v �u���Ɂv���u�S�āv�̏ꍇ
            if (_stockMoveListCndtnWork.PrintType == 1 || _stockMoveListCndtnWork.PrintType == -1)
            {
                if ( _stockMoveListCndtnWork.PrintType == -1)
                {
                    retstring += ",";
                }
                retstring += "9";
            }
            retstring += ")" + Environment.NewLine;
            */

            //���s�^�C�v
            // --- UPD 2012/11/06 Y.Wakita ---------->>>>>
            //if (_stockMoveListCndtnWork.PrintType == 0)
            if ((_stockMoveListCndtnWork.PrintType == 0) || (_stockMoveListCndtnWork.PrintType == 2))
            // --- UPD 2012/11/06 Y.Wakita ----------<<<<<
            {
                //���s�^�C�v �u�o�Ɂv���u�S�āv�̏ꍇ�A�o�׊m������Z�b�g����Ă���f�[�^��ΏۂƂ���
                retstring += " AND NOT(STM.SHIPMENTFIXDAYRF IS NULL OR STM.SHIPMENTFIXDAYRF=0)" + Environment.NewLine;
            }
            else if (_stockMoveListCndtnWork.PrintType == 1)
            {
                //���s�^�C�v�u���Ɂv�̏ꍇ�A���ד����Z�b�g����Ă���f�[�^��ΏۂƂ���
                retstring += " AND NOT(STM.ARRIVALGOODSDAYRF IS NULL OR STM.ARRIVALGOODSDAYRF=0)" + Environment.NewLine;
            }
            else if (_stockMoveListCndtnWork.PrintType == -1)
            {
                //retstring += " AND (NOT(STM.SHIPMENTFIXDAYRF IS NULL OR STM.SHIPMENTFIXDAYRF=0) AND NOT(STM.ARRIVALGOODSDAYRF IS NULL OR STM.ARRIVALGOODSDAYRF=0))" + Environment.NewLine;// DEL cheq 2013/01/05  Redmine#33828
                retstring += " AND (NOT(STM.SHIPMENTFIXDAYRF IS NULL OR STM.SHIPMENTFIXDAYRF=0) OR NOT(STM.ARRIVALGOODSDAYRF IS NULL OR STM.ARRIVALGOODSDAYRF=0))" + Environment.NewLine;// ADD cheq 2013/01/05  Redmine#33828
            }
            
            //�J�n�Ώۓ��t
            if (_stockMoveListCndtnWork.St_ShipArrivalDate != DateTime.MinValue)
            {
                //���s�^�C�v �u�o�Ɂv���u�S�āv�̏ꍇ
                // --- UPD 2012/11/06 Y.Wakita ---------->>>>>
                //if (_stockMoveListCndtnWork.PrintType == 0)
                if ((_stockMoveListCndtnWork.PrintType == 0) || (_stockMoveListCndtnWork.PrintType == 2))
                // --- UPD 2012/11/06 Y.Wakita ----------<<<<<
                {
                    retstring += " AND STM.SHIPMENTFIXDAYRF >= @STSHIPARRIVALDATE" + Environment.NewLine;
                }
                //���s�^�C�v �u���Ɂv�̏ꍇ
                if (_stockMoveListCndtnWork.PrintType == 1)
                {
                    retstring += " AND STM.ARRIVALGOODSDAYRF >= @STSHIPARRIVALDATE" + Environment.NewLine;
                }
                if (_stockMoveListCndtnWork.PrintType == -1)
                {
                    retstring += " AND (STM.SHIPMENTFIXDAYRF >= @STSHIPARRIVALDATE OR STM.ARRIVALGOODSDAYRF >= @STSHIPARRIVALDATE)" + Environment.NewLine;
                }

                SqlParameter paraStShipArrivalDate = sqlCommand.Parameters.Add("@STSHIPARRIVALDATE", SqlDbType.Int);
                paraStShipArrivalDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_stockMoveListCndtnWork.St_ShipArrivalDate);

            }

            //�I���Ώۓ��t
            if (_stockMoveListCndtnWork.Ed_ShipArrivalDate != DateTime.MinValue)
            {
                //���s�^�C�v �u�o�Ɂv���u�S�āv�̏ꍇ
                // --- UPD 2012/11/06 Y.Wakita ---------->>>>>
                //if (_stockMoveListCndtnWork.PrintType == 0)
                if ((_stockMoveListCndtnWork.PrintType == 0) || (_stockMoveListCndtnWork.PrintType == 2))
                // --- UPD 2012/11/06 Y.Wakita ----------<<<<<
                {
                    retstring += " AND STM.SHIPMENTFIXDAYRF <= @EDSHIPARRIVALDATE" + Environment.NewLine;
                }

                //���s�^�C�v �u���Ɂv�̏ꍇ
                if (_stockMoveListCndtnWork.PrintType == 1)
                {
                    retstring += " AND STM.ARRIVALGOODSDAYRF <= @EDSHIPARRIVALDATE" + Environment.NewLine;
                }

                if (_stockMoveListCndtnWork.PrintType == -1)
                {
                    retstring += " AND (STM.SHIPMENTFIXDAYRF <= @EDSHIPARRIVALDATE OR STM.ARRIVALGOODSDAYRF <= @EDSHIPARRIVALDATE)" + Environment.NewLine;
                }

                SqlParameter paraEdShipArrivalDate = sqlCommand.Parameters.Add("@EDSHIPARRIVALDATE", SqlDbType.Int);
                paraEdShipArrivalDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_stockMoveListCndtnWork.Ed_ShipArrivalDate);
            }

            //���_�R�[�h
            if (_stockMoveListCndtnWork.BfAfSectionCd != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _stockMoveListCndtnWork.BfAfSectionCd)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }

                if (sectionCodestr != "")
                {   
                    //�o�ɂ̂�
                    // --- UPD 2012/11/06 Y.Wakita ---------->>>>>
                    //if (_stockMoveListCndtnWork.PrintType == 0)
                    if ((_stockMoveListCndtnWork.PrintType == 0) || (_stockMoveListCndtnWork.PrintType == 2))
                    // --- UPD 2012/11/06 Y.Wakita ----------<<<<<
                    {
                        //�ړ������_�R�[�h
                        retstring += " AND STM.BFSECTIONCODERF IN (" + sectionCodestr + ") ";
                    }
                    else
                    //���ɂ̂�
                    if (_stockMoveListCndtnWork.PrintType == 1)
                    {
                        //�ړ��拒�_�R�[�h
                        retstring += " AND STM.AFSECTIONCODERF IN (" + sectionCodestr + ") ";
                    }
                    else
                    //�S��
                    if (_stockMoveListCndtnWork.PrintType == -1)
                    {
                        retstring += " AND (STM.BFSECTIONCODERF IN (" + sectionCodestr + ")  OR STM.AFSECTIONCODERF IN (" + sectionCodestr + ") )";
                    }
                }
                retstring += Environment.NewLine;
            }

            //�ړ����q�ɃR�[�h�ݒ�
            if (_stockMoveListCndtnWork.St_MainBfAfEnterWarehCd != "")
            {
                retstring += " AND STM.BFENTERWAREHCODERF>=@STBFENTERWAREHCODE" + Environment.NewLine;
                SqlParameter paraStMainBfAfEnterWarehCd = sqlCommand.Parameters.Add("@STBFENTERWAREHCODE", SqlDbType.NChar);
                paraStMainBfAfEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.St_MainBfAfEnterWarehCd);
            }
            if (_stockMoveListCndtnWork.Ed_MainBfAfEnterWarehCd != "")
            {
                retstring += " AND STM.BFENTERWAREHCODERF<=@EDBFENTERWAREHCODE" + Environment.NewLine;
                SqlParameter paraEdMainBfAfEnterWarehCd = sqlCommand.Parameters.Add("@EDBFENTERWAREHCODE", SqlDbType.NChar);
                paraEdMainBfAfEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_MainBfAfEnterWarehCd);
            }

            //�ړ���q�ɃR�[�h�ݒ�
            if (_stockMoveListCndtnWork.St_ShipArrivalEnterWarehCd != "")
            {
                retstring += " AND STM.AFENTERWAREHCODERF>=@STAFENTERWAREHCODE" + Environment.NewLine;
                SqlParameter paraStShipArrivalEnterWarehCd = sqlCommand.Parameters.Add("@STAFENTERWAREHCODE", SqlDbType.NChar);
                paraStShipArrivalEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.St_ShipArrivalEnterWarehCd);
            }
            if (_stockMoveListCndtnWork.Ed_ShipArrivalEnterWarehCd != "")
            {
                retstring += " AND STM.AFENTERWAREHCODERF<=@EDAFENTERWAREHCODE" + Environment.NewLine;
                SqlParameter paraEdShipArrivalEnterWarehCd = sqlCommand.Parameters.Add("@EDAFENTERWAREHCODE", SqlDbType.NChar);
                paraEdShipArrivalEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_ShipArrivalEnterWarehCd);
            }

            //�o�͎w��
            if (_stockMoveListCndtnWork.OutputDesignat != -1)
            {
                if (_stockMoveListCndtnWork.OutputDesignat == 0)
                {
                    retstring += " AND STM.SLIPPRINTFINISHCDRF=0" + Environment.NewLine;
                }
                else if (_stockMoveListCndtnWork.OutputDesignat == 1)
                {
                    retstring += " AND STM.SLIPPRINTFINISHCDRF=1" + Environment.NewLine;
                }
            }
            // 2008.07.07 add end --------------------------------------------<<

            //�݌Ɉړ����͏]�ƈ��R�[�h�ݒ�
            if (_stockMoveListCndtnWork.St_StockMvEmpCode != "")
            {
                retstring += " AND STM.STOCKMVEMPCODERF>=@STSTOCKMVEMPCODE" + Environment.NewLine;
                SqlParameter paraStStockMvEmpCd = sqlCommand.Parameters.Add("@STSTOCKMVEMPCODE", SqlDbType.NChar);
                paraStStockMvEmpCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.St_StockMvEmpCode);
            }
            if (_stockMoveListCndtnWork.Ed_StockMvEmpCode != "")
            {
                if (_stockMoveListCndtnWork.St_StockMvEmpCode == "")
                {
                    retstring += " AND (STM.STOCKMVEMPCODERF IS NULL OR";
                }
                else
                {
                    retstring += " AND (";
                }

                retstring += " STM.STOCKMVEMPCODERF<=@EDSTOCKMVEMPCODE)" + Environment.NewLine;
                SqlParameter paraEdStockMvEmpCd = sqlCommand.Parameters.Add("@EDSTOCKMVEMPCODE", SqlDbType.NChar);
                paraEdStockMvEmpCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_StockMvEmpCode);
            }

            //�d����R�[�h�ݒ�
            if (_stockMoveListCndtnWork.St_SupplierCd != 0)
            {
                retstring += " AND STM.SUPPLIERCDRF>=@STSUPPLIERCD" + Environment.NewLine;
                SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@STSUPPLIERCD", SqlDbType.Int);
                paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(_stockMoveListCndtnWork.St_SupplierCd);
            }
            if (_stockMoveListCndtnWork.Ed_SupplierCd != 999999999)
            {
                retstring += " AND STM.SUPPLIERCDRF<=@EDSUPPLIERCD" + Environment.NewLine;
                SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@EDSUPPLIERCD", SqlDbType.Int);
                paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(_stockMoveListCndtnWork.Ed_SupplierCd);
            }

            // ���s�^�C�v
            // ���׊m�肠��
            if (_stockMoveListCndtnWork.StockMoveFixCode == 1)
            {
                // ������
                if (_stockMoveListCndtnWork.PrintType == 0)
                {
                    retstring += " AND (STM.STOCKMOVEFORMALRF = 1 OR STM.STOCKMOVEFORMALRF = 2) AND STM.MOVESTATUSRF = 2 ";
                }
                // ���׍�
                else if (_stockMoveListCndtnWork.PrintType == 1)
                {
                    retstring += " AND (STM.STOCKMOVEFORMALRF = 3 OR STM.STOCKMOVEFORMALRF = 4) ";
                }
                // --- ADD 2012/11/06 Y.Wakita ---------->>>>>
                // �o��
                else if (_stockMoveListCndtnWork.PrintType == 2)
                {
                    retstring += " AND (STM.STOCKMOVEFORMALRF = 1 OR STM.STOCKMOVEFORMALRF = 2) ";
                }
                // --- ADD 2012/11/06 Y.Wakita ----------<<<<<
            }

            // ���׊m��Ȃ�
            else
            {
                // �o��
                if (_stockMoveListCndtnWork.PrintType == 0)
                {
                    retstring += " AND (STM.STOCKMOVEFORMALRF = 1 OR STM.STOCKMOVEFORMALRF = 2) ";
                }
                // ����
                else if (_stockMoveListCndtnWork.PrintType == 1)
                {
                    retstring += " AND (STM.STOCKMOVEFORMALRF = 3 OR STM.STOCKMOVEFORMALRF = 4) ";
                }
            }

            #region ������Where�� (�폜)
            /*
            //�ړ��`������ 1:�݌Ɉړ��A2:�q�Ɉړ�
            if (_stockMoveListCndtnWork.StockMoveFormalDiv == 1)
            {
                #region �݌Ɉړ�Where
                //�����敪�`�� 0:���o�ׁA1:�o�׍ρA2:�����ׁA3:���׍�
                if ((_stockMoveListCndtnWork.ShipmentArrivalDiv == 0) || (_stockMoveListCndtnWork.ShipmentArrivalDiv == 1))
                {
                    #region ���o�ׁA�o�׋��ʕ���
                    //�ړ������_�R�[�h    ���z��ŕ����w�肳���
                    if (_stockMoveListCndtnWork.BfAfSectionCd != null)
                    {
                        string sectionCodestr = "";
                        foreach (string seccdstr in _stockMoveListCndtnWork.BfAfSectionCd)
                        {
                            if (sectionCodestr != "")
                            {
                                sectionCodestr += ",";
                            }
                            sectionCodestr += "'" + seccdstr + "'";
                        }

                        if (sectionCodestr != "")
                        {
                            retstring += " AND STM.BFSECTIONCODERF IN (" + sectionCodestr + ") ";
                        }
                        retstring += Environment.NewLine;
                    }

                    //�ړ����q�ɃR�[�h�ݒ�
                    if (_stockMoveListCndtnWork.St_MainBfAfEnterWarehCd != "")
                    {
                        retstring += " AND STM.BFENTERWAREHCODERF>=@STBFENTERWAREHCODE" +Environment.NewLine;
                        SqlParameter paraStMainBfAfEnterWarehCd = sqlCommand.Parameters.Add("@STBFENTERWAREHCODE", SqlDbType.NChar);
                        paraStMainBfAfEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.St_MainBfAfEnterWarehCd);
                    }
                    if (_stockMoveListCndtnWork.Ed_MainBfAfEnterWarehCd != "")
                    {
                        retstring += " AND (STM.BFENTERWAREHCODERF<=@EDBFENTERWAREHCODE OR STM.BFENTERWAREHCODERF LIKE @EDBFENTERWAREHCODE)" +Environment.NewLine;
                        SqlParameter paraEdMainBfAfEnterWarehCd = sqlCommand.Parameters.Add("@EDBFENTERWAREHCODE", SqlDbType.NChar);
                        paraEdMainBfAfEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_MainBfAfEnterWarehCd + "%");
                    }

                    //�ړ��拒�_�R�[�h�ݒ�
                    if (_stockMoveListCndtnWork.St_ShipArrivalSectionCd != "")
                    {
                        retstring += " AND STM.AFSECTIONCODERF>=@STAFSECTIONCODE" +Environment.NewLine;
                        SqlParameter paraStShipArrivalSection = sqlCommand.Parameters.Add("@STAFSECTIONCODE", SqlDbType.NChar);
                        paraStShipArrivalSection.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.St_ShipArrivalSectionCd);
                    }
                    if (_stockMoveListCndtnWork.Ed_ShipArrivalSectionCd != "")
                    {
                        retstring += " AND (STM.AFSECTIONCODERF<=@EDAFSECTIONCODE OR STM.AFSECTIONCODERF LIKE @EDAFSECTIONCODE)" + Environment.NewLine;
                        SqlParameter paraEdShipArrivalSectionCd = sqlCommand.Parameters.Add("@EDAFSECTIONCODE", SqlDbType.NChar);
                        paraEdShipArrivalSectionCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_ShipArrivalSectionCd + "%");
                    }

                    //�ړ���q�ɃR�[�h�ݒ�
                    if (_stockMoveListCndtnWork.St_ShipArrivalEnterWarehCd != "")
                    {
                        retstring += " AND STM.AFENTERWAREHCODERF>=@STAFENTERWAREHCODE" + Environment.NewLine;
                        SqlParameter paraStShipArrivalEnterWarehCd = sqlCommand.Parameters.Add("@STAFENTERWAREHCODE", SqlDbType.NChar);
                        paraStShipArrivalEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.St_ShipArrivalEnterWarehCd);
                    }
                    if (_stockMoveListCndtnWork.Ed_ShipArrivalEnterWarehCd != "")
                    {
                        retstring += " AND (STM.AFENTERWAREHCODERF<=@EDAFENTERWAREHCODE OR STM.AFENTERWAREHCODERF LIKE @EDAFENTERWAREHCODE)" + Environment.NewLine;
                        SqlParameter paraEdShipArrivalEnterWarehCd = sqlCommand.Parameters.Add("@EDAFENTERWAREHCODE", SqlDbType.NChar);
                        paraEdShipArrivalEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_ShipArrivalEnterWarehCd + "%");
                    }
                    #endregion

                    if (_stockMoveListCndtnWork.ShipmentArrivalDiv == 0)
                    {
                        #region ���o�ׂ̏ꍇ
                        //�o�ח\����ݒ�
                        if (_stockMoveListCndtnWork.St_ShipArrivalDate != DateTime.MinValue)
                        {
                            int startymd = TDateTime.DateTimeToLongDate(_stockMoveListCndtnWork.St_ShipArrivalDate);
                            retstring += " AND STM.SHIPMENTSCDLDAYRF >= " + startymd.ToString();
                            retstring += Environment.NewLine;
                        }
                        if (_stockMoveListCndtnWork.Ed_ShipArrivalDate != DateTime.MinValue)
                        {
                            if (_stockMoveListCndtnWork.St_ShipArrivalDate == DateTime.MinValue)
                            {
                                retstring += " AND (STM.SHIPMENTSCDLDAYRF IS NULL OR";
                            }
                            else
                            {
                                retstring += " AND";
                            }

                            int endymd = TDateTime.DateTimeToLongDate(_stockMoveListCndtnWork.Ed_ShipArrivalDate);
                            retstring += " STM.SHIPMENTSCDLDAYRF <= " + endymd.ToString();

                            if (_stockMoveListCndtnWork.St_ShipArrivalDate == DateTime.MinValue)
                            {
                                retstring += " ) ";
                            }
                            retstring += Environment.NewLine;
                        }
                        retstring += " AND STM.MOVESTATUSRF = 1" + Environment.NewLine;
                        #endregion
                    }
                    else
                    {
                        #region �o�׍ς̏ꍇ
                        //�o�׊m����ݒ�
                        if (_stockMoveListCndtnWork.St_ShipArrivalDate != DateTime.MinValue)
                        {
                            int startymd = TDateTime.DateTimeToLongDate(_stockMoveListCndtnWork.St_ShipArrivalDate);
                            retstring += " AND STM.SHIPMENTFIXDAYRF >= " + startymd.ToString();
                            retstring += Environment.NewLine;
                        }
                        if (_stockMoveListCndtnWork.Ed_ShipArrivalDate != DateTime.MinValue)
                        {
                            if (_stockMoveListCndtnWork.St_ShipArrivalDate == DateTime.MinValue)
                            {
                                retstring += " AND (STM.SHIPMENTFIXDAYRF IS NULL OR";
                            }
                            else
                            {
                                retstring += " AND";
                            }

                            int endymd = TDateTime.DateTimeToLongDate(_stockMoveListCndtnWork.Ed_ShipArrivalDate);
                            retstring += " STM.SHIPMENTFIXDAYRF <= " + endymd.ToString();

                            if (_stockMoveListCndtnWork.St_ShipArrivalDate == DateTime.MinValue)
                            {
                                retstring += " ) ";
                            }
                            retstring += Environment.NewLine;
                        }
                        retstring += " AND STM.MOVESTATUSRF = 2" + Environment.NewLine;
                        #endregion
                    }
                }
                else
                {
                    #region �����ׁA���׋��ʕ���
                    //�ړ��拒�_�R�[�h    ���z��ŕ����w�肳���
                    if (_stockMoveListCndtnWork.BfAfSectionCd != null)
                    {
                        string sectionCodestr = "";
                        foreach (string seccdstr in _stockMoveListCndtnWork.BfAfSectionCd)
                        {
                            if (sectionCodestr != "")
                            {
                                sectionCodestr += ",";
                            }
                            sectionCodestr += "'" + seccdstr + "'";
                        }

                        if (sectionCodestr != "")
                        {
                            retstring += " AND STM.AFSECTIONCODERF IN (" + sectionCodestr + ") ";
                        }
                        retstring += Environment.NewLine;
                    }

                    //�ړ���q�ɃR�[�h�ݒ�
                    if (_stockMoveListCndtnWork.St_MainBfAfEnterWarehCd != "")
                    {
                        retstring += " AND STM.AFENTERWAREHCODERF>=@STAFENTERWAREHCODE" + Environment.NewLine;
                        SqlParameter paraStMainBfAfEnterWarehCd = sqlCommand.Parameters.Add("@STAFENTERWAREHCODE", SqlDbType.NChar);
                        paraStMainBfAfEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.St_MainBfAfEnterWarehCd);
                    }
                    if (_stockMoveListCndtnWork.Ed_MainBfAfEnterWarehCd != "")
                    {
                        retstring += " AND (STM.AFENTERWAREHCODERF<=@EDAFENTERWAREHCODE OR STM.AFENTERWAREHCODERF LIKE @EDAFENTERWAREHCODE)" + Environment.NewLine;
                        SqlParameter paraEdMainBfAfEnterWarehCd = sqlCommand.Parameters.Add("@EDAFENTERWAREHCODE", SqlDbType.NChar);
                        paraEdMainBfAfEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_MainBfAfEnterWarehCd + "%");
                    }

                    //�ړ������_�R�[�h�ݒ�
                    if (_stockMoveListCndtnWork.St_ShipArrivalSectionCd != "")
                    {
                        retstring += " AND STM.BFSECTIONCODERF>=@STBFSECTIONCODE" + Environment.NewLine;
                        SqlParameter paraStShipArrivalSection = sqlCommand.Parameters.Add("@STBFSECTIONCODE", SqlDbType.NChar);
                        paraStShipArrivalSection.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.St_ShipArrivalSectionCd);
                    }
                    if (_stockMoveListCndtnWork.Ed_ShipArrivalSectionCd != "")
                    {
                        retstring += " AND (STM.BFSECTIONCODERF<=@EDBFSECTIONCODE OR STM.BFSECTIONCODERF LIKE @EDBFSECTIONCODE)" + Environment.NewLine;
                        SqlParameter paraEdShipArrivalSectionCd = sqlCommand.Parameters.Add("@EDBFSECTIONCODE", SqlDbType.NChar);
                        paraEdShipArrivalSectionCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_ShipArrivalSectionCd + "%");
                    }

                    //�ړ����q�ɃR�[�h�ݒ�
                    if (_stockMoveListCndtnWork.St_ShipArrivalEnterWarehCd != "")
                    {
                        retstring += " AND STM.BFENTERWAREHCODERF>=@STBFENTERWAREHCODE"  + Environment.NewLine;
                        SqlParameter paraStShipArrivalEnterWarehCd = sqlCommand.Parameters.Add("@STBFENTERWAREHCODE", SqlDbType.NChar);
                        paraStShipArrivalEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.St_ShipArrivalEnterWarehCd);
                    }
                    if (_stockMoveListCndtnWork.Ed_ShipArrivalEnterWarehCd != "")
                    {
                        retstring += " AND (STM.BFENTERWAREHCODERF<=@EDBFENTERWAREHCODE OR STM.BFENTERWAREHCODERF LIKE @EDBFENTERWAREHCODE)" + Environment.NewLine;
                        SqlParameter paraEdShipArrivalEnterWarehCd = sqlCommand.Parameters.Add("@EDBFENTERWAREHCODE", SqlDbType.NChar);
                        paraEdShipArrivalEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_ShipArrivalEnterWarehCd + "%");
                    }
                    #endregion

                    if (_stockMoveListCndtnWork.ShipmentArrivalDiv == 3)
                    {
                        #region ���׍ς̏ꍇ
                        //���ד��ݒ�
                        if (_stockMoveListCndtnWork.St_ShipArrivalDate != DateTime.MinValue)
                        {
                            int startymd = TDateTime.DateTimeToLongDate(_stockMoveListCndtnWork.St_ShipArrivalDate);
                            retstring += " AND STM.ARRIVALGOODSDAYRF >= " + startymd.ToString();
                            retstring += Environment.NewLine;
                        }
                        if (_stockMoveListCndtnWork.Ed_ShipArrivalDate != DateTime.MinValue)
                        {
                            if (_stockMoveListCndtnWork.St_ShipArrivalDate == DateTime.MinValue)
                            {
                                retstring += " AND (STM.ARRIVALGOODSDAYRF IS NULL OR";
                            }
                            else
                            {
                                retstring += " AND";
                            }

                            int endymd = TDateTime.DateTimeToLongDate(_stockMoveListCndtnWork.Ed_ShipArrivalDate);
                            retstring += " STM.ARRIVALGOODSDAYRF <= " + endymd.ToString();

                            if (_stockMoveListCndtnWork.St_ShipArrivalDate == DateTime.MinValue)
                            {
                                retstring += " ) ";
                            }
                            retstring += Environment.NewLine;
                        }

                        retstring += " AND STM.MOVESTATUSRF = 9" + Environment.NewLine;
                        #endregion
                    }
                    else
                    {
                        #region �����ׂ̏ꍇ
                        //�o�׊m����ݒ�
                        if (_stockMoveListCndtnWork.St_ShipArrivalDate != DateTime.MinValue)
                        {
                            int startymd = TDateTime.DateTimeToLongDate(_stockMoveListCndtnWork.St_ShipArrivalDate);
                            retstring += " AND STM.SHIPMENTFIXDAYRF >= " + startymd.ToString();
                            retstring += Environment.NewLine;
                        }
                        if (_stockMoveListCndtnWork.Ed_ShipArrivalDate != DateTime.MinValue)
                        {
                            if (_stockMoveListCndtnWork.St_ShipArrivalDate == DateTime.MinValue)
                            {
                                retstring += " AND (STM.SHIPMENTFIXDAYRF IS NULL OR";
                            }
                            else
                            {
                                retstring += " AND";
                            }

                            int endymd = TDateTime.DateTimeToLongDate(_stockMoveListCndtnWork.Ed_ShipArrivalDate);
                            retstring += " STM.SHIPMENTFIXDAYRF <= " + endymd.ToString();

                            if (_stockMoveListCndtnWork.St_ShipArrivalDate == DateTime.MinValue)
                            {
                                retstring += " ) ";
                            }
                            retstring += Environment.NewLine;
                        }

                        retstring += " AND STM.MOVESTATUSRF = 2" + Environment.NewLine;
                        #endregion
                    }
                }
                retstring += " AND STM.STOCKMOVEFORMALRF = 1" + Environment.NewLine;
                #endregion
            }

            else
            {
                #region �q�Ɉړ�Where ���g�p
                //�����敪�`�� 1:�o�ׁA3:����
                if (_stockMoveListCndtnWork.ShipmentArrivalDiv == 1)
                {
                    #region �o�ׂ̏ꍇ
                    //�ړ������_�R�[�h    ���z��ŕ����w�肳���
                    if (_stockMoveListCndtnWork.BfAfSectionCd != null)
                    {
                        string sectionCodestr = "";
                        foreach (string seccdstr in _stockMoveListCndtnWork.BfAfSectionCd)
                        {
                            if (sectionCodestr != "")
                            {
                                sectionCodestr += ",";
                            }
                            sectionCodestr += "'" + seccdstr + "'";
                        }

                        if (sectionCodestr != "")
                        {
                            retstring += " AND STM.BFSECTIONCODERF IN (" + sectionCodestr + ") ";
                        }

                        retstring += Environment.NewLine;
                    }

                    //�ړ����q�ɃR�[�h�ݒ�
                    if (_stockMoveListCndtnWork.St_MainBfAfEnterWarehCd != "")
                    {
                        retstring += " AND STM.BFENTERWAREHCODERF>=@STBFENTERWAREHCODE" + Environment.NewLine;
                        SqlParameter paraStMainBfAfEnterWarehCd = sqlCommand.Parameters.Add("@STBFENTERWAREHCODE", SqlDbType.NChar);
                        paraStMainBfAfEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.St_MainBfAfEnterWarehCd);
                    }
                    if (_stockMoveListCndtnWork.Ed_MainBfAfEnterWarehCd != "")
                    {
                        retstring += " AND (STM.BFENTERWAREHCODERF<=@EDBFENTERWAREHCODE OR STM.BFENTERWAREHCODERF LIKE @EDBFENTERWAREHCODE)" + Environment.NewLine;
                        SqlParameter paraEdMainBfAfEnterWarehCd = sqlCommand.Parameters.Add("@EDBFENTERWAREHCODE", SqlDbType.NChar);
                        paraEdMainBfAfEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_MainBfAfEnterWarehCd + "%");
                    }

                    //�o�׊m����ݒ�
                    if (_stockMoveListCndtnWork.St_ShipArrivalDate != DateTime.MinValue)
                    {
                        int startymd = TDateTime.DateTimeToLongDate(_stockMoveListCndtnWork.St_ShipArrivalDate);
                        retstring += " AND STM.SHIPMENTFIXDAYRF >= " + startymd.ToString();
                        retstring += Environment.NewLine;
                    }
                    if (_stockMoveListCndtnWork.Ed_ShipArrivalDate != DateTime.MinValue)
                    {
                        if (_stockMoveListCndtnWork.St_ShipArrivalDate == DateTime.MinValue)
                        {
                            retstring += " AND (STM.SHIPMENTFIXDAYRF IS NULL OR";
                        }
                        else
                        {
                            retstring += " AND";
                        }

                        int endymd = TDateTime.DateTimeToLongDate(_stockMoveListCndtnWork.Ed_ShipArrivalDate);
                        retstring += " STM.SHIPMENTFIXDAYRF <= " + endymd.ToString();

                        if (_stockMoveListCndtnWork.St_ShipArrivalDate == DateTime.MinValue)
                        {
                            retstring += " ) ";
                        }
                        retstring += Environment.NewLine;
                    }
                    retstring += " AND STM.MOVESTATUSRF = 9" + Environment.NewLine;

                    //�ړ��拒�_�R�[�h�ݒ�
                    retstring += " AND STM.AFSECTIONCODERF=STM.BFSECTIONCODERF" + Environment.NewLine;

                    //�ړ���q�ɃR�[�h�ݒ�
                    if (_stockMoveListCndtnWork.St_ShipArrivalEnterWarehCd != "")
                    {
                        retstring += " AND STM.AFENTERWAREHCODERF>=@STAFENTERWAREHCODE" + Environment.NewLine;
                        SqlParameter paraStShipArrivalEnterWarehCd = sqlCommand.Parameters.Add("@STAFENTERWAREHCODE", SqlDbType.NChar);
                        paraStShipArrivalEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.St_ShipArrivalEnterWarehCd);
                    }
                    if (_stockMoveListCndtnWork.Ed_ShipArrivalEnterWarehCd != "")
                    {
                        retstring += " AND (STM.AFENTERWAREHCODERF<=@EDAFENTERWAREHCODE OR STM.AFENTERWAREHCODERF LIKE @EDAFENTERWAREHCODE)" + Environment.NewLine;
                        SqlParameter paraEdShipArrivalEnterWarehCd = sqlCommand.Parameters.Add("@EDAFENTERWAREHCODE", SqlDbType.NChar);
                        paraEdShipArrivalEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_ShipArrivalEnterWarehCd + "%");
                    }
                    #endregion
                }
                else
                {
                    #region ���ׂ̏ꍇ
                    //�ړ��拒�_�R�[�h    ���z��ŕ����w�肳���
                    if (_stockMoveListCndtnWork.BfAfSectionCd != null)
                    {
                        string sectionCodestr = "";
                        foreach (string seccdstr in _stockMoveListCndtnWork.BfAfSectionCd)
                        {
                            if (sectionCodestr != "")
                            {
                                sectionCodestr += ",";
                            }
                            sectionCodestr += "'" + seccdstr + "'";
                        }

                        if (sectionCodestr != "")
                        {
                            retstring += " AND STM.AFSECTIONCODERF IN (" + sectionCodestr + ") ";
                        }

                        retstring += Environment.NewLine;
                    }

                    //�ړ���q�ɃR�[�h�ݒ�
                    if (_stockMoveListCndtnWork.St_MainBfAfEnterWarehCd != "")
                    {
                        retstring += " AND STM.AFENTERWAREHCODERF>=@STAFENTERWAREHCODE" + Environment.NewLine;
                        SqlParameter paraStMainBfAfEnterWarehCd = sqlCommand.Parameters.Add("@STAFENTERWAREHCODE", SqlDbType.NChar);
                        paraStMainBfAfEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.St_MainBfAfEnterWarehCd);
                    }
                    if (_stockMoveListCndtnWork.Ed_MainBfAfEnterWarehCd != "")
                    {
                        retstring += " AND (STM.AFENTERWAREHCODERF<=@EDAFENTERWAREHCODE OR STM.AFENTERWAREHCODERF LIKE @EDAFENTERWAREHCODE)" + Environment.NewLine;
                        SqlParameter paraEdMainBfAfEnterWarehCd = sqlCommand.Parameters.Add("@EDAFENTERWAREHCODE", SqlDbType.NChar);
                        paraEdMainBfAfEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_MainBfAfEnterWarehCd + "%");
                    }

                    //���ד��ݒ�
                    if (_stockMoveListCndtnWork.St_ShipArrivalDate != DateTime.MinValue)
                    {
                        int startymd = TDateTime.DateTimeToLongDate(_stockMoveListCndtnWork.St_ShipArrivalDate);
                        retstring += " AND STM.ARRIVALGOODSDAYRF >= " + startymd.ToString();
                    }
                    if (_stockMoveListCndtnWork.Ed_ShipArrivalDate != DateTime.MinValue)
                    {
                        if (_stockMoveListCndtnWork.St_ShipArrivalDate == DateTime.MinValue)
                        {
                            retstring += " AND (STM.ARRIVALGOODSDAYRF IS NULL OR";
                        }
                        else
                        {
                            retstring += " AND";
                        }

                        int endymd = TDateTime.DateTimeToLongDate(_stockMoveListCndtnWork.Ed_ShipArrivalDate);
                        retstring += " STM.ARRIVALGOODSDAYRF <= " + endymd.ToString();

                        if (_stockMoveListCndtnWork.St_ShipArrivalDate == DateTime.MinValue)
                        {
                            retstring += " ) ";
                        }
                    }
                    retstring += Environment.NewLine;
                    retstring += " AND STM.MOVESTATUSRF = 9" + Environment.NewLine;

                    //�ړ������_�R�[�h�ݒ�
                    retstring += " AND STM.BFSECTIONCODERF=STM.AFSECTIONCODERF" + Environment.NewLine;

                    //�ړ����q�ɃR�[�h�ݒ�
                    if (_stockMoveListCndtnWork.St_ShipArrivalEnterWarehCd != "")
                    {
                        retstring += " AND STM.BFENTERWAREHCODERF>=@STBFENTERWAREHCODE" + Environment.NewLine;
                        SqlParameter paraStShipArrivalEnterWarehCd = sqlCommand.Parameters.Add("@STBFENTERWAREHCODE", SqlDbType.NChar);
                        paraStShipArrivalEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.St_ShipArrivalEnterWarehCd);
                    }
                    if (_stockMoveListCndtnWork.Ed_ShipArrivalEnterWarehCd != "")
                    {
                        retstring += " AND (STM.BFENTERWAREHCODERF<=@EDBFENTERWAREHCODE OR STM.BFENTERWAREHCODERF LIKE @EDBFENTERWAREHCODE)" + Environment.NewLine;
                        SqlParameter paraEdShipArrivalEnterWarehCd = sqlCommand.Parameters.Add("@EDBFENTERWAREHCODE", SqlDbType.NChar);
                        paraEdShipArrivalEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_ShipArrivalEnterWarehCd + "%");
                    }
                    #endregion
                }
                retstring += " AND STM.STOCKMOVEFORMALRF = 2" + Environment.NewLine;
                #endregion
            }
                */
            #endregion

            #endregion
            return retstring;
        }
    }
}
