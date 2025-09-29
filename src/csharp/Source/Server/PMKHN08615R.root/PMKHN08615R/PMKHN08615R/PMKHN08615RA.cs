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
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���i�}�X�^���  �����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�}�X�^����̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2008.11.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br>Update Note: �A�� 810 zhouyu </br>
    /// <br>Date       : 2011/08/12 </br>
    /// <br></br>
    /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2020/06/18</br>
    /// </remarks>
    [Serializable]
    public class GoodsPrintDB : RemoteDB, IGoodsPrintDB
    {
        /// <summary>
        /// ���i�}�X�^���  �����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.11</br>
        /// <br></br>
        /// <br>Update Note:</br>
        /// <br>Update Note: �A�� 810 zhouyu </br>
        /// <br>Date       : 2011/08/12 </br>
        /// </remarks>
        public GoodsPrintDB()
            :
            base("PMKHN08617D", "Broadleaf.Application.Remoting.ParamData.GoodsPrintResultWork", "GOODSURF")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̊|���}�X�^LIST��߂��܂�
        /// </summary>
        /// <param name="paraGoodsPrintResultWork">��������</param>
        /// <param name="paraGoodsPrintParamWork">��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̊|���}�X�^LIST��߂��܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.11</br>
        public int Search(out object paraGoodsPrintResultWork, object paraGoodsPrintParamWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            paraGoodsPrintResultWork = null;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchGoodsPrt(out paraGoodsPrintResultWork, paraGoodsPrintParamWork, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsPrintDB.Search");
                paraGoodsPrintResultWork = new ArrayList();
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
        #endregion  //[Search]

        #region [SearchGoodsPrt]
        /// <summary>
        /// �w�肳�ꂽ�����̏��i�}�X�^LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="paraGoodsPrintResultWork">��������</param>
        /// <param name="paraGoodsPrintParamWork">��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�}�X�^LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.11</br>
        public int SearchGoodsPrt(out object paraGoodsPrintResultWork, object paraGoodsPrintParamWork, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            GoodsPrintParamWork goodsPrintParamWork = null;

            ArrayList goodsPrintParamWorkList = paraGoodsPrintParamWork as ArrayList;
            ArrayList goodsPrintResultWorkList = new ArrayList();

            if (goodsPrintParamWorkList == null)
            {
                goodsPrintParamWork = paraGoodsPrintParamWork as GoodsPrintParamWork;
            }
            else
            {
                if (goodsPrintParamWorkList.Count > 0)
                    goodsPrintParamWork = goodsPrintParamWorkList[0] as GoodsPrintParamWork;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                //�������s
                status = SearchProc(ref goodsPrintResultWorkList, goodsPrintParamWork, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsPrintDB.SearchRatePrt Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            paraGoodsPrintResultWork = goodsPrintResultWorkList;

            return status;
        }
        #endregion  //[SearchRatePrt]

        #region [SearchProc]
        /// <summary>
        /// �w�肳�ꂽ�����̏��i�}�X�^LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsPrintResultWorkList">��������</param>
        /// <param name="goodsPrintParamWork">��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�}�X�^LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.11</br>
        /// <br></br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/06/18</br>
        private int SearchProc(ref ArrayList goodsPrintResultWorkList, GoodsPrintParamWork goodsPrintParamWork, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
            // �ϊ����Ăяo��
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // �ϊ���񏉊���
            convertDoubleRelease.ReleaseInitLib();
            // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // �Ώۃe�[�u��
                // GOODSURF      GODSU ���i�}�X�^�i���[�U�[�o�^�j
                // MAKERURF      MKERU ���[�J�[�}�X�^�i���[�U�[�o�^�j
                // GOODSMNGRF    GODSM ���i�Ǘ����}�X�^
                // GOODSPRICEURF GODSP ���i�}�X�^�i���[�U�[�o�^�j
                // USERGDBDURF   USRGB ���[�U�[�K�C�h�}�X�^(�{�f�B)
                // SUPPLIERRF    SPLER �d����}�X�^

                #region [Select���쐬]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   GODSU.UPDATEDATETIMERF" + Environment.NewLine;
                //selectTxt += "  ,GODSM.SECTIONCODERF" + Environment.NewLine;  //DEL 2011/08/12
                selectTxt += "  ,GODSU.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,MKERU.MAKERSHORTNAMERF" + Environment.NewLine;
                selectTxt += "  ,MKERU.MAKERNAMERF" + Environment.NewLine; // ADD 2011/08/12
                selectTxt += "  ,GODSU.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,GODSU.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "  ,GODSU.GOODSNAMEKANARF" + Environment.NewLine;
                selectTxt += "  ,GODSU.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,BLGOODS.BLGOODSHALFNAMERF" + Environment.NewLine;
                /*----------------DEL 2011/08/12 ---------------------->>>>>
                selectTxt += "  ,GODSM.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "  ,SPLER.SUPPLIERSNMRF" + Environment.NewLine;
                -----------------DEL 2011/08/12 ----------------------<<<<<*/
                selectTxt += "  ,GODSP.LISTPRICERF" + Environment.NewLine;
                selectTxt += "  ,GODSP.STOCKRATERF" + Environment.NewLine;
                selectTxt += "  ,GODSP.SALESUNITCOSTRF" + Environment.NewLine;
                selectTxt += "  ,GODSU.GOODSRATERANKRF" + Environment.NewLine;
                //selectTxt += "  ,GODSM.SUPPLIERLOTRF" + Environment.NewLine;  //DEL 2011/08/12
                selectTxt += "  ,GODSU.GOODSSPECIALNOTERF" + Environment.NewLine;
                selectTxt += "  ,GODSU.GOODSNOTE1RF" + Environment.NewLine;
                selectTxt += "  ,GODSU.GOODSNOTE2RF" + Environment.NewLine;
                selectTxt += "  ,GODSP.PRICESTARTDATERF" + Environment.NewLine;
                selectTxt += "  ,GODSP.LISTPRICERF AS NEWLISTPRICE" + Environment.NewLine;
                selectTxt += "  ,GODSU.GOODSKINDCODERF" + Environment.NewLine;
                selectTxt += "  ,GODSU.TAXATIONDIVCDRF" + Environment.NewLine;
                selectTxt += "  ,GODSU.ENTERPRISEGANRECODERF" + Environment.NewLine;
                selectTxt += "  ,USRGB.GUIDENAMERF AS ENTERPRISEGANRECODENAME" + Environment.NewLine;
                selectTxt += "  ,GODSU.OFFERDATADIVRF" + Environment.NewLine;
                selectTxt += "  ,BLGOODS.GOODSRATEGRPCODERF" + Environment.NewLine;  //ADD 2011/08/12
                selectTxt += " FROM GOODSURF AS GODSU" + Environment.NewLine;

                //JOIN
                //���[�J�[�}�X�^�i���[�U�[�o�^�j
                selectTxt += " LEFT JOIN MAKERURF MKERU" + Environment.NewLine;
                selectTxt += " ON  MKERU.ENTERPRISECODERF=GODSU.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND MKERU.GOODSMAKERCDRF=GODSU.GOODSMAKERCDRF" + Environment.NewLine;

                /*----------------DEL 2011/08/12 ---------------------->>>>>
                //���i�Ǘ����}�X�^
                selectTxt += " LEFT JOIN GOODSMNGRF GODSM" + Environment.NewLine;
                selectTxt += " ON  GODSM.ENTERPRISECODERF=GODSU.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GODSM.GOODSMAKERCDRF=GODSU.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND GODSM.BLGOODSCODERF=GODSU.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += " AND GODSM.GOODSNORF=GODSU.GOODSNORF" + Environment.NewLine;
                -----------------DEL 2011/08/12 ----------------------<<<<<*/

                //���i�}�X�^�i���[�U�[�o�^�j
                selectTxt += " LEFT JOIN GOODSPRICEURF GODSP" + Environment.NewLine;
                selectTxt += " ON  GODSP.ENTERPRISECODERF=GODSU.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GODSP.GOODSMAKERCDRF=GODSU.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND GODSP.GOODSNORF=GODSU.GOODSNORF" + Environment.NewLine;

                //���[�U�[�K�C�h�}�X�^(�{�f�B)
                selectTxt += " LEFT JOIN USERGDBDURF USRGB" + Environment.NewLine;
                selectTxt += " ON  USRGB.ENTERPRISECODERF=GODSU.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND USRGB.GUIDECODERF=GODSU.ENTERPRISEGANRECODERF" + Environment.NewLine;
                selectTxt += " AND USRGB.USERGUIDEDIVCDRF=41" + Environment.NewLine;

                /*----------------DEL 2011/08/12 ---------------------->>>>>
                //�d����}�X�^
                selectTxt += " LEFT JOIN SUPPLIERRF SPLER" + Environment.NewLine;
                selectTxt += " ON  SPLER.ENTERPRISECODERF=GODSM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SPLER.SUPPLIERCDRF=GODSM.SUPPLIERCDRF" + Environment.NewLine;
                -----------------DEL 2011/08/12 ----------------------<<<<<*/

                //BL�R�[�h�}�X�^
                selectTxt += " LEFT JOIN BLGOODSCDURF AS BLGOODS" + Environment.NewLine;
                selectTxt += " ON BLGOODS.ENTERPRISECODERF = GODSU.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND BLGOODS.BLGOODSCODERF = GODSU.BLGOODSCODERF" + Environment.NewLine;


                //WHERE
                // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
                //selectTxt += MakeWhereString(ref sqlCommand, goodsPrintParamWork, logicalMode);
                selectTxt += MakeWhereString(ref sqlCommand, goodsPrintParamWork, logicalMode, convertDoubleRelease);
                // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
                #endregion  //[Select���쐬]

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
                    //goodsPrintResultWorkList.Add(CopyToGoodsPrintResultWorkFromReader(ref myReader, goodsPrintParamWork));
                    goodsPrintResultWorkList.Add(CopyToGoodsPrintResultWorkFromReader(ref myReader, goodsPrintParamWork, convertDoubleRelease));
                    // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
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
                // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
                // ���
                convertDoubleRelease.Dispose();
                // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
            }

            return status;
        }
        #endregion //[SearchProc]

        #region [WHERE�吶������]
        /// <summary>
        /// WHERE�吶������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="goodsPrintParamWork">��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="convertDoubleRelease">���l�ϊ�����</param>
        /// <returns></returns>
        /// <br>Note       : WHERE�吶������</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.11</br>
        /// <br></br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/06/18</br>
        // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
        //private string MakeWhereString(ref SqlCommand sqlCommand, GoodsPrintParamWork goodsPrintParamWork, ConstantManagement.LogicalMode logicalMode)
        private string MakeWhereString(ref SqlCommand sqlCommand, GoodsPrintParamWork goodsPrintParamWork, ConstantManagement.LogicalMode logicalMode, ConvertDoubleRelease convertDoubleRelease)
        // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
        {
            #region WHERE���쐬
            string retstring = "";
            retstring += " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " GODSU.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsPrintParamWork.EnterpriseCode);

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

            /*------------------ DEL 2011/08/12 -------------------->>>>>
            //���_�R�[�h
            if (goodsPrintParamWork.SectionCode != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in goodsPrintParamWork.SectionCode)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }
                if (sectionCodestr != "")
                {
                    retstring += " AND GODSU.SECTIONCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //�d����R�[�h
            if (goodsPrintParamWork.SupplierCdSt != 0)
            {
                retstring += " AND GODSM.SUPPLIERCDRF>=@SUPPLIERCDST" + Environment.NewLine;
                SqlParameter paraSupplierCdSt = sqlCommand.Parameters.Add("@SUPPLIERCDST", SqlDbType.Int);
                paraSupplierCdSt.Value = SqlDataMediator.SqlSetInt32(goodsPrintParamWork.SupplierCdSt);
            }
            if ((goodsPrintParamWork.SupplierCdEd != 0) && (goodsPrintParamWork.SupplierCdEd != 999999))
            {
                retstring += " AND GODSM.SUPPLIERCDRF<=@SUPPLIERCDED" + Environment.NewLine;
                SqlParameter paraSupplierCdEd = sqlCommand.Parameters.Add("@SUPPLIERCDED", SqlDbType.Int);
                paraSupplierCdEd.Value = SqlDataMediator.SqlSetInt32(goodsPrintParamWork.SupplierCdEd);
            }
            --------------------- DEL 2011/08/12 --------------------<<<<<*/

            //���i���[�J�[�R�[�h
            if (goodsPrintParamWork.GoodsMakerCdSt != 0)
            {
                retstring += " AND GODSU.GOODSMAKERCDRF>=@GOODSMAKERCDST" + Environment.NewLine;
                SqlParameter paraGoodsMakerCdSt = sqlCommand.Parameters.Add("@GOODSMAKERCDST", SqlDbType.Int);
                paraGoodsMakerCdSt.Value = SqlDataMediator.SqlSetInt32(goodsPrintParamWork.GoodsMakerCdSt);
            }
            if ((goodsPrintParamWork.GoodsMakerCdEd != 0) &&(goodsPrintParamWork.GoodsMakerCdEd != 9999))
            {
                retstring += " AND GODSU.GOODSMAKERCDRF<=@GOODSMAKERCDED" + Environment.NewLine;
                SqlParameter paraGoodsMakerCdEd = sqlCommand.Parameters.Add("@GOODSMAKERCDED", SqlDbType.Int);
                paraGoodsMakerCdEd.Value = SqlDataMediator.SqlSetInt32(goodsPrintParamWork.GoodsMakerCdEd);
            }
            //BL���i�R�[�h
            if (goodsPrintParamWork.BLGoodsCodeSt != 0)
            {
                retstring += " AND GODSU.BLGOODSCODERF>=@BLGOODSCODEST" + Environment.NewLine;
                SqlParameter paraBLGoodsCodeSt = sqlCommand.Parameters.Add("@BLGOODSCODEST", SqlDbType.Int);
                paraBLGoodsCodeSt.Value = SqlDataMediator.SqlSetInt32(goodsPrintParamWork.BLGoodsCodeSt);
            }
            if ((goodsPrintParamWork.BLGoodsCodeEd != 0) &&(goodsPrintParamWork.BLGoodsCodeEd != 99999))
            {
                retstring += " AND GODSU.BLGOODSCODERF<=@BLGOODSCODEED" + Environment.NewLine;
                SqlParameter paraBLGoodsCodeEd = sqlCommand.Parameters.Add("@BLGOODSCODEED", SqlDbType.Int);
                paraBLGoodsCodeEd.Value = SqlDataMediator.SqlSetInt32(goodsPrintParamWork.BLGoodsCodeEd);
            }

            //���i�ԍ�
            if (goodsPrintParamWork.GoodsNoSt != "")
            {
                if (goodsPrintParamWork.GoodsNoSt.LastIndexOf("*") >= 0)
                {
                    String[] GoodsNoSt = goodsPrintParamWork.GoodsNoSt.Split(new Char[] { '*' });

                    retstring += " AND ( GODSU.GOODSNORF>=@GOODSNOST OR GODSU.GOODSNORF LIKE @GOODSNOST )" + Environment.NewLine;
                    SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@GOODSNOST", SqlDbType.NVarChar);
                    paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(GoodsNoSt[0] + "%");

                }
                else
                {
                    retstring += " AND GODSU.GOODSNORF>=@GOODSNOST" + Environment.NewLine;
                    SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@GOODSNOST", SqlDbType.NVarChar);
                    paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(goodsPrintParamWork.GoodsNoSt);
                }
            }
            if (goodsPrintParamWork.GoodsNoEd != "")
            {
                if (goodsPrintParamWork.GoodsNoEd.LastIndexOf("*") >= 0)
                {
                    String[] GoodsNoEd = goodsPrintParamWork.GoodsNoEd.Split(new Char[] { '*' });

                    retstring += " AND (GODSU.GOODSNORF<=@GOODSNOED OR GODSU.GOODSNORF LIKE @GOODSNOED )" + Environment.NewLine;
                    SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@GOODSNOED", SqlDbType.NVarChar);
                    paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(GoodsNoEd[0] + "%");
                }
                else
                {
                    retstring += " AND GODSU.GOODSNORF<=@GOODSNOED" + Environment.NewLine;
                    SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@GOODSNOED", SqlDbType.NVarChar);
                    paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(goodsPrintParamWork.GoodsNoEd);
                }
            }
            // �艿�w�� 0:���� 1:�ȏ� 2:�ȉ�
            // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
            double listPrice = 0;
            convertDoubleRelease.EnterpriseCode = goodsPrintParamWork.EnterpriseCode;
            convertDoubleRelease.GoodsMakerCd = int.MinValue; // �_�~�[
            convertDoubleRelease.GoodsNo = string.Empty; // �_�~�[
            convertDoubleRelease.ConvertSetParam = goodsPrintParamWork.ListPrice;

            // �ϊ��������s
            convertDoubleRelease.ConvertProc();
            
            listPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
            // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
            switch (goodsPrintParamWork.ListPriceDiv)
            {
                case 0://����
                    {
                        retstring += " AND GODSP.LISTPRICERF=@LISTPRICE" + Environment.NewLine;
                        SqlParameter paraListPrice = sqlCommand.Parameters.Add("@LISTPRICE", SqlDbType.Int);
                        // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
                        //paraListPrice.Value = SqlDataMediator.SqlSetDouble(goodsPrintParamWork.ListPrice);
                        paraListPrice.Value = SqlDataMediator.SqlSetDouble(listPrice);
                        // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
                        break;
                    }
                case 1://�ȏ�
                    {
                        retstring += " AND GODSP.LISTPRICERF>=@LISTPRICE" + Environment.NewLine;
                        SqlParameter paraListPrice = sqlCommand.Parameters.Add("@LISTPRICE", SqlDbType.Int);
                        // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
                        //paraListPrice.Value = SqlDataMediator.SqlSetDouble(goodsPrintParamWork.ListPrice);
                        paraListPrice.Value = SqlDataMediator.SqlSetDouble(listPrice);
                        // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
                        break;
                    }
                case 2://�ȉ�
                    {
                        retstring += " AND GODSP.LISTPRICERF<=@LISTPRICE" + Environment.NewLine;
                        SqlParameter paraListPrice = sqlCommand.Parameters.Add("@LISTPRICE", SqlDbType.Int);
                        // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
                        //paraListPrice.Value = SqlDataMediator.SqlSetDouble(goodsPrintParamWork.ListPrice);
                        paraListPrice.Value = SqlDataMediator.SqlSetDouble(listPrice);
                        // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
                        break;
                    }
            }
            // �����w�� 0:���� 1:�ȏ� 2:�ȉ�
            switch (goodsPrintParamWork.SalesUnitCostDiv)
            {
                case 0://����
                    {
                        retstring += " AND GODSP.SALESUNITCOSTRF=@SALESUNITCOST" + Environment.NewLine;
                        SqlParameter paraSalesUnitCost = sqlCommand.Parameters.Add("@SALESUNITCOST", SqlDbType.Int);
                        paraSalesUnitCost.Value = SqlDataMediator.SqlSetDouble(goodsPrintParamWork.SalesUnitCost);
                        break;
                    }
                case 1://�ȏ�
                    {
                        retstring += " AND GODSP.SALESUNITCOSTRF>=@SALESUNITCOST" + Environment.NewLine;
                        SqlParameter paraSalesUnitCost = sqlCommand.Parameters.Add("@SALESUNITCOST", SqlDbType.Int);
                        paraSalesUnitCost.Value = SqlDataMediator.SqlSetDouble(goodsPrintParamWork.SalesUnitCost);
                        break;
                    }
                case 2://�ȉ�
                    {
                        retstring += " AND GODSP.SALESUNITCOSTRF=@SALESUNITCOST" + Environment.NewLine;
                        SqlParameter paraSalesUnitCost = sqlCommand.Parameters.Add("@SALESUNITCOST", SqlDbType.Int);
                        paraSalesUnitCost.Value = SqlDataMediator.SqlSetDouble(goodsPrintParamWork.SalesUnitCost);
                        break;
                    }
            }
            #endregion  //WHERE���쐬

            return retstring;
        }
        #endregion  //[WHERE�吶������]

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� GoodsPrintResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="goodsPrintParamWork">��������</param>
        /// <param name="convertDoubleRelease">���l�ϊ�����</param>
        /// <returns>GoodsPrintResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.11</br>
        /// <br></br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/06/18</br>
        /// </remarks>
        // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
        //private GoodsPrintResultWork CopyToGoodsPrintResultWorkFromReader(ref SqlDataReader myReader, GoodsPrintParamWork goodsPrintParamWork)
        private GoodsPrintResultWork CopyToGoodsPrintResultWorkFromReader(ref SqlDataReader myReader, GoodsPrintParamWork goodsPrintParamWork, ConvertDoubleRelease convertDoubleRelease)
        // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
        {
            GoodsPrintResultWork ResultWork = new GoodsPrintResultWork();

            #region �N���X�֊i�[
            ResultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            //ResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")); //DEL 2011/08/12
            ResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            ResultWork.MakerShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERSHORTNAMERF"));
            // -----------------ADD 2011/08/12-------------->>>>>
            if (string.IsNullOrEmpty(ResultWork.MakerShortName))
            {
                ResultWork.MakerShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            }
            // -----------------ADD 2011/08/12---------------<<<<<
            ResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            ResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            ResultWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            ResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            ResultWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
            /* --------------DEL 2011/08/12 ----------------------->>>>>
            ResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            ResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            -----------------DEL 2011/08/12 --------------------------<<<<<*/
            // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
            //ResultWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
            convertDoubleRelease.EnterpriseCode = goodsPrintParamWork.EnterpriseCode;
            convertDoubleRelease.GoodsMakerCd = ResultWork.GoodsMakerCd;
            convertDoubleRelease.GoodsNo = ResultWork.GoodsNo;
            convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));

            // �ϊ��������s
            convertDoubleRelease.ReleaseProc();

            ResultWork.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
            // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
            ResultWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
            ResultWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
            ResultWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            //ResultWork.SupplierLot = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERLOTRF")); //DEL 2011/08/12
            ResultWork.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNOTERF"));
            ResultWork.GoodsNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE1RF"));
            ResultWork.GoodsNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE2RF"));
            ResultWork.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
            ResultWork.NewListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NEWLISTPRICE"));
            ResultWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
            ResultWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
            ResultWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            ResultWork.EnterpriseGanreCodeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODENAME"));
            ResultWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));
            ResultWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF")); //ADD 2011/08/12
            #endregion  //�N���X�֊i�[

            return ResultWork;
        }
        #endregion  //[�N���X�i�[����]

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.11</br>
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
        #endregion  //[�R�l�N�V������������]

        //-------------------ADD 2011/08/12----------------->>>>>
        #region [���i�Ǘ���񏈗��擾�Ǝd����]
        /// <summary>
        /// ���i�Ǘ����擾�����Ǝd����
        /// </summary>
        /// <remarks>
        /// <param name="retObj">��������</param>
        /// <param name="enterpriceCode">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�Ǘ����擾�����Ǝd����</br>
        /// <br>Programmer : zhouyu</br>
        /// <br>Date       : 2011/08/12</br>
        /// </remarks>
        public int SearchGoodsMsgSpler(ref object retObj, string enterpriceCode, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchGoodsMsgSplerProcP(ref retObj, enterpriceCode, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsURelationDataDB.Search");
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// ���i�Ǘ����擾�����Ǝd����
        /// </summary>
        /// <remarks>
        /// <param name="retObj">��������</param>
        /// <param name="enterpriceCode">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�Ǘ����擾�����Ǝd����</br>
        /// <br>Programmer : zhouyu</br>
        /// <br>Date       : 2011/08/12</br>
        /// </remarks>
        private int SearchGoodsMsgSplerProcP(ref object retObj, string enterpriceCode, int readMode,ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            ArrayList retCSAList = new ArrayList();

            // ���i�Ǘ����擾
            GoodsMngDB goodsMngDB = new GoodsMngDB();
            ArrayList goodsMngList = new ArrayList();
            GoodsMngWork goodsMngWork = new GoodsMngWork();
            goodsMngWork.EnterpriseCode = enterpriceCode;
            status = goodsMngDB.SearchGoodsMngProc(out goodsMngList, goodsMngWork, readMode, logicalMode, ref sqlConnection);
            retCSAList.AddRange(goodsMngList);

            // �d������擾
            SupplierDB supplierDB = new SupplierDB();
            ArrayList supplierList = new ArrayList();
            SupplierWork supplierWork = new SupplierWork();
            supplierWork.EnterpriseCode = enterpriceCode;
            status = supplierDB.Search(out supplierList, supplierWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
            retCSAList.AddRange(supplierList);

            retObj = retCSAList;

            if (retCSAList.Count == 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            else
            {
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
        }
        #endregion
        //-------------------ADD 2011/08/12-----------------<<<<<
    }
}
