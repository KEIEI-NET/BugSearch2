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
	/// �S�̏����lDB�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : �S�̏����l�̎��f�[�^������s���N���X�ł��B</br>
	/// <br>Programmer : 21052�@�R�c�@�\</br>
	/// <br>Date       : 2005.10.03</br>
	/// <br></br>
	/// <br>Update Note: 18322 �ؑ� ����</br>
    /// <br>Date       : 2006.12.05 �g�уV�X�e���p�ɕύX</br>
    /// <br></br>
    /// <br>Update Note: 30005 �،� ��</br>
    /// <br>Date       : 2007.03.05 �V�K���ځu������Ǘ��敪�v�ǉ��̑Ή�</br>
    /// <br></br>
    /// <br>Update Note: 19026�@���R�@����</br>
    /// <br>Date       : 2007.05.23 Sync�Ή�</br>
    /// <br></br>
    /// <br>Update Note: 980081 �R�c ���F</br>
    /// <br>Date       : 2007.08.16 ���ʊ�V�X�e���Ή�</br>
    /// <br></br>
    /// <br>Update Note: 980081 �R�c ���F</br>
    /// <br>Date       : 2007.12.17 ���ڒǉ�(9����)</br>
    /// <br></br>
    /// <br>Update Note: 980081 �R�c ���F</br>
    /// <br>Date       : 2008.01.10 �u�����Ǘ��敪�v�̍폜(���Џ��ݒ�Ɏ��悤�ɕύX)</br>
    /// <br></br>
    /// <br>Update Note: 20081 �D�c �E�l</br>
    /// <br>Date       : 2008.05.27 �o�l.�m�r�p�ɕύX</br>
    /// <br></br>
    /// <br>Update Note: 30531 ��� �r��</br>
    /// <br>Date       : 2010.01.15 �������^�C�v���̏o�͋敪��ǉ�(�R����)</br>
    /// <br>Update Note: zhouyu</br>
    /// <br>Date       : 2011/07/19 �A�� 1028</br>
    /// <br>                  �C�����e�F�A�� 1028 �݌Ɏd�����͂ŁA�i�ԓ��͌�Ɏ����� �d����=�P �ƕ\������A���݌ɐ���������ĕ\���ɂȂ蕪���肸�炢</br>
    /// <br>                  PM7�ł́A�d����=1�ƕ\������d���O�̌��݌���\���A�s�ړ���Ɍ��݌����ĕ\�������</br>
    /// <br>                  ����`�[���́C�d���`�[���� ������</br>
    /// <br>Update Note: ���N</br>
    /// <br>Date       : 2013/05/02</br>
    /// <br>�Ǘ��ԍ�   : 10901273-00 2013/06/18�z�M��</br>
    /// <br>           : Redmine#35434�̑Ή�</br>
    /// </remarks>
	[Serializable]
    public class AllDefSetDB : RemoteDB, IAllDefSetDB, IGetSyncdataList
	{
		/// <summary>
		/// �S�̏����lDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		public AllDefSetDB() :
		base("SFCMN09086D", "Broadleaf.Application.Remoting.ParamData.AllDefSetWork", "ALLDEFSETRF") //���N���X�̃R���X�g���N�^
		{
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̑S�̏����lLIST�̌�����߂��܂�		
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^(readMode=0:AllDefSetWork�N���X�F��ƃR�[�h)</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̑S�̏����lLIST�̌�����߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.03</br>
		public int SearchCnt(out int retCnt,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			return SearchCntProc(out retCnt, parabyte, readMode,logicalMode);
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̑S�̏����lLIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^(readMode=0:AllDefSetWork�N���X�F��ƃR�[�h)</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̑S�̏����lLIST�̌�����߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.03</br>
		private int SearchCntProc(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;								   

			AllDefSetWork alldefsetWork = null;
            string sqlTxt = string.Empty; // 2008.05.27 add

			retCnt = 0;

			ArrayList al = new ArrayList();
			try 
			{	
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

                // XML�̓ǂݍ���
				alldefsetWork = (AllDefSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(AllDefSetWork));

				//SQL������
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				using(SqlCommand sqlCommand = new SqlCommand("",sqlConnection))
				{
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
						(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||
						(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
                        // 2008.05.27 upd start --------------------------------------->>
						//sqlCommand.CommandText = "SELECT COUNT (*) FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
                        sqlTxt += "SELECT COUNT (*)" + Environment.NewLine;
                        sqlTxt += "    FROM ALLDEFSETRF" + Environment.NewLine;
                        sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "        AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.27 upd end -----------------------------------------<<
                        //�_���폜�敪�ݒ�
						SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					}
					else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
					{
                        // 2008.05.27 upd start --------------------------------------->>
						//sqlCommand.CommandText = "SELECT COUNT (*) FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE";
                        sqlTxt += "SELECT COUNT (*)" + Environment.NewLine;
                        sqlTxt += "    FROM ALLDEFSETRF" + Environment.NewLine;
                        sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "        AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.27 upd end -----------------------------------------<<
                        
                        //�_���폜�敪�ݒ�
						SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
						else													    	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
					}
					else 
					{
                        // 2008.05.27 upd start --------------------------------------->>
						//sqlCommand.CommandText = "SELECT COUNT (*) FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
                        sqlTxt += "SELECT COUNT (*)" + Environment.NewLine;
                        sqlTxt += "    FROM ALLDEFSETRF" + Environment.NewLine;
                        sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.27 upd end -----------------------------------------<<
					}
					SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(alldefsetWork.EnterpriseCode);

					//�f�[�^���[�h
					retCnt = (int)sqlCommand.ExecuteScalar();
					if (retCnt > 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"AllDefSetDB.SearchCntProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();
					sqlConnection.Close();
				}
			}

			return status;
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̑S�̏����l��߂��܂�
		/// </summary>
		/// <param name="parabyte">AllDefSetWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̑S�̏����l��߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.03</br>
		public int Read(ref byte[] parabyte , int readMode)
		{
            return this.ReadProc(ref parabyte, readMode);
        }
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̑S�̏����l��߂��܂�
        /// </summary>
        /// <param name="parabyte">AllDefSetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̑S�̏����l��߂��܂�</br>
        /// <br>Programmer : 21052�@�R�c�@�\</br>
        /// <br>Date       : 2005.10.03</br>
        /// <br>Update Note: ���N</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>�Ǘ��ԍ�   : 10901273-00 2013/06/18�z�M��</br>
        /// <br>           : Redmine#35434�̑Ή�</br>
        private int ReadProc(ref byte[] parabyte , int readMode)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			AllDefSetWork alldefsetWork = new AllDefSetWork();

			try 
			{			
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

                // XML�̓ǂݍ���
				alldefsetWork = (AllDefSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(AllDefSetWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Select�R�}���h�̐���
                // 2008.05.27 upd start --------------------------------------->>
				//using(SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection))
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
                sqlTxt += "    ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDSPCUSTTTLDAYRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDSPCUSTCLCTMNYDAYRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDSPCLCTMNYMONTHCDRF" + Environment.NewLine;
                sqlTxt += "    ,INIDSPPRSLORCORPCDRF" + Environment.NewLine;
                sqlTxt += "    ,INITDSPDMDIVRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDSPBILLPRTDIVCDRF" + Environment.NewLine;
                sqlTxt += "    ,ERANAMEDISPCD1RF" + Environment.NewLine;
                sqlTxt += "    ,ERANAMEDISPCD2RF" + Environment.NewLine;
                sqlTxt += "    ,ERANAMEDISPCD3RF" + Environment.NewLine;
                sqlTxt += "    ,GOODSNOINPDIVRF" + Environment.NewLine;
                sqlTxt += "    ,CNSTAXAUTOCORRDIVRF" + Environment.NewLine;
                sqlTxt += "    ,REMAINCNTMNGDIVRF" + Environment.NewLine;
                sqlTxt += "    ,MEMOMOVEDIVRF" + Environment.NewLine;
                sqlTxt += "    ,REMCNTAUTODSPDIVRF" + Environment.NewLine;
                sqlTxt += "    ,TTLAMNTDSPRATEDIVCDRF" + Environment.NewLine;
                // --- ADD  ���r��  2010/01/15 ---------->>>>>
                sqlTxt += "    ,DEFTTLBILLOUTPUTRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDTLBILLOUTPUTRF" + Environment.NewLine;
                sqlTxt += "    ,DEFSLTTLBILLOUTPUTRF" + Environment.NewLine;
                // --- ADD  ���r��  2010/01/15 ----------<<<<<
                sqlTxt += "    ,DTLCALCSTCKCNTDSPRF" + Environment.NewLine; //ADD 2011/07/19
                sqlTxt += "    ,GOODSSTOCKMSTBOOTDIVRF" + Environment.NewLine; // ADD ���N 2013/05/02 Redmine#35434
                sqlTxt += " FROM ALLDEFSETRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                // 2008.05.27 upd end -----------------------------------------<<
                {
					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(alldefsetWork.EnterpriseCode);
					findParaSectionCode.Value = SqlDataMediator.SqlSetString(alldefsetWork.SectionCode);

					myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
					if(myReader.Read())
					{
						alldefsetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
						alldefsetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
						alldefsetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
						alldefsetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
						alldefsetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
						alldefsetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
						alldefsetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
						alldefsetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
						alldefsetWork.SectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONCODERF"));
						// �� 20061128 18322 d
						//alldefsetWork.DistrictCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DISTRICTCODERF"));
						//alldefsetWork.DefDispAddrCd1 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEFDISPADDRCD1RF"));
						//alldefsetWork.DefDispAddrCd2 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEFDISPADDRCD2RF"));
						//alldefsetWork.DefDispAddrCd3 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEFDISPADDRCD3RF"));
						//alldefsetWork.DefDispAddress = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("DEFDISPADDRESSRF"));
						//alldefsetWork.No88AutoLiaCalcDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NO88AUTOLIACALCDIVRF"));
						//alldefsetWork.CarFixSelectMethod = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CARFIXSELECTMETHODRF"));
						// �� 20061128 18322 d
						
						alldefsetWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
						//alldefsetWork.CustCdAutoNumbering = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTCDAUTONUMBERINGRF")); // 2007.05.27 del
                        //alldefsetWork.CustomerDelChkDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERDELCHKDIVCDRF")); // 2007.05.27 del
						alldefsetWork.DefDspCustTtlDay = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEFDSPCUSTTTLDAYRF"));
						alldefsetWork.DefDspCustClctMnyDay = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEFDSPCUSTCLCTMNYDAYRF"));
						alldefsetWork.DefDspClctMnyMonthCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEFDSPCLCTMNYMONTHCDRF"));
						alldefsetWork.IniDspPrslOrCorpCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("INIDSPPRSLORCORPCDRF"));
						alldefsetWork.InitDspDmDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("INITDSPDMDIVRF"));
						alldefsetWork.DefDspBillPrtDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEFDSPBILLPRTDIVCDRF"));
                        // 2007.03.05 added by T-Kidate
                        //alldefsetWork.MemberInfoDispCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MEMBERINFODISPCDRF")); // 2007.05.27 del
                        // �� 2007.08.16 980081 a
                        alldefsetWork.EraNameDispCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD1RF"));
                        alldefsetWork.EraNameDispCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD2RF"));
                        alldefsetWork.EraNameDispCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD3RF"));
                        // �� 2007.08.16 980081 a
                        // �� 2007.12.17 980081 a
                        // �� 2008.01.10 980081 d
                        //alldefsetWork.SecMngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SECMNGDIVRF"));
                        // �� 2008.01.10 980081 d
                        alldefsetWork.GoodsNoInpDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSNOINPDIVRF"));
                        alldefsetWork.CnsTaxAutoCorrDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CNSTAXAUTOCORRDIVRF"));
                        alldefsetWork.RemainCntMngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("REMAINCNTMNGDIVRF"));
                        alldefsetWork.MemoMoveDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MEMOMOVEDIVRF"));
                        alldefsetWork.RemCntAutoDspDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("REMCNTAUTODSPDIVRF"));
                        alldefsetWork.TtlAmntDspRateDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDSPRATEDIVCDRF"));
                        // �� 2007.12.17 980081 a
                        // --- ADD  ���r��  2010/01/15 ---------->>>>>
                        alldefsetWork.DefTtlBillOutput = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFTTLBILLOUTPUTRF"));  // �����\�����v�������o�͋敪
                        alldefsetWork.DefDtlBillOutput = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFDTLBILLOUTPUTRF"));  // �����\�����א������o�͋敪
                        alldefsetWork.DefSlTtlBillOutput = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFSLTTLBILLOUTPUTRF"));  // �����\���`�[���v�������o�͋敪
                        // --- ADD  ���r��  2010/01/15 ----------<<<<<
                        alldefsetWork.DtlCalcStckCntDsp = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DTLCALCSTCKCNTDSPRF"));  //�d���E�o�׌㐔�\���敪 //ADD 2011/07/19
                        alldefsetWork.GoodsStockMstBootDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSSTOCKMSTBOOTDIVRF")); // ���i�݌ɕ\���敪 //ADD ���N 2013/05/02 Redmine#35434  
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				}
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"AllDefSetDB.Read:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();
					sqlConnection.Close();
				}
			}

			// XML�֕ϊ����A������̃o�C�i����
			parabyte = XmlByteSerializer.Serialize(alldefsetWork);

			return status;
		}

		/// <summary>
		/// �S�̏����l����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">AllDefSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �S�̏����l����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.03</br>
		public int Write(ref byte[] parabyte)
		{
            return this.WriteProc(ref parabyte);
        }
        /// <summary>
        /// �S�̏����l����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="parabyte">AllDefSetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �S�̏����l����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21052�@�R�c�@�\</br>
        /// <br>Date       : 2005.10.03</br>
        /// <br>Update Note: ���N</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>�Ǘ��ԍ�   : 10901273-00 2013/06/18�z�M��</br>
        /// <br>           : Redmine#35434�̑Ή�</br>
        private int WriteProc(ref byte[] parabyte)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			try 
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

                // XML�̓ǂݍ���
				AllDefSetWork alldefsetWork = (AllDefSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(AllDefSetWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Select�R�}���h�̐���
                // 2008.05.27 upd start -------------------------------------->>
				//using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, SECTIONCODERF FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection))
				string sqlTxt = string.Empty;
                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlTxt += " FROM ALLDEFSETRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                // 2008.05.27 upd end ----------------------------------------<<
                {
					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(alldefsetWork.EnterpriseCode);
					findParaSectionCode.Value = SqlDataMediator.SqlSetString(alldefsetWork.SectionCode);

					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
						DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
						if (_updateDateTime != alldefsetWork.UpdateDateTime)
						{
							//�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
							if (alldefsetWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
								//�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
							else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
							return status;
						}

                        // �� 20061128 18322 c
						//sqlCommand.CommandText = "UPDATE ALLDEFSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , DISTRICTCODERF=@DISTRICTCODE , DEFDISPADDRCD1RF=@DEFDISPADDRCD1 , DEFDISPADDRCD2RF=@DEFDISPADDRCD2 , DEFDISPADDRCD3RF=@DEFDISPADDRCD3 , DEFDISPADDRESSRF=@DEFDISPADDRESS , NO88AUTOLIACALCDIVRF=@NO88AUTOLIACALCDIV , TOTALAMOUNTDISPWAYCDRF=@TOTALAMOUNTDISPWAYCD , CUSTCDAUTONUMBERINGRF=@CUSTCDAUTONUMBERING , CUSTOMERDELCHKDIVCDRF=@CUSTOMERDELCHKDIVCD , DEFDSPCUSTTTLDAYRF=@DEFDSPCUSTTTLDAY , DEFDSPCUSTCLCTMNYDAYRF=@DEFDSPCUSTCLCTMNYDAY , DEFDSPCLCTMNYMONTHCDRF=@DEFDSPCLCTMNYMONTHCD , INIDSPPRSLORCORPCDRF=@INIDSPPRSLORCORPCD , INITDSPDMDIVRF=@INITDSPDMDIV , DEFDSPBILLPRTDIVCDRF=@DEFDSPBILLPRTDIVCD , CARFIXSELECTMETHODRF=@CARFIXSELECTMETHOD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
						
						//sqlCommand.CommandText = "UPDATE ALLDEFSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , TOTALAMOUNTDISPWAYCDRF=@TOTALAMOUNTDISPWAYCD , CUSTCDAUTONUMBERINGRF=@CUSTCDAUTONUMBERING , CUSTOMERDELCHKDIVCDRF=@CUSTOMERDELCHKDIVCD , DEFDSPCUSTTTLDAYRF=@DEFDSPCUSTTTLDAY , DEFDSPCUSTCLCTMNYDAYRF=@DEFDSPCUSTCLCTMNYDAY , DEFDSPCLCTMNYMONTHCDRF=@DEFDSPCLCTMNYMONTHCD , INIDSPPRSLORCORPCDRF=@INIDSPPRSLORCORPCD , INITDSPDMDIVRF=@INITDSPDMDIV , DEFDSPBILLPRTDIVCDRF=@DEFDSPBILLPRTDIVCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
						// �� 20061128 18322 c
						
                        // �� 2008.01.10 980081 c
                        //// �� 2007.12.17 980081 c
                        ////// �� 2007.08.16 980081 c
                        //////// 2007.03.05 added by T-Kidate
                        //////sqlCommand.CommandText = "UPDATE ALLDEFSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , TOTALAMOUNTDISPWAYCDRF=@TOTALAMOUNTDISPWAYCD , CUSTCDAUTONUMBERINGRF=@CUSTCDAUTONUMBERING , CUSTOMERDELCHKDIVCDRF=@CUSTOMERDELCHKDIVCD , DEFDSPCUSTTTLDAYRF=@DEFDSPCUSTTTLDAY , DEFDSPCUSTCLCTMNYDAYRF=@DEFDSPCUSTCLCTMNYDAY , DEFDSPCLCTMNYMONTHCDRF=@DEFDSPCLCTMNYMONTHCD , INIDSPPRSLORCORPCDRF=@INIDSPPRSLORCORPCD , INITDSPDMDIVRF=@INITDSPDMDIV , DEFDSPBILLPRTDIVCDRF=@DEFDSPBILLPRTDIVCD , MEMBERINFODISPCDRF=@MEMBERINFODISPCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                        ////sqlCommand.CommandText = "UPDATE ALLDEFSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , TOTALAMOUNTDISPWAYCDRF=@TOTALAMOUNTDISPWAYCD , CUSTCDAUTONUMBERINGRF=@CUSTCDAUTONUMBERING , CUSTOMERDELCHKDIVCDRF=@CUSTOMERDELCHKDIVCD , DEFDSPCUSTTTLDAYRF=@DEFDSPCUSTTTLDAY , DEFDSPCUSTCLCTMNYDAYRF=@DEFDSPCUSTCLCTMNYDAY , DEFDSPCLCTMNYMONTHCDRF=@DEFDSPCLCTMNYMONTHCD , INIDSPPRSLORCORPCDRF=@INIDSPPRSLORCORPCD , INITDSPDMDIVRF=@INITDSPDMDIV , DEFDSPBILLPRTDIVCDRF=@DEFDSPBILLPRTDIVCD , MEMBERINFODISPCDRF=@MEMBERINFODISPCD , ERANAMEDISPCD1RF=@ERANAMEDISPCD1 , ERANAMEDISPCD2RF=@ERANAMEDISPCD2 , ERANAMEDISPCD3RF=@ERANAMEDISPCD3 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                        ////// �� 2007.08.16 980081 c
                        //sqlCommand.CommandText = "UPDATE ALLDEFSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , TOTALAMOUNTDISPWAYCDRF=@TOTALAMOUNTDISPWAYCD , CUSTOMERDELCHKDIVCDRF=@CUSTOMERDELCHKDIVCD , CUSTCDAUTONUMBERINGRF=@CUSTCDAUTONUMBERING , DEFDSPCUSTTTLDAYRF=@DEFDSPCUSTTTLDAY , DEFDSPCUSTCLCTMNYDAYRF=@DEFDSPCUSTCLCTMNYDAY , DEFDSPCLCTMNYMONTHCDRF=@DEFDSPCLCTMNYMONTHCD , INIDSPPRSLORCORPCDRF=@INIDSPPRSLORCORPCD , INITDSPDMDIVRF=@INITDSPDMDIV , DEFDSPBILLPRTDIVCDRF=@DEFDSPBILLPRTDIVCD , MEMBERINFODISPCDRF=@MEMBERINFODISPCD , ERANAMEDISPCD1RF=@ERANAMEDISPCD1 , ERANAMEDISPCD2RF=@ERANAMEDISPCD2 , ERANAMEDISPCD3RF=@ERANAMEDISPCD3 , SECMNGDIVRF=@SECMNGDIV , GOODSNOINPDIVRF=@GOODSNOINPDIV , CNSTAXAUTOCORRDIVRF=@CNSTAXAUTOCORRDIV , REMAINCNTMNGDIVRF=@REMAINCNTMNGDIV , MEMOMOVEDIVRF=@MEMOMOVEDIV , REMCNTAUTODSPDIVRF=@REMCNTAUTODSPDIV , TTLAMNTDSPRATEDIVCDRF=@TTLAMNTDSPRATEDIVCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                        //// �� 2007.12.17 980081 c
                        // 2008.05.27 upd start -------------------------------------->>
                        //sqlCommand.CommandText = "UPDATE ALLDEFSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , TOTALAMOUNTDISPWAYCDRF=@TOTALAMOUNTDISPWAYCD , CUSTOMERDELCHKDIVCDRF=@CUSTOMERDELCHKDIVCD , CUSTCDAUTONUMBERINGRF=@CUSTCDAUTONUMBERING , DEFDSPCUSTTTLDAYRF=@DEFDSPCUSTTTLDAY , DEFDSPCUSTCLCTMNYDAYRF=@DEFDSPCUSTCLCTMNYDAY , DEFDSPCLCTMNYMONTHCDRF=@DEFDSPCLCTMNYMONTHCD , INIDSPPRSLORCORPCDRF=@INIDSPPRSLORCORPCD , INITDSPDMDIVRF=@INITDSPDMDIV , DEFDSPBILLPRTDIVCDRF=@DEFDSPBILLPRTDIVCD , MEMBERINFODISPCDRF=@MEMBERINFODISPCD , ERANAMEDISPCD1RF=@ERANAMEDISPCD1 , ERANAMEDISPCD2RF=@ERANAMEDISPCD2 , ERANAMEDISPCD3RF=@ERANAMEDISPCD3 , GOODSNOINPDIVRF=@GOODSNOINPDIV , CNSTAXAUTOCORRDIVRF=@CNSTAXAUTOCORRDIV , REMAINCNTMNGDIVRF=@REMAINCNTMNGDIV , MEMOMOVEDIVRF=@MEMOMOVEDIV , REMCNTAUTODSPDIVRF=@REMCNTAUTODSPDIV , TTLAMNTDSPRATEDIVCDRF=@TTLAMNTDSPRATEDIVCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                        sqlTxt = string.Empty;
                        sqlTxt += "UPDATE ALLDEFSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                        sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                        sqlTxt += " , TOTALAMOUNTDISPWAYCDRF=@TOTALAMOUNTDISPWAYCD" + Environment.NewLine;
                        sqlTxt += " , DEFDSPCUSTTTLDAYRF=@DEFDSPCUSTTTLDAY" + Environment.NewLine;
                        sqlTxt += " , DEFDSPCUSTCLCTMNYDAYRF=@DEFDSPCUSTCLCTMNYDAY" + Environment.NewLine;
                        sqlTxt += " , DEFDSPCLCTMNYMONTHCDRF=@DEFDSPCLCTMNYMONTHCD" + Environment.NewLine;
                        sqlTxt += " , INIDSPPRSLORCORPCDRF=@INIDSPPRSLORCORPCD" + Environment.NewLine;
                        sqlTxt += " , INITDSPDMDIVRF=@INITDSPDMDIV" + Environment.NewLine;
                        sqlTxt += " , DEFDSPBILLPRTDIVCDRF=@DEFDSPBILLPRTDIVCD" + Environment.NewLine;
                        sqlTxt += " , ERANAMEDISPCD1RF=@ERANAMEDISPCD1" + Environment.NewLine;
                        sqlTxt += " , ERANAMEDISPCD2RF=@ERANAMEDISPCD2" + Environment.NewLine;
                        sqlTxt += " , ERANAMEDISPCD3RF=@ERANAMEDISPCD3" + Environment.NewLine;
                        sqlTxt += " , GOODSNOINPDIVRF=@GOODSNOINPDIV" + Environment.NewLine;
                        sqlTxt += " , CNSTAXAUTOCORRDIVRF=@CNSTAXAUTOCORRDIV" + Environment.NewLine;
                        sqlTxt += " , REMAINCNTMNGDIVRF=@REMAINCNTMNGDIV" + Environment.NewLine;
                        sqlTxt += " , MEMOMOVEDIVRF=@MEMOMOVEDIV" + Environment.NewLine;
                        sqlTxt += " , REMCNTAUTODSPDIVRF=@REMCNTAUTODSPDIV" + Environment.NewLine;
                        sqlTxt += " , TTLAMNTDSPRATEDIVCDRF=@TTLAMNTDSPRATEDIVCD" + Environment.NewLine;
                        // --- ADD  ���r��  2010/01/15 ---------->>>>>
                        sqlTxt += " , DEFTTLBILLOUTPUTRF=@DEFTTLBILLOUTPUT" + Environment.NewLine;
                        sqlTxt += " , DEFDTLBILLOUTPUTRF=@DEFDTLBILLOUTPUT" + Environment.NewLine;
                        sqlTxt += " , DEFSLTTLBILLOUTPUTRF=@DEFSLTTLBILLOUTPUT" + Environment.NewLine;
                        // --- ADD  ���r��  2010/01/15 ----------<<<<<
                        sqlTxt += " , DTLCALCSTCKCNTDSPRF=@DTLCALCSTCKCNTDSP" + Environment.NewLine; //ADD 2011/07/19
                        sqlTxt += " , GOODSSTOCKMSTBOOTDIVRF=@GOODSSTOCKMSTBOOTDIV" + Environment.NewLine; // ADD ���N 2013/05/02 Redmine#35434
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.27 upd end ----------------------------------------<<
                        // �� 2008.01.10 980081 c
                        //KEY�R�}���h���Đݒ�
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(alldefsetWork.EnterpriseCode);
						findParaSectionCode.Value = SqlDataMediator.SqlSetString(alldefsetWork.SectionCode);

						//�X�V�w�b�_����ݒ�
						object obj = (object)this;
						IFileHeader flhd = (IFileHeader)alldefsetWork;
						FileHeader fileHeader = new FileHeader(obj);
						fileHeader.SetUpdateHeader(ref flhd,obj);
					}
					else
					{
						//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
						if (alldefsetWork.UpdateDateTime > DateTime.MinValue)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
							return status;
						}

						//�V�K�쐬����SQL���𐶐�
						
						// �� 20061128 18322 c
						//sqlCommand.CommandText = "INSERT INTO ALLDEFSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, DISTRICTCODERF, DEFDISPADDRCD1RF, DEFDISPADDRCD2RF, DEFDISPADDRCD3RF, DEFDISPADDRESSRF, NO88AUTOLIACALCDIVRF, TOTALAMOUNTDISPWAYCDRF, CUSTCDAUTONUMBERINGRF, CUSTOMERDELCHKDIVCDRF, DEFDSPCUSTTTLDAYRF, DEFDSPCUSTCLCTMNYDAYRF, DEFDSPCLCTMNYMONTHCDRF, INIDSPPRSLORCORPCDRF, INITDSPDMDIVRF, DEFDSPBILLPRTDIVCDRF, CARFIXSELECTMETHODRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @DISTRICTCODE, @DEFDISPADDRCD1, @DEFDISPADDRCD2, @DEFDISPADDRCD3, @DEFDISPADDRESS, @NO88AUTOLIACALCDIV, @TOTALAMOUNTDISPWAYCD, @CUSTCDAUTONUMBERING, @CUSTOMERDELCHKDIVCD, @DEFDSPCUSTTTLDAY, @DEFDSPCUSTCLCTMNYDAY, @DEFDSPCLCTMNYMONTHCD, @INIDSPPRSLORCORPCD, @INITDSPDMDIV, @DEFDSPBILLPRTDIVCD, @CARFIXSELECTMETHOD)";
						
						//sqlCommand.CommandText = "INSERT INTO ALLDEFSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, TOTALAMOUNTDISPWAYCDRF, CUSTCDAUTONUMBERINGRF, CUSTOMERDELCHKDIVCDRF, DEFDSPCUSTTTLDAYRF, DEFDSPCUSTCLCTMNYDAYRF, DEFDSPCLCTMNYMONTHCDRF, INIDSPPRSLORCORPCDRF, INITDSPDMDIVRF, DEFDSPBILLPRTDIVCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @TOTALAMOUNTDISPWAYCD, @CUSTCDAUTONUMBERING, @CUSTOMERDELCHKDIVCD, @DEFDSPCUSTTTLDAY, @DEFDSPCUSTCLCTMNYDAY, @DEFDSPCLCTMNYMONTHCD, @INIDSPPRSLORCORPCD, @INITDSPDMDIV, @DEFDSPBILLPRTDIVCD)";
						// �� 20061128 18322 c
						
                        // �� 2008.01.10 980081 c
                        //// �� 2007.12.17 980081 c
                        ////// �� 2007.08.16 980081 c
                        //////// 2007.03.05 modified by T-Kidate
                        //////sqlCommand.CommandText = "INSERT INTO ALLDEFSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, TOTALAMOUNTDISPWAYCDRF, CUSTCDAUTONUMBERINGRF, CUSTOMERDELCHKDIVCDRF, DEFDSPCUSTTTLDAYRF, DEFDSPCUSTCLCTMNYDAYRF, DEFDSPCLCTMNYMONTHCDRF, INIDSPPRSLORCORPCDRF, INITDSPDMDIVRF, DEFDSPBILLPRTDIVCDRF, MEMBERINFODISPCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @TOTALAMOUNTDISPWAYCD, @CUSTCDAUTONUMBERING, @CUSTOMERDELCHKDIVCD, @DEFDSPCUSTTTLDAY, @DEFDSPCUSTCLCTMNYDAY, @DEFDSPCLCTMNYMONTHCD, @INIDSPPRSLORCORPCD, @INITDSPDMDIV, @DEFDSPBILLPRTDIVCD, @MEMBERINFODISPCD)";
                        ////sqlCommand.CommandText = "INSERT INTO ALLDEFSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, TOTALAMOUNTDISPWAYCDRF, CUSTCDAUTONUMBERINGRF, CUSTOMERDELCHKDIVCDRF, DEFDSPCUSTTTLDAYRF, DEFDSPCUSTCLCTMNYDAYRF, DEFDSPCLCTMNYMONTHCDRF, INIDSPPRSLORCORPCDRF, INITDSPDMDIVRF, DEFDSPBILLPRTDIVCDRF, MEMBERINFODISPCDRF, ERANAMEDISPCD1RF, ERANAMEDISPCD2RF, ERANAMEDISPCD3RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @TOTALAMOUNTDISPWAYCD, @CUSTCDAUTONUMBERING, @CUSTOMERDELCHKDIVCD, @DEFDSPCUSTTTLDAY, @DEFDSPCUSTCLCTMNYDAY, @DEFDSPCLCTMNYMONTHCD, @INIDSPPRSLORCORPCD, @INITDSPDMDIV, @DEFDSPBILLPRTDIVCD, @MEMBERINFODISPCD, @ERANAMEDISPCD1, @ERANAMEDISPCD2, @ERANAMEDISPCD3)";
                        ////// �� 2007.08.16 980081 c
                        //sqlCommand.CommandText = "INSERT INTO ALLDEFSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, TOTALAMOUNTDISPWAYCDRF, CUSTOMERDELCHKDIVCDRF, CUSTCDAUTONUMBERINGRF, DEFDSPCUSTTTLDAYRF, DEFDSPCUSTCLCTMNYDAYRF, DEFDSPCLCTMNYMONTHCDRF, INIDSPPRSLORCORPCDRF, INITDSPDMDIVRF, DEFDSPBILLPRTDIVCDRF, MEMBERINFODISPCDRF, ERANAMEDISPCD1RF, ERANAMEDISPCD2RF, ERANAMEDISPCD3RF, SECMNGDIVRF, GOODSNOINPDIVRF, CNSTAXAUTOCORRDIVRF, REMAINCNTMNGDIVRF, MEMOMOVEDIVRF, REMCNTAUTODSPDIVRF, TTLAMNTDSPRATEDIVCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @TOTALAMOUNTDISPWAYCD, @CUSTOMERDELCHKDIVCD, @CUSTCDAUTONUMBERING, @DEFDSPCUSTTTLDAY, @DEFDSPCUSTCLCTMNYDAY, @DEFDSPCLCTMNYMONTHCD, @INIDSPPRSLORCORPCD, @INITDSPDMDIV, @DEFDSPBILLPRTDIVCD, @MEMBERINFODISPCD, @ERANAMEDISPCD1, @ERANAMEDISPCD2, @ERANAMEDISPCD3, @SECMNGDIV, @GOODSNOINPDIV, @CNSTAXAUTOCORRDIV, @REMAINCNTMNGDIV, @MEMOMOVEDIV, @REMCNTAUTODSPDIV, @TTLAMNTDSPRATEDIVCD)";
                        //// �� 2007.12.17 980081 c
                        // 2008.05.27 upd start -------------------------------------->>
                        //sqlCommand.CommandText = "INSERT INTO ALLDEFSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, TOTALAMOUNTDISPWAYCDRF, CUSTOMERDELCHKDIVCDRF, CUSTCDAUTONUMBERINGRF, DEFDSPCUSTTTLDAYRF, DEFDSPCUSTCLCTMNYDAYRF, DEFDSPCLCTMNYMONTHCDRF, INIDSPPRSLORCORPCDRF, INITDSPDMDIVRF, DEFDSPBILLPRTDIVCDRF, MEMBERINFODISPCDRF, ERANAMEDISPCD1RF, ERANAMEDISPCD2RF, ERANAMEDISPCD3RF, GOODSNOINPDIVRF, CNSTAXAUTOCORRDIVRF, REMAINCNTMNGDIVRF, MEMOMOVEDIVRF, REMCNTAUTODSPDIVRF, TTLAMNTDSPRATEDIVCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @TOTALAMOUNTDISPWAYCD, @CUSTOMERDELCHKDIVCD, @CUSTCDAUTONUMBERING, @DEFDSPCUSTTTLDAY, @DEFDSPCUSTCLCTMNYDAY, @DEFDSPCLCTMNYMONTHCD, @INIDSPPRSLORCORPCD, @INITDSPDMDIV, @DEFDSPBILLPRTDIVCD, @MEMBERINFODISPCD, @ERANAMEDISPCD1, @ERANAMEDISPCD2, @ERANAMEDISPCD3, @GOODSNOINPDIV, @CNSTAXAUTOCORRDIV, @REMAINCNTMNGDIV, @MEMOMOVEDIV, @REMCNTAUTODSPDIV, @TTLAMNTDSPRATEDIVCD)";
                        sqlTxt = string.Empty;
                        sqlTxt += "INSERT INTO ALLDEFSETRF" + Environment.NewLine;
                        sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                        sqlTxt += "    ,DEFDSPCUSTTTLDAYRF" + Environment.NewLine;
                        sqlTxt += "    ,DEFDSPCUSTCLCTMNYDAYRF" + Environment.NewLine;
                        sqlTxt += "    ,DEFDSPCLCTMNYMONTHCDRF" + Environment.NewLine;
                        sqlTxt += "    ,INIDSPPRSLORCORPCDRF" + Environment.NewLine;
                        sqlTxt += "    ,INITDSPDMDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,DEFDSPBILLPRTDIVCDRF" + Environment.NewLine;
                        sqlTxt += "    ,ERANAMEDISPCD1RF" + Environment.NewLine;
                        sqlTxt += "    ,ERANAMEDISPCD2RF" + Environment.NewLine;
                        sqlTxt += "    ,ERANAMEDISPCD3RF" + Environment.NewLine;
                        sqlTxt += "    ,GOODSNOINPDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,CNSTAXAUTOCORRDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,REMAINCNTMNGDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,MEMOMOVEDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,REMCNTAUTODSPDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,TTLAMNTDSPRATEDIVCDRF" + Environment.NewLine;
                        // --- ADD  ���r��  2010/01/15 ---------->>>>>
                        sqlTxt += "    ,DEFTTLBILLOUTPUTRF" + Environment.NewLine;
                        sqlTxt += "    ,DEFDTLBILLOUTPUTRF" + Environment.NewLine;
                        sqlTxt += "    ,DEFSLTTLBILLOUTPUTRF" + Environment.NewLine;
                        // --- ADD  ���r��  2010/01/15 ----------<<<<<
                        sqlTxt += "    ,DTLCALCSTCKCNTDSPRF" + Environment.NewLine; //ADD 2011/07/19
                        sqlTxt += "    ,GOODSSTOCKMSTBOOTDIVRF" + Environment.NewLine; // ADD�@���N�@2013/05/02 Redmine#35434 
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
                        sqlTxt += "    ,@TOTALAMOUNTDISPWAYCD" + Environment.NewLine;
                        sqlTxt += "    ,@DEFDSPCUSTTTLDAY" + Environment.NewLine;
                        sqlTxt += "    ,@DEFDSPCUSTCLCTMNYDAY" + Environment.NewLine;
                        sqlTxt += "    ,@DEFDSPCLCTMNYMONTHCD" + Environment.NewLine;
                        sqlTxt += "    ,@INIDSPPRSLORCORPCD" + Environment.NewLine;
                        sqlTxt += "    ,@INITDSPDMDIV" + Environment.NewLine;
                        sqlTxt += "    ,@DEFDSPBILLPRTDIVCD" + Environment.NewLine;
                        sqlTxt += "    ,@ERANAMEDISPCD1" + Environment.NewLine;
                        sqlTxt += "    ,@ERANAMEDISPCD2" + Environment.NewLine;
                        sqlTxt += "    ,@ERANAMEDISPCD3" + Environment.NewLine;
                        sqlTxt += "    ,@GOODSNOINPDIV" + Environment.NewLine;
                        sqlTxt += "    ,@CNSTAXAUTOCORRDIV" + Environment.NewLine;
                        sqlTxt += "    ,@REMAINCNTMNGDIV" + Environment.NewLine;
                        sqlTxt += "    ,@MEMOMOVEDIV" + Environment.NewLine;
                        sqlTxt += "    ,@REMCNTAUTODSPDIV" + Environment.NewLine;
                        sqlTxt += "    ,@TTLAMNTDSPRATEDIVCD" + Environment.NewLine;
                        // --- ADD  ���r��  2010/01/15 ---------->>>>>
                        sqlTxt += "    ,@DEFTTLBILLOUTPUT" + Environment.NewLine; 
                        sqlTxt += "    ,@DEFDTLBILLOUTPUT" + Environment.NewLine; 
                        sqlTxt += "    ,@DEFSLTTLBILLOUTPUT" + Environment.NewLine;
                        // --- ADD  ���r��  2010/01/15 ----------<<<<<
                        sqlTxt += "    ,@DTLCALCSTCKCNTDSP" + Environment.NewLine; //ADD 2011/07/19
                        sqlTxt += "    ,@GOODSSTOCKMSTBOOTDIV" + Environment.NewLine;// ADD ���N 2013/05/02 Redmine#35434
                        sqlTxt += " )" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.27 upd end ----------------------------------------<<
                        // �� 2008.01.10 980081 c
                        //�o�^�w�b�_����ݒ�
						object obj = (object)this;
						IFileHeader flhd = (IFileHeader)alldefsetWork;
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
					// �� 20061128 18322 d
					//SqlParameter paraDistrictCode = sqlCommand.Parameters.Add("@DISTRICTCODE", SqlDbType.Int);
					//SqlParameter paraDefDispAddrCd1 = sqlCommand.Parameters.Add("@DEFDISPADDRCD1", SqlDbType.Int);
					//SqlParameter paraDefDispAddrCd2 = sqlCommand.Parameters.Add("@DEFDISPADDRCD2", SqlDbType.Int);
					//SqlParameter paraDefDispAddrCd3 = sqlCommand.Parameters.Add("@DEFDISPADDRCD3", SqlDbType.Int);
					//SqlParameter paraDefDispAddress = sqlCommand.Parameters.Add("@DEFDISPADDRESS", SqlDbType.NVarChar);
					//SqlParameter paraNo88AutoLiaCalcDiv = sqlCommand.Parameters.Add("@NO88AUTOLIACALCDIV", SqlDbType.Int);
					//SqlParameter paraCarFixSelectMethod = sqlCommand.Parameters.Add("@CARFIXSELECTMETHOD", SqlDbType.Int);
					// �� 20061128 18322 d
					SqlParameter paraTotalAmountDispWayCd = sqlCommand.Parameters.Add("@TOTALAMOUNTDISPWAYCD", SqlDbType.Int);
                    //SqlParameter paraCustCdAutoNumbering = sqlCommand.Parameters.Add("@CUSTCDAUTONUMBERING", SqlDbType.Int); // 2007.05.27 del
                    //SqlParameter paraCustomerDelChkDivCd = sqlCommand.Parameters.Add("@CUSTOMERDELCHKDIVCD", SqlDbType.Int); // 2007.05.27 del
					SqlParameter paraDefDspCustTtlDay = sqlCommand.Parameters.Add("@DEFDSPCUSTTTLDAY", SqlDbType.Int);
					SqlParameter paraDefDspCustClctMnyDay = sqlCommand.Parameters.Add("@DEFDSPCUSTCLCTMNYDAY", SqlDbType.Int);
					SqlParameter paraDefDspClctMnyMonthCd = sqlCommand.Parameters.Add("@DEFDSPCLCTMNYMONTHCD", SqlDbType.Int);
					SqlParameter paraIniDspPrslOrCorpCd = sqlCommand.Parameters.Add("@INIDSPPRSLORCORPCD", SqlDbType.Int);
					SqlParameter paraInitDspDmDiv = sqlCommand.Parameters.Add("@INITDSPDMDIV", SqlDbType.Int);
					SqlParameter paraDefDspBillPrtDivCd = sqlCommand.Parameters.Add("@DEFDSPBILLPRTDIVCD", SqlDbType.Int);
                    // 2007.03.05 added by T-Kidate
                    //SqlParameter paraMemberInfoDispCd = sqlCommand.Parameters.Add("@MEMBERINFODISPCD", SqlDbType.Int); // 2007.05.27 del
                    // �� 2007.08.16 980081 a
                    SqlParameter paraEraNameDispCd1 = sqlCommand.Parameters.Add("@ERANAMEDISPCD1", SqlDbType.Int);
                    SqlParameter paraEraNameDispCd2 = sqlCommand.Parameters.Add("@ERANAMEDISPCD2", SqlDbType.Int);
                    SqlParameter paraEraNameDispCd3 = sqlCommand.Parameters.Add("@ERANAMEDISPCD3", SqlDbType.Int);
                    // �� 2007.08.16 980081 a
                    // �� 2007.12.17 980081 a
                    // �� 2008.01.10 980081 d
                    //SqlParameter paraSecMngDiv = sqlCommand.Parameters.Add("@SECMNGDIV", SqlDbType.Int);
                    // �� 2008.01.10 980081 d
                    SqlParameter paraGoodsNoInpDiv = sqlCommand.Parameters.Add("@GOODSNOINPDIV", SqlDbType.Int);
                    SqlParameter paraCnsTaxAutoCorrDiv = sqlCommand.Parameters.Add("@CNSTAXAUTOCORRDIV", SqlDbType.Int);
                    SqlParameter paraRemainCntMngDiv = sqlCommand.Parameters.Add("@REMAINCNTMNGDIV", SqlDbType.Int);
                    SqlParameter paraMemoMoveDiv = sqlCommand.Parameters.Add("@MEMOMOVEDIV", SqlDbType.Int);
                    SqlParameter paraRemCntAutoDspDiv = sqlCommand.Parameters.Add("@REMCNTAUTODSPDIV", SqlDbType.Int);
                    SqlParameter paraTtlAmntDspRateDivCd = sqlCommand.Parameters.Add("@TTLAMNTDSPRATEDIVCD", SqlDbType.Int);
                    // �� 2007.12.17 980081 a
                    // --- ADD  ���r��  2010/01/15 ---------->>>>>
                    SqlParameter paraDefTtlBillOutput = sqlCommand.Parameters.Add("@DEFTTLBILLOUTPUT", SqlDbType.Int);  // �����\�����v�������o�͋敪
                    SqlParameter paraDefDtlBillOutput = sqlCommand.Parameters.Add("@DEFDTLBILLOUTPUT", SqlDbType.Int);  // �����\�����א������o�͋敪
                    SqlParameter paraDefSlTtlBillOutput = sqlCommand.Parameters.Add("@DEFSLTTLBILLOUTPUT", SqlDbType.Int);  // �����\���`�[���v�������o�͋敪
                    // --- ADD  ���r��  2010/01/15 ----------<<<<<
                    SqlParameter paraDefDtlCalcStckCntDsp = sqlCommand.Parameters.Add("@DTLCALCSTCKCNTDSP", SqlDbType.Int);  //�d���E�o�׌㐔�\���敪 //ADD 2011/07/19
                    SqlParameter paraGoodsStockMSTBootDiv = sqlCommand.Parameters.Add("@GOODSSTOCKMSTBOOTDIV", SqlDbType.Int);// ���i�݌ɕ\���敪 // ADD ���N 2013/05/02 Redmine#35434


					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(alldefsetWork.CreateDateTime);
					paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(alldefsetWork.UpdateDateTime);
					paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(alldefsetWork.EnterpriseCode);
					paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(alldefsetWork.FileHeaderGuid);
					paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(alldefsetWork.UpdEmployeeCode);
					paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(alldefsetWork.UpdAssemblyId1);
					paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(alldefsetWork.UpdAssemblyId2);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.LogicalDeleteCode);
					paraSectionCode.Value = SqlDataMediator.SqlSetString(alldefsetWork.SectionCode);
					
					// �� 20061128 18322 d
					//paraDistrictCode.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.DistrictCode);
					//paraDefDispAddrCd1.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.DefDispAddrCd1);
					//paraDefDispAddrCd2.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.DefDispAddrCd2);
					//paraDefDispAddrCd3.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.DefDispAddrCd3);
					//paraDefDispAddress.Value = SqlDataMediator.SqlSetString(alldefsetWork.DefDispAddress);
					//paraNo88AutoLiaCalcDiv.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.No88AutoLiaCalcDiv);
					//paraCarFixSelectMethod.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.CarFixSelectMethod);
					// �� 20061128 18322 d
					
					paraTotalAmountDispWayCd.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.TotalAmountDispWayCd);
                    //paraCustCdAutoNumbering.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.CustCdAutoNumbering); // 2007.05.27 del
                    //paraCustomerDelChkDivCd.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.CustomerDelChkDivCd); // 2007.05.27 del
					paraDefDspCustTtlDay.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.DefDspCustTtlDay);
					paraDefDspCustClctMnyDay.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.DefDspCustClctMnyDay);
					paraDefDspClctMnyMonthCd.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.DefDspClctMnyMonthCd);
					paraIniDspPrslOrCorpCd.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.IniDspPrslOrCorpCd);
					paraInitDspDmDiv.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.InitDspDmDiv);
					paraDefDspBillPrtDivCd.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.DefDspBillPrtDivCd);
                    // 2007.03.05 added by T-Kidate
                    //paraMemberInfoDispCd.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.MemberInfoDispCd); // 2007.05.27 del
                    // �� 2007.08.16 980081 a
                    paraEraNameDispCd1.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.EraNameDispCd1);
                    paraEraNameDispCd2.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.EraNameDispCd2);
                    paraEraNameDispCd3.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.EraNameDispCd3);
                    // �� 2007.08.16 980081 a
                    // �� 2007.12.17 980081 a
                    // �� 2008.01.10 980081 d
                    //paraSecMngDiv.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.SecMngDiv);
                    // �� 2008.01.10 980081 d
                    paraGoodsNoInpDiv.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.GoodsNoInpDiv);
                    paraCnsTaxAutoCorrDiv.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.CnsTaxAutoCorrDiv);
                    paraRemainCntMngDiv.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.RemainCntMngDiv);
                    paraMemoMoveDiv.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.MemoMoveDiv);
                    paraRemCntAutoDspDiv.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.RemCntAutoDspDiv);
                    paraTtlAmntDspRateDivCd.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.TtlAmntDspRateDivCd);
                    // �� 2007.12.17 980081 a
                    // --- ADD  ���r��  2010/01/15 ---------->>>>>
                    paraDefTtlBillOutput.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.DefTtlBillOutput);  // �����\�����v�������o�͋敪
                    paraDefDtlBillOutput.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.DefDtlBillOutput);  // �����\�����א������o�͋敪
                    paraDefSlTtlBillOutput.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.DefSlTtlBillOutput);  // �����\���`�[���v�������o�͋敪
                    // --- ADD  ���r��  2010/01/15 ----------<<<<<
                    paraDefDtlCalcStckCntDsp.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.DtlCalcStckCntDsp);//�d���E�o�׌㐔�\���敪  //ADD 2011/07/19
                    paraGoodsStockMSTBootDiv.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.GoodsStockMstBootDiv); // ���i�݌ɋN���敪 // ADD ���N 2013/05/02 Redmine#35434

					sqlCommand.ExecuteNonQuery();

					// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
					parabyte = XmlByteSerializer.Serialize(alldefsetWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"AllDefSetDB.Write:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();
					sqlConnection.Close();
				}
			}

			return status;

		}

		/// <summary>
		/// �S�̏����l����_���폜���܂�
		/// </summary>
		/// <param name="parabyte">AllDefSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �S�̏����l����_���폜���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.03</br>
		public int LogicalDelete(ref byte[] parabyte)
		{
			return LogicalDeleteProc(ref parabyte,0);
		}

		/// <summary>
		/// �_���폜�S�̏����l���𕜊����܂�
		/// </summary>
		/// <param name="parabyte">AllDefSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜�S�̏����l���𕜊����܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.03</br>
		public int RevivalLogicalDelete(ref byte[] parabyte)
		{
			return LogicalDeleteProc(ref parabyte,1);
		}

		/// <summary>
		/// �S�̏����l���̘_���폜�𑀍삵�܂�
		/// </summary>
		/// <param name="parabyte">AllDefSetWork�I�u�W�F�N�g</param>
		/// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �S�̏����l���̘_���폜�𑀍삵�܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.03</br>
		private int LogicalDeleteProc(ref byte[] parabyte,int procMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int logicalDelCd = 0;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			try		
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

                // XML�̓ǂݍ���
				AllDefSetWork alldefsetWork = (AllDefSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(AllDefSetWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                // 2008.05.27 upd start -------------------------------------->>
				//using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, SECTIONCODERF FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection))
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlTxt += " FROM ALLDEFSETRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                // 2008.05.27 upd end ----------------------------------------<<
                {
					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(alldefsetWork.EnterpriseCode);
					findParaSectionCode.Value = SqlDataMediator.SqlSetString(alldefsetWork.SectionCode);

					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
						DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
						if (_updateDateTime != alldefsetWork.UpdateDateTime)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
							return status;
						}
						//���݂̘_���폜�敪���擾
						logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                        // 2008.05.27 upd start -------------------------------------->>
						//sqlCommand.CommandText = "UPDATE ALLDEFSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                        sqlTxt = string.Empty;
                        sqlTxt += "UPDATE ALLDEFSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.27 upd end ----------------------------------------<<
                        //KEY�R�}���h���Đݒ�
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(alldefsetWork.EnterpriseCode);
						findParaSectionCode.Value = SqlDataMediator.SqlSetString(alldefsetWork.SectionCode);

						//�X�V�w�b�_����ݒ�
						object obj = (object)this;
						IFileHeader flhd = (IFileHeader)alldefsetWork;
						FileHeader fileHeader = new FileHeader(obj);
						fileHeader.SetUpdateHeader(ref flhd,obj);
					}
					else
					{
						//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						return status;
					}
					if(!myReader.IsClosed)myReader.Close();

					//�_���폜���[�h�̏ꍇ
					if (procMode == 0)
					{
						if		(logicalDelCd == 3)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
							return status;
						}
						else if	(logicalDelCd == 0)	alldefsetWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
						else						alldefsetWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
					}
					else
					{
						if		(logicalDelCd == 1)	alldefsetWork.LogicalDeleteCode = 0;//�_���폜�t���O������
						else
						{
							if  (logicalDelCd == 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
							else					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//���S�폜�̓f�[�^�Ȃ���߂�
							return status;
						}
					}

					//Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
					SqlParameter paraUpdateDateTime    = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
					SqlParameter paraUpdEmployeeCode   = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
					SqlParameter paraUpdAssemblyId1    = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
					SqlParameter paraUpdAssemblyId2    = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
					paraUpdateDateTime.Value    = SqlDataMediator.SqlSetDateTimeFromTicks(alldefsetWork.UpdateDateTime);
					paraUpdEmployeeCode.Value   = SqlDataMediator.SqlSetString(alldefsetWork.UpdEmployeeCode);
					paraUpdAssemblyId1.Value    = SqlDataMediator.SqlSetString(alldefsetWork.UpdAssemblyId1);
					paraUpdAssemblyId2.Value    = SqlDataMediator.SqlSetString(alldefsetWork.UpdAssemblyId2);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(alldefsetWork.LogicalDeleteCode);

					sqlCommand.ExecuteNonQuery();

					// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
					parabyte = XmlByteSerializer.Serialize(alldefsetWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"AllDefSetDB.LogicalDeleteProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();
					sqlConnection.Close();
				}
			}

			return status;

		}

		/// <summary>
		/// �S�̏����l���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">�S�̏����l�I�u�W�F�N�g</param>
		/// <returns></returns>
		/// <br>Note       : �S�̏����l���𕨗��폜���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.03</br>
		public int Delete(byte[] parabyte)
		{
            return this.DeleteProc(parabyte);
        }
        /// <summary>
        /// �S�̏����l���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">�S�̏����l�I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : �S�̏����l���𕨗��폜���܂�</br>
        /// <br>Programmer : 21052�@�R�c�@�\</br>
        /// <br>Date       : 2005.10.03</br>
        private int DeleteProc(byte[] parabyte)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			try 
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

                // XML�̓ǂݍ���
				AllDefSetWork alldefsetWork = (AllDefSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(AllDefSetWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                // 2008.05.27 upd start -------------------------------------->>
				//using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, SECTIONCODERF FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection))
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlTxt += " FROM ALLDEFSETRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                // 2008.05.27 upd end ----------------------------------------<<
                {
					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(alldefsetWork.EnterpriseCode);
					findParaSectionCode.Value = SqlDataMediator.SqlSetString(alldefsetWork.SectionCode);

					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
						DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UpdateDateTimeRF"));//�X�V����
						if (_updateDateTime != alldefsetWork.UpdateDateTime)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
							return status;
						}

                        // 2008.05.27 upd start ------------------------------>>
						//sqlCommand.CommandText = "DELETE FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                        sqlTxt = string.Empty;
                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += " FROM ALLDEFSETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.27 upd end --------------------------------<<
                        //KEY�R�}���h���Đݒ�
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(alldefsetWork.EnterpriseCode);
						findParaSectionCode.Value = SqlDataMediator.SqlSetString(alldefsetWork.SectionCode);
					}
					else
					{
						//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
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
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"AllDefSetDB.Delete:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();
					sqlConnection.Close();
				}
			}
			return status;
		}

		#region �J�X�^���V���A���C�Y
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̑S�̏����lLIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̑S�̏����lLIST��S�Ė߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.03</br>
		public int Search(out object retobj,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)
		{		
			bool nextData;
			int retTotalCnt;
			return SearchProc(out retobj,out retTotalCnt,out nextData,paraobj ,readMode,logicalMode,0);
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̑S�̏����lLIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>		
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̑S�̏����lLIST��S�Ė߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.03</br>
        /// <br>Update Note: ���N</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>�Ǘ��ԍ�   : 10901273-00 2013/06/18�z�M��</br>
        /// <br>           : Redmine#35434�̑Ή�</br>
		private int SearchProc(out object retobj,out int retTotalCnt,out bool nextData,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			AllDefSetWork alldefsetWork = new AllDefSetWork();
			alldefsetWork = null;

			retobj = null;

			//��������0�ŏ�����
			retTotalCnt = 0;

			//�����w�胊�[�h�̏ꍇ�ɂ͎w�茏���{�P�����[�h����
			int _readCnt = readCnt;			
			if (_readCnt > 0) _readCnt += 1;
			//�����R�[�h�����ŏ�����
			nextData = false;
            string sqlTxt = string.Empty; // 2008.05.27 add

			ArrayList al = new ArrayList();
			try 
			{	
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

                alldefsetWork = paraobj as AllDefSetWork;

				//SQL������
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();				

				//�����w�胊�[�h�ňꌏ�ڃ��[�h�̏ꍇ�f�[�^���������擾
				if ((readCnt > 0)&&(alldefsetWork.SectionCode == null)||(alldefsetWork.SectionCode == ""))
				{
					using(SqlCommand sqlCommandCount = new SqlCommand("",sqlConnection))
					{
						if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
							(logicalMode == ConstantManagement.LogicalMode.GetData1)||
							(logicalMode == ConstantManagement.LogicalMode.GetData2)||
							(logicalMode == ConstantManagement.LogicalMode.GetData3))
						{
                            // 2008.05.27 upd start --------------------------------->>
							//sqlCommandCount.CommandText = "SELECT COUNT (*) FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
                            sqlTxt += "SELECT COUNT (*)" + Environment.NewLine;
                            sqlTxt += "    FROM ALLDEFSETRF" + Environment.NewLine;
                            sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "        AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlCommandCount.CommandText = sqlTxt;
                            // 2008.05.27 upd end -----------------------------------<<
                            //�_���폜�敪�ݒ�
							SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
							paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
						}
						else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
						{
                            // 2008.05.27 upd start --------------------------------->>
							//sqlCommandCount.CommandText = "SELECT COUNT (*) FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE";
                            sqlTxt += "SELECT COUNT (*)" + Environment.NewLine;
                            sqlTxt += "    FROM ALLDEFSETRF" + Environment.NewLine;
                            sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "        AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlCommandCount.CommandText = sqlTxt;
                            // 2008.05.27 upd end -----------------------------------<<
                            //�_���폜�敪�ݒ�
							SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
							if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
							else												    		paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
						}
						else 
						{
                            // 2008.05.27 upd start --------------------------------->>
							//sqlCommandCount.CommandText = "SELECT COUNT (*) FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
                            sqlTxt += "SELECT COUNT (*)" + Environment.NewLine;
                            sqlTxt += "    FROM ALLDEFSETRF" + Environment.NewLine;
                            sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlCommandCount.CommandText = sqlTxt;
                            // 2008.05.27 upd end -----------------------------------<<
						}
						SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
						paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(alldefsetWork.EnterpriseCode);

						retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
					}
				}

                sqlTxt = string.Empty; // 2008.05.27 add

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
                            // 2008.05.27 upd start --------------------------------->>
							//sqlCommand.CommandText = "SELECT * FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY SECTIONCODERF";
                            sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                            sqlTxt += "    ,DEFDSPCUSTTTLDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,DEFDSPCUSTCLCTMNYDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,DEFDSPCLCTMNYMONTHCDRF" + Environment.NewLine;
                            sqlTxt += "    ,INIDSPPRSLORCORPCDRF" + Environment.NewLine;
                            sqlTxt += "    ,INITDSPDMDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,DEFDSPBILLPRTDIVCDRF" + Environment.NewLine;
                            sqlTxt += "    ,ERANAMEDISPCD1RF" + Environment.NewLine;
                            sqlTxt += "    ,ERANAMEDISPCD2RF" + Environment.NewLine;
                            sqlTxt += "    ,ERANAMEDISPCD3RF" + Environment.NewLine;
                            sqlTxt += "    ,GOODSNOINPDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,CNSTAXAUTOCORRDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,REMAINCNTMNGDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,MEMOMOVEDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,REMCNTAUTODSPDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,TTLAMNTDSPRATEDIVCDRF" + Environment.NewLine;
                            // --- ADD  ���r��  2010/01/15 ---------->>>>>
                            sqlTxt += "    ,DEFTTLBILLOUTPUTRF" + Environment.NewLine;
                            sqlTxt += "    ,DEFDTLBILLOUTPUTRF" + Environment.NewLine; 
                            sqlTxt += "    ,DEFSLTTLBILLOUTPUTRF" + Environment.NewLine;
                            // --- ADD  ���r��  2010/01/15 ----------<<<<<
                            sqlTxt += "    ,DTLCALCSTCKCNTDSPRF" + Environment.NewLine; //ADD 2011/07/19
                            sqlTxt += "    ,GOODSSTOCKMSTBOOTDIVRF" + Environment.NewLine; // ADD ���N 2013/05/02 Redmine#35434
                            sqlTxt += " FROM ALLDEFSETRF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            // 2008.05.27 upd end -----------------------------------<<
                        }
						else
						{
							//�ꌏ�ڃ��[�h�̏ꍇ
							if ((alldefsetWork.SectionCode == null)||(alldefsetWork.SectionCode == ""))
							{
                                // 2008.05.27 upd start --------------------------------->>
								//sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY SECTIONCODERF";
                                sqlTxt += "SELECT TOP" + Environment.NewLine;
                                sqlTxt += _readCnt.ToString() + Environment.NewLine;
                                sqlTxt += "    ,CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlTxt += "    ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCUSTTTLDAYRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCUSTCLCTMNYDAYRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCLCTMNYMONTHCDRF" + Environment.NewLine;
                                sqlTxt += "    ,INIDSPPRSLORCORPCDRF" + Environment.NewLine;
                                sqlTxt += "    ,INITDSPDMDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPBILLPRTDIVCDRF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD1RF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD2RF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD3RF" + Environment.NewLine;
                                sqlTxt += "    ,GOODSNOINPDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,CNSTAXAUTOCORRDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,REMAINCNTMNGDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,MEMOMOVEDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,REMCNTAUTODSPDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,TTLAMNTDSPRATEDIVCDRF" + Environment.NewLine;
                                // --- ADD  ���r��  2010/01/15 ---------->>>>>
                                sqlTxt += "    ,DEFTTLBILLOUTPUTRF" + Environment.NewLine; 
                                sqlTxt += "    ,DEFDTLBILLOUTPUTRF" + Environment.NewLine; 
                                sqlTxt += "    ,DEFSLTTLBILLOUTPUTRF" + Environment.NewLine;
                                // --- ADD  ���r��  2010/01/15 ----------<<<<<
                                sqlTxt += "    ,DTLCALCSTCKCNTDSPRF" + Environment.NewLine; //ADD 2011/07/19
                                sqlTxt += "    ,GOODSSTOCKMSTBOOTDIVRF" + Environment.NewLine; // ADD ���N 2013/05/02 Redmine#35434
                                sqlTxt += " FROM ALLDEFSETRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                                sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                                sqlCommand.CommandText = sqlTxt;
                                // 2008.05.27 upd end -----------------------------------<<
                            }
								//Next���[�h�̏ꍇ
							else
							{
                                // 2008.05.27 upd start --------------------------------->>
								//sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM ALLDEFSETRF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND SECTIONCODERF>@FINDSECTIONCODE ORDER BY SECTIONCODERF";
                                sqlTxt += "SELECT TOP" + Environment.NewLine;
                                sqlTxt += _readCnt.ToString() + Environment.NewLine;
                                sqlTxt += "    ,CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlTxt += "    ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCUSTTTLDAYRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCUSTCLCTMNYDAYRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCLCTMNYMONTHCDRF" + Environment.NewLine;
                                sqlTxt += "    ,INIDSPPRSLORCORPCDRF" + Environment.NewLine;
                                sqlTxt += "    ,INITDSPDMDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPBILLPRTDIVCDRF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD1RF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD2RF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD3RF" + Environment.NewLine;
                                sqlTxt += "    ,GOODSNOINPDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,CNSTAXAUTOCORRDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,REMAINCNTMNGDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,MEMOMOVEDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,REMCNTAUTODSPDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,TTLAMNTDSPRATEDIVCDRF" + Environment.NewLine;
                                // --- ADD  ���r��  2010/01/15 ---------->>>>>
                                sqlTxt += "    ,DEFTTLBILLOUTPUTRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDTLBILLOUTPUTRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFSLTTLBILLOUTPUTRF" + Environment.NewLine;
                                // --- ADD  ���r��  2010/01/15 ----------<<<<<
                                sqlTxt += "    ,DTLCALCSTCKCNTDSPRF" + Environment.NewLine; //ADD 2011/07/19
                                sqlTxt += "    ,GOODSSTOCKMSTBOOTDIVRF" + Environment.NewLine; // ADD ���N 2013/05/02 Redmine#35434
                                sqlTxt += " FROM ALLDEFSETRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                                sqlTxt += "    AND SECTIONCODERF>@FINDSECTIONCODE" + Environment.NewLine;
                                sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                                sqlCommand.CommandText = sqlTxt;
                                // 2008.05.27 upd end -----------------------------------<<
                                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
								paraSectionCode.Value = SqlDataMediator.SqlSetString(alldefsetWork.SectionCode);
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
                            // 2008.05.27 upd start --------------------------------->>
							//sqlCommand.CommandText = "SELECT * FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY SECTIONCODERF";
                            sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                            sqlTxt += "    ,DEFDSPCUSTTTLDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,DEFDSPCUSTCLCTMNYDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,DEFDSPCLCTMNYMONTHCDRF" + Environment.NewLine;
                            sqlTxt += "    ,INIDSPPRSLORCORPCDRF" + Environment.NewLine;
                            sqlTxt += "    ,INITDSPDMDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,DEFDSPBILLPRTDIVCDRF" + Environment.NewLine;
                            sqlTxt += "    ,ERANAMEDISPCD1RF" + Environment.NewLine;
                            sqlTxt += "    ,ERANAMEDISPCD2RF" + Environment.NewLine;
                            sqlTxt += "    ,ERANAMEDISPCD3RF" + Environment.NewLine;
                            sqlTxt += "    ,GOODSNOINPDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,CNSTAXAUTOCORRDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,REMAINCNTMNGDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,MEMOMOVEDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,REMCNTAUTODSPDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,TTLAMNTDSPRATEDIVCDRF" + Environment.NewLine;
                            // --- ADD  ���r��  2010/01/15 ---------->>>>>
                            sqlTxt += "    ,DEFTTLBILLOUTPUTRF" + Environment.NewLine;
                            sqlTxt += "    ,DEFDTLBILLOUTPUTRF" + Environment.NewLine;
                            sqlTxt += "    ,DEFSLTTLBILLOUTPUTRF" + Environment.NewLine;
                            // --- ADD  ���r��  2010/01/15 ----------<<<<<
                            sqlTxt += "    ,DTLCALCSTCKCNTDSPRF" + Environment.NewLine; //ADD 2011/07/19
                            sqlTxt += "    ,GOODSSTOCKMSTBOOTDIVRF" + Environment.NewLine; // ADD ���N 2013/05/02 Redmine#35434
                            sqlTxt += " FROM ALLDEFSETRF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            // 2008.05.27 upd end -----------------------------------<<
                        }
						else
						{
							//�ꌏ�ڃ��[�h�̏ꍇ
							if ((alldefsetWork.SectionCode == null)||(alldefsetWork.SectionCode == ""))
							{
                                // 2008.05.27 upd start --------------------------------->>
								//sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY SECTIONCODERF";
                                sqlTxt += "SELECT TOP" + Environment.NewLine;
                                sqlTxt += _readCnt.ToString() + Environment.NewLine;
                                sqlTxt += "    ,CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlTxt += "    ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCUSTTTLDAYRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCUSTCLCTMNYDAYRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCLCTMNYMONTHCDRF" + Environment.NewLine;
                                sqlTxt += "    ,INIDSPPRSLORCORPCDRF" + Environment.NewLine;
                                sqlTxt += "    ,INITDSPDMDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPBILLPRTDIVCDRF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD1RF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD2RF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD3RF" + Environment.NewLine;
                                sqlTxt += "    ,GOODSNOINPDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,CNSTAXAUTOCORRDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,REMAINCNTMNGDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,MEMOMOVEDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,REMCNTAUTODSPDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,TTLAMNTDSPRATEDIVCDRF" + Environment.NewLine;
                                // --- ADD  ���r��  2010/01/15 ---------->>>>>
                                sqlTxt += "    ,DEFTTLBILLOUTPUTRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDTLBILLOUTPUTRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFSLTTLBILLOUTPUTRF" + Environment.NewLine;
                                // --- ADD  ���r��  2010/01/15 ----------<<<<<
                                sqlTxt += "    ,DTLCALCSTCKCNTDSPRF" + Environment.NewLine; //ADD 2011/07/19
                                sqlTxt += "    ,GOODSSTOCKMSTBOOTDIVRF" + Environment.NewLine; // ADD ���N 2013/05/02 Redmine#35434
                                sqlTxt += " FROM ALLDEFSETRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                                sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                                sqlCommand.CommandText = sqlTxt;
                                // 2008.05.27 upd end -----------------------------------<<							
                            }
								//Next���[�h�̏ꍇ
							else
							{
                                // 2008.05.27 upd start --------------------------------->>
								//sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM ALLDEFSETRF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE AND SECTIONCODERF>@FINDSECTIONCODE ORDER BY SECTIONCODERF";
                                sqlTxt += "SELECT TOP" + Environment.NewLine;
                                sqlTxt += _readCnt.ToString() + Environment.NewLine;
                                sqlTxt += "    ,CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlTxt += "    ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCUSTTTLDAYRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCUSTCLCTMNYDAYRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCLCTMNYMONTHCDRF" + Environment.NewLine;
                                sqlTxt += "    ,INIDSPPRSLORCORPCDRF" + Environment.NewLine;
                                sqlTxt += "    ,INITDSPDMDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPBILLPRTDIVCDRF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD1RF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD2RF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD3RF" + Environment.NewLine;
                                sqlTxt += "    ,GOODSNOINPDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,CNSTAXAUTOCORRDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,REMAINCNTMNGDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,MEMOMOVEDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,REMCNTAUTODSPDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,TTLAMNTDSPRATEDIVCDRF" + Environment.NewLine;
                                // --- ADD  ���r��  2010/01/15 ---------->>>>>
                                sqlTxt += "    ,DEFTTLBILLOUTPUTRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDTLBILLOUTPUTRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFSLTTLBILLOUTPUTRF" + Environment.NewLine;
                                // --- ADD  ���r��  2010/01/15 ----------<<<<<
                                sqlTxt += "    ,DTLCALCSTCKCNTDSPRF" + Environment.NewLine; //ADD 2011/07/19
                                sqlTxt += "    ,GOODSSTOCKMSTBOOTDIVRF" + Environment.NewLine; // ADD ���N 2013/05/02 Redmine#35434
                                sqlTxt += " FROM ALLDEFSETRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                                sqlTxt += "    AND SECTIONCODERF>@FINDSECTIONCODE" + Environment.NewLine;
                                sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                                sqlCommand.CommandText = sqlTxt;
                                // 2008.05.27 upd end -----------------------------------<<                                

                                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
								paraSectionCode.Value = SqlDataMediator.SqlSetString(alldefsetWork.SectionCode);
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
                            // 2008.05.27 upd start --------------------------------->>
							//sqlCommand.CommandText = "SELECT * FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY SECTIONCODERF";
                            sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                            sqlTxt += "    ,DEFDSPCUSTTTLDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,DEFDSPCUSTCLCTMNYDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,DEFDSPCLCTMNYMONTHCDRF" + Environment.NewLine;
                            sqlTxt += "    ,INIDSPPRSLORCORPCDRF" + Environment.NewLine;
                            sqlTxt += "    ,INITDSPDMDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,DEFDSPBILLPRTDIVCDRF" + Environment.NewLine;
                            sqlTxt += "    ,ERANAMEDISPCD1RF" + Environment.NewLine;
                            sqlTxt += "    ,ERANAMEDISPCD2RF" + Environment.NewLine;
                            sqlTxt += "    ,ERANAMEDISPCD3RF" + Environment.NewLine;
                            sqlTxt += "    ,GOODSNOINPDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,CNSTAXAUTOCORRDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,REMAINCNTMNGDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,MEMOMOVEDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,REMCNTAUTODSPDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,TTLAMNTDSPRATEDIVCDRF" + Environment.NewLine;
                            // --- ADD  ���r��  2010/01/15 ---------->>>>>
                            sqlTxt += "    ,DEFTTLBILLOUTPUTRF" + Environment.NewLine;
                            sqlTxt += "    ,DEFDTLBILLOUTPUTRF" + Environment.NewLine;
                            sqlTxt += "    ,DEFSLTTLBILLOUTPUTRF" + Environment.NewLine;
                            // --- ADD  ���r��  2010/01/15 ----------<<<<<
                            sqlTxt += "    ,DTLCALCSTCKCNTDSPRF" + Environment.NewLine; //ADD 2011/07/19
                            sqlTxt += "    ,GOODSSTOCKMSTBOOTDIVRF" + Environment.NewLine; // ADD ���N 2013/05/02 Redmine#35434
                            sqlTxt += " FROM ALLDEFSETRF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            // 2008.05.27 upd end -----------------------------------<<                        
                        }
						else
						{
							//�ꌏ�ڃ��[�h�̏ꍇ
							if ((alldefsetWork.SectionCode == null)||(alldefsetWork.SectionCode == ""))
							{
                                // 2008.05.27 upd start --------------------------------->>
								//sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY SECTIONCODERF";
                                sqlTxt += "SELECT TOP" + Environment.NewLine;
                                sqlTxt += _readCnt.ToString() + Environment.NewLine;
                                sqlTxt += "    ,CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlTxt += "    ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCUSTTTLDAYRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCUSTCLCTMNYDAYRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCLCTMNYMONTHCDRF" + Environment.NewLine;
                                sqlTxt += "    ,INIDSPPRSLORCORPCDRF" + Environment.NewLine;
                                sqlTxt += "    ,INITDSPDMDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPBILLPRTDIVCDRF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD1RF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD2RF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD3RF" + Environment.NewLine;
                                sqlTxt += "    ,GOODSNOINPDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,CNSTAXAUTOCORRDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,REMAINCNTMNGDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,MEMOMOVEDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,REMCNTAUTODSPDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,TTLAMNTDSPRATEDIVCDRF" + Environment.NewLine;
                                // --- ADD  ���r��  2010/01/15 ---------->>>>>
                                sqlTxt += "    ,DEFTTLBILLOUTPUTRF" + Environment.NewLine; 
                                sqlTxt += "    ,DEFDTLBILLOUTPUTRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFSLTTLBILLOUTPUTRF" + Environment.NewLine;
                                // --- ADD  ���r��  2010/01/15 ----------<<<<<
                                sqlTxt += "    ,DTLCALCSTCKCNTDSPRF" + Environment.NewLine; //ADD 2011/07/19
                                sqlTxt += "    ,GOODSSTOCKMSTBOOTDIVRF" + Environment.NewLine; // ADD ���N 2013/05/02 Redmine#35434
                                sqlTxt += " FROM ALLDEFSETRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                                sqlCommand.CommandText = sqlTxt;
                                // 2008.05.27 upd end -----------------------------------<<
                            }
							else
							{
                                // 2008.05.27 upd start --------------------------------->>
								//sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF>@FINDSECTIONCODE ORDER BY SECTIONCODERF";
                                sqlTxt += "SELECT TOP" + Environment.NewLine;
                                sqlTxt += _readCnt.ToString() + Environment.NewLine;
                                sqlTxt += "    ,CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlTxt += "    ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCUSTTTLDAYRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCUSTCLCTMNYDAYRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCLCTMNYMONTHCDRF" + Environment.NewLine;
                                sqlTxt += "    ,INIDSPPRSLORCORPCDRF" + Environment.NewLine;
                                sqlTxt += "    ,INITDSPDMDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPBILLPRTDIVCDRF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD1RF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD2RF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD3RF" + Environment.NewLine;
                                sqlTxt += "    ,GOODSNOINPDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,CNSTAXAUTOCORRDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,REMAINCNTMNGDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,MEMOMOVEDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,REMCNTAUTODSPDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,TTLAMNTDSPRATEDIVCDRF" + Environment.NewLine;
                                // --- ADD  ���r��  2010/01/15 ---------->>>>>
                                sqlTxt += "    ,DEFTTLBILLOUTPUTRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDTLBILLOUTPUTRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFSLTTLBILLOUTPUTRF" + Environment.NewLine;
                                // --- ADD  ���r��  2010/01/15 ----------<<<<<
                                sqlTxt += "    ,DTLCALCSTCKCNTDSPRF" + Environment.NewLine; //ADD 2011/07/19
                                sqlTxt += "    ,GOODSSTOCKMSTBOOTDIVRF" + Environment.NewLine; // ADD ���N 2013/05/02 Redmine#35434
                                sqlTxt += " FROM ALLDEFSETRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    AND SECTIONCODERF>@FINDSECTIONCODE" + Environment.NewLine;
                                sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                                sqlCommand.CommandText = sqlTxt;
                                // 2008.05.27 upd end -----------------------------------<<
                                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
								paraSectionCode.Value = SqlDataMediator.SqlSetString(alldefsetWork.SectionCode);
							}
						}
					}
					SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(alldefsetWork.EnterpriseCode);

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
						AllDefSetWork wkAllDefSetWork = new AllDefSetWork();

						wkAllDefSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
						wkAllDefSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
						wkAllDefSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
						wkAllDefSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
						wkAllDefSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
						wkAllDefSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
						wkAllDefSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
						wkAllDefSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
						wkAllDefSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONCODERF"));
						
						// �� 20061128 18322 d
						//wkAllDefSetWork.DistrictCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DISTRICTCODERF"));
						//wkAllDefSetWork.DefDispAddrCd1 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEFDISPADDRCD1RF"));
						//wkAllDefSetWork.DefDispAddrCd2 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEFDISPADDRCD2RF"));
						//wkAllDefSetWork.DefDispAddrCd3 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEFDISPADDRCD3RF"));
						//wkAllDefSetWork.DefDispAddress = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("DEFDISPADDRESSRF"));
						//wkAllDefSetWork.No88AutoLiaCalcDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NO88AUTOLIACALCDIVRF"));
						//wkAllDefSetWork.CarFixSelectMethod = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CARFIXSELECTMETHODRF"));
						// �� 20061128 18322 d
						
						wkAllDefSetWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
                        //wkAllDefSetWork.CustCdAutoNumbering = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTCDAUTONUMBERINGRF")); // 2007.05.27 del
                        //wkAllDefSetWork.CustomerDelChkDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERDELCHKDIVCDRF")); // 2007.05.27 del
						wkAllDefSetWork.DefDspCustTtlDay = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEFDSPCUSTTTLDAYRF"));
						wkAllDefSetWork.DefDspCustClctMnyDay = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEFDSPCUSTCLCTMNYDAYRF"));
						wkAllDefSetWork.DefDspClctMnyMonthCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEFDSPCLCTMNYMONTHCDRF"));
						wkAllDefSetWork.IniDspPrslOrCorpCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("INIDSPPRSLORCORPCDRF"));
						wkAllDefSetWork.InitDspDmDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("INITDSPDMDIVRF"));
						wkAllDefSetWork.DefDspBillPrtDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEFDSPBILLPRTDIVCDRF"));
                        // 2007.03.05 added by T-Kidate
                        //wkAllDefSetWork.MemberInfoDispCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MEMBERINFODISPCDRF")); // 2007.05.27 del
                        // �� 2007.08.16 980081 a
                        wkAllDefSetWork.EraNameDispCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD1RF"));
                        wkAllDefSetWork.EraNameDispCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD2RF"));
                        wkAllDefSetWork.EraNameDispCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD3RF"));
                        // �� 2007.08.16 980081 a
                        // �� 2007.12.17 980081 a
                        // �� 2008.01.10 980081 d
                        //wkAllDefSetWork.SecMngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SECMNGDIVRF"));
                        // �� 2008.01.10 980081 d
                        wkAllDefSetWork.GoodsNoInpDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSNOINPDIVRF"));
                        wkAllDefSetWork.CnsTaxAutoCorrDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CNSTAXAUTOCORRDIVRF"));
                        wkAllDefSetWork.RemainCntMngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("REMAINCNTMNGDIVRF"));
                        wkAllDefSetWork.MemoMoveDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MEMOMOVEDIVRF"));
                        wkAllDefSetWork.RemCntAutoDspDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("REMCNTAUTODSPDIVRF"));
                        wkAllDefSetWork.TtlAmntDspRateDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDSPRATEDIVCDRF"));
                        // �� 2007.12.17 980081 a
                        // --- ADD  ���r��  2010/01/15 ---------->>>>>
                        wkAllDefSetWork.DefTtlBillOutput = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFTTLBILLOUTPUTRF"));  // �����\�����v�������o�͋敪
                        wkAllDefSetWork.DefDtlBillOutput = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFDTLBILLOUTPUTRF"));  // �����\�����א������o�͋敪
                        wkAllDefSetWork.DefSlTtlBillOutput = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFSLTTLBILLOUTPUTRF"));  // �����\���`�[���v�������o�͋敪
                        // --- ADD  ���r��  2010/01/15 ----------<<<<<
                        wkAllDefSetWork.DtlCalcStckCntDsp = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DTLCALCSTCKCNTDSPRF"));//�d���E�o�׌㐔�\���敪 //ADD 2011/07/19
                        wkAllDefSetWork.GoodsStockMstBootDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSSTOCKMSTBOOTDIVRF"));//���i�݌ɋN���敪 //ADD ���N 2013/05/02 Remdmine#35434

						al.Add(wkAllDefSetWork);

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				}
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"AllDefSetDB.SearchProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();
					sqlConnection.Close();
				}
			}
			retobj = al;
			return status;

		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̑S�̏����lLIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retArray">��������</param>
		/// <param name="alldefsetWork">�����p�����[�^</param>
		/// <param name="sqlConnection">�ȸ��ݏ��</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̑S�̏����lLIST��S�Ė߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.03</br>
		public int Search(out ArrayList retArray, AllDefSetWork alldefsetWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
		{		
			return SearchProc(out retArray, alldefsetWork, logicalMode, ref sqlConnection);
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̑S�̏����lLIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retArray">��������</param>
		/// <param name="alldefsetWork">�����p�����[�^</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="sqlConnection">�ȸ��ݏ��</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̑S�̏����lLIST��S�Ė߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.03</br>
        /// <br>Update Note: ���N</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>�Ǘ��ԍ�   : 10901273-00 2013/06/18�z�M��</br>
        /// <br>           : Redmine#35434�̑Ή�</br>
		private int SearchProc(out ArrayList retArray, AllDefSetWork alldefsetWork, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlDataReader myReader = null;

			retArray = null;
            string sqlTxt = string.Empty; // 2008.05.27 add

			ArrayList al = new ArrayList();
			try 
			{	

				using(SqlCommand sqlCommand = new SqlCommand("",sqlConnection))
				{
					//�f�[�^�Ǎ�
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
						(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||
						(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
                        // 2008.05.27 upd start --------------------------------------->>
						//sqlCommand.CommandText = "SELECT * FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                        sqlTxt += "    ,DEFDSPCUSTTTLDAYRF" + Environment.NewLine;
                        sqlTxt += "    ,DEFDSPCUSTCLCTMNYDAYRF" + Environment.NewLine;
                        sqlTxt += "    ,DEFDSPCLCTMNYMONTHCDRF" + Environment.NewLine;
                        sqlTxt += "    ,INIDSPPRSLORCORPCDRF" + Environment.NewLine;
                        sqlTxt += "    ,INITDSPDMDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,DEFDSPBILLPRTDIVCDRF" + Environment.NewLine;
                        sqlTxt += "    ,ERANAMEDISPCD1RF" + Environment.NewLine;
                        sqlTxt += "    ,ERANAMEDISPCD2RF" + Environment.NewLine;
                        sqlTxt += "    ,ERANAMEDISPCD3RF" + Environment.NewLine;
                        sqlTxt += "    ,GOODSNOINPDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,CNSTAXAUTOCORRDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,REMAINCNTMNGDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,MEMOMOVEDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,REMCNTAUTODSPDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,TTLAMNTDSPRATEDIVCDRF" + Environment.NewLine;
                        // --- ADD  ���r��  2010/01/15 ---------->>>>>
                        sqlTxt += "    ,DEFTTLBILLOUTPUTRF" + Environment.NewLine;
                        sqlTxt += "    ,DEFDTLBILLOUTPUTRF" + Environment.NewLine;
                        sqlTxt += "    ,DEFSLTTLBILLOUTPUTRF" + Environment.NewLine;
                        // --- ADD  ���r��  2010/01/15 ----------<<<<<
                        sqlTxt += "    ,DTLCALCSTCKCNTDSPRF" + Environment.NewLine; //ADD 2011/07/19
                        sqlTxt += "    ,GOODSSTOCKMSTBOOTDIVRF" + Environment.NewLine; // ADD ���N 2013/05/02 Redmine#35434
                        sqlTxt += " FROM ALLDEFSETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.27 upd end -----------------------------------------<<
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					}
					else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
						(logicalMode == ConstantManagement.LogicalMode.GetData012))
					{
                        // 2008.05.27 upd start --------------------------------------->>
						//sqlCommand.CommandText = "SELECT * FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE";
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                        sqlTxt += "    ,DEFDSPCUSTTTLDAYRF" + Environment.NewLine;
                        sqlTxt += "    ,DEFDSPCUSTCLCTMNYDAYRF" + Environment.NewLine;
                        sqlTxt += "    ,DEFDSPCLCTMNYMONTHCDRF" + Environment.NewLine;
                        sqlTxt += "    ,INIDSPPRSLORCORPCDRF" + Environment.NewLine;
                        sqlTxt += "    ,INITDSPDMDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,DEFDSPBILLPRTDIVCDRF" + Environment.NewLine;
                        sqlTxt += "    ,ERANAMEDISPCD1RF" + Environment.NewLine;
                        sqlTxt += "    ,ERANAMEDISPCD2RF" + Environment.NewLine;
                        sqlTxt += "    ,ERANAMEDISPCD3RF" + Environment.NewLine;
                        sqlTxt += "    ,GOODSNOINPDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,CNSTAXAUTOCORRDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,REMAINCNTMNGDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,MEMOMOVEDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,REMCNTAUTODSPDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,TTLAMNTDSPRATEDIVCDRF" + Environment.NewLine;
                        // --- ADD  ���r��  2010/01/15 ---------->>>>>
                        sqlTxt += "    ,DEFTTLBILLOUTPUTRF" + Environment.NewLine;
                        sqlTxt += "    ,DEFDTLBILLOUTPUTRF" + Environment.NewLine; 
                        sqlTxt += "    ,DEFSLTTLBILLOUTPUTRF" + Environment.NewLine;
                        // --- ADD  ���r��  2010/01/15 ----------<<<<<
                        sqlTxt += "    ,DTLCALCSTCKCNTDSPRF" + Environment.NewLine; //ADD 2011/07/19
                        sqlTxt += "    ,GOODSSTOCKMSTBOOTDIVRF" + Environment.NewLine; // ADD ���N 2013/05/02 Redmine#35434
                        sqlTxt += " FROM ALLDEFSETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.27 upd end -----------------------------------------<<
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
						else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
					}
					else
					{
                        // 2008.05.27 upd start --------------------------------------->>
						//sqlCommand.CommandText = "SELECT * FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                        sqlTxt += "    ,DEFDSPCUSTTTLDAYRF" + Environment.NewLine;
                        sqlTxt += "    ,DEFDSPCUSTCLCTMNYDAYRF" + Environment.NewLine;
                        sqlTxt += "    ,DEFDSPCLCTMNYMONTHCDRF" + Environment.NewLine;
                        sqlTxt += "    ,INIDSPPRSLORCORPCDRF" + Environment.NewLine;
                        sqlTxt += "    ,INITDSPDMDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,DEFDSPBILLPRTDIVCDRF" + Environment.NewLine;
                        sqlTxt += "    ,ERANAMEDISPCD1RF" + Environment.NewLine;
                        sqlTxt += "    ,ERANAMEDISPCD2RF" + Environment.NewLine;
                        sqlTxt += "    ,ERANAMEDISPCD3RF" + Environment.NewLine;
                        sqlTxt += "    ,GOODSNOINPDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,CNSTAXAUTOCORRDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,REMAINCNTMNGDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,MEMOMOVEDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,REMCNTAUTODSPDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,TTLAMNTDSPRATEDIVCDRF" + Environment.NewLine;
                        // --- ADD  ���r��  2010/01/15 ---------->>>>>
                        sqlTxt += "    ,DEFTTLBILLOUTPUTRF" + Environment.NewLine;
                        sqlTxt += "    ,DEFDTLBILLOUTPUTRF" + Environment.NewLine;
                        sqlTxt += "    ,DEFSLTTLBILLOUTPUTRF" + Environment.NewLine;
                        // --- ADD  ���r��  2010/01/15 ----------<<<<<
                        sqlTxt += "    ,DTLCALCSTCKCNTDSPRF" + Environment.NewLine; //ADD 2011/07/19
                        sqlTxt += "    ,GOODSSTOCKMSTBOOTDIVRF" + Environment.NewLine; // ADD ���N 2013/05/02 Redmine#35434
                        sqlTxt += " FROM ALLDEFSETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.27 upd end -----------------------------------------<<
					}
					if(alldefsetWork.SectionCode != "")
					{
						sqlCommand.CommandText = sqlCommand.CommandText + " AND SECTIONCODERF=@FINDSECTIONCODE";
						SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
						findParaSectionCode.Value = SqlDataMediator.SqlSetString(alldefsetWork.SectionCode);
					}
					sqlCommand.CommandText = sqlCommand.CommandText + " ORDER BY SECTIONCODERF";

					SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(alldefsetWork.EnterpriseCode);

					myReader = sqlCommand.ExecuteReader();
					while(myReader.Read())
					{
						AllDefSetWork wkAllDefSetWork = new AllDefSetWork();

						wkAllDefSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
						wkAllDefSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
						wkAllDefSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
						wkAllDefSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
						wkAllDefSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
						wkAllDefSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
						wkAllDefSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
						wkAllDefSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
						wkAllDefSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONCODERF"));
						
						// �� 20061128 18322 d
						//wkAllDefSetWork.DistrictCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DISTRICTCODERF"));
						//wkAllDefSetWork.DefDispAddrCd1 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEFDISPADDRCD1RF"));
						//wkAllDefSetWork.DefDispAddrCd2 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEFDISPADDRCD2RF"));
						//wkAllDefSetWork.DefDispAddrCd3 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEFDISPADDRCD3RF"));
						//wkAllDefSetWork.DefDispAddress = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("DEFDISPADDRESSRF"));
						//wkAllDefSetWork.No88AutoLiaCalcDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NO88AUTOLIACALCDIVRF"));
						//wkAllDefSetWork.CarFixSelectMethod = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CARFIXSELECTMETHODRF"));
						// �� 20061128 18322 d
						
						wkAllDefSetWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
                        //wkAllDefSetWork.CustCdAutoNumbering = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTCDAUTONUMBERINGRF")); // 2007.05.27 del
                        //wkAllDefSetWork.CustomerDelChkDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERDELCHKDIVCDRF")); // 2007.05.27 del
						wkAllDefSetWork.DefDspCustTtlDay = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEFDSPCUSTTTLDAYRF"));
						wkAllDefSetWork.DefDspCustClctMnyDay = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEFDSPCUSTCLCTMNYDAYRF"));
						wkAllDefSetWork.DefDspClctMnyMonthCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEFDSPCLCTMNYMONTHCDRF"));
						wkAllDefSetWork.IniDspPrslOrCorpCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("INIDSPPRSLORCORPCDRF"));
						wkAllDefSetWork.InitDspDmDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("INITDSPDMDIVRF"));
						wkAllDefSetWork.DefDspBillPrtDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEFDSPBILLPRTDIVCDRF"));
                        // 2007.03.05 added by T-Kidate
                        //wkAllDefSetWork.MemberInfoDispCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MEMBERINFODISPCDRF"));// 2007.05.27 del
                        // �� 2007.08.16 980081 a
                        wkAllDefSetWork.EraNameDispCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD1RF"));
                        wkAllDefSetWork.EraNameDispCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD2RF"));
                        wkAllDefSetWork.EraNameDispCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD3RF"));
                        // �� 2007.08.16 980081 a
                        // �� 2007.12.17 980081 a
                        // �� 2008.01.10 980081 d
                        //wkAllDefSetWork.SecMngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SECMNGDIVRF"));
                        // �� 2008.01.10 980081 d
                        wkAllDefSetWork.GoodsNoInpDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSNOINPDIVRF"));
                        wkAllDefSetWork.CnsTaxAutoCorrDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CNSTAXAUTOCORRDIVRF"));
                        wkAllDefSetWork.RemainCntMngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("REMAINCNTMNGDIVRF"));
                        wkAllDefSetWork.MemoMoveDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MEMOMOVEDIVRF"));
                        wkAllDefSetWork.RemCntAutoDspDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("REMCNTAUTODSPDIVRF"));
                        wkAllDefSetWork.TtlAmntDspRateDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDSPRATEDIVCDRF"));
                        // �� 2007.12.17 980081 a
                        // --- ADD  ���r��  2010/01/15 ---------->>>>>
                        wkAllDefSetWork.DefTtlBillOutput = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFTTLBILLOUTPUTRF"));  // �����\�����v�������o�͋敪
                        wkAllDefSetWork.DefDtlBillOutput = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFDTLBILLOUTPUTRF"));  // �����\�����א������o�͋敪
                        wkAllDefSetWork.DefSlTtlBillOutput = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFSLTTLBILLOUTPUTRF"));  // �����\���`�[���v�������o�͋敪
                        // --- ADD  ���r��  2010/01/15 ----------<<<<<
                        wkAllDefSetWork.DtlCalcStckCntDsp = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DTLCALCSTCKCNTDSPRF"));  //�d���E�o�׌㐔�\���敪  //ADD 2011/07/19
                        wkAllDefSetWork.GoodsStockMstBootDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSSTOCKMSTBOOTDIVRF"));//���i�݌ɋN���敪 //ADD ���N 2013/05/02 Remdmine#35434

						al.Add(wkAllDefSetWork);

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				}
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"AllDefSetDB.SearchProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
			}

			retArray = al;
			return status;

		}
		#endregion

        #region [GetSyncdataList]
        /// <summary>
        /// ���[�J���V���N�p�̃f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="arraylistdata">��������</param>
        /// <param name="syncServiceWork">Sync�p�f�[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.23</br>
        public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            return GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
        }
        /// <summary>
        /// ���[�J���V���N�p�̃f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="arraylistdata">��������</param>
        /// <param name="syncServiceWork">Sync�p�f�[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.23</br>
        /// <br>Update Note: ���N</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>�Ǘ��ԍ�   : 10901273-00 2013/06/18�z�M��</br>
        /// <br>           : Redmine#35434�̑Ή�</br>
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                // 2008.05.27 upd start ---------------------->>
                //sqlCommand = new SqlCommand("SELECT * FROM ALLDEFSETRF ", sqlConnection);
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
                sqlTxt += "    ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDSPCUSTTTLDAYRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDSPCUSTCLCTMNYDAYRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDSPCLCTMNYMONTHCDRF" + Environment.NewLine;
                sqlTxt += "    ,INIDSPPRSLORCORPCDRF" + Environment.NewLine;
                sqlTxt += "    ,INITDSPDMDIVRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDSPBILLPRTDIVCDRF" + Environment.NewLine;
                sqlTxt += "    ,ERANAMEDISPCD1RF" + Environment.NewLine;
                sqlTxt += "    ,ERANAMEDISPCD2RF" + Environment.NewLine;
                sqlTxt += "    ,ERANAMEDISPCD3RF" + Environment.NewLine;
                sqlTxt += "    ,GOODSNOINPDIVRF" + Environment.NewLine;
                sqlTxt += "    ,CNSTAXAUTOCORRDIVRF" + Environment.NewLine;
                sqlTxt += "    ,REMAINCNTMNGDIVRF" + Environment.NewLine;
                sqlTxt += "    ,MEMOMOVEDIVRF" + Environment.NewLine;
                sqlTxt += "    ,REMCNTAUTODSPDIVRF" + Environment.NewLine;
                sqlTxt += "    ,TTLAMNTDSPRATEDIVCDRF" + Environment.NewLine;
                // --- ADD  ���r��  2010/01/15 ---------->>>>>               
                sqlTxt += "    ,DEFTTLBILLOUTPUTRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDTLBILLOUTPUTRF" + Environment.NewLine;
                sqlTxt += "    ,DEFSLTTLBILLOUTPUTRF" + Environment.NewLine;
                // --- ADD  ���r��  2010/01/15 ----------<<<<<
                sqlTxt += "    ,DTLCALCSTCKCNTDSPRF" + Environment.NewLine; //ADD 2011/07/19
                sqlTxt += "    ,GOODSSTOCKMSTBOOTDIVRF" + Environment.NewLine; // ADD ���N 2013/05/02 Redmine#35434
                sqlTxt += " FROM ALLDEFSETRF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.27 upd end ------------------------<<

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToAllDefSetWorkFromReader(ref myReader));
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

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="syncServiceWork">Sync�p�f�[�^</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.23</br>
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

        /// <summary>
        /// SqlDataReader -> AllDefSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>AllDefSetWork</returns>
        /// <remarks>
        /// <br>Update Note: ���N</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>�Ǘ��ԍ�   : 10901273-00 2013/06/18�z�M��</br>
        /// <br>           : Redmine#35434�̑Ή�</br>
        /// </remarks>
        private AllDefSetWork CopyToAllDefSetWorkFromReader(ref SqlDataReader myReader)
        {
            AllDefSetWork allDefSetWork = new AllDefSetWork();
            allDefSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            allDefSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            allDefSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            allDefSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            allDefSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            allDefSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            allDefSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            allDefSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            allDefSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            allDefSetWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
            //allDefSetWork.CustomerDelChkDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERDELCHKDIVCDRF")); // 2007.05.27 del
            //allDefSetWork.CustCdAutoNumbering = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTCDAUTONUMBERINGRF")); // 2007.05.27 del
            allDefSetWork.DefDspCustTtlDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFDSPCUSTTTLDAYRF"));
            allDefSetWork.DefDspCustClctMnyDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFDSPCUSTCLCTMNYDAYRF"));
            allDefSetWork.DefDspClctMnyMonthCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFDSPCLCTMNYMONTHCDRF"));
            allDefSetWork.IniDspPrslOrCorpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INIDSPPRSLORCORPCDRF"));
            allDefSetWork.InitDspDmDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INITDSPDMDIVRF"));
            allDefSetWork.DefDspBillPrtDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFDSPBILLPRTDIVCDRF"));
            //allDefSetWork.MemberInfoDispCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MEMBERINFODISPCDRF"));// 2007.05.27 del
            // �� 2007.08.16 980081 a
            allDefSetWork.EraNameDispCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD1RF"));
            allDefSetWork.EraNameDispCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD2RF"));
            allDefSetWork.EraNameDispCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD3RF"));
            // �� 2007.08.16 980081 a
            // �� 2007.12.17 980081 a
            // �� 2008.01.10 980081 d
            //allDefSetWork.SecMngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SECMNGDIVRF"));
            // �� 2008.01.10 980081 d
            allDefSetWork.GoodsNoInpDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSNOINPDIVRF"));
            allDefSetWork.CnsTaxAutoCorrDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CNSTAXAUTOCORRDIVRF"));
            allDefSetWork.RemainCntMngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("REMAINCNTMNGDIVRF"));
            allDefSetWork.MemoMoveDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MEMOMOVEDIVRF"));
            allDefSetWork.RemCntAutoDspDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("REMCNTAUTODSPDIVRF"));
            allDefSetWork.TtlAmntDspRateDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDSPRATEDIVCDRF"));
            // �� 2007.12.17 980081 a
            // --- ADD  ���r��  2010/01/15 ---------->>>>>
            allDefSetWork.DefTtlBillOutput = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFTTLBILLOUTPUTRF"));  // �����\�����v�������o�͋敪
            allDefSetWork.DefDtlBillOutput = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFDTLBILLOUTPUTRF"));  // �����\�����א������o�͋敪
            allDefSetWork.DefSlTtlBillOutput = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFSLTTLBILLOUTPUTRF"));  // �����\���`�[���v�������o�͋敪
            // --- ADD  ���r��  2010/01/15 ----------<<<<<
            allDefSetWork.DtlCalcStckCntDsp = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DTLCALCSTCKCNTDSPRF"));  //�d���E�o�׌㐔�\���敪   //ADD 2011/07/19
            allDefSetWork.GoodsStockMstBootDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSSTOCKMSTBOOTDIVRF"));// ADD ���N�@2013/05/02 Redmine#35434 
            return allDefSetWork;
        }
        #endregion

    }
}
