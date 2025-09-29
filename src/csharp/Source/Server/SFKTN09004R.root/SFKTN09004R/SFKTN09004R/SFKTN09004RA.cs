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
using Broadleaf.Application.Common;


namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���_���ݒ�DB�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���_���ݒ�̎��f�[�^������s���N���X�ł��B</br>
	/// <br>Programmer : 21015�@�����@�F��</br>
	/// <br>Date       : 2005.03.24</br>
    /// <br></br>
    /// <br>Update Note: 980081  �R�c ���F</br>
    /// <br>Date       : 2007.09.26</br>
    /// <br>           : ���ʊ�Ή�(�q�ɒǉ�)</br>
    /// <br></br>
    /// <br>Update Note: 2007.12.17  �R�c ���F</br>
    /// <br>             Search���\�b�h(SqlTransaction�t��)��ǉ�</br>
    /// <br>Update Note: 2008.05.22  20081 �D�c �E�l</br>
    /// <br>             �o�l.�m�r�p�ɕύX</br>
    /// </remarks>
	[Serializable]
    public class SecInfoSetDB : RemoteDB, ISecInfoSetDB, IGetSyncdataList
	{

		/// <summary>
		/// ���_���ݒ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		/// </remarks>
		public SecInfoSetDB() :
			base("SFKTN09006D", "Broadleaf.Application.Remoting.ParamData.SecInfoSetWork", "SECINFOSETRF")
		{
		}

		/// <summary>
		/// �w�肳�ꂽ���_�R�[�h�̋��_���ݒ�LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^(readMode=0:SecInfoSetWork�N���X�F���_�R�[�h)</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		public int SearchCnt(out int retCnt,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			return SearchCntProc(out retCnt, parabyte, readMode,logicalMode);
		}

		/// <summary>
		/// �w�肳�ꂽ���_�R�[�h�̋��_���ݒ�LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^(readMode=0:SecInfoSetWork�N���X�F���_�R�[�h)</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		private int SearchCntProc(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;

			SecInfoSetWork secinfosetWork = null;

			retCnt = 0;

			try 
			{	
				//�R�l�N�V����������擾�Ή�����������
				//���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
				//���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;
				//�R�l�N�V����������擾�Ή�����������

				// XML�̓ǂݍ���
				secinfosetWork = (SecInfoSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SecInfoSetWork));

				//SQL������
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                string sqlTxt = string.Empty; // 2008.05.22 add

				using(SqlCommand sqlCommand = new SqlCommand("",sqlConnection))
				{
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
						(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||
						(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
                        // 2008.05.22 upd start ---------------------------------------------------->>
						//sqlCommand.CommandText = "SELECT COUNT (*) FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
                        sqlTxt += "SELECT COUNT" + Environment.NewLine;
                        sqlTxt += "    (*)" + Environment.NewLine;
                        sqlTxt += "    FROM SECINFOSETRF" + Environment.NewLine;
                        sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "        AND LOGICALDELETECODERF=@FINDLOGICALDELETECODERF" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.22 upd end ------------------------------------------------------<<
                        //�_���폜�敪�ݒ�
						SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					}
					else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
						(logicalMode == ConstantManagement.LogicalMode.GetData012))
					{
                        // 2008.05.22 upd start ---------------------------------------------------->>
						//sqlCommand.CommandText = "SELECT COUNT (*) FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE";
                        sqlTxt += "SELECT COUNT" + Environment.NewLine;
                        sqlTxt += "    (*)" + Environment.NewLine;
                        sqlTxt += "    FROM SECINFOSETRF" + Environment.NewLine;
                        sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "        AND LOGICALDELETECODERF<@FINDLOGICALDELETECODERF" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.22 upd end ------------------------------------------------------<<
                        //�_���폜�敪�ݒ�
						SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
						else														paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
					}
					else 
					{
                        // 2008.05.22 upd start ---------------------------------------------------->>
						//sqlCommand.CommandText = "SELECT COUNT (*) FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
                        sqlTxt += "SELECT COUNT" + Environment.NewLine;
                        sqlTxt += "    (*)" + Environment.NewLine;
                        sqlTxt += "    FROM SECINFOSETRF" + Environment.NewLine;
                        sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.22 upd end ------------------------------------------------------<<
					}
					SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.EnterpriseCode);

					//�f�[�^���[�h
					retCnt = (int)sqlCommand.ExecuteScalar();
					if (retCnt > 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					sqlCommand.Cancel();
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"SecInfoSetDB.SearchCnt Exception="+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(sqlConnection != null)
				{
					sqlConnection.Close();
					sqlConnection.Dispose();
				}
			}
			
			return status;
		}

		/// <summary>
		/// �w�肳�ꂽ���_�R�[�h�̋��_���ݒ�LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="parabyte">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		public int Search(out byte[] retbyte,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{		
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			bool nextData;
			int retTotalCnt;
			retbyte = null;
			try
			{
				status = SearchProc(out retbyte,out retTotalCnt,out nextData,parabyte ,readMode,logicalMode,0);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"SecInfoSetDB.Search Exception="+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}

		/// <summary>
		/// �w�肳�ꂽ���_�R�[�h�̋��_���ݒ�LIST���w�茏�����S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="parabyte">�����p�����[�^�iNextRead���͑O��ŏI���R�[�h�N���X�j</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">��������</param>		
		/// <returns>STATUS</returns>
		public int SearchSpecification(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte,int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{		
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			nextData = false;
			retTotalCnt = 0;
			retbyte = null;
			try
			{
				status = SearchProc(out retbyte,out retTotalCnt,out nextData,parabyte, readMode,logicalMode,readCnt);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"SecInfoSetDB.SearchSpecification Exception="+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}

		/// <summary>
		/// �w�肳�ꂽ���_�R�[�h�̋��_���ݒ�LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>		
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="parabyte">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
		/// <returns>STATUS</returns>
		private int SearchProc(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			SecInfoSetWork secinfosetWork = new SecInfoSetWork();
			secinfosetWork = null;

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
				//�R�l�N�V����������擾�Ή�����������
				//���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
				//���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;
				//�R�l�N�V����������擾�Ή�����������

				// XML�̓ǂݍ���
				secinfosetWork = (SecInfoSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SecInfoSetWork));

                string sqlTxt = string.Empty;  // 2008.05.22 add 

				//SQL������
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();				

				//�����w�胊�[�h�ňꌏ�ڃ��[�h�̏ꍇ�f�[�^���������擾
				if ((readCnt > 0)&&((secinfosetWork.SectionCode == null)||(secinfosetWork.SectionCode == "")))
				{
					using(SqlCommand sqlCommandCount = new SqlCommand("",sqlConnection))
					{
						if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
							(logicalMode == ConstantManagement.LogicalMode.GetData1)||
							(logicalMode == ConstantManagement.LogicalMode.GetData2)||
							(logicalMode == ConstantManagement.LogicalMode.GetData3))
						{
                            // 2008.05.22 upd start ---------------------------------------------------->>
							//sqlCommandCount.CommandText = "SELECT COUNT (*) FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
                            sqlTxt += "SELECT COUNT" + Environment.NewLine;
                            sqlTxt += "    (*)" + Environment.NewLine;
                            sqlTxt += "    FROM SECINFOSETRF" + Environment.NewLine;
                            sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "        AND LOGICALDELETECODERF=@FINDLOGICALDELETECODERF" + Environment.NewLine;
                            sqlCommandCount.CommandText = sqlTxt;
                            // 2008.05.22 upd end ------------------------------------------------------<<
                            //�_���폜�敪�ݒ�
							SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
							paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
						}
						else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
							(logicalMode == ConstantManagement.LogicalMode.GetData012))
						{
                            // 2008.05.22 upd start ---------------------------------------------------->>
							//sqlCommandCount.CommandText = "SELECT COUNT (*) FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE";
                            sqlTxt += "SELECT COUNT" + Environment.NewLine;
                            sqlTxt += "    (*)" + Environment.NewLine;
                            sqlTxt += "    FROM SECINFOSETRF" + Environment.NewLine;
                            sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "        AND LOGICALDELETECODERF<@FINDLOGICALDELETECODERF" + Environment.NewLine;
                            sqlCommandCount.CommandText = sqlTxt;
                            // 2008.05.22 upd end ------------------------------------------------------<<
                            //�_���폜�敪�ݒ�
							SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
							if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
							else														paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
						}
						else 
						{
                            // 2008.05.22 upd start ---------------------------------------------------->>
							//sqlCommandCount.CommandText = "SELECT COUNT (*) FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
                            sqlTxt += "SELECT COUNT" + Environment.NewLine;
                            sqlTxt += "    (*)" + Environment.NewLine;
                            sqlTxt += "    FROM SECINFOSETRF" + Environment.NewLine;
                            sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlCommandCount.CommandText = sqlTxt;
                            // 2008.05.22 upd end ------------------------------------------------------<<
						}
						SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
						paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.EnterpriseCode);

						retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
						sqlCommandCount.Cancel();
					}
				}
                sqlTxt = string.Empty; // 2008.05.22 add

				using(SqlCommand sqlCommand = new SqlCommand("",sqlConnection))
				{
					//�f�[�^�Ǎ�
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
						(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||
						(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
						//�����w�薳���̏ꍇ
						if (readCnt == 0)
						{
                            // 2008.05.22 upd start ---------------------------------------------------->>
							//sqlCommand.CommandText = "SELECT * FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY SECTIONCODERF";
                            sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                            sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                            sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                            sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                            sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                            sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                            sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                            sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt; 
                            // 2008.05.22 upd end ------------------------------------------------------<<
                        }
						else
						{
							//�ꌏ�ڃ��[�h�̏ꍇ
							if ((secinfosetWork.SectionCode == null)||(secinfosetWork.SectionCode == ""))
							{
                                // 2008.05.22 upd start ------------------------------------------------>>
								//sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY SECTIONCODERF";
                                sqlTxt += "SELECT TOP" + Environment.NewLine;
                                sqlTxt += _readCnt.ToString() + Environment.NewLine;
                                sqlTxt += "     CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                                sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                                sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                                sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                                sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                                sqlCommand.CommandText = sqlTxt; 
                                // 2008.05.22 upd end --------------------------------------------------<<
                            }
								//Next���[�h�̏ꍇ
							else
							{
                                // 2008.05.22 upd start ------------------------------------------------>>
								sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM SECINFOSETRF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND SECTIONCODERF>@FINDSECTIONCODE ORDER BY SECTIONCODERF";
                                sqlTxt += "SELECT TOP" + Environment.NewLine;
                                sqlTxt += _readCnt.ToString() + Environment.NewLine;
                                sqlTxt += "     CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                                sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                                sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                                sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                                sqlTxt += "    AND SECTIONCODERF>@FINDSECTIONCODERF" + Environment.NewLine;
                                sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                                sqlCommand.CommandText = sqlTxt;
                                // 2008.05.22 upd end --------------------------------------------------<<
                                
                                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
								paraSectionCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectionCode);
							}
						}
						SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					}
					else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
						(logicalMode == ConstantManagement.LogicalMode.GetData012))
					{
						//�����w�薳���̏ꍇ
						if (readCnt == 0)
						{
                            // 2008.05.22 upd start ---------------------------------------------------->>
							//sqlCommand.CommandText = "SELECT * FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY SECTIONCODERF";
                            sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                            sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                            sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                            sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                            sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                            sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                            sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                            sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            // 2008.05.22 upd end ------------------------------------------------------<<
                        }
						else
						{
							//�ꌏ�ڃ��[�h�̏ꍇ
							if ((secinfosetWork.SectionCode == null)||(secinfosetWork.SectionCode == ""))
							{
                                // 2008.05.22 upd start ------------------------------------------------>>
								//sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY SECTIONCODERF";
                                sqlTxt += "SELECT TOP" + Environment.NewLine;
                                sqlTxt += _readCnt.ToString() + Environment.NewLine;
                                sqlTxt += "     CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                                sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                                sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                                sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                                sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                                sqlCommand.CommandText = sqlTxt;
                                // 2008.05.22 upd end --------------------------------------------------<<
                            }
								//Next���[�h�̏ꍇ
							else
							{
                                // 2008.05.22 upd start ------------------------------------------------>>
								//sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM SECINFOSETRF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE AND SECTIONCODERF>@FINDSECTIONCODE ORDER BY SECTIONCODERF";
                                sqlTxt += "SELECT TOP" + Environment.NewLine;
                                sqlTxt += _readCnt.ToString() + Environment.NewLine;
                                sqlTxt += "     CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                                sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                                sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                                sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                                sqlTxt += "    AND SECTIONCODERF>@FINDSECTIONCODERF" + Environment.NewLine;
                                sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                                sqlCommand.CommandText = sqlTxt;
                                // 2008.05.22 upd end --------------------------------------------------<<
                                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
								paraSectionCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectionCode);
							}
						}
						SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
						else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
					}
					else
					{
						//�����w�薳���̏ꍇ
						if (readCnt == 0)
						{
                            // 2008.05.22 upd start----------------------------------------------------->>
							//sqlCommand.CommandText = "SELECT * FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY SECTIONCODERF";
                            sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                            sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                            sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                            sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                            sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                            sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                            sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                            sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            // 2008.05.22 upd end ------------------------------------------------------<<
                        }
						else
						{
							//�ꌏ�ڃ��[�h�̏ꍇ
							if ((secinfosetWork.SectionCode == null)||(secinfosetWork.SectionCode == ""))
							{
                                // 2008.05.22 upd start ------------------------------------------------>>
								//sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY SECTIONCODERF";
                                sqlTxt += "SELECT TOP" + Environment.NewLine;
                                sqlTxt += _readCnt.ToString() + Environment.NewLine;
                                sqlTxt += "     CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                                sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                                sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                                sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                                sqlCommand.CommandText = sqlTxt;
                                // 2008.05.22 upd end --------------------------------------------------<<
                            }
							else
							{
                                // 2008.05.22 upd start ------------------------------------------------>>
								//sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF>@FINDSECTIONCODE ORDER BY SECTIONCODERF";
                                sqlTxt += "SELECT TOP" + Environment.NewLine;
                                sqlTxt += _readCnt.ToString() + Environment.NewLine;
                                sqlTxt += "     CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                                sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                                sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                                sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    AND SECTIONCODERF>@FINDSECTIONCODERF" + Environment.NewLine;
                                sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                                sqlCommand.CommandText = sqlTxt;
                                // 2008.05.22 upd end --------------------------------------------------<<
                                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
								paraSectionCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectionCode);
							}
						}
					}
					SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(secinfosetWork.EnterpriseCode);

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
						SecInfoSetWork wkSecInfoSetWork = new SecInfoSetWork();

						wkSecInfoSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
						wkSecInfoSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
						wkSecInfoSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
						wkSecInfoSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
						wkSecInfoSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
						wkSecInfoSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
						wkSecInfoSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
						wkSecInfoSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
						wkSecInfoSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONCODERF"));
						wkSecInfoSetWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONGUIDENMRF"));
                        wkSecInfoSetWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));    // 2008.05.22 add
						wkSecInfoSetWork.CompanyNameCd1 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD1RF"));
                        wkSecInfoSetWork.MainOfficeFuncFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINOFFICEFUNCFLAGRF"));
                        wkSecInfoSetWork.IntroductionDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INTRODUCTIONDATERF"));   // 2008.05.22 add
                        // �� 20070926 980081 a
                        wkSecInfoSetWork.SectWarehouseCd1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD1RF"));
                        wkSecInfoSetWork.SectWarehouseCd2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD2RF"));
                        wkSecInfoSetWork.SectWarehouseCd3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD3RF"));
                        // �� 20070926 980081 a
						al.Add(wkSecInfoSetWork);

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
					sqlCommand.Cancel();
				}
				// XML�֕ϊ����A������̃o�C�i����
				SecInfoSetWork[] SecInfoSetWorks = (SecInfoSetWork[])al.ToArray(typeof(SecInfoSetWork));
				retbyte = XmlByteSerializer.Serialize(SecInfoSetWorks);
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"SecInfoSetDB.SearchProc Exception="+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Close();
					sqlConnection.Dispose();
				}
			}

			return status;
		}
		
		/// <summary>
		/// �w�肳�ꂽ���_�R�[�h�̋��_���ݒ�LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retList">��������</param>
		/// <param name="secinfosetWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="sqlConnection">�R�l�N�V�������</param>
		/// <returns>STATUS</returns>
		public int Search(out ArrayList retList,SecInfoSetWork secinfosetWork, int readMode,ConstantManagement.LogicalMode logicalMode,ref SqlConnection sqlConnection)
		{
            return this.SearchProc(out retList, secinfosetWork, readMode, logicalMode, ref sqlConnection);
        }
		/// <summary>
		/// �w�肳�ꂽ���_�R�[�h�̋��_���ݒ�LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retList">��������</param>
		/// <param name="secinfosetWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="sqlConnection">�R�l�N�V�������</param>
		/// <returns>STATUS</returns>
        /// 
        private int SearchProc(out ArrayList retList,SecInfoSetWork secinfosetWork, int readMode,ConstantManagement.LogicalMode logicalMode,ref SqlConnection sqlConnection)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlDataReader myReader = null;

			ArrayList al = new ArrayList();
			try 
			{
                string sqlTxt = string.Empty; // 2008.05.22 add

				using(SqlCommand sqlCommand = new SqlCommand("",sqlConnection))
				{
					//�f�[�^�Ǎ�
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
						(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||
						(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
                        // 2008.05.22 upd start ----------------------------------------->>
						//sqlCommand.CommandText = "SELECT * FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY SECTIONCODERF";
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                        sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                        sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                        sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.22 upd end -------------------------------------------<<
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					}
					else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
						(logicalMode == ConstantManagement.LogicalMode.GetData012))
					{
                        // 2008.05.22 upd start ----------------------------------------->>
						//sqlCommand.CommandText = "SELECT * FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY SECTIONCODERF";
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                        sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                        sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                        sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.22 upd end -------------------------------------------<<
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
						else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
					}
					else
					{
                        // 2008.05.22 upd start ----------------------------------------->>
						//sqlCommand.CommandText = "SELECT * FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY SECTIONCODERF";
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                        sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                        sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                        sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.22 upd end -------------------------------------------<<
                    }
					SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(secinfosetWork.EnterpriseCode);

					myReader = sqlCommand.ExecuteReader();

					while(myReader.Read())
					{
						SecInfoSetWork wkSecInfoSetWork = new SecInfoSetWork();

						wkSecInfoSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
						wkSecInfoSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
						wkSecInfoSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
						wkSecInfoSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
						wkSecInfoSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
						wkSecInfoSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
						wkSecInfoSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
						wkSecInfoSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
						wkSecInfoSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONCODERF"));
						wkSecInfoSetWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONGUIDENMRF"));
                        wkSecInfoSetWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));     // 2008.05.22 add
						wkSecInfoSetWork.CompanyNameCd1 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD1RF"));
                        wkSecInfoSetWork.MainOfficeFuncFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINOFFICEFUNCFLAGRF"));
                        wkSecInfoSetWork.IntroductionDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INTRODUCTIONDATERF"));    // 2008.05.22 add
                        // �� 20070926 980081 a
                        wkSecInfoSetWork.SectWarehouseCd1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD1RF"));
                        wkSecInfoSetWork.SectWarehouseCd2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD2RF"));
                        wkSecInfoSetWork.SectWarehouseCd3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD3RF"));
                        // �� 20070926 980081 a

						al.Add(wkSecInfoSetWork);

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
					sqlCommand.Cancel();
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}

			if(!myReader.IsClosed)myReader.Close();

			retList = al;

			return status;

		}

        // �� 2007.12.17 980081 a
        /// <summary>
        /// �w�肳�ꂽ���_�R�[�h�̋��_���ݒ�LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="secinfosetWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        public int Search(out ArrayList retList, SecInfoSetWork secinfosetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(out retList, secinfosetWork, readMode, logicalMode, ref sqlConnection,ref sqlTransaction);
        }
        /// <summary>
        /// �w�肳�ꂽ���_�R�[�h�̋��_���ݒ�LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="secinfosetWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        private int SearchProc(out ArrayList retList, SecInfoSetWork secinfosetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlTxt = string.Empty; // 2008.05.22 add

                using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction))
                {
                    //�f�[�^�Ǎ�
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        // 2008.05.22 upd start -------------------------------------->>
                        //sqlCommand.CommandText = "SELECT * FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY SECTIONCODERF";
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                        sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                        sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                        sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.22 upd end ----------------------------------------<<
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        // 2008.05.22 upd start -------------------------------------->>
                        //sqlCommand.CommandText = "SELECT * FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY SECTIONCODERF";
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                        sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                        sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                        sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.22 upd end ----------------------------------------<<
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                        else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                    }
                    else
                    {
                        // 2008.05.22 upd start -------------------------------------->>
                        //sqlCommand.CommandText = "SELECT * FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY SECTIONCODERF";
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                        sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                        sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                        sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.22 upd end ----------------------------------------<<
                    }
                    SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(secinfosetWork.EnterpriseCode);

                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        SecInfoSetWork wkSecInfoSetWork = new SecInfoSetWork();

                        wkSecInfoSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        wkSecInfoSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        wkSecInfoSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        wkSecInfoSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        wkSecInfoSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        wkSecInfoSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        wkSecInfoSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        wkSecInfoSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        wkSecInfoSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                        wkSecInfoSetWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                        wkSecInfoSetWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));  // 2008.05.22 add
                        wkSecInfoSetWork.CompanyNameCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYNAMECD1RF"));
                        wkSecInfoSetWork.MainOfficeFuncFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINOFFICEFUNCFLAGRF"));
                        wkSecInfoSetWork.IntroductionDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INTRODUCTIONDATERF")); // 2008.05.22 add
                        // �� 20070926 980081 a
                        wkSecInfoSetWork.SectWarehouseCd1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD1RF"));
                        wkSecInfoSetWork.SectWarehouseCd2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD2RF"));
                        wkSecInfoSetWork.SectWarehouseCd3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD3RF"));
                        // �� 20070926 980081 a

                        al.Add(wkSecInfoSetWork);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    sqlCommand.Cancel();
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }

            if (!myReader.IsClosed) myReader.Close();

            retList = al;

            return status;

        }
        // �� 2007.12.17 980081 a

		/// <summary>
		/// �w�肳�ꂽ���_�R�[�h�̋��_���ݒ��߂��܂�
		/// </summary>
		/// <param name="parabyte">SecInfoSetWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		public int Read(ref byte[] parabyte , int readMode)
		{
            return this.ReadProc(ref parabyte, readMode);
        }
        /// <summary>
        /// �w�肳�ꂽ���_�R�[�h�̋��_���ݒ��߂��܂�
        /// </summary>
        /// <param name="parabyte">SecInfoSetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        private int ReadProc(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			SecInfoSetWork secinfosetWork = new SecInfoSetWork();
			try
			{
				//�R�l�N�V����������擾�Ή�����������
				//���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
				//���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;
				//�R�l�N�V����������擾�Ή�����������

				// XML�̓ǂݍ���
				secinfosetWork = (SecInfoSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SecInfoSetWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Select�R�}���h�̐���
                // 2008.05.22 upd start ------------------------------------------->>
				//SqlCommand sqlCommand = new SqlCommand("SELECT * FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.22 upd end ---------------------------------------------<<

				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.EnterpriseCode);
				findParaSectionCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectionCode);

				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				if(myReader.Read())
				{
					secinfosetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					secinfosetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					secinfosetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					secinfosetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					secinfosetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					secinfosetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					secinfosetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					secinfosetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
					secinfosetWork.SectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONCODERF"));
					secinfosetWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    secinfosetWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));                 // 2008.05.22 add
					secinfosetWork.CompanyNameCd1 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD1RF"));
                    secinfosetWork.MainOfficeFuncFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINOFFICEFUNCFLAGRF"));
                    secinfosetWork.IntroductionDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INTRODUCTIONDATERF")); // 2008.05.22 add
                    // �� 20070926 980081 a
                    secinfosetWork.SectWarehouseCd1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD1RF"));
                    secinfosetWork.SectWarehouseCd2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD2RF"));
                    secinfosetWork.SectWarehouseCd3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD3RF"));
                    // �� 20070926 980081 a

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
				// XML�֕ϊ����A������̃o�C�i����
				parabyte = XmlByteSerializer.Serialize(secinfosetWork);
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"SecInfoSetDB.Read Exception="+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Close();
					sqlConnection.Dispose();
				}
			}

			return status;
		}

		/// <summary>
		/// ���_���ݒ����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">SecInfoSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		public int Write(ref byte[] parabyte)
		{
            return this.WriteProc(ref parabyte);
        }
        /// <summary>
        /// ���_���ݒ����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="parabyte">SecInfoSetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        private int WriteProc(ref byte[] parabyte)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			try
			{
				//�R�l�N�V����������擾�Ή�����������
				//���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
				//���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;
				//�R�l�N�V����������擾�Ή�����������

				// XML�̓ǂݍ���
				SecInfoSetWork secinfosetWork = (SecInfoSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SecInfoSetWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Select�R�}���h�̐���
                // 2008.05.22 upd start ------------------------------------------------>>
				//SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, SECTIONCODERF FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.22 upd end --------------------------------------------------<<

				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.EnterpriseCode);
				findParaSectionCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectionCode);

                sqlTxt = string.Empty; // 2008.05.22 add

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
					if (_updateDateTime != secinfosetWork.UpdateDateTime)
					{
						//�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
						if (secinfosetWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
							//�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
						else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						sqlCommand.Cancel();
						if(!myReader.IsClosed)myReader.Close();
						sqlConnection.Close();
						return status;
					}

                    // 2008.05.22 upd start -------------------------------------->>
					// �� 20070926 980081 c
                    //sqlCommand.CommandText = "UPDATE SECINFOSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , OTHRSLIPCOMPANYNMCDRF=@OTHRSLIPCOMPANYNMCD , SECTIONGUIDENMRF=@SECTIONGUIDENM , MAINOFFICEFUNCFLAGRF=@MAINOFFICEFUNCFLAG , SECCDFORNUMBERINGRF=@SECCDFORNUMBERING , COMPANYNAMECD1RF=@COMPANYNAMECD1 , COMPANYNAMECD2RF=@COMPANYNAMECD2 , COMPANYNAMECD3RF=@COMPANYNAMECD3 , COMPANYNAMECD4RF=@COMPANYNAMECD4 , COMPANYNAMECD5RF=@COMPANYNAMECD5 , COMPANYNAMECD6RF=@COMPANYNAMECD6 , COMPANYNAMECD7RF=@COMPANYNAMECD7 , COMPANYNAMECD8RF=@COMPANYNAMECD8 , COMPANYNAMECD9RF=@COMPANYNAMECD9 , COMPANYNAMECD10RF=@COMPANYNAMECD10 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                    //sqlCommand.CommandText = "UPDATE SECINFOSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , OTHRSLIPCOMPANYNMCDRF=@OTHRSLIPCOMPANYNMCD , SECTIONGUIDENMRF=@SECTIONGUIDENM , MAINOFFICEFUNCFLAGRF=@MAINOFFICEFUNCFLAG , SECCDFORNUMBERINGRF=@SECCDFORNUMBERING , COMPANYNAMECD1RF=@COMPANYNAMECD1 , COMPANYNAMECD2RF=@COMPANYNAMECD2 , COMPANYNAMECD3RF=@COMPANYNAMECD3 , COMPANYNAMECD4RF=@COMPANYNAMECD4 , COMPANYNAMECD5RF=@COMPANYNAMECD5 , COMPANYNAMECD6RF=@COMPANYNAMECD6 , COMPANYNAMECD7RF=@COMPANYNAMECD7 , COMPANYNAMECD8RF=@COMPANYNAMECD8 , COMPANYNAMECD9RF=@COMPANYNAMECD9 , COMPANYNAMECD10RF=@COMPANYNAMECD10 , SECTWAREHOUSECD1RF=@SECTWAREHOUSECD1 , SECTWAREHOUSENM1RF=@SECTWAREHOUSENM1 , SECTWAREHOUSECD2RF=@SECTWAREHOUSECD2 , SECTWAREHOUSENM2RF=@SECTWAREHOUSENM2 , SECTWAREHOUSECD3RF=@SECTWAREHOUSECD3 , SECTWAREHOUSENM3RF=@SECTWAREHOUSENM3 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                    sqlTxt += "UPDATE SECINFOSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                    sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                    sqlTxt += " , SECTIONGUIDENMRF=@SECTIONGUIDENM" + Environment.NewLine;
                    sqlTxt += " , SECTIONGUIDESNMRF=@SECTIONGUIDESNM" + Environment.NewLine;
                    sqlTxt += " , COMPANYNAMECD1RF=@COMPANYNAMECD1" + Environment.NewLine;
                    sqlTxt += " , MAINOFFICEFUNCFLAGRF=@MAINOFFICEFUNCFLAG" + Environment.NewLine;
                    sqlTxt += " , INTRODUCTIONDATERF=@INTRODUCTIONDATE" + Environment.NewLine;
                    sqlTxt += " , SECTWAREHOUSECD1RF=@SECTWAREHOUSECD1" + Environment.NewLine;
                    sqlTxt += " , SECTWAREHOUSECD2RF=@SECTWAREHOUSECD2" + Environment.NewLine;
                    sqlTxt += " , SECTWAREHOUSECD3RF=@SECTWAREHOUSECD3" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                    sqlCommand.CommandText = sqlTxt;
                    // �� 20070926 980081 c
                    // 2008.05.22 upd end ----------------------------------------<<
					//KEY�R�}���h���Đݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.EnterpriseCode);
					findParaSectionCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectionCode);

					//�X�V�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)secinfosetWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					if (secinfosetWork.UpdateDateTime > DateTime.MinValue)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						sqlCommand.Cancel();
						if(!myReader.IsClosed)myReader.Close();
						sqlConnection.Close();
						return status;
					}

					//�V�K�쐬����SQL���𐶐�
                    // 2008.05.22 upd start -------------------------------------------------->>
					// �� 20070926 980081 c
                    //sqlCommand.CommandText = "INSERT INTO SECINFOSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, OTHRSLIPCOMPANYNMCDRF, SECTIONGUIDENMRF, MAINOFFICEFUNCFLAGRF, SECCDFORNUMBERINGRF, COMPANYNAMECD1RF, COMPANYNAMECD2RF, COMPANYNAMECD3RF, COMPANYNAMECD4RF, COMPANYNAMECD5RF, COMPANYNAMECD6RF, COMPANYNAMECD7RF, COMPANYNAMECD8RF, COMPANYNAMECD9RF, COMPANYNAMECD10RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @OTHRSLIPCOMPANYNMCD, @SECTIONGUIDENM, @MAINOFFICEFUNCFLAG, @SECCDFORNUMBERING, @COMPANYNAMECD1, @COMPANYNAMECD2, @COMPANYNAMECD3, @COMPANYNAMECD4, @COMPANYNAMECD5, @COMPANYNAMECD6, @COMPANYNAMECD7, @COMPANYNAMECD8, @COMPANYNAMECD9, @COMPANYNAMECD10)";
                    //sqlCommand.CommandText = "INSERT INTO SECINFOSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, OTHRSLIPCOMPANYNMCDRF, SECTIONGUIDENMRF, MAINOFFICEFUNCFLAGRF, SECCDFORNUMBERINGRF, COMPANYNAMECD1RF, COMPANYNAMECD2RF, COMPANYNAMECD3RF, COMPANYNAMECD4RF, COMPANYNAMECD5RF, COMPANYNAMECD6RF, COMPANYNAMECD7RF, COMPANYNAMECD8RF, COMPANYNAMECD9RF, COMPANYNAMECD10RF, SECTWAREHOUSECD1RF, SECTWAREHOUSENM1RF, SECTWAREHOUSECD2RF, SECTWAREHOUSENM2RF, SECTWAREHOUSECD3RF, SECTWAREHOUSENM3RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @OTHRSLIPCOMPANYNMCD, @SECTIONGUIDENM, @MAINOFFICEFUNCFLAG, @SECCDFORNUMBERING, @COMPANYNAMECD1, @COMPANYNAMECD2, @COMPANYNAMECD3, @COMPANYNAMECD4, @COMPANYNAMECD5, @COMPANYNAMECD6, @COMPANYNAMECD7, @COMPANYNAMECD8, @COMPANYNAMECD9, @COMPANYNAMECD10, @SECTWAREHOUSECD1, @SECTWAREHOUSENM1, @SECTWAREHOUSECD2, @SECTWAREHOUSENM2, @SECTWAREHOUSECD3, @SECTWAREHOUSENM3)";
                    // �� 20070926 980081 c
                    sqlTxt += "INSERT INTO SECINFOSETRF" + Environment.NewLine;
                    sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                    sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                    sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                    sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                    sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                    sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                    sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                    sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                    sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
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
                    sqlTxt += "    ,@SECTIONCODE" + Environment.NewLine;
                    sqlTxt += "    ,@SECTIONGUIDENM" + Environment.NewLine;
                    sqlTxt += "    ,@SECTIONGUIDESNM" + Environment.NewLine;
                    sqlTxt += "    ,@COMPANYNAMECD1" + Environment.NewLine;
                    sqlTxt += "    ,@MAINOFFICEFUNCFLAG" + Environment.NewLine;
                    sqlTxt += "    ,@INTRODUCTIONDATE" + Environment.NewLine;
                    sqlTxt += "    ,@SECTWAREHOUSECD1" + Environment.NewLine;
                    sqlTxt += "    ,@SECTWAREHOUSECD2" + Environment.NewLine;
                    sqlTxt += "    ,@SECTWAREHOUSECD3" + Environment.NewLine;
                    sqlTxt += " )" + Environment.NewLine;
                    sqlCommand.CommandText = sqlTxt;
                    // 2008.05.22 upd end ----------------------------------------------------<<
                    //�o�^�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)secinfosetWork;
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
				SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
				SqlParameter paraSectionGuideNm = sqlCommand.Parameters.Add("@SECTIONGUIDENM", SqlDbType.NVarChar);
                SqlParameter paraSectionGuideSnm = sqlCommand.Parameters.Add("@SECTIONGUIDESNM", SqlDbType.NVarChar);   // 2008.05.22 add
				SqlParameter paraCompanyNameCd1 = sqlCommand.Parameters.Add("@COMPANYNAMECD1", SqlDbType.Int);
                SqlParameter paraMainOfficeFuncFlag = sqlCommand.Parameters.Add("@MAINOFFICEFUNCFLAG", SqlDbType.Int);
                SqlParameter paraIntroductionDate = sqlCommand.Parameters.Add("@INTRODUCTIONDATE", SqlDbType.Int);      // 2008.05.22 add
                // �� 20070926 980081 a
                SqlParameter paraSectWarehouseCd1 = sqlCommand.Parameters.Add("@SECTWAREHOUSECD1", SqlDbType.NChar);
                SqlParameter paraSectWarehouseCd2 = sqlCommand.Parameters.Add("@SECTWAREHOUSECD2", SqlDbType.NChar);
                SqlParameter paraSectWarehouseCd3 = sqlCommand.Parameters.Add("@SECTWAREHOUSECD3", SqlDbType.NChar);
                // �� 20070926 980081 a

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(secinfosetWork.CreateDateTime);
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(secinfosetWork.UpdateDateTime);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.EnterpriseCode);
				paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(secinfosetWork.FileHeaderGuid);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(secinfosetWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(secinfosetWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(secinfosetWork.LogicalDeleteCode);
				paraSectionCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectionCode);
				paraSectionGuideNm.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectionGuideNm);
                paraSectionGuideSnm.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectionGuideSnm);      // 2008.05.22 add
				paraCompanyNameCd1.Value = SqlDataMediator.SqlSetInt32(secinfosetWork.CompanyNameCd1);
                paraMainOfficeFuncFlag.Value = SqlDataMediator.SqlSetInt32(secinfosetWork.MainOfficeFuncFlag);
                paraIntroductionDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(secinfosetWork.IntroductionDate);     // 2008.05.22 add
                // �� 20070926 980081 a
                paraSectWarehouseCd1.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectWarehouseCd1);
                paraSectWarehouseCd2.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectWarehouseCd2);
                paraSectWarehouseCd3.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectWarehouseCd3);
                // �� 20070926 980081 a

				sqlCommand.ExecuteNonQuery();

				// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
				parabyte = XmlByteSerializer.Serialize(secinfosetWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"SecInfoSetDB.Write Exception="+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Close();
					sqlConnection.Dispose();
				}
			}

			return status;
		}

		/// <summary>
		/// ���_���ݒ����_���폜���܂�
		/// </summary>
		/// <param name="parabyte">SecInfoSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		public int LogicalDelete(ref byte[] parabyte)
		{
			return  LogicalDeleteProc(ref parabyte,0);
		}

		/// <summary>
		/// �_���폜���_���ݒ���𕜊����܂�
		/// </summary>
		/// <param name="parabyte">SecInfoSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		public int RevivalLogicalDelete(ref byte[] parabyte)
		{
			return LogicalDeleteProc(ref parabyte,1);
		}

		/// <summary>
		/// ���_���ݒ���̘_���폜�𑀍삵�܂�
		/// </summary>
		/// <param name="parabyte">SecInfoSetWork�I�u�W�F�N�g</param>
		/// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
		/// <returns>STATUS</returns>
		private int LogicalDeleteProc(ref byte[] parabyte,int procMode)
		{

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int logicalDelCd = 0;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			try		
			{
				//�R�l�N�V����������擾�Ή�����������
				//���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
				//���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;
				//�R�l�N�V����������擾�Ή�����������

				// XML�̓ǂݍ���
				SecInfoSetWork secinfosetWork = (SecInfoSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SecInfoSetWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                // 2008.05.22 upd start --------------------------------------------->>
				//using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, SECTIONCODERF FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection))
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                // 2008.05.22 upd end -----------------------------------------------<<
                {
					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.EnterpriseCode);
					findParaSectionCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectionCode);

					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
						DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
						if (_updateDateTime != secinfosetWork.UpdateDateTime)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
							sqlConnection.Close();
							return status;
						}
						//���݂̘_���폜�敪���擾
						logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                        // 2008.05.22 upd start --------------------------------------------->>
						//sqlCommand.CommandText = "UPDATE SECINFOSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                        sqlTxt += "UPDATE SECINFOSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.22 upd end -----------------------------------------------<<
                        //KEY�R�}���h���Đݒ�
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.EnterpriseCode);
						findParaSectionCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectionCode);

						//�X�V�w�b�_����ݒ�
						object obj = (object)this;
						IFileHeader flhd = (IFileHeader)secinfosetWork;
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
						else if	(logicalDelCd == 0)	secinfosetWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
						else						secinfosetWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
					}
					else
					{
						if		(logicalDelCd == 1)	secinfosetWork.LogicalDeleteCode = 0;//�_���폜�t���O������
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
					paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(secinfosetWork.UpdateDateTime);
					paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.UpdEmployeeCode);
					paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(secinfosetWork.UpdAssemblyId1);
					paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(secinfosetWork.UpdAssemblyId2);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(secinfosetWork.LogicalDeleteCode);

					sqlCommand.ExecuteNonQuery();

					// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
					parabyte = XmlByteSerializer.Serialize(secinfosetWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"SecInfoSetDB.LogicalDeleteProc Exception="+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Close();
					sqlConnection.Dispose();
				}
			}

			return status;

		}

		/// <summary>
		/// ���_���ݒ���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">���_���ݒ�I�u�W�F�N�g</param>
		/// <returns></returns>
        public int Delete(byte[] parabyte)
        {
            return this.DeleteProc(parabyte);
        }
        /// <summary>
		/// ���_���ݒ���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">���_���ݒ�I�u�W�F�N�g</param>
		/// <returns></returns>
        private int DeleteProc(byte[] parabyte)
        {
        
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			try
			{
				//�R�l�N�V����������擾�Ή�����������
				//���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
				//���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;
				//�R�l�N�V����������擾�Ή�����������

				// XML�̓ǂݍ���
				SecInfoSetWork secinfosetWork = (SecInfoSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SecInfoSetWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                // 2008.05.22 upd start ---------------------------------------------->>
				//using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, SECTIONCODERF FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection))
				string sqlTxt = string.Empty;
                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                using(SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                // 2008.05.22 upd end ------------------------------------------------<<
                {
					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.EnterpriseCode);
					findParaSectionCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectionCode);

					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
						DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
						if (_updateDateTime != secinfosetWork.UpdateDateTime)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
							sqlConnection.Close();
							return status;
						}

                        // 2008.05.22 upd start ------------------------------->>
						//sqlCommand.CommandText = "DELETE FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                        sqlTxt = string.Empty;
                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt; 
                        // 2008.05.22 upd end ---------------------------------<<
                        //KEY�R�}���h���Đݒ�
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.EnterpriseCode);
						findParaSectionCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectionCode);
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
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"SecInfoSetDB.Delete Exception="+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Close();
					sqlConnection.Dispose();
				}
			}
			
			return status;
		}

        #region [GetSyncdataList]
        /// <summary>
        /// ���[�J���V���N�p�̃f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="arraylistdata">��������</param>
        /// <param name="syncServiceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�啪�ރ}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20096 �����@��
        /// ��</br>
        /// <br>Date       : 2007.05.08</br>
        public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            return this.GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
        }
        /// <summary>
        /// ���[�J���V���N�p�̃f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="arraylistdata">��������</param>
        /// <param name="syncServiceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�啪�ރ}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20096 �����@��
        /// ��</br>
        /// <br>Date       : 2007.05.08</br>
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                // 2008.05.22 upd start ------------------------------->>
                //sqlCommand = new SqlCommand("SELECT * FROM SECINFOSETRF  ", sqlConnection);
                string sqlTxt = string.Empty; 
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.22 upd end ---------------------------------<<

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToSecInfoSetWorkFromReader(ref myReader));

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

        #region [�V���N�pWhere���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="syncServiceWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 20096 �����@����</br>
        /// <br>Date       : 2007.05.08</br>
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
        /// �N���X�i�[���� Reader �� SecInfoSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SecInfoSetWork</returns>
        /// <remarks>
        /// <br>Programmer : 20096 �����@����</br>
        /// <br>Date       : 2007.05.09</br>
        /// </remarks>
        private SecInfoSetWork CopyToSecInfoSetWorkFromReader(ref SqlDataReader myReader)
        {
            SecInfoSetWork wkSecInfoSetWork = new SecInfoSetWork();

            #region �N���X�֊i�[
            wkSecInfoSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkSecInfoSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkSecInfoSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkSecInfoSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkSecInfoSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkSecInfoSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkSecInfoSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkSecInfoSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkSecInfoSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkSecInfoSetWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            wkSecInfoSetWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));  // 2008.05.22 add
            wkSecInfoSetWork.CompanyNameCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYNAMECD1RF"));
            wkSecInfoSetWork.MainOfficeFuncFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINOFFICEFUNCFLAGRF"));
            wkSecInfoSetWork.IntroductionDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INTRODUCTIONDATERF")); // 2008.05.22 add
            // �� 20070926 980081 a
            wkSecInfoSetWork.SectWarehouseCd1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD1RF"));
            wkSecInfoSetWork.SectWarehouseCd2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD2RF"));
            wkSecInfoSetWork.SectWarehouseCd3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD3RF"));
            // �� 20070926 980081 a
            #endregion

            return wkSecInfoSetWork;
        }
        #endregion


	}
}