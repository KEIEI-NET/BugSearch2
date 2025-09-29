using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using System.Collections.Generic; // --- ADD m.suzuki 2012/01/31
using Broadleaf.Library.Collections; // ADD 2014/06/12 PM-SCM���x���� �t�F�[�Y�Q ��Q�Ή� 


namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// �D�Ǖ��i���擾�����[�g�I�u�W�F�N�g�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �D�Ǖ��i���擾�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.13</br>
    /// <br></br>
    /// <br>Update Note: 2009.03.17 22018  ��� ���b</br>
    /// <br>           : �@�Z���N�g�R�[�h(PrmSetDtlNo1)���Z�b�g����悤�C���B</br>
    /// <br>           :   (�Z���N�g�R�[�h�ʂ̃f�[�^������Ƃ��Y���Ȃ��ɂȂ錻�ۂ̑Ή�)</br>
    /// <br></br>
    /// <br>Update Note: 2009/11/24�@21024 ���X�� ��</br>
    /// <br>           : �Z�b�g���i�����̖߂�l�ɁA�D�Ǖ��iBL�R�[�h�A�}�Ԃ�ǉ�(MANTIS[0013603])</br>
    /// <br></br>
    /// <br>Update Note: 2010/01/25�@21024 ���X�� ��</br>
    /// <br>           : �������x�`���[�j���O�Ή��i������֕��i�̓ǂݍ��ݕ��@�̏C��,MANTIS[0014934]�j</br>
    /// <br></br>
    /// <br>Update Note: 2010/04/28�@22018 ��� ���b</br>
    /// <br>           : ���R�����Ή��@�D�Ǖ��i���ꊇ�擾���鏈����ǉ��B(PMTKD06161R����Ăяo��)</br>
    /// <br></br>
    /// <br>Update Note: 2012/01/31�@22018 ��� ���b</br>
    /// <br>           : ��DB�ւ̕��׌y���Ή�</br>
    /// <br>           : �@�@������փ}�X�^�̒��o�񐔂��D�Ǖ��i�̌������ɂȂ��Ă����̂ŁA�ꊇ�Œ��o����悤�ύX�B</br>
    /// <br>           : �@�A�Z�b�g��փ}�X�^�̒��o�񐔂��Z�b�g�q�i�Ԃ̌������ɂȂ��Ă����̂ŁA�ꊇ�Œ��o����悤�ύX�B</br>
    /// <br>Update Note: 2014/05/09�@�g��</br>
    /// <br>           : ���x���P�t�F�[�Y�Q��11,��12 �i���^�C�~���O�ύX</br>
    /// <br></br>
    /// <br>Update Note: �Ǘ��ԍ�  11070076-00  PM-SCM���x���� �t�F�[�Y�Q�Ή�</br>
    /// <br>                                    13.�t���^���Œ�ԍ�����̂a�k�R�[�h�����񐔉��ǑΉ�</br>
    /// <br>                                    14.���׎捞�敪�̍X�V���@�����ǑΉ�</br>
    /// <br>                                    15.SCM�󔭒��f�[�^�i�ԗ����j�擾���@���ǑΉ�</br>
    /// <br>                                    16.�����i�������ǑΉ�</br>
    /// <br>                                    17.�D�Ǖi�������ǑΉ�</br>
    /// <br>Programmer : 30744 ���� ����q</br>
    /// <br>Date       : 2014/05/13</br>
    /// <br></br>
    /// <br>Update Note: �Ǘ��ԍ�  11070076-00  PM-SCM���x���� �t�F�[�Y�Q�Ή�</br>
    /// <br>                                    ��Q�Ή�</br>
    /// <br>Programmer : 30744 ���� ����q</br>
    /// <br>Date       : 2014/06/12</br>
    /// <br></br>
    /// <br>Update Note: �Ǘ��ԍ�  11070076-00  PM-SCM���x���� �t�F�[�Y�Q�Ή�</br>
    /// <br>                                    �p�u���b�N�ϐ����v���C�x�[�g�ϐ��ɕύX</br>
    /// <br>Programmer : 20073 �� �B</br>
    /// <br>Date       : 2014/08/07</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class PrimePartsInfDB : RemoteDB, IPrimePartsInfo
    {
        # region �o�t�a�k�h�b��`

        # region �D�Ǖi�Ԍ��� DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// <summary>
        ///�@�D�Ǖi�Ԍ��� DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        public PrimePartsInfDB()
            :
            base("PMTKD09063D", "Broadleaf.Application.Remoting.PrimePartsInfDB", "PRIMEPARTSRF")
        {
        }
        # endregion

        # region �D�Ǖi�Ԍ��� DB�����[�g�I�u�W�F�N�g
        /// <summary>
        /// �D�Ǖi�Ԍ��� DB�����[�g�I�u�W�F�N�g
        /// </summary>
        /// <param name="inPara">�����p�����[�^</param>
        /// <param name="inRetInf">���i���</param>
        /// <param name="inPrimePrice">���i���i</param>
        /// <param name="inRetSetParts">�Z�b�g���i</param>
        /// <param name="SetPrice">�Z�b�g���i</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �p�����[�^�Ŏw�肳�ꂽ�D�Ǖ��i����Ԃ��܂��B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.05.13</br>
        public int GetPartsInf(GetPrimePartsInfPara inPara, out ArrayList inRetInf, out ArrayList inPrimePrice,
                        out ArrayList inRetSetParts, out ArrayList SetPrice)
        {
            return GetPartsInfProc(inPara, out inRetInf, out inPrimePrice, out inRetSetParts, out SetPrice);
        }

        private int GetPartsInfProc(GetPrimePartsInfPara inPara, out ArrayList inRetInf, out ArrayList inPrimePrice,
                        out ArrayList inRetSetParts, out ArrayList SetPrice)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            //���ʂ̏�����
            inRetInf = new ArrayList();
            inPrimePrice = new ArrayList();
            inRetSetParts = new ArrayList();
            SetPrice = new ArrayList();

            try
            {
                SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //�D�Ǖi�Ԃ��j�d�x�ɂ��ėD�Ǖi�Ԃ�����
                status = SearchPrimePartsNo(inPara, out inRetInf, sqlConnection);
                if (status != 0)
                {
                    return (status);
                }
                //�Z�b�g�}�X�^�̓ǂݍ���
                ArrayList list = new ArrayList();
                foreach (OfferJoinPartsRetWork wk in inRetInf)
                {
                    OfrPartsCondWork ofrPartsCondWork = new OfrPartsCondWork();
                    ofrPartsCondWork.MakerCode = wk.JoinDestMakerCd;
                    ofrPartsCondWork.PrtsNo = wk.JoinDestPartsNo;
                    list.Add(ofrPartsCondWork);
                }
                SearchPartsPrice( list, out inPrimePrice, sqlConnection, null );

                if (inPara.SetSearchFlg == 1)
                {
                    status = SearchSetParts(0, list, out inRetSetParts, sqlConnection, null);
                    list = new ArrayList();
                    foreach (OfferSetPartsRetWork wk in inRetSetParts)
                    {
                        OfrPartsCondWork ofrPartsCondWork = new OfrPartsCondWork();
                        ofrPartsCondWork.MakerCode = wk.SetSubMakerCd;
                        ofrPartsCondWork.PrtsNo = wk.SetSubPartsNo;
                        list.Add(ofrPartsCondWork);
                    }
                    SearchPartsPrice( list, out SetPrice, sqlConnection, null );
                }
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "PrimePartsInfDB.GetPartsInf�ɂ�SQL�G���[���� Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimePartsInfDB.GetPartsInf�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        // --- ADD m.suzuki 2010/04/28 ---------->>>>>
        # region [�D�Ǖ��i����(���R�����p)]
        /// <summary>
        /// �D�Ǖ��i�����i���R�����p�j
        /// </summary>
        /// <param name="blGoodsCode"></param>
        /// <param name="condList"></param>
        /// <param name="inRetInf"></param>
        /// <param name="inPrimePrice"></param>
        /// <param name="inRetSetParts"></param>
        /// <param name="SetPrice"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        public int GetPrimePartsInfForFreeSearch( int blGoodsCode, ArrayList condList, out ArrayList inRetInf, out ArrayList inPrimePrice,
                        out ArrayList inRetSetParts, out ArrayList SetPrice, SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            //���ʂ̏�����
            inRetInf = new ArrayList();
            inPrimePrice = new ArrayList();
            inRetSetParts = new ArrayList();
            SetPrice = new ArrayList();

            try
            {
                //�D�Ǖi�Ԃ��j�d�x�ɂ��ėD�Ǖi�Ԃ�����
                status = SearchPrimePartsNoForFreeSearch( blGoodsCode, condList, out inRetInf, sqlConnection );
                if ( status != 0 )
                {
                    return (status);
                }
                //�Z�b�g�}�X�^�̓ǂݍ���
                ArrayList list = new ArrayList();
                foreach ( OfferJoinPartsRetWork wk in inRetInf )
                {
                    OfrPartsCondWork ofrPartsCondWork = new OfrPartsCondWork();
                    ofrPartsCondWork.MakerCode = wk.JoinDestMakerCd;
                    ofrPartsCondWork.PrtsNo = wk.JoinDestPartsNo;
                    list.Add( ofrPartsCondWork );
                }
                // �D�ǉ��i�ǂݍ���
                SearchPartsPrice( list, out inPrimePrice, sqlConnection, null );

                // �Z�b�g�ǂݍ���
                status = SearchSetParts( 0, list, out inRetSetParts, sqlConnection, null );
                list = new ArrayList();
                foreach ( OfferSetPartsRetWork wk in inRetSetParts )
                {
                    OfrPartsCondWork ofrPartsCondWork = new OfrPartsCondWork();
                    ofrPartsCondWork.MakerCode = wk.SetSubMakerCd;
                    ofrPartsCondWork.PrtsNo = wk.SetSubPartsNo;
                    list.Add( ofrPartsCondWork );
                }
                // �Z�b�g���i�ǂݍ���
                SearchPartsPrice( list, out SetPrice, sqlConnection, null );
            }
            catch ( SqlException ex )
            {
                return base.WriteSQLErrorLog( ex, "PrimePartsInfDB.GetPartsInf�ɂ�SQL�G���[���� Msg=" + ex.Message, 0 );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "PrimePartsInfDB.GetPartsInf�ɂăG���[���� Msg=" + ex.Message, 0 );
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
            }
            return status;
        }

        /// <summary>
        /// �D�Ǖ��i���擾�i���R�����p�j
        /// </summary>
        /// <param name="blGoodsCode"></param>
        /// <param name="condList"></param>
        /// <param name="inRetInf"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        /// <remarks>��SearchPrimePartsNo�����ɕ����i�ԂɑΉ����鏈���Ƃ��ĐV�K�쐬���܂��B</remarks>
        private int SearchPrimePartsNoForFreeSearch( int blGoodsCode, ArrayList condList, out ArrayList inRetInf, SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string selectstr = string.Empty;
            string wherestr = string.Empty;
            SqlDataReader myReader = null;

            inRetInf = new ArrayList();

            try
            {
                SqlCommand sqlCommand = new SqlCommand();

                //[�񋟗D�Ǖi�Ԍ���]
                selectstr = "SELECT ";
                selectstr += "PRM.OFFERDATERF, ";
                selectstr += "PRM.GOODSMGROUPRF, ";
                selectstr += "PRM.TBSPARTSCODERF, ";
                selectstr += "PRM.TBSPARTSCDDERIVEDNORF, ";
                selectstr += "PRM.PRMSETDTLNO1RF, ";
                selectstr += "PRM.PARTSMAKERCDRF, ";
                selectstr += "PRM.PRIMEPARTSNOWITHHRF, ";
                selectstr += "PRM.PRIMEPARTSNONONEHRF, ";
                selectstr += "PRM.PRIMEPARTSNAMERF, ";
                selectstr += "PRM.PRIMEPARTSKANANMRF, ";
                selectstr += "PRM.PARTSLAYERCDRF, ";
                selectstr += "PRM.PRIMEPARTSSPECIALNOTERF, ";
                selectstr += "PRM.PARTSATTRIBUTERF, ";
                selectstr += "PRM.CATALOGDELETEFLAGRF, ";
                selectstr += "PRM.PRMPARTSILLUSTCRF, ";
                selectstr += "SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF, ";
                selectstr += "SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF ";

                selectstr += " FROM PRIMEPARTSRF AS PRM ";

                selectstr += " LEFT OUTER JOIN SEARCHPRTNMRF ON (@FINDBLGOODSCODE = SEARCHPRTNMRF.TBSPARTSCODERF ";
                selectstr += " AND PRM.PARTSMAKERCDRF = SEARCHPRTNMRF.CARMAKERCODERF ) ";

                SqlParameter findBLGoodsCode = sqlCommand.Parameters.Add( "@FINDBLGOODSCODE", SqlDbType.Int );
                findBLGoodsCode.Value = SqlDataMediator.SqlSetInt32( blGoodsCode );

                # region [WHERE]
                wherestr = " WHERE ";

                for ( int index = 0; index < condList.Count; index++ )
                {
                    if ( index > 0 )
                    {
                        wherestr += " OR ";
                    }
                    wherestr += string.Format( " (PRM.PRIMEPARTSNOWITHHRF = @PARTSNORF{0} AND PRM.PARTSMAKERCDRF = @PARTSMAKERCDRF{0}) ", index );


                    OfrPartsCondWork cond = (condList[index] as OfrPartsCondWork);

                    // �i��
                    SqlParameter ptno = sqlCommand.Parameters.Add( string.Format( "@PARTSNORF{0}", index ), SqlDbType.NVarChar );
                    ptno.Value = SqlDataMediator.SqlSetString( cond.PrtsNo );

                    // ���[�J�[
                    SqlParameter mkcd = sqlCommand.Parameters.Add( string.Format( "@PARTSMAKERCDRF{0}", index ), SqlDbType.Int );
                    mkcd.Value = SqlDataMediator.SqlSetInt( cond.MakerCode );
                }
                # endregion

                selectstr += wherestr;

                selectstr += " ORDER BY PRM.PARTSMAKERCDRF, PRM.PRIMEPARTSNOWITHHRF";


                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = selectstr;
                sqlCommand.Transaction = null;


                myReader = sqlCommand.ExecuteReader();
                while ( myReader.Read() )
                {
                    OfferJoinPartsRetWork mf = new OfferJoinPartsRetWork();

                    # region [���ʊi�[]
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "OFFERDATERF" ) );
                    mf.GoodsMGroup = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSMGROUPRF" ) );
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "TBSPARTSCODERF" ) );
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "TBSPARTSCDDERIVEDNORF" ) );
                    mf.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PRMSETDTLNO1RF" ) );
                    mf.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PARTSMAKERCDRF" ) );
                    mf.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRIMEPARTSNOWITHHRF" ) );
                    mf.JoinSourPartsNoNoneH = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRIMEPARTSNONONEHRF" ) );
                    mf.JoinDestMakerCd = mf.JoinSourceMakerCode;
                    mf.JoinDestPartsNo = mf.JoinSourPartsNoWithH;
                    mf.PrimePartsName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRIMEPARTSNAMERF" ) );
                    mf.PrimePartsKanaName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRIMEPARTSKANANMRF" ) );
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PARTSLAYERCDRF" ) );
                    mf.PrimePartsSpecialNote = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRIMEPARTSSPECIALNOTERF" ) );
                    mf.PartsAttribute = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PARTSATTRIBUTERF" ) );
                    mf.CatalogDeleteFlag = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CATALOGDELETEFLAGRF" ) );
                    mf.PrmPartsIllustC = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRMPARTSILLUSTCRF" ) );
                    mf.SearchPartsFullName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SEARCHPARTSFULLNAMERF" ) );
                    mf.SearchPartsHalfName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SEARCHPARTSHALFNAMERF" ) );
                    # endregion

                    inRetInf.Add( mf );
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch ( SqlException ex )
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "PrimePartsInfDB.SearchPrimePartsNo�ɂăG���[���� Msg=" + ex.Message, 0 );
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( myReader != null && !myReader.IsClosed ) myReader.Close();
            }

            return status;
        }
        # endregion
        // --- ADD m.suzuki 2010/04/28 ----------<<<<<
        # endregion

        #region �����i�ԁ@���@��������
        /// <summary>
        /// �D�Ǖi�Ԍ��� DB�����[�g�I�u�W�F�N�g[�����i�ԁ@���@��������]
        /// </summary>
        /// <param name="priceDate"></param>
        /// <param name="substFlg">��փt���O[true:����/false:���Ȃ�]</param>
        /// <param name="carMakerCd">�����i�������p�ԃ��[�J�[�R�[�h[0�̏ꍇ�͌����i�������Ȃ�]</param>
        /// <param name="inPara">�����p�����[�^</param>		
        /// <param name="inRetInf">���i���</param>
        /// <param name="inPrimePrice"></param>
        /// <param name="inRetSetParts"></param>
        /// <param name="SetPrice"></param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �p�����[�^�Ŏw�肳�ꂽ�D�Ǖ��i����Ԃ��܂��B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.05.13</br>
        public int GetPartsInfByCtlgPtNo( bool substFlg, int carMakerCd, ArrayList inPara, out ArrayList inRetInf,
                out ArrayList inPrimePrice, out ArrayList inRetSetParts, out ArrayList SetPrice )
        {
            SqlConnection sqlConnection = null;
            inRetInf = null;
            inPrimePrice = null;
            inRetSetParts = null;
            SetPrice = null;
            try
            {
                SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                return GetPartsInfByCtlgPtNoProc( substFlg, carMakerCd, inPara, out inRetInf, out inPrimePrice,
                            out inRetSetParts, out SetPrice, sqlConnection );
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "PrimePartsInfDB.GetPartsInfByCtlgPtNo�ɂ�SQL�G���[���� Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimePartsInfDB.GetPartsInfByCtlgPtNo�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }
        }

        // ADD 2014/05/13 PM-SCM���x���� �t�F�[�Y�Q��17.�D�Ǖi�������ǑΉ� ---------------------------------->>>>>
        /// <summary>
        /// �D�Ǖi�Ԍ��� DB�����[�g�I�u�W�F�N�g[�����i�ԁ@���@��������]�i�����񓚏�����p�j
        /// </summary>
        /// <param name="priceDate"></param>
        /// <param name="substFlg">��փt���O[true:����/false:���Ȃ�]</param>
        /// <param name="carMakerCd">�����i�������p�ԃ��[�J�[�R�[�h[0�̏ꍇ�͌����i�������Ȃ�]</param>
        /// <param name="inPara">�����p�����[�^</param>		
        /// <param name="inRetInf">���i���</param>
        /// <param name="inPrimePrice"></param>
        /// <param name="inRetSetParts"></param>
        /// <param name="SetPrice"></param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �p�����[�^�Ŏw�肳�ꂽ�D�Ǖ��i����Ԃ��܂��B</br>
        // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi ----->>>>>
        //// UPD 2014/06/12 PM-SCM���x���� �t�F�[�Y�Q ��Q�Ή� ---------------------------->>>>>
        ////public int GetPartsInfByCtlgPtNoAutoAnswer(bool substFlg, int carMakerCd, ArrayList inPara, out ArrayList inRetInf,
        ////        out ArrayList inPrimePrice, out ArrayList inRetSetParts, out ArrayList SetPrice)
        //public int GetPartsInfByCtlgPtNoAutoAnswer(bool substFlg, int carMakerCd, ArrayList inPara, out object inRetInf,
        //        out object inPrimePrice, out object inRetSetParts, out object SetPrice)
        public int GetPartsInfByCtlgPtNoAutoAnswer(string sectionCodeWk, int customerCodeWk, List<object> obAutoAnsItemStList, List<object> obPrmSettingList,
            bool substFlg, int carMakerCd, ArrayList inPara, out object inRetInf,
                out object inPrimePrice, out object inRetSetParts, out object SetPrice)
        //// UPD 2014/06/12 PM-SCM���x���� �t�F�[�Y�Q ��Q�Ή� ----------------------------<<<<<
        // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi -----<<<<<
        {
            SqlConnection sqlConnection = null;
            // UPD 2014/06/12 PM-SCM���x���� �t�F�[�Y�Q ��Q�Ή� ---------------------------->>>>>
            //inRetInf = new ArrayList();
            //inPrimePrice = new ArrayList();
            //inRetSetParts = new ArrayList();
            //SetPrice = new ArrayList();
            CustomSerializeArrayList inRetInfCustomSerializeArrayList = new CustomSerializeArrayList();
            inRetInf = inRetInfCustomSerializeArrayList;
            CustomSerializeArrayList inPrimePriceCustomSerializeArrayList = new CustomSerializeArrayList();
            inPrimePrice = inPrimePriceCustomSerializeArrayList;
            CustomSerializeArrayList inRetSetPartsCustomSerializeArrayList = new CustomSerializeArrayList();
            inRetSetParts = inRetSetPartsCustomSerializeArrayList;
            CustomSerializeArrayList SetPriceCustomSerializeArrayList = new CustomSerializeArrayList();
            SetPrice = SetPriceCustomSerializeArrayList;
            // UPD 2014/06/12 PM-SCM���x���� �t�F�[�Y�Q ��Q�Ή� ----------------------------<<<<<

            ArrayList retInRetInf = new ArrayList();
            ArrayList retInPrimePrice = new ArrayList();
            ArrayList retInRetSetParts = new ArrayList();
            ArrayList retSetPrice = new ArrayList();

            try
            {

                // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi ----->>>>>
                List<AutoAnsItemStForOffer> autoAnsItemStList = new List<AutoAnsItemStForOffer>();
                List<PrmSettingUForOffer> prmSettingUList = new List<PrmSettingUForOffer>();
                int customerCode = 0;
                string sectionCode = string.Empty;

                CacheAutoAnswer(sectionCodeWk, customerCodeWk, obAutoAnsItemStList, obPrmSettingList,
                                    ref autoAnsItemStList, ref prmSettingUList, out customerCode, out sectionCode);
                // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi -----<<<<<

                SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                if (inPara != null && inPara.Count != 0)
                {
                    foreach (ArrayList paraList in inPara)
                    {
                        // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi ----->>>>>
                        //status = GetPartsInfByCtlgPtNoProcAutoAnswer(substFlg, carMakerCd, paraList, out retInRetInf, out retInPrimePrice,
                        //    out retInRetSetParts, out retSetPrice, sqlConnection);
                        status = GetPartsInfByCtlgPtNoProcAutoAnswer(autoAnsItemStList, prmSettingUList, customerCode, sectionCode, substFlg, carMakerCd, paraList, out retInRetInf, out retInPrimePrice,
                            out retInRetSetParts, out retSetPrice, sqlConnection);
                        // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi -----<<<<<

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // UPD 2014/06/12 PM-SCM���x���� �t�F�[�Y�Q ��Q�Ή� ---------------------------->>>>>
                            //if (retInRetInf == null || retInRetInf.Count == 0) SetInRetInf(ref retInRetInf);
                            //inRetInf.Add(retInRetInf);
                            //if (retInPrimePrice == null || retInPrimePrice.Count == 0) SetInPrimePrice(ref retInPrimePrice);
                            //inPrimePrice.Add(retInPrimePrice);
                            //if (retInRetSetParts == null || retInRetSetParts.Count == 0) SetInRetSetParts(ref retInRetSetParts);
                            //inRetSetParts.Add(retInRetSetParts);
                            //if (retSetPrice == null || retSetPrice.Count == 0) SetSetPrice(ref retSetPrice);
                            //SetPrice.Add(retSetPrice);
                            if (retInRetInf == null || retInRetInf.Count == 0) SetInRetInf(ref retInRetInf);
                            inRetInfCustomSerializeArrayList.Add(retInRetInf);
                            if (retInPrimePrice == null || retInPrimePrice.Count == 0) SetInPrimePrice(ref retInPrimePrice);
                            inPrimePriceCustomSerializeArrayList.Add(retInPrimePrice);
                            if (retInRetSetParts == null || retInRetSetParts.Count == 0) SetInRetSetParts(ref retInRetSetParts);
                            inRetSetPartsCustomSerializeArrayList.Add(retInRetSetParts);
                            if (retSetPrice == null || retSetPrice.Count == 0) SetSetPrice(ref retSetPrice);
                            SetPriceCustomSerializeArrayList.Add(retSetPrice);
                            // UPD 2014/06/12 PM-SCM���x���� �t�F�[�Y�Q ��Q�Ή� ----------------------------<<<<<
                        }
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                return status;
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "PrimePartsInfDB.GetPartsInfByCtlgPtNo�ɂ�SQL�G���[���� Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimePartsInfDB.GetPartsInfByCtlgPtNo�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        ///  �D�Ǖi�ԏ�񏉊����ݒ�
        /// </summary>
        /// <param name="retInRetInf"></param>
        private void SetInRetInf(ref ArrayList retInRetInf)
        {
            OfferJoinPartsRetWork mf = new OfferJoinPartsRetWork();

            mf.CatalogDeleteFlag = 0;
            mf.GoodsMGroup = 0;
            mf.JoinDestMakerCd = 0;
            mf.JoinDestPartsNo = string.Empty;
            mf.JoinDispOrder = 0;
            mf.JoinQty = 0;
            mf.JoinSourceMakerCode = 0;
            mf.JoinSourPartsNoNoneH = string.Empty;
            mf.JoinSourPartsNoWithH = string.Empty;
            mf.JoinSpecialNote = string.Empty;
            mf.OfferDate = DateTime.MinValue;
            mf.PartsAttribute = 0;
            mf.PartsLayerCd = string.Empty;
            mf.PrimePartsKanaName = string.Empty; ;
            mf.PrimePartsName = string.Empty; ;
            mf.PrimePartsSpecialNote = string.Empty;
            mf.PrmPartsIllustC = string.Empty;
            mf.PrmSetDtlNo1 = 0;
            mf.PrmSetDtlNo2 = 0;
            mf.SearchPartsFullName = string.Empty;
            mf.SearchPartsHalfName = string.Empty;
            mf.SetPartsFlg = 0;
            mf.SubstKubun = 0;
            mf.TbsPartsCdDerivedNo = 0;
            mf.TbsPartsCode = 0;

            retInRetInf.Add(mf);
        }
        /// <summary>
        ///  �D�Ǖi�ԉ��i��񏉊����ݒ�
        /// </summary>
        /// <param name="retInPrimePrice"></param>
        private void SetInPrimePrice(ref ArrayList retInPrimePrice)
        {
            OfferJoinPriceRetWork mf = new OfferJoinPriceRetWork();

            mf.NewPrice = 0;
            mf.OfferDate = DateTime.MinValue;
            mf.OpenPriceDiv = 0;
            mf.PartsMakerCd = 0;
            mf.PriceStartDate = DateTime.MinValue;
            mf.PrimePartsNoWithH = string.Empty;
            mf.PrmSetDtlNo1 = 0;

            retInPrimePrice.Add(mf);

        }
        /// <summary>
        ///  �Z�b�g�i��񏉊����ݒ�
        /// </summary>
        /// <param name="retInRetSetParts"></param>
        private void SetInRetSetParts(ref ArrayList retInRetSetParts)
        {
            OfferSetPartsRetWork mf = new OfferSetPartsRetWork();

            mf.CatalogDeleteFlag = 0;
            mf.CatalogShapeNo = string.Empty;
            mf.GoodsMGroup = 0;
            mf.OfferDate = DateTime.MinValue;
            mf.PartsAttribute = 0;
            mf.PartsLayerCd = string.Empty;
            mf.PrimePartsKanaName = string.Empty;
            mf.PrimePartsName = string.Empty;
            mf.PrimePartsSpecialNote = string.Empty;
            mf.PrmPartsIllustC = string.Empty;
            mf.PrmPrtTbsPrtCd = 0;
            mf.PrmPrtTbsPrtCdDerivNo = 0;
            mf.SearchPartsFullName = string.Empty;
            mf.SearchPartsHalfName = string.Empty;
            mf.SetDispOrder = 0;
            mf.SetMainMakerCd = 0;
            mf.SetMainPartsNo = string.Empty;
            mf.SetName = string.Empty;
            mf.SetQty = 0;
            mf.SetSpecialNote = string.Empty;
            mf.SetSubMakerCd = 0;
            mf.SetSubPartsNo = string.Empty;
            mf.SubstKubun = 0;
            mf.TbsPartsCdDerivedNo = 0;
            mf.TbsPartsCode = 0;

            retInRetSetParts.Add(mf);

        }
        /// <summary>
        ///  �Z�b�g�i���i��񏉊����ݒ�
        /// </summary>
        /// <param name="retSetPrice"></param>
        private void SetSetPrice(ref ArrayList retSetPrice)
        {
            OfferJoinPriceRetWork mf = new OfferJoinPriceRetWork();

            mf.NewPrice = 0;
            mf.OfferDate = DateTime.MinValue;
            mf.OpenPriceDiv = 0;
            mf.PartsMakerCd = 0;
            mf.PriceStartDate = DateTime.MinValue;
            mf.PrimePartsNoWithH = string.Empty;
            mf.PrmSetDtlNo1 = 0;

            retSetPrice.Add(mf);

        }

        // ADD 2014/05/13 PM-SCM���x���� �t�F�[�Y�Q��17.�D�Ǖi�������ǑΉ� ----------------------------------<<<<<

        /// <summary>
        /// 
        /// </summary>
        /// <param name="priceDate"></param>
        /// <param name="substFlg"></param>
        /// <param name="carMakerCd"></param>
        /// <param name="inPara"></param>
        /// <param name="inRetInf"></param>
        /// <param name="inPrimePrice"></param>
        /// <param name="inRetSetParts"></param>
        /// <param name="SetPrice"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int GetPartsInfByCtlgPtNoProc( bool substFlg, int carMakerCd, ArrayList inPara, out ArrayList inRetInf,
                out ArrayList inPrimePrice, out ArrayList inRetSetParts, out ArrayList SetPrice, SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            ArrayList condListForJoin = (ArrayList)inPara.Clone();

            inRetInf = new ArrayList();
            inPrimePrice = new ArrayList();
            inRetSetParts = new ArrayList();
            SetPrice = new ArrayList();

            //�����i�Ԃ��j�d�x�ɂ��ėD�ǌ����i�Ԃ�����
            status = SearchPrimePartsNo(carMakerCd, condListForJoin, out inRetInf, sqlConnection, null);

            if (status != 0)
            {
                return (status);
            }

            ArrayList listForSetSearch = new ArrayList();
            // --- ADD m.suzuki 2012/01/31 ---------->>>>>
            ArrayList listForJoinSubst = new ArrayList(); // ������ւ̌����������X�g (��������)
            Dictionary<string, OfferJoinPartsRetWork> joinSrcInfoDic = new Dictionary<string, OfferJoinPartsRetWork>(); // ������ւ̌����Ɏg�p���錋�������f�B�N�V���i��
            Dictionary<string, OfferJoinPartsRetWork> newJoinSrcInfoDic;
            // --- ADD m.suzuki 2012/01/31 ----------<<<<<
            if (substFlg) // ������֌���
            {
                ArrayList primeSubstList = new ArrayList();
                // ������ւ�S�ĒT���B���i�ԁ��V�i�ԁ�(�V�i��->���i��)���V�i�ԁ�  10����܂�
                foreach (OfferJoinPartsRetWork wk in inRetInf)
                {
                    OfrPartsCondWork condWork = new OfrPartsCondWork();
                    condWork.MakerCode = wk.JoinDestMakerCd;
                    condWork.PrtsNo = wk.JoinDestPartsNo;
                    condWork.PrtsNoOrg = wk.JoinSourPartsNoWithH;
                    condListForJoin.Add(condWork); // �����i�̉��i�����̂��� 
                    listForSetSearch.Add(condWork); // �����ŃZ�b�g�}�X�^�����p���X�g��\�ߍ���Ēu���B

                    // --- UPD m.suzuki 2012/01/31 ---------->>>>>
                    # region // DEL
                    //for ( int i = 1; i < 11; i++ )
                    //{
                    //    OfferJoinPartsRetWork primeSubstWork;
                    //    // 2010/01/25 >>>
                    //    //SearchJoinSubst(carMakerCd, condWork, out primeSubstWork, sqlConnection, null);
                    //    SearchJoinSubst( carMakerCd, wk, condWork, out primeSubstWork, sqlConnection, null );
                    //    // 2010/01/25 <<<
                    //    if ( primeSubstWork != null )
                    //    {
                    //        primeSubstList.Add( primeSubstWork );
                    //
                    //        condWork = new OfrPartsCondWork();
                    //        condWork.MakerCode = primeSubstWork.JoinDestMakerCd;
                    //        condWork.PrtsNo = primeSubstWork.JoinDestPartsNo;
                    //        condWork.PrtsNoOrg = primeSubstWork.JoinSourPartsNoWithH;
                    //        condListForJoin.Add( condWork ); // ������֕i�̉��i�����̂��� !!!!!!!!
                    //    }
                    //    else
                    //    {
                    //        break;
                    //    }
                    //}
                    # endregion
                    // ������ւ̌����p���X�g�Ɋi�[
                    listForJoinSubst.Add( condWork ); 
                    
                    // ���������f�B�N�V���i���Ɋi�[
                    string key = GetJoinSrcInfoKey( condWork.MakerCode, condWork.PrtsNo );
                    if ( !joinSrcInfoDic.ContainsKey( key ) )
                    {
                        joinSrcInfoDic.Add( key, wk );
                    }
                    // --- UPD m.suzuki 2012/01/31 ----------<<<<<
                }
                // --- ADD m.suzuki 2012/01/31 ---------->>>>>
                if ( listForJoinSubst.Count > 0 )
                {
                    // ������֌���(10����)
                    for ( int i = 1; i < 11; i++ )
                    {
                        // ������֌����i���オ�i�ނ� joinSrcInfoDic �� listForJoinSubst �������ւ��j
                        SearchJoinSubst( carMakerCd, joinSrcInfoDic, listForJoinSubst, out primeSubstList, out newJoinSrcInfoDic, sqlConnection, null );

                        // �������ʂ����X�g�Ɋi�[
                        if ( primeSubstList != null && primeSubstList.Count > 0 )
                        {
                            // (���̐����)������ւ̌����������X�g���쐬������
                            listForJoinSubst = new ArrayList();

                            foreach ( OfferJoinPartsRetWork primeSubstWork in primeSubstList )
                            {
                                OfrPartsCondWork condWork = new OfrPartsCondWork();
                                condWork.MakerCode = primeSubstWork.JoinDestMakerCd;
                                condWork.PrtsNo = primeSubstWork.JoinDestPartsNo;
                                condWork.PrtsNoOrg = primeSubstWork.JoinSourPartsNoWithH;

                                condListForJoin.Add( condWork ); // ������֕i�̉��i�����ׁ̈A�Z�b�g
                                listForJoinSubst.Add( condWork ); // ������ւ̎����㌟���ׁ̈A�Z�b�g
                            }

                            // (���̐����)���������f�B�N�V���i���̍����ւ�
                            joinSrcInfoDic = newJoinSrcInfoDic;
                        }
                        else
                        {
                            // �Y�����Ȃ�������10���㕪�̃��[�v���I��
                            break;
                        }
                    }
                }
                // --- ADD m.suzuki 2012/01/31 ----------<<<<<
                inRetInf.AddRange(primeSubstList);
            }
            else // ��֌������Ȃ��ꍇ�A���i�E�Z�b�g�����̂��߈ȉ��̃��X�g�쐬���s���B
            {
                foreach (OfferJoinPartsRetWork wk in inRetInf)
                {
                    OfrPartsCondWork condWork = new OfrPartsCondWork();
                    condWork.MakerCode = wk.JoinDestMakerCd;
                    condWork.PrtsNo = wk.JoinDestPartsNo;
                    condWork.PrtsNoOrg = wk.JoinSourPartsNoWithH;
                    condListForJoin.Add(condWork); // �����i�̉��i�����̂��� 
                    listForSetSearch.Add(condWork); // �����ŃZ�b�g�}�X�^�����p���X�g��\�ߍ���Ēu���B
                }
            }

            // �����E������ւ̉��i�����擾����B
            SearchPartsPrice( condListForJoin, out inPrimePrice, sqlConnection, null );

            //�Z�b�g�}�X�^�̓ǂݍ���
            status = SearchSetParts(carMakerCd, listForSetSearch, out inRetSetParts, sqlConnection, null);

            if (substFlg) // �Z�b�g��֌���
            {
                ArrayList list = (ArrayList)inRetSetParts.Clone();

                // --- UPD m.suzuki 2012/01/31 ---------->>>>>
                # region // DEL
                //// �Z�b�g��ւ�S�ĒT���B���i�ԁ��V�i�ԁ�(�V�i��->���i��)���V�i�ԁ�  10����܂�
                //foreach (OfferSetPartsRetWork wk in list)
                //{
                //    OfferSetPartsRetWork condWork = wk;
                //    for (int i = 1; i < 11; i++)
                //    {
                //        OfferSetPartsRetWork setSubst;
                //        SearchSetSubst(carMakerCd, condWork, out setSubst, sqlConnection, null);
                //        if (setSubst != null)
                //        {
                //            inRetSetParts.Add(setSubst);
                //
                //            condWork = new OfferSetPartsRetWork();
                //            condWork.SetMainPartsNo = setSubst.SetMainPartsNo;
                //            condWork.SetSubMakerCd = setSubst.SetSubMakerCd;
                //            condWork.SetSubPartsNo = setSubst.SetSubPartsNo;
                //        }
                //        else
                //        {
                //            break;
                //        }
                //    }
                //}
                # endregion

                if ( list.Count > 0 )
                {
                    // �Z�b�g���f�B�N�V���i������
                    Dictionary<string, OfferSetPartsRetWork> setPartsDic = new Dictionary<string, OfferSetPartsRetWork>();
                    foreach ( OfferSetPartsRetWork setPartsRetWork in inRetSetParts )
                    {
                        string key = GetSetPartsInfoKey( setPartsRetWork.SetSubMakerCd, setPartsRetWork.SetMainPartsNo, setPartsRetWork.SetSubPartsNo );
                        if ( !setPartsDic.ContainsKey( key ) )
                        {
                            setPartsDic.Add( key, setPartsRetWork );
                        }
                    }

                    ArrayList setSubstList;
                    Dictionary<string, OfferSetPartsRetWork> newSetPartsDic;

                    // �Z�b�g��֌���(10����)
                    for ( int i = 0; i < 11; i++ )
                    {
                        // �Z�b�g��֌���
                        SearchSetSubst( carMakerCd, setPartsDic, list, out setSubstList, out newSetPartsDic, sqlConnection, null );

                        if ( setSubstList != null && setSubstList.Count > 0 )
                        {
                            // (���̐����)�Z�b�g��ւ̌����������X�g���쐬������
                            list = new ArrayList();
                            foreach ( OfferSetPartsRetWork setSubst in setSubstList )
                            {
                                inRetSetParts.Add( setSubst ); // �Z�b�g�̌������ʃ��X�g�ɒǉ�

                                OfferSetPartsRetWork condWork = new OfferSetPartsRetWork();
                                condWork.SetMainPartsNo = setSubst.SetMainPartsNo;
                                condWork.SetSubMakerCd = setSubst.SetSubMakerCd;
                                condWork.SetSubPartsNo = setSubst.SetSubPartsNo;
                                list.Add( condWork );
                            }

                            // (���̐����)�Z�b�g���f�B�N�V���i���̍����ւ�
                            setPartsDic = newSetPartsDic;
                        }
                        else
                        {
                            // �Y�����Ȃ�������10���㕪�̃��[�v���I��
                            break;
                        }
                    }
                }
                // --- UPD m.suzuki 2012/01/31 ----------<<<<<
            }

            // �Z�b�g�E�Z�b�g��ւ̉��i�����擾����B
            ArrayList listForSetPrice = new ArrayList();
            foreach (OfferSetPartsRetWork wk in inRetSetParts)
            {
                OfrPartsCondWork ofrPartsCondWork = new OfrPartsCondWork();
                ofrPartsCondWork.MakerCode = wk.SetSubMakerCd;
                ofrPartsCondWork.PrtsNo = wk.SetSubPartsNo;
                listForSetPrice.Add(ofrPartsCondWork);
            }
            SearchPartsPrice( listForSetPrice, out SetPrice, sqlConnection, null );

            return status;
        }
        #endregion

        # region �����i�Ԃj�d�x���D�ǌ������i����
        /// <summary>
        /// �����i�Ԃj�d�x���D�Ǖ��i����
        /// </summary>
        /// <param name="carMakerCd">�����i�������p�ԃ��[�J�[�R�[�h</param>
        /// <param name="inWork">�������X�g</param>
        /// <param name="retWork">���ʃ��X�g</param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int SearchPrimePartsNo(int carMakerCd, ArrayList inWork, out ArrayList retWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            retWork = new ArrayList();

            if (inWork == null)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            if (inWork.Count == 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            return SearchPrimePartsNoProc(carMakerCd, inWork, ref retWork, sqlConnection, sqlTransaction);
        }

        private int SearchPrimePartsNoProc(int carMakerCd, ArrayList inWork, ref ArrayList retWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string selectstr = string.Empty;
            string wherestr = string.Empty;

            SqlDataReader myReader = null;

            try
            {
                //[�P���ɏ����i�ɕR�t���D�Ǖi�𒊏o]
                selectstr = "SELECT ";
                //selectstr += "JOINPARTSRF.OFFERDATERF, ";
                selectstr += "JOINPARTSRF.GOODSMGROUPRF ";
                selectstr += ",JOINPARTSRF.TBSPARTSCODERF ";
                selectstr += ",JOINPARTSRF.TBSPARTSCDDERIVEDNORF ";
                selectstr += ",JOINPARTSRF.PRMSETDTLNO1RF "; // �Z���N�g�R�[�h
                selectstr += ",JOINPARTSRF.PRMSETDTLNO2RF "; // ��ʃR�[�h
                selectstr += ",JOINPARTSRF.JOINDISPORDERRF ";
                selectstr += ",JOINPARTSRF.JOINSOURCEMAKERCODERF ";
                selectstr += ",JOINPARTSRF.JOINSOURPARTSNOWITHHRF ";
                selectstr += ",JOINPARTSRF.JOINSOURPARTSNONONEHRF ";
                selectstr += ",JOINPARTSRF.JOINDESTMAKERCDRF ";
                selectstr += ",JOINPARTSRF.JOINDESTPARTSNORF ";
                selectstr += ",JOINPARTSRF.JOINQTYRF ";
                selectstr += ",JOINPARTSRF.SETPARTSFLGRF ";
                selectstr += ",JOINPARTSRF.JOINSPECIALNOTERF ";

                selectstr += ",PRIMEPARTSRF.OFFERDATERF ";
                selectstr += ",PRIMEPARTSRF.PRIMEPARTSNAMERF ";
                selectstr += ",PRIMEPARTSRF.PRIMEPARTSKANANMRF ";
                selectstr += ",PRIMEPARTSRF.PARTSLAYERCDRF ";
                selectstr += ",PRIMEPARTSRF.PRIMEPARTSSPECIALNOTERF ";
                selectstr += ",PRIMEPARTSRF.PARTSATTRIBUTERF ";
                selectstr += ",PRIMEPARTSRF.CATALOGDELETEFLAGRF ";

                if (carMakerCd != 0) // �ԃ��[�J�[�R�[�h����@�i�����i����������j
                {
                    selectstr += ",SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF ";
                    selectstr += ",SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF ";
                }

                selectstr += " FROM PRIMEPARTSRF INNER JOIN JOINPARTSRF ON PRIMEPARTSRF.PARTSMAKERCDRF = JOINPARTSRF.JOINDESTMAKERCDRF";
                selectstr += " AND PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = JOINPARTSRF.JOINDESTPARTSNORF ";

                if (carMakerCd != 0) // �ԃ��[�J�[�R�[�h����@�i�����i����������j
                {
                    selectstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (JOINPARTSRF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
                    selectstr += string.Format("AND SEARCHPRTNMRF.CARMAKERCODERF = {0}) ", carMakerCd);
                }

                selectstr += " WHERE ";

                foreach (OfrPartsCondWork wk in inWork)
                {
                    //���[�J�[�R�[�h
                    wherestr += " OR ( ";
                    wherestr += " JOINPARTSRF.JOINSOURCEMAKERCODERF = " + wk.MakerCode;
                    wherestr += " AND JOINPARTSRF.JOINSOURPARTSNOWITHHRF = '" + wk.PrtsNo + "'";
                    wherestr += " ) ";
                }
                wherestr = wherestr.Substring(3); // �擪��OR����

                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection, sqlTransaction);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    OfferJoinPartsRetWork mf = new OfferJoinPartsRetWork();

                    //�������
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    mf.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));    // �Z���N�g�R�[�h
                    mf.PrmSetDtlNo2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO2RF"));    // ��ʃR�[�h
                    mf.JoinDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDISPORDERRF"));  //
                    mf.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINSOURCEMAKERCODERF"));
                    mf.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNOWITHHRF"));
                    mf.JoinSourPartsNoNoneH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNONONEHRF"));
                    mf.JoinDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDESTMAKERCDRF"));
                    mf.JoinDestPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDESTPARTSNORF"));
                    mf.JoinQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("JOINQTYRF"));
                    mf.SetPartsFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETPARTSFLGRF"));
                    mf.JoinSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSPECIALNOTERF"));

                    //�D�Ǐ��
                    mf.PrimePartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNAMERF"));
                    mf.PrimePartsKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSKANANMRF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PrimePartsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSSPECIALNOTERF"));
                    mf.PartsAttribute = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSATTRIBUTERF"));
                    mf.CatalogDeleteFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGDELETEFLAGRF"));

                    if (carMakerCd != 0) // �ԃ��[�J�[�R�[�h����@�i�����i����������j
                    {
                        mf.SearchPartsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSFULLNAMERF"));
                        mf.SearchPartsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSHALFNAMERF"));
                    }

                    retWork.Add(mf);
                }
                // �����܂Ő��폈��������0���̏ꍇ�ł����툵������B
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimePartsInfDB.SearchPrimePartsNoProc�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }

            return status;
        }

        // --- ADD m.suzuki 2012/01/31 ---------->>>>>
        /// <summary>
        /// ������֌�������
        /// </summary>
        /// <param name="carMakerCd"></param>
        /// <param name="joinSrcInfoDic"></param>
        /// <param name="inWorkList"></param>
        /// <param name="retWorkList"></param>
        /// <param name="newJoinSrcInfoDic"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int SearchJoinSubst( int carMakerCd, Dictionary<string, OfferJoinPartsRetWork> joinSrcInfoDic, ArrayList inWorkList, out ArrayList retWorkList, out Dictionary<string, OfferJoinPartsRetWork> newJoinSrcInfoDic, SqlConnection sqlConnection, SqlTransaction sqlTransaction )
        {
            //----------------------------------------
            // �D�Ǖ��i�̌������ʂ̌��������߂���ƁA
            // �N�G���̍ő啶�������I�[�o�[����댯���L��ׁA
            // ���X�g�𕪊����ď������܂��B
            // 
            // ���C���ƂȂ鏈�����e�́uSearchJoinSubstProc�v�ł��B
            //----------------------------------------

            int status;
            int retStatus = 0;

            Dictionary<string, OfferJoinPartsRetWork> newJoinSrcInfoDicSub;
            ArrayList retWorkListSub;

            newJoinSrcInfoDic = new Dictionary<string, OfferJoinPartsRetWork>();
            retWorkList = new ArrayList();

            const int maxCount = 100; // �������錏��
            
            for ( int startIndex = 0; startIndex < inWorkList.Count; startIndex += maxCount )
            {
                // �������X�g�̕����iList->ListSub�j
                ArrayList inWorkListSub = new ArrayList();
                inWorkListSub.AddRange( inWorkList.GetRange( startIndex, Math.Min( maxCount, inWorkList.Count - startIndex ) ) );

                // �������s
                status = SearchJoinSubstProc( carMakerCd, joinSrcInfoDic, inWorkListSub, out retWorkListSub, out newJoinSrcInfoDicSub, sqlConnection, sqlTransaction );
                if ( status != 0 && status != (int)ConstantManagement.DB_Status.ctDB_EOF )
                {
                    retStatus = status;
                }

                // ���ʃ��X�g�̓����iList<-ListSub�j
                retWorkList.AddRange( retWorkListSub );

                // ���ʃf�B�N�V���i���̓����iDic<-DicSub�j
                foreach ( string key in newJoinSrcInfoDicSub.Keys )
                {
                    if ( !newJoinSrcInfoDic.ContainsKey( key ) )
                    {
                        newJoinSrcInfoDic.Add( key, newJoinSrcInfoDicSub[key] );
                    }
                }
            }

            // �Y�����P���������ꍇ
            if ( retWorkList.Count == 0 )
            {
                retStatus = (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            return retStatus;
        }
        // --- ADD m.suzuki 2012/01/31 ----------<<<<<
        // --- UPD m.suzuki 2012/01/31 ---------->>>>>
        ///// <summary>
        ///// ������֌�������
        ///// </summary>
        ///// <param name="carMakerCd">�����i�������p�ԃ��[�J�[�R�[�h[0�̏ꍇ�͌����i�������Ȃ�]</param>
        ///// <param name="inWork">�������X�g</param>
        ///// <param name="joinSrcInfo">���������</param>
        ///// <param name="retWork">���ʃ��X�g</param>
        ///// <param name="sqlConnection"></param>
        ///// <param name="sqlTransaction"></param>
        ///// <returns></returns>
        //// 2010/01/25 >>>
        ////private int SearchJoinSubst(int carMakerCd, OfrPartsCondWork inWork, out OfferJoinPartsRetWork retWork,
        ////    SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        //private int SearchJoinSubst(int carMakerCd, OfferJoinPartsRetWork joinSrcInfo, OfrPartsCondWork inWork, out OfferJoinPartsRetWork retWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        //// 2010/01/25 <<<
        /// <summary>
        /// ������֌�������
        /// </summary>
        /// <param name="carMakerCd">�����i�������p�ԃ��[�J�[�R�[�h[0�̏ꍇ�͌����i�������Ȃ�]</param>
        /// <param name="joinSrcInfoDic">���������</param>
        /// <param name="inWorkList">�������X�g</param>
        /// <param name="retWorkList">���ʃ��X�g</param>
        /// <param name="newJoinSrcInfoDic">���������(�����㕪)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns></returns>
        private int SearchJoinSubstProc( int carMakerCd, Dictionary<string, OfferJoinPartsRetWork> joinSrcInfoDic, ArrayList inWorkList, out ArrayList retWorkList, out Dictionary<string, OfferJoinPartsRetWork> newJoinSrcInfoDic, SqlConnection sqlConnection, SqlTransaction sqlTransaction )
        // --- UPD m.suzuki 2012/01/31 ----------<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string selectstr = string.Empty;
            string wherestr = string.Empty;

            SqlDataReader myReader = null;
            // --- DEL m.suzuki 2012/01/31 ---------->>>>>
            //retWork = null;
            // --- DEL m.suzuki 2012/01/31 ----------<<<<<

            // --- ADD m.suzuki 2012/01/31 ---------->>>>>
            retWorkList = new ArrayList();
            newJoinSrcInfoDic = new Dictionary<string, OfferJoinPartsRetWork>();
            // --- ADD m.suzuki 2012/01/31 ----------<<<<<

            // ������ւ�����
            selectstr = "SELECT ";
            // 2010/01/25 �����}�X�^�͎Q�Ƃ��Ȃ� >>>
            //selectstr += "JOINPARTSRF.JOINSOURCEMAKERCODERF";
            //selectstr += ",JOINPARTSRF.JOINSOURPARTSNOWITHHRF";
            //selectstr += ",JOINPARTSRF.JOINDESTPARTSNORF";
            //selectstr += ",JOINPARTSRF.JOINDESTMAKERCDRF";
            //selectstr += ",JOINPARTSRF.JOINQTYRF ";
            //selectstr += ",PRIMEPARTSRF.OFFERDATERF";
            selectstr += "PRIMEPARTSRF.OFFERDATERF";
            // 2010/01/25 <<<
            selectstr += ",PRIMEPARTSRF.GOODSMGROUPRF";
            selectstr += ",PRIMEPARTSRF.TBSPARTSCODERF";
            selectstr += ",PRIMEPARTSRF.TBSPARTSCDDERIVEDNORF";
            selectstr += ",PRIMEPARTSRF.PRMSETDTLNO1RF";
            selectstr += ",PRIMEPARTSRF.PRIMEPARTSNAMERF";
            selectstr += ",PRIMEPARTSRF.PRIMEPARTSKANANMRF";
            selectstr += ",PRIMEPARTSRF.PARTSLAYERCDRF";
            selectstr += ",PRIMEPARTSRF.PRIMEPARTSSPECIALNOTERF";
            selectstr += ",PRIMEPARTSRF.PARTSATTRIBUTERF";
            selectstr += ",PRIMEPARTSRF.CATALOGDELETEFLAGRF";
            // 2010/01/25 Add >>>
            selectstr += ",JOINSUBSTRF.PARTSMAKERCODERF";
            // 2010/01/25 Add <<<
            selectstr += ",JOINSUBSTRF.JOINNEWPARTSNORF";
            selectstr += ",JOINSUBSTRF.JOINSUBSTSPECIALNOTERF ";
            // --- ADD m.suzuki 2012/01/31 ---------->>>>>
            selectstr += ",JOINSUBSTRF.JOINOLDPARTSNORF ";
            // --- ADD m.suzuki 2012/01/31 ----------<<<<<

            // 2010/01/25 �����i���́A�������ŗǂ��̂ō폜 >>>
            //if (carMakerCd != 0) // �ԃ��[�J�[�R�[�h����@�i�����i����������j
            //{
            //    selectstr += ",SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF ";
            //    selectstr += ",SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF ";
            //}
            // 2010/01/25 Del <<<

            // 2010/01/25 >>>
            //selectstr += "FROM ";
            //selectstr += " JOINPARTSRF JOIN JOINSUBSTRF ON JOINPARTSRF.JOINDESTMAKERCDRF = JOINSUBSTRF.PARTSMAKERCODERF AND ";
            //selectstr += " JOINPARTSRF.JOINDESTPARTSNORF = JOINSUBSTRF.JOINOLDPARTSNORF ";
            //selectstr += " INNER JOIN PRIMEPARTSRF ON PRIMEPARTSRF.PARTSMAKERCDRF = JOINSUBSTRF.PARTSMAKERCODERF ";
            //selectstr += " AND PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = JOINSUBSTRF.JOINNEWPARTSNORF ";

            selectstr += "FROM";
            selectstr += "  JOINSUBSTRF ";
            selectstr += "INNER JOIN PRIMEPARTSRF ON ";
            selectstr += "  PRIMEPARTSRF.PARTSMAKERCDRF = JOINSUBSTRF.PARTSMAKERCODERF";
            selectstr += "  AND PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = JOINSUBSTRF.JOINNEWPARTSNORF";
            // 2010/01/25 <<<

            // 2010/01/25 �����i���́A�������ŗǂ��̂ō폜 >>>
            //if (carMakerCd != 0) // �ԃ��[�J�[�R�[�h����@�i�����i����������j
            //{
            //    selectstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (JOINPARTSRF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
            //    selectstr += string.Format("AND SEARCHPRTNMRF.CARMAKERCODERF = {0}) ", carMakerCd);
            //}
            // 2010/01/25 Del <<<

            selectstr += " WHERE ";

            //���[�J�[�R�[�h
            // --- UPD m.suzuki 2012/01/31 ---------->>>>>
            //// 2010/01/25 >>>
            ////wherestr += " JOINPARTSRF.JOINDESTMAKERCDRF = " + inWork.MakerCode;
            ////wherestr += " AND JOINPARTSRF.JOINDESTPARTSNORF = '" + inWork.PrtsNo + "'";
            ////wherestr += " AND JOINPARTSRF.JOINSOURPARTSNOWITHHRF = '" + inWork.PrtsNoOrg + "'";
            //wherestr += "  JOINSUBSTRF.PARTSMAKERCODERF = " + inWork.MakerCode;
            //wherestr += "  AND JOINSUBSTRF.JOINOLDPARTSNORF = '" + inWork.PrtsNo + "'";
            //// 2010/01/25 <<<
            foreach ( OfrPartsCondWork wk in inWorkList )
            {
                wherestr += "OR ( JOINSUBSTRF.PARTSMAKERCODERF = " + wk.MakerCode + " AND ";
                wherestr += "JOINSUBSTRF.JOINOLDPARTSNORF = '" + wk.PrtsNo + "' ) ";
            }
            wherestr = wherestr.Substring( 3 ); // �擪��OR����
            // --- UPD m.suzuki 2012/01/31 ----------<<<<<
            try
            {
                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection, sqlTransaction);

                myReader = sqlCommand.ExecuteReader();
                // --- UPD m.suzuki 2012/01/31 ---------->>>>>
                //if ( myReader.Read() )
                while ( myReader.Read() )
                // --- UPD m.suzuki 2012/01/31 ----------<<<<<
                {
                    OfferJoinPartsRetWork mf = new OfferJoinPartsRetWork();

                    //�������
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    mf.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));    // �Z���N�g�R�[�h
                    //mf.PrmSetDtlNo2 = 0;//  SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO2RF"));    // ��ʃR�[�h
                    //mf.JoinDispOrder = 0;// SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDISPORDERRF"));  //
                    // 2010/01/25 >>>
                    //mf.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINSOURCEMAKERCODERF"));
                    //mf.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDESTPARTSNORF"));
                    //mf.JoinSourPartsNoNoneH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNOWITHHRF"));
                    //mf.JoinDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDESTMAKERCDRF"));

                    // --- UPD m.suzuki 2012/01/31 ---------->>>>>
                    //mf.JoinSourceMakerCode = inWork.MakerCode;
                    //mf.JoinSourPartsNoWithH = inWork.PrtsNo;
                    mf.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PARTSMAKERCODERF" ) );
                    mf.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "JOINOLDPARTSNORF" ) );
                    // --- UPD m.suzuki 2012/01/31 ----------<<<<<
                    // --- ADD m.suzuki 2012/01/31 ---------->>>>>
                    // ���������̎擾
                    OfferJoinPartsRetWork joinSrcInfo;

                    string key = GetJoinSrcInfoKey( mf.JoinSourceMakerCode, mf.JoinSourPartsNoWithH );
                    if ( joinSrcInfoDic.ContainsKey( key ) )
                    {
                        joinSrcInfo = joinSrcInfoDic[key];
                    }
                    else
                    {
                        joinSrcInfo = new OfferJoinPartsRetWork();
                    }
                    // --- ADD m.suzuki 2012/01/31 ----------<<<<<

                    mf.JoinSourPartsNoNoneH = joinSrcInfo.JoinSourPartsNoNoneH; // �������i�ԁi�n�C�t�������j�ɁA�匳�̌������i�Ԃ����Ȃ��Ɛ���ɓ����Ȃ�...
                    mf.JoinDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCODERF"));
                    // 2010/01/25 <<<
                    mf.JoinDestPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINNEWPARTSNORF"));
                    // --- UPD m.suzuki 2012/01/31 ---------->>>>>
                    //// 2010/01/25 >>>
                    ////mf.JoinQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("JOINQTYRF")); // ��������QTY���g���Ă������H
                    //mf.JoinQty = joinSrcInfo.JoinQty;
                    //// 2010/01/25 <<<
                    mf.JoinQty = joinSrcInfo.JoinQty;
                    // --- UPD m.suzuki 2012/01/31 ----------<<<<<
                    mf.SetPartsFlg = 0;// ���ɂ����Ȃ� //  SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETPARTSFLGRF"));
                    mf.JoinSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSUBSTSPECIALNOTERF"));

                    //�D�Ǐ��
                    mf.PrimePartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNAMERF"));
                    mf.PrimePartsKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSKANANMRF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PrimePartsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSSPECIALNOTERF"));
                    mf.PartsAttribute = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSATTRIBUTERF"));
                    mf.CatalogDeleteFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGDELETEFLAGRF"));

                    if ( carMakerCd != 0 ) // �ԃ��[�J�[�R�[�h����@�i�����i����������j
                    {
                        // 2010/01/25 >>>
                        //mf.SearchPartsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSFULLNAMERF"));
                        //mf.SearchPartsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSHALFNAMERF"));
                        mf.SearchPartsFullName = joinSrcInfo.SearchPartsFullName;
                        mf.SearchPartsHalfName = joinSrcInfo.SearchPartsHalfName;
                        // 2010/01/25 <<<
                    }

                    mf.SubstKubun = 1;
                    // --- UPD m.suzuki 2012/01/31 ---------->>>>>
                    //retWork = mf;
                    retWorkList.Add( mf );
                    // --- UPD m.suzuki 2012/01/31 ----------<<<<<

                    // --- ADD m.suzuki 2012/01/31 ---------->>>>>
                    // ���̐�������̌��������f�B�N�V���i��
                    string newKey = GetJoinSrcInfoKey( mf.JoinDestMakerCd, mf.JoinDestPartsNo);
                    if ( !newJoinSrcInfoDic.ContainsKey( newKey ) )
                    {
                        newJoinSrcInfoDic.Add( newKey, joinSrcInfo );
                    }

                    // �����X�e�[�^�X�Z�b�g(����I��)
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    // --- ADD m.suzuki 2012/01/31 ----------<<<<<
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimePartsInfDB.SearchJoinSubst�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }
            return status;
        }
        // --- ADD m.suzuki 2012/01/31 ---------->>>>>
        /// <summary>
        /// ���������̃f�B�N�V���i���p�L�[��������
        /// </summary>
        /// <param name="partsMakerCode"></param>
        /// <param name="joinOldPartsNoWithH"></param>
        /// <returns></returns>
        private string GetJoinSrcInfoKey( int partsMakerCode, string joinOldPartsNoWithH )
        {
            return partsMakerCode.ToString( "0000" ) + "'" + joinOldPartsNoWithH;
        }
        // --- ADD m.suzuki 2012/01/31 ----------<<<<<
        # endregion

        # region �Z�b�g�}�X�^����
        /// <summary>
        /// �Z�b�g�}�X�^����
        /// </summary>
        /// <param name="carMakerCd">�����i�������p�ԃ��[�J�[�R�[�h[0�̏ꍇ�͌����i�������Ȃ�]</param>
        /// <param name="inWork">�������X�g</param>
        /// <param name="retWork">���ʃ��X�g</param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int SearchSetParts(int carMakerCd, ArrayList inWork, out ArrayList retWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            retWork = new ArrayList();
            if (inWork == null)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            if (inWork.Count == 0)
            {
                return 0;
            }

            return SearchSetPartsProc(carMakerCd, inWork, ref retWork, sqlConnection, sqlTransaction);
        }

        private int SearchSetPartsProc(int carMakerCd, ArrayList inWork, ref ArrayList retWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string selectstr = string.Empty;
            string wherestr = string.Empty;
            SqlDataReader myReader = null;

            try
            {
                //�擾�}�X�^����
                selectstr = OFFERSETPARTSRFSelectFields;
                if (carMakerCd != 0) // �ԃ��[�J�[�R�[�h����@�i�����i����������j
                {
                    selectstr += ",SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF ";
                    selectstr += ",SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF ";
                }
                //�i�n�h�m����
                selectstr += " FROM PRIMEPARTSRF INNER JOIN SETPARTSRF ON PRIMEPARTSRF.PARTSMAKERCDRF = SETPARTSRF.SETSUBMAKERCDRF";
                selectstr += " AND PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = SETPARTSRF.SETSUBPARTSNORF ";
                if (carMakerCd != 0) // �ԃ��[�J�[�R�[�h����@�i�����i����������j
                {
                    selectstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (PRIMEPARTSRF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
                    selectstr += string.Format("AND SEARCHPRTNMRF.CARMAKERCODERF = {0}) ", carMakerCd);
                }
                //�v�g�d�q�d����
                selectstr += "WHERE ";

                //�����惁�[�J�[�R�[�h�E������i�� 
                foreach (OfrPartsCondWork wk in inWork)
                {
                    wherestr += "OR ( SETPARTSRF.SETMAINMAKERCDRF = " + wk.MakerCode + " AND ";
                    wherestr += "SETPARTSRF.SETMAINPARTSNORF = '" + wk.PrtsNo + "' ) ";
                }
                wherestr = wherestr.Substring(3); // �擪��OR����

                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection, sqlTransaction);

                myReader = sqlCommand.ExecuteReader();
                while ( myReader.Read() )
                {
                    OfferSetPartsRetWork mf = new OfferSetPartsRetWork();

                    //�Z�b�g�}�X�^
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    mf.SetMainMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETMAINMAKERCDRF"));
                    mf.SetMainPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETMAINPARTSNORF"));
                    mf.SetSubMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETSUBMAKERCDRF"));
                    mf.SetSubPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETSUBPARTSNORF"));
                    mf.SetDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETDISPORDERRF"));
                    mf.SetQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SETQTYRF"));
                    mf.SetName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETNAMERF"));
                    mf.SetSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETSPECIALNOTERF"));
                    mf.CatalogShapeNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATALOGSHAPENORF"));

                    //�D�Ǖ��i�}�X�^
                    mf.PrimePartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNAMERF"));
                    mf.PrimePartsKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSKANANMRF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PrimePartsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSSPECIALNOTERF"));
                    mf.PartsAttribute = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSATTRIBUTERF"));
                    mf.CatalogDeleteFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGDELETEFLAGRF"));
                    // 2009/11/24 Add >>>
                    mf.PrmPrtTbsPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMPRTTBSPRTCDRF"));
                    mf.PrmPrtTbsPrtCdDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMPRTTBSPRTCDDERIVNORF"));
                    // 2009/11/24 Add <<<

                    if (carMakerCd != 0) // �ԃ��[�J�[�R�[�h����@�i�����i����������j
                    {
                        mf.SearchPartsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSFULLNAMERF"));
                        mf.SearchPartsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSHALFNAMERF"));
                    }

                    retWork.Add(mf);
                }
                //if (retWork.Count > 0)
                //{
                // �擾������0���ł��ُ�I�����Ă͂����Ȃ��̂Ő��탊�^�[������B
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //}
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimePartsInfDB.SearchParts�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }
            return status;
        }

        // --- ADD m.suzuki 2012/01/31 ---------->>>>>
        /// <summary>
        /// �Z�b�g��֌���
        /// </summary>
        /// <param name="carMakerCd"></param>
        /// <param name="setPartsDic"></param>
        /// <param name="inWorkList"></param>
        /// <param name="retWorkList"></param>
        /// <param name="newSetPartsDic"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int SearchSetSubst( int carMakerCd, Dictionary<string, OfferSetPartsRetWork> setPartsDic, ArrayList inWorkList, out ArrayList retWorkList, out Dictionary<string, OfferSetPartsRetWork> newSetPartsDic, SqlConnection sqlConnection, SqlTransaction sqlTransaction )
        {
            //----------------------------------------
            // �Z�b�g�̌������ʂ̌��������߂���ƁA
            // �N�G���̍ő啶�������I�[�o�[����댯���L��ׁA
            // ���X�g�𕪊����ď������܂��B
            // 
            // ���C���ƂȂ鏈�����e�́uSearchSetSubstProc�v�ł��B
            //----------------------------------------

            int status;
            int retStatus = 0;

            Dictionary<string, OfferSetPartsRetWork> newSetPartsDicSub;
            ArrayList retWorkListSub;

            newSetPartsDic = new Dictionary<string, OfferSetPartsRetWork>();
            retWorkList = new ArrayList();

            const int maxCount = 100; // �������錏��

            for ( int startIndex = 0; startIndex < inWorkList.Count; startIndex += maxCount )
            {
                // �������X�g�̕����iList->ListSub�j
                ArrayList inWorkListSub = new ArrayList();
                inWorkListSub.AddRange( inWorkList.GetRange( startIndex, Math.Min( maxCount, inWorkList.Count - startIndex ) ) );

                // �Z�b�g��֌������s
                status = SearchSetSubstProc( carMakerCd, setPartsDic, inWorkListSub, out retWorkListSub, out newSetPartsDicSub, sqlConnection, sqlTransaction );
                if ( status != 0 && status != (int)ConstantManagement.DB_Status.ctDB_EOF )
                {
                    retStatus = status;
                }

                // ���ʃ��X�g�̓����iList<-ListSub�j
                retWorkList.AddRange( retWorkListSub );

                // ���ʃf�B�N�V���i���̓����iDic<-DicSub�j
                foreach ( string key in newSetPartsDicSub.Keys )
                {
                    if ( !newSetPartsDic.ContainsKey( key ) )
                    {
                        newSetPartsDic.Add( key, newSetPartsDicSub[key] );
                    }
                }
            }

            // �Y�����P���������ꍇ
            if ( retWorkList.Count == 0 )
            {
                retStatus = (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            
            return retStatus;
        }
        // --- ADD m.suzuki 2012/01/31 ----------<<<<<

        // --- UPD m.suzuki 2012/01/31 ---------->>>>>
        ///// <summary>
        ///// �Z�b�g��֌���
        ///// </summary>
        ///// <param name="carMakerCd"></param>
        ///// <param name="inWork"></param>
        ///// <param name="retWork"></param>
        ///// <param name="sqlConnection"></param>
        ///// <param name="sqlTransaction"></param>
        ///// <returns></returns>
        //private int SearchSetSubst(int carMakerCd, OfferSetPartsRetWork inWork, out OfferSetPartsRetWork retWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        /// <summary>
        /// �Z�b�g��֌���
        /// </summary>
        /// <param name="carMakerCd"></param>
        /// <param name="inWorkList"></param>
        /// <param name="retWorkList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int SearchSetSubstProc( int carMakerCd, Dictionary<string, OfferSetPartsRetWork> setPartsDic, ArrayList inWorkList, out ArrayList retWorkList, out Dictionary<string, OfferSetPartsRetWork> newSetPartsDic, SqlConnection sqlConnection, SqlTransaction sqlTransaction )
        // --- UPD m.suzuki 2012/01/31 ----------<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string selectstr = string.Empty;
            string wherestr = string.Empty;

            SqlDataReader myReader = null;
            // --- UPD m.suzuki 2012/01/31 ---------->>>>>
            //retWork = null;
            retWorkList = new ArrayList();
            // --- UPD m.suzuki 2012/01/31 ----------<<<<<
            // --- ADD m.suzuki 2012/01/31 ---------->>>>>
            newSetPartsDic = new Dictionary<string, OfferSetPartsRetWork>();
            // --- ADD m.suzuki 2012/01/31 ----------<<<<<

            #region �N�G���쐬
            // ������ւ�����
            selectstr = "SELECT ";
            // --- DEL m.suzuki 2012/01/31 ---------->>>>>
            //selectstr += "SETPARTSRF.SETMAINMAKERCDRF";
            //selectstr += ",SETPARTSRF.SETSUBPARTSNORF";
            //selectstr += ",SETPARTSRF.SETSUBMAKERCDRF";
            //selectstr += ",SETPARTSRF.SETDISPORDERRF";
            //selectstr += ",SETPARTSRF.SETSPECIALNOTERF";
            //selectstr += ",SETPARTSRF.SETNAMERF";
            //selectstr += ",SETPARTSRF.CATALOGSHAPENORF";
            // --- DEL m.suzuki 2012/01/31 ----------<<<<<
            // --- ADD m.suzuki 2012/01/31 ---------->>>>>
            selectstr += "SETSUBSTRF.SETMAINPARTSNORF ";
            selectstr += ",SETSUBSTRF.PARTSMAKERCODERF ";
            selectstr += ",SETSUBSTRF.SETOLDPARTSNORF ";
            // --- ADD m.suzuki 2012/01/31 ----------<<<<<
            selectstr += ",PRIMEPARTSRF.OFFERDATERF";
            selectstr += ",PRIMEPARTSRF.GOODSMGROUPRF";
            selectstr += ",PRIMEPARTSRF.TBSPARTSCODERF";
            selectstr += ",PRIMEPARTSRF.TBSPARTSCDDERIVEDNORF";
            selectstr += ",PRIMEPARTSRF.PRMSETDTLNO1RF";
            selectstr += ",PRIMEPARTSRF.PRIMEPARTSNAMERF";
            selectstr += ",PRIMEPARTSRF.PRIMEPARTSKANANMRF";
            selectstr += ",PRIMEPARTSRF.PARTSLAYERCDRF";
            selectstr += ",PRIMEPARTSRF.PRIMEPARTSSPECIALNOTERF";
            selectstr += ",PRIMEPARTSRF.PARTSATTRIBUTERF";
            selectstr += ",PRIMEPARTSRF.CATALOGDELETEFLAGRF";
            selectstr += ",SETSUBSTRF.SETNEWPARTSNORF";
            selectstr += ",SETSUBSTRF.SETSUBSTSPECIALNOTERF ";
            if (carMakerCd != 0) // �ԃ��[�J�[�R�[�h����@�i�����i����������j
            {
                selectstr += ",SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF ";
                selectstr += ",SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF ";
            }
            selectstr += "FROM ";
            // --- UPD m.suzuki 2012/01/31 ---------->>>>>
            //selectstr += " SETPARTSRF JOIN SETSUBSTRF ON SETPARTSRF.SETSUBMAKERCDRF = SETSUBSTRF.PARTSMAKERCODERF AND ";
            //selectstr += " SETPARTSRF.SETMAINPARTSNORF = SETSUBSTRF.SETMAINPARTSNORF AND ";
            //selectstr += " SETPARTSRF.SETSUBPARTSNORF = SETSUBSTRF.SETOLDPARTSNORF ";
            selectstr += " SETSUBSTRF ";
            // --- UPD m.suzuki 2012/01/31 ----------<<<<<
            selectstr += " INNER JOIN PRIMEPARTSRF ON PRIMEPARTSRF.PARTSMAKERCDRF = SETSUBSTRF.PARTSMAKERCODERF ";
            selectstr += " AND PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = SETSUBSTRF.SETNEWPARTSNORF ";
            if (carMakerCd != 0) // �ԃ��[�J�[�R�[�h����@�i�����i����������j
            {
                selectstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (PRIMEPARTSRF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
                selectstr += string.Format("AND SEARCHPRTNMRF.CARMAKERCODERF = {0}) ", carMakerCd);
            }
            selectstr += " WHERE ";

            // --- UPD m.suzuki 2012/01/31 ---------->>>>>�u
            ////foreach (OfrPartsCondWork wk in inWork)
            ////{
            ////���[�J�[�R�[�h
            ////wherestr += " OR ( ";
            //wherestr += " SETSUBSTRF.PARTSMAKERCODERF = " + inWork.SetSubMakerCd;
            //wherestr += " AND SETSUBSTRF.SETMAINPARTSNORF = '" + inWork.SetMainPartsNo + "'";
            //wherestr += " AND SETSUBSTRF.SETOLDPARTSNORF = '" + inWork.SetSubPartsNo + "'";
            ////wherestr += " ) ";
            ////}
            ////wherestr = wherestr.Substring(3); // �擪��OR����
            foreach ( OfferSetPartsRetWork wk in inWorkList )
            {
                wherestr += "OR ( SETSUBSTRF.PARTSMAKERCODERF = " + wk.SetSubMakerCd + " AND ";
                wherestr += "SETSUBSTRF.SETMAINPARTSNORF = '" + wk.SetMainPartsNo + "' AND ";
                wherestr += "SETSUBSTRF.SETOLDPARTSNORF = '" + wk.SetSubPartsNo + "' ) ";
            }
            wherestr = wherestr.Substring( 3 ); // �擪��OR����
            // --- UPD m.suzuki 2012/01/31 ----------<<<<<
            #endregion
            try
            {
                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection, sqlTransaction);

                myReader = sqlCommand.ExecuteReader();
                // --- UPD m.suzuki 2012/01/31 ---------->>>>>
                //if ( myReader.Read() )
                while ( myReader.Read() )
                // --- UPD m.suzuki 2012/01/31 ----------<<<<<
                {
                    OfferSetPartsRetWork mf = new OfferSetPartsRetWork();

                    //�Z�b�g�}�X�^
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    // --- DEL m.suzuki 2012/01/31 ---------->>>>>
                    //mf.SetMainMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETMAINMAKERCDRF"));
                    // --- DEL m.suzuki 2012/01/31 ----------<<<<<
                    // --- UPD m.suzuki 2012/01/31 ---------->>>>>
                    //mf.SetMainPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETSUBPARTSNORF"));
                    mf.SetMainPartsNo = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SETMAINPARTSNORF" ) );
                    // --- UPD m.suzuki 2012/01/31 ----------<<<<<
                    // --- UPD m.suzuki 2012/01/31 ---------->>>>>
                    //mf.SetSubMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETSUBMAKERCDRF"));
                    mf.SetSubMakerCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PARTSMAKERCODERF" ) );
                    // --- UPD m.suzuki 2012/01/31 ----------<<<<<
                    mf.SetSubPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETNEWPARTSNORF"));
                    // --- DEL m.suzuki 2012/01/31 ---------->>>>>
                    //mf.SetDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETDISPORDERRF"));
                    // --- DEL m.suzuki 2012/01/31 ----------<<<<<
                    mf.SetQty = 0;// SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETQTYRF"));
                    // --- DEL m.suzuki 2012/01/31 ---------->>>>>
                    //mf.SetName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETNAMERF"));
                    // --- DEL m.suzuki 2012/01/31 ----------<<<<<
                    // --- DEL m.suzuki 2012/01/31 ---------->>>>>
                    //mf.SetSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETSPECIALNOTERF"));
                    //mf.CatalogShapeNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATALOGSHAPENORF"));
                    // --- DEL m.suzuki 2012/01/31 ----------<<<<<

                    // --- ADD m.suzuki 2012/01/31 ---------->>>>>
                    // ���ɂȂ��Ă���Z�b�g�}�X�^���擾����
                    string setOldPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETOLDPARTSNORF"));
                    OfferSetPartsRetWork setParts;
                    string key = GetSetPartsInfoKey( mf.SetSubMakerCd, mf.SetMainPartsNo, setOldPartsNo );
                    if ( setPartsDic.ContainsKey( key ) )
                    {
                        setParts = setPartsDic[key];
                    }
                    else
                    {
                        setParts = new OfferSetPartsRetWork();
                    }
                    // �Z�b�g�}�X�^����̎擾
                    mf.SetMainMakerCd = setParts.SetMainMakerCd;
                    mf.SetDispOrder = setParts.SetDispOrder;
                    mf.SetName = setParts.SetName;
                    mf.SetSpecialNote = setParts.SetSpecialNote;
                    mf.CatalogShapeNo = setParts.CatalogShapeNo;
                    // --- ADD m.suzuki 2012/01/31 ----------<<<<<

                    //�D�Ǖ��i�}�X�^
                    mf.PrimePartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNAMERF"));
                    mf.PrimePartsKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSKANANMRF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PrimePartsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSSPECIALNOTERF"));
                    mf.PartsAttribute = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSATTRIBUTERF"));
                    mf.CatalogDeleteFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGDELETEFLAGRF"));
                    if (carMakerCd != 0) // �ԃ��[�J�[�R�[�h����@�i�����i����������j
                    {
                        mf.SearchPartsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSFULLNAMERF"));
                        mf.SearchPartsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSHALFNAMERF"));
                    }
                    mf.SubstKubun = 1;

                    // --- UPD m.suzuki 2012/01/31 ---------->>>>>
                    //retWork = mf;
                    retWorkList.Add( mf );

                    // �f�B�N�V���i���̍Đ����i���̐���ցj
                    string newKey = GetSetPartsInfoKey( mf.SetSubMakerCd, mf.SetMainPartsNo, mf.SetSubPartsNo );
                    if ( !newSetPartsDic.ContainsKey( newKey ) )
                    {
                        newSetPartsDic.Add( newKey, setParts );
                    }

                    // �����X�e�[�^�X�Z�b�g(����I��)
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    // --- UPD m.suzuki 2012/01/31 ----------<<<<<
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimePartsInfDB.SearchSetSubst�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }
            return status;
        }
        // --- ADD m.suzuki 2012/01/31 ---------->>>>>
        /// <summary>
        /// �Z�b�g���̃f�B�N�V���i���p�L�[��������
        /// </summary>
        /// <param name="partsMakerCode"></param>
        /// <param name="setMainPartsNo"></param>
        /// <param name="setSubPartsNo"></param>
        /// <returns></returns>
        private string GetSetPartsInfoKey( int partsMakerCode, string setMainPartsNo, string setSubPartsNo )
        {
            return partsMakerCode.ToString( "0000" ) + "'" + setMainPartsNo + "'" + setSubPartsNo;
        }
        // --- ADD m.suzuki 2012/01/31 ----------<<<<<
        # endregion

        /// <summary>
        /// �i���擾(�S�p)
        /// </summary>
        /// <param name="makerCd">���[�J�R�[�h</param>
        /// <param name="partsNo">�n�C�t���t�i��</param>
        /// <param name="name">�i��</param>
        /// <returns></returns>
        public int GetPartsName(int makerCd, string partsNo, out string name)
        {
            return GetPartsNameProc(makerCd, partsNo, out name,0);
        }

        /// <summary>
        /// �i���擾(���p)
        /// </summary>
        /// <param name="makerCd">���[�J�R�[�h</param>
        /// <param name="partsNo">�n�C�t���t�i��</param>
        /// <param name="name">�i��</param>
        /// <returns></returns>
        public int GetPartsNameKana(int makerCd, string partsNo, out string name)
        {
            return GetPartsNameProc(makerCd, partsNo, out name,1);
        }

        private int GetPartsNameProc(int makerCd, string partsNo, out string name, int mode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string nameString = "";
            if (mode == 0)
            {
                nameString = "PRIMEPARTSNAMERF";
            }
            else
            {
                nameString = "PRIMEPARTSKANANMRF";
            }

            string query = "SELECT " + nameString +" PRIMEPARTSNAMERF FROM PRIMEPARTSRF "
                         + "WHERE PRIMEPARTSNOWITHHRF = @PARTSNO AND PARTSMAKERCDRF = @MAKERCODE ";
            name = string.Empty;

            SqlConnection sqlConnection = CreateSqlConnection();
            if (sqlConnection == null)
            {
                return 99;
            }
            sqlConnection.Open();

            SqlCommand sqlCommand = null;
            try
            {
                sqlCommand = new SqlCommand(query, sqlConnection);
                ((SqlParameter)sqlCommand.Parameters.Add("@PARTSNO", SqlDbType.NVarChar)).Value = partsNo;
                ((SqlParameter)sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int)).Value = makerCd;
                object ret = sqlCommand.ExecuteScalar();
                if (ret != null)
                {
                    name = ret.ToString();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();
                if (sqlConnection != null)
                    sqlConnection.Dispose();
            }

            return status;
        }
        # endregion

        # region �o�q�h�u�`�s�d��`

        #region ���i�擾
        /// <summary>
        /// ���i�擾
        /// </summary>
        /// <param name="priceDate"></param>
        /// <param name="inWork"></param>
        /// <param name="retWork"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int SearchPartsPrice( ArrayList inWork, out ArrayList retWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string selectstr = string.Empty;
            string wherestr = string.Empty;

            SqlDataReader myReader = null;
            retWork = new ArrayList();

            if (inWork == null || inWork.Count == 0)
            {
                return status;
            }

            try
            {
                //[�P���ɏ����i�ɕR�t���D�Ǖi�𒊏o]
                selectstr = "SELECT ";
                selectstr += "PRMPRTPRICERF.OFFERDATERF, ";
                selectstr += "PRMPRTPRICERF.PRMSETDTLNO1RF, "; // �Z���N�g�R�[�h
                selectstr += "PRMPRTPRICERF.PARTSMAKERCDRF, ";
                selectstr += "PRMPRTPRICERF.PRIMEPARTSNOWITHHRF, ";
                selectstr += "PRMPRTPRICERF.PRICESTARTDATERF, ";
                selectstr += "PRMPRTPRICERF.NEWPRICERF, ";
                selectstr += "PRMPRTPRICERF.OPENPRICEDIVRF ";

                selectstr += " FROM PRMPRTPRICERF ";

                selectstr += " WHERE ";

                foreach ( OfrPartsCondWork wk in inWork )
                {
                    //���[�J�[�R�[�h
                    wherestr += " OR ( ";
                    wherestr += " PRMPRTPRICERF.PARTSMAKERCDRF = " + wk.MakerCode;
                    wherestr += " AND PRMPRTPRICERF.PRIMEPARTSNOWITHHRF = '" + wk.PrtsNo + "'";
                    wherestr += " ) ";
                }
                wherestr = wherestr.Substring(3); // �擪��OR����
                wherestr += "ORDER BY PRICESTARTDATERF DESC";

                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection, sqlTransaction);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    OfferJoinPriceRetWork mf = new OfferJoinPriceRetWork();

                    //�������
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
                base.WriteErrorLog(ex, "PrimePartsInfDB.SearchPartsPrice�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }

            return status;

        }
        #endregion

        # region �D�Ǖi�Ԃj�d�x���D�Ǖi�Ԍ���
        /// <summary>
        /// �D�Ǖi�Ԃj�d�x���D�Ǖ��i����[���i�����ǉ��v��]
        /// </summary>
        /// <param name="inPara">��������</param>
        /// <param name="retWork">��������</param>
        /// <param name="sqlConnection">�R���l�N�V����</param>
        /// <returns></returns>
        private int SearchPrimePartsNo(GetPrimePartsInfPara inPara, out ArrayList retWork, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string selectstr = string.Empty;
            string wherestr = string.Empty;
            string queryCol = string.Empty;
            SqlDataReader myReader = null;

            string partsNo = inPara.PrtsNoNoneHyphen;
            int partsMakerCode = inPara.PartsMakerCode;

            retWork = new ArrayList();

            try
            {
                if (inPara.PrtsNoNoneHyphen.Contains("-"))
                {
                    queryCol = "PRIMEPARTSNOWITHHRF";
                }
                else
                {
                    queryCol = "PRIMEPARTSNONONEHRF";
                }

                //[�񋟏��i�i�ԞB������]
                selectstr = "SELECT TOP(100) ";
                selectstr += "PRIMEPARTSRF.OFFERDATERF, ";
                selectstr += "PRIMEPARTSRF.GOODSMGROUPRF, ";
                selectstr += "PRIMEPARTSRF.TBSPARTSCODERF, ";
                selectstr += "PRIMEPARTSRF.TBSPARTSCDDERIVEDNORF, ";
                selectstr += "PRIMEPARTSRF.PRMSETDTLNO1RF, ";
                selectstr += "PRIMEPARTSRF.PARTSMAKERCDRF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSNOWITHHRF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSNONONEHRF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSNAMERF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSKANANMRF, ";
                selectstr += "PRIMEPARTSRF.PARTSLAYERCDRF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSSPECIALNOTERF, ";
                selectstr += "PRIMEPARTSRF.PARTSATTRIBUTERF, ";
                selectstr += "PRIMEPARTSRF.CATALOGDELETEFLAGRF, ";
                selectstr += "PRIMEPARTSRF.PRMPARTSILLUSTCRF ";

                selectstr += " FROM PRIMEPARTSRF ";

                //////////////////////////////////////////////////////////////////////////////////////
                switch (inPara.SearchType)
                {
                    case 0: // ���S��v
                        wherestr = " WHERE PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = @PARTSNORF ";
                        break;
                    case 1: // �O����v
                        partsNo = partsNo + "%";
                        wherestr = " WHERE PRIMEPARTSRF." + queryCol + " LIKE @PARTSNORF ";
                        break;
                    case 2: // �����v
                        partsNo = "%" + partsNo;
                        wherestr = " WHERE PRIMEPARTSRF." + queryCol + " LIKE @PARTSNORF ";
                        break;
                    case 3: // �B������
                        partsNo = "%" + partsNo + "%";
                        wherestr = " WHERE PRIMEPARTSRF." + queryCol + " LIKE @PARTSNORF ";
                        break;
                    case 4: // �n�C�t���������S��v
                        wherestr = " WHERE PRIMEPARTSRF.PRIMEPARTSNONONEHRF = @PARTSNORF ";
                        break;
                }
                if (inPara.PartsMakerCode != 0)
                    wherestr += "AND PRIMEPARTSRF.PARTSMAKERCDRF = @PARTSMAKERCDRF";
                //////////////////////////////////////////////////////////////////////////////////////
                selectstr += wherestr;

                selectstr += " ORDER BY PRIMEPARTSRF.PARTSMAKERCDRF, PRIMEPARTSRF.PRIMEPARTSNOWITHHRF";

                // Prameter�I�u�W�F�N�g�̍쐬
                SqlCommand sqlCommand = new SqlCommand(selectstr, sqlConnection);
                SqlParameter ptno = sqlCommand.Parameters.Add("@PARTSNORF", SqlDbType.NVarChar);
                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                ptno.Value = SqlDataMediator.SqlSetString(partsNo);

                if (partsMakerCode != 0)
                {
                    SqlParameter mkcd = sqlCommand.Parameters.Add("@PARTSMAKERCDRF", SqlDbType.Int);
                    mkcd.Value = SqlDataMediator.SqlSetInt(partsMakerCode);
                }

                // Parameter�I�u�W�F�N�g�֒l�ݒ�

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    OfferJoinPartsRetWork mf = new OfferJoinPartsRetWork();
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                    mf.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PRMSETDTLNO1RF" ) );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
                    mf.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    mf.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNOWITHHRF"));
                    mf.JoinSourPartsNoNoneH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNONONEHRF"));
                    mf.JoinDestMakerCd = mf.JoinSourceMakerCode;
                    mf.JoinDestPartsNo = mf.JoinSourPartsNoWithH;
                    mf.PrimePartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNAMERF"));
                    mf.PrimePartsKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSKANANMRF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PrimePartsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSSPECIALNOTERF"));
                    mf.PartsAttribute = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSATTRIBUTERF"));
                    mf.CatalogDeleteFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGDELETEFLAGRF"));
                    mf.PrmPartsIllustC = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMPARTSILLUSTCRF"));
                    
                    retWork.Add(mf);
                }
                //if (retWork.Count > 0)
                //{
                // �擾������0���ł��ُ�I�����Ă͂����Ȃ��̂Ő��탊�^�[������B
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //}
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimePartsInfDB.SearchPrimePartsNo�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        # endregion

        # region �Z�b�g�}�X�^�擾���ڒ�`
        // �Z�b�g�}�X�^�擾���ڒ�`
        private string OFFERSETPARTSRFSelectFields = "SELECT "
            //�Z�b�g�}�X�^
            //+ "SETPARTSRF.OFFERDATERF, "
            + "SETPARTSRF.GOODSMGROUPRF"
            + ",SETPARTSRF.TBSPARTSCODERF"
            + ",SETPARTSRF.TBSPARTSCDDERIVEDNORF"
            + ",SETPARTSRF.SETMAINMAKERCDRF"
            + ",SETPARTSRF.SETMAINPARTSNORF"
            + ",SETPARTSRF.SETSUBMAKERCDRF"
            + ",SETPARTSRF.SETSUBPARTSNORF"
            + ",SETPARTSRF.SETDISPORDERRF"
            + ",SETPARTSRF.SETQTYRF"
            + ",SETPARTSRF.SETNAMERF"
            + ",SETPARTSRF.SETSPECIALNOTERF"
            + ",SETPARTSRF.CATALOGSHAPENORF"

            //�D�Ǖ��i�}�X�^
            + ",PRIMEPARTSRF.OFFERDATERF"
            // 2009/11/24 Add >>>
            + ",PRIMEPARTSRF.TBSPARTSCODERF AS PRMPRTTBSPRTCDRF"
            + ",PRIMEPARTSRF.TBSPARTSCDDERIVEDNORF AS PRMPRTTBSPRTCDDERIVNORF"
            // 2009/11/24 Add <<<
            + ",PRIMEPARTSRF.PRIMEPARTSNAMERF"
            + ",PRIMEPARTSRF.PRIMEPARTSKANANMRF"
            + ",PRIMEPARTSRF.PARTSLAYERCDRF"
            + ",PRIMEPARTSRF.PRIMEPARTSSPECIALNOTERF"
            + ",PRIMEPARTSRF.PARTSATTRIBUTERF"
            + ",PRIMEPARTSRF.CATALOGDELETEFLAGRF ";
        # endregion

        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
            if (string.IsNullOrEmpty(connectionText))
                return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }

        # endregion

#if Kill0618
        /// <summary>
        /// �D�ǁE�Z�b�g��֌���
        /// </summary>
        /// <param name="inPara">�����������X�g</param>
        /// <param name="retSubstParts">��֕��i���X�g</param>
        /// <param name="retSubstPrice">��֕��i���i���X�g</param>
        /// <returns></returns>
        public int GetJoinSubst(ArrayList inPara, out ArrayList retSubstParts, out ArrayList retSubstPrice)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            retSubstParts = new ArrayList();
            retSubstPrice = new ArrayList();

            SqlConnection sqlConnection = null;

            try
            {
                SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = SearchPrimePartsNo(condListForJoin, out inRetInf, sqlConnection, null);

                if (status != 0)
                {
                    return (status);
                }

                //�Z�b�g�}�X�^�̓ǂݍ���
                ArrayList listForSetSearch = new ArrayList();
                foreach (OfferJoinPartsRetWork wk in inRetInf)
                {
                    OfrPartsCondWork ofrPartsCondWork = new OfrPartsCondWork();
                    ofrPartsCondWork.MakerCode = wk.JoinDestMakerCd;
                    ofrPartsCondWork.PrtsNo = wk.JoinDestPartsNo;
                    listForSetSearch.Add(ofrPartsCondWork);
                }
                status = SearchSetParts(listForSetSearch, out inRetSetParts, sqlConnection, null);

                // �Z�b�g��ւ�S�ĒT���B
                ArrayList inputList = (ArrayList)inRetSetParts.Clone();
                ArrayList setSubstList;
                do
                {
                    setSubstList = new ArrayList();
                    SearchSetSubst(inputList, out setSubstList, sqlConnection, null);
                    if (setSubstList.Count > 0)
                    {
                        inRetSetParts.AddRange(setSubstList);

                        inputList = new ArrayList();
                        foreach (OfferSetPartsRetWork work in setSubstList)
                        {
                            OfferSetPartsRetWork condWork = new OfferSetPartsRetWork();
                            condWork.SetMainPartsNo = work.SetMainPartsNo;
                            condWork.SetSubMakerCd = work.SetSubMakerCd;
                            condWork.SetSubPartsNo = work.SetSubPartsNo;
                            inputList.Add(condWork);
                            //retSetParts.Add(condWork); // �Z�b�g��֕i�̉��i�����̂��� !!!!!!!!
                        }
                    }
                } while (setSubstList.Count > 0);

                // �Z�b�g�E�Z�b�g��ւ̉��i�����擾����B
                ArrayList listForSetPrice = new ArrayList();
                foreach (OfferSetPartsRetWork wk in inRetSetParts)
                {
                    OfrPartsCondWork ofrPartsCondWork = new OfrPartsCondWork();
                    ofrPartsCondWork.MakerCode = wk.SetSubMakerCd;
                    ofrPartsCondWork.PrtsNo = wk.SetSubPartsNo;
                    listForSetPrice.Add(ofrPartsCondWork);
                }
                SearchPartsPrice(listForSetPrice, out SetPrice, sqlConnection, null);

                // ������ւ�S�ĒT���B���i�ԁ��V�i�ԁ�(�V�i��->���i��)���V�i�ԁ�
                inputList = (ArrayList)condListForJoin.Clone();
                ArrayList primeSubstList;
                do
                {
                    primeSubstList = new ArrayList();
                    SearchJoinSubst(inputList, out primeSubstList, sqlConnection, null);
                    if (primeSubstList.Count > 0)
                    {
                        inRetInf.AddRange(primeSubstList);

                        inputList = new ArrayList();
                        foreach (OfferJoinPartsRetWork work in primeSubstList)
                        {
                            OfrPartsCondWork condWork = new OfrPartsCondWork();
                            condWork.MakerCode = work.JoinDestMakerCd;
                            condWork.PrtsNo = work.JoinDestPartsNo;
                            inputList.Add(condWork);
                            condListForJoin.Add(condWork); // ������֕i�̉��i�����̂��� !!!!!!!!
                        }
                    }
                } while (primeSubstList.Count > 0);

                // �����E������ւ̉��i�����擾����B
                SearchPartsPrice(condListForJoin, out inPrimePrice, sqlConnection, null);

            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "PrimePartsInfDB.GetPartsInfByCtlgPtNo�ɂ�SQL�G���[���� Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimePartsInfDB.GetPartsInfByCtlgPtNo�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
#endif

        // ADD 2014/05/09 ���x���P�t�F�[�Y�Q��11,��12 �g��  -------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        // DEL 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi ----->>>>>
        ///// <summary> �����񓚕i�ڐݒ胊�X�g�i�����񓚐�p�j </summary>
        //private List<AutoAnsItemStForOffer> autoAnsItemStList = null;
        ///// <summary> �D��ݒ胊�X�g�i�����񓚐�p�j</summary>
        //private List<PrmSettingUForOffer> prmSettingUList = null;
        ///// <summary> PM.NS ���Ӑ�R�[�h�i�����񓚐�p�j</summary>
        //private int customerCode = 0;
        ///// <summary> PM.NS ���_�R�[�h(Trim��)�i�����񓚐�p�j </summary>
        //private string sectionCode = string.Empty;
        // DEL 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi -----<<<<<

        /// <summary>
        /// �����񓚐�p �e��v���p�e�B �L���b�V������
        /// </summary>
        /// <param name="sectionCodeWk">���_�R�[�h</param>
        /// <param name="customerCodeWk">���Ӑ�R�[�h</param>
        /// <param name="obAutoAnsItemStList">�����񓚕i�ڐݒ胊�X�g</param>
        /// <param name="obPrmSettingList">�D��ݒ胊�X�g</param>
        // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi ----->>>>>
        //public void CacheAutoAnswer(string sectionCodeWk, int customerCodeWk, List<object> obAutoAnsItemStList, List<object> obPrmSettingList)
        private void CacheAutoAnswer(string sectionCodeWk, int customerCodeWk, List<object> obAutoAnsItemStList, List<object> obPrmSettingList,
                                    ref List<AutoAnsItemStForOffer> autoAnsItemStList, ref List<PrmSettingUForOffer> prmSettingUList, out int customerCode, out string sectionCode)
        // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi -----<<<<<
        {
            // �����񓚕i�ڐݒ胊�X�g �ݒ�
            // DEL 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi ----->>>>>
            //autoAnsItemStList = new List<AutoAnsItemStForOffer>();
            // DEL 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi -----<<<<<
            foreach (List<object> tgt in obAutoAnsItemStList)
            {
                AutoAnsItemStForOffer wk = new AutoAnsItemStForOffer();
                wk.SectionCode = tgt[0].ToString().Trim();	// ���_�R�[�h
                wk.CustomerCode = (int)tgt[1];      // ���Ӑ�R�[�h
                wk.GoodsMGroup = (int)tgt[2];		// ���i�����ރR�[�h
                wk.BLGoodsCode = (int)tgt[3];       // BL���i�R�[�h
                wk.GoodsMakerCd = (int)tgt[4];      // ���i���[�J�[�R�[�h
                wk.PrmSetDtlNo2 = (int)tgt[5];      // �D�ǐݒ�ڍ׃R�[�h�Q
                wk.AutoAnswerDiv = (int)tgt[6];     // �����񓚋敪
                wk.PriorityOrder = (int)tgt[7];     // �D�揇��
        
                autoAnsItemStList.Add(wk);
            }
        
            // �D�ǐݒ胊�X�g �ݒ�
            // DEL 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi ----->>>>>
            //prmSettingUList = new List<PrmSettingUForOffer>();
            // DEL 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi ----->>>>>
            foreach (List<object> tgt in obPrmSettingList)
            {
                PrmSettingUForOffer wk = new PrmSettingUForOffer();
                wk.GoodsMGroup = (int)tgt[0];   // ���i�����ރR�[�h
                wk.TbsPartsCode = (int)tgt[1];  // BL�R�[�h
                wk.PartsMakerCd = (int)tgt[2];  // ���i���[�J�[�R�[�h
                wk.PrmSetDtlNo1 = (int)tgt[3];  // �D�ǐݒ�ڍ׃R�[�h�P
                wk.PrmSetDtlNo2 = (int)tgt[4];  // �D�ǐݒ�ڍ׃R�[�h�Q
                wk.PrimeDisplayCode = (int)tgt[5];  // �D�Ǖ\���敪�v���p�e�B
        
                prmSettingUList.Add(wk);
            }

            // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi ----->>>>>
            //this.customerCode = customerCodeWk;
            //this.sectionCode = sectionCodeWk.Trim();
            customerCode = customerCodeWk;
            sectionCode = sectionCodeWk.Trim();
            // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi -----<<<<<
        }

        // DEL 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi ----->>>>>
        ///// <summary>
        ///// �����񓚐�p �e��v���p�e�B �L���b�V���N���A
        ///// </summary>
        //public void CacheClearAutoAnswer()
        //{
        //    // �����񓚕i�ڐݒ胊�X�g �ݒ�
        //    autoAnsItemStList = null;
        //
        //    // �D�ǐݒ胊�X�g �ݒ�
        //    prmSettingUList = null;
        //    customerCode = 0;
        //    sectionCode = string.Empty;
        //}
        // DEL 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi -----<<<<<

        /// <summary>
        /// �����񓚐�p�@�D�Ǖi�Ԍ��� DB�����[�g�I�u�W�F�N�g[�����i�ԁ@���@��������]
        /// </summary>
        /// <param name="substFlg">��փt���O[true:����/false:���Ȃ�]</param>
        /// <param name="carMakerCd">�����i�������p�ԃ��[�J�[�R�[�h[0�̏ꍇ�͌����i�������Ȃ�]</param>
        /// <param name="inPara">�����p�����[�^</param>		
        /// <param name="inRetInf">���i���</param>
        /// <param name="inPrimePrice">�D�ǉ��i���X�g</param>
        /// <param name="inRetSetParts">�Z�b�g���i���</param>
        /// <param name="SetPrice">�Z�b�g���i</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <returns>0:����I�� 4:NOT FOUND ���̑�:�G���[</returns>
        // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi ----->>>>>
        //private int GetPartsInfByCtlgPtNoProcAutoAnswer(bool substFlg, int carMakerCd, ArrayList inPara, out ArrayList inRetInf,
        //        out ArrayList inPrimePrice, out ArrayList inRetSetParts, out ArrayList SetPrice, SqlConnection sqlConnection)
        private int GetPartsInfByCtlgPtNoProcAutoAnswer(List<AutoAnsItemStForOffer> autoAnsItemStList, List<PrmSettingUForOffer> prmSettingUList, int customerCode, string sectionCode, 
                bool substFlg, int carMakerCd, ArrayList inPara, out ArrayList inRetInf,
                out ArrayList inPrimePrice, out ArrayList inRetSetParts, out ArrayList SetPrice, SqlConnection sqlConnection)
        // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi -----<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            ArrayList condListForJoin = (ArrayList)inPara.Clone();

            inRetInf = new ArrayList();
            inPrimePrice = new ArrayList();
            inRetSetParts = new ArrayList();
            SetPrice = new ArrayList();

            // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi ----->>>>>
            //�����i�Ԃ��j�d�x�ɂ��ėD�ǌ����i�Ԃ�����
            //status = SearchPrimePartsNoAutoAnswer(carMakerCd, condListForJoin, out inRetInf, sqlConnection, null);
            status = SearchPrimePartsNoAutoAnswer(autoAnsItemStList, prmSettingUList, customerCode, sectionCode, carMakerCd, condListForJoin, out inRetInf, sqlConnection, null);
            // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi -----<<<<<

            if (status != 0)
            {
                return (status);
            }

            ArrayList listForSetSearch = new ArrayList();
            ArrayList listForJoinSubst = new ArrayList(); // ������ւ̌����������X�g (��������)
            Dictionary<string, OfferJoinPartsRetWork> joinSrcInfoDic = new Dictionary<string, OfferJoinPartsRetWork>(); // ������ւ̌����Ɏg�p���錋�������f�B�N�V���i��
            Dictionary<string, OfferJoinPartsRetWork> newJoinSrcInfoDic;
            if (substFlg) // ������֌���
            {
                ArrayList primeSubstList = new ArrayList();
                // ������ւ�S�ĒT���B���i�ԁ��V�i�ԁ�(�V�i��->���i��)���V�i�ԁ�  10����܂�
                foreach (OfferJoinPartsRetWork wk in inRetInf)
                {
                    OfrPartsCondWork condWork = new OfrPartsCondWork();
                    condWork.MakerCode = wk.JoinDestMakerCd;
                    condWork.PrtsNo = wk.JoinDestPartsNo;
                    condWork.PrtsNoOrg = wk.JoinSourPartsNoWithH;
                    condListForJoin.Add(condWork); // �����i�̉��i�����̂��� 
                    listForSetSearch.Add(condWork); // �����ŃZ�b�g�}�X�^�����p���X�g��\�ߍ���Ēu���B

                    # region // DEL
                    # endregion
                    // ������ւ̌����p���X�g�Ɋi�[
                    listForJoinSubst.Add(condWork);

                    // ���������f�B�N�V���i���Ɋi�[
                    string key = GetJoinSrcInfoKey(condWork.MakerCode, condWork.PrtsNo);
                    if (!joinSrcInfoDic.ContainsKey(key))
                    {
                        joinSrcInfoDic.Add(key, wk);
                    }
                }
                if (listForJoinSubst.Count > 0)
                {
                    // ������֌���(10����)
                    for (int i = 1; i < 11; i++)
                    {
                        // ������֌����i���オ�i�ނ� joinSrcInfoDic �� listForJoinSubst �������ւ��j
                        SearchJoinSubst(carMakerCd, joinSrcInfoDic, listForJoinSubst, out primeSubstList, out newJoinSrcInfoDic, sqlConnection, null);

                        // �������ʂ����X�g�Ɋi�[
                        if (primeSubstList != null && primeSubstList.Count > 0)
                        {
                            // (���̐����)������ւ̌����������X�g���쐬������
                            listForJoinSubst = new ArrayList();

                            foreach (OfferJoinPartsRetWork primeSubstWork in primeSubstList)
                            {
                                OfrPartsCondWork condWork = new OfrPartsCondWork();
                                condWork.MakerCode = primeSubstWork.JoinDestMakerCd;
                                condWork.PrtsNo = primeSubstWork.JoinDestPartsNo;
                                condWork.PrtsNoOrg = primeSubstWork.JoinSourPartsNoWithH;

                                condListForJoin.Add(condWork); // ������֕i�̉��i�����ׁ̈A�Z�b�g
                                listForJoinSubst.Add(condWork); // ������ւ̎����㌟���ׁ̈A�Z�b�g
                            }

                            // (���̐����)���������f�B�N�V���i���̍����ւ�
                            joinSrcInfoDic = newJoinSrcInfoDic;
                        }
                        else
                        {
                            // �Y�����Ȃ�������10���㕪�̃��[�v���I��
                            break;
                        }
                    }
                }
                inRetInf.AddRange(primeSubstList);
            }
            else // ��֌������Ȃ��ꍇ�A���i�E�Z�b�g�����̂��߈ȉ��̃��X�g�쐬���s���B
            {
                foreach (OfferJoinPartsRetWork wk in inRetInf)
                {
                    OfrPartsCondWork condWork = new OfrPartsCondWork();
                    condWork.MakerCode = wk.JoinDestMakerCd;
                    condWork.PrtsNo = wk.JoinDestPartsNo;
                    condWork.PrtsNoOrg = wk.JoinSourPartsNoWithH;
                    condListForJoin.Add(condWork); // �����i�̉��i�����̂��� 
                    listForSetSearch.Add(condWork); // �����ŃZ�b�g�}�X�^�����p���X�g��\�ߍ���Ēu���B
                }
            }

            // �����E������ւ̉��i�����擾����B
            SearchPartsPrice(condListForJoin, out inPrimePrice, sqlConnection, null);

            //�Z�b�g�}�X�^�̓ǂݍ���
            status = SearchSetParts(carMakerCd, listForSetSearch, out inRetSetParts, sqlConnection, null);

            if (substFlg) // �Z�b�g��֌���
            {
                ArrayList list = (ArrayList)inRetSetParts.Clone();

                if (list.Count > 0)
                {
                    // �Z�b�g���f�B�N�V���i������
                    Dictionary<string, OfferSetPartsRetWork> setPartsDic = new Dictionary<string, OfferSetPartsRetWork>();
                    foreach (OfferSetPartsRetWork setPartsRetWork in inRetSetParts)
                    {
                        string key = GetSetPartsInfoKey(setPartsRetWork.SetSubMakerCd, setPartsRetWork.SetMainPartsNo, setPartsRetWork.SetSubPartsNo);
                        if (!setPartsDic.ContainsKey(key))
                        {
                            setPartsDic.Add(key, setPartsRetWork);
                        }
                    }

                    ArrayList setSubstList;
                    Dictionary<string, OfferSetPartsRetWork> newSetPartsDic;

                    // �Z�b�g��֌���(10����)
                    for (int i = 0; i < 11; i++)
                    {
                        // �Z�b�g��֌���
                        SearchSetSubst(carMakerCd, setPartsDic, list, out setSubstList, out newSetPartsDic, sqlConnection, null);

                        if (setSubstList != null && setSubstList.Count > 0)
                        {
                            // (���̐����)�Z�b�g��ւ̌����������X�g���쐬������
                            list = new ArrayList();
                            foreach (OfferSetPartsRetWork setSubst in setSubstList)
                            {
                                inRetSetParts.Add(setSubst); // �Z�b�g�̌������ʃ��X�g�ɒǉ�

                                OfferSetPartsRetWork condWork = new OfferSetPartsRetWork();
                                condWork.SetMainPartsNo = setSubst.SetMainPartsNo;
                                condWork.SetSubMakerCd = setSubst.SetSubMakerCd;
                                condWork.SetSubPartsNo = setSubst.SetSubPartsNo;
                                list.Add(condWork);
                            }

                            // (���̐����)�Z�b�g���f�B�N�V���i���̍����ւ�
                            setPartsDic = newSetPartsDic;
                        }
                        else
                        {
                            // �Y�����Ȃ�������10���㕪�̃��[�v���I��
                            break;
                        }
                    }
                }
            }

            // �Z�b�g�E�Z�b�g��ւ̉��i�����擾����B
            ArrayList listForSetPrice = new ArrayList();
            foreach (OfferSetPartsRetWork wk in inRetSetParts)
            {
                OfrPartsCondWork ofrPartsCondWork = new OfrPartsCondWork();
                ofrPartsCondWork.MakerCode = wk.SetSubMakerCd;
                ofrPartsCondWork.PrtsNo = wk.SetSubPartsNo;
                listForSetPrice.Add(ofrPartsCondWork);
            }
            SearchPartsPrice(listForSetPrice, out SetPrice, sqlConnection, null);

            return status;
        }

        /// <summary>
        /// �����񓚐�p�@�����i�Ԃj�d�x���D�Ǖ��i����
        /// </summary>
        /// <param name="carMakerCd">�����i�������p�ԃ��[�J�[�R�[�h</param>
        /// <param name="inWork">�������X�g</param>
        /// <param name="retWork">���ʃ��X�g</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <param name="sqlTransaction">SQL�g�����U�N�V����</param>
        /// <returns>0:����I�� 4:NOT FOUND ���̑�:�G���[</returns>
        // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi ----->>>>>
        //public int SearchPrimePartsNoAutoAnswer(int carMakerCd, ArrayList inWork, out ArrayList retWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        private int SearchPrimePartsNoAutoAnswer(List<AutoAnsItemStForOffer> autoAnsItemStList, List<PrmSettingUForOffer> prmSettingUList, int customerCode, string sectionCode, int carMakerCd, ArrayList inWork, out ArrayList retWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi -----<<<<<
        {
            retWork = new ArrayList();

            if (inWork == null)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            if (inWork.Count == 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi ----->>>>>
            //return SearchPrimePartsNoProcAutoAnswer(carMakerCd, inWork, ref retWork, sqlConnection, sqlTransaction);
            return SearchPrimePartsNoProcAutoAnswer(autoAnsItemStList, prmSettingUList, customerCode, sectionCode, carMakerCd, inWork, ref retWork, sqlConnection, sqlTransaction);
            // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi -----<<<<<
        }

        /// <summary>
        /// �����񓚐�p�@�����i�Ԃj�d�x���D�Ǖ��i����
        /// </summary>
        /// <param name="carMakerCd">�����i�������p�ԃ��[�J�[�R�[�h</param>
        /// <param name="inWork">�������X�g</param>
        /// <param name="retWork">���ʃ��X�g</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <param name="sqlTransaction">SQL�g�����U�N�V����</param>
        /// <returns>0:����I�� 4:NOT FOUND ���̑�:�G���[</returns>
        // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi ----->>>>>
        //private int SearchPrimePartsNoProcAutoAnswer(int carMakerCd, ArrayList inWork, ref ArrayList retWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        private int SearchPrimePartsNoProcAutoAnswer(List<AutoAnsItemStForOffer> autoAnsItemStList, List<PrmSettingUForOffer> prmSettingUList, int customerCode, string sectionCode, int carMakerCd, ArrayList inWork, ref ArrayList retWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi -----<<<<<
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string selectstr = string.Empty;
            string wherestr = string.Empty;

            SqlDataReader myReader = null;

            try
            {
                //[�P���ɏ����i�ɕR�t���D�Ǖi�𒊏o]
                selectstr = "SELECT ";
                //selectstr += "JOINPARTSRF.OFFERDATERF, ";
                selectstr += "JOINPARTSRF.GOODSMGROUPRF ";
                selectstr += ",JOINPARTSRF.TBSPARTSCODERF ";
                selectstr += ",JOINPARTSRF.TBSPARTSCDDERIVEDNORF ";
                selectstr += ",JOINPARTSRF.PRMSETDTLNO1RF "; // �Z���N�g�R�[�h
                selectstr += ",JOINPARTSRF.PRMSETDTLNO2RF "; // ��ʃR�[�h
                selectstr += ",JOINPARTSRF.JOINDISPORDERRF ";
                selectstr += ",JOINPARTSRF.JOINSOURCEMAKERCODERF ";
                selectstr += ",JOINPARTSRF.JOINSOURPARTSNOWITHHRF ";
                selectstr += ",JOINPARTSRF.JOINSOURPARTSNONONEHRF ";
                selectstr += ",JOINPARTSRF.JOINDESTMAKERCDRF ";
                selectstr += ",JOINPARTSRF.JOINDESTPARTSNORF ";
                selectstr += ",JOINPARTSRF.JOINQTYRF ";
                selectstr += ",JOINPARTSRF.SETPARTSFLGRF ";
                selectstr += ",JOINPARTSRF.JOINSPECIALNOTERF ";

                selectstr += ",PRIMEPARTSRF.OFFERDATERF ";
                selectstr += ",PRIMEPARTSRF.PRIMEPARTSNAMERF ";
                selectstr += ",PRIMEPARTSRF.PRIMEPARTSKANANMRF ";
                selectstr += ",PRIMEPARTSRF.PARTSLAYERCDRF ";
                selectstr += ",PRIMEPARTSRF.PRIMEPARTSSPECIALNOTERF ";
                selectstr += ",PRIMEPARTSRF.PARTSATTRIBUTERF ";
                selectstr += ",PRIMEPARTSRF.CATALOGDELETEFLAGRF ";

                if (carMakerCd != 0) // �ԃ��[�J�[�R�[�h����@�i�����i����������j
                {
                    selectstr += ",SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF ";
                    selectstr += ",SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF ";
                }

                selectstr += " FROM PRIMEPARTSRF INNER JOIN JOINPARTSRF ON PRIMEPARTSRF.PARTSMAKERCDRF = JOINPARTSRF.JOINDESTMAKERCDRF";
                selectstr += " AND PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = JOINPARTSRF.JOINDESTPARTSNORF ";

                if (carMakerCd != 0) // �ԃ��[�J�[�R�[�h����@�i�����i����������j
                {
                    selectstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (JOINPARTSRF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
                    selectstr += string.Format("AND SEARCHPRTNMRF.CARMAKERCODERF = {0}) ", carMakerCd);
                }

                selectstr += " WHERE ";

                foreach (OfrPartsCondWork wk in inWork)
                {
                    //���[�J�[�R�[�h
                    wherestr += " OR ( ";
                    wherestr += " JOINPARTSRF.JOINSOURCEMAKERCODERF = " + wk.MakerCode;
                    wherestr += " AND JOINPARTSRF.JOINSOURPARTSNOWITHHRF = '" + wk.PrtsNo + "'";
                    wherestr += " ) ";
                }
                wherestr = wherestr.Substring(3); // �擪��OR����

                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection, sqlTransaction);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    OfferJoinPartsRetWork mf = new OfferJoinPartsRetWork();

                    //�������
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    mf.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));    // �Z���N�g�R�[�h
                    mf.PrmSetDtlNo2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO2RF"));    // ��ʃR�[�h
                    mf.JoinDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDISPORDERRF"));  //
                    mf.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINSOURCEMAKERCODERF"));
                    mf.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNOWITHHRF"));
                    mf.JoinSourPartsNoNoneH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNONONEHRF"));
                    mf.JoinDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDESTMAKERCDRF"));
                    mf.JoinDestPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDESTPARTSNORF"));
                    mf.JoinQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("JOINQTYRF"));
                    mf.SetPartsFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETPARTSFLGRF"));
                    mf.JoinSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSPECIALNOTERF"));

                    //�D�Ǐ��
                    mf.PrimePartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNAMERF"));
                    mf.PrimePartsKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSKANANMRF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PrimePartsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSSPECIALNOTERF"));
                    mf.PartsAttribute = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSATTRIBUTERF"));
                    mf.CatalogDeleteFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGDELETEFLAGRF"));

                    if (carMakerCd != 0) // �ԃ��[�J�[�R�[�h����@�i�����i����������j
                    {
                        mf.SearchPartsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSFULLNAMERF"));
                        mf.SearchPartsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSHALFNAMERF"));
                    }

                    // �����񓚕i�ڐݒ� �ɂ��񓚑Ώۂ��̔��f
                    if (autoAnsItemStList != null && autoAnsItemStList.Count > 0)
                    {
                        // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi ----->>>>>
                        //if (!IsAutoAnswer(mf))
                        if (!IsAutoAnswer(autoAnsItemStList, mf, customerCode, sectionCode))
                        // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi -----<<<<<
                            continue;
                    }

                    // �D��ݒ� �ɂ��񓚑Ώۂ��̔��f
                    if (prmSettingUList != null && prmSettingUList.Count > 0)
                    {
                        // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi ----->>>>>
                        //if (!IsPrmSetting(mf))
                        if (!IsPrmSetting(prmSettingUList,mf))
                        // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi -----<<<<<
                            continue;
                    }

                    retWork.Add(mf);
                }

                // �����܂Ő��폈��������0���̏ꍇ�ł����툵������B
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimePartsInfDB.SearchPrimePartsNoProcAutoAnswer�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// �����񓚐�p�@�D�ǐݒ�̔��f
        /// </summary>
        /// <param name="mf">�������ʕ��i���</param>
        /// <returns>true�F�D�ǐݒ�L��@false�F�D�ǐݒ薳��</returns>
        // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi ----->>>>>
        //private bool IsPrmSetting(OfferJoinPartsRetWork mf)
        private bool IsPrmSetting(List<PrmSettingUForOffer> prmSettingUList, OfferJoinPartsRetWork mf)
        // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi -----<<<<<
        {
            bool isPrmSetting = false;

            // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi ----->>>>>
            //PrmSettingUForOffer prmSetting = SearchPrmSettingUWork(mf.GoodsMGroup, mf.TbsPartsCode, mf.JoinDestMakerCd, mf.PrmSetDtlNo1, mf.PrmSetDtlNo2);
            PrmSettingUForOffer prmSetting = SearchPrmSettingUWork(prmSettingUList,mf.GoodsMGroup, mf.TbsPartsCode, mf.JoinDestMakerCd, mf.PrmSetDtlNo1, mf.PrmSetDtlNo2);
            // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi -----<<<<<

            if (prmSetting != null)
            {
                if (mf.JoinSourPartsNoWithH == mf.JoinDestPartsNo && mf.JoinSourceMakerCode == mf.JoinDestMakerCd)
                {
                    // �Z�b�g�i�́A�D�Ǖ\���敪���u�\�����Ȃ��v�ȊO�͕\������
                    if (!prmSetting.PrimeDisplayCode.Equals(0))
                    {
                        isPrmSetting = true;
                    }
                }
                else
                {
                    // �D�Ǖ\���敪��[�D�Ǖ\���敪]�ȊO�͕\�����Ȃ�
                    if (prmSetting.PrimeDisplayCode.Equals(1))
                    {
                        isPrmSetting = true;
                    }
                }
            }

            return isPrmSetting;
        }

        /// <summary>
        /// �����񓚐�p�@�D�ǐݒ胊�X�g����A�Ώۂ̗D�ǐݒ���擾���܂��B
        /// </summary>
        /// <param name="goodsMGroup">���i�����ރR�[�h</param>
        /// <param name="tbsPartsCode">BL�R�[�h</param>
        /// <param name="partsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="prmSetDtlNo1">�D�ǐݒ�ڍ׃R�[�h�P�i�Z���N�g�R�[�h�j</param>
        /// <param name="prmSetDtlNo2">�D�ǐݒ�ڍ׃R�[�h�Q�i��ʃR�[�h�j</param>
        /// <returns>�ΏۗD�ǐݒ�</returns>
        // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi ----->>>>>
        //private PrmSettingUForOffer SearchPrmSettingUWork(int goodsMGroup, int tbsPartsCode, int partsMakerCd, int prmSetDtlNo1, int prmSetDtlNo2)
        private PrmSettingUForOffer SearchPrmSettingUWork(List<PrmSettingUForOffer> prmSettingUList, int goodsMGroup, int tbsPartsCode, int partsMakerCd, int prmSetDtlNo1, int prmSetDtlNo2)
        // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi -----<<<<<
        {
            return prmSettingUList.Find(
                        delegate(PrmSettingUForOffer prmSettingUWork)
                        {
                            if (prmSettingUWork.PrmSetDtlNo2.Equals(prmSetDtlNo2) &&
                                prmSettingUWork.PrmSetDtlNo1.Equals(prmSetDtlNo1) &&
                                prmSettingUWork.PartsMakerCd.Equals(partsMakerCd) &&
                                prmSettingUWork.TbsPartsCode.Equals(tbsPartsCode) &&
                                prmSettingUWork.GoodsMGroup.Equals(goodsMGroup) )
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        });
        }

        /// <summary>
        /// �����񓚐�p�@�����񓚕i�ڐݒ�̔��f
        /// </summary>
        /// <param name="mf">�������ʕ��i���</param>
        /// <returns>true�F�����񓚑Ώہ@false�F�����񓚑ΏۊO</returns>
        // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi ----->>>>>
        //private bool IsAutoAnswer(OfferJoinPartsRetWork mf)
        private bool IsAutoAnswer(List<AutoAnsItemStForOffer> autoAnsItemStList, OfferJoinPartsRetWork mf, int customerCode, string sectionCode)
        // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi -----<<<<<
        {
            bool autoAnswer = false;

            AutoAnsItemStForOffer selectAutoAnsItemSt = new AutoAnsItemStForOffer();

            // �����񓚕i�ڐݒ�}�X�^������
            // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi ----->>>>>
            //selectAutoAnsItemSt = autoAnsItemStFind(autoAnsItemStList, mf, this.sectionCode, this.customerCode);
            selectAutoAnsItemSt = autoAnsItemStFind(autoAnsItemStList, mf, sectionCode, customerCode);
            // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi -----<<<<<

            // �����񓚕i�ڐݒ�}�X�^�ɓo�^������ꍇ
            if (selectAutoAnsItemSt != null)
            {
                // �����񓚕i�ڐݒ�}�X�^.�����񓚋敪�̔���
                if (!selectAutoAnsItemSt.AutoAnswerDiv.Equals(0)) // 0:���Ȃ�(�S�Ď蓮��)
                {
                    autoAnswer = true;
                }
            }

            return autoAnswer;
        }

        /// <summary>
        /// �����񓚐�p�@�����񓚕i�ڐݒ茟��
        /// </summary>
        /// <param name="mf">�������ʕ��i���</param>
        /// <param name="sectionCodeWk">���_�R�[�h</param>
        /// <param name="customerCodeWk">���Ӑ�R�[�h</param>
        /// <returns>�Ώێ����񓚕i�ڐݒ�</returns>
        // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi ----->>>>>
        //private AutoAnsItemStForOffer autoAnsItemStFind(OfferJoinPartsRetWork mf, string sectionCodeWk, int customerCodeWk)
        private AutoAnsItemStForOffer autoAnsItemStFind(List<AutoAnsItemStForOffer> autoAnsItemStList, OfferJoinPartsRetWork mf, string sectionCodeWk, int customerCodeWk)
        // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi -----<<<<<
        {
            // ��������
            AutoAnsItemStForOffer retAutoAnsItemSt;

            // �ꊇ�������ʂ��D�揇�ʂɍ��킹�Č������ʂ𒊏o
            if (customerCodeWk > 0)
            {
                #region  �D�揇��1:���Ӑ�{�����ށ{BL�R�[�h�{���[�J�[
                retAutoAnsItemSt = autoAnsItemStList.Find(
                    delegate(AutoAnsItemStForOffer AutoAnsItemSt)
                    {
                        return IsPriority1(AutoAnsItemSt, mf, customerCodeWk);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "�D�揇��1:���Ӑ�(={0})�{������(={1})�{BL�R�[�h(={2})�{���[�J�[(={3}) �Ō�������܂����B",
                        customerCodeWk,
                        mf.GoodsMGroup,
                        mf.TbsPartsCode,
                        mf.JoinDestMakerCd
                    );

                    #endregion

                    return retAutoAnsItemSt;
                }
                #endregion

                #region  �D�揇��2:���Ӑ�{�����ށi���ʁj�{BL�R�[�h�{���[�J�[

                retAutoAnsItemSt = autoAnsItemStList.Find(
                    delegate(AutoAnsItemStForOffer AutoAnsItemSt)
                    {
                        return IsPriority2(AutoAnsItemSt, mf, customerCodeWk);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "�D�揇��1:���Ӑ�(={0})�{������(={1})�{BL�R�[�h(={2})�{���[�J�[(={3}) �Ō�������܂����B",
                        customerCodeWk,
                        mf.GoodsMGroup,
                        mf.TbsPartsCode,
                        mf.JoinDestMakerCd
                    );

                    #endregion
                    return retAutoAnsItemSt;
                }

                #endregion
                #region �D�揇��3:���Ӑ�{�����ށ{���[�J�[

                retAutoAnsItemSt = autoAnsItemStList.Find(
                    delegate(AutoAnsItemStForOffer AutoAnsItemSt)
                    {
                        return IsPriority3(AutoAnsItemSt, mf, customerCodeWk);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "�D�揇��3:���Ӑ�(={0})�{������(={1}) �Ō�������܂����B",
                        customerCodeWk,
                        mf.GoodsMGroup
                    );

                    #endregion // </Log>

                    return retAutoAnsItemSt;
                }

                #endregion

                #region �D�揇��4:���Ӑ�{���[�J�[

                retAutoAnsItemSt = autoAnsItemStList.Find(
                    delegate(AutoAnsItemStForOffer AutoAnsItemSt)
                    {
                        return IsPriority4(AutoAnsItemSt, mf, customerCodeWk);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "�D�揇��4:���Ӑ�(={0}) �Ō�������܂����B",
                        customerCodeWk
                    );

                    #endregion

                    return retAutoAnsItemSt;
                }

                #endregion
            }
            if (!string.IsNullOrEmpty(sectionCodeWk))
            {
                #region �D�揇��5:���_�{�����ށ{BL�R�[�h�{���[�J�[

                retAutoAnsItemSt = autoAnsItemStList.Find(
                    delegate(AutoAnsItemStForOffer AutoAnsItemSt)
                    {
                        return IsPriority5(AutoAnsItemSt, mf, sectionCodeWk);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "�D�揇��5:���_(={0})�{������(={1})�{BL�R�[�h(={2})�{���[�J�[(={3}) �Ō�������܂����B",
                        sectionCodeWk,
                        mf.GoodsMGroup,
                        mf.TbsPartsCode,
                        mf.JoinDestMakerCd
                    );

                    #endregion

                    return retAutoAnsItemSt;
                }

                #endregion

                #region �D�揇��6:���_�{�����ށi���ʁj�{BL�R�[�h�{���[�J�[

                retAutoAnsItemSt = autoAnsItemStList.Find(
                    delegate(AutoAnsItemStForOffer AutoAnsItemSt)
                    {
                        return IsPriority6(AutoAnsItemSt, mf, sectionCodeWk);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "�D�揇��5:���_(={0})�{������(={1})�{BL�R�[�h(={2})�{���[�J�[(={3}) �Ō�������܂����B",
                        sectionCodeWk,
                        mf.GoodsMGroup,
                        mf.TbsPartsCode,
                        mf.JoinDestMakerCd
                    );

                    #endregion

                    return retAutoAnsItemSt;
                }

                #endregion

                #region �D�揇��7:���_�{�����ށ{���[�J�[

                retAutoAnsItemSt = autoAnsItemStList.Find(
                    delegate(AutoAnsItemStForOffer AutoAnsItemSt)
                    {
                        return IsPriority7(AutoAnsItemSt, mf, sectionCodeWk);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "�D�揇��7:���_(={0})�{������(={1}) �Ō�������܂����B",
                        sectionCodeWk,
                        mf.GoodsMGroup
                    );

                    #endregion // </Log>

                    return retAutoAnsItemSt;
                }

                #endregion

                #region �D�揇��8:���_�{���[�J�[

                retAutoAnsItemSt = autoAnsItemStList.Find(
                    delegate(AutoAnsItemStForOffer AutoAnsItemSt)
                    {
                        return IsPriority8(AutoAnsItemSt, mf, sectionCodeWk);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "�D�揇��8:���_(={0}) �Ō�������܂����B",
                        sectionCodeWk
                    );

                    #endregion

                    return retAutoAnsItemSt;
                }

                #endregion
            }
            else
            {
                retAutoAnsItemSt = null;
                return retAutoAnsItemSt;
            }

            if (!sectionCodeWk.Equals("00"))
            {
                // ���_�F�S�ЂŌ���
                // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi ----->>>>>
                //return autoAnsItemStFind(mf, "00", 0);
                return autoAnsItemStFind(autoAnsItemStList,mf, "00", 0);
                // UPD 2014/08/07 ���x���P�t�F�[�Y�Q T.Nishi -----<<<<<
            }

            return retAutoAnsItemSt;
        }

        #region �D�揇�ʂ̔��f

        /// <summary>
        /// �����񓚐�p�@�D�揇��1:���Ӑ�{�����ށ{BL�R�[�h�{���[�J�[�ł��邩���f���܂��B
        /// </summary>
        /// <param name="autoAnsItemSt">�����񓚕i�ڐݒ�</param>
        /// <param name="mf">�������ʕ��i���</param>
        /// <param name="customerCodeWk">���Ӑ�R�[�h</param>
        /// <returns>
        /// <c>true</c> :�D�揇��1�ł��B<br/>
        /// <c>false</c>:�D�揇��1�ł͂���܂���B
        /// </returns>
        private static bool IsPriority1(AutoAnsItemStForOffer autoAnsItemSt, OfferJoinPartsRetWork mf, int customerCodeWk)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == mf.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.CustomerCode == customerCodeWk
                        &&
                    autoAnsItemSt.GoodsMGroup == mf.GoodsMGroup
                        &&
                    autoAnsItemSt.BLGoodsCode == mf.TbsPartsCode
                        &&
                    autoAnsItemSt.GoodsMakerCd == mf.JoinDestMakerCd
                );
            }
            return false;
        }
        /// <summary>
        /// �����񓚐�p�@�D�揇��2:���Ӑ�{�����ށi���ʁj�{BL�R�[�h�{���[�J�[�ł��邩���f���܂��B
        /// </summary>
        /// <param name="autoAnsItemSt">�����񓚕i�ڐݒ�</param>
        /// <param name="mf">�������ʕ��i���</param>
        /// <param name="customerCodeWk">���Ӑ�R�[�h</param>
        /// <returns>
        /// <c>true</c> :�D�揇��2�ł��B<br/>
        /// <c>false</c>:�D�揇��2�ł͂���܂���B
        /// </returns>
        private static bool IsPriority2(AutoAnsItemStForOffer autoAnsItemSt, OfferJoinPartsRetWork mf, int customerCodeWk)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == mf.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.CustomerCode == customerCodeWk
                        &&
                    autoAnsItemSt.GoodsMGroup == 0
                        &&
                    autoAnsItemSt.BLGoodsCode == mf.TbsPartsCode
                        &&
                    autoAnsItemSt.GoodsMakerCd == mf.JoinDestMakerCd

                );
            }
            return false;
        }

        /// <summary>
        /// �����񓚐�p�@�D�揇��3:���Ӑ�{�����ށ{���[�J�[�ł��邩���f���܂��B
        /// </summary>
        /// <param name="autoAnsItemSt">�����񓚕i�ڐݒ�</param>
        /// <param name="mf">�������ʕ��i���</param>
        /// <param name="customerCodeWk">���Ӑ�R�[�h</param>
        /// <returns>
        /// <c>true</c> :�D�揇��3�ł��B<br/>
        /// <c>false</c>:�D�揇��3�ł͂���܂���B
        /// </returns>
        private static bool IsPriority3(AutoAnsItemStForOffer autoAnsItemSt, OfferJoinPartsRetWork mf, int customerCodeWk)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == mf.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.CustomerCode == customerCodeWk
                        &&
                    autoAnsItemSt.GoodsMGroup == mf.GoodsMGroup
                        &&
                    autoAnsItemSt.BLGoodsCode == 0
                        &&
                    autoAnsItemSt.GoodsMakerCd == mf.JoinDestMakerCd
                );
            }
            return false;
        }

        /// <summary>
        /// �����񓚐�p�@�D�揇��4:���Ӑ�{���[�J�[�ł��邩���f���܂��B
        /// </summary>
        /// <param name="autoAnsItemSt">�����񓚕i�ڐݒ�</param>
        /// <param name="mf">�������ʕ��i���</param>
        /// <param name="customerCodeWk">���Ӑ�R�[�h</param>
        /// <returns>
        /// <c>true</c> :�D�揇��4�ł��B<br/>
        /// <c>false</c>:�D�揇��4�ł͂���܂���B
        /// </returns>
        private static bool IsPriority4(AutoAnsItemStForOffer autoAnsItemSt, OfferJoinPartsRetWork mf, int customerCodeWk)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == mf.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.CustomerCode == customerCodeWk
                        &&
                    autoAnsItemSt.GoodsMGroup == 0
                        &&
                    autoAnsItemSt.BLGoodsCode == 0
                        &&
                    autoAnsItemSt.GoodsMakerCd == mf.JoinDestMakerCd
                );
            }
            return false;
        }

        /// <summary>
        /// �����񓚐�p�@�D�揇��5:���_�{�����ށ{BL�R�[�h�{���[�J�[�ł��邩���f���܂��B
        /// </summary>
        /// <param name="autoAnsItemSt">�����񓚕i�ڐݒ�</param>
        /// <param name="mf">�������ʕ��i���</param>
        /// <param name="sectionCodeWk">���_�R�[�h</param>
        /// <returns>
        /// <c>true</c> :�D�揇��5�ł��B<br/>
        /// <c>false</c>:�D�揇��5�ł͂���܂���B
        /// </returns>
        private static bool IsPriority5(AutoAnsItemStForOffer autoAnsItemSt, OfferJoinPartsRetWork mf, string sectionCodeWk)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == mf.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.SectionCode.Trim() == sectionCodeWk
                        &&
                    autoAnsItemSt.GoodsMGroup == mf.GoodsMGroup
                        &&
                    autoAnsItemSt.BLGoodsCode == mf.TbsPartsCode
                        &&
                    autoAnsItemSt.GoodsMakerCd == mf.JoinDestMakerCd
                );
            }
            return false;
        }

        /// <summary>
        /// �����񓚐�p�@�D�揇��6:���_�{�����ށi���ʁj�{BL�R�[�h�{���[�J�[�ł��邩���f���܂��B
        /// </summary>
        /// <param name="autoAnsItemSt">�����񓚕i�ڐݒ�</param>
        /// <param name="mf">�������ʕ��i���</param>
        /// <param name="sectionCodeWk">���_�R�[�h</param>
        /// <returns>
        /// <c>true</c> :�D�揇��6�ł��B<br/>
        /// <c>false</c>:�D�揇��6�ł͂���܂���B
        /// </returns>
        private static bool IsPriority6(AutoAnsItemStForOffer autoAnsItemSt, OfferJoinPartsRetWork mf, string sectionCodeWk)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == mf.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.SectionCode.Trim() == sectionCodeWk
                        &&
                    autoAnsItemSt.GoodsMGroup == 0
                        &&
                    autoAnsItemSt.BLGoodsCode == mf.TbsPartsCode
                        &&
                    autoAnsItemSt.GoodsMakerCd == mf.JoinDestMakerCd

                );
            }
            return false;
        }

        /// <summary>
        /// �����񓚐�p�@�D�揇��7:���_�{�����ނł��邩���f���܂��B
        /// </summary>
        /// <param name="autoAnsItemSt">�����񓚕i�ڐݒ�</param>
        /// <param name="mf">�������ʕ��i���</param>
        /// <param name="sectionCodeWk">���_�R�[�h</param>
        /// <returns>
        /// <c>true</c> :�D�揇��7�ł��B<br/>
        /// <c>false</c>:�D�揇��7�ł͂���܂���B
        /// </returns>
        private static bool IsPriority7(AutoAnsItemStForOffer autoAnsItemSt, OfferJoinPartsRetWork mf, string sectionCodeWk)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == mf.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.SectionCode.Trim() == sectionCodeWk
                        &&
                    autoAnsItemSt.GoodsMGroup == mf.GoodsMGroup
                        &&
                    autoAnsItemSt.BLGoodsCode == 0
                        &&
                    autoAnsItemSt.GoodsMakerCd == mf.JoinDestMakerCd
                );
            }
            return false;
        }

        /// <summary>
        /// �����񓚐�p�@�D�揇��8:���_�ł��邩���f���܂��B
        /// </summary>
        /// <param name="autoAnsItemSt">�����񓚕i�ڐݒ�</param>
        /// <param name="mf">�������ʕ��i���</param>
        /// <param name="sectionCodeWk">���_�R�[�h</param>
        /// <returns>
        /// <c>true</c> :�D�揇��8�ł��B<br/>
        /// <c>false</c>:�D�揇��8�ł͂���܂���B
        /// </returns>
        private static bool IsPriority8(AutoAnsItemStForOffer autoAnsItemSt, OfferJoinPartsRetWork mf, string sectionCodeWk)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == mf.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.SectionCode.Trim() == sectionCodeWk
                        &&
                    autoAnsItemSt.GoodsMGroup == 0
                        &&
                    autoAnsItemSt.BLGoodsCode == 0
                        &&
                    autoAnsItemSt.GoodsMakerCd == mf.JoinDestMakerCd
                );
            }
            return false;
        }

        #endregion
        // ADD 2014/05/09 ���x���P�t�F�[�Y�Q��11,��12 �g��  --------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    }

    // ADD 2014/05/09 ���x���P�t�F�[�Y�Q��11,��12 �g��  -------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    /// <summary>
    /// �����񓚐�p�@�I�t�@�[�p�����񓚕i�ڐݒ�f�[�^�N���X
    /// </summary>
    internal class AutoAnsItemStForOffer
    {
        /// <summary>���_�R�[�h</summary>
        /// <remarks>00�͑S��</remarks>
        private string _sectionCode = "";

        /// <summary>���Ӑ�R�[�h</summary>
        /// <remarks>0�͑S���Ӑ�</remarks>
        private Int32 _customerCode;

        /// <summary>���i�����ރR�[�h</summary>
        private Int32 _goodsMGroup;

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>�D�ǐݒ�ڍ׃R�[�h�Q</summary>
        /// <remarks>����ʃR�[�h</remarks>
        private Int32 _prmSetDtlNo2;

        /// <summary>�����񓚋敪</summary>
        /// <remarks>0:���Ȃ�,1:�[��,2:���i</remarks>
        private Int32 _autoAnswerDiv;

        /// <summary>�D�揇��</summary>
        private Int32 _priorityOrder;

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>00�͑S��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// <value>0�͑S���Ӑ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>���i�����ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރR�[�h�v���p�e�B</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
       /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  PrmSetDtlNo2
        /// <summary>�D�ǐݒ�ڍ׃R�[�h�Q�v���p�e�B</summary>
        /// <value>����ʃR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǐݒ�ڍ׃R�[�h�Q�v���p�e�B</br>
        /// </remarks>
        public Int32 PrmSetDtlNo2
        {
            get { return _prmSetDtlNo2; }
            set { _prmSetDtlNo2 = value; }
        }

        /// public propaty name  :  AutoAnswerDiv
        /// <summary>�����񓚋敪�v���p�e�B</summary>
        /// <value>0:���Ȃ�,1:�[��,2:���i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����񓚋敪�v���p�e�B</br>
        /// </remarks>
        public Int32 AutoAnswerDiv
        {
            get { return _autoAnswerDiv; }
            set { _autoAnswerDiv = value; }
        }

        /// public propaty name  :  PriorityOrder
        /// <summary>�D�揇�ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�揇�ʃv���p�e�B</br>
        /// </remarks>
        public Int32 PriorityOrder
        {
            get { return _priorityOrder; }
            set { _priorityOrder = value; }
        }

        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>AutoAnsItemSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AutoAnsItemSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// </remarks>
        public AutoAnsItemStForOffer()
        {
        }
    }

    /// <summary>
    /// �����񓚐�p�@�I�t�@�[�p�D�ǐݒ�f�[�^�N���X
    /// </summary>
    internal class PrmSettingUForOffer
    {
        /// <summary>���i�����ރR�[�h</summary>
        /// <remarks>��������</remarks>
        private Int32 _goodsMGroup;

        /// <summary>BL�R�[�h</summary>
        private Int32 _tbsPartsCode;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _partsMakerCd;

        /// <summary>�D�ǐݒ�ڍ׃R�[�h�P</summary>
        /// <remarks>���Z���N�g�R�[�h</remarks>
        private Int32 _prmSetDtlNo1;

        /// <summary>�D�ǐݒ�ڍ׃R�[�h�Q</summary>
        /// <remarks>����ʃR�[�h</remarks>
        private Int32 _prmSetDtlNo2;

        /// <summary>�D�Ǖ\���敪</summary>
        /// <remarks>0:�����@1:���i&�����@2:���i</remarks>
        private Int32 _primeDisplayCode;

        /// public propaty name  :  GoodsMGroup
        /// <summary>���i�����ރR�[�h�v���p�e�B</summary>
        /// <value>��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރR�[�h�v���p�e�B</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  TbsPartsCode
        /// <summary>BL�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�v���p�e�B</br>
        /// </remarks>
        public Int32 TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }

        /// public propaty name  :  PartsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// </remarks>
        public Int32 PartsMakerCd
        {
            get { return _partsMakerCd; }
            set { _partsMakerCd = value; }
        }

        /// public propaty name  :  PrmSetDtlNo1
        /// <summary>�D�ǐݒ�ڍ׃R�[�h�P�v���p�e�B</summary>
        /// <value>���Z���N�g�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǐݒ�ڍ׃R�[�h�P�v���p�e�B</br>
        /// </remarks>
        public Int32 PrmSetDtlNo1
        {
            get { return _prmSetDtlNo1; }
            set { _prmSetDtlNo1 = value; }
        }

        /// public propaty name  :  PrmSetDtlNo2
        /// <summary>�D�ǐݒ�ڍ׃R�[�h�Q�v���p�e�B</summary>
        /// <value>����ʃR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǐݒ�ڍ׃R�[�h�Q�v���p�e�B</br>
        /// </remarks>
        public Int32 PrmSetDtlNo2
        {
            get { return _prmSetDtlNo2; }
            set { _prmSetDtlNo2 = value; }
        }

        /// public propaty name  :  PrimeDisplayCode
        /// <summary>�D�Ǖ\���敪�v���p�e�B</summary>
        /// <value>0:�����@1:���i&�����@2:���i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�Ǖ\���敪�v���p�e�B</br>
        /// </remarks>
        public Int32 PrimeDisplayCode
        {
            get { return _primeDisplayCode; }
            set { _primeDisplayCode = value; }
        }

        /// <summary>
        /// �D�ǐݒ�i���[�U�[�o�^���j���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PrmSettingUWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmSettingUWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// </remarks>
        public PrmSettingUForOffer()
        {
        }
    }
    // ADD 2014/05/09 ���x���P�t�F�[�Y�Q��11,��12 �g��  --------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
}
