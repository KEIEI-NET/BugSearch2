//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�}�X�^�i�e�L�X�g�ϊ��j
// �v���O�����T�v   : ���i�}�X�^�e�L�X�g�ϊ�  �����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902160-00  �쐬�S�� : ���z
// �� �� ��  K2013/08/08  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670219-00  �쐬�S�� : ������
// �C �� ��  2020/08/20   �C�����e : PMKOBETSU-4005 ���i�}�X�^�@�艿���l�ϊ��Ή�
//----------------------------------------------------------------------------//
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
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���i�}�X�^�e�L�X�g�ϊ�  �����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�}�X�^�e�L�X�g�ϊ��̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���z</br>
    /// <br>Date       : K2013/08/08</br>
    /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2020/08/20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class GoodsTextExpDB : RemoteDB, IGoodsTextExpDB
    {
        #region [Constructor]
        /// <summary>
        /// ���i�}�X�^�e�L�X�g�ϊ�  �����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���z</br>
        /// <br>Date       : K2013/08/08</br>
        /// <br></br>
        /// <br>Update Note:</br>
        /// </remarks>
        public GoodsTextExpDB()
            :
            base("PMKHN09196DC", "Broadleaf.Application.Remoting.ParamData.GoodsTextExpRetWork", "GOODSURF")
        {
        }
        #endregion

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̏��i�}�X�^LIST��߂��܂�
        /// </summary>
        /// <param name="goodsTextExpRetWork">��������</param>
        /// <param name="goodsTextExpWork">��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�}�X�^LIST��߂��܂�</br>
        /// <br>Programmer : ���z</br>
        /// <br>Date       : K2013/08/08</br>
        public int Search(out object goodsTextExpRetWork, object goodsTextExpWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            goodsTextExpRetWork = null;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchProc(out goodsTextExpRetWork, goodsTextExpWork, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsTextExpDB.Search");
                goodsTextExpRetWork = new ArrayList();
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
        #endregion

        #region [SearchProc]
        /// <summary>
        /// �w�肳�ꂽ�����̏��i�}�X�^LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsTextExpRetWorkList">��������</param>
        /// <param name="goodsTextExpWork">��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�}�X�^LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���z</br>
        /// <br>Date       : K2013/08/08</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2020/08/20</br>
        private int SearchProc(out object goodsTextExpRetWorkList, object goodsTextExpWork, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList retList = new ArrayList();

            //----- ADD 2020/08/20 ������ PMKOBETSU-4005 ---------->>>>>
            // �ϊ����Ăяo��
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // �ϊ���񏉊���
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/08/20 ������ PMKOBETSU-4005 ----------<<<<<

            try
            {
                GoodsTextExpWork paraWork = goodsTextExpWork as GoodsTextExpWork;
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // �Ώۃe�[�u��
                // GOODSURF      GODSU    ���i�}�X�^�i���[�U�[�o�^�j
                // GOODSPRICEURF GODSP    ���i�}�X�^�i���[�U�[�o�^�j
                // BLGOODSCDURF  BLGODSU  �a�k���i�R�[�h�}�X�^(���[�U�[�o�^)
                // BLGROUPURF    BLGRPU   �a�k�O���[�v�}�X�^�i���[�U�[�o�^�j

                #region [Select���쐬]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   GODSU.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,GODSU.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,GODSU.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,BLGODSU.BLGOODSFULLNAMERF" + Environment.NewLine;
                selectTxt += "  ,BLGODSU.BLGOODSHALFNAMERF" + Environment.NewLine;
                selectTxt += "  ,BLGODSU.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "  ,BLGODSU.GOODSRATEGRPCODERF" + Environment.NewLine;
                selectTxt += "  ,BLGRPU.BLGROUPNAMERF" + Environment.NewLine;
                selectTxt += "  ,BLGRPU.BLGROUPKANANAMERF" + Environment.NewLine;
                selectTxt += "  ,GODSU.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "  ,GODSP.PRICESTARTDATERF" + Environment.NewLine;
                selectTxt += "  ,MAXGODSP.SETPRICESTARTDATERF" + Environment.NewLine;
                selectTxt += "  ,GODSP.LISTPRICERF" + Environment.NewLine;
                selectTxt += "  ,GODSP.STOCKRATERF" + Environment.NewLine;
                selectTxt += "  ,GODSP.SALESUNITCOSTRF" + Environment.NewLine;
                selectTxt += " FROM GOODSURF AS GODSU WITH (READUNCOMMITTED)" + Environment.NewLine;

                //JOIN
                //���i�}�X�^�i���[�U�[�o�^�j
                selectTxt += " LEFT JOIN GOODSPRICEURF GODSP WITH (READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += " ON  GODSP.ENTERPRISECODERF=GODSU.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GODSP.GOODSMAKERCDRF=GODSU.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND GODSP.GOODSNORF=GODSU.GOODSNORF" + Environment.NewLine;
                selectTxt += " AND GODSP.LOGICALDELETECODERF=GODSU.LOGICALDELETECODERF" + Environment.NewLine;

                //���i�}�X�^�i���[�U�[�o�^�j ���i�J�n���i�ŐV�j
                selectTxt += " LEFT JOIN (" + Environment.NewLine;
                selectTxt += " SELECT ENTERPRISECODERF, GOODSMAKERCDRF, GOODSNORF, LOGICALDELETECODERF, MAX(PRICESTARTDATERF) AS SETPRICESTARTDATERF" + Environment.NewLine;
                selectTxt += " FROM GOODSPRICEURF WITH (READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += " WHERE GOODSPRICEURF.PRICESTARTDATERF <= @PRICESTARTDATE" + Environment.NewLine;
                selectTxt += " GROUP BY ENTERPRISECODERF, GOODSMAKERCDRF, GOODSNORF, LOGICALDELETECODERF) MAXGODSP" + Environment.NewLine;
                selectTxt += " ON  MAXGODSP.ENTERPRISECODERF=GODSP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND MAXGODSP.GOODSMAKERCDRF=GODSP.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND MAXGODSP.GOODSNORF=GODSP.GOODSNORF" + Environment.NewLine;
                selectTxt += " AND MAXGODSP.LOGICALDELETECODERF=GODSP.LOGICALDELETECODERF" + Environment.NewLine;

                //�a�k���i�R�[�h�}�X�^(���[�U�[�o�^)
                selectTxt += " LEFT JOIN BLGOODSCDURF BLGODSU WITH (READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += " ON  BLGODSU.ENTERPRISECODERF=GODSU.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND BLGODSU.BLGOODSCODERF=GODSU.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += " AND BLGODSU.LOGICALDELETECODERF=GODSU.LOGICALDELETECODERF" + Environment.NewLine;

                //�a�k�O���[�v�}�X�^�i���[�U�[�o�^�j
                selectTxt += " LEFT JOIN BLGROUPURF BLGRPU WITH (READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += " ON  BLGRPU.ENTERPRISECODERF=BLGODSU.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND BLGRPU.BLGROUPCODERF=BLGODSU.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += " AND BLGRPU.LOGICALDELETECODERF=BLGODSU.LOGICALDELETECODERF" + Environment.NewLine;

                //WHERE
                selectTxt += MakeWhereString(ref sqlCommand, paraWork, logicalMode);

                //ORDER BY
                selectTxt += " ORDER BY GODSU.GOODSNORF, GODSU.GOODSMAKERCDRF";
                #endregion  //[Select���쐬]

                sqlCommand.CommandText = selectTxt;
                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ---------->>>>>
                    //retList.Add(CopyToGoodsTextExpRetWorkFromReader(ref myReader, paraWork));
                    retList.Add(CopyToGoodsTextExpRetWorkFromReader(ref myReader, paraWork, convertDoubleRelease));
                    // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ----------<<<<<
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
                base.WriteErrorLog(ex, "GoodsPrintDB.SearchProc Exception=" + ex.Message);
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

                //----- ADD 2020/08/20 ������ PMKOBETSU-4005 ---------->>>>>
                // ���
                convertDoubleRelease.Dispose();
                //----- ADD 2020/08/20 ������ PMKOBETSU-4005 ----------<<<<<
            }

            goodsTextExpRetWorkList = retList;
            return status;
        }
        #endregion

        #region [WHERE�吶������]
        /// <summary>
        /// WHERE�吶������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="goodsTextExpWork">��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns></returns>
        /// <br>Note       : WHERE�吶������</br>
        /// <br>Programmer : ���z</br>
        /// <br>Date       : K2013/08/08</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, GoodsTextExpWork goodsTextExpWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = "";
            retstring += " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " GODSU.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsTextExpWork.EnterpriseCode);

            //�_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND GODSU.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND GODSU.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //���i���[�J�[�R�[�h
            if (goodsTextExpWork.GoodsMakerCdSt != 0)
            {
                retstring += " AND GODSU.GOODSMAKERCDRF>=@GOODSMAKERCDST" + Environment.NewLine;
                SqlParameter paraGoodsMakerCdSt = sqlCommand.Parameters.Add("@GOODSMAKERCDST", SqlDbType.Int);
                paraGoodsMakerCdSt.Value = SqlDataMediator.SqlSetInt32(goodsTextExpWork.GoodsMakerCdSt);
            }
            if ((goodsTextExpWork.GoodsMakerCdEd != 0) && (goodsTextExpWork.GoodsMakerCdEd != 9999))
            {
                retstring += " AND GODSU.GOODSMAKERCDRF<=@GOODSMAKERCDED" + Environment.NewLine;
                SqlParameter paraGoodsMakerCdEd = sqlCommand.Parameters.Add("@GOODSMAKERCDED", SqlDbType.Int);
                paraGoodsMakerCdEd.Value = SqlDataMediator.SqlSetInt32(goodsTextExpWork.GoodsMakerCdEd);
            }

            //BL���i�R�[�h
            if (goodsTextExpWork.BLGoodsCodeSt != 0)
            {
                retstring += " AND GODSU.BLGOODSCODERF>=@BLGOODSCODEST" + Environment.NewLine;
                SqlParameter paraBLGoodsCodeSt = sqlCommand.Parameters.Add("@BLGOODSCODEST", SqlDbType.Int);
                paraBLGoodsCodeSt.Value = SqlDataMediator.SqlSetInt32(goodsTextExpWork.BLGoodsCodeSt);
            }
            if ((goodsTextExpWork.BLGoodsCodeEd != 0) && (goodsTextExpWork.BLGoodsCodeEd != 99999))
            {
                retstring += " AND GODSU.BLGOODSCODERF<=@BLGOODSCODEED" + Environment.NewLine;
                SqlParameter paraBLGoodsCodeEd = sqlCommand.Parameters.Add("@BLGOODSCODEED", SqlDbType.Int);
                paraBLGoodsCodeEd.Value = SqlDataMediator.SqlSetInt32(goodsTextExpWork.BLGoodsCodeEd);
            }

            //���i�ԍ�
            if (goodsTextExpWork.GoodsNoSt != "")
            {
                if (goodsTextExpWork.GoodsNoSt.LastIndexOf("*") >= 0)
                {
                    String[] GoodsNoSt = goodsTextExpWork.GoodsNoSt.Split(new Char[] { '*' });

                    retstring += " AND ( GODSU.GOODSNORF>=@GOODSNOST OR GODSU.GOODSNORF LIKE @GOODSNOST )" + Environment.NewLine;
                    SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@GOODSNOST", SqlDbType.NVarChar);
                    paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(GoodsNoSt[0] + "%");

                }
                else
                {
                    retstring += " AND GODSU.GOODSNORF>=@GOODSNOST" + Environment.NewLine;
                    SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@GOODSNOST", SqlDbType.NVarChar);
                    paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(goodsTextExpWork.GoodsNoSt);
                }
            }
            if (goodsTextExpWork.GoodsNoEd != "")
            {
                if (goodsTextExpWork.GoodsNoEd.LastIndexOf("*") >= 0)
                {
                    String[] GoodsNoEd = goodsTextExpWork.GoodsNoEd.Split(new Char[] { '*' });

                    retstring += " AND (GODSU.GOODSNORF<=@GOODSNOED OR GODSU.GOODSNORF LIKE @GOODSNOED )" + Environment.NewLine;
                    SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@GOODSNOED", SqlDbType.NVarChar);
                    paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(GoodsNoEd[0] + "%");
                }
                else
                {
                    retstring += " AND GODSU.GOODSNORF<=@GOODSNOED" + Environment.NewLine;
                    SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@GOODSNOED", SqlDbType.NVarChar);
                    paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(goodsTextExpWork.GoodsNoEd);
                }
            }

            //�o�^���t
            if (goodsTextExpWork.UpdateDateSt != 0)
            {
                retstring += " AND GODSU.UPDATEDATERF>=@UPDATEDATEST" + Environment.NewLine;
                SqlParameter paraUpdateDateSt = sqlCommand.Parameters.Add("@UPDATEDATEST", SqlDbType.Int);
                paraUpdateDateSt.Value = SqlDataMediator.SqlSetInt32(goodsTextExpWork.UpdateDateSt);
            }
            if ((goodsTextExpWork.UpdateDateEd != 0) && (goodsTextExpWork.UpdateDateEd != 99999999))
            {
                retstring += " AND GODSU.UPDATEDATERF<=@UPDATEDATEED" + Environment.NewLine;
                SqlParameter paraUpdateDateEd = sqlCommand.Parameters.Add("@UPDATEDATEED", SqlDbType.Int);
                paraUpdateDateEd.Value = SqlDataMediator.SqlSetInt32(goodsTextExpWork.UpdateDateEd);
            }

            //���i�J�n��
            SqlParameter paraPriceStartDate = sqlCommand.Parameters.Add("@PRICESTARTDATE", SqlDbType.Int);
            paraPriceStartDate.Value = SqlDataMediator.SqlSetInt32(goodsTextExpWork.PriceStartDate);

            #endregion

            return retstring;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� GoodsTextExpRetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="goodsTextExpWork">��������</param>
        /// <param name="convertDoubleRelease">���l�ϊ�����</param>
        /// <returns>GoodsTextExpRetWork</returns>
        /// <remarks>
        /// <br>Programmer : ���z</br>
        /// <br>Date       : K2013/08/08</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2020/08/20</br>
        /// </remarks>
        // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ---------->>>>>
        //private GoodsTextExpRetWork CopyToGoodsTextExpRetWorkFromReader(ref SqlDataReader myReader, GoodsTextExpWork goodsTextExpWork)
        private GoodsTextExpRetWork CopyToGoodsTextExpRetWorkFromReader(ref SqlDataReader myReader, GoodsTextExpWork goodsTextExpWork, ConvertDoubleRelease convertDoubleRelease)
        // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ----------<<<<<
        {
            GoodsTextExpRetWork ResultWork = new GoodsTextExpRetWork();

            #region �N���X�֊i�[
            ResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            ResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            ResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            ResultWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            ResultWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
            ResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            ResultWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));
            ResultWork.BLGroupKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPKANANAMERF"));
            ResultWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));
            ResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            ResultWork.PriceStartDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
            ResultWork.SetPriceStartDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETPRICESTARTDATERF"));
            // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ---------->>>>>
            //ResultWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
            convertDoubleRelease.EnterpriseCode = goodsTextExpWork.EnterpriseCode;
            convertDoubleRelease.GoodsMakerCd = ResultWork.GoodsMakerCd;
            convertDoubleRelease.GoodsNo = ResultWork.GoodsNo;
            convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));

            // �ϊ��������s
            convertDoubleRelease.ReleaseProc();

            ResultWork.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
            // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ----------<<<<<
            ResultWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
            ResultWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
            #endregion

            return ResultWork;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ���z</br>
        /// <br>Date       : K2013/08/08</br>
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
        #endregion
    }
}
