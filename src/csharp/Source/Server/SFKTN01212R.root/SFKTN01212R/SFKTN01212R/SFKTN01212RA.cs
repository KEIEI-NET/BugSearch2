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
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���_��񃊃��[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���_���ݒ�̎��f�[�^������s���N���X�ł��B</br>
	/// <br>Programmer : 21015�@�����@�F��</br>
	/// <br>Date       : 2005.08.06</br>
	/// <br>---------------------------------------------------------</br>
	/// <br>Update Note: ���Ж��̃}�X�^���C�A�E�g�ύX�Ή�</br>
    /// <br>Programmer : 20036�@�ē��@�떾</br>
    /// <br>Date       : 2007.05.16</br>
	/// <br>---------------------------------------------------------</br>
	/// <br>Update Note: ���_���ݒ�}�X�^���C�A�E�g�ύX�Ή�</br>
	/// <br>Programmer : 21024�@���X�� ��</br>
	/// <br>Date       : 2007.10.15</br>
    /// <br>---------------------------------------------------------</br>
    /// <br>Update Note: �o�l.�m�r�p�ɕύX</br>
    /// <br>Programmer : 20081�@�D�c �E�l</br>
    /// <br>Date       : 2008.06.05</br>
    /// </remarks>
	[Serializable]
	public class SectionInfo : RemoteDB , ISectionInfo
	{
		
		/// <summary>
		/// ���_��񃊃��[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.08.06</br>
		/// </remarks>
		public SectionInfo() :
		base("SFKTN09006D", "Broadleaf.Application.Remoting.ParamData.SecInfoSetWork", "SECINFOSETRF")
		{
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̋��_���LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="searchRetList">��������</param>
		/// <param name="secInfoSetWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="errorLevel">�G���[���x��</param>
		/// <param name="errorCode">�G���[�R�[�h</param>
		/// <param name="errorMessage">�G���[���b�Z�[�W</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̋��_���LIST��S�Ė߂��܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.08.06</br>
        public int Search(out object searchRetList, object secInfoSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, out int errorLevel, out string errorCode, out string errorMessage)
		{
			// STATUS������
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            searchRetList = null;
			errorLevel = 0;
			errorCode = "";
			errorMessage = "";
            SqlConnection sqlConnection = null; //2006.06.21 kane add
            CustomSerializeArrayList retList = null; //2006.06.21 kane add

			SecInfoSetWork _secInfoSetWork = secInfoSetWork as SecInfoSetWork;
			if(_secInfoSetWork == null)
			{
				base.WriteErrorLog("�v���O�����G���[�B�p�����[�^�����ݒ�ł� : SectionInfo.Search");
				return status;
			}

            try
            {
                //2006.06.21 kane add start >>>
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //�R�l�N�V����������擾�Ή�����������

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                //2006.06.21 kane add end   <<<

                //status = SearchProc(out SecInfoSetWork, _secInfoSetWork, readMode, logicalMode, out errorLevel, out errorCode, out errorMessage);//2006.06.21 kane del
                status = SearchProc(out retList, _secInfoSetWork, readMode, logicalMode, out errorLevel, out errorCode, out errorMessage, ref sqlConnection);//2006.06.21 kane add
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SectionInfo.SearchSecInfoSetProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            searchRetList = retList;//2006.06.21 kane add
			return status;
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̋��_���LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="SecInfoSetWork">��������</param>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="SectionCode">���_�R�[�h</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="errorLevel">�G���[���x��</param>
		/// <param name="errorCode">�G���[�R�[�h</param>
		/// <param name="errorMessage">�G���[���b�Z�[�W</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̋��_���LIST��S�Ė߂��܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.08.06</br>
		public int Search(out object SecInfoSetWork, string EnterpriseCode, string SectionCode, int readMode,ConstantManagement.LogicalMode logicalMode,out int errorLevel,out string errorCode,out string errorMessage)
		{
			SecInfoSetWork _secInfoSetWork = new SecInfoSetWork();
			_secInfoSetWork.EnterpriseCode = EnterpriseCode;
			//return SearchProc(out SecInfoSetWork,_secInfoSetWork,readMode,logicalMode,out errorLevel,out errorCode,out errorMessage);//2006.06.21 kane del
            return Search(out SecInfoSetWork, _secInfoSetWork, readMode, logicalMode, out errorLevel, out errorCode, out errorMessage);//2006.06.21 kane add
		}

		private int SearchSecInfoSetProc(out ArrayList secInfoSetWorkList, SecInfoSetWork secInfoSetWork, int CtrlFuncCode, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			secInfoSetWorkList = new ArrayList();
			try
			{
				//�R�l�N�V����������擾�Ή�����������
				//���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
				//���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;
				//�R�l�N�V����������擾�Ή�����������

				//SQL������
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();				

				sqlCommand = new SqlCommand("SELECT * FROM SECINFOSETRF " 
				,sqlConnection);

				//WHERE���̍쐬
				sqlCommand.CommandText += MakeWhereString(ref sqlCommand,secInfoSetWork,logicalMode);

				//ORDER BY�̎w��
				sqlCommand.CommandText += "ORDER BY SECINFOSETRF.ENTERPRISECODERF ,SECINFOSETRF.SECTIONCODERF";
				
				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				while(myReader.Read())
				{
					//---���_���ݒ�
					SecInfoSetWork wkSecInfoSetWork = CopyToSecInfoSetFromReader(myReader);
					secInfoSetWorkList.Add(wkSecInfoSetWork);

				}

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch(SqlException ex)
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"SectionInfo.SearchSecInfoSetProc Exception="+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(sqlCommand != null)sqlCommand.Dispose();
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
        /// 
        /// </summary>
        /// <param name="retList"></param>
        /// <param name="secInfoSetWork"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="readMode"></param>
        /// <param name="logicalMode"></param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̋��_�n����S�Ė߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2006.06.21</br>
        public int Search(out CustomSerializeArrayList retList, SecInfoSetWork secInfoSetWork, ref SqlConnection sqlConnection, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int errorLevel = 0;
            string errorCode = "";
            string errorMessage = "";
            retList = null;
            if (secInfoSetWork == null)
            {
                base.WriteErrorLog("�v���O�����G���[�B�p�����[�^�����ݒ�ł� : SectionInfo.Search");
                return status;
            }

            status = SearchProc(out retList, secInfoSetWork, readMode, logicalMode, out errorLevel, out errorCode, out errorMessage , ref sqlConnection);

            return status;
        }

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̋��_���LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="searchRetCSArrayList">��������</param>
		/// <param name="secInfoSetWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="errorLevel">�G���[���x��</param>
		/// <param name="errorCode">�G���[�R�[�h</param>
		/// <param name="errorMessage">�G���[���b�Z�[�W</param>
		/// <param name="sqlConnection">�R�l�N�V����</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̋��_���LIST��S�Ė߂��܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.07.04</br>
        //private int SearchProc(out object searchRetCSArrayList, SecInfoSetWork secInfoSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, out int errorLevel, out string errorCode, out string errorMessage)//2006.06.21 kane del
        private int SearchProc(out CustomSerializeArrayList searchRetCSArrayList, SecInfoSetWork secInfoSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, out int errorLevel, out string errorCode, out string errorMessage, ref SqlConnection sqlConnection)//2006.06.21 kane add
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			//SqlConnection sqlConnection = null;//2006.06.21 kane del
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;;

			errorLevel		= 0;
			errorCode		= "";
			errorMessage	= "";

			searchRetCSArrayList = null;
			
			//�߂�l�i�[�p
			CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

			try 
			{	
                //2006.06.21 kane del start >>>
                ////�R�l�N�V����������擾�Ή�����������
                ////���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                ////���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                //if (connectionText == null || connectionText == "") return status;
                ////�R�l�N�V����������擾�Ή�����������

                ////SQL������
                //sqlConnection = new SqlConnection(connectionText);
                //sqlConnection.Open();				
                //2006.06.21 kane del end   <<<
				
				//-------------------
				//���ʊi�[�pArrayList
				//-------------------
				//���_���ݒ�
				ArrayList SecInfoSetWorkList = new ArrayList();
				//���Ж���
				ArrayList CompanyNmWorkList = new ArrayList();

				//Select��̐���
				string SelectString = MakeSelectString(secInfoSetWork,0);
				using(sqlCommand = new SqlCommand(SelectString ,sqlConnection))
				{
					//WHERE���̍쐬
					sqlCommand.CommandText += MakeWhereString(ref sqlCommand,secInfoSetWork,logicalMode);

				
					//ORDER BY�̎w��
					sqlCommand.CommandText += "ORDER BY SECINFOSETRF.ENTERPRISECODERF ,SECINFOSETRF.SECTIONCODERF";
				
					myReader = sqlCommand.ExecuteReader();
					while(myReader.Read())
					{
						//---���_���ݒ�
						SecInfoSetWork wkSecInfoSetWork = CopyToSecInfoSetFromReader(myReader);
						if(SecInfoSetWorkList.Count <= 0)
							SecInfoSetWorkList.Add(wkSecInfoSetWork);
						else if(wkSecInfoSetWork.SectionCode != ((SecInfoSetWork)SecInfoSetWorkList[SecInfoSetWorkList.Count-1]).SectionCode)
							SecInfoSetWorkList.Add(wkSecInfoSetWork);

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				
					if(myReader.IsClosed == false)myReader.Close();
				
					sqlCommand.CommandText = "SELECT * FROM COMPANYNMRF WHERE ENTERPRISECODERF=@ENTERPRISECODE";

					myReader = sqlCommand.ExecuteReader();

					while(myReader.Read())
					{
						//---���Ж���
						CompanyNmWork wkCompanyNmWork = CopyToCompanyNmFromReader(myReader);
						CompanyNmWorkList.Add(wkCompanyNmWork);
					}

					customSerializeArrayList.Add(SecInfoSetWorkList);
					customSerializeArrayList.Add(CompanyNmWorkList);
				}
			}			
			catch (SqlException ex)
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
				//�G���[�̏ꍇ�ݒ肵�܂�(���݉�)
				errorLevel		= ex.LineNumber;
				errorCode		= ex.Number.ToString();
				errorMessage	= ex.Message;
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"SectionInfo.SearchProc Exception="+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				//errorLevel = status;
				errorCode = status.ToString(); 
				errorMessage = ex.Message;
			}
			finally
			{
				if(sqlCommand != null)sqlCommand.Dispose();
				if(!myReader.IsClosed)myReader.Close();
                //2006.06.21 kane del start >>>
                //if(sqlConnection != null)
                //{
                //    sqlConnection.Close();
                //    sqlConnection.Dispose();
                //}
                //2006.06.21 kane del end   <<<
			}
			
			searchRetCSArrayList = customSerializeArrayList;
	

			return status;
		}


		/// <summary>
		/// Select����������
		/// </summary>
		/// <param name="secInfoSetWork">���������i�[�N���X</param>
		/// <param name="mode"></param>
		/// <returns>Select������</returns>
		/// <br>Note       : Select���̐������s���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.07.04</br>
		private string MakeSelectString(SecInfoSetWork secInfoSetWork, int mode)
		{
			//���_���ݒ�A���_����ݒ�A���Ж��̂̂R�̃}�X�^���������đS�Ă̏����擾���܂��B
			string retstring = "SELECT * FROM SECINFOSETRF ";
			return retstring;
		}

		/// <summary>
		/// �������������񐶐��{�����l�ݒ�
		/// </summary>
		/// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
		/// <param name="secInfoSetWork">���������i�[�N���X</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>Where����������</returns>
		/// <br>Note       : �������������񐶐��{�����l�ݒ���s���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.07.04</br>
		private string MakeWhereString(ref SqlCommand sqlCommand,SecInfoSetWork secInfoSetWork,ConstantManagement.LogicalMode logicalMode)
		{
			string retstring = "WHERE ";

			//��ƃR�[�h
			retstring += "SECINFOSETRF.ENTERPRISECODERF=@ENTERPRISECODE ";
			SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
			paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(secInfoSetWork.EnterpriseCode);

			//�_���폜�敪
			string logidelstr = "";
			if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
				(logicalMode == ConstantManagement.LogicalMode.GetData1)||
				(logicalMode == ConstantManagement.LogicalMode.GetData2)||
				(logicalMode == ConstantManagement.LogicalMode.GetData3))
			{
				logidelstr = "AND SECINFOSETRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
			}
			else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
				(logicalMode == ConstantManagement.LogicalMode.GetData012))
			{
				logidelstr = "AND SECINFOSETRF.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
			}
			if(logidelstr != "")
			{
				retstring += logidelstr;
				SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
			}

			return retstring;
		}

		/// <summary>
		/// DataReader����SecInfoSetWork�N���X�֒l���ڂ��܂�
		/// </summary>
		/// <param name="myReader"></param>
        /// <returns>SecInfoSetWork</returns>
		/// <remarks>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.08.06</br>
		/// </remarks>
		private SecInfoSetWork CopyToSecInfoSetFromReader(SqlDataReader myReader)
		{
			SecInfoSetWork wkSecInfoSetWork = new SecInfoSetWork();
			#region �N���X�֑��
			wkSecInfoSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
			wkSecInfoSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
			wkSecInfoSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
			wkSecInfoSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
			wkSecInfoSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
			wkSecInfoSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
			wkSecInfoSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
			wkSecInfoSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
			wkSecInfoSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONCODERF"));
			//wkSecInfoSetWork.OthrSlipCompanyNmCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("OTHRSLIPCOMPANYNMCDRF")); // 2008.06.05 del
			wkSecInfoSetWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONGUIDENMRF"));
            wkSecInfoSetWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));         // 2008.06.05 add  
            wkSecInfoSetWork.CompanyNameCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYNAMECD1RF"));
            wkSecInfoSetWork.MainOfficeFuncFlag = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("MAINOFFICEFUNCFLAGRF"));
            wkSecInfoSetWork.IntroductionDate = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("INTRODUCTIONDATERF"));        // 2008.06.05 add  
            //wkSecInfoSetWork.SecCdForNumbering = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECCDFORNUMBERINGRF"));    // 2008.06.05 del
			
            // 2008.06.05 del start --------------------------------------------------------->>
            //wkSecInfoSetWork.CompanyNameCd2 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD2RF"));
            //wkSecInfoSetWork.CompanyNameCd3 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD3RF"));
            //wkSecInfoSetWork.CompanyNameCd4 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD4RF"));
            //wkSecInfoSetWork.CompanyNameCd5 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD5RF"));
            //wkSecInfoSetWork.CompanyNameCd6 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD6RF"));
            //wkSecInfoSetWork.CompanyNameCd7 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD7RF"));
            //wkSecInfoSetWork.CompanyNameCd8 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD8RF"));
            //wkSecInfoSetWork.CompanyNameCd9 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD9RF"));
            //wkSecInfoSetWork.CompanyNameCd10 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD10RF"));
            // 2008.06.05 del end -----------------------------------------------------------<<
			// 2007.10.15 sasaki >>
			wkSecInfoSetWork.SectWarehouseCd1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD1RF"));
			wkSecInfoSetWork.SectWarehouseCd2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD2RF"));
			wkSecInfoSetWork.SectWarehouseCd3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD3RF"));
            // 2008.06.05 del start --------------------------------------------------------->>
            //wkSecInfoSetWork.SectWarehouseNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSENM1RF"));
            //wkSecInfoSetWork.SectWarehouseNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSENM2RF"));
            //wkSecInfoSetWork.SectWarehouseNm3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSENM3RF"));
            // 2008.06.05 del end -----------------------------------------------------------<<
			// 2007.10.15 sasaki <<
			#endregion
			return wkSecInfoSetWork;
		}
	
		/// <summary>
		/// DataReader����CompanyNmWork�N���X�֒l���ڂ��܂�
		/// </summary>
		/// <param name="myReader"></param>
        /// <returns>CompanyNmWork</returns>
		/// <remarks>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.08.06</br>
		/// </remarks>
		private CompanyNmWork CopyToCompanyNmFromReader(SqlDataReader myReader)
		{
			CompanyNmWork wkCompanyNmWork = new CompanyNmWork();

			#region �N���X�֑��
            wkCompanyNmWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkCompanyNmWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkCompanyNmWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkCompanyNmWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkCompanyNmWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkCompanyNmWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkCompanyNmWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkCompanyNmWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkCompanyNmWork.CompanyNameCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYNAMECDRF"));
            wkCompanyNmWork.CompanyPr = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYPRRF"));
            wkCompanyNmWork.CompanyName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME1RF"));
            wkCompanyNmWork.CompanyName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME2RF"));
            wkCompanyNmWork.PostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
            wkCompanyNmWork.Address1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
            //wkCompanyNmWork.Address2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESS2RF")); // 2008.06.05 del
            wkCompanyNmWork.Address3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
            wkCompanyNmWork.Address4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
            wkCompanyNmWork.CompanyTelNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO1RF"));
            wkCompanyNmWork.CompanyTelNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO2RF"));
            wkCompanyNmWork.CompanyTelNo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO3RF"));
            wkCompanyNmWork.CompanyTelTitle1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE1RF"));
            wkCompanyNmWork.CompanyTelTitle2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE2RF"));
            wkCompanyNmWork.CompanyTelTitle3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE3RF"));
            wkCompanyNmWork.TransferGuidance = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRANSFERGUIDANCERF"));
            wkCompanyNmWork.AccountNoInfo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO1RF"));
            wkCompanyNmWork.AccountNoInfo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO2RF"));
            wkCompanyNmWork.AccountNoInfo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO3RF"));
            wkCompanyNmWork.CompanySetNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYSETNOTE1RF"));
            wkCompanyNmWork.CompanySetNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYSETNOTE2RF"));
            wkCompanyNmWork.ImageInfoDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IMAGEINFODIVRF"));
            wkCompanyNmWork.ImageInfoCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IMAGEINFOCODERF"));
            wkCompanyNmWork.CompanyUrl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYURLRF"));
            wkCompanyNmWork.CompanyPrSentence2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYPRSENTENCE2RF"));
            wkCompanyNmWork.ImageCommentForPrt1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IMAGECOMMENTFORPRT1RF"));
            wkCompanyNmWork.ImageCommentForPrt2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IMAGECOMMENTFORPRT2RF"));
			#endregion
			return wkCompanyNmWork;
		}
	}

}
