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
    /// �^���ޕʏ�񌟍�DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �^���ޕʏ�񌟍�DB�����[�g�I�u�W�F�N�g</br>
    /// <br>Programmer : 96186�@���ԁ@�T��</br>
    /// <br>Date       : 2007.03.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class CtgyMdlLnkDB : RemoteDB, ICtgyMdlLnkDB
    {
        /// <summary>
        ///�@�񋟎��q��񌋍�����DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 96186�@���ԁ@�T��</br>
        /// <br>Date       : 2007.03.16</br>
        /// </remarks>
        public CtgyMdlLnkDB()
            :
            base("PMTKD06103D", "Broadleaf.Application.Remoting.CtgyMdlLnkDB", "CTGYMDLLNKRF")
        {
        }

        /// <summary>
        /// �^���ޕʏ�񌟍�DB�����[�g�I�u�W�F�N�g
        /// </summary>
        /// <param name="ctgyMdlLnkCondWork"></param>
        /// <param name="ctgyMdlLnkRetWork"></param>
        /// <returns></returns>
        public int GetCtgyMdlLnk(CtgyMdlLnkCondWork ctgyMdlLnkCondWork, out ArrayList ctgyMdlLnkRetWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //���o�̓p�����[�^�[�ݒ�
            ctgyMdlLnkRetWork = null;
            SqlConnection sqlConnection = null;
            try
            {
                ArrayList _ctgyMdlLnkRetWork = null;

                //�r�p�k��������
                SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = GetCtgyMdlLnkSerch(ctgyMdlLnkCondWork, out _ctgyMdlLnkRetWork, sqlConnection, null);
                if (status == 0)
                {
                    ctgyMdlLnkRetWork = _ctgyMdlLnkRetWork;
                }
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "CtgyMdlLnkDB.GetCtgyMdlLnk�ɂ�SQL�G���[���� Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CtgyMdlLnkDB.GetCtgyMdlLnk�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                    sqlConnection.Dispose();
            }
            return status;
        }

        /// <summary>
        /// �^���ޕʏ��擾����
        /// </summary>
        /// <param name="ctgyMdlLnkCondWork"></param>
        /// <param name="ctgyMdlLnkRetWork"></param>
        /// <param name="sqlConnection">SQL Connection</param>
        /// <param name="sqlTransaction">SQL Transaction</param>
        /// <returns></returns>
        public int GetCtgyMdlLnkSerch(CtgyMdlLnkCondWork ctgyMdlLnkCondWork, out ArrayList ctgyMdlLnkRetWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return GetCtgyMdlLnkSerchProc(ctgyMdlLnkCondWork, out  ctgyMdlLnkRetWork, sqlConnection, sqlTransaction);
        }

        private int GetCtgyMdlLnkSerchProc(CtgyMdlLnkCondWork ctgyMdlLnkCondWork, out ArrayList ctgyMdlLnkRetWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = 0;
            ctgyMdlLnkRetWork = new ArrayList();
            SqlDataReader myReader = null;

            //���ʂ̏�����
            ArrayList RetInf = new ArrayList();

            //���ʂ�AllayList�ɂ�����Ə��N���X
            CtgyMdlLnkRetWork mf = null;

            string selectstr = "";
            string wherestr = "";

            try
            {
                selectstr = "SELECT ";
                selectstr += "CTGYMDLLNKRF.MODELDESIGNATIONNORF, ";
                selectstr += "CTGYMDLLNKRF.CATEGORYNORF, ";
                selectstr += "CTGYMDLLNKRF.CARPROPERNORF, ";
                selectstr += "CTGYMDLLNKRF.FULLMODELFIXEDNORF ";

                //�i�n�h�m����
                selectstr += " FROM CTGYMDLLNKRF ";

                //�v�g�d�q�d����
                selectstr += "WHERE ";

                //�t���^���Œ�ԍ�
                string wkstring = "";
                foreach (int fullModelFixedNo in ctgyMdlLnkCondWork.FullModelFixedNo)
                {
                    wkstring += fullModelFixedNo + ",";
                }
                if (wkstring != "")
                {
                    wkstring = wkstring.Remove(wkstring.LastIndexOf(','));
                    wherestr += " CTGYMDLLNKRF.FULLMODELFIXEDNORF IN (" + wkstring + ") ";
                }

                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    mf = new CtgyMdlLnkRetWork();
                    mf.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));
                    mf.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));
                    mf.CarProperNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARPROPERNORF"));
                    mf.FullModelFixedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FULLMODELFIXEDNORF"));
                    RetInf.Add(mf);
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "CtgyMdlLnkDB.GetCtgyMdlLnkSerch�ɂ�SQL�G���[���� Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CtgyMdlLnkDB.GetCtgyMdlLnkSerch�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }

            ctgyMdlLnkRetWork = RetInf;
            return status;
        }
    }
}
