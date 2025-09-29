using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Diagnostics;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �݌Ɏd���`�[���������[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ɏd���`�[(�݌ɒ����f�[�^)�̌������s���N���X�ł�</br>
    /// <br>Programmer : 22018�@��؁@���b</br>
    /// <br>Date       : 2008.08.20</br>
    /// <br>-------------------------------------------</br>
    /// <br>Update Note: 2011/03/22 ������</br>
    /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class StockAdjRefSearchDB : RemoteDB, IStockAdjRefSearchDB
    {
        /// <summary>
        /// �݌Ɏd���`�[���������[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 22018�@��؁@���b</br>
        /// <br>Date       : 2008.08.20</br>
        /// </remarks>
        public StockAdjRefSearchDB()
            : base( "PMZAI04016D", "Broadleaf.Application.Remoting.ParamData.StockAdjRefSearchParaWork", "STOCKADJUSTRF" )
        {
        }

        #region[�w��para�̍݌ɒ����f�[�^LIST]
        /// <summary>
        /// �w�肳�ꂽ�p�����[�^�̏����𖞂����S�Ă̍݌ɒ����f�[�^LIST��߂��܂�
        /// </summary>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="retObj">�������ʍ݌ɒ����f�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�p�����[�^�̏����𖞂����S�Ă̍݌ɒ����f�[�^LIST��߂��܂�</br>
        /// <br>Programmer : 22018�@��؁@���b</br>
        /// <br>Date       : 2008.08.20</br>
        /// </remarks>
        public int Search( ref object paraObj, out object retObj )
        {
            return SearchProc( ref paraObj, out retObj );
        }
        /// <summary>
        /// �w�肳�ꂽ�p�����[�^�̏����𖞂����S�Ă̍݌ɒ����f�[�^LIST��߂��܂�
        /// </summary>
        /// <param name="paraObj"></param>
        /// <param name="retObj"></param>
        /// <returns></returns>
        /// <br>Update Note: 2011/03/22 ������</br>
        /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
        private int SearchProc(ref object paraObj, out object retObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //�������p�����[�^List�E�������ʃ��^�[��List
            CustomSerializeArrayList paraList = paraObj as CustomSerializeArrayList;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();

            retObj = null;

            //�������p�����[�^�`�F�b�N
            if (paraObj == null)
            {
                base.WriteErrorLog(null, "�v���O�����G���[�B�����Ώۃp�����[�^List�����w��ł�");
                return status;
            }

            // ---ADD 2011/03/22---------->>>>>
            StockAdjRefSearchParaWork searchPara = new StockAdjRefSearchParaWork();
            OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
            SqlConnection sqlConnection = null;

            //�������p�����[�^�̎��o��
            for (int i = 0; i < paraList.Count; i++)
            {
                if (paraList[i] is StockAdjRefSearchParaWork)
                {
                    searchPara = paraList[i] as StockAdjRefSearchParaWork;
                }
            }

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, searchPara.EnterpriseCode, "�݌Ɏd���`�[�Ɖ�", "���o�J�n");
            // ---ADD 2011/03/22----------<<<<<

            //�������������s
            status = SearchProc(paraList, out retList);

            // ---ADD 2011/03/22---------->>>>>
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, searchPara.EnterpriseCode, "�݌Ɏd���`�[�Ɖ�", "���o�I��");
            }
            catch
            {
                //�Ȃ��B
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            // ---ADD 2011/03/22----------<<<<<

            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    retObj = (object)retList;
            //}
            retObj = (object)retList;

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�p�����[�^�̏����𖞂����S�Ă̍݌ɒ����f�[�^LIST��߂��܂�
        /// </summary>
        /// <param name="paraList">�����p�����[�^</param>
        /// <param name="retList">�������ʍ݌ɒ����f�[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�p�����[�^�̏����𖞂����S�Ă̍݌ɒ����f�[�^LIST��߂��܂�</br>
        /// <br>Programmer : 22018�@��؁@���b</br>
        /// <br>Date       : 2008.08.20</br>
        private int SearchProc(CustomSerializeArrayList paraList, out CustomSerializeArrayList retList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            
            SqlConnection sqlConnection = null;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //SqlEncryptInfo sqlEncriptInfo = null;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            SqlDataReader myReader = null;

            //�������p�����[�^�i�[�p
            StockAdjRefSearchParaWork searchPara = null;

            //���������ʊi�[�pList
            retList = new CustomSerializeArrayList();

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //�������p�����[�^�̎��o��
                if (paraList != null)
                {
                    for (int i = 0; i < paraList.Count; i++)
                    {
                        if (paraList[i] is StockAdjRefSearchParaWork)
                        {
                            searchPara = paraList[i] as StockAdjRefSearchParaWork;
                        }
                    }
                }

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //sqlEncriptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "STOCKSLIPRF", "STOCKDETAILRF", "STOCKEXPLADATARF" });
                //���Í����L�[OPEN�iSQLException�̉\���L��j
                //sqlEncriptInfo.OpenSymKey(ref sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                if (searchPara != null)
                {
                    string sqlText = string.Empty;
                    SqlCommand sqlCommand = new SqlCommand( sqlText, sqlConnection );

                    //��SQL�\������

                    # region [SELECT������]

                    # region //delete
                    //// Select
                    //sqlText += "SELECT " + Environment.NewLine;
                    //sqlText += "  ADJ.ENTERPRISECODERF," + Environment.NewLine;
                    //sqlText += "  ADJ.SECTIONCODERF," + Environment.NewLine;
                    //sqlText += "  SEC.SECTIONGUIDESNMRF," + Environment.NewLine;
                    //sqlText += "  DTL.WAREHOUSECODERF," + Environment.NewLine;
                    //sqlText += "  DTL.WAREHOUSENAMERF," + Environment.NewLine;
                    //sqlText += "  ADJ.ACPAYSLIPCDRF," + Environment.NewLine;
                    //sqlText += "  ADJ.ACPAYTRANSCDRF," + Environment.NewLine;
                    //sqlText += "  ADJ.INPUTDAYRF," + Environment.NewLine;
                    //sqlText += "  ADJ.ADJUSTDATERF," + Environment.NewLine;
                    //sqlText += "  ADJ.STOCKADJUSTSLIPNORF," + Environment.NewLine;
                    //sqlText += "  ADJ.STOCKAGENTCODERF," + Environment.NewLine;
                    //sqlText += "  ADJ.STOCKAGENTNAMERF," + Environment.NewLine;
                    //sqlText += "  ADJ.SLIPNOTERF," + Environment.NewLine;
                    //sqlText += "  ADJ.STOCKSUBTTLPRICERF" + Environment.NewLine;

                    //sqlText += "FROM " + Environment.NewLine;
                    //sqlText += "  STOCKADJUSTRF AS ADJ" + Environment.NewLine;

                    //// LeftJoin SEC
                    //sqlText += "LEFT JOIN" + Environment.NewLine;
                    //sqlText += "  SECINFOSETRF AS SEC" + Environment.NewLine;
                    //sqlText += "ON" + Environment.NewLine;
                    //sqlText += "  ADJ.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;

                    //// LeftJoin DTL
                    //sqlText += "LEFT JOIN" + Environment.NewLine;
                    //sqlText += "  STOCKADJUSTDTLRF AS DTL" + Environment.NewLine;
                    //sqlText += "ON" + Environment.NewLine;
                    //sqlText += "  ADJ.ENTERPRISECODERF=DTL.ENTERPRISECODERF" + Environment.NewLine;
                    //sqlText += "  AND ADJ.STOCKADJUSTSLIPNORF=DTL.STOCKADJUSTSLIPNORF" + Environment.NewLine;
                    //sqlText += "  AND DTL.STOCKADJUSTROWNORF='1'" + Environment.NewLine;

                    //// Where
                    //sqlText += MakeWhereString( ref sqlCommand, searchPara );
                    # endregion

                    // Select
                    sqlText += "SELECT " + Environment.NewLine;
                    sqlText += "  ADJ.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "  ADJ.STOCKSECTIONCDRF," + Environment.NewLine;
                    sqlText += "  SEC.SECTIONGUIDESNMRF," + Environment.NewLine;
                    sqlText += "  DTL.WAREHOUSECODERF," + Environment.NewLine;
                    sqlText += "  DTL.WAREHOUSENAMERF," + Environment.NewLine;
                    sqlText += "  ADJ.ACPAYSLIPCDRF," + Environment.NewLine;
                    sqlText += "  ADJ.ACPAYTRANSCDRF," + Environment.NewLine;
                    sqlText += "  ADJ.INPUTDAYRF," + Environment.NewLine;
                    sqlText += "  ADJ.ADJUSTDATERF," + Environment.NewLine;
                    sqlText += "  ADJ.STOCKADJUSTSLIPNORF," + Environment.NewLine;
                    sqlText += "  ADJ.STOCKAGENTCODERF," + Environment.NewLine;
                    sqlText += "  ADJ.STOCKAGENTNAMERF," + Environment.NewLine;
                    sqlText += "  ADJ.SLIPNOTERF," + Environment.NewLine;
                    sqlText += "  ADJ.STOCKSUBTTLPRICERF" + Environment.NewLine;

                    sqlText += "FROM " + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    
                    # region [SLP]
                    // Select SLP
                    sqlText += "SELECT DISTINCT" + Environment.NewLine;
                    sqlText += "  ADJS.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "  ADJS.STOCKADJUSTSLIPNORF" + Environment.NewLine;
                    sqlText += "FROM " + Environment.NewLine;
                    sqlText += "  STOCKADJUSTRF AS ADJS" + Environment.NewLine;
                    sqlText += "JOIN " + Environment.NewLine;
                    sqlText += "  STOCKADJUSTDTLRF AS DTLS" + Environment.NewLine;
                    sqlText += "ON" + Environment.NewLine;
                    sqlText += "  ADJS.ENTERPRISECODERF=DTLS.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  AND ADJS.STOCKADJUSTSLIPNORF=DTLS.STOCKADJUSTSLIPNORF" + Environment.NewLine;
                    // Where
                    sqlText += MakeWhereString( ref sqlCommand, searchPara );

                    # endregion

                    sqlText += ") AS SLP" + Environment.NewLine;

                    // LeftJoin ADJ
                    sqlText += "LEFT JOIN" + Environment.NewLine;
                    sqlText += "  STOCKADJUSTRF AS ADJ" + Environment.NewLine;
                    sqlText += "ON" + Environment.NewLine;
                    sqlText += "  SLP.ENTERPRISECODERF=ADJ.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  AND SLP.STOCKADJUSTSLIPNORF=ADJ.STOCKADJUSTSLIPNORF" + Environment.NewLine;

                    // LeftJoin SEC
                    sqlText += "LEFT JOIN" + Environment.NewLine;
                    sqlText += "  SECINFOSETRF AS SEC" + Environment.NewLine;
                    sqlText += "ON" + Environment.NewLine;
                    sqlText += "  ADJ.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  AND ADJ.STOCKSECTIONCDRF=SEC.SECTIONCODERF" + Environment.NewLine;

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 ADD
                    // LeftJoin DTLROW
                    sqlText += "LEFT JOIN" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    sqlText += "  SELECT " + Environment.NewLine;
                    sqlText += "    ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "    STOCKADJUSTSLIPNORF," + Environment.NewLine;
                    sqlText += "    MIN(STOCKADJUSTROWNORF) AS ROWNO" + Environment.NewLine;
                    sqlText += "  FROM STOCKADJUSTDTLRF" + Environment.NewLine;
                    sqlText += "  GROUP BY" + Environment.NewLine;
                    sqlText += "    ENTERPRISECODERF,STOCKADJUSTSLIPNORF" + Environment.NewLine;
                    sqlText += ") AS DTLROW" + Environment.NewLine;
                    sqlText += "ON" + Environment.NewLine;
                    sqlText += "  DTLROW.ENTERPRISECODERF=ADJ.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  AND DTLROW.STOCKADJUSTSLIPNORF=ADJ.STOCKADJUSTSLIPNORF" + Environment.NewLine;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 ADD

                    // LeftJoin DTL
                    sqlText += "LEFT JOIN" + Environment.NewLine;
                    sqlText += "  STOCKADJUSTDTLRF AS DTL" + Environment.NewLine;
                    sqlText += "ON" + Environment.NewLine;
                    sqlText += "  ADJ.ENTERPRISECODERF=DTL.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  AND ADJ.STOCKADJUSTSLIPNORF=DTL.STOCKADJUSTSLIPNORF" + Environment.NewLine;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 DEL
                    //sqlText += "  AND DTL.STOCKADJUSTROWNORF='1'" + Environment.NewLine;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 ADD
                    sqlText += "  AND DTL.STOCKADJUSTSLIPNORF=DTLROW.STOCKADJUSTSLIPNORF" + Environment.NewLine;
                    sqlText += "  AND DTL.STOCKADJUSTROWNORF=DTLROW.ROWNO" + Environment.NewLine;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 ADD

                    // OrderBy
                    sqlText += "ORDER BY" + Environment.NewLine;
                    sqlText += "  ADJ.ADJUSTDATERF," + Environment.NewLine;
                    sqlText += "  ADJ.STOCKADJUSTSLIPNORF" + Environment.NewLine;

                    # endregion

                    sqlCommand.CommandText = sqlText;
                    myReader = sqlCommand.ExecuteReader();

                    while ( myReader.Read() )
                    {
                        //���������ʂ��i�[
                        retList.Add( CopyToRetWork( ref myReader ) );
                    }

                    if ( retList.Count > 0 )
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
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
                base.WriteErrorLog(ex, "SearchStockSlipDB.SearchProc Exception = " + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //if (myReader != null && myReader.IsClosed == false) myReader.Close();
                ////�Í����L�[�N���[�Y
                //if (sqlEncriptInfo != null && sqlEncriptInfo.IsOpen) sqlEncriptInfo.CloseSymKey(ref sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region[Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="searchPara">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <remarks>
        /// <br>WHERE�吶�����g���񂷈ׁASQL�������񐶐��ƃp�����[�^�ݒ�𕪂��ċL�ڂ��܂��B</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockAdjRefSearchParaWork searchPara )
        {
            string retstring = "WHERE" + Environment.NewLine;

            # region [����]

            // ��ƃR�[�h
            retstring += "  ADJS.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString( searchPara.EnterpriseCode );

            // �_���폜
            retstring += "  AND ADJS.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            retstring += "  AND DTLS.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add( "@FINDLOGICALDELETECODE", SqlDbType.Int );
            findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32( (int)ConstantManagement.LogicalMode.GetData0 );

            // ���_�R�[�h
            if ( searchPara.SectionCode != string.Empty )
            {
                retstring += "  AND ADJS.STOCKSECTIONCDRF=@FINDSECTIONCODE " + Environment.NewLine;
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add( "@FINDSECTIONCODE", SqlDbType.NChar );
                findParaSectionCode.Value = SqlDataMediator.SqlSetString( searchPara.SectionCode );
            }
            // �q�ɃR�[�h
            if ( searchPara.WarehouseCode != string.Empty )
            {
                retstring += "  AND DTLS.WAREHOUSECODERF=@FINDWAREHOUSECODE " + Environment.NewLine;
                SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add( "@FINDWAREHOUSECODE", SqlDbType.NChar );
                findParaWarehouseCode.Value = SqlDataMediator.SqlSetString( searchPara.WarehouseCode );
            }
            // �󕥌��`�[�敪
            if ( searchPara.AcPaySlipCd != 0 )
            {
                retstring += "  AND ADJS.ACPAYSLIPCDRF=@FINDACPAYSLIPCD " + Environment.NewLine;
                SqlParameter findParaAcPaySlipCd = sqlCommand.Parameters.Add( "@FINDACPAYSLIPCD", SqlDbType.Int );
                findParaAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32( searchPara.AcPaySlipCd );
            }
            // �󕥌�����敪
            if ( searchPara.AcPayTransCd != 0 )
            {
                retstring += "  AND ADJS.ACPAYTRANSCDRF=@FINDACPAYTRANSCD " + Environment.NewLine;
                SqlParameter findParaAcPayTransCd = sqlCommand.Parameters.Add( "@FINDACPAYTRANSCD", SqlDbType.Int );
                findParaAcPayTransCd.Value = SqlDataMediator.SqlSetInt32( searchPara.AcPayTransCd );
            }
            // �J�n���͓��t
            if ( searchPara.St_InputDay != 0 )
            {
                retstring += "  AND ADJS.INPUTDAYRF>=@FINDST_INPUTDAY " + Environment.NewLine;
                SqlParameter findParaSt_InputDay = sqlCommand.Parameters.Add( "@FINDST_INPUTDAY", SqlDbType.Int );
                findParaSt_InputDay.Value = SqlDataMediator.SqlSetInt32( searchPara.St_InputDay );
            }
            // �I�����͓��t
            if ( searchPara.Ed_InputDay != 0 )
            {
                retstring += "  AND ADJS.INPUTDAYRF<=@FINDED_INPUTDAY " + Environment.NewLine;
                SqlParameter findParaEd_InputDay = sqlCommand.Parameters.Add( "@FINDED_INPUTDAY", SqlDbType.Int );
                findParaEd_InputDay.Value = SqlDataMediator.SqlSetInt32( searchPara.Ed_InputDay );
            }
            // �J�n�������t
            if ( searchPara.St_AdjustDate != 0 )
            {
                retstring += "  AND ADJS.ADJUSTDATERF>=@FINDST_ADJUSTDATE " + Environment.NewLine;
                SqlParameter findParaSt_AdjustDate = sqlCommand.Parameters.Add( "@FINDST_ADJUSTDATE", SqlDbType.Int );
                findParaSt_AdjustDate.Value = SqlDataMediator.SqlSetInt32( searchPara.St_AdjustDate );
            }
            // �I���������t
            if ( searchPara.Ed_AdjustDate != 0 )
            {
                retstring += "  AND ADJS.ADJUSTDATERF<=@FINDED_ADJUSTDATE " + Environment.NewLine;
                SqlParameter findParaEd_AdjustDate = sqlCommand.Parameters.Add( "@FINDED_ADJUSTDATE", SqlDbType.Int );
                findParaEd_AdjustDate.Value = SqlDataMediator.SqlSetInt32( searchPara.Ed_AdjustDate );
            }
            // �J�n�݌ɒ����`�[�ԍ�
            if ( searchPara.St_StockAdjustSlipNo != 0 )
            {
                retstring += "  AND ADJS.STOCKADJUSTSLIPNORF>=@FINDST_STOCKADJUSTSLIPNO " + Environment.NewLine;
                SqlParameter findParaSt_StockAdjustSlipNo = sqlCommand.Parameters.Add( "@FINDST_STOCKADJUSTSLIPNO", SqlDbType.Int );
                findParaSt_StockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32( searchPara.St_StockAdjustSlipNo );
            }
            // �I���݌ɒ����`�[�ԍ�
            if ( searchPara.Ed_StockAdjustSlipNo != 0 )
            {
                retstring += "  AND ADJS.STOCKADJUSTSLIPNORF<=@FINDED_STOCKADJUSTSLIPNO " + Environment.NewLine;
                SqlParameter findParaEd_StockAdjustSlipNo = sqlCommand.Parameters.Add( "@FINDED_STOCKADJUSTSLIPNO", SqlDbType.Int );
                findParaEd_StockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32( searchPara.Ed_StockAdjustSlipNo );
            }
            // �d���S���҃R�[�h
            if ( searchPara.StockAgentCode != string.Empty )
            {
                retstring += "  AND ADJS.STOCKAGENTCODERF=@FINDSTOCKAGENTCODE " + Environment.NewLine;
                SqlParameter findParaStockAgentCode = sqlCommand.Parameters.Add( "@FINDSTOCKAGENTCODE", SqlDbType.NVarChar );
                findParaStockAgentCode.Value = SqlDataMediator.SqlSetString( searchPara.StockAgentCode );
            }
            // ���i���[�J�[�R�[�h
            if ( searchPara.GoodsMakerCd != 0 )
            {
                retstring += "  AND DTLS.GOODSMAKERCDRF=@FINDGOODSMAKERCD " + Environment.NewLine;
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add( "@FINDGOODSMAKERCD", SqlDbType.Int );
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32( searchPara.GoodsMakerCd );
            }
            // ���i�ԍ�
            if ( searchPara.GoodsNo != string.Empty )
            {
                retstring += "  AND DTLS.GOODSNORF" + MakeMarkFromType( searchPara.GoodsNoTyp ) + "@FINDGOODSNO " + Environment.NewLine;
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add( "@FINDGOODSNO", SqlDbType.NVarChar );
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString( MakeLikeStringFromType( searchPara.GoodsNo, searchPara.GoodsNoTyp ) );
            }
            // ���i����
            if ( searchPara.GoodsName != string.Empty )
            {
                retstring += "  AND DTLS.GOODSNAMERF" + MakeMarkFromType( searchPara.GoodsNameTyp ) + "@FINDGOODSNAME " + Environment.NewLine;
                SqlParameter findParaGoodsName = sqlCommand.Parameters.Add( "@FINDGOODSNAME", SqlDbType.NVarChar );
                findParaGoodsName.Value = SqlDataMediator.SqlSetString( MakeLikeStringFromType( searchPara.GoodsName, searchPara.GoodsNameTyp ) );
            }
            // �q�ɒI��
            if ( searchPara.WarehouseShelfNo != string.Empty )
            {
                retstring += "  AND DTLS.WAREHOUSESHELFNORF" + MakeMarkFromType( searchPara.WarehouseShelfNoTyp ) + "@FINDWAREHOUSESHELFNO " + Environment.NewLine;
                SqlParameter findParaWarehouseShelfNo = sqlCommand.Parameters.Add( "@FINDWAREHOUSESHELFNO", SqlDbType.NVarChar );
                findParaWarehouseShelfNo.Value = SqlDataMediator.SqlSetString( MakeLikeStringFromType( searchPara.WarehouseShelfNo, searchPara.WarehouseShelfNoTyp ) );
            }

            # endregion

            return retstring;
        }
        /// <summary>
        /// �����^�C�v�� Like������擾
        /// </summary>
        /// <param name="value"></param>
        /// <param name="searchType"></param>
        /// <returns></returns>
        private string MakeLikeStringFromType( string value, int searchType )
        {
            switch ( searchType )
            {
                case 0:
                    {
                        // ���S��v
                        return string.Format( "{0}", value );
                    }
                case 1:
                    {
                        // �O����v
                        return string.Format( "{0}%", value );
                    }
                case 2:
                    {
                        // �����v
                        return string.Format( "%{0}", value );
                    }
                case 3:
                default:
                    {
                        // �����܂�
                        return string.Format( "%{0}%", value );
                    }
            }
        }
        /// <summary>
        /// �����^�C�v�� �L���擾
        /// </summary>
        /// <param name="searchType"></param>
        /// <returns></returns>
        private string MakeMarkFromType( int searchType )
        {
            if ( searchType == 0 )
            {
                // ���S��v
                return " = ";
            }
            else
            {
                return " LIKE ";
            }
        }
        #endregion

        #region[�������ʃN���X�i�[]
        /// <summary>
        /// �d���������ʃN���X�o�͏���
        /// </summary>
        /// <param name="myReader">��������</param>
        /// <returns>�o�̓N���X</returns>
        /// <remarks>
        /// <br>Note       : �d���������ʃN���X�o�͏���</br>
        /// <br>Programmer : 22018�@��؁@���b</br>
        /// <br>Date       : 2008.08.20</br>
        /// </remarks>
        private StockAdjRefSearchRetWork CopyToRetWork(ref SqlDataReader myReader)
        {
            StockAdjRefSearchRetWork stockAdjRefSearchRetWork = new StockAdjRefSearchRetWork();

            # region [copy]
            stockAdjRefSearchRetWork.EnterpriseCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENTERPRISECODERF" ) ); // ��ƃR�[�h
            stockAdjRefSearchRetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF")); // ���_�R�[�h
            stockAdjRefSearchRetWork.SectionGuideSnm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SECTIONGUIDESNMRF" ) ); // ���_�K�C�h����
            stockAdjRefSearchRetWork.WarehouseCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "WAREHOUSECODERF" ) ); // �q�ɃR�[�h
            stockAdjRefSearchRetWork.WarehouseName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "WAREHOUSENAMERF" ) ); // �q�ɖ���
            stockAdjRefSearchRetWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ACPAYSLIPCDRF" ) ); // �󕥌��`�[�敪
            stockAdjRefSearchRetWork.AcPayTransCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ACPAYTRANSCDRF" ) ); // �󕥌�����敪
            stockAdjRefSearchRetWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "INPUTDAYRF" ) ); // ���͓��t
            stockAdjRefSearchRetWork.AdjustDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "ADJUSTDATERF" ) ); // �������t
            stockAdjRefSearchRetWork.StockAdjustSlipNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "STOCKADJUSTSLIPNORF" ) ); // �݌ɒ����`�[�ԍ�
            stockAdjRefSearchRetWork.StockAgentCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "STOCKAGENTCODERF" ) ); // �d���S���҃R�[�h
            stockAdjRefSearchRetWork.StockAgentName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "STOCKAGENTNAMERF" ) ); // �d���S���Җ���
            stockAdjRefSearchRetWork.SlipNote = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SLIPNOTERF" ) ); // �`�[���l
            stockAdjRefSearchRetWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "STOCKSUBTTLPRICERF" ) ); // �d�����z
            # endregion

            return stockAdjRefSearchRetWork;
        }
        #endregion
    }
}
