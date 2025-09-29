using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���R���[(����`�[)�񋟃����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
    /// <br>Note         : ���R���[(����`�[)�Ɋւ���񋟃f�[�^�̌������s���N���X�ł��B</br>
	/// <br>Programmer   : 22018 ��� ���b</br>
	/// <br>Date         : 2008.06.06</br>
	/// <br></br>
	/// <br>UpdateNote   : </br>
	/// </remarks>
	[Serializable]
    public class FrePSalesSlipOfferDB : RemoteDB, IFrePSalesSlipOfferDB
	{
		#region Constructor
		/// <summary>
		/// ���R���[(����`�[)�񋟃����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note		: DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
		/// <br>Programmer	: 22018 ��� ���b</br>
		/// <br>Date		: 2007.05.07</br>
		/// </remarks>
		public FrePSalesSlipOfferDB()
            : base( "PMTKD08006D", "", "" )
		{
		}
		#endregion

        #region IFrePSalesSlipOfferDB �����o
        /// <summary>
		/// ���R���[(����`�[)�񋟌�������
		/// </summary>
		/// <param name="retCustomSerializeArrayList">�󎚍��ڏ��J�X�^���V���A���C�YLIST</param>
		/// <param name="msgDiv">���b�Z�[�W�敪</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ���R���[���ڐݒ�}�X�^�z����擾���܂��B</br>
		/// <br>Programmer	: 22018 ��� ���b</br>
		/// <br>Date		: 2007.05.07</br>
		/// </remarks>
        public int SearchFrePSalesSlipOffer( ref object retCustomSerializeArrayList, out bool msgDiv, out string errMsg )
        {
            return SearchFrePSalesSlipOfferProc( ref retCustomSerializeArrayList, out msgDiv, out errMsg );
        }
        /// <summary>
        /// ���R���[(����`�[)�񋟌�������
        /// </summary>
        /// <param name="retCustomSerializeArrayList">�󎚍��ڏ��J�X�^���V���A���C�YLIST</param>
        /// <param name="msgDiv">���b�Z�[�W�敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int SearchFrePSalesSlipOfferProc( ref object retCustomSerializeArrayList, out bool msgDiv, out string errMsg )
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            msgDiv = false;
            errMsg = string.Empty;

			SqlConnection sqlConnection = null;
			try
			{
                CustomSerializeArrayList retWork = (CustomSerializeArrayList)retCustomSerializeArrayList;

				//SQL������
				using (sqlConnection = CreateSqlConnection())
				{
					sqlConnection.Open();

                    status = SearchProc( ref retWork, ref sqlConnection );
                    if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                    {
                        retWork = new CustomSerializeArrayList();
                    }
				}
			}
			catch (SqlException ex)
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex, "PrtItemSetDB.SearchPrtItemSet", status);
				if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
				{
					msgDiv = true;
					errMsg = "���R���[(����`�[)�񋟌������Ƀ^�C���A�E�g���������܂����B";
				}
				else
				{
					errMsg = ex.Message;
				}
			}
			catch (Exception ex)
			{
				base.WriteErrorLog(ex, "PrtItemSetDB.SearchPrtItemSet", (int)ConstantManagement.MethodResult.ctFNC_ERROR);
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
			finally
			{
				if (sqlConnection != null) sqlConnection.Close();
			}

			return status;
		}

		#endregion

		#region PrivateMethod
		/// <summary>
		/// ���R���[(����`�[)�񋟌��������i���C�����j
		/// </summary>
        /// <param name="frePSalesSlipOfferWork"></param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ���R���[���ڐݒ�}�X�^LIST���擾���܂��B</br>
		/// <br>Programmer	: 22018 ��� ���b</br>
		/// <br>Date		: 2007.05.07</br>
		/// </remarks>
        public int SearchProc( ref CustomSerializeArrayList frePSalesSlipOfferWork, ref SqlConnection sqlConnection )
        {
            return SearchProcProc( ref frePSalesSlipOfferWork, ref sqlConnection );
        }
        /// <summary>
        /// ���R���[(����`�[)�񋟌��������i���C�����j
        /// </summary>
        /// <param name="frePSalesSlipOfferWork"></param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        private int SearchProcProc( ref CustomSerializeArrayList frePSalesSlipOfferWork, ref SqlConnection sqlConnection )
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            CustomSerializeArrayList retWork = new CustomSerializeArrayList();

            foreach ( object obj in frePSalesSlipOfferWork )
            {
                if ( obj is TbsPartsCodeWork[] )
                {
                    //----------------------------------------------------
                    // �a�k�R�[�h�i�񋟁j
                    //----------------------------------------------------
                    TbsPartsCodeWork[] retTbsPartsCodeWorks;
                    SearchTbsPartsCode( (obj as TbsPartsCodeWork[]), out retTbsPartsCodeWorks, ref sqlConnection );
                    
                    retWork.Add( retTbsPartsCodeWorks );

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else if ( obj is PMakerNmWork[] )
                {
                    //----------------------------------------------------
                    // ���i���[�J�[�i�񋟁j
                    //----------------------------------------------------
                    PMakerNmWork[] retPMakerNmWorks;
                    SearchPMakerNm( (obj as PMakerNmWork[]), out retPMakerNmWorks, ref sqlConnection );

                    retWork.Add( retPMakerNmWorks );

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }

            frePSalesSlipOfferWork = retWork;

			return status;
        }

        # region [Search �a�k�R�[�h�}�X�^��]
        /// <summary>
        /// Search �a�k�R�[�h�}�X�^��
        /// </summary>
        /// <param name="paraWorks"></param>
        /// <param name="retWorks"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchTbsPartsCode( TbsPartsCodeWork[] paraWorks, out TbsPartsCodeWork[] retWorks, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            retWorks = new TbsPartsCodeWork[0];

            try
            {
                List<TbsPartsCodeWork> retList = new List<TbsPartsCodeWork>();

                //Select�R�}���h�̐���
                SqlCommand sqlCommand;

                sqlCommand = new SqlCommand( "SELECT TBSPARTSCODERF, TBSPARTSFULLNAMERF, TBSPARTSHALFNAMERF FROM TBSPARTSCODERF ", sqlConnection );
                sqlCommand.CommandText += MakeWhereStringForTbsPartsCode( ref sqlCommand, paraWorks );

                // �^�C���A�E�g���Ԑݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut( RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInitial );

                myReader = sqlCommand.ExecuteReader();
                while ( myReader.Read() )
                {
                    TbsPartsCodeWork work = new TbsPartsCodeWork();
                    work.TbsPartsCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "TBSPARTSCODERF" ) );
                    work.TbsPartsFullName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "TBSPARTSFULLNAMERF" ) );
                    work.TbsPartsHalfName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "TBSPARTSHALFNAMERF" ) );
                    retList.Add( work );
                }
                if ( retList.Count > 0 )
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    retWorks = retList.ToArray();
                }
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                }
			}

            return status;
        }

        /// <summary>
        /// WHERE�吶������
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="paraWorks"></param>
        /// <returns></returns>
        private string MakeWhereStringForTbsPartsCode( ref SqlCommand sqlCommand, TbsPartsCodeWork[] paraWorks )
        {
            StringBuilder whereString = new StringBuilder();

            // TbsParts�R�[�h
            List<SqlParameter> paraList = new List<SqlParameter>();

            whereString.Append( " WHERE TBSPARTSCODERF IN ( " );
            for ( int index = 0; index < paraWorks.Length; index++ )
            {
                if ( index != 0 )
                {
                    whereString.Append( "," );
                }
                whereString.Append( string.Format("@FINDTBSPARTSCODE{0}",index));
                SqlParameter newPara = sqlCommand.Parameters.Add( string.Format( "@FINDTBSPARTSCODE{0}", index ), SqlDbType.Int );
                newPara.Value = paraWorks[index].TbsPartsCode;
                paraList.Add( newPara );
            }
            whereString.Append( " ) " );
            return whereString.ToString();
        }
        # endregion

        # region [Search ���i���[�J�[���̃}�X�^��]
        /// <summary>
        /// Search ���i���[�J�[���̃}�X�^��
        /// </summary>
        /// <param name="paraWorks"></param>
        /// <param name="retWorks"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchPMakerNm( PMakerNmWork[] paraWorks, out PMakerNmWork[] retWorks, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            retWorks = new PMakerNmWork[0];

            try
            {
                List<PMakerNmWork> retList = new List<PMakerNmWork>();

                //Select�R�}���h�̐���
                SqlCommand sqlCommand;

                sqlCommand = new SqlCommand( "SELECT PARTSMAKERCODERF, PARTSMAKERFULLNAMERF, PARTSMAKERHALFNAMERF FROM PMAKERNMRF ", sqlConnection );
                sqlCommand.CommandText += MakeWhereStringForPMakerNm( ref sqlCommand, paraWorks );

                // �^�C���A�E�g���Ԑݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut( RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInitial );

                myReader = sqlCommand.ExecuteReader();
                while ( myReader.Read() )
                {
                    PMakerNmWork work = new PMakerNmWork();
                    work.PartsMakerCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PARTSMAKERCODERF" ) );
                    work.PartsMakerFullName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PARTSMAKERFULLNAMERF" ) );
                    work.PartsMakerHalfName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PARTSMAKERHALFNAMERF" ) );
                    retList.Add( work );
                }
                if ( retList.Count > 0 )
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    retWorks = retList.ToArray();
                }
            }
            finally
            {
                if ( myReader != null )
                {
                    if ( !myReader.IsClosed ) myReader.Close();
                }
            }

            return status;
        }

        /// <summary>
        /// WHERE�吶������
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="paraWorks"></param>
        /// <returns></returns>
        private string MakeWhereStringForPMakerNm( ref SqlCommand sqlCommand, PMakerNmWork[] paraWorks )
        {
            StringBuilder whereString = new StringBuilder();

            // TbsParts�R�[�h
            List<SqlParameter> paraList = new List<SqlParameter>();

            whereString.Append( " WHERE PARTSMAKERCODERF IN ( " );
            for ( int index = 0; index < paraWorks.Length; index++ )
            {
                if ( index != 0 )
                {
                    whereString.Append( "," );
                }
                whereString.Append( string.Format( "@FINDPARTSMAKERCODE{0}", index ) );
                SqlParameter newPara = sqlCommand.Parameters.Add( string.Format( "@FINDPARTSMAKERCODE{0}", index ), SqlDbType.Int );
                newPara.Value = paraWorks[index].PartsMakerCode;
                paraList.Add( newPara );
            }
            whereString.Append( " ) " );
            return whereString.ToString();
        }
        # endregion


        /// <summary>
		/// �R�l�N�V������񐶐�
		/// </summary>
		/// <returns>�R�l�N�V�������</returns>
		private SqlConnection CreateSqlConnection()
		{
			SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
			string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
			if (connectionText == null || connectionText == "") return null;

			return new SqlConnection(connectionText);
		}
		#endregion
	}
}
