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
    /// �񋟎��q��񌋍�����DB�����[�g�I�u�W�F�N�g[TBO�����}�X�^]
    /// </summary>
    /// <remarks>
    /// <br>Note       : �񋟎��q��񌋍������̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class TBOSearchInfDB : RemoteDB, ITBOSearchInfDB
    {
        /// <summary>
        ///�@�񋟎��q��񌋍�����DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        public TBOSearchInfDB()
            :
            base("PMTKD06074D", "Broadleaf.Application.Remoting.TBOSearchInfDB", "TBOSEARCHRF")
        {
        }

        /// <summary>
        /// �񋟎��q��񌋍�����DB�����[�g�I�u�W�F�N�g
        /// </summary>
        /// <param name="tBOSearchCondWork"></param>
        /// <param name="tBOSearchRetWork"></param>
        /// <param name="tBOSearchPriceRetWork"></param>
        /// <returns></returns>
        public int Search(TBOSearchCondWork tBOSearchCondWork, out ArrayList tBOSearchRetWork, out ArrayList tBOSearchPriceRetWork)
        {
            return SearchProc(tBOSearchCondWork, out tBOSearchRetWork, out tBOSearchPriceRetWork);
        }

        /// <summary>
        /// �񋟎��q��񌋍�����DB�����[�g�I�u�W�F�N�g
        /// </summary>
        /// <param name="tBOSearchCondWork"></param>
        /// <param name="tBOSearchRetWork"></param>
        /// <param name="tBOSearchPriceRetWork"></param>
        /// <returns></returns>
        private int SearchProc(TBOSearchCondWork tBOSearchCondWork, out ArrayList tBOSearchRetWork, out ArrayList tBOSearchPriceRetWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            //���o�̓p�����[�^�[�ݒ�
            tBOSearchRetWork = null;
            tBOSearchPriceRetWork = null;
            try
            {
                if (tBOSearchCondWork == null)
                {
                    return status;
                }
                if (tBOSearchCondWork.EquipGenreCode == 0 && (tBOSearchCondWork.EquipName == null || tBOSearchCondWork.EquipName.Length == 0))
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                //�r�p�k��������
                SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                if (tBOSearchCondWork.EquipName[0].EndsWith("*") || tBOSearchCondWork.EquipName[0].StartsWith("*")) // �������̞B��������
                {
                    status = SearchEquipName(tBOSearchCondWork, out tBOSearchRetWork, sqlConnection);
                }
                else
                {
                    status = SearchPrimeParts(tBOSearchCondWork, out tBOSearchRetWork, sqlConnection);

                    status = SearchPrimePartsPrice(tBOSearchCondWork, out tBOSearchPriceRetWork, sqlConnection);
                }
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "TBOSearchInfDB.Search�ɂ�SQL�G���[���� Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "TBOSearchInfDB.Search Exception = " + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// �񋟎��q��񌋍������i�������̞B�������j
        /// </summary>
        /// <param name="inPara"></param>
        /// <param name="retWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchEquipName(TBOSearchCondWork inPara, out ArrayList retWork, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string selectstr = string.Empty;
            string wherestr = string.Empty;
            SqlDataReader myReader = null;

            retWork = new ArrayList();

            try
            {
                //[�P���ɏ����i�ɕR�t���D�Ǖi�𒊏o]
                selectstr = "SELECT ";

                //TBO�����}�X�^����
                selectstr += "TBOSEARCHRF.OFFERDATERF, ";
                selectstr += "TBOSEARCHRF.GOODSMGROUPRF, ";
                selectstr += "TBOSEARCHRF.TBSPARTSCODERF, ";
                selectstr += "TBOSEARCHRF.EQUIPGENRECODERF, ";
                selectstr += "TBOSEARCHRF.EQUIPNAMERF, ";
                selectstr += "TBOSEARCHRF.JOINDESTMAKERCDRF "; // �D�ǐݒ菈���̂��߂ɕK�v

                //�i�n�h�m����
                selectstr += " FROM TBOSEARCHRF ";

                //�v�g�d�q�d����
                wherestr = " WHERE TBOSEARCHRF.EQUIPGENRECODERF = @EQUIPGENRECODE ";

                //��������
                string wkstring = inPara.EquipName[0];
                if (wkstring.StartsWith("*"))
                {
                    wkstring = "%" + wkstring.Substring(1);
                }
                if (wkstring.EndsWith("*"))
                {
                    wkstring = wkstring.Remove(wkstring.Length - 1) + "%";
                }
                wherestr += " AND TBOSEARCHRF.EQUIPNAMERF LIKE '" + wkstring + "' ";

                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection);

                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter equipGenreCode = sqlCommand.Parameters.Add("@EQUIPGENRECODE", SqlDbType.Int);	//��������
                equipGenreCode.Value = SqlDataMediator.SqlSetInt(inPara.EquipGenreCode);


                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    TBOSearchRetWork mf = new TBOSearchRetWork();

                    //�񋟎��q��񌋍��}�X�^����
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.EquipGenreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPGENRECODERF"));
                    mf.EquipName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EQUIPNAMERF"));
                    mf.JoinDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDESTMAKERCDRF"));

                    retWork.Add(mf);
                }
                if (retWork.Count > 0)
                {
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
                base.WriteErrorLog(ex, "TBOSearchInfDB.SearchEquipName�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// �񋟎��q��񌋍������i�������ށE�������̎w��j
        /// </summary>
        /// <param name="inPara"></param>
        /// <param name="retWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchPrimeParts(TBOSearchCondWork inPara, out ArrayList retWork, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string selectstr = string.Empty;
            string wherestr = string.Empty;
            SqlDataReader myReader = null;

            retWork = new ArrayList();

            try
            {
                //[�P���ɏ����i�ɕR�t���D�Ǖi�𒊏o]
                selectstr = "SELECT ";

                //TBO�����}�X�^����
                selectstr += "TBOSEARCHRF.OFFERDATERF";
                selectstr += ",TBOSEARCHRF.GOODSMGROUPRF";
                selectstr += ",TBOSEARCHRF.TBSPARTSCODERF";
                selectstr += ",TBOSEARCHRF.TBSPARTSCDDERIVEDNORF";
                selectstr += ",TBOSEARCHRF.EQUIPGENRECODERF";
                selectstr += ",TBOSEARCHRF.EQUIPNAMERF";
                selectstr += ",TBOSEARCHRF.CARINFOJOINDISPORDERRF";
                selectstr += ",TBOSEARCHRF.JOINDESTMAKERCDRF";
                selectstr += ",TBOSEARCHRF.JOINDESTPARTSNORF";
                selectstr += ",TBOSEARCHRF.JOINQTYRF";
                selectstr += ",TBOSEARCHRF.EQUIPSPECIALNOTERF";

                //�񋟗D�Ǖ��i�}�X�^����
                selectstr += ",PRIMEPARTSRF.PRIMEPARTSNAMERF";
                selectstr += ",PRIMEPARTSRF.PRIMEPARTSKANANMRF";
                selectstr += ",PRIMEPARTSRF.PARTSLAYERCDRF";
                selectstr += ",PRIMEPARTSRF.PRIMEPARTSSPECIALNOTERF";
                selectstr += ",PRIMEPARTSRF.PARTSATTRIBUTERF";
                selectstr += ",PRIMEPARTSRF.CATALOGDELETEFLAGRF ";

                if (inPara.CarMakerCd != 0) // �ԃ��[�J�[�R�[�h����@�i�����i����������j
                {
                    selectstr += ",SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF ";
                    selectstr += ",SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF ";
                }
                //�i�n�h�m����
                selectstr += " FROM PRIMEPARTSRF INNER JOIN TBOSEARCHRF ";
                selectstr += "ON PRIMEPARTSRF.GOODSMGROUPRF = TBOSEARCHRF.GOODSMGROUPRF";
                selectstr += " AND PRIMEPARTSRF.TBSPARTSCODERF = TBOSEARCHRF.TBSPARTSCODERF";
                selectstr += " AND PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = TBOSEARCHRF.JOINDESTPARTSNORF";
                selectstr += " AND PRIMEPARTSRF.PARTSMAKERCDRF = TBOSEARCHRF.JOINDESTMAKERCDRF";
                if (inPara.CarMakerCd != 0) // �ԃ��[�J�[�R�[�h����@�i�����i����������j
                {
                    selectstr += " LEFT OUTER JOIN SEARCHPRTNMRF ON (PRIMEPARTSRF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
                    selectstr += string.Format("AND SEARCHPRTNMRF.CARMAKERCODERF = {0}) ", inPara.CarMakerCd);
                }
                //�v�g�d�q�d����
                if (inPara.EquipGenreCode != 0)
                    wherestr = " WHERE TBOSEARCHRF.EQUIPGENRECODERF = @EQUIPGENRECODE ";

                //��������
                string wkstring = string.Empty;
                foreach (string str in inPara.EquipName)
                {
                    wkstring += "'" + str + "', ";
                }
                if (wkstring.Length > 0)
                {
                    if (wherestr == string.Empty)
                    {
                        wherestr = " WHERE TBOSEARCHRF.EQUIPNAMERF IN (" + wkstring.Remove(wkstring.Length - 2) + ") ";
                    }
                    else
                    {
                        wherestr += " AND TBOSEARCHRF.EQUIPNAMERF IN (" + wkstring.Remove(wkstring.Length - 2) + ") ";
                    }
                }

                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection);

                // Prameter�I�u�W�F�N�g�̍쐬
                if (inPara.EquipGenreCode != 0)
                {
                    SqlParameter equipGenreCode = sqlCommand.Parameters.Add("@EQUIPGENRECODE", SqlDbType.Int);	//��������
                    equipGenreCode.Value = SqlDataMediator.SqlSetInt(inPara.EquipGenreCode);
                }

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    TBOSearchRetWork mf = new TBOSearchRetWork();

                    //�񋟎��q��񌋍��}�X�^����
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    mf.EquipGenreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPGENRECODERF"));
                    mf.EquipName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EQUIPNAMERF"));
                    mf.CarInfoJoinDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARINFOJOINDISPORDERRF"));
                    mf.JoinDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDESTMAKERCDRF"));
                    mf.JoinDestPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDESTPARTSNORF"));
                    mf.JoinQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("JOINQTYRF"));
                    mf.EquipSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EQUIPSPECIALNOTERF"));

                    //�񋟗D�Ǖ��i�}�X�^����
                    mf.PrimePartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNAMERF"));
                    mf.PrimePartsKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSKANANMRF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PrimePartsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSSPECIALNOTERF"));
                    mf.PartsAttribute = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSATTRIBUTERF"));
                    mf.CatalogDelteFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGDELETEFLAGRF"));

                    if (inPara.CarMakerCd != 0) // �ԃ��[�J�[�R�[�h����@�i�����i����������j
                    {
                        mf.SearchPartsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSFULLNAMERF"));
                        mf.SearchPartsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSHALFNAMERF"));
                    }

                    retWork.Add(mf);
                }
                if (retWork.Count > 0)
                {
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
                base.WriteErrorLog(ex, "TBOSearchInfDB.SearchPrimeParts�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// �񋟎��q��񌋍����i���i�����i�������ށE�������̎w��j
        /// </summary>
        /// <param name="inPara"></param>
        /// <param name="retWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchPrimePartsPrice(TBOSearchCondWork inPara, out ArrayList retWork, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string selectstr = "";
            string wherestr = "";
            SqlDataReader myReader = null;

            retWork = new ArrayList();

            try
            {
                //[�P���ɏ����i�ɕR�t���D�Ǖi�𒊏o]
                selectstr = "SELECT ";

                //�D�ǉ��i�}�X�^����
                selectstr += "PRMPRTPRICERF.OFFERDATERF, ";
                selectstr += "PRMPRTPRICERF.PRMSETDTLNO1RF, ";
                selectstr += "PRMPRTPRICERF.PARTSMAKERCDRF, ";
                selectstr += "PRMPRTPRICERF.PRIMEPARTSNOWITHHRF, ";
                selectstr += "PRMPRTPRICERF.PRICESTARTDATERF, ";
                selectstr += "PRMPRTPRICERF.NEWPRICERF, ";
                selectstr += "PRMPRTPRICERF.OPENPRICEDIVRF ";

                //�i�n�h�m����
                selectstr += " FROM PRMPRTPRICERF INNER JOIN TBOSEARCHRF ";
                selectstr += " ON PRMPRTPRICERF.PRIMEPARTSNOWITHHRF = TBOSEARCHRF.JOINDESTPARTSNORF";
                selectstr += " AND PRMPRTPRICERF.PARTSMAKERCDRF = TBOSEARCHRF.JOINDESTMAKERCDRF";

                //�v�g�d�q�d����
                if (inPara.EquipGenreCode != 0)
                    wherestr = " WHERE TBOSEARCHRF.EQUIPGENRECODERF = @EQUIPGENRECODE ";

                //��������
                string wkstring = string.Empty;
                foreach (string str in inPara.EquipName)
                {
                    wkstring += "'" + str + "', ";
                }
                if (wkstring.Length > 0)
                {
                    if (wherestr == string.Empty)
                    {
                        wherestr = " WHERE TBOSEARCHRF.EQUIPNAMERF IN (" + wkstring.Remove(wkstring.Length - 2) + ") ";
                    }
                    else
                    {
                        wherestr += " AND TBOSEARCHRF.EQUIPNAMERF IN (" + wkstring.Remove(wkstring.Length - 2) + ") ";
                    }
                }

                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection);

                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter equipGenreCode = sqlCommand.Parameters.Add("@EQUIPGENRECODE", SqlDbType.Int);	//��������
                equipGenreCode.Value = SqlDataMediator.SqlSetInt(inPara.EquipGenreCode);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    TBOSearchPriceRetWork mf = new TBOSearchPriceRetWork();

                    //�D�ǉ��i�}�X�^����
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));
                    mf.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    mf.PrimePartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNOWITHHRF"));
                    mf.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
                    mf.NewPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NEWPRICERF"));
                    mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));

                    retWork.Add(mf);
                }
                if (retWork.Count > 0)
                {
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
                base.WriteErrorLog(ex, "TBOSearchInfDB.SearchPrimePartsPrice�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

    }
}
