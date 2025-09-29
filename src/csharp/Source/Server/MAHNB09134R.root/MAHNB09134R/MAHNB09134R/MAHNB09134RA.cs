using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ������z�����敪�ݒ�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ������z�����敪�ݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 19026�@���R�@����</br>
    /// <br>Date       : 2007.05.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class SalesProcMoneyDB : RemoteDB, IGetSyncdataList, ISalesProcMoneyDB
    {
        /// <summary>
        /// ������z�����敪�ݒ�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.22</br>
        /// </remarks>
        public SalesProcMoneyDB()
            :
            base("MAHNB06016D", "Broadleaf.Application.Remoting.ParamData.SalesProcMoneyWork", "SALESPROCMONEYRF")
        {
        }
        
        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̎d�����z�����敪�ݒ�}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">SalesProcMoneyWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔�����z�����敪�ݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.08.14</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
          int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
          SqlConnection sqlConnection = null;

          try
          {
            SalesProcMoneyWork salesProcMoneyWork = new SalesProcMoneyWork();

            // XML�̓ǂݍ���
            salesProcMoneyWork = (SalesProcMoneyWork)XmlByteSerializer.Deserialize(parabyte, typeof(SalesProcMoneyWork));
            if (salesProcMoneyWork == null) return status;

            //�R�l�N�V��������
            sqlConnection = CreateSqlConnection();
            if (sqlConnection == null) return status;
            sqlConnection.Open();

            status = ReadProc(ref salesProcMoneyWork, readMode, ref sqlConnection);

            // XML�֕ϊ����A������̃o�C�i����
            parabyte = XmlByteSerializer.Serialize(salesProcMoneyWork);
          }
          catch (Exception ex)
          {
            base.WriteErrorLog(ex, "SalesProcMoneyDB.Read");
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
        /// �w�肳�ꂽ�����̔�����z�����敪�ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="salesProcMoneyWork">SalesProcMoneyWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔�����z�����敪�ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.08.14</br>
        public int ReadProc(ref SalesProcMoneyWork salesProcMoneyWork, int readMode, ref SqlConnection sqlConnection)
        {
          int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
          SqlDataReader myReader = null;

          try
          {
            string selectTxt = "";
            selectTxt += "SELECT * FROM SALESPROCMONEYRF ";
            selectTxt += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
            
            //Select�R�}���h�̐���
            using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
            {

              //Prameter�I�u�W�F�N�g�̍쐬
              SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

              //Parameter�I�u�W�F�N�g�֒l�ݒ�
              findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.EnterpriseCode);

              myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
              if (myReader.Read())
              {
                salesProcMoneyWork = CopyToSalesProcMoneyWorkFromReader(ref myReader);
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

        /// <summary>
        /// ������z�����敪�ݒ�}�X�^��ǂݍ���
        /// </summary>
        /// <param name="salesProcMoneyWork">������z�����敪�ݒ�}�X�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <param name="sqlTransaction">SQL�g�����U�N�V����</param>
        /// <returns></returns>
        public int Read(ref SalesProcMoneyWork salesProcMoneyWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
          int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

          SqlDataReader myReader = null;
          try
          {
            string selectTxt = "";
            
            selectTxt += "SELECT ";
            selectTxt += "CREATEDATETIMERF";
            selectTxt += ",UPDATEDATETIMERF";
            selectTxt += ",ENTERPRISECODERF";
            selectTxt += ",FILEHEADERGUIDRF";
            selectTxt += ",UPDEMPLOYEECODERF";
            selectTxt += ",UPDASSEMBLYID1RF";
            selectTxt += ",UPDASSEMBLYID2RF";
            selectTxt += ",LOGICALDELETECODERF";
            selectTxt += ",FRACPROCMONEYDIVRF";
            selectTxt += ",FRACTIONPROCCDRF";
            selectTxt += ",FRACTIONPROCCODERF";
            selectTxt += ",UPPERLIMITPRICERF";
            selectTxt += ",FRACTIONPROCUNITRF";
            selectTxt += " FROM SALESPROCMONEYRF";
            selectTxt += " WHERE ";
            selectTxt += "ENTERPRISECODERF=@FINDENTERPRISECODE ";
            selectTxt += "AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV ";
            selectTxt += "AND FRACTIONPROCCODERF=@FINDFRACTIONPROCCODE ";
            selectTxt += "AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE";

            //Select�R�}���h�̐���
            using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction))
            {

              //Prameter�I�u�W�F�N�g�̍쐬
              SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
              SqlParameter findParaFracProcMoneyDiv = sqlCommand.Parameters.Add("@FINDFRACPROCMONEYDIV", SqlDbType.Int);
              SqlParameter findParaFractionProcCode = sqlCommand.Parameters.Add("@FINDFRACTIONPROCCODE", SqlDbType.Int);
              SqlParameter findParaUpperLimitPrice = sqlCommand.Parameters.Add("@FINDUPPERLIMITPRICE", SqlDbType.Float);

              //Parameter�I�u�W�F�N�g�֒l�ݒ�
              findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.EnterpriseCode);
              findParaFracProcMoneyDiv.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FracProcMoneyDiv);
              findParaFractionProcCode.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FractionProcCode);
              findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(salesProcMoneyWork.UpperLimitPrice);

              myReader = sqlCommand.ExecuteReader();
              if (myReader.Read())
              {
                salesProcMoneyWork = CopyToSalesProcMoneyWorkFromReader(ref myReader);
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

        #region [Write]
        /// <summary>
        /// ������z�����敪�ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="salesProcMoneyWork">SalesProcMoneyWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ������z�����敪�ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.08.14</br>
        public int Write(ref object salesProcMoneyWork)
        {
          int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
          SqlConnection sqlConnection = null;
          SqlTransaction sqlTransaction = null;
          try
          {
            //�p�����[�^�̃L���X�g
            ArrayList paraList = CastToArrayListFromPara(salesProcMoneyWork);
            if (paraList == null) return status;

            //�R�l�N�V��������
            sqlConnection = CreateSqlConnection();
            if (sqlConnection == null) return status;
            sqlConnection.Open();

            // �g�����U�N�V�����J�n
            sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            //write���s
            status = WriteSalesProcMoneyProc(ref paraList, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
              // �R�~�b�g
              sqlTransaction.Commit();
            else
            {
              // ���[���o�b�N
              if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            //�߂�l�Z�b�g
            salesProcMoneyWork = paraList;
          }
          catch (Exception ex)
          {
            base.WriteErrorLog(ex, "SalesProcMoneyDB.Write(ref object salesProcMoneyWork)");
            // ���[���o�b�N
            if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
          }
          finally
          {
            if (sqlTransaction != null) sqlTransaction.Dispose();
            if (sqlConnection != null)
            {
              sqlConnection.Close();
              sqlConnection.Dispose();
            }
          }

          return status;
        }


        /// <summary>
        /// ������z�����敪�ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection,SqlTranaction���g�p)
        /// </summary>
        /// <param name="salesProcMoneyWorkList">SalesProcMoneyWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ������z�����敪�ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection,SqlTranaction���g�p)</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.08.14</br>
        public int WriteSalesProcMoneyProc(ref ArrayList salesProcMoneyWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
          int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

          SqlDataReader myReader = null;
          SqlCommand sqlCommand = null;
          ArrayList al = new ArrayList();
          try
          {
            if (salesProcMoneyWorkList != null)
            {
              string selectTxt = "";
              for (int i = 0; i < salesProcMoneyWorkList.Count; i++)
              {
                SalesProcMoneyWork salesProcMoneyWork = salesProcMoneyWorkList[i] as SalesProcMoneyWork;
                selectTxt = "";
                
                selectTxt += "SELECT ";
                selectTxt += "UPDATEDATETIMERF";
                selectTxt += ",ENTERPRISECODERF ";
                selectTxt += "FROM SALESPROCMONEYRF ";
                selectTxt += "WHERE ";
                selectTxt += "ENTERPRISECODERF=@FINDENTERPRISECODE";
                selectTxt += " AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV";
                selectTxt += " AND FRACTIONPROCCODERF=@FINDFRACTIONPROCCODE";
                selectTxt += " AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE";
                
                //Select�R�}���h�̐���
                sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFracProcMoneyDiv = sqlCommand.Parameters.Add("@FINDFRACPROCMONEYDIV", SqlDbType.Int);
                SqlParameter findParaFractionProcCode = sqlCommand.Parameters.Add("@FINDFRACTIONPROCCODE", SqlDbType.Int);
                SqlParameter findParaUpperLimitPrice = sqlCommand.Parameters.Add("@FINDUPPERLIMITPRICE", SqlDbType.Float);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.EnterpriseCode);
                findParaFracProcMoneyDiv.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FracProcMoneyDiv);
                findParaFractionProcCode.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FractionProcCode);
                findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(salesProcMoneyWork.UpperLimitPrice);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                  //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                  DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                  if (_updateDateTime != salesProcMoneyWork.UpdateDateTime)
                  {
                    //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                    if (salesProcMoneyWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                    //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                    else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (myReader.IsClosed == false) myReader.Close();
                    return status;
                  }

                  sqlCommand.CommandText =  "UPDATE SALESPROCMONEYRF ";
                  sqlCommand.CommandText += "SET  UPDATEDATETIMERF=@UPDATEDATETIME";
                  sqlCommand.CommandText += ", ENTERPRISECODERF=@ENTERPRISECODE";
                  sqlCommand.CommandText += ", FILEHEADERGUIDRF=@FILEHEADERGUID";
                  sqlCommand.CommandText += ", UPDEMPLOYEECODERF=@UPDEMPLOYEECODE";
                  sqlCommand.CommandText += ", UPDASSEMBLYID1RF=@UPDASSEMBLYID1";
                  sqlCommand.CommandText += ", UPDASSEMBLYID2RF=@UPDASSEMBLYID2";
                  sqlCommand.CommandText += ", LOGICALDELETECODERF=@LOGICALDELETECODE";
                  sqlCommand.CommandText += ", FRACPROCMONEYDIVRF=@FRACPROCMONEYDIV";
                  sqlCommand.CommandText += ", FRACTIONPROCCDRF=@FRACTIONPROCCD";
                  sqlCommand.CommandText += ", FRACTIONPROCCODERF=@FRACTIONPROCCODE";
                  sqlCommand.CommandText += ", UPPERLIMITPRICERF=@UPPERLIMITPRICE";
                  sqlCommand.CommandText += ", FRACTIONPROCUNITRF=@FRACTIONPROCUNIT ";
                  sqlCommand.CommandText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";
                  sqlCommand.CommandText += "AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV ";
                  sqlCommand.CommandText += "AND FRACTIONPROCCODERF=@FINDFRACTIONPROCCODE ";
                  sqlCommand.CommandText += "AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE";
                  
                  //KEY�R�}���h���Đݒ�
                  findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.EnterpriseCode);
                  findParaFracProcMoneyDiv.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FracProcMoneyDiv);
                  findParaFractionProcCode.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FractionProcCode);
                  findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(salesProcMoneyWork.UpperLimitPrice);

                  //�X�V�w�b�_����ݒ�
                  object obj = (object)this;
                  IFileHeader flhd = (IFileHeader)salesProcMoneyWork;
                  FileHeader fileHeader = new FileHeader(obj);
                  fileHeader.SetUpdateHeader(ref flhd, obj);
                }
                else
                {
                  //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                  if (salesProcMoneyWork.UpdateDateTime > DateTime.MinValue)
                  {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    sqlCommand.Cancel();
                    if (myReader.IsClosed == false) myReader.Close();
                    return status;
                  }

                  //�V�K�쐬����SQL���𐶐�
                  sqlCommand.CommandText = "INSERT INTO SALESPROCMONEYRF ";
                  sqlCommand.CommandText += "(CREATEDATETIMERF";
                  sqlCommand.CommandText += ", UPDATEDATETIMERF";
                  sqlCommand.CommandText += ", ENTERPRISECODERF";
                  sqlCommand.CommandText += ", FILEHEADERGUIDRF";
                  sqlCommand.CommandText += ", UPDEMPLOYEECODERF";
                  sqlCommand.CommandText += ", UPDASSEMBLYID1RF";
                  sqlCommand.CommandText += ", UPDASSEMBLYID2RF";
                  sqlCommand.CommandText += ", LOGICALDELETECODERF";
                  sqlCommand.CommandText += ", FRACPROCMONEYDIVRF";
                  sqlCommand.CommandText += ", FRACTIONPROCCDRF";
                  sqlCommand.CommandText += ", FRACTIONPROCCODERF";
                  sqlCommand.CommandText += ", UPPERLIMITPRICERF";
                  sqlCommand.CommandText += ", FRACTIONPROCUNITRF) ";
                  sqlCommand.CommandText += "VALUES ";
                  sqlCommand.CommandText += "(@CREATEDATETIME";
                  sqlCommand.CommandText += ", @UPDATEDATETIME";
                  sqlCommand.CommandText += ", @ENTERPRISECODE";
                  sqlCommand.CommandText += ", @FILEHEADERGUID";
                  sqlCommand.CommandText += ", @UPDEMPLOYEECODE";
                  sqlCommand.CommandText += ", @UPDASSEMBLYID1";
                  sqlCommand.CommandText += ", @UPDASSEMBLYID2";
                  sqlCommand.CommandText += ", @LOGICALDELETECODE";
                  sqlCommand.CommandText += ", @FRACPROCMONEYDIV";
                  sqlCommand.CommandText += ", @FRACTIONPROCCD";
                  sqlCommand.CommandText += ", @FRACTIONPROCCODE";
                  sqlCommand.CommandText += ", @UPPERLIMITPRICE";
                  sqlCommand.CommandText += ", @FRACTIONPROCUNIT)";
                  
                  //�o�^�w�b�_����ݒ�
                  object obj = (object)this;
                  IFileHeader flhd = (IFileHeader)salesProcMoneyWork;
                  FileHeader fileHeader = new FileHeader(obj);
                  fileHeader.SetInsertHeader(ref flhd, obj);
                }
                if (myReader.IsClosed == false) myReader.Close();

                #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraFracProcMoneyDiv = sqlCommand.Parameters.Add("@FRACPROCMONEYDIV", SqlDbType.Int);
                SqlParameter paraFractionProcCd = sqlCommand.Parameters.Add("@FRACTIONPROCCD", SqlDbType.Int);
                SqlParameter paraFractionProcCode = sqlCommand.Parameters.Add("@FRACTIONPROCCODE", SqlDbType.Int);
                SqlParameter paraUpperLimitPrice = sqlCommand.Parameters.Add("@UPPERLIMITPRICE", SqlDbType.Float);
                SqlParameter paraFractionProcUnit = sqlCommand.Parameters.Add("@FRACTIONPROCUNIT", SqlDbType.Float);
                #endregion

                #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesProcMoneyWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesProcMoneyWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(salesProcMoneyWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.LogicalDeleteCode);
                paraFracProcMoneyDiv.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FracProcMoneyDiv);
                paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FractionProcCd);
                paraFractionProcCode.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FractionProcCode);
                paraUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(salesProcMoneyWork.UpperLimitPrice);
                paraFractionProcUnit.Value = SqlDataMediator.SqlSetDouble(salesProcMoneyWork.FractionProcUnit);
                #endregion

                sqlCommand.ExecuteNonQuery();
                al.Add(salesProcMoneyWork);
              }
            }

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
          }
          catch (SqlException ex)
          {
            //���N���X�ɗ�O��n���ď������Ă��炤
            status = base.WriteSQLErrorLog(ex);
          }
          finally
          {
            if (myReader != null)
              if (myReader.IsClosed == false) myReader.Close();
            if (sqlCommand != null)
            {
              sqlCommand.Cancel();
              sqlCommand.Dispose();
            }
          }

          salesProcMoneyWorkList = al;

          return status;
        }
        #endregion

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̔�����z�����敪�ݒ�}�X�^�߂�f�[�^���LIST��߂��܂�
        /// </summary>
        /// <param name="salesProcMoneyWork">��������</param>
        /// <param name="parseSalesProcMoneyWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔�����z�����敪�ݒ�}�X�^�߂�f�[�^���LIST��߂��܂�</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.08.14</br>
        public int Search(out object salesProcMoneyWork, object parseSalesProcMoneyWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
          int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
          SqlConnection sqlConnection = null;
          salesProcMoneyWork = null;
          try
          {
            //�R�l�N�V��������
            sqlConnection = CreateSqlConnection();
            if (sqlConnection == null) return status;
            sqlConnection.Open();

            return SearchSalesProcMoneyProc(out salesProcMoneyWork, parseSalesProcMoneyWork, readMode, logicalMode, ref sqlConnection);

          }
          catch (Exception ex)
          {
            base.WriteErrorLog(ex, "SalesProcMoneyDB.Search");
            salesProcMoneyWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̔�����z�����敪�ݒ�}�X�^�߂�f�[�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objsalesProcMoneyWork">��������</param>
        /// <param name="parasalesProcMoneyWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔�����z�����敪�ݒ�}�X�^�߂�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.08.14</br>
        public int SearchSalesProcMoneyProc(out object objsalesProcMoneyWork, object parasalesProcMoneyWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
          SalesProcMoneyWork salesProcMoneyWork = null;

          ArrayList salesProcMoneyWorkList = parasalesProcMoneyWork as ArrayList;
          if (salesProcMoneyWorkList == null)
          {
            salesProcMoneyWork = parasalesProcMoneyWork as SalesProcMoneyWork;
          }
          else
          {
            if (salesProcMoneyWorkList.Count > 0)
              salesProcMoneyWork = salesProcMoneyWorkList[0] as SalesProcMoneyWork;
          }

          int status = SearchSalesProcMoneyProc(out salesProcMoneyWorkList, salesProcMoneyWork, readMode, logicalMode, ref sqlConnection);
          objsalesProcMoneyWork = salesProcMoneyWorkList;
          return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̔�����z�����敪�ݒ�}�X�^�߂�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="salesProcMoneyWorkList">��������</param>
        /// <param name="salesProcMoneyWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔�����z�����敪�ݒ�}�X�^�߂�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.08.14</br>
        public int SearchSalesProcMoneyProc(out ArrayList salesProcMoneyWorkList, SalesProcMoneyWork salesProcMoneyWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
          int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
          SqlDataReader myReader = null;
          SqlCommand sqlCommand = null;

          ArrayList al = new ArrayList();
          try
          {
            sqlCommand = new SqlCommand("SELECT * FROM SALESPROCMONEYRF ", sqlConnection);

            sqlCommand.CommandText += MakeWhereString(ref sqlCommand, salesProcMoneyWork, logicalMode);

            myReader = sqlCommand.ExecuteReader();

            while (myReader.Read())
            {

              al.Add(CopyToSalesProcMoneyWorkFromReader(ref myReader));

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

          salesProcMoneyWorkList = al;

          return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// ������z�����敪�ݒ�}�X�^�߂�f�[�^����_���폜���܂�
        /// </summary>
        /// <param name="salesProcMoneyWork">SalesProcMoneyWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ������z�����敪�ݒ�}�X�^�߂�f�[�^����_���폜���܂�</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.08.14</br>
        public int LogicalDelete(ref object salesProcMoneyWork)
        {
          return LogicalDeleteSalesProcMoney(ref salesProcMoneyWork, 0);
        }

        /// <summary>
        /// �_���폜������z�����敪�ݒ�}�X�^�߂�f�[�^���𕜊����܂�
        /// </summary>
        /// <param name="salesProcMoneyWork">SalesProcMoneyWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜������z�����敪�ݒ�}�X�^�߂�f�[�^���𕜊����܂�</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.08.14</br>
        public int RevivalLogicalDelete(ref object salesProcMoneyWork)
        {
          return LogicalDeleteSalesProcMoney(ref salesProcMoneyWork, 1);
        }

        /// <summary>
        /// ������z�����敪�ݒ�}�X�^�߂�f�[�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="salesProcMoneyWork">SalesProcMoneyWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ������z�����敪�ݒ�}�X�^�߂�f�[�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.08.14</br>
        private int LogicalDeleteSalesProcMoney(ref object salesProcMoneyWork, int procMode)
        {
          int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
          SqlConnection sqlConnection = null;
          SqlTransaction sqlTransaction = null;
          try
          {
            //�p�����[�^�̃L���X�g
            ArrayList paraList = CastToArrayListFromPara(salesProcMoneyWork);
            if (paraList == null) return status;

            //�R�l�N�V��������
            sqlConnection = CreateSqlConnection();
            if (sqlConnection == null) return status;
            sqlConnection.Open();

            // �g�����U�N�V�����J�n
            sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            status = LogicalDeleteSalesProcMoneyProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
              // �R�~�b�g
              sqlTransaction.Commit();
            else
            {
              // ���[���o�b�N
              if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
          }
          catch (Exception ex)
          {
            string procModestr = "";
            if (procMode == 0)
              procModestr = "LogicalDelete";
            else
              procModestr = "RevivalLogicalDelete";
            base.WriteErrorLog(ex, "SalesProcMoneyDB.LogicalDeleteCarrier :" + procModestr);

            // ���[���o�b�N
            if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
          }
          finally
          {
            if (sqlTransaction != null) sqlTransaction.Dispose();
            if (sqlConnection != null)
            {
              sqlConnection.Close();
              sqlConnection.Dispose();
            }
          }

          return status;
        }

        /// <summary>
        /// ������z�����敪�ݒ�}�X�^�߂�f�[�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection,SqlTranaction���g�p)
        /// </summary>
        /// <param name="salesProcMoneyWorkList">SalesProcMoneyWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ������z�����敪�ݒ�}�X�^�߂�f�[�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection,SqlTranaction���g�p)</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.08.14</br>
        public int LogicalDeleteSalesProcMoneyProc(ref ArrayList salesProcMoneyWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
          int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
          int logicalDelCd = 0;
          SqlDataReader myReader = null;
          SqlCommand sqlCommand = null;
          ArrayList al = new ArrayList();

          try
          {
            if (salesProcMoneyWorkList != null)
            {
              for (int i = 0; i < salesProcMoneyWorkList.Count; i++)
              {
                SalesProcMoneyWork salesProcMoneyWork = salesProcMoneyWorkList[i] as SalesProcMoneyWork;

                string selectTxt = "";
                selectTxt += "SELECT UPDATEDATETIMERF";
                selectTxt += ", ENTERPRISECODERF";
                selectTxt += ",LOGICALDELETECODERF ";
                selectTxt += "FROM SALESPROCMONEYRF ";
                selectTxt += "WHERE ";
                selectTxt += "ENTERPRISECODERF=@FINDENTERPRISECODE ";
                selectTxt += "AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV ";
                selectTxt += "AND FRACTIONPROCCODERF=@FINDFRACTIONPROCCODE ";
                selectTxt += "AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE";

                //Select�R�}���h�̐���
                sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFracProcMoneyDiv = sqlCommand.Parameters.Add("@FINDFRACPROCMONEYDIV", SqlDbType.Int);
                SqlParameter findParaFractionProcCode = sqlCommand.Parameters.Add("@FINDFRACTIONPROCCODE", SqlDbType.Int);
                SqlParameter findParaUpperLimitPrice = sqlCommand.Parameters.Add("@FINDUPPERLIMITPRICE", SqlDbType.Float);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.EnterpriseCode);
                findParaFracProcMoneyDiv.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FracProcMoneyDiv);
                findParaFractionProcCode.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FractionProcCode);
                findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(salesProcMoneyWork.UpperLimitPrice);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                  //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                  DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                  if (_updateDateTime != salesProcMoneyWork.UpdateDateTime)
                  {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    return status;
                  }
                  //���݂̘_���폜�敪���擾
                  logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                  sqlCommand.CommandText = "UPDATE SALESPROCMONEYRF ";
                  sqlCommand.CommandText += "SET UPDATEDATETIMERF=@UPDATEDATETIME ";
                  sqlCommand.CommandText += ", UPDEMPLOYEECODERF=@UPDEMPLOYEECODE ";
                  sqlCommand.CommandText += ", UPDASSEMBLYID1RF=@UPDASSEMBLYID1 ";
                  sqlCommand.CommandText += ", UPDASSEMBLYID2RF=@UPDASSEMBLYID2 ";
                  sqlCommand.CommandText += ", LOGICALDELETECODERF=@LOGICALDELETECODE ";
                  sqlCommand.CommandText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";
                  sqlCommand.CommandText += "AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV ";
                  sqlCommand.CommandText += "AND FRACTIONPROCCODERF=@FINDFRACTIONPROCCODE ";
                  sqlCommand.CommandText += "AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE";
                  
                  //KEY�R�}���h���Đݒ�
                  findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.EnterpriseCode);
                  findParaFracProcMoneyDiv.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FracProcMoneyDiv);
                  findParaFractionProcCode.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FractionProcCode);
                  findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(salesProcMoneyWork.UpperLimitPrice);

                  //�X�V�w�b�_����ݒ�
                  object obj = (object)this;
                  IFileHeader flhd = (IFileHeader)salesProcMoneyWork;
                  FileHeader fileHeader = new FileHeader(obj);
                  fileHeader.SetUpdateHeader(ref flhd, obj);
                }
                else
                {
                  //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                  status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                  sqlCommand.Cancel();
                  return status;
                }
                sqlCommand.Cancel();
                if (myReader.IsClosed == false) myReader.Close();

                //�_���폜���[�h�̏ꍇ
                if (procMode == 0)
                {
                  if (logicalDelCd == 3)
                  {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
                    sqlCommand.Cancel();
                    return status;
                  }
                  else if (logicalDelCd == 0) salesProcMoneyWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                  else salesProcMoneyWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                }
                else
                {
                  if (logicalDelCd == 1) salesProcMoneyWork.LogicalDeleteCode = 0;//�_���폜�t���O������
                  else
                  {
                    if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                    else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//���S�폜�̓f�[�^�Ȃ���߂�
                    sqlCommand.Cancel();
                    return status;
                  }
                }

                //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesProcMoneyWork.UpdateDateTime);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.LogicalDeleteCode);

                int ret = sqlCommand.ExecuteNonQuery();
                
                al.Add(salesProcMoneyWork);
              }

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
            if (myReader != null)
              if (!myReader.IsClosed) myReader.Close();
            if (sqlCommand != null)
            {
              sqlCommand.Cancel();
              sqlCommand.Dispose();
            }
          }

          salesProcMoneyWorkList = al;

          return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// ������z�����敪�ݒ�}�X�^�߂�f�[�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">������z�����敪�ݒ�}�X�^�߂�f�[�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : ������z�����敪�ݒ�}�X�^�߂�f�[�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.08.14</br>
        public int Delete(byte[] parabyte)
        {
          int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
          SqlConnection sqlConnection = null;
          SqlTransaction sqlTransaction = null;
          try
          {
            //�p�����[�^�̃L���X�g
            ArrayList paraList = CastToArrayListFromPara(parabyte);
            if (paraList == null) return status;

            //�R�l�N�V��������
            sqlConnection = CreateSqlConnection();
            if (sqlConnection == null) return status;
            sqlConnection.Open();

            // �g�����U�N�V�����J�n
            sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            status = DeleteSalesProcMoneyProc(paraList, ref sqlConnection, ref sqlTransaction);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
              // �R�~�b�g
              sqlTransaction.Commit();
            else
            {
              // ���[���o�b�N
              if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
          }
          catch (Exception ex)
          {
            base.WriteErrorLog(ex, "SalesProcMoneyDB.Delete");
            // ���[���o�b�N
            if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
          }
          finally
          {
            if (sqlTransaction != null) sqlTransaction.Dispose();
            if (sqlConnection != null)
            {
              sqlConnection.Close();
              sqlConnection.Dispose();
            }
          }
          return status;
        }

        /// <summary>
        /// ������z�����敪�ݒ�}�X�^�߂�f�[�^���𕨗��폜���܂�(�O�������SqlConnection,SqlTranaction���g�p)
        /// </summary>
        /// <param name="salesProcMoneyWorkList">������z�����敪�ݒ�}�X�^�߂�f�[�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : ������z�����敪�ݒ�}�X�^�߂�f�[�^���𕨗��폜���܂�(�O�������SqlConnection,SqlTranaction���g�p)</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.08.14</br>
        public int DeleteSalesProcMoneyProc(ArrayList salesProcMoneyWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
          int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
          SqlDataReader myReader = null;
          SqlCommand sqlCommand = null;
          try
          {

            for (int i = 0; i < salesProcMoneyWorkList.Count; i++)
            {
              SalesProcMoneyWork salesProcMoneyWork = salesProcMoneyWorkList[i] as SalesProcMoneyWork;

              string selectTxt = "";
              selectTxt += "SELECT UPDATEDATETIMERF";
              selectTxt += ", ENTERPRISECODERF";
              selectTxt += ", LOGICALDELETECODERF ";
              selectTxt += "FROM SALESPROCMONEYRF ";
              selectTxt += "WHERE ";
              selectTxt += "ENTERPRISECODERF=@FINDENTERPRISECODE ";
              selectTxt += "AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV ";
              selectTxt += "AND FRACTIONPROCCODERF=@FINDFRACTIONPROCCODE ";
              selectTxt += "AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE";

              sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

              //Prameter�I�u�W�F�N�g�̍쐬
              SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
              SqlParameter findParaFracProcMoneyDiv = sqlCommand.Parameters.Add("@FINDFRACPROCMONEYDIV", SqlDbType.Int);
              SqlParameter findParaFractionProcCode = sqlCommand.Parameters.Add("@FINDFRACTIONPROCCODE", SqlDbType.Int);
              SqlParameter findParaUpperLimitPrice = sqlCommand.Parameters.Add("@FINDUPPERLIMITPRICE", SqlDbType.Float);

              //Parameter�I�u�W�F�N�g�֒l�ݒ�
              findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.EnterpriseCode);
              findParaFracProcMoneyDiv.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FracProcMoneyDiv);
              findParaFractionProcCode.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FractionProcCode);
              findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(salesProcMoneyWork.UpperLimitPrice);

              myReader = sqlCommand.ExecuteReader();
              if (myReader.Read())
              {
                //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                if (_updateDateTime != salesProcMoneyWork.UpdateDateTime)
                {
                  status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                  sqlCommand.Cancel();
                  return status;
                }

                sqlCommand.CommandText = "DELETE FROM SALESPROCMONEYRF ";
                sqlCommand.CommandText += "WHERE ";
                sqlCommand.CommandText += "ENTERPRISECODERF=@FINDENTERPRISECODE ";
                sqlCommand.CommandText += "AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV ";
                sqlCommand.CommandText += "AND FRACTIONPROCCODERF=@FINDFRACTIONPROCCODE ";
                sqlCommand.CommandText += "AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE";
                
                //KEY�R�}���h���Đݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.EnterpriseCode);
                findParaFracProcMoneyDiv.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FracProcMoneyDiv);
                findParaFractionProcCode.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FractionProcCode);
                findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(salesProcMoneyWork.UpperLimitPrice);
              }
              else
              {
                //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                sqlCommand.Cancel();
                return status;
              }
              if (myReader.IsClosed == false) myReader.Close();

              sqlCommand.ExecuteNonQuery();
            }
            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
          }
          catch (SqlException ex)
          {
            //���N���X�ɗ�O��n���ď������Ă��炤
            status = base.WriteSQLErrorLog(ex);
          }
          finally
          {
            if (myReader != null)
              if (myReader.IsClosed == false) myReader.Close();
            if (sqlCommand != null)
            {
              sqlCommand.Cancel();
              sqlCommand.Dispose();
            }
          }

          return status;
        }
        #endregion


        #region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="salesProcMoneyWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.08.14</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalesProcMoneyWork salesProcMoneyWork, ConstantManagement.LogicalMode logicalMode)
        {
          string wkstring = "";
          string retstring = "WHERE ";

          //��ƃR�[�h
          retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
          SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
          paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.EnterpriseCode);

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

          //�[�������Ώۋ��z�敪
          if (salesProcMoneyWork.FracProcMoneyDiv >= 0)
          {
            retstring += "AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV ";
            SqlParameter paraFracProcMoneyDiv = sqlCommand.Parameters.Add("@FINDFRACPROCMONEYDIV", SqlDbType.Int);
            paraFracProcMoneyDiv.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FracProcMoneyDiv);
          }

          //�[�������R�[�h
          if (salesProcMoneyWork.FractionProcCode >= 0)
          {
            retstring += "AND FRACTIONPROCCODERF=@FINDFRACTIONPROCCODE ";
            SqlParameter paraFractionProcCode = sqlCommand.Parameters.Add("@FINDFRACTIONPROCCODE", SqlDbType.Int);
            paraFractionProcCode.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FractionProcCode);
          }

          //������z
          if (salesProcMoneyWork.UpperLimitPrice > 0)
          {
            retstring += "AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE ";
            SqlParameter paraUpperLimitPrice = sqlCommand.Parameters.Add("@FINDUPPERLIMITPRICE", SqlDbType.Int);
            paraUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(salesProcMoneyWork.UpperLimitPrice);
          }
          return retstring;
        }
        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.08.14</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
          ArrayList retal = null;
          SalesProcMoneyWork[] SalesProcMoneyWorkArray = null;

          if (paraobj != null)
            try
            {
              //ArrayList�̏ꍇ
              if (paraobj is ArrayList)
              {
                retal = paraobj as ArrayList;
              }

              //�p�����[�^�N���X�̏ꍇ
              if (paraobj is SalesProcMoneyWork)
              {
                SalesProcMoneyWork wkSalesProcMoneyWork = paraobj as SalesProcMoneyWork;
                if (wkSalesProcMoneyWork != null)
                {
                  retal = new ArrayList();
                  retal.Add(wkSalesProcMoneyWork);
                }
              }

              //byte[]�̏ꍇ
              if (paraobj is byte[])
              {
                byte[] byteArray = paraobj as byte[];
                try
                {
                  SalesProcMoneyWorkArray = (SalesProcMoneyWork[])XmlByteSerializer.Deserialize(byteArray, typeof(SalesProcMoneyWork[]));
                }
                catch (Exception) { }
                if (SalesProcMoneyWorkArray != null)
                {
                  retal = new ArrayList();
                  retal.AddRange(SalesProcMoneyWorkArray);
                }
                else
                {
                  try
                  {
                    SalesProcMoneyWork wkSalesProcMoneyWork = (SalesProcMoneyWork)XmlByteSerializer.Deserialize(byteArray, typeof(SalesProcMoneyWork));
                    if (wkSalesProcMoneyWork != null)
                    {
                      retal = new ArrayList();
                      retal.Add(wkSalesProcMoneyWork);
                    }
                  }
                  catch (Exception) { }
                }
              }

            }
            catch (Exception)
            {
              //���ɉ������Ȃ�
            }

          return retal;
        }
        #endregion

        #region [GetSyncdataList]
        /// <summary>
        /// ���[�J���V���N�p�̃f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="arraylistdata">��������</param>
        /// <param name="syncServiceWork">Sync�p�f�[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�Z�b�g���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.21</br>
        public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("SELECT * FROM SALESPROCMONEYRF ", sqlConnection);

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToSalesProcMoneyWorkFromReader(ref myReader));
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

            arraylistdata = al;

            return status;
        }
        #endregion

        #region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="syncServiceWork">Sync�p�f�[�^</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.21</br>
        private string MakeSyncWhereString(ref SqlCommand sqlCommand, SyncServiceWork syncServiceWork)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //��ƃR�[�h
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);

            //�����V���N�̏ꍇ�͍X�V���t�͈͎̔w��
            if (syncServiceWork.Syncmode == 0)
            {
                wkstring = "AND UPDATEDATETIMERF>=@FINDUPDATEDATETIMEST ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeSt = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEST", SqlDbType.BigInt);
                paraUpdateDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeSt);

                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }
            else
            {
                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }

            return retstring;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� SalesProcMoneyWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SalesProcMoneyWork</returns>
        /// <remarks>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.22</br>
        /// <br></br>
        /// <br>UpDateNote : DC.NS�p�Ƀ��C�A�E�g�ύX</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.08.14</br>
        /// </remarks>
        private SalesProcMoneyWork CopyToSalesProcMoneyWorkFromReader(ref SqlDataReader myReader)
        {
            SalesProcMoneyWork salesProcMoneyWork = new SalesProcMoneyWork();

            #region �N���X�֊i�[
            salesProcMoneyWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            salesProcMoneyWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            salesProcMoneyWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            salesProcMoneyWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            salesProcMoneyWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            salesProcMoneyWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            salesProcMoneyWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            salesProcMoneyWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            // 2007.08.14 Delete >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //salesProcMoneyWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            // 2007.08.14 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            salesProcMoneyWork.FracProcMoneyDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCMONEYDIVRF"));
            salesProcMoneyWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));

            // 2007.08.14 Add >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            salesProcMoneyWork.FractionProcCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCODERF"));
            salesProcMoneyWork.UpperLimitPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UPPERLIMITPRICERF"));
            salesProcMoneyWork.FractionProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACTIONPROCUNITRF"));
            // 2007.08.14 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            #endregion

            return salesProcMoneyWork;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.22</br>
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
