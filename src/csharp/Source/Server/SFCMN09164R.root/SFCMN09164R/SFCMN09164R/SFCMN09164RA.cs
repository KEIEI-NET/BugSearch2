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
	/// �S�̍��ڕ\������DB�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : �S�̍��ڕ\�����̂̎��f�[�^������s���N���X�ł��B</br>
	/// <br>Programmer : 90027�@�����@��</br>
	/// <br>Date       : 2006.08.28</br>
    /// <br></br>
    /// <br>Update Note: 2008.05.26  20081 �D�c �E�l</br>
    /// <br>             �o�l.�m�r�p�ɕύX</br>
	/// </remarks>
	[Serializable]
	public class AlItmDspNmDB : RemoteDB , IAlItmDspNmDB
	{

		/// <summary>
		/// �S�̍��ڕ\������DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		/// </remarks>
		public AlItmDspNmDB() :
		base("SFCMN09166D", "Broadleaf.Application.Remoting.ParamData.AlItmDspNmWork", "ALITMDSPNMRF") //���N���X�̃R���X�g���N�^
		{
        }

        #region �m���J�X�^���V���A���C�Y
        /// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\������LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="parabyte">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\������LIST��S�Ė߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		public int Search(out byte[] retbyte,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{		
			try
			{
				bool nextData;
				int retTotalCnt;
				return SearchProc(out retbyte,out retTotalCnt,out nextData,parabyte ,readMode,logicalMode,0);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog( ex , "Search(out byte[] retbyte,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)" );
				retbyte = new byte[0];
				return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
		}


		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\������LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>		
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="parabyte">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\������LIST��S�Ė߂��܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		private int SearchProc(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			AlItmDspNmWork alitmdspnmWork = new AlItmDspNmWork();
			alitmdspnmWork = null;

			retbyte = null;

			//��������0�ŏ�����
			retTotalCnt = 0;

			//�����w�胊�[�h�̏ꍇ�ɂ͎w�茏���{�P�����[�h����
			int _readCnt = readCnt;			
			if (_readCnt > 0) _readCnt += 1;
			//�����R�[�h�����ŏ�����
			nextData = false;

			ArrayList al = new ArrayList();
            string sqlTxt = string.Empty; // 2008.05.26 add
			try 
			{	
				//���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				alitmdspnmWork = (AlItmDspNmWork)XmlByteSerializer.Deserialize(parabyte,typeof(AlItmDspNmWork));

				//SQL������
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();				


				SqlCommand sqlCommand;

				//�f�[�^�Ǎ�
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
                    // 2008.05.26 upd start ----------------------------------------->>
					//sqlCommand = new SqlCommand("SELECT * FROM ALITMDSPNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE",sqlConnection);
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,MOBILETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OTHERTELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO1DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO2DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO3DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,JOINDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,STOCKRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,UNITCOSTDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OUTTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,INTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,LISTPRICEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,DELIHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,BILLHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,ESTMHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,RECTHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += " FROM ALITMDSPNMRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.26 upd end -------------------------------------------<<

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
                    // 2008.05.26 upd start ----------------------------------------->>
					//sqlCommand = new SqlCommand("SELECT * FROM ALITMDSPNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE",sqlConnection);
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,MOBILETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OTHERTELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO1DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO2DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO3DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,JOINDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,STOCKRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,UNITCOSTDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OUTTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,INTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,LISTPRICEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,DELIHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,BILLHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,ESTMHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,RECTHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += " FROM ALITMDSPNMRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.26 upd end -------------------------------------------<<

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else
				{
                    // 2008.05.26 upd start ----------------------------------------->>
					//sqlCommand = new SqlCommand("SELECT * FROM ALITMDSPNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",sqlConnection);
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,MOBILETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OTHERTELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO1DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO2DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO3DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,JOINDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,STOCKRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,UNITCOSTDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OUTTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,INTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,LISTPRICEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,DELIHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,BILLHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,ESTMHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,RECTHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += " FROM ALITMDSPNMRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.26 upd end -------------------------------------------<<
				}
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.EnterpriseCode);

				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                int retCnt = 0;
				while(myReader.Read())
				{
					//�߂�l�J�E���^�J�E���g
					retCnt += 1;
					if (readCnt > 0)
					{
						//�߂�l�̌������擾�w�������𒴂����ꍇ�I��
						if (readCnt < retCnt) 
						{
							nextData = true;
							break;
						}
					}
					AlItmDspNmWork wkAlItmDspNmWork = new AlItmDspNmWork();

					wkAlItmDspNmWork.CreateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					wkAlItmDspNmWork.UpdateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					wkAlItmDspNmWork.EnterpriseCode     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					wkAlItmDspNmWork.FileHeaderGuid     = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					wkAlItmDspNmWork.UpdEmployeeCode    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					wkAlItmDspNmWork.UpdAssemblyId1     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					wkAlItmDspNmWork.UpdAssemblyId2     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					wkAlItmDspNmWork.LogicalDeleteCode  = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                    //wkAlItmDspNmWork.DspNameManageNo    = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DSPNAMEMANAGENORF"));   // 2008.05.26 del
                    wkAlItmDspNmWork.HomeTelNoDspName   = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("HOMETELNODSPNAMERF"));
                    wkAlItmDspNmWork.OfficeTelNoDspName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("OFFICETELNODSPNAMERF"));
                    wkAlItmDspNmWork.MobileTelNoDspName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MOBILETELNODSPNAMERF"));
                    wkAlItmDspNmWork.OtherTelNoDspName  = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("OTHERTELNODSPNAMERF"));
                    wkAlItmDspNmWork.HomeFaxNoDspName   = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("HOMEFAXNODSPNAMERF"));
                    wkAlItmDspNmWork.OfficeFaxNoDspName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("OFFICEFAXNODSPNAMERF"));
                    wkAlItmDspNmWork.AddInfo1DspName    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDINFO1DSPNAMERF"));
                    wkAlItmDspNmWork.AddInfo2DspName    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDINFO2DSPNAMERF"));
                    wkAlItmDspNmWork.AddInfo3DspName    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDINFO3DSPNAMERF"));
                    // 2008.05.26 add start --------------------------------------------->>
                    wkAlItmDspNmWork.JoinDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDSPNAMERF"));
                    wkAlItmDspNmWork.StockRateDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKRATEDSPNAMERF"));
                    wkAlItmDspNmWork.UnitCostDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITCOSTDSPNAMERF"));
                    wkAlItmDspNmWork.ProfitDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PROFITDSPNAMERF"));
                    wkAlItmDspNmWork.ProfitRateDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PROFITRATEDSPNAMERF"));
                    wkAlItmDspNmWork.OutTaxDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTTAXDSPNAMERF"));
                    wkAlItmDspNmWork.InTaxDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INTAXDSPNAMERF"));
                    wkAlItmDspNmWork.ListPriceDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LISTPRICEDSPNAMERF"));
                    wkAlItmDspNmWork.DeliHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIHONORTTLDEFRF"));
                    wkAlItmDspNmWork.BillHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLHONORTTLDEFRF"));
                    wkAlItmDspNmWork.EstmHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTMHONORTTLDEFRF"));
                    wkAlItmDspNmWork.RectHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECTHONORTTLDEFRF"));
                    // 2008.05.26 add end -----------------------------------------------<<

					al.Add(wkAlItmDspNmWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}

			if(!myReader.IsClosed)myReader.Close();
			sqlConnection.Close();

			// XML�֕ϊ����A������̃o�C�i����
			AlItmDspNmWork[] AlItmDspNmWorks = (AlItmDspNmWork[])al.ToArray(typeof(AlItmDspNmWork));
			retbyte = XmlByteSerializer.Serialize(AlItmDspNmWorks);

			return status;

		}
		

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\�����̂�߂��܂�
		/// </summary>
		/// <param name="parabyte">AlItmDspNmWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\�����̂�߂��܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		public int Read(ref byte[] parabyte , int readMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			try
			{
				SqlConnection sqlConnection = null;
				SqlDataReader myReader = null;

				AlItmDspNmWork alitmdspnmWork = new AlItmDspNmWork();
                string sqlTxt = string.Empty;   // 2008.05.26 add

				try 
				{			
					//���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
					SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
					string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
					if (connectionText == null || connectionText == "") return status;

					// XML�̓ǂݍ���
					alitmdspnmWork = (AlItmDspNmWork)XmlByteSerializer.Deserialize(parabyte,typeof(AlItmDspNmWork));

					sqlConnection = new SqlConnection(connectionText);
					sqlConnection.Open();

					//Select�R�}���h�̐���
                    // 2008.05.26 upd start ----------------------------------------------------->>
					//using(SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ALITMDSPNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DSPNAMEMANAGENORF=0", sqlConnection))
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,MOBILETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OTHERTELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO1DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO2DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO3DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,JOINDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,STOCKRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,UNITCOSTDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OUTTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,INTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,LISTPRICEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,DELIHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,BILLHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,ESTMHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,RECTHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += " FROM ALITMDSPNMRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                    // 2008.05.26 upd end -------------------------------------------------------<<
                    {
						//Prameter�I�u�W�F�N�g�̍쐬
						SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

						//Parameter�I�u�W�F�N�g�֒l�ݒ�
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.EnterpriseCode);

						myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
						if(myReader.Read())
						{
					        alitmdspnmWork.CreateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					        alitmdspnmWork.UpdateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					        alitmdspnmWork.EnterpriseCode     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					        alitmdspnmWork.FileHeaderGuid     = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					        alitmdspnmWork.UpdEmployeeCode    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					        alitmdspnmWork.UpdAssemblyId1     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					        alitmdspnmWork.UpdAssemblyId2     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					        alitmdspnmWork.LogicalDeleteCode  = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                            //alitmdspnmWork.DspNameManageNo    = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DSPNAMEMANAGENORF"));   // 2008.05.26 del
                            alitmdspnmWork.HomeTelNoDspName   = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("HOMETELNODSPNAMERF"));
                            alitmdspnmWork.OfficeTelNoDspName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("OFFICETELNODSPNAMERF"));
                            alitmdspnmWork.MobileTelNoDspName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MOBILETELNODSPNAMERF"));
                            alitmdspnmWork.OtherTelNoDspName  = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("OTHERTELNODSPNAMERF"));
                            alitmdspnmWork.HomeFaxNoDspName   = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("HOMEFAXNODSPNAMERF"));
                            alitmdspnmWork.OfficeFaxNoDspName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("OFFICEFAXNODSPNAMERF"));
                            alitmdspnmWork.AddInfo1DspName    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDINFO1DSPNAMERF"));
                            alitmdspnmWork.AddInfo2DspName    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDINFO2DSPNAMERF"));
                            alitmdspnmWork.AddInfo3DspName    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDINFO3DSPNAMERF"));
                            // 2008.05.26 add start --------------------------------------------->>
                            alitmdspnmWork.JoinDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDSPNAMERF"));
                            alitmdspnmWork.StockRateDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKRATEDSPNAMERF"));
                            alitmdspnmWork.UnitCostDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITCOSTDSPNAMERF"));
                            alitmdspnmWork.ProfitDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PROFITDSPNAMERF"));
                            alitmdspnmWork.ProfitRateDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PROFITRATEDSPNAMERF"));
                            alitmdspnmWork.OutTaxDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTTAXDSPNAMERF"));
                            alitmdspnmWork.InTaxDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INTAXDSPNAMERF"));
                            alitmdspnmWork.ListPriceDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LISTPRICEDSPNAMERF"));
                            alitmdspnmWork.DeliHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIHONORTTLDEFRF"));
                            alitmdspnmWork.BillHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLHONORTTLDEFRF"));
                            alitmdspnmWork.EstmHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTMHONORTTLDEFRF"));
                            alitmdspnmWork.RectHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECTHONORTTLDEFRF"));
                            // 2008.05.26 add end -----------------------------------------------<<

							status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
						}
					}
				}
				catch (SqlException ex) 
				{
					//���N���X�ɗ�O��n���ď������Ă��炤
					status = base.WriteSQLErrorLog(ex);
                }

				if(!myReader.IsClosed)myReader.Close();
				sqlConnection.Close();

				// XML�֕ϊ����A������̃o�C�i����
				parabyte = XmlByteSerializer.Serialize(alitmdspnmWork);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog( ex , "AlItmDspNmDB.Read(ref byte[] parabyte , int readMode)" );
			}
			return status;
		}


		/// <summary>
		/// �S�̍��ڕ\�����̏���o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">AlItmDspNmWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �S�̍��ڕ\�����̏���o�^�A�X�V���܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		public int Write(ref byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			try
			{
				SqlConnection sqlConnection = null;
				SqlDataReader myReader = null;
                string sqlTxt = string.Empty;   // 2008.05.26 add
				try 
				{
					//���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
					SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
					string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
					if (connectionText == null || connectionText == "") return status;

					// XML�̓ǂݍ���
					AlItmDspNmWork alitmdspnmWork = (AlItmDspNmWork)XmlByteSerializer.Deserialize(parabyte,typeof(AlItmDspNmWork));

					sqlConnection = new SqlConnection(connectionText);
					sqlConnection.Open();

					//Select�R�}���h�̐���
                    // 2008.05.26 upd start ------------------------------------------->>
					//using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, DSPNAMEMANAGENORF   FROM ALITMDSPNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DSPNAMEMANAGENORF=0", sqlConnection))
                    sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += " FROM ALITMDSPNMRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))    
                    // 2008.05.26 upd end ---------------------------------------------<<
                    {
						//Prameter�I�u�W�F�N�g�̍쐬
						SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

						//Parameter�I�u�W�F�N�g�֒l�ݒ�
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.EnterpriseCode);

						myReader = sqlCommand.ExecuteReader();
						if(myReader.Read())
						{
							//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
							DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
							if (_updateDateTime != alitmdspnmWork.UpdateDateTime)
							{
								//�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
								if (alitmdspnmWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
									//�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
								else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
								sqlCommand.Cancel();
								if(!myReader.IsClosed)myReader.Close();
								sqlConnection.Close();
								return status;
							}

                            // 2008.05.26 upd start ------------------------------------>>
                            //sqlCommand.CommandText = "UPDATE ALITMDSPNMRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , DSPNAMEMANAGENORF=@DSPNAMEMANAGENO,HOMETELNODSPNAMERF=@HOMETELNODSPNAME,OFFICETELNODSPNAMERF=@OFFICETELNODSPNAME,MOBILETELNODSPNAMERF=@MOBILETELNODSPNAME,OTHERTELNODSPNAMERF=@OTHERTELNODSPNAME,HOMEFAXNODSPNAMERF=@HOMEFAXNODSPNAME,OFFICEFAXNODSPNAMERF=@OFFICEFAXNODSPNAME,ADDINFO1DSPNAMERF=@ADDINFO1DSPNAME,ADDINFO2DSPNAMERF=@ADDINFO2DSPNAME,ADDINFO3DSPNAMERF=@ADDINFO3DSPNAME     WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DSPNAMEMANAGENORF=0";
                            sqlTxt = string.Empty;
                            sqlTxt += "UPDATE ALITMDSPNMRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " , HOMETELNODSPNAMERF=@HOMETELNODSPNAME" + Environment.NewLine;
                            sqlTxt += " , OFFICETELNODSPNAMERF=@OFFICETELNODSPNAME" + Environment.NewLine;
                            sqlTxt += " , MOBILETELNODSPNAMERF=@MOBILETELNODSPNAME" + Environment.NewLine;
                            sqlTxt += " , OTHERTELNODSPNAMERF=@OTHERTELNODSPNAME" + Environment.NewLine;
                            sqlTxt += " , HOMEFAXNODSPNAMERF=@HOMEFAXNODSPNAME" + Environment.NewLine;
                            sqlTxt += " , OFFICEFAXNODSPNAMERF=@OFFICEFAXNODSPNAME" + Environment.NewLine;
                            sqlTxt += " , ADDINFO1DSPNAMERF=@ADDINFO1DSPNAME" + Environment.NewLine;
                            sqlTxt += " , ADDINFO2DSPNAMERF=@ADDINFO2DSPNAME" + Environment.NewLine;
                            sqlTxt += " , ADDINFO3DSPNAMERF=@ADDINFO3DSPNAME" + Environment.NewLine;
                            sqlTxt += " , JOINDSPNAMERF=@JOINDSPNAME" + Environment.NewLine;
                            sqlTxt += " , STOCKRATEDSPNAMERF=@STOCKRATEDSPNAME" + Environment.NewLine;
                            sqlTxt += " , UNITCOSTDSPNAMERF=@UNITCOSTDSPNAME" + Environment.NewLine;
                            sqlTxt += " , PROFITDSPNAMERF=@PROFITDSPNAME" + Environment.NewLine;
                            sqlTxt += " , PROFITRATEDSPNAMERF=@PROFITRATEDSPNAME" + Environment.NewLine;
                            sqlTxt += " , OUTTAXDSPNAMERF=@OUTTAXDSPNAME" + Environment.NewLine;
                            sqlTxt += " , INTAXDSPNAMERF=@INTAXDSPNAME" + Environment.NewLine;
                            sqlTxt += " , LISTPRICEDSPNAMERF=@LISTPRICEDSPNAME" + Environment.NewLine;
                            sqlTxt += " , DELIHONORTTLDEFRF=@DELIHONORTTLDEF" + Environment.NewLine;
                            sqlTxt += " , BILLHONORTTLDEFRF=@BILLHONORTTLDEF" + Environment.NewLine;
                            sqlTxt += " , ESTMHONORTTLDEFRF=@ESTMHONORTTLDEF" + Environment.NewLine;
                            sqlTxt += " , RECTHONORTTLDEFRF=@RECTHONORTTLDEF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            // 2008.05.26 upd end --------------------------------------<<
                            
                            //KEY�R�}���h���Đݒ�
							findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.EnterpriseCode);

							//�X�V�w�b�_����ݒ�
							object obj = (object)this;
							IFileHeader flhd = (IFileHeader)alitmdspnmWork;
							FileHeader fileHeader = new FileHeader(obj);
							fileHeader.SetUpdateHeader(ref flhd,obj);
						}
						else
						{
							//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
							if (alitmdspnmWork.UpdateDateTime > DateTime.MinValue)
							{
								status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
								sqlCommand.Cancel();
								if(!myReader.IsClosed)myReader.Close();
								sqlConnection.Close();
								return status;
							}

							//�V�K�쐬����SQL���𐶐�
                            // 2008.05.26 upd start --------------------------------->>
							//sqlCommand.CommandText = "INSERT INTO ALITMDSPNMRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, DSPNAMEMANAGENORF,HOMETELNODSPNAMERF,OFFICETELNODSPNAMERF,MOBILETELNODSPNAMERF,OTHERTELNODSPNAMERF,HOMEFAXNODSPNAMERF,OFFICEFAXNODSPNAMERF,ADDINFO1DSPNAMERF,ADDINFO2DSPNAMERF,ADDINFO3DSPNAMERF  ) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @DSPNAMEMANAGENO,@HOMETELNODSPNAME,@OFFICETELNODSPNAME,@MOBILETELNODSPNAME,@OTHERTELNODSPNAME,@HOMEFAXNODSPNAME,@OFFICEFAXNODSPNAME,@ADDINFO1DSPNAME,@ADDINFO2DSPNAME,@ADDINFO3DSPNAME  )";
                            sqlTxt = string.Empty;
                            sqlTxt += "INSERT INTO ALITMDSPNMRF" + Environment.NewLine;
                            sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,HOMETELNODSPNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,OFFICETELNODSPNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,MOBILETELNODSPNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,OTHERTELNODSPNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,HOMEFAXNODSPNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,OFFICEFAXNODSPNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,ADDINFO1DSPNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,ADDINFO2DSPNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,ADDINFO3DSPNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,JOINDSPNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,STOCKRATEDSPNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,UNITCOSTDSPNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,PROFITDSPNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,PROFITRATEDSPNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,OUTTAXDSPNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,INTAXDSPNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,LISTPRICEDSPNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,DELIHONORTTLDEFRF" + Environment.NewLine;
                            sqlTxt += "    ,BILLHONORTTLDEFRF" + Environment.NewLine;
                            sqlTxt += "    ,ESTMHONORTTLDEFRF" + Environment.NewLine;
                            sqlTxt += "    ,RECTHONORTTLDEFRF" + Environment.NewLine;
                            sqlTxt += " )" + Environment.NewLine;
                            sqlTxt += " VALUES" + Environment.NewLine;
                            sqlTxt += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlTxt += "    ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += "    ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlTxt += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += "    ,@HOMETELNODSPNAME" + Environment.NewLine;
                            sqlTxt += "    ,@OFFICETELNODSPNAME" + Environment.NewLine;
                            sqlTxt += "    ,@MOBILETELNODSPNAME" + Environment.NewLine;
                            sqlTxt += "    ,@OTHERTELNODSPNAME" + Environment.NewLine;
                            sqlTxt += "    ,@HOMEFAXNODSPNAME" + Environment.NewLine;
                            sqlTxt += "    ,@OFFICEFAXNODSPNAME" + Environment.NewLine;
                            sqlTxt += "    ,@ADDINFO1DSPNAME" + Environment.NewLine;
                            sqlTxt += "    ,@ADDINFO2DSPNAME" + Environment.NewLine;
                            sqlTxt += "    ,@ADDINFO3DSPNAME" + Environment.NewLine;
                            sqlTxt += "    ,@JOINDSPNAME" + Environment.NewLine;
                            sqlTxt += "    ,@STOCKRATEDSPNAME" + Environment.NewLine;
                            sqlTxt += "    ,@UNITCOSTDSPNAME" + Environment.NewLine;
                            sqlTxt += "    ,@PROFITDSPNAME" + Environment.NewLine;
                            sqlTxt += "    ,@PROFITRATEDSPNAME" + Environment.NewLine;
                            sqlTxt += "    ,@OUTTAXDSPNAME" + Environment.NewLine;
                            sqlTxt += "    ,@INTAXDSPNAME" + Environment.NewLine;
                            sqlTxt += "    ,@LISTPRICEDSPNAME" + Environment.NewLine;
                            sqlTxt += "    ,@DELIHONORTTLDEF" + Environment.NewLine;
                            sqlTxt += "    ,@BILLHONORTTLDEF" + Environment.NewLine;
                            sqlTxt += "    ,@ESTMHONORTTLDEF" + Environment.NewLine;
                            sqlTxt += "    ,@RECTHONORTTLDEF" + Environment.NewLine;
                            sqlTxt += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            // 2008.05.26 upd end -----------------------------------<<
                            //�o�^�w�b�_����ݒ�
							object obj = (object)this;
							IFileHeader flhd = (IFileHeader)alitmdspnmWork;
							FileHeader fileHeader = new FileHeader(obj);
							fileHeader.SetInsertHeader(ref flhd,obj);
						}
						if(!myReader.IsClosed)myReader.Close();

						//Prameter�I�u�W�F�N�g�̍쐬
						SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
						SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
						SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
						SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
						SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
						SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
						SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
						SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                        //SqlParameter paraDspNameManageNo = sqlCommand.Parameters.Add("@DSPNAMEMANAGENO", SqlDbType.Int);     // 2008.05.26 del
                        SqlParameter paraHomeTelNoDspName = sqlCommand.Parameters.Add("@HOMETELNODSPNAME", SqlDbType.NVarChar);
                        SqlParameter paraOfficeTelNoDspName = sqlCommand.Parameters.Add("@OFFICETELNODSPNAME", SqlDbType.NVarChar);
                        SqlParameter paraMobileTelNoDspName = sqlCommand.Parameters.Add("@MOBILETELNODSPNAME", SqlDbType.NVarChar);
                        SqlParameter paraOtherTelNoDspName = sqlCommand.Parameters.Add("@OTHERTELNODSPNAME", SqlDbType.NVarChar);
                        SqlParameter paraHomeFaxNoDspName = sqlCommand.Parameters.Add("@HOMEFAXNODSPNAME", SqlDbType.NVarChar);
                        SqlParameter paraOfficeFaxNoDspName = sqlCommand.Parameters.Add("@OFFICEFAXNODSPNAME", SqlDbType.NVarChar);
                        SqlParameter paraAddInfo1DspName = sqlCommand.Parameters.Add("@ADDINFO1DSPNAME", SqlDbType.NVarChar);
                        SqlParameter paraAddInfo2DspName = sqlCommand.Parameters.Add("@ADDINFO2DSPNAME", SqlDbType.NVarChar);
                        SqlParameter paraAddInfo3DspName = sqlCommand.Parameters.Add("@ADDINFO3DSPNAME", SqlDbType.NVarChar);
                        // 2008.05.26 add start -------------------------->>
                        SqlParameter paraJoinDspName = sqlCommand.Parameters.Add("@JOINDSPNAME", SqlDbType.NVarChar);
                        SqlParameter paraStockRateDspName = sqlCommand.Parameters.Add("@STOCKRATEDSPNAME", SqlDbType.NVarChar);
                        SqlParameter paraUnitCostDspName = sqlCommand.Parameters.Add("@UNITCOSTDSPNAME", SqlDbType.NVarChar);
                        SqlParameter paraProfitDspName = sqlCommand.Parameters.Add("@PROFITDSPNAME", SqlDbType.NVarChar);
                        SqlParameter paraProfitRateDspName = sqlCommand.Parameters.Add("@PROFITRATEDSPNAME", SqlDbType.NVarChar);
                        SqlParameter paraOutTaxDspName = sqlCommand.Parameters.Add("@OUTTAXDSPNAME", SqlDbType.NVarChar);
                        SqlParameter paraInTaxDspName = sqlCommand.Parameters.Add("@INTAXDSPNAME", SqlDbType.NVarChar);
                        SqlParameter paraListPriceDspName = sqlCommand.Parameters.Add("@LISTPRICEDSPNAME", SqlDbType.NVarChar);
                        SqlParameter paraDeliHonorTtlDef = sqlCommand.Parameters.Add("@DELIHONORTTLDEF", SqlDbType.NVarChar);
                        SqlParameter paraBillHonorTtlDef = sqlCommand.Parameters.Add("@BILLHONORTTLDEF", SqlDbType.NVarChar);
                        SqlParameter paraEstmHonorTtlDef = sqlCommand.Parameters.Add("@ESTMHONORTTLDEF", SqlDbType.NVarChar);
                        SqlParameter paraRectHonorTtlDef = sqlCommand.Parameters.Add("@RECTHONORTTLDEF", SqlDbType.NVarChar);
                        // 2008.05.26 add end ----------------------------<<

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
						paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(alitmdspnmWork.CreateDateTime);
						paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(alitmdspnmWork.UpdateDateTime);
						paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.EnterpriseCode);
						paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(alitmdspnmWork.FileHeaderGuid);
						paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.UpdEmployeeCode);
						paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.UpdAssemblyId1);
						paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.UpdAssemblyId2);
						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(alitmdspnmWork.LogicalDeleteCode);

                        //paraDspNameManageNo.Value = SqlDataMediator.SqlSetInt32(alitmdspnmWork.DspNameManageNo);   // 2008.05.26 del
                        paraHomeTelNoDspName.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.HomeTelNoDspName);
                        paraOfficeTelNoDspName.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.OfficeTelNoDspName);
                        paraMobileTelNoDspName.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.MobileTelNoDspName);
                        paraOtherTelNoDspName.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.OtherTelNoDspName);
                        paraHomeFaxNoDspName.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.HomeFaxNoDspName);
                        paraOfficeFaxNoDspName.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.OfficeFaxNoDspName);
                        paraAddInfo1DspName.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.AddInfo1DspName);
                        paraAddInfo2DspName.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.AddInfo2DspName);
                        paraAddInfo3DspName.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.AddInfo3DspName);
                        // 2008.05.26 add start -------------------------->>
                        paraJoinDspName.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.JoinDspName);
                        paraStockRateDspName.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.StockRateDspName);
                        paraUnitCostDspName.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.UnitCostDspName);
                        paraProfitDspName.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.ProfitDspName);
                        paraProfitRateDspName.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.ProfitRateDspName);
                        paraOutTaxDspName.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.OutTaxDspName);
                        paraInTaxDspName.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.InTaxDspName);
                        paraListPriceDspName.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.ListPriceDspName);
                        paraDeliHonorTtlDef.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.DeliHonorTtlDef);
                        paraBillHonorTtlDef.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.BillHonorTtlDef);
                        paraEstmHonorTtlDef.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.EstmHonorTtlDef);
                        paraRectHonorTtlDef.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.RectHonorTtlDef);
                        // 2008.05.26 add end ----------------------------<<

						sqlCommand.ExecuteNonQuery();

						// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
						parabyte = XmlByteSerializer.Serialize(alitmdspnmWork);

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				}
				catch (SqlException ex) 
				{
					//���N���X�ɗ�O��n���ď������Ă��炤
					status = base.WriteSQLErrorLog(ex);
				}

				if(!myReader.IsClosed)myReader.Close();
				sqlConnection.Close();
			}
			catch(Exception ex)
			{
				base.WriteErrorLog( ex , "AlItmDspNmDB.Write" );
            }
			return status;
		}


		/// <summary>
		/// �S�̍��ڕ\�����̏���_���폜���܂�
		/// </summary>
		/// <param name="parabyte">AlItmDspNmWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �S�̍��ڕ\�����̏���_���폜���܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		public int LogicalDelete(ref byte[] parabyte)
		{
			try
			{
				return LogicalDeleteProc(ref parabyte,0);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog( ex , "AlItmDspNmDB.LogicalDelete" );
				return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
		}

		/// <summary>
		/// �_���폜�S�̍��ڕ\�����̏��𕜊����܂�
		/// </summary>
		/// <param name="parabyte">AlItmDspNmWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜�S�̍��ڕ\�����̏��𕜊����܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		public int RevivalLogicalDelete(ref byte[] parabyte)
		{
			try
			{
				return LogicalDeleteProc(ref parabyte,1);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog( ex , "AlItmDspNmDB.RevivalLogicalDelete" );
				return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
		}

		/// <summary>
		/// �S�̍��ڕ\�����̏��̘_���폜�𑀍삵�܂�
		/// </summary>
		/// <param name="parabyte">AlItmDspNmWork�I�u�W�F�N�g</param>
		/// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �S�̍��ڕ\�����̏��̘_���폜�𑀍삵�܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		private int LogicalDeleteProc(ref byte[] parabyte,int procMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int logicalDelCd = 0;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
            string sqlTxt = string.Empty; // 2008.05.26 add
			try		
			{
				//���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				AlItmDspNmWork alitmdspnmWork = (AlItmDspNmWork)XmlByteSerializer.Deserialize(parabyte,typeof(AlItmDspNmWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                // 2008.05.26 upd start ----------------------------------->>
				//using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, DSPNAMEMANAGENORF   FROM ALITMDSPNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DSPNAMEMANAGENORF=0", sqlConnection))
                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += " FROM ALITMDSPNMRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                // 2008.05.26 upd end -------------------------------------<<
                {
					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.EnterpriseCode);

					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
						DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
						if (_updateDateTime != alitmdspnmWork.UpdateDateTime)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
							sqlConnection.Close();
							return status;
						}
						//���݂̘_���폜�敪���擾
						logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
                        // 2008.05.26 upd start ---------------------------->>
						//sqlCommand.CommandText = "UPDATE ALITMDSPNMRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE   WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DSPNAMEMANAGENORF=0";
                        sqlTxt = string.Empty;
                        sqlTxt += "UPDATE ALITMDSPNMRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.26 upd end ------------------------------<<

                        //KEY�R�}���h���Đݒ�
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.EnterpriseCode);

						//�X�V�w�b�_����ݒ�
						object obj = (object)this;
						IFileHeader flhd = (IFileHeader)alitmdspnmWork;
						FileHeader fileHeader = new FileHeader(obj);
						fileHeader.SetUpdateHeader(ref flhd,obj);
					}
					else
					{
						//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						sqlCommand.Cancel();
						if(!myReader.IsClosed)myReader.Close();
						sqlConnection.Close();
						return status;
					}
					sqlCommand.Cancel();
					if(!myReader.IsClosed)myReader.Close();

					//�_���폜���[�h�̏ꍇ
					if (procMode == 0)
					{
						if		(logicalDelCd == 3)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
							sqlConnection.Close();
							return status;
						}
						else if	(logicalDelCd == 0)	alitmdspnmWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
						else						alitmdspnmWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
					}
					else
					{
						if		(logicalDelCd == 1)	alitmdspnmWork.LogicalDeleteCode = 0;//�_���폜�t���O������
						else
						{
							if  (logicalDelCd == 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
							else					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//���S�폜�̓f�[�^�Ȃ���߂�
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
							sqlConnection.Close();
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
					paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(alitmdspnmWork.UpdateDateTime);
					paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.UpdEmployeeCode);
					paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.UpdAssemblyId1);
					paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.UpdAssemblyId2);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(alitmdspnmWork.LogicalDeleteCode);

					sqlCommand.ExecuteNonQuery();

					// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
					parabyte = XmlByteSerializer.Serialize(alitmdspnmWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}

			if(!myReader.IsClosed)myReader.Close();
			sqlConnection.Close();

			return status;

		}

		/// <summary>
		/// �S�̍��ڕ\�����̏��𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">�S�̍��ڕ\�����̃I�u�W�F�N�g</param>
		/// <returns></returns>
		/// <br>Note       : �S�̍��ڕ\�����̏��𕨗��폜���܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		public int Delete(byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			try
			{
				SqlConnection sqlConnection = null;
				SqlDataReader myReader = null;
                string sqlTxt = string.Empty;   // 2008.05.26 add
				try 
				{
					//���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
					SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
					string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
					if (connectionText == null || connectionText == "") return status;

					// XML�̓ǂݍ���
					AlItmDspNmWork alitmdspnmWork = (AlItmDspNmWork)XmlByteSerializer.Deserialize(parabyte,typeof(AlItmDspNmWork));

					sqlConnection = new SqlConnection(connectionText);
					sqlConnection.Open();

                    // 2008.05.26 upd start ------------------------------->>
					//using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, DSPNAMEMANAGENORF   FROM ALITMDSPNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DSPNAMEMANAGENORF=0", sqlConnection))
                    sqlTxt += "UPDATE ALITMDSPNMRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                    sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))    
                    // 2008.05.26 upd end ---------------------------------<<
                    {
						//Prameter�I�u�W�F�N�g�̍쐬
						SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

						//Parameter�I�u�W�F�N�g�֒l�ݒ�
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.EnterpriseCode);

						myReader = sqlCommand.ExecuteReader();
						if(myReader.Read())
						{
							//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
							DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UpdateDateTimeRF"));//�X�V����
							if (_updateDateTime != alitmdspnmWork.UpdateDateTime)
							{
								status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
								sqlCommand.Cancel();
								if(!myReader.IsClosed)myReader.Close();
								sqlConnection.Close();
								return status;
							}

                            // 2008.05.26 upd start ------------------------------>>
                            //sqlCommand.CommandText = "DELETE FROM ALITMDSPNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DSPNAMEMANAGENORF=0";
                            sqlTxt = string.Empty;
                            sqlTxt += "DELETE" + Environment.NewLine;
                            sqlTxt += " FROM ALITMDSPNMRF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            // 2008.05.26 upd end --------------------------------<<
                            
                            //KEY�R�}���h���Đݒ�
							findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.EnterpriseCode);
						}
						else
						{
							//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
							status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
							sqlConnection.Close();
							return status;
						}
						if(!myReader.IsClosed)myReader.Close();

						sqlCommand.ExecuteNonQuery();

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				}
				catch (SqlException ex) 
				{
					//���N���X�ɗ�O��n���ď������Ă��炤
					status = base.WriteSQLErrorLog(ex);
				}

				if(!myReader.IsClosed)myReader.Close();
				sqlConnection.Close();
			}
			catch(Exception ex)
			{
				base.WriteErrorLog( ex , "AlItmDspNmDB.Delete" );
			}
			return status;
        }
        #endregion




        #region �J�X�^���V���A���C�Y
        /// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\������LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\������LIST��S�Ė߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		public int Search(out object retobj,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)
		{		
			try
			{
				bool nextData;
				int retTotalCnt;
				return SearchProc(out retobj,out retTotalCnt,out nextData,paraobj ,readMode,logicalMode,0);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog( ex , "AlItmDspNmDB.Search(out object retobj,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)" );
				retobj = new ArrayList();
				return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
		}


		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\������LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>		
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\������LIST��S�Ė߂��܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		private int SearchProc(out object retobj,out int retTotalCnt,out bool nextData,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			AlItmDspNmWork alitmdspnmWork = new AlItmDspNmWork();
			alitmdspnmWork = null;

			retobj = null;

			//��������0�ŏ�����
			retTotalCnt = 0;

			//�����w�胊�[�h�̏ꍇ�ɂ͎w�茏���{�P�����[�h����
			int _readCnt = readCnt;			
			if (_readCnt > 0) _readCnt += 1;
			//�����R�[�h�����ŏ�����
			nextData = false;
            string sqlTxt = string.Empty;  // 2008.05.26 add

			ArrayList al = new ArrayList();
			try 
			{	
				//���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				alitmdspnmWork = paraobj as AlItmDspNmWork;

				//SQL������
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();				

				SqlCommand sqlCommand;

				//�f�[�^�Ǎ�
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
                    // 2008.05.26 upd start ---------------------------------------------->>
					//sqlCommand = new SqlCommand("SELECT * FROM ALITMDSPNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ",sqlConnection);
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,MOBILETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OTHERTELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO1DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO2DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO3DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,JOINDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,STOCKRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,UNITCOSTDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OUTTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,INTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,LISTPRICEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,DELIHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,BILLHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,ESTMHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,RECTHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += " FROM ALITMDSPNMRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.26 upd end ------------------------------------------------<<
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
                    // 2008.05.26 upd start ---------------------------------------------->>
					//sqlCommand = new SqlCommand("SELECT * FROM ALITMDSPNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ",sqlConnection);
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,MOBILETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OTHERTELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO1DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO2DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO3DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,JOINDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,STOCKRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,UNITCOSTDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OUTTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,INTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,LISTPRICEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,DELIHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,BILLHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,ESTMHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,RECTHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += " FROM ALITMDSPNMRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.26 upd end ------------------------------------------------<<
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else
				{
                    // 2008.05.26 upd start ---------------------------------------------->>
					//sqlCommand = new SqlCommand("SELECT * FROM ALITMDSPNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ",sqlConnection);
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,MOBILETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OTHERTELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO1DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO2DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO3DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,JOINDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,STOCKRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,UNITCOSTDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OUTTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,INTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,LISTPRICEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,DELIHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,BILLHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,ESTMHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,RECTHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += " FROM ALITMDSPNMRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.26 upd end ------------------------------------------------<<
				}

                SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.EnterpriseCode);

				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				int retCnt = 0;
				while(myReader.Read())
				{
					//�߂�l�J�E���^�J�E���g
					retCnt += 1;
					if (readCnt > 0)
					{
						//�߂�l�̌������擾�w�������𒴂����ꍇ�I��
						if (readCnt < retCnt) 
						{
							nextData = true;
							break;
						}
					}
					AlItmDspNmWork wkAlItmDspNmWork = new AlItmDspNmWork();

					wkAlItmDspNmWork.CreateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					wkAlItmDspNmWork.UpdateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					wkAlItmDspNmWork.EnterpriseCode     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					wkAlItmDspNmWork.FileHeaderGuid     = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					wkAlItmDspNmWork.UpdEmployeeCode    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					wkAlItmDspNmWork.UpdAssemblyId1     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					wkAlItmDspNmWork.UpdAssemblyId2     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					wkAlItmDspNmWork.LogicalDeleteCode  = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                    //wkAlItmDspNmWork.DspNameManageNo    = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DSPNAMEMANAGENORF"));  // 2008.05.26 del
                    wkAlItmDspNmWork.HomeTelNoDspName   = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("HOMETELNODSPNAMERF"));
                    wkAlItmDspNmWork.OfficeTelNoDspName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("OFFICETELNODSPNAMERF"));
                    wkAlItmDspNmWork.MobileTelNoDspName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MOBILETELNODSPNAMERF"));
                    wkAlItmDspNmWork.OtherTelNoDspName  = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("OTHERTELNODSPNAMERF"));
                    wkAlItmDspNmWork.HomeFaxNoDspName   = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("HOMEFAXNODSPNAMERF"));
                    wkAlItmDspNmWork.OfficeFaxNoDspName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("OFFICEFAXNODSPNAMERF"));
                    wkAlItmDspNmWork.AddInfo1DspName    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDINFO1DSPNAMERF"));
                    wkAlItmDspNmWork.AddInfo2DspName    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDINFO2DSPNAMERF"));
                    wkAlItmDspNmWork.AddInfo3DspName    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDINFO3DSPNAMERF"));
                    // 2008.05.26 add start -------------------------------------->>
                    wkAlItmDspNmWork.JoinDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDSPNAMERF"));
                    wkAlItmDspNmWork.StockRateDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKRATEDSPNAMERF"));
                    wkAlItmDspNmWork.UnitCostDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITCOSTDSPNAMERF"));
                    wkAlItmDspNmWork.ProfitDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PROFITDSPNAMERF"));
                    wkAlItmDspNmWork.ProfitRateDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PROFITRATEDSPNAMERF"));
                    wkAlItmDspNmWork.OutTaxDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTTAXDSPNAMERF"));
                    wkAlItmDspNmWork.InTaxDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INTAXDSPNAMERF"));
                    wkAlItmDspNmWork.ListPriceDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LISTPRICEDSPNAMERF"));
                    wkAlItmDspNmWork.DeliHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIHONORTTLDEFRF"));
                    wkAlItmDspNmWork.BillHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLHONORTTLDEFRF"));
                    wkAlItmDspNmWork.EstmHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTMHONORTTLDEFRF"));
                    wkAlItmDspNmWork.RectHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECTHONORTTLDEFRF"));
                    // 2008.05.26 add end ----------------------------------------<<

					al.Add(wkAlItmDspNmWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}

			if(!myReader.IsClosed)myReader.Close();
			sqlConnection.Close();

			retobj = al;
			return status;

		}
		
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\�����̂�߂��܂�
		/// </summary>
		/// <param name="alItmDspNmWork">AlItmDspNmWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\�����̂�߂��܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		public int Read(ref object alItmDspNmWork, int readMode)
		{
			try
			{
				AlItmDspNmWork wkAlItmDspNmWork = alItmDspNmWork as AlItmDspNmWork;
				if(wkAlItmDspNmWork == null)return (int)ConstantManagement.DB_Status.ctDB_ERROR;
				return ReadAlItmDspNmWork(readMode,0,wkAlItmDspNmWork.EnterpriseCode,out alItmDspNmWork);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog( ex , "AlItmDspNmDB.Read(ref object alItmDspNmWork, int readMode)" );
				return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
		}	

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\�����̂�߂��܂�
		/// </summary>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="alItmDspNmWork">�擾�f�[�^</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\�����̂�߂��܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		public int ReadAlItmDspNmWork(int readMode, ConstantManagement.LogicalMode logicalMode, string enterpriseCode, out object alItmDspNmWork)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			try
			{
				SqlConnection sqlConnection = null;
				SqlDataReader myReader = null;

				alItmDspNmWork = new AlItmDspNmWork();
				AlItmDspNmWork wkalItmDspNmWork = new AlItmDspNmWork();
                string sqlTxt = string.Empty;  // 2008.05.26 add

				try 
				{			
					//���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
					SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
					string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
					if (connectionText == null || connectionText == "") return status;

					sqlConnection = new SqlConnection(connectionText);
					sqlConnection.Open();

					//Select�R�}���h�̐���
                    // 2008.05.26 upd start ------------------------------------>>
					//using(SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ALITMDSPNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DSPNAMEMANAGENORF=0", sqlConnection))
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,MOBILETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OTHERTELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO1DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO2DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO3DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,JOINDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,STOCKRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,UNITCOSTDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OUTTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,INTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,LISTPRICEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,DELIHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,BILLHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,ESTMHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,RECTHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += " FROM ALITMDSPNMRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))    
                    // 2008.05.26 upd end --------------------------------------<<
                    {
						//Prameter�I�u�W�F�N�g�̍쐬
						SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

						//Parameter�I�u�W�F�N�g�֒l�ݒ�
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

						myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
						if(myReader.Read())
						{
					        wkalItmDspNmWork.CreateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					        wkalItmDspNmWork.UpdateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					        wkalItmDspNmWork.EnterpriseCode     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					        wkalItmDspNmWork.FileHeaderGuid     = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					        wkalItmDspNmWork.UpdEmployeeCode    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					        wkalItmDspNmWork.UpdAssemblyId1     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					        wkalItmDspNmWork.UpdAssemblyId2     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					        wkalItmDspNmWork.LogicalDeleteCode  = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                            //wkalItmDspNmWork.DspNameManageNo    = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DSPNAMEMANAGENORF"));    // 2008.05.26 del
                            wkalItmDspNmWork.HomeTelNoDspName   = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("HOMETELNODSPNAMERF"));
                            wkalItmDspNmWork.OfficeTelNoDspName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("OFFICETELNODSPNAMERF"));
                            wkalItmDspNmWork.MobileTelNoDspName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MOBILETELNODSPNAMERF"));
                            wkalItmDspNmWork.OtherTelNoDspName  = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("OTHERTELNODSPNAMERF"));
                            wkalItmDspNmWork.HomeFaxNoDspName   = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("HOMEFAXNODSPNAMERF"));
                            wkalItmDspNmWork.OfficeFaxNoDspName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("OFFICEFAXNODSPNAMERF"));
                            wkalItmDspNmWork.AddInfo1DspName    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDINFO1DSPNAMERF"));
                            wkalItmDspNmWork.AddInfo2DspName    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDINFO2DSPNAMERF"));
                            wkalItmDspNmWork.AddInfo3DspName    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDINFO3DSPNAMERF"));
                            // 2008.05.26 add start ------------------------------>>
                            wkalItmDspNmWork.JoinDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDSPNAMERF"));
                            wkalItmDspNmWork.StockRateDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKRATEDSPNAMERF"));
                            wkalItmDspNmWork.UnitCostDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITCOSTDSPNAMERF"));
                            wkalItmDspNmWork.ProfitDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PROFITDSPNAMERF"));
                            wkalItmDspNmWork.ProfitRateDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PROFITRATEDSPNAMERF"));
                            wkalItmDspNmWork.OutTaxDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTTAXDSPNAMERF"));
                            wkalItmDspNmWork.InTaxDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INTAXDSPNAMERF"));
                            wkalItmDspNmWork.ListPriceDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LISTPRICEDSPNAMERF"));
                            wkalItmDspNmWork.DeliHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIHONORTTLDEFRF"));
                            wkalItmDspNmWork.BillHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLHONORTTLDEFRF"));
                            wkalItmDspNmWork.EstmHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTMHONORTTLDEFRF"));
                            wkalItmDspNmWork.RectHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECTHONORTTLDEFRF"));
                            // 2008.05.26 add end --------------------------------<<

							status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
						}
					}
				}
				catch (SqlException ex) 
				{
					//���N���X�ɗ�O��n���ď������Ă��炤
					status = base.WriteSQLErrorLog(ex);
				}

				if(!myReader.IsClosed)myReader.Close();
				sqlConnection.Close();

				alItmDspNmWork = wkalItmDspNmWork;
			}
			catch(Exception ex)
			{
				base.WriteErrorLog( ex , "AlItmDspNmDB.ReadAlItmDspNmWork" );
				alItmDspNmWork = new AlItmDspNmWork();
			}
			return status;
		}
		#endregion




        #region �p�u���b�N���\�b�h
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\������LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="parabyte">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="sqlConnection">�R�l�N�V�������</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\������LIST��S�Ė߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		public int Search(out byte[] retbyte,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
		{		
			try
			{
				bool nextData;
				int retTotalCnt;
				return SearchProc(out retbyte,out retTotalCnt,out nextData,parabyte ,readMode,logicalMode,0, ref sqlConnection);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog( ex , "Search(out byte[] retbyte,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)" );
				retbyte = new byte[0];
				return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
		}


		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\������LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>		
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="parabyte">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
		/// <param name="sqlConnection">�R�l�N�V�������</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\������LIST��S�Ė߂��܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		private int SearchProc(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt, ref SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
	//		SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			AlItmDspNmWork alitmdspnmWork = new AlItmDspNmWork();
			alitmdspnmWork = null;
            string sqlTxt = string.Empty; // 2008.05.26 add

			retbyte = null;

			//��������0�ŏ�����
			retTotalCnt = 0;

			//�����w�胊�[�h�̏ꍇ�ɂ͎w�茏���{�P�����[�h����
			int _readCnt = readCnt;			
			if (_readCnt > 0) _readCnt += 1;
			//�����R�[�h�����ŏ�����
			nextData = false;

			ArrayList al = new ArrayList();
			try 
			{	
                ////���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                //if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				alitmdspnmWork = (AlItmDspNmWork)XmlByteSerializer.Deserialize(parabyte,typeof(AlItmDspNmWork));

                ////SQL������
                //sqlConnection = new SqlConnection(connectionText);
                //sqlConnection.Open();				


				SqlCommand sqlCommand;

				//�f�[�^�Ǎ�
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
                    // 2008.05.26 upd start ------------------------------------>>
					//sqlCommand = new SqlCommand("SELECT * FROM ALITMDSPNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE",sqlConnection);
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,MOBILETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OTHERTELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO1DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO2DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO3DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,JOINDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,STOCKRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,UNITCOSTDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OUTTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,INTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,LISTPRICEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,DELIHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,BILLHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,ESTMHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,RECTHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += " FROM ALITMDSPNMRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection); 
                    // 2008.05.26 upd end --------------------------------------<<

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
                    // 2008.05.26 upd start ------------------------------------>>
					//sqlCommand = new SqlCommand("SELECT * FROM ALITMDSPNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE",sqlConnection);
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,MOBILETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OTHERTELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO1DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO2DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO3DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,JOINDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,STOCKRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,UNITCOSTDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OUTTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,INTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,LISTPRICEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,DELIHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,BILLHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,ESTMHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,RECTHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += " FROM ALITMDSPNMRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.26 upd end --------------------------------------<<

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else
				{
                    // 2008.05.26 upd start ------------------------------------>>
					//sqlCommand = new SqlCommand("SELECT * FROM ALITMDSPNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",sqlConnection);
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,MOBILETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OTHERTELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO1DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO2DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO3DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,JOINDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,STOCKRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,UNITCOSTDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OUTTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,INTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,LISTPRICEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,DELIHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,BILLHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,ESTMHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,RECTHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += " FROM ALITMDSPNMRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.26 upd end --------------------------------------<<
				}
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.EnterpriseCode);

				myReader = sqlCommand.ExecuteReader();     //CommandBehavior.CloseConnection);

                int retCnt = 0;
				while(myReader.Read())
				{
					//�߂�l�J�E���^�J�E���g
					retCnt += 1;
					if (readCnt > 0)
					{
						//�߂�l�̌������擾�w�������𒴂����ꍇ�I��
						if (readCnt < retCnt) 
						{
							nextData = true;
							break;
						}
					}
					AlItmDspNmWork wkAlItmDspNmWork = new AlItmDspNmWork();

					wkAlItmDspNmWork.CreateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					wkAlItmDspNmWork.UpdateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					wkAlItmDspNmWork.EnterpriseCode     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					wkAlItmDspNmWork.FileHeaderGuid     = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					wkAlItmDspNmWork.UpdEmployeeCode    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					wkAlItmDspNmWork.UpdAssemblyId1     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					wkAlItmDspNmWork.UpdAssemblyId2     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					wkAlItmDspNmWork.LogicalDeleteCode  = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                    //wkAlItmDspNmWork.DspNameManageNo    = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DSPNAMEMANAGENORF"));   // 2008.05.26 del
                    wkAlItmDspNmWork.HomeTelNoDspName   = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("HOMETELNODSPNAMERF"));
                    wkAlItmDspNmWork.OfficeTelNoDspName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("OFFICETELNODSPNAMERF"));
                    wkAlItmDspNmWork.MobileTelNoDspName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MOBILETELNODSPNAMERF"));
                    wkAlItmDspNmWork.OtherTelNoDspName  = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("OTHERTELNODSPNAMERF"));
                    wkAlItmDspNmWork.HomeFaxNoDspName   = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("HOMEFAXNODSPNAMERF"));
                    wkAlItmDspNmWork.OfficeFaxNoDspName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("OFFICEFAXNODSPNAMERF"));
                    wkAlItmDspNmWork.AddInfo1DspName    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDINFO1DSPNAMERF"));
                    wkAlItmDspNmWork.AddInfo2DspName    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDINFO2DSPNAMERF"));
                    wkAlItmDspNmWork.AddInfo3DspName    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDINFO3DSPNAMERF"));
                    // 2008.05.26 add start ------------------------------>>
                    wkAlItmDspNmWork.JoinDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDSPNAMERF"));
                    wkAlItmDspNmWork.StockRateDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKRATEDSPNAMERF"));
                    wkAlItmDspNmWork.UnitCostDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITCOSTDSPNAMERF"));
                    wkAlItmDspNmWork.ProfitDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PROFITDSPNAMERF"));
                    wkAlItmDspNmWork.ProfitRateDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PROFITRATEDSPNAMERF"));
                    wkAlItmDspNmWork.OutTaxDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTTAXDSPNAMERF"));
                    wkAlItmDspNmWork.InTaxDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INTAXDSPNAMERF"));
                    wkAlItmDspNmWork.ListPriceDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LISTPRICEDSPNAMERF"));
                    wkAlItmDspNmWork.DeliHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIHONORTTLDEFRF"));
                    wkAlItmDspNmWork.BillHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLHONORTTLDEFRF"));
                    wkAlItmDspNmWork.EstmHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTMHONORTTLDEFRF"));
                    wkAlItmDspNmWork.RectHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECTHONORTTLDEFRF"));
                    // 2008.05.26 add end --------------------------------<<

					al.Add(wkAlItmDspNmWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}

			if(!myReader.IsClosed)myReader.Close();
	//		sqlConnection.Close();

			// XML�֕ϊ����A������̃o�C�i����
			AlItmDspNmWork[] AlItmDspNmWorks = (AlItmDspNmWork[])al.ToArray(typeof(AlItmDspNmWork));
			retbyte = XmlByteSerializer.Serialize(AlItmDspNmWorks);

			return status;

		}
		

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\�����̂�߂��܂�
		/// </summary>
		/// <param name="parabyte">AlItmDspNmWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="sqlConnection">�R�l�N�V�������</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\�����̂�߂��܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		public int Read(ref byte[] parabyte , int readMode, ref SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			try
			{
	//			SqlConnection sqlConnection = null;
				SqlDataReader myReader = null;

				AlItmDspNmWork alitmdspnmWork = new AlItmDspNmWork();
                string sqlTxt = string.Empty; // 2008.05.26 add

				try 
				{			
                    ////���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                    //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    //if (connectionText == null || connectionText == "") return status;

					// XML�̓ǂݍ���
					alitmdspnmWork = (AlItmDspNmWork)XmlByteSerializer.Deserialize(parabyte,typeof(AlItmDspNmWork));

                    //sqlConnection = new SqlConnection(connectionText);
                    //sqlConnection.Open();

					//Select�R�}���h�̐���
                    // 2008.05.26 upd start ----------------------------------->>
					//using(SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ALITMDSPNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DSPNAMEMANAGENORF=0", sqlConnection))
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,MOBILETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OTHERTELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO1DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO2DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO3DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,JOINDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,STOCKRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,UNITCOSTDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OUTTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,INTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,LISTPRICEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,DELIHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,BILLHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,ESTMHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,RECTHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += " FROM ALITMDSPNMRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))   
                    // 2008.05.26 upd end -------------------------------------<<
                    {
						//Prameter�I�u�W�F�N�g�̍쐬
						SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

						//Parameter�I�u�W�F�N�g�֒l�ݒ�
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.EnterpriseCode);

						myReader = sqlCommand.ExecuteReader();    //CommandBehavior.CloseConnection);
						if(myReader.Read())
						{
					        alitmdspnmWork.CreateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					        alitmdspnmWork.UpdateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					        alitmdspnmWork.EnterpriseCode     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					        alitmdspnmWork.FileHeaderGuid     = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					        alitmdspnmWork.UpdEmployeeCode    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					        alitmdspnmWork.UpdAssemblyId1     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					        alitmdspnmWork.UpdAssemblyId2     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					        alitmdspnmWork.LogicalDeleteCode  = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                            //alitmdspnmWork.DspNameManageNo    = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DSPNAMEMANAGENORF"));   // 2008.05.26 del
                            alitmdspnmWork.HomeTelNoDspName   = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("HOMETELNODSPNAMERF"));
                            alitmdspnmWork.OfficeTelNoDspName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("OFFICETELNODSPNAMERF"));
                            alitmdspnmWork.MobileTelNoDspName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MOBILETELNODSPNAMERF"));
                            alitmdspnmWork.OtherTelNoDspName  = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("OTHERTELNODSPNAMERF"));
                            alitmdspnmWork.HomeFaxNoDspName   = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("HOMEFAXNODSPNAMERF"));
                            alitmdspnmWork.OfficeFaxNoDspName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("OFFICEFAXNODSPNAMERF"));
                            alitmdspnmWork.AddInfo1DspName    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDINFO1DSPNAMERF"));
                            alitmdspnmWork.AddInfo2DspName    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDINFO2DSPNAMERF"));
                            alitmdspnmWork.AddInfo3DspName    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDINFO3DSPNAMERF"));
                            // 2008.05.26 add start ------------------------------>>
                            alitmdspnmWork.JoinDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDSPNAMERF"));
                            alitmdspnmWork.StockRateDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKRATEDSPNAMERF"));
                            alitmdspnmWork.UnitCostDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITCOSTDSPNAMERF"));
                            alitmdspnmWork.ProfitDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PROFITDSPNAMERF"));
                            alitmdspnmWork.ProfitRateDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PROFITRATEDSPNAMERF"));
                            alitmdspnmWork.OutTaxDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTTAXDSPNAMERF"));
                            alitmdspnmWork.InTaxDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INTAXDSPNAMERF"));
                            alitmdspnmWork.ListPriceDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LISTPRICEDSPNAMERF"));
                            alitmdspnmWork.DeliHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIHONORTTLDEFRF"));
                            alitmdspnmWork.BillHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLHONORTTLDEFRF"));
                            alitmdspnmWork.EstmHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTMHONORTTLDEFRF"));
                            alitmdspnmWork.RectHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECTHONORTTLDEFRF"));
                            // 2008.05.26 add end --------------------------------<<

							status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
						}
					}
				}
				catch (SqlException ex) 
				{
					//���N���X�ɗ�O��n���ď������Ă��炤
					status = base.WriteSQLErrorLog(ex);
                }

				if(!myReader.IsClosed)myReader.Close();
	//			sqlConnection.Close();

				// XML�֕ϊ����A������̃o�C�i����
				parabyte = XmlByteSerializer.Serialize(alitmdspnmWork);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog( ex , "AlItmDspNmDB.Read(ref byte[] parabyte , int readMode, ref SqlConnection sqlConnection)" );
			}
			return status;
        }



        /// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\������LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="sqlConnection">�R�l�N�V�������</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\������LIST��S�Ė߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		public int Search(out object retobj,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
		{		
			try
			{
				bool nextData;
				int retTotalCnt;
				return SearchProc(out retobj,out retTotalCnt,out nextData,paraobj ,readMode,logicalMode,0, ref sqlConnection);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog( ex , "AlItmDspNmDB.Search(out object retobj,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)" );
				retobj = new ArrayList();
				return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
		}


		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\������LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>		
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
		/// <param name="sqlConnection">�R�l�N�V�������</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\������LIST��S�Ė߂��܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		private int SearchProc(out object retobj,out int retTotalCnt,out bool nextData,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt, ref SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
	//		SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			AlItmDspNmWork alitmdspnmWork = new AlItmDspNmWork();
			alitmdspnmWork = null;

			retobj = null;

			//��������0�ŏ�����
			retTotalCnt = 0;

			//�����w�胊�[�h�̏ꍇ�ɂ͎w�茏���{�P�����[�h����
			int _readCnt = readCnt;			
			if (_readCnt > 0) _readCnt += 1;
			//�����R�[�h�����ŏ�����
			nextData = false;
            string sqlTxt = string.Empty; // 2008.05.26 add

			ArrayList al = new ArrayList();
            try
            {
                ////���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                //if (connectionText == null || connectionText == "") return status;

                alitmdspnmWork = paraobj as AlItmDspNmWork;

                ////SQL������
                //sqlConnection = new SqlConnection(connectionText);
                //sqlConnection.Open();				

                SqlCommand sqlCommand;

                //�f�[�^�Ǎ�
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    // 2008.05.26 upd start --------------------------------->>
                    //sqlCommand = new SqlCommand("SELECT * FROM ALITMDSPNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ", sqlConnection);
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,MOBILETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OTHERTELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO1DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO2DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO3DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,JOINDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,STOCKRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,UNITCOSTDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OUTTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,INTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,LISTPRICEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,DELIHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,BILLHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,ESTMHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,RECTHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += " FROM ALITMDSPNMRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.26 upd end -----------------------------------<<
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    // 2008.05.26 upd start --------------------------------->>
                    //sqlCommand = new SqlCommand("SELECT * FROM ALITMDSPNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ", sqlConnection);
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,MOBILETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OTHERTELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO1DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO2DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO3DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,JOINDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,STOCKRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,UNITCOSTDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OUTTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,INTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,LISTPRICEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,DELIHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,BILLHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,ESTMHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,RECTHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += " FROM ALITMDSPNMRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.26 upd end -----------------------------------<<

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    // 2008.05.26 upd start --------------------------------->>
                    //sqlCommand = new SqlCommand("SELECT * FROM ALITMDSPNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ", sqlConnection);
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,MOBILETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OTHERTELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO1DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO2DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO3DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,JOINDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,STOCKRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,UNITCOSTDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OUTTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,INTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,LISTPRICEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,DELIHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,BILLHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,ESTMHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,RECTHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += " FROM ALITMDSPNMRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.26 upd end -----------------------------------<<
                }

                SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader();   //CommandBehavior.CloseConnection);
                int retCnt = 0;
                while (myReader.Read())
                {
                    //�߂�l�J�E���^�J�E���g
                    retCnt += 1;
                    if (readCnt > 0)
                    {
                        //�߂�l�̌������擾�w�������𒴂����ꍇ�I��
                        if (readCnt < retCnt)
                        {
                            nextData = true;
                            break;
                        }
                    }
                    AlItmDspNmWork wkAlItmDspNmWork = new AlItmDspNmWork();

                    wkAlItmDspNmWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkAlItmDspNmWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkAlItmDspNmWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkAlItmDspNmWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkAlItmDspNmWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkAlItmDspNmWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkAlItmDspNmWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkAlItmDspNmWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                    //wkAlItmDspNmWork.DspNameManageNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DSPNAMEMANAGENORF"));      // 2008.05.26 del
                    wkAlItmDspNmWork.HomeTelNoDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMETELNODSPNAMERF"));
                    wkAlItmDspNmWork.OfficeTelNoDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICETELNODSPNAMERF"));
                    wkAlItmDspNmWork.MobileTelNoDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MOBILETELNODSPNAMERF"));
                    wkAlItmDspNmWork.OtherTelNoDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OTHERTELNODSPNAMERF"));
                    wkAlItmDspNmWork.HomeFaxNoDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMEFAXNODSPNAMERF"));
                    wkAlItmDspNmWork.OfficeFaxNoDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICEFAXNODSPNAMERF"));
                    wkAlItmDspNmWork.AddInfo1DspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDINFO1DSPNAMERF"));
                    wkAlItmDspNmWork.AddInfo2DspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDINFO2DSPNAMERF"));
                    wkAlItmDspNmWork.AddInfo3DspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDINFO3DSPNAMERF"));
                    // 2008.05.26 add start ------------------------------>>
                    wkAlItmDspNmWork.JoinDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDSPNAMERF"));
                    wkAlItmDspNmWork.StockRateDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKRATEDSPNAMERF"));
                    wkAlItmDspNmWork.UnitCostDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITCOSTDSPNAMERF"));
                    wkAlItmDspNmWork.ProfitDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PROFITDSPNAMERF"));
                    wkAlItmDspNmWork.ProfitRateDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PROFITRATEDSPNAMERF"));
                    wkAlItmDspNmWork.OutTaxDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTTAXDSPNAMERF"));
                    wkAlItmDspNmWork.InTaxDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INTAXDSPNAMERF"));
                    wkAlItmDspNmWork.ListPriceDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LISTPRICEDSPNAMERF"));
                    wkAlItmDspNmWork.DeliHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIHONORTTLDEFRF"));
                    wkAlItmDspNmWork.BillHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLHONORTTLDEFRF"));
                    wkAlItmDspNmWork.EstmHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTMHONORTTLDEFRF"));
                    wkAlItmDspNmWork.RectHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECTHONORTTLDEFRF"));
                    // 2008.05.26 add end --------------------------------<<

                    al.Add(wkAlItmDspNmWork);

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
                if (!myReader.IsClosed) myReader.Close();
                //		sqlConnection.Close();
            }

			retobj = al;
			return status;

		}
		
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\�����̂�߂��܂�
		/// </summary>
		/// <param name="alItmDspNmWork">AlItmDspNmWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="sqlConnection">�R�l�N�V�������</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\�����̂�߂��܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		public int Read(ref object alItmDspNmWork, int readMode, ref SqlConnection sqlConnection)
		{
			try
			{
				AlItmDspNmWork wkAlItmDspNmWork = alItmDspNmWork as AlItmDspNmWork;
				if(wkAlItmDspNmWork == null)return (int)ConstantManagement.DB_Status.ctDB_ERROR;

				return ReadAlItmDspNmWork(readMode,0,wkAlItmDspNmWork.EnterpriseCode,out alItmDspNmWork, ref sqlConnection);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog( ex , "AlItmDspNmDB.Read(ref object alItmDspNmWork, int readMode, ref SqlConnection sqlConnection)" );
				return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
		}	

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\�����̂�߂��܂�
		/// </summary>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="alItmDspNmWork">�擾�f�[�^</param>
		/// <param name="sqlConnection">�R�l�N�V�������</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\�����̂�߂��܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		public int ReadAlItmDspNmWork(int readMode, ConstantManagement.LogicalMode logicalMode, string enterpriseCode, out object alItmDspNmWork, ref SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			try
			{
	//			SqlConnection sqlConnection = null;
				SqlDataReader myReader = null;

				alItmDspNmWork = new AlItmDspNmWork();
				AlItmDspNmWork wkalItmDspNmWork = new AlItmDspNmWork();

				try 
				{			
                    ////���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                    //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    //if (connectionText == null || connectionText == "") return status;

                    //sqlConnection = new SqlConnection(connectionText);
                    //sqlConnection.Open();

					//Select�R�}���h�̐���
                    // 2008.05.26 upd start ---------------------------------------->>
					//using(SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ALITMDSPNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DSPNAMEMANAGENORF=0", sqlConnection))
                    string sqlTxt = string.Empty;
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,MOBILETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OTHERTELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO1DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO2DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO3DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,JOINDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,STOCKRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,UNITCOSTDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OUTTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,INTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,LISTPRICEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,DELIHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,BILLHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,ESTMHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,RECTHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += " FROM ALITMDSPNMRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                    // 2008.05.26 upd end ------------------------------------------<<
                    {
						//Prameter�I�u�W�F�N�g�̍쐬
						SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

						//Parameter�I�u�W�F�N�g�֒l�ݒ�
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

						myReader = sqlCommand.ExecuteReader();   //CommandBehavior.CloseConnection);
						if(myReader.Read())
						{
					        wkalItmDspNmWork.CreateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					        wkalItmDspNmWork.UpdateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					        wkalItmDspNmWork.EnterpriseCode     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					        wkalItmDspNmWork.FileHeaderGuid     = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					        wkalItmDspNmWork.UpdEmployeeCode    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					        wkalItmDspNmWork.UpdAssemblyId1     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					        wkalItmDspNmWork.UpdAssemblyId2     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					        wkalItmDspNmWork.LogicalDeleteCode  = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                            //wkalItmDspNmWork.DspNameManageNo    = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DSPNAMEMANAGENORF"));   // 2008.05.26 del
                            wkalItmDspNmWork.HomeTelNoDspName   = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("HOMETELNODSPNAMERF"));
                            wkalItmDspNmWork.OfficeTelNoDspName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("OFFICETELNODSPNAMERF"));
                            wkalItmDspNmWork.MobileTelNoDspName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MOBILETELNODSPNAMERF"));
                            wkalItmDspNmWork.OtherTelNoDspName  = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("OTHERTELNODSPNAMERF"));
                            wkalItmDspNmWork.HomeFaxNoDspName   = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("HOMEFAXNODSPNAMERF"));
                            wkalItmDspNmWork.OfficeFaxNoDspName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("OFFICEFAXNODSPNAMERF"));
                            wkalItmDspNmWork.AddInfo1DspName    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDINFO1DSPNAMERF"));
                            wkalItmDspNmWork.AddInfo2DspName    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDINFO2DSPNAMERF"));
                            wkalItmDspNmWork.AddInfo3DspName    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDINFO3DSPNAMERF"));
                            // 2008.05.26 add start ------------------------------>>
                            wkalItmDspNmWork.JoinDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDSPNAMERF"));
                            wkalItmDspNmWork.StockRateDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKRATEDSPNAMERF"));
                            wkalItmDspNmWork.UnitCostDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITCOSTDSPNAMERF"));
                            wkalItmDspNmWork.ProfitDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PROFITDSPNAMERF"));
                            wkalItmDspNmWork.ProfitRateDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PROFITRATEDSPNAMERF"));
                            wkalItmDspNmWork.OutTaxDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTTAXDSPNAMERF"));
                            wkalItmDspNmWork.InTaxDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INTAXDSPNAMERF"));
                            wkalItmDspNmWork.ListPriceDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LISTPRICEDSPNAMERF"));
                            wkalItmDspNmWork.DeliHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIHONORTTLDEFRF"));
                            wkalItmDspNmWork.BillHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLHONORTTLDEFRF"));
                            wkalItmDspNmWork.EstmHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTMHONORTTLDEFRF"));
                            wkalItmDspNmWork.RectHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECTHONORTTLDEFRF"));
                            // 2008.05.26 add end --------------------------------<<
                            
							status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
						}
					}
				}
				catch (SqlException ex) 
				{
					//���N���X�ɗ�O��n���ď������Ă��炤
					status = base.WriteSQLErrorLog(ex);
				}

				if(!myReader.IsClosed)myReader.Close();
	//			sqlConnection.Close();

				alItmDspNmWork = wkalItmDspNmWork;
			}
			catch(Exception ex)
			{
				base.WriteErrorLog( ex , "AlItmDspNmDB.ReadAlItmDspNmWork" );
				alItmDspNmWork = new AlItmDspNmWork();
			}
			return status;
		}
        #endregion




        #region ArrayList��
        /// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\������LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="sqlConnection">�R�l�N�V�������</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\������LIST��S�Ė߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
//		public int Search(out ArrayList retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
		public int Search(out AlItmDspNmWork retobj, AlItmDspNmWork paraobj, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
		{		
			try
			{
				bool nextData;
				int retTotalCnt;
				return SearchProc(out retobj, out retTotalCnt, out nextData, paraobj, readMode, logicalMode, 0, ref sqlConnection);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog( ex , "AlItmDspNmDB.Search(out ArrayList retobj,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)" );
				retobj = null;      //new ArrayList();
				return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
		}


		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\������LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>		
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
		/// <param name="sqlConnection">�R�l�N�V�������</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̑S�̍��ڕ\������LIST��S�Ė߂��܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
//		private int SearchProc(out ArrayList retobj, out int retTotalCnt, out bool nextData, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt, ref SqlConnection sqlConnection)
		private int SearchProc(out AlItmDspNmWork retobj, out int retTotalCnt, out bool nextData, AlItmDspNmWork paraobj, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt, ref SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
	//		SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			AlItmDspNmWork alitmdspnmWork = new AlItmDspNmWork();
			alitmdspnmWork = null;

			retobj = null;

			//��������0�ŏ�����
			retTotalCnt = 0;

			//�����w�胊�[�h�̏ꍇ�ɂ͎w�茏���{�P�����[�h����
			int _readCnt = readCnt;			
			if (_readCnt > 0) _readCnt += 1;
			//�����R�[�h�����ŏ�����
			nextData = false;

			ArrayList al = new ArrayList();

      		AlItmDspNmWork wkAlItmDspNmWork = new AlItmDspNmWork();
            string sqlTxt = string.Empty; // 2008.05.26 add
            
            try 
			{	
                ////���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                //if (connectionText == null || connectionText == "") return status;

				alitmdspnmWork = paraobj as AlItmDspNmWork;

                ////SQL������
                //sqlConnection = new SqlConnection(connectionText);
                //sqlConnection.Open();				

				SqlCommand sqlCommand;

				//�f�[�^�Ǎ�
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
                    // 2008.05.26 upd start ------------------------------->>
					//sqlCommand = new SqlCommand("SELECT * FROM ALITMDSPNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ",sqlConnection);
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,MOBILETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OTHERTELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO1DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO2DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO3DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,JOINDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,STOCKRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,UNITCOSTDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OUTTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,INTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,LISTPRICEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,DELIHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,BILLHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,ESTMHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,RECTHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += " FROM ALITMDSPNMRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.26 upd end ---------------------------------<<

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
                    // 2008.05.26 upd start ------------------------------->>
					//sqlCommand = new SqlCommand("SELECT * FROM ALITMDSPNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ",sqlConnection);
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,MOBILETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OTHERTELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO1DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO2DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO3DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,JOINDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,STOCKRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,UNITCOSTDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OUTTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,INTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,LISTPRICEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,DELIHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,BILLHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,ESTMHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,RECTHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += " FROM ALITMDSPNMRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.26 upd end ---------------------------------<<

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else
				{
                    // 2008.05.26 upd start ------------------------------->>
					//sqlCommand = new SqlCommand("SELECT * FROM ALITMDSPNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ",sqlConnection);
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,MOBILETELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OTHERTELNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,HOMEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OFFICEFAXNODSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO1DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO2DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ADDINFO3DSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,JOINDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,STOCKRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,UNITCOSTDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,PROFITRATEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,OUTTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,INTAXDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,LISTPRICEDSPNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,DELIHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,BILLHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,ESTMHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += "    ,RECTHONORTTLDEFRF" + Environment.NewLine;
                    sqlTxt += " FROM ALITMDSPNMRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.26 upd end ---------------------------------<<
                }

                SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(alitmdspnmWork.EnterpriseCode);

				myReader = sqlCommand.ExecuteReader();      //CommandBehavior.CloseConnection);
				int retCnt = 0;
				while(myReader.Read())
				{
					//�߂�l�J�E���^�J�E���g
					retCnt += 1;
					if (readCnt > 0)
					{
						//�߂�l�̌������擾�w�������𒴂����ꍇ�I��
						if (readCnt < retCnt) 
						{
							nextData = true;
							break;
						}
					}
			//		AlItmDspNmWork wkAlItmDspNmWork = new AlItmDspNmWork();

					wkAlItmDspNmWork.CreateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					wkAlItmDspNmWork.UpdateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					wkAlItmDspNmWork.EnterpriseCode     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					wkAlItmDspNmWork.FileHeaderGuid     = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					wkAlItmDspNmWork.UpdEmployeeCode    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					wkAlItmDspNmWork.UpdAssemblyId1     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					wkAlItmDspNmWork.UpdAssemblyId2     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					wkAlItmDspNmWork.LogicalDeleteCode  = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                    //wkAlItmDspNmWork.DspNameManageNo    = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DSPNAMEMANAGENORF"));   // 2008.05.26 del
                    wkAlItmDspNmWork.HomeTelNoDspName   = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("HOMETELNODSPNAMERF"));
                    wkAlItmDspNmWork.OfficeTelNoDspName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("OFFICETELNODSPNAMERF"));
                    wkAlItmDspNmWork.MobileTelNoDspName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MOBILETELNODSPNAMERF"));
                    wkAlItmDspNmWork.OtherTelNoDspName  = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("OTHERTELNODSPNAMERF"));
                    wkAlItmDspNmWork.HomeFaxNoDspName   = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("HOMEFAXNODSPNAMERF"));
                    wkAlItmDspNmWork.OfficeFaxNoDspName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("OFFICEFAXNODSPNAMERF"));
                    wkAlItmDspNmWork.AddInfo1DspName    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDINFO1DSPNAMERF"));
                    wkAlItmDspNmWork.AddInfo2DspName    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDINFO2DSPNAMERF"));
                    wkAlItmDspNmWork.AddInfo3DspName    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDINFO3DSPNAMERF"));
                    // 2008.05.26 add start ------------------------------>>
                    wkAlItmDspNmWork.JoinDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDSPNAMERF"));
                    wkAlItmDspNmWork.StockRateDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKRATEDSPNAMERF"));
                    wkAlItmDspNmWork.UnitCostDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITCOSTDSPNAMERF"));
                    wkAlItmDspNmWork.ProfitDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PROFITDSPNAMERF"));
                    wkAlItmDspNmWork.ProfitRateDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PROFITRATEDSPNAMERF"));
                    wkAlItmDspNmWork.OutTaxDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTTAXDSPNAMERF"));
                    wkAlItmDspNmWork.InTaxDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INTAXDSPNAMERF"));
                    wkAlItmDspNmWork.ListPriceDspName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LISTPRICEDSPNAMERF"));
                    wkAlItmDspNmWork.DeliHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIHONORTTLDEFRF"));
                    wkAlItmDspNmWork.BillHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLHONORTTLDEFRF"));
                    wkAlItmDspNmWork.EstmHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTMHONORTTLDEFRF"));
                    wkAlItmDspNmWork.RectHonorTtlDef = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECTHONORTTLDEFRF"));
                    // 2008.05.26 add end --------------------------------<<

				//	al.Add(wkAlItmDspNmWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}

			if(!myReader.IsClosed)myReader.Close();
	//		sqlConnection.Close();

			//retobj = al;
            retobj = wkAlItmDspNmWork;
			return status;

		}
		
        #endregion


    }
}
