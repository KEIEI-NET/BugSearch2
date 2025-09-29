using System;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Data;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���R�����^�����擾�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R�����^�����擾�����[�g�N���X�ł��B</br>
    /// <br>Programmer : 22018  ��� ���b</br>
    /// <br>Date       : 2010/04/19</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class FreeSearchModelSearchDB : RemoteDB, IFreeSearchModelSearchDB
    {
        # region --- private��` ---
        # region --- ���R�����^���}�X�^�擾���ڒ�` ---

        //���R�����^���}�X�^�擾���ڒ�`
        private string CARMODELRFSelectFields = "SELECT"
                + "  CAR.MAKERCODERF"
                + ", MAKERNAMERF"
                + ", MAKERKANANAMERF"
                + ", CAR.MODELCODERF"
                + ", CAR.MODELSUBCODERF"
                + ", MODELFULLNAMERF"
                + ", MODELHALFNAMERF"
                + ", CAR.STPRODUCETYPEOFYEARRF"
                + ", CAR.EDPRODUCETYPEOFYEARRF"
                + ", CAR.DOORCOUNTRF"
                + ", CAR.BODYNAMERF"
                + ", CAR.EXHAUSTGASSIGNRF"
                + ", CAR.SERIESMODELRF"
                + ", CAR.CATEGORYSIGNMODELRF"
                + ", CAR.FULLMODELRF"
                + ", CAR.STPRODUCEFRAMENORF"
                + ", CAR.EDPRODUCEFRAMENORF"
                + ", CAR.MODELGRADENMRF"
                + ", CAR.ENGINEMODELNMRF"
                + ", CAR.ENGINEDISPLACENMRF"
                + ", CAR.EDIVNMRF"
                + ", CAR.TRANSMISSIONNMRF"
                + ", CAR.WHEELDRIVEMETHODNMRF"
                + ", CAR.SHIFTNMRF"
                + ", CAR.FREESRCHMDLFXDNORF";

        private string CarKindSelectFields = "SELECT DISTINCT "
                + "  CAR.MAKERCODERF"
                + ", CAR.MODELCODERF"
                + ", CAR.MODELSUBCODERF"
                + ", MAKERNAMERF"
                + ", MAKERKANANAMERF"
                + ", MODELFULLNAMERF"
                + ", MODELHALFNAMERF";

        private string CarKindEgnSelectFields = "SELECT DISTINCT "
                + "  CAR.MAKERCODERF"
                + ", CAR.MODELCODERF"
                + ", CAR.MODELSUBCODERF"
                + ", CAR.ENGINEMODELNMRF"
                + ", MAKERNAMERF"
                + ", MAKERKANANAMERF"
                + ", MODELFULLNAMERF"
                + ", MODELHALFNAMERF";

        private string CARMODELRFOrderByFields = " ORDER BY"
                + "  CAR.MAKERCODERF"
                + ", CAR.MODELCODERF"
                + ", CAR.MODELSUBCODERF";

        private string CARMODELRFOrderByFieldsForCarModelSearch = " ORDER BY"
                + "  CAR.MAKERCODERF"
                + ", CAR.MODELCODERF"
                + ", CAR.MODELSUBCODERF"
                + ", CAR.FULLMODELRF"
                + ", CAR.STPRODUCETYPEOFYEARRF"
                + ", CAR.EDPRODUCETYPEOFYEARRF";

        # endregion
        # endregion

        # region --- �R���X�g���N�^ ---
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public FreeSearchModelSearchDB()
            : base( "PMJKN06003D", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelSCarKindInfoWork", "FREESEARCHMODELRF" )
        {
        }
        # endregion

        # region --- �^�����擾���� ---

        # region --- �^�������������ޕʌ^�������� ---
        /// <summary>
        /// �ޕʌ^����������
        /// </summary>
        /// <param name="freeSearchModelSCndtnWork">�ԗ���������</param>
        /// <param name="kindList">��������(�Ԏ탊�X�g)</param>
        /// <param name="carModelRetList">��������(�^�����X�g)</param>
        /// <returns>DB Status</returns>
        public int GetCarCtgyMdl( FreeSearchModelSCndtnWork freeSearchModelSCndtnWork, out ArrayList kindList, out ArrayList carModelRetList )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            kindList = new ArrayList();
            carModelRetList = new ArrayList();

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo( ConstantManagement_SF_PRO.IndexCode_UserDB );
                if ( string.IsNullOrEmpty( connectionText ) )
                    return status;

                //SQL������
                sqlConnection = new SqlConnection( connectionText );
                sqlConnection.Open();

                //--------------------------------------------------------
                // ���Ԏ팟���ƌ^�������̑g�ݍ��킹��PMTKD06101R�ɏ���
                //
                // �@�Ԏ팟���@
                //�@�@�@�Ԏ팟���̂�
                //�@�@�@�Ԏ팟���{�^������ (�Ԏ�1���̏ꍇ)
                // �@�^�������@
                //�@�@�@�^�������̂�
                //--------------------------------------------------------

                // �Ԏ팟��
                if ( freeSearchModelSCndtnWork.SearchMode == 0 )
                {
                    status = GetCarKindCtgyMdlProc( freeSearchModelSCndtnWork, out kindList, sqlConnection, null );
                }

                // �^������
                if ( (kindList.Count == 1 && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) || freeSearchModelSCndtnWork.SearchMode == 1 )
                {
                    status = GetCarCtgyMdlSearchProc( freeSearchModelSCndtnWork, out carModelRetList, sqlConnection, null );
                }
            }
            catch ( SqlException ex )
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "FreeSearchModelSearchDB.GetCarCtgyMdlSearch Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( sqlConnection != null )
                {
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="freeSearchModelSCndtnWork"></param>
        /// <param name="kindList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int GetCarKindCtgyMdlProc( FreeSearchModelSCndtnWork freeSearchModelSCndtnWork, out ArrayList kindList, SqlConnection sqlConnection, SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            kindList = new ArrayList();
            SqlDataReader myReader = null;

            try
            {
                //�擾����
                string sqlText = CarKindSelectFields;
                SqlCommand sqlCmd = new SqlCommand();

                //�A���w��
                sqlText += " FROM FREESEARCHMODELRF AS CAR ";
                sqlText += " INNER JOIN MAKERURF ON CAR.MAKERCODERF = MAKERURF.GOODSMAKERCDRF ";
                sqlText += " INNER JOIN MODELNAMEURF ON CAR.MAKERCODERF = MODELNAMEURF.MAKERCODERF AND CAR.MODELCODERF = MODELNAMEURF.MODELCODERF AND CAR.MODELSUBCODERF = MODELNAMEURF.MODELSUBCODERF ";


                //���o����
                sqlText += " WHERE";
                sqlText += " CAR.MODELDESIGNATIONNORF = @MODELDESIGNATIONNORF";
                sqlText += " AND CAR.CATEGORYNORF = @CATEGORYNORF";
                ((SqlParameter)sqlCmd.Parameters.Add( "@MODELDESIGNATIONNORF", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt32( freeSearchModelSCndtnWork.ModelDesignationNo );
                ((SqlParameter)sqlCmd.Parameters.Add( "@CATEGORYNORF", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt32( freeSearchModelSCndtnWork.CategoryNo );

                if ( freeSearchModelSCndtnWork.MakerCode != 0 )
                {
                    sqlText += " AND CAR.MAKERCODERF = @MAKERCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@MAKERCODERF", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt32( freeSearchModelSCndtnWork.MakerCode );
                }
                if ( freeSearchModelSCndtnWork.ModelCode != 0 )
                {
                    sqlText += " AND CAR.MODELCODERF = @MODELCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@MODELCODERF", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt32( freeSearchModelSCndtnWork.ModelCode );
                }
                if ( freeSearchModelSCndtnWork.ModelSubCode != -1 )
                {
                    sqlText += " AND CAR.MODELSUBCODERF = @MODELSUBCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@MODELSUBCODERF", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt32( freeSearchModelSCndtnWork.ModelSubCode );
                }

                //�uORDER BY�v�ݒ�
                sqlText += CARMODELRFOrderByFields;

                sqlCmd.Connection = sqlConnection;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = sqlText;
                sqlCmd.Transaction = sqlTransaction;

                // SQL�̎��s
                myReader = sqlCmd.ExecuteReader();

                // �Ԏ���i�[����
                SetFreeSearchModelSCarKindInfoWork( myReader, kindList );
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch ( SqlException ex )
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "FreeSearchModelSearchDB.GetCarKindCtgyMdl Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( myReader != null && myReader.IsClosed == false )
                {
                    myReader.Close();
                }
            }
            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="freeSearchModelSCndtnWork"></param>
        /// <param name="carModelRetList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int GetCarCtgyMdlSearchProc( FreeSearchModelSCndtnWork freeSearchModelSCndtnWork, out ArrayList carModelRetList, SqlConnection sqlConnection, SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            carModelRetList = new ArrayList();
            SqlDataReader myReader = null;

            try
            {
                //�擾����
                string sqlText = CARMODELRFSelectFields;
                SqlCommand sqlCmd = new SqlCommand();

                //�A���w��
                sqlText += " FROM FREESEARCHMODELRF AS CAR ";
                sqlText += " INNER JOIN MAKERURF ON CAR.MAKERCODERF = MAKERURF.GOODSMAKERCDRF ";
                sqlText += " INNER JOIN MODELNAMEURF ON CAR.MAKERCODERF = MODELNAMEURF.MAKERCODERF AND CAR.MODELCODERF = MODELNAMEURF.MODELCODERF AND CAR.MODELSUBCODERF = MODELNAMEURF.MODELSUBCODERF ";


                //���o����
                sqlText += " WHERE";
                sqlText += " CAR.MODELDESIGNATIONNORF = @MODELDESIGNATIONNORF";
                sqlText += " AND CAR.CATEGORYNORF = @CATEGORYNORF";
                ((SqlParameter)sqlCmd.Parameters.Add( "@MODELDESIGNATIONNORF", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt32( freeSearchModelSCndtnWork.ModelDesignationNo );
                ((SqlParameter)sqlCmd.Parameters.Add( "@CATEGORYNORF", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt32( freeSearchModelSCndtnWork.CategoryNo );

                if ( freeSearchModelSCndtnWork.MakerCode != 0 )
                {
                    sqlText += " AND CAR.MAKERCODERF = @MAKERCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@MAKERCODERF", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt32( freeSearchModelSCndtnWork.MakerCode );
                }
                if ( freeSearchModelSCndtnWork.ModelCode != 0 )
                {
                    sqlText += " AND CAR.MODELCODERF = @MODELCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@MODELCODERF", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt32( freeSearchModelSCndtnWork.ModelCode );
                }
                if ( freeSearchModelSCndtnWork.ModelSubCode != -1 )
                {
                    sqlText += " AND CAR.MODELSUBCODERF = @MODELSUBCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@MODELSUBCODERF", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt32( freeSearchModelSCndtnWork.ModelSubCode );
                }
                // --- ADD m.suzuki 2009/00/00 ---------->>>>>
                sqlText += " ORDER BY FULLMODELRF, MODELGRADENMRF, BODYNAMERF, DOORCOUNTRF, ENGINEMODELNMRF, ENGINEDISPLACENMRF, EDIVNMRF, TRANSMISSIONNMRF, SHIFTNMRF, WHEELDRIVEMETHODNMRF ";
                // --- ADD m.suzuki 2009/00/00 ----------<<<<<

                sqlCmd.Connection = sqlConnection;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = sqlText;
                sqlCmd.Transaction = sqlTransaction;

                // SQL�̎��s
                myReader = sqlCmd.ExecuteReader();

                // ���q�^���i�[����
                SetFreeSearchModelSRetWork( myReader, carModelRetList );
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch ( SqlException ex )
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "FreeSearchModelSearchDB.GetCarCtgyMdlSearch Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( myReader != null && myReader.IsClosed == false )
                {
                    myReader.Close();
                }
            }
            return status;
        }

        # endregion

        # region --- �^�������������^�������� ---
        /// <summary>
        /// �^������
        /// </summary>
        /// <param name="freeSearchModelSCndtnWork"></param>
        /// <param name="kindList"></param>
        /// <param name="carModelRetList"></param>
        /// <returns></returns>
        public int GetCarModel( FreeSearchModelSCndtnWork freeSearchModelSCndtnWork, out ArrayList kindList, out ArrayList carModelRetList )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            kindList = new ArrayList();
            carModelRetList = new ArrayList();

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo( ConstantManagement_SF_PRO.IndexCode_UserDB );
                if ( string.IsNullOrEmpty( connectionText ) )
                    return status;

                //SQL������
                sqlConnection = new SqlConnection( connectionText );
                sqlConnection.Open();

                //--------------------------------------------------------
                // ���Ԏ팟���ƌ^�������̑g�ݍ��킹��PMTKD06101R�ɏ���
                //
                // �@�Ԏ팟���@
                //�@�@�@�Ԏ팟���̂�
                //�@�@�@�Ԏ팟���{�^������ (�Ԏ�1���̏ꍇ)
                // �@�^�������@
                //�@�@�@�^�������̂�
                //--------------------------------------------------------

                // �Ԏ팟��
                if ( freeSearchModelSCndtnWork.SearchMode == 0 )
                {
                    status = GetCarKindModelProc( freeSearchModelSCndtnWork, out kindList, sqlConnection, null );
                }

                // �^������
                if ( (kindList.Count == 1 && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) || freeSearchModelSCndtnWork.SearchMode == 1 )
                {
                    status = GetCarModelSearchProc( freeSearchModelSCndtnWork, out carModelRetList, sqlConnection, null );
                }
            }
            catch ( SqlException ex )
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "FreeSearchModelSearchDB.GetCarModelSearch Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( sqlConnection != null )
                {
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        /// <summary>
        /// �^�������i�Ԏ�擾�j
        /// </summary>
        /// <param name="freeSearchModelSCndtnWork"></param>
        /// <param name="kindList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransanction"></param>
        /// <returns></returns>
        private int GetCarKindModelProc( FreeSearchModelSCndtnWork freeSearchModelSCndtnWork, out ArrayList kindList, SqlConnection sqlConnection, SqlTransaction sqlTransanction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            kindList = new ArrayList();
            SqlDataReader myReader = null;

            try
            {
                //�擾����
                string sqlText = CarKindSelectFields;
                string whereString = string.Empty;
                SqlCommand sqlCmd = new SqlCommand();

                //�A���w��
                sqlText += " FROM FREESEARCHMODELRF AS CAR ";
                sqlText += " INNER JOIN MAKERURF ON CAR.MAKERCODERF = MAKERURF.GOODSMAKERCDRF ";
                sqlText += " INNER JOIN MODELNAMEURF ON CAR.MAKERCODERF = MODELNAMEURF.MAKERCODERF AND CAR.MODELCODERF = MODELNAMEURF.MODELCODERF AND CAR.MODELSUBCODERF = MODELNAMEURF.MODELSUBCODERF";

                //���o����
                // �r�K�X�K�����ʋL��
                if ( freeSearchModelSCndtnWork.ExhaustGasSign != string.Empty )
                {
                    whereString += " AND CAR.EXHAUSTGASSIGNRF = @EXHAUSTGASSIGNRF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@EXHAUSTGASSIGNRF", SqlDbType.NChar )).Value = SqlDataMediator.SqlSetString( freeSearchModelSCndtnWork.ExhaustGasSign );
                }

                // �V���[�Y�^��
                if ( freeSearchModelSCndtnWork.SeriesModel != string.Empty )
                {
                    if ( freeSearchModelSCndtnWork.CategorySignModel == string.Empty )
                    {
                        // �ޕʋL�������͂���Ă��Ȃ���Ό����v                        
                        whereString += " AND CAR.SERIESMODELRF LIKE @SERIESMODELRF";
                        ((SqlParameter)sqlCmd.Parameters.Add( "@SERIESMODELRF", SqlDbType.NChar )).Value = SqlDataMediator.SqlSetString( freeSearchModelSCndtnWork.SeriesModel + '%' );
                    }
                    else
                    {
                        // �ޕʋL�������͂���Ă���ꍇ�͊��S��v
                        whereString += " AND CAR.SERIESMODELRF = @SERIESMODELRF";
                        ((SqlParameter)sqlCmd.Parameters.Add( "@SERIESMODELRF", SqlDbType.NChar )).Value = SqlDataMediator.SqlSetString( freeSearchModelSCndtnWork.SeriesModel );
                    }
                }

                // �ޕʋL��
                if ( freeSearchModelSCndtnWork.CategorySignModel != string.Empty )
                {
                    whereString += " AND CAR.CATEGORYSIGNMODELRF LIKE @CATEGORYSIGNMODELRF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@CATEGORYSIGNMODELRF", SqlDbType.NChar )).Value = SqlDataMediator.SqlSetString( freeSearchModelSCndtnWork.CategorySignModel + '%' );
                }

                if ( freeSearchModelSCndtnWork.MakerCode != 0 )
                {
                    whereString += " AND CAR.MAKERCODERF = @MAKERCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@MAKERCODERF", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt32( freeSearchModelSCndtnWork.MakerCode );
                }
                if ( freeSearchModelSCndtnWork.ModelCode != 0 )
                {
                    whereString += " AND CAR.MODELCODERF = @MODELCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@MODELCODERF", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt32( freeSearchModelSCndtnWork.ModelCode );
                }
                if ( freeSearchModelSCndtnWork.ModelSubCode != -1 )
                {
                    whereString += " AND CAR.MODELSUBCODERF = @MODELSUBCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@MODELSUBCODERF", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt32( freeSearchModelSCndtnWork.ModelSubCode );
                }

                if ( whereString.Length > 0 )
                {
                    sqlText += " WHERE " + whereString.Substring( 4 );
                }

                //�uORDER BY�v�ݒ�
                sqlText += CARMODELRFOrderByFields;

                sqlCmd.Connection = sqlConnection;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = sqlText;
                sqlCmd.Transaction = sqlTransanction;

                // SQL�̎��s
                myReader = sqlCmd.ExecuteReader();

                // �Ԏ���i�[����
                SetFreeSearchModelSCarKindInfoWork( myReader, kindList );
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch ( SqlException ex )
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "FreeSearchModelSearchDB.GetCarKindModel Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( myReader != null && myReader.IsClosed == false )
                {
                    myReader.Close();
                }
            }
            return status;
        }

        /// <summary>
        /// �^�������i�^���擾�j
        /// </summary>
        /// <param name="freeSearchModelSCndtnWork"></param>
        /// <param name="carModelRetList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int GetCarModelSearchProc( FreeSearchModelSCndtnWork freeSearchModelSCndtnWork, out ArrayList carModelRetList, SqlConnection sqlConnection, SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            carModelRetList = new ArrayList();
            SqlDataReader myReader = null;

            try
            {
                //�擾����
                string sqlText = CARMODELRFSelectFields;
                string whereString = string.Empty;
                SqlCommand sqlCmd = new SqlCommand();

                //�A���w��
                sqlText += " FROM FREESEARCHMODELRF AS CAR ";
                sqlText += " INNER JOIN MAKERURF ON CAR.MAKERCODERF = MAKERURF.GOODSMAKERCDRF ";
                sqlText += " INNER JOIN MODELNAMEURF ON CAR.MAKERCODERF = MODELNAMEURF.MAKERCODERF AND CAR.MODELCODERF = MODELNAMEURF.MODELCODERF AND CAR.MODELSUBCODERF = MODELNAMEURF.MODELSUBCODERF";


                //���o����
                // �r�K�X�K�����ʋL��
                if ( freeSearchModelSCndtnWork.ExhaustGasSign != string.Empty )
                {
                    whereString += " AND CAR.EXHAUSTGASSIGNRF = @EXHAUSTGASSIGNRF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@EXHAUSTGASSIGNRF", SqlDbType.NChar )).Value = SqlDataMediator.SqlSetString( freeSearchModelSCndtnWork.ExhaustGasSign );
                }

                // �V���[�Y�^��
                if ( freeSearchModelSCndtnWork.SeriesModel != string.Empty )
                {
                    if ( freeSearchModelSCndtnWork.CategorySignModel == string.Empty )
                    {
                        // �ޕʋL�������͂���Ă��Ȃ���Ό����v
                        whereString += " AND CAR.SERIESMODELRF LIKE @SERIESMODELRF";
                        ((SqlParameter)sqlCmd.Parameters.Add( "@SERIESMODELRF", SqlDbType.NChar )).Value = SqlDataMediator.SqlSetString( freeSearchModelSCndtnWork.SeriesModel + '%' );
                    }
                    else
                    {
                        // �ޕʋL�������͂���Ă���ꍇ�͊��S��v
                        whereString += " AND CAR.SERIESMODELRF = @SERIESMODELRF";
                        ((SqlParameter)sqlCmd.Parameters.Add( "@SERIESMODELRF", SqlDbType.NChar )).Value = SqlDataMediator.SqlSetString( freeSearchModelSCndtnWork.SeriesModel );
                    }
                }

                // �ޕʋL��
                if ( freeSearchModelSCndtnWork.CategorySignModel != string.Empty )
                {
                    whereString += " AND CAR.CATEGORYSIGNMODELRF LIKE @CATEGORYSIGNMODELRF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@CATEGORYSIGNMODELRF", SqlDbType.NChar )).Value = SqlDataMediator.SqlSetString( freeSearchModelSCndtnWork.CategorySignModel + '%' );
                }

                if ( freeSearchModelSCndtnWork.MakerCode != 0 )
                {
                    whereString += " AND CAR.MAKERCODERF = @MAKERCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@MAKERCODERF", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt32( freeSearchModelSCndtnWork.MakerCode );
                }
                if ( freeSearchModelSCndtnWork.ModelCode != 0 )
                {
                    whereString += " AND CAR.MODELCODERF = @MODELCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@MODELCODERF", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt32( freeSearchModelSCndtnWork.ModelCode );
                }
                if ( freeSearchModelSCndtnWork.ModelSubCode != -1 )
                {
                    whereString += " AND CAR.MODELSUBCODERF = @MODELSUBCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@MODELSUBCODERF", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt32( freeSearchModelSCndtnWork.ModelSubCode );
                }

                if ( whereString.Length > 0 )
                {
                    sqlText += " WHERE " + whereString.Substring( 4 );
                }
                //�uORDER BY�v�ݒ�
                sqlText += CARMODELRFOrderByFieldsForCarModelSearch;

                sqlCmd.Connection = sqlConnection;
                sqlCmd.CommandText = sqlText;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Transaction = sqlTransaction;

                // SQL�̎��s
                myReader = sqlCmd.ExecuteReader();

                // ���q�^���i�[����
                SetFreeSearchModelSRetWork( myReader, carModelRetList );
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch ( SqlException ex )
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "FreeSearchModelSearchDB.GetCarModelSearch Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( myReader != null && myReader.IsClosed == false )
                {
                    myReader.Close();
                }
            }
            return status;
        }
        # endregion

        # region --- �^�������������G���W���^�������� ---
        /// <summary>
        /// �G���W���^����������
        /// </summary>
        /// <param name="freeSearchModelSCndtnWork">�ԗ���������</param>
        /// <param name="kindList">��������(�Ԏ탊�X�g)</param>
        /// <param name="carModelRetList">��������(�^�����X�g)</param>
        /// <returns>DB Status</returns>
        public int GetCarEngine( FreeSearchModelSCndtnWork freeSearchModelSCndtnWork, out ArrayList kindList, out ArrayList carModelRetList )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            kindList = new ArrayList();
            carModelRetList = new ArrayList();

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo( ConstantManagement_SF_PRO.IndexCode_UserDB );
                if ( string.IsNullOrEmpty( connectionText ) )
                    return status;

                //SQL������
                sqlConnection = new SqlConnection( connectionText );
                sqlConnection.Open();

                //--------------------------------------------------------
                // ���Ԏ팟���ƌ^�������̑g�ݍ��킹��PMTKD06101R�ɏ���
                //
                // �@�Ԏ팟���@
                //�@�@�@�Ԏ팟���̂�
                //�@�@�@�Ԏ팟���{�^������ (�Ԏ�1���̏ꍇ)
                // �@�^�������@
                //�@�@�@�^�������̂�
                //--------------------------------------------------------

                // �Ԏ팟��
                if ( freeSearchModelSCndtnWork.SearchMode == 0 )
                {
                    status = GetCarKindEngineProc( freeSearchModelSCndtnWork, out kindList, sqlConnection, null );
                }

                // �^������
                if ( (kindList.Count == 1 && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) || freeSearchModelSCndtnWork.SearchMode == 1 )
                {
                    status = GetCarEngineSearchProc( freeSearchModelSCndtnWork, out carModelRetList, sqlConnection, null );
                }
            }
            catch ( SqlException ex )
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "FreeSearchModelSearchDB.GetCarEngineSearch Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( sqlConnection != null )
                {
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        /// <summary>
        /// �G���W���^�������i�Ԏ�擾�j
        /// </summary>
        /// <param name="freeSearchModelSCndtnWork"></param>
        /// <param name="kindList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int GetCarKindEngineProc( FreeSearchModelSCndtnWork freeSearchModelSCndtnWork, out ArrayList kindList, SqlConnection sqlConnection, SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            kindList = new ArrayList();
            SqlDataReader myReader = null;

            try
            {
                //�擾����
                string sqlText = CarKindEgnSelectFields;
                SqlCommand sqlCmd = new SqlCommand();

                //�A���w��
                sqlText += " FROM FREESEARCHMODELRF AS CAR ";
                sqlText += " INNER JOIN MAKERURF ON CAR.MAKERCODERF = MAKERURF.GOODSMAKERCDRF ";
                sqlText += " INNER JOIN MODELNAMEURF ON CAR.MAKERCODERF = MODELNAMEURF.MAKERCODERF AND CAR.MODELCODERF = MODELNAMEURF.MODELCODERF AND CAR.MODELSUBCODERF = MODELNAMEURF.MODELSUBCODERF";

                //���o����
                sqlText += " WHERE CAR.ENGINEMODELNMRF LIKE @ENGINEMODELNMRF";
                ((SqlParameter)sqlCmd.Parameters.Add( "@ENGINEMODELNMRF", SqlDbType.NChar )).Value = SqlDataMediator.SqlSetString( freeSearchModelSCndtnWork.EngineModelNm + "%" );

                if ( freeSearchModelSCndtnWork.MakerCode != 0 )
                {
                    sqlText += " AND CAR.MAKERCODERF = @MAKERCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@MAKERCODERF", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt32( freeSearchModelSCndtnWork.MakerCode );
                }
                if ( freeSearchModelSCndtnWork.ModelCode != 0 )
                {
                    sqlText += " AND CAR.MODELCODERF = @MODELCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@MODELCODERF", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt32( freeSearchModelSCndtnWork.ModelCode );
                }
                if ( freeSearchModelSCndtnWork.ModelSubCode != -1 )
                {
                    sqlText += " AND CAR.MODELSUBCODERF = @MODELSUBCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@MODELSUBCODERF", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt32( freeSearchModelSCndtnWork.ModelSubCode );
                }

                //�uORDER BY�v�ݒ�
                sqlText += CARMODELRFOrderByFields;

                sqlCmd.Connection = sqlConnection;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = sqlText;
                sqlCmd.Transaction = sqlTransaction;

                // SQL�̎��s
                myReader = sqlCmd.ExecuteReader();

                // �Ԏ���i�[����
                SetEgnFreeSearchModelSCarKindInfoWork( myReader, kindList );
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch ( SqlException ex )
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "FreeSearchModelSearchDB.GetCarKindEngine Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( myReader != null && myReader.IsClosed == false )
                {
                    myReader.Close();
                }
            }
            return status;
        }

        /// <summary>
        /// �G���W���^�������i�^���擾�j
        /// </summary>
        /// <param name="freeSearchModelSCndtnWork"></param>
        /// <param name="carModelRetList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int GetCarEngineSearchProc( FreeSearchModelSCndtnWork freeSearchModelSCndtnWork, out ArrayList carModelRetList, SqlConnection sqlConnection, SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            carModelRetList = new ArrayList();
            SqlDataReader myReader = null;

            try
            {
                //�擾����
                string sqlText = CARMODELRFSelectFields;
                SqlCommand sqlCmd = new SqlCommand();

                //�A���w��
                sqlText += " FROM FREESEARCHMODELRF AS CAR";
                sqlText += " INNER JOIN MAKERURF ON CAR.MAKERCODERF = MAKERURF.GOODSMAKERCDRF ";
                sqlText += " INNER JOIN MODELNAMEURF ON CAR.MAKERCODERF = MODELNAMEURF.MAKERCODERF AND CAR.MODELCODERF = MODELNAMEURF.MODELCODERF AND CAR.MODELSUBCODERF = MODELNAMEURF.MODELSUBCODERF ";

                //���o����
                sqlText += " WHERE CAR.ENGINEMODELNMRF LIKE @ENGINEMODELNMRF";
                ((SqlParameter)sqlCmd.Parameters.Add( "@ENGINEMODELNMRF", SqlDbType.NChar )).Value = SqlDataMediator.SqlSetString( freeSearchModelSCndtnWork.EngineModelNm + "%" );

                if ( freeSearchModelSCndtnWork.MakerCode != 0 )
                {
                    sqlText += " AND CAR.MAKERCODERF = @MAKERCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@MAKERCODERF", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt32( freeSearchModelSCndtnWork.MakerCode );
                }
                if ( freeSearchModelSCndtnWork.ModelCode != 0 )
                {
                    sqlText += " AND CAR.MODELCODERF = @MODELCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@MODELCODERF", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt32( freeSearchModelSCndtnWork.ModelCode );
                }
                if ( freeSearchModelSCndtnWork.ModelSubCode != -1 )
                {
                    sqlText += " AND CAR.MODELSUBCODERF = @MODELSUBCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@MODELSUBCODERF", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt32( freeSearchModelSCndtnWork.ModelSubCode );
                }

                sqlCmd.Connection = sqlConnection;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = sqlText;
                sqlCmd.Transaction = sqlTransaction;

                // SQL�̎��s
                myReader = sqlCmd.ExecuteReader();

                // ���q�^���i�[����
                SetFreeSearchModelSRetWork( myReader, carModelRetList );
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch ( SqlException ex )
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "FreeSearchModelSearchDB.GetCarEngineSearch Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( myReader != null && myReader.IsClosed == false )
                {
                    myReader.Close();
                }
            }

            return status;
        }
        # endregion

        #region --- �^�������������t���^���Œ�ԍ������� ---
        /// <summary>
        /// �t���^���Œ�ԍ���������
        /// </summary>
        /// <param name="freeSearchModelSCndtnWork">�ԗ���������</param>
        /// <param name="kindList">��������(�Ԏ탊�X�g)</param>
        /// <param name="carModelRetList">��������(�^�����X�g)</param>
        /// <returns>DB Status</returns>
        public int GetCarFullModelNo( FreeSearchModelSCndtnWork freeSearchModelSCndtnWork, out ArrayList kindList, out ArrayList carModelRetList )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            kindList = new ArrayList();
            carModelRetList = new ArrayList();

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo( ConstantManagement_SF_PRO.IndexCode_UserDB );
                if ( string.IsNullOrEmpty( connectionText ) )
                    return status;

                //SQL������
                sqlConnection = new SqlConnection( connectionText );
                sqlConnection.Open();

                //--------------------------------------------------------
                // ���Ԏ팟���ƌ^�������̑g�ݍ��킹��PMTKD06101R�ɏ���
                //
                // �@�Ԏ팟���@
                //�@�@�@�Ԏ팟���̂�
                //�@�@�@�Ԏ팟���{�^������ (�Ԏ�1���̏ꍇ)
                // �@�^�������@
                //�@�@�@�^�������̂�
                //--------------------------------------------------------

                // �Ԏ팟��
                if ( freeSearchModelSCndtnWork.SearchMode == 0 )
                {
                    status = GetCarKindFullModelNoProc( freeSearchModelSCndtnWork, out kindList, sqlConnection, null );
                }

                // �^������
                //if ( (kindList.Count == 1 && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) || freeSearchModelSCndtnWork.SearchMode == 1 )
                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || freeSearchModelSCndtnWork.SearchMode == 1 )
                {
                    status = GetCarFullModelNoSearchProc( freeSearchModelSCndtnWork, out carModelRetList, sqlConnection, null );
                }
            }
            catch ( SqlException ex )
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "FreeSearchModelSearchDB.GetCarEngineSearch Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( sqlConnection != null )
                {
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �t���^���Œ�ԍ����������i�Ԏ�擾�j
        /// </summary>
        /// <param name="freeSearchModelSCndtnWork"></param>
        /// <param name="kindList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransanction"></param>
        /// <returns></returns>
        private int GetCarKindFullModelNoProc( FreeSearchModelSCndtnWork freeSearchModelSCndtnWork, out ArrayList kindList, SqlConnection sqlConnection, SqlTransaction sqlTransanction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            kindList = new ArrayList();
            SqlDataReader myReader = null;

            try
            {
                //�擾����
                string sqlText = CarKindSelectFields;
                string whereString = string.Empty;
                SqlCommand sqlCmd = new SqlCommand();

                //�A���w��
                sqlText += " FROM FREESEARCHMODELRF AS CAR ";
                sqlText += " INNER JOIN MAKERURF ON CAR.MAKERCODERF = MAKERURF.GOODSMAKERCDRF ";
                sqlText += " INNER JOIN MODELNAMEURF ON CAR.MAKERCODERF = MODELNAMEURF.MAKERCODERF AND CAR.MODELCODERF = MODELNAMEURF.MODELCODERF AND CAR.MODELSUBCODERF = MODELNAMEURF.MODELSUBCODERF ";

                //���o����
                whereString = "WHERE FREESRCHMDLFXDNORF IN (";
                for ( int i = 0; i < freeSearchModelSCndtnWork.FreeSrchMdlFxdNos.Length; i++ )
                {
                    whereString += "'" + freeSearchModelSCndtnWork.FreeSrchMdlFxdNos[i].Trim() + "', ";
                }
                sqlText += whereString.Remove( whereString.Length - 2 ) + ") ";
                

                //�uORDER BY�v�ݒ�
                sqlText += CARMODELRFOrderByFields;

                sqlCmd.Connection = sqlConnection;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = sqlText;
                sqlCmd.Transaction = sqlTransanction;

                // SQL�̎��s
                myReader = sqlCmd.ExecuteReader();

                // �Ԏ���i�[����
                SetFreeSearchModelSCarKindInfoWork( myReader, kindList );
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch ( SqlException ex )
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "FreeSearchModelSearchDB.GetCarKindModel Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( myReader != null && myReader.IsClosed == false )
                {
                    myReader.Close();
                }
            }
            return status;
        }

        /// <summary>
        /// �t���^���Œ�ԍ����������i�^���擾�j
        /// </summary>
        /// <param name="freeSearchModelSCndtnWork"></param>
        /// <param name="carModelRetList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int GetCarFullModelNoSearchProc( FreeSearchModelSCndtnWork freeSearchModelSCndtnWork, out ArrayList carModelRetList, SqlConnection sqlConnection, SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            carModelRetList = new ArrayList();
            SqlDataReader myReader = null;

            try
            {
                //�擾����
                string sqlText = CARMODELRFSelectFields;
                string whereString = string.Empty;
                SqlCommand sqlCmd = new SqlCommand();

                //�A���w��
                sqlText += " FROM FREESEARCHMODELRF AS CAR ";
                sqlText += " INNER JOIN MAKERURF ON CAR.MAKERCODERF = MAKERURF.GOODSMAKERCDRF ";
                sqlText += " INNER JOIN MODELNAMEURF ON CAR.MAKERCODERF = MODELNAMEURF.MAKERCODERF AND CAR.MODELCODERF = MODELNAMEURF.MODELCODERF AND CAR.MODELSUBCODERF = MODELNAMEURF.MODELSUBCODERF ";

                //���o����
                whereString = "WHERE FREESRCHMDLFXDNORF IN (";
                for ( int i = 0; i < freeSearchModelSCndtnWork.FreeSrchMdlFxdNos.Length; i++ )
                {
                    //whereString += freeSearchModelSCndtnWork.FreeSrchMdlFxdNos[i].Trim() + ", ";
                    whereString += "'" + freeSearchModelSCndtnWork.FreeSrchMdlFxdNos[i].Trim() + "', ";
                }
                sqlText += whereString.Remove( whereString.Length - 2 ) + ") ";


                //�uORDER BY�v�ݒ�
                sqlText += CARMODELRFOrderByFields;

                sqlCmd.Connection = sqlConnection;
                sqlCmd.CommandText = sqlText;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Transaction = sqlTransaction;

                // SQL�̎��s
                myReader = sqlCmd.ExecuteReader();

                // ���q�^���i�[����
                SetFreeSearchModelSRetWork( myReader, carModelRetList );
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch ( SqlException ex )
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "FreeSearchModelSearchDB.GetCarFullModelNoSearchProc Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( myReader != null && myReader.IsClosed == false )
                {
                    myReader.Close();
                }
            }
            return status;
        }
        #endregion

        # endregion

        # region --- �i�[���� ---
        # region --- ���q�^���i�[���� ---
        /// <summary>
        /// ���q�^���i�[����
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="carModelRetList"></param>
        /// <returns></returns>
        private void SetFreeSearchModelSRetWork( SqlDataReader myReader, ArrayList carModelRetList )
        {
            while ( myReader.Read() )
            {
                FreeSearchModelSRetWork wkFreeSearchModelSRetWork = new FreeSearchModelSRetWork();

                wkFreeSearchModelSRetWork.MakerCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MAKERCODERF" ) );
                wkFreeSearchModelSRetWork.MakerFullName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MAKERNAMERF" ) );
                wkFreeSearchModelSRetWork.MakerHalfName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MAKERKANANAMERF" ) );
                wkFreeSearchModelSRetWork.ModelCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELCODERF" ) );
                wkFreeSearchModelSRetWork.ModelSubCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELSUBCODERF" ) );
                wkFreeSearchModelSRetWork.ModelFullName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MODELFULLNAMERF" ) );
                wkFreeSearchModelSRetWork.ModelHalfName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MODELHALFNAMERF" ) );
                wkFreeSearchModelSRetWork.SystematicCode = 0;
                wkFreeSearchModelSRetWork.SystematicName = string.Empty;
                wkFreeSearchModelSRetWork.ProduceTypeOfYearCd = 0;
                wkFreeSearchModelSRetWork.ProduceTypeOfYearNm = string.Empty;
                wkFreeSearchModelSRetWork.StProduceTypeOfYear = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "STPRODUCETYPEOFYEARRF" ) );
                wkFreeSearchModelSRetWork.EdProduceTypeOfYear = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "EDPRODUCETYPEOFYEARRF" ) );
                wkFreeSearchModelSRetWork.DoorCount = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DOORCOUNTRF" ) );
                wkFreeSearchModelSRetWork.BodyNameCode = 0;
                wkFreeSearchModelSRetWork.BodyName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "BODYNAMERF" ) );
                wkFreeSearchModelSRetWork.CarProperNo = 0;
                wkFreeSearchModelSRetWork.FullModelFixedNo = 0;
                wkFreeSearchModelSRetWork.ExhaustGasSign = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "EXHAUSTGASSIGNRF" ) );
                wkFreeSearchModelSRetWork.SeriesModel = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SERIESMODELRF" ) );
                wkFreeSearchModelSRetWork.CategorySignModel = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CATEGORYSIGNMODELRF" ) );
                wkFreeSearchModelSRetWork.FullModel = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FULLMODELRF" ) );
                wkFreeSearchModelSRetWork.FrameModel = string.Empty;
                wkFreeSearchModelSRetWork.StProduceFrameNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "STPRODUCEFRAMENORF" ) );
                wkFreeSearchModelSRetWork.EdProduceFrameNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "EDPRODUCEFRAMENORF" ) );
                wkFreeSearchModelSRetWork.ModelGradeNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MODELGRADENMRF" ) );
                wkFreeSearchModelSRetWork.EngineModelNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENGINEMODELNMRF" ) );
                wkFreeSearchModelSRetWork.EngineDisplaceNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENGINEDISPLACENMRF" ) );
                wkFreeSearchModelSRetWork.EDivNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "EDIVNMRF" ) );
                wkFreeSearchModelSRetWork.TransmissionNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "TRANSMISSIONNMRF" ) );
                wkFreeSearchModelSRetWork.WheelDriveMethodNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "WHEELDRIVEMETHODNMRF" ) );
                wkFreeSearchModelSRetWork.ShiftNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SHIFTNMRF" ) );
                wkFreeSearchModelSRetWork.AddiCarSpec1 = string.Empty;
                wkFreeSearchModelSRetWork.AddiCarSpec2 = string.Empty;
                wkFreeSearchModelSRetWork.AddiCarSpec3 = string.Empty;
                wkFreeSearchModelSRetWork.AddiCarSpec4 = string.Empty;
                wkFreeSearchModelSRetWork.AddiCarSpec5 = string.Empty;
                wkFreeSearchModelSRetWork.AddiCarSpec6 = string.Empty;
                wkFreeSearchModelSRetWork.AddiCarSpecTitle1 = string.Empty;
                wkFreeSearchModelSRetWork.AddiCarSpecTitle2 = string.Empty;
                wkFreeSearchModelSRetWork.AddiCarSpecTitle3 = string.Empty;
                wkFreeSearchModelSRetWork.AddiCarSpecTitle4 = string.Empty;
                wkFreeSearchModelSRetWork.AddiCarSpecTitle5 = string.Empty;
                wkFreeSearchModelSRetWork.AddiCarSpecTitle6 = string.Empty;
                wkFreeSearchModelSRetWork.RelevanceModel = string.Empty;
                wkFreeSearchModelSRetWork.SubCarNmCd = 0;
                wkFreeSearchModelSRetWork.ModelGradeSname = string.Empty;
                wkFreeSearchModelSRetWork.BlockIllustrationCd = 0;
                wkFreeSearchModelSRetWork.ThreeDIllustNo = 0;
                wkFreeSearchModelSRetWork.PartsDataOfferFlag = 1; // 1:���i�񋟂���
                wkFreeSearchModelSRetWork.FreeSrchMdlFxdNo = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FREESRCHMDLFXDNORF" ) );

                carModelRetList.Add( wkFreeSearchModelSRetWork );
            }
        }
        # endregion

        # region --- �Ԏ���i�[���� ---
        /// <summary>
        /// �Ԏ���i�[����
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="kindList"></param>
        /// <returns></returns>
        private void SetFreeSearchModelSCarKindInfoWork( SqlDataReader myReader, ArrayList kindList )
        {
            while ( myReader.Read() )
            {
                FreeSearchModelSCarKindInfoWork wkCarKind = new FreeSearchModelSCarKindInfoWork();

                wkCarKind.MakerCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MAKERCODERF" ) );
                wkCarKind.ModelCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELCODERF" ) );
                wkCarKind.ModelSubCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELSUBCODERF" ) );
                wkCarKind.MakerFullName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MAKERNAMERF" ) );
                wkCarKind.MakerHalfName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MAKERKANANAMERF" ) );
                wkCarKind.ModelFullName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MODELFULLNAMERF" ) );
                wkCarKind.ModelHalfName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MODELHALFNAMERF" ) );
                kindList.Add( wkCarKind );
            }
        }

        /// <summary>
        /// �Ԏ���i�[�������G���W��������p��
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="kindList"></param>
        /// <returns></returns>
        private void SetEgnFreeSearchModelSCarKindInfoWork( SqlDataReader myReader, ArrayList kindList )
        {
            while ( myReader.Read() )
            {
                FreeSearchModelSCarKindInfoWork wkCarKind = new FreeSearchModelSCarKindInfoWork();

                wkCarKind.MakerCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MAKERCODERF" ) );
                wkCarKind.ModelCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELCODERF" ) );
                wkCarKind.ModelSubCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELSUBCODERF" ) );
                wkCarKind.EngineModelNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENGINEMODELNMRF" ) );
                wkCarKind.MakerFullName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MAKERNAMERF" ) );
                wkCarKind.MakerHalfName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MAKERKANANAMERF" ) );
                wkCarKind.ModelFullName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MODELFULLNAMERF" ) );
                wkCarKind.ModelHalfName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MODELHALFNAMERF" ) );
                kindList.Add( wkCarKind );
            }
        }

        # endregion
        # endregion
    }
}
