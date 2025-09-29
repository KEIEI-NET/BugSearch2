//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���iMAX���ח\��
// �v���O�����T�v   : ��ʒ��o�����𖞂������f�[�^��߂�
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11270001-00  �쐬�S�� : ���O
// �� �� ��  2016/01/21  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670219-00  �쐬�S�� : 杍^
// �� �� ��  2020/06/18   �C�����e : PMKOBETSU-4005 �d�a�d�΍�
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;

using Broadleaf.Library.Data;
using Broadleaf.Library.Resources; 
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common; // ADD 2020/06/18 杍^ PMKOBETSU-4005

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���iMAX���ח\��DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note        : ���iMAX���ח\��f�[�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer  : ���O</br>
    /// <br>Date        : 2016/01/21</br>
    /// <br>Update Note : PMKOBETSU-4005 �d�a�d�΍�</br>
    /// <br>Programmer  : 杍^</br>
    /// <br>Date        : 2020/06/18</br>
    /// </remarks>
    [Serializable]
    public class PartsMaxStockArrivalDB : RemoteDB, IPartsMaxStockArrivalDB
    {
        #region �R���X�g
        /// <summary>
        /// ���iMAX���ח\��R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���ɂȂ�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        public PartsMaxStockArrivalDB()
        {
        }
        #endregion

        #region public
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̕��iMAX���ח\�񌏐��擾����
        /// </summary>
        /// <param name="searchCount">��������</param>
        /// <param name="partsMaxStockArrivalCndtnWork">�����p�����[�^</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �w�肳�ꂽ��ƃR�[�h�̕��iMAX���ח\�񌏐��擾�������܂�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        public int SearchCount(out int searchCount, object partsMaxStockArrivalCndtnWork, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            searchCount = 0;
            object partsMaxStockArrivalResultWork = null;
            errMessage = string.Empty;
            bool moveDiv = true;
            //SqlConnection����
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            //SqlConnection�ڑ�
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnction = null;
            //�R�l�N�V��������
            using (sqlConnction = new SqlConnection(connectionText))
            {
                try
                {
                    sqlConnction.Open();
                    PartsMaxStockArrivalCondt cndtnWork = partsMaxStockArrivalCndtnWork as PartsMaxStockArrivalCondt;

                    status = SearchProc(out partsMaxStockArrivalResultWork, out searchCount, cndtnWork, out errMessage, ref sqlConnction, moveDiv, 0);

                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "PartsMaxStockArrivalDB.Search");
                    errMessage = ex.Message;
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
                finally
                {
                    // �R�l�N�V�����j��
                    if (sqlConnction != null) sqlConnction.Close();
                }
            }

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̕��iMAX���ח\��f�[�^�̑S�Ė߂鏈��
        /// </summary>
        /// <param name="partsMaxStockArrivalResultWork">��������</param>
        /// <param name="partsMaxStockArrivalCndtnWork">�����p�����[�^</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="loopIndex">����index</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �w�肳�ꂽ��ƃR�[�h�̕��iMAX���ח\��f�[�^LIST��S�Ė߂��܂�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        public int Search(out object partsMaxStockArrivalResultWork, object partsMaxStockArrivalCndtnWork, out string errMessage, int loopIndex)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            partsMaxStockArrivalResultWork = null;
            errMessage = string.Empty;
            bool moveDiv = false;
            int searchCount = 0;
            //SqlConnection����
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            //SqlConnection�ڑ�
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnction = null;
            //�R�l�N�V��������
            using (sqlConnction = new SqlConnection(connectionText))
            {
                try
                {
                    sqlConnction.Open();
                    PartsMaxStockArrivalCondt cndtnWork = partsMaxStockArrivalCndtnWork as PartsMaxStockArrivalCondt;

                    status = SearchProc(out partsMaxStockArrivalResultWork, out searchCount, cndtnWork, out errMessage, ref sqlConnction, moveDiv, loopIndex);

                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "PartsMaxStockArrivalDB.Search");
                    partsMaxStockArrivalResultWork = new ArrayList();
                    errMessage = ex.Message;
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
                finally
                {
                    // �R�l�N�V�����j��
                    if (sqlConnction != null) sqlConnction.Close();
                }
            }

            return status;
        }
        #endregion

        #region private
        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ɉړ��f�[�^��S�Ė߂鏈��
        /// </summary>
        /// <param name="partsMaxStockArrivalResultWork">�݌Ɉړ��f�[�^����</param>
        /// <param name="searchCount">�݌Ɉړ��f�[�^����</param>
        /// <param name="cndtnWork">�����p�����[�^</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="moveDiv">�����擾�ƍ݌Ɉړ��f�[�^�敪</param>
        /// <param name="loopIndex">���[�vIndex</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɉړ��f�[�^��S�Ė߂�B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// <br>Update Note : PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2020/06/18</br>
        /// </remarks>
        private int SearchProc(out object partsMaxStockArrivalResultWork, out int searchCount, PartsMaxStockArrivalCondt cndtnWork, out string errMessage, ref SqlConnection sqlConnection, bool moveDiv, int loopIndex)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            errMessage = string.Empty;
            partsMaxStockArrivalResultWork = null;
            searchCount = 0;
            ArrayList al = new ArrayList(); //���o����
            StringBuilder sqlTxt = new StringBuilder(string.Empty);
            //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
            // �ϊ����Ăяo��
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // �ϊ���񏉊���
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<
            // �����N�G�����̍\�z
            using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection))
            {
                try
                {
                    if (moveDiv)
                    {
                        // Select�R�}���h
                        sqlTxt.Append(MakeMoveCountString());
                        sqlTxt.Append(MakeMoveWhereString(cndtnWork, moveDiv));
                    }
                    else
                    {
                        // Select�R�}���h
                        sqlTxt.Append(MakeMoveSelectString(loopIndex, cndtnWork));
                        SqlParameter paraGoodsDate = sqlCommand.Parameters.Add("@DATE", SqlDbType.Int);
                        paraGoodsDate.Value = SqlDataMediator.SqlSetInt32(Int32.Parse(DateTime.Today.ToString("yyyyMMdd")));

                    }


                    //��������
                    // ��ƃR�[�h
                    SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODERF", SqlDbType.NChar);
                    paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EnterpriseCode);

                    // �_���폜�敪
                    SqlParameter paraALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODERF", SqlDbType.Int);
                    paraALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                    // �o�ɋ��_�R�[�h
                    if (!string.IsNullOrEmpty(cndtnWork.BfSectionCode))
                    {
                        SqlParameter paraBfSectionCode = sqlCommand.Parameters.Add("@BFSECTIONCODE", SqlDbType.NChar);
                        paraBfSectionCode.Value = SqlDataMediator.SqlSetString(cndtnWork.BfSectionCode);
                    }
                    // ���ɋ��_�R�[�h
                    if (!string.IsNullOrEmpty(cndtnWork.AfSectionCode))
                    {
                        SqlParameter paraAfSectionCode = sqlCommand.Parameters.Add("@AFSECTIONCODE", SqlDbType.NChar);
                        paraAfSectionCode.Value = SqlDataMediator.SqlSetString(cndtnWork.AfSectionCode);
                    }
                    SqlParameter para_St_Date = sqlCommand.Parameters.Add("@ARRIVALGOODSDAYST", SqlDbType.Int);
                    para_St_Date.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.ShipDateSt);

                    SqlParameter para_Ed_Date = sqlCommand.Parameters.Add("@ARRIVALGOODSDAYED", SqlDbType.Int);
                    para_Ed_Date.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.ShipDateEd);


                    sqlCommand.CommandText = sqlTxt.ToString();

                    // �N�G�����s���̃^�C���A�E�g���Ԃ�3600�b�ɐݒ肷��
                    sqlCommand.CommandTimeout = 3600;
                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            // ���o����-�l�Z�b�g
                            if (moveDiv)
                            {
                                searchCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESDT_COUNT"));

                            }
                            else
                            {
                                //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
                                // �݌Ɉړ��f�[�^���o����-�l�Z�b�g
                                //al.Add(CopyMoveDataFromSqlDataReader(myReader));
                                al.Add(CopyMoveDataFromSqlDataReader(myReader, convertDoubleRelease));
                                //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<
                            }
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }

                        if (al.Count == 0 && !moveDiv)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                    }

                }
                catch (SqlException ex)
                {
                    errMessage = ex.Message;
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    errMessage = ex.Message;
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "PartsMaxStockArrivalDB.SearchProc Exception=" + ex.Message, status);
                }
                //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
                finally
                {
                    // ���
                    convertDoubleRelease.Dispose();
                }
                //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<
            }


            partsMaxStockArrivalResultWork = al;

            return status;
        }

        /// <summary>
        /// �ړ��f�[�^������
        /// </summary>
        /// <remarks>
        /// <br>Note        : �ړ��f�[�^����������</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private string MakeMoveSelectString(int loopIndex, PartsMaxStockArrivalCondt cndtnWork)
        {
            StringBuilder selectTxt = new StringBuilder();
            selectTxt.Append("SELECT ").Append(Environment.NewLine);
            selectTxt.Append("* FROM ").Append(Environment.NewLine);
            selectTxt.Append("( ").Append(Environment.NewLine);
            selectTxt.Append("SELECT ").Append(Environment.NewLine);
            selectTxt.Append("ROW_NUMBER() OVER(ORDER BY SUB_MOVE.STOCKMOVESLIPNORF, SUB_MOVE.STOCKMOVEROWNORF) AS ROWID ").Append(Environment.NewLine);
            selectTxt.Append(",*  ").Append(Environment.NewLine);
            selectTxt.Append("FROM ").Append(Environment.NewLine);
            selectTxt.Append("( ").Append(Environment.NewLine);

            selectTxt.Append("SELECT ").Append(Environment.NewLine);
            selectTxt.Append("STMOVE.ENTERPRISECODERF ").Append(Environment.NewLine);        // ��ƃR�[�h
            selectTxt.Append(",STMOVE.SHIPMENTFIXDAYRF ").Append(Environment.NewLine);       // �o�׊m���
            selectTxt.Append(",STMOVE.STOCKMOVESLIPNORF ").Append(Environment.NewLine);      // �݌Ɉړ��`�[�ԍ�
            selectTxt.Append(",STMOVE.STOCKMOVEROWNORF ").Append(Environment.NewLine);       // �݌Ɉړ��s�ԍ�
            selectTxt.Append(",STMOVE.GOODSNORF ").Append(Environment.NewLine);              // ���i�ԍ�
            selectTxt.Append(",STMOVE.GOODSNAMERF ").Append(Environment.NewLine);            // ���i����
            selectTxt.Append(",STMOVE.GOODSMAKERCDRF ").Append(Environment.NewLine);         // ���i���[�J�[�R�[�h
            selectTxt.Append(",STMOVE.MAKERNAMERF ").Append(Environment.NewLine);            // ���[�J�[����
            selectTxt.Append(",STMOVE.BLGOODSCODERF ").Append(Environment.NewLine);          // BL���i�R�[�h
            selectTxt.Append(",STMOVE.MOVECOUNTRF ").Append(Environment.NewLine);            // �ړ���
            selectTxt.Append(",STMOVE.BFSECTIONCODERF ").Append(Environment.NewLine);        // �ړ������_�R�[�h
            selectTxt.Append(",STMOVE.BFSECTIONGUIDESNMRF ").Append(Environment.NewLine);    // �ړ������_�K�C�h����
            selectTxt.Append(",STMOVE.BFENTERWAREHCODERF ").Append(Environment.NewLine);     // �ړ����q�ɃR�[�h
            selectTxt.Append(",STMOVE.BFENTERWAREHNAMERF ").Append(Environment.NewLine);     // �ړ����q�ɖ���
            selectTxt.Append(",STMOVE.AFSECTIONCODERF ").Append(Environment.NewLine);        // �ړ��拒�_�R�[�h
            selectTxt.Append(",STMOVE.AFSECTIONGUIDESNMRF ").Append(Environment.NewLine);    // �ړ��拒�_�K�C�h����
            selectTxt.Append(",STMOVE.AFENTERWAREHCODERF ").Append(Environment.NewLine);     // �ړ���q�ɃR�[�h
            selectTxt.Append(",STMOVE.AFENTERWAREHNAMERF ").Append(Environment.NewLine);     // �ړ���q�ɖ���
            selectTxt.Append(" ,STMOVE.SUPPLIERCDRF ").Append(Environment.NewLine);          // �d����R�[�h
            selectTxt.Append(",BLGOODSCDU.GOODSRATEGRPCODERF ").Append(Environment.NewLine); // ���i�|��G
            selectTxt.Append(",BLGOODSCDU.BLGROUPCODERF ").Append(Environment.NewLine);      // BL�O���[�v�R�[�h
            selectTxt.Append(",GOODSU.GOODSRATERANKRF ").Append(Environment.NewLine);// ���i�|�������N
            selectTxt.Append(",GOODSU.TAXATIONDIVCDRF ").Append(Environment.NewLine);// �ېŋ敪

            selectTxt.Append(",BLGROUPU.GOODSMGROUPRF ").Append(Environment.NewLine);// ���i�����ރR�[�h
            selectTxt.Append(",WAREHOUSE.SECTIONCODERF  ").Append(Environment.NewLine);// �Ǘ����_�R�[�h

            selectTxt.Append(",GSP.OPENPRICEDIVRF ").Append(Environment.NewLine);            //�I�[�v�����i�敪
            selectTxt.Append(",GSP.PRICESTARTDATERF, -- ���i�}�X�^.���i�J�n��").Append(Environment.NewLine);
            selectTxt.Append(" GSP.LISTPRICERF, ").Append(Environment.NewLine);
            selectTxt.Append(" GSP.SALESUNITCOSTRF, ").Append(Environment.NewLine);
            selectTxt.Append(" GSP.STOCKRATERF, ").Append(Environment.NewLine);                                             
            selectTxt.Append(" GSP.OFFERDATERF, ").Append(Environment.NewLine);
            selectTxt.Append(" GSP.UPDATEDATERF ").Append(Environment.NewLine);
            selectTxt.Append("FROM STOCKMOVERF AS STMOVE WITH (READUNCOMMITTED) --�݌Ɉړ��f�[�^").Append(Environment.NewLine);

            selectTxt.Append(" LEFT JOIN GOODSURF AS GOODSU WITH (READUNCOMMITTED) --���i�}�X�^").Append(Environment.NewLine);
            selectTxt.Append(" ON STMOVE.ENTERPRISECODERF = GOODSU.ENTERPRISECODERF -- ��ƃR�[�h ").Append(Environment.NewLine);
            selectTxt.Append(" AND STMOVE.GOODSMAKERCDRF = GOODSU.GOODSMAKERCDRF -- ���i���[�J�[�R�[�h ").Append(Environment.NewLine);
            selectTxt.Append(" AND STMOVE.GOODSNORF = GOODSU.GOODSNORF -- ���i�ԍ� ").Append(Environment.NewLine);
            selectTxt.Append(" AND GOODSU.LOGICALDELETECODERF = 0 -- �_���폜�敪 ").Append(Environment.NewLine);

            selectTxt.Append(" LEFT JOIN BLGOODSCDURF AS BLGOODSCDU WITH (READUNCOMMITTED) --�a�k���i�R�[�h�}�X�^(���[�U�[)").Append(Environment.NewLine);
            selectTxt.Append(" ON GOODSU.ENTERPRISECODERF = BLGOODSCDU.ENTERPRISECODERF-- ��ƃR�[�h ").Append(Environment.NewLine);
            selectTxt.Append(" AND STMOVE.BLGOODSCODERF = BLGOODSCDU.BLGOODSCODERF-- BL���i�R�[�h ").Append(Environment.NewLine);

            selectTxt.Append(" LEFT JOIN BLGROUPURF AS BLGROUPU WITH (READUNCOMMITTED) --BL�O���[�v�}�X�^�i���[�U�[�o�^���j").Append(Environment.NewLine);
            selectTxt.Append(" ON BLGOODSCDU.ENTERPRISECODERF = BLGROUPU.ENTERPRISECODERF-- ��ƃR�[�h ").Append(Environment.NewLine);
            selectTxt.Append(" AND BLGOODSCDU.BLGROUPCODERF = BLGROUPU.BLGROUPCODERF-- BL�O���[�v�R�[�h ").Append(Environment.NewLine);

            selectTxt.Append(" LEFT JOIN WAREHOUSERF AS WAREHOUSE WITH (READUNCOMMITTED) --�q�Ƀ}�X�^").Append(Environment.NewLine);
            selectTxt.Append(" ON STMOVE.ENTERPRISECODERF = WAREHOUSE.ENTERPRISECODERF-- ��ƃR�[�h ").Append(Environment.NewLine);
            selectTxt.Append(" AND STMOVE.AFENTERWAREHCODERF = WAREHOUSE.WAREHOUSECODERF-- �q�ɃR�[�h ").Append(Environment.NewLine);

            selectTxt.Append("LEFT JOIN  GOODSPRICEURF AS GSP WITH (READUNCOMMITTED) --���i�}�X�^").Append(Environment.NewLine);
            selectTxt.Append("ON STMOVE.ENTERPRISECODERF = GSP.ENTERPRISECODERF ").Append(Environment.NewLine);
            selectTxt.Append("AND STMOVE.GOODSMAKERCDRF = GSP.GOODSMAKERCDRF ").Append(Environment.NewLine);
            selectTxt.Append("AND STMOVE.GOODSNORF = GSP.GOODSNORF ").Append(Environment.NewLine);
            selectTxt.Append("AND GSP.LOGICALDELETECODERF = 0 ").Append(Environment.NewLine);
            selectTxt.Append("AND GSP.PRICESTARTDATERF =  ").Append(Environment.NewLine);
            selectTxt.Append("(SELECT MAX(PRICESTARTDATERF) ").Append(Environment.NewLine);
            selectTxt.Append("FROM GOODSPRICEURF GSP_B WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
            selectTxt.Append("WHERE GSP_B.ENTERPRISECODERF=STMOVE.ENTERPRISECODERF ").Append(Environment.NewLine);
            selectTxt.Append("AND GSP_B.GOODSMAKERCDRF=STMOVE.GOODSMAKERCDRF ").Append(Environment.NewLine);
            selectTxt.Append("AND GSP_B.GOODSNORF=STMOVE.GOODSNORF ").Append(Environment.NewLine);
            selectTxt.Append("AND GSP_B.PRICESTARTDATERF <= @DATE)").Append(Environment.NewLine);
            selectTxt.Append(MakeMoveWhereString(cndtnWork, false));

            selectTxt.Append(") AS SUB_MOVE ").Append(Environment.NewLine);
            selectTxt.Append(") AS MOVE ").Append(Environment.NewLine);
            selectTxt.Append("WHERE ").Append(Environment.NewLine);
            selectTxt.Append("ROWID BETWEEN " ).Append(Environment.NewLine);
            selectTxt.Append(loopIndex * cndtnWork.DataSize + 1).Append(Environment.NewLine);
            selectTxt.Append(" AND ").Append(Environment.NewLine);
            selectTxt.Append((loopIndex + 1) * cndtnWork.DataSize).Append(Environment.NewLine);

            return selectTxt.ToString();

        }

         /// <summary>
        /// �ړ��f�[�^������
        /// </summary>
        /// <remarks>
        /// <br>Note        : �ړ��f�[�^����������</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private string MakeMoveWhereString(PartsMaxStockArrivalCondt cndtnWork, bool moveDiv)
        {
            StringBuilder sqlTxt = new StringBuilder();
            //��������
            sqlTxt.Append(" WHERE ").Append(Environment.NewLine);

            // ��ƃR�[�h
            sqlTxt.Append(" STMOVE.ENTERPRISECODERF=@ENTERPRISECODERF ").Append(Environment.NewLine);

            // �_���폜�敪
            sqlTxt.Append(" AND STMOVE.LOGICALDELETECODERF=@ALOGICALDELETECODERF").Append(Environment.NewLine);


            // �o�ɋ��_�R�[�h
            if (!string.IsNullOrEmpty(cndtnWork.BfSectionCode))
            {
                sqlTxt.Append(" AND STMOVE.BFSECTIONCODERF=@BFSECTIONCODE ").Append(Environment.NewLine);
               
            }
            // ���ɋ��_�R�[�h
            if (!string.IsNullOrEmpty(cndtnWork.AfSectionCode))
            {
                sqlTxt.Append(" AND STMOVE.AFSECTIONCODERF=@AFSECTIONCODE ").Append(Environment.NewLine);
               
            }
            sqlTxt.Append(" AND STMOVE.STOCKMOVEFORMALRF IN (1, 2) ").Append(Environment.NewLine);
            // �o�ד��t
            sqlTxt.Append(" AND STMOVE.SHIPMENTFIXDAYRF BETWEEN @ARRIVALGOODSDAYST AND @ARRIVALGOODSDAYED").Append(Environment.NewLine);

            // �ړ���q�ɃR�[�h     ���z��ŕ����w�肳���
            if (cndtnWork.AfWarehouseCodeList != null)
            {
                string warehouseCodestr = "";
                foreach (string whsCdstr in cndtnWork.AfWarehouseCodeList)
                {
                    if (warehouseCodestr != "")
                    {
                        warehouseCodestr += ",";
                    }
                    warehouseCodestr += "'" + whsCdstr + "'";
                }

                if (warehouseCodestr != "")
                {
                    sqlTxt.Append(" AND STMOVE.AFENTERWAREHCODERF IN (" + warehouseCodestr + ") ").Append(Environment.NewLine);
                }
            }

            // �ړ����q�ɃR�[�h     ���z��ŕ����w�肳���
            if (cndtnWork.BfWarehouseCodeList != null)
            {
                string warehouseCdstr = "";
                foreach (string whCdstr in cndtnWork.BfWarehouseCodeList)
                {
                    if (warehouseCdstr != "")
                    {
                        warehouseCdstr += ",";
                    }
                    warehouseCdstr += "'" + whCdstr + "'";
                }

                if (warehouseCdstr != "")
                {
                    sqlTxt.Append(" AND STMOVE.BFENTERWAREHCODERF IN (" + warehouseCdstr + ") ").Append(Environment.NewLine);
                }
            }
            return sqlTxt.ToString();

        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <remarks>
        /// <br>Note        : ����������</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private string MakeMoveCountString()
        {
            StringBuilder selectTxt = new StringBuilder();
            selectTxt.Append("SELECT ").Append(Environment.NewLine);
            selectTxt.Append("COUNT(*) AS SALESDT_COUNT ").Append(Environment.NewLine);
            selectTxt.Append("FROM STOCKMOVERF AS STMOVE WITH (READUNCOMMITTED) --�݌Ɉړ��f�[�^").Append(Environment.NewLine);
            return selectTxt.ToString();

        }

        /// <summary>
        /// �ړ��f�[�^�̊i�[
        /// </summary>
        /// <returns>�ړ��f�[�^</returns>
        /// <remarks>
        /// <br>Note       : �ړ��f�[�^�̊i�[���s���B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// <br>Update Note : PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2020/06/18</br>
        /// </remarks>
        //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
        //private PartsMaxStockArrivalWork CopyMoveDataFromSqlDataReader(SqlDataReader myReader)
        private PartsMaxStockArrivalWork CopyMoveDataFromSqlDataReader(SqlDataReader myReader, ConvertDoubleRelease convertDoubleRelease)
        //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<
        {
            PartsMaxStockArrivalWork moveDataExportResultWork = new PartsMaxStockArrivalWork();

            #region �������ʂ̊i�[
            moveDataExportResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            moveDataExportResultWork.ShipDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTFIXDAYRF"));
            moveDataExportResultWork.StockMoveSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVESLIPNORF"));
            moveDataExportResultWork.StockMoveSlipRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEROWNORF"));
            moveDataExportResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            moveDataExportResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            moveDataExportResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            moveDataExportResultWork.GoodsMakerNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            moveDataExportResultWork.BLGoodsCod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            moveDataExportResultWork.ShipmentCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVECOUNTRF"));
            moveDataExportResultWork.BfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONCODERF")).Trim();
            moveDataExportResultWork.BfSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONGUIDESNMRF"));
            moveDataExportResultWork.BfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHCODERF")).Trim();
            moveDataExportResultWork.BfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHNAMERF"));
            moveDataExportResultWork.AfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONCODERF")).Trim();
            moveDataExportResultWork.AfSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONGUIDESNMRF"));
            moveDataExportResultWork.AfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHCODERF")).Trim();
            moveDataExportResultWork.AfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHNAMERF"));
            moveDataExportResultWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));// �I�[�v�����i�敪
            moveDataExportResultWork.PriceStartDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
            //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
            //moveDataExportResultWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
            convertDoubleRelease.EnterpriseCode = moveDataExportResultWork.EnterpriseCode;
            convertDoubleRelease.GoodsMakerCd = moveDataExportResultWork.GoodsMakerCd;
            convertDoubleRelease.GoodsNo = moveDataExportResultWork.GoodsNo;
            convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));

            // �ϊ��������s
            convertDoubleRelease.ReleaseProc();

            moveDataExportResultWork.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
            //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<
            moveDataExportResultWork.GpuSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));// ���i�}�X�^�̌����P��
            moveDataExportResultWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
            moveDataExportResultWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
            moveDataExportResultWork.UpdateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATEDATERF"));
            moveDataExportResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));// ���_�R�[�h
            moveDataExportResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));// �d����R�[�h
            moveDataExportResultWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));//���i�|���O���[�v�R�[�h
            moveDataExportResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));//BL�O���[�v�R�[�h
            moveDataExportResultWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));//���i�����ރR�[�h
            moveDataExportResultWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));//���i�|�������N
            moveDataExportResultWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));//�ېŋ�

            #endregion

            return moveDataExportResultWork;
        }
        #endregion

    }
}
