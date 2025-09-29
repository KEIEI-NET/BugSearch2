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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���i�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 21015�@�����@�F��</br>
    /// <br>Date       : 2007.02.06</br>
    /// <br></br>
    /// <br>Update Note: DC.NS�p�ɏC��</br>
    /// <br>Programmer : 22008�@�����@���n</br>
    /// <br>Date       : 2007.08.16</br>
    /// </remarks>
    [Serializable]
    public class GoodsDB : RemoteDB, IGoodsDB
    {
        /// <summary>
        /// ���i�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.06</br>
        /// </remarks>
        public GoodsDB()
            :
            base("MATKD08116D", "Broadleaf.Application.Remoting.ParamData.GoodsWork", "GOODSRF")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̏��i�}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="goodsWork">��������</param>
        /// <param name="paragoodsWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.06</br>
        public int Search(out object goodsWork, object paragoodsWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            goodsWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchGoodsProc(out goodsWork, paragoodsWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsDB.Search");
                goodsWork = new ArrayList();
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

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�}�X�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objgoodsWork">��������</param>
        /// <param name="paragoodsWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.06</br>
        public int SearchGoodsProc(out object objgoodsWork, object paragoodsWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            GoodsWork goodsWork = null;

            ArrayList goodsWorkList = paragoodsWork as ArrayList;
            if (goodsWorkList == null)
            {
                goodsWork = paragoodsWork as GoodsWork;
            }
            else
            {
                if (goodsWorkList.Count > 0)
                    goodsWork = goodsWorkList[0] as GoodsWork;
            }

            int status = SearchGoodsProc(out goodsWorkList, goodsWork, readMode, logicalMode, ref sqlConnection);
            objgoodsWork = goodsWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsWorkList">��������</param>
        /// <param name="goodsWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.06</br>
        /// <br></br>
        /// <br>Update Note: DC.NS�p�ɏC��</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.08.16</br>
        public int SearchGoodsProc(out ArrayList goodsWorkList, GoodsWork goodsWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlTxt = "";
                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "   GOODS.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.MAKERNAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNORF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSSHORTNAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNAMEKANARF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.JANRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.BLGOODSCODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.BLGOODSFULLNAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UNITCODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UNITNAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.DISPLAYORDERRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.LARGEGOODSGANRECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.LARGEGOODSGANRENAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.MEDIUMGOODSGANRECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.MEDIUMGOODSGANRENAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.DETAILGOODSGANRECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.DETAILGOODSGANRENAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSRATERANKRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.SALESORDERUNITRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSSETDIVCDRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.TAXATIONDIVCDRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNONONEHYPHENRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.OFFERDATERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSKINDCODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNOTE1RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNOTE2RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSSPECIALNOTERF" + Environment.NewLine;
                sqlTxt += "FROM GOODSRF AS GOODS" + Environment.NewLine;
                
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                sqlTxt = "";
                sqlTxt += "WHERE" + Environment.NewLine;

                //���i�ԍ�
                if (string.IsNullOrEmpty(goodsWork.GoodsNo) == false)
                {
                  sqlTxt += " GOODS.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                  SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                  paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsWork.GoodsNo);
                }

                //���i���[�J�[�R�[�h
                if (goodsWork.GoodsMakerCd != 0)
                {
                  sqlTxt += " AND GOODS.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                  SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                  paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsWork.GoodsMakerCd);
                }

                string wkstring = "";
                //�_���폜�敪
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                  wkstring = " AND GOODS.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                  wkstring = " AND GOODS.LOGICALDELETECODERF<@FINDLOGICALDELETECODE " + Environment.NewLine;
                }

                if (wkstring != "")
                {
                  sqlTxt += wkstring;
                  SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }

                //sqlCommand.CommandText += MakeWhereString(ref sqlCommand, goodsWork, logicalMode);
                sqlCommand.CommandText += sqlTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToGoodsWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            goodsWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̏��i�}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">GoodsWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�}�X�^��߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.06</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                GoodsWork goodsWork = new GoodsWork();

                // XML�̓ǂݍ���
                goodsWork = (GoodsWork)XmlByteSerializer.Deserialize(parabyte, typeof(GoodsWork));
                if (goodsWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref goodsWork, readMode, ref sqlConnection);

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(goodsWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsDB.Read");
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsWork">GoodsWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.06</br>
        /// <br></br>
        /// <br>UpDateNote : DC.NS�p�ɏC��</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.08.16</br>
        public int ReadProc(ref GoodsWork goodsWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string sqlTxt = "";
                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "   GOODS.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.MAKERNAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNORF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSSHORTNAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNAMEKANARF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.JANRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.BLGOODSCODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.BLGOODSFULLNAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UNITCODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UNITNAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.DISPLAYORDERRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.LARGEGOODSGANRECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.LARGEGOODSGANRENAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.MEDIUMGOODSGANRECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.MEDIUMGOODSGANRENAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.DETAILGOODSGANRECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.DETAILGOODSGANRENAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSRATERANKRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.SALESORDERUNITRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSSETDIVCDRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.TAXATIONDIVCDRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNONONEHYPHENRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.OFFERDATERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSKINDCODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNOTE1RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNOTE2RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSSPECIALNOTERF" + Environment.NewLine;
                sqlTxt += "FROM GOODSRF AS GOODS" + Environment.NewLine;
                sqlTxt += "WHERE" + Environment.NewLine;
                sqlTxt += "       GOODS.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                sqlTxt += "  AND  GOODS.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                //Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                {

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsWork.GoodsNo);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        goodsWork = CopyToGoodsWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="goodsWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.06</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, GoodsWork goodsWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //�_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            return retstring;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� GoodsWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>GoodsWork</returns>
        /// <remarks>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.06</br>
        /// </remarks>
        private GoodsWork CopyToGoodsWorkFromReader(ref SqlDataReader myReader)
        {
            GoodsWork wkGoodsWork = new GoodsWork();

            #region �N���X�֊i�[
            wkGoodsWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkGoodsWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkGoodsWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkGoodsWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkGoodsWork.MakerName= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            wkGoodsWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkGoodsWork.GoodsName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GOODSNAMERF"));
            wkGoodsWork.GoodsShortName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GOODSSHORTNAMERF"));
            wkGoodsWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GOODSNAMEKANARF"));
            wkGoodsWork.Jan = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("JANRF"));
            wkGoodsWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkGoodsWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            wkGoodsWork.UnitCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNITCODERF"));
            wkGoodsWork.UnitName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITNAMERF"));
            wkGoodsWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
            wkGoodsWork.LargeGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRECODERF"));
            wkGoodsWork.LargeGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRENAMERF"));
            wkGoodsWork.MediumGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRECODERF"));
            wkGoodsWork.MediumGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRENAMERF"));
            wkGoodsWork.DetailGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DETAILGOODSGANRECODERF"));
            wkGoodsWork.DetailGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DETAILGOODSGANRENAMERF"));
            wkGoodsWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            wkGoodsWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
            wkGoodsWork.GoodsSetDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSSETDIVCDRF"));
            wkGoodsWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
            wkGoodsWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
            wkGoodsWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkGoodsWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
            wkGoodsWork.GoodsNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE1RF"));
            wkGoodsWork.GoodsNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE2RF"));
            wkGoodsWork.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNOTERF"));

            #endregion

            return wkGoodsWork;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.06</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}
