//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �D�Ǖ��i�o�[�R�[�h��񒊏o�����[�g�I�u�W�F�N�g
// �v���O�����T�v   : �D�Ǖ��i�o�[�R�[�h��񒊏o�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370074-00  �쐬�S�� : 30757 ���X�؋M�p
// �� �� ��  2017/09/20   �C�����e : �n���f�B�^�[�~�i���񎟑Ή��i�V�K�쐬�j
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// �D�Ǖ��i�o�[�R�[�h��񒊏o�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �D�Ǖ��i�o�[�R�[�h��񒊏o�����̎��f�[�^������s���N���X�̒�`�Ǝ���</br>
    /// <br>Programmer : 30757�@���X�؁@�M�p</br>
    /// <br>Date       : 2017/09/20</br>
    /// </remarks>
    [Serializable]
    public class OfferPrmPartsBrcdInfoDB : RemoteDB, IOfferPrmPartsBrcdInfo
    {
        #region �萔��`

        /// <summary>
        /// ���o�����擾SELECT��
        /// </summary>
        private static readonly string SelectCountQuery = "SELECT \n    COUNT(*) \n";

        /// <summary>
        /// ��񒊏oSELECT��
        /// </summary>
        private static readonly string SelectQuery =
              "SELECT \n"
            + "         OFFERDATERF \n"
            + "        ,PARTSMAKERCODERF \n"
            + "        ,TBSPARTSCODERF \n"
            + "        ,PRIMEPARTSNOWITHHRF \n"
            + "        ,PRIMEPRTSBARCDKNDDIVRF \n"
            + "        ,PRIMEPARTSBARCODERF ";

        /// <summary>
        /// ���o�����擾�y�я�񒊏o����FROM��
        /// </summary>
        private static readonly string FromQuery = "FROM dbo.PRMPRTBRCDRF WITH (READUNCOMMITTED) ";

        /// <summary>
        /// ���o�����擾�y�я�񒊏o����WHERE��(�D�Ǖ��i�o�[�R�[�h��񒊏o�����p�����[�^�����݂��Ȃ��ꍇ)
        /// </summary>
        private static readonly string WhereSymbol = "WHERE ";

        /// <summary>
        /// WHERE��擪��������
        /// </summary>
        private static readonly string WhereFormatTop = "       (PARTSMAKERCODERF = {0} AND TBSPARTSCODERF = {1})";

        /// <summary>
        /// WHERE��擪�ȍ~��������
        /// </summary>
        private static readonly string WhereFormat = "    OR (PARTSMAKERCODERF = {0} AND TBSPARTSCODERF = {1})";

        /// <summary>
        /// SQL���s���^�C���A�E�g�K��l(3600�b)
        /// </summary>
        private const int SqlCommandTimeoutDefault = 3600;

        /// <summary>
        /// �G���[���b�Z�[�W�F�D�Ǖ��i�o�[�R�[�h��񒊏o�����擾�ŗ�O����
        /// </summary>
        private static readonly string ErrorTextGetSearchCountFaild = "�D�Ǖ��i�o�[�R�[�h��񒊏o�����擾�ŗ�O���������܂����B";

        /// <summary>
        /// �G���[���b�Z�[�W�F�D�Ǖ��i�o�[�R�[�h��񒊏o�ŗ�O����
        /// </summary>
        private static readonly string ErrorTextSearchFaild = "�D�Ǖ��i�o�[�R�[�h��񒊏o�����ŗ�O���������܂����B";

        #endregion //�萔��`


        #region �R���X�g���N�^
        /// <summary>
        /// �D�Ǖ��i�o�[�R�[�h��񒊏o�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �D�Ǖ��i�o�[�R�[�h��񒊏o�����[�g�I�u�W�F�N�g�N���X�̃C���X�^���X�𐶐�</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        public OfferPrmPartsBrcdInfoDB()
            :
            base( "PMTKD09404D", "Broadleaf.Application.Remoting.OfferPrmPartsBrcdInfoDB", "PRMPRTBRCDRF" )
        {
        }
        #endregion //�R���X�g���N�^

        #region IOfferPrmPartsBrcdInfo �����o
        /// <summary>
        /// �D�Ǖ��i�o�[�R�[�h��񒊏o�����擾
        /// </summary>
        /// <param name="selectParam">���o�p�����[�^</param>
        /// <param name="retCnt">���o����</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : ���o�p�����[�^�̏����ɍ��v����D�Ǖ��i�o�[�R�[�h�����擾�����ꍇ�̌������擾����</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        public int GetSearchCount( ref object selectParam, out int retCnt )
        {
            return this.GetSearchCountProc( selectParam, out retCnt );
        }

        /// <summary>
        /// �D�Ǖ��i�o�[�R�[�h��񒊏o
        /// </summary>
        /// <param name="selectParam">���o�p�����[�^</param>
        /// <param name="prmPartsBrcdInfoList">���o����</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : ���o�p�����[�^�̏����ɍ��v����D�Ǖ��i�o�[�R�[�h�����擾�擾����</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        public int Search( ref object selectParam, out object prmPartsBrcdInfoList )
        {
            return this.SearchProc( selectParam, out prmPartsBrcdInfoList );
        }

        #endregion //IOfferPrmPartsBrcdInfo �����o

        #region �v���C�x�[�g���\�b�h

        /// <summary>
        /// �D�Ǖ��i�o�[�R�[�h��񒊏o�����擾����
        /// </summary>
        /// <param name="selectParam">���o�p�����[�^</param>
        /// <param name="retCnt">���o����</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : ���o�p�����[�^�̏����ɍ��v����D�Ǖ��i�o�[�R�[�h�����擾�����ꍇ�̌������擾����</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private int GetSearchCountProc( object selectParam, out int retCnt )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string queryText = null;

            retCnt = -1;

            try
            {
                using(SqlConnection sqlConnection = this.CreateSqlConnection())
                {
                    if (sqlConnection == null)
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_OFFLINE;
                    }
                    sqlConnection.Open();
                    
                    try
                    {
                        using( SqlCommand sqlCommand = new SqlCommand(string.Empty, sqlConnection) )
                        {
                            try
                            {
                                //�N�G��������̐���
                                int funcResult = this.CreateGetSearchCountQuery( ref selectParam, sqlCommand , out queryText);
                                if ( funcResult != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                {
                                    return funcResult;
                                }
                                sqlCommand.CommandText = queryText;
                                sqlCommand.CommandTimeout = OfferPrmPartsBrcdInfoDB.SqlCommandTimeoutDefault;
                                
                                object ret = sqlCommand.ExecuteScalar();
                                int count = int.MinValue;
                                if (ret != null )
                                {
                                    int.TryParse( ret.ToString(), out count);
                                    retCnt = count;
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }
                                else
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                }
                            }
                            finally
                            {
                                if (sqlCommand != null)
                                    sqlCommand.Dispose();
                            }
                        }
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }

            }
            catch (SqlException sqlExp)
            {
                status = base.WriteSQLErrorLog( sqlExp );
            }
            catch (Exception exp)
            {
                base.WriteErrorLog( exp, OfferPrmPartsBrcdInfoDB.ErrorTextGetSearchCountFaild );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }


            return (int)status;
        }

        /// <summary>
        /// �D�Ǖ��i�o�[�R�[�h��񒊏o����
        /// </summary>
        /// <param name="selectParam">���o�p�����[�^</param>
        /// <param name="prmPartsBrcdInfoList">���o����</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : ���o�p�����[�^�̏����ɍ��v����D�Ǖ��i�o�[�R�[�h�����擾�擾����</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc( object selectParam, out object prmPartsBrcdInfoList )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string queryText = null;
            ArrayList execResultList = new ArrayList();

            prmPartsBrcdInfoList = null;

            try
            {
                using (SqlConnection sqlConnection = this.CreateSqlConnection())
                {
                    if (sqlConnection == null)
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_OFFLINE;
                    }
                    sqlConnection.Open();

                    try
                    {
                        using (SqlCommand sqlCommand = new SqlCommand( string.Empty, sqlConnection ))
                        {
                            try
                            {
                                //�N�G��������̐���
                                int funcResult = this.CreateSearchQuery( ref selectParam, sqlCommand, out queryText );
                                if (funcResult != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    return funcResult;
                                }
                                sqlCommand.CommandText = queryText;
                                sqlCommand.CommandTimeout = OfferPrmPartsBrcdInfoDB.SqlCommandTimeoutDefault;

                                SqlDataReader myReader = null;
                                try
                                {
                                    myReader = sqlCommand.ExecuteReader();

                                    while (myReader.Read())
                                    {
                                        RettPrmPartsBrcdInfoWork prmPartsBrcdInfoWork = this.CopyToPrmPartsBrcdInfoWorkFromDataReader( ref myReader );
                                        execResultList.Add( prmPartsBrcdInfoWork );
                                    }

                                    if (execResultList.Count <= 0)
                                    {
                                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                    }
                                    else
                                    {
                                        prmPartsBrcdInfoList = (object)execResultList;
                                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                    }
                                }
                                finally
                                {
                                    if ( myReader != null )
                                        myReader.Close();
                                }


                            }
                            finally
                            {
                                if (sqlCommand != null)
                                    sqlCommand.Dispose();
                            }
                        }
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }

            }
            catch (SqlException sqlExp)
            {
                status = base.WriteSQLErrorLog( sqlExp );
            }
            catch (Exception exp)
            {
                base.WriteErrorLog( exp, OfferPrmPartsBrcdInfoDB.ErrorTextSearchFaild );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (int)status;
        }

        /// <summary>
        /// �D�Ǖ��i�o�[�R�[�h��񒊏o�����擾�N�G������
        /// </summary>
        /// <param name="selectParam">���o�p�����[�^</param>
        /// <param name="sqlCommand">�D�Ǖ��i�o�[�R�[�h��񒊏o�����N�G�����s�p�I�u�W�F�N�g</param>
        /// <param name="queryText">�N�G��������i�[�I�u�W�F�N�g</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : �D�Ǖ��i�o�[�R�[�h��񒊏o�����擾���s���N�G���̐����y�уp�����[�^�̐ݒ�</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private int CreateGetSearchCountQuery( ref object selectParam, SqlCommand sqlCommand, out string queryText )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            StringBuilder queryStrings = new StringBuilder();

            queryText = null;

             //Select��AFrom��̃Z�b�g
            queryStrings.Append( OfferPrmPartsBrcdInfoDB.SelectCountQuery );
            queryStrings.Append( OfferPrmPartsBrcdInfoDB.FromQuery );

            //Where��̃Z�b�g
            this.AddWhereQuery( ref selectParam, sqlCommand, ref queryStrings );

            queryText = queryStrings.ToString();

            return status;
        }

        /// <summary>
        /// �D�Ǖ��i�o�[�R�[�h��񒊏o�N�G������
        /// </summary>
        /// <param name="selectParam">���o�p�����[�^</param>
        /// <param name="sqlCommand">�D�Ǖ��i�o�[�R�[�h��񒊏o�N�G�����s�p�I�u�W�F�N�g</param>
        /// <param name="queryText">�N�G��������i�[�I�u�W�F�N�g</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : �D�Ǖ��i�o�[�R�[�h��񒊏o���s���N�G���̐����y�уp�����[�^�̐ݒ�</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private int CreateSearchQuery( ref object selectParam, SqlCommand sqlCommand, out string queryText )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            StringBuilder queryStrings = new StringBuilder();

            queryText = null;

            //Select��AFrom��̃Z�b�g
            queryStrings.Append( OfferPrmPartsBrcdInfoDB.SelectQuery );
            queryStrings.Append( OfferPrmPartsBrcdInfoDB.FromQuery );

            //Where��̃Z�b�g
            this.AddWhereQuery( ref selectParam, sqlCommand, ref queryStrings );

            queryText = queryStrings.ToString();

            return status;
        }

        /// <summary>
        /// WHERE�吶��
        /// </summary>
        /// <param name="selectParam">���o�p�����[�^</param>
        /// <param name="sqlCommand">�N�G�����s�p�I�u�W�F�N�g</param>
        /// <param name="queryText">�N�G��������i�[�I�u�W�F�N�g</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : �D�Ǖ��i�o�[�R�[�h��񒊏o�p�y�їD�Ǖ��i�o�[�R�[�h��񒊏o�����擾�p�N�G�����AWHERE��̐����y�уp�����[�^�̐ݒ�</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private void AddWhereQuery( ref object selectParam, SqlCommand sqlCommand, ref StringBuilder queryText )
        {
            string whereString = OfferPrmPartsBrcdInfoDB.WhereSymbol;
            ArrayList paramList = selectParam as ArrayList;

            // �p�����[�^����̏ꍇ�AWHERE��͍��Ȃ�
            if ( paramList == null || paramList.Count <= 0 )
            {
                return;
            }

            foreach (object param in paramList)
            {
                GetPrmPartsBrcdParaWork paramWork = null;

                if (param == null || !( param is GetPrmPartsBrcdParaWork ))
                {
                    continue;
                }
                paramWork = param as GetPrmPartsBrcdParaWork;

                if (!string.IsNullOrEmpty( whereString ))
                {
                    //whereString�ɕ����񂪊܂܂�Ă���ꍇ�A�擪�̏����Ȃ̂�WHERE�������ǉ�
                    queryText.AppendLine( whereString );
                    whereString = string.Empty;

                    //�擪�̒��o������ǉ�
                    queryText.AppendFormat( OfferPrmPartsBrcdInfoDB.WhereFormatTop, paramWork.MakerCode, paramWork.BLGoodsCode );
                    queryText.AppendLine();
                }
                else
                {
                    //whereString�ɕ����񂪊܂܂�Ă��Ȃ��ꍇ�A�擪�ȍ~�̒��o������ǉ�
                    queryText.AppendFormat( OfferPrmPartsBrcdInfoDB.WhereFormat, paramWork.MakerCode, paramWork.BLGoodsCode );
                    queryText.AppendLine();
                }
            }
        }

        /// <summary>
        /// �D�Ǖ��i�o�[�R�[�h��񒊏o���ʃ��[�N�I�u�W�F�N�g�̐���
        /// </summary>
        /// <param name="myReader">�D�Ǖ��i�o�[�R�[�h��񒊏o���ʂ̃f�[�^�X�g���[��</param>
        /// <returns>�D�Ǖ��i�o�[�R�[�h��񒊏o���ʃ��[�N</returns>
        /// <remarks>
        /// <br>Note       : �D�Ǖ��i�o�[�R�[�h��񒊏o�N�G�������s���ē����f�[�^�X�g���[���̌��݈ʒu�̃��R�[�h���猋�ʃ��[�N�I�u�W�F�N�g�𐶐�</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private RettPrmPartsBrcdInfoWork CopyToPrmPartsBrcdInfoWorkFromDataReader( ref SqlDataReader myReader )
        {
            RettPrmPartsBrcdInfoWork prmPartsBrcdInfoWork = new RettPrmPartsBrcdInfoWork();
            prmPartsBrcdInfoWork.OfferDate = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "OFFERDATERF" ) );  // �񋟓��t
            prmPartsBrcdInfoWork.PartsMakerCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PARTSMAKERCODERF" ) );  // ���i���[�J�[�R�[�h
            prmPartsBrcdInfoWork.TbsPartsCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "TBSPARTSCODERF" ) );  // BL���i�R�[�h
            prmPartsBrcdInfoWork.PrimePartsNoWithH = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRIMEPARTSNOWITHHRF" ) );  // �D�Ǖi��(�|�t���i��)
            prmPartsBrcdInfoWork.PrimePrtsBarCdKndDiv = SqlDataMediator.SqlGetInt16( myReader, myReader.GetOrdinal( "PRIMEPRTSBARCDKNDDIVRF" ) );  // ���i�o�[�R�[�h���
            prmPartsBrcdInfoWork.PrimePartsBarCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRIMEPARTSBARCODERF" ) );  // ���i�o�[�R�[�h���
            return prmPartsBrcdInfoWork;
        }

        /// <summary>
        /// SQL Server�f�[�^�x�[�X�ڑ���񏈗�
        /// </summary>
        /// <returns>SQL Server�f�[�^�x�[�X�Ƃ̐ڑ����</returns>
        /// <remarks>
        /// <br>Note       : SQL Server�f�[�^�x�[�X�ւ̊J�����ڑ������擾����</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo( ConstantManagement_SF_PRO.IndexCode_OfferDB );
            if (string.IsNullOrEmpty( connectionText ))
                return null;

            retSqlConnection = new SqlConnection( connectionText );

            return retSqlConnection;
        }

        #endregion �v���C�x�[�g���\�b�h

    }
}
