//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �s�a�n���o��
// �v���O�����T�v   : �s�a�n���o�� DB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11270029-00  �쐬�S�� : ������
// �� �� �� : 2016/05/20   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11670219-00  �쐬�S�� : 杍^
// �� �� �� : 2020/11/02   �C�����e : PMKOBETSU-4005 �d�a�d�΍�
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
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �s�a�n���o��DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note        : �s�a�n���o�͂̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer  : ������</br>
    /// <br>Date        : 2016/05/20</br>
    /// <br>Update Note : PMKOBETSU-4005 �d�a�d�΍�</br>
    /// <br>Programmer  : 杍^</br>
    /// <br>Date        : 2020/11/02</br>
    /// </remarks>
    [Serializable]
    public class TBODataExportDB : RemoteDB, ITBODataExportDB
    {
        #region TBODataExportDB
        /// <summary>
        /// �s�a�n���o�̓R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���ɂȂ�</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        public TBODataExportDB()
        {
        }
        #endregion

        #region TBO�f�[�^�̌���
        /// <summary>
        /// �s�a�n���o�͏�񃊃X�g�̎擾����
        /// </summary>
        /// <param name="TBOExportResultWork">TBO�f�[�^����</param>
        /// <param name="TBODataExportCondWork">�����p�����[�^</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �s�a�n���o�͏�񃊃X�g(TBO�f�[�^)���擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        public int SearchTBOData(out object TBOExportResultWork, object TBODataExportCondWork, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            TBOExportResultWork = null;
            errMessage = string.Empty;
            try
            {
                // �R�l�N�V��������
                using (SqlConnection sqlConnection = CreateSqlConnection(true))
                {
                    // ��������
                    status = SearchTBODataProc(ref TBOExportResultWork, TBODataExportCondWork, out errMessage, sqlConnection);
                }

            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                base.WriteErrorLog(ex, ex.Message);
            }

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̂s�a�n���ނ�S�Ė߂鏈��
        /// </summary>
        /// <param name="TBOExportResultWork">TBO�f�[�^����</param>
        /// <param name="TBODataExportCondWork">�����p�����[�^</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̂s�a�n���ނ�S�Ė߂�B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2016/05/20</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/11/02</br>
        /// </remarks>
        private int SearchTBODataProc(ref object TBOExportResultWork, object TBODataExportCondWork, out string errMessage, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            
            errMessage = string.Empty;
            TBODataExportCond cndtnWork = TBODataExportCondWork as TBODataExportCond;
            ArrayList al = new ArrayList(); 

            //----- ADD 2020/11/02 杍^ PMKOBETSU-4005 ---------->>>>>
            // �ϊ����Ăяo��
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // �ϊ���񏉊���
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/11/02 杍^ PMKOBETSU-4005 ----------<<<<<

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection))
                {
                    // �����N�G�����̍\�z
                    sqlCommand.CommandText = MakeSelectTBOString(sqlCommand, cndtnWork);

                    // �N�G�����s���̃^�C���A�E�g���Ԃ�3600�b�ɐݒ肷��
                    sqlCommand.CommandTimeout = 3600;
                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            // ���o����-�l�Z�b�g
                            //----- UPD 2020/11/02 杍^ PMKOBETSU-4005 ---------->>>>>
                            //al.Add(CopyTBODataFromSqlDataReader(myReader));
                            al.Add(CopyTBODataFromSqlDataReader(myReader, convertDoubleRelease, cndtnWork));
                            //----- UPD 2020/11/02 杍^ PMKOBETSU-4005 ----------<<<<<
                        }
                    }

                    if (al.Count == 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
            }
            catch (SqlException ex)
            {
                errMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteSQLErrorLog(ex, ex.Message, ex.Number);
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            //----- ADD 2020/11/02 杍^ PMKOBETSU-4005 ---------->>>>>
            finally
            {
                // ���
                convertDoubleRelease.Dispose();
            }
            //----- ADD 2020/11/02 杍^ PMKOBETSU-4005 ----------<<<<<

            TBOExportResultWork = al;

            return status;
        }

        /// <summary>
        /// TBO�f�[�^�̃N�G�����̍\�z
        /// </summary>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="cndtnWork">��������</param>
        /// <returns>�N�G����</returns>
        /// <remarks>
        /// <br>Note       : TBO�f�[�^�̃N�G�����̍\�z���s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private string MakeSelectTBOString(SqlCommand sqlCommand, TBODataExportCond cndtnWork)
        {
            StringBuilder sqlText = new StringBuilder();

            sqlText.AppendLine(" SELECT GOODSURF.GOODSNORF, "); // ���i�ԍ�
            sqlText.AppendLine(" GOODSURF.GOODSNAMERF, "); // ���i����
            sqlText.AppendLine(" GOODSURF.GOODSMAKERCDRF, "); // ���i���[�J�[�R�[�h
            sqlText.AppendLine(" (CASE WHEN GOODSURF.UPDATEDATETIMERF < STK2.UPDATEDATETIMERF AND STK2.UPDATEDATETIMERF IS NOT NULL ");
            sqlText.AppendLine(" THEN STK2.UPDATEDATETIMERF  ");
            sqlText.AppendLine(" ELSE GOODSURF.UPDATEDATETIMERF ");
            sqlText.AppendLine(" END) AS UPDATEDATETIMERF, "); // �X�V�N����
            sqlText.AppendLine(" GOODSURF.BLGOODSCODERF, "); // BL���i�R�[�h
            sqlText.AppendLine(" GS.PARENTGOODSNORF, "); // �e���i�ԍ�
            sqlText.AppendLine(" BLGOODSCDURF.GOODSRATEGRPCODERF, "); // ���i�����ރR�[�h
            sqlText.AppendLine(" MAKERURF.MAKERNAMERF, "); // ���[�J�[����
            sqlText.AppendLine(" GOODSPRICEURF.LISTPRICERF, "); // �艿�i�����j
            sqlText.AppendLine(" GOODSPRICEURF.SALESUNITCOSTRF, "); // �����P��
            sqlText.AppendLine(" SUM_STOCKRF.SUM_SHIPMENTPOSCNTRF, "); // �o�׉\��
            sqlText.AppendLine(" SUM_STOCKRF.SUM_MINIMUMSTOCKCNTRF "); // �Œ�݌ɐ�
            sqlText.AppendLine(" FROM ( ");
            sqlText.AppendLine("    SELECT ");
            sqlText.AppendLine("        ENTERPRISECODERF,");
            sqlText.AppendLine("        PARENTGOODSNORF, ");
            sqlText.AppendLine("        SUBGOODSNORF, ");
            sqlText.AppendLine("        SUBGOODSMAKERCDRF, ");
            sqlText.AppendLine("        ROW_NUMBER() OVER(PARTITION BY SUBGOODSNORF,SUBGOODSMAKERCDRF ORDER BY PARENTGOODSNORF) AS ROWNUM ");
            sqlText.AppendLine("    FROM GOODSSETRF WITH (READUNCOMMITTED) ");
            sqlText.AppendLine(" ) AS GS ");
            sqlText.AppendLine(" INNER JOIN GOODSURF WITH (READUNCOMMITTED) ");
            sqlText.AppendLine(" ON GOODSURF.GOODSNORF = GS.SUBGOODSNORF ");
            sqlText.AppendLine(" AND GOODSURF.GOODSMAKERCDRF = GS.SUBGOODSMAKERCDRF ");
            sqlText.AppendLine(" AND GOODSURF.ENTERPRISECODERF = GS.ENTERPRISECODERF ");
            sqlText.AppendLine(" LEFT JOIN BLGOODSCDURF WITH (READUNCOMMITTED) ");
            sqlText.AppendLine(" ON GOODSURF.BLGOODSCODERF = BLGOODSCDURF.BLGOODSCODERF  ");
            sqlText.AppendLine(" AND GOODSURF.ENTERPRISECODERF = BLGOODSCDURF.ENTERPRISECODERF ");
            sqlText.AppendLine(" LEFT JOIN MAKERURF WITH (READUNCOMMITTED) ");
            sqlText.AppendLine(" ON GOODSURF.GOODSMAKERCDRF = MAKERURF.GOODSMAKERCDRF ");
            sqlText.AppendLine(" AND GOODSURF.ENTERPRISECODERF = MAKERURF.ENTERPRISECODERF ");
            sqlText.AppendLine(" LEFT JOIN GOODSPRICEURF WITH (READUNCOMMITTED) ");
            sqlText.AppendLine(" ON GOODSURF.GOODSNORF = GOODSPRICEURF.GOODSNORF ");
            sqlText.AppendLine(" AND GOODSURF.GOODSMAKERCDRF = GOODSPRICEURF.GOODSMAKERCDRF ");
            sqlText.AppendLine(" AND GOODSURF.ENTERPRISECODERF = GOODSPRICEURF.ENTERPRISECODERF ");
            sqlText.AppendLine(" LEFT JOIN ( ");
            sqlText.AppendLine("    SELECT ENTERPRISECODERF, ");
            sqlText.AppendLine("        GOODSMAKERCDRF, ");
            sqlText.AppendLine("        GOODSNORF, ");
            sqlText.AppendLine("        SECTIONCODERF, ");
            sqlText.AppendLine("        SUM(SHIPMENTPOSCNTRF) AS SUM_SHIPMENTPOSCNTRF, ");
            sqlText.AppendLine("        SUM(MINIMUMSTOCKCNTRF) AS SUM_MINIMUMSTOCKCNTRF ");
            sqlText.AppendLine("    FROM STOCKRF WITH (READUNCOMMITTED) ");
            sqlText.AppendLine("    WHERE SECTIONCODERF = @SECTIONCODE ");
            sqlText.AppendLine("    GROUP BY ENTERPRISECODERF, ");
            sqlText.AppendLine("        GOODSMAKERCDRF, ");
            sqlText.AppendLine("        GOODSNORF, ");
            sqlText.AppendLine("        SECTIONCODERF ");
            sqlText.AppendLine(" ) AS SUM_STOCKRF ");
            sqlText.AppendLine(" ON GOODSURF.GOODSNORF = SUM_STOCKRF.GOODSNORF ");
            sqlText.AppendLine(" AND GOODSURF.GOODSMAKERCDRF = SUM_STOCKRF.GOODSMAKERCDRF ");
            sqlText.AppendLine(" AND GOODSURF.ENTERPRISECODERF = SUM_STOCKRF.ENTERPRISECODERF ");
            sqlText.AppendLine(" LEFT JOIN ( ");
            sqlText.AppendLine("    SELECT ENTERPRISECODERF, ");
            sqlText.AppendLine("        GOODSMAKERCDRF, ");
            sqlText.AppendLine("        GOODSNORF, ");
            sqlText.AppendLine("        SECTIONCODERF, ");
            sqlText.AppendLine("        MAX(UPDATEDATETIMERF) AS UPDATEDATETIMERF ");
            sqlText.AppendLine("    FROM STOCKRF WITH (READUNCOMMITTED) ");
            sqlText.AppendLine("    WHERE SECTIONCODERF = @SECTIONCODE ");
            sqlText.AppendLine("    GROUP BY ENTERPRISECODERF, ");
            sqlText.AppendLine("        GOODSMAKERCDRF, ");
            sqlText.AppendLine("        GOODSNORF, ");
            sqlText.AppendLine("        SECTIONCODERF ");
            sqlText.AppendLine(" ) AS STK2 ");
            sqlText.AppendLine(" ON STK2.GOODSNORF = SUM_STOCKRF.GOODSNORF ");
            sqlText.AppendLine(" AND STK2.GOODSMAKERCDRF = SUM_STOCKRF.GOODSMAKERCDRF ");
            sqlText.AppendLine(" AND STK2.ENTERPRISECODERF = SUM_STOCKRF.ENTERPRISECODERF ");
            sqlText.AppendLine(" AND STK2.SECTIONCODERF = SUM_STOCKRF.SECTIONCODERF ");
            sqlText.AppendLine(" INNER JOIN ( ");
            sqlText.AppendLine("    SELECT GOODSPRICES.GOODSMAKERCDRF, ");
            sqlText.AppendLine("        GOODSPRICES.GOODSNORF, ");
            sqlText.AppendLine("        MAX(GOODSPRICES.PRICESTARTDATERF) AS MAX_PRICESTARTDATERF ");
            sqlText.AppendLine("    FROM ( ");
            sqlText.AppendLine("        SELECT GOODSMAKERCDRF, ");
            sqlText.AppendLine("            GOODSNORF, ");
            sqlText.AppendLine("            PRICESTARTDATERF ");
            sqlText.AppendLine("        FROM GOODSPRICEURF WITH (READUNCOMMITTED) ");
            sqlText.AppendLine("        WHERE PRICESTARTDATERF <= @PRICESTART ");
            sqlText.AppendLine("    ) AS GOODSPRICES ");
            sqlText.AppendLine("    GROUP BY ");
            sqlText.AppendLine("        GOODSPRICES.GOODSMAKERCDRF, ");
            sqlText.AppendLine("        GOODSPRICES.GOODSNORF ");
            sqlText.AppendLine(" ) AS GOODSPRICEURF2 ");
            sqlText.AppendLine(" ON GOODSURF.GOODSNORF = GOODSPRICEURF2.GOODSNORF ");
            sqlText.AppendLine(" AND GOODSURF.GOODSMAKERCDRF = GOODSPRICEURF2.GOODSMAKERCDRF ");
            sqlText.AppendLine(" AND GOODSPRICEURF.PRICESTARTDATERF = GOODSPRICEURF2.MAX_PRICESTARTDATERF ");

            //Where��
            sqlText.Append(MakeTBOWhereString(sqlCommand, cndtnWork));

            return sqlText.ToString();
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="cndtnWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <remarks>
        /// <br>Note        : �������������񐶐��{�����l�ݒ���s���B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        private string MakeTBOWhereString(SqlCommand sqlCommand, TBODataExportCond cndtnWork)
        {
            #region WHERE���쐬
            StringBuilder retstring = new StringBuilder(" WHERE ");

            // ��ƃR�[�h
            retstring.AppendLine(" GS.ENTERPRISECODERF = @ENTERPRISECODERF ");
            // �Z�b�g�}�X�^�̎q���[�J�[+�q�i�ԂŃO���[�s���O�����擪1�s�ڂ��̗p
            retstring.AppendLine(" AND GS.ROWNUM = 1 ");
            // ���i�����ރR�[�h
            if (cndtnWork.GoodsMGroup.Count > 0)
            {
                retstring.AppendLine(" AND BLGOODSCDURF.GOODSRATEGRPCODERF IN( ");
                retstring.AppendLine(String.Join(",", (string[])cndtnWork.GoodsMGroup.ToArray(typeof(string))));
                retstring.AppendLine(" ) ");
            }
            // �i��
            if (!String.IsNullOrEmpty(cndtnWork.GoodsNo))
            {
                retstring.AppendLine(" AND GS.PARENTGOODSNORF LIKE @GOODSNO ");
            }
            // ���[�J�[
            if (cndtnWork.GoodsMakerCd_ST != 0)
            {
                retstring.AppendLine(" AND GS.SUBGOODSMAKERCDRF >= @MAKERCODE_ST ");
            }
            if (cndtnWork.GoodsMakerCd_ED != 9999)
            {
                retstring.AppendLine(" AND GS.SUBGOODSMAKERCDRF <= @MAKERCODE_ED ");
            }

            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
            paraGoodsNo.Value = SqlDataMediator.SqlSetString(String.Format("%{0}%", EscapeLike(cndtnWork.GoodsNo)));
            SqlParameter paraMakerCode_St = sqlCommand.Parameters.Add("@MAKERCODE_ST", SqlDbType.Int);
            paraMakerCode_St.Value = SqlDataMediator.SqlSetInt(cndtnWork.GoodsMakerCd_ST);
            SqlParameter paraMakerCode_Ed = sqlCommand.Parameters.Add("@MAKERCODE_ED", SqlDbType.Int);
            paraMakerCode_Ed.Value = SqlDataMediator.SqlSetInt(cndtnWork.GoodsMakerCd_ED);
            SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
            paraSectionCode.Value = SqlDataMediator.SqlSetString(cndtnWork.SectionCodeRF);
            SqlParameter paraPriceStartDate = sqlCommand.Parameters.Add("@PRICESTART", SqlDbType.Int);
            paraPriceStartDate.Value = SqlDataMediator.SqlSetInt(cndtnWork.PriceStartDate);
            SqlParameter paraEnterpriSecode = sqlCommand.Parameters.Add("@ENTERPRISECODERF", SqlDbType.NChar);
            paraEnterpriSecode.Value = SqlDataMediator.SqlSetString(cndtnWork.EnterpriseCode);

            #endregion

            return retstring.ToString();
        }

        /// <summary>
        /// TBO�f�[�^�̊i�[
        /// </summary>
        /// <param name="myReader">��������</param>
        /// <returns>TBO�f�[�^</returns>
        /// <remarks>
        /// <br>Note       : TBO�f�[�^�̊i�[���s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2016/05/20</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/11/02</br>
        /// </remarks>
        //----- UPD 2020/11/02 杍^ PMKOBETSU-4005 ---------->>>>>
        //private TBODataExportResultWork CopyTBODataFromSqlDataReader(SqlDataReader myReader)
        private TBODataExportResultWork CopyTBODataFromSqlDataReader(SqlDataReader myReader, ConvertDoubleRelease convertDoubleRelease, TBODataExportCond cndtnWork)
        //----- UPD 2020/11/02 杍^ PMKOBETSU-4005 ----------<<<<<
        {
            TBODataExportResultWork TBODataExportResultWork = new TBODataExportResultWork();

            #region �������ʂ̊i�[
            TBODataExportResultWork.GoodsCategoryRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF")); // ���i�J�e�S��
            TBODataExportResultWork.GoodsNoRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF")); // ���i�ԍ�
            TBODataExportResultWork.GoodsNameRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF")); // ���i����
            TBODataExportResultWork.GoodsMakerCdRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF")); // ���i���[�J�[�R�[�h
            TBODataExportResultWork.MakerNameRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF")); // ���[�J�[����
            //----- UPD 2020/11/02 杍^ PMKOBETSU-4005 ---------->>>>>
            //TBODataExportResultWork.SuggestPriceRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF")); // ��]�������i
            convertDoubleRelease.EnterpriseCode = cndtnWork.EnterpriseCode;
            convertDoubleRelease.GoodsMakerCd = TBODataExportResultWork.GoodsMakerCdRF;
            convertDoubleRelease.GoodsNo = TBODataExportResultWork.GoodsNoRF;
            convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF")); // ��]�������i

            // �ϊ��������s
            convertDoubleRelease.ReleaseProc();

            TBODataExportResultWork.SuggestPriceRF = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
            //----- UPD 2020/11/02 杍^ PMKOBETSU-4005 ----------<<<<<
            TBODataExportResultWork.PurchaseCostRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF")); // �d������
            TBODataExportResultWork.PMUpdateTimeRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("UPDATEDATETIMERF")); // PM�X�V����
            TBODataExportResultWork.SearchTag1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARENTGOODSNORF")); // �����^�O1 
            TBODataExportResultWork.ShipmentPosCntRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUM_SHIPMENTPOSCNTRF")); // �o�׉\��
            TBODataExportResultWork.BLGoodsCodeRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF")); // BL���i�R�[�h
            TBODataExportResultWork.MinimumStockCntRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUM_MINIMUMSTOCKCNTRF")); // �Œ�݌ɐ�
            #endregion

            return TBODataExportResultWork;
        }

        /// <summary>
        /// LIKE�����̕����G�X�P�[�v
        /// </summary>
        /// <param name="targetValue">�G�X�P�[�v�Ώۂ̏����l</param>
        /// <returns>�G�X�P�[�v��̏����l</returns>
         /// <remarks>
        /// <br>Note       : LIKE�����̃G�X�P�[�v</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private string EscapeLike(string targetValue)
        {
            if (String.IsNullOrEmpty(targetValue)) return String.Empty;

            return targetValue.Replace("%", "[%]").Replace("_", "[_]").Replace("[", "[[]");
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ����� false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Note        : SqlConnection���������B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            //SqlConnection����
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            //SqlConnection�ڑ�
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            //SqlConnection�Ԃ�
            return retSqlConnection;
        }
        #endregion
    }
}
