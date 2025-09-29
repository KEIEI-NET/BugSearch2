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

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���R���[�󎚍��ڃ����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���R���[�󎚍��ڂ̌������s���N���X�ł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.05.07</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	[Serializable]
	public class PrtItemSetDB : RemoteDB, IPrtItemSetDB
	{
		#region Constructor
		/// <summary>
		/// ���R���[�󎚍��ڃ����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note		: DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.07</br>
		/// </remarks>
		public PrtItemSetDB()
			: base("SFTKD08113D", "Broadleaf.Application.Remoting.ParamData.PrtItemSetWork", "PRTITEMSETRF")
		{
		}
		#endregion

		#region IPrtItemSetDB �����o
		/// <summary>
		/// ���R���[�󎚍��ڃO���[�v��������
		/// </summary>
		/// <param name="prtItemGrpWorkArray">���R���[�󎚍��ڃO���[�v�z��</param>
		/// <param name="msgDiv">���b�Z�[�W�敪</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: ���R���[���ڃO���[�v�}�X�^�z���S���擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.07</br>
		/// </remarks>
        public int SearchPrtItemGrp( out object prtItemGrpWorkArray, out bool msgDiv, out string errMsg )
        {
            return SearchPrtItemGrpProc( out prtItemGrpWorkArray, out msgDiv, out errMsg );
        }
        /// <summary>
        /// ���R���[�󎚍��ڃO���[�v��������
        /// </summary>
        /// <param name="prtItemGrpWorkArray">���R���[�󎚍��ڃO���[�v�z��</param>
        /// <param name="msgDiv">���b�Z�[�W�敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int SearchPrtItemGrpProc( out object prtItemGrpWorkArray, out bool msgDiv, out string errMsg )
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			msgDiv = false;
			errMsg = string.Empty;
			prtItemGrpWorkArray = null;

			SqlConnection sqlConnection = null;
			try
			{
				List<PrtItemGrpWork> wkPrtItemGrpWork;

				//SQL������
				using (sqlConnection = CreateSqlConnection())
				{
					sqlConnection.Open();

					status = SearchPrtItemGrpProc(out wkPrtItemGrpWork, sqlConnection);
					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						prtItemGrpWorkArray = wkPrtItemGrpWork.ToArray();
				}
			}
			catch (SqlException ex)
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex, "PrtItemSetDB.SearchPrtItemGrp", status);
				if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
				{
					msgDiv = true;
					errMsg = "���R���[�󎚍��ڃO���[�v�������Ƀ^�C���A�E�g���������܂����B";
				}
				else
				{
					errMsg = ex.Message;
				}
			}
			catch (Exception ex)
			{
				base.WriteErrorLog(ex, "PrtItemSetDB.SearchPrtItemGrp", (int)ConstantManagement.MethodResult.ctFNC_ERROR);
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
			finally
			{
				if (sqlConnection != null) sqlConnection.Close();
			}

			return status;
		}

		/// <summary>
		/// ���R���[�󎚍��ڐݒ茟������
		/// </summary>
		/// <param name="freePrtPprItemGrpCd">���R���[���ڃO���[�v�R�[�h</param>
		/// <param name="retCustomSerializeArrayList">�󎚍��ڏ��J�X�^���V���A���C�YLIST</param>
		/// <param name="msgDiv">���b�Z�[�W�敪</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ���R���[���ڐݒ�}�X�^�z����擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.07</br>
		/// </remarks>
        public int SearchPrtItemSet( int freePrtPprItemGrpCd, out object retCustomSerializeArrayList, out bool msgDiv, out string errMsg )
        {
            return SearchPrtItemSetProc( freePrtPprItemGrpCd, out retCustomSerializeArrayList, out msgDiv, out errMsg );
        }
        /// <summary>
        /// ���R���[�󎚍��ڐݒ茟������
        /// </summary>
        /// <param name="freePrtPprItemGrpCd">���R���[���ڃO���[�v�R�[�h</param>
        /// <param name="retCustomSerializeArrayList">�󎚍��ڏ��J�X�^���V���A���C�YLIST</param>
        /// <param name="msgDiv">���b�Z�[�W�敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int SearchPrtItemSetProc( int freePrtPprItemGrpCd, out object retCustomSerializeArrayList, out bool msgDiv, out string errMsg )
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			msgDiv = false;
			errMsg = string.Empty;
			retCustomSerializeArrayList = new CustomSerializeArrayList();

			SqlConnection sqlConnection = null;
			try
			{
				CustomSerializeArrayList retList = new CustomSerializeArrayList();

				//SQL������
				using (sqlConnection = CreateSqlConnection())
				{
					sqlConnection.Open();

					List<PrtItemSetWork> prtItemSetList;
					status = SearchPrtItemSetProc(freePrtPprItemGrpCd, out prtItemSetList, sqlConnection);
					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						retList.Add(new ArrayList(prtItemSetList));

						// ���R���[�\�[�g���ʏ����l�}�X�^�̎擾
						FPprSchmGrDB fPprSchmGrDB = new FPprSchmGrDB();
						List<FPSortInitWork> fPSortInitList;
						status = fPprSchmGrDB.SearchFPSortInitProc(out fPSortInitList, freePrtPprItemGrpCd, new int[] { 0 }, ref sqlConnection);
						switch (status)
						{
							case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
							{
								retList.Add(new ArrayList(fPSortInitList));
								break;
							}
							case (int)ConstantManagement.DB_Status.ctDB_EOF:
							{
								status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
								break;
							}
						}
					}

					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						retCustomSerializeArrayList = retList;
				}
			}
			catch (SqlException ex)
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex, "PrtItemSetDB.SearchPrtItemSet", status);
				if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
				{
					msgDiv = true;
					errMsg = "���R���[�󎚍��ڐݒ茟�����Ƀ^�C���A�E�g���������܂����B";
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

		/// <summary>
		/// ���R���[�󎚍��ڐݒ茟������
		/// </summary>
		/// <param name="freePrtPprItemGrpCd">���R���[���ڃO���[�v�R�[�h</param>
		/// <param name="freePrtPprSchmGrpCd">���R���[�X�L�[�}�O���[�v�R�[�h</param>
		/// <param name="retCustomSerializeArrayList">�󎚍��ڏ��J�X�^���V���A���C�YLIST</param>
		/// <param name="msgDiv">���b�Z�[�W�敪</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ���R���[���ڐݒ�}�X�^�z����擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.07</br>
		/// </remarks>
        public int SearchPrtItemSetWithFPprSchmCv( int freePrtPprItemGrpCd, int freePrtPprSchmGrpCd, out object retCustomSerializeArrayList, out bool msgDiv, out string errMsg )
        {
            return SearchPrtItemSetWithFPprSchmCvProc( freePrtPprItemGrpCd, freePrtPprSchmGrpCd, out retCustomSerializeArrayList, out msgDiv, out errMsg );
        }
        /// <summary>
        /// ���R���[�󎚍��ڐݒ茟������
        /// </summary>
        /// <param name="freePrtPprItemGrpCd">���R���[���ڃO���[�v�R�[�h</param>
        /// <param name="freePrtPprSchmGrpCd">���R���[�X�L�[�}�O���[�v�R�[�h</param>
        /// <param name="retCustomSerializeArrayList">�󎚍��ڏ��J�X�^���V���A���C�YLIST</param>
        /// <param name="msgDiv">���b�Z�[�W�敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int SearchPrtItemSetWithFPprSchmCvProc( int freePrtPprItemGrpCd, int freePrtPprSchmGrpCd, out object retCustomSerializeArrayList, out bool msgDiv, out string errMsg )
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			msgDiv = false;
			errMsg = string.Empty;
			retCustomSerializeArrayList = new CustomSerializeArrayList();

			SqlConnection sqlConnection = null;
			try
			{
				CustomSerializeArrayList retList = new CustomSerializeArrayList();

				//SQL������
				using (sqlConnection = CreateSqlConnection())
				{
					sqlConnection.Open();

					// �󎚍��ڐݒ�}�X�^�̎擾
					List<PrtItemSetWork> prtItemSetList;
					status = SearchPrtItemSetProc(freePrtPprItemGrpCd, out prtItemSetList, sqlConnection);
					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						retList.Add(new ArrayList(prtItemSetList));

					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						// ���R���[�X�L�[�}�R���o�[�g�}�X�^�̎擾
						FPprSchmGrDB fPprSchmGrDB = new FPprSchmGrDB();
						List<FPprSchmCvWork> fPprSchmCvList;
						status = fPprSchmGrDB.SearchFPprSchmCvProc(out fPprSchmCvList, freePrtPprSchmGrpCd, ref sqlConnection);
						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							retList.Add(new ArrayList(fPprSchmCvList));

							// ���R���[�\�[�g���ʏ����l�}�X�^�̎擾
							List<FPSortInitWork> fPSortInitList;
							status = fPprSchmGrDB.SearchFPSortInitProc(out fPSortInitList, freePrtPprItemGrpCd, new int[] { 0, freePrtPprSchmGrpCd }, ref sqlConnection);
							switch (status)
							{
								case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
								{
									retList.Add(new ArrayList(fPSortInitList));
									break;
								}
								case (int)ConstantManagement.DB_Status.ctDB_EOF:
								{
									status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
									break;
								}
							}

							if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
							{
								// ���R���[���o���������l�}�X�^�̎擾
								List<FPECndInitWork> fPECndInitList;
								status = fPprSchmGrDB.SearchFPECndInitProc(out fPECndInitList, freePrtPprSchmGrpCd, ref sqlConnection);
								switch (status)
								{
									case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
									{
										retList.Add(new ArrayList(fPECndInitList));
										break;
									}
									case (int)ConstantManagement.DB_Status.ctDB_EOF:
									{
										status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
										break;
									}
								}
							}
						}
					}
				}

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					retCustomSerializeArrayList = retList;
			}
			catch (SqlException ex)
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex, "PrtItemSetDB.SearchPrtItemSetWithFPprSchmCv", status);
				if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
				{
					msgDiv = true;
					errMsg = "���R���[�󎚍��ڐݒ茟�����Ƀ^�C���A�E�g���������܂����B";
				}
				else
				{
					errMsg = ex.Message;
				}
			}
			catch (Exception ex)
			{
				base.WriteErrorLog(ex, "PrtItemSetDB.SearchPrtItemSetWithFPprSchmCv", (int)ConstantManagement.MethodResult.ctFNC_ERROR);
				errMsg = ex.Message;
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
		/// ���R���[�󎚍��ڃO���[�v���������i���C�����j
		/// </summary>
		/// <param name="prtItemGrpWorkList">���R���[�󎚍��ڃO���[�vLIST</param>
		/// <param name="sqlConnection">SQL�R�l�N�V����</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: ���R���[���ڃO���[�v�}�X�^LIST��S���擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.07</br>
		/// </remarks>
		private int SearchPrtItemGrpProc(out List<PrtItemGrpWork> prtItemGrpWorkList, SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			SqlDataReader myReader = null;

			prtItemGrpWorkList = new List<PrtItemGrpWork>();
			try
			{
				//Select�R�}���h�̐���
				SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, FREEPRTPPRITEMGRPCDRF, FREEPRTPPRITEMGRPNMRF, PRINTPAPERUSEDIVCDRF, EXTRACTIONPGIDRF, EXTRACTIONPGCLASSIDRF, OUTPUTPGIDRF, OUTPUTPGCLASSIDRF, DATAINPUTSYSTEMRF, LINKSLIPDATAINPUTSYSRF, LINKSLIPPRTKINDRF, LINKSLIPPRTSETPPRIDRF, EXTRASECTIONKINDCDRF, EXTRASECTIONSELEXISTRF, FORMFEEDLINECOUNTRF, CRCHARCNTRF, FREEPRTPPRSPPRPSECDRF FROM PRTITEMGRPRF", sqlConnection);

				// �^�C���A�E�g���Ԑݒ�
				sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInitial);

				myReader = sqlCommand.ExecuteReader();
				while (myReader.Read())
				{
					PrtItemGrpWork prtItemGrpWork = new PrtItemGrpWork();

					#region �f�[�^�̃R�s�[
					prtItemGrpWork.CreateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
					prtItemGrpWork.UpdateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
					prtItemGrpWork.LogicalDeleteCode	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
					prtItemGrpWork.FreePrtPprItemGrpCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRITEMGRPCDRF"));
					prtItemGrpWork.FreePrtPprItemGrpNm	= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FREEPRTPPRITEMGRPNMRF"));
					prtItemGrpWork.PrintPaperUseDivcd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRINTPAPERUSEDIVCDRF"));
					prtItemGrpWork.ExtractionPgId		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXTRACTIONPGIDRF"));
					prtItemGrpWork.ExtractionPgClassId	= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXTRACTIONPGCLASSIDRF"));
					prtItemGrpWork.OutputPgId			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTPGIDRF"));
					prtItemGrpWork.OutputPgClassId		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTPGCLASSIDRF"));
					prtItemGrpWork.DataInputSystem		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
					prtItemGrpWork.LinkSlipDataInputSys	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LINKSLIPDATAINPUTSYSRF"));
					prtItemGrpWork.LinkSlipPrtKind		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LINKSLIPPRTKINDRF"));
					prtItemGrpWork.LinkSlipPrtSetPprId	= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LINKSLIPPRTSETPPRIDRF"));
					prtItemGrpWork.ExtraSectionKindCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXTRASECTIONKINDCDRF"));
					prtItemGrpWork.ExtraSectionSelExist	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXTRASECTIONSELEXISTRF"));
					prtItemGrpWork.FormFeedLineCount	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FORMFEEDLINECOUNTRF"));
					prtItemGrpWork.CrCharCnt			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CRCHARCNTRF"));
					prtItemGrpWork.FreePrtPprSpPrpseCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRSPPRPSECDRF"));
					#endregion

					prtItemGrpWorkList.Add(prtItemGrpWork);
				}

				if (prtItemGrpWorkList.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
		/// ���R���[�󎚍��ڐݒ茟�������i���C�����j
		/// </summary>
		/// <param name="freePrtPprItemGrpCd">���R���[���ڃO���[�v�R�[�h</param>
		/// <param name="prtItemSetWorkList">���R���[�󎚍��ڐݒ�LIST</param>
		/// <param name="sqlConnection">SQL�R�l�N�V����</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ���R���[���ڐݒ�}�X�^LIST���擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.07</br>
		/// </remarks>
		private int SearchPrtItemSetProc(int freePrtPprItemGrpCd, out List<PrtItemSetWork> prtItemSetWorkList, SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			SqlDataReader myReader = null;

			prtItemSetWorkList = new List<PrtItemSetWork>();

			try
			{
				//Select�R�}���h�̐���
				SqlCommand sqlCommand;
				// ���R���[���ڃO���[�v�R�[�h���w�莞�͑S���擾
				if (freePrtPprItemGrpCd == 0)
				{
					sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, FREEPRTPPRITEMGRPCDRF, FREEPRTPAPERITEMCDRF, FREEPRTPAPERITEMNMRF, FILENMRF, DDCHARCNTRF, DDNAMERF, REPORTCONTROLCODERF, HEADERUSEDIVCDRF, DETAILUSEDIVCDRF, FOOTERUSEDIVCDRF, EXTRACONDITIONDIVCDRF, EXTRACONDITIONTYPECDRF, COMMAEDITEXISTCDRF, PRINTPAGECTRLDIVCDRF, SYSTEMDIVCDRF, OPTIONCODERF, EXTRACONDDETAILGRPCDRF, TOTALITEMDIVCDRF, FORMFEEDITEMDIVCDRF, FREEPRTPPRDISPGRPCDRF, NECESSARYEXTRACONDCDRF, CIPHERFLGRF, EXTRACTIONITDEDFLGRF, GROUPSUPPRESSCDRF, DTLCOLORCHANGECDRF, HEIGHTADJUSTDIVCDRF, ADDITEMUSEDIVCDRF, INPUTCHARCNTRF, BARCODESTYLERF FROM PRTITEMSETRF", sqlConnection);
				}
				else
				{
					sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, FREEPRTPPRITEMGRPCDRF, FREEPRTPAPERITEMCDRF, FREEPRTPAPERITEMNMRF, FILENMRF, DDCHARCNTRF, DDNAMERF, REPORTCONTROLCODERF, HEADERUSEDIVCDRF, DETAILUSEDIVCDRF, FOOTERUSEDIVCDRF, EXTRACONDITIONDIVCDRF, EXTRACONDITIONTYPECDRF, COMMAEDITEXISTCDRF, PRINTPAGECTRLDIVCDRF, SYSTEMDIVCDRF, OPTIONCODERF, EXTRACONDDETAILGRPCDRF, TOTALITEMDIVCDRF, FORMFEEDITEMDIVCDRF, FREEPRTPPRDISPGRPCDRF, NECESSARYEXTRACONDCDRF, CIPHERFLGRF, EXTRACTIONITDEDFLGRF, GROUPSUPPRESSCDRF, DTLCOLORCHANGECDRF, HEIGHTADJUSTDIVCDRF, ADDITEMUSEDIVCDRF, INPUTCHARCNTRF, BARCODESTYLERF FROM PRTITEMSETRF WHERE FREEPRTPPRITEMGRPCDRF=@FINDFREEPRTPPRITEMGRPCD", sqlConnection);

					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter findParaFreePrtPprItemGrpCd = sqlCommand.Parameters.Add("@FINDFREEPRTPPRITEMGRPCD", SqlDbType.Int);
					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaFreePrtPprItemGrpCd.Value = freePrtPprItemGrpCd;
				}
				// �^�C���A�E�g���Ԑݒ�
				sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInitial);

				myReader = sqlCommand.ExecuteReader();
				while (myReader.Read())
				{
					PrtItemSetWork prtItemSetWork = new PrtItemSetWork();

					#region �f�[�^�̃R�s�[
					prtItemSetWork.CreateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
					prtItemSetWork.UpdateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
					prtItemSetWork.LogicalDeleteCode	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
					prtItemSetWork.FreePrtPprItemGrpCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRITEMGRPCDRF"));
					prtItemSetWork.FreePrtPaperItemCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPAPERITEMCDRF"));
					prtItemSetWork.FreePrtPaperItemNm	= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FREEPRTPAPERITEMNMRF"));
					prtItemSetWork.FileNm				= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FILENMRF"));
					prtItemSetWork.DDCharCnt			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DDCHARCNTRF"));
					prtItemSetWork.DDName				= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DDNAMERF"));
					prtItemSetWork.ReportControlCode	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("REPORTCONTROLCODERF"));
					prtItemSetWork.HeaderUseDivCd		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HEADERUSEDIVCDRF"));
					prtItemSetWork.DetailUseDivCd		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILUSEDIVCDRF"));
					prtItemSetWork.FooterUseDivCd		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FOOTERUSEDIVCDRF"));
					prtItemSetWork.ExtraConditionDivCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXTRACONDITIONDIVCDRF"));
					prtItemSetWork.ExtraConditionTypeCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXTRACONDITIONTYPECDRF"));
					prtItemSetWork.CommaEditExistCd		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMMAEDITEXISTCDRF"));
					prtItemSetWork.PrintPageCtrlDivCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRINTPAGECTRLDIVCDRF"));
					prtItemSetWork.SystemDivCd			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SYSTEMDIVCDRF"));
					prtItemSetWork.OptionCode			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OPTIONCODERF"));
					prtItemSetWork.ExtraCondDetailGrpCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXTRACONDDETAILGRPCDRF"));
					prtItemSetWork.TotalItemDivCd		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALITEMDIVCDRF"));
					prtItemSetWork.FormFeedItemDivCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FORMFEEDITEMDIVCDRF"));
					prtItemSetWork.FreePrtPprDispGrpCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRDISPGRPCDRF"));
					prtItemSetWork.NecessaryExtraCondCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NECESSARYEXTRACONDCDRF"));
					prtItemSetWork.CipherFlg			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CIPHERFLGRF"));
					prtItemSetWork.ExtractionItdedFlg	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXTRACTIONITDEDFLGRF"));
					prtItemSetWork.GroupSuppressCd		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GROUPSUPPRESSCDRF"));
					prtItemSetWork.DtlColorChangeCd		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DTLCOLORCHANGECDRF"));
					prtItemSetWork.HeightAdjustDivCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HEIGHTADJUSTDIVCDRF"));
					prtItemSetWork.AddItemUseDivCd		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDITEMUSEDIVCDRF"));
					prtItemSetWork.InputCharCnt			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INPUTCHARCNTRF"));
					prtItemSetWork.BarCodeStyle			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BARCODESTYLERF"));
					#endregion

					prtItemSetWorkList.Add(prtItemSetWork);
				}

				if (prtItemSetWorkList.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
