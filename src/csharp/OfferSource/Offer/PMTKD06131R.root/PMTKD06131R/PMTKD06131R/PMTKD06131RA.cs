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
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// �N�����擾�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �N�����擾�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 96186�@���ԁ@�T��</br>
    /// <br>Date       : 2007.03.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class PrdTypYearDB : RemoteDB, IPrdTypYearDB
    {
        # region --- �R���X�g���N�^ ---
        /// <summary>
        /// �ޕʌ^�����������[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 96137�@�v�ۓc�@�M��</br>
        /// <br>Date       : 2005.04.05</br>
        /// </remarks>
        public PrdTypYearDB()
            :
        base("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.PrdTypYearRetWork", "PRDTYPYEARRF")
        {
        }
        # endregion

        /// <summary>
        /// ���Y�N������߂��܂�
        /// </summary>
        /// <param name="prdTypYearRetWork">��������</param>
        /// <param name="prdTypYearCondWork">�N���w��</param>
        /// <returns>STATUS</returns>
        public int SearchPrdTypYearInf(out object prdTypYearRetWork, object prdTypYearCondWork)
        {
            prdTypYearRetWork = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            try
            {
                //�������ꎞ�i�[�R���N�V��������
                ArrayList retArrayprdTypYearRetWork = new ArrayList();
                PrdTypYearCondWork _prdTypYearCondWork = (PrdTypYearCondWork)prdTypYearCondWork;

                //���\�b�h�J�n���ɃR�l�N�V������������擾
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    base.WriteErrorLog("PrdTypYearDB.SearchPrdTypYearInf�ɂăG���[���� ConnectionText���擾�o���܂���ł����B");
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }

                //SQL������
                SqlConnection sqlConnection = null;
                using (sqlConnection = new SqlConnection(connectionText))
                {
                    sqlConnection.Open();

                    //�ޕʑ������擾
                    status = SearchPrdTypYear(retArrayprdTypYearRetWork, _prdTypYearCondWork, sqlConnection, null);

                    //�߂�l��ݒ�
                    if ((retArrayprdTypYearRetWork.Count > 0) && (status == 0))
                    {
                        prdTypYearRetWork = (object)retArrayprdTypYearRetWork;
                    }
                }
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "PrdTypYearDB.SearchPrdTypYearInf�ɂ�SQL�G���[���� Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrdTypYearDB.SearchPrdTypYearInf�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        # region --- ���Y�N�����擾 ---
        /// <summary>
        /// ���Y�N�����擾
        /// </summary>
        /// <param name="retArray">��������</param>
        /// <param name="prdTypYearCondWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sql�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">SQL Transaction</param>
        /// <returns>STATUS</returns>
        public int SearchPrdTypYear(ArrayList retArray, PrdTypYearCondWork prdTypYearCondWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return SearchPrdTypYearProc(retArray, prdTypYearCondWork, sqlConnection, sqlTransaction);
        }

        private int SearchPrdTypYearProc(ArrayList retArray, PrdTypYearCondWork prdTypYearCondWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retArray.Clear();

            using (SqlCommand sqlCommand = new SqlCommand())
            {
                string cmdText;
                sqlCommand.Connection = sqlConnection;

                cmdText =
                    //���Y�N������
                    "SELECT "
                    + "PRDTYPYEARRF.MAKERCODERF, "
                    + "PRDTYPYEARRF.FRAMEMODELRF, "
                    + "PRDTYPYEARRF.STPRODUCEFRAMENORF, "
                    + "PRDTYPYEARRF.EDPRODUCEFRAMENORF, "
                    + "PRDTYPYEARRF.PRODUCETYPEOFYEARRF "

                    + "FROM PRDTYPYEARRF "

                    //���o����
                    + "WHERE PRDTYPYEARRF.MAKERCODERF=@FINDMAKERCODE "
                    + "AND PRDTYPYEARRF.FRAMEMODELRF=@FINDFRAMEMODEL ";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findMakerCode = sqlCommand.Parameters.Add("@FINDMAKERCODE", SqlDbType.Int);
                SqlParameter findFrameModel = sqlCommand.Parameters.Add("@FINDFRAMEMODEL", SqlDbType.NVarChar);

                //Parameter�I�u�W�F�N�g�֗ޕʁE�^���l�ݒ�
                findMakerCode.Value = prdTypYearCondWork.MakerCode;
                findFrameModel.Value = prdTypYearCondWork.FrameModel;

                if (prdTypYearCondWork.StProduceTypeOfYear != 0)
                {
                    cmdText += " AND PRDTYPYEARRF.PRODUCETYPEOFYEARRF >= @FINDSTPRODUCETYPEOFYEAR ";
                    ((SqlParameter)sqlCommand.Parameters.Add("@FINDSTPRODUCETYPEOFYEAR", SqlDbType.NVarChar)).Value =
                        prdTypYearCondWork.StProduceTypeOfYear;
                }
                if (prdTypYearCondWork.EdProduceTypeOfYear != 0)
                {
                    cmdText += " AND PRDTYPYEARRF.PRODUCETYPEOFYEARRF <= @FINDEDPRODUCETYPEOFYEAR ";
                    ((SqlParameter)sqlCommand.Parameters.Add("@FINDEDPRODUCETYPEOFYEAR", SqlDbType.NVarChar)).Value =
                        prdTypYearCondWork.EdProduceTypeOfYear;
                }

                sqlCommand.CommandText = cmdText;
                SqlDataReader myReader = null;
                try
                {
                    myReader = sqlCommand.ExecuteReader();
                    SetPrdTypYearRetWork(myReader, retArray);

                    if (retArray.Count > 0)
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException ex)
                {
                    return base.WriteSQLErrorLog(ex, "PrdTypYearDB.SearchPrdTypYear�ɂ�SQL�G���[���� Msg=" + ex.Message, 0);
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "PrdTypYearDB.SearchPrdTypYear�ɂăG���[���� Msg=" + ex.Message, 0);
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                finally
                {
                    if (myReader != null && !myReader.IsClosed)
                        myReader.Close();
                }
            }
            return status;
        }
        # endregion

        # region --- ���Y�N�������N���X�ɃZ�b�g ---
        /// <summary>
        /// ���Y�N�������N���X�ɃZ�b�g
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="retArray"></param>
        private void SetPrdTypYearRetWork(SqlDataReader myReader, ArrayList retArray)
        {
            while (myReader.Read())
            {
                PrdTypYearRetWork wkPrdTypYearRetWork = new PrdTypYearRetWork();
                wkPrdTypYearRetWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                wkPrdTypYearRetWork.FrameModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMEMODELRF"));
                wkPrdTypYearRetWork.StProduceFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STPRODUCEFRAMENORF"));
                wkPrdTypYearRetWork.EdProduceFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDPRODUCEFRAMENORF"));
                wkPrdTypYearRetWork.ProduceTypeOfYear = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRODUCETYPEOFYEARRF"));

                retArray.Add(wkPrdTypYearRetWork);
            }
        }
        # endregion

    }
}
